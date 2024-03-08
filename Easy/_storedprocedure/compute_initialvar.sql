
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/


if exists (select * from dbo.sysobjects where id = object_id(N'[compute_initialvar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_initialvar]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE   PROCEDURE compute_initialvar
	@ayear int,
	@date datetime = null,
	@generatevar char(1) ='N',
	@idupb varchar(36)=null,
	@idsor01 int = null,
	@idsor02 int = null,
	@idsor03 int = null,
	@idsor04 int = null,
	@idsor05 int = null
AS
BEGIN
-- setuser 'amministrazione'
--  compute_initialvar 2018, {ts '2018-11-20 00:00:00'} ,'N',null

if @date is null set @date =  CONVERT(smalldatetime, '31-12-' + CONVERT(char(4), @ayear), 105)
set  @idupb = CASE WHEN @idupb is null THEN '%' else  REPLACE(@idupb+'%','%%','%') END

declare @oggi smalldatetime
set @oggi= convert(datetime, FLOOR(CONVERT(FLOAT,getdate())))


DECLARE @data varchar(13)
SELECT 	@data = CONVERT(varchar(20),@date,5)
DECLARE @firstday datetime
SET 	@firstday = CONVERT(smalldatetime, '01-01-' + CONVERT(char(4), @ayear), 105)
DECLARE @lastday datetime
SET 	@lastday = CONVERT(smalldatetime, '31-12-' + CONVERT(char(4), @ayear), 105)
DECLARE @assessmentphasecode int
SELECT 	@assessmentphasecode = assessmentphasecode FROM config WHERE ayear = @ayear
DECLARE @appropriationphasecode int
SELECT 	@appropriationphasecode = appropriationphasecode FROM config WHERE ayear = @ayear
DECLARE @maxexpensephase int
SELECT 	@maxexpensephase =  MAX(nphase) FROM expensephase
DECLARE @maxincomephase int
SELECT 	@maxincomephase = MAX(nphase) FROM incomephase


-- Ricerca la fase equivalente all'impegno se è stata inserita nella tabella di configurazione  del bilancio
DECLARE @phasebilancio tinyint
SELECT 	@phasebilancio = appropriationphasecode
FROM config
WHERE ayear = @ayear
-- Se non è stata inserita nella tabella di configurazione  ipotizza che si tratti della fase dove viene identificata  la voce di bilancio
IF (@phasebilancio IS NULL)
BEGIN
	SELECT 	@phasebilancio = expensefinphase FROM uniconfig 
END

-- Se @fin_kind = 1 ==> è stata personalizzata una previsione principale di tipo "competenza", se @fin_kind = 2
-- ==> è stata personalizzata una previsione principale di tipo "cassa", se  @fin_kind = 3 ==>comp. e cassa
DECLARE @cashvaliditykind int
SELECT  @cashvaliditykind = cashvaliditykind FROM config WHERE ayear = @ayear

DECLARE @fin_kind tinyint
SELECT @fin_kind = ISNULL(fin_kind ,0) FROM config WHERE ayear = @ayear


DECLARE @nextayear int
SET 	@nextayear = @ayear + 1

DECLARE @minlivop tinyint
DECLARE @maxlivop tinyint

SELECT @minlivop = isnull(MIN(nlevel),1) FROM finlevel WHERE flag&2 <> 0 AND ayear = @nextayear
SELECT @maxlivop = MAX(nlevel) FROM finlevel WHERE ayear = @nextayear

-- Alla stregua della compute_transf_prevision, quando:
-- 1)capitolo 2008 è articolato 
-- 2)capitolo 2009 non è articolato
-- si può spezzare il legame capitolo 2008-2009 in #finlookup

CREATE TABLE #finlookup(
        oldidfin	int,-- ayear
        newidfin	int -- ayear +1
)
INSERT INTO #finlookup(oldidfin,newidfin)
SELECT oldidfin,newidfin
FROM finlookup
JOIN fin
        ON finlookup.oldidfin = fin.idfin
