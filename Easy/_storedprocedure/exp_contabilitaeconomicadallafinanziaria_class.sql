
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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



if exists (select * from dbo.sysobjects where id = object_id(N'[exp_contabilitaeconomicadallafinanziaria_class]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_contabilitaeconomicadallafinanziaria_class]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE    PROCEDURE [exp_contabilitaeconomicadallafinanziaria_class]
(
	@ayear smallint,
	@adate datetime,
	@idsorkind int,
	@showupb char(1)='N',
	@idupb varchar(36)='%',
	@showchildupb char(1)='N',
	@showmissioneprogrammi char(1)='S',
	@idsorkindmissioneprogrammi int,
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null

)
AS BEGIN

--  exec exp_contabilitaeconomicadallafinanziaria_class 2013, {ts '2013-12-31 00:00:00'}, 35, 'S','00010007','N','N',47,null,null,null,null,null
-- exp_contabilitaeconomicadallafinanziaria_class '2013', {ts '2013-07-18 00:00:00.000'}, '16', 'S', '%', 'N', 'S', 5, null, null, null, null, null


DECLARE @idupboriginal varchar(36)
SET @idupboriginal = @idupb

declare @fixedidupb varchar(36)
set @fixedidupb= null
if (@showupb='N') set @fixedidupb='0001'

IF (@showchildupb = 'S')
BEGIN
	SET @idupb = @idupb + '%' 
END

DECLARE @MostraTutteVoci char(1)
SELECT @MostraTutteVoci = isnull(paramvalue,'N') 
FROM generalreportparameter WHERE idparam = 'MostraTutteVoci'

DECLARE @oplevel tinyint
SELECT @oplevel = MAX(nlevel) --> Prendiamo il max perchè le prev. vengono messe sui nodi foglia, enon sui capitolo come avviene per il bilancio.
FROM sortinglevel
WHERE  (flag&2)<>0 and idsorkind = @idsorkind
	
	
declare @fin_kind tinyint
SELECT  @fin_kind = isnull(fin_kind,0) FROM config WHERE ayear = @ayear

DECLARE @minoplevelfin tinyint
SELECT  @minoplevelfin = min(nlevel)
FROM 	finlevel
WHERE 	ayear = @ayear and flag&2 <> 0

DECLARE @cashvaliditykind int
SELECT  @cashvaliditykind = cashvaliditykind FROM config WHERE ayear = @ayear

DECLARE @incomefinphase tinyint
DECLARE @expensefinphase tinyint
DECLARE @maxincomephase tinyint
DECLARE @maxexpensephase tinyint

SELECT @incomefinphase = assessmentphasecode FROM config WHERE ayear = @ayear
IF @incomefinphase IS NULL
BEGIN
	SELECT @incomefinphase = incomefinphase FROM uniconfig
END
SELECT @maxincomephase = MAX(nphase) FROM incomephase

SELECT @expensefinphase = appropriationphasecode FROM config WHERE ayear = @ayear
IF @expensefinphase IS NULL
BEGIN
	SELECT @expensefinphase = expensefinphase FROM uniconfig
END
SELECT @maxexpensephase = MAX(nphase) FROM expensephase


CREATE TABLE #data
(
	idsor int,
	idupb varchar(36),
	idsormissioneprogrammi int,
	quota decimal(19,2),
	prevision decimal(19,2),
	varprevision decimal (19,2),
	prevision2 decimal(19,2),
	prevision3 decimal(19,2),
	E_mov_finphase_C decimal(19,2),
	E_var_finphase_C decimal(19,2),
	E_mov_maxphase_C decimal(19,2),	--> Ultima fase
	E_var_maxphase_C decimal(19,2),
	proceeds_C decimal(19,2),	
	var_proceeds_C decimal(19,2),	--> Incasso in base alla configurazione

	S_mov_finphase_C decimal(19,2),
	S_var_finphase_C decimal(19,2),
	S_mov_maxphase_C decimal(19,2),	--> Ultima fase
	S_var_maxphase_C decimal(19,2),
	payment_C decimal(19,2),		--> Pagamento in base alla configurazione
	var_payment_C decimal(19,2),

	ep_amount decimal(19,2)
)

-- Inserisce previsione iniziale, previsione precedente, previsione anno+1, previsione anno+2
insert into #data (
	idsor,
	idupb,
	prevision,
	prevision2,
	prevision3
)
select budgetprevision.idsor, isnull(@fixedidupb,budgetprevision.idupb),
		ISNULL(SUM(budgetprevision.prevision),0),
		isnull(sum(prevision2),0),
		isnull(sum(prevision3),0)
from budgetprevision 
join sorting 
	on budgetprevision.idsor = sorting.idsor
JOIN upb U
	ON budgetprevision.idupb = U.idupb
JOIN sortinglevel 
	ON sorting.nlevel = sortinglevel.nlevel 
where budgetprevision.ayear = @ayear
		and sorting.idsorkind = @idsorkind
		and sortinglevel.idsorkind = @idsorkind
		AND (budgetprevision.idupb LIKE @idupb)	
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND isnull(U.active,'N')='S'
		AND (sorting.nlevel = @oplevel
			OR (sorting.nlevel < @oplevel		
				AND not EXISTS (SELECT * FROM sorting S2 WHERE S2.paridsor = sorting.idsor and S2.idsorkind=@idsorkind)
				AND (sortinglevel.flag&2)<>0
			   )
			)
group by budgetprevision.idsor, isnull(@fixedidupb,budgetprevision.idupb)


-- Inserisce var di previsione
insert into #data (
	idsor,
	idupb,
	varprevision
)
select BD.idsor, 
	isnull(@fixedidupb,BD.idupb),
	ISNULL(SUM(BD.amount),0)
