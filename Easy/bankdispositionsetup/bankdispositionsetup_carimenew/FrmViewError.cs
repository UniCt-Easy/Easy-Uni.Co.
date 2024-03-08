
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
using System.Text;
using System.Windows.Forms;
using funzioni_configurazione;
using metadatalibrary;
using System.IO;

namespace bankdispositionsetup_carimenew {
    public partial class FrmViewError : MetaDataForm {
        DataSet DS;
        public FrmViewError(DataSet DS) {
            InitializeComponent();
            this.DS = DS;
            DataTable T = DS.Tables[0];
            btnSave.Enabled = (T.Rows.Count > 0);
            T.Columns[0].Caption = "Errore";
            HelpForm.SetDataGrid(gridCheck, T);
        }

        private void btnSave_Click(object sender, EventArgs e) {
            SaveFileDialog _sf = new SaveFileDialog();
            ISaveFileDialog sf = createSaveFileDialog(_sf);
            sf.Title = "Selezionare il file in cui verranno memorizzati " +
                "gli errori";
            if (sf.ShowDialog() != DialogResult.OK) return;
            string fullname = sf.FileName;
            txtSave.Text = fullname;
            try {
                StreamWriter sw = new StreamWriter(fullname, false, System.Text.Encoding.Default);
                DataTable T = GetGridTable();
                foreach (DataRow R in T.Rows) {
                    sw.WriteLine(R[0].ToString());
                }
                sw.Close();
            }
            catch { }
        }

        private DataTable GetGridTable() {
            return ((DataSet)gridCheck.DataSource).Tables[gridCheck.DataMember];
        }

        private void btnOK_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
