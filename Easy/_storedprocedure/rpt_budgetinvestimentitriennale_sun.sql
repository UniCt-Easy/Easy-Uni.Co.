
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_budgetinvestimentitriennale_sun]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_budgetinvestimentitriennale_sun]
GO
/****** Object:  StoredProcedure [rpt_budgetinvestimentitriennale_sun]    Script Date: 10/11/2014 11.24.35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- exec rpt_budgetinvestimenti_sun 2014, 15,'%','S'
create      PROCEDURE [rpt_budgetinvestimentitriennale_sun](
	@ayear int,--> anno del bilancio di previsione
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

/*
Gianni 27/10/2014 versione triennale dipartimentale della SP rpt_budgetinvestimenti_sun già esistente
*/

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

/*Anno 1*/

declare @IMMOBILIZZAZIONI decimal(19,2)
declare @I_IMMATERIALI decimal(19,2)

declare @1_Costi_impianto decimal(19,2)
set @1_Costi_impianto = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'I1111%'),0)

declare @2_Diritti_brevetto decimal(19,2)
set @2_Diritti_brevetto = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'I1112%'),0)

declare @3_Concessioni_licenze decimal(19,2)
set @3_Concessioni_licenze = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'I1113%'),0)

declare @4_Immobilizzazioni_immateriali_corso_acconti decimal(19,2)
set @4_Immobilizzazioni_immateriali_corso_acconti =ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'I1114%'),0)

declare @5_Altre_immobilizzazioni_immateriali decimal(19,2)
set @5_Altre_immobilizzazioni_immateriali = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'I1115%'),0)

set @I_IMMATERIALI = @1_Costi_impianto + @2_Diritti_brevetto + @3_Concessioni_licenze + @4_Immobilizzazioni_immateriali_corso_acconti + @5_Altre_immobilizzazioni_immateriali
	
declare @II_MATERIALI decimal(19,2)
declare @1_Terreni_fabbricati decimal(19,2)
set @1_Terreni_fabbricati =ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'I1121%'),0)

declare @2_Impianti_attrezzature decimal(19,2)
set @2_Impianti_attrezzature= ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'I1122%'),0)

declare @3_Attrezzature_scientifiche decimal(19,2)
set @3_Attrezzature_scientifiche =ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'I1123%'),0)

declare @4_Patrimonio_librario decimal(19,2)
set @4_Patrimonio_librario=ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'I1124%'),0)

declare @5_Mobili_arredi decimal(19,2)
set @5_Mobili_arredi =ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'I1125%'),0)

declare @6_Immobilizzazioni_materiali_corso_acconti decimal(19,2)
set @6_Immobilizzazioni_materiali_corso_acconti =ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'I1126%'),0)

declare @7_Altre_immobilizzazioni_materiali decimal(19,2)
set @7_Altre_immobilizzazioni_materiali =ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'I1127%'),0)

	
set @II_MATERIALI = @1_Terreni_fabbricati
				+ @2_Impianti_attrezzature
				+ @3_Attrezzature_scientifiche
				+ @4_Patrimonio_librario
				+ @5_Mobili_arredi
				+ @6_Immobilizzazioni_materiali_corso_acconti
				+ @7_Altre_immobilizzazioni_materiali

declare @III_FINANZIARIE decimal(19,2)
set @III_FINANZIARIE = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'I113%'),0)
	
SET @IMMOBILIZZAZIONI = @I_IMMATERIALI + @II_MATERIALI + @III_FINANZIARIE

declare @INVESTIMENTI_RICERCA decimal(19,2)
set @INVESTIMENTI_RICERCA = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'I2%'),0)

/*Anno 2*/

declare @IMMOBILIZZAZIONI_ANNO_2 decimal(19,2)
declare @I_IMMATERIALI_ANNO_2 decimal(19,2)

declare @1_Costi_impianto_ANNO_2 decimal(19,2)
set @1_Costi_impianto_ANNO_2 = ISNULL(( SELECT SUM(budgetprevision.prevision2)
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
		AND S.sortcode LIKE 'I1111%'),0)

