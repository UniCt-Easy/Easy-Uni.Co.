
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_budgeteconomicoufficiale]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_budgeteconomicoufficiale]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
-- exec rpt_budgeteconomicoufficiale 2015, 62,'%','S',null,null,null,null,null,'S'
CREATE      PROCEDURE [rpt_budgeteconomicoufficiale](
	@ayear int,--> anno del bilancio di previsione
	@idsorkind int=null,
	@idupb varchar(36)='%',
	@showchildupb char(1)='S',
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null,
	@budgetpuro char(1)
)
AS BEGIN
if (@budgetpuro='S') 
	Begin
		exec rpt_budgeteconomicoufficiale_puro @ayear, @idupb,@showchildupb,	@idsor01,@idsor02,@idsor03,	@idsor04,@idsor05
		RETURN
	End

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

DECLARE @idupboriginal varchar(36)
SET @idupboriginal= @idupb
IF (@showchildupb = 'S')  AND ISNULL(@idupb,'') <> '%'
BEGIN
	SET @idupb=@idupb+'%' 
END

/*	I. PROVENTI PROPRI
	1)Proventi per la didattica
	2)Proventi da Ricerche commissionate e trasferimento tecnologico
	3)Proventi da Ricerche con finanziamento competitivi
*/
declare @A_I1_ProventiPerLaDidattica decimal(19,2)
set @A_I1_ProventiPerLaDidattica = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'EA1101%'),0)

declare @A_I2_ProventiDaRicercheCommissionate decimal(19,2)
set @A_I2_ProventiDaRicercheCommissionate = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'EA1102%'),0)

declare @A_I3_ProventiDaRicercheConFinanziamento decimal(19,2)
set @A_I3_ProventiDaRicercheConFinanziamento = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'EA1103%'),0)

declare @A_I_ProventiPropri decimal(19,2)
set @A_I_ProventiPropri = @A_I1_ProventiPerLaDidattica + @A_I2_ProventiDaRicercheCommissionate + @A_I3_ProventiDaRicercheConFinanziamento

/*
	II.CONTRIBUTI
	1)Contributi MIUR e altre Amministrazioni centrali
	2)Contributi Regioni e Province autonome
	3)Contributi altre Amministrazioni locali
	4)Contributi Unione Europea e altri Organismi Internazionali
	5)Contributi da Università
	6)Contributi da altri (pubblici)
	7)Contributi da altri (privati)
*/
declare @A_II1_ContributiMIUR decimal(19,2)
set @A_II1_ContributiMIUR = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'EA1201%'),0)

declare @A_II2_ContributiRegioni decimal(19,2)
set @A_II2_ContributiRegioni = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'EA1202%'),0)

declare @A_II3_ContributiAltreAmministrazioni decimal(19,2)
set @A_II3_ContributiAltreAmministrazioni = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'EA1203%'),0)

declare @A_II4_ContributiUE decimal(19,2)
set @A_II4_ContributiUE = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'EA1204%'),0)

declare @A_II5_ContributiUniversita decimal(19,2)
set @A_II5_ContributiUniversita = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'EA1205%'),0)

declare @A_II6_ContributiAltriPubblici decimal(19,2)
set @A_II6_ContributiAltriPubblici = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'EA1206%'),0)

declare @A_II7_ContributiAltriPrivati decimal(19,2)
set @A_II7_ContributiAltriPrivati = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'EA1207%'),0)

declare @A_II_Contributi decimal(19,2)
set @A_II_Contributi = @A_II1_ContributiMIUR + @A_II2_ContributiRegioni + @A_II3_ContributiAltreAmministrazioni 
						+ @A_II4_ContributiUE + @A_II5_ContributiUniversita +  @A_II6_ContributiAltriPubblici + @A_II7_ContributiAltriPrivati

declare @A_III_ProventiPerAttivitaAssistenziale decimal(19,2)
set @A_III_ProventiPerAttivitaAssistenziale = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'EA1301%'),0)

-- IV. PROVENTI PER GESTIONE DIRETTA INTERVENTI PER IL DIRITTO ALLO STUDIO
declare @A_IV_ProventiPerGestioneDiretta decimal(19,2)
set @A_IV_ProventiPerGestioneDiretta = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'EA1401%'),0)

