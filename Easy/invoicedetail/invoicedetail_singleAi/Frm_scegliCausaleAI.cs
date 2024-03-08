
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using metadatalibrary;
using System.Data;
//using funzioni_configurazione;

namespace invoicedetail_singleAi {
	public partial class Frm_scegliCausaleAI : MetaDataForm {
		MetaData Meta;
		string QuerySql;
		DataAccess Conn;
		public DataRow[] SelectedRows = null;
		public DataRow[] SelectedRowsbk;
		QueryHelper QHS;
		CQueryHelper QHC;
		public Frm_scegliCausaleAI(MetaData Meta, string Sql) {
			InitializeComponent();
			this.Meta = Meta;
			this.Conn = Meta.Conn;
			this.QuerySql = Sql ;
			QHC = new CQueryHelper();
			QHS = Conn.GetQueryHelper();
			creaTable();
			riempiGrid();
			FormInit();
		}
		DataTable TabCausali = null;
		void creaTable() {
			TabCausali = new DataTable();
			TabCausali.CaseSensitive = false;
			TabCausali.TableName = "causali";

			TabCausali.Columns.Add("ai");
			TabCausali.Columns.Add("idaccmotive");
			TabCausali.Columns.Add("paridaccmotive");
			TabCausali.Columns.Add("codemotive");
			TabCausali.Columns.Add("motive");
			TabCausali.Columns.Add("cu");
			TabCausali.Columns.Add("ct", typeof(DateTime));
			TabCausali.Columns.Add("lu");
			TabCausali.Columns.Add("lt", typeof(DateTime));
			TabCausali.Columns.Add("active");
			TabCausali.Columns.Add("idepoperation");
			TabCausali.Columns.Add("epoperation");
			TabCausali.Columns.Add("in_use");

			TabCausali.Columns.Add("flagamm");
			TabCausali.Columns.Add("flagdep");
			TabCausali.Columns.Add("expensekind");
			TabCausali.Columns.Add("sortcode");

		}
		void riempiGrid() {

			TabCausali = Conn.SQLRunner(QuerySql);
			//if (TabCausali.Rows.Count != 0) {
			//	TabCausali.PrimaryKey = new[] { TabCausali.Columns["ai"], TabCausali.Columns["idaccmotive"] };
			//}
			TabCausali.Columns["AI"].Caption = "AI";
			TabCausali.Columns["idaccmotive"].Caption = "";
			TabCausali.Columns["paridaccmotive"].Caption = "";
			TabCausali.Columns["codemotive"].Caption = "CodCausale";
			TabCausali.Columns["motive"].Caption = "Causale";
			TabCausali.Columns["cu"].Caption = "";
			TabCausali.Columns["ct"].Caption = "";
			TabCausali.Columns["lu"].Caption = "";
			TabCausali.Columns["lt"].Caption = "";
			TabCausali.Columns["active"].Caption = "";
			TabCausali.Columns["idepoperation"].Caption = "";
			TabCausali.Columns["epoperation"].Caption = "";
			TabCausali.Columns["in_use"].Caption = "";
			TabCausali.Columns["flagamm"].Caption = "";
			TabCausali.Columns["flagdep"].Caption = "";
			TabCausali.Columns["expensekind"].Caption = "";
			TabCausali.Columns["sortcode"].Caption = "";
			TabCausali.AcceptChanges();

			DataSet D = new DataSet();
			D.Tables.Add(TabCausali);
			HelpForm.SetDataGrid(gridDettagliCausale, TabCausali);
			gridDettagliCausale.TableStyles.Clear();
			HelpForm.SetGridStyle(gridDettagliCausale, TabCausali);
			formatgrids format = new formatgrids(gridDettagliCausale);
			format.AutosizeColumnWidth();

		}
		string CustomTitle;
		void FormInit() {
			CustomTitle = "Selezione Causale tramite Intelligenza Artificiale";
			tabController.HideTabsMode =
				Crownwood.Magic.Controls.TabControl.HideTabsModes.HideAlways;

			//Selects first tab
			displayTabs(0);
		}
		void displayTabs(int newTab) {
			tabController.SelectedIndex = newTab;
			//Evaluates Buttons Appearance
			//btnBack.Visible = (newTab > 0);
			if (newTab == tabController.TabPages.Count - 1)
				btnNext.Text = "Inserisci";
			else
				btnNext.Text = "Avanti >";
			Text = CustomTitle;// + " (Pagina " + (newTab + 1) + " di " + tabController.TabPages.Count + ")";
		}
		DataRow GetGridRow(DataGrid G, int index) {
			string TableName = G.DataMember;
			DataSet MyDS = (DataSet)G.DataSource;
			DataTable MyTable = MyDS.Tables[TableName];
			string filter;
			filter = QHC.AppAnd(QHC.CmpEq("ai", G[index, 0]));

			DataRow[] selectresult = MyTable.Select(filter);
			if (selectresult.Length == 0) return null;
			return selectresult[0];
		}
		private bool alreadyselected(DataRow currRowgrid, DataRow[] rrowSelected) {
			foreach (DataRow R in rrowSelected)
				if (R == currRowgrid) return true;
			return false;

		}
		private DataRow[] GetGridSelectedRows(DataGrid G) {
			if (G.DataMember == null) return null;
			if (G.DataSource == null) return null;
			string TableName = G.DataMember;
			DataSet MyDS = (DataSet)G.DataSource;
			DataTable MyTable = MyDS.Tables[TableName];
			int numrighetemp = MyTable.Rows.Count;
			int numrighe = 0;
			int i;
			for (i = 0; i < numrighetemp; i++) {
				if (G.IsSelected(i)) {
					numrighe++;
				}
			}

			DataRow[] Res = new DataRow[numrighe];
			int count = 0;
			for (i = 0; i < numrighetemp; i++) {
				if (G.IsSelected(i)) {
					Res[count++] = GetGridRow(G, i);
				}
			}
			return Res;
		}
		bool InsidePaint = false;
		private void gridDettagliFatturaMadre_Paint(object sender, PaintEventArgs e) {
			if (string.IsNullOrEmpty(gridDettagliCausale.DataMember)) return;
			if (InsidePaint) return;
			InsidePaint = true;
			int i;

			string TableName = gridDettagliCausale.DataMember;
			DataSet MyDS = (DataSet)gridDettagliCausale.DataSource;
			DataTable MyTable = MyDS.Tables[TableName];

			int numrighetemp = MyTable.Rows.Count;
			DataRow gridrow = null;

			// Contiene le righe selezionate RowSelectedbk, lo fa solo una volta
			if (SelectedRowsbk == null)
				SelectedRowsbk = new DataRow[numrighetemp];

			for (i = 0; i < numrighetemp; i++) {
				if (gridDettagliCausale.IsSelected(i)) {
					gridrow = GetGridRow(gridDettagliCausale, i);
					if (alreadyselected(gridrow, SelectedRowsbk)) continue;
				}
				if (!(gridDettagliCausale.IsSelected(i))) {
					gridrow = GetGridRow(gridDettagliCausale, i);
					if (!(alreadyselected(gridrow, SelectedRowsbk))) continue;
				}
			}

			SelectedRowsbk = GetGridSelectedRows(gridDettagliCausale);
			InsidePaint = false;
		}
		bool customChangeTab(int oldTab, int newTab) {
			if ((oldTab == 0) && (newTab == 1)) return ScegliDocs();
			if ((oldTab == 1) && (newTab == 2)) return true;
			return true;
		}
		bool ScegliDocs() {
			SelectedRows = GetGridSelectedRows(gridDettagliCausale);
			if ((SelectedRows == null) || (SelectedRows.Length == 0)) {
				show("Non è stato selezionato alcun dettaglio.");
				return false;
			}

			return true;
		}
		void standardChangeTab(int step) {
			var oldTab = tabController.SelectedIndex;
			var newTab = oldTab + step;
			if (newTab < 0 || (newTab > tabController.TabPages.Count)) return;
			if (!customChangeTab(oldTab, newTab)) return;
			if (newTab == tabController.TabPages.Count) {
				DialogResult = DialogResult.OK;
				return;
			}
			displayTabs(newTab);
		}

		private void btnNext_Click(object sender, EventArgs e) {
			standardChangeTab(+1);
		}

		private void btnCancel_Click(object sender, EventArgs e) {

		}
	}
}