declare @2_Diritti_brevetto_ANNO_2 decimal(19,2)
set @2_Diritti_brevetto_ANNO_2 = ISNULL(( SELECT SUM(budgetprevision.prevision2)
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
		AND S.sortcode LIKE 'I1112%'),0)

declare @3_Concessioni_licenze_ANNO_2 decimal(19,2)
set @3_Concessioni_licenze_ANNO_2 = ISNULL(( SELECT SUM(budgetprevision.prevision2)
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
		AND S.sortcode LIKE 'I1113%'),0)

declare @4_Immobilizzazioni_immateriali_corso_acconti_ANNO_2 decimal(19,2)
set @4_Immobilizzazioni_immateriali_corso_acconti_ANNO_2 =ISNULL(( SELECT SUM(budgetprevision.prevision2)
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
		AND S.sortcode LIKE 'I1114%'),0)

declare @5_Altre_immobilizzazioni_immateriali_ANNO_2 decimal(19,2)
set @5_Altre_immobilizzazioni_immateriali_ANNO_2 = ISNULL(( SELECT SUM(budgetprevision.prevision2)
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
		AND S.sortcode LIKE 'I1115%'),0)

set @I_IMMATERIALI_ANNO_2 = @1_Costi_impianto_ANNO_2 
						+ @2_Diritti_brevetto_ANNO_2 + 
						@3_Concessioni_licenze_ANNO_2 + 
						@4_Immobilizzazioni_immateriali_corso_acconti_ANNO_2 + 
						@5_Altre_immobilizzazioni_immateriali_ANNO_2
	
declare @II_MATERIALI_ANNO_2 decimal(19,2)
declare @1_Terreni_fabbricati_ANNO_2 decimal(19,2)
set @1_Terreni_fabbricati_ANNO_2 =ISNULL(( SELECT SUM(budgetprevision.prevision2)
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
		AND S.sortcode LIKE 'I1121%'),0)

declare @2_Impianti_attrezzature_ANNO_2 decimal(19,2)
set @2_Impianti_attrezzature_ANNO_2= ISNULL(( SELECT SUM(budgetprevision.prevision2)
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
		AND S.sortcode LIKE 'I1122%'),0)

declare @3_Attrezzature_scientifiche_ANNO_2 decimal(19,2)
set @3_Attrezzature_scientifiche_ANNO_2 =ISNULL(( SELECT SUM(budgetprevision.prevision2)
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
		AND S.sortcode LIKE 'I1123%'),0)

declare @4_Patrimonio_librario_ANNO_2 decimal(19,2)
set @4_Patrimonio_librario_ANNO_2=ISNULL(( SELECT SUM(budgetprevision.prevision2)
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
		AND S.sortcode LIKE 'I1124%'),0)

declare @5_Mobili_arredi_ANNO_2 decimal(19,2)
set @5_Mobili_arredi_ANNO_2 =ISNULL(( SELECT SUM(budgetprevision.prevision2)
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
		AND S.sortcode LIKE 'I1125%'),0)

declare @6_Immobilizzazioni_materiali_corso_acconti_ANNO_2 decimal(19,2)
set @6_Immobilizzazioni_materiali_corso_acconti_ANNO_2 =ISNULL(( SELECT SUM(budgetprevision.prevision2)
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
		AND S.sortcode LIKE 'I1126%'),0)

declare @7_Altre_immobilizzazioni_materiali_ANNO_2 decimal(19,2)
set @7_Altre_immobilizzazioni_materiali_ANNO_2 =ISNULL(( SELECT SUM(budgetprevision.prevision2)
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
		AND S.sortcode LIKE 'I1127%'),0)

	
set @II_MATERIALI_ANNO_2 = @1_Terreni_fabbricati_ANNO_2
				+ @2_Impianti_attrezzature_ANNO_2
				+ @3_Attrezzature_scientifiche_ANNO_2
				+ @4_Patrimonio_librario_ANNO_2
				+ @5_Mobili_arredi_ANNO_2
				+ @6_Immobilizzazioni_materiali_corso_acconti_ANNO_2
				+ @7_Altre_immobilizzazioni_materiali_ANNO_2

