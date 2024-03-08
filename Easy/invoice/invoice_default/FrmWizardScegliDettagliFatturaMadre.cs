
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
using funzioni_configurazione;

namespace invoice_default {
	public partial class FrmWizardScegliDettagliFatturaMadre : MetaDataForm {
		//private Crownwood.Magic.Controls.TabPage tabPage2;
		//private System.ComponentModel.Container components = null;
		MetaData Meta;
		//private System.Windows.Forms.DataGrid gridDettagli;
		string filterregistry;
		string acquistovendita;
		object idcurrency;
		int flagactivity;
		private Crownwood.Magic.Controls.TabControl tabController;
		ContextMenu ExcelMenu;
		DataTable InvoiceDetail;
		DataAccess Conn;
		//private System.Windows.Forms.Label labelMsg;
		public DataRow[] SelectedRows = null;
		private System.Windows.Forms.Label lblselezautomaticamente;
		//private Label label1;
		//private Label lblValuta;
		public DataRow[] SelectedRowsbk;
		QueryHelper QHS;
		CQueryHelper QHC;

		public FrmWizardScegliDettagliFatturaMadre(MetaData Meta, string filterregistry, string acquistovendita,
					object idcurrency, int flagactivity, DataTable invoiceDetail) {
			InitializeComponent();
			this.Meta = Meta;
			this.Conn = Meta.Conn;
			this.filterregistry = filterregistry;
			this.InvoiceDetail = invoiceDetail;
			this.acquistovendita = acquistovendita;
			this.idcurrency = idcurrency;
			this.flagactivity = flagactivity;
			QHC = new CQueryHelper();
			QHS = Conn.GetQueryHelper();

			ExcelMenu = new ContextMenu();
			ExcelMenu.MenuItems.Add("Excel", Excel_Click);
			gridDettagliFatturaMadre.ContextMenu = ExcelMenu;
			riempiGrid();

			FormInit();
		}
		private static void Excel_Click(object menusender, EventArgs e) {
			object sender = (menusender as MenuItem)?.Parent.GetContextMenu()?.SourceControl;
			if (!(sender is DataGrid)) return;
			var g = (DataGrid)sender;
			var dds = g.DataSource;
			if (!(dds is DataSet)) return;
			var ddt = g.DataMember;
			if (ddt == null) return;
			var T = ((DataSet)dds).Tables[ddt];
			if (T == null) return;
			exportclass.DataTableToExcel(T, true);
		}

		string CustomTitle;
		void FormInit() {
			CustomTitle = "Creazione fattura da fattura di riferimento";
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
			Text = CustomTitle + " (Pagina " + (newTab + 1) + " di " + tabController.TabPages.Count + ")";
		}
		void SelezionaTutto() {
			object dataSource = gridDettagliFatturaMadre.DataSource;
			if (dataSource == null) return;

			var cm = (CurrencyManager)
				gridDettagliFatturaMadre.BindingContext[dataSource, gridDettagliFatturaMadre.DataMember];

			var view = cm.List as DataView;

			if (view != null) {
				for (int i = 0; i < view.Count; i++) {
					gridDettagliFatturaMadre.Select(i);
				}
			}
		}

