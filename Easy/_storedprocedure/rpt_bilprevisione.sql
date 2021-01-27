
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_bilprevisione]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_bilprevisione]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
--exec  rpt_bilprevisione 2013, 'S', 3, '%', 'N', 'N', 'N', NULL, NULL, NULL, NULL, NULL

--	exec rpt_bilprevisione 2012,'S',1,'%','S','S','S'
-- setuser 'amministrazione'
CREATE    PROCEDURE [rpt_bilprevisione]
(
	@ayear smallint,
	@finpart char(1)='S',
	@levelusable tinyint=3,
	@idupb varchar(36)='%',
	@showupb char(1)='N',
	@showchildupb char(1)='N',
	@suppressifblank char(1)='S',
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
)
AS BEGIN

DECLARE @idupboriginal varchar(36)
SET @idupboriginal = @idupb

declare @fixedidupb varchar(36)
set @fixedidupb= null
if (@showupb='N') set @fixedidupb='0001'




IF (@showchildupb = 'S')
BEGIN
	SET @idupb = @idupb + '%' 
END

declare @fin_kind tinyint
SELECT  @fin_kind = isnull(fin_kind,0) FROM config WHERE ayear = @ayear



DECLARE @boxpartitiontitle varchar(50)
SELECT @boxpartitiontitle=boxpartitiontitle FROM config WHERE ayear = @ayear

DECLARE	@finpart_bit  tinyint  -- Parte del bilancio (Entrata / Spesa)
if @finpart='E' set @finpart_bit = 0
if @finpart='S' set @finpart_bit = 1

DECLARE @MostraTutteVoci char(1)
SELECT @MostraTutteVoci = isnull(paramvalue,'N') 
FROM generalreportparameter WHERE idparam = 'MostraTutteVoci'

DECLARE @minoplevel tinyint
SELECT @minoplevel = min(nlevel)
FROM finlevel
WHERE ayear = @ayear and (flag&2)<>0
	
DECLARE @levelusable_original tinyint	
SET @levelusable_original = @levelusable


IF(@levelusable < @minoplevel)-- se decidi di fare la stampa per categoria
begin
	SET @levelusable = @minoplevel
end

CREATE TABLE #data
(
	idfin int,
	idupb varchar(36),
	initialprevision decimal(19,2),
	previousprevision decimal(19,2),
	secondaryprevision decimal(19,2),
	previoussecondaryprev decimal(19,2),
	currentarrears decimal(19,2),
	previousarrears decimal(19,2),
	accretion_var decimal(19,2),
	diminution_var decimal(19,2),
	tosuppress char(1)
)



DECLARE @supposed_ff_jan01 decimal(19,2)
DECLARE @supposed_aa_jan01 decimal(19,2)
DECLARE @ff_prec decimal(19,2)
DECLARE @aa_prec decimal(19,2)
DECLARE @infoadvance char(1)

DECLARE @floatfund_01_jan_used decimal(19,2) 
DECLARE @supposed_aa_01_jan_used decimal(19,2) 
DECLARE @aa_01_jan_used decimal(19,2) 
DECLARE @supposed_ff_01_jan_used decimal(19,2) 
DECLARE @supposed_aa_prec_used decimal(19,2) 
DECLARE @aa_prec_used decimal(19,2) 
DECLARE @ff_prec_used decimal(19,2) 

