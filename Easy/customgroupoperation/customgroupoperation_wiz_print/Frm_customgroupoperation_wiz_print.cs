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
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;

namespace customgroupoperation_wiz_print//wizard_customgroupoperation_report//
{
	/// <summary>
	/// Summary description for frmwizard_customgroupoperation_report.
	/// </summary>
	public class Frm_customgroupoperation_wiz_print : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnBack;
		private Crownwood.Magic.Controls.TabControl tabController;
		private Crownwood.Magic.Controls.TabPage tabpage1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblMessaggi;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		MetaData Meta;
		DataTable Parametri;
		DataTable SelectedReports;
		DataTable SelectedGroups;
		bool CanSave=false;
		string CustomTitle;
		//string filterstampe=null;
		private System.Windows.Forms.ListView ListViewGruppi;
		private System.Windows.Forms.ListView ListViewStampe;
		private System.Windows.Forms.ListView ListViewParametri;
		private System.Windows.Forms.Label label5;
		public /*Rana:wizard_customgroupoperation_report.*/vistaForm DS;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtBoxConsenti;
		private System.Windows.Forms.TextBox txtBoxDivieto;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rdbVieta;
		private System.Windows.Forms.RadioButton rdbConsenti;
		private Crownwood.Magic.Controls.TabPage tabPage3;
		private Crownwood.Magic.Controls.TabPage tabPage2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton rdbInsUpd;
		private System.Windows.Forms.RadioButton rdbElimina;
		private Crownwood.Magic.Controls.TabPage tabPage5;
		private Crownwood.Magic.Controls.TabPage tabPage4;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.DataGrid dgrExistingRows;
		private System.Windows.Forms.Label label9;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_customgroupoperation_wiz_print()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			tabController.HideTabsMode = 
				Crownwood.Magic.Controls.TabControl.HideTabsModes.HideAlways;
			
