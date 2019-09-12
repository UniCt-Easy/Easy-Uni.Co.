/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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

ï»¿using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

namespace flussocrediti_default {
    partial class FrmErrori : Form {
        private FrmErrori(List<string> errori) {
            InitializeComponent();

            StringBuilder sb = new StringBuilder();
            foreach (var errore in errori) {
                sb.AppendLine(errore);                
            }
            txtErrori.Text = sb.ToString();
        }

        public static void MostraErrori(IWin32Window owner, List<string> errori) {
            var newForm = new FrmErrori(errori);

            newForm.ShowDialog(owner);
        }
    }
}