IF @finpart = 'E'
BEGIN
	SELECT
		@supposed_ff_jan01 = --> sta bene Previsioni per il 2014
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

	SELECT @floatfund_01_jan_used = isnull(paramvalue,0) 
	FROM generalreportparameter 
	WHERE idparam='ff_jan01'
	
	SELECT @aa_01_jan_used = isnull(paramvalue,0) 
	FROM generalreportparameter 
	WHERE idparam='aa_jan01'

	SELECT @supposed_ff_01_jan_used = isnull(paramvalue,0) 
	FROM generalreportparameter 
	WHERE idparam='supposed_ff_jan01'
	
	SELECT @supposed_aa_01_jan_used = isnull(paramvalue,0) 
	FROM generalreportparameter 
	WHERE idparam='supposed_aa_jan01'

	
	
	-- Bilancio di Previsione 2014 --
	
	-- Fondo cassa al 01/01/2013
	SELECT 	@ff_prec = ISNULL(startfloatfund, 0) 
	FROM surplus
	WHERE ayear = @ayear - 1

	-- Avanzo di amministrazione al 01/01/2013 = AA al 31/12/2012 = fondo cassa 31/12/2012 + Residui Attivi 2012 - Residui Passivi 2012 = fondo cassa 01/01/2013 + RA 2012 - RP 2012
	SELECT	
		@aa_prec = 	(SELECT ISNULL(startfloatfund, 0) FROM surplus	WHERE ayear = @ayear - 1)
			+	
			ISNULL(previousrevenue, 0) +
			ISNULL(currentrevenue , 0) -
			ISNULL(previousexpenditure, 0) -
			ISNULL(currentexpenditure, 0)
	FROM surplus
	WHERE ayear = @ayear - 2
 -- Per ulteriori dettagli in merito a questa modifica leggere la Documentazione del task n.4077
	
	SELECT @supposed_aa_prec_used = isnull(paramvalue,0) 
	FROM generalreportparameter 
	WHERE idparam='supposed_aa_prec'

	SELECT @aa_prec_used = isnull(paramvalue,0) 
	FROM generalreportparameter 
	WHERE idparam='aa_prec'

	SELECT @ff_prec_used = isnull(paramvalue,0) 
	FROM generalreportparameter 
	WHERE idparam='ff_prec'

END

SELECT @infoadvance = paramvalue
FROM generalreportparameter
WHERE idparam = 'MostraAvanzo'

insert into #data (
	idfin,
	idupb,
	initialprevision,previousprevision,secondaryprevision,previoussecondaryprev,currentarrears,previousarrears
)
select finyear.idfin,isnull(@fixedidupb,finyear.idupb),
		ISNULL(SUM(finyear.prevision),0),ISNULL(SUM(finyear.previousprevision),0),
		ISNULL(SUM(finyear.secondaryprev),0),ISNULL(SUM(finyear.previoussecondaryprev),0),
		ISNULL(SUM(finyear.currentarrears),0),ISNULL(SUM(finyear.previousarrears),0)
from finyear 
	join fin f5 on finyear.idfin=f5.idfin
JOIN upb U
	ON finyear.idupb = U.idupb
JOIN finlevel fl
	ON f5.nlevel = fl.nlevel AND  f5.ayear = fl.ayear
where f5.ayear = @ayear
		AND (finyear.idupb LIKE @idupb)	
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND ((f5.flag & 1)= @finpart_bit) --AND f5.finpart = @finpart
		AND (f5.nlevel = @levelusable
			OR (f5.nlevel < @levelusable
				AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = f5.idfin)
				AND (fl.flag&2)<>0
			   )
			)
		AND (@infoadvance = 'N' OR @infoadvance = 'B' OR (F5.flag & 16 =0)) 
group by finyear.idfin,isnull(@fixedidupb,finyear.idupb)

UPDATE #data SET tosuppress = 'N'

--SELECT * FROM #DATA
 

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
SELECT @lev_desc6 = description FROM finlevel WHERE ayear = @ayear AND nlevel = 5

if (@levelusable_original<6) 
	set @lev_desc6='liv6'


if (@levelusable_original<5) 
	set @lev_desc5='liv5'

if (@levelusable_original<4) 
	set @lev_desc4='liv4'

if (@levelusable_original<3) 
	set @lev_desc3='liv3'


if (@levelusable_original<2) 
	set @lev_desc2='liv2'


IF (@showupb ='S')
BEGIN

;with raggruppa_capitoli (
		idfin,
		idupb,
		initialprevision,
		previousprevision	,
		secondaryprevision	,
		previoussecondaryprev	,
		currentarrears		,
		previousarrears		
  )
 AS(
		SELECT 
			idfin,
			idupb,
			ISNULL(SUM(initialprevision),0),
			ISNULL(SUM(previousprevision),0),
			ISNULL(SUM(secondaryprevision),0),
			ISNULL(SUM(previoussecondaryprev),0),
			ISNULL(SUM(currentarrears),0),
			ISNULL(SUM(previousarrears),0)
		FROM #data
		group by idfin,idupb
)

