
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
using System.Text;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using System.Xml;
using System.Collections;
using System.Xml.Schema;
using System.Xml.Xsl;
using System.IO;
using System.Net.Mail;
using System.Threading;
using funzioni_configurazione;

namespace sdi_acquistoestere_default {
	public partial class Frm_sdi_acquistoestere_default : MetaDataForm {
		CQueryHelper QHC;
		QueryHelper QHS;
		DataAccess Conn;
		MetaData Meta;
        public IOpenFileDialog openFileDialog1;
        public Frm_sdi_acquistoestere_default() {
			InitializeComponent();
            openFileDialog1 = createOpenFileDialog(_openFileDialog1);
        }
        bool IsAdmin = false;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHS = Meta.Conn.GetQueryHelper();
            QHC = new CQueryHelper();
            Conn = Meta.Conn;
            Meta.CanInsert = false;
            cboTipo.DataSource = this.DS.invoicekind;
            btnToProtocol.Enabled = false;
            if (Meta.GetSys("IsSystemAdmin") != null)
                IsAdmin = IsAdmin || (bool)Meta.GetSys("IsSystemAdmin");

            if (!IsAdmin) {
                Meta.CanCancel = false;
            }

        }
        public void MetaData_AfterFill() {
            gboxStato.Enabled = false;
            grpStatoTrasmissione.Enabled = false;
            grpMessaggi.Enabled = false;
            grpIPAMittenteVendita.Enabled = false;
            txtNomeFile.ReadOnly = true;
            txtNomeFilecompresso.ReadOnly = true;
            txtIdentificativoSdI.ReadOnly = true;
            txtProtocollo.ReadOnly = true;
            txtNumDocumento.ReadOnly = true;
            txtEsercDocumento.ReadOnly = true;
            cboTipo.Enabled = false;
            DataRow Curr = DS.sdi_acquistoestere.Rows[0];

            if (Meta.EditMode) {

                object currProt = Curr["arrivalprotocolnum", DataRowVersion.Original];
                btnToProtocol.Enabled = (currProt == DBNull.Value); 

                btnUpload.Enabled = (chkExported.Checked == false);

            }

            chkExported.Enabled = false;
            txtSignedFileName.ReadOnly = true;
            chkIsSigned.Enabled = false;
            MostraBottoniXMLMessaggi();
            btnScollega.Visible = canDetachFattura();
        }
        bool canDetachFattura() {
            if (Meta.IsEmpty)
                return false;
            if (DS.invoice.Rows.Count == 0)
                return false;

            //se non è firmata si può scollegare
            if (chkIsSigned.CheckState != CheckState.Checked)
                return true;

            //Scartata da SDI: si può scollegare
            if (chkNS_notificascarto.Checked)
                return true;

            DataRow curr = DS.sdi_acquistoestere.Rows[0];
            //rifiutata 
            if (curr["idsdi_status"].ToString() == "3")
                return true;

            return false;
        }
        public void MostraBottoniXMLMessaggi() {
            if (Meta.IsEmpty) return;

            // ns (notifica scarto)
            // mc (mancata consegna)
            // rc (ricevuta di consegna)
            // ne (notifica esito cedente)
            // dt (decorrenza termini)
            // at (attestazione impossibilità recapito)
            if (DS.sdi_acquistoestere.Rows.Count == 0) {
                return;
            }
            DataRow Curr = DS.sdi_acquistoestere.Rows[0];
            if (Curr.RowState == DataRowState.Deleted) return;
            btnXMLRC.Visible = Curr["rc"] != DBNull.Value;
            btnXMLMC.Visible = Curr["mc"] != DBNull.Value;
            btnXMLNS.Visible = Curr["ns"] != DBNull.Value;
        }