WHERE fin.ayear = @ayear
-- Cancella il capitolo articolato nel 2008, e dearticolato nel 2009.
DELETE FROM #finlookup WHERE EXISTS ( select * from fin where fin.paridfin = #finlookup.oldidfin )--è parent nel  2008
                                AND NOT EXISTS ( select * from fin where fin.paridfin = #finlookup.newidfin )-- non è parent nel 2009

BEGIN  --#@bilprevision_all: previsione iniziale, attuale etc.
	DECLARE @bilprevision_all TABLE 
	(	idupb varchar(36),
		idfin int,
		--idunderwriting int,	
		thisyearprevision decimal (19,2),	        -- prev. principale di finyear(non va in output)
		thisyearsecondaryprevision decimal (19,2),	-- prev. secondaria di finyear(non va in output)
		tot_varprev decimal(19,2),		--variazioni della prev. principale alla data
		tot_varsecondaryprev decimal(19,2),  --variazioni della prev. secondaria alla data,
		totvarcredit  decimal(19,2), --tot.var.crediti alla data
		totvarproceeds decimal(19,2), --tot.var. ass.cassa alla data
		totcreditpart decimal(19,2),   -- ass. Crediti
		totproceedspart decimal(19,2), -- ass. Cassa
		residui1 decimal(19,2),var_residui1 decimal(19,2), --IMPEGNI/ACCERTAMENTI c/residuo, Var. IMPEGNI/ACCERTAMENTI c/residuo
		competenza1 decimal(19,2),-- IMPEGNI/ACCERTAMENTI c/competenza
		competenza_alla_data decimal(19,2),  --IMPEGNI/ACCERTAMENTI c/competenza alla data
		competenza2 decimal(19,2), var_competenza2 decimal(19,2),  -- PAGAMENTI / INCASSI c/competenza 
		residui2 decimal(19,2), var_residui2 decimal(19,2), -- PAGAMENTI / INCASSI c/residuo
		di_cassa decimal(19,2), var_di_cassa decimal(19,2)-- PAGAMENTI / INCASSI c/competenza e c/residuo
	)

	DECLARE @bilprevision TABLE 
	(	finpart char(1),
		assured char(1),
	
		idupb varchar(36),
		idfin int,
		flag tinyint,
		--idunderwriting int,	

		thisyearprevision decimal (19,2),	        -- prev. principale di finyear(non va in output)
		tot_varprev decimal(19,2),		--variazioni della prev. principale alla data

		thisyearsecondaryprevision decimal (19,2),	-- prev. secondaria di finyear(non va in output)
		tot_varsecondaryprev decimal(19,2),  --variazioni della prev. secondaria alla data

		availableprevision decimal(19,2),	-- prev. disponibile principale di quest'anno x Entrate e Spesa,
		availableprevision_secondary decimal(19,2),-- prev. disponibile secondaria di quest'anno x Entrate e Spesa,

		totvarcredit  decimal(19,2), --tot.var.crediti alla data
		totvarproceeds decimal(19,2), --tot.var. ass.cassa alla data
		totcreditpart decimal(19,2),   -- ass. Crediti
		totproceedspart decimal(19,2), -- ass. Cassa

		residui1 decimal(19,2), var_residui1 decimal(19,2), --IMPEGNI/ACCERTAMENTI c/residuo
		competenza1 decimal(19,2),competenza_alla_data decimal(19,2), --IMPEGNI/ACCERTAMENTI c/competenza
			
		competenza2 decimal(19,2), var_competenza2 decimal(19,2), -- PAGAMENTI / INCASSI c/competenza  		 		  
		residui2 decimal(19,2), var_residui2 decimal(19,2),--PAGAMENTI / INCASSIc/residuo 		 		  

		di_cassa decimal(19,2), var_di_cassa decimal(19,2), -- PAGAMENTI / INCASSI c/competenza e c/residuo 		 
					  
		-- Valori da inserire nella variazini di tipo Iniziale
		NUOVA_PREVISIONE decimal(19,2),
		NUOVA_PREVISIONE_CASSA decimal(19,2),
		RESIDUI_PRESUNTI decimal(19,2),
		PREVISIONE_ANNOPREC_COMP	 decimal(19,2),
		PREVISIONE_ANNOPREC_CASSA	 decimal(19,2)
	)
 
DECLARE @levelusable tinyint
SELECT  @levelusable = max(nlevel)
FROM 	finlevel
WHERE 	ayear = @ayear and flag&2 <> 0

INSERT INTO @bilprevision_all(
		idfin, idupb,
		thisyearprevision,	thisyearsecondaryprevision)
select	ISNULL(FLK.idparent, F_NEW.idfin),
		finyear.idupb,
		ISNULL(SUM(finyear.prevision),0),
		ISNULL(SUM(finyear.secondaryprev),0)
from finyear 
join fin f5 
	on finyear.idfin=f5.idfin
JOIN upb U
	ON finyear.idupb = U.idupb
JOIN finlevel fl
	ON f5.nlevel = fl.nlevel AND  f5.ayear = fl.ayear
JOIN #finlookup FK 
        ON FK.oldidfin = finyear.idfin 
JOIN fin F_NEW
         ON F_NEW.idfin = FK.newidfin
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = F_NEW.idfin AND FLK.nlevel = @levelusable
where f5.ayear = @ayear
		AND (finyear.idupb LIKE @idupb)	
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND (f5.nlevel = @levelusable
			OR (f5.nlevel < @levelusable
				AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = f5.idfin)
				AND (fl.flag&2)<>0
			   )
			)
group by  ISNULL(FLK.idparent,F_NEW.idfin), finyear.idupb

INSERT INTO @bilprevision_all(
		idfin, idupb,
		tot_varprev, tot_varsecondaryprev)
SELECT
	F_NEW.idfin, D.idupb,
	sum(case when V.flagprevision = 'S'  then D.amount else 0 end),  --tot_varprev
	sum(case when V.flagsecondaryprev = 'S'  then D.amount else 0 end) --tot_varsecondaryprev
from finvar V
JOIN finvardetail D 	
	ON V.yvar = D.yvar
	AND V.nvar = D.nvar	
join finlink FL on FL.idchild= D.idfin
JOIN #finlookup FK 
	ON FK.oldidfin = FL.idparent 
JOIN fin F_NEW
		ON F_NEW.idfin = FK.newidfin
JOIN UPB U
	ON D.idupb=U.idupb
	WHERE  V.yvar = @ayear
			AND V.adate <= @date
			AND V.idfinvarstatus = 5 
			AND V.variationkind <> 5
			AND F_NEW.nlevel>= @minlivop
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
			AND  D.idupb like @idupb
	GROUP BY F_NEW.flag, D.idupb, FL.idparent,F_NEW.idfin, F_NEW.paridfin, F_NEW.nlevel 



	INSERT INTO @bilprevision_all(
		idfin, idupb,
		totvarproceeds,totvarcredit 
	)
	select 
		 F_NEW.idfin, D.idupb, 
			sum(case when V.flagproceeds ='S' and F_NEW.flag&1<>0 then D.amount else 0 end), --totvarproceeds
			sum(case when V.flagcredit ='S' and F_NEW.flag&1<>0 then D.amount else 0 end) --totvarcredit
		from finvar V
		JOIN finvardetail D 	
			ON V.yvar = D.yvar
			AND V.nvar = D.nvar	
		join finlink FL on FL.idchild= D.idfin
		JOIN #finlookup FK 
			ON FK.oldidfin = FL.idparent 
		JOIN fin F_NEW
			 ON F_NEW.idfin = FK.newidfin
		JOIN UPB U
			ON D.idupb=U.idupb		
	WHERE  V.yvar = @ayear
			AND V.adate <= @date
			AND V.idfinvarstatus = 5 
			AND F_NEW.nlevel>= @minlivop
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
			AND  D.idupb like @idupb
			AND (F_NEW.flag & 48 =0) --non consideriamo le voci di avanzo
	GROUP BY F_NEW.flag, D.idupb, FL.idparent,F_NEW.idfin, F_NEW.paridfin, F_NEW.nlevel 


