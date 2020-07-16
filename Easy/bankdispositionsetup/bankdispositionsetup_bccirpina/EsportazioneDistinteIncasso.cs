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
using System.Data;
using funzioni_configurazione;
using metadatalibrary;
using metaeasylibrary;
using System.Windows.Forms;
using System.Collections;
using System.Xml;

namespace bankdispositionsetup_bccirpina {
 
    public class EsportazioneDistinteIncasso {
        DataAccess Conn;
        int yproceedstransmission;
        int nproceedstransmission;
        QueryHelper QHS;
        CQueryHelper QHC;
        Sepa_incassi schema= new Sepa_incassi();

        public EsportazioneDistinteIncasso(DataAccess Conn, int yproceedstransmission, int nproceedstransmission) {
            this.Conn = Conn;
            this.yproceedstransmission = yproceedstransmission;
            this.nproceedstransmission = nproceedstransmission;
            QHS = Conn.GetQueryHelper();
            QHC = new CQueryHelper();

        }


        public XmlDocument GeneraFileXML() {
            DataTable P = Conn.RUN_SELECT("proceedstransmission", "*", null,
                    QHS.AppAnd(QHS.CmpEq("yproceedstransmission", yproceedstransmission),
                                QHS.CmpEq("nproceedstransmission", nproceedstransmission)), null, false);
            if (P == null || P.Rows.Count == 0) {
                MessageBox.Show("Non ho trovato la distinta n." + nproceedstransmission + " del " + yproceedstransmission,
                                "Errore");
                return null;
            }
            DataRow R = P.Rows[0];
            object spexportinc = Conn.DO_READ_VALUE("treasurer", QHS.CmpEq("idtreasurer", R["idtreasurer"]), "spexportinc");
            if (spexportinc == null || spexportinc == DBNull.Value)
            {
                MessageBox.Show("Il cassiere relativo alla distinta n." + nproceedstransmission +
                            " del " + yproceedstransmission + " non Ë ben configurato per l'esportazione elettronica", "Errore");
                return null;
            }

            DataSet D = Conn.CallSP(spexportinc.ToString(), new object[] { yproceedstransmission, nproceedstransmission }, false, 300);
            if (D == null || D.Tables.Count == 0) return null;
            DataTable T = D.Tables[0];
            if (T.Rows.Count == 0) {
                MessageBox.Show("L'esportazione Ë stata eseguita ma non ha restituito alcun risultato", "Errore");
                return null;
            }


            if (T.Columns.Count == 1) {
                FrmViewError View = new FrmViewError(D);
                View.Show();

                return null;
            }

            XmlDocument X = new XmlDocument();
            X.CreateXmlDeclaration("1.0", "ISO-8859-15", null);

            
            String ssheet = "type=\"text/xsl\" href=\".\\Ordinativi_2.0.xslt\"";
            XmlProcessingInstruction newPI = X.CreateProcessingInstruction("xml-stylesheet", ssheet);
            X.AppendChild(newPI);

            if (!Crea_flusso_ordinativi(X, T)) return null;

            string xsiNS = "http://www.w3.org/2001/XMLSchema-instance";
            string xmlnsNS = "http://www.w3.org/2000/xmlns/";
            XmlAttribute attributeNode = X.CreateAttribute("xmlns", "xsi", xmlnsNS);
            attributeNode.Value = xsiNS;
            X.DocumentElement.SetAttributeNode(attributeNode);

            attributeNode = X.CreateAttribute("xsi", "noNamespaceSchemaLocation", xsiNS);
            attributeNode.Value = "../../../XSD/ORDINATIVI_BCC_SCUOLE_MIUR.XSD";
            X.DocumentElement.SetAttributeNode(attributeNode);

            return X;                

        }


        bool Crea_flusso_ordinativi(XmlDocument x, DataTable T) {
            string selettore = "(kind='TESTATA')";
            DataRow[] RR = T.Select(selettore);
            if (RR.Length == 0) {
                MessageBox.Show("Riga flusso_ordinativi non trovata, filtro utilizzato = " + selettore,
                                        "Errore");
                return false;
            }
            DataRow R = RR[0];

            XmlElement Rflusso = XmlHelper.CreaRigaChild(x, schema.flusso_ordinativi, R, null);
            //Aggiunge righe figlie a RFLusso
            bool res= Aggiungi_reversali(Rflusso, T, R);
            XmlHelper.SortElement(Rflusso, new string[] {"codice_ABI_BT","identificativo_flusso","data_ora_creazione_flusso","codice_ente",
                        "descrizione_ente","codice_ente_BT","riferimento_ente","esercizio","reversale"});
            return res;
        }

