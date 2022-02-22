
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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using System.Data;
using ep_functions;
using funzioni_configurazione;

namespace accountvardetail_single {
	/// <summary>
	/// Summary description for Frm_accountvardetail_single.
	/// </summary>
	public class Frm_accountvardetail_single : MetaDataForm {
		MetaData Meta;
		private DataAccess Conn;
		bool inChiusura = false;
        public accountvardetail_single.vistaForm DS;
		private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescrizione;
		private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Button btnOK;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        QueryHelper QHS;
        public GroupBox grpImporto5;
        private RadioButton radioButton7;
        private RadioButton radioButton8;
        private TextBox txtImporto5;
        public GroupBox grpImporto4;
        private RadioButton radioButton5;
        private RadioButton radioButton6;
        private TextBox txtImporto4;
        public GroupBox grpImporto3;
        private RadioButton radioButton3;
        private RadioButton radioButton4;
        private TextBox txtImporto3;
        public GroupBox grpImporto2;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private TextBox txtImporto2;
        public GroupBox grpImporto1;
        private RadioButton rdbDiminuzione;
        private RadioButton rdbAumento;
        private TextBox txtImporto1;
        private GroupBox gboxUPB;
        public TextBox txtUPB;
        private TextBox txtDescrUPB;
        private Button btnUPBCode;
        private GroupBox gboxConto;
        private TextBox txtDenominazioneConto;
        private TextBox txtCodiceConto;
        private Button btnConto;
        private TextBox txtTotale;
        private Label label4;
        public GroupBox gboxclass3;
        public Button btnCodice3;
        private TextBox txtDenom3;
        private TextBox txtCodice3;
        public GroupBox gboxclass2;
        public Button btnCodice2;
        private TextBox txtDenom2;
        private TextBox txtCodice2;
        public GroupBox gboxclass1;
        public Button btnCodice1;
        private TextBox txtDenom1;
        private TextBox txtCodice1;
        public GroupBox grpRipartizioneCosti;
        public Button button3;
        public TextBox textBox1;
        public TextBox txtCodiceRipartizione;
        private CheckBox chkListTitle;
        private GroupBox groupBox2;
        private ComboBox cmbCausale;
        public GroupBox grpPrevCassaDI;
        private TextBox textBox2;
		private GroupBox grpInventario;
		private TextBox txtDescClassif;
		private TextBox txtCodClassif;
		private Button btnClassif;
		private Button btnSpalmaPrevisioni;
		private TextBox txtNumDettaglio;
		private Label labelNumDett;
		CQueryHelper QHC;
		public Frm_accountvardetail_single() {
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			inChiusura = true;
			if( disposing ) {
				if(components != null) {
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		public void MetaData_AfterActivation() {
			
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.label2 = new System.Windows.Forms.Label();
			this.txtDescrizione = new System.Windows.Forms.TextBox();
			this.btnAnnulla = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.grpImporto5 = new System.Windows.Forms.GroupBox();
			this.radioButton7 = new System.Windows.Forms.RadioButton();
			this.radioButton8 = new System.Windows.Forms.RadioButton();
			this.txtImporto5 = new System.Windows.Forms.TextBox();
			this.grpImporto4 = new System.Windows.Forms.GroupBox();
			this.radioButton5 = new System.Windows.Forms.RadioButton();
			this.radioButton6 = new System.Windows.Forms.RadioButton();
			this.txtImporto4 = new System.Windows.Forms.TextBox();
			this.grpImporto3 = new System.Windows.Forms.GroupBox();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton4 = new System.Windows.Forms.RadioButton();
			this.txtImporto3 = new System.Windows.Forms.TextBox();
			this.grpImporto2 = new System.Windows.Forms.GroupBox();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.txtImporto2 = new System.Windows.Forms.TextBox();
			this.grpImporto1 = new System.Windows.Forms.GroupBox();
			this.rdbDiminuzione = new System.Windows.Forms.RadioButton();
			this.rdbAumento = new System.Windows.Forms.RadioButton();
			this.txtImporto1 = new System.Windows.Forms.TextBox();
			this.gboxUPB = new System.Windows.Forms.GroupBox();
			this.txtUPB = new System.Windows.Forms.TextBox();
			this.txtDescrUPB = new System.Windows.Forms.TextBox();
			this.btnUPBCode = new System.Windows.Forms.Button();
			this.gboxConto = new System.Windows.Forms.GroupBox();
			this.chkListTitle = new System.Windows.Forms.CheckBox();
			this.txtDenominazioneConto = new System.Windows.Forms.TextBox();
			this.txtCodiceConto = new System.Windows.Forms.TextBox();
			this.btnConto = new System.Windows.Forms.Button();
			this.txtTotale = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.gboxclass3 = new System.Windows.Forms.GroupBox();
			this.btnCodice3 = new System.Windows.Forms.Button();
			this.txtDenom3 = new System.Windows.Forms.TextBox();
			this.txtCodice3 = new System.Windows.Forms.TextBox();
			this.gboxclass2 = new System.Windows.Forms.GroupBox();
			this.btnCodice2 = new System.Windows.Forms.Button();
			this.txtDenom2 = new System.Windows.Forms.TextBox();
			this.txtCodice2 = new System.Windows.Forms.TextBox();
			this.gboxclass1 = new System.Windows.Forms.GroupBox();
			this.btnCodice1 = new System.Windows.Forms.Button();
			this.txtDenom1 = new System.Windows.Forms.TextBox();
			this.txtCodice1 = new System.Windows.Forms.TextBox();
			this.grpRipartizioneCosti = new System.Windows.Forms.GroupBox();
			this.button3 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.txtCodiceRipartizione = new System.Windows.Forms.TextBox();
			this.DS = new accountvardetail_single.vistaForm();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.cmbCausale = new System.Windows.Forms.ComboBox();
			this.grpPrevCassaDI = new System.Windows.Forms.GroupBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.grpInventario = new System.Windows.Forms.GroupBox();
			this.txtDescClassif = new System.Windows.Forms.TextBox();
			this.txtCodClassif = new System.Windows.Forms.TextBox();
			this.btnClassif = new System.Windows.Forms.Button();
			this.btnSpalmaPrevisioni = new System.Windows.Forms.Button();
			this.txtNumDettaglio = new System.Windows.Forms.TextBox();
			this.labelNumDett = new System.Windows.Forms.Label();
			this.grpImporto5.SuspendLayout();
			this.grpImporto4.SuspendLayout();
			this.grpImporto3.SuspendLayout();
			this.grpImporto2.SuspendLayout();
			this.grpImporto1.SuspendLayout();
			this.gboxUPB.SuspendLayout();
			this.gboxConto.SuspendLayout();
			this.gboxclass3.SuspendLayout();
			this.gboxclass2.SuspendLayout();
			this.gboxclass1.SuspendLayout();
			this.grpRipartizioneCosti.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.grpPrevCassaDI.SuspendLayout();
			this.grpInventario.SuspendLayout();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(13, 28);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 16);
			this.label2.TabIndex = 18;
			this.label2.Text = "Descrizione:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtDescrizione
			// 
			this.txtDescrizione.Location = new System.Drawing.Point(13, 49);
			this.txtDescrizione.Multiline = true;
			this.txtDescrizione.Name = "txtDescrizione";
			this.txtDescrizione.Size = new System.Drawing.Size(311, 75);
			this.txtDescrizione.TabIndex = 1;
			this.txtDescrizione.Tag = "accountvardetail.description";
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnAnnulla.Location = new System.Drawing.Point(750, 554);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
			this.btnAnnulla.TabIndex = 10;
			this.btnAnnulla.Text = "Annulla";
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(646, 554);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 9;
			this.btnOK.Tag = "mainsave";
			this.btnOK.Text = "OK";
			// 
			// grpImporto5
			// 
			this.grpImporto5.Controls.Add(this.radioButton7);
			this.grpImporto5.Controls.Add(this.radioButton8);
			this.grpImporto5.Controls.Add(this.txtImporto5);
			this.grpImporto5.Location = new System.Drawing.Point(665, 139);
			this.grpImporto5.Name = "grpImporto5";
			this.grpImporto5.Size = new System.Drawing.Size(148, 88);
			this.grpImporto5.TabIndex = 6;
			this.grpImporto5.TabStop = false;
			this.grpImporto5.Tag = "accountvardetail.amount5.valuesigned";
			this.grpImporto5.Text = "Importo variazione anno";
			// 
			// radioButton7
			// 
			this.radioButton7.Location = new System.Drawing.Point(6, 40);
			this.radioButton7.Name = "radioButton7";
			this.radioButton7.Size = new System.Drawing.Size(104, 21);
			this.radioButton7.TabIndex = 3;
			this.radioButton7.Tag = "-";
			this.radioButton7.Text = "Diminuzione";
			this.radioButton7.CheckedChanged += new System.EventHandler(this.txtImportoLeave);
			// 
			// radioButton8
			// 
			this.radioButton8.Location = new System.Drawing.Point(6, 19);
			this.radioButton8.Name = "radioButton8";
			this.radioButton8.Size = new System.Drawing.Size(104, 24);
			this.radioButton8.TabIndex = 2;
			this.radioButton8.Tag = "+";
			this.radioButton8.Text = "Aumento";
			this.radioButton8.CheckedChanged += new System.EventHandler(this.txtImportoLeave);
			// 
			// txtImporto5
			// 
			this.txtImporto5.Location = new System.Drawing.Point(6, 62);
			this.txtImporto5.Name = "txtImporto5";
			this.txtImporto5.Size = new System.Drawing.Size(104, 20);
			this.txtImporto5.TabIndex = 1;
			this.txtImporto5.Tag = "accountvardetail.amount5";
			this.txtImporto5.Leave += new System.EventHandler(this.txtImportoLeave);
			// 
			// grpImporto4
			// 
			this.grpImporto4.Controls.Add(this.radioButton5);
			this.grpImporto4.Controls.Add(this.radioButton6);
			this.grpImporto4.Controls.Add(this.txtImporto4);
			this.grpImporto4.Location = new System.Drawing.Point(504, 139);
			this.grpImporto4.Name = "grpImporto4";
			this.grpImporto4.Size = new System.Drawing.Size(148, 88);
			this.grpImporto4.TabIndex = 5;
			this.grpImporto4.TabStop = false;
			this.grpImporto4.Tag = "accountvardetail.amount4.valuesigned";
			this.grpImporto4.Text = "Importo variazione anno";
			// 
			// radioButton5
			// 
			this.radioButton5.Location = new System.Drawing.Point(6, 40);
			this.radioButton5.Name = "radioButton5";
			this.radioButton5.Size = new System.Drawing.Size(104, 21);
			this.radioButton5.TabIndex = 3;
			this.radioButton5.Tag = "-";
			this.radioButton5.Text = "Diminuzione";
			this.radioButton5.CheckedChanged += new System.EventHandler(this.txtImportoLeave);
			// 
			// radioButton6
			// 
			this.radioButton6.Location = new System.Drawing.Point(6, 19);
			this.radioButton6.Name = "radioButton6";
			this.radioButton6.Size = new System.Drawing.Size(104, 24);
			this.radioButton6.TabIndex = 2;
			this.radioButton6.Tag = "+";
			this.radioButton6.Text = "Aumento";
			this.radioButton6.CheckedChanged += new System.EventHandler(this.txtImportoLeave);
			// 
			// txtImporto4
			// 
			this.txtImporto4.Location = new System.Drawing.Point(6, 62);
			this.txtImporto4.Name = "txtImporto4";
			this.txtImporto4.Size = new System.Drawing.Size(104, 20);
			this.txtImporto4.TabIndex = 1;
			this.txtImporto4.Tag = "accountvardetail.amount4";
			this.txtImporto4.Leave += new System.EventHandler(this.txtImportoLeave);
			// 
			// grpImporto3
			// 
			this.grpImporto3.Controls.Add(this.radioButton3);
			this.grpImporto3.Controls.Add(this.radioButton4);
			this.grpImporto3.Controls.Add(this.txtImporto3);
			this.grpImporto3.Location = new System.Drawing.Point(341, 139);
			this.grpImporto3.Name = "grpImporto3";
			this.grpImporto3.Size = new System.Drawing.Size(148, 88);
			this.grpImporto3.TabIndex = 4;
			this.grpImporto3.TabStop = false;
			this.grpImporto3.Tag = "accountvardetail.amount3.valuesigned";
			this.grpImporto3.Text = "Importo variazione anno";
			// 
			// radioButton3
			// 
			this.radioButton3.Location = new System.Drawing.Point(6, 40);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(104, 21);
			this.radioButton3.TabIndex = 3;
			this.radioButton3.Tag = "-";
			this.radioButton3.Text = "Diminuzione";
			this.radioButton3.CheckedChanged += new System.EventHandler(this.txtImportoLeave);
			// 
			// radioButton4
			// 
			this.radioButton4.Location = new System.Drawing.Point(6, 19);
			this.radioButton4.Name = "radioButton4";
			this.radioButton4.Size = new System.Drawing.Size(104, 24);
			this.radioButton4.TabIndex = 2;
			this.radioButton4.Tag = "+";
			this.radioButton4.Text = "Aumento";
			this.radioButton4.CheckedChanged += new System.EventHandler(this.txtImportoLeave);
			// 
			// txtImporto3
			// 
			this.txtImporto3.Location = new System.Drawing.Point(6, 62);
			this.txtImporto3.Name = "txtImporto3";
			this.txtImporto3.Size = new System.Drawing.Size(104, 20);
			this.txtImporto3.TabIndex = 1;
			this.txtImporto3.Tag = "accountvardetail.amount3";
			this.txtImporto3.Leave += new System.EventHandler(this.txtImportoLeave);
			// 
			// grpImporto2
			// 
			this.grpImporto2.Controls.Add(this.radioButton1);
			this.grpImporto2.Controls.Add(this.radioButton2);
			this.grpImporto2.Controls.Add(this.txtImporto2);
			this.grpImporto2.Location = new System.Drawing.Point(176, 139);
			this.grpImporto2.Name = "grpImporto2";
			this.grpImporto2.Size = new System.Drawing.Size(148, 88);
			this.grpImporto2.TabIndex = 3;
			this.grpImporto2.TabStop = false;
			this.grpImporto2.Tag = "accountvardetail.amount2.valuesigned";
			this.grpImporto2.Text = "Importo variazione anno";
			// 
			// radioButton1
			// 
			this.radioButton1.Location = new System.Drawing.Point(6, 40);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(104, 21);
			this.radioButton1.TabIndex = 3;
			this.radioButton1.Tag = "-";
			this.radioButton1.Text = "Diminuzione";
			this.radioButton1.CheckedChanged += new System.EventHandler(this.txtImportoLeave);
			// 
			// radioButton2
			// 
			this.radioButton2.Location = new System.Drawing.Point(6, 19);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(104, 24);
			this.radioButton2.TabIndex = 2;
			this.radioButton2.Tag = "+";
			this.radioButton2.Text = "Aumento";
			this.radioButton2.CheckedChanged += new System.EventHandler(this.txtImportoLeave);
			// 
			// txtImporto2
			// 
			this.txtImporto2.Location = new System.Drawing.Point(6, 62);
			this.txtImporto2.Name = "txtImporto2";
			this.txtImporto2.Size = new System.Drawing.Size(104, 20);
			this.txtImporto2.TabIndex = 1;
			this.txtImporto2.Tag = "accountvardetail.amount2";
			this.txtImporto2.Leave += new System.EventHandler(this.txtImportoLeave);
			// 
			// grpImporto1
			// 
			this.grpImporto1.Controls.Add(this.rdbDiminuzione);
			this.grpImporto1.Controls.Add(this.rdbAumento);
			this.grpImporto1.Controls.Add(this.txtImporto1);
			this.grpImporto1.Location = new System.Drawing.Point(13, 139);
			this.grpImporto1.Name = "grpImporto1";
			this.grpImporto1.Size = new System.Drawing.Size(148, 88);
			this.grpImporto1.TabIndex = 2;
			this.grpImporto1.TabStop = false;
			this.grpImporto1.Tag = "accountvardetail.amount.valuesigned";
			this.grpImporto1.Text = "Importo variazione anno";
			// 
			// rdbDiminuzione
			// 
			this.rdbDiminuzione.Location = new System.Drawing.Point(6, 40);
			this.rdbDiminuzione.Name = "rdbDiminuzione";
			this.rdbDiminuzione.Size = new System.Drawing.Size(104, 21);
			this.rdbDiminuzione.TabIndex = 3;
			this.rdbDiminuzione.Tag = "-";
			this.rdbDiminuzione.Text = "Diminuzione";
			this.rdbDiminuzione.CheckedChanged += new System.EventHandler(this.txtImportoLeave);
			// 
			// rdbAumento
			// 
			this.rdbAumento.Location = new System.Drawing.Point(6, 19);
			this.rdbAumento.Name = "rdbAumento";
			this.rdbAumento.Size = new System.Drawing.Size(104, 24);
			this.rdbAumento.TabIndex = 2;
			this.rdbAumento.Tag = "+";
			this.rdbAumento.Text = "Aumento";
			this.rdbAumento.CheckedChanged += new System.EventHandler(this.txtImportoLeave);
			// 
			// txtImporto1
			// 
			this.txtImporto1.Location = new System.Drawing.Point(6, 62);
			this.txtImporto1.Name = "txtImporto1";
			this.txtImporto1.Size = new System.Drawing.Size(104, 20);
			this.txtImporto1.TabIndex = 1;
			this.txtImporto1.Tag = "accountvardetail.amount";
			this.txtImporto1.Leave += new System.EventHandler(this.txtImportoLeave);
			// 
			// gboxUPB
			// 
			this.gboxUPB.Controls.Add(this.txtUPB);
			this.gboxUPB.Controls.Add(this.txtDescrUPB);
			this.gboxUPB.Controls.Add(this.btnUPBCode);
			this.gboxUPB.Location = new System.Drawing.Point(290, 242);
			this.gboxUPB.Name = "gboxUPB";
			this.gboxUPB.Size = new System.Drawing.Size(267, 104);
			this.gboxUPB.TabIndex = 8;
			this.gboxUPB.TabStop = false;
			this.gboxUPB.Tag = "AutoChoose.txtUPB.default.(active=\'S\')";
			// 
			// txtUPB
			// 
			this.txtUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtUPB.Location = new System.Drawing.Point(8, 77);
			this.txtUPB.Name = "txtUPB";
			this.txtUPB.Size = new System.Drawing.Size(250, 20);
			this.txtUPB.TabIndex = 5;
			this.txtUPB.Tag = "upb.codeupb?x";
			// 
			// txtDescrUPB
			// 
			this.txtDescrUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescrUPB.Location = new System.Drawing.Point(126, 16);
			this.txtDescrUPB.Multiline = true;
			this.txtDescrUPB.Name = "txtDescrUPB";
			this.txtDescrUPB.ReadOnly = true;
			this.txtDescrUPB.Size = new System.Drawing.Size(132, 55);
			this.txtDescrUPB.TabIndex = 4;
			this.txtDescrUPB.TabStop = false;
			this.txtDescrUPB.Tag = "upb.title";
			// 
			// btnUPBCode
			// 
			this.btnUPBCode.BackColor = System.Drawing.SystemColors.Control;
			this.btnUPBCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnUPBCode.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnUPBCode.Location = new System.Drawing.Point(8, 51);
			this.btnUPBCode.Name = "btnUPBCode";
			this.btnUPBCode.Size = new System.Drawing.Size(112, 20);
			this.btnUPBCode.TabIndex = 2;
			this.btnUPBCode.TabStop = false;
			this.btnUPBCode.Tag = "manage.upb.tree";
			this.btnUPBCode.Text = "UPB:";
			this.btnUPBCode.UseVisualStyleBackColor = true;
			// 
			// gboxConto
			// 
			this.gboxConto.Controls.Add(this.chkListTitle);
			this.gboxConto.Controls.Add(this.txtDenominazioneConto);
			this.gboxConto.Controls.Add(this.txtCodiceConto);
			this.gboxConto.Controls.Add(this.btnConto);
			this.gboxConto.Location = new System.Drawing.Point(13, 233);
			this.gboxConto.Name = "gboxConto";
			this.gboxConto.Size = new System.Drawing.Size(273, 113);
			this.gboxConto.TabIndex = 7;
			this.gboxConto.TabStop = false;
			this.gboxConto.Tag = "";
			// 
			// chkListTitle
			// 
			this.chkListTitle.Location = new System.Drawing.Point(5, 8);
			this.chkListTitle.Name = "chkListTitle";
			this.chkListTitle.Size = new System.Drawing.Size(155, 19);
			this.chkListTitle.TabIndex = 57;
			this.chkListTitle.TabStop = false;
			this.chkListTitle.Text = "Cerca per denominazione";
			// 
			// txtDenominazioneConto
			// 
			this.txtDenominazioneConto.Location = new System.Drawing.Point(134, 27);
			this.txtDenominazioneConto.Multiline = true;
			this.txtDenominazioneConto.Name = "txtDenominazioneConto";
			this.txtDenominazioneConto.ReadOnly = true;
			this.txtDenominazioneConto.Size = new System.Drawing.Size(134, 56);
			this.txtDenominazioneConto.TabIndex = 2;
			this.txtDenominazioneConto.TabStop = false;
			this.txtDenominazioneConto.Tag = "account.title";
			// 
			// txtCodiceConto
			// 
			this.txtCodiceConto.Location = new System.Drawing.Point(6, 87);
			this.txtCodiceConto.Name = "txtCodiceConto";
			this.txtCodiceConto.Size = new System.Drawing.Size(262, 20);
			this.txtCodiceConto.TabIndex = 1;
			this.txtCodiceConto.Tag = "account.codeacc?x";
			this.txtCodiceConto.Enter += new System.EventHandler(this.txtCodiceConto_Enter);
			this.txtCodiceConto.Leave += new System.EventHandler(this.txtCodiceConto_Leave);
			// 
			// btnConto
			// 
			this.btnConto.Location = new System.Drawing.Point(8, 57);
			this.btnConto.Name = "btnConto";
			this.btnConto.Size = new System.Drawing.Size(120, 23);
			this.btnConto.TabIndex = 0;
			this.btnConto.TabStop = false;
			this.btnConto.Tag = "";
			this.btnConto.Text = "Conto";
			this.btnConto.Click += new System.EventHandler(this.btnConto_Click);
			// 
			// txtTotale
			// 
			this.txtTotale.Location = new System.Drawing.Point(709, 22);
			this.txtTotale.Name = "txtTotale";
			this.txtTotale.ReadOnly = true;
			this.txtTotale.Size = new System.Drawing.Size(104, 20);
			this.txtTotale.TabIndex = 52;
			this.txtTotale.Tag = "";
			this.txtTotale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(706, 6);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(91, 13);
			this.label4.TabIndex = 51;
			this.label4.Text = "Totale pluriennale";
			// 
			// gboxclass3
			// 
			this.gboxclass3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxclass3.Controls.Add(this.btnCodice3);
			this.gboxclass3.Controls.Add(this.txtDenom3);
			this.gboxclass3.Controls.Add(this.txtCodice3);
			this.gboxclass3.Location = new System.Drawing.Point(563, 350);
			this.gboxclass3.Name = "gboxclass3";
			this.gboxclass3.Size = new System.Drawing.Size(262, 108);
			this.gboxclass3.TabIndex = 55;
			this.gboxclass3.TabStop = false;
			this.gboxclass3.Tag = "AutoManage.txtCodice3.treeclassmovimenti";
			this.gboxclass3.Text = "Classificazione 3";
			// 
			// btnCodice3
			// 
			this.btnCodice3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnCodice3.Location = new System.Drawing.Point(6, 56);
			this.btnCodice3.Name = "btnCodice3";
			this.btnCodice3.Size = new System.Drawing.Size(88, 23);
			this.btnCodice3.TabIndex = 4;
			this.btnCodice3.TabStop = false;
			this.btnCodice3.Tag = "manage.sorting3.tree";
			this.btnCodice3.Text = "Codice";
			this.btnCodice3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtDenom3
			// 
			this.txtDenom3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDenom3.Location = new System.Drawing.Point(123, 21);
			this.txtDenom3.Multiline = true;
			this.txtDenom3.Name = "txtDenom3";
			this.txtDenom3.ReadOnly = true;
			this.txtDenom3.Size = new System.Drawing.Size(133, 56);
			this.txtDenom3.TabIndex = 3;
			this.txtDenom3.TabStop = false;
			this.txtDenom3.Tag = "sorting3.description";
			// 
			// txtCodice3
			// 
			this.txtCodice3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCodice3.Location = new System.Drawing.Point(6, 82);
			this.txtCodice3.Name = "txtCodice3";
			this.txtCodice3.Size = new System.Drawing.Size(250, 20);
			this.txtCodice3.TabIndex = 2;
			this.txtCodice3.Tag = "sorting3.sortcode?x";
			// 
			// gboxclass2
			// 
			this.gboxclass2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxclass2.Controls.Add(this.btnCodice2);
			this.gboxclass2.Controls.Add(this.txtDenom2);
			this.gboxclass2.Controls.Add(this.txtCodice2);
			this.gboxclass2.Location = new System.Drawing.Point(292, 349);
			this.gboxclass2.Name = "gboxclass2";
			this.gboxclass2.Size = new System.Drawing.Size(265, 108);
			this.gboxclass2.TabIndex = 54;
			this.gboxclass2.TabStop = false;
			this.gboxclass2.Tag = "AutoManage.txtCodice2.treeclassmovimenti";
			this.gboxclass2.Text = "Classificazione 2";
			// 
			// btnCodice2
			// 
			this.btnCodice2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnCodice2.Location = new System.Drawing.Point(10, 56);
			this.btnCodice2.Name = "btnCodice2";
			this.btnCodice2.Size = new System.Drawing.Size(88, 23);
			this.btnCodice2.TabIndex = 4;
			this.btnCodice2.TabStop = false;
			this.btnCodice2.Tag = "manage.sorting2.tree";
			this.btnCodice2.Text = "Codice";
			this.btnCodice2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtDenom2
			// 
			this.txtDenom2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDenom2.Location = new System.Drawing.Point(118, 24);
			this.txtDenom2.Multiline = true;
			this.txtDenom2.Name = "txtDenom2";
			this.txtDenom2.ReadOnly = true;
			this.txtDenom2.Size = new System.Drawing.Size(139, 55);
			this.txtDenom2.TabIndex = 3;
			this.txtDenom2.TabStop = false;
			this.txtDenom2.Tag = "sorting2.description";
			// 
			// txtCodice2
			// 
			this.txtCodice2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCodice2.Location = new System.Drawing.Point(6, 82);
			this.txtCodice2.Name = "txtCodice2";
			this.txtCodice2.Size = new System.Drawing.Size(251, 20);
			this.txtCodice2.TabIndex = 2;
			this.txtCodice2.Tag = "sorting2.sortcode?x";
			// 
			// gboxclass1
			// 
			this.gboxclass1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxclass1.Controls.Add(this.btnCodice1);
			this.gboxclass1.Controls.Add(this.txtDenom1);
			this.gboxclass1.Controls.Add(this.txtCodice1);
			this.gboxclass1.Location = new System.Drawing.Point(12, 349);
			this.gboxclass1.Name = "gboxclass1";
			this.gboxclass1.Size = new System.Drawing.Size(274, 108);
			this.gboxclass1.TabIndex = 53;
			this.gboxclass1.TabStop = false;
			this.gboxclass1.Tag = "AutoManage.txtCodice1.treeclassmovimenti";
			this.gboxclass1.Text = "Classificazione 1";
			// 
			// btnCodice1
			// 
			this.btnCodice1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnCodice1.Location = new System.Drawing.Point(6, 56);
			this.btnCodice1.Name = "btnCodice1";
			this.btnCodice1.Size = new System.Drawing.Size(88, 23);
			this.btnCodice1.TabIndex = 4;
			this.btnCodice1.TabStop = false;
			this.btnCodice1.Tag = "manage.sorting1.tree";
			this.btnCodice1.Text = "Codice";
			this.btnCodice1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtDenom1
			// 
			this.txtDenom1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDenom1.Location = new System.Drawing.Point(128, 24);
			this.txtDenom1.Multiline = true;
			this.txtDenom1.Name = "txtDenom1";
			this.txtDenom1.ReadOnly = true;
			this.txtDenom1.Size = new System.Drawing.Size(141, 55);
			this.txtDenom1.TabIndex = 3;
			this.txtDenom1.TabStop = false;
			this.txtDenom1.Tag = "sorting1.description";
			// 
			// txtCodice1
			// 
			this.txtCodice1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCodice1.Location = new System.Drawing.Point(6, 82);
			this.txtCodice1.Name = "txtCodice1";
			this.txtCodice1.Size = new System.Drawing.Size(263, 20);
			this.txtCodice1.TabIndex = 2;
			this.txtCodice1.Tag = "sorting1.sortcode?x";
			// 
			// grpRipartizioneCosti
			// 
			this.grpRipartizioneCosti.Controls.Add(this.button3);
			this.grpRipartizioneCosti.Controls.Add(this.textBox1);
			this.grpRipartizioneCosti.Controls.Add(this.txtCodiceRipartizione);
			this.grpRipartizioneCosti.Location = new System.Drawing.Point(563, 242);
			this.grpRipartizioneCosti.Name = "grpRipartizioneCosti";
			this.grpRipartizioneCosti.Size = new System.Drawing.Size(262, 99);
			this.grpRipartizioneCosti.TabIndex = 56;
			this.grpRipartizioneCosti.TabStop = false;
			this.grpRipartizioneCosti.Tag = "AutoChoose.txtCodiceRipartizione.default.(active=\'S\')";
			this.grpRipartizioneCosti.Text = "Ripartizione dei Costi";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(8, 41);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(93, 23);
			this.button3.TabIndex = 4;
			this.button3.Tag = "choose.costpartition.default.(active=\'S\')";
			this.button3.Text = "Codice";
			this.button3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(107, 16);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(149, 52);
			this.textBox1.TabIndex = 3;
			this.textBox1.TabStop = false;
			this.textBox1.Tag = "costpartition.title";
			// 
			// txtCodiceRipartizione
			// 
			this.txtCodiceRipartizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCodiceRipartizione.Location = new System.Drawing.Point(8, 73);
			this.txtCodiceRipartizione.Name = "txtCodiceRipartizione";
			this.txtCodiceRipartizione.Size = new System.Drawing.Size(248, 20);
			this.txtCodiceRipartizione.TabIndex = 2;
			this.txtCodiceRipartizione.Tag = "costpartition.costpartitioncode?x";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.cmbCausale);
			this.groupBox2.Location = new System.Drawing.Point(341, 45);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(472, 46);
			this.groupBox2.TabIndex = 71;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Fonte di Finanziamento";
			// 
			// cmbCausale
			// 
			this.cmbCausale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbCausale.DataSource = this.DS.tipomovimento;
			this.cmbCausale.DisplayMember = "descrizione";
			this.cmbCausale.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
			this.cmbCausale.ItemHeight = 13;
			this.cmbCausale.Location = new System.Drawing.Point(10, 19);
			this.cmbCausale.Name = "cmbCausale";
			this.cmbCausale.Size = new System.Drawing.Size(456, 21);
			this.cmbCausale.TabIndex = 70;
			this.cmbCausale.Tag = "accountvardetail.underwritingkind";
			this.cmbCausale.ValueMember = "idtipo";
			// 
			// grpPrevCassaDI
			// 
			this.grpPrevCassaDI.Controls.Add(this.textBox2);
			this.grpPrevCassaDI.Location = new System.Drawing.Point(340, 93);
			this.grpPrevCassaDI.Name = "grpPrevCassaDI";
			this.grpPrevCassaDI.Size = new System.Drawing.Size(149, 43);
			this.grpPrevCassaDI.TabIndex = 72;
			this.grpPrevCassaDI.TabStop = false;
			this.grpPrevCassaDI.Tag = "";
			this.grpPrevCassaDI.Text = "Prev. Cassa DI 394/2017";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(6, 18);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(130, 20);
			this.textBox2.TabIndex = 1;
			this.textBox2.Tag = "accountvardetail.prevcassa";
			// 
			// grpInventario
			// 
			this.grpInventario.Controls.Add(this.txtDescClassif);
			this.grpInventario.Controls.Add(this.txtCodClassif);
			this.grpInventario.Controls.Add(this.btnClassif);
			this.grpInventario.Location = new System.Drawing.Point(12, 468);
			this.grpInventario.Name = "grpInventario";
			this.grpInventario.Size = new System.Drawing.Size(354, 97);
			this.grpInventario.TabIndex = 73;
			this.grpInventario.TabStop = false;
			this.grpInventario.Tag = "AutoManage.txtCodClassif.tree";
			this.grpInventario.Text = "Inventario";
			// 
			// txtDescClassif
			// 
			this.txtDescClassif.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescClassif.Location = new System.Drawing.Point(116, 11);
			this.txtDescClassif.Multiline = true;
			this.txtDescClassif.Name = "txtDescClassif";
			this.txtDescClassif.ReadOnly = true;
			this.txtDescClassif.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDescClassif.Size = new System.Drawing.Size(232, 56);
			this.txtDescClassif.TabIndex = 2;
			this.txtDescClassif.Tag = "inventorytreeview.description";
			// 
			// txtCodClassif
			// 
			this.txtCodClassif.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCodClassif.Location = new System.Drawing.Point(6, 73);
			this.txtCodClassif.Name = "txtCodClassif";
			this.txtCodClassif.Size = new System.Drawing.Size(340, 20);
			this.txtCodClassif.TabIndex = 9;
			this.txtCodClassif.Tag = "inventorytreeview.codeinv?x";
			// 
			// btnClassif
			// 
			this.btnClassif.Location = new System.Drawing.Point(9, 44);
			this.btnClassif.Name = "btnClassif";
			this.btnClassif.Size = new System.Drawing.Size(88, 23);
			this.btnClassif.TabIndex = 3;
			this.btnClassif.TabStop = false;
			this.btnClassif.Tag = "manage.inventorytreeview.tree";
			this.btnClassif.Text = "Classificazione";
			// 
			// btnSpalmaPrevisioni
			// 
			this.btnSpalmaPrevisioni.Location = new System.Drawing.Point(504, 108);
			this.btnSpalmaPrevisioni.Name = "btnSpalmaPrevisioni";
			this.btnSpalmaPrevisioni.Size = new System.Drawing.Size(217, 23);
			this.btnSpalmaPrevisioni.TabIndex = 74;
			this.btnSpalmaPrevisioni.Text = "Ripartisci previsione pluriennale";
			this.btnSpalmaPrevisioni.UseVisualStyleBackColor = true;
			this.btnSpalmaPrevisioni.Click += new System.EventHandler(this.btnSpalmaPrevisioni_Click);
			// 
			// txtNumDettaglio
			// 
			this.txtNumDettaglio.Location = new System.Drawing.Point(580, 22);
			this.txtNumDettaglio.Name = "txtNumDettaglio";
			this.txtNumDettaglio.ReadOnly = true;
			this.txtNumDettaglio.Size = new System.Drawing.Size(77, 20);
			this.txtNumDettaglio.TabIndex = 75;
			this.txtNumDettaglio.Tag = "accountvardetail.rownum";
			// 
			// labelNumDett
			// 
			this.labelNumDett.AutoSize = true;
			this.labelNumDett.Location = new System.Drawing.Point(578, 9);
			this.labelNumDett.Name = "labelNumDett";
			this.labelNumDett.Size = new System.Drawing.Size(77, 13);
			this.labelNumDett.TabIndex = 76;
			this.labelNumDett.Text = "Num. Dettaglio";
			// 
			// Frm_accountvardetail_single
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(837, 589);
			this.Controls.Add(this.labelNumDett);
			this.Controls.Add(this.txtNumDettaglio);
			this.Controls.Add(this.btnSpalmaPrevisioni);
			this.Controls.Add(this.grpInventario);
			this.Controls.Add(this.grpPrevCassaDI);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.grpRipartizioneCosti);
			this.Controls.Add(this.gboxclass3);
			this.Controls.Add(this.gboxclass2);
			this.Controls.Add(this.gboxclass1);
			this.Controls.Add(this.txtTotale);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.gboxUPB);
			this.Controls.Add(this.gboxConto);
			this.Controls.Add(this.grpImporto5);
			this.Controls.Add(this.grpImporto4);
			this.Controls.Add(this.grpImporto3);
			this.Controls.Add(this.grpImporto2);
			this.Controls.Add(this.grpImporto1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtDescrizione);
			this.Controls.Add(this.btnAnnulla);
			this.Controls.Add(this.btnOK);
			this.Name = "Frm_accountvardetail_single";
			this.Text = "Frm_accountvardetail_single";
			this.grpImporto5.ResumeLayout(false);
			this.grpImporto5.PerformLayout();
			this.grpImporto4.ResumeLayout(false);
			this.grpImporto4.PerformLayout();
			this.grpImporto3.ResumeLayout(false);
			this.grpImporto3.PerformLayout();
			this.grpImporto2.ResumeLayout(false);
			this.grpImporto2.PerformLayout();
			this.grpImporto1.ResumeLayout(false);
			this.grpImporto1.PerformLayout();
			this.gboxUPB.ResumeLayout(false);
			this.gboxUPB.PerformLayout();
			this.gboxConto.ResumeLayout(false);
			this.gboxConto.PerformLayout();
			this.gboxclass3.ResumeLayout(false);
			this.gboxclass3.PerformLayout();
			this.gboxclass2.ResumeLayout(false);
			this.gboxclass2.PerformLayout();
			this.gboxclass1.ResumeLayout(false);
			this.gboxclass1.PerformLayout();
			this.grpRipartizioneCosti.ResumeLayout(false);
			this.grpRipartizioneCosti.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.grpPrevCassaDI.ResumeLayout(false);
			this.grpPrevCassaDI.PerformLayout();
			this.grpInventario.ResumeLayout(false);
			this.grpInventario.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion
	