from budgetvar B
join budgetvardetail BD
	on B.nbudgetvar = BD.nbudgetvar
	and B.ybudgetvar = BD.ybudgetvar
join sorting 
	on BD.idsor = sorting.idsor
JOIN upb U
	ON BD.idupb = U.idupb

where BD.ybudgetvar = @ayear
		and B.adate <= @adate
		AND isnull(U.active,'N')='S'
		and sorting.idsorkind = @idsorkind
		AND (BD.idupb LIKE @idupb)	
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
group by BD.idsor, isnull(@fixedidupb,BD.idupb)



-- Se deve mostrare anche i codice della class. Missioni Programmi, inserisce anche questi.
 CREATE TABLE #missioniprogrammi(
	idsor int NOT NULL,
	sortcode varchar(50),
	idupb varchar(36) NOT NULL,
	quota decimal(19,6) NULL,
	PRIMARY KEY (idsor,idupb)
)

if (@showmissioneprogrammi ='S')
Begin
	insert into #missioniprogrammi (
		idupb,
		idsor,
		sortcode,
		quota
	)
	select	
			isnull(@fixedidupb,US.idupb),
			US.idsor,
			sorting.sortcode,
			isnull(US.quota,1)
	from upbsorting US
	join sorting 
		on US.idsor = sorting.idsor
	join sortingkind K
		ON sorting.idsorkind = K.idsorkind
	JOIN upb U
		ON US.idupb = U.idupb
	where  K.idsorkind = @idsorkindmissioneprogrammi
			AND (US.idupb LIKE @idupb)	
			AND isnull(U.active,'N')='S'
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
End


