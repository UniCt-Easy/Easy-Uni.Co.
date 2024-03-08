
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
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;
using System.Collections;
using System.Threading;
using System.Data.OleDb;
using System.IO;
using System.Globalization;
using System.Net;
using q=metadatalibrary.MetaExpression;

namespace notable_scriptcomuni {
	public partial class frmNoTable_scriptcomuni : MetaDataForm  {
		public frmNoTable_scriptcomuni() {
			InitializeComponent();
			askFileName.FileName = "openFileVarComuni";
			askFileName.RestoreDirectory = true;
		}
		
		private DataTable variazioneComuni = null;
		private DataTable listaComuni = null;
		private DataTable listaComuniAE = null;
		private DataTable listaAliquote = null;
		public void MetaData_AfterLink() {
			
			//bool isAdmin = (bool)Meta.GetSys("IsSystemAdmin");
			
			cacheTable(DS.geo_city,null);
			cacheTable(DS.geo_city_agency,null);
			cacheTable(DS.geo_cap,null);
			cacheTable(DS.geo_country,null);
			cacheTable(DS.geo_city_codeview,null);
			cacheTable(DS.taxratecitystartview,null);

			DS.getIndexManager().checkCreateIndex(DS.geo_city_codeview, new string[]{"nazionale","provincecode","newcity"}, false);
			DS.getIndexManager().checkCreateIndex(DS.geo_city_codeview, new string[]{"nazionale","newcity"}, false);
			DS.getIndexManager().checkCreateIndex(DS.geo_city_codeview, new string[]{"nazionale","provincecode"}, false);
			DS.getIndexManager().checkCreateIndex(DS.geo_city_codeview, new string[]{"nazionale"}, false);
			
			DS.getIndexManager().checkCreateIndex(DS.geo_city, new string[]{"title"}, false);
			DS.getIndexManager().checkCreateIndex(DS.geo_city, new string[]{"title","stop"}, true);
			DS.getIndexManager().checkCreateIndex(DS.geo_city, new string[]{"title","newcity", "stop"}, true);

			DS.getIndexManager().checkCreateIndex(DS.geo_city_agency, new string[]{"idcity","idagency","idcode"}, true);
			DS.getIndexManager().checkCreateIndex(DS.geo_city_agency, new string[]{"idcity"}, false);
			DS.getIndexManager().checkCreateIndex(DS.geo_country, new string[]{"province"}, true);

			DS.getIndexManager().checkCreateIndex(DS.taxratecitystartview, new string[] {"idcity"}, false);
		}

		object getIdCity(string nazionale, DateTime start) {
			var rr = DS.geo_city_codeview.f_Eq("nazionale", nazionale).ToList();
			if (rr.Count() == 1) return rr[0]["idcity"];

			//Prima vede se c'è uno con datastart valorizzata e prima di start fornito
			var rrwithStart = rr.f_isNotNull("start")._Filter(q.le("start", start)).OrderByDescending(x => x["start"]).ToList();
			if (rrwithStart.Count > 0) return rrwithStart[0]["idcity"];
			
			//nessuno ha datastart, allora prende quello senza newcity o stop
			var rrValid = rr.f_isNull("newcity").f_isNull("stop").ToList();
			if (rrValid.Count == 1) return rrValid[0]["idcity"];

			//prova solo senza newcity
			var rrNoNewCity = rr.f_isNull("newcity").ToList();
			if (rrNoNewCity.Count ==1 ) return rrNoNewCity[0]["idcity"];

			//Cerca quello il cui newcity non sia compreso tra quelli dati
			List<DataRow> foundTop = new List<DataRow>();
			foreach (var r in rr) {
				if ((rr.f_Eq("idcity",r["newcity"])?.Count()??0)==0) foundTop.Add(r);
			}

			if (foundTop.Count == 1) {
				return foundTop[0]["idcity"];
			}

			return null;
		}


		object getIdCityName(string nazionale,string provincia, string name, bool all=false) {
			var r = DS.geo_city_codeview.Filter(q.eq("nazionale", nazionale)& q.eq("newcity",DBNull.Value) & q.eq("title",name) & q.eq("provincecode",provincia));
			if (r.Length > 0) return r[0]["idcity"];
			if (!all) return null;
			r = DS.geo_city_codeview.Filter(q.eq("nazionale", nazionale) & q.eq("title",name)  & q.eq("provincecode",provincia));
			if (r.Length == 0) return null;
			if (r.Length==1)return r[0]["idcity"];
			return  r.OrderBy(x => (x["start"]==DBNull.Value)? DateTime.MinValue:x["start"]).LastOrDefault()["idcity"];
		}


		object getIdCity(string nazionale,string provincia, bool all=false) {
			var r = DS.geo_city_codeview.Filter(q.eq("nazionale", nazionale)& q.eq("newcity",DBNull.Value) & q.eq("provincecode",provincia));
			if (r.Length > 0) return r[0]["idcity"];
			if (!all) return null;
			r = DS.geo_city_codeview.Filter(q.eq("nazionale", nazionale)& q.eq("provincecode",provincia));
			if (r.Length == 0) return null;
			if (r.Length==1)return r[0]["idcity"];
			return  r.OrderBy(x => (x["start"]==DBNull.Value)? DateTime.MinValue:x["start"]).LastOrDefault()["idcity"];
		}

		

		//public void MetaData_AfterActivation() { }
		public void MetaData_AfterClear() {
			pulisciNomiPaesi(DS.geo_city);
			pulisciNomiPaesi(DS.geo_city_codeview);
		}
		//public void MetaData_BeforeFill() {}
		//public void MetaData_AfterFill() {}
		//public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
		//public void MetaData_BeforePost() { }
		//public void MetaData_AfterPost() { }

	

		private void btnElabora_Click(object sender, EventArgs e) {

			if (listaComuni == null || variazioneComuni == null) {
				show("E' necessario selezionare i due file", "Errore");
				return;
			}
		}

		private DataTable readFileGenerico(DataTable t, string fileName) {
			if (fileName.EndsWith("xls") || fileName.EndsWith("xlsx")) {
				t.Clear();
				var c = new ExcelImport();
				c.ImportTable(fileName, t, false, 2);
			}
			else {
				// Lettura file .CSV
				var pathOnly = Path.GetDirectoryName(fileName);
				if (pathOnly == null) return null;
				var connectionString = ExcelImport.CsvConnString(pathOnly, false);
				var onlyfileName = Path.GetFileName(fileName);
				var inicontent = "[" + onlyfileName + "]\r\n" +
				                 "Format = Delimited(;)\r\n" +
				                 "MaxScanRows=0\r\n" +
				                 "DecimalSymbol=,\r\n" +
				                 "CurrencyThousandSymbol=.\r\n" +
				                 "CurrencyDigits=2\r\n" +
				                 "ColNameHeader = False";
				for (var i = 0; i < t.Columns.Count; i++) {
					var nCol = i + 1;
					var c = t.Columns[i];
					var colDef = "Col" + nCol + "=\"" + c.ColumnName + "\" " + getExcelType(c);
					inicontent += "\r\n" + colDef;
				}

				var fNameIni = Path.Combine(pathOnly, "schema.ini");
				File.WriteAllText(fNameIni, inicontent);

				try {
					// open the connection to the file
					using (var connection = new OleDbConnection(connectionString)) {
						//connection.Open();
						var sql = $"SELECT * FROM [{onlyfileName}]";

						// create an adapter
						using (var adapter = new OleDbDataAdapter(sql, connection)) {
							// clear the datatable to avoid old data persistant
							t.Locale = CultureInfo.CurrentCulture;
							t.Clear();
							adapter.Fill(t);
						}
						GC.Collect(); 
						GC.WaitForPendingFinalizers();
						//connection.Close();
						//connection.Dispose();
					}
				}
				catch (Exception ex) {
					show(this, ex.Message);
					return null;
				}

				const int rowsToSkip = 1;
				// pulizia nomi colonne da eventuali spazi
				foreach (DataColumn c in t.Columns) {
					c.ColumnName = c.ColumnName.Replace(" ","");
				}

				for (var i = 0; i < rowsToSkip; i++) {
					t.Rows[i].Delete();
				}

				t.AcceptChanges();
				File.Delete(fNameIni);
				
				
			}

			return t;
		}

		private DataTable readFileListaComuni(string fileName) {
			var dtToImport = new DataTable();
			var header = "Istat;Comune;Provincia;Regione;Prefisso;CAP;CodFisco;Abitanti;Link";
			            //Istat;Comune;Provincia;Regione;Prefisso;CAP;CodFisco;Abitanti;Link
			foreach (string colName in header.Split(';')) {
				dtToImport.Columns.Add(colName, typeof(string));
			}

			readFileGenerico(dtToImport, fileName);
			dtToImport.Columns["Comune"].ColumnName = "title";
			dtToImport.Columns["CodFisco"].ColumnName = "nazionale";
			dtToImport.Columns["Istat"].ColumnName = "istat";
			dtToImport.Columns.Add("idcity", typeof(int));
			pulisciNomiPaesi(dtToImport);
			/*
			listaComuni: Comune BAJARDO trovato come BAIARDO
			listaComuni: Comune CASTELNUOVO DI VAL DI CECINA trovato come CASTELNUOVO VAL DI CECINA
			listaComuni: Comune EMARE'SE trovato come EMARESE
			listaComuni: Comune FÉNIS trovato come FENIS
			listaComuni: Comune NOICA'TTARO trovato come NOICATTARO
			listaComuni: Comune REGGIO CALABRIA trovato come REGGIO DI CALABRIA
			listaComuni: Comune REGGIO EMILIA trovato come REGGIO NELL'EMILIA
			listaComuni: Comune ROCCA D'ARCE trovato come ROCCADARCE
			listaComuni: Comune SAINT RHÉMY EN BOSSES trovato come SAINT-RHEMY-EN-BOSSES
			listaComuni: Comune SAN DORLIGO DELLA VALLE   DOLINA trovato come SAN DORLIGO DELLA VALLE
			listaComuni: Comune TERZO D'AQUILEIA trovato come TERZO DI AQUILEIA
			listaComuni: Comune VERRE'S trovato come VERRES
			*/
			Dictionary<string,string>aliases= new Dictionary<string, string>() {
				{"BARI SARDO", "BARISARDO"},
				{ "BAJARDO","BAIARDO"},
				{ "CASTELNUOVO DI VAL DI CECINA","CASTELNUOVO VAL DI CECINA"},
				{ "EMARE'SE","EMARESE"},
				{ "FÉNIS","BAIARDO"},
				{ "NOICA'TTARO","NOICATTARO"},
				{ "REGGIO CALABRIA","REGGIO DI CALABRIA"},
				{ "REGGIO EMILIA","REGGIO NELL'EMILIA"},
			
				{ "SAINT RHÉMY EN BOSSES","SAINT RHEMY EN BOSSES"},
				{ "SAN DORLIGO DELLA VALLE   DOLINA","SAN DORLIGO DELLA VALLE"},
				{ "TERZO D'AQUILEIA","TERZO DI AQUILEIA"},
				{ "VERRE'S","VERRES"},


				{ "VODO CADORE","VODO DI CADORE"},
				{ "ZANÈ","ZANE'"},
				{ "ZERBOLÒ","ZERBOLO''"},
				{"GODIASCO", "GODIASCO SALICE TERME"},
				{"PUEGNAGO SUL GARDA", "PUEGNAGO DEL GARDA"},
				{"SANTO STINO DI LIVENZA", "SAN STINO DI LIVENZA"},
				{"TREMOSINE","TREMOSINE SUL GARDA" }
				
			};
			foreach (var k in aliases.Keys) {
				var r = dtToImport.f_Eq("title", k).FirstOrDefault();
				if (r != null) r["title"] = aliases[k];
			}

			dtToImport.Columns.Add("idcountry", typeof(int));
			foreach (DataRow r in dtToImport.Rows) {
				string provincia = r["Provincia"].ToString();
				var rc = DS.geo_country.Filter(q.eq("province",provincia )).FirstOrDefault();
				if (rc == null) {
					show($"Comune {r["title"]}: provincia {provincia} non trovata","Errore");
					continue;
				}
				r["idcountry"] = rc["idcountry"];

				r["idcity"] = getIdCity(r["nazionale"].ToString(), provincia, true)??DBNull.Value;
			}
			return dtToImport;
		}

		string pulisciNome(string title) {
			title = title.ToUpperInvariant();
			title = title.Replace("Ã", "A").Replace("È","E'").Replace("À","A'").Replace("Ì","I'").Replace("Ò","O'").Replace("-"," ");
			title = title.Replace("É", "E").Replace("Ì","I'").Replace("Ù","U'");
			if (title.Contains('*')) {
				title = title.Split('*')[0].Trim();
			}

			

			if (title.Contains('*')) {
				title = title.Split('*')[0].Trim();
			}

			return title;
		}

		void pulisciNomiPaesi(DataTable t) {
			foreach (DataRow r in t.Rows) {
				string title = r["title"].ToString();
				
				
				r["title"] = pulisciNome(title);
			}
			t.AcceptChanges();
		}

		private DataTable readFileListaComuniAE(string fileName) {
			var dtToImport = new DataTable();
			var header =
				"CodiceNazionale;SiglaProvincia;DenominazioneItaliana;DenominazioneEstera;CodiceCatastale;UfficioCatastoTerreni;UfficioCatastoFabbricati;CodiceConservatoria;CodiceIstat;DataCostituzione;AttesaVCTTerritorio;AttesaVCTFabbricati";
             // "Codice Nazionale;Sigla Provincia;Denominazione Italiana;Denominazione Estera;Codice Catastale;Ufficio Catasto Terreni;Ufficio Catasto Fabbricati;Codice Conservatoria;Codice Istat;Data Costituzione;Attesa VCT Territorio;Attesa VCT Fabbricati"
			foreach (string colName in header.Split(';')) {
				dtToImport.Columns.Add(colName, typeof(string));
			}

			readFileGenerico(dtToImport, fileName);
			dtToImport.Columns.Add("start", typeof(DateTime));
			foreach (DataRow r in dtToImport.Rows) {
				if (r["DataCostituzione"].ToString() != "") {
					r["start"] = HelpForm.GetObjectFromString(typeof(DateTime), r["DataCostituzione"].ToString(), "g")??DBNull.Value;
				}
			}

			dtToImport.Columns["DenominazioneItaliana"].ColumnName = "title";
			dtToImport.Columns["CodiceNazionale"].ColumnName = "nazionale";
			dtToImport.Columns["CodiceCatastale"].ColumnName = "catastale";
			dtToImport.Columns["CodiceIstat"].ColumnName = "istat";
			
			dtToImport.Columns.Add("idcity", typeof(int));
			
			
			pulisciNomiPaesi(dtToImport);

			
			foreach (var k in aliasesAgenziaEntrate.Keys) {
				var r = dtToImport.f_Eq("title", k).FirstOrDefault();
				if (r != null) r["title"] = aliasesAgenziaEntrate[k];
			}

			dtToImport.Columns.Add("idcountry", typeof(int));
			ricalcolaInfoListaComuni(dtToImport);
			return dtToImport;
		}

		

