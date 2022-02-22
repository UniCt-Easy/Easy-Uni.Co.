
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


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using funzioni_configurazione;
using metadatalibrary;
using pagamenti = bankdispositionsetup_siopeplus_pagamenti;
using incassi = bankdispositionsetup_siopeplus_incassi;
using System.Xml.Xsl;
using System.IO;
using pagoPaService;

namespace siopeplus_functions {
    public class siopeplus_export {
        DataAccess Conn;
        //public DataSet D;
        int esercizio;
        QueryHelper QHS;
        CQueryHelper QHC;
        //int limiteOPIinKb = 180;
        int limiteOPIinByte = 184320;
		// bool stop = false;
		pagamenti.mandatoInformazioni_beneficiarioSpese tratt_spese_esente_mandati_multipli;
		public siopeplus_export(DataAccess Conn) {
            this.Conn = Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();

            esercizio = CfgFn.GetNoNullInt32(Conn.GetSys("esercizio"));
			tratt_spese_esente_mandati_multipli= get_trattamento_spese_esente_mandati_multipli() ;


		}

        public pagamenti.mandato creaMandato(DataRow R) {
            pagamenti.mandatoTipo_operazione Tipo_operazione = pagamenti.mandatoTipo_operazione.INSERIMENTO;
            if (R["tipo_operazione"].ToString().Equals("ANNULLO")) {
                Tipo_operazione = pagamenti.mandatoTipo_operazione.ANNULLO;
            }
            if (R["tipo_operazione"].ToString().Equals("VARIAZIONE")) {
                Tipo_operazione = pagamenti.mandatoTipo_operazione.VARIAZIONE;
            }

            var Rmandato = new pagamenti.mandato();
            Rmandato.tipo_operazione = Tipo_operazione;
            Rmandato.numero_mandato = R["numero_mandato"].ToString();
            if (R["data_mandato"] != null) {
                DateTime data_mandato = DateTime.ParseExact(R["data_mandato"].ToString(), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                Rmandato.data_mandato = data_mandato;
            }

            Rmandato.importo_mandato = CfgFn.GetNoNullDecimal(R["importo_mandato"]);
            Rmandato.conto_evidenza = GetStringValue(R["conto_evidenza"]);
            Rmandato.estremi_provvedimento_autorizzativo = R["estremi_provvedimento_autorizzativo"].ToString();
            Rmandato.responsabile_provvedimento = R["responsabile_provvedimento"].ToString();
            Rmandato.ufficio_responsabile = R["ufficio_responsabile"].ToString();

            if (Rmandato == null) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Saltato mandato n." + R["ndoc"].ToString() + " per errore di dati");
                return null;
            }
            return Rmandato;
        }


        public incassi.reversale creaReversale(DataRow R) {
            incassi.reversaleTipo_operazione Tipo_operazione = incassi.reversaleTipo_operazione.INSERIMENTO;
			if (R["tipo_operazione"].ToString().Equals("ANNULLO")) {
				Tipo_operazione = incassi.reversaleTipo_operazione.ANNULLO;
			}
			if (R["tipo_operazione"].ToString().Equals("VARIAZIONE")) {
				Tipo_operazione = incassi.reversaleTipo_operazione.VARIAZIONE;
			}
			var Rreversale = new incassi.reversale();
            Rreversale.tipo_operazione = Tipo_operazione;
            Rreversale.numero_reversale = R["numero_reversale"].ToString();
            if (R["data_reversale"] != null) {
                DateTime data_reversale = DateTime.ParseExact(R["data_reversale"].ToString(), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                Rreversale.data_reversale = data_reversale;
            }

            Rreversale.importo_reversale = CfgFn.GetNoNullDecimal(R["importo_reversale"]);
            Rreversale.conto_evidenza =  GetStringValue(R["conto_evidenza"]); 
            if (Rreversale == null) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Saltata reversale n." + R["ndoc"].ToString() + " per errore di dati");
                return null;
            }
            return Rreversale;
        }
        public string GetStringValue(object V) {
            if ((V == DBNull.Value) || V.ToString() == "") return null;
            if (V.ToString().Trim() == "") return null;
            return V.ToString();
        }

