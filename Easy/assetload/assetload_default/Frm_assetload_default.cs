
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
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using ep_functions;
using System.Globalization;
using funzioni_configurazione;
using System.Linq;
using q = metadatalibrary.MetaExpression;

namespace assetload_default//buonocaricoinventario//
{
    /// <summary>
    /// Summary description for frmbuonocaricoinventario.
    /// </summary>
    public class Frm_assetload_default : System.Windows.Forms.Form {
        DataTable tInventoryTree;

        public MetaData Meta;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;
        public dsmeta DS;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TextBox txtCredDeb;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEsercizio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNumero;
        private bool flagcreddeb;
        private bool flagcausale;
        private System.Windows.Forms.ComboBox cboCausale;
        private System.Windows.Forms.Button btnModificaCaricoBene;
        private System.Windows.Forms.Button btnScollegaCaricoBene;
        private System.Windows.Forms.Button btnCollegaCaricoBene;
        private System.Windows.Forms.DataGrid dgrCaricoBene;
        private System.Windows.Forms.GroupBox grpCausale;
        private System.Windows.Forms.GroupBox grpCred;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGrid dgrRatifica;
        private System.Windows.Forms.GroupBox grpMovimenti;
        private System.Windows.Forms.Button btnCollegaMov;
        private System.Windows.Forms.Button btnScollegaMov;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNumeroFin;
        private System.Windows.Forms.TextBox txtEsercizioFin;
        private System.Windows.Forms.ComboBox cboTipo;
        private object codicefase;
        private System.Windows.Forms.TabPage tabBuono;
        private System.Windows.Forms.TabPage tabRatifica;
        private System.Windows.Forms.TabPage tabOperazioni;
        private string descrizionefase;
        private System.Windows.Forms.TextBox txtRatifica;
        private MetaData Mspesaview;
        private bool Warning = false;
        private System.Windows.Forms.Button btnTipoBuono;
        private CheckBox chkTransmitted;
        private TabPage tabEP;
        private Button btnGeneraEP;
        private Button btnVisualizzaEP;
        private TabPage tabRival;
        private Button btnWizardAmortization;
        private Button btnScollegaAmmortamento;
        private Button btnCollegaAmmortamento;
        private Button btnModificaAmmortamento;
        private DataGrid dgrAmmortamenti;
        private GroupBox gboxtotali;
        private TextBox txttotali;
        private Label label8;
        private TextBox txtrival;
        private Label label7;
        private TextBox txtcarichi;
        private Label label5;
        private Button btnVisualizzaPreimpegni;
        private Button btnGeneraPreimpegni;
        private Button btnGeneraEpExp;
        private Button btnVisualizzaEpExp;
        private Button btnVisualizzaPreaccertamenti;
        private Button btnGeneraPreaccertamenti;
        private Button btnGeneraEpAcc;
        private Button btnVisualizzaEpAcc;
        private Button btnAggiungidaFattura;
        private Label labAltroEsercizio;
        private Label labEP;
        bool inChiusura = false;

