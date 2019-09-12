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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using metadatalibrary;

namespace assetsetup_impostatransmitted {
    public partial class FrmAssetSetup_ImpostaTransmitted : Form {
        MetaData Meta;
        public FrmAssetSetup_ImpostaTransmitted() {
            InitializeComponent();
        }

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            GetData.CacheTable(DS.inventoryagency);
        }

        public void MetaData_AfterActivation() {
            if (this.Text.EndsWith("(Ricerca)")) {
                this.Text = this.Text.Replace("(Ricerca)", "");
            }
            txtEsercizioInizio.Text = Meta.GetSys("esercizio").ToString();
            txtEsercizioFine.Text = Meta.GetSys("esercizio").ToString();
        }

        public void MetaData_AfterClear() {
            if (this.Text.EndsWith("(Ricerca)")) {
                this.Text = this.Text.Replace("(Ricerca)", "");
            }
        }

        private void btnStart_Click(object sender, EventArgs e) {
            object start = HelpForm.GetObjectFromString(typeof(int), txtEsercizioInizio.Text, "x.y");
            object stop = HelpForm.GetObjectFromString(typeof(int), txtEsercizioFine.Text, "x.y");

            if ((start == null) || (start == DBNull.Value) || (stop == null) || (stop == DBNull.Value)) {
                MessageBox.Show(this, "Specificare entrambe gli esercizi sui quali si vuole impostare il flag", "Errore");
                return;
            }

            if (cmbEnte.SelectedValue == DBNull.Value) {
                MessageBox.Show(this, "Specificare l'ente inventariale", "Errore");
                return;
            }
            object ente = cmbEnte.SelectedValue;
            DataSet dsOut = DataAccess.CallSP(Meta.Conn, "compute_set_transmitted", new object[] { ente, start, stop }, true, 0);
            if ((dsOut == null) || (dsOut.Tables.Count == 0)) {
                MessageBox.Show(this, "Errore nell'esecuzione della procedura di aggiornamento del flag", "Errore");
            }
            else {
                MessageBox.Show(this, "Procedura eseguita correttamente", "Errore");
            }
        }

        private void txtEsercizioInizio_Leave(object sender, EventArgs e) {
            HelpForm.ExtLeaveIntTextBox(txtEsercizioInizio, "x.y.year");
        }

        private void txtEsercizioFine_Leave(object sender, EventArgs e) {
            HelpForm.ExtLeaveIntTextBox(txtEsercizioFine, "x.y.year");
        }

    }
}