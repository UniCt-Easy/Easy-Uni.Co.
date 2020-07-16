/*
    Easy
    Copyright (C) 2020 UniversitÃ  degli Studi di Catania (www.unict.it)
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
using System.Collections;

namespace no_table_alert {
    public partial class FrmNotable_alert : Form {
        MetaData Meta;
        QueryHelper QHS;
        CQueryHelper QHC;

        public FrmNotable_alert() {
            InitializeComponent();
        }
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Meta.SearchEnabled = false;
            Meta.CanInsertCopy = false;
            Meta.CanInsert = false;
            Meta.CanCancel = false;
            DataAccess conn = Meta.Conn;


            int altezza = 70;
            QHS = Meta.Conn.GetQueryHelper();
            QHC = new CQueryHelper();
            string filtroLogin = QHS.CmpEq("login", Meta.GetSys("user"));
            Meta.Conn.RUN_SELECT_INTO_TABLE(DS.dbuseralert, null, filtroLogin, null, true);
            string filtroAlert = QHS.AppAnd(
                QHS.FieldIn("idalert", DS.dbuseralert.Select()),
                QHS.CmpNe("query", ""));
            Meta.Conn.RUN_SELECT_INTO_TABLE(DS.alert, null, filtroAlert, null, true);
            GetData.DenyClear(DS.alert);
            GetData.LockRead(DS.alert);
            GetData.DenyClear(DS.dbuseralert);
            GetData.LockRead(DS.dbuseralert);
            PostData.MarkAsTemporaryTable(DS.alert, false);
            int y = 0;
            foreach (DataRow r in DS.alert.Rows) {
                string baseQuery = r["query"].ToString();
                string query = conn.Compile(r["query"].ToString(), true);
                if (query.Contains("<%usr[") ) continue;
                if (query.Contains("<%sys[") ) continue;
                if (query == "(1=2)") continue;
                DataTable t = Meta.Conn.SQLRunner(query);
                if ((t != null) && (t.Rows.Count > 0)) {
                    GroupBox group = new GroupBox();
                    group.Location = new Point(10, y + 10);
                    group.Size = new Size(715, altezza + 30);
                    group.Text = "Avviso " + r["idalert"];
                    group.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left)
                                | AnchorStyles.Right)));
                    Controls.Add(group);

                    TextBox textAvviso = new TextBox();
                    group.Controls.Add(textAvviso);
                    textAvviso.Location = new Point(10, 20);
                    textAvviso.Width = 500;
                    textAvviso.Multiline = true;
                    textAvviso.Height = altezza;
                    textAvviso.ReadOnly = true;
                    textAvviso.Text = r["description"].ToString();
                    textAvviso.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left)
                                | AnchorStyles.Right)));

                    Button btnDettagli = new Button();
                    group.Controls.Add(btnDettagli);
                    btnDettagli.Location = new Point(textAvviso.Location.X + textAvviso.Width + 12, 27);
                    btnDettagli.Width = 70;
                    btnDettagli.Text = "Dettagli";
                    btnDettagli.Tag = r;
                    btnDettagli.Click += new System.EventHandler(btnDettagli_Click);
                    btnDettagli.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));

                    Button btnQuery = new Button();
                    group.Controls.Add(btnQuery);
                    btnQuery.Location = new Point(btnDettagli.Location.X + btnDettagli.Width + 12, 27);
                    btnQuery.AutoSize = true;
                    btnQuery.Text = "Ottieni elenco";
                    btnQuery.Tag = r;
                    btnQuery.Click += new System.EventHandler(btnQuery_Click);
                    btnQuery.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));

                    if (r["lu"].ToString() != "sysadmin" && r["cu"].ToString() != "sysadmin") {
	                    CheckBox check = new CheckBox();
	                    group.Controls.Add(check);
	                    check.AutoSize = true;
	                    check.Location = new Point(textAvviso.Location.X + textAvviso.Width + 10, 60);
	                    check.ThreeState = false;
	                    check.Text = "Non visualizzare più quest'avviso";
	                    check.CheckedChanged += new System.EventHandler(this.check_CheckedChanged);
	                    string ff = QHC.CmpEq("idalert", r["idalert"]);
	                    tags[check] = ff;
	                    check.Checked = DS.dbuseralert.Select(ff).Length == 0;
	                    check.Anchor = ((AnchorStyles) ((AnchorStyles.Top | AnchorStyles.Right)));
                    }

                    y += altezza + 50;
                }
            }
            Size = new Size(750, y + 40);
            RUNNED=true;
        }

        Hashtable tags = new Hashtable();

        bool RUNNED = false;
        private void btnDettagli_Click(object sender, EventArgs e) {
            Button btnDettagli = (Button)sender;
            DataRow rAlert = (DataRow) btnDettagli.Tag;
            MessageBox.Show(this, rAlert["alertdetail"].ToString());
        }

        private void btnQuery_Click(object sender, EventArgs e) {
            Button btnQuery = (Button)sender;
            DataRow rAlert = (DataRow) btnQuery.Tag;
            string cmd = rAlert["query"].ToString();
            if (cmd.Trim() == "") return;
            string sql = Meta.Conn.Compile(cmd, true);
            if (sql.Contains("usr[") || sql.Contains("sys[") || sql=="(1=2)") {
                MessageBox.Show("Il comando contiene variabili di ambiente non compilate quindi non è eseguibile.",
                    "Avviso");
                return;
            }
            FrmViewResult V = new FrmViewResult(Meta,sql,
                            rAlert["tablename"].ToString(),
                            rAlert["listtype"].ToString(),
                            rAlert["edittype"].ToString());
            V.Show(this);
        }
        public void MetaData_AfterClear() {
            Text = "Avvisi";
        }

        private void check_CheckedChanged(object sender, EventArgs e) {
            if (!RUNNED) return;
            CheckBox check = (CheckBox)sender;
            if (check.Checked) {
                foreach (DataRow r in DS.dbuseralert.Select(tags[check].ToString())) {
                    r.Delete();
                }
            } else {
                MetaData metaUserAlert = MetaData.GetMetaData(this, "dbuseralert");
                metaUserAlert.SetDefaults(DS.dbuseralert);
                DataRow[] found = DS.alert.Select(tags[check].ToString());
                if (found.Length == 0) return;
                DataRow rAlert = found[0];
                DataRow rUA = metaUserAlert.Get_New_Row(rAlert, DS.dbuseralert);
                rUA["idalert"] = rAlert["idalert"];
                rUA["login"] = Meta.GetSys("user");
            }
            
            PostData pd = new PostData();
            pd.InitClass(DS, Meta.Conn);
            bool ok = pd.DO_POST();
        }
    }
}
