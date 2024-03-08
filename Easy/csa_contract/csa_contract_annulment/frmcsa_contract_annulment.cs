
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
using metaeasylibrary;
using funzioni_configurazione;
using q= metadatalibrary.MetaExpression;
using System.Collections;
using csa_import_default;

namespace csa_contract_annulment {
	public partial class frmcsa_contract_annulment : MetaDataForm {
		MetaData Meta;
		DataAccess Conn;
		CQueryHelper QHC = new CQueryHelper();
		QueryHelper QHS;
		EntityDispatcher Dispatcher;
		int esercizio;
		private DataTable OutTable;
		private DataTable SP_Result;

		public IOpenFileDialog openInputFileDlg;

		public frmcsa_contract_annulment() {
			InitializeComponent();
			openInputFileDlg = createOpenFileDialog(_openInputFileDlg);
		}
	 
		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
			Dispatcher = Meta.Dispatcher as EntityDispatcher;
			Conn = Meta.Conn;
			esercizio = Conn.GetEsercizio();
			QHS = Conn.GetQueryHelper();
			//bool isAdmin = (bool)Meta.GetSys("IsSystemAdmin");
			
			string contractfilter = QHS.AppAnd(QHS.NullOrEq("active", "S"),  
				QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
			Meta.SearchEnabled = false;
			Meta.canInsert = false;
			chkKeepAlive.Checked = true;
			GetElencoContrattiCSA();
		}





		private void btnCancel_Click(object sender, System.EventArgs e) {
			DS.AcceptChanges();
			Close();
		}


		/// <summary>
		/// Displays tab n. NewTab and updates buttons
		/// </summary>
		/// <param name="newTab"></param>


		void ResetWizard() {
			DS.Clear();
			dgrRegoleSpecifiche.DataSource = null;
			GetElencoContrattiCSA();
		}



		private void FormatDataGrid(DataGrid dgr, DataTable tResult) {
			HelpForm.SetGridStyle(dgr, tResult);
			metadatalibrary.formatgrids fg = new formatgrids(dgr);
			fg.AutosizeColumnWidth();
		}
 
		private void ImpostaCaption(DataTable T) {
			foreach (DataColumn C in T.Columns)
				MetaData.DescribeAColumn(T, C.ColumnName, "", -1);

			int nPos = 0;
			if (T.TableName == "Regole") {
				MetaData.DescribeAColumn(T, "idcsa_contract", ".idcsa_contract", nPos++);
				MetaData.DescribeAColumn(T, "ayear", "Cfg.", nPos++);
				MetaData.DescribeAColumn(T, "csa_contractkindcode", "#Reg. gen.", nPos++);
				MetaData.DescribeAColumn(T, "csa_contractkind", "Reg. gen.", nPos++);
				MetaData.DescribeAColumn(T, "ycontract", "Eserc. Regola", nPos++);
				MetaData.DescribeAColumn(T, "ncontract", "Numero Regola", nPos++);
				MetaData.DescribeAColumn(T, "csa_contractkindflagcr", "C/R", nPos++);
				MetaData.DescribeAColumn(T, "title", "Descrizione", nPos++);
				MetaData.DescribeAColumn(T, "active", "Attivo", nPos++);
		 
			}
			 
		}
		private int getIntSys(string nome)
		{
			int s = CfgFn.GetNoNullInt32(Meta.GetSys(nome));
			if (s == 0) return 99;
			return s;
		}

		private bool GetElencoContrattiCSA() {
			DataSet DataSource = new DataSet();
			string filterOperation = (chkKeepAlive.Checked) ? QHS.NullOrEq("active", "S") : QHS.CmpEq("active", "N");
			dgrRegoleSpecifiche.DataSource = null;
			string filter = QHS.AppAnd(filterOperation,
				QHS.CmpEq("ayear", getIntSys("esercizio")));

			 
			DataTable RegoleSpecifiche = Meta.Conn.RUN_SELECT("csa_contractview", " idcsa_contract, ayear," +
				" csa_contractkindcode, csa_contractkind, ycontract, ncontract, csa_contractkindflagcr," +
				" title, active ", " csa_contractkindcode,ycontract, ncontract ",filter,null, false) ;

			if (RegoleSpecifiche != null) {
				RegoleSpecifiche.TableName = "Regole";
				ImpostaCaption(RegoleSpecifiche);
				DataSource.Tables.Add(RegoleSpecifiche);
				FormatDataGrid(dgrRegoleSpecifiche, RegoleSpecifiche);
				HelpForm.SetDataGrid(dgrRegoleSpecifiche, RegoleSpecifiche);
				HelpForm.SetAllowMultiSelection(RegoleSpecifiche, true);
			}


			if (RegoleSpecifiche.Rows.Count > 0) {
				for (int i = 0; i < RegoleSpecifiche.Rows.Count; i++) {
					dgrRegoleSpecifiche.UnSelect(i); // seleziona tutto
				}
			}

			Meta.FreshForm();
			return true;
		}

	 
		 