-- PARTE ENTRATA
	INSERT INTO #data(
		idsor,
		idupb,
		E_mov_finphase_C
	)
	SELECT
		FS.idsor,
		isnull(@fixedidupb,IY.idupb),
		SUM(IY.amount)
	FROM income I
	JOIN incomeyear IY
		ON IY.idinc = I.idinc
	JOIN finsorting FS
		ON FS.idfin = IY.idfin
	JOIN sorting S
		ON FS.idsor = S.idsor
	JOIN upb U
		ON IY.idupb = U.idupb
	JOIN incometotal IT
		ON IT.idinc = IY.idinc
		AND IT.ayear = IY.ayear
	WHERE I.adate <= @adate
		AND IY.ayear = @ayear
		AND S.idsorkind = @idsorkind
		AND ( (IT.flag & 1) =0)	--> Competenza
		AND I.nphase = @incomefinphase
		AND (IY.idupb LIKE @idupb)
		AND isnull(U.active,'N')='S'
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	GROUP BY FS.idsor, isnull(@fixedidupb,IY.idupb)

	INSERT INTO #data(
		idsor,
		idupb,
		E_var_finphase_C
	)
	SELECT 
		FS.idsor,
		isnull(@fixedidupb,IY.idupb),
		SUM(IV.amount)
	FROM incomevar IV
	JOIN income I
		ON IV.idinc = I.idinc
	JOIN incomeyear IY
		ON IY.idinc = IV.idinc
	JOIN finsorting FS
		ON FS.idfin = IY.idfin
	JOIN sorting S
		ON S.idsor = FS.idsor
	JOIN upb U
		ON IY.idupb = U.idupb
	JOIN incometotal IT
		ON IT.idinc = IY.idinc
		AND IT.ayear = IY.ayear
	WHERE IV.yvar = @ayear
		AND S.idsorkind = @idsorkind
		AND IY.ayear = @ayear
		AND ( (IT.flag & 1) =0)-- Competenza
		AND I.nphase = @incomefinphase
		AND IV.adate <= @adate 
		AND isnull(U.active,'N')='S'
		AND (IY.idupb LIKE @idupb)
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	GROUP BY FS.idsor, isnull(@fixedidupb,IY.idupb)

	INSERT INTO #data(
		idsor,
		idupb,
		E_mov_maxphase_C
	)
	SELECT
		FS.idsor,
		isnull(@fixedidupb,IY.idupb),
		SUM(IY.amount)
	FROM income I
	JOIN incomeyear IY
		ON IY.idinc = I.idinc
	JOIN finsorting FS
		ON FS.idfin = IY.idfin
	JOIN sorting S
		ON FS.idsor = S.idsor
	JOIN upb U
		ON IY.idupb = U.idupb
	JOIN incometotal IT
		ON IT.idinc = IY.idinc
		AND IT.ayear = IY.ayear
	WHERE I.adate <= @adate
		AND IY.ayear = @ayear
		AND S.idsorkind = @idsorkind
		AND ( (IT.flag & 1) =0)	--> Competenza
		AND I.nphase = @maxincomephase
		AND (IY.idupb LIKE @idupb)
		AND isnull(U.active,'N')='S'
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	GROUP BY FS.idsor, isnull(@fixedidupb,IY.idupb)

	INSERT INTO #data(
		idsor,
		idupb,
		E_var_maxphase_C
	)
	SELECT 
		FS.idsor,
		isnull(@fixedidupb,IY.idupb),
		SUM(IV.amount)
	FROM incomevar IV
	JOIN income I
		ON IV.idinc = I.idinc
	JOIN incomeyear IY
		ON IY.idinc = IV.idinc
	JOIN finsorting FS
		ON FS.idfin = IY.idfin
	JOIN sorting S
		ON S.idsor = FS.idsor
	JOIN upb U
		ON IY.idupb = U.idupb
	JOIN incometotal IT
		ON IT.idinc = IY.idinc
		AND IT.ayear = IY.ayear
	WHERE IV.yvar = @ayear
		AND S.idsorkind = @idsorkind
		AND IY.ayear = @ayear
		AND ( (IT.flag & 1) =0)-- Competenza
		AND I.nphase = @maxincomephase
		AND IV.adate <= @adate 
		AND (IY.idupb LIKE @idupb)
		AND isnull(U.active,'N')='S'
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	GROUP BY FS.idsor, isnull(@fixedidupb,IY.idupb)


	INSERT INTO #data(
		idsor,
		idupb,	
		proceeds_C
	)
	SELECT
		FS.idsor,
		isnull(@fixedidupb,HPV.idupb),
		SUM(HPV.amount)
	FROM historyproceedsview HPV
	JOIN upb U
		ON HPV.idupb = U.idupb
	JOIN finsorting FS
		ON FS.idfin = HPV.idfin
	JOIN sorting S
		ON S.idsor = FS.idsor
	WHERE HPV.competencydate <= @adate
		AND ( (HPV.totflag & 1) = 0)--Competenza
		AND HPV.ymov = @ayear
		AND S.idsorkind = @idsorkind
		AND (HPV.idupb LIKE @idupb)
		AND isnull(U.active,'N')='S'
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	GROUP BY FS.idsor, isnull(@fixedidupb,HPV.idupb)
	

	IF (@cashvaliditykind <> 4)
	BEGIN
		INSERT INTO #data(
			idsor,
			idupb,
			var_proceeds_C
		)
		SELECT 
			FS.idsor,
			isnull(@fixedidupb,IY.idupb),
			SUM(IV.amount)
		FROM incomevar IV
		JOIN incomeyear IY
			ON IY.idinc = IV.idinc
		JOIN finsorting FS
			ON FS.idfin = IY.idfin
		JOIN sorting S
			ON S.idsor = FS.idsor
		JOIN historyproceedsview HPV
			ON HPV.idinc = IV.idinc
		JOIN upb U
			ON HPV.idupb = U.idupb
		WHERE IV.yvar = @ayear
			AND IV.adate <= @adate
			AND IY.ayear = @ayear
			AND S.idsorkind = @idsorkind
			AND isnull(U.active,'N')='S'
			AND ( (HPV.totflag & 1) = 0)-- Competenza
			AND (HPV.competencydate <= @adate AND HPV.ymov = @ayear)
			AND (IY.idupb LIKE @idupb)	
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)	
		GROUP BY FS.idsor, isnull(@fixedidupb,IY.idupb)
	END

