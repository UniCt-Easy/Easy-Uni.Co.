
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
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;//funzioni_configurazione

namespace storeunloaddetail_single
{
	/// <summary>
	/// Summary description for frmdettordinegenericosingle.
	/// </summary>
    public class Frm_storeunloaddetail_single : MetaDataForm {
		public object codiceresponsabile;
        CQueryHelper QHC;
        QueryHelper QHS;
		/// <summary>
		/// Required designer variable.
		/// </summary>
        private System.ComponentModel.Container components = null;
        public vistaForm DS;
        private Button btnAnnulla;
        private Button btnOK;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private GroupBox grpListino;
        private TextBox txtListino;
        private TextBox txtDescrizioneListino;
        private GroupBox gboxListClass;
        private CheckBox chkAttivo;
        private TextBox txtCodiceClass;
        private TextBox txtDescrListClass;
        private GroupBox groupBox2;
        private TextBox txtQuantitaConfezioni;
        private PictureBox pbox;
        private Label label4;
        private ComboBox cmbResponsabile;
        private GroupBox groupBox1;
        private Label label2;
        private ComboBox cmbTipoFattura;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private GroupBox grpRiga;
        private Label label14;
        private TextBox txtNumordine;
        private TextBox txtEsercordine;
        private GroupBox grpAnalitico;
        public GroupBox gboxclass1;
        public Button btnCodice1;
        private TextBox txtDenom1;
        private TextBox txtCodice1;
        public GroupBox gboxclass3;
        public Button btnCodice3;
        private TextBox txtDenom3;
        private TextBox txtCodice3;
        public GroupBox gboxclass2;
        public Button btnCodice2;
        private TextBox txtDenom2;
        private TextBox txtCodice2;
		MetaData Meta;

