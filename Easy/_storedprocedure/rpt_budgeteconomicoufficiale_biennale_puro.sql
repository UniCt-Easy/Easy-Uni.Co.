
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_budgeteconomicoufficiale_biennale_puro]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_budgeteconomicoufficiale_biennale_puro]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--- setuser 'amm'
--- setuser 'amministrazione'
-- exec rpt_budgeteconomicoufficiale_biennale_puro 2021, '%','S'
CREATE      PROCEDURE [rpt_budgeteconomicoufficiale_biennale_puro](
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
  A_I1_ProventiPerLaDidattica  decimal(19,2),  
  A_I2_ProventiDaRicercheCommissionate   decimal(19,2)  ,
  A_I3_ProventiDaRicercheConFinanziamento  decimal(19,2) ,  
  A_I_ProventiPropri  decimal(19,2) ,  
  A_II1_ContributiMIUR  decimal(19,2) ,  
  A_II2_ContributiRegioni  decimal(19,2) ,  
  A_II3_ContributiAltreAmministrazioni  decimal(19,2),  
  A_II4_ContributiUE  decimal(19,2),  
  A_II5_ContributiUniversita  decimal(19,2),  
  A_II6_ContributiAltriPubblici  decimal(19,2),  
  A_II7_ContributiAltriPrivati   decimal(19,2) ,
  A_II_Contributi  decimal(19,2),  
  A_III_ProventiPerAttivitaAssistenziale  decimal(19,2),  
  A_IV_ProventiPerGestioneDiretta  decimal(19,2),  
  A_V1_UtilizzoRiservePatrimonioNetto  decimal(19,2),
  A_V2_AltriProventi  decimal(19,2),
  A_V_UtilizzoRiservePatrimonioNetto  decimal(19,2),  
  A_VI_VariazioniRimanenze  decimal(19,2),  
  A_VII_IncrementoImmobilizzazioni  decimal(19,2),  
  B_VIII1a_CostiDocentiRicercatori  decimal(19,2),  
  B_VIII1b_CollaborazioniScientifiche  decimal(19,2),  
  B_VIII1c_DocentiAContratto  decimal(19,2),   
  B_VIII1d_EspertiLinguistici  decimal(19,2),  
  B_VIII1e_AltroPersonale  decimal(19,2),  
  B_VIII2_CostiPersonaleDirigente  decimal(19,2),  
  B_VIII_CostiPersonale  decimal(19,2),  
  B_IX1_CostiSostegnoStudenti  decimal(19,2),  
  B_IX2_CostiDirittoStudio  decimal(19,2),  
  B_IX3_CostiRicercaAttivitaEditoriale  decimal(19,2),  
  B_IX4_TrasferimentiPartner  decimal(19,2),  
  B_IX5_AcquistoMaterialeConsumo  decimal(19,2),   
  B_IX6_VariazioneRimanenze  decimal(19,2),  
  B_IX7_AcquistoLibri  decimal(19,2),  
  B_IX8_AcquistoServizi  decimal(19,2),  
  B_IX9_AcquistoAltriMateriali  decimal(19,2),  
  B_IX10_VariazioneRimanenze  decimal(19,2),  
  B_IX11_CostiGodimento  decimal(19,2),  
  B_IX12_AltriCosti  decimal(19,2),   
  IX_CostiGestione  decimal(19,2),  
  B_X1_AmmortamentiImmobImmateriali  decimal(19,2),  
  B_X2_AmmortamentiImmobMateriali  decimal(19,2),  
  B_X3_SvalutazioniImmobilizzazioni  decimal(19,2),
  B_X4_SvalutazioniCrediti decimal(19,2),  
  X_AmmortamentiSvalutazioni decimal(19,2),  
  B_XI_AccantonamentiRischiOneri  decimal(19,2),  
  B_XII_OneriDversiGestione  decimal(19,2),  
  C_1ProventiFinanziari  decimal(19,2),  
  C_2Interessi  decimal(19,2),  
  C_3Utili  decimal(19,2),  
  C_3Perdite  decimal(19,2),  
  C_ProventiOneri  decimal(19,2),  
  D_1Rivalutazioni  decimal(19,2),  
  D_2Svalutazioni  decimal(19,2),  
  D_Rettifiche  decimal(19,2),  
  E_1ProventiStraordinari  decimal(19,2),   
  E_2OneriStraordinari  decimal(19,2),   
  E_ProventiOneriStraordinari decimal(19,2),  
  F_Imposte  decimal(19,2),   
  G_UtilizzoDiRiserve  decimal(19,2),   
  TOTRICAVI  decimal(19,2),  
  TOTCOSTI  decimal(19,2),  
  RisultatoEconomicoPresunto  decimal(19,2),  
  RisultatoAPareggio   decimal(19,2)
) 