		decimal getImportoFromStringa(string importo) {
			if (importo.EndsWith(".")||importo.EndsWith(",")) importo = importo.Substring(0, importo.Length - 1);
			importo = importo.Replace("€", "");
			importo = importo.Trim();
			int dotPos = importo.IndexOf('.');
			int lastDotPos = importo.LastIndexOf('.');
			if (lastDotPos != dotPos) {
				//rimuove la prima occorrenza del punto  se ce ne sono due o più
				return getImportoFromStringa(importo.Remove(dotPos, 1));
			}

			int commaPos = importo.IndexOf(',');
			int lastCommaPos = importo.LastIndexOf(',');
			if (lastCommaPos != commaPos) {
				//rimuove la prima occorrenza della virgola  se ce ne sono due o più
				return getImportoFromStringa(importo.Remove(commaPos, 1));
			}


			if (dotPos < 0 && commaPos < 0) {
				return Convert.ToDecimal(importo, new CultureInfo("en-US"));
			}
			//se ci sono tutti e due, il primo non serve comunque
			if (dotPos >= 0 && commaPos >= 0) {
				if (dotPos < commaPos) return getImportoFromStringa(importo.Replace(".", ""));
				return getImportoFromStringa(importo.Replace(",", ""));
			}

			//c'è uno solo dei due, normalizza la stringa con solo il punto decimale (che  potrebbe essere anche un punto di separazione delle migliaia)
			if (commaPos >= 0) return getImportoFromStringa(importo.Replace(',', '.'));

			//A questo punto c'è solo un punto, e dobbiamo decidere se cancellarlo o considerarlo un punto decimale o delle migliaia
			//Lo consideriamo un punto decimale se seguito da 1 o due cifre numeriche
			if (dotPos < importo.Length - 3) {
				//Altrimenti è un punto/virgola delle migliaia e lo togliamo
				importo = importo.Replace(".", "");
			}
			
			
			return Convert.ToDecimal(importo, new CultureInfo("en-US"));
		}

		int getFirstImportoDontSkipEuro(string fascia, out string result) {
			result = null;
			for (int i = 0; i < fascia.Length; i++) {
				if (char.IsDigit(fascia[i])) {
					//prende da quella cifra in poi
					int j = i + 1;
					while (j < fascia.Length && (char.IsDigit(fascia[j]) || fascia[j] == '.' || fascia[j] == ',')) j++;
					result= fascia.Substring(i, j - i);
					return i;
				}
			}
			return -1;
		}

		int getFirstImporto(string fascia, out string result) {
			
			int euroPos = fascia.IndexOf("euro");
			
			if (euroPos > 0) {
				if (fascia.IndexOf("euro,") != euroPos && fascia.IndexOf("euro annui,")!=euroPos) {
					int posImporto= getFirstImportoDontSkipEuro(fascia.Substring(euroPos),out result);
					if (posImporto > 0) return posImporto+euroPos;
				}
			}

			return getFirstImportoDontSkipEuro(fascia, out result);
		}

		decimal calcolaImportoEsenteDaDescrizione(string fascia) {
			fascia = fascia.ToLowerInvariant().Trim();
			string importoStr;
			fascia = fascia.Replace("art. 50", "").Replace("art. 49", "").Replace("e l)","").Replace("comma 2","").Replace("art. 53","").Replace("comma 1","")
				.Replace("art. 67","").Replace("art. 66","").Replace("art.53","").Replace("art.49","").Replace("art. 4","").Replace("art.50","");
			int firstImporto = getFirstImporto(fascia,out importoStr);
			if (firstImporto < 0) {
				if (fascia.StartsWith("esenzione") && fascia.IndexOf("fino ad euro diciottomila") > 0) return 18000;
				return 0;
			}
			
			decimal importo= getImportoFromStringa(importoStr);
			if (importo == 0) {
				string rest = fascia.Substring(firstImporto + 5);
				var nextImporto=   getFirstImporto(rest,out importoStr);
				if (firstImporto > 0) {
					firstImporto = nextImporto+firstImporto + 5;
					importo= getImportoFromStringa(importoStr);
				}
				
			}

			if (!isFasciaEsenzioneNormale(fascia)) return 0;

			foreach (var prefixEqual in new string[] { "esenzione per " }) {
				if (fascia == prefixEqual + importoStr) return importo;
			}
			
			foreach (var prefixStart in new string[] {
				"Esenzione per redditi fino a ", "Esenzione per reddito fino a ","Esenzione per redditi fin a",
				"Esenzione per redditi annui inferiori a",
				"Esenzione per redditi uguali o inferiori a",
				"esenzione per reddito fino a",
				"Esenzione per esenzione per reddito da lavoro dipendente",
				"Esenzione per i titolari di reddito di pensione e lavoro dipendente",
				"Esenzione per reddito inferiore a",
				"Esenzione per tutte le tipologie di reddito imponibile",
				"esenzione per importi fino ad euro",
				"esenzione per redditi isee inferiori a",
				"esenzione per redditi complessivi annui pari o inferiori a"
				
			}) {
				string p= prefixStart.ToLowerInvariant();
				if (fascia.StartsWith(p))return importo;
			}

			
			if (fascia.StartsWith("esenzione")) {
				foreach (var prefixBefore in new string[] {
					"lavoro dipendente", "lavoratori dipendenti","reddito imponibile complessivo","redditi certificati da CUD pari","reddito irpef",
					"redditi complessivi annui imponibili","reddito isee","reddito complessivo",
					"redditi di qualsiasi tipologia",
					"esenzione per scaglione di reddito da euro 0.00 fino a euro"
				}) {

					int posPrefix = fascia.IndexOf(prefixBefore.ToLowerInvariant());
					if (posPrefix >= 0 && posPrefix < firstImporto) return importo;
				}
			}

			//reddito annuo imponibile inferiore ad euro 10.000,00 derivante da lavoro dipendente 
			if (fascia.StartsWith("esenzione") && fascia.IndexOf("derivante da lavoro dipendente")-firstImporto-importo.ToString().Length<5 ) {
				return importo;
			}

			if (fascia.StartsWith("esenzione") && fascia.IndexOf("fino ad euro diciottomila") > 0) return 18000;

			Dictionary<int,decimal>minimaInps = new Dictionary<int, decimal>() {
				{2007, 436.14M}, {2008, 443.56M}, {2009, 458.20M}, {2010, 460.97M}, {2011, 468.35M}, {2012, 481.00M}, 
				{2013, 495.43M}, {2014, 500.88M}, {2015, 501.89M},	{2016, 501.89M},{2017, 501.89M},{2018, 507.46M},
				{2019, 513.01M},{2020, 515.07M},{2021, 515.58M}
			};

			//'Esenzione per reddito imponibile pari o inferiore al doppio della pensione minima INPS per lavoratori dipendenti vigente al 31 dicembre dell''anno precedente.'
			if (fascia.StartsWith("esenzione") && fascia.IndexOf("doppio della pensione minima INPS")>0 && fascia.IndexOf("anno precedente")>0) {
				return minimaInps[esercizio - 1] * 2;
			}

			return 0;
			/*
				NO update add2018 set esente = 15000 where fascia = 'Esenzione per i contribuenti ultrasettantenni che abbiano conseguito nell''''''''anno 2015 un reddito imponibile non superiore a euro 15.000,00'								
				NO update add2018 set esente = 7500 where fascia = 'Esenzione per redditi da pensione inferiori ad Euro 7500'
								
			 */
		}

		void ricalcolaInfoListaComuni(DataTable t) {
			foreach (DataRow r in t.Rows) {
				string provincia = r["SiglaProvincia"].ToString();
				var rc = DS.geo_country.Filter(q.eq("province", provincia)).FirstOrDefault();
				if (rc == null) {
					show($"Comune {r["title"]}: provincia {provincia} non trovata","Errore");
					continue;
				}
				r["idcountry"] = rc["idcountry"];

				var idcity= getIdCity(r["nazionale"].ToString(),provincia, true)??DBNull.Value;
				if (idcity == null) {
					show($"Codice nazionale: {r["nazionale"]} non trovato in geo_city_codeview", "Errore");
					continue;
				}
				r["idcity"] = idcity;
			}
		}

		Dictionary<string, string> aliasesAgenziaEntrate = new Dictionary<string, string>() {
			{"ROCCADARCE", "ROCCA D'ARCE"},
			{"BARI SARDO", "BARISARDO"},
			{"VODO CADORE" ,"VODO DI CADORE"},
			{"SAˆN JAN DI FASSA","SAN JAN DI FASSA"  }

		};

		
		private DataTable readFileVariazioni(string fileName) {
			var dtToImport = new DataTable();
			var header =
				"CodiceNazionale;SiglaProvincia;DenominazioneItaliana;DenominazioneEstera;CodiceCatastale;DataVariazione;TipoVariazione;TipoAnnotazione;Info;EstremiProvvedimento;ContenutoProvvedimento";
			//   Codice Nazionale;Sigla Provincia;Denominazione Italiana;Denominazione Estera;Codice Catastale;Data Variazione;Tipo Variazione;Tipo Annotazione;Info;Estremi Provvedimento;Contenuto Provvedimento
			foreach (string colName in header.Split(';')) {
				dtToImport.Columns.Add(colName, typeof(string));
			}
			readFileGenerico(dtToImport, fileName);

			dtToImport.Columns.Add("data", typeof(DateTime));
			foreach (DataRow r in dtToImport.Rows) {
				object d = HelpForm.GetObjectFromString(typeof(DateTime), r["DataVariazione"].ToString(), "g");
				r["data"] = d;
			}
			dtToImport.Columns["CodiceNazionale"].ColumnName = "nazionale";
			dtToImport.Columns["DenominazioneItaliana"].ColumnName = "title";
			dtToImport.Columns["CodiceCatastale"].ColumnName = "catastale";
			dtToImport.Columns.Add("idcity", typeof(int));
			pulisciNomiPaesi(dtToImport);
			
			foreach (var k in aliasesAgenziaEntrate.Keys) {
				var r = dtToImport.f_Eq("title", k).FirstOrDefault();
				if (r != null) r["title"] = aliasesAgenziaEntrate[k];
			}

			dtToImport.Columns.Add("idcountry", typeof(int));
			string[] comuniErratiCagliari = new string[] {
				"ESCALAPLANO", "ESCOLCA", "ESTERZILI","GERGEI","ISILI","NURAGUS","NURALLAO","NURRI","ORROLI","SADALI","SERRI","SEULO",
				"VILLANOVA TULO"
			};
			string[] comuniErratiOristano = new string[] {"GENONI"};
			foreach (DataRow r in dtToImport.Rows) {
				string provincia = r["SiglaProvincia"].ToString();
				//Correggo alcuni dati errati nel file variazioni
				if (comuniErratiCagliari.Contains(r["title"].ToString()) 
				    && r["TipoVariazione"].ToString() == "CPR" &&
					provincia=="NU" &&
				    r["Info"].ToString() == "Nuova provincia: SU") {
					provincia = "CA";
					r["SiglaProvincia"] = "CA";
				}
				if (comuniErratiOristano.Contains(r["title"].ToString()) 
				    && r["TipoVariazione"].ToString() == "CPR" &&
				    provincia=="NU" &&
				    r["Info"].ToString() == "Nuova provincia: SU") {
					provincia = "OR";
					r["SiglaProvincia"] = "OR";
				}

				var rc = DS.geo_country.Filter(q.eq("province", provincia)).FirstOrDefault();
				if (rc == null) {
					show($"Comune {r["title"]}: provincia {r["SiglaProvincia"]} non trovata","Errore");
					continue;
				}
				r["idcountry"] = rc["idcountry"];
				if (r["TipoVariazione"].ToString() == "CDE") {
					r["idcity"] = getIdCityName(r["nazionale"].ToString(), provincia, r["title"].ToString(), true)??DBNull.Value;
				}
				else {
					r["idcity"] = getIdCity(r["nazionale"].ToString(), provincia,true)??DBNull.Value;
				}
				
			}

			return dtToImport;
		}

		static string getExcelType(DataColumn c) {
			if (c.DataType == typeof(int)) return "Integer";
			if (c.DataType == typeof(string)) return "LongChar";
			if (c.DataType == typeof(decimal)) return "Currency";
			if (c.DataType == typeof(DateTime)) return "DateTime";
			(new MetaDataForm()).show("Tipo " + c.DataType + " non trovato");
			return "Text";
		}


		private void btnFileVariazioneComuni_Click(object sender, EventArgs e) {
			var res = askFileName.ShowDialog(this);
			if (res != DialogResult.OK) return;
			var fileName = askFileName.FileName;
			DataTable t = null;
			if (fileName.EndsWith("xls") || fileName.EndsWith("xlsx") || fileName.EndsWith("csv")) {
				try {
					t = readFileVariazioni(fileName);
					if (t == null) return;
					
				}
				catch (Exception ex) {
					show(this, $"Errore nell\'apertura del file! Processo Terminato\n{ex.Message}");
					return ;
				}
			}
			else {
				show("Il file deve avere formato xls, xlsx o csv", "Errore");
			}

			txtFileVarComuniAE.Text = askFileName.FileName;
			variazioneComuni = t;

			scan();
			btnFileListaComuni.Visible = true;
		}
		
		private void btnFileListaComuni_Click(object sender, EventArgs e) {
			var res = askFileName.ShowDialog(this);
			if (res != DialogResult.OK) return;
			
			var fileName = askFileName.FileName;
			DataTable t;
			if (fileName.EndsWith("xls") || fileName.EndsWith("xlsx") || fileName.EndsWith("csv")) {
				try {
					t = readFileListaComuni(fileName);
					if (t == null) return;
					
				}
				catch (Exception ex) {
					show(this, $"Errore nell\'apertura del file! Processo Terminato\n{ex.Message}");
					return ;
				}
			}
			else {
				show("Il file deve avere formato xls, xlsx o csv", "Errore");
				return;
			}

			txtListaComuni.Text = askFileName.FileName;
			listaComuni = t;
			//	ListaComuni:	var header = "Istat;Comune;Provincia;Regione;Prefisso;CAP;CodFisco;Abitanti;Link";

			if (!listaComuniAE.Columns.Contains("cap")) {
				listaComuniAE.Columns.Add("cap", typeof(string));
			}

			var aeRows = new Dictionary<string, DataRow>();
			foreach (DataRow r in listaComuniAE.Rows) aeRows[r["nazionale"].ToString()] = r;

			foreach (DataRow r in listaComuni.Rows) {
				
				string cod = r["nazionale"].ToString();
				if (!aeRows.ContainsKey(cod)) {
					var rSuppressed = DS.geo_city_codeview.f_Eq("nazionale", cod).FirstOrDefault();
					if (rSuppressed != null) {
						if (soppressi.Contains(r["title"].ToString())) continue;
						if (rSuppressed["newcity"] != DBNull.Value) {
							continue;
						}
					}
					show($"Codice nazionale {cod} non trovato nella lista dell'agenzia delle entrate",
						"Errore");
					continue;
				}

				aeRows[cod]["cap"] = r["CAP"];
			}
		}