--	PARTE SPESA

	INSERT INTO #data(
		idsor,
		idupb,
		S_mov_finphase_C
	)
	SELECT
		FS.idsor,
		isnull(@fixedidupb,EY.idupb),
		SUM(EY.amount)
	FROM expense E
	JOIN expenseyear EY
		ON EY.idexp = E.idexp
	JOIN finsorting FS
		ON FS.idfin = EY.idfin
	JOIN sorting S
		ON S.idsor = FS.idsor
	JOIN upb U
		ON EY.idupb = U.idupb
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp
		AND ET.ayear = EY.ayear
	WHERE E.adate <= @adate
		AND EY.ayear = @ayear
		AND S.idsorkind = @idsorkind
		AND ( (ET.flag & 1) = 0) -- Competenza
		AND E.nphase = @expensefinphase
		AND (EY.idupb LIKE @idupb)
		AND isnull(U.active,'N')='S'
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)		
	GROUP BY FS.idsor, isnull(@fixedidupb,EY.idupb)
	
	INSERT INTO #data(
		idsor,
		idupb,
		S_var_finphase_C
	)
	SELECT
		FS.idsor,
		isnull(@fixedidupb,EY.idupb),
		SUM(EV.amount)
	FROM expensevar EV
	JOIN expense E
		ON EV.idexp = E.idexp
	JOIN expenseyear EY
		ON EY.idexp = EV.idexp
	JOIN finsorting FS
		ON FS.idfin = EY.idfin
	JOIN sorting S
		ON S.idsor = FS.idsor
	JOIN upb U
		ON EY.idupb = U.idupb
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp
		AND ET.ayear = EY.ayear
	WHERE EV.yvar = @ayear
		AND S.idsorkind = @idsorkind
		AND EV.adate <= @adate 
		AND EY.ayear = @ayear
		AND isnull(U.active,'N')='S'
		AND ( (ET.flag & 1) = 0) -- Competenza
		AND E.nphase = @expensefinphase
		AND (EY.idupb LIKE @idupb)	
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)	
	GROUP BY FS.idsor, isnull(@fixedidupb,EY.idupb)

	INSERT INTO #data(
		idsor,
		idupb,
		S_mov_maxphase_C
	)
	SELECT
		FS.idsor, 
		isnull(@fixedidupb,EY.idupb),
		SUM(EY.amount)
	FROM expense E
	JOIN expenseyear EY
		ON EY.idexp = E.idexp
	JOIN finsorting FS
		ON FS.idfin = EY.idfin
	JOIN sorting S
		ON S.idsor = FS.idsor
	JOIN upb U
		ON EY.idupb = U.idupb
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp
		AND ET.ayear = EY.ayear
	WHERE E.adate <= @adate
		AND EY.ayear = @ayear
		AND isnull(U.active,'N')='S'
		AND S.idsorkind = @idsorkind
		AND ( (ET.flag & 1) = 0) -- Competenza
		AND E.nphase = @maxexpensephase
		AND (EY.idupb LIKE @idupb)
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)		
	GROUP BY FS.idsor, isnull(@fixedidupb,EY.idupb)
	
	INSERT INTO #data(
		idsor,
		idupb,
		S_var_maxphase_C
	)
	SELECT
		FS.idsor,
		isnull(@fixedidupb,EY.idupb),
		SUM(EV.amount)
	FROM expensevar EV
	JOIN expense E
		ON EV.idexp = E.idexp
	JOIN expenseyear EY
		ON EY.idexp = EV.idexp
	JOIN finsorting FS
		ON FS.idfin = EY.idfin
	JOIN sorting S
		ON S.idsor = FS.idsor
	JOIN upb U
		ON EY.idupb = U.idupb
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp
		AND ET.ayear = EY.ayear
	WHERE EV.yvar = @ayear
		AND S.idsorkind = @idsorkind
		AND EV.adate <= @adate 
		AND EY.ayear = @ayear
		AND isnull(U.active,'N')='S'
		AND ( (ET.flag & 1) = 0) -- Competenza
		AND E.nphase = @maxexpensephase
		AND (EY.idupb LIKE @idupb)	
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)	
	GROUP BY FS.idsor, isnull(@fixedidupb,EY.idupb)



	INSERT INTO #data(
		idsor,
		idupb,
		payment_C
	)
	SELECT
		FS.idsor,
		isnull(@fixedidupb,EY.idupb),
		SUM(HPV.amount)
	FROM historypaymentview HPV
	JOIN expenseyear EY
		ON EY.idexp = HPV.idexp
	JOIN finsorting FS
		ON FS.idfin = HPV.idfin
	JOIN sorting S
		ON S.idsor = FS.idsor
	JOIN upb U
		ON EY.idupb = U.idupb
	WHERE HPV.competencydate <= @adate
		AND EY.ayear = @ayear
		AND S.idsorkind = @idsorkind
		AND ( (HPV.totflag & 1) = 0)-- Competenza
		AND HPV.ymov = @ayear
		AND isnull(U.active,'N')='S'
		AND (EY.idupb LIKE @idupb)		
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	GROUP BY FS.idsor, isnull(@fixedidupb,EY.idupb)


	
	IF (@cashvaliditykind <> 4)
	BEGIN
		INSERT INTO #data(
			idsor,
			idupb,
			var_payment_C
		)
		SELECT
			FS.idsor,	
			isnull(@fixedidupb,EY.idupb),
			SUM(EV.amount)
		FROM expensevar EV
		JOIN expenseyear EY
			ON EY.idexp = EV.idexp
		JOIN finsorting FS
			ON FS.idfin = EY.idfin
		JOIN sorting S
			ON S.idsor = FS.idsor
		JOIN upb U
			ON EY.idupb = U.idupb
		JOIN historypaymentview HPV
			ON HPV.idexp = EV.idexp
		WHERE EV.yvar = @ayear
			AND EV.adate <= @adate
			AND isnull(U.active,'N')='S'
			AND S.idsorkind = @idsorkind
			AND EY.ayear = @ayear
			AND ( (HPV.totflag & 1) = 0)--Competenza
			AND HPV.competencydate <= @adate	AND HPV.ymov = @ayear
			AND (EY.idupb LIKE @idupb)		
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)	
		GROUP BY FS.idsor,isnull(@fixedidupb,EY.idupb)
	END


