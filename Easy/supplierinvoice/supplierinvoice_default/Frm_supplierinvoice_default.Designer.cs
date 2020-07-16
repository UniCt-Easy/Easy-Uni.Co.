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

namespace supplierinvoice_default
{
    partial class Frm_supplierinvoice_default
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
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtCredDeb = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDataDoc = new System.Windows.Forms.TextBox();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.frpDocumento = new System.Windows.Forms.GroupBox();
            this.txtNumDocumento = new System.Windows.Forms.TextBox();
            this.txtEsercDocumento = new System.Windows.Forms.TextBox();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.DS = new supplierinvoice_default.vistaForm();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grpGenerale = new System.Windows.Forms.GroupBox();
            this.groupBox6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.frpDocumento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grpGenerale.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.textBox10);
            this.groupBox6.Location = new System.Drawing.Point(15, 243);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(448, 96);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Descrizione ";
            // 
            // textBox10
            // 
            this.textBox10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox10.Location = new System.Drawing.Point(12, 16);
            this.textBox10.Multiline = true;
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(424, 72);
            this.textBox10.TabIndex = 0;
            this.textBox10.Tag = "supplierinvoice.description";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.txtCredDeb);
            this.groupBox3.Location = new System.Drawing.Point(15, 66);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(448, 40);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Tag = "AutoChoose.txtCredDeb.lista.(active=\'S\')";
            this.groupBox3.Text = " Fornitore";
            // 
            // txtCredDeb
            // 
            this.txtCredDeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCredDeb.Location = new System.Drawing.Point(12, 16);
            this.txtCredDeb.Name = "txtCredDeb";
            this.txtCredDeb.Size = new System.Drawing.Size(424, 20);
            this.txtCredDeb.TabIndex = 0;
            this.txtCredDeb.Tag = "registry.title";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtDataDoc);
            this.groupBox2.Controls.Add(this.txtDocumento);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(15, 193);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(448, 48);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Documento";
            // 
            // txtDataDoc
            // 
            this.txtDataDoc.Location = new System.Drawing.Point(304, 22);
            this.txtDataDoc.Name = "txtDataDoc";
            this.txtDataDoc.Size = new System.Drawing.Size(80, 20);
            this.txtDataDoc.TabIndex = 2;
            this.txtDataDoc.Tag = "supplierinvoice.docdate";
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(80, 22);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(160, 20);
            this.txtDocumento.TabIndex = 1;
            this.txtDocumento.Tag = "supplierinvoice.doc";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(256, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Data";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Documento";
            // 
            // frpDocumento
            // 
            this.frpDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.frpDocumento.Controls.Add(this.txtNumDocumento);
            this.frpDocumento.Controls.Add(this.txtEsercDocumento);
            this.frpDocumento.Controls.Add(this.cboTipo);
            this.frpDocumento.Controls.Add(this.label3);
            this.frpDocumento.Controls.Add(this.label2);
            this.frpDocumento.Location = new System.Drawing.Point(15, 111);
            this.frpDocumento.Name = "frpDocumento";
            this.frpDocumento.Size = new System.Drawing.Size(448, 80);
            this.frpDocumento.TabIndex = 2;
            this.frpDocumento.TabStop = false;
            this.frpDocumento.Text = "Tipo documento";
            // 
            // txtNumDocumento
            // 
            this.txtNumDocumento.Location = new System.Drawing.Point(200, 48);
            this.txtNumDocumento.Name = "txtNumDocumento";
            this.txtNumDocumento.Size = new System.Drawing.Size(64, 20);
            this.txtNumDocumento.TabIndex = 3;
            this.txtNumDocumento.Tag = "supplierinvoice.ninv";
            // 
            // txtEsercDocumento
            // 
            this.txtEsercDocumento.Location = new System.Drawing.Point(72, 48);
            this.txtEsercDocumento.Name = "txtEsercDocumento";
            this.txtEsercDocumento.Size = new System.Drawing.Size(64, 20);
            this.txtEsercDocumento.TabIndex = 2;
            this.txtEsercDocumento.Tag = "supplierinvoice.yinv.year";
            // 
            // cboTipo
            // 
            this.cboTipo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTipo.DataSource = this.DS.invoicekind;
            this.cboTipo.DisplayMember = "description";
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.Location = new System.Drawing.Point(72, 24);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(320, 21);
            this.cboTipo.TabIndex = 1;
            this.cboTipo.Tag = "supplierinvoice.idinvkind";
            this.cboTipo.ValueMember = "idinvkind";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(144, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Numero";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Esercizio";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DataSource = this.DS.dbdepartment;
            this.comboBox1.DisplayMember = "description";
            this.comboBox1.Location = new System.Drawing.Point(16, 23);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(420, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.Tag = "supplierinvoice.iddbdepartment";
            this.comboBox1.ValueMember = "iddbdepartment";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Location = new System.Drawing.Point(15, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(448, 54);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dipartimento";
            // 
            // grpGenerale
            // 
            this.grpGenerale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpGenerale.Controls.Add(this.groupBox6);
            this.grpGenerale.Controls.Add(this.groupBox1);
            this.grpGenerale.Controls.Add(this.groupBox3);
            this.grpGenerale.Controls.Add(this.frpDocumento);
            this.grpGenerale.Controls.Add(this.groupBox2);
            this.grpGenerale.Location = new System.Drawing.Point(6, 1);
            this.grpGenerale.Name = "grpGenerale";
            this.grpGenerale.Size = new System.Drawing.Size(478, 354);
            this.grpGenerale.TabIndex = 0;
            this.grpGenerale.TabStop = false;
            // 
            // Frm_supplierinvoice_default
            // 
            this.ClientSize = new System.Drawing.Size(496, 362);
            this.Controls.Add(this.grpGenerale);
            this.Name = "Frm_supplierinvoice_default";
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.frpDocumento.ResumeLayout(false);
            this.frpDocumento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.grpGenerale.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtCredDeb;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDataDoc;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox frpDocumento;
        private System.Windows.Forms.TextBox txtNumDocumento;
        private System.Windows.Forms.TextBox txtEsercDocumento;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        public vistaForm DS;
        private System.Windows.Forms.GroupBox grpGenerale;
    }
}