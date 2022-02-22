
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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


using System.Collections.Generic;
using System.Windows.Forms;
using TesseraSanitaria;
using metadatalibrary;

namespace no_table_invoice_ssn {

    public partial class FrmErrori : MetaDataForm {

        public static void Show(Form parent, Dictionary<string, List<Messaggio>> messaggi) {
            var form = new FrmErrori();
            foreach (string numeroDocumento in messaggi.Keys) {
                var lista = messaggi[numeroDocumento];

                foreach (var messaggio in lista) {
                    var item = new ListViewItem(new string[] { messaggio.Codice, messaggio.Descrizione });
                    item.ImageIndex = (int)messaggio.Tipo;

                    form.listMessaggi.Items.Add(item);
                }
            }
            form.ShowDialog(parent);
        }

        public FrmErrori() {
            InitializeComponent();
        }

    }

}
