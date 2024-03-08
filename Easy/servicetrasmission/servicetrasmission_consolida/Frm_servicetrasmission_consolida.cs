
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
using funzioni_configurazione;
using System.Xml;
using System.IO;
using System.Globalization;



namespace servicetrasmission_consolida{
    public partial class Frm_servicetrasmission_consolida : MetaDataForm {
        MetaData Meta;
        private XmlTextWriter writer;
        public DataTable tServiceRegistry ;
        public DataTable tServicePayment;
        
        public Frm_servicetrasmission_consolida()
        {
            InitializeComponent();
            saveFileDialog1.DefaultExt = "xml";
        }
        CQueryHelper QHC;
        QueryHelper QHS;

        public void MetaData_AfterLink(){
            bool IsAmministrazione = false;
            Meta = MetaData.GetMetaData(this);
            Meta.CanSave = false;
            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
            Meta.CanCancel = false;
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            if (Meta.GetSys("userdb") != null){
                IsAmministrazione = (Meta.GetSys("userdb").ToString().ToLower() == "amministrazione");
            }
//            txtEsercizio.Text = Meta.GetSys("esercizio").ToString();
            txtEsercizio.Enabled = false;
            //btnConsolidaConsulenti.Enabled = IsAmministrazione;
            //btnConsolidaDipendenti.Enabled = IsAmministrazione;
        }

        private void btnConsolida_Click(object sender, EventArgs e){
            if ((chkyear.Checked) && (txtEsercizio.Text == "")){
                show(this, "indicare l'Esercizio");
                return;
            }
            GeneraFile("c");
        }

        private void btnConsolidaDipendenti_Click(object sender, EventArgs e){
            if ((chkyear.Checked) && (txtEsercizio.Text == "")){
                show(this, "indicare l'Esercizio");
                return;
            }
            GeneraFile("d");
        }

        private DataTable chiamaSP(string sp, object[] parametri){
            DataSet ds = Meta.Conn.CallSP(sp, parametri);
            if ((ds == null) || (ds.Tables.Count == 0)){
                show(this, "Errore nella chiamata " + sp);
                return null;
            }
            return ds.Tables[0];
        }

        private string sostituiscivirgolaconpunto(decimal importo){
            string group = System.Globalization.NumberFormatInfo.CurrentInfo.NumberGroupSeparator;
            string dec = System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
            string s1 = importo.ToString("g").Replace(group, "");
            return s1.Replace(dec, ".");
        }

        void esportaPagamentoOLD(DataRow R, string tag, bool cancellapagamento){
            string filtrodipartimento;
            string filtropagamento;
            filtropagamento = QHC.MCmp(R, new string[] { "yservreg", "nservreg" });
            filtrodipartimento = QHC.CmpEq("iddbdepartment", R["iddbdepartment"]);

            filtropagamento = GetData.MergeFilters(filtropagamento, filtrodipartimento);
            if (R["employkind"].ToString().ToUpper() == "C"){
                foreach (DataRow Pag in tServicePayment.Select(filtropagamento, "semesterpay")){
                    writer.WriteStartElement(tag);
                    scriviXml(Pag,
                        new string[] { "anno", "semestre" },
                        new string[] { "ypay", "semesterpay" });
                        decimal payedamount = (CfgFn.GetNoNullDecimal(Pag["payedamount"]));
                        writer.WriteAttributeString("importo", sostituiscivirgolaconpunto(payedamount));
                    writer.WriteEndElement();
                }
            }
            else// se è un dipendete non deve scrivere il semestre
            {
                foreach (DataRow Pag in tServicePayment.Select(filtropagamento, "semesterpay"))
                {
                    writer.WriteStartElement(tag);
                    writer.WriteAttributeString("anno", Pag["ypay"].ToString());
                    if (!cancellapagamento)
                    {
                        decimal payedamount = (CfgFn.GetNoNullDecimal(Pag["payedamount"]));
                        writer.WriteAttributeString("importo", sostituiscivirgolaconpunto(payedamount));
                    }
                    writer.WriteEndElement();
                }
            }
        }

