
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
using metaeasylibrary;
using itinerationFunctions;
namespace no_table_trasfdocmissione {
    public partial class Frm_trasfdocmissione : MetaDataForm {
        MetaData Meta;
        DataAccess Conn;

        IFolderBrowserDialog folderDlg;

        public Frm_trasfdocmissione() {
            InitializeComponent();
            folderDlg = createFolderBrowserDialog(_folderDlg);
        }

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            Meta.CanSave = false;
            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
            Meta.CanCancel = false;
            txtEsercizioMissione.Text = Meta.GetSys("esercizio").ToString();
        }
        private void btnSelezionaFolder_Click(object sender, EventArgs e) {
            if (folderDlg.ShowDialog(this) == DialogResult.OK) {
                txtFolder.Text = folderDlg.SelectedPath;
            }
        }

        private void btnEseguidownload_Click(object sender, EventArgs e) {
            object nstart = HelpForm.GetObjectFromString(typeof(int), txtNumInizio.Text, null);
            object nstop = HelpForm.GetObjectFromString(typeof(int), txtNumFine.Text, null);
            string pathdir = txtFolder.Text;
            object esercMissione = HelpForm.GetObjectFromString(typeof(int), txtEsercizioMissione.Text.ToString(), "x.y.year");
            string errors = "";
            MissFun.ScaricaAllegati_e_StampaMissioni(Conn, pathdir, esercMissione, nstart, nstop, out errors);
            if ((errors == null)||(errors=="")) {
                show("Operazione eseguita","Informazione",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {
                show(errors);
            }
        }
    }
}
