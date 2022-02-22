
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

namespace accountingyear_default {
    public partial class AskDate : MetaDataForm {
        DataAccess Conn;
        public AskDate(string title, DataAccess Conn) {
            InitializeComponent();
            this.Conn = Conn;
            CustomLabel.Text = title;
            HelpForm.ExtLeaveDateTimeTextBox(txtData, null);
        }

        private void txtData_Leave(object sender, EventArgs e) {
            HelpForm.ExtLeaveDateTimeTextBox(txtData, null);
        }

        public bool DatiValidi() {
            try {
                DateTime TT = (DateTime)HelpForm.GetObjectFromString(typeof(DateTime),
                    txtData.Text.ToString(), "x.y");
                return true;
            }
            catch {
                show("E' necessario inserire una data valida");
                txtData.Focus();
                return false;
            }

        }
        private void btnOk_Click(object sender, System.EventArgs e) {
            if (!DatiValidi()) {
                DialogResult = DialogResult.None;
                return;
            }
            DateTime TT = (DateTime)HelpForm.GetObjectFromString(typeof(DateTime),
                txtData.Text.ToString(), "x.y");
            int CurrentEsercizio = (int)Conn.GetSys("esercizio");
            if (TT.Year != CurrentEsercizio) {
                show("La data deve essere compresa nell'esercizio corrente");
                DialogResult = DialogResult.None;
                return;
            }
            DialogResult = DialogResult.OK;
        }
    }
}
