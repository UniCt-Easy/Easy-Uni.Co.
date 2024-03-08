
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
using System.IO;
using System.Globalization;
using System.Linq;
using CsvHelper;

namespace f24ordinario_default {
	public partial class Frm_f24ordinario_default :MetaDataForm {
		MetaData Meta;
		QueryHelper QHS;
		CQueryHelper QHC;
		CultureInfo cultureInfo = CultureInfo.GetCultureInfo(0x0410);
		
		public Frm_f24ordinario_default() {
			InitializeComponent();
			saveFileDialog1.DefaultExt = "T24";
			string dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "f24ordinario/prog/temp");
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
			GetData.SetStaticFilter(DS.f24ordinario, filterEsercizio);
			GetData.CacheTable(DS.license);
			GetData.CacheTable(DS.config, filterEsercizio, null, false);
			GetData.MarkToAddBlankRow(DS.monthname);
			GetData.Add_Blank_Row(DS.monthname);
			GetData.CacheTable(DS.monthname);
			GetData.CacheTable(DS.fiscaltaxregion);
			GetData.SetSorting(DS.monthname, "code");
		}

		public void MetaData_AfterClear() {
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

			// Considero la liquidazione Ritenute
			DataSet MyDS = (DataSet)gridLiquidazioni.DataSource;
			DataTable MyTable = MyDS.Tables[gridLiquidazioni.DataMember.ToString()];
			amount = MetaData.SumColumn(MyTable, "amount");

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
			// Considero gli inserimento manuali
			decimal ManualeAmount = 0;
			decimal ManualeAmountCred = 0;
			decimal ManualeAmountDeb = 0;

			DataSet MyManualeDS = (DataSet)dataGridManuale.DataSource;
			DataTable MyManualeTable = MyManualeDS.Tables[dataGridManuale.DataMember.ToString()];
			ManualeAmountCred = MetaData.SumColumn(MyManualeTable, "importoacredito");
			ManualeAmountDeb = MetaData.SumColumn(MyManualeTable, "importoadebito");
			ManualeAmount = ManualeAmountDeb - ManualeAmountCred;

			totalAmount = amount + ivaAmount + ManualeAmount;
			txtTotaleAddebito.Text = HelpForm.StringValue(totalAmount, txtTotaleAddebito.Tag.ToString());

			if (minDate != DateTime.MaxValue) {
				txtDataPrimaLiquid.Text = HelpForm.StringValue(minDate, txtDataPrimaLiquid.Tag.ToString());
			}
			if (maxDate != DateTime.MinValue) {
				txtDataUltimaLiquid.Text = HelpForm.StringValue(maxDate, txtDataUltimaLiquid.Tag.ToString());
			}

		}

		object PrimoGiornoDelMese(object mese, object anno) {
			if ((anno == DBNull.Value) || (anno == null))
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
			return QH.AppAnd(QH.IsNull("idf24ordinario"),
				QH.IsNotNull("fiscaltaxcode"),
				QH.Between("ytaxpay", esercizio - 1, esercizio));
		}

		string GetFilterForLinkingIVA(QueryHelper QH) {
			int esercizio = (int)Meta.GetSys("esercizio");
			return QH.AppAnd(QH.IsNull("idf24ordinario"),
				QH.Between("yivapay", esercizio - 1, esercizio));
		}

		string GetFilterForf24ordinarioLinking(QueryHelper QH) {
			int esercizio = (int)Meta.GetSys("esercizio");

			DateTime dtPrimoDelMese = new DateTime(
			CfgFn.GetNoNullInt32(Meta.GetSys("esercizio")),
			((DateTime)Meta.GetSys("datacontabile")).Month,
			1);

			DateTime dtPrimoDelMesePrec = dtPrimoDelMese.AddMonths(-1);


			return QH.AppAnd(QH.IsNull("idf24ordinario"),
				QH.IsNotNull("fiscaltaxcode"), QH.CmpEq("flagf24ordinario", "S")
				, QH.Between("transmissiondate", dtPrimoDelMesePrec, Meta.GetSys("datacontabile"))
				);
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
			tw.Write("A".PadRight(1 + 14));//Tipo record
			tw.Write("F24A0");//Codice fornitura
			tw.Write("14");//Codice fornitura (persona non fisica)
			string cf = getStringaDiLunghezzaN(txtCodiceFiscale.Text, 16);
			tw.Write(cf.PadRight(16));
			//Dati riservati al fornitore persona fisica
			tw.Write("".PadRight(172));
			tw.Write("0".PadRight(5, '0'));

			//Dati riservati al fornitore persona NON fisica
			string denominazione = getStringaDiLunghezzaN(txtDenominazione.Text, 60);
			denominazione = denominazione.Replace("'", " ");
			tw.Write(denominazione.PadRight(60));//Denominazione

			tw.Write("".PadRight(40 + 2 + 35));
			tw.Write("0".PadRight(5, '0'));
			object val = Meta.Conn.DO_READ_VALUE("geo_city", QHS.CmpEq("idcity", DS.license.Rows[0]["idcity"]), "title");
			tw.Write(val.ToString().PadRight(40));//Comune del domicilio fiscale
			string country = getStringaDiLunghezzaN(DS.license.Rows[0]["country"].ToString(),2);
			tw.Write(country.PadRight(2));//Sigla della provincia del domicilio fiscale

			string address1 = getStringaDiLunghezzaN(DS.license.Rows[0]["address1"].ToString(), 35);
			address1 = address1.Replace("'", " ");
			tw.Write(address1.PadRight(35));//Indirizzo del domicilio fiscale

			string cap = getStringaDiLunghezzaN(DS.license.Rows[0]["cap"].ToString(), 5);
			tw.Write(cap.PadRight(5)); // cap del domicilio fiscale
									   //Altre informazioni modelli F24
			tw.Write("".PadRight(1 + 14 + 12));
			string email = getStringaDiLunghezzaN(txtEmail.Text, 55);
			tw.Write(email.PadRight(55));
			//Dati dell'invio modelli F24
			tw.Write("001");//Progressivo dell'invio telematico
			tw.Write("001".PadRight(3 + 100));//Numero totale degli invii telematici (numero dei record di tipo M presenti nel Flusso)
			tw.Write("1".PadRight(1 + 1269));//Flag di Accettazione
			tw.Write("A\r\n");
		}

