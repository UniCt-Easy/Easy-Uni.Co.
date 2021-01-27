
/*
Easy
Copyright (C) 2021 Universit� degli Studi di Catania (www.unict.it)
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using metadatalibrary;
using metaeasylibrary;
using System.Data;
using System.Windows.Forms;
using funzioni_configurazione;

namespace siope_objectcontrols {
    public class siope_helper {
        TextBox txtCodice;
        TextBox txtDenominazione;
        DataRow rSorting;
        Form F;
        public siope_helper(Form F, TextBox txtCodice, TextBox txtDenominazione, DataRow rSorting) {
            this.F = F;
            this.txtCodice = txtCodice;
            this.txtDenominazione = txtDenominazione;
            this.rSorting = rSorting;
        }
        public void ImpostaSiope() {
            if (rSorting == null) {
                //Ho cancellato la causale, azzero il siope.
                txtCodice.Text = "";
                txtDenominazione.Text = "";
                return;
            }
            else {
                txtCodice.Text = rSorting["sortcode"].ToString();
                txtDenominazione.Text = rSorting["description"].ToString();
            }
        }

    }
}
