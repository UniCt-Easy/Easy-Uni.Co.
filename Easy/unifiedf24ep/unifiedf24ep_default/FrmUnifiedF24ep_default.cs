
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
using metadatalibrary;
using funzioni_configurazione;
using SituazioneViewer;//SituazioneViewer
using System.IO;
using System.Globalization;

namespace unifiedf24ep_default {
    public partial class Frmunifiedf24ep_default : MetaDataForm {
        MetaData Meta;
        QueryHelper QHS;
        CQueryHelper QHC;
        CultureInfo cultureInfo = CultureInfo.GetCultureInfo(0x0410);

        public Frmunifiedf24ep_default() {
            InitializeComponent();
            string dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "f24ep/prog/temp");
            if (Directory.Exists(dir)) {
                saveFileDialog1.InitialDirectory = dir;
            }
        }

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHS = Meta.Conn.GetQueryHelper();
            QHC = new CQueryHelper();
            GetData.CacheTable(DS.tax);
            GetData.CacheTable(DS.license);
            string filterEsercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            GetData.SetStaticFilter(DS.unifiedf24ep, filterEsercizio);
            GetData.CacheTable(DS.config, filterEsercizio, null, false);
            bool IsAmministrazione = false;
            GetData.MarkToAddBlankRow(DS.monthname);
            GetData.Add_Blank_Row(DS.monthname);
            GetData.CacheTable(DS.monthname);
            GetData.SetSorting(DS.monthname, "code");

           
            if (Meta.GetSys("userdb") != null) {
                IsAmministrazione = (Meta.GetSys("userdb").ToString().ToLower() == "amministrazione");
            }
         
           
            Meta.CanSave = IsAmministrazione;
            Meta.CanInsert = IsAmministrazione;
            Meta.CanInsertCopy = IsAmministrazione;
            Meta.CanCancel = IsAmministrazione;
            btnGeneraF24.Enabled = IsAmministrazione;
           
        }

        public void MetaData_AfterClear () {
            txtTotaleAddebito.Text = "";
            txtDenominazione.Text = "";
            txtCodiceFiscale.Text = "";
            txtContoDiAddebito.Text = "";
            txtPercorso.Text = "";
            txtEmail.Text = "";
            btnCollegaDettagli.Enabled = false;
            btnSituazione.Enabled = false;
            cmbMese.Enabled = true;
        }

        public void MetaData_AfterFill() {
            txtCodiceFiscale.Text = DS.license.Rows[0]["cf"].ToString();
            txtDenominazione.Text = DS.license.Rows[0]["agency"].ToString();
            object iban = DS.config.Rows[0]["iban_f24"];
            txtContoDiAddebito.Text = CfgFn.normalizzaIBAN(iban.ToString().ToUpper());

            object email_f24 = DS.config.Rows[0]["email_f24"];
            txtContoDiAddebito.Text = CfgFn.normalizzaIBAN(iban.ToString().ToUpper());
            txtEmail.Text = email_f24.ToString();

            btnCollegaDettagli.Enabled = Meta.EditMode;
            btnSituazione.Enabled = Meta.EditMode;
            riempiCampiCalcolati();
            if (DS.unifiedtax.Select().Length > 0 || DS.unifiedtaxcorrige.Select().Length > 0 || DS.unifiedclawback.Select().Length > 0)
            {
                cmbMese.Enabled = false;
            }
            else {
                cmbMese.Enabled = true;
            }
        }

       private void btnGeneraF24_Click(object sender, EventArgs e) {
      
            if (DS.unifiedf24ep.Rows.Count == 0) {
                return;
            }
            if ((DS.unifiedtax.Rows.Count == 0) && (DS.unifiedtaxcorrige.Rows.Count == 0) && (DS.unifiedclawback.Rows.Count == 0) 
                 && DS.unifiedf24epsanction.Rows.Count == 0) {
                show(this, "Non ci sono dettagli ritenute da elaborare!");
                return;
            }
            PostData.RemoveFalseUpdates(DS);
            if (DS.HasChanges()) {
                show(this, "Per generare il file del modello f24EP occorre prima SALVARE");
                return;
            }
            DataRow Curr = DS.unifiedf24ep.Rows[0];
            
            DataTable t = Meta.Conn.CallSP("exp_unifiedf24ep", new object[] { Curr["idunifiedf24ep"] }).Tables[0];
            if (!t.Columns.Contains("importoadebito")) {// ERRORE
                SubF24 fErr = new SubF24(t);
                DialogResult drErr = fErr.ShowDialog();
            }
            else {
                DialogResult dr = saveFileDialog1.ShowDialog(this);
                if (dr == DialogResult.OK) {
                    txtPercorso.Text = saveFileDialog1.FileName;
                }
                else {
                    show(this, "Non è stato selezionato il percorso in cui memorizzare il file dell'F24");
                    return;
                }
                Stream stream = saveFileDialog1.OpenFile();
                StreamWriter sw = new StreamWriter(stream, Encoding.Default);

                int numeroDiRecordM = t.Select(QHC.CmpEq("tiporecord", "M")).Length;
                int numeroDiRecordV = t.Select(QHC.CmpEq("tiporecord", "V")).Length;

                DataRow[] Rec_M = t.Select(QHC.CmpEq("tiporecord", "M"));
             
                generaRecordA(sw);
                for (int numRecM = 0; numRecM <= numeroDiRecordM - 1; numRecM++)
                {
                    object cf_contributor = Rec_M[numRecM]["cf_contributor"];
                    string filter = QHC.AppAnd(QHC.CmpEq("tiporecord", "V"), QHC.CmpEq("cf_contributor", cf_contributor));
                    int numeroDiRecordVContribuente = (t.Select(filter).Length + 21) / 22;
                    DataRow[] Rec_V = t.Select(filter);

                    generaRecordM(sw, Rec_M[numRecM], Rec_V);

                    for (int numRecV = 1; numRecV <= numeroDiRecordVContribuente; numRecV++)
                    {
                        generaRecordV(sw, Rec_V, numRecV);
                    }

                }
                generaRecordZ(sw, numeroDiRecordV);
                sw.Close();
               
                txtDataGenerazione.Text = HelpForm.StringValue(Meta.GetSys("datacontabile"),
                    txtDataGenerazione.Tag.ToString(), DS.unifiedf24ep.Columns["adate"]);
                Curr["adate"] = Meta.GetSys("datacontabile");
                Meta.SaveFormData();
                show(this, "Dati salvati", "Ok");
            }
            Meta.SaveFormData();
        }

        private string getStringaDiLunghezzaN(object o, int n) {
            string stringa = o.ToString();
            return stringa.Length > n
                ? stringa.Substring(0, n)
                : stringa.PadRight(n);
        }

        private string formattaImporto(object importo) {
            int centesimi = (int)((decimal)importo * 100);
            return centesimi.ToString().PadLeft(15, '0');
        }

        private void generaRecordA(TextWriter tw) {
            tw.Write("A".PadRight(1+14));//Tipo record
            tw.Write("F24EP");//Codice fornitura
            tw.Write("14");//Codice fornitura
            string cf = getStringaDiLunghezzaN(txtCodiceFiscale.Text, 16);
            tw.Write(cf.PadRight(16+177));//Codice fiscale del fornitore
            string denominazione = getStringaDiLunghezzaN(txtDenominazione.Text, 60);
            tw.Write(denominazione.PadRight(60 + 164)+" ".PadRight(1 + 14 + 67));//Denominazione
            tw.Write("001");//Progressivo dell'invio telematico
            tw.Write("001".PadRight(103));//Numero totale degli invii telematici
            tw.Write("1".PadRight(1+1269));//Flag di Accettazione
            tw.Write("A\r\n");
        }

        private void generaRecordM(TextWriter tw, DataRow R, DataRow[] Rec_V)
        {
            tw.Write("M");//Tipo record
            string cf = getStringaDiLunghezzaN(txtCodiceFiscale.Text, 11);
            tw.Write(cf.PadRight(11 + 5));//Codice fiscale contribuente
            tw.Write("1".PadLeft(8,'0').PadRight(8+3+25+20+16));//Progressivo invio all'interno del flusso, non superiore a 999
            tw.Write("E".PadLeft(1 + 1).PadRight(1 + 1 + 426));
            string denominazione = getStringaDiLunghezzaN(txtDenominazione.Text, 55);

            if (R["declaration_on_behalf_of"].ToString() == "S")
            {
                string cf_contributor = R["cf_contributor"].ToString();
                // intervento sostitutivo
                tw.Write(denominazione.PadRight(55));
                tw.Write("14".PadRight(2));
                tw.Write(cf_contributor.PadRight(16 + 1177));
            }
            else
                tw.Write(denominazione.PadRight(55 + 1195));//Denominazione
            tw.Write("14");//Tipo titolare del conto
            tw.Write(cf);//Codice fiscale contribuente
            string iban = txtContoDiAddebito.Text;
            //15 Codice Paese 1781 2 AN Assume sempre il valore IT
            //16 Codice di Controllo 1783 2 NU Obbligatorio e coerente con le specifiche IBAN.
            //17 CIN 1785 1 AN Obbligatorio, deve essere una lettera maiuscola.
            //18 ABI 1786 5 NU Assume sempre il valore 01000 (Banca d'Italia)
            //19 CAB 1791 5 NU Assume sempre il valore 03245
            //20 Numero di conto 1796 12 AN Obbligatorio. Numero di conto definito in modo da individuare anche la tesoreria destinataria. Si veda la circolare n. 20 del 8/5/2007 della R.G.S.
            tw.Write(iban.PadRight(27));//Conto di addebito
            //string email = getStringaDiLunghezzaN(DS.license.Rows[0]["email"].ToString(), 61); ; //email del contribuente, da mettere
            string email = txtEmail.Text;
            tw.Write(" ");            //filler
            tw.Write(email.PadRight(60));
            tw.Write("EURO");//Valuta
            decimal _SaldoTotaleADebito = 0;

            for (int i = 0; i < Rec_V.Length; i++)
            {
                _SaldoTotaleADebito += CfgFn.GetNoNullDecimal(Rec_V[i]["importoadebito"])- CfgFn.GetNoNullDecimal(Rec_V[i]["importoacredito"]);
            }

            string saldoTotaleADebito = _SaldoTotaleADebito.ToString("n", cultureInfo.NumberFormat);
            if (saldoTotaleADebito.Length > 15) saldoTotaleADebito = saldoTotaleADebito.Replace(".", "");
            tw.Write(saldoTotaleADebito.PadRight(15));//Saldo totale a debito
            DateTime _DataDiVersamento = (DateTime)HelpForm.GetObjectFromString(
                typeof(DateTime), txtDataDiVersamento.Text, txtDataDiVersamento.Tag.ToString());
            string dataDiVersamento = _DataDiVersamento.ToString("dd-MM-yyyy", cultureInfo);
            tw.Write(dataDiVersamento);//Data di versamento
            tw.Write("A\r\n");
        }

        private void generaRecordV(TextWriter tw, DataRow[] t, int numRecV)
        {
            decimal importoADebito = 0;
            decimal importoACredito = 0;
            tw.Write("V");
            string cf = getStringaDiLunghezzaN(txtCodiceFiscale.Text, 16);//Codice fiscale contribuente
            tw.Write(cf);
            tw.Write("1".PadLeft(8, '0').PadRight(8 + 3 + 25 + 20 + 16));//Progressivo invio all'interno del flusso, non superiore a 999
            tw.Write("D");//TIPO MODELLO  (modello Enti Pubblici v. 2016)
            tw.Write("   ".PadRight(3)); //Codice ufficio finanziario 3 caratteri
            tw.Write("0".PadRight(11,'0')); //Codice Atto, se presente deve essere formalmente corretto
            tw.Write("   ".PadRight(18)); // Identificativo operazione
            int max = t.Length < numRecV * 22 ? t.Length : numRecV * 22;
            for (int i = (numRecV - 1) * 22; i < max; i++) 
            {
                DataRow r = t[i];
                tw.Write(r["tiporiga"].ToString());
                tw.Write(getStringaDiLunghezzaN(r["codicetributo"], 6));//Codice tributo/ Causale
                tw.Write(getStringaDiLunghezzaN(r["codice"], 5));//Significato dipendete da tipo riga
                tw.Write(getStringaDiLunghezzaN(r["estremi"], 17));//vedere specifiche
                tw.Write(getStringaDiLunghezzaN(r["riferimentoA"], 6));
                tw.Write(getStringaDiLunghezzaN(r["riferimentoB"], 6));

                //tw.Write(getStringaDiLunghezzaN(r["codiceente"], 4));//Codice ente
                //tw.Write(r["mesediriferimento"].ToString().PadLeft(4, '0'));//Rateazione/mese di riferimento
                //tw.Write(r["annodiriferimento"].ToString().PadLeft(4, '0').PadRight(4 + 13));//Anno riferimento
                tw.Write(formattaImporto(r["importoadebito"]));//Importo a debito
                importoADebito += (decimal)r["importoadebito"];
                tw.Write(formattaImporto(r["importoacredito"]));//Importo a credito
                importoACredito += (decimal)r["importoacredito"];
            }
            for (int i = max; i < numRecV * 22; i++) {
                tw.Write(' ');//tipo riga
                tw.Write("".PadRight(6));
                tw.Write("".PadRight(5));
                tw.Write("".PadRight(17));
                tw.Write("".PadRight(6));
                tw.Write("".PadRight(6));
                tw.Write("0".PadRight(15, '0'));
                tw.Write("0".PadRight(15, '0'));
            }
            tw.Write(" ".PadRight(58));
            tw.Write(formattaImporto(importoADebito).PadRight(15, '0'));//Importo a debito
            tw.Write(formattaImporto(importoACredito).PadRight(15, '0'));//Importo a credito
            tw.Write("P");//Segno saldo
            tw.Write(formattaImporto(importoADebito - importoACredito).ToString().PadLeft(15, '0').PadRight(15 + 4));//Saldo di Sezione
            tw.Write(formattaImporto(importoADebito - importoACredito));//Saldo finale modello F24 EP
            DateTime _DataDiVersamento = (DateTime)HelpForm.GetObjectFromString(
                typeof(DateTime), txtDataDiVersamento.Text, txtDataDiVersamento.Tag.ToString());
            string dataDiVersamento = _DataDiVersamento.ToString("ddMMyyyy", cultureInfo);
            tw.Write(dataDiVersamento.PadRight(8+82));//Data di versamento
            tw.Write("A\r\n");
        }

        private void generaRecordZ(TextWriter tw, int numeroDiRecordV) {
            tw.Write("Z".PadRight(1 + 14));//Tipo record
            tw.Write(numeroDiRecordV.ToString().PadLeft(9, '0'));//Numero record di tipo 'V'
            tw.Write("1".PadLeft(9, '0'));//Numero record di tipo 'M'
            tw.Write("A\r\n".PadLeft(1864 + 1 + 2));
        }

        
        private void btnCollegaDettagli_Click (object sender, EventArgs e) {
            // Determino le righe che possono essere inserite
            // nell'attuale modello F24EP unificato. Le ritenute devono avere il codice tributo valorizzato
            if (Meta.IsEmpty) return;
            DataRow Curr = DS.unifiedf24ep.Rows[0];
            string filterTax =  QHS.FieldIn("taxcode",DS.tax.Select(QHS.AppOr(QHS.IsNotNull("fiscaltaxcode"), QHS.IsNotNull("fiscaltaxcodecredit"))));
            //Leggo il mese della dichiarazione, deve essere valorizzato per effettuare la raccolta 
            string filterMonth;
            string filterYear;
            int nmonth;
            // saranno considerate le ritenute del periodo <= al mese della dichiarazione
            if (CfgFn.GetNoNullInt32(cmbMese.SelectedValue) > 0) {
                nmonth = CfgFn.GetNoNullInt32(cmbMese.SelectedValue);
            }
            else {
                show("Valorizzare il mese della dichiarazione","Attenzione");
                return;
            }
            if (nmonth == 1) {
                filterMonth = QHS.CmpLe("nmonth", 12);
                filterYear = QHS.CmpEq("ayear", CfgFn.GetNoNullInt32(Meta.GetSys("esercizio")) -1);
            }
            else {
                filterMonth =  QHS.CmpLe("nmonth",nmonth -1);
                filterYear = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            }


            string MyFilterClawbackSQL = QHS.AppAnd(QHS.IsNull("idunifiedf24ep"), filterMonth, filterYear);
            string MyFilterSQL = QHS.AppAnd(QHS.IsNull("idunifiedf24ep"),filterTax,filterMonth,filterYear);
            string MyFilterCafDocumentSQL = QHS.AppAnd(QHS.IsNull("idunifiedf24ep"), filterMonth, filterYear);

            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.unifiedtax,
                null,
                MyFilterSQL,
                null, false);

            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.unifiedtaxcorrige,
               null,
               MyFilterSQL,
               null, false);

            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.unifiedclawback,
            null,
            MyFilterClawbackSQL,
            null, false);

            foreach (DataRow rDettaglioRitenuta in DS.unifiedtax.Select()) {
                rDettaglioRitenuta["idunifiedf24ep"] = Curr["idunifiedf24ep"];
            }

            foreach (DataRow rCorrezione in DS.unifiedtaxcorrige.Select()) {
                rCorrezione["idunifiedf24ep"] = Curr["idunifiedf24ep"];
            }

            foreach (DataRow rRecupero in DS.unifiedclawback.Select())
            {
                rRecupero["idunifiedf24ep"] = Curr["idunifiedf24ep"];
            }

           


            if (DS.unifiedtax.Select().Length > 0 || DS.unifiedtaxcorrige.Select().Length > 0 || DS.unifiedclawback.Select().Length > 0)
            {
                show(this, "Operazione completata", "Avviso");
                cmbMese.Enabled = false;
            }
            else
                show(this, "Non ci sono dettagli da collegare al modello", "Avviso");

            riempiCampiCalcolati();

        }


        private void riempiCampiCalcolati () {
            decimal amount = 0;
            decimal totEmploytax = 0;
            decimal totAdmintax = 0;
            decimal totEmployamount = 0;
            decimal totAdminamount = 0;


            decimal totClawback = 0;
            decimal sanctionAmount = 0;
            decimal totalAmount = 0;
            totEmploytax = MetaData.SumColumn(DS.unifiedtax, "employtax");
            totAdmintax = MetaData.SumColumn(DS.unifiedtax, "admintax");
            totEmployamount = MetaData.SumColumn(DS.unifiedtaxcorrige, "employamount");
            totAdminamount = MetaData.SumColumn(DS.unifiedtaxcorrige, "adminamount");
            amount = totEmploytax + totAdmintax + totEmployamount + totAdminamount;

            totClawback = MetaData.SumColumn(DS.unifiedclawback, "amount");

            DataSet MySanctionDS = (DataSet)gridSanzioni.DataSource;
            DataTable MySanctionTable = MySanctionDS.Tables[gridSanzioni.DataMember.ToString()];
            sanctionAmount = MetaData.SumColumn(MySanctionTable, "amount");
            totalAmount = amount + sanctionAmount + totClawback;
            txtTotaleAddebito.Text = HelpForm.StringValue(totalAmount, txtTotaleAddebito.Tag.ToString());
        }

        private void btnSituazione_Click (object sender, EventArgs e) {
            string idunifiedf24ep;
            DataAccess Conn = MetaData.GetConnection(this);
            try {
                DataRow MyRow = DS.unifiedf24ep.Rows[0];
                   //HelpForm.GetLastSelected(DS.unifiedf24ep);
                idunifiedf24ep = MyRow["idunifiedf24ep"].ToString();
            }
            catch {
                return;
            }
            DataSet Out = Meta.Conn.CallSP("show_unifiedf24ep",
                new Object[1] {idunifiedf24ep
							  }
                );
            if (Out == null) return;
            Out.Tables[0].TableName = "Situazione F24 Consolidato di Ateneo";
            frmSituazioneViewer View = new frmSituazioneViewer(Out);
            View.Show();
        }

        private void button1_Click(object sender, EventArgs e) {
            if (DS.unifiedf24ep.Rows.Count == 0) {
                return;
            }
            if ((DS.unifiedtax.Rows.Count == 0) && (DS.unifiedtaxcorrige.Rows.Count == 0) && (DS.unifiedclawback.Rows.Count == 0)
                 && DS.unifiedf24epsanction.Rows.Count == 0) {
                show(this, "Non ci sono dettagli ritenute da elaborare!");
                return;
            }
            PostData.RemoveFalseUpdates(DS);
            if (DS.HasChanges()) {
                show(this, "Per generare il file del modello f24EP occorre prima SALVARE");
                return;
            }

            DataRow Curr = DS.unifiedf24ep.Rows[0];
            DataTable t1 = Meta.Conn.CallSP("exp_unifiedf24ep_dati", new object[] { Curr["idunifiedf24ep"] }).Tables[0];
            // Codice per esportare in excel
            exportclass.DataTableToExcel(t1, true);
        }
    }
}
