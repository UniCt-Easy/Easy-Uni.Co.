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
using metadatalibrary;
using System.Data;
using funzioni_configurazione;
using System.Reflection;

namespace accountvardetail_default {
	/// <summary>
	/// Summary description for Frm_accountvardetail_default.
	/// </summary>
	public class Frm_accountvardetail_default : System.Windows.Forms.Form {
		MetaData Meta;
		private DataAccess Conn;
		string filteresercizio;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtProvvedimento;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtNumProvv;
		private System.Windows.Forms.TextBox txtDataProvv;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtDataContabile;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox txtDescrizione;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtNumero;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtEsercizio;
		private System.Windows.Forms.Button btnVariazione;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        public accountvardetail_default.vistaForm DS;
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
        private Label label4;
        private TextBox txtTotale;
        private GroupBox gboxResponsabile;
        public TextBox txtResponsabile;
        private GroupBox gboxStato;
        private ComboBox cmbStatus;
        private GroupBox gboxTipoVariazione;
        private RadioButton rdbVarIniziale;
        private RadioButton rdbVarNormale;
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
        public Button button4;
        public TextBox textBox2;
        public TextBox txtCodiceRipartizione;
        private GroupBox gboxConto;
        private CheckBox chkListTitle;
        private TextBox txtDenominazioneConto;
        private TextBox txtCodiceConto;
        private Button btnConto;
        private GroupBox groupBox2;
        private ComboBox cmbCausale;
        private RadioButton rdbVarStorno;
        private RadioButton rdbVarAssestamento;
        private GroupBox gboxAtto;
        private Button btnScegliAtto;
        private TextBox txtNact;
        private TextBox txtPrevCassaDI;
        private Label lblPrevCassaDI;
		private GroupBox grpInventario;
		private TextBox txtDescClassif;
		private TextBox txtCodClassif;
		private Button btnClassif;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_accountvardetail_default() {
			InitializeComponent();
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtProvvedimento = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtNumProvv = new System.Windows.Forms.TextBox();
			this.txtDataProvv = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtDataContabile = new System.Windows.Forms.TextBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.txtDescrizione = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtNumero = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtEsercizio = new System.Windows.Forms.TextBox();
			this.btnVariazione = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.DS = new accountvardetail_default.vistaForm();
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
			this.label4 = new System.Windows.Forms.Label();
			this.txtTotale = new System.Windows.Forms.TextBox();
			this.gboxResponsabile = new System.Windows.Forms.GroupBox();
			this.txtResponsabile = new System.Windows.Forms.TextBox();
			this.gboxStato = new System.Windows.Forms.GroupBox();
			this.cmbStatus = new System.Windows.Forms.ComboBox();
			this.gboxTipoVariazione = new System.Windows.Forms.GroupBox();
			this.rdbVarAssestamento = new System.Windows.Forms.RadioButton();
			this.rdbVarStorno = new System.Windows.Forms.RadioButton();
			this.rdbVarIniziale = new System.Windows.Forms.RadioButton();
			this.rdbVarNormale = new System.Windows.Forms.RadioButton();
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
			this.button4 = new System.Windows.Forms.Button();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.txtCodiceRipartizione = new System.Windows.Forms.TextBox();
			this.gboxConto = new System.Windows.Forms.GroupBox();
			this.chkListTitle = new System.Windows.Forms.CheckBox();
			this.txtDenominazioneConto = new System.Windows.Forms.TextBox();
			this.txtCodiceConto = new System.Windows.Forms.TextBox();
			this.btnConto = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.cmbCausale = new System.Windows.Forms.ComboBox();
			this.gboxAtto = new System.Windows.Forms.GroupBox();
			this.btnScegliAtto = new System.Windows.Forms.Button();
			this.txtNact = new System.Windows.Forms.TextBox();
			this.txtPrevCassaDI = new System.Windows.Forms.TextBox();
			this.lblPrevCassaDI = new System.Windows.Forms.Label();
			this.grpInventario = new System.Windows.Forms.GroupBox();
			this.txtDescClassif = new System.Windows.Forms.TextBox();
			this.txtCodClassif = new System.Windows.Forms.TextBox();
			this.btnClassif = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.grpImporto5.SuspendLayout();
			this.grpImporto4.SuspendLayout();
			this.grpImporto3.SuspendLayout();
			this.grpImporto2.SuspendLayout();
			this.grpImporto1.SuspendLayout();
			this.gboxUPB.SuspendLayout();
			this.gboxResponsabile.SuspendLayout();
			this.gboxStato.SuspendLayout();
			this.gboxTipoVariazione.SuspendLayout();
			this.gboxclass3.SuspendLayout();
			this.gboxclass2.SuspendLayout();
			this.gboxclass1.SuspendLayout();
			this.grpRipartizioneCosti.SuspendLayout();
			this.gboxConto.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.gboxAtto.SuspendLayout();
			this.grpInventario.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtProvvedimento);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.txtNumProvv);
			this.groupBox1.Controls.Add(this.txtDataProvv);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Location = new System.Drawing.Point(456, 81);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(364, 103);
			this.groupBox1.TabIndex = 33;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Provvedimento";
			// 
			// txtProvvedimento
			// 
			this.txtProvvedimento.Location = new System.Drawing.Point(8, 16);
			this.txtProvvedimento.Multiline = true;
			this.txtProvvedimento.Name = "txtProvvedimento";
			this.txtProvvedimento.ReadOnly = true;
			this.txtProvvedimento.Size = new System.Drawing.Size(350, 40);
			this.txtProvvedimento.TabIndex = 15;
			this.txtProvvedimento.TabStop = false;
			this.txtProvvedimento.Tag = "accountvar.enactment";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(186, 64);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(64, 16);
			this.label7.TabIndex = 20;
			this.label7.Text = "Num. provv";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtNumProvv
			// 
			this.txtNumProvv.Location = new System.Drawing.Point(256, 63);
			this.txtNumProvv.Name = "txtNumProvv";
			this.txtNumProvv.ReadOnly = true;
			this.txtNumProvv.Size = new System.Drawing.Size(102, 20);
			this.txtNumProvv.TabIndex = 21;
			this.txtNumProvv.TabStop = false;
			this.txtNumProvv.Tag = "accountvar.nenactment";
			// 
			// txtDataProvv
			// 
			this.txtDataProvv.Location = new System.Drawing.Point(93, 63);
			this.txtDataProvv.Name = "txtDataProvv";
			this.txtDataProvv.ReadOnly = true;
			this.txtDataProvv.Size = new System.Drawing.Size(87, 20);
			this.txtDataProvv.TabIndex = 17;
			this.txtDataProvv.TabStop = false;
			this.txtDataProvv.Tag = "accountvar.enactmentdate";
			this.txtDataProvv.TextChanged += new System.EventHandler(this.txtDataProvv_TextChanged);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(15, 64);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(72, 16);
			this.label6.TabIndex = 16;
			this.label6.Text = "Data provv.:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDataContabile
			// 
			this.txtDataContabile.Location = new System.Drawing.Point(740, 285);
			this.txtDataContabile.Name = "txtDataContabile";
			this.txtDataContabile.ReadOnly = true;
			this.txtDataContabile.Size = new System.Drawing.Size(80, 20);
			this.txtDataContabile.TabIndex = 40;
			this.txtDataContabile.TabStop = false;
			this.txtDataContabile.Tag = "accountvar.adate";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(13, 152);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(424, 56);
			this.textBox1.TabIndex = 2;
			this.textBox1.Tag = "accountvardetail.description";
			// 
			// txtDescrizione
			// 
			this.txtDescrizione.Location = new System.Drawing.Point(13, 81);
			this.txtDescrizione.Multiline = true;
			this.txtDescrizione.Name = "txtDescrizione";
			this.txtDescrizione.ReadOnly = true;
			this.txtDescrizione.Size = new System.Drawing.Size(430, 50);
			this.txtDescrizione.TabIndex = 38;
			this.txtDescrizione.TabStop = false;
			this.txtDescrizione.Tag = "accountvar.description";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(740, 264);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(80, 18);
			this.label5.TabIndex = 39;
			this.label5.Text = "Data contabile:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.label1);
			this.groupBox5.Controls.Add(this.txtNumero);
			this.groupBox5.Controls.Add(this.label3);
			this.groupBox5.Controls.Add(this.txtEsercizio);
			this.groupBox5.Controls.Add(this.btnVariazione);
			this.groupBox5.Location = new System.Drawing.Point(12, 7);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(375, 49);
			this.groupBox5.TabIndex = 1;
			this.groupBox5.TabStop = false;
			this.groupBox5.Tag = "AutoChoose.txtNumero.default";
			this.groupBox5.Text = "Dati variazione";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(104, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 16);
			this.label1.TabIndex = 4;
			this.label1.Text = "Esercizio:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtNumero
			// 
			this.txtNumero.Location = new System.Drawing.Point(296, 16);
			this.txtNumero.Name = "txtNumero";
			this.txtNumero.Size = new System.Drawing.Size(64, 20);
			this.txtNumero.TabIndex = 2;
			this.txtNumero.Tag = "accountvar.nvar?accountvardetailview.nvar";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(240, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 16);
			this.label3.TabIndex = 8;
			this.label3.Text = "Numero:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtEsercizio
			// 
			this.txtEsercizio.Location = new System.Drawing.Point(160, 16);
			this.txtEsercizio.Name = "txtEsercizio";
			this.txtEsercizio.ReadOnly = true;
			this.txtEsercizio.Size = new System.Drawing.Size(64, 20);
			this.txtEsercizio.TabIndex = 5;
			this.txtEsercizio.TabStop = false;
			this.txtEsercizio.Tag = "";
			this.txtEsercizio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btnVariazione
			// 
			this.btnVariazione.Location = new System.Drawing.Point(16, 16);
			this.btnVariazione.Name = "btnVariazione";
			this.btnVariazione.Size = new System.Drawing.Size(72, 23);
			this.btnVariazione.TabIndex = 1;
			this.btnVariazione.Tag = "choose.accountvar.default";
			this.btnVariazione.Text = "Variazione";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(4, 51);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(128, 32);
			this.label2.TabIndex = 37;
			this.label2.Text = "Descrizione Variazione:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(9, 134);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(120, 22);
			this.label8.TabIndex = 41;
			this.label8.Text = "Descrizione dettaglio:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// grpImporto5
			// 
			this.grpImporto5.Controls.Add(this.radioButton7);
			this.grpImporto5.Controls.Add(this.radioButton8);
			this.grpImporto5.Controls.Add(this.txtImporto5);
			this.grpImporto5.Location = new System.Drawing.Point(676, 310);
			this.grpImporto5.Name = "grpImporto5";
			this.grpImporto5.Size = new System.Drawing.Size(148, 88);
			this.grpImporto5.TabIndex = 7;
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
			this.grpImporto4.Location = new System.Drawing.Point(512, 310);
			this.grpImporto4.Name = "grpImporto4";
			this.grpImporto4.Size = new System.Drawing.Size(148, 88);
			this.grpImporto4.TabIndex = 6;
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
			this.grpImporto3.Location = new System.Drawing.Point(345, 310);
			this.grpImporto3.Name = "grpImporto3";
			this.grpImporto3.Size = new System.Drawing.Size(148, 88);
			this.grpImporto3.TabIndex = 5;
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
			this.grpImporto2.Location = new System.Drawing.Point(179, 310);
			this.grpImporto2.Name = "grpImporto2";
			this.grpImporto2.Size = new System.Drawing.Size(148, 88);
			this.grpImporto2.TabIndex = 4;
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
			this.grpImporto1.Location = new System.Drawing.Point(15, 310);
			this.grpImporto1.Name = "grpImporto1";
			this.grpImporto1.Size = new System.Drawing.Size(148, 88);
			this.grpImporto1.TabIndex = 3;
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
			this.gboxUPB.Location = new System.Drawing.Point(287, 404);
			this.gboxUPB.Name = "gboxUPB";
			this.gboxUPB.Size = new System.Drawing.Size(265, 104);
			this.gboxUPB.TabIndex = 9;
			this.gboxUPB.TabStop = false;
			this.gboxUPB.Tag = "AutoChoose.txtUPB.default.(active=\'S\')";
			// 
			// txtUPB
			// 
			this.txtUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtUPB.Location = new System.Drawing.Point(8, 77);
			this.txtUPB.Name = "txtUPB";
			this.txtUPB.Size = new System.Drawing.Size(248, 20);
			this.txtUPB.TabIndex = 5;
			this.txtUPB.Tag = "upb.codeupb?x";
			// 
			// txtDescrUPB
			// 
			this.txtDescrUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescrUPB.Location = new System.Drawing.Point(128, 9);
			this.txtDescrUPB.Multiline = true;
			this.txtDescrUPB.Name = "txtDescrUPB";
			this.txtDescrUPB.ReadOnly = true;
			this.txtDescrUPB.Size = new System.Drawing.Size(128, 62);
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
			this.btnUPBCode.UseVisualStyleBackColor = false;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(615, 269);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(91, 13);
			this.label4.TabIndex = 49;
			this.label4.Text = "Totale pluriennale";
			// 
			// txtTotale
			// 
			this.txtTotale.Location = new System.Drawing.Point(618, 285);
			this.txtTotale.Name = "txtTotale";
			this.txtTotale.ReadOnly = true;
			this.txtTotale.Size = new System.Drawing.Size(104, 20);
			this.txtTotale.TabIndex = 50;
			this.txtTotale.Tag = "";
			this.txtTotale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// gboxResponsabile
			// 
			this.gboxResponsabile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxResponsabile.Controls.Add(this.txtResponsabile);
			this.gboxResponsabile.Location = new System.Drawing.Point(15, 267);
			this.gboxResponsabile.Name = "gboxResponsabile";
			this.gboxResponsabile.Size = new System.Drawing.Size(422, 40);
			this.gboxResponsabile.TabIndex = 53;
			this.gboxResponsabile.TabStop = false;
			this.gboxResponsabile.Tag = "AutoChoose.txtResponsabile.default.(financeactive=\'S\')";
			this.gboxResponsabile.Text = "Responsabile";
			// 
			// txtResponsabile
			// 
			this.txtResponsabile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtResponsabile.Location = new System.Drawing.Point(11, 14);
			this.txtResponsabile.Name = "txtResponsabile";
			this.txtResponsabile.Size = new System.Drawing.Size(401, 20);
			this.txtResponsabile.TabIndex = 0;
			this.txtResponsabile.Tag = "manager.title?x";
			// 
			// gboxStato
			// 
			this.gboxStato.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxStato.Controls.Add(this.cmbStatus);
			this.gboxStato.Location = new System.Drawing.Point(569, 12);
			this.gboxStato.Name = "gboxStato";
			this.gboxStato.Size = new System.Drawing.Size(264, 44);
			this.gboxStato.TabIndex = 51;
			this.gboxStato.TabStop = false;
			this.gboxStato.Text = "Stato";
			// 
			// cmbStatus
			// 
			this.cmbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbStatus.DataSource = this.DS.accountvarstatus;
			this.cmbStatus.DisplayMember = "description";
			this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbStatus.Location = new System.Drawing.Point(6, 15);
			this.cmbStatus.Name = "cmbStatus";
			this.cmbStatus.Size = new System.Drawing.Size(251, 21);
			this.cmbStatus.TabIndex = 43;
			this.cmbStatus.Tag = "accountvar.idaccountvarstatus?accountvardetailview.idaccountvarstatus";
			this.cmbStatus.ValueMember = "idaccountvarstatus";
			// 
			// gboxTipoVariazione
			// 
			this.gboxTipoVariazione.Controls.Add(this.rdbVarAssestamento);
			this.gboxTipoVariazione.Controls.Add(this.rdbVarStorno);
			this.gboxTipoVariazione.Controls.Add(this.rdbVarIniziale);
			this.gboxTipoVariazione.Controls.Add(this.rdbVarNormale);
			this.gboxTipoVariazione.Location = new System.Drawing.Point(393, 7);
			this.gboxTipoVariazione.Name = "gboxTipoVariazione";
			this.gboxTipoVariazione.Size = new System.Drawing.Size(173, 68);
			this.gboxTipoVariazione.TabIndex = 54;
			this.gboxTipoVariazione.TabStop = false;
			this.gboxTipoVariazione.Text = "Tipo variazione";
			// 
			// rdbVarAssestamento
			// 
			this.rdbVarAssestamento.AutoSize = true;
			this.rdbVarAssestamento.Location = new System.Drawing.Point(79, 45);
			this.rdbVarAssestamento.Name = "rdbVarAssestamento";
			this.rdbVarAssestamento.Size = new System.Drawing.Size(91, 17);
			this.rdbVarAssestamento.TabIndex = 6;
			this.rdbVarAssestamento.Tag = "accountvar.variationkind:3?accountvardetailview.variationkind:3";
			this.rdbVarAssestamento.Text = "Assestamento";
			this.rdbVarAssestamento.UseVisualStyleBackColor = true;
			// 
			// rdbVarStorno
			// 
			this.rdbVarStorno.Location = new System.Drawing.Point(8, 44);
			this.rdbVarStorno.Name = "rdbVarStorno";
			this.rdbVarStorno.Size = new System.Drawing.Size(71, 16);
			this.rdbVarStorno.TabIndex = 5;
			this.rdbVarStorno.Tag = "accountvar.variationkind:4?accountvardetailview.variationkind:4";
			this.rdbVarStorno.Text = "Storno";
			// 
			// rdbVarIniziale
			// 
			this.rdbVarIniziale.AutoSize = true;
			this.rdbVarIniziale.Location = new System.Drawing.Point(85, 16);
			this.rdbVarIniziale.Name = "rdbVarIniziale";
			this.rdbVarIniziale.Size = new System.Drawing.Size(57, 17);
			this.rdbVarIniziale.TabIndex = 4;
			this.rdbVarIniziale.Tag = "accountvar.variationkind:5?accountvardetailview.variationkind:5";
			this.rdbVarIniziale.Text = "Iniziale";
			this.rdbVarIniziale.UseVisualStyleBackColor = true;
			// 
			// rdbVarNormale
			// 
			this.rdbVarNormale.Location = new System.Drawing.Point(8, 16);
			this.rdbVarNormale.Name = "rdbVarNormale";
			this.rdbVarNormale.Size = new System.Drawing.Size(71, 16);
			this.rdbVarNormale.TabIndex = 0;
			this.rdbVarNormale.Tag = "accountvar.variationkind:1?accountvardetailview.variationkind:1";
			this.rdbVarNormale.Text = "Normale";
			// 
			// gboxclass3
			// 
			this.gboxclass3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxclass3.Controls.Add(this.btnCodice3);
			this.gboxclass3.Controls.Add(this.txtDenom3);
			this.gboxclass3.Controls.Add(this.txtCodice3);
			this.gboxclass3.Location = new System.Drawing.Point(561, 511);
			this.gboxclass3.Name = "gboxclass3";
			this.gboxclass3.Size = new System.Drawing.Size(259, 108);
			this.gboxclass3.TabIndex = 58;
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
			this.txtDenom3.Location = new System.Drawing.Point(115, 24);
			this.txtDenom3.Multiline = true;
			this.txtDenom3.Name = "txtDenom3";
			this.txtDenom3.ReadOnly = true;
			this.txtDenom3.Size = new System.Drawing.Size(138, 56);
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
			this.txtCodice3.Size = new System.Drawing.Size(247, 20);
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
			this.gboxclass2.Location = new System.Drawing.Point(287, 511);
			this.gboxclass2.Name = "gboxclass2";
			this.gboxclass2.Size = new System.Drawing.Size(265, 108);
			this.gboxclass2.TabIndex = 57;
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
			this.txtDenom2.Location = new System.Drawing.Point(128, 24);
			this.txtDenom2.Multiline = true;
			this.txtDenom2.Name = "txtDenom2";
			this.txtDenom2.ReadOnly = true;
			this.txtDenom2.Size = new System.Drawing.Size(129, 55);
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
			this.gboxclass1.Location = new System.Drawing.Point(15, 513);
			this.gboxclass1.Name = "gboxclass1";
			this.gboxclass1.Size = new System.Drawing.Size(266, 108);
			this.gboxclass1.TabIndex = 56;
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
			this.txtDenom1.Size = new System.Drawing.Size(130, 55);
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
			this.txtCodice1.Size = new System.Drawing.Size(252, 20);
			this.txtCodice1.TabIndex = 2;
			this.txtCodice1.Tag = "sorting1.sortcode?x";
			// 
			// grpRipartizioneCosti
			// 
			this.grpRipartizioneCosti.Controls.Add(this.button4);
			this.grpRipartizioneCosti.Controls.Add(this.textBox2);
			this.grpRipartizioneCosti.Controls.Add(this.txtCodiceRipartizione);
			this.grpRipartizioneCosti.Location = new System.Drawing.Point(561, 404);
			this.grpRipartizioneCosti.Name = "grpRipartizioneCosti";
			this.grpRipartizioneCosti.Size = new System.Drawing.Size(267, 104);
			this.grpRipartizioneCosti.TabIndex = 59;
			this.grpRipartizioneCosti.TabStop = false;
			this.grpRipartizioneCosti.Tag = "AutoChoose.txtCodiceRipartizione.default.(active=\'S\')";
			this.grpRipartizioneCosti.Text = "Ripartizione dei Costi";
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(8, 34);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(88, 23);
			this.button4.TabIndex = 4;
			this.button4.Tag = "choose.costpartition.default.(active=\'S\')";
			this.button4.Text = "Codice";
			this.button4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// textBox2
			// 
			this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox2.Location = new System.Drawing.Point(115, 13);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.Size = new System.Drawing.Size(144, 56);
			this.textBox2.TabIndex = 3;
			this.textBox2.TabStop = false;
			this.textBox2.Tag = "costpartition.title";
			// 
			// txtCodiceRipartizione
			// 
			this.txtCodiceRipartizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCodiceRipartizione.Location = new System.Drawing.Point(8, 74);
			this.txtCodiceRipartizione.Name = "txtCodiceRipartizione";
			this.txtCodiceRipartizione.Size = new System.Drawing.Size(251, 20);
			this.txtCodiceRipartizione.TabIndex = 2;
			this.txtCodiceRipartizione.Tag = "costpartition.costpartitioncode?x";
			// 
			// gboxConto
			// 
			this.gboxConto.Controls.Add(this.chkListTitle);
			this.gboxConto.Controls.Add(this.txtDenominazioneConto);
			this.gboxConto.Controls.Add(this.txtCodiceConto);
			this.gboxConto.Controls.Add(this.btnConto);
			this.gboxConto.Location = new System.Drawing.Point(15, 398);
			this.gboxConto.Name = "gboxConto";
			this.gboxConto.Size = new System.Drawing.Size(266, 113);
			this.gboxConto.TabIndex = 60;
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
			this.txtDenominazioneConto.Size = new System.Drawing.Size(124, 56);
			this.txtDenominazioneConto.TabIndex = 2;
			this.txtDenominazioneConto.TabStop = false;
			this.txtDenominazioneConto.Tag = "accountminusable.title";
			// 
			// txtCodiceConto
			// 
			this.txtCodiceConto.Location = new System.Drawing.Point(6, 87);
			this.txtCodiceConto.Name = "txtCodiceConto";
			this.txtCodiceConto.Size = new System.Drawing.Size(252, 20);
			this.txtCodiceConto.TabIndex = 1;
			this.txtCodiceConto.Tag = "accountminusable.codeacc?accountvardetail.codeacc";
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
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.cmbCausale);
			this.groupBox2.Location = new System.Drawing.Point(13, 215);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(424, 46);
			this.groupBox2.TabIndex = 70;
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
			this.cmbCausale.Size = new System.Drawing.Size(408, 21);
			this.cmbCausale.TabIndex = 70;
			this.cmbCausale.Tag = "accountvardetail.underwritingkind";
			this.cmbCausale.ValueMember = "idtipo";
			// 
			// gboxAtto
			// 
			this.gboxAtto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxAtto.Controls.Add(this.btnScegliAtto);
			this.gboxAtto.Controls.Add(this.txtNact);
			this.gboxAtto.Location = new System.Drawing.Point(456, 190);
			this.gboxAtto.Name = "gboxAtto";
			this.gboxAtto.Size = new System.Drawing.Size(364, 44);
			this.gboxAtto.TabIndex = 71;
			this.gboxAtto.TabStop = false;
			this.gboxAtto.Tag = "AutoChoose.txtNact.default";
			// 
			// btnScegliAtto
			// 
			this.btnScegliAtto.Location = new System.Drawing.Point(6, 15);
			this.btnScegliAtto.Name = "btnScegliAtto";
			this.btnScegliAtto.Size = new System.Drawing.Size(133, 23);
			this.btnScegliAtto.TabIndex = 13;
			this.btnScegliAtto.TabStop = false;
			this.btnScegliAtto.Tag = "choose.enactment.default";
			this.btnScegliAtto.Text = "Atto Amministrativo";
			this.btnScegliAtto.UseVisualStyleBackColor = true;
			// 
			// txtNact
			// 
			this.txtNact.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtNact.Location = new System.Drawing.Point(145, 15);
			this.txtNact.Name = "txtNact";
			this.txtNact.Size = new System.Drawing.Size(212, 20);
			this.txtNact.TabIndex = 10;
			this.txtNact.Tag = "accountenactment.nenactment?accountvardetailview.enactmentnumber";
			// 
			// txtPrevCassaDI
			// 
			this.txtPrevCassaDI.Location = new System.Drawing.Point(484, 285);
			this.txtPrevCassaDI.Name = "txtPrevCassaDI";
			this.txtPrevCassaDI.ReadOnly = true;
			this.txtPrevCassaDI.Size = new System.Drawing.Size(119, 20);
			this.txtPrevCassaDI.TabIndex = 1;
			this.txtPrevCassaDI.Tag = "accountvardetail.prevcassa";
			// 
			// lblPrevCassaDI
			// 
			this.lblPrevCassaDI.AutoSize = true;
			this.lblPrevCassaDI.Location = new System.Drawing.Point(475, 269);
			this.lblPrevCassaDI.Name = "lblPrevCassaDI";
			this.lblPrevCassaDI.Size = new System.Drawing.Size(128, 13);
			this.lblPrevCassaDI.TabIndex = 72;
			this.lblPrevCassaDI.Text = "Prev. Cassa DI 394/2017";
			// 
			// grpInventario
			// 
			this.grpInventario.Controls.Add(this.txtDescClassif);
			this.grpInventario.Controls.Add(this.txtCodClassif);
			this.grpInventario.Controls.Add(this.btnClassif);
			this.grpInventario.Location = new System.Drawing.Point(18, 627);
			this.grpInventario.Name = "grpInventario";
			this.grpInventario.Size = new System.Drawing.Size(354, 97);
			this.grpInventario.TabIndex = 74;
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
			// Frm_accountvardetail_default
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(840, 735);
			this.Controls.Add(this.grpInventario);
			this.Controls.Add(this.lblPrevCassaDI);
			this.Controls.Add(this.txtPrevCassaDI);
			this.Controls.Add(this.gboxAtto);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.gboxConto);
			this.Controls.Add(this.grpRipartizioneCosti);
			this.Controls.Add(this.gboxclass3);
			this.Controls.Add(this.gboxStato);
			this.Controls.Add(this.gboxclass2);
			this.Controls.Add(this.gboxclass1);
			this.Controls.Add(this.gboxTipoVariazione);
			this.Controls.Add(this.gboxResponsabile);
			this.Controls.Add(this.txtTotale);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.gboxUPB);
			this.Controls.Add(this.grpImporto5);
			this.Controls.Add(this.grpImporto4);
			this.Controls.Add(this.grpImporto3);
			this.Controls.Add(this.grpImporto2);
			this.Controls.Add(this.grpImporto1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.txtDataContabile);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.txtDescrizione);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label8);
			this.Name = "Frm_accountvardetail_default";
			this.Text = "Frm_accountvardetail_default";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
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
			this.gboxResponsabile.ResumeLayout(false);
			this.gboxResponsabile.PerformLayout();
			this.gboxStato.ResumeLayout(false);
			this.gboxTipoVariazione.ResumeLayout(false);
			this.gboxTipoVariazione.PerformLayout();
			this.gboxclass3.ResumeLayout(false);
			this.gboxclass3.PerformLayout();
			this.gboxclass2.ResumeLayout(false);
			this.gboxclass2.PerformLayout();
			this.gboxclass1.ResumeLayout(false);
			this.gboxclass1.PerformLayout();
			this.grpRipartizioneCosti.ResumeLayout(false);
			this.grpRipartizioneCosti.PerformLayout();
			this.gboxConto.ResumeLayout(false);
			this.gboxConto.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.gboxAtto.ResumeLayout(false);
			this.gboxAtto.PerformLayout();
			this.grpInventario.ResumeLayout(false);
			this.grpInventario.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

        QueryHelper QHS;
        CQueryHelper QHC;
		public void MetaData_AfterLink(){
			Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();

			filteresercizio = QHS.CmpEq("ayear",Meta.GetSys("esercizio"));
			string filteresercvar = QHS.CmpEq("yvar",Meta.GetSys("esercizio"));
            GetData.SetStaticFilter(DS.account, filteresercizio);
            GetData.SetStaticFilter(DS.accountminusable, filteresercizio);
            GetData.SetStaticFilter(DS.accountvar, filteresercvar);
			GetData.SetStaticFilter(DS.accountvardetail, filteresercvar);
            GetData.SetStaticFilter(DS.accountenactment, QHS.CmpEq("yenactment", Meta.Conn.GetSys("esercizio")));
            //GetData.CacheTable(DS.sortingkind,null,null,true);
            txtEsercizio.Text= Meta.GetSys("esercizio").ToString();
			this.Conn=Meta.Conn;
            DataTable tExpSetup = Conn.RUN_SELECT("config", "*", null, filteresercizio, null, null, true);
            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
            SetImportoName();
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

        }
        bool isprev_iniziale(int varkind) {
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
        object GetCtrlByName(string Name) {
            System.Reflection.FieldInfo Ctrl = this.GetType().GetField(Name);
            if (Ctrl == null)
                return null;
            return Ctrl.GetValue(this);
        }

        void SetImportoName() {
            int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
            for (int i = 1; i <= 5; i++) {
                GroupBox G = (GroupBox) GetCtrlByName("grpImporto" + i.ToString());
                int N= esercizio+i-1;
                G.Text = G.Text.Replace("anno", N.ToString());
            }
        }

        void SetEditFonteFinanziamento() {

            //ClearComboFonteFinanziamento();

            if (!Meta.EditMode) return;
            //cmbCausale.SelectedValue= DS.Tables["ordinegenericomovspesa"].Rows[0]["tipomovimento"].ToString();
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
        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
			
        }

        public void MetaData_AfterClear() {
            txtTotale.Text = "";
            gboxTipoVariazione.Enabled = true;
            gboxResponsabile.Enabled = true;
            gboxStato.Enabled = true;
            gboxConto.Enabled = true;
            gboxUPB.Enabled = true;
            grpRipartizioneCosti.Enabled = true;
			grpInventario.Enabled = true;
			lblPrevCassaDI.Visible = true;
            txtPrevCassaDI.Visible = true;
        }

        public void MetaData_AfterFill(){
            //if (!Meta.InsertMode)
            //{
            //    // Come nel vecchio codice le info relative al bilancio sono editabili solo in fase di inserimento				
            //    btnCodiceConto.Enabled = false;
            //    txtCodiceConto.ReadOnly=true;	//txtCodiceConto.Enabled = false;
            //}
            gboxTipoVariazione.Enabled = false;
            gboxResponsabile.Enabled = false;
            gboxStato.Enabled = false;
            gboxConto.Enabled = false;
            gboxUPB.Enabled = false;
            grpRipartizioneCosti.Enabled = false;
			grpInventario.Enabled = false;
			CalcolaTotale(false);
            SetEditFonteFinanziamento();
            lblPrevCassaDI.Visible = false;
            txtPrevCassaDI.Visible = false;
            if (DS.accountvar.Rows.Count > 0) {
                DataRow rAccvar = DS.accountvar.Rows[0];
                int varkind = CfgFn.GetNoNullInt32(rAccvar["variationkind"]);
                if (isprev_iniziale(varkind)) {
                    lblPrevCassaDI.Visible = true;
                    txtPrevCassaDI.Visible = true;
                }
                else {
                    lblPrevCassaDI.Visible = false;
                    txtPrevCassaDI.Visible = false;
                }
            }
        }

        private void txtDataProvv_TextChanged(object sender, EventArgs e) {

        }
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

        private void svuotaOggetti() {
            txtDenominazioneConto.Text = "";
        }
        private void txtCodiceConto_Leave(object sender, EventArgs e) {
            if (Meta == null) return;
            if (!Meta.DrawStateIsDone) return;
            if (txtCodiceConto.Text == "") {
                svuotaOggetti();
                return;
            }
            if (lastCodiceConto == txtCodiceConto.Text) return;

            string filter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            string Codeacc = txtCodiceConto.Text;
            if (!Codeacc.EndsWith("%")) Codeacc += "%";
            filter = QHC.AppAnd(filter, QHS.Like("codeacc", Codeacc));

            MetaData MetaAccountminusable = MetaData.GetMetaData(this, "accountminusable");
            MetaAccountminusable.FilterLocked = true;
            MetaAccountminusable.DS = DS.Clone();

            DataRow Choosen = MetaAccountminusable.SelectOne("default", filter, "accountminusable", null);
            if (Choosen == null) {
                txtCodiceConto.Focus();
                lastCodiceConto = null;
                return;
            }

            txtCodiceConto.Text = (Choosen != null) ? Choosen["codeacc"].ToString() : "";
            txtDenominazioneConto.Text = (Choosen != null) ? Choosen["title"].ToString() : "";
        }
        private string lastCodiceConto;
        private void txtCodiceConto_Enter(object sender, EventArgs e) {
            lastCodiceConto = txtCodiceConto.Text;
        }

        private void btnConto_Click(object sender, EventArgs e) {
            string filter = "";
            int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));

            string filteroperativo = "(idacc in (SELECT idacc from accountminusable where ayear='" +
                esercizio + "'))";

            if (chkListTitle.Checked) {
                FrmAskDescr FR = new FrmAskDescr(0);
                DialogResult D = FR.ShowDialog(this);
                if (D != DialogResult.OK) return;
                filter = GetData.MergeFilters(filter,
                    "(title like " + QueryCreator.quotedstrvalue(
                    "%" + FR.txtDescrizione.Text + "%", true)) + ")";
            }
            filter = GetData.MergeFilters(filter, filteroperativo);
            MetaData.DoMainCommand(this, "choose.accountminusable.default." + filter);
        }
    }
}