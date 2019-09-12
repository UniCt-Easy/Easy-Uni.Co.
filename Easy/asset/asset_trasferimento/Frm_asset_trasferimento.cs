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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using System.Data;
using funzioni_configurazione;

namespace asset_trasferimento//beneinv_trasferimento//
{
	/// <summary>
	/// Summary description for frmbeneinv_trasferimento.
	/// </summary>
	public class Frm_asset_trasferimento : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		public vistaForm DS;
		private Crownwood.Magic.Controls.TabControl tabController;
		private Crownwood.Magic.Controls.TabPage tabPageInizio;
		private System.Windows.Forms.Label lblFase1;
		private Crownwood.Magic.Controls.TabPage tabPage1;
		private Crownwood.Magic.Controls.TabPage tabPage2;
		private Crownwood.Magic.Controls.TabPage tabPage3;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnBack;
		private System.ComponentModel.Container components = null;
		private string CustomTitle="Trasferimento cespiti";
		private MetaData Meta;
		private System.Windows.Forms.Label lblFase2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txt_idbene_da;
		private System.Windows.Forms.TextBox txt_idbene_a;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txt_numcarico_a;
		private System.Windows.Forms.TextBox txt_numcarico_da;
		private System.Windows.Forms.TextBox txt_numinv_a;
		private System.Windows.Forms.TextBox txt_numinv_da;
		private DataAccess Conn;
		private System.Windows.Forms.Label lblFase3;
		private System.Windows.Forms.GroupBox grpResp;
		private System.Windows.Forms.TextBox txtdesc;
		private System.Windows.Forms.ComboBox cboResp;
		private string Responsabile="";
		private string CodiceResponsabile="";
        private string Consegnatario = "";
        private string CodiceConsegnatario = "";
		private string Filtro="";
		private System.Windows.Forms.TextBox txtIdUbicazione;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtCodUbicazione;
		private System.Windows.Forms.GroupBox grpUbic;
		private System.Windows.Forms.TextBox txtCodUbic1;
		private System.Windows.Forms.TextBox txtDescUbic1;
		private System.Windows.Forms.TextBox txtIdUbic1;
		private System.Windows.Forms.Button btnUbic1;
		private System.Windows.Forms.Button btnUbic;
		private System.Windows.Forms.Label lblFase4;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.ComboBox cmbInventario;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtDataTrasferimento;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox cmbResponsabile;
		private Crownwood.Magic.Controls.TabPage tabPage2bis;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.DataGrid gridCespiti;
		private System.Windows.Forms.RadioButton rdbSostituisci;
		private System.Windows.Forms.RadioButton rdbStorico;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Button btnSelezionaTutto;
		private System.Windows.Forms.Label label17;
        private Label label18;
        private ComboBox cboConsegnatario;
        private GroupBox groupBox2;
        private ComboBox cmbConsegnatario;
        private GroupBox groupBox3;
        private Panel panel1;
        private System.Windows.Forms.Label label16;
	
		private enum eTipoModalita {
			IDBENE,
			NUMCARICOBENE,
			NUMINVENTARIO,
			RESPONSABILE,
			UBICAZIONE,
			NESSUNA,
			NONDEFINITA
		}
		//private eTipoModalita Modalita=eTipoModalita.NONDEFINITA;

		public Frm_asset_trasferimento()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			tabController.HideTabsMode = 
				Crownwood.Magic.Controls.TabControl.HideTabsModes.HideAlways;

			lblFase1.Text="Il processo di trasferimento di cespiti da un'ubicazione "+
				"ad un'altra può essere eseguito specificando tutti i cespiti o parte di essi "+
				"ricercandoli in base alle seguenti modalità:\r\n\r\n"+
				"- per ubicazione\r\n\r\n"+
				"- per identificativo cespite\r\n\r\n"+
				"- per numero carico cespite\r\n\r\n"+
				"- per numero inventario\r\n\r\n"+
				"- per responsabile";

