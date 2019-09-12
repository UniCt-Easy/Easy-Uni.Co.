/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
using metadatalibrary;
using System.Data;
using System.IO;
using generaSQL;
using LiveUpdate;
using System.Windows.Forms;
using funzioni_configurazione;

namespace Install
{
	/// <summary>
	/// Summary description for Patrimonio.
	/// </summary>
	public class Patrimonio
	{
		/// <summary>
		/// Copia la tabella beneinventariabile in asset ponendo idpiece sempre uguale ad uno.
		/// </summary>
		/// <param name="SourceConn"></param>
		/// <param name="Conn"></param>
		/// <returns>true se Ok</returns>
		public static bool esportaBeneinventariabile(Form form, DataAccess SourceConn, DataAccess Conn) {
			string query = "select ct=bene.createtimestamp, cu=bene.createuser, "
				+ "idasset=idbene, idlocation=idubicazione, idman=codiceresponsabile, idpiece=1, "
				+ "lifestart=datacreazione, lt=bene.lastmodtimestamp, lu=bene.lastmoduser, nassetacquire=numcaricobene, "
				+ "ninventory=numinventario, rtf=bene.olenotes, txt=bene.notes, "
				+ "idassetunloadkind=codicetipobuono, yassetunload=esercbuonoinventario, nassetunload=numbuonoinventario, "
                + "flagunload = ISNULL(scarico.flagbuonoinventario,'S') "
				+ "from beneinventariabile bene left outer join scaricobeneinventario scarico "
				+ "on bene.numscaricobene=scarico.numscaricobene";
			string errMsg;
			DataTable tAsset = SourceConn.SQLRunner(query, 0, out errMsg);
			if (errMsg != null) {
				MessageBox.Show(form, errMsg);
				return false;
			}
			tAsset.TableName = "asset";
			//int lastNAssetAcquire = CfgFn.GetNoNullInt32( tAsset.Compute("max(nassetacquire)", null));

			DataSet ds = new DataSet();
			ds.Tables.Add(tAsset);

			DataRow[] rBeniNonCaricati = tAsset.Select("nassetacquire is null");
			if (rBeniNonCaricati.Length > 0) {
				string[,] colonne = { {
					   "idasset", "Id. bene"}, {
					   "nassetacquire", "Num. carico bene"}, {
					   "idlocation", "Id. ubicazione"}, {
					   "idman", "Codice responsabile"}, {
					   "lifestart", "Data creazione"}, {
					   "ninventory","Num. inventario"}, {
					   "idassetunloadkind", "Codice tipo buono"}, {
					   "nassetunload", "Num. buono inventario"},
					  {"yassetunload","Eserc. buono inventario"}};

				new FrmErrore(rBeniNonCaricati, "I seguenti beni non sono stati caricati:", colonne).ShowDialog(form);
			}

			return Migrazione.lanciaScript(form, Conn, ds, "Bene inventariabile -> asset");

			//return lastNAssetAcquire;
		}
		


		/// <summary>
		/// Copia la tabella partenoninventariabile in asset ponendo idasset come selettore ed idpiece 
		/// come campo ad autoincremento.
		/// Inoltre, per ogni bene con parti scaricate ma non caricate, vengono copiate le righe di scaricoparteinventario
		/// in assetacquire con nassetacquire che parte da lastNassetAcquire e ponendo idinv=idclass del carico bene,
		/// ispieceacquire='S' e loadkind='R';
		/// </summary>
		/// <param name="SourceConn"></param>
		/// <param name="Conn"></param>
		/// <returns>max(nassetacquire) scritto in assetacquire</returns>
		public static bool esportaPartenoninventariabile(Form form,
			DataAccess SourceConn, DataAccess Conn, int lastNAssetAcquire) 
		{
			//newlastNAssetAcquire=lastNAssetAcquire;
			string query = "select ct=parte.createtimestamp, cu=parte.createuser,"
				+ "idasset=parte.idbene, idpiece=parte.idparte, "
				+ "lt=parte.lastmodtimestamp, lu=parte.lastmoduser, nassetacquire=parte.numcaricoparte+"
				+ lastNAssetAcquire
				+ ", rtf=parte.olenotes, txt=parte.notes, "
				+ "idassetunloadkind=scarico.codicetipobuono, yassetunload=scarico.esercbuonoinventario, nassetunload=scarico.numbuonoinventario, "
                + "flagunload = ISNULL(scarico.flagbuonoinventario,'S') "
				+ "from partenoninventariabile parte "
				+ "join beneinventariabile bene on bene.idbene=parte.idbene "
				+ "left outer join scaricoparteinventario scarico on parte.numscaricoparte=scarico.numscaricoparte";

			string errMsg;
			DataTable tAsset = SourceConn.SQLRunner(query, 0, out errMsg);
			if (errMsg != null) {
				MessageBox.Show(form, errMsg);
				return false;
			}
			if (tAsset.Rows.Count==0) return true;

			DataRow[] rPartiNonCaricate = tAsset.Select("nassetacquire is null");
			if (rPartiNonCaricate.Length > 0) 
			{
				string[,] colonne = new string[,] { {
					  "idasset", "Id. parte"},
					 {"nassetacquire", "Num. carico parte"},
					 {"idlocation", "Id. ubicazione"},
					 {"idman", "Codice responsabile"},
					 {"lifestart", "Data creazione"},
					 {"ninventory","Num. inventario"},
					 {"idassetunloadkind", "Codice tipo buono"}, {
					  "nassetunload", "Num. buono inventario"},
					  {"yassetunload","Eserc. buono inventario"}};

				new FrmErrore(rPartiNonCaricate, "Le seguenti parti non sono state caricate:", colonne).ShowDialog(form);
			}

			tAsset.TableName = "asset";
			DataSet ds = new DataSet();
			ds.Tables.Add(tAsset);

			Hashtable parti = new Hashtable();
			foreach (DataRow r in tAsset.Rows) {
				object idPiece = parti[r["idasset"]];
				if (idPiece == null) {
					idPiece = 2;
				} else {
					idPiece = 1 + (int)idPiece;
				}
				parti[r["idasset"]] = idPiece;
				r["idpiece"] = idPiece;
			}

			//newlastNAssetAcquire = CfgFn.GetNoNullInt32(tAsset.Compute("max(nassetacquire)", null)) ;

			bool res= Migrazione.lanciaScript(form, Conn, ds, "(partenoninventariabile -> asset) e (scaricoparteinventario -> asset)");
			return res;
		}



