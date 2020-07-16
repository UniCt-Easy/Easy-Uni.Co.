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
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;

namespace abatement_default//tipodetrazionelista//
{
    /// <summary>
    /// Summary description for frmtipodetrazionelista.
    /// </summary>
    public class Frm_abatement_default : System.Windows.Forms.Form {
        //private System.ComponentModel.IContainer components;
        public vistaForm DS;
        private System.Windows.Forms.GroupBox grpApplicazione;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.TextBox SubEntity_txtAliquota;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox SubEntity_txtMassimale;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox SubEntity_txtFranchigia;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox SubEntity_txtDescrizioneCod;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox SubEntity_txtCodiceDetrazione;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbTipoImponibile;
        private System.Windows.Forms.Button btnTipoImponibile;
        private System.Windows.Forms.GroupBox grpCodiceDetrazione;
        private System.Windows.Forms.TextBox SubEntity_txtDescEstesa;
        MetaData Meta;
        private System.Windows.Forms.CheckBox checkBox1;
        bool IsAdmin;
        public Frm_abatement_default() {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing) {
            if (disposing) {

            }
            base.Dispose(disposing);
        }

        CQueryHelper QHC;
        QueryHelper QHS;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            IsAdmin = false;
            string filteresercizio;

            if (Meta.GetSys("manage_prestazioni") != null)
                IsAdmin = (Meta.GetSys("manage_prestazioni").ToString() == "S");
            Meta.CanSave = IsAdmin;
            Meta.CanInsert = IsAdmin;
            Meta.CanInsertCopy = IsAdmin;
            Meta.CanCancel = IsAdmin;
            grpCodiceDetrazione.Text = "Dati del " + Meta.GetSys("esercizio").ToString();
            HelpForm.SetFormatForColumn(DS.abatementcode.Columns["rate"], "p");
            filteresercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            GetData.CacheTable(DS.tax, null, null, true);
            GetData.SetStaticFilter(DS.abatementcode, filteresercizio);
            GetData.CacheTable(DS.abatementview, filteresercizio, null, false);
        }

        public void MetaData_BeforeFill() {
            //Controlla che vi sia o Crea una nuova riga nelle DataTable "codicedetrazione" con valori di default.
            //			SolaLettura(false);
            if (Meta.InsertMode) {
                SolaLettura(!IsAdmin);
                CreateCodiceDetrazioneRow();
            }
            if (Meta.EditMode) {
                SolaLettura(!IsAdmin);
            }
        }

        public void CreateCodiceDetrazioneRow() {
            if (Meta.IsEmpty) return;
            DataRow DRtipodetrazione = HelpForm.GetLastSelected(DS.abatement);
            DataRow[] R = DS.Tables["abatementcode"].Select(QHC.CmpEq("idabatement",
                DRtipodetrazione["idabatement"]));
            if (R.Length == 0) {
                MetaData MetaCD = MetaData.GetMetaData(this, "abatementcode");
                MetaCD.SetDefaults(DS.abatementcode);
                DataRow DR = MetaCD.Get_New_Row(DRtipodetrazione, DS.abatementcode);
            }
        }

        public void MetaData_AfterClear() {
            SolaLettura(!IsAdmin);
        }