        public pagamenti.ctFattura_siope get_classificazione_fatture_uscite(DataRow R) {
            pagamenti.ctClassificazione_dati_siope_uscite ClassDatiSiope = new pagamenti.ctClassificazione_dati_siope_uscite();
            //Enum
            bool commerciale = false;
            if (R["tipo_debito_siope"].ToString().Equals("IVA")) {
                ClassDatiSiope.tipo_debito_siope_nc = pagamenti.stTipo_debito_non_commerciale.IVA;
            }
            if (R["tipo_debito_siope"].ToString().Equals("NON COMMERCIALE")) {
                ClassDatiSiope.tipo_debito_siope_nc = pagamenti.stTipo_debito_non_commerciale.NON_COMMERCIALE;
            }
            if (R["tipo_debito_siope"].ToString().Equals("COMMERCIALE")) {
                ClassDatiSiope.tipo_debito_siope_c = pagamenti.stTipo_debito_commerciale.COMMERCIALE;
                commerciale = true;
            }
            pagamenti.ctFattura_siope FF = new pagamenti.ctFattura_siope();
            if (commerciale) {
                ClassDatiSiope.codice_cig_siope = GetStringValue(R["codice_cig_siope"]);
                //Enum
                ClassDatiSiope.motivo_esclusione_cig_siope =
                    ToOptionalEnum<pagamenti.stMotivo_esclusione_cig_siope>(R["motivo_esclusione_cig_siope"].ToString());


                FF.codice_ipa_ente_siope = GetStringValue(R["codice_ipa_ente_siope"]);
                //qui vanno messi gli items
                if (R["tipo_documento_siope"].ToString() == "ELETTRONICO") {
                    FF.tipo_documento_siope_e = FF.tipo_documento_siope_e = pagamenti.stTipo_documento_elettronico.ELETTRONICO;
                    FF.identificativo_lotto_sdi_siope = CfgFn.GetNoNullInt64(R["identificativo_lotto_sdi_siope"]);
                 }
                if (R["tipo_documento_siope"].ToString() == "ANALOGICO") {
                    FF.tipo_documento_siope_a = pagamenti.stTipo_documento_analogico.ANALOGICO;
                    switch (R["tipo_documento_analogico_siope"].ToString()) {
                        case "FATT_ANALOGICA": FF.tipo_documento_analogico_siope = pagamenti.ctFattura_siopeTipo_documento_analogico_siope.FATT_ANALOGICA; break;
                        case "DOC_EQUIVALENTE": FF.tipo_documento_analogico_siope = pagamenti.ctFattura_siopeTipo_documento_analogico_siope.DOC_EQUIVALENTE; break;
                    }
                    FF.codice_fiscale_emittente_siope = GetStringValue(R["codice_fiscale_emittente_siope"]);
                    FF.anno_emissione_fattura_siope = GetStringValue(R["anno_emissione_fattura_siope"]);
                }

                FF.dati_fattura_siope.numero_fattura_siope = GetStringValue(R["numero_fattura_siope"]);
                FF.dati_fattura_siope.importo_siope = CfgFn.GetNoNullDecimal(R["importo_siope"]);
                //Enum
                switch (R["natura_spesa_siope"].ToString()) {
                    case "CORRENTE": FF.dati_fattura_siope.natura_spesa_siope = pagamenti.ctDati_fattura_siopeNatura_spesa_siope.CORRENTE; break;
                    case "CAPITALE": FF.dati_fattura_siope.natura_spesa_siope = pagamenti.ctDati_fattura_siopeNatura_spesa_siope.CAPITALE; break;
                }

                if (R["data_scadenza_pagam_siope"] != DBNull.Value) {
                    DateTime data_scadenza_pagam_siope = DateTime.Now;
                    DateTime.TryParse(R["data_scadenza_pagam_siope"].ToString(), out data_scadenza_pagam_siope);
                    FF.dati_fattura_siope.data_scadenza_pagam_siope = data_scadenza_pagam_siope;
                    FF.dati_fattura_siope.data_scadenza_pagam_siopeSpecified = true;
                }

                //FF.dati_fattura_siope.motivo_scadenza_siope
                switch (R["motivo_scadenza_siope"].ToString()) {
                    case "SCAD_FATTURA": FF.dati_fattura_siope.motivo_scadenza_siope = pagamenti.ctDati_fattura_siopeMotivo_scadenza_siope.SCAD_FATTURA; break;
                    case "CORRETTA_SCAD_FATTURA": FF.dati_fattura_siope.motivo_scadenza_siope = pagamenti.ctDati_fattura_siopeMotivo_scadenza_siope.CORRETTA_SCAD_FATTURA; break;
                    case "SOSP_DECORRENZA_TERMINI": FF.dati_fattura_siope.motivo_scadenza_siope = pagamenti.ctDati_fattura_siopeMotivo_scadenza_siope.SOSP_DECORRENZA_TERMINI; break;
                }
                if (GetStringValue(R["motivo_scadenza_siope"]) != null) {
                    FF.dati_fattura_siope.motivo_scadenza_siopeSpecified = true;
                }
                //ClassDatiSiope.fattura_siope = FF;
                ClassDatiSiope.fattura_siope.Add(FF);
            }
            else {
                FF = null;
                //ClassDatiSiope.fattura_siope = FF;
                ClassDatiSiope.fattura_siope.Add(FF);
            }

            return FF;

        }
        public pagamenti.ctClassificazione_dati_siope_usciteDati_ARCONET_siope get_arconet_uscite(DataRow R) {
            pagamenti.ctClassificazione_dati_siope_usciteDati_ARCONET_siope arconet_uscite = new pagamenti.ctClassificazione_dati_siope_usciteDati_ARCONET_siope();
            arconet_uscite.codice_missione_siope = R["codice_missione_siope"].ToString();
            arconet_uscite.codice_programma_siope = R["codice_programma_siope"].ToString();
            arconet_uscite.codice_economico_siope = R["codice_economico_siope"].ToString();
            arconet_uscite.importo_codice_economico_siope = CfgFn.GetNoNullDecimal(R["importo_codice_economico_siope"]);
            arconet_uscite.codice_UE_siope = R["codice_UE_siope"].ToString();
            arconet_uscite.cofog_siope.codice_cofog_siope = R["codice_cofog_siope"].ToString();
            arconet_uscite.cofog_siope.importo_cofog_siope = CfgFn.GetNoNullDecimal(R["importo_cofog_siope"]);
            return arconet_uscite;
        }
        //public pagamenti.ctClassificazione_dati_siope_usciteDati_ARCONET_siopeCofog_siope get_arconet_cofog(DataRow R) {
        //    pagamenti.ctClassificazione_dati_siope_usciteDati_ARCONET_siopeCofog_siope arconet_cofog = new pagamenti.ctClassificazione_dati_siope_usciteDati_ARCONET_siopeCofog_siope();
        //    arconet_cofog.codice_cofog_siope = R["codice_cofog_siope"].ToString();
        //    arconet_cofog.importo_cofog_siope = CfgFn.GetNoNullDecimal(R["importo_cofog_siope"]);
        //    return arconet_cofog;
        //}
        public pagamenti.ctClassificazione_dati_siope_uscite get_classificazione_usciteIntestazione(DataRow R) {
            pagamenti.ctClassificazione_dati_siope_uscite ClassDatiSiope = new pagamenti.ctClassificazione_dati_siope_uscite();
            //Enum
            bool commerciale = false;
            if (R["tipo_debito_siope"].ToString().Equals("IVA")) {
                ClassDatiSiope.tipo_debito_siope_nc = pagamenti.stTipo_debito_non_commerciale.IVA;
            }
            if (R["tipo_debito_siope"].ToString().Equals("NON COMMERCIALE")) {
                ClassDatiSiope.tipo_debito_siope_nc = pagamenti.stTipo_debito_non_commerciale.NON_COMMERCIALE;
            }
            if (R["tipo_debito_siope"].ToString().Equals("COMMERCIALE")) {
                ClassDatiSiope.tipo_debito_siope_c = pagamenti.stTipo_debito_commerciale.COMMERCIALE;
                commerciale = true;
            }
            if (commerciale) {
                ClassDatiSiope.codice_cig_siope = GetStringValue(R["codice_cig_siope"]);
                //Enum
                ClassDatiSiope.motivo_esclusione_cig_siope =
                    ToOptionalEnum<pagamenti.stMotivo_esclusione_cig_siope>(R["motivo_esclusione_cig_siope"].ToString());
            }
        

            return ClassDatiSiope;
        }
        /// <summary>
        /// Ok
        /// </summary>
        /// <param name="R"></param>
        /// <returns></returns>
        public pagamenti.mandatoInformazioni_beneficiarioClassificazione get_classificazione_uscite(DataRow R) {
            pagamenti.mandatoInformazioni_beneficiarioClassificazione CC = new pagamenti.mandatoInformazioni_beneficiarioClassificazione();

            CC.codice_cgu = GetStringValue(R["codice_cgu"]);
            CC.codice_cup = GetStringValue(R["codice_cup"]);
            CC.codice_cpv = GetStringValue(R["codice_cpv"]);
            CC.importo = CfgFn.GetNoNullDecimal(R["importoclassificazionemov"]);

            string codice_cgu = R["codice_cgu"].ToString();
            int idexp = CfgFn.GetNoNullInt32(R["idexp"]);
            string idexp_idsor = idexp.ToString() + '_' + codice_cgu;
            pagamenti.ctClassificazione_dati_siope_uscite ClassDatiSiope = new pagamenti.ctClassificazione_dati_siope_uscite();
          
            //Dictionary di < fattura_siope >
            foreach (var item in FatturaSiope_perIdexpIdsorFatt) {
                var itemKey = item.Key;
                string[] ArrItemKey = itemKey.Split('_');
                string itemIdexpIdsor = ArrItemKey[0].ToString() + '_' + ArrItemKey[1].ToString();
                if (itemIdexpIdsor != idexp_idsor) continue;
                //Valorizza i primi elementi di <classificazione_dati_siope_uscite>
                ClassDatiSiope.tipo_debito_siope_c = ClassDatiSiopeIntestazione_perIdexpIdsorFatt[itemIdexpIdsor].tipo_debito_siope_c;
                ClassDatiSiope.tipo_debito_siope_nc = ClassDatiSiopeIntestazione_perIdexpIdsorFatt[itemIdexpIdsor].tipo_debito_siope_nc;
                ClassDatiSiope.codice_cig_siope = ClassDatiSiopeIntestazione_perIdexpIdsorFatt[itemIdexpIdsor].codice_cig_siope;
                ClassDatiSiope.motivo_esclusione_cig_siope = ClassDatiSiopeIntestazione_perIdexpIdsorFatt[itemIdexpIdsor].motivo_esclusione_cig_siope;
                //Poi aggiungo <fattura_siope>  con tutti i suoi elementi                                                                                                                      
                bool commerciale = (ClassDatiSiope.tipo_debito_siope_c == pagamenti.stTipo_debito_commerciale.COMMERCIALE);
                if (commerciale) {
                    // Valorizza <fattura_siope>
                    //ClassDatiSiope.fattura_siope = item.Value;
                    ClassDatiSiope.fattura_siope.Add(item.Value);
                }
                else {
                    pagamenti.ctFattura_siope FF = new pagamenti.ctFattura_siope();
                    FF = null;
                    //ClassDatiSiope.fattura_siope = FF;
                    ClassDatiSiope.fattura_siope.Add(FF);
                }

            }
            foreach(var item in Arconet_perIdexpIdsor) {
                var itemKey = item.Key;
                string[] ArrItemKey = itemKey.Split('_');
                string itemIdexpIdsor = ArrItemKey[0].ToString() + '_' + ArrItemKey[1].ToString();
                if (itemIdexpIdsor != idexp_idsor) continue;
                ClassDatiSiope.dati_ARCONET_siope  = Arconet_perIdexpIdsor[itemIdexpIdsor];
            }
                CC.classificazione_dati_siope_uscite = ClassDatiSiope;
            return CC;
        }

        public pagamenti.ritenute get_ritenute(DataRow R) {
            pagamenti.ritenute RIT = new pagamenti.ritenute();
            RIT.importo_ritenute = CfgFn.GetNoNullDecimal(R["importo_ritenute"]);
            RIT.numero_reversale = GetStringValue(R["numero_reversale"]);
            RIT.progressivo_versante = GetStringValue(R["progressivo_versante"]);
          
            return RIT;
        }

        public pagamenti.mandatoInformazioni_beneficiarioSospeso get_sospeso_uscite(DataRow R) {
            pagamenti.mandatoInformazioni_beneficiarioSospeso S = new pagamenti.mandatoInformazioni_beneficiarioSospeso();
            S.numero_provvisorio = GetStringValue(R["numero_provvisorio"]);
            S.importo_provvisorio = CfgFn.GetNoNullDecimal(R["importo_provvisorio"]);
            return S;
        }
        public incassi.reversaleInformazioni_versanteSospeso get_sospeso_entrate(DataRow R) {
            incassi.reversaleInformazioni_versanteSospeso S = new incassi.reversaleInformazioni_versanteSospeso();
            S.numero_provvisorio = GetStringValue(R["numero_provvisorio"]);
            S.importo_provvisorio = CfgFn.GetNoNullDecimal(R["importo_provvisorio"]);
            return S;
        }