-- Inserisce l'Utilizzato in EP

insert into #data (
	idsor,
	idupb,
	EP_amount
)
select A.idsor, 
	isnull(@fixedidupb,ED.idupb),
	abs(ISNULL(SUM(ED.amount),0))
from entry E
join entrydetail ED
	on E.yentry = ED.yentry
	and E.nentry = ED.nentry
join accountsorting A
	ON A.idacc = ED.idacc
join sorting S
	ON A.idsor = S.idsor
JOIN upb U
	ON ED.idupb = U.idupb
where E.yentry = @ayear
		and E.adate <= @adate
		and S.idsorkind = @idsorkind
		AND isnull(U.active,'N')='S'
		AND E.identrykind  not in (6,7) -- Esclude Epilogo, Apertura
		AND (ED.idupb LIKE @idupb)	
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
group by A.idsor, isnull(@fixedidupb,ED.idupb)





delete from #data where 
	isnull(prevision ,0) = 0 and 
	isnull(varprevision ,0) = 0 and 
	isnull(prevision2 ,0) = 0 and 
	isnull(prevision3 ,0) = 0 and 
	isnull(E_mov_finphase_C ,0) = 0 and 
	isnull(E_var_finphase_C ,0) = 0 and 
	isnull(E_mov_maxphase_C,0) = 0 and 
	isnull(E_var_maxphase_C ,0) = 0 and 
	isnull(proceeds_C ,0) = 0 and 	
	isnull(var_proceeds_C ,0) = 0 and 
	isnull(S_mov_finphase_C ,0) = 0 and 
	isnull(S_var_finphase_C,0) = 0 and 
	isnull(S_mov_maxphase_C,0) = 0 and 
	isnull(S_var_maxphase_C ,0) = 0 and 
	isnull(payment_C ,0) = 0 and 
	isnull(var_payment_C ,0) = 0 and 
	isnull(	ep_amount ,0) = 0 

	

