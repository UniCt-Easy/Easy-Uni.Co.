
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
using funzioni_configurazione;//funzioni_configurazione

namespace taxrate_default//aliquotaritenutalistanew//
{
	/// <summary>
	/// Summary description for frmaliquotaritenutalistanew.
	/// </summary>
	public class Frm_taxrate_default : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox9;
		private System.Windows.Forms.TextBox textBox8;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.ComboBox cmbDataInizioStruttura;
		private System.Windows.Forms.ComboBox cmbTipoRitenuta;
		public System.Windows.Forms.Panel MetaDataDetail;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ComboBox cmbScaglione;
		private System.Windows.Forms.ImageList images;
		public System.Windows.Forms.ToolBar MetaDataToolBar;
		private System.Windows.Forms.ToolBarButton seleziona;
		private System.Windows.Forms.ToolBarButton impostaricerca;
		private System.Windows.Forms.ToolBarButton effettuaricerca;
		private System.Windows.Forms.ToolBarButton modifica;
		private System.Windows.Forms.ToolBarButton inserisci;
		private System.Windows.Forms.ToolBarButton inseriscicopia;
		private System.Windows.Forms.ToolBarButton elimina;
		private System.Windows.Forms.ToolBarButton Salva;
		private System.ComponentModel.IContainer components;
		MetaData Meta;
		DataTable TipoRitenutaTable;
		string filterritenuta, filterdatainiziostruttura;
		public vistaForm DS;