		/// <summary>
		/// Copia la tabella aumentovalorebene in assetacquire ponendo idinv=caricobeneinventario.idclass,
		/// idinventory=caricobeneinventario.inventory, ispieceacquire='N', loadkind='R'
		/// e nassetacquire a partire da lastNAssetAcquire+1
		/// </summary>
		/// <param name="SourceConn"></param>
		/// <param name="Conn"></param>
		/// <param name="lastNAssetAcquire"></param>
		/// <returns></returns>
		public static bool esportaAumentoValoreBene(Form form,
			DataAccess SourceConn, DataAccess Conn, int lastNAssetAcquire, out int newlastNAssetAcquire ) 
		{
			newlastNAssetAcquire=lastNAssetAcquire;

			string query = "select adate=aumento.datacontabile, ct=aumento.createtimestamp, cu=aumento.createuser, "
				+ "description=aumento.descrizione, discount=aumento.sconto, "
				+ "flagload=aumento.flagbuonoinventario, idasset=aumento.idbene, "
				+ "idassetloadkind=aumento.codicetipobuono, "
				+ "idinv=idclass, idinventory=codiceinventario, "
				+ "idmot=aumento.codicecausale, "
				+ "ispieceacquire='S', loadkind='N', "
				+ "lt=aumento.lastmodtimestamp, lu=aumento.lastmoduser, "
				//+ "idpiece=null, nassetacquire=null, "
				+ "nassetload=aumento.numbuonoinventario, number=1, rtf=aumento.olenotes, taxable=aumento.imponibile, "
				+ "taxrate=aumento.imposta, txt=aumento.notes, "
				+ "tax=CONVERT(decimal(19,2),ROUND((CONVERT(decimal(19,2),"
				+ "ROUND(ISNULL(aumento.imponibile,0)*(1+ISNULL(aumento.imposta,0))*(1-ISNULL(aumento.sconto,0)),2))"
				+ " - ROUND(ISNULL(aumento.imponibile,0)*(1-ISNULL(aumento.sconto,0)),2)),2)), "
				+ "abatable=0, "
				+ "yassetload=aumento.esercbuonoinventario "
				+ "from aumentovalorebene aumento "
				+ "join beneinventariabile bene on bene.idbene = aumento.idbene "
				+ "join caricobeneinventario carico on carico.numcaricobene = bene.numcaricobene";
			string errMsg;
			DataTable tAssetAcquire = SourceConn.SQLRunner(query, 0, out errMsg);
			if (errMsg != null) {
				MessageBox.Show(form, errMsg);
				return false;
			}
			tAssetAcquire.Columns.Add("idpiece",typeof(int));
			tAssetAcquire.Columns.Add("nassetacquire",typeof(int));

			if (tAssetAcquire.Rows.Count==0) return true;

			Hashtable parti = new Hashtable();
			for (int i=0; i<tAssetAcquire.Rows.Count; i++) {
				DataRow r = tAssetAcquire.Rows[i];
				r["nassetacquire"] = lastNAssetAcquire + i + 1;

				object idPiece = parti[r["idasset"]];
				if (idPiece == null) {
					idPiece = Conn.DO_READ_VALUE("asset", "idasset="+r["idasset"], "max(idpiece)");
				}
				idPiece = 1 + CfgFn.GetNoNullInt32(idPiece);
				parti[r["idasset"]] = idPiece;
				r["idpiece"] = idPiece;
			}
			DataSet ds = new DataSet();
			tAssetAcquire.TableName = "assetacquire";
			ds.Tables.Add(tAssetAcquire);

			DataTable tAsset = ds.Tables.Add("asset");
			foreach (string c in new string[] {"ct","cu","idasset","idpiece","lt","lu","nassetacquire","rtf","txt"}) {
				tAsset.Columns.Add(c, tAssetAcquire.Columns[c].DataType);
			}
			foreach (DataRow s in tAssetAcquire.Rows) {
				DataRow d = tAsset.NewRow();
				foreach (DataColumn c in tAsset.Columns) {
					d[c] = s[c.ColumnName];
				}
				tAsset.Rows.Add(d);
			}

			tAssetAcquire.Columns.Remove("idasset");
			tAssetAcquire.Columns.Remove("idpiece");
			newlastNAssetAcquire = CfgFn.GetNoNullInt32(tAsset.Compute("max(nassetacquire)", null));

			return  Migrazione.lanciaScript(form, Conn, ds, "Aumento valore bene -> Asset acquire");

		}