-- V.ALTRI PROVENTI E RICAVI DIVERSI
-- 1) Utilizzo di riserve di Patrimonio netto derivanti dalla contabilità finanziaria
-- 2) Altri Proventi e Ricavi Diversi
declare @A_V1_UtilizzoRiservePatrimonioNetto decimal(19,2)
set @A_V1_UtilizzoRiservePatrimonioNetto = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'EA1501%'),0)
		
declare @A_V2_AltriProventi decimal(19,2)
set @A_V2_AltriProventi = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'EA1502%'),0)
		
declare @A_V_UtilizzoRiservePatrimonioNetto decimal(19,2)
set @A_V_UtilizzoRiservePatrimonioNetto = @A_V1_UtilizzoRiservePatrimonioNetto + @A_V2_AltriProventi
-- Variazione Rimanenze
declare @A_VI_VariazioniRimanenze decimal(19,2)
set @A_VI_VariazioniRimanenze = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'EA1601%'),0)


-- Incremento delle Immobilizzazioni per Lavori Interni
declare @A_VII_IncrementoImmobilizzazioni decimal(19,2)
set @A_VII_IncrementoImmobilizzazioni = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'EA1701%'),0)
/*
 B)	COSTI OPERATIVI
VIII.COSTI DEL PERSONALE
	1) Costi del personale dedicato alla ricerca e alla didattica
		a)Docenti/ricercatori
		b)Collaborazioni scientifiche (collaboratori, assegnisti, ecc)
		c)Docenti a contratto 
		d)Esperti linguistici
		e)Altro personale dedicato alla didattica e alla ricerca
	2) Costi del personale dirigente e tecnico-amministrativo
*/

declare @B_VIII1a_CostiDocentiRicercatori decimal(19,2)
set @B_VIII1a_CostiDocentiRicercatori = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'EB1101%'),0)

declare @B_VIII1b_CollaborazioniScientifiche decimal(19,2)
set @B_VIII1b_CollaborazioniScientifiche = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'EB1102%'),0)

declare @B_VIII1c_DocentiAContratto  decimal(19,2)
set @B_VIII1c_DocentiAContratto = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'EB1103%'),0)

declare @B_VIII1d_EspertiLinguistici decimal(19,2)
set @B_VIII1d_EspertiLinguistici = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'EB1104%'),0)

declare @B_VIII1e_AltroPersonale decimal(19,2)
set @B_VIII1e_AltroPersonale = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'EB1105%'),0)

declare @B_VIII2_CostiPersonaleDirigente decimal(19,2)
set @B_VIII2_CostiPersonaleDirigente = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'EB1201%'),0)

declare @B_VIII_CostiPersonale decimal(19,2)
set @B_VIII_CostiPersonale = @B_VIII1a_CostiDocentiRicercatori + @B_VIII1b_CollaborazioniScientifiche + @B_VIII1c_DocentiAContratto + @B_VIII1d_EspertiLinguistici + @B_VIII1e_AltroPersonale + @B_VIII2_CostiPersonaleDirigente

	/*
	IX.COSTI DELLA GESTIONE CORRENTE
	1)Costi per sostegno agli studenti
	2)Costi per il diritto allo studio
	3)Costi per la ricerca e l'attività editoriale
	4)Trasferimenti a partner di progetti coordinati
	5)Acquisto materiale consumo per laboratori
	6)Variazione rimanenze di materiale di consumo per laboratori
	7)Acquisto di libri, periodici e materiale bibliografico
	8)Acquisto di servizi e collaborazioni tecnico gestionali
	9)Acquisto altri materiali
	10)Variazione delle rimanenze di materiali
	11)Costi per godimento bene di terzi
	12)Altri  costi 
	*/
declare @B_IX1_CostiSostegnoStudenti decimal(19,2)
set @B_IX1_CostiSostegnoStudenti = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'EB2101%'),0)

declare @B_IX2_CostiDirittoStudio decimal(19,2)
set @B_IX2_CostiDirittoStudio = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'EB2102%'),0)

declare @B_IX3_CostiRicercaAttivitaEditoriale decimal(19,2)
set @B_IX3_CostiRicercaAttivitaEditoriale = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'EB2103%'),0)

declare @B_IX4_TrasferimentiPartner decimal(19,2)
set @B_IX4_TrasferimentiPartner = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'EB2104%'),0)