			Set_DescribeColumn(DS.report);
			Set_DescribeColumn(DS.customgroup);
			Set_DescribeColumn(DS.customgroupoperation_temp);
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
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnNext = new System.Windows.Forms.Button();
			this.btnBack = new System.Windows.Forms.Button();
			this.tabController = new Crownwood.Magic.Controls.TabControl();
			this.tabPage5 = new Crownwood.Magic.Controls.TabPage();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.rdbElimina = new System.Windows.Forms.RadioButton();
			this.rdbInsUpd = new System.Windows.Forms.RadioButton();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.txtBoxConsenti = new System.Windows.Forms.TextBox();
			this.txtBoxDivieto = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rdbVieta = new System.Windows.Forms.RadioButton();
			this.rdbConsenti = new System.Windows.Forms.RadioButton();
			this.label4 = new System.Windows.Forms.Label();
			this.tabpage1 = new Crownwood.Magic.Controls.TabPage();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.ListViewParametri = new System.Windows.Forms.ListView();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.ListViewStampe = new System.Windows.Forms.ListView();
			this.label3 = new System.Windows.Forms.Label();
			this.tabPage3 = new Crownwood.Magic.Controls.TabPage();
			this.button5 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.ListViewGruppi = new System.Windows.Forms.ListView();
			this.lblMessaggi = new System.Windows.Forms.Label();
			this.tabPage4 = new Crownwood.Magic.Controls.TabPage();
			this.label8 = new System.Windows.Forms.Label();
			this.dgrExistingRows = new System.Windows.Forms.DataGrid();
			this.label9 = new System.Windows.Forms.Label();
			this.DS = new /*Rana:wizard_customgroupoperation_report.*/vistaForm();
			this.tabController.SuspendLayout();
			this.tabPage5.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabpage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tabPage4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrExistingRows)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(448, 376);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 10;
			this.btnCancel.Text = "Cancel";
			// 
			// btnNext
			// 
			this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNext.Location = new System.Drawing.Point(344, 376);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(72, 23);
			this.btnNext.TabIndex = 9;
			this.btnNext.Text = "Avanti >";
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// btnBack
			// 
			this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBack.Location = new System.Drawing.Point(264, 376);
			this.btnBack.Name = "btnBack";
			this.btnBack.Size = new System.Drawing.Size(72, 23);
			this.btnBack.TabIndex = 8;
			this.btnBack.Text = "< Indietro";
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
			// 
			// tabController
			// 
			this.tabController.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tabController.IDEPixelArea = true;
			this.tabController.Location = new System.Drawing.Point(9, 8);
			this.tabController.Name = "tabController";
			this.tabController.SelectedIndex = 4;
			this.tabController.SelectedTab = this.tabPage5;
			this.tabController.Size = new System.Drawing.Size(512, 352);
			this.tabController.TabIndex = 11;
			this.tabController.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
																							this.tabpage1,
																							this.tabPage2,
																							this.tabPage3,
																							this.tabPage4,
																							this.tabPage5});
			this.tabController.SelectionChanged += new System.EventHandler(this.tabController_SelectionChanged);
			// 
			// tabPage5
			// 
			this.tabPage5.Controls.Add(this.groupBox2);
			this.tabPage5.Controls.Add(this.label6);
			this.tabPage5.Controls.Add(this.label7);
			this.tabPage5.Controls.Add(this.txtBoxConsenti);
			this.tabPage5.Controls.Add(this.txtBoxDivieto);
			this.tabPage5.Controls.Add(this.groupBox1);
			this.tabPage5.Controls.Add(this.label4);
			this.tabPage5.Location = new System.Drawing.Point(0, 0);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Size = new System.Drawing.Size(512, 327);
			this.tabPage5.TabIndex = 5;
			this.tabPage5.Title = "Pagina 5 di 5";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.rdbElimina);
			this.groupBox2.Controls.Add(this.rdbInsUpd);
			this.groupBox2.Location = new System.Drawing.Point(8, 48);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(288, 40);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Operazione";
			// 
			// rdbElimina
			// 
			this.rdbElimina.Location = new System.Drawing.Point(168, 16);
			this.rdbElimina.Name = "rdbElimina";
			this.rdbElimina.Size = new System.Drawing.Size(112, 16);
			this.rdbElimina.TabIndex = 1;
			this.rdbElimina.Text = "Elimina regole";
			this.rdbElimina.CheckedChanged += new System.EventHandler(this.rdbElimina_CheckedChanged);
			// 
			// rdbInsUpd
			// 
			this.rdbInsUpd.Checked = true;
			this.rdbInsUpd.Location = new System.Drawing.Point(8, 16);
			this.rdbInsUpd.Name = "rdbInsUpd";
			this.rdbInsUpd.Size = new System.Drawing.Size(136, 16);
			this.rdbInsUpd.TabIndex = 0;
			this.rdbInsUpd.TabStop = true;
			this.rdbInsUpd.Text = "Crea/aggiorna regole";
			this.rdbInsUpd.CheckedChanged += new System.EventHandler(this.rdbInsUpd_CheckedChanged);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(16, 104);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(136, 24);
			this.label6.TabIndex = 33;
			this.label6.Text = "Condizione di consenti:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(16, 208);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(120, 24);
			this.label7.TabIndex = 32;
			this.label7.Text = "Condizione di divieto:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtBoxConsenti
			// 
			this.txtBoxConsenti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtBoxConsenti.Location = new System.Drawing.Point(16, 128);
			this.txtBoxConsenti.Multiline = true;
			this.txtBoxConsenti.Name = "txtBoxConsenti";
			this.txtBoxConsenti.Size = new System.Drawing.Size(488, 72);
			this.txtBoxConsenti.TabIndex = 3;
			this.txtBoxConsenti.Tag = "";
			this.txtBoxConsenti.Text = "";
			// 
			// txtBoxDivieto
			// 
			this.txtBoxDivieto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtBoxDivieto.Enabled = false;
			this.txtBoxDivieto.Location = new System.Drawing.Point(16, 232);
			this.txtBoxDivieto.Multiline = true;
			this.txtBoxDivieto.Name = "txtBoxDivieto";
			this.txtBoxDivieto.Size = new System.Drawing.Size(488, 72);
			this.txtBoxDivieto.TabIndex = 4;
			this.txtBoxDivieto.Tag = "";
			this.txtBoxDivieto.Text = "";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.rdbVieta);
			this.groupBox1.Controls.Add(this.rdbConsenti);
			this.groupBox1.Location = new System.Drawing.Point(344, 48);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(104, 72);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Default";
			// 
			// rdbVieta
			// 
			this.rdbVieta.Checked = true;
			this.rdbVieta.Location = new System.Drawing.Point(16, 24);
			this.rdbVieta.Name = "rdbVieta";
			this.rdbVieta.Size = new System.Drawing.Size(72, 16);
			this.rdbVieta.TabIndex = 0;
			this.rdbVieta.TabStop = true;
			this.rdbVieta.Tag = "";
			this.rdbVieta.Text = "Vieta";
			this.rdbVieta.CheckedChanged += new System.EventHandler(this.rdbVieta_CheckedChanged);
			// 
			// rdbConsenti
			// 
			this.rdbConsenti.Location = new System.Drawing.Point(16, 48);
			this.rdbConsenti.Name = "rdbConsenti";
			this.rdbConsenti.Size = new System.Drawing.Size(72, 16);
			this.rdbConsenti.TabIndex = 1;
			this.rdbConsenti.Tag = "";
			this.rdbConsenti.Text = "Consenti";
			this.rdbConsenti.CheckedChanged += new System.EventHandler(this.rdbConsenti_CheckedChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 8);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(504, 32);
			this.label4.TabIndex = 1;
			this.label4.Text = "Selezionare il tipo di operazione e le opzioni di sicurezza. Per salvare, cliccar" +
				"e su Fine";
			// 
			// tabpage1
			// 
			this.tabpage1.Controls.Add(this.button2);
			this.tabpage1.Controls.Add(this.button1);
			this.tabpage1.Controls.Add(this.label5);
			this.tabpage1.Controls.Add(this.ListViewParametri);
			this.tabpage1.Controls.Add(this.label2);
			this.tabpage1.Controls.Add(this.label1);
			this.tabpage1.Location = new System.Drawing.Point(0, 0);
			this.tabpage1.Name = "tabpage1";
			this.tabpage1.Selected = false;
			this.tabpage1.Size = new System.Drawing.Size(512, 327);
			this.tabpage1.TabIndex = 0;
			this.tabpage1.Title = "Pagina 1 di 5";
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button2.Location = new System.Drawing.Point(136, 256);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(104, 23);
			this.button2.TabIndex = 5;
			this.button2.Text = "Annulla selezione";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button1.Location = new System.Drawing.Point(16, 256);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(104, 23);
			this.button1.TabIndex = 4;
			this.button1.Text = "Seleziona tutti";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.label5.Location = new System.Drawing.Point(16, 48);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(488, 40);
			this.label5.TabIndex = 3;
			this.label5.Text = "Selezionare i parametri dei prospetti dei quali si vogliono gestire le autorizzaz" +
				"ioni (nessuna selezione corrisponde a tutti i parametri)";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ListViewParametri
			// 
			this.ListViewParametri.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.ListViewParametri.Location = new System.Drawing.Point(16, 88);
			this.ListViewParametri.Name = "ListViewParametri";
			this.ListViewParametri.Size = new System.Drawing.Size(488, 160);
			this.ListViewParametri.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label2.Location = new System.Drawing.Point(16, 288);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(288, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Per proseguire, cliccare su Avanti.";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(488, 32);
			this.label1.TabIndex = 0;
			this.label1.Text = "Questa procedura guidata permette di effettuare le operazioni connesse alla gesti" +
				"one della sicurezza dei prospetti in relazione ai gruppi di utenti.";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.button3);
			this.tabPage2.Controls.Add(this.button4);
			this.tabPage2.Controls.Add(this.ListViewStampe);
			this.tabPage2.Controls.Add(this.label3);
			this.tabPage2.Location = new System.Drawing.Point(0, 0);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Selected = false;
			this.tabPage2.Size = new System.Drawing.Size(512, 327);
			this.tabPage2.TabIndex = 3;
			this.tabPage2.Title = "Pagina 2 di 5";
			// 
			// button3
			// 
			this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button3.Location = new System.Drawing.Point(128, 288);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(104, 23);
			this.button3.TabIndex = 7;
			this.button3.Text = "Annulla selezione";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button4.Location = new System.Drawing.Point(8, 288);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(104, 23);
			this.button4.TabIndex = 6;
			this.button4.Text = "Seleziona tutti";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// ListViewStampe
			// 
			this.ListViewStampe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.ListViewStampe.Location = new System.Drawing.Point(8, 80);
			this.ListViewStampe.Name = "ListViewStampe";
			this.ListViewStampe.Size = new System.Drawing.Size(504, 192);
			this.ListViewStampe.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.label3.Location = new System.Drawing.Point(8, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(496, 56);
			this.label3.TabIndex = 1;
			this.label3.Text = "Selezionare i prospetti e cliccare avanti";
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.button5);
			this.tabPage3.Controls.Add(this.button6);
			this.tabPage3.Controls.Add(this.ListViewGruppi);
			this.tabPage3.Controls.Add(this.lblMessaggi);
			this.tabPage3.Location = new System.Drawing.Point(0, 0);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Selected = false;
			this.tabPage3.Size = new System.Drawing.Size(512, 327);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Title = "Pagina 3 di 5";
			this.tabPage3.Visible = false;
			// 
			// button5
			// 
			this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button5.Location = new System.Drawing.Point(128, 288);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(104, 23);
			this.button5.TabIndex = 9;
			this.button5.Text = "Annulla selezione";
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// button6
			// 
			this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button6.Location = new System.Drawing.Point(8, 288);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(104, 23);
			this.button6.TabIndex = 8;
			this.button6.Text = "Seleziona tutti";
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// ListViewGruppi
			// 
			this.ListViewGruppi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.ListViewGruppi.Location = new System.Drawing.Point(8, 80);
			this.ListViewGruppi.Name = "ListViewGruppi";
			this.ListViewGruppi.Size = new System.Drawing.Size(488, 200);
			this.ListViewGruppi.TabIndex = 1;
			// 
			// lblMessaggi
			// 
			this.lblMessaggi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lblMessaggi.Location = new System.Drawing.Point(16, 16);
			this.lblMessaggi.Name = "lblMessaggi";
			this.lblMessaggi.Size = new System.Drawing.Size(480, 56);
			this.lblMessaggi.TabIndex = 0;
			this.lblMessaggi.Text = "Selezionare i gruppi e cliccare Avanti";
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.label8);
			this.tabPage4.Controls.Add(this.dgrExistingRows);
			this.tabPage4.Controls.Add(this.label9);
			this.tabPage4.Location = new System.Drawing.Point(0, 0);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Selected = false;
			this.tabPage4.Size = new System.Drawing.Size(512, 327);
			this.tabPage4.TabIndex = 4;
			this.tabPage4.Title = "Pagina 4 di 5";
			// 
			// label8
			// 
			this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.label8.Location = new System.Drawing.Point(16, 48);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(480, 23);
			this.label8.TabIndex = 6;
			this.label8.Text = "Per continuare, cliccare su Avanti.";
			// 
			// dgrExistingRows
			// 
			this.dgrExistingRows.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dgrExistingRows.DataMember = "";
			this.dgrExistingRows.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrExistingRows.Location = new System.Drawing.Point(16, 80);
			this.dgrExistingRows.Name = "dgrExistingRows";
			this.dgrExistingRows.Size = new System.Drawing.Size(488, 224);
			this.dgrExistingRows.TabIndex = 5;
			// 
			// label9
			// 
			this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.label9.Location = new System.Drawing.Point(16, 16);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(488, 24);
			this.label9.TabIndex = 4;
			this.label9.Text = "In base alle scelte effettuate, verranno modificate o eliminate le regole sottost" +
				"anti.";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// frmwizard_customgroupoperation_report
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(530, 415);
			this.Controls.Add(this.tabController);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnNext);
			this.Controls.Add(this.btnBack);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "frmwizard_customgroupoperation_report";
			this.Text = "frmwizard_customgroupoperation_report";
			this.tabController.ResumeLayout(false);
			this.tabPage5.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.tabpage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgrExistingRows)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public void Set_DescribeColumn(DataTable T) 
		{
			if (T.TableName == "report")
			{
				T.Columns["modulename"].Caption="Nome modulo";
				T.Columns["reportname"].Caption="Nome";
				T.Columns["groupname"].Caption="Gruppo";
				T.Columns["description"].Caption="Descrizione";
				T.Columns["filename"].Caption="File";
				T.Columns["orientation"].Caption="Orientamento";
			}
			if (T.TableName == "customgroup")
			{
				T.Columns["idcustomgroup"].Caption="ID Nome gruppo";
				T.Columns["groupname"].Caption="Nome gruppo";
				T.Columns["description"].Caption="Descrizione";
				T.Columns["lastmodtimestamp"].Caption="";
				T.Columns["lastmoduser"].Caption="";
			}

			if (T.TableName == "customgroupoperation_temp")
			{
				T.Columns["idgroup"].Caption="ID gruppo";
				T.Columns["tablename"].Caption="Nome report";
				T.Columns["operation"].Caption="Operazione";
				T.Columns["defaultisdeny"].Caption="Default";
				T.Columns["allowcondition"].Caption="Condizione di consenti";
				T.Columns["denycondition"].Caption="Condizione di divieto";
				T.Columns["lastmodtimestamp"].Caption="";
				T.Columns["lastmoduser"].Caption="";
			}
		}
		public void MetaData_AfterActivation() {
			FormInit();
		}

		void FormInit() {
			CustomTitle="Wizard autorizzazioni prospetti";
			//Selects first tab
			DisplayTabs(0);
		}

		public void MetaData_AfterLink(){
			Meta = MetaData.GetMetaData(this);
			Meta.CanInsert=false;
			Meta.CanInsertCopy=false;
			Meta.CanSave=false;
			Meta.CanCancel=false;
			GetData.LockRead(DS.customgroupoperation);
			GetData.DenyClear(DS.customgroupoperation);
			GetData.LockRead(DS.customgroupoperation_temp);
			GetData.DenyClear(DS.customgroupoperation_temp);
			GetData.LockRead(DS.customgroup);
			GetData.DenyClear(DS.customgroup);
			GetData.LockRead(DS.report);
			GetData.DenyClear(DS.report);
			FillListViewParametri(ListViewParametri);
			
		}

		string GetFilterFromListViewParametri(){
			DataTable CheckedLVItems=new DataTable();
			CheckedLVItems.Columns.Add("paramname");
			foreach (object LVIo in ListViewParametri.Items){
				if (!typeof(ListViewItem).IsAssignableFrom(LVIo.GetType()))continue;
				ListViewItem LVI = (ListViewItem) LVIo;
				DataRow ItemRow = (DataRow) LVI.Tag;
				if ((LVI.Checked)){
					CheckedLVItems.Rows.Add(new object[1]{ItemRow[0].ToString()});
				}
			}
			if (CheckedLVItems==null || CheckedLVItems.Rows.Count==0) return null;
			return QueryCreator.ColumnValues(CheckedLVItems, null, 
				"paramname", true);
		}

		bool IsPrimaryKey(DataColumn C, DataColumn [] PKeys){
			foreach (DataColumn K in PKeys){
				if (C.ColumnName == K.ColumnName)
					return true;
			}
			return false;
		}

		DataTable GetSelectedRowsFromListViewItems(ListView L){
			if (L.Items.Count==0) return null;
			DataTable CheckedLVItems = new DataTable();
			ListViewItem LVItem = (ListViewItem) L.Items[0];
			DataRow RowItem = (DataRow) LVItem.Tag;
			foreach (DataColumn C in RowItem.Table.Columns){
				CheckedLVItems.Columns.Add(C.ColumnName, C.DataType);
			}

			// imposta la chiave promaria della nuova tabella
			// CheckedLVItems.PrimaryKey = new DataColumn[RowItem.Table.PrimaryKey.Length];
			DataColumn [] MyKeys = new DataColumn[RowItem.Table.PrimaryKey.Length];
			int i = 0;
			foreach (DataColumn C in CheckedLVItems.Columns){
				if (IsPrimaryKey(C, RowItem.Table.PrimaryKey)){
					MyKeys[i]=C;
					i++;
				}
			}
			CheckedLVItems.PrimaryKey = MyKeys;
			foreach (object LVIo in L.Items){
				if (!typeof(ListViewItem).IsAssignableFrom(LVIo.GetType()))continue;
				ListViewItem LVI = (ListViewItem) LVIo;
				DataRow ItemRow = (DataRow) LVI.Tag;
				if ((LVI.Checked)){
					DataRow NewRow = CheckedLVItems.NewRow();
					foreach (DataColumn C in ItemRow.Table.Columns)
						NewRow[C.ColumnName]=ItemRow[C.ColumnName];
					CheckedLVItems.Rows.Add(NewRow);
				}
			}
			if (CheckedLVItems==null || CheckedLVItems.Rows.Count==0) return null;
			return CheckedLVItems;
		}

		bool FillListView(ListView L, string Table, string filter){
			//Sets ListView Header Columns
			if (filter=="") filter = null;
			DS.Tables[Table].Clear();
			DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn,DS.Tables[Table], null, filter, null, true);
			if (DS.Tables[Table].Rows.Count==0) return false;
			DS.Tables[Table].AcceptChanges();
			DataTable Parent2 = DS.Tables[Table];
			L.BeginUpdate();
			L.Clear();
			string []colnames = new string[Parent2.Columns.Count];
			int ncols=0;
			Graphics GG = Graphics.FromHwnd(L.FindForm().Handle);
			int []sizes = new int[Parent2.Columns.Count];
			foreach (DataColumn C in Parent2.Columns){
				if (C.Caption=="")continue;
				colnames[ncols]= C.ColumnName;
				sizes[ncols]= Convert.ToInt32(GG.MeasureString(C.ColumnName, L.Font).Width)+5;
				ncols++;
			}
			
			string []items= new string[ncols];
			//Fills ListBox
			foreach(DataRow R in Parent2.Rows){
				for (int i=0; i<ncols; i++){
					string colname= colnames[i];
					items[i]= HelpForm.StringValue(R[colname],
						"", 
						Parent2.Columns[colname]);
					int ss = Convert.ToInt32(GG.MeasureString(items[i], L.Font).Width)+5;
					if (sizes[i]<ss) sizes[i]=ss;
				}
				ListViewItem LVII = new ListViewItem(items[0]);
				LVII.Tag= R;
				for (int j=1; j<ncols; j++) LVII.SubItems.Add(items[j]);
				L.Items.Add(LVII);
			}
			int ii=0;
			foreach (DataColumn C in Parent2.Columns){
				if (C.Caption=="")continue;
				L.Columns.Add(C.Caption, sizes[ii], HelpForm.GetAlignForColumn(C));
				ii++;
			}
			
			L.CheckBoxes= true;
			L.FullRowSelect=true;
			L.View = View.Details;
			L.GridLines=true;

			L.EndUpdate();
			L.Refresh();
			return true;
		}

		bool FillListViewParametri(ListView L){
			//Sets ListView Header Columns
			Parametri = Meta.Conn.SQLRunner("select distinct paramname from reportparameter");
			Parametri.Columns[0].ColumnName="Nome parametro";
			if (Parametri==null || Parametri.Rows.Count==0) return false;
			Parametri.AcceptChanges();
			DataTable Parent2 = Parametri;
			L.BeginUpdate();
			L.Clear();
			string []colnames = new string[Parent2.Columns.Count];
			int ncols=0;
			Graphics GG = Graphics.FromHwnd(L.FindForm().Handle);
			int []sizes = new int[Parent2.Columns.Count];
			foreach (DataColumn C in Parent2.Columns){
				if (C.Caption=="")continue;
				colnames[ncols]= C.ColumnName;
				sizes[ncols]= Convert.ToInt32(GG.MeasureString(C.ColumnName, L.Font).Width)+5;
				ncols++;
			}
			
			string []items= new string[ncols];
			//Fills ListBox
			foreach(DataRow R in Parent2.Rows){
				for (int i=0; i<ncols; i++){
					string colname= colnames[i];
					items[i]= HelpForm.StringValue(R[colname],
						"", 
						Parent2.Columns[colname]);
					int ss = Convert.ToInt32(GG.MeasureString(items[i], L.Font).Width)+5;
					if (sizes[i]<ss) sizes[i]=ss;
				}
				ListViewItem LVII = new ListViewItem(items[0]);
				LVII.Tag= R;
				for (int j=1; j<ncols; j++) LVII.SubItems.Add(items[j]);
				L.Items.Add(LVII);
			}
			int ii=0;
			foreach (DataColumn C in Parent2.Columns){
				if (C.Caption=="")continue;
				L.Columns.Add(C.Caption, sizes[ii], HelpForm.GetAlignForColumn(C));
				ii++;
			}
			
			L.CheckBoxes= true;
			L.FullRowSelect=true;
			L.View = View.Details;
			L.GridLines=true;

			L.EndUpdate();
			L.Refresh();
			return true;
		}


		/// <summary>
		/// Displays tab n. NewTab and updates buttons
		/// </summary>
		/// <param name="newTab"></param>
		void DisplayTabs(int newTab) {
			tabController.SelectedIndex= newTab;
			//Evaluates Buttons Appearance
			btnBack.Visible=(newTab>0);
			if (newTab== tabController.TabPages.Count-1)
				btnNext.Text="Fine.";
			else
				btnNext.Text="Avanti >";
			Text = CustomTitle+ " (Pagina "+(newTab+1)+" di "+tabController.TabPages.Count+")";
		}


		/// <summary>
		/// Changes tab backward/forward
		/// </summary>
		/// <param name="step"></param>
		void StandardChangeTab(int step) {
			int oldTab= tabController.SelectedIndex;
			int newTab= oldTab+step;
			if ((newTab<0)||(newTab>tabController.TabPages.Count))return;
			if (!CustomChangeTab(oldTab,newTab))return;
			if (newTab==tabController.TabPages.Count) {
				DialogResult= DialogResult.OK;
				return;
			}
			DisplayTabs(newTab);
		}

		/// <summary>
		/// Must return true if operation is possible, and do any
		///  operation related to change from tab oldTab to newTab
		/// </summary>
		/// <param name="oldTab"></param>
		/// <param name="newTab"></param>
		/// <returns></returns>
		bool CustomChangeTab(int oldTab, int newTab) {
			//if (oldTab==0) 	return true ; // 0->1: nothing to do
			if ((oldTab==1)&&(newTab==0)) {
				btnNext.Enabled=true;
				return true; //1->0:nothing to do!
			}
			if ((oldTab==0)&&(newTab==1)) {
				string paramfilter=null, filter=null;
				paramfilter=GetFilterFromListViewParametri();
				if (paramfilter!=null)
					filter = "(reportname in "+
						"(select distinct reportname from reportparameter where "+
						"paramname in ("+GetFilterFromListViewParametri()+")))";
				FillListView(ListViewStampe, "report", filter);
				FillListView(ListViewGruppi, "customgroup", null);
				return true;
			}
			if ((oldTab==1)&&(newTab==2)) {
				SelectedReports = GetSelectedRowsFromListViewItems(ListViewStampe);
				if (SelectedReports==null || SelectedReports.Rows.Count==0){
					MessageBox.Show(this, "Non Ë stato selezionato alcun prospetto", "Errore");
					CanSave=false;
					return false;
				}
				CanSave=true;
				return true;
			}
			if ((oldTab==2)&&(newTab==3)) {
				SelectedGroups = GetSelectedRowsFromListViewItems(ListViewGruppi);
				if (SelectedGroups==null || SelectedGroups.Rows.Count==0){
					MessageBox.Show(this, "Non Ë stato selezionato alcun gruppo", "Errore");
					CanSave=false;
					return false;
				}
				// riempire il grid delle righe esistenti di customgroupoperation
				SetExistingRowsGrid();
				CanSave=true;
				return true;
			}
			return true;
		}

		void AddRowToTable(DataRow R, DataTable T) {			
			DataRow NewR = T.NewRow();
			foreach(DataColumn C in R.Table.Columns) {
				NewR[C.ColumnName]= R[C.ColumnName];
			}
			T.Rows.Add(NewR);
		}
		
		void SetExistingRowsGrid(){
			string filter;
			filter = "(operation='P') AND (tablename IN ("+
				QueryCreator.ColumnValues(SelectedReports, null,"reportname", false)+
				") AND (idgroup IN ("+
				QueryCreator.ColumnValues(SelectedGroups, null, "idcustomgroup", false)+
				")))";
			DS.customgroupoperation_temp.Clear();
			DataTable ExistingRowsTable = Meta.Conn.RUN_SELECT("customgroupoperation","*",null,filter, null, true);
			if (ExistingRowsTable==null) return;
			foreach (DataRow R in ExistingRowsTable.Rows){
				AddRowToTable(R, DS.customgroupoperation_temp);
			}
			Meta.DescribeColumns(DS.customgroupoperation_temp, "print");
			HelpForm.SetDataGrid(dgrExistingRows, DS.customgroupoperation_temp);

			formatgrids FG = new formatgrids(dgrExistingRows);
			FG.AutosizeColumnWidth();
			DS.customgroupoperation_temp.AcceptChanges();
		}

		DataRow GetExistingRow(DataTable T, DataRow R){
			string filter =
				"(idgroup="+QueryCreator.quotedstrvalue(R["idgroup"], false)+
				") AND (tablename="+QueryCreator.quotedstrvalue(R["tablename"], false)+
				") AND (operation="+QueryCreator.quotedstrvalue(R["operation"], false)+
				")";
			DataRow [] FoundRows = T.Select(filter);
			if (FoundRows.Length==1) return FoundRows[0];
			return null;
		}

		private void SaveData() {
			DataRow ExstRow;
			Meta.SetDefaults(DS.customgroupoperation);
			DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn,DS.customgroupoperation, null, 
				"(operation='P')", null, true);
			foreach (DataRow GruppiRow in SelectedGroups.Rows){
				foreach (DataRow ReportRow in SelectedReports.Rows){
					DataRow NewRow = DS.customgroupoperation.NewRow();
					NewRow["idgroup"]=GruppiRow["idcustomgroup"];
					NewRow["tablename"]=ReportRow["reportname"];
					NewRow["operation"]="P";
					if (rdbVieta.Checked)
						NewRow["defaultisdeny"]="S";
					else
						NewRow["defaultisdeny"]="N";
					if (txtBoxConsenti.Text=="")
						NewRow["allowcondition"]=DBNull.Value;
					else
						NewRow["allowcondition"]=txtBoxConsenti.Text.Trim();

					if (txtBoxDivieto.Text=="")
						NewRow["denycondition"]=DBNull.Value;
					else
						NewRow["denycondition"]=txtBoxDivieto.Text.Trim();
					NewRow["lastmoduser"]="AAA";
					NewRow["lastmodtimestamp"]=DateTime.Now;
					ExstRow=GetExistingRow(DS.customgroupoperation, NewRow);
					if (rdbElimina.Checked){
						if (ExstRow!=null)
							ExstRow.Delete();
						continue;
					}
					if (ExstRow==null && !rdbElimina.Checked){
						DS.customgroupoperation.Rows.Add(NewRow);
					}
					else{
						NewRow=ExstRow;
						if (rdbVieta.Checked)
							NewRow["defaultisdeny"]="S";
						else
							NewRow["defaultisdeny"]="N";
						if (txtBoxConsenti.Text=="")
							NewRow["allowcondition"]=DBNull.Value;
						else
							NewRow["allowcondition"]=txtBoxConsenti.Text.Trim();

						if (txtBoxDivieto.Text=="")
							NewRow["denycondition"]=DBNull.Value;
						else
							NewRow["denycondition"]=txtBoxDivieto.Text.Trim();
						NewRow["lastmoduser"]="AAA";
						NewRow["lastmodtimestamp"]=DateTime.Now;
					}
				}
			}
			
			Easy_PostData MyPostData = new Easy_PostData();
			MyPostData.InitClass(DS, Meta.Conn);
			MyPostData.DO_POST();
		}


		private void btnNext_Click(object sender, System.EventArgs e) {
			//if (tabController.SelectedIndex==tabController.TabPages.Count-1)
			if (tabController.SelectedIndex==tabController.TabPages.Count-1 && CanSave){
				SaveData();
			}
			StandardChangeTab(+1);

		}

		private void btnBack_Click(object sender, System.EventArgs e) {
			StandardChangeTab(-1);
		
		}

		void ListViewItemsCheckUncheckAll(ListView LV, bool Check){
			foreach (ListViewItem LVI in LV.Items)
				LVI.Checked=Check;
		}

		private void button1_Click(object sender, System.EventArgs e) {
			ListViewItemsCheckUncheckAll(ListViewParametri, true);
		}

		private void button2_Click(object sender, System.EventArgs e) {
			ListViewItemsCheckUncheckAll(ListViewParametri, false);	
		}

		private void button4_Click(object sender, System.EventArgs e) {
			ListViewItemsCheckUncheckAll(ListViewStampe, true);
		}

		private void button3_Click(object sender, System.EventArgs e) {		
			ListViewItemsCheckUncheckAll(ListViewStampe, false);
		}

		private void button6_Click(object sender, System.EventArgs e) {
			ListViewItemsCheckUncheckAll(ListViewGruppi, true);
		}

		private void button5_Click(object sender, System.EventArgs e) {
			ListViewItemsCheckUncheckAll(ListViewGruppi, false);		
		}

		private void rdbInsUpd_CheckedChanged(object sender, System.EventArgs e) {
			if (((RadioButton)sender).Checked==true)
				EnableDisableControls(true);
			else
				EnableDisableControls(false);
		}

		void EnableDisableControls(bool enable){
			txtBoxConsenti.Text="";
			txtBoxDivieto.Text="";
			txtBoxConsenti.Enabled=enable;
			txtBoxDivieto.Enabled=enable;
			groupBox1.Enabled=enable;
			if (enable) ControlloVC();
		}

		void ControlloVC() {
			txtBoxConsenti.Enabled=true; 
			txtBoxDivieto.Enabled=true;
			if (rdbConsenti.Checked==true) {
				txtBoxConsenti.Enabled=false;
				txtBoxConsenti.Text="";
				txtBoxDivieto.Enabled=true;
			}
			if (rdbVieta.Checked==true) {
				txtBoxDivieto.Enabled=false; 
				txtBoxDivieto.Text="";
				txtBoxConsenti.Enabled=true; 
			}
		}

		private void rdbElimina_CheckedChanged(object sender, System.EventArgs e) {
			if (((RadioButton)sender).Checked==true)
				EnableDisableControls(false);
			else
				EnableDisableControls(true);
		}

		private void rdbVieta_CheckedChanged(object sender, System.EventArgs e) {
			ControlloVC();
		}

		private void rdbConsenti_CheckedChanged(object sender, System.EventArgs e) {
			ControlloVC();
		}

		private void tabController_SelectionChanged(object sender, System.EventArgs e) {
		
		}
	}
}