		/// <summary>
		/// Copia la tabella diminuzionevalorebene in assetacquire ponendo idinv=caricobeneinventario.idclass,
		/// idinventory=caricobeneinventario.inventory, ispieceacquire='N', loadkind='R'
		/// e nassetacquire a partire da lastNAssetAcquire+1
		/// </summary>
		/// <param name="SourceConn"></param>
		/// <param name="Conn"></param>
		/// <param name="lastNassetAcquire"></param>
		public static bool esportaDiminuzioneValoreBene(Form form,
			DataAccess SourceConn, DataAccess Conn, int lastNassetAcquire,out int newlastNAssetAcquire)
		{
			newlastNAssetAcquire=lastNassetAcquire;
			string query = "select adate=diminuzione.datacontabile, ct=diminuzione.createtimestamp, "
				+ "cu=diminuzione.createuser, description=diminuzione.descrizione, "
				+ "discount=diminuzione.sconto, flagload='N', "
				+ "idasset=diminuzione.idbene, idassetunloadkind=diminuzione.codicetipobuono, "
				+ "idinv=idclass, idinventory=codiceinventario, idmot='SCARICO', "
				+ "ispieceacquire='S', loadkind='R', "
				+ "lt=diminuzione.lastmodtimestamp, lu=diminuzione.lastmoduser, "
				//+ "nassetacquire=null"
				//+ lastNassetAcquire
				+ " nassetunload=diminuzione.numbuonoinventario, rtf=diminuzione.olenotes "
				+ ", number= 1 "
				+ ", taxable=diminuzione.imponibile, taxrate=diminuzione.imposta, txt=diminuzione.notes, "
				+ "tax = CONVERT(decimal(19,2),ROUND((CONVERT(decimal(19,2),"
				+ "ROUND(ISNULL(diminuzione.imponibile,0)*(1+ISNULL(diminuzione.imposta,0))*(1-ISNULL(diminuzione.sconto,0)),2))"
				+ " - ROUND(ISNULL(diminuzione.imponibile,0)*(1-ISNULL(diminuzione.sconto,0)),2)),2)), "
				+ "abatable=0, "
				+ "yassetunload=diminuzione.esercbuonoinventario, "
                + "flagunload = ISNULL(diminuzione.flagbuonoinventario,'S') "
				+ "from diminuzionevalorebene diminuzione "
				+ "left outer join beneinventariabile bene on diminuzione.idbene=bene.idbene "
				+ "left outer join caricobeneinventario carico on bene.numcaricobene=carico.numcaricobene";
			string errMsg;
			DataTable tAssetAcquire = SourceConn.SQLRunner(query, 0, out errMsg);
			if (errMsg != null) {
				MessageBox.Show(form, errMsg);
				return false;
			}
			tAssetAcquire.Columns.Add("nassetacquire",typeof(int));
			if (tAssetAcquire.Rows.Count==0) return true;
			tAssetAcquire.Columns.Add("idpiece");

			Hashtable parti = new Hashtable();
			for(int i=0; i<tAssetAcquire.Rows.Count; i++) {
				DataRow r = tAssetAcquire.Rows[i];
				r["nassetacquire"] = lastNassetAcquire + i + 1;

			
				object idPiece = parti[r["idasset"]];
				if (idPiece == null) {
					idPiece = Conn.DO_READ_VALUE("asset", "idasset="+r["idasset"], "max(idpiece)");
				}
				idPiece = 1 + (int)idPiece;
				parti[r["idasset"]] = idPiece;
				r["idpiece"] = idPiece;
			}
			tAssetAcquire.TableName = "assetacquire";
			DataSet ds = new DataSet();
			ds.Tables.Add(tAssetAcquire);

			DataTable tAsset = ds.Tables.Add("asset");
			foreach (string c in new string[] {"ct","cu","idasset","idpiece","lt","lu","nassetacquire","rtf","txt",
											   "idassetunloadkind","yassetunload","nassetunload","flagunload"}) {
				tAsset.Columns.Add(c,tAssetAcquire.Columns[c].DataType);
			}
			foreach (DataRow s in tAssetAcquire.Rows) {
				DataRow d = tAsset.NewRow();
				foreach (DataColumn c in tAsset.Columns) {
					d[c] = s[c.ColumnName];
				}
				tAsset.Rows.Add(d);
			}

//			tAssetAcquire.Columns.Remove("idasset");
//			tAssetAcquire.Columns.Remove("idpiece");
			tAssetAcquire.Columns.Remove("idasset");
			tAssetAcquire.Columns.Remove("idassetunloadkind");
			tAssetAcquire.Columns.Remove("yassetunload");
			tAssetAcquire.Columns.Remove("nassetunload");
			tAssetAcquire.Columns.Remove("idpiece");
            tAssetAcquire.Columns.Remove("flagunload");
		
			newlastNAssetAcquire = CfgFn.GetNoNullInt32(tAsset.Compute("max(nassetacquire)", null)) ;

			return Migrazione.lanciaScript(form, Conn, ds, "Diminuzione valore bene -> Asset acquire");
		}
		
		public static bool esportaCausaleCaricoInventario(Form form, DataAccess sourceConn, DataAccess destConn, DataTable tColName) {
			DataTable tAssetLoadMotive = Migrazione.leggiETraduciTabella("causalecaricoinventario", sourceConn, tColName, form);
			if (tAssetLoadMotive == null) return false;
			if (tAssetLoadMotive.Select("idmot='SCARICO'").Length==0){
				tAssetLoadMotive.TableName = "assetloadmotive";
				DataRow r = tAssetLoadMotive.NewRow();
				r["idmot"] = "SCARICO";
				r["description"] = "PER SCARICO";
				r["flagnewasset"] = "S";
				r["cu"] = "migrazione";
				r["ct"] = DateTime.Now;
				r["lu"] = "migrazione";
				r["lt"] = DateTime.Now;
				tAssetLoadMotive.Rows.Add(r);
			}
			return Migrazione.lanciaScript(form, destConn, tAssetLoadMotive, "causalecaricoinventario -> assetloadmotive");
		}

		/// <summary>
		/// Copia la tabella caricobeneinventario in assetacquire ponendo ispieceacquire='N'
		/// e nassetacquire=numcaricobene
		/// </summary>
		/// <param name="SourceConn"></param>
		/// <param name="Conn"></param>
		
