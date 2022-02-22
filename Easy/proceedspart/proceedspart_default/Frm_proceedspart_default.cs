
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
using metaeasylibrary;
using funzioni_configurazione;//funzioni_configurazione

namespace proceedspart_default//assegnazioneincassi//
{
	/// <summary>
	/// Summary description for frmassegnazioneincassi.
	/// </summary>
	public class Frm_proceedspart_default : MetaDataForm
	{
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtDataContabile;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtImporto;
		private System.Windows.Forms.TextBox txtDescrizione;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox grpBilancio;
		private System.Windows.Forms.TextBox txtDescrBilancio;
		private System.Windows.Forms.TextBox txtBilancio;
		private System.Windows.Forms.Button btnBilancio;
		private System.Windows.Forms.GroupBox grpAssegnazione;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtNumAssegnazione;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtEsercAssegnazione;
		private System.Windows.Forms.GroupBox grpAccertamento;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtNumEntrata;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtEsercEntrata;
        private System.Windows.Forms.Button btnAccertamento;
		private System.ComponentModel.IContainer components;
		MetaData Meta;
		DataAccess Conn;
		string filteresercizio;
		private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox1;
        public vistaForm DS;
        private Button btnCassiereEntrata;
        private ComboBox cmbCassiereEntrata;
        private GroupBox groupBox4;
        private Button btnCassiereUscita;
        private ComboBox cmbCassiereUscita;
        private GroupBox gboxUpb;
        private TextBox txtDescrizioneUpbUscita;
        private TextBox txtUpbUscita;
        private Button btnUpbUscita;
        private GroupBox groupBox2;
        private TextBox TxtDescizioneUpbEntrata;
        private TextBox txtUpbEntrata;
        private Button btnUpbEntrata;
		string command;