SELECT 
	f.idfin,
	SUBSTRING(f.codefin, @startpos1, @lencod_lev1) as code1,
	f1.title AS desc1,
	@lev_desc1 AS descliv1,
	SUBSTRING(f.printingorder, @startpos1, @lencod_lev1) as order1,
	
	CASE when (f2.codefin is null) then null
		else SUBSTRING(f.codefin, @startpos2, @lencod_lev2) 
	end	as code2,
	f2.title AS desc2,
	@lev_desc2 AS descliv2,
	SUBSTRING(f.printingorder, @startpos2, @lencod_lev2) as order2,
	
	case when (f3.codefin is null) then null
		else SUBSTRING(f.codefin, @startpos3, @lencod_lev3)
	end	 as code3,
	f3.title as desc3,
	@lev_desc3 as descliv3,
	SUBSTRING(f.printingorder, @startpos3, @lencod_lev3) as order3,
	
	case when (f4.codefin is null) then null
		else	SUBSTRING(f.codefin, @startpos4, @lencod_lev4)
	end	as code4,
	f4.title AS desc4,
	@lev_desc4 AS descliv4,
	SUBSTRING(f.printingorder, @startpos4, @lencod_lev4) as order4,
	
	case when (f5.codefin is null) then null
		else SUBSTRING(f.codefin, @startpos5, @lencod_lev5) 
	end	as code5,
	f5.title AS desc5,
	@lev_desc5 AS descliv5,
	SUBSTRING(f.printingorder, @startpos5, @lencod_lev5) as order5,
	
	case when (f6.codefin is null) then null
		else SUBSTRING(f.codefin, @startpos6, @lencod_lev6) 
	end	as code6,
	f6.title AS desc6,
	@lev_desc6 AS descliv6,
	SUBSTRING(f.printingorder, @startpos6, @lencod_lev6) as order6,

	upb.codeupb,
	upb.idupb as idupb,
	upb.title as upb,
	upb.printingorder as upbprintingorder,
	
	f.nlevel,
		ISNULL(SUM(initialprevision),0) AS initialprevision,
		ISNULL(SUM(previousprevision),0) AS previousprevision,
		ISNULL(SUM(secondaryprevision),0) AS secondaryprevision,
		ISNULL(SUM(previoussecondaryprev),0) AS previoussecondaryprev,
		ISNULL(SUM(currentarrears),0) AS currentarrears,
		ISNULL(SUM(previousarrears),0) AS previousarrears,
		SUM (case when isnull(initialprevision,0)-isnull(previousprevision,0) > 0 then isnull(initialprevision,0)-isnull(previousprevision,0) else 0 end) as accretion_var,
		SUM (case when isnull(previousprevision,0)-isnull(initialprevision,0) > 0 then isnull(previousprevision,0)-isnull(initialprevision,0) else 0 end) as diminution_var,
	
		@minoplevel AS minoplevel,
		isnull('N', @suppressifblank) AS tosuppress,	
	case @fin_kind when 1 then 'C' else 'S' end AS previsionkind,
			@supposed_ff_jan01 AS supposed_ff_jan01,
			@supposed_aa_jan01 AS supposed_aa_jan01,
			@ff_prec AS ff_prec,
			@aa_prec AS aa_prec,
	isnull(@floatfund_01_jan_used,0) as floatfund_01_jan_used,
	isnull(@supposed_aa_01_jan_used,0) as supposed_aa_01_jan_used,
	isnull(@aa_01_jan_used,0) as aa_01_jan_used,
	isnull(@supposed_ff_01_jan_used,0) as supposed_ff_01_jan_used,
	isnull(@aa_prec_used,0) as  aa_prec_used,
	isnull(@ff_prec_used,0) as  ff_prec_used,
            @boxpartitiontitle as boxpartitiontitle
FROM fin f
	JOIN finlevel fl
		ON f.nlevel = fl.nlevel AND  f.ayear = fl.ayear	
