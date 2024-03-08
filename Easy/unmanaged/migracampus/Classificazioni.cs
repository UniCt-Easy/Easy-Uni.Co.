
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
using System.Windows.Forms;
using metadatalibrary;
using System.Data;
using System.Collections;
using LiveUpdate;
using System.Text;
using funzioni_configurazione;

namespace Install
{
	/// <summary>
	/// Summary description for Classificazioni.
	/// </summary>
	public class Classificazioni {
        public static void Reset() {
            lookupidsorkind = new Hashtable();
            lookupTableName = new Hashtable();
            MigraTipoClassMovimenti_eseguito = false;
            MigraTipoClassTabelle_eseguito = false;
            MigraClassMovimenti_eseguito = false;
            MigraClassTabelle_eseguito = false;

        }

        public static string getExtAccess(DataAccess Conn, string table, bool dbo) {
            //DBNAME.owner"
            if (dbo)
                return Conn.GetSys("database").ToString() + ".dbo." + table;
            else
                return Conn.GetSys("database").ToString() + "." + Conn.GetSys("userdb").ToString() + "." + table;
        }

		private static void getDescrizioniClassificazioni(string classificazione, Form form, out string tipoCodice, out string codiceTipoClass) {
			tipoCodice = null;
			codiceTipoClass = null;
			switch (classificazione) {
				case "bilancio": tipoCodice = "class"; codiceTipoClass = "_CLBIL"; break;
				case "murst": tipoCodice = "murst";	codiceTipoClass = "_CLMURST"; break;
				case "consolidamento": tipoCodice = "consolid";	codiceTipoClass = "_CLCONS"; break;
				default: MessageBox.Show(form, "Errore interno: non esiste la tabella class"+classificazione); break;
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
		public static bool creaRigheInFinSorting(string classificazione, Hashtable ht, 
                Form form, DataAccess sourceConn, DataAccess destConn) {
            Upb.migraBilancio(form, sourceConn, destConn);

			string tipoCodice = null;
			string codiceTipoClass = null;
			getDescrizioniClassificazioni(classificazione, form, out tipoCodice, out codiceTipoClass);
            string query = "select "
                + "ct=createtimestamp, "
                + "cu=createuser, "
                + "fin.idfin, "
                + "codice=codice" + tipoCodice
                + ", lt=lastmodtimestamp, "
                + "lu=lastmoduser "
                + "from bilancio "
                + " JOIN " + getExtAccess(destConn, "fin", false) + " fin"
                + "  ON fin.codefin=bilancio.codicebilancio "
                + "  AND fin.ayear=bilancio.esercizio "
                + "  AND (  ((fin.flag & 1)=0 AND (bilancio.partebilancio='E')) "
                + "         OR ((fin.flag & 1)<>0 AND (bilancio.partebilancio='S')) ) "
                + "where codice" + tipoCodice + " is not null  ";


			DataTable All = Migrazione.eseguiQuery(sourceConn, query, form);
            DataTable FinSor = destConn.CreateTableByName("finsorting", "*");

			foreach(DataRow Curr in All.Select()) {
                string codice = Curr["codice"].ToString().ToUpper();
                if (ht[codice] == null) {
					MessageBox.Show("La classificazione ("+classificazione+")"+
                                        codice + " non è stata trovata nella tabella " +
										classificazione);
                    ht[codice] = DBNull.Value;
				}
                if (ht[codice] == DBNull.Value) {
					continue; //scartato!
				}
                DataRow R = FinSor.NewRow();
                R["idsor"] = ht[codice];
                R["quota"]=1;
                foreach (string S in new string[] { "ct", "cu", "lt", "lu", "idfin" }) {
                    R[S] = Curr[S];
                }
                FinSor.Rows.Add(R);
			}


			DataSet ds = new DataSet();
            ds.Tables.Add(FinSor);
			return Migrazione.lanciaScript(form,destConn, ds, "bilancio -> finsorting("+classificazione+")");
		}





        public static bool MigraClassCustom(Form form, DataAccess sourceConn, DataAccess destConn,
                out int idsorkind, out Hashtable lookupcustomidsor,
                string codesorkind, string description, string customtable, string customcodefield) {
            lookupcustomidsor = new Hashtable();
            QueryHelper QHS = destConn.GetQueryHelper();
            idsorkind = 0;
            if (destConn.RUN_SELECT_COUNT("sortingkind", QHS.CmpEq("codesorkind", codesorkind), false) > 0) return true;

            //Inserisce in Sortingkind
            DataTable SorKind = destConn.CreateTableByName("sortingkind", "*");
            int nmaxsorkind = CfgFn.GetNoNullInt32(destConn.DO_READ_VALUE("sortingkind", null, "max(idsorkind)"));
            idsorkind = nmaxsorkind + 1;
            DataRow R = SorKind.NewRow();
            R["idsorkind"] = idsorkind;
            R["description"] = description;
            R["codesorkind"] = codesorkind;
            R["active"] = "N";
            R["cu"] = "swmore";
            R["flag"] = 0;
            R["lu"] = "swmore";
            R["lt"] = DateTime.Now;
            R["ct"] = DateTime.Now;
            SorKind.Rows.Add(R);

            //Inserisce in sortinglevel
            DataTable SorLevel = destConn.CreateTableByName("sortinglevel", "*");
            R = SorLevel.NewRow();
            R["idsorkind"] = idsorkind;
            R["description"] = "Livello 1";
            R["nlevel"] = 1;
            int flag = 0;
            flag = flag + 1; //Alfanum y
            flag = flag + 2; //usable y
            flag = flag + 4; //restart y
            flag = flag + 3 * 256; //codelen 3
            R["flag"] = flag;
            //R["active"] = "N";
            R["cu"] = "swmore";
            R["lu"] = "swmore";
            R["lt"] = DateTime.Now;
            R["ct"] = DateTime.Now;
            SorLevel.Rows.Add(R);

            //Inserisce in sorting
            DataTable All = sourceConn.SQLRunner("SELECT * FROM " + customtable);
            int nmaxsorting = CfgFn.GetNoNullInt32(destConn.DO_READ_VALUE("sorting", null, "max(idsor)"));
            DataTable Sor = destConn.CreateTableByName("sorting", "*");
            foreach (DataRow Curr in All.Rows) {
                nmaxsorting++;
                R = Sor.NewRow();
                R["idsor"] = nmaxsorting;
                R["sortcode"] = Curr[customcodefield];
                lookupcustomidsor[R["sortcode"].ToString().ToUpper()] = nmaxsorting;
                R["nlevel"] = 1;
                R["idsorkind"] = idsorkind;
                R["description"] = Curr["descrizione"];
                R["cu"] = Curr["createuser"];
                R["lu"] = Curr["lastmoduser"];
                R["lt"] = Curr["createtimestamp"];
                R["ct"] = Curr["lastmodtimestamp"];
                Sor.Rows.Add(R);
            }

            //Inserisce in sortingapplicability
            DataTable SorApp = destConn.CreateTableByName("sortingapplicability", "*");
            R = SorApp.NewRow();
            R["idsorkind"] = idsorkind;
            R["tablename"] = "fin";
            R["cu"] = "swmore";
            R["lu"] = "swmore";
            R["lt"] = DateTime.Now;
            R["ct"] = DateTime.Now;
            SorApp.Rows.Add(R);

            DataSet ds = new DataSet();
            ds.Tables.Add(SorKind);
            ds.Tables.Add(SorLevel);
            ds.Tables.Add(Sor);
            ds.Tables.Add(SorApp);

            return Migrazione.lanciaScript(form, destConn, ds, "Migrazione " + customtable);

        }


		public static bool migraClassBilancio(Form form, DataAccess sourceConn, DataAccess destConn) 
		{
			
			Hashtable htCorrispondiCodici;
			bool esecuzioneCorretta = true;

            int idsorkind;

            DialogResult dr = MessageBox.Show(form, "Procedo alla migrazione dei codici di classificazione "
			+ "CLASSBILANCIO presenti nella tabella bilancio?", "Conferma", MessageBoxButtons.YesNoCancel);
			if (dr == DialogResult.Yes) {
                esecuzioneCorretta = MigraClassCustom(form, sourceConn, destConn, out idsorkind, out htCorrispondiCodici,
                    "_CLBIL", "ex classbilancio", "classbilancio", "codiceclass");
				if (!esecuzioneCorretta) return false;
				esecuzioneCorretta = creaRigheInFinSorting("bilancio",htCorrispondiCodici, form, sourceConn, destConn);
				if (!esecuzioneCorretta) return false;
			}

			dr = MessageBox.Show(form, "Procedo alla migrazione dei codici di classificazione "
				+ "CLASSMURST presenti nella tabella bilancio?", "Conferma", MessageBoxButtons.YesNoCancel);
			if (dr == DialogResult.Yes) {
                esecuzioneCorretta = MigraClassCustom(form, sourceConn, destConn, out idsorkind, out htCorrispondiCodici,
                                    "_CLMURST", "ex classmurst", "classmurst", "codicemurst");
                if (!esecuzioneCorretta) return false;
                esecuzioneCorretta = creaRigheInFinSorting("murst", htCorrispondiCodici, form, sourceConn, destConn);
                if (!esecuzioneCorretta) return false;
			}

			dr = MessageBox.Show(form, "Procedo alla migrazione dei codici di classificazione "
				+ "CLASSCONSOLIDAMENTO presenti nella tabella bilancio?", "Conferma", MessageBoxButtons.YesNoCancel);
			if (dr == DialogResult.Yes) {
                esecuzioneCorretta = MigraClassCustom(form, sourceConn, destConn, out idsorkind, out htCorrispondiCodici,
                    "_CLCONS", "ex classconsolidamento", "classconsolidamento", "codiceconsolid");
                if (!esecuzioneCorretta) return false;
                esecuzioneCorretta = creaRigheInFinSorting("consolidamento", htCorrispondiCodici, form, sourceConn, destConn);
                if (!esecuzioneCorretta) return false;
			}

			return true;
		}

        public static Hashtable lookupidsorkind = new Hashtable();
        public static bool MigraTipoClassMovimenti_eseguito = false;
        public static bool MigraTipoClassMovimenti(Form form, DataAccess SourceConn, DataAccess destConn){
            if (MigraTipoClassMovimenti_eseguito) return true;
            MigraTipoClassMovimenti_eseguito = true;

            DataTable Existent = destConn.SQLRunner("SELECT * from sortingkind");
            foreach (DataRow RC in Existent.Rows) {
                string code = RC["codesorkind"].ToString().ToUpper();
                lookupidsorkind[code] =RC["idsorkind"];
            }

            DataTable All = SourceConn.SQLRunner("SELECT "+
                " M.codicefaseentrata, M.codicefasespesa, M.codicetipoclass,"+
                " ct=M.createtimestamp,cu=M.createuser,description=M.descrizione,"+
                " M.flagdisponibilita, M.flagobbligatoria,"+
                " lt=M.lastmodtimestamp,lu=M.lastmoduser "+
                " FROM tipoclassmovimenti M");
            if (All.Rows.Count == 0) return true;
            DataTable SorKind = destConn.CreateTableByName("sortingkind", "*");
            int idsorkindmax = CfgFn.GetNoNullInt32(destConn.DO_READ_VALUE("sortingkind", null, "max(idsorkind)"));
            foreach (DataRow Curr in All.Rows) {
                string codesorkind=Curr["codicetipoclass"].ToString();
                if (lookupidsorkind[codesorkind.ToUpper()] != null) continue;
                idsorkindmax++;
                DataRow R = SorKind.NewRow();
                R["idsorkind"] = idsorkindmax;
                R["codesorkind"] = codesorkind;
                lookupidsorkind[codesorkind.ToUpper()] = idsorkindmax;
                if (Curr["codicefaseentrata"] != DBNull.Value)
                    R["nphaseincome"] = CfgFn.GetNoNullInt32(Curr["codicefaseentrata"]);
                if (Curr["codicefasespesa"] != DBNull.Value)
                    R["nphaseexpense"] = CfgFn.GetNoNullInt32(Curr["codicefasespesa"]);
                int flag = 0;
                if (Curr["flagobbligatoria"].ToString().ToUpper() == "S") flag += 1;
                if (Curr["flagdisponibilita"].ToString().ToUpper() == "S") flag += 2;
                R["flag"] = flag;
                foreach (string S in new string[] { "ct", "cu", "description", "lt", "lu" }) {
                    R[S] = Curr[S];
                }
                SorKind.Rows.Add(R);
            }
            if (SorKind.Rows.Count == 0) return true;
            DataSet ds = new DataSet();
            ds.Tables.Add(SorKind);

            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento SorKind da TipoClassMov");

        }

        public static Hashtable lookupTableName= new Hashtable();
        public static void RiempiLookupTableName(){
            lookupTableName["sezione"]="division";
            lookupTableName["classinventario"]="inventorytree";
            lookupTableName["responsabile"]="manager";
            lookupTableName["bilancio"]="fin";
            lookupTableName["ubicazione"]="location";
            lookupTableName["creditoredebitore"]="registry";
            lookupTableName["responsabile"]="manager";
        }


        static bool MigraTipoClassTabelle_eseguito = false;
        public static bool MigraTipoClassTabelle(Form form, DataAccess SourceConn, DataAccess destConn) {
            if (MigraTipoClassTabelle_eseguito) return true;
            MigraTipoClassTabelle_eseguito = true;
            DataTable Existent = destConn.SQLRunner("SELECT * from sortingkind");
            foreach (DataRow RC in Existent.Rows) {
                string code = RC["codesorkind"].ToString().ToUpper();
                lookupidsorkind[code] = RC["idsorkind"];
            }

            DataTable All = SourceConn.SQLRunner("SELECT " +
                " M.codicetipoclass," +
                " ct=M.createtimestamp,cu=M.createuser,description=M.descrizione," +
                " M.nometabella, " +
                " lt=M.lastmodtimestamp,lu=M.lastmoduser " +
                " FROM tipoclasstabelle M");
            if (All.Rows.Count == 0) return true;

            RiempiLookupTableName();
            QueryHelper QHS= destConn.GetQueryHelper();

            DataTable SorKind = destConn.CreateTableByName("sortingkind", "*");
            DataTable SorKindApp= destConn.CreateTableByName("sortingapplicability","*");
            int idsorkindmax = CfgFn.GetNoNullInt32(destConn.DO_READ_VALUE("sortingkind", null, "max(idsorkind)"));
            foreach (DataRow Curr in All.Rows) {
                string codesorkind = Curr["codicetipoclass"].ToString();
                if (lookupidsorkind[codesorkind.ToUpper()] == null) {
                    idsorkindmax++;
                    DataRow R = SorKind.NewRow();
                    R["idsorkind"] = idsorkindmax;
                    R["codesorkind"] = codesorkind;
                    lookupidsorkind[codesorkind.ToUpper()] = idsorkindmax;
                    int flag = 0;
                    R["flag"] = flag;
                    foreach (string S in new string[] { "ct", "cu", "description", "lt", "lu" }) {
                        R[S] = Curr[S];
                    }
                    SorKind.Rows.Add(R);
                }
                string newtable = lookupTableName[Curr["nometabella"].ToString().ToLower()].ToString();
                int idsorkind= CfgFn.GetNoNullInt32( lookupidsorkind[codesorkind.ToUpper()]);
                int N = destConn.RUN_SELECT_COUNT("sortingapplicability",
                    QHS.AppAnd(QHS.CmpEq("idsorkind",idsorkind),QHS.CmpEq("tablename",newtable)),false);
                if (N == 0) {
                    DataRow RR = SorKindApp.NewRow();
                    RR["idsorkind"] = idsorkind;
                    RR["tablename"]=lookupidsorkind[codesorkind.ToUpper()];
                    RR["ct"] = DateTime.Now;
                    RR["lt"] = DateTime.Now;
                    RR["cu"] = "swmore";
                    RR["lu"] = "swmore";
                    SorKindApp.Rows.Add(RR);
                }                    
            }
            if (SorKind.Rows.Count == 0  && SorKindApp.Rows.Count==0) return true;
            DataSet ds = new DataSet();
            if (SorKind.Rows.Count>0) ds.Tables.Add(SorKind);
            if (SorKindApp.Rows.Count>0) ds.Tables.Add(SorKindApp);

            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento SorKind da TipoClassTabelle");


        }

        public static bool MigraLivelloClassMovimenti(Form form, DataAccess sourceConn, DataAccess destConn) {
            DataTable AllTipoClassMov = sourceConn.SQLRunner("SELECT * from tipoclassmovimenti");
            if (AllTipoClassMov.Rows.Count == 0) return true;

            MigraTipoClassMovimenti(form, sourceConn, destConn);
            DataTable SortingLevel = destConn.CreateTableByName("sortinglevel", "*");
            QueryHelper SQ = sourceConn.GetQueryHelper();
            QueryHelper DQ = destConn.GetQueryHelper();

            foreach (DataRow CurrTipo in AllTipoClassMov.Rows) {
                //Migra la class. CurrTipo
                string codesorkind = CurrTipo["codicetipoclass"].ToString();
                int idsorkind = CfgFn.GetNoNullInt32( lookupidsorkind[codesorkind.ToUpper()]);

                if (destConn.RUN_SELECT_COUNT("sortinglevel", DQ.CmpEq("idsorkind", idsorkind), false) > 0) continue;

                DataTable AllLivClassMov = sourceConn.SQLRunner("SELECT * from livelloclassmovimenti WHERE " +
                    SQ.CmpEq("codicetipoclass", codesorkind));

                foreach (DataRow CurrLiv in AllLivClassMov.Rows) {
                    DataRow R = SortingLevel.NewRow();
                    R["idsorkind"] = idsorkind;
                    R["nlevel"] = CfgFn.GetNoNullInt32(CurrLiv["codicelivello"]);
                    R["description"] = CurrLiv["descrizione"];
                    int len = CfgFn.GetNoNullInt32(CurrLiv["lunghcodice"]);
                    int flag = 0;
                    if (CurrLiv["tipocodice"].ToString().ToUpper() == "A") flag += 1;
                    if (CurrLiv["flagoperativo"].ToString().ToUpper() == "S") flag += 2;
                    if (CurrLiv["flagreset"].ToString().ToUpper() == "S") flag += 4;
                    flag += len * 256;
                    R["flag"] = flag;
                    R["lu"] = CurrLiv["lastmoduser"];
                    R["cu"] = CurrLiv["createuser"];
                    R["lt"] = CurrLiv["lastmodtimestamp"];
                    R["ct"] = CurrLiv["createtimestamp"];
                    SortingLevel.Rows.Add(R);
                }

            }
            if (SortingLevel.Rows.Count == 0) return true;
            DataSet ds = new DataSet();
            ds.Tables.Add(SortingLevel);
            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento SortingLevel da LivelloClassMovimenti");
        }

        public static bool MigraLivelloClassTabelle(Form form, DataAccess sourceConn, DataAccess destConn) {
            DataTable AllTipoClassMov = sourceConn.SQLRunner("SELECT * from tipoclasstabelle");
            if (AllTipoClassMov.Rows.Count == 0) return true;

            MigraTipoClassTabelle(form, sourceConn, destConn);
            DataTable SortingLevel = destConn.CreateTableByName("sortinglevel", "*");
            QueryHelper SQ = sourceConn.GetQueryHelper();
            QueryHelper DQ = destConn.GetQueryHelper();

            foreach (DataRow CurrTipo in AllTipoClassMov.Rows) {
                //Migra la class. CurrTipo
                string codesorkind = CurrTipo["codicetipoclass"].ToString();
                int idsorkind = CfgFn.GetNoNullInt32(lookupidsorkind[codesorkind.ToUpper()]);

                if (destConn.RUN_SELECT_COUNT("sortinglevel", DQ.CmpEq("idsorkind", idsorkind), false) > 0) continue;

                DataTable AllLivClassMov = sourceConn.SQLRunner("SELECT * from livelloclasstabelle WHERE " +
                    SQ.CmpEq("codicetipoclass", codesorkind));

                foreach (DataRow CurrLiv in AllLivClassMov.Rows) {
                    DataRow R = SortingLevel.NewRow();
                    R["idsorkind"] = idsorkind;
                    R["nlevel"] = CfgFn.GetNoNullInt32(CurrLiv["codicelivello"]);
                    R["description"] = CurrLiv["descrizione"];
                    int len = CfgFn.GetNoNullInt32(CurrLiv["lunghcodice"]);
                    int flag = 0;
                    if (CurrLiv["tipocodice"].ToString().ToUpper() == "A") flag += 1;
                    if (CurrLiv["flagoperativo"].ToString().ToUpper() == "S") flag += 2;
                    if (CurrLiv["flagreset"].ToString().ToUpper() == "S") flag += 4;
                    flag += len * 256;
                    R["flag"] = flag;
                    R["lu"] = CurrLiv["lastmoduser"];
                    R["cu"] = CurrLiv["createuser"];
                    R["lt"] = CurrLiv["lastmodtimestamp"];
                    R["ct"] = CurrLiv["createtimestamp"];
                    SortingLevel.Rows.Add(R);
                }

            }
            if (SortingLevel.Rows.Count == 0) return true;
            DataSet ds = new DataSet();
            ds.Tables.Add(SortingLevel);
            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento SortingLevel da LivelloClassTabelle");
        }

        static bool MigraClassMovimenti_eseguito = false;
        public static bool MigraClassMovimenti(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (MigraClassMovimenti_eseguito) return true;
            MigraClassMovimenti_eseguito = true;
            DataTable AllTipoClassMov = sourceConn.SQLRunner("SELECT * from tipoclassmovimenti");
            if (AllTipoClassMov.Rows.Count == 0) return true;

            MigraTipoClassMovimenti(form, sourceConn, destConn);
            int maxidsor = CfgFn.GetNoNullInt32(destConn.DO_READ_VALUE("sorting", null, "max(idsor)"));
            DataTable Sorting = destConn.CreateTableByName("sorting", "*");
            QueryHelper SQ= sourceConn.GetQueryHelper();
            QueryHelper DQ = destConn.GetQueryHelper();
            CQueryHelper QHC = new CQueryHelper();

            foreach (DataRow CurrTipo in AllTipoClassMov.Rows) {
                //Migra la class. CurrTipo
                string codesorkind= CurrTipo["codicetipoclass"].ToString();
                int idsorkind = CfgFn.GetNoNullInt32( lookupidsorkind[codesorkind.ToUpper()]);

                if (destConn.RUN_SELECT_COUNT("sorting", DQ.CmpEq("idsorkind", idsorkind), false) > 0) continue;

                DataTable AllClassMov = sourceConn.SQLRunner("SELECT * from classmovimenti WHERE " +
                    SQ.CmpEq("codicetipoclass", codesorkind));

                foreach (DataRow CurrClass in AllClassMov.Select(null, "codicelivello")) {
                    maxidsor++;
                    DataRow R = Sorting.NewRow();
                    R["idsor"] = maxidsor;
                    R["idsorkind"] = idsorkind;
                    if (CfgFn.GetNoNullInt32(CurrClass["codicelivello"]) > 1) {
                        string filterparent = QHC.CmpEq("idclass", CurrClass["livsupidclass"]);
                        DataRow[] Parent = AllClassMov.Select(filterparent);
                        if (Parent.Length > 0) {
                            string myfilter = QHC.CmpEq("sortcode", Parent[0]["codiceclass"]);
                            DataRow[] myparent = Sorting.Select(myfilter);
                            if (myparent.Length > 0) R["paridsor"] = myparent[0]["idsor"];
                        }
                    }
                    R["description"] = CurrClass["descrizione"];
                    R["sortcode"] = CurrClass["codiceclass"];
                    R["nlevel"] = CfgFn.GetNoNullInt32(CurrClass["codicelivello"]);
                    R["txt"] = CurrClass["notes"];
                    R["rtf"] = CurrClass["olenotes"];
                    R["lu"] = CurrClass["lastmoduser"];
                    R["cu"] = CurrClass["createuser"];
                    R["lt"] = CurrClass["lastmodtimestamp"];
                    R["ct"] = CurrClass["createtimestamp"];
                    Sorting.Rows.Add(R);
                }

            }
            if (Sorting.Rows.Count == 0) return true;
            DataSet ds = new DataSet();
            ds.Tables.Add(Sorting);
            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento Sorting da ClassMovimenti");
        }

        static bool MigraClassTabelle_eseguito = false;
        public static bool MigraClassTabelle(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (MigraClassTabelle_eseguito) return true;
            MigraClassTabelle_eseguito = true;
            DataTable AllTipoClassTab = sourceConn.SQLRunner("SELECT * from tipoclasstabelle");
            if (AllTipoClassTab.Rows.Count == 0) return true;

            MigraTipoClassTabelle(form, sourceConn, destConn);
            int maxidsor = CfgFn.GetNoNullInt32(destConn.DO_READ_VALUE("sorting", null, "max(idsor)"));
            DataTable Sorting = destConn.CreateTableByName("sorting", "*");
            QueryHelper SQ = sourceConn.GetQueryHelper();
            QueryHelper DQ = destConn.GetQueryHelper();
            CQueryHelper QHC = new CQueryHelper();

            foreach (DataRow CurrTipo in AllTipoClassTab.Rows) {
                //Migra la class. CurrTipo
                string codesorkind = CurrTipo["codicetipoclass"].ToString();
                int idsorkind = CfgFn.GetNoNullInt32( lookupidsorkind[codesorkind.ToUpper()]);

                if (destConn.RUN_SELECT_COUNT("sorting", DQ.CmpEq("idsorkind", idsorkind), false) > 0) continue;

                DataTable AllClassMov = sourceConn.SQLRunner("SELECT * from classtabelle WHERE " +
                    SQ.CmpEq("codicetipoclass", codesorkind));

                foreach (DataRow CurrClass in AllClassMov.Select(null, "codicelivello")) {
                    maxidsor++;
                    DataRow R = Sorting.NewRow();
                    R["idsor"] = maxidsor;
                    R["idsorkind"] = idsorkind;
                    if (CfgFn.GetNoNullInt32(CurrClass["codicelivello"]) > 1) {
                        string filterparent = QHC.CmpEq("idclass", CurrClass["livsupidclass"]);
                        DataRow[] Parent = AllClassMov.Select(filterparent);
                        if (Parent.Length > 0) {
                            string myfilter = QHC.CmpEq("sortcode", Parent[0]["codiceclass"]);
                            DataRow[] myparent = Sorting.Select(myfilter);
                            if (myparent.Length > 0) R["paridsor"] = myparent[0]["idsor"];
                        }
                    }
                    R["description"] = CurrClass["descrizione"];
                    R["sortcode"] = CurrClass["codiceclass"];
                    R["nlevel"] = CfgFn.GetNoNullInt32(CurrClass["codicelivello"]);
                    R["txt"] = CurrClass["notes"];
                    R["rtf"] = CurrClass["olenotes"];
                    R["lu"] = CurrClass["lastmoduser"];
                    R["cu"] = CurrClass["createuser"];
                    R["lt"] = CurrClass["lastmodtimestamp"];
                    R["ct"] = CurrClass["createtimestamp"];
                    Sorting.Rows.Add(R);
                }

            }
            if (Sorting.Rows.Count == 0) return true;
            DataSet ds = new DataSet();
            ds.Tables.Add(Sorting);
            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento Sorting da ClassTabelle");
        }


        public static bool MigraPrevisioneClassMovimenti(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (destConn.RUN_SELECT_COUNT("sortingprev", null, false) > 0) return true;

            DataTable AllTipoClassMov = sourceConn.SQLRunner("SELECT * from tipoclassmovimenti");
            if (AllTipoClassMov.Rows.Count == 0) return true;

            MigraTipoClassMovimenti(form, sourceConn, destConn);
            MigraClassMovimenti(form, sourceConn, destConn);

            DataTable Sortingprev = destConn.CreateTableByName("sortingprev", "*");

            foreach (DataRow CurrTipo in AllTipoClassMov.Rows) {
                //Migra la class. CurrTipo
                string codesorkind = CurrTipo["codicetipoclass"].ToString();
                int idsorkind = CfgFn.GetNoNullInt32(lookupidsorkind[codesorkind.ToUpper()]);
                QueryHelper QHS = destConn.GetQueryHelper();

                DataTable All = sourceConn.SQLRunner(
                        "SELECT ct=M.createtimestamp,cu=M.createuser,ayear=M.esercizio,SOR.idsor,"+
                        "lt=M.lastmodtimestamp,lu=M.lastmoduser,incomeprevision=M.previsioneentrate,"+
                        " expenseprevision=M.previsionespese "+
                        " from previsioneclassmovimenti M " +
                        " JOIN classmovimenti C ON C.idclass=M.idclass AND C.codicetipoclass=M.codicetipoclass" +
                        " JOIN " + getExtAccess(destConn, "sorting", false) + " SOR " +
                        "   ON SOR.sortcode=C.codiceclass " +                       
                        " WHERE " +
                            QHS.AppAnd(QHS.CmpEq("M.codicetipoclass", codesorkind),
                                    QHS.CmpEq("SOR.idsorkind", idsorkind)) );
                foreach (DataRow ImpClass in All.Rows) {
                    DataRow R = Sortingprev.NewRow();
                    foreach (string S in new string[] { "ct", "cu", "ayear", "idsor", "lt", "lu",
                                            "incomeprevision", "expenseprevision" }) {
                        R[S] = ImpClass[S];
                    }
                    Sortingprev.Rows.Add(R);
                }

            }
            if (Sortingprev.Rows.Count == 0) return true;
            DataSet ds = new DataSet();
            ds.Tables.Add(Sortingprev);
            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento Sortingprev da previsioneclassmovimenti");

        }

        public static bool MigraVarClassMovEntrate(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (destConn.RUN_SELECT_COUNT("sortingprevincomevar", null, false) > 0) return true;

            DataTable AllTipoClassMov = sourceConn.SQLRunner("SELECT * from tipoclassmovimenti");
            if (AllTipoClassMov.Rows.Count == 0) return true;

            MigraTipoClassMovimenti(form, sourceConn, destConn);
            MigraClassMovimenti(form, sourceConn, destConn);

            DataTable SortingprevVar = destConn.CreateTableByName("sortingprevincomevar", "*");

            foreach (DataRow CurrTipo in AllTipoClassMov.Rows) {
                //Migra la class. CurrTipo
                string codesorkind = CurrTipo["codicetipoclass"].ToString();
                int idsorkind = CfgFn.GetNoNullInt32(lookupidsorkind[codesorkind.ToUpper()]);
                QueryHelper QHS = destConn.GetQueryHelper();

                DataTable All = sourceConn.SQLRunner(
                        "SELECT ct=M.createtimestamp,cu=M.createuser,adate=M.datacontabile,description=M.descrizione,"+
                        "ayear=M.esercizio,yvar=M.esercvariazione,SOR.idsor ,amount=M.importo,lt=M.lastmodtimestamp,"+
                        "lu=M.lastmoduser,txt=M.notes,nvar=M.numvariazione,rtf=M.olenotes "+
                        " from varclassmovimentientrate M " +
                        " JOIN classmovimenti C ON C.idclass=M.idclass AND C.codicetipoclass=M.codicetipoclass" +
                        " JOIN " + getExtAccess(destConn, "sorting", false) + " SOR " +
                        "   ON SOR.sortcode=C.codiceclass " +
                        " WHERE " +
                            QHS.AppAnd(QHS.CmpEq("M.codicetipoclass", codesorkind),
                                    QHS.CmpEq("SOR.idsorkind", idsorkind)));
                foreach (DataRow ImpClass in All.Rows) {
                    DataRow R = SortingprevVar.NewRow();
                    foreach (string S in new string[] { "ct", "cu", "adate", "description", "ayear", "yvar", 
                                "idsor", "amount", "lt", "lu", "txt", "nvar", "rtf" }) {
                        R[S] = ImpClass[S];
                    }
                    SortingprevVar.Rows.Add(R);
                }

            }
            if (SortingprevVar.Rows.Count == 0) return true;
            DataSet ds = new DataSet();
            ds.Tables.Add(SortingprevVar);
            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento sortingprevincomevar da varclassmovimentientrate");

        }

        public static bool MigraVarClassMovSpese(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (destConn.RUN_SELECT_COUNT("sortingprevexpensevar", null, false) > 0) return true;

            DataTable AllTipoClassMov = sourceConn.SQLRunner("SELECT * from tipoclassmovimenti");
            if (AllTipoClassMov.Rows.Count == 0) return true;

            MigraTipoClassMovimenti(form, sourceConn, destConn);
            MigraClassMovimenti(form, sourceConn, destConn);

            DataTable SortingprevVar = destConn.CreateTableByName("sortingprevexpensevar", "*");

            foreach (DataRow CurrTipo in AllTipoClassMov.Rows) {
                //Migra la class. CurrTipo
                string codesorkind = CurrTipo["codicetipoclass"].ToString();
                int idsorkind = CfgFn.GetNoNullInt32(lookupidsorkind[codesorkind.ToUpper()]);
                QueryHelper QHS = destConn.GetQueryHelper();

                DataTable All = sourceConn.SQLRunner(
                        "SELECT ct=M.createtimestamp,cu=M.createuser,adate=M.datacontabile,description=M.descrizione," +
                        "ayear=M.esercizio,yvar=M.esercvariazione,SOR.idsor ,amount=M.importo,lt=M.lastmodtimestamp," +
                        "lu=M.lastmoduser,txt=M.notes,nvar=M.numvariazione,rtf=M.olenotes " +
                        " from varclassmovimentispese M " +
                        " JOIN classmovimenti C ON C.idclass=M.idclass AND C.codicetipoclass=M.codicetipoclass" +
                        " JOIN " + getExtAccess(destConn, "sorting", false) + " SOR " +
                        "   ON SOR.sortcode=C.codiceclass " +
                        " WHERE " +
                            QHS.AppAnd(QHS.CmpEq("M.codicetipoclass", codesorkind),
                                    QHS.CmpEq("SOR.idsorkind", idsorkind)));
                foreach (DataRow ImpClass in All.Rows) {
                    DataRow R = SortingprevVar.NewRow();
                    foreach (string S in new string[] { "ct", "cu", "adate", "description", "ayear", "yvar", 
                                "idsor", "amount", "lt", "lu", "txt", "nvar", "rtf" }) {
                        R[S] = ImpClass[S];
                    }
                    SortingprevVar.Rows.Add(R);
                }

            }
            if (SortingprevVar.Rows.Count == 0) return true;
            DataSet ds = new DataSet();
            ds.Tables.Add(SortingprevVar);
            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento sortingprevexpensevar da varclassmovimentispese");

        }

        public static bool MigraImpClassSpesa(Form form, DataAccess sourceConn, DataAccess destConn) {
            DataTable AllTipoClassMov = sourceConn.SQLRunner("SELECT * from tipoclassmovimenti");
            if (AllTipoClassMov.Rows.Count == 0) return true;

            MigraTipoClassMovimenti(form, sourceConn, destConn);
            MigraClassMovimenti(form, sourceConn, destConn);
            Upb.migraSpesa(form, sourceConn, destConn);

            DataTable ExpSorted = destConn.CreateTableByName("expensesorted", "*");

            foreach (DataRow CurrTipo in AllTipoClassMov.Rows) {
                //Migra la class. CurrTipo
                string codesorkind = CurrTipo["codicetipoclass"].ToString();
                int idsorkind = CfgFn.GetNoNullInt32(lookupidsorkind[codesorkind.ToUpper()]);
                QueryHelper QHS = destConn.GetQueryHelper();

                string qES = "SELECT COUNT(*) as numero FROM sorting " +
                " JOIN expensesorted " +
                " ON expensesorted.idsor = sorting.idsor " +
                " WHERE " + QHS.CmpEq("idsorkind", idsorkind);
                DataTable tApp = destConn.SQLRunner(qES);

                if ((tApp != null) && (tApp.Rows.Count > 0)) {
                    DataRow rApp = tApp.Rows[0];
                    if (CfgFn.GetNoNullInt32(rApp["numero"]) > 0) return true;
                }
                string sql = "SELECT ayear=S.esercmovimento, ct=M.createtimestamp,cu=M.createuser,description=M.descrizione, " +
                        "SOR.idsor,EXP.idexp ,amount=M.importo,lt=M.lastmodtimestamp,lu=M.lastmoduser, " +
                        " txt=M.notes,rtf=M.olenotes " +
                        " from impclassspesa M " +
                        " JOIN classmovimenti C ON C.idclass=M.idclass AND C.codicetipoclass=M.codicetipoclass" +
                        " JOIN " + getExtAccess(destConn, "sorting", false) + " SOR " +
                        "   ON SOR.sortcode=C.codiceclass " +
                        " JOIN SPESA S ON S.idspesa=M.idspesa " +
                        " JOIN " + getExtAccess(destConn, "expense", false) + " EXP " +
                        "    ON EXP.ymov= S.esercmovimento " +
                        "    AND EXP.nmov = S.nummovimento " +
                        "   AND  EXP.nphase = convert(int,S.codicefase) " +
                        " WHERE " +
                            QHS.AppAnd(QHS.CmpEq("M.codicetipoclass", codesorkind),
                                    QHS.CmpEq("SOR.idsorkind", idsorkind)) +
                        " ORDER BY EXP.idexp, SOR.idsor ";

                DataTable AllClassMov = sourceConn.SQLRunner(sql);
                string prevselector = "";
                int previd = 0;
                foreach (DataRow ImpClass in AllClassMov.Rows) {
                    DataRow R = ExpSorted.NewRow();
                    foreach (string S in new string[] { "ayear", "ct", "cu", "description", "idsor", "idexp", "amount", 
                        "lt", "lu", "txt", "rtf" }) {
                        R[S] = ImpClass[S];
                    }
                    string selector = ImpClass["idexp"].ToString() + "-" + ImpClass["idsor"].ToString();
                    if (selector == prevselector) {
                        previd++;
                    }
                    else {
                        previd = 1;
                    }
                    prevselector = selector;
                    R["idsubclass"] = previd;
                    R["tobecontinued"] = "N";
                    ExpSorted.Rows.Add(R);
                }

            }
            if (ExpSorted.Rows.Count == 0) return true;
            DataSet ds = new DataSet();
            ds.Tables.Add(ExpSorted);
            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento ExpenseSorted da impclassspesa");

        }

        public static bool MigraImpClassEntrata(Form form, DataAccess sourceConn, DataAccess destConn) {
            DataTable AllTipoClassMov = sourceConn.SQLRunner("SELECT * from tipoclassmovimenti");
            if (AllTipoClassMov.Rows.Count == 0) return true;

            MigraTipoClassMovimenti(form, sourceConn, destConn);
            MigraClassMovimenti(form, sourceConn, destConn);
            Upb.migraEntrata(form, sourceConn, destConn);

            DataTable IncSorted = destConn.CreateTableByName("incomesorted", "*");

            foreach (DataRow CurrTipo in AllTipoClassMov.Rows) {
                //Migra la class. CurrTipo
                string codesorkind = CurrTipo["codicetipoclass"].ToString();
                int idsorkind = CfgFn.GetNoNullInt32(lookupidsorkind[codesorkind.ToUpper()]);
                QueryHelper QHS = destConn.GetQueryHelper();

                string qIS = "SELECT COUNT(*) as numero FROM sorting " +
                                " JOIN incomesorted " +
                                " ON incomesorted.idsor = sorting.idsor " +
                                " WHERE " + QHS.CmpEq("idsorkind", idsorkind);
                DataTable tApp = destConn.SQLRunner(qIS);

                if ((tApp != null) && (tApp.Rows.Count > 0)) {
                    DataRow rApp = tApp.Rows[0];
                    if (CfgFn.GetNoNullInt32(rApp["numero"]) > 0) return true;
                }
                string sql =
                    "SELECT  ayear=E.esercmovimento, ct=M.createtimestamp,cu=M.createuser,description=M.descrizione, " +
                        "SOR.idsor,INC.idinc ,amount=M.importo,lt=M.lastmodtimestamp,lu=M.lastmoduser, " +
                        " txt=M.notes,rtf=M.olenotes " +
                        " from impclassentrata M " +
                        " JOIN classmovimenti C ON C.idclass=M.idclass AND C.codicetipoclass=M.codicetipoclass" +
                        " JOIN " + getExtAccess(destConn, "sorting", false) + " SOR " +
                        "   ON SOR.sortcode=C.codiceclass " +
                        " JOIN ENTRATA E ON E.identrata=M.identrata " +
                        " JOIN " + getExtAccess(destConn, "income", false) + " INC " +
                        "    ON INC.ymov= E.esercmovimento " +
                        "    AND INC.nmov = E.nummovimento " +
                        "   AND  INC.nphase = convert(int,E.codicefase) " +
                        " WHERE " +
                            QHS.AppAnd(QHS.CmpEq("M.codicetipoclass", codesorkind),
                                    QHS.CmpEq("SOR.idsorkind", idsorkind)) +
                        " ORDER BY INC.idinc, SOR.idsor ";
                DataTable AllClassMov = sourceConn.SQLRunner(sql);
                string prevselector = "";
                int previd = 0;
                foreach (DataRow ImpClass in AllClassMov.Rows) {
                    DataRow R = IncSorted.NewRow();
                    foreach (string S in new string[] { "ayear", "ct", "cu", "description", "idsor", "idinc", "amount", 
                        "lt", "lu", "txt", "rtf" }) {
                        R[S] = ImpClass[S];
                    }
                    string selector = ImpClass["idinc"].ToString() + "-" + ImpClass["idsor"].ToString();
                    if (selector == prevselector) {
                        previd++;
                    }
                    else {
                        previd = 1;
                    }
                    prevselector = selector;
                    R["idsubclass"] = previd;
                    R["tobecontinued"] = "N";
                    IncSorted.Rows.Add(R);
                }

            }
            if (IncSorted.Rows.Count == 0) return true;
            DataSet ds = new DataSet();
            ds.Tables.Add(IncSorted);
            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento IncomeSorted da impclassentrata");

        }

        public static bool MigraClassTreeBilancio(Form form, DataAccess sourceConn, DataAccess destConn) {
            DataTable AllTipoClassTab = sourceConn.SQLRunner("SELECT * from tipoclasstabelle where nometabella='bilancio'");
            if (AllTipoClassTab.Rows.Count == 0) return true;

            MigraTipoClassTabelle(form, sourceConn, destConn);
            MigraClassTabelle(form, sourceConn, destConn);
            Upb.migraBilancio(form, sourceConn, destConn);

            DataTable FinSorted = destConn.CreateTableByName("finsorting", "*");

            foreach (DataRow CurrTipo in AllTipoClassTab.Rows) {
                //Migra la class. CurrTipo
                string codesorkind = CurrTipo["codicetipoclass"].ToString();
                int idsorkind = CfgFn.GetNoNullInt32(lookupidsorkind[codesorkind.ToUpper()]);
                QueryHelper QHS = destConn.GetQueryHelper();

                if (destConn.RUN_SELECT_COUNT("finsorting", QHS.CmpEq("idsorkind", idsorkind), false) > 0) continue;

                DataTable AllClassBil = sourceConn.SQLRunner(
                        "SELECT ct=M.createtimestamp,cu=M.createuser, " +
                        "SOR.idsor,FIN.idfin ,lt=M.lastmodtimestamp,lu=M.lastmoduser " +
                        " from classtreebilancio M " +
                        " JOIN classtabelle C ON C.idclass=M.idclass AND C.codicetipoclass=M.codicetipoclass " +
                        " JOIN " + getExtAccess(destConn, "sorting", false) + " SOR " +
                        "   ON SOR.sortcode=C.codiceclass " +
                        " JOIN BILANCIO B ON B.idbilancio=M.idbilancio " +
                            " JOIN " + getExtAccess(destConn, "fin", false) + " FIN ON " +
                             " FIN.codefin=B.codicebilancio AND " +
                             " FIN.ayear = B.esercizio " + 
                        "   AND  INC.nphase = convert(int,S.codicefase) " +                
                        " WHERE " +
                            QHS.AppAnd(QHS.CmpEq("M.codicetipoclass", codesorkind),QHS.CmpEq("SOR.idsorkind", idsorkind)) +
                        " AND  ( ((FIN.flag & 1)==0 AND B.partebilancio='E') OR ((FIN.flag & 1)<>0 AND B.partebilancio='S') ) "
                        );

                foreach (DataRow ImpClass in AllClassBil.Rows) {
                    DataRow R = FinSorted.NewRow();
                    foreach (string S in new string[] { "ct", "cu",  "idsor", "idfin", "lt", "lu"}) {
                        R[S] = ImpClass[S];
                    }
                    R["quota"] = 1;
                    FinSorted.Rows.Add(R);
                }

            }
            if (FinSorted.Rows.Count == 0) return true;
            DataSet ds = new DataSet();
            ds.Tables.Add(FinSorted);
            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento FinSorting da classtreebilancio");

        }

        public static bool MigraClassTreeClassInventario(Form form, DataAccess sourceConn, DataAccess destConn) {
            DataTable AllTipoClassTab = sourceConn.SQLRunner("SELECT * from tipoclasstabelle where nometabella='classinventario'");
            if (AllTipoClassTab.Rows.Count == 0) return true;

            MigraTipoClassTabelle(form, sourceConn, destConn);
            MigraClassTabelle(form, sourceConn, destConn);
            Patrimonio.EsportaClassInventario(form, sourceConn, destConn);

            DataTable InvTreeSorted = destConn.CreateTableByName("inventorytreesorting", "*");

            foreach (DataRow CurrTipo in AllTipoClassTab.Rows) {
                //Migra la class. CurrTipo
                string codesorkind = CurrTipo["codicetipoclass"].ToString();
                int idsorkind = CfgFn.GetNoNullInt32(lookupidsorkind[codesorkind.ToUpper()]);
                QueryHelper QHS = destConn.GetQueryHelper();

                if (destConn.RUN_SELECT_COUNT("inventorytreesorting", QHS.CmpEq("idsorkind", idsorkind), false) > 0) continue;

                DataTable AllClassInv = sourceConn.SQLRunner(
                        "SELECT ct=M.createtimestamp,cu=M.createuser, " +
                        "SOR.idsor,INV.idinv ,lt=M.lastmodtimestamp,lu=M.lastmoduser " +
                        " from classtreeclassinventario M " +
                        " JOIN classtabelle C ON C.idclass=M.idclass AND C.codicetipoclass=M.codicetipoclass " +
                        " JOIN " + getExtAccess(destConn, "sorting", false) + " SOR " +
                        "   ON SOR.sortcode=C.codiceclass " +
                        " JOIN classinventario CL ON CL.idclass=M.idclass " +
                            " JOIN " + getExtAccess(destConn, "inventorytree", true) + " INV ON " +
                             " INV.codeinv=CL.codiceclass AND " +
                        " WHERE " +
                            QHS.AppAnd(QHS.CmpEq("M.codicetipoclass", codesorkind), QHS.CmpEq("SOR.idsorkind", idsorkind)) 
                        );

                foreach (DataRow ImpClass in AllClassInv.Rows) {
                    DataRow R = InvTreeSorted.NewRow();
                    foreach (string S in new string[] { "ct", "cu", "idsor", "idinv", "lt", "lu" }) {
                        R[S] = ImpClass[S];
                    }
                    InvTreeSorted.Rows.Add(R);
                }

            }
            if (InvTreeSorted.Rows.Count == 0) return true;
            DataSet ds = new DataSet();
            ds.Tables.Add(InvTreeSorted);
            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento InvTreeSorted da classtreeclassinventario");

        }

        public static bool MigraClassTreeResponsabile(Form form, DataAccess sourceConn, DataAccess destConn) {
            DataTable AllTipoClassTab = sourceConn.SQLRunner("SELECT * from tipoclasstabelle where nometabella='responsabile'");
            if (AllTipoClassTab.Rows.Count == 0) return true;

            MigraTipoClassTabelle(form, sourceConn, destConn);
            MigraClassTabelle(form, sourceConn, destConn);
            Patrimonio.EsportaResponsabile(form, sourceConn, destConn);

            DataTable TabSorted = destConn.CreateTableByName("managersorting", "*");

            foreach (DataRow CurrTipo in AllTipoClassTab.Rows) {
                //Migra la class. CurrTipo
                string codesorkind = CurrTipo["codicetipoclass"].ToString();
                int idsorkind = CfgFn.GetNoNullInt32(lookupidsorkind[codesorkind.ToUpper()]);
                QueryHelper QHS = destConn.GetQueryHelper();

                if (destConn.RUN_SELECT_COUNT("managersorting", QHS.CmpEq("idsorkind", idsorkind), false) > 0) continue;

                DataTable AllClass = sourceConn.SQLRunner(
                        "SELECT ct=M.createtimestamp,cu=M.createuser, " +
                        "SOR.idsor, M.codiceresponsabile, lt=M.lastmodtimestamp,lu=M.lastmoduser " +
                        " from classtreeresponsabile M " +
                        " JOIN classtabelle C ON C.idclass=M.idclass AND C.codicetipoclass=M.codicetipoclass " +
                        " JOIN " + getExtAccess(destConn, "sorting", false) + " SOR " +
                        "   ON SOR.sortcode=C.codiceclass " +
                        " WHERE " +
                            QHS.AppAnd(QHS.CmpEq("M.codicetipoclass", codesorkind), QHS.CmpEq("SOR.idsorkind", idsorkind))
                        );

                foreach (DataRow ImpClass in AllClass.Rows) {
                    DataRow R = TabSorted.NewRow();
                    foreach (string S in new string[] { "ct", "cu", "idsor", "lt", "lu" }) {
                        R[S] = ImpClass[S];
                    }
                    R["idman"] = Patrimonio.lookupidman[ImpClass["codiceresponsabile"].ToString().ToUpper()];
                    R["quota"] = 1;
                    TabSorted.Rows.Add(R);
                }

            }
            if (TabSorted.Rows.Count == 0) return true;
            DataSet ds = new DataSet();
            ds.Tables.Add(TabSorted);
            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento managersorting da classtreeresponsabile");

        }


        public static bool MigraClassTreeSezione(Form form, DataAccess sourceConn, DataAccess destConn) {
            DataTable AllTipoClassTab = sourceConn.SQLRunner("SELECT * from tipoclasstabelle where nometabella='sezione'");
            if (AllTipoClassTab.Rows.Count == 0) return true;

            MigraTipoClassTabelle(form, sourceConn, destConn);
            MigraClassTabelle(form, sourceConn, destConn);
            Patrimonio.EsportaSezione(form, sourceConn, destConn);

            DataTable TabSorted = destConn.CreateTableByName("divisionsorting", "*");

            foreach (DataRow CurrTipo in AllTipoClassTab.Rows) {
                //Migra la class. CurrTipo
                string codesorkind = CurrTipo["codicetipoclass"].ToString();
                int idsorkind = CfgFn.GetNoNullInt32(lookupidsorkind[codesorkind.ToUpper()]);
                QueryHelper QHS = destConn.GetQueryHelper();

                if (destConn.RUN_SELECT_COUNT("divisionsorting", QHS.CmpEq("idsorkind", idsorkind), false) > 0) continue;

                DataTable AllClass = sourceConn.SQLRunner(
                        "SELECT ct=M.createtimestamp,cu=M.createuser, " +
                        "SOR.idsor, M.codicesezione, lt=M.lastmodtimestamp,lu=M.lastmoduser " +
                        " from classtreesezione M " +
                        " JOIN classtabelle C ON C.idclass=M.idclass AND C.codicetipoclass=M.codicetipoclass " +
                        " JOIN " + getExtAccess(destConn, "sorting", false) + " SOR " +
                        "   ON SOR.sortcode=C.codiceclass " +
                        " WHERE " +
                            QHS.AppAnd(QHS.CmpEq("M.codicetipoclass", codesorkind), QHS.CmpEq("SOR.idsorkind", idsorkind))
                        );

                foreach (DataRow ImpClass in AllClass.Rows) {
                    DataRow R = TabSorted.NewRow();
                    foreach (string S in new string[] { "ct", "cu", "idsor", "lt", "lu" }) {
                        R[S] = ImpClass[S];
                    }
                    R["iddivision"] = Patrimonio.lookupiddivision[ImpClass["codicesezione"].ToString().ToUpper()];
                    R["quota"] = 1;
                    TabSorted.Rows.Add(R);
                }

            }
            if (TabSorted.Rows.Count == 0) return true;
            DataSet ds = new DataSet();
            ds.Tables.Add(TabSorted);
            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento classtreesezione da classtreesezione");

        }

        public static bool MigraClassTreeUbicazione(Form form, DataAccess sourceConn, DataAccess destConn) {
            DataTable AllTipoClassTab = sourceConn.SQLRunner("SELECT * from tipoclasstabelle where nometabella='ubicazione'");
            if (AllTipoClassTab.Rows.Count == 0) return true;

            MigraTipoClassTabelle(form, sourceConn, destConn);
            MigraClassTabelle(form, sourceConn, destConn);
            Patrimonio.EsportaUbicazione(form, sourceConn, destConn);

            DataTable TabSorted = destConn.CreateTableByName("locationsorting", "*");

            foreach (DataRow CurrTipo in AllTipoClassTab.Rows) {
                //Migra la class. CurrTipo
                string codesorkind = CurrTipo["codicetipoclass"].ToString();
                int idsorkind = CfgFn.GetNoNullInt32(lookupidsorkind[codesorkind.ToUpper()]);
                QueryHelper QHS = destConn.GetQueryHelper();

                if (destConn.RUN_SELECT_COUNT("locationsorting", QHS.CmpEq("idsorkind", idsorkind), false) > 0) continue;

                DataTable AllClass = sourceConn.SQLRunner(
                        "SELECT ct=M.createtimestamp,cu=M.createuser, " +
                        "SOR.idsor, LOC.idlocation, lt=M.lastmodtimestamp,lu=M.lastmoduser " +
                        " from classtreeubicazione M " +
                        " JOIN classtabelle C ON C.idclass=M.idclass AND C.codicetipoclass=M.codicetipoclass " +
                        " JOIN " + getExtAccess(destConn, "sorting", false) + " SOR " +
                        "   ON SOR.sortcode=C.codiceclass " +
                        " JOIN ubicazione UB ON UB.idubicazione= M.idubicazione "+
                        " JOIN "+getExtAccess(destConn,"location",false)+" LOC "+
                        "   ON LOC.locationcode = UB.codiceubicazione "+
                        " WHERE " +
                            QHS.AppAnd(QHS.CmpEq("M.codicetipoclass", codesorkind), QHS.CmpEq("SOR.idsorkind", idsorkind))
                        );

                foreach (DataRow ImpClass in AllClass.Rows) {
                    DataRow R = TabSorted.NewRow();
                    foreach (string S in new string[] { "ct", "cu", "idsor","idlocation", "lt", "lu" }) {
                        R[S] = ImpClass[S];
                    }
                    TabSorted.Rows.Add(R);
                }

            }
            if (TabSorted.Rows.Count == 0) return true;
            DataSet ds = new DataSet();
            ds.Tables.Add(TabSorted);
            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento locationsorting da classtreeubicazione");

        }


        public static bool MigraClassTreeCredDeb(Form form, DataAccess sourceConn, DataAccess destConn) {
            DataTable AllTipoClassTab = sourceConn.SQLRunner("SELECT * from tipoclasstabelle where nometabella='creditoredebitore'");
            if (AllTipoClassTab.Rows.Count == 0) return true;

            MigraTipoClassTabelle(form, sourceConn, destConn);
            MigraClassTabelle(form, sourceConn, destConn);
            Anagrafica.migraCreditoreDebitore(form, sourceConn, destConn);

            DataTable TabSorted = destConn.CreateTableByName("registrysorting", "*");

            foreach (DataRow CurrTipo in AllTipoClassTab.Rows) {
                //Migra la class. CurrTipo
                string codesorkind = CurrTipo["codicetipoclass"].ToString();
                int idsorkind = CfgFn.GetNoNullInt32(lookupidsorkind[codesorkind.ToUpper()]);
                QueryHelper QHS = destConn.GetQueryHelper();

                if (destConn.RUN_SELECT_COUNT("registrysorting", QHS.CmpEq("idsorkind", idsorkind), false) > 0) continue;

                string sql = "SELECT ct=M.createtimestamp,cu=M.createuser, " +
                        "SOR.idsor, REG.idreg, lt=M.lastmodtimestamp,lu=M.lastmoduser " +
                        " from classtreecreddebi M " +
                        " JOIN classtabelle C ON C.idclass=M.idclass AND C.codicetipoclass=M.codicetipoclass " +
                        " JOIN " + getExtAccess(destConn, "sorting", false) + " SOR " +
                        "   ON SOR.sortcode=C.codiceclass " +
                        " JOIN creditoredebitore CR ON CR.codicecreddeb= M.codicecreddeb " +
                        " JOIN " + getExtAccess(destConn, "registry", true) + " REG " +
                        "   ON REG.title= CR.denominazione " +
                        " WHERE " +
                            QHS.AppAnd(QHS.CmpEq("M.codicetipoclass", codesorkind), QHS.CmpEq("SOR.idsorkind", idsorkind));
                DataTable AllClass = sourceConn.SQLRunner(sql);

                foreach (DataRow ImpClass in AllClass.Rows) {
                    DataRow R = TabSorted.NewRow();
                    foreach (string S in new string[] { "ct", "cu", "idsor", "idreg", "lt", "lu" }) {
                        R[S] = ImpClass[S];
                    }
                    TabSorted.Rows.Add(R);
                }

            }
            if (TabSorted.Rows.Count == 0) return true;
            DataSet ds = new DataSet();
            ds.Tables.Add(TabSorted);
            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento registrysorting da classtreecreddebi");

        }

		public static bool migraClassificazioni(Form form, DataAccess sourceConn, DataAccess destConn) 
		{
			if (! migraClassBilancio(form, sourceConn, destConn)) return false;
            if (!MigraTipoClassMovimenti(form, sourceConn, destConn)) return false;
            if (!MigraTipoClassTabelle(form, sourceConn, destConn)) return false;

            if (!MigraLivelloClassMovimenti(form, sourceConn, destConn)) return false;
            if (!MigraLivelloClassTabelle(form, sourceConn, destConn)) return false;

            if (!MigraPrevisioneClassMovimenti(form, sourceConn, destConn)) return false;
            if (!MigraVarClassMovEntrate(form, sourceConn, destConn)) return false;
            if (!MigraVarClassMovSpese(form, sourceConn, destConn)) return false;

            if (!MigraClassMovimenti(form, sourceConn, destConn)) return false;
            if (!MigraClassTabelle(form, sourceConn, destConn)) return false;

            if (!MigraImpClassSpesa(form, sourceConn, destConn)) return false;
            if (!MigraImpClassEntrata(form, sourceConn, destConn)) return false;

            if (!MigraClassTreeBilancio(form, sourceConn, destConn)) return false;
            if (!MigraClassTreeClassInventario(form, sourceConn, destConn)) return false;
            if (!MigraClassTreeResponsabile(form, sourceConn, destConn)) return false;
            if (!MigraClassTreeSezione(form, sourceConn, destConn)) return false;
            if (!MigraClassTreeUbicazione(form, sourceConn, destConn)) return false;
            if (!MigraClassTreeCredDeb(form, sourceConn, destConn)) return false;


			return true;
		}
	}
}