		public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
             if (R == null) return;
             if (T.TableName == "account")
             {
                 object enable = R["flagenablebudgetprev"];
                 if (enable != DBNull.Value)
                 {
                     if (enable.ToString() == "N")
                     {
                         txtCodiceConto.Text = "";
                         txtDenominazioneConto.Text = "";
                     }

                 }
             }

                
		}


        int varkind = 0;
        bool isprev_iniziale() {
            return (varkind == 5);
        }

        void SetGBoxClass(int num, object sortingkind) {
            if (sortingkind == DBNull.Value) {
                GroupBox G = (GroupBox)GetCtrlByName("gboxclass" + num.ToString());
                G.Visible = false;
            }
            else {
                string filter = QHS.CmpEq("idsorkind", sortingkind);
                GetData.SetStaticFilter(DS.Tables["sorting" + num.ToString()], filter);
                GroupBox gboxclass = (GroupBox)GetCtrlByName("gboxclass" + num.ToString());
                Button btnCodice = (Button)GetCtrlByName("btnCodice" + num.ToString());
                gboxclass.Tag = "AutoManage.txtCodice" + num.ToString() + ".tree." + filter;
                string title = Conn.DO_READ_VALUE("sortingkind", filter, "description").ToString();
                gboxclass.Text = title;
                btnCodice.Tag = "manage.sorting" + num.ToString() + ".tree." + filter;
                DS.Tables["sorting" + num.ToString()].ExtendedProperties[MetaData.ExtraParams] = filter;
            }
        }

