
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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using funzioni_configurazione;
using metadatalibrary;
using metaeasylibrary;
using System.Xml;
using System.Xml.Xsl;
using System.IO;
using bankdispositionsetup_importnew;
using System.Diagnostics;

namespace bankdispositionsetup_bccirpina {



    public partial class frmbankdispositionsetup_bccirpina : MetaDataForm {

        public IOpenFileDialog openFileDialog;

        public frmbankdispositionsetup_bccirpina() {
            InitializeComponent();
            openFileDialog = createOpenFileDialog(_openFileDialog1);
        }

        DataAccess Conn;
        MetaData Meta;
        QueryHelper QHS;
        CQueryHelper QHC;
        //ImportazioneEsitiBancari import = null;

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


        public void MetaData_Afterfill() {
            Text = "Trasmissione distinte Banca di Credito Cooperativo Irpina";
            EnableDisableGBox();

        }

        public void MetaData_AfterClear() {
            Text = "Trasmissione distinte Banca di Credito Cooperativo Irpina";
            EnableDisableGBox();
        }

        void EnableDisableGBox() {
            gboxIncassi.Enabled = (txtNPaymentTransmission.Text.Trim() == "");
            gboxPagamenti.Enabled = (txtNproceedsTransm.Text.Trim() == "");

            btnGeneraFileIncassi.Visible = txtNproceedsTransm.Text.Trim() != "";
            btnGeneraFilePagamenti.Visible = txtNPaymentTransmission.Text.Trim() != "";
        }

        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (T.TableName == DS.proceedstransmission.TableName) EnableDisableGBox();
            if (T.TableName == DS.paymenttransmission.TableName) EnableDisableGBox();
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
            EsportazioneDistintePagamento E = new EsportazioneDistintePagamento(Conn, y, n);
            XmlDocument D = E.GeneraFileXML();
            if (D == null) return;

            string filterTreasurer = QHS.CmpEq("idtreasurer", idtreasurer);
            string fname = "";
            object savepath = Conn.DO_READ_VALUE("treasurer", filterTreasurer, "savepath");
            if (savepath != DBNull.Value)
                fname = Path.Combine(savepath.ToString(), Meta.GetSys("esercizio") + "_mandati_" + n.ToString());
            else {
                saveFileDialog1.FileName = Meta.GetSys("esercizio") + "_mandati_" + n.ToString();
                DialogResult dialogResult = saveFileDialog1.ShowDialog(this);
                if (dialogResult == DialogResult.Cancel) return;
                fname = saveFileDialog1.FileName;
            }
            try {
                XmlWriterSettings xs = new XmlWriterSettings();
                xs.Indent = true;
                xs.CloseOutput = true;
                xs.Encoding = Encoding.GetEncoding("ISO-8859-15");
                XmlWriter xW = XmlWriter.Create(fname, xs);
                D.WriteTo(xW);
                xW.Flush();
                xW.Close();
                show("Salvataggio del file " + fname + " effettuato");
                TreasurerPutFile ftp = new TreasurerPutFile(Conn, idtreasurer);
                ftp.putFile(fname, Meta.GetSys("esercizio") + "_mandati_" + n.ToString());

            }
            catch (Exception e1) {
                QueryCreator.ShowException("Errore nel salvataggio del file " + fname, e1);
                return;
            }

            try {
                XslCompiledTransform xsltransform = new XslCompiledTransform();
                xsltransform.Load(AppDomain.CurrentDomain.BaseDirectory + "Ordinativi_2.0.xslt");


                Stream transformedData = new MemoryStream();
                String xmlString = D.InnerXml;

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xmlString);

                xsltransform.Transform(doc, null, transformedData);
                transformedData.Seek(0, SeekOrigin.Begin);
                webBrowser1.DocumentStream = transformedData;
            }
            catch (Exception e2) {
                QueryCreator.ShowException("Errore cercando di visualizzare il file " + fname, e2);
                return;
            }


