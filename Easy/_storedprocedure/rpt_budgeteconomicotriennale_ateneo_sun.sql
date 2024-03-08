
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_budgeteconomicotriennale_ateneo_sun]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_budgeteconomicotriennale_ateneo_sun]
GO
/****** Object:  StoredProcedure [rpt_budgeteconomicotriennale_ateneo_sun]    Script Date: 10/11/2014 11.24.01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- exec amministrazione.[rpt_budgeteconomicotriennale_ateneo_sun] 2014, 15,'00010001','S'
CREATE PROCEDURE [rpt_budgeteconomicotriennale_ateneo_sun](
	@ayear int,--> anno del bilancio di previsione
	@idsorkind int
)
AS BEGIN
/*

Gianni 27/10/2014 Stampa del Budget Economico di Ateneo
Lanciare due volte la stored procedure [rpt_budgeteconomicotriennale_sun]

Prima volta per i dati dell'amministrazione
amministrazione.rpt_budgeteconomicotriennale_sun 2014, 15,'00010001%','S'
Seconda volta per i dati dei dipartimenti
amministrazione.rpt_budgeteconomicotriennale_sun 2014, 15,'00010002%','S'

*/


/*Tabella Temporanea per l'amministrazione*/
CREATE TABLE #DATI_AMM
(
[treasurer_amm] decimal(19,2),
[I_PROVENTI_PROPRI_amm] decimal(19,2),
[II_CONTRIBUTI_amm] decimal(19,2),
[III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE_amm] decimal(19,2),
[IV_PROVENTI_PER_GESTIONE_DIRETTA_amm] decimal(19,2),
[V_ALTRI_PROVENTI_amm] decimal(19,2),
[VI_VARIAZIONE_LAVORI_IN_CORSO_amm] decimal(19,2),
[VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI_amm] decimal(19,2),
[PROVENTIOPERATIVI_amm] decimal(19,2),
[COSTI_OPERATIVI_amm] decimal(19,2),
[COSTI_SPECIFICI_amm] decimal(19,2),
[I_SOSTEGNO_AGLI_STUDENTI_amm] decimal(19,2),
[1_Interventi_favore_degli_studenti_amm] decimal(19,2),
[2_Borse_di_studio_amm] decimal(19,2),
[II_Interventi_diritto_allo_studio_amm] decimal(19,2),
[III_Sostegno_alla_ricerca_amm] decimal(19,2),
[IV_Personale_dedicato_alla_ricerca_amm] decimal(19,2),
[1_Docenti_amm] decimal(19,2),
[2_Ricercatori_amm] decimal(19,2),
[3_Ricercatori_a_tempo_determinato_amm] decimal(19,2),
[4_Collaborazioni_scientifiche_amm] decimal(19,2),
[5_Docenti_contratto_amm] decimal(19,2),
[6_Esperti_linguistici_amm] decimal(19,2),
[7_Altro_personale_dedicato_alla_ricerca_didattica_amm] decimal(19,2),
[8_Missioni_personale_dedicato_alla_didattica_amm] decimal(19,2),
[9_Altri_oneri_personale_amm] decimal(19,2),
[V_Acquisto_materiale_amm] decimal(19,2),
[VI_Trasferimenti_amm] decimal(19,2),
[VII_Altri_costi_specifici_amm] decimal(19,2),
[COSTI_GENERALI_amm] decimal(19,2),
[I_Personale_tecnicoamministrativo_amm] decimal(19,2),
[II_Acquisto_materiali_amm] decimal(19,2),
[III_Acquisto_libri_periodici_amm] decimal(19,2),
[IV_Acquisto_servizi_amm] decimal(19,2),
[V_Costi_godimento_beni_amm] decimal(19,2),
[VI_Altri_costi_generali_amm] decimal(19,2),
[1_Utenze_canoni_amm] decimal(19,2),
[2_Manutenzione_ordinaria_amm] decimal(19,2),
[3_Manutenzione_straordinaria_amm] decimal(19,2),
[4_Altri_costi_generali_amm] decimal(19,2),
[DIFFERENZA_PROVENTI_E_COSTI_OPERATIVI_amm] decimal(19,2),
[AMMORTAMENTI_SVALUTAZIONI_amm] decimal(19,2),
[ACCANTONAMENTI_RISCHI_ONERI_amm] decimal(19,2),
[ALTRI_ACCANTONAMENTI_amm] decimal(19,2),
[ONERI_DIVERSI_GESTIONE_amm] decimal(19,2),
[I_Imposte_varie_amm] decimal(19,2),
[II_Altri_oneri_amm] decimal(19,2),
[III_Trasferimenti_correnti_amm] decimal(19,2),
[IV_Trasferimenti_investimenti_amm] decimal(19,2),
[PROVENTI_E_ONERI_FINANZIARI_amm] decimal(19,2),
[proventi_amm] decimal(19,2),
[oneri_amm] decimal(19,2),
[RETTIFICHE_DI_VALORE_DI_ATTIVITA_FINANZIARIE_amm] decimal(19,2),
[PROVENTI_ONERI_STRAORDINARI_amm] decimal(19,2),
[1_PROVENTI_STRAORDINARI_amm] decimal(19,2),
[2_ONERI_STRAORDINARI_amm] decimal(19,2),
[IMPOSTE_TASSE_amm] decimal(19,2),
[I_PROVENTI_PROPRI_ANNO_2_amm] decimal(19,2),
[II_CONTRIBUTI_ANNO_2_amm] decimal(19,2),
[III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE_ANNO_2_amm] decimal(19,2),
[IV_PROVENTI_PER_GESTIONE_DIRETTA_ANNO_2_amm] decimal(19,2),
[V_ALTRI_PROVENTI_ANNO_2_amm] decimal(19,2),
[VI_VARIAZIONE_LAVORI_IN_CORSO_ANNO_2_amm] decimal(19,2),
[VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI_ANNO_2_amm] decimal(19,2),
[PROVENTIOPERATIVI_ANNO_2_amm] decimal(19,2),
[COSTI_OPERATIVI_ANNO_2_amm] decimal(19,2),
[COSTI_SPECIFICI_ANNO_2_amm] decimal(19,2),
[I_SOSTEGNO_AGLI_STUDENTI_ANNO_2_amm] decimal(19,2),
[1_Interventi_favore_degli_studenti_ANNO_2_amm] decimal(19,2),
[2_Borse_di_studio_ANNO_2_amm] decimal(19,2),
[II_Interventi_diritto_allo_studio_ANNO_2_amm] decimal(19,2),
[III_Sostegno_alla_ricerca_ANNO_2_amm] decimal(19,2),
[IV_Personale_dedicato_alla_ricerca_ANNO_2_amm] decimal(19,2),
[1_Docenti_ANNO_2_amm] decimal(19,2),
[2_Ricercatori_ANNO_2_amm] decimal(19,2),
[3_Ricercatori_a_tempo_determinato_ANNO_2_amm] decimal(19,2),
[4_Collaborazioni_scientifiche_ANNO_2_amm] decimal(19,2),
[5_Docenti_contratto_ANNO_2_amm] decimal(19,2),
[6_Esperti_linguistici_ANNO_2_amm] decimal(19,2),
[7_Altro_personale_dedicato_alla_ricerca_didattica_ANNO_2_amm] decimal(19,2),
[8_Missioni_personale_dedicato_alla_didattica_ANNO_2_amm] decimal(19,2),
[9_Altri_oneri_personale_ANNO_2_amm] decimal(19,2),
[V_Acquisto_materiale_ANNO_2_amm] decimal(19,2),
[VI_Trasferimenti_ANNO_2_amm] decimal(19,2),
[VII_Altri_costi_specifici_ANNO_2_amm] decimal(19,2),
[COSTI_GENERALI_ANNO_2_amm] decimal(19,2),
[I_Personale_tecnicoamministrativo_ANNO_2_amm] decimal(19,2),
[II_Acquisto_materiali_ANNO_2_amm] decimal(19,2),
[III_Acquisto_libri_periodici_ANNO_2_amm] decimal(19,2),
[IV_Acquisto_servizi_ANNO_2_amm] decimal(19,2),
[V_Costi_godimento_beni_ANNO_2_amm] decimal(19,2),
[VI_Altri_costi_generali_ANNO_2_amm] decimal(19,2),
[1_Utenze_canoni_ANNO_2_amm] decimal(19,2),
[2_Manutenzione_ordinaria_ANNO_2_amm] decimal(19,2),
[3_Manutenzione_straordinaria_ANNO_2_amm] decimal(19,2),
[4_Altri_costi_generali_ANNO_2_amm] decimal(19,2),
[DIFFERENZA_PROVENTI_E_COSTI_OPERATIVI_ANNO_2_amm] decimal(19,2),
[AMMORTAMENTI_SVALUTAZIONI_ANNO_2_amm] decimal(19,2),
[ACCANTONAMENTI_RISCHI_ONERI_ANNO_2_amm] decimal(19,2),
[ALTRI_ACCANTONAMENTI_ANNO_2_amm] decimal(19,2),
[ONERI_DIVERSI_GESTIONE_ANNO_2_amm] decimal(19,2),
[I_Imposte_varie_ANNO_2_amm] decimal(19,2),
[II_Altri_oneri_ANNO_2_amm] decimal(19,2),
[III_Trasferimenti_correnti_ANNO_2_amm] decimal(19,2),
[IV_Trasferimenti_investimenti_ANNO_2_amm] decimal(19,2),
[PROVENTI_E_ONERI_FINANZIARI_ANNO_2_amm] decimal(19,2),
[proventi_ANNO_2_amm] decimal(19,2),
[oneri_ANNO_2_amm] decimal(19,2),
[RETTIFICHE_DI_VALORE_DI_ATTIVITA_FINANZIARIE_ANNO_2_amm] decimal(19,2),
[PROVENTI_ONERI_STRAORDINARI_ANNO_2_amm] decimal(19,2),
[1_PROVENTI_STRAORDINARI_ANNO_2_amm] decimal(19,2),
[2_ONERI_STRAORDINARI_ANNO_2_amm] decimal(19,2),
[IMPOSTE_TASSE_ANNO_2_amm] decimal(19,2),
[I_PROVENTI_PROPRI_ANNO_3_amm] decimal(19,2),
[II_CONTRIBUTI_ANNO_3_amm] decimal(19,2),
[III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE_ANNO_3_amm] decimal(19,2),
[IV_PROVENTI_PER_GESTIONE_DIRETTA_ANNO_3_amm] decimal(19,2),
[V_ALTRI_PROVENTI_ANNO_3_amm] decimal(19,2),
[VI_VARIAZIONE_LAVORI_IN_CORSO_ANNO_3_amm] decimal(19,2),
[VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI_ANNO_3_amm] decimal(19,2),
[PROVENTIOPERATIVI_ANNO_3_amm] decimal(19,2),
[COSTI_OPERATIVI_ANNO_3_amm] decimal(19,2),
[COSTI_SPECIFICI_ANNO_3_amm] decimal(19,2),
[I_SOSTEGNO_AGLI_STUDENTI_ANNO_3_amm] decimal(19,2),
[1_Interventi_favore_degli_studenti_ANNO_3_amm] decimal(19,2),
[2_Borse_di_studio_ANNO_3_amm] decimal(19,2),
[II_Interventi_diritto_allo_studio_ANNO_3_amm] decimal(19,2),
[III_Sostegno_alla_ricerca_ANNO_3_amm] decimal(19,2),
[IV_Personale_dedicato_alla_ricerca_ANNO_3_amm] decimal(19,2),
[1_Docenti_ANNO_3_amm] decimal(19,2),
[2_Ricercatori_ANNO_3_amm] decimal(19,2),
[3_Ricercatori_a_tempo_determinato_ANNO_3_amm] decimal(19,2),
[4_Collaborazioni_scientifiche_ANNO_3_amm] decimal(19,2),
[5_Docenti_contratto_ANNO_3_amm] decimal(19,2),
[6_Esperti_linguistici_ANNO_3_amm] decimal(19,2),
[7_Altro_personale_dedicato_alla_ricerca_didattica_ANNO_3_amm] decimal(19,2),
[8_Missioni_personale_dedicato_alla_didattica_ANNO_3_amm] decimal(19,2),
[9_Altri_oneri_personale_ANNO_3_amm] decimal(19,2),
[V_Acquisto_materiale_ANNO_3_amm] decimal(19,2),
[VI_Trasferimenti_ANNO_3_amm] decimal(19,2),
[VII_Altri_costi_specifici_ANNO_3_amm] decimal(19,2),
[COSTI_GENERALI_ANNO_3_amm] decimal(19,2),
[I_Personale_tecnicoamministrativo_ANNO_3_amm] decimal(19,2),
[II_Acquisto_materiali_ANNO_3_amm] decimal(19,2),
[III_Acquisto_libri_periodici_ANNO_3_amm] decimal(19,2),
[IV_Acquisto_servizi_ANNO_3_amm] decimal(19,2),
[V_Costi_godimento_beni_ANNO_3_amm] decimal(19,2),
[VI_Altri_costi_generali_ANNO_3_amm] decimal(19,2),
[1_Utenze_canoni_ANNO_3_amm] decimal(19,2),
[2_Manutenzione_ordinaria_ANNO_3_amm] decimal(19,2),
[3_Manutenzione_straordinaria_ANNO_3_amm] decimal(19,2),
[4_Altri_costi_generali_ANNO_3_amm] decimal(19,2),
[DIFFERENZA_PROVENTI_E_COSTI_OPERATIVI_ANNO_3_amm] decimal(19,2),
[AMMORTAMENTI_SVALUTAZIONI_ANNO_3_amm] decimal(19,2),
[ACCANTONAMENTI_RISCHI_ONERI_ANNO_3_amm] decimal(19,2),
[ALTRI_ACCANTONAMENTI_ANNO_3_amm] decimal(19,2),
[ONERI_DIVERSI_GESTIONE_ANNO_3_amm] decimal(19,2),
[I_Imposte_varie_ANNO_3_amm] decimal(19,2),
[II_Altri_oneri_ANNO_3_amm] decimal(19,2),
[III_Trasferimenti_correnti_ANNO_3_amm] decimal(19,2),
[IV_Trasferimenti_investimenti_ANNO_3_amm] decimal(19,2),
[PROVENTI_E_ONERI_FINANZIARI_ANNO_3_amm] decimal(19,2),
[proventi_ANNO_3_amm] decimal(19,2),
[oneri_ANNO_3_amm] decimal(19,2),
[RETTIFICHE_DI_VALORE_DI_ATTIVITA_FINANZIARIE_ANNO_3_amm] decimal(19,2),
[PROVENTI_ONERI_STRAORDINARI_ANNO_3_amm] decimal(19,2),
[1_PROVENTI_STRAORDINARI_ANNO_3_amm] decimal(19,2),
[2_ONERI_STRAORDINARI_ANNO_3_amm] decimal(19,2),
[IMPOSTE_TASSE_ANNO_3_amm] decimal(19,2)
)

/*Tabella Temporanea per i dipartimenti*/
CREATE TABLE #DATI_DIP
(
[treasurer_dip] decimal(19,2),
[I_PROVENTI_PROPRI_dip] decimal(19,2),
[II_CONTRIBUTI_dip] decimal(19,2),
[III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE_dip] decimal(19,2),
[IV_PROVENTI_PER_GESTIONE_DIRETTA_dip] decimal(19,2),
[V_ALTRI_PROVENTI_dip] decimal(19,2),
[VI_VARIAZIONE_LAVORI_IN_CORSO_dip] decimal(19,2),
[VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI_dip] decimal(19,2),
[PROVENTIOPERATIVI_dip] decimal(19,2),
[COSTI_OPERATIVI_dip] decimal(19,2),
[COSTI_SPECIFICI_dip] decimal(19,2),
[I_SOSTEGNO_AGLI_STUDENTI_dip] decimal(19,2),
[1_Interventi_favore_degli_studenti_dip] decimal(19,2),
[2_Borse_di_studio_dip] decimal(19,2),
[II_Interventi_diritto_allo_studio_dip] decimal(19,2),
[III_Sostegno_alla_ricerca_dip] decimal(19,2),
[IV_Personale_dedicato_alla_ricerca_dip] decimal(19,2),
[1_Docenti_dip] decimal(19,2),
[2_Ricercatori_dip] decimal(19,2),
[3_Ricercatori_a_tempo_determinato_dip] decimal(19,2),
[4_Collaborazioni_scientifiche_dip] decimal(19,2),
[5_Docenti_contratto_dip] decimal(19,2),
[6_Esperti_linguistici_dip] decimal(19,2),
[7_Altro_personale_dedicato_alla_ricerca_didattica_dip] decimal(19,2),
[8_Missioni_personale_dedicato_alla_didattica_dip] decimal(19,2),
[9_Altri_oneri_personale_dip] decimal(19,2),
[V_Acquisto_materiale_dip] decimal(19,2),
[VI_Trasferimenti_dip] decimal(19,2),
[VII_Altri_costi_specifici_dip] decimal(19,2),
[COSTI_GENERALI_dip] decimal(19,2),
[I_Personale_tecnicoamministrativo_dip] decimal(19,2),
[II_Acquisto_materiali_dip] decimal(19,2),
[III_Acquisto_libri_periodici_dip] decimal(19,2),
[IV_Acquisto_servizi_dip] decimal(19,2),
[V_Costi_godimento_beni_dip] decimal(19,2),
[VI_Altri_costi_generali_dip] decimal(19,2),
[1_Utenze_canoni_dip] decimal(19,2),
[2_Manutenzione_ordinaria_dip] decimal(19,2),
[3_Manutenzione_straordinaria_dip] decimal(19,2),
[4_Altri_costi_generali_dip] decimal(19,2),
[DIFFERENZA_PROVENTI_E_COSTI_OPERATIVI_dip] decimal(19,2),
[AMMORTAMENTI_SVALUTAZIONI_dip] decimal(19,2),
[ACCANTONAMENTI_RISCHI_ONERI_dip] decimal(19,2),
[ALTRI_ACCANTONAMENTI_dip] decimal(19,2),
[ONERI_DIVERSI_GESTIONE_dip] decimal(19,2),
[I_Imposte_varie_dip] decimal(19,2),
[II_Altri_oneri_dip] decimal(19,2),
[III_Trasferimenti_correnti_dip] decimal(19,2),
[IV_Trasferimenti_investimenti_dip] decimal(19,2),
[PROVENTI_E_ONERI_FINANZIARI_dip] decimal(19,2),
[proventi_dip] decimal(19,2),
[oneri_dip] decimal(19,2),
[RETTIFICHE_DI_VALORE_DI_ATTIVITA_FINANZIARIE_dip] decimal(19,2),
[PROVENTI_ONERI_STRAORDINARI_dip] decimal(19,2),
[1_PROVENTI_STRAORDINARI_dip] decimal(19,2),
[2_ONERI_STRAORDINARI_dip] decimal(19,2),
[IMPOSTE_TASSE_dip] decimal(19,2),
[I_PROVENTI_PROPRI_ANNO_2_dip] decimal(19,2),
[II_CONTRIBUTI_ANNO_2_dip] decimal(19,2),
[III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE_ANNO_2_dip] decimal(19,2),
[IV_PROVENTI_PER_GESTIONE_DIRETTA_ANNO_2_dip] decimal(19,2),
[V_ALTRI_PROVENTI_ANNO_2_dip] decimal(19,2),
[VI_VARIAZIONE_LAVORI_IN_CORSO_ANNO_2_dip] decimal(19,2),
[VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI_ANNO_2_dip] decimal(19,2),
[PROVENTIOPERATIVI_ANNO_2_dip] decimal(19,2),
[COSTI_OPERATIVI_ANNO_2_dip] decimal(19,2),
[COSTI_SPECIFICI_ANNO_2_dip] decimal(19,2),
[I_SOSTEGNO_AGLI_STUDENTI_ANNO_2_dip] decimal(19,2),
[1_Interventi_favore_degli_studenti_ANNO_2_dip] decimal(19,2),
[2_Borse_di_studio_ANNO_2_dip] decimal(19,2),
[II_Interventi_diritto_allo_studio_ANNO_2_dip] decimal(19,2),
[III_Sostegno_alla_ricerca_ANNO_2_dip] decimal(19,2),
[IV_Personale_dedicato_alla_ricerca_ANNO_2_dip] decimal(19,2),
[1_Docenti_ANNO_2_dip] decimal(19,2),
[2_Ricercatori_ANNO_2_dip] decimal(19,2),
[3_Ricercatori_a_tempo_determinato_ANNO_2_dip] decimal(19,2),
[4_Collaborazioni_scientifiche_ANNO_2_dip] decimal(19,2),
[5_Docenti_contratto_ANNO_2_dip] decimal(19,2),
[6_Esperti_linguistici_ANNO_2_dip] decimal(19,2),
[7_Altro_personale_dedicato_alla_ricerca_didattica_ANNO_2_dip] decimal(19,2),
[8_Missioni_personale_dedicato_alla_didattica_ANNO_2_dip] decimal(19,2),
[9_Altri_oneri_personale_ANNO_2_dip] decimal(19,2),
[V_Acquisto_materiale_ANNO_2_dip] decimal(19,2),
[VI_Trasferimenti_ANNO_2_dip] decimal(19,2),
[VII_Altri_costi_specifici_ANNO_2_dip] decimal(19,2),
[COSTI_GENERALI_ANNO_2_dip] decimal(19,2),
[I_Personale_tecnicoamministrativo_ANNO_2_dip] decimal(19,2),
[II_Acquisto_materiali_ANNO_2_dip] decimal(19,2),
[III_Acquisto_libri_periodici_ANNO_2_dip] decimal(19,2),
[IV_Acquisto_servizi_ANNO_2_dip] decimal(19,2),
[V_Costi_godimento_beni_ANNO_2_dip] decimal(19,2),
[VI_Altri_costi_generali_ANNO_2_dip] decimal(19,2),
[1_Utenze_canoni_ANNO_2_dip] decimal(19,2),
[2_Manutenzione_ordinaria_ANNO_2_dip] decimal(19,2),
[3_Manutenzione_straordinaria_ANNO_2_dip] decimal(19,2),
[4_Altri_costi_generali_ANNO_2_dip] decimal(19,2),
[DIFFERENZA_PROVENTI_E_COSTI_OPERATIVI_ANNO_2_dip] decimal(19,2),
[AMMORTAMENTI_SVALUTAZIONI_ANNO_2_dip] decimal(19,2),
[ACCANTONAMENTI_RISCHI_ONERI_ANNO_2_dip] decimal(19,2),
[ALTRI_ACCANTONAMENTI_ANNO_2_dip] decimal(19,2),
[ONERI_DIVERSI_GESTIONE_ANNO_2_dip] decimal(19,2),
[I_Imposte_varie_ANNO_2_dip] decimal(19,2),
[II_Altri_oneri_ANNO_2_dip] decimal(19,2),
[III_Trasferimenti_correnti_ANNO_2_dip] decimal(19,2),
[IV_Trasferimenti_investimenti_ANNO_2_dip] decimal(19,2),
[PROVENTI_E_ONERI_FINANZIARI_ANNO_2_dip] decimal(19,2),
[proventi_ANNO_2_dip] decimal(19,2),
[oneri_ANNO_2_dip] decimal(19,2),
[RETTIFICHE_DI_VALORE_DI_ATTIVITA_FINANZIARIE_ANNO_2_dip] decimal(19,2),
[PROVENTI_ONERI_STRAORDINARI_ANNO_2_dip] decimal(19,2),
[1_PROVENTI_STRAORDINARI_ANNO_2_dip] decimal(19,2),
[2_ONERI_STRAORDINARI_ANNO_2_dip] decimal(19,2),
[IMPOSTE_TASSE_ANNO_2_dip] decimal(19,2),
[I_PROVENTI_PROPRI_ANNO_3_dip] decimal(19,2),
[II_CONTRIBUTI_ANNO_3_dip] decimal(19,2),
[III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE_ANNO_3_dip] decimal(19,2),
[IV_PROVENTI_PER_GESTIONE_DIRETTA_ANNO_3_dip] decimal(19,2),
[V_ALTRI_PROVENTI_ANNO_3_dip] decimal(19,2),
[VI_VARIAZIONE_LAVORI_IN_CORSO_ANNO_3_dip] decimal(19,2),
[VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI_ANNO_3_dip] decimal(19,2),
[PROVENTIOPERATIVI_ANNO_3_dip] decimal(19,2),
[COSTI_OPERATIVI_ANNO_3_dip] decimal(19,2),
[COSTI_SPECIFICI_ANNO_3_dip] decimal(19,2),
[I_SOSTEGNO_AGLI_STUDENTI_ANNO_3_dip] decimal(19,2),
[1_Interventi_favore_degli_studenti_ANNO_3_dip] decimal(19,2),
[2_Borse_di_studio_ANNO_3_dip] decimal(19,2),
[II_Interventi_diritto_allo_studio_ANNO_3_dip] decimal(19,2),
[III_Sostegno_alla_ricerca_ANNO_3_dip] decimal(19,2),
[IV_Personale_dedicato_alla_ricerca_ANNO_3_dip] decimal(19,2),
[1_Docenti_ANNO_3_dip] decimal(19,2),
[2_Ricercatori_ANNO_3_dip] decimal(19,2),
[3_Ricercatori_a_tempo_determinato_ANNO_3_dip] decimal(19,2),
[4_Collaborazioni_scientifiche_ANNO_3_dip] decimal(19,2),
[5_Docenti_contratto_ANNO_3_dip] decimal(19,2),
[6_Esperti_linguistici_ANNO_3_dip] decimal(19,2),
[7_Altro_personale_dedicato_alla_ricerca_didattica_ANNO_3_dip] decimal(19,2),
[8_Missioni_personale_dedicato_alla_didattica_ANNO_3_dip] decimal(19,2),
[9_Altri_oneri_personale_ANNO_3_dip] decimal(19,2),
[V_Acquisto_materiale_ANNO_3_dip] decimal(19,2),
[VI_Trasferimenti_ANNO_3_dip] decimal(19,2),
[VII_Altri_costi_specifici_ANNO_3_dip] decimal(19,2),
[COSTI_GENERALI_ANNO_3_dip] decimal(19,2),
[I_Personale_tecnicoamministrativo_ANNO_3_dip] decimal(19,2),
[II_Acquisto_materiali_ANNO_3_dip] decimal(19,2),
[III_Acquisto_libri_periodici_ANNO_3_dip] decimal(19,2),
[IV_Acquisto_servizi_ANNO_3_dip] decimal(19,2),
[V_Costi_godimento_beni_ANNO_3_dip] decimal(19,2),
[VI_Altri_costi_generali_ANNO_3_dip] decimal(19,2),
[1_Utenze_canoni_ANNO_3_dip] decimal(19,2),
[2_Manutenzione_ordinaria_ANNO_3_dip] decimal(19,2),
[3_Manutenzione_straordinaria_ANNO_3_dip] decimal(19,2),
[4_Altri_costi_generali_ANNO_3_dip] decimal(19,2),
[DIFFERENZA_PROVENTI_E_COSTI_OPERATIVI_ANNO_3_dip] decimal(19,2),
[AMMORTAMENTI_SVALUTAZIONI_ANNO_3_dip] decimal(19,2),
[ACCANTONAMENTI_RISCHI_ONERI_ANNO_3_dip] decimal(19,2),
[ALTRI_ACCANTONAMENTI_ANNO_3_dip] decimal(19,2),
[ONERI_DIVERSI_GESTIONE_ANNO_3_dip] decimal(19,2),
[I_Imposte_varie_ANNO_3_dip] decimal(19,2),
[II_Altri_oneri_ANNO_3_dip] decimal(19,2),
[III_Trasferimenti_correnti_ANNO_3_dip] decimal(19,2),
[IV_Trasferimenti_investimenti_ANNO_3_dip] decimal(19,2),
[PROVENTI_E_ONERI_FINANZIARI_ANNO_3_dip] decimal(19,2),
[proventi_ANNO_3_dip] decimal(19,2),
[oneri_ANNO_3_dip] decimal(19,2),
[RETTIFICHE_DI_VALORE_DI_ATTIVITA_FINANZIARIE_ANNO_3_dip] decimal(19,2),
[PROVENTI_ONERI_STRAORDINARI_ANNO_3_dip] decimal(19,2),
[1_PROVENTI_STRAORDINARI_ANNO_3_dip] decimal(19,2),
[2_ONERI_STRAORDINARI_ANNO_3_dip] decimal(19,2),
[IMPOSTE_TASSE_ANNO_3_dip] decimal(19,2)
)


