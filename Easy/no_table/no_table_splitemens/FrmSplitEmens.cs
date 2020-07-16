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
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using metadatalibrary;
using funzioni_configurazione;
using System.Globalization;

namespace no_table_splitemens{
    public partial class FrmSplitEmens : Form    {
        private MetaData meta;
        QueryHelper QHS;
        CQueryHelper QHC;
        string idSedeINPS = "";

        public FrmSplitEmens() {
            InitializeComponent();

            dsEmens.Emens.Columns["AnnoMeseDenuncia"].Caption = "Mese denuncia";
            dsEmens.Emens.Columns["CFAzienda"].Caption = "C.F. Azienda";
            dsEmens.Emens.Columns["CFCollaboratore"].Caption = "C.F. Collaboratore";
            dsEmens.Emens.Columns["Cognome"].Caption = "Cognome";
            dsEmens.Emens.Columns["Nome"].Caption = "Nome";
            dsEmens.Emens.Columns["CodiceComune"].Caption = "Codice Comune";
            dsEmens.Emens.Columns["TipoRapporto"].Caption = "Tipo rapporto";
            dsEmens.Emens.Columns["CodiceAttivita"].Caption = "Codice attivit‡";
            dsEmens.Emens.Columns["Imponibile"].Caption = "Imponibile";
            dsEmens.Emens.Columns["Aliquota"].Caption = "Aliquota";
            dsEmens.Emens.Columns["AltraAss"].Caption = "Altra ass.";
            dsEmens.Emens.Columns["Dal"].Caption = "Dal";
            dsEmens.Emens.Columns["Al"].Caption = "Al";
            dsEmens.Emens.Columns["nomefile"].Caption = "Nome del file";
            dsEmens.Emens.Columns["CodCalamita"].Caption = "";
            dsEmens.Emens.Columns["CodCertificazione"].Caption = "";

        }

        public void MetaData_AfterLink(){
            meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = meta.Conn.GetQueryHelper();

            meta.CanCancel = false;
            meta.CanInsert = false;
            meta.CanInsertCopy = false;
            meta.CanSave = false;
            meta.SearchEnabled = false;
            meta.MainRefreshEnabled = false;
            //string errMess;

            DataAccess.RUN_SELECT_INTO_TABLE(meta.Conn, dsEmens.emenscontractkind, null, null, null, true);
            DataAccess.RUN_SELECT_INTO_TABLE(meta.Conn, dsEmens.inpsactivity, null, null, null, true);
            DataAccess.RUN_SELECT_INTO_TABLE(meta.Conn, dsEmens.otherinsurance, null, null, null, true);
        }

        private XmlTextWriter getXmlTextWriter(out string messaggio){
            messaggio = null;
            try{
                return new XmlTextWriter(txtFileXml.Text, Encoding.UTF8);
            }
            catch (ArgumentException e){
                messaggio = e.Message;
                return null;
            }
        }

        private XmlTextWriter setXmlTextWriter(string nomefile){
            string messaggio = null;
            try{
                return new XmlTextWriter(nomefile, Encoding.UTF8);
            }
            catch (ArgumentException e){
                messaggio = e.Message;
                return null;
            }
        }

        private DirectoryInfo getDirectoryInfo(out string messaggio){
            messaggio = null;
            try{
                return new DirectoryInfo(txtDirectory.Text);
            }
            catch (ArgumentException e){
                messaggio = e.Message;
                return null;
            }
        }

        private void writeElementString(XmlTextWriter writer, string campo, DataRow riga)
        {
            if (riga[campo] != DBNull.Value)
            {
                writer.WriteElementString(campo, riga[campo].ToString());
            }
        }

        private string valore(XmlElement nodo)
        {
            if (nodo == null) return null;
            return nodo.InnerText;
        }