declare @B_IX5_AcquistoMaterialeConsumo  decimal(19,2)
set @B_IX5_AcquistoMaterialeConsumo = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'EB2105%'),0)

declare @B_IX6_VariazioneRimanenze decimal(19,2)
set @B_IX6_VariazioneRimanenze = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'EB2106%'),0)

declare @B_IX7_AcquistoLibri decimal(19,2)
set @B_IX7_AcquistoLibri = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'EB2107%'),0)

declare @B_IX8_AcquistoServizi decimal(19,2)
set @B_IX8_AcquistoServizi = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'EB2108%'),0)

declare @B_IX9_AcquistoAltriMateriali decimal(19,2)
set @B_IX9_AcquistoAltriMateriali = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'EB2109%'),0)

declare @B_IX10_VariazioneRimanenze decimal(19,2)
set @B_IX10_VariazioneRimanenze = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'EB2110%'),0)

declare @B_IX11_CostiGodimento decimal(19,2)
set @B_IX11_CostiGodimento = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'EB2111%'),0)

declare @B_IX12_AltriCosti  decimal(19,2)
set @B_IX12_AltriCosti = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'EB2112%'),0)

declare @IX_CostiGestione decimal(19,2)
set @IX_CostiGestione = @B_IX1_CostiSostegnoStudenti + @B_IX2_CostiDirittoStudio + @B_IX3_CostiRicercaAttivitaEditoriale  
						+ @B_IX4_TrasferimentiPartner + @B_IX5_AcquistoMaterialeConsumo +@B_IX6_VariazioneRimanenze 
						+ @B_IX7_AcquistoLibri + @B_IX8_AcquistoServizi + @B_IX9_AcquistoAltriMateriali + @B_IX10_VariazioneRimanenze 
						+@B_IX11_CostiGodimento  + @B_IX12_AltriCosti
/*	
	X.AMMORTAMENTI E SVALUTAZIONI
		1) Ammortamenti immobilizzazioni immateriali
		2) Ammortamenti immobilizzazioni materiali
		3) Svalutazioni immobilizzazioni
		4) Svalutazioni dei crediti compresi nell'attivo circolante e nelle disponibilità liquide
*/
declare @B_X1_AmmortamentiImmobImmateriali decimal(19,2)
set @B_X1_AmmortamentiImmobImmateriali = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'EB3101%'),0)

declare @B_X2_AmmortamentiImmobMateriali decimal(19,2)
set @B_X2_AmmortamentiImmobMateriali = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'EB3102%'),0)

declare @B_X3_SvalutazioniImmobilizzazioni decimal(19,2)
set @B_X3_SvalutazioniImmobilizzazioni = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'EB3103%'),0)

declare @B_X4_SvalutazioniCrediti decimal(19,2)
set @B_X4_SvalutazioniCrediti = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'EB3104%'),0)

declare @X_AmmortamentiSvalutazioni decimal(19,2)
set @X_AmmortamentiSvalutazioni = @B_X1_AmmortamentiImmobImmateriali + @B_X2_AmmortamentiImmobMateriali + @B_X3_SvalutazioniImmobilizzazioni + @B_X4_SvalutazioniCrediti 

declare @B_XI_AccantonamentiRischiOneri decimal(19,2)
set @B_XI_AccantonamentiRischiOneri = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'EB4101%'),0)

declare @B_XII_OneriDversiGestione decimal(19,2)
set @B_XII_OneriDversiGestione = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'EB5101%'),0)
/*
	C) PROVENTI ED ONERI FINANZIARI
	1) Proventi finanziari
	2) Interessi ed altri oneri finanziari 
	3) Utili su cambi 
	4) Perdite su cambi 
*/
declare @C_1ProventiFinanziari decimal(19,2)
set @C_1ProventiFinanziari = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'EC1101%'),0)

declare @C_2Interessi_orig decimal(19,2)
declare @C_2Interessi decimal(19,2)
set @C_2Interessi_orig = ISNULL(( SELECT  SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'EC1102%'),0)

if (@C_2Interessi_orig < 0) set @C_2Interessi = -@C_2Interessi_orig else set @C_2Interessi = @C_2Interessi_orig

