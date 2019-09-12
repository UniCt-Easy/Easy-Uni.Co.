if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_bilprevisione_bozza]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_bilprevisione_bozza]
GO
--setuser 'amm'

CREATE  PROCEDURE [rpt_bilprevisione_bozza]
	@ayear 			int,
	@finpart 		char(1),
	@levelusable 		tinyint,
	@idupb			varchar(36),
	@showupb 		char(1),
	@showchildupb 		char(1),
	@suppressifblank 	char(1),
	@nprevfin 		int
AS BEGIN
/* Versione 1.0.2 del 16/11/2007 ultima modifica: Pino */
CREATE TABLE #budget
(
	idfin int,
	code1 varchar(50),printorder1 varchar(50),
	code2 varchar(50),printorder2 varchar(50),
	code3 varchar(50),printorder3 varchar(50),
	code4 varchar(50),printorder4 varchar(50),
	code5 varchar(50),printorder5 varchar(50),
	code6 varchar(50),printorder6 varchar(50),
	prevision decimal(19,2),
	previousprevision decimal(19,2),
	secondaryprev decimal(19,2),
	previoussecondaryprev decimal(19,2),
	currentarrears decimal(19,2),
	-- NO previousarrears decimal(19,2),
	codeupb varchar(50),
	idupb varchar(36),
	upb varchar(150),
	upbprintingorder varchar(50),
	tosuppress char(1),
	nlevel tinyint,
	supposed_ff decimal(19,2),
	supposed_aa decimal(19,2),
	supposed_ff_prec decimal(19,2),
	supposed_aa_prec decimal(19,2)
)

DECLARE @idupboriginal 		varchar(36)
	
SET 	@idupboriginal= @idupb
IF 	(@showchildupb = 'S') SET @idupb=@idupb+'%' 
	

DECLARE	@finpart_bit  tinyint  -- Parte del bilancio (Entrata / Spesa)
if @finpart='E' set @finpart_bit = 0
if @finpart='S' set @finpart_bit = 1

DECLARE @MostraTutteVoci char(1)
SELECT @MostraTutteVoci = isnull(paramvalue,'N') 
FROM generalreportparameter WHERE idparam = 'MostraTutteVoci'
	
DECLARE @length1 int
DECLARE @length2 int
DECLARE @length3 int
DECLARE @length4 int
DECLARE @length5 int
DECLARE @length6 int
SELECT 	@length1 = flag / 256 FROM finlevel WHERE ayear = @ayear + 1 	AND nlevel = 1
SELECT 	@length2 = flag / 256 FROM finlevel WHERE ayear = @ayear + 1	AND nlevel = 2
SELECT 	@length3 = flag / 256 FROM finlevel WHERE ayear = @ayear + 1	AND nlevel = 3
SELECT 	@length4 = flag / 256 FROM finlevel WHERE ayear = @ayear + 1	AND nlevel = 4
SELECT 	@length5 = flag / 256 FROM finlevel WHERE ayear = @ayear + 1	AND nlevel = 5
SELECT 	@length6 = flag / 256 FROM finlevel WHERE ayear = @ayear + 1	AND nlevel = 6
DECLARE @pos1 int
DECLARE @pos2 int
DECLARE @pos3 int
DECLARE @pos4 int
DECLARE @pos5 int
DECLARE @pos6 int

SET @pos1 = 1
SET @pos2 = @pos1 + @length1
SET @pos3 = @pos2 + @length2
SET @pos4 = @pos3 + @length3
SET @pos5 = @pos4 + @length4
SET @pos6 = @pos5 + @length5
	
DECLARE @infoadvance char(1)
SELECT 	@infoadvance = paramvalue	
FROM    generalreportparameter
WHERE   idparam = 'MostraAvanzo'

DECLARE @minlevelusable  tinyint
SELECT 	@minlevelusable = min(nlevel)
FROM    finlevel
WHERE   ayear = @ayear 
	AND (flag&2)<>0

IF(@levelusable < @minlevelusable)
begin
	SET @levelusable = @minlevelusable
end

DECLARE @fin_kind tinyint

SELECT  @fin_kind = fin_kind
	FROM 	config 
	WHERE 	ayear = @ayear