		private void btnListaComuniAE_Click(object sender, EventArgs e) {
			var res = askFileName.ShowDialog(this);
			if (res != DialogResult.OK) return;
			
			var fileName = askFileName.FileName;

			DataTable t = null;
			if (fileName.EndsWith("xls") || fileName.EndsWith("xlsx") || fileName.EndsWith("csv")) {
				try {
					t = readFileListaComuniAE(fileName);
					if (t == null) return;
					
				}
				catch (Exception ex) {
					show(this, $"Errore nell\'apertura del file! Processo Terminato\n{ex.Message}");
					return ;
				}
			}
			else {
				show("Il file deve avere formato xls, xlsx o csv", "Errore");
				return;
			}

            foreach (DataRow r in t.Rows) {
                while (r["istat"].ToString().Length < 6) {
                    r["istat"] = "0" + r["istat"].ToString();
                }
            }
			txtListaComuniAE.Text = askFileName.FileName;
			listaComuniAE = t;
			btnFileVariazioneComuniAE.Visible = true;
		}

		void scan() {
			scanCambioNomi();
			scanSoppressi();
			scanIstituiti();

		}

		Dictionary<string,string> nuovoNome= new Dictionary<string, string>();
		void scanCambioNomi() {
			foreach (DataRow r in variazioneComuni.Rows) {
				if (r["TipoVariazione"].ToString().ToUpperInvariant() == "CDE") {
					var nuovoNomeComune = r["Info"].ToString().Split(':')[1].Trim();
					nuovoNomeComune =nuovoNomeComune.Split('/')[0].Trim();
					string newName = pulisciNome(nuovoNomeComune);
					if (newName!=r["title"].ToString()) nuovoNome[r["title"].ToString()] =newName ;
				}
			}
		}
		HashSet<string>soppressi = new HashSet<string>();
		void scanSoppressi() {
			foreach (DataRow r in variazioneComuni.Rows) {
				string tipovar = r["TipoVariazione"].ToString().ToUpperInvariant();
				if ( tipovar== "COS" || tipovar=="VTE") {
					if (r["Info"].ToString().StartsWith("Soppresso")) soppressi.Add(r["title"].ToString());
				}

			}
		}

		HashSet<string>istituiti = new HashSet<string>();
		void scanIstituiti() {
			foreach (DataRow r in variazioneComuni.Rows) {
				string tipovar = r["TipoVariazione"].ToString().ToUpperInvariant();
				if (tipovar == "COS" || tipovar == "VTE") {
					string info = r["Info"].ToString();
					if (info.Contains("per la costituzione del comune di")) {
						string soppresso = info.Replace("Soppresso per la costituzione del comune di ","").Trim();
						soppresso = soppresso.Split('(')[0].Trim();
						soppresso = soppresso.Split('/')[0].Trim();
						soppresso = pulisciNome(soppresso);
						if (aliasesAgenziaEntrate.ContainsKey(soppresso)) soppresso = aliasesAgenziaEntrate[soppresso];
						
						istituiti.Add( soppresso);
						if (nuovoNome.ContainsKey(soppresso)) istituiti.Add(nuovoNome[soppresso]);
					}
				}


			}
		}


		private void btnCheckCoerenza_Click(object sender, EventArgs e) {
			if (variazioneComuni == null || listaComuni == null|| listaComuniAE==null) return;
			var sb= new StringBuilder();
		
			
			Dictionary<string,string> nomeDaCambiare= new Dictionary<string, string>();
			foreach (DataRow r in variazioneComuni.Rows) {
				var titleCity = r["title"].ToString().ToUpperInvariant();	//"SAN JAN DI FASSA"
				object dataStop = null;
				dataStop = r["data"];
				var filter = q.eq("title", titleCity) & q.eq("stop",dataStop);
				var rCity=DS.geo_city.Filter(filter).FirstOrDefault();
				if (rCity != null) {
					r["idcity"] = rCity["idcity"];
					continue;
				}


				if (dataStop != null) {
					filter = q.eq("title", titleCity) & q.eq("stop",null); //vede se nel programma risulta ancora in vita
					rCity=DS.geo_city.Filter(filter).FirstOrDefault();
					if (rCity != null) {
						r["idcity"] = rCity["idcity"];
						//sb.AppendLine($"variazioneComuni: Comune {titleCity} trovato ma è da sopprimere");
						continue;
					}
				}

				if (dataStop != null) {
					filter = q.eq("title", titleCity) & q.isNotNull("stop"); //vede se nel programma risulta ancora in vita
					rCity=DS.geo_city.Filter(filter).FirstOrDefault();
					if (rCity != null) {
						r["idcity"] = rCity["idcity"];
						//sb.AppendLine($"variazioneComuni: Comune {titleCity} trovato ma è da sopprimere");
						continue;
					}
				}

				var city = DS.geo_city_codeview._Filter(q.eq("nazionale", r["nazionale"]) & q.eq("newcity", null))
					.FirstOrDefault();
					

				if (city != null) {
					r["idcity"] = city["idcity"];
					string vecchioNome = city["title"].ToString();
					if (nuovoNome.ContainsKey(vecchioNome) && nuovoNome[vecchioNome].ToString() == titleCity) {
						continue;
					}

					if (soppressi.Contains(titleCity)) continue;
					sb.AppendLine($"variazioneComuni: Comune {titleCity} {dataStop} trovato come {city["title"]} {city["stop"]}");
					continue;
				}

				if (istituiti.Contains(titleCity)) continue;
				if (rCity == null) {
					sb.AppendLine($"variazioneComuni: Comune {titleCity} {dataStop} non trovato in geo_city");
				}
			}

			foreach (DataRow r in listaComuniAE.Rows) {
				var titleCity = r["title"].ToString().ToUpperInvariant();
				var filter = q.eq("title", titleCity) & q.eq("stop",null);
				var rCity=DS.geo_city.Filter(filter).FirstOrDefault();
				if (rCity != null) {
					r["idcity"] = rCity["idcity"];
					continue;
				}

				var city = DS.geo_city_codeview._Filter(q.eq("nazionale", r["nazionale"]) & q.eq("newcity", null))
					.FirstOrDefault();


				if (city != null) {
					r["idcity"] = city["idcity"];
					string vecchioNome = city["title"].ToString();
					if (nuovoNome.ContainsKey(vecchioNome) && nuovoNome[vecchioNome].ToString() == titleCity) {
						continue;
					}
					sb.AppendLine($"listaComuniAE: Comune {titleCity} {r["nazionale"]} trovato come {city["title"]}");
					nomeDaCambiare[city["title"].ToString()] = titleCity;
					continue;
				}
				if (istituiti.Contains(titleCity)) continue;
				if (rCity == null) {
					sb.AppendLine($"listaComuniAE: Comune {titleCity} non trovato in geo_city");
				}
			}


			foreach (DataRow r in listaComuni.Rows) {
				var titleCity = r["title"].ToString().ToUpperInvariant();
				var filter = q.eq("title", titleCity) & q.eq("stop",null);
				var rCity=DS.geo_city.Filter(filter).FirstOrDefault();
				if (rCity != null) {
					r["idcity"] = rCity["idcity"];
					continue;
				}

				if (rCity == null) {
					filter = q.eq("title", titleCity);
					rCity=DS.geo_city.Filter(filter).FirstOrDefault();
					if (rCity != null) {
						r["idcity"] = rCity["idcity"]; //trovato, soppresso ma è normale qui
						continue;
					}
				}


				var city = DS.geo_city_codeview._Filter(q.eq("nazionale", r["nazionale"]) & q.eq("newcity", null))
					.FirstOrDefault();

				if (city != null) {
					r["idcity"] = city["idcity"];
					string vecchioNome = city["title"].ToString();
					if (nuovoNome.ContainsKey(vecchioNome) && nuovoNome[vecchioNome].ToString() == titleCity) {
						continue;
					}
					if (soppressi.Contains(titleCity)) continue;
					if (nomeDaCambiare.ContainsKey(city["title"].ToString()) &&
					    nomeDaCambiare[city["title"].ToString()] == titleCity) {
						continue;
					}
					sb.AppendLine($"listaComuni: Comune {titleCity} trovato come {city["title"]}");
					continue;
				}
				if (istituiti.Contains(titleCity)) continue;
				if (rCity == null) {
					sb.AppendLine($"listaComuni: Comune {titleCity} non trovato in geo_city");
				}
			}

			txtResult.Text = sb.ToString();
		}

		void elabora() {

		}

		private void btnRenameScript_Click(object sender, EventArgs e) {
			if (variazioneComuni == null || listaComuni == null|| listaComuniAE==null) return;
			var sb= new StringBuilder();
			sb.AppendLine("--[DBO]--");
			sb.AppendLine();


			Dictionary<string,string> nomeDaCambiare= new Dictionary<string, string>();

			foreach (DataRow r in listaComuniAE.Rows) {
				var titleCity = r["title"].ToString().ToUpperInvariant();
				var filter = q.eq("title", titleCity) & q.eq("stop",null);
				var rCity=DS.geo_city.Filter(filter).FirstOrDefault();
				if (rCity != null) {
					r["idcity"] = rCity["idcity"];
					continue;
				}
				var city = DS.geo_city_codeview._Filter(q.eq("nazionale", r["nazionale"]) & q.eq("newcity", null))
					.FirstOrDefault();

				if (city != null) {
					r["idcity"] = city["idcity"];
					string vecchioNome = city["title"].ToString();
					if (nuovoNome.ContainsKey(vecchioNome) && nuovoNome[vecchioNome].ToString() == titleCity) {
						continue;
					}
					
					//sb.AppendLine($"listaComuniAE: Comune {titleCity} {r["nazionale"]} trovato come {city["title"]}");
					sb.AppendLine(
						$"UPDATE geo_city set title={q.constant(titleCity).toSql(qhs)} WHERE idcity={q.constant(city["idcity"]).toSql(qhs)} --era {city["title"]}");

					nomeDaCambiare[city["title"].ToString()] = titleCity;
					continue;
				}
				
			}
			txtResult.Text = sb.ToString();
		}

		private int oldMaxIdCity = -1;

		void resetMaxIdCity() {
			oldMaxIdCity = -1;
//			DS.RejectChanges();

		}

		int getNewIdCity() {
			if (oldMaxIdCity != -1) {
				oldMaxIdCity++;
				return oldMaxIdCity;
			}
			oldMaxIdCity = CfgFn.GetNoNullInt32( DS.geo_city.Compute("max(idcity)",null))+1;
			return oldMaxIdCity;
		}

		string sql(object o) {
			return q.constant(o??DBNull.Value).toSql(qhs);
		}
		string insertIntoGeoCity(object idcity, object idcountry, object title, object oldcity, object newcity, object start,object stop) {
			return conn.getInsertCommand("geo_city",
				new string[] {"idcity", "idcountry", "oldcity", "newcity", "title", "start","stop", "lt", "lu"},
				new string[] {
					sql(idcity), sql(idcountry), sql(oldcity), sql(newcity), sql(title), sql(start),sql(stop), 
						sql(DateTime.Now),sql(me())
				}, 9
			);
		}

		string setStopGeoCityAgency(object idcity, object idagency, object idcode,  object version, object stop) {
			var r = DS.geo_city_agency
				.Filter(q.eq("idcity", idcity) & q.eq("idagency", idagency) & q.eq("idcode", idcode) &
				        q.eq("version", version)).FirstOrDefault();
			if (r == null) return string.Empty;
			r["stop"] = stop;
			return conn.getUpdateCommand("geo_city_agency",
				(q.eq("idcity",idcity)&q.eq("idcode",idcode)&q.eq("idagency",idagency)& q.eq("version",version)).toSql(qhs),
				new string[] {"stop", "lt", "lu"},
				new string[] {sql(stop), sql(DateTime.Now),sql(me())
				}, 3
			);
		}

		string insertIntoGeoCityAgency(object idcity, object idagency, object idcode,  object val,object version=null,object start=null,object stop=null) {
			var r = DS.geo_city_agency.NewRow();
			r["idcity"] = idcity;
			r["idagency"] = idagency;
			r["version"] = version??DBNull.Value;
			r["value"] = val;
			r["start"] = start??DBNull.Value;
			r["stop"] = stop??DBNull.Value;
			r["lt"] = DateTime.Now;
			r["lu"] = me();
			DS.geo_city_agency.Rows.Add(r);


			return conn.getInsertCommand("geo_city_agency",
				new string[] {"idcity", "idagency", "idcode", "version", "value", "start","stop", "lt", "lu"},
				new string[] {
					sql(idcity), sql(idagency), sql(idcode), sql(version??1), sql(val), sql(start),sql(stop), 
						sql(DateTime.Now),sql(me())
				}, 9
			);
		}


		string creaComune(object idcity,  object title, object idcountry, object oldcity, object nazionale,
			object catastale, object istat, object cap, object start,object stop=null, object newcity=null) {
			var sb= new StringBuilder();
			sb.AppendLine(
				$"/*** Istituzione comune {title} ({nazionale} istat:{istat} cap:{cap} catastale:{catastale}) *****/");
			sb.AppendLine(insertIntoGeoCity(idcity, idcountry, title, oldcity, newcity, start, stop));
			if (catastale!=DBNull.Value && catastale!=null) sb.AppendLine(insertIntoGeoCityAgency(idcity,1,2,catastale));
			sb.AppendLine(insertIntoGeoCityAgency(idcity,1,1,nazionale));
			if (istat!=DBNull.Value && istat!=null) sb.AppendLine(insertIntoGeoCityAgency(idcity,2,1,istat));
			if (cap!=DBNull.Value && cap!=null) sb.AppendLine(insertIntoGeoCityAgency(idcity,3,1,cap));
			sb.AppendLine();
			return sb.ToString();
		}

