
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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


using Microsoft.Deployment.WindowsInstaller;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using Xceed.FileSystem;
using Xceed.Zip;

namespace LiveUpgrade {

    public partial class FormProgress : Form {

        private delegate void LogEventDelegate(string message);
        private delegate void LogProgressDelegate(int percentage);

        public FormProgress() {
            InitializeComponent();
        }

        private void LogProgress(int percentage) {
            progressUpgrade.Value = percentage;
        }

        #region "Download"
        /// <summary>
        /// Scarica un file dal web.
        /// </summary>
        /// <param name="name">Nome del file da scaricare.</param>
        /// <param name="url">Indirizzo web.</param>
        /// <returns>Il percorso dove il file è stato scaricato.</returns>
        public void Download(string name, string url, string path) {
            progressUpgrade.Style = ProgressBarStyle.Continuous;
            progressUpgrade.Value = progressUpgrade.Minimum;
            labelUpgrade.Text = string.Format("Scaricamento di '{0}' in corso... ", name);

            var thread = new Thread(() => {
                var web = new WebClient();
                //web.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
                //web.Headers.Add("Accept-Language", "it-IT,it;q=0.8,en-US;q=0.6,en;q=0.4,bg;q=0.2,es;q=0.2,vi;q=0.2");
                web.Headers.Add("User-Agent", "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; Trident/6.0)");
                var request = WebRequest.Create(url);
                request.Method = "GET";

                var response = request.GetResponse();
                var bytesTotal = response.ContentLength;

                using (var input = response.GetResponseStream())
                using (var output = new FileStream(path, FileMode.Create)) {
                    var buffer = new byte[2048];

                    int bytesRead = 0;
                    long bytesWritten = 0;

                    try {
                        while ((bytesRead = input.Read(buffer, 0, buffer.Length)) > 0) {
                            output.Write(buffer, 0, bytesRead);

                            bytesWritten += bytesRead;
                            var progress = Convert.ToInt32((100 * bytesWritten) / bytesTotal);

                            Invoke(new LogProgressDelegate(LogProgress), progress);
                            Application.DoEvents();
                        }
                    }
                    catch (Exception ex) {
                        string caption = "Errore";
                        string message = @"Si è verificato un errore critico e l'aggiornamento è stato interrotto. Contattare il supporto tecnico.";
                        MessageBox.Show(this, message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);

                        Log.Critical(ex);
                    }
                    finally {
                        output.Flush();
                        output.Close();
                        input.Close();
                    }
                }
            });

            thread.IsBackground = true;
            thread.Start();
            
            while (!thread.Join(0)) {
                Application.DoEvents();
            }
        }
        #endregion

        #region "Clear"
        /// <summary>
        /// Elimina i file specificati dalla cartella.
        /// </summary>
        /// <param name="dest">Cartella operativa.</param>
        /// <param name="filters">Filtri per la cancellazione.</param>
        public void Clean(string dest) {
            var folder = new DiskFolder(dest);
            if (!folder.Exists) return;

            progressUpgrade.Value = progressUpgrade.Minimum;
            labelUpgrade.Text = string.Format("Pulisco la cartella {0}... ", folder.Name);

            try {
                var files = folder.GetFiles(false);
                foreach (var file in files) {
                    if (file.Name.StartsWith("fileindex") ||
                        (file.Name.EndsWith(".dll") && !(file.Name.StartsWith("Microsoft") || file.Name.StartsWith("Xceed")))) {
                        file.Delete();
                    }
                }
            }
            catch (Exception ex) {
                string caption = "Errore";
                string message = @"Si è verificato un errore critico e l'aggiornamento è stato interrotto. Contattare il supporto tecnico.";
                MessageBox.Show(this, message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);

                Log.Critical(ex);
            }
        }
        #endregion

        #region "Unpack"
        /// <summary>
        /// Scompatta un archivio nella cartella di destinazione.
        /// </summary>
        /// <param name="file">Archivio da scompattare.</param>
        /// <param name="dest">Cartella di destinazione.</param>
        /// <returns>Risultato dell'operazione.</returns>
        public void Unpack(string file, string dest) {
            var folder = new DiskFolder(dest);
            var archive = new ZipArchive(new DiskFile(file));

            progressUpgrade.Style = ProgressBarStyle.Continuous;
            progressUpgrade.Value = progressUpgrade.Minimum;
            labelUpgrade.Text = string.Format("Scompatto l'archivio {0} in {1}... ", archive.Name, folder.Name);

            FileSystemEvents events = new FileSystemEvents();
            events.ItemProgression += Events_ItemProgression;
            events.ItemException += Events_ItemException;

            try {
                archive.CopyFilesTo(events, null, folder, true, true, "*.*");

                progressUpgrade.Value = progressUpgrade.Maximum;
            }
            catch (Exception ex) {
                string caption = "Errore";
                string message = @"Si è verificato un errore critico e l'aggiornamento è stato interrotto. Contattare il supporto tecnico.";
                MessageBox.Show(this, message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);

                Log.Critical(ex);
            }
        }

        private void Events_ItemProgression(object sender, ItemProgressionEventArgs e) {
            Invoke(new LogProgressDelegate(LogProgress), e.AllItems.Percent);

            Application.DoEvents();
            Refresh();
        }

        private void Events_ItemException(object sender, ItemExceptionEventArgs e) {
            var message = string.Format("Chiudere gli altri programmi in esecuzione e riprovare.");
            var result = MessageBox.Show(this, message, "Errore", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

            switch (result) {
                case DialogResult.Cancel: e.Action = ItemExceptionAction.Abort; break;
                case DialogResult.Retry: e.Action = ItemExceptionAction.Retry; break;
            }
        }
        #endregion

        #region "Run"
        public int Run(string path, string args) {
            progressUpgrade.Style = ProgressBarStyle.Marquee;
            labelUpgrade.Text = string.Format("Esecuzione di '{0}' in corso...", Path.GetFileName(path));

            Refresh();
            //Application.DoEvents();

            try {
                var process = new Process();
                process.StartInfo.FileName = path;
                process.StartInfo.Arguments = args;
                process.Start();

                while (!process.HasExited) {
                    Application.DoEvents();
                    Thread.Sleep(1);
                }

                return process.ExitCode;
            }
            catch (Exception ex) {
                string caption = "Errore";
                string message = @"Si è verificato un errore critico e l'aggiornamento è stato interrotto. Contattare il supporto tecnico.";
                MessageBox.Show(this, message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);

                Log.Critical(ex);
            }

            return -1;
        }
        #endregion

        #region "Install"
        public void Install(string path, string args) {
            progressUpgrade.Style = ProgressBarStyle.Marquee;
            labelUpgrade.Text = string.Format("Installazione di '{0}' in corso...", Path.GetFileName(path));

            try {
                Installer.SetInternalUI(InstallUIOptions.Silent);
                Installer.InstallProduct(path, args);
            }
            catch (Exception ex) {
                string caption = "Errore";
                string message = @"Si è verificato un errore critico e l'aggiornamento è stato interrotto. Contattare il supporto tecnico.";
                MessageBox.Show(this, message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);

                Log.Critical(ex);
            }
        }
        #endregion

    }

}