        public static T? ToOptionalEnum<T>(string value, bool ignoreCase = true) where T:struct {
            if (string.IsNullOrEmpty(value)) return null;
            try {
                return (T) Enum.Parse(typeof(T), value, ignoreCase);
            }
            catch {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Valore non previsto:" + value + " per il tipo " + typeof(T).Name);
                return null; 
            }
            
        }
        public static T ToForcedEnum<T>(string value, bool ignoreCase = true)  {
            if (string.IsNullOrEmpty(value)) return default(T);
            try {
                return (T) Enum.Parse(typeof(T), value, ignoreCase);
            }
            catch {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Valore non previsto:" + value + " per il tipo " + typeof(T).Name);
                return default(T);
            }
            
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="T">tabella output della SP (contiene uno o più movimenti)</param>
		/// <param name="R">Pagamento considerato</param>
		/// <returns></returns>
		/// 
		public pagamenti.mandatoInformazioni_beneficiarioSpese get_trattamento_spese_esente_mandati_multipli() {
			pagamenti.mandatoInformazioni_beneficiarioSpese RSpeseEsente = new pagamenti.mandatoInformazioni_beneficiarioSpese();
			DataTable ChargeHandling = Conn.RUN_SELECT("chargehandling","*",null,QHS.BitSet("flag",2),null, false);
			if (ChargeHandling != null && ChargeHandling.Rows.Count > 0) { 
				object soggetto_destinatario_delle_spese = ChargeHandling.Rows[0]["handlingbankcode"];
				object motive = ChargeHandling.Rows[0]["motive"];
				object payment_kind = ChargeHandling.Rows[0]["payment_kind"];
				RSpeseEsente.soggetto_destinatario_delle_spese = ToForcedEnum<pagamenti.mandatoInformazioni_beneficiarioSpeseSoggetto_destinatario_delle_spese>
					(soggetto_destinatario_delle_spese.ToString().Replace(" ",""));
				RSpeseEsente.causale_esenzione_spese = motive.ToString();
				RSpeseEsente.natura_pagamento = payment_kind.ToString();
			}
			return RSpeseEsente;
		}

 
		public pagamenti.mandatoInformazioni_beneficiarioSpese ricalcola_trattamento_spese_per_anagrafica(DataRow R) {
			pagamenti.mandatoInformazioni_beneficiarioSpese RSpese = new pagamenti.mandatoInformazioni_beneficiarioSpese();
			string anagrafica = R["anagrafica_beneficiario"].ToString();
			int idexp = CfgFn.GetNoNullInt32(R["idexp"]);
			if ((trattamentoSpesePerAnagrafica.Count == 0)||!trattamentoSpesePerAnagrafica.ContainsKey(anagrafica)) {
				RSpese.soggetto_destinatario_delle_spese = ToForcedEnum<pagamenti.mandatoInformazioni_beneficiarioSpeseSoggetto_destinatario_delle_spese>(
				R["soggetto_destinatario_delle_spese"].ToString());
				RSpese.natura_pagamento = GetStringValue(R["natura_pagamento"]);
				RSpese.causale_esenzione_spese = GetStringValue(R["causale_esenzione_spese"]);
				return RSpese;
			}
			if (R["soggetto_destinatario_delle_spese"] != DBNull.Value) {
				// tutti i pagamenti arrivano con pagamento spese valorizzato nella stored procedure essendo obbligatorio, in certi casi la sp ha valorizzato 
				// quello di default in configurazione
				// 1) trattamento spese esente, lasciamo stare quello scelto da loro
				if  (R["soggetto_destinatario_delle_spese"].ToString() == "ESENTE") {
					RSpese.soggetto_destinatario_delle_spese = ToForcedEnum<pagamenti.mandatoInformazioni_beneficiarioSpeseSoggetto_destinatario_delle_spese>(
			        R["soggetto_destinatario_delle_spese"].ToString());
					RSpese.natura_pagamento = GetStringValue(R["natura_pagamento"]);
					RSpese.causale_esenzione_spese = GetStringValue(R["causale_esenzione_spese"]);
					return RSpese;
				}
				else {
					//2) trattamento spese non esente,
					// Filtro a parità di anagrafica i trattamenti spese già considerati

				List<pagamenti.mandatoInformazioni_beneficiarioSpese> lista_TrattSpese = trattamentoSpesePerAnagrafica[anagrafica];
				bool trovato = false;
				foreach (pagamenti.mandatoInformazioni_beneficiarioSpese singoloTratt in lista_TrattSpese) {
					 if (singoloTratt.soggetto_destinatario_delle_spese.ToString() == R["soggetto_destinatario_delle_spese"].ToString())
						 trovato = true;
				}
				//  se per l'anagrafica è il primo di quella tipologia lasciamo quello
				if (!trovato) {
					RSpese.soggetto_destinatario_delle_spese = ToForcedEnum<pagamenti.mandatoInformazioni_beneficiarioSpeseSoggetto_destinatario_delle_spese>(
					R["soggetto_destinatario_delle_spese"].ToString());
					RSpese.natura_pagamento = GetStringValue(R["natura_pagamento"]);
					RSpese.causale_esenzione_spese = GetStringValue(R["causale_esenzione_spese"]);
					return RSpese;
				}
				else
				// per quell'anagrafica, è stata già introdotta quella tipologia di  pagamento non esente,  la cambiamo in quella  esente
				{
						RSpese = tratt_spese_esente_mandati_multipli;
				}
			}
			}
			return RSpese;
		}
		Dictionary<string,  List<pagamenti.mandatoInformazioni_beneficiarioSpese>> trattamentoSpesePerAnagrafica =
			new Dictionary<string, List<pagamenti.mandatoInformazioni_beneficiarioSpese>>();
		public pagamenti.mandatoInformazioni_beneficiario get_informazioni_beneficiario(DataRow R) {


			string anagrafica = R["anagrafica_beneficiario"].ToString();
			int idexp = CfgFn.GetNoNullInt32(R["idexp"]);

			pagamenti.mandatoInformazioni_beneficiario Rinfomazioni_beneficiario = new pagamenti.mandatoInformazioni_beneficiario();
            Rinfomazioni_beneficiario.progressivo_beneficiario = R["progressivo_beneficiario"].ToString();
            Rinfomazioni_beneficiario.importo_beneficiario = CfgFn.GetNoNullDecimal(R["importo_beneficiario"]);

            Rinfomazioni_beneficiario.tipo_pagamento = ToForcedEnum<pagamenti.mandatoInformazioni_beneficiarioTipo_pagamento>(R["tipo_pagamento"].ToString());

            if (R["data_esecuzione_pagamento"] != DBNull.Value) {
                DateTime data_esecuzione_pagamento ;
                if (DateTime.TryParse(R["data_esecuzione_pagamento"].ToString(), out data_esecuzione_pagamento)) {
                    Rinfomazioni_beneficiario.data_esecuzione_pagamento = data_esecuzione_pagamento;
                    Rinfomazioni_beneficiario.data_esecuzione_pagamentoSpecified = true;
                }
            }
            if (R["data_scadenza_pagamento"] != DBNull.Value) {
                DateTime data_scadenza_pagamento;
                if (DateTime.TryParse(R["data_scadenza_pagamento"].ToString(), out data_scadenza_pagamento)) {
                    Rinfomazioni_beneficiario.data_scadenza_pagamento = data_scadenza_pagamento;
                    Rinfomazioni_beneficiario.data_scadenza_pagamentoSpecified = true;
                }
            }
            
            
            if (R["destinazione"] != DBNull.Value) {
                Rinfomazioni_beneficiario.destinazione =
                    ToForcedEnum<pagamenti.mandatoInformazioni_beneficiarioDestinazione>(R["destinazione"].ToString());
            }

            if (Rinfomazioni_beneficiario.tipo_pagamento !=
                pagamenti.mandatoInformazioni_beneficiarioTipo_pagamento.REGOLARIZZAZIONE) {
	            Rinfomazioni_beneficiario.numero_conto_banca_italia_ente_ricevente= GetStringValue(R["numero_conto_banca_italia_ente_ricevente"]);
            }
           
            if (R["tipo_contabilita_ente_ricevente"] != DBNull.Value) {
                Rinfomazioni_beneficiario.tipo_contabilita_ente_ricevente =
                ToForcedEnum<pagamenti.mandatoInformazioni_beneficiarioTipo_contabilita_ente_ricevente>(
                    R["tipo_contabilita_ente_ricevente"].ToString());
            }


            //if (trasmissione) {
            //    Aggiungi_classificazione_uscite(T, Rinfomazioni_beneficiario, R);
            //}
            // Bollo

            if (R["assoggettamento_bollo"] != DBNull.Value) {
                string bollo = R["assoggettamento_bollo"].ToString();
                if (bollo.ToUpper() == "ESENTE") bollo = "ESENTEBOLLO";
                if (bollo.ToUpper() == "ESENTE BOLLO") bollo = "ESENTEBOLLO";
                Rinfomazioni_beneficiario.bollo.assoggettamento_bollo =
                    ToForcedEnum<pagamenti.mandatoInformazioni_beneficiarioBolloAssoggettamento_bollo>(bollo);
            }
            Rinfomazioni_beneficiario.bollo.causale_esenzione_bollo = GetStringValue(R["causale_esenzione_bollo"]);

            // Spese

            if (R["soggetto_destinatario_delle_spese"] != DBNull.Value) {
				Rinfomazioni_beneficiario.spese = ricalcola_trattamento_spese_per_anagrafica(R);
				if (!trattamentoSpesePerAnagrafica.ContainsKey(anagrafica))
				trattamentoSpesePerAnagrafica[anagrafica] = new List<pagamenti.mandatoInformazioni_beneficiarioSpese>(); 
				trattamentoSpesePerAnagrafica[anagrafica].Add(Rinfomazioni_beneficiario.spese);
			}

            // Beneficiario
            Rinfomazioni_beneficiario.beneficiario.anagrafica_beneficiario = GetStringValue(R["anagrafica_beneficiario"]);
            Rinfomazioni_beneficiario.beneficiario.indirizzo_beneficiario = GetStringValue(R["indirizzo_beneficiario"]);
            Rinfomazioni_beneficiario.beneficiario.cap_beneficiario = GetStringValue(R["cap_beneficiario"]);
            Rinfomazioni_beneficiario.beneficiario.localita_beneficiario = GetStringValue(R["localita_beneficiario"]);
            Rinfomazioni_beneficiario.beneficiario.provincia_beneficiario = GetStringValue(R["provincia_beneficiario"]);
            Rinfomazioni_beneficiario.beneficiario.stato_beneficiario = GetStringValue(R["stato_beneficiario"]);
            Rinfomazioni_beneficiario.beneficiario.partita_iva_beneficiario = GetStringValue(R["partita_iva_beneficiario"]);
            Rinfomazioni_beneficiario.beneficiario.codice_fiscale_beneficiario = GetStringValue(R["codice_fiscale_beneficiario"]);
            //-Delegato
            pagamenti.delegato Delegato = new pagamenti.delegato();
            Delegato.anagrafica_delegato = GetStringValue(R["anagrafica_delegato"]);
            Delegato.indirizzo_delegato = GetStringValue(R["indirizzo_delegato"]);
            Delegato.cap_delegato = GetStringValue(R["cap_delegato"]);
            Delegato.localita_delegato = GetStringValue(R["localita_delegato"]);
            Delegato.provincia_delegato = GetStringValue(R["provincia_delegato"]);
            Delegato.stato_delegato = GetStringValue(R["stato_delegato"]);
            Delegato.codice_fiscale_delegato = GetStringValue(R["codice_fiscale_delegato"]);
            if (Delegato.anagrafica_delegato != null) {
                Rinfomazioni_beneficiario.delegato.Add(Delegato);
            }
            // Creditore effettivo
            if (R["anagrafica_creditore_effettivo"] != DBNull.Value) {
                pagamenti.creditore_effettivo CreditoreEffettivo = new pagamenti.creditore_effettivo();
                CreditoreEffettivo.anagrafica_creditore_effettivo = GetStringValue(R["anagrafica_creditore_effettivo"]);
                CreditoreEffettivo.indirizzo_creditore_effettivo = GetStringValue(R["indirizzo_creditore_effettivo"]);
                CreditoreEffettivo.cap_creditore_effettivo = GetStringValue(R["cap_creditore_effettivo"]);
                CreditoreEffettivo.localita_creditore_effettivo = GetStringValue(R["localita_creditore_effettivo"]);
                CreditoreEffettivo.provincia_creditore_effettivo = GetStringValue(R["provincia_creditore_effettivo"]);
                CreditoreEffettivo.stato_creditore_effettivo = GetStringValue(R["stato_creditore_effettivo"]);
                CreditoreEffettivo.partita_iva_creditore_effettivo = GetStringValue(R["partita_iva_creditore_effettivo"]);
                CreditoreEffettivo.codice_fiscale_creditore_effettivo = GetStringValue(R["codice_fiscale_creditore_effettivo"]);
                if (CreditoreEffettivo.anagrafica_creditore_effettivo != null) {
                    Rinfomazioni_beneficiario.creditore_effettivo = CreditoreEffettivo;
                }
            }
            if (GetStringValue(R["numero_conto_corrente_beneficiario"]) != null) {
                pagamenti.piazzatura Piazzatura = new pagamenti.piazzatura();
                Piazzatura.numero_conto_corrente_beneficiario = GetStringValue(R["numero_conto_corrente_beneficiario"]);
                Rinfomazioni_beneficiario.piazzatura = Piazzatura;
                //Rinfomazioni_beneficiario.piazzatura.numero_conto_corrente_beneficiario = GetStringValue(R["numero_conto_corrente_beneficiario"]);
            }
            // - sepa_credit_transfer
            if (GetStringValue(R["iban"]) != null) {
                pagamenti.sepa_credit_transfer SCT = new pagamenti.sepa_credit_transfer();
                SCT.iban = GetStringValue(R["iban"]);
                SCT.bic = GetStringValue(R["bic"]);
                SCT.identificativo_end_to_end = GetStringValue(R["identificativo_end_to_end"]);

                pagamenti.sepa_credit_transferIdentificativo_category_purpose CP = new pagamenti.sepa_credit_transferIdentificativo_category_purpose();
                switch (R["code"].ToString()) {
                    case "SALA": CP.code = pagamenti.sepa_credit_transferIdentificativo_category_purposeCode.SALA; break;
                    case "PENS": CP.code = pagamenti.sepa_credit_transferIdentificativo_category_purposeCode.PENS; break;
                    default:
                        CP.proprietary = GetStringValue(R["proprietary"]);
                        break;
                }
                if (CP != null) {
                    SCT.identificativo_category_purpose = CP;
                }
                Rinfomazioni_beneficiario.sepa_credit_transfer = SCT;
            }
            Rinfomazioni_beneficiario.codice_versante = GetStringValue(R["codice_versante"]);
            Rinfomazioni_beneficiario.causale = GetStringValue(R["causale"]);
           
            //if (trasmissione) {
            //    //Sospeso
            //    Aggiungi_sospeso_uscite(T, Rinfomazioni_beneficiario, R);
            //    //Ritenute
            //    Aggiungi_ritenute(T, Rinfomazioni_beneficiario, R);
            //}
            pagamenti.informazioni_aggiuntive IA = new pagamenti.informazioni_aggiuntive();
            IA.riferimento_documento_esterno = GetStringValue(R["riferimento_documento_esterno"]);
            if (R["tipo_pagamento"].ToString() == "AVVISOPAGOPA") {
                var AvvPagoPa = new pagamenti.ctAvviso_pagoPA();
                AvvPagoPa.numero_avviso = GetStringValue(R["numero_avviso_pagopa"]);
                AvvPagoPa.codice_identificativo_ente = GetStringValue(R["codice_fiscale_beneficiario"]);
                IA.avviso_pagoPA = AvvPagoPa;
            }
            Rinfomazioni_beneficiario.informazioni_aggiuntive = IA;
            return Rinfomazioni_beneficiario;
        }

        /// <summary>
        /// restituisce l'elenco dei beneficiari presenti nella tabella
        /// </summary>
        /// <param name="T"></param>
        /// <returns></returns>
        /// 

        Dictionary<string, pagamenti.ctFattura_siope> FatturaSiope_perIdexpIdsorFatt = new Dictionary<string, pagamenti.ctFattura_siope>();
        Dictionary<string, pagamenti.ctClassificazione_dati_siope_usciteDati_ARCONET_siope> Arconet_perIdexpIdsor = new Dictionary<string, pagamenti.ctClassificazione_dati_siope_usciteDati_ARCONET_siope>();
        Dictionary<string, incassi.ctClassificazione_dati_siope_entrateDati_ARCONET_siope> Arconet_perIdincIdsor = new Dictionary<string, incassi.ctClassificazione_dati_siope_entrateDati_ARCONET_siope>();
        //Dictionary<string, pagamenti.ctClassificazione_dati_siope_usciteDati_ARCONET_siopeCofog_siope> ArconetCofog_perIdexpIdsorPxCof = new Dictionary<string, pagamenti.ctClassificazione_dati_siope_usciteDati_ARCONET_siopeCofog_siope>();
        Dictionary<string, pagamenti.ctClassificazione_dati_siope_uscite> ClassDatiSiopeIntestazione_perIdexpIdsorFatt = 
            new Dictionary<string, pagamenti.ctClassificazione_dati_siope_uscite>();

        Dictionary<string, List<pagamenti.ctFattura_siope>> LfatturaSiope =
            new Dictionary<string, List<pagamenti.ctFattura_siope>>();

        public  Dictionary<int, pagamenti.mandatoInformazioni_beneficiario> get_listaBeneficiari(DataTable T) {
			Dictionary<int, pagamenti.mandatoInformazioni_beneficiario> beneficiariPerIdExp = new Dictionary<int, pagamenti.mandatoInformazioni_beneficiario>();


			//int SizeinByte = 0;
			foreach (DataRow R in T.Rows) {
                if (R.RowState == DataRowState.Deleted) continue;
                int idexp = CfgFn.GetNoNullInt32(R["idexp"]);
                if (R.RowState==DataRowState.Deleted)continue;                
                int idexpMain = CfgFn.GetNoNullInt32(R["idexp"]);
				string anagrafica = R["anagrafica_beneficiario"].ToString();
				if (R["kind"].ToString().Trim() == "INFO_BENEFICIARIO") {
                    if (idexpMain == 0) {
                        MetaFactory.factory.getSingleton<IMessageShower>().Show("Ci sono problemi per il pagamento numero " + R["nmov"]);
                        return null;
                    }
					var benef = get_informazioni_beneficiario(R);
					beneficiariPerIdExp[idexp] = benef;
                    if (benef == null) return null;
                }
            }

            foreach (DataRow R in T.Rows) {
                if (R.RowState == DataRowState.Deleted) continue;
                string codice_cgu = R["codice_cgu"].ToString();
                int idexp = CfgFn.GetNoNullInt32(R["idexp"]);
                string numero_fattura_siope = R["numero_fattura_siope"].ToString();//da sostituire con yinv_ninv_idinvkind
                string idexp_idsor_fatt = idexp.ToString() + '_' + codice_cgu+'_'+ numero_fattura_siope;
                if (R["kind"].ToString().Trim() == "CLASSIFICAZIONI_FATTURASIOPE") {
                    var FattSiope = get_classificazione_fatture_uscite(R);
                    FatturaSiope_perIdexpIdsorFatt[idexp_idsor_fatt] = FattSiope;
                    //var ClassFattIntestazione = get_classificazione_usciteIntestazione(R);
                    //ClassDatiSiopeIntestazione_perIdexpIdsorFatt[idexp_idsor_fatt] = ClassFattIntestazione;
                }
                string idexp_idsor = idexp.ToString() + '_' + codice_cgu;
                if (R["kind"].ToString().Trim() == "CLASSIFICAZIONI") {
                    var ClassFattIntestazione = get_classificazione_usciteIntestazione(R);
                    ClassDatiSiopeIntestazione_perIdexpIdsorFatt[idexp_idsor] = ClassFattIntestazione;
                }
                if (R["kind"].ToString().Trim() == "ARCONET") {
                    string programma = R["codice_programma_siope"].ToString();
                    var Arconet = get_arconet_uscite(R);
                    Arconet_perIdexpIdsor[idexp_idsor] = Arconet;

                    //string idexp_idsor_px_cofog = idexp_idsor_px + '_' + R["codice_cofog_siope"].ToString(); ;
                    //var ArconetCofog = get_arconet_cofog(R);
                    //ArconetCofog_perIdexpIdsorPxCof[idexp_idsor_px_cofog] = ArconetCofog;
                }
            }

            foreach (DataRow R in T.Rows) {
                if (R.RowState==DataRowState.Deleted)continue;                
                int idexp = CfgFn.GetNoNullInt32(R["idexp"]);
                switch (R["kind"].ToString().Trim()) {                        
                
                    case "CLASSIFICAZIONI": {
                        var benefClass = beneficiariPerIdExp[idexp];
                            pagamenti.mandatoInformazioni_beneficiarioClassificazione CC = get_classificazione_uscite(R);
                            if (CC != null) {
                                benefClass.classificazione.Add(CC);
                            }
                            break;
                        }
                    case "RITENUTE": {
                        var benefRit = beneficiariPerIdExp[idexp];
                            pagamenti.ritenute RIT = get_ritenute(R);
                            if (RIT != null) {
                                benefRit.ritenute.Add(RIT);
                            }
                            break;
                        }
                    case "SOSPESI": {
                        var benefSospesi = beneficiariPerIdExp[idexp];
                            pagamenti.mandatoInformazioni_beneficiarioSospeso SOSP = get_sospeso_uscite(R);
                            if (SOSP != null) {
                                benefSospesi.sospeso.Add(SOSP);
                            }
                            break;
                        }
                }
            }

            return beneficiariPerIdExp;
            //string Dsingolo = infoBeneficiario.toXml();
            //SizeinByte = Dsingolo.Length;

            //return SizeinByte;
        }

        

        public string Crea_flusso_ordinativi_pag(DataTable T, out bool stop) {
            stop = false;
            string selettore = "(kind='TESTATA')";
            DataRow[] rTestate = T.Select(selettore);
            if (rTestate.Length == 0) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Riga flusso_ordinativi non trovata, filtro utilizzato = " + selettore,
                                        "Errore");
                return null;
            }
            DataRow rTestata = rTestate[0];
            //var V = R;

