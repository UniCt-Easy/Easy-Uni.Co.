
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
using System.Text;
using metadatalibrary;
using System.Data;
using System.IO;
using System.Windows.Forms;
using funzioni_configurazione;
using System.Collections;

namespace no_table_unifydip {
    public class Copyer {
        public bool applied;
        DataTable T;
        protected string filter = null;
        protected bool skipduplicates = false;
        public string table;
        Dictionary<string, translator> PRETrlist = new Dictionary<string, translator>();
        Dictionary<string, translator> POSTTrlist = new Dictionary<string, translator>();
        Dictionary<string, string> lookup = new Dictionary<string, string>();
        List<string> L = new List<string>();
        List<string> SkipFieldsWhenNull = new List<string>();
        List<string> AllowNoTransl = new List<string>();
        CopyContext myContext = new CopyContext();
        bool skipIfNotEmpty = false;
        protected bool ClearDestAtStart = false;
        public Copyer AddPrivateTranslator(string code, translator TR) {
            myContext.Add(code, TR);
            applied = false;
            return this;
        }

        private bool dontCopy = false;


        public Copyer SkipIfNotEmpty() {
            this.skipIfNotEmpty = true;
            return this;
        }
        public Copyer SetFilter(string sqlfilter) {
            this.filter = sqlfilter;
            return this;
        }

        public Copyer DontCopy() {
            dontCopy = true;
            return this;
        }

        public Copyer SkipDuplicates() {
            skipduplicates = true;
            return this;
        }
        public Copyer SkipOnNull(string field) {
            SkipFieldsWhenNull.Add(field);
            return this;
        }
        public Copyer AllowNoTranslation(string field) {
            AllowNoTransl.Add(field);
            return this;
        }

        
        public Copyer ShouldClearDestDB(bool shouldclear) {
            this.ClearDestAtStart = shouldclear;
            return this;
        }
        /// <summary>
        /// Verifica il precheck di tutti i translator creati da questo copyer
        /// </summary>
        /// <param name="Source"></param>
        /// <param name="Dest"></param>
        /// <returns></returns>
        public virtual bool CheckPreconditions(DataAccess Source, DataAccess Dest) {
            foreach (translator T in PRETrlist.Values) {
                if (!T.Precheck(Source, Dest, table)) return false;
            }
            return true;
        }

        /// <summary>
        /// Checks whether external fields have already been defined
        /// </summary>
        /// <param name="Ctx"></param>
        /// <param name="L"></param>
        /// <returns></returns>
        public bool CheckDependencies(CopyContext Ctx, List<string> L) {
            foreach (DataColumn C in T.Columns) {
                string codetosearch = GetExternalCodeForField(C.ColumnName);
                if (!L.Contains(codetosearch)) continue;  //non è nella mandatory list, tutto ok
                if (PRETrlist.ContainsKey(codetosearch)) continue; //è un campo gestito da questo copyer stesso
                //è nella mandatorylist, vede se il Contesto per quel campo è stato definito
                if (Ctx.IsDefined(codetosearch)) continue;
                return false; //field has not yet been defined
            }
            return true;
        }

        /// <summary>
        /// gets external name for field
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        private string GetExternalCodeForField(string field) {
            if (!lookup.ContainsKey(field)) return field;
            return lookup[field];
        }

        /// <summary>
        /// Assumes source field  externally named dest
        /// </summary>
        /// <param name="source"></param>
        /// <param name="dest"></param>
        /// <returns></returns>
        public Copyer SetExternalCode(string source, string dest) {
            lookup[source] = dest;
            return this;
        }

        public Copyer(string table, DataAccess Model) {
            this.table = table;
            T = Model.CreateTableByName(table, "*");
        }

        /// <summary>
        /// restituisce l'elenco dei codici definiti da questo copyer
        /// </summary>
        /// <returns></returns>
        public List<string> CodeDefined() {
            return L;
        }
        protected virtual bool IsToCopy(DataRow R) {
            return true;
        }