		string sopprimiComune(object idcity,  object newcity, object stop) {
			
			var rOld = DS.geo_city_codeview.Filter(q.eq("idcity", idcity)).First();
			var rNew = DS.geo_city_codeview.Filter(q.eq("idcity", newcity)).First();
			var sb= new StringBuilder();
			sb.AppendLine($"/**** Soppressione comune {rOld["title"]} incorporato in {rNew["title"]} ({rNew["nazionale"]})  *****/");
			sb.AppendLine( conn.getUpdateCommand("geo_city", q.eq("idcity", idcity).toSql(qhs),
				new string[] {"newcity", "stop", "lt", "lu"},
				new string[] {sql(newcity), sql(stop), sql(DateTime.Now), sql(me())},
				4));
			sb.AppendLine();

			rOld["newcity"] = newcity;
			rOld["stop"] = stop;

			var oldCityRow = DS.geo_city.f_Eq("idcity", idcity).FirstOrDefault();
			oldCityRow["newcity"] = newcity;
			oldCityRow["stop"] = stop;


			return sb.ToString();
		}

		private void btnScriptVariazione_Click(object sender, EventArgs e) {
			if (variazioneComuni == null || listaComuni == null|| listaComuniAE==null) return;
			var sb= new StringBuilder();
			sb.AppendLine("--[DBO]--");
			sb.AppendLine();

			resetMaxIdCity();

			foreach (DataRow r in variazioneComuni.Select(null,"data asc")) {
				string provincia = r["SiglaProvincia"].ToString();
				var data = (DateTime) r["data"];
				string tipoVariazione = r["TipoVariazione"].ToString().ToUpperInvariant();
				string info = r["Info"].ToString();
				
				if (tipoVariazione == "VTE" || tipoVariazione =="COS") {
					if (info.StartsWith("Coinvolto in una variazione territoriale con i seguenti comuni:")) {
						//In teoria non deve fare nulla, questo comune incorpora altri comuni
						//Al massimo possiamo verificare che i suoi dati nel db siano coerenti con quelli presenti nelle lista comuni
						var s = checkInfo(r["nazionale"].ToString(),provincia);
						if (s != string.Empty) sb.AppendLine(s);
						continue;
					}
					
					//Confluisce in un comune esistente se Info inizia con "Soppresso
					object newCity;
					var checkExist = assicuraEsistenzaComune(info,r["idcity"], out newCity);
					if (newCity == null) continue; //errore
					if (checkExist != string.Empty) {
						sb.AppendLine(checkExist);
					}

					var rigaCorrente = DS.geo_city_codeview.Filter(q.eq("idcity", r["idcity"])).FirstOrDefault();
					if (rigaCorrente["newcity"].Equals(newCity)) {
						continue; //è stato già soppresso come richiesto dalla riga
					}
					if (rigaCorrente["newcity"]!=DBNull.Value) {
						continue; //è stato già modificato
					}

					sb.AppendLine(sopprimiComune(r["idcity"],newCity, r["data"]));
				}

				if (tipoVariazione == "CPR") {
					//Deve creare un nuovo comune tutto uguale ma con provincia diversa
					string nuovaProv = info.Split(':')[1].Trim();
					var rc = DS.geo_country.Filter(q.eq("province", nuovaProv)).FirstOrDefault();
					var idcountry = rc["idcountry"];
					
					var rigaCorrente = DS.geo_city_codeview.Filter(q.eq("idcity", r["idcity"])).FirstOrDefault();
					if (rigaCorrente["newcity"]!=DBNull.Value) continue; //è stato già operato il cambio di provincia

					sb.AppendLine(cambiaProvincia(r["idcity"],r["data"],idcountry));
				}

				//CDE		Nuova denominazione: SAN GIOVANNI DI FASSA/SÃˆN JAN
				if (tipoVariazione == "CDE") {
					string nuovaDenominazione = info.Split(':')[1].Split('/')[0].Trim();
					nuovaDenominazione = pulisciNome(nuovaDenominazione);
					if (nuovaDenominazione == r["title"].ToString()) continue;
					var rigaCorrente = DS.geo_city_codeview.Filter(q.eq("idcity", r["idcity"])).FirstOrDefault();
					if (rigaCorrente["newcity"]!=DBNull.Value) {
						continue; //è stato già modificato
					}

					sb.AppendLine($"/** Title:{r["title"]} info: {r["Info"]} **/");
					sb.AppendLine(cambiaDenominazione(r["idcity"], r["data"],nuovaDenominazione));
					//Qualcosa non va, rinomina cose errate
				}

			}

			txtResult.Text = sb.ToString();
		}

		string cambiaDenominazione(object idcity, object start, string nuovaDenominazione) {
			var rCity = DS.geo_city.f_Eq("idcity", idcity).FirstOrDefault();
			var rCode = DS.geo_city_codeview.f_Eq("idcity", idcity).FirstOrDefault();
			

			var rNew = DS.geo_city.newRow();
			var newId = getNewIdCity();
			rNew["idcity"] = newId;
			rNew["idcountry"] = rCity["idcountry"];
			rNew["oldcity"] = idcity;
			rNew["start"] = start;
			rNew["lt"] = DateTime.Now;
			rNew["lu"] = me();
			rNew["title"] = nuovaDenominazione;
			
			DS.geo_city.Rows.Add(rNew);

			rCity["newcity"] = newId;
			rCity["stop"] = start;

			rCode["newcity"] = newId;
			rCode["stop"] = start;

			var rNC = DS.geo_city_codeview.newRow();
			rNC["title"] = nuovaDenominazione;
			rNC["start"] = start;
			rNC["oldcity"] = idcity;
			rNC["idcountry"] = rCity["idcountry"];

			rNC["idcity"] = newId;
			rNC["provincecode"] = rCode["provincecode"];
			rNC["cap"] = rCode["cap"];
			rNC["istat"] = rCode["istat"];
			rNC["nazionale"] = rCode["nazionale"];
			rNC["catastale"] = rCode["catastale"];
			DS.geo_city_codeview.Rows.Add(rNC);

			foreach (var r in DS.geo_city_agency.f_Eq("idcity", idcity)) {
				var rr = DS.geo_city_agency.newRow();
				rr["idcity"] = newId;
				rr["idagency"] = r["idagency"];
				rr["idcode"] = r["idcode"];
				rr["version"] = r["version"];
				rr["value"] = r["value"];
				rr["lt"] = DateTime.Now;
				rr["lu"] = me();
				DS.geo_city_agency.Rows.Add(rr);
			}
			StringBuilder sb= new StringBuilder();
			sb.AppendLine(
				$"/******* Cambio denominazione di {rCity["title"]} idcity={idcity} in {nuovaDenominazione} ******/");
			sb.AppendLine(creaComune(newId, nuovaDenominazione, rCity["idcountry"], idcity,
				rCode["nazionale"], rCode["catastale"], rCode["istat"], rCode["cap"],
				start));
			sb.AppendLine(sopprimiComune(idcity, newId, start));
			sb.AppendLine("/*************************************************/");
			sb.AppendLine();
				


			return sb.ToString();
		}

		string cambiaProvincia(object idcity, object start, object newIdCountry) {
			var rCity = DS.geo_city.f_Eq("idcity", idcity).FirstOrDefault();
			var rCode = DS.geo_city_codeview.f_Eq("idcity", idcity).FirstOrDefault();
			var rCountry = DS.geo_country.f_Eq("idcountry", newIdCountry).FirstOrDefault();


			var rNew = DS.geo_city.newRow();
			var newId = getNewIdCity();
			rNew["idcity"] = newId;
			rNew["idcountry"] = newIdCountry;
			rNew["oldcity"] = idcity;
			rNew["start"] = start;
			rNew["lt"] = DateTime.Now;
			rNew["lu"] = me();
			rNew["title"] = rCity["title"];
			
			DS.geo_city.Rows.Add(rNew);

			rCity["newcity"] = newId;
			rCity["stop"] = start;

			rCode["newcity"] = newId;
			rCode["stop"] = start;

			var rNC = DS.geo_city_codeview.newRow();
			rNC["title"] = rCode["title"];
			rNC["start"] = start;
			rNC["oldcity"] = idcity;
			rNC["idcountry"] = newIdCountry;

			rNC["idcity"] = newId;
			rNC["provincecode"] = rCountry["province"];
			rNC["cap"] = rCode["cap"];
			rNC["istat"] = rCode["istat"];
			rNC["nazionale"] = rCode["nazionale"];
			rNC["catastale"] = rCode["catastale"];
			DS.geo_city_codeview.Rows.Add(rNC);

			foreach (var r in DS.geo_city_agency.f_Eq("idcity", idcity)) {
				var rr = DS.geo_city_agency.newRow();
				rr["idcity"] = newId;
				rr["idagency"] = r["idagency"];
				rr["idcode"] = r["idcode"];
				rr["version"] = r["version"];
				rr["value"] = r["value"];
				rr["lt"] = DateTime.Now;
				rr["lu"] = me();
				DS.geo_city_agency.Rows.Add(rr);
			}
			StringBuilder sb= new StringBuilder();
			sb.AppendLine(
				$"/******* Cambio provincia di {rCity["title"]} da {rCode["provincecode"]} a {rCountry["province"]} ******/");
			sb.AppendLine(creaComune(newId, rCode["title"], newIdCountry, idcity,
				rCode["nazionale"], rCode["catastale"], rCode["istat"], rCode["cap"],
				start));
			sb.AppendLine(sopprimiComune(idcity, newId, start));
			sb.AppendLine("/*************************************************/");
			sb.AppendLine();
				


			return sb.ToString();
			//return string.Empty;
		}


		string me() {
			return "toolComuni" + esercizio.ToString();
		}

		string updateCurrentCode(object idcity, object idagency, object idcode, object value) {
			var rr = DS.geo_city_agency.Filter(q.eq("idcity", idcity) & q.eq("idagency", idagency) &
			                                   q.eq("idcode", idcode));
			int maxVersion;
			if (rr.Length == 0) {
				//MetaFactory.factory.getSingleton<IMessageShower>().Show($"Non ho trovato codici associati all'idcity {idcity} idagency {idagency} idcode {idcode}","Errore");
				maxVersion = 0;
			}
			else {
				
				DataRow rCurr;
				if (rr.Length == 1) {
					maxVersion = (int) rr[0]["version"];
					rCurr = rr[0];
				}
				else {
					maxVersion = rr.Select(x => (Int32) x["version"]).Max();
					rCurr = DS.geo_city_agency.Filter(q.eq("idcity", idcity) & q.eq("idagency", idagency) &
					                                  q.eq("idcode", idcode) & q.eq("version", maxVersion)).First();
				}

				if (rCurr["value"].ToString() == value.ToString()) return string.Empty;
			}

			//Deve aggiornare il codice
			var rNew = DS.geo_city_agency.newRow();
			rNew["idcity"] = idcity;
			rNew["idagency"] = idagency;
			rNew["idcode"] = idcode;
			rNew["version"] = maxVersion + 1;
			rNew["value"] = value;
			rNew["lt"] = DateTime.Now;
			rNew["lu"] = me();
			DS.geo_city_agency.Rows.Add(rNew);
			rNew.AcceptChanges();

			var s= new StringBuilder();
			if (maxVersion>0) s.AppendLine(setStopGeoCityAgency(idcity, idagency, idcode, maxVersion, DateTime.Now.Date));
			s.AppendLine(insertIntoGeoCityAgency(idcity, idagency, idcode, value, maxVersion + 1));
			return s.ToString();

		}
		
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="nazionale"></param>
		/// <returns></returns>
		string checkInfo(string nazionale,string province) {
			//Prende le informazioni da quelle correnti 
			var rAe = listaComuniAE._Filter(q.eq("nazionale", nazionale) & q.eq("SiglaProvincia",province) ).FirstOrDefault();
			if (rAe == null) {
				//Il comune non è più attivo, non facciamo nessuna verifica in questo caso
				return string.Empty;
			}

			//in rAe la riga dell'agenzia delle entrate arricchita con il cap 
			var r = DS.geo_city_codeview.Filter(q.eq("nazionale", nazionale)& q.eq("provincecode",province) &q.eq("newcity",null)).FirstOrDefault();
			if (r == null) {
				show($"Il codice nazionale {nazionale} non è stato trovato in geo_city_codeview", "Errore");
				return string.Empty;
			}

			bool anyUpdate = false;
			var sb= new StringBuilder();
			if (r["istat"].ToString() != rAe["istat"].ToString()) {
				sb.AppendLine($"/**** Aggiornamento ISTAT {r["title"]} da {r["istat"]} a {rAe["istat"]}   *****/");
				sb.AppendLine(updateCurrentCode(r["idcity"], 2, 1, rAe["istat"]));
				r["istat"] = rAe["istat"];
				anyUpdate = true;
			}
			if (r["catastale"].ToString() != rAe["catastale"].ToString()) {
				sb.AppendLine($"/**** Aggiornamento catastale {r["title"]} da {r["catastale"]} a {rAe["catastale"]}   *****/");
				sb.AppendLine(updateCurrentCode(r["idcity"], 1, 2, rAe["catastale"]));
				r["catastale"] = rAe["catastale"];
				anyUpdate = true;
			}
			string cap = rAe["cap"].ToString();
			if (!cap.Contains("x") && cap!="") {
				if (r["cap"].ToString() != cap) {
					sb.AppendLine($"/**** Aggiornamento CAP {r["title"]} da {r["cap"]} a {rAe["cap"]}    *****/");
					sb.AppendLine(updateCurrentCode(r["idcity"], 3, 1, rAe["cap"]));
					r["cap"] = rAe["cap"];
					anyUpdate = true;
				}
				
			}

			if (anyUpdate) return sb.ToString();
			return string.Empty;
		}