		public Frm_taxrate_default()
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Frm_taxrate_default));
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.cmbDataInizioStruttura = new System.Windows.Forms.ComboBox();
			this.cmbTipoRitenuta = new System.Windows.Forms.ComboBox();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.MetaDataDetail = new System.Windows.Forms.Panel();
			this.label10 = new System.Windows.Forms.Label();
			this.cmbScaglione = new System.Windows.Forms.ComboBox();
			this.DS = new taxrate_default.vistaForm();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.panel5 = new System.Windows.Forms.Panel();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.label5 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.textBox9 = new System.Windows.Forms.TextBox();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.images = new System.Windows.Forms.ImageList(this.components);
			this.MetaDataToolBar = new System.Windows.Forms.ToolBar();
			this.seleziona = new System.Windows.Forms.ToolBarButton();
			this.impostaricerca = new System.Windows.Forms.ToolBarButton();
			this.effettuaricerca = new System.Windows.Forms.ToolBarButton();
			this.modifica = new System.Windows.Forms.ToolBarButton();
			this.inserisci = new System.Windows.Forms.ToolBarButton();
			this.inseriscicopia = new System.Windows.Forms.ToolBarButton();
			this.elimina = new System.Windows.Forms.ToolBarButton();
			this.Salva = new System.Windows.Forms.ToolBarButton();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.MetaDataDetail.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(144, 88);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(112, 24);
			this.label2.TabIndex = 8;
			this.label2.Text = "Data inizio struttura:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(144, 64);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(112, 24);
			this.label1.TabIndex = 7;
			this.label1.Text = "Tipo ritenuta:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cmbDataInizioStruttura
			// 
			this.cmbDataInizioStruttura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbDataInizioStruttura.Location = new System.Drawing.Point(256, 88);
			this.cmbDataInizioStruttura.Name = "cmbDataInizioStruttura";
			this.cmbDataInizioStruttura.Size = new System.Drawing.Size(152, 21);
			this.cmbDataInizioStruttura.TabIndex = 6;
			this.cmbDataInizioStruttura.Tag = "";
			this.cmbDataInizioStruttura.SelectedIndexChanged += new System.EventHandler(this.cmbDataInizioStruttura_SelectedIndexChanged);
			// 
			// cmbTipoRitenuta
			// 
			this.cmbTipoRitenuta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTipoRitenuta.Location = new System.Drawing.Point(256, 64);
			this.cmbTipoRitenuta.Name = "cmbTipoRitenuta";
			this.cmbTipoRitenuta.Size = new System.Drawing.Size(272, 21);
			this.cmbTipoRitenuta.TabIndex = 5;
			this.cmbTipoRitenuta.Tag = "";
			this.cmbTipoRitenuta.SelectedIndexChanged += new System.EventHandler(this.cmbTipoRitenuta_SelectedIndexChanged);
			this.cmbTipoRitenuta.Enter += new System.EventHandler(this.cmbTipoRitenuta_Enter);
			// 
			// dataGrid1
			// 
			this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(8, 120);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(666, 112);
			this.dataGrid1.TabIndex = 9;
			this.dataGrid1.Tag = "taxrate.default";
			// 
			// MetaDataDetail
			// 
			this.MetaDataDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.MetaDataDetail.Controls.Add(this.label10);
			this.MetaDataDetail.Controls.Add(this.cmbScaglione);
			this.MetaDataDetail.Controls.Add(this.groupBox2);
			this.MetaDataDetail.Controls.Add(this.groupBox1);
			this.MetaDataDetail.Controls.Add(this.label4);
			this.MetaDataDetail.Controls.Add(this.textBox3);
			this.MetaDataDetail.Controls.Add(this.textBox2);
			this.MetaDataDetail.Controls.Add(this.panel2);
			this.MetaDataDetail.Controls.Add(this.label3);
			this.MetaDataDetail.Controls.Add(this.textBox1);
			this.MetaDataDetail.Location = new System.Drawing.Point(8, 240);
			this.MetaDataDetail.Name = "MetaDataDetail";
			this.MetaDataDetail.Size = new System.Drawing.Size(664, 160);
			this.MetaDataDetail.TabIndex = 10;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(112, 8);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(72, 22);
			this.label10.TabIndex = 29;
			this.label10.Text = "Scaglione:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cmbScaglione
			// 
			this.cmbScaglione.DataSource = this.DS.ratebracket;
			this.cmbScaglione.DisplayMember = "!descrizione";
			this.cmbScaglione.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbScaglione.Location = new System.Drawing.Point(184, 8);
			this.cmbScaglione.Name = "cmbScaglione";
			this.cmbScaglione.Size = new System.Drawing.Size(344, 21);
			this.cmbScaglione.TabIndex = 28;
			this.cmbScaglione.Tag = "";
			this.cmbScaglione.ValueMember = "nbracket";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.textBox6);
			this.groupBox2.Controls.Add(this.textBox5);
			this.groupBox2.Controls.Add(this.textBox4);
			this.groupBox2.Controls.Add(this.panel5);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Location = new System.Drawing.Point(416, 40);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(240, 112);
			this.groupBox2.TabIndex = 27;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Contributi a carico dell\'Amministrazione";
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(88, 80);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(56, 20);
			this.textBox6.TabIndex = 34;
			this.textBox6.Tag = "taxrate.admindenominator";
			this.textBox6.Text = "";
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(88, 48);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(56, 20);
			this.textBox5.TabIndex = 33;
			this.textBox5.Tag = "taxrate.adminnumerator";
			this.textBox5.Text = "";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(88, 16);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(96, 20);
			this.textBox4.TabIndex = 32;
			this.textBox4.Tag = "taxrate.adminrate.fixed.4..%.100";
			this.textBox4.Text = "";
			// 
			// panel5
			// 
			this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel5.Location = new System.Drawing.Point(80, 73);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(72, 2);
			this.panel5.TabIndex = 31;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(24, 64);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(56, 22);
			this.label8.TabIndex = 30;
			this.label8.Text = "Quota:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(24, 16);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(64, 22);
			this.label9.TabIndex = 28;
			this.label9.Text = "Aliquota:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.panel3);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.textBox7);
			this.groupBox1.Controls.Add(this.textBox9);
			this.groupBox1.Controls.Add(this.textBox8);
			this.groupBox1.Location = new System.Drawing.Point(224, 40);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(184, 112);
			this.groupBox1.TabIndex = 26;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Ritenute a carico del dipendente";
			// 
			// panel3
			// 
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel3.Location = new System.Drawing.Point(64, 73);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(72, 2);
			this.panel3.TabIndex = 31;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 64);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(56, 22);
			this.label5.TabIndex = 30;
			this.label5.Text = "Quota:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(8, 16);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(64, 22);
			this.label7.TabIndex = 28;
			this.label7.Text = "Aliquota:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox7
			// 
			this.textBox7.Location = new System.Drawing.Point(72, 16);
			this.textBox7.Name = "textBox7";
			this.textBox7.Size = new System.Drawing.Size(96, 20);
			this.textBox7.TabIndex = 27;
			this.textBox7.Tag = "taxrate.employrate.fixed.4..%.100";
			this.textBox7.Text = "";
			// 
			// textBox9
			// 
			this.textBox9.Location = new System.Drawing.Point(72, 80);
			this.textBox9.Name = "textBox9";
			this.textBox9.Size = new System.Drawing.Size(56, 20);
			this.textBox9.TabIndex = 28;
			this.textBox9.Tag = "taxrate.employdenominator";
			this.textBox9.Text = "";
			// 
			// textBox8
			// 
			this.textBox8.Location = new System.Drawing.Point(72, 48);
			this.textBox8.Name = "textBox8";
			this.textBox8.Size = new System.Drawing.Size(56, 20);
			this.textBox8.TabIndex = 27;
			this.textBox8.Tag = "taxrate.employnumerator";
			this.textBox8.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 104);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(96, 22);
			this.label4.TabIndex = 21;
			this.label4.Text = "Quota imponibile:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(120, 120);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(56, 20);
			this.textBox3.TabIndex = 20;
			this.textBox3.Tag = "taxrate.taxabledenominator";
			this.textBox3.Text = "";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(120, 88);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(56, 20);
			this.textBox2.TabIndex = 19;
			this.textBox2.Tag = "taxrate.taxablenumerator";
			this.textBox2.Text = "";
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Location = new System.Drawing.Point(112, 112);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(72, 2);
			this.panel2.TabIndex = 18;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 56);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(104, 22);
			this.label3.TabIndex = 17;
			this.label3.Text = "Data inizio aliquota:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(120, 56);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(88, 20);
			this.textBox1.TabIndex = 16;
			this.textBox1.Tag = "taxrate.ratestart";
			this.textBox1.Text = "";
			// 
			// images
			// 
			this.images.ImageSize = new System.Drawing.Size(30, 30);
			this.images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("images.ImageStream")));
			this.images.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// MetaDataToolBar
			// 
			this.MetaDataToolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.MetaDataToolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																							   this.seleziona,
																							   this.impostaricerca,
																							   this.effettuaricerca,
																							   this.modifica,
																							   this.inserisci,
																							   this.inseriscicopia,
																							   this.elimina,
																							   this.Salva});
			this.MetaDataToolBar.ButtonSize = new System.Drawing.Size(56, 56);
			this.MetaDataToolBar.Dock = System.Windows.Forms.DockStyle.None;
			this.MetaDataToolBar.DropDownArrows = true;
			this.MetaDataToolBar.ImageList = this.images;
			this.MetaDataToolBar.Location = new System.Drawing.Point(0, 0);
			this.MetaDataToolBar.Name = "MetaDataToolBar";
			this.MetaDataToolBar.ShowToolTips = true;
			this.MetaDataToolBar.Size = new System.Drawing.Size(682, 56);
			this.MetaDataToolBar.TabIndex = 35;
			this.MetaDataToolBar.Tag = "";
			// 
			// seleziona
			// 
			this.seleziona.ImageIndex = 1;
			this.seleziona.Tag = "mainselect";
			this.seleziona.Text = "Seleziona";
			this.seleziona.ToolTipText = "Seleziona l\'elemento desiderato";
			// 
			// impostaricerca
			// 
			this.impostaricerca.ImageIndex = 10;
			this.impostaricerca.Tag = "mainsetsearch";
			this.impostaricerca.Text = "Imposta Ricerca";
			this.impostaricerca.ToolTipText = "Imposta una nuova ricerca";
			// 
			// effettuaricerca
			// 
			this.effettuaricerca.ImageIndex = 12;
			this.effettuaricerca.Tag = "maindosearch";
			this.effettuaricerca.Text = "Effettua Ricerca";
			this.effettuaricerca.ToolTipText = "Cerca in base ai dati immessi";
			// 
			// modifica
			// 
			this.modifica.ImageIndex = 6;
			this.modifica.Tag = "mainedit";
			this.modifica.Text = "Modifica";
			this.modifica.ToolTipText = "Modifica l\'elemento selezionato";
			// 
			// inserisci
			// 
			this.inserisci.ImageIndex = 0;
			this.inserisci.Tag = "maininsert";
			this.inserisci.Text = "Inserisci";
			this.inserisci.ToolTipText = "Inserisci un nuovo elemento";
			// 
			// inseriscicopia
			// 
			this.inseriscicopia.ImageIndex = 9;
			this.inseriscicopia.Tag = "maininsertcopy";
			this.inseriscicopia.Text = "Inserisci copia";
			this.inseriscicopia.ToolTipText = "Inserisci un nuovo elemento copiando i dati da quello attuale";
			// 
			// elimina
			// 
			this.elimina.ImageIndex = 3;
			this.elimina.Tag = "maindelete";
			this.elimina.Text = "Elimina";
			this.elimina.ToolTipText = "Elimina l\'elemento selezionato";
			// 
			// Salva
			// 
			this.Salva.ImageIndex = 2;
			this.Salva.Tag = "mainsave";
			this.Salva.Text = "Salva";
			this.Salva.ToolTipText = "Salva le modifiche effettuate";
			// 
			// Frm_taxrate_default
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(682, 407);
			this.Controls.Add(this.MetaDataDetail);
			this.Controls.Add(this.dataGrid1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cmbDataInizioStruttura);
			this.Controls.Add(this.cmbTipoRitenuta);
			this.Controls.Add(this.MetaDataToolBar);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "Frm_taxrate_default";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmaliquotaritenutalistanew";
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.MetaDataDetail.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public void MetaData_AfterLink()
		{
			Meta = MetaData.GetMetaData(this);
			DS.taxrate.ExtendedProperties["sort_by"]="ratestart, nbracket";
			HelpForm.SetFormatForColumn(DS.taxrate.Columns["adminrate"], "p");
			HelpForm.SetFormatForColumn(DS.taxrate.Columns["employrate"], "p");
			//DisableToolbar();
			GetData.CacheTable(DS.ratebracket);
			//riempie il combo tiporitenuta
            //object O = "";
            //cmbTipoRitenuta.Items.Add(O);
            TipoRitenutaTable=Meta.Conn.RUN_SELECT("tax","*","description","(active='S')", null, true);
            cmbTipoRitenuta.DataSource = TipoRitenutaTable;
            cmbTipoRitenuta.ValueMember = "taxcode";
            cmbTipoRitenuta.DisplayMember = "description";
            //foreach (DataRow R in TipoRitenutaTable.Rows)
            //    cmbTipoRitenuta.Items.Add(R["description"]);
		}

		void DisableToolbar()
		{
			//Meta.CanInsert=false;
			Meta.CanInsertCopy=false;
			Meta.FreshToolBar();
		}

		void EnableToolbar()
		{
			//Meta.CanInsert=true;
			Meta.CanInsertCopy=true;
			Meta.FreshToolBar();
		}