        private void VisualizzaXMLMessaggi(string tipomessaggio) {
            // ns (notifica scarto)
            // mc (mancata consegna)
            // rc (ricevuta di consegna)
            // ne (notifica esito cedente)
            // dt (decorrenza termini)
            // at (attestazione impossibilità recapito)
            if (DS.sdi_acquistoestere.Rows.Count == 0) {
                return;
            }
            if (!Meta.GetFormData(false))
                return;
            // Visualizza file xml
            //string tempFileName = Path.GetFileNameWithoutExtension(Path.GetTempFileName()) + ".htm";
            string tempFileName = Path.ChangeExtension(Path.GetTempFileName(), "htm");
            XmlWriter xw = XmlWriter.Create(tempFileName);
            XmlDocument doc = new XmlDocument();

            if (DS.sdi_acquistoestere.Rows[0][tipomessaggio] == DBNull.Value)
                return;
            try {
                doc.LoadXml(DS.sdi_acquistoestere.Rows[0][tipomessaggio].ToString());
            }
            catch {
                return;
            }

            XslCompiledTransform xsltransform = new XslCompiledTransform();
            string filexls = "";
            if (tipomessaggio.ToUpper() == "AT")
                filexls = tipomessaggio.ToUpper() + "_v1.1.xslt";
            else
                filexls = tipomessaggio.ToUpper() + "_v1.0.xslt";
            // Leggo l'attributo "xmlns:ns3" che mi permette di selezionare il namespace   e lo confronto con quello del foglio di stile
            // Devono essere identici ai fini di una corretta visualizzazione
            string xmlns_ns3 = doc.DocumentElement.Attributes["xmlns:ns3"].Value;
            string xmlns_a_old = "http://www.fatturapa.gov.it/sdi/messaggi/v1.0";
            //Non solo: in tal caso i Messaggi NotificaScarto e NotificaMancataConsegna necessitano di un proprio foglio di stile
            if (xmlns_ns3 == "http://ivaservizi.agenziaentrate.gov.it/docs/xsd/fattura/messaggi/v1.0") {
                if ((tipomessaggio.ToUpper() == "NS") || (tipomessaggio.ToUpper() == "MC")) filexls = tipomessaggio.ToUpper() + "_new_v1.0.xslt";
                else {
                    // Per altri messaggi, se solo il namespace del foglio di stile differisce da quello del messaggi,
                    // basta cambiare l'attributo xmlns_ns3 e continuare a usare lo stesso foglio di stile
                    // tutte le altre proprietà restano invariate. Bisogna rieffettuare il LoadXML perchè un semplice SetAttribute sul doc non ha effetto
                    try {
                        doc.LoadXml(DS.sdi_acquistoestere.Rows[0][tipomessaggio].ToString().Replace(xmlns_ns3, xmlns_a_old));
                    }
                    catch {
                        return;
                    }
                }
            }
            xsltransform.Load(AppDomain.CurrentDomain.BaseDirectory + filexls);
            xsltransform.Transform(doc, null, xw);
            xw.Flush();
            xw.Close();
            runProcess(tempFileName, true);
        }

        public string getXmlText(XmlDocument x, string xpath, XmlNamespaceManager ns) {
            if (ns == null) {
                try {
                    XmlNode n = x.SelectSingleNode(xpath);
                    if (n != null) {
                        return n.InnerText;
                    }
                }
                catch {
                }
                return null;
            }

            try {
                XmlNode n = x.SelectSingleNode(xpath, ns);
                if (n != null) {
                    return n.InnerText;
                }
            }
            catch {
            }
            return null;
        }

        public string CreaFileAllegato(XmlDocument fatturaxml, string nomeAllegato) {
            string tempFileName = Path.GetFileNameWithoutExtension(nomeAllegato) + ".htm";
            string pathfileAllegato = "";
            XmlWriter xw = XmlWriter.Create(tempFileName);
            string xsl = "";
            //if (ScriviMessCopiaCortesia()) {
            //    xsl = "fatturapa_v1.2Semplificata_mess.xslt";
            //}
            //else {
                xsl = "fatturapa_v1.2Semplificata.xslt";
            //}

            try {
                XslCompiledTransform xsltransform = new XslCompiledTransform();
                xsltransform.Load(AppDomain.CurrentDomain.BaseDirectory + xsl);

                xsltransform.Transform(fatturaxml, null, xw);
                xw.Flush();
                xw.Close();

                pathfileAllegato = AppDomain.CurrentDomain.BaseDirectory + tempFileName;
            }
            catch (Exception E) {
            }

            return pathfileAllegato;
        }
        public static string rimuoviTutteEstensioni(string nomeFile) {
            return Path.GetFileName(nomeFile).Split('.')[0];
        }

        public static string getTutteEstensioni(string nomeFile) {
            string s = Path.GetFileName(nomeFile);
            int id = s.IndexOf('.');
            return s.Substring(id + 1);
        }
        string getNomeCompleto(string identificativoFattura, string DataFattura) {
            string invalid = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            string nomeFile = identificativoFattura + "-" + DataFattura;
            foreach (char c in invalid) {
                nomeFile = nomeFile.Replace(c.ToString(), "");
            }

            return nomeFile;
        }

        public string GetCcMail(DataAccess Conn) {
            object mail = null;
            QueryHelper Q = Conn.GetQueryHelper();
            mail = Conn.DO_SYS_CMD("SELECT email from trasmissionmanager where "
                   + Q.CmpEq("idtrasmissiondocument", "FEVEN"));
            if (mail == null) {
                return null;
            }
            else {
                return mail.ToString();
            }
        }


