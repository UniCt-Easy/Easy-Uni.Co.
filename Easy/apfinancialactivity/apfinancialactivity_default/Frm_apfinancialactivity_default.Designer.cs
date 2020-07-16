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

namespace apfinancialactivity_default
{
    partial class Frm_apfinancialactivity_default
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_apfinancialactivity_default));
            this.DS = new apfinancialactivity_default.vistaForm();
            this.tabGeneralita = new System.Windows.Forms.TabPage();
            this.chkAttivo = new System.Windows.Forms.CheckBox();
            this.cmbLivello = new System.Windows.Forms.ComboBox();
            this.txtDenominazione = new System.Windows.Forms.TextBox();
            this.txtCodice = new System.Windows.Forms.TextBox();
            this.lblDenominazione = new System.Windows.Forms.Label();
            this.lblCodice = new System.Windows.Forms.Label();
            this.lblLivello = new System.Windows.Forms.Label();
            this.icons = new System.Windows.Forms.ImageList(this.components);
            this.MetaDataDetail = new System.Windows.Forms.TabControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.treeView1 = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.tabGeneralita.SuspendLayout();
            this.MetaDataDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // tabGeneralita
            // 
            this.tabGeneralita.Controls.Add(this.chkAttivo);
            this.tabGeneralita.Controls.Add(this.cmbLivello);
            this.tabGeneralita.Controls.Add(this.txtDenominazione);
            this.tabGeneralita.Controls.Add(this.txtCodice);
            this.tabGeneralita.Controls.Add(this.lblDenominazione);
            this.tabGeneralita.Controls.Add(this.lblCodice);
            this.tabGeneralita.Controls.Add(this.lblLivello);
            this.tabGeneralita.Location = new System.Drawing.Point(4, 23);
            this.tabGeneralita.Name = "tabGeneralita";
            this.tabGeneralita.Size = new System.Drawing.Size(408, 243);
            this.tabGeneralita.TabIndex = 0;
            this.tabGeneralita.Text = "Principale";
            this.tabGeneralita.UseVisualStyleBackColor = true;
            // 
            // chkAttivo
            // 
            this.chkAttivo.Location = new System.Drawing.Point(328, 16);
            this.chkAttivo.Name = "chkAttivo";
            this.chkAttivo.Size = new System.Drawing.Size(56, 24);
            this.chkAttivo.TabIndex = 53;
            this.chkAttivo.Tag = "apfinancialactivity.active:S:N";
            this.chkAttivo.Text = "Attivo";
            // 
            // cmbLivello
            // 
            this.cmbLivello.DataSource = DS.apfinancialactivitylevel;
            this.cmbLivello.DisplayMember = "description";
            this.cmbLivello.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLivello.Location = new System.Drawing.Point(16, 48);
            this.cmbLivello.Name = "cmbLivello";
            this.cmbLivello.Size = new System.Drawing.Size(168, 21);
            this.cmbLivello.TabIndex = 52;
            this.cmbLivello.Tag = "apfinancialactivity.nlevel";
            this.cmbLivello.ValueMember = "nlevel";
            // 
            // txtDenominazione
            // 
            this.txtDenominazione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenominazione.Location = new System.Drawing.Point(16, 104);
            this.txtDenominazione.Multiline = true;
            this.txtDenominazione.Name = "txtDenominazione";
            this.txtDenominazione.Size = new System.Drawing.Size(376, 56);
            this.txtDenominazione.TabIndex = 46;
            this.txtDenominazione.Tag = "apfinancialactivity.description";
            // 
            // txtCodice
            // 
            this.txtCodice.Location = new System.Drawing.Point(216, 48);
            this.txtCodice.Name = "txtCodice";
            this.txtCodice.Size = new System.Drawing.Size(168, 20);
            this.txtCodice.TabIndex = 45;
            this.txtCodice.Tag = "apfinancialactivity.apfinancialactivitycode";
            // 
            // lblDenominazione
            // 
            this.lblDenominazione.Location = new System.Drawing.Point(16, 88);
            this.lblDenominazione.Name = "lblDenominazione";
            this.lblDenominazione.Size = new System.Drawing.Size(84, 13);
            this.lblDenominazione.TabIndex = 49;
            this.lblDenominazione.Text = "Denominazione:";
            this.lblDenominazione.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCodice
            // 
            this.lblCodice.Location = new System.Drawing.Point(213, 32);
            this.lblCodice.Name = "lblCodice";
            this.lblCodice.Size = new System.Drawing.Size(60, 16);
            this.lblCodice.TabIndex = 48;
            this.lblCodice.Text = "Codice:";
            this.lblCodice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLivello
            // 
            this.lblLivello.Location = new System.Drawing.Point(16, 32);
            this.lblLivello.Name = "lblLivello";
            this.lblLivello.Size = new System.Drawing.Size(104, 14);
            this.lblLivello.TabIndex = 47;
            this.lblLivello.Text = "Livello gerarchico:";
            this.lblLivello.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // icons
            // 
            this.icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("icons.ImageStream")));
            this.icons.TransparentColor = System.Drawing.Color.Transparent;
            this.icons.Images.SetKeyName(0, "");
            this.icons.Images.SetKeyName(1, "");
            // 
            // MetaDataDetail
            // 
            this.MetaDataDetail.Controls.Add(this.tabGeneralita);
            this.MetaDataDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MetaDataDetail.ImageList = this.imageList1;
            this.MetaDataDetail.Location = new System.Drawing.Point(208, 0);
            this.MetaDataDetail.Name = "MetaDataDetail";
            this.MetaDataDetail.SelectedIndex = 0;
            this.MetaDataDetail.Size = new System.Drawing.Size(416, 270);
            this.MetaDataDetail.TabIndex = 46;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.HideSelection = false;
            this.treeView1.ImageIndex = 1;
            this.treeView1.ImageList = this.icons;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.ShowPlusMinus = false;
            this.treeView1.Size = new System.Drawing.Size(208, 270);
            this.treeView1.TabIndex = 45;
            this.treeView1.Tag = "apfinancialactivity.default";
            // 
            // Frm_apfinancialactivity_default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 270);
            this.Controls.Add(this.MetaDataDetail);
            this.Controls.Add(this.treeView1);
            this.Name = "Frm_apfinancialactivity_default";
            this.Text = "Frm_apfinancialactivity_default";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.tabGeneralita.ResumeLayout(false);
            this.tabGeneralita.PerformLayout();
            this.MetaDataDetail.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.TabPage tabGeneralita;
        private System.Windows.Forms.CheckBox chkAttivo;
        private System.Windows.Forms.ComboBox cmbLivello;
        private System.Windows.Forms.TextBox txtDenominazione;
        private System.Windows.Forms.TextBox txtCodice;
        private System.Windows.Forms.Label lblDenominazione;
        private System.Windows.Forms.Label lblCodice;
        private System.Windows.Forms.Label lblLivello;
        private System.Windows.Forms.ImageList icons;
        public System.Windows.Forms.TabControl MetaDataDetail;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TreeView treeView1;

    }
}