		public static bool esportaCaricoBeneInventario(Form form, DataAccess SourceConn, DataAccess Conn, out int lastNAssetAcquire ) {
			lastNAssetAcquire = 0;
			string query = "select adate=datacontabile, ct=createtimestamp, cu=createuser, "
				+ "description=descrizione, discount=sconto, flagload=flagbuonoinventario, "
				+ "idassetloadkind=codicetipobuono, idinv=idclass, idinventory=codiceinventario, "
				+ "idmot=codicecausale, idreg=codicecreddeb, ispieceacquire='N', loadkind=flagtipocarico, "
				+ "lt=lastmodtimestamp, lu=lastmoduser, nassetacquire=numcaricobene, "
				+ "nassetload=numbuonoinventario, nman=numordine, number=quantita, "
				+ "rownum=numriga, rtf=olenotes, startnumber=numiniziale, "
				+ "tax=CONVERT(decimal(19,2),ROUND((CONVERT(decimal(19,2),"
				+ "ROUND(ISNULL(imponibile,0)*(1+ISNULL(imposta,0))*(1-ISNULL(sconto,0)),2))"
				+ " - ROUND(ISNULL(imponibile,0)*(1-ISNULL(sconto,0)),2))*quantita,2)), "
				+ "taxable=imponibile, txt=notes, yassetload=esercbuonoinventario, "
				+ "taxrate=imposta, idmankind=CASE WHEN numordine is not null then 'GENERALE' else null END, "
				+ "abatable=0, "
				+ "yman=esercordine from caricobeneinventario";
			string errMsg;
			DataTable tAssetAcquire = SourceConn.SQLRunner(query, 0, out errMsg);
			if (errMsg != null) {
				MessageBox.Show(form, errMsg);
				return false;
			}
			if (tAssetAcquire.Rows.Count==0) return true;
			tAssetAcquire.TableName = "assetacquire";
			DataSet ds = new DataSet();
			ds.Tables.Add(tAssetAcquire);
			lastNAssetAcquire = CfgFn.GetNoNullInt32( tAssetAcquire.Compute("max(nassetacquire)", null));
			return  Migrazione.lanciaScript(form, Conn, ds, "Carico bene inventario -> Asset acquire");
		}

		//public static int calcolaMaxNumCaricoBene (Form form, DataAccess SourceConn, DataAccess Conn, DataTable tAssetAcquire){
			
		//}

		/// <summary>
		/// Copia la tabella caricoparteinventario in assetacquire ponendo ispieceacquire='S',
		/// loadkind='R' e nassetacquire a partire da lastNAssetAcquire
		/// </summary>
		/// <param name="SourceConn"></param>
		/// <param name="Conn"></param>
		/// <param name="lastNAssetAcquire"></param>
		public static bool esportaCaricoParteInventario(Form form, DataAccess SourceConn, DataAccess Conn, 
			int lastNAssetAcquire, out int newlastNAssetAcquire) {
			newlastNAssetAcquire = lastNAssetAcquire;
			string query = "select adate=datacontabile, ct=createtimestamp, cu=createuser, "
				+ "description=descrizione, discount=sconto, flagload=flagbuonoinventario, "
				+ "idassetloadkind=codicetipobuono, idinv=idclass, idinventory=codiceinventario, "
				+ "idmot=codicecausale, idreg=codicecreddeb, ispieceacquire='S', loadkind='N', "
				+ "lt=lastmodtimestamp, lu=lastmoduser, nassetacquire=numcaricoparte+"
				+ lastNAssetAcquire
				+ ", nassetload=numbuonoinventario, "
				+ "nman=numordine, number=quantita, rownum=numriga, rtf=olenotes, "
				+ "taxable=imponibile, txt=notes, yassetload=esercbuonoinventario, "
				+ "tax=CONVERT(decimal(19,2),ROUND((CONVERT(decimal(19,2),"
				+ "ROUND(ISNULL(imponibile,0)*(1+ISNULL(imposta,0))*(1-ISNULL(sconto,0)),2))"
				+ " - ROUND(ISNULL(imponibile,0)*(1-ISNULL(sconto,0)),2))*quantita,2)), "
				+ "taxrate=imposta, idmankind=CASE WHEN numordine is not null then 'GENERALE' ELSE null END, "
				+ "abatable=0, "
				+ "yman=esercordine from caricoparteinventario";
			string errMsg;
			DataTable tAssetAcquire = SourceConn.SQLRunner(query, 0, out errMsg);
			if (errMsg != null) {
				MessageBox.Show(form, errMsg);
				return false;
			}
			if (tAssetAcquire.Rows.Count==0) return true;
			tAssetAcquire.TableName = "assetacquire";
			DataSet ds = new DataSet();
			ds.Tables.Add(tAssetAcquire);
			
			newlastNAssetAcquire = CfgFn.GetNoNullInt32(tAssetAcquire.Compute("max(nassetacquire)", null)) ;

			return Migrazione.lanciaScript(form, Conn, ds, "Carico parte inventario -> Asset acquire");
		}



		public static bool controllaParteEBene(Form form, DataAccess SourceConn) {
			string query = "select idparte, idbene from partenoninventariabile where idbene not in (select idbene from beneinventariabile)";
			string messaggio;
			DataTable t = SourceConn.SQLRunner(query, 0, out messaggio);
			if (messaggio != null) {
				MessageBox.Show(form, messaggio);
				return false;
			}
			if (t.Rows.Count > 0) {
				messaggio = "Esistono le seguenti parti che non hanno il corrispondente bene:";
				t.Columns["idparte"].Caption = "Id. parte";
				t.Columns["idbene"].Caption = "Id. bene";
				string domanda = "Si intende procedere lo stesso perdendo tali informazioni?";
				DialogResult dr = new FrmErrore(t, messaggio, domanda).ShowDialog(form);
				if (dr == DialogResult.No) {
					return false;
				}
			}
			return true;
		}