        public Frm_assetload_default() {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            //QueryCreator.SetTableForPosting(DS.assetaccretionview,"assetaccretion");
            QueryCreator.SetTableForPosting(DS.assetacquireview, "assetacquire");
            QueryCreator.SetTableForPosting(DS.assetamortizationunloadview, "assetamortization");
            GetData.SetSorting(DS.historypaymentview, "ymov DESC,nmov DESC");
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing) {
            inChiusura = true;
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.DS = new assetload_default.dsmeta();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabBuono = new System.Windows.Forms.TabPage();
            this.gboxtotali = new System.Windows.Forms.GroupBox();
            this.txttotali = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtrival = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtcarichi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkTransmitted = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTipoBuono = new System.Windows.Forms.Button();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEsercizio = new System.Windows.Forms.TextBox();
            this.grpCausale = new System.Windows.Forms.GroupBox();
            this.cboCausale = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.grpCred = new System.Windows.Forms.GroupBox();
            this.txtCredDeb = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.tabOperazioni = new System.Windows.Forms.TabPage();
            this.btnAggiungidaFattura = new System.Windows.Forms.Button();
            this.dgrCaricoBene = new System.Windows.Forms.DataGrid();
            this.btnModificaCaricoBene = new System.Windows.Forms.Button();
            this.btnCollegaCaricoBene = new System.Windows.Forms.Button();
            this.btnScollegaCaricoBene = new System.Windows.Forms.Button();
            this.tabRival = new System.Windows.Forms.TabPage();
            this.btnWizardAmortization = new System.Windows.Forms.Button();
            this.btnScollegaAmmortamento = new System.Windows.Forms.Button();
            this.btnCollegaAmmortamento = new System.Windows.Forms.Button();
            this.btnModificaAmmortamento = new System.Windows.Forms.Button();
            this.dgrAmmortamenti = new System.Windows.Forms.DataGrid();
            this.tabRatifica = new System.Windows.Forms.TabPage();
            this.grpMovimenti = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNumeroFin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEsercizioFin = new System.Windows.Forms.TextBox();
            this.dgrRatifica = new System.Windows.Forms.DataGrid();
            this.btnScollegaMov = new System.Windows.Forms.Button();
            this.btnCollegaMov = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.txtRatifica = new System.Windows.Forms.TextBox();
            this.tabEP = new System.Windows.Forms.TabPage();
            this.labAltroEsercizio = new System.Windows.Forms.Label();
            this.labEP = new System.Windows.Forms.Label();
            this.btnVisualizzaPreimpegni = new System.Windows.Forms.Button();
            this.btnGeneraPreimpegni = new System.Windows.Forms.Button();
            this.btnGeneraEpExp = new System.Windows.Forms.Button();
            this.btnVisualizzaEpExp = new System.Windows.Forms.Button();
            this.btnVisualizzaPreaccertamenti = new System.Windows.Forms.Button();
            this.btnGeneraPreaccertamenti = new System.Windows.Forms.Button();
            this.btnGeneraEpAcc = new System.Windows.Forms.Button();
            this.btnVisualizzaEpAcc = new System.Windows.Forms.Button();
            this.btnGeneraEP = new System.Windows.Forms.Button();
            this.btnVisualizzaEP = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabBuono.SuspendLayout();
            this.gboxtotali.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.grpCausale.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpCred.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabOperazioni.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrCaricoBene)).BeginInit();
            this.tabRival.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrAmmortamenti)).BeginInit();
            this.tabRatifica.SuspendLayout();
            this.grpMovimenti.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrRatifica)).BeginInit();
            this.tabEP.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabBuono);
            this.tabControl1.Controls.Add(this.tabOperazioni);
            this.tabControl1.Controls.Add(this.tabRival);
            this.tabControl1.Controls.Add(this.tabRatifica);
            this.tabControl1.Controls.Add(this.tabEP);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(720, 429);
            this.tabControl1.TabIndex = 0;
            // 
            // tabBuono
            // 
            this.tabBuono.Controls.Add(this.gboxtotali);
            this.tabBuono.Controls.Add(this.chkTransmitted);
            this.tabBuono.Controls.Add(this.groupBox1);
            this.tabBuono.Controls.Add(this.groupBox5);
            this.tabBuono.Controls.Add(this.grpCausale);
            this.tabBuono.Controls.Add(this.groupBox2);
            this.tabBuono.Controls.Add(this.grpCred);
            this.tabBuono.Controls.Add(this.textBox13);
            this.tabBuono.Controls.Add(this.label11);
            this.tabBuono.Controls.Add(this.textBox14);
            this.tabBuono.Controls.Add(this.label16);
            this.tabBuono.Controls.Add(this.label17);
            this.tabBuono.Controls.Add(this.textBox15);
            this.tabBuono.Controls.Add(this.groupBox3);
            this.tabBuono.Location = new System.Drawing.Point(4, 22);
            this.tabBuono.Name = "tabBuono";
            this.tabBuono.Size = new System.Drawing.Size(712, 403);
            this.tabBuono.TabIndex = 0;
            this.tabBuono.Text = "Principale";
            this.tabBuono.UseVisualStyleBackColor = true;
            // 
            // gboxtotali
            // 
            this.gboxtotali.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxtotali.Controls.Add(this.txttotali);
            this.gboxtotali.Controls.Add(this.label8);
            this.gboxtotali.Controls.Add(this.txtrival);
            this.gboxtotali.Controls.Add(this.label7);
            this.gboxtotali.Controls.Add(this.txtcarichi);
            this.gboxtotali.Controls.Add(this.label5);
            this.gboxtotali.Location = new System.Drawing.Point(552, 9);
            this.gboxtotali.Name = "gboxtotali";
            this.gboxtotali.Size = new System.Drawing.Size(136, 170);
            this.gboxtotali.TabIndex = 69;
            this.gboxtotali.TabStop = false;
            this.gboxtotali.Text = "Totali";
            // 
            // txttotali
            // 
            this.txttotali.Location = new System.Drawing.Point(10, 138);
            this.txttotali.Name = "txttotali";
            this.txttotali.ReadOnly = true;
            this.txttotali.Size = new System.Drawing.Size(100, 20);
            this.txttotali.TabIndex = 5;
            this.txttotali.TabStop = false;
            this.txttotali.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(7, 122);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Totale buono";
            // 
            // txtrival
            // 
            this.txtrival.Location = new System.Drawing.Point(9, 81);
            this.txtrival.Name = "txtrival";
            this.txtrival.ReadOnly = true;
            this.txtrival.Size = new System.Drawing.Size(100, 20);
            this.txtrival.TabIndex = 3;
            this.txtrival.TabStop = false;
            this.txtrival.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Rivalutazioni";
            // 
            // txtcarichi
            // 
            this.txtcarichi.Location = new System.Drawing.Point(10, 33);
            this.txtcarichi.Name = "txtcarichi";
            this.txtcarichi.ReadOnly = true;
            this.txtcarichi.Size = new System.Drawing.Size(100, 20);
            this.txtcarichi.TabIndex = 1;
            this.txtcarichi.TabStop = false;
            this.txtcarichi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Carichi";
            // 
            // chkTransmitted
            // 
            this.chkTransmitted.AutoSize = true;
            this.chkTransmitted.Location = new System.Drawing.Point(483, 365);
            this.chkTransmitted.Name = "chkTransmitted";
            this.chkTransmitted.Size = new System.Drawing.Size(77, 17);
            this.chkTransmitted.TabIndex = 68;
            this.chkTransmitted.Tag = "assetload.transmitted:S:N";
            this.chkTransmitted.Text = "Trasmesso";
            this.chkTransmitted.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnTipoBuono);
            this.groupBox1.Controls.Add(this.cboTipo);
            this.groupBox1.Location = new System.Drawing.Point(8, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(538, 48);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnTipoBuono
            // 
            this.btnTipoBuono.Location = new System.Drawing.Point(8, 15);
            this.btnTipoBuono.Name = "btnTipoBuono";
            this.btnTipoBuono.Size = new System.Drawing.Size(72, 22);
            this.btnTipoBuono.TabIndex = 176;
            this.btnTipoBuono.Tag = "choose.assetloadkind.default";
            this.btnTipoBuono.Text = "Tipo buono";
            // 
            // cboTipo
            // 
            this.cboTipo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTipo.DataSource = this.DS.assetloadkind;
            this.cboTipo.DisplayMember = "description";
            this.cboTipo.Location = new System.Drawing.Point(96, 16);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(434, 21);
            this.cboTipo.TabIndex = 2;
            this.cboTipo.Tag = "assetload.idassetloadkind.(active=\'S\')";
            this.cboTipo.ValueMember = "idassetloadkind";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.txtNumero);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.txtEsercizio);
            this.groupBox5.Location = new System.Drawing.Point(8, 51);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(160, 72);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 62;
            this.label3.Text = "Numero";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(72, 40);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(64, 20);
            this.txtNumero.TabIndex = 1;
            this.txtNumero.Tag = "assetload.nassetload";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 60;
            this.label2.Text = "Esercizio";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEsercizio
            // 
            this.txtEsercizio.Location = new System.Drawing.Point(72, 16);
            this.txtEsercizio.Name = "txtEsercizio";
            this.txtEsercizio.ReadOnly = true;
            this.txtEsercizio.Size = new System.Drawing.Size(64, 20);
            this.txtEsercizio.TabIndex = 59;
            this.txtEsercizio.TabStop = false;
            this.txtEsercizio.Tag = "assetload.yassetload.year";
            // 
            // grpCausale
            // 
            this.grpCausale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCausale.Controls.Add(this.cboCausale);
            this.grpCausale.Location = new System.Drawing.Point(8, 187);
            this.grpCausale.Name = "grpCausale";
            this.grpCausale.Size = new System.Drawing.Size(680, 48);
            this.grpCausale.TabIndex = 5;
            this.grpCausale.TabStop = false;
            this.grpCausale.Tag = "";
            this.grpCausale.Text = "Causale di carico";
            // 
            // cboCausale
            // 
            this.cboCausale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCausale.DataSource = this.DS.assetloadmotive;
            this.cboCausale.DisplayMember = "description";
            this.cboCausale.Location = new System.Drawing.Point(16, 14);
            this.cboCausale.Name = "cboCausale";
            this.cboCausale.Size = new System.Drawing.Size(656, 21);
            this.cboCausale.TabIndex = 48;
            this.cboCausale.Tag = "assetload.idmot.(active=\'S\')";
            this.cboCausale.ValueMember = "idmot";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.textBox11);
            this.groupBox2.Controls.Add(this.textBox12);
            this.groupBox2.Location = new System.Drawing.Point(288, 235);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(400, 96);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Provvedimento";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.Location = new System.Drawing.Point(264, 72);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 16);
            this.label15.TabIndex = 75;
            this.label15.Text = "Data:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox11
            // 
            this.textBox11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox11.Location = new System.Drawing.Point(304, 72);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(80, 20);
            this.textBox11.TabIndex = 74;
            this.textBox11.Tag = "assetload.enactmentdate";
            // 
            // textBox12
            // 
            this.textBox12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox12.Location = new System.Drawing.Point(8, 16);
            this.textBox12.Multiline = true;
            this.textBox12.Name = "textBox12";
            this.textBox12.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox12.Size = new System.Drawing.Size(384, 48);
            this.textBox12.TabIndex = 72;
            this.textBox12.Tag = "assetload.enactment";
            // 
            // grpCred
            // 
            this.grpCred.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCred.Controls.Add(this.txtCredDeb);
            this.grpCred.Location = new System.Drawing.Point(8, 131);
            this.grpCred.Name = "grpCred";
            this.grpCred.Size = new System.Drawing.Size(538, 48);
            this.grpCred.TabIndex = 4;
            this.grpCred.TabStop = false;
            this.grpCred.Tag = "AutoChoose.txtCredDeb.lista.(active=\'S\')";
            this.grpCred.Text = "Cedente";
            // 
            // txtCredDeb
            // 
            this.txtCredDeb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCredDeb.Location = new System.Drawing.Point(16, 16);
            this.txtCredDeb.Name = "txtCredDeb";
            this.txtCredDeb.Size = new System.Drawing.Size(506, 20);
            this.txtCredDeb.TabIndex = 1;
            this.txtCredDeb.Tag = "registry.title?assetloadview.registry";
            // 
            // textBox13
            // 
            this.textBox13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox13.Location = new System.Drawing.Point(184, 67);
            this.textBox13.Multiline = true;
            this.textBox13.Name = "textBox13";
            this.textBox13.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox13.Size = new System.Drawing.Size(362, 56);
            this.textBox13.TabIndex = 3;
            this.textBox13.Tag = "assetload.description";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(184, 51);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 16);
            this.label11.TabIndex = 64;
            this.label11.Text = "Descrizione:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(128, 339);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(80, 20);
            this.textBox14.TabIndex = 8;
            this.textBox14.Tag = "assetload.adate";
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(16, 339);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(96, 16);
            this.label16.TabIndex = 65;
            this.label16.Text = "Data contabile";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(16, 363);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(96, 16);
            this.label17.TabIndex = 67;
            this.label17.Text = "Data stampa";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(128, 363);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(80, 20);
            this.textBox15.TabIndex = 9;
            this.textBox15.Tag = "assetload.printdate";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox4);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.textBox5);
            this.groupBox3.Location = new System.Drawing.Point(8, 235);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(272, 96);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Documento";
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.Location = new System.Drawing.Point(144, 72);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(112, 20);
            this.textBox4.TabIndex = 65;
            this.textBox4.Tag = "assetload.docdate";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Location = new System.Drawing.Point(104, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 16);
            this.label6.TabIndex = 66;
            this.label6.Text = "Data:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox5
            // 
            this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox5.Location = new System.Drawing.Point(8, 16);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox5.Size = new System.Drawing.Size(256, 48);
            this.textBox5.TabIndex = 63;
            this.textBox5.Tag = "assetload.doc";
            // 
            // tabOperazioni
            // 
            this.tabOperazioni.Controls.Add(this.btnAggiungidaFattura);
            this.tabOperazioni.Controls.Add(this.dgrCaricoBene);
            this.tabOperazioni.Controls.Add(this.btnModificaCaricoBene);
            this.tabOperazioni.Controls.Add(this.btnCollegaCaricoBene);
            this.tabOperazioni.Controls.Add(this.btnScollegaCaricoBene);
            this.tabOperazioni.Location = new System.Drawing.Point(4, 22);
            this.tabOperazioni.Name = "tabOperazioni";
            this.tabOperazioni.Size = new System.Drawing.Size(712, 403);
            this.tabOperazioni.TabIndex = 1;
            this.tabOperazioni.Text = "Cespiti e accessori";
            this.tabOperazioni.UseVisualStyleBackColor = true;
            // 
            // btnAggiungidaFattura
            // 
            this.btnAggiungidaFattura.Location = new System.Drawing.Point(428, 5);
            this.btnAggiungidaFattura.Name = "btnAggiungidaFattura";
            this.btnAggiungidaFattura.Size = new System.Drawing.Size(141, 22);
            this.btnAggiungidaFattura.TabIndex = 6;
            this.btnAggiungidaFattura.Text = "Aggiungi da Fattura";
            this.btnAggiungidaFattura.UseVisualStyleBackColor = true;
            this.btnAggiungidaFattura.Click += new System.EventHandler(this.btnAggiungidaFattura_Click);
            // 
            // dgrCaricoBene
            // 
            this.dgrCaricoBene.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrCaricoBene.CaptionVisible = false;
            this.dgrCaricoBene.DataMember = "";
            this.dgrCaricoBene.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgrCaricoBene.Location = new System.Drawing.Point(8, 33);
            this.dgrCaricoBene.Name = "dgrCaricoBene";
            this.dgrCaricoBene.Size = new System.Drawing.Size(688, 362);
            this.dgrCaricoBene.TabIndex = 5;
            this.dgrCaricoBene.TabStop = false;
            this.dgrCaricoBene.Tag = "assetacquireview.buonodicarico";
            // 
            // btnModificaCaricoBene
            // 
            this.btnModificaCaricoBene.Location = new System.Drawing.Point(170, 4);
            this.btnModificaCaricoBene.Name = "btnModificaCaricoBene";
            this.btnModificaCaricoBene.Size = new System.Drawing.Size(75, 23);
            this.btnModificaCaricoBene.TabIndex = 3;
            this.btnModificaCaricoBene.Text = "Correggi";
            this.btnModificaCaricoBene.Click += new System.EventHandler(this.btnModificaCaricoBene_Click);
            // 
            // btnCollegaCaricoBene
            // 
            this.btnCollegaCaricoBene.Location = new System.Drawing.Point(8, 3);
            this.btnCollegaCaricoBene.Name = "btnCollegaCaricoBene";
            this.btnCollegaCaricoBene.Size = new System.Drawing.Size(75, 24);
            this.btnCollegaCaricoBene.TabIndex = 1;
            this.btnCollegaCaricoBene.Tag = "";
            this.btnCollegaCaricoBene.Text = "Aggiungi";
            this.btnCollegaCaricoBene.Click += new System.EventHandler(this.btnCollegaCaricoBene_Click);
            // 
            // btnScollegaCaricoBene
            // 
            this.btnScollegaCaricoBene.Location = new System.Drawing.Point(89, 3);
            this.btnScollegaCaricoBene.Name = "btnScollegaCaricoBene";
            this.btnScollegaCaricoBene.Size = new System.Drawing.Size(75, 24);
            this.btnScollegaCaricoBene.TabIndex = 2;
            this.btnScollegaCaricoBene.Tag = "";
            this.btnScollegaCaricoBene.Text = "Rimuovi";
            this.btnScollegaCaricoBene.Click += new System.EventHandler(this.btnScollegaCaricoBene_Click);
            // 
            // tabRival
            // 
            this.tabRival.Controls.Add(this.btnWizardAmortization);
            this.tabRival.Controls.Add(this.btnScollegaAmmortamento);
            this.tabRival.Controls.Add(this.btnCollegaAmmortamento);
            this.tabRival.Controls.Add(this.btnModificaAmmortamento);
            this.tabRival.Controls.Add(this.dgrAmmortamenti);
            this.tabRival.Location = new System.Drawing.Point(4, 22);
            this.tabRival.Name = "tabRival";
            this.tabRival.Padding = new System.Windows.Forms.Padding(3);
            this.tabRival.Size = new System.Drawing.Size(712, 403);
            this.tabRival.TabIndex = 4;
            this.tabRival.Text = "Rivalutazioni";
            this.tabRival.UseVisualStyleBackColor = true;
            // 
            // btnWizardAmortization
            // 
            this.btnWizardAmortization.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWizardAmortization.Location = new System.Drawing.Point(599, 13);
            this.btnWizardAmortization.Name = "btnWizardAmortization";
            this.btnWizardAmortization.Size = new System.Drawing.Size(105, 22);
            this.btnWizardAmortization.TabIndex = 14;
            this.btnWizardAmortization.Text = "Aggiunta guidata";
            this.btnWizardAmortization.UseVisualStyleBackColor = true;
            this.btnWizardAmortization.Click += new System.EventHandler(this.btnWizardAmortization_Click);
            // 
            // btnScollegaAmmortamento
            // 
            this.btnScollegaAmmortamento.Location = new System.Drawing.Point(88, 12);
            this.btnScollegaAmmortamento.Name = "btnScollegaAmmortamento";
            this.btnScollegaAmmortamento.Size = new System.Drawing.Size(75, 24);
            this.btnScollegaAmmortamento.TabIndex = 11;
            this.btnScollegaAmmortamento.Tag = "";
            this.btnScollegaAmmortamento.Text = "Rimuovi";
            this.btnScollegaAmmortamento.Click += new System.EventHandler(this.btnScollegaAmmortamento_Click);
            // 
            // btnCollegaAmmortamento
            // 
            this.btnCollegaAmmortamento.Location = new System.Drawing.Point(8, 12);
            this.btnCollegaAmmortamento.Name = "btnCollegaAmmortamento";
            this.btnCollegaAmmortamento.Size = new System.Drawing.Size(75, 24);
            this.btnCollegaAmmortamento.TabIndex = 10;
            this.btnCollegaAmmortamento.Tag = "";
            this.btnCollegaAmmortamento.Text = "Aggiungi";
            this.btnCollegaAmmortamento.Click += new System.EventHandler(this.btnCollegaAmmortamento_Click);
            // 
            // btnModificaAmmortamento
            // 
            this.btnModificaAmmortamento.Location = new System.Drawing.Point(168, 12);
            this.btnModificaAmmortamento.Name = "btnModificaAmmortamento";
            this.btnModificaAmmortamento.Size = new System.Drawing.Size(75, 23);
            this.btnModificaAmmortamento.TabIndex = 13;
            this.btnModificaAmmortamento.Text = "Correggi";
            this.btnModificaAmmortamento.Click += new System.EventHandler(this.btnModificaAmmortamento_Click);
            // 
            // dgrAmmortamenti
            // 
            this.dgrAmmortamenti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrAmmortamenti.CaptionVisible = false;
            this.dgrAmmortamenti.DataMember = "";
            this.dgrAmmortamenti.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgrAmmortamenti.Location = new System.Drawing.Point(8, 41);
            this.dgrAmmortamenti.Name = "dgrAmmortamenti";
            this.dgrAmmortamenti.Size = new System.Drawing.Size(696, 350);
            this.dgrAmmortamenti.TabIndex = 12;
            this.dgrAmmortamenti.TabStop = false;
            this.dgrAmmortamenti.Tag = "assetamortizationunloadview.buonocarico";
            // 
            // tabRatifica
            // 
            this.tabRatifica.Controls.Add(this.grpMovimenti);
            this.tabRatifica.Controls.Add(this.label13);
            this.tabRatifica.Controls.Add(this.txtRatifica);
            this.tabRatifica.Location = new System.Drawing.Point(4, 22);
            this.tabRatifica.Name = "tabRatifica";
            this.tabRatifica.Size = new System.Drawing.Size(712, 403);
            this.tabRatifica.TabIndex = 2;
            this.tabRatifica.Text = "Ratifica";
            this.tabRatifica.UseVisualStyleBackColor = true;
            // 
            // grpMovimenti
            // 
            this.grpMovimenti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpMovimenti.Controls.Add(this.label4);
            this.grpMovimenti.Controls.Add(this.txtNumeroFin);
            this.grpMovimenti.Controls.Add(this.label1);
            this.grpMovimenti.Controls.Add(this.txtEsercizioFin);
            this.grpMovimenti.Controls.Add(this.dgrRatifica);
            this.grpMovimenti.Controls.Add(this.btnScollegaMov);
            this.grpMovimenti.Controls.Add(this.btnCollegaMov);
            this.grpMovimenti.Location = new System.Drawing.Point(8, 48);
            this.grpMovimenti.Name = "grpMovimenti";
            this.grpMovimenti.Size = new System.Drawing.Size(696, 343);
            this.grpMovimenti.TabIndex = 2;
            this.grpMovimenti.TabStop = false;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(128, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 39;
            this.label4.Text = "Numero";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNumeroFin
            // 
            this.txtNumeroFin.Location = new System.Drawing.Point(184, 25);
            this.txtNumeroFin.Name = "txtNumeroFin";
            this.txtNumeroFin.Size = new System.Drawing.Size(48, 20);
            this.txtNumeroFin.TabIndex = 2;
            this.txtNumeroFin.Tag = "";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 37;
            this.label1.Text = "Esercizio";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEsercizioFin
            // 
            this.txtEsercizioFin.Location = new System.Drawing.Point(72, 25);
            this.txtEsercizioFin.Name = "txtEsercizioFin";
            this.txtEsercizioFin.Size = new System.Drawing.Size(48, 20);
            this.txtEsercizioFin.TabIndex = 1;
            this.txtEsercizioFin.Tag = "";
            this.txtEsercizioFin.Leave += new System.EventHandler(this.txtEsercizioFin_Leave);
            // 
            // dgrRatifica
            // 
            this.dgrRatifica.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrRatifica.CaptionVisible = false;
            this.dgrRatifica.DataMember = "";
            this.dgrRatifica.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgrRatifica.Location = new System.Drawing.Point(8, 56);
            this.dgrRatifica.Name = "dgrRatifica";
            this.dgrRatifica.Size = new System.Drawing.Size(680, 279);
            this.dgrRatifica.TabIndex = 3;
            this.dgrRatifica.TabStop = false;
            this.dgrRatifica.Tag = "assetloadexpense.ratifica";
            // 
            // btnScollegaMov
            // 
            this.btnScollegaMov.Location = new System.Drawing.Point(368, 24);
            this.btnScollegaMov.Name = "btnScollegaMov";
            this.btnScollegaMov.Size = new System.Drawing.Size(75, 23);
            this.btnScollegaMov.TabIndex = 4;
            this.btnScollegaMov.Tag = "delete";
            this.btnScollegaMov.Text = "Rimuovi";
            // 
            // btnCollegaMov
            // 
            this.btnCollegaMov.Location = new System.Drawing.Point(288, 24);
            this.btnCollegaMov.Name = "btnCollegaMov";
            this.btnCollegaMov.Size = new System.Drawing.Size(75, 23);
            this.btnCollegaMov.TabIndex = 3;
            this.btnCollegaMov.Text = "Inserisci";
            this.btnCollegaMov.Click += new System.EventHandler(this.btnCollegaMov_Click);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(16, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 16);
            this.label13.TabIndex = 68;
            this.label13.Text = "Data ratifica";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRatifica
            // 
            this.txtRatifica.Location = new System.Drawing.Point(96, 14);
            this.txtRatifica.Name = "txtRatifica";
            this.txtRatifica.Size = new System.Drawing.Size(80, 20);
            this.txtRatifica.TabIndex = 1;
            this.txtRatifica.Tag = "assetload.ratificationdate.d";
            this.txtRatifica.Leave += new System.EventHandler(this.txtRatifica_Leave);
            // 
            // tabEP
            // 
            this.tabEP.Controls.Add(this.labAltroEsercizio);
            this.tabEP.Controls.Add(this.labEP);
            this.tabEP.Controls.Add(this.btnVisualizzaPreimpegni);
            this.tabEP.Controls.Add(this.btnGeneraPreimpegni);
            this.tabEP.Controls.Add(this.btnGeneraEpExp);
            this.tabEP.Controls.Add(this.btnVisualizzaEpExp);
            this.tabEP.Controls.Add(this.btnVisualizzaPreaccertamenti);
            this.tabEP.Controls.Add(this.btnGeneraPreaccertamenti);
            this.tabEP.Controls.Add(this.btnGeneraEpAcc);
            this.tabEP.Controls.Add(this.btnVisualizzaEpAcc);
            this.tabEP.Controls.Add(this.btnGeneraEP);
            this.tabEP.Controls.Add(this.btnVisualizzaEP);
            this.tabEP.Location = new System.Drawing.Point(4, 22);
            this.tabEP.Name = "tabEP";
            this.tabEP.Padding = new System.Windows.Forms.Padding(3);
            this.tabEP.Size = new System.Drawing.Size(712, 403);
            this.tabEP.TabIndex = 3;
            this.tabEP.Text = "E/P";
            this.tabEP.UseVisualStyleBackColor = true;
            // 
            // labAltroEsercizio
            // 
            this.labAltroEsercizio.AutoSize = true;
            this.labAltroEsercizio.Location = new System.Drawing.Point(15, 40);
            this.labAltroEsercizio.Name = "labAltroEsercizio";
            this.labAltroEsercizio.Size = new System.Drawing.Size(165, 13);
            this.labAltroEsercizio.TabIndex = 69;
            this.labAltroEsercizio.Text = "Il buono non è di questo esercizio";
            // 
            // labEP
            // 
            this.labEP.AutoSize = true;
            this.labEP.Location = new System.Drawing.Point(15, 16);
            this.labEP.Name = "labEP";
            this.labEP.Size = new System.Drawing.Size(237, 13);
            this.labEP.TabIndex = 68;
            this.labEP.Text = "Le scritture in partita doppia sono state generate.";
            // 
            // btnVisualizzaPreimpegni
            // 
            this.btnVisualizzaPreimpegni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVisualizzaPreimpegni.Location = new System.Drawing.Point(329, 150);
            this.btnVisualizzaPreimpegni.Name = "btnVisualizzaPreimpegni";
            this.btnVisualizzaPreimpegni.Size = new System.Drawing.Size(348, 23);
            this.btnVisualizzaPreimpegni.TabIndex = 67;
            this.btnVisualizzaPreimpegni.TabStop = false;
            this.btnVisualizzaPreimpegni.Text = "Visualizza Preimpegni di Budget";
            // 
            // btnGeneraPreimpegni
            // 
            this.btnGeneraPreimpegni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGeneraPreimpegni.Location = new System.Drawing.Point(329, 111);
            this.btnGeneraPreimpegni.Name = "btnGeneraPreimpegni";
            this.btnGeneraPreimpegni.Size = new System.Drawing.Size(348, 23);
            this.btnGeneraPreimpegni.TabIndex = 66;
            this.btnGeneraPreimpegni.TabStop = false;
            this.btnGeneraPreimpegni.Text = "Genera Preimpegni di Budget";
            // 
            // btnGeneraEpExp
            // 
            this.btnGeneraEpExp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGeneraEpExp.Location = new System.Drawing.Point(329, 30);
            this.btnGeneraEpExp.Name = "btnGeneraEpExp";
            this.btnGeneraEpExp.Size = new System.Drawing.Size(348, 23);
            this.btnGeneraEpExp.TabIndex = 64;
            this.btnGeneraEpExp.TabStop = false;
            this.btnGeneraEpExp.Text = "Genera Impegni di Budget";
            // 
            // btnVisualizzaEpExp
            // 
            this.btnVisualizzaEpExp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVisualizzaEpExp.Location = new System.Drawing.Point(329, 70);
            this.btnVisualizzaEpExp.Name = "btnVisualizzaEpExp";
            this.btnVisualizzaEpExp.Size = new System.Drawing.Size(348, 23);
            this.btnVisualizzaEpExp.TabIndex = 65;
            this.btnVisualizzaEpExp.TabStop = false;
            this.btnVisualizzaEpExp.Text = "Visualizza Impegni di Budget";
            // 
            // btnVisualizzaPreaccertamenti
            // 
            this.btnVisualizzaPreaccertamenti.Location = new System.Drawing.Point(18, 313);
            this.btnVisualizzaPreaccertamenti.Name = "btnVisualizzaPreaccertamenti";
            this.btnVisualizzaPreaccertamenti.Size = new System.Drawing.Size(328, 23);
            this.btnVisualizzaPreaccertamenti.TabIndex = 63;
            this.btnVisualizzaPreaccertamenti.TabStop = false;
            this.btnVisualizzaPreaccertamenti.Text = "Visualizza Preaccertamenti di Budget";
            this.btnVisualizzaPreaccertamenti.Visible = false;
            // 
            // btnGeneraPreaccertamenti
            // 
            this.btnGeneraPreaccertamenti.Location = new System.Drawing.Point(18, 274);
            this.btnGeneraPreaccertamenti.Name = "btnGeneraPreaccertamenti";
            this.btnGeneraPreaccertamenti.Size = new System.Drawing.Size(328, 23);
            this.btnGeneraPreaccertamenti.TabIndex = 62;
            this.btnGeneraPreaccertamenti.TabStop = false;
            this.btnGeneraPreaccertamenti.Text = "Genera Preaccertamenti di Budget";
            this.btnGeneraPreaccertamenti.Visible = false;
            // 
            // btnGeneraEpAcc
            // 
            this.btnGeneraEpAcc.Location = new System.Drawing.Point(18, 193);
            this.btnGeneraEpAcc.Name = "btnGeneraEpAcc";
            this.btnGeneraEpAcc.Size = new System.Drawing.Size(328, 23);
            this.btnGeneraEpAcc.TabIndex = 60;
            this.btnGeneraEpAcc.TabStop = false;
            this.btnGeneraEpAcc.Text = "Genera Accertamenti di Budget";
            this.btnGeneraEpAcc.Visible = false;
            // 
            // btnVisualizzaEpAcc
            // 
            this.btnVisualizzaEpAcc.Location = new System.Drawing.Point(18, 233);
            this.btnVisualizzaEpAcc.Name = "btnVisualizzaEpAcc";
            this.btnVisualizzaEpAcc.Size = new System.Drawing.Size(328, 23);
            this.btnVisualizzaEpAcc.TabIndex = 61;
            this.btnVisualizzaEpAcc.TabStop = false;
            this.btnVisualizzaEpAcc.Text = "Visualizza Accertamenti di Budget";
            this.btnVisualizzaEpAcc.Visible = false;
            // 
            // btnGeneraEP
            // 
            this.btnGeneraEP.Location = new System.Drawing.Point(15, 108);
            this.btnGeneraEP.Name = "btnGeneraEP";
            this.btnGeneraEP.Size = new System.Drawing.Size(224, 23);
            this.btnGeneraEP.TabIndex = 21;
            this.btnGeneraEP.Text = "Genera le scritture in partita doppia";
            // 
            // btnVisualizzaEP
            // 
            this.btnVisualizzaEP.Location = new System.Drawing.Point(15, 76);
            this.btnVisualizzaEP.Name = "btnVisualizzaEP";
            this.btnVisualizzaEP.Size = new System.Drawing.Size(224, 23);
            this.btnVisualizzaEP.TabIndex = 20;
            this.btnVisualizzaEP.Text = "Visualizza le scritture in partita doppia";
            // 
            // Frm_assetload_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(720, 429);
            this.Controls.Add(this.tabControl1);
            this.Name = "Frm_assetload_default";
            this.Text = "frmbuonocaricoinventario";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabBuono.ResumeLayout(false);
            this.tabBuono.PerformLayout();
            this.gboxtotali.ResumeLayout(false);
            this.gboxtotali.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.grpCausale.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpCred.ResumeLayout(false);
            this.grpCred.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabOperazioni.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrCaricoBene)).EndInit();
            this.tabRival.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrAmmortamenti)).EndInit();
            this.tabRatifica.ResumeLayout(false);
            this.tabRatifica.PerformLayout();
            this.grpMovimenti.ResumeLayout(false);
            this.grpMovimenti.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrRatifica)).EndInit();
            this.tabEP.ResumeLayout(false);
            this.tabEP.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private void assegnaColoriAiButton() {
            btnCollegaCaricoBene.ForeColor = formcolors.GridButtonForeColor();
            btnCollegaCaricoBene.BackColor = formcolors.GridHeaderBackColor();
            btnScollegaCaricoBene.ForeColor = formcolors.GridButtonForeColor();
            btnScollegaCaricoBene.BackColor = formcolors.GridHeaderBackColor();
            btnModificaCaricoBene.ForeColor = formcolors.GridButtonForeColor();
            btnModificaCaricoBene.BackColor = formcolors.GridHeaderBackColor();
            btnCollegaAmmortamento.ForeColor = formcolors.GridButtonForeColor();
            btnCollegaAmmortamento.BackColor = formcolors.GridHeaderBackColor();
            btnScollegaAmmortamento.ForeColor = formcolors.GridButtonForeColor();
            btnScollegaAmmortamento.BackColor = formcolors.GridHeaderBackColor();
            btnModificaAmmortamento.ForeColor = formcolors.GridButtonForeColor();
            btnModificaAmmortamento.BackColor = formcolors.GridHeaderBackColor();
            btnCollegaMov.ForeColor = formcolors.GridButtonForeColor();
            btnCollegaMov.BackColor = formcolors.GridHeaderBackColor();
        }

        public void MetaData_AfterClear() {
            gboxtotali.Visible = false;
            EsaminaFlag();
            txtEsercizio.ReadOnly = false;
            txtNumero.ReadOnly = false;
            txtEsercizio.Text = Meta.GetSys("esercizio").ToString();
            txtEsercizioFin.Text = Meta.GetSys("esercizio").ToString();
            txtNumeroFin.Text = "";
            //			btnCreaAumentoValore.Enabled=false;
            Meta.UnMarkTableAsNotEntityChild(DS.assetamortizationunloadview);
            Meta.UnMarkTableAsNotEntityChild(DS.assetacquireview);
            //btnCreaCaricoBene.Enabled = false;
            btnAggiungidaFattura.Enabled = false;
            EPM.mostraEtichette();
        }
        private EP_Manager EPM;
        QueryHelper QHS;
        CQueryHelper QHC;
        DataAccess Conn;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            string filteresercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            GetData.CacheTable(DS.config, filteresercizio, null, false);
            GetData.CacheTable(DS.expensephase, null, "nphase", true);
            //GetData.CacheTable(DS.assetloadmotive,null,"description",true);
            //Mspesaview=MetaData.GetMetaData(this,"expenseview");
            Mspesaview = MetaData.GetMetaData(this, "historypaymentview");
            tInventoryTree = DataAccess.CreateTableByName(Meta.Conn, "inventorytree", "*");
            QueryCreator.SetTableForPosting(DS.assetamortizationunloadview, "assetamortization");
            EPM = new EP_Manager(Meta, btnGeneraEpExp, btnVisualizzaEpExp, btnGeneraPreimpegni, btnVisualizzaPreimpegni,
                         btnGeneraEP, btnVisualizzaEP, labEP, labAltroEsercizio, "assetload");



        }

        public void MetaData_AfterActivation() {
            EsaminaFlag();
            codicefase = Meta.GetSys("maxexpensephase");
            DataRow[] rows = DS.expensephase.Select(QHC.CmpEq("nphase", codicefase));
            if (rows.Length > 0) {
                descrizionefase = rows[0]["description"].ToString();
            }
            else {
                descrizionefase = "Nessuna fase esistente!";
            }
            grpMovimenti.Text = descrizionefase;
            assegnaColoriAiButton();
        }
        void CalcolaTotali() {
            gboxtotali.Visible = true;
            decimal totcarichi = MetaData.SumColumn(DS.assetacquireview, "total");
            decimal totrival = MetaData.SumColumn(DS.assetamortizationunloadview, "amount");
            decimal tot = totcarichi + totrival;
            txtcarichi.Text = totcarichi.ToString("n");
            txtrival.Text = totrival.ToString("n");
            txttotali.Text = tot.ToString("n");
        }
        public void MetaData_AfterFill() {
            if (Meta.IsEmpty) return;
            CalcolaTotali();                                                             
            if (Meta.EditMode || Meta.InsertMode) {
                txtEsercizio.ReadOnly = true;
                txtNumero.ReadOnly = true;
            }
            else {
                txtEsercizio.ReadOnly = false;
                txtNumero.ReadOnly = false;
            }
            //			btnCreaAumentoValore.Enabled=Meta.EditMode;
            //btnCreaCaricoBene.Enabled = Meta.EditMode;

            //ControlloRatifica();
            EsaminaFlag();
            EsaminaVincoliFigli();
            ValorizzaVariabiliUtente();
            EPM.mostraEtichette();
            btnAggiungidaFattura.Enabled = DS.assetacquireview.Count==0 && DS.assetamortizationunloadview.Count == 0;
        }

        /*private void AbilitaRatificaCampo(bool enable) {
			txtRatifica.ReadOnly=!enable;
		}
		private void AbilitaRatificaGrid(bool enable) {
			btnCollegaMov.Enabled=enable;
			btnScollegaMov.Enabled=enable;
		}
		private void AbilitaRatifica(bool enable) {
			AbilitaRatificaCampo(enable);
			AbilitaRatificaGrid(enable);
		}*/

      

        //string idrelated = "";
        //bool fromDelete = false;
        public void MetaData_BeforePost() {
            EPM.beforePost();
        }

        public void MetaData_AfterPost() {
            EPM.afterPost();
        }

        private void ParseDate(TextBox T) {
            if (!T.Enabled) return;
            if (T.ReadOnly) return;
            if (T.Text == "") return;
            string tag = HelpForm.GetStandardTag(T.Tag);
            //tag = tag+".d";
            string hhsep = CultureInfo.CurrentCulture.DateTimeFormat.TimeSeparator;
            string ppsep = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            string S = T.Text; //+hhsep+"0"+ppsep+"0";
            int len = S.Length;
            object O = DBNull.Value;
            while (len > 0) {
                try {
                    O = HelpForm.GetObjectFromString(typeof(DateTime), S, tag);
                    if ((O != null) && (O != DBNull.Value)) break;
                }
                catch {
                }
                len = len - 1;
                S = S.Substring(0, len);
            }
            T.Text = HelpForm.StringValue(O, tag);
        }

        private void ValorizzaVariabiliUtente() {
            if (Meta.IsEmpty) return;
            DataRow R = DS.assetload.Rows[0];
            Meta.Conn.SetUsr("frmbuonodicarico_causale",  R["idmot"]);
            Meta.Conn.SetUsr("frmbuonodicarico_codicecreddeb" ,R["idreg"]);

            if (R["idassetloadkind"] == DBNull.Value) {
                Meta.Conn.SetUsr("frmbuonodicarico_idinventory", DBNull.Value);
            }
            else {
                string filter = QHC.MCmp(R, "idassetloadkind");
                if (DS.assetloadkind.Select(filter).Length == 0) return;

                Meta.Conn.SetUsr("frmbuonodicarico_idinventory" ,
                    DS.assetloadkind.Select(filter)[0]["idinventory"]);
                //R["idinventory"].ToString();
            }

        }

        /// <summary>
        /// Abilitazione di creditore/debitore, causale
        /// </summary>
        private void EsaminaVincoliFigli() {
            bool causale = false;
            bool creditore = false;
            if (Meta.IsEmpty) return;
            DataRow CurrDoc = DS.assetload.Rows[0];
            DataSet DSaum = (DataSet)dgrAmmortamenti.DataSource;
            DataSet DSben = (DataSet)dgrCaricoBene.DataSource;
            //			DataSet DSpar = (DataSet)dgrCaricoParte.DataSource;
            DataTable Taum = DSaum.Tables[dgrAmmortamenti.DataMember.ToString()];
            DataTable Tben = DSben.Tables[dgrCaricoBene.DataMember.ToString()];
            //			DataTable Tpar = DSpar.Tables[dgrCaricoParte.DataMember.ToString()];

            //aumento valore bene
            //			if (Taum.Rows.Count > 0) {
            //				cboCausale.Enabled=false;
            //				if (flagcausale=="S") {
            //					HelpForm.SetComboBoxValue(cboCausale,Taum.Rows[0]["idmot"].ToString());
            //					CurrDoc["idmot"]=Taum.Rows[0]["idmot"];
            //					causale=true;
            //				}
            //				if (flagcreddeb=="S") {
            //					txtCredDeb.Text=Taum.Rows[0]["registry"].ToString();
            //					CurrDoc["idreg"]=Taum.Rows[0]["idreg"];
            //					creditore=true;
            //				}
            //			}
            //carico bene


            if (DS.assetacquireview.Rows.Count > 0) {
                DataRow DRassetacquireview = DS.assetacquireview.Rows[0]; //<-
                cboTipo.Enabled = false;
                btnTipoBuono.Enabled = false;
                if (!causale) {
                    cboCausale.Enabled = false;
                    if (flagcausale) {
                        object idmot = DRassetacquireview["idmot"];
                        DS.assetacquireview._IfNotExists(q.ne("idmot", idmot),
                            _then: () => {
                                HelpForm.SetComboBoxValue(cboCausale, idmot);
                                CurrDoc["idmot"] = idmot;
                                causale = true;
                            });

                        if (DS.assetacquireview.Select(QHC.CmpNe("idmot", idmot)).Length == 0) {
                            HelpForm.SetComboBoxValue(cboCausale, idmot);
                            CurrDoc["idmot"] = idmot;
                            causale = true;
                        }
                    }
                }
                if (!creditore) {
                    txtCredDeb.ReadOnly = true;
                    if (flagcreddeb) {
                        object idreg = DRassetacquireview["idreg"];
                        if (DS.assetacquireview.Select(QHC.CmpNe("idreg", idreg)).Length == 0) {
                            txtCredDeb.Text = DRassetacquireview["registry"].ToString();
                            CurrDoc["idreg"] = idreg;
                            creditore = true;
                        }
                    }
                }
            }
            else {
                if (DS.assetamortizationunloadview.Rows.Count > 0) {
                    cboTipo.Enabled = false;
                    btnTipoBuono.Enabled = false;
                }
                else {
                    cboTipo.Enabled = Meta.InsertMode;
                    btnTipoBuono.Enabled = Meta.InsertMode;
                }


            }

        }

        private void EsaminaFlag() {
            if (Warning) return;
            if (DS.config.Rows.Count == 0) {
                MessageBox.Show("La configurazione del PATRIMONIO non è stata definita per l'esercizio corrente. " +
                    "Non sarà possibile salvare il buono di carico.\r" +
                    @"La configurazione si trova alla voce di menu Configurazione\Operazioni inventariabili\Configurazione", "Attenzione",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Warning = true;
                Meta.CanSave = false;
                return;
            }
            DataRow r = DS.Tables["config"].Rows[0];
            string flagnumerazione = r["asset_flagnumbering"].ToString().ToUpper();
            if (flagnumerazione == "" || flagnumerazione == "N") {
                MessageBox.Show("Non è stato definito il tipo di numerazione per la configurazione " +
                    "del PATRIMONIO per l'esercizio corrente. " +
                    "Non sarà possibile salvare il buono di carico.\r" +
                    @"La configurazione si trova alla voce di menu Configurazione\Operazioni inventariabili\Configurazione", "Attenzione",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Warning = true;
                Meta.CanSave = false;
                return;
            }
            byte assetload_flag = (byte)r["assetload_flag"];
            flagcreddeb = (assetload_flag & 1) == 1;
            flagcausale = (assetload_flag & 2) == 2;
            txtCredDeb.ReadOnly = !flagcreddeb;
            cboCausale.Enabled = flagcausale;
            cboTipo.Enabled = true;
            btnTipoBuono.Enabled = true;

        }

        private string CalcolaFiltroDocCollegato(string tipo, bool SQL) {
            Meta.GetFormData(true);
            QueryHelper qh = SQL ? QHS : QHC;
            string filter = qh.AppAnd(qh.BitSet("flag", 0),
                            qh.IsNull("idassetload")
                            );
            if (tipo.ToUpper() == "A") filter = qh.AppAnd(filter, qh.CmpGt("amortizationquota", 0));

            //ricavo informazioni sul codiceinventario
            if (!Meta.IsEmpty) {
                DataRow R = DS.assetload.Rows[0];
                DataRow Rinv = R.GetParentRow("assetloadkindassetload");
                if (Rinv != null && Rinv["idinventory"] != DBNull.Value) {
                    filter = qh.AppAnd(filter, GetInventoryFilter(qh, Rinv["idinventory"]));
                }
            }
            //per aumentovalorebene il codicecreddeb non viene considerato
            if (tipo.ToUpper() != "A") {
                object codicecreddeb = DS.assetload.Rows[0]["idreg"];
                if (flagcreddeb) {
                    if (codicecreddeb == DBNull.Value) {
                        if (DS.assetacquireview.Select().Length > 0)
                            filter = qh.AppAnd(filter, qh.IsNull("idreg"));
                    }
                    else {
                        filter = qh.AppAnd(filter, qh.CmpEq("idreg", codicecreddeb));
                    }
                }
            }

            if (flagcausale && (tipo.ToUpper() != "A")) {
                object codicecausale = DS.assetload.Rows[0]["idmot"];
                if (codicecausale == DBNull.Value) {
                    if (DS.assetacquireview.Select().Length > 0)
                        filter = qh.AppAnd(filter, qh.IsNull("idmot"));
                }
                else {
                    filter = qh.AppAnd(filter, qh.CmpEq("idmot", codicecausale));
                }
            }
            return filter;
        }


        private MetaExpression getInvFilter(object idinventory) {
            MetaExpression filter = q.eq("idinventory", idinventory);
            string SQLfilterInv = QHS.CmpEq("idinventory", idinventory);
            var o = Conn.readObject("inventory", SQLfilterInv, "flag,idinventoryagency");
            int flag = CfgFn.GetNoNullInt32(o["flag"]);
            bool flagMixed = ((flag & 1) == 1);
            if (flagMixed) {
                object inventoryAgency = o["idinventoryagency"];
                string filterEnte = QHS.CmpEq("idinventoryagency", inventoryAgency);
                DataTable ListInvEnte = Meta.Conn.RUN_SELECT("inventory", "*", null, filterEnte, null, false);
                filter = q.fieldIn("idinventory", ListInvEnte.Select()._Pick("idinventory").ToArray());
            }

            return filter;
        }

        private string GetInventoryFilter(QueryHelper QH, object codInventario) {

            string filterInv = QH.CmpEq("idinventory", codInventario);
            string SQLfilterInv = QHS.CmpEq("idinventory", codInventario);
            string filter = filterInv;

            int flag = CfgFn.GetNoNullInt32(Meta.Conn.DO_READ_VALUE("inventory", SQLfilterInv, "flag"));
            bool flagMixed = ((flag & 1) == 1);

            if (flagMixed) {
                // Se il flag vale S, non devo filtrare i carichi sull'inventario ma solo sull'ente Inventariale
                object inventoryAgency = Meta.Conn.DO_READ_VALUE("inventory", SQLfilterInv, "idinventoryagency");
                string filterEnte = QHS.CmpEq("idinventoryagency", inventoryAgency);
                DataTable ListInvEnte = Meta.Conn.RUN_SELECT("inventory", "*", null, filterEnte, null, false);
                if (ListInvEnte.Rows.Count > 0) {
                    filter = QH.FieldIn("idinventory", ListInvEnte.Select());
                }
            }
            return filter;
        }



        private void Collega(string tipo) {
            if (MetaData.Empty(this)) return;
            if (cboTipo.SelectedIndex <= 0) {
                MessageBox.Show("E' necessario selezionare prima il tipo buono.");
                tabControl1.SelectedTab = tabBuono;
                cboTipo.Focus();
                return;
            }
            string filter = CalcolaFiltroDocCollegato(tipo, true);
            string command = "";
            switch (tipo.ToUpper()) {
                case "A":
                    command = "choose.assetamortizationunloadview.buonocarico";
                    break;
                case "B":
                    //carico bene
                    command = "choose.assetacquireview.default";
                    break;
                default:
                    return;
            }
            Meta.DoMainCommand(command + "." + filter);
        }

        private void Scollega(string tipo) {
            if (Meta.IsEmpty) return;
            DataGrid grid;
            switch (tipo.ToUpper()) {
                case "A":
                    grid = dgrAmmortamenti;
                    break;
                case "B":
                    grid = dgrCaricoBene;
                    break;
                default:
                    return;
            }
            MetaData.Unlink_Grid(grid);
        }

        private void Modifica(string tipo) {
            if (Meta.IsEmpty) return;
            string lblAdded;
            string lblToAdd;
            DataTable T;
            switch (tipo.ToUpper()) {
                case "A":
                    lblAdded = "Rivalutazioni incluse nel buono di carico";
                    lblToAdd = "Rivalutazioni non incluse nel buono di carico";
                    T = DS.assetamortizationunloadview;
                    break;
                case "B":
                    lblAdded = "Cespiti inclusi nel buono di carico";
                    lblToAdd = "Cespiti non inclusi nel buono di carico";
                    T = DS.assetacquireview;
                    break;
                default:
                    return;
            }
            string MyFilter = CalcolaFiltroDocCollegato(tipo, false);
            string MyFilterSQL = CalcolaFiltroDocCollegato(tipo, true);
            Meta.MultipleLinkUnlinkRows("Composizione buono di carico",
                lblAdded, lblToAdd, T, MyFilter, MyFilterSQL, "default");
        }

        private void btnCollegaAumento_Click(object sender, System.EventArgs e) {
            Collega("A");
        }

        private void btnScollegaAumento_Click(object sender, System.EventArgs e) {
            Scollega("A");
        }

        private void btnModificaAumento_Click(object sender, System.EventArgs e) {
            Modifica("A");
        }

        private void btnCollegaCaricoBene_Click(object sender, System.EventArgs e) {
            Collega("B");
        }

        private void btnScollegaCaricoBene_Click(object sender, System.EventArgs e) {
            Scollega("B");
        }

        private void btnModificaCaricoBene_Click(object sender, System.EventArgs e) {
            Modifica("B");
        }
        #region E/P


     

     
        #endregion
    

        private string GetMovimentoFilter() {
            object codicecreddeb = DS.assetload.Rows[0]["idreg"];
            int eserccorrente = (int)Meta.GetSys("esercizio");

            string MyFilter = QHS.CmpGe("ymov", CfgFn.GetNoNullInt32(txtEsercizioFin.Text.Trim()));
            if (txtNumeroFin.Text.Trim() != "")
                MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("nmov", CfgFn.GetNoNullInt32(txtNumeroFin.Text.Trim())));
            if (flagcreddeb) {
                MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("idreg", codicecreddeb));
            }

            if (DS.assetloadexpense.Rows.Count > 0) {
                MyFilter = QHS.AppAnd(MyFilter, QHS.FieldNotIn("idexp", DS.assetloadexpense.Select()));
            }
            return MyFilter;
        }

        private void btnCollegaMov_Click(object sender, System.EventArgs e) {
            if (Meta.IsEmpty) return;
            Mspesaview.FilterLocked = true;
            Mspesaview.DS = DS.Clone();
            DataRow R = Mspesaview.SelectOne("carico", GetMovimentoFilter(), "historypaymentview", null);
            if (R == null) return;
            ImpostaDataRatifica(R);
            MetaData M = MetaData.GetMetaData(this, "assetloadexpense");
            ImpostaValoriDaSpesa(DS.assetloadexpense, R);
            M.SetDefaults(DS.assetloadexpense);
            M.Get_New_Row(DS.assetload.Rows[0], DS.assetloadexpense);
            txtNumeroFin.Text = "";

        }

        private void ImpostaValoriDaSpesa(DataTable T, DataRow R) {
            MetaData.SetDefault(T, "idexp", R["idexp"]);
            MetaData.SetDefault(T, "!ymov", R["ymov"]);
            MetaData.SetDefault(T, "!nmov", R["nmov"]);
            MetaData.SetDefault(T, "!expensedescription", R["description"]);
            MetaData.SetDefault(T, "!expensedoc", R["doc"]);
            MetaData.SetDefault(T, "!amount", R["amount"]);
            MetaData.SetDefault(T, "!npay", R["npay"]);
        }

        private void ImpostaDataRatifica(DataRow R) {
            // Calcola la data di competenza per il pagamento selezionato
            Meta.GetFormData(true);
            object compDate = R["competencydate"];
            if (compDate == DBNull.Value) return;
            string tag = HelpForm.GetStandardTag(txtRatifica.Tag);
            var currLoad = DS.assetload.First();
            if (!currLoad.ratificationdate.HasValue) {
                currLoad.ratificationdate = (DateTime)compDate;
                txtRatifica.Text = HelpForm.StringValue(compDate, tag);
            }
            else {
                if (!currLoad.ratificationdate.Equals(compDate)) {
                    if (MessageBox.Show("Sostituire la data ratifica con la data di competenza " + HelpForm.StringValue(compDate, tag) +
                                        " del movimento selezionato?",
                    "Avviso", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                        currLoad.ratificationdate = (DateTime)compDate;
                        txtRatifica.Text = HelpForm.StringValue(compDate, tag);
                    }
                }
            }
            Meta.FreshForm();
        }


        private void txtRatifica_Leave(object sender, System.EventArgs e) {
            if (inChiusura) return;
            ParseDate(txtRatifica);
        }

        private void txtEsercizioFin_Leave(object sender, System.EventArgs e) {
            if (inChiusura) return;
            HelpForm.ExtLeaveIntTextBox(txtEsercizioFin, "x.x.year");
        }

        //private void btnCreaCaricoBene_Click(object sender, System.EventArgs e) {
        //    var cmm = Meta.CMM;
        //    if (cmm == null) return;
        //    cmm.addContextMenuToForm(Meta,this);
        //    cmm.UpdateMenu();
        //    ContextMenu CM = cmm.CM;
        //    if (CM == null) return;
        //    foreach (MenuItem M in CM.MenuItems) {
        //        if (M.MenuItems != null) {
        //            foreach (MenuItem MM in M.MenuItems) {
        //                myMenuItem MyM = MM as myMenuItem;
        //                if (MyM == null) continue;
        //                if (!MyM.Insert) continue;
        //                DataRow R = MyM.Relation;
        //                if (R == null) continue;
        //                if (R.Table.TableName != "customdirectrel") continue;
        //                string ToTable = R["totable"].ToString();
        //                if (ToTable != "assetacquire") continue;
        //                MM.PerformClick();
        //            }
        //        }
        //    }
        //}

        private void btnWizardAmortization_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            var RTipoBuono = DS.assetloadkind.f_Eq("idassetloadkind", cboTipo.SelectedValue)._First();
            object OldIdinventory = RTipoBuono?.idinventory;

            FrmWizardAmortization F = new FrmWizardAmortization(Meta, OldIdinventory);
            DialogResult RES = F.ShowDialog(this);
            if (RES != DialogResult.OK) return;
            Meta.GetFormData(true);
            DataTable T = F.AssetAmortization;  //(assetpieceview)
            if (T.Rows.Count > 0) {

                object PrimoIdInv = T.Rows[0]["idinventory"];
                //object NewIdInv;
                //int i;
                //for (i = 1; i < T.Rows.Count; i++)
                //{
                //    NewIdInv = T.Rows[i]["idinventory"];
                //    if (!PrimoIdInv.Equals(NewIdInv))
                //    {
                //        MessageBox.Show("Attenzione! I cespiti selezionati appartengono a diversi tipi di inventario");
                //        return;
                //    }
                //}
                var Curr = DS.assetload.First();

                if ((Meta.InsertMode) && (CfgFn.GetNoNullInt32(Curr.idassetloadkind) == 0)) {
                    DS.assetloadkind._IfExists(q.eq("idinventory", PrimoIdInv),
                        found => {
                            Curr.idassetloadkind = found.idassetloadkind;
                            cboTipo.SelectedValue = found.idassetloadkind;
                        }
                     );

                    //var NewRTipoBuono = DS.assetloadkind.f_Eq("idinventory", PrimoIdInv)._First();
                    //if (NewRTipoBuono != null) {
                    //    Curr.idassetloadkind = NewRTipoBuono.idassetloadkind;
                    //    cboTipo.SelectedValue = NewRTipoBuono.idassetloadkind;
                    //}

                }

                foreach (DataRow R in T.Rows) { //Righe selezionate attraverso il wizard	
                    //string keyfilter = QueryCreator.WHERE_COLNAME_CLAUSE(R,
                    // new string[] { "namortization" }, DataRowVersion.Default, false);
                    // Verifica se già presente nel DataSet del form chiamante
                    //DataRow[] Found = DS.assetamortizationunloadview.Select(keyfilter);
                    DS.assetamortizationunloadview._IfExists(q.eqObj("namortization", R),
                        _then: f => f["idassetload"] = Curr.idassetload,
                        _else: () => {
                            //DataRow NewR = DS.assetamortizationunloadview.NewRow();
                            //foreach (DataColumn C in R.Table.Columns) {
                            //    NewR[C.ColumnName] = R[C.ColumnName];
                            //}
                            var NewR = DS.assetamortizationunloadview.NewRowAs(R);

                            DS.assetamortizationunloadview.Rows.Add(NewR);
                            NewR.AcceptChanges();
                            NewR["idassetload"] = Curr["idassetload"];
                        }
                        );

                    //var found= DS.assetamortizationunloadview.f_EqObj("namortization", R)._First();
                    //if (found != null) {
                    //    found["idassetload"] = Curr.idassetload;
                    //}
                    //else {
                    //    DataRow NewR = DS.assetamortizationunloadview.NewRow();
                    //    foreach (DataColumn C in R.Table.Columns) {
                    //        NewR[C.ColumnName] = R[C.ColumnName];
                    //    }
                    //    DS.assetamortizationunloadview.Rows.Add(NewR);
                    //    NewR.AcceptChanges();
                    //    NewR["idassetload"] = Curr["idassetload"];
                    //}


                }
                Meta.MarkTableAsNotEntityChild(DS.assetamortizationunloadview);
                Meta.FreshForm();
            }


        }

        private void btnCollegaAmmortamento_Click(object sender, EventArgs e) {
            Collega("A");
        }

        private void btnScollegaAmmortamento_Click(object sender, EventArgs e) {
            Scollega("A");
        }

        private void btnModificaAmmortamento_Click(object sender, EventArgs e) {
            Modifica("A");
        }

        public void MetaData_BeforeFill() {
            GetData.DenyClear(DS.assetacquireview);
        }
        private void btnAggiungidaFattura_Click(object sender, EventArgs e) {
            if (MetaData.Empty(this)) return;
            Meta.GetFormData(true);

            var curr = DS.assetload.First();

            if (cboTipo.SelectedIndex <= 0) {
                MessageBox.Show("E' necessario selezionare prima il tipo buono.");
                tabControl1.SelectedTab = tabBuono;
                cboTipo.Focus();
                return;
            }
            //DataRow[] RTipoBuono = DS.assetloadkind.Select(QHC.CmpEq("idassetloadkind", cboTipo.SelectedValue));
            //if (RTipoBuono.Length > 0) {
            //    OldIdinventory = RTipoBuono[0]["idinventory"];
            //}
            //else {
            //    OldIdinventory = null;
            //}
            object OldIdinventory = DS.assetloadkind.f_Eq("idassetloadkind", cboTipo.SelectedValue)._First()?.idinventory;

            FrmAskDescr FR = new FrmAskDescr(Meta.Dispatcher, OldIdinventory);
            DialogResult D = FR.ShowDialog(this);
            if (D != DialogResult.OK) return;
            //if (FR.Selected != null) {
            //    string filter = QHS.AppAnd(QHC.CmpEq("idinvkind", FR.Selected["idinvkind"]),
            //        QHC.CmpEq("yinv", FR.Selected["yinv"]), QHC.CmpEq("ninv", FR.Selected["ninv"]), QHC.IsNull("idassetload"));
            //    DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.assetacquireview, null, filter, null, true);
            //    DataRow Curr = DS.assetload.First();
            //    foreach (DataRow R in DS.assetacquireview.Select(filter)) {
            //        R["idassetload"] = Curr["idassetload"];
            //    }
            //    Meta.MainRefresh();
            //}

            if (FR.Selected != null) {
                var Curr = DS.assetload.First();
                var lista =
                DS.assetacquireview
                        .getFromDb(Meta.Conn,
                                    q.mCmp(FR.Selected, "idinvkind", "yinv", "ninv") & q.isNull("idassetload")
                                      & getInvFilter(OldIdinventory)
                                      & (flagcausale ? q.eq("idmot", curr.idmotValue) : q.constant(true))
                                    );
                if (lista.Length == 0) {
                    MessageBox.Show("Non è stata trovato alcun carico associato alla fattura indicata coerente con " +
                        "il tipo buono carico e con la causale di carico selezionati", "Avviso");
                }
                else {
                    lista._forEach(r => r["idassetload"] = Curr.idassetload);
                }

                Meta.FreshForm();
            }

        }
    }
}
