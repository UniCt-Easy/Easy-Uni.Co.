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
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using ep_functions;
using funzioni_configurazione;

namespace entry_default {
	/// <summary>
	/// Summary description for FrmEntry_default.
	/// </summary>
	public class FrmEntry_default : System.Windows.Forms.Form {
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtEsercizio;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtNumero;
		private System.Windows.Forms.TextBox txtDescrizione;
		private System.Windows.Forms.TextBox txtDataContabile;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtSaldo;
        private System.Windows.Forms.Label label8;
		public entry_default.vistaForm DS;
		private System.Windows.Forms.GroupBox groupBox19;
		private System.Windows.Forms.TextBox txtDocumento;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtDataDocumento;
        private System.Windows.Forms.Label label14;
        private Label label4;
        public ComboBox cmbEntryKind;
        MetaData Meta;
        DataAccess Conn;
        CQueryHelper QHC;
        QueryHelper QHS;
        DataTable tPlAccount;
        private DataGrid dataGrid2;
        private Button button2;
        private Button button3;
        private Button btnViewDoc;
        private CheckBox checkBox1;
        private TextBox txtTotDare;
        private Label label6;
        private TextBox txtTotAvere;
        private Label label7;
        private TabControl tabControl1;
        private TabPage tabPrincipale;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private Button btnEditRatei;
        private DataGrid dataGridRatei;
        private Button btnRatei;
        private Button btnDelRatei;
        private Button btnElimina;
        private DataGrid detailgrid;
        private Button btnModifica;
        private Button btnInserisci;
        private Label lblRateo;
        private TabPage tabAttributi;
        public GroupBox gboxclass05;
        public TextBox txtCodice05;
        public Button btnCodice05;
        private TextBox txtDenom05;
        public GroupBox gboxclass04;
        public TextBox txtCodice04;
        public Button btnCodice04;
        private TextBox txtDenom04;
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
        private CheckBox chkOfficial; 
   

		public FrmEntry_default() {
			InitializeComponent();

			DS.entrydetail.ExtendedProperties["ViewTable"]= DS.entrydetailview;
			DS.entrydetailview.ExtendedProperties["RealTable"]= DS.entrydetail;
            DS.upb.ExtendedProperties["ViewTable"] = DS.entrydetailview;
            DS.registry.ExtendedProperties["ViewTable"] = DS.entrydetailview;
            DS.account.ExtendedProperties["ViewTable"] = DS.entrydetailview;


			DS.entrydetailview.Columns["yentry"].ExtendedProperties["ViewSource"]="entrydetail.yentry";
			DS.entrydetailview.Columns["nentry"].ExtendedProperties["ViewSource"]="entrydetail.nentry";
			DS.entrydetailview.Columns["ndetail"].ExtendedProperties["ViewSource"] = "entrydetail.ndetail";
			DS.entrydetailview.Columns["idacc"].ExtendedProperties["ViewSource"] = "entrydetail.idacc";
			DS.entrydetailview.Columns["idreg"].ExtendedProperties["ViewSource"]="entrydetail.idreg";
			DS.entrydetailview.Columns["idupb"].ExtendedProperties["ViewSource"]="entrydetail.idupb";//<--
			DS.entrydetailview.Columns["idsor1"].ExtendedProperties["ViewSource"]="entrydetail.idsor1";//<--
			DS.entrydetailview.Columns["idsor2"].ExtendedProperties["ViewSource"]="entrydetail.idsor2";//<--
			DS.entrydetailview.Columns["idsor3"].ExtendedProperties["ViewSource"]="entrydetail.idsor3";//<--
			DS.entrydetailview.Columns["amount"].ExtendedProperties["ViewSource"]="entrydetail.amount";
            DS.entrydetailview.Columns["importcode"].ExtendedProperties["ViewSource"] = "entrydetail.importcode";
			DS.entrydetailview.Columns["detaildescription"].ExtendedProperties["ViewSource"]="entrydetail.description";
			DS.entrydetailview.Columns["idaccmotive"].ExtendedProperties["ViewSource"]="entrydetail.idaccmotive";
            DS.entrydetailview.Columns["competencystart"].ExtendedProperties["ViewSource"] = "entrydetail.competencystart";
            DS.entrydetailview.Columns["competencystop"].ExtendedProperties["ViewSource"] = "entrydetail.competencystop";
            DS.entrydetailview.Columns["autogenerated"].ExtendedProperties["ViewSource"] = "entrydetail.autogenerated";
            DS.entrydetailview.Columns["idrelateddetail"].ExtendedProperties["ViewSource"] = "entrydetail.idrelated";
            DS.entrydetailview.Columns["idepexp"].ExtendedProperties["ViewSource"] = "entrydetail.idepexp";
            DS.entrydetailview.Columns["idepacc"].ExtendedProperties["ViewSource"] = "entrydetail.idepacc";

            DS.entrydetailview.Columns["cu"].ExtendedProperties["ViewSource"]="entrydetail.cu";
			DS.entrydetailview.Columns["ct"].ExtendedProperties["ViewSource"]="entrydetail.ct";
			DS.entrydetailview.Columns["lu"].ExtendedProperties["ViewSource"]="entrydetail.lu";
			DS.entrydetailview.Columns["lt"].ExtendedProperties["ViewSource"]="entrydetail.lt";
		
			DS.entrydetailview.Columns["codeupb"].ExtendedProperties["ViewSource"]="upb.codeupb";
			DS.entrydetailview.Columns["upb"].ExtendedProperties["ViewSource"]="upb.title";
            DS.entrydetailview.Columns["idepupbkind"].ExtendedProperties["ViewSource"] = "upb.idepupbkind";

            
			DS.entrydetailview.Columns["registry"].ExtendedProperties["ViewSource"]="registry.title";

			DS.entrydetailview.Columns["account"].ExtendedProperties["ViewSource"]="account.title";
			DS.entrydetailview.Columns["codeacc"].ExtendedProperties["ViewSource"]="account.codeacc";
		    DS.entrydetailview.Columns["idplaccount"].ExtendedProperties["ViewSource"] = "account.idplaccount";
			DS.entrydetailview.Columns["idaccountkind"].ExtendedProperties["ViewSource"]="account.idaccountkind";
			DS.entrydetailview.Columns["flagregistry"].ExtendedProperties["ViewSource"]="account.flagregistry";
			DS.entrydetailview.Columns["flagupb"].ExtendedProperties["ViewSource"]="account.flagupb";


            DS.entrydetailaccrual.ExtendedProperties["gridmaster"] = "entrydetail";

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEsercizio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbEntryKind = new System.Windows.Forms.ComboBox();
            this.DS = new entry_default.vistaForm();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.txtDataContabile = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSaldo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDataDocumento = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.btnViewDoc = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txtTotDare = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTotAvere = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPrincipale = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEditRatei = new System.Windows.Forms.Button();
            this.dataGridRatei = new System.Windows.Forms.DataGrid();
            this.btnRatei = new System.Windows.Forms.Button();
            this.btnDelRatei = new System.Windows.Forms.Button();
            this.btnElimina = new System.Windows.Forms.Button();
            this.detailgrid = new System.Windows.Forms.DataGrid();
            this.btnModifica = new System.Windows.Forms.Button();
            this.btnInserisci = new System.Windows.Forms.Button();
            this.lblRateo = new System.Windows.Forms.Label();
            this.tabAttributi = new System.Windows.Forms.TabPage();
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
            this.chkOfficial = new System.Windows.Forms.CheckBox();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPrincipale.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRatei)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailgrid)).BeginInit();
            this.tabAttributi.SuspendLayout();
            this.gboxclass05.SuspendLayout();
            this.gboxclass04.SuspendLayout();
            this.gboxclass03.SuspendLayout();
            this.gboxclass02.SuspendLayout();
            this.gboxclass01.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtEsercizio);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtNumero);
            this.groupBox3.Location = new System.Drawing.Point(10, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(248, 62);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Scrittura";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(124, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Numero:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercizio
            // 
            this.txtEsercizio.Location = new System.Drawing.Point(68, 21);
            this.txtEsercizio.Name = "txtEsercizio";
            this.txtEsercizio.ReadOnly = true;
            this.txtEsercizio.Size = new System.Drawing.Size(48, 20);
            this.txtEsercizio.TabIndex = 1;
            this.txtEsercizio.TabStop = false;
            this.txtEsercizio.Tag = "entry.yentry.year";
            this.txtEsercizio.Text = "-";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Esercizio:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(188, 22);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(48, 20);
            this.txtNumero.TabIndex = 2;
            this.txtNumero.Tag = "entry.nentry";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(265, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 18);
            this.label4.TabIndex = 31;
            this.label4.Text = "Tipo ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbEntryKind
            // 
            this.cmbEntryKind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbEntryKind.DataSource = this.DS.entrykind;
            this.cmbEntryKind.DisplayMember = "description";
            this.cmbEntryKind.Location = new System.Drawing.Point(299, 47);
            this.cmbEntryKind.Name = "cmbEntryKind";
            this.cmbEntryKind.Size = new System.Drawing.Size(270, 21);
            this.cmbEntryKind.TabIndex = 3;
            this.cmbEntryKind.Tag = "entry.identrykind";
            this.cmbEntryKind.ValueMember = "identrykind";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Location = new System.Drawing.Point(11, 96);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(301, 67);
            this.txtDescrizione.TabIndex = 2;
            this.txtDescrizione.Tag = "entry.description";
            // 
            // txtDataContabile
            // 
            this.txtDataContabile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDataContabile.Location = new System.Drawing.Point(693, 167);
            this.txtDataContabile.Name = "txtDataContabile";
            this.txtDataContabile.Size = new System.Drawing.Size(88, 20);
            this.txtDataContabile.TabIndex = 5;
            this.txtDataContabile.Tag = "entry.adate";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Location = new System.Drawing.Point(596, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 22;
            this.label5.Text = "Data contabile:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(11, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 21;
            this.label2.Text = "Descrizione:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSaldo
            // 
            this.txtSaldo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSaldo.Location = new System.Drawing.Point(676, 49);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.ReadOnly = true;
            this.txtSaldo.Size = new System.Drawing.Size(104, 20);
            this.txtSaldo.TabIndex = 25;
            this.txtSaldo.TabStop = false;
            this.txtSaldo.Tag = "";
            this.txtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.Location = new System.Drawing.Point(614, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 16);
            this.label8.TabIndex = 24;
            this.label8.Text = "Saldo:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox19
            // 
            this.groupBox19.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox19.Controls.Add(this.txtDocumento);
            this.groupBox19.Controls.Add(this.label10);
            this.groupBox19.Controls.Add(this.txtDataDocumento);
            this.groupBox19.Controls.Add(this.label14);
            this.groupBox19.Location = new System.Drawing.Point(321, 95);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(459, 44);
            this.groupBox19.TabIndex = 4;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "Documento collegato";
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(92, 16);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(200, 20);
            this.txtDocumento.TabIndex = 1;
            this.txtDocumento.Tag = "entry.doc";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(6, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 18);
            this.label10.TabIndex = 0;
            this.label10.Text = "Descrizione";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDataDocumento
            // 
            this.txtDataDocumento.Location = new System.Drawing.Point(384, 16);
            this.txtDataDocumento.Name = "txtDataDocumento";
            this.txtDataDocumento.Size = new System.Drawing.Size(72, 20);
            this.txtDataDocumento.TabIndex = 2;
            this.txtDataDocumento.Tag = "entry.docdate";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(314, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 18);
            this.label14.TabIndex = 0;
            this.label14.Text = "Data";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(11, 18);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(72, 24);
            this.button2.TabIndex = 32;
            this.button2.Tag = "edit.single";
            this.button2.Text = "Modifica";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(89, 18);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(72, 24);
            this.button3.TabIndex = 33;
            this.button3.Tag = "delete";
            this.button3.Text = "Elimina";
            // 
            // dataGrid2
            // 
            this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid2.DataMember = "";
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(11, 54);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.Size = new System.Drawing.Size(596, 312);
            this.dataGrid2.TabIndex = 30;
            this.dataGrid2.Tag = "entrydetailaccrual.default.single";
            // 
            // btnViewDoc
            // 
            this.btnViewDoc.Location = new System.Drawing.Point(268, 15);
            this.btnViewDoc.Name = "btnViewDoc";
            this.btnViewDoc.Size = new System.Drawing.Size(161, 23);
            this.btnViewDoc.TabIndex = 42;
            this.btnViewDoc.TabStop = false;
            this.btnViewDoc.Text = "Vedi documento principale";
            this.btnViewDoc.UseVisualStyleBackColor = true;
            this.btnViewDoc.Click += new System.EventHandler(this.btnViewDoc_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.TopRight;
            this.checkBox1.Location = new System.Drawing.Point(709, 15);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(68, 17);
            this.checkBox1.TabIndex = 344;
            this.checkBox1.TabStop = false;
            this.checkBox1.Tag = "entry.locked:S:N";
            this.checkBox1.Text = "Bloccata";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // txtTotDare
            // 
            this.txtTotDare.Location = new System.Drawing.Point(397, 142);
            this.txtTotDare.Name = "txtTotDare";
            this.txtTotDare.ReadOnly = true;
            this.txtTotDare.Size = new System.Drawing.Size(104, 20);
            this.txtTotDare.TabIndex = 46;
            this.txtTotDare.TabStop = false;
            this.txtTotDare.Tag = "";
            this.txtTotDare.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(321, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 16);
            this.label6.TabIndex = 45;
            this.label6.Text = "Totale Dare";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTotAvere
            // 
            this.txtTotAvere.Location = new System.Drawing.Point(619, 142);
            this.txtTotAvere.Name = "txtTotAvere";
            this.txtTotAvere.ReadOnly = true;
            this.txtTotAvere.Size = new System.Drawing.Size(104, 20);
            this.txtTotAvere.TabIndex = 48;
            this.txtTotAvere.TabStop = false;
            this.txtTotAvere.Tag = "";
            this.txtTotAvere.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(544, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 16);
            this.label7.TabIndex = 47;
            this.label7.Text = "Totale Avere";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPrincipale);
            this.tabControl1.Controls.Add(this.tabAttributi);
            this.tabControl1.Location = new System.Drawing.Point(2, 180);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(779, 304);
            this.tabControl1.TabIndex = 345;
            // 
            // tabPrincipale
            // 
            this.tabPrincipale.Controls.Add(this.groupBox2);
            this.tabPrincipale.Location = new System.Drawing.Point(4, 22);
            this.tabPrincipale.Name = "tabPrincipale";
            this.tabPrincipale.Padding = new System.Windows.Forms.Padding(3);
            this.tabPrincipale.Size = new System.Drawing.Size(771, 278);
            this.tabPrincipale.TabIndex = 0;
            this.tabPrincipale.Text = "Principale";
            this.tabPrincipale.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.btnElimina);
            this.groupBox2.Controls.Add(this.detailgrid);
            this.groupBox2.Controls.Add(this.btnModifica);
            this.groupBox2.Controls.Add(this.btnInserisci);
            this.groupBox2.Controls.Add(this.lblRateo);
            this.groupBox2.Location = new System.Drawing.Point(-3, -8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(777, 294);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnEditRatei);
            this.groupBox1.Controls.Add(this.dataGridRatei);
            this.groupBox1.Controls.Add(this.btnRatei);
            this.groupBox1.Controls.Add(this.btnDelRatei);
            this.groupBox1.Location = new System.Drawing.Point(6, 170);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(766, 111);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ratei Associati";
            // 
            // btnEditRatei
            // 
            this.btnEditRatei.Location = new System.Drawing.Point(8, 49);
            this.btnEditRatei.Name = "btnEditRatei";
            this.btnEditRatei.Size = new System.Drawing.Size(72, 24);
            this.btnEditRatei.TabIndex = 38;
            this.btnEditRatei.Tag = "edit.default";
            this.btnEditRatei.Text = "Modifica";
            // 
            // dataGridRatei
            // 
            this.dataGridRatei.AllowNavigation = false;
            this.dataGridRatei.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridRatei.DataMember = "";
            this.dataGridRatei.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridRatei.Location = new System.Drawing.Point(89, 19);
            this.dataGridRatei.Name = "dataGridRatei";
            this.dataGridRatei.Size = new System.Drawing.Size(671, 86);
            this.dataGridRatei.TabIndex = 40;
            this.dataGridRatei.Tag = "entrydetailaccrual.default.default";
            // 
            // btnRatei
            // 
            this.btnRatei.Location = new System.Drawing.Point(8, 19);
            this.btnRatei.Name = "btnRatei";
            this.btnRatei.Size = new System.Drawing.Size(72, 24);
            this.btnRatei.TabIndex = 37;
            this.btnRatei.Tag = "insert.default";
            this.btnRatei.Text = "Inserisci";
            this.btnRatei.UseVisualStyleBackColor = true;
            // 
            // btnDelRatei
            // 
            this.btnDelRatei.Location = new System.Drawing.Point(8, 79);
            this.btnDelRatei.Name = "btnDelRatei";
            this.btnDelRatei.Size = new System.Drawing.Size(72, 24);
            this.btnDelRatei.TabIndex = 39;
            this.btnDelRatei.Tag = "delete";
            this.btnDelRatei.Text = "Elimina";
            // 
            // btnElimina
            // 
            this.btnElimina.Location = new System.Drawing.Point(14, 95);
            this.btnElimina.Name = "btnElimina";
            this.btnElimina.Size = new System.Drawing.Size(72, 24);
            this.btnElimina.TabIndex = 3;
            this.btnElimina.Tag = "delete";
            this.btnElimina.Text = "Elimina";
            // 
            // detailgrid
            // 
            this.detailgrid.AllowNavigation = false;
            this.detailgrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.detailgrid.DataMember = "";
            this.detailgrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.detailgrid.Location = new System.Drawing.Point(95, 35);
            this.detailgrid.Name = "detailgrid";
            this.detailgrid.Size = new System.Drawing.Size(672, 136);
            this.detailgrid.TabIndex = 29;
            this.detailgrid.Tag = "entrydetail.default.single";
            // 
            // btnModifica
            // 
            this.btnModifica.Location = new System.Drawing.Point(14, 65);
            this.btnModifica.Name = "btnModifica";
            this.btnModifica.Size = new System.Drawing.Size(72, 24);
            this.btnModifica.TabIndex = 2;
            this.btnModifica.Tag = "edit.single";
            this.btnModifica.Text = "Modifica";
            // 
            // btnInserisci
            // 
            this.btnInserisci.Location = new System.Drawing.Point(14, 35);
            this.btnInserisci.Name = "btnInserisci";
            this.btnInserisci.Size = new System.Drawing.Size(72, 24);
            this.btnInserisci.TabIndex = 1;
            this.btnInserisci.Tag = "insert.single";
            this.btnInserisci.Text = "Inserisci";
            // 
            // lblRateo
            // 
            this.lblRateo.AutoSize = true;
            this.lblRateo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRateo.ForeColor = System.Drawing.Color.Red;
            this.lblRateo.Location = new System.Drawing.Point(10, 16);
            this.lblRateo.Name = "lblRateo";
            this.lblRateo.Size = new System.Drawing.Size(353, 13);
            this.lblRateo.TabIndex = 34;
            this.lblRateo.Text = "Attenzione: ad alcuni conti potrebbe essere necessario associare dei ratei";
            this.lblRateo.Visible = false;
            // 
            // tabAttributi
            // 
            this.tabAttributi.Controls.Add(this.gboxclass05);
            this.tabAttributi.Controls.Add(this.gboxclass04);
            this.tabAttributi.Controls.Add(this.gboxclass03);
            this.tabAttributi.Controls.Add(this.gboxclass02);
            this.tabAttributi.Controls.Add(this.gboxclass01);
            this.tabAttributi.Location = new System.Drawing.Point(4, 22);
            this.tabAttributi.Name = "tabAttributi";
            this.tabAttributi.Padding = new System.Windows.Forms.Padding(3);
            this.tabAttributi.Size = new System.Drawing.Size(771, 278);
            this.tabAttributi.TabIndex = 1;
            this.tabAttributi.Text = "Attributi";
            this.tabAttributi.UseVisualStyleBackColor = true;
            // 
            // gboxclass05
            // 
            this.gboxclass05.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxclass05.Controls.Add(this.txtCodice05);
            this.gboxclass05.Controls.Add(this.btnCodice05);
            this.gboxclass05.Controls.Add(this.txtDenom05);
            this.gboxclass05.Location = new System.Drawing.Point(350, 85);
            this.gboxclass05.Name = "gboxclass05";
            this.gboxclass05.Size = new System.Drawing.Size(416, 64);
            this.gboxclass05.TabIndex = 28;
            this.gboxclass05.TabStop = false;
            this.gboxclass05.Tag = "";
            this.gboxclass05.Text = "Classificazione 5";
            // 
            // txtCodice05
            // 
            this.txtCodice05.Location = new System.Drawing.Point(9, 38);
            this.txtCodice05.Name = "txtCodice05";
            this.txtCodice05.Size = new System.Drawing.Size(179, 20);
            this.txtCodice05.TabIndex = 6;
            // 
            // btnCodice05
            // 
            this.btnCodice05.Location = new System.Drawing.Point(8, 14);
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
            this.txtDenom05.Location = new System.Drawing.Point(194, 8);
            this.txtDenom05.Multiline = true;
            this.txtDenom05.Name = "txtDenom05";
            this.txtDenom05.ReadOnly = true;
            this.txtDenom05.Size = new System.Drawing.Size(214, 52);
            this.txtDenom05.TabIndex = 3;
            this.txtDenom05.TabStop = false;
            this.txtDenom05.Tag = "sorting05.description";
            // 
            // gboxclass04
            // 
            this.gboxclass04.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxclass04.Controls.Add(this.txtCodice04);
            this.gboxclass04.Controls.Add(this.btnCodice04);
            this.gboxclass04.Controls.Add(this.txtDenom04);
            this.gboxclass04.Location = new System.Drawing.Point(349, 15);
            this.gboxclass04.Name = "gboxclass04";
            this.gboxclass04.Size = new System.Drawing.Size(416, 64);
            this.gboxclass04.TabIndex = 27;
            this.gboxclass04.TabStop = false;
            this.gboxclass04.Tag = "";
            this.gboxclass04.Text = "Classificazione 4";
            // 
            // txtCodice04
            // 
            this.txtCodice04.Location = new System.Drawing.Point(9, 38);
            this.txtCodice04.Name = "txtCodice04";
            this.txtCodice04.Size = new System.Drawing.Size(180, 20);
            this.txtCodice04.TabIndex = 6;
            // 
            // btnCodice04
            // 
            this.btnCodice04.Location = new System.Drawing.Point(8, 14);
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
            this.txtDenom04.Location = new System.Drawing.Point(195, 12);
            this.txtDenom04.Multiline = true;
            this.txtDenom04.Name = "txtDenom04";
            this.txtDenom04.ReadOnly = true;
            this.txtDenom04.Size = new System.Drawing.Size(213, 46);
            this.txtDenom04.TabIndex = 3;
            this.txtDenom04.TabStop = false;
            this.txtDenom04.Tag = "sorting04.description";
            // 
            // gboxclass03
            // 
            this.gboxclass03.Controls.Add(this.txtCodice03);
            this.gboxclass03.Controls.Add(this.btnCodice03);
            this.gboxclass03.Controls.Add(this.txtDenom03);
            this.gboxclass03.Location = new System.Drawing.Point(6, 155);
            this.gboxclass03.Name = "gboxclass03";
            this.gboxclass03.Size = new System.Drawing.Size(338, 64);
            this.gboxclass03.TabIndex = 25;
            this.gboxclass03.TabStop = false;
            this.gboxclass03.Tag = "";
            this.gboxclass03.Text = "Classificazione 3";
            // 
            // txtCodice03
            // 
            this.txtCodice03.Location = new System.Drawing.Point(8, 38);
            this.txtCodice03.Name = "txtCodice03";
            this.txtCodice03.Size = new System.Drawing.Size(170, 20);
            this.txtCodice03.TabIndex = 6;
            // 
            // btnCodice03
            // 
            this.btnCodice03.Location = new System.Drawing.Point(8, 14);
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
            this.txtDenom03.Location = new System.Drawing.Point(186, 8);
            this.txtDenom03.Multiline = true;
            this.txtDenom03.Name = "txtDenom03";
            this.txtDenom03.ReadOnly = true;
            this.txtDenom03.Size = new System.Drawing.Size(144, 52);
            this.txtDenom03.TabIndex = 3;
            this.txtDenom03.TabStop = false;
            this.txtDenom03.Tag = "sorting03.description";
            // 
            // gboxclass02
            // 
            this.gboxclass02.Controls.Add(this.txtCodice02);
            this.gboxclass02.Controls.Add(this.btnCodice02);
            this.gboxclass02.Controls.Add(this.txtDenom02);
            this.gboxclass02.Location = new System.Drawing.Point(6, 85);
            this.gboxclass02.Name = "gboxclass02";
            this.gboxclass02.Size = new System.Drawing.Size(338, 64);
            this.gboxclass02.TabIndex = 26;
            this.gboxclass02.TabStop = false;
            this.gboxclass02.Tag = "";
            this.gboxclass02.Text = "Classificazione 2";
            // 
            // txtCodice02
            // 
            this.txtCodice02.Location = new System.Drawing.Point(8, 38);
            this.txtCodice02.Name = "txtCodice02";
            this.txtCodice02.Size = new System.Drawing.Size(170, 20);
            this.txtCodice02.TabIndex = 6;
            // 
            // btnCodice02
            // 
            this.btnCodice02.Location = new System.Drawing.Point(8, 14);
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
            this.txtDenom02.Location = new System.Drawing.Point(186, 8);
            this.txtDenom02.Multiline = true;
            this.txtDenom02.Name = "txtDenom02";
            this.txtDenom02.ReadOnly = true;
            this.txtDenom02.Size = new System.Drawing.Size(144, 52);
            this.txtDenom02.TabIndex = 3;
            this.txtDenom02.TabStop = false;
            this.txtDenom02.Tag = "sorting02.description";
            // 
            // gboxclass01
            // 
            this.gboxclass01.Controls.Add(this.txtCodice01);
            this.gboxclass01.Controls.Add(this.btnCodice01);
            this.gboxclass01.Controls.Add(this.txtDenom01);
            this.gboxclass01.Location = new System.Drawing.Point(6, 15);
            this.gboxclass01.Name = "gboxclass01";
            this.gboxclass01.Size = new System.Drawing.Size(338, 64);
            this.gboxclass01.TabIndex = 24;
            this.gboxclass01.TabStop = false;
            this.gboxclass01.Tag = "";
            this.gboxclass01.Text = "Classificazione 1";
            // 
            // txtCodice01
            // 
            this.txtCodice01.Location = new System.Drawing.Point(7, 40);
            this.txtCodice01.Name = "txtCodice01";
            this.txtCodice01.Size = new System.Drawing.Size(171, 20);
            this.txtCodice01.TabIndex = 5;
            // 
            // btnCodice01
            // 
            this.btnCodice01.Location = new System.Drawing.Point(8, 16);
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
            this.txtDenom01.Location = new System.Drawing.Point(186, 8);
            this.txtDenom01.Multiline = true;
            this.txtDenom01.Name = "txtDenom01";
            this.txtDenom01.ReadOnly = true;
            this.txtDenom01.Size = new System.Drawing.Size(144, 52);
            this.txtDenom01.TabIndex = 3;
            this.txtDenom01.TabStop = false;
            this.txtDenom01.Tag = "sorting01.description";
            // 
            // chkOfficial
            // 
            this.chkOfficial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkOfficial.AutoSize = true;
            this.chkOfficial.CheckAlign = System.Drawing.ContentAlignment.TopRight;
            this.chkOfficial.Location = new System.Drawing.Point(619, 15);
            this.chkOfficial.Name = "chkOfficial";
            this.chkOfficial.Size = new System.Drawing.Size(64, 17);
            this.chkOfficial.TabIndex = 346;
            this.chkOfficial.TabStop = false;
            this.chkOfficial.Tag = "entry.official:S:N";
            this.chkOfficial.Text = "Ufficiale";
            this.chkOfficial.UseVisualStyleBackColor = true;
            // 
            // FrmEntry_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(788, 487);
            this.Controls.Add(this.chkOfficial);
            this.Controls.Add(this.txtTotAvere);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTotDare);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnViewDoc);
            this.Controls.Add(this.txtSaldo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbEntryKind);
            this.Controls.Add(this.txtDescrizione);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDataContabile);
            this.Controls.Add(this.groupBox19);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmEntry_default";
            this.Text = "FrmEntry_default";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox19.ResumeLayout(false);
            this.groupBox19.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPrincipale.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRatei)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailgrid)).EndInit();
            this.tabAttributi.ResumeLayout(false);
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
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        object idaccount_rateopassivo;
        object idaccount_rateoattivo;
        public void MetaData_AfterActivation()
        {
            btnRatei.BackColor = formcolors.GridButtonBackColor();
            btnRatei.ForeColor = formcolors.GridButtonForeColor();
            btnEditRatei.BackColor = formcolors.GridButtonBackColor();
            btnEditRatei.ForeColor = formcolors.GridButtonForeColor();
            btnDelRatei.BackColor = formcolors.GridButtonBackColor();
            btnDelRatei.ForeColor = formcolors.GridButtonForeColor();

            DataRow rSetup = DS.config.Rows[0];

            idaccount_rateopassivo = rSetup["idacc_accruedcost"];
            idaccount_rateoattivo = rSetup["idacc_accruedrevenue"];

        }

        public void MetaData_BeforeFill() {
            RicalcolaRatei();
            //AggiustaDateCompetenzaScrittureConRateiAssociati();
        }
        
        bool isUpbPluriennale(object idupb) {
            if (idupb == null || idupb == DBNull.Value) return false;
            DataRow[] found = DS.upb.Select(QHC.CmpEq("idupb", idupb));
            object idepupbkind = DBNull.Value;
            if (found.Length > 0) {
                idepupbkind = found[0]["idepupbkind"];
            }
            else {
                idepupbkind = Conn.DO_READ_VALUE("upb", QHS.CmpEq("idupb", idupb), "idepupbkind");
                if (idepupbkind == null) idepupbkind = DBNull.Value;
            }
            return (idepupbkind != DBNull.Value);
            
        }

        //Porta indietro la data inizio competenza scrittura se uno cancella un rateo (alla data inizio del rateo che sto cancellando)
        //Porta avanti la data inizio competenza scrittura se uno aggiunge un rateo (all'1/1 dell'anno successivo al rateo che sto aggiungendo)        
        void AggiustaDateCompetenzaScrittureConRateiAssociati() {
            //Rimette a posto la data inizio competenza nella scrittura principale se uno sta cancellando dei ratei associati
            foreach (DataRow RRateo in DS.entrydetailaccrual.Rows) {
                if (RRateo.RowState != DataRowState.Deleted) continue;
                string filter = QHS.AppAnd(QHS.CmpEq("yentry", RRateo["yentrylinked",DataRowVersion.Original]),
                                QHS.CmpEq("nentry", RRateo["nentrylinked", DataRowVersion.Original]),
                                QHS.CmpEq("ndetail", RRateo["ndetaillinked", DataRowVersion.Original]));
                object datestartrateo = Conn.DO_READ_VALUE("entrydetail", filter, "competencystart");
                if (datestartrateo == null || datestartrateo == DBNull.Value) continue;
                DateTime CStartRateo = (DateTime)datestartrateo;


                string cfilter = QHC.MCmp(RRateo, new string[] { "yentry", "nentry", "ndetail" });
                DataRow[] myR = DS.entrydetail.Select(cfilter);
                if (myR.Length == 0) continue;
                DataRow CurrDet = myR[0];

                object datestartdet = CurrDet["competencystart"];
                object datestart_original = datestartdet;
                if (CurrDet.RowState == DataRowState.Modified) {
                    datestart_original = CurrDet["competencystart", DataRowVersion.Original];
                    if (datestart_original == DBNull.Value) datestart_original = CStartRateo;
                }
                if (CStartRateo > (DateTime)datestart_original) CStartRateo = (DateTime)datestart_original;

                if (datestartdet == null || datestartdet == DBNull.Value) {
                    CurrDet["competencystart"] = CStartRateo;
                    continue;
                }
                DateTime CStartDet = (DateTime)datestartdet;
                if (CStartDet.CompareTo(CStartRateo) > 0) {//occhio: qui c'è il GREATER THAN
                    myR[0]["competencystart"] = CStartRateo;
                }

            }


            //Sposta in avanti la data inizio competenza se uno sta aggiungendo dei ratei associati
            //la data è posta al 1/1 dell'anno successivo alla data fine del rateo associato sempre se non è già superiore a quel valore
            foreach (DataRow RRateo in DS.entrydetailaccrual.Select()) {
                if (RRateo.RowState != DataRowState.Added) continue;

                string filter = QHS.AppAnd(QHS.CmpEq("yentry", RRateo["yentrylinked"]),
                                QHS.CmpEq("nentry", RRateo["nentrylinked"]),
                                QHS.CmpEq("ndetail", RRateo["ndetaillinked"]));
                object datestartrateo = Conn.DO_READ_VALUE("entrydetail", filter, "competencystop");
                if (datestartrateo == null || datestartrateo == DBNull.Value) continue;
                DateTime CStartRateo = (DateTime)datestartrateo;
                CStartRateo = new DateTime(CStartRateo.Year + 1, 1, 1);

                string cfilter = QHC.MCmp(RRateo, new string[] { "yentry", "nentry", "ndetail" });
                DataRow[] myR = DS.entrydetail.Select(cfilter);
                if (myR.Length == 0) continue;
                object datestartdet = myR[0]["competencystart"];
                if (datestartdet == null || datestartdet == DBNull.Value) {
                    myR[0]["competencystart"] = CStartRateo;
                    continue;
                }
                DateTime CStartDet = (DateTime)datestartdet;
                if (CStartDet.CompareTo(CStartRateo) < 0) {  //occhio: qui c'è il LESS THAN
                    myR[0]["competencystart"] = CStartRateo;
                }

            }
        }


		public void MetaData_AfterFill() {
            if (DS.entry.Rows.Count > 0) {
                DataRow Curr = DS.entry.Rows[0];
                if (Curr["idrelated"] == DBNull.Value) {
                    btnViewDoc.Visible = false;
                }
                else {
                    btnViewDoc.Visible = true;
                }
            }

			decimal somma_dare=MetaData.SumColumn(DS.entrydetail, "!dare");
			decimal somma_avere=MetaData.SumColumn(DS.entrydetail, "!avere");
			decimal saldo=somma_avere-somma_dare;
			txtSaldo.Text=saldo.ToString("c");
            txtTotAvere.Text = somma_avere.ToString("c");
            txtTotDare.Text = somma_dare.ToString("c");
            // Ricerca su dettagli che in base alla data inizio competenza,
            // dovrebbero 
            if ((Meta.EditMode || Meta.InsertMode))
            {
                lblRateo.Visible = VerificaRatei();
                btnRatei.Visible = AbilitaRatei();
                DataTable T;
                DataRow Curr;

                bool res = Meta.myHelpForm.GetCurrentRow(detailgrid, out T, out Curr);
                if (Curr == null) return;
              
                MetaData.SetDefault(DS.entrydetailaccrual, "yentry", Curr["yentry"]);
                MetaData.SetDefault(DS.entrydetailaccrual, "nentry", Curr["nentry"]);
                MetaData.SetDefault(DS.entrydetailaccrual, "ndetail",Curr["ndetail"]);
                if (CfgFn.GetNoNullDecimal(Curr["amount"]) > 0)
                {
                    MetaData.SetDefault(DS.entrydetailaccrual, "amount", CfgFn.GetNoNullDecimal(Curr["amount"]));
                }
                else
                {
                    MetaData.SetDefault(DS.entrydetailaccrual, "amount", -CfgFn.GetNoNullDecimal(Curr["amount"]));
                }

            }

		}

        //Verifica se ci sono scritture passibili di scelta del rateo 
        private bool VerificaRatei()
        {
            object adate;
           
            if (DS.entry.Rows.Count > 0)
            {
                adate = DS.entry.Rows[0]["adate"];
            }
            else return false;
            if (adate == DBNull.Value) return false;
            if (cmbEntryKind.SelectedIndex != 1) return false;
            DateTime dataContabile = (DateTime)adate;
            int esercContabile = dataContabile.Year;
            foreach (DataRow R in DS.entrydetail.Rows)
            {
                if (R.RowState == DataRowState.Deleted) continue;
                bool pluriennale = isUpbPluriennale(R["idupb"]);
                if (R["competencystart"] == DBNull.Value && !pluriennale) continue;

                string filterdetail = QHC.MCmp(R, new string[] { "yentry", "nentry", "ndetail" });
                DataRow[] Ratei = DS.entrydetailaccrual.Select(filterdetail);
                int num = Ratei.Length;

                if (pluriennale) {
                    if (num == 0)  return true;
                    continue;
                }

                DateTime inizioCompetenza = (DateTime)R["competencystart"];
                int esercCompetenza = inizioCompetenza.Year;
                if (esercCompetenza < esercContabile ) {
                    // Verifico l'esistenza di ratei associati a quel dettaglio
                    // ricerca nella tabella entrydetailaccrual
                    if (num == 0) return true;
                }                               
                
            }
            return false;
        }

        private bool AbilitaRatei() {
            if (DS.entry.Rows.Count == 0) return false;
            if (cmbEntryKind.SelectedIndex != 1) return false;
            DataRow RigaSelezionata = GetGridSelectedRows(detailgrid);
            if (RigaSelezionata == null) return false;
            DataRowState SelectedRowState = RigaSelezionata.RowState;
            if (SelectedRowState == DataRowState.Added) return false;
            object adate;
            object competencydate;

            if (DS.entry.Rows.Count == 0) {
                return false;
            }
            if (isUpbPluriennale(RigaSelezionata["idupb"])) {
                return true;
            }

            adate = DS.entry.Rows[0]["adate"];
            if (adate == DBNull.Value) return false;

            DateTime dataContabile = (DateTime)adate;
            int esercContabile = dataContabile.Year;
            competencydate = RigaSelezionata["competencystart"];
            if (competencydate == DBNull.Value) return false;

            DateTime inizioCompetenza = (DateTime)competencydate;
            int esercCompetenza = inizioCompetenza.Year;
            if (esercCompetenza < esercContabile) {
                return true;
            }

            string filterdetail = QHC.MCmp(RigaSelezionata, new string[] { "yentry", "nentry", "ndetail" });
            DataRow[] Ratei = DS.entrydetailaccrual.Select(filterdetail, null, DataViewRowState.Deleted);
            int num = Ratei.Length;
            if (num > 0) return true;
            Ratei = DS.entrydetailaccrual.Select(filterdetail, null, DataViewRowState.CurrentRows);
            num = Ratei.Length;
            if (num > 0) return true;

            return false;
        }


        private DataRow GetGridSelectedRows(DataGrid G)
        {
            DataSet DSV = (DataSet)G.DataSource;
            if (DSV == null) return null;
            DataTable TV = DSV.Tables[G.DataMember];
            if (TV == null) return null;

            if (TV.Rows.Count == 0) return null;
            DataRowView DV = null;
            try
            {
                DV = (DataRowView)G.BindingContext[DSV, TV.TableName].Current;
            }
            catch
            {
                DV = null;
            }
            if (DV == null) return null;

            DataRow R = DV.Row;
            return R;
        }


		public void  MetaData_AfterClear(){
			txtSaldo.Text="";
            txtTotAvere.Text = "";
            txtTotDare.Text = "";
            txtEsercizio.Text = Meta.GetSys("esercizio").ToString();
            btnViewDoc.Visible = false;
		}

	    public void MetaData_AfterPost() {
            MetaData.sendBroadcast(this, "EntrySaved");
        }

        public void MetaData_AfterLink()
        {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
            GetData.CacheTable(DS.entrykind, null, null, true);
            GetData.CacheTable(DS.config, QHS.CmpEq("ayear", Meta.GetSys("esercizio")), null, false);
            tPlAccount = DataAccess.CreateTableByName(Conn, "placcount", "idplaccount,nlevel,placcpart");
            HelpForm.SetDenyNull(DS.entry.Columns["locked"], true);
            HelpForm.SetDenyNull(DS.entry.Columns["official"], true);
            DataAccess.SetTableForReading(DS.sorting01, "sorting");
            DataAccess.SetTableForReading(DS.sorting02, "sorting");
            DataAccess.SetTableForReading(DS.sorting03, "sorting");
            DataAccess.SetTableForReading(DS.sorting04, "sorting");
            DataAccess.SetTableForReading(DS.sorting05, "sorting");

            DataTable tUniConfig = Conn.RUN_SELECT("uniconfig", "*", null,
                                                   null, null, null, true);
            if ((tUniConfig != null) && (tUniConfig.Rows.Count > 0)) {
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
                    idsorkind3 == DBNull.Value && idsorkind4 == DBNull.Value && idsorkind5 == DBNull.Value) {
                    tabControl1.TabPages.Remove(tabAttributi);
                }
            }
            Meta.CanInsertCopy = false;
        }

        public void MetaData_AfterRowSelect(DataTable T, DataRow R)
        {
            if (!Meta.DrawStateIsDone) return;

            if (T.TableName == "entrydetail")
            {
                btnRatei.Visible = AbilitaRatei();
                MetaData.SetDefault(DS.entrydetailaccrual, "yentry",  R["yentry"]);
                MetaData.SetDefault(DS.entrydetailaccrual, "nentry",  R["nentry"]);
                MetaData.SetDefault(DS.entrydetailaccrual, "ndetail", R["ndetail"]);
                if (CfgFn.GetNoNullDecimal(R["amount"]) >0)
                {
                    MetaData.SetDefault(DS.entrydetailaccrual, "amount", CfgFn.GetNoNullDecimal(R["amount"]));
                }
                else
                {
                    MetaData.SetDefault(DS.entrydetailaccrual, "amount", -CfgFn.GetNoNullDecimal(R["amount"]));
                }
            }
        }

        private void btnViewDoc_Click(object sender, EventArgs e) {
            if (DS.entry.Rows.Count == 0) return;
            DataRow Curr = DS.entry.Rows[0];
            EP_functions EP = new EP_functions(Meta.Dispatcher);
            EP.EditRelatedDocument(Meta, Curr);

        }
        
        /// <summary>
        /// Ricalcola le scritture sui ratei lasciando invariate quelle sui costi/ricavi
        /// </summary>
        void RicalcolaRatei() {
            if (Meta.IsEmpty) return;
            if (!DS.HasChanges()) return;
            if (DS.config.Rows.Count==0) return;
            if (DS.entry.Rows.Count == 0) return;

            if (DS.entrydetailaccrual.Select().Length == 0) return; //Se è una scrittura puramente manuale non fa nulla

            DataRow Curr = DS.entry.Rows[0];
            if (Curr["identrykind"].ToString() != "1") return;  //Funziona solo per scritture normali

            if (idaccount_rateopassivo == DBNull.Value) return;
            object oflagcompetencyPassivo = Conn.DO_READ_VALUE("account",
                                QHS.CmpEq("idacc", idaccount_rateopassivo),
                                "isnull(flagcompetency,'N')");
            string sflagcompetency_passivo = "";
            if (oflagcompetencyPassivo!=null) sflagcompetency_passivo= oflagcompetencyPassivo.ToString().ToUpper();
            bool flagcompetencyPassivo=sflagcompetency_passivo == "S";

            if (idaccount_rateoattivo == DBNull.Value) return;
            object oflagcompetency_attivo = Conn.DO_READ_VALUE("account",
                                QHS.CmpEq("idacc", idaccount_rateoattivo),
                                "isnull(flagcompetency,'N')");
            string sflagcompetency_attivo = "";
            if (oflagcompetency_attivo!=null) sflagcompetency_attivo=oflagcompetency_attivo.ToString().ToUpper();
            bool flagcompetencyAttivo = sflagcompetency_attivo == "S";
            int esercizio = Conn.GetEsercizio();
            
            //Azzera tutte le scritture sui ratei esistenti e quelle automatiche dei ratei pluriennali
            foreach (DataRow OldRateo in DS.entrydetail.Rows) {

                if (OldRateo.RowState == DataRowState.Deleted) {
                    if ((OldRateo["idacc", DataRowVersion.Original].Equals(idaccount_rateoattivo) ||
                        OldRateo["idacc", DataRowVersion.Original].Equals(idaccount_rateopassivo)) ||  // era &&, task 11454
                        OldRateo["autogenerated", DataRowVersion.Original].ToString().ToUpper()=="S"  
                        ) {
                        OldRateo.RejectChanges();
                        string filterAcc = QHC.CmpEq("idacc", OldRateo["idacc"]);
                        DataRow[] ContiRateo = DS.account.Select(filterAcc);
                        if (ContiRateo.Length == 0)
                        {
                            Conn.RUN_SELECT_INTO_TABLE(DS.account, null, QHS.CmpEq("idacc", OldRateo["idacc", DataRowVersion.Original]), null, false);
                        }
                        OldRateo["amount"] = 0;
                    }
                    continue;
                }
                if ((OldRateo["idacc"].Equals(idaccount_rateoattivo) ||
                    OldRateo["idacc"].Equals(idaccount_rateopassivo)) ||  // era &&, task 11454
                    OldRateo["autogenerated"].ToString().ToUpper() == "S"
                    ) {
                    OldRateo["amount"] = 0;
                   
                }
            }

            MetaData MetaDet = Meta.Dispatcher.Get("entrydetail");
            //Ricalcola le scritture sui ratei 
            foreach (DataRow RC in DS.entrydetail.Select()) {
                object idaccParentDetail = RC["idacc"];
                if (DS.account.Select(QHC.CmpEq("idacc", idaccParentDetail)).Length == 0) {
                    Conn.RUN_SELECT_INTO_TABLE(DS.account,null, QHS.CmpEq("idacc", idaccParentDetail), null, false);
                }
                if (DS.account.Select(QHC.CmpEq("idacc", idaccParentDetail)).Length == 0) {
                    MessageBox.Show($"Conto di chiave {idaccParentDetail} non trovato nella tabella account.",
                        "Errore nei dati");
                    return;
                }
                object idplaccount = DS.account.Select(QHC.CmpEq("idacc", idaccParentDetail))[0]["idplaccount"];
                object placcpart;
                ottieniInfoPlAccount(idplaccount, out placcpart);
                
                bool isRateoAttivo = true;//positivo
                if ((idplaccount == null) || (idplaccount == DBNull.Value)) {
                    //decimal curram = CfgFn.GetNoNullDecimal(RC["amount"]);
                    //if (curram < 0) isRateoAttivo = false;
                    //QueryCreator.MarkEvent($"ciclo 1 salto dettaglio {RC["description"]}");
                    continue;
                }
                else {
                    string C_R = placcpart.ToString().ToUpper();
                    if (C_R == "C") isRateoAttivo = false;
                    //QueryCreator.MarkEvent("rateo attivo:"+isRateoAttivo);
                }

                //Fa la somma dei ratei (entrydetailaccrual) ad esso collegati
                string filteraccrual = QueryCreator.WHERE_KEY_CLAUSE(RC, DataRowVersion.Current, false);
                DataRow[] Ratei = DS.entrydetailaccrual.Select(filteraccrual);
                
                foreach (DataRow Rateo in Ratei) {
                    decimal curr_rateo = CfgFn.GetNoNullDecimal(Rateo["amount"]);
                    if (!isRateoAttivo) curr_rateo = -curr_rateo;
                    bool use_competency = true;
                    object idaccount_rateo = DBNull.Value;
                    bool pluriennale= false;

                    //Se l'anno della scrittura collegata è l'anno attuale allora è un rateo relativo all'upb pluriennale
                    if (CfgFn.GetNoNullInt32( Rateo["yentrylinked"]) == esercizio) {
                        pluriennale= true;
                        object idepupbkind = Conn.DO_READ_VALUE("upb", QHS.CmpEq("idupb", RC["idupb"]), "idepupbkind");
                        if (idepupbkind != DBNull.Value && idepupbkind != null) {
                            idaccount_rateo = Conn.DO_READ_VALUE("epupbkindyear",
                                            QHS.AppAnd(QHS.CmpEq("idepupbkind", idepupbkind), QHS.CmpEq("ayear", esercizio)),
                                            "idacc_accruals");
                            if (idaccount_rateo != DBNull.Value && idaccount_rateo != null) {
                                object flagcompetency = Conn.DO_READ_VALUE("account", QHS.CmpEq("idacc", idaccount_rateo), "isnull(flagcompetency,'N')");
                                use_competency = (flagcompetency.ToString().ToUpper() == "S");
                            }
                        }
                    }
                    else {
                        if (isRateoAttivo ) {
                            idaccount_rateo = idaccount_rateoattivo;
                            use_competency = flagcompetencyAttivo;
                            //QueryCreator.MarkEvent("uso conto rateo attivo");
                        }
                        else {
                            idaccount_rateo = idaccount_rateopassivo;
                            use_competency = flagcompetencyPassivo;
                            //QueryCreator.MarkEvent("uso conto rateo passivo");
                        }
                    }

                    if (DS.account.Select(QHC.CmpEq("idacc", idaccount_rateo)).Length == 0) {
                        Conn.RUN_SELECT_INTO_TABLE(DS.account, null,
                            QHS.CmpEq("idacc", idaccount_rateo), null, false);
                    }

                    object c_start=DBNull.Value;
                    object c_stop=DBNull.Value;
                    string filterrateo = QHC.CmpEq("idacc", idaccount_rateo);

                    if (pluriennale) {
                        filterrateo = QHS.AppAnd(filterrateo, QHS.CmpEq("autogenerated", "S"));
                    }
                    else {
                        filterrateo = QHS.AppAnd(filterrateo, QHS.NullOrNe("autogenerated", "S"));
                    }
                    DataTable LinkedRateo = Conn.RUN_SELECT("entrydetail","*",null,
                                                QHS.AppAnd(QHS.CmpEq("yentry", Rateo["yentrylinked"]), 
                            QHS.CmpEq("nentry", Rateo["nentrylinked"]), QHS.CmpEq("ndetail", Rateo["ndetaillinked"])), null,false);

                    if (LinkedRateo.Rows.Count == 0) continue;

                    DataRow LR = LinkedRateo.Rows[0];

                    DataRow Rsource = pluriennale ? RC : LR;

                    if (use_competency) {
                        c_start = LR["competencystart"];
                        c_stop = LR["competencystop"]; 
                        filterrateo = QHC.AppAnd(filterrateo, QHC.CmpEq("competencystop", c_stop),
                                        QHC.CmpEq("competencystart",c_start),
                                        QHC.CmpEq("idupb", Rsource["idupb"]),
                                        QHC.CmpEq("idreg", Rsource["idreg"]),
                                        QHC.CmpEq("idepexp", Rsource["idepexp"]),
                        QHC.CmpEq("idsor1", Rsource["idsor1"]),
                        QHC.CmpEq("idsor2", Rsource["idsor2"]),
                        QHC.CmpEq("idsor3", Rsource["idsor3"])
                                        );
                    }
                    else {
                        filterrateo = QHC.AppAnd(filterrateo, QHC.CmpEq("idepacc", Rsource["idepacc"]));
                    }



                    //Non consideriamo UPB, idreg, idsor etc. che non hanno senso (credo) in questa circostanza
                    DataRow[] ArrRateoEsistente = DS.entrydetail.Select(filterrateo);
                    DataRow CurrRateo;
                    //Vede se esiste la scrittura sul rateo 
                    if (ArrRateoEsistente.Length > 0) {
                        CurrRateo = ArrRateoEsistente[0];
                    }
                    else {
                        DataRow RowParent = DS.entry.Rows[0];
                        MetaDet.SetDefaults(DS.entrydetail);
                        MetaData.SetDefault(DS.entrydetail, "idacc", idaccount_rateo);
                        CurrRateo = MetaDet.Get_New_Row(RowParent, DS.entrydetail);
                        MetaData.SetDefault(DS.entrydetail, "idacc", "");
                        if (pluriennale) {
                            CurrRateo["autogenerated"] = "S";
                        }
                        //solo in fase di creazione metto questi
                        foreach (string field in new string[] { "idreg", "idupb", "idsor1", "idsor2", "idsor3","idepexp","idepacc" })
                            CurrRateo[field] = Rsource[field];
                    }
                   
                    CurrRateo["competencystart"] = c_start;
                    CurrRateo["competencystop"] = c_stop;
                    CurrRateo["amount"] = CfgFn.GetNoNullDecimal(CurrRateo["amount"]) +CfgFn.GetNoNullDecimal(curr_rateo);
                    
                }
            }


            foreach (DataRow NewRateo in DS.entrydetail.Select()) {
                bool AutoGenCondition = true;
                if (!NewRateo["idacc"].Equals(idaccount_rateoattivo) &&
                    !NewRateo["idacc"].Equals(idaccount_rateopassivo) &&
                    NewRateo["autogenerated"].ToString().ToUpper()!="S"
                    ) continue;
                if (CfgFn.GetNoNullDecimal(NewRateo["amount"]) == 0) NewRateo.Delete();
            }

            //Ricalcola le scritture sui costi  / ricavi
            foreach (DataRow RC in DS.entrydetail.Select()) {
                if (DS.account.Select(QHC.CmpEq("idacc", RC["idacc"])).Length == 0) {
                    Conn.RUN_SELECT_INTO_TABLE(DS.account, null,
                        QHS.CmpEq("idacc", RC["idacc"]), null, false);
                }

                if (DS.account.Select(QHC.CmpEq("idacc", RC["idacc"])).Length == 0) {
                    MessageBox.Show($"Conto di chiave {RC["idacc"]} non trovato nella tabella account.",
                        "Errore nei dati");
                    return;
                }

                object idplaccount = DS.account.Select(QHC.CmpEq("idacc", RC["idacc"]))[0]["idplaccount"];
                object placcpart;
                ottieniInfoPlAccount(idplaccount, out placcpart);

                bool isRateoAttivo = true;//positivo
                if ((idplaccount == null) || (idplaccount == DBNull.Value)) {
                    //decimal curram = CfgFn.GetNoNullDecimal(RC["amount"]);
                    //if (curram < 0) isRateoAttivo = false;
                    //QueryCreator.MarkEvent($"ciclo 2 salto dettaglio {RC["description"]}");
                    continue;
                }
                else {
                    string C_R = placcpart.ToString().ToUpper();
                    if (C_R == "C") isRateoAttivo = false;
                }

                

                decimal importoprinc = CfgFn.GetNoNullDecimal(RC["amount"]);
                decimal oldrateo = 0;
                decimal newrateo = 0;

                //Fa la somma dei ratei OLD ad esso relativi
                string filteraccrual = QueryCreator.WHERE_KEY_CLAUSE(RC, DataRowVersion.Current, false);
                DataRow[] Ratei = DS.entrydetailaccrual.Select(filteraccrual,null,DataViewRowState.Added);
                foreach (DataRow Rateo in Ratei) newrateo += CfgFn.GetNoNullDecimal(Rateo["amount"]);

                Ratei = DS.entrydetailaccrual.Select(filteraccrual, null, DataViewRowState.Deleted);
                foreach (DataRow Rateo in Ratei) oldrateo += CfgFn.GetNoNullDecimal(Rateo["amount", DataRowVersion.Original]);

                Ratei = DS.entrydetailaccrual.Select(filteraccrual, null, DataViewRowState.ModifiedCurrent);
                foreach (DataRow Rateo in Ratei) oldrateo += CfgFn.GetNoNullDecimal(Rateo["amount", DataRowVersion.Original]);
                foreach (DataRow Rateo in Ratei) newrateo += CfgFn.GetNoNullDecimal(Rateo["amount", DataRowVersion.Current]);

                if (oldrateo == newrateo) continue;
                decimal diff = newrateo - oldrateo;
                decimal oldcostoricavo = CfgFn.GetNoNullDecimal( RC["amount", DataRowVersion.Original]);
                if (!isRateoAttivo) diff = - diff;
                decimal newcostoricavo = oldcostoricavo - diff;
                RC["amount"] = newcostoricavo;
                //MetaDet.CalculateFields(RC, "default");
            }
            Meta.myGetData.GetTemporaryValues(DS.entrydetail);

        }

        private void ottieniInfoPlAccount(object idplacc, out object placcpart) {
            placcpart = DBNull.Value;
            if ((idplacc == null) || (idplacc == DBNull.Value)) return;
            string filterC = QHC.CmpEq("idplaccount", idplacc);
            string filterSQL = QHS.CmpEq("idplaccount", idplacc);
            if (tPlAccount.Select(filterC).Length == 0) {
                DataAccess.RUN_SELECT_INTO_TABLE(Conn, tPlAccount, null, filterSQL, null, true);
            }
            if (tPlAccount.Select(filterC).Length == 0) return;
            DataRow rPlAccount = tPlAccount.Select(filterC)[0];
            placcpart = rPlAccount["placcpart"];
        }
	}
}