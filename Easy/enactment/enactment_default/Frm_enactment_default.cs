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

using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using SituazioneViewer;//SituazioneViewer
using funzioni_configurazione;//funzioni_configurazione

namespace enactment_default{
	/// <summary>
	/// Summary description for frmdocumentoincasso_multiplo.
	/// Revised By Nino 26/1/2003
	/// revised By Nino 21/2/2003
	/// revised By Nino on 8/3/2003
	/// </summary>
	public class Frm_enactment_default : System.Windows.Forms.Form {
        QueryHelper QHS;
        CQueryHelper QHC = new CQueryHelper();
        private System.Windows.Forms.GroupBox gboxStato;
		private System.Windows.Forms.RadioButton rdbAnnullato;
        private System.Windows.Forms.RadioButton rdbApprovato;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtNumeroDocumento;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEsercizioDocumento;
	    MetaData Meta;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGrid dataGrid1;
        private RadioButton rdbInAttesa;
        private Button btnApprova;
        private Button btnAnnulla;
        private TextBox txtDescrizione;
        private Label label8;
        private Label label9;
        private TextBox txtDataContabile;
        private Label label3;
        private TextBox txtNOfficial;
        private Button btnWait;
        public vistaForm DS;
        private TabControl tabControl1;
        private TabPage tabPageVariazioni;
        private GroupBox groupBox2;
        private Button btnModifica;
        private DataGrid dgrVariazioni;
        private Button btnScollega;
        private Button btnCollega;
        private TabPage tabPageAttributi;
        public GroupBox gboxclass03;
        public TextBox txtCodice03;
        public Button btnCodice03;
        private TextBox txtDenom03;
        public GroupBox gboxclass02;
        public TextBox txtCodice02;
        public Button btnCodice02;
        private TextBox txtDenom02;
        public GroupBox gboxclass01;
        public TextBox txtCodice01;
        public Button btnCodice01;
        private TextBox txtDenom01;
        public GroupBox gboxclass05;
        public TextBox txtCodice05;
        public Button btnCodice05;
        private TextBox txtDenom05;
        public GroupBox gboxclass04;
        public TextBox txtCodice04;
        public Button btnCodice04;
        private TextBox txtDenom04;
		private System.ComponentModel.IContainer components;