        private BudgetFunction bf;

        public void MetaData_AfterLink(){
			Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
			
			bf = new BudgetFunction(this.getInstance<IMetaDataDispatcher>() as MetaDataDispatcher);

            string filter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            string filterenablebudgetprev = QHS.NullOrEq("flagenablebudgetprev", "S");
            GetData.SetStaticFilter(DS.account, QHS.AppAnd(filter, filterenablebudgetprev));
            GetData.SetStaticFilter(DS.accountminusable, QHS.AppAnd(filter, filterenablebudgetprev));
            this.Conn=Meta.Conn;
            DataTable tExpSetup = Conn.RUN_SELECT("config", "*", null, filter, null, null, true);
            SetImportoName();

            DataRow rAccvardetail = Meta.SourceRow;
            DataRow rAccvar = rAccvardetail.GetParentRow("accountvar_accountvardetail");
            varkind = CfgFn.GetNoNullInt32(rAccvar["variationkind"]);

            if (rAccvar.RowState == DataRowState.Modified) {
                int CurrentStatus = CfgFn.GetNoNullInt32(rAccvar["idaccountvarstatus"]);
                int OriginalStatus = CfgFn.GetNoNullInt32(rAccvar["idaccountvarstatus", DataRowVersion.Original]);
                if ((OriginalStatus == 5) || ((CurrentStatus == 5) && (rAccvar.RowState == DataRowState.Modified))) {
                    txtDescrizione.Focus();
                }
            }
            DataAccess.SetTableForReading(DS.sorting1, "sorting");
            DataAccess.SetTableForReading(DS.sorting2, "sorting");
            DataAccess.SetTableForReading(DS.sorting3, "sorting");
            if ((tExpSetup != null) && (tExpSetup.Rows.Count > 0)) {
                DataRow r = tExpSetup.Rows[0];
                object idsorkind1 = r["idsortingkind1"];
                object idsorkind2 = r["idsortingkind2"];
                object idsorkind3 = r["idsortingkind3"];
                SetGBoxClass(1, idsorkind1);
                SetGBoxClass(2, idsorkind2);
                SetGBoxClass(3, idsorkind3);
            }
            GetData.MarkToAddBlankRow(DS.tipomovimento);
            GetData.Add_Blank_Row(DS.tipomovimento);
            EnableTipoMovimento("C", "Contributi da Terzi");
            EnableTipoMovimento("I", "Risorse da indebitamento");
            EnableTipoMovimento("P", "Risorse Proprie");
            PostData.MarkAsTemporaryTable(DS.tipomovimento, false);
            if (isprev_iniziale()) {
                grpPrevCassaDI.Visible = true;
            }
            else {
                grpPrevCassaDI.Visible = false;
            }
        }
        object GetCtrlByName(string Name) {
            System.Reflection.FieldInfo Ctrl = this.GetType().GetField(Name);
            if (Ctrl == null)
                return null;
            return Ctrl.GetValue(this);
        }
        void SetImportoName() {
            int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
            for (int i = 1; i <= 5; i++) {
                GroupBox G = (GroupBox)GetCtrlByName("grpImporto" + i.ToString());
                int N = esercizio + i - 1;
                G.Text = G.Text.Replace("anno", N.ToString());
            }
        }
        void SetEditFonteFinanziamento() {
            if (!Meta.EditMode) return;

            if (DS.Tables["accountvardetail"].Rows[0]["underwritingkind"].Equals(System.DBNull.Value)) return;

            object currtipo = DS.Tables["accountvardetail"].Rows[0]["underwritingkind"];
            HelpForm.SetComboBoxValue(cmbCausale, currtipo);
        }