//		void EnableToolbar(bool enable) {
//			Meta.CanInsert=enable;
//			Meta.CanInsertCopy=enable;
//			Meta.FreshToolBar();
//			this.SendToBack();
//			MetaDataToolBar.BringToFront();
//		}
		
		private void cmbTipoRitenuta_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (!Meta.DrawStateIsDone) return;
			DS.taxrate.Clear();
			DS.ratebracket.Clear(); //
			Meta.FreshForm();
			cmbDataInizioStruttura.Items.Clear();
            if(cmbTipoRitenuta.SelectedIndex <= 0) return;
			//if (cmbTipoRitenuta.SelectedItem.ToString()=="") return;
            object taxcode = cmbTipoRitenuta.SelectedValue;
            if(taxcode == null) return;
			filterritenuta = "(taxcode="+
				QueryCreator.quotedstrvalue(taxcode, true)+
				")";
            MetaData.SetDefault(DS.taxrate, "taxcode", taxcode);
			PopolaComboDataInizioStruttura(filterritenuta);
			if (!Meta.IsEmpty) DisableToolbar();
		}

		public void MetaData_AfterRowSelect(DataTable T, DataRow R)
		{
			if (R==null) return;
			if (T.TableName == "taxrate")
			{
				if (Meta.EditMode)
				{
					EnableToolbar();
					cmbScaglione.SelectedValue=R["nbracket"];
				}
			}
		}

		void CheckFormChanges()
		{
			Meta.GetFormData(true);
			if (!Meta.WarnUnsaved())
				MetaDataDetail.Focus();
		}

		void PopolaComboDataInizioStruttura(string filter)
		{
			//riempie il combo datainiziostruttura
			object O = "";
			cmbDataInizioStruttura.Items.Add(O);
			DataTable DataInizioStrutturaTable=Meta.Conn.RUN_SELECT("ratevalidity",
								"validitystart",null,filter, null, true);
			foreach (DataRow R in DataInizioStrutturaTable.Rows)
				cmbDataInizioStruttura.Items.Add(Convert.ToDateTime(R["validitystart"]).ToShortDateString());
		}

		public void MetaData_AfterClear()
		{
			cmbScaglione.Enabled=false;	
			cmbTipoRitenuta.Enabled=true;
			cmbDataInizioStruttura.Enabled=true;
			if (!Meta.DrawStateIsDone) return;
			EnableToolbar();
		}

		public void MetaData_AfterFill()
		{
			if (Meta.InsertMode)
			{
				cmbScaglione.Enabled=true;
				cmbTipoRitenuta.Enabled=false;
				cmbDataInizioStruttura.Enabled=false;
			}
			if (Meta.EditMode)
			{
				cmbScaglione.Enabled=false;	
				cmbTipoRitenuta.Enabled=true;
				cmbDataInizioStruttura.Enabled=true;
			}
		}

		public void MetaData_AfterGetFormData()
		{
			if (Meta.EditMode) return;
			DataRow CurrentRow = HelpForm.GetLastSelected(DS.taxrate);
//			int CurrentScaglione = Convert.ToInt16(cmbScaglione.SelectedValue);
//			string filter = "(ratestart="+QueryCreator.quotedstrvalue(
//				CurrentRow["ratestart"],false)+
//				") AND (nbracket = "+QueryCreator.quotedstrvalue(
//				CurrentScaglione,false)+")";			
//			// verifica se lo scaglione è già stato inserito
//			// sulla datainizioaliquota corrente
//			DataRow [] res = DS.taxrate.Select(filter);
//			if (res.Length==0){
			try {
				CurrentRow["nbracket"]=cmbScaglione.SelectedValue;
			}
			catch {
				CurrentRow["nbracket"]=0;
			}
//			}
//			else{
//				CurrentRow["nbracket"]=0;
//			}
		}

		private void cmbDataInizioStruttura_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//if (!Meta.DrawStateIsDone) return;