END


begin  --assegnazione  crediti

	INSERT INTO @bilprevision_all
	(
		idfin,	idupb,	
		totcreditpart 
	)
	SELECT
		ISNULL(finlink.idparent,FK.newidfin),
		creditpart.idupb,
		SUM(ISNULL(creditpart.amount,0))
	FROM creditpart
	JOIN #finlookup FK 
			ON FK.oldidfin = creditpart.idfin 
	LEFT OUTER JOIN finlink
		ON  finlink.idchild = FK.newidfin AND finlink.nlevel >= @minlivop
	join upb U on U.idupb= creditpart.idupb
	JOIN income I on creditpart.idinc= I.idinc
	WHERE creditpart.ycreditpart = @ayear
		AND (creditpart.adate >= @firstday AND creditpart.adate <= @date)
		AND  creditpart.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		--AND (I.expiration is null or I.expiration <= @lastday )
	GROUP BY creditpart.idupb,ISNULL(finlink.idparent,FK.newidfin)
END


begin -- #proceedstransmitted:  Assegnazione delle Assegnazioni Incassi trasmessi prima della data 

	INSERT INTO @bilprevision_all
	(
		idfin,	idupb,
		totproceedspart
	)
	SELECT
		ISNULL(finlink.idparent,FK.newidfin),
		proceedspart.idupb, 
		SUM(ISNULL(proceedspart.amount,0))
	FROM proceedspart
	JOIN income I on proceedspart.idinc= I.idinc
	JOIN proceedscommunicated
		ON proceedspart.idinc = proceedscommunicated.idinc
		AND proceedspart.yproceedspart = proceedscommunicated.ymov
	JOIN #finlookup FK 
			ON FK.oldidfin = proceedspart.idfin 
	INNER JOIN incomelink ELINK on ELINK.idchild=I.idinc and ELINK.nlevel=@assessmentphasecode
	INNER JOIN income IMP ON IMP.idinc = ELINK.idparent 
	LEFT OUTER JOIN finlink
		ON  finlink.idchild = FK.newidfin AND finlink.nlevel >= @minlivop
	join upb U on U.idupb= proceedspart.idupb

	WHERE proceedscommunicated.ymov = @ayear
		AND (proceedscommunicated.competencydate >= @firstday AND proceedscommunicated.competencydate <= @date)
		AND  proceedspart.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	GROUP BY proceedspart.idupb,ISNULL(finlink.idparent,FK.newidfin)

END


BEGIN -- #totimpegni: impegni residui, di competenza, di competenza_alla_data   
	INSERT INTO @bilprevision_all
	(
		idfin,	idupb, 
		residui1, competenza1,competenza_alla_data
	)
	SELECT
		ISNULL(finlink.idparent,FK.newidfin),	EY.idupb, 
		SUM(CASE WHEN  (ET.flag&1)=1 THEN EY.amount  ELSE 0 END), --residui
		SUM(CASE WHEN  (ET.flag&1)=0 THEN EY.amount  ELSE 0 END), --competenza
		SUM(CASE WHEN ( ( ((ET.flag&1)=0)  AND  @fin_kind IN (1,3)) OR (@fin_kind = 2))
						AND E.adate <= @date THEN EY.amount ELSE 0 END) --competenza_alla_data
	FROM expensetotal ET
	JOIN expenseyear EY
		ON EY.idexp = ET.idexp
		AND EY.ayear = ET.ayear
	JOIN expense E
		ON E.idexp = EY.idexp
	JOIN #finlookup FK 
			ON FK.oldidfin = EY.idfin 
	LEFT OUTER JOIN finlink
		ON  finlink.idchild = FK.newidfin AND finlink.nlevel >= @minlivop
	join UPB U on U.idupb  = EY.idupb
	WHERE EY.ayear = @ayear
		AND E.nphase = @appropriationphasecode
		AND  EY.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	GROUP BY EY.idupb,ISNULL(finlink.idparent,FK.newidfin)
	;

	insert into  @bilprevision_all  (idfin,	idupb, 	
	var_residui1, competenza1, competenza_alla_data)
	SELECT
		ISNULL(finlink.idparent,FK.newidfin),
		EY.idupb,
		SUM(CASE WHEN  (ET.flag&1)=1 THEN EV.amount ELSE 0 END),
		SUM(CASE WHEN  (ET.flag&1)=0 THEN EV.amount ELSE 0 END),
		SUM(CASE WHEN ( ( ((ET.flag&1)=0)  AND  @fin_kind IN (1,3)) OR (@fin_kind = 2))
						AND E.adate <= @date THEN  EV.amount ELSE 0 END)
	FROM expensetotal ET
	JOIN expenseyear EY
		ON EY.idexp = ET.idexp
		AND EY.ayear = ET.ayear
	JOIN expense E
		ON E.idexp = EY.idexp
	JOIN expensevar EV 
		on EV.idexp=EY.idexp and EV.yvar=EY.ayear
	JOIN #finlookup FK 
			ON FK.oldidfin = EY.idfin 
	LEFT OUTER JOIN finlink
		ON  finlink.idchild = FK.newidfin AND finlink.nlevel >= @minlivop
	join upb U on U.idupb=EY.idupb
	WHERE EY.ayear = @ayear
		AND E.nphase = @appropriationphasecode
		AND  EY.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	GROUP BY EY.idupb,ISNULL(finlink.idparent,FK.newidfin)