		public Frm_enactment_default() {
			InitializeComponent();
			QueryCreator.SetTableForPosting(DS.finvarview, "finvar");
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_enactment_default));
            this.gboxStato = new System.Windows.Forms.GroupBox();
            this.rdbInAttesa = new System.Windows.Forms.RadioButton();
            this.rdbAnnullato = new System.Windows.Forms.RadioButton();
            this.rdbApprovato = new System.Windows.Forms.RadioButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNOfficial = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNumeroDocumento = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEsercizioDocumento = new System.Windows.Forms.TextBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.btnApprova = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDataContabile = new System.Windows.Forms.TextBox();
            this.btnWait = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageVariazioni = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnModifica = new System.Windows.Forms.Button();
            this.dgrVariazioni = new System.Windows.Forms.DataGrid();
            this.btnScollega = new System.Windows.Forms.Button();
            this.btnCollega = new System.Windows.Forms.Button();
            this.tabPageAttributi = new System.Windows.Forms.TabPage();
            this.gboxclass05 = new System.Windows.Forms.GroupBox();
            this.txtCodice05 = new System.Windows.Forms.TextBox();
            this.btnCodice05 = new System.Windows.Forms.Button();
            this.txtDenom05 = new System.Windows.Forms.TextBox();
            this.gboxclass04 = new System.Windows.Forms.GroupBox();
            this.txtCodice04 = new System.Windows.Forms.TextBox();
            this.btnCodice04 = new System.Windows.Forms.Button();
            this.txtDenom04 = new System.Windows.Forms.TextBox();
            this.gboxclass03 = new System.Windows.Forms.GroupBox();
            this.txtCodice03 = new System.Windows.Forms.TextBox();
            this.btnCodice03 = new System.Windows.Forms.Button();
            this.txtDenom03 = new System.Windows.Forms.TextBox();
            this.gboxclass02 = new System.Windows.Forms.GroupBox();
            this.txtCodice02 = new System.Windows.Forms.TextBox();
            this.btnCodice02 = new System.Windows.Forms.Button();
            this.txtDenom02 = new System.Windows.Forms.TextBox();
            this.gboxclass01 = new System.Windows.Forms.GroupBox();
            this.txtCodice01 = new System.Windows.Forms.TextBox();
            this.btnCodice01 = new System.Windows.Forms.Button();
            this.txtDenom01 = new System.Windows.Forms.TextBox();
            this.DS = new enactment_default.vistaForm();
            this.gboxStato.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPageVariazioni.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrVariazioni)).BeginInit();
            this.tabPageAttributi.SuspendLayout();
            this.gboxclass05.SuspendLayout();
            this.gboxclass04.SuspendLayout();
            this.gboxclass03.SuspendLayout();
            this.gboxclass02.SuspendLayout();
            this.gboxclass01.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // gboxStato
            // 
            this.gboxStato.Controls.Add(this.rdbInAttesa);
            this.gboxStato.Controls.Add(this.rdbAnnullato);
            this.gboxStato.Controls.Add(this.rdbApprovato);
            this.gboxStato.Location = new System.Drawing.Point(239, 0);
            this.gboxStato.Name = "gboxStato";
            this.gboxStato.Size = new System.Drawing.Size(195, 114);
            this.gboxStato.TabIndex = 3;
            this.gboxStato.TabStop = false;
            this.gboxStato.Text = "Stato";
            // 
            // rdbInAttesa
            // 
            this.rdbInAttesa.Location = new System.Drawing.Point(6, 21);
            this.rdbInAttesa.Name = "rdbInAttesa";
            this.rdbInAttesa.Size = new System.Drawing.Size(155, 16);
            this.rdbInAttesa.TabIndex = 3;
            this.rdbInAttesa.Tag = "enactment.idenactmentstatus:1";
            this.rdbInAttesa.Text = "In attesa di approvazione";
            // 
            // rdbAnnullato
            // 
            this.rdbAnnullato.Location = new System.Drawing.Point(6, 80);
            this.rdbAnnullato.Name = "rdbAnnullato";
            this.rdbAnnullato.Size = new System.Drawing.Size(96, 16);
            this.rdbAnnullato.TabIndex = 1;
            this.rdbAnnullato.Tag = "enactment.idenactmentstatus:3";
            this.rdbAnnullato.Text = "Annullato";
            // 
            // rdbApprovato
            // 
            this.rdbApprovato.Location = new System.Drawing.Point(6, 46);
            this.rdbApprovato.Name = "rdbApprovato";
            this.rdbApprovato.Size = new System.Drawing.Size(96, 28);
            this.rdbApprovato.TabIndex = 0;
            this.rdbApprovato.Tag = "enactment.idenactmentstatus:2";
            this.rdbApprovato.Text = "Approvato";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtNOfficial);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtNumeroDocumento);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtEsercizioDocumento);
            this.groupBox1.Location = new System.Drawing.Point(8, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 114);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Atto";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "Num. Ufficiale:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNOfficial
            // 
            this.txtNOfficial.Location = new System.Drawing.Point(101, 72);
            this.txtNOfficial.Name = "txtNOfficial";
            this.txtNOfficial.Size = new System.Drawing.Size(115, 20);
            this.txtNOfficial.TabIndex = 4;
            this.txtNOfficial.Tag = "enactment.nofficial";
            this.txtNOfficial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(80, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Numero:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNumeroDocumento
            // 
            this.txtNumeroDocumento.Location = new System.Drawing.Point(154, 48);
            this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            this.txtNumeroDocumento.Size = new System.Drawing.Size(62, 20);
            this.txtNumeroDocumento.TabIndex = 2;
            this.txtNumeroDocumento.Tag = "enactment.nenactment";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(80, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Esercizio:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercizioDocumento
            // 
            this.txtEsercizioDocumento.Location = new System.Drawing.Point(154, 24);
            this.txtEsercizioDocumento.Name = "txtEsercizioDocumento";
            this.txtEsercizioDocumento.ReadOnly = true;
            this.txtEsercizioDocumento.Size = new System.Drawing.Size(62, 20);
            this.txtEsercizioDocumento.TabIndex = 1;
            this.txtEsercizioDocumento.TabStop = false;
            this.txtEsercizioDocumento.Tag = "enactment.yenactment";
            // 
            // dataGrid1
            // 
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(0, 0);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(130, 80);
            this.dataGrid1.TabIndex = 0;
            // 
            // btnApprova
            // 
            this.btnApprova.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApprova.Location = new System.Drawing.Point(671, 45);
            this.btnApprova.Name = "btnApprova";
            this.btnApprova.Size = new System.Drawing.Size(107, 23);
            this.btnApprova.TabIndex = 108;
            this.btnApprova.Tag = "";
            this.btnApprova.Text = "Approva l\'atto";
            this.btnApprova.Click += new System.EventHandler(this.btnApprova_Click);
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.Location = new System.Drawing.Point(671, 77);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(107, 23);
            this.btnAnnulla.TabIndex = 107;
            this.btnAnnulla.Tag = "";
            this.btnAnnulla.Text = "Annulla l\'atto";
            this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizione.Location = new System.Drawing.Point(9, 135);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(777, 54);
            this.txtDescrizione.TabIndex = 105;
            this.txtDescrizione.Tag = "enactment.description";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(6, 116);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 16);
            this.label8.TabIndex = 106;
            this.label8.Text = "Descrizione:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.Location = new System.Drawing.Point(562, 196);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 16);
            this.label9.TabIndex = 102;
            this.label9.Text = "Data approvazione:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDataContabile
            // 
            this.txtDataContabile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDataContabile.Location = new System.Drawing.Point(691, 195);
            this.txtDataContabile.Name = "txtDataContabile";
            this.txtDataContabile.Size = new System.Drawing.Size(96, 20);
            this.txtDataContabile.TabIndex = 100;
            this.txtDataContabile.Tag = "enactment.adate";
            // 
            // btnWait
            // 
            this.btnWait.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWait.Location = new System.Drawing.Point(671, 14);
            this.btnWait.Name = "btnWait";
            this.btnWait.Size = new System.Drawing.Size(107, 23);
            this.btnWait.TabIndex = 109;
            this.btnWait.Tag = "";
            this.btnWait.Text = "Rimetti in attesa";
            this.btnWait.Click += new System.EventHandler(this.btnWait_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageVariazioni);
            this.tabControl1.Controls.Add(this.tabPageAttributi);
            this.tabControl1.Location = new System.Drawing.Point(8, 221);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(778, 323);
            this.tabControl1.TabIndex = 110;
            // 
            // tabPageVariazioni
            // 
            this.tabPageVariazioni.Controls.Add(this.groupBox2);
            this.tabPageVariazioni.Location = new System.Drawing.Point(4, 22);
            this.tabPageVariazioni.Name = "tabPageVariazioni";
            this.tabPageVariazioni.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageVariazioni.Size = new System.Drawing.Size(770, 297);
            this.tabPageVariazioni.TabIndex = 0;
            this.tabPageVariazioni.Text = "Variazioni";
            this.tabPageVariazioni.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnModifica);
            this.groupBox2.Controls.Add(this.dgrVariazioni);
            this.groupBox2.Controls.Add(this.btnScollega);
            this.groupBox2.Controls.Add(this.btnCollega);
            this.groupBox2.Location = new System.Drawing.Point(13, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(751, 278);
            this.groupBox2.TabIndex = 102;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Variazioni di Bilancio inserite nell\'Atto";
            // 
            // btnModifica
            // 
            this.btnModifica.Location = new System.Drawing.Point(8, 88);
            this.btnModifica.Name = "btnModifica";
            this.btnModifica.Size = new System.Drawing.Size(75, 23);
            this.btnModifica.TabIndex = 5;
            this.btnModifica.Text = "Modifica...";
            this.btnModifica.Click += new System.EventHandler(this.btnModifica_Click);
            // 
            // dgrVariazioni
            // 
            this.dgrVariazioni.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrVariazioni.DataMember = "";
            this.dgrVariazioni.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgrVariazioni.Location = new System.Drawing.Point(96, 16);
            this.dgrVariazioni.Name = "dgrVariazioni";
            this.dgrVariazioni.Size = new System.Drawing.Size(647, 254);
            this.dgrVariazioni.TabIndex = 3;
            this.dgrVariazioni.TabStop = false;
            this.dgrVariazioni.Tag = "finvarview.documentocollegato";
            // 
            // btnScollega
            // 
            this.btnScollega.Location = new System.Drawing.Point(8, 56);
            this.btnScollega.Name = "btnScollega";
            this.btnScollega.Size = new System.Drawing.Size(75, 23);
            this.btnScollega.TabIndex = 2;
            this.btnScollega.Tag = "";
            this.btnScollega.Text = "Rimuovi";
            this.btnScollega.Click += new System.EventHandler(this.btnScollega_Click);
            // 
            // btnCollega
            // 
            this.btnCollega.Location = new System.Drawing.Point(8, 24);
            this.btnCollega.Name = "btnCollega";
            this.btnCollega.Size = new System.Drawing.Size(75, 23);
            this.btnCollega.TabIndex = 1;
            this.btnCollega.Tag = "";
            this.btnCollega.Text = "Inserisci";
            this.btnCollega.Click += new System.EventHandler(this.btnCollega_Click);
            // 
            // tabPageAttributi
            // 
            this.tabPageAttributi.Controls.Add(this.gboxclass05);
            this.tabPageAttributi.Controls.Add(this.gboxclass04);
            this.tabPageAttributi.Controls.Add(this.gboxclass03);
            this.tabPageAttributi.Controls.Add(this.gboxclass02);
            this.tabPageAttributi.Controls.Add(this.gboxclass01);
            this.tabPageAttributi.Location = new System.Drawing.Point(4, 22);
            this.tabPageAttributi.Name = "tabPageAttributi";
            this.tabPageAttributi.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAttributi.Size = new System.Drawing.Size(770, 297);
            this.tabPageAttributi.TabIndex = 1;
            this.tabPageAttributi.Text = "Attributi";
            this.tabPageAttributi.UseVisualStyleBackColor = true;
            // 
            // gboxclass05
            // 
            this.gboxclass05.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxclass05.Controls.Add(this.txtCodice05);
            this.gboxclass05.Controls.Add(this.btnCodice05);
            this.gboxclass05.Controls.Add(this.txtDenom05);
            this.gboxclass05.Location = new System.Drawing.Point(387, 108);
            this.gboxclass05.Name = "gboxclass05";
            this.gboxclass05.Size = new System.Drawing.Size(370, 82);
            this.gboxclass05.TabIndex = 26;
            this.gboxclass05.TabStop = false;
            this.gboxclass05.Tag = "";
            this.gboxclass05.Text = "Classificazione 5";
            // 
            // txtCodice05
            // 
            this.txtCodice05.Location = new System.Drawing.Point(9, 55);
            this.txtCodice05.Name = "txtCodice05";
            this.txtCodice05.Size = new System.Drawing.Size(337, 20);
            this.txtCodice05.TabIndex = 6;
            // 
            // btnCodice05
            // 
            this.btnCodice05.Location = new System.Drawing.Point(8, 26);
            this.btnCodice05.Name = "btnCodice05";
            this.btnCodice05.Size = new System.Drawing.Size(88, 23);
            this.btnCodice05.TabIndex = 4;
            this.btnCodice05.Tag = "manage.sorting05.tree";
            this.btnCodice05.Text = "Codice";
            this.btnCodice05.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom05
            // 
            this.txtDenom05.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom05.Location = new System.Drawing.Point(123, 8);
            this.txtDenom05.Multiline = true;
            this.txtDenom05.Name = "txtDenom05";
            this.txtDenom05.ReadOnly = true;
            this.txtDenom05.Size = new System.Drawing.Size(223, 41);
            this.txtDenom05.TabIndex = 3;
            this.txtDenom05.TabStop = false;
            this.txtDenom05.Tag = "sorting05.description";
            // 
            // gboxclass04
            // 
            this.gboxclass04.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxclass04.Controls.Add(this.txtCodice04);
            this.gboxclass04.Controls.Add(this.btnCodice04);
            this.gboxclass04.Controls.Add(this.txtDenom04);
            this.gboxclass04.Location = new System.Drawing.Point(387, 18);
            this.gboxclass04.Name = "gboxclass04";
            this.gboxclass04.Size = new System.Drawing.Size(370, 86);
            this.gboxclass04.TabIndex = 25;
            this.gboxclass04.TabStop = false;
            this.gboxclass04.Tag = "";
            this.gboxclass04.Text = "Classificazione 4";
            // 
            // txtCodice04
            // 
            this.txtCodice04.Location = new System.Drawing.Point(6, 60);
            this.txtCodice04.Name = "txtCodice04";
            this.txtCodice04.Size = new System.Drawing.Size(340, 20);
            this.txtCodice04.TabIndex = 6;
            // 
            // btnCodice04
            // 
            this.btnCodice04.Location = new System.Drawing.Point(6, 31);
            this.btnCodice04.Name = "btnCodice04";
            this.btnCodice04.Size = new System.Drawing.Size(88, 23);
            this.btnCodice04.TabIndex = 4;
            this.btnCodice04.Tag = "manage.sorting04.tree";
            this.btnCodice04.Text = "Codice";
            this.btnCodice04.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom04
            // 
            this.txtDenom04.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom04.Location = new System.Drawing.Point(123, 6);
            this.txtDenom04.Multiline = true;
            this.txtDenom04.Name = "txtDenom04";
            this.txtDenom04.ReadOnly = true;
            this.txtDenom04.Size = new System.Drawing.Size(223, 50);
            this.txtDenom04.TabIndex = 3;
            this.txtDenom04.TabStop = false;
            this.txtDenom04.Tag = "sorting04.description";
            // 
            // gboxclass03
            // 
            this.gboxclass03.Controls.Add(this.txtCodice03);
            this.gboxclass03.Controls.Add(this.btnCodice03);
            this.gboxclass03.Controls.Add(this.txtDenom03);
            this.gboxclass03.Location = new System.Drawing.Point(8, 192);
            this.gboxclass03.Name = "gboxclass03";
            this.gboxclass03.Size = new System.Drawing.Size(364, 88);
            this.gboxclass03.TabIndex = 23;
            this.gboxclass03.TabStop = false;
            this.gboxclass03.Tag = "";
            this.gboxclass03.Text = "Classificazione 3";
            // 
            // txtCodice03
            // 
            this.txtCodice03.Location = new System.Drawing.Point(9, 62);
            this.txtCodice03.Name = "txtCodice03";
            this.txtCodice03.Size = new System.Drawing.Size(327, 20);
            this.txtCodice03.TabIndex = 6;
            // 
            // btnCodice03
            // 
            this.btnCodice03.Location = new System.Drawing.Point(9, 35);
            this.btnCodice03.Name = "btnCodice03";
            this.btnCodice03.Size = new System.Drawing.Size(88, 23);
            this.btnCodice03.TabIndex = 4;
            this.btnCodice03.Tag = "manage.sorting03.tree";
            this.btnCodice03.Text = "Codice";
            this.btnCodice03.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom03
            // 
            this.txtDenom03.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom03.Location = new System.Drawing.Point(126, 8);
            this.txtDenom03.Multiline = true;
            this.txtDenom03.Name = "txtDenom03";
            this.txtDenom03.ReadOnly = true;
            this.txtDenom03.Size = new System.Drawing.Size(210, 50);
            this.txtDenom03.TabIndex = 3;
            this.txtDenom03.TabStop = false;
            this.txtDenom03.Tag = "sorting03.description";
            // 
            // gboxclass02
            // 
            this.gboxclass02.Controls.Add(this.txtCodice02);
            this.gboxclass02.Controls.Add(this.btnCodice02);
            this.gboxclass02.Controls.Add(this.txtDenom02);
            this.gboxclass02.Location = new System.Drawing.Point(9, 105);
            this.gboxclass02.Name = "gboxclass02";
            this.gboxclass02.Size = new System.Drawing.Size(364, 88);
            this.gboxclass02.TabIndex = 24;
            this.gboxclass02.TabStop = false;
            this.gboxclass02.Tag = "";
            this.gboxclass02.Text = "Classificazione 2";
            // 
            // txtCodice02
            // 
            this.txtCodice02.Location = new System.Drawing.Point(6, 61);
            this.txtCodice02.Name = "txtCodice02";
            this.txtCodice02.Size = new System.Drawing.Size(332, 20);
            this.txtCodice02.TabIndex = 6;
            // 
            // btnCodice02
            // 
            this.btnCodice02.Location = new System.Drawing.Point(8, 32);
            this.btnCodice02.Name = "btnCodice02";
            this.btnCodice02.Size = new System.Drawing.Size(88, 23);
            this.btnCodice02.TabIndex = 4;
            this.btnCodice02.Tag = "manage.sorting02.tree";
            this.btnCodice02.Text = "Codice";
            this.btnCodice02.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom02
            // 
            this.txtDenom02.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom02.Location = new System.Drawing.Point(126, 6);
            this.txtDenom02.Multiline = true;
            this.txtDenom02.Name = "txtDenom02";
            this.txtDenom02.ReadOnly = true;
            this.txtDenom02.Size = new System.Drawing.Size(212, 52);
            this.txtDenom02.TabIndex = 3;
            this.txtDenom02.TabStop = false;
            this.txtDenom02.Tag = "sorting02.description";
            // 
            // gboxclass01
            // 
            this.gboxclass01.Controls.Add(this.txtCodice01);
            this.gboxclass01.Controls.Add(this.btnCodice01);
            this.gboxclass01.Controls.Add(this.txtDenom01);
            this.gboxclass01.Location = new System.Drawing.Point(9, 16);
            this.gboxclass01.Name = "gboxclass01";
            this.gboxclass01.Size = new System.Drawing.Size(364, 88);
            this.gboxclass01.TabIndex = 22;
            this.gboxclass01.TabStop = false;
            this.gboxclass01.Tag = "";
            this.gboxclass01.Text = "Classificazione 1";
            // 
            // txtCodice01
            // 
            this.txtCodice01.Location = new System.Drawing.Point(6, 62);
            this.txtCodice01.Name = "txtCodice01";
            this.txtCodice01.Size = new System.Drawing.Size(332, 20);
            this.txtCodice01.TabIndex = 5;
            // 
            // btnCodice01
            // 
            this.btnCodice01.Location = new System.Drawing.Point(6, 33);
            this.btnCodice01.Name = "btnCodice01";
            this.btnCodice01.Size = new System.Drawing.Size(88, 23);
            this.btnCodice01.TabIndex = 4;
            this.btnCodice01.Tag = "manage.sorting01.tree";
            this.btnCodice01.Text = "Codice";
            this.btnCodice01.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom01
            // 
            this.txtDenom01.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom01.Location = new System.Drawing.Point(126, 8);
            this.txtDenom01.Multiline = true;
            this.txtDenom01.Name = "txtDenom01";
            this.txtDenom01.ReadOnly = true;
            this.txtDenom01.Size = new System.Drawing.Size(212, 52);
            this.txtDenom01.TabIndex = 3;
            this.txtDenom01.TabStop = false;
            this.txtDenom01.Tag = "sorting01.description";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // Frm_enactment_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(799, 556);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnWait);
            this.Controls.Add(this.btnApprova);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.txtDescrizione);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtDataContabile);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gboxStato);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Frm_enactment_default";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.gboxStato.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPageVariazioni.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrVariazioni)).EndInit();
            this.tabPageAttributi.ResumeLayout(false);
            this.gboxclass05.ResumeLayout(false);
            this.gboxclass05.PerformLayout();
            this.gboxclass04.ResumeLayout(false);
            this.gboxclass04.PerformLayout();
            this.gboxclass03.ResumeLayout(false);
            this.gboxclass03.PerformLayout();
            this.gboxclass02.ResumeLayout(false);
            this.gboxclass02.PerformLayout();
            this.gboxclass01.ResumeLayout(false);
            this.gboxclass01.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        DataAccess Conn;
		public void MetaData_AfterLink(){
			Meta = MetaData.GetMetaData(this);
            QHS = Meta.Conn.GetQueryHelper();
            QHC = new CQueryHelper();
            Conn = Meta.Conn;
            GetData.SetStaticFilter(DS.enactment, QHS.CmpEq("yenactment", Meta.GetSys("esercizio")));
            GetData.SetStaticFilter(DS.finvarview, QHS.CmpEq("yvar", Meta.GetSys("esercizio")));

            DataAccess.SetTableForReading(DS.sorting01, "sorting");
            DataAccess.SetTableForReading(DS.sorting02, "sorting");
            DataAccess.SetTableForReading(DS.sorting03, "sorting");
            DataAccess.SetTableForReading(DS.sorting04, "sorting");
            DataAccess.SetTableForReading(DS.sorting05, "sorting");

            DataTable tUniConfig = Conn.RUN_SELECT("uniconfig", "*", null,
              null, null, null, true);
            if ((tUniConfig != null) && (tUniConfig.Rows.Count > 0))
            {
                DataRow r = tUniConfig.Rows[0];
                object idsorkind1 = r["idsorkind01"];
                object idsorkind2 = r["idsorkind02"];
                object idsorkind3 = r["idsorkind03"];
                object idsorkind4 = r["idsorkind04"];
                object idsorkind5 = r["idsorkind05"];
                CfgFn.SetGBoxClass0(this, 1, idsorkind1);
                CfgFn.SetGBoxClass0(this, 2, idsorkind2);
                CfgFn.SetGBoxClass0(this, 3, idsorkind3);
                CfgFn.SetGBoxClass0(this, 4, idsorkind4);
                CfgFn.SetGBoxClass0(this, 5, idsorkind5);
                if (idsorkind1 == DBNull.Value && idsorkind2 == DBNull.Value &&
                    idsorkind3 == DBNull.Value && idsorkind4 == DBNull.Value && idsorkind5 == DBNull.Value)
                {
                    tabControl1.TabPages.Remove(tabPageAttributi);
                }
            }

		}
      
        public void MetaData_AfterActivation () {
            btnCollega.BackColor  = formcolors.GridButtonBackColor();
            btnCollega.ForeColor  = formcolors.GridButtonForeColor();
            btnScollega.BackColor = formcolors.GridButtonBackColor();
            btnScollega.ForeColor = formcolors.GridButtonForeColor();
            btnModifica.BackColor = formcolors.GridButtonBackColor();
            btnModifica.ForeColor = formcolors.GridButtonForeColor();
        }
     
       
        public void MetaData_AfterClear(){
        gboxStato.Enabled = true;
        btnAnnulla.Visible = false;
        btnApprova.Visible = false;
        btnWait.Visible = false;

        txtEsercizioDocumento.Text=Meta.GetSys("esercizio").ToString();
        btnCollega.Enabled=false;
        btnScollega.Enabled=false;
        btnModifica.Enabled=false;
        
        //gestisciBottoniEsito(false);
        txtNumeroDocumento.ReadOnly = false;
    }
    

    public void MetaData_AfterFill(){
        bool ModoInsert = MetaData.GetMetaData(this).InsertMode;
        bool ModoEdit = MetaData.GetMetaData(this).EditMode;
        DataRow Curr = DS.enactment.Rows[0];
        string filtraAtto= QHS.CmpKey(Curr);
        AbilitaVariazioni(true);

        btnApprova.Enabled = true;
        btnAnnulla.Enabled = true;

        if (ModoEdit) {
            txtNumeroDocumento.ReadOnly = true;
        }
        gboxStato.Enabled = false;

        btnWait.Visible = !rdbInAttesa.Checked;
        btnApprova.Visible = rdbInAttesa.Checked;
        btnAnnulla.Visible = rdbInAttesa.Checked;

        //if (ModoInsert || ModoEdit) {
            if (rdbInAttesa.Checked) {
                AbilitaVariazioni(true);
            }
            else {
                AbilitaVariazioni(false);
            }
        //}
        }

		string CalculateFilterForLinking(bool SQL){
            QueryHelper qh = SQL ? QHS : QHC;
            string MyFilter = "";
            int currentyear=(int)Meta.GetSys("esercizio");
		    //Aggiunge solo le var. di tipo "inserito"
            MyFilter = qh.IsNull("idenactment");
            // in inserimento solo variazioni ufficiali
            if (SQL) {
                MyFilter = qh.AppAnd(MyFilter, 
                    qh.CmpGe("idfinvarstatus", 4), qh.CmpEq("yvar", currentyear), QHS.CmpEq("official", "S"));
            }

			return MyFilter;
		}
         
        private void btnCollega_Click(object sender, System.EventArgs e) {
			
			if (MetaData.Empty(this)) return;
			MetaData.GetFormData(this,true);
			string MyFilter = CalculateFilterForLinking(true);
           	string command = "choose.finvarview.documentocollegato." + MyFilter;
			MetaData.Choose(this,command);
			
		}

		private void btnModifica_Click(object sender, System.EventArgs e) {
			if (Meta.IsEmpty) return;
			Meta.GetFormData(true);
			string MyFilter = CalculateFilterForLinking(false);
			string MyFilterSQL = CalculateFilterForLinking(true);
			Meta.MultipleLinkUnlinkRows("Composizione documento",
				"Movimenti inclusi nel documento selezionato", 
				"Movimenti non inclusi in alcun documento",
				DS.finvarview, MyFilter, MyFilterSQL, "documentocollegato");
		}

		private void btnScollega_Click(object sender, System.EventArgs e) {
			if (Meta.IsEmpty) return; 
			Meta.GetFormData(true);
			MetaData.Unlink_Grid(dgrVariazioni);
            Meta.FreshForm();
		}


      

        private void btnApprova_Click (object sender, EventArgs e) {
            if (!Meta.GetFormData(false)) return;
            DataRow Curr = DS.enactment.Rows[0];
            if (Curr["nofficial"] == DBNull.Value) {
                MessageBox.Show("E' necessario, prima di approvare l'atto, inserirne il numero ufficiale");
                HelpForm.FocusControl(txtNOfficial);
                return;
            }
            if (Curr["adate"] == DBNull.Value) {
                MessageBox.Show("E' necessario, prima di approvare l'atto, inserirne la data di approvazione");
                HelpForm.FocusControl(txtDataContabile);
                return; 
            }
            bool do_update = MessageBox.Show("Attenzione, approvando l'atto " +
                    "e tutte le variazioni in esso contenute che attualmente " +
                    "sono nello stato di 'Inserita' passeranno allo stato di " +
                    " 'Approvata' ", "Conferma", MessageBoxButtons.OKCancel) ==
                        DialogResult.OK;
            if (!do_update) return;

            bool do_update_enactment= false;
            bool do_update_all_finvar_adate = false;
            bool do_update_approved_finvar_adate = false;

            //do_update = MessageBox.Show("Si desidera aggiornare anche i campi Data Contabile, Provvedimento,Data provvedimento e Numero " +
            //    "delle variazioni contenute nell'atto?", "Conferma", MessageBoxButtons.OKCancel) ==
            //        DialogResult.OK;

            AskConfirm Ask = new AskConfirm(0);
            DialogResult AskRes = Ask.ShowDialog(this);
            if (AskRes != DialogResult.OK) return;

            do_update_enactment = Ask.chk_do_update_enactment.Checked;
            do_update_all_finvar_adate = Ask.rdb_do_update_all_finvar_adate.Checked;
            do_update_approved_finvar_adate = Ask.rdb_do_update_approved_finvar_adate.Checked;
          

            foreach (DataRow RR in DS.finvarview.Select()) {
                if (do_update_enactment)
                {
                    RR["enactment"] = Curr["description"];
                    RR["enactmentdate"] = Curr["adate"];
                    RR["nenactment"] = Curr["nofficial"];
                }
                if (do_update_all_finvar_adate)
                {
                    RR["adate"] = Curr["adate"];
                }
                if (RR["idfinvarstatus"].ToString() == "4"){
                    RR["idfinvarstatus"] = 5;
                    if (do_update_approved_finvar_adate)
                        RR["adate"] = Curr["adate"];
                }
            }

            Curr["idenactmentstatus"] = 2;
            Meta.SaveFormData();
            Meta.FreshForm();
            if (!DS.HasChanges()) SendMails();

        }

        private void btnWait_Click(object sender, EventArgs e) {
            if (!Meta.GetFormData(false)) return;
            bool do_update = MessageBox.Show("Attenzione, l'atto sarà rimesso nello stato di 'In attesa di approvazione' " +
                                "e tutte le variazioni contenute che attualmente "+
                                "sono nello stato di 'approvata' retrocederanno nuovamente allo stato "+
                                " 'Inserita' ", "Conferma", MessageBoxButtons.OKCancel) ==
                    DialogResult.OK;
            if (!do_update) return;
            foreach (DataRow RR in DS.finvarview.Select()) {
                if (RR["idfinvarstatus"].ToString() == "5")
                    RR["idfinvarstatus"] = 4;
            }
            DataRow Curr = DS.enactment.Rows[0];
            Curr["idenactmentstatus"] = 1;
            Meta.SaveFormData();
            Meta.FreshForm();
            if (!DS.HasChanges()) SendMails();

        }

        private void btnAnnulla_Click(object sender, EventArgs e) {
            if (!Meta.GetFormData(false)) return;
            bool do_update = MessageBox.Show("Attenzione l'atto sarà annullato " +
                                "e tutte le variazioni in esso contenute attualmente nello stato di 'Inserita'" +
                                "passeranno allo stato " +
                                " 'Annullata' ", "Conferma", MessageBoxButtons.OKCancel) ==
                    DialogResult.OK;
            if (!do_update) return;
            foreach (DataRow RR in DS.finvarview.Select()) {
                if (RR["idfinvarstatus"].ToString() == "4")
                    RR["idfinvarstatus"] = 6;
            }
            DataRow Curr = DS.enactment.Rows[0];
            Curr["idenactmentstatus"] = 3;
            Meta.SaveFormData();
            Meta.FreshForm();
            if (!DS.HasChanges()) SendMails();

           
        }

        void AbilitaVariazioni(bool enable) {
            btnCollega.Enabled = enable;
            btnScollega.Enabled = enable;
            btnModifica.Enabled = enable;
        }

        void SendMails() {

            DataRow Curr = DS.enactment.Rows[0];
            foreach (DataRow V in DS.finvarview.Rows) {
                SendMailVar(V);
            }


        }

        void SendMailVar(DataRow Var) {
            if (Var["idman"] == DBNull.Value) return;
            int idman = CfgFn.GetNoNullInt32(Var["idman"]);
            string filter = QHS.CmpEq("idman", idman);

            DataTable T = Meta.Conn.RUN_SELECT("manager", "*", null, filter, null, false);
            if (T.Rows[0]["wantswarn"].ToString().ToUpper() != "S") return;

            string mailto = T.Rows[0]["email"].ToString();
            if (mailto == "") return;

            int CurrentStatus = CfgFn.GetNoNullInt32(Var["idfinvarstatus"]);
            string currstatustext = "";
            switch (CurrentStatus) {
                case 3:
                    currstatustext = "Da Correggere";
                    break;
                case 4:
                    currstatustext = "Inserita";
                    break;
                case 5:
                    currstatustext = "Approvato";
                    break;
                case 6:
                    currstatustext = "Annullato";
                    break;
            }



            SendMail SM = new SendMail();
            SM.UseSMTPLoginAsFromField = true;
            SM.Conn = Meta.Conn;

            SM.To = mailto;
            string MsgBody = "";
            MsgBody = "La variazione di bilancio numero " + Var["nvar"] + " relativa all'esercizio " + Var["yvar"] + "\r\n";
            MsgBody += "E' passata nello stato '" + currstatustext + "'.\r\n";

            MsgBody += " Dettagli:\r\n";

            DataTable Finvar = Meta.Conn.RUN_SELECT("finvar", "*", null, QHS.CmpKey(Var), null, false);
            DataRow V = Finvar.Rows[0];

            if (Var["description"].ToString() != "") MsgBody += Var["description"].ToString() + "\r\n";
            if (V["annotation"].ToString() != "") MsgBody += V["annotation"].ToString() + "\r\n";
            MsgBody += "\r\n\r\n";
            DataTable Finvardetailview = Meta.Conn.RUN_SELECT("finvardetailview", "*", null, QHS.CmpKey(Var), null, false);
            foreach (DataRow RD in Finvardetailview.Rows) {
                MsgBody += GetTextForFinVarDetail(RD);
                if (RD["description"].ToString() != "") MsgBody += RD["description"].ToString() + "\r\n";
                if (RD["annotation"].ToString() != "") MsgBody += RD["annotation"].ToString() + "\r\n";
            }
            MsgBody += "\r\n";


            SM.Subject = "Notifica cambiamento di stato variazione di bilancio";
            SM.MessageBody = MsgBody;
            SM.Conn = Meta.Conn;
            
            if (!SM.Send()) {
                if (SM.ErrorMessage != "") MessageBox.Show(SM.ErrorMessage, "Errore");
            }

        }

        string GetTextForFinVarDetail(DataRow R) {
            string S = "";
            S += "Voce Bilancio " + R["codefin"].ToString() + " - " + R["finance"].ToString() + "\r\n";
            S += "UPB " + R["codeupb"].ToString() + " - " + R["upb"].ToString() + "\r\n";
            S += "Importo variazione:" + CfgFn.GetNoNullDecimal(R["amount"]).ToString("c") + "\r\n"; ;
            return S;
        }
	}
}