declare @C_3Utili decimal(19,2)
set @C_3Utili = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'EC1103%'),0)

declare @C_3Perdite decimal(19,2)
set @C_3Perdite = ISNULL(( SELECT - SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'EC1104%'),0)

declare @C_ProventiOneri decimal(19,2)
declare @C_ProventiOneri_orig decimal(19,2)
set @C_ProventiOneri_orig = @C_1ProventiFinanziari - @C_2Interessi+ @C_3Utili + @C_3Perdite
if (@C_ProventiOneri_orig < 0) SET @C_ProventiOneri = - @C_ProventiOneri_orig else set @C_ProventiOneri = @C_ProventiOneri_orig

/*
	D) RETTIFICHE DI VALORE DI ATTIVITA' FINANZIARIE
		1) Rivalutazioni di attività finanziarie
		2) Svalutazioni di attività finanziarie
*/
declare @D_1Rivalutazioni decimal(19,2)
set @D_1Rivalutazioni = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'ED1101%'),0)

declare @D_2Svalutazioni decimal(19,2)
declare @D_2Svalutazioni_orig decimal(19,2)
set @D_2Svalutazioni_orig = ISNULL(( SELECT - SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'ED1102%'),0)

if (@D_2Svalutazioni_orig < 0) SET @D_2Svalutazioni = - @D_2Svalutazioni_orig else set @D_2Svalutazioni = @D_2Svalutazioni_orig

declare @D_Rettifiche_orig decimal(19,2)
declare @D_Rettifiche decimal(19,2)

set @D_Rettifiche_orig = @D_1Rivalutazioni - @D_2Svalutazioni
if (@D_Rettifiche_orig < 0) SET @D_Rettifiche = - @D_Rettifiche_orig else set @D_Rettifiche = @D_Rettifiche_orig


/*
	E)	PROVENTI ED ONERI STRAORDINARI
		1) Proventi straordinari
		2) Oneri straordinari
*/
			
declare @E_1ProventiStraordinari  decimal(19,2)
set @E_1ProventiStraordinari = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'EE1101%'),0)

declare @E_2OneriStraordinari  decimal(19,2)
declare @E_2OneriStraordinari_orig  decimal(19,2)
set @E_2OneriStraordinari_orig = ISNULL(( SELECT  SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'EE1102%'),0)

if (@E_2OneriStraordinari_orig < 0) SET @E_2OneriStraordinari = - @E_2OneriStraordinari_orig else set @E_2OneriStraordinari = @E_2OneriStraordinari_orig

declare @E_ProventiOneriStraordinari_orig decimal(19,2)
declare @E_ProventiOneriStraordinari decimal(19,2)
set @E_ProventiOneriStraordinari_orig = @E_1ProventiStraordinari - @E_2OneriStraordinari

if (@E_ProventiOneriStraordinari_orig < 0) SET @E_ProventiOneriStraordinari = - @E_ProventiOneriStraordinari_orig else set @E_ProventiOneriStraordinari = @E_ProventiOneriStraordinari_orig

/*
F) Imposte sul reddito dell'esercizio correnti, differite, anticipate
*/

declare @F_Imposte_orig  decimal(19,2)
declare @F_Imposte  decimal(19,2)
set @F_Imposte_orig = ISNULL(( SELECT - SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'EF1101%'),0)

if (@F_Imposte_orig < 0) SET @F_Imposte = - @F_Imposte_orig else set @F_Imposte = @F_Imposte_orig

/*
	G) Utilizzo di riservedi Patrimonio Netto derivanti dalla contabilità economico-patrimoniale
*/
declare @G_UtilizzoDiRiserve  decimal(19,2)
set @G_UtilizzoDiRiserve = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
		AND S.sortcode LIKE 'EG1101%'),0)