		/// <summary>
		/// Crea il nuovo comune referenziato nelle informazioni se non esiste, restituisce lo script eventuale per crearlo e il relativo idcity
		/// </summary>
		/// <param name="info"></param>
		/// <param name="idcity"></param>
		/// <returns></returns>
		string assicuraEsistenzaComune(string info, object oldIdCity, out object idcity) {
			idcity = null;
			bool riconosciuto = false;
			var patterns = new string[] {
				"Soppresso per variazione territoriale coinvolgente i seguenti comuni:",
				"Soppresso per la costituzione del comune di"
			};
			foreach (var p in patterns) {
				if (info.Contains(p)) {
					info = info.Replace(p, "");
					riconosciuto = true;
					break;
				}
			}

			if (!riconosciuto) {
				show($"Errore nella stringa {info}, il messaggio non è conforme allo standard.", "Errore");
				idcity = null;
				return $">>Errore nella stringa {info}";
			}
			//Estrae nome e codice nazionale
			info = info.Replace("Soppresso per la costituzione del comune di ", "").Trim();
			string title = pulisciNome(info.Split('(')[0].Trim().Split('/')[0].Trim());
			string nazionale = info.Split('(')[1].Split(')')[0].Trim();
			//Cerca il comune per codice catastale, e distingue il caso in cui sia anche poi stato soppresso o meno
			if (soppressi.Contains(title)) {
					var comune = DS.geo_city_codeview.Filter(q.eq("nazionale", nazionale) & q.isNotNull("newcity")).FirstOrDefault();
					if (comune != null) {
						idcity = comune["idcity"];
						return string.Empty;//Il comune già esiste nei vecchi comuni
					}
					if (istituiti.Contains(title)) {
						//E' da creare e poi rimuovere
						comune = DS.geo_city_codeview.Filter(q.eq("nazionale", nazionale) & q.eq("newcity",null)).FirstOrDefault();
						if (comune != null) {
							idcity = comune["idcity"];
							return string.Empty;//Il comune già esiste nei vecchi comuni
						}
					}

			}
			else {
				var comune = DS.geo_city_codeview.Filter(q.eq("nazionale", nazionale)  & q.isNull("newcity")).FirstOrDefault();
				if (comune != null) {
					idcity = comune["idcity"];
					return string.Empty; //Il comune già esiste nei comuni attuali
				}
			}

			//Il comune è da creare
			//Estrae i dati dall'elenco comuni attuali
			var rCurr = listaComuniAE._Filter(q.eq("nazionale", nazionale)).FirstOrDefault();
			if (rCurr == null) {
				//Potrebbe mancare perchè nel mentre soppresso
				if (!soppressi.Contains(title)) {
					show(
						$"Il comune con codice nazionale {nazionale} non è stato trovato nella lista comuni dell'A.E.",
						"Errore");
				}
				return string.Empty;
			}

			idcity = getNewIdCity();
			return aggiungiComune(idcity, rCurr,oldIdCity);
		}

		string aggiungiComune(object idCity, DataRow rAe, object oldCity) {
			DataRow rCity = DS.geo_city.NewRow();
			rCity["idcity"] = idCity;
			rCity["idcountry"] = rAe["idcountry"];
			rCity["oldcity"] = oldCity;
			rCity["start"] = rAe["start"];
			rCity["lt"] = DateTime.Now;
			rCity["lu"] = me();
			rCity["title"] = rAe["title"];
			DS.geo_city.Rows.Add(rCity);

			var rr = DS.geo_city_codeview.newRow();
			rr["idcity"] = idCity;
			rr["title"] = rAe["title"];
			rr["oldcity"] = oldCity;
			rr["nazionale"] = rAe["nazionale"];
			rr["catastale"] = rAe["catastale"];
			rr["istat"] = rAe["istat"];
			rr["cap"] = rAe["cap"];
			rr["idcountry"] = rAe["idcountry"];
			rr["provincecode"] = rAe["SiglaProvincia"];
			rr["start"] = rAe["start"];
			DS.geo_city_codeview.Rows.Add(rr);


			var sb= new StringBuilder();

			var sCrea = creaComune(idCity, rAe["title"], rAe["idcountry"], oldCity, rAe["nazionale"], rAe["catastale"],
				rAe["istat"], rAe["cap"], rAe["start"]);

			return sCrea;

		}

		private void btnViewInfo_Click(object sender, EventArgs e) {
			var sb= new StringBuilder();
			sb.AppendLine("Comuni soppressi:");
			var lista = soppressi.ToList();
			lista.Sort();
			foreach (var ss in lista) sb.AppendLine(ss);

			sb.AppendLine();
			sb.AppendLine("Comuni istituiti:");
			lista = istituiti.ToList();
			lista.Sort();
			foreach (var ss in lista) sb.AppendLine(ss);

			sb.AppendLine();
			sb.AppendLine("Cambi di nome:");
			lista = nuovoNome.Keys.ToList();
			lista.Sort();
			foreach (var ss in lista) sb.AppendLine($"{ss} => {nuovoNome[ss]}");

			txtResult.Text = sb.ToString();
		}

		private void btnCheckAllineamento_Click(object sender, EventArgs e) {
			ricalcolaInfoListaComuni(listaComuniAE);
			var sb= new StringBuilder();
			foreach (DataRow rAe in listaComuniAE.Rows) {
				string titleAe = rAe["title"].ToString();
				string nazionaleAe = rAe["nazionale"].ToString();
				string provinciaAe = rAe["SiglaProvincia"].ToString();
				var rDb = DS.geo_city_codeview.f_Eq("idcity", rAe["idcity"]).FirstOrDefault();
				if (rDb == null) {
					sb.AppendLine($"Comune {titleAe} ({nazionaleAe})  ({provinciaAe}) non trovato in geo_city_codeview");
					continue;
				}

				if (rDb["newcity"] != DBNull.Value ) {
					show(
						$"Il comune id:{rDb["idcity"]} {titleAe} ({nazionaleAe})  ({provinciaAe}) nel db è stato sostituito con un altro, ma non avrebbe dovuto accadere ",
						"Errore");
				}
				bool differences = false;
				string capAE = rAe["cap"].ToString();
				if (capAE != "" && (!capAE.Contains("x")) && (rAe["cap"].ToString() != rDb["cap"].ToString())) {
					//sb.AppendLine($"Comune {titleAe} ({nazionaleAe}): codice CAP diverso: {rDb["cap"]} invece di {capAE} ");
					differences = true;
				}


				foreach (string f in new string[] { "nazionale", "catastale", "istat" }) {
					if (rAe[f] == DBNull.Value) continue;
					if (rAe[f].ToString() != rDb[f].ToString()) {
						//sb.AppendLine($"Comune {titleAe} ({nazionaleAe}): codice {f} diverso: {rDb[f]} invece di {rAe[f]} ");
						differences = true;
					}
				}

				if (differences) {
					string ss = checkInfo(nazionaleAe, provinciaAe);
					if (ss == string.Empty) {
						show($"Anomalia su comune {rAe["idcity"]} ","Avviso");
					}
					else {
						sb.AppendLine(ss);
					}
				}

				var startDb = rDb["start"];
				var startAE = (DateTime) rAe["start"];
				if (startDb != DBNull.Value) {
					if (startAE.Year < 2000) continue;
					if (startAE.CompareTo((DateTime) startDb) != 0) {
						sb.AppendLine(
							$"Il comune id:{rDb["idcity"]} {rDb["title"]} ({rDb["nazionale"]})  ha data inizio {startDb} nel db mentre {startAE} sull'A.E. ");
					}
					
				}

				if (provinciaAe != rDb["provincecode"].ToString()) {
					var rigaCorrente = DS.geo_city_codeview.Filter(q.eq("idcity", rAe["idcity"])).FirstOrDefault();
					if (rigaCorrente["newcity"] != DBNull.Value) {
						show(
							$"La provincia è cambiata ma il comune era stato già soppresso, qualcosa non va. idcity={rAe["idcity"]}");
						continue;
					}
					
					sb.AppendLine(cambiaProvincia(rAe["idcity"], rAe["start"], rigaCorrente["idcountry"]));
					//sb.AppendLine($"Comune {titleAe} ({nazionaleAe}): provincia diversa diverso: {rDb["provincecode"]} invece di {provinciaAe} ");
				}
				
			}
			HashSet<int> listaAECity = new HashSet<int>();
			foreach (DataRow rAE in listaComuniAE.Rows) {
				listaAECity.Add(CfgFn.GetNoNullInt32(rAE["idcity"]));
			}
			foreach (DataRow rDb in DS.geo_city_codeview.Rows) {
				string titleDb = rDb["title"].ToString();
				string nazionale = rDb["nazionale"].ToString();
				string provincia = rDb["provincecode"].ToString();
				int idcity = CfgFn.GetNoNullInt32(rDb["idcity"]);

				if (rDb["newcity"] == DBNull.Value && rDb["stop"]==DBNull.Value) {
					
					//Cerca una corrispondenza in AE
					if (!listaAECity.Contains(idcity)) {
						sb.AppendLine(
							$"Il comune id:{rDb["idcity"]} {titleDb} ({nazionale})  ({provincia}) nel db non è stato trovato nella lista AE ");
					}
				}
				else {
					if (listaAECity.Contains(idcity)) {
						sb.AppendLine(
							$"Il comune id:{rDb["idcity"]} {titleDb} ({nazionale})  ({provincia}) nel db  è stato trovato nella lista AE ma non avrebbe dovuto");
					}
				}
			}

			txtResult.Text = sb.ToString();
		}

		private void btnCambioProvincia_Click(object sender, EventArgs e) {
			string txt = txtResult.Text;
			int idcity = CfgFn.GetNoNullInt32(txt.Split(';')[0].Trim());
			string province = txt.Split(';')[1].Trim();
			DateTime data = (DateTime) HelpForm.GetObjectFromString(typeof(DateTime), txt.Split(';')[2].Trim(),"g");
			var rc = DS.geo_country.Filter(q.eq("province", province)).FirstOrDefault();
			var idcountry = rc["idcountry"];
					
			var rigaCorrente = DS.geo_city_codeview.Filter(q.eq("idcity", idcity)).FirstOrDefault();
			if (rigaCorrente["newcity"]!=DBNull.Value) {
				show("Il comune indicato è stato già sostituito da altri", "Errore");
				return;
			}

			txtResult.Text += cambiaProvincia(idcity,data,idcountry);

		}

		private void btnFileAliquoteComunali_Click(object sender, EventArgs e) {
			btnFileAliquoteComunali.Visible = false;
			try {
				var res = askFileName.ShowDialog(this);
				if (res != DialogResult.OK) return;

				var fileName = askFileName.FileName;

				DataTable t = null;
				if (fileName.EndsWith("xls") || fileName.EndsWith("xlsx") || fileName.EndsWith("csv")) {
					try {
						t = readAliquoteComunali(fileName);
						if (t == null) return;

					}
					catch (Exception ex) {
						show(this, $"Errore nell\'apertura del file! Processo Terminato\n{ex.Message}");
						return;
					}
				}
				else {
					show("Il file deve avere formato xls, xlsx o csv", "Errore");
					return;
				}

				txtFileAliquoteComunali.Text = askFileName.FileName;
				listaAliquote = t;
			}
			finally {
				btnFileAliquoteComunali.Visible = true;
			}
		}

