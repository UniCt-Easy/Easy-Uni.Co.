
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
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;//funzioni_configurazione
using ep_functions;

namespace estimatedetail_single {
    /// <summary>
    /// </summary>
    public class Frm_estimatedetail_single : System.Windows.Forms.Form {
        private System.Windows.Forms.TextBox txtDescrizione;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIvaEUR;
        private System.Windows.Forms.TextBox txtImponibileEUR;
        private System.Windows.Forms.TextBox txtAppunti;
        public string codicevaluta;
        public double tassocambio;
        private double aliquota = 0;
        public object codiceresponsabile;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtResiduo;
        private System.Windows.Forms.GroupBox gboxIVA;
        private System.Windows.Forms.GroupBox gboxImponibile;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnRemoveIva;
        private System.Windows.Forms.Button btnRemoveImponibile;
        private System.Windows.Forms.TextBox txtNumeroIva;
        private System.Windows.Forms.TextBox txtEsercizioIva;
        private System.Windows.Forms.TextBox txtNumImponibile;
        private System.Windows.Forms.TextBox txtEsercizioImponibile;
        private System.Windows.Forms.Button btnUPBCode;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabFinanziario;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnCodice;
        private System.Windows.Forms.TabPage tabFatturazione;
        public System.Windows.Forms.GroupBox gboxclass1;
        private System.Windows.Forms.TextBox txtDenom1;
        public TextBox txtCodice1;
        public System.Windows.Forms.Button btnCodice1;
        public System.Windows.Forms.GroupBox gboxclass2;
        public System.Windows.Forms.Button btnCodice2;
        private System.Windows.Forms.TextBox txtDenom2;
        public TextBox txtCodice2;
        private System.Windows.Forms.TabPage tabAnalitico;
        public System.Windows.Forms.GroupBox gboxclass3;
        public System.Windows.Forms.Button btnCodice3;
        private System.Windows.Forms.TextBox txtDenom3;
        public TextBox txtCodice3;
        private System.Windows.Forms.TextBox txtNInvoiced;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox TxtIvaValutaTot;
        private System.Windows.Forms.TextBox TxtImponibileValutaTot;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnTipo;
        private System.Windows.Forms.ComboBox cmbTipoIVA;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtTaxRate;
        public estimatedetail_single.dsmeta DS;
        private System.Windows.Forms.GroupBox grpRegistry;
        private System.Windows.Forms.TextBox txtCredDeb;
        private System.Windows.Forms.TextBox txtstart;
        private System.Windows.Forms.TextBox txtstop;
        private TabPage tabEP;
        private GroupBox grpCausaleAnnullamento;
        private TextBox textBox2;
        private TextBox txtCodiceCausaleAnnullamento;
        private Button btnCausaleEPAnnullamento;
        private GroupBox gboxCompetenza;
        private TextBox textBox4;
        private TextBox textBox3;
        private Label label15;
        private Label label14;
        private GroupBox grpCausale;
        private TextBox txtDescrizioneCausale;
        private TextBox txtCodiceCausale;
        private Button btnCausaleEP;
        private TabPage tabAppunti;
        private TabPage tabMain;
        private TextBox txtQuantita;
        private Label label1;
        private GroupBox grpValoreUnitInValuta;
        private TextBox txtSconto;
        private TextBox txtImponibile;
        private Label label16;
        private Label label18;
        private GroupBox gboxUPB;
        public TextBox txtUPB;
        private Button btnUPB;
        private TextBox txtDescrUPB;
        private RadioButton rdEPKind_N;
        private RadioButton rdEPKind_F;
        private RadioButton rdEPKind_R;
        public GroupBox grpRipartizioneRicavi;
        public Button button3;
        public TextBox textBox1;
        public TextBox txtCodiceRipartizione;
        private GroupBox gBoxupbIVA;
        public TextBox txtUPBiva;
        private Label label17;
        private Button buttonupbIVA;
        private TextBox textBox6;
        private GroupBox gboxListino;
        private CheckBox chkListDescription;
        private Button btnListino;
        private TextBox txtListino;
        private TextBox txtDescrizioneListino;
        private GroupBox grpBoxImpegniBudget;
        private Label label34;
        private Label label33;
        private TextBox txtNumIxBudget;
        private TextBox txtEsercIxBudget;
        private Label lblcig;
        private TextBox txtcig;
        private GroupBox gboxCausale;
        private TextBox TxtDescrCausaleDeb;
        private TextBox txtCodiceCausaleEntrata;
        private Button button6;
        private CheckBox chkScrittureDifferite;
        private TabPage tabPage1;
        private TextBox textBox8;
        private TextBox textBox7;
        private Label label26;
        private TextBox txtBollettino;
        private Label label23;
        private TextBox txtScadenza;
        private Label label22;
        private TextBox textBox5;
        private TextBox textBox9;
        private GroupBox grpBoxSiopeEP;
        private Button btnSiope;
        private TextBox txtDescSiope;
        private TextBox txtCodSiope;
        private GroupBox groupBox3;
        private Button btnScollegaPreaccertamento;
        private Button btnCollegaPreaccertamento;
        private Label label24;
        private Label label25;
        private TextBox txtNumPreimpegno;
        private TextBox txtEsercPreImpegno;
        MetaData Meta;