insert into #DATI_AMM
exec rpt_budgeteconomicotriennale_sun @ayear, @idsorkind,'00010001%','S'

insert into #DATI_DIP
exec rpt_budgeteconomicotriennale_sun @ayear, @idsorkind,'00010002%','S'

DECLARE @TREASURER VARCHAR(50)


/*Variabili da restituire*/

/*Amministrazione*/

DECLARE @I_PROVENTI_PROPRI_amm decimal(19,2)
DECLARE @II_CONTRIBUTI_amm decimal(19,2)
DECLARE @III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE_amm decimal(19,2)
DECLARE @IV_PROVENTI_PER_GESTIONE_DIRETTA_amm decimal(19,2)
DECLARE @V_ALTRI_PROVENTI_amm decimal(19,2)
DECLARE @VI_VARIAZIONE_LAVORI_IN_CORSO_amm decimal(19,2)
DECLARE @VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI_amm decimal(19,2)
DECLARE @PROVENTIOPERATIVI_amm decimal(19,2)
DECLARE @COSTI_OPERATIVI_amm decimal(19,2)
DECLARE @COSTI_SPECIFICI_amm decimal(19,2)
DECLARE @I_SOSTEGNO_AGLI_STUDENTI_amm decimal(19,2)
DECLARE @1_Interventi_favore_degli_studenti_amm decimal(19,2)
DECLARE @2_Borse_di_studio_amm decimal(19,2)
DECLARE @II_Interventi_diritto_allo_studio_amm decimal(19,2)
DECLARE @III_Sostegno_alla_ricerca_amm decimal(19,2)
DECLARE @IV_Personale_dedicato_alla_ricerca_amm decimal(19,2)
DECLARE @1_Docenti_amm decimal(19,2)
DECLARE @2_Ricercatori_amm decimal(19,2)
DECLARE @3_Ricercatori_a_tempo_determinato_amm decimal(19,2)
DECLARE @4_Collaborazioni_scientifiche_amm decimal(19,2)
DECLARE @5_Docenti_contratto_amm decimal(19,2)
DECLARE @6_Esperti_linguistici_amm decimal(19,2)
DECLARE @7_Altro_personale_dedicato_alla_ricerca_didattica_amm decimal(19,2)
DECLARE @8_Missioni_personale_dedicato_alla_didattica_amm decimal(19,2)
DECLARE @9_Altri_oneri_personale_amm decimal(19,2)
DECLARE @V_Acquisto_materiale_amm decimal(19,2)
DECLARE @VI_Trasferimenti_amm decimal(19,2)
DECLARE @VII_Altri_costi_specifici_amm decimal(19,2)
DECLARE @COSTI_GENERALI_amm decimal(19,2)
DECLARE @I_Personale_tecnicoamministrativo_amm decimal(19,2)
DECLARE @II_Acquisto_materiali_amm decimal(19,2)
DECLARE @III_Acquisto_libri_periodici_amm decimal(19,2)
DECLARE @IV_Acquisto_servizi_amm decimal(19,2)
DECLARE @V_Costi_godimento_beni_amm decimal(19,2)
DECLARE @VI_Altri_costi_generali_amm decimal(19,2)
DECLARE @1_Utenze_canoni_amm decimal(19,2)
DECLARE @2_Manutenzione_ordinaria_amm decimal(19,2)
DECLARE @3_Manutenzione_straordinaria_amm decimal(19,2)
DECLARE @4_Altri_costi_generali_amm decimal(19,2)
DECLARE @DIFFERENZA_PROVENTI_E_COSTI_OPERATIVI_amm decimal(19,2)
DECLARE @AMMORTAMENTI_SVALUTAZIONI_amm decimal(19,2)
DECLARE @ACCANTONAMENTI_RISCHI_ONERI_amm decimal(19,2)
DECLARE @ALTRI_ACCANTONAMENTI_amm decimal(19,2)
DECLARE @ONERI_DIVERSI_GESTIONE_amm decimal(19,2)
DECLARE @I_Imposte_varie_amm decimal(19,2)
DECLARE @II_Altri_oneri_amm decimal(19,2)
DECLARE @III_Trasferimenti_correnti_amm decimal(19,2)
DECLARE @IV_Trasferimenti_investimenti_amm decimal(19,2)
DECLARE @PROVENTI_E_ONERI_FINANZIARI_amm decimal(19,2)
DECLARE @proventi_amm decimal(19,2)
DECLARE @oneri_amm decimal(19,2)
DECLARE @RETTIFICHE_DI_VALORE_DI_ATTIVITA_FINANZIARIE_amm decimal(19,2)
DECLARE @PROVENTI_ONERI_STRAORDINARI_amm decimal(19,2)
DECLARE @1_PROVENTI_STRAORDINARI_amm decimal(19,2)
DECLARE @2_ONERI_STRAORDINARI_amm decimal(19,2)
DECLARE @IMPOSTE_TASSE_amm decimal(19,2)
DECLARE @I_PROVENTI_PROPRI_ANNO_2_amm decimal(19,2)
DECLARE @II_CONTRIBUTI_ANNO_2_amm decimal(19,2)
DECLARE @III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE_ANNO_2_amm decimal(19,2)
DECLARE @IV_PROVENTI_PER_GESTIONE_DIRETTA_ANNO_2_amm decimal(19,2)
DECLARE @V_ALTRI_PROVENTI_ANNO_2_amm decimal(19,2)
DECLARE @VI_VARIAZIONE_LAVORI_IN_CORSO_ANNO_2_amm decimal(19,2)
DECLARE @VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI_ANNO_2_amm decimal(19,2)
DECLARE @PROVENTIOPERATIVI_ANNO_2_amm decimal(19,2)
DECLARE @COSTI_OPERATIVI_ANNO_2_amm decimal(19,2)
DECLARE @COSTI_SPECIFICI_ANNO_2_amm decimal(19,2)
DECLARE @I_SOSTEGNO_AGLI_STUDENTI_ANNO_2_amm decimal(19,2)
DECLARE @1_Interventi_favore_degli_studenti_ANNO_2_amm decimal(19,2)
DECLARE @2_Borse_di_studio_ANNO_2_amm decimal(19,2)
DECLARE @II_Interventi_diritto_allo_studio_ANNO_2_amm decimal(19,2)
DECLARE @III_Sostegno_alla_ricerca_ANNO_2_amm decimal(19,2)
DECLARE @IV_Personale_dedicato_alla_ricerca_ANNO_2_amm decimal(19,2)
DECLARE @1_Docenti_ANNO_2_amm decimal(19,2)
DECLARE @2_Ricercatori_ANNO_2_amm decimal(19,2)
DECLARE @3_Ricercatori_a_tempo_determinato_ANNO_2_amm decimal(19,2)
DECLARE @4_Collaborazioni_scientifiche_ANNO_2_amm decimal(19,2)
DECLARE @5_Docenti_contratto_ANNO_2_amm decimal(19,2)
DECLARE @6_Esperti_linguistici_ANNO_2_amm decimal(19,2)
DECLARE @7_Altro_personale_dedicato_alla_ricerca_didattica_ANNO_2_amm decimal(19,2)
DECLARE @8_Missioni_personale_dedicato_alla_didattica_ANNO_2_amm decimal(19,2)
DECLARE @9_Altri_oneri_personale_ANNO_2_amm decimal(19,2)
DECLARE @V_Acquisto_materiale_ANNO_2_amm decimal(19,2)
DECLARE @VI_Trasferimenti_ANNO_2_amm decimal(19,2)
DECLARE @VII_Altri_costi_specifici_ANNO_2_amm decimal(19,2)
DECLARE @COSTI_GENERALI_ANNO_2_amm decimal(19,2)
DECLARE @I_Personale_tecnicoamministrativo_ANNO_2_amm decimal(19,2)
DECLARE @II_Acquisto_materiali_ANNO_2_amm decimal(19,2)
DECLARE @III_Acquisto_libri_periodici_ANNO_2_amm decimal(19,2)
DECLARE @IV_Acquisto_servizi_ANNO_2_amm decimal(19,2)
DECLARE @V_Costi_godimento_beni_ANNO_2_amm decimal(19,2)
DECLARE @VI_Altri_costi_generali_ANNO_2_amm decimal(19,2)
DECLARE @1_Utenze_canoni_ANNO_2_amm decimal(19,2)
DECLARE @2_Manutenzione_ordinaria_ANNO_2_amm decimal(19,2)
DECLARE @3_Manutenzione_straordinaria_ANNO_2_amm decimal(19,2)
DECLARE @4_Altri_costi_generali_ANNO_2_amm decimal(19,2)
DECLARE @DIFFERENZA_PROVENTI_E_COSTI_OPERATIVI_ANNO_2_amm decimal(19,2)
DECLARE @AMMORTAMENTI_SVALUTAZIONI_ANNO_2_amm decimal(19,2)
DECLARE @ACCANTONAMENTI_RISCHI_ONERI_ANNO_2_amm decimal(19,2)
DECLARE @ALTRI_ACCANTONAMENTI_ANNO_2_amm decimal(19,2)
DECLARE @ONERI_DIVERSI_GESTIONE_ANNO_2_amm decimal(19,2)
DECLARE @I_Imposte_varie_ANNO_2_amm decimal(19,2)
DECLARE @II_Altri_oneri_ANNO_2_amm decimal(19,2)
DECLARE @III_Trasferimenti_correnti_ANNO_2_amm decimal(19,2)
DECLARE @IV_Trasferimenti_investimenti_ANNO_2_amm decimal(19,2)
DECLARE @PROVENTI_E_ONERI_FINANZIARI_ANNO_2_amm decimal(19,2)
DECLARE @proventi_ANNO_2_amm decimal(19,2)
DECLARE @oneri_ANNO_2_amm decimal(19,2)
DECLARE @RETTIFICHE_DI_VALORE_DI_ATTIVITA_FINANZIARIE_ANNO_2_amm decimal(19,2)
DECLARE @PROVENTI_ONERI_STRAORDINARI_ANNO_2_amm decimal(19,2)
DECLARE @1_PROVENTI_STRAORDINARI_ANNO_2_amm decimal(19,2)
DECLARE @2_ONERI_STRAORDINARI_ANNO_2_amm decimal(19,2)
DECLARE @IMPOSTE_TASSE_ANNO_2_amm decimal(19,2)
DECLARE @I_PROVENTI_PROPRI_ANNO_3_amm decimal(19,2)
DECLARE @II_CONTRIBUTI_ANNO_3_amm decimal(19,2)
DECLARE @III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE_ANNO_3_amm decimal(19,2)
DECLARE @IV_PROVENTI_PER_GESTIONE_DIRETTA_ANNO_3_amm decimal(19,2)
DECLARE @V_ALTRI_PROVENTI_ANNO_3_amm decimal(19,2)
DECLARE @VI_VARIAZIONE_LAVORI_IN_CORSO_ANNO_3_amm decimal(19,2)
DECLARE @VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI_ANNO_3_amm decimal(19,2)
DECLARE @PROVENTIOPERATIVI_ANNO_3_amm decimal(19,2)
DECLARE @COSTI_OPERATIVI_ANNO_3_amm decimal(19,2)
DECLARE @COSTI_SPECIFICI_ANNO_3_amm decimal(19,2)
DECLARE @I_SOSTEGNO_AGLI_STUDENTI_ANNO_3_amm decimal(19,2)
DECLARE @1_Interventi_favore_degli_studenti_ANNO_3_amm decimal(19,2)
DECLARE @2_Borse_di_studio_ANNO_3_amm decimal(19,2)
DECLARE @II_Interventi_diritto_allo_studio_ANNO_3_amm decimal(19,2)
DECLARE @III_Sostegno_alla_ricerca_ANNO_3_amm decimal(19,2)
DECLARE @IV_Personale_dedicato_alla_ricerca_ANNO_3_amm decimal(19,2)
DECLARE @1_Docenti_ANNO_3_amm decimal(19,2)
DECLARE @2_Ricercatori_ANNO_3_amm decimal(19,2)
DECLARE @3_Ricercatori_a_tempo_determinato_ANNO_3_amm decimal(19,2)
DECLARE @4_Collaborazioni_scientifiche_ANNO_3_amm decimal(19,2)
DECLARE @5_Docenti_contratto_ANNO_3_amm decimal(19,2)
DECLARE @6_Esperti_linguistici_ANNO_3_amm decimal(19,2)
DECLARE @7_Altro_personale_dedicato_alla_ricerca_didattica_ANNO_3_amm decimal(19,2)
DECLARE @8_Missioni_personale_dedicato_alla_didattica_ANNO_3_amm decimal(19,2)
DECLARE @9_Altri_oneri_personale_ANNO_3_amm decimal(19,2)
DECLARE @V_Acquisto_materiale_ANNO_3_amm decimal(19,2)
DECLARE @VI_Trasferimenti_ANNO_3_amm decimal(19,2)
DECLARE @VII_Altri_costi_specifici_ANNO_3_amm decimal(19,2)
DECLARE @COSTI_GENERALI_ANNO_3_amm decimal(19,2)
DECLARE @I_Personale_tecnicoamministrativo_ANNO_3_amm decimal(19,2)
DECLARE @II_Acquisto_materiali_ANNO_3_amm decimal(19,2)
DECLARE @III_Acquisto_libri_periodici_ANNO_3_amm decimal(19,2)
DECLARE @IV_Acquisto_servizi_ANNO_3_amm decimal(19,2)
DECLARE @V_Costi_godimento_beni_ANNO_3_amm decimal(19,2)
DECLARE @VI_Altri_costi_generali_ANNO_3_amm decimal(19,2)
DECLARE @1_Utenze_canoni_ANNO_3_amm decimal(19,2)
DECLARE @2_Manutenzione_ordinaria_ANNO_3_amm decimal(19,2)
DECLARE @3_Manutenzione_straordinaria_ANNO_3_amm decimal(19,2)
DECLARE @4_Altri_costi_generali_ANNO_3_amm decimal(19,2)
DECLARE @DIFFERENZA_PROVENTI_E_COSTI_OPERATIVI_ANNO_3_amm decimal(19,2)
DECLARE @AMMORTAMENTI_SVALUTAZIONI_ANNO_3_amm decimal(19,2)
DECLARE @ACCANTONAMENTI_RISCHI_ONERI_ANNO_3_amm decimal(19,2)
DECLARE @ALTRI_ACCANTONAMENTI_ANNO_3_amm decimal(19,2)
DECLARE @ONERI_DIVERSI_GESTIONE_ANNO_3_amm decimal(19,2)
DECLARE @I_Imposte_varie_ANNO_3_amm decimal(19,2)
DECLARE @II_Altri_oneri_ANNO_3_amm decimal(19,2)
DECLARE @III_Trasferimenti_correnti_ANNO_3_amm decimal(19,2)
DECLARE @IV_Trasferimenti_investimenti_ANNO_3_amm decimal(19,2)
DECLARE @PROVENTI_E_ONERI_FINANZIARI_ANNO_3_amm decimal(19,2)
DECLARE @proventi_ANNO_3_amm decimal(19,2)
DECLARE @oneri_ANNO_3_amm decimal(19,2)
DECLARE @RETTIFICHE_DI_VALORE_DI_ATTIVITA_FINANZIARIE_ANNO_3_amm decimal(19,2)
DECLARE @PROVENTI_ONERI_STRAORDINARI_ANNO_3_amm decimal(19,2)
DECLARE @1_PROVENTI_STRAORDINARI_ANNO_3_amm decimal(19,2)
DECLARE @2_ONERI_STRAORDINARI_ANNO_3_amm decimal(19,2)
DECLARE @IMPOSTE_TASSE_ANNO_3_amm decimal(19,2)



/*Dipartimenti*/