left outer join finlink 
				on finlink.idparent=f.idfin    
cross join  upb 
left outer join raggruppa_capitoli 
				on raggruppa_capitoli.idfin=finlink.idchild   and raggruppa_capitoli.idupb=upb.idupb

LEFT OUTER JOIN finlink flk1
	ON flk1.idchild = f.idfin AND flk1.nlevel = 1
LEFT OUTER JOIN fin f1
	ON flk1.idparent = f1.idfin 
LEFT OUTER JOIN finlink flk2
	ON flk2.idchild = f.idfin AND flk2.nlevel = 2
LEFT OUTER JOIN fin f2
	ON flk2.idparent = f2.idfin 
LEFT OUTER JOIN finlink flk3
	ON flk3.idchild = f.idfin AND flk3.nlevel = 3
LEFT OUTER JOIN fin f3
	ON flk3.idparent = f3.idfin 
LEFT OUTER JOIN finlink flk4
	ON flk4.idchild = f.idfin AND flk4.nlevel = 4
LEFT OUTER JOIN fin f4
	ON flk4.idparent = f4.idfin 
LEFT OUTER JOIN finlink flk5
	ON flk5.idchild = f.idfin AND flk5.nlevel = 5
LEFT OUTER JOIN fin f5
	ON flk5.idparent = f5.idfin 
LEFT OUTER JOIN finlink flk6
	ON flk5.idchild = f.idfin AND flk5.nlevel = 6
LEFT OUTER JOIN fin f6
	ON flk6.idparent = f6.idfin 	
where  ( (@MostraTutteVoci = 'S'  or @suppressifblank='N') OR 
(upb.idupb='0001' or
			 raggruppa_capitoli.idfin is not null) 
   ) and
		f.ayear=@ayear 
		AND ((f.flag & 1)= @finpart_bit) 
		AND (f.nlevel = @levelusable_original )
			 
	   and upb.idupb like @idupb
	   AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	   AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	   AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	   AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	   AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)	
GROUP BY F.idfin,f.codefin,upb.printingorder,upb.idupb,upb.title,upb.codeupb,
	upb.idsor01,  upb.idsor02,  upb.idsor03, upb.idsor04, upb.idsor05,
	SUBSTRING(f.codefin, @startpos1, @lencod_lev1),
	SUBSTRING(f.codefin, @startpos2, @lencod_lev2),f2.codefin,
	SUBSTRING(f.codefin, @startpos3, @lencod_lev3),f3.codefin,
	SUBSTRING(f.codefin, @startpos4, @lencod_lev4),f4.codefin,
	SUBSTRING(f.codefin, @startpos5, @lencod_lev5),f5.codefin,
	SUBSTRING(f.codefin, @startpos6, @lencod_lev6),f6.codefin,
	SUBSTRING(f.printingorder, @startpos1, @lencod_lev1),
	SUBSTRING(f.printingorder, @startpos2, @lencod_lev2),
	SUBSTRING(f.printingorder, @startpos3, @lencod_lev3),
	SUBSTRING(f.printingorder, @startpos4, @lencod_lev4),
	SUBSTRING(f.printingorder, @startpos5, @lencod_lev5),
	SUBSTRING(f.printingorder, @startpos6, @lencod_lev6),
	f1.title,f2.title,f3.title,f4.title,f5.title,f6.title,f.printingorder,
	f.nlevel 
ORDER BY upb.printingorder ASC,
	f.printingorder ASC
	
	
END 



IF (@showupb ='N')
BEGIN
declare 	@codeupb varchar(50)
declare		@upb varchar(150)
declare		@upbprintingorder varchar(50)
declare		@ext_idupb varchar(50)

if (@idupboriginal='%')
begin
	set @codeupb= null
	set @upb= null
	set @upbprintingorder= null
	set @ext_idupb= null
end
else
begin
	SET @upbprintingorder =
		(SELECT TOP 1 printingorder
		FROM upb
		WHERE idupb = @idupboriginal)
	SET  @upb =
		(SELECT TOP 1 title
		FROM upb
		WHERE idupb = @idupboriginal)
	SET  @ext_idupb =	@idupboriginal
	SET  @codeupb =
		(SELECT TOP 1 codeupb
		FROM upb	
		WHERE idupb = @idupboriginal)
