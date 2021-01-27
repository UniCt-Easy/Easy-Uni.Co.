
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


if exists (select * from dbo.sysobjects where id = object_id(N'[AL_rpt_bilpreventivo_UPB]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [AL_rpt_bilpreventivo_UPB]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO






-- select * from riep_preventivo
-- setuser 'accademia'
-- [AL_rpt_bilpreventivo_UPB] 2008, 'E', 5, ''

-- AL_rpt_riepprevisione_UPB 2008, 'S', '5', 'RAG'
CREATE     proceduRE AL_rpt_bilpreventivo_UPB
	@ayear smallint,
	@finpart char(1),
	@levelusable tinyint,
	@upb varchar(36) -- RAG
	,@disav char(1)
--	@codeupb varchar(20) -- 01FAL
AS BEGIN
DECLARE 	@showupb char(1)
DECLARE 	@showchildupb char(1)
DECLARE 	@suppressifblank char(1)
DECLARE		@idupb varchar(36)

delete riep_preventivo

delete assoc_bilancio_UPB_DEF where ayear = @AYEAR 
insert into assoc_bilancio_UPB_DEF (idman, title, idfin, upb ,ayear) 
select distinct F.IDMAN, M.TITLE, f.idfin , s.sortcode , @ayear
FROM FINLAST F 
JOIN MANAGER M
ON M.IDMAN = F.IDMAN
JOIN SORTINGview  s
ON s.description = m.title
and s.codesorkind ='CENTRORESP'
WHERE F.IDFIN IN (SELECT DISTINCT FI.IDFIN 
FROM FIN FI
WHERE FI.AYEAR = @AYEAR AND FI.flag & 1 =1) -- uscita
ORDER BY F.IDMAN, f.idfin

DECLARE	@nphase_fin_int int
SELECT @nphase_fin_int = 1

-- SELECT @levelusable = MIN(nlevel) FROM finlevel WHERE (flag & 2)<>0 AND ayear = @ayear
DECLARE @nphase_ass_app tinyint--char(1) -- Fase paragonabile all'accertamento o all'impegno
DECLARE	@nphase_fin tinyint--char(1) -- Fase in cui viene inserita la voce di bilancio
DECLARE	@maxphase tinyint--char(1) -- Fase di cassa

SELECT @showupb ='N'
SELECT @showchildupb = 'N'
SELECT @suppressifblank ='N'
SELECT @idupb ='%'

-- select * from sorting
DECLARE @idupboriginal varchar(36)
SET @idupboriginal = @idupb

IF (@showchildupb = 'S')
BEGIN
	SET @idupb = @idupb + '%' 
END

IF @finpart = 'E'
BEGIN
	SELECT @nphase_ass_app = assessmentphasecode FROM config WHERE ayear = @ayear
	SELECT @nphase_fin = incomefinphase FROM uniconfig
	SELECT @maxphase = MAX(nphase) FROM incomephase
	SET @nphase_fin_int = CONVERT(int, @nphase_fin)
END
ELSE
BEGIN
	SELECT @nphase_ass_app = appropriationphasecode FROM config WHERE ayear = @ayear
	SELECT @nphase_fin = expensefinphase from uniconfig
	SELECT @maxphase = MAX(nphase) FROM expensephase
	SET @nphase_fin_int = CONVERT(int, @nphase_fin) 
END


DECLARE	@finpart_bit  tinyint  -- Parte del bilancio (E = Entrata S = Spesa)
if @finpart='E' set @finpart_bit = 0
if @finpart='S' set @finpart_bit = 1

CREATE TABLE #totresiniziali
(
fase int,
idbilancio		int NOT NULL,
codefin varchar(50),
totale					float					NULL
)


DECLARE @minoplevel tinyint
SELECT @minoplevel = min(nlevel)
FROM finlevel
WHERE ayear = @ayear and (flag&2)<>0
	
--IF(@levelusable < @minoplevel)-- se decidi di fare la stampa per categoria
--begin
	--SET @levelusable = @minoplevel
--end


CREATE TABLE #decisionale
(
upb  varchar(15)   				 null,
decode_upb varchar(250)   				 null,
classif varchar(50)   				 null,
code1	varchar(10)	  				 not null,
desc1	varchar(100)	  				 NULL,
descliv1			varchar(35)		  				 NULL,
order1				varchar(10)		  				 NULL,

code2				varchar(10)		  				 NULL,
desc2			varchar(100)	  				 NULL,
descliv2		varchar(35)	  				 NULL,
order2			varchar(10)	  				 NULL,

code3				varchar(10)		  				 NULL,
desc3			varchar(100)	  				 NULL,
descliv3		varchar(35)	  				 NULL,
order3			varchar(10)	  				 NULL,

code4				varchar(10)		  				 NULL,
desc4			varchar(100)	  				 NULL,
descliv4		varchar(35)	  				 NULL,
order4			varchar(10)	  				 NULL,

code5				varchar(10)		  				 NULL,
desc5			varchar(100)	  				 NULL,
descliv5		varchar(35)	  				 NULL,
order5			varchar(10)	  				 NULL,

code6				varchar(10)		  				 NULL,
desc6			varchar(100)	  				 NULL,
descliv6		varchar(35)	  				 NULL,
order6			varchar(10)	  				 NULL,

initialprevision	decimal(19,2)	NULL,
previousprevision			decimal(19,2)			NULL,
secondaryprevision				decimal(19,2)					NULL,
previoussecondaryprev				decimal(19,2)					NULL,
currentarrears						decimal(19,2)			NULL,
previousarrears						decimal(19,2)			NULL,
cassa_competenza	char(1)				  				NULL,
mostraavanzo		char(1)				  				NULL,
fondocassapres							decimal(19,2)					NULL,
avanzoamminpres							decimal(19,2)					NULL,
fondocassapresprec					decimal(19,2)					NULL,
avanzoamminpresprec					decimal(19,2)					NULL,
prevdefcassa decimal(19,2)					NULL
)


CREATE TABLE #budget
(
	idfin int,
	codefin varchar(50),
	classif varchar(50)   				 null,

	codeupb varchar(50),
	idupb varchar(36),
	upb varchar(150),
	upbprintingorder varchar(36),
	initialprevision decimal(19,2),
	previousprevision decimal(19,2),
	secondaryprevision decimal(19,2),
	previoussecondaryprev decimal(19,2),
	currentarrears decimal(19,2),
	previousarrears decimal(19,2),
	tosuppress char(1),
	nlevel tinyint,
	code1 varchar(50),
	order1 varchar(50),
	code2 varchar(50),
	order2 varchar(50),
	code3 varchar(50),
	desc3 varchar(150),
	order3 varchar(50),
	code4 varchar(50),
	desc4 varchar(150),
	order4 varchar(50),
	code5 varchar(50),
	desc5 varchar(150),
	order5 varchar(50),
	code6 varchar(50),
	desc6 varchar(150),
	order6 varchar(50),
ayear smallint NULL
)

CREATE TABLE #budgetFONDI
(
	idfin int,
	codefin varchar(50),
	classif varchar(50)   				 null,

	codeupb varchar(50),
	idupb varchar(36),
	upb varchar(150),
	upbprintingorder varchar(36),
	initialprevision decimal(19,2),
	previousprevision decimal(19,2),
	secondaryprevision decimal(19,2),
	previoussecondaryprev decimal(19,2),
	currentarrears decimal(19,2),
	previousarrears decimal(19,2),
	tosuppress char(1),
	nlevel tinyint,
	code1 varchar(50),
	order1 varchar(50),
	code2 varchar(50),
	order2 varchar(50),
	code3 varchar(50),
	desc3 varchar(150),
	order3 varchar(50),
	code4 varchar(50),
	desc4 varchar(150),
	order4 varchar(50),
	code5 varchar(50),
	desc5 varchar(150),
	order5 varchar(50),
	code6 varchar(50),
	desc6 varchar(150),
	order6 varchar(50),
ayear smallint NULL
)

DECLARE @fin_kind tinyint
DECLARE @incomephase tinyint
DECLARE @expensephase tinyint

SELECT @fin_kind = fin_kind,
@incomephase = incomephase, 
@expensephase = expensephase
FROM config
WHERE ayear = @ayear


--DECLARE @newnlevel int
--SET @newnlevel = (CONVERT(int, @levelusable)*4)+3 --> è la lughezza del bilancio a partire dal livello scelto dall'utente(in realtà il termine flagusable non è esatto esso infatti rappresenta il "level")

DECLARE @supposed_ff_jan01 decimal(19,2)
DECLARE @supposed_aa_jan01 decimal(19,2)
DECLARE @ff_prec decimal(19,2)
DECLARE @aa_prec decimal(19,2)
DECLARE @infoadvance char(1)

DECLARE @startfloatfund DECIMAL(19,2)

SELECT @startfloatfund = --@startfloatfund
			ISNULL(startfloatfund, 0.0) +  
			ISNULL(competencyproceeds, 0.0) + 
			ISNULL(residualproceeds, 0.0) - 
			ISNULL(competencypayments, 0.0) - 
			ISNULL(residualpayments, 0.0) 
			FROM surplus
			WHERE ayear = @ayear -1



IF @finpart = 'E'
BEGIN
	SELECT --@supposed_ff_jan01
		@supposed_ff_jan01 =
			ISNULL(startfloatfund, 0) +
			ISNULL(proceedstilldate, 0) -
			ISNULL(paymentstilldate, 0) +
			ISNULL(proceedstoendofyear, 0) -
			ISNULL(paymentstoendofyear, 0),
-- @supposed_aa_jan01
		@supposed_aa_jan01 =
			ISNULL(startfloatfund, 0) +
			ISNULL(proceedstilldate, 0) -
			ISNULL(paymentstilldate, 0) +
			ISNULL(proceedstoendofyear, 0) -
			ISNULL(paymentstoendofyear, 0) +
			ISNULL(supposedpreviousrevenue, 0) +
			ISNULL(supposedcurrentrevenue , 0) -
			ISNULL(supposedpreviousexpenditure, 0) -
			ISNULL(supposedcurrentexpenditure, 0)
	FROM surplus
	WHERE ayear = @ayear - 1

	SELECT
--fondocassapresprec
		@ff_prec =
			ISNULL(startfloatfund, 0) + 
			ISNULL(competencyproceeds, 0) -
			ISNULL(competencypayments, 0) +
			ISNULL(residualproceeds, 0) -
			ISNULL(residualpayments, 0),
-- avanzoamminpresprec
		@aa_prec =
			ISNULL(startfloatfund, 0) +
			ISNULL(competencyproceeds, 0) -
			ISNULL(competencypayments, 0) +
			ISNULL(residualproceeds, 0) -
			ISNULL(residualpayments, 0) +
			ISNULL(previousrevenue, 0) +
			ISNULL(currentrevenue , 0) -
			ISNULL(previousexpenditure, 0) -
			ISNULL(currentexpenditure, 0)
	FROM surplus
	WHERE ayear = @ayear - 2
END

SELECT @infoadvance = paramvalue
FROM generalreportparameter
WHERE idparam = 'MostraAvanzo'

DECLARE @idfinincomesurplus int -- Flag indicante se l'avanzo di amministrazione è attribuito in previsione ad un capitolo di entrata o no --M. Smaldino
SELECT @idfinincomesurplus = isnull(idfinincomesurplus,0) 
	FROM config
	WHERE ayear = @ayear

declare @date smalldatetime
declare @italiano  varchar(200)
select @italiano = @@LANGUAGE
IF @italiano ='Italiano'
select @date = '31/12/'+convert(varchar(4),@ayear-1)
else
select @date = '12/31/'+convert(varchar(4),@ayear-1)

if @finpart ='S'
BEGIN

		INSERT INTO #totresiniziali
					(
					fase,
					idbilancio,
					codefin,
					totale
						)
	SELECT  e.nphase, my.idfin,e.codefin,  sum(MT.curramount  )
	FROM expenseyear MY
	JOIN expensetotal MT
	ON MT.idexp = MY.idexp
	AND MT.ayear = MY.ayear
	JOIN expenseview e
	ON e.idexp = My.idexp
	AND e.ayear = MY.ayear
	WHERE 
		e.adate <= @date
		AND MY.ayear = @ayear-1
		AND ((MT.flag & 1) = 1)  -->  'R'
		AND e.nphase >= @nphase_fin
		and e.ymov <  @ayear-1
--		and e.codefin = '1310000'
	GROUP BY e.nphase,my.idfin,e.codefin

END				
ELSE
		INSERT INTO #totresiniziali
					(
					fase,
					idbilancio,
					codefin,
					totale
					)
	SELECT  e.nphase, my.idfin,e.codefin,  sum(MT.curramount  )
	FROM incomeyear MY
	JOIN incometotal MT
	ON MT.idinc = MY.idinc
	AND MT.ayear = MY.ayear
	JOIN incomeview e
	ON e.idinc= My.idinc
	AND e.ayear = MY.ayear

	WHERE 
		e.adate <= @date
		AND MY.ayear = @ayear-1
		AND ((MT.flag & 1) = 1)  -->  'R'
		AND e.nphase >= @nphase_fin
		and e.ymov <  @ayear-1
--		and e.codefin = '1310000'
	GROUP BY e.nphase,my.idfin,e.codefin

-- select * from #totresiniziali
INSERT INTO #budget
(
	idfin,
	codefin,
	code1, order1,code2,order2,code3,order3,code4,order4,code5,order5,code6,order6,
	codeupb,idupb, upb,
	upbprintingorder,
	initialprevision,
	previousprevision,
	secondaryprevision,
	previoussecondaryprev,
	currentarrears,
	previousarrears,
	nlevel
)
SELECT
	f6.idfin, f6.codefin,
	f1.codefin, f1.printingorder,
	f2.codefin, f2.printingorder,
	f3.codefin, f3.printingorder,
	f4.codefin, f4.printingorder,
	f5.codefin, f5.printingorder,
	f6.codefin, f6.printingorder,
	upb.codeupb,
	upb.idupb,
	upb.title,
	upb.printingorder,
	ISNULL(finyear.prevision,0), 
	ISNULL(finyear.previousprevision,0), 
	ISNULL(finyear.secondaryprev,0) ,
	ISNULL(finyear.previoussecondaryprev,0) ,
	ISNULL(finyear.currentarrears,0),
	ISNULL(finyear.previousarrears,0),
	f6.nlevel 
FROM fin f6
CROSS JOIN upb 
JOIN finlevel fl
	ON f6.nlevel = fl.nlevel AND  f6.ayear = fl.ayear
LEFT OUTER JOIN finyear
	ON finyear.idfin = f6.idfin
	AND finyear.idupb = upb.idupb
LEFT OUTER JOIN fin f5
	ON f5.idfin = f6.paridfin
LEFT OUTER JOIN fin f4
	ON f4.idfin = f5.paridfin
LEFT OUTER JOIN fin f3
	ON f3.idfin = f4.paridfin
LEFT JOIN fin f2
	ON f2.idfin = f3.paridfin
LEFT OUTER JOIN fin f1
	ON f1.idfin = f2.paridfin
WHERE f6.ayear = @ayear
	AND (upb.idupb LIKE @idupb)	
	AND ((f6.flag & 1)= @finpart_bit) --AND f6.finpart = @finpart
	AND (f6.nlevel = @levelusable
		OR (f6.nlevel < @levelusable
		AND EXISTS 
		(SELECT * FROM finlast WHERE finlast.idfin = f6.idfin)
		AND (fl.flag&2)<>0
		)

		)
	AND (@infoadvance = 'N' OR @infoadvance = 'B' OR f6.idfin <> @idfinincomesurplus )

/*
	AND (upb.idupb LIKE @idupb)	
	AND ((f6.flag & 1)= @finpart_bit) --AND f6.finpart = @finpart
	AND (f6.nlevel = @levelusable)
*/
DECLARE @lencod_lev1 int
SELECT @lencod_lev1 = flag / 256 FROM finlevel WHERE ayear = @ayear AND nlevel = 1
DECLARE @startpos1 int
SELECT @startpos1 = 1
DECLARE @lencod_lev2 int
SELECT @lencod_lev2 = flag / 256 FROM finlevel WHERE ayear = @ayear AND nlevel = 2
DECLARE @startpos2 int
SELECT @startpos2 = @startpos1 + @lencod_lev1
DECLARE @lencod_lev3 int
SELECT @lencod_lev3 = flag / 256 FROM finlevel WHERE ayear = @ayear AND nlevel = 3
DECLARE @startpos3 int
SELECT @startpos3 = @startpos2 + @lencod_lev2
DECLARE @lencod_lev4 int
SELECT @lencod_lev4 = flag / 256 FROM finlevel WHERE ayear = @ayear AND nlevel = 4
DECLARE @startpos4 int
SELECT @startpos4 = @startpos3 + @lencod_lev3
DECLARE @lencod_lev5 int 
SELECT @lencod_lev5 = flag / 256 FROM finlevel WHERE ayear = @ayear AND nlevel = 5
DECLARE @startpos5 int 
SELECT @startpos5 = @startpos4 + @lencod_lev4
DECLARE @lencod_lev6 int 
SELECT @lencod_lev6 = flag / 256 FROM finlevel WHERE ayear = @ayear AND nlevel = 6
DECLARE @startpos6 int 
SELECT @startpos6 = @startpos5 + @lencod_lev5

UPDATE #budget SET code1 = code2, code2 = code3, code3 = code4, code4 = code5, code5 = code6, code6 = NULL WHERE code1 IS NULL
UPDATE #budget SET code1 = code2, code2 = code3, code3 = code4, code4 = code5, code5 = code6, code6 = NULL WHERE code1 IS NULL
UPDATE #budget SET code1 = code2, code2 = code3, code3 = code4, code4 = code5, code5 = code6, code6 = NULL WHERE code1 IS NULL
UPDATE #budget SET code1 = code2, code2 = code3, code3 = code4, code4 = code5, code5 = code6, code6 = NULL WHERE code1 IS NULL
UPDATE #budget SET code1 = code2, code2 = code3, code3 = code4, code4 = code5, code5 = code6, code6 = NULL WHERE code1 IS NULL

UPDATE #budget SET code1 = SUBSTRING(code1, @startpos1, @lencod_lev1)
UPDATE #budget SET code2 = SUBSTRING(code2, @startpos2, @lencod_lev2)
UPDATE #budget SET code3 = SUBSTRING(code3, @startpos3, @lencod_lev3)
UPDATE #budget SET code4 = SUBSTRING(code4, @startpos4, @lencod_lev4)
UPDATE #budget SET code5 = SUBSTRING(code5, @startpos5, @lencod_lev5)
UPDATE #budget SET code6 = SUBSTRING(code6, @startpos6, @lencod_lev6)

UPDATE #budget SET order1 = order2, order2 = order3, order3 = order4, order4 = order5, order5 = order6, order6 = NULL WHERE order1 IS NULL
UPDATE #budget SET order1 = order2, order2 = order3, order3 = order4, order4 = order5, order5 = order6, order6 = NULL WHERE order1 IS NULL
UPDATE #budget SET order1 = order2, order2 = order3, order3 = order4, order4 = order5, order5 = order6, order6 = NULL WHERE order1 IS NULL
UPDATE #budget SET order1 = order2, order2 = order3, order3 = order4, order4 = order5, order5 = order6, order6 = NULL WHERE order1 IS NULL
UPDATE #budget SET order1 = order2, order2 = order3, order3 = order4, order4 = order5, order5 = order6, order6 = NULL WHERE order1 IS NULL

UPDATE #budget SET order1 = SUBSTRING(order1, @startpos1, @lencod_lev1)
UPDATE #budget SET order2 = SUBSTRING(order2, @startpos2, @lencod_lev2)
UPDATE #budget SET order3 = SUBSTRING(order3, @startpos3, @lencod_lev3)
UPDATE #budget SET order4 = SUBSTRING(order4, @startpos4, @lencod_lev4)
UPDATE #budget SET order5 = SUBSTRING(order5, @startpos5, @lencod_lev5)
UPDATE #budget SET order6 = SUBSTRING(order6, @startpos6, @lencod_lev6)

IF (@showupb <>'S') AND (@idupboriginal <> '%' ) AND (@showchildupb = 'S')
BEGIN
	UPDATE #budget SET  
	upbprintingorder =
		(SELECT TOP 1 upbprintingorder
		FROM #budget
		WHERE idupb = @idupboriginal),
	upb =
		(SELECT TOP 1 upb
		FROM #budget
		WHERE idupb = @idupboriginal),
	idupb = @idupboriginal,
	codeupb =
		(SELECT TOP 1 codeupb
		FROM #budget
		WHERE idupb = @idupboriginal)
END
--select distinct codeupb,idupb from #budget --where idfin = 7298

/*IF (@showupb <>'S') and (@idupboriginal = '%') 
BEGIN
	UPDATE #budget SET  
	upbprintingorder = NULL,
	upb =  NULL,
	idupb = NULL,
	codeupb = NULL
END*/

IF (@suppressifblank = 'S')
BEGIN
	UPDATE #budget SET tosuppress = 'S'
	WHERE  
		(ISNULL(initialprevision,0)= 0 AND 
		ISNULL(previousprevision,0)= 0 AND 
		ISNULL(secondaryprevision,0)= 0 AND
		ISNULL(previoussecondaryprev,0) = 0 AND
		ISNULL(currentarrears,0)= 0 AND
		ISNULL(previousarrears,0)= 0)

	UPDATE #budget SET tosuppress = 'N'
	WHERE  
		NOT(ISNULL(initialprevision,0)= 0 AND 
		ISNULL(previousprevision,0)= 0 AND 
		ISNULL(secondaryprevision,0)= 0 AND
		ISNULL(previoussecondaryprev,0) = 0 AND
		ISNULL(currentarrears,0)= 0 AND
		ISNULL(previousarrears,0)= 0)
END
ELSE
BEGIN
	UPDATE #budget SET tosuppress = 'N'
END

DECLARE @lev_desc1 varchar(50)
SELECT @lev_desc1 = description FROM finlevel WHERE ayear = @ayear AND nlevel = 1
DECLARE @lev_desc2 varchar(50)
SELECT @lev_desc2 = description FROM finlevel WHERE ayear = @ayear AND nlevel = 2
DECLARE @lev_desc3 varchar(50)
SELECT @lev_desc3 = description FROM finlevel WHERE ayear = @ayear AND nlevel = 3
DECLARE @lev_desc4 varchar(50)
SELECT @lev_desc4 = description FROM finlevel WHERE ayear = @ayear AND nlevel = 4
DECLARE @lev_desc5 varchar(50)
SELECT @lev_desc5 = description FROM finlevel WHERE ayear = @ayear AND nlevel = 5
DECLARE @lev_desc6 varchar(50)
SELECT @lev_desc6 = description FROM finlevel WHERE ayear = @ayear AND nlevel = 6

--- qui seconda parte

/* 
SELECT F.IDFIN, S.SORTCODE,* FROM fin f
JOIN finsorting fs
ON fs.idfin = f.idfin
--and fs.idsorkind ='CL_FUNZ'
JOIN sorting s
ON s.idsor = fs.idsor
JOIN sortingkind k
ON s.idsorkind = k.idsorkind
and k.codesorkind ='CL_FUNZ'
AND AYEAR = 2007
*/
UPDATE #budget SET ayear = @ayear

insert into #budgetFONDI 
select distinct	idfin,	codefin ,'',
	'0'  ,'0' ,'' ,0 ,
	sum(isnull(initialprevision, 0.0)),
	sum(isnull(previousprevision ,0.0)),
	sum(isnull(secondaryprevision,0.0)),
	sum(isnull(previoussecondaryprev ,0.0)),
	sum(isnull(currentarrears ,0.0)),
	sum(isnull(previousarrears ,0.0)),
	'' ,0 ,code1 ,order1 ,code2 ,order2 ,
	code3 ,	desc3 ,	order3 ,
	code4 ,	desc4 ,	order4 ,
	code5 ,	desc5 ,	order5 ,
	code6 ,	desc6 ,	order6,
	ayear 
from #budget --
--where codeupb NOT IN ('ACCADEMIA', 'ACC') --and len (idupb) = 12
GROUP BY idfin,	codefin ,
	
	code1 ,order1 ,code2 ,order2 ,
	code3 ,	desc3 ,	order3 ,
	code4 ,	desc4 ,	order4 ,
	code5 ,	desc5 ,	order5 ,
	code6 ,	desc6 ,	order6,
	ayear 
DElete #budget
INSERT INTO #budget
select * from #budgetFONDI-- where codeupb NOT IN ('ACCADEMIA', 'ACC')

-- select distinct * from #budgetFONDI

/*
select * from #budget
JOIN assoc_bilancio_UPB_DEF a
ON  #budget.idfin = a.idfin
-- AND #budget.idman = a.iman
where a.upb = @upb
order by a.idfin
select * from finyearview where idfin > 7298
select * from #budget where idfin = 7298
*/
-- select * from #decisionale
IF @finpart= 'S'
BEGIN
		insert into #decisionale
		SELECT  upb=a.upb
			,decoupb=rtrim(ltrim(a.title))
,''
--			classif
			,code1		
			,f1.title AS desc1
			,@lev_desc1 AS descliv1
			,order1	
										
			,code2											
			,f2.title AS desc2
			,@lev_desc2 AS descliv2
			,order2											

			,code3
			,f3.title AS desc3
			,@lev_desc3 AS descliv3
			,order3											
					
			,code4
			,f4.title AS desc4
			,@lev_desc4 AS descliv4
			,order4
				
			,code5
			,f5.title AS desc5
			,@lev_desc5 AS descliv5
			,order5

			,code6
			,f6.title AS desc6
			,@lev_desc6 AS descliv6
			,order6

			,isnull(initialprevision, 0.0)
			,isnull(previousprevision, 0.0)
			,isnull(secondaryprevision, 0.0)
			,previoussecondaryprev = isnull(previoussecondaryprev, 0.0)

			,currentarrears = ISNULL(currentarrears, 0.0)
			,previousarrears = ISNULL(previousarrears, 0.0)
,'',''
			,@startfloatfund 
			,0						
			,0					
			,0					
			,prevdefcassa = isnull(previoussecondaryprev, 0.0)
		FROM #budget
	
		JOIN assoc_bilancio_UPB_DEF a
		ON  #budget.idfin = a.idfin
		AND  a.ayear = @ayear

		LEFT OUTER JOIN #totresiniziali
		on #budget.idfin= #totresiniziali.idbilancio

		LEFT OUTER JOIN residuipresuntixidbilancio
		ON #budget.codefin= residuipresuntixidbilancio.vocebilancio

		LEFT OUTER JOIN finlink flk1
		ON flk1.idchild = #budget.idfin AND flk1.nlevel = 1
		LEFT OUTER JOIN fin f1
		ON flk1.idparent = f1.idfin 
		LEFT OUTER JOIN finlink flk2
		ON flk2.idchild = #budget.idfin AND flk2.nlevel = 2
		LEFT OUTER JOIN fin f2
		ON flk2.idparent = f2.idfin 
		LEFT OUTER JOIN finlink flk3
		ON flk3.idchild = #budget.idfin AND flk3.nlevel = 3
		LEFT OUTER JOIN fin f3

		ON flk3.idparent = f3.idfin 
		LEFT OUTER JOIN finlink flk4
			ON flk4.idchild = #budget.idfin AND flk4.nlevel = 4
		LEFT OUTER JOIN fin f4
			ON flk4.idparent = f4.idfin 
	
		LEFT OUTER JOIN finlink flk5
			ON flk5.idchild = #budget.idfin AND flk5.nlevel = 5
		LEFT OUTER JOIN fin f5
			ON flk5.idparent = f5.idfin 
		LEFT OUTER JOIN finlink flk6
			ON flk6.idchild = #budget.idfin AND flk5.nlevel = 6
		LEFT OUTER JOIN fin f6
			ON flk6.idparent = f6.idfin 
--		WHERE a.UPB = @upb 
		--AND ayear = @ayear


		UPDATE #decisionale			
		SET cassa_competenza = @fin_kind--(SELECT distinct #budget.cassa_competenza FROM #budget)
		,mostraavanzo = 'S'--(SELECT distinct #budget.mostraavanzo FROM #budget)
		,avanzoamminpres = @supposed_aa_jan01--(SELECT distinct #budget.avanzoamminpres FROM #budget)
		,avanzoamminpresprec = @aa_prec--(SELECT distinct #budget.avanzoamminpresprec FROM #budget)
		,fondocassapresprec = @ff_prec--ELECT distinct #budget.fondocassapresprec FROM #budget)
		, Fondocassapres	= @startfloatfund  
END
ELSE
BEGIN
	 		insert into #decisionale
			SELECT  ''
				,''
				,''
--				,classif
				,code1											

			,f1.title AS desc1
			,@lev_desc1 AS descliv1
			,order1	
										
			,code2											
			,f2.title AS desc2
			,@lev_desc2 AS descliv2
			,order2											

			,code3
			,f3.title AS desc3
			,@lev_desc3 AS descliv3
			,order3											
							
			,code4
			,f4.title AS desc4
			,@lev_desc4 AS descliv4
			,order4									

			,code5
			,f5.title AS desc5
			,@lev_desc5 AS descliv5
			,order5									

			,code6
			,f6.title AS desc6
			,@lev_desc6 AS descliv6
			,order6		
					
			,isnull(initialprevision, 0.0)
			,isnull(previousprevision, 0.0)
			,isnull(secondaryprevision, 0.0)
			,previoussecondaryprev = isnull(previoussecondaryprev, 0.0)
-- NEL 2005 è TOT CAMBIATO IL BILANCIO X CUI I RESIDUI ATTIVIE PASSIVI VERRANNO MESSI 
-- NEL CAMPO currentarrears E previousarrears 
			,currentarrears = ISNULL(currentarrears, 0.0)
			,previousarrears = ISNULL(previousarrears, 0.0)
,'',''
			,fondocassapres	= @supposed_ff_jan01 
			,avanzoamminpres	=@supposed_aa_jan01					
			,fondocassa0101=@startfloatfund 
			,0
			
			,prevdefcassa = isnull(previoussecondaryprev, 0.0)
			FROM #budget

		LEFT OUTER JOIN residuipresuntixidbilancio
		ON #budget.codefin= residuipresuntixidbilancio.vocebilancio
	LEFT OUTER JOIN finlink flk1
		ON flk1.idchild = #budget.idfin AND flk1.nlevel = 1
	LEFT OUTER JOIN fin f1
		ON flk1.idparent = f1.idfin 
	LEFT OUTER JOIN finlink flk2
		ON flk2.idchild = #budget.idfin AND flk2.nlevel = 2
	LEFT OUTER JOIN fin f2
		ON flk2.idparent = f2.idfin 
	LEFT OUTER JOIN finlink flk3
		ON flk3.idchild = #budget.idfin AND flk3.nlevel = 3
	LEFT OUTER JOIN fin f3

		ON flk3.idparent = f3.idfin 
	LEFT OUTER JOIN finlink flk4
		ON flk4.idchild = #budget.idfin AND flk4.nlevel = 4
	LEFT OUTER JOIN fin f4
		ON flk4.idparent = f4.idfin 

	LEFT OUTER JOIN finlink flk5
		ON flk5.idchild = #budget.idfin AND flk5.nlevel = 5
	LEFT OUTER JOIN fin f5
		ON flk5.idparent = f5.idfin 
	LEFT OUTER JOIN finlink flk6
		ON flk6.idchild = #budget.idfin AND flk5.nlevel = 6
	LEFT OUTER JOIN fin f6
		ON flk6.idparent = f6.idfin 

		LEFT OUTER JOIN #totresiniziali
		on #budget.idfin= #totresiniziali.idbilancio

		WHERE code1 <>0			

		UPDATE #decisionale			
		SET cassa_competenza = @fin_kind--(SELECT distinct #budget.cassa_competenza FROM #budget)
		,mostraavanzo = 'S'--(SELECT distinct #budget.mostraavanzo FROM #budget)
		,avanzoamminpres = @supposed_aa_jan01--(SELECT distinct #budget.avanzoamminpres FROM #budget)
		,avanzoamminpresprec = @aa_prec--(SELECT distinct #budget.avanzoamminpresprec FROM #budget)
		,fondocassapresprec = @ff_prec--(SELECT distinct #budget.fondocassapresprec FROM #budget)
		, Fondocassapres	= @startfloatfund

END
delete RIEP_PREVENTIVO
IF @finpart= 'S'
	insert into RIEP_PREVENTIVO
	SELECT DISTINCT   
	upb 
	,decode_upb 
	,code1	
	,desc1	
	,descliv1			
	,order1				
	,code2											
	,desc2												
	,descliv2										
	,order2											
	
	,code3
	,desc3 = desc3 
	,descliv3 = descliv3
	,order3			
,initialprevision= SUM(ISNULL(initialprevision	,0.0))
,previousprevision=SUM(ISNULL(previousprevision	,0.0))
,secondaryprevision=SUM(ISNULL(secondaryprevision,0.0))
,previoussecondaryprev= SUM(ISNULL(previoussecondaryprev ,0.0))
,currentarrears=SUM(ISNULL(currentarrears,0.0))			
,previousarrears=SUM(ISNULL(previousarrears,0.0))					
,fondocassapres=SUM(ISNULL(fondocassapres,0.0))					
,avanzoamminpres=SUM(ISNULL(avanzoamminpres,0.0))						
,fondocassapresprec=SUM(ISNULL(fondocassapresprec,0.0))					
,avanzoamminpresprec=SUM(ISNULL(avanzoamminpresprec,0.0))				
,prevdefcassa=SUM(ISNULL(prevdefcassa ,0.0))
 FROM #decisionale
GROUP BY upb
	,decode_upb 
	,code1	
			,desc1											
			,descliv1										
			,order1	
			,code2											
			,desc2												
			,descliv2										
			,order2											
			,code3											
			,desc3												
			,descliv3										
			,order3	

		ORDER BY upb
			,code1											
			,desc1											
--			,descliv1										
			,order1	
			,code2											
			,desc2												
--			,descliv2										
			,order2											
			,code3											
			,desc3												
			--,descliv3										
			,order3	


ELSE
insert into RIEP_PREVENTIVO
SELECT DISTINCT  upb=''
,decoupb=''
,code1	
,desc1	
,descliv1			
,order1				

,code2											
,desc2												
,descliv2										
,order2											

,code3				
,desc3		
,descliv3 
,order3			

,SUM(ISNULL(initialprevision,0.0))
,SUM(ISNULL(previousprevision,0.0))
,SUM(ISNULL(secondaryprevision,0.0))	
,SUM(ISNULL(previoussecondaryprev,0.0))		
,SUM(ISNULL(currentarrears,0.0))				
,SUM(ISNULL(previousarrears,0.0))					
,SUM(ISNULL(fondocassapres,0.0))					
,SUM(ISNULL(avanzoamminpres,0.0))						
,SUM(ISNULL(fondocassapresprec,0.0))			
,SUM(ISNULL(avanzoamminpresprec,0.0))			
,SUM(ISNULL(prevdefcassa ,0.0))
 FROM #decisionale
GROUP BY upb
			,code1											
			,desc1											
			,descliv1										
			,order1	
			,code2											
			,desc2												
			,descliv2										
			,order2											
			,code3											
			,desc3												
			,descliv3										
			,order3	
ORDER BY 
code1											
,desc1											
--,descliv1										
,order1											
,code2											
,desc2												
--,descliv2										
,order2											
,code3											
,desc3												
--,descliv3										
,order3	

IF @finpart= 'S'
	SELECT DISTINCT   
	upb 
	,decoupb=decode_upb 
	,code1	
	,desc1	
	,descliv1			
	,order1				
				,code2											
				,desc2												
				,descliv2										
				,order2											
	
	,code3
	,desc3 = desc3 
	,descliv3 = descliv3
	,order3			

			,code4											
			,desc4												
			,descliv4										
			,order4							

			,code5											
			,desc5												
			,descliv5										
			,order5							
				
			,code6											
			,desc6												
			,descliv6										
			,order6							

,initialprevision	
,previousprevision			
,secondaryprevision				
,previoussecondaryprev				
,currentarrears						
,previousarrears						
,fondocassapres							
,avanzoamminpres							
,fondocassapresprec					
,avanzoamminpresprec					
,prevdefcassa 
 FROM #decisionale
where upb = @upb
		ORDER BY upb
			,code1											
			,desc1											
--			,descliv1										
			,order1	
			,code2											
			,desc2												
--			,descliv2										
			,order2											
			,code3											
			,desc3												
			--,descliv3										
			,order3	
			,order4
			,order5							
			,order6							

ELSE
SELECT DISTINCT  upb=''
,decoupb=''
,code1	
,desc1	
,descliv1			
,order1				

,code2											
,desc2												
,descliv2										
,order2											

,code3				
,desc3		= desc3 
,descliv3 = descliv3 
,order3			

			,code4											
			,desc4												
			,descliv4										
			,order4							

			,code5											
			,desc5												
			,descliv5										
			,order5							
				
			,code6											
			,desc6												
			,descliv6										

			,order6							

,initialprevision	
,previousprevision			
,secondaryprevision				
,previoussecondaryprev				
,currentarrears						
,previousarrears						
,fondocassapres		=  @supposed_ff_jan01 
,avanzoamminpres	= @supposed_aa_jan01 --@supposed_aa_jan01					
,fondocassapresprec					
,avanzoamminpresprec					
,prevdefcassa 
 FROM #decisionale
		ORDER BY 
			code1											
			,desc1											

			--,descliv1										
			,order1											

			,code2											
			,desc2												
			--,descliv2										
			,order2											

			,code3											
			,desc3												
			--,descliv3										
			,order3	
			,order4
			,order5							
			,order6							
END






GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

