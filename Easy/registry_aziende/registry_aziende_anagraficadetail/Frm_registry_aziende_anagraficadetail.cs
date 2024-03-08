
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
using System.IO;

namespace registry_aziende_anagraficadetail {
	public partial class Frm_registry_aziende_anagraficadetail : MetaDataForm {
		MetaData Meta;
		public Frm_registry_aziende_anagraficadetail() {
			InitializeComponent();
		}
		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
			disableAll();

		}
		public void MetaData_AfterFill() {
			if (DS.registry_aziende.Rows[0]["idnumerodip"] == DBNull.Value) {
				if ((cmbDip.SelectedIndex > 0) || (cmbDip.SelectedIndex == 0) ){
					cmbDip.SelectedIndex = -1;
				}
			}

		}
		public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
			if (!Meta.DrawStateIsDone) return;
			if (Meta.IsEmpty) return;
		}
		public void disableAll() {
			grpNace.Enabled = false;
			gboxAteco.Enabled = false;
			cmbDip.Enabled = false;
			cmbNaturagiu.Enabled = false;
		}

		private void label1_Click(object sender, EventArgs e) {

		}
	}
}