end

;with raggruppa_capitoli (
		idfin,
		idupb,
		initialprevision,
		previousprevision	,
		secondaryprevision	,
		previoussecondaryprev	,
		currentarrears		,
		previousarrears		
  )
 AS(
		SELECT 
			idfin,
			idupb,
			ISNULL(SUM(initialprevision),0),
			ISNULL(SUM(previousprevision),0),
			ISNULL(SUM(secondaryprevision),0),
			ISNULL(SUM(previoussecondaryprev),0),
			ISNULL(SUM(currentarrears),0),
			ISNULL(SUM(previousarrears),0)
		FROM #data
		group by idfin,idupb
)

SELECT 
	f.idfin,
	SUBSTRING(f.codefin, @startpos1, @lencod_lev1) as code1,
	f1.title AS desc1,
	@lev_desc1 AS descliv1,
	SUBSTRING(f.printingorder, @startpos1, @lencod_lev1) as order1,
	
	CASE when (f2.codefin is null) then null
		else SUBSTRING(f.codefin, @startpos2, @lencod_lev2) 
	end	as code2,
	f2.title AS desc2,
	@lev_desc2 AS descliv2,
	SUBSTRING(f.printingorder, @startpos2, @lencod_lev2) as order2,
	
	case when (f3.codefin is null) then null
		else SUBSTRING(f.codefin, @startpos3, @lencod_lev3)
	end	 as code3,
	f3.title as desc3,
	@lev_desc3 as descliv3,
	SUBSTRING(f.printingorder, @startpos3, @lencod_lev3) as order3,
	
	case when (f4.codefin is null) then null
		else	SUBSTRING(f.codefin, @startpos4, @lencod_lev4)
	end	as code4,
	f4.title AS desc4,
	@lev_desc4 AS descliv4,
	SUBSTRING(f.printingorder, @startpos4, @lencod_lev4) as order4,
	
	case when (f5.codefin is null) then null
		else SUBSTRING(f.codefin, @startpos5, @lencod_lev5) 
	end	as code5,
	f5.title AS desc5,
	@lev_desc5 AS descliv5,
	SUBSTRING(f.printingorder, @startpos5, @lencod_lev5) as order5,
	
	case when (f6.codefin is null) then null
		else SUBSTRING(f.codefin, @startpos6, @lencod_lev6) 
	end	as code6,
	f6.title AS desc6,
	@lev_desc6 AS descliv6,
	SUBSTRING(f.printingorder, @startpos6, @lencod_lev6) as order6,

	@codeupb as codeupb,
	@ext_idupb as idupb,
	@upb as upb,
	@upbprintingorder as upbprintingorder,
	f.nlevel,

	
	ISNULL(SUM(initialprevision),0) AS initialprevision,
		ISNULL(SUM(previousprevision),0) AS previousprevision,
		ISNULL(SUM(secondaryprevision),0) AS secondaryprevision,
		ISNULL(SUM(previoussecondaryprev),0) AS previoussecondaryprev,
		ISNULL(SUM(currentarrears),0) AS currentarrears,
		ISNULL(SUM(previousarrears),0) AS previousarrears,
SUM (case when isnull(initialprevision,0)-isnull(previousprevision,0) > 0 then isnull(initialprevision,0)-isnull(previousprevision,0) else 0 end) as accretion_var,
		SUM (case when isnull(previousprevision,0)-isnull(initialprevision,0) > 0 then isnull(previousprevision,0)-isnull(initialprevision,0) else 0 end) as diminution_var,
	
	@minoplevel AS minoplevel,
	isnull('N', @suppressifblank) AS tosuppress,	
	
	case @fin_kind when 1 then 'C' else 'S' end AS previsionkind,

		@supposed_ff_jan01 AS supposed_ff_jan01,
		@supposed_aa_jan01 AS supposed_aa_jan01,
		@ff_prec AS ff_prec,
		@aa_prec AS aa_prec,
		isnull(@floatfund_01_jan_used,0) as floatfund_01_jan_used,
		isnull(@supposed_aa_01_jan_used,0) as supposed_aa_01_jan_used,
		isnull(@aa_01_jan_used,0) as aa_01_jan_used,
		isnull(@supposed_ff_01_jan_used,0) as supposed_ff_01_jan_used,
		isnull(@supposed_aa_prec_used,0) as supposed_aa_prec_used,
		isnull(@aa_prec_used,0) as  aa_prec_used,
		isnull(@ff_prec_used,0) as  ff_prec_used,
                @boxpartitiontitle as boxpartitiontitle
