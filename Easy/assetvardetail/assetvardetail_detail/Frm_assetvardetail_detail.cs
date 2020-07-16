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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace assetvardetail_detail {
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Frm_assetvardetail_detail : System.Windows.Forms.Form {
		private System.Windows.Forms.GroupBox groupBoxClassificazione;
		private System.Windows.Forms.Button buttonClassificazione;
		private System.Windows.Forms.TextBox textBoxClassificazione;
		private System.Windows.Forms.TextBox textBoxNomeClassificazione;
		private System.Windows.Forms.TextBox textBoxDescrizione;
		private System.Windows.Forms.TextBox textBoxImporto;
		private System.Windows.Forms.RadioButton radioButtonAumento;
		private System.Windows.Forms.RadioButton radioButtonDiminuzione;
		private System.Windows.Forms.Label labelDescrizione;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonAnnulla;
		private System.Windows.Forms.GroupBox groupBoxImporto;
		public vistaForm DS;
		private System.Windows.Forms.GroupBox grpInventario;
		private System.Windows.Forms.ComboBox comboBox1;
        private GroupBox groupBox2;
        private ComboBox cboCausale;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_assetvardetail_detail() {
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if(components != null) {
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_assetvardetail_detail));
            this.groupBoxClassificazione = new System.Windows.Forms.GroupBox();
            this.textBoxNomeClassificazione = new System.Windows.Forms.TextBox();
            this.textBoxClassificazione = new System.Windows.Forms.TextBox();
            this.buttonClassificazione = new System.Windows.Forms.Button();
            this.textBoxDescrizione = new System.Windows.Forms.TextBox();
            this.textBoxImporto = new System.Windows.Forms.TextBox();
            this.radioButtonAumento = new System.Windows.Forms.RadioButton();
            this.radioButtonDiminuzione = new System.Windows.Forms.RadioButton();
            this.labelDescrizione = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonAnnulla = new System.Windows.Forms.Button();
            this.groupBoxImporto = new System.Windows.Forms.GroupBox();
            this.DS = new assetvardetail_detail.vistaForm();
            this.grpInventario = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboCausale = new System.Windows.Forms.ComboBox();
            this.groupBoxClassificazione.SuspendLayout();
            this.groupBoxImporto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.grpInventario.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxClassificazione
            // 
            this.groupBoxClassificazione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxClassificazione.Controls.Add(this.textBoxNomeClassificazione);
            this.groupBoxClassificazione.Controls.Add(this.textBoxClassificazione);
            this.groupBoxClassificazione.Controls.Add(this.buttonClassificazione);
            this.groupBoxClassificazione.Location = new System.Drawing.Point(8, 107);
            this.groupBoxClassificazione.Name = "groupBoxClassificazione";
            this.groupBoxClassificazione.Size = new System.Drawing.Size(400, 88);
            this.groupBoxClassificazione.TabIndex = 2;
            this.groupBoxClassificazione.TabStop = false;
            this.groupBoxClassificazione.Tag = "AutoManage.textBoxClassificazione.tree";
            this.groupBoxClassificazione.Text = "Classificazione";
            // 
            // textBoxNomeClassificazione
            // 
            this.textBoxNomeClassificazione.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNomeClassificazione.Location = new System.Drawing.Point(144, 24);
            this.textBoxNomeClassificazione.Multiline = true;
            this.textBoxNomeClassificazione.Name = "textBoxNomeClassificazione";
            this.textBoxNomeClassificazione.ReadOnly = true;
            this.textBoxNomeClassificazione.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxNomeClassificazione.Size = new System.Drawing.Size(248, 56);
            this.textBoxNomeClassificazione.TabIndex = 2;
            this.textBoxNomeClassificazione.TabStop = false;
            this.textBoxNomeClassificazione.Tag = "inventorytreeview.description";
            // 
            // textBoxClassificazione
            // 
            this.textBoxClassificazione.Location = new System.Drawing.Point(8, 56);
            this.textBoxClassificazione.Name = "textBoxClassificazione";
            this.textBoxClassificazione.Size = new System.Drawing.Size(120, 20);
            this.textBoxClassificazione.TabIndex = 1;
            this.textBoxClassificazione.Tag = "inventorytreeview.codeinv?x";
            // 
            // buttonClassificazione
            // 
            this.buttonClassificazione.Image = ((System.Drawing.Image)(resources.GetObject("buttonClassificazione.Image")));
            this.buttonClassificazione.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonClassificazione.Location = new System.Drawing.Point(8, 24);
            this.buttonClassificazione.Name = "buttonClassificazione";
            this.buttonClassificazione.Size = new System.Drawing.Size(120, 23);
            this.buttonClassificazione.TabIndex = 0;
            this.buttonClassificazione.TabStop = false;
            this.buttonClassificazione.Tag = "manage.inventorytreeview.tree";
            this.buttonClassificazione.Text = "Classificazione";
            // 
            // textBoxDescrizione
            // 
            this.textBoxDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDescrizione.Location = new System.Drawing.Point(8, 227);
            this.textBoxDescrizione.Multiline = true;
            this.textBoxDescrizione.Name = "textBoxDescrizione";
            this.textBoxDescrizione.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDescrizione.Size = new System.Drawing.Size(184, 56);
            this.textBoxDescrizione.TabIndex = 3;
            this.textBoxDescrizione.Tag = "assetvardetail.description";
            // 
            // textBoxImporto
            // 
            this.textBoxImporto.Location = new System.Drawing.Point(8, 32);
            this.textBoxImporto.Name = "textBoxImporto";
            this.textBoxImporto.Size = new System.Drawing.Size(96, 20);
            this.textBoxImporto.TabIndex = 3;
            this.textBoxImporto.Tag = "assetvardetail.amount";
            // 
            // radioButtonAumento
            // 
            this.radioButtonAumento.Checked = true;
            this.radioButtonAumento.Location = new System.Drawing.Point(112, 16);
            this.radioButtonAumento.Name = "radioButtonAumento";
            this.radioButtonAumento.Size = new System.Drawing.Size(72, 24);
            this.radioButtonAumento.TabIndex = 4;
            this.radioButtonAumento.TabStop = true;
            this.radioButtonAumento.Tag = "+";
            this.radioButtonAumento.Text = "Aumento";
            // 
            // radioButtonDiminuzione
            // 
            this.radioButtonDiminuzione.Location = new System.Drawing.Point(112, 40);
            this.radioButtonDiminuzione.Name = "radioButtonDiminuzione";
            this.radioButtonDiminuzione.Size = new System.Drawing.Size(88, 24);
            this.radioButtonDiminuzione.TabIndex = 5;
            this.radioButtonDiminuzione.TabStop = true;
            this.radioButtonDiminuzione.Tag = "-";
            this.radioButtonDiminuzione.Text = "Diminuzione";
            // 
            // labelDescrizione
            // 
            this.labelDescrizione.Location = new System.Drawing.Point(8, 203);
            this.labelDescrizione.Name = "labelDescrizione";
            this.labelDescrizione.Size = new System.Drawing.Size(64, 23);
            this.labelDescrizione.TabIndex = 1;
            this.labelDescrizione.Text = "Descrizione";
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(236, 300);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.TabStop = false;
            this.buttonOK.Tag = "mainsave";
            this.buttonOK.Text = "OK";
            // 
            // buttonAnnulla
            // 
            this.buttonAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonAnnulla.Location = new System.Drawing.Point(332, 300);
            this.buttonAnnulla.Name = "buttonAnnulla";
            this.buttonAnnulla.Size = new System.Drawing.Size(75, 23);
            this.buttonAnnulla.TabIndex = 4;
            this.buttonAnnulla.TabStop = false;
            this.buttonAnnulla.Text = "Annulla";
            // 
            // groupBoxImporto
            // 
            this.groupBoxImporto.Controls.Add(this.radioButtonDiminuzione);
            this.groupBoxImporto.Controls.Add(this.textBoxImporto);
            this.groupBoxImporto.Controls.Add(this.radioButtonAumento);
            this.groupBoxImporto.Location = new System.Drawing.Point(200, 203);
            this.groupBoxImporto.Name = "groupBoxImporto";
            this.groupBoxImporto.Size = new System.Drawing.Size(208, 80);
            this.groupBoxImporto.TabIndex = 4;
            this.groupBoxImporto.TabStop = false;
            this.groupBoxImporto.Tag = "assetvardetail.amount.valuesigned";
            this.groupBoxImporto.Text = "Importo";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // grpInventario
            // 
            this.grpInventario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpInventario.Controls.Add(this.comboBox1);
            this.grpInventario.Location = new System.Drawing.Point(8, 8);
            this.grpInventario.Name = "grpInventario";
            this.grpInventario.Size = new System.Drawing.Size(400, 48);
            this.grpInventario.TabIndex = 1;
            this.grpInventario.TabStop = false;
            this.grpInventario.Text = "Inventario";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DataSource = this.DS.inventory;
            this.comboBox1.DisplayMember = "description";
            this.comboBox1.Location = new System.Drawing.Point(8, 16);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(384, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.Tag = "assetvardetail.idinventory.(active=\'s\')";
            this.comboBox1.ValueMember = "idinventory";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboCausale);
            this.groupBox2.Location = new System.Drawing.Point(8, 59);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(400, 40);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Causale di Carico";
            // 
            // cboCausale
            // 
            this.cboCausale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCausale.DataSource = this.DS.assetloadmotive;
            this.cboCausale.DisplayMember = "description";
            this.cboCausale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCausale.Location = new System.Drawing.Point(8, 16);
            this.cboCausale.Name = "cboCausale";
            this.cboCausale.Size = new System.Drawing.Size(384, 21);
            this.cboCausale.TabIndex = 14;
            this.cboCausale.Tag = "assetvardetail.idmot";
            this.cboCausale.ValueMember = "idmot";
            // 
            // Frm_assetvardetail_detail
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(416, 342);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpInventario);
            this.Controls.Add(this.groupBoxImporto);
            this.Controls.Add(this.buttonAnnulla);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.labelDescrizione);
            this.Controls.Add(this.textBoxDescrizione);
            this.Controls.Add(this.groupBoxClassificazione);
            this.Name = "Frm_assetvardetail_detail";
            this.Text = "Dettaglio variazione";
            this.groupBoxClassificazione.ResumeLayout(false);
            this.groupBoxClassificazione.PerformLayout();
            this.groupBoxImporto.ResumeLayout(false);
            this.groupBoxImporto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.grpInventario.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
	}
}