//			bool MustSave=false;
//			if (!Meta.IsEmpty)
//			{
//				Meta.GetFormData(true);
//				if (!Meta.WarnUnsaved())
//				{
//					MustSave=true;
//				}
//			}
//			if (MustSave)
//			{
//				MetaDataDetail.Focus();
//				return;
//			}

			Meta.DoMainCommand("mainsetsearch");
			if (!Meta.IsEmpty && DS.HasChanges())
			{
				MetaDataDetail.Focus();
				return;
			}
			if (cmbDataInizioStruttura.SelectedItem.ToString()=="") 
			{
				cmbTipoRitenuta.SelectedItem="";
				Meta.FreshForm();
				DisableToolbar();
				return;
			}

			filterdatainiziostruttura = "(validitystart="+
				QueryCreator.quotedstrvalue(cmbDataInizioStruttura.SelectedItem,true)+
				")";
			MetaData.SetDefault(DS.taxrate, "validitystart", Convert.ToDateTime(cmbDataInizioStruttura.SelectedItem));
			DS.ratebracket.Clear(); //
			string filter = GetData.MergeFilters(filterritenuta, filterdatainiziostruttura);
			Meta.DoMainCommand("maindosearch.default."+filter);
			//Meta.FreshForm();
			//if (DS.aliquotaritenuta.Rows.Count > 0)
				PopolaComboScaglione(filter);
			EnableToolbar();

		}

		void PopolaComboScaglione(string filter)
		{
			DS.ratebracket.Clear();
			DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn,DS.ratebracket, "nbracket",
				filter, null, true);
			foreach (DataRow R in DS.ratebracket.Rows) {
				if (R["maxamount"] != DBNull.Value) {
					R["!descrizione"] = "Scaglione "+R["nbracket"].ToString()+
						": da "+CfgFn.GetNoNullDecimal(R["minamount"]).ToString("c")+
						" a "+CfgFn.GetNoNullDecimal(R["maxamount"]).ToString("c")+".";
				}
				else {
					R["!descrizione"] = "Scaglione "+R["nbracket"].ToString()+
						": da "+CfgFn.GetNoNullDecimal(R["minamount"]).ToString("c")+".";
				}

			}
			DS.ratebracket.AcceptChanges();
		}

		private void cmbTipoRitenuta_Enter(object sender, System.EventArgs e)
		{
			CheckFormChanges();
		}
	}
}