declare @III_FINANZIARIE_ANNO_2 decimal(19,2)
set @III_FINANZIARIE_ANNO_2 = ISNULL(( SELECT SUM(budgetprevision.prevision2)
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
		AND S.sortcode LIKE 'I113%'),0)
	
SET @IMMOBILIZZAZIONI_ANNO_2 = @I_IMMATERIALI_ANNO_2 + @II_MATERIALI_ANNO_2 + @III_FINANZIARIE_ANNO_2

declare @INVESTIMENTI_RICERCA_ANNO_2 decimal(19,2)
set @INVESTIMENTI_RICERCA_ANNO_2 = ISNULL(( SELECT SUM(budgetprevision.prevision2)
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
		AND S.sortcode LIKE 'I2%'),0)

/*Anno 3*/

declare @IMMOBILIZZAZIONI_ANNO_3 decimal(19,2)
declare @I_IMMATERIALI_ANNO_3 decimal(19,2)

declare @1_Costi_impianto_ANNO_3 decimal(19,2)
set @1_Costi_impianto_ANNO_3= ISNULL(( SELECT SUM(budgetprevision.prevision3)
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
		AND S.sortcode LIKE 'I1111%'),0)

declare @2_Diritti_brevetto_ANNO_3 decimal(19,2)
set @2_Diritti_brevetto_ANNO_3= ISNULL(( SELECT SUM(budgetprevision.prevision3)
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
		AND S.sortcode LIKE 'I1112%'),0)

declare @3_Concessioni_licenze_ANNO_3 decimal(19,2)
set @3_Concessioni_licenze_ANNO_3= ISNULL(( SELECT SUM(budgetprevision.prevision3)
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
		AND S.sortcode LIKE 'I1113%'),0)

declare @4_Immobilizzazioni_immateriali_corso_acconti_ANNO_3 decimal(19,2)
set @4_Immobilizzazioni_immateriali_corso_acconti_ANNO_3=ISNULL(( SELECT SUM(budgetprevision.prevision3)
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
		AND S.sortcode LIKE 'I1114%'),0)

declare @5_Altre_immobilizzazioni_immateriali_ANNO_3 decimal(19,2)
set @5_Altre_immobilizzazioni_immateriali_ANNO_3= ISNULL(( SELECT SUM(budgetprevision.prevision3)
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
		AND S.sortcode LIKE 'I1115%'),0)

set @I_IMMATERIALI_ANNO_3= @1_Costi_impianto_ANNO_3
						+ @2_Diritti_brevetto_ANNO_3+ 
						@3_Concessioni_licenze_ANNO_3+ 
						@4_Immobilizzazioni_immateriali_corso_acconti_ANNO_3+ 
						@5_Altre_immobilizzazioni_immateriali_ANNO_2
	
declare @II_MATERIALI_ANNO_3 decimal(19,2)
declare @1_Terreni_fabbricati_ANNO_3 decimal(19,2)
set @1_Terreni_fabbricati_ANNO_3=ISNULL(( SELECT SUM(budgetprevision.prevision3)
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
		AND S.sortcode LIKE 'I1121%'),0)

declare @2_Impianti_attrezzature_ANNO_3 decimal(19,2)
set @2_Impianti_attrezzature_ANNO_2= ISNULL(( SELECT SUM(budgetprevision.prevision3)
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
		AND S.sortcode LIKE 'I1122%'),0)

declare @3_Attrezzature_scientifiche_ANNO_3 decimal(19,2)
set @3_Attrezzature_scientifiche_ANNO_3=ISNULL(( SELECT SUM(budgetprevision.prevision3)
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
		AND S.sortcode LIKE 'I1123%'),0)

declare @4_Patrimonio_librario_ANNO_3 decimal(19,2)
set @4_Patrimonio_librario_ANNO_2=ISNULL(( SELECT SUM(budgetprevision.prevision3)
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
		AND S.sortcode LIKE 'I1124%'),0)

declare @5_Mobili_arredi_ANNO_3 decimal(19,2)
set @5_Mobili_arredi_ANNO_3=ISNULL(( SELECT SUM(budgetprevision.prevision3)
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
		AND S.sortcode LIKE 'I1125%'),0)

