
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
using System.Text;
using System.Data;
using funzioni_configurazione;
using metadatalibrary;
using metaeasylibrary;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Xsl;
using System.Collections;

namespace bankdispositionsetup_mps_abi36 {
    public class EsportazioneDistintePagamento {
        DataAccess Conn;
        int ypaymenttransmission;
        int npaymenttransmission;
        QueryHelper QHS;
        CQueryHelper QHC;
        Sepa_pagamenti schema = new Sepa_pagamenti();
       

        public EsportazioneDistintePagamento(DataAccess Conn, int ypaymenttransmission, int npaymenttransmission) {
            this.Conn = Conn;
            this.ypaymenttransmission = ypaymenttransmission;
            this.npaymenttransmission = npaymenttransmission;
            QHS = Conn.GetQueryHelper();
            QHC = new CQueryHelper();
        }
        public XmlDocument GeneraFileXML() {
            DataTable P = Conn.RUN_SELECT("paymenttransmission", "*", null,
                    QHS.AppAnd(QHS.CmpEq("ypaymenttransmission", ypaymenttransmission),
                                QHS.CmpEq("npaymenttransmission", npaymenttransmission)), null, false);
            if (P == null || P.Rows.Count == 0) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Non ho trovato la distinta n." + npaymenttransmission + " del " + ypaymenttransmission,
                                "Errore");
                return null;
            }
            DataRow R = P.Rows[0];
            object spexportexp = Conn.DO_READ_VALUE("treasurer", QHS.CmpEq("idtreasurer", R["idtreasurer"]), "spexportexp");
            if (spexportexp == null || spexportexp == DBNull.Value) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Il cassiere relativo alla distinta n." + npaymenttransmission +
                            " del " + ypaymenttransmission + " non è ben configurato per l'esportazione elettronica", "Errore");
                return null;
            }

            DataSet D = Conn.CallSP(spexportexp.ToString(), new object[] { ypaymenttransmission, npaymenttransmission }, false, 300);
            if (D == null || D.Tables.Count == 0) return null;
            DataTable T = D.Tables[0];
            if (T.Rows.Count == 0) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("L'esportazione è stata eseguita ma non ha restituito alcun risultato", "Errore");
                return null;
            }


            if (T.Columns.Count == 1) {
                FrmViewError View = new FrmViewError(D);
                View.Show();

                return null;
            }

            XmlDocument X = new XmlDocument();
            X.CreateXmlDeclaration("1.0", "ISO-8859-15", null);  //ISO-8859-15

            String ssheet = "type=\"text/xsl\" href=\".\\ORDINATIVI_3.02.xslt\"";
            XmlProcessingInstruction newPI = X.CreateProcessingInstruction("xml-stylesheet", ssheet);
            X.AppendChild(newPI);

            if (!Crea_flusso_ordinativi(X, T)) return null;


            string xsiNS = "http://www.w3.org/2001/XMLSchema-instance";
            string xmlnsNS = "http://www.w3.org/2000/xmlns/";
            XmlAttribute attributeNode = X.CreateAttribute("xmlns", "xsi", xmlnsNS);
            attributeNode.Value = xsiNS;
            X.DocumentElement.SetAttributeNode(attributeNode);

            attributeNode = X.CreateAttribute("xsi","noNamespaceSchemaLocation", xsiNS);
            attributeNode.Value = "../../../XSD/ORDINATIVI_3.02.XSD";
            X.DocumentElement.SetAttributeNode(attributeNode);


            return X;

        }

        bool Crea_flusso_ordinativi(XmlDocument X, DataTable T) {
            string selettore = "(kind='TESTATA')";
            DataRow[] RR = T.Select(selettore);
            if (RR.Length == 0) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Riga flusso_ordinativi non trovata, filtro utilizzato = " + selettore,
                                        "Errore");
                return  false;
            }
            DataRow R = RR[0];

           

            
            XmlElement Rflusso = XmlHelper.CreaRigaChild(X, schema.flusso_ordinativi, R, null);
            //Aggiunge righe figlie a RFLusso
            bool res= Aggiungi_mandati(Rflusso, T, R);

            XmlHelper.SortElement(Rflusso, new string[] {"codice_ABI_BT","identificativo_flusso","data_ora_creazione_flusso","codice_ente",
                        "descrizione_ente","codice_ente_BT","riferimento_ente","esercizio","mandato"});

            return res;
            
        }


        bool Aggiungi_mandati(XmlElement E, DataTable T, DataRow Rflusso) {
            string selettore = "(kind='MANDATO')";
            DataRow[] RR = T.Select(selettore);
            if (RR.Length == 0) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Nessun mandato trovato.");
                return false;
            }
            foreach (DataRow R in RR) {
                XmlElement Rmandato = XmlHelper.CreaRigaChild(E, schema.mandato, R, null);
                if (Rmandato == null) {
                    MetaFactory.factory.getSingleton<IMessageShower>().Show("Saltato mandato n." + R["ndoc"].ToString() + " per errore di dati");
                    return false;
                }
                if (!Aggiungi_informazioni_beneficiario(Rmandato, T, R)) return false;
                //XmlHelper.CreaRigaChild(E, schema.dati_a_disposizione_ente_mandato, R, null);
                XmlHelper.SortElement(Rmandato, new string[] {"tipo_operazione","numero_mandato","data_mandato","importo_mandato",
                            "conto_evidenza",
                            "estremi_provvedimento_autorizzativo","responsabile_provvedimento","ufficio_responsabile",
                            "informazioni_beneficiario"});
            }
            return true;
        }


        

        bool Aggiungi_informazioni_beneficiario(XmlElement E, DataTable T, DataRow Rmandato) {
           // if (Rmandato["tipo_operazione"].ToString() == "ANNULLO") return true; // va inserita solo la testata del documento

            string selettore = QHC.AppAnd(
                              QHC.CmpEq("kind", "INFO_BENEFICIARIO"),
                              QHC.CmpEq("ndoc", Rmandato["ndoc"])
                              );
            DataRow[] RR = T.Select(selettore);
            if (RR.Length == 0) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Informazioni sul beneficiario non trovate per il mandato n." +
                                    Rmandato["ndoc"].ToString(), "Errore");
                return false;
            }
            foreach (DataRow R in RR) {
                XmlElement Rinformazioni_beneficiario =
                    XmlHelper.CreaRigaChild(E, schema.informazioni_beneficiario, R, null);
                if (Rinformazioni_beneficiario == null) {
                    MetaFactory.factory.getSingleton<IMessageShower>().Show("Informazioni sul beneficiario non trovate per il mandato n." +
                                    R["ndoc"].ToString(), "Errore");
                    return false;
                }

                Aggiungi_classificazione(Rinformazioni_beneficiario,  T, R);
                Aggiungi_ritenute(Rinformazioni_beneficiario,  T, R);
                XmlHelper.CreaRigaChild(Rinformazioni_beneficiario, schema.bollo, R, null);
                XmlHelper.CreaRigaChild(Rinformazioni_beneficiario, schema.spese, R, null);
                XmlHelper.CreaRigaChild(Rinformazioni_beneficiario, schema.beneficiario, R, null);
                XmlHelper.CreaRigaChild(Rinformazioni_beneficiario, schema.delegato, R, null);
                XmlHelper.CreaRigaChild(Rinformazioni_beneficiario, schema.creditore_effettivo, R, null);
                XmlElement Piazzatura = XmlHelper.CreaRigaChild(Rinformazioni_beneficiario, schema.piazzatura, R, null);
                XmlHelper.CreaRigaChild(Rinformazioni_beneficiario, schema.sepa_credit_transfer, R, null);
                
                //XmlHelper.CreaRigaChild(Rinformazioni_beneficiario, schema.sospeso, R, null);
                Aggiungi_sospeso(Rinformazioni_beneficiario, T, R);

                XmlHelper.CreaRigaChild(Rinformazioni_beneficiario, schema.informazioni_aggiuntive, R, null);
                //XmlHelper.CreaRigaChild(Rinformazioni_beneficiario, schema.sostituzione_mandato, R, null);
                //XmlHelper.CreaRigaChild(Rinformazioni_beneficiario, schema.dati_a_disposizione_ente_beneficiario, R, null);

                XmlHelper.SortElement(Rinformazioni_beneficiario, new string[]{
                    "progressivo_beneficiario","importo_beneficiario","tipo_pagamento","impignorabili","frazionabile",
                            "gestione_provvisoria",
                            "data_esecuzione_pagamento","data_scadenza_pagamento","destinazione",
                            "numero_conto_banca_italia_ente_ricevente","tipo_contabilita_ente_ricevente",  
                            "classificazione","bollo","spese","beneficiario", "delegato","creditore_effettivo",
                            "piazzatura","sepa_credit_transfer", "causale", "sospeso","ritenute",
                            "informazioni_aggiuntive"
                });
               
                XmlHelper.SortElement(Piazzatura, new string[]{"abi_beneficiario","cab_beneficiario", 
                    "numero_conto_corrente_beneficiario","caratteri_controllo","codice_cin","codice_paese",
                    "denominazione_banca_destinataria"
                });
            }
            return true;
        }

        void Aggiungi_classificazione(XmlElement E,  DataTable T, DataRow Rsp_data) {
            string selettore = QHC.AppAnd(
                    QHC.CmpEq("kind","CLASSIFICAZIONI"),
                    QHC.CmpEq("ndoc",Rsp_data["ndoc"]),
                    QHC.CmpEq("idpay",Rsp_data["idpay"])
                    );
            DataRow[] RR = T.Select(selettore);
            if (RR.Length == 0) {
                return;
            }
            Hashtable H = new Hashtable();
            H["importo"] = "importo_siope";
            foreach (DataRow R in RR) {
                XmlElement Class = XmlHelper.CreaRigaChild(E, schema.classificazione, R, H);
                XmlHelper.SortElement(Class, new string[] { "codice_cgu", "codice_cup", "codice_cpv", "importo" });
            }
            
        }

        void Aggiungi_sospeso(XmlElement E, DataTable T, DataRow Rsp_data) {
            string selettore = QHC.AppAnd(
                    QHC.CmpEq("kind", "SOSPESI"),
                    QHC.CmpEq("ndoc", Rsp_data["ndoc"]),
                    QHC.CmpEq("idpay", Rsp_data["idpay"])
                    );
            DataRow[] RR = T.Select(selettore);
            if (RR.Length == 0) {
                return;
            }
            foreach (DataRow R in RR) {
                XmlElement Class = XmlHelper.CreaRigaChild(E, schema.sospeso, R, null);
                XmlHelper.SortElement(Class, new string[] { "numero_provvisorio", "importo_provvisorio" });
            }
        }

        void Aggiungi_ritenute(XmlElement E, DataTable T, DataRow Rsp_data) {
            string selettore = QHC.AppAnd(
                    QHC.CmpEq("kind", "RITENUTE"),
                    QHC.CmpEq("ndoc", Rsp_data["ndoc"]),
                    QHC.CmpEq("idpay", Rsp_data["idpay"])
                    );
            DataRow[] RR = T.Select(selettore);
            if (RR.Length == 0) {
                return;
            }
            foreach (DataRow R in RR) {
                XmlElement Ritenute = XmlHelper.CreaRigaChild(E, schema.ritenute, R, null);
                XmlHelper.SortElement(Ritenute, new string[] { "importo_ritenute", "numero_reversale", "progressivo_versante" });
            }
        }




       
    }
}