        public Frm_estimatedetail_single() {
            InitializeComponent();


        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing) {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_estimatedetail_single));
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtIvaEUR = new System.Windows.Forms.TextBox();
            this.txtImponibileEUR = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAppunti = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtstart = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtstop = new System.Windows.Forms.TextBox();
            this.gboxIVA = new System.Windows.Forms.GroupBox();
            this.btnRemoveIva = new System.Windows.Forms.Button();
            this.txtNumeroIva = new System.Windows.Forms.TextBox();
            this.txtEsercizioIva = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNInvoiced = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtResiduo = new System.Windows.Forms.TextBox();
            this.gboxImponibile = new System.Windows.Forms.GroupBox();
            this.btnRemoveImponibile = new System.Windows.Forms.Button();
            this.txtNumImponibile = new System.Windows.Forms.TextBox();
            this.txtEsercizioImponibile = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.DS = new estimatedetail_single.dsmeta();
            this.btnUPBCode = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.gboxListino = new System.Windows.Forms.GroupBox();
            this.chkListDescription = new System.Windows.Forms.CheckBox();
            this.btnListino = new System.Windows.Forms.Button();
            this.txtListino = new System.Windows.Forms.TextBox();
            this.txtDescrizioneListino = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.TxtIvaValutaTot = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.TxtImponibileValutaTot = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnTipo = new System.Windows.Forms.Button();
            this.cmbTipoIVA = new System.Windows.Forms.ComboBox();
            this.txtTaxRate = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.grpRegistry = new System.Windows.Forms.GroupBox();
            this.txtCredDeb = new System.Windows.Forms.TextBox();
            this.txtQuantita = new System.Windows.Forms.TextBox();
            this.grpValoreUnitInValuta = new System.Windows.Forms.GroupBox();
            this.txtSconto = new System.Windows.Forms.TextBox();
            this.txtImponibile = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabFinanziario = new System.Windows.Forms.TabPage();
            this.gboxCausale = new System.Windows.Forms.GroupBox();
            this.TxtDescrCausaleDeb = new System.Windows.Forms.TextBox();
            this.txtCodiceCausaleEntrata = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.lblcig = new System.Windows.Forms.Label();
            this.txtcig = new System.Windows.Forms.TextBox();
            this.gBoxupbIVA = new System.Windows.Forms.GroupBox();
            this.txtUPBiva = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.buttonupbIVA = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.gboxUPB = new System.Windows.Forms.GroupBox();
            this.txtUPB = new System.Windows.Forms.TextBox();
            this.btnUPB = new System.Windows.Forms.Button();
            this.txtDescrUPB = new System.Windows.Forms.TextBox();
            this.tabAnalitico = new System.Windows.Forms.TabPage();
            this.grpRipartizioneRicavi = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtCodiceRipartizione = new System.Windows.Forms.TextBox();
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
            this.tabFatturazione = new System.Windows.Forms.TabPage();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.tabEP = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnScollegaPreaccertamento = new System.Windows.Forms.Button();
            this.btnCollegaPreaccertamento = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.txtNumPreimpegno = new System.Windows.Forms.TextBox();
            this.txtEsercPreImpegno = new System.Windows.Forms.TextBox();
            this.grpBoxSiopeEP = new System.Windows.Forms.GroupBox();
            this.btnSiope = new System.Windows.Forms.Button();
            this.txtDescSiope = new System.Windows.Forms.TextBox();
            this.txtCodSiope = new System.Windows.Forms.TextBox();
            this.chkScrittureDifferite = new System.Windows.Forms.CheckBox();
            this.grpBoxImpegniBudget = new System.Windows.Forms.GroupBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.txtNumIxBudget = new System.Windows.Forms.TextBox();
            this.txtEsercIxBudget = new System.Windows.Forms.TextBox();
            this.grpCausaleAnnullamento = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtCodiceCausaleAnnullamento = new System.Windows.Forms.TextBox();
            this.btnCausaleEPAnnullamento = new System.Windows.Forms.Button();
            this.gboxCompetenza = new System.Windows.Forms.GroupBox();
            this.rdEPKind_N = new System.Windows.Forms.RadioButton();
            this.rdEPKind_F = new System.Windows.Forms.RadioButton();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.rdEPKind_R = new System.Windows.Forms.RadioButton();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.grpCausale = new System.Windows.Forms.GroupBox();
            this.txtDescrizioneCausale = new System.Windows.Forms.TextBox();
            this.txtCodiceCausale = new System.Windows.Forms.TextBox();
            this.btnCausaleEP = new System.Windows.Forms.Button();
            this.tabAppunti = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.txtBollettino = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtScadenza = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.btnCodice = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.gboxIVA.SuspendLayout();
            this.gboxImponibile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.gboxListino.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.grpRegistry.SuspendLayout();
            this.grpValoreUnitInValuta.SuspendLayout();
            this.tabFinanziario.SuspendLayout();
            this.gboxCausale.SuspendLayout();
            this.gBoxupbIVA.SuspendLayout();
            this.gboxUPB.SuspendLayout();
            this.tabAnalitico.SuspendLayout();
            this.grpRipartizioneRicavi.SuspendLayout();
            this.gboxclass3.SuspendLayout();
            this.gboxclass2.SuspendLayout();
            this.gboxclass1.SuspendLayout();
            this.tabFatturazione.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.tabEP.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.grpBoxSiopeEP.SuspendLayout();
            this.grpBoxImpegniBudget.SuspendLayout();
            this.grpCausaleAnnullamento.SuspendLayout();
            this.gboxCompetenza.SuspendLayout();
            this.grpCausale.SuspendLayout();
            this.tabAppunti.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizione.Location = new System.Drawing.Point(17, 68);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(499, 40);
            this.txtDescrizione.TabIndex = 2;
            this.txtDescrizione.Tag = "estimatedetail.detaildescription";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(14, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Descrizione:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(704, 541);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.TabStop = false;
            this.btnOK.Tag = "mainsave";
            this.btnOK.Text = "OK";
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(785, 541);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 3;
            this.btnAnnulla.TabStop = false;
            this.btnAnnulla.Text = "Annulla";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtIvaEUR);
            this.groupBox2.Controls.Add(this.txtImponibileEUR);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(322, 258);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(280, 56);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Valore totale in EUR";
            // 
            // txtIvaEUR
            // 
            this.txtIvaEUR.Location = new System.Drawing.Point(128, 32);
            this.txtIvaEUR.Name = "txtIvaEUR";
            this.txtIvaEUR.ReadOnly = true;
            this.txtIvaEUR.Size = new System.Drawing.Size(72, 20);
            this.txtIvaEUR.TabIndex = 38;
            this.txtIvaEUR.TabStop = false;
            this.txtIvaEUR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtImponibileEUR
            // 
            this.txtImponibileEUR.Location = new System.Drawing.Point(8, 32);
            this.txtImponibileEUR.Name = "txtImponibileEUR";
            this.txtImponibileEUR.ReadOnly = true;
            this.txtImponibileEUR.Size = new System.Drawing.Size(88, 20);
            this.txtImponibileEUR.TabIndex = 37;
            this.txtImponibileEUR.TabStop = false;
            this.txtImponibileEUR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(128, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 35;
            this.label3.Text = "IVA:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 34;
            this.label4.Text = "Imponibile:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAppunti
            // 
            this.txtAppunti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAppunti.Location = new System.Drawing.Point(0, 0);
            this.txtAppunti.Multiline = true;
            this.txtAppunti.Name = "txtAppunti";
            this.txtAppunti.Size = new System.Drawing.Size(849, 506);
            this.txtAppunti.TabIndex = 19;
            this.txtAppunti.Tag = "estimatedetail.annotations";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(11, 237);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(504, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "Data contabile (da inserire se questo dettaglio non era presente nel Contratto or" +
    "iginale)";
            // 
            // txtstart
            // 
            this.txtstart.Location = new System.Drawing.Point(11, 254);
            this.txtstart.Name = "txtstart";
            this.txtstart.Size = new System.Drawing.Size(104, 20);
            this.txtstart.TabIndex = 4;
            this.txtstart.Tag = "estimatedetail.start";
            this.txtstart.Leave += new System.EventHandler(this.txtstart_Leave);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(10, 279);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(433, 16);
            this.label5.TabIndex = 19;
            this.label5.Text = "Data annullamento (inserire se il dettaglio è  annullato o sostituito da un altro" +
    " dettaglio)";
            // 
            // txtstop
            // 
            this.txtstop.Location = new System.Drawing.Point(11, 296);
            this.txtstop.Name = "txtstop";
            this.txtstop.Size = new System.Drawing.Size(104, 20);
            this.txtstop.TabIndex = 5;
            this.txtstop.Tag = "estimatedetail.stop";
            this.txtstop.Leave += new System.EventHandler(this.txtstop_Leave);
            // 
            // gboxIVA
            // 
            this.gboxIVA.Controls.Add(this.btnRemoveIva);
            this.gboxIVA.Controls.Add(this.txtNumeroIva);
            this.gboxIVA.Controls.Add(this.txtEsercizioIva);
            this.gboxIVA.Controls.Add(this.label8);
            this.gboxIVA.Controls.Add(this.label7);
            this.gboxIVA.Location = new System.Drawing.Point(275, 134);
            this.gboxIVA.Name = "gboxIVA";
            this.gboxIVA.Size = new System.Drawing.Size(256, 56);
            this.gboxIVA.TabIndex = 3;
            this.gboxIVA.TabStop = false;
            this.gboxIVA.Text = "Contabilizzazione IVA in finanziario";
            // 
            // btnRemoveIva
            // 
            this.btnRemoveIva.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveIva.Location = new System.Drawing.Point(136, 28);
            this.btnRemoveIva.Name = "btnRemoveIva";
            this.btnRemoveIva.Size = new System.Drawing.Size(112, 24);
            this.btnRemoveIva.TabIndex = 4;
            this.btnRemoveIva.TabStop = false;
            this.btnRemoveIva.Text = "Decontabilizza";
            this.btnRemoveIva.Click += new System.EventHandler(this.btnRemoveIva_Click);
            // 
            // txtNumeroIva
            // 
            this.txtNumeroIva.Location = new System.Drawing.Point(64, 32);
            this.txtNumeroIva.Name = "txtNumeroIva";
            this.txtNumeroIva.ReadOnly = true;
            this.txtNumeroIva.Size = new System.Drawing.Size(64, 20);
            this.txtNumeroIva.TabIndex = 3;
            this.txtNumeroIva.TabStop = false;
            this.txtNumeroIva.Tag = "income_iva.nmov";
            // 
            // txtEsercizioIva
            // 
            this.txtEsercizioIva.Location = new System.Drawing.Point(8, 32);
            this.txtEsercizioIva.Name = "txtEsercizioIva";
            this.txtEsercizioIva.ReadOnly = true;
            this.txtEsercizioIva.Size = new System.Drawing.Size(40, 20);
            this.txtEsercizioIva.TabIndex = 2;
            this.txtEsercizioIva.TabStop = false;
            this.txtEsercizioIva.Tag = "income_iva.ymov";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(64, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 16);
            this.label8.TabIndex = 1;
            this.label8.Text = "Numero";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(8, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "Eserc.";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(8, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(152, 23);
            this.label9.TabIndex = 21;
            this.label9.Text = "Quantità inserita in fatture:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNInvoiced
            // 
            this.txtNInvoiced.Location = new System.Drawing.Point(152, 8);
            this.txtNInvoiced.Name = "txtNInvoiced";
            this.txtNInvoiced.ReadOnly = true;
            this.txtNInvoiced.Size = new System.Drawing.Size(100, 20);
            this.txtNInvoiced.TabIndex = 22;
            this.txtNInvoiced.Tag = "";
            this.txtNInvoiced.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(309, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(120, 23);
            this.label10.TabIndex = 23;
            this.label10.Text = "non inserita in fatture:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtResiduo
            // 
            this.txtResiduo.Location = new System.Drawing.Point(437, 8);
            this.txtResiduo.Name = "txtResiduo";
            this.txtResiduo.ReadOnly = true;
            this.txtResiduo.Size = new System.Drawing.Size(100, 20);
            this.txtResiduo.TabIndex = 24;
            this.txtResiduo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gboxImponibile
            // 
            this.gboxImponibile.Controls.Add(this.btnRemoveImponibile);
            this.gboxImponibile.Controls.Add(this.txtNumImponibile);
            this.gboxImponibile.Controls.Add(this.txtEsercizioImponibile);
            this.gboxImponibile.Controls.Add(this.label11);
            this.gboxImponibile.Controls.Add(this.label12);
            this.gboxImponibile.Location = new System.Drawing.Point(11, 134);
            this.gboxImponibile.Name = "gboxImponibile";
            this.gboxImponibile.Size = new System.Drawing.Size(256, 56);
            this.gboxImponibile.TabIndex = 2;
            this.gboxImponibile.TabStop = false;
            this.gboxImponibile.Text = "Contabilizzazione imponibile in finanziario";
            // 
            // btnRemoveImponibile
            // 
            this.btnRemoveImponibile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveImponibile.Location = new System.Drawing.Point(136, 24);
            this.btnRemoveImponibile.Name = "btnRemoveImponibile";
            this.btnRemoveImponibile.Size = new System.Drawing.Size(112, 23);
            this.btnRemoveImponibile.TabIndex = 4;
            this.btnRemoveImponibile.TabStop = false;
            this.btnRemoveImponibile.Text = "Decontabilizza";
            this.btnRemoveImponibile.Click += new System.EventHandler(this.btnRemoveImponibile_Click);
            // 
            // txtNumImponibile
            // 
            this.txtNumImponibile.Location = new System.Drawing.Point(64, 32);
            this.txtNumImponibile.Name = "txtNumImponibile";
            this.txtNumImponibile.ReadOnly = true;
            this.txtNumImponibile.Size = new System.Drawing.Size(64, 20);
            this.txtNumImponibile.TabIndex = 3;
            this.txtNumImponibile.TabStop = false;
            this.txtNumImponibile.Tag = "income_imponibile.nmov";
            // 
            // txtEsercizioImponibile
            // 
            this.txtEsercizioImponibile.Location = new System.Drawing.Point(8, 32);
            this.txtEsercizioImponibile.Name = "txtEsercizioImponibile";
            this.txtEsercizioImponibile.ReadOnly = true;
            this.txtEsercizioImponibile.Size = new System.Drawing.Size(40, 20);
            this.txtEsercizioImponibile.TabIndex = 2;
            this.txtEsercizioImponibile.TabStop = false;
            this.txtEsercizioImponibile.Tag = "income_imponibile.ymov";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(64, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 16);
            this.label11.TabIndex = 1;
            this.label11.Text = "Numero";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(8, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 16);
            this.label12.TabIndex = 0;
            this.label12.Text = "Eserc.";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // btnUPBCode
            // 
            this.btnUPBCode.Location = new System.Drawing.Point(0, 0);
            this.btnUPBCode.Name = "btnUPBCode";
            this.btnUPBCode.Size = new System.Drawing.Size(75, 23);
            this.btnUPBCode.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabMain);
            this.tabControl1.Controls.Add(this.tabFinanziario);
            this.tabControl1.Controls.Add(this.tabAnalitico);
            this.tabControl1.Controls.Add(this.tabFatturazione);
            this.tabControl1.Controls.Add(this.tabEP);
            this.tabControl1.Controls.Add(this.tabAppunti);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(8, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(857, 532);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.TabStop = false;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.gboxListino);
            this.tabMain.Controls.Add(this.groupBox1);
            this.tabMain.Controls.Add(this.txtDescrizione);
            this.tabMain.Controls.Add(this.groupBox6);
            this.tabMain.Controls.Add(this.grpRegistry);
            this.tabMain.Controls.Add(this.txtQuantita);
            this.tabMain.Controls.Add(this.label6);
            this.tabMain.Controls.Add(this.grpValoreUnitInValuta);
            this.tabMain.Controls.Add(this.groupBox2);
            this.tabMain.Controls.Add(this.label1);
            this.tabMain.Location = new System.Drawing.Point(4, 22);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMain.Size = new System.Drawing.Size(849, 506);
            this.tabMain.TabIndex = 6;
            this.tabMain.Text = "Principale";
            this.tabMain.UseVisualStyleBackColor = true;
            this.tabMain.Click += new System.EventHandler(this.tabMain_Click);
            // 
            // gboxListino
            // 
            this.gboxListino.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxListino.Controls.Add(this.chkListDescription);
            this.gboxListino.Controls.Add(this.btnListino);
            this.gboxListino.Controls.Add(this.txtListino);
            this.gboxListino.Controls.Add(this.txtDescrizioneListino);
            this.gboxListino.Location = new System.Drawing.Point(538, 68);
            this.gboxListino.Name = "gboxListino";
            this.gboxListino.Size = new System.Drawing.Size(301, 117);
            this.gboxListino.TabIndex = 4;
            this.gboxListino.TabStop = false;
            this.gboxListino.Tag = "";
            // 
            // chkListDescription
            // 
            this.chkListDescription.Location = new System.Drawing.Point(11, 11);
            this.chkListDescription.Name = "chkListDescription";
            this.chkListDescription.Size = new System.Drawing.Size(277, 20);
            this.chkListDescription.TabIndex = 4;
            this.chkListDescription.TabStop = false;
            this.chkListDescription.Text = "Fitra per Descrizione/Class.Merceologica";
            // 
            // btnListino
            // 
            this.btnListino.BackColor = System.Drawing.SystemColors.Control;
            this.btnListino.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListino.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnListino.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListino.ImageIndex = 0;
            this.btnListino.Location = new System.Drawing.Point(6, 59);
            this.btnListino.Name = "btnListino";
            this.btnListino.Size = new System.Drawing.Size(57, 23);
            this.btnListino.TabIndex = 1;
            this.btnListino.TabStop = false;
            this.btnListino.Tag = "";
            this.btnListino.Text = "Listino";
            this.btnListino.UseVisualStyleBackColor = false;
            this.btnListino.Click += new System.EventHandler(this.btnListino_Click);
            // 
            // txtListino
            // 
            this.txtListino.Location = new System.Drawing.Point(6, 88);
            this.txtListino.Name = "txtListino";
            this.txtListino.Size = new System.Drawing.Size(289, 20);
            this.txtListino.TabIndex = 6;
            this.txtListino.Tag = "";
            this.txtListino.TextChanged += new System.EventHandler(this.txtListino_TextChanged);
            this.txtListino.Enter += new System.EventHandler(this.txtListino_Enter);
            this.txtListino.Leave += new System.EventHandler(this.txtListino_Leave);
            // 
            // txtDescrizioneListino
            // 
            this.txtDescrizioneListino.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizioneListino.Location = new System.Drawing.Point(76, 31);
            this.txtDescrizioneListino.Multiline = true;
            this.txtDescrizioneListino.Name = "txtDescrizioneListino";
            this.txtDescrizioneListino.ReadOnly = true;
            this.txtDescrizioneListino.Size = new System.Drawing.Size(219, 51);
            this.txtDescrizioneListino.TabIndex = 9;
            this.txtDescrizioneListino.TabStop = false;
            this.txtDescrizioneListino.Tag = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.TxtIvaValutaTot);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.TxtImponibileValutaTot);
            this.groupBox1.Location = new System.Drawing.Point(322, 196);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 56);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Valore totale in valuta";
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(128, 16);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(64, 16);
            this.label20.TabIndex = 3;
            this.label20.Text = "IVA";
            // 
            // TxtIvaValutaTot
            // 
            this.TxtIvaValutaTot.Location = new System.Drawing.Point(128, 32);
            this.TxtIvaValutaTot.Name = "TxtIvaValutaTot";
            this.TxtIvaValutaTot.Size = new System.Drawing.Size(72, 20);
            this.TxtIvaValutaTot.TabIndex = 8;
            this.TxtIvaValutaTot.Tag = "estimatedetail.tax.fixed.2...1";
            this.TxtIvaValutaTot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtIvaValutaTot.TextChanged += new System.EventHandler(this.TxtIvaValutaTot_TextChanged);
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(8, 16);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(56, 16);
            this.label19.TabIndex = 1;
            this.label19.Text = "Imponibile";
            // 
            // TxtImponibileValutaTot
            // 
            this.TxtImponibileValutaTot.Location = new System.Drawing.Point(8, 32);
            this.TxtImponibileValutaTot.Name = "TxtImponibileValutaTot";
            this.TxtImponibileValutaTot.ReadOnly = true;
            this.TxtImponibileValutaTot.Size = new System.Drawing.Size(88, 20);
            this.TxtImponibileValutaTot.TabIndex = 0;
            this.TxtImponibileValutaTot.TabStop = false;
            this.TxtImponibileValutaTot.Tag = "";
            this.TxtImponibileValutaTot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.btnTipo);
            this.groupBox6.Controls.Add(this.cmbTipoIVA);
            this.groupBox6.Controls.Add(this.txtTaxRate);
            this.groupBox6.Controls.Add(this.label21);
            this.groupBox6.Location = new System.Drawing.Point(9, 114);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(506, 71);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            // 
            // btnTipo
            // 
            this.btnTipo.Location = new System.Drawing.Point(8, 14);
            this.btnTipo.Name = "btnTipo";
            this.btnTipo.Size = new System.Drawing.Size(64, 23);
            this.btnTipo.TabIndex = 7;
            this.btnTipo.TabStop = false;
            this.btnTipo.Tag = "choose.ivakind.default";
            this.btnTipo.Text = "Tipo IVA";
            // 
            // cmbTipoIVA
            // 
            this.cmbTipoIVA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTipoIVA.DataSource = this.DS.ivakind;
            this.cmbTipoIVA.DisplayMember = "description";
            this.cmbTipoIVA.Location = new System.Drawing.Point(6, 43);
            this.cmbTipoIVA.Name = "cmbTipoIVA";
            this.cmbTipoIVA.Size = new System.Drawing.Size(404, 21);
            this.cmbTipoIVA.TabIndex = 2;
            this.cmbTipoIVA.Tag = "estimatedetail.idivakind";
            this.cmbTipoIVA.ValueMember = "idivakind";
            // 
            // txtTaxRate
            // 
            this.txtTaxRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTaxRate.Location = new System.Drawing.Point(428, 43);
            this.txtTaxRate.Name = "txtTaxRate";
            this.txtTaxRate.ReadOnly = true;
            this.txtTaxRate.Size = new System.Drawing.Size(72, 20);
            this.txtTaxRate.TabIndex = 2;
            this.txtTaxRate.TabStop = false;
            this.txtTaxRate.Tag = "estimatedetail.taxrate.fixed.4..%.100";
            this.txtTaxRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label21.Location = new System.Drawing.Point(428, 21);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(72, 16);
            this.label21.TabIndex = 35;
            this.label21.Text = "Aliquota";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpRegistry
            // 
            this.grpRegistry.Controls.Add(this.txtCredDeb);
            this.grpRegistry.Location = new System.Drawing.Point(9, 6);
            this.grpRegistry.Name = "grpRegistry";
            this.grpRegistry.Size = new System.Drawing.Size(392, 40);
            this.grpRegistry.TabIndex = 1;
            this.grpRegistry.TabStop = false;
            this.grpRegistry.Tag = "AutoChoose.txtCredDeb.default.(active=\'S\')";
            this.grpRegistry.Text = "Cliente";
            // 
            // txtCredDeb
            // 
            this.txtCredDeb.Location = new System.Drawing.Point(8, 16);
            this.txtCredDeb.Name = "txtCredDeb";
            this.txtCredDeb.Size = new System.Drawing.Size(376, 20);
            this.txtCredDeb.TabIndex = 0;
            this.txtCredDeb.Tag = "registrymainview.title?estimatedetailview.registry";
            // 
            // txtQuantita
            // 
            this.txtQuantita.Location = new System.Drawing.Point(14, 230);
            this.txtQuantita.Name = "txtQuantita";
            this.txtQuantita.Size = new System.Drawing.Size(88, 20);
            this.txtQuantita.TabIndex = 5;
            this.txtQuantita.Tag = "estimatedetail.number.N";
            this.txtQuantita.TextChanged += new System.EventHandler(this.txtImponibile_TextChanged);
            // 
            // grpValoreUnitInValuta
            // 
            this.grpValoreUnitInValuta.Controls.Add(this.txtSconto);
            this.grpValoreUnitInValuta.Controls.Add(this.txtImponibile);
            this.grpValoreUnitInValuta.Controls.Add(this.label16);
            this.grpValoreUnitInValuta.Controls.Add(this.label18);
            this.grpValoreUnitInValuta.Location = new System.Drawing.Point(108, 196);
            this.grpValoreUnitInValuta.Name = "grpValoreUnitInValuta";
            this.grpValoreUnitInValuta.Size = new System.Drawing.Size(208, 56);
            this.grpValoreUnitInValuta.TabIndex = 6;
            this.grpValoreUnitInValuta.TabStop = false;
            this.grpValoreUnitInValuta.Text = "Valore unitario in valuta ";
            // 
            // txtSconto
            // 
            this.txtSconto.Location = new System.Drawing.Point(128, 32);
            this.txtSconto.Name = "txtSconto";
            this.txtSconto.Size = new System.Drawing.Size(64, 20);
            this.txtSconto.TabIndex = 6;
            this.txtSconto.Tag = "estimatedetail.discount.fixed.4..%.100";
            this.txtSconto.TextChanged += new System.EventHandler(this.txtImponibile_TextChanged);
            // 
            // txtImponibile
            // 
            this.txtImponibile.Location = new System.Drawing.Point(8, 32);
            this.txtImponibile.Name = "txtImponibile";
            this.txtImponibile.Size = new System.Drawing.Size(88, 20);
            this.txtImponibile.TabIndex = 5;
            this.txtImponibile.Tag = "estimatedetail.taxable.fixed.5...1";
            this.txtImponibile.TextChanged += new System.EventHandler(this.txtImponibile_TextChanged);
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(128, 16);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 16);
            this.label16.TabIndex = 36;
            this.label16.Text = "Sconto:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(8, 16);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(64, 16);
            this.label18.TabIndex = 34;
            this.label18.Text = "Imponibile:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(14, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "Quantità:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabFinanziario
            // 
            this.tabFinanziario.Controls.Add(this.gboxCausale);
            this.tabFinanziario.Controls.Add(this.lblcig);
            this.tabFinanziario.Controls.Add(this.txtcig);
            this.tabFinanziario.Controls.Add(this.gBoxupbIVA);
            this.tabFinanziario.Controls.Add(this.gboxUPB);
            this.tabFinanziario.Controls.Add(this.gboxImponibile);
            this.tabFinanziario.Controls.Add(this.gboxIVA);
            this.tabFinanziario.Controls.Add(this.txtstart);
            this.tabFinanziario.Controls.Add(this.label5);
            this.tabFinanziario.Controls.Add(this.txtstop);
            this.tabFinanziario.Controls.Add(this.label2);
            this.tabFinanziario.Location = new System.Drawing.Point(4, 22);
            this.tabFinanziario.Name = "tabFinanziario";
            this.tabFinanziario.Size = new System.Drawing.Size(849, 506);
            this.tabFinanziario.TabIndex = 0;
            this.tabFinanziario.Text = "Finanziario";
            this.tabFinanziario.UseVisualStyleBackColor = true;
            // 
            // gboxCausale
            // 
            this.gboxCausale.Controls.Add(this.TxtDescrCausaleDeb);
            this.gboxCausale.Controls.Add(this.txtCodiceCausaleEntrata);
            this.gboxCausale.Controls.Add(this.button6);
            this.gboxCausale.Location = new System.Drawing.Point(419, 262);
            this.gboxCausale.Name = "gboxCausale";
            this.gboxCausale.Size = new System.Drawing.Size(301, 104);
            this.gboxCausale.TabIndex = 68;
            this.gboxCausale.TabStop = false;
            this.gboxCausale.Tag = "AutoManage.txtCodiceCausaleEntrata.tree.(active = \'S\')";
            this.gboxCausale.Text = "Causale Bilancio di entrata";
            this.gboxCausale.UseCompatibleTextRendering = true;
            // 
            // TxtDescrCausaleDeb
            // 
            this.TxtDescrCausaleDeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtDescrCausaleDeb.Location = new System.Drawing.Point(120, 16);
            this.TxtDescrCausaleDeb.Multiline = true;
            this.TxtDescrCausaleDeb.Name = "TxtDescrCausaleDeb";
            this.TxtDescrCausaleDeb.ReadOnly = true;
            this.TxtDescrCausaleDeb.Size = new System.Drawing.Size(175, 56);
            this.TxtDescrCausaleDeb.TabIndex = 2;
            this.TxtDescrCausaleDeb.TabStop = false;
            this.TxtDescrCausaleDeb.Tag = "finmotive_income.title";
            // 
            // txtCodiceCausaleEntrata
            // 
            this.txtCodiceCausaleEntrata.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodiceCausaleEntrata.Location = new System.Drawing.Point(10, 78);
            this.txtCodiceCausaleEntrata.Name = "txtCodiceCausaleEntrata";
            this.txtCodiceCausaleEntrata.Size = new System.Drawing.Size(285, 20);
            this.txtCodiceCausaleEntrata.TabIndex = 10;
            this.txtCodiceCausaleEntrata.Tag = "finmotive_income.codemotive?x";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(10, 45);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(104, 23);
            this.button6.TabIndex = 0;
            this.button6.TabStop = false;
            this.button6.Tag = "manage.finmotive_income.tree";
            this.button6.Text = "Causale";
            // 
            // lblcig
            // 
            this.lblcig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblcig.Location = new System.Drawing.Point(124, 324);
            this.lblcig.Name = "lblcig";
            this.lblcig.Size = new System.Drawing.Size(207, 19);
            this.lblcig.TabIndex = 65;
            this.lblcig.Tag = "";
            this.lblcig.Text = "Codice Identificativo di Gara(CIG)";
            this.lblcig.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtcig
            // 
            this.txtcig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtcig.Location = new System.Drawing.Point(124, 346);
            this.txtcig.Name = "txtcig";
            this.txtcig.Size = new System.Drawing.Size(94, 20);
            this.txtcig.TabIndex = 64;
            this.txtcig.Tag = "estimatedetail.cigcode";
            // 
            // gBoxupbIVA
            // 
            this.gBoxupbIVA.Controls.Add(this.txtUPBiva);
            this.gBoxupbIVA.Controls.Add(this.label17);
            this.gBoxupbIVA.Controls.Add(this.buttonupbIVA);
            this.gBoxupbIVA.Controls.Add(this.textBox6);
            this.gBoxupbIVA.Location = new System.Drawing.Point(342, 3);
            this.gBoxupbIVA.Name = "gBoxupbIVA";
            this.gBoxupbIVA.Size = new System.Drawing.Size(315, 126);
            this.gBoxupbIVA.TabIndex = 20;
            this.gBoxupbIVA.TabStop = false;
            this.gBoxupbIVA.Tag = "AutoChoose.txtUPBiva.default.(active=\'S\')";
            this.gBoxupbIVA.Text = "UPB per la Contabilizzazione IVA";
            // 
            // txtUPBiva
            // 
            this.txtUPBiva.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUPBiva.Location = new System.Drawing.Point(9, 100);
            this.txtUPBiva.Name = "txtUPBiva";
            this.txtUPBiva.Size = new System.Drawing.Size(300, 20);
            this.txtUPBiva.TabIndex = 7;
            this.txtUPBiva.Tag = "upb_iva.codeupb?x";
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(7, 24);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(95, 50);
            this.label17.TabIndex = 6;
            this.label17.Text = "Utilizzare solo se diverso dal principale";
            // 
            // buttonupbIVA
            // 
            this.buttonupbIVA.BackColor = System.Drawing.SystemColors.Control;
            this.buttonupbIVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonupbIVA.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonupbIVA.Location = new System.Drawing.Point(10, 77);
            this.buttonupbIVA.Name = "buttonupbIVA";
            this.buttonupbIVA.Size = new System.Drawing.Size(76, 20);
            this.buttonupbIVA.TabIndex = 5;
            this.buttonupbIVA.TabStop = false;
            this.buttonupbIVA.Tag = "manage.upb_iva.tree";
            this.buttonupbIVA.Text = "UPB";
            this.buttonupbIVA.UseVisualStyleBackColor = false;
            // 
            // textBox6
            // 
            this.textBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox6.Location = new System.Drawing.Point(112, 16);
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(198, 78);
            this.textBox6.TabIndex = 4;
            this.textBox6.TabStop = false;
            this.textBox6.Tag = "upb_iva.title";
            // 
            // gboxUPB
            // 
            this.gboxUPB.Controls.Add(this.txtUPB);
            this.gboxUPB.Controls.Add(this.btnUPB);
            this.gboxUPB.Controls.Add(this.txtDescrUPB);
            this.gboxUPB.Location = new System.Drawing.Point(11, 3);
            this.gboxUPB.Name = "gboxUPB";
            this.gboxUPB.Size = new System.Drawing.Size(327, 125);
            this.gboxUPB.TabIndex = 1;
            this.gboxUPB.TabStop = false;
            this.gboxUPB.Tag = "AutoChoose.txtUPB.default.(active=\'S\')";
            // 
            // txtUPB
            // 
            this.txtUPB.Location = new System.Drawing.Point(8, 97);
            this.txtUPB.Name = "txtUPB";
            this.txtUPB.Size = new System.Drawing.Size(313, 20);
            this.txtUPB.TabIndex = 1;
            this.txtUPB.Tag = "upb.codeupb?x";
            // 
            // btnUPB
            // 
            this.btnUPB.BackColor = System.Drawing.SystemColors.Control;
            this.btnUPB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUPB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUPB.Location = new System.Drawing.Point(6, 71);
            this.btnUPB.Name = "btnUPB";
            this.btnUPB.Size = new System.Drawing.Size(76, 20);
            this.btnUPB.TabIndex = 5;
            this.btnUPB.TabStop = false;
            this.btnUPB.Tag = "manage.upb.tree";
            this.btnUPB.Text = "UPB";
            this.btnUPB.UseVisualStyleBackColor = false;
            // 
            // txtDescrUPB
            // 
            this.txtDescrUPB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrUPB.Location = new System.Drawing.Point(108, 8);
            this.txtDescrUPB.Multiline = true;
            this.txtDescrUPB.Name = "txtDescrUPB";
            this.txtDescrUPB.ReadOnly = true;
            this.txtDescrUPB.Size = new System.Drawing.Size(211, 81);
            this.txtDescrUPB.TabIndex = 4;
            this.txtDescrUPB.TabStop = false;
            this.txtDescrUPB.Tag = "upb.title";
            // 
            // tabAnalitico
            // 
            this.tabAnalitico.Controls.Add(this.grpRipartizioneRicavi);
            this.tabAnalitico.Controls.Add(this.gboxclass3);
            this.tabAnalitico.Controls.Add(this.gboxclass2);
            this.tabAnalitico.Controls.Add(this.gboxclass1);
            this.tabAnalitico.Location = new System.Drawing.Point(4, 22);
            this.tabAnalitico.Name = "tabAnalitico";
            this.tabAnalitico.Size = new System.Drawing.Size(849, 506);
            this.tabAnalitico.TabIndex = 3;
            this.tabAnalitico.Text = "Analitico";
            this.tabAnalitico.UseVisualStyleBackColor = true;
            // 
            // grpRipartizioneRicavi
            // 
            this.grpRipartizioneRicavi.Controls.Add(this.button3);
            this.grpRipartizioneRicavi.Controls.Add(this.textBox1);
            this.grpRipartizioneRicavi.Controls.Add(this.txtCodiceRipartizione);
            this.grpRipartizioneRicavi.Location = new System.Drawing.Point(350, 8);
            this.grpRipartizioneRicavi.Name = "grpRipartizioneRicavi";
            this.grpRipartizioneRicavi.Size = new System.Drawing.Size(305, 114);
            this.grpRipartizioneRicavi.TabIndex = 5;
            this.grpRipartizioneRicavi.TabStop = false;
            this.grpRipartizioneRicavi.Tag = "AutoChoose.txtCodiceRipartizione.default.(active=\'S\')";
            this.grpRipartizioneRicavi.Text = "Ripartizione dei Ricavi";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(8, 58);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(88, 23);
            this.button3.TabIndex = 4;
            this.button3.Tag = "choose.revenuepartition.default.(active=\'S\')";
            this.button3.Text = "Codice";
            this.button3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(130, 8);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(167, 72);
            this.textBox1.TabIndex = 3;
            this.textBox1.TabStop = false;
            this.textBox1.Tag = "revenuepartition.title";
            // 
            // txtCodiceRipartizione
            // 
            this.txtCodiceRipartizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodiceRipartizione.Location = new System.Drawing.Point(8, 88);
            this.txtCodiceRipartizione.Name = "txtCodiceRipartizione";
            this.txtCodiceRipartizione.Size = new System.Drawing.Size(289, 20);
            this.txtCodiceRipartizione.TabIndex = 2;
            this.txtCodiceRipartizione.Tag = "revenuepartition.revenuepartitioncode?x";
            // 
            // gboxclass3
            // 
            this.gboxclass3.Controls.Add(this.btnCodice3);
            this.gboxclass3.Controls.Add(this.txtDenom3);
            this.gboxclass3.Controls.Add(this.txtCodice3);
            this.gboxclass3.Location = new System.Drawing.Point(8, 254);
            this.gboxclass3.Name = "gboxclass3";
            this.gboxclass3.Size = new System.Drawing.Size(336, 118);
            this.gboxclass3.TabIndex = 3;
            this.gboxclass3.TabStop = false;
            this.gboxclass3.Tag = "AutoManage.txtCodice.treeclassmovimenti";
            this.gboxclass3.Text = "Classificazione 3";
            // 
            // btnCodice3
            // 
            this.btnCodice3.Location = new System.Drawing.Point(8, 66);
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
            this.txtDenom3.Location = new System.Drawing.Point(128, 19);
            this.txtDenom3.Multiline = true;
            this.txtDenom3.Name = "txtDenom3";
            this.txtDenom3.ReadOnly = true;
            this.txtDenom3.Size = new System.Drawing.Size(200, 70);
            this.txtDenom3.TabIndex = 3;
            this.txtDenom3.TabStop = false;
            this.txtDenom3.Tag = "sorting3.description";
            // 
            // txtCodice3
            // 
            this.txtCodice3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCodice3.Location = new System.Drawing.Point(8, 92);
            this.txtCodice3.Name = "txtCodice3";
            this.txtCodice3.Size = new System.Drawing.Size(320, 20);
            this.txtCodice3.TabIndex = 4;
            this.txtCodice3.Tag = "sorting3.sortcode?x";
            // 
            // gboxclass2
            // 
            this.gboxclass2.Controls.Add(this.btnCodice2);
            this.gboxclass2.Controls.Add(this.txtDenom2);
            this.gboxclass2.Controls.Add(this.txtCodice2);
            this.gboxclass2.Location = new System.Drawing.Point(8, 139);
            this.gboxclass2.Name = "gboxclass2";
            this.gboxclass2.Size = new System.Drawing.Size(336, 109);
            this.gboxclass2.TabIndex = 2;
            this.gboxclass2.TabStop = false;
            this.gboxclass2.Tag = "AutoManage.txtCodice.treeclassmovimenti";
            this.gboxclass2.Text = "Classificazione 2";
            // 
            // btnCodice2
            // 
            this.btnCodice2.Location = new System.Drawing.Point(8, 54);
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
            this.txtDenom2.Location = new System.Drawing.Point(128, 11);
            this.txtDenom2.Multiline = true;
            this.txtDenom2.Name = "txtDenom2";
            this.txtDenom2.ReadOnly = true;
            this.txtDenom2.Size = new System.Drawing.Size(200, 66);
            this.txtDenom2.TabIndex = 3;
            this.txtDenom2.TabStop = false;
            this.txtDenom2.Tag = "sorting2.description";
            // 
            // txtCodice2
            // 
            this.txtCodice2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCodice2.Location = new System.Drawing.Point(6, 83);
            this.txtCodice2.Name = "txtCodice2";
            this.txtCodice2.Size = new System.Drawing.Size(322, 20);
            this.txtCodice2.TabIndex = 2;
            this.txtCodice2.Tag = "sorting2.sortcode?x";
            // 
            // gboxclass1
            // 
            this.gboxclass1.Controls.Add(this.btnCodice1);
            this.gboxclass1.Controls.Add(this.txtDenom1);
            this.gboxclass1.Controls.Add(this.txtCodice1);
            this.gboxclass1.Location = new System.Drawing.Point(8, 8);
            this.gboxclass1.Name = "gboxclass1";
            this.gboxclass1.Size = new System.Drawing.Size(336, 114);
            this.gboxclass1.TabIndex = 1;
            this.gboxclass1.TabStop = false;
            this.gboxclass1.Tag = "AutoManage.txtCodice.treeclassmovimenti";
            this.gboxclass1.Text = "Classificazione 1";
            // 
            // btnCodice1
            // 
            this.btnCodice1.Location = new System.Drawing.Point(8, 61);
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
            this.txtDenom1.Location = new System.Drawing.Point(128, 10);
            this.txtDenom1.Multiline = true;
            this.txtDenom1.Name = "txtDenom1";
            this.txtDenom1.ReadOnly = true;
            this.txtDenom1.Size = new System.Drawing.Size(200, 74);
            this.txtDenom1.TabIndex = 3;
            this.txtDenom1.TabStop = false;
            this.txtDenom1.Tag = "sorting1.description";
            // 
            // txtCodice1
            // 
            this.txtCodice1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCodice1.Location = new System.Drawing.Point(6, 88);
            this.txtCodice1.Name = "txtCodice1";
            this.txtCodice1.Size = new System.Drawing.Size(322, 20);
            this.txtCodice1.TabIndex = 2;
            this.txtCodice1.Tag = "sorting1.sortcode?x";
            // 
            // tabFatturazione
            // 
            this.tabFatturazione.Controls.Add(this.checkBox1);
            this.tabFatturazione.Controls.Add(this.label13);
            this.tabFatturazione.Controls.Add(this.dataGrid1);
            this.tabFatturazione.Controls.Add(this.txtNInvoiced);
            this.tabFatturazione.Controls.Add(this.label10);
            this.tabFatturazione.Controls.Add(this.txtResiduo);
            this.tabFatturazione.Controls.Add(this.label9);
            this.tabFatturazione.Location = new System.Drawing.Point(4, 22);
            this.tabFatturazione.Name = "tabFatturazione";
            this.tabFatturazione.Size = new System.Drawing.Size(849, 506);
            this.tabFatturazione.TabIndex = 1;
            this.tabFatturazione.Text = "Fatturazione";
            this.tabFatturazione.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(278, 42);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(345, 24);
            this.checkBox1.TabIndex = 28;
            this.checkBox1.Tag = "estimatedetail.toinvoice:N:S";
            this.checkBox1.Text = "Non proporre più il dettaglio per l\'inserimento in fatture";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(8, 47);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(192, 16);
            this.label13.TabIndex = 27;
            this.label13.Text = "Elenco dettagli fatture associati";
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(8, 72);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(833, 428);
            this.dataGrid1.TabIndex = 26;
            this.dataGrid1.Tag = "invoicedetail.dettordine";
            // 
            // tabEP
            // 
            this.tabEP.Controls.Add(this.groupBox3);
            this.tabEP.Controls.Add(this.grpBoxSiopeEP);
            this.tabEP.Controls.Add(this.chkScrittureDifferite);
            this.tabEP.Controls.Add(this.grpBoxImpegniBudget);
            this.tabEP.Controls.Add(this.grpCausaleAnnullamento);
            this.tabEP.Controls.Add(this.gboxCompetenza);
            this.tabEP.Controls.Add(this.grpCausale);
            this.tabEP.Location = new System.Drawing.Point(4, 22);
            this.tabEP.Name = "tabEP";
            this.tabEP.Size = new System.Drawing.Size(849, 506);
            this.tabEP.TabIndex = 4;
            this.tabEP.Text = "E/P";
            this.tabEP.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnScollegaPreaccertamento);
            this.groupBox3.Controls.Add(this.btnCollegaPreaccertamento);
            this.groupBox3.Controls.Add(this.label24);
            this.groupBox3.Controls.Add(this.label25);
            this.groupBox3.Controls.Add(this.txtNumPreimpegno);
            this.groupBox3.Controls.Add(this.txtEsercPreImpegno);
            this.groupBox3.Location = new System.Drawing.Point(16, 396);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(347, 64);
            this.groupBox3.TabIndex = 51;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Preaccertamento di Budget selezionato manualmente";
            // 
            // btnScollegaPreaccertamento
            // 
            this.btnScollegaPreaccertamento.Location = new System.Drawing.Point(243, 29);
            this.btnScollegaPreaccertamento.Name = "btnScollegaPreaccertamento";
            this.btnScollegaPreaccertamento.Size = new System.Drawing.Size(75, 23);
            this.btnScollegaPreaccertamento.TabIndex = 15;
            this.btnScollegaPreaccertamento.TabStop = false;
            this.btnScollegaPreaccertamento.Tag = "";
            this.btnScollegaPreaccertamento.Text = "Scollega";
            this.btnScollegaPreaccertamento.Click += new System.EventHandler(this.btnScollegaPreaccertamento_Click);
            // 
            // btnCollegaPreaccertamento
            // 
            this.btnCollegaPreaccertamento.Location = new System.Drawing.Point(160, 29);
            this.btnCollegaPreaccertamento.Name = "btnCollegaPreaccertamento";
            this.btnCollegaPreaccertamento.Size = new System.Drawing.Size(75, 23);
            this.btnCollegaPreaccertamento.TabIndex = 14;
            this.btnCollegaPreaccertamento.TabStop = false;
            this.btnCollegaPreaccertamento.Tag = "";
            this.btnCollegaPreaccertamento.Text = "Collega";
            this.btnCollegaPreaccertamento.Click += new System.EventHandler(this.btnCollegaPreaccertamento_Click);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(86, 16);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(44, 13);
            this.label24.TabIndex = 7;
            this.label24.Text = "Numero";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(6, 16);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(49, 13);
            this.label25.TabIndex = 6;
            this.label25.Text = "Esercizio";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNumPreimpegno
            // 
            this.txtNumPreimpegno.Location = new System.Drawing.Point(89, 32);
            this.txtNumPreimpegno.Name = "txtNumPreimpegno";
            this.txtNumPreimpegno.ReadOnly = true;
            this.txtNumPreimpegno.Size = new System.Drawing.Size(64, 20);
            this.txtNumPreimpegno.TabIndex = 3;
            this.txtNumPreimpegno.TabStop = false;
            this.txtNumPreimpegno.Tag = "pre_epacc.nepacc";
            // 
            // txtEsercPreImpegno
            // 
            this.txtEsercPreImpegno.Location = new System.Drawing.Point(6, 32);
            this.txtEsercPreImpegno.Name = "txtEsercPreImpegno";
            this.txtEsercPreImpegno.ReadOnly = true;
            this.txtEsercPreImpegno.Size = new System.Drawing.Size(64, 20);
            this.txtEsercPreImpegno.TabIndex = 2;
            this.txtEsercPreImpegno.TabStop = false;
            this.txtEsercPreImpegno.Tag = "pre_epacc.yepacc";
            // 
            // grpBoxSiopeEP
            // 
            this.grpBoxSiopeEP.Controls.Add(this.btnSiope);
            this.grpBoxSiopeEP.Controls.Add(this.txtDescSiope);
            this.grpBoxSiopeEP.Controls.Add(this.txtCodSiope);
            this.grpBoxSiopeEP.Location = new System.Drawing.Point(377, 12);
            this.grpBoxSiopeEP.Name = "grpBoxSiopeEP";
            this.grpBoxSiopeEP.Size = new System.Drawing.Size(247, 144);
            this.grpBoxSiopeEP.TabIndex = 50;
            this.grpBoxSiopeEP.TabStop = false;
            this.grpBoxSiopeEP.Tag = "AutoChoose.txtCodSiope.tree";
            this.grpBoxSiopeEP.Text = "Class.SIOPE";
            // 
            // btnSiope
            // 
            this.btnSiope.Location = new System.Drawing.Point(7, 79);
            this.btnSiope.Name = "btnSiope";
            this.btnSiope.Size = new System.Drawing.Size(56, 20);
            this.btnSiope.TabIndex = 10;
            this.btnSiope.Text = "Codice";
            this.btnSiope.UseVisualStyleBackColor = true;
            // 
            // txtDescSiope
            // 
            this.txtDescSiope.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescSiope.Location = new System.Drawing.Point(69, 30);
            this.txtDescSiope.Multiline = true;
            this.txtDescSiope.Name = "txtDescSiope";
            this.txtDescSiope.ReadOnly = true;
            this.txtDescSiope.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescSiope.Size = new System.Drawing.Size(172, 69);
            this.txtDescSiope.TabIndex = 2;
            this.txtDescSiope.Tag = "sorting_siope.description";
            // 
            // txtCodSiope
            // 
            this.txtCodSiope.Location = new System.Drawing.Point(6, 108);
            this.txtCodSiope.Name = "txtCodSiope";
            this.txtCodSiope.ReadOnly = true;
            this.txtCodSiope.Size = new System.Drawing.Size(235, 20);
            this.txtCodSiope.TabIndex = 9;
            this.txtCodSiope.Tag = "sorting_siope.sortcode?x";
            // 
            // chkScrittureDifferite
            // 
            this.chkScrittureDifferite.AutoSize = true;
            this.chkScrittureDifferite.Location = new System.Drawing.Point(373, 240);
            this.chkScrittureDifferite.Name = "chkScrittureDifferite";
            this.chkScrittureDifferite.Size = new System.Drawing.Size(251, 17);
            this.chkScrittureDifferite.TabIndex = 11;
            this.chkScrittureDifferite.Tag = "estimatedetail.flag:0";
            this.chkScrittureDifferite.Text = "Scritture differite alla data contabile del dettaglio";
            this.chkScrittureDifferite.UseVisualStyleBackColor = true;
            // 
            // grpBoxImpegniBudget
            // 
            this.grpBoxImpegniBudget.Controls.Add(this.label34);
            this.grpBoxImpegniBudget.Controls.Add(this.label33);
            this.grpBoxImpegniBudget.Controls.Add(this.txtNumIxBudget);
            this.grpBoxImpegniBudget.Controls.Add(this.txtEsercIxBudget);
            this.grpBoxImpegniBudget.Location = new System.Drawing.Point(373, 389);
            this.grpBoxImpegniBudget.Name = "grpBoxImpegniBudget";
            this.grpBoxImpegniBudget.Size = new System.Drawing.Size(199, 71);
            this.grpBoxImpegniBudget.TabIndex = 48;
            this.grpBoxImpegniBudget.TabStop = false;
            this.grpBoxImpegniBudget.Text = "Accertamento di Budget";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(14, 49);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(44, 13);
            this.label34.TabIndex = 7;
            this.label34.Text = "Numero";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(9, 25);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(49, 13);
            this.label33.TabIndex = 6;
            this.label33.Text = "Esercizio";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNumIxBudget
            // 
            this.txtNumIxBudget.Location = new System.Drawing.Point(78, 45);
            this.txtNumIxBudget.Name = "txtNumIxBudget";
            this.txtNumIxBudget.ReadOnly = true;
            this.txtNumIxBudget.Size = new System.Drawing.Size(64, 20);
            this.txtNumIxBudget.TabIndex = 3;
            this.txtNumIxBudget.TabStop = false;
            this.txtNumIxBudget.Tag = "epacc.nepacc";
            // 
            // txtEsercIxBudget
            // 
            this.txtEsercIxBudget.Location = new System.Drawing.Point(78, 19);
            this.txtEsercIxBudget.Name = "txtEsercIxBudget";
            this.txtEsercIxBudget.ReadOnly = true;
            this.txtEsercIxBudget.Size = new System.Drawing.Size(64, 20);
            this.txtEsercIxBudget.TabIndex = 2;
            this.txtEsercIxBudget.TabStop = false;
            this.txtEsercIxBudget.Tag = "epacc.yepacc";
            // 
            // grpCausaleAnnullamento
            // 
            this.grpCausaleAnnullamento.Controls.Add(this.textBox2);
            this.grpCausaleAnnullamento.Controls.Add(this.txtCodiceCausaleAnnullamento);
            this.grpCausaleAnnullamento.Controls.Add(this.btnCausaleEPAnnullamento);
            this.grpCausaleAnnullamento.Location = new System.Drawing.Point(16, 224);
            this.grpCausaleAnnullamento.Name = "grpCausaleAnnullamento";
            this.grpCausaleAnnullamento.Size = new System.Drawing.Size(351, 144);
            this.grpCausaleAnnullamento.TabIndex = 3;
            this.grpCausaleAnnullamento.TabStop = false;
            this.grpCausaleAnnullamento.Tag = "AutoManage.txtCodiceCausaleAnnullamento.tree.(in_use=\'S\')";
            this.grpCausaleAnnullamento.Text = "Causale di annullamento";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(120, 16);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(225, 86);
            this.textBox2.TabIndex = 2;
            this.textBox2.TabStop = false;
            this.textBox2.Tag = "accmotiveappliedannulment.motive";
            // 
            // txtCodiceCausaleAnnullamento
            // 
            this.txtCodiceCausaleAnnullamento.Location = new System.Drawing.Point(6, 108);
            this.txtCodiceCausaleAnnullamento.Name = "txtCodiceCausaleAnnullamento";
            this.txtCodiceCausaleAnnullamento.Size = new System.Drawing.Size(339, 20);
            this.txtCodiceCausaleAnnullamento.TabIndex = 1;
            this.txtCodiceCausaleAnnullamento.Tag = "accmotiveappliedannulment.codemotive?x";
            // 
            // btnCausaleEPAnnullamento
            // 
            this.btnCausaleEPAnnullamento.Location = new System.Drawing.Point(10, 79);
            this.btnCausaleEPAnnullamento.Name = "btnCausaleEPAnnullamento";
            this.btnCausaleEPAnnullamento.Size = new System.Drawing.Size(104, 23);
            this.btnCausaleEPAnnullamento.TabIndex = 0;
            this.btnCausaleEPAnnullamento.TabStop = false;
            this.btnCausaleEPAnnullamento.Tag = "manage.accmotiveappliedannulment.tree";
            this.btnCausaleEPAnnullamento.Text = "Causale";
            // 
            // gboxCompetenza
            // 
            this.gboxCompetenza.Controls.Add(this.rdEPKind_N);
            this.gboxCompetenza.Controls.Add(this.rdEPKind_F);
            this.gboxCompetenza.Controls.Add(this.textBox4);
            this.gboxCompetenza.Controls.Add(this.rdEPKind_R);
            this.gboxCompetenza.Controls.Add(this.textBox3);
            this.gboxCompetenza.Controls.Add(this.label15);
            this.gboxCompetenza.Controls.Add(this.label14);
            this.gboxCompetenza.Location = new System.Drawing.Point(16, 159);
            this.gboxCompetenza.Name = "gboxCompetenza";
            this.gboxCompetenza.Size = new System.Drawing.Size(556, 59);
            this.gboxCompetenza.TabIndex = 2;
            this.gboxCompetenza.TabStop = false;
            this.gboxCompetenza.Text = "Competenza economica";
            // 
            // rdEPKind_N
            // 
            this.rdEPKind_N.AutoSize = true;
            this.rdEPKind_N.Location = new System.Drawing.Point(241, 16);
            this.rdEPKind_N.Name = "rdEPKind_N";
            this.rdEPKind_N.Size = new System.Drawing.Size(279, 17);
            this.rdEPKind_N.TabIndex = 9;
            this.rdEPKind_N.Tag = "estimatedetail.epkind:N";
            this.rdEPKind_N.Text = "Non generare ratei o scritture automatiche a fine anno";
            this.rdEPKind_N.UseVisualStyleBackColor = true;
            // 
            // rdEPKind_F
            // 
            this.rdEPKind_F.AutoSize = true;
            this.rdEPKind_F.Location = new System.Drawing.Point(413, 34);
            this.rdEPKind_F.Name = "rdEPKind_F";
            this.rdEPKind_F.Size = new System.Drawing.Size(117, 17);
            this.rdEPKind_F.TabIndex = 8;
            this.rdEPKind_F.Tag = "estimatedetail.epkind:F";
            this.rdEPKind_F.Text = "Fattura da emettere";
            this.rdEPKind_F.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(130, 32);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 10;
            this.textBox4.Tag = "estimatedetail.competencystop";
            // 
            // rdEPKind_R
            // 
            this.rdEPKind_R.AutoSize = true;
            this.rdEPKind_R.Location = new System.Drawing.Point(242, 34);
            this.rdEPKind_R.Name = "rdEPKind_R";
            this.rdEPKind_R.Size = new System.Drawing.Size(143, 17);
            this.rdEPKind_R.TabIndex = 7;
            this.rdEPKind_R.Tag = "estimatedetail.epkind:R";
            this.rdEPKind_R.Text = "Genera rateo a fine anno";
            this.rdEPKind_R.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(8, 32);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 9;
            this.textBox3.Tag = "estimatedetail.competencystart";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(130, 18);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 16);
            this.label15.TabIndex = 1;
            this.label15.Text = "Fine";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(8, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(100, 16);
            this.label14.TabIndex = 0;
            this.label14.Text = "Inizio";
            // 
            // grpCausale
            // 
            this.grpCausale.Controls.Add(this.txtDescrizioneCausale);
            this.grpCausale.Controls.Add(this.txtCodiceCausale);
            this.grpCausale.Controls.Add(this.btnCausaleEP);
            this.grpCausale.Location = new System.Drawing.Point(16, 12);
            this.grpCausale.Name = "grpCausale";
            this.grpCausale.Size = new System.Drawing.Size(351, 144);
            this.grpCausale.TabIndex = 1;
            this.grpCausale.TabStop = false;
            this.grpCausale.Tag = "AutoManage.txtCodiceCausale.tree.(in_use=\'S\')";
            this.grpCausale.Text = "Causale";
            // 
            // txtDescrizioneCausale
            // 
            this.txtDescrizioneCausale.Location = new System.Drawing.Point(120, 16);
            this.txtDescrizioneCausale.Multiline = true;
            this.txtDescrizioneCausale.Name = "txtDescrizioneCausale";
            this.txtDescrizioneCausale.ReadOnly = true;
            this.txtDescrizioneCausale.Size = new System.Drawing.Size(225, 86);
            this.txtDescrizioneCausale.TabIndex = 2;
            this.txtDescrizioneCausale.TabStop = false;
            this.txtDescrizioneCausale.Tag = "accmotiveapplied.motive";
            // 
            // txtCodiceCausale
            // 
            this.txtCodiceCausale.Location = new System.Drawing.Point(6, 108);
            this.txtCodiceCausale.Name = "txtCodiceCausale";
            this.txtCodiceCausale.Size = new System.Drawing.Size(339, 20);
            this.txtCodiceCausale.TabIndex = 1;
            this.txtCodiceCausale.Tag = "accmotiveapplied.codemotive?x";
            // 
            // btnCausaleEP
            // 
            this.btnCausaleEP.Location = new System.Drawing.Point(6, 79);
            this.btnCausaleEP.Name = "btnCausaleEP";
            this.btnCausaleEP.Size = new System.Drawing.Size(104, 23);
            this.btnCausaleEP.TabIndex = 0;
            this.btnCausaleEP.TabStop = false;
            this.btnCausaleEP.Tag = "manage.accmotiveapplied.tree";
            this.btnCausaleEP.Text = "Causale";
            // 
            // tabAppunti
            // 
            this.tabAppunti.Controls.Add(this.txtAppunti);
            this.tabAppunti.Location = new System.Drawing.Point(4, 22);
            this.tabAppunti.Name = "tabAppunti";
            this.tabAppunti.Size = new System.Drawing.Size(849, 506);
            this.tabAppunti.TabIndex = 5;
            this.tabAppunti.Text = "Appunti";
            this.tabAppunti.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBox9);
            this.tabPage1.Controls.Add(this.textBox8);
            this.tabPage1.Controls.Add(this.textBox7);
            this.tabPage1.Controls.Add(this.label26);
            this.tabPage1.Controls.Add(this.txtBollettino);
            this.tabPage1.Controls.Add(this.label23);
            this.tabPage1.Controls.Add(this.txtScadenza);
            this.tabPage1.Controls.Add(this.label22);
            this.tabPage1.Controls.Add(this.textBox5);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(849, 506);
            this.tabPage1.TabIndex = 7;
            this.tabPage1.Text = "PagoPA";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // textBox9
            // 
            this.textBox9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox9.Location = new System.Drawing.Point(278, 23);
            this.textBox9.Multiline = true;
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(550, 34);
            this.textBox9.TabIndex = 86;
            this.textBox9.Text = "Data oltre la quale potrebbe essere applicata una mora in caso di ritardato pagam" +
    "ento";
            // 
            // textBox8
            // 
            this.textBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox8.Location = new System.Drawing.Point(278, 79);
            this.textBox8.Multiline = true;
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(550, 34);
            this.textBox8.TabIndex = 85;
            this.textBox8.Text = "E\' il codice usato in ALTRI PROGRAMMI (es. segreterie studenti)  per identificare" +
    " questo credito.";
            // 
            // textBox7
            // 
            this.textBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox7.Location = new System.Drawing.Point(278, 149);
            this.textBox7.Multiline = true;
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(550, 97);
            this.textBox7.TabIndex = 84;
            this.textBox7.Text = resources.GetString("textBox7.Text");
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(16, 71);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(207, 19);
            this.label26.TabIndex = 83;
            this.label26.Tag = "";
            this.label26.Text = "Numero Bollettino";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBollettino
            // 
            this.txtBollettino.Location = new System.Drawing.Point(17, 91);
            this.txtBollettino.Name = "txtBollettino";
            this.txtBollettino.Size = new System.Drawing.Size(234, 20);
            this.txtBollettino.TabIndex = 82;
            this.txtBollettino.Tag = "estimatedetail.nform";
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(17, 14);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(104, 23);
            this.label23.TabIndex = 81;
            this.label23.Text = "Data Scadenza:";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtScadenza
            // 
            this.txtScadenza.Location = new System.Drawing.Point(17, 37);
            this.txtScadenza.Name = "txtScadenza";
            this.txtScadenza.Size = new System.Drawing.Size(104, 20);
            this.txtScadenza.TabIndex = 80;
            this.txtScadenza.Tag = "estimatedetail.proceedsexpiring";
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(13, 127);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(207, 19);
            this.label22.TabIndex = 79;
            this.label22.Tag = "";
            this.label22.Text = "Codice Bollettino Univoco ";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(14, 149);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(234, 20);
            this.textBox5.TabIndex = 78;
            this.textBox5.Tag = "estimatedetail.iduniqueformcode";
            // 
            // btnCodice
            // 
            this.btnCodice.Location = new System.Drawing.Point(0, 0);
            this.btnCodice.Name = "btnCodice";
            this.btnCodice.Size = new System.Drawing.Size(75, 23);
            this.btnCodice.TabIndex = 0;
            // 
            // Frm_estimatedetail_single
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(877, 576);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Frm_estimatedetail_single";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmdettContratto di Venditasingle";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gboxIVA.ResumeLayout(false);
            this.gboxIVA.PerformLayout();
            this.gboxImponibile.ResumeLayout(false);
            this.gboxImponibile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabMain.PerformLayout();
            this.gboxListino.ResumeLayout(false);
            this.gboxListino.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.grpRegistry.ResumeLayout(false);
            this.grpRegistry.PerformLayout();
            this.grpValoreUnitInValuta.ResumeLayout(false);
            this.grpValoreUnitInValuta.PerformLayout();
            this.tabFinanziario.ResumeLayout(false);
            this.tabFinanziario.PerformLayout();
            this.gboxCausale.ResumeLayout(false);
            this.gboxCausale.PerformLayout();
            this.gBoxupbIVA.ResumeLayout(false);
            this.gBoxupbIVA.PerformLayout();
            this.gboxUPB.ResumeLayout(false);
            this.gboxUPB.PerformLayout();
            this.tabAnalitico.ResumeLayout(false);
            this.grpRipartizioneRicavi.ResumeLayout(false);
            this.grpRipartizioneRicavi.PerformLayout();
            this.gboxclass3.ResumeLayout(false);
            this.gboxclass3.PerformLayout();
            this.gboxclass2.ResumeLayout(false);
            this.gboxclass2.PerformLayout();
            this.gboxclass1.ResumeLayout(false);
            this.gboxclass1.PerformLayout();
            this.tabFatturazione.ResumeLayout(false);
            this.tabFatturazione.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.tabEP.ResumeLayout(false);
            this.tabEP.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.grpBoxSiopeEP.ResumeLayout(false);
            this.grpBoxSiopeEP.PerformLayout();
            this.grpBoxImpegniBudget.ResumeLayout(false);
            this.grpBoxImpegniBudget.PerformLayout();
            this.grpCausaleAnnullamento.ResumeLayout(false);
            this.grpCausaleAnnullamento.PerformLayout();
            this.gboxCompetenza.ResumeLayout(false);
            this.gboxCompetenza.PerformLayout();
            this.grpCausale.ResumeLayout(false);
            this.grpCausale.PerformLayout();
            this.tabAppunti.ResumeLayout(false);
            this.tabAppunti.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        CQueryHelper QHC;
        QueryHelper QHS;
        
        DataAccess Conn;
        private string filterEpOperation;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
            HelpForm.SetDenyNull(DS.estimatedetail.Columns["toinvoice"], true);
            HelpForm.SetDenyNull(DS.estimatedetail.Columns["tax"], true);
            tassocambio = 1;
            codiceresponsabile = DBNull.Value;
            Hashtable h = (Hashtable) Meta.ExtraParameter;
            if (h == null) {
                grpValoreUnitInValuta.Text += "(non impostata)";
                tassocambio = 1;
                codiceresponsabile = DBNull.Value;
            }
            else {
                grpValoreUnitInValuta.Text += "(" + h["nomevaluta"].ToString() + ")";
                tassocambio = Convert.ToDouble(h["cambio"]);
                codiceresponsabile = h["codiceresponsabile"];
            }

            filterEpOperation = QHS.CmpEq("idepoperation", "fatven");
            //filterEpOperation calcolato, ora lo integriamo  integrando il filtro per dep/amm
            filterEpOperation = AddAccMotiveFilter.AddAmmDepFilter(filterEpOperation, Conn);
            DS.accmotiveapplied.ExtendedProperties[MetaData.ExtraParams] = filterEpOperation;
            DS.accmotiveappliedannulment.ExtendedProperties[MetaData.ExtraParams] = filterEpOperation; //maria
            GetData.SetStaticFilter(DS.accmotiveapplied, filterEpOperation);
            GetData.SetStaticFilter(DS.accmotiveappliedannulment, filterEpOperation);
            DataRow DR = Meta.SourceRow;

            if (DR["stop"] != DBNull.Value) {
                DateTime stop = (DateTime) DR["stop"];
                if (stop.Year != Conn.GetEsercizio()) txtstop.ReadOnly = true;
                if (DR.RowState==DataRowState.Unchanged)txtstop.ReadOnly = true;
                if (DR.RowState==DataRowState.Modified 
                    && DR["stop",DataRowVersion.Original]!=DBNull.Value)txtstop.ReadOnly = true;

            }
            if (DR.RowState!=DataRowState.Added) txtstart.ReadOnly = true;

            string filter_total;
            if (DR["idupb"] != DBNull.Value)
                filter_total = QHS.AppOr(QHS.CmpEq("idupb", DR["idupb"]), QHS.CmpEq("idman", codiceresponsabile));
            else
                filter_total = QHS.CmpEq("idman", codiceresponsabile);

            DataTable EstimateKind = Conn.RUN_SELECT("estimatekind", "*", null,
                QHS.CmpEq("idestimkind", DR["idestimkind"]), null, null, true);
            if (EstimateKind.Rows.Count > 0) {
                string multiReg = EstimateKind.Rows[0]["multireg"].ToString();
                if (multiReg == "S") {
                    grpRegistry.Visible = true;
                }
                else {
                    grpRegistry.Visible = false;
                }
                string statfilter = "";
                string linktoinvoice = EstimateKind.Rows[0]["linktoinvoice"].ToString();

                DataTable parentTable = DR.Table.DataSet.Tables["estimate"];
                DataRow drParent = DR.GetParentRow(QueryCreator.GetParentChildRel(parentTable, DR.Table));
                if (drParent.RowState != DataRowState.Added && linktoinvoice == "S") {
                    //Verifica se ci sono ratei o scritture di fatt. a ricevere 
                    string idrelated = EP_functions.GetIdForDocument(drParent);
                    idrelated  = idrelated + "§" + DR["rownum"];
                    int nRatei = Conn.RUN_SELECT_COUNT("entrydetail", QHS.CmpEq("idrelated", idrelated), false);
                    if (nRatei > 0) {
                        gboxCompetenza.Enabled = false;
                    }
                }

                if (linktoinvoice == "N") {
                    string filterthis = null;
                    if (Meta.EditMode) filterthis = QHS.CmpEq("idivakind", DR["idivakind"]);
                    statfilter = QHS.AppAnd(QHS.NullOrEq("active", "S"), QHS.DoPar(QHS.AppOr(
                        QHS.CmpEq("isnull(rate,0)", 0), filterthis)));


                }
                if (linktoinvoice == "N") {
                    rdEPKind_F.Enabled = false;
                    rdEPKind_R.Enabled = false;
                }

                string filterivakind = "";

                DataRow DRP = Meta.SourceRow.GetParentRow("estimateestimatedetail");
                string flagintracom = DRP["flagintracom"].ToString();

                if (flagintracom == "N")
                    filterivakind = QHS.AppAnd(filterivakind, QHS.BitSet("flag", 6)); //Italia
                if (flagintracom == "S")
                    filterivakind = QHS.AppAnd(filterivakind, QHS.BitSet("flag", 7)); //Intra-UE
                if (flagintracom == "X")
                    filterivakind = QHS.AppAnd(filterivakind, QHS.BitSet("flag", 8)); //Extra-UE


                if (filterivakind != "" && DR["idivakind"] != DBNull.Value) {
                    filterivakind = QHS.AppOr(QHS.CmpEq("idivakind", DR["idivakind"]), filterivakind);
                }
                if (filterivakind != "")
                    statfilter = QHS.AppAnd(statfilter, filterivakind);
                if (statfilter != "") GetData.SetStaticFilter(DS.ivakind, statfilter);
            }

            if (codiceresponsabile != DBNull.Value) {
                GetData.SetStaticFilter(DS.upb, filter_total);
                btnUPB.Tag = "choose.upb.tree." + filter_total;
            }
            else
                btnUPB.Tag = "manage.upb.tree";


            DataAccess.SetTableForReading(DS.finmotive_income, "finmotive");


            DataAccess.SetTableForReading(DS.sorting1, "sorting");
            DataAccess.SetTableForReading(DS.sorting2, "sorting");
            DataAccess.SetTableForReading(DS.sorting3, "sorting");
            DataAccess.SetTableForReading(DS.income_imponibile, "income");
            DataAccess.SetTableForReading(DS.income_iva, "income");
            DataAccess.SetTableForReading(DS.accmotiveappliedannulment, "accmotiveapplied");
            DataAccess.SetTableForReading(DS.upb_iva, "upb");
            DataTable tConfig = Conn.RUN_SELECT("config", "*", null,
                QHS.CmpEq("ayear", Meta.GetSys("esercizio")), null, null, true);
            if ((tConfig != null) && (tConfig.Rows.Count > 0)) {
                DataRow R = tConfig.Rows[0];
                object idsorkind1 = R["idsortingkind1"];
                object idsorkind2 = R["idsortingkind2"];
                object idsorkind3 = R["idsortingkind3"];
                CfgFn.SetGBoxClass(this, 1, idsorkind1);
                CfgFn.SetGBoxClass(this, 2, idsorkind2);
                CfgFn.SetGBoxClass(this, 3, idsorkind3);
                if (idsorkind1 == DBNull.Value && idsorkind2 == DBNull.Value && idsorkind3 == DBNull.Value) {
                    tabControl1.TabPages.Remove(tabAnalitico);
                }

                bool removeIvaTab = true;
                foreach (string COL in new string[] {
                    "agencycode", "deferredexpensephase", "deferredincomephase",
                    "flagpayment", "flagrefund", "idfinivapayment", "idfinivarefund", "idivapayperiodicity",
                    "minpayment",
                    "minrefund", "paymentagency", "refundagency"
                }) {
                    if (R[COL] == DBNull.Value) continue;
                    removeIvaTab = false;
                    break;
                }

                if (removeIvaTab) {
                    tabControl1.TabPages.Remove(tabFatturazione);
                }

               
            }

            //MODIFICHE TASK 10565 (RESO UGUALE A mandatedetail_single), quindi commentato il codice sottostante

            //DataTable DetailsEstimate = DR.Table.DataSet.Tables["estimatedetail"];
            //string filter = QHC.CmpEq("idgroup", DR["idgroup"]);
            //DataRow[] Selected = DetailsEstimate.Select(filter);
            //decimal detailsGroup = Selected.Length;
            //if (detailsGroup > 1) {
            //    DisableEditGroup();
            //    if ((DR["idinc_iva"] != DBNull.Value) || (DR["idinc_taxable"] != DBNull.Value)) {
            //        DisablePostLinked();

            //    }
            //}
            SiopeObj = new siope_helper(this, txtCodSiope, txtDescSiope, btnSiope, grpBoxSiopeEP, false, DS.sorting_siope);

			int esercizio = Conn.GetEsercizio();
			int yestim = CfgFn.GetNoNullInt32(DR["yestim"]);
			DateTime primoGennaio = new DateTime(esercizio, 1, 1);

			if ((yestim < esercizio) && (DR["idepacc"] != DBNull.Value)) {
				//Non modifica la causale EP per dettagli degli anni precedenti associati a impegni di budget
				btnListino.Enabled = false;
				txtListino.ReadOnly = true;
                btnCausaleEP.Enabled = false;
                txtCodiceCausale.ReadOnly = true;
                //btnCausaleEPAnnullamento.Enabled = false;
                //txtCodiceCausaleAnnullamento.ReadOnly = true;
                btnUPB.Enabled = false;
                buttonupbIVA.Enabled = false;
                txtUPB.ReadOnly = true;
                txtUPBiva.ReadOnly = true;
            }


		}

		siope_helper SiopeObj;


        //void DisablePostLinked() {
        //    txtImponibile.Enabled = false;
        //    TxtIvaValutaTot.Enabled = false;
        //    txtUPB.ReadOnly = true;
        //    btnUPB.Enabled = false;
        //}

        //void DisableEditGroup() {
        //    grpRegistry.Enabled = false;
        //    groupBox6.Enabled = false;
        //    txtQuantita.Enabled = false;
        //    txtSconto.Enabled = false;
        //    txtDescrizione.Enabled = false;
        //    txtstart.Enabled = false;
        //    //txtstop.Enabled = false;
        //    grpCausale.Enabled = false;
        //    grpCausaleAnnullamento.Enabled = false;
        //    //gboxCompetenza.Enabled = false;
        //}


        //FINE MODIFICHE TASK 10565 (RESO UGUALE A mandatedetail_single)

        object GetCtrlByName(string Name) {
            System.Reflection.FieldInfo Ctrl = this.GetType().GetField(Name);
            if (Ctrl == null) return null;
            //if (!typeof(Label).IsAssignableFrom(Ctrl.FieldType)) return null;                         
            //Label L =  (Label) Ctrl.GetValue(this);                        
            //return L;
            return Ctrl.GetValue(this);
        }


        void SetGBoxClass(int num, object sortingkind) {
            string nums = num.ToString();
            if (sortingkind == DBNull.Value) {
                GroupBox G = (GroupBox) GetCtrlByName("gboxclass" + num);
                G.Visible = false;
            }
            else {
                string filter = QHS.CmpEq("idsorkind", sortingkind);

                GetData.SetStaticFilter(DS.Tables["sorting" + nums], filter);
                GroupBox gboxclass = (GroupBox) GetCtrlByName("gboxclass" + nums);
                Button btnCodice = (Button) GetCtrlByName("btnCodice" + nums);
                string title = Conn.DO_READ_VALUE("sortingkind", filter, "description").ToString();
                gboxclass.Text = title;
                gboxclass.Tag = "AutoManage.txtCodice" + nums + ".tree." + filter;
                btnCodice.Tag = "manage.sorting" + nums + ".tree." + filter;
                DS.Tables["sorting" + nums].ExtendedProperties[MetaData.ExtraParams] = filter;
            }
        }

        public void MetaData_AfterFill() {
//			Calcola();
            CalcolaImponibileValuta();
            CalcolaImportiEUR(false);
            VisualizzaControlliContabilizzazione();
            CalcolaResiduo(false);
            HelpForm.SetDenyNull(DS.estimatedetail.Columns["idivakind"], true);
            DataRow Curr = DS.estimatedetail.Rows[0];
            SiopeObj.setCausaleEPCorrente(Curr["idaccmotive"]);
            if (Curr["idinc_iva"] != DBNull.Value) {
                gBoxupbIVA.Enabled = false;
                object idupb_iva = Conn.DO_READ_VALUE("incomeyear", QHS.CmpEq("idinc", Curr["idinc_iva"]),
                                "max(idupb)");
                if (Curr["idupb_iva"] == DBNull.Value && (Curr["idupb"].ToString()!=idupb_iva.ToString())) {
                    if (Meta.IsFirstFillForThisRow) {
                        if (MetaFactory.factory.getSingleton<IMessageShower>().Show(this,
                            "Aggiorno l'upb dell'iva in base a quello usato in fase di contabilizzazione?", "Avviso",
                            MessageBoxButtons.YesNo) == DialogResult.Yes) {
                            Curr["idupb_iva"] = idupb_iva;
                            Conn.RUN_SELECT_INTO_TABLE(DS.upb_iva, null, QHS.CmpEq("idupb", Curr["idupb_iva"]), null,
                                false);
                            Meta.myHelpForm.FillControls(gBoxupbIVA.Controls);
                        }
                    }
                }
            }

            if (Curr["idinc_taxable"] != DBNull.Value){
                gboxUPB.Enabled = false;
                object idupb_taxable = Conn.DO_READ_VALUE("incomeyear", QHS.CmpEq("idinc", Curr["idinc_taxable"]),
                                "max(idupb)");
                if (Curr["idupb"] == DBNull.Value && (Curr["idupb"].ToString() != idupb_taxable.ToString())){
                    if (Meta.IsFirstFillForThisRow){
                        if (MetaFactory.factory.getSingleton<IMessageShower>().Show(this,
                            "Aggiorno l'upb in base a quello usato in fase di contabilizzazione?", "Avviso",
                            MessageBoxButtons.YesNo) == DialogResult.Yes){
                            Curr["idupb"] = idupb_taxable;
                            Conn.RUN_SELECT_INTO_TABLE(DS.upb, null, QHS.CmpEq("idupb", Curr["idupb"]), null,
                                false);
                            Meta.myHelpForm.FillControls(gboxUPB.Controls);
                        }
                    }
                }
            }
            object idlist = Curr["idlist"];
            if (idlist != DBNull.Value) {
                DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.listview, null, QHS.CmpEq("idlist", idlist), null, true);
                if (DS.listview.Rows.Count != 0) {
                    riempiOggetti(DS.listview.Rows[0]);
                }
            }
        }

        public void MetaData_AfterGetFormData() {
            DataRow curr = DS.estimatedetail.Rows[0];
            //MOFICIHE TASK 10671
            if (curr["stop"] != DBNull.Value && curr["stop"].ToString() != "") {
                curr["toinvoice"] = "N";
            }
        }


        public void MetaData_AfterPost() {
            Meta.SourceRow.Table.ExtendedProperties["RigaModificata"] = Meta.SourceRow;
        }

        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (T.TableName == "ivakind") {
                if (R != null) {
                    aliquota = CfgFn.GetNoNullDouble(R["rate"]);
                }
                else {
                    aliquota = 0;
                }
                if (Meta.DrawStateIsDone) {
                    CalcolaImportiValuta(Meta.DrawStateIsDone);
                    CalcolaImportiEUR(Meta.DrawStateIsDone);
                }
            }
            if (T.TableName == "accmotiveapplied") {
                if (!Meta.DrawStateIsDone)
                    return;
                if (Meta.IsEmpty)
                    return;
                SiopeObj.setCausaleEPCorrente(R?["idaccmotive"]);
                SiopeObj.selectSiope();
            }
        }

        decimal NInvoiced;
        bool NInvoicedEvalued = false;

        void CalcolaResiduo(bool LeggiDati) {
            if (Meta.InsertMode) {
                txtResiduo.Text = "";
                return;
            }
            if (LeggiDati) Meta.GetFormData(true);
            DataRow Curr = DS.estimatedetail.Rows[0];
            decimal N = CfgFn.GetNoNullDecimal(Curr["number"]);
            if (!NInvoicedEvalued) {
                string filter = QueryCreator.WHERE_KEY_CLAUSE(Curr, DataRowVersion.Default, true);
                NInvoiced = CfgFn.GetNoNullDecimal(
                    Conn.DO_READ_VALUE("estimatedetailtoinvoice", filter, "invoiced"));
            }
            decimal INVOICED = NInvoiced;
            decimal residual = N - INVOICED;

            if (NInvoiced >= 0) {
                txtNInvoiced.Text = NInvoiced.ToString("n");
            }
            else {
                txtNInvoiced.Text = "";
            }

            if (residual >= 0) {
                txtResiduo.Text = residual.ToString("n");
            }
            else {
                txtResiduo.Text = "";
            }
        }

        void VisualizzaControlliContabilizzazione() {
            DataRow Curr = DS.estimatedetail.Rows[0];
            if (Meta.InsertMode) {
                gboxImponibile.Visible = false;
                gboxIVA.Visible = false;
                return;
            }
            if (Curr["idinc_taxable"] == DBNull.Value) {
                btnRemoveImponibile.Visible = false;
            }
            if (Curr["idinc_iva"] == DBNull.Value) {
                btnRemoveIva.Visible = false;
            }
        }


        private void Calcola() {
        }

        private void CalcolaImportiEUR(bool LeggiDati) {
            if (LeggiDati) Meta.GetFormData(true);
            DataRow Curr = DS.estimatedetail.Rows[0];

            try {
                double imponibile = CfgFn.GetNoNullDouble(Curr["taxable"]);
                double quantita = CfgFn.GetNoNullDouble(Curr["number"]);
                double sconto = CfgFn.GetNoNullDouble(Curr["discount"]);
                double imponibiletotEUR = CfgFn.RoundValuta((imponibile*quantita*(1 - sconto)*tassocambio));
                //double imponibiletotEUR = CfgFn.RoundValuta(imponibiletot*tassocambio);
                double iva = CfgFn.GetNoNullDouble(Curr["tax"]);
                double ivaEUR = CfgFn.RoundValuta(iva*tassocambio);

                txtImponibileEUR.Text = HelpForm.StringValue(imponibiletotEUR,"x.y.fixed.2...1");
                //imponibiletotEUR.ToString("n");
                txtIvaEUR.Text = HelpForm.StringValue(ivaEUR, "x.y.fixed.2...1"); //                .ToString("n");
            }
            catch {
                txtImponibileEUR.Text = "";
                txtIvaEUR.Text = "";
            }

        }

        private void CalcolaImportiValuta(bool LeggiDati) {
            if (LeggiDati) Meta.GetFormData(true);
            DataRow Curr = DS.estimatedetail.Rows[0];

            try {
                double imponibile = CfgFn.GetNoNullDouble(Curr["taxable"]);
                double quantita = CfgFn.GetNoNullDouble(Curr["number"]);
                double sconto = CfgFn.GetNoNullDouble(Curr["discount"]);
                double imponibiletot = CfgFn.RoundValuta((imponibile*quantita*(1 - sconto)));
                double imponibiletotEUR = CfgFn.RoundValuta((imponibile*quantita*(1 - sconto)*tassocambio));
                //double imponibiletotEUR = CfgFn.RoundValuta(imponibiletot*tassocambio);
                double iva = CfgFn.RoundValuta(imponibiletot*aliquota);
                double ivaEUR = CfgFn.RoundValuta(iva*tassocambio);
                TxtImponibileValutaTot.Text = HelpForm.StringValue(imponibiletot,
                    "x.y.fixed.2...1"); //             imponibiletot.ToString("n");
                TxtIvaValutaTot.Text = HelpForm.StringValue(iva, "x.y.fixed.2...1"); //   iva.ToString("n");
                Curr["taxrate"] = aliquota;
                txtTaxRate.Text = HelpForm.StringValue(aliquota, txtTaxRate.Tag.ToString());
                //aliquota.ToString("p04");
            }
            catch {
                TxtImponibileValutaTot.Text = "";
                TxtIvaValutaTot.Text = "";
                txtTaxRate.Text = "";
            }
        }


        private void CalcolaImponibileValuta() {
            DataRow Curr = DS.estimatedetail.Rows[0];

            try {
                double imponibile = CfgFn.GetNoNullDouble(Curr["taxable"]);
                double quantita = CfgFn.GetNoNullDouble(Curr["number"]);
                double sconto = CfgFn.GetNoNullDouble(Curr["discount"]);
                double imponibiletot = CfgFn.RoundValuta((imponibile*quantita*(1 - sconto)));
                TxtImponibileValutaTot.Text = HelpForm.StringValue(imponibiletot, "x.y.fixed.2...1");
                    //         imponibiletot.ToString("n");
            }
            catch {
                TxtImponibileValutaTot.Text = "";
            }
        }


        private void txtImponibile_TextChanged(object sender, System.EventArgs e) {
            if (!Meta.DrawStateIsDone) return;
//			Calcola();
            CalcolaImportiValuta(true);
            CalcolaImportiEUR(true);
            if (sender == txtQuantita) CalcolaResiduo(true);
        }

        private void btnRemoveIva_Click(object sender, System.EventArgs e) {
            if (MetaFactory.factory.getSingleton<IMessageShower>().Show(this,
                "Rimuovendo la contabilizzazione del DETTAGLIO il movimento finanziario continuerà " +
                "comunque a contabilizzare il contratto attivo, tuttavia in forma 'generica'. Per rimuovere la contabilizzazione " +
                "del contratto è necessario eseguire la procedura guidata 'Rimuovi contabilizzazione'.\r" +
                "Procedo a rimuovere la contabilizzazione del dettaglio?", "Avviso", MessageBoxButtons.YesNo) !=
                DialogResult.Yes) return;
            DataRow Curr = DS.estimatedetail.Rows[0];
            Curr["idinc_iva"] = DBNull.Value;
            DS.income_iva.Clear();
            txtEsercizioIva.Text = "";
            txtNumeroIva.Text = "";

            if (Curr["idinc_iva", DataRowVersion.Original].ToString() ==
                Curr["idinc_taxable", DataRowVersion.Original].ToString()) {
                Curr["idinc_taxable"] = DBNull.Value;
                DS.income_imponibile.Clear();
                txtEsercizioImponibile.Text = "";
                txtNumImponibile.Text = "";
            }
        }

        private void btnRemoveImponibile_Click(object sender, System.EventArgs e) {
            if (MetaFactory.factory.getSingleton<IMessageShower>().Show(this,
                "Rimuovendo la contabilizzazione del DETTAGLIO il movimento finanziario continuerà " +
                "comunque a contabilizzare il contratto attivo, tuttavia in forma 'generica'. Per rimuovere la contabilizzazione " +
                "del contratto è necessario eseguire la procedura guidata 'Rimuovi contabilizzazione'.\r" +
                "Procedo a rimuovere la contabilizzazione del dettaglio?", "Avviso", MessageBoxButtons.YesNo) !=
                DialogResult.Yes) return;
            DataRow Curr = DS.estimatedetail.Rows[0];
            Curr["idinc_taxable"] = DBNull.Value;
            DS.income_imponibile.Clear();
            txtEsercizioImponibile.Text = "";
            txtNumImponibile.Text = "";
            if (Curr["idinc_iva", DataRowVersion.Original].ToString() ==
                Curr["idinc_taxable", DataRowVersion.Original].ToString()) {
                Curr["idinc_iva"] = DBNull.Value;
                DS.income_iva.Clear();
                txtEsercizioIva.Text = "";
                txtNumeroIva.Text = "";
            }
        }

        private void TxtIvaValutaTot_TextChanged(object sender, System.EventArgs e) {
            if (!Meta.DrawStateIsDone) return;
            CalcolaImportiEUR(true);
        }

        private void tabMain_Click(object sender, EventArgs e) {

        }

        private void btnListino_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty)
                return;
            if (!Meta.IsEmpty) {
                Meta.GetFormData(true);
            }
            DataRow Curr = DS.estimatedetail.Rows[0];
            string filter =
                QHS.DoPar(QHS.AppOr(QHS.IsNull("validitystop"), QHS.CmpGe("validitystop", Meta.GetSys("datacontabile"))));
            filter = QHS.AppAnd(filter, QHS.BitSet("flagvisiblekind", 2)); //bit 2: visibile nei c. attivi
            filter = QHS.AppAnd(filter, QHS.NullOrEq("active", "S"));
            MetaData Mlistino = MetaData.GetMetaData(this, "listview");
            Mlistino.FilterLocked = true;
            Mlistino.DS = DS.Clone();

            if (chkListDescription.Checked) {
                FrmAskDescr FR = new FrmAskDescr(Meta.Dispatcher);
                DialogResult D = FR.ShowDialog(this);
                if (D != DialogResult.OK)
                    return;
                if (FR.Selected != null) {
                    object idlistclass = FR.Selected["idlistclass"];
                    filter = QHS.AppAnd(filter, QHS.CmpEq("idlistclass", FR.Selected["idlistclass"]));
                }
                if (FR.txtDescrizione.Text != "") {
                    string Description = FR.txtDescrizione.Text;
                    if (!Description.EndsWith("%"))
                        Description += "%";
                    if (!Description.StartsWith("%"))
                        Description = "%" + Description;
                    filter = QHS.AppAnd(filter, QHS.Like("description", Description));
                }
            }



            DataRow Choosen = Mlistino.SelectOne("default", filter, "listview", null);
            if (Choosen == null)
                return;

            AggiornaListino(Choosen);
            return;
        }

        void AggiornaListino(DataRow Choosen) {
            DataRow Curr = DS.estimatedetail.Rows[0];
            if (txtDescrizione.Text != "") {
                if (CfgFn.GetNoNullInt32(Curr["idlist"]) != CfgFn.GetNoNullInt32(Choosen["idlist"])) {
                    if (MetaFactory.factory.getSingleton<IMessageShower>().Show("Aggiorno il campo descrizione in base al listino selezionato?",
                        "Conferma", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        txtDescrizione.Text = Choosen["description"].ToString();
                    Curr["detaildescription"] = Choosen["description"].ToString();

                }
            }
            else {
                Curr["detaildescription"] = Choosen["description"].ToString();
                txtDescrizione.Text = Choosen["description"].ToString();
            }
            string filterEstimKind = QHS.CmpEq("idestimkind", Curr["idestimkind"]);
            object linkToInvoice = Conn.DO_READ_VALUE("estimatekind", filterEstimKind, "linktoinvoice");
            object idlistclasssel = Choosen["idlistclass"];
            string filterListClass = QHS.AppAnd(QHS.CmpEq("idlistclass", idlistclasssel),
                QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
            Curr["idlist"] = Choosen["idlist"];

            // Legge la causale EP associata alla classificazione merceologica del listino, e la scrive nella causale EP del dettaglio ordine.
            object idaccmotive = Conn.DO_READ_VALUE("listclass", QHS.CmpEq("idlistclass", Choosen["idlistclass"]),
                "idaccmotive");
            DS.accmotiveapplied.Clear();
            Meta.Conn.RUN_SELECT_INTO_TABLE(DS.accmotiveapplied, null, QHS.AppAnd(filterEpOperation, QHS.CmpEq("idaccmotive", idaccmotive)), null,
                false);
            if (DS.accmotiveapplied.Rows.Count > 0) {
                DataRow AccMotive = DS.accmotiveapplied.Rows[0];
                txtCodiceCausale.Text = AccMotive["codemotive"].ToString();
                txtDescrizioneCausale.Text = AccMotive["motive"].ToString();
                Curr["idaccmotive"] = AccMotive["idaccmotive"].ToString();
            }
            else {
                txtCodiceCausale.Text = "";
                txtDescrizioneCausale.Text = "";
                Curr["idaccmotive"] = DBNull.Value;
            }
            SiopeObj.setCausaleEPCorrente(Curr?["idaccmotive"]);
            SiopeObj.selectSiope();
            riempiOggetti(Choosen);
        }

        private void riempiOggetti(DataRow listRow) {
            txtListino.Text = (listRow != null) ? listRow["intcode"].ToString() : "";
            txtDescrizioneListino.Text = (listRow != null) ? listRow["description"].ToString() : "";
        }

        private void svuotaOggetti() {
            txtDescrizioneListino.Text = "";
            if ((!MetaData.Empty(this))) {
                DS.estimatedetail.Rows[0]["idlist"] = DBNull.Value;
            }
        }

        private void txtListino_TextChanged(object sender, EventArgs e) {
         
        }

        private void txtListino_Leave(object sender, EventArgs e) {
            if (Meta == null)
                return;
            if (!Meta.DrawStateIsDone)
                return;
            if (!Meta.IsEmpty) {
                Meta.GetFormData(true);
            }
            if (txtListino.Text == "") {
                svuotaOggetti();
                return;
            }
            if (DS.estimatedetail.Rows.Count == 0)
                return;
            if (!Meta.DrawStateIsDone)
                return;
            if (txtListino.Text == lastCodice) return;
            string filter =
                QHS.DoPar(QHS.AppOr(QHS.IsNull("validitystop"), QHS.CmpGe("validitystop", Meta.GetSys("datacontabile"))));

            string IntCode = txtListino.Text;
            if (!IntCode.EndsWith("%"))
                IntCode += "%";
            filter = QHC.AppAnd(filter, QHS.Like("intcode", IntCode));
            filter = QHS.AppAnd(filter, QHS.NullOrEq("active", "S"));
            filter = QHS.AppAnd(filter, QHS.BitSet("flagvisiblekind", 2)); //bit 2: visibile nei c. attivi
            MetaData Mlistino = MetaData.GetMetaData(this, "listview");
            Mlistino.FilterLocked = true;
            Mlistino.DS = DS.Clone();

            DataRow Choosen = Mlistino.SelectOne("default", filter, "listview", null);
            if (Choosen == null) {
                txtListino.Focus();
                lastCodice = null;
                return;
            }

            AggiornaListino(Choosen);
        }

        private string lastCodice;
        private void txtListino_Enter(object sender, EventArgs e) {
            lastCodice = txtListino.Text;
        }

        public string GetFilterForEpAcc(DataRow Curr) {
            int nphase = 1; // Preimpegno
            string Filterbase = QHS.AppAnd(QHS.CmpEq("ayear", Meta.GetSys("esercizio")), QHS.CmpEq("nphase", nphase));

            //Se la fattura è collegata a dettaglio C.A., prenderemo l'accertamento di budget di quel dettaglio.            
            //La scelta va fatta solo sugli Accertamenti di Budget imputati a Conti di Ricavi
            Filterbase = QHS.AppAnd(Filterbase,QHS.CmpGt("totavailable",0),QHS.CmpEq("revenue","S")) ;
            if (Curr["idupb"] != null && Curr["idupb"] != DBNull.Value) {
                Filterbase = QHS.AppAnd(Filterbase, QHS.CmpEq("idupb", Curr["idupb"]));
            }

            return Filterbase;
        }

        private void btnCollegaPreaccertamento_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty)return;
            var Curr = DS.estimatedetail.First();
            MetaData.GetFormData(this, true);
            if (Curr["idepacc"] != DBNull.Value) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Non è possibile collegare un preimpegno avendo già generato l'impegno di budget",
                    "Errore");
                return;
            }

            string FilterExpBudget = GetFilterForEpAcc(Curr);

            string VistaScelta = "epaccview";

            MetaData Mepexp = Meta.Dispatcher.Get(VistaScelta);
            Mepexp.FilterLocked = true;
            Mepexp.DS = DS;
            DataRow MyDR = Mepexp.SelectOne("default", FilterExpBudget, null, null);

            if (MyDR != null) {
                Curr["idepacc_pre"] = MyDR["idepacc"];
                Meta.FreshForm();
            }
        }

        private void btnScollegaPreaccertamento_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty)return;
            MetaData.GetFormData(this, true);

            DataRow Curr = DS.estimatedetail.Rows[0];
            if (Curr["idepacc"] != DBNull.Value) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Non è possibile scollegare un preimpegno avendo già generato l'accertamento di budget",
                    "Errore");
                return;
            }

            Curr["idepacc_pre"] = DBNull.Value;
            DS.pre_epacc.Clear();
            txtEsercPreImpegno.Text = "";
            txtNumPreimpegno.Text = "";
            Meta.FreshForm();
        }

        private void txtstop_Leave(object sender, EventArgs e) {
            if (txtstop.ReadOnly)return;
            if (txtstop.Text.Trim()=="")return;
            object d = HelpForm.GetObjectFromString(typeof(DateTime), txtstop.Text, txtstop.Tag.ToString());
            if (d==null)return;
            if (((DateTime) d).Year != Conn.GetEsercizio()) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("E' necessario che la data di fine validità sia dell'esercizio.", "Errore");
                txtstop.Text = "";
            }
            if (Meta.DrawStateIsDone &&!Meta.IsEmpty) {
                var curr = DS.estimatedetail[0];
                if (((DateTime) d).Year < curr.yestim) {
                    MetaFactory.factory.getSingleton<IMessageShower>().Show("E' necessario che la data di fine validità non preceda l'anno di creazione del contratto.", "Errore");
                    txtstop.Text = "";
                }
            }
        }

        private void txtstart_Leave(object sender, EventArgs e) {
            if (txtstart.ReadOnly)return;
            if (txtstart.Text.Trim()=="")return;
            object d = HelpForm.GetObjectFromString(typeof(DateTime), txtstart.Text, txtstart.Tag.ToString());
            if (d==null)return;
            if (((DateTime) d).Year != Conn.GetEsercizio()) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("E' necessario che la data di inizio validità sia dell'esercizio.", "Errore");
                txtstart.Text = "";
            }
            if (Meta.DrawStateIsDone &&!Meta.IsEmpty) {
                var curr = DS.estimatedetail[0];
                if (((DateTime) d).Year < curr.yestim) {
                    MetaFactory.factory.getSingleton<IMessageShower>().Show("E' necessario che la data di inizio validità non preceda l'anno di creazione del contratto.", "Errore");
                    txtstart.Text = "";
                }
            }

        }
    }
}