        protected virtual bool SkipExtNulls(DataRow R,CopyContext Ctx) {
            

            foreach (string field in SkipFieldsWhenNull) {
                if (R[field] == DBNull.Value) continue;

                object o=null;
                if (myContext.IsDefined(field)) {
                    //I traduttori privati prevalgono su quelli pubblici e non risentono del codice esterno
                    o = myContext.Translate(field, R[field]);
                }
                else {
                    o = Ctx.Translate(GetExternalCodeForField(field), R[field]);
                }
                if (o == null || o == DBNull.Value) return true;
            }
            return false;
        }

        protected virtual void Translate(CopyContext Ctx, DataRow R) {
            DataTable T = R.Table;
            foreach (DataColumn C in T.Columns) {
                try {
                    object O;
                    if (myContext.IsDefined(C.ColumnName)) {
                        //I traduttori privati prevalgono su quelli pubblici e non risentono del codice esterno
                        O = myContext.Translate(C.ColumnName, R[C.ColumnName]);
                    }
                    else {
                       O = Ctx.Translate(GetExternalCodeForField(C.ColumnName), R[C.ColumnName]);
                    }

                    if (O == null && AllowNoTransl.Contains(C.ColumnName)) O = DBNull.Value;

                    R[C.ColumnName] = O;

                }
                catch (Exception E) {
                    MessageBox.Show("La colonna " + C.ColumnName + " della tabella " + table + " contiene il valore " +
                                    R[C.ColumnName].ToString() + " che non è stato possibile tradurre ");
                    throw E;
                }
            }
        }

        /// <summary>
        /// Merge the translators created by this Copyer to an external list
        /// </summary>
        /// <returns></returns>
        public virtual void MergePreTranslatorsTo(CopyContext Ctx) {
            if (PRETrlist.Count == 0) return;
            foreach (string code in PRETrlist.Keys) {
                Ctx.Add(code,PRETrlist[code]);
            }
        }

        /// <summary>
        /// Chiamato in sede di costruzione della classe per stabilire quali translators siano attivati da questo oggetto
        /// </summary>
        /// <param name="code"></param>
        /// <param name="T"></param>
        /// <returns></returns>
        public Copyer DefinesPreTranslator(string code, translator T) {
            if (L.Contains(code)) {
                MessageBox.Show("Errore: doppia definizione del translator di codice " + code, "Errore di progettazione");
            }
            L.Add(code);
            PRETrlist[code] = T;
            return this;
        }

        /// <summary>
        /// Merge the translators created by this Copyer to an external list
        /// </summary>
        /// <returns></returns>
        public virtual void MergePostTranslatorsTo(CopyContext Ctx) {
            if (POSTTrlist.Count == 0) return;
            foreach (string code in POSTTrlist.Keys) {
                Ctx.Add(code, POSTTrlist[code]);
            }
        }

        /// <summary>
        /// Chiamato in sede di costruzione della classe per stabilire quali translators siano attivati da questo oggetto
        /// </summary>
        /// <param name="code"></param>
        /// <param name="T"></param>
        /// <returns></returns>
        public Copyer DefinesPostTranslator(string code, translator T) {
            L.Add(code);
            POSTTrlist[code] = T;
            return this;
        }

        protected string GetSQLDataValues(DataRow row, DataTable Cols) {
            string s = "";
            int colcount = Cols.Rows.Count;
            for (int i = 0; i < colcount; i++) {
                string valore = "";
                string colname = Cols.Rows[i]["COLUMN_NAME"].ToString();
                if (row.Table.Columns.Contains(colname))
                    valore = QueryCreator.quotedstrvalue(row[colname], true);
                else
                    valore = "NULL";
                s += valore + ",";
            }
            s = s.Remove(s.Length - 1, 1);
            return s + ")\r\n";
        }

