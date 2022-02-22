
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
using System.Windows.Forms;
using metadatalibrary;
using System.Data;
using System.Collections;
using LiveUpdate;
using System.Text;

namespace EasyInstall
{
	/// <summary>
	/// Summary description for Classificazioni.
	/// </summary>
	public class Classificazioni {
		/// <summary>
		/// Metodo che migra le classificazioni legate al bilancio nelle tabelle standard di classificazione
		/// </summary>
		/// <param name="classificazione">Nome della classificazione</param>
		/// <param name="form">Nome del Form</param>
		/// <param name="sourceConn">Connessione Sorgente</param>
		/// <param name="destConn">Connessione di Destinazione</param>
		/// <param name="htCodiciClass">HashTable che associa i sortcode e gli idsor</param>
		/// <returns>TRUE: Se l'esecuzione dello scrpit è corretta; ELSE: Se si è verificato un errore</returns>
		public static bool migraClass(string classificazione, Form form, DataAccess sourceConn, DataAccess destConn
			,out Hashtable htCodiciClass) {	
			string tipoCodice;
			string codiceTipoClass;
			htCodiciClass = new Hashtable();
			getDescrizioniClassificazioni(classificazione, form,out tipoCodice, out codiceTipoClass);
			DataTable MyClass=destConn.RUN_SELECT("sorting","*",null,"idsorkind="+
				QueryCreator.quotedstrvalue(codiceTipoClass,true),null,false);
			if (MyClass==null) return true;
			foreach(DataRow R in MyClass.Rows){
				htCodiciClass[R["sortcode"]]= R["idsor"];
			}
			return true;
		}