			lblFase2.Text="Specificare il filtro per il trasferimento "+
				"di tutti i cespiti o parte secondo una delle modalità sotto indicate";
			GetData.CacheTable(DS.manager,null,"title",true);
			GetData.CacheTable(DS.manager1,null,"title",true);
            GetData.CacheTable(DS.managerconsegnatario, null, "title", true);
            GetData.CacheTable(DS.managerconsegnatario1, null, "title", true);
			GetData.CacheTable(DS.inventory,"(active='S')","description",true);
			DataAccess.SetTableForReading(DS.locationview_alias,"locationview");
			DataAccess.SetTableForReading(DS.manager1,"manager");
            DataAccess.SetTableForReading(DS.managerconsegnatario, "manager");
            DataAccess.SetTableForReading(DS.managerconsegnatario1, "manager");
			QueryCreator.SetTableForPosting(DS.assetview,"asset");
			txtDataTrasferimento.Text= HelpForm.StringValue(DateTime.Now,"x.y");
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
            this.DS = new asset_trasferimento.vistaForm();
            this.tabController = new Crownwood.Magic.Controls.TabControl();
            this.tabPageInizio = new Crownwood.Magic.Controls.TabPage();
            this.lblFase1 = new System.Windows.Forms.Label();
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.label18 = new System.Windows.Forms.Label();
            this.cboConsegnatario = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbInventario = new System.Windows.Forms.ComboBox();
            this.grpUbic = new System.Windows.Forms.GroupBox();
            this.txtIdUbic1 = new System.Windows.Forms.TextBox();
            this.txtDescUbic1 = new System.Windows.Forms.TextBox();
            this.txtCodUbic1 = new System.Windows.Forms.TextBox();
            this.btnUbic1 = new System.Windows.Forms.Button();
            this.cboResp = new System.Windows.Forms.ComboBox();
            this.txt_numinv_a = new System.Windows.Forms.TextBox();
            this.txt_numinv_da = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_numcarico_a = new System.Windows.Forms.TextBox();
            this.txt_numcarico_da = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_idbene_a = new System.Windows.Forms.TextBox();
            this.txt_idbene_da = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFase2 = new System.Windows.Forms.Label();
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbConsegnatario = new System.Windows.Forms.ComboBox();
            this.rdbStorico = new System.Windows.Forms.RadioButton();
            this.rdbSostituisci = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbResponsabile = new System.Windows.Forms.ComboBox();
            this.txtDataTrasferimento = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.grpResp = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCodUbicazione = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtdesc = new System.Windows.Forms.TextBox();
            this.txtIdUbicazione = new System.Windows.Forms.TextBox();
            this.btnUbic = new System.Windows.Forms.Button();
            this.lblFase3 = new System.Windows.Forms.Label();
            this.tabPage2bis = new Crownwood.Magic.Controls.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gridCespiti = new System.Windows.Forms.DataGrid();
            this.btnSelezionaTutto = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPage3 = new Crownwood.Magic.Controls.TabPage();
            this.lblFase4 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.tabController.SuspendLayout();
            this.tabPageInizio.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.grpUbic.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpResp.SuspendLayout();
            this.tabPage2bis.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCespiti)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // tabController
            // 
            this.tabController.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabController.IDEPixelArea = true;
            this.tabController.Location = new System.Drawing.Point(0, 0);
            this.tabController.Name = "tabController";
            this.tabController.SelectedIndex = 0;
            this.tabController.SelectedTab = this.tabPageInizio;
            this.tabController.Size = new System.Drawing.Size(715, 468);
            this.tabController.TabIndex = 1;
            this.tabController.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPageInizio,
            this.tabPage1,
            this.tabPage2,
            this.tabPage2bis,
            this.tabPage3});
            this.tabController.SelectionChanged += new System.EventHandler(this.tabController_SelectionChanged);
            // 
            // tabPageInizio
            // 
            this.tabPageInizio.Controls.Add(this.lblFase1);
            this.tabPageInizio.Location = new System.Drawing.Point(0, 0);
            this.tabPageInizio.Name = "tabPageInizio";
            this.tabPageInizio.Size = new System.Drawing.Size(715, 443);
            this.tabPageInizio.TabIndex = 6;
            this.tabPageInizio.Title = "Inizio";
            // 
            // lblFase1
            // 
            this.lblFase1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFase1.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.lblFase1.Location = new System.Drawing.Point(8, 16);
            this.lblFase1.Name = "lblFase1";
            this.lblFase1.Size = new System.Drawing.Size(699, 356);
            this.lblFase1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label18);
            this.tabPage1.Controls.Add(this.cboConsegnatario);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.cmbInventario);
            this.tabPage1.Controls.Add(this.grpUbic);
            this.tabPage1.Controls.Add(this.cboResp);
            this.tabPage1.Controls.Add(this.txt_numinv_a);
            this.tabPage1.Controls.Add(this.txt_numinv_da);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txt_numcarico_a);
            this.tabPage1.Controls.Add(this.txt_numcarico_da);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txt_idbene_a);
            this.tabPage1.Controls.Add(this.txt_idbene_da);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.lblFase2);
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Selected = false;
            this.tabPage1.Size = new System.Drawing.Size(715, 443);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Title = "Page1";
            this.tabPage1.Visible = false;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(24, 380);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(136, 33);
            this.label18.TabIndex = 29;
            this.label18.Text = "Subconsegnatario attuale";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboConsegnatario
            // 
            this.cboConsegnatario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboConsegnatario.DataSource = this.DS.managerconsegnatario;
            this.cboConsegnatario.DisplayMember = "title";
            this.cboConsegnatario.Location = new System.Drawing.Point(176, 380);
            this.cboConsegnatario.MaxDropDownItems = 25;
            this.cboConsegnatario.Name = "cboConsegnatario";
            this.cboConsegnatario.Size = new System.Drawing.Size(523, 23);
            this.cboConsegnatario.TabIndex = 28;
            this.cboConsegnatario.ValueMember = "idman";
            this.cboConsegnatario.SelectedIndexChanged += new System.EventHandler(this.cboConsegnatario_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(13, 288);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(152, 23);
            this.label16.TabIndex = 27;
            this.label16.Text = "Inventario";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(13, 256);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(152, 23);
            this.label15.TabIndex = 26;
            this.label15.Text = "Numero carico cespite";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(13, 224);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(152, 23);
            this.label14.TabIndex = 25;
            this.label14.Text = "Identificativo cespite";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(29, 192);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(136, 23);
            this.label12.TabIndex = 24;
            this.label12.Text = "Responsabile attuale";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(61, 144);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 23);
            this.label11.TabIndex = 23;
            this.label11.Text = "Ubicazione attuale";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(173, 296);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 16);
            this.label13.TabIndex = 22;
            this.label13.Text = "Tipo";
            // 
            // cmbInventario
            // 
            this.cmbInventario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbInventario.DataSource = this.DS.inventory;
            this.cmbInventario.DisplayMember = "description";
            this.cmbInventario.Location = new System.Drawing.Point(221, 288);
            this.cmbInventario.MaxDropDownItems = 25;
            this.cmbInventario.Name = "cmbInventario";
            this.cmbInventario.Size = new System.Drawing.Size(483, 23);
            this.cmbInventario.TabIndex = 12;
            this.cmbInventario.ValueMember = "idinventory";
            this.cmbInventario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmb_KeyDown);
            this.cmbInventario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmb_KeyPress);
            // 
            // grpUbic
            // 
            this.grpUbic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpUbic.Controls.Add(this.txtIdUbic1);
            this.grpUbic.Controls.Add(this.txtDescUbic1);
            this.grpUbic.Controls.Add(this.txtCodUbic1);
            this.grpUbic.Controls.Add(this.btnUbic1);
            this.grpUbic.Location = new System.Drawing.Point(181, 59);
            this.grpUbic.Name = "grpUbic";
            this.grpUbic.Size = new System.Drawing.Size(523, 125);
            this.grpUbic.TabIndex = 2;
            this.grpUbic.TabStop = false;
            this.grpUbic.Tag = "AutoChoose.txtCodUbic1.tree";
            // 
            // txtIdUbic1
            // 
            this.txtIdUbic1.Location = new System.Drawing.Point(120, 24);
            this.txtIdUbic1.Name = "txtIdUbic1";
            this.txtIdUbic1.Size = new System.Drawing.Size(80, 23);
            this.txtIdUbic1.TabIndex = 7;
            this.txtIdUbic1.Tag = "locationview_alias.idlocation";
            this.txtIdUbic1.Visible = false;
            // 
            // txtDescUbic1
            // 
            this.txtDescUbic1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescUbic1.Location = new System.Drawing.Point(96, 26);
            this.txtDescUbic1.Multiline = true;
            this.txtDescUbic1.Name = "txtDescUbic1";
            this.txtDescUbic1.ReadOnly = true;
            this.txtDescUbic1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescUbic1.Size = new System.Drawing.Size(419, 68);
            this.txtDescUbic1.TabIndex = 6;
            this.txtDescUbic1.Tag = "locationview_alias.description";
            // 
            // txtCodUbic1
            // 
            this.txtCodUbic1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodUbic1.Location = new System.Drawing.Point(6, 96);
            this.txtCodUbic1.Name = "txtCodUbic1";
            this.txtCodUbic1.Size = new System.Drawing.Size(509, 23);
            this.txtCodUbic1.TabIndex = 5;
            this.txtCodUbic1.Tag = "locationview_alias.locationcode";
            // 
            // btnUbic1
            // 
            this.btnUbic1.Location = new System.Drawing.Point(6, 67);
            this.btnUbic1.Name = "btnUbic1";
            this.btnUbic1.Size = new System.Drawing.Size(80, 23);
            this.btnUbic1.TabIndex = 1;
            this.btnUbic1.Tag = "manage.locationview_alias.tree";
            this.btnUbic1.Text = "Ubicazione";
            // 
            // cboResp
            // 
            this.cboResp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboResp.DataSource = this.DS.manager;
            this.cboResp.DisplayMember = "title";
            this.cboResp.Location = new System.Drawing.Point(181, 192);
            this.cboResp.MaxDropDownItems = 25;
            this.cboResp.Name = "cboResp";
            this.cboResp.Size = new System.Drawing.Size(523, 23);
            this.cboResp.TabIndex = 4;
            this.cboResp.ValueMember = "idman";
            this.cboResp.SelectedIndexChanged += new System.EventHandler(this.cboResp_SelectedIndexChanged);
            this.cboResp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmb_KeyDown);
            this.cboResp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmb_KeyPress);
            // 
            // txt_numinv_a
            // 
            this.txt_numinv_a.Location = new System.Drawing.Point(333, 320);
            this.txt_numinv_a.Name = "txt_numinv_a";
            this.txt_numinv_a.Size = new System.Drawing.Size(56, 23);
            this.txt_numinv_a.TabIndex = 14;
            this.txt_numinv_a.Leave += new System.EventHandler(this.LeaveInt);
            // 
            // txt_numinv_da
            // 
            this.txt_numinv_da.Location = new System.Drawing.Point(221, 320);
            this.txt_numinv_da.Name = "txt_numinv_da";
            this.txt_numinv_da.Size = new System.Drawing.Size(56, 23);
            this.txt_numinv_da.TabIndex = 13;
            this.txt_numinv_da.Leave += new System.EventHandler(this.LeaveInt);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(309, 320);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 16);
            this.label5.TabIndex = 15;
            this.label5.Text = "a";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(181, 320);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 16);
            this.label6.TabIndex = 14;
            this.label6.Text = "Da";
            // 
            // txt_numcarico_a
            // 
            this.txt_numcarico_a.Location = new System.Drawing.Point(333, 256);
            this.txt_numcarico_a.Name = "txt_numcarico_a";
            this.txt_numcarico_a.Size = new System.Drawing.Size(56, 23);
            this.txt_numcarico_a.TabIndex = 10;
            this.txt_numcarico_a.Leave += new System.EventHandler(this.LeaveInt);
            // 
            // txt_numcarico_da
            // 
            this.txt_numcarico_da.Location = new System.Drawing.Point(221, 256);
            this.txt_numcarico_da.Name = "txt_numcarico_da";
            this.txt_numcarico_da.Size = new System.Drawing.Size(56, 23);
            this.txt_numcarico_da.TabIndex = 9;
            this.txt_numcarico_da.Leave += new System.EventHandler(this.LeaveInt);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(309, 256);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "a";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(181, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Da";
            // 
            // txt_idbene_a
            // 
            this.txt_idbene_a.Location = new System.Drawing.Point(333, 224);
            this.txt_idbene_a.Name = "txt_idbene_a";
            this.txt_idbene_a.Size = new System.Drawing.Size(56, 23);
            this.txt_idbene_a.TabIndex = 7;
            this.txt_idbene_a.Leave += new System.EventHandler(this.LeaveInt);
            // 
            // txt_idbene_da
            // 
            this.txt_idbene_da.Location = new System.Drawing.Point(221, 224);
            this.txt_idbene_da.Name = "txt_idbene_da";
            this.txt_idbene_da.Size = new System.Drawing.Size(56, 23);
            this.txt_idbene_da.TabIndex = 6;
            this.txt_idbene_da.Leave += new System.EventHandler(this.LeaveInt);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(309, 224);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "a";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(181, 224);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Da";
            // 
            // lblFase2
            // 
            this.lblFase2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFase2.Location = new System.Drawing.Point(16, 8);
            this.lblFase2.Name = "lblFase2";
            this.lblFase2.Size = new System.Drawing.Size(683, 48);
            this.lblFase2.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.rdbStorico);
            this.tabPage2.Controls.Add(this.rdbSostituisci);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.txtDataTrasferimento);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.grpResp);
            this.tabPage2.Controls.Add(this.lblFase3);
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            this.tabPage2.Size = new System.Drawing.Size(715, 443);
            this.tabPage2.TabIndex = 4;
            this.tabPage2.Title = "Page2";
            this.tabPage2.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.cmbConsegnatario);
            this.groupBox2.Location = new System.Drawing.Point(16, 300);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(693, 50);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Selezionare il nuovo Subconsegnatario ( o lasciare vuoto per non variare il Subco" +
    "nsegnatario)";
            // 
            // cmbConsegnatario
            // 
            this.cmbConsegnatario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbConsegnatario.DataSource = this.DS.managerconsegnatario1;
            this.cmbConsegnatario.DisplayMember = "title";
            this.cmbConsegnatario.Location = new System.Drawing.Point(8, 18);
            this.cmbConsegnatario.MaxDropDownItems = 25;
            this.cmbConsegnatario.Name = "cmbConsegnatario";
            this.cmbConsegnatario.Size = new System.Drawing.Size(677, 23);
            this.cmbConsegnatario.TabIndex = 0;
            this.cmbConsegnatario.ValueMember = "idman";
            this.cmbConsegnatario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmb_KeyDown);
            this.cmbConsegnatario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmb_KeyPress);
            // 
            // rdbStorico
            // 
            this.rdbStorico.Checked = true;
            this.rdbStorico.Location = new System.Drawing.Point(16, 359);
            this.rdbStorico.Name = "rdbStorico";
            this.rdbStorico.Size = new System.Drawing.Size(264, 24);
            this.rdbStorico.TabIndex = 9;
            this.rdbStorico.TabStop = true;
            this.rdbStorico.Text = "Preserva la storicità del cespite";
            // 
            // rdbSostituisci
            // 
            this.rdbSostituisci.Location = new System.Drawing.Point(304, 367);
            this.rdbSostituisci.Name = "rdbSostituisci";
            this.rdbSostituisci.Size = new System.Drawing.Size(232, 24);
            this.rdbSostituisci.TabIndex = 8;
            this.rdbSostituisci.Text = "Sostituisci le informazioni  originali";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cmbResponsabile);
            this.groupBox1.Location = new System.Drawing.Point(16, 249);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(693, 50);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selezionare il nuovo responsabile ( o lasciare vuoto per non variare il responsab" +
    "ile)";
            // 
            // cmbResponsabile
            // 
            this.cmbResponsabile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbResponsabile.DataSource = this.DS.manager1;
            this.cmbResponsabile.DisplayMember = "title";
            this.cmbResponsabile.Location = new System.Drawing.Point(8, 18);
            this.cmbResponsabile.MaxDropDownItems = 25;
            this.cmbResponsabile.Name = "cmbResponsabile";
            this.cmbResponsabile.Size = new System.Drawing.Size(677, 23);
            this.cmbResponsabile.TabIndex = 0;
            this.cmbResponsabile.ValueMember = "idman";
            this.cmbResponsabile.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmb_KeyDown);
            this.cmbResponsabile.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmb_KeyPress);
            // 
            // txtDataTrasferimento
            // 
            this.txtDataTrasferimento.Location = new System.Drawing.Point(24, 402);
            this.txtDataTrasferimento.Name = "txtDataTrasferimento";
            this.txtDataTrasferimento.Size = new System.Drawing.Size(100, 23);
            this.txtDataTrasferimento.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(24, 386);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(176, 16);
            this.label9.TabIndex = 5;
            this.label9.Text = "Data di trasferimento";
            // 
            // grpResp
            // 
            this.grpResp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpResp.Controls.Add(this.label8);
            this.grpResp.Controls.Add(this.txtCodUbicazione);
            this.grpResp.Controls.Add(this.label7);
            this.grpResp.Controls.Add(this.txtdesc);
            this.grpResp.Controls.Add(this.txtIdUbicazione);
            this.grpResp.Controls.Add(this.btnUbic);
            this.grpResp.Location = new System.Drawing.Point(16, 88);
            this.grpResp.Name = "grpResp";
            this.grpResp.Size = new System.Drawing.Size(691, 155);
            this.grpResp.TabIndex = 4;
            this.grpResp.TabStop = false;
            this.grpResp.Tag = "AutoChoose.txtCodUbicazione.tree";
            this.grpResp.Text = "Selezionare la nuova ubicazione (o lasciare vuoto per non variare l\'ubicazione de" +
    "i cespiti selezionati)";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(13, 89);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 16);
            this.label8.TabIndex = 5;
            this.label8.Text = "Codice";
            // 
            // txtCodUbicazione
            // 
            this.txtCodUbicazione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodUbicazione.Location = new System.Drawing.Point(11, 117);
            this.txtCodUbicazione.Name = "txtCodUbicazione";
            this.txtCodUbicazione.Size = new System.Drawing.Size(674, 23);
            this.txtCodUbicazione.TabIndex = 4;
            this.txtCodUbicazione.Tag = "locationview.locationcode";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(16, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 16);
            this.label7.TabIndex = 3;
            this.label7.Text = "Identificativo";
            this.label7.Visible = false;
            // 
            // txtdesc
            // 
            this.txtdesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtdesc.Location = new System.Drawing.Point(118, 24);
            this.txtdesc.Multiline = true;
            this.txtdesc.Name = "txtdesc";
            this.txtdesc.ReadOnly = true;
            this.txtdesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtdesc.Size = new System.Drawing.Size(567, 81);
            this.txtdesc.TabIndex = 2;
            this.txtdesc.Tag = "locationview.description";
            // 
            // txtIdUbicazione
            // 
            this.txtIdUbicazione.Location = new System.Drawing.Point(6, 53);
            this.txtIdUbicazione.Name = "txtIdUbicazione";
            this.txtIdUbicazione.ReadOnly = true;
            this.txtIdUbicazione.Size = new System.Drawing.Size(112, 23);
            this.txtIdUbicazione.TabIndex = 1;
            this.txtIdUbicazione.Tag = "locationview.idlocation";
            this.txtIdUbicazione.Visible = false;
            // 
            // btnUbic
            // 
            this.btnUbic.Location = new System.Drawing.Point(16, 24);
            this.btnUbic.Name = "btnUbic";
            this.btnUbic.Size = new System.Drawing.Size(80, 23);
            this.btnUbic.TabIndex = 0;
            this.btnUbic.Tag = "manage.locationview.tree";
            this.btnUbic.Text = "Ubicazione";
            // 
            // lblFase3
            // 
            this.lblFase3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFase3.Location = new System.Drawing.Point(24, 16);
            this.lblFase3.Name = "lblFase3";
            this.lblFase3.Size = new System.Drawing.Size(683, 56);
            this.lblFase3.TabIndex = 3;
            // 
            // tabPage2bis
            // 
            this.tabPage2bis.Controls.Add(this.groupBox3);
            this.tabPage2bis.Controls.Add(this.btnSelezionaTutto);
            this.tabPage2bis.Controls.Add(this.label17);
            this.tabPage2bis.Controls.Add(this.label10);
            this.tabPage2bis.Location = new System.Drawing.Point(0, 0);
            this.tabPage2bis.Name = "tabPage2bis";
            this.tabPage2bis.Selected = false;
            this.tabPage2bis.Size = new System.Drawing.Size(715, 443);
            this.tabPage2bis.TabIndex = 7;
            this.tabPage2bis.Title = "Page 2bis";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.gridCespiti);
            this.groupBox3.Location = new System.Drawing.Point(11, 67);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(701, 373);
            this.groupBox3.TabIndex = 29;
            this.groupBox3.TabStop = false;
            // 
            // gridCespiti
            // 
            this.gridCespiti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridCespiti.DataMember = "";
            this.gridCespiti.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridCespiti.Location = new System.Drawing.Point(6, 22);
            this.gridCespiti.Name = "gridCespiti";
            this.gridCespiti.Size = new System.Drawing.Size(689, 342);
            this.gridCespiti.TabIndex = 0;
            this.gridCespiti.Tag = "assetview.default";
            // 
            // btnSelezionaTutto
            // 
            this.btnSelezionaTutto.Location = new System.Drawing.Point(8, 16);
            this.btnSelezionaTutto.Name = "btnSelezionaTutto";
            this.btnSelezionaTutto.Size = new System.Drawing.Size(88, 23);
            this.btnSelezionaTutto.TabIndex = 28;
            this.btnSelezionaTutto.Text = "Seleziona tutto";
            this.btnSelezionaTutto.Click += new System.EventHandler(this.btnSelezionaTutto_Click);
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(112, 16);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(456, 32);
            this.label17.TabIndex = 27;
            this.label17.Text = "Tenere premuto il tasto CTRL o MAIUSC e contemporaneamente cliccare con il mouse " +
    "per selezionare più cespiti da trasferire";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(8, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(440, 16);
            this.label10.TabIndex = 1;
            this.label10.Text = "Verranno elaborati i seguenti cespiti:";
            // 
            // tabPage3
            // 
            this.tabPage3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabPage3.Controls.Add(this.lblFase4);
            this.tabPage3.Location = new System.Drawing.Point(0, 0);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Selected = false;
            this.tabPage3.Size = new System.Drawing.Size(715, 443);
            this.tabPage3.TabIndex = 5;
            this.tabPage3.Title = "Page3";
            this.tabPage3.Visible = false;
            // 
            // lblFase4
            // 
            this.lblFase4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFase4.Location = new System.Drawing.Point(3, 11);
            this.lblFase4.Name = "lblFase4";
            this.lblFase4.Size = new System.Drawing.Size(691, 208);
            this.lblFase4.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(641, 486);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Annulla";
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(537, 486);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 11;
            this.btnNext.Text = "Avanti >";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(457, 486);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 10;
            this.btnBack.Text = "< Indietro";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.tabController);
            this.panel1.Location = new System.Drawing.Point(2, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(715, 468);
            this.panel1.TabIndex = 13;
            // 
            // Frm_asset_trasferimento
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(729, 523);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnBack);
            this.Name = "Frm_asset_trasferimento";
            this.Text = "frmbeneinv_trasferimento";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.tabController.ResumeLayout(false);
            this.tabPageInizio.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.grpUbic.ResumeLayout(false);
            this.grpUbic.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.grpResp.ResumeLayout(false);
            this.grpResp.PerformLayout();
            this.tabPage2bis.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCespiti)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

        CQueryHelper QHC;
        QueryHelper QHS;
		public void MetaData_AfterLink() {
			Meta=MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
			Conn=Meta.Conn;
		}

		public void MetaData_AfterClear() {
			DisplayTabs(0);
		}

		void DisplayTabs(int newTab){
			tabController.SelectedIndex = newTab;
			//Evaluates Buttons Appearance
			btnBack.Visible=(newTab>0);
			if (newTab== tabController.TabPages.Count-1)
				btnNext.Text="Fine";
			else
				btnNext.Text="Avanti >";
			Text = CustomTitle+ " (Pagina "+(newTab+1)+" di "+tabController.TabPages.Count+")";
		}

		private void btnBack_Click(object sender, System.EventArgs e) {
			StandardChangeTab(-1);
		}

		private void btnNext_Click(object sender, System.EventArgs e) {
			StandardChangeTab(+1);
		}


		bool CustomChangeTab(int oldTab, int newTab){
			if ((oldTab==0)&&(newTab==1)) return true;
			if ((oldTab==1)&&(newTab==2)) return GetFiltro();
			if ((oldTab==2)&&(newTab==3)) {
				if ((txtIdUbicazione.Text.Trim()=="")&&(cmbResponsabile.SelectedIndex<=0)){
					ShowMsg("Attenzione, non è stato selezionato nessun cambiamento da effettuare");
					return false;
				}
				if (rdbStorico.Checked){
					object T = HelpForm.GetObjectFromString(typeof(DateTime), 
						txtDataTrasferimento.Text,"x.y");
					if (T==DBNull.Value){
						ShowMsg("Attenzione, non è stata selezionata una data di trasferimento");
						return false;
					}
				    if ((DateTime)T==QueryCreator.EmptyDate()){
				        ShowMsg("Attenzione, non è stata selezionata una data di trasferimento");
				        return false;
				    }
				}
				return AggiornaGrid();
			}
			if ((oldTab==3)&&(newTab==4)) return AggiornaDati();
			if ((oldTab==3)&&(newTab==2)) {
				DS.assetview.Clear();
			}
			if ((oldTab==4)&&(newTab==3)) {
				DS.assetmanager.Clear();
				DS.assetlocation.Clear();
                DS.assetsubmanager.Clear();
				DS.assetview.RejectChanges();
				return true;
			}
			return true;
		}

        private void cmb_KeyDown (object sender, System.Windows.Forms.KeyEventArgs e) {
            ComboBox acComboBox = (ComboBox)sender;
            int selectionStart = acComboBox.SelectionStart;

            switch (e.KeyCode) {
                //Se è stato premuta la freccia "SINISTRA" faccio cominciare la selezione
                //un carattere prima rispetto alla selezione attuale
                case Keys.Left:
                if (selectionStart > 0) {
                    acComboBox.Select(selectionStart - 1, acComboBox.Text.Length - (selectionStart - 1));
                }
                else {
                    acComboBox.SelectAll();
                }
                break;

                //Se è stato premuto il tasto "CANC" seleziono la riga vuota del combobox
                case Keys.Delete:
                int index = acComboBox.FindString("");
                if (index != -1) {
                    acComboBox.DroppedDown = false;
                    acComboBox.SelectedIndex = index;
                    acComboBox.DroppedDown = true;
                }
                acComboBox.SelectAll();
                break;

                //Se è stato premuta la freccia "DESTRA" faccio cominciare la selezione
                //un carattere dopo rispetto alla selezione attuale
                case Keys.Right:
                if (acComboBox.Text.Length > selectionStart) {
                    acComboBox.Select(selectionStart + 1, acComboBox.Text.Length - (selectionStart + 1));
                }
                break;

                //Se è stato premuto il tasto "HOME" seleziono tutta la riga attuale.
                case Keys.Home:
                acComboBox.SelectAll();
                break;

                default:
                //Altrimenti lascio la gestione di questo evento a .NET
                return;
            }
            e.Handled = true;
        }

        private void cmb_KeyPress (object sender, System.Windows.Forms.KeyPressEventArgs e) {
            //Se è stato premuto ESC o INVIO lascio la gestione dell'evento a .NET
            if ((e.KeyChar == 27) || (e.KeyChar == 13)) {
                return;
            }

            ComboBox acComboBox = (ComboBox)sender;

            int selectionStart = acComboBox.SelectionStart;
            if (selectionStart > acComboBox.Text.Length) selectionStart = acComboBox.Text.Length;

            //Se il tasto premuto è BACKSPACE, faccio cominciare la selezione un carattere prima
            //dell'inizio della selezione corrente
            if (e.KeyChar == 8) {
                if (selectionStart > 0) {
                    acComboBox.Select(selectionStart - 1, acComboBox.Text.Length - (selectionStart - 1));
                }
                else {
                    acComboBox.SelectAll();
                }
            }
            else {
                //Se è un qualunque altro carattere (quindi tale che IsInputKey()=true
                //e diverso anche da ESC, INVIO, BACK) allora lo gestisco io.

                //Cerco una riga del ComboBox che cominci per i primi "selectionStart" caratteri
                //della riga corrente concatenati col tasto premuto
                string ricerca = acComboBox.Text.Substring(0, selectionStart) + e.KeyChar;

                int index = acComboBox.FindString(ricerca);

                if (index != -1) {
                    //Se tale riga esiste, allora la seleziono
                    if (acComboBox.SelectedIndex != index) {
                        acComboBox.DroppedDown = false;
                        acComboBox.SelectedIndex = index;
                    }
                    acComboBox.DroppedDown = true;
                    if (selectionStart < acComboBox.Text.Length) {
                        //e faccio cominciare la selezione da selectionstart + 1
                        acComboBox.Select(selectionStart + 1, acComboBox.Text.Length - (selectionStart + 1));
                    }
                }
                else {
                    //Se invece tale riga non esiste, allora seleziono la riga attuale
                    //dal carattere in posizione selectionStart fino alla fine
                    acComboBox.DroppedDown = true;
                    acComboBox.Select(selectionStart, acComboBox.Text.Length - selectionStart);
                }
            }
            //Forzo l'apertura della tendina per facilitare l'utente nella scelta
            e.Handled = true;
        }


		private bool UpdateData(out int righe) {
			righe=0;
			DataRow []RigheSelezionate= GetGridSelectedRows(gridCespiti);
			object idubicazione_new=txtIdUbicazione.Text.Trim();
			if (idubicazione_new.ToString()=="") idubicazione_new=DBNull.Value;
			object newresp=DBNull.Value;
			if (cmbResponsabile.SelectedIndex>0){
				newresp= cmbResponsabile.SelectedValue;
			}
            object newconsegnatario = DBNull.Value;
            if (cmbConsegnatario.SelectedIndex > 0) {
                newconsegnatario = cmbConsegnatario.SelectedValue;
            }
            MetaData MLoc = MetaData.GetMetaData(this, "assetlocation");
            MetaData MMan = MetaData.GetMetaData(this, "assetmanager");
            MetaData MSubMan = MetaData.GetMetaData(this, "assetsubmanager");
            if (rdbStorico.Checked) {
                DateTime T = (DateTime)HelpForm.GetObjectFromString(typeof(DateTime),
                                txtDataTrasferimento.Text, "x.y");
                MLoc.SetDefaults(DS.assetlocation);
                MMan.SetDefaults(DS.assetmanager);
                MSubMan.SetDefaults(DS.assetsubmanager);

                //foreach (DataRow R in DS.assetview.Rows) {
                foreach (DataRow R in RigheSelezionate) {
                    if (idubicazione_new != DBNull.Value) {
                        MetaData.SetDefault(DS.assetlocation, "idasset", R["idasset"]);
                        MetaData.SetDefault(DS.assetlocation, "start", T);
                        DataRow NewLoc = MLoc.Get_New_Row(null, DS.assetlocation);
                        NewLoc["idlocation"] = idubicazione_new;
                        R["idcurrlocation"] = idubicazione_new;
                    }
                  
                    if (newresp != DBNull.Value) {
                        MetaData.SetDefault(DS.assetmanager, "idasset", R["idasset"]);
                        MetaData.SetDefault(DS.assetmanager, "start", T);
                        DataRow NewMan = MMan.Get_New_Row(null, DS.assetmanager);
                        NewMan["idman"] = newresp;
                        R["idcurrman"] = newresp;
                    }
         
                    if (newconsegnatario != DBNull.Value) {
                        MetaData.SetDefault(DS.assetsubmanager, "idasset", R["idasset"]);
                        MetaData.SetDefault(DS.assetsubmanager, "start", T);
                        DataRow NewSubMan = MSubMan.Get_New_Row(null, DS.assetsubmanager);
                        NewSubMan["idmanager"] = newconsegnatario;
                        R["idcurrsubman"] = newconsegnatario;
                    }
                    righe++;
                }
                PostData pd = Meta.Get_PostData();
                pd.InitClass(DS, Meta.Conn);
                return pd.DO_POST();

            }
            else {
                foreach (DataRow R in RigheSelezionate) {
                    if (idubicazione_new != DBNull.Value) {
                        string filtro = QHC.AppAnd(QHC.CmpEq("idasset", R["idasset"]), QHC.IsNull("start"));
                        string filtroSQL = QHS.AppAnd(QHS.CmpEq("idasset", R["idasset"]), QHS.IsNull("start"));

                        if (DS.assetlocation.Select(filtro).Length > 0) {
                            DataRow Curr = DS.assetlocation.Select(filtro)[0];
                            Curr["idlocation"] = idubicazione_new;
                        }
                        else {
                            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.assetlocation, null, filtroSQL, null, true);
                            if (DS.assetlocation.Select(filtro).Length > 0) {
                                DataRow Curr = DS.assetlocation.Select(filtro)[0];
                                Curr["idlocation"] = idubicazione_new;
                            }
                            else {
                                MetaData.SetDefault(DS.assetlocation, "idasset", R["idasset"]);
                                DataRow NewLoc = MLoc.Get_New_Row(null, DS.assetlocation);
                                NewLoc["idlocation"] = idubicazione_new;
                                NewLoc["start"] = DBNull.Value;
                            }
                        }
                        R["idcurrlocation"] = idubicazione_new;
                    }
                    if (newresp != DBNull.Value) {
                        string filtro = QHC.AppAnd(QHC.CmpEq("idasset", R["idasset"]), QHC.IsNull("start"));
                        string filtroSQL = QHS.AppAnd(QHC.CmpEq("idasset", R["idasset"]), QHS.IsNull("start"));
                        if (DS.assetmanager.Select(filtro).Length > 0) {
                            DataRow Curr = DS.assetmanager.Select(filtro)[0];
                            Curr["idman"] = newresp;
                        }
                        else {
                            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.assetmanager, null, filtroSQL, null, true);
                            if (DS.assetmanager.Select(filtro).Length > 0) {
                                DataRow Curr = DS.assetmanager.Select(filtro)[0];
                                Curr["idman"] = newresp;
                            }
                            else {
                                MetaData.SetDefault(DS.assetmanager, "idasset", R["idasset"]);
                                DataRow NewMan = MMan.Get_New_Row(null, DS.assetmanager);
                                NewMan["idman"] = newresp;
                                NewMan["start"] = DBNull.Value;
                            }
                        }
                    }
                    if (newconsegnatario != DBNull.Value) {
                        string filtro = QHC.AppAnd(QHC.CmpEq("idasset", R["idasset"]), QHC.IsNull("start"));
                        string filtroSQL = QHS.AppAnd(QHC.CmpEq("idasset", R["idasset"]), QHS.IsNull("start"));
                        if (DS.assetsubmanager.Select(filtro).Length > 0) {
                            DataRow Curr = DS.assetsubmanager.Select(filtro)[0];
                            Curr["idmanager"] = newconsegnatario;
                        }
                        else {
                            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.assetsubmanager, null, filtroSQL, null, true);
                            if (DS.assetsubmanager.Select(filtro).Length > 0) {
                                DataRow Curr = DS.assetsubmanager.Select(filtro)[0];
                                Curr["idmanager"] = newconsegnatario;
                            }
                            else {
                                MetaData.SetDefault(DS.assetsubmanager, "idasset", R["idasset"]);
                                DataRow NewSubMan = MSubMan.Get_New_Row(null, DS.assetsubmanager);
                                NewSubMan["idmanager"] = newconsegnatario;
                                NewSubMan["start"] = DBNull.Value;
                            }
                        }
                    }
                    righe++;
                }
                PostData pd = Meta.Get_PostData();
                pd.InitClass(DS, Meta.Conn);
                return pd.DO_POST();
            }

		}

		bool AggiornaGrid(){
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.assetview, "codeinventory,ninventory", Filtro, null, false);
			HelpForm.SetDataGrid(gridCespiti,DS.assetview);
			HelpForm.SetAllowMultiSelection(DS.assetview,true);
			SelezionaTuttiICespiti();
			return true;
		}

		private DataRow[] GetGridSelectedRows(DataGrid G){
			if (G.DataMember==null) return null;
			if (G.DataSource==null) return null;
			string TableName = G.DataMember.ToString();
			DataSet MyDS =(DataSet)G.DataSource;
			DataTable MyTable = MyDS.Tables[TableName];
			int numrighetemp=MyTable.Rows.Count;
			int numrighe=0;
			int i;
			for (i=0; i<numrighetemp; i++){
				if(G.IsSelected(i)){
					numrighe++;
				}
			}

			DataRow[] Res=new DataRow[numrighe]; 			
			int count=0;
			for (i=0; i<numrighetemp; i++){
				if(G.IsSelected(i)){
					Res[count++]= GetGridRow(G,i);
				}
			}
			return Res;
		    
			
		}


		DataRow GetGridRow(DataGrid G, int index){
			string TableName = G.DataMember.ToString();
			DataSet MyDS =(DataSet)G.DataSource;
			DataTable MyTable = MyDS.Tables[TableName];
			string filter;
			//filter="idasset='"+G[index,0].ToString()+"' and idpiece = '" +G[index,1].ToString()+"'";
            filter = QHS.AppAnd(QHS.CmpEq("idasset", G[index, 0]), QHS.CmpEq("idpiece", G[index, 1]));
			DataRow[] selectresult = MyTable.Select(filter);
			return selectresult[0];
		}

		private bool AggiornaDati() {

			string msg="";
			if (txtIdUbicazione.Text.Trim()!="" && cmbResponsabile.SelectedIndex>0){
				msg="Attenzione, verranno trasferiti i cespiti e ne sarà cambiato il responsabile in base alla "+
				"modalità prescelta. Continuare?";
			}
			if (txtIdUbicazione.Text.Trim()!="" && cmbResponsabile.SelectedIndex<=0){
				msg="Attenzione, verranno trasferiti i cespiti in base alla "+
				"modalità prescelta. Continuare?";
			}
			if (txtIdUbicazione.Text.Trim()=="" && cmbResponsabile.SelectedIndex>0){
				msg="Attenzione, sarà cambiato il responsabile dei cespiti in base alla "+
				"modalità prescelta. Continuare?";
			}

			if (MessageBox.Show(msg,"Attenzione",
				MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question)!=DialogResult.Yes)
				return false;
			
			int righe;
			if (UpdateData(out righe)) {
				if (righe > 0)
					lblFase4.Text="Elaborazione terminata con successo. "+
						"Numero cespiti elaborati: "+ righe.ToString();
				else
					lblFase4.Text="Nessun cespite trovato in base al criterio di ricerca effettuato.";
			}
			else {
				lblFase4.Text="Sono stati riscontrati errori. "+
					"Non è stato possibile effettuare il trasferimento dei cespiti";
			}

			return true;
		}

		void StandardChangeTab(int step){
			int oldTab= tabController.SelectedIndex;
			int newTab= oldTab+step;
			if ((newTab<0)||(newTab>tabController.TabPages.Count))return;
			if (!CustomChangeTab(oldTab, newTab)) return;
			if (newTab==tabController.TabPages.Count){
				DialogResult= DialogResult.OK;
				return;
			}
			DisplayTabs(newTab);
		}


		/// <summary>
		/// Restituisce false se non è stato applicato alcun filtro
		/// </summary>
		/// <returns></returns>
		private bool GetFiltro() {
			Filtro="";
			//string field="";
			if (txtIdUbic1.Text!=""){
                Filtro = QHS.AppAnd(Filtro, QHS.CmpEq("idcurrlocation", txtIdUbic1.Text));
			}

			if (cboResp.SelectedIndex>0){
                Filtro = QHS.CmpEq("idcurrman", cboResp.SelectedValue);
			}

            if (cboConsegnatario.SelectedIndex > 0) {
                Filtro = QHS.AppAnd(Filtro, QHS.CmpEq("idcurrsubman", cboConsegnatario.SelectedValue));
            }           

			if (txt_idbene_da.Text.Trim()!=""){
				int N1= CfgFn.GetNoNullInt32(HelpForm.GetObjectFromString(typeof(int),txt_idbene_da.Text,"x.y"));
				if (N1>0){
                    Filtro = QHS.AppAnd(Filtro,QHS.CmpGe("idasset", N1));

				}
			}
			if (txt_idbene_a.Text.Trim()!=""){
				int N2= CfgFn.GetNoNullInt32(HelpForm.GetObjectFromString(typeof(int),txt_idbene_a.Text,"x.y"));
				if (N2>0){
                    Filtro = QHS.AppAnd(Filtro, QHS.CmpLe("idasset", N2));

				}
			}
			if (txt_numcarico_da.Text.Trim()!=""){
				int N3= CfgFn.GetNoNullInt32(HelpForm.GetObjectFromString(typeof(int),txt_numcarico_da.Text,"x.y"));
				if (N3>0){
                    Filtro = QHS.AppAnd(Filtro, QHS.CmpGe("nassetacquire", N3));

				}
			}
			if (txt_numcarico_a.Text.Trim()!=""){
				int N4= CfgFn.GetNoNullInt32(HelpForm.GetObjectFromString(typeof(int),txt_numcarico_a.Text,"x.y"));
				if (N4>0){
                    Filtro = QHS.AppAnd(Filtro, QHS.CmpLe("nassetacquire", N4));
				}
			}

			if (txt_numinv_da.Text.Trim()!=""){
				int N5= CfgFn.GetNoNullInt32(HelpForm.GetObjectFromString(typeof(int),txt_numinv_da.Text,"x.y"));
				if (N5>0){
                    Filtro = QHS.AppAnd(Filtro, QHS.CmpGe("ninventory", N5));

				}
			}
			if (txt_numinv_a.Text.Trim()!=""){
				int N6= CfgFn.GetNoNullInt32(HelpForm.GetObjectFromString(typeof(int),txt_numinv_a.Text,"x.y"));
				if (N6>0){
                    Filtro = QHS.AppAnd(Filtro, QHS.CmpLe("ninventory", N6));
				}
			}

			if (cmbInventario.SelectedIndex>0){
                Filtro = QHS.AppAnd(Filtro,QHS.CmpEq("idinventory",cmbInventario.SelectedValue));
			}
			if (Filtro==""){
                Filtro = QHS.CmpEq("idpiece", 1);
				return (MessageBox.Show(
					"Non è stato selezionato alcun filtro. Saranno trasferiti TUTTI i cespiti del patrimonio. Conferma?",
					"Conferma",MessageBoxButtons.OKCancel)==DialogResult.OK);
			}
			else {
                Filtro = QHS.AppAnd(Filtro, QHS.CmpEq("idpiece", 1));
				return true;
			}

		}

		
		private void ShowMsg(string msg) {
			MessageBox.Show(msg,"Attenzione",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
		}




		private void cboResp_SelectedIndexChanged(object sender, System.EventArgs e) {
			try {
				DataRow R=((DataRowView)cboResp.SelectedItem).Row;
				CodiceResponsabile=R["idman"].ToString();
				Responsabile=R["title"].ToString();
			}
			catch {
				CodiceResponsabile="";
				Responsabile="";
			}
		}

		private void LeaveInt(object sender, System.EventArgs e) {
			HelpForm.LeaveIntTextBox(sender,e);
		}

		private void tabController_SelectionChanged(object sender, System.EventArgs e) {
		
		}

		private void SelezionaTuttiICespiti() {
			object dataSource = gridCespiti.DataSource;
			if (dataSource==null) return;

			CurrencyManager cm = (CurrencyManager) 
				gridCespiti.BindingContext[dataSource, gridCespiti.DataMember];

			DataView view = cm.List as DataView;

			if (view != null) {
				for (int i=0; i<view.Count; i++) {
					gridCespiti.Select(i);
				}
			}
		}

		private void btnSelezionaTutto_Click(object sender, System.EventArgs e) {
			SelezionaTuttiICespiti();
		}

        private void cboConsegnatario_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                DataRow R = ((DataRowView)cboConsegnatario.SelectedItem).Row;
                CodiceConsegnatario = R["idman"].ToString();
                Consegnatario = R["title"].ToString();
            }
            catch {
                CodiceConsegnatario = "";
                Consegnatario = "";
            }
        }



	}
}
