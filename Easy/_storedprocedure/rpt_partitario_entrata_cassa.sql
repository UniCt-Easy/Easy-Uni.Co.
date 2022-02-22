
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_partitario_entrata_cassa]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_partitario_entrata_cassa]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE   PROCEDURE [rpt_partitario_entrata_cassa]
	@ayear int,
	@kind char(1),
	@idupb	varchar(36),
	@nlevel tinyint,
	@start datetime,
	@stop datetime,
	@showupb char(1),
	@showchildupb char(1),
	@suppressifblank char(1),
	@flagnofficial	char(1),
	@idfin int
AS
BEGIN
/* Versione 1.0.1 del 17/09/2007 ultima modifica: PINO */
DECLARE @idupboriginal varchar(36)
SET @idupboriginal= @idupb
IF (@showchildupb = 'S') 
BEGIN
	SET @idupb=@idupb+'%' 
END

-- exec rpt_partitario_entrata_cassa 2011, 'S', '%', 3, {ts '2011-06-01 00:00:00'}, {ts '2011-12-31 00:00:00'}, 'N', 'N', 'S', 'N', 13550 
DECLARE @level_input tinyint
SET  @level_input = ISNULL((SELECT nlevel from fin where idfin = @idfin) ,@nlevel)
-- ho scelto come livello 2 e poi ho specificato il capitolo, lui corregge @nlevel dandogli 3
IF (@nlevel < @level_input ) AND (@idfin is not null)
	BEGIN
	SET  @nlevel = @level_input
	END



/*DECLARE @kind_bit  tinyint 
IF @kind='C' set @kind_bit = 0
IF @kind='R' set @kind_bit = 1
*/
DECLARE @level varchar(50)
SELECT  @level = description 
FROM 	finlevel
WHERE 	nlevel = @nlevel
AND 	ayear = @ayear

DECLARE @levelusable tinyint
SELECT 	@levelusable = MIN(nlevel)
FROM 	finlevel
WHERE 	flag&2 <> 0
AND 	ayear = @ayear

IF @levelusable < @nlevel
BEGIN	
	SET @levelusable = @nlevel
END

CREATE TABLE #income	(
	codeupb varchar(50),
	idupb varchar(36),
	upb varchar(150),
	upbprintingorder varchar(50),
	idfin int,
	rowkind int,
	nphase tinyint,
	operationdate datetime,
	operationkind varchar(55),
	idmov int,
	idreg int,
	ymov int,
	nmov int,
	nofficial int,
	nsubmov int,
	ndoc int,
	description varchar(150),
	doc varchar(150),
	initialprevision decimal(19,2),
	finvar decimal(19,2),
	cassaphase_amount decimal(19,2),
	emessiondate datetime,
	printeddate datetime,
	trasmitteddate datetime,
	transactiondate datetime,
	annulmentdate datetime,
	annotations varchar(400),
	available decimal(19,2),
	hierarchy varchar (50)
)
DECLARE @firstday datetime
SET 	@firstday = CONVERT(datetime, '01-01-' + CONVERT(varchar(4),@ayear), 105)

DECLARE @previsionkind char(1) 
SELECT  @previsionkind =  
	 CASE 
		WHEN fin_kind IN (1,3) THEN 'C'
		WHEN fin_kind = 2 THEN 'S'
	 END
FROM  config 
WHERE config.ayear = @ayear

DECLARE @secprevisionkind    char(1) 
SELECT  @secprevisionkind  = 
	 CASE 
		WHEN fin_kind = 3 THEN 'S'
		ELSE NULL
	END
FROM 	config 
WHERE   config.ayear = @ayear

DECLARE @finphase tinyint
DECLARE @finname varchar(50)
SELECT @finphase = assessmentphasecode FROM config  WHERE ayear = @ayear
SELECT @finname = description FROM incomephase WHERE nphase = @finphase
DECLARE @phasecassa varchar(50)
DECLARE @maxincomephase tinyint
SELECT @maxincomephase = MAX(nphase) FROM incomephase
SELECT @phasecassa = description FROM incomephase WHERE nphase = @maxincomephase