		private static void getDescrizioniClassificazioni(string classificazione, Form form, out string tipoCodice, out string codiceTipoClass) {
			tipoCodice = null;
			codiceTipoClass = null;
			switch (classificazione) {
				case "bilancio": tipoCodice = "class"; codiceTipoClass = "_CLBIL"; break;
				case "murst": tipoCodice = "murst";	codiceTipoClass = "_CLMURST"; break;
				case "consolidamento": tipoCodice = "consolid";	codiceTipoClass = "_CLCONS"; break;
				default: MetaFactory.factory.getSingleton<IMessageShower>().Show(form, "Errore interno: non esiste la tabella class"+classificazione); break;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="classificazione">Parte variabile del nome tabella della classificazione i.e. bilancio -> classbilancio</param>
		/// <param name="ht">HastTable con chiave il sortcode e valore l'idsor</param>
		/// <param name="form"></param>
		/// <param name="tSorting">Tabella della classificazione da ricopiare</param>
		/// <param name="sourceConn">Connessione Sorgente</param>
		/// <param name="destConn">Connessione di Destinazione</param>
		/// <returns>TRUE: Se l'esecuzione non ha avuto problemi; FALSE: Se sono stati riscontrati degli errori</returns>
		public static bool creaRigheInFinSorting(string classificazione, Hashtable ht, Form form, DataAccess sourceConn, DataAccess destConn) {
			string tipoCodice = null;
			string codiceTipoClass = null;
			getDescrizioniClassificazioni(classificazione, form, out tipoCodice, out codiceTipoClass);
			string query = "select "
				+ "idsorkind='"+codiceTipoClass
				+ "', ct=createtimestamp, "
				+ "cu=createuser, "
				+ "idfin=idbilancio, "
				+ "idsor=codice"+tipoCodice
				+ ", lt=lastmodtimestamp, "
				+ "lu=lastmoduser, "
				+ "quota=1 "
				+ "from bilancio "
				+ "where codice"+tipoCodice+" is not null";

			DataTable tFinSorting = Migrazione.eseguiQuery(sourceConn, query, form);
			if (tFinSorting==null) return false;

			foreach(DataRow rFinSorting in tFinSorting.Select()) {
				if (rFinSorting["idsor"] == DBNull.Value) continue;
				if (ht[rFinSorting["idsor"]]==null) {
					MetaFactory.factory.getSingleton<IMessageShower>().Show("La classificazione ("+classificazione+")"+
										rFinSorting["idsor"].ToString()+" non è stata trovata nella tabella "+
										classificazione);
					ht[rFinSorting["idsor"]]=DBNull.Value;
				}
				if (ht[rFinSorting["idsor"]]==DBNull.Value) {
					rFinSorting.Delete();
					continue; //scartato!
				}
				rFinSorting["idsor"] = ht[rFinSorting["idsor"]];
			}
			tFinSorting.AcceptChanges(); //Elimina le righe da saltare

//			if (tFinSorting.Rows.Count > 0) {
//				DialogResult dr = MetaFactory.factory.getSingleton<IMessageShower>().Show(form, "Procedo alla migrazione dei codici di classificazione "
//					+ classificazione + "presenti nella tabella bilancio?", "Conferma", MessageBoxButtons.YesNoCancel);
//				if (dr == DialogResult.No) {
//					return;
//				}
//			}

			DataSet ds = new DataSet();
			tFinSorting.TableName = "finsorting";
			ds.Tables.Add(tFinSorting);
			return Migrazione.lanciaScript(form,destConn, ds, "bilancio -> finsorting("+classificazione+")");
		}

		public static string tabelleSpeciali = "'classbilancio', 'classmurst', 'classconsolidamento'";

		public static bool migraSpeciali(Form form, DataAccess sourceConn, DataAccess destConn) 
		{
			//			Migrazione.copiaTabelle("Copia di tabelle 'Classificazioni'",
			//				tTableSetup, "Classificazioni", tabelleSpeciali, tColName, sourceConn, form, destConn);

			//classbilancio -> sorting, sortinglevel, sortingkind
			Hashtable htCorrispondiCodici;
			bool esecuzioneCorretta = true;

			DialogResult dr = MetaFactory.factory.getSingleton<IMessageShower>().Show(form, "Procedo alla migrazione dei codici di classificazione "
			+ "CLASSBILANCIO presenti nella tabella bilancio?", "Conferma", MessageBoxButtons.YesNoCancel);
			if (dr == DialogResult.Yes) {
				StringBuilder SB1 = Download.LeggiTestoScript("class_bil.sql");
				esecuzioneCorretta=Download.RUN_SCRIPT(destConn,SB1,"Creazione classificazione _CLBIL");				
				if (!esecuzioneCorretta) return false;
				esecuzioneCorretta = migraClass("bilancio", form, sourceConn, destConn, out htCorrispondiCodici);
				if (!esecuzioneCorretta) return false;
				//bilancio -> finsorting
				esecuzioneCorretta = creaRigheInFinSorting("bilancio",htCorrispondiCodici, form, sourceConn, destConn);
				if (!esecuzioneCorretta) return false;
			}

			dr = MetaFactory.factory.getSingleton<IMessageShower>().Show(form, "Procedo alla migrazione dei codici di classificazione "
				+ "CLASSMURST presenti nella tabella bilancio?", "Conferma", MessageBoxButtons.YesNoCancel);
			if (dr == DialogResult.Yes) {
				StringBuilder SB2 = Download.LeggiTestoScript("class_murst.sql");
				esecuzioneCorretta=Download.RUN_SCRIPT(destConn,SB2,"Creazione classificazione _CLMURST");				
				if (!esecuzioneCorretta) return false;
				//classmurst -> sorting, sortinglevel, sortingkind
				esecuzioneCorretta = migraClass("murst", form, sourceConn, destConn, out htCorrispondiCodici);
				if (!esecuzioneCorretta) return false;
				//bilancio -> finsorting
				esecuzioneCorretta = creaRigheInFinSorting("murst", htCorrispondiCodici, form, sourceConn, destConn);
				if (!esecuzioneCorretta) return false;
			}

			dr = MetaFactory.factory.getSingleton<IMessageShower>().Show(form, "Procedo alla migrazione dei codici di classificazione "
				+ "CLASSCONSOLIDAMENTO presenti nella tabella bilancio?", "Conferma", MessageBoxButtons.YesNoCancel);
			if (dr == DialogResult.Yes) {
				StringBuilder SB3 = Download.LeggiTestoScript("class_cons.sql");
				esecuzioneCorretta=Download.RUN_SCRIPT(destConn,SB3,"Creazione classificazione _CLCONS");				
				if (!esecuzioneCorretta) return false;
				//classconsolidamento -> sorting, sortinglevel, sortingkind
				esecuzioneCorretta = migraClass("consolidamento", form, sourceConn, destConn, out htCorrispondiCodici);
				if (!esecuzioneCorretta) return false;
				//bilancio -> finsorting
				esecuzioneCorretta = creaRigheInFinSorting("consolidamento", htCorrispondiCodici, form, sourceConn, destConn);
				if (!esecuzioneCorretta) return false;
			}

			return true;
		}

		public static bool migraClassificazioni(Form form, DataAccess sourceConn, DataAccess destConn, 
			DataTable tTableName, DataTable tColName,
			bool copiaClassificazioniBilancio, bool copiaClassificazioniAnagrafica) 
		{
			bool esecuzioneCorretta;
			if (copiaClassificazioniBilancio) {
				esecuzioneCorretta = migraSpeciali(form, sourceConn, destConn);
				if (!esecuzioneCorretta) return false;
			}

			string tabelleDaNonCopiare = "";

			if (copiaClassificazioniBilancio) {
				if (!copiaClassificazioniAnagrafica) {
					tabelleDaNonCopiare = "'registrysorting'"; //B&&!A
				}
			} else {
				if (copiaClassificazioniAnagrafica) {
					tabelleDaNonCopiare = "'finsorting'";//!B&&A
				} else {
					tabelleDaNonCopiare = "'finsorting', 'registrysorting'";//!B&&!A
				}
			}

			DataRow[] rSpeciali = tTableName.Select("oldtable in ("+tabelleSpeciali+")");
			foreach (DataRow r in rSpeciali) {
				r["copiato"] = "S";
			}
			string filtro = "oldtable not in("
				+ tabelleSpeciali
				+ ") and copiato='N' and tipocopia='copia' and chk like '%Classificazioni%'";

			if (tabelleDaNonCopiare != "") {
				filtro += " AND (newtable not in (" + tabelleDaNonCopiare + "))";
			}

			DataRow[] rTableName = tTableName.Select(filtro);
			foreach (DataRow rTable in rTableName) {
				DataSet ds = new DataSet();
				DataTable t = Migrazione.leggiETraduciTabella(rTable["oldtable"].ToString(), sourceConn, tColName, form);
				if (t==null) return false;
				ds.Tables.Add(t);
				t.TableName = rTable["newtable"].ToString();
				rTable["copiato"] = "S";
				string nomeCopia = "Copia tabella "+t.TableName;
				bool res= Migrazione.lanciaScript(form, destConn, t, nomeCopia);
				if (!res) return false;
			}
			return true;
		}
	}
}
