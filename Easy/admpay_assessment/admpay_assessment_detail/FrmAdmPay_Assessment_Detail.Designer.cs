
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


namespace admpay_assessment_detail {
    partial class FrmAdmPay_Assessment_Detail {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            InChiusura = true;
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.gboxEntrata = new System.Windows.Forms.GroupBox();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtEserc = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbFaseEntrata = new System.Windows.Forms.ComboBox();
            this.DS = new admpay_assessment_detail.vistaForm();
            this.btnEntrata = new System.Windows.Forms.Button();
            this.chkEntrata = new System.Windows.Forms.CheckBox();
            this.gboxNormale = new System.Windows.Forms.GroupBox();
            this.grpBilancio = new System.Windows.Forms.GroupBox();
            this.chkListTitle = new System.Windows.Forms.CheckBox();
            this.chkFilterAvailable = new System.Windows.Forms.CheckBox();
            this.btnBilancio = new System.Windows.Forms.Button();
            this.txtCodiceBilancio = new System.Windows.Forms.TextBox();
            this.txtDenominazioneBilancio = new System.Windows.Forms.TextBox();
            this.txtImporto = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblWarning = new System.Windows.Forms.Label();
            this.gboxUPB = new System.Windows.Forms.GroupBox();
            this.txtUPB = new System.Windows.Forms.TextBox();
            this.btnUPB = new System.Windows.Forms.Button();
            this.txtDescrUPB = new System.Windows.Forms.TextBox();
            this.gboxEntrata.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.gboxNormale.SuspendLayout();
            this.grpBilancio.SuspendLayout();
            this.gboxUPB.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(12, 73);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(440, 56);
            this.textBox1.TabIndex = 26;
            this.textBox1.Tag = "admpay_assessment.description";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 25;
            this.label1.Text = "Descrizione:";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(248, 510);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "Annulla";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(136, 510);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 23;
            this.btnOk.Tag = "mainsave";
            this.btnOk.Text = "Ok";
            // 
            // gboxEntrata
            // 
            this.gboxEntrata.Controls.Add(this.txtNum);
            this.gboxEntrata.Controls.Add(this.label13);
            this.gboxEntrata.Controls.Add(this.txtEserc);
            this.gboxEntrata.Controls.Add(this.label12);
            this.gboxEntrata.Controls.Add(this.cmbFaseEntrata);
            this.gboxEntrata.Controls.Add(this.btnEntrata);
            this.gboxEntrata.Location = new System.Drawing.Point(12, 401);
            this.gboxEntrata.Name = "gboxEntrata";
            this.gboxEntrata.Size = new System.Drawing.Size(440, 104);
            this.gboxEntrata.TabIndex = 22;
            this.gboxEntrata.TabStop = false;
            this.gboxEntrata.Text = "Selezione del movimento di Entrata a cui collegare il pagamento stipendi";
            // 
            // txtNum
            // 
            this.txtNum.Location = new System.Drawing.Point(56, 69);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(80, 20);
            this.txtNum.TabIndex = 3;
            this.txtNum.Tag = "incomeview.nmov?admpay_assessmentview.nmov";
            this.txtNum.Leave += new System.EventHandler(this.txtNum_Leave);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(16, 72);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 16);
            this.label13.TabIndex = 4;
            this.label13.Text = "Num.";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEserc
            // 
            this.txtEserc.Location = new System.Drawing.Point(56, 40);
            this.txtEserc.Name = "txtEserc";
            this.txtEserc.Size = new System.Drawing.Size(56, 20);
            this.txtEserc.TabIndex = 2;
            this.txtEserc.Tag = "incomeview.ymov.year?admpay_assessmentview.ymov.year";
            this.txtEserc.Leave += new System.EventHandler(this.txtEserc_Leave);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(16, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 16);
            this.label12.TabIndex = 2;
            this.label12.Text = "Eserc.";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbFaseEntrata
            // 
            this.cmbFaseEntrata.DataSource = this.DS.incomephase;
            this.cmbFaseEntrata.DisplayMember = "description";
            this.cmbFaseEntrata.Location = new System.Drawing.Point(8, 16);
            this.cmbFaseEntrata.Name = "cmbFaseEntrata";
            this.cmbFaseEntrata.Size = new System.Drawing.Size(232, 21);
            this.cmbFaseEntrata.TabIndex = 1;
            this.cmbFaseEntrata.Tag = "incomeview.nphase?admpay_assessmentview.nphase";
            this.cmbFaseEntrata.ValueMember = "nphase";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // btnEntrata
            // 
            this.btnEntrata.Location = new System.Drawing.Point(296, 16);
            this.btnEntrata.Name = "btnEntrata";
            this.btnEntrata.Size = new System.Drawing.Size(128, 23);
            this.btnEntrata.TabIndex = 0;
            this.btnEntrata.TabStop = false;
            this.btnEntrata.Text = "Scegli Movimento";
            this.btnEntrata.Click += new System.EventHandler(this.btnEntrata_Click);
            // 
            // chkEntrata
            // 
            this.chkEntrata.Location = new System.Drawing.Point(13, 377);
            this.chkEntrata.Name = "chkEntrata";
            this.chkEntrata.Size = new System.Drawing.Size(256, 24);
            this.chkEntrata.TabIndex = 21;
            this.chkEntrata.Text = "Abilita selezione del movimento di entrata";
            this.chkEntrata.CheckedChanged += new System.EventHandler(this.chkEntrata_CheckedChanged);
            // 
            // gboxNormale
            // 
            this.gboxNormale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxNormale.Controls.Add(this.gboxUPB);
            this.gboxNormale.Controls.Add(this.grpBilancio);
            this.gboxNormale.Location = new System.Drawing.Point(12, 137);
            this.gboxNormale.Name = "gboxNormale";
            this.gboxNormale.Size = new System.Drawing.Size(440, 208);
            this.gboxNormale.TabIndex = 20;
            this.gboxNormale.TabStop = false;
            this.gboxNormale.Text = "Imputazione normale";
            // 
            // grpBilancio
            // 
            this.grpBilancio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBilancio.Controls.Add(this.chkListTitle);
            this.grpBilancio.Controls.Add(this.chkFilterAvailable);
            this.grpBilancio.Controls.Add(this.btnBilancio);
            this.grpBilancio.Controls.Add(this.txtCodiceBilancio);
            this.grpBilancio.Controls.Add(this.txtDenominazioneBilancio);
            this.grpBilancio.Location = new System.Drawing.Point(16, 96);
            this.grpBilancio.Name = "grpBilancio";
            this.grpBilancio.Size = new System.Drawing.Size(416, 104);
            this.grpBilancio.TabIndex = 1;
            this.grpBilancio.TabStop = false;
            this.grpBilancio.Tag = "AutoManage.txtCodiceBilancio.treeeupb.(idupb=\'0001\')";
            // 
            // chkListTitle
            // 
            this.chkListTitle.Location = new System.Drawing.Point(8, 32);
            this.chkListTitle.Name = "chkListTitle";
            this.chkListTitle.Size = new System.Drawing.Size(296, 16);
            this.chkListTitle.TabIndex = 15;
            this.chkListTitle.TabStop = false;
            this.chkListTitle.Text = "Cerca per denominazione";
            // 
            // chkFilterAvailable
            // 
            this.chkFilterAvailable.Checked = true;
            this.chkFilterAvailable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFilterAvailable.Location = new System.Drawing.Point(8, 16);
            this.chkFilterAvailable.Name = "chkFilterAvailable";
            this.chkFilterAvailable.Size = new System.Drawing.Size(288, 16);
            this.chkFilterAvailable.TabIndex = 13;
            this.chkFilterAvailable.TabStop = false;
            this.chkFilterAvailable.Text = "Filtra per disponibilità sufficiente";
            // 
            // btnBilancio
            // 
            this.btnBilancio.BackColor = System.Drawing.SystemColors.Control;
            this.btnBilancio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBilancio.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBilancio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBilancio.ImageIndex = 0;
            this.btnBilancio.Location = new System.Drawing.Point(8, 48);
            this.btnBilancio.Name = "btnBilancio";
            this.btnBilancio.Size = new System.Drawing.Size(120, 23);
            this.btnBilancio.TabIndex = 1;
            this.btnBilancio.TabStop = false;
            this.btnBilancio.Tag = "";
            this.btnBilancio.Text = "Bilancio:";
            this.btnBilancio.UseVisualStyleBackColor = false;
            this.btnBilancio.Click += new System.EventHandler(this.btnBilancio_Click);
            // 
            // txtCodiceBilancio
            // 
            this.txtCodiceBilancio.Location = new System.Drawing.Point(8, 72);
            this.txtCodiceBilancio.Name = "txtCodiceBilancio";
            this.txtCodiceBilancio.Size = new System.Drawing.Size(120, 20);
            this.txtCodiceBilancio.TabIndex = 0;
            this.txtCodiceBilancio.Tag = "finview.codefin?admpay_assessmentview.codefin";
            // 
            // txtDenominazioneBilancio
            // 
            this.txtDenominazioneBilancio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenominazioneBilancio.Location = new System.Drawing.Point(144, 48);
            this.txtDenominazioneBilancio.Multiline = true;
            this.txtDenominazioneBilancio.Name = "txtDenominazioneBilancio";
            this.txtDenominazioneBilancio.ReadOnly = true;
            this.txtDenominazioneBilancio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDenominazioneBilancio.Size = new System.Drawing.Size(264, 48);
            this.txtDenominazioneBilancio.TabIndex = 2;
            this.txtDenominazioneBilancio.TabStop = false;
            this.txtDenominazioneBilancio.Tag = "finview.title";
            // 
            // txtImporto
            // 
            this.txtImporto.Location = new System.Drawing.Point(184, 27);
            this.txtImporto.Name = "txtImporto";
            this.txtImporto.Size = new System.Drawing.Size(100, 20);
            this.txtImporto.TabIndex = 19;
            this.txtImporto.Tag = "admpay_assessment.amount";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(3, 27);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 17;
            this.textBox3.Tag = "admpay_assessment.nassessment";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(181, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 23);
            this.label4.TabIndex = 18;
            this.label4.Text = "Importo da assegnare:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 24);
            this.label3.TabIndex = 16;
            this.label3.Text = "Num Meta Accertamento:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblWarning
            // 
            this.lblWarning.Location = new System.Drawing.Point(12, 348);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(440, 32);
            this.lblWarning.TabIndex = 27;
            this.lblWarning.Text = "Sezione disabilitata in quanto sono associati al\'impegnativa più meta movimenti c" +
    "he hanno una anagrafica distinta e, la fase di spesa associata all\'anagrafica è " +
    "la prima";
            // 
            // gboxUPB
            // 
            this.gboxUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxUPB.Controls.Add(this.txtUPB);
            this.gboxUPB.Controls.Add(this.btnUPB);
            this.gboxUPB.Controls.Add(this.txtDescrUPB);
            this.gboxUPB.Location = new System.Drawing.Point(16, 13);
            this.gboxUPB.Name = "gboxUPB";
            this.gboxUPB.Size = new System.Drawing.Size(416, 82);
            this.gboxUPB.TabIndex = 3;
            this.gboxUPB.TabStop = false;
            this.gboxUPB.Tag = "AutoChoose.txtUPB.default.(active=\'S\')";
            // 
            // txtUPB
            // 
            this.txtUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUPB.Location = new System.Drawing.Point(6, 53);
            this.txtUPB.Name = "txtUPB";
            this.txtUPB.Size = new System.Drawing.Size(132, 20);
            this.txtUPB.TabIndex = 7;
            this.txtUPB.Tag = "upb.codeupb?x";
            // 
            // btnUPB
            // 
            this.btnUPB.Location = new System.Drawing.Point(7, 19);
            this.btnUPB.Name = "btnUPB";
            this.btnUPB.Size = new System.Drawing.Size(130, 24);
            this.btnUPB.TabIndex = 1;
            this.btnUPB.TabStop = false;
            this.btnUPB.Tag = "manage.upb.tree";
            this.btnUPB.Text = "UPB";
            // 
            // txtDescrUPB
            // 
            this.txtDescrUPB.Location = new System.Drawing.Point(144, 14);
            this.txtDescrUPB.Multiline = true;
            this.txtDescrUPB.Name = "txtDescrUPB";
            this.txtDescrUPB.ReadOnly = true;
            this.txtDescrUPB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescrUPB.Size = new System.Drawing.Size(264, 62);
            this.txtDescrUPB.TabIndex = 2;
            this.txtDescrUPB.TabStop = false;
            this.txtDescrUPB.Tag = "upb.title";
            // 
            // FrmAdmPay_Assessment_Detail
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 540);
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.gboxEntrata);
            this.Controls.Add(this.chkEntrata);
            this.Controls.Add(this.gboxNormale);
            this.Controls.Add(this.txtImporto);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Name = "FrmAdmPay_Assessment_Detail";
            this.Text = "FrmAdmPay_Assessment_Detail";
            this.gboxEntrata.ResumeLayout(false);
            this.gboxEntrata.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.gboxNormale.ResumeLayout(false);
            this.grpBilancio.ResumeLayout(false);
            this.grpBilancio.PerformLayout();
            this.gboxUPB.ResumeLayout(false);
            this.gboxUPB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox gboxEntrata;
        private System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtEserc;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbFaseEntrata;
        private System.Windows.Forms.Button btnEntrata;
        private System.Windows.Forms.CheckBox chkEntrata;
        private System.Windows.Forms.GroupBox gboxNormale;
        public System.Windows.Forms.GroupBox grpBilancio;
        private System.Windows.Forms.CheckBox chkListTitle;
        private System.Windows.Forms.CheckBox chkFilterAvailable;
        private System.Windows.Forms.Button btnBilancio;
        public System.Windows.Forms.TextBox txtCodiceBilancio;
        private System.Windows.Forms.TextBox txtDenominazioneBilancio;
        private System.Windows.Forms.TextBox txtImporto;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        public vistaForm DS;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.GroupBox gboxUPB;
        public System.Windows.Forms.TextBox txtUPB;
        private System.Windows.Forms.Button btnUPB;
        private System.Windows.Forms.TextBox txtDescrUPB;
    }
}