        private void Leggi(string emensKind){
            string messaggio;
            if (txtFileXml.Text == "")
            {
                MessageBox.Show(this, "E' necessario indicare il file da elaborare!");
                chiediFileDaElaborare();
            }

            DirectoryInfo di = getDirectoryInfo(out messaggio);
            if (di == null)
            {
                chiediCartellaPerSalvare();
                di = getDirectoryInfo(out messaggio);
                if (di == null)
                {
                    MessageBox.Show(this, "Errore: " + messaggio
                        + "\n\nE' necessario indicare la cartella nella quale scrivere i file Emens da generare!");
                    return;
                }
            }

            dsEmens.Collaboratore.Clear();
            dsEmens.Azienda.Clear();
            dsEmens.log.Clear();

            leggiFile();

            int nFiles = CfgFn.GetNoNullInt32(dsEmens.Collaboratore.Compute("max(rownum)", null));

            // Scrive gli n file spacchettati.
            for (int i = 1; i <= nFiles; i++)
            {
                string NameNewFile = "";
                if (nFiles == 1)
                {
                    NameNewFile = Path.Combine(txtDirectory.Text, Path.GetFileName(txtFileXml.Text));
                }
                else
                {
                    NameNewFile = Path.Combine(txtDirectory.Text, Path.GetFileNameWithoutExtension(txtFileXml.Text) + i + ".xml");
                }

                XmlTextWriter writer = setXmlTextWriter(NameNewFile);
                writer.Formatting = Formatting.Indented;
                if (emensKind == "E")
                {
                    writer.WriteStartElement("DenunceRetributiveMensili");
                    writer.WriteStartElement("DatiMittente");
                }
                else
                {
                    writer.WriteStartElement("DenunceMensili");
                    writer.WriteStartElement("DatiMittente");
                    writer.WriteAttributeString("Tipo", "1");
                }

                writer.WriteElementString("CFPersonaMittente", txtCFPersonaMittente.Text);
                writer.WriteElementString("RagSocMittente", txtRagSocMittente.Text);
                writer.WriteElementString("CFMittente", txtCFMittente.Text);
                writer.WriteElementString("CFSoftwarehouse", txtCFSoftwarehouse.Text);
                writer.WriteElementString("SedeINPS", idSedeINPS);
                writer.WriteEndElement();//"DatiMittente"

                foreach (DataRow rigaAzienda in dsEmens.Azienda.Select(null, "CFAzienda,AnnoMeseDenuncia"))
                {
                    int nColl = dsEmens.Collaboratore.Select(QHC.AppAnd(QHC.CmpEq("idAzienda", rigaAzienda["idAzienda"]), QHC.CmpEq("rownum", i))).Length;
                    if (nColl == 0) continue;

                    writer.WriteStartElement("Azienda");
                    writeElementString(writer, "AnnoMeseDenuncia", rigaAzienda);
                    writeElementString(writer, "CFAzienda", rigaAzienda);
                    writeElementString(writer, "RagSocAzienda", rigaAzienda);

                    writer.WriteStartElement("ListaCollaboratori");
                    writeElementString(writer, "CAP", rigaAzienda);
                    writeElementString(writer, "ISTAT", rigaAzienda);

                    object idAzienda = rigaAzienda["idAzienda"];

                    //foreach (DataRow rigaCollaboratore in rigaAzienda.GetChildRows("AziendaCollaboratore"))
                    foreach (DataRow rigaCollaboratore in dsEmens.Collaboratore.Select(QHC.AppAnd(QHC.CmpEq("idAzienda", idAzienda), QHC.CmpEq("rownum", i))))
                    {
                        writer.WriteStartElement("Collaboratore");
                        writeElementString(writer, "CFCollaboratore", rigaCollaboratore);
                        writeElementString(writer, "Cognome", rigaCollaboratore);
                        writeElementString(writer, "Nome", rigaCollaboratore);
                        writeElementString(writer, "CodiceComune", rigaCollaboratore);
                        writeElementString(writer, "TipoRapporto", rigaCollaboratore);
                        writeElementString(writer, "CodiceAttivita", rigaCollaboratore);
                        writeElementString(writer, "Imponibile", rigaCollaboratore);
                        writeElementString(writer, "Aliquota", rigaCollaboratore);
                        writeElementString(writer, "AltraAss", rigaCollaboratore);
                        writeElementString(writer, "Dal", rigaCollaboratore);
                        writeElementString(writer, "Al", rigaCollaboratore);
                        writeElementString(writer, "CodCalamita", rigaCollaboratore);
                        writeElementString(writer, "CodCertificazione", rigaCollaboratore);
                        writer.WriteEndElement();//"Collaboratore"
                    }
                    writer.WriteEndElement();//"ListaCollaboratori"
                    writer.WriteEndElement();//"Azienda"
                }
                writer.WriteEndElement();//"DenunceRetributiveMensili"
                writer.Close();
            }
            visualizzaXml();
        }
        private void btnLeggi_Click(object sender, EventArgs e) {
            Leggi("E");
        }