		public static bool controllaAumentoValoreEBene(Form form, DataAccess SourceConn) {
			string query = "select numaumentovalore, idbene from aumentovalorebene where idbene not in (select idbene from beneinventariabile)";
			string messaggio;
			DataTable t = SourceConn.SQLRunner(query, 0, out messaggio);
			if (messaggio != null) {
				MessageBox.Show(form, messaggio);
				return false;
			}
			if (t.Rows.Count > 0) {
				messaggio = "Esistono i seguenti aumenti di valore che non hanno il corrispondente bene:";
				string domanda = "Si intende procedere nella migrazione perdendo tutti gli aumenti di valore "
					+ "che non avevano un corrispondente bene?";
				t.Columns["numaumentovalore"].Caption = "Num. aumento valore";
				t.Columns["idbene"].Caption = "Id. bene";
				DialogResult dr = new FrmErrore(t, messaggio, domanda).ShowDialog(form);
				if (dr == DialogResult.No) {
					return false;
				}
			}
			return true;
		
		}//		public static void controllaScaricoBeneEBene(Form form, DataAccess SourceConn) 

//		{
//			string query = "select * from scaricobeneinventario where numscaricobene not in "
//				+ "(select numscaricobene from beneinventariabile where numscaricobene is not null) "
//				+ " order by numscaricobene";
//			string messaggio;
//			DataTable t = SourceConn.SQLRunner(query, -1, out messaggio);
//			if (messaggio != null) 
//			{
//				MessageBox.Show(form, messaggio);
//				return;
//			}
//			if (t.Rows.Count > 0) 
//			{
//				messaggio = "Esistono i seguenti scarichi che non hanno corrispondenti beni:";
//				string[,] colonne = new string[,] { 
//					{"numscaricobene", "Num. scarico bene"},
//					{"descrizione", "Descrizione"},
//					{"codiceinventario", "Codice inventario"},
//					{"codicetipobuono", "Codice tipo buono"},
//					{"esercbuonoinventario", "Eserc. buono inventario"},
//					{"numbuonoinventario", "Num. buono inventario"}};
//				new FrmErrore(messaggio, t.Select(), colonne).ShowDialog(form);
//			}
//		}

		public static bool controllaScaricoBeneEBuono(Form form, DataAccess SourceConn) {
			string query = "select scarico.numscaricobene, scarico.descrizione, scarico.codiceinventario, scarico.codicetipobuono, scarico.esercbuonoinventario, scarico.numbuonoinventario "
				+ "from scaricobeneinventario scarico "
				+ "left outer join buonoscaricoinventario buono on buono.codicetipobuono=scarico.codicetipobuono "
				+ "and buono.esercbuonoinventario=scarico.esercbuonoinventario "
				+ "and buono.numbuonoinventario=scarico.numbuonoinventario "
				+ "where buono.codicetipobuono is null or buono.esercbuonoinventario is null or buono.numbuonoinventario is null "
				+ "order by scarico.numscaricobene ";
			string messaggio;
			DataTable t = SourceConn.SQLRunner(query,0, out messaggio);
			if (messaggio != null) {
				MessageBox.Show(form, messaggio);
				return false;
			}
			if (t.Rows.Count > 0) 
			{
				messaggio = "Esistono i seguenti scarichi beni che non hanno un corrispondente buono di scarico:";
				t.Columns["numscaricobene"].Caption = "Num. scarico bene";
				t.Columns["descrizione"].Caption = "Descrizione";
				t.Columns["codiceinventario"].Caption = "Codice inventario";
				t.Columns["codicetipobuono"].Caption = "Codice tipo buono";
				t.Columns["esercbuonoinventario"].Caption = "Eserc. buono inventario";
				t.Columns["numbuonoinventario"].Caption = "Num. buono inventario";
				string domanda = "Si intende procedere nella migrazione perdendo tutti gli scarichi dei beni "
					+ "che non avevano un corrispondente buono di scarico?";
				DialogResult dr = new FrmErrore(t, messaggio, domanda).ShowDialog(form);
				if (dr == DialogResult.No) {
					return false;
				}
			}
			return true;
		}

		public static bool controllaScaricoParteEParte(Form form, DataAccess SourceConn) {
			string query = "select numscaricoparte, descrizione, codiceinventario, codicetipobuono, esercbuonoinventario, numbuonoinventario "
				+ "from scaricoparteinventario where numscaricoparte not in "
				+ "(select numscaricoparte from partenoninventariabile where numscaricoparte is not null) "
				+ " order by numscaricoparte";
			string messaggio;
			DataTable t = SourceConn.SQLRunner(query, 0, out messaggio);
			if (messaggio != null) {
				MessageBox.Show(form, messaggio);
				return false;
			}
			if (t.Rows.Count > 0) 
			{
				messaggio = "Esistono i seguenti scarichi che non hanno corrispondenti parti:";
				t.Columns["numscaricoparte"].Caption = "Num. scarico parte";
				t.Columns["descrizione"].Caption = "Descrizione";
				t.Columns["codiceinventario"].Caption = "Codice inventario";
				t.Columns["codicetipobuono"].Caption = "Codice tipo buono";
				t.Columns["esercbuonoinventario"].Caption = "Eserc. buono inventario";
				t.Columns["numbuonoinventario"].Caption = "Num. buono inventario";
				string domanda = "Si intende procedere nella migrazione perdendo tutti gli scarichi delle parti "
					+ "che non avevano un corrispondente buono di scarico?";
				DialogResult dr = new FrmErrore(t, messaggio, domanda).ShowDialog(form);
				if (dr == DialogResult.No) {
					return false;
				}
			}
			return true;
		}