IF ((@kind IN ('C','S')) AND (DATEDIFF(DAY,@start, @firstday) = 0))
BEGIN
	INSERT INTO #income
		(
		idfin,
		codeupb	,
		idupb,
		upb,
		upbprintingorder,
		rowkind,
		operationdate,
		operationkind,
		initialprevision
		)
	SELECT 
		fin.idfin,
		upb.codeupb,
		upb.idupb,
		upb.title,
		upb.printingorder,
		1,
		@firstday,
		'Prev.iniziale',
		CASE
			WHEN @kind = 'C' THEN (SELECT SUM(fy2.prevision) 
						FROM finyear fy2 
						JOIN fin f2
							ON fy2.idfin=f2.idfin
						JOIN finlink
							ON finlink.idchild = fy2.idfin
							AND finlink.nlevel = @nlevel
						WHERE   finlink.idparent = fin.idfin
							AND f2.nlevel = @levelusable 
							AND fy2.idupb= upb.idupb)
			WHEN (@kind = 'S' and @previsionkind = 'S') 
					THEN (SELECT SUM(fy2.prevision) 
						FROM finyear fy2 
						JOIN fin f2
							ON fy2.idfin=f2.idfin
						JOIN finlink
							ON finlink.idchild = fy2.idfin
							AND finlink.nlevel = @nlevel
						WHERE   finlink.idparent = fin.idfin
							AND f2.nlevel = @levelusable 
							AND fy2.idupb= upb.idupb)
			WHEN (@kind = 'S' and @secprevisionkind = 'S') 
					THEN (SELECT SUM(fy2.secondaryprev) 
						FROM finyear fy2 
						JOIN fin f2
							ON fy2.idfin=f2.idfin
						JOIN finlink
							ON finlink.idchild = fy2.idfin
							AND finlink.nlevel = @nlevel
						WHERE finlink.idparent = fin.idfin
							AND f2.nlevel = @levelusable 
							AND fy2.idupb= upb.idupb)
			END
	FROM finyear
	JOIN fin
		ON finyear.idfin = fin.idfin
	JOIN upb
		ON finyear.idupb = upb.idupb
	left outer JOIN finlink
		ON finlink.idchild = finyear.idfin
		AND finlink.nlevel = @level_input
	WHERE (upb.idupb like @idupb )
		AND fin.ayear = @ayear
		AND ((fin.flag&1)=0) -- Entrata
		AND fin.nlevel = @nlevel
		AND (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin)
END

DECLARE @cashvaliditykind int
SELECT  @cashvaliditykind = cashvaliditykind
FROM config
WHERE ayear = @ayear
IF (DATEDIFF(DAY,@start, @firstday) <> 0)
BEGIN
	CREATE TABLE #previousincome
	(
		idfin 	int,
		idupb 	varchar(36),
		initialprevision decimal(19,2),
		finvar decimal(19,2),
		cassaphase_amount decimal(19,2)
	)
	INSERT INTO #previousincome
		(
		idfin,
		idupb
		)
	SELECT finyear.idfin,
	       finyear.idupb
	FROM finyear
	JOIN fin
		ON finyear.idfin = fin.idfin
	JOIN upb
		ON finyear.idupb = upb.idupb
	left outer JOIN finlink
		ON finlink.idchild = finyear.idfin
		AND finlink.nlevel = @level_input
	WHERE (upb.idupb like @idupb)
		AND fin.ayear = @ayear
		AND ((fin.flag&1)=0) -- Entrata
		AND fin.nlevel = @nlevel
		AND (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin)
-------------------------------------------------------------------------------------------------------------

INSERT INTO #previousincome
	(
	idfin,
	idupb
	)--> Prende quelli che non ha preso prima perchè non presenti in finyear  
SELECT 
	isnull(FL1.idparent, fin.idfin),
	incomeyear.idupb