declare @6_Immobilizzazioni_materiali_corso_acconti_ANNO_3 decimal(19,2)
set @6_Immobilizzazioni_materiali_corso_acconti_ANNO_3=ISNULL(( SELECT SUM(budgetprevision.prevision3)
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
		AND S.sortcode LIKE 'I1126%'),0)

declare @7_Altre_immobilizzazioni_materiali_ANNO_3 decimal(19,2)
set @7_Altre_immobilizzazioni_materiali_ANNO_3=ISNULL(( SELECT SUM(budgetprevision.prevision3)
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
		AND S.sortcode LIKE 'I1127%'),0)

	
set @II_MATERIALI_ANNO_3= @1_Terreni_fabbricati_ANNO_2
				+ @2_Impianti_attrezzature_ANNO_2
				+ @3_Attrezzature_scientifiche_ANNO_2
				+ @4_Patrimonio_librario_ANNO_2
				+ @5_Mobili_arredi_ANNO_2
				+ @6_Immobilizzazioni_materiali_corso_acconti_ANNO_2
				+ @7_Altre_immobilizzazioni_materiali_ANNO_2

declare @III_FINANZIARIE_ANNO_3 decimal(19,2)
set @III_FINANZIARIE_ANNO_3= ISNULL(( SELECT SUM(budgetprevision.prevision3)
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
		AND S.sortcode LIKE 'I113%'),0)
	
SET @IMMOBILIZZAZIONI_ANNO_3= @I_IMMATERIALI_ANNO_3+ @II_MATERIALI_ANNO_3+ @III_FINANZIARIE_ANNO_2

declare @INVESTIMENTI_RICERCA_ANNO_3 decimal(19,2)
set @INVESTIMENTI_RICERCA_ANNO_3= ISNULL(( SELECT SUM(budgetprevision.prevision3)
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
		AND S.sortcode LIKE 'I2%'),0)