        bool Aggiungi_reversali(XmlElement E, DataTable T, DataRow Rflusso) {
            string selettore = "(kind='REVERSALE')";
            DataRow[] RR = T.Select(selettore);
            if (RR.Length == 0) {
                MessageBox.Show("Nessuna reversale trovata.");
                return false;
            }
            foreach (DataRow R in RR) {
                XmlElement Rreversale = XmlHelper.CreaRigaChild(E, schema.reversale, R, null);
                if (Rreversale == null) {
                    MessageBox.Show("Saltata reversale n." + R["ndoc"].ToString() + " per errore di dati");
                    return false;
                }
                if (!Aggiungi_informazioni_versante(Rreversale, T, R)) return false;
                //XmlHelper.CreaRigaChild(Rreversale, schema.dati_a_disposizione_ente_reversale, R, null);
                XmlHelper.SortElement(Rreversale, new string[] {"tipo_operazione","numero_reversale","data_reversale","importo_reversale",
                            "conto_evidenza","informazioni_versante","dati_a_disposizione_ente_reversale"});
            }
            return true;

        }

        bool Aggiungi_informazioni_versante(XmlElement E, DataTable T, DataRow Rreversale) {
           // if (Rreversale["tipo_operazione"].ToString() == "ANNULLO") return true; // va inserita solo la testata del documento
            string selettore = QHC.AppAnd(
                              QHC.CmpEq("kind", "INFO_VERSANTE"),
                              QHC.CmpEq("ndoc", Rreversale["ndoc"])
                              );
            DataRow[] RR = T.Select(selettore);
            if (RR.Length == 0) {
                MessageBox.Show("Informazioni sul versante non trovate per la reversale n." +
                                    Rreversale["ndoc"].ToString(), "Errore");
                return false;
            }
            foreach (DataRow R in RR) {
                XmlElement Rinformazioni_versante = XmlHelper.CreaRigaChild(E, schema.informazioni_versante, R, null);
                if (Rinformazioni_versante == null) {
                    MessageBox.Show("Informazioni sul versante non trovate per la reversale n." +
                                    R["ndoc"].ToString(), "Errore");
                    return false;
                }

                Aggiungi_classificazione(Rinformazioni_versante, T, R);

                XmlHelper.CreaRigaChild(Rinformazioni_versante, schema.bollo, R, null);

                XmlHelper.CreaRigaChild(Rinformazioni_versante, schema.versante, R, null);

                //XmlHelper.CreaRigaChild(Rinformazioni_versante, schema.sospeso, R, null);
                Aggiungi_sospeso(Rinformazioni_versante, T, R);

                XmlHelper.CreaRigaChild(Rinformazioni_versante, schema.mandato_associato, R, null);


                XmlHelper.CreaRigaChild(Rinformazioni_versante, schema.informazioni_aggiuntive, R, null);
                //XmlHelper.CreaRigaChild(Rinformazioni_versante, schema.sostituzione_reversale, R, null);
                //XmlHelper.CreaRigaChild(Rinformazioni_versante, schema.dati_a_disposizione_ente_versante, R, null);

                XmlHelper.SortElement(Rinformazioni_versante, new string[]{
                    "progressivo_versante","importo_versante","tipo_riscossione","numero_ccp","tipo_entrata",
                            "destinazione","classificazione","bollo",
                            "versante","causale",        
                            "sospeso","mandato_associato","informazioni_aggiuntive" 
                });

            }
            return true;
        }

        void Aggiungi_classificazione(XmlElement E, DataTable T, DataRow Rsp_data) {
            string selettore = QHC.AppAnd(
                    QHC.CmpEq("kind", "CLASSIFICAZIONI"),
                    QHC.CmpEq("ndoc", Rsp_data["ndoc"]),
                    QHC.CmpEq("idpro", Rsp_data["idpro"])
                    );
            DataRow[] RR = T.Select(selettore);
            if (RR.Length == 0) {
                return;
            }
            Hashtable H = new Hashtable();
            H["importo"] = "importo_siope";
            foreach (DataRow R in RR) {
                XmlElement Class= XmlHelper.CreaRigaChild(E, schema.classificazione, R, H);
                XmlHelper.SortElement(Class, new string[] { "codice_cge", "importo" });
            }
        }
        void Aggiungi_sospeso(XmlElement E, DataTable T, DataRow Rsp_data) {
            string selettore = QHC.AppAnd(
                    QHC.CmpEq("kind", "SOSPESI"),
                    QHC.CmpEq("ndoc", Rsp_data["ndoc"]),
                    QHC.CmpEq("idpro", Rsp_data["idpro"])
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
    }
}