        public void MetaData_BeforePost() {
            if (DS.sdi_acquistoestere.Rows.Count == 0) {
                return;
            }
            DataRow curr = DS.sdi_acquistoestere.Rows[0];
            if (curr.RowState == DataRowState.Deleted) return;
            object protocol = curr["arrivalprotocolnum"];
            object idsdi_oldstatus = curr["idsdi_status", DataRowVersion.Original];
            if ((protocol != DBNull.Value) && (CfgFn.GetNoNullInt32(idsdi_oldstatus) == 5))
                curr["idsdi_status"] = 1; // lo pongo in attesa 
        }

        public void MetaData_AfterClear() {
            gboxStato.Enabled = true;
            btnScollega.Visible = false;
            grpIPAMittenteVendita.Enabled = true;
            grpStatoTrasmissione.Enabled = true;




            grpMessaggi.Enabled = true;
            txtNomeFile.ReadOnly = false;
            txtNomeFilecompresso.ReadOnly = false;
            txtSignedFileName.ReadOnly = false;
            txtIdentificativoSdI.ReadOnly = false;
            txtProtocollo.ReadOnly = false;
            btnToProtocol.Enabled = false;
            txtNumDocumento.ReadOnly = false;
            txtEsercDocumento.ReadOnly = false;
            cboTipo.Enabled = true;
            chkExported.Enabled = true;
            btnUpload.Enabled = false;
            btnXMLRC.Visible = true;
            btnXMLMC.Visible = true;
            btnXMLNS.Visible = true;
        }

		private void btnToProtocol_Click(object sender, EventArgs e) {
            if (!Meta.GetFormData(false)) return;
            DataRow curr = DS.sdi_acquistoestere.Rows[0];
            object arrivalProtocol = DBNull.Value;
            object oldprotocol = curr["arrivalprotocolnum", DataRowVersion.Original];
			if (oldprotocol != DBNull.Value) return;
			FrmAskProtocollo FP = new FrmAskProtocollo(0);
			if (FP.ShowDialog(this) == DialogResult.OK) {
				arrivalProtocol = FP.Protocollo;
			}
			if (arrivalProtocol != DBNull.Value) {
                curr["arrivalprotocolnum"] = arrivalProtocol;
            }
            Meta.FreshForm();
        }

		private void btnGeneraFile_Click(object sender, EventArgs e) {
            if (DS.sdi_acquistoestere.Rows.Count == 0) {
                return;
            }
            XmlDocument doc = new XmlDocument();
            if (DS.sdi_acquistoestere.Rows[0]["xml"] == DBNull.Value)
                return;
            doc.LoadXml(DS.sdi_acquistoestere.Rows[0]["xml"].ToString());
            if (doc == null) return;

            string fname = DS.sdi_acquistoestere.Rows[0]["filename"].ToString();


            string fNameNoExtension = fname.Split('.')[0];
            string extension = ".xml"; 


            saveFileDialog1.FileName = fNameNoExtension + extension;

            DialogResult dialogResult = saveFileDialog1.ShowDialog(this);

            if (dialogResult == DialogResult.Cancel) return;
            fname = saveFileDialog1.FileName;

            try {
                XmlWriterSettings xs = new XmlWriterSettings();
                xs.Indent = true;
                xs.CloseOutput = true;
                xs.Encoding = Encoding.UTF8;
                XmlWriter xW = XmlWriter.Create(fname, xs);
                doc.WriteTo(xW);
                xW.Flush();
                xW.Close();
                show("Salvataggio del file " + fname + " effettuato");
            }
            catch (Exception e1) {
                QueryCreator.ShowError(this, "Errore nel salvataggio del file " + fname, e1.ToString());
            }
        }

		private void btnUpload_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            string fName = txtNomeFile.Text;
            DialogResult res = openFileDialog1.ShowDialog(this);
            if (res != DialogResult.OK) return;
            string signed = openFileDialog1.FileName;
            string simpleName = Path.GetFileName(signed);
            if (simpleName != fName && simpleName != fName + ".p7m") {
                show("Il nome file caricato non è valido. Il nome del file deve essere ESATTAMENTE: " + fName
                                + " se firmato con XADES o " + fName + ".p7m se firmato con CADES", "Errore");
                return;
            }
            byte[] buff = File.ReadAllBytes(signed);
            string x = Convert.ToBase64String(buff);


