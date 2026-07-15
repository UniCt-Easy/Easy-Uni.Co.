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

if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_budgeteconomicoufficiale_consorzio_triennale]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_budgeteconomicoufficiale_consorzio_triennale]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
-- setuser 'amministrazione'
-- exec rpt_budgeteconomicoufficiale_consorzio_triennale 2024, '%','S'
CREATE      PROCEDURE [rpt_budgeteconomicoufficiale_consorzio_triennale](
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
declare @A_1_ProventiRuoliContributivi_prev2 decimal(19,2)
declare @A_1_ProventiRuoliContributivi_prev3 decimal(19,2)
select @A_1_ProventiRuoliContributivi = ISNULL(SUM(accountyear.prevision*A.economicbudget_sign_value), 0),
@A_1_ProventiRuoliContributivi_prev2 = ISNULL(SUM(accountyear.prevision2*A.economicbudget_sign_value), 0),
@A_1_ProventiRuoliContributivi_prev3 = ISNULL(SUM(accountyear.prevision3*A.economicbudget_sign_value), 0)
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
		AND S.sortcode LIKE 'EA0101%'

declare @A_2_ContributiManutenzioneStraordinaria decimal(19,2)
declare @A_2_ContributiManutenzioneStraordinaria_prev2 decimal(19,2)
declare @A_2_ContributiManutenzioneStraordinaria_prev3 decimal(19,2)
select @A_2_ContributiManutenzioneStraordinaria = ISNULL(SUM(accountyear.prevision*A.economicbudget_sign_value), 0),
@A_2_ContributiManutenzioneStraordinaria_prev2 = ISNULL(SUM(accountyear.prevision2*A.economicbudget_sign_value), 0),
@A_2_ContributiManutenzioneStraordinaria_prev3 = ISNULL(SUM(accountyear.prevision3*A.economicbudget_sign_value), 0)
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
		AND S.sortcode LIKE 'EA0102%'

declare @A_3_ContributiReallizzazioneNuoveOpere decimal(19,2)
declare @A_3_ContributiReallizzazioneNuoveOpere_prev2 decimal(19,2)
declare @A_3_ContributiReallizzazioneNuoveOpere_prev3 decimal(19,2)
select @A_3_ContributiReallizzazioneNuoveOpere = ISNULL(SUM(accountyear.prevision*A.economicbudget_sign_value), 0),
@A_3_ContributiReallizzazioneNuoveOpere_prev2 = ISNULL(SUM(accountyear.prevision2*A.economicbudget_sign_value), 0),
@A_3_ContributiReallizzazioneNuoveOpere_prev3 = ISNULL(SUM(accountyear.prevision3*A.economicbudget_sign_value), 0)
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
		AND S.sortcode LIKE 'EA0103%'

declare @A_4_IncrementiImmobilizzazioniLavori decimal(19,2)
declare @A_4_IncrementiImmobilizzazioniLavori_prev2 decimal(19,2)
declare @A_4_IncrementiImmobilizzazioniLavori_prev3 decimal(19,2)
select @A_4_IncrementiImmobilizzazioniLavori = ISNULL(SUM(accountyear.prevision*A.economicbudget_sign_value), 0),
@A_4_IncrementiImmobilizzazioniLavori_prev2 = ISNULL(SUM(accountyear.prevision2*A.economicbudget_sign_value), 0),
@A_4_IncrementiImmobilizzazioniLavori_prev3 = ISNULL(SUM(accountyear.prevision3*A.economicbudget_sign_value), 0)
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
		AND S.sortcode LIKE 'EA0104%'

declare @A_5_AltriRicaviProventi decimal(19,2)
declare @A_5_AltriRicaviProventi_prev2 decimal(19,2)
declare @A_5_AltriRicaviProventi_prev3 decimal(19,2)
select @A_5_AltriRicaviProventi = ISNULL(SUM(accountyear.prevision*A.economicbudget_sign_value), 0),
@A_5_AltriRicaviProventi_prev2 = ISNULL(SUM(accountyear.prevision2*A.economicbudget_sign_value), 0),
@A_5_AltriRicaviProventi_prev3 = ISNULL(SUM(accountyear.prevision3*A.economicbudget_sign_value), 0)
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
		AND S.sortcode LIKE 'EA0105%'

declare @A_ValoreProduzione decimal(19,2)
set @A_ValoreProduzione = @A_1_ProventiRuoliContributivi + @A_2_ContributiManutenzioneStraordinaria + @A_3_ContributiReallizzazioneNuoveOpere +
							@A_4_IncrementiImmobilizzazioniLavori + @A_5_AltriRicaviProventi

declare @A_ValoreProduzione_prev2 decimal(19,2)
set @A_ValoreProduzione_prev2 = @A_1_ProventiRuoliContributivi_prev2 + @A_2_ContributiManutenzioneStraordinaria_prev2 + @A_3_ContributiReallizzazioneNuoveOpere_prev2 +
							@A_4_IncrementiImmobilizzazioniLavori_prev2 + @A_5_AltriRicaviProventi_prev2

declare @A_ValoreProduzione_prev3 decimal(19,2)
set @A_ValoreProduzione_prev3 = @A_1_ProventiRuoliContributivi_prev3 + @A_2_ContributiManutenzioneStraordinaria_prev3 + @A_3_ContributiReallizzazioneNuoveOpere_prev3 +
							@A_4_IncrementiImmobilizzazioniLavori_prev3 + @A_5_AltriRicaviProventi_prev3

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
declare @B_6_AcquistiBeni_prev2 decimal(19,2)
declare @B_6_AcquistiBeni_prev3 decimal(19,2)
select @B_6_AcquistiBeni = ISNULL(SUM(accountyear.prevision*A.economicbudget_sign_value), 0),
@B_6_AcquistiBeni_prev2 = ISNULL(SUM(accountyear.prevision2*A.economicbudget_sign_value), 0),
@B_6_AcquistiBeni_prev3 = ISNULL(SUM(accountyear.prevision3*A.economicbudget_sign_value), 0)
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
		AND S.sortcode LIKE 'EB0601%'

declare @B_7A_ManutenzioneOrdinaria decimal(19,2)
declare @B_7A_ManutenzioneOrdinaria_prev2 decimal(19,2)
declare @B_7A_ManutenzioneOrdinaria_prev3 decimal(19,2)
select @B_7A_ManutenzioneOrdinaria = ISNULL(SUM(accountyear.prevision*A.economicbudget_sign_value), 0),
@B_7A_ManutenzioneOrdinaria_prev2 = ISNULL(SUM(accountyear.prevision2*A.economicbudget_sign_value), 0),
@B_7A_ManutenzioneOrdinaria_prev3 = ISNULL(SUM(accountyear.prevision3*A.economicbudget_sign_value), 0)
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
		AND S.sortcode LIKE 'EB0701%'

declare @B_7B_ManutenzioneStraordinaria decimal(19,2)
declare @B_7B_ManutenzioneStraordinaria_prev2 decimal(19,2)
declare @B_7B_ManutenzioneStraordinaria_prev3 decimal(19,2)
select @B_7B_ManutenzioneStraordinaria = ISNULL(SUM(accountyear.prevision*A.economicbudget_sign_value), 0),
@B_7B_ManutenzioneStraordinaria_prev2 = ISNULL(SUM(accountyear.prevision2*A.economicbudget_sign_value), 0),
@B_7B_ManutenzioneStraordinaria_prev3 = ISNULL(SUM(accountyear.prevision3*A.economicbudget_sign_value), 0)
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
		AND S.sortcode LIKE 'EB0702%'

declare @B_7C_RealizzazioneNuoveOpere decimal(19,2)
declare @B_7C_RealizzazioneNuoveOpere_prev2 decimal(19,2)
declare @B_7C_RealizzazioneNuoveOpere_prev3 decimal(19,2)
select @B_7C_RealizzazioneNuoveOpere = ISNULL(SUM(accountyear.prevision*A.economicbudget_sign_value), 0),
@B_7C_RealizzazioneNuoveOpere_prev2 = ISNULL(SUM(accountyear.prevision2*A.economicbudget_sign_value), 0),
@B_7C_RealizzazioneNuoveOpere_prev3 = ISNULL(SUM(accountyear.prevision3*A.economicbudget_sign_value), 0)
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
		AND S.sortcode LIKE 'EB0703%'

declare @B_7D_AltriServizi decimal(19,2)
declare @B_7D_AltriServizi_prev2 decimal(19,2)
declare @B_7D_AltriServizi_prev3 decimal(19,2)
select @B_7D_AltriServizi = ISNULL(SUM(accountyear.prevision*A.economicbudget_sign_value), 0),
@B_7D_AltriServizi_prev2 = ISNULL(SUM(accountyear.prevision2*A.economicbudget_sign_value), 0),
@B_7D_AltriServizi_prev3 = ISNULL(SUM(accountyear.prevision3*A.economicbudget_sign_value), 0)
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
		AND S.sortcode LIKE 'EB0704%'

declare @B_8_VariazioneRimanenze decimal(19,2)
declare @B_8_VariazioneRimanenze_prev2 decimal(19,2)
declare @B_8_VariazioneRimanenze_prev3 decimal(19,2)
select @B_8_VariazioneRimanenze = ISNULL(SUM(accountyear.prevision*A.economicbudget_sign_value), 0),
@B_8_VariazioneRimanenze_prev2 = ISNULL(SUM(accountyear.prevision2*A.economicbudget_sign_value), 0),
@B_8_VariazioneRimanenze_prev3 = ISNULL(SUM(accountyear.prevision3*A.economicbudget_sign_value), 0)
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
		AND S.sortcode LIKE 'EB0801%'

declare @B_9_GodimentoBeniTerzi decimal(19,2)
declare @B_9_GodimentoBeniTerzi_prev2 decimal(19,2)
declare @B_9_GodimentoBeniTerzi_prev3 decimal(19,2)
select @B_9_GodimentoBeniTerzi = ISNULL(SUM(accountyear.prevision*A.economicbudget_sign_value), 0),
@B_9_GodimentoBeniTerzi_prev2 = ISNULL(SUM(accountyear.prevision2*A.economicbudget_sign_value), 0),
@B_9_GodimentoBeniTerzi_prev3 = ISNULL(SUM(accountyear.prevision3*A.economicbudget_sign_value), 0)
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
		AND S.sortcode LIKE 'EB0901%'

declare @B_10_Personale decimal(19,2)
declare @B_10_Personale_prev2 decimal(19,2)
declare @B_10_Personale_prev3 decimal(19,2)
select @B_10_Personale = ISNULL(SUM(accountyear.prevision*A.economicbudget_sign_value), 0),
@B_10_Personale_prev2 = ISNULL(SUM(accountyear.prevision2*A.economicbudget_sign_value), 0),
@B_10_Personale_prev3 = ISNULL(SUM(accountyear.prevision3*A.economicbudget_sign_value), 0)
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
		AND S.sortcode LIKE 'EB1001%'

declare @B_11_AmmortamentiSvalutazioni decimal(19,2)
declare @B_11_AmmortamentiSvalutazioni_prev2 decimal(19,2)
declare @B_11_AmmortamentiSvalutazioni_prev3 decimal(19,2)
select @B_11_AmmortamentiSvalutazioni = ISNULL(SUM(accountyear.prevision*A.economicbudget_sign_value), 0),
@B_11_AmmortamentiSvalutazioni_prev2 = ISNULL(SUM(accountyear.prevision2*A.economicbudget_sign_value), 0),
@B_11_AmmortamentiSvalutazioni_prev3 = ISNULL(SUM(accountyear.prevision3*A.economicbudget_sign_value), 0)
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
		AND S.sortcode LIKE 'EB1101%'

declare @B_12_AccantonamentiRischiOneri decimal(19,2)
declare @B_12_AccantonamentiRischiOneri_prev2 decimal(19,2)
declare @B_12_AccantonamentiRischiOneri_prev3 decimal(19,2)
select @B_12_AccantonamentiRischiOneri = ISNULL(SUM(accountyear.prevision*A.economicbudget_sign_value), 0),
@B_12_AccantonamentiRischiOneri_prev2 = ISNULL(SUM(accountyear.prevision2*A.economicbudget_sign_value), 0),
@B_12_AccantonamentiRischiOneri_prev3 = ISNULL(SUM(accountyear.prevision3*A.economicbudget_sign_value), 0)
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
		AND S.sortcode LIKE 'EB1201%'

declare @B_13_OneriDiversiGestione decimal(19,2)
declare @B_13_OneriDiversiGestione_prev2 decimal(19,2)
declare @B_13_OneriDiversiGestione_prev3 decimal(19,2)
select @B_13_OneriDiversiGestione = ISNULL(SUM(accountyear.prevision*A.economicbudget_sign_value), 0),
@B_13_OneriDiversiGestione_prev2 = ISNULL(SUM(accountyear.prevision2*A.economicbudget_sign_value), 0),
@B_13_OneriDiversiGestione_prev3 = ISNULL(SUM(accountyear.prevision3*A.economicbudget_sign_value), 0)
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
		AND S.sortcode LIKE 'EB1301%'

declare @B_CostiProduzione decimal(19,2)
set @B_CostiProduzione = @B_6_AcquistiBeni + @B_7A_ManutenzioneOrdinaria + @B_7B_ManutenzioneStraordinaria + @B_7C_RealizzazioneNuoveOpere + @B_7D_AltriServizi + @B_8_VariazioneRimanenze +
						@B_9_GodimentoBeniTerzi + @B_10_Personale + @B_11_AmmortamentiSvalutazioni + @B_12_AccantonamentiRischiOneri + @B_13_OneriDiversiGestione

declare @B_CostiProduzione_prev2 decimal(19,2)
set @B_CostiProduzione_prev2 = @B_6_AcquistiBeni_prev2 + @B_7A_ManutenzioneOrdinaria_prev2 + @B_7B_ManutenzioneStraordinaria_prev2 + @B_7C_RealizzazioneNuoveOpere_prev2 + @B_7D_AltriServizi_prev2 + @B_8_VariazioneRimanenze_prev2 +
						@B_9_GodimentoBeniTerzi_prev2 + @B_10_Personale_prev2 + @B_11_AmmortamentiSvalutazioni_prev2 + @B_12_AccantonamentiRischiOneri_prev2 + @B_13_OneriDiversiGestione_prev2

declare @B_CostiProduzione_prev3 decimal(19,2)
set @B_CostiProduzione_prev3 = @B_6_AcquistiBeni_prev3 + @B_7A_ManutenzioneOrdinaria_prev3 + @B_7B_ManutenzioneStraordinaria_prev3 + @B_7C_RealizzazioneNuoveOpere_prev3 + @B_7D_AltriServizi_prev3 + @B_8_VariazioneRimanenze_prev3 +
						@B_9_GodimentoBeniTerzi_prev3 + @B_10_Personale_prev3 + @B_11_AmmortamentiSvalutazioni_prev3 + @B_12_AccantonamentiRischiOneri_prev3 + @B_13_OneriDiversiGestione_prev3

declare @DifferenzaValoriCostiProduzione decimal(19,2)
set @DifferenzaValoriCostiProduzione = @A_ValoreProduzione - @B_CostiProduzione

declare @DifferenzaValoriCostiProduzione_prev2 decimal(19,2)
set @DifferenzaValoriCostiProduzione_prev2 = @A_ValoreProduzione_prev2 - @B_CostiProduzione_prev2

declare @DifferenzaValoriCostiProduzione_prev3 decimal(19,2)
set @DifferenzaValoriCostiProduzione_prev3 = @A_ValoreProduzione_prev3 - @B_CostiProduzione_prev3

/*
	C) PROVENTI E ONERI FINANZIARI
	C)1) Interessi attivi 
	C)2) Altri proventi finanziari
	C)3) Interessi passivi 
	C)4) Altri oneri finanziari
*/
declare @C_1_InteressiAttivi decimal(19,2)
declare @C_1_InteressiAttivi_prev2 decimal(19,2)
declare @C_1_InteressiAttivi_prev3 decimal(19,2)
select @C_1_InteressiAttivi = ISNULL(SUM(accountyear.prevision*A.economicbudget_sign_value), 0),
@C_1_InteressiAttivi_prev2 = ISNULL(SUM(accountyear.prevision2*A.economicbudget_sign_value), 0),
@C_1_InteressiAttivi_prev3 = ISNULL(SUM(accountyear.prevision3*A.economicbudget_sign_value), 0)
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
		AND S.sortcode LIKE 'EC0101%'

declare @C_2_AltriProventiFinanziari decimal(19,2)
declare @C_2_AltriProventiFinanziari_prev2 decimal(19,2)
declare @C_2_AltriProventiFinanziari_prev3 decimal(19,2)
select @C_2_AltriProventiFinanziari = ISNULL(SUM(accountyear.prevision*A.economicbudget_sign_value), 0),
@C_2_AltriProventiFinanziari_prev2 = ISNULL(SUM(accountyear.prevision2*A.economicbudget_sign_value), 0),
@C_2_AltriProventiFinanziari_prev3 = ISNULL(SUM(accountyear.prevision3*A.economicbudget_sign_value), 0)
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
		AND S.sortcode LIKE 'EC0102%'

declare @C_3_InteressiPassivi decimal(19,2)
declare @C_3_InteressiPassivi_prev2 decimal(19,2)
declare @C_3_InteressiPassivi_prev3 decimal(19,2)
select @C_3_InteressiPassivi = ISNULL(SUM(accountyear.prevision*A.economicbudget_sign_value), 0),
@C_3_InteressiPassivi_prev2 = ISNULL(SUM(accountyear.prevision2*A.economicbudget_sign_value), 0),
@C_3_InteressiPassivi_prev3 = ISNULL(SUM(accountyear.prevision3*A.economicbudget_sign_value), 0)
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
		AND S.sortcode LIKE 'EC0103%'

declare @C_4_AltriOneriFinanziari decimal(19,2)
declare @C_4_AltriOneriFinanziari_prev2 decimal(19,2)
declare @C_4_AltriOneriFinanziari_prev3 decimal(19,2)
select @C_4_AltriOneriFinanziari = ISNULL(SUM(accountyear.prevision*A.economicbudget_sign_value), 0),
@C_4_AltriOneriFinanziari_prev2 = ISNULL(SUM(accountyear.prevision2*A.economicbudget_sign_value), 0),
@C_4_AltriOneriFinanziari_prev3 = ISNULL(SUM(accountyear.prevision3*A.economicbudget_sign_value), 0)
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
		AND S.sortcode LIKE 'EC0104%'

declare @C_ProventiOneriFinanziari decimal(19,2)
set @C_ProventiOneriFinanziari = @C_1_InteressiAttivi + @C_2_AltriProventiFinanziari - @C_3_InteressiPassivi - @C_4_AltriOneriFinanziari

declare @C_ProventiOneriFinanziari_prev2 decimal(19,2)
set @C_ProventiOneriFinanziari_prev2 = @C_1_InteressiAttivi_prev2 + @C_2_AltriProventiFinanziari_prev2 - @C_3_InteressiPassivi_prev2 - @C_4_AltriOneriFinanziari_prev2

declare @C_ProventiOneriFinanziari_prev3 decimal(19,2)
set @C_ProventiOneriFinanziari_prev3 = @C_1_InteressiAttivi_prev3 + @C_2_AltriProventiFinanziari_prev3 - @C_3_InteressiPassivi_prev3 - @C_4_AltriOneriFinanziari_prev3

/*
	D) RETTIFICHE DI VALORE DI ATTIVITA' FINANZIARIE
	D)1) Rivalutazioni
	D)2) Svalutazioni
*/
declare @D_1_Rivalutazioni decimal(19,2)
declare @D_1_Rivalutazioni_prev2 decimal(19,2)
declare @D_1_Rivalutazioni_prev3 decimal(19,2)
select @D_1_Rivalutazioni = ISNULL(SUM(accountyear.prevision*A.economicbudget_sign_value), 0),
@D_1_Rivalutazioni_prev2 = ISNULL(SUM(accountyear.prevision2*A.economicbudget_sign_value), 0),
@D_1_Rivalutazioni_prev3 = ISNULL(SUM(accountyear.prevision3*A.economicbudget_sign_value), 0)
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
		AND S.sortcode LIKE 'ED0101%'

declare @D_2_Svalutazioni decimal(19,2)
declare @D_2_Svalutazioni_prev2 decimal(19,2)
declare @D_2_Svalutazioni_prev3 decimal(19,2)
select @D_2_Svalutazioni = ISNULL(SUM(accountyear.prevision*A.economicbudget_sign_value), 0),
@D_2_Svalutazioni_prev2 = ISNULL(SUM(accountyear.prevision2*A.economicbudget_sign_value), 0),
@D_2_Svalutazioni_prev3 = ISNULL(SUM(accountyear.prevision3*A.economicbudget_sign_value), 0)
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
		AND S.sortcode LIKE 'ED0102%'

declare @D_RettificheValoreAttivita decimal(19,2)
set @D_RettificheValoreAttivita = @D_1_Rivalutazioni - @D_2_Svalutazioni

declare @D_RettificheValoreAttivita_prev2 decimal(19,2)
set @D_RettificheValoreAttivita_prev2 = @D_1_Rivalutazioni_prev2 - @D_2_Svalutazioni_prev2

declare @D_RettificheValoreAttivita_prev3 decimal(19,2)
set @D_RettificheValoreAttivita_prev3 = @D_1_Rivalutazioni_prev3 - @D_2_Svalutazioni_prev3

/*
	E) PROVENTI E ONERI STRAORDINARI
	E)1) Proventi straordinari 
	E)2) Oneri straordinari
*/
declare @E_1_ProventiStraordinari decimal(19,2)
declare @E_1_ProventiStraordinari_prev2 decimal(19,2)
declare @E_1_ProventiStraordinari_prev3 decimal(19,2)
select @E_1_ProventiStraordinari = ISNULL(SUM(accountyear.prevision*A.economicbudget_sign_value), 0),
@E_1_ProventiStraordinari_prev2 = ISNULL(SUM(accountyear.prevision2*A.economicbudget_sign_value), 0),
@E_1_ProventiStraordinari_prev3 = ISNULL(SUM(accountyear.prevision3*A.economicbudget_sign_value), 0)
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
		AND S.sortcode LIKE 'EE0101%'

declare @E_2_OneriStraordinari decimal(19,2)
declare @E_2_OneriStraordinari_prev2 decimal(19,2)
declare @E_2_OneriStraordinari_prev3 decimal(19,2)
select @E_2_OneriStraordinari = ISNULL(SUM(accountyear.prevision*A.economicbudget_sign_value), 0),
@E_2_OneriStraordinari_prev2 = ISNULL(SUM(accountyear.prevision2*A.economicbudget_sign_value), 0),
@E_2_OneriStraordinari_prev3 = ISNULL(SUM(accountyear.prevision3*A.economicbudget_sign_value), 0)
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
		AND S.sortcode LIKE 'EE0102%'

declare @E_ProventiOneriStraordinari decimal(19,2)
set @E_ProventiOneriStraordinari = @E_1_ProventiStraordinari - @E_2_OneriStraordinari

declare @E_ProventiOneriStraordinari_prev2 decimal(19,2)
set @E_ProventiOneriStraordinari_prev2 = @E_1_ProventiStraordinari_prev2 - @E_2_OneriStraordinari_prev2

declare @E_ProventiOneriStraordinari_prev3 decimal(19,2)
set @E_ProventiOneriStraordinari_prev3 = @E_1_ProventiStraordinari_prev3 - @E_2_OneriStraordinari_prev3

declare @RisultatoSenzaImposte decimal(19,2)
set @RisultatoSenzaImposte = @A_ValoreProduzione - @B_CostiProduzione + @C_ProventiOneriFinanziari + @D_RettificheValoreAttivita + @E_ProventiOneriStraordinari

declare @RisultatoSenzaImposte_prev2 decimal(19,2)
set @RisultatoSenzaImposte_prev2 = @A_ValoreProduzione_prev2 - @B_CostiProduzione_prev2 + @C_ProventiOneriFinanziari_prev2 + @D_RettificheValoreAttivita_prev2 + @E_ProventiOneriStraordinari_prev2

declare @RisultatoSenzaImposte_prev3 decimal(19,2)
set @RisultatoSenzaImposte_prev3 = @A_ValoreProduzione_prev3 - @B_CostiProduzione_prev3 + @C_ProventiOneriFinanziari_prev3 + @D_RettificheValoreAttivita_prev3 + @E_ProventiOneriStraordinari_prev3

/*
	F) Imposte sul reddito dell'esercizio correnti, differite, anticipate
*/
declare @F_ImposteReddito decimal(19,2)
declare @F_ImposteReddito_prev2 decimal(19,2)
declare @F_ImposteReddito_prev3 decimal(19,2)
select @F_ImposteReddito = ISNULL(SUM(accountyear.prevision*A.economicbudget_sign_value), 0),
@F_ImposteReddito_prev2 = ISNULL(SUM(accountyear.prevision2*A.economicbudget_sign_value), 0),
@F_ImposteReddito_prev3 = ISNULL(SUM(accountyear.prevision3*A.economicbudget_sign_value), 0)
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
		AND S.sortcode LIKE 'EF0101%'

declare @RisultatoEconomicoPresunto decimal(19,2)
set @RisultatoEconomicoPresunto = @RisultatoSenzaImposte - @F_ImposteReddito

declare @RisultatoEconomicoPresunto_prev2 decimal(19,2)
set @RisultatoEconomicoPresunto_prev2 = @RisultatoSenzaImposte_prev2 - @F_ImposteReddito_prev2

declare @RisultatoEconomicoPresunto_prev3 decimal(19,2)
set @RisultatoEconomicoPresunto_prev3 = @RisultatoSenzaImposte_prev3 - @F_ImposteReddito_prev3

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
@RisultatoEconomicoPresunto						as 'RisultatoEconomicoPresunto',

@A_1_ProventiRuoliContributivi_prev2			as 'A_1_ProventiRuoliContributivi_prev2',
@A_2_ContributiManutenzioneStraordinaria_prev2	as 'A_2_ContributiManutenzioneStraordinaria_prev2',
@A_3_ContributiReallizzazioneNuoveOpere_prev2	as 'A_3_ContributiReallizzazioneNuoveOpere_prev2',
@A_4_IncrementiImmobilizzazioniLavori_prev2		as 'A_4_IncrementiImmobilizzazioniLavori_prev2',
@A_5_AltriRicaviProventi_prev2					as 'A_5_AltriRicaviProventi_prev2',
@A_ValoreProduzione_prev2						as 'A_ValoreProduzione_prev2',
@B_6_AcquistiBeni_prev2							as 'B_6_AcquistiBeni_prev2',
@B_7A_ManutenzioneOrdinaria_prev2				as 'B_7A_ManutenzioneOrdinaria_prev2',
@B_7B_ManutenzioneStraordinaria_prev2			as 'B_7B_ManutenzioneStraordinaria_prev2',
@B_7C_RealizzazioneNuoveOpere_prev2				as 'B_7C_RealizzazioneNuoveOpere_prev2',
@B_7D_AltriServizi_prev2						as 'B_7D_AltriServizi_prev2',
@B_8_VariazioneRimanenze_prev2					as 'B_8_VariazioneRimanenze_prev2',
@B_9_GodimentoBeniTerzi_prev2					as 'B_9_GodimentoBeniTerzi_prev2',
@B_10_Personale_prev2							as 'B_10_Personale_prev2',
@B_11_AmmortamentiSvalutazioni_prev2			as 'B_11_AmmortamentiSvalutazioni_prev2',
@B_12_AccantonamentiRischiOneri_prev2			as 'B_12_AccantonamentiRischiOneri_prev2',
@B_13_OneriDiversiGestione_prev2				as 'B_13_OneriDiversiGestione_prev2',
@B_CostiProduzione_prev2						as 'B_CostiProduzione_prev2',
@DifferenzaValoriCostiProduzione_prev2			as 'DifferenzaValoriCostiProduzione_prev2',
@C_1_InteressiAttivi_prev2						as 'C_1_InteressiAttivi_prev2',
@C_2_AltriProventiFinanziari_prev2				as 'C_2_AltriProventiFinanziari_prev2',
@C_3_InteressiPassivi_prev2						as 'C_3_InteressiPassivi_prev2',
@C_4_AltriOneriFinanziari_prev2					as 'C_4_AltriOneriFinanziari_prev2',
@C_ProventiOneriFinanziari_prev2				as 'C_ProventiOneriFinanziari_prev2',
@D_1_Rivalutazioni_prev2						as 'D_1_Rivalutazioni_prev2',
@D_2_Svalutazioni_prev2							as 'D_2_Svalutazioni_prev2',
@D_RettificheValoreAttivita_prev2				as 'D_RettificheValoreAttivita_prev2',
@E_1_ProventiStraordinari_prev2					as 'E_1_ProventiStraordinari_prev2',
@E_2_OneriStraordinari_prev2					as 'E_2_OneriStraordinari_prev2',
@E_ProventiOneriStraordinari_prev2				as 'E_ProventiOneriStraordinari_prev2',
@RisultatoSenzaImposte_prev2					as 'RisultatoSenzaImposte_prev2',
@F_ImposteReddito_prev2							as 'F_ImposteReddito_prev2',
@RisultatoEconomicoPresunto_prev2				as 'RisultatoEconomicoPresunto_prev2',

@A_1_ProventiRuoliContributivi_prev3			as 'A_1_ProventiRuoliContributivi_prev3',
@A_2_ContributiManutenzioneStraordinaria_prev3	as 'A_2_ContributiManutenzioneStraordinaria_prev3',
@A_3_ContributiReallizzazioneNuoveOpere_prev3	as 'A_3_ContributiReallizzazioneNuoveOpere_prev3',
@A_4_IncrementiImmobilizzazioniLavori_prev3		as 'A_4_IncrementiImmobilizzazioniLavori_prev3',
@A_5_AltriRicaviProventi_prev3					as 'A_5_AltriRicaviProventi_prev3',
@A_ValoreProduzione_prev3						as 'A_ValoreProduzione_prev3',
@B_6_AcquistiBeni_prev3							as 'B_6_AcquistiBeni_prev3',
@B_7A_ManutenzioneOrdinaria_prev3				as 'B_7A_ManutenzioneOrdinaria_prev3',
@B_7B_ManutenzioneStraordinaria_prev3			as 'B_7B_ManutenzioneStraordinaria_prev3',
@B_7C_RealizzazioneNuoveOpere_prev3				as 'B_7C_RealizzazioneNuoveOpere_prev3',
@B_7D_AltriServizi_prev3						as 'B_7D_AltriServizi_prev3',
@B_8_VariazioneRimanenze_prev3					as 'B_8_VariazioneRimanenze_prev3',
@B_9_GodimentoBeniTerzi_prev3					as 'B_9_GodimentoBeniTerzi_prev3',
@B_10_Personale_prev3							as 'B_10_Personale_prev3',
@B_11_AmmortamentiSvalutazioni_prev3			as 'B_11_AmmortamentiSvalutazioni_prev3',
@B_12_AccantonamentiRischiOneri_prev3			as 'B_12_AccantonamentiRischiOneri_prev3',
@B_13_OneriDiversiGestione_prev3				as 'B_13_OneriDiversiGestione_prev3',
@B_CostiProduzione_prev3						as 'B_CostiProduzione_prev3',
@DifferenzaValoriCostiProduzione_prev3			as 'DifferenzaValoriCostiProduzione_prev3',
@C_1_InteressiAttivi_prev3						as 'C_1_InteressiAttivi_prev3',
@C_2_AltriProventiFinanziari_prev3				as 'C_2_AltriProventiFinanziari_prev3',
@C_3_InteressiPassivi_prev3						as 'C_3_InteressiPassivi_prev3',
@C_4_AltriOneriFinanziari_prev3					as 'C_4_AltriOneriFinanziari_prev3',
@C_ProventiOneriFinanziari_prev3				as 'C_ProventiOneriFinanziari_prev3',
@D_1_Rivalutazioni_prev3						as 'D_1_Rivalutazioni_prev3',
@D_2_Svalutazioni_prev3							as 'D_2_Svalutazioni_prev3',
@D_RettificheValoreAttivita_prev3				as 'D_RettificheValoreAttivita_prev3',
@E_1_ProventiStraordinari_prev3					as 'E_1_ProventiStraordinari_prev3',
@E_2_OneriStraordinari_prev3					as 'E_2_OneriStraordinari_prev3',
@E_ProventiOneriStraordinari_prev3				as 'E_ProventiOneriStraordinari_prev3',
@RisultatoSenzaImposte_prev3					as 'RisultatoSenzaImposte_prev3',
@F_ImposteReddito_prev3							as 'F_ImposteReddito_prev3',
@RisultatoEconomicoPresunto_prev3				as 'RisultatoEconomicoPresunto_prev3'

END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO