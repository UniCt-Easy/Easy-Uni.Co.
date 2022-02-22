
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_bilprevisionesorting_mpsiope]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_bilprevisionesorting_mpsiope]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

 
-- exec rpt_bilprevisionesorting_mpsiope 2018, 68, 47, '%', 'S', 'S',  null,null,null,null,null
CREATE  PROCEDURE [rpt_bilprevisionesorting_mpsiope]
	@ayear			int,

	@idsorkind_siope int, --> Classificazione Siope
	@idsorkind_missprog	int, --> Classificazione Missioni Programmi

	@idupb			varchar(36),
	@showupb char(1)='N',
	@showchildupb char(1),

	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null 
AS
BEGIN
/* IMPORTANTE:
La parte Spesa elabora gli UPB classificati con Missioni Programmi, e le voci di bilancio classificate con DI_394_08.06.17 Uscite
Mostra i codici class. di Missioni Programmi e DI_394_08.06.17 Uscite

La parte Entrata elabora le voci di bilancio classificate con DI_394_08.06.17 Entrate
Mostra gli UPB e i codici classificazione DI_394_08.06.17 Entrate
*/
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

DECLARE	@finpart_bit  tinyint  -- Parte del bilancio (Entrata / Spesa)
set @finpart_bit = 1

CREATE TABLE #situation
(
	idupb 			varchar(36),
	idsor_MissProg int,
	idsor_siope int,
	idfin			int,
	initialprevision decimal(19,2),
	previousprevision decimal(19,2),
	secondaryprevision decimal(19,2),
	previoussecondaryprev decimal(19,2),
	currentarrears decimal(19,2),
	previousarrears decimal(19,2),
	nlevel			tinyint
)

IF @ayear IS NULL 
BEGIN
	SELECT * FROM  #situation 
	RETURN
END

/*declare @nlevel tinyint
SELECT  @nlevel = max(nlevel)
FROM 	finlevel
WHERE 	ayear = @ayear and flag&2 <> 0
*/
IF 	(@showchildupb = 'S') set @idupb=@idupb+'%' 

/*DECLARE @levelusable tinyint
SELECT  @levelusable = MIN(nlevel) 
FROM 	finlevel
WHERE 	ayear =@ayear and (flag&2)<>0
*/


-- Legge le previsioni e le moltiplica per la quota della Classificazione Missione e Programmi
	INSERT INTO #situation(
		idfin,nlevel,
		idupb,
		idsor_MissProg,
		idsor_siope,
		initialprevision,previousprevision,secondaryprevision,previoussecondaryprev,currentarrears,previousarrears
	)
	SELECT 
		F.idfin, F.nlevel,
		U.idupb,
		US.idsor,
		FS.idsor,
		ISNULL(SUM(finyear.prevision*ISNULL(US.quota,0)*ISNULL(FS.quota,0)),0),	
		ISNULL(SUM(finyear.previousprevision*ISNULL(US.quota,0)*ISNULL(FS.quota,0)),0),	
		ISNULL(SUM(finyear.secondaryprev*ISNULL(US.quota,0)*ISNULL(FS.quota,0)),0),	
		ISNULL(SUM(finyear.previoussecondaryprev*ISNULL(US.quota,0)*ISNULL(FS.quota,0)),0),	
		ISNULL(SUM(finyear.currentarrears*ISNULL(US.quota,0)*ISNULL(FS.quota,0)),0),	
		ISNULL(SUM(finyear.previousarrears*ISNULL(US.quota,0)*ISNULL(FS.quota,0)),0)
	FROM upbsorting US
	cross join finsorting FS
	join finyear
			on US.idupb = finyear.idupb and FS.idfin = finyear.idfin
	join sorting SortUpb
		ON SortUpb.idsor = US.idsor	
	JOIN sorting sorFin
			ON sorFin.idsor = FS.idsor		
	JOIN upb  U
		ON  finyear.idupb = U.idupb
	JOIN fin F
		ON finyear.idfin = F.idfin
	WHERE ((F.flag & 1)= @finpart_bit) 
		AND (finyear.ayear = @ayear)
		AND (U.idupb LIKE @idupb)
		and SortUpb.idsorkind = @idsorkind_MissProg
		AND sorFin.idsorkind = @idsorkind_siope
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	GROUP BY  U.idupb, US.idsor, FS.idsor,F.idfin, F.nlevel


