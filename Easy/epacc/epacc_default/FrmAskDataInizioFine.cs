
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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


using metadatalibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace epacc_default {
	public partial class FrmAskDataInizioFine :Form {
		public FrmAskDataInizioFine(bool x) {
			InitializeComponent();
			HelpForm.ExtLeaveDateTimeTextBox(txtDataInizio, null);
			HelpForm.ExtLeaveDateTimeTextBox(txtDataFine, null);
		}

		private void txtDataInizio_Leave(object sender, EventArgs e) {
			HelpForm.ExtLeaveDateTimeTextBox(txtDataInizio, null);
		}

		private void txtDataFine_Leave(object sender, EventArgs e) {
			HelpForm.ExtLeaveDateTimeTextBox(txtDataFine, null);
		}

		public bool DatiValidi() {
			try {
				DateTime TT = (DateTime) HelpForm.GetObjectFromString(typeof(DateTime),
					txtDataInizio.Text.ToString(), "x.y");
			}
			catch {
				MetaFactory.factory.getSingleton<IMessageShower>().Show("E' necessario inserire una data inizio valida");
				txtDataInizio.Focus();
				return false;
			}
			try {
				DateTime TT = (DateTime) HelpForm.GetObjectFromString(typeof(DateTime),
					txtDataInizio.Text.ToString(), "x.y");
			}
			catch {
				MetaFactory.factory.getSingleton<IMessageShower>().Show("E' necessario inserire una data fine valida");
				txtDataInizio.Focus();
				return false;
			}

			return true;
		}

		private void btnOk_Click(object sender, EventArgs e) {
			if (!DatiValidi()) return;
			DialogResult = DialogResult.OK;
		}
	}
}