		private void generaRecordM(TextWriter tw, DataRow R, DataRow[] Rec_V) {
			tw.Write("M");//Tipo record
			string cf = getStringaDiLunghezzaN(txtCodiceFiscale.Text, 11);
			tw.Write(cf.PadRight(16));//Codice fiscale contribuente
									  // il progressivo all'interno del flusso va cambiato
			tw.Write("1".PadLeft(8, '0').PadRight(8 + 3 + 25 + 20 + 16));//Progressivo invio all'interno del flusso, non superiore a 999
			tw.Write("E".PadLeft(1 + 1).PadRight(1 + 1));
			//Dati di chi effettua il pagamento per altri -versante / firmatari
			tw.Write("".PadRight(1 + 1 + 16 + 1 + 24 + 20 + 1 + 8 + 40 + 2 + 40 + 2 + 5 + 35));
			//Residenza anagrafica del contribuente (facoltativa)


			object val = Meta.Conn.DO_READ_VALUE("geo_city", QHS.CmpEq("idcity", DS.license.Rows[0]["idcity"]), "title");
			tw.Write(val.ToString().PadRight(40));//Comune del domicilio fiscale
			string country = getStringaDiLunghezzaN(DS.license.Rows[0]["country"].ToString(), 2);
			tw.Write(country.PadRight(2));//Sigla della provincia del domicilio fiscale


			string cap = getStringaDiLunghezzaN(DS.license.Rows[0]["cap"].ToString(), 5);
			tw.Write(cap.PadRight(5)); // cap del domicilio fiscale

			string address1 = getStringaDiLunghezzaN(DS.license.Rows[0]["address1"].ToString(), 35);
			address1 = address1.Replace("'", " ");
			tw.Write(address1.PadRight(35));//Indirizzo del domicilio fiscale
			tw.Write("".PadRight(12 + 56));


			//Dati anagrafici del contribuente persona fisica
			tw.Write("".PadRight(24 + 20 + 8 + 1 + 25 + 2));
			string denominazione = getStringaDiLunghezzaN(txtDenominazione.Text, 55);

			if (R["declaration_on_behalf_of"].ToString() == "S") {
				string cf_contributor = R["cf_contributor"].ToString();
				// intervento sostitutivo
				tw.Write(denominazione.PadRight(55));
				tw.Write("".PadRight(2));
				tw.Write("".PadRight(16 + 1177));
			} else
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

			for (int i = 0; i < Rec_V.Length; i++) {
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
		/*
				string filterRigaF = QHC.AppAnd(QHC.CmpEq("tiporecord", "V"), QHC.CmpEq("tiporiga", "F"), QHC.CmpEq("cf_contributor", cf_contributor));
				int numeroDiRecordVRigaF = (t.Select(filterRigaF).Length + 5) / 6;
				string filterRigaI = QHC.AppAnd(QHC.CmpEq("tiporecord", "V"), QHC.CmpEq("tiporiga", "I"), QHC.CmpEq("cf_contributor", cf_contributor));
				int numeroDiRecordVRigaI = (t.Select(filterRigaI).Length + 3) / 4;
				string filterRigaR = QHC.AppAnd(QHC.CmpEq("tiporecord", "V"), QHC.CmpEq("tiporiga", "R"), QHC.CmpEq("cf_contributor", cf_contributor));
				int numeroDiRecordVRigaR = (t.Select(filterRigaR).Length + 3) / 4;
				string filterRigaS = QHC.AppAnd(QHC.CmpEq("tiporecord", "V"), QHC.CmpEq("tiporiga", "S"), QHC.CmpEq("cf_contributor", cf_contributor));
				int numeroDiRecordVRigaS = (t.Select(filterRigaR).Length + 3) / 4;
				string filterRigaN = QHC.AppAnd(QHC.CmpEq("tiporecord", "V"), QHC.CmpEq("tiporiga", "N"), QHC.CmpEq("cf_contributor", cf_contributor));
				int numeroDiRecordVRigaN = (t.Select(filterRigaR).Length + 2) / 3;
		*/
		private void generaRecordV(TextWriter tw, DataTable t, int numRecV) {
			// numRecV indice di record V
			decimal importoADebito = 0;
			decimal importoACredito = 0;
			decimal importoADebitoTot = 0;
			decimal importoACreditoTot = 0;
			tw.Write("V");
			string cf = getStringaDiLunghezzaN(txtCodiceFiscale.Text, 16);//Codice fiscale contribuente
			tw.Write(cf);
			tw.Write("1".PadLeft(8, '0').PadRight(8 + 3 + 25 + 20 + 16));//Progressivo invio all'interno del flusso, non superiore a 999
			tw.Write("A");//TIPO MODELLO
			tw.Write("".PadRight(3)); //Codice ufficio finanziario 3 caratteri
			tw.Write("0".PadRight(11, '0')); //Codice Atto, se presente deve essere formalmente corretto
											 //deve ciclare solo su quelli ERARIO
											 //Inserisce le prima 6

			// =====================================================================================
			//								TIPO RIGA F (ERARIO)
			// =====================================================================================
			
			string filterRigaF = QHC.AppAnd(QHC.CmpEq("tiporecord", "V"), QHC.CmpEq("tiporiga", "F"));
			DataRow[] tRigaF = t.Select(filterRigaF);
			
			// Ciclo per inserire sempre 6 elementi per riga
			for (int i = (numRecV - 1) * 6; i < numRecV * 6; i++)
			{
				// Verifico se ci sono elementi da inserire
				// Altrimenti inserisco elementi vuoti 
				if (i < tRigaF.Length)
				{
					DataRow r = tRigaF[i];
					tw.Write(getStringaDiLunghezzaN(r["codicetributo"], 4));//Codice tributo/ Causale
					tw.Write("".PadRight(16));//numero certificazione
					tw.Write(getStringaDiLunghezzaN(r["riferimentoA"], 4));//Rateazione/Regione/Provincia
					tw.Write(getStringaDiLunghezzaN(r["riferimentoB"], 4));//Anno di Riferimento
					tw.Write(formattaImporto(r["importoadebito"]));//Importo a debito
					importoADebito += (decimal)r["importoadebito"];
					tw.Write(formattaImporto(r["importoacredito"]));//Importo a credito
					importoACredito += (decimal)r["importoacredito"];
				}
				else
				{
					tw.Write("".PadRight(4));//codice tributo
					tw.Write("".PadRight(16));//numero certificazione
					tw.Write("".PadRight(4));//Rateazione/Regione/Provincia
					tw.Write("".PadRight(4));//Anno di Riferimento
					tw.Write("0".PadRight(15, '0'));
					tw.Write("0".PadRight(15, '0'));
				}
			}

			tw.Write(formattaImporto(importoADebito).PadRight(15, '0'));//Importo a debito  
			tw.Write(formattaImporto(importoACredito).PadRight(15, '0'));//Importo a credito
			tw.Write("P");//Segno saldo
			tw.Write(formattaImporto(importoADebito - importoACredito).ToString().PadLeft(15, '0').PadRight(15));//Saldo di Sezione
			importoADebitoTot += importoADebito;
			importoACreditoTot += importoACredito;
			importoADebito = 0; //AZZERO GLI IMPORTI
			importoACredito = 0;
			
			// =====================================================================================
			//								TIPO RIGA I (INPS)
			// =====================================================================================
			
			//Tutto di nuovo per la Sezione INPS(I): 4 righe + saldo
			string filterRigaI = QHC.AppAnd(QHC.CmpEq("tiporecord", "V"), QHC.CmpEq("tiporiga", "I"));
			DataRow[] tRigaI = t.Select(filterRigaI);
			
			// Ciclo per inserire sempre 4 elementi per riga			
			for (int i = (numRecV - 1) * 4; i < numRecV * 4; i++)
			{
				// Verifico se ci sono elementi da inserire
				// Altrimenti inserisco elementi vuoti 
				if (i < tRigaI.Length)
				{
					DataRow r = tRigaI[i];
					//tw.Write(getStringaDiLunghezzaN(r["codice"], 4));//Codice sede
					tw.Write(getStringaDiLunghezzaN(r["codicesedeINPS"], 4));//Codice sede INPS
					tw.Write(getStringaDiLunghezzaN(r["codicetributo"], 4));//Codice tributo/ Causale
					tw.Write(getStringaDiLunghezzaN(r["matricolaInpsF24"], 17)); // Matricola  INPS
					tw.Write(getStringaDiLunghezzaN(r["riferimentoA"], 6));
					tw.Write(getStringaDiLunghezzaN(r["riferimentoB"], 6));
					tw.Write(formattaImporto(r["importoadebito"]));//Importo a debito
					importoADebito += (decimal)r["importoadebito"];
					tw.Write(formattaImporto(r["importoacredito"]));//Importo a credito
					importoACredito += (decimal)r["importoacredito"];
				}
				else
				{
					tw.Write("0".PadRight(4, '0')); //codice sede
					tw.Write("".PadRight(4));//codice tributo
					tw.Write("".PadRight(17));
					tw.Write("0".PadRight(6, '0'));
					tw.Write("0".PadRight(6, '0'));
					tw.Write("0".PadRight(15, '0'));
					tw.Write("0".PadRight(15, '0'));
				}
			}

			tw.Write(formattaImporto(importoADebito).PadRight(15, '0'));//Importo a debito  
			tw.Write(formattaImporto(importoACredito).PadRight(15, '0'));//Importo a credito
			tw.Write("P");//Segno saldo
			tw.Write(formattaImporto(importoADebito - importoACredito).ToString().PadLeft(15, '0').PadRight(15));//Saldo di Sezione
			importoADebitoTot += importoADebito;
			importoACreditoTot += importoACredito;
			importoADebito = 0; //AZZERO GLI IMPORTI
			importoACredito = 0;

			// =====================================================================================
			//								TIPO RIGA R (REGIONI)
			// =====================================================================================
			
			//Tutto di nuovo per la Sezione Regioni(R) : 4 righe + saldo
			string filterRigaR = QHC.AppAnd(QHC.CmpEq("tiporecord", "V"), QHC.CmpEq("tiporiga", "R"));
			DataRow[] tRigaR = t.Select(filterRigaR);

			// Ciclo per inserire sempre 4 elementi per riga
			for (int i = (numRecV - 1) * 4; i < numRecV * 4; i++)
			{
				// Verifico se ci sono elementi da inserire
				// Altrimenti inserisco elementi vuoti 
				if (i < tRigaR.Length)
				{
					DataRow r = tRigaR[i];
					tw.Write(getStringaDiLunghezzaN(r["idfiscaltaxregion"], 2));//Significato dipendete da tipo riga
					tw.Write(getStringaDiLunghezzaN(r["codicetributo"], 4));//Codice tributo/ Causale
					tw.Write(getStringaDiLunghezzaN(r["riferimentoA"], 4));
					tw.Write(getStringaDiLunghezzaN(r["riferimentoB"], 4));
					tw.Write(formattaImporto(r["importoadebito"]));//Importo a debito
					importoADebito += (decimal)r["importoadebito"];
					tw.Write(formattaImporto(r["importoacredito"]));//Importo a credito
					importoACredito += (decimal)r["importoacredito"];
				}
				else
				{
					tw.Write("0".PadRight(2, '0'));
					tw.Write("".PadRight(4));//codice tributo
					tw.Write("".PadRight(4));
					tw.Write("0".PadRight(4, '0'));
					tw.Write("0".PadRight(15, '0'));
					tw.Write("0".PadRight(15, '0'));
				}
			}

			tw.Write(formattaImporto(importoADebito).PadRight(15, '0'));//Importo a debito  
			tw.Write(formattaImporto(importoACredito).PadRight(15, '0'));//Importo a credito
			tw.Write("P");//Segno saldo
			tw.Write(formattaImporto(importoADebito - importoACredito).ToString().PadLeft(15, '0').PadRight(15));//Saldo di Sezione
			importoADebitoTot += importoADebito;
			importoACreditoTot += importoACredito;
			importoADebito = 0; //AZZERO GLI IMPORTI
			importoACredito = 0;
			
			
			// =====================================================================================
			//								TIPO RIGA S (LOCALI)
			// =====================================================================================

			//Sezione IMU ed Altri Tributi Locali(S) 4
			string filterRigaS = QHC.AppAnd(QHC.CmpEq("tiporecord", "V"), QHC.CmpEq("tiporiga", "S"));
			DataRow[] tRigaS = t.Select(filterRigaS);
						
			tw.Write("".PadRight(18)); //Identificativo Operazione

			// Ciclo per inserire sempre 4 elementi per riga
			for (int i = (numRecV - 1) * 4; i < numRecV * 4; i++)
			{
				// Verifico se ci sono elementi da inserire
				// Altrimenti inserisco elementi vuoti 
				if (i < tRigaS.Length)
				{
					DataRow r = tRigaS[i];
					//tw.Write(getStringaDiLunghezzaN(r["identificativooperazione"], 18)); //Identificativo Operazione
					tw.Write(getStringaDiLunghezzaN(r["codiceente_provincia_comune"], 4));//Codice ente/prov/Comune
					tw.Write(r["ravvedimentooperoso"]); //Flag Ravvedimento Operos0
					tw.Write(r["immobilivariati"]); //Flag Immobili Variati
					tw.Write(r["acconto"]);//Flag Acconto
					tw.Write(r["saldo"]);//Flag Saldo
					tw.Write(r["numeroimmobili"]);//Numero Immobile     
					tw.Write(formattaImporto(r["detrazioneabitazione"])); //Detrazione abitazione principale
					tw.Write(getStringaDiLunghezzaN(r["codicetributo"], 4));//Codice tributo/ Causale
					tw.Write(getStringaDiLunghezzaN(r["riferimentoA"], 4));
					tw.Write(getStringaDiLunghezzaN(r["riferimentoB"], 4));
					tw.Write(formattaImporto(r["importoadebito"]));//Importo a debito
					importoADebito += (decimal)r["importoadebito"];
					tw.Write(formattaImporto(r["importoacredito"]));//Importo a credito
					importoACredito += (decimal)r["importoacredito"];
				}
				else
				{
					tw.Write("".PadRight(4));//Codice ente/prov/Comune
					tw.Write("0".PadRight(1, '0'));//Flag Ravvedimento Operoso
					tw.Write("0".PadRight(1, '0'));//Flag Immobili Variati
					tw.Write("0".PadRight(1, '0'));//Flag Acconto
					tw.Write("0".PadRight(1, '0'));//Flag Saldo
					tw.Write("0".PadRight(3, '0'));//Numero Immobile
					tw.Write("0".PadRight(15, '0'));//Detrazione abitazione principale
					tw.Write("".PadRight(4));//codice tributo
					tw.Write("".PadRight(4));//rateazione
					tw.Write("0".PadRight(4, '0'));//anno riferimento
					tw.Write("0".PadRight(15, '0'));
					tw.Write("0".PadRight(15, '0'));
				}
			}

			tw.Write(formattaImporto(importoADebito).PadRight(15, '0'));//Importo a debito  
			tw.Write(formattaImporto(importoACredito).PadRight(15, '0'));//Importo a credito
			tw.Write("P");//Segno saldo
			tw.Write(formattaImporto(importoADebito - importoACredito).ToString().PadLeft(15, '0').PadRight(15));//Saldo di Sezione
			importoADebitoTot += importoADebito;
			importoACreditoTot += importoACredito;
			importoADebito = 0; //AZZERO GLI IMPORTI
			importoACredito = 0;

			// =====================================================================================
			//								TIPO RIGA N (INAIL)
			// =====================================================================================
			
			//Tutto di nuovo per la Sezione INAIL(N) : 3 righe + saldo
			string filterRigaN = QHC.AppAnd(QHC.CmpEq("tiporecord", "V"), QHC.CmpEq("tiporiga", "N"));
			DataRow[] tRigaN = t.Select(filterRigaN);

			// Ciclo per inserire sempre 3 elementi per riga
			for (int i = (numRecV - 1) * 3; i < numRecV * 3; i++)
			{
				// Verifico se ci sono elementi da inserire
				// Altrimenti inserisco elementi vuoti
				if (i < tRigaN.Length)
				{
					DataRow r = tRigaN[i];
					tw.Write(r["codicesedeinail"]); //Codice sede INAIL
					tw.Write(r["codiceditta"]); //Codice ditta
					tw.Write(r["cc_codiceditta"]); //Codice controllo (c.c.) del Codice Ditta
					tw.Write(r["numerodiriferimento"]);//Numero di riferimento
					tw.Write(getStringaDiLunghezzaN(r["causaleinail"], 1));// Causale
					tw.Write(formattaImporto(r["importoadebito"]));//Importo a debito
					importoADebito += (decimal)r["importoadebito"];
					tw.Write(formattaImporto(r["importoacredito"]));//Importo a credito
					importoACredito += (decimal)r["importoacredito"];
				}
				else
				{
					tw.Write("8".PadRight(5, '0')); //Codice sede 
					tw.Write("0".PadRight(8, '0')); //Codice ditta
					tw.Write("0".PadRight(2, '0'));
					tw.Write("0".PadRight(6, '0'));//Numero di riferimento
					tw.Write("".PadRight(1));// Causale
					tw.Write("0".PadRight(15, '0'));
					tw.Write("0".PadRight(15, '0'));
				}
			}

			tw.Write(formattaImporto(importoADebito).PadRight(15, '0'));//Importo a debito  
			tw.Write(formattaImporto(importoACredito).PadRight(15, '0'));//Importo a credito
			tw.Write("P");//Segno saldo
			tw.Write(formattaImporto(importoADebito - importoACredito).ToString().PadLeft(15, '0').PadRight(15));//Saldo di Sezione
			importoADebitoTot += importoADebito;
			importoACreditoTot += importoACredito;
			importoADebito = 0; //AZZERO GLI IMPORTI
			importoACredito = 0;

			// =====================================================================================
			//								TIPO RIGA A (Altri Enti)
			// =====================================================================================
			
			//Sezione Altri Enti previdenziali ed assicurativi (A)
			string filterRigaA = QHC.AppAnd(QHC.CmpEq("tiporecord", "V"), QHC.CmpEq("tiporiga", "A"));
			DataRow[] tRigaA = t.Select(filterRigaA);

			// Ciclo per inserire sempre 2 elementi per riga
			for (int i = (numRecV - 1) * 2; i < numRecV * 2; i++)
			{
				// Verifico se ci sono elementi da inserire
				// Altrimenti inserisco elementi vuoti
				if (i < tRigaA.Length)
				{
					DataRow r = tRigaA[i];
					// se è il primo elemento della riga aggiungo il Codice altri enti previdenziali ed assicurativi
					if (i == ((numRecV - 1) * 2))
					{
						//va scritto solo una volta per sezione
						tw.Write(r["idaltrienti"].ToString().PadRight(4, '0')); //Codice altri enti previdenziali ed assicurativi
					}

					tw.Write(getStringaDiLunghezzaN(r["idcodicesedealtrienti"], 5)); //Codice sede 
					tw.Write(getStringaDiLunghezzaN(r["codicetributo"], 4));//Codice tributo/ Causale
					tw.Write(r["codiceposizione"]);//Codice Posizione
					tw.Write(getStringaDiLunghezzaN(r["riferimentoA"], 6));
					tw.Write(getStringaDiLunghezzaN(r["riferimentoB"], 6));
					tw.Write(formattaImporto(r["importoadebito"]));//Importo a debito
					importoADebito += (decimal)r["importoadebito"];
					tw.Write(formattaImporto(r["importoacredito"]));//Importo a credito
					importoACredito += (decimal)r["importoacredito"];
				}
				else
				{
					// se è il primo elemento della riga aggiungo il Codice altri enti previdenziali ed assicurativi
					if (i == ((numRecV - 1) * 2))
					{
						//va scritta una sezione A completamente vuota, introdotta da 
						//Codice altri enti previdenziali ed assicurativi, metto una stringa di quattro zeri
						tw.Write("0".PadRight(4, '0'));
					}

					tw.Write("".PadRight(5)); //Codice sede
					tw.Write("".PadRight(4)); //Codice tributo
					tw.Write("0".PadRight(9, '0')); //Codice posizione
					tw.Write("0".PadRight(6, '0'));//riferimento A
					tw.Write("0".PadRight(6, '0'));//riferimento B
					tw.Write("0".PadRight(15, '0'));// importo a debito
					tw.Write("0".PadRight(15, '0')); // importo a credito
				}
			}

			tw.Write(formattaImporto(importoADebito).PadRight(15, '0'));//Importo a debito  
			tw.Write(formattaImporto(importoACredito).PadRight(15, '0'));//Importo a credito
			tw.Write("P");//Segno saldo
			tw.Write(formattaImporto(importoADebito - importoACredito).ToString().PadLeft(15, '0').PadRight(15));//Saldo di Sezione
			importoADebitoTot += importoADebito;
			importoACreditoTot += importoACredito;
			importoADebito = 0; //AZZERO GLI IMPORTI
			importoACredito = 0;


			tw.Write(" ".PadRight(50));//Filler
									   //Saldo finale modello F24 EP: da calcolare sul totale!!!
			tw.Write(formattaImporto(importoADebitoTot - importoACreditoTot));
			DateTime _DataDiVersamento = (DateTime)HelpForm.GetObjectFromString(
				typeof(DateTime), txtDataDiVersamento.Text, txtDataDiVersamento.Tag.ToString());
			string dataDiVersamento = _DataDiVersamento.ToString("ddMMyyyy", cultureInfo);
			tw.Write(dataDiVersamento.PadRight(8 + 82));//Data di versamento
			tw.Write("A\r\n");
		}

		private void generaRecordZ(TextWriter tw, int numeroDiRecordV) {
			tw.Write("Z".PadRight(1 + 14));//Tipo record
			tw.Write(numeroDiRecordV.ToString().PadLeft(9, '0'));//Numero record di tipo 'V'
			tw.Write("1".PadLeft(9, '0'));//Numero record di tipo 'M'
			tw.Write("A\r\n".PadLeft(1864 + 1 + 2));
		}

		private void btnGeneraf24ordinario_Click(object sender, EventArgs e) {
			if (DS.f24ordinario.Rows.Count == 0) {
				return;
			}
			//TODO POST
			if ((DS.taxpayview.Rows.Count == 0)/* && (DS.expenseclawbackview.Rows.Count == 0)*/ && (DS.ivapay.Rows.Count == 0) && (DS.f24ordinariodetail.Rows.Count == 0)) {
				show(this, "Non ci sono liquidazioni!");
				return;
			}

			if (!Meta.GetFormData(false)) return;
			PostData.RemoveFalseUpdates(DS);
			if (DS.HasChanges()) {
				show(this, "Per generare il file del modello f24 occorre prima SALVARE");
				return;
			}
			DataRow Curr = DS.f24ordinario.Rows[0];
			DateTime dataDiVersamento = (DateTime)HelpForm.GetObjectFromString(
				typeof(DateTime), txtDataDiVersamento.Text, txtDataDiVersamento.Tag.ToString());
			if (dataDiVersamento < DateTime.Now.Date) {
				show("Data di addebito: il valore immesso non può essere inferiore alla data corrente");
				HelpForm.FocusControl(txtDataDiVersamento);
				return;
			}
			DataTable t = Meta.Conn.CallSP("exp_f24ordinario", new object[] { Curr["idf24ordinario"] }).Tables[0];

			if (!t.Columns.Contains("importoadebito")) {// ERRORE
				SubF24 fErr = new SubF24(t);
                createForm(fErr, null);
                DialogResult drErr = fErr.ShowDialog();
			} else {
				DialogResult dr = saveFileDialog1.ShowDialog(this);
				if (dr == DialogResult.OK) {
					txtPercorso.Text = saveFileDialog1.FileName;
				} else {
					show(this, "Non è stato selezionato il percorso in cui memorizzare il file dell'F24");
					return;
				}
				Stream stream = saveFileDialog1.OpenFile();
				StreamWriter sw = new StreamWriter(stream, Encoding.Default);

				int numeroDiRecordM = t.Select(QHC.CmpEq("tiporecord", "M")).Length;
				int numeroDiRecordV = t.Select(QHC.CmpEq("tiporecord", "V")).Length;

				DataRow[] Rec_M = t.Select(QHC.CmpEq("tiporecord", "M"));
				generaRecordA(sw);
				/*
    F: ERARIO 6
	I: INPS 4
	R: REGIONI 4
	S: ENTI LOCALI 4 
	N: INAIL 3
    A: ALTRIENTI 2
                 * */

				int maxRigaF = 6;
				int maxRigaI = 4;
				int maxRigaR = 4;
				int maxRigaS = 4;
				int maxRigaN = 3;
				int maxRigaA = 2;

				for (int numRecM = 0; numRecM <= numeroDiRecordM - 1; numRecM++) {
					object cf_contributor = Rec_M[numRecM]["cf_contributor"];

					// Calcolo il numero di righe necessarie per ogni tipo record
					string filterRigaF = QHC.AppAnd(QHC.CmpEq("tiporecord", "V"), QHC.CmpEq("tiporiga", "F"), QHC.CmpEq("cf_contributor", cf_contributor));
					int numeroDiRecordVRigaF = (int)Math.Ceiling((double)t.Select(filterRigaF).Length / maxRigaF);
					string filterRigaI = QHC.AppAnd(QHC.CmpEq("tiporecord", "V"), QHC.CmpEq("tiporiga", "I"), QHC.CmpEq("cf_contributor", cf_contributor));
					int numeroDiRecordVRigaI = (int)Math.Ceiling((double)t.Select(filterRigaI).Length / maxRigaI);
					string filterRigaR = QHC.AppAnd(QHC.CmpEq("tiporecord", "V"), QHC.CmpEq("tiporiga", "R"), QHC.CmpEq("cf_contributor", cf_contributor));
					int numeroDiRecordVRigaR = (int)Math.Ceiling((double)t.Select(filterRigaR).Length / maxRigaR);
					string filterRigaS = QHC.AppAnd(QHC.CmpEq("tiporecord", "V"), QHC.CmpEq("tiporiga", "S"), QHC.CmpEq("cf_contributor", cf_contributor));
					int numeroDiRecordVRigaS = (int)Math.Ceiling((double)t.Select(filterRigaS).Length / maxRigaS);
					string filterRigaN = QHC.AppAnd(QHC.CmpEq("tiporecord", "V"), QHC.CmpEq("tiporiga", "N"), QHC.CmpEq("cf_contributor", cf_contributor));
					int numeroDiRecordVRigaN = (int)Math.Ceiling((double)t.Select(filterRigaN).Length / maxRigaN);
					string filterRigaA = QHC.AppAnd(QHC.CmpEq("tiporecord", "V"), QHC.CmpEq("tiporiga", "A"), QHC.CmpEq("cf_contributor", cf_contributor));
					int numeroDiRecordVRigaA = (int)Math.Ceiling((double)t.Select(filterRigaA).Length / maxRigaA);

					// Prendo il massimo tra il numero righe necessarie dei vari tipi record
					int numeroDiRecordVContribuente =  new [] { numeroDiRecordVRigaF, numeroDiRecordVRigaI, numeroDiRecordVRigaR, numeroDiRecordVRigaS, numeroDiRecordVRigaN, numeroDiRecordVRigaA }.Max();
					string filter = QHC.AppAnd(QHC.CmpEq("tiporecord", "V"), QHC.CmpEq("cf_contributor", cf_contributor));
					DataRow[] Rec_V = t.Select(filter);

					generaRecordM(sw, Rec_M[numRecM], Rec_V);
					for (int numRecV = 1; numRecV <= numeroDiRecordVContribuente; numRecV++) {
						//generaRecordV(sw, Rec_V, numRecV);
						generaRecordV(sw, t, numRecV);
					}

				}
				generaRecordZ(sw, numeroDiRecordV);
				sw.Flush();
				sw.Close();

				txtDataGenerazione.Text = HelpForm.StringValue(Meta.GetSys("datacontabile"),
				txtDataGenerazione.Tag.ToString(), DS.f24ordinario.Columns["adate"]);
				Curr["adate"] = Meta.GetSys("datacontabile");
				Meta.SaveFormData();
			}
		}

		private void btnInserisci_Click(object sender, EventArgs e) {
			if (MetaData.Empty(this)) return;
			MetaData.GetFormData(this, true);
			string MyFilter = GetFilterForLinking(QHS);
			string command = "choose.taxpayview.liqcollegataF24ord." + MyFilter;
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
			Meta.MultipleLinkUnlinkRows("Composizione F24 Ordinario",
				"Liquidazioni incluse nel modello F24 selezionato",
				"Liquidazioni non incluse in alcun modello F24",
				DS.taxpayview, MyFilter, MyFilterSQL, "liqcollegataF24ord");
			riempiCampiCalcolati();
		}

		private void button1_Click(object sender, EventArgs e) {
			if (DS.f24ordinario.Rows.Count == 0) {
				return;
			}
			//TODO POST
			if ((DS.taxpayview.Rows.Count == 0)/* && (DS.expenseclawbackview.Rows.Count == 0)*/ && (DS.ivapay.Rows.Count == 0) && (DS.f24ordinariodetail.Rows.Count == 0)) {
				show(this, "Non ci sono liquidazioni!");
				return;
			}

			if (!Meta.GetFormData(false)) return;
			PostData.RemoveFalseUpdates(DS);
			if (DS.HasChanges()) {
				show(this, "Per generare il file del modello f24 occorre prima SALVARE");
				return;
			}

			DataRow Curr = DS.f24ordinario.Rows[0];
			DataTable t1 = Meta.Conn.CallSP("exp_f24ordinario_dati", new object[] { Curr["idf24ordinario"] }).Tables[0];
			if ((t1 == null) || (t1.Rows.Count == 0)) {
				show(this, "La procedura di estrazione dati non ha restituito risultati");
				return;
			}

			// Codice per esportare in excel
			exportclass.DataTableToExcel(t1, true);
		}

		private void btnDeleteIVA_Click(object sender, EventArgs e) {
			if (Meta.IsEmpty) return;
			Meta.GetFormData(true);
			MetaData.Unlink_Grid(gridIVA);
			riempiCampiCalcolati();
		}

		private void btnInsertIVA_Click(object sender, EventArgs e) {
			if (MetaData.Empty(this)) return;
			MetaData.GetFormData(this, true);
			string MyFilter = GetFilterForLinkingIVA(QHS);
			string command = "choose.ivapay.default." + MyFilter;
			MetaData.Choose(this, command);
			riempiCampiCalcolati();
		}

		private void btnEditIVA_Click(object sender, EventArgs e) {
			if (Meta.IsEmpty) return;
			Meta.GetFormData(true);
			string MyFilter = GetFilterForLinkingIVA(QHC);
			string MyFilterSQL = GetFilterForLinkingIVA(QHS);
			Meta.MultipleLinkUnlinkRows("Composizione F24 ",
				"Liquidazioni IVA incluse nel modello F24 selezionato",
				"Liquidazioni IVA non incluse in alcun modello F24",
				DS.ivapay, MyFilter, MyFilterSQL, "default");
			riempiCampiCalcolati();
		}

		private void btnImport_Click(object sender, EventArgs e)
		{
			if (Meta.IsEmpty) return;

			DataTable t = new DataTable();
			string fileName = "";

			try
			{
				OpenFileDialog _openInputFileDlg = new OpenFileDialog();
				IOpenFileDialog openInputFileDlg = createOpenFileDialog(_openInputFileDlg);
				// Apertura della finestra per poter scegliere un file da importare
				
				DialogResult result = openInputFileDlg.ShowDialog();
				if (result != DialogResult.OK)
				{
					show("Non è stato scelto alcun file");
					return;
				}

				fileName = openInputFileDlg.FileName;

				if (string.IsNullOrWhiteSpace(fileName))
					return;
			}
			catch (Exception ex)
			{
				show($"{ex.Message}", "Errore");
				return;
			}

			if (!fileName.EndsWith("csv"))
			{
				show("File non valido! Selezionare un file csv", "Errore");
				return;
			}

			try
			{
				//lettura del file csv e caricamento dei dati nel datatable t
				using (StreamReader reader = new StreamReader(fileName))
				using (CsvReader csvReader = new CsvReader(reader))
				{
					using (CsvDataReader dataReader = new CsvDataReader(csvReader))
					{
						t.Load(dataReader);
					}
				}
			}
			catch (Exception ex)
			{
				show($"Errore nell'apertura del file.\n{ex.Message}", "Errore");
				return;
			}

			DataTable tributi = Meta.Conn.RUN_SELECT("f24tributi", "*", null, null, null, false);

			// La configurazione Inail è stata inserita nella tabella pat
			DataTable pat = Meta.Conn.RUN_SELECT("pat", "*", null, null, null, false);

			//prendo il massimo iddetail di f24ordinariodetail
			int maxIdf24detail = Convert.ToInt32(DS.f24ordinariodetail.AsEnumerable().Max(row => row["iddetail"]));

			string TributiError = "";
			int nRows = 2;
			// per ogni riga letta dal file csv creo una riga di f24ordinariodetail
			foreach (DataRow r in t.Rows)
			{
				DataRow f24detail = DS.f24ordinariodetail.NewRow();

				f24detail["idf24ordinario"] = DS.f24ordinario.Rows[0]["idf24ordinario"];
				f24detail["iddetail"] = maxIdf24detail + 1;

				DataRow[] rTributi = tributi.Select(QHS.CmpEq("codicetributoep", r["cod_tributo"].ToString().Trim()));

				if (rTributi == null)
				{
					TributiError += $"Riga {nRows} - codice: {r["cod_tributo"].ToString().Trim()} sezione: {r["sezione"].ToString().Trim()},\n";
					nRows++;
					continue;
				}

				if (rTributi.Count() == 0)
				{
					TributiError += $"Riga {nRows} - codice: {r["cod_tributo"].ToString().Trim()} sezione: {r["sezione"].ToString().Trim()},\n";
					nRows++;
					continue;
				}

				DataRow tributo = rTributi[0];

				f24detail["codicetributo"] = tributo["codicetributo"];
				// per riferimento A oppure B uso la formattazione: Mese MM  MeseAnno MMAAAA
				if (r["riferimento_a"] != DBNull.Value && r["riferimento_a"].ToString().Trim() != "" && r["sezione"].ToString().Trim().ToUpper() != "N")
				{
					int lunghezza = r["riferimento_a"].ToString().Trim().Length;
					if (lunghezza > 4) //MeseAnno MMAAAA
						f24detail["riferimentoa"] = r["riferimento_a"].ToString().Trim().PadLeft(6, '0');
					else // Mese MM
						f24detail["riferimentoa"] = r["riferimento_a"].ToString().Trim().PadLeft(4, '0');
				}
				if (r["riferimento_b"] != DBNull.Value && r["riferimento_b"].ToString().Trim() != "" && r["sezione"].ToString().Trim().ToUpper() != "N")
				{
					int lunghezza = r["riferimento_b"].ToString().Trim().Length;
					if (lunghezza > 4) // MeseAnno MMAAAA
						f24detail["riferimentob"] = r["riferimento_b"].ToString().Trim().PadLeft(6, '0');
					else // Mese MM
						f24detail["riferimentob"] = r["riferimento_b"].ToString().Trim().PadLeft(4, '0');
				}
				f24detail["idf24sezione"] = tributo["idf24sezione"];

				f24detail["ct"] = DateTime.Now;
				f24detail["lt"] = DateTime.Now;
				f24detail["cu"] = "importazionef24";
				f24detail["lu"] = "importazionef24";

				decimal.TryParse(r["importo"].ToString(), out decimal res);

				res /= 100;

				if (r["segno_importo"].ToString().Trim() == "+")
				{
					f24detail["importoadebito"] = res;
				}
				else
				{
					f24detail["importoacredito"] = res;
				}

				switch (tributo["idf24sezione"].ToString())
				{
					case "F":
						// non ci sono dati da aggiungere
						break;
					case "I":
						//vengono letti dalla tabella config
						break;
					case "R":
						int.TryParse(r["codice"].ToString(), out int result);
						f24detail["idfiscaltaxregion"] = result.ToString().PadLeft(2, '0');
						break;
					case "S":
						f24detail["catastalecomune"] = r["codice"].ToString().Trim();
						break;
					case "N":
						DataRow[] rowsPat = pat.Select(QHS.AppAnd(
							QHS.CmpEq("active", "S"),
							QHS.IsNotNull("cc"),
							QHS.IsNotNull("codicesede"),
							QHS.CmpLe("validitystart", Meta.GetSys("datacontabile").ToString()),
							QHS.CmpGe("validitystop", Meta.GetSys("datacontabile").ToString())
							));

						if (rowsPat == null)
						{
							show("Configurazione Inail non trovata. \n" +
								"Aggiungere la configurazione in Compensi - Parasubordinati - Tabelle secondarie - Posizione Assicurativa Territoriale.");
							DS.f24ordinariodetail.Clear();
							return;
						}

						if (rowsPat.Count() == 0)
						{
							show("Configurazione Inail non trovata. \n" +
								"Aggiungere la configurazione in Compensi - Parasubordinati - Tabelle secondarie - Posizione Assicurativa Territoriale.");
							DS.f24ordinariodetail.Clear();
							return;
						}

						if (rowsPat.Count() > 1)
						{
							show("Ci sono più configurazione Inail. Lasciare attiva una e disattivare le altre.");
							DS.f24ordinariodetail.Clear();
							return;
						}

						DataRow rPat = rowsPat[0];

						f24detail["codicesedeinail"] = rPat["codicesede"].ToString().Trim();
						f24detail["codiceditta"] = rPat["patcode"].ToString().Trim();
						f24detail["cc_codiceditta"] = rPat["cc"].ToString().Trim();
						f24detail["causaleinail"] = r["riferimento_a"].ToString().Trim();
						f24detail["numerodiriferimento"] = tributo["codicetributo"].ToString().Trim();

						break;
					case "A":
						f24detail["idaltrienti"] = tributo["idaltrienti"];
						f24detail["idcodicesedealtrienti"] = r["codice"].ToString().Trim();
						break;
				}

				DS.f24ordinariodetail.Rows.Add(f24detail);
				maxIdf24detail++;
				nRows++;
			}

			if (TributiError != "")
			{
				DS.f24ordinariodetail.Clear();
				TributiError = "Codici Tributo non trovati:\n\n" + TributiError;
				show(TributiError.Substring(0, TributiError.Length - 2), "Errore");
				return;
			}

		}
	}
}