DECLARE @TOTRICAVI decimal(19,2)
/*SET @TOTRICAVI = @A_I_ProventiPropri + @A_II_Contributi + @A_III_ProventiPerAttivitaAssistenziale + @A_IV_ProventiPerGestioneDiretta +
				@A_V_UtilizzoRiservePatrimonioNetto + @A_VI_VariazioniRimanenze + @A_VII_IncrementoImmobilizzazioni
				+ @C_1ProventiFinanziari  +  @C_3Utili 
				+ @D_1Rivalutazioni
				+ @E_1ProventiStraordinari 
*/
DECLARE @TOTCOSTI decimal(19,2)
/*SET @TOTCOSTI = @B_VIII_CostiPersonale + @IX_CostiGestione + @X_AmmortamentiSvalutazioni + @B_XI_AccantonamentiRischiOneri + @B_XII_OneriDversiGestione
				   - @C_2Interessi + @C_3Perdite
				   + @D_2Svalutazioni
				   - @E_2OneriStraordinari
				   + @F_Imposte 
				   -->  Interessi, Oneri straordinari sono col segno meno, perchè vengono letti col segno -, ma in questo contesto vanno sommati.
*/
declare @RisultatoEconomicoPresunto decimal(19,2)
---set @RisultatoEconomicoPresunto = @TOTRICAVI - @TOTCOSTI
set @RisultatoEconomicoPresunto = 
				@A_I_ProventiPropri + @A_II_Contributi + @A_III_ProventiPerAttivitaAssistenziale + @A_IV_ProventiPerGestioneDiretta +
				@A_V_UtilizzoRiservePatrimonioNetto + @A_VI_VariazioniRimanenze + @A_VII_IncrementoImmobilizzazioni
				- (@B_VIII_CostiPersonale + @IX_CostiGestione + @X_AmmortamentiSvalutazioni + @B_XI_AccantonamentiRischiOneri + @B_XII_OneriDversiGestione)
				+ @C_ProventiOneri_orig+ @D_Rettifiche_orig + @E_ProventiOneriStraordinari_orig - @F_Imposte

declare @RisultatoAPareggio decimal(19,2)
set @RisultatoAPareggio = @RisultatoEconomicoPresunto + @G_UtilizzoDiRiserve


DECLARE @codeupb	varchar(50)
DECLARE @title		varchar(150)
 
SELECT	@codeupb = codeupb,
		@title = title
FROM	upb 
WHERE	idupb = @idupboriginal

