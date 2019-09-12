if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_budgeteconomico_sun_dettagliato]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_budgeteconomico_sun_dettagliato]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
-- exec rpt_budgeteconomico_sun_dettagliato 2015, 15,'%','S'
--exec rpt_budgeteconomico_sun_dettagliato 2015, 58,'%','S' 
CREATE      PROCEDURE [rpt_budgeteconomico_sun_dettagliato](
	@ayear int,
	@idsorkind int,
	@idupb varchar(36)='%',
	@showchildupb char(1)='S',
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
)
AS BEGIN
declare @treasurer varchar(150)
if(@idupb = '%') 
Begin
	select @treasurer = null
end
Else
Begin
	select @treasurer = isnull(T.header, T.description) from upb U
						join treasurer T
							ON T.idtreasurer = U.idtreasurer
						where U.idupb = @idupb
End

IF (@showchildupb = 'S')
BEGIN
	SET @idupb = @idupb + '%' 
END

create table #dati(
	department varchar(200),
	prevision decimal (19,2),
	sortcode varchar(50),
	idsor int,
	nlevel int
)
insert into #dati(department, prevision, sortcode, idsor, nlevel)
SELECT 
	@treasurer ,
	isnull(sum(budgetprevision.prevision),0),
	S.sortcode,
	S.idsor,
	S.nlevel
FROM sorting S
join budgetprevision
	on budgetprevision.idsor = S.idsor
JOIN upb U
	ON budgetprevision.idupb = U.idupb
WHERE budgetprevision.ayear = @ayear
	and S.idsorkind = @idsorkind
	AND U.idupb like @idupb
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	and S.sortcode like 'E%'
group by S.sortcode,S.idsor,S.nlevel

insert into #dati(department, prevision, sortcode, idsor, nlevel)
SELECT 
	@treasurer ,
	0,
	S.sortcode,
	S.idsor,
	S.nlevel
FROM sorting S
join sortinglevel SL
	on S.nlevel = SL.nlevel