        void ClearComboFonteFinanziamento() {
            DataTable TCombo = DS.tipomovimento;
            TCombo.Clear();
           
        }

        void EnableTipoMovimento(string IDtipo, string descrtipo) {
            DataRow R = DS.tipomovimento.NewRow();
            R["idtipo"] = IDtipo;
            R["descrizione"] = descrtipo;
            DS.tipomovimento.Rows.Add(R);
            DS.tipomovimento.AcceptChanges();
        }

        public void MetaData_AfterFill() {

            DataRow rAccountvardetail = Meta.SourceRow;
            if (rAccountvardetail == null) return;

            DataRow rAccountvar = rAccountvardetail.GetParentRow("accountvar_accountvardetail");

            if (rAccountvar == null) return;        // Verifica che i DataRow siano valorizzati

            // 5 = Approvata
            if (Meta.InsertMode) {
                btnConto.Enabled = true;
                txtCodiceConto.ReadOnly = false;
                btnUPBCode.Enabled = true;
                txtUPB.ReadOnly = false;
            }
            else {
                int CurrentStatus = CfgFn.GetNoNullInt32(rAccountvar["idaccountvarstatus"]);
                int OriginalStatus = CfgFn.GetNoNullInt32(rAccountvar["idaccountvarstatus", DataRowVersion.Original]);
                if ((OriginalStatus == 5) || ((CurrentStatus == 5) && (rAccountvar.RowState == DataRowState.Modified))) {
                    btnConto.Enabled = false;
                    txtCodiceConto.ReadOnly = true;
                    txtCodiceConto.TabStop = false;
                    btnUPBCode.Enabled = false;
                    txtUPB.TabStop = false;
                    txtUPB.ReadOnly = true;
                }
                else {
                    btnConto.Enabled = true;
                    txtCodiceConto.ReadOnly = false;
                    txtCodiceConto.TabStop = true;
                    btnUPBCode.Enabled = true;
                    txtUPB.ReadOnly = false;
                    txtUPB.TabStop = true;
                }
            }
                      
            CalcolaTotale(false);
            SetEditFonteFinanziamento();
        }


        
        //public void MetaData_AfterFill(){
        //    if (!Meta.InsertMode){
				
