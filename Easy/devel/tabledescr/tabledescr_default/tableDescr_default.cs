
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
using System.Linq;
using System.Windows.Forms;
using metadatalibrary;
using System.IO;
using q = metadatalibrary.MetaExpression;

namespace tabledescr_default {
    public partial class tableDescr_default : MetaDataForm {
        public tableDescr_default() {
            InitializeComponent();
			HelpForm.SetDenyNull(DS.tabledescr.Columns["isdbo"], true);
		}

        private MetaData meta;
        private DataAccess conn;
        public void MetaData_AfterLink() {
            meta = MetaData.GetMetaData(this);
            conn = meta.Conn;
            DataAccess.SetTableForReading(DS.relation_parent, "relation");
            DataAccess.SetTableForReading(DS.relation_child, "relation");
            DataAccess.SetTableForReading(DS.relationcol_child, "relationcol");

            meta.MarkTableAsNotEntityChild(DS.relationcol);
            meta.MarkTableAsNotEntityChild(DS.relationcol_child);

            meta.MarkTableAsNotEntityChild(DS.relation_parent);
            meta.MarkTableAsNotEntityChild(DS.relation_child);
        }

        private void btnCaptions_Click(object sender, EventArgs e) {
            if (meta.IsEmpty) return;
            DataRow curr = DS.tabledescr.Rows[0];
            string table = curr["tablename"].ToString();
            scegliTabella frm = new scegliTabella(1);
            frm.txtMeta.Text = table;
            if (frm.ShowDialog(this) != DialogResult.OK) return;
            table = frm.txtMeta.Text;
            LeggiCaption(table);


        }

        string prendiNomeDaForm(MetaData m) {
            string table = m.Name;
            Form f = m.GetPublicForm("default");
            if (m.Name != "" && m.Name != table) {
                return m.Name;               
            }

            //if (f != null && f.Text!="") {
            //    return f.Text;
            //}
            foreach (string edittype in m.EditTypes) {
                f = m.GetPublicForm(edittype);
                if (m.Name != "" && m.Name != table) {
                    return m.Name;
                }
            }
            return null;
        }

        public void MetaData_BeforeFill() {
            meta.MarkTableAsNotEntityChild(DS.colvalue);
            meta.MarkTableAsNotEntityChild(DS.colbit);
            meta.MarkTableAsNotEntityChild(DS.relationcol);
            meta.MarkTableAsNotEntityChild(DS.relationcol_child);

            meta.MarkTableAsNotEntityChild(DS.relation_parent);
            meta.MarkTableAsNotEntityChild(DS.relation_child);

            CQueryHelper QHC = new CQueryHelper();
            foreach(DataRow r in DS.relation_child.Rows) {
                if (r.RowState != DataRowState.Deleted) continue;
                foreach (DataRow rr in DS.relationcol_child.Select(
                    QHC.CmpEq("idrelation", r["idrelation", DataRowVersion.Original]))){
                    rr.Delete();
                }
            }
            foreach (DataRow r in DS.relation_parent.Rows) {
                if (r.RowState != DataRowState.Deleted) continue;
                foreach (DataRow rr in DS.relationcol.Select(
                    QHC.CmpEq("idrelation", r["idrelation", DataRowVersion.Original]))) {
                    rr.Delete();
                }
            }

            //Set default sulle due tabelle relation
            DataRow curr = DS.tabledescr.Rows[0];
            MetaData.SetDefault(DS.relation_parent, "parenttable", curr["tablename"]);
            MetaData.SetDefault(DS.relation_child, "childtable", curr["tablename"]);
            MetaData.SetDefault(DS.relation_child, "parenttable", "");
            MetaData.SetDefault(DS.relation_parent, "childtable", "");
        }

        /// <summary>
        /// Cerca di calcolare il nome di una tabella dai form ad essa collegati, sempre se non è già valorizzata
        /// </summary>
        /// <param name="table"></param>
        void leggiNome(string table) {
            CQueryHelper q = new CQueryHelper();

            MetaData host = meta.Dispatcher.Get(table);
            DataRow curr = DS.tabledescr.Rows[0];
            if (curr["description"].ToString() != "") return;
            if (host.Name == "" || host.Name == table) {

                string nomeDaForm = prendiNomeDaForm(host);
                if (nomeDaForm == null) return;
                host.Name = nomeDaForm;
            }
            txtDescrizione.Text = host.Name;
            curr["description"] = host.Name;
        }
        