		public static bool controllaScaricoParteEBuono(Form form, DataAccess SourceConn) {
			string query = "select scarico.numscaricoparte, scarico.descrizione, scarico.codicetipobuono, scarico.esercbuonoinventario, scarico.numbuonoinventario "
				+ "from scaricoparteinventario scarico "
				+ "left outer join buonoscaricoinventario buono on buono.codicetipobuono=scarico.codicetipobuono "
				+ "and buono.esercbuonoinventario=scarico.esercbuonoinventario "
				+ "and buono.numbuonoinventario=scarico.numbuonoinventario "
				+ "where buono.codicetipobuono is null or buono.esercbuonoinventario is null or buono.numbuonoinventario is null "
				+ "order by scarico.numscaricoparte ";
			string messaggio;
			DataTable t = SourceConn.SQLRunner(query, 0, out messaggio);
			if (messaggio != null) {
				MessageBox.Show(form, messaggio);
				return false;
			}
			if (t.Rows.Count > 0) 
			{
				messaggio = "Esistono i seguenti scarichi parti che non hanno un corrispondente buono di scarico:";
				t.Columns["numscaricoparte"].Caption = "Num. scarico parte";
				t.Columns["descrizione"].Caption = "Descrizione";
				t.Columns["codiceinventario"].Caption = "Codice inventario";
				t.Columns["codicetipobuono"].Caption = "Codice tipo buono";
				t.Columns["esercbuonoinventario"].Caption = "Eserc. buono inventario";
				t.Columns["numbuonoinventario"].Caption = "Num. buono inventario";
				new FrmErrore(t, messaggio).ShowDialog(form);
				return false;
			}
			return true;
		}

		public static bool controllaCarichiSenzaBeni(Form form, DataAccess SourceConn) {
			string sub = "(select count(*) from beneinventariabile where numcaricobene=caricobeneinventario.numcaricobene)";
			string query = "select numcaricobene, descrizione, quantita, beni=" 
				+ sub
				+ " from caricobeneinventario where "
				+ sub
				+ " = 0";
			string messaggio;
			DataTable t = SourceConn.SQLRunner(query, 0, out messaggio);
			if (messaggio != null) {
				MessageBox.Show(form, messaggio);
				return false;
			}
			if (t.Rows.Count > 0) {
				messaggio = "La quantità effettiva dei beni nei seguenti carichi è pari a zero:";
				t.Columns["numcaricobene"].Caption = "Num. carico bene";
				t.Columns["descrizione"].Caption = "Descrizione";
				t.Columns["quantita"].Caption = "Quantità";
				t.Columns["beni"].Caption = "Beni";
				string domanda = "Si intende procedere nella migrazione anche se ci sono questi carichi senza beni?";
				DialogResult dr = new FrmErrore(t, messaggio, domanda).ShowDialog(form);
				if (dr==DialogResult.No) {
					return false;
				}
			}
			return true;
		}

		public static bool controllaQuantitaInCaricoBene(Form form, DataAccess SourceConn) {
			string sub = "(select count(*) from beneinventariabile where numcaricobene=caricobeneinventario.numcaricobene)";
			string query = "select numcaricobene, descrizione, quantita, beni=" 
				+ sub
				+ " from caricobeneinventario where quantita is null or quantita<1 or "
				+ sub
				+ " not in (0, quantita)";
			string messaggio;
			DataTable t = SourceConn.SQLRunner(query, 0, out messaggio);
			if (messaggio != null) {
				MessageBox.Show(form, messaggio);
				return false;
			}
			if (t.Rows.Count > 0) {
				messaggio = "Errata la quantità dei beni nei seguenti carichi:";
				t.Columns["numcaricobene"].Caption = "Num. carico bene";
				t.Columns["descrizione"].Caption = "Descrizione";
				t.Columns["quantita"].Caption = "Quantità";
				t.Columns["beni"].Caption = "Beni";
				string domanda = "Si intende procedere comunque?";
				DialogResult dr = new FrmErrore(t, messaggio, domanda).ShowDialog(form);
				if (dr == DialogResult.No) {
					return false;
				}
			}
//			int beni = CfgFn.GetNoNullInt32( SourceConn.DO_READ_VALUE("beneinventariabile", null, "count(*)"));
//			int quantita = CfgFn.GetNoNullInt32( SourceConn.DO_READ_VALUE("caricobeneinventario", null, "sum(quantita)"));
//			if (beni!=quantita) {
//				string confronto = (quantita < beni) ? "minore" : "maggiore";
//				MessageBox.Show(form, "La somma delle quantità dei carichi dei beni ("+quantita
//					+ ") è "+confronto+" del numero dei beni ("+beni+")", "ERRORE!");
//				return false;
//			}
			return true;
		}

		public static bool controllaBeniSenzaCarichi(Form form, DataAccess SourceConn) {
			string query = "select idbene, numcaricobene from beneinventariabile where numcaricobene not in "
				+ "(select numcaricobene from caricobeneinventario)";
			string messaggio;
			DataTable t = SourceConn.SQLRunner(query, 0, out messaggio);
			if (messaggio != null) {
				MessageBox.Show(form, messaggio);
				return false;
			}
			if (t.Rows.Count > 0) {
				messaggio = "Errata la quantità dei beni nei seguenti carichi:";
				t.Columns["numcaricobene"].Caption = "Num. carico bene";
				t.Columns["idbene"].Caption = "Id. bene";
				string domanda = "Si intende procedere comunque?";
				DialogResult dr = new FrmErrore(t, messaggio, domanda).ShowDialog(form);
				if (dr == DialogResult.No) {
					return false;
				}
			}
			return true;
		}

