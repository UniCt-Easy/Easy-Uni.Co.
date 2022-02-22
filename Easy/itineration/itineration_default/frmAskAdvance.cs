
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
using metadatalibrary;
using System.Windows.Forms;

namespace itineration_default {
    public partial class frmAskAdvance : MetaDataForm {
        public object importo;
        public frmAskAdvance (int dummy) {
            InitializeComponent();
        }

      
        private void txtAnticipo_Leave (object sender, EventArgs e) {
            decimal valore;
            HelpForm.ExtLeaveDecTextBox(txtAnticipo, "x.y");
            string strvalore = txtAnticipo.Text.Trim();
            if (strvalore == "") {
                importo = 0;
                return;
            }
            try {
                valore = (decimal)HelpForm.GetObjectFromString(
                    typeof(decimal), txtAnticipo.Text
                    , "x.y");
                txtAnticipo.Text = valore.ToString("c");
                if ((valore < 0)) {
                    show("L'importo non può essere negativo");
                    txtAnticipo.Focus();
                    return;
                }
                importo = valore;
            }
            catch {
                show("E' necessario inserire un importo valido");
                txtAnticipo.Focus();
                importo = 0;
                return ;
            }
             
        }
    }
}
