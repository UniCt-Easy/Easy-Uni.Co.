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

if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_budgeteconomicoufficiale_consorzio]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_budgeteconomicoufficiale_consorzio]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
-- setuser 'amministrazione'
-- exec rpt_budgeteconomicoufficiale_consorzio 2024, '%','S'
CREATE      PROCEDURE [rpt_budgeteconomicoufficiale_consorzio](
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

create table #budgetcurr (
	ayear int,					
	idupb varchar(36),			
	codeupb varchar(50),		
	upb varchar(150),			
	department varchar(150), 			
	A_1_ProventiRuoliContributivi decimal(19,2),	
	A_2_ContributiManutenzioneStraordinaria decimal(19,2),
	A_3_ContributiReallizzazioneNuoveOpere decimal(19,2),
	A_4_IncrementiImmobilizzazioniLavori decimal(19,2),
	A_5_AltriRicaviProventi	decimal(19,2),
	A_ValoreProduzione decimal(19,2),
	B_6_AcquistiBeni decimal(19,2),	
	B_7A_ManutenzioneOrdinaria decimal(19,2),		
	B_7B_ManutenzioneStraordinaria decimal(19,2),
	B_7C_RealizzazioneNuoveOpere decimal(19,2),
	B_7D_AltriServizi decimal(19,2),
	B_8_VariazioneRimanenze decimal(19,2),	
	B_9_GodimentoBeniTerzi decimal(19,2),	
	B_10_Personale decimal(19,2),	
	B_11_AmmortamentiSvalutazioni decimal(19,2),			
	B_12_AccantonamentiRischiOneri decimal(19,2),
	B_13_OneriDiversiGestione decimal(19,2),
	B_CostiProduzione decimal(19,2),
	DifferenzaValoriCostiProduzione	decimal(19,2),	
	C_1_InteressiAttivi decimal(19,2),
	C_2_AltriProventiFinanziari decimal(19,2),
	C_3_InteressiPassivi decimal(19,2),
	C_4_AltriOneriFinanziari decimal(19,2),	
	C_ProventiOneriFinanziari decimal(19,2),
	D_1_Rivalutazioni decimal(19,2),
	D_2_Svalutazioni decimal(19,2),		
	D_RettificheValoreAttivita decimal(19,2),		
	E_1_ProventiStraordinari decimal(19,2),
	E_2_OneriStraordinari decimal(19,2),
	E_ProventiOneriStraordinari decimal(19,2),
	RisultatoSenzaImposte decimal(19,2),
	F_ImposteReddito decimal(19,2),
	RisultatoEconomicoPresunto decimal(19,2)
)

insert into #budgetcurr (
	ayear,					
	idupb,			
	codeupb,		
	upb,			
	department, 			
	A_1_ProventiRuoliContributivi,	
	A_2_ContributiManutenzioneStraordinaria,
	A_3_ContributiReallizzazioneNuoveOpere,
	A_4_IncrementiImmobilizzazioniLavori,
	A_5_AltriRicaviProventi,
	A_ValoreProduzione,	
	B_6_AcquistiBeni,	
	B_7A_ManutenzioneOrdinaria,		
	B_7B_ManutenzioneStraordinaria,
	B_7C_RealizzazioneNuoveOpere,
	B_7D_AltriServizi,
	B_8_VariazioneRimanenze,	
	B_9_GodimentoBeniTerzi,	
	B_10_Personale,	
	B_11_AmmortamentiSvalutazioni,			
	B_12_AccantonamentiRischiOneri,
	B_13_OneriDiversiGestione,
	B_CostiProduzione,
	DifferenzaValoriCostiProduzione,	
	C_1_InteressiAttivi,
	C_2_AltriProventiFinanziari,
	C_3_InteressiPassivi,
	C_4_AltriOneriFinanziari,	
	C_ProventiOneriFinanziari,
	D_1_Rivalutazioni,
	D_2_Svalutazioni,		
	D_RettificheValoreAttivita,		
	E_1_ProventiStraordinari,
	E_2_OneriStraordinari,
	E_ProventiOneriStraordinari,
	RisultatoSenzaImposte,
	F_ImposteReddito,
	RisultatoEconomicoPresunto
)
exec rpt_budgeteconomicoufficiale_puro_consorzio @ayear, @idupb, @showchildupb,	@idsor01, @idsor02, @idsor03, @idsor04, @idsor05

