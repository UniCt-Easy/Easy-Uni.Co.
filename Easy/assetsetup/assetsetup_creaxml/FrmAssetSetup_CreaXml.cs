/*
    Easy
    Copyright (C) 2020 Universit√† degli Studi di Catania (www.unict.it)
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
using System.IO;
using System.Collections;

namespace assetsetup_creaxml {
    public partial class FrmAssetSetup_CreaXml : Form {
        MetaData Meta;
        public FrmAssetSetup_CreaXml() {
            InitializeComponent();
        }

        private void btnFile_Click(object sender, EventArgs e) {
            DialogResult dr = saveFileDialog1.ShowDialog();
            if (dr != DialogResult.OK) {
                MessageBox.Show(this, "File non selezionato");
                return;
            }
            txtFile.Text = saveFileDialog1.FileName;
        }

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
        }

        private void btnGeneraXml_Click(object sender, EventArgs e) {
            if (saveFileDialog1.FileName == "") {
                MessageBox.Show(this, "File nel quale verr‡ salvato lo schema XML non selezionato, processo interrotto", "Errore");
                return;
            }
            if (!datiEstrapolati()) {
                MessageBox.Show(this, "Errore nell'estrazione dei dati, il file XML non verr‡ generato", "Errore");
                return;
            }
            salvaFile();
        }

        DataSet dsEsporta = new DataSet();
        private bool datiEstrapolati() {
            string [] tabelle = new string [] {"inventory", "inventorykind", "inventoryagency", "config",
            "assetloadkind", "assetunloadkind", "assetloadmotive", "assetunloadmotive", "inventoryamortization", 
            "assetusagekind"};
            foreach(string tName in tabelle) {
                string filter = null;
                if (tName == "inventoryamortization") {
                    filter = "(flag & 2 <> 0)";
                }

                string fieldList = "*";
                if (tName == "config") {
                    fieldList = "ayear, assetload_flag, asset_flagnumbering, asset_flagrestart, ct, cu, lt, lu";
                }
                DataTable t = DataAccess.CreateTableByName(Meta.Conn, tName, fieldList);
                DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, t, null, filter, null, true);
                if (t == null) {
                    MessageBox.Show(this, "Errore nell'estrazione dei dati della tabella " + tName, "Errore");
                    return false;
                }
                t.TableName = tName;
                dsEsporta.Tables.Add(t);
            }
            return true;
        }

        private void salvaFile() {
            string fileName = saveFileDialog1.FileName;
            try {
                FileStream fs = new FileStream(fileName, FileMode.Create);
                dsEsporta.WriteXml(fs, XmlWriteMode.WriteSchema);
                fs.Close();
            }
            catch (Exception ex) {
                MessageBox.Show(this, "Impossibile generare il file\n" + ex.Message);
                return;
            }
            MessageBox.Show(this, "File generato correttamente. Il percorso dove trovare il file Ë: " + fileName);
            azzeraDataSet();
            dsEsporta.Clear();
        }

        private void azzeraDataSet() {
            dsEsporta.Clear();

            ArrayList A = new ArrayList(10);
            foreach (DataTable t in dsEsporta.Tables) {
                A.Add(t);
            }
            foreach (DataTable t in A) {
                dsEsporta.Tables.Remove(t);
            }
            dsEsporta.AcceptChanges();
        }
    }
}