select
  @treasurer											as department,

  /*Anno 1*/
  @IMMOBILIZZAZIONI  									as			 'IMMOBILIZZAZIONI'  		,
  @I_IMMATERIALI  										as			 'I_IMMATERIALI'  		,
  @1_Costi_impianto										as			 '1_Costi_impianto'		,
  @2_Diritti_brevetto  									as			 '2_Diritti_brevetto'  		,
  @3_Concessioni_licenze  								as			 '3_Concessioni_licenze'  		,
  @4_Immobilizzazioni_immateriali_corso_acconti  		as			 '4_Immobilizzazioni_immateriali_corso_acconti'  		,
  @5_Altre_immobilizzazioni_immateriali  				as			 '5_Altre_immobilizzazioni_immateriali'  		,
  @II_MATERIALI  										as			 'II_MATERIALI'  		,
  @1_Terreni_fabbricati  								as			 '1_Terreni_fabbricati'  		,
  @2_Impianti_attrezzature  							as			 '2_Impianti_attrezzature'  		,
  @3_Attrezzature_scientifiche  						as			 '3_Attrezzature_scientifiche'  		,
  @4_Patrimonio_librario  								as			 '4_Patrimonio_librario'  		,
  @5_Mobili_arredi  									as			 '5_Mobili_arredi'  		,
  @6_Immobilizzazioni_materiali_corso_acconti  			as			 '6_Immobilizzazioni_materiali_corso_acconti'  		,
  @7_Altre_immobilizzazioni_materiali  					as			 '7_Altre_immobilizzazioni_materiali'  		,
  @III_FINANZIARIE  									as			 'III_FINANZIARIE'  		,
  @INVESTIMENTI_RICERCA  								as			 'INVESTIMENTI_RICERCA',		

  /*Anno 2*/

  @IMMOBILIZZAZIONI_ANNO_2  									as			 'IMMOBILIZZAZIONI_ANNO_2'  		,
  @I_IMMATERIALI_ANNO_2  										as			 'I_IMMATERIALI_ANNO_2'  		,
  @1_Costi_impianto_ANNO_2										as			 '1_Costi_impianto_ANNO_2'		,
  @2_Diritti_brevetto_ANNO_2  									as			 '2_Diritti_brevetto_ANNO_2'  		,
  @3_Concessioni_licenze_ANNO_2  								as			 '3_Concessioni_licenze_ANNO_2'  		,
  @4_Immobilizzazioni_immateriali_corso_acconti_ANNO_2  		as			 '4_Immobilizzazioni_immateriali_corso_acconti_ANNO_2'  		,
  @5_Altre_immobilizzazioni_immateriali_ANNO_2  				as			 '5_Altre_immobilizzazioni_immateriali_ANNO_2'  		,
  @II_MATERIALI_ANNO_2  										as			 'II_MATERIALI_ANNO_2'  		,
  @1_Terreni_fabbricati_ANNO_2  								as			 '1_Terreni_fabbricati_ANNO_2'  		,
  @2_Impianti_attrezzature_ANNO_2  								as			 '2_Impianti_attrezzature_ANNO_2'  		,
  @3_Attrezzature_scientifiche_ANNO_2  							as			 '3_Attrezzature_scientifiche_ANNO_2'  		,
  @4_Patrimonio_librario_ANNO_2  								as			 '4_Patrimonio_librario_ANNO_2'  		,
  @5_Mobili_arredi_ANNO_2  										as			 '5_Mobili_arredi_ANNO_2'  		,
  @6_Immobilizzazioni_materiali_corso_acconti_ANNO_2  			as			 '6_Immobilizzazioni_materiali_corso_acconti_ANNO_2'  		,
  @7_Altre_immobilizzazioni_materiali_ANNO_2  					as			 '7_Altre_immobilizzazioni_materiali_ANNO_2'  		,
  @III_FINANZIARIE_ANNO_2  										as			 'III_FINANZIARIE_ANNO_2'  		,
  @INVESTIMENTI_RICERCA_ANNO_2  								as			 'INVESTIMENTI_RICERCA_ANNO_2',			
  
  /*Anno 3*/

  @IMMOBILIZZAZIONI_ANNO_3  									as			 'IMMOBILIZZAZIONI_ANNO_3'  		,
  @I_IMMATERIALI_ANNO_3  										as			 'I_IMMATERIALI_ANNO_3'  		,
  @1_Costi_impianto_ANNO_3										as			 '1_Costi_impianto_ANNO_3'		,
  @2_Diritti_brevetto_ANNO_3  									as			 '2_Diritti_brevetto_ANNO_3'  		,
  @3_Concessioni_licenze_ANNO_3  								as			 '3_Concessioni_licenze_ANNO_3'  		,
  @4_Immobilizzazioni_immateriali_corso_acconti_ANNO_3  		as			 '4_Immobilizzazioni_immateriali_corso_acconti_ANNO_3'  		,
  @5_Altre_immobilizzazioni_immateriali_ANNO_3  				as			 '5_Altre_immobilizzazioni_immateriali_ANNO_3'  		,
  @II_MATERIALI_ANNO_3  										as			 'II_MATERIALI_ANNO_3'  		,
  @1_Terreni_fabbricati_ANNO_3  								as			 '1_Terreni_fabbricati_ANNO_3'  		,
  @2_Impianti_attrezzature_ANNO_3  								as			 '2_Impianti_attrezzature_ANNO_3'  		,
  @3_Attrezzature_scientifiche_ANNO_3  							as			 '3_Attrezzature_scientifiche_ANNO_3'  		,
  @4_Patrimonio_librario_ANNO_3  								as			 '4_Patrimonio_librario_ANNO_3'  		,
  @5_Mobili_arredi_ANNO_3  										as			 '5_Mobili_arredi_ANNO_3'  		,
  @6_Immobilizzazioni_materiali_corso_acconti_ANNO_3  			as			 '6_Immobilizzazioni_materiali_corso_acconti_ANNO_3'  		,
  @7_Altre_immobilizzazioni_materiali_ANNO_3  					as			 '7_Altre_immobilizzazioni_materiali_ANNO_3'  		,
  @III_FINANZIARIE_ANNO_3  										as			 'III_FINANZIARIE_ANNO_3'  		,
  @INVESTIMENTI_RICERCA_ANNO_3  								as			 'INVESTIMENTI_RICERCA_ANNO_3'	
  	
END

