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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_budgeteconomicoufficiale_cee_biennale_puro]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_budgeteconomicoufficiale_cee_biennale_puro]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

-- setuser 'amministrazione' 
-- exec rpt_budgeteconomicoufficiale_cee_biennale_puro 2025, '%','S'
CREATE      PROCEDURE [rpt_budgeteconomicoufficiale_cee_biennale_puro](
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

DECLARE @ayear_prec INT
SET @ayear_prec = @ayear -1

CREATE TABLE #budgeteconomico
(
  ayear int  ,
  idupboriginal  varchar(38) ,
  codeupb  varchar(50),
  title varchar(200),
  treasurer varchar(200),
 A_Totale 	decimal(19,2),
 A1a_RicaviVenditePrestazioni  	decimal(19,2),
 A1b_RicaviVenditePrestazioni  	decimal(19,2),
 A2_VariazioniRimanenze  	decimal(19,2),
 A3_VariazioniLavori  	decimal(19,2),
 A4_IncrementiImmobilizzazioni   	decimal(19,2),
 A5a_AltriRicavi   	decimal(19,2),
 A5b_AltriRicavi   	decimal(19,2),
 B_Totale  	decimal(19,2),
 B10_Totale  	decimal(19,2),
 B10a_AmmortamentoImmateriali  	decimal(19,2),
 B10b_AmmortamentoImmobilizzazioniMateriali  	decimal(19,2),
 B10c_SvalutazioniImmobilizzazioni  	decimal(19,2),
 B10d_SvalutazioniCrediti  	decimal(19,2),
 B11_VariazioniRimanenze  	decimal(19,2),
 B12_AccantonamentiRischi  	decimal(19,2),
 B13_AltriAccantonamenti  	decimal(19,2),
 B14_OneriDiversiGestione  	decimal(19,2),
 B6_PerMateriePrime  	decimal(19,2),
 B7_PerServizi  	decimal(19,2),
 B8_PerGodimento  	decimal(19,2),
 B9_Totale  	decimal(19,2),
 B9a_SalariStipendi  	decimal(19,2),
 B9b_OneriSociali  	decimal(19,2),
 B9c_TrattamentoFineRapporto  	decimal(19,2),
 B9d_TrattamentoFineRapporto  	decimal(19,2),
 B9e_AltriCosti  	decimal(19,2),
 C_Totale  	decimal(19,2),
 C15a_ProventiPartecipazioni  	decimal(19,2),
 C15b_ProventiPartecipazioni  	decimal(19,2),
 C15c_ProventiPartecipazioni  	decimal(19,2),
 C15d_ProventiPartecipazioni  	decimal(19,2),
 C15e_ProventiPartecipazioni  	decimal(19,2),
 C15_totale decimal(19,1),
 C16_totale  	decimal(19,2),
 C16a_Crediti  	decimal(19,2),
 C16a1_Crediti  	decimal(19,2),
 C16a2_Crediti  	decimal(19,2),
 C16a3_Crediti  	decimal(19,2),
 C16a4_Crediti  	decimal(19,2),
 C16a5_Crediti  	decimal(19,2),
 C16b_TitoliIscrittiImmobilizzazion  	decimal(19,2),
 C16c_TitoliIscrittiAttivoCircolante  	decimal(19,2),
 C16d_ProventiDiversiPrecedenti  	decimal(19,2),
 C16d1_ProventiDiversiPrecedenti  	decimal(19,2),
 C16d2_ProventiDiversiPrecedenti  	decimal(19,2),
 C16d3_ProventiDiversiPrecedenti  	decimal(19,2),
 C16d4_ProventiDiversiPrecedenti  	decimal(19,2),
 C16d5_ProventiDiversiPrecedenti  	decimal(19,2),
 C17_Interessi  	decimal(19,2),
 C17a_Interessi  	decimal(19,2),
 C17b_Interessi  	decimal(19,2),
 C17c_Interessi  	decimal(19,2),
 C17d_Interessi  	decimal(19,2),
 C17e_Interessi  	decimal(19,2),

 C17bis_UtiliPerdite  	decimal(19,2),
 D_Totale  	decimal(19,2),
 D18_Totale  	decimal(19,2),
 D18a_Rivalutazioni_diPartecipazioni  	decimal(19,2),
 D18b_Rivalutazioni_diImmobilizzazioniFinanziarie  	decimal(19,2),
 D18c_Rivalutazioni_diTitoliIscritti   	decimal(19,2),
 D18d_Rivalutazioni_diStrumentiFinanziari  	decimal(19,2),
 D19_Totale  	decimal(19,2),
 D19a_Svalutazioni_diPartecipazioni  	decimal(19,2),
 D19b_Svalutazioni_diImmobilizzazioniFinanziarie  	decimal(19,2),
 D19c_Svalutazioni_diTitoliIscritti   	decimal(19,2),
 D19d_Svalutazioni_diStrumentiFinanziari  	decimal(19,2),
 D20_ImposteRedditoEesercizio  			 decimal(19,2),
 D20a_ImposteRedditoEesercizio  	decimal(19,2),
 D20b_ImposteRedditoEesercizio  	decimal(19,2),
 D20c_ImposteRedditoEesercizio  	decimal(19,2),

 DifferenzaValoreCostiProduzione  	decimal(19,2),
 Totale_RisultatoPrimaDelleImposte  	decimal(19,2),
 TotaledelleRettifiche 	decimal(19,2)

) 

INSERT INTO #budgeteconomico 
EXEC rpt_budgeteconomicoufficiale_cee_puro   @ayear , @idupb, @showchildupb , @idsor01, @idsor02, @idsor03, @idsor04, @idsor05


INSERT INTO #budgeteconomico
EXEC rpt_budgeteconomicoufficiale_cee_puro   @ayear_prec , @idupb, @showchildupb , @idsor01, @idsor02, @idsor03, @idsor04, @idsor05

SELECT
  B.ayear				  AS ayear         ,
  B.idupboriginal		  as idupb         ,
  B.codeupb				  as codeupb	   ,
  B.title				  as upb		   ,
  B.treasurer as department,
 ----------------------------------------------------------------------------------------------------------
 --------------------------------- esercizio corrente -----------------------------------------------------
 ----------------------------------------------------------------------------------------------------------
B.A_Totale 	as	 A_Totale 	,
B.A1a_RicaviVenditePrestazioni  	as	 A1a_RicaviVenditePrestazioni  	,
B.A1b_RicaviVenditePrestazioni  	as	 A1b_RicaviVenditePrestazioni  	,
B.A2_VariazioniRimanenze  	as	 A2_VariazioniRimanenze  	,
B.A3_VariazioniLavori  	as	 A3_VariazioniLavori  	,
B.A4_IncrementiImmobilizzazioni   	as	 A4_IncrementiImmobilizzazioni   	,
B.A5a_AltriRicavi   	as	 A5a_AltriRicavi   	,
B.A5b_AltriRicavi   	as	 A5b_AltriRicavi   	,
B.B_Totale  	as	 B_Totale  	,
B.B10_Totale  	as	 B10_Totale  	,
B.B10a_AmmortamentoImmateriali  	as	 B10a_AmmortamentoImmateriali  	,
B.B10b_AmmortamentoImmobilizzazioniMateriali  	as	 B10b_AmmortamentoImmobilizzazioniMateriali  	,
B.B10c_SvalutazioniImmobilizzazioni  	as	 B10c_SvalutazioniImmobilizzazioni  	,
B.B10d_SvalutazioniCrediti  	as	 B10d_SvalutazioniCrediti  	,
B.B11_VariazioniRimanenze  	as	 B11_VariazioniRimanenze  	,
B.B12_AccantonamentiRischi  	as	 B12_AccantonamentiRischi  	,
B.B13_AltriAccantonamenti  	as	 B13_AltriAccantonamenti  	,
B.B14_OneriDiversiGestione  	as	 B14_OneriDiversiGestione  	,
B.B6_PerMateriePrime  	as	 B6_PerMateriePrime  	,
B.B7_PerServizi  	as	 B7_PerServizi  	,
B.B8_PerGodimento  	as	 B8_PerGodimento  	,
B.B9_Totale  	as	 B9_Totale  	,
B.B9a_SalariStipendi  	as	 B9a_SalariStipendi  	,
B.B9b_OneriSociali  	as	 B9b_OneriSociali  	,
B.B9c_TrattamentoFineRapporto  	as	 B9c_TrattamentoFineRapporto  	,
B.B9d_TrattamentoFineRapporto  	as	 B9d_TrattamentoFineRapporto  	,
B.B9e_AltriCosti  	as	 B9e_AltriCosti  	,
B.C_Totale  	as	 C_Totale  	,
B.C15a_ProventiPartecipazioni  	as	 C15a_ProventiPartecipazioni  	,
B.C15b_ProventiPartecipazioni  	as	 C15b_ProventiPartecipazioni  	,
B.C15c_ProventiPartecipazioni  	as	 C15c_ProventiPartecipazioni  	,
B.C15d_ProventiPartecipazioni  	as	 C15d_ProventiPartecipazioni  	,
B.C15e_ProventiPartecipazioni  	as	 C15e_ProventiPartecipazioni  	,
B.C15_totale  	as	 C15_totale  	,
B.C16_totale  	as	 C16_totale  	,
B.C16a_Crediti  	as	 C16a_Crediti  	,

B.C16a1_Crediti as  C16a1_Crediti,
B.C16a2_Crediti as  C16a2_Crediti,
B.C16a3_Crediti as  C16a3_Crediti,
B.C16a4_Crediti as  C16a4_Crediti,
B.C16a5_Crediti as  C16a5_Crediti,

B.C16b_TitoliIscrittiImmobilizzazion  	as	 C16b_TitoliIscrittiImmobilizzazion  	,
B.C16c_TitoliIscrittiAttivoCircolante  	as	 C16c_TitoliIscrittiAttivoCircolante  	,
B.C16d_ProventiDiversiPrecedenti  	as	 C16d_ProventiDiversiPrecedenti  	,
B.C16d1_ProventiDiversiPrecedenti  	as	 C16d1_ProventiDiversiPrecedenti  	,
B.C16d2_ProventiDiversiPrecedenti  	as	 C16d2_ProventiDiversiPrecedenti  	,
B.C16d3_ProventiDiversiPrecedenti  	as	 C16d3_ProventiDiversiPrecedenti  	,
B.C16d4_ProventiDiversiPrecedenti  	as	 C16d4_ProventiDiversiPrecedenti  	,
B.C16d5_ProventiDiversiPrecedenti  	as	 C16d5_ProventiDiversiPrecedenti  	,
B.C17_Interessi	as C17_Interessi,
B.C17a_Interessi  	as	 C17a_Interessi  	,
B.C17b_Interessi  	as	 C17b_Interessi  	,
B.C17c_Interessi  	as	 C17c_Interessi  	,
B.C17d_Interessi  	as	 C17d_Interessi  	,
B.C17e_Interessi  	as	 C17e_Interessi  	,

B.C17bis_UtiliPerdite  	as	 C17bis_UtiliPerdite  	,
B.D_Totale  	as	 D_Totale  	,
B.D18_Totale  	as	 D18_Totale  	,
B.D18a_Rivalutazioni_diPartecipazioni  	as	 D18a_Rivalutazioni_diPartecipazioni  	,
B.D18b_Rivalutazioni_diImmobilizzazioniFinanziarie  	as	 D18b_Rivalutazioni_diImmobilizzazioniFinanziarie  	,
B.D18c_Rivalutazioni_diTitoliIscritti   	as	 D18c_Rivalutazioni_diTitoliIscritti   	,
B.D18d_Rivalutazioni_diStrumentiFinanziari  	as	 D18d_Rivalutazioni_diStrumentiFinanziari  	,
B.D19_Totale  	as	 D19_Totale  	,
B.D19a_Svalutazioni_diPartecipazioni  	as	 D19a_Svalutazioni_diPartecipazioni  	,
B.D19b_Svalutazioni_diImmobilizzazioniFinanziarie  	as	 D19b_Svalutazioni_diImmobilizzazioniFinanziarie  	,
B.D19c_Svalutazioni_diTitoliIscritti   	as	 D19c_Svalutazioni_diTitoliIscritti   	,
B.D19d_Svalutazioni_diStrumentiFinanziari  	as	 D19d_Svalutazioni_diStrumentiFinanziari  	,
B.D20_ImposteRedditoEesercizio  		as		 D20_ImposteRedditoEesercizio  	,
B.D20a_ImposteRedditoEesercizio  	as	 D20a_ImposteRedditoEesercizio  	,
B.D20b_ImposteRedditoEesercizio  	as	 D20b_ImposteRedditoEesercizio  	,
B.D20c_ImposteRedditoEesercizio  	as	 D20c_ImposteRedditoEesercizio  	,
B.DifferenzaValoreCostiProduzione  	as	 DifferenzaValoreCostiProduzione  	,
B.Totale_RisultatoPrimaDelleImposte  	as	 Totale_RisultatoPrimaDelleImposte  	,
B.TotaledelleRettifiche 	as	 TotaledelleRettifiche 	,

 ----------------------------------------------------------------------------------------------------------
 --------------------------------- esercizio precedente----------------------------------------------------
 ----------------------------------------------------------------------------------------------------------
B1.A_Totale 	as	 A_Totale_prec,
B1.A1a_RicaviVenditePrestazioni  	as	 A1a_RicaviVenditePrestazioni_prec,
B1.A1b_RicaviVenditePrestazioni  	as	 A1b_RicaviVenditePrestazioni_prec,
B1.A2_VariazioniRimanenze  	as	 A2_VariazioniRimanenze_prec,
B1.A3_VariazioniLavori  	as	 A3_VariazioniLavori_prec,
B1.A4_IncrementiImmobilizzazioni   	as	 A4_IncrementiImmobilizzazioni_prec,
B1.A5a_AltriRicavi   	as	 A5a_AltriRicavi_prec,
B1.A5b_AltriRicavi   	as	 A5b_AltriRicavi_prec,
B1.B_Totale  	as	 B_Totale_prec,
B1.B10_Totale  	as	 B10_Totale_prec,
B1.B10a_AmmortamentoImmateriali  	as	 B10a_AmmortamentoImmateriali_prec,
B1.B10b_AmmortamentoImmobilizzazioniMateriali  	as	 B10b_AmmortamentoImmobilizzazioniMateriali_prec,
B1.B10c_SvalutazioniImmobilizzazioni  	as	 B10c_SvalutazioniImmobilizzazioni_prec,
B1.B10d_SvalutazioniCrediti  	as	 B10d_SvalutazioniCrediti_prec,
B1.B11_VariazioniRimanenze  	as	 B11_VariazioniRimanenze_prec,
B1.B12_AccantonamentiRischi  	as	 B12_AccantonamentiRischi_prec,
B1.B13_AltriAccantonamenti  	as	 B13_AltriAccantonamenti_prec,
B1.B14_OneriDiversiGestione  	as	 B14_OneriDiversiGestione_prec,
B1.B6_PerMateriePrime  	as	 B6_PerMateriePrime_prec,
B1.B7_PerServizi  	as	 B7_PerServizi_prec,
B1.B8_PerGodimento  	as	 B8_PerGodimento_prec,
B1.B9_Totale  	as	 B9_Totale_prec,
B1.B9a_SalariStipendi  	as	 B9a_SalariStipendi_prec,
B1.B9b_OneriSociali  	as	 B9b_OneriSociali_prec,
B1.B9c_TrattamentoFineRapporto  	as	 B9c_TrattamentoFineRapporto_prec,
B1.B9d_TrattamentoFineRapporto  	as	 B9d_TrattamentoFineRapporto_prec,
B1.B9e_AltriCosti  	as	 B9e_AltriCosti_prec,
B1.C_Totale  	as	 C_Totale_prec,
B1.C15a_ProventiPartecipazioni  	as	 C15a_ProventiPartecipazioni_prec,
B1.C15b_ProventiPartecipazioni  	as	 C15b_ProventiPartecipazioni_prec,
B1.C15c_ProventiPartecipazioni  	as	 C15c_ProventiPartecipazioni_prec,
B1.C15d_ProventiPartecipazioni  	as	 C15d_ProventiPartecipazioni_prec,
B1.C15e_ProventiPartecipazioni  	as	 C15e_ProventiPartecipazioni_prec,
B1.C15_totale  	as	 C15_totale_prec,
B1.C16_totale  	as	 C16_totale_prec,
B1.C16a_Crediti  	as	 C16a_Crediti_prec,

B1.C16a1_Crediti as  C16a1_Crediti_prec,
B1.C16a2_Crediti as  C16a2_Crediti_prec,
B1.C16a3_Crediti as  C16a3_Crediti_prec,
B1.C16a4_Crediti as  C16a4_Crediti_prec,
B1.C16a5_Crediti as  C16a5_Crediti_prec,

B1.C16b_TitoliIscrittiImmobilizzazion  	as	 C16b_TitoliIscrittiImmobilizzazion_prec,
B1.C16c_TitoliIscrittiAttivoCircolante  	as	 C16c_TitoliIscrittiAttivoCircolante_prec,
B1.C16d_ProventiDiversiPrecedenti  	as	 C16d_ProventiDiversiPrecedenti_prec,
B1.C16d1_ProventiDiversiPrecedenti  	as	 C16d1_ProventiDiversiPrecedenti_prec,
B1.C16d2_ProventiDiversiPrecedenti  	as	 C16d2_ProventiDiversiPrecedenti_prec,
B1.C16d3_ProventiDiversiPrecedenti  	as	 C16d3_ProventiDiversiPrecedenti_prec,
B1.C16d4_ProventiDiversiPrecedenti  	as	 C16d4_ProventiDiversiPrecedenti_prec,
B1.C16d5_ProventiDiversiPrecedenti  	as	 C16d5_ProventiDiversiPrecedenti_prec,
B1.C17_Interessi	as C17_Interessi_prec,
B1.C17a_Interessi  	as	 C17a_Interessi_prec,
B1.C17b_Interessi  	as	 C17b_Interessi_prec,
B1.C17c_Interessi  	as	 C17c_Interessi_prec,
B1.C17d_Interessi  	as	 C17d_Interessi_prec,
B1.C17e_Interessi  	as	 C17e_Interessi_prec,

B1.C17bis_UtiliPerdite  	as	 C17bis_UtiliPerdite_prec,
B1.D_Totale  	as	 D_Totale_prec,
B1.D18_Totale  	as	 D18_Totale_prec,
B1.D18a_Rivalutazioni_diPartecipazioni  	as	 D18a_Rivalutazioni_diPartecipazioni_prec,
B1.D18b_Rivalutazioni_diImmobilizzazioniFinanziarie  	as	 D18b_Rivalutazioni_diImmobilizzazioniFinanziarie_prec,
B1.D18c_Rivalutazioni_diTitoliIscritti   	as	 D18c_Rivalutazioni_diTitoliIscritti_prec,
B1.D18d_Rivalutazioni_diStrumentiFinanziari  	as	 D18d_Rivalutazioni_diStrumentiFinanziari_prec,
B1.D19_Totale  	as	 D19_Totale_prec,
B1.D19a_Svalutazioni_diPartecipazioni  	as	 D19a_Svalutazioni_diPartecipazioni_prec,
B1.D19b_Svalutazioni_diImmobilizzazioniFinanziarie  	as	 D19b_Svalutazioni_diImmobilizzazioniFinanziarie_prec,
B1.D19c_Svalutazioni_diTitoliIscritti   	as	 D19c_Svalutazioni_diTitoliIscritti_prec,
B1.D19d_Svalutazioni_diStrumentiFinanziari  	as	 D19d_Svalutazioni_diStrumentiFinanziari_prec,
B1.D20_ImposteRedditoEesercizio  		as		 D20_ImposteRedditoEesercizio_prec  	,
B1.D20a_ImposteRedditoEesercizio  	as	 D20a_ImposteRedditoEesercizio_prec,
B1.D20b_ImposteRedditoEesercizio  	as	 D20b_ImposteRedditoEesercizio_prec,
B1.D20c_ImposteRedditoEesercizio  	as	 D20c_ImposteRedditoEesercizio_prec,
B1.DifferenzaValoreCostiProduzione  	as	 DifferenzaValoreCostiProduzione_prec,
B1.Totale_RisultatoPrimaDelleImposte  	as	 Totale_RisultatoPrimaDelleImposte_prec,
B1.TotaledelleRettifiche 	as	 TotaledelleRettifiche_prec

  FROM #budgeteconomico B 
  JOIN #budgeteconomico B1 ON 
	   B.ayear - 1 = B1.ayear	AND			   
	   B.idupboriginal	 =	  B1.idupboriginal		  
   WHERE B1.ayear = @ayear-1
	   and B.ayear = @ayear  
				
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