		public Frm_storeunloaddetail_single()
		{
            InitializeComponent();
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
            this.DS = new storeunloaddetail_single.vistaForm();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.grpListino = new System.Windows.Forms.GroupBox();
            this.txtListino = new System.Windows.Forms.TextBox();
            this.txtDescrizioneListino = new System.Windows.Forms.TextBox();
            this.gboxListClass = new System.Windows.Forms.GroupBox();
            this.chkAttivo = new System.Windows.Forms.CheckBox();
            this.txtCodiceClass = new System.Windows.Forms.TextBox();
            this.txtDescrListClass = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtQuantitaConfezioni = new System.Windows.Forms.TextBox();
            this.pbox = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbResponsabile = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTipoFattura = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.grpRiga = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtNumordine = new System.Windows.Forms.TextBox();
            this.txtEsercordine = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.grpAnalitico = new System.Windows.Forms.GroupBox();
            this.gboxclass1 = new System.Windows.Forms.GroupBox();
            this.btnCodice1 = new System.Windows.Forms.Button();
            this.txtDenom1 = new System.Windows.Forms.TextBox();
            this.txtCodice1 = new System.Windows.Forms.TextBox();
            this.gboxclass3 = new System.Windows.Forms.GroupBox();
            this.btnCodice3 = new System.Windows.Forms.Button();
            this.txtDenom3 = new System.Windows.Forms.TextBox();
            this.txtCodice3 = new System.Windows.Forms.TextBox();
            this.gboxclass2 = new System.Windows.Forms.GroupBox();
            this.btnCodice2 = new System.Windows.Forms.Button();
            this.txtDenom2 = new System.Windows.Forms.TextBox();
            this.txtCodice2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.grpListino.SuspendLayout();
            this.gboxListClass.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grpRiga.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.grpAnalitico.SuspendLayout();
            this.gboxclass1.SuspendLayout();
            this.gboxclass3.SuspendLayout();
            this.gboxclass2.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(487, 519);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 15;
            this.btnAnnulla.Text = "Annulla";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(403, 519);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 14;
            this.btnOK.Tag = "mainsave";
            this.btnOK.Text = "OK";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(10, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(553, 494);
            this.tabControl1.TabIndex = 44;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grpListino);
            this.tabPage1.Controls.Add(this.gboxListClass);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.pbox);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.cmbResponsabile);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.grpRiga);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(545, 468);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Principale";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // grpListino
            // 
            this.grpListino.Controls.Add(this.txtListino);
            this.grpListino.Controls.Add(this.txtDescrizioneListino);
            this.grpListino.Location = new System.Drawing.Point(15, 17);
            this.grpListino.Name = "grpListino";
            this.grpListino.Size = new System.Drawing.Size(316, 81);
            this.grpListino.TabIndex = 51;
            this.grpListino.TabStop = false;
            this.grpListino.Text = "Listino";
            // 
            // txtListino
            // 
            this.txtListino.Location = new System.Drawing.Point(6, 24);
            this.txtListino.Name = "txtListino";
            this.txtListino.ReadOnly = true;
            this.txtListino.Size = new System.Drawing.Size(113, 20);
            this.txtListino.TabIndex = 37;
            this.txtListino.Tag = "list.intcode";
            // 
            // txtDescrizioneListino
            // 
            this.txtDescrizioneListino.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizioneListino.Location = new System.Drawing.Point(125, 24);
            this.txtDescrizioneListino.Multiline = true;
            this.txtDescrizioneListino.Name = "txtDescrizioneListino";
            this.txtDescrizioneListino.ReadOnly = true;
            this.txtDescrizioneListino.Size = new System.Drawing.Size(185, 47);
            this.txtDescrizioneListino.TabIndex = 38;
            this.txtDescrizioneListino.TabStop = false;
            this.txtDescrizioneListino.Tag = "list.description";
            // 
            // gboxListClass
            // 
            this.gboxListClass.Controls.Add(this.chkAttivo);
            this.gboxListClass.Controls.Add(this.txtCodiceClass);
            this.gboxListClass.Controls.Add(this.txtDescrListClass);
            this.gboxListClass.Location = new System.Drawing.Point(13, 104);
            this.gboxListClass.Name = "gboxListClass";
            this.gboxListClass.Size = new System.Drawing.Size(318, 79);
            this.gboxListClass.TabIndex = 50;
            this.gboxListClass.TabStop = false;
            this.gboxListClass.Tag = "";
            this.gboxListClass.Text = "Classificazione Merceologica";
            // 
            // chkAttivo
            // 
            this.chkAttivo.Location = new System.Drawing.Point(8, 49);
            this.chkAttivo.Name = "chkAttivo";
            this.chkAttivo.Size = new System.Drawing.Size(120, 24);
            this.chkAttivo.TabIndex = 36;
            this.chkAttivo.Tag = "listclass.authrequired:S:N";
            this.chkAttivo.Text = "Aut. Richiesta";
            // 
            // txtCodiceClass
            // 
            this.txtCodiceClass.Location = new System.Drawing.Point(7, 19);
            this.txtCodiceClass.Name = "txtCodiceClass";
            this.txtCodiceClass.ReadOnly = true;
            this.txtCodiceClass.Size = new System.Drawing.Size(120, 20);
            this.txtCodiceClass.TabIndex = 35;
            this.txtCodiceClass.Tag = "listclass.codelistclass";
            // 
            // txtDescrListClass
            // 
            this.txtDescrListClass.Location = new System.Drawing.Point(133, 19);
            this.txtDescrListClass.Multiline = true;
            this.txtDescrListClass.Name = "txtDescrListClass";
            this.txtDescrListClass.ReadOnly = true;
            this.txtDescrListClass.Size = new System.Drawing.Size(179, 53);
            this.txtDescrListClass.TabIndex = 4;
            this.txtDescrListClass.TabStop = false;
            this.txtDescrListClass.Tag = "listclass.title";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtQuantitaConfezioni);
            this.groupBox2.Location = new System.Drawing.Point(14, 347);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(166, 50);
            this.groupBox2.TabIndex = 49;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Quantità";
            // 
            // txtQuantitaConfezioni
            // 
            this.txtQuantitaConfezioni.Location = new System.Drawing.Point(11, 19);
            this.txtQuantitaConfezioni.Name = "txtQuantitaConfezioni";
            this.txtQuantitaConfezioni.Size = new System.Drawing.Size(141, 20);
            this.txtQuantitaConfezioni.TabIndex = 28;
            this.txtQuantitaConfezioni.Tag = "storeunloaddetail.number.N";
            // 
            // pbox
            // 
            this.pbox.Location = new System.Drawing.Point(337, 24);
            this.pbox.Name = "pbox";
            this.pbox.Size = new System.Drawing.Size(194, 183);
            this.pbox.TabIndex = 48;
            this.pbox.TabStop = false;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(14, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 16);
            this.label4.TabIndex = 47;
            this.label4.Text = "Responsabile:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbResponsabile
            // 
            this.cmbResponsabile.DataSource = this.DS.manager;
            this.cmbResponsabile.DisplayMember = "title";
            this.cmbResponsabile.Location = new System.Drawing.Point(16, 203);
            this.cmbResponsabile.Name = "cmbResponsabile";
            this.cmbResponsabile.Size = new System.Drawing.Size(298, 21);
            this.cmbResponsabile.TabIndex = 46;
            this.cmbResponsabile.Tag = "storeunloaddetail.idman";
            this.cmbResponsabile.ValueMember = "idman";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbTipoFattura);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(14, 287);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(517, 56);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Riga del dettaglio fattura di vendita";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tipo/Eserc./Num./Riga";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbTipoFattura
            // 
            this.cmbTipoFattura.DataSource = this.DS.invoicekind;
            this.cmbTipoFattura.DisplayMember = "description";
            this.cmbTipoFattura.Enabled = false;
            this.cmbTipoFattura.Location = new System.Drawing.Point(136, 24);
            this.cmbTipoFattura.Name = "cmbTipoFattura";
            this.cmbTipoFattura.Size = new System.Drawing.Size(220, 21);
            this.cmbTipoFattura.TabIndex = 12;
            this.cmbTipoFattura.Tag = "invoicedetail.idinvkind";
            this.cmbTipoFattura.ValueMember = "idinvkind";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(457, 25);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(32, 20);
            this.textBox2.TabIndex = 4;
            this.textBox2.TabStop = false;
            this.textBox2.Tag = "invoicedetail.rownum";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(411, 25);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(40, 20);
            this.textBox3.TabIndex = 3;
            this.textBox3.TabStop = false;
            this.textBox3.Tag = "invoicedetail.ninv";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(363, 24);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(42, 20);
            this.textBox4.TabIndex = 2;
            this.textBox4.TabStop = false;
            this.textBox4.Tag = "invoicedetail.yinv.year";
            // 
            // grpRiga
            // 
            this.grpRiga.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRiga.Controls.Add(this.label14);
            this.grpRiga.Controls.Add(this.txtNumordine);
            this.grpRiga.Controls.Add(this.txtEsercordine);
            this.grpRiga.Enabled = false;
            this.grpRiga.Location = new System.Drawing.Point(14, 233);
            this.grpRiga.Name = "grpRiga";
            this.grpRiga.Size = new System.Drawing.Size(300, 50);
            this.grpRiga.TabIndex = 44;
            this.grpRiga.TabStop = false;
            this.grpRiga.Text = "Riga della prenotazione";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(8, 24);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(120, 16);
            this.label14.TabIndex = 6;
            this.label14.Text = "Eserc./Numero";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNumordine
            // 
            this.txtNumordine.Location = new System.Drawing.Point(202, 20);
            this.txtNumordine.Name = "txtNumordine";
            this.txtNumordine.ReadOnly = true;
            this.txtNumordine.Size = new System.Drawing.Size(40, 20);
            this.txtNumordine.TabIndex = 3;
            this.txtNumordine.TabStop = false;
            this.txtNumordine.Tag = "booking.nbooking";
            // 
            // txtEsercordine
            // 
            this.txtEsercordine.Location = new System.Drawing.Point(134, 20);
            this.txtEsercordine.Name = "txtEsercordine";
            this.txtEsercordine.ReadOnly = true;
            this.txtEsercordine.Size = new System.Drawing.Size(62, 20);
            this.txtEsercordine.TabIndex = 2;
            this.txtEsercordine.TabStop = false;
            this.txtEsercordine.Tag = "booking.ybooking.year";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.grpAnalitico);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(545, 468);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "EP";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // grpAnalitico
            // 
            this.grpAnalitico.Controls.Add(this.gboxclass1);
            this.grpAnalitico.Controls.Add(this.gboxclass3);
            this.grpAnalitico.Controls.Add(this.gboxclass2);
            this.grpAnalitico.Location = new System.Drawing.Point(6, 17);
            this.grpAnalitico.Name = "grpAnalitico";
            this.grpAnalitico.Size = new System.Drawing.Size(366, 272);
            this.grpAnalitico.TabIndex = 9;
            this.grpAnalitico.TabStop = false;
            this.grpAnalitico.Text = "Analitico";
            // 
            // gboxclass1
            // 
            this.gboxclass1.Controls.Add(this.btnCodice1);
            this.gboxclass1.Controls.Add(this.txtDenom1);
            this.gboxclass1.Controls.Add(this.txtCodice1);
            this.gboxclass1.Location = new System.Drawing.Point(15, 15);
            this.gboxclass1.Name = "gboxclass1";
            this.gboxclass1.Size = new System.Drawing.Size(336, 80);
            this.gboxclass1.TabIndex = 4;
            this.gboxclass1.TabStop = false;
            this.gboxclass1.Tag = "AutoManage.txtCodice.treeclassmovimenti";
            this.gboxclass1.Text = "Classificazione 1";
            // 
            // btnCodice1
            // 
            this.btnCodice1.Location = new System.Drawing.Point(8, 23);
            this.btnCodice1.Name = "btnCodice1";
            this.btnCodice1.Size = new System.Drawing.Size(88, 23);
            this.btnCodice1.TabIndex = 4;
            this.btnCodice1.Tag = "manage.sorting1.tree";
            this.btnCodice1.Text = "Codice";
            this.btnCodice1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom1
            // 
            this.txtDenom1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom1.Location = new System.Drawing.Point(128, 20);
            this.txtDenom1.Multiline = true;
            this.txtDenom1.Name = "txtDenom1";
            this.txtDenom1.ReadOnly = true;
            this.txtDenom1.Size = new System.Drawing.Size(200, 56);
            this.txtDenom1.TabIndex = 3;
            this.txtDenom1.TabStop = false;
            this.txtDenom1.Tag = "sorting1.description";
            // 
            // txtCodice1
            // 
            this.txtCodice1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCodice1.Location = new System.Drawing.Point(8, 53);
            this.txtCodice1.Name = "txtCodice1";
            this.txtCodice1.Size = new System.Drawing.Size(112, 20);
            this.txtCodice1.TabIndex = 2;
            this.txtCodice1.Tag = "sorting1.sortcode?x";
            // 
            // gboxclass3
            // 
            this.gboxclass3.Controls.Add(this.btnCodice3);
            this.gboxclass3.Controls.Add(this.txtDenom3);
            this.gboxclass3.Controls.Add(this.txtCodice3);
            this.gboxclass3.Location = new System.Drawing.Point(15, 187);
            this.gboxclass3.Name = "gboxclass3";
            this.gboxclass3.Size = new System.Drawing.Size(336, 79);
            this.gboxclass3.TabIndex = 5;
            this.gboxclass3.TabStop = false;
            this.gboxclass3.Tag = "AutoManage.txtCodice.treeclassmovimenti";
            this.gboxclass3.Text = "Classificazione 3";
            // 
            // btnCodice3
            // 
            this.btnCodice3.Location = new System.Drawing.Point(8, 22);
            this.btnCodice3.Name = "btnCodice3";
            this.btnCodice3.Size = new System.Drawing.Size(88, 23);
            this.btnCodice3.TabIndex = 4;
            this.btnCodice3.Tag = "manage.sorting3.tree";
            this.btnCodice3.Text = "Codice";
            this.btnCodice3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom3
            // 
            this.txtDenom3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom3.Location = new System.Drawing.Point(128, 20);
            this.txtDenom3.Multiline = true;
            this.txtDenom3.Name = "txtDenom3";
            this.txtDenom3.ReadOnly = true;
            this.txtDenom3.Size = new System.Drawing.Size(200, 55);
            this.txtDenom3.TabIndex = 3;
            this.txtDenom3.TabStop = false;
            this.txtDenom3.Tag = "sorting3.description";
            // 
            // txtCodice3
            // 
            this.txtCodice3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCodice3.Location = new System.Drawing.Point(8, 51);
            this.txtCodice3.Name = "txtCodice3";
            this.txtCodice3.Size = new System.Drawing.Size(112, 20);
            this.txtCodice3.TabIndex = 4;
            this.txtCodice3.Tag = "sorting3.sortcode?x";
            // 
            // gboxclass2
            // 
            this.gboxclass2.Controls.Add(this.btnCodice2);
            this.gboxclass2.Controls.Add(this.txtDenom2);
            this.gboxclass2.Controls.Add(this.txtCodice2);
            this.gboxclass2.Location = new System.Drawing.Point(15, 101);
            this.gboxclass2.Name = "gboxclass2";
            this.gboxclass2.Size = new System.Drawing.Size(336, 80);
            this.gboxclass2.TabIndex = 6;
            this.gboxclass2.TabStop = false;
            this.gboxclass2.Tag = "AutoManage.txtCodice.treeclassmovimenti";
            this.gboxclass2.Text = "Classificazione 2";
            // 
            // btnCodice2
            // 
            this.btnCodice2.Location = new System.Drawing.Point(6, 25);
            this.btnCodice2.Name = "btnCodice2";
            this.btnCodice2.Size = new System.Drawing.Size(88, 23);
            this.btnCodice2.TabIndex = 4;
            this.btnCodice2.Tag = "manage.sorting2.tree";
            this.btnCodice2.Text = "Codice";
            this.btnCodice2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom2
            // 
            this.txtDenom2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom2.Location = new System.Drawing.Point(128, 20);
            this.txtDenom2.Multiline = true;
            this.txtDenom2.Name = "txtDenom2";
            this.txtDenom2.ReadOnly = true;
            this.txtDenom2.Size = new System.Drawing.Size(200, 56);
            this.txtDenom2.TabIndex = 3;
            this.txtDenom2.TabStop = false;
            this.txtDenom2.Tag = "sorting2.description";
            // 
            // txtCodice2
            // 
            this.txtCodice2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCodice2.Location = new System.Drawing.Point(6, 53);
            this.txtCodice2.Name = "txtCodice2";
            this.txtCodice2.Size = new System.Drawing.Size(112, 20);
            this.txtCodice2.TabIndex = 2;
            this.txtCodice2.Tag = "sorting2.sortcode?x";
            // 
            // Frm_storeunloaddetail_single
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(575, 564);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Frm_storeunloaddetail_single";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.grpListino.ResumeLayout(false);
            this.grpListino.PerformLayout();
            this.gboxListClass.ResumeLayout(false);
            this.gboxListClass.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpRiga.ResumeLayout(false);
            this.grpRiga.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.grpAnalitico.ResumeLayout(false);
            this.gboxclass1.ResumeLayout(false);
            this.gboxclass1.PerformLayout();
            this.gboxclass3.ResumeLayout(false);
            this.gboxclass3.PerformLayout();
            this.gboxclass2.ResumeLayout(false);
            this.gboxclass2.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion
		

		DataAccess Conn;
		public void MetaData_AfterLink(){
			Meta = MetaData.GetMetaData(this);
			Conn= Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
            string filter = "(ayear=" + QueryCreator.quotedstrvalue(Meta.GetSys("esercizio"), true) + ")";
            DataAccess.SetTableForReading(DS.sorting1, "sorting");
            DataAccess.SetTableForReading(DS.sorting2, "sorting");
            DataAccess.SetTableForReading(DS.sorting3, "sorting");
         
            DataTable tExpSetup = Meta.Conn.RUN_SELECT("config", "*", null,
                  filter, null, null, true);
            if ((tExpSetup != null) && (tExpSetup.Rows.Count > 0)) {
                DataRow R = tExpSetup.Rows[0];
                string idsorkind1 = R["idsortingkind1"].ToString();
                string idsorkind2 = R["idsortingkind2"].ToString();
                string idsorkind3 = R["idsortingkind3"].ToString();
                SetGBoxClass(1, idsorkind1);
                SetGBoxClass(2, idsorkind2);
                SetGBoxClass(3, idsorkind3);

                if (idsorkind3 == "") {
                    grpAnalitico.Size = new System.Drawing.Size(366, 200);
                }
                if (idsorkind2 + idsorkind3 == "") {
                    grpAnalitico.Size = new System.Drawing.Size(366, 100);
                }
                if (idsorkind1 + idsorkind2 + idsorkind3 == "") {
                    grpAnalitico.Visible = false;
                }
            }
        }

        void SetGBoxClass (int num, string sortingkind) {
            if (sortingkind == "") {
                GroupBox G = (GroupBox)GetCtrlByName("gboxclass" + num.ToString());
                G.Visible = false;
            }
            else {
                string filter = "(idsorkind=" +
                    QueryCreator.quotedstrvalue(sortingkind, true) + ")";
                GetData.SetStaticFilter(DS.Tables["sorting" + num.ToString()], filter);
                GroupBox gboxclass = (GroupBox)GetCtrlByName("gboxclass" + num.ToString());
                Button btnCodice = (Button)GetCtrlByName("btnCodice" + num.ToString());
                string title = Meta.Conn.DO_READ_VALUE("sortingkind", filter, "description").ToString();
                gboxclass.Text = title;
                gboxclass.Tag = "AutoManage.txtCodice" + num.ToString() + ".tree." + filter;
                btnCodice.Tag = "manage.sorting" + num.ToString() + ".tree." + filter;
                DS.Tables["sorting" + num.ToString()].ExtendedProperties[MetaData.ExtraParams] = filter;
            }
        }
        object GetCtrlByName (string Name) {
            System.Reflection.FieldInfo Ctrl = this.GetType().GetField(Name);
            if (Ctrl == null) return null;
            return Ctrl.GetValue(this);
        }

        public void MetaData_AfterFill() {
            DataRow RList = DS.list.Rows[0];
            FreshLogo(RList);

            DataRow Curr = DS.storeunloaddetail.Rows[0];
            if (Meta.InsertMode && Curr["idbooking"] == DBNull.Value){
                cmbResponsabile.Enabled = true;
            }
            else{
                cmbResponsabile.Enabled = false;
            }
        }
          
        void FreshLogo (DataRow RList) {
            if (RList == null) return;

            try {
                if (RList["pic"] != DBNull.Value) {
                    MemoryStream MS = new MemoryStream((byte[])RList["pic"]);
                    Image IM = new Bitmap(MS, false);
                    pbox.Image = IM;
                }
                else {
                    pbox.Image = null;
                }
            }
            catch {
                pbox.Image = null;
            }
        }
	}
}