		public Frm_proceedspart_default()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            DataAccess.SetTableForReading(DS.treasurerincome, "treasurer");
            DataAccess.SetTableForReading(DS.upbincome, "upb");

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_proceedspart_default));
            this.label7 = new System.Windows.Forms.Label();
            this.txtDataContabile = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtImporto = new System.Windows.Forms.TextBox();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.grpBilancio = new System.Windows.Forms.GroupBox();
            this.txtDescrBilancio = new System.Windows.Forms.TextBox();
            this.txtBilancio = new System.Windows.Forms.TextBox();
            this.btnBilancio = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.grpAssegnazione = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumAssegnazione = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEsercAssegnazione = new System.Windows.Forms.TextBox();
            this.grpAccertamento = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TxtDescizioneUpbEntrata = new System.Windows.Forms.TextBox();
            this.txtUpbEntrata = new System.Windows.Forms.TextBox();
            this.btnUpbEntrata = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCassiereEntrata = new System.Windows.Forms.Button();
            this.cmbCassiereEntrata = new System.Windows.Forms.ComboBox();
            this.DS = new proceedspart_default.vistaForm();
            this.txtNumEntrata = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEsercEntrata = new System.Windows.Forms.TextBox();
            this.btnAccertamento = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnCassiereUscita = new System.Windows.Forms.Button();
            this.cmbCassiereUscita = new System.Windows.Forms.ComboBox();
            this.gboxUpb = new System.Windows.Forms.GroupBox();
            this.txtDescrizioneUpbUscita = new System.Windows.Forms.TextBox();
            this.txtUpbUscita = new System.Windows.Forms.TextBox();
            this.btnUpbUscita = new System.Windows.Forms.Button();
            this.grpBilancio.SuspendLayout();
            this.grpAssegnazione.SuspendLayout();
            this.grpAccertamento.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.gboxUpb.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(468, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 16);
            this.label7.TabIndex = 85;
            this.label7.Text = "Data contabile:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDataContabile
            // 
            this.txtDataContabile.Location = new System.Drawing.Point(574, 44);
            this.txtDataContabile.Name = "txtDataContabile";
            this.txtDataContabile.Size = new System.Drawing.Size(104, 20);
            this.txtDataContabile.TabIndex = 3;
            this.txtDataContabile.Tag = "proceedspart.adate?proceedspartview.adate";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(468, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 16);
            this.label6.TabIndex = 83;
            this.label6.Text = "Importo:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtImporto
            // 
            this.txtImporto.Location = new System.Drawing.Point(574, 16);
            this.txtImporto.Name = "txtImporto";
            this.txtImporto.Size = new System.Drawing.Size(104, 20);
            this.txtImporto.TabIndex = 2;
            this.txtImporto.Tag = "proceedspart.amount?proceedspartview.amount";
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Location = new System.Drawing.Point(104, 16);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(248, 84);
            this.txtDescrizione.TabIndex = 1;
            this.txtDescrizione.Tag = "proceedspart.description?proceedspartview.description";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 80;
            this.label5.Text = "Descrizione:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpBilancio
            // 
            this.grpBilancio.Controls.Add(this.txtDescrBilancio);
            this.grpBilancio.Controls.Add(this.txtBilancio);
            this.grpBilancio.Controls.Add(this.btnBilancio);
            this.grpBilancio.Location = new System.Drawing.Point(364, 190);
            this.grpBilancio.Name = "grpBilancio";
            this.grpBilancio.Size = new System.Drawing.Size(328, 124);
            this.grpBilancio.TabIndex = 3;
            this.grpBilancio.TabStop = false;
            this.grpBilancio.Tag = "AutoManage.txtBilancio.treesupb";
            this.grpBilancio.Text = "Bilancio";
            // 
            // txtDescrBilancio
            // 
            this.txtDescrBilancio.Location = new System.Drawing.Point(128, 16);
            this.txtDescrBilancio.Multiline = true;
            this.txtDescrBilancio.Name = "txtDescrBilancio";
            this.txtDescrBilancio.ReadOnly = true;
            this.txtDescrBilancio.Size = new System.Drawing.Size(192, 76);
            this.txtDescrBilancio.TabIndex = 54;
            this.txtDescrBilancio.TabStop = false;
            this.txtDescrBilancio.Tag = "finview.title";
            // 
            // txtBilancio
            // 
            this.txtBilancio.Location = new System.Drawing.Point(10, 98);
            this.txtBilancio.Name = "txtBilancio";
            this.txtBilancio.Size = new System.Drawing.Size(310, 20);
            this.txtBilancio.TabIndex = 1;
            this.txtBilancio.Tag = "finview.codefin?proceedspartview.codefin";
            // 
            // btnBilancio
            // 
            this.btnBilancio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBilancio.ImageIndex = 0;
            this.btnBilancio.ImageList = this.imageList1;
            this.btnBilancio.Location = new System.Drawing.Point(10, 68);
            this.btnBilancio.Name = "btnBilancio";
            this.btnBilancio.Size = new System.Drawing.Size(104, 24);
            this.btnBilancio.TabIndex = 62;
            this.btnBilancio.TabStop = false;
            this.btnBilancio.Tag = "";
            this.btnBilancio.Text = "Bilancio:";
            this.btnBilancio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBilancio.Click += new System.EventHandler(this.btnBilancio_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            // 
            // grpAssegnazione
            // 
            this.grpAssegnazione.Controls.Add(this.label1);
            this.grpAssegnazione.Controls.Add(this.txtNumAssegnazione);
            this.grpAssegnazione.Controls.Add(this.label2);
            this.grpAssegnazione.Controls.Add(this.txtEsercAssegnazione);
            this.grpAssegnazione.Location = new System.Drawing.Point(6, 8);
            this.grpAssegnazione.Name = "grpAssegnazione";
            this.grpAssegnazione.Size = new System.Drawing.Size(120, 104);
            this.grpAssegnazione.TabIndex = 2;
            this.grpAssegnazione.TabStop = false;
            this.grpAssegnazione.Text = "Assegnazione";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Numero:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNumAssegnazione
            // 
            this.txtNumAssegnazione.Location = new System.Drawing.Point(8, 72);
            this.txtNumAssegnazione.Name = "txtNumAssegnazione";
            this.txtNumAssegnazione.Size = new System.Drawing.Size(96, 20);
            this.txtNumAssegnazione.TabIndex = 1;
            this.txtNumAssegnazione.Tag = "proceedspart.nproceedspart?proceedspartview.nproceedspart";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Esercizio:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEsercAssegnazione
            // 
            this.txtEsercAssegnazione.Location = new System.Drawing.Point(8, 32);
            this.txtEsercAssegnazione.Name = "txtEsercAssegnazione";
            this.txtEsercAssegnazione.ReadOnly = true;
            this.txtEsercAssegnazione.Size = new System.Drawing.Size(56, 20);
            this.txtEsercAssegnazione.TabIndex = 8;
            this.txtEsercAssegnazione.TabStop = false;
            this.txtEsercAssegnazione.Tag = "proceedspart.yproceedspart?proceedspartview.yproceedspart";
            // 
            // grpAccertamento
            // 
            this.grpAccertamento.Controls.Add(this.groupBox2);
            this.grpAccertamento.Controls.Add(this.label3);
            this.grpAccertamento.Controls.Add(this.btnCassiereEntrata);
            this.grpAccertamento.Controls.Add(this.cmbCassiereEntrata);
            this.grpAccertamento.Controls.Add(this.txtNumEntrata);
            this.grpAccertamento.Controls.Add(this.label4);
            this.grpAccertamento.Controls.Add(this.txtEsercEntrata);
            this.grpAccertamento.Controls.Add(this.btnAccertamento);
            this.grpAccertamento.Location = new System.Drawing.Point(132, 8);
            this.grpAccertamento.Name = "grpAccertamento";
            this.grpAccertamento.Size = new System.Drawing.Size(560, 173);
            this.grpAccertamento.TabIndex = 1;
            this.grpAccertamento.TabStop = false;
            this.grpAccertamento.Tag = "";
            this.grpAccertamento.Text = "???";
            this.grpAccertamento.Enter += new System.EventHandler(this.grpAccertamento_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TxtDescizioneUpbEntrata);
            this.groupBox2.Controls.Add(this.txtUpbEntrata);
            this.groupBox2.Controls.Add(this.btnUpbEntrata);
            this.groupBox2.Location = new System.Drawing.Point(152, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(400, 113);
            this.groupBox2.TabIndex = 98;
            this.groupBox2.TabStop = false;
            this.groupBox2.Tag = "AutoChoose.txtUpbEntrata.default.(active=\'S\')";
            this.groupBox2.Text = "UPB";
            // 
            // TxtDescizioneUpbEntrata
            // 
            this.TxtDescizioneUpbEntrata.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtDescizioneUpbEntrata.Location = new System.Drawing.Point(99, 17);
            this.TxtDescizioneUpbEntrata.Multiline = true;
            this.TxtDescizioneUpbEntrata.Name = "TxtDescizioneUpbEntrata";
            this.TxtDescizioneUpbEntrata.ReadOnly = true;
            this.TxtDescizioneUpbEntrata.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtDescizioneUpbEntrata.Size = new System.Drawing.Size(293, 59);
            this.TxtDescizioneUpbEntrata.TabIndex = 0;
            this.TxtDescizioneUpbEntrata.TabStop = false;
            this.TxtDescizioneUpbEntrata.Tag = "upbincome.title";
            // 
            // txtUpbEntrata
            // 
            this.txtUpbEntrata.Location = new System.Drawing.Point(6, 83);
            this.txtUpbEntrata.Name = "txtUpbEntrata";
            this.txtUpbEntrata.Size = new System.Drawing.Size(386, 20);
            this.txtUpbEntrata.TabIndex = 1;
            this.txtUpbEntrata.Tag = "upbincome.codeupb?proceedspartview.codeupbincome";
            // 
            // btnUpbEntrata
            // 
            this.btnUpbEntrata.BackColor = System.Drawing.SystemColors.Control;
            this.btnUpbEntrata.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpbEntrata.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUpbEntrata.Location = new System.Drawing.Point(6, 60);
            this.btnUpbEntrata.Name = "btnUpbEntrata";
            this.btnUpbEntrata.Size = new System.Drawing.Size(79, 20);
            this.btnUpbEntrata.TabIndex = 0;
            this.btnUpbEntrata.TabStop = false;
            this.btnUpbEntrata.Tag = "manage.upbincome.tree";
            this.btnUpbEntrata.Text = "U.P.B.";
            this.btnUpbEntrata.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(2, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Numero:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCassiereEntrata
            // 
            this.btnCassiereEntrata.Location = new System.Drawing.Point(21, 135);
            this.btnCassiereEntrata.Name = "btnCassiereEntrata";
            this.btnCassiereEntrata.Size = new System.Drawing.Size(125, 24);
            this.btnCassiereEntrata.TabIndex = 96;
            this.btnCassiereEntrata.TabStop = false;
            this.btnCassiereEntrata.Tag = "choose.treasurerincome.lista";
            this.btnCassiereEntrata.Text = "Cassiere per incasso";
            this.btnCassiereEntrata.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbCassiereEntrata
            // 
            this.cmbCassiereEntrata.DataSource = this.DS.treasurerincome;
            this.cmbCassiereEntrata.DisplayMember = "description";
            this.cmbCassiereEntrata.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCassiereEntrata.Location = new System.Drawing.Point(152, 138);
            this.cmbCassiereEntrata.Name = "cmbCassiereEntrata";
            this.cmbCassiereEntrata.Size = new System.Drawing.Size(400, 21);
            this.cmbCassiereEntrata.TabIndex = 95;
            this.cmbCassiereEntrata.Tag = "treasurerincome.idtreasurer?proceedspartview.idtreasurerincome";
            this.cmbCassiereEntrata.ValueMember = "idtreasurer";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // txtNumEntrata
            // 
            this.txtNumEntrata.Location = new System.Drawing.Point(66, 72);
            this.txtNumEntrata.Name = "txtNumEntrata";
            this.txtNumEntrata.Size = new System.Drawing.Size(80, 20);
            this.txtNumEntrata.TabIndex = 2;
            this.txtNumEntrata.Tag = "incomeview.nmov?proceedspartview.nmov";
            this.txtNumEntrata.Leave += new System.EventHandler(this.txtNumEntrata_Leave);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(2, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Esercizio:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercEntrata
            // 
            this.txtEsercEntrata.Location = new System.Drawing.Point(66, 48);
            this.txtEsercEntrata.Name = "txtEsercEntrata";
            this.txtEsercEntrata.Size = new System.Drawing.Size(80, 20);
            this.txtEsercEntrata.TabIndex = 1;
            this.txtEsercEntrata.Tag = "incomeview.ymov.year?proceedspartview.ymov.year";
            this.txtEsercEntrata.Leave += new System.EventHandler(this.txtEsercEntrata_Leave);
            // 
            // btnAccertamento
            // 
            this.btnAccertamento.Location = new System.Drawing.Point(10, 16);
            this.btnAccertamento.Name = "btnAccertamento";
            this.btnAccertamento.Size = new System.Drawing.Size(128, 23);
            this.btnAccertamento.TabIndex = 0;
            this.btnAccertamento.TabStop = false;
            this.btnAccertamento.Tag = "";
            this.btnAccertamento.Text = "???";
            this.btnAccertamento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAccertamento.Click += new System.EventHandler(this.btnAccertamento_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDescrizione);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtImporto);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtDataContabile);
            this.groupBox1.Location = new System.Drawing.Point(6, 361);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(686, 107);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dati Contabili";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnCassiereUscita);
            this.groupBox4.Controls.Add(this.cmbCassiereUscita);
            this.groupBox4.Controls.Add(this.gboxUpb);
            this.groupBox4.Location = new System.Drawing.Point(6, 187);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(352, 168);
            this.groupBox4.TabIndex = 96;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Progetto finanziato";
            // 
            // btnCassiereUscita
            // 
            this.btnCassiereUscita.Location = new System.Drawing.Point(3, 133);
            this.btnCassiereUscita.Name = "btnCassiereUscita";
            this.btnCassiereUscita.Size = new System.Drawing.Size(62, 24);
            this.btnCassiereUscita.TabIndex = 96;
            this.btnCassiereUscita.TabStop = false;
            this.btnCassiereUscita.Tag = "choose.treasurer.lista";
            this.btnCassiereUscita.Text = "Cassiere:";
            this.btnCassiereUscita.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbCassiereUscita
            // 
            this.cmbCassiereUscita.DataSource = this.DS.treasurer;
            this.cmbCassiereUscita.DisplayMember = "description";
            this.cmbCassiereUscita.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCassiereUscita.Location = new System.Drawing.Point(71, 136);
            this.cmbCassiereUscita.Name = "cmbCassiereUscita";
            this.cmbCassiereUscita.Size = new System.Drawing.Size(252, 21);
            this.cmbCassiereUscita.TabIndex = 95;
            this.cmbCassiereUscita.Tag = "upb.idtreasurer?proceedspartview.idtreasurer";
            this.cmbCassiereUscita.ValueMember = "idtreasurer";
            // 
            // gboxUpb
            // 
            this.gboxUpb.Controls.Add(this.txtDescrizioneUpbUscita);
            this.gboxUpb.Controls.Add(this.txtUpbUscita);
            this.gboxUpb.Controls.Add(this.btnUpbUscita);
            this.gboxUpb.Location = new System.Drawing.Point(3, 16);
            this.gboxUpb.Name = "gboxUpb";
            this.gboxUpb.Size = new System.Drawing.Size(328, 111);
            this.gboxUpb.TabIndex = 94;
            this.gboxUpb.TabStop = false;
            this.gboxUpb.Tag = "AutoChoose.txtUpbUscita.default.(active=\'S\')";
            this.gboxUpb.Text = "UPB";
            // 
            // txtDescrizioneUpbUscita
            // 
            this.txtDescrizioneUpbUscita.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizioneUpbUscita.Location = new System.Drawing.Point(123, 16);
            this.txtDescrizioneUpbUscita.Multiline = true;
            this.txtDescrizioneUpbUscita.Name = "txtDescrizioneUpbUscita";
            this.txtDescrizioneUpbUscita.ReadOnly = true;
            this.txtDescrizioneUpbUscita.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescrizioneUpbUscita.Size = new System.Drawing.Size(197, 63);
            this.txtDescrizioneUpbUscita.TabIndex = 0;
            this.txtDescrizioneUpbUscita.TabStop = false;
            this.txtDescrizioneUpbUscita.Tag = "upb.title";
            // 
            // txtUpbUscita
            // 
            this.txtUpbUscita.Location = new System.Drawing.Point(5, 85);
            this.txtUpbUscita.Name = "txtUpbUscita";
            this.txtUpbUscita.Size = new System.Drawing.Size(315, 20);
            this.txtUpbUscita.TabIndex = 1;
            this.txtUpbUscita.Tag = "upb.codeupb?proceedspartview.codeupb";
            // 
            // btnUpbUscita
            // 
            this.btnUpbUscita.BackColor = System.Drawing.SystemColors.Control;
            this.btnUpbUscita.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpbUscita.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUpbUscita.Location = new System.Drawing.Point(8, 59);
            this.btnUpbUscita.Name = "btnUpbUscita";
            this.btnUpbUscita.Size = new System.Drawing.Size(86, 20);
            this.btnUpbUscita.TabIndex = 0;
            this.btnUpbUscita.TabStop = false;
            this.btnUpbUscita.Tag = "";
            this.btnUpbUscita.Text = "U.P.B.";
            this.btnUpbUscita.UseVisualStyleBackColor = false;
            this.btnUpbUscita.Click += new System.EventHandler(this.btnUpbUscita_Click);
            // 
            // Frm_proceedspart_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(702, 493);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpBilancio);
            this.Controls.Add(this.grpAssegnazione);
            this.Controls.Add(this.grpAccertamento);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Frm_proceedspart_default";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmassegnazioneincassi";
            this.grpBilancio.ResumeLayout(false);
            this.grpBilancio.PerformLayout();
            this.grpAssegnazione.ResumeLayout(false);
            this.grpAssegnazione.PerformLayout();
            this.grpAccertamento.ResumeLayout(false);
            this.grpAccertamento.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.gboxUpb.ResumeLayout(false);
            this.gboxUpb.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion
        CQueryHelper QHC;
        QueryHelper QHS;

		public void MetaData_AfterLink() {
			Meta=MetaData.GetMetaData(this);
			Conn = Meta.Conn;

            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();

			filteresercizio=QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
			GetData.CacheTable(DS.incomephase);
			GetData.SetStaticFilter(DS.finview, QHS.AppAnd(filteresercizio, QHS.CmpEq("finpart",'S')));
			GetData.SetStaticFilter(DS.incomeview, filteresercizio);
            GetData.CacheTable(DS.config, filteresercizio, null, false);

			DS.incomeview.ExtendedProperties["sort_by"]="ymov desc, nmov desc";
			command="";
		}

		void CambiaFiltroMovimento(bool SearchMode){
			string filter;
            int maxfase = CfgFn.GetNoNullInt32(Meta.GetSys("maxincomephase"));
			filter=QHS.CmpEq("nphase", maxfase);
			if (!SearchMode) filter = QHS.AppAnd(filter, QHS.CmpNe("unpartitioned", 0));
			//grpAccertamento.Tag+="."+filter;
			command="choose.incomeview.assegnazionecredito"+"."+filter;
		}

		public void MetaData_BeforeActivation() {
			string DescrFase="";
//			string filter="";
			int maxfase=0;
            maxfase = CfgFn.GetNoNullInt32(Meta.GetSys("maxincomephase"));
			DataRow[] fasi = DS.incomephase.Select(QHC.CmpEq("nphase", maxfase));
			if (fasi.Length==1) {
				DescrFase=fasi[0]["description"].ToString();
//				filter="(codicefase='"+fasi[0]["codicefase"].ToString()+"')"+
//					" AND (assegnare <> 0)";
//				grpAccertamento.Tag+="."+filter;
//				command="choose.entrataview.assegnazionecredito"+"."+filter;
				grpAccertamento.Text=DescrFase;
				btnAccertamento.Text=DescrFase;
			}
		}

		public void MetaData_AfterClear() {
			txtEsercAssegnazione.Text=Meta.GetSys("esercizio").ToString();
			grpAccertamento.Enabled=true;
			if (!Meta.GointToInsertMode) CambiaFiltroMovimento(true);
			if (Meta.IsEmpty)
			{
				txtEsercEntrata.Text ="";
				txtEsercEntrata.ReadOnly=false;
			}
            string f = QHS.AppAnd(filteresercizio, QHS.CmpEq("finpart",'S'), QHC.CmpEq("idupb", "0001"));
			GetData.SetStaticFilter(DS.finview, f);
            EnableControls(true);
    	}
        public void EnableControls(bool enable){
            btnUpbEntrata.Enabled = enable;
            txtUpbEntrata.ReadOnly = !enable;
            btnCassiereEntrata.Enabled = enable;
            cmbCassiereEntrata.Enabled = enable;
            btnCassiereUscita.Enabled = enable;
            cmbCassiereUscita.Enabled = enable;

        }

		public void MetaData_AfterFill() {
			string filter;
			if (!Meta.InsertMode){
				grpAccertamento.Enabled=false;
			}
			if (Meta.InsertMode)
			{
				txtEsercEntrata.Text = Meta.GetSys("esercizio").ToString();
				txtEsercEntrata.ReadOnly=true;
			}
			CambiaFiltroMovimento(false);
			
			if (DS.incomeview.Rows.Count>0){
				//
				filter = QHS.CmpEq("idupb", DS.incomeview.Rows[0]["idupb"]);
			}
			else {
                filter = QHS.CmpEq("idupb", "0001");
			}
            string f = QHS.AppAnd(filteresercizio, QHS.CmpEq("finpart", 'S'), filter);
			GetData.SetStaticFilter(DS.finview, f);
            EnableControls(false);
		}

		private void DoChooseCommand(Control sender){			
			string filter="";
			string mycommand=command;
			if  (sender==txtNumEntrata){
				filter=Meta.myHelpForm.GetSpecificCondition(grpAccertamento.Controls, "incomeview");
			}
			else {
				string eserc = txtEsercEntrata.Text.Trim();
				if (eserc!="") filter = QHS.CmpEq("ymov", eserc);
			}
			if (Meta.InsertMode) {
				string filter1= QHS.CmpEq("ymov", Meta.GetSys("esercizio"));
				filter = GetData.MergeFilters(filter,filter1);
				mycommand = QHS.AppAnd(mycommand, filter);
			}
			if (!(Meta.InsertMode) && (filter!=""))
                mycommand = QHS.AppAnd(mycommand, filter);
			
			if (!MetaData.Choose(this,mycommand))
			{
				if (sender!=null) sender.Focus();
			};
		}

		// restituisce l'importo per la nuova assegnazione (0 se c'è qualche anomalia)
		decimal GetImporto(DataRow RigaEntrataView)
		{
			string filter = QHS.AppAnd(QHS.CmpEq("idinc", RigaEntrataView["idinc"]), 
				QHS.CmpEq("ayear", RigaEntrataView["ayear"]));
			DataTable ImportoEntrata = Meta.Conn.RUN_SELECT("incometotal","*",null,filter, null, true);
			if (ImportoEntrata.Rows.Count!=1) return 0;
			DataRow R = ImportoEntrata.Rows[0];
			decimal importocorrente = CfgFn.GetNoNullDecimal(R["curramount"]);
			decimal importoassegnato = CfgFn.GetNoNullDecimal(R["partitioned"]);
			decimal importoassegnazione = importocorrente - importoassegnato;
			if (importoassegnazione >= 0) 
				return importoassegnazione;
			else
				return 0;
		}

		public void MetaData_AfterRowSelect(DataTable T, DataRow R)
		{
			if (T.TableName == "incomeview"){
				if (Meta.InsertMode){
					if (R==null){
						txtImporto.Text="";
						DS.proceedspart.Rows[0]["amount"]=DBNull.Value;
						return;
					}
//					decimal D = Convert.ToDecimal(R["importocorrente"]);
//					txtImporto.Text= D.ToString("C");
					Meta.GetFormData(true);
					DS.proceedspart.Rows[0]["amount"]=GetImporto(R);
					Meta.FreshForm(); 
				}
			}
            if (T.TableName == "upb"){
                if(R==null)return;
                ImpostaCassiere(R);
            }
		}

        void ImpostaCassiere(DataRow UPB){
            if (Meta.IsEmpty) return;
            DataRow Curr = DS.proceedspart.Rows[0];
            if (UPB["idtreasurer"] != DBNull.Value){
                //Curr["idtreasurer"] = UPB["idtreasurer"];
                HelpForm.SetComboBoxValue(cmbCassiereUscita, UPB["idtreasurer"]);
            }
       }

            void ClearEntrata(bool ClearEsercizio){
			txtImporto.Text="";
			txtNumAssegnazione.Text="";
			txtNumEntrata.Text="";
			if (ClearEsercizio) txtEsercEntrata.Text="";
			if (Meta.IsEmpty) return;
			DS.proceedspart.Rows[0]["idinc"]=0;
			DS.proceedspart.Rows[0]["nproceedspart"]=0;
			DS.proceedspart.Rows[0]["amount"]=DBNull.Value;
		}

		private void btnAccertamento_Click(object sender, System.EventArgs e) {
			DoChooseCommand(null);
		}

		private void txtEsercEntrata_Leave(object sender, System.EventArgs e) {
			string esercentrata=txtEsercEntrata.Text.Trim();
			if (esercentrata==""){
				MetaData.Choose(this, "choose.incomeview.unknown.clear");
				return;
			}
			
			//if txtEsercEntrata is not Empty:
			if (Meta.IsEmpty) return;
				
			if(DS.incomeview.Rows.Count>0 ){
				if (esercentrata== DS.incomeview.Rows[0]["ymov"].ToString())
					return;
				else{
					ClearEntrata(false);
					return;
				}	
			}

		}

		private void txtNumEntrata_Leave(object sender, System.EventArgs e) {
			if (txtNumEntrata.Text.Trim()!=""){
				DoChooseCommand((Control)sender);
				return;
			}
			//if txtNumentrata is empty:
			if (Meta.IsEmpty) return;
			ClearEntrata(false);	

		}
        bool UsaCrediti() {
            if (DS.config.Rows.Count == 0) return false;
            if (DS.config.Rows[0]["flagcredit"].ToString().ToUpper() == "S") return true;
            return false;
        }
        

		private void btnBilancio_Click(object sender, System.EventArgs e) {
			string filter;
			int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
		
			string filteridfin= QHS.AppAnd(QHS.CmpEq("ayear", esercizio), QHS.BitSet("flag", 0));
			DS.finview.Clear();
			//Il filtro sull'UPB c'è sempre
			if (DS.incomeview.Rows.Count>0){
				//
				filter = QHS.CmpEq("idupb", DS.incomeview.Rows[0]["idupb"]);
			}
			else {
				filter=QHS.CmpEq("idupb", "0001");
			}
            filter = QHS.AppAnd(filteridfin, filter);
			GetData.SetStaticFilter(DS.finview,filter);
            //DataAccess.RUN_SELECT_INTO_TABLE(Conn,DS.finview,null,filter,null,true);
			DS.finview.ExtendedProperties[MetaData.ExtraParams]=filter;
			MetaData.DoMainCommand(this,"manage.finview.treesupb");
		}

        private void btnUpbUscita_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) {
                Meta.DoMainCommand("manage.upb.tree");
                return;
            }
            object idaccertamento = DBNull.Value;

            object parentid = DS.proceedspart.Rows[0]["idinc"];

            idaccertamento = Meta.Conn.DO_READ_VALUE("incomelink",
                    QHS.AppAnd(QHS.CmpEq("idchild", parentid),
                                QHS.CmpEq("nlevel", Meta.GetSys("incomefinphase"))), "idparent");

            if (idaccertamento == null) idaccertamento = DBNull.Value;


            object idunderwriting = DBNull.Value;
            if (DS.incomeview.Select().Length > 0)
                idunderwriting = DS.incomeview.Rows[0]["idunderwriting"];


            // era manage.upb.tree
            if (UsaCrediti() && idaccertamento!=DBNull.Value) {
                Meta.GetFormData(true);
                string filter = QHS.AppAnd(QHS.CmpEq("idinc", idaccertamento),
                                    QHS.CmpEq("ayear", Meta.GetSys("esercizio")),
                                    QHS.CmpGt("credit", QHS.Field("proceeds"))
                                    );

                MetaData MetaCP = MetaData.GetMetaData(this, "creditproceedsview");


                MetaCP.DS = new DataSet();
                MetaCP.linkedForm = this;
                MetaCP.FilterLocked = true;
                DataRow CP = MetaCP.SelectOne("lista", filter, "creditproceedsview", null);
                if (CP == null) return;
                object idfin = CP["idfin"];
                object idupb = CP["idupb"];
                decimal amount_needed = CfgFn.GetNoNullDecimal(CP["credit"])
                                            - CfgFn.GetNoNullDecimal(CP["proceeds"]);

                DataRow Curr = DS.proceedspart.Rows[0];

                Curr["idfin"] = idfin;
                Curr["idupb"] = idupb;

                decimal amount_assignable = GetAssignableAmount();
                //sceglie il minimo tra i due
                decimal amount = amount_needed > amount_assignable ? amount_assignable : amount_needed;
                Curr["amount"] = amount;


                Meta.FreshForm(true);
                return;
            }
            if (idunderwriting != DBNull.Value) {
                Meta.GetFormData(true);
                string filter = QHS.AppAnd(QHS.CmpGt("paymentprevavailable", QHS.Field("proceedsavailable")),
                                            QHS.CmpEq("finpart", "S"),
                                            QHS.CmpEq("idunderwriting", idunderwriting),
                                            QHS.CmpEq("ayear",Meta.GetSys("esercizio")));
                MetaData MetaUnder = MetaData.GetMetaData(this, "upbunderwritingyearview");
                MetaUnder.DS = new DataSet();
                MetaUnder.linkedForm = this;
                MetaUnder.FilterLocked = true;
                DataRow Und = MetaUnder.SelectOne("crediti", filter, "upbunderwritingyearview", null);
                if (Und == null) return;
                DataRow Curr = DS.proceedspart.Rows[0];
                Curr["idupb"] = Und["idupb"];
                Curr["idfin"] = Und["idfin"];
                decimal amount_needed = CfgFn.GetNoNullDecimal(Und["paymentprevavailable"]) - CfgFn.GetNoNullDecimal(Und["proceedsavailable"]);
                decimal amount_assignable = GetAssignableAmount();
                //sceglie il minimo tra i due
                decimal amount = amount_needed > amount_assignable ? amount_assignable : amount_needed;
                Curr["amount"] = amount;

                Meta.FreshForm(true);
            }
            else {
                Meta.GetFormData(true);
                string filter = QHS.AppAnd(QHS.CmpGt("paymentprevavailable", QHS.Field("proceedsavailable")),
                                            QHS.CmpEq("finpart", "S"), QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
                MetaData MetaUY = MetaData.GetMetaData(this, "upbfinyearview");
                MetaUY.DS = new DataSet();
                MetaUY.linkedForm = this;
                MetaUY.FilterLocked = true;
                DataRow Und = MetaUY.SelectOne("crediti", filter, "upbfinyearview", null);
                if (Und == null) return;
                DataRow Curr = DS.proceedspart.Rows[0];
                Curr["idupb"] = Und["idupb"];
                Curr["idfin"] = Und["idfin"];
                decimal amount_needed = CfgFn.GetNoNullDecimal(Und["paymentprevavailable"]) - CfgFn.GetNoNullDecimal(Und["proceedsavailable"]);
                decimal amount_assignable = GetAssignableAmount();
                //sceglie il minimo tra i due
                decimal amount = amount_needed > amount_assignable ? amount_assignable : amount_needed;
                Curr["amount"] = amount;

                Meta.FreshForm(true);
            }
        }


        decimal GetAssignableAmount() {
            if (Meta.IsEmpty) return 0;
            DataRow Curr = DS.proceedspart.Rows[0];
            if (Curr["idinc"] == DBNull.Value) return 0;
            if (DS.incomeview.Rows.Count == 0) return 0;
            DataRow CurrIncomeView = DS.incomeview.Rows[0];
            string filter = QHS.AppAnd(QHS.CmpEq("idinc", CurrIncomeView["idinc"]),
                QHS.CmpEq("ayear", CurrIncomeView["ayear"]));
            DataTable ImportoEntrata = Meta.Conn.RUN_SELECT("incometotal", "*", null, filter, null, true);
            if (ImportoEntrata.Rows.Count != 1) return 0;
            DataRow R = ImportoEntrata.Rows[0];
            decimal importocorrente = CfgFn.GetNoNullDecimal(R["curramount"]);
            decimal importoassegnato = CfgFn.GetNoNullDecimal(R["partitioned"]);
            decimal importoassegnazione = importocorrente - importoassegnato;
            if (importoassegnazione >= 0)
                return importoassegnazione;
            else
                return 0;
        }

        private void grpAccertamento_Enter(object sender, EventArgs e) {

        }

	}
}
