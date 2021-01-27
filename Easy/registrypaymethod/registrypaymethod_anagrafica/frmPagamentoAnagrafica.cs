
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
using System.IO;
using funzioni_configurazione;//funzioni_configurazione
using System.Text;

namespace registrypaymethod_anagrafica {//PagamentoAnagrafica//
	/// <summary>
	/// Summary description for frmPagamentoAnagrafica.
	/// </summary>
	public class Frm_registrypaymethod_anagrafica : System.Windows.Forms.Form {
        const string CIN_NON_CORRETTO = "CIN non corretto!";
        MetaData Meta;
        string lastCIN = "";
        object lastABI = DBNull.Value;
        object lastCAB = DBNull.Value;
        string lastCC = "";
        bool inChiusura = false;
		private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancButton;
        public vistaForm DS;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private ComboBox cmbChargeHandling;
        private Button btnChargeHandling;
        private CheckBox chkEsenteSpese;
        private GroupBox groupBox3;
        private TextBox textBox2;
        private TextBox textBox4;
        private Label label10;
        private GroupBox groupBox2;
        private ComboBox comboBox1;
        private GroupBox groupBox1;
        private TextBox scadenza;
        private Label label6;
        private ComboBox tiposcadenza;
        private Label label4;
        private TextBox textBox1;
        private Label label11;
        private GroupBox gboxDelegato;
        private TextBox txtDelegato;
        private TextBox tipo;
        private TextBox descrizione;
        private Label label2;
        private CheckBox chkFlagAttivo;
        private GroupBox gboxCoordinate;
        private Label label13;
        private TextBox textBox3;
        private GroupBox gboxSportello;
        private Button btnCab;
        private TextBox txtCab;
        private TextBox txtCabDescr;
        private GroupBox gboxBanca;
        private TextBox txtBanca;
        private Button BancaButton;
        private TextBox txtDescrBanca;
        private Button btnIBAN;
        private TextBox txtIBAN;
        private Label label12;
        private Button btnBBAN;
        private Label label7;
        private TextBox txtBBAN;
        private Label label8;
        private Label label5;
        private TextBox txtCin;
        private Label label3;
        private TextBox contocorrente;
        private CheckBox chkPredefinita;
        private ComboBox cmbModalita;
        private Button ModalitaButton;
        private Label label1;
        private TabPage tabPage2;
        private TextBox textBox5;
        private TabPage tabCertificati;
        private GroupBox groupBox4;
        private Label labDurcFileName;
        private Button btnVisualizzaDocCF;
        private Button btnRimuoviDocCF;
        private Button btnAllegaDocCF;
        private GroupBox groupBox5;
        private Label labAutocertFileName;
        private Button btnVisualizzaCCdedicato;
        private Button btnRimuoviCCdedicato;
        private Button btnAllegaCCdedicato;
        private OpenFileDialog opendlg;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