DECLARE @I_PROVENTI_PROPRI_dip decimal(19,2)
DECLARE @II_CONTRIBUTI_dip decimal(19,2)
DECLARE @III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE_dip decimal(19,2)
DECLARE @IV_PROVENTI_PER_GESTIONE_DIRETTA_dip decimal(19,2)
DECLARE @V_ALTRI_PROVENTI_dip decimal(19,2)
DECLARE @VI_VARIAZIONE_LAVORI_IN_CORSO_dip decimal(19,2)
DECLARE @VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI_dip decimal(19,2)
DECLARE @PROVENTIOPERATIVI_dip decimal(19,2)
DECLARE @COSTI_OPERATIVI_dip decimal(19,2)
DECLARE @COSTI_SPECIFICI_dip decimal(19,2)
DECLARE @I_SOSTEGNO_AGLI_STUDENTI_dip decimal(19,2)
DECLARE @1_Interventi_favore_degli_studenti_dip decimal(19,2)
DECLARE @2_Borse_di_studio_dip decimal(19,2)
DECLARE @II_Interventi_diritto_allo_studio_dip decimal(19,2)
DECLARE @III_Sostegno_alla_ricerca_dip decimal(19,2)
DECLARE @IV_Personale_dedicato_alla_ricerca_dip decimal(19,2)
DECLARE @1_Docenti_dip decimal(19,2)
DECLARE @2_Ricercatori_dip decimal(19,2)
DECLARE @3_Ricercatori_a_tempo_determinato_dip decimal(19,2)
DECLARE @4_Collaborazioni_scientifiche_dip decimal(19,2)
DECLARE @5_Docenti_contratto_dip decimal(19,2)
DECLARE @6_Esperti_linguistici_dip decimal(19,2)
DECLARE @7_Altro_personale_dedicato_alla_ricerca_didattica_dip decimal(19,2)
DECLARE @8_Missioni_personale_dedicato_alla_didattica_dip decimal(19,2)
DECLARE @9_Altri_oneri_personale_dip decimal(19,2)
DECLARE @V_Acquisto_materiale_dip decimal(19,2)
DECLARE @VI_Trasferimenti_dip decimal(19,2)
DECLARE @VII_Altri_costi_specifici_dip decimal(19,2)
DECLARE @COSTI_GENERALI_dip decimal(19,2)
DECLARE @I_Personale_tecnicoamministrativo_dip decimal(19,2)
DECLARE @II_Acquisto_materiali_dip decimal(19,2)
DECLARE @III_Acquisto_libri_periodici_dip decimal(19,2)
DECLARE @IV_Acquisto_servizi_dip decimal(19,2)
DECLARE @V_Costi_godimento_beni_dip decimal(19,2)
DECLARE @VI_Altri_costi_generali_dip decimal(19,2)
DECLARE @1_Utenze_canoni_dip decimal(19,2)
DECLARE @2_Manutenzione_ordinaria_dip decimal(19,2)
DECLARE @3_Manutenzione_straordinaria_dip decimal(19,2)
DECLARE @4_Altri_costi_generali_dip decimal(19,2)
DECLARE @DIFFERENZA_PROVENTI_E_COSTI_OPERATIVI_dip decimal(19,2)
DECLARE @AMMORTAMENTI_SVALUTAZIONI_dip decimal(19,2)
DECLARE @ACCANTONAMENTI_RISCHI_ONERI_dip decimal(19,2)
DECLARE @ALTRI_ACCANTONAMENTI_dip decimal(19,2)
DECLARE @ONERI_DIVERSI_GESTIONE_dip decimal(19,2)
DECLARE @I_Imposte_varie_dip decimal(19,2)
DECLARE @II_Altri_oneri_dip decimal(19,2)
DECLARE @III_Trasferimenti_correnti_dip decimal(19,2)
DECLARE @IV_Trasferimenti_investimenti_dip decimal(19,2)
DECLARE @PROVENTI_E_ONERI_FINANZIARI_dip decimal(19,2)
DECLARE @proventi_dip decimal(19,2)
DECLARE @oneri_dip decimal(19,2)
DECLARE @RETTIFICHE_DI_VALORE_DI_ATTIVITA_FINANZIARIE_dip decimal(19,2)
DECLARE @PROVENTI_ONERI_STRAORDINARI_dip decimal(19,2)
DECLARE @1_PROVENTI_STRAORDINARI_dip decimal(19,2)
DECLARE @2_ONERI_STRAORDINARI_dip decimal(19,2)
DECLARE @IMPOSTE_TASSE_dip decimal(19,2)
DECLARE @I_PROVENTI_PROPRI_ANNO_2_dip decimal(19,2)
DECLARE @II_CONTRIBUTI_ANNO_2_dip decimal(19,2)
DECLARE @III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE_ANNO_2_dip decimal(19,2)
DECLARE @IV_PROVENTI_PER_GESTIONE_DIRETTA_ANNO_2_dip decimal(19,2)
DECLARE @V_ALTRI_PROVENTI_ANNO_2_dip decimal(19,2)
DECLARE @VI_VARIAZIONE_LAVORI_IN_CORSO_ANNO_2_dip decimal(19,2)
DECLARE @VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI_ANNO_2_dip decimal(19,2)
DECLARE @PROVENTIOPERATIVI_ANNO_2_dip decimal(19,2)
DECLARE @COSTI_OPERATIVI_ANNO_2_dip decimal(19,2)
DECLARE @COSTI_SPECIFICI_ANNO_2_dip decimal(19,2)
DECLARE @I_SOSTEGNO_AGLI_STUDENTI_ANNO_2_dip decimal(19,2)
DECLARE @1_Interventi_favore_degli_studenti_ANNO_2_dip decimal(19,2)
DECLARE @2_Borse_di_studio_ANNO_2_dip decimal(19,2)
DECLARE @II_Interventi_diritto_allo_studio_ANNO_2_dip decimal(19,2)
DECLARE @III_Sostegno_alla_ricerca_ANNO_2_dip decimal(19,2)
DECLARE @IV_Personale_dedicato_alla_ricerca_ANNO_2_dip decimal(19,2)
DECLARE @1_Docenti_ANNO_2_dip decimal(19,2)
DECLARE @2_Ricercatori_ANNO_2_dip decimal(19,2)
DECLARE @3_Ricercatori_a_tempo_determinato_ANNO_2_dip decimal(19,2)
DECLARE @4_Collaborazioni_scientifiche_ANNO_2_dip decimal(19,2)
DECLARE @5_Docenti_contratto_ANNO_2_dip decimal(19,2)
DECLARE @6_Esperti_linguistici_ANNO_2_dip decimal(19,2)
DECLARE @7_Altro_personale_dedicato_alla_ricerca_didattica_ANNO_2_dip decimal(19,2)
DECLARE @8_Missioni_personale_dedicato_alla_didattica_ANNO_2_dip decimal(19,2)
DECLARE @9_Altri_oneri_personale_ANNO_2_dip decimal(19,2)
DECLARE @V_Acquisto_materiale_ANNO_2_dip decimal(19,2)
DECLARE @VI_Trasferimenti_ANNO_2_dip decimal(19,2)
DECLARE @VII_Altri_costi_specifici_ANNO_2_dip decimal(19,2)
DECLARE @COSTI_GENERALI_ANNO_2_dip decimal(19,2)
DECLARE @I_Personale_tecnicoamministrativo_ANNO_2_dip decimal(19,2)
DECLARE @II_Acquisto_materiali_ANNO_2_dip decimal(19,2)
DECLARE @III_Acquisto_libri_periodici_ANNO_2_dip decimal(19,2)
DECLARE @IV_Acquisto_servizi_ANNO_2_dip decimal(19,2)
DECLARE @V_Costi_godimento_beni_ANNO_2_dip decimal(19,2)
DECLARE @VI_Altri_costi_generali_ANNO_2_dip decimal(19,2)
DECLARE @1_Utenze_canoni_ANNO_2_dip decimal(19,2)
DECLARE @2_Manutenzione_ordinaria_ANNO_2_dip decimal(19,2)
DECLARE @3_Manutenzione_straordinaria_ANNO_2_dip decimal(19,2)
DECLARE @4_Altri_costi_generali_ANNO_2_dip decimal(19,2)
DECLARE @DIFFERENZA_PROVENTI_E_COSTI_OPERATIVI_ANNO_2_dip decimal(19,2)
DECLARE @AMMORTAMENTI_SVALUTAZIONI_ANNO_2_dip decimal(19,2)
DECLARE @ACCANTONAMENTI_RISCHI_ONERI_ANNO_2_dip decimal(19,2)
DECLARE @ALTRI_ACCANTONAMENTI_ANNO_2_dip decimal(19,2)
DECLARE @ONERI_DIVERSI_GESTIONE_ANNO_2_dip decimal(19,2)
DECLARE @I_Imposte_varie_ANNO_2_dip decimal(19,2)
DECLARE @II_Altri_oneri_ANNO_2_dip decimal(19,2)
DECLARE @III_Trasferimenti_correnti_ANNO_2_dip decimal(19,2)
DECLARE @IV_Trasferimenti_investimenti_ANNO_2_dip decimal(19,2)
DECLARE @PROVENTI_E_ONERI_FINANZIARI_ANNO_2_dip decimal(19,2)
DECLARE @proventi_ANNO_2_dip decimal(19,2)
DECLARE @oneri_ANNO_2_dip decimal(19,2)
DECLARE @RETTIFICHE_DI_VALORE_DI_ATTIVITA_FINANZIARIE_ANNO_2_dip decimal(19,2)
DECLARE @PROVENTI_ONERI_STRAORDINARI_ANNO_2_dip decimal(19,2)
DECLARE @1_PROVENTI_STRAORDINARI_ANNO_2_dip decimal(19,2)
DECLARE @2_ONERI_STRAORDINARI_ANNO_2_dip decimal(19,2)
DECLARE @IMPOSTE_TASSE_ANNO_2_dip decimal(19,2)
DECLARE @I_PROVENTI_PROPRI_ANNO_3_dip decimal(19,2)
DECLARE @II_CONTRIBUTI_ANNO_3_dip decimal(19,2)
DECLARE @III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE_ANNO_3_dip decimal(19,2)
DECLARE @IV_PROVENTI_PER_GESTIONE_DIRETTA_ANNO_3_dip decimal(19,2)
DECLARE @V_ALTRI_PROVENTI_ANNO_3_dip decimal(19,2)
DECLARE @VI_VARIAZIONE_LAVORI_IN_CORSO_ANNO_3_dip decimal(19,2)
DECLARE @VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI_ANNO_3_dip decimal(19,2)
DECLARE @PROVENTIOPERATIVI_ANNO_3_dip decimal(19,2)
DECLARE @COSTI_OPERATIVI_ANNO_3_dip decimal(19,2)
DECLARE @COSTI_SPECIFICI_ANNO_3_dip decimal(19,2)
DECLARE @I_SOSTEGNO_AGLI_STUDENTI_ANNO_3_dip decimal(19,2)
DECLARE @1_Interventi_favore_degli_studenti_ANNO_3_dip decimal(19,2)
DECLARE @2_Borse_di_studio_ANNO_3_dip decimal(19,2)
DECLARE @II_Interventi_diritto_allo_studio_ANNO_3_dip decimal(19,2)
DECLARE @III_Sostegno_alla_ricerca_ANNO_3_dip decimal(19,2)
DECLARE @IV_Personale_dedicato_alla_ricerca_ANNO_3_dip decimal(19,2)
DECLARE @1_Docenti_ANNO_3_dip decimal(19,2)
DECLARE @2_Ricercatori_ANNO_3_dip decimal(19,2)
DECLARE @3_Ricercatori_a_tempo_determinato_ANNO_3_dip decimal(19,2)
DECLARE @4_Collaborazioni_scientifiche_ANNO_3_dip decimal(19,2)
DECLARE @5_Docenti_contratto_ANNO_3_dip decimal(19,2)
DECLARE @6_Esperti_linguistici_ANNO_3_dip decimal(19,2)
DECLARE @7_Altro_personale_dedicato_alla_ricerca_didattica_ANNO_3_dip decimal(19,2)
DECLARE @8_Missioni_personale_dedicato_alla_didattica_ANNO_3_dip decimal(19,2)
DECLARE @9_Altri_oneri_personale_ANNO_3_dip decimal(19,2)
DECLARE @V_Acquisto_materiale_ANNO_3_dip decimal(19,2)
DECLARE @VI_Trasferimenti_ANNO_3_dip decimal(19,2)
DECLARE @VII_Altri_costi_specifici_ANNO_3_dip decimal(19,2)
DECLARE @COSTI_GENERALI_ANNO_3_dip decimal(19,2)
DECLARE @I_Personale_tecnicoamministrativo_ANNO_3_dip decimal(19,2)
DECLARE @II_Acquisto_materiali_ANNO_3_dip decimal(19,2)
DECLARE @III_Acquisto_libri_periodici_ANNO_3_dip decimal(19,2)
DECLARE @IV_Acquisto_servizi_ANNO_3_dip decimal(19,2)
DECLARE @V_Costi_godimento_beni_ANNO_3_dip decimal(19,2)
DECLARE @VI_Altri_costi_generali_ANNO_3_dip decimal(19,2)
DECLARE @1_Utenze_canoni_ANNO_3_dip decimal(19,2)
DECLARE @2_Manutenzione_ordinaria_ANNO_3_dip decimal(19,2)
DECLARE @3_Manutenzione_straordinaria_ANNO_3_dip decimal(19,2)
DECLARE @4_Altri_costi_generali_ANNO_3_dip decimal(19,2)
DECLARE @DIFFERENZA_PROVENTI_E_COSTI_OPERATIVI_ANNO_3_dip decimal(19,2)
DECLARE @AMMORTAMENTI_SVALUTAZIONI_ANNO_3_dip decimal(19,2)
DECLARE @ACCANTONAMENTI_RISCHI_ONERI_ANNO_3_dip decimal(19,2)
DECLARE @ALTRI_ACCANTONAMENTI_ANNO_3_dip decimal(19,2)
DECLARE @ONERI_DIVERSI_GESTIONE_ANNO_3_dip decimal(19,2)
DECLARE @I_Imposte_varie_ANNO_3_dip decimal(19,2)
DECLARE @II_Altri_oneri_ANNO_3_dip decimal(19,2)
DECLARE @III_Trasferimenti_correnti_ANNO_3_dip decimal(19,2)
DECLARE @IV_Trasferimenti_investimenti_ANNO_3_dip decimal(19,2)
DECLARE @PROVENTI_E_ONERI_FINANZIARI_ANNO_3_dip decimal(19,2)
DECLARE @proventi_ANNO_3_dip decimal(19,2)
DECLARE @oneri_ANNO_3_dip decimal(19,2)
DECLARE @RETTIFICHE_DI_VALORE_DI_ATTIVITA_FINANZIARIE_ANNO_3_dip decimal(19,2)
DECLARE @PROVENTI_ONERI_STRAORDINARI_ANNO_3_dip decimal(19,2)
DECLARE @1_PROVENTI_STRAORDINARI_ANNO_3_dip decimal(19,2)
DECLARE @2_ONERI_STRAORDINARI_ANNO_3_dip decimal(19,2)
DECLARE @IMPOSTE_TASSE_ANNO_3_dip decimal(19,2)
DECLARE @I_PROVENTI_PROPRI_ANNO_2 decimal(19,2)
DECLARE @II_CONTRIBUTI_ANNO_2 decimal(19,2)
DECLARE @III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE_ANNO_2 decimal(19,2)
DECLARE @IV_PROVENTI_PER_GESTIONE_DIRETTA_ANNO_2 decimal(19,2)
DECLARE @V_ALTRI_PROVENTI_ANNO_2 decimal(19,2)
DECLARE @VI_VARIAZIONE_LAVORI_IN_CORSO_ANNO_2 decimal(19,2)
DECLARE @VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI_ANNO_2 decimal(19,2)
DECLARE @PROVENTIOPERATIVI_ANNO_2 decimal(19,2)
DECLARE @COSTI_OPERATIVI_ANNO_2 decimal(19,2)
DECLARE @COSTI_SPECIFICI_ANNO_2 decimal(19,2)
DECLARE @I_SOSTEGNO_AGLI_STUDENTI_ANNO_2 decimal(19,2)
DECLARE @1_Interventi_favore_degli_studenti_ANNO_2 decimal(19,2)
DECLARE @2_Borse_di_studio_ANNO_2 decimal(19,2)
DECLARE @II_Interventi_diritto_allo_studio_ANNO_2 decimal(19,2)
DECLARE @III_Sostegno_alla_ricerca_ANNO_2 decimal(19,2)
DECLARE @IV_Personale_dedicato_alla_ricerca_ANNO_2 decimal(19,2)
DECLARE @1_Docenti_ANNO_2 decimal(19,2)
DECLARE @2_Ricercatori_ANNO_2 decimal(19,2)
DECLARE @3_Ricercatori_a_tempo_determinato_ANNO_2 decimal(19,2)
DECLARE @4_Collaborazioni_scientifiche_ANNO_2 decimal(19,2)
DECLARE @5_Docenti_contratto_ANNO_2 decimal(19,2)
DECLARE @6_Esperti_linguistici_ANNO_2 decimal(19,2)
DECLARE @7_Altro_personale_dedicato_alla_ricerca_didattica_ANNO_2 decimal(19,2)
DECLARE @8_Missioni_personale_dedicato_alla_didattica_ANNO_2 decimal(19,2)
DECLARE @9_Altri_oneri_personale_ANNO_2 decimal(19,2)
DECLARE @V_Acquisto_materiale_ANNO_2 decimal(19,2)
DECLARE @VI_Trasferimenti_ANNO_2 decimal(19,2)
DECLARE @VII_Altri_costi_specifici_ANNO_2 decimal(19,2)
DECLARE @COSTI_GENERALI_ANNO_2 decimal(19,2)
DECLARE @I_Personale_tecnicoamministrativo_ANNO_2 decimal(19,2)
DECLARE @II_Acquisto_materiali_ANNO_2 decimal(19,2)
DECLARE @III_Acquisto_libri_periodici_ANNO_2 decimal(19,2)
DECLARE @IV_Acquisto_servizi_ANNO_2 decimal(19,2)
DECLARE @V_Costi_godimento_beni_ANNO_2 decimal(19,2)
DECLARE @VI_Altri_costi_generali_ANNO_2 decimal(19,2)
DECLARE @1_Utenze_canoni_ANNO_2 decimal(19,2)
DECLARE @2_Manutenzione_ordinaria_ANNO_2 decimal(19,2)
DECLARE @3_Manutenzione_straordinaria_ANNO_2 decimal(19,2)
DECLARE @4_Altri_costi_generali_ANNO_2 decimal(19,2)
DECLARE @DIFFERENZA_PROVENTI_E_COSTI_OPERATIVI_ANNO_2 decimal(19,2)
DECLARE @AMMORTAMENTI_SVALUTAZIONI_ANNO_2 decimal(19,2)
DECLARE @ACCANTONAMENTI_RISCHI_ONERI_ANNO_2 decimal(19,2)
DECLARE @ALTRI_ACCANTONAMENTI_ANNO_2 decimal(19,2)
DECLARE @ONERI_DIVERSI_GESTIONE_ANNO_2 decimal(19,2)
DECLARE @I_Imposte_varie_ANNO_2 decimal(19,2)
DECLARE @II_Altri_oneri_ANNO_2 decimal(19,2)
DECLARE @III_Trasferimenti_correnti_ANNO_2 decimal(19,2)
DECLARE @IV_Trasferimenti_investimenti_ANNO_2 decimal(19,2)
DECLARE @PROVENTI_E_ONERI_FINANZIARI_ANNO_2 decimal(19,2)
DECLARE @proventi_ANNO_2 decimal(19,2)
DECLARE @oneri_ANNO_2 decimal(19,2)
DECLARE @RETTIFICHE_DI_VALORE_DI_ATTIVITA_FINANZIARIE_ANNO_2 decimal(19,2)
DECLARE @PROVENTI_ONERI_STRAORDINARI_ANNO_2 decimal(19,2)
DECLARE @1_PROVENTI_STRAORDINARI_ANNO_2 decimal(19,2)
DECLARE @2_ONERI_STRAORDINARI_ANNO_2 decimal(19,2)
DECLARE @IMPOSTE_TASSE_ANNO_2 decimal(19,2)
DECLARE @I_PROVENTI_PROPRI_ANNO_3 decimal(19,2)
DECLARE @II_CONTRIBUTI_ANNO_3 decimal(19,2)
DECLARE @III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE_ANNO_3 decimal(19,2)
DECLARE @IV_PROVENTI_PER_GESTIONE_DIRETTA_ANNO_3 decimal(19,2)
DECLARE @V_ALTRI_PROVENTI_ANNO_3 decimal(19,2)
DECLARE @VI_VARIAZIONE_LAVORI_IN_CORSO_ANNO_3 decimal(19,2)
DECLARE @VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI_ANNO_3 decimal(19,2)
DECLARE @PROVENTIOPERATIVI_ANNO_3 decimal(19,2)
DECLARE @COSTI_OPERATIVI_ANNO_3 decimal(19,2)
DECLARE @COSTI_SPECIFICI_ANNO_3 decimal(19,2)
DECLARE @I_SOSTEGNO_AGLI_STUDENTI_ANNO_3 decimal(19,2)
DECLARE @1_Interventi_favore_degli_studenti_ANNO_3 decimal(19,2)
DECLARE @2_Borse_di_studio_ANNO_3 decimal(19,2)
DECLARE @II_Interventi_diritto_allo_studio_ANNO_3 decimal(19,2)
DECLARE @III_Sostegno_alla_ricerca_ANNO_3 decimal(19,2)
DECLARE @IV_Personale_dedicato_alla_ricerca_ANNO_3 decimal(19,2)
DECLARE @1_Docenti_ANNO_3 decimal(19,2)
DECLARE @2_Ricercatori_ANNO_3 decimal(19,2)
DECLARE @3_Ricercatori_a_tempo_determinato_ANNO_3 decimal(19,2)
DECLARE @4_Collaborazioni_scientifiche_ANNO_3 decimal(19,2)
DECLARE @5_Docenti_contratto_ANNO_3 decimal(19,2)
DECLARE @6_Esperti_linguistici_ANNO_3 decimal(19,2)
DECLARE @7_Altro_personale_dedicato_alla_ricerca_didattica_ANNO_3 decimal(19,2)
DECLARE @8_Missioni_personale_dedicato_alla_didattica_ANNO_3 decimal(19,2)
DECLARE @9_Altri_oneri_personale_ANNO_3 decimal(19,2)
DECLARE @V_Acquisto_materiale_ANNO_3 decimal(19,2)
DECLARE @VI_Trasferimenti_ANNO_3 decimal(19,2)
DECLARE @VII_Altri_costi_specifici_ANNO_3 decimal(19,2)
DECLARE @COSTI_GENERALI_ANNO_3 decimal(19,2)
DECLARE @I_Personale_tecnicoamministrativo_ANNO_3 decimal(19,2)
DECLARE @II_Acquisto_materiali_ANNO_3 decimal(19,2)
DECLARE @III_Acquisto_libri_periodici_ANNO_3 decimal(19,2)
DECLARE @IV_Acquisto_servizi_ANNO_3 decimal(19,2)
DECLARE @V_Costi_godimento_beni_ANNO_3 decimal(19,2)
DECLARE @VI_Altri_costi_generali_ANNO_3 decimal(19,2)
DECLARE @1_Utenze_canoni_ANNO_3 decimal(19,2)
DECLARE @2_Manutenzione_ordinaria_ANNO_3 decimal(19,2)
DECLARE @3_Manutenzione_straordinaria_ANNO_3 decimal(19,2)
DECLARE @4_Altri_costi_generali_ANNO_3 decimal(19,2)
DECLARE @DIFFERENZA_PROVENTI_E_COSTI_OPERATIVI_ANNO_3 decimal(19,2)
DECLARE @AMMORTAMENTI_SVALUTAZIONI_ANNO_3 decimal(19,2)
DECLARE @ACCANTONAMENTI_RISCHI_ONERI_ANNO_3 decimal(19,2)
DECLARE @ALTRI_ACCANTONAMENTI_ANNO_3 decimal(19,2)
DECLARE @ONERI_DIVERSI_GESTIONE_ANNO_3 decimal(19,2)
DECLARE @I_Imposte_varie_ANNO_3 decimal(19,2)
DECLARE @II_Altri_oneri_ANNO_3 decimal(19,2)
DECLARE @III_Trasferimenti_correnti_ANNO_3 decimal(19,2)
DECLARE @IV_Trasferimenti_investimenti_ANNO_3 decimal(19,2)
DECLARE @PROVENTI_E_ONERI_FINANZIARI_ANNO_3 decimal(19,2)
DECLARE @proventi_ANNO_3 decimal(19,2)
DECLARE @oneri_ANNO_3 decimal(19,2)
DECLARE @RETTIFICHE_DI_VALORE_DI_ATTIVITA_FINANZIARIE_ANNO_3 decimal(19,2)
DECLARE @PROVENTI_ONERI_STRAORDINARI_ANNO_3 decimal(19,2)
DECLARE @1_PROVENTI_STRAORDINARI_ANNO_3 decimal(19,2)
DECLARE @2_ONERI_STRAORDINARI_ANNO_3 decimal(19,2)
DECLARE @IMPOSTE_TASSE_ANNO_3 decimal(19,2)

/*Totali*/
DECLARE @I_PROVENTI_PROPRI decimal(19,2)
DECLARE @II_CONTRIBUTI decimal(19,2)
DECLARE @III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE decimal(19,2)
DECLARE @IV_PROVENTI_PER_GESTIONE_DIRETTA decimal(19,2)
DECLARE @V_ALTRI_PROVENTI decimal(19,2)
DECLARE @VI_VARIAZIONE_LAVORI_IN_CORSO decimal(19,2)
DECLARE @VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI decimal(19,2)
DECLARE @PROVENTIOPERATIVI decimal(19,2)
DECLARE @COSTI_OPERATIVI decimal(19,2)
DECLARE @COSTI_SPECIFICI decimal(19,2)
DECLARE @I_SOSTEGNO_AGLI_STUDENTI decimal(19,2)
DECLARE @1_Interventi_favore_degli_studenti decimal(19,2)
DECLARE @2_Borse_di_studio decimal(19,2)
DECLARE @II_Interventi_diritto_allo_studio decimal(19,2)
DECLARE @III_Sostegno_alla_ricerca decimal(19,2)
DECLARE @IV_Personale_dedicato_alla_ricerca decimal(19,2)
DECLARE @1_Docenti decimal(19,2)
DECLARE @2_Ricercatori decimal(19,2)
DECLARE @3_Ricercatori_a_tempo_determinato decimal(19,2)
DECLARE @4_Collaborazioni_scientifiche decimal(19,2)
DECLARE @5_Docenti_contratto decimal(19,2)
DECLARE @6_Esperti_linguistici decimal(19,2)
DECLARE @7_Altro_personale_dedicato_alla_ricerca_didattica decimal(19,2)
DECLARE @8_Missioni_personale_dedicato_alla_didattica decimal(19,2)
DECLARE @9_Altri_oneri_personale decimal(19,2)
DECLARE @V_Acquisto_materiale decimal(19,2)
DECLARE @VI_Trasferimenti decimal(19,2)
DECLARE @VII_Altri_costi_specifici decimal(19,2)
DECLARE @COSTI_GENERALI decimal(19,2)
DECLARE @I_Personale_tecnicoamministrativo decimal(19,2)
DECLARE @II_Acquisto_materiali decimal(19,2)
DECLARE @III_Acquisto_libri_periodici decimal(19,2)
DECLARE @IV_Acquisto_servizi decimal(19,2)
DECLARE @V_Costi_godimento_beni decimal(19,2)
DECLARE @VI_Altri_costi_generali decimal(19,2)
DECLARE @1_Utenze_canoni decimal(19,2)
DECLARE @2_Manutenzione_ordinaria decimal(19,2)
DECLARE @3_Manutenzione_straordinaria decimal(19,2)
DECLARE @4_Altri_costi_generali decimal(19,2)
DECLARE @DIFFERENZA_PROVENTI_E_COSTI_OPERATIVI decimal(19,2)
DECLARE @AMMORTAMENTI_SVALUTAZIONI decimal(19,2)
DECLARE @ACCANTONAMENTI_RISCHI_ONERI decimal(19,2)
DECLARE @ALTRI_ACCANTONAMENTI decimal(19,2)
DECLARE @ONERI_DIVERSI_GESTIONE decimal(19,2)
DECLARE @I_Imposte_varie decimal(19,2)
DECLARE @II_Altri_oneri decimal(19,2)
DECLARE @III_Trasferimenti_correnti decimal(19,2)
DECLARE @IV_Trasferimenti_investimenti decimal(19,2)
DECLARE @PROVENTI_E_ONERI_FINANZIARI decimal(19,2)
DECLARE @proventi decimal(19,2)
DECLARE @oneri decimal(19,2)
DECLARE @RETTIFICHE_DI_VALORE_DI_ATTIVITA_FINANZIARIE decimal(19,2)
DECLARE @PROVENTI_ONERI_STRAORDINARI decimal(19,2)
DECLARE @1_PROVENTI_STRAORDINARI decimal(19,2)
DECLARE @2_ONERI_STRAORDINARI decimal(19,2)
DECLARE @IMPOSTE_TASSE decimal(19,2)