            try {
                bool res = XML_XSD_Validator.Validate(fname,
                    AppDomain.CurrentDomain.BaseDirectory + "ORDINATIVI_BCC_SCUOLE_MIUR.XSD");
                if (!res) {
                    QueryCreator.ShowError(this, "Errore nella validazione dell'xml",
                        XML_XSD_Validator.GetError());
                    return;
                }
            }
            catch (Exception e3) {
                QueryCreator.ShowException("Errore validando il file " + fname, e3);
                return;
            }

            AggiornaStreamDate("PAYMENTTRANSMISSION", y, n);

            
          

        }

        private void btnGeneraFileIncassi_Click(object sender, EventArgs e) {
            int n = CfgFn.GetNoNullInt32(txtNproceedsTransm.Text);
            if (n == 0) {
                show(this, "E' necessario selezionare un numero per la distinta");
                return;
            }
            int y = CfgFn.GetNoNullInt32(Conn.GetSys("esercizio"));

            string filterProceedsTransmission = QHS.AppAnd(QHS.CmpEq("yproceedstransmission", y),
                QHS.CmpEq("nproceedstransmission", n));
            object idtreasurer = Conn.DO_READ_VALUE("proceedstransmission", filterProceedsTransmission, "idtreasurer");
            object flagtransmissionenabled = Conn.DO_READ_VALUE("proceedstransmission", filterProceedsTransmission,
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

            EsportazioneDistinteIncasso E = new EsportazioneDistinteIncasso(Conn, y, n);
            XmlDocument D = E.GeneraFileXML();


            string filterTreasurer = QHS.CmpEq("idtreasurer", idtreasurer);
            string fname = "";
            object savepath = Conn.DO_READ_VALUE("treasurer", filterTreasurer, "savepath");
            if (savepath != DBNull.Value)
                fname = Path.Combine(savepath.ToString(), Meta.GetSys("esercizio") + "_reversali_" + n.ToString());
            else {
                saveFileDialog1.FileName = Meta.GetSys("esercizio") + "_reversali_" + n.ToString();
                DialogResult dialogResult = saveFileDialog1.ShowDialog(this);
                if (dialogResult == DialogResult.Cancel) return;
                fname = saveFileDialog1.FileName;
            }

            try {
                XmlWriterSettings xs = new XmlWriterSettings();
                xs.Indent = true;
                //xs.NewLineOnAttributes = true;
                xs.Encoding = Encoding.GetEncoding("ISO-8859-15");
                xs.CloseOutput = true;
                XmlWriter xW = XmlWriter.Create(fname, xs);
                D.WriteTo(xW);
                xW.Flush();
                xW.Close();
                show("Salvataggio del file " + fname + " effettuato");
                TreasurerPutFile ftp = new TreasurerPutFile(Conn, idtreasurer);
                ftp.putFile(fname, Meta.GetSys("esercizio") + "_reversali_" + n.ToString());

            }
            catch (System.IO.IOException e1) {
                show(e1.Message, "Errore nel salvataggio del file " + fname);
            }
            try {
                XslCompiledTransform xsltransform = new XslCompiledTransform();
                xsltransform.Load(AppDomain.CurrentDomain.BaseDirectory + "Ordinativi_2.0.xslt");


                Stream transformedData = new MemoryStream();
                String xmlString = D.InnerXml;

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xmlString);

                xsltransform.Transform(doc, null, transformedData);
                transformedData.Seek(0, SeekOrigin.Begin);
                webBrowser1.DocumentStream = transformedData;
            }
            catch (Exception e2) {
                QueryCreator.ShowException("Errore cercando di visualizzare il file " + fname, e2);
                return;
            }

            try {
                bool res = XML_XSD_Validator.Validate(fname,
                    AppDomain.CurrentDomain.BaseDirectory + "ORDINATIVI_BCC_SCUOLE_MIUR.XSD");
                if (!res) {
                    QueryCreator.ShowError(this, "Errore nella validazione dell'xml",
                        XML_XSD_Validator.GetError());
                    return;
                }
            }
            catch (Exception e3) {
                QueryCreator.ShowException("Errore validando il file " + fname, e3);
                return;
            }

            AggiornaStreamDate("PROCEEDSTRANSMISSION", y, n);

           

            //try {
            //     Process.Start(fname);
            //}
            //catch (Exception E1)
            //{
            //    QueryCreator.ShowException(E1);
            //}


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