INSERT INTO #budgeteconomico 
EXEC rpt_budgeteconomicoufficiale_puro   @ayear , @idupb, @showchildupb , @idsor01, @idsor02, @idsor03, @idsor04, @idsor05


INSERT INTO #budgeteconomico
EXEC rpt_budgeteconomicoufficiale_puro   @ayear_prec , @idupb, @showchildupb , @idsor01, @idsor02, @idsor03, @idsor04, @idsor05

SELECT
  B.ayear				  AS ayear         ,
  B.idupboriginal		  as idupb         ,
  B.codeupb				  as codeupb	   ,
  B.title				  as upb		   ,
  B.treasurer as department,
 ----------------------------------------------------------------------------------------------------------
 --------------------------------- esercizio corrente -----------------------------------------------------
 ----------------------------------------------------------------------------------------------------------
  B.A_I1_ProventiPerLaDidattica  	as	  'A_I1_ProventiPerLaDidattica',  
  B.A_I2_ProventiDaRicercheCommissionate  	as	  'A_I2_ProventiDaRicercheCommissionate',  
  B.A_I3_ProventiDaRicercheConFinanziamento  	as	  'A_I3_ProventiDaRicercheConFinanziamento',  
  B.A_I_ProventiPropri  	as	  'A_I_ProventiPropri',  
  B.A_II1_ContributiMIUR  	as	  'A_II1_ContributiMIUR',  
  B.A_II2_ContributiRegioni  	as	  'A_II2_ContributiRegioni',  
  B.A_II3_ContributiAltreAmministrazioni  	as	  'A_II3_ContributiAltreAmministrazioni',  
  B.A_II4_ContributiUE  	as	  'A_II4_ContributiUE',  
  B.A_II5_ContributiUniversita  	as	  'A_II5_ContributiUniversita',  
  B.A_II6_ContributiAltriPubblici  	as	  'A_II6_ContributiAltriPubblici',  
  B.A_II7_ContributiAltriPrivati  	as	  'A_II7_ContributiAltriPrivati',  
  B.A_II_Contributi  	as	  'A_II_Contributi',  
  B.A_III_ProventiPerAttivitaAssistenziale  	as	  'A_III_ProventiPerAttivitaAssistenziale',  
  B.A_IV_ProventiPerGestioneDiretta  	as	  'A_IV_ProventiPerGestioneDiretta',  
  B.A_V1_UtilizzoRiservePatrimonioNetto  as 'A_V1_UtilizzoRiservePatrimonioNetto ',
  B.A_V2_AltriProventi as 'A_V2_AltriProventi',
  B.A_V_UtilizzoRiservePatrimonioNetto  	as	  'A_V_UtilizzoRiservePatrimonioNetto',  
  B.A_VI_VariazioniRimanenze  	as	  'A_VI_VariazioniRimanenze',  
  B.A_VII_IncrementoImmobilizzazioni  	as	  'A_VII_IncrementoImmobilizzazioni',  
  B.B_VIII1a_CostiDocentiRicercatori  	as	  'B_VIII1a_CostiDocentiRicercatori',  
  B.B_VIII1b_CollaborazioniScientifiche  	as	  'B_VIII1b_CollaborazioniScientifiche',  
  B.B_VIII1c_DocentiAContratto   	as	  'B_VIII1c_DocentiAContratto',   
  B.B_VIII1d_EspertiLinguistici  	as	  'B_VIII1d_EspertiLinguistici',  
  B.B_VIII1e_AltroPersonale  	as	  'B_VIII1e_AltroPersonale',  
  B.B_VIII2_CostiPersonaleDirigente  	as	  'B_VIII2_CostiPersonaleDirigente',  
  B.B_VIII_CostiPersonale  	as	  'B_VIII_CostiPersonale',  
  B.B_IX1_CostiSostegnoStudenti  	as	  'B_IX1_CostiSostegnoStudenti',  
  B.B_IX2_CostiDirittoStudio  	as	  'B_IX2_CostiDirittoStudio',  
  B.B_IX3_CostiRicercaAttivitaEditoriale  	as	  'B_IX3_CostiRicercaAttivitaEditoriale',  
  B.B_IX4_TrasferimentiPartner  	as	  'B_IX4_TrasferimentiPartner',  
  B.B_IX5_AcquistoMaterialeConsumo   	as	  'B_IX5_AcquistoMaterialeConsumo',   
  B.B_IX6_VariazioneRimanenze  	as	  'B_IX6_VariazioneRimanenze',  
  B.B_IX7_AcquistoLibri  	as	  'B_IX7_AcquistoLibri',  
  B.B_IX8_AcquistoServizi  	as	  'B_IX8_AcquistoServizi',  
  B.B_IX9_AcquistoAltriMateriali  	as	  'B_IX9_AcquistoAltriMateriali',  
  B.B_IX10_VariazioneRimanenze  	as	  'B_IX10_VariazioneRimanenze',  
  B.B_IX11_CostiGodimento  	as	  'B_IX11_CostiGodimento',  
  B.B_IX12_AltriCosti   	as	  'B_IX12_AltriCosti',   
  B.IX_CostiGestione  	as	  'IX_CostiGestione',  
  B.B_X1_AmmortamentiImmobImmateriali  	as	  'B_X1_AmmortamentiImmobImmateriali',  
  B.B_X2_AmmortamentiImmobMateriali  	as	  'B_X2_AmmortamentiImmobMateriali',  
  B.B_X3_SvalutazioniImmobilizzazioni  	as	  'B_X3_SvalutazioniImmobilizzazioni',
  B.B_X4_SvalutazioniCrediti  	as	  'B_X4_SvalutazioniCrediti',  
  B.X_AmmortamentiSvalutazioni  	as	  'X_AmmortamentiSvalutazioni',  
  B.B_XI_AccantonamentiRischiOneri  	as	  'B_XI_AccantonamentiRischiOneri',  
  B.B_XII_OneriDversiGestione  	as	  'B_XII_OneriDversiGestione',  
  B.C_1ProventiFinanziari  	as	  'C_1ProventiFinanziari',  
  B.C_2Interessi  	as	  'C_2Interessi',  
  B.C_3Utili  	as	  'C_3Utili',  
  B.C_3Perdite  	as	  'C_3Perdite',  
  B.C_ProventiOneri  	as	  'C_ProventiOneri',  
  B.D_1Rivalutazioni  	as	  'D_1Rivalutazioni',  
  B.D_2Svalutazioni  	as	  'D_2Svalutazioni',  
  B.D_Rettifiche  	as	  'D_Rettifiche',  
  B.E_1ProventiStraordinari   	as	  'E_1ProventiStraordinari',   
  B.E_2OneriStraordinari   	as	  'E_2OneriStraordinari',   
  B.E_ProventiOneriStraordinari  	as	  'E_ProventiOneriStraordinari',  
  B.F_Imposte   	as	  'F_Imposte',   
  B.G_UtilizzoDiRiserve   	as	  'G_UtilizzoDiRiserve',   
  B.TOTRICAVI  	as	  'TotRicavi',  
  B.TOTCOSTI  	as	  'TotCosto',  
  B.RisultatoEconomicoPresunto  	as	  'RisultatoEconomicoPresunto', 
  B.RisultatoAPareggio 	as	  'RisultatoAPareggio', 
 ----------------------------------------------------------------------------------------------------------
 --------------------------------- esercizio precedente----------------------------------------------------
 ----------------------------------------------------------------------------------------------------------
  B1.A_I1_ProventiPerLaDidattica  	as	  'A_I1_ProventiPerLaDidattica_prec',  
  B1.A_I2_ProventiDaRicercheCommissionate  	as	  'A_I2_ProventiDaRicercheCommissionate_prec',  
  B1.A_I3_ProventiDaRicercheConFinanziamento  	as	  'A_I3_ProventiDaRicercheConFinanziamento_prec',  
  B1.A_I_ProventiPropri  	as	  'A_I_ProventiPropri_prec',  
  B1.A_II1_ContributiMIUR  	as	  'A_II1_ContributiMIUR_prec',  
  B1.A_II2_ContributiRegioni  	as	  'A_II2_ContributiRegioni_prec',  
  B1.A_II3_ContributiAltreAmministrazioni  	as	  'A_II3_ContributiAltreAmministrazioni_prec',  
  B1.A_II4_ContributiUE  	as	  'A_II4_ContributiUE_prec',  
  B1.A_II5_ContributiUniversita  	as	  'A_II5_ContributiUniversita_prec',  
  B1.A_II6_ContributiAltriPubblici  	as	  'A_II6_ContributiAltriPubblici_prec',  
  B1.A_II7_ContributiAltriPrivati  	as	  'A_II7_ContributiAltriPrivati_prec',  
  B1.A_II_Contributi  	as	  'A_II_Contributi_prec',  
  B1.A_III_ProventiPerAttivitaAssistenziale  	as	  'A_III_ProventiPerAttivitaAssistenziale_prec',  
  B1.A_IV_ProventiPerGestioneDiretta  	as	  'A_IV_ProventiPerGestioneDiretta_prec',  
  B1.A_V1_UtilizzoRiservePatrimonioNetto  as 'A_V1_UtilizzoRiservePatrimonioNetto_prec',
  B1.A_V2_AltriProventi as 'A_V2_AltriProventi_prec',
  B1.A_V_UtilizzoRiservePatrimonioNetto  	as	  'A_V_UtilizzoRiservePatrimonioNetto_prec',  
  B1.A_VI_VariazioniRimanenze  	as	  'A_VI_VariazioniRimanenze_prec',  
  B1.A_VII_IncrementoImmobilizzazioni  	as	  'A_VII_IncrementoImmobilizzazioni_prec',  
  B1.B_VIII1a_CostiDocentiRicercatori  	as	  'B_VIII1a_CostiDocentiRicercatori_prec',  
  B1.B_VIII1b_CollaborazioniScientifiche  	as	  'B_VIII1b_CollaborazioniScientifiche_prec',  
  B1.B_VIII1c_DocentiAContratto   	as	  'B_VIII1c_DocentiAContratto_prec',   
  B1.B_VIII1d_EspertiLinguistici  	as	  'B_VIII1d_EspertiLinguistici_prec',  
  B1.B_VIII1e_AltroPersonale  	as	  'B_VIII1e_AltroPersonale_prec',  
  B1.B_VIII2_CostiPersonaleDirigente  	as	  'B_VIII2_CostiPersonaleDirigente_prec',  
  B1.B_VIII_CostiPersonale  	as	  'B_VIII_CostiPersonale_prec',  
  B1.B_IX1_CostiSostegnoStudenti  	as	  'B_IX1_CostiSostegnoStudenti_prec',  
  B1.B_IX2_CostiDirittoStudio  	as	  'B_IX2_CostiDirittoStudio_prec',  
  B1.B_IX3_CostiRicercaAttivitaEditoriale  	as	  'B_IX3_CostiRicercaAttivitaEditoriale_prec',  
  B1.B_IX4_TrasferimentiPartner  	as	  'B_IX4_TrasferimentiPartner_prec',  
  B1.B_IX5_AcquistoMaterialeConsumo   	as	  'B_IX5_AcquistoMaterialeConsumo_prec',   
  B1.B_IX6_VariazioneRimanenze  	as	  'B_IX6_VariazioneRimanenze_prec',  
  B1.B_IX7_AcquistoLibri  	as	  'B_IX7_AcquistoLibri_prec',  
  B1.B_IX8_AcquistoServizi  	as	  'B_IX8_AcquistoServizi_prec',  
  B1.B_IX9_AcquistoAltriMateriali  	as	  'B_IX9_AcquistoAltriMateriali_prec',  
  B1.B_IX10_VariazioneRimanenze  	as	  'B_IX10_VariazioneRimanenze_prec',  
  B1.B_IX11_CostiGodimento  	as	  'B_IX11_CostiGodimento_prec',  
  B1.B_IX12_AltriCosti   	as	  'B_IX12_AltriCosti_prec',   
  B1.IX_CostiGestione  	as	  'IX_CostiGestione_prec',  
  B1.B_X1_AmmortamentiImmobImmateriali  	as	  'B_X1_AmmortamentiImmobImmateriali_prec',  
  B1.B_X2_AmmortamentiImmobMateriali  	as	  'B_X2_AmmortamentiImmobMateriali_prec',  
  B1.B_X3_SvalutazioniImmobilizzazioni  	as	  'B_X3_SvalutazioniImmobilizzazioni_prec',
  B1.B_X4_SvalutazioniCrediti  	as	  'B_X4_SvalutazioniCrediti_prec',  
  B1.X_AmmortamentiSvalutazioni  	as	  'X_AmmortamentiSvalutazioni_prec',  
  B1.B_XI_AccantonamentiRischiOneri  	as	  'B_XI_AccantonamentiRischiOneri_prec',  
  B1.B_XII_OneriDversiGestione  	as	  'B_XII_OneriDversiGestione_prec',  
  B1.C_1ProventiFinanziari  	as	  'C_1ProventiFinanziari_prec',  
  B1.C_2Interessi  	as	  'C_2Interessi_prec',  
  B1.C_3Utili  	as	  'C_3Utili_prec',  
  B1.C_3Perdite  	as	  'C_3Perdite_prec',  
  B1.C_ProventiOneri  	as	  'C_ProventiOneri_prec',  
  B1.D_1Rivalutazioni  	as	  'D_1Rivalutazioni_prec',  
  B1.D_2Svalutazioni  	as	  'D_2Svalutazioni_prec',  
  B1.D_Rettifiche  	as	  'D_Rettifiche_prec',  
  B1.E_1ProventiStraordinari   	as	  'E_1ProventiStraordinari_prec',   
  B1.E_2OneriStraordinari   	as	  'E_2OneriStraordinari_prec',   
  B1.E_ProventiOneriStraordinari  	as	  'E_ProventiOneriStraordinari_prec',  
  B1.F_Imposte   	as	  'F_Imposte_prec',   
  B1.G_UtilizzoDiRiserve   	as	  'G_UtilizzoDiRiserve_prec',   
  B1.TOTRICAVI  	as	  'TotRicavi_prec',  
  B1.TOTCOSTI  	as	  'TotCosto_prec',  
  B1.RisultatoEconomicoPresunto  	as	  'RisultatoEconomicoPresunto_prec', 
  B1.RisultatoAPareggio 	as	  'RisultatoAPareggio_prec' 
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