		private DataTable readAliquoteComunali(string fileName) {
			Dictionary<int,DataRow> esenzioniAggiuntive = new Dictionary<int, DataRow>();
			var dtToImport = new DataTable();
			var header =
				"CODICE_CATASTALE;COMUNE;PR;NUMERO_DELIBERA;DATA_DELIBERA;DATA_PUBBLICAZIONE;NOTE;MULTIALIQ;ALIQUOTA;FASCIA;ALIQUOTA_2;FASCIA_2;ALIQUOTA_3;FASCIA_3;ALIQUOTA_4;FASCIA_4;ALIQUOTA_5;FASCIA_5;ALIQUOTA_6;FASCIA_6;" +
				"ALIQUOTA_7;FASCIA_7;ALIQUOTA_8;FASCIA_8;ALIQUOTA_9;FASCIA_9;ALIQUOTA_10;FASCIA_10;ALIQUOTA_11;FASCIA_11;" +
				"ALIQUOTA_12;FASCIA_12;FLAG_NUOVA;IMPORTO_ESENTE";
			foreach (string colName in header.Split(';')) {
				dtToImport.Columns.Add(colName, typeof(string));
			}

			var culture = new CultureInfo("en-US");
			int maxcolumns = 12;
			readFileGenerico(dtToImport, fileName);
			dtToImport.Columns.Add("start", typeof(DateTime));
			dtToImport.Columns.Add("data_delib", typeof(DateTime));
			dtToImport.Columns.Add("data_pubb", typeof(DateTime));
			dtToImport.Columns.Add("idcity", typeof(int));
			dtToImport.Columns.Add("idcountry", typeof(int));
			dtToImport.Columns.Add("idtaxratecitystart", typeof(int));
			dtToImport.Columns.Add("annotations", typeof(string));
			dtToImport.Columns.Add("toinsert", typeof(string));
			dtToImport.Columns.Add("enforcement", typeof(string));
			for (int i = 1; i <= maxcolumns; i++) {
				dtToImport.Columns.Add("limit" + i.ToString(), typeof(decimal));
				dtToImport.Columns.Add("rate" + i.ToString(), typeof(decimal));
			}
			StringBuilder sb = new StringBuilder();
			dtToImport.Columns.Add("esente", typeof(decimal));
			dtToImport.Columns["COMUNE"].ColumnName = "title";
			dtToImport.Columns["FASCIA"].ColumnName = "FASCIA_1";
			dtToImport.Columns["CODICE_CATASTALE"].ColumnName = "nazionale";

			//delete from add2018   where data_pubblicazione is  null and aliquota='0*'
			foreach (DataRow r in dtToImport.Rows) {
				string aliquota = r["ALIQUOTA"].ToString().Trim();
				if (r["DATA_PUBBLICAZIONE"].ToString().Trim() == "" && (  aliquota=="" || aliquota== "0*")) r.Delete();
			}

			dtToImport.AcceptChanges();

			/*
			 * 
								update add2018  set fascia = replace(fascia,'"',''),
								fascia_2 = replace(fascia_2,'"',''),
								fascia_3 = replace(fascia_3,'"',''),
								fascia_4 = replace(fascia_4,'"',''),
								fascia_5 = replace(fascia_5,'"',''),
								fascia_6 = replace(fascia_6,'"','')
								/*
			 * 
				update add2018 set fascia = replace(fascia,',','.') where  fascia like 'esenzione per redditi fino a euro%' and fascia like '%,00'
				update add2018 set fascia = replace(fascia,',','.') where  fascia like 'esenzione per redditi fino a euro%' and fascia like '%,99'				
				update add2018 set fascia = fascia +'0' where  fascia like '%.0'
				
				--ripetere più volte
				update add2018 set fascia = replace(fascia,'  ',' ') 
			 */


			foreach (DataRow r in dtToImport.Rows) {
				if (r["title"].ToString() == "BARANELLO") {
					int h = 1;
				}
				for (int i = 1; i <= maxcolumns; i++) {
					string fascia = r["FASCIA_" + i.ToString()].ToString();
					fascia = fascia.Replace("\"", "").Replace("  ", " ").Replace("  ", " ").Replace("  ", " ").Replace("  ", " ");
					fascia = fascia.Replace("Applicabile a tutti i casi escluso gli esenti", "aliquota unica");
					if (fascia.ToLowerInvariant().StartsWith("esenzione per redditi fino a euro")) {
						if (fascia.EndsWith(",00") || fascia.EndsWith(",99")) fascia = fascia.Replace(',', '.');
					}

					if (fascia.EndsWith(".0")) fascia += "0";
					r["FASCIA_" + i.ToString()] = fascia.Trim();
				}
			}


			/*
			 * 
				update add2018 set importo_esente = null where rtrim(ltrim(importo_esente))=''
				update add2018 set importo_esente = null where importo_esente='0'
				update add2018 set importo_esente = replace(importo_esente,',','.')
				update add2018 set importo_esente = importo_esente+'.00' where not importo_esente like '%.__'
				update add2018 set importo_esente = ltrim(rtrim(importo_esente))
			 */
			/*
		
		 */

			foreach (DataRow r in dtToImport.Rows) {
				if (r["IMPORTO_ESENTE"] == DBNull.Value) continue;
				string esente = r["IMPORTO_ESENTE"].ToString().Trim();
				if (esente == "0") {
					esente = "";
				}

				if (esente == "") {
					r["IMPORTO_ESENTE"] = DBNull.Value;
					continue;
				}

				esente = esente.Replace(',', '.');
				if (!esente.Contains(".")) esente += ".00";
				r["IMPORTO_ESENTE"] = esente.Trim();
				r["esente"] = Convert.ToDecimal(r["IMPORTO_ESENTE"], culture);
			}


			/*
			 * 
			update add2018 set fascia = replace(fascia,substring(importo_esente,1,len(importo_esente)-3),importo_esente) 
					where  fascia like 'esenzione per redditi fino a euro%' 
					and not fascia like '%'+importo_esente+'%'
					and fascia like '%'+substring(importo_esente,1,len(importo_esente)-3)+'%'

			--questa non deve dare righe
			select * from add2018 where (fascia like 'Esenzione%' or fascia like 'Applicabile%') and esente =0
			--questa non deve dare righe
			select * from add2018 where esente >0 and fascia not like 'Esenzione%'  and fascia not like 'Applicabile%'			

			 */
			//Sistema solo la fascia in alcuni casi particolari
			foreach (DataRow r in dtToImport.Rows) {
				if (r["nazionale"].ToString() == "G822") {
					int x = 1;
				}

				if (r["FASCIA_1"] != DBNull.Value) {
					string fascia = r["FASCIA_1"].ToString().Trim().ToLowerInvariant();
					string esente = r["IMPORTO_ESENTE"].ToString().Trim();
					if (esente == "") {
						continue; //Per es. è "fascia unica" senza esenzione
					}

					string esenteInt = esente.Substring(0, esente.Length - 3);
					if (fascia.StartsWith("esenzione per redditi fino a euro") && (!fascia.Contains(esente)) &&
					    fascia.Contains(esenteInt)) {
						fascia = fascia.Replace(esenteInt, esente);
						r["FASCIA"] = fascia;
					}
				}

				if (r["IMPORTO_ESENTE"] != DBNull.Value &&
				    (!r["FASCIA_1"].ToString().EndsWith(r["IMPORTO_ESENTE"].ToString()))) {
					sb.AppendLine(
						$"Il comune {r["title"]} ha una fascia errata: {r["FASCIA_1"]}, importo esente:{r["IMPORTO_ESENTE"]}");
				}

			}


			foreach (DataRow r in dtToImport.Rows) {
				
				if (r["nazionale"].ToString() == "I177") {
					int x = 1;
				}

				decimal esenteOriginale = CfgFn.GetNoNullDecimal(r["esente"]);
				decimal esente = esenteOriginale;
				for (int i = 1; i <= maxcolumns; i++) {
					string fascia = r[$"FASCIA_{i}"].ToString().Trim().ToLowerInvariant();
					if (fascia.Contains("residenti")) continue;

					if (fascia.StartsWith("applicabile")) {
						esente = calcolaImportoEsenteDaDescrizione(fascia); // il limite inferiore funge da esenzione 
						if (esente > 0 && esente < 1000) {
							sb.AppendLine(
								$"Importo esente strano trovato descrizione fascia {fascia} e importo  {esente} su comune {r["title"]}");
						}
						if (i == 1) {
							if (esenteOriginale == 0) {
								r["esente"] = esente;
							}
							else {
								if (esenteOriginale != esente) {
									sb.AppendLine(
										$"Incoerenza con descrizione fascia {fascia} e importo esenzione {esenteOriginale} su comune {r["title"]}");
								}
							}
						}

						continue;
					}

					if (!isFasciaEsenzioneNormale(fascia))continue;
					//if (esente != 0) continue; //l'esenzione la valorizziamo una sola volta, cerchiamo di farlo una volta e bene

					
						decimal nuovoesente = calcolaImportoEsenteDaDescrizione(fascia); // il limite inferiore funge da esenzione 
						if (nuovoesente > 0 && nuovoesente < 1000 && r["title"].ToString()!="CASATISMA") {
							sb.AppendLine(
								$"Importo esente strano trovato descrizione fascia {fascia} e importo  {nuovoesente} su comune {r["title"]}");
						}

						if (nuovoesente > esente) {
							if (esente > 0) {
								int y = 1;
							}
							esente = nuovoesente;
						}
						r["esente"] = esente;
					

					

				}
			}



			foreach (DataRow r in dtToImport.Rows) {
				if (r["DATA_PUBBLICAZIONE"].ToString() != "") {
					//update  add2018 set data_pubblicazione = null where data_pubblicazione <= '01-01-1950'
					DateTime d = (DateTime) HelpForm.GetObjectFromString(typeof(DateTime),
						r["DATA_PUBBLICAZIONE"].ToString().Split(' ')[0], "g");
					if (d.Year > 1950) r["data_pubb"] = d;
				}

				if (r["DATA_DELIBERA"].ToString() != "") {
					//update  add2018 set data_delibera = null where data_delibera <= '01-01-1950'
					DateTime d = (DateTime) HelpForm.GetObjectFromString(typeof(DateTime),
						r["DATA_DELIBERA"].ToString().Split(' ')[0], "g");
					if (d.Year > 1950) r["data_delib"] = d;
				}

				string nDelibera = "";
				if (r["NUMERO_DELIBERA"].ToString() != "") {
					nDelibera = "n." + r["NUMERO_DELIBERA"].ToString();
				}

				string del = "";
				if (r["data_delib"] != DBNull.Value) {
					var d = (DateTime) r["data_delib"];
					del = $" del {d.Day}/{d.Month}/{d.Year}";
				}

				string pubblicata = "";
				
				if (r["data_pubb"] != DBNull.Value) {
					var d = (DateTime) r["data_pubb"];
					pubblicata = $" pubblicata il {d.Day}/{d.Month}/{d.Year}";
				}

				string note = "";
				if (r["NOTE"].ToString() != "") {
					note = r["NOTE"].ToString() + " - ";
				}

				r["annotations"] = $"{note}delibera {nDelibera}{del}{pubblicata} ";

				/*				 
					update add2018 set rate= convert(decimal(19,6),replace(aliquota,',','.')) 
					update add2018 set rate2= convert(decimal(19,6),round(replace(aliquota_2,',','.'),6)) where ltrim(rtrim(aliquota_2))<>'' and  isnumeric(aliquota_2) =1
					update add2018 set rate3= convert(decimal(19,6),round(replace(aliquota_3,',','.'),6)) where ltrim(rtrim(aliquota_3))<>'' and  isnumeric(aliquota_3) =1
					update add2018 set rate4= convert(decimal(19,6),round(replace(aliquota_4,',','.'),6)) where ltrim(rtrim(aliquota_4))<>'' and  isnumeric(aliquota_4) =1
					update add2018 set rate5= convert(decimal(19,6),round(replace(aliquota_5,',','.'),6)) where ltrim(rtrim(aliquota_5))<>'' and  isnumeric(aliquota_5) =1
					update add2018 set rate6= convert(decimal(19,6),round(replace(aliquota_6,',','.'),6)) where ltrim(rtrim(aliquota_6))<>'' and  isnumeric(aliquota_6) =1
			
					update add2018 set rate=rate/100
					update add2018 set rate2=rate2/100
					update add2018 set rate3=rate3/100
					update add2018 set rate4=rate4/100
					update add2018 set rate5=rate5/100
					update add2018 set rate6=rate6/100

				 */



			}

			foreach (DataRow r in dtToImport.Rows) {
				foreach (var d in new Dictionary<string, string>() {
					{"aliquota", "rate1"}, {"aliquota_2", "rate2"}, {"aliquota_3", "rate3"}, {"aliquota_4", "rate4"},
					{"aliquota_5", "rate5"}, {"aliquota_6", "rate6"}, {"aliquota_7", "rate7"}, {"aliquota_8", "rate8"}
					, {"aliquota_9", "rate9"}, {"aliquota_10", "rate10"}, {"aliquota_11", "rate11"}, {"aliquota_12", "rate12"}
				}) {
					var ali = r[d.Key];
					if (ali.ToString() == "") continue;
					ali = ali.ToString().Replace(',', '.');
					var dec = Convert.ToDecimal(ali, culture);
					if (dec >= 1 || (dec != 0.0M && dec < 0.01M)) {
						sb.AppendLine(
							$"Aliquota anomala:{ali} di valore {dec} per comune {r["title"]} ({r["nazionale"]})");
					}

					r[d.Value] = dec / 100.0M;

				}
			}


			

			foreach (DataRow r in dtToImport.Rows) {
				
				string provincia = r["PR"].ToString().Trim();
				var rc = DS.geo_country.Filter(q.eq("province", provincia)).FirstOrDefault();
				if (rc == null) {
					show($"Comune {r["title"]}: provincia {provincia} non trovata", "Errore");
					continue;
				}

				r["idcountry"] = rc["idcountry"];

				
				object dStart = r["data_pubb"];
				if (dStart == DBNull.Value) {
					sb.AppendLine($"Comune {r["title"]} Codice nazionale: {r["nazionale"]} senza data pubblicazione, ALIQUOTA:{r["ALIQUOTA"]}");
					continue;
				}

				var idcity = getIdCity(r["nazionale"].ToString(), (DateTime) dStart) ?? DBNull.Value;
					
					//DS.geo_city_codeview.Filter(q.eq("nazionale", r["nazionale"].ToString()))._Filter(q.nullOrLe("start", dStart))
					//            .OrderBy(x => {
					//	            if (x["start"] != DBNull.Value) return x["start"];
					//				if (x["newcity"]!=DBNull.Value) return new DateTime(1000, 1, 1);
					//	            return new DateTime(1001, 1, 1);
					//            }).Reverse()
					//	.FirstOrDefault()?["idcity"] ?? DBNull.Value;
				if (r["nazionale"].ToString()=="G221") {
					int x = 1;
				}
					//getIdCity(r["nazionale"].ToString(), provincia, true) ?? DBNull.Value;
				if (idcity == DBNull.Value) {
					sb.AppendLine($"Comune {r["title"]} ({r["nazionale"]}) Data pubblicazione: {dStart} non trovato in geo_city_codeview");
					//MetaFactory.factory.getSingleton<IMessageShower>().Show($"Codice nazionale: {r["nazionale"]} non trovato in geo_city_codeview", "Errore");
					continue;
				}

				r["idcity"] = idcity;
			}


			//update add2018 set limit1 = 0,limit2 = 0,limit3=0,limit4=0,limit5=0,limit6=0 where fascia = 'Aliquota unica'
			foreach (DataRow r in dtToImport.Rows) {
				string fascia = r["FASCIA_1"].ToString().Trim().ToLowerInvariant();
				if (fascia == "aliquota unica") {
					for (int i = 1; i <= maxcolumns; i++) {
						r[$"limit{i}"] = 0;
					}
				}

			}

			//Queste righe vanno ridotte alle sole che si vogliano imputare alla gestione manuale
			//select codice_catastale,fascia,esente from add2018 where fascia_2= 'Aliquota unica' and esente is null 
			foreach (DataRow r in dtToImport.Rows) {
				string fascia2 = r["FASCIA_2"].ToString().Trim().ToLowerInvariant();
				if (fascia2 != "aliquota unica") continue;
				decimal esente = CfgFn.GetNoNullDecimal(r["esente"]);
				if (esente != 0) continue;
				string fascia = r["FASCIA_1"].ToString().Trim().ToLowerInvariant();
				if (!isFasciaEsenzioneNormale(fascia)) continue;
				//if (fascia.Contains("pensione") || fascia.Contains("figli") || fascia.Contains("disoccupazione") ||
				//    fascia.Contains("pensioni") || fascia.Contains("ultrasettan") ||
				//	fascia.Contains("ultrassessantacinquenni") ||
				//	fascia.Contains(" 65 anni ")||
				//    fascia.Contains(" familiare ")||
				//    fascia.Contains("ultrasessan") || fascia.Contains("trasferiscono la loro residenza")) continue;
				sb.AppendLine($"Il comune {r["title"]} ha aliquota unica in seconda fascia ed una fascia da verificare:{fascia}");
			}

			//questa non deve dare righe
			//select * from add2018 where fascia_2= 'Aliquota unica' and esente>0 and (rate<>0 or rate2=0 or  rate3<>0 or rate4<>0 or rate5<>0 or rate6<>0)
			foreach (DataRow r in dtToImport.Rows) {
				string fascia2 = r["FASCIA_2"].ToString().Trim().ToLowerInvariant();
				if (fascia2 != "aliquota unica") continue;
				decimal esente = CfgFn.GetNoNullDecimal(r["esente"]);
				if (esente != 0) continue;
				string fascia = r["FASCIA_1"].ToString().Trim().ToLowerInvariant();
				if (CfgFn.GetNoNullDecimal(r["rate1"]) != 0) {
					if (!(fascia.Contains("redditi da pensione") ||
					      fascia.Contains("trasferiscono la loro residenza"))) {
						sb.AppendLine($"Il comune {r["title"]} non dovrebbe avere aliquota1<>0 ");
					}
				}

				if (CfgFn.GetNoNullDecimal(r["rate2"]) == 0)sb.AppendLine($"Il comune {r["title"]} non dovrebbe avere aliquota2=0 ");
				if (CfgFn.GetNoNullDecimal(r["rate3"]) != 0)sb.AppendLine($"Il comune {r["title"]} non dovrebbe avere aliquota3<>0 ");
				if (CfgFn.GetNoNullDecimal(r["rate4"]) != 0)sb.AppendLine($"Il comune {r["title"]} non dovrebbe avere aliquota4<>0 ");
				if (CfgFn.GetNoNullDecimal(r["rate5"]) != 0)sb.AppendLine($"Il comune {r["title"]} non dovrebbe avere aliquota5<>0 ");
				if (CfgFn.GetNoNullDecimal(r["rate6"]) != 0)sb.AppendLine($"Il comune {r["title"]} non dovrebbe avere aliquota6<>0 ");
				if (CfgFn.GetNoNullDecimal(r["rate7"]) != 0) sb.AppendLine($"Il comune {r["title"]} non dovrebbe avere aliquota7<>0 ");
				if (CfgFn.GetNoNullDecimal(r["rate8"]) != 0) sb.AppendLine($"Il comune {r["title"]} non dovrebbe avere aliquota8<>0 ");
				if (CfgFn.GetNoNullDecimal(r["rate9"]) != 0) sb.AppendLine($"Il comune {r["title"]} non dovrebbe avere aliquota9<>0 ");
				if (CfgFn.GetNoNullDecimal(r["rate10"]) != 0) sb.AppendLine($"Il comune {r["title"]} non dovrebbe avere aliquota10<>0 ");
				if (CfgFn.GetNoNullDecimal(r["rate11"]) != 0) sb.AppendLine($"Il comune {r["title"]} non dovrebbe avere aliquota11<>0 ");
				if (CfgFn.GetNoNullDecimal(r["rate12"]) != 0) sb.AppendLine($"Il comune {r["title"]} non dovrebbe avere aliquota12<>0 ");
			}

			//questa non dovrebbe dare righe a meno che non siano esenzioni particolari  (1)
			//select * from add2018 where fascia_2= 'Aliquota unica' and (esente is null or esente=0)
			foreach (DataRow r in dtToImport.Rows) {
				string fascia = r["FASCIA_1"].ToString().Trim().ToLowerInvariant();
				string fascia2 = r["FASCIA_2"].ToString().Trim().ToLowerInvariant();
				if (fascia2 != "aliquota unica") continue;
				decimal esente = CfgFn.GetNoNullDecimal(r["esente"]);
				if (esente != 0) continue;
				if (!isFasciaEsenzioneNormale(fascia)) continue;
				if (fascia.Contains("redditi da pensione")) continue;
				if (fascia.Contains("trasferiscono la loro residenza")) continue;
				sb.AppendLine($"Il comune {r["title"]}, fascia={r["FASCIA_1"]} non dovrebbe avere esente=0 ");
			}

			//--se c'è un'esenzione e poi un'aliquota ordinaria, applichiamo l'aliquota su tutto ma poi imposteremo l'esenzione nella struttura
			//update add2018 set limit1 = 0,limit2 =0,rate=rate2, rate2=0 where esente>0 and fascia_2= 'Aliquota unica' and limit1 is null
			//foreach (DataRow r in dtToImport.Rows) {
			//	string fascia2 = r["FASCIA_2"].ToString().Trim().ToLowerInvariant();
			//	if (fascia2 != "aliquota unica") continue;
			//	if (r["limit1"] != DBNull.Value) continue;
			//	decimal esente = CfgFn.GetNoNullDecimal(r["esente"]);
			//	if (esente != 0) continue;
			//	r["limit1"] = 0;
			//	r["limit2"] = 0;
			//	r["rate1"] = r["rate2"];
			//	r["rate2"] = 0;
			//}

			//update add2018 set limit1 = null,limit2 =null,rate2=0 where esente>0 and fascia_2= 'Aliquota unica' and limit1 =0  correggo situazioni anomale in cui limit1=0 ma dovrebbe essere null
			//foreach (DataRow r in dtToImport.Rows) {
			//	string fascia2 = r["FASCIA_2"].ToString().Trim().ToLowerInvariant();
			//	if (fascia2 != "aliquota unica") continue;
			//	decimal esente = CfgFn.GetNoNullDecimal(r["esente"]);
			//	if (esente == 0) continue;
			//	if (r["limit1"] == DBNull.Value) continue;
			//	if (CfgFn.GetNoNullDecimal(r["limit1"]) != 0) continue;
			//	sb.AppendLine(
			//		$"correggo situazioni anomale in cui limit1=0 ma dovrebbe essere null: {r["title"]} fascia2={r["FASCIA_2"]}");
			//	r["limit1"] = DBNull.Value;
			//	r["limit2"] = DBNull.Value;
			//	r["rate2"] = 0;
			//}


			//select esente,fascia,rate,rate2,limit1 from add2018 where fascia_2= 'Applicabile a aliquota ordinaria' and esente>0  and limit1 is null
			//	--altra interpretazione possibile in questo caso, nel caso in cui si consideri l'esenzione anche come quota esente
			//	---    update add2018 set limit1 = esente ,limit2 =0,rate=rate2, rate2=0 where esente>0 and fascia_2= 'Aliquota ordinaria'


			//--in questo caso abbiamo esenzioni di tipo strano, facciamo finta che l'esenzione non esista e per il resto ci comportiamo come nel caso precedente
			// devono essere i casi che abbiamo identificato nel caso precedente (1)
			//select * from add2018 where esente is null and fascia_2= 'Aliquota unica' and limit1 is null
			//update add2018 set limit1 = 0,limit2 =0,rate=rate2, rate2=0 where esente is null and fascia_2= 'Aliquota unica' and limit1 is null 
			//foreach (DataRow r in dtToImport.Rows) {
			//	string fascia2 = r["FASCIA_2"].ToString().Trim().ToLowerInvariant();
			//	if (fascia2 != "aliquota unica") continue;
			//	decimal esente = CfgFn.GetNoNullDecimal(r["esente"]);
			//	if (esente != 0) continue;
			//	r["limit1"] = 0;
			//	r["limit2"] = 0;
			//	r["rate1"] = r["rate2"];
			//	r["rate2"] = 0;
			//}

			//select esente,fascia,rate,rate2,limit1 from add2018 where fascia_2= 'Applicabile a aliquota ordinaria' and esente>0  and limit1 is null
			foreach (DataRow r in dtToImport.Rows) {
				string fascia2 = r["FASCIA_2"].ToString().Trim().ToLowerInvariant();
				if (fascia2 != "applicabile a aliquota ordinaria") continue;
				decimal esente = CfgFn.GetNoNullDecimal(r["esente"]);
				if (esente == 0) continue;
				if (CfgFn.GetNoNullDecimal(r["limit1"]) == 0) {
					sb.AppendLine($"Il comune {r["title"]}, fascia={r["FASCIA_1"]} non dovrebbe avere limit1=0 ");
				}

			}
			
			//Calcola le varie fasce, in particolare:
			//Se inizia con "esenzione", vai avanti, è una gestione già fatta nei passi precedenti 
			//se finisce con "fino ad euro" si intende che il limite superiore è quello dopo tale  espressione. Quello inferiore è il superiore prec.
			//Se inizia con "da euro " si intende che quel che segue è il limite inferiore+1cent, che dovrebbe essere iug
			//se finisce con "oltre euro" si intende che il limite superiore non è presente. Quello inferiore è il superiore prec.
			foreach (DataRow r in dtToImport.Rows) {
				decimal esente = CfgFn.GetNoNullDecimal(r["esente"]);
				decimal limitePrecedente = 0;
				int ultimaFasciaValorizzata = 0;
				bool aliquotaUnicaTrovata = false;
				for (int i = 1; i <= maxcolumns; i++) {
					string fascia = r[$"FASCIA_{i}"].ToString().Trim().ToLowerInvariant();
					if (fascia == "") {
						if (CfgFn.GetNoNullDecimal(r[$"rate{i}"]) != 0) {
							sb.AppendLine($"Il comune {r["title"]} ha una aliquota valorizzata ({r[$"rate{i}"]}) in una fascia vuota: fascia_{i} ");
						}
						continue;
					}
					if (aliquotaUnicaTrovata) {
						sb.AppendLine(
							$"Il comune {r["title"]} ha una fascia valorizzata dopo l'aliquota unica: fascia_{i} = {fascia}");
					}
					if (fascia == "aliquota unica") {

						if (ultimaFasciaValorizzata!= 0) {
							sb.AppendLine(
								$"Il comune {r["title"]} ha una aliquota valorizzata prima dell'aliquota unica: fascia_{i} = {fascia}");
						}

						for (int k = i+1; k<=6; k++) {
							if (CfgFn.GetNoNullDecimal(r[$"rate{k}"]) != 0) {
								sb.AppendLine($"Il comune {r["title"]} ha una aliquota valorizzata dopo dell'aliquota unica: fascia_{k} = {fascia}");
							}
						}
						aliquotaUnicaTrovata = true;
						continue;
					}

					if (fascia.Contains("residenti")||fascia.Contains("redditi da pensione")||fascia.StartsWith("esenzione")) {
						if (fascia.StartsWith("esenzione")) {
							if (CfgFn.GetNoNullDecimal(r[$"rate{i}"]) != 0) {
								sb.AppendLine($"Il comune {r["title"]} ha una aliquota valorizzata ({r[$"rate{i}"]}) in una fascia di esenzione: fascia_{i} = {fascia}");
							}
						}
						else {
							if (CfgFn.GetNoNullDecimal(r[$"rate{i}"]) == 0) {
								sb.AppendLine($"Il comune {r["title"]} ha aliquota nulla in una fascia non di esenzione: fascia_{i} = {fascia}");
							}
						}
						if (ultimaFasciaValorizzata > 0) {
							sb.AppendLine(
								$"Il comune {r["title"]} ha una fascia di esenzione dopo una non di esenzione: fascia_{i} = {fascia}");
						}

						continue;
					}
					
					string fasciaOriginale = fascia;
					bool prefixFound = false;
					fascia = fascia.Replace("applicabile a applicabile", "applicabile a ");
					fascia = fascia.Replace("applicabile a  a ", "applicabile a ");
					fascia = fascia.Replace("applicabile a a ", "applicabile a ");
					foreach (var prefix in new Dictionary<string,string>() {
						{"applicabile a scaglione di reddito ","applicabile a scaglione di reddito"},
						{ "applicabile a scaglioni di reddito da", "applicabile a scaglioni di reddito"},
						{ "applicabile a scaglione da","applicabile a scaglione" },
						{ "applicabile a scaglioni di reddito oltre ","applicabile a scaglioni di reddito" },
						{ "applicabile a fino a", "applicabile a fino"},
						{ "applicabile a scaglione irpef da","applicabile a scaglione irpef" },
						{ "applicabile a reddito imponibile da","applicabile a reddito imponibile" },
						{ "applicabile a oltre","applicabile a"},
						{ "applicabile a scaglione oltre","applicabile a scaglione" },
						{ "applicabile a da ", "applicabile" },
						{ "applicabile a reddito imponibile oltre","applicabile a reddito imponibile" },
						{ "applicabile a fasce di reddito da", "applicabile a fasce di reddito" },
						{ "applicabile a fasce di reddito oltre","applicabile a fasce di reddito" },
						{ "applicabile a redditi da euro","applicabile a redditi"},
						{ "applicabile a contribuenti con reddito imponibile fino a","applicabile a contribuenti con reddito imponibile" },
						{ "applicabile a contribuenti con reddito imponibile da","applicabile a contribuenti con reddito imponibile" },
						{ "applicabile a contribuenti con reddito imponibile oltre","applicabile a contribuenti con reddito imponibile" },
						{ "applicabile a redditi fino a ","applicabile a redditi"},
						{ "applicabile a redditi da ","applicabile a redditi" },
						{ "applicabile a redditi oltre","applicabile a redditi" },
						{ "applicabile a contribuenti con reddito","applicabile a contribuenti con reddito" }
					}) {
						if (fascia.StartsWith(prefix.Key)) {
							fascia = fascia.Substring(prefix.Value.Length);
							prefixFound = true;
							break;
						}
					}

					if (!prefixFound) {
						sb.AppendLine($"Il comune {r["title"]} ha una fascia non riconosciuta fascia_{i} = {fascia}");
						continue;
					}

					
					int _da_position = fascia.IndexOf(" da ");
					if (_da_position<0)_da_position = fascia.IndexOf(" oltre ");
					if (_da_position<0)_da_position = fascia.IndexOf(" tra ");
					if (_da_position<0)_da_position = fascia.IndexOf(" maggiore o uguale ");
					if (_da_position >= 0) {
						fascia = fascia.Substring(_da_position);

						string importoDAStr;
						int posImportoDA = getFirstImportoDontSkipEuro(fascia, out importoDAStr);
						decimal importoDA = getImportoFromStringa(importoDAStr);

						if (ultimaFasciaValorizzata == 0) {
							if (importoDA!=0 && Math.Abs(importoDA-esente)>0.02M &&  importoDA!= esente+1M) {
								sb.AppendLine($"Il comune {r["title"]} ha un limite inferiore (DA) ma non c'è una fascia precedente. fascia_{i} = {fasciaOriginale}");
							}
						}
						else {
							if (Math.Abs(importoDA -limitePrecedente)>0.02M  && importoDA != limitePrecedente + 1M ) {
								sb.AppendLine(
									$"Il comune {r["title"]} ha un limite inferiore (DA/OLTRE) incoerente con il limite superiore precedente. {importoDA}<>{limitePrecedente} fascia_{i} = {fasciaOriginale}");
							}
						}
					}

					if (limitePrecedente!=0 && _da_position<0) {
						sb.AppendLine(
							$"Il comune {r["title"]} ha una fascia senza DA ma ce n'era una prima. fascia_{i} = {fasciaOriginale}");
					}

					int _a_position = fascia.IndexOf(" a ");
					if (_a_position < 0) _a_position = fascia.IndexOf(" fino ");
					if (_a_position < 0) _a_position = fascia.IndexOf(" ad euro ");
					if (_a_position < 0) _a_position = fascia.IndexOf(" ed euro ");
					if (_a_position < 0) _a_position = fascia.IndexOf(" ad â€ ");
					if (_a_position < 0) _a_position = fascia.IndexOf(" ad € ");
					if (_a_position >= 0) {
						string importoAStr;
						int posImportoA = getFirstImportoDontSkipEuro(fascia.Substring(_a_position), out importoAStr);
						limitePrecedente = getImportoFromStringa(importoAStr);
						r[$"limit{i}"] = limitePrecedente;
					}
					if (_a_position>0 && _da_position>0 && _a_position <_da_position ) {
						sb.AppendLine($"Il comune {r["title"]} ha una fascia con un sino A prima di DA/OLTRE . fascia_{i} = {fasciaOriginale}");
					}

					if (_a_position < 0 && _da_position<0) {
						sb.AppendLine(
							$"Il comune {r["title"]} ha una fascia senza A e senza OLTRE e senza DA. fascia_{i} = {fasciaOriginale}");
					}
					
					ultimaFasciaValorizzata = i;
				}
			}
			//Slitta le aliquote dove trova "esente"
			foreach (DataRow r in dtToImport.Rows) {
				if (r["idcity"].ToString() == "14126") {
					int x = 1;
				}
				int searchFirstFase = 0;
				bool allResidenti = true;
				for (int i = 1; i <= maxcolumns; i++) {
					string fascia = r[$"FASCIA_{i}"].ToString().Trim().ToLowerInvariant();
					if (fascia == "aliquota unica") {
						searchFirstFase = i;
						break;
					}

					if (fascia!="" && !fascia.Contains("residenti")) allResidenti = false;
					if (fascia.Contains("residenti") || fascia.Contains("redditi da pensione") || fascia.StartsWith("esenzione")||fascia=="") continue;
					
					searchFirstFase = i;
					break;
				}

				if (searchFirstFase == 0) {
					if (!allResidenti) {
						if (CfgFn.GetNoNullDecimal(r["esente"]) != 0M) {
							esenzioniAggiuntive[CfgFn.GetNoNullInt32(r["idcity"])] = r;
						}

						sb.AppendLine($"Il comune {r["title"]} ({r["nazionale"]}) esenzione:{r["esente"]} idcity={r["idcity"]} è del tutto senza fasce");
						continue;
					}

					decimal max = 0;
					for (int i = 1; i <= maxcolumns; i++) {
						decimal rate = CfgFn.GetNoNullDecimal(r[$"rate{i}"]);
						r[$"rate{i}"] = 0;
						r[$"limit{i}"]=0;
						if (rate > max) max = rate;
					}
					r[$"rate1"] = max;
					searchFirstFase = 1;
				}
				setRateFrom(r,searchFirstFase);

			}

			foreach (var idcity in esenzioniAggiuntive.Keys) {
				var rr = dtToImport._Filter(q.eq("idcity", idcity));

				foreach (var r in rr) {
					if (r != esenzioniAggiuntive[idcity]) {
						r["esente"] = esenzioniAggiuntive[idcity]["esente"];
					}
				}
				esenzioniAggiuntive[idcity].Delete();
				esenzioniAggiuntive[idcity].AcceptChanges();
			}

			txtResult.Text = sb.ToString();
			return dtToImport;
		}

	

		bool isFasciaEsenzioneNormale(string fascia) {
			if (!fascia.StartsWith("esenzione")) return false;
			//incominciamo da quelli sicuri
			foreach (var prefixStart in new string[] {
				"Esenzione per redditi fino a ", "Esenzione per reddito fino a ","Esenzione per redditi fin a",
				"Esenzione per redditi annui inferiori a",
				"Esenzione per redditi uguali o inferiori a",
				"Esenzione per esenzione per reddito da lavoro dipendente",
				"Esenzione per redditi derivanti da lavoro dipendente",
				"Esenzione per i titolari di reddito di pensione e lavoro dipendente",
				"Esenzione per reddito inferiore a",
				"Esenzione per tutte le tipologie di reddito imponibile",
				"esenzione per importi fino ad euro",
				"esenzione per redditi isee inferiori a",
				"esenzione per redditi complessivi annui pari o inferiori a"
				
			}) {
				string p= prefixStart.ToLowerInvariant();
				if (fascia.StartsWith(p))return true;
			}

			foreach (var strContains in new string[] {
				"lavoro dipendente e/o da pensione",
				"esenzione per reddito da lavoro dipendente",
				"esenzione per redditi di pensione o lavoro dipendente",
				"derivante da lavoro dipendente, assimilato o da pensione",
				"conseguano un reddito derivante da lavoro dipendente",
				"conseguono un reddito, derivante da lavoro dipendente o assimilato",
				"derivante esclusivamente da redditi da lavoro dipendente",
				"esclusivamente derivante da lavoro dipendente",
				"da quote derivanti da lavoro dipendente",
				"persone fisiche, da lavoro dipendente e assimilato,",
				"annuo imponibile derivante da lavoro dipendente"
			}) {
				if (fascia.Contains(strContains)) return true;
			}

			if (fascia.Contains("redditi domenicali")) return false;
			if (fascia.Contains("abitazione principale e relative pertinenze")) return false;
			if (fascia.Contains("redditi di terreni")) return false;
			if (fascia.Contains("soggetti con disabilit")) return false;
			if (fascia.Contains("mobilita")) return false;
			if (fascia.Contains("redditi da indennita")) return false;
			if (fascia.Contains("invalidi")) return false;
			if (fascia.Contains("handicap")) return false;
			if (fascia.Contains("componenti familiare")) return false;
			if (fascia.Contains("nucleo familiare")) return false;
			if (fascia.Contains("diverso da quello da pensione e da lavoro dipendente")) return false;
			if (fascia.Contains("ultrassessanta")) return false;
			if (fascia.Contains("esclusivamente di pensione")) return false;
			if (fascia.Contains("ultrasettan")) return false;
			if (fascia.Contains("residenti")) return false;
			if (fascia.Contains("pensioni")) return false;
			if (fascia.Contains("da pensione")) return false;
			if (fascia.Contains("per pensionati")) return false;
			if (fascia.Contains("65 anni")) return false;
			if (fascia.Contains("65enni")) return false;
			if (fascia.Contains("disoccupazione")) return false;
			if (fascia.Contains("figli")) return false;
			if (fascia.Contains("trasferiscono la loro residenza")) return false;

			return true;
		}