            //Aggiunge righe figlie a Flusso
            pagamenti.flusso_ordinativi F = new pagamenti.flusso_ordinativi();

            var rMandati = T.Select("(kind='MANDATO')");
            if (rMandati.Length == 0) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Nessun mandato trovato.");
                return null;
            }
            F.testata_flusso.codice_ABI_BT = GetStringValue(rTestata["codice_ABI_BT"]);
            F.testata_flusso.identificativo_flusso = GetStringValue(rTestata["identificativo_flusso"]);
            F.testata_flusso.data_ora_creazione_flusso = (DateTime)rTestata["data_ora_creazione_flusso"];
            F.testata_flusso.codice_ente = GetStringValue(rTestata["codice_ente"]);
            F.testata_flusso.descrizione_ente = GetStringValue(rTestata["descrizione_ente"]);
            F.testata_flusso.codice_istat_ente = GetStringValue(rTestata["codice_istat_ente"]);
            F.testata_flusso.codice_fiscale_ente = GetStringValue(rTestata["codice_fiscale_ente"]);
            F.testata_flusso.codice_tramite_ente = GetStringValue(rTestata["codice_tramite_ente"]);
            F.testata_flusso.codice_tramite_BT = GetStringValue(rTestata["codice_tramite_BT"]);
            F.testata_flusso.codice_ente_BT = GetStringValue(rTestata["codice_ente_BT"]);
            F.testata_flusso.riferimento_ente = GetStringValue(rTestata["riferimento_ente"].ToString());
            F.esercizio = Conn.GetSys("esercizio").ToString();
            

