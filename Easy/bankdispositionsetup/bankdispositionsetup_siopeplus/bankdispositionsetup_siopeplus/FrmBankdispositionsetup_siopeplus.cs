/*
    Easy
    Copyright (C) 2019 Universit� degli Studi di Catania (www.unict.it)

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

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using funzioni_configurazione;
using metadatalibrary;
using System.Globalization;
using pagamenti=bankdispositionsetup_siopeplus_pagamenti;
using incassi=bankdispositionsetup_siopeplus_incassi;
using genericSerializer;
using System.Xml;
using System.Xml.Xsl;
using System.IO;
using pagoPaService;
using Xceed.Zip;
using Xceed.Compression;
using Xceed.FileSystem;
using siopeplus_functions;

namespace bankdispositionsetup_siopeplus {
    public partial class FrmBankdispositionsetup_siopeplus :Form {
        public FrmBankdispositionsetup_siopeplus() {
            InitializeComponent();
        }
        DataAccess Conn;
        MetaData Meta;
        QueryHelper QHS;
        CQueryHelper QHC;

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);

            Meta.CanSave = false;
            Meta.SearchEnabled = false;
            Meta.MainRefreshEnabled = false;
            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
            Meta.CanCancel = false;

            Conn = MetaData.GetConnection(this);
            QHS = Conn.GetQueryHelper();
            QHC = new CQueryHelper();

            GetData.SetStaticFilter(DS.paymenttransmission, QHS.CmpEq("ypaymenttransmission", Conn.GetSys("esercizio")));
            GetData.SetStaticFilter(DS.proceedstransmission,
                QHS.CmpEq("yproceedstransmission", Conn.GetSys("esercizio")));

            string s;
            s = btnProceedsTransm.Tag.ToString();
            s = s.Replace("%<esercizio>%", Conn.GetSys("esercizio").ToString());
            btnProceedsTransm.Tag = s;

            s = btnPaymentTransm.Tag.ToString();
            s = s.Replace("%<esercizio>%", Conn.GetSys("esercizio").ToString());
            btnPaymentTransm.Tag = s;

            s = gboxIncassi.Tag.ToString();
            s = s.Replace("%<esercizio>%", Conn.GetSys("esercizio").ToString());
            gboxIncassi.Tag = s;

            s = gboxPagamenti.Tag.ToString();
            s = s.Replace("%<esercizio>%", Conn.GetSys("esercizio").ToString());
            gboxPagamenti.Tag = s;



            object ultimaEsitazioneDB = Meta.Conn.DO_READ_VALUE("banktransaction",
                "(yban = '" + Meta.GetSys("esercizio") + "')"
                , "max(transactiondate)");
            if (ultimaEsitazioneDB == DBNull.Value) {
                ultimaEsitazioneDB = Meta.Conn.DO_READ_VALUE("banktransaction",
                    "(yban = '" + (CfgFn.GetNoNullInt32(Meta.GetSys("esercizio")) - 1) + "' )"
                    , "max(transactiondate)");
            }
        }

        private void btnGeneraFilePagamenti_Click(object sender, EventArgs e) {
            int n = CfgFn.GetNoNullInt32(txtNPaymentTransmission.Text);
            if (n == 0) {
                MessageBox.Show(this, "E' necessario selezionare un numero per la distinta");
                return;
            }
            int y = CfgFn.GetNoNullInt32(Conn.GetSys("esercizio"));

            string filterPaymentTransmission = QHS.AppAnd(QHS.CmpEq("ypaymenttransmission", y),
                QHS.CmpEq("npaymenttransmission", n));
            object idtreasurer = Conn.DO_READ_VALUE("paymenttransmission", filterPaymentTransmission, "idtreasurer");
            object flagtransmissionenabled = Conn.DO_READ_VALUE("paymenttransmission", filterPaymentTransmission,
                "flagtransmissionenabled");
            object cfgflagenabletransmission = Conn.DO_READ_VALUE("config", QHS.CmpEq("ayear", y),
                "flagenabletransmission");

            if (cfgflagenabletransmission != DBNull.Value) {
                string cfg_flag = cfgflagenabletransmission.ToString().ToUpper();
                if ((cfg_flag == "S") && (flagtransmissionenabled.ToString().ToUpper() != "S")) {
                    MessageBox.Show(this, "La trasmissione della distinta non è stata autorizzata");
                    return;
                }
            }

            string fileName;
            var xml  =generaFileXML(y, n,"p",out fileName);
            if (xml==null || fileName==null)return;
            if (salvaFile(xml, fileName, n, idtreasurer, "p")) {
                AggiornaStreamDate("PAYMENTTRANSMISSION", y, n);
            }
            
        }

        public static string RemoveInvalidXmlChars(string content) {
            return new string(content.Where(ch => System.Xml.XmlConvert.IsXmlChar(ch)).ToArray());
        }


        bool salvaFile(XmlDocument document, string fname, int ntrasmission,object idtreasurer,string kind) {
            document.writeXmlToFile(fname,Encoding.GetEncoding("ISO-8859-1"));

            
            // Cerca di Validare il file
            try {
                bool res = XML_XSD_Validator.Validate(fname,
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "OPI_FLUSSO_ORDINATIVI_V_1_3_1.XSD"));
                if (!res) {
                    QueryCreator.ShowError(this, "Errore nella validazione dell'xml", XML_XSD_Validator.GetError());
                    return false;
                }
                else {
                    string middle = (kind == "p") ? "_mandati_" : "_reversali_";
                    TreasurerPutFile ftp = new TreasurerPutFile(Conn, idtreasurer);
                    string errori = ftp.putFile(fname, Conn.GetEsercizio() + middle + ntrasmission.ToString());
                    if (errori != null) {
                        MessageBox.Show(errori, "Errore nel trasferimento FTP");
                    }
                    else {
                        MessageBox.Show("File " + fname + " correttamente generato e validato.", "Avviso");
                    }
                }
            }


            catch (Exception e3) {
                QueryCreator.ShowException("Errore validando il file " + fname, e3);
                return false;
            }
            //Visualizza il file
            try {
                XslCompiledTransform xsltransform = new XslCompiledTransform();
                xsltransform.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory , "ORDINATIVI_3.02_SIOPE.xslt"));
                
                // Secondo metodo, utilizzo di uno stream
                Stream transformedData = new MemoryStream();
                xsltransform.Transform(fname, null, transformedData);
                transformedData.Seek(0, SeekOrigin.Begin);
                webBrowser1.DocumentStream = transformedData;
            }
            catch (Exception e2) {
                QueryCreator.ShowException("Errore cercando di visualizzare il file " + fname, e2);
                return false;
            }

            //Ha trovato degli ordinativi con dimensione superiore a 190 kb
            if (stop) return false;
            if (Use_webservice(Conn)) {
                InviaFile_a_SiopePlus(fname);
            }

            return true;
        }
        private void AggiornaStreamDate(string tablename, int y, int n) {
            string updateTo = " UPDATE " + tablename +
                              " SET  " + tablename + ".STREAMDATE = GETDATE(), " +
                              " LT = GETDATE(), LU = 'automatico'" +
                              " WHERE Y" + tablename + " = " + y.ToString() + " AND " +
                              " N" + tablename + " = " + n.ToString() +
                              " AND STREAMDATE IS NULL ";
            string errMsg;
            Conn.SQLRunner(updateTo, -1, out errMsg);
        }

        /// <summary>
        /// Restituisce un path completo in cui salvare il file, nome file incluso, eventualmente chiedendolo al cliente
        /// </summary>
        /// <param name="idtreasurer"></param>
        /// <param name="kind"></param>
        /// <param name="ntransmission"></param>
        /// <returns></returns>
        string getFileNameFlusso(object idtreasurer,string kind, int ntransmission) {
            string filterTreasurer = QHS.CmpEq("idtreasurer", idtreasurer);
            string fname = "";
            object savepath = Conn.DO_READ_VALUE("treasurer", filterTreasurer, "savepath");
            string manrev = "";
            if (kind == "p") {
                manrev = "_mandati_";
            }
            else {
                manrev = "_reversali_";
            }
            if (savepath != DBNull.Value) { 
                fname = Path.Combine(savepath.ToString(), Meta.GetSys("esercizio") + manrev + ntransmission.ToString());
				fname = fname + ".xml";
			}
			else {
                saveFileDialog1.FileName = Meta.GetSys("esercizio") + manrev + ntransmission.ToString();
				saveFileDialog1.Filter = "XML|*.xml";
				DialogResult dialogResult = saveFileDialog1.ShowDialog(this);
                if (dialogResult == DialogResult.Cancel) return null;
                fname = saveFileDialog1.FileName;
            }

            return fname;
        }

        bool stop = false;
        public XmlDocument  generaFileXML(int ytransmission, int ntransmission, string kind, out string fileName) {
            fileName = null;
            DataTable TT = null;
            if (kind == "p") {
                TT = Conn.RUN_SELECT("paymenttransmission", "*", null,
                   QHS.AppAnd(QHS.CmpEq("ypaymenttransmission", ytransmission),
                    QHS.CmpEq("npaymenttransmission", ntransmission)), null, false);
            }
            else {
                TT = Conn.RUN_SELECT("proceedstransmission", "*", null,
                   QHS.AppAnd(QHS.CmpEq("yproceedstransmission", ytransmission),
                    QHS.CmpEq("nproceedstransmission", ntransmission)), null, false);
            }
            if (TT == null || TT.Rows.Count == 0) {
                MessageBox.Show("Non ho trovato la distinta n." + ntransmission + " del " + ytransmission,
                                "Errore");
                return null;
            }
            DataRow R = TT.Rows[0];
            object spexport = null;
           

            if (kind == "p") {
                spexport = "trasmele_expense_opisiopeplus";
            }
            else {
                spexport = "trasmele_income_opisiopeplus";
            }
            DataSet D = Conn.CallSP(spexport.ToString(), new object[] { ytransmission, ntransmission }, false, 300);
            if (D == null || D.Tables.Count == 0) return null;
            DataTable T = D.Tables[0];
            if (T.Rows.Count == 0) {
                MessageBox.Show("L'esportazione è stata eseguita ma non ha restituito alcun risultato", "Errore");
                return null;
            }


            if (T.Columns.Count == 1) {
                FrmViewError View = new FrmViewError(D);
                View.Show();
                return null;
            }

            string DocPag = "";
            stop = false;
            siopeplus_export SS = new siopeplus_export(Conn);
            if (kind == "p") {
                DocPag =  SS.Crea_flusso_ordinativi_pag(T, out stop); 
            }
            else {
                DocPag = SS.Crea_flusso_ordinativi_inc(T, out stop);
            }

            if (DocPag == null) return null;
        
            XmlDocument document = new XmlDocument();
            document.LoadXml(DocPag);
            fileName = getFileNameFlusso(R["idtreasurer"], kind, ntransmission);
            return document;

       
        }
        //Controlla che sarà usato il WS
		public bool Use_webservice(DataAccess Conn) {
			object usewebservice = Conn.DO_READ_VALUE("opisiopeplus_config", QHS.CmpEq("code", "opi_siopeplus"), "usewebservice", null);
			if (usewebservice == null || usewebservice == DBNull.Value) return false;
			if (usewebservice.ToString()=="S") return true; 
			return false;
		}


		public void InviaFile_a_SiopePlus(string fname) {
            var listaErrori = PagoPaService.InviaOPI(Conn, fname);

            if (listaErrori != null && listaErrori.Count > 0) {
                FrmErrori.MostraErrori(this, listaErrori);
                Meta.FreshForm(true);
                btnGeneraFilePagamenti.Enabled = true;
                btnGeneraFileIncassi.Enabled = true;
                return;
            }
            MessageBox.Show("Invio eseguito con successo.");

        }
      
       
        private void btnGeneraFileIncassi_Click(object sender, EventArgs e) {
            int n = CfgFn.GetNoNullInt32(txtNproceedsTransm.Text);
            if (n == 0) {
                MessageBox.Show(this, "E' necessario selezionare un numero per la distinta");
                return;
            }
            int y = CfgFn.GetNoNullInt32(Conn.GetSys("esercizio"));

            string filterTransmission = QHS.AppAnd(QHS.CmpEq("yproceedstransmission", y),
                QHS.CmpEq("nproceedstransmission", n));
            object idtreasurer = Conn.DO_READ_VALUE("proceedstransmission", filterTransmission, "idtreasurer");
            object flagtransmissionenabled = Conn.DO_READ_VALUE("proceedstransmission", filterTransmission,
                "flagtransmissionenabled");
            object cfgflagenabletransmission = Conn.DO_READ_VALUE("config", QHS.CmpEq("ayear", y),
                "flagenabletransmission");

            if (cfgflagenabletransmission != DBNull.Value) {
                string cfg_flag = cfgflagenabletransmission.ToString().ToUpper();
                if ((cfg_flag == "S") && (flagtransmissionenabled.ToString().ToUpper() != "S")) {
                    MessageBox.Show(this, "La trasmissione della distinta non è stata autorizzata");
                    return;
                }
            }

            string fileName;
            var xml= generaFileXML(y, n,"i", out fileName);
            if (xml==null || fileName==null)return;
            if (salvaFile(xml, fileName, n, idtreasurer, "i")) {
                AggiornaStreamDate("PROCEEDSTRANSMISSION", y, n);
            }
            
        }

        private void btnPaymentTransm_Click(object sender, EventArgs e) {

        }
    }
}

