
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



if exists (select * from dbo.sysobjects where id = object_id(N'[exp_bilconsuntivo_diff_var_uff_non_uff]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_bilconsuntivo_diff_var_uff_non_uff]
GO

/****** Object:  StoredProcedure [amministrazione].[rpt_bilconsuntivo]    Script Date: 09/12/2014 10:59:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--setuser 'amm'
--update generalreportparameter set paramvalue='S' WHERE idparam = 'MostraTutteVoci'
-- exec rpt_bilconsuntivo 2013,{ts '2013-12-31 00:00:00'},'E',4,'%','N','N','S','S', null, null, null, null, null
-- Gianni - 9 12 2014 - Esportazione per Silvia Pistoia
-- Capitolo, Descrizione Capitolo, Previsione Inizialie, 
-- Variazioni Ufficiali, Previsione Attuale  (solo ufficiali), 
-- Variazioni ufficiali e non ufficiali, Previsione Attuale (variazioni ufficiali e non ufficiali) 
-- Differenza tra Previsione attuale 1 e Previsione attuale 2

CREATE PROCEDURE [exp_bilconsuntivo_diff_var_uff_non_uff]
(
	@ayear int,
	@date datetime,
	--@finpart char(1)='S',
	@levelusable tinyint=3,
	--@idupb varchar(36)='%',
	--@showupb char(1)='N',
	--@showchildupb char(1)='S',
	--@suppressifblank char(1)='S',
	--@officialvar  char(1)='S',
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
)
AS BEGIN

declare @idupb varchar(36)
SET @idupb = ''

declare @showupb char(1)
SET @showupb = 'N'

declare @showchildupb char(1)
set @showchildupb='S'

declare @suppressifblank char(1)
set @suppressifblank='S'

declare @officialvar  char(1)
set @officialvar='S'

SET @idupb = @idupb + '%' 
declare @finpart char(1)
set @finpart= 'E'

declare @fixedidupb varchar(36)
set @fixedidupb= null
if (@showupb='N') set @fixedidupb='0001'





DECLARE	@finpart_bit  tinyint  -- Parte del bilancio ( Entrata / Spesa)
if @finpart='E' set @finpart_bit = 0
if @finpart='S' set @finpart_bit = 1

declare @fin_kind tinyint
SELECT  @fin_kind = isnull(fin_kind,0) FROM config WHERE ayear = @ayear


-- Tabella da modificare per aggiungere le colonne "non ufficiali"

CREATE TABLE #data
(
	idfin int,				
	idupb varchar(36),
	initialprevision decimal(19,2),
	variazioni_ufficiali decimal(19,2),
	tutte_le_variazioni decimal(19,2),
)


DECLARE @finphase tinyint
DECLARE @maxphase tinyint
/*
IF @finpart = 'E' 
BEGIN
	SELECT @finphase = assessmentphasecode
	FROM config
	WHERE ayear = @ayear
	IF @finphase IS NULL
	BEGIN
		SELECT @finphase = incomefinphase FROM uniconfig
	END
	SELECT @maxphase = MAX(nphase) FROM incomephase
END
ELSE
BEGIN
	SELECT @finphase = appropriationphasecode
	FROM config
	WHERE ayear = @ayear
	IF @finphase IS NULL
	BEGIN
		SELECT @finphase = expensefinphase FROM uniconfig
	END
	SELECT @maxphase = MAX(nphase) FROM expensephase
END
*/

IF @finpart = 'E'
BEGIN
	
-- Per ulteriori dettagli in merito a questa modifica leggere la Documentazione del task n.4077
	
DECLARE @minoplevel tinyint
SELECT  @minoplevel = min(nlevel)
FROM 	finlevel
WHERE 	ayear = @ayear and flag&2 <> 0

DECLARE @levelusable_original tinyint	
SET @levelusable_original = @levelusable

IF(@levelusable < @minoplevel)
BEGIN
	SET @levelusable = @minoplevel
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

insert into #data (
	idfin,
	idupb,
	initialprevision
)
select finyear.idfin,isnull(@fixedidupb,finyear.idupb),
		ISNULL(SUM(finyear.prevision),0)
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
		--AND ((f5.flag & 1)= @finpart_bit) --AND f5.finpart = @finpart
		AND (f5.nlevel = @levelusable
			OR (f5.nlevel < @levelusable
				AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = f5.idfin)
				AND (fl.flag&2)<>0
			   )
			)
		--AND (@infoadvance = 'N' OR @infoadvance = 'B' OR (F5.flag & 16 =0) )-- f5.flagincomesurplus = 'N')
group by finyear.idfin,isnull(@fixedidupb,finyear.idupb)

--select SUBSTRING('123456789', 12, 5)
--tutti gli inserimenti avvengono a livello di @levelusable o inferiore se per quel ramo non esiste un livello così basso

