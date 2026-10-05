/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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

if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_budgeteconomicoufficiale_puro_consorzio]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_budgeteconomicoufficiale_puro_consorzio]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
-- setuser 'amministrazione'
-- exec rpt_budgeteconomicoufficiale_puro_consorzio 2024, '%','S'
CREATE      PROCEDURE [rpt_budgeteconomicoufficiale_puro_consorzio](
	@ayear int,--> anno del bilancio di previsione
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

DECLARE @idupboriginal varchar(36)
SET @idupboriginal= @idupb
IF (@showchildupb = 'S')  AND ISNULL(@idupb,'') <> '%'
BEGIN
	SET @idupb=@idupb+'%' 
END

/*
	A) VALORE DELLA PRODUZIONE
	A)1) Proventi da ruoli contributivi 
	A)2) Contributi per manutenzione straordinaria su beni di terzi 
	A)3) Contributi per realizzazione nuove opere di terzi 
	A)4) Incrementi di immobilizzazioni per lavori interni
	A)5) Altri ricavi e proventi
*/
declare @A_1_ProventiRuoliContributivi decimal(19,2)
set @A_1_ProventiRuoliContributivi = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EA0101%'),0)

declare @A_2_ContributiManutenzioneStraordinaria decimal(19,2)
set @A_2_ContributiManutenzioneStraordinaria = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EA0102%'),0)

declare @A_3_ContributiReallizzazioneNuoveOpere decimal(19,2)
set @A_3_ContributiReallizzazioneNuoveOpere = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EA0103%'),0)

declare @A_4_IncrementiImmobilizzazioniLavori decimal(19,2)
set @A_4_IncrementiImmobilizzazioniLavori = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EA0104%'),0)

declare @A_5_AltriRicaviProventi decimal(19,2)
set @A_5_AltriRicaviProventi = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EA0105%'),0)

declare @A_ValoreProduzione decimal(19,2)
set @A_ValoreProduzione = @A_1_ProventiRuoliContributivi + @A_2_ContributiManutenzioneStraordinaria + @A_3_ContributiReallizzazioneNuoveOpere +
							@A_4_IncrementiImmobilizzazioniLavori + @A_5_AltriRicaviProventi

/*
	B) COSTI DELLA PRODUZIONE
	B)6) Acquisti di beni 
	B)7) Acquisti di servizi
	B)7)a) Manutenzione ordinaria in appalto 
	B)7)b) Manutenzione straordinaria in appalto finanziata con risorse di terzi	
	B)7)c) Realizzazione nuove opere in appalto finanziata con risorse di terzi
	B)7)d) Altri servizi 
	B)8) Variazione delle rimanenze
	B)9) Godimento di beni di terzi 
	B)10) Personale 
	B)11) Ammortamenti e svalutazioni 
	B)12) Accantonamenti per rischi ed oneri 
	B)13) Oneri diversi di gestione
*/
declare @B_6_AcquistiBeni decimal(19,2)
set @B_6_AcquistiBeni = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EB0601%'),0)

declare @B_7A_ManutenzioneOrdinaria decimal(19,2)
set @B_7A_ManutenzioneOrdinaria = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EB0701%'),0)

declare @B_7B_ManutenzioneStraordinaria decimal(19,2)
set @B_7B_ManutenzioneStraordinaria = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EB0702%'),0)

declare @B_7C_RealizzazioneNuoveOpere decimal(19,2)
set @B_7C_RealizzazioneNuoveOpere = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EB0703%'),0)

declare @B_7D_AltriServizi decimal(19,2)
set @B_7D_AltriServizi = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EB0704%'),0)

declare @B_8_VariazioneRimanenze decimal(19,2)
set @B_8_VariazioneRimanenze = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EB0801%'),0)

declare @B_9_GodimentoBeniTerzi decimal(19,2)
set @B_9_GodimentoBeniTerzi = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EB0901%'),0)

declare @B_10_Personale decimal(19,2)
set @B_10_Personale = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EB1001%'),0)

declare @B_11_AmmortamentiSvalutazioni decimal(19,2)
set @B_11_AmmortamentiSvalutazioni = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EB1101%'),0)

declare @B_12_AccantonamentiRischiOneri decimal(19,2)
set @B_12_AccantonamentiRischiOneri = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EB1201%'),0)

declare @B_13_OneriDiversiGestione decimal(19,2)
set @B_13_OneriDiversiGestione = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EB1301%'),0)

declare @B_CostiProduzione decimal(19,2)
set @B_CostiProduzione = @B_6_AcquistiBeni + @B_7A_ManutenzioneOrdinaria + @B_7B_ManutenzioneStraordinaria + @B_7C_RealizzazioneNuoveOpere + @B_7D_AltriServizi + @B_8_VariazioneRimanenze +
						@B_9_GodimentoBeniTerzi + @B_10_Personale + @B_11_AmmortamentiSvalutazioni + @B_12_AccantonamentiRischiOneri + @B_13_OneriDiversiGestione

declare @DifferenzaValoriCostiProduzione decimal(19,2)
set @DifferenzaValoriCostiProduzione = @A_ValoreProduzione - @B_CostiProduzione

/*
	C) PROVENTI E ONERI FINANZIARI
	C)1) Interessi attivi 
	C)2) Altri proventi finanziari
	C)3) Interessi passivi 
	C)4) Altri oneri finanziari
*/
declare @C_1_InteressiAttivi decimal(19,2)
set @C_1_InteressiAttivi = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EC0101%'),0)

declare @C_2_AltriProventiFinanziari decimal(19,2)
set @C_2_AltriProventiFinanziari = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EC0102%'),0)

declare @C_3_InteressiPassivi decimal(19,2)
set @C_3_InteressiPassivi = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EC0103%'),0)

declare @C_4_AltriOneriFinanziari decimal(19,2)
set @C_4_AltriOneriFinanziari = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EC0104%'),0)

declare @C_ProventiOneriFinanziari decimal(19,2)
set @C_ProventiOneriFinanziari = @C_1_InteressiAttivi + @C_2_AltriProventiFinanziari - @C_3_InteressiPassivi - @C_4_AltriOneriFinanziari

/*
	D) RETTIFICHE DI VALORE DI ATTIVITA' FINANZIARIE
	D)1) Rivalutazioni
	D)2) Svalutazioni
*/
declare @D_1_Rivalutazioni decimal(19,2)
set @D_1_Rivalutazioni = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'ED0101%'),0)

