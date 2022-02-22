
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using metadatalibrary;
using System.Globalization;
using funzioni_configurazione;
using q = metadatalibrary.MetaExpression;
using ep_functions;

namespace mandate_default {
	public partial class FrmAnnullaDettaglio : MetaDataForm {

		MetaDataDispatcher Disp;
		DataTable upb;
		DataAccess Conn;
		private QueryHelper QHS;
		private CQueryHelper QHC;
		public DataTable Info;
		private DataRow Dettaglio;
		private DataRow rContratto;

		public object SelectedCasualeAnn;

		public FrmAnnullaDettaglio(DataRow Contratto, DataRow RigaSelezionata, MetaData Meta, MetaDataDispatcher Disp) {
			InitializeComponent();
			this.Disp = Disp;
			this.Conn = Meta.Conn;
			QHC = new CQueryHelper();
			QHS = Conn.GetQueryHelper();
			this.Dettaglio = RigaSelezionata;
			this.rContratto = Contratto;

			int yestim = CfgFn.GetNoNullInt32(rContratto["yman"]);
			var rFirst = EP_Manager.getFirstRow(RigaSelezionata);
			if (rFirst["start"] != DBNull.Value) {
				yestim = ((DateTime) rFirst["start"]).Year;
			}

			if (yestim >= Conn.GetEsercizio()) {
				gBoxCausale.Visible = false;
			}
			else {
				SelectedCasualeAnn = RigaSelezionata["idaccmotive"];
				if (SelectedCasualeAnn != DBNull.Value) {
					var t = Conn.readTable("accmotive", q.eq("idaccmotive", SelectedCasualeAnn));
					var accmot = t.Rows[0];
					txtCausaleAnnullo.Text = accmot["codemotive"].ToString();
				}
			}

			txtStop.Leave += TxtStopOnLeave;
		}

		private void TxtStopOnLeave(object sender, EventArgs e) {
			HelpForm.ExtLeaveDateTimeTextBox(txtStop, "x.y");
		}

		private void btnCausaleAnnullamento_Click(object sender, EventArgs e) {
			string filter = QHS.CmpEq("active", "S");
			MetaData MetaAccmotiveannulment = Disp.Get("accmotiveapplied");
			MetaAccmotiveannulment.FilterLocked = true;
			MetaAccmotiveannulment.SearchEnabled = false;
			MetaAccmotiveannulment.MainSelectionEnabled = true;
			MetaAccmotiveannulment.StartFilter = filter;
			string filterEpAnnullOperation = QHS.CmpEq("idepoperation", "fatven");
			MetaAccmotiveannulment.ExtraParameter = QHS.AppAnd(filter, filterEpAnnullOperation);
			string edittype;
			edittype = "tree";

			bool res = MetaAccmotiveannulment.Edit(this, edittype, true);
			if (!res) return;
			SelectedCasualeAnn = MetaAccmotiveannulment.LastSelectedRow?["idaccmotive"];
			riempiTextBox(MetaAccmotiveannulment.LastSelectedRow);
		}

		private void riempiTextBox(DataRow AccmotiveRow) {
			txtCausaleAnnullo.Text = (AccmotiveRow != null) ? AccmotiveRow["codemotive"].ToString() : "";
		}

		private void btnOK_Click(object sender, EventArgs e) {
			int yman = CfgFn.GetNoNullInt32(rContratto["yman"]);
			if (txtStop.Text == "") {
				show(this, "Inserire la data di annullamento del dettaglio");
				this.DialogResult = DialogResult.None;
				return;
			}


			object date = HelpForm.GetObjectFromString(typeof(DateTime), txtStop.Text, "x.y.g");
			if (date == null) {
				show(this, "Inserire la data di annullamento del dettaglio");
				this.DialogResult = DialogResult.None;
				return;
			}

			if (((DateTime) date).Year != Conn.GetEsercizio()) {
				show(this,
					"La data di annullamento deve essere dell'esercizio corrente.");
				this.DialogResult = DialogResult.None;
				return;
			}

			if (((DateTime) date).Year < yman) {
				show(this,
					"La data di annullamento deve essere successiva all'anno di creazione del contratto");
				this.DialogResult = DialogResult.None;
				return;
			}

		}

		private void GestisceTextUpb(TextBox txtCausaleAnnullo) {
			if (txtCausaleAnnullo.Text.Trim() == "") {
				SelectedCasualeAnn = null;
				riempiTextBox(null);
				return;
			}

			MetaData MetaAccmotiveannulment = Disp.Get("accmotiveapplied");

			MetaAccmotiveannulment.FilterLocked = true;
			MetaAccmotiveannulment.SearchEnabled = false;
			MetaAccmotiveannulment.MainSelectionEnabled = true;
			MetaAccmotiveannulment.StartFilter = null;
			MetaAccmotiveannulment.startFieldWanted = "codemotive";
			MetaAccmotiveannulment.startValueWanted = null;

			MetaAccmotiveannulment.startValueWanted = txtCausaleAnnullo.Text.Trim();
			string startfield = MetaAccmotiveannulment.startFieldWanted;
			string startvalue = MetaAccmotiveannulment.startValueWanted;
			DataRow selRow=null;
			SelectedCasualeAnn = null;
			if (startvalue != null) {
				//try to load a row directly, without opening a new form		
				string stripped = startvalue;
				if (stripped.EndsWith("%")) stripped = stripped.TrimEnd(new Char[] {'%'});
				string filter = "(" + startfield + "='" + stripped + "')";
				string filterEpAnnullOperation = QHS.CmpEq("idepoperation", "fatacq");
				filter = QHS.AppAnd(filter, filterEpAnnullOperation);
				SelectedCasualeAnn = MetaAccmotiveannulment.SelectByCondition(filter, "accmotive");
			}

			if (selRow == null) {
				string filter = "(codemotive like " + QueryCreator.quotedstrvalue(txtCausaleAnnullo.Text + "%", true) +
				                ")";
				string filterEpAnnullOperation = QHS.CmpEq("idepoperation", "fatacq");
				filter = QHS.AppAnd(filter, filterEpAnnullOperation);
				MetaAccmotiveannulment.FilterLocked = true;
				selRow= MetaAccmotiveannulment.SelectOne("default", filter, "accmotiveapplied", null);
				if (selRow == null) {
					riempiTextBox(null);
					return;
					}
				SelectedCasualeAnn = selRow["idaccmotive"];
				riempiTextBox(selRow);
				return;
			}

			riempiTextBox(selRow);
		}


		private void txtCausaleAnnullo_Leave(object sender, EventArgs e) {
			if (!txtCausaleAnnullo.Modified) return;
			GestisceTextUpb(txtCausaleAnnullo);
		}
	}
}
