
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


namespace pettycashoperation_wizardinvoicedetail {
    partial class FrmAskInfo {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
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
            this.gboxUPB = new System.Windows.Forms.GroupBox();
            this.cmbUPB = new System.Windows.Forms.ComboBox();
            this.gboxBilAnnuale = new System.Windows.Forms.GroupBox();
            this.chkListTitle = new System.Windows.Forms.CheckBox();
            this.chkListManager = new System.Windows.Forms.CheckBox();
            this.chkFilterAvailable = new System.Windows.Forms.CheckBox();
            this.btnBilancio = new System.Windows.Forms.Button();
            this.txtBilancio = new System.Windows.Forms.TextBox();
            this.txtDenominazioneBilancio = new System.Windows.Forms.TextBox();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.txtImporto = new System.Windows.Forms.TextBox();
            this.gboxManager = new System.Windows.Forms.GroupBox();
            this.cmbResponsabile = new System.Windows.Forms.ComboBox();
            this.BtnAnnulla = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.gboxSpesa = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtEserc = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbFaseSpesa = new System.Windows.Forms.ComboBox();
            this.btnSpesa = new System.Windows.Forms.Button();
            this.chkSpesa = new System.Windows.Forms.CheckBox();
            this.gboxUPB.SuspendLayout();
            this.gboxBilAnnuale.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.gboxManager.SuspendLayout();
            this.gboxSpesa.SuspendLayout();
            this.SuspendLayout();
            // 
            // gboxUPB
            // 
            this.gboxUPB.Controls.Add(this.cmbUPB);
            this.gboxUPB.Location = new System.Drawing.Point(8, 96);
            this.gboxUPB.Name = "gboxUPB";
            this.gboxUPB.Size = new System.Drawing.Size(314, 43);
            this.gboxUPB.TabIndex = 20;
            this.gboxUPB.TabStop = false;
            this.gboxUPB.Tag = "";
            this.gboxUPB.Text = "UPB da associare ai dettagli ai quali non è stato attribuito";
            // 
            // cmbUPB
            // 
            this.cmbUPB.DisplayMember = "codeupb";
            this.cmbUPB.Location = new System.Drawing.Point(8, 17);
            this.cmbUPB.Name = "cmbUPB";
            this.cmbUPB.Size = new System.Drawing.Size(300, 21);
            this.cmbUPB.TabIndex = 10;
            this.cmbUPB.Tag = "";
            this.cmbUPB.ValueMember = "idupb";
            this.cmbUPB.SelectedIndexChanged += new System.EventHandler(this.cmbUPB_SelectedIndexChanged);
            // 
            // gboxBilAnnuale
            // 
            this.gboxBilAnnuale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxBilAnnuale.Controls.Add(this.chkListTitle);
            this.gboxBilAnnuale.Controls.Add(this.chkListManager);
            this.gboxBilAnnuale.Controls.Add(this.chkFilterAvailable);
            this.gboxBilAnnuale.Controls.Add(this.btnBilancio);
            this.gboxBilAnnuale.Controls.Add(this.txtBilancio);
            this.gboxBilAnnuale.Controls.Add(this.txtDenominazioneBilancio);
            this.gboxBilAnnuale.Location = new System.Drawing.Point(8, 139);
            this.gboxBilAnnuale.Name = "gboxBilAnnuale";
            this.gboxBilAnnuale.Size = new System.Drawing.Size(314, 104);
            this.gboxBilAnnuale.TabIndex = 19;
            this.gboxBilAnnuale.TabStop = false;
            this.gboxBilAnnuale.Tag = "AutoManage.txtCodiceBilancio.treesupb.(idupb=\'0001\')";
            // 
            // chkListTitle
            // 
            this.chkListTitle.Location = new System.Drawing.Point(8, 40);
            this.chkListTitle.Name = "chkListTitle";
            this.chkListTitle.Size = new System.Drawing.Size(296, 16);
            this.chkListTitle.TabIndex = 12;
            this.chkListTitle.TabStop = false;
            this.chkListTitle.Text = "Cerca per denominazione";
            // 
            // chkListManager
            // 
            this.chkListManager.Location = new System.Drawing.Point(8, 24);
            this.chkListManager.Name = "chkListManager";
            this.chkListManager.Size = new System.Drawing.Size(288, 16);
            this.chkListManager.TabIndex = 11;
            this.chkListManager.TabStop = false;
            this.chkListManager.Text = "Elenca per responsabile";
            // 
            // chkFilterAvailable
            // 
            this.chkFilterAvailable.Checked = true;
            this.chkFilterAvailable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFilterAvailable.Location = new System.Drawing.Point(8, 8);
            this.chkFilterAvailable.Name = "chkFilterAvailable";
            this.chkFilterAvailable.Size = new System.Drawing.Size(288, 16);
            this.chkFilterAvailable.TabIndex = 10;
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
            this.btnBilancio.Location = new System.Drawing.Point(8, 56);
            this.btnBilancio.Name = "btnBilancio";
            this.btnBilancio.Size = new System.Drawing.Size(112, 20);
            this.btnBilancio.TabIndex = 1;
            this.btnBilancio.TabStop = false;
            this.btnBilancio.Tag = "";
            this.btnBilancio.Text = "Bilancio";
            this.btnBilancio.UseVisualStyleBackColor = false;
            this.btnBilancio.Click += new System.EventHandler(this.btnBilancio_Click);
            // 
            // txtBilancio
            // 
            this.txtBilancio.Location = new System.Drawing.Point(8, 80);
            this.txtBilancio.Name = "txtBilancio";
            this.txtBilancio.Size = new System.Drawing.Size(112, 20);
            this.txtBilancio.TabIndex = 2;
            this.txtBilancio.Tag = "finview.codefin?x";
            this.txtBilancio.Click += new System.EventHandler(this.txtCodiceBilancio_Leave);
            this.txtBilancio.Leave += new System.EventHandler(this.txtCodiceBilancio_Leave);
            // 
            // txtDenominazioneBilancio
            // 
            this.txtDenominazioneBilancio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenominazioneBilancio.Location = new System.Drawing.Point(128, 56);
            this.txtDenominazioneBilancio.Multiline = true;
            this.txtDenominazioneBilancio.Name = "txtDenominazioneBilancio";
            this.txtDenominazioneBilancio.ReadOnly = true;
            this.txtDenominazioneBilancio.Size = new System.Drawing.Size(178, 42);
            this.txtDenominazioneBilancio.TabIndex = 3;
            this.txtDenominazioneBilancio.TabStop = false;
            this.txtDenominazioneBilancio.Tag = "finview.title";
            // 
            // groupBox18
            // 
            this.groupBox18.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox18.Controls.Add(this.txtImporto);
            this.groupBox18.Location = new System.Drawing.Point(8, 8);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(314, 40);
            this.groupBox18.TabIndex = 18;
            this.groupBox18.TabStop = false;
            this.groupBox18.Tag = "";
            this.groupBox18.Text = "Importo del movimento che sarà generato";
            // 
            // txtImporto
            // 
            this.txtImporto.Location = new System.Drawing.Point(8, 16);
            this.txtImporto.Name = "txtImporto";
            this.txtImporto.Size = new System.Drawing.Size(112, 20);
            this.txtImporto.TabIndex = 1;
            this.txtImporto.Tag = "";
            this.txtImporto.Leave += new System.EventHandler(this.txtImporto_Leave);
            // 
            // gboxManager
            // 
            this.gboxManager.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxManager.Controls.Add(this.cmbResponsabile);
            this.gboxManager.Location = new System.Drawing.Point(8, 48);
            this.gboxManager.Name = "gboxManager";
            this.gboxManager.Size = new System.Drawing.Size(314, 40);
            this.gboxManager.TabIndex = 17;
            this.gboxManager.TabStop = false;
            this.gboxManager.Text = "Responsabile";
            // 
            // cmbResponsabile
            // 
            this.cmbResponsabile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbResponsabile.DisplayMember = "title";
            this.cmbResponsabile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResponsabile.ItemHeight = 13;
            this.cmbResponsabile.Location = new System.Drawing.Point(8, 14);
            this.cmbResponsabile.Name = "cmbResponsabile";
            this.cmbResponsabile.Size = new System.Drawing.Size(298, 21);
            this.cmbResponsabile.TabIndex = 1;
            this.cmbResponsabile.Tag = "";
            this.cmbResponsabile.ValueMember = "idman";
            // 
            // BtnAnnulla
            // 
            this.BtnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnAnnulla.Location = new System.Drawing.Point(328, 276);
            this.BtnAnnulla.Name = "BtnAnnulla";
            this.BtnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.BtnAnnulla.TabIndex = 16;
            this.BtnAnnulla.Text = "Annulla";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(216, 276);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 15;
            this.btnOk.Text = "Ok";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // gboxSpesa
            // 
            this.gboxSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxSpesa.Controls.Add(this.label7);
            this.gboxSpesa.Controls.Add(this.txtNum);
            this.gboxSpesa.Controls.Add(this.label13);
            this.gboxSpesa.Controls.Add(this.txtEserc);
            this.gboxSpesa.Controls.Add(this.label12);
            this.gboxSpesa.Controls.Add(this.cmbFaseSpesa);
            this.gboxSpesa.Controls.Add(this.btnSpesa);
            this.gboxSpesa.Location = new System.Drawing.Point(328, 139);
            this.gboxSpesa.Name = "gboxSpesa";
            this.gboxSpesa.Size = new System.Drawing.Size(264, 104);
            this.gboxSpesa.TabIndex = 22;
            this.gboxSpesa.TabStop = false;
            this.gboxSpesa.Text = "Movimento di Spesa a cui collegare il reintegro";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(6, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 16);
            this.label7.TabIndex = 5;
            this.label7.Text = "Fase";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNum
            // 
            this.txtNum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNum.Location = new System.Drawing.Point(194, 72);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(63, 20);
            this.txtNum.TabIndex = 4;
            this.txtNum.Tag = "";
            this.txtNum.Leave += new System.EventHandler(this.txtNum_Leave);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(148, 73);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 16);
            this.label13.TabIndex = 4;
            this.label13.Text = "Num.";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEserc
            // 
            this.txtEserc.Location = new System.Drawing.Point(52, 69);
            this.txtEserc.Name = "txtEserc";
            this.txtEserc.Size = new System.Drawing.Size(56, 20);
            this.txtEserc.TabIndex = 3;
            this.txtEserc.Tag = "";
            this.txtEserc.Leave += new System.EventHandler(this.txtEserc_Leave);
            this.txtEserc.Enter += new System.EventHandler(this.txtEserc_Enter);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(15, 69);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 16);
            this.label12.TabIndex = 2;
            this.label12.Text = "Eserc.";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbFaseSpesa
            // 
            this.cmbFaseSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFaseSpesa.DisplayMember = "description";
            this.cmbFaseSpesa.Location = new System.Drawing.Point(52, 45);
            this.cmbFaseSpesa.Name = "cmbFaseSpesa";
            this.cmbFaseSpesa.Size = new System.Drawing.Size(206, 21);
            this.cmbFaseSpesa.TabIndex = 2;
            this.cmbFaseSpesa.Tag = "";
            this.cmbFaseSpesa.ValueMember = "nphase";
            // 
            // btnSpesa
            // 
            this.btnSpesa.Location = new System.Drawing.Point(6, 17);
            this.btnSpesa.Name = "btnSpesa";
            this.btnSpesa.Size = new System.Drawing.Size(128, 23);
            this.btnSpesa.TabIndex = 1;
            this.btnSpesa.TabStop = false;
            this.btnSpesa.Text = "Scegli Movimento";
            this.btnSpesa.Click += new System.EventHandler(this.btnSpesa_Click);
            // 
            // chkSpesa
            // 
            this.chkSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSpesa.Location = new System.Drawing.Point(330, 115);
            this.chkSpesa.Name = "chkSpesa";
            this.chkSpesa.Size = new System.Drawing.Size(256, 16);
            this.chkSpesa.TabIndex = 21;
            this.chkSpesa.Text = "Seleziona  movimento di spesa per reintegro";
            this.chkSpesa.CheckedChanged += new System.EventHandler(this.chkSpesa_CheckedChanged);
            // 
            // FrmAskInfo
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 311);
            this.Controls.Add(this.gboxSpesa);
            this.Controls.Add(this.gboxUPB);
            this.Controls.Add(this.chkSpesa);
            this.Controls.Add(this.gboxBilAnnuale);
            this.Controls.Add(this.groupBox18);
            this.Controls.Add(this.gboxManager);
            this.Controls.Add(this.BtnAnnulla);
            this.Controls.Add(this.btnOk);
            this.Name = "FrmAskInfo";
            this.Text = "Informazioni per l\'imputazione della Piccola Spesa";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FrmAskInfo_Closing);
            this.gboxUPB.ResumeLayout(false);
            this.gboxBilAnnuale.ResumeLayout(false);
            this.gboxBilAnnuale.PerformLayout();
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            this.gboxManager.ResumeLayout(false);
            this.gboxSpesa.ResumeLayout(false);
            this.gboxSpesa.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gboxUPB;
        private System.Windows.Forms.ComboBox cmbUPB;
        private System.Windows.Forms.GroupBox gboxBilAnnuale;
        private System.Windows.Forms.CheckBox chkListTitle;
        private System.Windows.Forms.CheckBox chkListManager;
        private System.Windows.Forms.CheckBox chkFilterAvailable;
        private System.Windows.Forms.Button btnBilancio;
        private System.Windows.Forms.TextBox txtBilancio;
        private System.Windows.Forms.TextBox txtDenominazioneBilancio;
        private System.Windows.Forms.GroupBox groupBox18;
        private System.Windows.Forms.TextBox txtImporto;
        private System.Windows.Forms.GroupBox gboxManager;
        private System.Windows.Forms.ComboBox cmbResponsabile;
        private System.Windows.Forms.Button BtnAnnulla;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox gboxSpesa;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtEserc;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbFaseSpesa;
        private System.Windows.Forms.Button btnSpesa;
        private System.Windows.Forms.CheckBox chkSpesa;
    }
}