declare	@Sorkind	varchar(50)--> Classificazione Missioni Programmi
select @Sorkind = description from sortingkind where idsorkind = @idsorkind_MissProg

declare @levelparent varchar(50) --> Nome del 1° livello della classificazione Missioni/Programmi
declare @levelchild varchar(50)--> Nome del 2° livello della classificazione Missioni/Programmi
select @levelparent = description from sortinglevel where idsorkind = @idsorkind_MissProg and nlevel = 1
select @levelchild = description from sortinglevel where idsorkind = @idsorkind_MissProg and nlevel = 2

IF (@showupb ='S')
BEGIN

 	SELECT 
		@levelparent as levelparent_mp,
		@levelchild as levelchild_mp,
		U.codeupb,
		#situation.idupb,
		U.title as 'upb',
		U.printingorder as 'upbprintingorder',
		S1.sortcode as code_mp,
		S1.description as sorting_mp,
		SortPar1.description as sortingparent_mp,
		SortPar1.sortcode as codeparent_mp,

		S2.sortcode as code_siope,
		S2.description as sorting_siope,

		case	when @fin_kind = 3 then isnull(sum(previoussecondaryprev),0)
				when @fin_kind in (1,2) then sum(isnull(previousprevision,0) + isnull(currentarrears,0))
		end as prevision_prec,

		case	when @fin_kind = 3 then isnull(sum(secondaryprevision),0)
				when @fin_kind in (1,2) then sum(isnull(initialprevision,0) + isnull(currentarrears,0))
		end as prevision_curr
 	FROM #situation 
	JOIN upb U
		on #situation.idupb = U.idupb
-- Missione e Programmi
	left outer join sorting S1
		ON S1.idsor = #situation.idsor_MissProg	and S1.idsorkind = @idsorkind_MissProg		
	left outer join sorting SortPar1 
		on S1.paridsor = SortPar1.idsor	 and SortPar1.idsorkind = @idsorkind_MissProg		
-- Siope 
	left outer join sorting S2
		ON S2.idsor = #situation.idsor_siope	and S2.idsorkind = @idsorkind_siope
	GROUP BY U.codeupb,
		#situation.idupb,
		U.title,	U.printingorder,
		S1.sortcode,		S1.description,		SortPar1.description,		SortPar1.sortcode,
		S2.sortcode ,		S2.description 
	ORDER BY S1.sortcode, U.printingorder
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
 	SELECT 
		@levelparent as levelparent_mp,
		@levelchild as levelchild_mp,
		@codeupb as codeupb,
		@ext_idupb as idupb,
		@upb as upb,
		@upbprintingorder as upbprintingorder,
		S1.sortcode as code_mp,
		S1.description as sorting_mp,
		SortPar1.description as sortingparent_mp,
		SortPar1.sortcode as codeparent_mp,

		S2.sortcode as code_siope,
		S2.description as sorting_siope,

		case	when @fin_kind = 3 then isnull(sum(previoussecondaryprev),0)
				when @fin_kind in (1,2) then sum(isnull(previousprevision,0) + isnull(currentarrears,0))
		end as prevision_prec,

		case	when @fin_kind = 3 then isnull(sum(secondaryprevision),0)
				when @fin_kind in (1,2) then sum(isnull(initialprevision,0) + isnull(currentarrears,0))
		end as prevision_curr
 	FROM #situation 
-- Missione e Programmi
	left outer join sorting S1
		ON S1.idsor = #situation.idsor_MissProg	and S1.idsorkind = @idsorkind_MissProg		
	left outer join sorting SortPar1 
		on S1.paridsor = SortPar1.idsor	 and SortPar1.idsorkind = @idsorkind_MissProg		
-- Siope 
	left outer join sorting S2
		ON S2.idsor = #situation.idsor_siope	and S2.idsorkind = @idsorkind_siope
	GROUP BY S1.sortcode,		S1.description,		SortPar1.description,		SortPar1.sortcode,
		S2.sortcode ,		S2.description 
	ORDER BY S1.sortcode

END

END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