        public void SolaLettura(bool noscrittura) {
            SubEntity_txtCodiceDetrazione.ReadOnly = noscrittura;
            SubEntity_txtDescrizioneCod.ReadOnly = noscrittura;
            SubEntity_txtFranchigia.ReadOnly = noscrittura;
            SubEntity_txtMassimale.ReadOnly = noscrittura;
            SubEntity_txtAliquota.ReadOnly = noscrittura;
        }
        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.DS = new abatement_default.vistaForm();
            this.grpApplicazione = new System.Windows.Forms.GroupBox();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.SubEntity_txtAliquota = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.SubEntity_txtMassimale = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.SubEntity_txtFranchigia = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SubEntity_txtDescrizioneCod = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SubEntity_txtCodiceDetrazione = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SubEntity_txtDescEstesa = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTipoImponibile = new System.Windows.Forms.ComboBox();
            this.btnTipoImponibile = new System.Windows.Forms.Button();
            this.grpCodiceDetrazione = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.grpApplicazione.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpCodiceDetrazione.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // grpApplicazione
            // 
            this.grpApplicazione.Controls.Add(this.radioButton4);
            this.grpApplicazione.Controls.Add(this.radioButton3);
            this.grpApplicazione.Location = new System.Drawing.Point(560, 0);
            this.grpApplicazione.Name = "grpApplicazione";
            this.grpApplicazione.Size = new System.Drawing.Size(120, 72);
            this.grpApplicazione.TabIndex = 4;
            this.grpApplicazione.TabStop = false;
            this.grpApplicazione.Text = "Applicazione";
            // 
            // radioButton4
            // 
            this.radioButton4.Location = new System.Drawing.Point(8, 40);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.TabIndex = 1;
            this.radioButton4.Tag = "abatement.appliance:C";
            this.radioButton4.Text = "Competenza";
            // 
            // radioButton3
            // 
            this.radioButton3.Location = new System.Drawing.Point(8, 16);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.TabIndex = 0;
            this.radioButton3.Tag = "abatement.appliance:S";
            this.radioButton3.Text = "Cassa Allargato";
            // 
            // SubEntity_txtAliquota
            // 
            this.SubEntity_txtAliquota.Location = new System.Drawing.Point(568, 80);
            this.SubEntity_txtAliquota.Name = "SubEntity_txtAliquota";
            this.SubEntity_txtAliquota.Size = new System.Drawing.Size(96, 20);
            this.SubEntity_txtAliquota.TabIndex = 4;
            this.SubEntity_txtAliquota.Tag = "abatementcode.rate.fixed.4..%.100?abatementview.rate.fixed.4..%.100";
            this.SubEntity_txtAliquota.Text = "";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(520, 80);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 23);
            this.label11.TabIndex = 75;
            this.label11.Text = "Aliquota:";
            // 
            // SubEntity_txtMassimale
            // 
            this.SubEntity_txtMassimale.Location = new System.Drawing.Point(328, 80);
            this.SubEntity_txtMassimale.Name = "SubEntity_txtMassimale";
            this.SubEntity_txtMassimale.Size = new System.Drawing.Size(112, 20);
            this.SubEntity_txtMassimale.TabIndex = 3;
            this.SubEntity_txtMassimale.Tag = "abatementcode.maximal?abatementview.maximal";
            this.SubEntity_txtMassimale.Text = "";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(256, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 23);
            this.label10.TabIndex = 74;
            this.label10.Text = "Massimale";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // SubEntity_txtFranchigia
            // 
            this.SubEntity_txtFranchigia.Location = new System.Drawing.Point(96, 80);
            this.SubEntity_txtFranchigia.Name = "SubEntity_txtFranchigia";
            this.SubEntity_txtFranchigia.Size = new System.Drawing.Size(96, 20);
            this.SubEntity_txtFranchigia.TabIndex = 2;
            this.SubEntity_txtFranchigia.Tag = "abatementcode.exemption?abatementview.exemption";
            this.SubEntity_txtFranchigia.Text = "";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(24, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 23);
            this.label9.TabIndex = 73;
            this.label9.Text = "Franchigia";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // SubEntity_txtDescrizioneCod
            // 
            this.SubEntity_txtDescrizioneCod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.SubEntity_txtDescrizioneCod.Location = new System.Drawing.Point(136, 40);
            this.SubEntity_txtDescrizioneCod.Name = "SubEntity_txtDescrizioneCod";
            this.SubEntity_txtDescrizioneCod.Size = new System.Drawing.Size(532, 20);
            this.SubEntity_txtDescrizioneCod.TabIndex = 1;
            this.SubEntity_txtDescrizioneCod.Tag = "abatementcode.description?abatementview.abatementtitle";
            this.SubEntity_txtDescrizioneCod.Text = "";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(8, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 23);
            this.label8.TabIndex = 72;
            this.label8.Text = "Descrizione Cod.";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(576, 136);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(102, 20);
            this.textBox1.TabIndex = 10;
            this.textBox1.Tag = "abatement.evaluationorder";
            this.textBox1.Text = "";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(456, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 23);
            this.label7.TabIndex = 71;
            this.label7.Text = "Ordine Valutazione";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // SubEntity_txtCodiceDetrazione
            // 
            this.SubEntity_txtCodiceDetrazione.Location = new System.Drawing.Point(136, 16);
            this.SubEntity_txtCodiceDetrazione.Name = "SubEntity_txtCodiceDetrazione";
            this.SubEntity_txtCodiceDetrazione.Size = new System.Drawing.Size(168, 20);
            this.SubEntity_txtCodiceDetrazione.TabIndex = 0;
            this.SubEntity_txtCodiceDetrazione.Tag = "abatementcode.code?abatementview.abatementcode";
            this.SubEntity_txtCodiceDetrazione.Text = "";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 23);
            this.label1.TabIndex = 70;
            this.label1.Text = "Codice Detrazione";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(576, 104);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(102, 20);
            this.textBox6.TabIndex = 8;
            this.textBox6.Tag = "abatement.validitystop";
            this.textBox6.Text = "";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(464, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 24);
            this.label6.TabIndex = 68;
            this.label6.Text = "Data Fine";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(136, 104);
            this.textBox2.Name = "textBox2";
            this.textBox2.TabIndex = 7;
            this.textBox2.Tag = "abatement.validitystart";
            this.textBox2.Text = "";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 24);
            this.label2.TabIndex = 64;
            this.label2.Text = "Data Inizio";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(440, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(112, 72);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo Calcolo";
            // 
            // radioButton2
            // 
            this.radioButton2.Location = new System.Drawing.Point(8, 48);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(96, 16);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Tag = "abatement.calculationkind:M";
            this.radioButton2.Text = "Mensile";
            // 
            // radioButton1
            // 
            this.radioButton1.Location = new System.Drawing.Point(8, 24);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(96, 16);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Tag = "abatement.calculationkind:G";
            this.radioButton1.Text = "Giornaliero";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(136, 136);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(304, 20);
            this.textBox5.TabIndex = 9;
            this.textBox5.Tag = "abatement.evaluatesp";
            this.textBox5.Text = "";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 23);
            this.label5.TabIndex = 60;
            this.label5.Text = "SP Calcolo";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // SubEntity_txtDescEstesa
            // 
            this.SubEntity_txtDescEstesa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.SubEntity_txtDescEstesa.Location = new System.Drawing.Point(136, 112);
            this.SubEntity_txtDescEstesa.Multiline = true;
            this.SubEntity_txtDescEstesa.Name = "SubEntity_txtDescEstesa";
            this.SubEntity_txtDescEstesa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.SubEntity_txtDescEstesa.Size = new System.Drawing.Size(532, 168);
            this.SubEntity_txtDescEstesa.TabIndex = 12;
            this.SubEntity_txtDescEstesa.Tag = "abatementcode.longdescription?abatementview.longdescription";
            this.SubEntity_txtDescEstesa.Text = "";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 23);
            this.label4.TabIndex = 58;
            this.label4.Text = "Descrizione Estesa";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Location = new System.Drawing.Point(136, 80);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(544, 20);
            this.textBox3.TabIndex = 6;
            this.textBox3.Tag = "abatement.description";
            this.textBox3.Text = "";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 23);
            this.label3.TabIndex = 55;
            this.label3.Text = "Descrizione";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbTipoImponibile
            // 
            this.cmbTipoImponibile.DataSource = this.DS.tax;
            this.cmbTipoImponibile.DisplayMember = "description";
            this.cmbTipoImponibile.Location = new System.Drawing.Point(136, 8);
            this.cmbTipoImponibile.Name = "cmbTipoImponibile";
            this.cmbTipoImponibile.Size = new System.Drawing.Size(256, 21);
            this.cmbTipoImponibile.TabIndex = 2;
            this.cmbTipoImponibile.Tag = "abatement.taxcode";
            this.cmbTipoImponibile.ValueMember = "taxcode";
            // 
            // btnTipoImponibile
            // 
            this.btnTipoImponibile.Location = new System.Drawing.Point(8, 8);
            this.btnTipoImponibile.Name = "btnTipoImponibile";
            this.btnTipoImponibile.Size = new System.Drawing.Size(112, 23);
            this.btnTipoImponibile.TabIndex = 1;
            this.btnTipoImponibile.Tag = "choose.tax.default";
            this.btnTipoImponibile.Text = "Codice Ritenuta";
            // 
            // grpCodiceDetrazione
            // 
            this.grpCodiceDetrazione.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCodiceDetrazione.Controls.Add(this.label1);
            this.grpCodiceDetrazione.Controls.Add(this.SubEntity_txtCodiceDetrazione);
            this.grpCodiceDetrazione.Controls.Add(this.label8);
            this.grpCodiceDetrazione.Controls.Add(this.SubEntity_txtDescrizioneCod);
            this.grpCodiceDetrazione.Controls.Add(this.label9);
            this.grpCodiceDetrazione.Controls.Add(this.SubEntity_txtFranchigia);
            this.grpCodiceDetrazione.Controls.Add(this.label10);
            this.grpCodiceDetrazione.Controls.Add(this.SubEntity_txtMassimale);
            this.grpCodiceDetrazione.Controls.Add(this.label11);
            this.grpCodiceDetrazione.Controls.Add(this.SubEntity_txtAliquota);
            this.grpCodiceDetrazione.Controls.Add(this.label4);
            this.grpCodiceDetrazione.Controls.Add(this.SubEntity_txtDescEstesa);
            this.grpCodiceDetrazione.Location = new System.Drawing.Point(8, 168);
            this.grpCodiceDetrazione.Name = "grpCodiceDetrazione";
            this.grpCodiceDetrazione.Size = new System.Drawing.Size(676, 288);
            this.grpCodiceDetrazione.TabIndex = 11;
            this.grpCodiceDetrazione.TabStop = false;
            this.grpCodiceDetrazione.Text = "Dati dell\'esercizio";
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(136, 48);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Tag = "abatement.flagabatableexpense:S:N";
            this.checkBox1.Text = "Onere detraibile";
            // 
            // Frm_abatement_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(692, 462);
            this.Controls.Add(this.grpCodiceDetrazione);
            this.Controls.Add(this.grpApplicazione);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbTipoImponibile);
            this.Controls.Add(this.btnTipoImponibile);
            this.Controls.Add(this.checkBox1);
            this.Name = "Frm_abatement_default";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.grpApplicazione.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.grpCodiceDetrazione.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion
    }
}