		void setRateFrom(DataRow r, int i) {
			int dest=1;
			for (int j = i; j <= 6; j++) {
				dest = j - i + 1; // i diventa 1
				r[$"rate{dest}"] = r[$"rate{j}"];
				r[$"limit{dest}"] = r[$"limit{j}"];
			}

			for (int j = dest + 1; j <= 6; j++) {
				r[$"rate{j}"] = 0;
				r[$"limit{j}"] = 0;
			}
		}

		object NonZeroDecimal(decimal n) {
			if (n == 0) return DBNull.Value;
			return n;
		}
		private void btnAggiornaAliquoteComunali_Click(object sender, EventArgs e) {
			var t2 = DS.taxratecitystartview.Clone();
			Dictionary<int,DataRow> dbRows= new Dictionary<int, DataRow>();
			foreach (DataRow r in DS.taxratecitystartview.Rows) {
				int idcity = toInt(r["idcity"]);
				if (!dbRows.ContainsKey(idcity)) {
					dbRows[idcity] = r;
					continue;
				}
				var rDb = dbRows[idcity];
				var dbStart = (int) rDb["idtaxratecitystart"];
				var rStart= (int) r["idtaxratecitystart"];
				if (dbStart <rStart ) {
					dbRows[idcity] = r;
				}

			}
			Dictionary<int,DataRow> newRows= new Dictionary<int, DataRow>();
			foreach (DataRow r in listaAliquote.Rows) {
				if (r["data_pubb"] == DBNull.Value) continue;
				var dPub = (DateTime) r["data_pubb"];
				var dStart= new DateTime(dPub.Year,1,1);
				if (dPub.Month == 12 && dPub.Day > 20) {
					dStart = new DateTime(dPub.Year+1,1,1);
				}
				else {
					if (dPub.Month > 2 || (dPub.Month == 2 && dPub.Day > 15)) {
						dStart = new DateTime(dPub.Year, 12, 31);
					}
				}

				var n = t2.NewRow();
				n["idcity"] = r["idcity"];
				n["idcountry"] = r["idcountry"];
				n["idtaxratecitystart"] = 1;
				n["city"] = r["title"];
				n["taxref"] = "-";
				n["start"] = dStart;
				n["taxcode"] = 1;
				n["annotations"] = r["annotations"];
				int nAliquote = 0;
				decimal min = CfgFn.GetNoNullDecimal(r["esente"]);
				decimal esente = min;
				n["taxablemin"] = NonZeroDecimal(esente);
				for (int i = 1; i <= 5; i++) {
					decimal rate = CfgFn.GetNoNullDecimal(r[$"rate{i}"]);
					decimal limit = CfgFn.GetNoNullDecimal(r[$"limit{i}"]);
					if (i > 1) n[$"min{i}"] = min;
					n[$"max{i}"] = NonZeroDecimal(limit);
					min = limit;
					n[$"rate{i}"] = NonZeroDecimal(rate);
					if (rate != 0) nAliquote = i;
				}

				if (nAliquote > 1) {
					r["enforcement"] = "P";
				}
				else {
					r["enforcement"] = "F";
				}

				if (!newRows.ContainsKey(toInt(n["idcity"]))) {
					t2.Rows.Add(n);
					newRows[toInt(n["idcity"])] = n;
				}
				
				
				/*
				update add2018 set toinsert='N' 
				update add2018 set toinsert='S' where start is not null and isnull(note,'*') <> 'conferma'
				 */
				
			}

			
			var sb= new StringBuilder();
			sb.AppendLine("--[DBO]--");
			sb.AppendLine();
			foreach (var idCity in newRows.Keys) {
				
				var newRow = newRows[idCity];
				var currStart = (DateTime) newRow["start"];
				string sinthNew = getSintesiAliquote(newRow);

				if (!dbRows.ContainsKey(idCity)) {
					sb.AppendLine($"/*** Nuovo Comune {newRow["city"]} idcity:{idCity} ****/");
					sb.AppendLine($"/*** dati: {currStart} {sinthNew} {newRow["annotations"]} ***/");
					//sb.AppendLine($"La città {newRow["city"]}  id {idCity} non è stata trovata nelle aliquote presenti nel db");
					sb.AppendLine(getScriptNewCityStart(newRow));
					continue;
				}

				if (idCity == 14126) {
					int x = 1;
				}
				var dbRow = dbRows[idCity];
				var dbStart = (DateTime) dbRow["start"];
				string sinthDB = getSintesiAliquote(dbRow);
				if (currStart.Year < dbStart.Year) continue;
				if (sinthDB != sinthNew) {
					if (currStart.CompareTo(dbStart) <= 0) {
						sb.AppendLine($"/*** Correzione Comune {newRow["city"]} idcity:{idCity} ****/");
					}
					else {
						sb.AppendLine($"/*** Aggiornamento Comune {newRow["city"]} idcity:{idCity} ****/");
					}
					sb.AppendLine($"/*** era: {dbStart} {sinthDB} {dbRow["annotations"]} ***/");
					sb.AppendLine($"/*** ora: {currStart} {sinthNew} {newRow["annotations"]} ***/");
					sb.AppendLine(getScriptNewCityStart(newRow));
				}

			}

			txtResult.Text = sb.ToString();
			
		}


		string getSintesiAliquote(DataRow r) {
			string colEsente = "taxablemin";
			//if (!r.Table.Columns.Contains("esente")) colEsente = "taxablemin";
			string sintesi = "";
			for (int i = 1; i <= 5; i++) {
				string fascia = "";
				decimal min = (i>1)? CfgFn.Round( CfgFn.GetNoNullDecimal(r[$"min{i}"]),2) : CfgFn.Round( CfgFn.GetNoNullDecimal(r[colEsente]),2);
				if (i == 1 && min == 0M) min = CfgFn.Round(CfgFn.GetNoNullDecimal(r[$"min{i}"]), 2);

				decimal max = CfgFn.Round( CfgFn.GetNoNullDecimal(r[$"max{i}"]),2);
				decimal rate = CfgFn.Round( CfgFn.GetNoNullDecimal(r[$"rate{i}"]),4);
				if (rate == 0M) continue;
				fascia = min.ToString()+"-";
				
				if (max!=0) fascia +=  max.ToString();
				

				fascia += $"({HelpForm.StringValue(CfgFn.GetNoNullDecimal(rate) ,"x.y.p")})\t";
				sintesi += " " + fascia;
			}

			return sintesi;
		}

		int toInt(object o) {
			return CfgFn.GetNoNullInt32(o);
		}

		string getScriptNewCityStart(DataRow r) {
			StringBuilder sb = new StringBuilder();
			var idcity = (Int32) r["idcity"];
			DataRow[] existentRows = DS.taxratecitystart.get(conn,q.eq("idcity", idcity));
			int maxstart = 0;
			if (existentRows.Count() > 0) {
				maxstart= (int) existentRows.GetMax<int>("idtaxratecitystart");
			}

			var newR = DS.taxratecitystart.newRow();
			newR["idcity"] = idcity;
			newR["idtaxratecitystart"] = maxstart + 1;
			newR["start"] = r["start"];
			newR["taxcode"] = r["taxcode"];
			newR["annotations"] = r["annotations"];
			newR["taxablemin"] = r["taxablemin"];
			newR["enforcement"] = r["enforcement"];
			newR["lt"] = DateTime.Now;
			newR["lu"] = "toolscript" + DateTime.Now.Year.ToString();
			DS.taxratecitystart.Rows.Add(newR);

			sb.AppendLine(conn.getInsertCommand("taxratecitystart",
				new string[] {
					"idcity", "idtaxratecitystart", "start", "taxcode", "annotations",
					"taxablemin", "enforcement", "lt", "lu"
				},
				new string[] {
					sql(newR["idcity"]), sql(newR["idtaxratecitystart"]), sql(newR["start"]), sql(newR["taxcode"]),
					sql(newR["annotations"]),
					sql(newR["taxablemin"]), sql(newR["enforcement"]), sql(newR["lt"]), sql(newR["lu"])
				},
				9
			));

		

			for (int i = 1; i <= 5; i++) {
				decimal rate = CfgFn.GetNoNullDecimal(r[$"rate{i}"]);
				if (rate == 0) break;
				DataRow newB = DS.taxratecitybracket.newRow();
				newB["idcity"] = newR["idcity"];
				newB["idtaxratecitystart"] = newR["idtaxratecitystart"];
				newB["taxcode"] = newR["taxcode"];
				newB["lt"] = DateTime.Now;
				newB["lu"] = "toolscript" + DateTime.Now.Year.ToString();
				newB["nbracket"] = i;
				newB["rate"] = rate;
				newB["minamount"] = r[$"min{i}"];
				newB["maxamount"] = r[$"max{i}"];
				DS.taxratecitybracket.Rows.Add(newB);

				sb.AppendLine(conn.getInsertCommand("taxratecitybracket",
					new string[] {
						"idcity", "idtaxratecitystart", "taxcode", "nbracket", "rate", "minamount", "maxamount",  "lt", "lu"
					},
					new string[] {
						sql(newB["idcity"]), sql(newB["idtaxratecitystart"]), sql(newB["taxcode"]), sql(newB["nbracket"]), sql(newB["rate"]),
						sql(newB["minamount"]), sql(newB["maxamount"]),  sql(newB["lt"]), sql(newB["lu"])
					},
					9
				));


			}
			sb.AppendLine();
			sb.AppendLine();

			return sb.ToString();
		}


	}
		

}