        /// <summary>
        /// Cerca di valorizzare le caption vuote su colonne e tabelle
        /// </summary>
        /// <param name="table"></param>
        void LeggiCaption(string table) {
            CQueryHelper q = new CQueryHelper();
            QueryHelper QHS = meta.QHS;
            MetaData host = meta.Dispatcher.Get(table);
            DataTable t;
            foreach (string l in host.ListingTypes) {
                t = conn.CreateTableByName(table, "*");
                try {
                    host.DescribeColumns(t, l);
                }
                catch {
                    continue;
                }
                foreach (DataColumn c in t.Columns) {
                    if (c.Caption == c.ColumnName) continue;
                    if (string.IsNullOrEmpty(c.Caption)) continue;
                    DataRow[] found = DS.coldescr.Select(q.CmpEq("colname", c.ColumnName));
                    if (found.Length == 0) continue;
                    DataRow f = found[0];
                    string caption = f["description"].ToString();  //Valorizza le caption ove non già valorizzate
                    if (caption != "") continue;
                    string newCaption = c.Caption;
                    if (newCaption.StartsWith(".")) {
                        if (newCaption.Length > 0) {
                            newCaption = newCaption.Substring(1);
                        }
                        else {
                            newCaption = "";
                        }
                    }

                    f["description"] = newCaption;
                }
            }
            t = conn.RUN_SELECT("coldescr", "*", null, QHS.CmpEq("tablename", table), null, false);
            foreach (DataRow descrRow in t.Rows) {
                string colName = descrRow["colname"].ToString();
                DataRow[] found = DS.coldescr.Select(q.CmpEq("colname", colName));
                if (found.Length == 0) continue;
                DataRow toSet = found[0];
                if (toSet["description"].ToString() != "") continue;
                string descr = descrRow["description"].ToString();
                if (descr=="") continue;
                toSet["description"] = descr;
            }
        }

        /// <summary>
        /// Effettua LeggiCaption su tutte le tabelle in tabledescr
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCaptionGlobale_Click(object sender, EventArgs e) {
            DataTable allTables = conn.RUN_SELECT("tabledescr", "tablename", null, null, null, false);
            QueryHelper q = conn.GetQueryHelper();
            var ctrl = this.getInstance<IFormController>();
            foreach (DataRow r in allTables.Rows) {
                meta.DllDispatcher.unrecoverableError = false;
                meta.DoMainCommand("mainsetsearch");
                string table = r["tablename"].ToString();
                var ex = conn.count("tabledescr", MetaExpression.keyCmp(r));
                if (ex==0)continue;
                bool found = ctrl.searchRow( "default", q.CmpKey(r),false);
                if (!found) {
                    continue;
                }            
                //meta.SelectOne("default", q.CmpKey(r), "default", null);
                LeggiCaption(table);
                LeggiCaption(table+"view");
                meta.GetFormData(true);
                meta.SaveFormData();
                Application.DoEvents();
            }
        }

        private void btnAllNames_Click(object sender, EventArgs e) {
            DataTable allTables = conn.RUN_SELECT("tabledescr", "tablename", null, null, null, false);
            QueryHelper q = conn.GetQueryHelper();
            foreach (DataRow r in allTables.Rows) {
                meta.DoMainCommand("mainsetsearch");
                string table = r["tablename"].ToString();
                var ctrl = this.getInstance<IFormController>();
                bool found = ctrl.searchRow( "default", q.CmpKey(r),false);
                if (!found) {
                    continue;
                }
                //meta.SelectOne("default", q.CmpKey(r), "default", null);
                leggiNome(table);
                meta.SaveFormData();
                Application.DoEvents();
            }
        }

        private void btnLeggiDati_Click(object sender, EventArgs e) {
            if (meta.IsEmpty) return;
            DataRow r = DS.tabledescr.Rows[0];
            string table = r["tablename"].ToString();
            DataTable t = conn.RUN_SELECT(table, "*", null, null, "1000", false);
            frmVediTabella f = new frmVediTabella(t);
            f.Show();
        }

        private void btnAggiorna_Click(object sender, EventArgs e) {
            AggiornaStrutturaTabella();
        }