        private void scriviXml(DataRow row, string[] col, string[] sourcecol)
        {
            for (int i = 0; i < col.Length; i++)
            {
                string c = col[i];
                string source = sourcecol[i];
                if (!(row[source] is DBNull))
                {
                    if (row[source] is DateTime)
                    {
                        //lavora i DateTime
                        DateTime d = (DateTime)row[source];
                        writer.WriteAttributeString(c.ToString(), d.ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        if (row[source] is Decimal)
                        {
                            // Lavora i decimali
                            decimal amount = CfgFn.GetNoNullDecimal(row[source]);
                            writer.WriteAttributeString(c.ToString(), sostituiscivirgolaconpunto(amount));
                        }
                        else
                        {
                            //Tutto il resto
                            writer.WriteAttributeString(c, row[source].ToString());
                        }

                    }
                }
            }
        }
        


        int Semestre(DateTime Data){
            int mese = Data.Month;
            if (mese <= 6){
                return 1;
            }
            else{
                return 2;
            }
        }

        private void GeneraFile(object tipo){
            object AnnoRiferimento;
            object SemestreRiferimento = DBNull.Value;

            if (chkyear.Checked){
                AnnoRiferimento = HelpForm.GetObjectFromString(typeof(int), txtEsercizio.Text.ToString(), "x.y.year");
            }
            else{
                if (tipo.ToString() == "D"){
                    AnnoRiferimento = Convert.ToInt32(Meta.Conn.GetSys("esercizio")) - 1;
                }
                else{
                    DateTime DataContabile = Convert.ToDateTime(Meta.GetSys("datacontabile"));
                    int SemestreContabile = Semestre(DataContabile);
                    if (SemestreContabile == 1){
                        AnnoRiferimento = Convert.ToInt32(Meta.Conn.GetSys("esercizio")) - 1; 
                        SemestreRiferimento = 2;
                    }
                    else{
                        AnnoRiferimento = Convert.ToInt32(Meta.Conn.GetSys("esercizio"));
                        SemestreRiferimento = 1;
                    }
                }
            }

            tServiceRegistry = chiamaSP("compute_serviceregistry", new object[] { AnnoRiferimento, SemestreRiferimento, tipo });
            tServicePayment = chiamaSP("compute_servicepayment", new object[] { AnnoRiferimento, tipo });



            if (tServiceRegistry.Rows.Count == 0){
                show(this, "Non ci sono Incarichi da trasmettere");
                if (tServicePayment.Rows.Count == 0){
                    show(this, "Non ci sono Pagamenti da trasmettere");
                    return;
                }
            }

            StringWriter sw = new StringWriter();
            writer = new XmlTextWriter(sw);
            writer.Formatting = Formatting.Indented;

            writer.WriteProcessingInstruction("xml", "version='1.0' encoding='UTF-8' standalone='yes' ");
            writer.WriteStartElement("comunicazione", "http://com.accenture.perla.it/anagrafeprestazioni_inserimentoincarichi");// Apre - COMUNICAZIONE

            writer.WriteStartElement("inserimentoIncarichi");       // Apre - INSERIMENTO INCARICHI
            DataTable serviceagency = DataAccess.RUN_SELECT(Meta.Conn, "serviceagency", "*", null, null, false);
            DataRow rServiceagency = serviceagency.Rows[0];
            writer.WriteAttributeString("codiceEnte", rServiceagency["pa_code"].ToString());
            writer.WriteAttributeString("annoRiferimento", AnnoRiferimento.ToString());

            if (tipo.ToString() == "c"){
                InsertConsulenti();
            }
            else{
                InsertDipendenti();
            }

            writer.WriteEndElement();//fine inserimentoIncarichi            // Chiude - INSERIMENTO INCARICHI

            writer.WriteEndElement();// Comunicazione           // Chiude - COMUNICAZIONE
            writer.Close();

            string xmlString = sw.ToString();
            if (txtNomeFile.Text == "") {
                DialogResult dialogResult = saveFileDialog1.ShowDialog(this);
                if (dialogResult == DialogResult.Cancel) return;
                txtNomeFile.Text = saveFileDialog1.FileName;
            }
            StreamWriter stw = new StreamWriter(saveFileDialog1.OpenFile());
            stw.Write(sw.ToString());
            stw.Close();
            show(this, "Operazione Eseguita", "");
        }

        private void InsertConsulenti(){
            string fieldvalue = "";
            // Genera il file xml solo per i CONSULENTI
            writer.WriteStartElement("nuoviIncarichi");             // Apre - NUOVI INCARICHI
            foreach (DataRow rConsulente in tServiceRegistry.Select(QHC.CmpEq("employkind", 'C'))){
                writer.WriteStartElement("consulente");                 // Apre - CONSULENTE
                writer.WriteAttributeString("idMittente", rConsulente["senderreporting"].ToString());

                writer.WriteStartElement("incaricato");         // Apre - INCARICATO
                if (rConsulente["idconsultingkind"].ToString() == "P1"){
                    //	personaFisica
                    writer.WriteStartElement("personaFisica");  // Apre - PERSONA FISICA
                    if (rConsulente["cf"] != DBNull.Value){
                        writer.WriteAttributeString("codiceFiscale", rConsulente["cf"].ToString());
                    }
                    if (rConsulente["p_iva"] != DBNull.Value){
                        writer.WriteAttributeString("partitaIva", rConsulente["p_iva"].ToString());
                    }

                    scriviXml(rConsulente, new string[] { "cognome", "nome" }, new string[] { "surname", "forename" });

                    fieldvalue = rConsulente["flagforeign"].ToString().ToUpper();
                    writer.WriteAttributeString("estero", (fieldvalue == "S" ? "Y" : "N"));
                    if (rConsulente["gender"] != DBNull.Value){
                        writer.WriteAttributeString("sesso", rConsulente["gender"].ToString());
                    }

                    if (rConsulente["birthdate"] != DBNull.Value){
                        DateTime d = (DateTime)rConsulente["birthdate"];
                        writer.WriteAttributeString("dataNascita", d.ToString("yyyy-MM-dd"));
                    }
                    writer.WriteEndElement();//	personaFisica       // Chiude - PERSONA FISICA
                }

                if (rConsulente["idconsultingkind"].ToString() != "P1"){
                    //	personaGiuridica			
                    writer.WriteStartElement("personaGiuridica"); // Apre - PERSONA GIURIDICA
                    if ((rConsulente["cf"] != DBNull.Value) && (rConsulente["cf"].ToString().Length == 11)){
                        writer.WriteAttributeString("codiceFiscale", rConsulente["cf"].ToString());
                    }
                    if (((rConsulente["cf"] == DBNull.Value)||(rConsulente["cf"].ToString().Length != 11))
                        && (rConsulente["p_iva"] != DBNull.Value)){
                        writer.WriteAttributeString("partitaIva", rConsulente["p_iva"].ToString());
                    }

                    writer.WriteAttributeString("denominazione", rConsulente["title"].ToString());

                    fieldvalue = rConsulente["flagforeign"].ToString().ToUpper();
                    if (fieldvalue == "S"){
                        writer.WriteAttributeString("estero", "Y");
                        writer.WriteAttributeString("tipologiaAzienda", rConsulente["idconsultingkind"].ToString());
                    }
                    else{
                        writer.WriteAttributeString("estero", "N");
                        writer.WriteAttributeString("tipologiaAzienda", rConsulente["idconsultingkind"].ToString());
                        writer.WriteAttributeString("codiceComuneSede", rConsulente["codcity"].ToString());
                    }

                    writer.WriteEndElement();//	personaGiuridica        // Chiude - PERSONA GIURIDICA
                }
                writer.WriteEndElement();//	incaricato          // Chiude - INCARICATO

                writer.WriteStartElement("incarico");   // Apre -  INCARICO
                if (CfgFn.GetNoNullInt32(rConsulente["yservreg"]) < 2011){
                    // Cambia il nome del campo attività economica: fino al 2010 è idfinancialactivity, dal 2011 diventa apfinancialactivitycode.
                    scriviXml(rConsulente,
                        new string[] {"semestreRiferimento", "modalitaAcquisizione","tipoRapporto",
                                     "attivitaEconomica","descrizioneIncarico"},
                        new string[] {"referencesemester", "idacquirekind","idapcontractkind",
                                     "idfinancialactivity","description"}
                        );
                }
                else{
                    scriviXml(rConsulente,
                        new string[] {"semestreRiferimento", "modalitaAcquisizione","tipoRapporto"},
                        new string[] {"referencesemester", "idacquirekind","idapcontractkind"}
                        );
                    string apfinancialactivitycode = Meta.Conn.DO_READ_VALUE("apfinancialactivity", QHS.CmpEq("idapfinancialactivity", rConsulente["idapfinancialactivity"]), "apfinancialactivitycode").ToString();
                    writer.WriteAttributeString("attivitaEconomica", apfinancialactivitycode);
                    writer.WriteAttributeString("descrizioneIncarico", rConsulente["description"].ToString());


                }
                fieldvalue = rConsulente["regulation"].ToString().ToUpper();
                writer.WriteAttributeString("riferimentoRegolamento", (fieldvalue == "S" ? "Y" : "N"));
                scriviXml(rConsulente,
                new string[] { "dataAffidamento", "dataInizio", "dataFine" },
                new string[] { "expectationsdate", "start", "stop" }
                );
                fieldvalue = rConsulente["payment"].ToString().ToUpper();
                writer.WriteAttributeString("incaricoSaldato", (fieldvalue == "S" ? "1" : "2"));

                decimal expectedamount = (CfgFn.GetNoNullDecimal(rConsulente["expectedamount"]));
                writer.WriteAttributeString("importo", sostituiscivirgolaconpunto(expectedamount));

                if (rConsulente["idreferencerule"] != DBNull.Value){
                    writer.WriteStartElement("riferimentoNormativo");       // Apre - RIFERIMENTO NORMATIVO
                    scriviXml(rConsulente,
                    new string[] { "riferimento", "data", "numero", "articolo", "comma" },
                    new string[] { "idreferencerule", "referencedate", "articlenumber", "article", "paragraph" }
                    );
                    writer.WriteEndElement();//riferimentoNormativo     // Chiude - RIFERIMENTO NORMATIVO
                }

                writer.WriteEndElement();//incarico             // Chiude - INCARICO
                //Esporto Nuovo Pagamento
                string filtropagamento = QHC.MCmp(rConsulente, new string[] { "yservreg", "nservreg" });
                string filtrodipartimento = QHC.CmpEq("iddbdepartment", rConsulente["iddbdepartment"]);
                filtropagamento = GetData.MergeFilters(filtropagamento, filtrodipartimento);

                if (tServicePayment.Select(filtropagamento, "semesterpay").Length > 0){
                    writer.WriteStartElement("pagamenti"); // Apre PAGAMENTI
                    esportaPagamento(rConsulente, "nuovoPagamento");
                    writer.WriteEndElement(); // Chiude PAGAMENTI
                }

                writer.WriteEndElement();//fine consulente              // Chiude - CONSULENTE
            }// Chiude foreach
            writer.WriteEndElement();//fine nuoviIncarichi          // Chiude - NUOVI INCARICHI
        }

        private void InsertDipendenti(){
            string fieldvalue = "";
            // Genera il file xml solo per i DIPENDENTI
            writer.WriteStartElement("nuoviIncarichi");             // Apre - NUOVI INCARICHI
            foreach (DataRow rDipendente in tServiceRegistry.Select(QHC.CmpEq("employkind", 'D'))){
                writer.WriteStartElement("dipendente");                 // Apre - DIPENDENTE
                writer.WriteAttributeString("idMittente", rDipendente["senderreporting"].ToString());

                writer.WriteStartElement("incaricato");         // Apre - INCARICATO
                scriviXml(rDipendente,
                    new string[] { "codiceFiscale", "cognome", "nome", "qualifica" },
                    new string[] { "cf", "surname", "forename", "idapmanager" }
                    );
                writer.WriteEndElement();        // Chiude - INCARICATO

                writer.WriteStartElement("conferente");         // Apre - CONFERENTE
                scriviXml(rDipendente,
                        new string[] { "tipologia", "codiceFiscale", "denominazione" },
                        new string[] { "idApregistrykind", "pa_cf", "pa_title" }
                        );
                writer.WriteStartElement("nuovaPersona");
                writer.WriteStartElement("personaGiuridica");         // Apre - personaGiuridica
                writer.WriteAttributeString("denominazione", rDipendente["pa_title"].ToString());
                writer.WriteAttributeString("estero", "N");
                writer.WriteAttributeString("tipologiaAzienda", rDipendente["idApregistrykind"].ToString());

                writer.WriteEndElement();  // Chiude - personaGiuridica
                writer.WriteEndElement();  // Chiude - nuovaPersona
                writer.WriteEndElement();        // Chiude - CONFERENTE


                writer.WriteStartElement("incarico");   // Apre -  INCARICO
                scriviXml(rDipendente,
                        new string[] { "tipologia", "dataAutorizzazione", "dataInizio", "dataFine" },
                        new string[] { "idapactivitykind", "authorizationdate", "start", "stop" }
                        );

                fieldvalue = rDipendente["officeduty"].ToString().ToUpper();
                writer.WriteAttributeString("doveriUfficio", (fieldvalue == "S" ? "7" : "8"));
                fieldvalue = rDipendente["payment"].ToString().ToUpper();
                writer.WriteAttributeString("incaricoSaldato", (fieldvalue == "S" ? "1" : "2"));
                decimal expectedamount = (CfgFn.GetNoNullDecimal(rDipendente["expectedamount"]));
                writer.WriteAttributeString("importo", sostituiscivirgolaconpunto(expectedamount));


                if (rDipendente["idreferencerule"] != DBNull.Value)
                {
                    writer.WriteStartElement("riferimentoNormativo");       // Apre - RIFERIMENTO NORMATIVO
                    scriviXml(rDipendente,
                    new string[] { "riferimento", "data", "numero", "articolo", "comma" },
                    new string[] { "idreferencerule", "referencedate", "articlenumber", "article", "paragraph" }
                    );
                    writer.WriteEndElement();//riferimentoNormativo     // Chiude - RIFERIMENTO NORMATIVO
                }

                writer.WriteEndElement();//incarico             // Chiude - INCARICO

                //Esporto Nuovo Pagamento
                string filtropagamento = QHC.MCmp(rDipendente, new string[] { "yservreg", "nservreg" });
                if (tServicePayment.Select(filtropagamento, "semesterpay").Length > 0)
                {
                    writer.WriteStartElement("pagamenti"); // Apre PAGAMENTI
                    esportaPagamento(rDipendente, "nuovoPagamento");
                    writer.WriteEndElement(); // Chiude PAGAMENTI
                }

                writer.WriteEndElement();              // Chiude - DIPENDENTE
                writer.WriteEndElement();             // Chiude - NUOVI INCARICHI
            }
        }

        void esportaPagamento(DataRow R, string tag){
            string filtrodipartimento;
            string filtropagamento;
            filtropagamento = QHC.MCmp(R, new string[] { "yservreg", "nservreg" });
            filtrodipartimento = QHC.CmpEq("iddbdepartment", R["iddbdepartment"]);
            filtropagamento = GetData.MergeFilters(filtropagamento, filtrodipartimento);
            if (R["employkind"].ToString().ToUpper() == "C"){
                foreach (DataRow Pag in tServicePayment.Select(filtropagamento, "semesterpay")){
                    writer.WriteStartElement(tag);
                    scriviXml(Pag,
                        new string[] { "anno", "semestre" },
                        new string[] { "ypay", "semesterpay" });
                        decimal payedamount = (CfgFn.GetNoNullDecimal(Pag["payedamount"]));
                        writer.WriteAttributeString("importo", sostituiscivirgolaconpunto(payedamount));
                    writer.WriteEndElement();
                }
            }
            else// se è un Dipendete non deve scrivere il semestre
            {
                foreach (DataRow Pag in tServicePayment.Select(filtropagamento, "semesterpay")){
                    writer.WriteStartElement(tag);
                    writer.WriteAttributeString("anno", Pag["ypay"].ToString());
                    decimal payedamount = (CfgFn.GetNoNullDecimal(Pag["payedamount"]));
                    writer.WriteAttributeString("importo", sostituiscivirgolaconpunto(payedamount));
                    writer.WriteEndElement();
                }
            }
        }


        
        private void txtEsercizio_Leave(object sender, EventArgs e)
        {
            HelpForm.FormatLikeYear(txtEsercizio);
        }

        private void btnSalvaFile_Click(object sender, EventArgs e){
            salvaFile();
        }

        void salvaFile(){
            DialogResult dialogResult = saveFileDialog1.ShowDialog(this);
            if (dialogResult == DialogResult.Cancel) return;
            txtNomeFile.Text = saveFileDialog1.FileName;
        }

        private void chkyear_CheckedChanged(object sender, EventArgs e){
            if (chkyear.Checked){
                txtEsercizio.Enabled = true;
            }
            else{
                txtEsercizio.Text = "";
                txtEsercizio.Enabled = false;
            }

        }

        private void ElaboraFileRitorno(XmlDocument document){
            // definizione file da creare
            SaveFileDialog _dlg = new SaveFileDialog();
            ISaveFileDialog dlg = createSaveFileDialog(_dlg);
            string filename = "";
            if (dlg.ShowDialog() == DialogResult.OK)
                filename = dlg.FileName;
            if (filename == "") return;
            StreamWriter sw = new StreamWriter(filename, false, System.Text.Encoding.GetEncoding(1252));

            XmlElement Comunicazione = document.DocumentElement;
            foreach (XmlElement esitoInserimentoIncarichi in Comunicazione.GetElementsByTagName("esitoInserimentoIncarichi"))
            {
                XmlAttribute esito = esitoInserimentoIncarichi.GetAttributeNode("esitoFile");
                if (esito == null)
                {
                    show("Controllare che il file selezionato sia quello di Risposta", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (esito.Value.ToString().ToUpper() == "KO")
                {
                    show(this, "Il file Trasmesso è ERRATO. Correggere i dati inseriti.");
                    //TrasmissioneApprovata(document);// riceve il file in input estrae gli id da NuovoIncarico e li scrive nel db
                    foreach (XmlElement esitoNuoviIncarichi in esitoInserimentoIncarichi.GetElementsByTagName("esitoNuoviIncarichi")){
                        if (esitoNuoviIncarichi.FirstChild.Name == "consulente"){
                            Decodifica("c", esitoNuoviIncarichi, sw);
                        }
                        if (esitoNuoviIncarichi.FirstChild.Name == "dipendente"){
                            Decodifica("d", esitoNuoviIncarichi, sw);
                        }
                    }
                }
            }
            sw.Close();
            show("File salvato in " + filename, "Informazioni", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
        }

        private string ScomponiIdMittende(string idMittente){
            // idMittente = Curr["yservreg"].ToString() + Curr["nservreg"].ToString().PadLeft(5, '0') + iddb.ToString().PadLeft(5, '0');
            // 20100107201981
            string eserc = idMittente.Substring(0,4);
            string num = idMittente.Substring(4,5);
            string iddb = idMittente.Substring(9, 5);

            DataTable tLicense = chiamaSP("compute_iddb", new object[] { iddb });
            if (tLicense.Rows.Count == 0)   return idMittente;
            string departmentname = tLicense.Rows[0]["departmentname"].ToString();
            return "Dip. " + departmentname + " Incarico N. " + num + " del "+ eserc;
        }

        private void Decodifica(string tipo, XmlElement esitoNuoviIncarichi, StreamWriter sw){
            string idMittente, esito;
            // Consulente
            if (tipo == "c"){
                foreach (XmlElement consulente in esitoNuoviIncarichi.GetElementsByTagName("consulente")){
                    esito = consulente.GetAttributeNode("esito").Value.ToString();
                    if (esito == "OK") continue;
                    idMittente = consulente.GetAttributeNode("idMittente").Value.ToString();
                    string idMittenteLeggibile = ScomponiIdMittende(idMittente);
                    foreach (XmlElement errori in consulente.GetElementsByTagName("errori")){
                        foreach (XmlElement incaricato in errori.GetElementsByTagName("incaricato"))
                        {
                            foreach (XmlElement personafisica in errori.GetElementsByTagName("personaFisica"))
                            {
                                if (personafisica.HasAttribute("codiceFiscale"))
                                {
                                    string codiceFiscale = personafisica.GetAttributeNode("codiceFiscale").Value.ToString();
                                    sw.WriteLine(idMittenteLeggibile + ":" + codiceFiscale);
                                }
                                if (personafisica.HasAttribute("cognome"))
                                {
                                    string cognome = personafisica.GetAttributeNode("cognome").Value.ToString();
                                    sw.WriteLine(idMittenteLeggibile + ":" + cognome);
                                }
                                if (personafisica.HasAttribute("nome"))
                                {
                                    string nome = personafisica.GetAttributeNode("nome").Value.ToString();
                                    sw.WriteLine(idMittenteLeggibile + ":" + nome);
                                }
                                if (personafisica.HasAttribute("estero"))
                                {
                                    string estero = personafisica.GetAttributeNode("estero").Value.ToString();
                                    sw.WriteLine(idMittenteLeggibile + ":" + estero);
                                }
                                if (personafisica.HasAttribute("partitaIva"))
                                {
                                    string partitaIva = personafisica.GetAttributeNode("partitaIva").Value.ToString();
                                    sw.WriteLine(idMittenteLeggibile + ":" + partitaIva);
                                }
                                if (personafisica.HasAttribute("denominazione"))
                                {
                                    string denominazione = personafisica.GetAttributeNode("denominazione").Value.ToString();
                                    sw.WriteLine(idMittenteLeggibile + ":" + denominazione);
                                }
                                if (personafisica.HasAttribute("tipologiaAzienda"))
                                {
                                    string tipologiaAzienda = personafisica.GetAttributeNode("tipologiaAzienda").Value.ToString();
                                    sw.WriteLine(idMittenteLeggibile + ":" + tipologiaAzienda);
                                }
                                if (personafisica.HasAttribute("codiceComuneSede"))
                                {
                                    string codiceComuneSede = personafisica.GetAttributeNode("codiceComuneSede").Value.ToString();
                                    sw.WriteLine(idMittenteLeggibile + ":" + codiceComuneSede);
                                }
                            }

                        }
                        foreach (XmlElement incarico in errori.GetElementsByTagName("incarico"))
                        {
                            if (incarico.HasAttribute("incaricoSaldato")){
                                string incaricoSaldato = incarico.GetAttributeNode("incaricoSaldato").Value.ToString();
                                sw.WriteLine(idMittenteLeggibile + ":" + incaricoSaldato);
                            }
                            if (incarico.HasAttribute("dataInizio")){
                                string dataInizio = incarico.GetAttributeNode("dataInizio").Value.ToString();
                                sw.WriteLine(idMittenteLeggibile + ":" + dataInizio);
                            }
                            if (incarico.HasAttribute("semestreRiferimento")){
                                string semestreRiferimento = incarico.GetAttributeNode("semestreRiferimento").Value.ToString();
                                sw.WriteLine(idMittenteLeggibile + ":" + semestreRiferimento );
                            }
                            if (incarico.HasAttribute("modalitaAcquisizione")){
                                string modalitaAcquisizione = incarico.GetAttributeNode("modalitaAcquisizione").Value.ToString();
                                sw.WriteLine(idMittenteLeggibile + ":" + modalitaAcquisizione);
                            }
                            if (incarico.HasAttribute("tipoRapporto")){
                                string tipoRapporto = incarico.GetAttributeNode("tipoRapporto").Value.ToString();
                                sw.WriteLine(idMittenteLeggibile + ":" + tipoRapporto);
                            }
                            if (incarico.HasAttribute("attivitaEconomica")){
                                string attivitaEconomica = incarico.GetAttributeNode("attivitaEconomica").Value.ToString();
                                sw.WriteLine(idMittenteLeggibile + ":" + attivitaEconomica);
                            }
                            if (incarico.HasAttribute("descrizioneIncarico")){
                                string descrizioneIncarico = incarico.GetAttributeNode("descrizioneIncarico").Value.ToString();
                                sw.WriteLine(idMittenteLeggibile + ":" + descrizioneIncarico);
                            }
                            if (incarico.HasAttribute("dataAffidamento")){
                                string dataAffidamento = incarico.GetAttributeNode("dataAffidamento").Value.ToString();
                                sw.WriteLine(idMittenteLeggibile + ":" + dataAffidamento);
                            }
                            if (incarico.HasAttribute("dataFine")){
                                string dataFine = incarico.GetAttributeNode("dataFine").Value.ToString();
                                sw.WriteLine(idMittenteLeggibile + ":" + dataFine);
                            }
                            if (incarico.HasAttribute("tipoImporto")){
                                string tipoImporto = incarico.GetAttributeNode("tipoImporto").Value.ToString();
                                sw.WriteLine(idMittenteLeggibile + ":" + tipoImporto);
                            }
                            if (incarico.HasAttribute("importo")){
                                string importo = incarico.GetAttributeNode("importo").Value.ToString();
                                sw.WriteLine(idMittenteLeggibile + ":" + importo);
                            }
                        }

                        foreach (XmlElement pagamenti in errori.GetElementsByTagName("pagamenti")){
                            if (pagamenti.HasAttribute("importo")){
                                string importo = pagamenti.GetAttributeNode("importo").Value.ToString();
                                sw.WriteLine(idMittenteLeggibile + ":" + importo);
                            }
                            if (pagamenti.HasAttribute("anno")){
                                string anno = pagamenti.GetAttributeNode("anno").Value.ToString();
                                sw.WriteLine(idMittenteLeggibile + ":" + anno);
                            }
                            if (pagamenti.HasAttribute("semestre")){
                                string semestre = pagamenti.GetAttributeNode("semestre").Value.ToString();
                                sw.WriteLine(idMittenteLeggibile + ":" + semestre);
                            }
                        }
                    }
                }
            }
            else{
                // Dipendenti
                foreach (XmlElement dipendente in esitoNuoviIncarichi.GetElementsByTagName("dipendente")){
                    esito = dipendente.GetAttributeNode("esito").Value.ToString();
                    if (esito == "OK") continue;
                    idMittente = dipendente.GetAttributeNode("idMittente").Value.ToString();
                    string idMittenteLeggibile = ScomponiIdMittende(idMittente);
                    foreach (XmlElement errori in dipendente.GetElementsByTagName("errori")){
                        foreach (XmlElement incaricato in errori.GetElementsByTagName("incaricato")){
                            if (incaricato.HasAttribute("codiceFiscale")){
                                string codiceFiscale = incaricato.GetAttributeNode("codiceFiscale").Value.ToString();
                                sw.WriteLine(idMittenteLeggibile + ":" + codiceFiscale);
                            }
                            if (incaricato.HasAttribute("cognome")){
                                string cognome = incaricato.GetAttributeNode("cognome").Value.ToString();
                                sw.WriteLine(idMittenteLeggibile + ":" + cognome);
                            }
                            if (incaricato.HasAttribute("nome")){
                                string nome = incaricato.GetAttributeNode("nome").Value.ToString();
                                sw.WriteLine(idMittenteLeggibile + ":" + nome);
                            }
                            if (incaricato.HasAttribute("qualifica")){
                                string qualifica = incaricato.GetAttributeNode("qualifica").Value.ToString();
                                sw.WriteLine(idMittenteLeggibile + ":" + qualifica);
                            }
                        }
                        foreach (XmlElement incaricato in errori.GetElementsByTagName("conferente")){
                            if (incaricato.HasAttribute("denominazione")){
                                string denominazione = incaricato.GetAttributeNode("denominazione").Value.ToString();
                                sw.WriteLine(idMittenteLeggibile + ":" + denominazione);
                            }
                            if (incaricato.HasAttribute("codiceFiscale")){
                                string codiceFiscale = incaricato.GetAttributeNode("codiceFiscale").Value.ToString();
                                sw.WriteLine(idMittenteLeggibile + ":" + codiceFiscale);
                            }

                            if (incaricato.HasAttribute("tipologia")){
                                string tipologia = incaricato.GetAttributeNode("tipologia").Value.ToString();
                                sw.WriteLine(idMittenteLeggibile + ":" + tipologia);
                            }

                            if (incaricato.HasAttribute("partitaIva")){
                                string partitaIva = incaricato.GetAttributeNode("partitaIva").Value.ToString();
                                sw.WriteLine(idMittenteLeggibile + ":" + partitaIva);
                            }
                            if (incaricato.HasAttribute("cognome")){
                                string cognome = incaricato.GetAttributeNode("cognome").Value.ToString();
                                sw.WriteLine(idMittenteLeggibile + ":" + cognome);
                            }
                            if (incaricato.HasAttribute("nome")){
                                string nome = incaricato.GetAttributeNode("nome").Value.ToString();
                                sw.WriteLine(idMittenteLeggibile + ":" + nome);
                            }

                            if (incaricato.HasAttribute("estero")){
                                string estero = incaricato.GetAttributeNode("estero").Value.ToString();
                                sw.WriteLine(idMittenteLeggibile + ":" + estero);
                            }

                            if (incaricato.HasAttribute("datanascita")){
                                string datanascita = incaricato.GetAttributeNode("datanascita").Value.ToString();
                                sw.WriteLine(idMittenteLeggibile + ":" + datanascita);
                            }
                            if (incaricato.HasAttribute("tipologiaAzienda")){
                                string tipologiaAzienda = incaricato.GetAttributeNode("tipologiaAzienda").Value.ToString();
                                sw.WriteLine(idMittenteLeggibile + ":" + tipologiaAzienda);
                            }
                            if (incaricato.HasAttribute("codiceComuneSede")){
                                string codiceComuneSede = incaricato.GetAttributeNode("codiceComuneSede").Value.ToString();
                                sw.WriteLine(idMittenteLeggibile + ":" + codiceComuneSede);
                            }
                        }
                        foreach (XmlElement incarico in errori.GetElementsByTagName("incarico"))
                        {
                            if (incarico.HasAttribute("tipologia")){
                                string tipologia = incarico.GetAttributeNode("tipologia").Value.ToString();
                                sw.WriteLine(idMittenteLeggibile + ":" + tipologia);
                            }
                            if (incarico.HasAttribute("dataAutorizzazione")){
                                string dataAutorizzazione = incarico.GetAttributeNode("dataAutorizzazione").Value.ToString();
                                sw.WriteLine(idMittenteLeggibile + ":" + dataAutorizzazione);

                            }
                            if (incarico.HasAttribute("dataInizio")){
                                string dataInizio = incarico.GetAttributeNode("dataInizio").Value.ToString();
                                sw.WriteLine(idMittenteLeggibile + ":" + dataInizio);
                            }
                            if (incarico.HasAttribute("dataFine")){
                                string dataFine = incarico.GetAttributeNode("dataFine").Value.ToString();
                                sw.WriteLine(idMittenteLeggibile + ":" + dataFine);
                            }
                            if (incarico.HasAttribute("doveriufficio")){
                                string doveriufficio = incarico.GetAttributeNode("doveriufficio").Value.ToString();
                                sw.WriteLine(idMittenteLeggibile + ":" + doveriufficio);
                            }
                            if (incarico.HasAttribute("incaricoSaldato")){
                                string incaricoSaldato = incarico.GetAttributeNode("incaricoSaldato").Value.ToString();
                                sw.WriteLine(idMittenteLeggibile + ":" + incaricoSaldato);
                            }
 
                            if (incarico.HasAttribute("tipoImporto")){
                                string tipoImporto = incarico.GetAttributeNode("tipoImporto").Value.ToString();
                                sw.WriteLine(idMittenteLeggibile + ":" + tipoImporto);
                            }
                            if (incarico.HasAttribute("importo")){
                                string importo = incarico.GetAttributeNode("importo").Value.ToString();
                                sw.WriteLine(idMittenteLeggibile + ":" + importo);
                            }
                        }

                        foreach (XmlElement pagamenti in errori.GetElementsByTagName("pagamenti")){
                            if (pagamenti.HasAttribute("importo")){
                                string importo = pagamenti.GetAttributeNode("importo").Value.ToString();
                                sw.WriteLine(idMittenteLeggibile + ":" + importo);
                            }
                            if (pagamenti.HasAttribute("anno")){
                                string anno = pagamenti.GetAttributeNode("anno").Value.ToString();
                                sw.WriteLine(idMittenteLeggibile + ":" + anno);
                            }
                        }

                        //riferimentoNormativo

                        foreach (XmlElement riferimentoNormativo in errori.GetElementsByTagName("riferimentoNormativo")){
                            if (riferimentoNormativo.HasAttribute("comma")){
                                string comma = riferimentoNormativo.GetAttributeNode("comma").Value.ToString();
                                sw.WriteLine(idMittenteLeggibile + ":" + comma);
                            }
                            if (riferimentoNormativo.HasAttribute("articolo")){
                                string articolo = riferimentoNormativo.GetAttributeNode("articolo").Value.ToString();
                                sw.WriteLine(idMittenteLeggibile + ":" + articolo);
                            }
                            if (riferimentoNormativo.HasAttribute("numero")){
                                string numero = riferimentoNormativo.GetAttributeNode("numero").Value.ToString();
                                sw.WriteLine(idMittenteLeggibile + ":" + numero);
                            }
                            if (riferimentoNormativo.HasAttribute("data")){
                                string data = riferimentoNormativo.GetAttributeNode("data").Value.ToString();
                                sw.WriteLine(idMittenteLeggibile + ":" + data);
                            }
                            if (riferimentoNormativo.HasAttribute("riferimento")){
                                string riferimento = riferimentoNormativo.GetAttributeNode("riferimento").Value.ToString();
                                sw.WriteLine(idMittenteLeggibile + ":" + riferimento);
                            }
                        }
                    }
                }
            }
        }


        private void button1_Click(object sender, EventArgs e){
            string messaggio = "";
            XmlDocument document = new XmlDocument();
            DialogResult dr = openFileDialog1.ShowDialog(this);
            if (dr != DialogResult.OK) return;
            txtNomeFile.Text = openFileDialog1.FileName;
            try
            {
                //runProcess(txtNomeFile.Text, true);// Consente di visualizzare il File
                document.Load(txtNomeFile.Text);
            }
            catch (Exception ex)
            {
                messaggio = "Non riesco ad aprire il file: " + txtNomeFile.Text +
                    "\nErrore: " + ex.Message;
                show(this, messaggio);
                return;
            }
            ElaboraFileRitorno(document);

        }
    }
}