		public static bool controllaQuantitaInScaricoBene(Form form, DataAccess SourceConn) {
			string sub = "(select count(*) from beneinventariabile where numscaricobene=scaricobeneinventario.numscaricobene)";
			string query = "select numscaricobene, descrizione, quantita, beni="
				+ sub
				+ " from scaricobeneinventario where quantita is null or quantita<1 or quantita <> "
				+ sub;
			string messaggio;
			DataTable t = SourceConn.SQLRunner(query, 0, out messaggio);
			if (messaggio != null) {
				MessageBox.Show(form, messaggio);
				return false;
			}
			if (t.Rows.Count > 0) {
				messaggio = "Errata la quantità dei beni nei seguenti scarichi:";
				t.Columns["numscaricobene"].Caption = "Num. scarico bene";
				t.Columns["descrizione"].Caption = "Descrizione";
				t.Columns["quantita"].Caption = "Quantità";
				t.Columns["beni"].Caption = "Beni";
				string domanda = "Si intende procedere nella migrazione anche se ci sono questi carichi bene?";
				DialogResult dr = new FrmErrore(t, messaggio, domanda).ShowDialog(form);
				if (dr==DialogResult.No) {
					return false;
				}
			}
			return true;
		}

		public static bool controllaQuantitaInCaricoParte(Form form, DataAccess SourceConn) {
			string sub = "(select count(*) from partenoninventariabile where numcaricoparte=caricoparteinventario.numcaricoparte)";
			string query = "select numcaricoparte, descrizione, quantita, parti="
				+ sub
				+ " from caricoparteinventario where quantita is null or quantita<1 or quantita <> "
				+ sub;
			string messaggio;
			DataTable t = SourceConn.SQLRunner(query, 0, out messaggio);
			if (messaggio != null) {
				MessageBox.Show(form, messaggio);
				return false;
			}
			if (t.Rows.Count > 0) {
				messaggio = "Errata la quantità delle parti nei seguenti carichi:";
				t.Columns["numcaricoparte"].Caption = "Num. carico parte";
				t.Columns["descrizione"].Caption = "Descrizione";
				t.Columns["quantita"].Caption = "Quantità";
				t.Columns["parti"].Caption = "Parti";
				string domanda = "Si intende procedere nella migrazione anche se ci sono questi carichi parte?";
				DialogResult dr = new FrmErrore(t, messaggio, domanda).ShowDialog(form);
				if (dr==DialogResult.No) {
					return false;
				}
			}
			int parti = CfgFn.GetNoNullInt32(SourceConn.DO_READ_VALUE("partenoninventariabile", null, "count(*)"));
			int quantita = CfgFn.GetNoNullInt32( SourceConn.DO_READ_VALUE("caricoparteinventario", null, "sum(quantita)"));
			if (parti!=quantita) {
				string confronto = (quantita < parti) ? "minore" : "maggiore";
				DialogResult dr= MessageBox.Show(form, "La somma delle quantità dei carichi delle parti ("+quantita
					+ ") è "+confronto+" del numero delle parti ("+parti+")", "ERRORE!",
						MessageBoxButtons.YesNo);
				if (dr==DialogResult.No) {
					return false;
				}
			}
			return true;
		}

		public static bool controllaQuantitaInScaricoParte(Form form, DataAccess SourceConn) {
			string sub = "(select count(*) from partenoninventariabile where numscaricoparte=scaricoparteinventario.numscaricoparte)";
			string query = "select numscaricoparte, descrizione, quantita, parti="
				+ sub
				+ " from scaricoparteinventario where quantita is null or quantita<1 or quantita <> "
				+ sub;
			string messaggio;
			DataTable t = SourceConn.SQLRunner(query, 0, out messaggio);
			if (messaggio != null) {
				MessageBox.Show(form, messaggio);
				return false;
			}
			if (t.Rows.Count > 0) {
				messaggio = "Errata la quantità delle parti nei seguenti scarichi:";
				t.Columns["numscaricoparte"].Caption = "Num. scarico parte";
				t.Columns["descrizione"].Caption = "Descrizione";
				t.Columns["quantita"].Caption = "Quantità";
				t.Columns["parti"].Caption = "Parti";
				string domanda = "Si intende procedere nella migrazione anche se ci sono questi scarichi parte?";
				DialogResult dr = new FrmErrore(t, messaggio, domanda).ShowDialog(form);
				if (dr==DialogResult.No) {
					return false;
				}
			}
			return true;
		}


		/// <summary>
		/// Copia la tabella eventotecnico in maintenance ponendo idpiece=1
		/// </summary>
		/// <param name="form"></param>
		/// <param name="sourceConn"></param>
		/// <param name="destConn"></param>
		public static bool esportaEventoTecnico(Form form, DataAccess sourceConn, DataAccess destConn) {
			string q = "select adate=datacontabile, amount=importo, ct=createtimestamp, cu=createuser, "
				+ "description=descrizione, idasset=idbene, idpiece=1, idmaintenancekind=codicetipoevento, "
				+ "lt=lastmodtimestamp, lu=lastmoduser, nmaintenance=numevento, rtf=olenotes, txt=notes "
				+ "from eventotecnico";
			DataTable t = Migrazione.eseguiQuery(sourceConn, q, form);
			if (t==null) return false;
			DataSet ds = new DataSet();
			ds.Tables.Add(t);
			t.TableName = "maintenance";
			return Migrazione.lanciaScript(form, destConn, ds, "eventotecnico -> maintenance");
		}

		/// <summary>
		/// Copia la tabella rivalutazionebene in assetamortization ponendo idpiece=1
		/// </summary>
		/// <param name="form"></param>
		/// <param name="sourceConn"></param>
		/// <param name="destConn"></param>
		public static bool esportaRivalutazioneBene(Form form, DataAccess sourceConn, DataAccess destConn) {
			string q = "select adate=datacontabile, amortizationquota=quotarivalutazione, "
				+ "assetvalue=valorebene, ct=createtimestamp, cu=createuser, "
				+ "description=descrizione, idasset=idbene, idinventoryamortization=codicetiporivalutazione, "
				+ "idpiece=1, lt=lastmodtimestamp, lu=lastmoduser, namortization=numrivalutazione, "
				+ "rtf=olenotes, txt=notes, flagunload = CASE "
                + " WHEN ISNULL(quotarivalutazione,0) >= 0 OR YEAR(datacontabile) <= 2006 THEN 'N' "
                + " ELSE 'S' END "
				+ "from rivalutazionebene";
			DataTable t = Migrazione.eseguiQuery(sourceConn, q, form);
			if (t==null) return false;
			DataSet ds = new DataSet();
			ds.Tables.Add(t);
			t.TableName = "assetamortization";
			return Migrazione.lanciaScript(form, destConn, ds, "rivalutazionebene -> assetamortization");
		}

