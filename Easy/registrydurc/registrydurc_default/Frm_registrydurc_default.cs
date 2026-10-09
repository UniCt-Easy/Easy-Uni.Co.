/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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
    public partial class Frm_registrydurc_default : MetaDataForm {
        private MetaData Meta;
        CQueryHelper QHC;
        QueryHelper QHS;

        public IOpenFileDialog opendlg;

        public Frm_registrydurc_default(){
            InitializeComponent();
            opendlg = createOpenFileDialog(_opendlg);
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

            if (Curr["selfcertification"] != DBNull.Value || Curr["idfilestorage2"] != DBNull.Value)
            {
                string nome = NomeDaMostrare(Curr, "selfcertification");
                if (nome == null) return; // download non disponibile, già segnalato
                labAutocertFileName.Text = nome;
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

            if (Curr["durccertification"] != DBNull.Value || Curr["idfilestorage"] != DBNull.Value)
            {
                btnAllegaDurc.Enabled = false;
                btnVisualizzaDurc.Enabled = true;
                btnRimuoviDurc.Enabled = true;

                string nome = NomeDaMostrare(Curr, "durccertification");
                if (nome == null) return; // download non disponibile, già segnalato
                labDurcFileName.Text = nome;
            }
            else
            {
                btnAllegaDurc.Enabled = true;
                btnVisualizzaDurc.Enabled = false;
                btnRimuoviDurc.Enabled = false;
            }
        }

        // Nome da mostrare nell'etichetta: la colonna <campo>filename, altrimenti il nome scritto in testa al
        // contenuto (formato vecchio). Il contenuto su MongoDb si scarica solo se la colonna del nome è vuota,
        // come prima. Restituisce null (dopo averlo segnalato) se il download non è disponibile, "" se il nome
        // non c'è.
        string NomeDaMostrare(DataRow Curr, string certification) {
            object colonna = Curr[certification + "filename"];
            if (colonna != DBNull.Value && !string.IsNullOrWhiteSpace(colonna.ToString()))
                return colonna.ToString().Trim();

            byte[] dati = Curr[certification] as byte[];
            if (dati == null) {
                string idfilestorage = certification == "selfcertification" ? "idfilestorage2" : "idfilestorage";
                dati = metaeasylibrary.HttpFileStorage.DownloadFile(this.conn, this.meta.PrimaryDataTable.TableName, Curr[idfilestorage].ToString()).GetAwaiter().GetResult();
                if (dati == null) {
                    show("Servizio Download degli Allegati non disponibile");
                    return null;
                }
            }
            string incorporato;
            int inizio = InizioContenuto(dati, out incorporato);
            return NomeAllegato(Curr, certification, dati, inizio, incorporato) ?? "";
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
                    show("La data inserita non era valida");
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
                            //DialogResult RES = show("Si desidera aggiornare anche la data di Scadenza?", "Informazione", MessageBoxButtons.OKCancel);
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
        // Gli allegati possono essere in due formati:
        //  - nuovo:   il campo contiene solo il file, il nome sta in <campo>filename (come salva questa maschera
        //             e registrydurc_anagraficadetail da r23483)
        //  - vecchio: il campo contiene "nome file" + byte 0 + file e <campo>filename è vuoto (DURC salvati prima)
        // Il formato si riconosce dai byte, non dalla colonna del nome. Stesse funzioni di
        // registrydurc_anagraficadetail: tenerle allineate.

        // Nome del file: la colonna <campo>filename se valorizzata, altrimenti il nome scritto in testa al
        // contenuto (formato vecchio); null se non disponibile.
        string NomeAllegato(DataRow Curr, string certification, byte[] dati, int inizio, string incorporato) {
            object colonna = Curr[certification + "filename"];
            if (colonna != DBNull.Value && !string.IsNullOrWhiteSpace(colonna.ToString()))
                return colonna.ToString().Trim();
            if (string.IsNullOrWhiteSpace(incorporato))
                return null;
            // Un nome vecchio senza estensione (es. "DURC E NET") prende quella del contenuto,
            // altrimenti non si saprebbe con cosa aprire il file.
            if (HaEstensione(incorporato))
                return incorporato;
            string ext = EstensioneDaContenuto(dati, inizio);
            return ext == null ? incorporato : incorporato + ext;
        }

        // Offset da cui inizia il file vero: la lunghezza del prefisso "nome + byte 0" se il contenuto è nel
        // formato vecchio, altrimenti 0 (in incorporato il nome letto, null se assente). Il prefisso vale solo se
        // il byte 0 cade entro i primi 256 byte, prima non ci sono caratteri di controllo né / \, dopo c'è almeno
        // un byte, e il nome ha un'estensione oppure dopo c'è un tipo di file riconoscibile: così un file già
        // pulito con un byte 0 all'inizio (un JPEG comincia con FF D8 FF E0 00) non viene scambiato per vecchio.
        static int InizioContenuto(byte[] dati, out string incorporato) {
            incorporato = null;
            if (dati == null) return 0;
            int max = Math.Min(dati.Length, 256);
            int zero = -1;
            for (int i = 0; i < max; i++) {
                if (dati[i] == 0) { zero = i; break; }
                if (dati[i] < 0x20) return 0;
            }
            if (zero < 1 || zero + 1 >= dati.Length) return 0;
            // Il vecchio codice scriveva il nome con Encoding.Default: lo si rilegge allo stesso modo.
            string nome = Encoding.Default.GetString(dati, 0, zero);
            if (nome.IndexOf('/') >= 0 || nome.IndexOf('\\') >= 0) return 0;
            if (!HaEstensione(nome) && EstensioneDaContenuto(dati, zero + 1) == null) return 0;
            incorporato = nome;
            return zero + 1;
        }

        // Punto non in ultima posizione, seguito da 1-8 caratteri alfanumerici.
        static bool HaEstensione(string nome) {
            int punto = nome.LastIndexOf('.');
            if (punto < 0 || punto >= nome.Length - 1 || nome.Length - 1 - punto > 8) return false;
            for (int i = punto + 1; i < nome.Length; i++)
                if (!char.IsLetterOrDigit(nome[i])) return false;
            return true;
        }

        // Estensione del file che inizia a d[da], dai primi byte; null se il tipo non è riconosciuto.
        static string EstensioneDaContenuto(byte[] d, int da) {
            if (d == null || da < 0 || da >= d.Length) return null;
            int n = d.Length - da;
            Func<string, bool> inizia = s => {
                if (n < s.Length) return false;
                for (int i = 0; i < s.Length; i++)
                    if (d[da + i] != (byte)s[i]) return false;
                return true;
            };
            if (inizia("%PDF")) return ".pdf";
            if (n >= 3 && d[da] == 0xFF && d[da + 1] == 0xD8 && d[da + 2] == 0xFF) return ".jpg";
            if (n >= 4 && d[da] == 0x89 && d[da + 1] == 0x50 && d[da + 2] == 0x4E && d[da + 3] == 0x47) return ".png";
            if (inizia("GIF87a") || inizia("GIF89a")) return ".gif";
            if (n >= 4 && d[da] == 0x49 && d[da + 1] == 0x49 && d[da + 2] == 0x2A && d[da + 3] == 0x00) return ".tif";
            if (n >= 4 && d[da] == 0x4D && d[da + 1] == 0x4D && d[da + 2] == 0x00 && d[da + 3] == 0x2A) return ".tif";
            if (n >= 2 && d[da] == 0x42 && d[da + 1] == 0x4D) return ".bmp";
            if (n >= 4 && d[da] == 0x50 && d[da + 1] == 0x4B && d[da + 2] == 0x03 && d[da + 3] == 0x04) return ".zip";
            if (n >= 4 && d[da] == 0xD0 && d[da + 1] == 0xCF && d[da + 2] == 0x11 && d[da + 3] == 0xE0) return ".doc";
            if (inizia("{\\rtf")) return ".rtf";
            if (inizia("<?xml")) return ".xml";
            if (inizia("<html") || inizia("<HTML") || inizia("<!DOCTYPE") || inizia("<!doctype")) return ".htm";
            if (n >= 2 && d[da] == 0x30 && d[da + 1] >= 0x80 && d[da + 1] <= 0x84) return ".p7m";
            return null;
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
            
            string estensione = Path.GetExtension(opendlg.FileName);

			if (CfgFn.ExtensionDenied(estensione)) {
				show("Impossibile caricare questo tipo di file");
				return;
			}
            
            DataRow Curr = HelpForm.GetLastSelected(DS.registrydurc);
            if (Curr == null) return;

            // Formato nuovo, come registrydurc_anagraficadetail: nel campo solo il file, il nome in <campo>filename.
            byte[] ByteArray;
            try {
                ByteArray = File.ReadAllBytes(opendlg.FileName);
            }
            catch (Exception e) {
                QueryCreator.ShowException("Errore nell'apertura del file", e);
                return;
            }
            if (ByteArray.Length == 0) return;
            Curr[certification] = ByteArray;
            Curr[certification + "filename"] = Path.GetFileName(opendlg.FileName);
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
            string FilePath = Path.GetTempPath();
            string prefix = "SWMOREDURC";
            string filenametodelete = FilePath + prefix + "*.*";
            string idfieldStorage = certification == "durccertification" ? "idfilestorage" : "idfilestorage2";
            string[] existingreports = System.IO.Directory.GetFiles(FilePath, prefix + "*.*");
            foreach (string filename in existingreports)   {
                try
                {
                    System.IO.File.Delete(filename);
                }
                catch
                { }
            }

            //sw � il nome del file temporaneo che hai creato
            DateTime oggi_dt = DateTime.Now;
            string oggi = oggi_dt.Ticks.ToString();
            DataRow Curr = DS.registrydurc.Rows[0];
            if (Curr[certification] == DBNull.Value && Curr[idfieldStorage] == DBNull.Value)  return;
            // File preso dall'attachment o dal MongoDb
            byte[] ByteArray = { };

     
            if (Curr[certification] != DBNull.Value) {
                // Attachment
                ByteArray = (byte[])Curr[certification];
            }
            else {
                // MongoDb
                ByteArray = metaeasylibrary.HttpFileStorage.DownloadFile(this.conn, this.meta.PrimaryDataTable.TableName, Curr[idfieldStorage].ToString()).GetAwaiter().GetResult();
                if (ByteArray == null) {
                    show("Servizio Download degli Allegati non disponibile");
                    return;
                }
            }

            if (ByteArray != null) {
                // Formato vecchio ("nome" + byte 0 + file): si salta il prefisso e, se la colonna del nome
                // è vuota, si usa il nome incorporato. Formato nuovo: offset 0 e nome dalla colonna.
                string incorporato;
                int offset = InizioContenuto(ByteArray, out incorporato);
                string fname = NomeAllegato(Curr, certification, ByteArray, offset, incorporato);
                if (fname == null) {
                    show("Nome del file allegato non disponibile");
                    return;
                }
                string estensione = Path.GetExtension(fname).Trim();

                bool extensionDenied = CfgFn.ExtensionDenied(estensione);

			    if (extensionDenied) {
				    show("Impossibile aprire questo tipo di file");
				    return;
			    }
			    if (!CfgFn.ExtensionAllowed(estensione)) {
				    DialogResult dr = show("Si sta aprendo un file con estensione " + estensione +". Sei sicuro di voler aprire questo file?", "Attenzione!", MessageBoxButtons.YesNo);
				    if (dr == DialogResult.No) 
					    return;
			    }

                string sw = Path.Combine(FilePath, prefix + oggi.ToString() + estensione);
                try
                {
                    ScriviFile(sw, ByteArray, offset);

                    runProcess(sw, true);
                }
                catch (Exception E)
                {
                    QueryCreator.ShowException(E);
                }
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
            if (DS.registrydurc.Rows[0]["idfilestorage"] != DBNull.Value)
            {
                DS.registrydurc.Rows[0]["idfilestorage"] = DBNull.Value;
            }
            else
            {
                DS.registrydurc.Rows[0]["durccertification"] = DBNull.Value;
            }
            // Senza più allegato, il nome non deve restare.
            if (DS.registrydurc.Rows[0]["idfilestorage"] == DBNull.Value && DS.registrydurc.Rows[0]["durccertification"] == DBNull.Value)
                DS.registrydurc.Rows[0]["durccertificationfilename"] = DBNull.Value;
            AbilitaDisabilitaAllegati();
        }

        private void btnRimuoviAuto_Click(object sender, EventArgs e){
            if (DS.registrydurc.Rows[0]["idfilestorage2"] != DBNull.Value)
            {
                DS.registrydurc.Rows[0]["idfilestorage2"] = DBNull.Value;
            }
            else
            {
                DS.registrydurc.Rows[0]["selfcertification"] = DBNull.Value;
            }
            // Senza più allegato, il nome non deve restare.
            if (DS.registrydurc.Rows[0]["idfilestorage2"] == DBNull.Value && DS.registrydurc.Rows[0]["selfcertification"] == DBNull.Value)
                DS.registrydurc.Rows[0]["selfcertificationfilename"] = DBNull.Value;
            AbilitaDisabilitaAllegati();
        }

    }
}