WHERE S.idsorkind = @idsorkind
	and SL.idsorkind = @idsorkind
		AND (S.nlevel = 6
			OR (S.nlevel < 6 
				AND not EXISTS (SELECT * FROM sorting WHERE sorting.paridsor = S.idsor)
				AND (SL.flag&2)<>0
			   )
			)	
	and S.sortcode like 'E%'			
	and (select COUNT(*) from #dati where idsor = S.idsor) = 0
	

DECLARE @lencod_lev1 int
SELECT @lencod_lev1 = 1-- flag / 256 FROM sortinglevel WHERE idsorkind = @idsorkind AND nlevel = 1
DECLARE @startpos1 int
SELECT @startpos1 = 1
DECLARE @lencod_lev2 int
SELECT @lencod_lev2 = 1--flag / 256 FROM sortinglevel WHERE idsorkind = @idsorkind AND nlevel = 2
DECLARE @startpos2 int
SELECT @startpos2 = @startpos1 + @lencod_lev1
DECLARE @lencod_lev3 int
SELECT @lencod_lev3 = 1--flag / 256 FROM sortinglevel WHERE idsorkind = @idsorkind AND nlevel = 3
DECLARE @startpos3 int
SELECT @startpos3 = @startpos2 + @lencod_lev2
DECLARE @lencod_lev4 int
SELECT @lencod_lev4 = 1--flag / 256 FROM sortinglevel WHERE idsorkind = @idsorkind AND nlevel = 4
DECLARE @startpos4 int
SELECT @startpos4 = @startpos3 + @lencod_lev3
DECLARE @lencod_lev5 int 
SELECT @lencod_lev5 = 1--flag / 256 FROM sortinglevel WHERE idsorkind = @idsorkind AND nlevel = 5
DECLARE @startpos5 int 
SELECT @startpos5 = @startpos4 + @lencod_lev4
DECLARE @lencod_lev6 int 
SELECT @lencod_lev6 = 2--flag / 256 FROM sortinglevel WHERE idsorkind = @idsorkind AND nlevel = 6
DECLARE @startpos6 int 
SELECT @startpos6 = @startpos5 + @lencod_lev5



DECLARE @lev_desc1 varchar(50)
SELECT @lev_desc1 = description FROM sortinglevel WHERE idsorkind = @idsorkind AND nlevel = 1
DECLARE @lev_desc2 varchar(50)
SELECT @lev_desc2 = description FROM sortinglevel WHERE idsorkind = @idsorkind AND nlevel = 2
DECLARE @lev_desc3 varchar(50)
SELECT @lev_desc3 = description FROM sortinglevel WHERE idsorkind = @idsorkind AND nlevel = 3
DECLARE @lev_desc4 varchar(50)
SELECT @lev_desc4 = description FROM sortinglevel WHERE idsorkind = @idsorkind AND nlevel = 4
DECLARE @lev_desc5 varchar(50)
SELECT @lev_desc5 = description FROM sortinglevel WHERE idsorkind = @idsorkind AND nlevel = 5
DECLARE @lev_desc6 varchar(50)
SELECT @lev_desc6 = description FROM sortinglevel WHERE idsorkind = @idsorkind AND nlevel = 6


SELECT
	S.idsor,
	SUBSTRING(S.sortcode, @startpos1, @lencod_lev1) as code1,
	S1.description AS desc1,
	@lev_desc1 AS descliv1,
	SUBSTRING(S.printingorder, @startpos1, @lencod_lev1) as order1,
	
	CASE when (S2.sortcode is null) then null
		else SUBSTRING(S.sortcode, @startpos2, @lencod_lev2) 
	end	as code2,
	S2.description AS desc2,
	@lev_desc2 AS descliv2,
	SUBSTRING(S.printingorder, @startpos2, @lencod_lev2) as order2,
	
	case when (S3.sortcode is null) then null
		else SUBSTRING(S.sortcode, @startpos3, @lencod_lev3)
	end	 as code3,
	S3.description as desc3,
	@lev_desc3 as descliv3,
	SUBSTRING(S.printingorder, @startpos3, @lencod_lev3) as order3,
	
	case when (S4.sortcode is null) then null
		else	SUBSTRING(S.sortcode, @startpos4, @lencod_lev4)
	end	as code4,
	S4.description AS desc4,
	@lev_desc4 AS descliv4,
	SUBSTRING(S.printingorder, @startpos4, @lencod_lev4) as order4,
	
	case when (S5.sortcode is null) then null
		else SUBSTRING(S.sortcode, @startpos5, @lencod_lev5) 
	end	as code5,
	S5.description AS desc5,
	@lev_desc5 AS descliv5,
	SUBSTRING(S.printingorder, @startpos5, @lencod_lev5) as order5,
	
	case when (S6.sortcode is null) then null
		else SUBSTRING(S.sortcode, @startpos6, @lencod_lev6) 
	end	as code6,
	S6.description AS desc6,
	@lev_desc6 AS descliv6,
	SUBSTRING(S.printingorder, @startpos6, @lencod_lev6) as order6,
	D.prevision, 
	D.sortcode
from #dati D
join sorting S
	on D.idsor = S.idsor
join sortinglevel SL
	on S.nlevel = SL.nlevel and SL.idsorkind = @idsorkind
LEFT OUTER JOIN sortinglink slk1
	ON slk1.idchild = S.idsor AND slk1.nlevel = 1
LEFT OUTER JOIN sorting S1
	ON slk1.idparent = S1.idsor 
LEFT OUTER JOIN sortinglink slk2
	ON slk2.idchild = S.idsor AND slk2.nlevel = 2
LEFT OUTER JOIN sorting S2
	ON slk2.idparent = S2.idsor 
LEFT OUTER JOIN sortinglink slk3
	ON slk3.idchild = S.idsor AND slk3.nlevel = 3
LEFT OUTER JOIN sorting S3
	ON slk3.idparent = S3.idsor 
LEFT OUTER JOIN sortinglink slk4
	ON slk4.idchild = S.idsor AND slk4.nlevel = 4
LEFT OUTER JOIN sorting S4
	ON slk4.idparent = S4.idsor 
LEFT OUTER JOIN sortinglink slk5
	ON slk5.idchild = S.idsor AND slk5.nlevel = 5
LEFT OUTER JOIN sorting S5
	ON slk5.idparent = S5.idsor 
LEFT OUTER JOIN sortinglink slk6
	ON slk6.idchild = S.idsor AND slk6.nlevel = 6
LEFT OUTER JOIN sorting S6
	ON slk6.idparent = S6.idsor 
Order by S.sortcode

/*
declare @PROVENTIOPERATIVI decimal(19,2)
SET @PROVENTIOPERATIVI= ISNULL(( SELECT SUM(budgetprevision.prevision)
FROM budgetprevision 
join sorting S
	on budgetprevision.idsor = S.idsor
JOIN upb U
	ON budgetprevision.idupb = U.idupb
WHERE budgetprevision.ayear = @ayear
	and S.idsorkind = @idsorkind
	AND U.idupb like @idupb
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	AND S.sortcode LIKE 'E1%'),0)

declare @COSTI_OPERATIVI decimal (19,2)
set @COSTI_OPERATIVI = ISNULL((  SELECT SUM(budgetprevision.prevision)
FROM budgetprevision 
join sorting S
	on budgetprevision.idsor = S.idsor
JOIN upb U
	ON budgetprevision.idupb = U.idupb
WHERE budgetprevision.ayear = @ayear
	and S.idsorkind = @idsorkind
	AND U.idupb like @idupb
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	AND S.sortcode LIKE 'E2%'),0)

declare @DIFFERENZA_PROVENTI_E_COSTI_OPERATIVI  decimal (19,2)
set @DIFFERENZA_PROVENTI_E_COSTI_OPERATIVI= @PROVENTIOPERATIVI - @COSTI_OPERATIVI--> DIFFERENZA


declare @proventi decimal(19,2)
set @proventi = ISNULL((  SELECT SUM(budgetprevision.prevision)
FROM budgetprevision 
join sorting S
	on budgetprevision.idsor = S.idsor
JOIN upb U
	ON budgetprevision.idupb = U.idupb
WHERE budgetprevision.ayear = @ayear
	and S.idsorkind = @idsorkind
	AND U.idupb like @idupb
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	AND S.sortcode LIKE 'E5111%'),0)

declare @oneri decimal(19,2)
set @oneri = ISNULL((  SELECT SUM(budgetprevision.prevision)
FROM budgetprevision 
join sorting S
	on budgetprevision.idsor = S.idsor
JOIN upb U
	ON budgetprevision.idupb = U.idupb
WHERE budgetprevision.ayear = @ayear
	and S.idsorkind = @idsorkind
	AND U.idupb like @idupb
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	AND S.sortcode LIKE 'E5112%'),0)

declare @PROVENTI_E_ONERI_sortingANZIARI  decimal (19,2)
set @PROVENTI_E_ONERI_sortingANZIARI = @proventi - @oneri--> DA CONTROLLARE 


declare @Svalutazioni_Rettifiche decimal(19,2)
set @Svalutazioni_Rettifiche = ISNULL((  SELECT SUM(budgetprevision.prevision)
FROM budgetprevision 
join sorting S
	on budgetprevision.idsor = S.idsor
JOIN upb U
	ON budgetprevision.idupb = U.idupb
WHERE budgetprevision.ayear = @ayear
	and S.idsorkind = @idsorkind
	AND U.idupb like @idupb
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	AND S.sortcode LIKE 'E411201%'),0)

declare @Rivalutazioni_Rettifiche decimal(19,2)
set @Rivalutazioni_Rettifiche = ISNULL((  SELECT SUM(budgetprevision.prevision)
FROM budgetprevision 
join sorting S
	on budgetprevision.idsor = S.idsor
JOIN upb U
	ON budgetprevision.idupb = U.idupb
WHERE budgetprevision.ayear = @ayear
	and S.idsorkind = @idsorkind
	AND U.idupb like @idupb
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	AND S.sortcode LIKE 'E411101%'),0)

declare @RETTIFICHE_DI_VALORE_DI_ATTIVITA_sortingANZIARIE  decimal (19,2)
set @RETTIFICHE_DI_VALORE_DI_ATTIVITA_sortingANZIARIE = @Rivalutazioni_Rettifiche - @Svalutazioni_Rettifiche --> DIFFERENZA

declare @1_PROVENTI_STRAORDINARI  decimal (19,2)
set @1_PROVENTI_STRAORDINARI = ISNULL((  SELECT SUM(budgetprevision.prevision)
FROM budgetprevision 
join sorting S
	on budgetprevision.idsor = S.idsor
JOIN upb U
	ON budgetprevision.idupb = U.idupb
WHERE budgetprevision.ayear = @ayear
	and S.idsorkind = @idsorkind
	AND U.idupb like @idupb
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	AND S.sortcode LIKE 'E611%'),0)

declare @2_ONERI_STRAORDINARI  decimal (19,2)
set @2_ONERI_STRAORDINARI = ISNULL( ( SELECT SUM(budgetprevision.prevision)
FROM budgetprevision 
join sorting S
	on budgetprevision.idsor = S.idsor
JOIN upb U
	ON budgetprevision.idupb = U.idupb
WHERE budgetprevision.ayear = @ayear
	and S.idsorkind = @idsorkind
	AND U.idupb like @idupb
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	AND S.sortcode LIKE 'E612%'),0)

declare @PROVENTI_ONERI_STRAORDINARI  decimal (19,2)
set @PROVENTI_ONERI_STRAORDINARI = @1_PROVENTI_STRAORDINARI-@2_ONERI_STRAORDINARI --> DIFFERENZA
*/

/*select
  @treasurer as department,
  @DIFFERENZA_PROVENTI_E_COSTI_OPERATIVI   	as		  'DIFFERENZA_PROVENTI_E_COSTI_OPERATIVI',  
  @PROVENTI_E_ONERI_sortingANZIARI   	as		  'PROVENTI_E_ONERI_sortingANZIARI',   
  @RETTIFICHE_DI_VALORE_DI_ATTIVITA_sortingANZIARIE   	as		  'RETTIFICHE_DI_VALORE_DI_ATTIVITA_sortingANZIARIE',   
  @PROVENTI_ONERI_STRAORDINARI   	as		  'PROVENTI_ONERI_STRAORDINARI'   
*/

END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 