FROM incomeyear
	JOIN income
		ON income.idinc = incomeyear.idinc
	JOIN incometotal
		ON  incomeyear.idinc = incometotal.idinc
		AND incomeyear.ayear = incometotal.ayear	
	left outer JOIN finlink
		ON finlink.idchild = incomeyear.idfin
		AND finlink.nlevel = @level_input
	left outer JOIN finlink FL1
		ON FL1.idchild = incomeyear.idfin	
		AND FL1.nlevel = @nlevel
	JOIN fin
		ON fin.idfin = isnull(FL1.idparent, fin.idfin)--FL1.idparent
	WHERE /*((incometotal.flag&1) = @kind_bit)
		AND */income.adate < @start
		AND fin.ayear = @ayear
		AND ((fin.flag&1)=0) 
		AND income.nphase = @finphase
		AND incomeyear.ayear = @ayear
		AND (incomeyear.idupb like @idupb )
		AND (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin)	
		AND NOT EXISTS (SELECT #previousincome.idfin,#previousincome.idupb
			FROM #previousincome
			WHERE idupb = incomeyear.idupb AND idfin = isnull(finlink.idparent, fin.idfin))
	GROUP by incomeyear.idupb,isnull(FL1.idparent, fin.idfin)--> altrimenti prende una coppia per ogni stanziamento imputato a quella coppia