		public Frm_registrypaymethod_anagrafica() {
			InitializeComponent();
			HelpForm.SetDenyNull(DS.registrypaymethod.Columns["flagstandard"], true);
			HelpForm.SetDenyNull(DS.registrypaymethod.Columns["active"], true);
            HelpForm.SetDenyNull(DS.registrypaymethod.Columns["flag"], true);
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
			this.OkButton = new System.Windows.Forms.Button();
			this.CancButton = new System.Windows.Forms.Button();
			this.DS = new registrypaymethod_anagrafica.vistaForm();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.cmbChargeHandling = new System.Windows.Forms.ComboBox();
			this.btnChargeHandling = new System.Windows.Forms.Button();
			this.chkEsenteSpese = new System.Windows.Forms.CheckBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.scadenza = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.tiposcadenza = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.gboxDelegato = new System.Windows.Forms.GroupBox();
			this.txtDelegato = new System.Windows.Forms.TextBox();
			this.tipo = new System.Windows.Forms.TextBox();
			this.descrizione = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.chkFlagAttivo = new System.Windows.Forms.CheckBox();
			this.gboxCoordinate = new System.Windows.Forms.GroupBox();
			this.label13 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.gboxSportello = new System.Windows.Forms.GroupBox();
			this.btnCab = new System.Windows.Forms.Button();
			this.txtCab = new System.Windows.Forms.TextBox();
			this.txtCabDescr = new System.Windows.Forms.TextBox();
			this.gboxBanca = new System.Windows.Forms.GroupBox();
			this.txtBanca = new System.Windows.Forms.TextBox();
			this.BancaButton = new System.Windows.Forms.Button();
			this.txtDescrBanca = new System.Windows.Forms.TextBox();
			this.btnIBAN = new System.Windows.Forms.Button();
			this.txtIBAN = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.btnBBAN = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.txtBBAN = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtCin = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.contocorrente = new System.Windows.Forms.TextBox();
			this.chkPredefinita = new System.Windows.Forms.CheckBox();
			this.cmbModalita = new System.Windows.Forms.ComboBox();
			this.ModalitaButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.tabCertificati = new System.Windows.Forms.TabPage();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.labDurcFileName = new System.Windows.Forms.Label();
			this.btnVisualizzaDocCF = new System.Windows.Forms.Button();
			this.btnRimuoviDocCF = new System.Windows.Forms.Button();
			this.btnAllegaDocCF = new System.Windows.Forms.Button();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.labAutocertFileName = new System.Windows.Forms.Label();
			this.btnVisualizzaCCdedicato = new System.Windows.Forms.Button();
			this.btnRimuoviCCdedicato = new System.Windows.Forms.Button();
			this.btnAllegaCCdedicato = new System.Windows.Forms.Button();
			this.opendlg = new System.Windows.Forms.OpenFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.gboxDelegato.SuspendLayout();
			this.gboxCoordinate.SuspendLayout();
			this.gboxSportello.SuspendLayout();
			this.gboxBanca.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabCertificati.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.SuspendLayout();
			// 
			// OkButton
			// 
			this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OkButton.Location = new System.Drawing.Point(530, 577);
			this.OkButton.Name = "OkButton";
			this.OkButton.Size = new System.Drawing.Size(75, 23);
			this.OkButton.TabIndex = 15;
			this.OkButton.Tag = "mainsave";
			this.OkButton.Text = "Ok";
			// 
			// CancButton
			// 
			this.CancButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.CancButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancButton.Location = new System.Drawing.Point(613, 577);
			this.CancButton.Name = "CancButton";
			this.CancButton.Size = new System.Drawing.Size(75, 23);
			this.CancButton.TabIndex = 16;
			this.CancButton.Text = "Annulla";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabCertificati);
			this.tabControl1.Location = new System.Drawing.Point(12, 8);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(676, 551);
			this.tabControl1.TabIndex = 17;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.cmbChargeHandling);
			this.tabPage1.Controls.Add(this.btnChargeHandling);
			this.tabPage1.Controls.Add(this.chkEsenteSpese);
			this.tabPage1.Controls.Add(this.groupBox3);
			this.tabPage1.Controls.Add(this.textBox4);
			this.tabPage1.Controls.Add(this.label10);
			this.tabPage1.Controls.Add(this.groupBox2);
			this.tabPage1.Controls.Add(this.groupBox1);
			this.tabPage1.Controls.Add(this.textBox1);
			this.tabPage1.Controls.Add(this.label11);
			this.tabPage1.Controls.Add(this.gboxDelegato);
			this.tabPage1.Controls.Add(this.tipo);
			this.tabPage1.Controls.Add(this.descrizione);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.chkFlagAttivo);
			this.tabPage1.Controls.Add(this.gboxCoordinate);
			this.tabPage1.Controls.Add(this.chkPredefinita);
			this.tabPage1.Controls.Add(this.cmbModalita);
			this.tabPage1.Controls.Add(this.ModalitaButton);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(668, 525);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Generale";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// cmbChargeHandling
			// 
			this.cmbChargeHandling.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbChargeHandling.DataSource = this.DS.chargehandling;
			this.cmbChargeHandling.DisplayMember = "description";
			this.cmbChargeHandling.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbChargeHandling.Location = new System.Drawing.Point(371, 486);
			this.cmbChargeHandling.Name = "cmbChargeHandling";
			this.cmbChargeHandling.Size = new System.Drawing.Size(290, 21);
			this.cmbChargeHandling.TabIndex = 80;
			this.cmbChargeHandling.Tag = "registrypaymethod.idchargehandling";
			this.cmbChargeHandling.ValueMember = "idchargehandling";
			// 
			// btnChargeHandling
			// 
			this.btnChargeHandling.Location = new System.Drawing.Point(371, 460);
			this.btnChargeHandling.Name = "btnChargeHandling";
			this.btnChargeHandling.Size = new System.Drawing.Size(80, 23);
			this.btnChargeHandling.TabIndex = 79;
			this.btnChargeHandling.TabStop = false;
			this.btnChargeHandling.Tag = "choose.chargehandling.default.(active<>\'N\')";
			this.btnChargeHandling.Text = "Tratt. Spese";
			// 
			// chkEsenteSpese
			// 
			this.chkEsenteSpese.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.chkEsenteSpese.Location = new System.Drawing.Point(468, 460);
			this.chkEsenteSpese.Name = "chkEsenteSpese";
			this.chkEsenteSpese.Size = new System.Drawing.Size(192, 24);
			this.chkEsenteSpese.TabIndex = 78;
			this.chkEsenteSpese.Tag = "registrypaymethod.flag:0";
			this.chkEsenteSpese.Text = "Esente da Spese Bancarie";
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.Controls.Add(this.textBox2);
			this.groupBox3.Location = new System.Drawing.Point(448, 403);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(212, 48);
			this.groupBox3.TabIndex = 77;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Conto Banca d\'Italia";
			// 
			// textBox2
			// 
			this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox2.Location = new System.Drawing.Point(82, 19);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(121, 20);
			this.textBox2.TabIndex = 53;
			this.textBox2.Tag = "registrypaymethod.extracode";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(139, 3);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(69, 20);
			this.textBox4.TabIndex = 61;
			this.textBox4.Tag = "registrypaymethod.idregistrypaymethod";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(113, 6);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(14, 13);
			this.label10.TabIndex = 76;
			this.label10.Text = "#";
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.groupBox2.Controls.Add(this.comboBox1);
			this.groupBox2.Location = new System.Drawing.Point(8, 449);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(264, 40);
			this.groupBox2.TabIndex = 69;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Valuta";
			// 
			// comboBox1
			// 
			this.comboBox1.DataSource = this.DS.currency;
			this.comboBox1.DisplayMember = "description";
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(11, 13);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(247, 21);
			this.comboBox1.TabIndex = 0;
			this.comboBox1.Tag = "registrypaymethod.idcurrency";
			this.comboBox1.ValueMember = "idcurrency";
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.groupBox1.Controls.Add(this.scadenza);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.tiposcadenza);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Location = new System.Drawing.Point(8, 395);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(434, 48);
			this.groupBox1.TabIndex = 68;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Scadenza concordata per il pagamento delle fatture";
			// 
			// scadenza
			// 
			this.scadenza.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.scadenza.Location = new System.Drawing.Point(66, 16);
			this.scadenza.Name = "scadenza";
			this.scadenza.Size = new System.Drawing.Size(88, 20);
			this.scadenza.TabIndex = 10;
			this.scadenza.Tag = "registrypaymethod.paymentexpiring";
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label6.Location = new System.Drawing.Point(142, 16);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(104, 23);
			this.label6.TabIndex = 38;
			this.label6.Text = "Tipo scadenza:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tiposcadenza
			// 
			this.tiposcadenza.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tiposcadenza.DataSource = this.DS.expirationkind;
			this.tiposcadenza.DisplayMember = "description";
			this.tiposcadenza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tiposcadenza.Location = new System.Drawing.Point(256, 16);
			this.tiposcadenza.Name = "tiposcadenza";
			this.tiposcadenza.Size = new System.Drawing.Size(172, 21);
			this.tiposcadenza.TabIndex = 11;
			this.tiposcadenza.Tag = "registrypaymethod.idexpirationkind";
			this.tiposcadenza.ValueMember = "idexpirationkind";
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label4.Location = new System.Drawing.Point(2, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 24);
			this.label4.TabIndex = 37;
			this.label4.Text = "Scadenza:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.textBox1.Location = new System.Drawing.Point(192, 497);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(80, 20);
			this.textBox1.TabIndex = 70;
			this.textBox1.Tag = "registrypaymethod.refexternaldoc";
			// 
			// label11
			// 
			this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label11.Location = new System.Drawing.Point(8, 497);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(176, 23);
			this.label11.TabIndex = 75;
			this.label11.Text = "Riferimento Documento Esterno:";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// gboxDelegato
			// 
			this.gboxDelegato.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxDelegato.Controls.Add(this.txtDelegato);
			this.gboxDelegato.Location = new System.Drawing.Point(8, 347);
			this.gboxDelegato.Name = "gboxDelegato";
			this.gboxDelegato.Size = new System.Drawing.Size(653, 40);
			this.gboxDelegato.TabIndex = 67;
			this.gboxDelegato.TabStop = false;
			this.gboxDelegato.Tag = "AutoChoose.txtDelegato.anagrafica.((active<>\'N\')AND((cf is not null)or (p_iva is " +
    "not null)))";
			this.gboxDelegato.Text = "Delegato";
			// 
			// txtDelegato
			// 
			this.txtDelegato.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDelegato.Location = new System.Drawing.Point(8, 16);
			this.txtDelegato.Name = "txtDelegato";
			this.txtDelegato.Size = new System.Drawing.Size(637, 20);
			this.txtDelegato.TabIndex = 0;
			this.txtDelegato.Tag = "registry.title?registrypaymethodview.deputy";
			// 
			// tipo
			// 
			this.tipo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tipo.Location = new System.Drawing.Point(139, 33);
			this.tipo.Name = "tipo";
			this.tipo.Size = new System.Drawing.Size(517, 20);
			this.tipo.TabIndex = 63;
			this.tipo.Tag = "registrypaymethod.regmodcode";
			// 
			// descrizione
			// 
			this.descrizione.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.descrizione.Location = new System.Drawing.Point(139, 86);
			this.descrizione.Multiline = true;
			this.descrizione.Name = "descrizione";
			this.descrizione.Size = new System.Drawing.Size(517, 45);
			this.descrizione.TabIndex = 65;
			this.descrizione.Tag = "registrypaymethod.paymentdescr";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(45, 33);
			this.label2.Name = "label2";
			this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.label2.Size = new System.Drawing.Size(88, 23);
			this.label2.TabIndex = 74;
			this.label2.Text = "Nome modalità:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// chkFlagAttivo
			// 
			this.chkFlagAttivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.chkFlagAttivo.Location = new System.Drawing.Point(284, 474);
			this.chkFlagAttivo.Name = "chkFlagAttivo";
			this.chkFlagAttivo.Size = new System.Drawing.Size(104, 24);
			this.chkFlagAttivo.TabIndex = 72;
			this.chkFlagAttivo.Tag = "registrypaymethod.active:S:N";
			this.chkFlagAttivo.Text = "Attivo";
			// 
			// gboxCoordinate
			// 
			this.gboxCoordinate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxCoordinate.Controls.Add(this.label13);
			this.gboxCoordinate.Controls.Add(this.textBox3);
			this.gboxCoordinate.Controls.Add(this.gboxSportello);
			this.gboxCoordinate.Controls.Add(this.gboxBanca);
			this.gboxCoordinate.Controls.Add(this.btnIBAN);
			this.gboxCoordinate.Controls.Add(this.txtIBAN);
			this.gboxCoordinate.Controls.Add(this.label12);
			this.gboxCoordinate.Controls.Add(this.btnBBAN);
			this.gboxCoordinate.Controls.Add(this.label7);
			this.gboxCoordinate.Controls.Add(this.txtBBAN);
			this.gboxCoordinate.Controls.Add(this.label8);
			this.gboxCoordinate.Controls.Add(this.label5);
			this.gboxCoordinate.Controls.Add(this.txtCin);
			this.gboxCoordinate.Controls.Add(this.label3);
			this.gboxCoordinate.Controls.Add(this.contocorrente);
			this.gboxCoordinate.Location = new System.Drawing.Point(8, 131);
			this.gboxCoordinate.Name = "gboxCoordinate";
			this.gboxCoordinate.Size = new System.Drawing.Size(653, 215);
			this.gboxCoordinate.TabIndex = 66;
			this.gboxCoordinate.TabStop = false;
			this.gboxCoordinate.Text = "Coordinate bancarie";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(405, 160);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(99, 13);
			this.label13.TabIndex = 29;
			this.label13.Text = "Codice BIC/SWIFT";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(408, 181);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(199, 20);
			this.textBox3.TabIndex = 28;
			this.textBox3.Tag = "registrypaymethod.biccode";
			// 
			// gboxSportello
			// 
			this.gboxSportello.Controls.Add(this.btnCab);
			this.gboxSportello.Controls.Add(this.txtCab);
			this.gboxSportello.Controls.Add(this.txtCabDescr);
			this.gboxSportello.Location = new System.Drawing.Point(306, 46);
			this.gboxSportello.Name = "gboxSportello";
			this.gboxSportello.Size = new System.Drawing.Size(300, 73);
			this.gboxSportello.TabIndex = 3;
			this.gboxSportello.TabStop = false;
			this.gboxSportello.Tag = "AutoChoose.txtCab.default.(flagusable<>\'N\')";
			// 
			// btnCab
			// 
			this.btnCab.Location = new System.Drawing.Point(6, 14);
			this.btnCab.Name = "btnCab";
			this.btnCab.Size = new System.Drawing.Size(100, 23);
			this.btnCab.TabIndex = 4;
			this.btnCab.Tag = "choose.cab.default";
			this.btnCab.Text = "CAB";
			// 
			// txtCab
			// 
			this.txtCab.Location = new System.Drawing.Point(6, 43);
			this.txtCab.Name = "txtCab";
			this.txtCab.Size = new System.Drawing.Size(100, 20);
			this.txtCab.TabIndex = 29;
			this.txtCab.Tag = "cab.idcab?registrypaymethodview.idcab";
			// 
			// txtCabDescr
			// 
			this.txtCabDescr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCabDescr.Location = new System.Drawing.Point(112, 10);
			this.txtCabDescr.Multiline = true;
			this.txtCabDescr.Name = "txtCabDescr";
			this.txtCabDescr.ReadOnly = true;
			this.txtCabDescr.Size = new System.Drawing.Size(182, 58);
			this.txtCabDescr.TabIndex = 1;
			this.txtCabDescr.TabStop = false;
			this.txtCabDescr.Tag = "cab.description";
			// 
			// gboxBanca
			// 
			this.gboxBanca.Controls.Add(this.txtBanca);
			this.gboxBanca.Controls.Add(this.BancaButton);
			this.gboxBanca.Controls.Add(this.txtDescrBanca);
			this.gboxBanca.Location = new System.Drawing.Point(1, 46);
			this.gboxBanca.Name = "gboxBanca";
			this.gboxBanca.Size = new System.Drawing.Size(299, 73);
			this.gboxBanca.TabIndex = 2;
			this.gboxBanca.TabStop = false;
			this.gboxBanca.Tag = "AutoChoose.txtBanca.default.(flagusable<>\'N\')";
			// 
			// txtBanca
			// 
			this.txtBanca.Location = new System.Drawing.Point(9, 43);
			this.txtBanca.Name = "txtBanca";
			this.txtBanca.Size = new System.Drawing.Size(100, 20);
			this.txtBanca.TabIndex = 3;
			this.txtBanca.Tag = "bank.idbank?registrypaymethodview.idbank";
			// 
			// BancaButton
			// 
			this.BancaButton.Location = new System.Drawing.Point(8, 14);
			this.BancaButton.Name = "BancaButton";
			this.BancaButton.Size = new System.Drawing.Size(101, 23);
			this.BancaButton.TabIndex = 2;
			this.BancaButton.Tag = "choose.bank.default.(flagusable<>\'N\')";
			this.BancaButton.Text = "ABI";
			// 
			// txtDescrBanca
			// 
			this.txtDescrBanca.Location = new System.Drawing.Point(129, 10);
			this.txtDescrBanca.Multiline = true;
			this.txtDescrBanca.Name = "txtDescrBanca";
			this.txtDescrBanca.ReadOnly = true;
			this.txtDescrBanca.Size = new System.Drawing.Size(164, 58);
			this.txtDescrBanca.TabIndex = 2;
			this.txtDescrBanca.TabStop = false;
			this.txtDescrBanca.Tag = "bank.description";
			// 
			// btnIBAN
			// 
			this.btnIBAN.Location = new System.Drawing.Point(269, 179);
			this.btnIBAN.Name = "btnIBAN";
			this.btnIBAN.Size = new System.Drawing.Size(129, 23);
			this.btnIBAN.TabIndex = 27;
			this.btnIBAN.Text = "Inserisci l\'IBAN";
			this.btnIBAN.Click += new System.EventHandler(this.btnIBAN_Click);
			// 
			// txtIBAN
			// 
			this.txtIBAN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtIBAN.Location = new System.Drawing.Point(56, 181);
			this.txtIBAN.Name = "txtIBAN";
			this.txtIBAN.ReadOnly = true;
			this.txtIBAN.Size = new System.Drawing.Size(208, 20);
			this.txtIBAN.TabIndex = 26;
			this.txtIBAN.TabStop = false;
			this.txtIBAN.Tag = "registrypaymethod.iban";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(9, 181);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(32, 13);
			this.label12.TabIndex = 25;
			this.label12.Text = "IBAN";
			// 
			// btnBBAN
			// 
			this.btnBBAN.Location = new System.Drawing.Point(268, 150);
			this.btnBBAN.Name = "btnBBAN";
			this.btnBBAN.Size = new System.Drawing.Size(129, 23);
			this.btnBBAN.TabIndex = 7;
			this.btnBBAN.Text = "Inserisci il BBAN";
			this.btnBBAN.Click += new System.EventHandler(this.btnBBAN_Click);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(8, 152);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(36, 13);
			this.label7.TabIndex = 23;
			this.label7.Text = "BBAN";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtBBAN
			// 
			this.txtBBAN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtBBAN.Location = new System.Drawing.Point(56, 152);
			this.txtBBAN.Name = "txtBBAN";
			this.txtBBAN.ReadOnly = true;
			this.txtBBAN.Size = new System.Drawing.Size(208, 20);
			this.txtBBAN.TabIndex = 22;
			this.txtBBAN.TabStop = false;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(128, 16);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(376, 32);
			this.label8.TabIndex = 20;
			this.label8.Text = "Nota: solo inserendo correttamente tutti i dati sarà visualizzato, nelle stampe, " +
    "il BBAN come da regolamento bancario";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 122);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(160, 16);
			this.label5.TabIndex = 16;
			this.label5.Text = "C/C corrente Italia o Estero:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtCin
			// 
			this.txtCin.Location = new System.Drawing.Point(72, 24);
			this.txtCin.Name = "txtCin";
			this.txtCin.Size = new System.Drawing.Size(48, 20);
			this.txtCin.TabIndex = 1;
			this.txtCin.Tag = "registrypaymethod.cin";
			this.txtCin.Leave += new System.EventHandler(this.txtCin_Leave);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 27);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 16);
			this.label3.TabIndex = 5;
			this.label3.Text = "Cin:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// contocorrente
			// 
			this.contocorrente.Location = new System.Drawing.Point(174, 121);
			this.contocorrente.Name = "contocorrente";
			this.contocorrente.Size = new System.Drawing.Size(190, 20);
			this.contocorrente.TabIndex = 6;
			this.contocorrente.Tag = "registrypaymethod.cc";
			this.contocorrente.Leave += new System.EventHandler(this.contocorrente_Leave);
			// 
			// chkPredefinita
			// 
			this.chkPredefinita.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.chkPredefinita.Location = new System.Drawing.Point(284, 449);
			this.chkPredefinita.Name = "chkPredefinita";
			this.chkPredefinita.Size = new System.Drawing.Size(88, 24);
			this.chkPredefinita.TabIndex = 71;
			this.chkPredefinita.Tag = "registrypaymethod.flagstandard:S:N";
			this.chkPredefinita.Text = "Predefinito";
			// 
			// cmbModalita
			// 
			this.cmbModalita.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbModalita.DataSource = this.DS.paymethod;
			this.cmbModalita.DisplayMember = "description";
			this.cmbModalita.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbModalita.Location = new System.Drawing.Point(139, 59);
			this.cmbModalita.Name = "cmbModalita";
			this.cmbModalita.Size = new System.Drawing.Size(517, 21);
			this.cmbModalita.TabIndex = 64;
			this.cmbModalita.Tag = "registrypaymethod.idpaymethod";
			this.cmbModalita.ValueMember = "idpaymethod";
			// 
			// ModalitaButton
			// 
			this.ModalitaButton.Location = new System.Drawing.Point(53, 57);
			this.ModalitaButton.Name = "ModalitaButton";
			this.ModalitaButton.Size = new System.Drawing.Size(80, 23);
			this.ModalitaButton.TabIndex = 62;
			this.ModalitaButton.TabStop = false;
			this.ModalitaButton.Tag = "manage.paymethod.anagrafica";
			this.ModalitaButton.Text = "Tipo Modalità";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(17, 86);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(116, 42);
			this.label1.TabIndex = 73;
			this.label1.Text = "Note per il Tesoriere - Rif.doc.esterno:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.textBox5);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(668, 525);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Note";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// textBox5
			// 
			this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox5.Location = new System.Drawing.Point(23, 22);
			this.textBox5.Multiline = true;
			this.textBox5.Name = "textBox5";
			this.textBox5.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox5.Size = new System.Drawing.Size(626, 481);
			this.textBox5.TabIndex = 39;
			this.textBox5.Tag = "registrypaymethod.notes";
			// 
			// tabCertificati
			// 
			this.tabCertificati.Controls.Add(this.groupBox4);
			this.tabCertificati.Controls.Add(this.groupBox5);
			this.tabCertificati.Location = new System.Drawing.Point(4, 22);
			this.tabCertificati.Name = "tabCertificati";
			this.tabCertificati.Size = new System.Drawing.Size(668, 525);
			this.tabCertificati.TabIndex = 2;
			this.tabCertificati.Text = "Certificati";
			this.tabCertificati.UseVisualStyleBackColor = true;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.labDurcFileName);
			this.groupBox4.Controls.Add(this.btnVisualizzaDocCF);
			this.groupBox4.Controls.Add(this.btnRimuoviDocCF);
			this.groupBox4.Controls.Add(this.btnAllegaDocCF);
			this.groupBox4.Location = new System.Drawing.Point(4, 110);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(437, 73);
			this.groupBox4.TabIndex = 204;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Documento identità del dichiarante (se separato dalla dichiarazione)";
			// 
			// labDurcFileName
			// 
			this.labDurcFileName.Location = new System.Drawing.Point(10, 16);
			this.labDurcFileName.Name = "labDurcFileName";
			this.labDurcFileName.Size = new System.Drawing.Size(406, 18);
			this.labDurcFileName.TabIndex = 75;
			// 
			// btnVisualizzaDocCF
			// 
			this.btnVisualizzaDocCF.Location = new System.Drawing.Point(333, 36);
			this.btnVisualizzaDocCF.Name = "btnVisualizzaDocCF";
			this.btnVisualizzaDocCF.Size = new System.Drawing.Size(79, 24);
			this.btnVisualizzaDocCF.TabIndex = 2;
			this.btnVisualizzaDocCF.Text = "Visualizza";
			this.btnVisualizzaDocCF.UseVisualStyleBackColor = true;
			this.btnVisualizzaDocCF.Click += new System.EventHandler(this.btnVisualizzaDocCF_Click);
			// 
			// btnRimuoviDocCF
			// 
			this.btnRimuoviDocCF.Location = new System.Drawing.Point(213, 36);
			this.btnRimuoviDocCF.Name = "btnRimuoviDocCF";
			this.btnRimuoviDocCF.Size = new System.Drawing.Size(99, 24);
			this.btnRimuoviDocCF.TabIndex = 1;
			this.btnRimuoviDocCF.Text = "Rimuovi Allegato";
			this.btnRimuoviDocCF.UseVisualStyleBackColor = true;
			this.btnRimuoviDocCF.Click += new System.EventHandler(this.btnRimuoviDoc_Click);
			// 
			// btnAllegaDocCF
			// 
			this.btnAllegaDocCF.Location = new System.Drawing.Point(117, 36);
			this.btnAllegaDocCF.Name = "btnAllegaDocCF";
			this.btnAllegaDocCF.Size = new System.Drawing.Size(79, 24);
			this.btnAllegaDocCF.TabIndex = 0;
			this.btnAllegaDocCF.Text = "Allega";
			this.btnAllegaDocCF.UseVisualStyleBackColor = true;
			this.btnAllegaDocCF.Click += new System.EventHandler(this.btnAllegaDoc_Click);
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.labAutocertFileName);
			this.groupBox5.Controls.Add(this.btnVisualizzaCCdedicato);
			this.groupBox5.Controls.Add(this.btnRimuoviCCdedicato);
			this.groupBox5.Controls.Add(this.btnAllegaCCdedicato);
			this.groupBox5.Location = new System.Drawing.Point(3, 24);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(438, 82);
			this.groupBox5.TabIndex = 203;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Dichiarazione cc dedicato e documento identità dichiarante";
			// 
			// labAutocertFileName
			// 
			this.labAutocertFileName.Location = new System.Drawing.Point(11, 16);
			this.labAutocertFileName.Name = "labAutocertFileName";
			this.labAutocertFileName.Size = new System.Drawing.Size(407, 16);
			this.labAutocertFileName.TabIndex = 74;
			// 
			// btnVisualizzaCCdedicato
			// 
			this.btnVisualizzaCCdedicato.Location = new System.Drawing.Point(335, 45);
			this.btnVisualizzaCCdedicato.Name = "btnVisualizzaCCdedicato";
			this.btnVisualizzaCCdedicato.Size = new System.Drawing.Size(79, 24);
			this.btnVisualizzaCCdedicato.TabIndex = 2;
			this.btnVisualizzaCCdedicato.Text = "Visualizza";
			this.btnVisualizzaCCdedicato.UseVisualStyleBackColor = true;
			this.btnVisualizzaCCdedicato.Click += new System.EventHandler(this.btnVisualizzaCCdedicato_Click);
			// 
			// btnRimuoviCCdedicato
			// 
			this.btnRimuoviCCdedicato.Location = new System.Drawing.Point(214, 45);
			this.btnRimuoviCCdedicato.Name = "btnRimuoviCCdedicato";
			this.btnRimuoviCCdedicato.Size = new System.Drawing.Size(101, 24);
			this.btnRimuoviCCdedicato.TabIndex = 1;
			this.btnRimuoviCCdedicato.Text = "Rimuovi Allegato";
			this.btnRimuoviCCdedicato.UseVisualStyleBackColor = true;
			this.btnRimuoviCCdedicato.Click += new System.EventHandler(this.btnRimuoviCCdedicato_Click);
			// 
			// btnAllegaCCdedicato
			// 
			this.btnAllegaCCdedicato.Location = new System.Drawing.Point(118, 45);
			this.btnAllegaCCdedicato.Name = "btnAllegaCCdedicato";
			this.btnAllegaCCdedicato.Size = new System.Drawing.Size(79, 24);
			this.btnAllegaCCdedicato.TabIndex = 0;
			this.btnAllegaCCdedicato.Text = "Allega";
			this.btnAllegaCCdedicato.UseVisualStyleBackColor = true;
			this.btnAllegaCCdedicato.Click += new System.EventHandler(this.btnAllegaCCdedicato_Click);
			// 
			// opendlg
			// 
			this.opendlg.Title = "Scegli il file da allegare";
			// 
			// Frm_registrypaymethod_anagrafica
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(700, 612);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.OkButton);
			this.Controls.Add(this.CancButton);
			this.Name = "Frm_registrypaymethod_anagrafica";
			this.Text = "frmPagamentoAnagrafica";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.gboxDelegato.ResumeLayout(false);
			this.gboxDelegato.PerformLayout();
			this.gboxCoordinate.ResumeLayout(false);
			this.gboxCoordinate.PerformLayout();
			this.gboxSportello.ResumeLayout(false);
			this.gboxSportello.PerformLayout();
			this.gboxBanca.ResumeLayout(false);
			this.gboxBanca.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.tabCertificati.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
        
        CQueryHelper QHC;
        QueryHelper QHS;
		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            //GetData.CacheTable(DS.currency, null, null, true);
            bool FlagEsenteBanca = LeggiFlagEsenteBancaPredefinita();
            chkEsenteSpese.Visible = FlagEsenteBanca;
        }
		private void btnBBAN_Click(object sender, System.EventArgs e) {
			inserisciBBAN();
		}

		private bool controllaBanca(string insertedBBAN) {
			string ABI = insertedBBAN.Substring(1,5);
			string filtroBanca = QHS.CmpEq("idbank", ABI);
			object codiceABI = Meta.Conn.DO_READ_VALUE("bank", filtroBanca, "idbank");
			if (codiceABI == null) {
				MetaFactory.factory.getSingleton<IMessageShower>().Show(this,"La banca inserita nell'IBAN non esiste in Easy. Deve essere inserita in Anagrafiche - ABI (Banche)");
				return false;
			}
			string CAB = insertedBBAN.Substring(6,5);
            filtroBanca = QHS.AppAnd(filtroBanca,QHS.CmpEq("idcab", CAB));
			object codiceCAB = Meta.Conn.DO_READ_VALUE("cab", filtroBanca, "idcab");
			if (codiceCAB == null) {
				MetaFactory.factory.getSingleton<IMessageShower>().Show(this,"Lo sportello inserito nell'IBAN non esiste in Easy. Deve essere inserito in Anagrafiche - CAB (Filiali)");
				return false;
			}
			return true;
		}

		private void inserisciBBAN() {
            string bbanIniziale = txtBBAN.Text == CIN_NON_CORRETTO ? "" : txtBBAN.Text;
            frmaskbban BBAN = new frmaskbban(bbanIniziale);
			if (BBAN.ShowDialog(this)!=DialogResult.OK) return;
			if (BBAN.insertedBBAN == "") return;
			
			bool inserisciDati = controllaBanca(BBAN.insertedBBAN);
			if (!inserisciDati) return;
			string CIN = BBAN.insertedBBAN.Substring(0,1).ToUpper();
			string ABI = BBAN.insertedBBAN.Substring(1,5);
			string CAB = BBAN.insertedBBAN.Substring(6,5);
			string CC = BBAN.insertedBBAN.Substring(11,12);
            string iban = CfgFn.calcolaIBAN("IT", BBAN.insertedBBAN);
			if ((Meta.InsertMode) || (Meta.EditMode)) {
                MetaData.GetFormData(this, true);
				DS.registrypaymethod.Rows[0]["cin"] = CIN;
				DS.registrypaymethod.Rows[0]["idbank"] = ABI;
				DS.registrypaymethod.Rows[0]["idcab"] = CAB;
				DS.registrypaymethod.Rows[0]["cc"] = CC;
                DS.registrypaymethod.Rows[0]["iban"] = iban;
                Meta.FreshForm();
			}
			else {
				txtBanca.Text = ABI;
				txtCab.Text = CAB;
				txtCin.Text = CIN;
				contocorrente.Text = CC;
			}
			txtBBAN.Text = BBAN.insertedBBAN;
            txtIBAN.Text = iban;
		}

		private void txtCin_Leave(object sender, System.EventArgs e) {
			if (inChiusura) return;
			if (Meta.IsEmpty) return;
			if (txtCin.Text == "") {
				txtBBAN.Text = "";
				lastCIN = "";
				return;
			}
			if (lastCIN == txtCin.Text.ToUpper()) return;
			lastCIN = txtCin.Text.ToUpper();
			calcolaBBAN();
		}

		private void contocorrente_Leave(object sender, System.EventArgs e) {
			if (inChiusura) return;
			if (Meta.IsEmpty) return;
			if (contocorrente.Text == "") {
				txtBBAN.Text = "";
				lastCC = "";
				return;
			}
			if (lastCC == contocorrente.Text) return;
			lastCC = contocorrente.Text;
			calcolaBBAN();
		}
        void SetAutoCab(object idbank) {
            string Autochoose = "AutoChoose.txtCab.default.";
            string Choose = "Choose.cab.default.";
            string filter;
            if (idbank != DBNull.Value) {
                //Imposta il filtro sulla banca nello sportello
                filter = QHS.AppAnd(QHS.CmpEq("idbank", idbank), QHS.CmpNe("flagusable", "N"));
            }
            else {
                //Rimuove il filtro sulla banca nello sportello
                filter = QHS.CmpNe("flagusable", "N");
            }
            gboxSportello.Tag = Autochoose + filter;
            btnCab.Tag = Choose + filter;
            Meta.SetAutoMode(gboxSportello);
        }

		public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
			if (Meta.IsEmpty) return;
			switch(T.TableName) {
				case "bank": {
                    if (Meta.DrawStateIsDone) {
                        string Autochoose = "AutoChoose.txtCab.default.";
                        string Choose = "Choose.cab.default.";
                        DS.cab.Clear();
                        txtCab.Text = "";
                        txtCabDescr.Text = "";
                        if (!Meta.IsEmpty) {
                            DataRow Curr = DS.registrypaymethod.Rows[0];
                            Curr["idcab"] = DBNull.Value;
                        }
                        string filter;
                        if (R != null) {
                            //Imposta il filtro sulla banca nello sportello
                            filter= QHS.AppAnd(QHS.CmpEq("idbank",R["idbank"]),QHS.CmpNe("flagusable","N"));
                        }
                        else {
                            //Rimuove il filtro sulla banca nello sportello
                            filter = QHS.CmpNe("flagusable", "N");
                        }
                        gboxSportello.Tag = Autochoose+filter;
                        btnCab.Tag = Choose + filter;
                        Meta.SetAutoMode(gboxSportello);
                    }
					if (R == null) {
						lastABI = DBNull.Value;
						txtBBAN.Text = "";
						return;
					}
					if (lastABI.Equals(R["idbank"])) return;
					lastABI = R["idbank"];
					//calcolaBBAN();
					break;
				}
				case "cab": {
                    if (R != null && Meta.DrawStateIsDone && txtBanca.Text=="") {
                        DS.bank.Clear();
                        Meta.Conn.RUN_SELECT_INTO_TABLE(DS.bank, null, QHS.CmpEq("idbank", R["idbank"]), null, false);
                        if (DS.bank.Rows.Count > 0) {
                            DataRow B= DS.bank.Rows[0];
                            txtBanca.Text = B["idbank"].ToString();
                            txtDescrBanca.Text = B["description"].ToString();
                        }
                        SetAutoCab(R["idbank"]);
                    }
					if (R == null) {
						lastCAB = DBNull.Value;
						txtBBAN.Text = "";
						return;
					}
					if (lastCAB.Equals(R["idcab"])) return;
					lastCAB = R["idcab"];
					calcolaBBAN();
					break;
				}
				case "paymethod": {
					if (R != null) {
						bool ammettiDelegato = (R["allowdeputy"].ToString().ToUpper() == "S");
						AbilitaDisabilitaDelegato(ammettiDelegato);
						if (Meta.DrawStateIsDone){
							if (!ammettiDelegato)
								//azzeraCoordinateBancarie();
							//else 
								azzeraDelegato();
						}
					}
					else {
						//gboxCoordinate.Visible = true;
						gboxDelegato.Visible = true;
					}

					break;
				}
                case "chargehandling":
                    {
                        if (R != null)
                        {
                           
                            if (LeggiFlagEsenteBancaPredefinita()) {
                                int flag_exemption = (CfgFn.GetNoNullInt32(R["flag"]) & 1);
                                chkEsenteSpese.Checked = !((flag_exemption & 1) == 0);
                            }
                         
                        }
                       
                        break;
                    }
			}
		}

		private void AbilitaDisabilitaDelegato(bool ammettiDelegato) {
			if (Meta.IsEmpty) return;
			if (ammettiDelegato) {
				//gboxCoordinate.Visible = false;
				gboxDelegato.Visible = true;
			}
			else {
				//gboxCoordinate.Visible = true;
				gboxDelegato.Visible = false;
			}
		}

		
		private void azzeraDelegato() {
			if (Meta.IsEmpty) return;
			if (DS.registrypaymethod.Rows.Count == 0) return;
			DataRow Curr = DS.registrypaymethod.Rows[0];
			Curr["iddeputy"]=DBNull.Value;
			txtDelegato.Text="";
			DS.registry.Clear();
		}

		private void azzeraCoordinateBancarie() {
			if (Meta.IsEmpty) return;
			if (DS.registrypaymethod.Rows.Count == 0) return;
			DataRow Curr = DS.registrypaymethod.Rows[0];
			Curr["cin"]=DBNull.Value;
			txtCin.Text="";
			Curr["idbank"]=DBNull.Value;
			Curr["idcab"]=DBNull.Value;
			Curr["cc"]=DBNull.Value;
			try {
				txtBanca.Text="";
				txtCab.Text="";
                txtDescrBanca.Text = "";
                txtCabDescr.Text = "";
                DS.bank.Clear();
                DS.cab.Clear();
			}
			catch {
			}
			contocorrente.Text="";
		}

		private void calcolaBBAN() {
			if (DS.registrypaymethod.Rows.Count == 0) return;
			if (Meta.DrawStateIsDone) Meta.GetFormData(true);
			DataRow Curr = DS.registrypaymethod.Rows[0];
			bool puoiCalcolare =
				((Curr["cin"] != DBNull.Value) &&
				(Curr["idbank"] != DBNull.Value) &&
				(Curr["idcab"] != DBNull.Value) &&
				(Curr["cc"] != DBNull.Value) &&
				(Curr["cin"].ToString() != "") &&
				(Curr["idbank"].ToString() != "") &&
				(Curr["idcab"].ToString() != "") &&
				(Curr["cc"].ToString() != ""));
			if (!puoiCalcolare) {
				txtBBAN.Text = "";
				return;
			}
			Curr["cin"] = Curr["cin"].ToString().ToUpper();
			bool cinCorretto = CfgFn.CheckCIN(Curr["cin"].ToString(),Curr["idcab"].ToString(),Curr["idbank"].ToString(),Curr["cc"].ToString());
			if (cinCorretto) {
				txtBBAN.Text = Curr["cin"].ToString() + Curr["idbank"].ToString() + Curr["idcab"].ToString() + Curr["cc"].ToString();
                txtIBAN.Text = CfgFn.calcolaIBAN("IT", txtBBAN.Text);
                Curr["iban"] = txtIBAN.Text;
            }
			else {
				txtBBAN.Text = CIN_NON_CORRETTO;
                txtIBAN.Text = null;
            }
		}

	    public void MetaData_BeforeFill() {
	        FlagCCdedicato();
	    }

	    public void MetaData_AfterFill() {
            AbilitaDisabilitaAllegati();
            if (Meta.FirstFillForThisRow) {
                DataRow Curr = DS.registrypaymethod.Rows[0];
                SetAutoCab(Curr["idbank"]);
                calcolaBBAN();
            }

		  
			if ((Meta.FirstFillForThisRow) && (Meta.EditMode)) {
				assegnaVarDiConfronto();
				DataRow Curr = DS.registrypaymethod.Rows[0];
				string filtroModalita = "(idpaymethod = " + QueryCreator.quotedstrvalue(Curr["idpaymethod"],false) + ")";
				DataRow []rr= DS.paymethod.Select(filtroModalita);
				if (rr.Length>0) {
					DataRow rMod = rr[0];
					bool ammettiDelegato = ((rMod["allowdeputy"] != DBNull.Value)
						&& (rMod["allowdeputy"].ToString().ToUpper() == "S"));
					AbilitaDisabilitaDelegato(ammettiDelegato);
				}				
				else {
					AbilitaDisabilitaDelegato(false);
				}

			}
		}

		public void assegnaVarDiConfronto() {
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.registrypaymethod.Rows[0];

			lastCIN = (Curr["cin"] == DBNull.Value) ? "" : Curr["cin"].ToString().ToUpper();
			lastABI = Curr["idbank"];
            lastCAB = Curr["idcab"];
			lastCC = (Curr["cc"] == DBNull.Value) ? "" : Curr["cc"].ToString();
		}

        private void btnIBAN_Click(object sender, EventArgs e) {
            FrmAskIban frm = new FrmAskIban(txtIBAN.Text);
            if (frm.ShowDialog(this) != DialogResult.OK) return;
            if (frm.insertedIBAN == "") {
                txtIBAN.Text = frm.insertedIBAN;
                return;
            }
            if (!frm.insertedIBAN.StartsWith("IT")) {
                if ((Meta.InsertMode) || (Meta.EditMode)) {
                    MetaData.GetFormData(this, true);
                    DS.registrypaymethod.Rows[0]["iban"] = frm.insertedIBAN;
                    DS.registrypaymethod.Rows[0]["cin"] = DBNull.Value;
				    DS.registrypaymethod.Rows[0]["idbank"] = DBNull.Value;
                    DS.registrypaymethod.Rows[0]["idcab"] = DBNull.Value;
                    DS.registrypaymethod.Rows[0]["cc"] = DBNull.Value;
                    Meta.FreshForm();
                }
                return;
            }

            bool inserisciDati = controllaBanca(frm.insertedIBAN.Substring(4));
            if (!inserisciDati) return;

            string bban = frm.insertedIBAN.Substring(4);
            string CIN = bban.Substring(0, 1).ToUpper();
            string ABI = bban.Substring(1, 5);
            string CAB = bban.Substring(6, 5);
            string CC = bban.Substring(11, 12);
            if ((Meta.InsertMode) || (Meta.EditMode)) {
                MetaData.GetFormData(this, true);
                DS.registrypaymethod.Rows[0]["cin"] = CIN;
                DS.registrypaymethod.Rows[0]["idbank"] = ABI;
                DS.registrypaymethod.Rows[0]["idcab"] = CAB;
                DS.registrypaymethod.Rows[0]["cc"] = CC;
                DS.registrypaymethod.Rows[0]["iban"] = frm.insertedIBAN;
                Meta.FreshForm();
            }
            else {
                txtBanca.Text = ABI;
                txtCab.Text = CAB;
                txtCin.Text = CIN;
                contocorrente.Text = CC;
            }
            txtBBAN.Text = frm.insertedIBAN.Substring(4);
            txtIBAN.Text = frm.insertedIBAN;
        }
        void SalvaAllegato(string certification) {
            // Legge il file indicato dall'utente e lo scrive nel DB nel campo apposito
            if (Meta.IsEmpty) return;
            if (!Meta.GetFormData(true)) return;
            DialogResult dialogResult;
            try {
                dialogResult = opendlg.ShowDialog(this);
            }
            catch (Exception E) {
                QueryCreator.ShowException("Errore nella selezione  del file", E);
                return;
            }
            if (dialogResult == DialogResult.Cancel) return;
            DataRow Curr = HelpForm.GetLastSelected(DS.registrypaymethod);
            if (Curr == null) return;
            FileStream FS;
            try {
                FS = new FileStream(opendlg.FileName, FileMode.Open, FileAccess.Read);
            }
            catch (Exception e) {
                QueryCreator.ShowException("Errore nell'apertura del file", e);
                return;
            }
            string estensione = Path.GetExtension(FS.Name);
            if (FS == null) return;
            int n = (int)FS.Length;
            if (n == 0) return;
            int namelen = LengthForFileName(opendlg.FileName);

            try {
                byte[] ByteArray = new byte[n + namelen];
                FS.Read(ByteArray, namelen, n);
                if (FS.Length == 0) {
                    Curr[certification] = DBNull.Value;
                }
                FS.Close();
                SetBytesForFileName(opendlg.FileName, ByteArray);
                Curr[certification] = ByteArray;
            }
            catch { }
            AbilitaDisabilitaAllegati();
            if (certification == "ccdedicato_doc") {
                FlagCCdedicato();
            }
        }

        public void MetaData_AfterClear() {
            AbilitaDisabilitaAllegati();
        }
        private void FlagCCdedicato() {
            if (Meta.IsEmpty) {
                return;
            }

            DataRow Curr = DS.registrypaymethod.Rows[0];
            int flag = CfgFn.GetNoNullInt32(Curr["requested_doc"]);
            // bit 0 - CC dedicato
            if (Curr["ccdedicato_doc"] != DBNull.Value) {
                //lo Valorizza a 1
                flag = flag | 1;
            }
            else {
                //Lo azzera.
                flag = flag & 0xFE;
            }
            Curr["requested_doc"] = flag;
        }
        private void btnAllegaCCdedicato_Click(object sender, EventArgs e) {
            SalvaAllegato("ccdedicato_doc");
        }

        private void btnAllegaDoc_Click(object sender, EventArgs e) {
            SalvaAllegato("ccdedicato_cf");
        }

        private void btnRimuoviCCdedicato_Click(object sender, EventArgs e) {
            DS.registrypaymethod.Rows[0]["ccdedicato_doc"] = DBNull.Value;
            AbilitaDisabilitaAllegati();
            FlagCCdedicato();
        }

        private void btnRimuoviDoc_Click(object sender, EventArgs e) {
            DS.registrypaymethod.Rows[0]["ccdedicato_cf"] = DBNull.Value;
            AbilitaDisabilitaAllegati();
        }
        void AbilitaDisabilitaAllegati() {
            labAutocertFileName.Text = "";
            labDurcFileName.Text = "";
            //if (Meta.IsEmpty) {
            //    btnAllegaAuto.Enabled = false;
            //    btnVisualizzaAuto.Enabled = false;
            //    btnRimuoviAuto.Enabled = false;

            //    btnAllegaDurc.Enabled = false;
            //    btnVisualizzaDurc.Enabled = false;
            //    btnRimuoviDurc.Enabled = false;

            //    return;
            //}
            DataRow Curr = DS.registrypaymethod.Rows[0];

            if (Curr["ccdedicato_doc"] != DBNull.Value) {
                byte[] B = (byte[])Curr["ccdedicato_doc"];
                labAutocertFileName.Text = GetFileName(B);
                btnAllegaCCdedicato.Enabled = false;
                btnVisualizzaCCdedicato.Enabled = true;
                btnRimuoviCCdedicato.Enabled = true;
            }
            else {
                btnAllegaCCdedicato.Enabled = true;
                btnVisualizzaCCdedicato.Enabled = false;
                btnRimuoviCCdedicato.Enabled = false;
            }

            if (Curr["ccdedicato_cf"] != DBNull.Value) {
                btnAllegaDocCF.Enabled = false;
                btnVisualizzaDocCF.Enabled = true;
                btnRimuoviDocCF.Enabled = true;
                byte[] B = (byte[])Curr["ccdedicato_cf"];
                labDurcFileName.Text = GetFileName(B);
            }
            else {
                btnAllegaDocCF.Enabled = true;
                btnVisualizzaDocCF.Enabled = false;
                btnRimuoviDocCF.Enabled = false;
            }
        }

        private void VisualizzaAllegato(string certification) {
            string FilePath = AppDomain.CurrentDomain.BaseDirectory;
            string prefix = "SWMOREALL";
            string filenametodelete = FilePath + prefix + "*.*";
            string[] existingreports = System.IO.Directory.GetFiles(FilePath, prefix + "*.*");
            foreach (string filename in existingreports) {
                try {
                    System.IO.File.Delete(filename);
                }
                catch { }
            }

            //sw è il nome del file temporaneo che hai creato
            DateTime oggi_dt = DateTime.Now;
            string oggi = oggi_dt.Ticks.ToString();
            DataRow Curr = DS.registrypaymethod.Rows[0];

            byte[] ByteArray = (byte[])Curr[certification];
            int offset = GetOffsetForData(ByteArray);
            string fname = GetFileName(ByteArray);
            string estensione = Path.GetExtension(fname).Trim(); ;

            string sw = Path.Combine(FilePath, prefix + oggi.ToString() + estensione);
            try {
                ScriviFile(sw, ByteArray, offset);

                System.Diagnostics.Process.Start(sw);
            }
            catch (Exception E) {
                QueryCreator.ShowException(E);
            }

        }
        void ScriviFile(string sw, byte[] documento, int offset) {
            // Legge il documento memorizzato nel DB e lo scrive nel file temp.
            if (Meta.IsEmpty) return;
            if (!Meta.GetFormData(true)) return;

            FileStream FS = new FileStream(sw, FileMode.Create, FileAccess.Write);

            int n = documento.Length - offset;
            if (n == 0) return;
            try {
                FS.Write(documento, offset, n);//<<<<<<<<<
                FS.Flush();
                FS.Close();
            }
            catch { }
        }
        void SetBytesForFileName(string S, byte[] B) {
            string fname = Path.GetFileName(S);
            byte[] b = Encoding.Default.GetBytes(fname);
            for (int i = 0; i < b.Length; i++) B[i] = b[i];
            B[b.Length] = 0;
        }
        int LengthForFileName(string S) {
            string fname = Path.GetFileName(S);
            return fname.Length + 1;
        }
        int GetOffsetForData(Byte[] B) {
            int i = 0;
            while (i < B.Length && B[i] != 0) i++;
            return i + 1;
        }
        string GetFileName(Byte[] B) {
            int len = 0;
            for (int i = 0; i < B.Length; i++) {
                len++;
                if (B[i] == 0) break;
            }
            byte[] b = new byte[len - 1];
            for (int i = 0; i < len - 1; i++) {
                b[i] = B[i];
            }
            return Encoding.Default.GetString(b);
        }
        private void btnVisualizzaCCdedicato_Click(object sender, EventArgs e) {
            VisualizzaAllegato("ccdedicato_doc");
        }

        private void btnVisualizzaDocCF_Click(object sender, EventArgs e) {
            VisualizzaAllegato("ccdedicato_cf");
        }

        private bool LeggiFlagEsenteBancaPredefinita() {
            DataTable tTreasurer = Meta.Conn.RUN_SELECT("treasurer", "*", null, QHS.AppAnd(QHS.CmpEq("flagdefault", "S"), QHS.BitSet("flag", 1)), null, false);
            if (tTreasurer.Rows.Count == 0) return false;
            else
                return true;
        }
    }
}
