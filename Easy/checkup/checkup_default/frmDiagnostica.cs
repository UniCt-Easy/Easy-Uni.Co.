
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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
using System.Data;

namespace checkup_default//diagnostica//
{
	/// <summary>
	/// Summary description for frmDiagnostica.
	/// </summary>
	public class Frm_checkup_default : MetaDataForm
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.Button btnTest;
		private System.Windows.Forms.Label labErr;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Label labOk;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button btnElenca;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Button btnRisolvi;
		private System.Windows.Forms.TabPage tabPage4;
		public /*Rana:diagnostica.*/vistaForm DS;
		MetaData Meta;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TabPage tabPage5;
		private System.Windows.Forms.TabPage tabPage6;
		private System.Windows.Forms.ImageList images;
		public System.Windows.Forms.GroupBox TabContr;
		private System.Windows.Forms.TextBox txtDescrizione;
		private System.Windows.Forms.TextBox txtComando;
		private System.Windows.Forms.TextBox txtRisolvi;
		private System.Windows.Forms.TextBox txtErrore;
		private System.Windows.Forms.TextBox txtEditType;
		private System.Windows.Forms.TextBox txtListType;
		private System.Windows.Forms.TextBox txtTabella;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.TextBox txtCause;
		private System.Windows.Forms.TextBox txtConseguenze;
		private System.Windows.Forms.Label labWait;
		private System.Windows.Forms.Label labWaitElenco;
		private System.Windows.Forms.Label labWaitRisolvi;
		bool IsAdmin=false;