		/// <summary>
		/// Legge "Non associare a sospeso in Elaborazione Versamenti"
		/// </summary>
		/// <returns></returns>
		 
	   bool doSave() {
			return true;
		}


		DataRow GetGridRow(DataGrid G, int index) {
			string TableName = G.DataMember.ToString();
			DataSet MyDS = (DataSet) G.DataSource;
			DataTable MyTable = MyDS.Tables[TableName];
			string filter = "";
			string nomecampo = "idcsa_contract";
			if (G.Name == "dgrRegoleSpecifiche") nomecampo = "idcsa_contract";
			filter = QHC.CmpEq(nomecampo, G[index, 0]);
			DataRow[] selectresult = MyTable.Select(filter);
			return (selectresult.Length > 0) ? selectresult[0] : null;
		}

		private DataRow[] GetGridSelectedRows(DataGrid G) {
			if (G.DataMember == null) return null;
			if (G.DataSource == null) return null;
			string TableName = G.DataMember.ToString();
			DataSet MyDS = (DataSet) G.DataSource;
			DataTable MyTable = MyDS.Tables[TableName];
			int numrighetemp = MyTable.Rows.Count;
			int numrighe = 0;
			int i;
			for (i = 0; i < numrighetemp; i++) {
				if (G.IsSelected(i)) {
					DataRow R = GetGridRow(G, i);
					if (R == null) continue;
					numrighe++;
				}
			}

			DataRow[] Res = new DataRow[numrighe];
			int count = 0;
			for (i = 0; i < numrighetemp; i++) {
				if (G.IsSelected(i)) {
					DataRow R = GetGridRow(G, i);
					if (R == null) continue;
					Res[count++] = R;
				}
			}

			return Res;
		}

		private void dgrVersamentiAnnuali_MouseUp(object sender, MouseEventArgs e) {
			//Impedisce la multiselezione col mouse
			HelpForm.HelpForm_MouseUp(sender, e);
		}

		private void dgrVersamentiAnnuali_KeyUp(object sender, KeyEventArgs e) {
			//Impedisce la multiselezione da tastiera
			HelpForm.HelpForm_KeyUp(sender, e);
		}

		private bool alreadyselected(DataRow curr_rowgrid, DataRow[] RrowSelected) {
			foreach (DataRow R in RrowSelected)
				if (R == curr_rowgrid)
					return true;
			return false;

		}



		private bool executing = false;
		private void btnElabora_Click(object sender, EventArgs e)
		{
			if (executing) return;
			DS.csa_contract.Clear();
			executing = true;
			//sia entrate che spese
			string message = "";
	
			DataRow[] RegoleSelected = GetGridSelectedRows(dgrRegoleSpecifiche);
			if (RegoleSelected.Length == 0)
			{
				show("E' necessario selezionare una Regola Specifica");
				executing = false;
				return;
			}
			if (chkKeepAlive.Checked)
			{
				message = "Si è scelto di disattivare tutte le Regole Selezionate?";
			}
			else
			{
				message = "Si è scelto di riattivare tutte le Regole Selezionate?";
			}
			if (show(this, message,
					"Conferma", MessageBoxButtons.YesNo) == DialogResult.No)
			{
				executing = false;
				return;
			}
			else
			{

				string list = QHC.DistinctVal(RegoleSelected, "idcsa_contract");
				string filter = QHC.AppAnd(QHC.CmpEq("ayear", getIntSys("esercizio")),
					QHC.FieldInList("idcsa_contract", list));

				if (DS.csa_contract.Rows.Count == 0)
				{
					DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.csa_contract,
						null, filter, null, true);
 
					foreach (DataRow r in DS.csa_contract.Rows)
					{
						if (chkKeepAlive.Checked)
						{
							r["active"] = "N";
							message = "Disattivazione delle Regole avvenuta con successo";
						}
						else
						{
							r["active"] = "S";
							message = "Riattivazione delle Regole avvenuta con successo";
						}
					}
					Easy_PostData MyPostData = new Easy_PostData();
					MyPostData.InitClass(DS, Meta.Conn);
					bool res = MyPostData.DO_POST();
					if (res)
					{
						show(this, message);
						DS.csa_contract.AcceptChanges();
					}
					else
					{
						show(this, "Si è verificato un errore, le Regole non sono state disattivate");
					}
				}

				executing = false;
				GetElencoContrattiCSA();
				return;
			}
		 
		}

		private void chkKeepAlive_CheckedChanged(object sender, EventArgs e)
		{
			if (chkKeepAlive.Checked) chkKeepAlive.Text = "Disattivazione Regole";
			else
				chkKeepAlive.Text = "Riattivazione Regole";
			if (Meta.DrawStateIsDone)
				GetElencoContrattiCSA();
		}
	}

}