declare @ayearprev int
set @ayearprev = @ayear - 1

create table #budgetprev (
	ayear int,					
	idupb varchar(36),			
	codeupb varchar(50),		
	upb varchar(150),			
	department varchar(150), 			
	A_1_ProventiRuoliContributivi decimal(19,2),	
	A_2_ContributiManutenzioneStraordinaria decimal(19,2),
	A_3_ContributiReallizzazioneNuoveOpere decimal(19,2),
	A_4_IncrementiImmobilizzazioniLavori decimal(19,2),
	A_5_AltriRicaviProventi	decimal(19,2),
	A_ValoreProduzione decimal(19,2),
	B_6_AcquistiBeni decimal(19,2),	
	B_7A_ManutenzioneOrdinaria decimal(19,2),		
	B_7B_ManutenzioneStraordinaria decimal(19,2),
	B_7C_RealizzazioneNuoveOpere decimal(19,2),
	B_7D_AltriServizi decimal(19,2),
	B_8_VariazioneRimanenze decimal(19,2),	
	B_9_GodimentoBeniTerzi decimal(19,2),	
	B_10_Personale decimal(19,2),	
	B_11_AmmortamentiSvalutazioni decimal(19,2),			
	B_12_AccantonamentiRischiOneri decimal(19,2),
	B_13_OneriDiversiGestione decimal(19,2),
	B_CostiProduzione decimal(19,2),
	DifferenzaValoriCostiProduzione	decimal(19,2),	
	C_1_InteressiAttivi decimal(19,2),
	C_2_AltriProventiFinanziari decimal(19,2),
	C_3_InteressiPassivi decimal(19,2),
	C_4_AltriOneriFinanziari decimal(19,2),	
	C_ProventiOneriFinanziari decimal(19,2),
	D_1_Rivalutazioni decimal(19,2),
	D_2_Svalutazioni decimal(19,2),		
	D_RettificheValoreAttivita decimal(19,2),		
	E_1_ProventiStraordinari decimal(19,2),
	E_2_OneriStraordinari decimal(19,2),
	E_ProventiOneriStraordinari decimal(19,2),
	RisultatoSenzaImposte decimal(19,2),
	F_ImposteReddito decimal(19,2),
	RisultatoEconomicoPresunto decimal(19,2)
)

insert into #budgetprev (
	ayear,					
	idupb,			
	codeupb,		
	upb,			
	department, 			
	A_1_ProventiRuoliContributivi,	
	A_2_ContributiManutenzioneStraordinaria,
	A_3_ContributiReallizzazioneNuoveOpere,
	A_4_IncrementiImmobilizzazioniLavori,
	A_5_AltriRicaviProventi,
	A_ValoreProduzione,	
	B_6_AcquistiBeni,	
	B_7A_ManutenzioneOrdinaria,		
	B_7B_ManutenzioneStraordinaria,
	B_7C_RealizzazioneNuoveOpere,
	B_7D_AltriServizi,
	B_8_VariazioneRimanenze,	
	B_9_GodimentoBeniTerzi,	
	B_10_Personale,	
	B_11_AmmortamentiSvalutazioni,			
	B_12_AccantonamentiRischiOneri,
	B_13_OneriDiversiGestione,
	B_CostiProduzione,
	DifferenzaValoriCostiProduzione,	
	C_1_InteressiAttivi,
	C_2_AltriProventiFinanziari,
	C_3_InteressiPassivi,
	C_4_AltriOneriFinanziari,	
	C_ProventiOneriFinanziari,
	D_1_Rivalutazioni,
	D_2_Svalutazioni,		
	D_RettificheValoreAttivita,		
	E_1_ProventiStraordinari,
	E_2_OneriStraordinari,
	E_ProventiOneriStraordinari,
	RisultatoSenzaImposte,
	F_ImposteReddito,
	RisultatoEconomicoPresunto
)
exec rpt_budgeteconomicoufficiale_puro_consorzio @ayearprev, @idupb, @showchildupb,	@idsor01, @idsor02, @idsor03, @idsor04, @idsor05