END


BEGIN -- #payments : competenza, residui, di_cassa

	INSERT INTO  @bilprevision_all
	(
		idfin,	idupb,
		competenza2,residui2,di_cassa
	)
	SELECT
		ISNULL(finlink.idparent,FK.newidfin),	EY.idupb,
		SUM (CASE WHEN (ET.flag&1)=0 then HPV.amount  ELSE  0 END), -- competenza
		SUM (CASE WHEN (ET.flag&1)<>0 then HPV.amount  ELSE  0 END), -- residui
		SUM (CASE WHEN (HPV.competencydate >= @firstday AND HPV.competencydate <= @date)  then EY.amount  ELSE  0 END) --di_cassa
	FROM expense E 
		INNER JOIN expenselink ELINK on ELINK.idchild=E.idexp and ELINK.nlevel=@appropriationphasecode
		INNER JOIN expense IMP ON IMP.idexp = ELINK.idparent 
		INNER JOIN expensetotal IMPTOT ON IMPTOT.idexp=IMP.idexp and IMPTOT.ayear=E.ymov       
		INNER JOIN expenselast EL				ON EL.idexp =E.idexp 
		INNER JOIN expenseyear EY				ON E.idexp = EY.idexp AND E.ymov = EY.ayear 
		INNER JOIN expensetotal ET				ON E.idexp = ET.idexp AND E.ymov = ET.ayear 
		INNER JOIN #finlookup FK				ON FK.oldidfin = EY.idfin 
		LEFT OUTER JOIN finlink					ON  finlink.idchild = FK.newidfin AND finlink.nlevel >= @minlivop
		LEFT OUTER JOIN historypaymentview HPV	ON E.idexp = HPV.idexp	AND E.ymov = HPV.ymov
		JOIN UPB U on U.idupb= EY.idupb
		WHERE E.ymov = @ayear
			AND  EY.idupb like @idupb
			AND HPV.competencydate <= @date
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		GROUP BY ISNULL(finlink.idparent,FK.newidfin),	EY.idupb 
	;

END

	if(@cashvaliditykind<>4)
	Begin
		INSERT INTO  @bilprevision_all
		(
			idfin,	idupb,
			var_competenza2,  var_residui2, var_di_cassa
		)
		SELECT
			ISNULL(finlink.idparent,FK.newidfin),	EY.idupb,
			SUM (CASE WHEN (ET.flag&1)=0 then  EV.amount  ELSE  0 END), -- competenza
			SUM (CASE WHEN (ET.flag&1)<>0 then  EV.amount  ELSE  0 END), -- residui
			SUM (CASE WHEN (HPV.competencydate >= @firstday AND HPV.competencydate <= @date) 
					then  EV.amount  ELSE  0 END) --di_cassa
		FROM expense E 
			INNER JOIN expenselink ELINK			on ELINK.idchild=E.idexp and ELINK.nlevel=@appropriationphasecode
			INNER JOIN expense IMP					ON IMP.idexp = ELINK.idparent 
			INNER JOIN expenselast EL				ON EL.idexp =E.idexp 
			INNER JOIN expenseyear EY				ON E.idexp = EY.idexp AND E.ymov = EY.ayear 
			INNER JOIN expensetotal ET				ON E.idexp = ET.idexp AND E.ymov = ET.ayear 
			INNER JOIN expensevar EV				ON EV.idexp= EY.idexp 
			JOIN #finlookup FK						ON FK.oldidfin = EY.idfin 
			LEFT OUTER JOIN finlink					ON  finlink.idchild = FK.newidfin AND finlink.nlevel >= @minlivop
			LEFT OUTER JOIN historypaymentview HPV	ON E.idexp = HPV.idexp	AND E.ymov = HPV.ymov
			JOIN UPB U on U.idupb=EY.idupb
			WHERE E.ymov = @ayear
					AND  EY.idupb like @idupb
					AND HPV.competencydate <= @date
					AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
					AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
					AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
					AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
					AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
			GROUP BY ISNULL(finlink.idparent,FK.newidfin),	EY.idupb
		;
	End



BEGIN  -- #totaccertamenti  Importo attuale degli accertamenti residui, competenza, competenza_alla_data   

	INSERT INTO @bilprevision_all (	idfin,	idupb,
									residui1, competenza1, competenza_alla_data)
	SELECT
		ISNULL(finlink.idparent,FK.newidfin),	EY.idupb,
		SUM(CASE WHEN  (ET.flag&1)=1 THEN EY.amount ELSE 0 END),  --residui
		SUM(CASE WHEN  (ET.flag&1)=0 THEN EY.amount ELSE 0 END),  --competenza
		SUM(CASE WHEN ( ( ((ET.flag&1)=0)  AND  @fin_kind IN (1,3)) OR (@fin_kind = 2))
						AND E.adate <= @date THEN EY.amount ELSE 0 END) --competenza_alla_data
	FROM incometotal ET
	JOIN incomeyear EY
		ON EY.idinc = ET.idinc
		AND EY.ayear = ET.ayear
	JOIN income E
		ON E.idinc = EY.idinc
	JOIN #finlookup FK 
			ON FK.oldidfin = EY.idfin 
	LEFT OUTER JOIN finlink
		ON  finlink.idchild = FK.newidfin AND finlink.nlevel >= @minlivop
	JOIN UPB U on U.idupb= EY.idupb
	WHERE EY.ayear = @ayear
		AND E.nphase = @assessmentphasecode
		AND  EY.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	GROUP BY EY.idupb,ISNULL(finlink.idparent,FK.newidfin)


	insert into  @bilprevision_all  (idfin,	idupb,	
	var_residui1, competenza1, competenza_alla_data)
	SELECT
		ISNULL(finlink.idparent,FK.newidfin), EY.idupb,
		SUM(CASE WHEN  (ET.flag&1)=1 THEN EV.amount ELSE 0 END),
		SUM(CASE WHEN  (ET.flag&1)=0 THEN EV.amount ELSE 0 END),
		SUM(CASE WHEN ( ( ((ET.flag&1)=0)  AND  @fin_kind IN (1,3)) OR (@fin_kind = 2))
						AND E.adate <= @date THEN  EV.amount ELSE 0 END)
	FROM incometotal ET
	JOIN incomeyear EY
		ON EY.idinc = ET.idinc
		AND EY.ayear = ET.ayear
	JOIN income E
		ON E.idinc = EY.idinc
	JOIN incomevar EV 
		on EV.idinc=EY.idinc and EV.yvar=EY.ayear
	JOIN #finlookup FK 
			ON FK.oldidfin = EY.idfin 
	LEFT OUTER JOIN finlink
		ON  finlink.idchild = FK.newidfin AND finlink.nlevel >= @minlivop
	join upb U on U.idupb=EY.idupb
	WHERE EY.ayear = @ayear
		AND E.nphase = @assessmentphasecode
		AND  EY.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	GROUP BY EY.idupb,ISNULL(finlink.idparent,FK.newidfin)
