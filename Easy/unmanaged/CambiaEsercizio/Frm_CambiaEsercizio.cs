
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
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;

namespace CambiaEsercizio//CambiaEsercizio//
{
    /// <summary>
    /// Summary description for frmCambiaEsercizio.
    /// </summary>
    public class frmCambiaEsercizio : System.Windows.Forms.Form {
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEsercizio;
        EntityDispatcher E;
        DataAccess DataAccessLocale;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public frmCambiaEsercizio(EntityDispatcher E) {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            this.E = E;
            DataAccessLocale = E.Conn;
            txtEsercizio.Text = E.GetSys("esercizio").ToString();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtEsercizio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(200, 88);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Annulla";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(112, 88);
            this.btnOK.Name = "btnOK";
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtEsercizio
            // 
            this.txtEsercizio.Location = new System.Drawing.Point(120, 40);
            this.txtEsercizio.Name = "txtEsercizio";
            this.txtEsercizio.Size = new System.Drawing.Size(72, 20);
            this.txtEsercizio.TabIndex = 5;
            this.txtEsercizio.Text = "";
            this.txtEsercizio.Leave += new System.EventHandler(this.txtEsercizio_Leave);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 40);
            this.label1.Name = "label1";
            this.label1.TabIndex = 4;
            this.label1.Text = "Esercizio:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmCambiaEsercizio
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(288, 125);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtEsercizio);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmCambiaEsercizio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modifica esercizio";
            this.ResumeLayout(false);

        }

        #endregion

        private void txtEsercizio_Leave(object sender, System.EventArgs e) {
            HelpForm.FormatLikeYear(txtEsercizio);
        }

        bool CambioDataConsentita(DataAccess DA, DateTime newDate) {
            object idcustomuser = DA.GetSys("idcustomuser");
            object ayear = newDate.Year;
            if (newDate.Year < 2000 || newDate.Year > 2099) return false;
            if (idcustomuser == DBNull.Value) return true;
            QueryHelper QHS = DA.GetQueryHelper();
            string filterall = QHS.CmpEq("idcustomuser", idcustomuser);
            if (DA.RUN_SELECT_COUNT("flowchartuser", filterall, false) == 0) return true; //fuori dall'organigramma
            string filteranno = QHS.Like("idflowchart", ayear.ToString().Substring(2) + "%");
            string filterdate = QHS.AppAnd(filterall, filteranno, QHS.NullOrLe("start", newDate), QHS.NullOrGe("stop", newDate));
            if (DA.RUN_SELECT_COUNT("flowchartuser", filterdate, false) == 0) return false;
            object oggi = DA.DO_SYS_CMD("select getdate()");
            string filternow = QHS.AppAnd(filterall, filteranno, QHS.NullOrLe("start", oggi), QHS.NullOrGe("stop", newDate));
            if (DA.RUN_SELECT_COUNT("flowchartuser", filternow, false) == 0) return false;
            return true;
        }

        public bool DatiValidi() {
            int esercizio;
            try {
                esercizio = (int) HelpForm.GetObjectFromString(typeof(int),
                    txtEsercizio.Text.ToString(), "x.y.year");
                if (esercizio < 1000) {
                    MetaFactory.factory.getSingleton<IMessageShower>().Show("L'esercizio non può essere minore di 1000","Errore");
                    txtEsercizio.Focus();
                    return false;
                }
                if (esercizio > 3000) {
                    MetaFactory.factory.getSingleton<IMessageShower>().Show("L'esercizio è troppo grande","Errore");
                    txtEsercizio.Focus();
                    return false;
                }

                //return true;
            }
            catch {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("E' necessario inserire un esercizio");
                txtEsercizio.Focus();
                return false;
            }

            string filteresercizio = "(ayear=" + QueryCreator.quotedstrvalue(esercizio, true) + ")";
            DataTable EsercizioTable =
                DataAccessLocale.RUN_SELECT("accountingyear", "*", null, filteresercizio, null, true);

            if (EsercizioTable.Rows.Count == 0) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("L'esercizio " + esercizio + " non è stato creato.");
                txtEsercizio.Focus();
                return false;
            }

            txtEsercizio.Focus();
            return true;
        }

        private void btnOK_Click(object sender, System.EventArgs e) {
            if (!DatiValidi()) return;
            int esercizio = (int) HelpForm.GetObjectFromString(typeof(int),
                txtEsercizio.Text.ToString(), "x.y.year");
            int oldesercizio = (int) E.GetSys("esercizio");
            //DataAccessLocale.SetEsercizio(esercizio);
            //DateTime T = (DateTime) DataAccessLocale.sys["datacontabile"];
            DateTime T = DateTime.Now;
            DateTime ToSet = DateTime.Now;
            if (esercizio > oldesercizio) {
                ToSet = new DateTime(esercizio, 1, 1);
                //DataAccessLocale.SetDataContabile(				
                //	new DateTime(esercizio, 1, 1));
            }

            if (esercizio < oldesercizio) {
                ToSet = new DateTime(esercizio, 12, 31);
                //DataAccessLocale.SetDataContabile(
                //	new DateTime(esercizio, 12, 31));
            }

            if (esercizio == T.Year) {
                ToSet = new DateTime(esercizio, T.Month, T.Day);
                //DataAccessLocale.SetDataContabile( 
                //	new DateTime(esercizio, T.Month, T.Day));
            }

            if (!CambioDataConsentita(DataAccessLocale, ToSet)) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Accesso non consentito in tale data in base alla gestione della sicurezza");
                return;

            }

            E.SetSys("esercizio", esercizio);
            E.SetSys("datacontabile", ToSet);
            if (esercizio != oldesercizio)
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Avvertimento: la data contabile è stata automaticamente impostata al \n" +
                                ((DateTime) E.GetSys("datacontabile")).ToShortDateString());
            DialogResult = DialogResult.OK;
        }
    }
}