------------------------------------------------------------------------------------------------------------------------------

	IF (@kind IN ('C','S'))
		BEGIN
			UPDATE #previousincome
				SET initialprevision =
					(SELECT 
						CASE
							WHEN  @kind = 'C' THEN SUM(u2.prevision) 
							WHEN (@kind = 'S' and @previsionkind = 'S') THEN SUM(u2.prevision) 
							WHEN (@kind = 'S' and @secprevisionkind = 'S') THEN SUM(u2.secondaryprev) 
						END
					FROM finyear u2
					JOIN fin f2
						ON u2.idfin = f2.idfin	
					JOIN finlink
						ON finlink.idchild = f2.idfin 
						and finlink.nlevel =  @nlevel
					WHERE u2.idupb= #previousincome.idupb
						AND finlink.idparent = #previousincome.idfin
						AND f2.nlevel = @levelusable),
				finvar =
					(SELECT SUM(finvardetail.amount)
					FROM finvardetail
					JOIN finvar
						ON finvar.yvar = finvardetail.yvar
						AND finvar.nvar = finvardetail.nvar
					JOIN finlink
						ON finlink.idchild = finvardetail.idfin  
						AND finlink.nlevel = @nlevel
					WHERE finvardetail.idupb = #previousincome.idupb
						AND finvar.flagprevision ='S'
						AND finvar.variationkind <> 5
						AND finvar.adate < @start
						AND finvar.yvar = @ayear
						AND finlink.idparent = #previousincome.idfin)
		END
	ELSE
		BEGIN
			UPDATE #previousincome
				SET initialprevision =
					(SELECT SUM(incomeyear.amount)
					FROM incomeyear
					JOIN income
						ON income.idinc = incomeyear.idinc
					JOIN incometotal
						ON  incomeyear.idinc = incometotal.idinc
						AND incomeyear.ayear = incometotal.ayear	
					JOIN finlink
						ON finlink.idchild = incomeyear.idfin
						AND finlink.nlevel = @nlevel
					WHERE /* ((incometotal.flag&1) = @kind_bit)
						AND */income.adate < @start
						AND income.nphase = @finphase
						AND incomeyear.idupb = #previousincome.idupb
						AND finlink.idparent =  #previousincome.idfin
						AND incomeyear.ayear = @ayear)
		END

	IF (@cashvaliditykind <> 4)
	BEGIN
		UPDATE #previousincome
		SET cassaphase_amount = ISNULL((
			SELECT SUM(HPV.amount)
			FROM historyproceedsview HPV
			JOIN finlink
				ON finlink.idchild = HPV.idfin	
				AND finlink.nlevel = @nlevel
			WHERE (HPV.flagarrear = @kind OR @kind = 'S')
				AND HPV.idupb = #previousincome.idupb
				AND HPV.competencydate < @start
				AND finlink.idparent = #previousincome.idfin
				AND HPV.ymov = @ayear), 0)
			+ 
			ISNULL((
			SELECT SUM(incomevar.amount)
			FROM incomevar
			JOIN historyproceedsview HPV
				ON HPV.idinc = incomevar.idinc
			JOIN finlink
				ON finlink.idchild = HPV.idfin	
				AND finlink.nlevel = @nlevel
			WHERE incomevar.yvar = @ayear
				AND HPV.ymov = @ayear
				AND HPV.idupb = #previousincome.idupb
				AND finlink.idparent = #previousincome.idfin
				AND (HPV.flagarrear = @kind OR @kind = 'S')
				AND incomevar.adate < @start
				AND HPV.competencydate <= @start
				AND HPV.ymov = @ayear
				), 0)	
	END
	ELSE
	BEGIN
		UPDATE #previousincome
		SET cassaphase_amount = ISNULL((
			SELECT SUM(HPV.amount)
			FROM historyproceedsview HPV
			JOIN finlink
				ON finlink.idchild = HPV.idfin	
				AND finlink.nlevel = @nlevel
			WHERE (HPV.flagarrear = @kind OR @kind = 'S')
				AND HPV.idupb = #previousincome.idupb
				AND HPV.competencydate < @start
				AND finlink.idparent = #previousincome.idfin
				AND HPV.ymov = @ayear), 0)
	END
	

		INSERT INTO #income
		(
			idfin,
			idupb,
			codeupb,
			upb,
			upbprintingorder,
			rowkind,
			operationdate,
			operationkind,
			initialprevision,
			finvar,
			cassaphase_amount
		)
		SELECT
			#previousincome.idfin,
			upb.idupb,
			upb.codeupb,
			upb.title,
			upb.printingorder,
			1,
			DATEADD(dd, -1, @start),
		 	'Tot.prec.',
			#previousincome.initialprevision,
			#previousincome.finvar,
			#previousincome.cassaphase_amount
		FROM #previousincome
		JOIN fin
			ON fin.idfin = #previousincome.idfin
		JOIN upb 
			ON upb.idupb=#previousincome.idupb
END 
IF (@kind IN ('C','S')) 
BEGIN
-- Variazione di previsione

	INSERT INTO #income
		(
		idfin,
		idupb,codeupb,upb,upbprintingorder,
		rowkind,
		operationdate,
		operationkind,
		ymov,
		nmov,
		nofficial,
		description,
		finvar
		)
	SELECT 
		isnull(finlink.idparent, fin.idfin),
		upb.idupb,
		upb.codeupb,
		upb.title,
		upb.printingorder,
		2,
		finvar.adate,
		'Var.prev.',
		finvar.yvar,
		finvar.nvar,
		CASE finvar.official
			WHEN 'S' THEN finvar.nofficial
			ELSE NULL
		END,
		finvar.description,
		finvardetail.amount
	FROM finvardetail
	JOIN finvar
		ON finvar.yvar = finvardetail.yvar
		AND finvar.nvar = finvardetail.nvar
	JOIN upb 
		ON upb.idupb=finvardetail.idupb 
	left outer JOIN finlink
		ON finlink.idchild = finvardetail.idfin	
		AND finlink.nlevel = @level_input
	JOIN fin
		ON fin.idfin = finvardetail.idfin
	WHERE (upb.idupb like @idupb )
		AND finvar.flagprevision = 'S'
		AND finvar.variationkind <> 5
		AND finvar.adate BETWEEN @start AND @stop
		AND fin.ayear = @ayear
		AND ((fin.flag&1)=0) -- = 'E'	
		--AND fin.nlevel = @nlevel
		AND (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin)	
END

------------------------
-- Movimenti di Entrata / fase cassa
INSERT INTO #income
	(
	idfin,
	idmov,
	idupb,
	codeupb,
	upb,
	upbprintingorder,
	rowkind,
	nphase,
	operationdate,
	operationkind,
	ymov,
	nmov,
	ndoc,
	description,
 	doc,
	idreg,
	cassaphase_amount
	)
SELECT 
	isnull(FL1.idparent, fin.idfin),
	HPV.idinc,
	upb.idupb,upb.codeupb,upb.title,upb.printingorder,
	15, --> in quella due fasi c'era 5
	@maxincomephase,
	HPV.competencydate,
	@phasecassa,
	HPV.ymov,
	HPV.nmov,
	HPV.npro,
	HPV.description,
	CASE
		WHEN HPV.doc IS NOT NULL AND 
			HPV.docdate IS NULL THEN
			'Inc. ' + HPV.doc
		WHEN HPV.doc IS NOT NULL AND
			HPV.docdate IS NOT NULL THEN
			'Inc. ' + HPV.doc + 
			' del ' + CONVERT(varchar(20), HPV.docdate, 105)
		ELSE
			(NULL)
	END,
	HPV.idreg,
	HPV.amount
FROM historyproceedsview HPV
JOIN upb
	ON HPV.idupb = upb.idupb
left outer JOIN finlink
	ON finlink.idchild = HPV.idfin	
	AND finlink.nlevel = @level_input
left outer JOIN finlink FL1
	ON FL1.idchild = HPV.idfin	
	AND FL1.nlevel = @nlevel
JOIN fin
	ON fin.idfin = FL1.idparent
WHERE HPV.competencydate BETWEEN @start AND @stop
	AND (upb.idupb like @idupb )
	AND HPV.ymov = @ayear
	AND ((@kind IN ('C', 'R') AND HPV.flagarrear = @kind) OR @kind = 'S')
	AND fin.ayear = @ayear
	AND ((fin.flag&1)=0) -- Entrata
	AND fin.nlevel = @nlevel
	AND (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin)

-- Variazione ai Movimenti di Entrata / fase cassa 
IF (@cashvaliditykind <> 4)
BEGIN
	INSERT INTO #income
		(
		idfin,
		idmov,
		idupb, codeupb,upb,upbprintingorder,
		rowkind,
		nphase,
		operationdate,
		operationkind,
		ymov,
		nmov,
		nsubmov,
		ndoc,
		description,
		doc,
		idreg,
		cassaphase_amount
		)
	SELECT 
		isnull(FL1.idparent, fin.idfin),
		HPV.idinc,
		upb.idupb, upb.codeupb,upb.title,upb.printingorder,
		20,-- in quella a due fasi c'era 6
		@maxincomephase, 
		incomevar.adate,
		'Var.' + @phasecassa,
		HPV.ymov,
		HPV.nmov,
		incomevar.nvar,
		HPV.npro,
		incomevar.description,
		CASE
			WHEN incomevar.doc IS NOT NULL AND 
				incomevar.docdate IS NULL THEN
				'Inc. ' + incomevar.doc
			WHEN incomevar.doc IS NOT NULL AND
				incomevar.docdate IS NOT NULL THEN
				'Inc. ' + incomevar.doc + 
				' del ' + CONVERT(varchar(20), incomevar.docdate, 105)
			ELSE
		(NULL)
		END,
		HPV.idreg,
		incomevar.amount
	FROM incomevar
	JOIN historyproceedsview HPV
		ON  HPV.idinc = incomevar.idinc
	JOIN upb
		ON upb.idupb = HPV.idupb
	left outer JOIN finlink
		ON finlink.idchild = HPV.idfin	
		AND finlink.nlevel = @level_input
	left outer JOIN finlink FL1
		ON FL1.idchild = HPV.idfin	
		AND FL1.nlevel = @nlevel
	JOIN fin
		ON fin.idfin = FL1.idparent
	WHERE incomevar.yvar = @ayear
		AND incomevar.adate BETWEEN @start AND @stop
		AND isnull(incomevar.autokind,'') <>'22'
		AND (upb.idupb like @idupb)
		AND HPV.competencydate BETWEEN @start AND @stop
		AND HPV.ymov = @ayear
		AND ((@kind IN ('C', 'R') AND (HPV.flagarrear = @kind)) OR @kind = 'S')
		AND fin.ayear = @ayear
		AND ((fin.flag&1)=0) -- Entrata
		AND fin.nlevel = @nlevel
		AND (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin)
		
END
-- costruisce la gerarchia del movimento per creare l'ordinamento nel report
UPDATE #income 
SET 
	hierarchy = convert(varchar(4),E1.ymov) + '/' + 
	Replicate('0',6-len(convert(varchar(6),E1.nmov)))+ convert(varchar(6),E1.nmov)
FROM income
JOIN incomelink EL1
	ON EL1.idchild = income.idinc  AND EL1.nlevel = 1
LEFT OUTER JOIN incomelink EL2
	ON EL2.idchild = income.idinc  AND EL2.nlevel = 2
LEFT OUTER JOIN incomelink EL3
	ON EL3.idchild = income.idinc  AND EL3.nlevel = 3
LEFT OUTER JOIN incomelink EL4
	ON EL4.idchild = income.idinc  AND EL4.nlevel = 4
LEFT OUTER JOIN income E1
	ON E1.idinc = EL1.idparent
LEFT OUTER JOIN income E2
	ON E2.idinc = EL2.idparent
LEFT OUTER JOIN income E4
	ON E4.idinc = EL4.idparent
LEFT OUTER JOIN income E3
	ON E3.idinc = EL3.idparent
WHERE  EL1.idchild = #income.idmov
-------------------------------------------------------

UPDATE #income
SET 		emessiondate = proceedsview.adate,
		printeddate = 	proceedsview.printdate,
		trasmitteddate = proceedsview.transmissiondate,	
		transactiondate =  proceedsperformed.competencydate,
		annulmentdate = proceedsview.annulmentdate
FROM proceedsview
LEFT OUTER JOIN banktransaction
	ON banktransaction.kpro=proceedsview.kpro	
	AND (banktransaction.kind='C' OR banktransaction.kind IS NULL)	
LEFT OUTER JOIN proceedsperformed 
	ON proceedsperformed.npro=proceedsview.npro	
	AND proceedsperformed.ypro=proceedsview.ypro
WHERE #income.ndoc = proceedsview.npro
	AND proceedsview.ypro=@ayear
	
IF (@suppressifblank = 'N')
BEGIN
--se ho scelto di vedere l'upb inserisco le coppie upb/bilancio altrimenti inserisco solo il bilanico non utilizzato
	IF ( (@showupb <>'S') and (@idupboriginal = '%'))
	Begin
		INSERT INTO #income 
			(
			idfin,
			rowkind
			)
		SELECT 
			fin.idfin,
			1
		FROM fin 
		JOIN finlink
			ON finlink.idchild = fin.idfin	
			AND finlink.nlevel = @level_input
		WHERE  fin.ayear = @ayear
			AND ((fin.flag&1)= 0) -- Entrata
			AND fin.nlevel = @nlevel
			AND (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin)
			and not exists (SELECT *
				FROM #income
				WHERE fin.idfin = #income.idfin )	

	End
	Else
	Begin
		INSERT INTO #income 
			(
				idfin,
				idupb,
				codeupb,
				upb,
				upbprintingorder,
				rowkind
				)
		SELECT 
			isnull(FL1.idparent, fin.idfin),
			upb.idupb,
			codeupb,
			upb.title,
			upb.printingorder,
			1
		FROM fin CROSS JOIN upb 
		left outer JOIN finlink
			ON finlink.idchild = fin.idfin	
			AND finlink.nlevel = @level_input
		left outer JOIN finlink FL1
			ON FL1.idchild = fin.idfin	
			AND FL1.nlevel = @nlevel
		WHERE (upb.idupb like @idupb)
			AND fin.ayear = @ayear
			AND ((fin.flag&1)=0) -- Entrata	
			AND fin.nlevel = @nlevel
			AND (@idfin IS NULL OR isnull(finlink.idparent, fin.idfin) = @idfin)
			and not exists (SELECT *
				FROM #income
				WHERE isnull(#income.idupb,'')=isnull(i.idupb,'')  
				AND FL1.idparent = #income.idfin)
	End
	
END

IF (@showupb <>'S') AND (@idupboriginal <> '%' ) AND (@showchildupb = 'S')
		UPDATE #income SET  
			upbprintingorder = (SELECT TOP 1 upbprintingorder
				FROM #income
				WHERE idupb = @idupboriginal),
			upb = (SELECT TOP 1 upb
				FROM #income
				WHERE idupb = @idupboriginal),
			idupb = @idupboriginal,
			codeupb =(SELECT TOP 1 codeupb
				FROM #income	
				WHERE idupb = @idupboriginal)
IF (@showupb <>'S') and (@idupboriginal = '%')
		UPDATE #income SET  
			upbprintingorder = null	,
			upb =  null,
			idupb = null,
			codeupb = null



-- se ho scelto di nascondere le voci di bilancio non utilizzate:
-- cancello le righe che hanno valori pari a zero 
-- per cui non esistono variazioni di previzioni (rowkind=2) o movimenti di entrata (rowkind >= 3 )  
IF (@suppressifblank = 'S') AND @nlevel>2	--> se la stampa è x un livello sottostante la categoria cancella le righe
BEGIN
	DELETE FROM #income WHERE 
		ISNULL(initialprevision,0)=0 AND 
		ISNULL(finvar,0)=0 AND 
		ISNULL(cassaphase_amount,0)=0 AND
		NOT EXISTS (select * from  #income i
				where isnull(#income.idupb,'')=isnull(i.idupb,'') AND
				      #income.idfin=i.idfin AND 
					i.rowkind>1)
END



IF (@showupb <>'S') 
BEGIN
	SELECT 
		#income.idfin,
		idmov,
		@level as levelname,
		F.codefin,
		F.printingorder as finprintingorder,
		F.title,
		codeupb,idupb,upb,upbprintingorder,rowkind,
		nphase,operationdate,operationkind,ymov,nmov,nofficial,nsubmov,
		ndoc,description,doc,annotations,
		REG.title as registry,	
		isnull(sum(initialprevision),0) as initialprevision,
		isnull(sum(finvar),0) as finvar	,
		isnull(sum(available),0) as available,
		isnull(sum(cassaphase_amount),0) as cassaphase_amount,
		emessiondate,printeddate,trasmitteddate,transactiondate,
		annulmentdate,
		@finname as finname,				
		@phasecassa as phasecassa,
		hierarchy
	FROM #income
	JOIN fin F
		ON F.idfin = #income.idfin
	LEFT OUTER JOIN registry REG
		ON REG.idreg = #income.idreg
	GROUP BY codeupb,idupb,upb,upbprintingorder,hierarchy,
		F.printingorder,#income.idfin,idmov,
		F.codefin,F.title,
		rowkind,nphase,operationdate,operationkind,ymov,nmov,nofficial,nsubmov,ndoc,description,doc,
		annotations,REG.title,emessiondate,printeddate,
		trasmitteddate,transactiondate,annulmentdate
	ORDER BY upbprintingorder ASC, finprintingorder ASC,hierarchy ASC,
		rowkind ASC,
		ymov ASC,
		nmov ASC,
		nsubmov ASC
END
ELSE
BEGIN
	SELECT 	#income.idfin,
		idmov,
		@level as levelname,
		F.codefin,
		F.printingorder as finprintingorder,
		F.title,
		codeupb,idupb,upb,upbprintingorder,rowkind,
		nphase,operationdate,operationkind,ymov,nmov,nofficial,nsubmov,
		ndoc,description,doc,annotations,
		REG.title as registry,	
		isnull(initialprevision,0) as initialprevision,
		isnull(finvar,0) as finvar,
		isnull(available,0) as available,
		isnull(cassaphase_amount,0) as cassaphase_amount,
		emessiondate,printeddate,trasmitteddate,transactiondate,annulmentdate,
		@finname as finname,	
		@phasecassa as phasecassa,
		hierarchy		
	FROM #income
	JOIN fin F
		ON F.idfin = #income.idfin
	LEFT OUTER JOIN registry REG
		ON REG.idreg = #income.idreg
	ORDER BY upbprintingorder ASC, F.printingorder ASC,hierarchy ASC,
		rowkind ASC,
		ymov ASC,
		nmov ASC,
		nofficial ASC,
		nsubmov ASC
END

END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