		void riempiGrid() {

			string filtercurrency = QHS.CmpEq("idcurrency", idcurrency);
			filtercurrency = QHS.DoPar(QHS.AppOr(filtercurrency, QHS.IsNull("idcurrency")));
			string filter = QHS.AppAnd(filterregistry, filtercurrency);
			//"NLdaLIQ,NLdaSOSP,NOLIQ";
			string listaPccStatus = "NLdaLIQ,NLdaSOSP,NOLIQ" ;
			listaPccStatus = "'" + listaPccStatus.ToString().Replace(",", "','") + "'";
			string filterpcc = "";
			if (acquistovendita == "A") {
				filterpcc = QHS.FieldInList("idpccdebitstatus", listaPccStatus);
				filterpcc = QHS.DoPar(QHS.AppOr(filterpcc, QHS.IsNull("idpccdebitstatus")));
			}
			filter = QHS.AppAnd(filter, filterpcc, QHS.CmpEq("kind", acquistovendita), QHS.CmpGt("residual-linked", 0), QHS.CmpEq("flagactivity", flagactivity));
			
			object currency = Conn.DO_READ_VALUE("currency", filtercurrency, "description");
			if (currency != null) {
				lblValuta.Text = currency.ToString().ToUpper();
			}
			DataTable invDetailMain;

			invDetailMain = Conn.RUN_SELECT("invoicedetailmainavailable", "*",
						"idinvkind ASC,yinv DESC,ninv DESC,rownum ASC",
							filter, null, false);


			Conn.DeleteAllUnselectable(invDetailMain);

			if (invDetailMain.Rows.Count != 0) {
				invDetailMain.PrimaryKey = new[]{invDetailMain.Columns["idinvkind"],
															  invDetailMain.Columns["yinv"],
															  invDetailMain.Columns["ninv"],
															  invDetailMain.Columns["rownum"]};
				//Ora ha messo in invDetail tutto ciò che da DB è idoneo 'da associare'.

				//Effettua ora una serie di allineamenti sul DataTable per renderlo più coerente con quello
				// che c'è nel DataSet del form padre.

				//Per ogni riga del DataSet in stato di INSERT/UPDATE effettua una sottrazione ed eventualmente
				// un delete su invDetail se la riga corrispondente risulta essere esaurita.
				foreach (DataRow R in InvoiceDetail.Select()) {
					if (R.RowState != DataRowState.Added) continue;
					if (R["idinvkind_main"] == DBNull.Value) continue; //Non è una riga collegata a dettagli fatt
					string filterMain = QHC.AppAnd(	QHC.CmpEq("idinvkind", R["idinvkind_main"]),
							QHC.CmpEq("yinv", R["yinv_main"]),
							QHC.CmpEq("ninv", R["ninv_main"]),
							QHC.CmpEq("rownum", R["rownum_main"])
						);


					DataRow[] RM = invDetailMain.Select(filterMain);
					if ((RM.Length == 0)) continue;
					var detail = RM[0];
					decimal oldnumber = 0;
					decimal newnumber = CfgFn.GetNoNullDecimal(R["number", DataRowVersion.Current]);
					decimal oldresidual = CfgFn.GetNoNullDecimal(detail["residual"]);
					decimal newresidual = oldresidual - newnumber + oldnumber;
					detail["residual"] = newresidual;
				}

				foreach (DataRow R in InvoiceDetail.Select()) {
					if (R.RowState != DataRowState.Modified) continue;
					string filterMain = QHC.AppAnd(QHC.CmpEq("idinvkind", R["idinvkind_main"]),
							QHC.CmpEq("yinv", R["yinv_main"]),
							QHC.CmpEq("ninv", R["ninv_main"]),
							QHC.CmpEq("rownum", R["rownum_main"])
						);
					DataRow[] RM = invDetailMain.Select(filterMain);
					if ((RM.Length == 0)) continue;
					DataRow detail = RM[0];
					decimal oldnumber;
					if (R["idinvkind_main", DataRowVersion.Original] == DBNull.Value)
						oldnumber = 0;
					else
						oldnumber = CfgFn.GetNoNullDecimal(R["number", DataRowVersion.Original]);

					decimal newnumber;
					if (R["idinvkind_main", DataRowVersion.Current] == DBNull.Value)
						newnumber = 0;
					else
						newnumber = CfgFn.GetNoNullDecimal(R["number", DataRowVersion.Current]);


					decimal oldresidual = CfgFn.GetNoNullDecimal(detail["residual"]);
					decimal newresidual = oldresidual - newnumber + oldnumber;
					detail["residual"] = newresidual;
				}

				foreach (DataRow r in InvoiceDetail.Rows) {
					if (r.RowState != DataRowState.Deleted) continue;
					if (r["idinvkind_main", DataRowVersion.Original] == DBNull.Value) continue;

					string filterMain = QHC.AppAnd(QHC.CmpEq("idinvkind", r["idinvkind_main", DataRowVersion.Original]),
						QHC.CmpEq("yinv", r["yinv_main", DataRowVersion.Original]),
						QHC.CmpEq("ninv", r["ninv_main", DataRowVersion.Original])
					);
					filterMain = QHC.AppAnd(filterMain, QHC.CmpEq("rownum", r["rownum_main", DataRowVersion.Original]));

					DataRow[] RM = invDetailMain.Select(filterMain);
					if ((RM.Length == 0)) continue;
					DataRow Detail = RM[0];
					decimal oldnumber = CfgFn.GetNoNullDecimal(r["number", DataRowVersion.Original]);
					decimal newnumber = 0;
					decimal oldresidual = CfgFn.GetNoNullDecimal(Detail["residual"]);
					decimal newresidual = oldresidual - newnumber + oldnumber;
					Detail["residual"] = newresidual;
				}

				foreach (DataRow R in invDetailMain.Select()) {
					decimal residual = CfgFn.GetNoNullDecimal(R["residual"]);
					if (residual == 0) R.Delete();
				}

				invDetailMain.AcceptChanges();
				if (invDetailMain.Select().Length > 0) {
					MetaData MAP;
					MAP = Meta.Dispatcher.Get("invoicedetailmainavailable");
					MAP.DescribeColumns(invDetailMain, "default");
					DataSet D = new DataSet();
					D.Tables.Add(invDetailMain);
					HelpForm.SetDataGrid(gridDettagliFatturaMadre, invDetailMain);
					gridDettagliFatturaMadre.TableStyles.Clear();
					HelpForm.SetGridStyle(gridDettagliFatturaMadre, invDetailMain);
					formatgrids format = new formatgrids(gridDettagliFatturaMadre);
					format.AutosizeColumnWidth();
					HelpForm.SetAllowMultiSelection(invDetailMain, true);
					SelezionaTutto();
				}
			}
		}
		private bool alreadyselected(DataRow currRowgrid, DataRow[] rrowSelected) {
			foreach (DataRow R in rrowSelected)
				if (R == currRowgrid) return true;
			return false;

		}
		bool InsidePaint = false;