        protected void Comment(DataAccess Dest, CopyContext Ctx, CopyDisplay CD) {
            DataTable T = Dest.CreateTableByName(table, "*");

            //Verifica quanti codici sono definiti e crea una stringa
            string comment = "";
            foreach (DataColumn C in T.Columns) {
                string extcode = GetExternalCodeForField(C.ColumnName);
                //esamina i campi  a  codifica esterna
                if (extcode != C.ColumnName) 
                    comment += "[" + C.ColumnName + " -> " + extcode + "] ";

                if (myContext.IsDefined(extcode)) {
                    if (extcode == C.ColumnName)  comment += "[" + extcode + " priv]";                    
                }
                else {
                    if (Ctx.IsDefined(extcode)) {
                        if (extcode == C.ColumnName)  comment += "[" + extcode + " ext]";
                    }
                    else {
                        if (extcode != C.ColumnName) {
                            comment += "\r\n\r\n>>>>>>>> E R R O R : " + extcode + " is not a defined translator <<<<<<<<<\r\n\r\n";
                        }
                    }
                }
                
            }
            foreach (string field in SkipFieldsWhenNull) {
                comment += "[Skips on " + field + " null] ";
            }
            if (comment != "") {
                comment = "Table " + table.ToUpper() + ":" + comment;
                CD.Comment(comment);
            }
        }


        public virtual bool CopyTable(DataAccess Source, DataAccess Dest, CopyContext Ctx, CopyDisplay CD) {
            int count = 0;
           
            QueryHelper QHS = Dest.GetQueryHelper();
            try {
                DataTable Cols = Dest.SQLRunner("sp_columns " + table + ",'" + Dest.GetSys("userdb").ToString() + "'");
                if (Cols.Rows.Count == 0)
                    Cols = Dest.SQLRunner("sp_columns " + table + ",'dbo'");

                if (ClearDestAtStart) {
                    Dest.SQLRunner("DELETE FROM " + table);
                }

                if (dontCopy) {
                    CD.Comment("Table " + table + " skipped");
                    applied = true;
                    return true;
                }
            
                if (skipIfNotEmpty) {
                    if (Dest.RUN_SELECT_COUNT(table, null, false) > 0) {
                        CD.Comment("Table " + table + " skipped cause destination is not empty");
                        applied = true;
                        return true;
                    }
                }

                Comment(Dest, Ctx, CD);
                int not_to_copy = 0;
                int nullskipped = 0;

                int nrows = Source.RUN_SELECT_COUNT(table, filter, false);
                CD.Start(filter==null? table: table+ " where "+filter, "copy", nrows);

                string insert = "INSERT INTO " + table + " VALUES(";//(
                string s = "";
                string err;
                DataTable T = Dest.CreateTableByName(table, "*");
                string col = QueryCreator.ColumnNameList(T);


                DataAccess.DataRowReader DRR = new DataAccess.DataRowReader(Source, table, col, null, filter);
                foreach (DataRow row in DRR) {
                    CD.Update(1);
                    if (!IsToCopy(row)) { not_to_copy++; continue; }
                    if (SkipExtNulls(row, Ctx)) { nullskipped++; continue; }

                    Translate(Ctx, row);

                    if (skipduplicates) {
                        int num = Dest.RUN_SELECT_COUNT(table, QHS.CmpKey(row), false);
                        if (num > 0) continue;
                    }
                    

                    count++;
                    string values = GetSQLDataValues(row, Cols);
                    s += insert + values;
                    if (count == 10) {
                        Dest.SQLRunner(s, 0, out err);
                        
                        if (err != null) {
                            QueryCreator.ShowError(null, "Errore", err);
                            StreamWriter fsw = new StreamWriter("temp.sql", false, Encoding.Default);
                            fsw.Write(s.ToString());
                            fsw.Close();
                            MessageBox.Show("Errore durante la copia della tabella " + table + "\r\nLo script lanciato si trova nel file 'temp.sql'");
                            CD.Stop(false);
                            return false;
                        }
                        s = "";
                        count = 0;
                    }
                }
                if (s != "") {
                    Dest.SQLRunner(s, 0, out err);
                    count = 0;
                    if (err != null) {
                        QueryCreator.ShowError(null, "Errore", err);
                        StreamWriter fsw = new StreamWriter("temp.sql", false, Encoding.Default);
                        fsw.Write(s.ToString());
                        fsw.Close();
                        MessageBox.Show("Errore durante la copia di " + table + "\r\nLo script lanciato si trova nel file 'temp.sql'");
                        CD.Stop(false);
                        return false;
                    }

                    s = "";
                }
                CD.Stop(true);
                if (not_to_copy > 0 || nullskipped > 0) {
                    CD.Comment(">>Not to copy:" + not_to_copy.ToString() + "  NullSkipped:" + nullskipped.ToString());
                }
                applied = true;
                return true;
            }
            catch (Exception E) {
                QueryCreator.ShowException(E);
                CD.Stop(false);
                return false;
            }

        }
    }