END

BEGIN --#proceeds : incassi, competenza,residui,di_cassa
	INSERT INTO  @bilprevision_all
	(
		idfin,	idupb,
		competenza2,  residui2, di_cassa
	)
	SELECT
		ISNULL(finlink.idparent,FK.newidfin),	EY.idupb,
		SUM (CASE WHEN (ET.flag&1)=0 then HPV.amount  ELSE  0 END), -- competenza
		SUM (CASE WHEN (ET.flag&1)<>0 then HPV.amount  ELSE  0 END), -- residui
		SUM (CASE WHEN (HPV.competencydate >= @firstday AND HPV.competencydate <= @date) 
				then ET.curramount  ELSE  0 END)		 --  di_cassa
	
	FROM income E
		INNER JOIN incomelink ELINK on ELINK.idchild=E.idinc and ELINK.nlevel=@assessmentphasecode
		INNER JOIN income IMP ON IMP.idinc = ELINK.idparent 
		INNER JOIN incometotal IMPTOT			ON IMPTOT.idinc=IMP.idinc and IMPTOT.ayear=E.ymov       
		INNER JOIN incomelast EL				ON EL.idinc =E.idinc 
		INNER JOIN incomeyear EY				ON E.idinc = EY.idinc AND E.ymov = EY.ayear 
		INNER JOIN incometotal ET				ON E.idinc = ET.idinc AND E.ymov = ET.ayear 
		INNER JOIN #finlookup FK						ON FK.oldidfin = EY.idfin 
		LEFT OUTER JOIN finlink					ON  finlink.idchild = FK.newidfin AND finlink.nlevel >= @minlivop
		LEFT OUTER JOIN historyproceedsview HPV	ON E.idinc = HPV.idinc	AND E.ymov = HPV.ymov
		JOIN UPB U on U.idupb=EY.idupb
		WHERE E.ymov = @ayear
			AND  EY.idupb like @idupb
			AND HPV.competencydate <= @date
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		GROUP BY ISNULL(finlink.idparent,FK.newidfin),	EY.idupb
END
;

if(@cashvaliditykind<>4)
	Begin
		INSERT INTO  @bilprevision_all
		(
			idfin,	idupb,
			var_competenza2,  var_residui2, var_di_cassa
		)
		SELECT
			ISNULL(finlink.idparent,FK.newidfin),	EY.idupb,
			SUM (CASE WHEN (ET.flag&1)=0 then  EV.amount  ELSE  0 END), -- competenza
			SUM (CASE WHEN (ET.flag&1)<>0 then  EV.amount  ELSE  0 END), -- residui
			SUM (CASE WHEN (HPV.competencydate >= @firstday AND HPV.competencydate <= @date) 
					then  EV.amount  ELSE  0 END) --di_cassa
		FROM income E 
			INNER JOIN incomelink ELINK			on ELINK.idchild=E.idinc and ELINK.nlevel=@assessmentphasecode
			INNER JOIN income IMP					ON IMP.idinc = ELINK.idparent 
			INNER JOIN incomelast EL				ON EL.idinc =E.idinc 
			INNER JOIN incomeyear EY				ON E.idinc = EY.idinc AND E.ymov = EY.ayear 
			INNER JOIN incometotal ET				ON E.idinc = ET.idinc AND E.ymov = ET.ayear 
			INNER JOIN incomevar EV				ON EV.idinc= EY.idinc 
			JOIN #finlookup FK						ON FK.oldidfin = EY.idfin 
			LEFT OUTER JOIN finlink					ON  finlink.idchild = FK.newidfin AND finlink.nlevel >= @minlivop
			LEFT OUTER JOIN historyproceedsview HPV	ON E.idinc = HPV.idinc	AND E.ymov = HPV.ymov
			JOIN UPB U on U.idupb=EY.idupb
			WHERE E.ymov = @ayear
					AND  EY.idupb like @idupb
					AND HPV.competencydate <= @date
					AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
					AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
					AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
					AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
					AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
			GROUP BY ISNULL(finlink.idparent,FK.newidfin),	EY.idupb
		;
	End;


