
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
using System.Windows.Forms;
using metadatalibrary;

namespace no_table_unifica_anagrafiche {
    public partial class FrmNoTable_Unifica_Anagrafiche : MetaDataForm {
        CQueryHelper QHC;
        QueryHelper QHS;
        MetaData Meta;
    
        public FrmNoTable_Unifica_Anagrafiche() {
            InitializeComponent();
        }

      

        public void MetaData_AfterActivation() {
            impostaColoreBottoni();
            if (this.Text.EndsWith("(Ricerca)")) {
                this.Text = this.Text.Substring(0, Text.Length - 10);
            }

            Meta.Conn.RUN_SELECT_INTO_TABLE(DS.registrymainview, "title", QHS.IsNotNull("toredirect"), null, false);
			/*DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.registrymainview,
               "title ASC", QHS.IsNotNull("toredirect"),
               null, false);*/
			ImpostaCaption();
			PostData.MarkAsTemporaryTable(DS.registrymainview, false); 
            if (GridAnagrafiche.DataSource == null) {
                HelpForm.SetDataGrid(GridAnagrafiche, DS.registrymainview);

				new formatgrids(GridAnagrafiche).AutosizeColumnWidth();
            }
        }

		private void ImpostaCaption() {
			foreach (DataColumn C in DS.registrymainview.Columns) {
				string colName = C.ColumnName;
				MetaData.DescribeAColumn(DS.registrymainview, colName, "");
			}

			DS.registrymainview.Columns["idreg"].Caption = "Codice";
			DS.registrymainview.Columns["toredirect"].Caption = "Da unificare con";
			DS.registrymainview.Columns["title"].Caption = "Denominazione";
			DS.registrymainview.Columns["surname"].Caption = "Cognome";
			DS.registrymainview.Columns["forename"].Caption = "Nome";
			DS.registrymainview.Columns["cf"].Caption = "Cod. Fiscale";
			DS.registrymainview.Columns["p_iva"].Caption = "Partita IVA";
			DS.registrymainview.Columns["registryclass"].Caption = "Tipologia";
			DS.registrymainview.Columns["lt"].Caption = "lt";
			DS.registrymainview.Columns["lu"].Caption = "lu";
			DS.registrymainview.Columns["active"].Caption = "attiva";
		}
        private void impostaColoreBottoni() {
            btnUnifica.BackColor = formcolors.GridButtonBackColor();
            btnUnifica.ForeColor = formcolors.GridButtonForeColor();
        }

        public void MetaData_AfterClear() {
            if (this.Text.Trim().EndsWith("(Ricerca)")) {
                this.Text = this.Text.Substring(0, Text.Length - 10);
            }
        }

        public void MetaData_AfterFill() {
            if (this.Text.Trim().EndsWith("(Ricerca)")) {
                this.Text = this.Text.Substring(0, Text.Length - 10);
            }
        }

     
       
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            GetData.SetSorting(DS.registrymainview, "toredirect,idreg");
         }

        private void btnUnifica_Click (object sender, EventArgs e) {
            Meta.Conn.CallSP("unify_registry", new object[] {}, false, 600);
            show("Operazione eseguita.");
        }

        DataRow GetGridRow (int index) {
            string TableName = GridAnagrafiche.DataMember.ToString();
            DataSet MyDS = (DataSet)GridAnagrafiche.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];
            string filter = QHC.CmpEq("idreg", GridAnagrafiche[index, 0]);
            DataRow[] selectresult = MyTable.Select(filter);
            return selectresult[0];
        }

        private void GridAnagrafiche_DoubleClick (object sender, EventArgs e) {
            int i = GridAnagrafiche.CurrentRowIndex;
            if (i < 0) return;

            GridSelectRow(i);
        }

        void GridSelectRow (int I) {
            DataRow R = GetGridRow(I);
            if (R == null) return;
            MetaData Registry = Meta.Dispatcher.Get("registry");

            Registry.ContextFilter = QHS.CmpEq("idreg", R["toredirect"]);
            Registry.Edit(this.ParentForm, "anagrafica", false);
            string listtype = Registry.DefaultListType;
            DataRow RR = Registry.SelectOne(listtype, QHS.CmpEq("idreg", R["toredirect"]), null, null);
            if (RR != null) Registry.SelectRow(RR, listtype);
        }
    }
}