DECLARE @nextayear 	int
set @nextayear = @ayear + 1

--------------------------------------------------------------------------------------------------------------------------------
-- Attualmente in prevfindetail i capitoli articolati non vengono inseriti, per questi vengono inseriti solo gli articoli.
-- Quindi, usiamo #prevfindetail che conterrà prevfindetail + i capitoli degli articoli presenti in prevfindetail.
-- Totalizziamo questi capitoli.
-- In questa tabella saranno inseriti SOLO i valori di 'previousprevision' e 'previoussecondaryprev', perchè questi saranno letti da
-- #prevfindetail appartenente alla query esterna. Gli altri valori saranno letti da prevfindetail del DB facendo i SUM con le sub-query.
CREATE TABLE #prevfindetail
(
	idfin int, 
        idupb varchar(36),
	previousprevision decimal(19,2),
	previoussecondaryprev decimal(19,2),
)

INSERT INTO #prevfindetail
(
	idfin,idupb,
	previousprevision,
	previoussecondaryprev
)
SELECT 
	idfin,idupb,
	previousprevision,
	previoussecondaryprev
FROM prevfindetail 
WHERE  nprevfin = @nprevfin  AND ayear = @ayear

IF(@levelusable = @minlevelusable)
BEGIN
--se sto facendo la stampa per capitolo, inserisco nella #tab anche i capitoli articolati perchè NON sono
-- presenti in prevfindetail del DB. Questo vale anche se la stampa è per categoria perchè se così fosse
-- @levelusable sarà stato modificato da 2 a 3 da una istruzione precedente.
        INSERT INTO #prevfindetail
        (
		idfin,
		idupb,
		previousprevision,previoussecondaryprev
        )
        SELECT DISTINCT 
        	FLK.idparent,
                idupb,
        		(SELECT ISNULL(SUM(FiY.previousprevision), 0.0)
					FROM fin Fi
					JOIN finlink FLK
						ON Fi.idfin = FLK.idchild 
					JOIN finlast 
						ON finlast.idfin = FLK.idchild 
					JOIN prevfindetail FiY
						ON FiY.idfin = FLK.idchild 
						AND FiY.nprevfin = @nprevfin 
						AND FiY.ayear = @ayear 
					WHERE (Fi.flag & 1)= @finpart_bit
						AND ((FI.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
						AND FiY.idupb = prevfindetail.idupb
						AND FLK.idparent = prevfindetail.idfin 
						),
				(SELECT ISNULL(SUM(FiY.previoussecondaryprev), 0.0)
					FROM fin Fi
					JOIN finlink FLK
						ON Fi.idfin = FLK.idchild 
					JOIN finlast 
						ON finlast.idfin = FLK.idchild 
					JOIN prevfindetail FiY
						ON FiY.idfin = FLK.idchild 
						AND FiY.nprevfin = @nprevfin 
						AND FiY.ayear = @ayear 
					WHERE (Fi.flag & 1)= @finpart_bit
						AND ((FI.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
						AND FiY.idupb = prevfindetail.idupb
						AND FLK.idparent = prevfindetail.idfin 
						)
        FROM prevfindetail 
        join finlink FLK
                ON prevfindetail.idfin = FLK.idchild 
                AND FLK.nlevel = @levelusable
        WHERE nprevfin = @nprevfin  AND ayear = @ayear
        	AND NOT EXISTS (SELECT *
        		FROM #prevfindetail P2
        		WHERE P2.idupb = prevfindetail.idupb AND P2.idfin = FLK.idparent)
END
--------------------------------------------------------------------------------------------------------------------------------

IF (@suppressifblank <> 'S')
BEGIN
	INSERT INTO #budget
	(
		idfin,
		code1,printorder1,
		code2,printorder2,
		code3,printorder3,
		code4,printorder4,
		code5,printorder5,
		code6,printorder6,
		codeupb,
		idupb,
		upb,
		upbprintingorder,
		prevision,
		previousprevision,
		secondaryprev,
		previoussecondaryprev,
		currentarrears,
		nlevel
	)
	SELECT 	b6.idfin, 
		b1.codefin,b1.printingorder,  
		b2.codefin,b2.printingorder,
		b3.codefin,b3.printingorder,  
		b4.codefin,b4.printingorder,  
		b5.codefin,b5.printingorder,  
		b6.codefin,b6.printingorder,  
		upb.codeupb,
		upb.idupb,
		upb.title,
		upb.printingorder,	
		(SELECT 
			case @fin_kind
				when 2 then ISNULL(SUM(FiY.cash), 0.0)
				else ISNULL(SUM(FiY.competency), 0.0)
			end
			FROM fin Fi
			JOIN finlink FLK
				ON Fi.idfin = FLK.idchild 
			JOIN finlast 
				ON finlast.idfin = FLK.idchild 
			JOIN prevfindetail FiY
				ON FiY.idfin = FLK.idchild 
				AND FiY.nprevfin = @nprevfin -- P.nprevfin 
				AND FiY.ayear = @ayear -- P.ayear
			WHERE (Fi.flag & 1)= @finpart_bit
				AND ((FI.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
				AND FiY.idupb = upb.idupb
				AND FLK.idparent = b6.idfin 
				),
	
		ISNULL(P.previousprevision,0),
		(SELECT 
			ISNULL(SUM(FiY.cash), 0.0)
			FROM fin Fi
			JOIN finlink FLK
				ON Fi.idfin = FLK.idchild 
			JOIN finlast 
				ON finlast.idfin = FLK.idchild 
			JOIN prevfindetail FiY
				ON FiY.idfin = FLK.idchild 
				AND FiY.nprevfin = @nprevfin -- P.nprevfin 
				AND FiY.ayear = @ayear -- P.ayear
			WHERE (Fi.flag & 1)= @finpart_bit
				AND ((FI.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
				AND FiY.idupb = upb.idupb
				AND FLK.idparent = b6.idfin 
				),
	
		ISNULL(P.previoussecondaryprev,0),
		(SELECT 
			CASE
				WHEN (@finpart= 'E') THEN ISNULL(SUM(FiY.supposedrevenue), 0.0)
				ELSE ISNULL(SUM(FiY.supposedexpenditure), 0.0)
			END
		FROM fin Fi
		JOIN finlink FLK
			ON Fi.idfin = FLK.idchild 
		JOIN finlast 
			ON finlast.idfin = FLK.idchild 
		JOIN prevfindetail FiY
			ON FiY.idfin = FLK.idchild 
			AND FiY.nprevfin = @nprevfin -- P.nprevfin 
			AND FiY.ayear = @ayear -- P.ayear
		WHERE (Fi.flag & 1)= @finpart_bit
			AND ((FI.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
			AND FiY.idupb = upb.idupb
			AND FLK.idparent = b6.idfin 
			),
	
		b6.nlevel
	FROM  fin b6 cross join upb
	JOIN finlevel fl
		ON b6.nlevel = fl.nlevel AND  b6.ayear = fl.ayear
	left outer join #prevfindetail P	
		on P.idfin = b6.idfin
		and  P.idupb = upb.idupb
--                 AND P.nprevfin = @nprevfin 
--                 AND P.ayear = @ayear 
	left outer join fin b5 
		ON b5.idfin = b6.paridfin
	left outer join fin b4 
		ON b4.idfin = b5.paridfin
	left outer join fin b3 
		ON b3.idfin = b4.paridfin
	left outer join fin b2 
		ON b2.idfin = b3.paridfin
	left outer join fin b1 
		ON b1.idfin = b2.paridfin
	WHERE (upb.idupb like @idupb)
		AND b6.ayear = @nextayear
		AND ((b6.flag & 1)= @finpart_bit) 
		AND (b6.nlevel = @levelusable
		OR 
		  (b6.nlevel < @levelusable
		AND EXISTS
			(SELECT * FROM finlast WHERE finlast.idfin = b6.idfin)
			AND (fl.flag&2)<>0
			))
		AND (@infoadvance = 'N' or @infoadvance = 'B' OR (B6.flag & 16 =0))
END 
Else
BEGIN
	INSERT INTO #budget
	(
		idfin,
		code1,printorder1,
		code2,printorder2,
		code3,printorder3,
		code4,printorder4,
		code5,printorder5,
		code6,printorder6,
		codeupb,
		idupb,
		upb,
		upbprintingorder,
		prevision,
		previousprevision,
		secondaryprev,
		previoussecondaryprev,
		currentarrears,
		nlevel
	)
	SELECT 	b6.idfin, 
		b1.codefin,b1.printingorder,  
		b2.codefin,b2.printingorder,
		b3.codefin,b3.printingorder,  
		b4.codefin,b4.printingorder,  
		b5.codefin,b5.printingorder,  
		b6.codefin,b6.printingorder,  
		upb.codeupb,
		upb.idupb,
		upb.title,
		upb.printingorder,	
		(SELECT 
			case @fin_kind
				when 2 then ISNULL(SUM(FiY.cash), 0.0)
				else ISNULL(SUM(FiY.competency), 0.0)
			end
			FROM fin Fi
			JOIN finlink FLK
				ON Fi.idfin = FLK.idchild 
			JOIN finlast 
				ON finlast.idfin = FLK.idchild 
			JOIN prevfindetail FiY
				ON FiY.idfin = FLK.idchild 
				AND FiY.nprevfin = @nprevfin -- P.nprevfin 
				AND FiY.ayear = @ayear -- P.ayear
			WHERE (Fi.flag & 1)= @finpart_bit
				AND ((FI.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
				AND FiY.idupb = upb.idupb
				AND FLK.idparent = b6.idfin 
				),
	
		ISNULL(P.previousprevision,0),
		(SELECT 
			ISNULL(SUM(FiY.cash), 0.0)
			FROM fin Fi
			JOIN finlink FLK
				ON Fi.idfin = FLK.idchild 
			JOIN finlast 
				ON finlast.idfin = FLK.idchild 
			JOIN prevfindetail FiY
				ON FiY.idfin = FLK.idchild 
				AND FiY.nprevfin = @nprevfin -- P.nprevfin  
				AND FiY.ayear = @ayear -- P.ayear
			WHERE (Fi.flag & 1)= @finpart_bit
				AND ((FI.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
				AND FiY.idupb = upb.idupb
				AND FLK.idparent = b6.idfin 
				),
	
		ISNULL(P.previoussecondaryprev,0),
		(SELECT 
			CASE
				WHEN (@finpart= 'E') THEN ISNULL(SUM(FiY.supposedrevenue), 0.0)
				ELSE ISNULL(SUM(FiY.supposedexpenditure), 0.0)
			END
		FROM fin Fi
		JOIN finlink FLK
			ON Fi.idfin = FLK.idchild 
		JOIN finlast 
			ON finlast.idfin = FLK.idchild 
		JOIN prevfindetail FiY
			ON FiY.idfin = FLK.idchild 
			AND FiY.nprevfin = @nprevfin -- P.nprevfin  
			AND FiY.ayear = @ayear -- P.ayear
		WHERE (Fi.flag & 1)= @finpart_bit
			AND ((FI.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
			AND FiY.idupb = upb.idupb
			AND FLK.idparent = b6.idfin 
			),
	
		b6.nlevel
	FROM  fin b6 cross join upb
	JOIN finlevel fl
		ON b6.nlevel = fl.nlevel AND  b6.ayear = fl.ayear
	join #prevfindetail P	
		on P.idfin = b6.idfin
		and  P.idupb = upb.idupb
	left outer join fin b5 
		ON b5.idfin = b6.paridfin
	left outer join fin b4 
		ON b4.idfin = b5.paridfin
	left outer join fin b3 
		ON b3.idfin = b4.paridfin
	left outer join fin b2 
		ON b2.idfin = b3.paridfin
	left outer join fin b1 
		ON b1.idfin = b2.paridfin
	WHERE (upb.idupb like @idupb)
		AND ((b6.flag & 1)= @finpart_bit) 
		AND (b6.nlevel = @levelusable
		OR 
		  (b6.nlevel < @levelusable
		AND EXISTS
			(SELECT * FROM finlast WHERE finlast.idfin = b6.idfin)
			AND (fl.flag&2)<>0
			))
		AND (@infoadvance = 'N' or @infoadvance = 'B' OR (B6.flag & 16 =0))
--                AND P.nprevfin = @nprevfin 
--                AND P.ayear = @ayear
--select '2',* from #budget

END
-- Questi due valori non saranno + calcolati, ma saranno letti da prevfindetail
-- NELLA SELECT PRINCIPALE
		
UPDATE #budget SET code1 = code2, code2=code3, code3=code4, code4=code5, code5=code6, code6=NULL where code1 is null
UPDATE #budget SET code1 = code2, code2=code3, code3=code4, code4=code5, code5=code6, code6=NULL where code1 is null
UPDATE #budget SET code1 = code2, code2=code3, code3=code4, code4=code5, code5=code6, code6=NULL where code1 is null
UPDATE #budget SET code1 = code2, code2=code3, code3=code4, code4=code5, code5=code6, code6=NULL where code1 is null
UPDATE #budget SET code1 = code2, code2=code3, code3=code4, code4=code5, code5=code6, code6=NULL where code1 is null
UPDATE #budget SET code1 = substring(code1, @pos1, @length1)
UPDATE #budget SET code2 = substring(code2, @pos2, @length2)
UPDATE #budget SET code3 = substring(code3, @pos3, @length3)
UPDATE #budget SET code4 = substring(code4, @pos4, @length4)
UPDATE #budget SET code5 = substring(code5, @pos5, @length5)
UPDATE #budget SET code6 = substring(code6, @pos6, @length6)
UPDATE #budget SET printorder1=printorder2, printorder2=printorder3, printorder3=printorder4, printorder4=printorder5, printorder5=printorder6, printorder6=NULL where printorder1 is null
UPDATE #budget SET printorder1=printorder2, printorder2=printorder3, printorder3=printorder4, printorder4=printorder5, printorder5=printorder6, printorder6=NULL where printorder1 is null
UPDATE #budget SET printorder1=printorder2, printorder2=printorder3, printorder3=printorder4, printorder4=printorder5, printorder5=printorder6, printorder6=NULL where printorder1 is null
UPDATE #budget SET printorder1=printorder2, printorder2=printorder3, printorder3=printorder4, printorder4=printorder5, printorder5=printorder6, printorder6=NULL where printorder1 is null
UPDATE #budget SET printorder1=printorder2, printorder2=printorder3, printorder3=printorder4, printorder4=printorder5, printorder5=printorder6, printorder6=NULL where printorder1 is null
UPDATE #budget SET printorder1=substring(printorder1, @pos1, @length1)
UPDATE #budget SET printorder2=substring(printorder2, @pos2, @length2)
UPDATE #budget SET printorder3=substring(printorder3, @pos3, @length3)
UPDATE #budget SET printorder4=substring(printorder4, @pos4, @length4)
UPDATE #budget SET printorder5=substring(printorder5, @pos5, @length5)
UPDATE #budget SET printorder6=substring(printorder6, @pos6, @length6)

declare @descliv1 varchar(50)
declare @descliv2 varchar(50)
declare @descliv3 varchar(50)
declare @descliv4 varchar(50)
declare @descliv5 varchar(50)
declare @descliv6 varchar(50)
select 	@descliv1=description from finlevel where ayear=@ayear and nlevel=1
select 	@descliv2=description from finlevel where ayear=@ayear and nlevel=2
select 	@descliv3=description from finlevel where ayear=@ayear and nlevel=3
select 	@descliv4=description from finlevel where ayear=@ayear and nlevel=4
select 	@descliv5=description from finlevel where ayear=@ayear and nlevel=5
select 	@descliv6=description from finlevel where ayear=@ayear and nlevel=6

/*
 Se N qualora per un capitolo non esistano sott-capitoli con legami con l'upb fondo
 NON verrà visualizzata l'indicazione del Titolo/Categoria/Capitolo
*/

IF(Upper(@MostraTutteVoci)='N' AND @suppressifblank = 'S' )
BEGIN
	DELETE FROM #budget 
	WHERE (ISNULL(prevision,0)= 0 AND 
			ISNULL(previousprevision,0)= 0 AND 
			ISNULL(secondaryprev,0)= 0 AND
			ISNULL(previoussecondaryprev,0) = 0 AND
			ISNULL(currentarrears,0)= 0)
	AND idupb <> '0001'
END

	
IF (@showupb <>'S') AND (@idupboriginal <> '%' ) AND (@showchildupb = 'S')
BEGIN
	UPDATE #budget SET  
		upbprintingorder = (SELECT TOP 1 upbprintingorder
			FROM #budget
			WHERE idupb = @idupboriginal),
		upb = (SELECT TOP 1 upb
			FROM #budget
			WHERE idupb = @idupboriginal),
		idupb = @idupboriginal,
		codeupb =(SELECT TOP 1 codeupb
			FROM #budget	
			WHERE idupb = @idupboriginal)
END
	
IF (@showupb <>'S') and (@idupboriginal = '%') 
BEGIN
	UPDATE #budget SET  
		upbprintingorder = null,
		upb =  null,
		idupb = null,
		codeupb = null
END

IF (@suppressifblank = 'S')
		BEGIN
			UPDATE #budget   SET tosuppress = 'S'
			WHERE  
			(ISNULL(prevision,0)= 0 AND 
			ISNULL(previousprevision,0)= 0 AND 
			ISNULL(secondaryprev,0)= 0 AND
			ISNULL(previoussecondaryprev,0) = 0 AND
			ISNULL(currentarrears,0)= 0)
	
			UPDATE #budget   SET tosuppress = 'N'
			WHERE  
			NOT(ISNULL(prevision,0)= 0 AND 
			ISNULL(previousprevision,0)= 0 AND 
			ISNULL(secondaryprev,0)= 0 AND
			ISNULL(previoussecondaryprev,0) = 0 AND
			-- NO ISNULL(previousarrears,0)= 0 AND
			ISNULL(currentarrears,0)= 0)
		END
	ELSE
		UPDATE #budget   SET tosuppress = 'N'
	
DECLARE @supposed_ff	  decimal(19,2)
DECLARE @supposed_aa	  decimal(19,2)
DECLARE @supposed_ff_prec decimal(19,2)
DECLARE @supposed_aa_prec decimal(19,2)
	
---------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------ QUESTO CALCOLO DEVE ESSERE DEFINITO --------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------------------------------------------------------
-- questa stampa è fatta nell'anno in cui si è eseguito il form di bil.prev. automatico
IF @finpart = 'E'
BEGIN
	SELECT	
		@supposed_ff =
			ISNULL(startfloatfund, 0.0) + ISNULL(proceedstilldate, 0.0) -
			ISNULL(paymentstilldate, 0.0) + ISNULL(proceedstoendofyear, 0.0) -
			ISNULL(paymentstoendofyear, 0.0),
		@supposed_aa =
			ISNULL(startfloatfund, 0.0) + ISNULL(proceedstilldate, 0.0) -
			ISNULL(paymentstilldate, 0.0) + ISNULL(proceedstoendofyear, 0.0) -
			ISNULL(paymentstoendofyear, 0.0) + ISNULL(supposedpreviousrevenue, 0.0) +				
			ISNULL(supposedcurrentrevenue , 0.0) - ISNULL(supposedpreviousexpenditure, 0.0) -
			ISNULL(supposedcurrentexpenditure, 0.0)
		FROM surplus
		WHERE ayear = @ayear 
	SELECT	
		@supposed_ff_prec =
			ISNULL(startfloatfund, 0.0) + ISNULL(competencyproceeds, 0.0) -
			ISNULL(competencypayments, 0.0) + ISNULL(residualproceeds, 0.0) -
			ISNULL(residualpayments, 0.0),
		@supposed_aa_prec =
			ISNULL(startfloatfund, 0.0) + ISNULL(competencyproceeds, 0.0) -
			ISNULL(competencypayments, 0.0) + ISNULL(residualproceeds, 0.0) -
			ISNULL(residualpayments, 0.0) + ISNULL(previousrevenue, 0.0) +				
			ISNULL(currentrevenue , 0.0) - ISNULL(previousexpenditure, 0.0) -
			ISNULL(currentexpenditure, 0.0)
	FROM surplus
	WHERE ayear = @ayear -  1
END

IF ((@showupb <>'S') AND (@idupboriginal <> '%' ) AND (@showchildupb = 'S'))
	OR 
	((@showupb <>'S') and (@idupboriginal = '%'))
BEGIN
	SELECT
		#budget.idfin as 'idfin',
		code1,
		b1.title as 'desc1',
		@descliv1 as 'descliv1',
		printorder1,
		code2,
		b2.title as  'desc2',
		@descliv2 as 'descliv2',
		printorder2,
		code3,
		b3.title as 'desc3',
		@descliv3 as 'descliv3',
		printorder3,
		code4,
		b4.title as 'desc4',
		@descliv4 as  'descliv4',
		printorder4,
		code5,
		b5.title as 'desc5',
		@descliv5 as  'descliv5',
		printorder5,
		code6,
		b6.title as 'desc6',
		@descliv6 as 'descliv6',
		printorder6,
		codeupb,
		idupb,
		upb,
		upbprintingorder,
		#budget.nlevel,
		sum(isnull(prevision,0)) as 'prevision',
		sum(isnull(previousprevision,0)) as 'previousprevision',
		sum(isnull(secondaryprev,0)) as 'secondaryprev',
		sum(isnull(previoussecondaryprev,0)) as 'previoussecondaryprev',
		sum(isnull(currentarrears, 0)) as 'currentarrears',
		-- NO sum(isnull(previousarrears,0)) as 'previousarrears',
		@minlevelusable as 'minlevelusable',
		CASE 
		when (sum(isnull(prevision,0))  = 0 AND 
		      sum(isnull(previousprevision,0))= 0 AND 
		      sum(isnull(secondaryprev,0))= 0 AND
	              sum(isnull(previoussecondaryprev,0)) = 0 AND
	              sum(isnull(currentarrears, 0))= 0 AND
	              -- NO sum(isnull(previousarrears,0)) = 0 AND
		      @suppressifblank = 'S')
		then 'S' 
		else 'N' END as 'tosuppress',
		case @fin_kind when 2 then 'S' else 'C' end as 'previsionkind',
		ISNULL(@supposed_ff,0)	as supposed_ff,	--@supposed_ff as 'supposed_ff',
		ISNULL(@supposed_aa,0) 	as supposed_aa,	  --@supposed_aa as 'supposed_aa',
		@supposed_ff_prec as 'supposed_ff_prec',
		@supposed_aa_prec as 'supposed_aa_prec'
	FROM 	#budget
	LEFT OUTER JOIN finlink flk1
		ON flk1.idchild = #budget.idfin AND flk1.nlevel = 1
	LEFT OUTER JOIN fin b1
		ON flk1.idparent = b1.idfin 
	 LEFT OUTER JOIN finlink flk2
		ON flk2.idchild = #budget.idfin AND flk2.nlevel = 2
	LEFT OUTER JOIN fin b2
		ON flk2.idparent = b2.idfin 
	LEFT OUTER JOIN finlink flk3
		ON flk3.idchild = #budget.idfin AND flk3.nlevel = 3
	LEFT OUTER JOIN fin b3
		ON flk3.idparent = b3.idfin 
	LEFT OUTER JOIN finlink flk4
		ON flk4.idchild = #budget.idfin AND flk4.nlevel = 4
	LEFT OUTER JOIN fin b4
		ON flk4.idparent = b4.idfin 
	LEFT OUTER JOIN finlink flk5
		ON flk5.idchild = #budget.idfin AND flk5.nlevel = 5
	LEFT OUTER JOIN fin b5
		ON flk5.idparent = b5.idfin 
	LEFT OUTER JOIN finlink flk6
		ON flk6.idchild = #budget.idfin AND flk6.nlevel = 6
	LEFT OUTER JOIN fin b6
		ON flk6.idparent = b5.idfin 
	GROUP BY upbprintingorder,idupb ,upb,codeupb,
		#budget.idfin,code1,printorder1,code2,printorder2,code3,
		printorder3,code4,printorder4,code5,
		b1.title,b2.title,b3.title,b4.title,b5.title,b6.title,
		printorder5,code6,printorder6,b6.nlevel,codeupb,supposed_ff,supposed_aa,
		#budget.nlevel
	ORDER BY upbprintingorder ASC,
		printorder1 ASC,
		printorder2 ASC,
		printorder3 ASC,
		printorder4 ASC,
		printorder5 ASC,
		printorder6 ASC
END
ELSE
BEGIN
	SELECT 	#budget.idfin 	as 'idfin',
		code1,
		b1.title 	as 'desc1',
		@descliv1 	as 'descliv1',
		printorder1,
		code2,
		b2.title 	as  'desc2',
		@descliv2 	as 'descliv2',
		printorder2,
		code3,
		b3.title 	as 'desc3',
		@descliv3 	as 'descliv3',
		printorder3,
		code4,
		b4.title 	as 'desc4',
		@descliv4 	as  'descliv4',
		printorder4,
		code5,
		b5.title 	as 'desc5',
		@descliv5 	as 'descliv5',
		printorder5,
		code6,
		b6.title 	as 'desc6',
		@descliv6 	as 'descliv6',
		printorder6,
		#budget.nlevel,
		isnull(prevision,0) 			as 'prevision',
		isnull(previousprevision,0) 		as 'previousprevision',
		isnull(secondaryprev,0) 		as 'secondaryprev',
		isnull(previoussecondaryprev,0) 	as 'previoussecondaryprev',
		isnull(currentarrears, 0) 		as 'currentarrears',
		-- NO isnull(previousarrears,0) 	as 'previousarrears',
		case @fin_kind when 2 then 'S' else 'C' end 	as 'previsionkind',
		codeupb,
		idupb,
		upb,
		upbprintingorder,
		null 			as 'display_advance',
		ISNULL(@supposed_ff,0)	as 'supposed_ff', 	
		ISNULL(@supposed_aa,0) 	as 'supposed_aa',	
		@supposed_ff_prec 	as 'supposed_ff_prec',
		@supposed_aa_prec 	as 'supposed_aa_prec', 
		CASE 
		when (isnull(prevision,0)  		= 0 AND 
		      isnull(previousprevision,0)	= 0 AND 
		      isnull(secondaryprev,0)		= 0 AND
	              isnull(previoussecondaryprev,0)   = 0 AND
	              isnull(currentarrears, 0)	= 0 AND
	              -- NO isnull(previousarrears,0) 	= 0 AND
		      @suppressifblank = 'S')
		then 'S' 
		else 'N' END as 'tosuppress',
		@minlevelusable as 'minlevelusable'
	FROM 	#budget
	LEFT OUTER JOIN finlink flk1
		ON flk1.idchild = #budget.idfin AND flk1.nlevel = 1
	LEFT OUTER JOIN fin b1
		ON flk1.idparent = b1.idfin 
	LEFT OUTER JOIN finlink flk2
		ON flk2.idchild = #budget.idfin AND flk2.nlevel = 2
	LEFT OUTER JOIN fin b2
		ON flk2.idparent = b2.idfin 
	LEFT OUTER JOIN finlink flk3
		ON flk3.idchild = #budget.idfin AND flk3.nlevel = 3
	LEFT OUTER JOIN fin b3
		ON flk3.idparent = b3.idfin 
	LEFT OUTER JOIN finlink flk4
		ON flk4.idchild = #budget.idfin AND flk4.nlevel = 4
	LEFT OUTER JOIN fin b4
		ON flk4.idparent = b4.idfin 
	LEFT OUTER JOIN finlink flk5
		ON flk5.idchild = #budget.idfin AND flk5.nlevel = 5
	LEFT OUTER JOIN fin b5
		ON flk5.idparent = b5.idfin 
	LEFT OUTER JOIN finlink flk6
		ON flk6.idchild = #budget.idfin AND flk6.nlevel = 6
	LEFT OUTER JOIN fin b6
		ON flk6.idparent = b6.idfin 
	ORDER BY  
		upbprintingorder ASC,
		printorder1 ASC,
		printorder2 ASC,
		printorder3 ASC,
		printorder4 ASC,
		printorder5 ASC,
		printorder6 ASC
END
END
go




