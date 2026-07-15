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
using metaeasylibrary;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace metaeasylibrary {
    public partial class frmCreaTicket : Form {
        MetaData meta;
        DataSet DS;
        IDataAccess Conn;
        private IFormController controller;
        QueryHelper q;
        int idcliente = 0;
        int idente = 0;
        int idstruttura = 0;
        byte[] attachmentFile;
        string attachmentFileName;
        helpDeskService.doHelpDesk hds;
        public frmCreaTicket(MetaData meta, IDataAccess conn) {
            InitializeComponent();
            this.meta = meta;

            this.DS = meta.ds;
            this.Conn = conn;
            this.q = Conn.GetQueryHelper();
            controller = meta?.linkedForm.getInstance<IFormController>();

            this.idcliente = getIdCliente();
            if (idcliente > 0) {
                hds = new helpDeskService.doHelpDesk {
                    Url = "https://your-server/helpdeskservice/doHelpDesk.asmx"
                };

                idente = Convert.ToInt32(Conn.DO_READ_VALUE("uniconfig", null, "idente"));

                var treasurer = Conn.RUN_SELECT("treasurer", "*", null,
                   q.AppAnd(q.CmpEq("active", "S"), q.IsNotNull("idstruttura")), null, false);
                Conn.Security.DeleteAllUnselectable(treasurer);
                if (treasurer.Rows.Count > 0) {
                    if (treasurer.Rows[0]["idstruttura"] != DBNull.Value) {
                        idstruttura = Convert.ToInt32(treasurer.Rows[0]["idstruttura"]);
                    }
                }
            }


        }


        int getIdCliente() {
            var webUser = Conn.RUN_SELECT("webuser", "*", null, q.CmpEq("username", Conn.Security.GetSys("user")), null, false);
            if (webUser == null || webUser.Rows.Count == 0)
                return 0;
            var r = webUser.Rows[0];
            if (r["idcliente"] == DBNull.Value) return 0;
            string nome = r["nome"].ToString();
            string cognome = r["cognome"].ToString();
            string titolo = r["titolo"].ToString();
            txtDenominazione.Text = titolo + " " + nome + " " + cognome;
            txtEmail.Text = r["email"].ToString();
            txtUser.Text = r["username"].ToString();
            return Convert.ToInt32(r["idcliente"]);
        }
        bool firstActivation = true;
        private void frmCreaTicket_Activated(object sender, EventArgs e) {
            if (!firstActivation)
                return;
            firstActivation = false;
            if (idcliente == 0) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this,"E' necessario registrarsi prima di poter creare ticket. Andare su File/Ticket/Registrazione all'Helpdesk", "Avviso");
                this.Close();
            }
        }
        string noNullString(string s) {
            if (s == null) return "(null)";
            return s;
        }
        private void btnInvia_Click(object sender, EventArgs e) {
            if (hds == null) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Non è possibile creare un ticket prima di registrarsi.", "Avviso");
                return;
            }
            if (txtProblema.Text.Length < 10) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this,"Descrivere il problema accuratamente per agevolarne il processo di risoluzione", "Avviso");
                return;
            }
            string problema = txtProblema.Text;

            string dataset = " "+Convert.ToBase64String(DataAccess.PackDataSet( DS));
            if (dataset.Length > 40000) dataset = "*";

            //nella maschera degli operatori
            //string xmlClear = Encoding.UTF8.GetString(Convert.FromBase64String(DocStr));

            string screenshot="";
            if (chkScreenShot.Checked) {
                var bounds = Screen.GetBounds(Point.Empty);
                using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height)) {
                    this.WindowState = FormWindowState.Minimized;
                    Application.DoEvents();                    
                    using (var g = Graphics.FromImage(bitmap)) {
                        g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                    }
                    WindowState = FormWindowState.Normal;
                    var MS = new MemoryStream();
                    bitmap.Save(MS, ImageFormat.Jpeg);
                    screenshot = Convert.ToBase64String(MS.GetBuffer());
                    //sul client:
                    //  byte[] ByteArray = Convert.FromBase64String(Doc);
                }
            }
            var sb = new StringBuilder();            
            var currAss = AppDomain.CurrentDomain.GetAssemblies();
            
            foreach (Assembly A in currAss) {
                if (A.GetName() == null) continue;
                sb.AppendLine(A.GetName().Name.PadLeft(40) + ":" + A.GetName().Version);
            }
            string dll = sb.ToString();

            string outputview = "";
            if (Debug.Listeners != null) {
                foreach (TraceListener tl in Debug.Listeners) {
                    //Vede se ha proprietà StringBuilder Errors
                    var myType = tl.GetType();
                    var mprop = myType.GetField("Errors");
                    if (mprop != null) {
                        if(mprop.GetValue(tl) is StringBuilder ssb)
                            outputview = ssb.ToString();
                        break;
                    }
                }
            }
            StringBuilder status = new StringBuilder();
            status.AppendLine("Metadata " + noNullString(meta.TableName)+ " - " + noNullString(meta.Name));
            status.AppendLine("edittype " + noNullString(meta.edit_type));
            if (controller != null) {
                if (controller.IsEmpty) {
                    status.AppendLine("Form status: empty" );
                }
            
                if (controller.EditMode) {
                    status.AppendLine("Form status: edit" );
                    if (meta.ds.HasChanges()) {
                        status.AppendLine("DS has changes" );
                    }
                    else {
                        status.AppendLine("DS has no changes" );
                    }
                }
                if (controller.InsertMode) {
                    status.AppendLine("Form status: insert" );
                }

            }
            if (controller?.linkedForm != null) {
                status.AppendLine("form filename: " + FormController.GetHelpFileName(meta.linkedForm) );
            }
            if (Conn != null) {
                foreach (string skey in Conn.Security.EnumSysKeys()) {
                    if (Conn.Security.GetSys(skey) != null) {
                        status.AppendLine("sys[" + skey + "]=" + Conn.Security.GetSys(skey));
                    }
                }
                foreach (string skey in Conn.Security.EnumUsrKeys()) {
                    if (Conn.Security.GetUsr(skey) != null) {
                        status.AppendLine("usr[" + skey + "]=" + Conn.Security.GetUsr(skey));
                    }
                }
            }
            else {
                status.AppendLine("Il DataAccess collegato al form è null.");
            }

            string attachment64 = null;
            if (attachmentFile != null) {
                attachment64 = Convert.ToBase64String(attachmentFile);
            }
            string res = hds.creaTicket(idcliente, idstruttura, idente, dataset, screenshot, status.ToString(),
                        attachment64, attachmentFileName, outputview, dll, problema);
            if (res!=null && res.StartsWith("Errori")) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this,res, "Errore");
                return;
            }
            //res è l'id del ticket
            int idticket = Convert.ToInt32(res);
            res = "Errore nella scrittura del db";
            if (Conn != null) {
                res = Conn.DO_INSERT("ticket",
                                new string[]{"idticket","login","email","denominazione","problema",
                                "idcliente","idstruttura","idente","filename","status","apertura"},
                                    new string[]{q.quote(idticket),q.quote(txtUser.Text),q.quote(txtEmail.Text),q.quote(txtDenominazione.Text),
                                                    q.quote(problema),q.quote(idcliente),q.quote(idstruttura),
                                                    q.quote(idente), q.quote(attachmentFileName),q.quote("aperto"),q.quote(DateTime.Now)}, 11);
            }
            if (res != null) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this,"Errore nel salvataggio IN LOCALE del ticket:\r\n"+res
                    +"Sarà avvisato della risoluzione del ticket con una mail all'indirizzo "+txtEmail.Text+"."
                    , "Avviso");
            }
            MetaFactory.factory.getSingleton<IMessageShower>().Show(this,"Il ticket è stato creato.", "Avviso");
            this.Close();
        }

        private void btnAttach_Click(object sender, EventArgs e) {
            openFileDialog1.Title = "Seleziona l'allegato";
            if (openFileDialog1.ShowDialog(this) != DialogResult.OK)
                return;
            try {
                FileStream FS = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                int n = (int) FS.Length;
                if (n == 0) {
                    return;
                }
                byte[] ByteArray = new byte[n];
                FS.Read(ByteArray, 0, n);
                if (FS.Length == 0) {
                    return;
                }
                FS.Close();
                attachmentFile = ByteArray;
                attachmentFileName = Path.GetFileName(openFileDialog1.FileName);
                txtFileAllegato.Text = attachmentFileName;
            }
            catch (Exception E) {
                QueryCreator.ShowException("Errore aprendo il file " + openFileDialog1.FileName, E);
            }
        }

        private void btnRimuovi_Click(object sender, EventArgs e) {
            attachmentFile = null;
            attachmentFileName = null;
            txtFileAllegato.Text = "";
        }
    }
}