SELECT
  @ayear				  AS ayear         ,
  @idupboriginal		  as idupb         ,
  @codeupb				  as codeupb	   ,
  @title				  as upb		   ,
	@treasurer as department,
  @A_I1_ProventiPerLaDidattica  	as	  'A_I1_ProventiPerLaDidattica',  
  @A_I2_ProventiDaRicercheCommissionate  	as	  'A_I2_ProventiDaRicercheCommissionate',  
  @A_I3_ProventiDaRicercheConFinanziamento  	as	  'A_I3_ProventiDaRicercheConFinanziamento',  
  @A_I_ProventiPropri  	as	  'A_I_ProventiPropri',  
  @A_II1_ContributiMIUR  	as	  'A_II1_ContributiMIUR',  
  @A_II2_ContributiRegioni  	as	  'A_II2_ContributiRegioni',  
  @A_II3_ContributiAltreAmministrazioni  	as	  'A_II3_ContributiAltreAmministrazioni',  
  @A_II4_ContributiUE  	as	  'A_II4_ContributiUE',  
  @A_II5_ContributiUniversita  	as	  'A_II5_ContributiUniversita',  
  @A_II6_ContributiAltriPubblici  	as	  'A_II6_ContributiAltriPubblici',  
  @A_II7_ContributiAltriPrivati  	as	  'A_II7_ContributiAltriPrivati',  
  @A_II_Contributi  	as	  'A_II_Contributi',  
  @A_III_ProventiPerAttivitaAssistenziale  	as	  'A_III_ProventiPerAttivitaAssistenziale',  
  @A_IV_ProventiPerGestioneDiretta  	as	  'A_IV_ProventiPerGestioneDiretta',  
  @A_V1_UtilizzoRiservePatrimonioNetto  as 'A_V1_UtilizzoRiservePatrimonioNetto ',
  @A_V2_AltriProventi as 'A_V2_AltriProventi',
  @A_V_UtilizzoRiservePatrimonioNetto  	as	  'A_V_UtilizzoRiservePatrimonioNetto',  
  @A_VI_VariazioniRimanenze  	as	  'A_VI_VariazioniRimanenze',  
  @A_VII_IncrementoImmobilizzazioni  	as	  'A_VII_IncrementoImmobilizzazioni',  
  @B_VIII1a_CostiDocentiRicercatori  	as	  'B_VIII1a_CostiDocentiRicercatori',  
  @B_VIII1b_CollaborazioniScientifiche  	as	  'B_VIII1b_CollaborazioniScientifiche',  
  @B_VIII1c_DocentiAContratto   	as	  'B_VIII1c_DocentiAContratto',   
  @B_VIII1d_EspertiLinguistici  	as	  'B_VIII1d_EspertiLinguistici',  
  @B_VIII1e_AltroPersonale  	as	  'B_VIII1e_AltroPersonale',  
  @B_VIII2_CostiPersonaleDirigente  	as	  'B_VIII2_CostiPersonaleDirigente',  
  @B_VIII_CostiPersonale  	as	  'B_VIII_CostiPersonale',  
  @B_IX1_CostiSostegnoStudenti  	as	  'B_IX1_CostiSostegnoStudenti',  
  @B_IX2_CostiDirittoStudio  	as	  'B_IX2_CostiDirittoStudio',  
  @B_IX3_CostiRicercaAttivitaEditoriale  	as	  'B_IX3_CostiRicercaAttivitaEditoriale',  
  @B_IX4_TrasferimentiPartner  	as	  'B_IX4_TrasferimentiPartner',  
  @B_IX5_AcquistoMaterialeConsumo   	as	  'B_IX5_AcquistoMaterialeConsumo',   
  @B_IX6_VariazioneRimanenze  	as	  'B_IX6_VariazioneRimanenze',  
  @B_IX7_AcquistoLibri  	as	  'B_IX7_AcquistoLibri',  
  @B_IX8_AcquistoServizi  	as	  'B_IX8_AcquistoServizi',  
  @B_IX9_AcquistoAltriMateriali  	as	  'B_IX9_AcquistoAltriMateriali',  
  @B_IX10_VariazioneRimanenze  	as	  'B_IX10_VariazioneRimanenze',  
  @B_IX11_CostiGodimento  	as	  'B_IX11_CostiGodimento',  
  @B_IX12_AltriCosti   	as	  'B_IX12_AltriCosti',   
  @IX_CostiGestione  	as	  'IX_CostiGestione',  
  @B_X1_AmmortamentiImmobImmateriali  	as	  'B_X1_AmmortamentiImmobImmateriali',  
  @B_X2_AmmortamentiImmobMateriali  	as	  'B_X2_AmmortamentiImmobMateriali',  
  @B_X3_SvalutazioniImmobilizzazioni  	as	  'B_X3_SvalutazioniImmobilizzazioni',
  @B_X4_SvalutazioniCrediti  	as	  'B_X4_SvalutazioniCrediti',  
  @X_AmmortamentiSvalutazioni  	as	  'X_AmmortamentiSvalutazioni',  
  @B_XI_AccantonamentiRischiOneri  	as	  'B_XI_AccantonamentiRischiOneri',  
  @B_XII_OneriDversiGestione  	as	  'B_XII_OneriDversiGestione',  
  @C_1ProventiFinanziari  	as	  'C_1ProventiFinanziari',  
  @C_2Interessi  	as	  'C_2Interessi',  
  @C_3Utili  	as	  'C_3Utili',  
  @C_3Perdite  	as	  'C_3Perdite',  
  @C_ProventiOneri  	as	  'C_ProventiOneri',  
  @D_1Rivalutazioni  	as	  'D_1Rivalutazioni',  
  @D_2Svalutazioni  	as	  'D_2Svalutazioni',   
  @D_Rettifiche  	as	  'D_Rettifiche',  
  @E_1ProventiStraordinari   	as	  'E_1ProventiStraordinari',   
  @E_2OneriStraordinari   	as	  'E_2OneriStraordinari',  
  @E_ProventiOneriStraordinari  	as	  'E_ProventiOneriStraordinari',  
  @F_Imposte   	as	  'F_Imposte',   
  @G_UtilizzoDiRiserve   	as	  'G_UtilizzoDiRiserve',   
  @TOTRICAVI  	as	  'TotRicavi',  
  @TOTCOSTI  	as	  'TotCosto',  
  @RisultatoEconomicoPresunto  	as	  'RisultatoEconomicoPresunto', 
  @RisultatoAPareggio 	as	  'RisultatoAPareggio' 
		




				
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