IF (@showupb ='S')
BEGIN
 SELECT 
	K.description as 'Classificazione',
	S.sortcode as 'Cod.Conto',--'Codice Class.',
	S.description as 'Conto',
	upb.codeupb as 'Cod.UPB',
	upb.title as 'UPB',

	case when (@showmissioneprogrammi='S') then SUM(isnull(prevision,0) * isnull(M.quota,1)) 
	else SUM(isnull(prevision,0))
	end
		AS 'Budget Iniziale',
	case when (@showmissioneprogrammi='S') then SUM(isnull(prevision2,0) * isnull(M.quota,1)) 
	else SUM(isnull(prevision2,0))
	end
		AS 'Budget Iniziale Eserc.+1',
	case when (@showmissioneprogrammi='S') then SUM(isnull(prevision3,0) * isnull(M.quota,1)) 
	else SUM(isnull(prevision3,0))
	end
		AS 'Budget Iniziale Eserc.+2',
	case when (@showmissioneprogrammi='S') then SUM(isnull(varprevision,0) * isnull(M.quota,1)) 
	else SUM(isnull(varprevision,0))
	end 
		AS 'Variazioni di Budget',
	case when (@showmissioneprogrammi='S') then SUM((isnull(prevision,0) +isnull(varprevision,0)) * isnull(M.quota,1)) 
	else SUM(isnull(prevision,0) + isnull(varprevision,0))
	end
		AS 'Budget alla data',

	case when (@showmissioneprogrammi='S') then 
		(SUM((isnull(prevision,0) +isnull(varprevision,0)) * isnull(M.quota,1)) 
		- SUM(isnull(E_mov_finphase_C,0) * isnull(#data.quota,1) + isnull(E_var_finphase_C,0) * isnull(#data.quota,1)) 
		- SUM(isnull(S_mov_finphase_C,0) * isnull(#data.quota,1) + isnull(S_var_finphase_C,0) * isnull(#data.quota,1)) 
		)
	else (SUM((isnull(prevision,0) +isnull(varprevision,0))) 
		- SUM(isnull(E_mov_finphase_C,0)  + isnull(E_var_finphase_C,0) ) 
		- SUM(isnull(S_mov_finphase_C,0)  + isnull(S_var_finphase_C,0) ) 
		)
	end
		AS 'Budget residuo',

	case when (@showmissioneprogrammi='S') then
		SUM(isnull(E_mov_finphase_C,0) * isnull(#data.quota,1) + isnull(E_var_finphase_C,0) * isnull(#data.quota,1)) 
		else SUM(isnull(E_mov_finphase_C,0) + isnull(E_var_finphase_C,0)) 
		end
		AS 'Budget Accertato c/Comp.',
	case when (@showmissioneprogrammi='S') then
		SUM(isnull(E_mov_maxphase_C,0) * isnull(#data.quota,1) + isnull(E_var_maxphase_C,0) * isnull(#data.quota,1)) 
		else SUM(isnull(E_mov_maxphase_C,0)+ isnull(E_var_maxphase_C,0) ) 
		end AS 'Fatturato(E)',
	case when (@showmissioneprogrammi='S') then
		SUM(isnull(proceeds_C,0) * isnull(#data.quota,1) + isnull(var_proceeds_C,0) * isnull(#data.quota,1)) 
		else SUM(isnull(proceeds_C,0) + isnull(var_proceeds_C,0)) 
		end AS 'Cassa(E)',
	case when (@showmissioneprogrammi='S') then
		SUM(isnull(S_mov_finphase_C,0) * isnull(#data.quota,1) + isnull(S_var_finphase_C,0) * isnull(#data.quota,1)) 
		else SUM(isnull(S_mov_finphase_C,0) + isnull(S_var_finphase_C,0) )
		end AS 'Budget Impegnato c/Comp.',
	case when (@showmissioneprogrammi='S') then
		SUM(isnull(S_mov_maxphase_C,0) * isnull(#data.quota,1) + isnull(S_var_maxphase_C,0) * isnull(#data.quota,1))
		else SUM(isnull(S_mov_maxphase_C,0) + isnull(S_var_maxphase_C,0))
		end AS 'Fatturato(S)',
	case when (@showmissioneprogrammi='S') then
		SUM(isnull(payment_C,0) * isnull(#data.quota,1) + isnull(var_payment_C,0) * isnull(#data.quota,1)) 
		else SUM(isnull(payment_C,0) + isnull(var_payment_C,0) ) 
		end AS 'Cassa(S)',
	case when (@showmissioneprogrammi='S') then
		SUM(isnull(EP_amount,0) * isnull(#data.quota,1)) 
		else SUM(isnull(EP_amount,0)) 
		end AS 'Utilizzato in E/P',
	case when (@showmissioneprogrammi='S') then	M.sortcode 
	else null end
		as 'Missione/Programmi'
FROM #data 
join sorting S
	on #data.idsor = S.idsor 
join sortingkind K
	on S.idsorkind = K.idsorkind
join upb
	on #data.idupb=upb.idupb
LEFT OUTER JOIN #missioniprogrammi M
		ON upb.idupb = M.idupb
where   upb.idupb like @idupb
	   and S.idsorkind = @idsorkind
	   AND isnull(upb.active,'N')='S'
	   AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	   AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	   AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	   AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	   AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
GROUP BY 
	K.description,
	S.sortcode,	S.description, upb.codeupb,upb.title,
	M.sortcode
 ORDER BY upb.codeupb asc, S.sortcode ASC 

END

IF (@showupb ='N')
BEGIN
SELECT 
	K.description as 'Classificazione',
	S.sortcode as 'Cod.Conto',--'Codice Class.',
	S.description as 'Conto',
	case when (@showmissioneprogrammi='S') then SUM(isnull(prevision,0) * isnull(M.quota,1)) 
	else SUM(isnull(prevision,0))
	end
		AS 'Budget Iniziale',
	case when (@showmissioneprogrammi='S') then SUM(isnull(prevision2,0) * isnull(M.quota,1)) 
	else SUM(isnull(prevision2,0))
	end
		AS 'Budget Iniziale Eserc.+1',
	case when (@showmissioneprogrammi='S') then SUM(isnull(prevision3,0) * isnull(M.quota,1)) 
	else SUM(isnull(prevision3,0))
	end
		AS 'Budget Iniziale Eserc.+2',
	case when (@showmissioneprogrammi='S') then SUM(isnull(varprevision,0) * isnull(M.quota,1)) 
	else SUM(isnull(varprevision,0))
	end 
		AS 'Variazioni di Budget',
	case when (@showmissioneprogrammi='S') then SUM((isnull(prevision,0) +isnull(varprevision,0)) * isnull(M.quota,1)) 
	else SUM(isnull(prevision,0) + isnull(varprevision,0))
	end
		AS 'Budget alla data',

	case when (@showmissioneprogrammi='S') then 
		(SUM((isnull(prevision,0) +isnull(varprevision,0)) * isnull(M.quota,1)) 
		- SUM(isnull(E_mov_finphase_C,0) * isnull(#data.quota,1) + isnull(E_var_finphase_C,0) * isnull(#data.quota,1)) 
		- SUM(isnull(S_mov_finphase_C,0) * isnull(#data.quota,1) + isnull(S_var_finphase_C,0) * isnull(#data.quota,1)) 
		)
	else (SUM((isnull(prevision,0) +isnull(varprevision,0))) 
		- SUM(isnull(E_mov_finphase_C,0)  + isnull(E_var_finphase_C,0) ) 
		- SUM(isnull(S_mov_finphase_C,0)  + isnull(S_var_finphase_C,0) ) 
		)
	end
		AS 'Budget residuo',

	case when (@showmissioneprogrammi='S') then
		SUM(isnull(E_mov_finphase_C,0) * isnull(#data.quota,1) + isnull(E_var_finphase_C,0) * isnull(#data.quota,1)) 
		else SUM(isnull(E_mov_finphase_C,0) + isnull(E_var_finphase_C,0)) 
		end
		AS 'Budget Accertato c/Comp.',
	case when (@showmissioneprogrammi='S') then
		SUM(isnull(E_mov_maxphase_C,0) * isnull(#data.quota,1) + isnull(E_var_maxphase_C,0) * isnull(#data.quota,1)) 
		else SUM(isnull(E_mov_maxphase_C,0)+ isnull(E_var_maxphase_C,0) ) 
		end AS 'Fatturato(E)',
	case when (@showmissioneprogrammi='S') then
		SUM(isnull(proceeds_C,0) * isnull(#data.quota,1) + isnull(var_proceeds_C,0) * isnull(#data.quota,1)) 
		else SUM(isnull(proceeds_C,0) + isnull(var_proceeds_C,0)) 
		end AS 'Cassa(E)',
	case when (@showmissioneprogrammi='S') then
		SUM(isnull(S_mov_finphase_C,0) * isnull(#data.quota,1) + isnull(S_var_finphase_C,0) * isnull(#data.quota,1)) 
		else SUM(isnull(S_mov_finphase_C,0) + isnull(S_var_finphase_C,0) )
		end AS 'Budget Impegnato c/Comp.',
	case when (@showmissioneprogrammi='S') then
		SUM(isnull(S_mov_maxphase_C,0) * isnull(#data.quota,1) + isnull(S_var_maxphase_C,0) * isnull(#data.quota,1))
		else SUM(isnull(S_mov_maxphase_C,0) + isnull(S_var_maxphase_C,0))
		end AS 'Fatturato(S)',
	case when (@showmissioneprogrammi='S') then
		SUM(isnull(payment_C,0) * isnull(#data.quota,1) + isnull(var_payment_C,0) * isnull(#data.quota,1)) 
		else SUM(isnull(payment_C,0) + isnull(var_payment_C,0) ) 
		end AS 'Cassa(S)',
	case when (@showmissioneprogrammi='S') then
		SUM(isnull(EP_amount,0) * isnull(#data.quota,1)) 
		else SUM(isnull(EP_amount,0)) 
		end AS 'Utilizzato in E/P',
	case when (@showmissioneprogrammi='S') then	M.sortcode 
	else null end
		as 'Missione/Programmi'
FROM #data 
join sorting S
	on #data.idsor = S.idsor 
join sortingkind K
	on S.idsorkind = K.idsorkind
LEFT OUTER JOIN #missioniprogrammi M
		ON #data.idupb = M.idupb
where   S.idsorkind = @idsorkind
GROUP BY K.description,	S.sortcode,	S.description, M.sortcode 
 ORDER BY S.sortcode ASC 

END	


drop table #missioniprogrammi
drop table #data

END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

go


