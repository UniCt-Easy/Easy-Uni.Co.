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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using metadatalibrary;
using System.Collections;

namespace no_table_advice {
    public partial class FrmNotable_advice : Form {
        MetaData Meta;
        QueryHelper QHS;
        CQueryHelper QHC;

        public FrmNotable_advice() {
            InitializeComponent();
        }
        public void MetaData_AfterLink () {
            Meta = MetaData.GetMetaData(this);
            Meta.SearchEnabled = false;
            Meta.CanInsertCopy = false;
            Meta.CanInsert = false;
            Meta.CanCancel = false;

            int altezza = 50;
            QHS = Meta.Conn.GetQueryHelper();
            QHC = new CQueryHelper();
            string filtroLogin = QHS.CmpEq("login", Meta.GetSys("user"));
            Meta.Conn.RUN_SELECT_INTO_TABLE(DS.dbuseradvice, null, filtroLogin, null, true);

            // Visualizzo solo i 10 avvisi più recenti se no il form diventa enorme
            string query = " SELECT TOP 10 advice.codeadvice from advice  " +
                         " LEFT OUTER JOIN dbuseradvice ON " +
                         " dbuseradvice.codeadvice = advice.codeadvice " +
                         " AND " + filtroLogin +
                         " WHERE " + QHS.IsNull("dbuseradvice.codeadvice")+
                         " ORDER BY advice.adate DESC ";
            DataTable tAdvice = Meta.Conn.SQLRunner(query);

            if ((tAdvice != null) && (tAdvice.Rows.Count > 0)) {
                 string filtroadvice = QHS.FieldIn("codeadvice", tAdvice.Select());

                Meta.Conn.RUN_SELECT_INTO_TABLE(DS.advice, "adate desc", filtroadvice, null, true);

                // inserisco in dbuseradvice tutti i codici dei messaggi 
                // attualmente visualizzati, per evitare che ricompaiano al prossimo riavvio del programma
                string insert = "INSERT INTO dbuseradvice  " +
                   " (codeadvice, login, lt, lu)  " +
                   " SELECT " +
                   " advice.codeadvice, " +
                   QHS.quote(Meta.GetSys("user")) + ", " +
                   //QHS.quote(Meta.GetSys("datacontabile")) + ", " +
                   " GetDate(), " +
                   QHS.quote("assistenza") +
                   " FROM advice WHERE " + filtroadvice
                   ;

                DataTable t = Meta.Conn.SQLRunner(insert);

                GetData.DenyClear(DS.advice);
                GetData.LockRead(DS.advice);
                GetData.DenyClear(DS.dbuseradvice);
                GetData.LockRead(DS.dbuseradvice);
                PostData.MarkAsTemporaryTable(DS.advice, false);
                int y = 0;
                
                foreach (DataRow r in DS.advice.Rows) {
                    string data = ((DateTime)r["adate"]).ToShortDateString();
                    GroupBox group = new GroupBox();
                    group.Location = new Point(10, y + 10);
                    group.Size = new Size(400, altezza + 30);
                    group.Text = "Comunicazione " + r["codeadvice"] + " del " + data;
                    group.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left)
                                | AnchorStyles.Right)));
                    Controls.Add(group);

                    TextBox textAvviso = new TextBox();
                    group.Controls.Add(textAvviso);
                    textAvviso.Location = new Point(10, 20);
                    textAvviso.Width = 300;
                    textAvviso.Multiline = true;
                    textAvviso.ScrollBars = ScrollBars.Vertical;
                    textAvviso.Height = altezza;
                    textAvviso.ReadOnly = true;
                    textAvviso.Text = r["title"].ToString();
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
                    y += altezza + 30;
                }
                
                Size = new Size(450, y + 80);

                Button btnOk = new Button();
                Controls.Add(btnOk);
                btnOk.Location = new Point(190, y + 20);
                btnOk.DialogResult = DialogResult.OK;
                btnOk.Width = 70;
                btnOk.Text = "OK";
                btnOk.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));

                this.AcceptButton = btnOk;
            }
        }

        Hashtable tags = new Hashtable();

        private void btnDettagli_Click(object sender, EventArgs e) {
            Button btnDettagli = (Button)sender;
            DataRow radvice = (DataRow) btnDettagli.Tag;

            /*
            string[] columns = new string[] { "codeadvice", "login", "lt", "lu" };
            string[] values = new string[] {
											   QHS.quote(radvice["codeadvice"]),
											   QHS.quote(Meta.GetSys("user")),
											   QHS.quote(Meta.GetSys("datacontabile")) ,
											   QHS.quote("assistenza")};

            Meta.Conn.DO_INSERT("dbuseradvice", columns, values, columns.Length);
            */

            if (radvice["description"].ToString() == "") return;
            FrmViewResult V = new FrmViewResult(
                           radvice["title"].ToString(),
                           radvice["description"].ToString()
                           );
            V.ShowDialog(this);
        }

        public void MetaData_AfterClear() {
            Text = "Comunicazioni";
        }
    }
}