        //        txtCodiceConto.Enabled = false;
        //    }
           
        //}

        void CalcolaTotale(bool read) {
            if (Meta == null)
                return;
            if (Meta.IsEmpty)
                return;
            if (DS.accountvardetail.Rows.Count == 0)
                return;
            if (read) Meta.GetFormData(true);
            DataRow R = DS.accountvardetail.Rows[0];
            decimal totale = CfgFn.GetNoNullDecimal(R["amount"]);
            for (int i = 2; i <= 5; i++ ) {
                totale += CfgFn.GetNoNullDecimal(R["amount" + i.ToString()]);
            }
            txtTotale.Text = totale.ToString("c");
        }

        private void txtImportoLeave(object sender, EventArgs e) {
            CalcolaTotale(Meta.DrawStateIsDone);
        }

        private void btnConto_Click(object sender, EventArgs e) {
            string filter="";
            int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
       

            if (chkListTitle.Checked) {
                FrmAskDescr FR = new FrmAskDescr(0);
                DialogResult D = FR.ShowDialog(this);
                if (D != DialogResult.OK) return;
                string filterenablebudgetprev = QHS.NullOrEq("flagenablebudgetprev", "S");
                string filteroperativo = "(idacc in (SELECT idacc from accountminusable where ayear='" +
                                         esercizio + "'))";
                filter = GetData.MergeFilters(filter,
                    "(title like " + QueryCreator.quotedstrvalue(
                    "%" + FR.txtDescrizione.Text + "%", true)) + ")";
                filter = GetData.MergeFilters(filter, filteroperativo);
                filter = GetData.MergeFilters(filter, filterenablebudgetprev);
                MetaData.DoMainCommand(this, "choose.accountminusable.default." + filter);
            }
            else {
                MetaData.DoMainCommand(this, "manage.account.treeminusable");
            }
        }