-- INSERISCO LE VARIAZIONI UFFICIALI
INSERT INTO #data
(
	idfin,
	idupb,
	variazioni_ufficiali
)
SELECT
	ISNULL(FLK.idparent,FVD.idfin),
	isnull(@fixedidupb,FVD.idupb),
	SUM(FVD.amount)
FROM finvardetail FVD
JOIN finvar FV
	ON FV.yvar = FVD.yvar
	AND FV.nvar = FVD.nvar
JOIN fin F
	ON FVD.idfin = F.idfin
JOIN upb U
	ON FVD.idupb = U.idupb
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = FVD.idfin AND FLK.nlevel = @levelusable_original
WHERE FV.yvar = @ayear
	AND FV.adate <= @date
	AND FV.flagprevision = 'S'
	AND FV.idfinvarstatus = 5
	AND FV.variationkind <> 5
	AND
	((ISNULL(FV.official,'N') = 'S' AND ISNULL(@officialvar,'N') = 'S') -- consideriamo solo le variazioni ufficiali
	  OR ISNULL(@officialvar,'N') = 'N')
	--AND ((F.flag & 1 ) = @finpart_bit) AND F.ayear = @ayear
	AND (FVD.idupb LIKE @idupb)
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
GROUP BY isnull(@fixedidupb,FVD.idupb),ISNULL(FLK.idparent,FVD.idfin)


-- INSERISCO TUTTE LE VARIAZIONI
INSERT INTO #data
(
	idfin,
	idupb,
	tutte_le_variazioni
)
SELECT
	ISNULL(FLK.idparent,FVD.idfin),
	isnull(@fixedidupb,FVD.idupb),
	SUM(FVD.amount) 
FROM finvardetail FVD
JOIN finvar FV
	ON FV.yvar = FVD.yvar
	AND FV.nvar = FVD.nvar
JOIN  fin F
	ON FVD.idfin = F.idfin
JOIN upb U
	ON FVD.idupb = U.idupb
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = FVD.idfin AND FLK.nlevel = @levelusable_original
WHERE FV.yvar = @ayear
	AND FV.adate <= @date
	AND FV.flagprevision = 'S'
	AND FV.idfinvarstatus = 5
	AND FV.variationkind <> 5
	--AND ((F.flag & 1 ) = @finpart_bit) AND F.ayear = @ayear
	AND (FVD.idupb LIKE @idupb)
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
GROUP BY isnull(@fixedidupb,FVD.idupb),ISNULL(FLK.idparent,FVD.idfin)


/*
 Se N qualora per un capitolo non esistano sott-capitoli con legami con l'upb fondo
 NON verrà visualizzata l'indicazione del Titolo/Categoria/Capitolo
*/


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

if (@levelusable_original<5) 
	set @lev_desc5='liv5'

if (@levelusable_original<4) 
	set @lev_desc4='liv4'

if (@levelusable_original<3) 
	set @lev_desc3='liv3'


if (@levelusable_original<2) 
	set @lev_desc2='liv2'


END

declare 	@codeupb varchar(50)
declare		@upb varchar(150)
declare		@upbprintingorder varchar(50)
declare		@ext_idupb varchar(50)
set @codeupb= null
set @upb= null
set @upbprintingorder= null
set @ext_idupb= null

SELECT 
	CASE when (f.flag & 1) = 0 then 'E' else 'S' end as [Parte],
	fl.description as [Livello di Bilancio],
	f.codefin [Codice Bilancio],
	f.title	[Descrizione],
	ISNULL(SUM(initialprevision),0) AS [Previsione Iniziale],
	ISNULL(SUM(variazioni_ufficiali),0) AS	[Variazioni Ufficiali],
	ISNULL(SUM(initialprevision) + SUM(variazioni_ufficiali),0) AS [Previsione Attuale (solo variazioni ufficiali)],
	ISNULL(SUM(tutte_le_variazioni),0) AS	[Tutte le variazioni],
	ISNULL(SUM(initialprevision) + SUM(tutte_le_variazioni),0) AS [Previsione Attuale (tutte le variazioni)],
	ISNULL(SUM(initialprevision) + SUM(variazioni_ufficiali),0) -
	ISNULL(SUM(initialprevision) + SUM(tutte_le_variazioni),0) AS [Differenze]
	--case @fin_kind when 1 then 'C' else 'S' end AS previsionkind,
	
FROM fin f
	JOIN finlevel fl
		ON f.nlevel = fl.nlevel AND  f.ayear = fl.ayear	
left outer join #data on #data.idfin=f.idfin 
where 
		f.ayear=@ayear 
		--AND ((f.flag & 1)= @finpart_bit) 
		AND (f.nlevel = @levelusable_original 
			OR (f.nlevel < @levelusable_original
				AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = f.idfin)
				AND (fl.flag&2)<>0
			   )
			 )
GROUP BY 
	f.codefin,
	f.title,
	f.printingorder,
	f.nlevel,
	f.flag,
	fl.description
	--,f1.flag,f2.flag,f3.flag,f4.flag,f5.flag
ORDER BY 
	(f.flag & 1),f.printingorder ASC
END



