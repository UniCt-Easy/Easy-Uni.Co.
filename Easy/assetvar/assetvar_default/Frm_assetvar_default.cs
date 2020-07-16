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
using metadatalibrary;

namespace assetvar_default {//VariazionePatrimonio//
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Frm_assetvar_default : System.Windows.Forms.Form {
		private System.Windows.Forms.Label labelEsercizio;
		public vistaForm DS;
		private System.Windows.Forms.Label labelNumero;
		private System.Windows.Forms.TextBox textBoxNumeroVariazione;
		private System.Windows.Forms.Label labelEnteInventariale;
		private System.Windows.Forms.TextBox txtEsercizio;
		private System.Windows.Forms.ComboBox comboBoxEnteInventario;
		private System.Windows.Forms.Label labelDescrizione;
		private System.Windows.Forms.TextBox textBoxDescrizione;
		private System.Windows.Forms.TextBox textBoxProvvedimento;
		private System.Windows.Forms.Label labelDataProvv;
		private System.Windows.Forms.Label labelDataContabile;
		private System.Windows.Forms.TextBox textBoxDataProvv;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxNumProvv;
		private System.Windows.Forms.TextBox textBoxDataContabile;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button buttonElimina;
		private System.Windows.Forms.Button buttonModifica;
		private System.Windows.Forms.Button buttonInserisci;
		private System.Windows.Forms.DataGrid dataGridDettVarPatrimonio;
		private System.Windows.Forms.Label labelImporto;
		private System.Windows.Forms.TextBox textBoxImporto;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox checkBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_assetvar_default() {
			InitializeComponent();
		}

        MetaData Meta;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
        }

		public void  MetaData_AfterClear() {
			txtEsercizio.Text = Meta.GetSys("esercizio").ToString();
			textBoxImporto.Text = "";
            txtEsercizio.ReadOnly = false;
		}

