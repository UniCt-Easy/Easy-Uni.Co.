
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
using funzioni_configurazione;
using System.IO;
using System.Diagnostics;

namespace registrydurc_default{
    public partial class Frm_registrydurc_default : Form {
        private MetaData Meta;
        CQueryHelper QHC;
        QueryHelper QHS;

        public Frm_registrydurc_default(){
            InitializeComponent();
        }
        public void MetaData_AfterLink(){
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            HelpForm.SetDenyNull(DS.registrydurc.Columns["flagirregular"], true);
        }

        public void MetaData_AfterClear(){
            AbilitaDisabilitaAllegati();
        }

        public void MetaData_AfterFill() {
            AbilitaDisabilitaAllegati();
        }

        void AbilitaDisabilitaAllegati(){
            labAutocertFileName.Text = "";
            labDurcFileName.Text = "";
            if (Meta.IsEmpty)
            {
                btnAllegaAuto.Enabled = false;
                btnVisualizzaAuto.Enabled = false;
                btnRimuoviAuto.Enabled = false;

                btnAllegaDurc.Enabled = false;
                btnVisualizzaDurc.Enabled = false;
                btnRimuoviDurc.Enabled = false;

                return;
            }
            DataRow Curr = DS.registrydurc.Rows[0];

            if (Curr["selfcertification"] != DBNull.Value)
            {
                byte[] B = (byte[])Curr["selfcertification"];
                labAutocertFileName.Text = GetFileName(B);
                btnAllegaAuto.Enabled = false;
                btnVisualizzaAuto.Enabled = true;
                btnRimuoviAuto.Enabled = true;
            }
            else
            {
                btnAllegaAuto.Enabled = true;
                btnVisualizzaAuto.Enabled = false;
                btnRimuoviAuto.Enabled = false;
            }

            if (Curr["durccertification"] != DBNull.Value)
            {
                btnAllegaDurc.Enabled = false;
                btnVisualizzaDurc.Enabled = true;
                btnRimuoviDurc.Enabled = true;
                byte[] B = (byte[])Curr["durccertification"];
                labDurcFileName.Text = GetFileName(B);
            }
            else
            {
                btnAllegaDurc.Enabled = true;
                btnVisualizzaDurc.Enabled = false;
                btnRimuoviDurc.Enabled = false;
            }
        }
        private void txtDataIniziovalidita_Leave(object sender, EventArgs e) {
            if (!Meta.DrawStateIsDone) return;

            if (txtDataIniziovalidita.Text == "")
            {
                return;
            }
            else
            {
                //forza l'immissione di una data valida
                DateTime datainiziovalidita;
                try
                {
                    datainiziovalidita = Convert.ToDateTime(txtDataIniziovalidita.Text);
                }
                catch
                {
                    MetaFactory.factory.getSingleton<IMessageShower>().Show("La data inserita non era valida");
                    txtDataIniziovalidita.SelectAll();
                    txtDataIniziovalidita.Focus();
                    return;
                }
            }

            DateTime dRiferimento = new DateTime(2013, 8, 21);
            //I DURC rilasciati entro 21/8/2013 hanno una scadenza di 90
            //I DURC rilasciati dopo 21/8/2013 hanno una scadenza di 120. Task 4756
            if (Meta.InsertMode)
            {
                DateTime start = (DateTime)HelpForm.GetObjectFromString(typeof(DateTime), txtDataIniziovalidita.Text.ToString(), "x.y");
                DateTime stop = new DateTime();
                if (start >= dRiferimento) {
                    stop = start.AddDays(120);
                }
                else {
                    stop = start.AddDays(90);
                }
                txtscadenza.Text = stop.ToString("d");
            }

            if (Meta.EditMode)
            {
                if (DS.registrydurc.Rows.Count > 0)
                {
                    DataRow R = DS.registrydurc.Rows[0];
                    if (R["start"] != DBNull.Value)
                    {
                        DateTime curr_start = (DateTime)R["start"];
                        DateTime new_start = (DateTime)HelpForm.GetObjectFromString(typeof(DateTime), txtDataIniziovalidita.Text.ToString(), "x.y");
                        if (curr_start != new_start)
                        {
                            R["start"] = new_start;
                            //DialogResult RES = MetaFactory.factory.getSingleton<IMessageShower>().Show("Si desidera aggiornare anche la data di Scadenza?", "Informazione", MessageBoxButtons.OKCancel);
                            if (true){  //RES == DialogResult.OK
                                DateTime stop = new DateTime();
                                if (new_start >= dRiferimento) {
                                    stop = new_start.AddDays(120);
                                }
                                else {
                                    stop = new_start.AddDays(90);
                                }
                                R["stop"] = stop;
                                txtscadenza.Text = stop.ToString("d");
                            }
                        }
                    }
                }
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnAllegaAuto_Click(object sender, EventArgs e){
            SalvaAllegato("selfcertification");
        }

        private void btnAllegaDurc_Click(object sender, EventArgs e){
            //bisogna chiedere all'utente il percorso per un file,
            //leggerlo in un array di bytes e metterlo nel campo.
            SalvaAllegato("durccertification");
        }
        void SetBytesForFileName(string S, byte[] B)
        {
            string fname = Path.GetFileName(S);
            byte[] b = Encoding.Default.GetBytes(fname);
            for (int i = 0; i < b.Length; i++) B[i] = b[i];
            B[b.Length] = 0;
        }
        int LengthForFileName(string S)
        {
            string fname = Path.GetFileName(S);
            return fname.Length + 1;
        }
        int GetOffsetForData(Byte[] B)
        {
            int i = 0;
            while (i < B.Length && B[i] != 0) i++;
            return i + 1;
        }
        string GetFileName(Byte[] B)
        {
            int len = 0;
            for (int i = 0; i < B.Length; i++)
            {
                len++;
                if (B[i] == 0) break;
            }
            byte[] b = new byte[len - 1];
            for (int i = 0; i < len - 1; i++)
            {
                b[i] = B[i];
            }
            return Encoding.Default.GetString(b);
        }

        void SalvaAllegato(string certification)
        {
            // Legge il file indicato dall'utente e lo scrive nel DB in 'durccertification' o in 'selfcertification'
            if (Meta.IsEmpty) return;
            if (!Meta.GetFormData(true)) return;
            DialogResult dialogResult;
            try {
                dialogResult = opendlg.ShowDialog(this);
            }
            catch (Exception E) {
                QueryCreator.ShowException("Errore nella selezione  del file", E);
                return;
            }
            if (dialogResult == DialogResult.Cancel) return;
            DataRow Curr = HelpForm.GetLastSelected(DS.registrydurc);
            if (Curr == null) return;
            FileStream FS;
            try {
                FS = new FileStream(opendlg.FileName, FileMode.Open, FileAccess.Read);
            }
            catch (Exception e) {
                QueryCreator.ShowException("Errore nell'apertura del file", e);
                return;
            }
            string estensione = Path.GetExtension(FS.Name);
            if (FS == null) return;
            int n = (int)FS.Length;
            if (n == 0) return;
            int namelen = LengthForFileName(opendlg.FileName);

            try
            {
                byte[] ByteArray = new byte[n + namelen];
                FS.Read(ByteArray, namelen, n);
                if (FS.Length == 0)
                {
                    Curr[certification] = DBNull.Value;
                }
                FS.Close();
                SetBytesForFileName(opendlg.FileName, ByteArray);
                Curr[certification] = ByteArray;
            }
            catch { }
            AbilitaDisabilitaAllegati();
        }

        private void btnVisualizzaAuto_Click(object sender, EventArgs e){
            VisualizzaAllegato("selfcertification");
        }

        private void btnVisualizzaDurc_Click(object sender, EventArgs e){
            VisualizzaAllegato("durccertification");
        }

        private void VisualizzaAllegato(string certification)
        {
            string FilePath = AppDomain.CurrentDomain.BaseDirectory;
            string prefix = "SWMOREDURC";
            string filenametodelete = FilePath + prefix + "*.*";
            string[] existingreports = System.IO.Directory.GetFiles(FilePath, prefix + "*.*");
            foreach (string filename in existingreports)   {
                try
                {
                    System.IO.File.Delete(filename);
                }
                catch
                { }
            }

            //sw è il nome del file temporaneo che hai creato
            DateTime oggi_dt = DateTime.Now;
            string oggi = oggi_dt.Ticks.ToString();
            DataRow Curr = DS.registrydurc.Rows[0];

            byte[] ByteArray = (byte[])Curr[certification];
            int offset = GetOffsetForData(ByteArray);
            string fname = GetFileName(ByteArray);
            string estensione = Path.GetExtension(fname).Trim(); ;

            string sw = Path.Combine(FilePath, prefix + oggi.ToString() + estensione);
            try
            {
                ScriviFile(sw, ByteArray, offset);

                System.Diagnostics.Process.Start(sw);
            }
            catch (Exception E)
            {
                QueryCreator.ShowException(E);
            }

        }

        void ScriviFile(string sw, byte[] documento, int offset){
            // Legge il documento memorizzato nel DB e lo scrive nel file temp.
            if (Meta.IsEmpty) return;
            if (!Meta.GetFormData(true)) return;

            FileStream FS = new FileStream(sw, FileMode.Create, FileAccess.Write);

            int n = documento.Length - offset;
            if (n == 0) return;
            try
            {
                FS.Write(documento, offset, n);//<<<<<<<<<
                FS.Flush();
                FS.Close();
            }
            catch { }
        }

        private void btnRimuoviDurc_Click(object sender, EventArgs e){
            DS.registrydurc.Rows[0]["durccertification"] = DBNull.Value;
            AbilitaDisabilitaAllegati();
        }

        private void btnRimuoviAuto_Click(object sender, EventArgs e){
            DS.registrydurc.Rows[0]["selfcertification"] = DBNull.Value;
            AbilitaDisabilitaAllegati();
        }

    }
}
