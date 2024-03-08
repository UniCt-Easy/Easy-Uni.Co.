
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_bilprevisionepluriennale]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_bilprevisionepluriennale]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



/*
setuser 'amm'
exec rpt_bilprevisionepluriennale 2008,'E',3,'0001','S','N','S'

*/

CREATE      PROCEDURE [rpt_bilprevisionepluriennale]
(
	@ayear smallint,
	@finpart char(1),
	@levelusable tinyint,
	@idupb varchar(36),
	@showupb char(1),
	@showchildupb char(1),
	@suppressifblank char(1)
)
AS BEGIN

DECLARE @idupboriginal varchar(36)
SET @idupboriginal = @idupb

IF (@showchildupb = 'S')
BEGIN
	SET @idupb = @idupb + '%' 
END


DECLARE	@finpart_bit  tinyint  -- Parte del bilancio (Entrata / Spesa)
if @finpart='E' set @finpart_bit = 0
if @finpart='S' set @finpart_bit = 1

DECLARE @minoplevel tinyint
SELECT @minoplevel = min(nlevel)
FROM finlevel
WHERE ayear = @ayear and (flag&2)<>0

IF(@levelusable < @minoplevel)
begin
	SET @levelusable = @minoplevel
end

CREATE TABLE #budget
(
	idfin int,
	codeupb varchar(50),
	idupb varchar(36),
	upb varchar(150),
	upbprintingorder varchar(50),
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
	tosuppress char(1),
	nlevel tinyint,
	previsioneannuale1 decimal(19,2),
	previsioneannuale2 decimal(19,2),
	previsioneannuale3 decimal(19,2),
	prevbilprec decimal(19,2),
	prevbilprec2 decimal(19,2),
	varaumento decimal(19,2),
	vardiminuzione decimal(19,2),
	varaumento1 decimal(19,2),
	vardiminuzione1 decimal(19,2)
	)


	DECLARE @ayearprec smallint
	SET @ayearprec = @ayear - 1
		

declare @fin_kind int
SELECT @fin_kind = fin_kind
FROM config
WHERE ayear = @ayear

DECLARE @supposed_ff_jan01 decimal(19,2)
DECLARE @supposed_aa_jan01 decimal(19,2)
DECLARE @ff_prec decimal(19,2)
DECLARE @aa_prec decimal(19,2)

IF @finpart = 'E'
BEGIN
	SELECT
		@supposed_ff_jan01 =
			ISNULL(startfloatfund, 0) +
			ISNULL(proceedstilldate, 0) -
			ISNULL(paymentstilldate, 0) +
			ISNULL(proceedstoendofyear, 0) -
			ISNULL(paymentstoendofyear, 0),
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

	-- Bilancio di Previsione 2014 --
	
	-- Fondo cassa al 01/01/2013
	SELECT 	@ff_prec = ISNULL(startfloatfund, 0) 
	FROM surplus
	WHERE ayear = @ayear - 1

	-- Avanzo di amministrazione al 01/01/2013 = AA al 31/12/2012 = fondo cassa 31/12/2012 + Residui Attivi 2012 - Residui Passivi 2012 = fondo cassa 01/01/2013 + RA 2012 - RP 2012
	SELECT	
		@aa_prec = 	@ff_prec +	
			ISNULL(previousrevenue, 0) +
			ISNULL(currentrevenue , 0) -
			ISNULL(previousexpenditure, 0) -
			ISNULL(currentexpenditure, 0)
	FROM surplus
	WHERE ayear = @ayear - 2
 -- Per ulteriori dettagli in merito a questa modifica leggere la Documentazione del task n.4077
 
END


DECLARE @infoadvance char(1)
SELECT @infoadvance = paramvalue
FROM generalreportparameter
WHERE idparam = 'MostraAvanzo'


	INSERT INTO #budget
	(
		idfin,
		code1, order1,code2,order2,code3,order3,code4,order4,code5,order5,code6,order6,
		codeupb,idupb, upb,
		upbprintingorder,
		previsioneannuale1, 					
		previsioneannuale2, 					
		previsioneannuale3,
		nlevel
	)
	SELECT 
		f6.idfin, 
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
	ISNULL(FY.prevision, 0.0),
	ISNULL(FY.prevision2, 0.0),
	ISNULL(FY.prevision3, 0.0),
	f6.nlevel

	FROM fin f6
	CROSS JOIN upb 
	JOIN finlevel fl
		ON f6.nlevel = fl.nlevel AND  f6.ayear = fl.ayear
	LEFT OUTER JOIN finyear FY
		ON FY.idfin = f6.idfin
		AND FY.idupb = upb.idupb
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
		AND ((f6.flag & 1)= @finpart_bit) 
		AND (f6.nlevel = @levelusable
			OR (f6.nlevel < @levelusable
			AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = f6.idfin)
			AND (fl.flag&2)<>0
			)
	
			)
		AND (@infoadvance = 'N' OR @infoadvance = 'B' OR (F6.flag & 16 =0) )


