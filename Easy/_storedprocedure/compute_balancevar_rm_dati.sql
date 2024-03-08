
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



if exists (select * from dbo.sysobjects where id = object_id(N'[compute_balancevar_rm_dati]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_balancevar_rm_dati]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE   PROCEDURE [compute_balancevar_rm_dati]
	@ayear int,
	--@generatevar char(1) ='N',
	@idupb varchar(36)=null,
	@idsor01 int = null,
	@idsor02 int = null,
	@idsor03 int = null,
	@idsor04 int = null,
	@idsor05 int = null,
	@forced_assured char(1) ='-'
AS
BEGIN
declare @date smalldatetime
--  [compute_balancevar_rm_dati] 2023 , 'N'
set @date =  CONVERT(smalldatetime, '31-12-' + CONVERT(char(4), @ayear), 105)
set  @idupb = CASE WHEN @idupb is null THEN '%' else  REPLACE(@idupb+'%','%%','%') END

declare @oggi smalldatetime
set @oggi= convert(datetime, FLOOR(CONVERT(FLOAT,getdate())))

DECLARE @data varchar(13)
SELECT 	@data = CONVERT(varchar(20),@date,5)

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

-- SE finlookup è vuota perchè non è stato fatto il trasferimento nell'eserc. successivo, usiamo direttamente fin.
-- chiaramente è un caso eccezionale che risponde alla richiesta del task n. 18540
if not exists (select * from #finlookup)
Begin
	INSERT INTO #finlookup(oldidfin,newidfin)
	SELECT idfin, idfin
	FROM fin
       WHERE fin.ayear = @ayear

End



BEGIN  --#@bilprevision_all: previsione iniziale, attuale etc.
DECLARE @bilprevision_all TABLE 
(	idupb varchar(36),
	idfin int,
	idunderwriting int,	
	thisyearprevision decimal (19,2),	        -- prev. principale di finyear(non va in output)
	thisyearsecondaryprevision decimal (19,2),	-- prev. secondaria di finyear(non va in output)
	prevision decimal(19,2),		-- pura prev. comp. 
	prevision2 decimal(19,2), 	
	prevision3 decimal(19,2),	
	previousprevision decimal (19,2),
	previoussecondaryprev decimal (19,2),
	tot_varprev decimal(19,2),		--variazioni della prev. principale alla data
	tot_varsecondaryprev decimal(19,2),  --variazioni della prev. secondaria alla data,
	totvarcredit  decimal(19,2), --tot.var.crediti alla data
	totvarproceeds decimal(19,2), --tot.var. ass.cassa alla data
	totcreditpart decimal(19,2),   -- ass. Crediti
	totcreditpart_a_scadenza decimal(19,2),   -- ass. Crediti su accertamenti a scadenza 
	totproceedspart decimal(19,2), -- ass. Cassa
	proceedspart_su_scadenza decimal(19,2), --ass.incassi su accertamenti a scadenza
	residui1 decimal(19,2), competenza1 decimal(19,2),competenza_alla_data decimal(19,2), a_scadenza decimal(19,2), --IMPEGNI/ACCERTAMENTI
	var_residui1 decimal(19,2),
	trasmesso decimal(19,2), non_trasmesso decimal(19,2),
		 su_scadenza decimal(19,2), competenza2 decimal(19,2), residui2 decimal(19,2), di_cassa decimal(19,2), --PAGAMENTI / INCASSI
		 		 
	supposed_creditsurplus decimal(19,2),
	supposed_floatfund decimal(19,2),
	supposed_res_competency 	decimal(19,2),
	supposed_res_cash  	decimal(19,2),
	supposed_revenue    decimal(19,2),

	done_competency decimal(19,2),
	done_cassa decimal(19,2),
	done_revenue 	decimal(19,2),
	done_creditsurplus  	decimal(19,2),
	done_floatfund    decimal(19,2),


	supposed_residual decimal(19,2)
)

DECLARE @bilprevision TABLE 
(	finpart char(1),
	assured char(1),
	
	idupb varchar(36),
	idfin int,
	flag tinyint,
	idunderwriting int,	
	thisyearprevision decimal (19,2),	        -- prev. principale di finyear(non va in output)
	thisyearsecondaryprevision decimal (19,2),	-- prev. secondaria di finyear(non va in output)
	prevision decimal(19,2),		-- pura prev. comp. 
	availableprevision decimal(19,2),	-- prev. disponibile principale di quest'anno x Entrate e Spesa,
        availableprevision_secondary decimal(19,2),-- prev. disponibile secondaria di quest'anno x Entrate e Spesa,
        availableprevision_onlycash decimal(19,2),--  prev. disponibile per un bilancio di SOLA cassa di quest'anno x Entrate e Spesa,
	prevision2 decimal(19,2), 	
	prevision3 decimal(19,2),	
	prevision4 decimal(19,2),	
	prevision5 decimal(19,2),
	previousprevision decimal (19,2),
	previoussecondaryprev decimal (19,2),
	previousarrears decimal (19,2),
	totvarcredit  decimal(19,2), --tot.var.crediti alla data
	totvarproceeds decimal(19,2), --tot.var. ass.cassa alla data
	totcreditpart decimal(19,2),   -- ass. Crediti
	totcreditpart_a_scadenza decimal(19,2),   -- ass. Crediti su accertamenti a scadenza 
	totproceedspart decimal(19,2), -- ass. Cassa
	proceedspart_su_scadenza decimal(19,2), --ass.cassa su accertamenti a scadenza
	residui1 decimal(19,2), var_residui1 decimal(19,2), competenza1 decimal(19,2),
	competenza_alla_data decimal(19,2), a_scadenza decimal(19,2), --IMPEGNI/ACCERTAMENTI
	trasmesso decimal(19,2), non_trasmesso decimal(19,2),
		 su_scadenza decimal(19,2), competenza2 decimal(19,2), residui2 decimal(19,2), di_cassa decimal(19,2),

	floatfund decimal(19,2), -- Fondo Cassa alla data di redazione del bilancio di previsione
	finalproceeds decimal(19,2), -- Incassi Presunti al 31/12
	finalpayments decimal(19,2), -- Pagamenti Presunti al 31/12

	finalrevenue decimal(19,2), -- Residui Attivi Presunti al 31/12	SERVONO  X IL CALCOLO DELLA PREV DI CASSA, SE è Spesa SARà ZERO
	finalexpenditure decimal(19,2), -- Residui Passivi Presunti al 31/12	SERVONO X IL CALCOLO DELLA PREV DI CASSA, SE è Entrata SARà ZERO

	supposed_creditsurplus decimal(19,2),
	supposed_floatfund decimal(19,2),
	supposed_residual decimal(19,2),
	supposed_revenue    decimal(19,2),

	var_ass_cassa decimal(19,2),

	tot_varprev decimal(19,2),		--variazioni della prev. principale alla data
	tot_varsecondaryprev decimal(19,2),  --variazioni della prev. secondaria alla data
	available decimal(19,2),
	competency decimal(19,2),
	cash decimal(19,2),

	done_competency decimal(19,2),
	done_cassa decimal(19,2),
	done_revenue 	decimal(19,2),
	done_creditsurplus  	decimal(19,2),
	done_floatfund    decimal(19,2),



	--risultati
	supposed_res_competency 	decimal(19,2),
	supposed_res_cash  	decimal(19,2),

	finalfloatfund 	decimal(19,2),
	finalcreditsurplus  	decimal(19,2),
	res_competency decimal(19,2),
	res_cash decimal(19,2),
	reportcredit decimal(19,2)
)

print 'INSERT INTO #bilprevision'

INSERT INTO @bilprevision_all(
	idfin, idupb,	idunderwriting,
	thisyearprevision,       thisyearsecondaryprevision,
	prevision,	prevision2,	prevision3,
	
	previousprevision,	previoussecondaryprev,
	tot_varprev, tot_varsecondaryprev,
	totvarproceeds,totvarcredit 
)
select 
	 F_NEW.idfin, D.idupb, D.idunderwriting,
		sum(case when V.variationkind = 5 and V.flagprevision = 'S' then D.amount else 0 end) ,   --thisyearprevision
		sum(case when V.variationkind = 5 and V.flagsecondaryprev = 'S' AND @fin_kind = 3 then D.amount else 0 end), --thisyearsecondaryprevision
		sum(case when V.variationkind = 5 and V.flagprevision = 'S' then D.amount else 0 end),--prevision
		sum(case when V.variationkind = 5 and V.flagprevision = 'S' then D.prevision2 else 0 end),--prevision2
		sum(case when V.variationkind = 5 and V.flagprevision = 'S' then D.prevision3 else 0 end), --prevision3
		sum(case when V.variationkind = 5 and V.flagprevision = 'S' then D.amount else 0 end), --previousprevision
		sum(case when V.variationkind = 5 and V.flagsecondaryprev = 'S' AND @fin_kind = 3 then D.amount else 0 end), --previoussecondaryprev
		sum(case when V.variationkind <> 5 and  V.flagprevision = 'S'  then D.amount else 0 end),  --tot_varprev
		sum(case when V.variationkind <> 5 and  V.flagsecondaryprev = 'S'  then D.amount else 0 end), --tot_varsecondaryprev
		sum(case when V.flagproceeds ='S' and F_NEW.flag&1<>0 then D.amount else 0 end), --totvarproceeds
		sum(case when V.flagcredit ='S' and F_NEW.flag&1<>0 then D.amount else 0 end) --totvarcredit
	from finvar V
	JOIN finvardetail D 	ON V.yvar = D.yvar			AND V.nvar = D.nvar	
	join finlink FL			on FL.idchild= D.idfin
	JOIN #finlookup FK		ON FK.oldidfin = FL.idparent 
	JOIN fin F_NEW          ON F_NEW.idfin = FK.newidfin
	JOIN UPB U				ON D.idupb=U.idupb		
WHERE  V.yvar = @ayear
		--AND V.adate <= @date
		AND V.idfinvarstatus = 5 
		AND F_NEW.nlevel>= @minlivop
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND  D.idupb like @idupb
		AND (F_NEW.flag & 48 =0) --non consideriamo le voci di avanzo
GROUP BY F_NEW.flag, D.idupb, FL.idparent,F_NEW.idfin, F_NEW.paridfin, F_NEW.nlevel, D.idunderwriting

END


begin  --assegnazione  crediti

print '-- totcreditpart'
INSERT INTO @bilprevision_all
(
	idfin,	idupb,idunderwriting,	totcreditpart
)
SELECT
	ISNULL(finlink.idparent,FK.newidfin),
	creditpart.idupb, I.idunderwriting,
	SUM(ISNULL(creditpart.amount,0))
FROM creditpart
JOIN #finlookup FK 
        ON FK.oldidfin = creditpart.idfin 
LEFT OUTER JOIN finlink
	ON  finlink.idchild = FK.newidfin AND finlink.nlevel >= @minlivop
join upb U on U.idupb= creditpart.idupb
JOIN income I on creditpart.idinc= I.idinc
WHERE creditpart.ycreditpart = @ayear
	--AND (creditpart.adate >= @firstday AND creditpart.adate <= @date)
	AND  creditpart.idupb like @idupb
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
GROUP BY creditpart.idupb,ISNULL(finlink.idparent,FK.newidfin), I.idunderwriting


END


begin -- #proceedstransmitted:  Assegnazione delle Assegnazioni Incassi trasmessi prima della data 


print '--totproceedspart'
INSERT INTO @bilprevision_all
(
	idfin,	idupb,idunderwriting,	totproceedspart
)
SELECT
	ISNULL(finlink.idparent,FK.newidfin),
	proceedspart.idupb, I.idunderwriting,
	SUM(ISNULL(proceedspart.amount,0))

FROM proceedspart
JOIN income I on proceedspart.idinc= I.idinc
JOIN #finlookup FK 
        ON FK.oldidfin = proceedspart.idfin 
INNER JOIN incomelink ELINK on ELINK.idchild=I.idinc and ELINK.nlevel=@appropriationphasecode
INNER JOIN income IMP ON IMP.idinc = ELINK.idparent 
LEFT OUTER JOIN finlink
	ON  finlink.idchild = FK.newidfin AND finlink.nlevel >= @minlivop
join upb U on U.idupb= proceedspart.idupb

WHERE proceedspart.yproceedspart = @ayear	
	AND  proceedspart.idupb like @idupb
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
GROUP BY proceedspart.idupb,ISNULL(finlink.idparent,FK.newidfin), I.idunderwriting


END


BEGIN -- #totimpegni: impegni residui, di competenza, 
	


print 'insert into #totimpegni'
INSERT INTO @bilprevision_all
(
	idfin,	idupb, idunderwriting,	residui1, competenza1
)
SELECT
	ISNULL(finlink.idparent,FK.newidfin),	EY.idupb, UA.idunderwriting,
	SUM(CASE WHEN  (ET.flag&1)=1 THEN ISNULL(UA.amount,EY.amount)ELSE 0 END), --residui
	SUM(CASE WHEN  (ET.flag&1)=0 THEN ISNULL(UA.amount,EY.amount)ELSE 0 END) --competenza	
FROM expensetotal ET
JOIN expenseyear EY 	ON EY.idexp = ET.idexp
						AND EY.ayear = ET.ayear
JOIN expense E			ON E.idexp = EY.idexp
JOIN #finlookup FK      ON FK.oldidfin = EY.idfin 
left outer JOIN underwritingappropriation UA 			on UA.idexp=EY.idexp
LEFT OUTER JOIN finlink	ON  finlink.idchild = FK.newidfin AND finlink.nlevel >= @minlivop
join UPB U				on U.idupb  = EY.idupb
WHERE EY.ayear = @ayear
	AND E.nphase = @appropriationphasecode
	AND  EY.idupb like @idupb
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
GROUP BY EY.idupb,ISNULL(finlink.idparent,FK.newidfin),UA.idunderwriting
;

insert into  @bilprevision_all  (idfin,	idupb, idunderwriting,	residui1, competenza1, var_residui1)
SELECT
	ISNULL(finlink.idparent,FK.newidfin),	EY.idupb, EV.idunderwriting,
	SUM(CASE WHEN  (ET.flag&1)=1 THEN EV.amount ELSE 0 END),
	SUM(CASE WHEN  (ET.flag&1)=0 THEN EV.amount ELSE 0 END),
	SUM(CASE WHEN  (ET.flag&1)=1 THEN EV.amount ELSE 0 END)
FROM expensetotal ET	
JOIN expenseyear EY			ON EY.idexp = ET.idexp
							AND EY.ayear = ET.ayear
JOIN expense E				ON E.idexp = EY.idexp
JOIN expensevar EV			on EV.idexp=EY.idexp and EV.yvar=EY.ayear
JOIN #finlookup FK          ON FK.oldidfin = EY.idfin 
LEFT OUTER JOIN finlink		ON  finlink.idchild = FK.newidfin AND finlink.nlevel >= @minlivop
join upb U					on U.idupb=EY.idupb
WHERE EY.ayear = @ayear
	AND E.nphase = @appropriationphasecode
	AND  EY.idupb like @idupb
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
GROUP BY EY.idupb,ISNULL(finlink.idparent,FK.newidfin),EV.idunderwriting


END


BEGIN -- #payments : pagamenti trasmesso, non_trasmesso,su_impegno_a_scadenza, competenza, residui, di_cassa


/*
DECLARE @payments TABLE (idupb varchar(36),idfin int,  idunderwriting int,
		trasmesso decimal(19,2), --pagamenti trasmessi entro la data
		non_trasmesso decimal(19,2),  -- pagamenti non trasmessi entro la data (inclusi i non trasmessi o non inseriti in mandato)
		su_impegno_a_scadenza decimal(19,2),-- sono pagamenti fatti su impegni senza scadenza o con scadenza nell'anno
		competenza decimal(19,2), --pagamenti su impegni di competenza
		residui decimal(19,2),	--pagamenti su residui
		di_cassa decimal(19,2)  -- pagamenti alla data indicata dalla configurazione contabile per il giornale di cassa
		)
*/
INSERT INTO  @bilprevision_all
(
	idfin,	idupb,idunderwriting,	competenza2,residui2,di_cassa
)
SELECT
	ISNULL(finlink.idparent,FK.newidfin),	EY.idupb,	UP.idunderwriting,
	SUM (CASE WHEN (ET.flag&1)=0 then ISNULL(UP.amount,EY.amount)  ELSE  0 END), -- competenza
	SUM (CASE WHEN (ET.flag&1)<>0 then ISNULL(UP.amount,EY.amount)  ELSE  0 END), -- residui
	SUM ( ISNULL(UP.amount,EY.amount)) --di_cassa
	
FROM expense E 
	INNER JOIN expenselink ELINK on ELINK.idchild=E.idexp and ELINK.nlevel=@appropriationphasecode
	INNER JOIN expense IMP ON IMP.idexp = ELINK.idparent 
	INNER JOIN expensetotal IMPTOT ON IMPTOT.idexp=IMP.idexp and IMPTOT.ayear=E.ymov       
	INNER JOIN expenselast EL				ON EL.idexp =E.idexp 
	INNER JOIN expenseyear EY				ON E.idexp = EY.idexp AND E.ymov = EY.ayear 
	INNER JOIN expensetotal ET				ON E.idexp = ET.idexp AND E.ymov = ET.ayear 
	INNER JOIN #finlookup FK						ON FK.oldidfin = EY.idfin 
	LEFT OUTER JOIN underwritingpayment UP	ON UP.idexp=EL.idexp
	LEFT OUTER JOIN finlink					ON  finlink.idchild = FK.newidfin AND finlink.nlevel >= @minlivop
	JOIN UPB U on U.idupb= EY.idupb
	WHERE E.ymov = @ayear
		AND  EY.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	GROUP BY ISNULL(finlink.idparent,FK.newidfin),	EY.idupb,	UP.idunderwriting
;

INSERT INTO  @bilprevision_all
(
	idfin,	idupb,idunderwriting,competenza2,residui2,di_cassa
)
SELECT
	ISNULL(finlink.idparent,FK.newidfin),	EY.idupb,	EV.idunderwriting,
	SUM (CASE WHEN (ET.flag&1)=0 then  EV.amount  ELSE  0 END), -- competenza
	SUM (CASE WHEN (ET.flag&1)<>0 then  EV.amount  ELSE  0 END), -- residui
	SUM ( EV.amount ) --di_cassa

FROM expense E 
	INNER JOIN expenselink ELINK on ELINK.idchild=E.idexp and ELINK.nlevel=@appropriationphasecode
	INNER JOIN expense IMP ON IMP.idexp = ELINK.idparent 
	INNER JOIN expenselast EL				ON EL.idexp =E.idexp 
	INNER JOIN expenseyear EY				ON E.idexp = EY.idexp AND E.ymov = EY.ayear 
	INNER JOIN expensetotal ET				ON E.idexp = ET.idexp AND E.ymov = ET.ayear 
	INNER JOIN expensevar EV				ON EV.idexp= EY.idexp 
	JOIN #finlookup FK						ON FK.oldidfin = EY.idfin 
	LEFT OUTER JOIN underwritingpayment UP	ON UP.idexp=EL.idexp
	LEFT OUTER JOIN finlink					ON  finlink.idchild = FK.newidfin AND finlink.nlevel >= @minlivop
	JOIN UPB U on U.idupb=EY.idupb
	WHERE E.ymov = @ayear
			AND  EY.idupb like @idupb
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	GROUP BY ISNULL(finlink.idparent,FK.newidfin),	EY.idupb,	EV.idunderwriting
;

END


BEGIN  -- #totaccertamenti  Importo attuale degli accertamenti residui, competenza


--DECLARE @totaccertamenti TABLE (idupb varchar(36),idfin int, idunderwriting int,
--	residui decimal(19,2),   
--	competenza decimal(19,1), 
--	competenza_alla_data decimal(19,2),  -- tutti gli accertamenti se cfg di sola cassa, solo competenza altrimenti
--	a_scadenza decimal(19,2)
--	)
INSERT INTO @bilprevision_all (	idfin,	idupb, idunderwriting,	residui1, competenza1 )
SELECT
	ISNULL(finlink.idparent,FK.newidfin),	EY.idupb, E.idunderwriting,
	SUM(CASE WHEN  (ET.flag&1)=1 THEN EY.amount ELSE 0 END),  --residui
	SUM(CASE WHEN  (ET.flag&1)=0 THEN EY.amount ELSE 0 END)  --competenza
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
GROUP BY EY.idupb,ISNULL(finlink.idparent,FK.newidfin),E.idunderwriting



insert into  @bilprevision_all  (idfin,	idupb, idunderwriting,	residui1, competenza1)
SELECT
	ISNULL(finlink.idparent,FK.newidfin), EY.idupb, E.idunderwriting,
	SUM(CASE WHEN  (ET.flag&1)=1 THEN EV.amount ELSE 0 END),
	SUM(CASE WHEN  (ET.flag&1)=0 THEN EV.amount ELSE 0 END)
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
	AND E.nphase = @appropriationphasecode
	AND  EY.idupb like @idupb
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
GROUP BY EY.idupb,ISNULL(finlink.idparent,FK.newidfin),E.idunderwriting




END


BEGIN --#proceeds : incassi trasmesso, non_trasmesso, su_accertamento_a_scadenza,competenza,residui,di_cassa

--DECLARE @proceeds TABLE (idupb varchar(36),idfin int,  idunderwriting int,
--		trasmesso decimal(19,2), --incassi trasmessi entro la data
--		non_trasmesso decimal(19,2),  -- , non trasmessi entro la data (inclusi i non trasmessi o non inseriti in reversale)
--		su_accertamento_a_scadenza decimal(19,2),-- sono , fatti su accertamenti senza scadenza o con scadenza nell'anno
--		competenza decimal(19,2), --, su accertamenti di competenza
--		residui decimal(19,2),	--, su accertamenti residui
--		di_cassa decimal(19,2)  -- , alla data indicata dalla configurazione contabile per il giornale di cassa
--		)
INSERT INTO  @bilprevision_all
(
	idfin,	idupb,idunderwriting,	competenza2,  residui2, di_cassa
)
SELECT
	ISNULL(finlink.idparent,FK.newidfin),	EY.idupb,	E.idunderwriting,
	SUM (CASE WHEN (ET.flag&1)=0 then ET.curramount  ELSE  0 END), -- competenza
	SUM (CASE WHEN (ET.flag&1)<>0 then ET.curramount  ELSE  0 END), -- residui
	SUM (ET.curramount)		 --  di_cassa
	
FROM income E
	INNER JOIN incomelink ELINK on ELINK.idchild=E.idinc and ELINK.nlevel=@appropriationphasecode
	INNER JOIN income IMP ON IMP.idinc = ELINK.idparent 
	INNER JOIN incometotal IMPTOT			ON IMPTOT.idinc=IMP.idinc and IMPTOT.ayear=E.ymov       
	INNER JOIN incomelast EL				ON EL.idinc =E.idinc 
	INNER JOIN incomeyear EY				ON E.idinc = EY.idinc AND E.ymov = EY.ayear 
	INNER JOIN incometotal ET				ON E.idinc = ET.idinc AND E.ymov = ET.ayear 
	INNER JOIN #finlookup FK						ON FK.oldidfin = EY.idfin 
	LEFT OUTER JOIN finlink					ON  finlink.idchild = FK.newidfin AND finlink.nlevel >= @minlivop
	JOIN UPB U on U.idupb=EY.idupb
	WHERE E.ymov = @ayear
		AND  EY.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	GROUP BY ISNULL(finlink.idparent,FK.newidfin),	EY.idupb,	E.idunderwriting

END

;insert into  @bilprevision_all (idupb,	idfin,idunderwriting ,	
	supposed_res_competency ,supposed_res_cash,supposed_residual
)select fvd.idupb,fvd.idfin,fvd.idunderwriting,
		sum (case when flagprevision='S'  then fvd.amount else 0 end),
		sum (case when flagsecondaryprev='S' then fvd.amount else 0 end),
		sum (case when flagprevision='S' then fvd.residual else 0 end)
	from finvar fv
	join finvardetail fvd on fv.yvar=fvd.yvar and fv.nvar =fvd.nvar
	where fv.yvar=@ayear+1 and 
			fv.idfinvarstatus=5 and 
			fv.varflag &1 <> 0
		AND  fvd.idupb like @idupb
		AND (@idsor01 IS NULL OR fv.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR fv.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR fv.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR fv.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR fv.idsor05 = @idsor05)
	group by fvd.idupb,fvd.idfin,fvd.idunderwriting

;
insert into  @bilprevision_all (idupb,	idfin,idunderwriting ,	
	supposed_creditsurplus,supposed_floatfund
)select fvd.idupb,fvd.idfin,fvd.idunderwriting,
		sum (case when flagcredit='S' then fvd.amount else 0 end),
		sum (case when flagproceeds='S'  then fvd.amount else 0 end)
	from finvar fv
	join finvardetail fvd on fv.yvar=fvd.yvar and fv.nvar =fvd.nvar
	where fv.yvar=@ayear+1 and 
			fv.idfinvarstatus=5 and 
			fv.variationkind=2
		AND  fvd.idupb like @idupb
		AND (@idsor01 IS NULL OR fv.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR fv.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR fv.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR fv.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR fv.idsor05 = @idsor05)
	group by fvd.idupb,fvd.idfin,fvd.idunderwriting

insert into  @bilprevision_all (idupb,	idfin,idunderwriting ,	
	done_competency , done_cassa,done_revenue,done_creditsurplus,done_floatfund
)select fvd.idupb,fvd.idfin,fvd.idunderwriting, 	
		sum (case when flagprevision='S'  then fvd.amount else 0 end),
		sum (case when flagsecondaryprev='S' and fv.cu<>'compute_balancevar_residui' then fvd.amount else 0 end),
		sum (case when flagsecondaryprev='S' and fv.cu='compute_balancevar_residui' then fvd.amount else 0 end),
		sum (case when flagcredit='S' then fvd.amount else 0 end),
		sum (case when flagproceeds='S'  then fvd.amount else 0 end)

	from finvar fv
	join finvardetail fvd on fv.yvar=fvd.yvar and fv.nvar =fvd.nvar
	where fv.yvar=@ayear+1 and 
			fv.idfinvarstatus=5 and 
			fv.variationkind=3
		AND  fvd.idupb like @idupb
		AND (@idsor01 IS NULL OR fv.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR fv.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR fv.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR fv.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR fv.idsor05 = @idsor05)
	group by fvd.idupb,fvd.idfin,fvd.idunderwriting




insert into @bilprevision (idupb,	idfin,idunderwriting ,	
    thisyearprevision, thisyearsecondaryprevision,
  	prevision ,	prevision2 ,	prevision3 ,
	previousprevision ,	previoussecondaryprev ,
	totvarcredit ,	totvarproceeds ,
	tot_varprev ,	tot_varsecondaryprev,
	totcreditpart ,	 totproceedspart,
	residui1, competenza1, var_residui1,
		competenza2,residui2,di_cassa,
		supposed_res_competency ,supposed_res_cash,supposed_creditsurplus,supposed_floatfund,supposed_residual,
		done_competency , done_cassa,done_revenue,done_creditsurplus,done_floatfund
	)
	select idupb,	idfin,idunderwriting ,	
	SUM(thisyearprevision), SUM(thisyearsecondaryprevision),
  	SUM(prevision) ,	SUM(prevision2) ,	SUM(prevision3) ,
	SUM(previousprevision) ,	SUM(previoussecondaryprev),
	SUM(totvarcredit) ,	SUM(totvarproceeds) ,
	SUM(tot_varprev) ,	SUM(tot_varsecondaryprev),
	SUM(totcreditpart), SUM(totproceedspart), 
	SUM(residui1),SUM(competenza1),sum(var_residui1),
		SUM(competenza2),SUM(residui2),SUM(di_cassa),
		sum(supposed_res_competency) ,sum(supposed_res_cash),sum(supposed_creditsurplus),sum(supposed_floatfund),
		sum(supposed_residual),
	sum(done_competency) , sum(done_cassa),sum(done_revenue),sum(done_creditsurplus),sum(done_floatfund)
	from @bilprevision_all
		group by idupb,	idfin,idunderwriting 




update @bilprevision	SET finpart= 	CASE 	WHEN ((fin.flag&1)=1) THEN 'S' ELSE 'E' END,
			flag = fin.flag
	from @bilprevision 
		join fin on [@bilprevision].idfin= fin.idfin
			

UPDATE @bilprevision	 SET assured=  case when @forced_assured='-' then upb.assured else @forced_assured end
	from @bilprevision
	 join upb on [@bilprevision].idupb= upb.idupb
	

--------------------------------------------		CALCOLO DEGLI IMPORTI DI OUTPUT		-------------------------------------------
/*	FONDO CASSA definitivo = 
	  Tot. variazioni Dotazione Cassa
	+ Assegnazione degli incassi 
	- Mandati 	*/
UPDATE @bilprevision
SET 
	floatfund	= 
			ISNULL(totvarproceeds,0) 
			+ ISNULL(totproceedspart,0)
			- ISNULL(di_cassa,0)
	WHERE (finpart = 'S')and (assured <>'S') -- x i fondi vale zero


/*   INCASSI DEFINITIVI per le spese
	= tot. assegnaz.cassa + var.dot.cassa.

	*/
IF(@fin_kind <> 2) 
BEGIN
	UPDATE @bilprevision
	SET 
		finalproceeds =  			ISNULL(totvarproceeds,0) 
								+ ISNULL(totproceedspart,0)
	WHERE (finpart = 'S')and (assured <>'S') -- x i fondi vale zero

END


-- INCASSI PRESUNTI X LE ENTRATE (NUOVO), duale ai pagamenti presunti
/*
	 Totale Reversali Tx dopo la data
	+ Incassi o Righe di Reversale sensa Reversale di incasso
	+ Reversali di Incasso non Tx
	+ Accertamenti con scadenza entro l'anno oppure quelli che non hanno una data di scadenza

																	*/
IF(@fin_kind <> 2) 
BEGIN
	UPDATE @bilprevision
	SET 
		finalproceeds = isnull(di_cassa,0) 
	WHERE (finpart ='E') and (assured <>'S')   -- x i fondi vale zero
END

-- PAGAMENTI DEFINITIVI (RIMANE COM'ERA PRIMA) vale 0 per le Entrate, x le spese rimane così
/*
	 Totale Mandati
																	
*/

IF(@fin_kind <> 2) 
BEGIN
	UPDATE @bilprevision
	SET 
		finalpayments = isnull(di_cassa,0) 		
		WHERE (finpart='S') 	-- x le entrate è chiaramente a zero
END

--- Residui Attivi DEFINITIVI al 31/12
/*
	Importo attuale dei residui attivi al 01/01
	+ accertamenti effettuati nell'anno
	- incassi 
*/

IF(@fin_kind <> 2) 
BEGIN
	UPDATE @bilprevision
	SET 
		--supposedrevenue = 0,
		finalrevenue = isnull(residui1,0)+isnull(competenza1,0)
						  -  isnull(di_cassa,0),
		supposed_revenue= isnull(supposed_residual,0)
		where (finpart = 'E') and (assured='N')
	
	--residui attivi presunti in uscita = avanzo di amministrazione presunto + residui passivi presunti - fondo cassa presunto	
	update @bilprevision set supposed_revenue= isnull(supposed_creditsurplus,0)+isnull(supposed_residual,0)
									-isnull(supposed_floatfund,0)
		where (finpart = 'S') and (assured='N')

	update @bilprevision set finalrevenue= isnull(totcreditpart,0)+isnull(totvarcredit,0)+isnull(residui1,0)
								-isnull(totproceedspart,0)-isnull(totvarproceeds,0)
		where (finpart = 'S') and (assured='N')
END

-- Residui Passivi DEFINITIVI al 31/12
/*
	Importo attuale dei residui passivi
	+ impegni effettuati nell'anno
	- PAGAMENTI 
*/
IF(@fin_kind <> 2) 
BEGIN
	UPDATE @bilprevision
	SET 
		finalexpenditure =  isnull(residui1,0)+isnull(competenza1,0)-isnull(di_cassa,0)
				
		where (finpart='S') and (assured='N')
END
-- Dotazione crediti da riportare
/* 
	tot.var.dot.crediti + tot.ass.crediti - pagamenti
*/
IF (@fin_kind = 2)
BEGIN
	UPDATE @bilprevision
	SET reportcredit = ISNULL(totvarcredit,0) + ISNULL(totcreditpart,0) - ISNULL(di_cassa,0)
	WHERE finpart = 'S' and assured = 'N'
END
-- Previsione disponibile pricipale, ossia di competenza (availableprevision) :
--	Previsione attuale principale
--	+ Variazioni di Previsione alla data
--	- Impegni di competenza effettuati nell'anno alla data / - Accertamenti di competenza effettuati nell'anno alla data
--
-- Previsione disponibile secondaria, ossia di cassa (availableprevision_secondary):
--	Previsione attuale secondaria
--	+ Variazioni di Previsione alla data
--	- Pagamenti di cassa effettuati nell'anno alla data / - Incassi di cassa effettuati nell'anno alla data
--
-- Previsione disponibile pricipale di cassa, è la prev. disponibile per un bilancio di SOLA cassa (availableprevision_onlycash) :
--	Previsione attuale principale
--	+ Variazioni di Previsione alla data
--	- Pagamenti di cassa effettuati nell'anno alla data / - Incassi di cassa effettuati nell'anno alla data

UPDATE @bilprevision
SET 
	availableprevision = 	ISNULL(thisyearprevision,0) 
							+isnull(tot_varprev,0)
							- ISNULL(competenza1,0),

	availableprevision_secondary = 	ISNULL(thisyearsecondaryprevision,0) 
									+isnull(tot_varsecondaryprev,0)
								- ISNULL(di_cassa,0),

     availableprevision_onlycash =		ISNULL(thisyearprevision,0) 
										+ isnull(tot_varprev,0)
										- ISNULL(di_cassa,0)
where [@bilprevision].flag & 16 = 0  -- per l'av. di cassa e amm. non si calcola il disponibile
					
		
-- Procedura che imposta il valore dei capitoli articolati pari alla somma degli articoli
-- in particolare sta prendendo i capitoli degli articoli, se non esistono nella tabella.
-- Per esempio se ho fatto solo un mov. di spesa sull'articolo, lo troverò SOLO in expenseyear
-- quindi in #bilprevision troverò SOLO l'articolo. Questo ciclo serve ad inserisce anche il relativo capitolo
-- per poterlo totalizzare.


IF ((@fin_kind = 1) OR (@fin_kind = 3)) begin
	update @bilprevision set 
	-- Pura Prev. Comp. = finyear.prevision2 + prev.disponibile principale, ossia di competenza.
		competency= CASE WHEN ([@bilprevision].assured ='S') 
						THEN ISNULL(availableprevision,0) +ISNULL(prevision2,0) - isnull(var_residui1,0)
						ELSE ISNULL(prevision2,0)
			END,

	 -- Pura Prev. Cassa = finyear.prevision2 + prev.disponibile secondaria, ossia di cassa. 
		cash= CASE WHEN ([@bilprevision].assured ='S') 
							THEN ISNULL(availableprevision_secondary,0)  +ISNULL(prevision2,0) 
							ELSE 0 --ISNULL(prevision2,0)
				END,
		available = isnull(availableprevision,0)
end


--setuser 'amministrazione'
--finalfloatfund  = fondo cassa definitivo
update @bilprevision set finalfloatfund= case when finpart='S' and assured='N' and (flag & 16 =0)
	 then  isnull(floatfund,0)  else 0 end

--finalcreditsurplus = avanzo amministrazione definitivo
update @bilprevision set finalcreditsurplus = case when finpart='S' and assured='N' and (flag & 16 =0)
	then isnull(finalfloatfund,0) + isnull(finalrevenue,0)  - isnull(finalexpenditure,0)  else 0 end

update @bilprevision set res_competency = case when  assured='N' and finpart='S' and (flag & 16 =0) then finalcreditsurplus  else competency end
update @bilprevision set res_cash	    = case when  assured='N' and finpart='S' and (flag & 16 =0) then finalfloatfund   else cash end


update @bilprevision set supposed_res_cash = 0 where finpart='E' and assured='N' 

	 declare @flagcredit char(1)
	 set @flagcredit='N'
	 declare @flagproceeds char(1)
	 set @flagproceeds='N'

	 select @flagcredit=isnull(flagcredit,'N'),
			@flagproceeds=isnull(flagproceeds,'N') from config where ayear=@nextayear

update @bilprevision set var_ass_cassa= isnull(res_cash,0)-isnull(supposed_res_cash,0) +supposed_revenue
						where assured='N' and finpart='S'
						
update @bilprevision set var_ass_cassa= isnull(res_cash,0)-isnull(supposed_res_cash,0) 
						where assured='S' or finpart='E'

--IF  (@generatevar='N')
--BEGIN
	SELECT 
		[@bilprevision].finpart as 'E/S',		
		--newfin.idfin as idfin as,	
		newfin.codefin as 'codice bil.',			
		newfin.title as 'bilancio', 		
		--#bilprevision.idupb,	
		U.codeupb as 'codice upb',
		U.title as 'upb',
		U.assured as 'fin.certo',
		--#bilprevision.idunderwriting,
		UW.codeunderwriting as 'codice finanziamento',
		UW.title as 'finanziamento',
		thisyearprevision as 'prev.iniziale princ.',
		thisyearsecondaryprevision as 'prev.iniziale sec.',
		prevision2 as 'previsione pluriennale per anno succ.', 	
		prevision3 as 'prev. pluriennale anno +2', 	
		prevision4 as 'prev. pluriennale anno +3',	

		--previousprevision as 'prev.precedente',
		--previoussecondaryprev as 'prev.sec.precedente',
		tot_varprev as 'var.previsione',		--variazioni della prev. principale alla data
		tot_varsecondaryprev as 'var.prev.sec.',  --variazioni della prev. secondaria alla data,
		totvarcredit  as 'tot.var.dot.crediti', --tot.var.crediti alla data
		totvarproceeds as 'tot.var.dot.cassa', --tot.var. ass.cassa alla data
		totcreditpart as 'tot.ass.crediti',   -- ass. Crediti
		totproceedspart as 'tot.ass.cassa', -- ass. Cassa
		residui1 as 'residui fase 1',
		competenza1 as 'competenza fase 1',
		var_residui1 as 'Variazioni su residui passivi',
		ISNULL(di_cassa,0) as		'pagamenti/incassi',

		ISNULL(finalproceeds,0) as 'incassi',		-- INCASSI PRESUNTI alla data(RIMANE) servono x le Entrate
		ISNULL(finalpayments,0) as 'pagamenti',		-- PAGAMENTI PRESUNTI alla data (RIMANE)
		ISNULL(finalrevenue,0) as 'residui attivi',		-- Residui Attivi Presunti al 31/12
		ISNULL(finalexpenditure,0) as 'residui passivi',	-- Residui Passivi Presunti al 31/12	
		--isnull(competency,0) as 'pura prev. competenza  presunta',
		--isnull(cash,0) as 'pura prev. cassa presunta',
		available as 'prev. disponibile' ,		
		availableprevision_secondary as 'prev. disponibile secondaria',
		availableprevision_onlycash as 'prev.disponibile per sola cassa',

		supposed_floatfund as 'fondo cassa presunto',
		finalfloatfund as 'fondo cassa effettivo',

		supposed_creditsurplus as 'avanzo amm.presunto',
		finalcreditsurplus as 'avanzo amm.effettivo',

		supposed_res_competency as 'prev. competenza',               
		supposed_res_cash  as 'prev. cassa',

		res_competency as 'prev. competenza assestata',               
		res_cash  as 'prev. cassa assestata',
		reportcredit as 'Dotazione Crediti da riportare'
		
	FROM @bilprevision
	JOIN fin newfin
                ON newfin.idfin= [@bilprevision].idfin
	JOIN finlast FL on newfin.idfin= FL.idfin
	JOIN upb U
                ON U.idupb= [@bilprevision].idupb
	LEFT OUTER JOIN underwriting UW
                ON isnull(UW.idunderwriting,0)= isnull([@bilprevision].idunderwriting,0)
	order  by [@bilprevision].finpart,newfin.codefin,U.codeupb,UW.codeunderwriting

--END
	
--if (@generatevar='S') BEGIN
	
--	 print 'genero variazioni'
--	 declare @nmaxvar int
--	 select @nmaxvar = max(nvar) from finvar where yvar=@nextayear
--	 if @nmaxvar is null  set @nmaxvar=0

	 

--	 if ((@fin_kind<> 2) and (select count(*) from @bilprevision  where isnull(res_competency,0)-isnull(supposed_res_competency,0)-isnull(done_competency,0)<>0)<> 0) BEGIN

--		print 'ci sono variazioni'

--		 set @nmaxvar= @nmaxvar+1
		 
--		 declare @prevname varchar(100)
--		 set @prevname = /*CASE when @fin_kind<>2 then */'Assestamento Avanzo Amministrazione (Previsione)'
--				-- else 'Assestamento Fondo Cassa (Previsione)' end

--		 print 'variazione di prev.competenza'
--		 --sempre:
--		 insert into finvar(yvar,nvar,idfinvarstatus,flagprevision,flagsecondaryprev,flagcredit,flagproceeds,
--			description,variationkind,
--			adate, ct,cu,lt,lu,moneytransfer,official,idsor01,idsor02,idsor03,idsor04,idsor05,varflag)
--		  values(@nextayear,@nmaxvar,4,'S','N','N','N',
--			'Assestamento Avanzo di Amministrazione',3,
--			@oggi,GETDATE(),'compute_balancevar_rm_dati',GETDATE(),'compute_balancevar_rm_dati','N','N'
--				,@idsor01,@idsor02,@idsor03,@idsor04,@idsor05,0)

--		insert into finvardetail(yvar,nvar, rownum,[@bilprevision].idfin,idupb,idunderwriting,amount,
--			[@bilprevision].ct,[@bilprevision].cu,[@bilprevision].lt,[@bilprevision].lu,  --residual,
--							createexpense )
--			select @nextayear, @nmaxvar, ROW_NUMBER()OVER (ORDER BY [@bilprevision].idfin,idupb,idunderwriting),
--					[@bilprevision].idfin,idupb,idunderwriting,
--						isnull(res_competency,0)-isnull(supposed_res_competency,0)-isnull(done_competency,0),
--						GETDATE(),'compute_balancevar_rm_dati',GETDATE(),'compute_balancevar_rm_dati',
--						--case when [@bilprevision].finpart='S' then finalexpenditure else finalrevenue end,
--						'N'
--				from @bilprevision  
--				JOIN finlast FL on [@bilprevision].idfin= FL.idfin
--				where 	isnull(res_competency,0)-isnull(supposed_res_competency,0)-isnull(done_competency,0)<>0			
--	END
 
--    IF ((@fin_kind= 2) AND  (select count(*) from @bilprevision  where isnull(availableprevision_onlycash,0)<> 0 /*AND ISNULL(assured,'N') = 'S'*/) <> 0 )			 
--		BEGIN
--			set @nmaxvar= @nmaxvar+1

--			print 'variazione di prev. CASSA'
--			insert into finvar(yvar,nvar,idfinvarstatus,flagprevision,flagsecondaryprev,flagcredit,flagproceeds,
--					description,variationkind,
--					adate, ct,cu,lt,lu,moneytransfer,official,idsor01,idsor02,idsor03,idsor04,idsor05,varflag)
--			values(@nextayear,@nmaxvar,4,'S','N','N','N',
--						'Assestamento Fondo Cassa (Previsione)'	,	3	,					
--						@oggi,GETDATE(),'compute_balancevar_rm_dati',GETDATE(),'compute_balancevar_rm_dati','N','N'
--							,@idsor01,@idsor02,@idsor03,@idsor04,@idsor05,0)

--			insert into finvardetail(yvar,nvar, rownum,idfin,idupb,idunderwriting,amount,ct,cu,lt,lu,createexpense )
--			select @nextayear, @nmaxvar, ROW_NUMBER()OVER (ORDER BY [@bilprevision].idfin,idupb,idunderwriting),
--					[@bilprevision].idfin,idupb,idunderwriting,isnull(availableprevision_onlycash,0), 
--						GETDATE(),'compute_balancevar_rm_dati',GETDATE(),'compute_balancevar_rm_dati',
--						'N'
--				from @bilprevision 
--				JOIN finlast FL on [@bilprevision].idfin= FL.idfin
--				where 	isnull(availableprevision_onlycash,0)<>0
--				--AND ISNULL(assured,'N') = 'S'	

--     END


--	if  (@fin_kind= 3) AND (select count(*) from @bilprevision  where
--					isnull(var_ass_cassa,0)-isnull(done_cassa,0)<>0	)<> 0 BEGIN
--		set @nmaxvar= @nmaxvar+1

--		print 'variazione di prev. secondaria'
--		insert into finvar(yvar,nvar,idfinvarstatus,flagprevision,flagsecondaryprev,flagcredit,flagproceeds,
--				description,variationkind,
--				adate, ct,cu,lt,lu,moneytransfer,official,idsor01,idsor02,idsor03,idsor04,idsor05,varflag)
--		values(@nextayear,@nmaxvar,4,'N','S','N','N',
--					'Assestamento Fondo Cassa (Previsione)'	,	3	,					
--					@oggi,GETDATE(),'compute_balancevar_rm_dati',GETDATE(),'compute_balancevar_rm_dati','N','N'
--						,@idsor01,@idsor02,@idsor03,@idsor04,@idsor05,0)

--		insert into finvardetail(yvar,nvar, rownum,idfin,idupb,idunderwriting,amount,ct,cu,lt,lu,createexpense )
--		select @nextayear, @nmaxvar, ROW_NUMBER()OVER (ORDER BY [@bilprevision].idfin,idupb,idunderwriting),
--				[@bilprevision].idfin,idupb,idunderwriting,isnull(var_ass_cassa,0)-isnull(done_cassa,0), 
--					GETDATE(),'compute_balancevar_rm_dati',GETDATE(),'compute_balancevar_rm_dati',
--					'N'
--			from @bilprevision 
--			JOIN finlast FL on [@bilprevision].idfin= FL.idfin
--			where 	isnull(var_ass_cassa,0)-isnull(done_cassa,0)<>0
								

--	 END
	
--	if  (@fin_kind= 3) AND (select count(*) from @bilprevision  where
--					isnull(finalrevenue,0)-isnull(supposed_revenue,0)-isnull(done_revenue,0)<>0	)<> 0 BEGIN
--		set @nmaxvar= @nmaxvar+1

--		print 'variazione residui attivi in entrata ed in uscita'
--		insert into finvar(yvar,nvar,idfinvarstatus,flagprevision,flagsecondaryprev,flagcredit,flagproceeds,
--				description,variationkind,
--				adate, ct,cu,lt,lu,moneytransfer,official,idsor01,idsor02,idsor03,idsor04,idsor05,varflag)
--		values(@nextayear,@nmaxvar,4,'N','S','N','N',
--					'Assestamento Fondo Cassa (Previsione) - Residui Attivi'	,	3	,					
--					@oggi,GETDATE(),'compute_balancevar_rm_dati_residui',GETDATE(),'compute_balancevar_rm_dati','N','N'
--						,@idsor01,@idsor02,@idsor03,@idsor04,@idsor05,0)

--		insert into finvardetail(yvar,nvar, rownum,idfin,idupb,idunderwriting,amount,ct,cu,lt,lu,createexpense )
--		select @nextayear, @nmaxvar, ROW_NUMBER()OVER (ORDER BY [@bilprevision].idfin,idupb,idunderwriting),
--				[@bilprevision].idfin,idupb,idunderwriting,isnull(finalrevenue,0)-isnull(supposed_revenue,0)-isnull(done_revenue,0), 
--					GETDATE(),'compute_balancevar_rm_dati_residui',GETDATE(),'compute_balancevar_rm_dati',
--					'N'
--			from @bilprevision 
--			JOIN finlast FL on [@bilprevision].idfin= FL.idfin
--			where 	isnull(finalrevenue,0)-isnull(supposed_revenue,0)-isnull(done_revenue,0)<>0			

--	 END

--	 --variazione  crediti ove previsti
--	 	if  (@fin_kind <> 2) AND (@flagcredit ='S') AND (select count(*) from @bilprevision  where 
--				isnull(finalcreditsurplus,0)-isnull(supposed_creditsurplus,0)-isnull(done_creditsurplus,0)<>0)<> 0 BEGIN
--		set @nmaxvar= @nmaxvar+1

--		print 'variazione crediti'
--		insert into finvar(yvar,nvar,idfinvarstatus,flagprevision,flagsecondaryprev,flagcredit,flagproceeds,
--				description,variationkind,
--				adate, ct,cu,lt,lu,moneytransfer,official,idsor01,idsor02,idsor03,idsor04,idsor05,varflag)
--		values(@nextayear,@nmaxvar,4,'N','N','S','N',
--					'Assestamento Avanzo Amministrazione (Crediti)'	,	3	,					
--					@oggi,GETDATE(),'compute_balancevar_rm_dati',GETDATE(),'compute_balancevar_rm_dati','N','N'
--						,@idsor01,@idsor02,@idsor03,@idsor04,@idsor05,0)

--		insert into finvardetail(yvar,nvar, rownum,idfin,idupb,idunderwriting,amount,ct,cu,lt,lu,createexpense )
--		select @nextayear, @nmaxvar, ROW_NUMBER()OVER (ORDER BY [@bilprevision].idfin,idupb,idunderwriting),
--				[@bilprevision].idfin,idupb,idunderwriting,isnull(finalcreditsurplus,0)-isnull(supposed_creditsurplus,0)-isnull(done_creditsurplus,0) , 
--					GETDATE(),'compute_balancevar_rm_dati',GETDATE(),'compute_balancevar_rm_dati',
--					'N'
--			from @bilprevision 
--			JOIN finlast FL on [@bilprevision].idfin= FL.idfin
--			where 	isnull(finalcreditsurplus,0)-isnull(supposed_creditsurplus,0)-isnull(done_creditsurplus,0)<>0			

--	 END
--	 if  (@fin_kind = 2) AND (@flagcredit ='S') AND (select count(*) from @bilprevision  where 
--				([@bilprevision].assured = 'N') AND ([@bilprevision].finpart = 'S') 
--				AND isnull(totvarcredit,0) + isnull(totcreditpart,0)-isnull(di_cassa,0) <>0)<> 0 
--	 BEGIN
--		set @nmaxvar= @nmaxvar+1

--		print 'variazione crediti'
--		-- Per la dotazione crediti si dovrebbe riportare in sede di riporto bilancio con SOLA CASSA come previsione principale:
--		-- Crediti Disponibile da riportare = Assegnazione Crediti Iniziale + Assegnazione Crediti in corso d'anno - Pagato
--		insert into finvar(yvar,nvar,idfinvarstatus,flagprevision,flagsecondaryprev,flagcredit,flagproceeds,
--				description,variationkind,
--				adate, ct,cu,lt,lu,moneytransfer,official,idsor01,idsor02,idsor03,idsor04,idsor05,varflag)
--		values(@nextayear,@nmaxvar,4,'N','N','S','N',
--					'Assestamento Avanzo Amministrazione (Crediti)'	,	3	,					
--					@oggi,GETDATE(),'compute_balancevar_rm_dati',GETDATE(),'compute_balancevar_rm_dati','N','N'
--						,@idsor01,@idsor02,@idsor03,@idsor04,@idsor05,0)

--		insert into finvardetail(yvar,nvar, rownum,idfin,idupb,idunderwriting,amount,ct,cu,lt,lu,createexpense )
--		select @nextayear, @nmaxvar, ROW_NUMBER()OVER (ORDER BY [@bilprevision].idfin,idupb,idunderwriting),
--				[@bilprevision].idfin,idupb,idunderwriting,isnull(totvarcredit,0) + isnull(totcreditpart,0)-isnull(di_cassa,0)  , 
--					GETDATE(),'compute_balancevar_rm_dati',GETDATE(),'compute_balancevar_rm_dati',
--					'N'
--		from @bilprevision 
--		JOIN finlast FL on [@bilprevision].idfin= FL.idfin
--		where 	([@bilprevision].assured = 'N') AND ([@bilprevision].finpart = 'S') AND (isnull(totvarcredit,0) + isnull(totcreditpart,0)-isnull(di_cassa,0) <>0)

--	 END
	 
	 
--	 --variazione di incassi ove previsti
--	 if  (@flagproceeds ='S') AND (select count(*) from @bilprevision where 
--				isnull(supposed_floatfund,0)-isnull(finalfloatfund,0)-isnull(done_floatfund,0)<>0
--				)<> 0 BEGIN
--		set @nmaxvar= @nmaxvar+1

--		print 'variazione di incassi' 	 
--		insert into finvar(yvar,nvar,idfinvarstatus,flagprevision,flagsecondaryprev,flagcredit,flagproceeds,
--				description,variationkind,
--				adate, ct,cu,lt,lu,moneytransfer,official,idsor01,idsor02,idsor03,idsor04,idsor05,varflag)
--		values(@nextayear,@nmaxvar,4,'N','N','N','S',
--					'Assestamento Fondo Cassa (Cassa)'	,	3	,					
--					@oggi,GETDATE(),'compute_balancevar_rm_dati',GETDATE(),'compute_balancevar_rm_dati','N','N'
--						,@idsor01,@idsor02,@idsor03,@idsor04,@idsor05,0)

--		insert into finvardetail(yvar,nvar, rownum,idfin,idupb,idunderwriting,amount,ct,cu,lt,lu,createexpense )
--		select @nextayear, @nmaxvar, ROW_NUMBER()OVER (ORDER BY [@bilprevision].idfin,idupb,idunderwriting),
--				[@bilprevision].idfin,idupb,idunderwriting,isnull(finalfloatfund,0)-isnull(supposed_floatfund,0)-isnull(done_floatfund,0) , 
--					GETDATE(),'compute_balancevar_rm_dati',GETDATE(),'compute_balancevar_rm_dati',
--					'N'
--			from @bilprevision 
--			JOIN finlast FL on [@bilprevision].idfin= FL.idfin
--			where isnull(supposed_floatfund,0)-isnull(finalfloatfund,0)-isnull(done_floatfund,0)<>0			

--	 END
	 


--END --if (@generatevar='S')



END





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