            txtSignedFileName.Text = simpleName;
            DataRow Curr = DS.sdi_acquistoestere.Rows[0];
            Curr["signedxmlfilename"] = simpleName;
            Curr["signedxml"] = x;
            Curr["issigned"] = "S";
            chkIsSigned.Checked = true;
        }

		private void btnScollega_Click(object sender, EventArgs e) {
            if (DS.invoice.Rows.Count == 0)
                return;
            Meta.GetFormData(true);
            PostData.RemoveFalseUpdates(DS);
            if (DS.HasChanges()) {
                show(this, "Per scollegate la fattura occorre prima SALVARE");
                return;
            }
            DataRow inv = DS.invoice.Rows[0];
            inv["idsdi_acquistoestere"] = DBNull.Value;
            //inv["protocoldate"] = DBNull.Value;
            Meta.SaveFormData();
        }

		private void btnVisualizza_Click(object sender, EventArgs e) {
            if (DS.sdi_acquistoestere.Rows.Count == 0) {
                return;
            }
            if (!Meta.GetFormData(false))
                return;
            // Visualizza file xml
            //Stream transformedData = new MemoryStream();

            bool isPA = false;
            if (DS.invoice.Rows.Count > 0) {
                DataRow rFattura = DS.invoice.Rows[0];
                isPA = rFattura["ipa_ven_cliente"].ToString().Length == 6;
            }
            //string tempFileName = Path.GetFileNameWithoutExtension(Path.GetTempFileName()) + ".htm";
            string tempFileName = Path.ChangeExtension(Path.GetTempFileName(), "htm");

            Button btnVisualizza = (Button)sender;

            XmlWriter xw = XmlWriter.Create(tempFileName);
            XmlDocument doc = new XmlDocument();
            if (DS.sdi_acquistoestere.Rows[0]["xml"] == DBNull.Value)
                return;
            DateTime dataCont = (DateTime)Meta.GetSys("datacontabile");
            DateTime dataOttobre2020 = new DateTime(2020, 10, 1);
            doc.LoadXml(DS.sdi_acquistoestere.Rows[0]["xml"].ToString());
            string xsl = "";
            try {
                if (dataCont != null && dataCont > dataOttobre2020) {
                    //PRENDO I NUOVI FILE XSLT CHE VANNO IN VIGORE DAL 1/10/2020
                    string xslNew = isPA ? "fatturapa_v1.2.1.xslt" : "fatturaordinaria_v1.2.1.xslt";
                    string versione = doc.DocumentElement.Attributes["versione"].Value;
                    xsl = versione == "1.1" ? "fatturapa_v1.1.xslt" : xslNew;
                    if (btnVisualizza.Name == "btnVisualizzaSempl") {
                        //if (ScriviMessCopiaCortesia()) {
                        //    //DA SOSTITUIRE CON NUOVO FILE 1.2.1
                        //    xsl = "fatturapa_v1.2Semplificata_mess.xslt";
                        //}
                        //else {
                            xsl = "fatturapa_v1.2.1Semplificata.xslt";
                        //}
                    }
                    XslCompiledTransform xsltransform = new XslCompiledTransform();
                    xsltransform.Load(AppDomain.CurrentDomain.BaseDirectory + xsl);

                    xsltransform.Transform(doc, null, xw);
                    //transformedData.Seek(0, SeekOrigin.Begin);
                    //webBrowser1.DocumentStream = transformedData;
                    xw.Flush();
                    xw.Close();
                }
                else {
                    string xslNew = isPA ? "fatturapa_v1.2.xslt" : "fatturaordinaria_v1.2.xslt";
                    string versione = doc.DocumentElement.Attributes["versione"].Value;
                    xsl = versione == "1.1" ? "fatturapa_v1.1.xslt" : xslNew;
                    if (btnVisualizza.Name == "btnVisualizzaSempl") {
                        //if (ScriviMessCopiaCortesia()) {
                        //    xsl = "fatturapa_v1.2Semplificata_mess.xslt";
                        //}
                        //else {
                            xsl = "fatturapa_v1.2Semplificata.xslt";
                        //}
                    }
                    XslCompiledTransform xsltransform = new XslCompiledTransform();
                    xsltransform.Load(AppDomain.CurrentDomain.BaseDirectory + xsl);

                    xsltransform.Transform(doc, null, xw);
                    //transformedData.Seek(0, SeekOrigin.Begin);
                    //webBrowser1.DocumentStream = transformedData;
                    xw.Flush();
                    xw.Close();
                }
            }
            catch (Exception E) {
                QueryCreator.ShowException(this, "Errore aprendo la fattura selezionata", E);
                DataRow Curr = DS.sdi_acquistoestere.Rows[0];
                string errmsg = $"sdi_acquistoestere_default: Errore su {xsl}, Fattura : " + Curr["sdi_acquistoestere"];
                Meta.LogError(errmsg, E);
            }


            runProcess(tempFileName, true);
        }

		private void btnXMLNS_Click(object sender, EventArgs e) {
            VisualizzaXMLMessaggi("ns");
        }

		private void btnXMLMC_Click(object sender, EventArgs e) {
            VisualizzaXMLMessaggi("mc");
        }

		private void btnXMLRC_Click(object sender, EventArgs e) {
            VisualizzaXMLMessaggi("rc");
        }
	}

}