		public void MetaData_AfterFill() {
            txtEsercizio.ReadOnly = true;
			textBoxImporto.Text = MetaData.SumColumn(DS.assetvardetail, 
				DS.assetvardetail.Columns["amount"].ColumnName).ToString("c");
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
            this.labelEsercizio = new System.Windows.Forms.Label();
            this.DS = new assetvar_default.vistaForm();
            this.txtEsercizio = new System.Windows.Forms.TextBox();
            this.labelNumero = new System.Windows.Forms.Label();
            this.textBoxNumeroVariazione = new System.Windows.Forms.TextBox();
            this.labelEnteInventariale = new System.Windows.Forms.Label();
            this.comboBoxEnteInventario = new System.Windows.Forms.ComboBox();
            this.labelDescrizione = new System.Windows.Forms.Label();
            this.textBoxDescrizione = new System.Windows.Forms.TextBox();
            this.textBoxProvvedimento = new System.Windows.Forms.TextBox();
            this.labelDataProvv = new System.Windows.Forms.Label();
            this.labelDataContabile = new System.Windows.Forms.Label();
            this.textBoxDataContabile = new System.Windows.Forms.TextBox();
            this.textBoxDataProvv = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNumProvv = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelImporto = new System.Windows.Forms.Label();
            this.textBoxImporto = new System.Windows.Forms.TextBox();
            this.buttonElimina = new System.Windows.Forms.Button();
            this.buttonModifica = new System.Windows.Forms.Button();
            this.buttonInserisci = new System.Windows.Forms.Button();
            this.dataGridDettVarPatrimonio = new System.Windows.Forms.DataGrid();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDettVarPatrimonio)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelEsercizio
            // 
            this.labelEsercizio.Location = new System.Drawing.Point(8, 18);
            this.labelEsercizio.Name = "labelEsercizio";
            this.labelEsercizio.Size = new System.Drawing.Size(56, 16);
            this.labelEsercizio.TabIndex = 0;
            this.labelEsercizio.Text = "Esercizio";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // txtEsercizio
            // 
            this.txtEsercizio.Location = new System.Drawing.Point(56, 16);
            this.txtEsercizio.Name = "txtEsercizio";
            this.txtEsercizio.Size = new System.Drawing.Size(64, 20);
            this.txtEsercizio.TabIndex = 1;
            this.txtEsercizio.Tag = "assetvar.yvar.year";
            // 
            // labelNumero
            // 
            this.labelNumero.Location = new System.Drawing.Point(8, 50);
            this.labelNumero.Name = "labelNumero";
            this.labelNumero.Size = new System.Drawing.Size(48, 16);
            this.labelNumero.TabIndex = 2;
            this.labelNumero.Text = "Numero";
            // 
            // textBoxNumeroVariazione
            // 
            this.textBoxNumeroVariazione.Location = new System.Drawing.Point(56, 48);
            this.textBoxNumeroVariazione.Name = "textBoxNumeroVariazione";
            this.textBoxNumeroVariazione.Size = new System.Drawing.Size(64, 20);
            this.textBoxNumeroVariazione.TabIndex = 2;
            this.textBoxNumeroVariazione.Tag = "assetvar.nvar";
            // 
            // labelEnteInventariale
            // 
            this.labelEnteInventariale.Location = new System.Drawing.Point(136, 18);
            this.labelEnteInventariale.Name = "labelEnteInventariale";
            this.labelEnteInventariale.Size = new System.Drawing.Size(96, 16);
            this.labelEnteInventariale.TabIndex = 5;
            this.labelEnteInventariale.Text = "Ente inventariale";
            // 
            // comboBoxEnteInventario
            // 
            this.comboBoxEnteInventario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxEnteInventario.DataSource = this.DS.inventoryagency;
            this.comboBoxEnteInventario.DisplayMember = "description";
            this.comboBoxEnteInventario.Location = new System.Drawing.Point(224, 16);
            this.comboBoxEnteInventario.Name = "comboBoxEnteInventario";
            this.comboBoxEnteInventario.Size = new System.Drawing.Size(417, 21);
            this.comboBoxEnteInventario.TabIndex = 3;
            this.comboBoxEnteInventario.Tag = "assetvar.idinventoryagency.(active=\'S\')";
            this.comboBoxEnteInventario.ValueMember = "idinventoryagency";
            // 
            // labelDescrizione
            // 
            this.labelDescrizione.Location = new System.Drawing.Point(136, 48);
            this.labelDescrizione.Name = "labelDescrizione";
            this.labelDescrizione.Size = new System.Drawing.Size(64, 16);
            this.labelDescrizione.TabIndex = 7;
            this.labelDescrizione.Text = "Descrizione";
            // 
            // textBoxDescrizione
            // 
            this.textBoxDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDescrizione.Location = new System.Drawing.Point(224, 48);
            this.textBoxDescrizione.Multiline = true;
            this.textBoxDescrizione.Name = "textBoxDescrizione";
            this.textBoxDescrizione.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDescrizione.Size = new System.Drawing.Size(417, 40);
            this.textBoxDescrizione.TabIndex = 4;
            this.textBoxDescrizione.Tag = "assetvar.description";
            // 
            // textBoxProvvedimento
            // 
            this.textBoxProvvedimento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxProvvedimento.Location = new System.Drawing.Point(8, 16);
            this.textBoxProvvedimento.Name = "textBoxProvvedimento";
            this.textBoxProvvedimento.Size = new System.Drawing.Size(609, 20);
            this.textBoxProvvedimento.TabIndex = 1;
            this.textBoxProvvedimento.Tag = "assetvar.enactment";
            // 
            // labelDataProvv
            // 
            this.labelDataProvv.Location = new System.Drawing.Point(8, 48);
            this.labelDataProvv.Name = "labelDataProvv";
            this.labelDataProvv.Size = new System.Drawing.Size(32, 16);
            this.labelDataProvv.TabIndex = 11;
            this.labelDataProvv.Text = "Data:";
            this.labelDataProvv.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelDataContabile
            // 
            this.labelDataContabile.Location = new System.Drawing.Point(8, 200);
            this.labelDataContabile.Name = "labelDataContabile";
            this.labelDataContabile.Size = new System.Drawing.Size(80, 16);
            this.labelDataContabile.TabIndex = 15;
            this.labelDataContabile.Text = "Data contabile:";
            this.labelDataContabile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxDataContabile
            // 
            this.textBoxDataContabile.Location = new System.Drawing.Point(96, 200);
            this.textBoxDataContabile.Name = "textBoxDataContabile";
            this.textBoxDataContabile.Size = new System.Drawing.Size(88, 20);
            this.textBoxDataContabile.TabIndex = 7;
            this.textBoxDataContabile.Tag = "assetvar.adate";
            // 
            // textBoxDataProvv
            // 
            this.textBoxDataProvv.Location = new System.Drawing.Point(48, 48);
            this.textBoxDataProvv.Name = "textBoxDataProvv";
            this.textBoxDataProvv.Size = new System.Drawing.Size(96, 20);
            this.textBoxDataProvv.TabIndex = 2;
            this.textBoxDataProvv.Tag = "assetvar.enactmentdate";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(248, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Numero:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBoxNumProvv
            // 
            this.textBoxNumProvv.Location = new System.Drawing.Point(304, 48);
            this.textBoxNumProvv.Name = "textBoxNumProvv";
            this.textBoxNumProvv.Size = new System.Drawing.Size(72, 20);
            this.textBoxNumProvv.TabIndex = 3;
            this.textBoxNumProvv.Tag = "assetvar.nenactment";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.labelImporto);
            this.groupBox1.Controls.Add(this.textBoxImporto);
            this.groupBox1.Controls.Add(this.buttonElimina);
            this.groupBox1.Controls.Add(this.buttonModifica);
            this.groupBox1.Controls.Add(this.buttonInserisci);
            this.groupBox1.Controls.Add(this.dataGridDettVarPatrimonio);
            this.groupBox1.Location = new System.Drawing.Point(8, 224);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(633, 192);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dettaglio";
            // 
            // labelImporto
            // 
            this.labelImporto.Location = new System.Drawing.Point(336, 24);
            this.labelImporto.Name = "labelImporto";
            this.labelImporto.Size = new System.Drawing.Size(48, 16);
            this.labelImporto.TabIndex = 28;
            this.labelImporto.Text = "Importo";
            // 
            // textBoxImporto
            // 
            this.textBoxImporto.Location = new System.Drawing.Point(392, 24);
            this.textBoxImporto.Name = "textBoxImporto";
            this.textBoxImporto.ReadOnly = true;
            this.textBoxImporto.Size = new System.Drawing.Size(104, 20);
            this.textBoxImporto.TabIndex = 27;
            this.textBoxImporto.TabStop = false;
            this.textBoxImporto.Tag = "";
            // 
            // buttonElimina
            // 
            this.buttonElimina.Location = new System.Drawing.Point(176, 24);
            this.buttonElimina.Name = "buttonElimina";
            this.buttonElimina.Size = new System.Drawing.Size(75, 23);
            this.buttonElimina.TabIndex = 25;
            this.buttonElimina.TabStop = false;
            this.buttonElimina.Tag = "delete";
            this.buttonElimina.Text = "Elimina";
            // 
            // buttonModifica
            // 
            this.buttonModifica.Location = new System.Drawing.Point(96, 24);
            this.buttonModifica.Name = "buttonModifica";
            this.buttonModifica.Size = new System.Drawing.Size(75, 23);
            this.buttonModifica.TabIndex = 24;
            this.buttonModifica.TabStop = false;
            this.buttonModifica.Tag = "edit.detail";
            this.buttonModifica.Text = "Modifica";
            // 
            // buttonInserisci
            // 
            this.buttonInserisci.Location = new System.Drawing.Point(16, 24);
            this.buttonInserisci.Name = "buttonInserisci";
            this.buttonInserisci.Size = new System.Drawing.Size(75, 23);
            this.buttonInserisci.TabIndex = 23;
            this.buttonInserisci.TabStop = false;
            this.buttonInserisci.Tag = "insert.detail";
            this.buttonInserisci.Text = "Inserisci";
            // 
            // dataGridDettVarPatrimonio
            // 
            this.dataGridDettVarPatrimonio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridDettVarPatrimonio.DataMember = "";
            this.dataGridDettVarPatrimonio.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridDettVarPatrimonio.Location = new System.Drawing.Point(8, 56);
            this.dataGridDettVarPatrimonio.Name = "dataGridDettVarPatrimonio";
            this.dataGridDettVarPatrimonio.RowHeaderWidth = 0;
            this.dataGridDettVarPatrimonio.Size = new System.Drawing.Size(617, 128);
            this.dataGridDettVarPatrimonio.TabIndex = 26;
            this.dataGridDettVarPatrimonio.Tag = "assetvardetail.default.detail";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.textBoxProvvedimento);
            this.groupBox2.Controls.Add(this.labelDataProvv);
            this.groupBox2.Controls.Add(this.textBoxDataProvv);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBoxNumProvv);
            this.groupBox2.Location = new System.Drawing.Point(16, 120);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(625, 72);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Provvedimento";
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(24, 88);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(152, 16);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Tag = "assetvar.flag:#0";
            this.checkBox1.Text = "Consistenza Iniziale";
            // 
            // Frm_assetvar_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(649, 422);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBoxDataContabile);
            this.Controls.Add(this.labelDataContabile);
            this.Controls.Add(this.textBoxDescrizione);
            this.Controls.Add(this.labelDescrizione);
            this.Controls.Add(this.comboBoxEnteInventario);
            this.Controls.Add(this.labelEnteInventariale);
            this.Controls.Add(this.textBoxNumeroVariazione);
            this.Controls.Add(this.labelNumero);
            this.Controls.Add(this.txtEsercizio);
            this.Controls.Add(this.labelEsercizio);
            this.Name = "Frm_assetvar_default";
            this.Text = "Variazione patrimoniale";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDettVarPatrimonio)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

	}
}