		public static bool EffettuaControlli(Form form, DataAccess SourceConn){
			if (!controllaCarichiSenzaBeni(form, SourceConn)) return false;
			if (!controllaBeniSenzaCarichi(form, SourceConn)) return false;
			if (!controllaAumentoValoreEBene(form, SourceConn)) return false;
			if (!controllaParteEBene(form, SourceConn)) return false;
			if (!controllaQuantitaInCaricoBene(form, SourceConn)) return false;
			if (!controllaQuantitaInScaricoBene(form, SourceConn)) return false;
			if (!controllaQuantitaInCaricoParte(form, SourceConn)) return false;
			if (!controllaQuantitaInScaricoParte(form, SourceConn)) return false;
			if (!controllaScaricoBeneEBuono(form, SourceConn)) return false;
			if (!controllaScaricoParteEParte(form, SourceConn)) return false;
			if (!controllaScaricoParteEBuono(form, SourceConn)) return false;
			return true;
		}
		/// <summary>
		/// Metodo da chiamare da CopiaTutto
		/// Migra le tabelle di Patrimonio che non sono di configurazione e che non possono essere migrate
		/// con una semplice copia
		/// </summary>
		/// <param name="form"></param>
		/// <param name="SourceConn"></param>
		/// <param name="Conn"></param>
		public static bool migraSpeciali(Form form, DataAccess SourceConn, DataAccess Conn, DataTable tColName) {
			//			Migrazione.eseguiQuery(Conn, "truncate table assetacquire", form);
			//			Migrazione.eseguiQuery(Conn, "truncate table asset", form);


			//CaricoBeneInventario -> AssetAcquire
			int lastNAssetAcquire;
			if (!esportaCaricoBeneInventario(form, SourceConn, Conn, out lastNAssetAcquire)) return false;

			//BeneInventariabile -> asset
			if (!esportaBeneinventariabile(form, SourceConn, Conn)) return false;

			//CaricoParteInventario -> AssetAcquire
			int newlastNAssetAcquire;
			if (!esportaCaricoParteInventario(form, SourceConn, Conn, lastNAssetAcquire, out newlastNAssetAcquire)) return false;

			//(partenoninventariabile -> asset) e (scaricoparteinventario -> assetacquire)
			//int newlastNAssetAcquire;
			if (!esportaPartenoninventariabile(form, SourceConn, Conn, lastNAssetAcquire))return false;
			lastNAssetAcquire=newlastNAssetAcquire;
			
			//AumentoValoreBene -> AssetAcquire
			if (!esportaAumentoValoreBene(form, SourceConn, Conn, lastNAssetAcquire,out newlastNAssetAcquire))return false;
			lastNAssetAcquire=newlastNAssetAcquire;

			//DiminuzioneValoreBene -> AssetAcquire
			if (!esportaDiminuzioneValoreBene(form, SourceConn, Conn, lastNAssetAcquire,out newlastNAssetAcquire))return false;
			lastNAssetAcquire=newlastNAssetAcquire;

			//eventotecnico -> maintenance
			if (!esportaEventoTecnico(form, SourceConn, Conn)) return false;

			//rivalutazionebene -> assetamortization
			if (!(esportaRivalutazioneBene(form, SourceConn, Conn))) return false;

			//causalecaricoinventario -> assetloadmotive
			return esportaCausaleCaricoInventario(form, SourceConn, Conn, tColName);
		}

        //static string tabelleSpeciali = "'caricobeneinventario', 'beneinventariabile', 'caricoparteinventario', "
        //    + "'partenoninventariabile', 'scaricoparteinventario', 'aumentovalorebene', 'diminuzionevalorebene', "
        //    + "'eventotecnico', 'rivalutazionebene', 'causalecaricoinventario'";



		/// <summary>
		/// Metodo da chiamare se il checkBox del patrimonio è checked.
		/// Migra tutte le tabelle del Patrimonio, di configurazione e non.
		/// </summary>
		/// <param name="form"></param>
		/// <param name="sourceConn"></param>
		/// <param name="destConn"></param>
		/// <param name="tTableName"></param>
		/// <param name="tColName"></param>
		public static bool migraPatrimonio(Form form, DataAccess sourceConn, DataAccess destConn, 
			DataTable tTableName, DataTable tColName) 
		{
			if (!migraSpeciali(form, sourceConn, destConn, tColName)) return false;

            //DataRow[] rSpeciali = tTableName.Select("oldtable in ("+tabelleSpeciali+")");
            //foreach (DataRow r in rSpeciali) {
            //    r["copiato"] = "S";
            //}
			string filtro = "tipocopia='copia' and copiato='N' and chk like '%Patrimonio%'";

			DataRow[] rTableName = tTableName.Select(filtro);

			foreach (DataRow rTable in rTableName) {
				DataSet ds = new DataSet();
				DataTable t = Migrazione.leggiETraduciTabella(rTable["oldtable"].ToString(), sourceConn, tColName, form);
				if (t==null) return false;
				t.TableName = rTable["newtable"].ToString();
				ds.Tables.Add(t);
				rTable["copiato"] = "S";
				string nomeCopia = "Copia normali tabella "+t.TableName;
				bool res= Migrazione.lanciaScript(form, destConn, t, nomeCopia);
				if (!res) return false;
			}
			return true;
			
		}
	}
}