		public Frm_checkup_default()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_checkup_default));
            this.TabContr = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.labWait = new System.Windows.Forms.Label();
            this.labOk = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labErr = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.txtErrore = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.labWaitElenco = new System.Windows.Forms.Label();
            this.txtEditType = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtComando = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtListType = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTabella = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnElenca = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.labWaitRisolvi = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRisolvi = new System.Windows.Forms.TextBox();
            this.btnRisolvi = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.txtCause = new System.Windows.Forms.TextBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.txtConseguenze = new System.Windows.Forms.TextBox();
            this.DS = new checkup_default.vistaForm();
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.TabContr.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // TabContr
            // 
            this.TabContr.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabContr.Controls.Add(this.tabControl1);
            this.TabContr.Location = new System.Drawing.Point(8, 12);
            this.TabContr.Name = "TabContr";
            this.TabContr.Size = new System.Drawing.Size(896, 684);
            this.TabContr.TabIndex = 1;
            this.TabContr.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Location = new System.Drawing.Point(8, 16);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(880, 660);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.labWait);
            this.tabPage1.Controls.Add(this.labOk);
            this.tabPage1.Controls.Add(this.textBox4);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.labErr);
            this.tabPage1.Controls.Add(this.btnTest);
            this.tabPage1.Controls.Add(this.textBox2);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtDescrizione);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(872, 634);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Descrizione";
            // 
            // labWait
            // 
            this.labWait.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labWait.ForeColor = System.Drawing.Color.Olive;
            this.labWait.Location = new System.Drawing.Point(392, 8);
            this.labWait.Name = "labWait";
            this.labWait.Size = new System.Drawing.Size(304, 32);
            this.labWait.TabIndex = 11;
            this.labWait.Text = "Attendere prego...";
            this.labWait.Visible = false;
            // 
            // labOk
            // 
            this.labOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labOk.ForeColor = System.Drawing.Color.Green;
            this.labOk.Location = new System.Drawing.Point(312, 8);
            this.labOk.Name = "labOk";
            this.labOk.Size = new System.Drawing.Size(64, 32);
            this.labOk.TabIndex = 10;
            this.labOk.Text = "Ok";
            this.labOk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labOk.Visible = false;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(536, 56);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 3;
            this.textBox4.Tag = "checkup.groupnumber";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(480, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "Gruppo";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labErr
            // 
            this.labErr.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labErr.ForeColor = System.Drawing.Color.OrangeRed;
            this.labErr.Location = new System.Drawing.Point(200, 8);
            this.labErr.Name = "labErr";
            this.labErr.Size = new System.Drawing.Size(104, 32);
            this.labErr.TabIndex = 7;
            this.labErr.Text = "Errore";
            this.labErr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labErr.Visible = false;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(24, 16);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(160, 23);
            this.btnTest.TabIndex = 5;
            this.btnTest.Text = "Verifica condizione di errore";
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(144, 56);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(320, 20);
            this.textBox2.TabIndex = 2;
            this.textBox2.Tag = "checkup.code";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(40, 56);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(48, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Tag = "checkup.idcheckup";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(96, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "#";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.AcceptsReturn = true;
            this.txtDescrizione.AcceptsTab = true;
            this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizione.Location = new System.Drawing.Point(8, 104);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescrizione.Size = new System.Drawing.Size(848, 524);
            this.txtDescrizione.TabIndex = 4;
            this.txtDescrizione.Tag = "checkup.description";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(216, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Descrizione dell\'errore";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label10);
            this.tabPage4.Controls.Add(this.txtErrore);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(872, 350);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Condizione di errore";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(8, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(696, 16);
            this.label10.TabIndex = 1;
            this.label10.Text = "query che, se dà risultati, indica la presenza di un errore. Se manca, è usata qu" +
    "ella in \'Elenco\'";
            // 
            // txtErrore
            // 
            this.txtErrore.AcceptsReturn = true;
            this.txtErrore.AcceptsTab = true;
            this.txtErrore.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtErrore.Location = new System.Drawing.Point(8, 24);
            this.txtErrore.Multiline = true;
            this.txtErrore.Name = "txtErrore";
            this.txtErrore.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtErrore.Size = new System.Drawing.Size(856, 320);
            this.txtErrore.TabIndex = 0;
            this.txtErrore.Tag = "checkup.checkerrors";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.labWaitElenco);
            this.tabPage2.Controls.Add(this.txtEditType);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.txtComando);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.txtListType);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.txtTabella);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.btnElenca);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(872, 350);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Elenco";
            // 
            // labWaitElenco
            // 
            this.labWaitElenco.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labWaitElenco.ForeColor = System.Drawing.Color.Olive;
            this.labWaitElenco.Location = new System.Drawing.Point(656, 0);
            this.labWaitElenco.Name = "labWaitElenco";
            this.labWaitElenco.Size = new System.Drawing.Size(216, 32);
            this.labWaitElenco.TabIndex = 8;
            this.labWaitElenco.Text = "Attendere prego";
            this.labWaitElenco.Visible = false;
            // 
            // txtEditType
            // 
            this.txtEditType.Location = new System.Drawing.Point(552, 8);
            this.txtEditType.Name = "txtEditType";
            this.txtEditType.Size = new System.Drawing.Size(100, 20);
            this.txtEditType.TabIndex = 3;
            this.txtEditType.Tag = "checkup.edittype";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(496, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 23);
            this.label8.TabIndex = 7;
            this.label8.Text = "Edit Type";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtComando
            // 
            this.txtComando.AcceptsReturn = true;
            this.txtComando.AcceptsTab = true;
            this.txtComando.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComando.Location = new System.Drawing.Point(8, 48);
            this.txtComando.Multiline = true;
            this.txtComando.Name = "txtComando";
            this.txtComando.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtComando.Size = new System.Drawing.Size(856, 288);
            this.txtComando.TabIndex = 4;
            this.txtComando.Tag = "checkup.listerrors";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(8, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(416, 16);
            this.label7.TabIndex = 4;
            this.label7.Text = "comando per ottenere l\'elenco delle righe che presentano errori";
            // 
            // txtListType
            // 
            this.txtListType.Location = new System.Drawing.Point(392, 8);
            this.txtListType.Name = "txtListType";
            this.txtListType.Size = new System.Drawing.Size(100, 20);
            this.txtListType.TabIndex = 2;
            this.txtListType.Tag = "checkup.listtype";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(344, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 23);
            this.label6.TabIndex = 2;
            this.label6.Text = "ListType";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTabella
            // 
            this.txtTabella.Location = new System.Drawing.Point(200, 8);
            this.txtTabella.Name = "txtTabella";
            this.txtTabella.Size = new System.Drawing.Size(136, 20);
            this.txtTabella.TabIndex = 1;
            this.txtTabella.Tag = "checkup.tablename";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(144, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 23);
            this.label5.TabIndex = 0;
            this.label5.Text = "Tabella";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnElenca
            // 
            this.btnElenca.Location = new System.Drawing.Point(8, 8);
            this.btnElenca.Name = "btnElenca";
            this.btnElenca.Size = new System.Drawing.Size(128, 23);
            this.btnElenca.TabIndex = 6;
            this.btnElenca.Text = "Ottieni elenco";
            this.btnElenca.Click += new System.EventHandler(this.btnElenca_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.labWaitRisolvi);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.txtRisolvi);
            this.tabPage3.Controls.Add(this.btnRisolvi);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(872, 350);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Risoluzione";
            // 
            // labWaitRisolvi
            // 
            this.labWaitRisolvi.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labWaitRisolvi.ForeColor = System.Drawing.Color.Olive;
            this.labWaitRisolvi.Location = new System.Drawing.Point(424, 8);
            this.labWaitRisolvi.Name = "labWaitRisolvi";
            this.labWaitRisolvi.Size = new System.Drawing.Size(320, 32);
            this.labWaitRisolvi.TabIndex = 3;
            this.labWaitRisolvi.Text = "Attendere prego";
            this.labWaitRisolvi.Visible = false;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(104, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(304, 23);
            this.label9.TabIndex = 2;
            this.label9.Text = "Comando per correggere le righe contenenti errori";
            // 
            // txtRisolvi
            // 
            this.txtRisolvi.AcceptsReturn = true;
            this.txtRisolvi.AcceptsTab = true;
            this.txtRisolvi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRisolvi.Location = new System.Drawing.Point(8, 40);
            this.txtRisolvi.Multiline = true;
            this.txtRisolvi.Name = "txtRisolvi";
            this.txtRisolvi.Size = new System.Drawing.Size(856, 304);
            this.txtRisolvi.TabIndex = 1;
            this.txtRisolvi.Tag = "checkup.corrige";
            // 
            // btnRisolvi
            // 
            this.btnRisolvi.Location = new System.Drawing.Point(8, 8);
            this.btnRisolvi.Name = "btnRisolvi";
            this.btnRisolvi.Size = new System.Drawing.Size(88, 24);
            this.btnRisolvi.TabIndex = 0;
            this.btnRisolvi.Text = "Risolvi...";
            this.btnRisolvi.Click += new System.EventHandler(this.btnRisolvi_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.txtCause);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(872, 350);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Possibili Cause";
            // 
            // txtCause
            // 
            this.txtCause.AcceptsReturn = true;
            this.txtCause.AcceptsTab = true;
            this.txtCause.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCause.Location = new System.Drawing.Point(8, 8);
            this.txtCause.Multiline = true;
            this.txtCause.Name = "txtCause";
            this.txtCause.Size = new System.Drawing.Size(856, 336);
            this.txtCause.TabIndex = 0;
            this.txtCause.Tag = "checkup.motive";
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.txtConseguenze);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(872, 350);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Possibili Conseguenze";
            // 
            // txtConseguenze
            // 
            this.txtConseguenze.AcceptsReturn = true;
            this.txtConseguenze.AcceptsTab = true;
            this.txtConseguenze.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConseguenze.Location = new System.Drawing.Point(8, 8);
            this.txtConseguenze.Multiline = true;
            this.txtConseguenze.Name = "txtConseguenze";
            this.txtConseguenze.Size = new System.Drawing.Size(856, 336);
            this.txtConseguenze.TabIndex = 0;
            this.txtConseguenze.Tag = "checkup.consequence";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // images
            // 
            this.images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("images.ImageStream")));
            this.images.TransparentColor = System.Drawing.Color.Transparent;
            this.images.Images.SetKeyName(0, "");
            this.images.Images.SetKeyName(1, "");
            this.images.Images.SetKeyName(2, "");
            this.images.Images.SetKeyName(3, "");
            this.images.Images.SetKeyName(4, "");
            this.images.Images.SetKeyName(5, "");
            this.images.Images.SetKeyName(6, "");
            this.images.Images.SetKeyName(7, "");
            this.images.Images.SetKeyName(8, "");
            this.images.Images.SetKeyName(9, "");
            this.images.Images.SetKeyName(10, "");
            this.images.Images.SetKeyName(11, "");
            this.images.Images.SetKeyName(12, "");
            this.images.Images.SetKeyName(13, "");
            this.images.Images.SetKeyName(14, "");
            this.images.Images.SetKeyName(15, "");
            this.images.Images.SetKeyName(16, "");
            this.images.Images.SetKeyName(17, "");
            this.images.Images.SetKeyName(18, "");
            this.images.Images.SetKeyName(19, "");
            this.images.Images.SetKeyName(20, "");
            this.images.Images.SetKeyName(21, "");
            this.images.Images.SetKeyName(22, "");
            this.images.Images.SetKeyName(23, "");
            this.images.Images.SetKeyName(24, "");
            this.images.Images.SetKeyName(25, "");
            this.images.Images.SetKeyName(26, "");
            this.images.Images.SetKeyName(27, "");
            this.images.Images.SetKeyName(28, "");
            this.images.Images.SetKeyName(29, "");
            this.images.Images.SetKeyName(30, "");
            this.images.Images.SetKeyName(31, "");
            this.images.Images.SetKeyName(32, "");
            this.images.Images.SetKeyName(33, "");
            this.images.Images.SetKeyName(34, "");
            this.images.Images.SetKeyName(35, "");
            this.images.Images.SetKeyName(36, "");
            this.images.Images.SetKeyName(37, "");
            // 
            // Frm_checkup_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(912, 701);
            this.Controls.Add(this.TabContr);
            this.Name = "Frm_checkup_default";
            this.Text = "frmDiagnostica";
            this.TabContr.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion


		public void MetaData_AfterLink(){
			Meta= MetaData.GetMetaData(this);
			IsAdmin=false;

			if (Meta.GetSys("FlagMenuAdmin")!=null) 
				IsAdmin=(Meta.GetSys("FlagMenuAdmin").ToString()=="S");
			//btnElenca.Enabled= IsAdmin;
			btnRisolvi.Enabled= false;
			txtDescrizione.ReadOnly= !IsAdmin;
			txtComando.ReadOnly= !IsAdmin;
			txtRisolvi.ReadOnly= !IsAdmin;
			txtEditType.ReadOnly= !IsAdmin;
			txtCause.ReadOnly= !IsAdmin;
			txtConseguenze.ReadOnly = !IsAdmin;
			txtErrore.ReadOnly = !IsAdmin;
			if (!IsAdmin){
				Meta.CanSave=false;
				Meta.CanInsert=false;
				Meta.CanInsertCopy=false;
			}

		}

		public void MetaData_AfterClear(){
			labErr.Visible=false;
			labOk.Visible=false;
		}

        public void MetaData_BeforeFill() {
            DataRow R = HelpForm.GetLastSelected(DS.checkup);
            if (R != null) {
                R["listerrors"] = QueryCreator.GetPrintable(R["listerrors"].ToString());
                R["checkerrors"] = QueryCreator.GetPrintable(R["checkerrors"].ToString());
                R["corrige"] = QueryCreator.GetPrintable(R["corrige"].ToString());
            }
        }

		public void MetaData_AfterRowSelect(DataTable T, DataRow R){
			if (T.TableName == "checkup"){
				labErr.Visible=false;
				labOk.Visible=false;
			}
		}

		void FillGridElencoErrori(DataTable T){
		}

		private void btnTest_Click(object sender, System.EventArgs e) {
			string check= txtErrore.Text.Trim();
			btnTest.Enabled=false;
			labWait.Visible=true;
			labOk.Visible=false;
			labErr.Visible=false;
			Application.DoEvents();

			bool err=false;
			if (check==""){
				string cmd= Meta.Conn.Compile(txtComando.Text.Trim(),true);
				DataTable Out =Meta.Conn.SQLRunner(	cmd, false, 300);
				if ( (Out==null) || (Out.Rows.Count>0))	err=true;
				FillGridElencoErrori(Out);
			}
			else {
				string cmd= Meta.Conn.Compile(check,true);
				object O = Meta.Conn.DO_SYS_CMD(cmd);
				if ((O!=DBNull.Value)&&(O!=null)) err=true;
				FillGridElencoErrori(null);
			}
			labOk.Visible= (err==false);
			labErr.Visible= (err==true);
			labWait.Visible=false;
			btnTest.Enabled=true;
			Application.DoEvents();

		}

		private void btnElenca_Click(object sender, System.EventArgs e) {
			string cmd= txtComando.Text;
			if (cmd.Trim()=="") return;
			labWaitElenco.Visible=true;
			
			FrmViewResult V = new FrmViewResult(Meta, 
							Meta.Conn.Compile(cmd,true),
							txtTabella.Text.Trim(),
							txtListType.Text.Trim(),
							txtEditType.Text.Trim());
			labWaitElenco.Visible=false;
            createForm(V, null);
            V.Show();
			
			/*
			MetaData Dest= Meta.Dispatcher.Get(R["tabella"].ToString());
			string listtype= R["listtype"].ToString().Trim();
			if (listtype=="") listtype= Dest.DefaultListType;
			bool res= Dest.Edit(this, R["edittype"].ToString(), false);
			DataRow RR = Dest.SelectOne(listtype, R["listerrors"].ToString(), null,null);
			if (RR!=null) Dest.SelectRow(RR,listtype);
			*/

		}

		private void btnRisolvi_Click(object sender, System.EventArgs e) {
			string cmd= txtRisolvi.Text.Trim();
			string sol= Meta.Conn.Compile(cmd,true);
			btnRisolvi.Enabled=false;
			labWaitRisolvi.Visible=true;
			Application.DoEvents();
			Meta.Conn.SQLRunner(sol,false,600);
			btnRisolvi.Enabled=true;
			labWaitRisolvi.Visible=false;
			Application.DoEvents();
		}
	}
}
