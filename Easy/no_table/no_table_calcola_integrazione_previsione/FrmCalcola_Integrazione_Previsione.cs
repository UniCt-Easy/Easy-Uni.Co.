/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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
using metaeasylibrary;
using funzioni_configurazione;

namespace no_table_calcola_integrazione_previsione {
	public partial class FrmTrasfPrevisionInBudget :Form {
		MetaData Meta;
		int ayear;
		object adate;
		int esportazionekind;
		public FrmTrasfPrevisionInBudget() {
			InitializeComponent();
		}
		CQueryHelper QHC;
		QueryHelper QHS;
		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
			QHC = new CQueryHelper();
			QHS = Meta.Conn.GetQueryHelper();
			Meta.CanSave = false;
			Meta.CanInsert = false;
			Meta.CanInsertCopy = false;
			Meta.CanCancel = false;
			ayear = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
			adate = Meta.GetSys("datacontabile");
			 

		}




		private void btnTrasferisciVariazioni_Click(object sender, EventArgs e) {
			string errMsg;
			if (MessageBox.Show("Vuoi salvare una variazione non operativa?", "Conferma salvataggio",
					MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
				return;

			Meta.Conn.CallSP("calcola_integrazione_previsione", new object[] {ayear,
				adate,10/*MostraTutto*/, "N","S"}, 600, out errMsg);

			if (errMsg != null) {
				MessageBox.Show("Errore", errMsg);
			} else
				MessageBox.Show("Operazione eseguita");
			Close();
		}

		private void btnOK_Click(object sender, EventArgs e) {
				
		}

		private void btnVisualizza_Click(object sender, EventArgs e) {
			{
			 
				bool CostiAmmortamento = rdbCostiAmmortamento.Checked;
				bool RicaviRiserveExCofi = rdbRicaviRiserveExCofi.Checked;
				bool Rettifiche = rdbRettifiche.Checked;
				bool MostraTutto = rdbMostraTutto.Checked;

				esportazionekind = 10; /*Mostra Tutto*/
				//if (PrevIniziali) esportazionekind = 0;
				if (CostiAmmortamento) esportazionekind = 1;
				if (RicaviRiserveExCofi) esportazionekind = 2;
				if (Rettifiche) esportazionekind = 3;

				string errMsg;
				 
				DateTime dataDiRiferimento = (DateTime)adate;

		
				// Visualizza solo i dati senza creare variazione
				DataSet DResult = Meta.Conn.CallSP("exp_calcola_integrazione_previsione", new object[] {ayear,
				dataDiRiferimento,esportazionekind}, 600, out errMsg);

				if (DResult == null) {
					MessageBox.Show("Errore", errMsg);
				}
				DataTable TResult = DResult.Tables[0];

				dgDettaglio.DataSource = null;
				dgDettaglio.TableStyles.Clear();

				HelpForm.SetDataGrid(dgDettaglio, TResult);
				 

			}
		}
		 
	}
}