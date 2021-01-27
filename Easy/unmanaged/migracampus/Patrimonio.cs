
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
        public static void Reset() {
            LookupNumBene = new Hashtable();
            LookupNumCaricoBene = new Hashtable();
            LookupNumCaricoParte = new Hashtable();
            lookupiddivision = new Hashtable();
            lookupidman = new Hashtable();
            EsportaTipoUtilizzo_eseguito = false;
            EsportaTipoManutenzione_eseguita = false;
            lookupidassetusagekind = new Hashtable();
            lookupidmaintenancekind = new Hashtable();
       }

        static Hashtable LookupNumBene = new Hashtable();
		/// <summary>
		/// Copia la tabella beneinventariabile in asset ponendo idpiece sempre uguale ad uno.
		/// </summary>
		/// <param name="SourceConn"></param>
		/// <param name="Conn"></param>
		/// <returns>true se Ok</returns>
		public static bool esportaBeneinventariabile(Form form, DataAccess SourceConn, DataAccess Conn) {
            string query = "select ct=bene.createtimestamp, cu=bene.createuser, "
                + "lt=bene.lastmodtimestamp, lu=bene.lastmoduser, numcaricobene, bene.idbene, "
                + "ninventory=numinventario, rtf=bene.olenotes, txt=bene.notes, "
                + "UNL.idassetunload, "
                + "flagunload = ISNULL(scarico.flagbuonoinventario,'S') "
                + "from beneinventariabile bene left outer join scaricobeneinventario scarico "
                + "on bene.numscaricobene=scarico.numscaricobene "
                + " LEFT OUTER JOIN " + getExtAccess(Conn, "assetunloadkind", false) + " UNLK ON UNLK.codeassetunloadkind=scarico.codicetipobuono "
                + " LEFT OUTER JOIN " + getExtAccess(Conn, "assetunload", false) + " UNL ON " +
                                "UNL.idassetunloadkind = UNLK.idassetunloadkind AND " +
                                "UNL.yassetunload = scarico.esercbuonoinventario AND " +
                                "UNL.nassetunload = scarico.numbuonoinventario ";
                
                
			string errMsg;
			DataTable All = SourceConn.SQLRunner(query, 0, out errMsg);
			if (errMsg != null) {
				MessageBox.Show(form, errMsg);
				return false;
			}
            int maxasset=0;
            DataTable Asset = Conn.CreateTableByName("asset", "*");
            foreach (DataRow Curr in All.Rows) {
                maxasset++;
                DataRow R = Asset.NewRow();
                LookupNumBene[Curr["idbene"]]=maxasset;
                R["idasset"] = maxasset;
                R["idpiece"] = 1;
                int flag = Curr["flagunload"].ToString().ToUpper() == "S" ? 1 : 0;
                R["flag"] = flag;
                if (LookupNumCaricoBene[Curr["numcaricobene"]] != null) 
                    R["nassetacquire"] = LookupNumCaricoBene[Curr["numcaricobene"]];

                foreach (string s in new string[] { "lt", "ct", "lu", "cu", "txt", "rtf", "ninventory", "idassetunload" })
                    R[s] = Curr[s];

                Asset.Rows.Add(R);
            }


			DataSet ds = new DataSet();
            ds.Tables.Add(Asset);

            DataRow[] rBeniNonCaricati = Asset.Select("nassetacquire is null");
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
                + "parte.idbene, idpiece=parte.idparte, "
                + "lt=parte.lastmodtimestamp, lu=parte.lastmoduser, parte.numcaricoparte, "
                + "rtf=parte.olenotes, txt=parte.notes, "
                + " UNL.idassetunload, "
                + "flagunload = ISNULL(scarico.flagbuonoinventario,'S') "
                + "from partenoninventariabile parte "
                + "join beneinventariabile bene on bene.idbene=parte.idbene "
                + "left outer join scaricoparteinventario scarico on parte.numscaricoparte=scarico.numscaricoparte "
                + "left outer join " + getExtAccess(Conn, "assetunloadkind", false) + " UNLK ON UNLK.codeassetunloadkind=scarico.codicetipobuono "
                + "left outer join " + getExtAccess(Conn, "assetunload", false) + " UNL ON " +
                            "UNL.idassetunloadkind = UNL.idassetunloadkind AND " +
                            "UNL.yassetunload = scarico.esercbuonoinventario AND " +
                            "UNL.nassetunload = scarico.numbuonoinventario ";
                

			string errMsg;
			DataTable All = SourceConn.SQLRunner(query, 0, out errMsg);
			if (errMsg != null) {
				MessageBox.Show(form, errMsg);
				return false;
			}
			if (All.Rows.Count==0) return true;
            DataTable Asset = Conn.CreateTableByName("asset", "*");
            Hashtable parti = new Hashtable();

            foreach (DataRow Curr in All.Rows) {
                DataRow R = Asset.NewRow();
                object idasset = LookupNumBene[Curr["idbene"]];
                R["idasset"] = idasset;
                R["nassetacquire"] = LookupNumCaricoParte[Curr["numcaricoparte"]];
                object idPiece = parti[idasset];
                if (idPiece == null) {
                    idPiece = 2;
                }
                else {
                    idPiece = 1 + (int)idPiece;
                }
                parti[idasset] = idPiece;
                R["idpiece"] = idPiece;
                int flag = 0;
                if (Curr["flagunload"].ToString().ToUpper() == "S") flag += 1;
                R["flag"] = flag; 
                foreach (string s in new string[] { "lt", "lu", "ct", "cu", "rtf", "txt", "idassetunload" }) {
                    R[s] = Curr[s];
                }
                Asset.Rows.Add(R);
            }

            DataRow[] rPartiNonCaricate = Asset.Select("nassetacquire is null");
			if (rPartiNonCaricate.Length > 0) 
			{
				string[,] colonne = new string[,] { {
					  "idasset", "Id. parte"},
					 {"nassetacquire", "Num. carico parte"},
					 {"idassetunloadkind", "Codice tipo buono"}, {
					  "nassetunload", "Num. buono inventario"},
					  {"yassetunload","Eserc. buono inventario"}};

				new FrmErrore(rPartiNonCaricate, "Le seguenti parti non sono state caricate:", colonne).ShowDialog(form);
			}

			DataSet ds = new DataSet();
			ds.Tables.Add(Asset);


			//newlastNAssetAcquire = CfgFn.GetNoNullInt32(tAsset.Compute("max(nassetacquire)", null)) ;

			bool res= Migrazione.lanciaScript(form, Conn, ds, "partenoninventariabile -> asset ");
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
                + "description=aumento.descrizione, discount=aumento.sconto, startnumber=bene.numinventario, "
                + "flagload=aumento.flagbuonoinventario, aumento.idbene, "
                + "LD.idassetload, "
                + "IT.idinv, INV.idinventory,REG.idreg, "
                + "AM.idmot, "
                + "ispieceacquire='S', loadkind='N', "
                + "lt=aumento.lastmodtimestamp, lu=aumento.lastmoduser, "
                //+ "idpiece=null, nassetacquire=null, "
                + "number=1, rtf=aumento.olenotes, taxable=aumento.imponibile, "
                + "taxrate=aumento.imposta, txt=aumento.notes, "
                + "tax=CONVERT(decimal(19,2),ROUND((CONVERT(decimal(19,2),"
                + "ROUND(ISNULL(aumento.imponibile,0)*(1+ISNULL(aumento.imposta,0))*(1-ISNULL(aumento.sconto,0)),2))"
                + " - ROUND(ISNULL(aumento.imponibile,0)*(1-ISNULL(aumento.sconto,0)),2)),2)) "
                + "from aumentovalorebene aumento "
                + "join beneinventariabile bene on bene.idbene = aumento.idbene "
                + "join caricobeneinventario carico on carico.numcaricobene = bene.numcaricobene "
                + "LEFT OUTER JOIN creditoredebitore CRED ON CRED.codicecreddeb= carico.codicecreddeb "
                + "LEFT OUTER JOIN " + getExtAccess(Conn, "registry", true) + " REG ON REG.title= CRED.denominazione "
                + "LEFT OUTER JOIN " + getExtAccess(Conn, "assetloadkind", false) + " AL ON AL.codeassetloadkind= aumento.codicetipobuono "
                + "LEFT OUTER JOIN " + getExtAccess(Conn, "inventory", false) + " INV ON INV.codeinventory=carico.codiceinventario "
                + "LEFT OUTER JOIN " + getExtAccess(Conn, "assetload", false) + " LD ON " +
                            "LD.idassetloadkind= AL.idassetloadkind AND " +
                            "LD.yassetload = aumento.esercbuonoinventario AND " +
                            "LD.nassetload = aumento.numbuonoinventario "
                + "LEFT OUTER JOIN " + getExtAccess(Conn, "assetloadmotive", false) + " AM ON AM.codemot=aumento.codicecausale "
                + "LEFT OUTER JOIN classinventario CI ON CI.idclass= carico.idclass "
                + "LEFT OUTER JOIN " + getExtAccess(Conn, "inventorytree", true) + " IT ON IT.codeinv= CI.codiceclass ";
               
                           
			string errMsg;
            DataTable All = SourceConn.SQLRunner(query, 0, out errMsg);
			if (errMsg != null) {
				MessageBox.Show(form, errMsg);
				return false;
			}
			if (All.Rows.Count==0) return true;
            DataTable Assetacquire= Conn.CreateTableByName("assetacquire","*");
            DataTable Asset = Conn.CreateTableByName("asset", "*");
            Hashtable parti = new Hashtable();

            foreach (DataRow Curr in All.Rows) {
                newlastNAssetAcquire++;
                DataRow R = Assetacquire.NewRow();
                R["nassetacquire"] = newlastNAssetAcquire;
                R["abatable"] = 0;
                int flag = 4; //piece acquire
                if (Curr["flagload"].ToString().ToUpper() == "S") flag += 1;
                if (Curr["loadkind"].ToString().ToUpper() == "R") flag += 2;
                R["flag"] = flag;
                foreach (string col in new string[] { "adate", "idmot", "ct", "cu", "description","discount",
                        "idreg","lt","lu","rtf","startnumber","number",
                        "tax","taxable","taxrate","txt","idmot","idinventory","idinv"}) {
                    R[col] = Curr[col];
                }
                Assetacquire.Rows.Add(R);
                object idasset= LookupNumBene[Curr["idbene"]];
                DataRow r = Asset.NewRow();
                r["idasset"] = idasset;
                object idPiece = parti[Curr["idbene"]];
                if (idPiece == null) {
                    idPiece = Conn.DO_READ_VALUE("asset", "idasset=" + idasset.ToString(), "max(idpiece)");
                }
                idPiece = 1 + CfgFn.GetNoNullInt32(idPiece);
                parti[r["idasset"]] = idasset;
                r["idpiece"] = idPiece;
                r["flag"]=1; //flagunload='S'
                r["nassetacquire"] = newlastNAssetAcquire;
                foreach (string col in new string[] {  "ct", "cu", "lt","lu","rtf","txt"}) {
                    r[col] = Curr[col];
                }
                Asset.Rows.Add(r);

            }



			DataSet ds = new DataSet();
			ds.Tables.Add(Asset);
            ds.Tables.Add(Assetacquire);

			return  Migrazione.lanciaScript(form, Conn, ds, "Aumento valore bene -> Asset + Asset acquire");

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
                + "discount=diminuzione.sconto, flagload='N',  "
                + "diminuzione.idbene, UNL.idassetunload, startnumber=bene.numinventario, "
                + "IT.idinv, INV.idinventory,  "
                + "ispieceacquire='S', loadkind='R', "
                + "lt=diminuzione.lastmodtimestamp, lu=diminuzione.lastmoduser, "
                //+ "nassetacquire=null"
                //+ lastNassetAcquire
                + " rtf=diminuzione.olenotes "
                + ", number= 1 "
                + ", taxable=diminuzione.imponibile, taxrate=diminuzione.imposta, txt=diminuzione.notes, "
                + "tax = CONVERT(decimal(19,2),ROUND((CONVERT(decimal(19,2),"
                + "ROUND(ISNULL(diminuzione.imponibile,0)*(1+ISNULL(diminuzione.imposta,0))*(1-ISNULL(diminuzione.sconto,0)),2))"
                + " - ROUND(ISNULL(diminuzione.imponibile,0)*(1-ISNULL(diminuzione.sconto,0)),2)),2)), "
                + "abatable=0, "
                + "flagunload = ISNULL(diminuzione.flagbuonoinventario,'S') "
                + "from diminuzionevalorebene diminuzione "
                + " join beneinventariabile bene on diminuzione.idbene=bene.idbene "
                + "left outer join caricobeneinventario carico on bene.numcaricobene=carico.numcaricobene "
                + "left outer join " + getExtAccess(Conn, "assetunloadkind", false) + " UNLK ON UNLK.codeassetunloadkind= diminuzione.codicetipobuono "
                + "left outer join " + getExtAccess(Conn, "assetunload", false) + " UNL ON " +
                                    "UNL.idassetunloadkind = UNLK.idassetunloadkind AND " +
                                    "UNL.yassetunload = diminuzione.esercbuonoinventario AND " +
                                    "UNL.nassetunload = diminuzione.numbuonoinventario "
                + "LEFT OUTER JOIN " + getExtAccess(Conn, "inventory", false) +
                        " INV ON INV.codeinventory=carico.codiceinventario "
                + "LEFT OUTER JOIN classinventario CI ON CI.idclass= carico.idclass "
                + "LEFT OUTER JOIN " + getExtAccess(Conn, "inventorytree", true) + " IT ON IT.codeinv= CI.codiceclass ";

            string errMsg;
			DataTable All = SourceConn.SQLRunner(query, 0, out errMsg);
			if (errMsg != null) {
				MessageBox.Show(form, errMsg);
				return false;
			}
            if (All.Rows.Count == 0) return true;

            object idmot_all = Conn.DO_READ_VALUE("assetloadmotive", "codemot='SCARICO", "idmot");

            DataTable AssetAcquire = Conn.CreateTableByName("assetacquire", "*");
            DataTable Asset = Conn.CreateTableByName("asset", "*");

			Hashtable parti = new Hashtable();
            foreach(DataRow Curr in All.Rows) {
                object idasset = LookupNumBene[Curr["idbene"]];
                DataRow R = AssetAcquire.NewRow();
                newlastNAssetAcquire++;
                R["nassetacquire"] = newlastNAssetAcquire;
                int flag = 4; //piece acquire
                if (Curr["flagload"].ToString().ToUpper() == "S") flag += 1;
                if (Curr["loadkind"].ToString().ToUpper() == "R") flag += 2;
                R["flag"] = flag;
                R["idmot"] = idmot_all;
                foreach (string col in new string[] { "adate",  "ct", "cu", "description","discount",
                        "lt","lu","rtf","startnumber","number",
                        "tax","taxable","taxrate","txt","yman","idinventory","idinv"}) {
                    R[col] = Curr[col];
                }

                AssetAcquire.Rows.Add(R);
                
                DataRow r = Asset.NewRow();
                r["idasset"] = idasset;
                object idPiece = parti[idasset];
				if (idPiece == null) {
					idPiece = Conn.DO_READ_VALUE("asset", "idasset="+idasset.ToString(), "max(idpiece)");
				}
				idPiece = 1 + (int)idPiece;
				parti[idasset] = idPiece;
				r["idpiece"] = idPiece;
                r["nassetacquire"] = newlastNAssetAcquire;
                r["flag"]=1; //flagunload='S'
                foreach (string c in new string[] {"ct","cu","lt","lu","rtf","txt","idassetunload"}){
                    r[c]=Curr[c];
                }
                Asset.Rows.Add(r);
			}

            DataSet ds = new DataSet();
			ds.Tables.Add(AssetAcquire);
            ds.Tables.Add(Asset);
			
			return Migrazione.lanciaScript(form, Conn, ds, "Diminuzione valore bene -> Asset acquire + Asset");
		}
		


        static Hashtable LookupNumCaricoBene = new Hashtable();
		/// <summary>
		/// Copia la tabella caricobeneinventario in assetacquire ponendo ispieceacquire='N'
		/// e nassetacquire=numcaricobene
		/// </summary>
		/// <param name="SourceConn"></param>
		/// <param name="Conn"></param>		
		public static bool esportaCaricoBeneInventario(Form form, DataAccess SourceConn, DataAccess Conn, out int lastNAssetAcquire ) {
            lastNAssetAcquire = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("assetacquire", null, "max(nassetacquire)"));
            if (Conn.RUN_SELECT_COUNT("assetacquire", null, false) > 0) return true;
            string query = "select adate=M.datacontabile, ct=M.createtimestamp, cu=M.createuser, "
                + "description=M.descrizione, discount=M.sconto, flagload=M.flagbuonoinventario, "
                + "IT.idinv, INV.idinventory, M.numcaricobene,"
                + "AM.idmot, REG.idreg, ispieceacquire='N', loadkind=M.flagtipocarico, "
                + "lt=M.lastmodtimestamp, lu=M.lastmoduser, "
                + "LD.idassetload, nman=M.numordine, number=ISNULL(M.quantita,0), "
                + "rownum=M.numriga, rtf=M.olenotes, startnumber=M.numiniziale, "
                + "tax=CONVERT(decimal(19,2),ROUND((CONVERT(decimal(19,2),"
                + "ROUND(ISNULL(imponibile,0)*(1+ISNULL(imposta,0))*(1-ISNULL(sconto,0)),2))"
                + " - ROUND(ISNULL(imponibile,0)*(1-ISNULL(sconto,0)),2))*ISNULL(quantita,0),2)), "
                + "taxable=imponibile, txt=M.notes, "
                + "taxrate=imposta, idmankind=CASE WHEN numordine is not null then 'GENERALE' else null END, "
                + "yman=esercordine from caricobeneinventario M "
                + "LEFT OUTER JOIN creditoredebitore CRED ON CRED.codicecreddeb= M.codicecreddeb "
                + "LEFT OUTER JOIN " + getExtAccess(Conn, "registry", true) + " REG ON REG.title= CRED.denominazione "
                + "LEFT OUTER JOIN " + getExtAccess(Conn, "assetloadkind", false) + " AL ON AL.codeassetloadkind= M.codicetipobuono "
                + "LEFT OUTER JOIN " + getExtAccess(Conn, "inventory", false) + " INV ON INV.codeinventory=M.codiceinventario "
                + "LEFT OUTER JOIN " + getExtAccess(Conn, "assetload", false) + " LD ON " +
                            "LD.idassetloadkind= AL.idassetloadkind AND " +
                            "LD.yassetload = M.esercbuonoinventario AND " +
                            "LD.nassetload = M.numbuonoinventario "
                + "LEFT OUTER JOIN " + getExtAccess(Conn, "assetloadmotive", false) + " AM ON AM.codemot=M.codicecausale "
                + "LEFT OUTER JOIN classinventario CI ON CI.idclass= M.idclass "
                + "LEFT OUTER JOIN " + getExtAccess(Conn, "inventorytree", true) + " IT ON IT.codeinv= CI.codiceclass ";
			string errMsg;
			DataTable All = SourceConn.SQLRunner(query, 0, out errMsg);
			if (errMsg != null) {
				MessageBox.Show(form, errMsg);
				return false;
			}
			if (All.Rows.Count==0) return true;
            DataTable Assetacquire= Conn.CreateTableByName("assetacquire","*");
            foreach (DataRow Curr in All.Rows) {
                lastNAssetAcquire++;
                DataRow R = Assetacquire.NewRow();
                LookupNumCaricoBene[Curr["numcaricobene"]]=lastNAssetAcquire;
                R["nassetacquire"] = lastNAssetAcquire;
                R["abatable"] = 0;
                int flag = 0;
                if (Curr["flagload"].ToString().ToUpper() == "S") flag += 1;
                if (Curr["loadkind"].ToString().ToUpper() == "R") flag += 2;
                R["flag"] = flag;
                foreach (string col in new string[] { "adate", "idmot", "ct", "cu", "description","discount",
                        "idmankind","idreg","lt","lu","nman","rownum","rtf","startnumber","number",
                        "tax","taxable","taxrate","txt","yman","idmot","idinventory","idinv"}) {
                    R[col] = Curr[col];
                }
                Assetacquire.Rows.Add(R);

            }
			DataSet ds = new DataSet();
            ds.Tables.Add(Assetacquire);
			return  Migrazione.lanciaScript(form, Conn, ds, "Carico cespiti -> Asset acquire");
		}

		//public static int calcolaMaxNumCaricoBene (Form form, DataAccess SourceConn, DataAccess Conn, DataTable tAssetAcquire){
			
		//}
        static Hashtable LookupNumCaricoParte = new Hashtable();
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
            string query = "select adate=datacontabile, ct=M.createtimestamp, cu=M.createuser, "
				+ "description=M.descrizione, discount=sconto, flagload=flagbuonoinventario, "
                + "LD.idassetload , IT.idinv, INV.idinventory, numcaricoparte, "
				+ "AM.idmot, REG.idreg, ispieceacquire='S', loadkind='N', "
                + "lt=M.lastmodtimestamp, lu=M.lastmoduser, "
                + "nman=numordine, number=quantita, rownum=numriga, rtf=M.olenotes, "
                + "taxable=imponibile, txt=M.notes,  "
				+ "tax=CONVERT(decimal(19,2),ROUND((CONVERT(decimal(19,2),"
				+ "ROUND(ISNULL(imponibile,0)*(1+ISNULL(imposta,0))*(1-ISNULL(sconto,0)),2))"
				+ " - ROUND(ISNULL(imponibile,0)*(1-ISNULL(sconto,0)),2))*quantita,2)), "
				+ "taxrate=imposta, idmankind=CASE WHEN numordine is not null then 'GENERALE' ELSE null END, "
				+ "abatable=0, "
				+ "yman=esercordine from caricoparteinventario M "
                + "LEFT OUTER JOIN creditoredebitore CRED ON CRED.codicecreddeb= M.codicecreddeb "
                + "LEFT OUTER JOIN " + getExtAccess(Conn, "registry", true) + " REG ON REG.title= CRED.denominazione "
                + "LEFT OUTER JOIN " + getExtAccess(Conn, "assetloadkind", false) + " AL ON AL.codeassetloadkind= M.codicetipobuono "
                + "LEFT OUTER JOIN " + getExtAccess(Conn, "inventory", false) + " INV ON INV.codeinventory=M.codiceinventario "
                + "LEFT OUTER JOIN " + getExtAccess(Conn, "assetload", false) + " LD ON " +
                            "LD.idassetloadkind= AL.idassetloadkind AND " +
                            "LD.yassetload = M.esercbuonoinventario AND " +
                            "LD.nassetload = M.numbuonoinventario "
                + "LEFT OUTER JOIN " + getExtAccess(Conn, "assetloadmotive", false) + " AM ON AM.codemot=M.codicecausale "
                + "LEFT OUTER JOIN classinventario CI ON CI.idclass= M.idclass "
                + "LEFT OUTER JOIN " + getExtAccess(Conn, "inventorytree", true) + " IT ON IT.codeinv= CI.codiceclass ";

			string errMsg;
            DataTable All = SourceConn.SQLRunner(query, 0, out errMsg);
            if (errMsg != null) {
                MessageBox.Show(form, errMsg);
                return false;
            }

            if (All.Rows.Count == 0) return true;
            DataTable Assetacquire = Conn.CreateTableByName("assetacquire","*");
            foreach (DataRow Curr in All.Rows) {
                newlastNAssetAcquire++;
                DataRow R = Assetacquire.NewRow();
                LookupNumCaricoParte[Curr["numcaricoparte"]]=newlastNAssetAcquire;
                R["nassetacquire"] = newlastNAssetAcquire;
                R["abatable"] = 0;
                R["startnumber"] = DBNull.Value;
                int flag = 4; //pieceacquire
                if (Curr["flagload"].ToString().ToUpper() == "S") flag += 1;
                if (Curr["loadkind"].ToString().ToUpper() == "R") flag += 2;
                R["flag"] = flag;
                foreach (string col in new string[] { "adate", "idmot", "ct", "cu", "description","discount",
                        "idmankind","idreg","lt","lu","nman","rownum","rtf","number",
                        "tax","taxable","taxrate","txt","yman","idmot","idinventory","idinv"}) {
                    R[col] = Curr[col];
                }
                Assetacquire.Rows.Add(R);
            }
            DataSet ds = new DataSet();
            ds.Tables.Add(Assetacquire);
			
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
                    + "che non avevano corrispondenti parti?";
				DialogResult dr = new FrmErrore(t, messaggio, domanda).ShowDialog(form);
				if (dr == DialogResult.No) {
					return false;
				}
			}
			return true;
		}

		public static bool controllaScaricoParteEBuono(Form form, DataAccess SourceConn) {
			string query = "select scarico.numscaricoparte, scarico.descrizione, scarico.codicetipobuono,"+
                " scarico.esercbuonoinventario, scarico.numbuonoinventario "
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

        public static bool controllaTipoBuonoCarico(Form form, DataAccess SourceConn) {
            //Da FARE
            return true;
        }
        public static bool controllaTipoBuonoScarico(Form form, DataAccess SourceConn) {
            //Da FARE
            return true;
        }
        public static bool controllaInventario(Form form, DataAccess SourceConn) {
            //Da FARE
            return true;
        }


		/// <summary>
		/// Copia la tabella eventotecnico in maintenance ponendo idpiece=1
		/// </summary>
		/// <param name="form"></param>
		/// <param name="sourceConn"></param>
		/// <param name="destConn"></param>
		public static bool esportaEventoTecnico(Form form, DataAccess sourceConn, DataAccess destConn) {
            EsportaTipoManutenzione(form, sourceConn, destConn);

            string q = "select adate=datacontabile, amount=importo, ct=createtimestamp, cu=createuser, "
                + "description=descrizione, idbene, idpiece=1, "
                + " T.idmaintenancekind,"
                + "lt=lastmodtimestamp, lu=lastmoduser, nmaintenance=numevento, rtf=olenotes, txt=notes "
                + "from eventotecnico "
                + "left outer join " + getExtAccess(destConn, "maintenancekind", true) + 
                        " T ON T.codemaintenancekind= eventotecnico.codicetipoevento ";
			DataTable all = Migrazione.eseguiQuery(sourceConn, q, form);
			if (all==null) return false;
            if (all.Rows.Count == 0) return true;
            int nmaxmaintenance = 0;
            DataTable Maintenance = destConn.CreateTableByName("maintenance", "*");
            foreach (DataRow Curr in all.Rows) {
                DataRow R = Maintenance.NewRow();
                nmaxmaintenance++;
                R["idmaintenance"] = nmaxmaintenance;
                R["idasset"] = LookupNumBene[R["idbene"]];
                foreach (string s in new string[] {"adate","amount","ct","cu","lt","lu","idpiece",
                            "idmaintenancekind","rtf","txt"       }) {
                    R[s] = Curr[s];
                }
                Maintenance.Rows.Add(R);
            }
			DataSet ds = new DataSet();
            ds.Tables.Add(Maintenance);
			return Migrazione.lanciaScript(form, destConn, ds, "eventotecnico -> maintenance");
		}

		/// <summary>
		/// Copia la tabella rivalutazionebene in assetamortization ponendo idpiece=1
		/// </summary>
		/// <param name="form"></param>
		/// <param name="sourceConn"></param>
		/// <param name="destConn"></param>
		public static bool esportaRivalutazioneBene(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (destConn.RUN_SELECT_COUNT("assetamortization", null, false) > 0) return true;
            EsportaTipoAmmortamento(form, sourceConn, destConn);

            string q = "select adate=datacontabile, amortizationquota=quotarivalutazione, "
                + "assetvalue=valorebene, ct=createtimestamp, cu=createuser, "
                + "description=descrizione, idbene, IA.idinventoryamortization, "
                + "idpiece=1, lt=lastmodtimestamp, lu=lastmoduser,  "
                + "rtf=olenotes, txt=notes, flagunload = CASE "
                + " WHEN ISNULL(quotarivalutazione,0) >= 0 OR YEAR(datacontabile) <= 2006 THEN 'N' "
                + " ELSE 'S' END "
                + "from rivalutazionebene "
                + "LEFT OUTER JOIN " + getExtAccess(destConn, "inventoryamortization", false) + " IA " +
                        "ON IA.codeinventoryamortization = rivalutazionebene.codicetiporivalutazione";
			DataTable All = Migrazione.eseguiQuery(sourceConn, q, form);
			if (All==null) return false;
            if (All.Rows.Count == 0) return true;
            DataTable AssetAmortization = destConn.CreateTableByName("assetamortization", "*");
            int nmaxassetamortization = 0;
            foreach (DataRow Curr in All.Rows) {
                DataRow R = AssetAmortization.NewRow();
                nmaxassetamortization++;
                R["namortization"] = nmaxassetamortization;
                R["flag"] = 0; //flagunload=N
                R["idasset"] = LookupNumBene[Curr["idbene"]];
                foreach (string s in new string[] {"adate","amortizationquota", "assetvalue","ct","cu",
                        "description","idinventoryamortization","idpiece","lt","lu",
                          "rtf","txt"}) {
                    R[s] = Curr[s];
                }
                AssetAmortization.Rows.Add(R);
            }

			DataSet ds = new DataSet();
            ds.Tables.Add(AssetAmortization);
			return Migrazione.lanciaScript(form, destConn, ds, "rivalutazionebene -> assetamortization");
		}


        public static bool esportaRivalutazioneInventario(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (destConn.RUN_SELECT_COUNT("inventorysortingamortizationyear", null, false) > 0) return true;
            EsportaTipoAmmortamento(form, sourceConn, destConn);
            EsportaClassInventario(form, sourceConn, destConn);

            string q = "select ayear=E.esercizio, amortizationquota=quotarivalutazione, "
                + "ct=tipoclassrivalutazione.createtimestamp, cu=tipoclassrivalutazione.createuser, "
                + "IA.idinventoryamortization, "
                + " lt=tipoclassrivalutazione.lastmodtimestamp, lu=tipoclassrivalutazione.lastmoduser,  "
                + " IT.idinv "
                + "from tipoclassrivalutazione "
                + " cross join esercizio E "
                + "LEFT OUTER JOIN " + getExtAccess(destConn, "inventoryamortization", false) + " IA " +
                        "ON IA.codeinventoryamortization = tipoclassrivalutazione.codicetiporivalutazione "
                + "LEFT OUTER JOIN classinventario CI ON CI.idclass= tipoclassrivalutazione.idclass "
                + "LEFT OUTER JOIN " + getExtAccess(destConn, "inventorytree", true) + " IT ON IT.codeinv= CI.codiceclass ";
            DataTable All = Migrazione.eseguiQuery(sourceConn, q, form);
            if (All == null) return false;
            if (All.Rows.Count == 0) return true;
            DataTable AssetAmortization = destConn.CreateTableByName("inventorysortingamortizationyear", "*");
            foreach (DataRow Curr in All.Rows) {
                DataRow R = AssetAmortization.NewRow();
                foreach (string s in new string[] {"ayear","amortizationquota", "ct","cu","idinventoryamortization",
                        "idinv","lt","lu"}) {
                    R[s] = Curr[s];
                }
                AssetAmortization.Rows.Add(R);
            }

            DataSet ds = new DataSet();
            ds.Tables.Add(AssetAmortization);
            return Migrazione.lanciaScript(form, destConn, ds, "Riempimento inventorysortingamortizationyear");
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

        static CQueryHelper QHC= new CQueryHelper();




        public static void CreaRigafittizaCausaleCarico(string codicecausale, DataAccess DestConn,
                DataTable Assetloadmotive, ref int maxassetloadmotive) {
            if (Assetloadmotive.Select(QHC.CmpEq("codemot", codicecausale)).Length > 0) return;
            maxassetloadmotive++;
            DataRow R = Assetloadmotive.NewRow();
            R["idmot"] = maxassetloadmotive;
            R["description"] = codicecausale;
            R["codemot"] = codicecausale;
            R["flag"] = 1;
            R["lu"] = "migrazione";
            R["cu"] = "migrazione";
            R["lt"] = DateTime.Now;
            R["ct"] = DateTime.Now;
            Assetloadmotive.Rows.Add(R);
        }


        public static bool EsportaCausaleCarico(Form form,DataAccess SourceConn, DataAccess DestConn) {
            if (DestConn.RUN_SELECT_COUNT("assetloadmotive", null, true) > 0) return true;
            DataTable  Assetloadmotive = DestConn.CreateTableByName("assetloadmotive","*");
            int maxassetloadmotive = 0;

            //Crea le righe che non esistono ma sono referenziate
            DataTable Error1= SourceConn.SQLRunner(
                    "SELECT distinct codicecausale from caricobeneinventario "+
                    "WHERE codicecausale is not null and NOT EXISTS(SELECT * FROM causalecaricoinventario WHERE " +
                            "causalecaricoinventario.codicecausale = caricobeneinventario.codicecausale)");
            foreach (DataRow R in Error1.Rows) CreaRigafittizaCausaleCarico(R["codicecausale"].ToString(), DestConn, Assetloadmotive, ref maxassetloadmotive);


            Error1 = SourceConn.SQLRunner(
                    "SELECT distinct codicecausale from caricoparteinventario " +
                    "WHERE codicecausale is not null and NOT EXISTS(SELECT * FROM causalecaricoinventario WHERE " +
                        "causalecaricoinventario.codicecausale = caricoparteinventario.codicecausale)");
            foreach (DataRow R in Error1.Rows) CreaRigafittizaCausaleCarico(R["codicecausale"].ToString(), DestConn, Assetloadmotive, ref maxassetloadmotive);

            Error1 = SourceConn.SQLRunner(
                    "SELECT distinct codicecausale from aumentovalorebene " +
                    "WHERE codicecausale is not null and NOT EXISTS(SELECT * FROM causalecaricoinventario WHERE " +
                        "causalecaricoinventario.codicecausale = aumentovalorebene.codicecausale)");
            foreach (DataRow R in Error1.Rows) CreaRigafittizaCausaleCarico(R["codicecausale"].ToString(), DestConn, Assetloadmotive, ref maxassetloadmotive);


            Error1 = SourceConn.SQLRunner(
                    "SELECT distinct codicecausale from aumentovaloreparte " +
                    "WHERE codicecausale is not null and NOT EXISTS(SELECT * FROM causalecaricoinventario WHERE " +
                        "causalecaricoinventario.codicecausale = aumentovaloreparte.codicecausale)");
            foreach (DataRow R in Error1.Rows) CreaRigafittizaCausaleCarico(R["codicecausale"].ToString(), DestConn, Assetloadmotive, ref maxassetloadmotive);

            Error1 = SourceConn.SQLRunner(
                     "SELECT distinct codicecausale from buonocaricoinventario " +
                           "WHERE codicecausale is not null and NOT EXISTS(SELECT * FROM causalecaricoinventario WHERE " +
                            "causalecaricoinventario.codicecausale = buonocaricoinventario.codicecausale)");
            foreach (DataRow R in Error1.Rows) CreaRigafittizaCausaleCarico(R["codicecausale"].ToString(), DestConn, Assetloadmotive, ref maxassetloadmotive);


            DataTable All = SourceConn.SQLRunner("SELECT * from causalecaricoinventario");
            foreach (DataRow Curr in All.Rows) {
                DataRow R = Assetloadmotive.NewRow();
                maxassetloadmotive++;
                R["idmot"] = maxassetloadmotive;
                R["description"] = Curr["descrizione"];
                R["codemot"] = Curr["codicecausale"];
                R["flag"] = 1;
                R["lu"] = Curr["lastmoduser"];
                R["cu"] = Curr["createuser"];
                R["lt"] = Curr["lastmodtimestamp"];
                R["ct"] = Curr["createtimestamp"];
                Assetloadmotive.Rows.Add(R);
            }

            if (Assetloadmotive.Select("codemot='SCARICO'").Length==0){
				DataRow r = Assetloadmotive.NewRow();
                maxassetloadmotive++;
                r["idmot"] = maxassetloadmotive;
				r["codemot"] = "SCARICO";
				r["description"] = "PER SCARICO";
                r["flag"] = 1;
				r["cu"] = "migrazione";
				r["ct"] = DateTime.Now;
				r["lu"] = "migrazione";
				r["lt"] = DateTime.Now;
				Assetloadmotive.Rows.Add(r);
			}

            DataSet ds = new DataSet();
            ds.Tables.Add(Assetloadmotive);

            return Migrazione.lanciaScript(form, DestConn, ds, "Popolamento AssetLoadMotive");
        }

        public static void CreaRigafittizaCausaleScarico(string codicecausale, DataAccess DestConn,
                    DataTable Assetunloadmotive, ref int maxassetunloadmotive) {
            if (Assetunloadmotive.Select(QHC.CmpEq("codemot", codicecausale)).Length > 0) return;
            maxassetunloadmotive++;
            DataRow R = Assetunloadmotive.NewRow();
            R["idmot"] = maxassetunloadmotive;
            R["description"] = codicecausale;
            R["codemot"] = codicecausale;
            R["lu"] = "migrazione";
            R["cu"] = "migrazione";
            R["lt"] = DateTime.Now;
            R["ct"] = DateTime.Now;
            Assetunloadmotive.Rows.Add(R);
        }


        public static bool EsportaCausaleScarico(Form form, DataAccess SourceConn, DataAccess DestConn) {
            if (DestConn.RUN_SELECT_COUNT("assetunloadmotive", null, false) > 0) return true;

            DataTable Assetunloadmotive = DestConn.CreateTableByName("assetunloadmotive", "*");
            int maxassetunloadmotive = 0;

            //Crea le righe che non esistono ma sono referenziate
            DataTable Error1 = SourceConn.SQLRunner(
                    "SELECT distinct codicecausale from scaricobeneinventario " +
                    "WHERE codicecausale is not null and NOT EXISTS(SELECT * FROM causalescaricoinventario WHERE " +
                            "causalescaricoinventario.codicecausale = scaricobeneinventario.codicecausale)");
            foreach (DataRow R in Error1.Rows) CreaRigafittizaCausaleScarico(R["codicecausale"].ToString(), DestConn, Assetunloadmotive, ref maxassetunloadmotive);


            Error1 = SourceConn.SQLRunner(
                    "SELECT distinct codicecausale from scaricoparteinventario " +
                    "WHERE codicecausale is not null and NOT EXISTS(SELECT * FROM causalescaricoinventario WHERE " +
                        "causalescaricoinventario.codicecausale = scaricoparteinventario.codicecausale)");
            foreach (DataRow R in Error1.Rows) CreaRigafittizaCausaleScarico(R["codicecausale"].ToString(), DestConn, Assetunloadmotive, ref maxassetunloadmotive);

            Error1 = SourceConn.SQLRunner(
                    "SELECT distinct codicecausale from diminuzionevalorebene " +
                    "WHERE codicecausale is not null and NOT EXISTS(SELECT * FROM causalescaricoinventario WHERE " +
                        "causalescaricoinventario.codicecausale = diminuzionevalorebene.codicecausale)");
            foreach (DataRow R in Error1.Rows) CreaRigafittizaCausaleScarico(R["codicecausale"].ToString(), DestConn, Assetunloadmotive, ref maxassetunloadmotive);

            Error1 = SourceConn.SQLRunner(
                    "SELECT distinct codicecausale from diminuzionevaloreparte " +
                    "WHERE codicecausale is not null and NOT EXISTS(SELECT * FROM causalescaricoinventario WHERE " +
                        "causalescaricoinventario.codicecausale = diminuzionevaloreparte.codicecausale)");
            foreach (DataRow R in Error1.Rows) CreaRigafittizaCausaleScarico(R["codicecausale"].ToString(), DestConn, Assetunloadmotive, ref maxassetunloadmotive);


            Error1 = SourceConn.SQLRunner(
                     "SELECT distinct codicecausale from buonoscaricoinventario " +
                           "WHERE codicecausale is not null and NOT EXISTS(SELECT * FROM causalescaricoinventario WHERE " +
                            "causalescaricoinventario.codicecausale = buonoscaricoinventario.codicecausale)");
            foreach (DataRow R in Error1.Rows) CreaRigafittizaCausaleScarico(R["codicecausale"].ToString(), DestConn, Assetunloadmotive, ref maxassetunloadmotive);


            DataTable All = SourceConn.SQLRunner("SELECT * from causalescaricoinventario");
            foreach (DataRow Curr in All.Rows) {
                DataRow R = Assetunloadmotive.NewRow();
                maxassetunloadmotive++;
                R["idmot"] = maxassetunloadmotive;
                R["description"] = Curr["descrizione"];
                R["codemot"] = Curr["codicecausale"];
                R["lu"] = Curr["lastmoduser"];
                R["cu"] = Curr["createuser"];
                R["lt"] = Curr["lastmodtimestamp"];
                R["ct"] = Curr["createtimestamp"];
                Assetunloadmotive.Rows.Add(R);
            }


            DataSet ds = new DataSet();
            ds.Tables.Add(Assetunloadmotive);

            return Migrazione.lanciaScript(form, DestConn, ds, "Popolamento AssetUnloadMotive");

        }

        public static void CreaRigafittizaEnteInventario(string codiceenteinv, DataAccess DestConn,
                    DataTable InventoryAgency, ref int maxinventoryagency) {
            if (InventoryAgency.Select(QHC.CmpEq("codeinventoryagency", codiceenteinv)).Length > 0) return;
            maxinventoryagency++;
            DataRow R = InventoryAgency.NewRow();
            R["idinventoryagency"] = maxinventoryagency;
            R["codeinventoryagency"] = codiceenteinv;
            InventoryAgency.Rows.Add(R);
        }

        public static bool EsportaEnteInventario(Form form, DataAccess SourceConn, DataAccess DestConn) {
            if (DestConn.RUN_SELECT_COUNT("inventoryagency", null, false) > 0) return true;

            DataTable InventoryAgency = DestConn.CreateTableByName("inventoryagency", "*");
            int maxinventoryagency = 0;

            //Crea le righe che non esistono ma sono referenziate
            DataTable Error1 = SourceConn.SQLRunner(
                    "SELECT distinct codiceenteinv from inventario " +
                    "WHERE codiceenteinv is not null and NOT EXISTS(SELECT * FROM enteinventario WHERE " +
                            "enteinventario.codiceenteinv = inventario.codiceenteinv)");
            foreach (DataRow R in Error1.Rows) CreaRigafittizaEnteInventario(R["codiceenteinv"].ToString(), DestConn, InventoryAgency, ref maxinventoryagency);

            Error1 = SourceConn.SQLRunner(
                    "SELECT distinct codiceenteinv from variazionepatrimonio " +
                "WHERE codiceenteinv is not null and NOT EXISTS(SELECT * FROM enteinventario WHERE " +
                "enteinventario.codiceenteinv = variazionepatrimonio.codiceenteinv)");
            foreach (DataRow R in Error1.Rows) CreaRigafittizaEnteInventario(R["codiceenteinv"].ToString(), DestConn, InventoryAgency, ref maxinventoryagency);



            DataTable All = SourceConn.SQLRunner("SELECT * from enteinventario");
            foreach (DataRow Curr in All.Rows) {
                DataRow R = InventoryAgency.NewRow();
                maxinventoryagency++;
                R["idinventoryagency"] = maxinventoryagency;
                R["description"] = Curr["descrizione"];
                R["codeinventoryagency"] = Curr["codiceenteinv"];
                R["lu"] = Curr["lastmoduser"];
                R["cu"] = Curr["createuser"];
                R["lt"] = Curr["lastmodtimestamp"];
                R["ct"] = Curr["createtimestamp"];
                InventoryAgency.Rows.Add(R);
            }


            DataSet ds = new DataSet();
            ds.Tables.Add(InventoryAgency);

            return Migrazione.lanciaScript(form, DestConn, ds, "Popolamento InventoryAgency");
        }


        public static void CreaRigafittizaTipoInventario(string codicetipoinv, DataAccess DestConn,
            DataTable Inventorykind, ref int maxinventorykind) {
            if (Inventorykind.Select(QHC.CmpEq("codeinventorykind", codicetipoinv)).Length > 0) return;
            maxinventorykind++;
            DataRow R = Inventorykind.NewRow();
            R["idinventorykind"] = maxinventorykind;
            R["codeinventorykind"] = codicetipoinv;
            R["flag"] = 1; //discount
            Inventorykind.Rows.Add(R);
        }

        public static bool EsportaTipoInventario(Form form, DataAccess SourceConn, DataAccess DestConn) {
            if (DestConn.RUN_SELECT_COUNT("inventorykind", null, false) > 0) return true;
            DataTable Inventorykind = DestConn.CreateTableByName("inventorykind", "*");
            int maxinventorykind = 0;

            //Crea le righe che non esistono ma sono referenziate
            DataTable Error1 = SourceConn.SQLRunner(
                    "SELECT distinct codicetipoinv from inventario " +
                    "WHERE codicetipoinv is not null and NOT EXISTS(SELECT * FROM tipoinventario WHERE " +
                            "tipoinventario.codicetipoinv = inventario.codicetipoinv)");
            foreach (DataRow R in Error1.Rows) CreaRigafittizaTipoInventario(R["codicetipoinv"].ToString(), DestConn,
                        Inventorykind, ref maxinventorykind);


            DataTable All = SourceConn.SQLRunner("SELECT * from tipoinventario");
            foreach (DataRow Curr in All.Rows) {
                DataRow R = Inventorykind.NewRow();
                maxinventorykind++;
                R["idinventorykind"] = maxinventorykind;
                R["description"] = Curr["descrizione"];
                R["codeinventorykind"] = Curr["codicetipoinv"];
                R["flag"] = 1; //discount
                R["lu"] = Curr["lastmoduser"];
                R["cu"] = Curr["createuser"];
                R["lt"] = Curr["lastmodtimestamp"];
                R["ct"] = Curr["createtimestamp"];
                Inventorykind.Rows.Add(R);
            }


            DataSet ds = new DataSet();
            ds.Tables.Add(Inventorykind);

            return Migrazione.lanciaScript(form, DestConn, ds, "Popolamento Inventorykind");
        }


        public static string getExtAccess(DataAccess Conn, string table,bool dbo){
            //DBNAME.owner"
            if (dbo)
                return Conn.GetSys("database").ToString() + ".dbo."+table;
            else
                return Conn.GetSys("database").ToString() + "." + Conn.GetSys("userdb").ToString() + "." + table;
        }

        public static bool EsportaInventario(Form form, DataAccess SourceConn, DataAccess DestConn) {
            if (DestConn.RUN_SELECT_COUNT("inventory", null, false) > 0) return true;

            EsportaEnteInventario(form, SourceConn, DestConn);
            EsportaTipoInventario(form, SourceConn, DestConn);

            DataTable Inventory = null;
            int maxinventory= 0;

            Inventory = DestConn.CreateTableByName("inventory", "*");
            maxinventory = 0;
          

            DataTable All = SourceConn.SQLRunner(
                "SELECT I.codiceinventario, I.descrizione, "+
                "numiniziale, IA.idinventoryagency, IK.idinventorykind, I.numiniziale, "+
                " I.createuser,I.createtimestamp, I.lastmoduser, I.lastmodtimestamp "+
                " from inventario  I  JOIN "+
                getExtAccess(DestConn,"inventoryagency",false)+" IA ON I.codiceenteinv = IA.codeinventoryagency "+
                " JOIN "+getExtAccess(DestConn,"inventorykind",false)+
                        " IK ON I.codicetipoinv= IK.codeinventorykind "
                );
            foreach (DataRow Curr in All.Rows) {
                DataRow R = Inventory.NewRow();
                maxinventory++;
                R["idinventory"] = maxinventory;
                R["codeinventory"] = Curr["codiceinventario"];
                R["description"] = Curr["descrizione"];
                R["startnumber"] = Curr["numiniziale"];
                R["flag"] = 0; //mixed
                R["idinventorykind"] = Curr["idinventorykind"];
                R["idinventoryagency"] = Curr["idinventoryagency"];
                R["lu"] = Curr["lastmoduser"];
                R["cu"] = Curr["createuser"];
                R["lt"] = Curr["lastmodtimestamp"];
                R["ct"] = Curr["createtimestamp"];
                Inventory.Rows.Add(R);
            }


            DataSet ds = new DataSet();
            ds.Tables.Add(Inventory);

            return Migrazione.lanciaScript(form, DestConn, ds, "Popolamento Inventory");
        }

        public static bool EsportaTipoBuonoCarico(Form form, DataAccess SourceConn, DataAccess DestConn) {
            if (DestConn.RUN_SELECT_COUNT("assetloadkind", null, false) > 0) return true;
            EsportaInventario(form, SourceConn, DestConn);
            DataTable Assetloadkind = DestConn.CreateTableByName("assetloadkind","*");
            int maxassetloadkind = 0;
            string sql =
                "SELECT T.codicetipobuono,T.descrizione, T.numiniziale, T.flagnumcontinua, " +
                " I.idinventory ,  T.createuser,T.createtimestamp, T.lastmoduser, T.lastmodtimestamp " +
                " FROM tipobuonocaricoinv T JOIN " +
                getExtAccess(DestConn, "inventory", false) + " I ON I.codeinventory = T.codiceinventario";
            DataTable All = SourceConn.SQLRunner(sql);
            maxassetloadkind = 0;

            foreach (DataRow Curr in All.Rows) {
                DataRow R = Assetloadkind.NewRow();
                maxassetloadkind++;
                R["idassetloadkind"] = maxassetloadkind;
                R["description"] = Curr["descrizione"];
                R["startnumber"] = Curr["numiniziale"];
                R["flag"] = Curr["flagnumcontinua"].ToString().ToUpper() == "S" ? 1 : 0;
                R["idinventory"] = Curr["idinventory"];
                R["codeassetloadkind"] = Curr["codicetipobuono"];
                R["lu"] = Curr["lastmoduser"];
                R["cu"] = Curr["createuser"];
                R["lt"] = Curr["lastmodtimestamp"];
                R["ct"] = Curr["createtimestamp"];
                Assetloadkind.Rows.Add(R);
            }


            DataSet ds = new DataSet();
            ds.Tables.Add(Assetloadkind);

            return Migrazione.lanciaScript(form, DestConn, ds, "Popolamento AssetLoadKind");
        }

        public static bool EsportaTipoBuonoScarico(Form form, DataAccess SourceConn, DataAccess DestConn) {
            if (DestConn.RUN_SELECT_COUNT("assetunloadkind", null, false) > 0) return true;
            EsportaInventario(form, SourceConn, DestConn);

            DataTable Assetunloadkind = DestConn.CreateTableByName("assetunloadkind","*");
            int maxassetunloadkind = 0;
            DataTable All = SourceConn.SQLRunner(
                "SELECT T.codicetipobuono,T.descrizione, T.numiniziale, T.flagnumcontinua, " +
                " I.idinventory ,  T.createuser,T.createtimestamp, T.lastmoduser, T.lastmodtimestamp " +
                " FROM tipobuonoscaricoinv T JOIN " +
                getExtAccess(DestConn, "inventory", false) + " I ON I.codeinventory = T.codiceinventario");
            maxassetunloadkind = 0;

            foreach (DataRow Curr in All.Rows) {
                DataRow R = Assetunloadkind.NewRow();
                maxassetunloadkind++;
                R["idassetunloadkind"] = maxassetunloadkind;
                R["description"] = Curr["descrizione"];
                R["startnumber"] = Curr["numiniziale"];
                R["flag"] = Curr["flagnumcontinua"].ToString().ToUpper() == "S" ? 1 : 0;
                R["idinventory"] = Curr["idinventory"];
                R["codeassetunloadkind"] = Curr["codicetipobuono"];
                R["lu"] = Curr["lastmoduser"];
                R["cu"] = Curr["createuser"];
                R["lt"] = Curr["lastmodtimestamp"];
                R["ct"] = Curr["createtimestamp"];
                Assetunloadkind.Rows.Add(R);
            }


            DataSet ds = new DataSet();
            ds.Tables.Add(Assetunloadkind);

            return Migrazione.lanciaScript(form, DestConn, ds, "Popolamento AssetUnloadKind");
        }
        public static Hashtable lookupidmaintenancekind = new Hashtable();
        public static bool EsportaTipoManutenzione_eseguita = false;
        public static bool EsportaTipoManutenzione(Form form, DataAccess SourceConn, DataAccess DestConn) {
            if (EsportaTipoManutenzione_eseguita) return true;
            EsportaTipoManutenzione_eseguita = true;
            DataTable Existent = DestConn.SQLRunner("SELECT * from maintenancekind");
            foreach (DataRow RC in Existent.Rows) {
                string code = RC["codemaintenancekind"].ToString().ToUpper();
                lookupidmaintenancekind[code] = RC["idmaintenancekind"];
            }
            Existent.CaseSensitive = false;
            DataTable Maintenancekind = DestConn.CreateTableByName("maintenancekind", "*");
            int maxmaintenancekind = CfgFn.GetNoNullInt32(DestConn.DO_READ_VALUE("maintenancekind", null, "max(idmaintenancekind)"));
          
           DataTable All = SourceConn.SQLRunner("SELECT * from tipoeventotecnico");
            foreach (DataRow Curr in All.Rows) {
                string codice = Curr["codicetipoevento"].ToString().ToUpper();
                if (lookupidmaintenancekind[codice] != null) continue;
                string find = QHC.CmpEq("description", Curr["descrizione"]);
                DataRow[] found = Existent.Select(find);
                if (found.Length > 0) {
                    lookupidmaintenancekind[codice] = found[0]["idmaintenancekind"];
                    continue;
                }
                DataRow R = Maintenancekind.NewRow();
                maxmaintenancekind++;
                R["idmaintenancekind"] = maxmaintenancekind;
                R["description"] = Curr["descrizione"];
                R["codemaintenancekind"] = Curr["codicetipoevento"];
                R["lu"] = Curr["lastmoduser"];
                R["cu"] = Curr["createuser"];
                R["lt"] = Curr["lastmodtimestamp"];
                R["ct"] = Curr["createtimestamp"];
                Maintenancekind.Rows.Add(R);
            }


            DataSet ds = new DataSet();
            ds.Tables.Add(Maintenancekind);

            return Migrazione.lanciaScript(form, DestConn, ds, "Popolamento Maintenancekind");
        }


        public static bool EsportaTipoAmmortamento(Form form, DataAccess SourceConn, DataAccess DestConn) {
            if (DestConn.RUN_SELECT_COUNT("inventoryamortization", null, false) > 0) return true;
            DataTable Inventoryamortization = DestConn.CreateTableByName("inventoryamortization", "*");
            int mainventoryamortization = 0;

            DataTable Error1 = SourceConn.SQLRunner(
                "SELECT DISTINCT codicetiporivalutazione from tipoclassrivalutazione TC WHERE " +
                " NOT EXISTS(SELECT * FROM tiporivalinventario T where T.codicetiporivalutazione=" +
                " TC.codicetiporivalutazione)");
            foreach (DataRow RC in Error1.Rows) {
                DataRow R = Inventoryamortization.NewRow();
                mainventoryamortization++;
                R["idinventoryamortization"] = mainventoryamortization;
                R["description"] = RC["codicetiporivalutazione"];
                R["codeinventoryamortization"] = RC["codicetiporivalutazione"];
                int flag = 2 + 8; //official+ivaapplying+amortization
                flag += 4;
                R["flag"] = flag;
                R["lu"] = "SWMORE";
                R["cu"] = "SWMORE";
                R["lt"] = DateTime.Now;
                R["ct"] = DateTime.Now;
                Inventoryamortization.Rows.Add(R);
            }


            DataTable All = SourceConn.SQLRunner("SELECT * from tiporivalinventario");
            foreach (DataRow Curr in All.Rows) {
                DataRow R = Inventoryamortization.NewRow();
                mainventoryamortization++;
                R["idinventoryamortization"] = mainventoryamortization;
                R["description"] = Curr["descrizione"];
                R["codeinventoryamortization"] = Curr["codicetiporivalutazione"];
                int flag = 2 + 8; //official+ivaapplying+amortization
                if (Curr["flagapplicazioneiva"].ToString().ToUpper()=="S") flag+=4; 
                R["flag"]=flag;
                R["lu"] = Curr["lastmoduser"];
                R["cu"] = Curr["createuser"];
                R["lt"] = Curr["lastmodtimestamp"];
                R["ct"] = Curr["createtimestamp"];
                Inventoryamortization.Rows.Add(R);
            }


            DataSet ds = new DataSet();
            ds.Tables.Add(Inventoryamortization);

            return Migrazione.lanciaScript(form, DestConn, ds, "Popolamento Inventoryamortization");
        }


        public static Hashtable lookupiddivision = new Hashtable();
        public static bool EsportaSezione(Form form, DataAccess SourceConn, DataAccess DestConn) {
            if (DestConn.RUN_SELECT_COUNT("division", null, false) > 0) return true;
            DataTable All = SourceConn.SQLRunner(
                "SELECT cap=M.cap,M.codicesezione,city=M.comune,ct=M.createtimestamp,cu=M.createuser,"+
                "description=M.descrizione,address=M.indirizzo,lt=M.lastmodtimestamp,lu=M.lastmoduser,"+
                "txt=M.notes,rtf=M.olenotes,country=M.provincia,faxnumber=M.telefaxnumero,"+
                "faxprefix=M.telefaxprefisso,phonenumber=M.telefononumero,phoneprefix=M.telefonoprefisso "+
                "from sezione M");
            if (All.Rows.Count==0) return true;
            DataTable Division = DestConn.CreateTableByName("division", "*");
            int nmaxdivision = 0;
            foreach (DataRow Curr in All.Rows) {
                nmaxdivision++;
                DataRow R=Division.NewRow();
                R["iddivision"] = nmaxdivision;
                lookupiddivision[Curr["codicesezione"].ToString().ToUpper()] = nmaxdivision;
                foreach (string S in new string[] { "cap",  "city", "ct", "cu", "description", 
                    "address", "lt", "lu", "txt", "rtf", "country", "faxnumber", "faxprefix",
                    "phonenumber", "phoneprefix" }) {
                    R[S] = Curr[S];
                }
                Division.Rows.Add(R);
            }
            DataSet ds = new DataSet();
            ds.Tables.Add(Division);

            return Migrazione.lanciaScript(form, DestConn, ds, "Popolamento Division");

        }

        public static Hashtable lookupidman = new Hashtable();
        public static bool EsportaResponsabile(Form form, DataAccess SourceConn, DataAccess DestConn) {

            if (DestConn.RUN_SELECT_COUNT("manager", null, false) > 0) return true;
            EsportaSezione(form, SourceConn, DestConn);

            DataTable Manager = DestConn.CreateTableByName("manager","*");
            int maxidman = 0;
            DataTable All = SourceConn.SQLRunner("SELECT * from responsabile");

            foreach (DataRow Curr in All.Rows) {
                DataRow R = Manager.NewRow();
                maxidman++;
                R["idman"] = maxidman;
                lookupidman[Curr["codiceresponsabile"]] = maxidman;
                R["active"] = "S";
                R["title"] = Curr["nome"];
                R["email"] = Curr["indirizzoemail"];
                if (Curr["codicesezione"] != DBNull.Value)
                    R["iddivision"] = lookupiddivision[Curr["codicesezione"].ToString().ToUpper()];
                R["phonenumber"] = Curr["numerotelefono"];
                R["passwordweb"] = Curr["passwordweb"];
                R["userweb"] = Curr["loginweb"];
                R["passwordweb"] = Curr["passwordweb"];
                R["txt"] = Curr["notes"];
                R["rtf"] = Curr["olenotes"];
                R["lu"] = Curr["lastmoduser"];
                R["cu"] = Curr["createuser"];
                R["lt"] = Curr["lastmodtimestamp"];
                R["ct"] = Curr["createtimestamp"];
                Manager.Rows.Add(R);
            }


            DataSet ds = new DataSet();
            ds.Tables.Add(Manager);

            return Migrazione.lanciaScript(form, DestConn, ds, "Popolamento Manager");
        }


        public static bool EsportaLivelloInventario(Form form, DataAccess SourceConn, DataAccess DestConn) {
            if (DestConn.RUN_SELECT_COUNT("inventorysortinglevel", null, false) > 0) return true;
            DataTable InventorySortingLevel = DestConn.CreateTableByName("inventorysortinglevel","*");
            DataTable All = SourceConn.SQLRunner("SELECT * from livelloclassinventario");

            foreach (DataRow Curr in All.Rows) {
                DataRow R = InventorySortingLevel.NewRow();
                R["nlevel"] = CfgFn.GetNoNullInt32(Curr["codicelivello"]);
                R["description"] = Curr["descrizione"];
                R["codelen"] = CfgFn.GetNoNullInt32(Curr["lunghcodice"]);
                int flag = 0;
                if (Curr["tipocodice"].ToString().ToUpper() == "A") flag += 1;
                if (Curr["flagoperativo"].ToString().ToUpper() == "S") flag += 2;
                if (Curr["flagreset"].ToString().ToUpper() == "S") flag += 4;
                R["flag"] = flag;
                R["lu"] = Curr["lastmoduser"];
                R["cu"] = Curr["createuser"];
                R["lt"] = Curr["lastmodtimestamp"];
                R["ct"] = Curr["createtimestamp"];
                InventorySortingLevel.Rows.Add(R);
            }


            DataSet ds = new DataSet();
            ds.Tables.Add(InventorySortingLevel);

            return Migrazione.lanciaScript(form, DestConn, ds, "Popolamento InventorySortingLevel");
        }



        public static bool EsportaClassInventario(Form form, DataAccess SourceConn, DataAccess DestConn) {
            if (DestConn.RUN_SELECT_COUNT("inventorytree", null, false) > 0) return true;
            DataTable InventorySorting = DestConn.CreateTableByName("inventorytree", "*");
            int maxidinv = 0;
            DataTable All = SourceConn.SQLRunner("SELECT * from classinventario");

            foreach (DataRow Curr in All.Select(null, "codicelivello")) {
                maxidinv++;
                DataRow R = InventorySorting.NewRow();
                R["idinv"] = maxidinv;
                if (CfgFn.GetNoNullInt32(Curr["codicelivello"]) > 1) {
                    string filterparent= QHC.CmpEq("idclass",Curr["livsupidclass"]);
                    DataRow []Parent = All.Select(filterparent);
                    if (Parent.Length > 0) {
                        string myfilter = QHC.CmpEq("codeinv", Parent[0]["codiceclass"]);
                        DataRow[] myparent = InventorySorting.Select(myfilter);
                        if (myparent.Length > 0) R["paridinv"] = myparent[0]["idinv"];
                    }
                }
                R["description"] = Curr["descrizione"];
                R["codeinv"] = Curr["codiceclass"];
                R["nlevel"] = CfgFn.GetNoNullInt32( Curr["codicelivello"]);
                R["txt"] = Curr["notes"];
                R["rtf"] = Curr["olenotes"];
                R["lu"] = Curr["lastmoduser"];
                R["cu"] = Curr["createuser"];
                R["lt"] = Curr["lastmodtimestamp"];
                R["ct"] = Curr["createtimestamp"];
                InventorySorting.Rows.Add(R);
            }


            DataSet ds = new DataSet();
            ds.Tables.Add(InventorySorting);

            return Migrazione.lanciaScript(form, DestConn, ds, "Popolamento InventorySorting");
        }



        public static bool EsportaLivelloUbicazione(Form form, DataAccess SourceConn, DataAccess DestConn) {
            if (DestConn.RUN_SELECT_COUNT("locationlevel", null, false) > 0) return true;
            DataTable LocationLevel = DestConn.CreateTableByName("locationlevel", "*");
            DataTable All = SourceConn.SQLRunner("SELECT * from livelloubicazione");

            foreach (DataRow Curr in All.Rows) {
                DataRow R = LocationLevel.NewRow();
                R["nlevel"] = CfgFn.GetNoNullInt32(Curr["codicelivello"]);
                R["description"] = Curr["descrizione"];
                R["codelen"] = CfgFn.GetNoNullInt32(Curr["lunghcodice"]);
                int flag = 0;
                if (Curr["tipocodice"].ToString().ToUpper() == "A") flag += 1;
                if (Curr["flagoperativo"].ToString().ToUpper() == "S") flag += 2;
                if (Curr["flagreset"].ToString().ToUpper() == "S") flag += 4;
                R["flag"] = flag;
                R["lu"] = Curr["lastmoduser"];
                R["cu"] = Curr["createuser"];
                R["lt"] = Curr["lastmodtimestamp"];
                R["ct"] = Curr["createtimestamp"];
                LocationLevel.Rows.Add(R);
            }


            DataSet ds = new DataSet();
            ds.Tables.Add(LocationLevel);

            return Migrazione.lanciaScript(form, DestConn, ds, "Popolamento LocationLevel");
        }



        public static bool EsportaUbicazione(Form form, DataAccess SourceConn, DataAccess DestConn) {
            if (DestConn.RUN_SELECT_COUNT("location", null, false) > 0) return true;
            EsportaResponsabile(form, SourceConn, DestConn);

            DataTable Location = DestConn.CreateTableByName("location", "*");
            int maxidlocation = 0;
            DataTable All = SourceConn.SQLRunner("SELECT U.*,M1.idman  from ubicazione U " +
                " LEFT OUTER JOIN responsabile M ON U.codiceresponsabile= M.codiceresponsabile "+
                " LEFT OUTER JOIN "+getExtAccess(DestConn,"manager",false)+" M1 ON M1.title = M.nome ");

            foreach (DataRow Curr in All.Select(null, "codicelivello")) {
                maxidlocation++;
                DataRow R = Location.NewRow();
                R["idlocation"] = maxidlocation;
                if (CfgFn.GetNoNullInt32(Curr["codicelivello"]) > 1) {
                    string filterparent = QHC.CmpEq("idubicazione", Curr["livsupidubicazione"]);
                    DataRow[] Parent = All.Select(filterparent);
                    if (Parent.Length > 0) {
                        string myfilter = QHC.CmpEq("locationcode", Parent[0]["codiceubicazione"]);
                        DataRow[] myparent = Location.Select(myfilter);
                        if (myparent.Length > 0) R["paridlocation"] = myparent[0]["idlocation"];
                    }
                }
                R["active"] = "S";
                R["idman"] = Curr["idman"];
                R["description"] = Curr["descrizione"];
                R["locationcode"] = Curr["codiceubicazione"];
                R["nlevel"] = CfgFn.GetNoNullInt32(Curr["codicelivello"]);
                R["txt"] = Curr["notes"];
                R["rtf"] = Curr["olenotes"];
                R["lu"] = Curr["lastmoduser"];
                R["cu"] = Curr["createuser"];
                R["lt"] = Curr["lastmodtimestamp"];
                R["ct"] = Curr["createtimestamp"];
                Location.Rows.Add(R);
            }


            DataSet ds = new DataSet();
            ds.Tables.Add(Location);

            return Migrazione.lanciaScript(form, DestConn, ds, "Popolamento Location");
        }

        //causale, data cont., descrizione, 

        public static void CreaRigafittizaBuonoCarico(object idassetloadkind, object y, object n,
                object idmot, object idreg,        DataTable Assetload, ref int maxassetload) {
            if (Assetload.Select(QHC.AppAnd(
                    QHC.CmpEq("idassetloadkind",idassetloadkind),
                    QHC.CmpEq("yassetload",y),
                    QHC.CmpEq("nassetload",n))).Length > 0) return;
            maxassetload++;
            DataRow R = Assetload.NewRow();
            R["idassetload"] = maxassetload;
            R["idassetloadkind"] = idassetloadkind;
            R["yassetload"] = y;
            R["nassetload"] = n;
            R["ratificationdate"] = new DateTime(CfgFn.GetNoNullInt32( y), 12, 31);
            R["adate"] = R["ratificationdate"];
            R["printdate"] = R["ratificationdate"];
            R["description"] = "Carico storico";
            R["idreg"] = idreg;
            R["idmot"] = idmot;
            Assetload.Rows.Add(R);
        }

        public static bool EsportaBuonoCarico(Form form, DataAccess SourceConn, DataAccess DestConn) {
            if (DestConn.RUN_SELECT_COUNT("assetload", null, false) > 0) return true;
            EsportaTipoBuonoCarico(form, SourceConn, DestConn);
            EsportaCausaleCarico(form, SourceConn, DestConn);

            DataTable Assetload = DestConn.CreateTableByName("assetload","*");
            int maxassetload = 0;

            //Crea i buoni fittizi per ovviare a rif. chiavi inesistenti
            //Crea le righe che non esistono ma sono referenziate
            DataTable Error1 = SourceConn.SQLRunner(                                           
                "SELECT distinct T.idassetloadkind, AL.idmot , REG.idreg, "+
                        " C.esercbuonoinventario,C.numbuonoinventario from caricobeneinventario C " +
                    " JOIN "+getExtAccess(DestConn,"assetloadkind",false)+
                                " T ON T.codeassetloadkind= C.codicetipobuono "+          
                    " LEFT OUTER JOIN "+getExtAccess(DestConn,"assetloadmotive",false)+ 
                                " AL ON AL.codemot= C.codicecausale "+
                    " LEFT OUTER JOIN creditoredebitore CRED ON CRED.codicecreddeb= C.codicecreddeb "+
                    " LEFT OUTER JOIN " + getExtAccess(DestConn, "registry", true) + 
                                " REG ON REG.title= CRED.denominazione "+
                    " WHERE C.esercbuonoinventario is not null and C.numbuonoinventario is not null and " +
                    " NOT EXISTS(SELECT * FROM buonocaricoinventario BC WHERE " +
                            "BC.codicetipobuono= C.codicetipobuono and "+
                            "BC.esercbuonoinventario= C.esercbuonoinventario AND "+
                            "BC.numbuonoinventario = C.numbuonoinventario)");
            foreach (DataRow R in Error1.Rows) CreaRigafittizaBuonoCarico(R["idassetloadkind"],R["esercbuonoinventario"],
                    R["numbuonoinventario"], R["idmot"], R["idreg"], Assetload, ref maxassetload);



            Error1 = SourceConn.SQLRunner(
                 "SELECT distinct T.idassetloadkind, AL.idmot , REG.idreg, " +
                         " C.esercbuonoinventario,C.numbuonoinventario from caricoparteinventario C " +
                     " JOIN " + getExtAccess(DestConn, "assetloadkind", false) +
                                 " T ON T.codeassetloadkind= C.codicetipobuono " +
                     " LEFT OUTER JOIN " + getExtAccess(DestConn, "assetloadmotive", false) +
                                 " AL ON AL.codemot= C.codicecausale " +
                     " LEFT OUTER JOIN creditoredebitore CRED ON CRED.codicecreddeb= C.codicecreddeb " +
                     " LEFT OUTER JOIN " + getExtAccess(DestConn, "registry", true) +
                                 " REG ON REG.title= CRED.denominazione " +
                     " WHERE C.esercbuonoinventario is not null and C.numbuonoinventario is not null and " +
                     " NOT EXISTS(SELECT * FROM buonocaricoinventario BC WHERE " +
                             "BC.codicetipobuono= C.codicetipobuono and " +
                             "BC.esercbuonoinventario= C.esercbuonoinventario AND " +
                             "BC.numbuonoinventario = C.numbuonoinventario)");
            foreach (DataRow R in Error1.Rows) CreaRigafittizaBuonoCarico(R["idassetloadkind"], R["esercbuonoinventario"],
                    R["numbuonoinventario"], R["idmot"], R["idreg"], Assetload, ref maxassetload);




            Error1 = SourceConn.SQLRunner(
                 "SELECT distinct T.idassetloadkind, AL.idmot ,  " +
                         " C.esercbuonoinventario,C.numbuonoinventario from aumentovalorebene C " +
                     " JOIN " + getExtAccess(DestConn, "assetloadkind", false) +
                                 " T ON T.codeassetloadkind= C.codicetipobuono " +
                     " LEFT OUTER JOIN " + getExtAccess(DestConn, "assetloadmotive", false) +
                                 " AL ON AL.codemot= C.codicecausale " +
                      " WHERE C.esercbuonoinventario is not null and C.numbuonoinventario is not null and " +
                     " NOT EXISTS(SELECT * FROM buonocaricoinventario BC WHERE " +
                             "BC.codicetipobuono= C.codicetipobuono and " +
                             "BC.esercbuonoinventario= C.esercbuonoinventario AND " +
                             "BC.numbuonoinventario = C.numbuonoinventario)");
            foreach (DataRow R in Error1.Rows) CreaRigafittizaBuonoCarico(R["idassetloadkind"], R["esercbuonoinventario"],
                    R["numbuonoinventario"], R["idmot"], DBNull.Value, Assetload, ref maxassetload);


            Error1 = SourceConn.SQLRunner(
                 "SELECT distinct T.idassetloadkind, AL.idmot ,  " +
                         " C.esercbuonoinventario,C.numbuonoinventario from aumentovaloreparte C " +
                     " JOIN " + getExtAccess(DestConn, "assetloadkind", false) +
                                 " T ON T.codeassetloadkind= C.codicetipobuono " +
                     " LEFT OUTER JOIN " + getExtAccess(DestConn, "assetloadmotive", false) +
                                 " AL ON AL.codemot= C.codicecausale " +
                      " WHERE C.esercbuonoinventario is not null and C.numbuonoinventario is not null and " +
                     " NOT EXISTS(SELECT * FROM buonocaricoinventario BC WHERE " +
                             "BC.codicetipobuono= C.codicetipobuono and " +
                             "BC.esercbuonoinventario= C.esercbuonoinventario AND " +
                             "BC.numbuonoinventario = C.numbuonoinventario)");
            foreach (DataRow R in Error1.Rows) CreaRigafittizaBuonoCarico(R["idassetloadkind"], R["esercbuonoinventario"],
                    R["numbuonoinventario"], R["idmot"], DBNull.Value, Assetload, ref maxassetload);


            DataTable All = SourceConn.SQLRunner(
                "SELECT C.*, T.idassetloadkind, AL.idmot, REG.idreg from buonocaricoinventario C " +
                     " JOIN " + getExtAccess(DestConn, "assetloadkind", false) +
                                 " T ON T.codeassetloadkind= C.codicetipobuono " +
                     " LEFT OUTER JOIN " + getExtAccess(DestConn, "assetloadmotive", false) +
                                 " AL ON AL.codemot= C.codicecausale " +
                     " LEFT OUTER JOIN creditoredebitore CRED ON CRED.codicecreddeb= C.codicecreddeb " +
                     " LEFT OUTER JOIN " + getExtAccess(DestConn, "registry", true) +
                                 " REG ON REG.title= CRED.denominazione ");

            foreach (DataRow Curr in All.Rows) {
                DataRow R = Assetload.NewRow();
                maxassetload++;
                R["idassetload"] = maxassetload;
                R["idassetloadkind"] = Curr["idassetloadkind"];
                R["yassetload"] = Curr["esercbuonoinventario"];
                R["nassetload"] = Curr["numbuonoinventario"];
                R["description"] = Curr["descrizione"];
                R["adate"] = Curr["datacontabile"];
                R["doc"] = Curr["documento"];
                R["docdate"] = Curr["datadocumento"];
                R["enactment"] = Curr["provvedimento"];
                R["enactmentdate"] = Curr["dataprovvedimento"];
                R["idreg"] = Curr["idreg"];
                R["printdate"] = Curr["datastampa"];
                R["ratificationdate"] = Curr["dataratifica"];
                R["idmot"] = Curr["idmot"];

                R["txt"] = Curr["notes"];
                R["rtf"] = Curr["olenotes"];
                R["lu"] = Curr["lastmoduser"];
                R["cu"] = Curr["createuser"];
                R["lt"] = Curr["lastmodtimestamp"];
                R["ct"] = Curr["createtimestamp"];
                Assetload.Rows.Add(R);
            }


            DataSet ds = new DataSet();
            ds.Tables.Add(Assetload);

            return Migrazione.lanciaScript(form, DestConn, ds, "Popolamento AssetLoad");
        }


        public static void CreaRigafittizaBuonoScarico(object idassetunloadkind, object y, object n,
              object idmot, object idreg, DataTable Assetunload, ref int maxassetunload) {
            if (Assetunload.Select(QHC.AppAnd(
                    QHC.CmpEq("idassetunloadkind", idassetunloadkind),
                    QHC.CmpEq("yassetunload", y),
                    QHC.CmpEq("nassetunload", n))).Length > 0) return;
            maxassetunload++;
            DataRow R = Assetunload.NewRow();
            R["idassetunload"] = maxassetunload;
            R["idassetunloadkind"] = idassetunloadkind;
            R["yassetunload"] = y;
            R["nassetunload"] = n;
            R["ratificationdate"] = new DateTime(CfgFn.GetNoNullInt32(y), 12, 31);
            R["adate"] = R["ratificationdate"];
            R["printdate"] = R["ratificationdate"];
            R["description"] = "Carico storico";
            R["idreg"] = idreg;
            R["idmot"] = idmot;
            R["ct"] = DateTime.Now;
            R["lt"] = DateTime.Now;
            R["cu"] = "SWMORE";
            R["lu"] = "SWMORE";
            Assetunload.Rows.Add(R);
        }

        public static bool EsportaBuonoScarico(Form form, DataAccess SourceConn, DataAccess DestConn) {
            if (DestConn.RUN_SELECT_COUNT("assetunload", null, false) > 0) return true;

            EsportaTipoBuonoScarico(form, SourceConn, DestConn);
            EsportaCausaleScarico(form, SourceConn, DestConn);

            DataTable Assetunload = DestConn.CreateTableByName("assetunload", "*");
            int maxassetunload = 0;

            //Crea i buoni fittizi per ovviare a rif. chiavi inesistenti
            //Crea le righe che non esistono ma sono referenziate
            DataTable Error1 = SourceConn.SQLRunner(
                "SELECT distinct T.idassetunloadkind, AL.idmot , REG.idreg, " +
                        " C.esercbuonoinventario,C.numbuonoinventario from scaricobeneinventario C " +
                    " JOIN " + getExtAccess(DestConn, "assetunloadkind", false) +
                                " T ON T.codeassetunloadkind= C.codicetipobuono " +
                    " LEFT OUTER JOIN " + getExtAccess(DestConn, "assetunloadmotive", false) +
                                " AL ON AL.codemot= C.codicecausale " +
                    " LEFT OUTER JOIN creditoredebitore CRED ON CRED.codicecreddeb= C.codicecreddeb " +
                    " LEFT OUTER JOIN " + getExtAccess(DestConn, "registry", true) +
                                " REG ON REG.title= CRED.denominazione " +
                    " WHERE C.esercbuonoinventario is not null and C.numbuonoinventario is not null and " +
                    " NOT EXISTS(SELECT * FROM buonoscaricoinventario BC WHERE " +
                            "BC.codicetipobuono= C.codicetipobuono and " +
                            "BC.esercbuonoinventario= C.esercbuonoinventario AND " +
                            "BC.numbuonoinventario = C.numbuonoinventario)");
            foreach (DataRow R in Error1.Rows) CreaRigafittizaBuonoScarico(R["idassetunloadkind"], R["esercbuonoinventario"],
                    R["numbuonoinventario"], R["idmot"], R["idreg"], Assetunload, ref maxassetunload);



            Error1 = SourceConn.SQLRunner(
                 "SELECT distinct T.idassetunloadkind, AL.idmot , REG.idreg, " +
                         " C.esercbuonoinventario,C.numbuonoinventario from scaricoparteinventario C " +
                     " JOIN " + getExtAccess(DestConn, "assetunloadkind", false) +
                                 " T ON T.codeassetunloadkind= C.codicetipobuono " +
                     " LEFT OUTER JOIN " + getExtAccess(DestConn, "assetunloadmotive", false) +
                                 " AL ON AL.codemot= C.codicecausale " +
                     " LEFT OUTER JOIN creditoredebitore CRED ON CRED.codicecreddeb= C.codicecreddeb " +
                     " LEFT OUTER JOIN " + getExtAccess(DestConn, "registry", true) +
                                 " REG ON REG.title= CRED.denominazione " +
                     " WHERE C.esercbuonoinventario is not null and C.numbuonoinventario is not null and " +
                     " NOT EXISTS(SELECT * FROM buonoscaricoinventario BC WHERE " +
                             "BC.codicetipobuono= C.codicetipobuono and " +
                             "BC.esercbuonoinventario= C.esercbuonoinventario AND " +
                             "BC.numbuonoinventario = C.numbuonoinventario)");
            foreach (DataRow R in Error1.Rows) CreaRigafittizaBuonoScarico(R["idassetunloadkind"], R["esercbuonoinventario"],
                    R["numbuonoinventario"], R["idmot"], R["idreg"], Assetunload, ref maxassetunload);

            Error1 = SourceConn.SQLRunner(
                "SELECT distinct T.idassetunloadkind, AL.idmot ,  " +
                        " C.esercbuonoinventario,C.numbuonoinventario from diminuzionevalorebene C " +
                    " JOIN " + getExtAccess(DestConn, "assetunloadkind", false) +
                                " T ON T.codeassetunloadkind= C.codicetipobuono " +
                    " LEFT OUTER JOIN " + getExtAccess(DestConn, "assetunloadmotive", false) +
                                " AL ON AL.codemot= C.codicecausale " +
                    " WHERE C.esercbuonoinventario is not null and C.numbuonoinventario is not null and " +
                    " NOT EXISTS(SELECT * FROM buonoscaricoinventario BC WHERE " +
                            "BC.codicetipobuono= C.codicetipobuono and " +
                            "BC.esercbuonoinventario= C.esercbuonoinventario AND " +
                            "BC.numbuonoinventario = C.numbuonoinventario)");
            foreach (DataRow R in Error1.Rows) CreaRigafittizaBuonoScarico(R["idassetunloadkind"], R["esercbuonoinventario"],
                    R["numbuonoinventario"], R["idmot"], DBNull.Value, Assetunload, ref maxassetunload);



            Error1 = SourceConn.SQLRunner(
                "SELECT distinct T.idassetunloadkind, AL.idmot ,  " +
                        " C.esercbuonoinventario,C.numbuonoinventario from diminuzionevaloreparte C " +
                    " JOIN " + getExtAccess(DestConn, "assetunloadkind", false) +
                                " T ON T.codeassetunloadkind= C.codicetipobuono " +
                    " LEFT OUTER JOIN " + getExtAccess(DestConn, "assetunloadmotive", false) +
                                " AL ON AL.codemot= C.codicecausale " +
                    " WHERE C.esercbuonoinventario is not null and C.numbuonoinventario is not null and " +
                    " NOT EXISTS(SELECT * FROM buonoscaricoinventario BC WHERE " +
                            "BC.codicetipobuono= C.codicetipobuono and " +
                            "BC.esercbuonoinventario= C.esercbuonoinventario AND " +
                            "BC.numbuonoinventario = C.numbuonoinventario)");
            foreach (DataRow R in Error1.Rows) CreaRigafittizaBuonoScarico(R["idassetunloadkind"], R["esercbuonoinventario"],
                    R["numbuonoinventario"], R["idmot"], DBNull.Value, Assetunload, ref maxassetunload);

            string sql = "SELECT C.*, T.idassetunloadkind, AL.idmot, REG.idreg from buonoscaricoinventario C " +
                     " JOIN " + getExtAccess(DestConn, "assetunloadkind", false) +
                                 " T ON T.codeassetunloadkind= C.codicetipobuono " +
                     " LEFT OUTER JOIN " + getExtAccess(DestConn, "assetloadmotive", false) +
                                 " AL ON AL.codemot= C.codicecausale " +
                     " LEFT OUTER JOIN creditoredebitore CRED ON CRED.codicecreddeb= C.codicecreddeb " +
                     " LEFT OUTER JOIN " + getExtAccess(DestConn, "registry", true) +
                                 " REG ON REG.title= CRED.denominazione ";
            DataTable All = SourceConn.SQLRunner(sql);

            foreach (DataRow Curr in All.Rows) {
                DataRow R = Assetunload.NewRow();
                maxassetunload++;
                R["idassetunload"] = maxassetunload;
                R["idassetunloadkind"] = Curr["idassetunloadkind"];
                R["yassetunload"] = Curr["esercbuonoinventario"];
                R["nassetunload"] = Curr["numbuonoinventario"];
                R["description"] = Curr["descrizione"];
                R["adate"] = Curr["datacontabile"];
                R["doc"] = Curr["documento"];
                R["docdate"] = Curr["datadocumento"];
                R["enactment"] = Curr["provvedimento"];
                R["enactmentdate"] = Curr["dataprovvedimento"];
                R["idreg"] = Curr["idreg"];
                R["printdate"] = Curr["datastampa"];
                R["ratificationdate"] = Curr["dataratifica"];
                R["idmot"] = Curr["idmot"];

                R["txt"] = Curr["notes"];
                R["rtf"] = Curr["olenotes"];
                R["lu"] = Curr["lastmoduser"];
                R["cu"] = Curr["createuser"];
                R["lt"] = Curr["lastmodtimestamp"];
                R["ct"] = Curr["createtimestamp"];
                Assetunload.Rows.Add(R);
            }


            DataSet ds = new DataSet();
            ds.Tables.Add(Assetunload);

            return Migrazione.lanciaScript(form, DestConn, ds, "Popolamento Assetunload");
        }


        public static Hashtable lookupidassetusagekind = new Hashtable();
        public static bool EsportaTipoUtilizzo_eseguito = false;
        public static bool EsportaTipoUtilizzo(Form form, DataAccess SourceConn, DataAccess DestConn) {
            if (EsportaTipoUtilizzo_eseguito) return true;
            EsportaTipoUtilizzo_eseguito = true;
            DataTable Existent = DestConn.SQLRunner("SELECT * from assetusagekind");
            foreach (DataRow RC in Existent.Rows) {
                lookupidassetusagekind[RC["codeassetusagekind"].ToString().ToUpper()] = RC["idassetusagekind"];
            }
            Existent.CaseSensitive = false;

            DataTable AssetUsageKind = DestConn.CreateTableByName("assetusagekind", "*");
            int maxusagekind = CfgFn.GetNoNullInt32(DestConn.DO_READ_VALUE("assetusagekind", null, "max(idassetusagekind)"));
            DataTable All = SourceConn.SQLRunner("SELECT * from tipoutilizzoinventario");
            foreach (DataRow Curr in All.Rows) {
                string codice= Curr["codicetipoutilizzo"].ToString().ToUpper();
                if (lookupidassetusagekind[codice] != null) continue;
                string find = QHC.CmpEq("description", Curr["descrizione"]);
                DataRow []found=Existent.Select(find);
                if (found.Length> 0) {
                    lookupidassetusagekind[codice] = found[0]["idassetusagekind"];
                    continue;
                }
                DataRow R = AssetUsageKind.NewRow();
                maxusagekind++;
                R["idassetusagekind"] = maxusagekind;
                R["codeassetusagekind"] = Curr["codicetipoutilizzo"];
                R["description"] = Curr["descrizione"];
                R["lu"] = Curr["lastmoduser"];
                R["cu"] = Curr["createuser"];
                R["lt"] = Curr["lastmodtimestamp"];
                R["ct"] = Curr["createtimestamp"];
                AssetUsageKind.Rows.Add(R);
            }


            DataSet ds = new DataSet();
            ds.Tables.Add(AssetUsageKind);

            return Migrazione.lanciaScript(form, DestConn, ds, "Popolamento AssetUsageKind");
        }

        public static bool EsportaUtilizzoCarico(Form form, DataAccess SourceConn, DataAccess DestConn) {
            if (DestConn.RUN_SELECT_COUNT("assetusage", null, false) > 0) return true;

            DataTable AssetUsage = DestConn.CreateTableByName("assetusage", "*");
            string sql = "SELECT * from utilizzocarico ";

            DataTable All = SourceConn.SQLRunner(sql);
            foreach (DataRow Curr in All.Rows) {
                DataRow R = AssetUsage.NewRow();
                string codice= Curr["codicetipoutilizzo"].ToString().ToUpper();
                R["idassetusagekind"] = lookupidassetusagekind[codice];
                R["nassetacquire"] =  LookupNumCaricoBene[Curr["numcaricobene"]];
                R["usagequota"] = Curr["quotautilizzo"];
                R["lu"] = Curr["lastmoduser"];
                R["cu"] = Curr["createuser"];
                R["lt"] = Curr["lastmodtimestamp"];
                R["ct"] = Curr["createtimestamp"];
                AssetUsage.Rows.Add(R);
            }


            DataSet ds = new DataSet();
            ds.Tables.Add(AssetUsage);

            return Migrazione.lanciaScript(form, DestConn, ds, "Popolamento AssetUsage");
        }


        public static bool EsportaVariazionePatrimonio(Form form, DataAccess SourceConn, DataAccess DestConn) {
            EsportaEnteInventario(form, SourceConn, DestConn);
            string sql = "SELECT V.*, EI.idinventoryagency "
                    + "from variazionepatrimonio V "
                    + "left outer join " + getExtAccess(DestConn, "inventoryagency", false) + " EI " +
                            "ON EI.codeinventoryagency = V.codiceenteinv ";
            DataTable All = SourceConn.SQLRunner(sql);
            if (All.Rows.Count == 0) return true;

            DataTable AssetVar = DestConn.CreateTableByName("assetvar","*");
            int nmaxassetvar = 0;
            foreach (DataRow Curr in All.Rows) {
                DataRow R = AssetVar.NewRow();
                nmaxassetvar++;
                R["idassetvar"] = nmaxassetvar;
                R["flag"] = Curr["tipovariazione"].ToString().ToUpper() == "N" ? 1 : 0;
                R["yvar"] = Curr["esercvariazione"];
                R["nvar"] = Curr["numvariazione"];
                R["description"] = Curr["descrizione"];
                R["adate"] = Curr["datacontabile"];
                R["idinventoryagency"] = Curr["idinventoryagency"];
                R["enactment"] = Curr["provvedimento"];
                R["enactmentdate"] = Curr["dataprovved"];
                R["nenactment"] = Curr["numprovved"];

                R["txt"] = Curr["notes"];
                R["rtf"] = Curr["olenotes"];
                R["lu"] = Curr["lastmoduser"];
                R["cu"] = Curr["createuser"];
                R["lt"] = Curr["lastmodtimestamp"];
                R["ct"] = Curr["createtimestamp"];
                AssetVar.Rows.Add(R);

            }
            DataSet ds = new DataSet();
            ds.Tables.Add(AssetVar);

            return Migrazione.lanciaScript(form, DestConn, ds, "Popolamento AssetVar");

        }

        public static bool EsportaDettVariazionePatrimonio(Form form, DataAccess SourceConn, DataAccess DestConn) {
            EsportaEnteInventario(form, SourceConn, DestConn);
            string sql = "SELECT V.*, AV.idassetvar, IT.idinv "
                    + "from dettvarpatrimonio V "
                    + "left outer join " + getExtAccess(DestConn, "assetvar", false) + " AV " +
                            "ON AV.yvar = V.esercvariazione AND AV.nvar=V.numvariazione "
                    + "LEFT OUTER JOIN classinventario CI ON CI.idclass= V.idclass "
                    + "LEFT OUTER JOIN " + getExtAccess(DestConn, "inventorytree", true) + " IT ON IT.codeinv= CI.codiceclass ";
            DataTable All = SourceConn.SQLRunner(sql);
            if (All.Rows.Count == 0) return true;

            DataTable AssetVarDetail = DestConn.CreateTableByName("assetvardetail","*");

            Hashtable Hassetvar = new Hashtable();

            foreach (DataRow Curr in All.Rows) {
                DataRow R = AssetVarDetail.NewRow();
                R["idassetvar"]= Curr["idassetvar"];
                object iddetail = Hassetvar[R["idassetvar"]];
                if (iddetail == null) {
                    iddetail = (int) 1;
                }
                else {
                    iddetail = (int)iddetail + 1;
                }
                Hassetvar[R["idassetvar"]] = iddetail;
                R["idassetvardetail"] = iddetail;

                R["idinv"] = Curr["idinv"];
                R["description"] = Curr["descrizione"];
                R["amount"] = Curr["importo"];         

                R["lu"] = Curr["lastmoduser"];
                R["cu"] = Curr["createuser"];
                R["lt"] = Curr["lastmodtimestamp"];
                R["ct"] = Curr["createtimestamp"];
                AssetVarDetail.Rows.Add(R);

            }
            DataSet ds = new DataSet();
            ds.Tables.Add(AssetVarDetail);

            return Migrazione.lanciaScript(form, DestConn, ds, "Popolamento AssetVarDetail");

        }


        public static bool EsportaResponsabileInventario(Form form, DataAccess SourceConn, DataAccess DestConn) {
            EsportaResponsabile(form, SourceConn, DestConn);
            string sql =
                "SELECT M1.idman, IDBENE, B.lastmoduser,B.lastmodtimestamp, "
                + " B.createuser, B.createtimestamp from BENEINVENTARIABILE B "
                + " LEFT OUTER JOIN responsabile M ON B.codiceresponsabile= M.codiceresponsabile "
                + " LEFT OUTER JOIN " + getExtAccess(DestConn, "manager", false) + " M1 ON M1.title = M.nome "
                + " WHERE B.codiceresponsabile is not null";
            //Esporta prima i responsabili iniziali
            DataTable RespIni= SourceConn.SQLRunner(sql);
            DataTable OtherResp = SourceConn.SQLRunner("SELECT * from responsabileinventario "
                + " LEFT OUTER JOIN responsabile M ON responsabileinventario.codiceresponsabile= M.codiceresponsabile "
                + " LEFT OUTER JOIN " + getExtAccess(DestConn, "manager", false) + " M1 ON M1.title = M.nome ");
            Hashtable AssMan = new Hashtable();

            DataTable AssetManager = DestConn.CreateTableByName("assetmanager", "*");
            
            foreach (DataRow Curr in RespIni.Rows) {
                DataRow R = AssetManager.NewRow();
                object idasset = LookupNumBene[Curr["idbene"]];
                int n = 1;
                AssMan[idasset] = n;
                R["idassetmanager"] = n;
                R["idman"] = Curr["idman"];
                R["lu"] = Curr["lastmoduser"];
                R["cu"] = Curr["createuser"];
                R["lt"] = Curr["lastmodtimestamp"];
                R["ct"] = Curr["createtimestamp"];
                AssetManager.Rows.Add(R);
            }

            foreach (DataRow Curr in OtherResp.Rows) {
                DataRow R = AssetManager.NewRow();
                object idasset = LookupNumBene[Curr["idbene"]];
                object n = AssMan[idasset];
                if (n == null) {
                    n = (int)1;
                }
                else {
                    n = (int)n + 1;
                }
                AssMan[idasset] = n;
                R["idassetmanager"] = n;
                R["idman"] = Curr["idman"];
                R["start"] = Curr["datainizio"];
                R["lu"] = Curr["lastmoduser"];
                R["cu"] = Curr["createuser"];
                R["lt"] = Curr["lastmodtimestamp"];
                R["ct"] = Curr["createtimestamp"];
                AssetManager.Rows.Add(R);
            }

            DataSet ds = new DataSet();
            ds.Tables.Add(AssetManager);

            return Migrazione.lanciaScript(form, DestConn, ds, "Popolamento AssetManager");


        }


        public static bool EsportaUbicazioneInventario(Form form, DataAccess SourceConn, DataAccess DestConn) {
            EsportaUbicazione(form, SourceConn, DestConn);
            string sql = "SELECT U1.idlocation, IDBENE, B.lastmoduser,B.lastmodtimestamp, "
                + " B.createuser, B.createtimestamp from BENEINVENTARIABILE B "
                + " LEFT OUTER JOIN UBICAZIONE U ON B.idubicazione= U.idubicazione "
                + " LEFT OUTER JOIN " + getExtAccess(DestConn, "location", false) + " U1 ON U1.locationcode = U.codiceubicazione "
                + " WHERE B.idubicazione is not null";
            //Esporta prima i responsabili iniziali
            DataTable RespIni = SourceConn.SQLRunner(sql);
            DataTable OtherResp = SourceConn.SQLRunner("SELECT * from ubicazioneinventario "
                + " LEFT OUTER JOIN UBICAZIONE U ON ubicazioneinventario.idubicazione= U.idubicazione "
                + " LEFT OUTER JOIN " + getExtAccess(DestConn, "location", false) + " U1 ON U1.locationcode = U.codiceubicazione ");
            Hashtable AssLoc = new Hashtable();

            DataTable AssetLocation = DestConn.CreateTableByName("assetlocation", "*");

            foreach (DataRow Curr in RespIni.Rows) {
                DataRow R = AssetLocation.NewRow();
                object idasset = LookupNumBene[Curr["idbene"]];
                int n = 1;
                AssLoc[idasset] = n;
                R["idasset"] = idasset;
                R["idassetlocation"] = n;
                R["idlocation"] = Curr["idlocation"];
                R["lu"] = Curr["lastmoduser"];
                R["cu"] = Curr["createuser"];
                R["lt"] = Curr["lastmodtimestamp"];
                R["ct"] = Curr["createtimestamp"];
                AssetLocation.Rows.Add(R);
            }

            foreach (DataRow Curr in OtherResp.Rows) {
                DataRow R = AssetLocation.NewRow();
                object idasset = LookupNumBene[Curr["idbene"]];
                object n = AssLoc[idasset];
                if (n == null) {
                    n = (int)1;
                }
                else {
                    n = (int)n + 1;
                }
                AssLoc[idasset] = n;
                R["idasset"] = idasset;
                R["idassetlocation"] = n;
                R["idlocation"] = Curr["idlocation"];
                R["start"] = Curr["datainizio"];
                R["lu"] = Curr["lastmoduser"];
                R["cu"] = Curr["createuser"];
                R["lt"] = Curr["lastmodtimestamp"];
                R["ct"] = Curr["createtimestamp"];
                AssetLocation.Rows.Add(R);
            }

            DataSet ds = new DataSet();
            ds.Tables.Add(AssetLocation);

            return Migrazione.lanciaScript(form, DestConn, ds, "Popolamento AssetLocation");


        }




       

		/// <summary>
		/// Metodo da chiamare se il checkBox del patrimonio è checked.
		/// Migra tutte le tabelle del Patrimonio, di configurazione e non.
		/// </summary>
		/// <param name="form"></param>
		/// <param name="sourceConn"></param>
		/// <param name="destConn"></param>
		/// <param name="tTableName"></param>
		/// <param name="tColName"></param>
		public static bool migraPatrimonio(Form form, DataAccess sourceConn, DataAccess destConn) 
		{
            if (!EsportaCausaleCarico(form, sourceConn, destConn)) return false;
            if (!EsportaCausaleScarico(form, sourceConn, destConn)) return false;
            if (!EsportaEnteInventario(form, sourceConn, destConn)) return false;
            if (!EsportaTipoInventario(form, sourceConn, destConn)) return false;
            if (!EsportaInventario(form, sourceConn, destConn)) return false;
            if (!EsportaTipoBuonoCarico(form, sourceConn, destConn)) return false;
            if (!EsportaTipoBuonoScarico(form, sourceConn, destConn)) return false;
            if (!EsportaLivelloInventario(form, sourceConn, destConn)) return false;
            if (!EsportaClassInventario(form, sourceConn, destConn)) return false;
            if (!EsportaLivelloUbicazione(form, sourceConn, destConn)) return false;
            if (!EsportaUbicazione(form, sourceConn, destConn)) return false;
            if (!EsportaBuonoCarico(form, sourceConn, destConn)) return false;
            if (!EsportaBuonoScarico(form, sourceConn, destConn)) return false;


            //CaricoBeneInventario -> AssetAcquire
            int lastNAssetAcquire;
            if (!esportaCaricoBeneInventario(form, sourceConn, destConn, out lastNAssetAcquire)) return false;

            //BeneInventariabile -> asset
            if (!esportaBeneinventariabile(form, sourceConn, destConn)) return false;

            //CaricoParteInventario -> AssetAcquire
            int newlastNAssetAcquire;
            if (!esportaCaricoParteInventario(form, sourceConn, destConn, lastNAssetAcquire, out newlastNAssetAcquire)) return false;

            //(partenoninventariabile -> asset) e (scaricoparteinventario -> assetacquire)
            //int newlastNAssetAcquire;
            if (!esportaPartenoninventariabile(form, sourceConn, destConn, lastNAssetAcquire)) return false;
            lastNAssetAcquire = newlastNAssetAcquire;

            //AumentoValoreBene -> AssetAcquire
            if (!esportaAumentoValoreBene(form, sourceConn, destConn, lastNAssetAcquire, out newlastNAssetAcquire)) return false;
            lastNAssetAcquire = newlastNAssetAcquire;

            //DiminuzioneValoreBene -> AssetAcquire
            if (!esportaDiminuzioneValoreBene(form, sourceConn, destConn, lastNAssetAcquire, out newlastNAssetAcquire)) return false;
            lastNAssetAcquire = newlastNAssetAcquire;

            //eventotecnico -> maintenance
            if (!esportaEventoTecnico(form, sourceConn, destConn)) return false;

            //rivalutazionebene -> assetamortization
            if (!EsportaTipoAmmortamento(form, sourceConn, destConn)) return false;
            if (!(esportaRivalutazioneBene(form, sourceConn, destConn))) return false;
            if (!(esportaRivalutazioneInventario(form, sourceConn, destConn))) return false;

            if (!(EsportaVariazionePatrimonio(form, sourceConn, destConn))) return false;
            if (!(EsportaDettVariazionePatrimonio(form, sourceConn, destConn))) return false;

            if (!EsportaResponsabile(form, sourceConn, destConn)) return false;
            if (!EsportaResponsabileInventario(form, sourceConn, destConn)) return false;
            if (!EsportaUbicazioneInventario(form, sourceConn, destConn)) return false;

            if (!EsportaTipoUtilizzo(form, sourceConn, destConn)) return false;
            if (!EsportaUtilizzoCarico(form, sourceConn, destConn)) return false;
            return true;

           
			
		}
	}
}
