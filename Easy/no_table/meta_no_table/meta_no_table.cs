/*
    Easy
    Copyright (C) 2020 Universit√† degli Studi di Catania (www.unict.it)
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

using System;
using System.Collections.Generic;
using System.Text;
using metadatalibrary;
using metaeasylibrary;
using System.Windows.Forms;

namespace meta_no_table {
    public class Meta_no_table : Meta_easydata {
        public Meta_no_table(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "no_table") {
	        
            EditTypes.Add("default");
            EditTypes.Add("alert");
            EditTypes.Add("advice");
            EditTypes.Add("noduplicati");
            EditTypes.Add("deleteunusable");
            EditTypes.Add("wizardmerge");
            EditTypes.Add("formconverter");
            EditTypes.Add("f24ep");
            ListingTypes.Add("default");
            ListingTypes.Add("modulegroup");
            ListingTypes.Add("module");
            EditTypes.Add("wizardscaricomagazzino");
            EditTypes.Add("match_storedprocedure");
            EditTypes.Add("flowchart_massive");
            EditTypes.Add("checkpatrimonio");
            EditTypes.Add("transfprevinbudget");
            EditTypes.Add("undo_trasf_nuoveanagrafiche");
            EditTypes.Add("transfpaydisposition");
            EditTypes.Add("flussostudenti"); // sar‡ eliminato e sostituito dai successivi edit type
            EditTypes.Add("importaflussi");  
            EditTypes.Add("elaboracrediti");
            EditTypes.Add("elaboraincassiconsospesi");
            EditTypes.Add("elaboraincassisenzasospesi");
            EditTypes.Add("entry_verifica");
            EditTypes.Add("wizardassetgrantdetail");
            EditTypes.Add("ivapay");
            EditTypes.Add("invoicecomunicate");
            EditTypes.Add("unifydip");
            EditTypes.Add("consolidclientiforn");
            EditTypes.Add("elencoclientiforn");
            EditTypes.Add("esitomandati");
            EditTypes.Add("esitoreversali");
            EditTypes.Add("expbank");
            EditTypes.Add("cud");
            EditTypes.Add("iban");
            EditTypes.Add("wizanagrafiche");
            EditTypes.Add("noduplicati");
            EditTypes.Add("deleteunusable");
            EditTypes.Add("fillunified");
            EditTypes.Add("importazione");
            EditTypes.Add("fillunifiedtax");
            EditTypes.Add("trasflowchart");
            EditTypes.Add("epilogo");
            EditTypes.Add("apertura");
            EditTypes.Add("riparto");
            EditTypes.Add("rettifica");
            EditTypes.Add("integrazione");
            EditTypes.Add("rettifica_pluriennale");
			//EditTypes.Add("delete_rettifica_pluriennale");
			EditTypes.Add("rettifica_pluriennale_percentuale");
            EditTypes.Add("creascriptclass");
            EditTypes.Add("listaclassi");
            EditTypes.Add("compattascritture");
            EditTypes.Add("unificaanagrafiche");
            EditTypes.Add("importanagrafichecsa");
            EditTypes.Add("flowchartcopy");
            EditTypes.Add("importazionefatture");
            EditTypes.Add("splitemens");
            EditTypes.Add("consolida");
            EditTypes.Add("rateo");
            EditTypes.Add("transfprevinbudget");
            EditTypes.Add("undo_trasf_nuoveanagrafiche");
            EditTypes.Add("transfpaydisposition");
            EditTypes.Add("travasa_budgetvariationinitial");
            EditTypes.Add("invoice_ssn");
			EditTypes.Add("no_table_esterometro");
			EditTypes.Add("calcola_integrazione_previsione");
			EditTypes.Add("scriptcomuni");
		}
        public override void DescribeColumns(System.Data.DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "modulegroup") {
                DescribeAColumn(T, "modulename", "Modulo", 1);
                DescribeAColumn(T, "groupname", "Gruppo", 2);
                return;
            }
            if (ListingType == "module") {
                DescribeAColumn(T, "modulename", "Modulo", 1);
                return;
            }
        }

        protected override Form GetForm(string formName) {
	        canInsert = false;
	        canSave = false;
	        searchEnabled = false;
	        CanCancel = false;
	        canInsertCopy = false;
            switch (formName) {
	            case "scriptcomuni": {
		            Name = "Tool aggiorna comuni";
		            return GetFormByDllName("notable_scriptcomuni");
	            }

                case "unifydip": {
                        Name = "Unifica dipartimenti";
                        return GetFormByDllName("no_table_unifydip");
                    }

                case "consolidclientiforn": {
                        Name = "Consolidamento degli elenchi clienti/fornitori";
                        return GetFormByDllName("no_table_consolidclientiforn");
                    }
                case "elencoclientiforn": {
                        Name = "Elenco clienti/fornitori";
                        return GetFormByDllName("no_table_elencoclientiforn");
                    }
                case "esitomandati": {
                        ActAsList();
                        Name = "Esitazione multipla dei mandati";
                        return GetFormByDllName("no_table_esitomandati");
                    }
                case "esitoreversali": {
                        ActAsList();
                        Name = "Esitazione multipla delle reversali";
                        return GetFormByDllName("no_table_esitoreversali");
                    }
                case "alert": {
                        ActAsList();
                        Name = "Avvisi";
                        StartEmpty = true;
                        return GetFormByDllName("no_table_alert");
                    }
                case "advice": {
                        ActAsList();
                        Name = "Comunicazioni";
                        StartEmpty = true;
                        return GetFormByDllName("no_table_advice");
                    }
                case "expbank": {
                        Name = "Trasmissione elettronica delle distinte alla banca";
                        return GetFormByDllName("no_table_expbank");
                    }
                case "cud": {
                        Name = "Cud";
                        return GetFormByDllName("no_table_cud");
                    }
                case "iban": {
                        Name = "Calcolo IBAN";
                        SearchEnabled = false;
                        CanInsert = false;
                        CanInsertCopy = false;
                        return GetFormByDllName("no_table_iban");
                    }
                case "wizanagrafiche": {
                        SearchEnabled = false;
                        CanInsert = false;
                        CanInsertCopy = false;
                        Name = "Wizard Correzione Anagrafiche";
                        return GetFormByDllName("no_table_wizanagrafiche");
                    }
                case "wizardmerge": {
                        SearchEnabled = false;
                        CanInsert = false;
                        CanInsertCopy = false;
                        Name = "Wizard Importazione Data Base";
                        return GetFormByDllName("no_table_wizardmerge");
                    }
                case "noduplicati": {
                        SearchEnabled = false;
                        CanInsert = false;
                        CanInsertCopy = false;

                        Name = "Wizard per anagrafiche duplicate";
                        return GetFormByDllName("no_table_wiz_cfpiva_duplicata");
                    }
                case "deleteunusable": {
                        SearchEnabled = false;
                        CanInsert = false;
                        CanInsertCopy = false;

                        Name = "Wizard per la cancellazione delle anagrafiche non usate";
                        return GetFormByDllName("no_table_wiz_del_anagrafiche_nonusate");
                    }
                case "fillunified": {
                        Name = "Wizard che estrae ritenute e correzioni per l'amministrazione";
                        return GetFormByDllName("no_table_wiz_fillunified");
                    }
                case "importazione": {
                        SearchEnabled = false;
                        CanInsert = false;
                        CanInsertCopy = false;

                        Name = "Wizard Importazione Dati nel DB";
                        return GetFormByDllName("notable_importazione");
                    }
                case "fillunifiedtax": {
                        Name = "Raccolta ritenute per F24 EP da Dettagli ritenute";
                        return GetFormByDllName("no_table_fill_unifiedtax");
                    }
                case "trasflowchart": {
                        Name = "Trasferimento organigramma";
                        return GetFormByDllName("no_table_trasf_flowchart");
                    }
                case "epilogo": {
                        Name = "Generazione scritture epilogo";
                        return GetFormByDllName("no_table_entry_epilogo");
                    }
                case "apertura": {
                        Name = "Generazione scritture apertura";
                        return GetFormByDllName("no_table_entry_apertura");
                    }
                case "riparto": {
                        Name = "Riparto risultato di esercizio";
                        return GetFormByDllName("no_table_entry_apertura");
                    }
                case "rettifica": {
                        Name = "Assestamento (Risconti - Rettifica)";
                        return GetFormByDllName("no_table_entry_rettifica");
                    }
                case "integrazione": {
                        Name = "Generazione scritture integrazione";
                        return GetFormByDllName("no_table_entry_integrazione");
                    }
                case "rettifica_pluriennale": {
                        Name = "Assestamento Progetti Pluriennali a Commessa Completata";
                        return GetFormByDllName("no_table_entry_rettifica");
                    }
				//case "delete_rettifica_pluriennale": {
				//		Name = "Cancellazione Assestamento Progetti Pluriennali a Commessa Completata";
				//		return GetFormByDllName("no_table_delete_entry_rettifica");
				//	}
				case "rettifica_pluriennale_percentuale": {
                        Name = "Assestamento Progetti Pluriennali a percentuale di completamento";
                        return GetFormByDllName("no_table_entry_rettifica");
                    }
                case "creascriptclass": {
                        Name = "Generazione script per la Classificazione";
                        return GetFormByDllName("no_table_sortingkind_creascriptclass");
                    }
                case "listaclassi": {
                        Name = "Classificazione automatica Entrate e Spese";
                        return GetFormByDllName("no_table_sortingkind_listaclassi");
                    }
                case "compattascritture": {
                        Name = "Compatta Dettagli scritture";
                        return GetFormByDllName("no_table_entry_shrink");
                    }
                case "unificaanagrafiche": {
                        //ActAsList();
                        Name = "Unifica Anagrafiche";
                        return GetFormByDllName("no_table_unifica_anagrafiche");
                    }
                case "importanagrafichecsa": {
                        Name = "Importa Anagrafiche da CSA";
                        return GetFormByDllName("no_table_import_anagrafiche_csa");
                    }
                case "flowchartcopy": {
                        Name = "Trasferisci Organigramma";
                        return GetFormByDllName("no_table_flowchartcopy");
                    }
                case "importazionefatture": {
                        Name = "Importa Fatture";
                        return GetFormByDllName("notable_importazionefatture");
                    }
                case "splitemens": {
                        Name = "Ripartizione denunce Emens";
                        return GetFormByDllName("no_table_splitemens");
                    }

                case "formconverter": {
                        Name = "Conversione Form Windows => Web";
                        return GetFormByDllName("no_table_formconverter");
                    }
                case "wizardscaricomagazzino": {
                        Name = "Generazione delle scritture EP per gli scarichi di Magazzino";
                        return MetaData.GetFormByDllName("entry_wizard_scaricomagazzino");
                    }
                case "consolida": {
                        Name = "Consolida Trasmissione Anagrafe delle Prestazioni";
                        return GetFormByDllName("servicetrasmission_consolida");
                    }
                case "f24ep": {
                        Name = "Generazione F24EP da Excel";
                        return GetFormByDllName("no_table_f24ep");
                    }
                case "match_storedprocedure": {
                        Name = "Confronta StoredProcedure";
                        return GetFormByDllName("notable_match_storedprocedure");
                    }
                case "flowchart_massive": {
                        Name = "Importazione utenti database";
                        return GetFormByDllName("no_table_flowchart_massive");
                    }
                case "checkpatrimonio": {
                        Name = "Verifiche Patrimonio";
                        return GetFormByDllName("no_table_checkpatrimonio");
                    }
                case "rateo": {
                        Name = "Ratei e Fatture da ricevere/emettere";
                        return GetFormByDllName("no_table_entry_rateo");
                    }
                case "transfprevinbudget": {
                        Name = "Trasferimento";
                        return GetFormByDllName("no_table_trasf_prevision_in_budget");
                    }
                case "undo_trasf_nuoveanagrafiche": {
                        Name = "Annulla Trasferimento";
                        return GetFormByDllName("no_table_undo_trasf_nuoveanagrafiche_record8000");
                    }
                case "transfpaydisposition": {
                        Name = "Trasferimento disposizioni di pagamento non pagate";
                        return GetFormByDllName("no_table_trasf_paydisposition");
                    }
                case "travasa_budgetvariationinitial": {
                        Name = "Copia Var.Iniziali di Budget";
                        return GetFormByDllName("no_table_travasa_varinizialibudget");
                    }
                case "flussostudenti": {
                        Name = "Importa Flusso Studenti";
                        return GetFormByDllName("no_table_flussostudenti");
                    }
                case "importaflussi": {
                        Name = "Importa Flusso crediti e incassi da File Excel";
                        return GetFormByDllName("no_table_flussostudenti");
                    }
                case "elaboracrediti": {
                        Name = "Elabora Crediti";
                        return GetFormByDllName("no_table_flussostudenti");
                    }
                case "elaboraincassiconsospesi": {
                        Name = "Elabora Incassi";
                        return GetFormByDllName("no_table_flussostudenti");
                    }
                case "elaboraincassisenzasospesi": {
                        Name = "Elabora incassi senza sospesi";
                        return GetFormByDllName("no_table_flussostudenti");
                    }

                case "entry_verifica": {
                        Name = "Verifica scritture";
                        return GetFormByDllName("no_table_entry_verifica");
                    }
                case "invoice_ssn": {
                        Name = "Trasmissione fatture al sistema TS";
                        return GetFormByDllName("no_table_invoice_ssn");
                    }
                case "wizardassetgrantdetail": {
                    Name = "Generazione Risconti Su Ammortamento Cespiti";
                    return GetFormByDllName("no_table_wiz_assetgrantdetail");
                }
                case "ivapay": {
                    Name = "Comunicazione periodica Liquidazione IVA";
                    return GetFormByDllName("no_table_ivapay");
                }
                case "invoicecomunicate": {
                    Name = "Invio Dati Fatture (ex Spesometro)";
                    return GetFormByDllName("no_table_invoicecomunicate");
                }
				//Trasmissione telematica dei dati delle operazioni transfrontaliere (Esterometro)
				case "esterometro": {
					Name = "Invio Dati Operazioni Transfrontaliere (Esterometro)";
					return GetFormByDllName("no_table_esterometro");
				}
				//no_table_calcola_integrazione_previsione
				case "calcola_integrazione_previsione": {
					Name = "Calcola Budget Iniziale non operativo";
					return GetFormByDllName("no_table_calcola_integrazione_previsione");
				}
			}
			return null;
        }
    }
}