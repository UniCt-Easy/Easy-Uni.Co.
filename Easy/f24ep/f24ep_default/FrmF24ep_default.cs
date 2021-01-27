
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
using System.IO;
using System.Globalization;

namespace f24ep_default {
    public partial class FrmF24ep_default : Form {
        MetaData Meta;
        QueryHelper QHS;
        CQueryHelper QHC;
        CultureInfo cultureInfo = CultureInfo.GetCultureInfo(0x0410);

        public FrmF24ep_default() {
            InitializeComponent();
            string dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "f24ep/prog/temp");
            if (Directory.Exists(dir)) {
                saveFileDialog1.InitialDirectory = dir;
            }
        }

        int esercizio;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHS = Meta.Conn.GetQueryHelper();
            QHC = new CQueryHelper();
            esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
            string filterEsercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            GetData.SetStaticFilter(DS.f24ep, filterEsercizio);
            GetData.CacheTable(DS.license);
            GetData.CacheTable(DS.config, filterEsercizio, null, false);
            GetData.MarkToAddBlankRow(DS.monthname);
            GetData.Add_Blank_Row(DS.monthname);
            GetData.CacheTable(DS.monthname);
            GetData.SetSorting(DS.monthname, "code");
        }

        public void MetaData_AfterClear () {
            txtTotaleAddebito.Text = "";
            txtDenominazione.Text = "";
            txtCodiceFiscale.Text = "";
            txtPercorso.Text = "";
            txtContoDiAddebito.Text = "";
            txtEmail.Text = "";
        }
        public void MetaData_AfterFill() {
            txtCodiceFiscale.Text = DS.license.Rows[0]["cf"].ToString();
            txtDenominazione.Text = DS.license.Rows[0]["agency"].ToString();
            object iban = DS.config.Rows[0]["iban_f24"];
            txtContoDiAddebito.Text = CfgFn.normalizzaIBAN(iban.ToString().ToUpper());

            object email_f24 = DS.config.Rows[0]["email_f24"];
            txtEmail.Text = email_f24.ToString();

            riempiCampiCalcolati();
        }

        private void riempiCampiCalcolati() {
            DateTime minDate = DateTime.MaxValue;
            DateTime maxDate = DateTime.MinValue;
            decimal amount = 0;
            decimal sanctionAmount = 0;
            decimal ivaAmount = 0;
            decimal ivaAmountCred = 0;
            decimal ivaAmountDeb = 0;
            decimal detailsAmount = 0;
            decimal totalAmount = 0;

            DataSet MyDS = (DataSet)gridLiquidazioni.DataSource;
            DataTable MyTable = MyDS.Tables[gridLiquidazioni.DataMember.ToString()];
            amount = MetaData.SumColumn(MyTable, "amount");

            DataSet MySanctionDS = (DataSet)gridSanzioni.DataSource;
            DataTable MySanctionTable = MySanctionDS.Tables[gridSanzioni.DataMember.ToString()];
            sanctionAmount = MetaData.SumColumn(MySanctionTable, "amount");
            totalAmount = amount + sanctionAmount;

            DataSet MyDetailsDS = (DataSet)GridDetails.DataSource;
            DataTable MyDetailsTable = MyDetailsDS.Tables[GridDetails.DataMember.ToString()];
            detailsAmount = MetaData.SumColumn(MyDetailsTable, "amount");
            totalAmount = amount + detailsAmount;

            // Considero la liquidazione iva
            DataSet MyivaDS = (DataSet)gridIVA.DataSource;
            DataTable MyivaTable = MyivaDS.Tables[gridIVA.DataMember.ToString()];
            ivaAmountCred = MetaData.SumColumn(MyivaTable, "totalcredit");
            ivaAmountDeb = MetaData.SumColumn(MyivaTable, "totaldebit");
            ivaAmount = ivaAmountDeb - ivaAmountCred;

            ivaAmountCred = MetaData.SumColumn(MyivaTable, "totalcredit12");
            ivaAmountDeb = MetaData.SumColumn(MyivaTable, "totaldebit12");
            ivaAmount = ivaAmount + (ivaAmountDeb - ivaAmountCred);

            ivaAmountDeb = MetaData.SumColumn(MyivaTable, "totaldebitsplit");
            ivaAmount = ivaAmount + ivaAmountDeb;

            totalAmount = amount + ivaAmount;

            // valorizza le date in base alle Liquidazioni presenti nel grid
            foreach (DataRow r in MyTable.Rows) {
               // amount += CfgFn.GetNoNullDecimal(r["amount"]);
                DateTime aDate = (DateTime)r["adate"];
                if (minDate > aDate) {
                    minDate = aDate;
                }
                if (maxDate < aDate) {
                    maxDate = aDate;
                }
            }

            //valorizza le date in base agli Interventi sostitutivi presenti nel grid, SE E SOLO SE non vi sono liquidazioni
            if (MyTable.Rows.Count == 0) {
                foreach (DataRow r in MyDetailsTable.Rows) {
                    if ((r["rifa_month"] == DBNull.Value) || (r["rifb_month"] == DBNull.Value))
                        continue; 
                    object giorno0101 = PrimoGiornoDelMese(r["rifa_month"], r["rifa_year"]);
                    object giorno3112 = UltimoGiornoDelMese(r["rifb_month"], r["rifb_year"]);
                    DateTime giorno0101Date = (DateTime)giorno0101;
                    DateTime giorno3112Date = (DateTime)giorno3112;
                    if (minDate > giorno0101Date) {
                        minDate = giorno0101Date;
                    }
                    if (maxDate < giorno3112Date) {
                        maxDate = giorno3112Date;
                    }
                }
            }

            txtTotaleAddebito.Text = HelpForm.StringValue(totalAmount, txtTotaleAddebito.Tag.ToString());
            if (minDate != DateTime.MaxValue) {
                txtDataPrimaLiquid.Text = HelpForm.StringValue(minDate, txtDataPrimaLiquid.Tag.ToString());
            }
            if (maxDate != DateTime.MinValue) {
                txtDataUltimaLiquid.Text = HelpForm.StringValue(maxDate, txtDataUltimaLiquid.Tag.ToString());
            }

        }

        object PrimoGiornoDelMese(object mese, object anno) {
            if((anno==DBNull.Value)||(anno==null))
                anno = Meta.GetSys("esercizio");
            int intMese = CfgFn.GetNoNullInt32(mese);
            int intAnno = CfgFn.GetNoNullInt32(anno);
            DateTime giorno0101 = new DateTime(intAnno, intMese, 1);
            return giorno0101;
        }

        object UltimoGiornoDelMese(object mese, object anno) {
            if ((anno == DBNull.Value) || (anno == null))
                anno = Meta.GetSys("esercizio");
            int intMese = CfgFn.GetNoNullInt32(mese);
            int intAnno = CfgFn.GetNoNullInt32(anno);
            int intGiorno = DateTime.DaysInMonth(intAnno, intMese);
            DateTime giorno3112 = new DateTime(intAnno, intMese, intGiorno);
            return giorno3112;
        }

        string GetFilterForLinking(QueryHelper QH) {
            int esercizio = (int)Meta.GetSys("esercizio");
            return QH.AppAnd(QH.IsNull("idf24ep"),
                QH.IsNotNull("fiscaltaxcode"),
                QH.Between("ytaxpay", esercizio - 1, esercizio));
        }

        string GetFilterForLinkingIVA(QueryHelper QH) {
            int esercizio = (int)Meta.GetSys("esercizio");
            return QH.AppAnd(QH.IsNull("idf24ep"),
                QH.Between("yivapay", esercizio - 1, esercizio));
        }

        string GetFilterForF24EPLinking(QueryHelper QH)
        {
            int esercizio = (int)Meta.GetSys("esercizio");

            DateTime dtPrimoDelMese= new DateTime(
            CfgFn.GetNoNullInt32(Meta.GetSys("esercizio")),
            ((DateTime)Meta.GetSys("datacontabile")).Month,
            1);

            DateTime dtPrimoDelMesePrec = dtPrimoDelMese.AddMonths(-1);


            return QH.AppAnd(QH.IsNull("idf24ep"),
                QH.IsNotNull("fiscaltaxcode"), QH.CmpEq("flagf24ep","S")
                , QH.Between("transmissiondate", dtPrimoDelMesePrec, Meta.GetSys("datacontabile"))
                );
        }

     

        private void btnInserisci_Click(object sender, EventArgs e) {
            if (MetaData.Empty(this)) return;
            MetaData.GetFormData(this, true);
            string MyFilter = GetFilterForLinking(QHS);
            string command = "choose.taxpayview.default." + MyFilter;
            MetaData.Choose(this, command);
            riempiCampiCalcolati();
        }

        private void btnRimuovi_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            Meta.GetFormData(true);
            MetaData.Unlink_Grid(gridLiquidazioni);
            riempiCampiCalcolati();
        }

        private void btnModifica_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            Meta.GetFormData(true);
            string MyFilter = GetFilterForLinking(QHC);
            string MyFilterSQL = GetFilterForLinking(QHS);
            Meta.MultipleLinkUnlinkRows("Composizione F24 EP",
                "Liquidazioni incluse nel modello F24 selezionato",
                "Liquidazioni non incluse in alcun modello F24",
                DS.taxpayview, MyFilter, MyFilterSQL, "default");
            riempiCampiCalcolati();
        }


        private void btnInserisciDetail_Click(object sender, EventArgs e)
        {
            if (MetaData.Empty(this)) return;
            MetaData.GetFormData(this, true);
            string MyFilter = GetFilterForF24EPLinking(QHS);
            string command = "choose.expenseclawbackview.dettagliocollegato." + MyFilter;
            MetaData.Choose(this, command);
            riempiCampiCalcolati();
        }

        private void btnRimuoviDetail_Click(object sender, EventArgs e)
        {
            if (Meta.IsEmpty) return;
            Meta.GetFormData(true);
            MetaData.Unlink_Grid(GridDetails);
            riempiCampiCalcolati();
        }

        private void btnModificaDetail_Click(object sender, EventArgs e)
        {
            if (Meta.IsEmpty) return;
            Meta.GetFormData(true);
            string MyFilter = GetFilterForF24EPLinking(QHC);
            string MyFilterSQL = GetFilterForF24EPLinking(QHS);
            Meta.MultipleLinkUnlinkRows("Composizione F24 EP",
                "Interventi Sostitutivi inclusi nel modello F24 selezionato",
                "Interventi Sostitutivi non inclusi in alcun modello F24",
                DS.expenseclawbackview, MyFilter, MyFilterSQL, "dettagliocollegato");
            riempiCampiCalcolati();
        }
        private void btnGeneraF24_Click(object sender, EventArgs e)
        {
            if (DS.f24ep.Rows.Count == 0)
            {
                return;
            }

            if ((DS.taxpayview.Rows.Count == 0) && (DS.expenseclawbackview.Rows.Count==0) && (DS.ivapay.Rows.Count==0))
            {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Non ci sono liquidazioni!");
                return;
            }

            if (!Meta.GetFormData(false)) return;
            PostData.RemoveFalseUpdates(DS);
            if (DS.HasChanges())
            {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Per generare il file del modello f24 occorre prima SALVARE");
                return;
            }
            DataRow Curr = DS.f24ep.Rows[0];
            DateTime dataDiVersamento = (DateTime)HelpForm.GetObjectFromString(
                typeof(DateTime), txtDataDiVersamento.Text, txtDataDiVersamento.Tag.ToString());
            if (dataDiVersamento < DateTime.Now.Date)
            {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Data di addebito: il valore immesso non può essere inferiore alla data corrente");
                HelpForm.FocusControl(txtDataDiVersamento);
                return;
            }
            DataTable t = Meta.Conn.CallSP("exp_f24ep", new object[] { Curr["idf24ep"] }).Tables[0];
           
            if (!t.Columns.Contains("importoadebito"))
            {// ERRORE
                SubF24 fErr = new SubF24(t);
                DialogResult drErr = fErr.ShowDialog();
            }
            else
            {
                DialogResult dr = saveFileDialog1.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    txtPercorso.Text = saveFileDialog1.FileName;
                }
                else
                {
                    MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Non è stato selezionato il percorso in cui memorizzare il file dell'F24");
                    return;
                }
                Stream stream = saveFileDialog1.OpenFile();
                StreamWriter sw = new StreamWriter(stream, Encoding.Default);

                int numeroDiRecordM = t.Select(QHC.CmpEq("tiporecord", "M")).Length;
                int numeroDiRecordV = t.Select(QHC.CmpEq("tiporecord", "V")).Length;

                DataRow[] Rec_M = t.Select(QHC.CmpEq("tiporecord", "M"));
                generaRecordA(sw);

                for (int numRecM = 0; numRecM <= numeroDiRecordM-1; numRecM++)
                {
                    object cf_contributor = Rec_M[numRecM]["cf_contributor"];
                    string filter = QHC.AppAnd(QHC.CmpEq("tiporecord", "V"), QHC.CmpEq("cf_contributor", cf_contributor));
                    int numeroDiRecordVContribuente = (t.Select(filter).Length+21)/22;

                    DataRow[] Rec_V = t.Select(filter);

                    generaRecordM(sw, Rec_M[numRecM], Rec_V);
                    for (int numRecV = 1; numRecV <= numeroDiRecordVContribuente; numRecV++)
                    {
                        generaRecordV(sw, Rec_V, numRecV);
                    }

                }
                generaRecordZ(sw, numeroDiRecordV);
                sw.Flush();
                sw.Close();

                txtDataGenerazione.Text = HelpForm.StringValue(Meta.GetSys("datacontabile"),
                txtDataGenerazione.Tag.ToString(), DS.f24ep.Columns["adate"]);
                Curr["adate"] = Meta.GetSys("datacontabile");
                Meta.SaveFormData();
            }
        }

        /// <summary>
        /// restituisce una stringa di lunghezza N aggiungendo eventuali spazi a destra
        /// </summary>
        /// <param name="o"></param>
        /// <param name="n"></param>
        /// <returns></returns>
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
            tw.Write("14");//Codice fornitura (persona non fisica)
            string cf = getStringaDiLunghezzaN(txtCodiceFiscale.Text, 16);
            tw.Write(cf.PadRight(16+177));//Codice fiscale del fornitore
            string denominazione = getStringaDiLunghezzaN(txtDenominazione.Text, 60);
            tw.Write(denominazione.PadRight(60 + 164)+" ".PadRight(1 + 14 + 67));//Denominazione
            tw.Write("001");//Progressivo dell'invio telematico
            tw.Write("001".PadRight(3+100));//Numero totale degli invii telematici (numero dei record di tipo M presenti nel Flusso)
            tw.Write("1".PadRight(1+1269));//Flag di Accettazione
            tw.Write("A\r\n");
        }

        private void generaRecordM(TextWriter tw, DataRow R, DataRow[] Rec_V) {
            tw.Write("M");//Tipo record
            string cf = getStringaDiLunghezzaN(txtCodiceFiscale.Text, 11);
            tw.Write(cf.PadRight(11 + 5));//Codice fiscale contribuente
            // il progressivo all'interno del flusso va cambiato
            tw.Write("1".PadLeft(8,'0').PadRight(8+3+25+20+16));//Progressivo invio all'interno del flusso, non superiore a 999
            tw.Write("E".PadLeft(1 + 1).PadRight(1 + 1 + 426));
            string denominazione = getStringaDiLunghezzaN(txtDenominazione.Text, 55);
            
            if (R["declaration_on_behalf_of"].ToString() == "S")
                {
                    string cf_contributor = R["cf_contributor"].ToString();
                    // intervento sostitutivo
                    tw.Write(denominazione.PadRight(55));
                    tw.Write("51".PadRight(2));
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
            //string email = getStringaDiLunghezzaN(DS.license.Rows[0]["email"].ToString(), 60); ; //email del contribuente, da mettere
            string email = txtEmail.Text;
            tw.Write(" ");//filler
            tw.Write(email.PadRight(60));
            tw.Write("EURO");//Valuta
            decimal _SaldoTotaleADebito = 0;

            for (int i = 0; i < Rec_V.Length; i++)
            {
                _SaldoTotaleADebito += CfgFn.GetNoNullDecimal(Rec_V[i]["importoadebito"]);
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

        private void generaRecordV(TextWriter tw, DataRow[] t, int numRecV) {
            decimal importoADebito = 0;
            decimal importoACredito = 0;
            tw.Write("V");
            string cf = getStringaDiLunghezzaN(txtCodiceFiscale.Text, 16);//Codice fiscale contribuente
            tw.Write(cf);
            tw.Write("1".PadLeft(8, '0').PadRight(8 + 3 + 25 + 20 + 16));//Progressivo invio all'interno del flusso, non superiore a 999
            if (esercizio < 2014) {
                tw.Write("7");//TIPO MODELLO  ( ERA 6)
            }
            else {
                tw.Write("D");//TIPO MODELLO  (modello Enti Pubblici v. 2016)
            }
            tw.Write("   ".PadRight(3)); //Codice ufficio finanziario 3 caratteri
            tw.Write("0".PadRight(11, '0')); //Codice Atto, se presente deve essere formalmente corretto
            tw.Write("   ".PadRight(18)); // Identificativo operazione
            int max = t.Length < numRecV * 22 ? t.Length : numRecV * 22;

            for (int i = (numRecV - 1) * 22; i < max; i++) {
                DataRow r = t[i];
                tw.Write(getStringaDiLunghezzaN(r["tiporiga"].ToString(),1));
                tw.Write(getStringaDiLunghezzaN(r["codicetributo"], 6));//Codice tributo/ Causale
                tw.Write(getStringaDiLunghezzaN(r["codice"], 5));//Significato dipendete da tipo riga
                tw.Write(getStringaDiLunghezzaN(r["estremi"], 17));//vedere specifiche
                tw.Write(getStringaDiLunghezzaN(r["riferimentoA"], 6));
                tw.Write(getStringaDiLunghezzaN(r["riferimentoB"], 6));
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
            if (esercizio < 2014) {
                tw.Write(" ".PadRight(70));
            }
            else {
                tw.Write(" ".PadRight(58));
            }
            tw.Write(formattaImporto(importoADebito).PadRight(15,'0'));//Importo a debito  
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

        private void button1_Click(object sender, EventArgs e) {
            /*StreamReader t24 = new StreamReader("C:\\Programmi\\F24EP\\prog\\temp\\prova.t24");
            StreamReader f24 = new StreamReader("C:\\Programmi\\F24EP\\F24\\prova.f24");
            string t = t24.ReadLine();
            string f = f24.ReadLine();
            for (int i = 0; i < t.Length; i++) {
                if ((i < 216) || (i > 259) && (i < 440) || (i > 453) && (i < 1673) || (i > 1673) && (i < 1711) || (i > 1719) && (i != 1786)) {
                    if (t[i] != f[i]) {
                        Console.WriteLine(i + " " + t[i] + " " + f[i]);
                    }
                }
            }
            t = t24.ReadLine();
            f = f24.ReadLine();
            for (int i = 0; i < t.Length; i++) {
                if ((i < 518) && (i > 561)) {
                    if (t[i] != f[i]) {
                        Console.WriteLine(i + " " + t[i] + " " + f[i]);
                    }
                }
            }
            for (int j = 2; j < 7; j++) {
                Console.WriteLine("RIGA " + j);
                t = t24.ReadLine();
                f = f24.ReadLine();
                for (int i = 0; i < t.Length; i++) {
                    if (t[i] != f[i]) {
                        Console.WriteLine(i + " '" + t[i] + "' '" + f[i]+"'");
                    }
                }
            }
            t24.Close();
            f24.Close();*/
        }

        private void button1_Click_1(object sender, EventArgs e) {
            if (DS.f24ep.Rows.Count == 0) {
             return;
            }
            if ((DS.taxpayview.Rows.Count == 0) && (DS.expenseclawbackview.Rows.Count == 0)) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Non ci sono liquidazioni!");
                return;
            }

            if (!Meta.GetFormData(false)) return;
            PostData.RemoveFalseUpdates(DS);
            if (DS.HasChanges()) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Per generare il file del modello f24 occorre prima SALVARE");
                return;
            }

            DataRow Curr = DS.f24ep.Rows[0];
            DataTable t1 = Meta.Conn.CallSP("exp_f24ep_dati", new object[] { Curr["idf24ep"] }).Tables[0];
            // Codice per esportare in excel
            exportclass.DataTableToExcel(t1, true);
        }

        private void button4_Click(object sender, EventArgs e) {
            if (MetaData.Empty(this)) return;
            MetaData.GetFormData(this, true);
            string MyFilter = GetFilterForLinkingIVA(QHS);
            string command = "choose.ivapay.default." + MyFilter;
            MetaData.Choose(this, command);
            riempiCampiCalcolati();
        }

        private void button2_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            Meta.GetFormData(true);
            MetaData.Unlink_Grid(gridIVA);
            riempiCampiCalcolati();
        }

        private void button3_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            Meta.GetFormData(true);
            string MyFilter = GetFilterForLinkingIVA(QHC);
            string MyFilterSQL = GetFilterForLinkingIVA(QHS);
            Meta.MultipleLinkUnlinkRows("Composizione F24 EP",
                "Liquidazioni IVA incluse nel modello F24 selezionato",
                "Liquidazioni IVA non incluse in alcun modello F24",
                DS.ivapay, MyFilter, MyFilterSQL, "default");
            riempiCampiCalcolati();
        }
    }
}