select 
	c.ayear													as 'ayear',
	c.idupb													as 'idupb',
	c.codeupb												as 'codeupb',
	c.upb													as 'upb',
	c.department											as 'department',
	c.A_1_ProventiRuoliContributivi							as 'A_1_ProventiRuoliContributivi',
	c.A_2_ContributiManutenzioneStraordinaria				as 'A_2_ContributiManutenzioneStraordinaria',
	c.A_3_ContributiReallizzazioneNuoveOpere				as 'A_3_ContributiReallizzazioneNuoveOpere',
	c.A_4_IncrementiImmobilizzazioniLavori					as 'A_4_IncrementiImmobilizzazioniLavori',
	c.A_5_AltriRicaviProventi								as 'A_5_AltriRicaviProventi',
	c.A_ValoreProduzione									as 'A_ValoreProduzione',
	c.B_6_AcquistiBeni										as 'B_6_AcquistiBeni',
	c.B_7A_ManutenzioneOrdinaria							as 'B_7A_ManutenzioneOrdinaria',
	c.B_7B_ManutenzioneStraordinaria						as 'B_7B_ManutenzioneStraordinaria',
	c.B_7C_RealizzazioneNuoveOpere							as 'B_7C_RealizzazioneNuoveOpere',
	c.B_7D_AltriServizi										as 'B_7D_AltriServizi',
	c.B_8_VariazioneRimanenze								as 'B_8_VariazioneRimanenze',
	c.B_9_GodimentoBeniTerzi								as 'B_9_GodimentoBeniTerzi',
	c.B_10_Personale										as 'B_10_Personale',
	c.B_11_AmmortamentiSvalutazioni							as 'B_11_AmmortamentiSvalutazioni',
	c.B_12_AccantonamentiRischiOneri						as 'B_12_AccantonamentiRischiOneri',
	c.B_13_OneriDiversiGestione								as 'B_13_OneriDiversiGestione',
	c.B_CostiProduzione										as 'B_CostiProduzione',
	c.DifferenzaValoriCostiProduzione						as 'DifferenzaValoriCostiProduzione',
	c.C_1_InteressiAttivi									as 'C_1_InteressiAttivi',
	c.C_2_AltriProventiFinanziari							as 'C_2_AltriProventiFinanziari',
	c.C_3_InteressiPassivi									as 'C_3_InteressiPassivi',
	c.C_4_AltriOneriFinanziari								as 'C_4_AltriOneriFinanziari',
	c.C_ProventiOneriFinanziari								as 'C_ProventiOneriFinanziari',
	c.D_1_Rivalutazioni										as 'D_1_Rivalutazioni',
	c.D_2_Svalutazioni										as 'D_2_Svalutazioni',
	c.D_RettificheValoreAttivita							as 'D_RettificheValoreAttivita',
	c.E_1_ProventiStraordinari								as 'E_1_ProventiStraordinari',
	c.E_2_OneriStraordinari									as 'E_2_OneriStraordinari',
	c.E_ProventiOneriStraordinari							as 'E_ProventiOneriStraordinari',
	c.RisultatoSenzaImposte									as 'RisultatoSenzaImposte',
	c.F_ImposteReddito										as 'F_ImposteReddito',
	c.RisultatoEconomicoPresunto							as 'RisultatoEconomicoPresunto',
	p.ayear													as 'ayear_prev',
	p.idupb													as 'idupb_prev',
	p.codeupb												as 'codeupb_prev',
	p.upb													as 'upb_prev',
	p.department											as 'department_prev',
	p.A_1_ProventiRuoliContributivi							as 'A_1_ProventiRuoliContributivi_prev',
	p.A_2_ContributiManutenzioneStraordinaria				as 'A_2_ContributiManutenzioneStraordinaria_prev',
	p.A_3_ContributiReallizzazioneNuoveOpere				as 'A_3_ContributiReallizzazioneNuoveOpere_prev',
	p.A_4_IncrementiImmobilizzazioniLavori					as 'A_4_IncrementiImmobilizzazioniLavori_prev',
	p.A_5_AltriRicaviProventi								as 'A_5_AltriRicaviProventi_prev',
	p.A_ValoreProduzione									as 'A_ValoreProduzione_prev',
	p.B_6_AcquistiBeni										as 'B_6_AcquistiBeni_prev',
	p.B_7A_ManutenzioneOrdinaria							as 'B_7A_ManutenzioneOrdinaria_prev',
	p.B_7B_ManutenzioneStraordinaria						as 'B_7B_ManutenzioneStraordinaria_prev',
	p.B_7C_RealizzazioneNuoveOpere							as 'B_7C_RealizzazioneNuoveOpere_prev',
	p.B_7D_AltriServizi										as 'B_7D_AltriServizi_prev',
	p.B_8_VariazioneRimanenze								as 'B_8_VariazioneRimanenze_prev',
	p.B_9_GodimentoBeniTerzi								as 'B_9_GodimentoBeniTerzi_prev',
	p.B_10_Personale										as 'B_10_Personale_prev',
	p.B_11_AmmortamentiSvalutazioni							as 'B_11_AmmortamentiSvalutazioni_prev',
	p.B_12_AccantonamentiRischiOneri						as 'B_12_AccantonamentiRischiOneri_prev',
	p.B_13_OneriDiversiGestione								as 'B_13_OneriDiversiGestione_prev',
	p.B_CostiProduzione										as 'B_CostiProduzione_prev',
	p.DifferenzaValoriCostiProduzione						as 'DifferenzaValoriCostiProduzione_prev',
	p.C_1_InteressiAttivi									as 'C_1_InteressiAttivi_prev',
	p.C_2_AltriProventiFinanziari							as 'C_2_AltriProventiFinanziari_prev',
	p.C_3_InteressiPassivi									as 'C_3_InteressiPassivi_prev',
	p.C_4_AltriOneriFinanziari								as 'C_4_AltriOneriFinanziari_prev',
	p.C_ProventiOneriFinanziari								as 'C_ProventiOneriFinanziari_prev',
	p.D_1_Rivalutazioni										as 'D_1_Rivalutazioni_prev',
	p.D_2_Svalutazioni										as 'D_2_Svalutazioni_prev',
	p.D_RettificheValoreAttivita							as 'D_RettificheValoreAttivita_prev',
	p.E_1_ProventiStraordinari								as 'E_1_ProventiStraordinari_prev',
	p.E_2_OneriStraordinari									as 'E_2_OneriStraordinari_prev',
	p.E_ProventiOneriStraordinari							as 'E_ProventiOneriStraordinari_prev',
	p.RisultatoSenzaImposte									as 'RisultatoSenzaImposte_prev',
	p.F_ImposteReddito										as 'F_ImposteReddito_prev',
	p.RisultatoEconomicoPresunto							as 'RisultatoEconomicoPresunto_prev',
	isnull(c.A_1_ProventiRuoliContributivi,0) - 
		isnull(p.A_1_ProventiRuoliContributivi,0)			as 'A_1_ProventiRuoliContributivi_diff',
	isnull(c.A_2_ContributiManutenzioneStraordinaria, 0) -
		isnull(p.A_2_ContributiManutenzioneStraordinaria, 0) as 'A_2_ContributiManutenzioneStraordinaria_diff',
	isnull(c.A_3_ContributiReallizzazioneNuoveOpere, 0) -
		isnull(p.A_3_ContributiReallizzazioneNuoveOpere, 0)	as 'A_3_ContributiReallizzazioneNuoveOpere_diff',
	isnull(c.A_4_IncrementiImmobilizzazioniLavori, 0) -
		isnull(p.A_4_IncrementiImmobilizzazioniLavori,0)	as 'A_4_IncrementiImmobilizzazioniLavori_diff',
	isnull(c.A_5_AltriRicaviProventi, 0) -
		isnull(p.A_5_AltriRicaviProventi, 0)				as 'A_5_AltriRicaviProventi_diff',
	isnull(c.A_ValoreProduzione, 0) -
		isnull(p.A_ValoreProduzione, 0)						as 'A_ValoreProduzione_diff',
	isnull(c.B_6_AcquistiBeni, 0) -
		isnull(p.B_6_AcquistiBeni,0)						as 'B_6_AcquistiBeni_diff',
	isnull(c.B_7A_ManutenzioneOrdinaria, 0) -
		isnull(p.B_7A_ManutenzioneOrdinaria,0)				as 'B_7A_ManutenzioneOrdinaria_diff',
	isnull(c.B_7B_ManutenzioneStraordinaria, 0) -
		isnull(p.B_7B_ManutenzioneStraordinaria, 0)			as 'B_7B_ManutenzioneStraordinaria_diff',
	isnull(c.B_7C_RealizzazioneNuoveOpere, 0) -
		isnull(p.B_7C_RealizzazioneNuoveOpere,0)			as 'B_7C_RealizzazioneNuoveOpere_diff',
	isnull(c.B_7D_AltriServizi, 0) -
		isnull(p.B_7D_AltriServizi, 0)						as 'B_7D_AltriServizi_diff',
	isnull(c.B_8_VariazioneRimanenze, 0) -
		isnull(p.B_8_VariazioneRimanenze, 0)				as 'B_8_VariazioneRimanenze_diff',
	isnull(c.B_9_GodimentoBeniTerzi, 0) -
		isnull(p.B_9_GodimentoBeniTerzi,0)					as 'B_9_GodimentoBeniTerzi_diff',
	isnull(c.B_10_Personale, 0) -
		isnull(p.B_10_Personale, 0)							as 'B_10_Personale_diff',
	isnull(c.B_11_AmmortamentiSvalutazioni, 0) -
		isnull(p.B_11_AmmortamentiSvalutazioni, 0)			as 'B_11_AmmortamentiSvalutazioni_diff',
	isnull(c.B_12_AccantonamentiRischiOneri, 0) -
		isnull(p.B_12_AccantonamentiRischiOneri, 0)			as 'B_12_AccantonamentiRischiOneri_diff',
	isnull(c.B_13_OneriDiversiGestione, 0) -
		isnull(p.B_13_OneriDiversiGestione, 0)				as 'B_13_OneriDiversiGestione_diff',
	isnull(c.B_CostiProduzione, 0) -
		isnull(p.B_CostiProduzione, 0)						as 'B_CostiProduzione_diff',
	isnull(c.DifferenzaValoriCostiProduzione, 0) -
		isnull(p.DifferenzaValoriCostiProduzione, 0)		as 'DifferenzaValoriCostiProduzione_diff',
	isnull(c.C_1_InteressiAttivi, 0) -
		isnull(p.C_1_InteressiAttivi, 0)					as 'C_1_InteressiAttivi_diff',
	isnull(c.C_2_AltriProventiFinanziari, 0) -
		isnull(p.C_2_AltriProventiFinanziari, 0)			as 'C_2_AltriProventiFinanziari_diff',
	isnull(c.C_3_InteressiPassivi, 0) -
		isnull(p.C_3_InteressiPassivi, 0)					as 'C_3_InteressiPassivi_diff',
	isnull(c.C_4_AltriOneriFinanziari, 0) -
		isnull(p.C_4_AltriOneriFinanziari, 0)				as 'C_4_AltriOneriFinanziari_diff',
	isnull(c.C_ProventiOneriFinanziari, 0) -
		isnull(p.C_ProventiOneriFinanziari, 0)				as 'C_ProventiOneriFinanziari_diff',
	isnull(c.D_1_Rivalutazioni, 0) -
		isnull(p.D_1_Rivalutazioni, 0)						as 'D_1_Rivalutazioni_diff',
	isnull(c.D_2_Svalutazioni, 0) -
		isnull(p.D_2_Svalutazioni, 0)						as 'D_2_Svalutazioni_diff',
	isnull(c.D_RettificheValoreAttivita, 0) -
		isnull(p.D_RettificheValoreAttivita, 0)				as 'D_RettificheValoreAttivita_diff',
	isnull(c.E_1_ProventiStraordinari, 0) -
		isnull(p.E_1_ProventiStraordinari, 0)				as 'E_1_ProventiStraordinari_diff',
	isnull(c.E_2_OneriStraordinari, 0) -
		isnull(p.E_2_OneriStraordinari, 0)					as 'E_2_OneriStraordinari_diff',
	isnull(c.E_ProventiOneriStraordinari, 0) -
		isnull(p.E_ProventiOneriStraordinari, 0)			as 'E_ProventiOneriStraordinari_diff',
	isnull(c.RisultatoSenzaImposte, 0) -
		isnull(p.RisultatoSenzaImposte, 0)					as 'RisultatoSenzaImposte_diff',
	isnull(c.F_ImposteReddito, 0) -
		isnull(p.F_ImposteReddito, 0)						as 'F_ImposteReddito_diff',
	isnull(c.RisultatoEconomicoPresunto, 0) -
		isnull(p.RisultatoEconomicoPresunto, 0)				as 'RisultatoEconomicoPresunto_diff'
from #budgetcurr c
full join #budgetprev p on c.idupb = p.idupb

drop table #budgetcurr
drop table #budgetprev

END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO