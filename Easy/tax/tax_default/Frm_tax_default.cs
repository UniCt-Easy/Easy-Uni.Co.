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
using System.Data;
using metadatalibrary;

namespace tax_default {//tiporitenutalista//
	/// <summary>
	/// Summary description for frmtiporitenutalista.
	/// </summary>
	public class Frm_tax_default : System.Windows.Forms.Form {
        public vistaForm DS;
        private System.Windows.Forms.ImageList images;
        private System.Windows.Forms.ImageList imageList1;
        private TabControl tabControl1;
        private TabPage tabPage4;
        private GroupBox groupBox3;
        private DataGrid detailgrid;
        private Button btnInserisci;
        private Button btnElimina;
        private Button btnModifica;
        private Label label4;
        private ComboBox cmbMainTax;
        private Label label2;
        private TextBox txtCodiceRitenuta;
        private TextBox txtDescrizione;
        private ComboBox cmbImponibile;
        private TextBox txtCodiceTributo;
        private Label label1;
        private Button button1;
        private Label label3;
        private GroupBox gboxCategoria;
        private RadioButton radioButton13;
        private RadioButton radioButton5;
        private RadioButton radioButton4;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private GroupBox grptipoapplicazione;
        private RadioButton radioButton9;
        private RadioButton radioButton8;
        private RadioButton radioButton7;
        private RadioButton radioButton6;
        private GroupBox gboxApplicazione;
        private RadioButton radioButton12;
        private RadioButton radioButton11;
        private RadioButton radioButton10;
        private CheckBox chkIndetr;
        private CheckBox chkAttivo;
        private TabPage tabPage6;
        private DataGrid dataGrid1;
        private Button button11;
        private Button button12;
        private Button button13;
        private TabPage tabPage1;
        private GroupBox groupBox4;
        private DataGrid dataGrid2;
        private Button button2;
        private Button button3;
        private Button button4;
        private TextBox textBox1;
        private Label label5;
        private Label label6;
        private TextBox textBox2;
        private System.ComponentModel.IContainer components;

		public Frm_tax_default() {
			InitializeComponent();
			DataAccess.SetTableForReading(DS.accmotiveapplied_pay,"accmotiveapplied");
			DataAccess.SetTableForReading(DS.accmotiveapplied_cost,"accmotiveapplied");
            DataAccess.SetTableForReading(DS.finmotive_incomeintra, "finmotive");
            DataAccess.SetTableForReading(DS.finmotive_admintax, "finmotive");
            DataAccess.SetTableForReading(DS.finmotive_incomeemploy, "finmotive");
            DataAccess.SetTableForReading(DS.finmotive_expensecontra, "finmotive");
            DataAccess.SetTableForReading(DS.finmotive_expenseemploy, "finmotive");
            DataAccess.SetTableForReading(DS.service1, "service");
            DataAccess.SetTableForReading(DS.maintax, "tax");
            GetData.MarkToAddBlankRow(DS.maintax);
			HelpForm.SetDenyNull(DS.tax.Columns["flagunabatable"], true);
		}
        QueryHelper QHS;
	    private bool IsAdmin = false;
	    private MetaData Meta;
        public void MetaData_AfterLink(){
			Meta= MetaData.GetMetaData(this);
            QHS = Meta.Conn.GetQueryHelper();
			GetData.SetStaticFilter(DS.taxablekind,QHS.CmpEq("ayear",Meta.GetSys("esercizio")));

			if (Meta.GetSys("manage_prestazioni")!=null) 
				IsAdmin=(Meta.GetSys("manage_prestazioni").ToString()=="S");
			Meta.CanSave=true;
			Meta.CanInsert=IsAdmin;
			Meta.CanInsertCopy=IsAdmin;
			Meta.CanCancel=IsAdmin;		
			HelpForm.SetDenyNull(DS.tax.Columns["active"],true);

            string filterEpOperation = QHS.CmpEq("idepoperation", "apprit");
			DS.accmotiveapplied.ExtendedProperties[MetaData.ExtraParams]=filterEpOperation;
			GetData.SetStaticFilter(DS.accmotiveapplied,filterEpOperation);
            filterEpOperation = QHS.CmpEq("idepoperation", "appcontrib"); 
			DS.accmotiveapplied_cost.ExtendedProperties[MetaData.ExtraParams]=filterEpOperation;
			GetData.SetStaticFilter(DS.accmotiveapplied_cost,filterEpOperation);
            filterEpOperation = QHS.CmpEq("idepoperation", "liqrit"); 
			DS.accmotiveapplied_pay.ExtendedProperties[MetaData.ExtraParams]=filterEpOperation;
			GetData.SetStaticFilter(DS.accmotiveapplied_pay,filterEpOperation);
            GetData.CacheTable(DS.maintax, null, null, true);
            GetData.SetStaticFilter(DS.maintax, QHS.IsNull("maintaxcode"));
            GetData.SetSorting(DS.maintax, "description asc");
            GetData.SetStaticFilter(DS.taxmotiveyear, QHS.CmpEq("ayear", Meta.GetSys("esercizio")));

            EnableDisableMainCtrl();
        }

