
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


using emistiParser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csa_import_default {
    public partial class FrmViewEmistiErrors : Form {
        public FrmViewEmistiErrors(IEnumerable<ParseError> errors) {
            InitializeComponent();

            DataTable dtErrors = new DataTable();
            dtErrors.Columns.Add("# Riga", typeof(string));
            dtErrors.Columns.Add("Tipo Record", typeof(string));
            dtErrors.Columns.Add("Errore", typeof(string));
            dtErrors.Columns.Add("Contenuto Riga", typeof(string));

            foreach (var error in errors) {
                DataRow row = dtErrors.NewRow();
                row["# Riga"] = error.LineNumber;
                row["Tipo Record"] = error.RecordType.ToString();
                row["Errore"] = error.Message;
                row["Contenuto Riga"] = error.Line.ToString();
                dtErrors.Rows.Add(row);
            }

            dgvEmistiErrors.DataSource = dtErrors;
        }

        private void btnOk_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
