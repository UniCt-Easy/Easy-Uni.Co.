/*
    Easy
    Copyright (C) 2020 Universit√† degli Studi di Catania (www.unict.it)
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using metadatalibrary;
using funzioni_configurazione;

namespace asset_dettaglio//dettbeneinventariabile//
{
	/// <summary>
	/// Summary description for frmDettBeneInventariabile.
	/// </summary>
	public class Frm_asset_dettaglio : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		public vistaForm DS;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnAnnulla;
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.ComboBox comboBox1;
		private DataRow entityRow;
		private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox txtEsistenzaCespite;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox grpBene;
		private System.Windows.Forms.TextBox txtDescrizione;
		private System.Windows.Forms.Button btnSelezBene;
        private System.Windows.Forms.TextBox txtNumInv;
        private CheckBox chkTrasmesso;
        private GroupBox gboxUbicazione;
        private DataGrid dataGrid4;
        private Button button7;
        private Button button8;
        private Button button9;
        private GroupBox gboxResponsabile;
        private Button button4;
        private Button button5;
        private Button button6;
        private DataGrid dataGrid3;
        private TabPage tabPageInfoAgg;
        private TabPage tabConsegnatario;
        private GroupBox gboxConsegnatario;
        private Button button1;
        private Button button2;
        private Button button3;
        private DataGrid dataGrid1;
        private TextBox textBox1;
        private Label label1;
        private TextBox textBox3;
        private GroupBox groupBox1;
        private ComboBox cmbAmmortamento;
        private Button button10;
        private Label label30;
        private TextBox txtRfid;
        private MetaData Meta;

		public Frm_asset_dettaglio()
		{
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
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
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
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_asset_dettaglio));
			this.btnOK = new System.Windows.Forms.Button();
			this.btnAnnulla = new System.Windows.Forms.Button();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.label30 = new System.Windows.Forms.Label();
			this.txtRfid = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cmbAmmortamento = new System.Windows.Forms.ComboBox();
			this.DS = new asset_dettaglio.vistaForm();
			this.button10 = new System.Windows.Forms.Button();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.gboxUbicazione = new System.Windows.Forms.GroupBox();
			this.dataGrid4 = new System.Windows.Forms.DataGrid();
			this.button7 = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.button9 = new System.Windows.Forms.Button();
			this.gboxResponsabile = new System.Windows.Forms.GroupBox();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.dataGrid3 = new System.Windows.Forms.DataGrid();
			this.chkTrasmesso = new System.Windows.Forms.CheckBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.txtEsistenzaCespite = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.grpBene = new System.Windows.Forms.GroupBox();
			this.txtDescrizione = new System.Windows.Forms.TextBox();
			this.btnSelezBene = new System.Windows.Forms.Button();
			this.txtNumInv = new System.Windows.Forms.TextBox();
			this.tabPageInfoAgg = new System.Windows.Forms.TabPage();
			this.tabConsegnatario = new System.Windows.Forms.TabPage();
			this.gboxConsegnatario = new System.Windows.Forms.GroupBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.gboxUbicazione.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid4)).BeginInit();
			this.gboxResponsabile.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).BeginInit();
			this.grpBene.SuspendLayout();
			this.tabConsegnatario.SuspendLayout();
			this.gboxConsegnatario.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(618, 527);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 8;
			this.btnOK.Tag = "mainsave";
			this.btnOK.Text = "OK";
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnAnnulla.Location = new System.Drawing.Point(706, 527);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
			this.btnAnnulla.TabIndex = 9;
			this.btnAnnulla.Text = "Annulla";
			// 
			// comboBox1
			// 
			this.comboBox1.Location = new System.Drawing.Point(0, 0);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 21);
			this.comboBox1.TabIndex = 0;
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPageInfoAgg);
			this.tabControl1.Controls.Add(this.tabConsegnatario);
			this.tabControl1.Location = new System.Drawing.Point(8, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(794, 511);
			this.tabControl1.TabIndex = 16;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.groupBox1);
			this.tabPage1.Controls.Add(this.gboxUbicazione);
			this.tabPage1.Controls.Add(this.gboxResponsabile);
			this.tabPage1.Controls.Add(this.chkTrasmesso);
			this.tabPage1.Controls.Add(this.textBox2);
			this.tabPage1.Controls.Add(this.txtEsistenzaCespite);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.grpBene);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(786, 485);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Principale";
			// 
			// label30
			// 
			this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label30.Location = new System.Drawing.Point(532, 32);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(35, 16);
			this.label30.TabIndex = 32;
			this.label30.Tag = "";
			this.label30.Text = "Rfid";
			this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtRfid
			// 
			this.txtRfid.Location = new System.Drawing.Point(574, 31);
			this.txtRfid.Name = "txtRfid";
			this.txtRfid.Size = new System.Drawing.Size(134, 20);
			this.txtRfid.TabIndex = 2;
			this.txtRfid.Tag = "asset.rfid";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cmbAmmortamento);
			this.groupBox1.Controls.Add(this.button10);
			this.groupBox1.Controls.Add(this.textBox3);
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(13, 134);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(770, 74);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Ammortamento";
			// 
			// cmbAmmortamento
			// 
			this.cmbAmmortamento.DataSource = this.DS.inventoryamortization;
			this.cmbAmmortamento.DisplayMember = "description";
			this.cmbAmmortamento.Location = new System.Drawing.Point(132, 18);
			this.cmbAmmortamento.Name = "cmbAmmortamento";
			this.cmbAmmortamento.Size = new System.Drawing.Size(286, 21);
			this.cmbAmmortamento.TabIndex = 29;
			this.cmbAmmortamento.Tag = "asset.idinventoryamortization";
			this.cmbAmmortamento.ValueMember = "idinventoryamortization";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			// 
			// button10
			// 
			this.button10.Location = new System.Drawing.Point(6, 16);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(120, 23);
			this.button10.TabIndex = 28;
			this.button10.Tag = "manage.inventoryamortization.default";
			this.button10.Text = "Tipo Ammortamento";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(328, 44);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(90, 20);
			this.textBox3.TabIndex = 27;
			this.textBox3.Tag = "asset.amortizationquota.fixed.6..%.100";
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(423, 10);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(341, 58);
			this.textBox1.TabIndex = 26;
			this.textBox1.TabStop = false;
			this.textBox1.Text = resources.GetString("textBox1.Text");
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(174, 49);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(136, 13);
			this.label1.TabIndex = 25;
			this.label1.Text = "Percentuale ammortamento";
			// 
			// gboxUbicazione
			// 
			this.gboxUbicazione.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxUbicazione.Controls.Add(this.dataGrid4);
			this.gboxUbicazione.Controls.Add(this.button7);
			this.gboxUbicazione.Controls.Add(this.button8);
			this.gboxUbicazione.Controls.Add(this.button9);
			this.gboxUbicazione.Location = new System.Drawing.Point(13, 338);
			this.gboxUbicazione.Name = "gboxUbicazione";
			this.gboxUbicazione.Size = new System.Drawing.Size(760, 117);
			this.gboxUbicazione.TabIndex = 6;
			this.gboxUbicazione.TabStop = false;
			this.gboxUbicazione.Text = "Ubicazione";
			// 
			// dataGrid4
			// 
			this.dataGrid4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid4.CaptionVisible = false;
			this.dataGrid4.DataMember = "";
			this.dataGrid4.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid4.Location = new System.Drawing.Point(96, 19);
			this.dataGrid4.Name = "dataGrid4";
			this.dataGrid4.Size = new System.Drawing.Size(656, 92);
			this.dataGrid4.TabIndex = 19;
			this.dataGrid4.Tag = "assetlocation.detail.single";
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(8, 83);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(75, 24);
			this.button7.TabIndex = 18;
			this.button7.TabStop = false;
			this.button7.Tag = "delete";
			this.button7.Text = "Elimina";
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(8, 51);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(75, 24);
			this.button8.TabIndex = 17;
			this.button8.TabStop = false;
			this.button8.Tag = "edit.single";
			this.button8.Text = "Modifica";
			// 
			// button9
			// 
			this.button9.Location = new System.Drawing.Point(8, 19);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(75, 24);
			this.button9.TabIndex = 16;
			this.button9.TabStop = false;
			this.button9.Tag = "insert.single";
			this.button9.Text = "Inserisci";
			// 
			// gboxResponsabile
			// 
			this.gboxResponsabile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxResponsabile.Controls.Add(this.button4);
			this.gboxResponsabile.Controls.Add(this.button5);
			this.gboxResponsabile.Controls.Add(this.button6);
			this.gboxResponsabile.Controls.Add(this.dataGrid3);
			this.gboxResponsabile.Location = new System.Drawing.Point(13, 211);
			this.gboxResponsabile.Name = "gboxResponsabile";
			this.gboxResponsabile.Size = new System.Drawing.Size(760, 123);
			this.gboxResponsabile.TabIndex = 5;
			this.gboxResponsabile.TabStop = false;
			this.gboxResponsabile.Text = "Responsabile";
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(8, 19);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(75, 24);
			this.button4.TabIndex = 7;
			this.button4.TabStop = false;
			this.button4.Tag = "insert.single";
			this.button4.Text = "Inserisci";
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(8, 83);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(75, 24);
			this.button5.TabIndex = 9;
			this.button5.TabStop = false;
			this.button5.Tag = "delete";
			this.button5.Text = "Elimina";
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(8, 51);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(75, 24);
			this.button6.TabIndex = 8;
			this.button6.TabStop = false;
			this.button6.Tag = "edit.single";
			this.button6.Text = "Modifica";
			// 
			// dataGrid3
			// 
			this.dataGrid3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid3.CaptionVisible = false;
			this.dataGrid3.DataMember = "";
			this.dataGrid3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid3.Location = new System.Drawing.Point(96, 19);
			this.dataGrid3.Name = "dataGrid3";
			this.dataGrid3.Size = new System.Drawing.Size(656, 98);
			this.dataGrid3.TabIndex = 10;
			this.dataGrid3.Tag = "assetmanager.detail.single";
			// 
			// chkTrasmesso
			// 
			this.chkTrasmesso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.chkTrasmesso.AutoSize = true;
			this.chkTrasmesso.Location = new System.Drawing.Point(13, 464);
			this.chkTrasmesso.Name = "chkTrasmesso";
			this.chkTrasmesso.Size = new System.Drawing.Size(77, 17);
			this.chkTrasmesso.TabIndex = 7;
			this.chkTrasmesso.Tag = "asset.transmitted:S:N";
			this.chkTrasmesso.Text = "Trasmesso";
			this.chkTrasmesso.UseVisualStyleBackColor = true;
			// 
			// textBox2
			// 
			this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox2.Location = new System.Drawing.Point(200, 91);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.Size = new System.Drawing.Size(573, 41);
			this.textBox2.TabIndex = 21;
			this.textBox2.TabStop = false;
			this.textBox2.Text = "Indica la data di acquisto del cespite se esso Ë nuovo altrimenti indica la data " +
    "da cui si deve calcolare l\'et‡ del cespite ai fini dell\'ammortamento";
			// 
			// txtEsistenzaCespite
			// 
			this.txtEsistenzaCespite.Location = new System.Drawing.Point(13, 110);
			this.txtEsistenzaCespite.Name = "txtEsistenzaCespite";
			this.txtEsistenzaCespite.Size = new System.Drawing.Size(104, 20);
			this.txtEsistenzaCespite.TabIndex = 3;
			this.txtEsistenzaCespite.Tag = "asset.lifestart";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(10, 91);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(128, 16);
			this.label2.TabIndex = 20;
			this.label2.Text = "Inizio Esistenza Cespite:";
			// 
			// grpBene
			// 
			this.grpBene.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpBene.Controls.Add(this.label30);
			this.grpBene.Controls.Add(this.txtDescrizione);
			this.grpBene.Controls.Add(this.txtRfid);
			this.grpBene.Controls.Add(this.btnSelezBene);
			this.grpBene.Controls.Add(this.txtNumInv);
			this.grpBene.Location = new System.Drawing.Point(8, 16);
			this.grpBene.Name = "grpBene";
			this.grpBene.Size = new System.Drawing.Size(761, 72);
			this.grpBene.TabIndex = 1;
			this.grpBene.TabStop = false;
			this.grpBene.Tag = "";
			this.grpBene.Text = "Numero inventario cespite principale";
			// 
			// txtDescrizione
			// 
			this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescrizione.Location = new System.Drawing.Point(192, 16);
			this.txtDescrizione.Multiline = true;
			this.txtDescrizione.Name = "txtDescrizione";
			this.txtDescrizione.ReadOnly = true;
			this.txtDescrizione.Size = new System.Drawing.Size(255, 48);
			this.txtDescrizione.TabIndex = 5;
			this.txtDescrizione.Tag = "assetacquire.description";
			// 
			// btnSelezBene
			// 
			this.btnSelezBene.Location = new System.Drawing.Point(8, 16);
			this.btnSelezBene.Name = "btnSelezBene";
			this.btnSelezBene.Size = new System.Drawing.Size(136, 23);
			this.btnSelezBene.TabIndex = 2;
			this.btnSelezBene.Tag = "choose.asset.default";
			this.btnSelezBene.Text = "Num.Inventario ";
			// 
			// txtNumInv
			// 
			this.txtNumInv.Location = new System.Drawing.Point(8, 48);
			this.txtNumInv.Name = "txtNumInv";
			this.txtNumInv.Size = new System.Drawing.Size(88, 20);
			this.txtNumInv.TabIndex = 3;
			this.txtNumInv.Tag = "asset.ninventory";
			// 
			// tabPageInfoAgg
			// 
			this.tabPageInfoAgg.AutoScroll = true;
			this.tabPageInfoAgg.Location = new System.Drawing.Point(4, 22);
			this.tabPageInfoAgg.Name = "tabPageInfoAgg";
			this.tabPageInfoAgg.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageInfoAgg.Size = new System.Drawing.Size(786, 485);
			this.tabPageInfoAgg.TabIndex = 1;
			this.tabPageInfoAgg.Text = "Informazioni Aggiuntive";
			this.tabPageInfoAgg.UseVisualStyleBackColor = true;
			// 
			// tabConsegnatario
			// 
			this.tabConsegnatario.Controls.Add(this.gboxConsegnatario);
			this.tabConsegnatario.Location = new System.Drawing.Point(4, 22);
			this.tabConsegnatario.Name = "tabConsegnatario";
			this.tabConsegnatario.Size = new System.Drawing.Size(786, 485);
			this.tabConsegnatario.TabIndex = 2;
			this.tabConsegnatario.Text = "Subconsegnatario";
			this.tabConsegnatario.UseVisualStyleBackColor = true;
			// 
			// gboxConsegnatario
			// 
			this.gboxConsegnatario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxConsegnatario.Controls.Add(this.button1);
			this.gboxConsegnatario.Controls.Add(this.button2);
			this.gboxConsegnatario.Controls.Add(this.button3);
			this.gboxConsegnatario.Controls.Add(this.dataGrid1);
			this.gboxConsegnatario.Location = new System.Drawing.Point(9, 16);
			this.gboxConsegnatario.Name = "gboxConsegnatario";
			this.gboxConsegnatario.Size = new System.Drawing.Size(760, 190);
			this.gboxConsegnatario.TabIndex = 24;
			this.gboxConsegnatario.TabStop = false;
			this.gboxConsegnatario.Text = "Subconsegnatario Cespite";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(8, 19);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 24);
			this.button1.TabIndex = 7;
			this.button1.TabStop = false;
			this.button1.Tag = "insert.single";
			this.button1.Text = "Inserisci";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(8, 83);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 24);
			this.button2.TabIndex = 9;
			this.button2.TabStop = false;
			this.button2.Tag = "delete";
			this.button2.Text = "Elimina";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(8, 51);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 24);
			this.button3.TabIndex = 8;
			this.button3.TabStop = false;
			this.button3.Tag = "edit.single";
			this.button3.Text = "Modifica";
			// 
			// dataGrid1
			// 
			this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid1.CaptionVisible = false;
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(96, 19);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(656, 165);
			this.dataGrid1.TabIndex = 10;
			this.dataGrid1.Tag = "assetsubmanager.detail.single";
			// 
			// Frm_asset_dettaglio
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(812, 558);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.btnAnnulla);
			this.Controls.Add(this.btnOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "Frm_asset_dettaglio";
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.gboxUbicazione.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid4)).EndInit();
			this.gboxResponsabile.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).EndInit();
			this.grpBene.ResumeLayout(false);
			this.grpBene.PerformLayout();
			this.tabConsegnatario.ResumeLayout(false);
			this.gboxConsegnatario.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
        object lastrejected = DBNull.Value;
        void CheckResponsabileChange() {
            DataRow []Location= DS.assetlocation.Select(null,null,DataViewRowState.Added);
            foreach (DataRow RL in Location) {
                string filterloc = QHC.CmpEq("idlocation", RL["idlocation"]);
                DataRow[] LL = DS.location.Select(filterloc);
                if (LL.Length == 0) continue;
                if (LL[0]["idman"] == DBNull.Value) continue;
                if (LL[0]["idman"].ToString()==lastrejected.ToString()) continue;
                string filter= QHC.CmpEq("start",RL["start"]);
                if (DS.assetmanager.Select(filter).Length==0){
                    if (MessageBox.Show(this,"Si vuole reimpostare il responsabile in base alla nuova ubicazione?","Conferma",
                        MessageBoxButtons.YesNo)==DialogResult.No){
                        lastrejected = LL[0]["idman"];
                        return;
                    }
                           
                    MetaData AM = Meta.Dispatcher.Get("assetmanager");
                    AM.SetDefaults(DS.assetmanager);
                    DataRow NA = AM.Get_New_Row(DS.asset.Rows[0], DS.assetmanager);
                    MetaData.SetDefault(DS.assetmanager, "start", RL["start"]);
                    NA["start"] = RL["start"];
                    NA["idman"] = LL[0]["idman"];
                }
                else {
                    DataRow CurrAssMan = DS.assetmanager.Select(filter)[0];
                    if (CurrAssMan["idman"].ToString() != LL[0]["idman"].ToString())
                    {
                        if (MessageBox.Show(this, "Si vuole reimpostare il responsabile in base alla nuova ubicazione?", "Conferma",
                            MessageBoxButtons.YesNo) == DialogResult.No) {
                            lastrejected = LL[0]["idman"];
                            return;
                        }
                        CurrAssMan["idman"] = LL[0]["idman"];
                    }
                }
                Meta.myGetData.GetTemporaryValues(DS.assetmanager);
                lastrejected = DBNull.Value;
            }

        }

		public void MetaData_BeforeFill() 
		{
            CheckResponsabileChange();
            int flag = CfgFn.GetNoNullInt32(entityRow["flag"]);
            bool pieceacquire = ((flag & 4) != 0);
			if (!Meta.InsertMode && pieceacquire){
//				In fase di modifica Il btnSelezBene Ë disabilitato. 
				btnSelezBene.Enabled=false;
				grpBene.Tag="";
				txtNumInv.Tag="assetview.ninventory";
				txtRfid.Tag = "asset.rfid";
			}
		}
        CQueryHelper QHC;
        QueryHelper QHS;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            //riga padre (assetacquire)
            DataAccess.SetTableForReading(DS.submanager, "manager");
            entityRow = Meta.SourceRow.GetParentRow("assetacquireasset");
            if (entityRow == null) {
                Meta.ErroreIrrecuperabile = true;
                return;
            }

            int flag = CfgFn.GetNoNullInt32(entityRow["flag"]);
            bool pieceacquire = ((flag & 4) != 0);

            //riga inventario
            DataRow Rinv = entityRow.GetParentRow("inventoryassetacquire");
            if (Rinv != null) {
                txtDescrizione.Text = Rinv["description"].ToString();
            }
            
            string filter = QHS.CmpEq("idinventory", entityRow["idinventory"]);
            //string filter2="(idpiece='1')AND"+filter;
            string filter2 = QHS.AppAnd(QHS.CmpEq("idpiece", 1), filter);
            if (entityRow["idinv"].ToString() != "") {
                object idinv_lev1 = Meta.Conn.DO_READ_VALUE("inventorytreeview", QHS.CmpEq("idinv", entityRow["idinv"]), "idinv_lev1");
                if (idinv_lev1 != null) {
                    filter2 = QHS.AppAnd(filter2, QHS.CmpEq("idinv_lev1", idinv_lev1));
                    if (pieceacquire) {
                        DataRow Curr = Meta.SourceRow;
                        filter2 = QHS.AppOr(filter2, QHS.DoPar(QHS.AppAnd(QHS.CmpEq("idasset", Curr["idasset"]), QHS.CmpEq("idpiece", 1))));
                    }
                }
            }

            

            GetData.SetStaticFilter(DS.assetview, filter2);
            btnSelezBene.Tag += "." + filter;
            if (pieceacquire) {//si tratta di un carico parte
                grpBene.Tag = "AutoChoose.txtNumInv.default." + filter;
                btnSelezBene.Tag = "choose.assetview.default";
                txtNumInv.Tag = "assetview.ninventory?x";
				txtRfid.Tag = "assetview.rfid?x";
				txtDescrizione.Tag = "assetview.description";
                gboxResponsabile.Enabled = false;
                gboxUbicazione.Enabled = false;
                gboxConsegnatario.Enabled = false;
            }
            else {//si tratta di un carico bene
                btnSelezBene.Enabled = false;
                txtNumInv.ReadOnly = false;
                txtNumInv.Tag = "asset.ninventory";
				txtRfid.Tag = "asset.rfid";
				grpBene.Text = "Numero inventario e descrizione";
                gboxResponsabile.Enabled = true;
                gboxUbicazione.Enabled = true;
                gboxConsegnatario.Enabled = true;
                if (Meta.InsertMode) {
                    txtDescrizione.Tag = null;
                    //txtDescrizione.Text=
                }
            }
            Meta.MarkTableAsNotEntityChild(DS.assetmanager);
            Meta.MarkTableAsNotEntityChild(DS.assetsubmanager);
            Meta.MarkTableAsNotEntityChild(DS.assetlocation);
            GetData.CacheTable(DS.manager,null,null,false);
            GetData.CacheTable(DS.submanager, null, null, false);
            GetData.CacheTable(DS.multifieldkind, null, null, false);

        }

        public void MetaData_AfterFill () {
           
            DataRow Curr = DS.asset.Rows[0];
            object idinv = entityRow["idinv"];

            if (Meta.FirstFillForThisRow) {
                ClearMultifieldTab();
                DS.inventorytreemultifieldkind.Clear();
                Meta.Conn.RUN_SELECT_INTO_TABLE(DS.inventorytreemultifieldkind, null, QHS.CmpEq("idinv", entityRow["idinv"]), null, false);
                FillMultifieldTab(Curr["multifield"].ToString(), DS.multifieldkind,
                    DS.inventorytreemultifieldkind.Select(QHC.CmpEq("idinv", idinv), "idmultifieldkind"));
            }

        }
        public void MetaData_AfterGetFormData () {
            DataRow Curr = DS.asset.Rows[0];
            object idinv = entityRow["idinv"];
            string S = GetMultifieldTab();
            if (S == "" || S==null)
                Curr["multifield"] = DBNull.Value;
            else
                Curr["multifield"] = S;
        }

        #region gestione multifieldkind
        int TextHeight = 30;
        int TextWidth = 300;

        class mfield {
            public string fieldname;
            public string systype;
            public bool allownull;
            public string tag;
            public string fieldcode;
            public TextBox T;
        }

        int  AddMultiFieldToForm(TabPage TP, mfield MF, int x, int y, int maxlen) {
	        int nLine = maxlen / 45;
	        var T = new TextBox();
	        T.Width = TextWidth; 
	        T.Height = TextHeight;
	        if (maxlen != 0) {
		        T.MaxLength = maxlen;
	        }
	        if (nLine > 1) {
		        T.Multiline = true;
		        T.Height = TextHeight*nLine;
		        T.ScrollBars = ScrollBars.Vertical;
	        }

            var G = new GroupBox();
            G.Size = new Size(320, T.Height +30);
            G.Location = new Point(10 + x, 15 + y);

            G.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left))));
            //if (count < 10) {
            //    G.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left))));
            //}
            //else {
            //    G.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left)
            //                    | AnchorStyles.Right)));
            //}
            G.Text = MF.fieldname;
            if (!MF.allownull) {
                G.Text += " (*)";
            }
            TP.Controls.Add(G);

        
          
            G.Controls.Add(T);
         
            
            //T.Multiline = true;
            //T.ScrollBars = ScrollBars.Vertical;
            
            
            T.Location = new Point(5, 18);
            T.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Left)));
            //T.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left)
            //                    | AnchorStyles.Right)));

            MF.T = T;
            return G.Height;
        }


        mfield[] allfields = new mfield[1];
        /// <summary>
        /// Aggiunge i textbox al tab e li riempie con i valori trovati in value
        /// </summary>
        /// <param name="value">stinga codificata</param>
        /// <param name="MFKind">tabella multifieldkind</param>
        /// <param name="Fields">inventorytreemultifieldkind filtrata per idinv</param>
        void FillMultifieldTab(string value, DataTable MFKind, DataRow[] Fields) {
	      
            var FT = new TabControl();
            FT.Dock = DockStyle.Fill;
            var availableCodes = new Dictionary<string, bool>();

            var HL = new Dictionary<string, List<DataRow>>();
            var TabNameList = new ArrayList();
            foreach (DataRow Fk0 in MFKind.Select(null,"ordernumber")) {
                DataRow F=null;
                foreach (var FF in Fields) {
                    if (FF["idmultifieldkind"].ToString() == Fk0["idmultifieldkind"].ToString()) {
                        F = FF;
                        break;
                    }
                }
                if (F == null) continue;
                availableCodes[Fk0["fieldcode"].ToString().ToLower()] = true;
                string tabname = Fk0["tabname"].ToString();
                List<DataRow> AL;
                if (HL.ContainsKey(tabname)) {
                    AL = HL[tabname] as List<DataRow>;
                }
                else {
                    AL = new List<DataRow>();
                    HL[tabname] = AL;
                    TabNameList.Add(tabname);
                }
                AL.Add(F);
            }



            tabPageInfoAgg.Controls.Clear();
            tabPageInfoAgg.Controls.Add(FT);

            Hashtable H = new Hashtable();
            string[] allmf = value.Split(new char[] { 'ß' });
            foreach (string coppia in allmf) {
                if (coppia == "") continue;
                string[] cc = coppia.Split(new char[] { '|' });
                string code = cc[0].ToLower();
                if (!availableCodes.ContainsKey(code)) continue;
                string val = cc[1];
                H[code] = val;
            }
            //allfields= array di stringhe del tipo chiaveßvalore
            allfields = new mfield[Fields.Length];

            //if (value == "") allfields = new mfield[0];
            TabNameList.Sort();
            int maincount = 1;

            foreach (string tabname in TabNameList) {
                var TP = new TabPage(tabname == "null" ? "" : tabname);
                TP.AutoScroll = true;

                int x = 0;
                int y = 0;

                int tabcount = 1;
                foreach (var Field in HL[tabname]) {
                    DataRow[] Fks = MFKind.Select(QHC.CmpEq("idmultifieldkind", Field["idmultifieldkind"]));
                    if (Fks.Length == 0) continue;
                    var R = Fks[0];

                    string fieldcode = R["fieldcode"].ToString();
                    object XX = H[fieldcode.ToLower()];
                    if (XX == null) XX = "";
					var MF = new mfield {
						fieldname = R["fieldname"].ToString(),
						allownull = (R["allownull"].ToString().ToUpper() == "S"),
						systype = R["systype"].ToString(),
						tag = R["tag"].ToString(),
						fieldcode = fieldcode
					};

					

					int heigth = AddMultiFieldToForm(TP, MF, x, y, CfgFn.GetNoNullInt32(R["len"])); //inizio

					
					MF.T.Text = XX.ToString();
                    MF.T.TextAlign = MF.systype.ToLower() == "string" ? HorizontalAlignment.Left : HorizontalAlignment.Right;

					allfields[maincount - 1] = MF;

                    tabcount++;
                    maincount++;
                    y += heigth+10;
                    if (tabcount == 10) {
                        x += 350;
                        y = 0;
                    }
                }
               
                FT.TabPages.Add(TP);
                FT.Refresh();
            }

            ////Legenda campi obbligatori
            //if (Fields.Length > 0) {
            //    Label L = new Label();
            //    tabPageInfoAgg.Controls.Add(L);
            //    L.Text = "I campi contrassegnati da (*) sono obbligatori";
            //    L.AutoSize = true;
            //    L.Location = new Point(10 + x, 15 + y);
            //}

        }
        
        string GetMultifieldTab () {
            string res = "";
            foreach (mfield mf in allfields) {
                if (mf == null) continue;
                string value = mf.T.Text.Trim().Replace("ß", "").Replace("|", "");
                if (value == "") continue;
                string fieldcode = mf.fieldcode;
                string coppia = fieldcode + "|" + value;
                if (res != "") res += "ß";
                res += coppia;
            }
            if (Meta.EditMode) {
                DataRow Curr = DS.asset.Rows[0];
                string old = Curr["multifield", DataRowVersion.Original].ToString();
                if (are_same(res, old)) res = old;
            }
            return res;
        }


        bool are_same(string mfield1, string mfield2) {
            string[] coppie1 = mfield1.Split('ß');
            string[] coppie2 = mfield2.Split('ß');

            Hashtable h1 = new Hashtable();
            foreach (string c1 in coppie1) {
                string[] cval1 = c1.Split('|');
                if (cval1.Length < 2) continue;
                if (cval1[1].ToString() == "") continue;
                h1[cval1[0]] = cval1[1].TrimEnd();
            }

            Hashtable h2 = new Hashtable();
            foreach (string c2 in coppie2) {
                string[] cval2 = c2.Split('|');
                if (cval2.Length < 2) continue;
                if (cval2[1].ToString() == "") continue;
                h2[cval2[0]] = cval2[1].TrimEnd();
            }


            foreach (object k1 in h1.Keys) {
                if (!h2.Contains(k1.ToString())) return false;
                if (h1[k1.ToString()].ToString() != h2[k1.ToString()].ToString()) return false;
            }

            foreach (object k2 in h2.Keys) {
                if (!h1.Contains(k2.ToString())) return false;
                if (h1[k2.ToString()].ToString() != h2[k2.ToString()].ToString()) return false;
            }

            return true;
        }


        void ClearMultifieldTab () {
            tabPageInfoAgg.Controls.Clear();
            allfields = new mfield[1];
        }


        #endregion
	}
}