declare @D_2_Svalutazioni decimal(19,2)
set @D_2_Svalutazioni = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'ED0102%'),0)

declare @D_RettificheValoreAttivita decimal(19,2)
set @D_RettificheValoreAttivita = @D_1_Rivalutazioni - @D_2_Svalutazioni

/*
	E) PROVENTI E ONERI STRAORDINARI
	E)1) Proventi straordinari 
	E)2) Oneri straordinari
*/
declare @E_1_ProventiStraordinari decimal(19,2)
set @E_1_ProventiStraordinari = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EE0101%'),0)

declare @E_2_OneriStraordinari decimal(19,2)
set @E_2_OneriStraordinari = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EE0102%'),0)

declare @E_ProventiOneriStraordinari decimal(19,2)
set @E_ProventiOneriStraordinari = @E_1_ProventiStraordinari - @E_2_OneriStraordinari

declare @RisultatoSenzaImposte decimal(19,2)
set @RisultatoSenzaImposte = @A_ValoreProduzione - @B_CostiProduzione + @C_ProventiOneriFinanziari + @D_RettificheValoreAttivita + @E_ProventiOneriStraordinari

/*
	F) Imposte sul reddito dell'esercizio correnti, differite, anticipate
*/
declare @F_ImposteReddito decimal(19,2)
set @F_ImposteReddito = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EF0101%'),0)

declare @RisultatoEconomicoPresunto decimal(19,2)
set @RisultatoEconomicoPresunto = @RisultatoSenzaImposte - @F_ImposteReddito

DECLARE @codeupb	varchar(50)
DECLARE @title		varchar(150)
 
SELECT	@codeupb = codeupb,
		@title = title
FROM	upb 
WHERE	idupb = @idupboriginal

SELECT
@ayear					as ayear,
@idupboriginal			as idupb,
@codeupb				as codeupb,
@title					as upb,
@treasurer				as department,
@A_1_ProventiRuoliContributivi					as 'A_1_ProventiRuoliContributivi',
@A_2_ContributiManutenzioneStraordinaria		as 'A_2_ContributiManutenzioneStraordinaria',
@A_3_ContributiReallizzazioneNuoveOpere			as 'A_3_ContributiReallizzazioneNuoveOpere',
@A_4_IncrementiImmobilizzazioniLavori			as 'A_4_IncrementiImmobilizzazioniLavori',
@A_5_AltriRicaviProventi						as 'A_5_AltriRicaviProventi',
@A_ValoreProduzione								as 'A_ValoreProduzione',
@B_6_AcquistiBeni								as 'B_6_AcquistiBeni',
@B_7A_ManutenzioneOrdinaria						as 'B_7A_ManutenzioneOrdinaria',
@B_7B_ManutenzioneStraordinaria					as 'B_7B_ManutenzioneStraordinaria',
@B_7C_RealizzazioneNuoveOpere					as 'B_7C_RealizzazioneNuoveOpere',
@B_7D_AltriServizi								as 'B_7D_AltriServizi',
@B_8_VariazioneRimanenze						as 'B_8_VariazioneRimanenze',
@B_9_GodimentoBeniTerzi							as 'B_9_GodimentoBeniTerzi',
@B_10_Personale									as 'B_10_Personale',
@B_11_AmmortamentiSvalutazioni					as 'B_11_AmmortamentiSvalutazioni',
@B_12_AccantonamentiRischiOneri					as 'B_12_AccantonamentiRischiOneri',
@B_13_OneriDiversiGestione						as 'B_13_OneriDiversiGestione',
@B_CostiProduzione								as 'B_CostiProduzione',
@DifferenzaValoriCostiProduzione				as 'DifferenzaValoriCostiProduzione',
@C_1_InteressiAttivi							as 'C_1_InteressiAttivi',
@C_2_AltriProventiFinanziari					as 'C_2_AltriProventiFinanziari',
@C_3_InteressiPassivi							as 'C_3_InteressiPassivi',
@C_4_AltriOneriFinanziari						as 'C_4_AltriOneriFinanziari',
@C_ProventiOneriFinanziari						as 'C_ProventiOneriFinanziari',
@D_1_Rivalutazioni								as 'D_1_Rivalutazioni',
@D_2_Svalutazioni								as 'D_2_Svalutazioni',
@D_RettificheValoreAttivita						as 'D_RettificheValoreAttivita',
@E_1_ProventiStraordinari						as 'E_1_ProventiStraordinari',
@E_2_OneriStraordinari							as 'E_2_OneriStraordinari',
@E_ProventiOneriStraordinari					as 'E_ProventiOneriStraordinari',
@RisultatoSenzaImposte							as 'RisultatoSenzaImposte',
@F_ImposteReddito								as 'F_ImposteReddito',
@RisultatoEconomicoPresunto						as 'RisultatoEconomicoPresunto'	

END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO