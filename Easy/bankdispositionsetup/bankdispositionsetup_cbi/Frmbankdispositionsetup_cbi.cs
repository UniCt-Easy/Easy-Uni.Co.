
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


using System;
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
using metaeasylibrary;
using System.Xml;
using System.Xml.Xsl;
using System.IO;
using System.Xml;
using System.Xml.Xsl;

namespace bankdispositionsetup_cbi {
	public partial class Frmbankdispositionsetup_cbi : MetaDataForm {
        
        public Frmbankdispositionsetup_cbi() {
			InitializeComponent();
            saveFileDialog1.DefaultExt = "xml";
        }
        DataAccess Conn;
        MetaData Meta;
        QueryHelper QHS;
        CQueryHelper QHC;

        public  bool isBonificoEstero(int ytransmission, int ntransmission) {
            var query = "select * "
                + " from paymentcommunicated "
                + " JOIN paymethod  ON paymentcommunicated.idpaymethod = paymethod.idpaymethod "
                + " WHERE paymentcommunicated.ypaymenttransmission = "+ ytransmission + " AND paymentcommunicated.npaymenttransmission = "+ ntransmission
                + " AND paymethod.methodbankcode IN ('BONIFICOESTERO') ";

            var Estero = Conn.SQLRunner(query);
            if ((Estero == null) || (Estero.Rows.Count == 0))
                return false;
            else
                return true;

        }
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

            string s;

            s = btnPaymentTransm.Tag.ToString();
            s = s.Replace("%<esercizio>%", Conn.GetSys("esercizio").ToString());
            btnPaymentTransm.Tag = s;

            s = gboxPagamenti.Tag.ToString();
            s = s.Replace("%<esercizio>%", Conn.GetSys("esercizio").ToString());
            gboxPagamenti.Tag = s;
        }

        bool stop = false;
        public XmlDocument generaFileXML(int ytransmission, int ntransmission, out string fileName) {
            fileName = null;
            DataTable TT = null;
               TT = Conn.RUN_SELECT("paymenttransmission", "*", null,
                   QHS.AppAnd(QHS.CmpEq("ypaymenttransmission", ytransmission),
                    QHS.CmpEq("npaymenttransmission", ntransmission)), null, false);
 
            if (TT == null || TT.Rows.Count == 0) {
                show("Non ho trovato la distinta n." + ntransmission + " del " + ytransmission,
                                "Errore");
                return null;
            }
            DataRow R = TT.Rows[0];
            bool BonificoEstero = isBonificoEstero(ytransmission,ntransmission);
            object spexport = "trasmele_expense_cbi";
            DataSet D = Conn.CallSP(spexport.ToString(), new object[] { ytransmission, ntransmission }, false, 300);
            if (D == null || D.Tables.Count == 0) return null;
            DataTable T = D.Tables[0];
            if (T.Rows.Count == 0) {
                show("L'esportazione è stata eseguita ma non ha restituito alcun risultato", "Errore");
                return null;
            }

            if (T.Columns.Count == 1) {
                show("L'esportazione è stata eseguita ma  ha restituito errori bloccanti", "Errore");
                FrmViewError View = new FrmViewError(D);
                MetaFactory.factory.getSingleton<IFormCreationListener>().create(View, null);
                View.Show();
                return null;
            }

            // Chiama la sp di check, che mostra l'eventuale errore di quadratura, ma non evita la generazione del file.
            object sp_check = "check_trasmele_expense_cbi";

            // CODICE DA ATTIVA qualora venga creata la sp di check

            //DataSet DScheck = Conn.CallSP(sp_check.ToString(), new object[] { ytransmission, ntransmission }, false, 300);
            //if ((DScheck != null) && (DScheck.Tables.Count > 0)) {
            //    DataTable Tcheck = DScheck.Tables[0];
            //    if (Tcheck.Rows.Count > 0) {
            //        show("Vi sono problemi sulla quadratura di alcuni importi. \r\nIl file verrà generato ma se trasmesso, verrà RIFIUTATO DALLA BANCA", "Errore");
            //        FrmViewError View = new FrmViewError(DScheck);
            //        MetaFactory.factory.getSingleton<IFormCreationListener>().create(View, null);
            //        View.Show();
            //    }
            //}

            if (T.Columns.Count == 1) {
                FrmViewError View = new FrmViewError(D);
                MetaFactory.factory.getSingleton<IFormCreationListener>().create(View, null);
                View.Show();
                return null;
            }

            stop = false;
            
            EsportazioneDistintePagamento SS = new EsportazioneDistintePagamento(Conn, BonificoEstero);

            XmlDocument document = SS.Crea_flusso_ordinativi_pag(T);
            fileName = getFileNameFlusso(R["idtreasurer"],  ntransmission);
            return document;
        }

        /// <summary>
        /// Restituisce un path completo in cui salvare il file, nome file incluso, eventualmente chiedendolo al cliente
        /// </summary>
        /// <param name="idtreasurer"></param>
        /// <param name="kind"></param>
        /// <param name="ntransmission"></param>
        /// <returns></returns>
        string getFileNameFlusso(object idtreasurer, int ntransmission) {
            string filterTreasurer = QHS.CmpEq("idtreasurer", idtreasurer);
            string fname = "";
            object savepath = Conn.DO_READ_VALUE("treasurer", filterTreasurer, "savepath");
            string manrev = "_mandati_";

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

        bool salvaFile(XmlDocument document, string fname, int ntrasmission, object idtreasurer, string kind) {
            document.writeXmlToFile(fname, Encoding.GetEncoding("ISO-8859-1"));

            // Al file XML vengono aggiunti i Prefissi (BODY, PMRQ), il file XSD non li ha, quindi
            // la validazione xml/xsd restituisce errore
            bool validaFile = false;
            
            if (validaFile)
            {
                // Cerca di Validare il file
                try
                {
                    bool res = XML_XSD_Validator.Validate(fname,
                        Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CBIPaymentRequest.00.04.01.XSD"));
                    if (!res)
                    {
                        QueryCreator.ShowError(this, "Errore nella validazione dell'xml", XML_XSD_Validator.GetError());
                        return false;
                    }
                    //else {
                    //    string middle = (kind == "p") ? "_mandati_" : "_reversali_";
                    //    TreasurerPutFile ftp = new TreasurerPutFile(Conn, idtreasurer);
                    //    string errori = ftp.putFile(fname, Conn.GetEsercizio() + middle + ntrasmission.ToString());
                    //    if (errori != null) {
                    //        show(errori, "Errore nel trasferimento FTP");
                    //    }
                    //    else {
                    //        show("File " + fname + " correttamente generato e validato.", "Avviso");
                    //    }
                    //}
                }
                catch (Exception e3)
                {
                    QueryCreator.ShowException("Errore validando il file " + fname, e3);
                    return false;
                }
            }

            ////Visualizza il file
            //try {
            //    XslCompiledTransform xsltransform = new XslCompiledTransform();
            //    xsltransform.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ORDINATIVI_3.02_SIOPE.xslt"));

            //    // Secondo metodo, utilizzo di uno stream
            //    Stream transformedData = new MemoryStream();
            //    xsltransform.Transform(fname, null, transformedData);
            //    transformedData.Seek(0, SeekOrigin.Begin);
            //    webBrowser1.DocumentStream = transformedData;
            //}
            //catch (Exception e2) {
            //    QueryCreator.ShowException("Errore cercando di visualizzare il file " + fname, e2);
            //    return false;
            //}

            //Ha trovato degli ordinativi con dimensione superiore a 190 kb
            if (stop) return false;

            return true;
        }
        private void btnGeneraFilePagamenti_Click(object sender, EventArgs e) {
            int n = CfgFn.GetNoNullInt32(txtNPaymentTransmission.Text);
            if (n == 0) {
                show(this, "E' necessario selezionare un numero per la distinta");
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
                    show(this, "La trasmissione della distinta non è stata autorizzata");
                    return;
                }
            }
            string fileName;
            var xml = generaFileXML(y, n, out fileName);
            if (xml == null || fileName == null) return;
            if (salvaFile(xml, fileName, n, idtreasurer, "p")) {
                AggiornaStreamDate("PAYMENTTRANSMISSION", y, n);
            }
            //EsportazioneDistintePagamento E = new EsportazioneDistintePagamento(Conn, y, n);
            //string DocPag = "";
            //stop = false;
            //CBIPayment PP = new CBIPayment();
            //DocPag = PP.Crea_flusso_ordinativi_pag(T, out stop);

            /////XmlDocument D = E.GeneraFileXML();



            //////////if (D == null) return;
            //////////string filterTreasurer = QHS.CmpEq("idtreasurer", idtreasurer);
            //////////string fname = "";
            //////////object savepath = Conn.DO_READ_VALUE("treasurer", filterTreasurer, "savepath");
            //////////if (savepath != DBNull.Value)
            //////////    fname = Path.Combine(savepath.ToString(), Meta.GetSys("esercizio") + "_mandati_" + n.ToString());
            //////////else {
            //////////    saveFileDialog1.FileName = Meta.GetSys("esercizio") + "_mandati_" + n.ToString();
            //////////    DialogResult dialogResult = saveFileDialog1.ShowDialog(this);
            //////////    if (dialogResult == DialogResult.Cancel) return;
            //////////    fname = saveFileDialog1.FileName;
            //////////}
            //////////try {
            //////////    XmlWriterSettings xs = new XmlWriterSettings();
            //////////    xs.Indent = true;
            //////////    xs.CloseOutput = true;
            //////////    xs.Encoding = Encoding.GetEncoding("ISO-8859-15");
            //////////    XmlWriter xw = XmlWriter.Create(fname, xs);
            //////////    D.WriteTo(xw);
            //////////    xw.Flush();
            //////////    xw.Close();
            //////////    show("Salvataggio del file " + fname + " effettuato");

            //////////    TreasurerPutFile ftp = new TreasurerPutFile(Conn, idtreasurer);
            //////////    ftp.putFile(fname, Meta.GetSys("esercizio") + "_mandati_" + n.ToString());

            //////////}
            //////////catch (Exception e1) {
            //////////    QueryCreator.ShowException("Errore nel salvataggio del file " + fname, e1);
            //////////    return;
            //////////}

            //try {
            //    XslCompiledTransform xsltransform = new XslCompiledTransform();
            //    xsltransform.Load(AppDomain.CurrentDomain.BaseDirectory + "CBIPaymentRequest.00.04.01.xslt");

            //    // Secondo metodo, utilizzo di uno stream
            //    Stream transformedData = new MemoryStream();
            //    xsltransform.Transform(D, null, transformedData);
            //    transformedData.Seek(0, SeekOrigin.Begin);
            //    webBrowser1.DocumentStream = transformedData;
            //}
            //catch (Exception e2) {
            //    QueryCreator.ShowException("Errore cercando di visualizzare il file " + fname, e2);
            //    return;
            //}

            //////////try {


            //////////    bool res = XML_XSD_Validator.Validate(fname,
            //////////        AppDomain.CurrentDomain.BaseDirectory + "CBIPaymentRequest.00.04.01.XSD");
            //////////    if (!res) {
            //////////        QueryCreator.ShowError(this, "Errore nella validazione dell'xml",
            //////////            XML_XSD_Validator.GetError());
            //////////        return;
            //////////    }
            //////////}
            //////////catch (Exception e3) {
            //////////    QueryCreator.ShowException("Errore validando il file " + fname, e3);
            //////////    return;
            //////////}

            AggiornaStreamDate("PAYMENTTRANSMISSION", y, n);
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
    }
}