        private void visualizzaXml() {
        DirectoryInfo di = new DirectoryInfo(txtDirectory.Text);
        dsEmens.Emens.Clear();

        foreach (FileInfo fi in di.GetFiles()) {
            XmlDocument document = new XmlDocument();
            try{
                document.Load(fi.FullName);
            }
            catch (XmlException ex){
                MessageBox.Show(this, "Impossibile aprire il file Xml specificato.\n" + ex.Message);
                return;
            }

            XmlElement DenunceRetributiveMensili = document.DocumentElement;
            XmlElement DatiMittente = DenunceRetributiveMensili["DatiMittente"];
            foreach (XmlElement Azienda in DenunceRetributiveMensili.GetElementsByTagName("Azienda"))
            {
                string filtroEsercizio = "(ayear=" + Azienda["AnnoMeseDenuncia"].InnerText.Substring(0, 4) + ")";
                XmlElement ListaCollaboratori = Azienda["ListaCollaboratori"];
                foreach (XmlElement Collaboratore in ListaCollaboratori.GetElementsByTagName("Collaboratore"))
                {
                    DataRow rEmens = dsEmens.Emens.NewRow();
                    rEmens["CFAzienda"] = valore(Azienda["CFAzienda"]);
                    rEmens["AnnoMeseDenuncia"] = mese(Azienda["AnnoMeseDenuncia"]);
                    rEmens["CFCollaboratore"] = valore(Collaboratore["CFCollaboratore"]);
                    rEmens["Cognome"] = valore(Collaboratore["Cognome"]);
                    rEmens["Nome"] = valore(Collaboratore["Nome"]);
                    rEmens["CodiceComune"] = valore(Collaboratore["CodiceComune"]);
                    rEmens["TipoRapporto"] = decodifica(Collaboratore["TipoRapporto"], dsEmens.emenscontractkind, filtroEsercizio,
                            "idemenscontractkind", "description");
                    rEmens["CodiceAttivita"] = decodifica(Collaboratore["CodiceAttivita"], dsEmens.inpsactivity, filtroEsercizio,
                            "activitycode", "description");
                    rEmens["Imponibile"] = valuta(Collaboratore["Imponibile"]);
                    rEmens["Aliquota"] = percentuale(Collaboratore["Aliquota"]);
                    rEmens["AltraAss"] = decodifica(Collaboratore["AltraAss"], dsEmens.otherinsurance, filtroEsercizio,
                            "idotherinsurance", "description");
                    rEmens["Dal"] = giorno(Collaboratore["Dal"]);
                    rEmens["Al"] = giorno(Collaboratore["Al"]);
                    rEmens["CodCalamita"] = valore(Collaboratore["CodCalamita"]);
                    rEmens["CodCertificazione"] = valore(Collaboratore["CodCertificazione"]);
                    rEmens["nomefile"] = fi.FullName;
                    dsEmens.Emens.Rows.Add(rEmens);
                }
            }
        }

        HelpForm.SetDataGrid(gridFile, dsEmens.Emens);
        new formatgrids(gridFile).AutosizeColumnWidth();
        }
        /// <summary>
        /// Riempie il dataset dsEmens leggendo i dati dal file 
        /// </summary>
        private void leggiFile(){
            XmlDocument document =  new XmlDocument();
            try{
                System.Diagnostics.Process.Start(txtFileXml.Text);
                document.Load(txtFileXml.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Impossibile aprire il file Xml specificato.\n" + ex.Message);
                return;
            }
            int idAzienda = 0;
            int idCollaboratore = 0;
            int rownum = 0;
            idSedeINPS = "";
            XmlElement DenunceRetributiveMensili = document.DocumentElement;
            foreach (XmlElement DatiMittente in DenunceRetributiveMensili.GetElementsByTagName("DatiMittente")){
                txtCFPersonaMittente.Text = valore(DatiMittente["CFPersonaMittente"]);
                txtRagSocMittente.Text = valore(DatiMittente["RagSocMittente"]);
                txtCFMittente.Text = valore(DatiMittente["CFMittente"]);
                txtCFSoftwarehouse.Text = valore(DatiMittente["CFSoftwarehouse"]);
                idSedeINPS = valore(DatiMittente["SedeINPS"]);
                object SedeINPS = meta.Conn.DO_READ_VALUE("inpscenter", QHS.CmpEq("idinpscenter", valore(DatiMittente["SedeINPS"])), "title");
                txtSedeINPS.Text = QueryCreator.quotedstrvalue(SedeINPS, false);
            }

            foreach (XmlElement Azienda in DenunceRetributiveMensili.GetElementsByTagName("Azienda")){
                XmlElement ListaCollaboratori = Azienda["ListaCollaboratori"];

                string filtroAzienda = QHC.AppAnd(
                    QHC.CmpEq("AnnoMeseDenuncia", Azienda["AnnoMeseDenuncia"].FirstChild.Value),
                    QHC.CmpEq("CFAzienda", Azienda["CFAzienda"].FirstChild.Value));
                DataRow[] rAz = dsEmens.Azienda.Select(filtroAzienda);
                if (rAz.Length == 0){
                    DataRow rAzienda = dsEmens.Azienda.NewRow();
                    idAzienda++;
                    rAzienda["AnnoMeseDenuncia"] = valore(Azienda["AnnoMeseDenuncia"]);
                    rAzienda["CFAzienda"] = valore(Azienda["CFAzienda"]);
                    rAzienda["RagSocAzienda"] = valore(Azienda["RagSocAzienda"]);
                    rAzienda["CAP"] = valore(ListaCollaboratori["CAP"]);
                    rAzienda["ISTAT"] = valore(ListaCollaboratori["ISTAT"]);
                    rAzienda["idAzienda"] = idAzienda;
                    dsEmens.Azienda.Rows.Add(rAzienda);
                }

                foreach (XmlElement Collaboratore in ListaCollaboratori.GetElementsByTagName("Collaboratore")) {
                    string filtroCollaboratore = QHC.AppAnd(
                        QHC.CmpEq("CFCollaboratore", Collaboratore["CFCollaboratore"].FirstChild.Value),
                        QHC.CmpEq("TipoRapporto", Collaboratore["TipoRapporto"].FirstChild.Value),
                        QHC.CmpEq("Aliquota", Collaboratore["Aliquota"].FirstChild.Value),
                        QHC.CmpEq("AnnoMeseDenuncia", Azienda["AnnoMeseDenuncia"].FirstChild.Value),
                        QHC.CmpEq("CFAzienda", Azienda["CFAzienda"].FirstChild.Value)
                        );

                    DataRow[] coll = dsEmens.Collaboratore.Select(filtroCollaboratore);
                    if (coll.Length > 0){
                        idCollaboratore = CfgFn.GetNoNullInt32(coll[0]["idCollaboratore"]); 
                        rownum = CfgFn.GetNoNullInt32(dsEmens.Collaboratore.Compute("max(rownum)", QHC.AppAnd(QHC.CmpEq("idCollaboratore",idCollaboratore), 
                                        QHC.CmpEq("idAzienda", idAzienda))));
                        rownum++;
                    }
                    else{
                        idCollaboratore++;
                        rownum = 1;
                    }
                    DataRow rColl = dsEmens.Collaboratore.NewRow();
                    rColl["CFCollaboratore"] = valore(Collaboratore["CFCollaboratore"]);
                    rColl["Cognome"] = valore(Collaboratore["Cognome"]);
                    rColl["Nome"] = valore(Collaboratore["Nome"]);
                    rColl["CodiceComune"] = valore(Collaboratore["CodiceComune"]);
                    rColl["TipoRapporto"] = valore(Collaboratore["TipoRapporto"]);
                    rColl["CodiceAttivita"] = valore(Collaboratore["CodiceAttivita"]);
                    rColl["Imponibile"] = valore(Collaboratore["Imponibile"]);
                    rColl["Aliquota"] = valore(Collaboratore["Aliquota"]);
                    rColl["AltraAss"] = valore(Collaboratore["AltraAss"]);
                    rColl["Dal"] = valore(Collaboratore["Dal"]);
                    rColl["Al"] = valore(Collaboratore["Al"]);
                    rColl["CodCalamita"] = valore(Collaboratore["CodCalamita"]);
                    rColl["CodCertificazione"] = valore(Collaboratore["CodCertificazione"]);
                    rColl["AnnoMeseDenuncia"] = valore(Azienda["AnnoMeseDenuncia"]);
                    rColl["CFAzienda"] = valore(Azienda["CFAzienda"]);
                    rColl["idAzienda"] = idAzienda;
                    rColl["idCollaboratore"] = idCollaboratore;
                    rColl["rownum"] = rownum;
                    dsEmens.Collaboratore.Rows.Add(rColl);
                }
            }

        }

        private string mese(XmlElement nodo)
        {
            if (nodo == null) return null;
            DateTime dateTime = DateTime.ParseExact(nodo.InnerText, "yyyy-MM", DateTimeFormatInfo.CurrentInfo);
            return dateTime.ToString("MMMM yyyy");
        }

        private string giorno(XmlElement nodo)
        {
            if (nodo == null) return null;
            DateTime dateTime = DateTime.ParseExact(nodo.InnerText, "yyyy-MM-dd", DateTimeFormatInfo.CurrentInfo);
            return dateTime.ToShortDateString();
        }

        private string decodifica(XmlElement nodo, DataTable tab, string filtroEsercizio, string valueMember, string displayMember)
        {
            if (nodo == null) return null;
            DataRow[] r = tab.Select(filtroEsercizio + " and (" + valueMember + "='" + nodo.InnerText + "')");
            if (r.Length == 0)
            {
                return "DECODIFICA DI " + nodo.InnerText + " NON RIUSCITA";
            }
            return r[0][displayMember].ToString();
        }

        private string percentuale(XmlElement nodo)
        {
            if (nodo == null) return null;
            decimal p = Decimal.Parse(nodo.InnerText) / 10000;
            return p.ToString("p");
        }

        private string valuta(XmlElement nodo)
        {
            if (nodo == null) return null;
            decimal p = Decimal.Parse(nodo.InnerText);
            return p.ToString("c");
        }

        private void btnFileXml_Click(object sender, EventArgs e){
            chiediFileDaElaborare();
        }

        private void btnDirectory_Click(object sender, EventArgs e){
            chiediCartellaPerSalvare();
        }

        private void chiediFileDaElaborare() {
            DialogResult dr = openFileDialog1.ShowDialog(this);
            if (dr != DialogResult.OK) return;
            txtFileXml.Text = openFileDialog1.FileName;
		}
        private void chiediCartellaPerSalvare(){
            DialogResult dr = folderBrowserDialog1.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            txtDirectory.Text = folderBrowserDialog1.SelectedPath;
        }

        private void btnUniEmens_Click(object sender, EventArgs e)
        {
            Leggi("U");
        }
    }
}