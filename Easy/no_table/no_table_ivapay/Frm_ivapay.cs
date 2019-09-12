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

﻿using metadatalibrary;
using metaeasylibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Xsl;
using System.IO;
using System.Security;
using System.Globalization;
using funzioni_configurazione;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace no_table_ivapay {

    public partial class Frm_ivapay :Form {

        private const int SP_TIMEOUT = 10000;


        MetaData Meta;
        DataAccess Conn;
        QueryHelper QHS;
        CQueryHelper QHC;
        private XmlTextWriter writer;
        public Frm_ivapay() {
            InitializeComponent();
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

            PostData.MarkAsTemporaryTable(DS.trimestre, false);
            RiempiElencoTrimestri();
        }

        void RiempiElencoTrimestri() {
            AggiungiTrimestre(1, "Gennaio - Marzo");
            AggiungiTrimestre(2, "Aprile - Giugno");
            AggiungiTrimestre(3, "Luglio - Settembre");
            AggiungiTrimestre(4, "Ottobre - Dicembre");
        }
        void  AggiungiTrimestre(int IDtrimestre, string descr) {
            DataRow R = DS.trimestre.NewRow();
            R["idtrimestre"] = IDtrimestre;
            R["descrizione"] = descr;
            DS.trimestre.Rows.Add(R);
            DS.trimestre.AcceptChanges();
        }


        private void txtEsercizio_Leave(object sender, System.EventArgs e) {
            HelpForm.FormatLikeYear(txtEsercizio);
        }

        public bool DatiValidi() {
            int esercizio;
            try {
                esercizio = (int)HelpForm.GetObjectFromString(typeof(int),
                    txtEsercizio.Text.ToString(), "x.y.year");
                if ((esercizio < 0)) {
                    MessageBox.Show("L'esercizio non può essere negativo");
                    txtEsercizio.Focus();
                    return false;
                }
            }
            catch {
                MessageBox.Show("E' necessario inserire un esercizio");
                txtEsercizio.Focus();
                return false;
            }

            if (cmbTrimestre.SelectedValue == null) {
                MessageBox.Show("E' necessario selezionare un trimestre");
                return false;
            }

            txtEsercizio.Focus();
            return true;
        }

        private void btnOK_Click(object sender, System.EventArgs e) {
          
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



        private void faiScegliereCartella() {
            DialogResult dr = folderBrowserDialog1.ShowDialog(this);
            if (dr == DialogResult.OK) {
                txtPercorso.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private string aggiustaStringa(string stringa, bool toglichiocciola) {

            string s = stringa.Replace('’', ' ').Replace('´', ' ').Replace('Ç', 'c').Replace('ç', 'c').Replace('€', 'e').Replace('|', ' ').Replace('\\', ' ').Replace('£', ' ').Replace('§', ' ').Replace('[', ' ').Replace('#', ' ').Replace('!', ' ').Replace('Ù', 'u').Replace(
                'Ö', 'o').Replace('Ü', 'u').Replace('Ñ', 'n').Replace('Ð', 'd').Replace('Ê', 'e').Replace('Ë', 'e').Replace('Î', 'i').Replace('Ï', 'i').Replace('Ô', 'o').Replace('Õ', 'o').Replace('Û', 'u').Replace('Ý', 'y').Replace(
                ']', ' ').Replace('`', ' ').Replace('{', ' ').Replace('}', ' ').Replace('~', ' ').Replace('ü', 'u').Replace('â', 'a').Replace('ä', 'a').Replace('å', 'a').Replace('ê', 'e').Replace('ë', 'e').Replace('ï', 'i').Replace(
                'î', 'i').Replace('Ä', 'a').Replace('Å', 'a').Replace('ô', 'o').Replace('ö', 'o').Replace('û', 'u').Replace('ÿ', 'y').Replace('ñ', 'n').Replace('Â', 'a').Replace('¥', 'y').Replace('ã', 'a').Replace('Ã', 'a').Replace(
                'õ', 'o').Replace('ý', 'y').Replace('é', 'e').Replace('à', 'a').Replace('è', 'e').Replace('ì', 'i').Replace('ò', 'o').Replace('ù', 'u').Replace('á', 'a').Replace('í', 'i').Replace('ó', 'o').Replace('É', 'e').Replace(
                'Á', 'a').Replace('À', 'a').Replace('È', 'e').Replace('Í', 'i').Replace('Ì', 'i').Replace('Ó', 'o').Replace('Ò', 'o').Replace('Ú', 'u').Replace('\t', ' ').Replace('\n', ' ').Replace('\r', ' ').Replace('°', ' ');
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
        string format(object o) {

            if (o == null || o == DBNull.Value) return "";
            if (o.GetType() == typeof(Decimal)&&(CfgFn.GetNoNullDecimal(o) == 0)) return "";
            if (o.GetType() == typeof(DateTime)) return SecurityElement.Escape(FormatData((DateTime)o));
            if (o.GetType() == typeof(Decimal)) return SecurityElement.Escape(FormatDecimal((Decimal)o));
            if (o.GetType().ToString() == "System.Byte[]") return Convert.ToBase64String((byte[])o,
                                Base64FormattingOptions.InsertLineBreaks);
            string res = SecurityElement.Escape(o.ToString());
            if (res != null) {
                res = res.Replace("\"", "&quot;").Replace("'", "&apos;");
            }
            return res;
        }

        string FormatData(DateTime Data) {
            return Data.Year.ToString() + "-" + Data.Month.ToString().PadLeft(2, '0') + "-" + Data.Day.ToString().PadLeft(2, '0');
        }
        string FormatDecimal(Decimal d) {
            return sostituiscipuntoconvirgola(d);
        }

        string FormatGenericDecimal(Decimal d) {
            return d.ToString("N");
        }


        string FormatDecimalN(Decimal d, int N) {
            return d.ToString("F" + N, CultureInfo.InvariantCulture);
        }
        const string baseChars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        public static string IntToString(int value) {

            string result = "";
            int Base = baseChars.Length; //=62

            do {
                result = baseChars[value % Base] + result;
                value = value / Base;
            }
            while (value > 0);

            return result;
        }

        private string BuildNomeFile() {
            //ITDMSCSM79S19C975E_LI_20171.xml
            //IT80006510806_LI_20171.xml
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
            object trimestre = cmbTrimestre.SelectedValue;
            string NomeFile = "";
            if (codiceFiscale!="") NomeFile = "IT" + codiceFiscale + "_" + "LI_" + esercizio.ToString() + trimestre.ToString();
            else NomeFile = "IT" + partitaIVA + "_" + "LI_" + esercizio.ToString() + trimestre.ToString();
            return NomeFile;
        }

        private void generaFile() { 
            if (!DatiValidi()) return;
            int esercizio = (int)HelpForm.GetObjectFromString(typeof(int),
                txtEsercizio.Text.ToString(), "x.y.year");
            object trimestre = cmbTrimestre.SelectedValue;
            gridLiquidazioni.DataSource = null;
            DataSet Out = Conn.CallSP("exp_mod_liquidazioneperiva", new object[] { esercizio, trimestre }, false, 6000);
                if (Out == null) return;
                DataTable LiquidazioniIva = Out.Tables[0];
 

            gridLiquidazioni.DataBindings.Clear();
            gridLiquidazioni.DataSource = null;
            gridLiquidazioni.TableStyles.Clear();
            HelpForm.SetDataGrid(gridLiquidazioni, LiquidazioniIva);
            formatgrids fg = new formatgrids(gridLiquidazioni);
            fg.AutosizeColumnWidth();

            if (LiquidazioniIva.Columns.Contains("message")) { 
                MessageBox.Show("Il file non è stato generato");
                return;
            }
            string filterIntestazione = QHC.CmpEq("kind", "I");
            string filterFrontespizio = QHC.CmpEq("kind", "F");
            string filterModulo = QHC.CmpEq("kind", "VP");
            DataRow RIntestazione = LiquidazioniIva.First(filterIntestazione);
            DataRow RFrontespizio = LiquidazioniIva.First(filterFrontespizio);
            DataRow[] RModuli = LiquidazioniIva.Select(filterModulo);

            txtPercorso.Text = "";
            faiScegliereCartella();
            if (txtPercorso.Text == "") {
                MessageBox.Show(this, "Occorre specificare la cartella in cui creare il file", "errore");
                return;
            }
            Application.DoEvents();
            Cursor.Current = Cursors.WaitCursor;

            string NomeFile = BuildNomeFile() + ".xml";
            txtNomeFile.Text = NomeFile;
            string NomeCompletoFileXML = Path.Combine(txtPercorso.Text, NomeFile);
            try {
                File.Copy(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, NomeFile), NomeCompletoFileXML, true);
            }
            catch {

            }
            txtPercorso.Text = NomeCompletoFileXML;
            // Scrittura XML

            StringWriter sw = new StringWriter();
            writer = new XmlTextWriter(sw);
            writer.Formatting = Formatting.Indented;
            //< iv:Fornitura xmlns:iv = "urn:www.agenziaentrate.gov.it:specificheTecniche:sco:ivp" xmlns: ds = "http://www.w3.org/2000/09/xmldsig#" >
            writer.WriteProcessingInstruction("xml", "version='1.0' encoding='UTF-8' standalone='yes'");
            writer.WriteStartElement("iv:Fornitura"); //apre <Intestazione>
            writer.WriteAttributeString("xmlns", "iv", null, "urn:www.agenziaentrate.gov.it:specificheTecniche:sco:ivp");

            writer.WriteAttributeString("xmlns", "ds", null, "http://www.w3.org/2000/09/xmldsig#");

      

            /*
			1   <Fornitura>											<1.1>	
				1.1   <Intestazione>								Blocco obbligatorio		<1.1>	
					1.1.1   <CodiceFornitura>						xs:string	L'elemento è obbligatorio e contiene il codice della fornitura	"Valori ammessi:[ IVP17]"	<1.1>	5
					1.1.2   <CodiceFiscaleDichiarante>				xs:string	"Codice fiscale del soggetto obbligato alla trasmissione della comunicazione IVA quando non coincide con il soggetto passivo al quale i dati si riferiscono (p.e. tutore, curatore fallimentare etc.). Deve essere valorizzato tranne nei casi in cui il soggetto che appone la firma elettronica sul file:
																	- coincide  con il soggetto IVA al quale i dati si riferiscono;
																	- è un incaricato del soggetto IVA registrato presso i servizi telematici dell’Agenzia delle Entrate ed autorizzato attraverso le specifiche funzionalità di profilazione riservate ai “gestori incaricati”;
																	- è un intermediario (art. 3, commi 2 bis e 3 del DPR 322/1978)"	formato alfanumerico	<0.1>	16
					1.1.3   <CodiceCarica>							xs:string	Codice riferibile al soggetto che invia la comunicazione IVA in relazione alla carica rivestita	"Valori ammessi: vedi tabella generale dei codici di carica disponibile nelle istruzioni del modello IVA annuale"	<0.1>	1 … 2
					1.1.4   <IdSistema>						        xs:string	Campo riservato al Sistema: da NON valorizzare	formato alfanumerico	<0.1>	11 _16
			*/


            writer.WriteStartElement("iv:Intestazione"); //apre <Intestazione>
            writer.WriteElementString("iv:CodiceFornitura", getAZ09(RIntestazione["CodiceFornitura"]));
            writer.WriteElementString("iv:CodiceFiscaleDichiarante", getAZ09(RIntestazione["CodiceFiscaleDichiarante"]));
            writer.WriteElementString("iv:CodiceCarica", getAZ09(RIntestazione["CodiceCarica"]));
            
            //IdSistema campo ad uso esclusivo del sistema (non deve essere valorizzato). 
            //writer.WriteElementString("IdSistema", getAZ09(RIntestazione["IdSistema"]));   

            writer.WriteEndElement();// chiude <Intestazione>

            /*	
			1.2   <Comunicazione>						Blocco contenente i dati della comunicazione trimestrale IVA		<1.1>	
			1.2.1   <Frontespizio>						Blocco contenente i dati del fronterspizio della comunicazione trimestrale IVA		<1.1>	
			1.2.1.1   <CodiceFiscale>					xs:string	Codice fiscale del soggetto cui si riferisce la comunicazione trimestrale IVA	formato alfanumerico	<1.1>	11 … 16
			1.2.1.2   <AnnoImposta>					    xs:string	Anno di imposta  cui si riferisce la comunicazione	formato numerico	<1.1>	4
			1.2.1.3   <PartitaIVA>					    xs:string	Partita IVA del soggetto cui si riferisce la comunicazione trimestrale IVA	formato alfanumerico	<1.1>	11
			1.2.1.4   <PIVAControllante>			    xs:string	Partita IVA dell'ente o società controllante  nel caso di liquidazione di gruppo ultimo comma dell’art. 73,	formato alfanumerico	<0.1>	11
			1.2.1.5   <UltimoMese>					    xs:string	Ultime mese di controllo nel caso di interruzione della liquidazione di gruppo ultimo comma dell’art.73.	"Valori ammessi: [1] [2] [3] [4] [5] [6] [7] [8] [9] [10] [11] [13] [99]"	<0.1>	1 … 2
			1.2.1.6   <LiquidazioneGruppo>			    xs:string	Indica se la comunicazione si riferisce alla liquidazione di gruppo dell’ultimo comma dell’art. 73,	"Valori ammessi:[0] [1]"	<0.1>	1
			1.2.1.7   <CFDichiarante>					xs:string	Codice fiscale del dichiarante persona fisica che sottoscrive la Comunicazione	formato alfanumerico	<0.1>	16
			1.2.1.8   <CodiceCaricaDichiarante>			xs:string	Codice di carica del dichiarante	formato numerico	<0.1>	1 … 2
			1.2.1.9   <CodiceFiscaleSocieta>			xs:string	Codice fiscale della società dichiarante 	formato alfanumerico	<0.1>	11
			1.2.1.10  <FirmaDichiarazione>			    xs:string	Indica la presenza della firma del contribuente o di chi ne ha la rappresentanza legale o negoziale	"Valori ammessi:[0] [1]"	<1.1>	1
			1.2.1.11  <CFIntermediario>					xs:string	Codice fiscale dell'incaricato alla trasmissione	formato alfanumerico	<0.1>	16
			1.2.1.12  <ImpegnoPresentazione>			xs:string	Tipo di impegno a trasmettere; vale 1 se la comunicazione è stata predisposta dal contribuente, o   2  se è stata predisposta da chi effettua l'invio	"Valori ammessi:[1] [2]"	<0.1>	1
			1.2.1.13  <DataImpegno>					    xs:string	Data (giorno, mese e anno) di assunzione dell’impegno a trasmettere	formato ggmmaaaa	<0.1>	8
			1.2.1.14  <FirmaIntermediario>				xs:string	Indica la presenza della firma da parte dell'intermediario	"Valori ammessi:[0] [1]"	<0.1>	1
			1.2.1.15  <FlagConferma>					xs:string	Flag , la cui  valorizzazione a 1 indica presenza di anomalie nella comunicazione	"Valori ammessi:[0] [1]"	<0.1>	1
			1.2.1.16  <IdentificativoProdSoftware>		xs:string	Elemento a disposizione dei produttori di software	formato alfanumerico	<0.1>	1 … *
			*/
            //< iv:Fornitura xmlns:iv = "urn:www.agenziaentrate.gov.it:specificheTecniche:sco:ivp" xmlns: ds = "http://www.w3.org/2000/09/xmldsig#" >
            writer.WriteStartElement("iv:Comunicazione"); //apre <Comunicazione>
            writer.WriteAttributeString(null, "identificativo", null, "00001");
            writer.WriteStartElement("iv:Frontespizio");		//apre <Frontespizio>

            writer.WriteElementString("iv:CodiceFiscale", getAZ09(RFrontespizio["CodiceFiscale"]));
            writer.WriteElementString("iv:AnnoImposta", getAZ09(RFrontespizio["AnnoImposta"]));
            writer.WriteElementString("iv:PartitaIVA", getAZ09(RFrontespizio["PartitaIVA"]));

            // I seguenti dati non li scriviamo
            //writer.WriteElementString("PIVAControllante", getAZ09(RFrontespizio["PIVAControllante"]));
            //writer.WriteElementString("UltimoMese", getAZ09(RFrontespizio["UltimoMese"]));
            //writer.WriteElementString("LiquidazioneGruppo", getAZ09(RFrontespizio["LiquidazioneGruppo"]));
            writer.WriteElementString("iv:CFDichiarante", getAZ09(RIntestazione["CodiceFiscaleDichiarante"]));
            writer.WriteElementString("iv:CodiceCaricaDichiarante", getAZ09(RIntestazione["CodiceCarica"]));
            //writer.WriteElementString("CodiceFiscaleSocieta", getAZ09(RFrontespizio["CodiceFiscaleSocieta"]));
            writer.WriteElementString("iv:FirmaDichiarazione", getAZ09(1));
            //writer.WriteElementString("CFIntermediario", getAZ09(RFrontespizio["CFIntermediario"]));
            //writer.WriteElementString("ImpegnoPresentazione", getAZ09(RFrontespizio["CodiceDestinatario"]));
            //writer.WriteElementString("DataImpegno", format(RFrontespizio["DataImpegno"]));
            //writer.WriteElementString("FirmaIntermediario", getAZ09(1));
 
            //writer.WriteElementString("iv:FlagConferma", getAZ09(0)); i campi vuoti o nulli si possono omettere
            //writer.WriteElementString("IdentificativoProdSoftware", getAZ09(RFrontespizio["IdentificativoProdSoftware"]));
            writer.WriteEndElement();                    // chiude <Frontespizio>

            /*
				1.2.2   <DatiContabili>						Blocco relativo ai dati contabili della comunicazione IVA		<1.1>	
				1.2.2.1   <Modulo>							Blocco contenente i dati dei moduli della comunicazione trimestrale IVA. E' obbligatoria la presenza di almeno un modulo fino ad un massimo di cinque 		<1.5>	
				1.2.2.1.1   <Mese>							xs:string	Mese di riferimento della liquidazione IVA	"Valori ammessi:[1] [2] [3] [4] [5] [6] [7] [8] [9] [10] [11] [12]"	<0.1>	1 … 2
				1.2.2.1.2   <Trimestre>						xs:string	Trimestre di riferimento della liquidazione IVA	"Valori ammessi:[1] [2] [3] [4] [5]"	<0.1>	1
				1.2.2.1.3   <Subfornitura>					xs:string	Indica se il contribuente si è avvalso delle agevolazioni previste dall’art. 74, comma 5	"Valori ammessi:[0] [1]"	<0.1>	1
				1.2.2.1.4   <EventiEccezionali>				xs:string	Riservato ai soggetti chehanno fruito per il periodo di riferimento, agli effetti dell’IVA,delle agevolazioni fiscali	"Valori ammessi:[1] [9]"	<0.1>	1
				1.2.2.1.5   <TotaleOperazioniAttive>		xs:decimal	Ammontare complessivo delle cessioni/prestazioni al netto dell'IVA effettuate nel periodo di riferimento	formato numerico; i decimali vanno separati dall'intero con il carattere  ',' (virgola)	<0.1>	4 … 16
				1.2.2.1.6   <TotaleOperazioniPassive>		xs:decimal	Ammontare complessivo degli acquisti al netto dell'IVA effettuati nel periodo di riferimento	formato numerico; i decimali vanno separati dall'intero con il carattere  ',' (virgola)	<0.1>	4 … 16
				1.2.2.1.7   <IvaEsigibile>					xs:decimal	Ammontare IVA a debito relativo alle operazioni attive del periodo	formato numerico; i decimali vanno separati dall'intero con il carattere  ',' (virgola)	<0.1>	4 … 16
				1.2.2.1.8   <IvaDetratta>					xs:decimal	Ammontare IVA da portare in detrazione del periodo	formato numerico; i decimali vanno separati dall'intero con il carattere  ',' (virgola)	<0.1>	4 … 16
				1.2.2.1.9   <IvaDovuta>						xs:decimal	Vale  (IvaEsigibile - IvaDetratta) se positiva 	formato numerico; i decimali vanno separati dall'intero con il carattere  ',' (virgola)	<0.1>	4 … 16
				1.2.2.1.10  <IvaCredito>					xs:decimal	Vale  (IvaDetratta - IvaEsigibile) se positiva 	formato numerico; i decimali vanno separati dall'intero con il carattere  ',' (virgola)	<0.1>	4 … 16
				1.2.2.1.11  <DebitoPrecedente>				xs:decimal	Importo a debito non versato nel periodo precedente in quanto non superiore a 25,82 euro	formato numerico; i decimali vanno separati dall'intero con il carattere  ',' (virgola)	<0.1>	4 … 16
				1.2.2.1.12  <CreditoPeriodoPrecedente>		xs:decimal	Ammontare IVA a credito computata in detrazione, risultante dalle liquidazioni precedenti	formato numerico; i decimali vanno separati dall'intero con il carattere  ',' (virgola)	<0.1>	4 … 16
				1.2.2.1.13  <CreditoAnnoPrecedente>			xs:decimal	Ammontare IVA a credito compensabile che viene portato in detrazione e risultante dalla dichiarazione annuale dell'anno precedente	formato numerico; i decimali vanno separati dall'intero con il carattere  ',' (virgola)	<0.1>	4 … 16
				1.2.2.1.14  <VersamentiAutoUE>				xs:decimal	Ammontare complessivo dei versamenti relativi all'imposta dovuta per la prima cessione interna di autoveicoli	formato numerico; i decimali vanno separati dall'intero con il carattere  ',' (virgola)	<0.1>	4 … 16
				1.2.2.1.15  <CreditiImposta>				xs:decimal	Ammontare dei particolari crediti di imposta utilizzati nel periodo di riferimento a scomputo del versamento	formato numerico; i decimali vanno separati dall'intero con il carattere  ',' (virgola)	<0.1>	4 … 16
				1.2.2.1.16  <InteressiDovuti>				xs:decimal	Ammontare degli interessi dovuti relativamente alla liquidazione del trimestre	formato numerico; i decimali vanno separati dall'intero con il carattere  ',' (virgola)	<0.1>	4 … 16
				1.2.2.1.17  <Acconto>						xs:decimal	Amontare dell'acconto dovuto anche se non effettivamente versato 	formato numerico; i decimali vanno separati dall'intero con il carattere  ',' (virgola)	<0.1>	4 … 16
				1.2.2.1.18  <ImportoDaVersare>				xs:decimal	Vale (IvaDovuta - IvaCredito +  DebitoPrecedente + InteressiDovuti – CreditiImposta – CreditoPeriodoPrecedente – CreditoAnnoPrecedente - VersamentiAutoUE - Acconto)  se positivo	formato numerico; i decimali vanno separati dall'intero con il carattere  ',' (virgola)	<0.1>	4 … 16
				1.2.2.1.19  <ImportoACredito>				xs:decimal	Vale (IvaDovuta - IvaCredito +  DebitoPrecedente + InteressiDovuti – CreditiImposta – CreditoPeriodoPrecedente – CreditoAnnoPrecedente - VersamentiAautoUE - Acconto) se negativo senza segno	formato numerico; i decimali vanno separati dall'intero con il carattere  ',' (virgola)	<0.1>	4 … 16
			*/
            writer.WriteStartElement("iv:DatiContabili"); //Apre <DatiContabili>
            foreach (DataRow RMod in RModuli) {
                writer.WriteStartElement("iv:Modulo"); //Apre <Modulo>
                writer.WriteElementString("iv:NumeroModulo", getAZ09(RMod["Modulo"]));
                writer.WriteElementString("iv:Mese", getAZ09(RMod["Mese"]));
                //writer.WriteElementString("Trimestre", getAZ09(RMod["Trimestre"]));
                //writer.WriteElementString("Subfornitura", getAZ09(RMod["Subfornitura"]));
                //writer.WriteElementString("EventiEccezionali", getAZ09(RMod["EventiEccezionali"]));
                if (CfgFn.GetNoNullDecimal(RMod["TotaleOperazioniAttive"]) != 0)
                    writer.WriteElementString("iv:TotaleOperazioniAttive", format(RMod["TotaleOperazioniAttive"]));
                if (CfgFn.GetNoNullDecimal(RMod["TotaleOperazioniPassive"]) != 0)
                    writer.WriteElementString("iv:TotaleOperazioniPassive", format(RMod["TotaleOperazioniPassive"]));
                if (CfgFn.GetNoNullDecimal(RMod["IvaEsigibile"]) != 0)
                    writer.WriteElementString("iv:IvaEsigibile", format(RMod["IvaEsigibile"]));
                if (CfgFn.GetNoNullDecimal(RMod["IvaDetratta"]) != 0)
                    writer.WriteElementString("iv:IvaDetratta", format(RMod["IvaDetratta"]));
                if (CfgFn.GetNoNullDecimal(RMod["IvaDovuta"]) != 0)
                    writer.WriteElementString("iv:IvaDovuta", format(RMod["IvaDovuta"]));
                if (CfgFn.GetNoNullDecimal(RMod["IvaCredito"]) != 0)
                    writer.WriteElementString("iv:IvaCredito", format(RMod["IvaCredito"]));
                if (CfgFn.GetNoNullDecimal(RMod["DebitoPrecedente"]) != 0)
                    writer.WriteElementString("iv:DebitoPrecedente", format(RMod["DebitoPrecedente"]));
                if (CfgFn.GetNoNullDecimal(RMod["CreditoPeriodoPrecedente"]) != 0)
                    writer.WriteElementString("iv:CreditoPeriodoPrecedente", format(RMod["CreditoPeriodoPrecedente"]));
                if (CfgFn.GetNoNullDecimal(RMod["CreditoAnnoPrecedente"]) != 0)
                    writer.WriteElementString("iv:CreditoAnnoPrecedente", format(RMod["CreditoAnnoPrecedente"]));
                //writer.WriteElementString("VersamentiAutoUE", format(RMod["IVersamentiAutoUET"]));
                //writer.WriteElementString("CreditiImposta", format(RMod["VersamentiAutoUE"]));
                //writer.WriteElementString("InteressiDovuti", format(RMod["InteressiDovuti"]));
                if (RMod.Table.Columns.Contains("MetodoAcconto")) {
                    if (RMod["MetodoAcconto"].ToString() != "") {
                        writer.WriteElementString("iv:Metodo", getAZ09(RMod["MetodoAcconto"]));
                    }
                }

                if (RMod.Table.Columns.Contains("Acconto")) {
                    if (CfgFn.GetNoNullDecimal(RMod["Acconto"]) != 0)
                        writer.WriteElementString("iv:Acconto", format(RMod["Acconto"]));
                }

                if (CfgFn.GetNoNullDecimal(RMod["ImportoDaVersare"]) != 0)
                    writer.WriteElementString("iv:ImportoDaVersare", format(RMod["ImportoDaVersare"]));
                if (CfgFn.GetNoNullDecimal(RMod["ImportoACredito"]) != 0)
                    writer.WriteElementString("iv:ImportoACredito", format(RMod["ImportoACredito"]));
                writer.WriteEndElement();// chiude <Modulo>
            }

            writer.WriteEndElement();//		chiude <DatiContabili>
            writer.WriteEndElement();//			chiude <Comunicazione>
            writer.WriteEndElement();//				chiude <Fornitura>

            writer.Close();

            StreamWriter stw = new StreamWriter(NomeCompletoFileXML);
            stw.Write(sw.ToString());
            stw.Flush();
            stw.Close();
           

            string xmlString = sw.ToString();
            byte[] xml = new UTF8Encoding().GetBytes(xmlString);
         

            Meta.SaveFormData();
            MessageBox.Show("Creato il file " + NomeCompletoFileXML, "Avviso");
            //ValidaFile_conXSD();

            MessageBox.Show("Salvataggio eseguito.");
        }

       
        private void btnGenera_Click(object sender, EventArgs e) {
            generaFile();
        }

        private void ValidaFile_conXSD() {
            string fname = txtPercorso.Text.ToString();
            bool res = XML_XSD_Validator.Validate(fname, AppDomain.CurrentDomain.BaseDirectory + "fornituraIvp_2018_v1.xsd"); 
            if (!res) {
                QueryCreator.ShowError(this, "Errore nella validazione dell'xml",
                                XML_XSD_Validator.GetError());
            }
        }

      

        private void btnStampa_Click(object sender, EventArgs e) {
            generaModelloPdf();
        }

       private void generaModelloPdf () {
         if (!DatiValidi()) return;
            int esercizio = (int)HelpForm.GetObjectFromString(typeof(int),
                txtEsercizio.Text.ToString(), "x.y.year");
        object trimestre = cmbTrimestre.SelectedValue;

        DataSet Out = Conn.CallSP("exp_mod_liquidazioneperiva", new object[] { esercizio, trimestre }, false, 6000);
            if (Out == null) return;
            DataTable LiquidazioniIva = Out.Tables[0];
        HelpForm.SetDataGrid(gridLiquidazioni, LiquidazioniIva);
            if (LiquidazioniIva.Columns.Contains("message")) {
                MessageBox.Show("Il file non è stato generato");
                return;
            }
    string filterIntestazione = QHC.CmpEq("kind", "I");
    string filterFrontespizio = QHC.CmpEq("kind", "F");
    string filterModulo = QHC.CmpEq("kind", "VP");
    DataRow RIntestazione = LiquidazioniIva.First(filterIntestazione);
    DataRow RFrontespizio = LiquidazioniIva.First(filterFrontespizio);
            if (RIntestazione == null) {
                MessageBox.Show("Dati Intestazione Mancanti. La dichiarazione non sarà stampata");
                return;
            }
            if (RFrontespizio == null) {
                MessageBox.Show("Dati Frontespizio Mancanti. La dichiarazione non sarà stampata");
                return;
            }
            

            DataRow RModulo_1 = LiquidazioniIva.First(QHC.AppAnd(filterModulo, QHC.CmpEq("modulo", 1)));
            DataRow RModulo_2 = LiquidazioniIva.First(QHC.AppAnd(filterModulo, QHC.CmpEq("modulo", 2)));
            DataRow RModulo_3 = LiquidazioniIva.First(QHC.AppAnd(filterModulo, QHC.CmpEq("modulo", 3)));

            if (RModulo_1 == null) {
                MessageBox.Show("Dati primo mese assenti");
            }
            if (RModulo_2 == null) {
                MessageBox.Show("Dati secondo mese assenti");
            }
            if (RModulo_3 == null) {
                MessageBox.Show("Dati terzo mese assenti");
            }

           
            Application.DoEvents();
            Cursor.Current = Cursors.WaitCursor;

            string NomeFile = BuildNomeFile();
txtNomeFile.Text = NomeFile;
           

            try {

                Application.DoEvents();
                Cursor.Current = Cursors.WaitCursor;
                string nomeModello = "IVA_period_2018_mod_istr.pdf";
string[] fnames = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, nomeModello);
                if (fnames.Length == 0) {
                    MessageBox.Show(
                        "File " + nomeModello + " non trovato nella cartella " + AppDomain.CurrentDomain.BaseDirectory,
                        "Errore");
                }
                try {
                    string path = AppDomain.CurrentDomain.BaseDirectory + nomeModello;
PdfDocument document = PdfReader.Open(path, PdfDocumentOpenMode.Modify);
                    
                    if (document.AcroForm != null) {
                        var form = document.AcroForm;

                        if (form.Elements.ContainsKey("/NeedAppearances")) {
                            form.Elements["/NeedAppearances"] = new PdfBoolean(true);
                        }
                        else {
                            form.Elements.Add("/NeedAppearances", new PdfBoolean(true));
                        }

                        var items = new Dictionary<string, string>();
                        // I Intestazione F Frontespizio
                        // Attenzione deve esserci corrispondenza perfetta con i nomi usati nel modello
                        // (case sensitive)
                        items["CodiceFiscale"] = getAZ09(RFrontespizio["CodiceFiscale"]);
                        items["CodiceCaricaDichiarante"] = getAZ09(RIntestazione["CodiceCarica"]);
                        items["AnnoImposta"] = getAZ09(RFrontespizio["AnnoImposta"]);

                        items["PartitaIVA"] = getAZ09(RFrontespizio["PartitaIVA"]);
                        items["CFDichiarante"] = getAZ09(RIntestazione["CodiceFiscaleDichiarante"]);
                        items["FirmaDichiarazione"] = "X";

                    if (RModulo_1 != null) { 
                            items["CodiceFiscale_1"] = getAZ09(RFrontespizio["CodiceFiscale"]);
                            items["Modulo_1"] = getAZ09(RModulo_1["Modulo"]);
                            items["Mese_1"] = getAZ09(RModulo_1["Mese"]);


                            items["TotaleOperazioniAttive_1"] = format(RModulo_1["TotaleOperazioniAttive"]);
                            items["TotaleOperazioniPassive_1"] = format(RModulo_1["TotaleOperazioniPassive"]);
                            items["IvaEsigibile_1"] = format(RModulo_1["IvaEsigibile"]);
                            items["IvaDetratta_1"] = format(RModulo_1["IvaDetratta"]);
                            items["IvaDovuta_1"] = format(RModulo_1["IvaDovuta"]);
                            items["IvaCredito_1"] = format(RModulo_1["IvaCredito"]);
                            items["DebitoPrecedente_1"] = format(RModulo_1["DebitoPrecedente"]);
                            items["CreditoPeriodoPrecedente_1"] = format(RModulo_1["CreditoPeriodoPrecedente"]);
                            items["CreditoAnnoPrecedente_1"] = format(RModulo_1["CreditoAnnoPrecedente"]);
                            
                            items["Metodo_1"] = getAZ09(RModulo_1["MetodoAcconto"]);
                            items["Acconto_1"] = format(RModulo_1["Acconto"]);
                            items["ImportoDaVersare_1"] = format(RModulo_1["ImportoDaVersare"]);
                            items["ImportoACredito_1"] = format(RModulo_1["ImportoACredito"]);
                        }

                        if (RModulo_2 != null) {
                            items["CodiceFiscale_2"] = getAZ09(RFrontespizio["CodiceFiscale"]);
                            items["Modulo_2"] = getAZ09(RModulo_2["Modulo"]);
                            items["Mese_2"] = getAZ09(RModulo_2["Mese"]);

                            items["TotaleOperazioniAttive_2"] = format(RModulo_2["TotaleOperazioniAttive"]);
                            items["TotaleOperazioniPassive_2"] = format(RModulo_2["TotaleOperazioniPassive"]);
                            items["IvaEsigibile_2"] = format(RModulo_2["IvaEsigibile"]);
                            items["IvaDetratta_2"] = format(RModulo_2["IvaDetratta"]);
                            items["IvaDovuta_2"] = format(RModulo_2["IvaDovuta"]);
                            items["IvaCredito_2"] = format(RModulo_2["IvaCredito"]);
                            items["DebitoPrecedente_2"] = format(RModulo_2["DebitoPrecedente"]);
                            items["CreditoPeriodoPrecedente_2"] = format(RModulo_2["CreditoPeriodoPrecedente"]);
                            items["CreditoAnnoPrecedente_2"] = format(RModulo_2["CreditoAnnoPrecedente"]);
                            items["Metodo_2"] = getAZ09(RModulo_2["MetodoAcconto"]);
                            items["Acconto_2"] = format(RModulo_2["Acconto"]);
                            items["ImportoDaVersare_2"] = format(RModulo_2["ImportoDaVersare"]);
                            items["ImportoACredito_2"] = format(RModulo_2["ImportoACredito"]);
                        }

                        if (RModulo_3 != null) {
                            items["CodiceFiscale_3"] = getAZ09(RFrontespizio["CodiceFiscale"]);
                            items["Modulo_3"] = getAZ09(RModulo_3["Modulo"]);
                            items["Mese_3"] = getAZ09(RModulo_3["Mese"]);
                            items["TotaleOperazioniAttive_3"] = format(RModulo_3["TotaleOperazioniAttive"]);
                            items["TotaleOperazioniPassive_3"] = format(RModulo_3["TotaleOperazioniPassive"]);
                            items["IvaEsigibile_3"] = format(RModulo_3["IvaEsigibile"]);
                            items["IvaDetratta_3"] = format(RModulo_3["IvaDetratta"]);
                            items["IvaDovuta_3"] = format(RModulo_3["IvaDovuta"]);
                            items["IvaCredito_3"] = format(RModulo_3["IvaCredito"]);
                            items["DebitoPrecedente_3"] = format(RModulo_3["DebitoPrecedente"]);
                            items["CreditoPeriodoPrecedente_3"] = format(RModulo_3["CreditoPeriodoPrecedente"]);
                            items["CreditoAnnoPrecedente_3"] = format(RModulo_3["CreditoAnnoPrecedente"]);
                            items["Metodo_3"] = getAZ09(RModulo_3["MetodoAcconto"]);
                            items["Acconto_3"] = format(RModulo_3["Acconto"]);
                            items["ImportoDaVersare_3"] = format(RModulo_3["ImportoDaVersare"]);
                            items["ImportoACredito_3"] = format(RModulo_3["ImportoACredito"]);
                        }

                        foreach (var name in items.Keys) {
                            var field = document.AcroForm.Fields[name];
                            if (field != null) { // per non generare eccezione in caso di nomi errati
                                field.Value = new PdfString(items[name]);
                                field.ReadOnly = false;
                            }
                            else
                                MessageBox.Show("Errore nella scrittura del campo " + name);
                        }

                        stampaDocumento(document, NomeFile, null, null, null, null);

                    }
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Errore");
                    //do any cleanup and return
                    return;
                }

            }
            catch  {
                return;

            }}
        private void stampaDocumento(PdfDocument doc, string nomeFile, string cf, string progr, string modulo, string denominazione) {
            string invalid = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            //string nomeFile = denominazione + cf;
            foreach (char c in invalid) {
                nomeFile = nomeFile.Replace(c.ToString(), "");
            }
            txtPercorso.Text = "";
            faiScegliereCartella();
            if (txtPercorso.Text == "") {
                MessageBox.Show(this, "Occorre specificare la cartella in cui creare il file", "errore");
                return;
            }

            txtNomeFile.Text = nomeFile;
            string NomeCompletoFilePDF = Path.Combine(txtPercorso.Text, nomeFile+".pdf");
           
            txtPercorso.Text = NomeCompletoFilePDF;
           

            // string pathCompleto = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, NomeCompletoFilePDF);


            try {
                doc.Save(NomeCompletoFilePDF);
                MessageBox.Show("Salvataggio effettuato");
            }
            catch (Exception e) {
                QueryCreator.ShowError(this, "Errore salvando il file, probabilmente il file è già aperto.", e.ToString());
            }

            //Process p = new Process();
            //p.StartInfo.FileName = nomeFile;
            //p.Start();
        }

        private void btnValida_Click(object sender, EventArgs e) {
            ValidaFile_conXSD();
        }

        private void Excel_Click(object sender, EventArgs e, DataTable T) {
            if (T.Rows.Count == 0) {
                MessageBox.Show("Nessun elemento trovato");
                return;
            }
            exportclass.DataTableToExcel(T, true);
        }
        private void btnOpAttivePassive_Click(object sender, EventArgs e) {
            // Fatture commerciali o promiscue registrate nel periodo
            if (!DatiValidi()) return;
            int esercizio = (int)HelpForm.GetObjectFromString(typeof(int),
                txtEsercizio.Text.ToString(), "x.y.year");
            int trimestre = CfgFn.GetNoNullInt32(cmbTrimestre.SelectedValue);
            Button B = (Button)sender;
            object flagbuysell = DBNull.Value;
            if (B.Name == "btnOpAttive") flagbuysell = "V";
            else flagbuysell = "A";

            int meseinizio = 3*(trimestre - 1) + 1;
            int mesefine = 3 * (trimestre - 1) + 3;

            string filter = QHS.AppAnd(QHS.CmpEq("flagbuysell", flagbuysell), QHS.CmpEq("registerclass", flagbuysell),
               QHS.Between("month(adate)", meseinizio,mesefine), QHS.CmpEq("year(adate)", esercizio),
               // Filtro su tipo imposizione, tipi esclusi
               QHS.FieldNotInList("idivataxablekind", QHS.List(5, /*Fuori campo*/ 6  /*Escluse Articolo 15*/)),
               QHS.DoPar(QHS.AppOr(QHS.CmpEq("flagactivity",2)/*commerciale*/, QHS.CmpEq("flagactivity", 3)/*promiscua*/)));
             

            string sqlCmd = " SELECT  " +
                            " ivaregisterkind.registerclass AS 'Classe Registro', " +
                            " ivaregisterkind.description AS 'Registro', " +
                            " invoicedetailview.invoicekind as 'Tipo documento'," +
                            " invoicedetailview.yinv as 'Esercizio'," +
                            " invoicedetailview.ninv as 'Numero'," +
                            " invoicedetailview.rownum  as '#riga'," +
                            " CASE ivaregisterkind.flagactivity  WHEN 1 THEN 'Istituzionale' " +
                            " WHEN 2 THEN 'Commerciale' " +
                            " WHEN 3 THEN 'Promiscua' " +
                            " END as 'Attività', " +
                            " invoicedetailview.ivakind as 'Tipo IVA'," +
                            " registry as 'Anagrafica', " +
                            " month(adate) as 'Mese reg.'," +
                            " adate as 'Data reg.'," +
                            " invoicedetailview.description as 'Descrizione Fatt.'," +
                            " detaildescription as 'Descr. Dettaglio'," +
                            " flagbuysell as 'Vendite/Acquisto'," +
                            " flagvariation as 'Nota variaz.'," +
                            " CASE WHEN flagvariation = 'S' THEN - taxable_euro ELSE taxable_euro END as 'Imponibile'," +
                            " CASE WHEN flagvariation = 'S' THEN - tax ELSE tax END as 'Imposta'," +
                            " CASE WHEN flagvariation = 'S' THEN - unabatable ELSE unabatable END as 'Indetraibile'," +
                            " CASE WHEN flagvariation = 'S' THEN - rowtotal ELSE rowtotal END  as 'Totale Riga (IVA inclusa)'" +
                            " FROM  invoicedetailview  " +
                            " JOIN ivaregister " +
                            " ON ivaregister.idinvkind = invoicedetailview.idinvkind " +
                            " AND ivaregister.yinv = invoicedetailview.yinv " +
                            " AND ivaregister.ninv = invoicedetailview.ninv " +
                            " JOIN ivaregisterkind " +
                            " ON ivaregisterkind.idivaregisterkind = ivaregister.idivaregisterkind " +
                            " WHERE  " + filter +
                            " ORDER BY invoicedetailview.invoicekind, invoicedetailview.adate ";

            DataTable T = Conn.SQLRunner(sqlCmd);


            if (T != null) {
                Excel_Click(sender, e, T);
            }
        }

        private void btnIva_Click(object sender, EventArgs e) {
            if (!DatiValidi()) return;
            int esercizio = (int)HelpForm.GetObjectFromString(typeof(int),
                txtEsercizio.Text.ToString(), "x.y.year");
            object trimestre = cmbTrimestre.SelectedValue;
            Button B = (Button)sender;
            object exigible_or_deductble= DBNull.Value;
            if (B.Name == "btnIvaADebito") exigible_or_deductble = "E";
            else exigible_or_deductble = "D";

            DataSet Out = Conn.CallSP("exp_check_liq_iva", new object[] {  esercizio, trimestre, exigible_or_deductble }, false, 6000);
            if (Out == null) return;
            DataTable T = Out.Tables[0];
            if (T != null) {
                Excel_Click(sender, e, T);
            }

        }
    }
          
}