insert into @bilprevision (idupb,	idfin,	
		thisyearprevision, thisyearsecondaryprevision,
		totvarcredit ,	totvarproceeds ,
		tot_varprev ,	tot_varsecondaryprev,
		totcreditpart ,	 totproceedspart, 
		residui1, var_residui1, competenza1, competenza_alla_data,
			competenza2,residui2,di_cassa,
			var_competenza2,  var_residui2, var_di_cassa
		)
		select idupb,	idfin,
		SUM(thisyearprevision), SUM(thisyearsecondaryprevision),
		SUM(totvarcredit) ,	SUM(totvarproceeds) ,
		SUM(tot_varprev) ,	SUM(tot_varsecondaryprev),
		SUM(totcreditpart),  SUM(totproceedspart), 
		SUM(residui1),SUM(var_residui1), SUM(competenza1),SUM(competenza_alla_data),
		SUM(competenza2),SUM(residui2),SUM(di_cassa),
		SUM(var_competenza2),SUM(var_residui2),SUM(var_di_cassa)
		from @bilprevision_all
			group by idupb,	idfin


update @bilprevision	SET finpart= 	CASE 	WHEN ((fin.flag&1)=1) THEN 'S' ELSE 'E' END,
			flag = fin.flag
	from @bilprevision 
		join fin on [@bilprevision].idfin= fin.idfin
			

UPDATE @bilprevision	 SET assured=  isnull(upb.assured,'N')	
	from @bilprevision
	 join upb on [@bilprevision].idupb= upb.idupb
	

-- #yearappropriation			>>  #totimpegni.competenza						"Impegni di competenza"
-- #yearappropriationstilldate	>> #totimpegni.competenza_alla_data      "Impegni di competenza alla data"
-- #yearpayment					>> #payments.competenza	" Pagamenti di competenza"
-- #expenditurepayment			>> #payments.residui	" Pagamenti su residui"
-- #payment_cash				>>  #payments.di_cassa			"Pagamenti di cassa (in base alla cfg. di bilancio)"
-- #totexpenditure				>>  #totimpegni.residui
-- #expenditureproceeds			>> #proceeds.residui		"Incassi su residui"
-- #yearproceeds				>> #proceeds.competenza			"Incassi su competenza"
-- #proceeds_cash				>> #proceeds.di_cassa			"Incassi di cassa (in base alla cfg. di bilancio)"
-- #totrevenue					>> #totaccertamenti.residui
-- #yearassessment				>> #totaccertamenti.competenza
-- #yearassessmentstilldate     >> #totaccertamenti.competenza_alla_data
--------------------------------------------		CALCOLO DEGLI IMPORTI DI OUTPUT		-------------------------------------------

-- Previsione disponibile pricipale, ossia di competenza (availableprevision) :
--	Previsione attuale principale
--	+ Variazioni di Previsione alla data
--	- Impegni di competenza effettuati nell'anno alla data / - Accertamenti di competenza effettuati nell'anno alla data
--
-- Previsione disponibile secondaria, ossia di cassa (availableprevision_secondary):
--	Previsione attuale secondaria
--	+ Variazioni di Previsione alla data
--	- Pagamenti di cassa effettuati nell'anno alla data / - Incassi di cassa effettuati nell'anno alla data

UPDATE @bilprevision
SET 
	availableprevision = 	ISNULL(thisyearprevision,0) 
							+isnull(tot_varprev,0)
							- ISNULL(competenza_alla_data,0),

	availableprevision_secondary = 	ISNULL(thisyearsecondaryprevision,0) 
									+isnull(tot_varsecondaryprev,0)
								- ISNULL(di_cassa,0)
where [@bilprevision].flag & 16 = 0  -- per l'av. di cassa e amm. non si calcola il disponibile
					

	update @bilprevision set NUOVA_PREVISIONE = case 
					-- Previsione disponibile di competenza
					when  assured='S' and finpart='E' then ISNULL(availableprevision,0)

					-- Previsione disponibile di competenza + Variazioni sui Residui Passivi all'1/1 
					when  assured='S' and finpart='S' then ISNULL(availableprevision,0) - isnull(var_residui1,0)

					when  assured='N' and finpart='E' then 0

					-- Crediti Residui = Totale Crediti Imputati -Valore corrente Impegni di competenza
					when  assured='N' and finpart='S' then ISNULL(totvarcredit,0) + ISNULL(totcreditpart,0)- ISNULL(competenza1,0)
				End
	where [@bilprevision].flag & 16 = 0 

	update @bilprevision set NUOVA_PREVISIONE_CASSA	    = case
				-- Disponibile sulla previsione di Cassa = Previsione attuale di Cassa - Incassi in c/competenza - Incassi in c/residui
					when  assured='S' and finpart='E' then 	ISNULL(thisyearsecondaryprevision,0) +isnull(tot_varsecondaryprev,0)
														- ( isnull(competenza2,0) + isnull(var_competenza2,0) + isnull(residui2,0) +  isnull(var_residui2,0) )
				-- Disponibile sulla previsione di Cassa = Previsione attuale di Cassa - Pagamenti in c/competenza - Pagamenti in c/residui
					when  assured='S' and finpart='S' then ISNULL(thisyearsecondaryprevision,0) +isnull(tot_varsecondaryprev,0)
														- ( isnull(competenza2,0) + isnull(var_competenza2,0) + isnull(residui2,0) +  isnull(var_residui2,0) )
				
				-- Disponibile sulla previsione di Cassa = Totale Residui Attivi =
				--	+ Valore corrente Impegni di competenza
				--	+ Residui Passivi all'1/1
				--	- Pagamenti in c/competenza
				--	- Pagamenti in c/residui
				--	- |Variazioni sui Residui Passivi all'1/1 |
					when  assured='N' and finpart='E' then 	ISNULL(competenza1,0)
													+ ISNULL(residui1,0)
													- ( isnull(competenza2,0) + isnull(var_competenza2,0) + isnull(residui2,0) +  isnull(var_residui2,0) )
													+ isnull(var_residui1,0)
				--	Crediti Residui + Totale Residui Passivi=
				--	Totale Crediti Imputati - Valore corrente Impegni di c/competenza
				--	+ Valore corrente Impegni di competenza
				--	+ Residui Passivi all'1/1
				--	- Pagamenti in c/competenza
				--	- Pagamenti in c/residui
				--	- |Variazioni sui Residui Passivi all'1/1 |
					when  assured='N' and finpart='S' then ISNULL(totvarcredit,0) + ISNULL(totcreditpart,0)- ISNULL(competenza1,0)
													+ ISNULL(competenza1,0)
													+ ISNULL(residui1,0)
													- ( isnull(competenza2,0) + isnull(var_competenza2,0) + isnull(residui2,0) +  isnull(var_residui2,0) )
													+ isnull(var_residui1,0)
				end
	where [@bilprevision].flag & 16 = 0 

