
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



if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_budgeteconomico_triennale_all]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_budgeteconomico_triennale_all]
GO

/****** Object:  StoredProcedure [amministrazione].[rpt_bilconsuntivo]    Script Date: 09/12/2014 10:59:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- exec AMMINISTRAZIONE.rpt_budgeteconomico_triennale_all 2014, 21,'%','S'

/* 
GIANNI 15-12-2014
STAMPA DEL BUDGET ECONOMICO TRIENNALE PER TUTTI  
*/

CREATE      PROCEDURE [rpt_budgeteconomico_triennale_all](
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


/* PREVISIONI DELL'ESERCIZIO CORRENTE ANNO 1*/

/*I PROVENTI OPERATIVI SONO CALCOLATI DA UNA FORMULA*/


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
set @COSTI_OPERATIVI = ISNULL(( SELECT SUM(budgetprevision.prevision)
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


/* Le prossime due sono calcolate come somme*/
declare @COSTI_SPECIFICI  decimal (19,2)

declare @I_SOSTEGNO_AGLI_STUDENTI  decimal (19,2)


/*new @VIII_Costi_del_Personale*/
/*E21	Costi del Personale													*/
declare @VIII_Costi_del_Personale decimal (19,2)
set @VIII_Costi_del_Personale = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E21%'),0)


/*1) Costi del personale dedicato alla ricerca e alla didattica */
/*E211	Costi del personale dedicato alla ricerca e alla didattica			*/
declare @1_Costi_personale_dedicato_ricerca_didattica decimal (19,2)
set @1_Costi_personale_dedicato_ricerca_didattica = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E211%'),0)


/*a) Docenti e Ricercatori*/
/*E2111	Docenti e Ricercatori												*/

declare @a_Docenti_e_Ricercatori decimal (19,2)
set @a_Docenti_e_Ricercatori = ISNULL(( SELECT SUM(budgetprevision.prevision)
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

/*b) Collaborazioni scientifiche	*/
/*E2112	Collaborazioni scientifiche											*/
declare @b_Collaborazioni_scientifiche decimal (19,2)
set @b_Collaborazioni_scientifiche =  ISNULL(( SELECT SUM(budgetprevision.prevision)
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

/*E2113	Docenti a contratto												*/	
/* c) Docenti a contratto */
declare @c_Docenti_a_contratto decimal (19,2)
set @c_Docenti_a_contratto =  ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E2113%'),0)

/*E2114	Esperti e linquistici												*/
/* d) Esperti e linquistici */
declare @d_Esperti_e_linquistici decimal (19,2)
set @d_Esperti_e_linquistici =  ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E2114%'),0)


/*E2115	Altro personale dedicato alla ricerca e didattica					*/
/*    e) Altro personale dedicato alla ricerca e didattica	*/
declare @e_Altro_personale_dedicato_ricerca_didattica decimal (19,2)
set @e_Altro_personale_dedicato_ricerca_didattica = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E2115%'),0)

/*E2116	Altri oneri per il personale dedicato alla ricerca e didattica		*/
/*  f) Altri oneri per il personale dedicato alla ricerca e didattica	*/
declare @f_Altri_oneri_personale_dedicato_ricerca_didattica decimal (19,2)
set @f_Altri_oneri_personale_dedicato_ricerca_didattica = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E2116%'),0)


/*
2) Costi del personale dedicato ai servizi generali e amministrativi		
E212	Costi del personale dedicato ai servizi generali e amministrativi
*/

declare @2_Costi_personale_dedicato_servizi_generali_amministrativi decimal (19,2)
set @2_Costi_personale_dedicato_servizi_generali_amministrativi = ISNULL(( SELECT SUM(budgetprevision.prevision)
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

/*
a) Costi del personale dirigente e T.A.		
E2121	Costi del personale dirigente e T.A.
*/
declare @a_Costi_personale_dirigente_e_TA decimal (19,2)
set @a_Costi_personale_dirigente_e_TA = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E2121%'),0)


/*
b) Altro personale amministrativo		
E2122	Altro personale amministrativo
*/
declare @b_Altro_personale_amministrativo decimal (19,2)
set @b_Altro_personale_amministrativo = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E2122%'),0)


/*
c) Altri onei per il personale amministrativo		
E2123	Altri onei per il personale amministrativo
*/

declare @c_Altri_oneri_personale_amministrativo	 decimal (19,2)
set @c_Altri_oneri_personale_amministrativo = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E2123%'),0)

/*
IX Costi della Gestione corrente		
E22	Costi della Gestione corrente
*/

declare @IX_Costi_Gestione_corrente	 decimal (19,2)
set @IX_Costi_Gestione_corrente = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E22%'),0)

	
/*
1) Costi per il sostegno agli studenti
E221	Costi per il sostegno agli studenti
*/

declare @1_Costi_sostegno_studenti	 decimal (19,2)
set @1_Costi_sostegno_studenti = ISNULL(( SELECT SUM(budgetprevision.prevision)
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


/*
2) Costi per il diritto allo studio
E222	Costi per il diritto allo studio
*/

declare @2_Costi_diritto_allo_studio	 decimal (19,2)
set @2_Costi_diritto_allo_studio = ISNULL(( SELECT SUM(budgetprevision.prevision)
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


/*
3) Costi per la ricerca e l'attività editoriale
E223	Costi per la ricerca e l'attività editoriale
*/

declare @3_Costi_ricerca_e_attivita_editoriale	 decimal (19,2)
set @3_Costi_ricerca_e_attivita_editoriale = ISNULL(( SELECT SUM(budgetprevision.prevision)
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

/*
4) Aquisto materiale di consumo per laboratori
E224	Aquisto materiale di consumo per laboratori
*/

declare @4_Acquisto_materiale_consumo_per_laboratori	 decimal (19,2)
set @4_Acquisto_materiale_consumo_per_laboratori = ISNULL(( SELECT SUM(budgetprevision.prevision)
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

/*
5) Acquisto libri, periodici e materiale bibliografico
E225	Acquisto libri, periodici e materiale bibliografico
*/

declare @5_Acquisto_libri_periodici_e_materiale_bibliografico	 decimal (19,2)
set @5_Acquisto_libri_periodici_e_materiale_bibliografico = ISNULL(( SELECT SUM(budgetprevision.prevision)
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


/*
6) Acquisto di servizi e collaborazioni tecnico gestionali
E226	Acquisto di servizi e collaborazioni tecnico gestionali
*/

declare @6_Acquisto_servizi_collaborazioni_tecnico_gestionali	 decimal (19,2)
set @6_Acquisto_servizi_collaborazioni_tecnico_gestionali = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E226%'),0)

/*
7) Acquisto altri materiali
E227	Acquisto altri materiali
*/
declare @7_Acquisto_altri_materiali	 decimal (19,2)
set @7_Acquisto_altri_materiali = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E227%'),0)


/*
8) Costi per il godimento beni di terzi
E228	Costi per il godimento beni di terzi
*/

declare @8_Costi_per_godimento_beni_di_terzi	 decimal (19,2)
set @8_Costi_per_godimento_beni_di_terzi = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E228%'),0)


/*
9) Altri costi operativi
E229	Altri costi operativi
*/

declare @9_Altri_costi_operativi	 decimal (19,2)
set @9_Altri_costi_operativi = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E229%'),0)

/*
10) Trasferimenti e contributi
E22A	Trasferimenti e contributi
*/
declare @10_Trasferimenti_e_contributi	 decimal (19,2)
set @10_Trasferimenti_e_contributi = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E22A%'),0)


/*
a) Trasferimento a partner per progetti coordinati
E22A1	Trasferimento a partner per progetti coordinati
*/

declare @a_Trasferimento_a_partner_progetti_coordinati	 decimal (19,2)
set @a_Trasferimento_a_partner_progetti_coordinati = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E22A1%'),0)


/*
b) Contributi per investimenti in ricerca
E22A2	Contributi per investimenti in ricerca
*/

declare @b_Contributi_per_investimenti_ricerca	 decimal (19,2)
set @b_Contributi_per_investimenti_ricerca = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E22A2%'),0)


/*
c) Trasferimenti correnti
E22A3	Trasferimenti correnti
*/

declare @c_Trasferimenti_correnti	 decimal (19,2)
set @c_Trasferimenti_correnti = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E22A3%'),0)


/*
d) Trasferimenti in conto capitale
E22A4	Trasferimenti in conto capitale
*/
declare @d_Trasferimenti_conto_capitale	 decimal (19,2)
set @d_Trasferimenti_conto_capitale = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E22A4%'),0)

/*
X  Ammortamenti e Svalutazioni
E23	Ammortamenti e Svalutazioni
*/

declare @X_Ammortamenti_e_Svalutazioni	 decimal (19,2)
set @X_Ammortamenti_e_Svalutazioni = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E23%'),0)

/*
1) Ammortamenti
E231	Ammortamenti
*/
declare @1_Ammortamenti	 decimal (19,2)
set @1_Ammortamenti = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E231%'),0)
/*
2) Svalutazioni
E232	Svalutazioni
*/
declare @2_Svalutazioni	 decimal (19,2)
set @2_Svalutazioni = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E232%'),0)
/*
XI Accantonamenti per rischi e oneri
E24	Accantonamenti per rischi e oneri
*/
declare @XI_Accantonamenti_rischi_oneri	 decimal (19,2)
set @XI_Accantonamenti_rischi_oneri = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E24%'),0)
/*
XII Budget economico dei Progetti di ricerca
E25	Budget economico dei Progetti di ricerca
*/
declare @XII_Budget_economico_progetti_ricerca	 decimal (19,2)
set @XII_Budget_economico_progetti_ricerca = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E25%'),0)

------------------------------------------------------------------------------------------------------------------------------------------

/* Gestione Operativa(A-B) 
A = @PROVENTIOPERATIVI	E1 calcolati da una somma
B = @COSTI_OPERATIVI	E2
*/

declare @Gestione_Operativa	 decimal (19,2)
set @Gestione_Operativa = @PROVENTIOPERATIVI - @COSTI_OPERATIVI


/* C) Proventi e Oneri finanziari E31	Proventi e Oneri finanziari - Non può essere una somma  */

/*
1) Proventi Finanziari e utili su cambi
E311	Proventi Finanziari e utili su cambi
*/
declare @1_Proventi_Finanziari_utili_su_cambi	 decimal (19,2)
set @1_Proventi_Finanziari_utili_su_cambi = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E311%'),0)
/*
2) Oneri Finanziari e perdite su cambi
E312	Oneri Finanziari e perdite su cambi
*/
declare @2_Oneri_Finanziari_perdite_cambi	 decimal (19,2)
set @2_Oneri_Finanziari_perdite_cambi = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E312%'),0)

/* D) Rettifiche di valore di attività finanziarie E41	Rettifiche di valore di attività finanziarie - Non può essere una somma */

/*
1) Rivalutazioni attività finanziarie
E411	Rivalutazioni attività finanziarie
*/
declare @1_Rivalutazioni_attivita_finanziarie	 decimal (19,2)
set @1_Rivalutazioni_attivita_finanziarie = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E411%'),0)
/*
2) Svalutazioni attività finanziarie
E412	Svalutazioni attività finanziarie
*/
declare @2_Svalutazioni_attivita_finanziarie	 decimal (19,2)
set @2_Svalutazioni_attivita_finanziarie = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E412%'),0)

------------------------------------------------------------------------------------------------------------------------------------------
/*Gestione finanziaria (C1 + D1 - C2 -D2) 
C1 = codice @1_Proventi_Finanziari_utili_su_cambi	E311 "C 1) Proventi Finanziari e utili su cambi"
D1 = codice @1_Rivalutazioni_attivita_finanziarie	E411 "D 1) Rivalutazioni attività finanziarie"
C2 = codice @2_Oneri_Finanziari_perdite_cambi		E312 "C 2) Oneri Finanziari e perdite su cambi"
D2 = codice @2_Svalutazioni_attivita_finanziarie	E412 "D 2) Svalutazioni attività finanziarie"
*/

declare @Gestione_Finanziaria	 decimal (19,2)
set @Gestione_Finanziaria = @1_Proventi_Finanziari_utili_su_cambi + 
							@1_Rivalutazioni_attivita_finanziarie -
							@2_Oneri_Finanziari_perdite_cambi -
							@2_Svalutazioni_attivita_finanziarie


/* E) Proventi e oneri straordinari E51	Proventi e oneri straordinari -Non può essere una somma */

/*
1) Proventi straordinari
E511	Proventi straordinari
*/
declare @1_Proventi_straordinari	 decimal (19,2)
set @1_Proventi_straordinari = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E511%'),0)


/*
2) Oneri Straordinari
E512	Oneri Straordinari
*/
declare @2_Oneri_straordinari	 decimal (19,2)
set @2_Oneri_straordinari = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E512%'),0)
--------------------------------------------------------------------------------------------------------------------------------

/* Gestione straordinaria (E1 - E2) 
E1 = @1_Proventi_straordinari	codice E511	"E 1) Proventi straordinari"
E2 = @2_Oneri_straordinari		codice E512	"E 2) Oneri Straordinari"
*/

declare @Gestione_Straordinaria	 decimal (19,2)
set @Gestione_Straordinaria = @1_Proventi_straordinari -  @2_Oneri_straordinari


/*
F) Imposte e tasse
E6	Imposte e tasse
*/

declare @F_Imposte_e_tasse	 decimal (19,2)
set @F_Imposte_e_tasse = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'E6%'),0)



/* PREVISIONI DELL'ESERCIZIO CORRENTE ANNO 2*/

/*I PROVENTI OPERATIVI SONO CALCOLATI DA UNA FORMULA*/


declare @I_PROVENTI_PROPRI_ANNO2 decimal(19,2)
set @I_PROVENTI_PROPRI_ANNO2 = ISNULL(( SELECT SUM(budgetprevision.prevision2)
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

declare @II_CONTRIBUTI_ANNO2  decimal(19,2)
set  @II_CONTRIBUTI_ANNO2= ISNULL(( SELECT SUM(budgetprevision.prevision2)
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

declare @III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE_ANNO2 decimal(19,2)
set @III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE_ANNO2 =ISNULL((  SELECT SUM(budgetprevision.prevision2)
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

declare @IV_PROVENTI_PER_GESTIONE_DIRETTA_ANNO2 decimal (19,2)
set @IV_PROVENTI_PER_GESTIONE_DIRETTA_ANNO2 = ISNULL(( SELECT SUM(budgetprevision.prevision2)
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

declare @V_ALTRI_PROVENTI_ANNO2 decimal (19,2)
set @V_ALTRI_PROVENTI_ANNO2 = ISNULL(( SELECT SUM(budgetprevision.prevision2)
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

declare @VI_VARIAZIONE_LAVORI_IN_CORSO_ANNO2 decimal (19,2)
set @VI_VARIAZIONE_LAVORI_IN_CORSO_ANNO2 = ISNULL(( SELECT SUM(budgetprevision.prevision2)
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

declare @VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI_ANNO2 decimal (19,2)
set @VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI_ANNO2 = ISNULL(( SELECT SUM(budgetprevision.prevision2)
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

declare @PROVENTIOPERATIVI_ANNO2 decimal(19,2)
SET @PROVENTIOPERATIVI_ANNO2= @I_PROVENTI_PROPRI_ANNO2+
						@II_CONTRIBUTI_ANNO2+
						@III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE_ANNO2+
						@IV_PROVENTI_PER_GESTIONE_DIRETTA_ANNO2 +	
						@V_ALTRI_PROVENTI_ANNO2+
						@VI_VARIAZIONE_LAVORI_IN_CORSO_ANNO2+@VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI_ANNO2



declare @COSTI_OPERATIVI_ANNO2  decimal (19,2)
set @COSTI_OPERATIVI_ANNO2 = ISNULL(( SELECT SUM(budgetprevision.prevision2)
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


/* Le prossime due sono calcolate come somme*/
declare @COSTI_SPECIFICI_ANNO2  decimal (19,2)

declare @I_SOSTEGNO_AGLI_STUDENTI_ANNO2  decimal (19,2)


/*new @VIII_Costi_del_Personale*/
/*E21	Costi del Personale													*/
declare @VIII_Costi_del_Personale_ANNO2 decimal (19,2)
set @VIII_Costi_del_Personale_ANNO2 = ISNULL(( SELECT SUM(budgetprevision.prevision2)
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
	AND S.sortcode LIKE 'E21%'),0)


/*1) Costi del personale dedicato alla ricerca e alla didattica */
/*E211	Costi del personale dedicato alla ricerca e alla didattica			*/
declare @1_Costi_personale_dedicato_ricerca_didattica_ANNO2 decimal (19,2)
set @1_Costi_personale_dedicato_ricerca_didattica_ANNO2 = ISNULL(( SELECT SUM(budgetprevision.prevision2)
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
	AND S.sortcode LIKE 'E211%'),0)


/*a) Docenti e Ricercatori*/
/*E2111	Docenti e Ricercatori												*/

declare @a_Docenti_e_Ricercatori_ANNO2 decimal (19,2)
set @a_Docenti_e_Ricercatori_ANNO2 = ISNULL(( SELECT SUM(budgetprevision.prevision2)
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

/*b) Collaborazioni scientifiche	*/
/*E2112	Collaborazioni scientifiche											*/
declare @b_Collaborazioni_scientifiche_ANNO2 decimal (19,2)
set @b_Collaborazioni_scientifiche_ANNO2 =  ISNULL(( SELECT SUM(budgetprevision.prevision2)
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

/*E2113	Docenti a contratto												*/	
/* c) Docenti a contratto */
declare @c_Docenti_a_contratto_ANNO2 decimal (19,2)
set @c_Docenti_a_contratto_ANNO2 =  ISNULL(( SELECT SUM(budgetprevision.prevision2)
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
	AND S.sortcode LIKE 'E2113%'),0)

/*E2114	Esperti e linquistici												*/
/* d) Esperti e linquistici */
declare @d_Esperti_e_linquistici_ANNO2 decimal (19,2)
set @d_Esperti_e_linquistici_ANNO2 =  ISNULL(( SELECT SUM(budgetprevision.prevision2)
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
	AND S.sortcode LIKE 'E2114%'),0)


/*E2115	Altro personale dedicato alla ricerca e didattica					*/
/*    e) Altro personale dedicato alla ricerca e didattica	*/
declare @e_Altro_personale_dedicato_ricerca_didattica_ANNO2 decimal (19,2)
set @e_Altro_personale_dedicato_ricerca_didattica_ANNO2 = ISNULL(( SELECT SUM(budgetprevision.prevision2)
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
	AND S.sortcode LIKE 'E2115%'),0)

/*E2116	Altri oneri per il personale dedicato alla ricerca e didattica		*/
/*  f) Altri oneri per il personale dedicato alla ricerca e didattica	*/
declare @f_Altri_oneri_personale_dedicato_ricerca_didattica_ANNO2 decimal (19,2)
set @f_Altri_oneri_personale_dedicato_ricerca_didattica_ANNO2 = ISNULL(( SELECT SUM(budgetprevision.prevision2)
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
	AND S.sortcode LIKE 'E2116%'),0)


/*
2) Costi del personale dedicato ai servizi generali e amministrativi		
E212	Costi del personale dedicato ai servizi generali e amministrativi
*/

declare @2_Costi_personale_dedicato_servizi_generali_amministrativi_ANNO2 decimal (19,2)
set @2_Costi_personale_dedicato_servizi_generali_amministrativi_ANNO2 = ISNULL(( SELECT SUM(budgetprevision.prevision2)
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

/*
a) Costi del personale dirigente e T.A.		
E2121	Costi del personale dirigente e T.A.
*/
declare @a_Costi_personale_dirigente_e_TA_ANNO2 decimal (19,2)
set @a_Costi_personale_dirigente_e_TA_ANNO2 = ISNULL(( SELECT SUM(budgetprevision.prevision2)
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
	AND S.sortcode LIKE 'E2121%'),0)


/*
b) Altro personale amministrativo		
E2122	Altro personale amministrativo
*/
declare @b_Altro_personale_amministrativo_ANNO2 decimal (19,2)
set @b_Altro_personale_amministrativo_ANNO2 = ISNULL(( SELECT SUM(budgetprevision.prevision2)
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
	AND S.sortcode LIKE 'E2122%'),0)


/*
c) Altri onei per il personale amministrativo		
E2123	Altri onei per il personale amministrativo
*/

declare @c_Altri_oneri_personale_amministrativo_ANNO2	 decimal (19,2)
set @c_Altri_oneri_personale_amministrativo_ANNO2= ISNULL(( SELECT SUM(budgetprevision.prevision2)
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
	AND S.sortcode LIKE 'E2123%'),0)

/*
IX Costi della Gestione corrente		
E22	Costi della Gestione corrente
*/

declare @IX_Costi_Gestione_corrente_ANNO2	 decimal (19,2)
set @IX_Costi_Gestione_corrente_ANNO2 = ISNULL(( SELECT SUM(budgetprevision.prevision2)
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
	AND S.sortcode LIKE 'E22%'),0)

	
/*
1) Costi per il sostegno agli studenti
E221	Costi per il sostegno agli studenti
*/

declare @1_Costi_sostegno_studenti_ANNO2	 decimal (19,2)
set @1_Costi_sostegno_studenti_ANNO2 = ISNULL(( SELECT SUM(budgetprevision.prevision2)
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


/*
2) Costi per il diritto allo studio
E222	Costi per il diritto allo studio
*/

declare @2_Costi_diritto_allo_studio_ANNO2	 decimal (19,2)
set @2_Costi_diritto_allo_studio_ANNO2 = ISNULL(( SELECT SUM(budgetprevision.prevision2)
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


/*
3) Costi per la ricerca e l'attività editoriale
E223	Costi per la ricerca e l'attività editoriale
*/

declare @3_Costi_ricerca_e_attivita_editoriale_ANNO2	 decimal (19,2)
set @3_Costi_ricerca_e_attivita_editoriale_ANNO2 = ISNULL(( SELECT SUM(budgetprevision.prevision2)
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

/*
4) Aquisto materiale di consumo per laboratori
E224	Aquisto materiale di consumo per laboratori
*/

declare @4_Acquisto_materiale_consumo_per_laboratori_ANNO2	 decimal (19,2)
set @4_Acquisto_materiale_consumo_per_laboratori_ANNO2 = ISNULL(( SELECT SUM(budgetprevision.prevision2)
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

/*
5) Acquisto libri, periodici e materiale bibliografico
E225	Acquisto libri, periodici e materiale bibliografico
*/

declare @5_Acquisto_libri_periodici_e_materiale_bibliografico_ANNO2	 decimal (19,2)
set @5_Acquisto_libri_periodici_e_materiale_bibliografico_ANNO2 = ISNULL(( SELECT SUM(budgetprevision.prevision2)
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


/*
6) Acquisto di servizi e collaborazioni tecnico gestionali
E226	Acquisto di servizi e collaborazioni tecnico gestionali
*/

declare @6_Acquisto_servizi_collaborazioni_tecnico_gestionali_ANNO2	 decimal (19,2)
set @6_Acquisto_servizi_collaborazioni_tecnico_gestionali_ANNO2 = ISNULL(( SELECT SUM(budgetprevision.prevision2)
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
	AND S.sortcode LIKE 'E226%'),0)

/*
7) Acquisto altri materiali
E227	Acquisto altri materiali
*/
declare @7_Acquisto_altri_materiali_ANNO2	 decimal (19,2)
set @7_Acquisto_altri_materiali_ANNO2 = ISNULL(( SELECT SUM(budgetprevision.prevision2)
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
	AND S.sortcode LIKE 'E227%'),0)


/*
8) Costi per il godimento beni di terzi
E228	Costi per il godimento beni di terzi
*/

declare @8_Costi_per_godimento_beni_di_terzi_ANNO2	 decimal (19,2)
set @8_Costi_per_godimento_beni_di_terzi_ANNO2 = ISNULL(( SELECT SUM(budgetprevision.prevision2)
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
	AND S.sortcode LIKE 'E228%'),0)


/*
9) Altri costi operativi
E229	Altri costi operativi
*/

declare @9_Altri_costi_operativi_ANNO2	 decimal (19,2)
set @9_Altri_costi_operativi_ANNO2 = ISNULL(( SELECT SUM(budgetprevision.prevision2)
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
	AND S.sortcode LIKE 'E229%'),0)

/*
10) Trasferimenti e contributi
E22A	Trasferimenti e contributi
*/
declare @10_Trasferimenti_e_contributi_ANNO2	 decimal (19,2)
set @10_Trasferimenti_e_contributi_ANNO2 = ISNULL(( SELECT SUM(budgetprevision.prevision2)
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
	AND S.sortcode LIKE 'E22A%'),0)


/*
a) Trasferimento a partner per progetti coordinati
E22A1	Trasferimento a partner per progetti coordinati
*/

declare @a_Trasferimento_a_partner_progetti_coordinati_ANNO2	 decimal (19,2)
set @a_Trasferimento_a_partner_progetti_coordinati_ANNO2 = ISNULL(( SELECT SUM(budgetprevision.prevision2)
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
	AND S.sortcode LIKE 'E22A1%'),0)


/*
b) Contributi per investimenti in ricerca
E22A2	Contributi per investimenti in ricerca
*/

declare @b_Contributi_per_investimenti_ricerca_ANNO2	 decimal (19,2)
set @b_Contributi_per_investimenti_ricerca_ANNO2 = ISNULL(( SELECT SUM(budgetprevision.prevision2)
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
	AND S.sortcode LIKE 'E22A2%'),0)


/*
c) Trasferimenti correnti
E22A3	Trasferimenti correnti
*/

declare @c_Trasferimenti_correnti_ANNO2	 decimal (19,2)
set @c_Trasferimenti_correnti_ANNO2 = ISNULL(( SELECT SUM(budgetprevision.prevision2)
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
	AND S.sortcode LIKE 'E22A3%'),0)


/*
d) Trasferimenti in conto capitale
E22A4	Trasferimenti in conto capitale
*/
declare @d_Trasferimenti_conto_capitale_ANNO2	 decimal (19,2)
set @d_Trasferimenti_conto_capitale_ANNO2 = ISNULL(( SELECT SUM(budgetprevision.prevision2)
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
	AND S.sortcode LIKE 'E22A4%'),0)

/*
X  Ammortamenti e Svalutazioni
E23	Ammortamenti e Svalutazioni
*/

declare @X_Ammortamenti_e_Svalutazioni_ANNO2	 decimal (19,2)
set @X_Ammortamenti_e_Svalutazioni_ANNO2 = ISNULL(( SELECT SUM(budgetprevision.prevision2)
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
	AND S.sortcode LIKE 'E23%'),0)

/*
1) Ammortamenti
E231	Ammortamenti
*/
declare @1_Ammortamenti_ANNO2	 decimal (19,2)
set @1_Ammortamenti_ANNO2 = ISNULL(( SELECT SUM(budgetprevision.prevision2)
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
	AND S.sortcode LIKE 'E231%'),0)
/*
2) Svalutazioni
E232	Svalutazioni
*/
declare @2_Svalutazioni_ANNO2	 decimal (19,2)
set @2_Svalutazioni_ANNO2 = ISNULL(( SELECT SUM(budgetprevision.prevision2)
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
	AND S.sortcode LIKE 'E232%'),0)
/*
XI Accantonamenti per rischi e oneri
E24	Accantonamenti per rischi e oneri
*/
declare @XI_Accantonamenti_rischi_oneri_ANNO2	 decimal (19,2)
set @XI_Accantonamenti_rischi_oneri_ANNO2 = ISNULL(( SELECT SUM(budgetprevision.prevision2)
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
	AND S.sortcode LIKE 'E24%'),0)
/*
XII Budget economico dei Progetti di ricerca
E25	Budget economico dei Progetti di ricerca
*/
declare @XII_Budget_economico_progetti_ricerca_ANNO2	 decimal (19,2)
set @XII_Budget_economico_progetti_ricerca_ANNO2 = ISNULL(( SELECT SUM(budgetprevision.prevision2)
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
	AND S.sortcode LIKE 'E25%'),0)

------------------------------------------------------------------------------------------------------------------------------------------

/* Gestione Operativa(A-B) 
A = @PROVENTIOPERATIVI	E1 calcolati da una somma
B = @COSTI_OPERATIVI	E2
*/

declare @Gestione_Operativa_ANNO2	 decimal (19,2)
set @Gestione_Operativa_ANNO2 = @PROVENTIOPERATIVI_ANNO2 - @COSTI_OPERATIVI_ANNO2


/* C) Proventi e Oneri finanziari E31	Proventi e Oneri finanziari - Non può essere una somma  */

/*
1) Proventi Finanziari e utili su cambi
E311	Proventi Finanziari e utili su cambi
*/
declare @1_Proventi_Finanziari_utili_su_cambi_ANNO2	 decimal (19,2)
set @1_Proventi_Finanziari_utili_su_cambi_ANNO2 = ISNULL(( SELECT SUM(budgetprevision.prevision2)
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
	AND S.sortcode LIKE 'E311%'),0)
/*
2) Oneri Finanziari e perdite su cambi
E312	Oneri Finanziari e perdite su cambi
*/
declare @2_Oneri_Finanziari_perdite_cambi_ANNO2	 decimal (19,2)
set @2_Oneri_Finanziari_perdite_cambi_ANNO2 = ISNULL(( SELECT SUM(budgetprevision.prevision2)
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
	AND S.sortcode LIKE 'E312%'),0)

/* D) Rettifiche di valore di attività finanziarie E41	Rettifiche di valore di attività finanziarie - Non può essere una somma */

/*
1) Rivalutazioni attività finanziarie
E411	Rivalutazioni attività finanziarie
*/
declare @1_Rivalutazioni_attivita_finanziarie_ANNO2	 decimal (19,2)
set @1_Rivalutazioni_attivita_finanziarie_ANNO2 = ISNULL(( SELECT SUM(budgetprevision.prevision2)
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
	AND S.sortcode LIKE 'E411%'),0)
/*
2) Svalutazioni attività finanziarie
E412	Svalutazioni attività finanziarie
*/
declare @2_Svalutazioni_attivita_finanziarie_ANNO2	 decimal (19,2)
set @2_Svalutazioni_attivita_finanziarie_ANNO2 = ISNULL(( SELECT SUM(budgetprevision.prevision2)
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
	AND S.sortcode LIKE 'E412%'),0)

------------------------------------------------------------------------------------------------------------------------------------------
/*Gestione finanziaria (C1 + D1 - C2 -D2) 
C1 = codice @1_Proventi_Finanziari_utili_su_cambi	E311 "C 1) Proventi Finanziari e utili su cambi"
D1 = codice @1_Rivalutazioni_attivita_finanziarie	E411 "D 1) Rivalutazioni attività finanziarie"
C2 = codice @2_Oneri_Finanziari_perdite_cambi		E312 "C 2) Oneri Finanziari e perdite su cambi"
D2 = codice @2_Svalutazioni_attivita_finanziarie	E412 "D 2) Svalutazioni attività finanziarie"
*/

declare @Gestione_Finanziaria_ANNO2	 decimal (19,2)
set @Gestione_Finanziaria_ANNO2 = @1_Proventi_Finanziari_utili_su_cambi_ANNO2 + 
							@1_Rivalutazioni_attivita_finanziarie_ANNO2 -
							@2_Oneri_Finanziari_perdite_cambi_ANNO2 -
							@2_Svalutazioni_attivita_finanziarie_ANNO2


/* E) Proventi e oneri straordinari E51	Proventi e oneri straordinari -Non può essere una somma */

/*
1) Proventi straordinari
E511	Proventi straordinari
*/
declare @1_Proventi_straordinari_ANNO2	 decimal (19,2)
set @1_Proventi_straordinari_ANNO2 = ISNULL(( SELECT SUM(budgetprevision.prevision2)
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
	AND S.sortcode LIKE 'E511%'),0)


/*
2) Oneri Straordinari
E512	Oneri Straordinari
*/
declare @2_Oneri_straordinari_ANNO2	 decimal (19,2)
set @2_Oneri_straordinari_ANNO2 = ISNULL(( SELECT SUM(budgetprevision.prevision2)
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
	AND S.sortcode LIKE 'E512%'),0)
--------------------------------------------------------------------------------------------------------------------------------

/* Gestione straordinaria (E1 - E2) 
E1 = @1_Proventi_straordinari	codice E511	"E 1) Proventi straordinari"
E2 = @2_Oneri_straordinari		codice E512	"E 2) Oneri Straordinari"
*/

declare @Gestione_Straordinaria_ANNO2	 decimal (19,2)
set @Gestione_Straordinaria_ANNO2 = @1_Proventi_straordinari_ANNO2 -  @2_Oneri_straordinari_ANNO2


/*
F) Imposte e tasse
E6	Imposte e tasse
*/

declare @F_Imposte_e_tasse_ANNO2	 decimal (19,2)
set @F_Imposte_e_tasse_ANNO2 = ISNULL(( SELECT SUM(budgetprevision.prevision2)
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
	AND S.sortcode LIKE 'E6%'),0)


/* PREVISIONI DELL'ESERCIZIO CORRENTE ANNO 3*/

/*I PROVENTI OPERATIVI SONO CALCOLATI DA UNA FORMULA*/


declare @I_PROVENTI_PROPRI_ANNO3 decimal(19,2)
set @I_PROVENTI_PROPRI_ANNO3 = ISNULL(( SELECT SUM(budgetprevision.prevision3)
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

declare @II_CONTRIBUTI_ANNO3  decimal(19,2)
set  @II_CONTRIBUTI_ANNO3= ISNULL(( SELECT SUM(budgetprevision.prevision3)
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

declare @III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE_ANNO3 decimal(19,2)
set @III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE_ANNO3 =ISNULL((  SELECT SUM(budgetprevision.prevision3)
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

declare @IV_PROVENTI_PER_GESTIONE_DIRETTA_ANNO3 decimal (19,2)
set @IV_PROVENTI_PER_GESTIONE_DIRETTA_ANNO3 = ISNULL(( SELECT SUM(budgetprevision.prevision3)
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

declare @V_ALTRI_PROVENTI_ANNO3 decimal (19,2)
set @V_ALTRI_PROVENTI_ANNO3 = ISNULL(( SELECT SUM(budgetprevision.prevision3)
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

declare @VI_VARIAZIONE_LAVORI_IN_CORSO_ANNO3 decimal (19,2)
set @VI_VARIAZIONE_LAVORI_IN_CORSO_ANNO3 = ISNULL(( SELECT SUM(budgetprevision.prevision3)
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

declare @VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI_ANNO3 decimal (19,2)
set @VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI_ANNO3 = ISNULL(( SELECT SUM(budgetprevision.prevision3)
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

declare @PROVENTIOPERATIVI_ANNO3 decimal(19,2)
SET @PROVENTIOPERATIVI_ANNO3= @I_PROVENTI_PROPRI_ANNO3+
						@II_CONTRIBUTI_ANNO3+
						@III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE_ANNO3+
						@IV_PROVENTI_PER_GESTIONE_DIRETTA_ANNO3 +	
						@V_ALTRI_PROVENTI_ANNO3+
						@VI_VARIAZIONE_LAVORI_IN_CORSO_ANNO3+@VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI_ANNO3



declare @COSTI_OPERATIVI_ANNO3  decimal (19,2)
set @COSTI_OPERATIVI_ANNO3 = ISNULL(( SELECT SUM(budgetprevision.prevision3)
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


/* Le prossime due sono calcolate come somme*/
declare @COSTI_SPECIFICI_ANNO3  decimal (19,2)

declare @I_SOSTEGNO_AGLI_STUDENTI_ANNO3  decimal (19,2)


/*new @VIII_Costi_del_Personale*/
/*E21	Costi del Personale													*/
declare @VIII_Costi_del_Personale_ANNO3 decimal (19,2)
set @VIII_Costi_del_Personale_ANNO3 = ISNULL(( SELECT SUM(budgetprevision.prevision3)
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
	AND S.sortcode LIKE 'E21%'),0)


/*1) Costi del personale dedicato alla ricerca e alla didattica */
/*E211	Costi del personale dedicato alla ricerca e alla didattica			*/
declare @1_Costi_personale_dedicato_ricerca_didattica_ANNO3 decimal (19,2)
set @1_Costi_personale_dedicato_ricerca_didattica_ANNO3 = ISNULL(( SELECT SUM(budgetprevision.prevision3)
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
	AND S.sortcode LIKE 'E211%'),0)


/*a) Docenti e Ricercatori*/
/*E2111	Docenti e Ricercatori												*/

declare @a_Docenti_e_Ricercatori_ANNO3 decimal (19,2)
set @a_Docenti_e_Ricercatori_ANNO3 = ISNULL(( SELECT SUM(budgetprevision.prevision3)
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

/*b) Collaborazioni scientifiche	*/
/*E2112	Collaborazioni scientifiche											*/
declare @b_Collaborazioni_scientifiche_ANNO3 decimal (19,2)
set @b_Collaborazioni_scientifiche_ANNO3 =  ISNULL(( SELECT SUM(budgetprevision.prevision3)
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

/*E2113	Docenti a contratto												*/	
/* c) Docenti a contratto */
declare @c_Docenti_a_contratto_ANNO3 decimal (19,2)
set @c_Docenti_a_contratto_ANNO3 =  ISNULL(( SELECT SUM(budgetprevision.prevision3)
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
	AND S.sortcode LIKE 'E2113%'),0)

/*E2114	Esperti e linquistici												*/
/* d) Esperti e linquistici */
declare @d_Esperti_e_linquistici_ANNO3 decimal (19,2)
set @d_Esperti_e_linquistici_ANNO3 =  ISNULL(( SELECT SUM(budgetprevision.prevision3)
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
	AND S.sortcode LIKE 'E2114%'),0)


/*E2115	Altro personale dedicato alla ricerca e didattica					*/
/*    e) Altro personale dedicato alla ricerca e didattica	*/
declare @e_Altro_personale_dedicato_ricerca_didattica_ANNO3 decimal (19,2)
set @e_Altro_personale_dedicato_ricerca_didattica_ANNO3 = ISNULL(( SELECT SUM(budgetprevision.prevision3)
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
	AND S.sortcode LIKE 'E2115%'),0)

/*E2116	Altri oneri per il personale dedicato alla ricerca e didattica		*/
/*  f) Altri oneri per il personale dedicato alla ricerca e didattica	*/
declare @f_Altri_oneri_personale_dedicato_ricerca_didattica_ANNO3 decimal (19,2)
set @f_Altri_oneri_personale_dedicato_ricerca_didattica_ANNO3 = ISNULL(( SELECT SUM(budgetprevision.prevision3)
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
	AND S.sortcode LIKE 'E2116%'),0)


/*
2) Costi del personale dedicato ai servizi generali e amministrativi		
E212	Costi del personale dedicato ai servizi generali e amministrativi
*/

declare @2_Costi_personale_dedicato_servizi_generali_amministrativi_ANNO3 decimal (19,2)
set @2_Costi_personale_dedicato_servizi_generali_amministrativi_ANNO3 = ISNULL(( SELECT SUM(budgetprevision.prevision3)
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

/*
a) Costi del personale dirigente e T.A.		
E2121	Costi del personale dirigente e T.A.
*/
declare @a_Costi_personale_dirigente_e_TA_ANNO3 decimal (19,2)
set @a_Costi_personale_dirigente_e_TA_ANNO3 = ISNULL(( SELECT SUM(budgetprevision.prevision3)
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
	AND S.sortcode LIKE 'E2121%'),0)


/*
b) Altro personale amministrativo		
E2122	Altro personale amministrativo
*/
declare @b_Altro_personale_amministrativo_ANNO3 decimal (19,2)
set @b_Altro_personale_amministrativo_ANNO3 = ISNULL(( SELECT SUM(budgetprevision.prevision3)
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
	AND S.sortcode LIKE 'E2122%'),0)


/*
c) Altri onei per il personale amministrativo		
E2123	Altri onei per il personale amministrativo
*/

declare @c_Altri_oneri_personale_amministrativo_ANNO3	 decimal (19,2)
set @c_Altri_oneri_personale_amministrativo_ANNO3= ISNULL(( SELECT SUM(budgetprevision.prevision3)
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
	AND S.sortcode LIKE 'E2123%'),0)

/*
IX Costi della Gestione corrente		
E22	Costi della Gestione corrente
*/

declare @IX_Costi_Gestione_corrente_ANNO3	 decimal (19,2)
set @IX_Costi_Gestione_corrente_ANNO3 = ISNULL(( SELECT SUM(budgetprevision.prevision3)
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
	AND S.sortcode LIKE 'E22%'),0)

	
/*
1) Costi per il sostegno agli studenti
E221	Costi per il sostegno agli studenti
*/

declare @1_Costi_sostegno_studenti_ANNO3	 decimal (19,2)
set @1_Costi_sostegno_studenti_ANNO3 = ISNULL(( SELECT SUM(budgetprevision.prevision3)
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


/*
2) Costi per il diritto allo studio
E222	Costi per il diritto allo studio
*/

declare @2_Costi_diritto_allo_studio_ANNO3	 decimal (19,2)
set @2_Costi_diritto_allo_studio_ANNO3 = ISNULL(( SELECT SUM(budgetprevision.prevision3)
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


/*
3) Costi per la ricerca e l'attività editoriale
E223	Costi per la ricerca e l'attività editoriale
*/

declare @3_Costi_ricerca_e_attivita_editoriale_ANNO3	 decimal (19,2)
set @3_Costi_ricerca_e_attivita_editoriale_ANNO3 = ISNULL(( SELECT SUM(budgetprevision.prevision3)
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

/*
4) Aquisto materiale di consumo per laboratori
E224	Aquisto materiale di consumo per laboratori
*/

declare @4_Acquisto_materiale_consumo_per_laboratori_ANNO3	 decimal (19,2)
set @4_Acquisto_materiale_consumo_per_laboratori_ANNO3 = ISNULL(( SELECT SUM(budgetprevision.prevision3)
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

/*
5) Acquisto libri, periodici e materiale bibliografico
E225	Acquisto libri, periodici e materiale bibliografico
*/

declare @5_Acquisto_libri_periodici_e_materiale_bibliografico_ANNO3	 decimal (19,2)
set @5_Acquisto_libri_periodici_e_materiale_bibliografico_ANNO3 = ISNULL(( SELECT SUM(budgetprevision.prevision3)
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


/*
6) Acquisto di servizi e collaborazioni tecnico gestionali
E226	Acquisto di servizi e collaborazioni tecnico gestionali
*/

declare @6_Acquisto_servizi_collaborazioni_tecnico_gestionali_ANNO3	 decimal (19,2)
set @6_Acquisto_servizi_collaborazioni_tecnico_gestionali_ANNO3 = ISNULL(( SELECT SUM(budgetprevision.prevision3)
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
	AND S.sortcode LIKE 'E226%'),0)

/*
7) Acquisto altri materiali
E227	Acquisto altri materiali
*/
declare @7_Acquisto_altri_materiali_ANNO3	 decimal (19,2)
set @7_Acquisto_altri_materiali_ANNO3 = ISNULL(( SELECT SUM(budgetprevision.prevision3)
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
	AND S.sortcode LIKE 'E227%'),0)


/*
8) Costi per il godimento beni di terzi
E228	Costi per il godimento beni di terzi
*/

declare @8_Costi_per_godimento_beni_di_terzi_ANNO3	 decimal (19,2)
set @8_Costi_per_godimento_beni_di_terzi_ANNO3 = ISNULL(( SELECT SUM(budgetprevision.prevision3)
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
	AND S.sortcode LIKE 'E228%'),0)


/*
9) Altri costi operativi
E229	Altri costi operativi
*/

declare @9_Altri_costi_operativi_ANNO3	 decimal (19,2)
set @9_Altri_costi_operativi_ANNO3 = ISNULL(( SELECT SUM(budgetprevision.prevision3)
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
	AND S.sortcode LIKE 'E229%'),0)

/*
10) Trasferimenti e contributi
E22A	Trasferimenti e contributi
*/
declare @10_Trasferimenti_e_contributi_ANNO3	 decimal (19,2)
set @10_Trasferimenti_e_contributi_ANNO3 = ISNULL(( SELECT SUM(budgetprevision.prevision3)
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
	AND S.sortcode LIKE 'E22A%'),0)


/*
a) Trasferimento a partner per progetti coordinati
E22A1	Trasferimento a partner per progetti coordinati
*/

declare @a_Trasferimento_a_partner_progetti_coordinati_ANNO3	 decimal (19,2)
set @a_Trasferimento_a_partner_progetti_coordinati_ANNO3 = ISNULL(( SELECT SUM(budgetprevision.prevision3)
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
	AND S.sortcode LIKE 'E22A1%'),0)


/*
b) Contributi per investimenti in ricerca
E22A2	Contributi per investimenti in ricerca
*/

declare @b_Contributi_per_investimenti_ricerca_ANNO3	 decimal (19,2)
set @b_Contributi_per_investimenti_ricerca_ANNO3 = ISNULL(( SELECT SUM(budgetprevision.prevision3)
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
	AND S.sortcode LIKE 'E22A2%'),0)


/*
c) Trasferimenti correnti
E22A3	Trasferimenti correnti
*/

declare @c_Trasferimenti_correnti_ANNO3	 decimal (19,2)
set @c_Trasferimenti_correnti_ANNO3 = ISNULL(( SELECT SUM(budgetprevision.prevision3)
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
	AND S.sortcode LIKE 'E22A3%'),0)


/*
d) Trasferimenti in conto capitale
E22A4	Trasferimenti in conto capitale
*/
declare @d_Trasferimenti_conto_capitale_ANNO3	 decimal (19,2)
set @d_Trasferimenti_conto_capitale_ANNO3 = ISNULL(( SELECT SUM(budgetprevision.prevision3)
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
	AND S.sortcode LIKE 'E22A4%'),0)

/*
X  Ammortamenti e Svalutazioni
E23	Ammortamenti e Svalutazioni
*/

declare @X_Ammortamenti_e_Svalutazioni_ANNO3	 decimal (19,2)
set @X_Ammortamenti_e_Svalutazioni_ANNO3 = ISNULL(( SELECT SUM(budgetprevision.prevision3)
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
	AND S.sortcode LIKE 'E23%'),0)

/*
1) Ammortamenti
E231	Ammortamenti
*/
declare @1_Ammortamenti_ANNO3	 decimal (19,2)
set @1_Ammortamenti_ANNO3 = ISNULL(( SELECT SUM(budgetprevision.prevision3)
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
	AND S.sortcode LIKE 'E231%'),0)
/*
2) Svalutazioni
E232	Svalutazioni
*/
declare @2_Svalutazioni_ANNO3	 decimal (19,2)
set @2_Svalutazioni_ANNO3 = ISNULL(( SELECT SUM(budgetprevision.prevision3)
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
	AND S.sortcode LIKE 'E232%'),0)
/*
XI Accantonamenti per rischi e oneri
E24	Accantonamenti per rischi e oneri
*/
declare @XI_Accantonamenti_rischi_oneri_ANNO3	 decimal (19,2)
set @XI_Accantonamenti_rischi_oneri_ANNO3 = ISNULL(( SELECT SUM(budgetprevision.prevision3)
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
	AND S.sortcode LIKE 'E24%'),0)
/*
XII Budget economico dei Progetti di ricerca
E25	Budget economico dei Progetti di ricerca
*/
declare @XII_Budget_economico_progetti_ricerca_ANNO3	 decimal (19,2)
set @XII_Budget_economico_progetti_ricerca_ANNO3 = ISNULL(( SELECT SUM(budgetprevision.prevision3)
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
	AND S.sortcode LIKE 'E25%'),0)

------------------------------------------------------------------------------------------------------------------------------------------

/* Gestione Operativa(A-B) 
A = @PROVENTIOPERATIVI	E1 calcolati da una somma
B = @COSTI_OPERATIVI	E2
*/

declare @Gestione_Operativa_ANNO3	 decimal (19,2)
set @Gestione_Operativa_ANNO3 = @PROVENTIOPERATIVI_ANNO3 - @COSTI_OPERATIVI_ANNO3


/* C) Proventi e Oneri finanziari E31	Proventi e Oneri finanziari - Non può essere una somma  */

/*
1) Proventi Finanziari e utili su cambi
E311	Proventi Finanziari e utili su cambi
*/
declare @1_Proventi_Finanziari_utili_su_cambi_ANNO3	 decimal (19,2)
set @1_Proventi_Finanziari_utili_su_cambi_ANNO3 = ISNULL(( SELECT SUM(budgetprevision.prevision3)
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
	AND S.sortcode LIKE 'E311%'),0)
/*
2) Oneri Finanziari e perdite su cambi
E312	Oneri Finanziari e perdite su cambi
*/
declare @2_Oneri_Finanziari_perdite_cambi_ANNO3	 decimal (19,2)
set @2_Oneri_Finanziari_perdite_cambi_ANNO3 = ISNULL(( SELECT SUM(budgetprevision.prevision3)
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
	AND S.sortcode LIKE 'E312%'),0)

/* D) Rettifiche di valore di attività finanziarie E41	Rettifiche di valore di attività finanziarie - Non può essere una somma */

/*
1) Rivalutazioni attività finanziarie
E411	Rivalutazioni attività finanziarie
*/
declare @1_Rivalutazioni_attivita_finanziarie_ANNO3	 decimal (19,2)
set @1_Rivalutazioni_attivita_finanziarie_ANNO3 = ISNULL(( SELECT SUM(budgetprevision.prevision3)
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
	AND S.sortcode LIKE 'E411%'),0)
/*
2) Svalutazioni attività finanziarie
E412	Svalutazioni attività finanziarie
*/
declare @2_Svalutazioni_attivita_finanziarie_ANNO3	 decimal (19,2)
set @2_Svalutazioni_attivita_finanziarie_ANNO3 = ISNULL(( SELECT SUM(budgetprevision.prevision3)
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
	AND S.sortcode LIKE 'E412%'),0)

------------------------------------------------------------------------------------------------------------------------------------------
/*Gestione finanziaria (C1 + D1 - C2 -D2) 
C1 = codice @1_Proventi_Finanziari_utili_su_cambi	E311 "C 1) Proventi Finanziari e utili su cambi"
D1 = codice @1_Rivalutazioni_attivita_finanziarie	E411 "D 1) Rivalutazioni attività finanziarie"
C2 = codice @2_Oneri_Finanziari_perdite_cambi		E312 "C 2) Oneri Finanziari e perdite su cambi"
D2 = codice @2_Svalutazioni_attivita_finanziarie	E412 "D 2) Svalutazioni attività finanziarie"
*/

declare @Gestione_Finanziaria_ANNO3	 decimal (19,2)
set @Gestione_Finanziaria_ANNO3 = @1_Proventi_Finanziari_utili_su_cambi_ANNO3 + 
							@1_Rivalutazioni_attivita_finanziarie_ANNO3 -
							@2_Oneri_Finanziari_perdite_cambi_ANNO3 -
							@2_Svalutazioni_attivita_finanziarie_ANNO3


/* E) Proventi e oneri straordinari E51	Proventi e oneri straordinari -Non può essere una somma */

/*
1) Proventi straordinari
E511	Proventi straordinari
*/
declare @1_Proventi_straordinari_ANNO3	 decimal (19,2)
set @1_Proventi_straordinari_ANNO3 = ISNULL(( SELECT SUM(budgetprevision.prevision3)
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
	AND S.sortcode LIKE 'E511%'),0)


/*
2) Oneri Straordinari
E512	Oneri Straordinari
*/
declare @2_Oneri_straordinari_ANNO3	 decimal (19,2)
set @2_Oneri_straordinari_ANNO3 = ISNULL(( SELECT SUM(budgetprevision.prevision3)
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
	AND S.sortcode LIKE 'E512%'),0)
--------------------------------------------------------------------------------------------------------------------------------

/* Gestione straordinaria (E1 - E2) 
E1 = @1_Proventi_straordinari	codice E511	"E 1) Proventi straordinari"
E2 = @2_Oneri_straordinari		codice E512	"E 2) Oneri Straordinari"
*/

declare @Gestione_Straordinaria_ANNO3	 decimal (19,2)
set @Gestione_Straordinaria_ANNO3 = @1_Proventi_straordinari_ANNO3 -  @2_Oneri_straordinari_ANNO3


/*
F) Imposte e tasse
E6	Imposte e tasse
*/

declare @F_Imposte_e_tasse_ANNO3	 decimal (19,2)
set @F_Imposte_e_tasse_ANNO3 = ISNULL(( SELECT SUM(budgetprevision.prevision3)
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
	AND S.sortcode LIKE 'E6%'),0)




select
  @treasurer as department,

  @I_PROVENTI_PROPRI  	as								'I_PROVENTI_PROPRI',  
  @II_CONTRIBUTI   	as									'II_CONTRIBUTI',   
  @III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE  	as		'III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE', 
  @IV_PROVENTI_PER_GESTIONE_DIRETTA  	as				'IV_PROVENTI_PER_GESTIONE_DIRETTA', 
  @V_ALTRI_PROVENTI  	as								'V_ALTRI_PROVENTI',  
  @VI_VARIAZIONE_LAVORI_IN_CORSO  	as					'VI_VARIAZIONE_LAVORI_IN_CORSO', 
  @VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI  	as			'VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI', 
    --Totale proventi operativi 
  @PROVENTIOPERATIVI as									'TOTALE_PROVENTI_OPERATIVI',
    
  @COSTI_SPECIFICI   	as								'COSTI_SPECIFICI',   
  @I_SOSTEGNO_AGLI_STUDENTI   	as						'I_SOSTEGNO_AGLI_STUDENTI',

  
/*new @VIII_Costi_del_Personale E21	Costi del Personale													*/
 @VIII_Costi_del_Personale  AS 'VIII_Costi_del_Personale',
/*1) Costi del personale dedicato alla ricerca e alla didattica E211	Costi del personale dedicato alla ricerca e alla didattica			*/
 @1_Costi_personale_dedicato_ricerca_didattica  AS '1_Costi_personale_dedicato_ricerca_didattica',
 /*a) Docenti e Ricercatori E2111	Docenti e Ricercatori												*/
 @a_Docenti_e_Ricercatori  AS 'a_Docenti_e_Ricercatori',
 /*b) Collaborazioni scientifichE E2112	Collaborazioni scientifiche											*/
 @b_Collaborazioni_scientifiche  AS 'b_Collaborazioni_scientifiche',
/*E2113	Docenti a contratto	c) Docenti a contratto */
 @c_Docenti_a_contratto  AS 'c_Docenti_a_contratto',
 /*E2114	Esperti e linquistici d) Esperti e linquistici */
 @d_Esperti_e_linquistici  AS 'd_Esperti_e_linquistici',
 /*E2115	Altro personale dedicato alla ricerca e didattica	E) Altro personale dedicato alla ricerca e didattica	*/
 @e_Altro_personale_dedicato_ricerca_didattica  AS 'e_Altro_personale_dedicato_ricerca_didattica',
 /*E2116	Altri oneri per il personale dedicato alla ricerca e didattica f) Altri oneri per il personale dedicato alla ricerca e didattica	*/
 @f_Altri_oneri_personale_dedicato_ricerca_didattica  AS 'f_Altri_oneri_personale_dedicato_ricerca_didattica',

/* 2) Costi del personale dedicato ai servizi generali e amministrativi	E212	Costi del personale dedicato ai servizi generali e amministrativi */
 @2_Costi_personale_dedicato_servizi_generali_amministrativi  AS '2_Costi_personale_dedicato_servizi_generali_amministrativi',
 /* a) Costi del personale dirigente e T.A.	E2121	Costi del personale dirigente e T.A. */
 @a_Costi_personale_dirigente_e_TA  AS 'a_Costi_personale_dirigente_e_TA',
 /*b) Altro personale amministrativo	E2122	Altro personale amministrativo*/
 @b_Altro_personale_amministrativo  AS 'b_Altro_personale_amministrativo',
 /* c) Altri onei per il personale amministrativo E2123	Altri onei per il personale amministrativo */
 @c_Altri_oneri_personale_amministrativo	  AS 'c_Altri_oneri_personale_amministrativo',

 /* IX Costi della Gestione corrente		E22	Costi della Gestione corrente */
 @IX_Costi_Gestione_corrente	  AS 'IX_Costi_Gestione_corrente',
/* 1) Costi per il sostegno agli studenti E221	Costi per il sostegno agli studenti */
 @1_Costi_sostegno_studenti	  AS '1_Costi_sostegno_studenti',
 /* 2) Costi per il diritto allo studio E222	Costi per il diritto allo studio */
 @2_Costi_diritto_allo_studio	  AS '2_Costi_diritto_allo_studio',
 /* 3) Costi per la ricerca e l'attività editoriale E223	Costi per la ricerca e l'attività editoriale */
 @3_Costi_ricerca_e_attivita_editoriale	  AS '3_Costi_ricerca_e_attivita_editoriale',
 /* 4) Aquisto materiale di consumo per laboratori E224	Aquisto materiale di consumo per laboratori */
 @4_Acquisto_materiale_consumo_per_laboratori	  AS '4_Acquisto_materiale_consumo_per_laboratori',
 /*5) Acquisto libri, periodici e materiale bibliografico E225	Acquisto libri, periodici e materiale bibliografico */
 @5_Acquisto_libri_periodici_e_materiale_bibliografico	  AS '5_Acquisto_libri_periodici_e_materiale_bibliografico',
 /* 6) Acquisto di servizi e collaborazioni tecnico gestionali E226	Acquisto di servizi e collaborazioni tecnico gestionali */
 @6_Acquisto_servizi_collaborazioni_tecnico_gestionali	  AS '6_Acquisto_servizi_collaborazioni_tecnico_gestionali',
 /* 7) Acquisto altri materiali E227	Acquisto altri materiali */
 @7_Acquisto_altri_materiali	  AS '7_Acquisto_altri_materiali',
 /*8) Costi per il godimento beni di terzi E228	Costi per il godimento beni di terzi */
 @8_Costi_per_godimento_beni_di_terzi	  AS '8_Costi_per_godimento_beni_di_terzi',
 /* 9) Altri costi operativi E229	Altri costi operativi */
 @9_Altri_costi_operativi	  AS '9_Altri_costi_operativi',
 /* 10) Trasferimenti e contributi E22A	Trasferimenti e contributi */
 @10_Trasferimenti_e_contributi	  AS '10_Trasferimenti_e_contributi',
  /* a) Trasferimento a partner per progetti coordinati E22A1	Trasferimento a partner per progetti coordinati */
 @a_Trasferimento_a_partner_progetti_coordinati	  AS 'a_Trasferimento_a_partner_progetti_coordinati',
 /* b) Contributi per investimenti in ricerca E22A2	Contributi per investimenti in ricerca */
 @b_Contributi_per_investimenti_ricerca	  AS 'b_Contributi_per_investimenti_ricerca',
 /* c) Trasferimenti correnti E22A3	Trasferimenti correnti */
 @c_Trasferimenti_correnti	  AS 'c_Trasferimenti_correnti',
 /* d) Trasferimenti in conto capitale  E22A4	Trasferimenti in conto capitale*/
 @d_Trasferimenti_conto_capitale	  AS 'd_Trasferimenti_conto_capitale',

/* X  Ammortamenti e Svalutazioni E23	Ammortamenti e Svalutazioni */
 @X_Ammortamenti_e_Svalutazioni	  AS 'X_Ammortamenti_e_Svalutazioni',
 /* 1) Ammortamenti  E231	Ammortamenti*/
 @1_Ammortamenti	  AS '1_Ammortamenti',
 /* 2) Svalutazioni E232	Svalutazioni */
 @2_Svalutazioni	  AS '2_Svalutazioni',

/* XI Accantonamenti per rischi e oneri E24	Accantonamenti per rischi e oneri */
 @XI_Accantonamenti_rischi_oneri	  AS 'XI_Accantonamenti_rischi_oneri',

/* XII Budget economico dei Progetti di ricerca E25	Budget economico dei Progetti di ricerca */
 @XII_Budget_economico_progetti_ricerca	  AS 'XII_Budget_economico_progetti_ricerca',

/*Totale costi operativi*/
  @COSTI_OPERATIVI   	as								'TOTALE_COSTI_OPERATIVI', 

------------------------------------------------------------------------------------------------------------------------------------------

/* Gestione Operativa(A-B) 
A = @PROVENTIOPERATIVI	E1 calcolati da una somma
B = @COSTI_OPERATIVI	E2
*/
 @Gestione_Operativa	  AS 'Gestione_Operativa',

/* 1) Proventi Finanziari e utili su cambi E311	Proventi Finanziari e utili su cambi */
 @1_Proventi_Finanziari_utili_su_cambi	  AS '1_Proventi_Finanziari_utili_su_cambi',

/* 2) Oneri Finanziari e perdite su cambi E312	Oneri Finanziari e perdite su cambi */
 @2_Oneri_Finanziari_perdite_cambi	  AS '2_Oneri_Finanziari_perdite_cambi',

/* 1) Rivalutazioni attività finanziarie  E411	Rivalutazioni attività finanziarie*/
 @1_Rivalutazioni_attivita_finanziarie	  AS '1_Rivalutazioni_attivita_finanziarie',

/* 2) Svalutazioni attività finanziarie E412	Svalutazioni attività finanziarie */
 @2_Svalutazioni_attivita_finanziarie	  AS '2_Svalutazioni_attivita_finanziarie',


------------------------------------------------------------------------------------------------------------------------------------------
/*Gestione finanziaria (C1 + D1 - C2 -D2) */
 @Gestione_Finanziaria	  AS 'Gestione_Finanziaria',

/* 1) Proventi straordinari E511	Proventi straordinari */
 @1_Proventi_straordinari	  AS '1_Proventi_straordinari',

/* 2) Oneri Straordinari E512	Oneri Straordinari*/
 @2_Oneri_straordinari	  AS '2_Oneri_straordinari',

------------------------------------------------------------------------------------------------------------------------------------------

/* Gestione straordinaria (E1 - E2) */
 @Gestione_Straordinaria	  AS 'Gestione_Straordinaria',

/* F) Imposte e tasse E6	Imposte e tasse*/
 @F_Imposte_e_tasse	  AS 'F_Imposte_e_tasse',

/*Risultato Economico Atteso */
@Gestione_Operativa + @Gestione_Finanziaria + @Gestione_Straordinaria - @F_Imposte_e_tasse AS 'Risultato_Economico_Atteso',

/*ANNO2*/

  @I_PROVENTI_PROPRI_ANNO2  						as		'I_PROVENTI_PROPRI_ANNO2',  
  @II_CONTRIBUTI_ANNO2     							as		'II_CONTRIBUTI_ANNO2',   
  @III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE_ANNO2   	as		'III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE_ANNO2', 
  @IV_PROVENTI_PER_GESTIONE_DIRETTA_ANNO2    		as		'IV_PROVENTI_PER_GESTIONE_DIRETTA_ANNO2', 
  @V_ALTRI_PROVENTI_ANNO2    						as		'V_ALTRI_PROVENTI_ANNO2',  
  @VI_VARIAZIONE_LAVORI_IN_CORSO_ANNO2    			as		'VI_VARIAZIONE_LAVORI_IN_CORSO_ANNO2', 
  @VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI_ANNO2    	as		'VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI_ANNO2', 
    --Totale proventi operativi 
  @PROVENTIOPERATIVI_ANNO2   						as		'TOTALE_PROVENTI_OPERATIVI_ANNO2',
    
  @COSTI_SPECIFICI_ANNO2     						as		'COSTI_SPECIFICI_ANNO2',   
  @I_SOSTEGNO_AGLI_STUDENTI_ANNO2     				as		'I_SOSTEGNO_AGLI_STUDENTI_ANNO2',

  
/*new @VIII_Costi_del_Personale E21	Costi del Personale													*/
 @VIII_Costi_del_Personale_ANNO2  							AS 	'VIII_Costi_del_Personale_ANNO2',
/*1) Costi del personale dedicato alla ricerca e alla didattica E211	Costi del personale dedicato alla ricerca e alla didattica			*/
 @1_Costi_personale_dedicato_ricerca_didattica_ANNO2  		AS 	'1_Costi_personale_dedicato_ricerca_didattica_ANNO2',
 /*a) Docenti e Ricercatori E2111	Docenti e Ricercatori												*/
 @a_Docenti_e_Ricercatori_ANNO2  							AS 	'a_Docenti_e_Ricercatori_ANNO2',
 /*b) Collaborazioni scientifichE E2112	Collaborazioni scientifiche											*/
 @b_Collaborazioni_scientifiche_ANNO2  						AS 	'b_Collaborazioni_scientifiche_ANNO2',
/*E2113	Docenti a contratto	c) Docenti a contratto */
 @c_Docenti_a_contratto_ANNO2  								AS 	'c_Docenti_a_contratto_ANNO2',
 /*E2114	Esperti e linquistici d) Esperti e linquistici */
 @d_Esperti_e_linquistici_ANNO2  							AS 	'd_Esperti_e_linquistici_ANNO2',
 /*E2115	Altro personale dedicato alla ricerca e didattica	E) Altro personale dedicato alla ricerca e didattica	*/
 @e_Altro_personale_dedicato_ricerca_didattica_ANNO2  		AS 	'e_Altro_personale_dedicato_ricerca_didattica_ANNO2',
 /*E2116	Altri oneri per il personale dedicato alla ricerca e didattica f) Altri oneri per il personale dedicato alla ricerca e didattica	*/
 @f_Altri_oneri_personale_dedicato_ricerca_didattica_ANNO2  AS 	'f_Altri_oneri_personale_dedicato_ricerca_didattica_ANNO2',

/* 2) Costi del personale dedicato ai servizi generali e amministrativi	E212	Costi del personale dedicato ai servizi generali e amministrativi */
 @2_Costi_personale_dedicato_servizi_generali_amministrativi_ANNO2  AS '2_Costi_personale_dedicato_servizi_generali_amministrativi_ANNO2',
 /* a) Costi del personale dirigente e T.A.	E2121	Costi del personale dirigente e T.A. */
 @a_Costi_personale_dirigente_e_TA_ANNO2  							AS 'a_Costi_personale_dirigente_e_TA_ANNO2',
 /*b) Altro personale amministrativo	E2122	Altro personale amministrativo*/
 @b_Altro_personale_amministrativo_ANNO2  							AS 'b_Altro_personale_amministrativo_ANNO2',
 /* c) Altri onei per il personale amministrativo E2123	Altri onei per il personale amministrativo */
 @c_Altri_oneri_personale_amministrativo_ANNO2	  					AS 'c_Altri_oneri_personale_amministrativo_ANNO2',

 /* IX Costi della Gestione corrente		E22	Costi della Gestione corrente */
 @IX_Costi_Gestione_corrente_ANNO2	  								AS 'IX_Costi_Gestione_corrente_ANNO2',
/* 1) Costi per il sostegno agli studenti E221	Costi per il sostegno agli studenti */
 @1_Costi_sostegno_studenti_ANNO2	  								AS '1_Costi_sostegno_studenti_ANNO2',
 /* 2) Costi per il diritto allo studio E222	Costi per il diritto allo studio */
 @2_Costi_diritto_allo_studio_ANNO2	  								AS '2_Costi_diritto_allo_studio_ANNO2',
 /* 3) Costi per la ricerca e l'attività editoriale E223	Costi per la ricerca e l'attività editoriale */
 @3_Costi_ricerca_e_attivita_editoriale_ANNO2	  					AS '3_Costi_ricerca_e_attivita_editoriale_ANNO2',
 /* 4) Aquisto materiale di consumo per laboratori E224	Aquisto materiale di consumo per laboratori */
 @4_Acquisto_materiale_consumo_per_laboratori_ANNO2	  				AS '4_Acquisto_materiale_consumo_per_laboratori_ANNO2',
 /*5) Acquisto libri, periodici e materiale bibliografico E225	Acquisto libri, periodici e materiale bibliografico */
 @5_Acquisto_libri_periodici_e_materiale_bibliografico_ANNO2	  	AS '5_Acquisto_libri_periodici_e_materiale_bibliografico_ANNO2',
 /* 6) Acquisto di servizi e collaborazioni tecnico gestio	nali E226	Acquisto di servizi e collaborazioni tecnico gestionali */
 @6_Acquisto_servizi_collaborazioni_tecnico_gestionali_ANNO2	  	AS '6_Acquisto_servizi_collaborazioni_tecnico_gestionali_ANNO2',
 /* 7) Acquisto altri materiali E227	Acquisto altri materiali */
 @7_Acquisto_altri_materiali_ANNO2	  								AS '7_Acquisto_altri_materiali_ANNO2',
 /*8) Costi per il godimento beni di terzi E228	Costi per il godimento beni di terzi */
 @8_Costi_per_godimento_beni_di_terzi_ANNO2	  						AS '8_Costi_per_godimento_beni_di_terzi_ANNO2',
 /* 9) Altri costi operativi E229	Altri costi operativi */
 @9_Altri_costi_operativi_ANNO2	  									AS '9_Altri_costi_operativi_ANNO2',
 /* 10) Trasferimenti e contributi E22A	Trasferimenti e contributi */
 @10_Trasferimenti_e_contributi_ANNO2	  							AS '10_Trasferimenti_e_contributi_ANNO2',
  /* a) Trasferimento a partner per progetti coordinati E22A1	Trasferimento a partner per progetti coordinati */
 @a_Trasferimento_a_partner_progetti_coordinati_ANNO2	  			AS 'a_Trasferimento_a_partner_progetti_coordinati_ANNO2',
 /* b) Contributi per investimenti in ricerca E22A2	Contributi per investimenti in ricerca */
 @b_Contributi_per_investimenti_ricerca_ANNO2	  					AS 'b_Contributi_per_investimenti_ricerca_ANNO2',
 /* c) Trasferimenti correnti E22A3	Trasferimenti correnti */
 @c_Trasferimenti_correnti_ANNO2	  								AS 'c_Trasferimenti_correnti_ANNO2',
 /* d) Trasferimenti in conto capitale  E22A4	Trasferimenti in conto capitale*/
 @d_Trasferimenti_conto_capitale_ANNO2	  							AS 'd_Trasferimenti_conto_capitale_ANNO2',

/* X  Ammortamenti e Svalutazioni E23	Ammortamenti e Svalutazioni */
 @X_Ammortamenti_e_Svalutazioni_ANNO2	AS 'X_Ammortamenti_e_Svalutazioni_ANNO2',
 /* 1) Ammortamenti  E231	Ammortamenti*/
 @1_Ammortamenti_ANNO2	  				AS '1_Ammortamenti_ANNO2',
 /* 2) Svalutazioni E232	Svalutazioni */
 @2_Svalutazioni_ANNO2	  				AS '2_Svalutazioni_ANNO2',

/* XI Accantonamenti per rischi e oneri E24	Accantonamenti per rischi e oneri */
 @XI_Accantonamenti_rischi_oneri_ANNO2	  AS 'XI_Accantonamenti_rischi_oneri_ANNO2',

/* XII Budget economico dei Progetti di ricerca E25	Budget economico dei Progetti di ricerca */
 @XII_Budget_economico_progetti_ricerca_ANNO2	  AS 'XII_Budget_economico_progetti_ricerca_ANNO2',

/*Totale costi operativi*/
  @COSTI_OPERATIVI_ANNO2   						as								'TOTALE_COSTI_OPERATIVI_ANNO2', 

------------------------------------------------------------------------------------------------------------------------------------------

/* Gestione Operativa(A-B) 
A = @PROVENTIOPERATIVI	E1 calcolati da una somma
B = @COSTI_OPERATIVI	E2
*/
 @Gestione_Operativa_ANNO2	  AS 'Gestione_Operativa_ANNO2',

/* 1) Proventi Finanziari e utili su cambi E311	Proventi Finanziari e utili su cambi */
 @1_Proventi_Finanziari_utili_su_cambi_ANNO2	  AS '1_Proventi_Finanziari_utili_su_cambi_ANNO2',

/* 2) Oneri Finanziari e perdite su cambi E312	Oneri Finanziari e perdite su cambi */
 @2_Oneri_Finanziari_perdite_cambi_ANNO2	  AS '2_Oneri_Finanziari_perdite_cambi_ANNO2',

/* 1) Rivalutazioni attività finanziarie  E411	Rivalutazioni attività finanziarie*/
 @1_Rivalutazioni_attivita_finanziarie_ANNO2	  AS '1_Rivalutazioni_attivita_finanziarie_ANNO2',

/* 2) Svalutazioni attività finanziarie E412	Svalutazioni attività finanziarie */
 @2_Svalutazioni_attivita_finanziarie_ANNO2	  AS '2_Svalutazioni_attivita_finanziarie_ANNO2',


------------------------------------------------------------------------------------------------------------------------------------------
/*Gestione finanziaria (C1 + D1 - C2 -D2) */
 @Gestione_Finanziaria_ANNO2	  AS 'Gestione_Finanziaria_ANNO2',

/* 1) Proventi straordinari E511	Proventi straordinari */
 @1_Proventi_straordinari_ANNO2	  AS '1_Proventi_straordinari_ANNO2',

/* 2) Oneri Straordinari E512	Oneri Straordinari*/
 @2_Oneri_straordinari_ANNO2	  AS '2_Oneri_straordinari_ANNO2',

------------------------------------------------------------------------------------------------------------------------------------------

/* Gestione straordinaria (E1 - E2) */
 @Gestione_Straordinaria_ANNO2	  AS 'Gestione_Straordinaria_ANNO2',

/* F) Imposte e tasse E6	Imposte e tasse*/
 @F_Imposte_e_tasse_ANNO2	  AS 'F_Imposte_e_tasse_ANNO2',

/*Risultato Economico Atteso */
@Gestione_Operativa_ANNO2 + @Gestione_Finanziaria_ANNO2 + @Gestione_Straordinaria_ANNO2 - @F_Imposte_e_tasse_ANNO2 AS 'Risultato_Economico_Atteso_ANNO2',


/*ANNO 3*/


  @I_PROVENTI_PROPRI_ANNO3  						as		'I_PROVENTI_PROPRI_ANNO3',  
  @II_CONTRIBUTI_ANNO3     							as		'II_CONTRIBUTI_ANNO3',   
  @III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE_ANNO3   	as		'III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE_ANNO3', 
  @IV_PROVENTI_PER_GESTIONE_DIRETTA_ANNO3    		as		'IV_PROVENTI_PER_GESTIONE_DIRETTA_ANNO3', 
  @V_ALTRI_PROVENTI_ANNO3    						as		'V_ALTRI_PROVENTI_ANNO3',  
  @VI_VARIAZIONE_LAVORI_IN_CORSO_ANNO3    			as		'VI_VARIAZIONE_LAVORI_IN_CORSO_ANNO3', 
  @VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI_ANNO3    	as		'VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI_ANNO3', 
    --Totale proventi operativi 
  @PROVENTIOPERATIVI_ANNO3   						as		'TOTALE_PROVENTI_OPERATIVI_ANNO3',
    
  @COSTI_SPECIFICI_ANNO3     						as		'COSTI_SPECIFICI_ANNO3',   
  @I_SOSTEGNO_AGLI_STUDENTI_ANNO3     				as		'I_SOSTEGNO_AGLI_STUDENTI_ANNO3',

  
/*new @VIII_Costi_del_Personale E21	Costi del Personale													*/
 @VIII_Costi_del_Personale_ANNO3  							AS 	'VIII_Costi_del_Personale_ANNO3',
/*1) Costi del personale dedicato alla ricerca e alla didattica E211	Costi del personale dedicato alla ricerca e alla didattica			*/
 @1_Costi_personale_dedicato_ricerca_didattica_ANNO3  		AS 	'1_Costi_personale_dedicato_ricerca_didattica_ANNO3',
 /*a) Docenti e Ricercatori E2111	Docenti e Ricercatori												*/
 @a_Docenti_e_Ricercatori_ANNO3  							AS 	'a_Docenti_e_Ricercatori_ANNO3',
 /*b) Collaborazioni scientifichE E2112	Collaborazioni scientifiche											*/
 @b_Collaborazioni_scientifiche_ANNO3  						AS 	'b_Collaborazioni_scientifiche_ANNO3',
/*E2113	Docenti a contratto	c) Docenti a contratto */
 @c_Docenti_a_contratto_ANNO3  								AS 	'c_Docenti_a_contratto_ANNO3',
 /*E2114	Esperti e linquistici d) Esperti e linquistici */
 @d_Esperti_e_linquistici_ANNO3  							AS 	'd_Esperti_e_linquistici_ANNO3',
 /*E2115	Altro personale dedicato alla ricerca e didattica	E) Altro personale dedicato alla ricerca e didattica	*/
 @e_Altro_personale_dedicato_ricerca_didattica_ANNO3  		AS 	'e_Altro_personale_dedicato_ricerca_didattica_ANNO3',
 /*E2116	Altri oneri per il personale dedicato alla ricerca e didattica f) Altri oneri per il personale dedicato alla ricerca e didattica	*/
 @f_Altri_oneri_personale_dedicato_ricerca_didattica_ANNO3  AS 	'f_Altri_oneri_personale_dedicato_ricerca_didattica_ANNO3',

/* 2) Costi del personale dedicato ai servizi generali e amministrativi	E212	Costi del personale dedicato ai servizi generali e amministrativi */
 @2_Costi_personale_dedicato_servizi_generali_amministrativi_ANNO3  AS '2_Costi_personale_dedicato_servizi_generali_amministrativi_ANNO3',
 /* a) Costi del personale dirigente e T.A.	E2121	Costi del personale dirigente e T.A. */
 @a_Costi_personale_dirigente_e_TA_ANNO3  							AS 'a_Costi_personale_dirigente_e_TA_ANNO3',
 /*b) Altro personale amministrativo	E2122	Altro personale amministrativo*/
 @b_Altro_personale_amministrativo_ANNO3  							AS 'b_Altro_personale_amministrativo_ANNO3',
 /* c) Altri onei per il personale amministrativo E2123	Altri onei per il personale amministrativo */
 @c_Altri_oneri_personale_amministrativo_ANNO3	  					AS 'c_Altri_oneri_personale_amministrativo_ANNO3',

 /* IX Costi della Gestione corrente		E22	Costi della Gestione corrente */
 @IX_Costi_Gestione_corrente_ANNO3	  								AS 'IX_Costi_Gestione_corrente_ANNO3',
/* 1) Costi per il sostegno agli studenti E221	Costi per il sostegno agli studenti */
 @1_Costi_sostegno_studenti_ANNO3	  								AS '1_Costi_sostegno_studenti_ANNO3',
 /* 2) Costi per il diritto allo studio E222	Costi per il diritto allo studio */
 @2_Costi_diritto_allo_studio_ANNO3	  								AS '2_Costi_diritto_allo_studio_ANNO3',
 /* 3) Costi per la ricerca e l'attività editoriale E223	Costi per la ricerca e l'attività editoriale */
 @3_Costi_ricerca_e_attivita_editoriale_ANNO3	  					AS '3_Costi_ricerca_e_attivita_editoriale_ANNO3',
 /* 4) Aquisto materiale di consumo per laboratori E224	Aquisto materiale di consumo per laboratori */
 @4_Acquisto_materiale_consumo_per_laboratori_ANNO3	  				AS '4_Acquisto_materiale_consumo_per_laboratori_ANNO3',
 /*5) Acquisto libri, periodici e materiale bibliografico E225	Acquisto libri, periodici e materiale bibliografico */
 @5_Acquisto_libri_periodici_e_materiale_bibliografico_ANNO3	  	AS '5_Acquisto_libri_periodici_e_materiale_bibliografico_ANNO3',
 /* 6) Acquisto di servizi e collaborazioni tecnico gestio	nali E226	Acquisto di servizi e collaborazioni tecnico gestionali */
 @6_Acquisto_servizi_collaborazioni_tecnico_gestionali_ANNO3	  	AS '6_Acquisto_servizi_collaborazioni_tecnico_gestionali_ANNO3',
 /* 7) Acquisto altri materiali E227	Acquisto altri materiali */
 @7_Acquisto_altri_materiali_ANNO3	  								AS '7_Acquisto_altri_materiali_ANNO3',
 /*8) Costi per il godimento beni di terzi E228	Costi per il godimento beni di terzi */
 @8_Costi_per_godimento_beni_di_terzi_ANNO3	  						AS '8_Costi_per_godimento_beni_di_terzi_ANNO3',
 /* 9) Altri costi operativi E229	Altri costi operativi */
 @9_Altri_costi_operativi_ANNO3	  									AS '9_Altri_costi_operativi_ANNO3',
 /* 10) Trasferimenti e contributi E22A	Trasferimenti e contributi */
 @10_Trasferimenti_e_contributi_ANNO3	  							AS '10_Trasferimenti_e_contributi_ANNO3',
  /* a) Trasferimento a partner per progetti coordinati E22A1	Trasferimento a partner per progetti coordinati */
 @a_Trasferimento_a_partner_progetti_coordinati_ANNO3	  			AS 'a_Trasferimento_a_partner_progetti_coordinati_ANNO3',
 /* b) Contributi per investimenti in ricerca E22A2	Contributi per investimenti in ricerca */
 @b_Contributi_per_investimenti_ricerca_ANNO3	  					AS 'b_Contributi_per_investimenti_ricerca_ANNO3',
 /* c) Trasferimenti correnti E22A3	Trasferimenti correnti */
 @c_Trasferimenti_correnti_ANNO3	  								AS 'c_Trasferimenti_correnti_ANNO3',
 /* d) Trasferimenti in conto capitale  E22A4	Trasferimenti in conto capitale*/
 @d_Trasferimenti_conto_capitale_ANNO3	  							AS 'd_Trasferimenti_conto_capitale_ANNO3',

/* X  Ammortamenti e Svalutazioni E23	Ammortamenti e Svalutazioni */
 @X_Ammortamenti_e_Svalutazioni_ANNO3	AS 'X_Ammortamenti_e_Svalutazioni_ANNO3',
 /* 1) Ammortamenti  E231	Ammortamenti*/
 @1_Ammortamenti_ANNO3	  				AS '1_Ammortamenti_ANNO3',
 /* 2) Svalutazioni E232	Svalutazioni */
 @2_Svalutazioni_ANNO3	  				AS '2_Svalutazioni_ANNO3',

/* XI Accantonamenti per rischi e oneri E24	Accantonamenti per rischi e oneri */
 @XI_Accantonamenti_rischi_oneri_ANNO3	  AS 'XI_Accantonamenti_rischi_oneri_ANNO3',

/* XII Budget economico dei Progetti di ricerca E25	Budget economico dei Progetti di ricerca */
 @XII_Budget_economico_progetti_ricerca_ANNO3	  AS 'XII_Budget_economico_progetti_ricerca_ANNO3',

/*Totale costi operativi*/
  @COSTI_OPERATIVI_ANNO3   						as								'TOTALE_COSTI_OPERATIVI_ANNO3', 

------------------------------------------------------------------------------------------------------------------------------------------

/* Gestione Operativa(A-B) 
A = @PROVENTIOPERATIVI	E1 calcolati da una somma
B = @COSTI_OPERATIVI	E2
*/
 @Gestione_Operativa_ANNO3	  AS 'Gestione_Operativa_ANNO3',

/* 1) Proventi Finanziari e utili su cambi E311	Proventi Finanziari e utili su cambi */
 @1_Proventi_Finanziari_utili_su_cambi_ANNO3	  AS '1_Proventi_Finanziari_utili_su_cambi_ANNO3',

/* 2) Oneri Finanziari e perdite su cambi E312	Oneri Finanziari e perdite su cambi */
 @2_Oneri_Finanziari_perdite_cambi_ANNO3	  AS '2_Oneri_Finanziari_perdite_cambi_ANNO3',

/* 1) Rivalutazioni attività finanziarie  E411	Rivalutazioni attività finanziarie*/
 @1_Rivalutazioni_attivita_finanziarie_ANNO3	  AS '1_Rivalutazioni_attivita_finanziarie_ANNO3',

/* 2) Svalutazioni attività finanziarie E412	Svalutazioni attività finanziarie */
 @2_Svalutazioni_attivita_finanziarie_ANNO3	  AS '2_Svalutazioni_attivita_finanziarie_ANNO3',


------------------------------------------------------------------------------------------------------------------------------------------
/*Gestione finanziaria (C1 + D1 - C2 -D2) */
 @Gestione_Finanziaria_ANNO3	  AS 'Gestione_Finanziaria_ANNO3',

/* 1) Proventi straordinari E511	Proventi straordinari */
 @1_Proventi_straordinari_ANNO3	  AS '1_Proventi_straordinari_ANNO3',

/* 2) Oneri Straordinari E512	Oneri Straordinari*/
 @2_Oneri_straordinari_ANNO3	  AS '2_Oneri_straordinari_ANNO3',

------------------------------------------------------------------------------------------------------------------------------------------

/* Gestione straordinaria (E1 - E2) */
 @Gestione_Straordinaria_ANNO3	  AS 'Gestione_Straordinaria_ANNO3',

/* F) Imposte e tasse E6	Imposte e tasse*/
 @F_Imposte_e_tasse_ANNO3	  AS 'F_Imposte_e_tasse_ANNO3',

/*Risultato Economico Atteso */
@Gestione_Operativa_ANNO3 + @Gestione_Finanziaria_ANNO3 + @Gestione_Straordinaria_ANNO3 - @F_Imposte_e_tasse_ANNO3 AS 'Risultato_Economico_Atteso_ANNO3'

				

				
END

