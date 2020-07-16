/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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
using LiveUpdate;
using metaeasylibrary;
using System.IO;

namespace inventorytree_uniforma {
    public partial class FrmInventoryTree_Uniforma : Form {
        MetaData Meta;
        string Header = "--JTR";
        public FrmInventoryTree_Uniforma() {
            InitializeComponent();
        }

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
        }

        private void btnClassSup_Click(object sender, EventArgs e) {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr != DialogResult.OK) {
                MessageBox.Show(this, "Selezionare il file");
                return;
            }
            if (!verificaValiditaFile()) return;
            eseguiScript();
        }

        private void btnUniforma_Click(object sender, EventArgs e) {
            // Selezione dello script che installa la classificazione inventariale (ex fase 3)
            openFileDialog1.FileName = "";
            DialogResult dr1 = openFileDialog1.ShowDialog();
            if (dr1 != DialogResult.OK) {
                MessageBox.Show(this, "Selezionare il file");
                return;
            }
            if (!verificaValiditaFile()) return;

            AskClassificazione frm = new AskClassificazione(Meta);
            DialogResult dr2 = frm.ShowDialog();
            if (dr2 != DialogResult.OK) {
                MessageBox.Show(this, "Non � sta scelta la classificazione, la procedura sar� interrotta");
                return;
            }

            object sk_selected = frm.cmbSortingKind.SelectedValue;
            if ((sk_selected == null) || (sk_selected == DBNull.Value)) {
                MessageBox.Show(this, "Attenzione, non � stata scelta la classificazione, la procedura sar� interrotta");
                return;
            }

            DataSet dsCheck = Meta.Conn.CallSP("uniform_inventorytree_check", new object[] { sk_selected });
            if ((dsCheck == null) || (dsCheck.Tables.Count == 0)){
                MessageBox.Show(this, "Errore nella esecuzione della SP di Check");
                return;
            }
            DataTable tCheck = dsCheck.Tables[0];
            if (tCheck.Rows.Count != 0) {
                FrmError fe = new FrmError(tCheck);
                fe.Show();
                return;
            }

            DataSet dsUniform = Meta.Conn.CallSP("uniform_inventorytree", new object[] { sk_selected });

            if (!attaccaDeleteClassSup(sk_selected.ToString())) {
                return;
            }

            if (!eseguiScript()) {
                MessageBox.Show(this, "Errore nell'esecuzione dello script che installa la classificazione inventariale", "Errore");
                return;
            }
        }

        private bool attaccaDeleteClassSup(string idsorkind) {
            if (idsorkind == "") {
                MessageBox.Show(this, "Classificazione non selezionata", "Errore");
                return false;
            }
            string filename = openFileDialog1.FileName;
            if (filename == "") {
                MessageBox.Show(this, "File non selezionato!", "Errore");
                return false;
            }

            StringBuilder SB = Download.LeggiTestoScript(filename);
            string newLine = "\n\r";
            string cancellaClass = "DELETE FROM sortingkind WHERE idsorkind = " + QueryCreator.quotedstrvalue(idsorkind, true) + newLine
                + "DELETE FROM sortinglevel WHERE idsorkind = " + QueryCreator.quotedstrvalue(idsorkind, true) + newLine
                + "DELETE FROM sortingapplicability WHERE idsorkind = " + QueryCreator.quotedstrvalue(idsorkind, true) + newLine
                + "DELETE FROM sorting WHERE idsorkind = " + QueryCreator.quotedstrvalue(idsorkind, true) + newLine
                + "DELETE FROM inventorytreesorting WHERE idsorkind = " + QueryCreator.quotedstrvalue(idsorkind, true) + newLine;

            SB.Append(cancellaClass);

            StreamWriter fsw = new StreamWriter(filename, false, Encoding.Default);
            if (fsw == null) {
                MessageBox.Show(this, "Errore nell'apertura del file" + filename, "Errore");
                return false;
            }
            fsw.Write(SB);
            fsw.Close();
            return true;
        }

        private bool verificaValiditaFile() {
            if (openFileDialog1.FileName == "") {
                MessageBox.Show(this, "File non selezionato!", "Errore");
                return false;
            }

            string filename = openFileDialog1.FileName;

            StringBuilder SB = Download.LeggiTestoScript(filename);
            if (!SB.ToString().StartsWith(Header)) {
                MessageBox.Show(this, "Il file scelto non � valido oppure lo script � stato gi� eseguito su questo dipartimento");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Metodo che esegue lo script associato alla fase
        /// </summary>
        /// <returns></returns>
        private bool eseguiScript() {
            string filename = openFileDialog1.FileName;
            if (filename == "") {
                MessageBox.Show(this, "File non selezionato!", "Errore");
                return false;
            }

            StringBuilder SB = Download.LeggiTestoScript(filename);
            if (!SB.ToString().StartsWith(Header)) {
                MessageBox.Show(this, "Il file scelto non � valido oppure lo script � stato gi� eseguito su questo dipartimento");
                return false;
            }
            else {
                SB = SB.Remove(0, Header.Length);
            }

            bool ok = Download.RUN_SCRIPT(Meta.Conn, SB, "Esecuzione script della classificazione inventariale");
            if (!ok) {
                MessageBox.Show(this, "Errore durante l'esecuzione dello script");
                return false;
            }

            StreamWriter fsw = new StreamWriter(filename, false, Encoding.Default);
            if (fsw == null) {
                MessageBox.Show(this, "Errore nell'apertura del file" + filename, "Errore");
                return false;
            }
            fsw.Write(SB);
            fsw.Close();
            MessageBox.Show(this, "Script eseguito con successo");
            return true;
        }
    }
}