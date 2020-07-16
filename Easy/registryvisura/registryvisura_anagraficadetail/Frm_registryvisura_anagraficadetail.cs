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

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using metadatalibrary;
using funzioni_configurazione;

namespace registryvisura_anagraficadetail {
    public partial class Frm_registryvisura_anagraficadetail :Form {
        public Frm_registryvisura_anagraficadetail() {
            InitializeComponent();
        }
        private MetaData Meta;
        CQueryHelper QHC;
        QueryHelper QHS;

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
        }
        public void MetaData_AfterClear() {
            AbilitaDisabilitaAllegati();
        }

        public void MetaData_AfterFill() {
            AbilitaDisabilitaAllegati();
        }
        void AbilitaDisabilitaAllegati() {
            labDurcFileName.Text = "";
            if (Meta.IsEmpty) {
                btnAllegaVisura.Enabled = false;
                btnVisualizzaVisura.Enabled = false;
                btnRimuoviVisura.Enabled = false;

                return;
            }
            DataRow Curr = DS.registryvisura.Rows[0];

            if (Curr["visuracertification"] != DBNull.Value) {
                btnAllegaVisura.Enabled = false;
                btnVisualizzaVisura.Enabled = true;
                btnRimuoviVisura.Enabled = true;
                byte[] B = (byte[])Curr["visuracertification"];
                labDurcFileName.Text = GetFileName(B);
            }
            else {
                btnAllegaVisura.Enabled = true;
                btnVisualizzaVisura.Enabled = false;
                btnRimuoviVisura.Enabled = false;
            }
        }
        void SetBytesForFileName(string S, byte[] B) {
            string fname = Path.GetFileName(S);
            byte[] b = Encoding.Default.GetBytes(fname);
            for (int i = 0; i < b.Length; i++) B[i] = b[i];
            B[b.Length] = 0;
        }
        int LengthForFileName(string S) {
            string fname = Path.GetFileName(S);
            return fname.Length + 1;
        }
        int GetOffsetForData(Byte[] B) {
            int i = 0;
            while (i < B.Length && B[i] != 0) i++;
            return i + 1;
        }
        string GetFileName(Byte[] B) {
            int len = 0;
            for (int i = 0; i < B.Length; i++) {
                len++;
                if (B[i] == 0) break;
            }
            byte[] b = new byte[len - 1];
            for (int i = 0; i < len - 1; i++) {
                b[i] = B[i];
            }
            return Encoding.Default.GetString(b);
        }


        void SalvaAllegato(string certification) {
            // Legge il file indicato dall'utente e lo scrive nel DB in 'durccertification' o in 'selfcertification'
            if (Meta.IsEmpty) return;
            if (!Meta.GetFormData(true)) return;
            DialogResult dialogResult = opendlg.ShowDialog(this);
            if (dialogResult == DialogResult.Cancel) return;
            DataRow Curr = HelpForm.GetLastSelected(DS.registryvisura);
            if (Curr == null) return;
            FileStream FS = new FileStream(opendlg.FileName, FileMode.Open, FileAccess.Read);
            string estensione = Path.GetExtension(FS.Name);
            if (FS == null) return;
            int n = (int)FS.Length;
            if (n == 0) return;
            int namelen = LengthForFileName(opendlg.FileName);

            try {
                byte[] ByteArray = new byte[n + namelen];
                FS.Read(ByteArray, namelen, n);
                if (FS.Length == 0) {
                    Curr[certification] = DBNull.Value;
                }
                FS.Close();
                SetBytesForFileName(opendlg.FileName, ByteArray);
                Curr[certification] = ByteArray;
            }
            catch { }
            AbilitaDisabilitaAllegati();
        }

        private void VisualizzaAllegato(string certification) {
            if (Meta.IsEmpty) return;
            string FilePath = AppDomain.CurrentDomain.BaseDirectory;
            string prefix = "SWMOREVISU";
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

            DataRow Curr = DS.registryvisura.Rows[0];

            byte[] ByteArray = (byte[])Curr[certification];
            int offset = GetOffsetForData(ByteArray);
            string fname = GetFileName(ByteArray);
            string estensione = Path.GetExtension(fname).Trim(); ;

            string sw = Path.Combine(FilePath, prefix + oggi.ToString() + estensione);
            try {
                ScriviFile(sw, ByteArray, offset);

                System.Diagnostics.Process.Start(sw);
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

        private void btnAllegaDurc_Click(object sender, EventArgs e) {
            SalvaAllegato("visuracertification");
        }

        private void btnVisualizzaDurc_Click(object sender, EventArgs e) {
            VisualizzaAllegato("visuracertification");
        }

        private void btnRimuoviDurc_Click(object sender, EventArgs e) {
            DS.registryvisura.Rows[0]["visuracertification"] = DBNull.Value;
            AbilitaDisabilitaAllegati();
        }

        private void txtDataIniziovalidita_Leave(object sender, EventArgs e) {
            if (!Meta.DrawStateIsDone) return;

            if (txtDataIniziovalidita.Text == "") {
                return;
            }
            else {
                //forza l'immissione di una data valida
                DateTime datainiziovalidita;
                try {
                    datainiziovalidita = Convert.ToDateTime(txtDataIniziovalidita.Text);
                }
                catch {
                    MessageBox.Show("La data inserita non era valida");
                    txtDataIniziovalidita.SelectAll();
                    txtDataIniziovalidita.Focus();
                    return;
                }
            }
        }
    }
}