	    public void MetaData_AfterClear() {
	        EnableDisableMainCtrl();
	    }
        public void MetaData_AfterFill() {
            EnableDisableMainCtrl();
            Meta.MarkTableAsNotEntityChild(DS.taxmotiveyear, "tax_taxmotiveyear");
        }
        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (T.TableName == "tax") {
                if (!Meta.DrawStateIsDone) return;
                 if (R != null) {
                    MetaData.SetDefault(DS.taxmotiveyear, "taxcode", R["taxcode"]);            
                }
            }
        }

        void EnableDisableMainCtrl() {
	        bool abilita = Meta.IsEmpty || IsAdmin;
            txtCodiceRitenuta.ReadOnly = !abilita;
            txtDescrizione.ReadOnly = !abilita;
	        txtCodiceTributo.ReadOnly = !abilita;
            cmbMainTax.Enabled = abilita;
            cmbImponibile.Enabled = abilita;
            gboxCategoria.Enabled = abilita;
	        gboxApplicazione.Enabled = abilita;
	        grptipoapplicazione.Enabled = abilita;
	        chkAttivo.Enabled = abilita;
            chkIndetr.Enabled = abilita;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_tax_default));
            this.DS = new tax_default.vistaForm();
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.detailgrid = new System.Windows.Forms.DataGrid();
            this.btnInserisci = new System.Windows.Forms.Button();
            this.btnElimina = new System.Windows.Forms.Button();
            this.btnModifica = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbMainTax = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodiceRitenuta = new System.Windows.Forms.TextBox();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.cmbImponibile = new System.Windows.Forms.ComboBox();
            this.txtCodiceTributo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.gboxCategoria = new System.Windows.Forms.GroupBox();
            this.radioButton13 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.grptipoapplicazione = new System.Windows.Forms.GroupBox();
            this.radioButton9 = new System.Windows.Forms.RadioButton();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.gboxApplicazione = new System.Windows.Forms.GroupBox();
            this.radioButton12 = new System.Windows.Forms.RadioButton();
            this.radioButton11 = new System.Windows.Forms.RadioButton();
            this.radioButton10 = new System.Windows.Forms.RadioButton();
            this.chkIndetr = new System.Windows.Forms.CheckBox();
            this.chkAttivo = new System.Windows.Forms.CheckBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detailgrid)).BeginInit();
            this.gboxCategoria.SuspendLayout();
            this.grptipoapplicazione.SuspendLayout();
            this.gboxApplicazione.SuspendLayout();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
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
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(8, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(670, 487);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Controls.Add(this.textBox2);
            this.tabPage4.Controls.Add(this.textBox1);
            this.tabPage4.Controls.Add(this.label5);
            this.tabPage4.Controls.Add(this.groupBox3);
            this.tabPage4.Controls.Add(this.label4);
            this.tabPage4.Controls.Add(this.cmbMainTax);
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Controls.Add(this.txtCodiceRitenuta);
            this.tabPage4.Controls.Add(this.txtDescrizione);
            this.tabPage4.Controls.Add(this.cmbImponibile);
            this.tabPage4.Controls.Add(this.txtCodiceTributo);
            this.tabPage4.Controls.Add(this.label1);
            this.tabPage4.Controls.Add(this.button1);
            this.tabPage4.Controls.Add(this.label3);
            this.tabPage4.Controls.Add(this.gboxCategoria);
            this.tabPage4.Controls.Add(this.grptipoapplicazione);
            this.tabPage4.Controls.Add(this.gboxApplicazione);
            this.tabPage4.Controls.Add(this.chkIndetr);
            this.tabPage4.Controls.Add(this.chkAttivo);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(662, 461);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "Generale";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(313, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 16);
            this.label6.TabIndex = 49;
            this.label6.Text = "a credito:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(374, 90);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(112, 20);
            this.textBox2.TabIndex = 48;
            this.textBox2.Tag = "tax.fiscaltaxcodecredit";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(200, 140);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(112, 20);
            this.textBox1.TabIndex = 46;
            this.textBox1.Tag = "tax.insuranceagencycode";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(184, 16);
            this.label5.TabIndex = 47;
            this.label5.Text = "Codice Istituto Previdenziale (DALIA)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.detailgrid);
            this.groupBox3.Controls.Add(this.btnInserisci);
            this.groupBox3.Controls.Add(this.btnElimina);
            this.groupBox3.Controls.Add(this.btnModifica);
            this.groupBox3.Location = new System.Drawing.Point(6, 275);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(650, 181);
            this.groupBox3.TabIndex = 45;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Associazione delle causale di costo/debito alla prestazione";
            // 
            // detailgrid
            // 
            this.detailgrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.detailgrid.CaptionVisible = false;
            this.detailgrid.DataMember = "";
            this.detailgrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.detailgrid.Location = new System.Drawing.Point(96, 19);
            this.detailgrid.Name = "detailgrid";
            this.detailgrid.Size = new System.Drawing.Size(548, 154);
            this.detailgrid.TabIndex = 45;
            this.detailgrid.Tag = "taxmotiveyear.default.single";
            // 
            // btnInserisci
            // 
            this.btnInserisci.Location = new System.Drawing.Point(6, 16);
            this.btnInserisci.Name = "btnInserisci";
            this.btnInserisci.Size = new System.Drawing.Size(80, 22);
            this.btnInserisci.TabIndex = 42;
            this.btnInserisci.TabStop = false;
            this.btnInserisci.Tag = "insert.single";
            this.btnInserisci.Text = "Inserisci";
            // 
            // btnElimina
            // 
            this.btnElimina.Location = new System.Drawing.Point(6, 80);
            this.btnElimina.Name = "btnElimina";
            this.btnElimina.Size = new System.Drawing.Size(80, 22);
            this.btnElimina.TabIndex = 44;
            this.btnElimina.TabStop = false;
            this.btnElimina.Tag = "delete";
            this.btnElimina.Text = "Elimina";
            // 
            // btnModifica
            // 
            this.btnModifica.Location = new System.Drawing.Point(6, 48);
            this.btnModifica.Name = "btnModifica";
            this.btnModifica.Size = new System.Drawing.Size(80, 22);
            this.btnModifica.TabIndex = 43;
            this.btnModifica.TabStop = false;
            this.btnModifica.Tag = "edit.single";
            this.btnModifica.Text = "Modifica";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(4, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(184, 16);
            this.label4.TabIndex = 40;
            this.label4.Text = "Ritenuta per Liquidazione:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbMainTax
            // 
            this.cmbMainTax.DataSource = this.DS.maintax;
            this.cmbMainTax.DisplayMember = "description";
            this.cmbMainTax.Location = new System.Drawing.Point(198, 39);
            this.cmbMainTax.Name = "cmbMainTax";
            this.cmbMainTax.Size = new System.Drawing.Size(288, 21);
            this.cmbMainTax.TabIndex = 39;
            this.cmbMainTax.Tag = "tax.maintaxcode";
            this.cmbMainTax.ValueMember = "taxcode";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 16);
            this.label2.TabIndex = 32;
            this.label2.Text = "Descrizione:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCodiceRitenuta
            // 
            this.txtCodiceRitenuta.Location = new System.Drawing.Point(198, 14);
            this.txtCodiceRitenuta.Name = "txtCodiceRitenuta";
            this.txtCodiceRitenuta.Size = new System.Drawing.Size(288, 20);
            this.txtCodiceRitenuta.TabIndex = 26;
            this.txtCodiceRitenuta.Tag = "tax.taxref";
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Location = new System.Drawing.Point(198, 66);
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(288, 20);
            this.txtDescrizione.TabIndex = 27;
            this.txtDescrizione.Tag = "tax.description";
            // 
            // cmbImponibile
            // 
            this.cmbImponibile.DataSource = this.DS.taxablekind;
            this.cmbImponibile.DisplayMember = "description";
            this.cmbImponibile.Location = new System.Drawing.Point(198, 114);
            this.cmbImponibile.Name = "cmbImponibile";
            this.cmbImponibile.Size = new System.Drawing.Size(288, 21);
            this.cmbImponibile.TabIndex = 35;
            this.cmbImponibile.Tag = "tax.taxablecode";
            this.cmbImponibile.ValueMember = "taxablecode";
            // 
            // txtCodiceTributo
            // 
            this.txtCodiceTributo.Location = new System.Drawing.Point(198, 90);
            this.txtCodiceTributo.Name = "txtCodiceTributo";
            this.txtCodiceTributo.Size = new System.Drawing.Size(112, 20);
            this.txtCodiceTributo.TabIndex = 28;
            this.txtCodiceTributo.Tag = "tax.fiscaltaxcode";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 16);
            this.label1.TabIndex = 31;
            this.label1.Text = "Codice  Ritenuta:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(86, 114);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 23);
            this.button1.TabIndex = 34;
            this.button1.Tag = "manage.taxablekind.default";
            this.button1.Text = "Tipo Imponibile:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 28);
            this.label3.TabIndex = 33;
            this.label3.Text = "Codice tributo/Causale contributo a debito:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gboxCategoria
            // 
            this.gboxCategoria.Controls.Add(this.radioButton13);
            this.gboxCategoria.Controls.Add(this.radioButton5);
            this.gboxCategoria.Controls.Add(this.radioButton4);
            this.gboxCategoria.Controls.Add(this.radioButton3);
            this.gboxCategoria.Controls.Add(this.radioButton2);
            this.gboxCategoria.Controls.Add(this.radioButton1);
            this.gboxCategoria.Location = new System.Drawing.Point(518, 14);
            this.gboxCategoria.Name = "gboxCategoria";
            this.gboxCategoria.Size = new System.Drawing.Size(136, 160);
            this.gboxCategoria.TabIndex = 30;
            this.gboxCategoria.TabStop = false;
            this.gboxCategoria.Text = "Categoria";
            // 
            // radioButton13
            // 
            this.radioButton13.Location = new System.Drawing.Point(16, 112);
            this.radioButton13.Name = "radioButton13";
            this.radioButton13.Size = new System.Drawing.Size(88, 16);
            this.radioButton13.TabIndex = 5;
            this.radioButton13.Tag = "tax.taxkind:5";
            this.radioButton13.Text = "Arretrati";
            // 
            // radioButton5
            // 
            this.radioButton5.Location = new System.Drawing.Point(16, 88);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(88, 16);
            this.radioButton5.TabIndex = 4;
            this.radioButton5.Tag = "tax.taxkind:4";
            this.radioButton5.Text = "Assicurativa";
            // 
            // radioButton4
            // 
            this.radioButton4.Location = new System.Drawing.Point(16, 136);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(64, 16);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.Tag = "tax.taxkind:6";
            this.radioButton4.Text = "Altro";
            // 
            // radioButton3
            // 
            this.radioButton3.Location = new System.Drawing.Point(16, 64);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(96, 16);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Tag = "tax.taxkind:3";
            this.radioButton3.Text = "Previdenziale";
            // 
            // radioButton2
            // 
            this.radioButton2.Location = new System.Drawing.Point(16, 40);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(88, 16);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Tag = "tax.taxkind:2";
            this.radioButton2.Text = "Assistenziale";
            // 
            // radioButton1
            // 
            this.radioButton1.Location = new System.Drawing.Point(16, 16);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(64, 16);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Tag = "tax.taxkind:1";
            this.radioButton1.Text = "Fiscale";
            // 
            // grptipoapplicazione
            // 
            this.grptipoapplicazione.Controls.Add(this.radioButton9);
            this.grptipoapplicazione.Controls.Add(this.radioButton8);
            this.grptipoapplicazione.Controls.Add(this.radioButton7);
            this.grptipoapplicazione.Controls.Add(this.radioButton6);
            this.grptipoapplicazione.Location = new System.Drawing.Point(6, 166);
            this.grptipoapplicazione.Name = "grptipoapplicazione";
            this.grptipoapplicazione.Size = new System.Drawing.Size(392, 48);
            this.grptipoapplicazione.TabIndex = 36;
            this.grptipoapplicazione.TabStop = false;
            this.grptipoapplicazione.Text = "Tipo Applicazione Geografica";
            // 
            // radioButton9
            // 
            this.radioButton9.Location = new System.Drawing.Point(280, 16);
            this.radioButton9.Name = "radioButton9";
            this.radioButton9.Size = new System.Drawing.Size(104, 24);
            this.radioButton9.TabIndex = 3;
            this.radioButton9.Tag = "tax.geoappliance:C";
            this.radioButton9.Text = "Comunale";
            // 
            // radioButton8
            // 
            this.radioButton8.Location = new System.Drawing.Point(176, 16);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(104, 24);
            this.radioButton8.TabIndex = 2;
            this.radioButton8.Tag = "tax.geoappliance:P";
            this.radioButton8.Text = "Provinciale";
            // 
            // radioButton7
            // 
            this.radioButton7.Location = new System.Drawing.Point(80, 16);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(96, 24);
            this.radioButton7.TabIndex = 1;
            this.radioButton7.Tag = "tax.geoappliance:R";
            this.radioButton7.Text = "Regionale";
            // 
            // radioButton6
            // 
            this.radioButton6.Location = new System.Drawing.Point(8, 16);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(72, 24);
            this.radioButton6.TabIndex = 0;
            this.radioButton6.Tag = "tax.geoappliance:N";
            this.radioButton6.Text = "Nulla";
            // 
            // gboxApplicazione
            // 
            this.gboxApplicazione.Controls.Add(this.radioButton12);
            this.gboxApplicazione.Controls.Add(this.radioButton11);
            this.gboxApplicazione.Controls.Add(this.radioButton10);
            this.gboxApplicazione.Location = new System.Drawing.Point(6, 219);
            this.gboxApplicazione.Name = "gboxApplicazione";
            this.gboxApplicazione.Size = new System.Drawing.Size(280, 48);
            this.gboxApplicazione.TabIndex = 37;
            this.gboxApplicazione.TabStop = false;
            this.gboxApplicazione.Text = "Principio di Applicazione";
            // 
            // radioButton12
            // 
            this.radioButton12.Location = new System.Drawing.Point(208, 24);
            this.radioButton12.Name = "radioButton12";
            this.radioButton12.Size = new System.Drawing.Size(64, 16);
            this.radioButton12.TabIndex = 2;
            this.radioButton12.Tag = "tax.appliancebasis:S";
            this.radioButton12.Text = "Cassa";
            // 
            // radioButton11
            // 
            this.radioButton11.Location = new System.Drawing.Point(96, 20);
            this.radioButton11.Name = "radioButton11";
            this.radioButton11.Size = new System.Drawing.Size(104, 24);
            this.radioButton11.TabIndex = 1;
            this.radioButton11.Tag = "tax.appliancebasis:A";
            this.radioButton11.Text = "Cassa Allargato";
            // 
            // radioButton10
            // 
            this.radioButton10.Location = new System.Drawing.Point(8, 24);
            this.radioButton10.Name = "radioButton10";
            this.radioButton10.Size = new System.Drawing.Size(88, 16);
            this.radioButton10.TabIndex = 0;
            this.radioButton10.Tag = "tax.appliancebasis:C";
            this.radioButton10.Text = "Competenza";
            // 
            // chkIndetr
            // 
            this.chkIndetr.Location = new System.Drawing.Point(294, 251);
            this.chkIndetr.Name = "chkIndetr";
            this.chkIndetr.Size = new System.Drawing.Size(128, 16);
            this.chkIndetr.TabIndex = 29;
            this.chkIndetr.Tag = "tax.flagunabatable:S:N";
            this.chkIndetr.Text = "Ritenuta indetraibile";
            // 
            // chkAttivo
            // 
            this.chkAttivo.Location = new System.Drawing.Point(294, 227);
            this.chkAttivo.Name = "chkAttivo";
            this.chkAttivo.Size = new System.Drawing.Size(128, 16);
            this.chkAttivo.TabIndex = 38;
            this.chkAttivo.Tag = "tax.active:S:N";
            this.chkAttivo.Text = "Attiva";
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.dataGrid1);
            this.tabPage6.Controls.Add(this.button11);
            this.tabPage6.Controls.Add(this.button12);
            this.tabPage6.Controls.Add(this.button13);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(662, 461);
            this.tabPage6.TabIndex = 2;
            this.tabPage6.Text = "Classificazione";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(8, 47);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(650, 388);
            this.dataGrid1.TabIndex = 7;
            this.dataGrid1.Tag = "taxsorting.default.default";
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(184, 15);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(75, 23);
            this.button11.TabIndex = 6;
            this.button11.Tag = "delete";
            this.button11.Text = "Cancella";
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(96, 15);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(75, 23);
            this.button12.TabIndex = 5;
            this.button12.Tag = "edit.single";
            this.button12.Text = "Correggi";
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(8, 15);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(75, 23);
            this.button13.TabIndex = 4;
            this.button13.Tag = "insert.single";
            this.button13.Text = "Aggiungi";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(662, 461);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Causali su Bilancio";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.dataGrid2);
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Controls.Add(this.button4);
            this.groupBox4.Location = new System.Drawing.Point(6, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(653, 421);
            this.groupBox4.TabIndex = 46;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Associazione delle causali delle voci di bilancio alla prestazione";
            // 
            // dataGrid2
            // 
            this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid2.CaptionVisible = false;
            this.dataGrid2.DataMember = "";
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(96, 19);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.Size = new System.Drawing.Size(551, 394);
            this.dataGrid2.TabIndex = 45;
            this.dataGrid2.Tag = "taxfinmotive.default.single";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 22);
            this.button2.TabIndex = 42;
            this.button2.TabStop = false;
            this.button2.Tag = "insert.single";
            this.button2.Text = "Inserisci";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 80);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(80, 22);
            this.button3.TabIndex = 44;
            this.button3.TabStop = false;
            this.button3.Tag = "delete";
            this.button3.Text = "Elimina";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(6, 48);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(80, 22);
            this.button4.TabIndex = 43;
            this.button4.TabStop = false;
            this.button4.Tag = "edit.single";
            this.button4.Text = "Modifica";
            // 
            // Frm_tax_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(690, 502);
            this.Controls.Add(this.tabControl1);
            this.Name = "Frm_tax_default";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmtiporitenutalista";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.detailgrid)).EndInit();
            this.gboxCategoria.ResumeLayout(false);
            this.grptipoapplicazione.ResumeLayout(false);
            this.gboxApplicazione.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

	
	}
}