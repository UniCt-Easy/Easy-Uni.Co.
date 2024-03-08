
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_budgeteconomico_sun]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_budgeteconomico_sun]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
-- exec rpt_budgeteconomico_sun 2014, 58,'%','S'
CREATE      PROCEDURE [rpt_budgeteconomico_sun](
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




declare @I_PROVENTI_PROPRI decimal(19,2)
set @I_PROVENTI_PROPRI = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E11%'),0)

declare @II_CONTRIBUTI  decimal(19,2)
set  @II_CONTRIBUTI= ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E12%'),0)

declare @III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE decimal(19,2)
set @III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE =ISNULL((  SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E13%'),0)

declare @IV_PROVENTI_PER_GESTIONE_DIRETTA decimal (19,2)
set @IV_PROVENTI_PER_GESTIONE_DIRETTA = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E14%'),0)

declare @V_ALTRI_PROVENTI decimal (19,2)
set @V_ALTRI_PROVENTI = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E15%'),0)

declare @VI_VARIAZIONE_LAVORI_IN_CORSO decimal (19,2)
set @VI_VARIAZIONE_LAVORI_IN_CORSO = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E16%'),0)

declare @VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI decimal (19,2)
set @VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E17%'),0)

declare @PROVENTIOPERATIVI decimal(19,2)
SET @PROVENTIOPERATIVI= @I_PROVENTI_PROPRI+
						@II_CONTRIBUTI+
						@III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE+
						@IV_PROVENTI_PER_GESTIONE_DIRETTA +	
						@V_ALTRI_PROVENTI+
						@VI_VARIAZIONE_LAVORI_IN_CORSO+@VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI

declare @COSTI_OPERATIVI  decimal (19,2)
declare @COSTI_SPECIFICI  decimal (19,2)

declare @I_SOSTEGNO_AGLI_STUDENTI  decimal (19,2)
declare @1_Interventi_favore_degli_studenti decimal (19,2)
set @1_Interventi_favore_degli_studenti = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E2111%'),0)

declare @2_Borse_di_studio decimal (19,2)
set @2_Borse_di_studio =  ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E2112%'),0)

declare @III_Sostegno_alla_ricerca decimal (19,2)
set @III_Sostegno_alla_ricerca = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E213%'),0)

set @I_SOSTEGNO_AGLI_STUDENTI = @1_Interventi_favore_degli_studenti+
								@2_Borse_di_studio+
								@III_Sostegno_alla_ricerca

declare @II_Interventi_diritto_allo_studio decimal(19,2)
set @II_Interventi_diritto_allo_studio = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E212%'),0)

declare @IV_Personale_dedicato_alla_ricerca decimal (19,2)

declare @1_Docenti decimal (19,2)
set @1_Docenti = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E2141%'),0)

declare @2_Ricercatori decimal (19,2)
set @2_Ricercatori =  ISNULL((  SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E2142%'),0)

declare @3_Ricercatori_a_tempo_determinato decimal (19,2)
set @3_Ricercatori_a_tempo_determinato = ISNULL((  SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E2143%'),0)

declare @4_Collaborazioni_scientifiche decimal (19,2)
set @4_Collaborazioni_scientifiche =  ISNULL((  SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E2144%'),0)

declare @5_Docenti_contratto  decimal (19,2)
set @5_Docenti_contratto = ISNULL((  SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E2145%'),0)

declare @6_Esperti_linguistici  decimal (19,2)
set @6_Esperti_linguistici = ISNULL((  SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E2146%'),0)

declare @7_Altro_personale_dedicato_alla_ricerca_didattica decimal(19,2)
set @7_Altro_personale_dedicato_alla_ricerca_didattica = ISNULL((  SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E2147%'),0)

declare @8_Missioni_personale_dedicato_alla_didattica decimal (19,2)
set @8_Missioni_personale_dedicato_alla_didattica = ISNULL((  SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E2148%'),0)

declare @9_Altri_oneri_personale decimal (19,2)
set @9_Altri_oneri_personale = ISNULL((  SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E2149%'),0)
set @IV_Personale_dedicato_alla_ricerca =    @1_Docenti  +
											  @2_Ricercatori  +
											  @3_Ricercatori_a_tempo_determinato  +
											  @4_Collaborazioni_scientifiche +
											  @5_Docenti_contratto  +
											  @6_Esperti_linguistici  +
											  @7_Altro_personale_dedicato_alla_ricerca_didattica +
											  @8_Missioni_personale_dedicato_alla_didattica +
											  @9_Altri_oneri_personale 


declare @V_Acquisto_materiale decimal (19,2)
set @V_Acquisto_materiale = ISNULL((  SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E215%'),0)

declare @VI_Trasferimenti decimal (19,2)
set @VI_Trasferimenti = ISNULL((  SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E216%'),0)

declare @VII_Altri_costi_specifici  decimal (19,2)
set @VII_Altri_costi_specifici = ISNULL((  SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E217%'),0)

set @COSTI_SPECIFICI =	@I_SOSTEGNO_AGLI_STUDENTI+
						@II_Interventi_diritto_allo_studio+
						--@III_Sostegno_alla_ricerca + : è compreso in @I_SOSTEGNO_AGLI_STUDENTI. Va seguito il file Excel, non la gerarchia della classificazione.
						@IV_Personale_dedicato_alla_ricerca+
						@V_Acquisto_materiale+
						@VI_Trasferimenti+
						@VII_Altri_costi_specifici

declare @COSTI_GENERALI  decimal (19,2)

declare @I_Personale_tecnicoamministrativo  decimal (19,2)
set @I_Personale_tecnicoamministrativo =ISNULL((  SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E221%'),0)

declare @II_Acquisto_materiali  decimal (19,2)
set @II_Acquisto_materiali = ISNULL( ( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E222%'),0)

declare @III_Acquisto_libri_periodici decimal (19,2)
set @III_Acquisto_libri_periodici = ISNULL((  SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E223%'),0)

declare @IV_Acquisto_servizi decimal (19,2)
set @IV_Acquisto_servizi = ISNULL((  SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E224%'),0)

declare @V_Costi_godimento_beni decimal (19,2)
set @V_Costi_godimento_beni = ISNULL((  SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E225%'),0)

declare @VI_Altri_costi_generali  decimal (19,2)

declare @1_Utenze_canoni  decimal (19,2)
set @1_Utenze_canoni = ISNULL((  SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E2261%'),0)

declare @2_Manutenzione_ordinaria decimal (19,2)
set @2_Manutenzione_ordinaria = ISNULL((  SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E2262%'),0)

declare @3_Manutenzione_straordinaria decimal (19,2)
set @3_Manutenzione_straordinaria = ISNULL((  SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E2263%'),0)

declare @4_Altri_costi_generali decimal (19,2)
set @4_Altri_costi_generali = ISNULL((  SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E2264%'),0)

set @VI_Altri_costi_generali = @1_Utenze_canoni+@2_Manutenzione_ordinaria+@3_Manutenzione_straordinaria + @4_Altri_costi_generali

set @COSTI_GENERALI =   @I_Personale_tecnicoamministrativo   +
					  @II_Acquisto_materiali   +
					  @III_Acquisto_libri_periodici  +
					  @IV_Acquisto_servizi  +
					  @V_Costi_godimento_beni  +
					  @VI_Altri_costi_generali
set @COSTI_OPERATIVI = @COSTI_SPECIFICI + @COSTI_GENERALI

declare @DIFFERENZA_PROVENTI_E_COSTI_OPERATIVI  decimal (19,2)
set @DIFFERENZA_PROVENTI_E_COSTI_OPERATIVI= @PROVENTIOPERATIVI - @COSTI_OPERATIVI

declare @AMMORTAMENTI_SVALUTAZIONI  decimal (19,2)--  --> MANCANO
declare @ACCANTONAMENTI_RISCHI_ONERI  decimal (19,2) --> MANCANO
declare @ALTRI_ACCANTONAMENTI  decimal (19,2) --> MANCANO

declare @ONERI_DIVERSI_GESTIONE  decimal (19,2)
declare @I_Imposte_varie  decimal (19,2)
set @I_Imposte_varie = ISNULL((  SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E3111%'),0)

declare @II_Altri_oneri  decimal (19,2)
set @II_Altri_oneri = ISNULL((  SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E3112%'),0)

declare @III_Trasferimenti_correnti  decimal (19,2)
set @III_Trasferimenti_correnti = ISNULL((  SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E3113%'),0)

declare @IV_Trasferimenti_investimenti  decimal (19,2)
set @IV_Trasferimenti_investimenti = ISNULL((  SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E3114%'),0)

set @ONERI_DIVERSI_GESTIONE = @I_Imposte_varie +
							@II_Altri_oneri +
							@III_Trasferimenti_correnti +
							@IV_Trasferimenti_investimenti

declare @PROVENTI_E_ONERI_FINANZIARI  decimal (19,2)
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

set @PROVENTI_E_ONERI_FINANZIARI = @proventi - @oneri--> DA CONTROLLARE 

declare @RETTIFICHE_DI_VALORE_DI_ATTIVITA_FINANZIARIE  decimal (19,2)
declare @Svalutazioni_Rettifiche decimal(19,2)
declare @Rivalutazioni_Rettifiche decimal(19,2)

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

set @RETTIFICHE_DI_VALORE_DI_ATTIVITA_FINANZIARIE = @Rivalutazioni_Rettifiche - @Svalutazioni_Rettifiche

declare @PROVENTI_ONERI_STRAORDINARI  decimal (19,2)
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

set @PROVENTI_ONERI_STRAORDINARI = @1_PROVENTI_STRAORDINARI-@2_ONERI_STRAORDINARI
declare @IMPOSTE_TASSE  decimal (19,2)
set @IMPOSTE_TASSE = ISNULL((  SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E71%'),0)


select
  @treasurer as department,
  @I_PROVENTI_PROPRI  	as		  'I_PROVENTI_PROPRI',  
  @II_CONTRIBUTI   	as		  'II_CONTRIBUTI',   
  @III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE  	as		  'III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE', 
  @IV_PROVENTI_PER_GESTIONE_DIRETTA  	as		  'IV_PROVENTI_PER_GESTIONE_DIRETTA', 
  @V_ALTRI_PROVENTI  	as		  'V_ALTRI_PROVENTI',  
  @VI_VARIAZIONE_LAVORI_IN_CORSO  	as		  'VI_VARIAZIONE_LAVORI_IN_CORSO', 
  @VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI  	as		  'VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI', 
  @PROVENTIOPERATIVI  	as		  'PROVENTIOPERATIVI', 
  @COSTI_OPERATIVI   	as		  'COSTI_OPERATIVI',   
  @COSTI_SPECIFICI   	as		  'COSTI_SPECIFICI',   
  @I_SOSTEGNO_AGLI_STUDENTI   	as		  'I_SOSTEGNO_AGLI_STUDENTI',  
  @1_Interventi_favore_degli_studenti  	as		  '1_Interventi_favore_degli_studenti', 
  @2_Borse_di_studio  	as		  '2_Borse_di_studio', 
  @II_Interventi_diritto_allo_studio  	as		  'II_Interventi_diritto_allo_studio', 
  @III_Sostegno_alla_ricerca  	as		  'III_Sostegno_alla_ricerca',  
  @IV_Personale_dedicato_alla_ricerca  	as		  'IV_Personale_dedicato_alla_ricerca', 
  @1_Docenti  	as		  '1_Docenti', 
  @2_Ricercatori  	as		  '2_Ricercatori', 
  @3_Ricercatori_a_tempo_determinato  	as		  '3_Ricercatori_a_tempo_determinato', 
  @4_Collaborazioni_scientifiche  	as		  '4_Collaborazioni_scientifiche', 
  @5_Docenti_contratto   	as		  '5_Docenti_contratto',  
  @6_Esperti_linguistici   	as		  '6_Esperti_linguistici',   
  @7_Altro_personale_dedicato_alla_ricerca_didattica  	as		  '7_Altro_personale_dedicato_alla_ricerca_didattica', 
  @8_Missioni_personale_dedicato_alla_didattica  	as		  '8_Missioni_personale_dedicato_alla_didattica', 
  @9_Altri_oneri_personale  	as		  '9_Altri_oneri_personale', 
  @V_Acquisto_materiale  	as		  'V_Acquisto_materiale', 
  @VI_Trasferimenti  	as		  'VI_Trasferimenti', 
  @VII_Altri_costi_specifici   	as		  'VII_Altri_costi_specifici',  
  @COSTI_GENERALI   	as		  'COSTI_GENERALI',  
  @I_Personale_tecnicoamministrativo   	as		  'I_Personale_tecnicoamministrativo',  
  @II_Acquisto_materiali   	as		  'II_Acquisto_materiali',  
  @III_Acquisto_libri_periodici  	as		  'III_Acquisto_libri_periodici', 
  @IV_Acquisto_servizi  	as		  'IV_Acquisto_servizi', 
  @V_Costi_godimento_beni  	as		  'V_Costi_godimento_beni', 
  @VI_Altri_costi_generali   	as		  'VI_Altri_costi_generali', 
  @1_Utenze_canoni   	as		  '1_Utenze_canoni',  
  @2_Manutenzione_ordinaria  	as		  '2_Manutenzione_ordinaria', 
  @3_Manutenzione_straordinaria  	as		  '3_Manutenzione_straordinaria', 
  @4_Altri_costi_generali  	as		  '4_Altri_costi_generali', 
  @DIFFERENZA_PROVENTI_E_COSTI_OPERATIVI   	as		  'DIFFERENZA_PROVENTI_E_COSTI_OPERATIVI',  
  @AMMORTAMENTI_SVALUTAZIONI   	as		  'AMMORTAMENTI_SVALUTAZIONI',
  @ACCANTONAMENTI_RISCHI_ONERI    	as		  'ACCANTONAMENTI_RISCHI_ONERI',
  @ALTRI_ACCANTONAMENTI   	as		  'ALTRI_ACCANTONAMENTI',
  @ONERI_DIVERSI_GESTIONE   	as		  'ONERI_DIVERSI_GESTIONE',   
  @I_Imposte_varie   	as		  'I_Imposte_varie',   
  @II_Altri_oneri   	as		  'II_Altri_oneri',   
  @III_Trasferimenti_correnti   	as		  'III_Trasferimenti_correnti',   
  @IV_Trasferimenti_investimenti   	as		  'IV_Trasferimenti_investimenti',   
  @PROVENTI_E_ONERI_FINANZIARI   	as		  'PROVENTI_E_ONERI_FINANZIARI',   
  @proventi  	as		  'proventi',  
  @oneri  	as		  'oneri',  
  @RETTIFICHE_DI_VALORE_DI_ATTIVITA_FINANZIARIE   	as		  'RETTIFICHE_DI_VALORE_DI_ATTIVITA_FINANZIARIE',   
  @PROVENTI_ONERI_STRAORDINARI   	as		  'PROVENTI_ONERI_STRAORDINARI',   
  @1_PROVENTI_STRAORDINARI   	as		  '1_PROVENTI_STRAORDINARI',   
  @2_ONERI_STRAORDINARI   	as		  '2_ONERI_STRAORDINARI',   
  @IMPOSTE_TASSE   	as		  'IMPOSTE_TASSE'  

				
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