    /// <summary>
    /// Copyes a table appending rows setting key values = max(key)+1 foreach not existing rows
    ///  object are merged on code field bases
    /// </summary>
    public class MergeWithIntKey : Copyer {
        string code;
        string key;
        translator MyTR = null;
        Hashtable ToAdd = new Hashtable();
        string traslcode = null;

        public MergeWithIntKey(string table, DataAccess Model, string key, string code)
            : base(table, Model) {
            this.code=code;
            this.key=key;
            this.traslcode = key;
        }

        public override bool CheckPreconditions(DataAccess Source, DataAccess Dest) {
            if (!base.CheckPreconditions(Source, Dest)) return false;
            return CheckPreconditions(Source, Dest, false);
        }

        protected  bool CheckPreconditions(DataAccess Source, DataAccess Dest, bool forced) {
            if (ClearDestAtStart) {
                MyTR = new IdentityTranslator();
                AddPrivateTranslator(key, MyTR);  //key is translated as MyTR - no matter of external requests
                DefinesPreTranslator(traslcode, MyTR);  //defines external translator as requested
                return true;

            }

            DataTable S = Source.RUN_SELECT(table, "*", null, filter, null, false);
            DataTable D = Dest.RUN_SELECT(table, "*", null, null, null, false);
            int nmax = CfgFn.GetNoNullInt32(Dest.DO_READ_VALUE(table, null, "max(" + key + ")")) + 1;
            Hashtable H = new Hashtable();
            CQueryHelper QHC = new CQueryHelper();
            foreach (DataRow Rs in S.Rows) {              
                DataRow[] found = D.Select(QHC.CmpEq(code, Rs[code]));
                if (found.Length == 0) {
                    H[Rs[key]] = nmax++;
                    ToAdd[Rs[key]] = 1;
                    continue;
                }
                if (forced) {
                    MessageBox.Show("La tabella di destinazione " + table + " ha già una o più righe con " + code + " = " + Rs[code].ToString(), "Errore");
                    return false;

                }
                if (found.Length == 1) {
                    H[Rs[key]] = found[0][key];
                    continue;
                }
                MessageBox.Show("La tabella di destinazione " + table + " ha più righe con il campo " + code + " = " + Rs[code].ToString(), "Errore");
                return false;

            }
            MyTR = new ManualTranslator(H);
            AddPrivateTranslator(key, MyTR);  //key is translated as MyTR - no matter of external requests
            DefinesPreTranslator(traslcode, MyTR);  //defines external translator as requested
            return true;
        }


        protected override bool IsToCopy(DataRow R) {
            if (ClearDestAtStart) return true;
 
            object keyval = R[key];
            return ToAdd.ContainsKey(keyval); 
        }
       

 

        public MergeWithIntKey CreateTranslatorAs(string traslcode) {
            this.traslcode = traslcode;
            return this;
        }

        
       
    }

    public class ForcedAppendWithIntKey : MergeWithIntKey {
        public ForcedAppendWithIntKey(string table, DataAccess Model, string key, string code)
            : base(table, Model, key,code) {
        }


        public override bool CheckPreconditions(DataAccess Source, DataAccess Dest) {
            return CheckPreconditions(Source, Dest, true);

        }
    }

    /// <summary>
    /// Merges  tables basing on string key equality
    /// </summary>
    public class MergeWithStringKey : Copyer {
        string key;
        string traslcode = null;
        Hashtable ToAdd = new Hashtable();

        public MergeWithStringKey(string table, DataAccess Model, string key)
            : base(table, Model) {
            this.key=key;
            this.traslcode = key;
        }

        public MergeWithStringKey CreateTranslatorAs(string traslcode) {
            this.traslcode = traslcode;
            return this;
        }

        