            Dictionary<int, pagamenti.mandato> mandati = new Dictionary<int, pagamenti.mandato>();
            Dictionary<int, int> mandatoPerIdExp = new Dictionary<int, int>();//restituisce il mandato di ogni mov. di spesa

            
            //crea i mandati puri
            foreach (var mandato in rMandati) {
                var m = creaMandato(mandato);
                if (m == null) return null;
                mandati[(int) mandato["ndoc"]] = m;

                var pagam = new pagamenti.ctDati_a_disposizione_ente_mandato();
                pagam.struttura = rMandati[0]["dati_codice_struttura"].ToString();
                pagam.codice_struttura = rMandati[0]["dati_codice_struttura"].ToString();
                pagam.codice_ipa_struttura = rMandati[0]["dati_codice_ipa_struttura"].ToString();
                m.dati_a_disposizione_ente_mandato = pagam;

                F.Items.Add(m);
            }

            foreach (DataRow r in T.Rows) {
                if (r.RowState == DataRowState.Deleted) continue;
                if ((r["ndoc"] != DBNull.Value)&& (r["idexp"] != DBNull.Value)) {
                    mandatoPerIdExp[(int)r["idexp"]] = (int)r["ndoc"];//eventuali altri filtri
                }
            }

            var beneficiari = get_listaBeneficiari(T);

            foreach (var beneficiario in beneficiari) {
                var idexp = beneficiario.Key;
                var infoBenef = beneficiario.Value;
                var ndoc = mandatoPerIdExp[idexp];
                mandati[ndoc].informazioni_beneficiario.Add(infoBenef);
            }

            foreach (var beneficiario in beneficiari) {
	            var infoBenef = beneficiario.Value;
	            if (infoBenef.sospeso?.Count > 1000) {
		            MetaFactory.factory.getSingleton<IMessageShower>().Show(
			            $" Invio non eseguibile!\r\n Il pagamento da {infoBenef.beneficiario.anagrafica_beneficiario} ha più di 1000 sospesi.");
		            return null;
	            }
            }

            foreach (var mandato in mandati) {
                var m = mandato.toXml(Encoding.GetEncoding("ISO-8859-1"));
                if (m.Length>=  limiteOPIinByte) {
                    MetaFactory.factory.getSingleton<IMessageShower>().Show(
                        $"Invio non eseguibile!\r\n Il mandato n.{mandato.Value.numero_mandato} supera la dimensione massima consentita.{m.Length}");
                    return null;
                }
            }

            string D = F.toXml(Encoding.GetEncoding("ISO-8859-1"));
            if (D == null) return null;

