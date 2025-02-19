
/*
Easy
Copyright (C) 2024 Universit� degli Studi di Catania (www.unict.it)
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
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Xsl;
using System.IO;
using System.Security;

namespace no_table_invoicecomunicate {
    public partial class Frm_no_table_invoicecomunicate : MetaDataForm {
        MetaData Meta;
        DataAccess Conn;
        QueryHelper QHS;
        CQueryHelper QHC;
        private XmlTextWriter writer;
        
        public Frm_no_table_invoicecomunicate() {
            InitializeComponent();
            saveFileDialog1.DefaultExt = "xml";
        }
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Meta.CanCancel = false;
            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
            Meta.CanSave = false;
            Meta.SearchEnabled = false;
            txtEsercizio.Text = Meta.GetSys("esercizio").ToString();
            Conn = Meta.Conn;
            QHS = Conn.GetQueryHelper();
            QHC = new CQueryHelper();

            PostData.MarkAsTemporaryTable(DS.semestre, false);
            RiempiElencoTrimestri();
        }
        void RiempiElencoTrimestri() {
            AggiungiSemestre(1, "Gennaio - Giugno");
            AggiungiSemestre(2, "Luglio - Dicembre");
        }
        void AggiungiSemestre(int IDsemestre, string descr) {
            DataRow R = DS.semestre.NewRow();
            R["idsemestre"] = IDsemestre;
            R["descrizione"] = descr;
            DS.semestre.Rows.Add(R);
            DS.semestre.AcceptChanges();
        }
        private void btnGenera_Click(object sender, EventArgs e) {
            generaFile();
        }

        public bool DatiValidi() {
            int esercizio;
            try {
                esercizio = (int)HelpForm.GetObjectFromString(typeof(int),
                    txtEsercizio.Text.ToString(), "x.y.year");
                if ((esercizio < 0)) {
                    show("L'esercizio non pu� essere negativo");
                    txtEsercizio.Focus();
                    return false;
                }
            }
            catch {
                show("E' necessario inserire un esercizio");
                txtEsercizio.Focus();
                return false;
            }

            if (cmbSemestre.SelectedValue == null) {
                show("E' necessario selezionare un Semestre");
                return false;
            }
            txtEsercizio.Focus();
            
            return true;
        }
        private void txtEsercizio_Leave(object sender, EventArgs e) {
            HelpForm.FormatLikeYear(txtEsercizio);
        }
        private void faiScegliereCartella() {
            DialogResult dr = folderBrowserDialog1.ShowDialog(this);
            if (dr == DialogResult.OK) {
                txtPercorso.Text = folderBrowserDialog1.SelectedPath;
            }
        }
        private string BuildNomeFile(char progressivo) {
            //ITDMSCSM79S19C975E_DF_20171.xml
            //IT80006510806_DF_20171.xml
            DataTable dtLicense = Conn.RUN_SELECT("license", "cf, p_iva", null, null, null, false);
            if (dtLicense == null || dtLicense.Rows.Count == 0) {
                QueryCreator.ShowError(this, "Errore del database nel reperire informazioni dalla licenza.", Conn.LastError);
                return "";
            }

            var license = dtLicense.First();
            var codiceFiscale = license.Field<string>("cf");
            var partitaIVA = license.Field<string>("p_iva");
            int esercizio = (int)HelpForm.GetObjectFromString(typeof(int),
               txtEsercizio.Text.ToString(), "x.y.year");
            string esercizioStr = esercizio.ToString().Substring(2, 2);
            object semestre = cmbSemestre.SelectedValue;
            object kind_registry;
            if (rdbA.Checked) {
                kind_registry = 'F';//per gli Acquisti mettiamo la F a indicare che si tratta di Fornitore
            }
            else {
                kind_registry = 'C';//per le Vendite mettiamo la V a indicare che si tratta di Cliente
            }
            string NomeFile = "";
            if (codiceFiscale != "") NomeFile = "IT" + codiceFiscale + "_" + "DF_" + kind_registry +esercizioStr.ToString() + progressivo + semestre.ToString();
            else NomeFile = "IT" + partitaIVA + "_" + "DF_" + kind_registry + esercizioStr.ToString() + progressivo + semestre.ToString();
            return NomeFile;
        }
        private string aggiustaStringa(string stringa, bool toglichiocciola) {

            string s = stringa.Replace('�', ' ').Replace('�', ' ').Replace('�', 'c').Replace('�', 'c').Replace('�', 'e').Replace('|', ' ').Replace('\\', ' ').Replace('�', ' ').Replace('�', ' ').Replace('[', ' ').Replace('#', ' ').Replace('!', ' ').Replace('�', 'u').Replace(
                '�', 'o').Replace('�', 'u').Replace('�', 'n').Replace('�', 'd').Replace('�', 'e').Replace('�', 'e').Replace('�', 'i').Replace('�', 'i').Replace('�', 'o').Replace('�', 'o').Replace('�', 'u').Replace('�', 'y').Replace(
                ']', ' ').Replace('`', ' ').Replace('{', ' ').Replace('}', ' ').Replace('~', ' ').Replace('�', 'u').Replace('�', 'a').Replace('�', 'a').Replace('�', 'a').Replace('�', 'e').Replace('�', 'e').Replace('�', 'i').Replace(
                '�', 'i').Replace('�', 'a').Replace('�', 'a').Replace('�', 'o').Replace('�', 'o').Replace('�', 'u').Replace('�', 'y').Replace('�', 'n').Replace('�', 'a').Replace('�', 'y').Replace('�', 'a').Replace('�', 'a').Replace(
                '�', 'o').Replace('�', 'y').Replace('�', 'e').Replace('�', 'a').Replace('�', 'e').Replace('�', 'i').Replace('�', 'o').Replace('�', 'u').Replace('�', 'a').Replace('�', 'i').Replace('�', 'o').Replace('�', 'e').Replace(
                '�', 'a').Replace('�', 'a').Replace('�', 'e').Replace('�', 'i').Replace('�', 'i').Replace('�', 'o').Replace('�', 'o').Replace('�', 'u').Replace('\t', ' ').Replace('\n', ' ').Replace('\r', ' ').Replace('�', ' ');
            if (toglichiocciola)
                s = s.Replace('@', ' ');
            return s;
        }
        string getLatin1(object o) {
            if (o == null || o == DBNull.Value) {
                return "";
            }
            string t = aggiustaStringa(o.ToString(), false);
            byte[] b = Encoding.ASCII.GetBytes(t);
            string res = "";
            for (int i = 0; i < t.Length; i++) {
                if (b[i] >= 128) {
                    continue;
                }
                res += Encoding.ASCII.GetString(new byte[] { b[i] });
            }
            return res;
        }
        string FormatData(DateTime Data) {
            return Data.Year.ToString() + "-" + Data.Month.ToString().PadLeft(2, '0') + "-" + Data.Day.ToString().PadLeft(2, '0');
        }
        string FormatDecimal(Decimal d) {
            return sostituiscivirgolaconpunto(d);
        }
        private string sostituiscivirgolaconpunto(decimal importo) {
            string group = System.Globalization.NumberFormatInfo.CurrentInfo.NumberGroupSeparator;
            string dec = System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
            string s1 = importo.ToString("g").Replace(group, "");
            return s1.Replace(dec, ".");
        }
        private string sostituiscipuntoconvirgola(decimal importo) {
            string group = System.Globalization.NumberFormatInfo.CurrentInfo.NumberGroupSeparator;
            string dec = System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
            string s1 = importo.ToString("g").Replace(group, "");
            return s1.Replace(dec, ",");
        }

        private string format(object o) {

            if (o == null || o == DBNull.Value) return "";
            if (o is DateTime) return SecurityElement.Escape(FormatData((DateTime)o));
            if (o is decimal) return SecurityElement.Escape(FormatDecimal((decimal)o));
            if (o.GetType().ToString() == "System.Byte[]") return Convert.ToBase64String((byte[])o,
                                Base64FormattingOptions.InsertLineBreaks);
            var res = SecurityElement.Escape(o.ToString());
            res = res?.Replace("\"", "&quot;").Replace("'", "&apos;");
            return res;
        }
        string getAZ09(object o) {
            if (o == null || o == DBNull.Value) {
                return "";
            }
            string t = aggiustaStringa(o.ToString(), false).ToUpperInvariant();
            byte[] b = Encoding.ASCII.GetBytes(t);
            string res = "";
            for (int i = 0; i < t.Length; i++) {
                if (b[i] >= 65 && b[i] <= 90) {
                    res += Encoding.ASCII.GetString(new byte[] { b[i] });
                }
                if (b[i] >= 48 && b[i] <= 57) {
                    res += Encoding.ASCII.GetString(new byte[] { b[i] });
                }

            }
            return res;
        }
        string getAZ(object o) {
            if (o == null || o == DBNull.Value) {
                return "";
            }
            string t = aggiustaStringa(o.ToString(), false).ToUpperInvariant();
            byte[] b = Encoding.ASCII.GetBytes(t);
            string res = "";
            for (int i = 0; i < t.Length; i++) {
                if (b[i] >= 65 && b[i] <= 90) {
                    res += Encoding.ASCII.GetString(new byte[] { b[i] });
                }

            }
            return res;
        }
        string getdigit09(object o) {
            if (o == null || o == DBNull.Value) {
                return "";
            }
            string t = aggiustaStringa(o.ToString(), false).ToUpperInvariant();
            byte[] b = Encoding.ASCII.GetBytes(t);
            string res = "";
            for (int i = 0; i < t.Length; i++) {
                if (b[i] >= 48 && b[i] <= 57) {
                    res += Encoding.ASCII.GetString(new byte[] { b[i] });
                }

            }
            return res;
        }
        private void generaFile() {
            if (!DatiValidi()) return;
            if (Conn==null)return;
            
            var esercizio = (int)HelpForm.GetObjectFromString(typeof(int),
                txtEsercizio.Text, "x.y.year");
            var semestre = cmbSemestre.SelectedValue;
            var kind = rdbA.Checked ? "A" : "V";
            var Out = Conn.CallSP("exp_invoicecomunicate", new [] { esercizio, semestre, kind }, false, 6000);
            if (Out == null) return;
            var outRiepilogo = Conn.CallSP("exp_invoicecomunicateriepilogo", new [] { esercizio, semestre, kind }, false, 6000);
            if (outRiepilogo == null) return;
            var tComunicazione = Out.Tables[0];
            var tRiepilogo = outRiepilogo.Tables[0];
            var r = tComunicazione.First();
            if (r==null) return;
            txtPercorso.Text = "";
            faiScegliereCartella();
            if (txtPercorso.Text == "") {
                show(this, "Occorre specificare la cartella in cui creare il file", "errore");
                return;
            }
            Application.DoEvents();
            Cursor.Current = Cursors.WaitCursor;
            string progressivi = "00123456789abcdefghijklmnopqrstuvwxyz";
      

            string NomiFile = "";

            int numeroPacchetti = tComunicazione.Rows.Count / 1000;
            int resto = tComunicazione.Rows.Count - numeroPacchetti * 1000;
            if (resto > 0) numeroPacchetti++;
            for (int Npacchetto = 1; Npacchetto <= numeroPacchetti; Npacchetto++) {

                int limiteInferiore = (Npacchetto - 1) * 1000; //0 , 1000 , 2000
                int limiteSuperiore = (Npacchetto * 1000)-1;   //999, 1999, ... il nostro ultimo indice valido deve essere rows.count-1;
                if (limiteSuperiore >= tComunicazione.Rows.Count) limiteSuperiore = tComunicazione.Rows.Count - 1;

                // Scrittura XML
                var sw = new StringWriter();
                writer = new XmlTextWriter(sw) {Formatting = Formatting.Indented};
                writer.WriteProcessingInstruction("xml", "version='1.0' encoding='UTF-8'");
                writer.WriteStartElement("ns2:DatiFattura");
                const string versione = "DAT20";
                writer.WriteAttributeString("versione", versione);
                writer.WriteAttributeString("xmlns", "ns2", null,
                    "http://ivaservizi.agenziaentrate.gov.it/docs/xsd/fatture/v2.0");

                writer.WriteStartElement("DatiFatturaHeader"); //apre <DatiFatturaHeader>
                writer.WriteElementString("ProgressivoInvio", getLatin1(r["ProgressivoInvio"].ToString() + progressivi[Npacchetto].ToString()));
                writer.WriteEndElement(); // Chiude </DatiFatturaHeader>
                //if (kind.ToString() == "V") {
                var suffisso = kind == "V" ? "DTE" : "DTR";
                writer.WriteStartElement(suffisso); //apre <DTE>
                writer.WriteStartElement(kind == "V" ? "CedentePrestatoreDTE" : "CessionarioCommittenteDTR");

                writer.WriteStartElement("IdentificativiFiscali"); //Apre <IdentificativiFiscali>
                writer.WriteStartElement("IdFiscaleIVA"); // apre <IdFiscaleIVA>
                writer.WriteElementString("IdPaese", "IT");
                writer.WriteElementString("IdCodice", format(r["IdFiscaleIvaCodiceDip"]));
                writer.WriteEndElement(); // chiude <IdFiscaleIVA>
                writer.WriteElementString("CodiceFiscale", getAZ09(r["IdTrasmittenteCodice"]));
                writer.WriteEndElement(); // chiude IdentificativiFiscali

                writer.WriteStartElement("AltriDatiIdentificativi"); // Apre <AltriDatiIdentificativi>
                writer.WriteElementString("Denominazione", getLatin1(r["DenominazioneDip"]));
                writer.WriteStartElement("Sede"); //Apre <Sede>
                writer.WriteElementString("Indirizzo", getLatin1(r["indirizzoDip"]));
                writer.WriteElementString("CAP", getdigit09(r["capDip"]));
                writer.WriteElementString("Comune", getLatin1(r["comuneDip"]));
                writer.WriteElementString("Provincia", getAZ(r["provinciaDip"]));
                writer.WriteElementString("Nazione", "IT");
                writer.WriteEndElement(); // chiude <Sede>
                writer.WriteEndElement(); // chiude <AltriDatiIdentificativi>

                writer.WriteEndElement(); // Chiude </CedentePrestatoreDTE> o <CessionarioCommittenteDTR>
                for (int indice=limiteInferiore; indice<= limiteSuperiore;indice++ ) {
                    var rFattura = tComunicazione.Rows[indice];
                    writer.WriteStartElement(kind == "V" ? "CessionarioCommittenteDTE" : "CedentePrestatoreDTR");

                    //IdentificativiFiscali
                    writer.WriteStartElement(
                        "IdentificativiFiscali"); //Apre <IdentificativiFiscali  COMMITTENTE/FORNITORE
                    if (rFattura["IdFiscaleIvaCodiceAnagrafica"].ToString() != "") {
                        writer.WriteStartElement("IdFiscaleIVA"); // apre <IdFiscaleIVA>
                        writer.WriteElementString("IdPaese", getAZ(rFattura["IdFiscaleIvaPaeseAnagrafica"]));
                        writer.WriteElementString("IdCodice", format(rFattura["IdFiscaleIvaCodiceAnagrafica"]));
                        writer.WriteEndElement(); // chiude <IdFiscaleIVA>
                    }

                    if (rFattura["CFAnagrafica"].ToString() != "") {
                        writer.WriteElementString("CodiceFiscale", getAZ09(rFattura["CFAnagrafica"]));
                    }

                    writer.WriteEndElement(); // chiude IdentificativiFiscali COMMITTENTE
                    //AltriDatiIdentificativi COMMITTENTE
                    writer.WriteStartElement("AltriDatiIdentificativi");
                    if (rFattura["DenominazioneAnagrafica"].ToString() != "") {
                        writer.WriteElementString("Denominazione", getLatin1(rFattura["DenominazioneAnagrafica"]));
                    }

                    if (rFattura["nomeAnagrafica"].ToString() != "") {
                        writer.WriteElementString("Nome", getLatin1(rFattura["nomeAnagrafica"]));
                    }

                    if (rFattura["cognomeAnagrafica"].ToString() != "") {
                        writer.WriteElementString("Cognome", getLatin1(rFattura["cognomeAnagrafica"]));
                    }

                    writer.WriteStartElement("Sede"); //Apre <Sede>
                    writer.WriteElementString("Indirizzo", getLatin1(rFattura["indirizzoAnagrafica"]));
                    if (rFattura["capAnagrafica"].ToString() != "") {
                        writer.WriteElementString("CAP", getdigit09(rFattura["capAnagrafica"]));
                    }

                    writer.WriteElementString("Comune", getLatin1(rFattura["comuneAnagrafica"]));
                    if (rFattura["provinciaAnagrafica"].ToString() != "") {
                        writer.WriteElementString("Provincia", getAZ(rFattura["provinciaAnagrafica"]));
                    }

                    writer.WriteElementString("Nazione", getAZ(rFattura["nazioneAnagrafica"]));
                    writer.WriteEndElement(); // chiude <Sede>
                    writer.WriteEndElement(); // chiude AltriDatiIdentificativi
                    //DatiFatturaBodyDTE
                    writer.WriteStartElement("DatiFatturaBody" + suffisso); //Apre <DatiFatturaBodyDTE>
                    //DatiGenerali
                    writer.WriteStartElement("DatiGenerali"); //Apre DatiGenerali
                    writer.WriteElementString("TipoDocumento", format(rFattura["TipoDocumento"]));
                    writer.WriteElementString("Data", format(rFattura["datadocumento"]));
                    writer.WriteElementString("Numero", getLatin1(rFattura["numero"]));

                    if (kind == "A") {
                        writer.WriteElementString("DataRegistrazione", format(rFattura["dataregistrazione"]));
                    }

                    writer.WriteEndElement(); // chiude DatiGenerali
                    //DatiRiepilogo
                    var filterFatt = QHC.AppAnd(QHC.CmpEq("idinvkind", rFattura["idinvkind"]),
                        QHC.CmpEq("yinv", rFattura["yinv"]), QHC.CmpEq("ninv", rFattura["ninv"]));
                    foreach (var rRiepilogo in tRiepilogo.Select(filterFatt)) {
                        writer.WriteStartElement("DatiRiepilogo");
                        writer.WriteElementString("ImponibileImporto", format(rRiepilogo["ImponibileImporto"]));
                        writer.WriteStartElement("DatiIVA");
                        writer.WriteElementString("Imposta", format(rRiepilogo["Imposta"]));
                        writer.WriteElementString("Aliquota", format(rRiepilogo["AliquotaIVA"]));
                        writer.WriteEndElement(); //Chiude <DatiIVA>
                        if (rRiepilogo["Natura"].ToString() != "") {
                            writer.WriteElementString("Natura", format(rRiepilogo["Natura"]));
                        }

                        writer.WriteElementString("EsigibilitaIVA", format(rRiepilogo["EsigibilitaIVA"]));
                        writer.WriteEndElement(); //Chiude <DatiRiepilogo>
                    }

                    writer.WriteEndElement(); //Chiude <DatiFatturaBodyDTE>
                    writer.WriteEndElement(); //Chiude <CessionarioCommittenteDTE> 0 <CedentePrestatoreDTR>
                }

                writer.WriteEndElement(); // Chiude </DTE>
                // } // if kind=V
                writer.WriteEndElement(); // Chiude ns2:DatiFattura
                writer.Close();

                var nomeFile = BuildNomeFile(progressivi[Npacchetto]) + ".xml";
                var nomeCompletoFileXml = Path.Combine(txtPercorso.Text, nomeFile);

                txtNomeFile.Text = nomeCompletoFileXml;


                var stw = new StreamWriter(nomeCompletoFileXml);
                stw.Write(sw.ToString());
                stw.Flush();
                stw.Close();
                if (!ValidaFile_conXSD(nomeCompletoFileXml)) return ;
                NomiFile += nomeFile + '-';
            }
            //var xmlString = sw.ToString();
            //var xml = new UTF8Encoding().GetBytes(xmlString);


            Meta.SaveFormData();
            show("File creati:\n\r " + NomiFile, "Avviso");
            

            show("Salvataggio eseguito.");
         

        }

        private bool ValidaFile_conXSD(string fileName) {            
            bool res = XML_XSD_Validator.Validate(fileName, AppDomain.CurrentDomain.BaseDirectory + "datifatturav2.0.xsd");
            if (!res) {
                QueryCreator.ShowError(this, "Errore nella validazione dell'xml\r\n"+
                    $"Il file  {fileName} contiene errori nei dati che ne causeranno lo scarto. \r\n"+
                    "Per ottenere l'elenco delle probabili cause del problema, cliccare su OK e poi sul pulsante 'Documenti Elaborati' nella sezione 'Verifiche' in alto a destra del form.\r\n",
                                XML_XSD_Validator.GetError());
                return false;
            }else {
                show($"File {fileName} validato con successo");
                return true;
            }
            return res;
        }
        private void Excel_Click(object sender, EventArgs e, DataTable T) {
            if (T.Rows.Count == 0) {
                show("Nessun elemento trovato");
                return;
            }
            exportclass.DataTableToExcel(T, true);
        }
        private void btnDocElaborati_Click(object sender, EventArgs e) {
            if (!DatiValidi()) return;
            int esercizio = (int)HelpForm.GetObjectFromString(typeof(int),
                txtEsercizio.Text.ToString(), "x.y.year");
            object semestre = cmbSemestre.SelectedValue;
            object kind;
            if (rdbA.Checked) {
                kind = "A";
            }
            else {
                kind = "V";
            }
            DataSet Out = Conn.CallSP("exp_invoicecomunicate_dati", new object[] { esercizio, semestre, kind }, false, 6000);
            if (Out == null) return;
            DataTable tFatture= Out.Tables[0];
            int CountError = 0;
            foreach (DataRow rFattura in tFatture.Select()) {
                if (rFattura["comuneAnagrafica"].ToString() == "") {
                    rFattura["error"] = "Manca il Comune dell'Anagrafica.";
                    CountError++;
                }
                if (rFattura["Tipodocumento"].ToString() == "") {
                    rFattura["error"] = "Manca l'indicazione del Tipodocumento.";
                    CountError++;
                }

                if ((rFattura["IdFiscaleIvaCodiceAnagrafica"].ToString()=="") && (rFattura["CFAnagrafica"].ToString() == "")) {
                    rFattura["error"] = rFattura["error"].ToString() + "Indicare la p.iva o il CF dell'Anagrafica.";
                    CountError++;
                }
                if((CfgFn.GetNoNullDecimal(rFattura["AliquotaIVA"])==0) && (rFattura["Natura"].ToString() == "")) {
                    rFattura["error"] = rFattura["error"].ToString() + "Per le aliquote 0, va indicata la Natura.";
                    CountError++;
                }
               if (rFattura["IdFiscaleIvaPaeseAnagrafica"].ToString() == "IT") {
                    string errorePIVA = CalcolaPartitaIva.controllaPartitaIva(rFattura["IdFiscaleIvaCodiceAnagrafica"].ToString());
                    if (errorePIVA != null) {
                        rFattura["error"] = rFattura["error"].ToString()  + "La Partita IVA inserita non � valida.";
                        CountError++;
                    }
                }
                if (rFattura["indirizzoAnagrafica"].ToString()=="") {
                    rFattura["error"] = "Manca un indirizzo valido per l'Anagrafica.";
                    CountError++;
                }
                //Per gli ExtraUE se le prime due cifre del CF estero sono diverse dal codice ISO della nazione, indicata nell'indirizzo di residenza, comunica la differenza.
                if ((rFattura["codresidenza"].ToString() == "X") && (rFattura["IdFiscaleIvaPaeseAnagrafica"].ToString() != rFattura["nazioneAnagrafica"].ToString())){
                    rFattura["error"] = rFattura["error"].ToString() + "Anagrafica ExtraUE:i primi due caratteri del CF estero sono diversi dal codice ISO della nazione indicata nell'indirizzo.";
                    CountError++;
                }


            }

            if (CountError > 0) {
                show(
                    "Sono stati riscontrati errori nei dati che causeranno lo scarto del file.\nGli errori sono riportati nell'ultima colonna.",
                    "Avviso",MessageBoxButtons.OK);
                //foreach (DataRow rFattura in tFatture.Select(QHC.CmpEq("error",""))) {
                //    rFattura.Delete();
                //}
                //tFatture.AcceptChanges();
            }

            if (tFatture != null) {
            Excel_Click(sender, e, tFatture);
            }
        }

        private void Frm_no_table_invoicecomunicate_Load(object sender, EventArgs e) {

        }
    }
}