FROM fin f
JOIN finlevel fl
		ON f.nlevel = fl.nlevel AND  f.ayear = fl.ayear	
		left outer join finlink 
				on finlink.idparent=f.idfin    
left outer join raggruppa_capitoli 
				on raggruppa_capitoli.idfin=finlink.idchild 
LEFT OUTER JOIN finlink flk1
	ON flk1.idchild = f.idfin AND flk1.nlevel = 1
LEFT OUTER JOIN fin f1
	ON flk1.idparent = f1.idfin 
LEFT OUTER JOIN finlink flk2
	ON flk2.idchild = f.idfin AND flk2.nlevel = 2
LEFT OUTER JOIN fin f2
	ON flk2.idparent = f2.idfin 
LEFT OUTER JOIN finlink flk3
	ON flk3.idchild = f.idfin AND flk3.nlevel = 3
LEFT OUTER JOIN fin f3
	ON flk3.idparent = f3.idfin 
LEFT OUTER JOIN finlink flk4
	ON flk4.idchild = f.idfin AND flk4.nlevel = 4
LEFT OUTER JOIN fin f4
	ON flk4.idparent = f4.idfin 
LEFT OUTER JOIN finlink flk5
	ON flk5.idchild = f.idfin AND flk5.nlevel = 5
LEFT OUTER JOIN fin f5
	ON flk5.idparent = f5.idfin 
LEFT OUTER JOIN finlink flk6
	ON flk5.idchild = f.idfin AND flk5.nlevel = 6
LEFT OUTER JOIN fin f6
	ON flk6.idparent = f6.idfin 	
where ((@MostraTutteVoci = 'S'  or @suppressifblank='N')  OR 
     (raggruppa_capitoli.idfin is not null)) AND
		f.ayear=@ayear 
		AND ((f.flag & 1)= @finpart_bit) 
		AND (f.nlevel = @levelusable_original )

		--AND (f.nlevel = @levelusable_original 
		--	OR (f.nlevel < @levelusable_original
		--		AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = f.idfin)
		--		AND (fl.flag&2)<>0
		--	   )
		--	 )
	  
	  
GROUP BY F.idfin,f.codefin,
	SUBSTRING(f.codefin, @startpos1, @lencod_lev1),
	SUBSTRING(f.codefin, @startpos2, @lencod_lev2),f2.codefin,
	SUBSTRING(f.codefin, @startpos3, @lencod_lev3),f3.codefin,
	SUBSTRING(f.codefin, @startpos4, @lencod_lev4),f4.codefin,
	SUBSTRING(f.codefin, @startpos5, @lencod_lev5),f5.codefin,
	SUBSTRING(f.codefin, @startpos6, @lencod_lev6),f6.codefin,
	SUBSTRING(f.printingorder, @startpos1, @lencod_lev1),
	SUBSTRING(f.printingorder, @startpos2, @lencod_lev2),
	SUBSTRING(f.printingorder, @startpos3, @lencod_lev3),
	SUBSTRING(f.printingorder, @startpos4, @lencod_lev4),
	SUBSTRING(f.printingorder, @startpos5, @lencod_lev5),
	SUBSTRING(f.printingorder, @startpos5, @lencod_lev6),
	f1.title,f2.title,f3.title,f4.title,f5.title,f6.title,f.printingorder,
	f.nlevel 
ORDER BY 
	f.printingorder ASC
END


--select * from raggruppa_capitoli join fin on 
--raggruppa_capitoli.idfin = fin.idfin
--end
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