-- Residui Presunti, nella var. di porev. di tipo cassa verranno valorizzati a null
-- Totale Residui Attivi e Passivi = Valore corrente Impegni di competenza
								--	+ Residui Passivi all'1/1
								--	- Pagamenti in c/competenza
								--	- Pagamenti in c/residui
								--	- |Variazioni sui Residui Passivi all'1/1 |
	update @bilprevision set RESIDUI_PRESUNTI =  ISNULL(competenza1,0)
												+ ISNULL(residui1,0)
												- ( isnull(competenza2,0) + isnull(var_competenza2,0) + isnull(residui2,0) +  isnull(var_residui2,0) )
													+ isnull(var_residui1,0)
	where [@bilprevision].flag & 16 = 0 


	-- Previsione anno precedente :
	-- Previsione Inziale di Competenza = Variazioni di Competenza + Previsione attuale di Competenza
	update @bilprevision set PREVISIONE_ANNOPREC_COMP = ISNULL(thisyearprevision,0) +isnull(tot_varprev,0)
	
	-- Previsione anno precedente : 
	-- Previsione Iniziale di Cassa = Variazioni della previsione di cassa + Previsione attuale di Cassa
	update @bilprevision set PREVISIONE_ANNOPREC_CASSA = ISNULL(thisyearsecondaryprevision,0) +isnull(tot_varsecondaryprev,0)
						

IF  (@generatevar='N')
BEGIN
	SELECT 
		[@bilprevision].finpart as 'E/S',	
		U.assured as 'Fin.certo',
		U.codeupb as 'Codice UPB',
		newfin.codefin as 'Voce di Bilancio',			
		newfin.title as 'Bilancio', 		
		isnull(thisyearprevision,0) as 'Prev.iniziale Competenza',
		isnull(tot_varprev,0) as 'Variazioni di Competenza',		-- alla data
		isnull(thisyearprevision,0) + isnull(tot_varprev,0) as 'Previsione attuale di Competenza',
		case when U.assured='N' then isnull(totvarcredit,0) else 0 end as 'Variazione Dotazione Crediti', --tot.var.crediti alla data
		case when U.assured='N' then isnull(totcreditpart,0) else 0 end as 'Assegnazione crediti',   -- ass. Crediti
		case when U.assured='N' then isnull(totvarcredit,0) + isnull(totcreditpart,0) else 0 end as 'Totale Crediti Imputati',
		isnull(competenza1,0) as 'Valore corrente Accertamenti/Impegni di competenza',
		isnull(residui1,0) as  'Residui Attivi/Passivi all''1/1',
		isnull(var_residui1,0) as 'Var.Residui Attivi/Passivi all''1/1', 
		case when  ([@bilprevision].flag & 16 = 0 ) then 
				isnull(thisyearprevision,0) + isnull(tot_varprev,0)- isnull(competenza1,0)
			else 0
		end  as 'Prev.Disponibile Comp.' ,		
		case
			when finpart='S' and U.assured='N'then 
					isnull(totvarcredit,0) + isnull(totcreditpart,0) -->Totale Crediti Imputati
						- isnull(competenza1,0) --> Valore corrente Accertamenti/Impegni di competenza
			else 0
		end as 'Crediti Residui' , 
		case when U.assured='N' then isnull(totvarproceeds,0) else 0 end as 'Var.Dotazione Cassa', -- alla data
		case when U.assured='N' then isnull(totproceedspart,0) else 0 end as 'Assegnazioni di Cassa', -- 
		case when U.assured='N' then isnull(totvarproceeds,0) + isnull(totproceedspart,0) else 0 end as 'Totale cassa imputata',
		isnull(competenza2,0) + isnull(var_competenza2,0) as 'Pagamenti/Incassi in c/competenza',
		isnull(residui2,0) +  isnull(var_residui2,0) as 'Pagamenti/Incassi in c/residui',
		case when finpart='S' and  U.assured='N' then 
				isnull(totvarproceeds,0) + isnull(totproceedspart,0)  
				- (  isnull(competenza2,0) + isnull(var_competenza2,0) + isnull(residui2,0) +  isnull(var_residui2,0) )  
			else 0
		End as 'Cassa Residua',
		isnull(thisyearsecondaryprevision,0) as 'Previsione Inizale di cassa',
		isnull(tot_varsecondaryprev,0) as 'Var.Pevisione Cassa',  -- alla data,
		isnull(thisyearsecondaryprevision,0) + isnull(tot_varsecondaryprev,0) as 'Previsione attuale di Cassa',
		case when  ([@bilprevision].flag & 16 = 0 ) and (@fin_kind= 3) then 
			isnull(thisyearsecondaryprevision,0)  +  isnull(tot_varsecondaryprev,0)
			- (  isnull(competenza2,0) + isnull(var_competenza2,0) + isnull(residui2,0) +  isnull(var_residui2,0) ) 
			else 0
		end	as 'Disponibile sulla previsione di Cassa',
		ISNULL(competenza1,0) -->Valore corrente Accertamenti/Impegni di competenza
		+ ISNULL(residui1,0) --> Residui Attivi/Passivi all'1/1
		- (ISNULL(competenza2,0) + ISNULL(var_competenza2,0)+ ISNULL(residui2,0) +  ISNULL(var_residui2,0)) --> Pagamenti/Incassi in c/competenza, Pagamenti/Incassi in c/residui
		+ ISNULL(var_residui1,0) --> Variazioni sui Residui attivi e Passivi all'1/1 
			as 'Totale Residui Attivi e Passivi' 
	FROM @bilprevision
	JOIN fin newfin
                ON newfin.idfin= [@bilprevision].idfin
	JOIN finlast FL on newfin.idfin= FL.idfin
	JOIN upb U
                ON U.idupb= [@bilprevision].idupb
	order  by [@bilprevision].finpart,newfin.codefin,U.codeupb--,UW.codeunderwriting

