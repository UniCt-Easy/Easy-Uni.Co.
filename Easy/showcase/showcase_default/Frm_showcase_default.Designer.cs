/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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

namespace showcase_default
{
    partial class Frm_showcase_default
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.grpMagazzino = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtMagDescrizione = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.detailgrid = new System.Windows.Forms.DataGrid();
            this.btnInserisci = new System.Windows.Forms.Button();
            this.btnModifica = new System.Windows.Forms.Button();
            this.btnElimina = new System.Windows.Forms.Button();
            this.DS = new showcase_default.vistaForm();
            this.txtScadenza = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.grpMagazzino.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detailgrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Descrizione";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(116, 13);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(527, 20);
            this.txtTitle.TabIndex = 2;
            this.txtTitle.Tag = "showcase.title";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(116, 40);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(527, 50);
            this.txtDescription.TabIndex = 3;
            this.txtDescription.Tag = "showcase.description";
            // 
            // grpMagazzino
            // 
            this.grpMagazzino.Controls.Add(this.textBox1);
            this.grpMagazzino.Controls.Add(this.txtMagDescrizione);
            this.grpMagazzino.Controls.Add(this.button1);
            this.grpMagazzino.Location = new System.Drawing.Point(12, 125);
            this.grpMagazzino.Name = "grpMagazzino";
            this.grpMagazzino.Size = new System.Drawing.Size(632, 116);
            this.grpMagazzino.TabIndex = 4;
            this.grpMagazzino.TabStop = false;
            this.grpMagazzino.Text = "Magazzino";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(22, 49);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(604, 53);
            this.textBox1.TabIndex = 2;
            this.textBox1.Tag = "store.deliveryaddress";
            // 
            // txtMagDescrizione
            // 
            this.txtMagDescrizione.Location = new System.Drawing.Point(104, 20);
            this.txtMagDescrizione.Name = "txtMagDescrizione";
            this.txtMagDescrizione.Size = new System.Drawing.Size(522, 20);
            this.txtMagDescrizione.TabIndex = 1;
            this.txtMagDescrizione.Tag = "store.description?x";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Tag = "choose.store.default";
            this.button1.Text = "Magazzino";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // detailgrid
            // 
            this.detailgrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.detailgrid.CaptionVisible = false;
            this.detailgrid.DataMember = "";
            this.detailgrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.detailgrid.Location = new System.Drawing.Point(99, 247);
            this.detailgrid.Name = "detailgrid";
            this.detailgrid.Size = new System.Drawing.Size(544, 121);
            this.detailgrid.TabIndex = 15;
            this.detailgrid.Tag = "showcasedetail.list.single";
            // 
            // btnInserisci
            // 
            this.btnInserisci.Location = new System.Drawing.Point(12, 261);
            this.btnInserisci.Name = "btnInserisci";
            this.btnInserisci.Size = new System.Drawing.Size(75, 23);
            this.btnInserisci.TabIndex = 16;
            this.btnInserisci.Tag = "insert.single";
            this.btnInserisci.Text = "Inserisci";
            this.btnInserisci.UseVisualStyleBackColor = true;
            // 
            // btnModifica
            // 
            this.btnModifica.Location = new System.Drawing.Point(12, 290);
            this.btnModifica.Name = "btnModifica";
            this.btnModifica.Size = new System.Drawing.Size(75, 23);
            this.btnModifica.TabIndex = 17;
            this.btnModifica.Tag = "edit.single";
            this.btnModifica.Text = "Modifica";
            this.btnModifica.UseVisualStyleBackColor = true;
            // 
            // btnElimina
            // 
            this.btnElimina.Location = new System.Drawing.Point(12, 319);
            this.btnElimina.Name = "btnElimina";
            this.btnElimina.Size = new System.Drawing.Size(75, 23);
            this.btnElimina.TabIndex = 18;
            this.btnElimina.Tag = "delete.single";
            this.btnElimina.Text = "Elimina";
            this.btnElimina.UseVisualStyleBackColor = true;
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // txtScadenza
            // 
            this.txtScadenza.Location = new System.Drawing.Point(116, 100);
            this.txtScadenza.Name = "txtScadenza";
            this.txtScadenza.Size = new System.Drawing.Size(72, 20);
            this.txtScadenza.TabIndex = 19;
            this.txtScadenza.Tag = "showcase.paymentexpiring";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(14, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 20);
            this.label7.TabIndex = 20;
            this.label7.Text = "N. giorni scadenza";
            // 
            // Frm_showcase_default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 380);
            this.Controls.Add(this.txtScadenza);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnElimina);
            this.Controls.Add(this.btnModifica);
            this.Controls.Add(this.btnInserisci);
            this.Controls.Add(this.detailgrid);
            this.Controls.Add(this.grpMagazzino);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Frm_showcase_default";
            this.Text = "Frm_showcase_default";
            this.grpMagazzino.ResumeLayout(false);
            this.grpMagazzino.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detailgrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.GroupBox grpMagazzino;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtMagDescrizione;
        private System.Windows.Forms.DataGrid detailgrid;
        private System.Windows.Forms.Button btnInserisci;
        private System.Windows.Forms.Button btnModifica;
        private System.Windows.Forms.Button btnElimina;
        public vistaForm DS;
        private System.Windows.Forms.TextBox txtScadenza;
        private System.Windows.Forms.Label label7;
    }
}