/* AMMINISTRAZIONE */ 
SET @I_PROVENTI_PROPRI_amm =	ISNULL((select [I_PROVENTI_PROPRI_amm] from #DATI_AMM),0)
SET @II_CONTRIBUTI_amm =	ISNULL((select [II_CONTRIBUTI_amm] from #DATI_AMM),0)
SET @III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE_amm =	ISNULL((select [III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE_amm] from #DATI_AMM),0)
SET @IV_PROVENTI_PER_GESTIONE_DIRETTA_amm =	ISNULL((select [IV_PROVENTI_PER_GESTIONE_DIRETTA_amm] from #DATI_AMM),0)
SET @V_ALTRI_PROVENTI_amm =	ISNULL((select [V_ALTRI_PROVENTI_amm] from #DATI_AMM),0)
SET @VI_VARIAZIONE_LAVORI_IN_CORSO_amm =	ISNULL((select [VI_VARIAZIONE_LAVORI_IN_CORSO_amm] from #DATI_AMM),0)
SET @VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI_amm =	ISNULL((select [VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI_amm] from #DATI_AMM),0)
SET @PROVENTIOPERATIVI_amm =	ISNULL((select [PROVENTIOPERATIVI_amm] from #DATI_AMM),0)
SET @COSTI_OPERATIVI_amm =	ISNULL((select [COSTI_OPERATIVI_amm] from #DATI_AMM),0)
SET @COSTI_SPECIFICI_amm =	ISNULL((select [COSTI_SPECIFICI_amm] from #DATI_AMM),0)
SET @I_SOSTEGNO_AGLI_STUDENTI_amm =	ISNULL((select [I_SOSTEGNO_AGLI_STUDENTI_amm] from #DATI_AMM),0)
SET @1_Interventi_favore_degli_studenti_amm =	ISNULL((select [1_Interventi_favore_degli_studenti_amm] from #DATI_AMM),0)
SET @2_Borse_di_studio_amm =	ISNULL((select [2_Borse_di_studio_amm] from #DATI_AMM),0)
SET @II_Interventi_diritto_allo_studio_amm =	ISNULL((select [II_Interventi_diritto_allo_studio_amm] from #DATI_AMM),0)
SET @III_Sostegno_alla_ricerca_amm =	ISNULL((select [III_Sostegno_alla_ricerca_amm] from #DATI_AMM),0)
SET @IV_Personale_dedicato_alla_ricerca_amm =	ISNULL((select [IV_Personale_dedicato_alla_ricerca_amm] from #DATI_AMM),0)
SET @1_Docenti_amm =	ISNULL((select [1_Docenti_amm] from #DATI_AMM),0)
SET @2_Ricercatori_amm =	ISNULL((select [2_Ricercatori_amm] from #DATI_AMM),0)
SET @3_Ricercatori_a_tempo_determinato_amm =	ISNULL((select [3_Ricercatori_a_tempo_determinato_amm] from #DATI_AMM),0)
SET @4_Collaborazioni_scientifiche_amm =	ISNULL((select [4_Collaborazioni_scientifiche_amm] from #DATI_AMM),0)
SET @5_Docenti_contratto_amm =	ISNULL((select [5_Docenti_contratto_amm] from #DATI_AMM),0)
SET @6_Esperti_linguistici_amm =	ISNULL((select [6_Esperti_linguistici_amm] from #DATI_AMM),0)
SET @7_Altro_personale_dedicato_alla_ricerca_didattica_amm =	ISNULL((select [7_Altro_personale_dedicato_alla_ricerca_didattica_amm] from #DATI_AMM),0)
SET @8_Missioni_personale_dedicato_alla_didattica_amm =	ISNULL((select [8_Missioni_personale_dedicato_alla_didattica_amm] from #DATI_AMM),0)
SET @9_Altri_oneri_personale_amm =	ISNULL((select [9_Altri_oneri_personale_amm] from #DATI_AMM),0)
SET @V_Acquisto_materiale_amm =	ISNULL((select [V_Acquisto_materiale_amm] from #DATI_AMM),0)
SET @VI_Trasferimenti_amm =	ISNULL((select [VI_Trasferimenti_amm] from #DATI_AMM),0)
SET @VII_Altri_costi_specifici_amm =	ISNULL((select [VII_Altri_costi_specifici_amm] from #DATI_AMM),0)
SET @COSTI_GENERALI_amm =	ISNULL((select [COSTI_GENERALI_amm] from #DATI_AMM),0)
SET @I_Personale_tecnicoamministrativo_amm =	ISNULL((select [I_Personale_tecnicoamministrativo_amm] from #DATI_AMM),0)
SET @II_Acquisto_materiali_amm =	ISNULL((select [II_Acquisto_materiali_amm] from #DATI_AMM),0)
SET @III_Acquisto_libri_periodici_amm =	ISNULL((select [III_Acquisto_libri_periodici_amm] from #DATI_AMM),0)
SET @IV_Acquisto_servizi_amm =	ISNULL((select [IV_Acquisto_servizi_amm] from #DATI_AMM),0)
SET @V_Costi_godimento_beni_amm =	ISNULL((select [V_Costi_godimento_beni_amm] from #DATI_AMM),0)
SET @VI_Altri_costi_generali_amm =	ISNULL((select [VI_Altri_costi_generali_amm] from #DATI_AMM),0)
SET @1_Utenze_canoni_amm =	ISNULL((select [1_Utenze_canoni_amm] from #DATI_AMM),0)
SET @2_Manutenzione_ordinaria_amm =	ISNULL((select [2_Manutenzione_ordinaria_amm] from #DATI_AMM),0)
SET @3_Manutenzione_straordinaria_amm =	ISNULL((select [3_Manutenzione_straordinaria_amm] from #DATI_AMM),0)
SET @4_Altri_costi_generali_amm =	ISNULL((select [4_Altri_costi_generali_amm] from #DATI_AMM),0)
SET @DIFFERENZA_PROVENTI_E_COSTI_OPERATIVI_amm =	ISNULL((select [DIFFERENZA_PROVENTI_E_COSTI_OPERATIVI_amm] from #DATI_AMM),0)
SET @AMMORTAMENTI_SVALUTAZIONI_amm =	ISNULL((select [AMMORTAMENTI_SVALUTAZIONI_amm] from #DATI_AMM),0)
SET @ACCANTONAMENTI_RISCHI_ONERI_amm =	ISNULL((select [ACCANTONAMENTI_RISCHI_ONERI_amm] from #DATI_AMM),0)
SET @ALTRI_ACCANTONAMENTI_amm =	ISNULL((select [ALTRI_ACCANTONAMENTI_amm] from #DATI_AMM),0)
SET @ONERI_DIVERSI_GESTIONE_amm =	ISNULL((select [ONERI_DIVERSI_GESTIONE_amm] from #DATI_AMM),0)
SET @I_Imposte_varie_amm =	ISNULL((select [I_Imposte_varie_amm] from #DATI_AMM),0)
SET @II_Altri_oneri_amm =	ISNULL((select [II_Altri_oneri_amm] from #DATI_AMM),0)
SET @III_Trasferimenti_correnti_amm =	ISNULL((select [III_Trasferimenti_correnti_amm] from #DATI_AMM),0)
SET @IV_Trasferimenti_investimenti_amm =	ISNULL((select [IV_Trasferimenti_investimenti_amm] from #DATI_AMM),0)
SET @PROVENTI_E_ONERI_FINANZIARI_amm =	ISNULL((select [PROVENTI_E_ONERI_FINANZIARI_amm] from #DATI_AMM),0)
SET @proventi_amm =	ISNULL((select [proventi_amm] from #DATI_AMM),0)
SET @oneri_amm =	ISNULL((select [oneri_amm] from #DATI_AMM),0)
SET @RETTIFICHE_DI_VALORE_DI_ATTIVITA_FINANZIARIE_amm =	ISNULL((select [RETTIFICHE_DI_VALORE_DI_ATTIVITA_FINANZIARIE_amm] from #DATI_AMM),0)
SET @PROVENTI_ONERI_STRAORDINARI_amm =	ISNULL((select [PROVENTI_ONERI_STRAORDINARI_amm] from #DATI_AMM),0)
SET @1_PROVENTI_STRAORDINARI_amm =	ISNULL((select [1_PROVENTI_STRAORDINARI_amm] from #DATI_AMM),0)
SET @2_ONERI_STRAORDINARI_amm =	ISNULL((select [2_ONERI_STRAORDINARI_amm] from #DATI_AMM),0)
SET @IMPOSTE_TASSE_amm =	ISNULL((select [IMPOSTE_TASSE_amm] from #DATI_AMM),0)

/* AMMINISTRAZIONE ANNO 2*/

SET @I_PROVENTI_PROPRI_ANNO_2_amm =	ISNULL((select [I_PROVENTI_PROPRI_ANNO_2_amm] from #DATI_amm),0)
SET @II_CONTRIBUTI_ANNO_2_amm =	ISNULL((select [II_CONTRIBUTI_ANNO_2_amm] from #DATI_amm),0)
SET @III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE_ANNO_2_amm =	ISNULL((select [III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE_ANNO_2_amm] from #DATI_amm),0)
SET @IV_PROVENTI_PER_GESTIONE_DIRETTA_ANNO_2_amm =	ISNULL((select [IV_PROVENTI_PER_GESTIONE_DIRETTA_ANNO_2_amm] from #DATI_amm),0)
SET @V_ALTRI_PROVENTI_ANNO_2_amm =	ISNULL((select [V_ALTRI_PROVENTI_ANNO_2_amm] from #DATI_amm),0)
SET @VI_VARIAZIONE_LAVORI_IN_CORSO_ANNO_2_amm =	ISNULL((select [VI_VARIAZIONE_LAVORI_IN_CORSO_ANNO_2_amm] from #DATI_amm),0)
SET @VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI_ANNO_2_amm =	ISNULL((select [VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI_ANNO_2_amm] from #DATI_amm),0)
SET @PROVENTIOPERATIVI_ANNO_2_amm =	ISNULL((select [PROVENTIOPERATIVI_ANNO_2_amm] from #DATI_amm),0)
SET @COSTI_OPERATIVI_ANNO_2_amm =	ISNULL((select [COSTI_OPERATIVI_ANNO_2_amm] from #DATI_amm),0)
SET @COSTI_SPECIFICI_ANNO_2_amm =	ISNULL((select [COSTI_SPECIFICI_ANNO_2_amm] from #DATI_amm),0)
SET @I_SOSTEGNO_AGLI_STUDENTI_ANNO_2_amm =	ISNULL((select [I_SOSTEGNO_AGLI_STUDENTI_ANNO_2_amm] from #DATI_amm),0)
SET @1_Interventi_favore_degli_studenti_ANNO_2_amm =	ISNULL((select [1_Interventi_favore_degli_studenti_ANNO_2_amm] from #DATI_amm),0)
SET @2_Borse_di_studio_ANNO_2_amm =	ISNULL((select [2_Borse_di_studio_ANNO_2_amm] from #DATI_amm),0)
SET @II_Interventi_diritto_allo_studio_ANNO_2_amm =	ISNULL((select [II_Interventi_diritto_allo_studio_ANNO_2_amm] from #DATI_amm),0)
SET @III_Sostegno_alla_ricerca_ANNO_2_amm =	ISNULL((select [III_Sostegno_alla_ricerca_ANNO_2_amm] from #DATI_amm),0)
SET @IV_Personale_dedicato_alla_ricerca_ANNO_2_amm =	ISNULL((select [IV_Personale_dedicato_alla_ricerca_ANNO_2_amm] from #DATI_amm),0)
SET @1_Docenti_ANNO_2_amm =	ISNULL((select [1_Docenti_ANNO_2_amm] from #DATI_amm),0)
SET @2_Ricercatori_ANNO_2_amm =	ISNULL((select [2_Ricercatori_ANNO_2_amm] from #DATI_amm),0)
SET @3_Ricercatori_a_tempo_determinato_ANNO_2_amm =	ISNULL((select [3_Ricercatori_a_tempo_determinato_ANNO_2_amm] from #DATI_amm),0)
SET @4_Collaborazioni_scientifiche_ANNO_2_amm =	ISNULL((select [4_Collaborazioni_scientifiche_ANNO_2_amm] from #DATI_amm),0)
SET @5_Docenti_contratto_ANNO_2_amm =	ISNULL((select [5_Docenti_contratto_ANNO_2_amm] from #DATI_amm),0)
SET @6_Esperti_linguistici_ANNO_2_amm =	ISNULL((select [6_Esperti_linguistici_ANNO_2_amm] from #DATI_amm),0)
SET @7_Altro_personale_dedicato_alla_ricerca_didattica_ANNO_2_amm =	ISNULL((select [7_Altro_personale_dedicato_alla_ricerca_didattica_ANNO_2_amm] from #DATI_amm),0)
SET @8_Missioni_personale_dedicato_alla_didattica_ANNO_2_amm =	ISNULL((select [8_Missioni_personale_dedicato_alla_didattica_ANNO_2_amm] from #DATI_amm),0)
SET @9_Altri_oneri_personale_ANNO_2_amm =	ISNULL((select [9_Altri_oneri_personale_ANNO_2_amm] from #DATI_amm),0)
SET @V_Acquisto_materiale_ANNO_2_amm =	ISNULL((select [V_Acquisto_materiale_ANNO_2_amm] from #DATI_amm),0)
SET @VI_Trasferimenti_ANNO_2_amm =	ISNULL((select [VI_Trasferimenti_ANNO_2_amm] from #DATI_amm),0)
SET @VII_Altri_costi_specifici_ANNO_2_amm =	ISNULL((select [VII_Altri_costi_specifici_ANNO_2_amm] from #DATI_amm),0)
SET @COSTI_GENERALI_ANNO_2_amm =	ISNULL((select [COSTI_GENERALI_ANNO_2_amm] from #DATI_amm),0)
SET @I_Personale_tecnicoamministrativo_ANNO_2_amm =	ISNULL((select [I_Personale_tecnicoamministrativo_ANNO_2_amm] from #DATI_amm),0)
SET @II_Acquisto_materiali_ANNO_2_amm =	ISNULL((select [II_Acquisto_materiali_ANNO_2_amm] from #DATI_amm),0)
SET @III_Acquisto_libri_periodici_ANNO_2_amm =	ISNULL((select [III_Acquisto_libri_periodici_ANNO_2_amm] from #DATI_amm),0)
SET @IV_Acquisto_servizi_ANNO_2_amm =	ISNULL((select [IV_Acquisto_servizi_ANNO_2_amm] from #DATI_amm),0)
SET @V_Costi_godimento_beni_ANNO_2_amm =	ISNULL((select [V_Costi_godimento_beni_ANNO_2_amm] from #DATI_amm),0)
SET @VI_Altri_costi_generali_ANNO_2_amm =	ISNULL((select [VI_Altri_costi_generali_ANNO_2_amm] from #DATI_amm),0)
SET @1_Utenze_canoni_ANNO_2_amm =	ISNULL((select [1_Utenze_canoni_ANNO_2_amm] from #DATI_amm),0)
SET @2_Manutenzione_ordinaria_ANNO_2_amm =	ISNULL((select [2_Manutenzione_ordinaria_ANNO_2_amm] from #DATI_amm),0)
SET @3_Manutenzione_straordinaria_ANNO_2_amm =	ISNULL((select [3_Manutenzione_straordinaria_ANNO_2_amm] from #DATI_amm),0)
SET @4_Altri_costi_generali_ANNO_2_amm =	ISNULL((select [4_Altri_costi_generali_ANNO_2_amm] from #DATI_amm),0)
SET @DIFFERENZA_PROVENTI_E_COSTI_OPERATIVI_ANNO_2_amm =	ISNULL((select [DIFFERENZA_PROVENTI_E_COSTI_OPERATIVI_ANNO_2_amm] from #DATI_amm),0)
SET @AMMORTAMENTI_SVALUTAZIONI_ANNO_2_amm =	ISNULL((select [AMMORTAMENTI_SVALUTAZIONI_ANNO_2_amm] from #DATI_amm),0)
SET @ACCANTONAMENTI_RISCHI_ONERI_ANNO_2_amm =	ISNULL((select [ACCANTONAMENTI_RISCHI_ONERI_ANNO_2_amm] from #DATI_amm),0)
SET @ALTRI_ACCANTONAMENTI_ANNO_2_amm =	ISNULL((select [ALTRI_ACCANTONAMENTI_ANNO_2_amm] from #DATI_amm),0)
SET @ONERI_DIVERSI_GESTIONE_ANNO_2_amm =	ISNULL((select [ONERI_DIVERSI_GESTIONE_ANNO_2_amm] from #DATI_amm),0)
SET @I_Imposte_varie_ANNO_2_amm =	ISNULL((select [I_Imposte_varie_ANNO_2_amm] from #DATI_amm),0)
SET @II_Altri_oneri_ANNO_2_amm =	ISNULL((select [II_Altri_oneri_ANNO_2_amm] from #DATI_amm),0)
SET @III_Trasferimenti_correnti_ANNO_2_amm =	ISNULL((select [III_Trasferimenti_correnti_ANNO_2_amm] from #DATI_amm),0)
SET @IV_Trasferimenti_investimenti_ANNO_2_amm =	ISNULL((select [IV_Trasferimenti_investimenti_ANNO_2_amm] from #DATI_amm),0)
SET @PROVENTI_E_ONERI_FINANZIARI_ANNO_2_amm =	ISNULL((select [PROVENTI_E_ONERI_FINANZIARI_ANNO_2_amm] from #DATI_amm),0)
SET @proventi_ANNO_2_amm =	ISNULL((select [proventi_ANNO_2_amm] from #DATI_amm),0)
SET @oneri_ANNO_2_amm =	ISNULL((select [oneri_ANNO_2_amm] from #DATI_amm),0)
SET @RETTIFICHE_DI_VALORE_DI_ATTIVITA_FINANZIARIE_ANNO_2_amm =	ISNULL((select [RETTIFICHE_DI_VALORE_DI_ATTIVITA_FINANZIARIE_ANNO_2_amm] from #DATI_amm),0)
SET @PROVENTI_ONERI_STRAORDINARI_ANNO_2_amm =	ISNULL((select [PROVENTI_ONERI_STRAORDINARI_ANNO_2_amm] from #DATI_amm),0)
SET @1_PROVENTI_STRAORDINARI_ANNO_2_amm =	ISNULL((select [1_PROVENTI_STRAORDINARI_ANNO_2_amm] from #DATI_amm),0)
SET @2_ONERI_STRAORDINARI_ANNO_2_amm =	ISNULL((select [2_ONERI_STRAORDINARI_ANNO_2_amm] from #DATI_amm),0)
SET @IMPOSTE_TASSE_ANNO_2_amm =	ISNULL((select [IMPOSTE_TASSE_ANNO_2_amm] from #DATI_amm),0)

/*AMMINISTRAZIONE ANNO 3*/ 
SET @I_PROVENTI_PROPRI_ANNO_3_amm =	ISNULL((select [I_PROVENTI_PROPRI_ANNO_3_amm] from #DATI_amm),0)
SET @II_CONTRIBUTI_ANNO_3_amm =	ISNULL((select [II_CONTRIBUTI_ANNO_3_amm] from #DATI_amm),0)
SET @III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE_ANNO_3_amm =	ISNULL((select [III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE_ANNO_3_amm] from #DATI_amm),0)
SET @IV_PROVENTI_PER_GESTIONE_DIRETTA_ANNO_3_amm =	ISNULL((select [IV_PROVENTI_PER_GESTIONE_DIRETTA_ANNO_3_amm] from #DATI_amm),0)
SET @V_ALTRI_PROVENTI_ANNO_3_amm =	ISNULL((select [V_ALTRI_PROVENTI_ANNO_3_amm] from #DATI_amm),0)
SET @VI_VARIAZIONE_LAVORI_IN_CORSO_ANNO_3_amm =	ISNULL((select [VI_VARIAZIONE_LAVORI_IN_CORSO_ANNO_3_amm] from #DATI_amm),0)
SET @VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI_ANNO_3_amm =	ISNULL((select [VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI_ANNO_3_amm] from #DATI_amm),0)
SET @PROVENTIOPERATIVI_ANNO_3_amm =	ISNULL((select [PROVENTIOPERATIVI_ANNO_3_amm] from #DATI_amm),0)
SET @COSTI_OPERATIVI_ANNO_3_amm =	ISNULL((select [COSTI_OPERATIVI_ANNO_3_amm] from #DATI_amm),0)
SET @COSTI_SPECIFICI_ANNO_3_amm =	ISNULL((select [COSTI_SPECIFICI_ANNO_3_amm] from #DATI_amm),0)
SET @I_SOSTEGNO_AGLI_STUDENTI_ANNO_3_amm =	ISNULL((select [I_SOSTEGNO_AGLI_STUDENTI_ANNO_3_amm] from #DATI_amm),0)
SET @1_Interventi_favore_degli_studenti_ANNO_3_amm =	ISNULL((select [1_Interventi_favore_degli_studenti_ANNO_3_amm] from #DATI_amm),0)
SET @2_Borse_di_studio_ANNO_3_amm =	ISNULL((select [2_Borse_di_studio_ANNO_3_amm] from #DATI_amm),0)
SET @II_Interventi_diritto_allo_studio_ANNO_3_amm =	ISNULL((select [II_Interventi_diritto_allo_studio_ANNO_3_amm] from #DATI_amm),0)
SET @III_Sostegno_alla_ricerca_ANNO_3_amm =	ISNULL((select [III_Sostegno_alla_ricerca_ANNO_3_amm] from #DATI_amm),0)
SET @IV_Personale_dedicato_alla_ricerca_ANNO_3_amm =	ISNULL((select [IV_Personale_dedicato_alla_ricerca_ANNO_3_amm] from #DATI_amm),0)
SET @1_Docenti_ANNO_3_amm =	ISNULL((select [1_Docenti_ANNO_3_amm] from #DATI_amm),0)
SET @2_Ricercatori_ANNO_3_amm =	ISNULL((select [2_Ricercatori_ANNO_3_amm] from #DATI_amm),0)
SET @3_Ricercatori_a_tempo_determinato_ANNO_3_amm =	ISNULL((select [3_Ricercatori_a_tempo_determinato_ANNO_3_amm] from #DATI_amm),0)
SET @4_Collaborazioni_scientifiche_ANNO_3_amm =	ISNULL((select [4_Collaborazioni_scientifiche_ANNO_3_amm] from #DATI_amm),0)
SET @5_Docenti_contratto_ANNO_3_amm =	ISNULL((select [5_Docenti_contratto_ANNO_3_amm] from #DATI_amm),0)
SET @6_Esperti_linguistici_ANNO_3_amm =	ISNULL((select [6_Esperti_linguistici_ANNO_3_amm] from #DATI_amm),0)
SET @7_Altro_personale_dedicato_alla_ricerca_didattica_ANNO_3_amm =	ISNULL((select [7_Altro_personale_dedicato_alla_ricerca_didattica_ANNO_3_amm] from #DATI_amm),0)
SET @8_Missioni_personale_dedicato_alla_didattica_ANNO_3_amm =	ISNULL((select [8_Missioni_personale_dedicato_alla_didattica_ANNO_3_amm] from #DATI_amm),0)
SET @9_Altri_oneri_personale_ANNO_3_amm =	ISNULL((select [9_Altri_oneri_personale_ANNO_3_amm] from #DATI_amm),0)
SET @V_Acquisto_materiale_ANNO_3_amm =	ISNULL((select [V_Acquisto_materiale_ANNO_3_amm] from #DATI_amm),0)
SET @VI_Trasferimenti_ANNO_3_amm =	ISNULL((select [VI_Trasferimenti_ANNO_3_amm] from #DATI_amm),0)
SET @VII_Altri_costi_specifici_ANNO_3_amm =	ISNULL((select [VII_Altri_costi_specifici_ANNO_3_amm] from #DATI_amm),0)
SET @COSTI_GENERALI_ANNO_3_amm =	ISNULL((select [COSTI_GENERALI_ANNO_3_amm] from #DATI_amm),0)
SET @I_Personale_tecnicoamministrativo_ANNO_3_amm =	ISNULL((select [I_Personale_tecnicoamministrativo_ANNO_3_amm] from #DATI_amm),0)
SET @II_Acquisto_materiali_ANNO_3_amm =	ISNULL((select [II_Acquisto_materiali_ANNO_3_amm] from #DATI_amm),0)
SET @III_Acquisto_libri_periodici_ANNO_3_amm =	ISNULL((select [III_Acquisto_libri_periodici_ANNO_3_amm] from #DATI_amm),0)
SET @IV_Acquisto_servizi_ANNO_3_amm =	ISNULL((select [IV_Acquisto_servizi_ANNO_3_amm] from #DATI_amm),0)
SET @V_Costi_godimento_beni_ANNO_3_amm =	ISNULL((select [V_Costi_godimento_beni_ANNO_3_amm] from #DATI_amm),0)
SET @VI_Altri_costi_generali_ANNO_3_amm =	ISNULL((select [VI_Altri_costi_generali_ANNO_3_amm] from #DATI_amm),0)
SET @1_Utenze_canoni_ANNO_3_amm =	ISNULL((select [1_Utenze_canoni_ANNO_3_amm] from #DATI_amm),0)
SET @2_Manutenzione_ordinaria_ANNO_3_amm =	ISNULL((select [2_Manutenzione_ordinaria_ANNO_3_amm] from #DATI_amm),0)
SET @3_Manutenzione_straordinaria_ANNO_3_amm =	ISNULL((select [3_Manutenzione_straordinaria_ANNO_3_amm] from #DATI_amm),0)
SET @4_Altri_costi_generali_ANNO_3_amm =	ISNULL((select [4_Altri_costi_generali_ANNO_3_amm] from #DATI_amm),0)
SET @DIFFERENZA_PROVENTI_E_COSTI_OPERATIVI_ANNO_3_amm =	ISNULL((select [DIFFERENZA_PROVENTI_E_COSTI_OPERATIVI_ANNO_3_amm] from #DATI_amm),0)
SET @AMMORTAMENTI_SVALUTAZIONI_ANNO_3_amm =	ISNULL((select [AMMORTAMENTI_SVALUTAZIONI_ANNO_3_amm] from #DATI_amm),0)
SET @ACCANTONAMENTI_RISCHI_ONERI_ANNO_3_amm =	ISNULL((select [ACCANTONAMENTI_RISCHI_ONERI_ANNO_3_amm] from #DATI_amm),0)
SET @ALTRI_ACCANTONAMENTI_ANNO_3_amm =	ISNULL((select [ALTRI_ACCANTONAMENTI_ANNO_3_amm] from #DATI_amm),0)
SET @ONERI_DIVERSI_GESTIONE_ANNO_3_amm =	ISNULL((select [ONERI_DIVERSI_GESTIONE_ANNO_3_amm] from #DATI_amm),0)
SET @I_Imposte_varie_ANNO_3_amm =	ISNULL((select [I_Imposte_varie_ANNO_3_amm] from #DATI_amm),0)
SET @II_Altri_oneri_ANNO_3_amm =	ISNULL((select [II_Altri_oneri_ANNO_3_amm] from #DATI_amm),0)
SET @III_Trasferimenti_correnti_ANNO_3_amm =	ISNULL((select [III_Trasferimenti_correnti_ANNO_3_amm] from #DATI_amm),0)
SET @IV_Trasferimenti_investimenti_ANNO_3_amm =	ISNULL((select [IV_Trasferimenti_investimenti_ANNO_3_amm] from #DATI_amm),0)
SET @PROVENTI_E_ONERI_FINANZIARI_ANNO_3_amm =	ISNULL((select [PROVENTI_E_ONERI_FINANZIARI_ANNO_3_amm] from #DATI_amm),0)
SET @proventi_ANNO_3_amm =	ISNULL((select [proventi_ANNO_3_amm] from #DATI_amm),0)
SET @oneri_ANNO_3_amm =	ISNULL((select [oneri_ANNO_3_amm] from #DATI_amm),0)
SET @RETTIFICHE_DI_VALORE_DI_ATTIVITA_FINANZIARIE_ANNO_3_amm =	ISNULL((select [RETTIFICHE_DI_VALORE_DI_ATTIVITA_FINANZIARIE_ANNO_3_amm] from #DATI_amm),0)
SET @PROVENTI_ONERI_STRAORDINARI_ANNO_3_amm =	ISNULL((select [PROVENTI_ONERI_STRAORDINARI_ANNO_3_amm] from #DATI_amm),0)
SET @1_PROVENTI_STRAORDINARI_ANNO_3_amm =	ISNULL((select [1_PROVENTI_STRAORDINARI_ANNO_3_amm] from #DATI_amm),0)
SET @2_ONERI_STRAORDINARI_ANNO_3_amm =	ISNULL((select [2_ONERI_STRAORDINARI_ANNO_3_amm] from #DATI_amm),0)
SET @IMPOSTE_TASSE_ANNO_3_amm =	ISNULL((select [IMPOSTE_TASSE_ANNO_3_amm] from #DATI_amm),0)


/*DIPARTIMENTI*/

SET @I_PROVENTI_PROPRI_dip =	ISNULL((select [I_PROVENTI_PROPRI_dip] from #DATI_dip),0)
SET @II_CONTRIBUTI_dip =	ISNULL((select [II_CONTRIBUTI_dip] from #DATI_dip),0)
SET @III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE_dip =	ISNULL((select [III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE_dip] from #DATI_dip),0)
SET @IV_PROVENTI_PER_GESTIONE_DIRETTA_dip =	ISNULL((select [IV_PROVENTI_PER_GESTIONE_DIRETTA_dip] from #DATI_dip),0)
SET @V_ALTRI_PROVENTI_dip =	ISNULL((select [V_ALTRI_PROVENTI_dip] from #DATI_dip),0)
SET @VI_VARIAZIONE_LAVORI_IN_CORSO_dip =	ISNULL((select [VI_VARIAZIONE_LAVORI_IN_CORSO_dip] from #DATI_dip),0)
SET @VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI_dip =	ISNULL((select [VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI_dip] from #DATI_dip),0)
SET @PROVENTIOPERATIVI_dip =	ISNULL((select [PROVENTIOPERATIVI_dip] from #DATI_dip),0)
SET @COSTI_OPERATIVI_dip =	ISNULL((select [COSTI_OPERATIVI_dip] from #DATI_dip),0)
SET @COSTI_SPECIFICI_dip =	ISNULL((select [COSTI_SPECIFICI_dip] from #DATI_dip),0)
SET @I_SOSTEGNO_AGLI_STUDENTI_dip =	ISNULL((select [I_SOSTEGNO_AGLI_STUDENTI_dip] from #DATI_dip),0)
SET @1_Interventi_favore_degli_studenti_dip =	ISNULL((select [1_Interventi_favore_degli_studenti_dip] from #DATI_dip),0)
SET @2_Borse_di_studio_dip =	ISNULL((select [2_Borse_di_studio_dip] from #DATI_dip),0)
SET @II_Interventi_diritto_allo_studio_dip =	ISNULL((select [II_Interventi_diritto_allo_studio_dip] from #DATI_dip),0)
SET @III_Sostegno_alla_ricerca_dip =	ISNULL((select [III_Sostegno_alla_ricerca_dip] from #DATI_dip),0)
SET @IV_Personale_dedicato_alla_ricerca_dip =	ISNULL((select [IV_Personale_dedicato_alla_ricerca_dip] from #DATI_dip),0)
SET @1_Docenti_dip =	ISNULL((select [1_Docenti_dip] from #DATI_dip),0)
SET @2_Ricercatori_dip =	ISNULL((select [2_Ricercatori_dip] from #DATI_dip),0)
SET @3_Ricercatori_a_tempo_determinato_dip =	ISNULL((select [3_Ricercatori_a_tempo_determinato_dip] from #DATI_dip),0)
SET @4_Collaborazioni_scientifiche_dip =	ISNULL((select [4_Collaborazioni_scientifiche_dip] from #DATI_dip),0)
SET @5_Docenti_contratto_dip =	ISNULL((select [5_Docenti_contratto_dip] from #DATI_dip),0)
SET @6_Esperti_linguistici_dip =	ISNULL((select [6_Esperti_linguistici_dip] from #DATI_dip),0)
SET @7_Altro_personale_dedicato_alla_ricerca_didattica_dip =	ISNULL((select [7_Altro_personale_dedicato_alla_ricerca_didattica_dip] from #DATI_dip),0)
SET @8_Missioni_personale_dedicato_alla_didattica_dip =	ISNULL((select [8_Missioni_personale_dedicato_alla_didattica_dip] from #DATI_dip),0)
SET @9_Altri_oneri_personale_dip =	ISNULL((select [9_Altri_oneri_personale_dip] from #DATI_dip),0)
SET @V_Acquisto_materiale_dip =	ISNULL((select [V_Acquisto_materiale_dip] from #DATI_dip),0)
SET @VI_Trasferimenti_dip =	ISNULL((select [VI_Trasferimenti_dip] from #DATI_dip),0)
SET @VII_Altri_costi_specifici_dip =	ISNULL((select [VII_Altri_costi_specifici_dip] from #DATI_dip),0)
SET @COSTI_GENERALI_dip =	ISNULL((select [COSTI_GENERALI_dip] from #DATI_dip),0)
SET @I_Personale_tecnicoamministrativo_dip =	ISNULL((select [I_Personale_tecnicoamministrativo_dip] from #DATI_dip),0)
SET @II_Acquisto_materiali_dip =	ISNULL((select [II_Acquisto_materiali_dip] from #DATI_dip),0)
SET @III_Acquisto_libri_periodici_dip =	ISNULL((select [III_Acquisto_libri_periodici_dip] from #DATI_dip),0)
SET @IV_Acquisto_servizi_dip =	ISNULL((select [IV_Acquisto_servizi_dip] from #DATI_dip),0)
SET @V_Costi_godimento_beni_dip =	ISNULL((select [V_Costi_godimento_beni_dip] from #DATI_dip),0)
SET @VI_Altri_costi_generali_dip =	ISNULL((select [VI_Altri_costi_generali_dip] from #DATI_dip),0)
SET @1_Utenze_canoni_dip =	ISNULL((select [1_Utenze_canoni_dip] from #DATI_dip),0)
SET @2_Manutenzione_ordinaria_dip =	ISNULL((select [2_Manutenzione_ordinaria_dip] from #DATI_dip),0)
SET @3_Manutenzione_straordinaria_dip =	ISNULL((select [3_Manutenzione_straordinaria_dip] from #DATI_dip),0)
SET @4_Altri_costi_generali_dip =	ISNULL((select [4_Altri_costi_generali_dip] from #DATI_dip),0)
SET @DIFFERENZA_PROVENTI_E_COSTI_OPERATIVI_dip =	ISNULL((select [DIFFERENZA_PROVENTI_E_COSTI_OPERATIVI_dip] from #DATI_dip),0)
SET @AMMORTAMENTI_SVALUTAZIONI_dip =	ISNULL((select [AMMORTAMENTI_SVALUTAZIONI_dip] from #DATI_dip),0)
SET @ACCANTONAMENTI_RISCHI_ONERI_dip =	ISNULL((select [ACCANTONAMENTI_RISCHI_ONERI_dip] from #DATI_dip),0)
SET @ALTRI_ACCANTONAMENTI_dip =	ISNULL((select [ALTRI_ACCANTONAMENTI_dip] from #DATI_dip),0)
SET @ONERI_DIVERSI_GESTIONE_dip =	ISNULL((select [ONERI_DIVERSI_GESTIONE_dip] from #DATI_dip),0)
SET @I_Imposte_varie_dip =	ISNULL((select [I_Imposte_varie_dip] from #DATI_dip),0)
SET @II_Altri_oneri_dip =	ISNULL((select [II_Altri_oneri_dip] from #DATI_dip),0)
SET @III_Trasferimenti_correnti_dip =	ISNULL((select [III_Trasferimenti_correnti_dip] from #DATI_dip),0)
SET @IV_Trasferimenti_investimenti_dip =	ISNULL((select [IV_Trasferimenti_investimenti_dip] from #DATI_dip),0)
SET @PROVENTI_E_ONERI_FINANZIARI_dip =	ISNULL((select [PROVENTI_E_ONERI_FINANZIARI_dip] from #DATI_dip),0)
SET @proventi_dip =	ISNULL((select [proventi_dip] from #DATI_dip),0)
SET @oneri_dip =	ISNULL((select [oneri_dip] from #DATI_dip),0)
SET @RETTIFICHE_DI_VALORE_DI_ATTIVITA_FINANZIARIE_dip =	ISNULL((select [RETTIFICHE_DI_VALORE_DI_ATTIVITA_FINANZIARIE_dip] from #DATI_dip),0)
SET @PROVENTI_ONERI_STRAORDINARI_dip =	ISNULL((select [PROVENTI_ONERI_STRAORDINARI_dip] from #DATI_dip),0)
SET @1_PROVENTI_STRAORDINARI_dip =	ISNULL((select [1_PROVENTI_STRAORDINARI_dip] from #DATI_dip),0)
SET @2_ONERI_STRAORDINARI_dip =	ISNULL((select [2_ONERI_STRAORDINARI_dip] from #DATI_dip),0)
SET @IMPOSTE_TASSE_dip =	ISNULL((select [IMPOSTE_TASSE_dip] from #DATI_dip),0)

/* DIPARTIMENTI ANNO 2*/

SET @I_PROVENTI_PROPRI_ANNO_2_dip =	ISNULL((select [I_PROVENTI_PROPRI_ANNO_2_dip] from #DATI_dip),0)
SET @II_CONTRIBUTI_ANNO_2_dip =	ISNULL((select [II_CONTRIBUTI_ANNO_2_dip] from #DATI_dip),0)
SET @III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE_ANNO_2_dip =	ISNULL((select [III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE_ANNO_2_dip] from #DATI_dip),0)
SET @IV_PROVENTI_PER_GESTIONE_DIRETTA_ANNO_2_dip =	ISNULL((select [IV_PROVENTI_PER_GESTIONE_DIRETTA_ANNO_2_dip] from #DATI_dip),0)
SET @V_ALTRI_PROVENTI_ANNO_2_dip =	ISNULL((select [V_ALTRI_PROVENTI_ANNO_2_dip] from #DATI_dip),0)
SET @VI_VARIAZIONE_LAVORI_IN_CORSO_ANNO_2_dip =	ISNULL((select [VI_VARIAZIONE_LAVORI_IN_CORSO_ANNO_2_dip] from #DATI_dip),0)
SET @VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI_ANNO_2_dip =	ISNULL((select [VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI_ANNO_2_dip] from #DATI_dip),0)
SET @PROVENTIOPERATIVI_ANNO_2_dip =	ISNULL((select [PROVENTIOPERATIVI_ANNO_2_dip] from #DATI_dip),0)
SET @COSTI_OPERATIVI_ANNO_2_dip =	ISNULL((select [COSTI_OPERATIVI_ANNO_2_dip] from #DATI_dip),0)
SET @COSTI_SPECIFICI_ANNO_2_dip =	ISNULL((select [COSTI_SPECIFICI_ANNO_2_dip] from #DATI_dip),0)
SET @I_SOSTEGNO_AGLI_STUDENTI_ANNO_2_dip =	ISNULL((select [I_SOSTEGNO_AGLI_STUDENTI_ANNO_2_dip] from #DATI_dip),0)
SET @1_Interventi_favore_degli_studenti_ANNO_2_dip =	ISNULL((select [1_Interventi_favore_degli_studenti_ANNO_2_dip] from #DATI_dip),0)
SET @2_Borse_di_studio_ANNO_2_dip =	ISNULL((select [2_Borse_di_studio_ANNO_2_dip] from #DATI_dip),0)
SET @II_Interventi_diritto_allo_studio_ANNO_2_dip =	ISNULL((select [II_Interventi_diritto_allo_studio_ANNO_2_dip] from #DATI_dip),0)
SET @III_Sostegno_alla_ricerca_ANNO_2_dip =	ISNULL((select [III_Sostegno_alla_ricerca_ANNO_2_dip] from #DATI_dip),0)
SET @IV_Personale_dedicato_alla_ricerca_ANNO_2_dip =	ISNULL((select [IV_Personale_dedicato_alla_ricerca_ANNO_2_dip] from #DATI_dip),0)
SET @1_Docenti_ANNO_2_dip =	ISNULL((select [1_Docenti_ANNO_2_dip] from #DATI_dip),0)
SET @2_Ricercatori_ANNO_2_dip =	ISNULL((select [2_Ricercatori_ANNO_2_dip] from #DATI_dip),0)
SET @3_Ricercatori_a_tempo_determinato_ANNO_2_dip =	ISNULL((select [3_Ricercatori_a_tempo_determinato_ANNO_2_dip] from #DATI_dip),0)
SET @4_Collaborazioni_scientifiche_ANNO_2_dip =	ISNULL((select [4_Collaborazioni_scientifiche_ANNO_2_dip] from #DATI_dip),0)
SET @5_Docenti_contratto_ANNO_2_dip =	ISNULL((select [5_Docenti_contratto_ANNO_2_dip] from #DATI_dip),0)
SET @6_Esperti_linguistici_ANNO_2_dip =	ISNULL((select [6_Esperti_linguistici_ANNO_2_dip] from #DATI_dip),0)
SET @7_Altro_personale_dedicato_alla_ricerca_didattica_ANNO_2_dip =	ISNULL((select [7_Altro_personale_dedicato_alla_ricerca_didattica_ANNO_2_dip] from #DATI_dip),0)
SET @8_Missioni_personale_dedicato_alla_didattica_ANNO_2_dip =	ISNULL((select [8_Missioni_personale_dedicato_alla_didattica_ANNO_2_dip] from #DATI_dip),0)
SET @9_Altri_oneri_personale_ANNO_2_dip =	ISNULL((select [9_Altri_oneri_personale_ANNO_2_dip] from #DATI_dip),0)
SET @V_Acquisto_materiale_ANNO_2_dip =	ISNULL((select [V_Acquisto_materiale_ANNO_2_dip] from #DATI_dip),0)
SET @VI_Trasferimenti_ANNO_2_dip =	ISNULL((select [VI_Trasferimenti_ANNO_2_dip] from #DATI_dip),0)
SET @VII_Altri_costi_specifici_ANNO_2_dip =	ISNULL((select [VII_Altri_costi_specifici_ANNO_2_dip] from #DATI_dip),0)
SET @COSTI_GENERALI_ANNO_2_dip =	ISNULL((select [COSTI_GENERALI_ANNO_2_dip] from #DATI_dip),0)
SET @I_Personale_tecnicoamministrativo_ANNO_2_dip =	ISNULL((select [I_Personale_tecnicoamministrativo_ANNO_2_dip] from #DATI_dip),0)
SET @II_Acquisto_materiali_ANNO_2_dip =	ISNULL((select [II_Acquisto_materiali_ANNO_2_dip] from #DATI_dip),0)
SET @III_Acquisto_libri_periodici_ANNO_2_dip =	ISNULL((select [III_Acquisto_libri_periodici_ANNO_2_dip] from #DATI_dip),0)
SET @IV_Acquisto_servizi_ANNO_2_dip =	ISNULL((select [IV_Acquisto_servizi_ANNO_2_dip] from #DATI_dip),0)
SET @V_Costi_godimento_beni_ANNO_2_dip =	ISNULL((select [V_Costi_godimento_beni_ANNO_2_dip] from #DATI_dip),0)
SET @VI_Altri_costi_generali_ANNO_2_dip =	ISNULL((select [VI_Altri_costi_generali_ANNO_2_dip] from #DATI_dip),0)
SET @1_Utenze_canoni_ANNO_2_dip =	ISNULL((select [1_Utenze_canoni_ANNO_2_dip] from #DATI_dip),0)
SET @2_Manutenzione_ordinaria_ANNO_2_dip =	ISNULL((select [2_Manutenzione_ordinaria_ANNO_2_dip] from #DATI_dip),0)
SET @3_Manutenzione_straordinaria_ANNO_2_dip =	ISNULL((select [3_Manutenzione_straordinaria_ANNO_2_dip] from #DATI_dip),0)
SET @4_Altri_costi_generali_ANNO_2_dip =	ISNULL((select [4_Altri_costi_generali_ANNO_2_dip] from #DATI_dip),0)
SET @DIFFERENZA_PROVENTI_E_COSTI_OPERATIVI_ANNO_2_dip =	ISNULL((select [DIFFERENZA_PROVENTI_E_COSTI_OPERATIVI_ANNO_2_dip] from #DATI_dip),0)
SET @AMMORTAMENTI_SVALUTAZIONI_ANNO_2_dip =	ISNULL((select [AMMORTAMENTI_SVALUTAZIONI_ANNO_2_dip] from #DATI_dip),0)
SET @ACCANTONAMENTI_RISCHI_ONERI_ANNO_2_dip =	ISNULL((select [ACCANTONAMENTI_RISCHI_ONERI_ANNO_2_dip] from #DATI_dip),0)
SET @ALTRI_ACCANTONAMENTI_ANNO_2_dip =	ISNULL((select [ALTRI_ACCANTONAMENTI_ANNO_2_dip] from #DATI_dip),0)
SET @ONERI_DIVERSI_GESTIONE_ANNO_2_dip =	ISNULL((select [ONERI_DIVERSI_GESTIONE_ANNO_2_dip] from #DATI_dip),0)
SET @I_Imposte_varie_ANNO_2_dip =	ISNULL((select [I_Imposte_varie_ANNO_2_dip] from #DATI_dip),0)
SET @II_Altri_oneri_ANNO_2_dip =	ISNULL((select [II_Altri_oneri_ANNO_2_dip] from #DATI_dip),0)
SET @III_Trasferimenti_correnti_ANNO_2_dip =	ISNULL((select [III_Trasferimenti_correnti_ANNO_2_dip] from #DATI_dip),0)
SET @IV_Trasferimenti_investimenti_ANNO_2_dip =	ISNULL((select [IV_Trasferimenti_investimenti_ANNO_2_dip] from #DATI_dip),0)
SET @PROVENTI_E_ONERI_FINANZIARI_ANNO_2_dip =	ISNULL((select [PROVENTI_E_ONERI_FINANZIARI_ANNO_2_dip] from #DATI_dip),0)
SET @proventi_ANNO_2_dip =	ISNULL((select [proventi_ANNO_2_dip] from #DATI_dip),0)
SET @oneri_ANNO_2_dip =	ISNULL((select [oneri_ANNO_2_dip] from #DATI_dip),0)
SET @RETTIFICHE_DI_VALORE_DI_ATTIVITA_FINANZIARIE_ANNO_2_dip =	ISNULL((select [RETTIFICHE_DI_VALORE_DI_ATTIVITA_FINANZIARIE_ANNO_2_dip] from #DATI_dip),0)
SET @PROVENTI_ONERI_STRAORDINARI_ANNO_2_dip =	ISNULL((select [PROVENTI_ONERI_STRAORDINARI_ANNO_2_dip] from #DATI_dip),0)
SET @1_PROVENTI_STRAORDINARI_ANNO_2_dip =	ISNULL((select [1_PROVENTI_STRAORDINARI_ANNO_2_dip] from #DATI_dip),0)
SET @2_ONERI_STRAORDINARI_ANNO_2_dip =	ISNULL((select [2_ONERI_STRAORDINARI_ANNO_2_dip] from #DATI_dip),0)
SET @IMPOSTE_TASSE_ANNO_2_dip =	ISNULL((select [IMPOSTE_TASSE_ANNO_2_dip] from #DATI_dip),0)

/*DIPARTIMENTI ANNO 3*/ 
SET @I_PROVENTI_PROPRI_ANNO_3_dip =	ISNULL((select [I_PROVENTI_PROPRI_ANNO_3_dip] from #DATI_dip),0)
SET @II_CONTRIBUTI_ANNO_3_dip =	ISNULL((select [II_CONTRIBUTI_ANNO_3_dip] from #DATI_dip),0)
SET @III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE_ANNO_3_dip =	ISNULL((select [III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE_ANNO_3_dip] from #DATI_dip),0)
SET @IV_PROVENTI_PER_GESTIONE_DIRETTA_ANNO_3_dip =	ISNULL((select [IV_PROVENTI_PER_GESTIONE_DIRETTA_ANNO_3_dip] from #DATI_dip),0)
SET @V_ALTRI_PROVENTI_ANNO_3_dip =	ISNULL((select [V_ALTRI_PROVENTI_ANNO_3_dip] from #DATI_dip),0)
SET @VI_VARIAZIONE_LAVORI_IN_CORSO_ANNO_3_dip =	ISNULL((select [VI_VARIAZIONE_LAVORI_IN_CORSO_ANNO_3_dip] from #DATI_dip),0)
SET @VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI_ANNO_3_dip =	ISNULL((select [VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI_ANNO_3_dip] from #DATI_dip),0)
SET @PROVENTIOPERATIVI_ANNO_3_dip =	ISNULL((select [PROVENTIOPERATIVI_ANNO_3_dip] from #DATI_dip),0)
SET @COSTI_OPERATIVI_ANNO_3_dip =	ISNULL((select [COSTI_OPERATIVI_ANNO_3_dip] from #DATI_dip),0)
SET @COSTI_SPECIFICI_ANNO_3_dip =	ISNULL((select [COSTI_SPECIFICI_ANNO_3_dip] from #DATI_dip),0)
SET @I_SOSTEGNO_AGLI_STUDENTI_ANNO_3_dip =	ISNULL((select [I_SOSTEGNO_AGLI_STUDENTI_ANNO_3_dip] from #DATI_dip),0)
SET @1_Interventi_favore_degli_studenti_ANNO_3_dip =	ISNULL((select [1_Interventi_favore_degli_studenti_ANNO_3_dip] from #DATI_dip),0)
SET @2_Borse_di_studio_ANNO_3_dip =	ISNULL((select [2_Borse_di_studio_ANNO_3_dip] from #DATI_dip),0)
SET @II_Interventi_diritto_allo_studio_ANNO_3_dip =	ISNULL((select [II_Interventi_diritto_allo_studio_ANNO_3_dip] from #DATI_dip),0)
SET @III_Sostegno_alla_ricerca_ANNO_3_dip =	ISNULL((select [III_Sostegno_alla_ricerca_ANNO_3_dip] from #DATI_dip),0)
SET @IV_Personale_dedicato_alla_ricerca_ANNO_3_dip =	ISNULL((select [IV_Personale_dedicato_alla_ricerca_ANNO_3_dip] from #DATI_dip),0)
SET @1_Docenti_ANNO_3_dip =	ISNULL((select [1_Docenti_ANNO_3_dip] from #DATI_dip),0)
SET @2_Ricercatori_ANNO_3_dip =	ISNULL((select [2_Ricercatori_ANNO_3_dip] from #DATI_dip),0)
SET @3_Ricercatori_a_tempo_determinato_ANNO_3_dip =	ISNULL((select [3_Ricercatori_a_tempo_determinato_ANNO_3_dip] from #DATI_dip),0)
SET @4_Collaborazioni_scientifiche_ANNO_3_dip =	ISNULL((select [4_Collaborazioni_scientifiche_ANNO_3_dip] from #DATI_dip),0)
SET @5_Docenti_contratto_ANNO_3_dip =	ISNULL((select [5_Docenti_contratto_ANNO_3_dip] from #DATI_dip),0)
SET @6_Esperti_linguistici_ANNO_3_dip =	ISNULL((select [6_Esperti_linguistici_ANNO_3_dip] from #DATI_dip),0)
SET @7_Altro_personale_dedicato_alla_ricerca_didattica_ANNO_3_dip =	ISNULL((select [7_Altro_personale_dedicato_alla_ricerca_didattica_ANNO_3_dip] from #DATI_dip),0)
SET @8_Missioni_personale_dedicato_alla_didattica_ANNO_3_dip =	ISNULL((select [8_Missioni_personale_dedicato_alla_didattica_ANNO_3_dip] from #DATI_dip),0)
SET @9_Altri_oneri_personale_ANNO_3_dip =	ISNULL((select [9_Altri_oneri_personale_ANNO_3_dip] from #DATI_dip),0)
SET @V_Acquisto_materiale_ANNO_3_dip =	ISNULL((select [V_Acquisto_materiale_ANNO_3_dip] from #DATI_dip),0)
SET @VI_Trasferimenti_ANNO_3_dip =	ISNULL((select [VI_Trasferimenti_ANNO_3_dip] from #DATI_dip),0)
SET @VII_Altri_costi_specifici_ANNO_3_dip =	ISNULL((select [VII_Altri_costi_specifici_ANNO_3_dip] from #DATI_dip),0)
SET @COSTI_GENERALI_ANNO_3_dip =	ISNULL((select [COSTI_GENERALI_ANNO_3_dip] from #DATI_dip),0)
SET @I_Personale_tecnicoamministrativo_ANNO_3_dip =	ISNULL((select [I_Personale_tecnicoamministrativo_ANNO_3_dip] from #DATI_dip),0)
SET @II_Acquisto_materiali_ANNO_3_dip =	ISNULL((select [II_Acquisto_materiali_ANNO_3_dip] from #DATI_dip),0)
SET @III_Acquisto_libri_periodici_ANNO_3_dip =	ISNULL((select [III_Acquisto_libri_periodici_ANNO_3_dip] from #DATI_dip),0)
SET @IV_Acquisto_servizi_ANNO_3_dip =	ISNULL((select [IV_Acquisto_servizi_ANNO_3_dip] from #DATI_dip),0)
SET @V_Costi_godimento_beni_ANNO_3_dip =	ISNULL((select [V_Costi_godimento_beni_ANNO_3_dip] from #DATI_dip),0)
SET @VI_Altri_costi_generali_ANNO_3_dip =	ISNULL((select [VI_Altri_costi_generali_ANNO_3_dip] from #DATI_dip),0)
SET @1_Utenze_canoni_ANNO_3_dip =	ISNULL((select [1_Utenze_canoni_ANNO_3_dip] from #DATI_dip),0)
SET @2_Manutenzione_ordinaria_ANNO_3_dip =	ISNULL((select [2_Manutenzione_ordinaria_ANNO_3_dip] from #DATI_dip),0)
SET @3_Manutenzione_straordinaria_ANNO_3_dip =	ISNULL((select [3_Manutenzione_straordinaria_ANNO_3_dip] from #DATI_dip),0)
SET @4_Altri_costi_generali_ANNO_3_dip =	ISNULL((select [4_Altri_costi_generali_ANNO_3_dip] from #DATI_dip),0)
SET @DIFFERENZA_PROVENTI_E_COSTI_OPERATIVI_ANNO_3_dip =	ISNULL((select [DIFFERENZA_PROVENTI_E_COSTI_OPERATIVI_ANNO_3_dip] from #DATI_dip),0)
SET @AMMORTAMENTI_SVALUTAZIONI_ANNO_3_dip =	ISNULL((select [AMMORTAMENTI_SVALUTAZIONI_ANNO_3_dip] from #DATI_dip),0)
SET @ACCANTONAMENTI_RISCHI_ONERI_ANNO_3_dip =	ISNULL((select [ACCANTONAMENTI_RISCHI_ONERI_ANNO_3_dip] from #DATI_dip),0)
SET @ALTRI_ACCANTONAMENTI_ANNO_3_dip =	ISNULL((select [ALTRI_ACCANTONAMENTI_ANNO_3_dip] from #DATI_dip),0)
SET @ONERI_DIVERSI_GESTIONE_ANNO_3_dip =	ISNULL((select [ONERI_DIVERSI_GESTIONE_ANNO_3_dip] from #DATI_dip),0)
SET @I_Imposte_varie_ANNO_3_dip =	ISNULL((select [I_Imposte_varie_ANNO_3_dip] from #DATI_dip),0)
SET @II_Altri_oneri_ANNO_3_dip =	ISNULL((select [II_Altri_oneri_ANNO_3_dip] from #DATI_dip),0)
SET @III_Trasferimenti_correnti_ANNO_3_dip =	ISNULL((select [III_Trasferimenti_correnti_ANNO_3_dip] from #DATI_dip),0)
SET @IV_Trasferimenti_investimenti_ANNO_3_dip =	ISNULL((select [IV_Trasferimenti_investimenti_ANNO_3_dip] from #DATI_dip),0)
SET @PROVENTI_E_ONERI_FINANZIARI_ANNO_3_dip =	ISNULL((select [PROVENTI_E_ONERI_FINANZIARI_ANNO_3_dip] from #DATI_dip),0)
SET @proventi_ANNO_3_dip =	ISNULL((select [proventi_ANNO_3_dip] from #DATI_dip),0)
SET @oneri_ANNO_3_dip =	ISNULL((select [oneri_ANNO_3_dip] from #DATI_dip),0)
SET @RETTIFICHE_DI_VALORE_DI_ATTIVITA_FINANZIARIE_ANNO_3_dip =	ISNULL((select [RETTIFICHE_DI_VALORE_DI_ATTIVITA_FINANZIARIE_ANNO_3_dip] from #DATI_dip),0)
SET @PROVENTI_ONERI_STRAORDINARI_ANNO_3_dip =	ISNULL((select [PROVENTI_ONERI_STRAORDINARI_ANNO_3_dip] from #DATI_dip),0)
SET @1_PROVENTI_STRAORDINARI_ANNO_3_dip =	ISNULL((select [1_PROVENTI_STRAORDINARI_ANNO_3_dip] from #DATI_dip),0)
SET @2_ONERI_STRAORDINARI_ANNO_3_dip =	ISNULL((select [2_ONERI_STRAORDINARI_ANNO_3_dip] from #DATI_dip),0)
SET @IMPOSTE_TASSE_ANNO_3_dip =	ISNULL((select [IMPOSTE_TASSE_ANNO_3_dip] from #DATI_dip),0)


/*TOTALI ANNO 1*/

SET @I_PROVENTI_PROPRI  = @I_PROVENTI_PROPRI_amm + @I_PROVENTI_PROPRI_dip
SET @II_CONTRIBUTI  = @II_CONTRIBUTI_amm + @II_CONTRIBUTI_dip
SET @III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE  = @III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE_amm + @III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE_dip
SET @IV_PROVENTI_PER_GESTIONE_DIRETTA  = @IV_PROVENTI_PER_GESTIONE_DIRETTA_amm + @IV_PROVENTI_PER_GESTIONE_DIRETTA_dip
SET @V_ALTRI_PROVENTI  = @V_ALTRI_PROVENTI_amm + @V_ALTRI_PROVENTI_dip
SET @VI_VARIAZIONE_LAVORI_IN_CORSO  = @VI_VARIAZIONE_LAVORI_IN_CORSO_amm + @VI_VARIAZIONE_LAVORI_IN_CORSO_dip
SET @VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI  = @VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI_amm + @VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI_dip
SET @PROVENTIOPERATIVI  = @PROVENTIOPERATIVI_amm + @PROVENTIOPERATIVI_dip
SET @COSTI_OPERATIVI  = @COSTI_OPERATIVI_amm + @COSTI_OPERATIVI_dip
SET @COSTI_SPECIFICI  = @COSTI_SPECIFICI_amm + @COSTI_SPECIFICI_dip
SET @I_SOSTEGNO_AGLI_STUDENTI  = @I_SOSTEGNO_AGLI_STUDENTI_amm + @I_SOSTEGNO_AGLI_STUDENTI_dip
SET @1_Interventi_favore_degli_studenti  = @1_Interventi_favore_degli_studenti_amm + @1_Interventi_favore_degli_studenti_dip
SET @2_Borse_di_studio  = @2_Borse_di_studio_amm + @2_Borse_di_studio_dip
SET @II_Interventi_diritto_allo_studio  = @II_Interventi_diritto_allo_studio_amm + @II_Interventi_diritto_allo_studio_dip
SET @III_Sostegno_alla_ricerca  = @III_Sostegno_alla_ricerca_amm + @III_Sostegno_alla_ricerca_dip
SET @IV_Personale_dedicato_alla_ricerca  = @IV_Personale_dedicato_alla_ricerca_amm + @IV_Personale_dedicato_alla_ricerca_dip
SET @1_Docenti  = @1_Docenti_amm + @1_Docenti_dip
SET @2_Ricercatori  = @2_Ricercatori_amm + @2_Ricercatori_dip
SET @3_Ricercatori_a_tempo_determinato  = @3_Ricercatori_a_tempo_determinato_amm + @3_Ricercatori_a_tempo_determinato_dip
SET @4_Collaborazioni_scientifiche  = @4_Collaborazioni_scientifiche_amm + @4_Collaborazioni_scientifiche_dip
SET @5_Docenti_contratto  = @5_Docenti_contratto_amm + @5_Docenti_contratto_dip
SET @6_Esperti_linguistici  = @6_Esperti_linguistici_amm + @6_Esperti_linguistici_dip
SET @7_Altro_personale_dedicato_alla_ricerca_didattica  = @7_Altro_personale_dedicato_alla_ricerca_didattica_amm + @7_Altro_personale_dedicato_alla_ricerca_didattica_dip
SET @8_Missioni_personale_dedicato_alla_didattica  = @8_Missioni_personale_dedicato_alla_didattica_amm + @8_Missioni_personale_dedicato_alla_didattica_dip
SET @9_Altri_oneri_personale  = @9_Altri_oneri_personale_amm + @9_Altri_oneri_personale_dip
SET @V_Acquisto_materiale  = @V_Acquisto_materiale_amm + @V_Acquisto_materiale_dip
SET @VI_Trasferimenti  = @VI_Trasferimenti_amm + @VI_Trasferimenti_dip
SET @VII_Altri_costi_specifici  = @VII_Altri_costi_specifici_amm + @VII_Altri_costi_specifici_dip
SET @COSTI_GENERALI  = @COSTI_GENERALI_amm + @COSTI_GENERALI_dip
SET @I_Personale_tecnicoamministrativo  = @I_Personale_tecnicoamministrativo_amm + @I_Personale_tecnicoamministrativo_dip
SET @II_Acquisto_materiali  = @II_Acquisto_materiali_amm + @II_Acquisto_materiali_dip
SET @III_Acquisto_libri_periodici  = @III_Acquisto_libri_periodici_amm + @III_Acquisto_libri_periodici_dip
SET @IV_Acquisto_servizi  = @IV_Acquisto_servizi_amm + @IV_Acquisto_servizi_dip
SET @V_Costi_godimento_beni  = @V_Costi_godimento_beni_amm + @V_Costi_godimento_beni_dip
SET @VI_Altri_costi_generali  = @VI_Altri_costi_generali_amm + @VI_Altri_costi_generali_dip
SET @1_Utenze_canoni  = @1_Utenze_canoni_amm + @1_Utenze_canoni_dip
SET @2_Manutenzione_ordinaria  = @2_Manutenzione_ordinaria_amm + @2_Manutenzione_ordinaria_dip
SET @3_Manutenzione_straordinaria  = @3_Manutenzione_straordinaria_amm + @3_Manutenzione_straordinaria_dip
SET @4_Altri_costi_generali  = @4_Altri_costi_generali_amm + @4_Altri_costi_generali_dip
SET @DIFFERENZA_PROVENTI_E_COSTI_OPERATIVI  = @DIFFERENZA_PROVENTI_E_COSTI_OPERATIVI_amm + @DIFFERENZA_PROVENTI_E_COSTI_OPERATIVI_dip
SET @AMMORTAMENTI_SVALUTAZIONI  = @AMMORTAMENTI_SVALUTAZIONI_amm + @AMMORTAMENTI_SVALUTAZIONI_dip
SET @ACCANTONAMENTI_RISCHI_ONERI  = @ACCANTONAMENTI_RISCHI_ONERI_amm + @ACCANTONAMENTI_RISCHI_ONERI_dip
SET @ALTRI_ACCANTONAMENTI  = @ALTRI_ACCANTONAMENTI_amm + @ALTRI_ACCANTONAMENTI_dip
SET @ONERI_DIVERSI_GESTIONE  = @ONERI_DIVERSI_GESTIONE_amm + @ONERI_DIVERSI_GESTIONE_dip
SET @I_Imposte_varie  = @I_Imposte_varie_amm + @I_Imposte_varie_dip
SET @II_Altri_oneri  = @II_Altri_oneri_amm + @II_Altri_oneri_dip
SET @III_Trasferimenti_correnti  = @III_Trasferimenti_correnti_amm + @III_Trasferimenti_correnti_dip
SET @IV_Trasferimenti_investimenti  = @IV_Trasferimenti_investimenti_amm + @IV_Trasferimenti_investimenti_dip
SET @PROVENTI_E_ONERI_FINANZIARI  = @PROVENTI_E_ONERI_FINANZIARI_amm + @PROVENTI_E_ONERI_FINANZIARI_dip
SET @proventi  = @proventi_amm + @proventi_dip
SET @oneri  = @oneri_amm + @oneri_dip
SET @RETTIFICHE_DI_VALORE_DI_ATTIVITA_FINANZIARIE  = @RETTIFICHE_DI_VALORE_DI_ATTIVITA_FINANZIARIE_amm + @RETTIFICHE_DI_VALORE_DI_ATTIVITA_FINANZIARIE_dip
SET @PROVENTI_ONERI_STRAORDINARI  = @PROVENTI_ONERI_STRAORDINARI_amm + @PROVENTI_ONERI_STRAORDINARI_dip
SET @1_PROVENTI_STRAORDINARI  = @1_PROVENTI_STRAORDINARI_amm + @1_PROVENTI_STRAORDINARI_dip
SET @2_ONERI_STRAORDINARI  = @2_ONERI_STRAORDINARI_amm + @2_ONERI_STRAORDINARI_dip
SET @IMPOSTE_TASSE  = @IMPOSTE_TASSE_amm + @IMPOSTE_TASSE_dip

/*TOTALI ANNO 2*/

SET @I_PROVENTI_PROPRI_ANNO_2  = @I_PROVENTI_PROPRI_ANNO_2_amm + @I_PROVENTI_PROPRI_ANNO_2_dip
SET @II_CONTRIBUTI_ANNO_2  = @II_CONTRIBUTI_ANNO_2_amm + @II_CONTRIBUTI_ANNO_2_dip
SET @III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE_ANNO_2  = @III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE_ANNO_2_amm + @III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE_ANNO_2_dip
SET @IV_PROVENTI_PER_GESTIONE_DIRETTA_ANNO_2  = @IV_PROVENTI_PER_GESTIONE_DIRETTA_ANNO_2_amm + @IV_PROVENTI_PER_GESTIONE_DIRETTA_ANNO_2_dip
SET @V_ALTRI_PROVENTI_ANNO_2  = @V_ALTRI_PROVENTI_ANNO_2_amm + @V_ALTRI_PROVENTI_ANNO_2_dip
SET @VI_VARIAZIONE_LAVORI_IN_CORSO_ANNO_2  = @VI_VARIAZIONE_LAVORI_IN_CORSO_ANNO_2_amm + @VI_VARIAZIONE_LAVORI_IN_CORSO_ANNO_2_dip
SET @VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI_ANNO_2  = @VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI_ANNO_2_amm + @VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI_ANNO_2_dip
SET @PROVENTIOPERATIVI_ANNO_2  = @PROVENTIOPERATIVI_ANNO_2_amm + @PROVENTIOPERATIVI_ANNO_2_dip
SET @COSTI_OPERATIVI_ANNO_2  = @COSTI_OPERATIVI_ANNO_2_amm + @COSTI_OPERATIVI_ANNO_2_dip
SET @COSTI_SPECIFICI_ANNO_2  = @COSTI_SPECIFICI_ANNO_2_amm + @COSTI_SPECIFICI_ANNO_2_dip
SET @I_SOSTEGNO_AGLI_STUDENTI_ANNO_2  = @I_SOSTEGNO_AGLI_STUDENTI_ANNO_2_amm + @I_SOSTEGNO_AGLI_STUDENTI_ANNO_2_dip
SET @1_Interventi_favore_degli_studenti_ANNO_2  = @1_Interventi_favore_degli_studenti_ANNO_2_amm + @1_Interventi_favore_degli_studenti_ANNO_2_dip
SET @2_Borse_di_studio_ANNO_2  = @2_Borse_di_studio_ANNO_2_amm + @2_Borse_di_studio_ANNO_2_dip
SET @II_Interventi_diritto_allo_studio_ANNO_2  = @II_Interventi_diritto_allo_studio_ANNO_2_amm + @II_Interventi_diritto_allo_studio_ANNO_2_dip
SET @III_Sostegno_alla_ricerca_ANNO_2  = @III_Sostegno_alla_ricerca_ANNO_2_amm + @III_Sostegno_alla_ricerca_ANNO_2_dip
SET @IV_Personale_dedicato_alla_ricerca_ANNO_2  = @IV_Personale_dedicato_alla_ricerca_ANNO_2_amm + @IV_Personale_dedicato_alla_ricerca_ANNO_2_dip
SET @1_Docenti_ANNO_2  = @1_Docenti_ANNO_2_amm + @1_Docenti_ANNO_2_dip
SET @2_Ricercatori_ANNO_2  = @2_Ricercatori_ANNO_2_amm + @2_Ricercatori_ANNO_2_dip
SET @3_Ricercatori_a_tempo_determinato_ANNO_2  = @3_Ricercatori_a_tempo_determinato_ANNO_2_amm + @3_Ricercatori_a_tempo_determinato_ANNO_2_dip
SET @4_Collaborazioni_scientifiche_ANNO_2  = @4_Collaborazioni_scientifiche_ANNO_2_amm + @4_Collaborazioni_scientifiche_ANNO_2_dip
SET @5_Docenti_contratto_ANNO_2  = @5_Docenti_contratto_ANNO_2_amm + @5_Docenti_contratto_ANNO_2_dip
SET @6_Esperti_linguistici_ANNO_2  = @6_Esperti_linguistici_ANNO_2_amm + @6_Esperti_linguistici_ANNO_2_dip
SET @7_Altro_personale_dedicato_alla_ricerca_didattica_ANNO_2  = @7_Altro_personale_dedicato_alla_ricerca_didattica_ANNO_2_amm + @7_Altro_personale_dedicato_alla_ricerca_didattica_ANNO_2_dip
SET @8_Missioni_personale_dedicato_alla_didattica_ANNO_2  = @8_Missioni_personale_dedicato_alla_didattica_ANNO_2_amm + @8_Missioni_personale_dedicato_alla_didattica_ANNO_2_dip
SET @9_Altri_oneri_personale_ANNO_2  = @9_Altri_oneri_personale_ANNO_2_amm + @9_Altri_oneri_personale_ANNO_2_dip
SET @V_Acquisto_materiale_ANNO_2  = @V_Acquisto_materiale_ANNO_2_amm + @V_Acquisto_materiale_ANNO_2_dip
SET @VI_Trasferimenti_ANNO_2  = @VI_Trasferimenti_ANNO_2_amm + @VI_Trasferimenti_ANNO_2_dip
SET @VII_Altri_costi_specifici_ANNO_2  = @VII_Altri_costi_specifici_ANNO_2_amm + @VII_Altri_costi_specifici_ANNO_2_dip
SET @COSTI_GENERALI_ANNO_2  = @COSTI_GENERALI_ANNO_2_amm + @COSTI_GENERALI_ANNO_2_dip
SET @I_Personale_tecnicoamministrativo_ANNO_2  = @I_Personale_tecnicoamministrativo_ANNO_2_amm + @I_Personale_tecnicoamministrativo_ANNO_2_dip
SET @II_Acquisto_materiali_ANNO_2  = @II_Acquisto_materiali_ANNO_2_amm + @II_Acquisto_materiali_ANNO_2_dip
SET @III_Acquisto_libri_periodici_ANNO_2  = @III_Acquisto_libri_periodici_ANNO_2_amm + @III_Acquisto_libri_periodici_ANNO_2_dip
SET @IV_Acquisto_servizi_ANNO_2  = @IV_Acquisto_servizi_ANNO_2_amm + @IV_Acquisto_servizi_ANNO_2_dip
SET @V_Costi_godimento_beni_ANNO_2  = @V_Costi_godimento_beni_ANNO_2_amm + @V_Costi_godimento_beni_ANNO_2_dip
SET @VI_Altri_costi_generali_ANNO_2  = @VI_Altri_costi_generali_ANNO_2_amm + @VI_Altri_costi_generali_ANNO_2_dip
SET @1_Utenze_canoni_ANNO_2  = @1_Utenze_canoni_ANNO_2_amm + @1_Utenze_canoni_ANNO_2_dip
SET @2_Manutenzione_ordinaria_ANNO_2  = @2_Manutenzione_ordinaria_ANNO_2_amm + @2_Manutenzione_ordinaria_ANNO_2_dip
SET @3_Manutenzione_straordinaria_ANNO_2  = @3_Manutenzione_straordinaria_ANNO_2_amm + @3_Manutenzione_straordinaria_ANNO_2_dip
SET @4_Altri_costi_generali_ANNO_2  = @4_Altri_costi_generali_ANNO_2_amm + @4_Altri_costi_generali_ANNO_2_dip
SET @DIFFERENZA_PROVENTI_E_COSTI_OPERATIVI_ANNO_2  = @DIFFERENZA_PROVENTI_E_COSTI_OPERATIVI_ANNO_2_amm + @DIFFERENZA_PROVENTI_E_COSTI_OPERATIVI_ANNO_2_dip
SET @AMMORTAMENTI_SVALUTAZIONI_ANNO_2  = @AMMORTAMENTI_SVALUTAZIONI_ANNO_2_amm + @AMMORTAMENTI_SVALUTAZIONI_ANNO_2_dip
SET @ACCANTONAMENTI_RISCHI_ONERI_ANNO_2  = @ACCANTONAMENTI_RISCHI_ONERI_ANNO_2_amm + @ACCANTONAMENTI_RISCHI_ONERI_ANNO_2_dip
SET @ALTRI_ACCANTONAMENTI_ANNO_2  = @ALTRI_ACCANTONAMENTI_ANNO_2_amm + @ALTRI_ACCANTONAMENTI_ANNO_2_dip
SET @ONERI_DIVERSI_GESTIONE_ANNO_2  = @ONERI_DIVERSI_GESTIONE_ANNO_2_amm + @ONERI_DIVERSI_GESTIONE_ANNO_2_dip
SET @I_Imposte_varie_ANNO_2  = @I_Imposte_varie_ANNO_2_amm + @I_Imposte_varie_ANNO_2_dip
SET @II_Altri_oneri_ANNO_2  = @II_Altri_oneri_ANNO_2_amm + @II_Altri_oneri_ANNO_2_dip
SET @III_Trasferimenti_correnti_ANNO_2  = @III_Trasferimenti_correnti_ANNO_2_amm + @III_Trasferimenti_correnti_ANNO_2_dip
SET @IV_Trasferimenti_investimenti_ANNO_2  = @IV_Trasferimenti_investimenti_ANNO_2_amm + @IV_Trasferimenti_investimenti_ANNO_2_dip
SET @PROVENTI_E_ONERI_FINANZIARI_ANNO_2  = @PROVENTI_E_ONERI_FINANZIARI_ANNO_2_amm + @PROVENTI_E_ONERI_FINANZIARI_ANNO_2_dip
SET @proventi_ANNO_2  = @proventi_ANNO_2_amm + @proventi_ANNO_2_dip
SET @oneri_ANNO_2  = @oneri_ANNO_2_amm + @oneri_ANNO_2_dip
SET @RETTIFICHE_DI_VALORE_DI_ATTIVITA_FINANZIARIE_ANNO_2  = @RETTIFICHE_DI_VALORE_DI_ATTIVITA_FINANZIARIE_ANNO_2_amm + @RETTIFICHE_DI_VALORE_DI_ATTIVITA_FINANZIARIE_ANNO_2_dip
SET @PROVENTI_ONERI_STRAORDINARI_ANNO_2  = @PROVENTI_ONERI_STRAORDINARI_ANNO_2_amm + @PROVENTI_ONERI_STRAORDINARI_ANNO_2_dip
SET @1_PROVENTI_STRAORDINARI_ANNO_2  = @1_PROVENTI_STRAORDINARI_ANNO_2_amm + @1_PROVENTI_STRAORDINARI_ANNO_2_dip
SET @2_ONERI_STRAORDINARI_ANNO_2  = @2_ONERI_STRAORDINARI_ANNO_2_amm + @2_ONERI_STRAORDINARI_ANNO_2_dip
SET @IMPOSTE_TASSE_ANNO_2  = @IMPOSTE_TASSE_ANNO_2_amm + @IMPOSTE_TASSE_ANNO_2_dip

/*TOTALI ANNO 3*/

SET @I_PROVENTI_PROPRI_ANNO_3  = @I_PROVENTI_PROPRI_ANNO_3_amm  + @I_PROVENTI_PROPRI_ANNO_3_dip
SET @II_CONTRIBUTI_ANNO_3  = @II_CONTRIBUTI_ANNO_3_amm  + @II_CONTRIBUTI_ANNO_3_dip
SET @III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE_ANNO_3  = @III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE_ANNO_3_amm  + @III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE_ANNO_3_dip
SET @IV_PROVENTI_PER_GESTIONE_DIRETTA_ANNO_3  = @IV_PROVENTI_PER_GESTIONE_DIRETTA_ANNO_3_amm  + @IV_PROVENTI_PER_GESTIONE_DIRETTA_ANNO_3_dip
SET @V_ALTRI_PROVENTI_ANNO_3  = @V_ALTRI_PROVENTI_ANNO_3_amm  + @V_ALTRI_PROVENTI_ANNO_3_dip
SET @VI_VARIAZIONE_LAVORI_IN_CORSO_ANNO_3  = @VI_VARIAZIONE_LAVORI_IN_CORSO_ANNO_3_amm  + @VI_VARIAZIONE_LAVORI_IN_CORSO_ANNO_3_dip
SET @VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI_ANNO_3  = @VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI_ANNO_3_amm  + @VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI_ANNO_3_dip
SET @PROVENTIOPERATIVI_ANNO_3  = @PROVENTIOPERATIVI_ANNO_3_amm  + @PROVENTIOPERATIVI_ANNO_3_dip
SET @COSTI_OPERATIVI_ANNO_3  = @COSTI_OPERATIVI_ANNO_3_amm  + @COSTI_OPERATIVI_ANNO_3_dip
SET @COSTI_SPECIFICI_ANNO_3  = @COSTI_SPECIFICI_ANNO_3_amm  + @COSTI_SPECIFICI_ANNO_3_dip
SET @I_SOSTEGNO_AGLI_STUDENTI_ANNO_3  = @I_SOSTEGNO_AGLI_STUDENTI_ANNO_3_amm  + @I_SOSTEGNO_AGLI_STUDENTI_ANNO_3_dip
SET @1_Interventi_favore_degli_studenti_ANNO_3  = @1_Interventi_favore_degli_studenti_ANNO_3_amm  + @1_Interventi_favore_degli_studenti_ANNO_3_dip
SET @2_Borse_di_studio_ANNO_3  = @2_Borse_di_studio_ANNO_3_amm  + @2_Borse_di_studio_ANNO_3_dip
SET @II_Interventi_diritto_allo_studio_ANNO_3  = @II_Interventi_diritto_allo_studio_ANNO_3_amm  + @II_Interventi_diritto_allo_studio_ANNO_3_dip
SET @III_Sostegno_alla_ricerca_ANNO_3  = @III_Sostegno_alla_ricerca_ANNO_3_amm  + @III_Sostegno_alla_ricerca_ANNO_3_dip
SET @IV_Personale_dedicato_alla_ricerca_ANNO_3  = @IV_Personale_dedicato_alla_ricerca_ANNO_3_amm  + @IV_Personale_dedicato_alla_ricerca_ANNO_3_dip
SET @1_Docenti_ANNO_3  = @1_Docenti_ANNO_3_amm  + @1_Docenti_ANNO_3_dip
SET @2_Ricercatori_ANNO_3  = @2_Ricercatori_ANNO_3_amm  + @2_Ricercatori_ANNO_3_dip
SET @3_Ricercatori_a_tempo_determinato_ANNO_3  = @3_Ricercatori_a_tempo_determinato_ANNO_3_amm  + @3_Ricercatori_a_tempo_determinato_ANNO_3_dip
SET @4_Collaborazioni_scientifiche_ANNO_3  = @4_Collaborazioni_scientifiche_ANNO_3_amm  + @4_Collaborazioni_scientifiche_ANNO_3_dip
SET @5_Docenti_contratto_ANNO_3  = @5_Docenti_contratto_ANNO_3_amm  + @5_Docenti_contratto_ANNO_3_dip
SET @6_Esperti_linguistici_ANNO_3  = @6_Esperti_linguistici_ANNO_3_amm  + @6_Esperti_linguistici_ANNO_3_dip
SET @7_Altro_personale_dedicato_alla_ricerca_didattica_ANNO_3  = @7_Altro_personale_dedicato_alla_ricerca_didattica_ANNO_3_amm  + @7_Altro_personale_dedicato_alla_ricerca_didattica_ANNO_3_dip
SET @8_Missioni_personale_dedicato_alla_didattica_ANNO_3  = @8_Missioni_personale_dedicato_alla_didattica_ANNO_3_amm  + @8_Missioni_personale_dedicato_alla_didattica_ANNO_3_dip
SET @9_Altri_oneri_personale_ANNO_3  = @9_Altri_oneri_personale_ANNO_3_amm  + @9_Altri_oneri_personale_ANNO_3_dip
SET @V_Acquisto_materiale_ANNO_3  = @V_Acquisto_materiale_ANNO_3_amm  + @V_Acquisto_materiale_ANNO_3_dip
SET @VI_Trasferimenti_ANNO_3  = @VI_Trasferimenti_ANNO_3_amm  + @VI_Trasferimenti_ANNO_3_dip
SET @VII_Altri_costi_specifici_ANNO_3  = @VII_Altri_costi_specifici_ANNO_3_amm  + @VII_Altri_costi_specifici_ANNO_3_dip
SET @COSTI_GENERALI_ANNO_3  = @COSTI_GENERALI_ANNO_3_amm  + @COSTI_GENERALI_ANNO_3_dip
SET @I_Personale_tecnicoamministrativo_ANNO_3  = @I_Personale_tecnicoamministrativo_ANNO_3_amm  + @I_Personale_tecnicoamministrativo_ANNO_3_dip
SET @II_Acquisto_materiali_ANNO_3  = @II_Acquisto_materiali_ANNO_3_amm  + @II_Acquisto_materiali_ANNO_3_dip
SET @III_Acquisto_libri_periodici_ANNO_3  = @III_Acquisto_libri_periodici_ANNO_3_amm  + @III_Acquisto_libri_periodici_ANNO_3_dip
SET @IV_Acquisto_servizi_ANNO_3  = @IV_Acquisto_servizi_ANNO_3_amm  + @IV_Acquisto_servizi_ANNO_3_dip
SET @V_Costi_godimento_beni_ANNO_3  = @V_Costi_godimento_beni_ANNO_3_amm  + @V_Costi_godimento_beni_ANNO_3_dip
SET @VI_Altri_costi_generali_ANNO_3  = @VI_Altri_costi_generali_ANNO_3_amm  + @VI_Altri_costi_generali_ANNO_3_dip
SET @1_Utenze_canoni_ANNO_3  = @1_Utenze_canoni_ANNO_3_amm  + @1_Utenze_canoni_ANNO_3_dip
SET @2_Manutenzione_ordinaria_ANNO_3  = @2_Manutenzione_ordinaria_ANNO_3_amm  + @2_Manutenzione_ordinaria_ANNO_3_dip
SET @3_Manutenzione_straordinaria_ANNO_3  = @3_Manutenzione_straordinaria_ANNO_3_amm  + @3_Manutenzione_straordinaria_ANNO_3_dip
SET @4_Altri_costi_generali_ANNO_3  = @4_Altri_costi_generali_ANNO_3_amm  + @4_Altri_costi_generali_ANNO_3_dip
SET @DIFFERENZA_PROVENTI_E_COSTI_OPERATIVI_ANNO_3  = @DIFFERENZA_PROVENTI_E_COSTI_OPERATIVI_ANNO_3_amm  + @DIFFERENZA_PROVENTI_E_COSTI_OPERATIVI_ANNO_3_dip
SET @AMMORTAMENTI_SVALUTAZIONI_ANNO_3  = @AMMORTAMENTI_SVALUTAZIONI_ANNO_3_amm  + @AMMORTAMENTI_SVALUTAZIONI_ANNO_3_dip
SET @ACCANTONAMENTI_RISCHI_ONERI_ANNO_3  = @ACCANTONAMENTI_RISCHI_ONERI_ANNO_3_amm  + @ACCANTONAMENTI_RISCHI_ONERI_ANNO_3_dip
SET @ALTRI_ACCANTONAMENTI_ANNO_3  = @ALTRI_ACCANTONAMENTI_ANNO_3_amm  + @ALTRI_ACCANTONAMENTI_ANNO_3_dip
SET @ONERI_DIVERSI_GESTIONE_ANNO_3  = @ONERI_DIVERSI_GESTIONE_ANNO_3_amm  + @ONERI_DIVERSI_GESTIONE_ANNO_3_dip
SET @I_Imposte_varie_ANNO_3  = @I_Imposte_varie_ANNO_3_amm  + @I_Imposte_varie_ANNO_3_dip
SET @II_Altri_oneri_ANNO_3  = @II_Altri_oneri_ANNO_3_amm  + @II_Altri_oneri_ANNO_3_dip
SET @III_Trasferimenti_correnti_ANNO_3  = @III_Trasferimenti_correnti_ANNO_3_amm  + @III_Trasferimenti_correnti_ANNO_3_dip
SET @IV_Trasferimenti_investimenti_ANNO_3  = @IV_Trasferimenti_investimenti_ANNO_3_amm  + @IV_Trasferimenti_investimenti_ANNO_3_dip
SET @PROVENTI_E_ONERI_FINANZIARI_ANNO_3  = @PROVENTI_E_ONERI_FINANZIARI_ANNO_3_amm  + @PROVENTI_E_ONERI_FINANZIARI_ANNO_3_dip
SET @proventi_ANNO_3  = @proventi_ANNO_3_amm  + @proventi_ANNO_3_dip
SET @oneri_ANNO_3  = @oneri_ANNO_3_amm  + @oneri_ANNO_3_dip
SET @RETTIFICHE_DI_VALORE_DI_ATTIVITA_FINANZIARIE_ANNO_3  = @RETTIFICHE_DI_VALORE_DI_ATTIVITA_FINANZIARIE_ANNO_3_amm  + @RETTIFICHE_DI_VALORE_DI_ATTIVITA_FINANZIARIE_ANNO_3_dip
SET @PROVENTI_ONERI_STRAORDINARI_ANNO_3  = @PROVENTI_ONERI_STRAORDINARI_ANNO_3_amm  + @PROVENTI_ONERI_STRAORDINARI_ANNO_3_dip
SET @1_PROVENTI_STRAORDINARI_ANNO_3  = @1_PROVENTI_STRAORDINARI_ANNO_3_amm  + @1_PROVENTI_STRAORDINARI_ANNO_3_dip
SET @2_ONERI_STRAORDINARI_ANNO_3  = @2_ONERI_STRAORDINARI_ANNO_3_amm  + @2_ONERI_STRAORDINARI_ANNO_3_dip
SET @IMPOSTE_TASSE_ANNO_3  = @IMPOSTE_TASSE_ANNO_3_amm  + @IMPOSTE_TASSE_ANNO_3_dip

select
  @treasurer											as department,

    @I_PROVENTI_PROPRI_AMM	AS	'I_PROVENTI_PROPRI_AMM',
@II_CONTRIBUTI_AMM	AS	'II_CONTRIBUTI_AMM',
@III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE_AMM	AS	'III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE_AMM',
@IV_PROVENTI_PER_GESTIONE_DIRETTA_AMM	AS	'IV_PROVENTI_PER_GESTIONE_DIRETTA_AMM',
@V_ALTRI_PROVENTI_AMM	AS	'V_ALTRI_PROVENTI_AMM',
@VI_VARIAZIONE_LAVORI_IN_CORSO_AMM	AS	'VI_VARIAZIONE_LAVORI_IN_CORSO_AMM',
@VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI_AMM	AS	'VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI_AMM',
@PROVENTIOPERATIVI_AMM	AS	'PROVENTIOPERATIVI_AMM',
@COSTI_OPERATIVI_AMM	AS	'COSTI_OPERATIVI_AMM',
@COSTI_SPECIFICI_AMM	AS	'COSTI_SPECIFICI_AMM',
@I_SOSTEGNO_AGLI_STUDENTI_AMM	AS	'I_SOSTEGNO_AGLI_STUDENTI_AMM',
@1_Interventi_favore_degli_studenti_AMM	AS	'1_Interventi_favore_degli_studenti_AMM',
@2_Borse_di_studio_AMM	AS	'2_Borse_di_studio_AMM',
@II_Interventi_diritto_allo_studio_AMM	AS	'II_Interventi_diritto_allo_studio_AMM',
@III_Sostegno_alla_ricerca_AMM	AS	'III_Sostegno_alla_ricerca_AMM',
@IV_Personale_dedicato_alla_ricerca_AMM	AS	'IV_Personale_dedicato_alla_ricerca_AMM',
@1_Docenti_AMM	AS	'1_Docenti_AMM',
@2_Ricercatori_AMM	AS	'2_Ricercatori_AMM',
@3_Ricercatori_a_tempo_determinato_AMM	AS	'3_Ricercatori_a_tempo_determinato_AMM',
@4_Collaborazioni_scientifiche_AMM	AS	'4_Collaborazioni_scientifiche_AMM',
@5_Docenti_contratto_AMM	AS	'5_Docenti_contratto_AMM',
@6_Esperti_linguistici_AMM	AS	'6_Esperti_linguistici_AMM',
@7_Altro_personale_dedicato_alla_ricerca_didattica_AMM	AS	'7_Altro_personale_dedicato_alla_ricerca_didattica_AMM',
@8_Missioni_personale_dedicato_alla_didattica_AMM	AS	'8_Missioni_personale_dedicato_alla_didattica_AMM',
@9_Altri_oneri_personale_AMM	AS	'9_Altri_oneri_personale_AMM',
@V_Acquisto_materiale_AMM	AS	'V_Acquisto_materiale_AMM',
@VI_Trasferimenti_AMM	AS	'VI_Trasferimenti_AMM',
@VII_Altri_costi_specifici_AMM	AS	'VII_Altri_costi_specifici_AMM',
@COSTI_GENERALI_AMM	AS	'COSTI_GENERALI_AMM',
@I_Personale_tecnicoamministrativo_AMM	AS	'I_Personale_tecnicoamministrativo_AMM',
@II_Acquisto_materiali_AMM	AS	'II_Acquisto_materiali_AMM',
@III_Acquisto_libri_periodici_AMM	AS	'III_Acquisto_libri_periodici_AMM',
@IV_Acquisto_servizi_AMM	AS	'IV_Acquisto_servizi_AMM',
@V_Costi_godimento_beni_AMM	AS	'V_Costi_godimento_beni_AMM',
@VI_Altri_costi_generali_AMM	AS	'VI_Altri_costi_generali_AMM',
@1_Utenze_canoni_AMM	AS	'1_Utenze_canoni_AMM',
@2_Manutenzione_ordinaria_AMM	AS	'2_Manutenzione_ordinaria_AMM',
@3_Manutenzione_straordinaria_AMM	AS	'3_Manutenzione_straordinaria_AMM',
@4_Altri_costi_generali_AMM	AS	'4_Altri_costi_generali_AMM',
@DIFFERENZA_PROVENTI_E_COSTI_OPERATIVI_AMM	AS	'DIFFERENZA_PROVENTI_E_COSTI_OPERATIVI_AMM',
@AMMORTAMENTI_SVALUTAZIONI_AMM	AS	'AMMORTAMENTI_SVALUTAZIONI_AMM',
@ACCANTONAMENTI_RISCHI_ONERI_AMM	AS	'ACCANTONAMENTI_RISCHI_ONERI_AMM',
@ALTRI_ACCANTONAMENTI_AMM	AS	'ALTRI_ACCANTONAMENTI_AMM',
@ONERI_DIVERSI_GESTIONE_AMM	AS	'ONERI_DIVERSI_GESTIONE_AMM',
@I_Imposte_varie_AMM	AS	'I_Imposte_varie_AMM',
@II_Altri_oneri_AMM	AS	'II_Altri_oneri_AMM',
@III_Trasferimenti_correnti_AMM	AS	'III_Trasferimenti_correnti_AMM',
@IV_Trasferimenti_investimenti_AMM	AS	'IV_Trasferimenti_investimenti_AMM',
@PROVENTI_E_ONERI_FINANZIARI_AMM	AS	'PROVENTI_E_ONERI_FINANZIARI_AMM',
@proventi_AMM	AS	'proventi_AMM',
@oneri_AMM	AS	'oneri_AMM',
@RETTIFICHE_DI_VALORE_DI_ATTIVITA_FINANZIARIE_AMM	AS	'RETTIFICHE_DI_VALORE_DI_ATTIVITA_FINANZIARIE_AMM',
@PROVENTI_ONERI_STRAORDINARI_AMM	AS	'PROVENTI_ONERI_STRAORDINARI_AMM',
@1_PROVENTI_STRAORDINARI_AMM	AS	'1_PROVENTI_STRAORDINARI_AMM',
@2_ONERI_STRAORDINARI_AMM	AS	'2_ONERI_STRAORDINARI_AMM',
@IMPOSTE_TASSE_AMM	AS	'IMPOSTE_TASSE_AMM',


  @I_PROVENTI_PROPRI_DIP	AS	'I_PROVENTI_PROPRI_DIP',
@II_CONTRIBUTI_DIP	AS	'II_CONTRIBUTI_DIP',
@III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE_DIP	AS	'III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE_DIP',
@IV_PROVENTI_PER_GESTIONE_DIRETTA_DIP	AS	'IV_PROVENTI_PER_GESTIONE_DIRETTA_DIP',
@V_ALTRI_PROVENTI_DIP	AS	'V_ALTRI_PROVENTI_DIP',
@VI_VARIAZIONE_LAVORI_IN_CORSO_DIP	AS	'VI_VARIAZIONE_LAVORI_IN_CORSO_DIP',
@VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI_DIP	AS	'VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI_DIP',
@PROVENTIOPERATIVI_DIP	AS	'PROVENTIOPERATIVI_DIP',
@COSTI_OPERATIVI_DIP	AS	'COSTI_OPERATIVI_DIP',
@COSTI_SPECIFICI_DIP	AS	'COSTI_SPECIFICI_DIP',
@I_SOSTEGNO_AGLI_STUDENTI_DIP	AS	'I_SOSTEGNO_AGLI_STUDENTI_DIP',
@1_Interventi_favore_degli_studenti_DIP	AS	'1_Interventi_favore_degli_studenti_DIP',
@2_Borse_di_studio_DIP	AS	'2_Borse_di_studio_DIP',
@II_Interventi_diritto_allo_studio_DIP	AS	'II_Interventi_diritto_allo_studio_DIP',
@III_Sostegno_alla_ricerca_DIP	AS	'III_Sostegno_alla_ricerca_DIP',
@IV_Personale_dedicato_alla_ricerca_DIP	AS	'IV_Personale_dedicato_alla_ricerca_DIP',
@1_Docenti_DIP	AS	'1_Docenti_DIP',
@2_Ricercatori_DIP	AS	'2_Ricercatori_DIP',
@3_Ricercatori_a_tempo_determinato_DIP	AS	'3_Ricercatori_a_tempo_determinato_DIP',
@4_Collaborazioni_scientifiche_DIP	AS	'4_Collaborazioni_scientifiche_DIP',
@5_Docenti_contratto_DIP	AS	'5_Docenti_contratto_DIP',
@6_Esperti_linguistici_DIP	AS	'6_Esperti_linguistici_DIP',
@7_Altro_personale_dedicato_alla_ricerca_didattica_DIP	AS	'7_Altro_personale_dedicato_alla_ricerca_didattica_DIP',
@8_Missioni_personale_dedicato_alla_didattica_DIP	AS	'8_Missioni_personale_dedicato_alla_didattica_DIP',
@9_Altri_oneri_personale_DIP	AS	'9_Altri_oneri_personale_DIP',
@V_Acquisto_materiale_DIP	AS	'V_Acquisto_materiale_DIP',
@VI_Trasferimenti_DIP	AS	'VI_Trasferimenti_DIP',
@VII_Altri_costi_specifici_DIP	AS	'VII_Altri_costi_specifici_DIP',
@COSTI_GENERALI_DIP	AS	'COSTI_GENERALI_DIP',
@I_Personale_tecnicoamministrativo_DIP	AS	'I_Personale_tecnicoamministrativo_DIP',
@II_Acquisto_materiali_DIP	AS	'II_Acquisto_materiali_DIP',
@III_Acquisto_libri_periodici_DIP	AS	'III_Acquisto_libri_periodici_DIP',
@IV_Acquisto_servizi_DIP	AS	'IV_Acquisto_servizi_DIP',
@V_Costi_godimento_beni_DIP	AS	'V_Costi_godimento_beni_DIP',
@VI_Altri_costi_generali_DIP	AS	'VI_Altri_costi_generali_DIP',
@1_Utenze_canoni_DIP	AS	'1_Utenze_canoni_DIP',
@2_Manutenzione_ordinaria_DIP	AS	'2_Manutenzione_ordinaria_DIP',
@3_Manutenzione_straordinaria_DIP	AS	'3_Manutenzione_straordinaria_DIP',
@4_Altri_costi_generali_DIP	AS	'4_Altri_costi_generali_DIP',
@DIFFERENZA_PROVENTI_E_COSTI_OPERATIVI_DIP	AS	'DIFFERENZA_PROVENTI_E_COSTI_OPERATIVI_DIP',
@AMMORTAMENTI_SVALUTAZIONI_DIP	AS	'AMMORTAMENTI_SVALUTAZIONI_DIP',
@ACCANTONAMENTI_RISCHI_ONERI_DIP	AS	'ACCANTONAMENTI_RISCHI_ONERI_DIP',
@ALTRI_ACCANTONAMENTI_DIP	AS	'ALTRI_ACCANTONAMENTI_DIP',
@ONERI_DIVERSI_GESTIONE_DIP	AS	'ONERI_DIVERSI_GESTIONE_DIP',
@I_Imposte_varie_DIP	AS	'I_Imposte_varie_DIP',
@II_Altri_oneri_DIP	AS	'II_Altri_oneri_DIP',
@III_Trasferimenti_correnti_DIP	AS	'III_Trasferimenti_correnti_DIP',
@IV_Trasferimenti_investimenti_DIP	AS	'IV_Trasferimenti_investimenti_DIP',
@PROVENTI_E_ONERI_FINANZIARI_DIP	AS	'PROVENTI_E_ONERI_FINANZIARI_DIP',
@proventi_DIP	AS	'proventi_DIP',
@oneri_DIP	AS	'oneri_DIP',
@RETTIFICHE_DI_VALORE_DI_ATTIVITA_FINANZIARIE_DIP	AS	'RETTIFICHE_DI_VALORE_DI_ATTIVITA_FINANZIARIE_DIP',
@PROVENTI_ONERI_STRAORDINARI_DIP	AS	'PROVENTI_ONERI_STRAORDINARI_DIP',
@1_PROVENTI_STRAORDINARI_DIP	AS	'1_PROVENTI_STRAORDINARI_DIP',
@2_ONERI_STRAORDINARI_DIP	AS	'2_ONERI_STRAORDINARI_DIP',
@IMPOSTE_TASSE_DIP	AS	'IMPOSTE_TASSE_DIP',



  /*Anno 1*/

  @I_PROVENTI_PROPRI  									as		  'I_PROVENTI_PROPRI',  
  @II_CONTRIBUTI   										as		  'II_CONTRIBUTI',   
  @III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE  			as		  'III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE', 
  @IV_PROVENTI_PER_GESTIONE_DIRETTA  					as		  'IV_PROVENTI_PER_GESTIONE_DIRETTA', 
  @V_ALTRI_PROVENTI  									as		  'V_ALTRI_PROVENTI',  
  @VI_VARIAZIONE_LAVORI_IN_CORSO  						as		  'VI_VARIAZIONE_LAVORI_IN_CORSO', 
  @VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI  				as		  'VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI', 
  @PROVENTIOPERATIVI  									as		  'PROVENTIOPERATIVI', 
  @COSTI_OPERATIVI   									as		  'COSTI_OPERATIVI',   
  @COSTI_SPECIFICI   									as		  'COSTI_SPECIFICI',   
  @I_SOSTEGNO_AGLI_STUDENTI   							as		  'I_SOSTEGNO_AGLI_STUDENTI',  
  @1_Interventi_favore_degli_studenti  					as		  '1_Interventi_favore_degli_studenti', 
  @2_Borse_di_studio  									as		  '2_Borse_di_studio', 
  @II_Interventi_diritto_allo_studio  					as		  'II_Interventi_diritto_allo_studio', 
  @III_Sostegno_alla_ricerca  							as		  'III_Sostegno_alla_ricerca',  
  @IV_Personale_dedicato_alla_ricerca  					as		  'IV_Personale_dedicato_alla_ricerca', 
  @1_Docenti  											as		  '1_Docenti', 
  @2_Ricercatori  										as		  '2_Ricercatori', 
  @3_Ricercatori_a_tempo_determinato  					as		  '3_Ricercatori_a_tempo_determinato', 
  @4_Collaborazioni_scientifiche  						as		  '4_Collaborazioni_scientifiche', 
  @5_Docenti_contratto   								as		  '5_Docenti_contratto',  
  @6_Esperti_linguistici								as		  '6_Esperti_linguistici',   
  @7_Altro_personale_dedicato_alla_ricerca_didattica  	as		  '7_Altro_personale_dedicato_alla_ricerca_didattica', 
  @8_Missioni_personale_dedicato_alla_didattica  		as		  '8_Missioni_personale_dedicato_alla_didattica', 
  @9_Altri_oneri_personale  							as		  '9_Altri_oneri_personale', 
  @V_Acquisto_materiale  								as		  'V_Acquisto_materiale', 
  @VI_Trasferimenti  									as		  'VI_Trasferimenti', 
  @VII_Altri_costi_specifici   							as		  'VII_Altri_costi_specifici',  
  @COSTI_GENERALI   									as		  'COSTI_GENERALI',  
  @I_Personale_tecnicoamministrativo   					as		  'I_Personale_tecnicoamministrativo',  
  @II_Acquisto_materiali   								as		  'II_Acquisto_materiali',  
  @III_Acquisto_libri_periodici  						as		  'III_Acquisto_libri_periodici', 
  @IV_Acquisto_servizi  								as		  'IV_Acquisto_servizi', 
  @V_Costi_godimento_beni  								as		  'V_Costi_godimento_beni', 
  @VI_Altri_costi_generali   							as		  'VI_Altri_costi_generali', 
  @1_Utenze_canoni   									as		  '1_Utenze_canoni',  
  @2_Manutenzione_ordinaria  							as		  '2_Manutenzione_ordinaria', 
  @3_Manutenzione_straordinaria  						as		  '3_Manutenzione_straordinaria', 
  @4_Altri_costi_generali  								as		  '4_Altri_costi_generali', 
  @DIFFERENZA_PROVENTI_E_COSTI_OPERATIVI   				as		  'DIFFERENZA_PROVENTI_E_COSTI_OPERATIVI',  
  @AMMORTAMENTI_SVALUTAZIONI   							as		  'AMMORTAMENTI_SVALUTAZIONI',
  @ACCANTONAMENTI_RISCHI_ONERI    						as		  'ACCANTONAMENTI_RISCHI_ONERI',
  @ALTRI_ACCANTONAMENTI   								as		  'ALTRI_ACCANTONAMENTI',
  @ONERI_DIVERSI_GESTIONE   							as		  'ONERI_DIVERSI_GESTIONE',   
  @I_Imposte_varie   									as		  'I_Imposte_varie',   
  @II_Altri_oneri   									as		  'II_Altri_oneri',   
  @III_Trasferimenti_correnti   						as		  'III_Trasferimenti_correnti',   
  @IV_Trasferimenti_investimenti   						as		  'IV_Trasferimenti_investimenti',   
  @PROVENTI_E_ONERI_FINANZIARI   						as		  'PROVENTI_E_ONERI_FINANZIARI',   
  @proventi  											as		  'proventi',  
  @oneri  												as		  'oneri',  
  @RETTIFICHE_DI_VALORE_DI_ATTIVITA_FINANZIARIE   		as		  'RETTIFICHE_DI_VALORE_DI_ATTIVITA_FINANZIARIE',   
  @PROVENTI_ONERI_STRAORDINARI   						as		  'PROVENTI_ONERI_STRAORDINARI',   
  @1_PROVENTI_STRAORDINARI   							as		  '1_PROVENTI_STRAORDINARI',   
  @2_ONERI_STRAORDINARI									as		  '2_ONERI_STRAORDINARI',   
  @IMPOSTE_TASSE   										as		  'IMPOSTE_TASSE', 

  /*Anno 2*/

  @I_PROVENTI_PROPRI_ANNO_2  									as		  'I_PROVENTI_PROPRI_ANNO_2',  
  @II_CONTRIBUTI_ANNO_2    										as		  'II_CONTRIBUTI_ANNO_2',   
  @III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE_ANNO_2  				as		  'III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE_ANNO_2', 
  @IV_PROVENTI_PER_GESTIONE_DIRETTA_ANNO_2   					as		  'IV_PROVENTI_PER_GESTIONE_DIRETTA_ANNO_2', 
  @V_ALTRI_PROVENTI_ANNO_2   									as		  'V_ALTRI_PROVENTI_ANNO_2',  
  @VI_VARIAZIONE_LAVORI_IN_CORSO_ANNO_2   						as		  'VI_VARIAZIONE_LAVORI_IN_CORSO_ANNO_2', 
  @VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI_ANNO_2   				as		  'VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI_ANNO_2', 
  @PROVENTIOPERATIVI_ANNO_2   									as		  'PROVENTIOPERATIVI_ANNO_2', 
  @COSTI_OPERATIVI_ANNO_2    									as		  'COSTI_OPERATIVI_ANNO_2',   
  @COSTI_SPECIFICI_ANNO_2    									as		  'COSTI_SPECIFICI_ANNO_2',   
  @I_SOSTEGNO_AGLI_STUDENTI_ANNO_2    							as		  'I_SOSTEGNO_AGLI_STUDENTI_ANNO_2',  
  @1_Interventi_favore_degli_studenti_ANNO_2   					as		  '1_Interventi_favore_degli_studenti_ANNO_2', 
  @2_Borse_di_studio_ANNO_2   									as		  '2_Borse_di_studio_ANNO_2', 
  @II_Interventi_diritto_allo_studio_ANNO_2   					as		  'II_Interventi_diritto_allo_studio_ANNO_2', 
  @III_Sostegno_alla_ricerca_ANNO_2   							as		  'III_Sostegno_alla_ricerca_ANNO_2',  
  @IV_Personale_dedicato_alla_ricerca_ANNO_2   					as		  'IV_Personale_dedicato_alla_ricerca_ANNO_2', 
  @1_Docenti_ANNO_2   											as		  '1_Docenti_ANNO_2', 
  @2_Ricercatori_ANNO_2   										as		  '2_Ricercatori_ANNO_2', 
  @3_Ricercatori_a_tempo_determinato_ANNO_2  					as		  '3_Ricercatori_a_tempo_determinato_ANNO_2', 
  @4_Collaborazioni_scientifiche_ANNO_2   						as		  '4_Collaborazioni_scientifiche_ANNO_2', 
  @5_Docenti_contratto_ANNO_2    								as		  '5_Docenti_contratto_ANNO_2',  
  @6_Esperti_linguistici_ANNO_2 								as		  '6_Esperti_linguistici_ANNO_2',   
  @7_Altro_personale_dedicato_alla_ricerca_didattica_ANNO_2   	as		  '7_Altro_personale_dedicato_alla_ricerca_didattica_ANNO_2', 
  @8_Missioni_personale_dedicato_alla_didattica_ANNO_2   		as		  '8_Missioni_personale_dedicato_alla_didattica_ANNO_2', 
  @9_Altri_oneri_personale_ANNO_2   							as		  '9_Altri_oneri_personale_ANNO_2', 
  @V_Acquisto_materiale_ANNO_2   								as		  'V_Acquisto_materiale_ANNO_2', 
  @VI_Trasferimenti_ANNO_2   									as		  'VI_Trasferimenti_ANNO_2', 
  @VII_Altri_costi_specifici_ANNO_2    							as		  'VII_Altri_costi_specifici_ANNO_2',  
  @COSTI_GENERALI_ANNO_2    									as		  'COSTI_GENERALI_ANNO_2',  
  @I_Personale_tecnicoamministrativo_ANNO_2    					as		  'I_Personale_tecnicoamministrativo_ANNO_2',  
  @II_Acquisto_materiali_ANNO_2    								as		  'II_Acquisto_materiali_ANNO_2',  
  @III_Acquisto_libri_periodici_ANNO_2   						as		  'III_Acquisto_libri_periodici_ANNO_2', 
  @IV_Acquisto_servizi_ANNO_2   								as		  'IV_Acquisto_servizi_ANNO_2', 
  @V_Costi_godimento_beni_ANNO_2   								as		  'V_Costi_godimento_beni_ANNO_2', 
  @VI_Altri_costi_generali_ANNO_2    							as		  'VI_Altri_costi_generali_ANNO_2', 
  @1_Utenze_canoni_ANNO_2    									as		  '1_Utenze_canoni_ANNO_2',  
  @2_Manutenzione_ordinaria_ANNO_2   							as		  '2_Manutenzione_ordinaria_ANNO_2', 
  @3_Manutenzione_straordinaria_ANNO_2   						as		  '3_Manutenzione_straordinaria_ANNO_2', 
  @4_Altri_costi_generali_ANNO_2   								as		  '4_Altri_costi_generali_ANNO_2', 
  @DIFFERENZA_PROVENTI_E_COSTI_OPERATIVI_ANNO_2    				as		  'DIFFERENZA_PROVENTI_E_COSTI_OPERATIVI_ANNO_2',  
  @AMMORTAMENTI_SVALUTAZIONI_ANNO_2    							as		  'AMMORTAMENTI_SVALUTAZIONI',
  @ACCANTONAMENTI_RISCHI_ONERI_ANNO_2     						as		  'ACCANTONAMENTI_RISCHI_ONERI',
  @ALTRI_ACCANTONAMENTI_ANNO_2    								as		  'ALTRI_ACCANTONAMENTI',
  @ONERI_DIVERSI_GESTIONE_ANNO_2    							as		  'ONERI_DIVERSI_GESTIONE_ANNO_2',   
  @I_Imposte_varie_ANNO_2    									as		  'I_Imposte_varie_ANNO_2',   
  @II_Altri_oneri_ANNO_2    									as		  'II_Altri_oneri_ANNO_2',   
  @III_Trasferimenti_correnti_ANNO_2    						as		  'III_Trasferimenti_correnti_ANNO_2',   
  @IV_Trasferimenti_investimenti_ANNO_2    						as		  'IV_Trasferimenti_investimenti_ANNO_2',   
  @PROVENTI_E_ONERI_FINANZIARI_ANNO_2    						as		  'PROVENTI_E_ONERI_FINANZIARI_ANNO_2',   
  @proventi_ANNO_2   											as		  'proventi_ANNO_2',  
  @oneri_ANNO_2   												as		  'oneri_ANNO_2',  
  @RETTIFICHE_DI_VALORE_DI_ATTIVITA_FINANZIARIE_ANNO_2    		as		  'RETTIFICHE_DI_VALORE_DI_ATTIVITA_FINANZIARIE_ANNO_2',   
  @PROVENTI_ONERI_STRAORDINARI_ANNO_2    						as		  'PROVENTI_ONERI_STRAORDINARI_ANNO_2',   
  @1_PROVENTI_STRAORDINARI_ANNO_2    							as		  '1_PROVENTI_STRAORDINARI_ANNO_2',   
  @2_ONERI_STRAORDINARI_ANNO_2 									as		  '2_ONERI_STRAORDINARI_ANNO_2',   
  @IMPOSTE_TASSE_ANNO_2    										as		  'IMPOSTE_TASSE_ANNO_2',

  /*Anno 3*/

  @I_PROVENTI_PROPRI_ANNO_3  									as		  'I_PROVENTI_PROPRI_ANNO_3',  
  @II_CONTRIBUTI_ANNO_3    										as		  'II_CONTRIBUTI_ANNO_3',   
  @III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE_ANNO_3  				as		  'III_PROVENTI_PER_ATTIVITA_ASSISTENZIALE_ANNO_3', 
  @IV_PROVENTI_PER_GESTIONE_DIRETTA_ANNO_3   					as		  'IV_PROVENTI_PER_GESTIONE_DIRETTA_ANNO_3', 
  @V_ALTRI_PROVENTI_ANNO_3   									as		  'V_ALTRI_PROVENTI_ANNO_3',  
  @VI_VARIAZIONE_LAVORI_IN_CORSO_ANNO_3   						as		  'VI_VARIAZIONE_LAVORI_IN_CORSO_ANNO_3', 
  @VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI_ANNO_3   				as		  'VII_INCREMENTO_DELLE_IMMOBILIZZAZIONI_ANNO_3', 
  @PROVENTIOPERATIVI_ANNO_3   									as		  'PROVENTIOPERATIVI_ANNO_3', 
  @COSTI_OPERATIVI_ANNO_3    									as		  'COSTI_OPERATIVI_ANNO_3',   
  @COSTI_SPECIFICI_ANNO_3    									as		  'COSTI_SPECIFICI_ANNO_3',   
  @I_SOSTEGNO_AGLI_STUDENTI_ANNO_3    							as		  'I_SOSTEGNO_AGLI_STUDENTI_ANNO_3',  
  @1_Interventi_favore_degli_studenti_ANNO_3   					as		  '1_Interventi_favore_degli_studenti_ANNO_3', 
  @2_Borse_di_studio_ANNO_3   									as		  '2_Borse_di_studio_ANNO_3', 
  @II_Interventi_diritto_allo_studio_ANNO_3   					as		  'II_Interventi_diritto_allo_studio_ANNO_3', 
  @III_Sostegno_alla_ricerca_ANNO_3   							as		  'III_Sostegno_alla_ricerca_ANNO_3',  
  @IV_Personale_dedicato_alla_ricerca_ANNO_3   					as		  'IV_Personale_dedicato_alla_ricerca_ANNO_3', 
  @1_Docenti_ANNO_3   											as		  '1_Docenti_ANNO_3', 
  @2_Ricercatori_ANNO_3   										as		  '2_Ricercatori_ANNO_3', 
  @3_Ricercatori_a_tempo_determinato_ANNO_3  					as		  '3_Ricercatori_a_tempo_determinato_ANNO_3', 
  @4_Collaborazioni_scientifiche_ANNO_3   						as		  '4_Collaborazioni_scientifiche_ANNO_3', 
  @5_Docenti_contratto_ANNO_3    								as		  '5_Docenti_contratto_ANNO_3',  
  @6_Esperti_linguistici_ANNO_3 								as		  '6_Esperti_linguistici_ANNO_3',   
  @7_Altro_personale_dedicato_alla_ricerca_didattica_ANNO_3   	as		  '7_Altro_personale_dedicato_alla_ricerca_didattica_ANNO_3', 
  @8_Missioni_personale_dedicato_alla_didattica_ANNO_3   		as		  '8_Missioni_personale_dedicato_alla_didattica_ANNO_3', 
  @9_Altri_oneri_personale_ANNO_3   							as		  '9_Altri_oneri_personale_ANNO_3', 
  @V_Acquisto_materiale_ANNO_3   								as		  'V_Acquisto_materiale_ANNO_3', 
  @VI_Trasferimenti_ANNO_3   									as		  'VI_Trasferimenti_ANNO_3', 
  @VII_Altri_costi_specifici_ANNO_3    							as		  'VII_Altri_costi_specifici_ANNO_3',  
  @COSTI_GENERALI_ANNO_3    									as		  'COSTI_GENERALI_ANNO_3',  
  @I_Personale_tecnicoamministrativo_ANNO_3    					as		  'I_Personale_tecnicoamministrativo_ANNO_3',  
  @II_Acquisto_materiali_ANNO_3    								as		  'II_Acquisto_materiali_ANNO_3',  
  @III_Acquisto_libri_periodici_ANNO_3   						as		  'III_Acquisto_libri_periodici_ANNO_3', 
  @IV_Acquisto_servizi_ANNO_3   								as		  'IV_Acquisto_servizi_ANNO_3', 
  @V_Costi_godimento_beni_ANNO_3   								as		  'V_Costi_godimento_beni_ANNO_3', 
  @VI_Altri_costi_generali_ANNO_3    							as		  'VI_Altri_costi_generali_ANNO_3', 
  @1_Utenze_canoni_ANNO_3    									as		  '1_Utenze_canoni_ANNO_3',  
  @2_Manutenzione_ordinaria_ANNO_3   							as		  '2_Manutenzione_ordinaria_ANNO_3', 
  @3_Manutenzione_straordinaria_ANNO_3   						as		  '3_Manutenzione_straordinaria_ANNO_3', 
  @4_Altri_costi_generali_ANNO_3   								as		  '4_Altri_costi_generali_ANNO_3', 
  @DIFFERENZA_PROVENTI_E_COSTI_OPERATIVI_ANNO_3    				as		  'DIFFERENZA_PROVENTI_E_COSTI_OPERATIVI_ANNO_3',  
  @AMMORTAMENTI_SVALUTAZIONI_ANNO_3    							as		  'AMMORTAMENTI_SVALUTAZIONI',
  @ACCANTONAMENTI_RISCHI_ONERI_ANNO_3     						as		  'ACCANTONAMENTI_RISCHI_ONERI',
  @ALTRI_ACCANTONAMENTI_ANNO_3    								as		  'ALTRI_ACCANTONAMENTI',
  @ONERI_DIVERSI_GESTIONE_ANNO_3    							as		  'ONERI_DIVERSI_GESTIONE_ANNO_3',   
  @I_Imposte_varie_ANNO_3    									as		  'I_Imposte_varie_ANNO_3',   
  @II_Altri_oneri_ANNO_3    									as		  'II_Altri_oneri_ANNO_3',   
  @III_Trasferimenti_correnti_ANNO_3    						as		  'III_Trasferimenti_correnti_ANNO_3',   
  @IV_Trasferimenti_investimenti_ANNO_3    						as		  'IV_Trasferimenti_investimenti_ANNO_3',   
  @PROVENTI_E_ONERI_FINANZIARI_ANNO_3    						as		  'PROVENTI_E_ONERI_FINANZIARI_ANNO_3',   
  @proventi_ANNO_3   											as		  'proventi_ANNO_3',  
  @oneri_ANNO_3   												as		  'oneri_ANNO_3',  
  @RETTIFICHE_DI_VALORE_DI_ATTIVITA_FINANZIARIE_ANNO_3    		as		  'RETTIFICHE_DI_VALORE_DI_ATTIVITA_FINANZIARIE_ANNO_3',   
  @PROVENTI_ONERI_STRAORDINARI_ANNO_3    						as		  'PROVENTI_ONERI_STRAORDINARI_ANNO_3',   
  @1_PROVENTI_STRAORDINARI_ANNO_3    							as		  '1_PROVENTI_STRAORDINARI_ANNO_3',   
  @2_ONERI_STRAORDINARI_ANNO_3 									as		  '2_ONERI_STRAORDINARI_ANNO_3',   
  @IMPOSTE_TASSE_ANNO_3    										as		  'IMPOSTE_TASSE_ANNO_3'	

				
END