END
	
if (@generatevar='S') BEGIN
	
	 print 'genero variazioni'
	 declare @nmaxvar int
	 select @nmaxvar = max(nvar) from finvar where yvar=@nextayear
	 if @nmaxvar is null  set @nmaxvar=0

	 if (select count(*) from @bilprevision  where 
	  (isnull(NUOVA_PREVISIONE,0)<> 0  OR isnull(RESIDUI_PRESUNTI,0)<>0 OR isnull(PREVISIONE_ANNOPREC_COMP,0)<> 0)) 
	  <>0 BEGIN
		print 'ci sono variazioni'
		 set @nmaxvar= @nmaxvar+1
		 
		 declare @prevname varchar(100)
		 set @prevname = CASE when @fin_kind<>2 then 'Previsione iniziale di competenza'
				else 'Previsione iniziale di cassa' end

		 print 'variazione di prev.competenza'
		 --sempre:
		 insert into finvar(yvar,nvar,idfinvarstatus,flagprevision,flagsecondaryprev,flagcredit,flagproceeds,
			description,variationkind,
			adate, ct,cu,lt,lu,moneytransfer,official,idsor01,idsor02,idsor03,idsor04,idsor05,varflag)
		  values(@nextayear,@nmaxvar,4,'S','N','N','N',
			@prevname+' calcolata come disponibile dall''anno precedente',5,
			@oggi,GETDATE(),'compute_initialvar',GETDATE(),'compute_initialvar','N','N'
				,@idsor01,@idsor02,@idsor03,@idsor04,@idsor05,1)

		insert into finvardetail(yvar,nvar, rownum,	idfin,idupb,
			amount,
			ct,cu,lt,lu,
			residual,
			createexpense,
			previousprevision)
		select @nextayear, @nmaxvar, ROW_NUMBER()OVER (ORDER BY [@bilprevision].idfin,idupb),[@bilprevision].idfin,idupb,
			case when [@bilprevision].flag & 16 = 0 then NUOVA_PREVISIONE else null end, 
			GETDATE(),'compute_initialvar',GETDATE(),'compute_initialvar',
			case when [@bilprevision].flag & 16 = 0 then RESIDUI_PRESUNTI else null end, 
			'N',
			PREVISIONE_ANNOPREC_COMP
		from @bilprevision  
			JOIN finlast FL on [@bilprevision].idfin= FL.idfin
		where 	 (isnull(NUOVA_PREVISIONE,0)<>0  OR 
		          isnull(RESIDUI_PRESUNTI,0)<>0   OR 
		          isnull(PREVISIONE_ANNOPREC_COMP,0)<>0 )

	END

	-- Bilancio di Competenza e Cassa
	if  (@fin_kind= 3) AND (select count(*) from @bilprevision  
	where (isnull(NUOVA_PREVISIONE_CASSA,0)<>0 OR isnull(PREVISIONE_ANNOPREC_CASSA,0)<>0))<> 0 BEGIN
		set @nmaxvar= @nmaxvar+1

		print 'variazione di prev. secondaria'
		insert into finvar(yvar,nvar,idfinvarstatus,flagprevision,flagsecondaryprev,flagcredit,flagproceeds,
				description,variationkind,
				adate, ct,cu,lt,lu,moneytransfer,official,idsor01,idsor02,idsor03,idsor04,idsor05,varflag)
		values(@nextayear,@nmaxvar,4,'N','S','N','N',
					'Previsione iniziale di cassa calcolata come disponibile dall''anno precedente'	,	5	,					
					@oggi,GETDATE(),'compute_initialvar',GETDATE(),'compute_initialvar','N','N'
						,@idsor01,@idsor02,@idsor03,@idsor04,@idsor05,1)

		insert into finvardetail(yvar,nvar, rownum,idfin,idupb,
				amount,
				ct,cu,lt,lu,	
				residual,createexpense,previousprevision)
		select @nextayear, @nmaxvar, ROW_NUMBER()OVER (ORDER BY [@bilprevision].idfin,idupb),
				[@bilprevision].idfin,idupb,
				case when [@bilprevision].flag & 16 = 0 then NUOVA_PREVISIONE_CASSA else null end, 
				GETDATE(),'compute_initialvar',GETDATE(),'compute_initialvar',
				null, -- per la cassa non vanno valorizzati
				'N', 
				PREVISIONE_ANNOPREC_CASSA
			from @bilprevision 
			JOIN finlast FL on [@bilprevision].idfin= FL.idfin
			where 	 (isnull(NUOVA_PREVISIONE_CASSA,0)<>0 OR isnull(PREVISIONE_ANNOPREC_CASSA,0)<>0 ) 	

	 END
END --if (@generatevar='S')

END
