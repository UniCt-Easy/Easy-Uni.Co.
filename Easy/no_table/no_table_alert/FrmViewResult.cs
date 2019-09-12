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

namespace no_table_alert {
    public partial class FrmViewResult : Form {
        string table;
        string listtype;
        string edittype;
        MetaData Meta;
        DataTable T;
        QueryHelper QHS;

        public FrmViewResult(MetaData Meta,
                string cmd, string table, string listtype, string edittype) {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            this.table = table;
            this.listtype = listtype.Trim();
            this.edittype = edittype;
            Text = "Elenco di problemi da risolvere";
            //Text = table + "." + listtype + "." + edittype;
            this.Meta = Meta;
            QHS = Meta.Conn.GetQueryHelper();

            T = Meta.Conn.SQLRunner(cmd, false);
            if (T == null) return;

            DataSet DD = new DataSet("temp");

            ClearDataSet.RemoveConstraints(DD);
            DD.Tables.Add(T);
            HelpForm.SetDataGrid(dgrid, T);
            //dgrid.SetDataBinding(DD, T.TableName);

            formatgrids fg = new formatgrids(dgrid);
            fg.AutosizeColumnWidth();

        }

		private void dgrid_DoubleClick(object sender, System.EventArgs e) {
			DataRow Curr = CurrentSelectedRow();
			if (Curr==null) return;
			DataTable Dest = Meta.Conn.CreateTableByName(table,"*");
            string filter = "";
            bool errore = false;
            foreach (DataColumn c in Dest.PrimaryKey) {
                if (Curr.Table.Columns.Contains(c.ColumnName)) {
                    filter = QHS.AppAnd(filter, QHS.CmpEq(c.ColumnName, Curr[c.ColumnName]));
                } else {
                    if (c.ColumnName == "ayear") {
                        filter = QHS.AppAnd(filter, QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
                    }
                    else {
                        errore = true;
                    }
                }
            }
            if (errore) {
                string collist = "";
                foreach (DataColumn c in Dest.PrimaryKey) {
                    if (collist != "") collist += ",";
                    collist += c.ColumnName;
                }
                MessageBox.Show("Nelle colonne selezionate non era presente la chiave primaria della " +
                    "tabella " + Dest.TableName + ".\r" +
                    " Le colonne sono " + collist, "Errore");
                return;
            }
			MetaData DestM= Meta.Dispatcher.Get(table);
			if (listtype=="") listtype= DestM.DefaultListType;
			bool res= DestM.Edit(this, edittype.ToString(), false);
			DataRow RR = DestM.SelectOne(listtype, filter, null,null);
			if (RR!=null) DestM.SelectRow(RR,listtype);

		}
		public DataRow CurrentSelectedRow(){
			DataGrid GParent = dgrid;

			DataSet  DSV = (DataSet) GParent.DataSource;
			if (DSV==null) return null;
			DataTable TV=  DSV.Tables[GParent.DataMember];
			if (TV==null) return null;		
                
			if (TV.Rows.Count==0) return null;
			DataRowView DV = null;
			try {
				DV = (DataRowView) GParent.BindingContext[DSV, TV.TableName].Current;
			}
			catch {
				DV=null;
			}
			if (DV==null) return null;

			return DV.Row;


		}
		private void menuItem1_Click(object menusender, System.EventArgs e) {
			if (menusender==null) return;
			if (!(typeof(MenuItem).IsAssignableFrom(menusender.GetType())))return;
			object sender  = ((MenuItem) menusender).Parent.GetContextMenu().SourceControl;
			if (!(typeof(DataGrid).IsAssignableFrom(sender.GetType())))return;
			DataGrid G = (DataGrid) sender;
			object DDS = G.DataSource;
			if (DDS==null) return;
			if (!typeof(DataSet).IsAssignableFrom(DDS.GetType()))return;
			string DDT = G.DataMember;
			if (DDT==null) return;
			DataTable T = ((DataSet)DDS).Tables[DDT];
			if (T==null) return;
			exportclass.DataTableToExcel(T,true);

		}
	}
}