		/// <summary>
		/// Changes tab backward/forward
		/// </summary>
		/// <param name="step"></param>
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
		DataRow GetGridRow(DataGrid G, int index) {
			string TableName = G.DataMember;
			DataSet MyDS = (DataSet)G.DataSource;
			DataTable MyTable = MyDS.Tables[TableName];
			string filter;
			filter = QHC.AppAnd(QHC.CmpEq("idinvkind", G[index, 0]),
							QHC.CmpEq("yinv", G[index, 2]),
							QHC.CmpEq("ninv", G[index, 3]),
							QHC.CmpEq("rownum", G[index, 4]));

			DataRow[] selectresult = MyTable.Select(filter);
			if (selectresult.Length == 0) return null;
			return selectresult[0];
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

		bool ScegliDocs() {
			SelectedRows = GetGridSelectedRows(gridDettagliFatturaMadre);
			if ((SelectedRows == null) || (SelectedRows.Length == 0)) {
				show("Non è stato selezionato alcun dettaglio.");
				return false;
			}

			return true;
		}

		bool customChangeTab(int oldTab, int newTab) {
			if ((oldTab == 0) && (newTab == 1)) return ScegliDocs();
			if ((oldTab == 1) && (newTab == 2)) return true;
			return true;
		}
		private void btnBack_Click(object sender, EventArgs e) {
			standardChangeTab(-1);
		}

		private void btnNext_Click(object sender, EventArgs e) {
			standardChangeTab(+1);
		}

		private void btnCancel_Click(object sender, EventArgs e) {

		}

		private void gridDettagliFatturaMadre_Paint(object sender, PaintEventArgs e) {
			if (string.IsNullOrEmpty(gridDettagliFatturaMadre.DataMember)) return;
			if (InsidePaint) return;
			InsidePaint = true;
			int i;

			string TableName = gridDettagliFatturaMadre.DataMember;
			DataSet MyDS = (DataSet)gridDettagliFatturaMadre.DataSource;
			DataTable MyTable = MyDS.Tables[TableName];

			int numrighetemp = MyTable.Rows.Count;
			DataRow gridrow = null;

			// Contiene le righe selezionate RowSelectedbk, lo fa solo una volta
			if (SelectedRowsbk == null)
				SelectedRowsbk = new DataRow[numrighetemp];

			for (i = 0; i < numrighetemp; i++) {
				if (gridDettagliFatturaMadre.IsSelected(i)) {
					gridrow = GetGridRow(gridDettagliFatturaMadre, i);
					if (alreadyselected(gridrow, SelectedRowsbk)) continue;
					//SelectGridRowsIdemGroup(gridrow, gridDettagli, true);
				}
				if (!(gridDettagliFatturaMadre.IsSelected(i))) {
					gridrow = GetGridRow(gridDettagliFatturaMadre, i);
					if (!(alreadyselected(gridrow, SelectedRowsbk))) continue;
					//deve de-selezionare ciò che era selezionato
					//SelectGridRowsIdemGroup(gridrow, gridDettagli, false);
				}
			}

			SelectedRowsbk = GetGridSelectedRows(gridDettagliFatturaMadre);
			InsidePaint = false;
		}
	}
}