        private void svuotaOggetti() {
            txtDenominazioneConto.Text = "";
        }

       private void txtCodiceConto_Leave(object sender, EventArgs e) {
            if (inChiusura) return;
            if (Meta == null) return;
            if (!Meta.DrawStateIsDone) return;
            if (txtCodiceConto.Text == "") {
                svuotaOggetti();
                return;
            }
            if (lastCodiceConto == txtCodiceConto.Text) return;

            if (DS.accountvardetail.Rows.Count == 0) return;
            Meta.GetFormData(true);

            string filter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            string Codeacc = txtCodiceConto.Text;
            if (!Codeacc.EndsWith("%")) Codeacc += "%";
            
           string filterenablebudgetprev = QHS.NullOrEq("flagenablebudgetprev", "S");
           filter = QHC.AppAnd(filter, QHS.Like("codeacc", Codeacc),filterenablebudgetprev);

            MetaData MetaAccountminusable = MetaData.GetMetaData(this, "accountminusable");
            MetaAccountminusable.FilterLocked = true;
            MetaAccountminusable.DS = DS.Clone();

            DataRow Choosen = MetaAccountminusable.SelectOne("default", filter, "accountminusable", null);
            if (Choosen == null) {
                txtCodiceConto.Focus();
                lastCodiceConto = null;
                return;
            }

            DataRow Curr = DS.accountvardetail.Rows[0];
            Curr["idacc"] = Choosen["idacc"];
            txtCodiceConto.Text = (Choosen != null) ? Choosen["codeacc"].ToString() : "";
            txtDenominazioneConto.Text = (Choosen != null) ? Choosen["title"].ToString() : "";
        }