        public override bool CheckPreconditions(DataAccess Source, DataAccess Dest) {
            if (!base.CheckPreconditions(Source, Dest)) return false;
            return CheckPreconditions(Source, Dest, false);
        }


        protected bool CheckPreconditions(DataAccess Source, DataAccess Dest, bool forced) {
            DataTable S = Source.RUN_SELECT(table, "*", null,filter, null, false);
            DataTable D = Dest.RUN_SELECT(table, "*", null, null, null, false);
            CQueryHelper QHC = new CQueryHelper();
            foreach (DataRow Rs in S.Rows) {
                DataRow[] found = D.Select(QHC.CmpEq(key, Rs[key]));
                if (found.Length == 0) {
                    ToAdd[Rs[key]] = 1;
                    continue;
                }
                if (forced) {
                    MessageBox.Show("La tabella di destinazione " + table + " ha già una o più righe con " + key + " = " + Rs[key].ToString(), "Errore");
                    return false;

                }
                if (found.Length == 1) {
                    continue;
                }
                MessageBox.Show("La tabella di destinazione " + table + " ha più righe con il campo " + key + " = " + Rs[key].ToString(), "Errore");
                return false;

            }
            AddPrivateTranslator(key, new IdentityTranslator());
            DefinesPreTranslator(traslcode, new IdentityTranslator());

            return true;
        }


        protected override bool IsToCopy(DataRow R) {
            object keyval = R[key];
            return ToAdd.ContainsKey(keyval);
        }

      

      
    }

    public class ForcedAppendWithStringKey : MergeWithStringKey {
        public ForcedAppendWithStringKey(string table, DataAccess Model, string key, string code)
            : base(table, Model, key) {
        }


        public override bool CheckPreconditions(DataAccess Source, DataAccess Dest) {
            if (!base.CheckPreconditions(Source, Dest)) return false;
            return CheckPreconditions(Source, Dest, true);

        }
    }

    /// <summary>
    /// merges tables basing on code key, appending a suffix to it
    /// </summary>
    public class AppendStringToCodeField : Copyer {
        string code;
        string key;
        translator MyTR = null;
        Hashtable ToAdd = new Hashtable();
        string traslcode = null;
        string stringtoappend = null;
        int maxlen;
        public AppendStringToCodeField(string table, DataAccess Model, string key, string codefield, string stringtoappend,int maxlen)
            : base(table, Model) {
            this.code=codefield;
            this.key=key;
            this.traslcode = key;
            this.stringtoappend = stringtoappend;
            this.maxlen = maxlen;
        }

        public override bool CheckPreconditions(DataAccess Source, DataAccess Dest) {
            if (!base.CheckPreconditions(Source, Dest)) return false;
            return CheckPreconditionsForced(Source, Dest);
        }

        protected bool CheckPreconditionsForced(DataAccess Source, DataAccess Dest) {
            DataTable S = Source.RUN_SELECT(table, "*", null,filter, null, false);
            DataTable D = Dest.RUN_SELECT(table, "*", null, null, null, false);
            int nmax = CfgFn.GetNoNullInt32(Dest.DO_READ_VALUE(table, null, "max(" + key + ")")) + 1;
            StringAppender myAppender = new StringAppender(stringtoappend, maxlen);

            Hashtable H = new Hashtable();
            CQueryHelper QHC = new CQueryHelper();
            foreach (DataRow Rs in S.Rows) {
                object newval = myAppender.translate(Rs[code].ToString());                
                DataRow[] found = D.Select( QHC.CmpEq(code, newval));
                if (found.Length == 0) {
                    H[Rs[key]] = nmax++;
                    ToAdd[Rs[key]] = 1;
                    continue;
                }
                MessageBox.Show("La tabella di destinazione " + table + " ha già una o più righe con " +
                                    code + " = " + newval.ToString(), "Errore");
                return false;

            }
            MyTR = new ManualTranslator(H);
            AddPrivateTranslator(code, myAppender);
            DefinesPreTranslator(traslcode, MyTR);
            return true;
        }


        
    }
}