            return D;
        }

        public int CalcolaDimensione(string Dsingolo) {
            string FilePath = AppDomain.CurrentDomain.BaseDirectory;

            string tempfilename = FilePath + "opi.xml";

            using (StreamWriter sw = File.AppendText(tempfilename)) {
                sw.Write(Dsingolo);
            }
            long length = File.ReadAllBytes(tempfilename).Length;
            //int SizeinKB = (int)CfgFn.Round(Convert.ToDecimal(length) / 1024, 0);
            int SizeinByte = (int)(Convert.ToDecimal(length));
            try {
                System.IO.File.Delete(tempfilename);
            }
            catch {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Errore nella cancellazione del file temporaneo " + tempfilename);
            }
            return SizeinByte;
        }

        public incassi.ctFattura_siope get_classificazione_fatture_entrate(DataRow R) {
            incassi.ctClassificazione_dati_siope_entrate ClassDatiSiope = new incassi.ctClassificazione_dati_siope_entrate();
            //Enum
            bool commerciale = false;
            if (R["tipo_debito_siope"].ToString().Equals("IVA")) {
                ClassDatiSiope.tipo_debito_siope_nc = incassi.stTipo_debito_non_commerciale.IVA;
            }
            if (R["tipo_debito_siope"].ToString().Equals("NON COMMERCIALE")) {
                ClassDatiSiope.tipo_debito_siope_nc = incassi.stTipo_debito_non_commerciale.NON_COMMERCIALE;
            }
            if (R["tipo_debito_siope"].ToString().Equals("COMMERCIALE")) {
                ClassDatiSiope.tipo_debito_siope_c = incassi.stTipo_debito_commerciale.COMMERCIALE;
                commerciale = true;
            }
            incassi.ctFattura_siope FF = new incassi.ctFattura_siope();
            if (commerciale) {
                FF.codice_ipa_ente_siope = GetStringValue(R["codice_ipa_ente_siope"]);
                //qui vanno messi gli items
                if (R["tipo_documento_siope"].ToString() == "ELETTRONICO") {
                    FF.tipo_documento_siope_e = FF.tipo_documento_siope_e = incassi.stTipo_documento_elettronico.ELETTRONICO;
                    FF.identificativo_lotto_sdi_siope = CfgFn.GetNoNullInt64(R["identificativo_lotto_sdi_siope"]);
                }
                if (R["tipo_documento_siope"].ToString() == "ANALOGICO") {
                    FF.tipo_documento_siope_a = incassi.stTipo_documento_analogico.ANALOGICO;
                    switch (R["tipo_documento_analogico_siope"].ToString()) {
                        case "FATT_ANALOGICA": FF.tipo_documento_analogico_siope = incassi.ctFattura_siopeTipo_documento_analogico_siope.FATT_ANALOGICA; break;
                        case "DOC_EQUIVALENTE": FF.tipo_documento_analogico_siope = incassi.ctFattura_siopeTipo_documento_analogico_siope.DOC_EQUIVALENTE; break;
                    }
                    FF.codice_fiscale_emittente_siope = GetStringValue(R["codice_fiscale_emittente_siope"]);
                    FF.anno_emissione_fattura_siope = GetStringValue(R["anno_emissione_fattura_siope"]);

                }
                FF.ShouldSerializeidentificativo_lotto_sdi_siope();
                FF.dati_fattura_siope.numero_fattura_siope = GetStringValue(R["numero_fattura_siope"]);
                FF.dati_fattura_siope.importo_siope = CfgFn.GetNoNullDecimal(R["importo_siope"]);
                FF.ShouldSerializetipo_documento_analogico_siope();
                FF.ShouldSerializetipo_documento_siope_a();
                FF.ShouldSerializetipo_documento_siope_e();
                //Enum
                switch (R["natura_spesa_siope"].ToString()) {
                    case "CORRENTE": FF.dati_fattura_siope.natura_spesa_siope = incassi.ctDati_fattura_siopeNatura_spesa_siope.CORRENTE; break;
                    case "CAPITALE": FF.dati_fattura_siope.natura_spesa_siope = incassi.ctDati_fattura_siopeNatura_spesa_siope.CAPITALE; break;
                }

                if (R["data_scadenza_pagam_siope"] != DBNull.Value) {
                    DateTime data_scadenza_pagam_siope = DateTime.Now;
                    DateTime.TryParse(R["data_scadenza_pagam_siope"].ToString(), out data_scadenza_pagam_siope);
                    FF.dati_fattura_siope.data_scadenza_pagam_siope = data_scadenza_pagam_siope;
                    FF.dati_fattura_siope.data_scadenza_pagam_siopeSpecified = true;
                }

                //FF.dati_fattura_siope.motivo_scadenza_siope
                switch (R["motivo_scadenza_siope"].ToString()) {
                    case "SCAD_FATTURA": FF.dati_fattura_siope.motivo_scadenza_siope = incassi.ctDati_fattura_siopeMotivo_scadenza_siope.SCAD_FATTURA; break;
                    case "CORRETTA_SCAD_FATTURA": FF.dati_fattura_siope.motivo_scadenza_siope = incassi.ctDati_fattura_siopeMotivo_scadenza_siope.CORRETTA_SCAD_FATTURA; break;
                    case "SOSP_DECORRENZA_TERMINI": FF.dati_fattura_siope.motivo_scadenza_siope = incassi.ctDati_fattura_siopeMotivo_scadenza_siope.SOSP_DECORRENZA_TERMINI; break;
                }
                if (GetStringValue(R["motivo_scadenza_siope"]) != null) {
                    FF.dati_fattura_siope.motivo_scadenza_siopeSpecified = true;
                }

                //ClassDatiSiope.fattura_siope = FF;
                ClassDatiSiope.fattura_siope.Add(FF);
            }
            else {
                FF = null;
                //ClassDatiSiope.fattura_siope = FF;
                ClassDatiSiope.fattura_siope.Add(FF);
            }

            return FF;
        }

        public incassi.ctClassificazione_dati_siope_entrateDati_ARCONET_siope get_arconet_entrate(DataRow R) {
            incassi.ctClassificazione_dati_siope_entrateDati_ARCONET_siope arconet_entrate = new incassi.ctClassificazione_dati_siope_entrateDati_ARCONET_siope();
            arconet_entrate.codice_economico_siope = R["codice_economico_siope"].ToString();
            arconet_entrate.importo_codice_economico_siope = CfgFn.GetNoNullDecimal(R["importo_codice_economico_siope"]);
            arconet_entrate.codice_UE_siope = R["codice_UE_siope"].ToString();
            return arconet_entrate;
        }

        public incassi.ctClassificazione_dati_siope_entrate get_classificazione_entrateIntestazione(DataRow R) {
            incassi.ctClassificazione_dati_siope_entrate ClassDatiSiope = new incassi.ctClassificazione_dati_siope_entrate();
            //Enum
            bool commerciale = false;
            if (R["tipo_debito_siope"].ToString().Equals("IVA")) {
                ClassDatiSiope.tipo_debito_siope_nc = incassi.stTipo_debito_non_commerciale.IVA;
            }
            if (R["tipo_debito_siope"].ToString().Equals("NON COMMERCIALE")) {
                ClassDatiSiope.tipo_debito_siope_nc = incassi.stTipo_debito_non_commerciale.NON_COMMERCIALE;
            }
            if (R["tipo_debito_siope"].ToString().Equals("COMMERCIALE")) {
                ClassDatiSiope.tipo_debito_siope_c = incassi.stTipo_debito_commerciale.COMMERCIALE;
                commerciale = true;
            }
            return ClassDatiSiope;
        }
        public incassi.reversaleInformazioni_versanteClassificazione get_classificazione_entrate(DataRow R) {
            incassi.reversaleInformazioni_versanteClassificazione CC = new incassi.reversaleInformazioni_versanteClassificazione();
            CC.codice_cge = GetStringValue(R["codice_cge"]);
            CC.importo = CfgFn.GetNoNullDecimal(R["importoclassificazionemov"]);

            string codice_cge = R["codice_cge"].ToString();
            int idinc = CfgFn.GetNoNullInt32(R["idinc"]);
            string idinc_idsor = idinc.ToString() + '_' + codice_cge;
            incassi.ctClassificazione_dati_siope_entrate ClassDatiSiope = new incassi.ctClassificazione_dati_siope_entrate();
            //Dictionary di < fattura_siope >
            foreach (var item in FatturaSiope_perIdincIdsorFatt) {
                var itemKey = item.Key;
                string[] ArrItemKey = itemKey.Split('_');
                string itemIdincIdsor = ArrItemKey[0].ToString() + '_' + ArrItemKey[1].ToString();
                if (itemIdincIdsor != idinc_idsor) continue;
                //Valorizza i primi elementi di <classificazione_dati_siope_entrate>
                ClassDatiSiope.tipo_debito_siope_c = ClassDatiSiopeIntestazione_perIdincIdsorFatt[itemIdincIdsor].tipo_debito_siope_c;
                ClassDatiSiope.tipo_debito_siope_nc = ClassDatiSiopeIntestazione_perIdincIdsorFatt[itemIdincIdsor].tipo_debito_siope_nc;
                //Poi aggiungo <fattura_siope>  con tutti i suoi elementi                                                                                                                      
                bool commerciale = (ClassDatiSiope.tipo_debito_siope_c == incassi.stTipo_debito_commerciale.COMMERCIALE);
                if (commerciale) {
                    // Valorizza <fattura_siope>
                    //ClassDatiSiope.fattura_siope = item.Value;
                    ClassDatiSiope.fattura_siope.Add(item.Value);
                }
                else {
                    incassi.ctFattura_siope FF = new incassi.ctFattura_siope();
                    FF = null;
                    //ClassDatiSiope.fattura_siope = FF;
                    ClassDatiSiope.fattura_siope.Add(FF);
                }

            }

            //        bool commerciale = false;
            //        if (R["tipo_debito_siope"].ToString().Equals("IVA")) {
            //            ClassDatiSiope.tipo_debito_siope_nc = incassi.stTipo_debito_non_commerciale.IVA;
            //        }
            //        if (R["tipo_debito_siope"].ToString().Equals("NON COMMERCIALE")) {
            //            ClassDatiSiope.tipo_debito_siope_nc = incassi.stTipo_debito_non_commerciale.NON_COMMERCIALE;
            //        }
            //        if (R["tipo_debito_siope"].ToString().Equals("COMMERCIALE")) {
            //            ClassDatiSiope.tipo_debito_siope_c = incassi.stTipo_debito_commerciale.COMMERCIALE;
            //            commerciale = true;
            //        }
            //        if (commerciale) {
            //            incassi.ctFattura_siope FF = new incassi.ctFattura_siope();
            //            FF.codice_ipa_ente_siope = GetStringValue(R["codice_ipa_ente_siope"]);
            //            //qui vanno messi gli items
            //            if (R["tipo_documento_siope"].ToString() == "ELETTRONICO") {
            //                FF.tipo_documento_siope_e = FF.tipo_documento_siope_e = incassi.stTipo_documento_elettronico.ELETTRONICO;
            //                FF.identificativo_lotto_sdi_siope = CfgFn.GetNoNullInt32(R["identificativo_lotto_sdi_siope"]);
            //            }
            //            if (R["tipo_documento_siope"].ToString() == "ANALOGICO") {
            //                FF.tipo_documento_siope_a = incassi.stTipo_documento_analogico.ANALOGICO;
            //                switch (R["tipo_documento_analogico_siope"].ToString()) {
            //                    case "FATT_ANALOGICA": FF.tipo_documento_analogico_siope = incassi.ctFattura_siopeTipo_documento_analogico_siope.FATT_ANALOGICA; break;
            //                    case "DOC_EQUIVALENTE": FF.tipo_documento_analogico_siope = incassi.ctFattura_siopeTipo_documento_analogico_siope.DOC_EQUIVALENTE; break;
            //                }
            //                FF.codice_fiscale_emittente_siope = GetStringValue(R["codice_fiscale_emittente_siope"]);
            //                FF.anno_emissione_fattura_siope = GetStringValue(R["anno_emissione_fattura_siope"]);

            //            }
            //FF.ShouldSerializeidentificativo_lotto_sdi_siope();
            //FF.dati_fattura_siope.numero_fattura_siope = GetStringValue(R["numero_fattura_siope"]);
            //            FF.dati_fattura_siope.importo_siope = CfgFn.GetNoNullDecimal(R["importo_siope"]);
            //FF.ShouldSerializetipo_documento_analogico_siope();
            //FF.ShouldSerializetipo_documento_siope_a();
            //FF.ShouldSerializetipo_documento_siope_e();
            //            //Enum
            //            switch (R["natura_spesa_siope"].ToString()) {
            //                case "CORRENTE": FF.dati_fattura_siope.natura_spesa_siope = incassi.ctDati_fattura_siopeNatura_spesa_siope.CORRENTE; break;
            //                case "CAPITALE": FF.dati_fattura_siope.natura_spesa_siope = incassi.ctDati_fattura_siopeNatura_spesa_siope.CAPITALE; break;
            //            }

            //            if (R["data_scadenza_pagam_siope"] != null) {
            //                DateTime data_scadenza_pagam_siope = DateTime.Now;
            //                DateTime.TryParse(R["data_scadenza_pagam_siope"].ToString(), out data_scadenza_pagam_siope);
            //                FF.dati_fattura_siope.data_scadenza_pagam_siope = data_scadenza_pagam_siope;
            //                FF.dati_fattura_siope.data_scadenza_pagam_siopeSpecified = true;
            //            }

            //            //FF.dati_fattura_siope.motivo_scadenza_siope
            //            switch (R["motivo_scadenza_siope"].ToString()) {
            //                case "SCAD_FATTURA": FF.dati_fattura_siope.motivo_scadenza_siope = incassi.ctDati_fattura_siopeMotivo_scadenza_siope.SCAD_FATTURA; break;
            //                case "CORRETTA_SCAD_FATTURA": FF.dati_fattura_siope.motivo_scadenza_siope = incassi.ctDati_fattura_siopeMotivo_scadenza_siope.CORRETTA_SCAD_FATTURA; break;
            //                case "SOSP_DECORRENZA_TERMINI": FF.dati_fattura_siope.motivo_scadenza_siope = incassi.ctDati_fattura_siopeMotivo_scadenza_siope.SOSP_DECORRENZA_TERMINI; break;
            //            }
            //            if (GetStringValue(R["motivo_scadenza_siope"]) != null) {
            //                FF.dati_fattura_siope.motivo_scadenza_siopeSpecified = true;
            //            }

            //            ClassDatiSiope.fattura_siope = FF;
            //        }
            //        else {
            //            incassi.ctFattura_siope FF = new incassi.ctFattura_siope();
            //            FF = null;
            //            ClassDatiSiope.fattura_siope = FF;
            //        }
            foreach (var item in Arconet_perIdincIdsor) {
                var itemKey = item.Key;
                string[] ArrItemKey = itemKey.Split('_');
                string itemIdincIdsor = ArrItemKey[0].ToString() + '_' + ArrItemKey[1].ToString();
                if (itemIdincIdsor != idinc_idsor) continue;
                ClassDatiSiope.dati_ARCONET_siope = Arconet_perIdincIdsor[itemIdincIdsor];
            }
            CC.classificazione_dati_siope_entrate = ClassDatiSiope;
            return CC;
        }
        public void Aggiungi_classificazione_entrate(DataTable T, incassi.reversaleInformazioni_versante Rinfomazioni_versante, DataRow RB) {
            string selettore = QHC.AppAnd(
                QHC.CmpEq("kind", "CLASSIFICAZIONI"),
                QHC.CmpEq("ndoc", RB["ndoc"]),
                QHC.CmpEq("idpro", RB["idpro"])
                );
            DataRow[] RR = T.Select(selettore);
            if (RR.Length == 0) {
                return;
            }
            foreach (DataRow R in RR) {
                incassi.reversaleInformazioni_versanteClassificazione CC = get_classificazione_entrate(R);
                Rinfomazioni_versante.classificazione.Add(CC);
            }
            return;
        }

        public incassi.reversaleInformazioni_versante get_informazioni_versante(DataRow R) {

            incassi.reversaleInformazioni_versante Rinfomazioni_versante = new incassi.reversaleInformazioni_versante();
            Rinfomazioni_versante.progressivo_versante = R["progressivo_versante"].ToString();
            Rinfomazioni_versante.importo_versante = CfgFn.GetNoNullDecimal(R["importo_versante"]);

            if (R["tipo_riscossione"] != DBNull.Value) {
                Rinfomazioni_versante.tipo_riscossione =
                    ToForcedEnum<incassi.reversaleInformazioni_versanteTipo_riscossione>(R["tipo_riscossione"]
                        .ToString());
            }

            Rinfomazioni_versante.numero_ccp = GetStringValue(R["numero_ccp"]);

            if (R["tipo_entrata"] != DBNull.Value) {
                Rinfomazioni_versante.tipo_entrata =
                    ToForcedEnum<incassi.reversaleInformazioni_versanteTipo_entrata>(R["tipo_entrata"].ToString());
            }

            if (R["destinazione"] != DBNull.Value) {
                Rinfomazioni_versante.destinazione =
                    ToForcedEnum<incassi.reversaleInformazioni_versanteDestinazione>(R["destinazione"].ToString());
            }


            // Bollo
            if (R["assoggettamento_bollo"] != DBNull.Value) {
                string bollo = R["assoggettamento_bollo"].ToString();
                if (bollo.ToUpper() == "ESENTE") bollo = "ESENTEBOLLO";
                if (bollo.ToUpper() == "ESENTE BOLLO") bollo = "ESENTEBOLLO";
                Rinfomazioni_versante.bollo.assoggettamento_bollo =
                    ToForcedEnum<incassi.reversaleInformazioni_versanteBolloAssoggettamento_bollo>(bollo);
            }
           
            Rinfomazioni_versante.bollo.causale_esenzione_bollo = GetStringValue(R["causale_esenzione_bollo"]);

            // versante
            Rinfomazioni_versante.versante.anagrafica_versante = GetStringValue(R["anagrafica_versante"]);
            Rinfomazioni_versante.versante.indirizzo_versante = GetStringValue(R["indirizzo_versante"]);
            Rinfomazioni_versante.versante.cap_versante = GetStringValue(R["cap_versante"]);
            Rinfomazioni_versante.versante.localita_versante = GetStringValue(R["localita_versante"]);
            Rinfomazioni_versante.versante.provincia_versante = GetStringValue(R["provincia_versante"]);
            Rinfomazioni_versante.versante.stato_versante = GetStringValue(R["stato_versante"]);
            Rinfomazioni_versante.versante.partita_iva_versante = GetStringValue(R["partita_iva_versante"]);
            Rinfomazioni_versante.versante.codice_fiscale_versante = GetStringValue(R["codice_fiscale_versante"]);


            Rinfomazioni_versante.causale = GetStringValue(R["causale"]);
           
            if (GetStringValue(R["numero_mandato"]) != null) {
                incassi.mandato_associato MS = new incassi.mandato_associato();
                MS.numero_mandato = GetStringValue(R["numero_mandato"]);
                MS.progressivo_beneficiario = GetStringValue(R["progressivo_beneficiario"]);
                Rinfomazioni_versante.mandato_associato.Add(MS);
            }
            incassi.informazioni_aggiuntive IA = new incassi.informazioni_aggiuntive();
            IA.riferimento_documento_esterno = GetStringValue(R["riferimento_documento_esterno"]);
            Rinfomazioni_versante.informazioni_aggiuntive = IA;
            return Rinfomazioni_versante;
        }


        Dictionary<string, incassi.ctFattura_siope> FatturaSiope_perIdincIdsorFatt = new Dictionary<string, incassi.ctFattura_siope>();
        Dictionary<string, incassi.ctClassificazione_dati_siope_entrate> ClassDatiSiopeIntestazione_perIdincIdsorFatt =
            new Dictionary<string, incassi.ctClassificazione_dati_siope_entrate>();

        public Dictionary<int, incassi.reversaleInformazioni_versante> get_listaVersanti(DataTable T) {
            Dictionary<int, incassi.reversaleInformazioni_versante> versantiPerIdInc = new Dictionary<int, incassi.reversaleInformazioni_versante>();

            foreach (DataRow R in T.Rows) {
                if (R.RowState == DataRowState.Deleted) continue;
                int idinc = CfgFn.GetNoNullInt32(R["idinc"]);
                if (R["kind"].ToString().Trim()=="INFO_VERSANTE") {
                        if (idinc == 0) {
                            MetaFactory.factory.getSingleton<IMessageShower>().Show("Ci sono problemi per l'incasso numero " + R["nmov"]);
                            return null;
                        }

                        var vers = get_informazioni_versante(R);
                        versantiPerIdInc[idinc] = vers;
                        if (vers == null) return null;
                }
            }

            foreach (DataRow R in T.Rows) {
                if (R.RowState == DataRowState.Deleted) continue;
                string codice_cge = R["codice_cge"].ToString();
                string motivo_scadenza_siope = R["motivo_scadenza_siope"].ToString();
                int idinc = CfgFn.GetNoNullInt32(R["idinc"]);
                string numero_fattura_siope = R["numero_fattura_siope"].ToString();//da sostituire con yinv_ninv_idinvkind
                string idinc_idsor_fatt = idinc.ToString() + '_' + codice_cge + '_' + numero_fattura_siope+'_'+ motivo_scadenza_siope;
                if (R["kind"].ToString().Trim() == "CLASSIFICAZIONI_FATTURASIOPE") {
                    var FattSiope = get_classificazione_fatture_entrate(R);
                    FatturaSiope_perIdincIdsorFatt[idinc_idsor_fatt] = FattSiope;
                    //var ClassFattIntestazione = get_classificazione_usciteIntestazione(R);
                    //ClassDatiSiopeIntestazione_perIdexpIdsorFatt[idexp_idsor_fatt] = ClassFattIntestazione;
                }
                string idinc_idsor = idinc.ToString() + '_' + codice_cge;
                if (R["kind"].ToString().Trim() == "CLASSIFICAZIONI") {
                    var ClassFattIntestazione = get_classificazione_entrateIntestazione(R);
                    ClassDatiSiopeIntestazione_perIdincIdsorFatt[idinc_idsor] = ClassFattIntestazione;
                }
                if (R["kind"].ToString().Trim() == "ARCONET") {
                    var Arconet = get_arconet_entrate(R);
                    Arconet_perIdincIdsor[idinc_idsor] = Arconet;
                }
            }

            foreach (DataRow R in T.Rows) {
                if (R.RowState==DataRowState.Deleted)continue;
                int idinc = CfgFn.GetNoNullInt32(R["idinc"]);
                switch (R["kind"].ToString().Trim()) {
                    case "CLASSIFICAZIONI": {
                        var versClass = versantiPerIdInc[idinc];
                            incassi.reversaleInformazioni_versanteClassificazione CC = get_classificazione_entrate(R);
                            if (CC != null) {
                                versClass.classificazione.Add(CC);
                            }
                            break;
                        }
                    case "SOSPESI": {
                        var versSosp = versantiPerIdInc[idinc];
                            incassi.reversaleInformazioni_versanteSospeso SOSP = get_sospeso_entrate(R);
                            if (SOSP != null) {
                                versSosp.sospeso.Add(SOSP);
                            }
                            break;
                        }
                }
            }
            return versantiPerIdInc;
        }
        public string Crea_flusso_ordinativi_inc(DataTable T, out bool stop) {
            stop = false;
            string selettore = "(kind='TESTATA')";
            DataRow[] rTestate = T.Select(selettore);
            if (rTestate.Length == 0) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Riga flusso_ordinativi non trovata, filtro utilizzato = " + selettore,
                                        "Errore");
                return null;
            }
            DataRow rTestata = rTestate[0];

            //Aggiunge righe figlie a Flusso
            incassi.flusso_ordinativi F = new incassi.flusso_ordinativi();

            var rReversali = T.Select("(kind='REVERSALE')");
            if (rReversali.Length == 0) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Nessuna reversale trovata.");
                return null;
            }
            F.testata_flusso.codice_ABI_BT = GetStringValue(rTestata["codice_ABI_BT"]);
            F.testata_flusso.identificativo_flusso = GetStringValue(rTestata["identificativo_flusso"]);
            F.testata_flusso.data_ora_creazione_flusso = (DateTime)rTestata["data_ora_creazione_flusso"];
            F.testata_flusso.codice_ente = GetStringValue(rTestata["codice_ente"]);
            F.testata_flusso.descrizione_ente = GetStringValue(rTestata["descrizione_ente"]);
            F.testata_flusso.codice_istat_ente = GetStringValue(rTestata["codice_istat_ente"]);
            F.testata_flusso.codice_fiscale_ente = GetStringValue(rTestata["codice_fiscale_ente"]);
            F.testata_flusso.codice_tramite_ente = GetStringValue(rTestata["codice_tramite_ente"]);
            F.testata_flusso.codice_tramite_BT = GetStringValue(rTestata["codice_tramite_BT"]);
            F.testata_flusso.codice_ente_BT = GetStringValue(rTestata["codice_ente_BT"]);
            F.testata_flusso.riferimento_ente = GetStringValue(rTestata["riferimento_ente"].ToString());
            F.esercizio = Conn.GetSys("esercizio").ToString();

            
            Dictionary<int, incassi.reversale> reversali = new Dictionary<int, incassi.reversale>();
            Dictionary<int, int> reversaliPerIdInc= new Dictionary<int, int>();//restituisce il mandato di ogni mov. di spesa

            //crea le reversali pure
            foreach (var reve in rReversali) {
                var m = creaReversale(reve);
                if (m == null) return null;
                reversali[(int) reve["ndoc"]] = m;
                   
                incassi.ctDati_a_disposizione_ente_reversale dati_a_disposizione_ente_reversale = new incassi.ctDati_a_disposizione_ente_reversale();
                dati_a_disposizione_ente_reversale.struttura = rReversali[0]["dati_codice_struttura"].ToString();
                dati_a_disposizione_ente_reversale.codice_struttura= rReversali[0]["dati_codice_struttura"].ToString();
                dati_a_disposizione_ente_reversale.codice_ipa_struttura = rReversali[0]["dati_codice_ipa_struttura"].ToString();
                m.dati_a_disposizione_ente_reversale = dati_a_disposizione_ente_reversale;
                F.Items.Add(m);
            }

            foreach (DataRow r in T.Rows) {
                if (r.RowState == DataRowState.Deleted) continue;
                if ((r["ndoc"] != DBNull.Value) && (r["idinc"] != DBNull.Value)) {
                    reversaliPerIdInc[(int)r["idinc"]] = (int)r["ndoc"];//eventuali altri filtri
                }
            }
            var versanti = get_listaVersanti(T);
          
            foreach (var versante in versanti) {
                var idinc = versante.Key;
                var infoVersante = versante.Value;
                var ndoc = reversaliPerIdInc[idinc];
                reversali[ndoc].informazioni_versante.Add(infoVersante);
               
            }

            foreach (var versante in versanti) {
	            var infoVersante = versante.Value;
	            if (infoVersante.sospeso?.Count  > 1000) {
		            MetaFactory.factory.getSingleton<IMessageShower>().Show(
			            $" Invio non eseguibile!\r\n Il L'incasso da {infoVersante.versante.anagrafica_versante} ha più di 1000 sospesi.");
		            return null;
	            }
            }

            foreach (var reversale in reversali) {
                string r = reversale.toXml(Encoding.GetEncoding("ISO-8859-1"));
                if (r.Length>=  limiteOPIinByte) {
                    MetaFactory.factory.getSingleton<IMessageShower>().Show(
                        $" Invio non eseguibile!\r\n La reversale n.{reversale.Value.numero_reversale} supera la dimensione massima consentita ({r.Length}).");
                    return null;
                }
            }

            string D = F.toXml(Encoding.GetEncoding("ISO-8859-1"));
            if (D == null) return null;

            return D;
        }


    }
}