update #budget
SET prevbilprec = (SELECT SUM(ISNULL(FY_prec.prevision2, 0.0))
		FROM finlookup
		JOIN finyear FY_prec
		ON finlookup.oldidfin = FY_prec.idfin
		WHERE  #budget.idfin= finlookup.newidfin
		AND FY_prec.ayear = @ayearprec
		AND FY_prec.idupb = #budget.idupb) ,
	prevbilprec2 = (SELECT SUM(ISNULL(FY_prec.prevision3, 0.0))
		FROM finlookup
		JOIN finyear FY_prec
		ON finlookup.oldidfin = FY_prec.idfin
		WHERE  #budget.idfin= finlookup.newidfin
		AND FY_prec.ayear = @ayearprec
		AND FY_prec.idupb = #budget.idupb) 
		

UPDATE #budget
SET	varaumento = 	CASE 
		WHEN ISNULL(previsioneannuale1, 0) > ISNULL(prevbilprec, 0)
		THEN ISNULL(previsioneannuale1, 0) - ISNULL(prevbilprec, 0)
		ELSE NULL
	END,
	vardiminuzione = CASE 
		WHEN ISNULL(previsioneannuale1, 0) < ISNULL(prevbilprec, 0)
		THEN ISNULL(prevbilprec, 0) - ISNULL(previsioneannuale1, 0)
		ELSE NULL
	END,
	varaumento1 = 	CASE 
		WHEN ISNULL(previsioneannuale2, 0) > ISNULL(prevbilprec2, 0)
		THEN ISNULL(previsioneannuale2, 0) - ISNULL(prevbilprec2, 0)
		ELSE NULL
	END,
	vardiminuzione1 = CASE 
		WHEN ISNULL(previsioneannuale2, 0) < ISNULL(prevbilprec2, 0)
		THEN ISNULL(prevbilprec2, 0) - ISNULL(previsioneannuale2, 0)
		ELSE NULL
	END


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
	
IF (@showupb <>'S') and (@idupboriginal = '%') 
BEGIN
	UPDATE #budget SET  
	upbprintingorder = NULL,
	upb =  NULL,
	idupb = NULL,
	codeupb = NULL
END

IF (@suppressifblank = 'S')
BEGIN
	UPDATE #budget SET tosuppress = 'S'
	WHERE  
		(ISNULL(previsioneannuale1,0)= 0 AND 
		ISNULL(previsioneannuale2,0)= 0 AND 
		ISNULL(previsioneannuale3,0)= 0 AND
		ISNULL(prevbilprec,0) = 0 AND
		ISNULL(prevbilprec2,0)= 0 AND
		ISNULL(varaumento,0) = 0 AND
		ISNULL(vardiminuzione,0) = 0 AND 
		ISNULL(varaumento1,0) = 0 AND
		ISNULL(vardiminuzione1,0) = 0)

	UPDATE #budget SET tosuppress = 'N'
	WHERE  
		NOT(ISNULL(previsioneannuale1,0)= 0 AND 
		ISNULL(previsioneannuale2,0)= 0 AND 
		ISNULL(previsioneannuale3,0)= 0 AND
		ISNULL(prevbilprec,0) = 0 AND
		ISNULL(prevbilprec2,0)= 0 AND
		ISNULL(varaumento,0) = 0 AND
		ISNULL(vardiminuzione,0) = 0 AND 
		ISNULL(varaumento1,0) = 0 AND
		ISNULL(vardiminuzione1,0) = 0)

-- Se ho deciso di NON vedere gli upb, upb vale NULL, e potrei avere per la stessa voce di bilancio
-- una riga con tosuppress a S perchè i valori sono tutti zero
-- e una seconda riga con tosuppress a N perchè i valori NON sono zero
-- questo perchè la voce di bilancio su un upb aveva previsione, sugli altri no.
-- Quindi in questo caso nella SELECT finale la sp fornsice al report 2 righe per lo stesso capitolo,
--  di cui una ha valori tutti a zero e suppress a S,
-- l'altra con valori diversi da zero e suppress a N. 
-- Nel report, tra i vari raggruppamenti ve n'è uno sul capitolo, il raggruppamento è nascosto se suppress = N, 
-- quindi se al report arrivano due righe dello stesso capitolo la prima con suppress a S e la seconda a N,
-- ha effetto la prima e quindi il capitolo non viene mostrato.
-- La seguente DELETE serve a cancellare quelle righe con suppress a S, e quindi di quei capitoli che hanno importi a zero, ma per
-- cui esiste una riga con importi diversi da zero. In questo modo
-- nella SELETC SUM finale, della sp, la GROUP BY darà in OUT una sola riga ossia quella con importi diversi da zero


	DELETE FROM #budget	WHERE  
		tosuppress = 'S'
		AND 
		exists (select * from  #budget B2 
			where B2.idfin = #budget.idfin 
				and B2.idupb is null
				and B2.tosuppress='N')

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


IF ((@showupb <>'S') AND (@idupboriginal <> '%' ) AND (@showchildupb = 'S'))OR 
((@showupb <>'S') and (@idupboriginal = '%'))
BEGIN
	SELECT 
		BP.idfin,
		BP.code1,
		f1.title AS desc1,
		@lev_desc1 AS descliv1,
		BP.order1,
		BP.code2,
		f2.title AS desc2,
		@lev_desc2 AS descliv2,
		BP.order2,
		BP.code3,
		f3.title AS desc3,
		@lev_desc3 AS descliv3,
		BP.order3,
		BP.code4,
		f4.title AS desc4,
		@lev_desc4 AS descliv4,
		BP.order4,
		BP.code5,
		f5.title AS desc5,
		@lev_desc5 AS descliv5,
		BP.order5,
		BP.code6,
		f6.title AS desc6,
		@lev_desc6 AS descliv6,
		BP.order6,

		BP.codeupb	,
		BP.idupb,
		BP.upb,
		BP.upbprintingorder,
		BP.nlevel,

		ISNULL(SUM(BP.previsioneannuale1),0) AS previsioneannuale1,
		ISNULL(SUM(BP.previsioneannuale2),0) AS previsioneannuale2,
		ISNULL(SUM(BP.previsioneannuale3),0) AS previsioneannuale3,
		ISNULL(SUM(BP.prevbilprec),0) AS prevbilprec,
		ISNULL(SUM(BP.prevbilprec2),0) AS prevbilprec2,
		ISNULL(SUM(BP.varaumento),0) AS varaumento,
		ISNULL(SUM(BP.vardiminuzione),0) AS vardiminuizione,
		ISNULL(SUM(BP.varaumento1),0) AS varaumento1,
		ISNULL(SUM(BP.vardiminuzione1),0) AS vardiminuizione1,
		@minoplevel AS minoplevel,
		CASE 
			WHEN (ISNULL(sum(previsioneannuale1),0)= 0 AND 
			ISNULL(sum(previsioneannuale2),0)= 0 AND 
			ISNULL(sum(previsioneannuale3),0)= 0 AND
			ISNULL(sum(prevbilprec),0) = 0 AND
			ISNULL(sum(prevbilprec2),0)= 0 AND
			      @suppressifblank = 'S')
			THEN 'S' 
			ELSE 'N' 
		END AS tosuppress,
		case @fin_kind when 2 then 'S' else 'C' end AS previsionkind,
		@supposed_ff_jan01 AS supposed_ff_jan01,
		@supposed_aa_jan01 AS supposed_aa_jan01,
		@ff_prec AS ff_prec,
		@aa_prec AS aa_prec
	FROM #budget BP
	LEFT OUTER JOIN finlink flk1
		ON flk1.idchild = BP.idfin AND flk1.nlevel = 1
	LEFT OUTER JOIN fin f1
		ON flk1.idparent = f1.idfin 

	LEFT OUTER JOIN finlink flk2
		ON flk2.idchild = BP.idfin AND flk2.nlevel = 2
	LEFT OUTER JOIN fin f2
		ON flk2.idparent = f2.idfin 

	LEFT OUTER JOIN finlink flk3
		ON flk3.idchild = BP.idfin AND flk3.nlevel = 3
	LEFT OUTER JOIN fin f3
		ON flk3.idparent = f3.idfin 

	LEFT OUTER JOIN finlink flk4
		ON flk4.idchild = BP.idfin AND flk4.nlevel = 4
	LEFT OUTER JOIN fin f4
		ON flk4.idparent = f4.idfin 
	LEFT OUTER JOIN finlink flk5
		ON flk5.idchild = BP.idfin AND flk5.nlevel = 5
	LEFT OUTER JOIN fin f5
		ON flk5.idparent = f5.idfin 
	LEFT OUTER JOIN finlink flk6
		ON flk6.idchild = BP.idfin AND flk5.nlevel = 6
	LEFT OUTER JOIN fin f6
		ON flk6.idparent = f6.idfin 
GROUP BY upbprintingorder,idupb,upb,codeupb,
		BP.idfin,
		code1,f1.title,order1,
		code2,f2.title,order2,
		code3,f3.title,order3,
		code4,f4.title,order4,
		code5,f5.title,order5,
		code6,f6.title,order6,
		codeupb,tosuppress,BP.nlevel

	ORDER BY upbprintingorder ASC,
		order1 ASC, order2 ASC, order3 ASC, order4 ASC
END
ELSE
BEGIN
	SELECT 
		BP.idfin,
		BP.code1,
		f1.title AS desc1,
		@lev_desc1 AS descliv1,
		BP.order1,
		BP.code2,
		f2.title AS desc2,
		@lev_desc2 AS descliv2,
		BP.order2,
		BP.code3,
		f3.title AS desc3,
		@lev_desc3 AS descliv3,
		BP.order3,
		BP.code4,
		f4.title AS desc4,
		@lev_desc4 AS descliv4,
		BP.order4,
		BP.code5,
		f5.title AS desc5,
		@lev_desc5 AS descliv5,
		BP.order5,
		BP.code6,
		f6.title AS desc6,
		@lev_desc6 AS descliv6,
		BP.order6,
		BP.codeupb	,
		BP.idupb,
		BP.upb,
		BP.upbprintingorder,
		BP.nlevel,
		ISNULL(BP.previsioneannuale1,0) AS previsioneannuale1,
		ISNULL(BP.previsioneannuale2,0) AS previsioneannuale2,
		ISNULL(BP.previsioneannuale3,0) AS previsioneannuale3,
		ISNULL(BP.prevbilprec,0) AS prevbilprec,
		ISNULL(BP.prevbilprec2,0) AS prevbilprec2,
		ISNULL(BP.varaumento,0) AS varaumento,
		ISNULL(BP.vardiminuzione,0) AS vardiminuizione,
		ISNULL(BP.varaumento1,0) AS varaumento1,
		ISNULL(BP.vardiminuzione1,0) AS vardiminuizione1,
		@minoplevel AS minoplevel,
		tosuppress,
		case @fin_kind when 2 then 'S' else 'C' end AS previsionkind,
		@supposed_ff_jan01 AS supposed_ff_jan01,
		@supposed_aa_jan01 AS supposed_aa_jan01,
		@ff_prec AS ff_prec,
		@aa_prec AS aa_prec
	FROM #budget BP
	LEFT OUTER JOIN finlink flk1
		ON flk1.idchild = BP.idfin AND flk1.nlevel = 1
	LEFT OUTER JOIN fin f1
		ON flk1.idparent = f1.idfin 

	LEFT OUTER JOIN finlink flk2
		ON flk2.idchild = BP.idfin AND flk2.nlevel = 2
	LEFT OUTER JOIN fin f2
		ON flk2.idparent = f2.idfin 

	LEFT OUTER JOIN finlink flk3
		ON flk3.idchild = BP.idfin AND flk3.nlevel = 3
	LEFT OUTER JOIN fin f3
		ON flk3.idparent = f3.idfin 

	LEFT OUTER JOIN finlink flk4
		ON flk4.idchild = BP.idfin AND flk4.nlevel = 4
	LEFT OUTER JOIN fin f4
		ON flk4.idparent = f4.idfin 
	LEFT OUTER JOIN finlink flk5
		ON flk5.idchild = BP.idfin AND flk5.nlevel = 5
	LEFT OUTER JOIN fin f5
		ON flk5.idparent = f5.idfin 
	LEFT OUTER JOIN finlink flk6
		ON flk6.idchild = BP.idfin AND flk5.nlevel = 6
	LEFT OUTER JOIN fin f6
		ON flk6.idparent = f6.idfin 
	ORDER BY upbprintingorder ASC,
		order1 ASC, order2 ASC, order3 ASC, order4 ASC, order5 ASC, order6 ASC

END

END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