        private string lastCodiceConto;
        private void txtCodiceConto_Enter(object sender, EventArgs e) {
            lastCodiceConto = txtCodiceConto.Text;
        }

		private void btnSpalmaPrevisioni_Click(object sender, EventArgs e) {
			Meta.GetFormData(true);
			var r = DS.accountvardetail.Rows[0];
			decimal total = 0;
			foreach (string field in new[] {"amount", "amount2", "amount3", "amount4", "amount5"}) {
				total += CfgFn.GetNoNullDecimal(r[field]);
			}
			var f = new FrmAskDataInizioFine(false);
			var res = f.ShowDialog(this);
			if (res != DialogResult.OK) return;
			DateTime inizio = (DateTime) HelpForm.GetObjectFromString(typeof(DateTime),
				f.txtDataInizio.Text.ToString(), "x.y");
			DateTime fine = (DateTime) HelpForm.GetObjectFromString(typeof(DateTime),
				f.txtDataFine.Text.ToString(), "x.y");

			var split = bf.GetAmounts(total, inizio, fine);
			for (int i = 1; i <= 5; i++) {
				string field = (i == 1) ? "amount" : $"amount{i}";
				var d = split[i-1];
				if (d == 0) {
					r[field] = DBNull.Value;
				}
				else {
					r[field] = d;
				}
			}
			Meta.FreshForm(false);
		}
	}
}
