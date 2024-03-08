
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
using metadatalibrary;
using metaeasylibrary;
using System.IO;
using funzioni_configurazione;

namespace mandateattachment_default {
    public partial class FrmMandateAttachment : MetaDataForm {
        MetaData Meta;
        public IOpenFileDialog openFileDialog1;

        public FrmMandateAttachment() {
            InitializeComponent();
            openFileDialog1 = createOpenFileDialog(_openFileDialog1);
            
        }
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
        }
        private void btnAllega_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            DataRow Curr = DS.mandateattachment.Rows[0];
            openFileDialog1.Title = "Seleziona l'allegato";
            try {
                if (openFileDialog1.ShowDialog(this) != DialogResult.OK) return;
            }
            catch (Exception E) {
                QueryCreator.ShowException(E);
                return;
            }

            string estensione = Path.GetExtension(openFileDialog1.FileName);

			if (CfgFn.ExtensionDenied(estensione)) {
				show("Impossibile caricare questo tipo di file");
				return;
			}

            FileStream FS;
            try {
                FS = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
            }
            catch (Exception E) {
                QueryCreator.ShowException("Errore nell'apertura del file " + openFileDialog1.FileName, E);
                return;
            }
            
            int n = (int)FS.Length;
            if (n == 0) {
                Curr["attachment"] = DBNull.Value;
                return;
            }
            byte[] ByteArray = new byte[n ];
            FS.Read(ByteArray, 0, n);
            if (FS.Length == 0) {
                Curr["attachment"] = DBNull.Value;
            }
            FS.Close();
            Curr["attachment"] = ByteArray;
            string fname= Path.GetFileName(openFileDialog1.FileName);
            labAutocertFileName.Text = fname;
            Curr["filename"] = fname;
        }
        public void MetaData_AfterFill() {
            DataRow R = DS.mandateattachment.Rows[0];
            btnVisualizza.Visible = true;
            if (R["attachment"] == DBNull.Value) {
                btnVisualizza.Visible = false;
            }

        }
        private void btnVisualizza_Click(object sender, EventArgs e) {
            string FilePath = AppDomain.CurrentDomain.BaseDirectory;
            string prefix = "SWATTACHMENT";
            string filenametodelete = FilePath + prefix + "*.*";
            string[] existingreports = System.IO.Directory.GetFiles(FilePath, prefix + "*.*");
            foreach (string filename in existingreports) {
                try {
                    System.IO.File.Delete(filename);
                }
                catch { }
            }

            //sw è il nome del file temporaneo che hai creato
            DateTime oggi_dt = DateTime.Now;
            string oggi = oggi_dt.Ticks.ToString();
            DataRow Curr = DS.mandateattachment.Rows[0];
            if (Curr["attachment"] == DBNull.Value) return;

            byte[] ByteArray = (byte[])Curr["attachment"];
            int offset = 0;
            string fname = Curr["filename"].ToString();
            string estensione = Path.GetExtension(fname).Trim();

            bool extensionDenied = CfgFn.ExtensionDenied(estensione);

			if (extensionDenied) {
				show("Impossibile aprire questo tipo di file");
				return;
			}
			if (!CfgFn.ExtensionAllowed(estensione)) {
				DialogResult dr = show("Si sta aprendo un file con estensione " + estensione +".  Sei sicuro di voler aprire questo file?", "Attenzione!", MessageBoxButtons.YesNo);
				if (dr == DialogResult.No) 
					return;
			}

            string sw = Path.Combine(FilePath, prefix + oggi.ToString() + estensione);
            try {
                ScriviFile(sw, ByteArray, offset);
                runProcess(sw,true);
            }
            catch (Exception E) {
                QueryCreator.ShowException(E);
            }
        }

        void ScriviFile(string sw, byte[] documento, int offset) {
            // Legge il documento memorizzato nel DB e lo scrive nel file temp.
            if (Meta.IsEmpty) return;
            if (!Meta.GetFormData(true)) return;

            FileStream FS = new FileStream(sw, FileMode.Create, FileAccess.Write);

            int n = documento.Length - offset;
            if (n == 0) return;
            try {
                FS.Write(documento, offset, n);//<<<<<<<<<
                FS.Flush();
                FS.Close();
            }
            catch { }
        }

    }
}
