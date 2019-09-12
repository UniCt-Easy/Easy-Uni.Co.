if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_bilprevisionesortingaccount_mpsiope]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_bilprevisionesortingaccount_mpsiope]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

 
-- exec rpt_bilprevisionesortingaccount_mpsiope 2018, 70, 47, '%', 'S', 'S',  null,null,null,null,null
CREATE  PROCEDURE [rpt_bilprevisionesortingaccount_mpsiope]
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
	@idsor05 int=null ,
	@suppressifblank char(1)='S'
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
	idacc			varchar(38),
	prevision_curr decimal(19,2),
	nlevel			tinyint
)

IF @ayear IS NULL 
BEGIN
	SELECT * FROM  #situation 
	RETURN
END

IF 	(@showchildupb = 'S') set @idupb=@idupb+'%' 



-- Legge le previsioni e le moltiplica per la quota della Classificazione Missione e Programmi
	INSERT INTO #situation(
		idacc,nlevel,
		idupb,
		idsor_MissProg,
		idsor_siope,
		prevision_curr
	)
	SELECT 
		A.idacc, A.nlevel,
		U.idupb,
		US.idsor,
		ACCS.idsor,
		ISNULL(SUM(accountvardetail.prevcassa*ISNULL(US.quota,0)*ISNULL(ACCS.quota,0)),0)	
	FROM upbsorting US
	cross join accountsorting ACCS
	join accountvardetail
			on US.idupb = accountvardetail.idupb and ACCS.idacc = accountvardetail.idacc
	join sorting SortUpb
		ON SortUpb.idsor = US.idsor	
	JOIN sorting sortAcc
			ON sortAcc.idsor = ACCS.idsor		
	JOIN upb U
		ON accountvardetail.idupb = U.idupb
	JOIN account A
		ON accountvardetail.idacc = A.idacc
	join placcount
		on A.idplaccount = placcount.idplaccount
	WHERE /*((F.flag & 1)= @finpart_bit) 
		AND */(A.ayear = @ayear)
		AND (U.idupb LIKE @idupb)
		and SortUpb.idsorkind = @idsorkind_MissProg
		AND sortAcc.idsorkind = @idsorkind_siope
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		and placcount.placcpart='C'
	GROUP BY  U.idupb, US.idsor, ACCS.idsor, A.idacc, A.nlevel
	

declare	@Sorkind	varchar(50)--> Classificazione Missioni Programmi
select @Sorkind = description from sortingkind where idsorkind = @idsorkind_MissProg

declare @levelparent varchar(50) --> Nome del 1° livello della classificazione Missioni/Programmi
declare @levelchild varchar(50)--> Nome del 2° livello della classificazione Missioni/Programmi
select @levelparent = description from sortinglevel where idsorkind = @idsorkind_MissProg and nlevel = 1
select @levelchild = description from sortinglevel where idsorkind = @idsorkind_MissProg and nlevel = 2

if(@suppressifblank='S')
Begin
	delete from #situation where isnull(prevision_curr,0)=0
End

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
		isnull(sum(#situation.prevision_curr),0) as prevision_curr
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
		isnull(sum(prevision_curr),0) as prevision_curr
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