        void AggiornaStrutturaTabella() {
            if (meta.IsEmpty) return;
            meta.SaveFormData();
            if (DS.HasChanges()) {
                show("Salvare prima", "Errore");
                return;
            }

            DataRow r = DS.tabledescr.Rows[0];
            string table = r["tablename"].ToString();

            conn.Reset(true);
            try {
                this.conn.CallSP("clear_table_info",
                    new object[] { table });
            } catch {
                show("Errore eseguendo clear_table_info su '" + table + "'");
            }
            dbstructure DBS = (dbstructure)this.conn.GetStructure(table);
            conn.SaveStructure(DBS);
            dbanalyzer.ReadColumnTypes(DBS.columntypes, table, conn);

            
            
            QueryHelper QHS = conn.GetQueryHelper();
            CQueryHelper QHC = new CQueryHelper();

            string insertSql =
                "insert into coldescr (tablename, colname, description, col_len, col_scale, col_precision, sql_type, sql_declaration, system_type, primarykey, kind, lt, lu)"+
                " select tablename, field, null, col_len, col_scale, col_precision, sqltype, sqldeclaration, systemtype, iskey, 'S', null, 'nino' " +
                "from columntypes where  " + QHS.CmpEq("tablename", table) +
                " AND not exists (select * from coldescr C where C.tablename=columntypes.tablename and C.colname=columntypes.field)";
            DataTable t = conn.RUN_SELECT("columntypes", "*", null, QHS.CmpEq("tablename", table), null, false);
            foreach (DataRow rr in t.Select()) {
                string field = rr["field"].ToString();
                DataRow[] f = DS.coldescr.Select(QHC.CmpEq("colname", field));
                DataRow s;
                if (f.Length == 0) {
                    s = DS.coldescr.NewRow();
                    s["colname"] = rr["field"].ToString();
                    s["kind"] = "S";
                }
                else {
                    s = f[0];
                }
                foreach (
                    string col in new[] {"tablename", "col_len", "col_scale", "col_precision"}) {
                    s[col] = rr[col];
                }
                s["system_type"] = rr["systemtype"];
                s["sql_type"] = rr["sqltype"];
                s["sql_declaration"] = rr["sqldeclaration"];
                s["primarykey"] = rr["iskey"];

                if (f.Length == 0) {
                    DS.coldescr.Rows.Add(s);
                }
            }
            meta.SaveFormData();
        }

        private void btnSonarRelazioni_Click(object sender, EventArgs e) {
            string path = "D:\\easy";
            alreadyRead = new Dictionary<string, bool>();
            SearchRelation(path);
            

        }
        void SearchRelation(string path) {
            foreach (string sub in Directory.GetDirectories(path)) {
                SearchRelation(sub);
            }
            SearchXmlFile(path);
        }
        void SearchXmlFile(string path) {
            foreach(string xml in Directory.GetFiles(path, "*.xsd")) {
                ScanXmlFile(xml);
            }
        }
        void ScanXmlFile(string fileName) {
            if (fileName.Contains("fattura")) return;
            DataAccess conn = meta.Conn;
            
            DataSet d = new DataSet();
            try {
                d.ReadXml(fileName);
            }
            catch {
                return;
            }
            
            QueryHelper QHS = conn.GetQueryHelper();
            foreach(DataRelation r in d.Relations) {
                int isRealParent = conn.RUN_SELECT_COUNT("tabledescr", QHS.CmpEq("tablename", r.ParentTable.TableName), false);
                int isRealChild = conn.RUN_SELECT_COUNT("tabledescr", QHS.CmpEq("tablename", r.ChildTable.TableName), false);
                if (isRealParent == 0 || isRealChild == 0) continue;

                //Check if r is already in database                
                string filter = QHS.AppAnd(QHS.CmpEq("parenttable", r.ParentTable.TableName),QHS.CmpEq("childtable", r.ChildTable.TableName));
                DataTable t = conn.RUN_SELECT("relation", "*", null, filter, null, false);
                if (t.Rows.Count == 0) {
                    PrintRelation(fileName,r);
                    continue;
                }
                bool found = false;
                foreach(DataRow rDb in t.Rows) {     //vede se la relazione rDB è proprio r
                    
                    //Prende le colonne della relazione rDB
                    DataTable rCols = conn.RUN_SELECT("relationcol", "*", null, QHS.CmpEq("idrelation", rDb["idrelation"]), null, false);

                    if (rCols.Rows.Count != r.ParentColumns.Length) continue;


                    //Per ogni coppia in r.ParentColumns-r.ChildColumns cerca una corrispondente in rCols
                    bool CoppiaNonTrovata = false;
                    for (int i = 0; i < r.ParentColumns.Length; i++) {
                        bool foundCol = false;
                        foreach (DataRow rCol in rCols.Rows) {
                            if (rCol["parentcol"].ToString() != r.ParentColumns[i].ColumnName) continue;
                            //parentcol Found at position i
                            if (rCol["childcol"].ToString() != r.ChildColumns[i].ColumnName) continue;
                            foundCol = true;
                            break;
                        }
                        if (!foundCol) {
                            CoppiaNonTrovata = true;
                            break;
                        }
                    }
                    if (CoppiaNonTrovata) continue;
                    found = true;
                    break;
                }
                if (!found) {
                    PrintRelation(fileName,r);
                }
            }
        }

        Dictionary<string, bool> alreadyRead;
        void PrintRelation(string file,DataRelation r) {
            string s0 = $"File {file} Relation {r.RelationName}\n";
            string s=$"Parent: {r.ParentTable.TableName}  cols:{String.Join(",", (from DataColumn rr in r.ParentColumns select rr.ColumnName).ToArray())}\n";
            s+= $"Child: {r.ChildTable.TableName}  cols:{String.Join(",",(from DataColumn rr in r.ChildColumns select rr.ColumnName).ToArray())}\n";
            if (alreadyRead.ContainsKey(s)) return;
            alreadyRead.Add(s, true);
            QueryCreator.MarkEvent(s0+s);
        }
    }
}
