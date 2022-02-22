
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
using System.Data;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;//funzioni_configurazione

namespace finvar_default//VariazioneBilancio//
{
    /// <summary>
    /// Summary description for frmVariazioneBilancio.
    /// Revised by Nino on 22/12/2002
    /// Revised by Nino on 9/1/2003
    /// </summary>
    public class Frm_finvar_default : MetaDataForm {
        private System.Windows.Forms.TextBox txtDescrizione;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEsercizio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.TextBox txtProvvedimento;
        private System.Windows.Forms.TextBox txtDataContabile;
        private System.Windows.Forms.TextBox txtDataProvv;
        private System.Windows.Forms.TextBox txtNumProvv;
        private System.Windows.Forms.RadioButton rdbVarNormale;
        private System.Windows.Forms.RadioButton rdbVarRipartizione;
        private System.Windows.Forms.RadioButton rdbVarAssestamento;
        public vistaForm DS;
        private System.Windows.Forms.TextBox txtSaldo;
        private System.Windows.Forms.GroupBox groupTipoPrevisione;
        MetaData Meta;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdbVarStorno;
        private System.Windows.Forms.CheckBox ckbPrevSecondaria;
        private System.Windows.Forms.CheckBox ckbPrevPrincipale;
        private System.Windows.Forms.CheckBox chkCassa;
        private System.Windows.Forms.CheckBox chkCrediti;
        private GroupBox groupBox4;
        private TextBox txtNumUfficiale;
        private CheckBox chkOfficial;
        string flagcredit;
        string flagproceeds;
        private GroupBox gboxStato;
        private ComboBox cmbStatus;
        private GroupBox grpAtto;
        private TextBox txtNact;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        bool DoSendMail;
        private RadioButton rdbVarIniziale;
        private GroupBox gboxResponsabile;
        public TextBox txtResponsabile;
        private Button button4;
        private CheckBox chkMoneyTransfer;
        private CheckBox chkDispPresunto;
        private Button btnScegliAtto;
        private TabPage tabPage1;
        private GroupBox grpTipoClass;
        public TextBox txtTipoClass;
        private Button btnTipoClass;
        private Label label10;
        private TextBox textBox3;
        private TabPage tabAllegati;
        private DataGrid dataGrid3;
        private Button button2;
        private Button button3;
        private Button button1;
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
        private TabPage tabRicariche;
        private DataGrid dataGrid2;
        private TabPage tabAnnotazioni;
        private Label label4;
        private TextBox textBox1;
        private TextBox textBox4;
        private Label label11;
        private TabPage tabDettagli;
        private Button btnStornoDaCard;
        private Button btnInserisci;
        private Button btnModifica;
        private Button btnElimina;
        private DataGrid gridDetails;
        private Button btnStornoTraUpb;
        private TabControl tabControl1;
        private Button btnSimula;
        int CurrentStatus;

        public Frm_finvar_default() {
            InitializeComponent();
            DS.finvardetail.ExtendedProperties["ViewTable"] = DS.finvardetailview;
            DS.fin.ExtendedProperties["ViewTable"] = DS.finvardetailview;
            DS.upb.ExtendedProperties["ViewTable"] = DS.finvardetailview;
            DS.underwriting.ExtendedProperties["ViewTable"] = DS.finvardetailview;

            DS.finvardetailview.ExtendedProperties["RealTable"] = DS.finvardetail;

            DS.finvardetailview.Columns["yvar"].ExtendedProperties["ViewSource"] = "finvardetail.yvar";
            DS.finvardetailview.Columns["nvar"].ExtendedProperties["ViewSource"] = "finvardetail.nvar";
            DS.finvardetailview.Columns["rownum"].ExtendedProperties["ViewSource"] = "finvardetail.rownum";
            DS.finvardetailview.Columns["idfin"].ExtendedProperties["ViewSource"] = "finvardetail.idfin";
            DS.finvardetailview.Columns["idupb"].ExtendedProperties["ViewSource"] = "finvardetail.idupb";//<--
            DS.finvardetailview.Columns["amount"].ExtendedProperties["ViewSource"] = "finvardetail.amount";
            DS.finvardetailview.Columns["prevision2"].ExtendedProperties["ViewSource"] = "finvardetail.prevision2";
            DS.finvardetailview.Columns["prevision3"].ExtendedProperties["ViewSource"] = "finvardetail.prevision3";
            DS.finvardetailview.Columns["residual"].ExtendedProperties["ViewSource"] = "finvardetail.residual";
            DS.finvardetailview.Columns["previousprevision"].ExtendedProperties["ViewSource"] = "finvardetail.previousprevision";
            DS.finvardetailview.Columns["description"].ExtendedProperties["ViewSource"] = "finvardetail.description";
            DS.finvardetailview.Columns["limit"].ExtendedProperties["ViewSource"] = "finvardetail.limit";
            DS.finvardetailview.Columns["annotation"].ExtendedProperties["ViewSource"] = "finvardetail.annotation";
            DS.finvardetailview.Columns["idexp"].ExtendedProperties["ViewSource"] = "finvardetail.idexp";
            DS.finvardetailview.Columns["createexpense"].ExtendedProperties["ViewSource"] = "finvardetail.createexpense";
            DS.finvardetailview.Columns["idlcard"].ExtendedProperties["ViewSource"] = "finvardetail.idlcard";
            DS.finvardetailview.Columns["idunderwriting"].ExtendedProperties["ViewSource"] = "finvardetail.idunderwriting";

            DS.finvardetailview.Columns["cu"].ExtendedProperties["ViewSource"] = "finvardetail.cu";
            DS.finvardetailview.Columns["ct"].ExtendedProperties["ViewSource"] = "finvardetail.ct";
            DS.finvardetailview.Columns["lu"].ExtendedProperties["ViewSource"] = "finvardetail.lu";
            DS.finvardetailview.Columns["lt"].ExtendedProperties["ViewSource"] = "finvardetail.lt";

            DS.finvardetailview.Columns["ayear"].ExtendedProperties["ViewSource"] = "fin.ayear";
            DS.finvardetailview.Columns["flag"].ExtendedProperties["ViewSource"] = "fin.flag";
            DS.finvardetailview.Columns["codefin"].ExtendedProperties["ViewSource"] = "fin.codefin";
            DS.finvardetailview.Columns["finance"].ExtendedProperties["ViewSource"] = "fin.title";

            DS.finvardetailview.Columns["codeupb"].ExtendedProperties["ViewSource"] = "upb.codeupb";
            DS.finvardetailview.Columns["idtreasurer"].ExtendedProperties["ViewSource"] = "upb.idtreasurer";
            DS.finvardetailview.Columns["upb"].ExtendedProperties["ViewSource"] = "upb.title";

            DS.finvardetailview.Columns["underwriting"].ExtendedProperties["ViewSource"] = "underwriting.title";


            HelpForm.SetDenyNull(DS.Tables["finvar"].Columns["official"], true);
            HelpForm.SetDenyNull(DS.Tables["finvar"].Columns["idfinvarstatus"], true);

            QueryCreator.SetTableForPosting(DS.lcardvarview, "lcardvar");

        }

        private bool solaCassa = false;
        void SetMoneyTranferVisibility() {
            if (Meta == null) return;
            if (Meta.IsEmpty) {
                chkMoneyTransfer.Visible = true;
                return;
            }
            bool enableMoneyTransfer = true;
            if (flagproceeds == "S" && chkCassa.Checked == false) {
                enableMoneyTransfer = false;
            }
            else {
                if (flagcassa && ckbPrevSecondaria.Checked == false) {
                    enableMoneyTransfer = false;
                }
                else {
                    if (!ckbPrevPrincipale.Checked) {
                        enableMoneyTransfer = false;
                    }
                }
            }

            if (rdbVarStorno.Checked == false || enableMoneyTransfer == false) {
                chkMoneyTransfer.Visible = false;
                chkMoneyTransfer.Checked = false;
                return;
            }

            int N_plus = 0;
            int N_min = 0;
            int idtreasurer_minus=0 ;
            foreach (DataRow R in DS.finvardetail.Select()) {
                //considera solo le voci di spesa
                string filter_fin = QHC.CmpEq("idfin", R["idfin"]);
                DataRow[] Rf = DS.fin.Select(filter_fin);
                if (Rf.Length != 1) continue;
                int flag = CfgFn.GetNoNullInt32(Rf[0]["flag"]);
                if ((flag & 1) == 0) continue;
                decimal amount = CfgFn.GetNoNullDecimal(R["amount"]);
                if (amount > 0) N_plus = N_plus+1;
                if (amount < 0) {
                    if (N_min == 0) {
                        N_min = 1;
                        idtreasurer_minus = getCassiereFromIDUpb(R["idupb"]);
                    }
                    else {
                        int idtreas = getCassiereFromIDUpb(R["idupb"]);
                        if (idtreas!=idtreasurer_minus)
                            N_min = N_min + 1;
                    }
                }

            }
            if (N_plus > 0 && N_min == 1) {
                chkMoneyTransfer.Visible = true;
            }
            else {
                chkMoneyTransfer.Visible = false;
                chkMoneyTransfer.Checked = false;
            }

        }

        int getCassiereFromIDUpb(object idupb) {
            if (idupb == DBNull.Value) return 0;
            string f = QHC.CmpEq("idupb", idupb);
            if (DS.upb.Select(f).Length == 0) {
                return CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("upb", QHS.CmpEq("idupb", idupb), "idtreasurer"));
            }
            return CfgFn.GetNoNullInt32(DS.upb.Select(f)[0]["idtreasurer"]);
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
            this.txtNumProvv = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDataContabile = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDataProvv = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtProvvedimento = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbVarIniziale = new System.Windows.Forms.RadioButton();
            this.rdbVarStorno = new System.Windows.Forms.RadioButton();
            this.rdbVarAssestamento = new System.Windows.Forms.RadioButton();
            this.rdbVarNormale = new System.Windows.Forms.RadioButton();
            this.rdbVarRipartizione = new System.Windows.Forms.RadioButton();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEsercizio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupTipoPrevisione = new System.Windows.Forms.GroupBox();
            this.chkCassa = new System.Windows.Forms.CheckBox();
            this.chkCrediti = new System.Windows.Forms.CheckBox();
            this.ckbPrevSecondaria = new System.Windows.Forms.CheckBox();
            this.ckbPrevPrincipale = new System.Windows.Forms.CheckBox();
            this.txtSaldo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtNumUfficiale = new System.Windows.Forms.TextBox();
            this.chkOfficial = new System.Windows.Forms.CheckBox();
            this.gboxStato = new System.Windows.Forms.GroupBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.DS = new finvar_default.vistaForm();
            this.grpAtto = new System.Windows.Forms.GroupBox();
            this.btnScegliAtto = new System.Windows.Forms.Button();
            this.txtNact = new System.Windows.Forms.TextBox();
            this.gboxResponsabile = new System.Windows.Forms.GroupBox();
            this.txtResponsabile = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.chkMoneyTransfer = new System.Windows.Forms.CheckBox();
            this.chkDispPresunto = new System.Windows.Forms.CheckBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.grpTipoClass = new System.Windows.Forms.GroupBox();
            this.txtTipoClass = new System.Windows.Forms.TextBox();
            this.btnTipoClass = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.tabAllegati = new System.Windows.Forms.TabPage();
            this.dataGrid3 = new System.Windows.Forms.DataGrid();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
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
            this.tabRicariche = new System.Windows.Forms.TabPage();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.tabAnnotazioni = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tabDettagli = new System.Windows.Forms.TabPage();
            this.btnStornoDaCard = new System.Windows.Forms.Button();
            this.btnInserisci = new System.Windows.Forms.Button();
            this.btnModifica = new System.Windows.Forms.Button();
            this.btnElimina = new System.Windows.Forms.Button();
            this.gridDetails = new System.Windows.Forms.DataGrid();
            this.btnStornoTraUpb = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.btnSimula = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupTipoPrevisione.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.gboxStato.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.grpAtto.SuspendLayout();
            this.gboxResponsabile.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.grpTipoClass.SuspendLayout();
            this.tabAllegati.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).BeginInit();
            this.tabAttributi.SuspendLayout();
            this.gboxclass05.SuspendLayout();
            this.gboxclass04.SuspendLayout();
            this.gboxclass03.SuspendLayout();
            this.gboxclass02.SuspendLayout();
            this.gboxclass01.SuspendLayout();
            this.tabRicariche.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.tabAnnotazioni.SuspendLayout();
            this.tabDettagli.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetails)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNumProvv
            // 
            this.txtNumProvv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumProvv.Location = new System.Drawing.Point(264, 64);
            this.txtNumProvv.Name = "txtNumProvv";
            this.txtNumProvv.Size = new System.Drawing.Size(88, 20);
            this.txtNumProvv.TabIndex = 2;
            this.txtNumProvv.Tag = "finvar.nenactment";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Location = new System.Drawing.Point(261, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Numero:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDataContabile
            // 
            this.txtDataContabile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDataContabile.Location = new System.Drawing.Point(791, 99);
            this.txtDataContabile.Name = "txtDataContabile";
            this.txtDataContabile.Size = new System.Drawing.Size(101, 20);
            this.txtDataContabile.TabIndex = 8;
            this.txtDataContabile.Tag = "finvar.adate";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(788, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 16);
            this.label5.TabIndex = 18;
            this.label5.Text = "Data contabile:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDataProvv
            // 
            this.txtDataProvv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDataProvv.Location = new System.Drawing.Point(264, 26);
            this.txtDataProvv.Name = "txtDataProvv";
            this.txtDataProvv.Size = new System.Drawing.Size(88, 20);
            this.txtDataProvv.TabIndex = 1;
            this.txtDataProvv.Tag = "finvar.enactmentdate";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Location = new System.Drawing.Point(261, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "Data provvedimento:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtProvvedimento
            // 
            this.txtProvvedimento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProvvedimento.Location = new System.Drawing.Point(5, 19);
            this.txtProvvedimento.Multiline = true;
            this.txtProvvedimento.Name = "txtProvvedimento";
            this.txtProvvedimento.Size = new System.Drawing.Size(256, 66);
            this.txtProvvedimento.TabIndex = 0;
            this.txtProvvedimento.Tag = "finvar.enactment";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbVarIniziale);
            this.groupBox1.Controls.Add(this.rdbVarStorno);
            this.groupBox1.Controls.Add(this.rdbVarAssestamento);
            this.groupBox1.Controls.Add(this.rdbVarNormale);
            this.groupBox1.Controls.Add(this.rdbVarRipartizione);
            this.groupBox1.Location = new System.Drawing.Point(144, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(217, 72);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo variazione";
            // 
            // rdbVarIniziale
            // 
            this.rdbVarIniziale.AutoSize = true;
            this.rdbVarIniziale.Location = new System.Drawing.Point(110, 39);
            this.rdbVarIniziale.Name = "rdbVarIniziale";
            this.rdbVarIniziale.Size = new System.Drawing.Size(57, 17);
            this.rdbVarIniziale.TabIndex = 4;
            this.rdbVarIniziale.Tag = "finvar.variationkind:5";
            this.rdbVarIniziale.Text = "Iniziale";
            this.rdbVarIniziale.UseVisualStyleBackColor = true;
            this.rdbVarIniziale.CheckedChanged += new System.EventHandler(this.rdbVarIniziale_CheckedChanged);
            // 
            // rdbVarStorno
            // 
            this.rdbVarStorno.Location = new System.Drawing.Point(110, 20);
            this.rdbVarStorno.Name = "rdbVarStorno";
            this.rdbVarStorno.Size = new System.Drawing.Size(72, 16);
            this.rdbVarStorno.TabIndex = 3;
            this.rdbVarStorno.Tag = "finvar.variationkind:4";
            this.rdbVarStorno.Text = "Storno";
            this.rdbVarStorno.CheckedChanged += new System.EventHandler(this.rdbVarStorno_CheckedChanged);
            // 
            // rdbVarAssestamento
            // 
            this.rdbVarAssestamento.Location = new System.Drawing.Point(8, 48);
            this.rdbVarAssestamento.Name = "rdbVarAssestamento";
            this.rdbVarAssestamento.Size = new System.Drawing.Size(96, 16);
            this.rdbVarAssestamento.TabIndex = 2;
            this.rdbVarAssestamento.Tag = "finvar.variationkind:3";
            this.rdbVarAssestamento.Text = "Assestamento";
            // 
            // rdbVarNormale
            // 
            this.rdbVarNormale.Location = new System.Drawing.Point(8, 16);
            this.rdbVarNormale.Name = "rdbVarNormale";
            this.rdbVarNormale.Size = new System.Drawing.Size(96, 16);
            this.rdbVarNormale.TabIndex = 0;
            this.rdbVarNormale.Tag = "finvar.variationkind:1";
            this.rdbVarNormale.Text = "Normale";
            // 
            // rdbVarRipartizione
            // 
            this.rdbVarRipartizione.Location = new System.Drawing.Point(8, 32);
            this.rdbVarRipartizione.Name = "rdbVarRipartizione";
            this.rdbVarRipartizione.Size = new System.Drawing.Size(96, 16);
            this.rdbVarRipartizione.TabIndex = 1;
            this.rdbVarRipartizione.Tag = "finvar.variationkind:2";
            this.rdbVarRipartizione.Text = "Ripartizione";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(72, 40);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(48, 20);
            this.txtNumero.TabIndex = 2;
            this.txtNumero.Tag = "finvar.nvar";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Prot.:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Location = new System.Drawing.Point(7, 138);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(368, 72);
            this.txtDescrizione.TabIndex = 9;
            this.txtDescrizione.Tag = "finvar.description";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(7, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Descrizione:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEsercizio
            // 
            this.txtEsercizio.Location = new System.Drawing.Point(72, 16);
            this.txtEsercizio.Name = "txtEsercizio";
            this.txtEsercizio.ReadOnly = true;
            this.txtEsercizio.Size = new System.Drawing.Size(48, 20);
            this.txtEsercizio.TabIndex = 1;
            this.txtEsercizio.TabStop = false;
            this.txtEsercizio.Tag = "finvar.yvar";
            this.txtEsercizio.Text = "-";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Esercizio:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupTipoPrevisione
            // 
            this.groupTipoPrevisione.Controls.Add(this.chkCassa);
            this.groupTipoPrevisione.Controls.Add(this.chkCrediti);
            this.groupTipoPrevisione.Controls.Add(this.ckbPrevSecondaria);
            this.groupTipoPrevisione.Controls.Add(this.ckbPrevPrincipale);
            this.groupTipoPrevisione.Location = new System.Drawing.Point(367, 0);
            this.groupTipoPrevisione.Name = "groupTipoPrevisione";
            this.groupTipoPrevisione.Size = new System.Drawing.Size(295, 72);
            this.groupTipoPrevisione.TabIndex = 3;
            this.groupTipoPrevisione.TabStop = false;
            this.groupTipoPrevisione.Text = "Tipo previsione / dotazione";
            // 
            // chkCassa
            // 
            this.chkCassa.Location = new System.Drawing.Point(126, 40);
            this.chkCassa.Name = "chkCassa";
            this.chkCassa.Size = new System.Drawing.Size(167, 16);
            this.chkCassa.TabIndex = 4;
            this.chkCassa.TabStop = false;
            this.chkCassa.Tag = "finvar.flagproceeds:S:N";
            this.chkCassa.Text = "Variazione dotaz. cassa";
            this.chkCassa.CheckedChanged += new System.EventHandler(this.chkCassa_CheckedChanged);
            // 
            // chkCrediti
            // 
            this.chkCrediti.Location = new System.Drawing.Point(126, 16);
            this.chkCrediti.Name = "chkCrediti";
            this.chkCrediti.Size = new System.Drawing.Size(167, 20);
            this.chkCrediti.TabIndex = 3;
            this.chkCrediti.TabStop = false;
            this.chkCrediti.Tag = "finvar.flagcredit:S:N";
            this.chkCrediti.Text = "Variazione dotaz. crediti";
            // 
            // ckbPrevSecondaria
            // 
            this.ckbPrevSecondaria.Location = new System.Drawing.Point(16, 40);
            this.ckbPrevSecondaria.Name = "ckbPrevSecondaria";
            this.ckbPrevSecondaria.Size = new System.Drawing.Size(96, 16);
            this.ckbPrevSecondaria.TabIndex = 2;
            this.ckbPrevSecondaria.TabStop = false;
            this.ckbPrevSecondaria.Tag = "finvar.flagsecondaryprev:S:N";
            this.ckbPrevSecondaria.CheckedChanged += new System.EventHandler(this.ckbPrevSecondaria_CheckedChanged);
            // 
            // ckbPrevPrincipale
            // 
            this.ckbPrevPrincipale.Location = new System.Drawing.Point(16, 16);
            this.ckbPrevPrincipale.Name = "ckbPrevPrincipale";
            this.ckbPrevPrincipale.Size = new System.Drawing.Size(96, 20);
            this.ckbPrevPrincipale.TabIndex = 1;
            this.ckbPrevPrincipale.TabStop = false;
            this.ckbPrevPrincipale.Tag = "finvar.flagprevision:S:N";
            this.ckbPrevPrincipale.CheckedChanged += new System.EventHandler(this.ckbPrevPrincipale_CheckedChanged);
            // 
            // txtSaldo
            // 
            this.txtSaldo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSaldo.Location = new System.Drawing.Point(791, 193);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.ReadOnly = true;
            this.txtSaldo.Size = new System.Drawing.Size(104, 20);
            this.txtSaldo.TabIndex = 23;
            this.txtSaldo.TabStop = false;
            this.txtSaldo.Tag = "";
            this.txtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.Location = new System.Drawing.Point(788, 174);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 16);
            this.label8.TabIndex = 22;
            this.label8.Text = "Saldo:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtProvvedimento);
            this.groupBox2.Controls.Add(this.txtDataProvv);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtNumProvv);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(382, 125);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(396, 90);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Provvedimento";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtEsercizio);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtNumero);
            this.groupBox3.Location = new System.Drawing.Point(8, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(128, 72);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Variazione";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtNumUfficiale);
            this.groupBox4.Controls.Add(this.chkOfficial);
            this.groupBox4.Location = new System.Drawing.Point(8, 78);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(279, 40);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            // 
            // txtNumUfficiale
            // 
            this.txtNumUfficiale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumUfficiale.Location = new System.Drawing.Point(200, 12);
            this.txtNumUfficiale.Name = "txtNumUfficiale";
            this.txtNumUfficiale.Size = new System.Drawing.Size(71, 20);
            this.txtNumUfficiale.TabIndex = 1;
            this.txtNumUfficiale.Tag = "finvar.nofficial";
            // 
            // chkOfficial
            // 
            this.chkOfficial.AutoSize = true;
            this.chkOfficial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkOfficial.Location = new System.Drawing.Point(11, 15);
            this.chkOfficial.Name = "chkOfficial";
            this.chkOfficial.Size = new System.Drawing.Size(183, 17);
            this.chkOfficial.TabIndex = 0;
            this.chkOfficial.Tag = "finvar.official:S:N";
            this.chkOfficial.Text = "Variazione Ufficiale Numero";
            this.chkOfficial.UseVisualStyleBackColor = true;
            this.chkOfficial.CheckedChanged += new System.EventHandler(this.chkOfficial_CheckedChanged);
            // 
            // gboxStato
            // 
            this.gboxStato.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxStato.Controls.Add(this.cmbStatus);
            this.gboxStato.Location = new System.Drawing.Point(666, 0);
            this.gboxStato.Name = "gboxStato";
            this.gboxStato.Size = new System.Drawing.Size(289, 40);
            this.gboxStato.TabIndex = 4;
            this.gboxStato.TabStop = false;
            this.gboxStato.Text = "Stato";
            // 
            // cmbStatus
            // 
            this.cmbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStatus.DataSource = this.DS.finvarstatus;
            this.cmbStatus.DisplayMember = "description";
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Location = new System.Drawing.Point(6, 15);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(270, 21);
            this.cmbStatus.TabIndex = 43;
            this.cmbStatus.Tag = "finvar.idfinvarstatus?finvarview.idfinvarstatus";
            this.cmbStatus.ValueMember = "idfinvarstatus";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // grpAtto
            // 
            this.grpAtto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAtto.Controls.Add(this.btnScegliAtto);
            this.grpAtto.Controls.Add(this.txtNact);
            this.grpAtto.Location = new System.Drawing.Point(666, 43);
            this.grpAtto.Name = "grpAtto";
            this.grpAtto.Size = new System.Drawing.Size(289, 34);
            this.grpAtto.TabIndex = 5;
            this.grpAtto.TabStop = false;
            this.grpAtto.Tag = "AutoChoose.txtNact.default";
            // 
            // btnScegliAtto
            // 
            this.btnScegliAtto.Location = new System.Drawing.Point(6, 7);
            this.btnScegliAtto.Name = "btnScegliAtto";
            this.btnScegliAtto.Size = new System.Drawing.Size(133, 23);
            this.btnScegliAtto.TabIndex = 13;
            this.btnScegliAtto.TabStop = false;
            this.btnScegliAtto.Tag = "choose.enactment.default.(idenactmentstatus=\'1\')";
            this.btnScegliAtto.Text = "Atto Amministrativo";
            this.btnScegliAtto.UseVisualStyleBackColor = true;
            // 
            // txtNact
            // 
            this.txtNact.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNact.Location = new System.Drawing.Point(151, 10);
            this.txtNact.Name = "txtNact";
            this.txtNact.Size = new System.Drawing.Size(128, 20);
            this.txtNact.TabIndex = 10;
            this.txtNact.Tag = "enactment.nenactment?finvarview.enactmentnumber";
            // 
            // gboxResponsabile
            // 
            this.gboxResponsabile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxResponsabile.Controls.Add(this.txtResponsabile);
            this.gboxResponsabile.Controls.Add(this.button4);
            this.gboxResponsabile.Location = new System.Drawing.Point(293, 78);
            this.gboxResponsabile.Name = "gboxResponsabile";
            this.gboxResponsabile.Size = new System.Drawing.Size(485, 40);
            this.gboxResponsabile.TabIndex = 7;
            this.gboxResponsabile.TabStop = false;
            this.gboxResponsabile.Tag = "AutoChoose.txtResponsabile.default.(financeactive=\'S\')";
            // 
            // txtResponsabile
            // 
            this.txtResponsabile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResponsabile.Location = new System.Drawing.Point(114, 14);
            this.txtResponsabile.Name = "txtResponsabile";
            this.txtResponsabile.Size = new System.Drawing.Size(365, 20);
            this.txtResponsabile.TabIndex = 0;
            this.txtResponsabile.Tag = "manager.title?x";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(7, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(104, 23);
            this.button4.TabIndex = 25;
            this.button4.TabStop = false;
            this.button4.Tag = "choose.manager.default";
            this.button4.Text = "Responsabile";
            // 
            // chkMoneyTransfer
            // 
            this.chkMoneyTransfer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkMoneyTransfer.AutoSize = true;
            this.chkMoneyTransfer.Location = new System.Drawing.Point(791, 131);
            this.chkMoneyTransfer.Name = "chkMoneyTransfer";
            this.chkMoneyTransfer.Size = new System.Drawing.Size(99, 17);
            this.chkMoneyTransfer.TabIndex = 11;
            this.chkMoneyTransfer.Tag = "finvar.moneytransfer:S:N";
            this.chkMoneyTransfer.Text = "Storno di cassa";
            this.chkMoneyTransfer.UseVisualStyleBackColor = true;
            // 
            // chkDispPresunto
            // 
            this.chkDispPresunto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkDispPresunto.AutoSize = true;
            this.chkDispPresunto.Location = new System.Drawing.Point(791, 151);
            this.chkDispPresunto.Name = "chkDispPresunto";
            this.chkDispPresunto.Size = new System.Drawing.Size(106, 17);
            this.chkDispPresunto.TabIndex = 24;
            this.chkDispPresunto.Tag = "finvar.varflag:0";
            this.chkDispPresunto.Text = "Avanzo presunto";
            this.chkDispPresunto.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grpTipoClass);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.textBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(937, 270);
            this.tabPage1.TabIndex = 5;
            this.tabPage1.Text = "Altre informazioni";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // grpTipoClass
            // 
            this.grpTipoClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpTipoClass.Controls.Add(this.txtTipoClass);
            this.grpTipoClass.Controls.Add(this.btnTipoClass);
            this.grpTipoClass.Location = new System.Drawing.Point(6, 48);
            this.grpTipoClass.Name = "grpTipoClass";
            this.grpTipoClass.Size = new System.Drawing.Size(485, 40);
            this.grpTipoClass.TabIndex = 2;
            this.grpTipoClass.TabStop = false;
            this.grpTipoClass.Tag = "AutoChoose.txtTipoClass.default";
            // 
            // txtTipoClass
            // 
            this.txtTipoClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTipoClass.Location = new System.Drawing.Point(114, 14);
            this.txtTipoClass.Name = "txtTipoClass";
            this.txtTipoClass.Size = new System.Drawing.Size(365, 20);
            this.txtTipoClass.TabIndex = 0;
            this.txtTipoClass.Tag = "finvarkind.description?x";
            // 
            // btnTipoClass
            // 
            this.btnTipoClass.Location = new System.Drawing.Point(7, 12);
            this.btnTipoClass.Name = "btnTipoClass";
            this.btnTipoClass.Size = new System.Drawing.Size(104, 23);
            this.btnTipoClass.TabIndex = 25;
            this.btnTipoClass.TabStop = false;
            this.btnTipoClass.Tag = "choose.finvarkind.default";
            this.btnTipoClass.Text = "Classificazione";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.Location = new System.Drawing.Point(32, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 18);
            this.label10.TabIndex = 46;
            this.label10.Text = "Limite:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Location = new System.Drawing.Point(115, 16);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(145, 20);
            this.textBox3.TabIndex = 1;
            this.textBox3.Tag = "finvar.limit";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tabAllegati
            // 
            this.tabAllegati.Controls.Add(this.dataGrid3);
            this.tabAllegati.Controls.Add(this.button2);
            this.tabAllegati.Controls.Add(this.button3);
            this.tabAllegati.Controls.Add(this.button1);
            this.tabAllegati.Location = new System.Drawing.Point(4, 22);
            this.tabAllegati.Name = "tabAllegati";
            this.tabAllegati.Padding = new System.Windows.Forms.Padding(3);
            this.tabAllegati.Size = new System.Drawing.Size(937, 270);
            this.tabAllegati.TabIndex = 3;
            this.tabAllegati.Text = "Allegati";
            this.tabAllegati.UseVisualStyleBackColor = true;
            // 
            // dataGrid3
            // 
            this.dataGrid3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid3.DataMember = "";
            this.dataGrid3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid3.Location = new System.Drawing.Point(94, 6);
            this.dataGrid3.Name = "dataGrid3";
            this.dataGrid3.ReadOnly = true;
            this.dataGrid3.Size = new System.Drawing.Size(840, 258);
            this.dataGrid3.TabIndex = 27;
            this.dataGrid3.Tag = "finvarattachment.default.default";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(13, 90);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(68, 22);
            this.button2.TabIndex = 26;
            this.button2.Tag = "delete";
            this.button2.Text = "Elimina";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(13, 62);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(69, 22);
            this.button3.TabIndex = 25;
            this.button3.TabStop = false;
            this.button3.Tag = "edit.default";
            this.button3.Text = "Modifica...";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 22);
            this.button1.TabIndex = 24;
            this.button1.TabStop = false;
            this.button1.Tag = "insert.default";
            this.button1.Text = "Inserisci...";
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
            this.tabAttributi.Size = new System.Drawing.Size(937, 270);
            this.tabAttributi.TabIndex = 4;
            this.tabAttributi.Text = "Attributi";
            this.tabAttributi.UseVisualStyleBackColor = true;
            // 
            // gboxclass05
            // 
            this.gboxclass05.Controls.Add(this.txtCodice05);
            this.gboxclass05.Controls.Add(this.btnCodice05);
            this.gboxclass05.Controls.Add(this.txtDenom05);
            this.gboxclass05.Location = new System.Drawing.Point(499, 99);
            this.gboxclass05.Name = "gboxclass05";
            this.gboxclass05.Size = new System.Drawing.Size(434, 82);
            this.gboxclass05.TabIndex = 23;
            this.gboxclass05.TabStop = false;
            this.gboxclass05.Tag = "";
            this.gboxclass05.Text = "Classificazione 5";
            // 
            // txtCodice05
            // 
            this.txtCodice05.Location = new System.Drawing.Point(9, 55);
            this.txtCodice05.Name = "txtCodice05";
            this.txtCodice05.Size = new System.Drawing.Size(417, 20);
            this.txtCodice05.TabIndex = 6;
            // 
            // btnCodice05
            // 
            this.btnCodice05.Location = new System.Drawing.Point(8, 26);
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
            this.txtDenom05.Location = new System.Drawing.Point(188, 8);
            this.txtDenom05.Multiline = true;
            this.txtDenom05.Name = "txtDenom05";
            this.txtDenom05.ReadOnly = true;
            this.txtDenom05.Size = new System.Drawing.Size(238, 41);
            this.txtDenom05.TabIndex = 3;
            this.txtDenom05.TabStop = false;
            this.txtDenom05.Tag = "sorting05.description";
            // 
            // gboxclass04
            // 
            this.gboxclass04.Controls.Add(this.txtCodice04);
            this.gboxclass04.Controls.Add(this.btnCodice04);
            this.gboxclass04.Controls.Add(this.txtDenom04);
            this.gboxclass04.Location = new System.Drawing.Point(499, 6);
            this.gboxclass04.Name = "gboxclass04";
            this.gboxclass04.Size = new System.Drawing.Size(434, 86);
            this.gboxclass04.TabIndex = 22;
            this.gboxclass04.TabStop = false;
            this.gboxclass04.Tag = "";
            this.gboxclass04.Text = "Classificazione 4";
            // 
            // txtCodice04
            // 
            this.txtCodice04.Location = new System.Drawing.Point(6, 60);
            this.txtCodice04.Name = "txtCodice04";
            this.txtCodice04.Size = new System.Drawing.Size(420, 20);
            this.txtCodice04.TabIndex = 6;
            // 
            // btnCodice04
            // 
            this.btnCodice04.Location = new System.Drawing.Point(6, 31);
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
            this.txtDenom04.Location = new System.Drawing.Point(188, 8);
            this.txtDenom04.Multiline = true;
            this.txtDenom04.Name = "txtDenom04";
            this.txtDenom04.ReadOnly = true;
            this.txtDenom04.Size = new System.Drawing.Size(238, 50);
            this.txtDenom04.TabIndex = 3;
            this.txtDenom04.TabStop = false;
            this.txtDenom04.Tag = "sorting04.description";
            // 
            // gboxclass03
            // 
            this.gboxclass03.Controls.Add(this.txtCodice03);
            this.gboxclass03.Controls.Add(this.btnCodice03);
            this.gboxclass03.Controls.Add(this.txtDenom03);
            this.gboxclass03.Location = new System.Drawing.Point(6, 180);
            this.gboxclass03.Name = "gboxclass03";
            this.gboxclass03.Size = new System.Drawing.Size(486, 88);
            this.gboxclass03.TabIndex = 20;
            this.gboxclass03.TabStop = false;
            this.gboxclass03.Tag = "";
            this.gboxclass03.Text = "Classificazione 3";
            // 
            // txtCodice03
            // 
            this.txtCodice03.Location = new System.Drawing.Point(9, 62);
            this.txtCodice03.Name = "txtCodice03";
            this.txtCodice03.Size = new System.Drawing.Size(469, 20);
            this.txtCodice03.TabIndex = 6;
            // 
            // btnCodice03
            // 
            this.btnCodice03.Location = new System.Drawing.Point(9, 35);
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
            this.txtDenom03.Location = new System.Drawing.Point(187, 8);
            this.txtDenom03.Multiline = true;
            this.txtDenom03.Name = "txtDenom03";
            this.txtDenom03.ReadOnly = true;
            this.txtDenom03.Size = new System.Drawing.Size(291, 50);
            this.txtDenom03.TabIndex = 3;
            this.txtDenom03.TabStop = false;
            this.txtDenom03.Tag = "sorting03.description";
            // 
            // gboxclass02
            // 
            this.gboxclass02.Controls.Add(this.txtCodice02);
            this.gboxclass02.Controls.Add(this.btnCodice02);
            this.gboxclass02.Controls.Add(this.txtDenom02);
            this.gboxclass02.Location = new System.Drawing.Point(7, 93);
            this.gboxclass02.Name = "gboxclass02";
            this.gboxclass02.Size = new System.Drawing.Size(486, 88);
            this.gboxclass02.TabIndex = 21;
            this.gboxclass02.TabStop = false;
            this.gboxclass02.Tag = "";
            this.gboxclass02.Text = "Classificazione 2";
            // 
            // txtCodice02
            // 
            this.txtCodice02.Location = new System.Drawing.Point(6, 61);
            this.txtCodice02.Name = "txtCodice02";
            this.txtCodice02.Size = new System.Drawing.Size(474, 20);
            this.txtCodice02.TabIndex = 6;
            // 
            // btnCodice02
            // 
            this.btnCodice02.Location = new System.Drawing.Point(8, 32);
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
            this.txtDenom02.Location = new System.Drawing.Point(187, 6);
            this.txtDenom02.Multiline = true;
            this.txtDenom02.Name = "txtDenom02";
            this.txtDenom02.ReadOnly = true;
            this.txtDenom02.Size = new System.Drawing.Size(293, 52);
            this.txtDenom02.TabIndex = 3;
            this.txtDenom02.TabStop = false;
            this.txtDenom02.Tag = "sorting02.description";
            // 
            // gboxclass01
            // 
            this.gboxclass01.Controls.Add(this.txtCodice01);
            this.gboxclass01.Controls.Add(this.btnCodice01);
            this.gboxclass01.Controls.Add(this.txtDenom01);
            this.gboxclass01.Location = new System.Drawing.Point(7, 4);
            this.gboxclass01.Name = "gboxclass01";
            this.gboxclass01.Size = new System.Drawing.Size(486, 88);
            this.gboxclass01.TabIndex = 19;
            this.gboxclass01.TabStop = false;
            this.gboxclass01.Tag = "";
            this.gboxclass01.Text = "Classificazione 1";
            // 
            // txtCodice01
            // 
            this.txtCodice01.Location = new System.Drawing.Point(6, 62);
            this.txtCodice01.Name = "txtCodice01";
            this.txtCodice01.Size = new System.Drawing.Size(474, 20);
            this.txtCodice01.TabIndex = 5;
            // 
            // btnCodice01
            // 
            this.btnCodice01.Location = new System.Drawing.Point(6, 33);
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
            this.txtDenom01.Location = new System.Drawing.Point(187, 8);
            this.txtDenom01.Multiline = true;
            this.txtDenom01.Name = "txtDenom01";
            this.txtDenom01.ReadOnly = true;
            this.txtDenom01.Size = new System.Drawing.Size(293, 52);
            this.txtDenom01.TabIndex = 3;
            this.txtDenom01.TabStop = false;
            this.txtDenom01.Tag = "sorting01.description";
            // 
            // tabRicariche
            // 
            this.tabRicariche.Controls.Add(this.dataGrid2);
            this.tabRicariche.Location = new System.Drawing.Point(4, 22);
            this.tabRicariche.Name = "tabRicariche";
            this.tabRicariche.Padding = new System.Windows.Forms.Padding(3);
            this.tabRicariche.Size = new System.Drawing.Size(937, 270);
            this.tabRicariche.TabIndex = 2;
            this.tabRicariche.Text = "Ricariche Card";
            this.tabRicariche.UseVisualStyleBackColor = true;
            // 
            // dataGrid2
            // 
            this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid2.DataMember = "";
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(19, 6);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.Size = new System.Drawing.Size(897, 252);
            this.dataGrid2.TabIndex = 14;
            this.dataGrid2.Tag = "lcardvarview.cardcollegata";
            // 
            // tabAnnotazioni
            // 
            this.tabAnnotazioni.Controls.Add(this.label4);
            this.tabAnnotazioni.Controls.Add(this.textBox1);
            this.tabAnnotazioni.Controls.Add(this.textBox4);
            this.tabAnnotazioni.Controls.Add(this.label11);
            this.tabAnnotazioni.Location = new System.Drawing.Point(4, 22);
            this.tabAnnotazioni.Name = "tabAnnotazioni";
            this.tabAnnotazioni.Padding = new System.Windows.Forms.Padding(3);
            this.tabAnnotazioni.Size = new System.Drawing.Size(937, 270);
            this.tabAnnotazioni.TabIndex = 0;
            this.tabAnnotazioni.Text = "Annotazioni";
            this.tabAnnotazioni.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 51;
            this.label4.Text = "Annotazioni ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(6, 110);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(925, 144);
            this.textBox1.TabIndex = 2;
            this.textBox1.Tag = "finvar.annotation";
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.Location = new System.Drawing.Point(6, 19);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(925, 59);
            this.textBox4.TabIndex = 1;
            this.textBox4.Tag = "finvar.reason";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(3, 3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 16);
            this.label11.TabIndex = 49;
            this.label11.Text = "Motivazione";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabDettagli
            // 
            this.tabDettagli.Controls.Add(this.btnSimula);
            this.tabDettagli.Controls.Add(this.btnStornoDaCard);
            this.tabDettagli.Controls.Add(this.btnInserisci);
            this.tabDettagli.Controls.Add(this.btnModifica);
            this.tabDettagli.Controls.Add(this.btnElimina);
            this.tabDettagli.Controls.Add(this.gridDetails);
            this.tabDettagli.Controls.Add(this.btnStornoTraUpb);
            this.tabDettagli.Location = new System.Drawing.Point(4, 22);
            this.tabDettagli.Name = "tabDettagli";
            this.tabDettagli.Padding = new System.Windows.Forms.Padding(3);
            this.tabDettagli.Size = new System.Drawing.Size(937, 270);
            this.tabDettagli.TabIndex = 1;
            this.tabDettagli.Text = "Elenco dettagli";
            this.tabDettagli.UseVisualStyleBackColor = true;
            // 
            // btnStornoDaCard
            // 
            this.btnStornoDaCard.Location = new System.Drawing.Point(6, 156);
            this.btnStornoDaCard.Name = "btnStornoDaCard";
            this.btnStornoDaCard.Size = new System.Drawing.Size(86, 42);
            this.btnStornoDaCard.TabIndex = 16;
            this.btnStornoDaCard.TabStop = false;
            this.btnStornoDaCard.Text = "Inserisci storno da Card";
            this.btnStornoDaCard.UseVisualStyleBackColor = true;
            this.btnStornoDaCard.Click += new System.EventHandler(this.btnStornoDaCard_Click);
            // 
            // btnInserisci
            // 
            this.btnInserisci.Location = new System.Drawing.Point(6, 20);
            this.btnInserisci.Name = "btnInserisci";
            this.btnInserisci.Size = new System.Drawing.Size(86, 26);
            this.btnInserisci.TabIndex = 12;
            this.btnInserisci.TabStop = false;
            this.btnInserisci.Tag = "insert.single";
            this.btnInserisci.Text = "Inserisci";
            // 
            // btnModifica
            // 
            this.btnModifica.Location = new System.Drawing.Point(6, 52);
            this.btnModifica.Name = "btnModifica";
            this.btnModifica.Size = new System.Drawing.Size(86, 26);
            this.btnModifica.TabIndex = 13;
            this.btnModifica.TabStop = false;
            this.btnModifica.Tag = "edit.single";
            this.btnModifica.Text = "Modifica";
            // 
            // btnElimina
            // 
            this.btnElimina.Location = new System.Drawing.Point(6, 84);
            this.btnElimina.Name = "btnElimina";
            this.btnElimina.Size = new System.Drawing.Size(86, 26);
            this.btnElimina.TabIndex = 14;
            this.btnElimina.TabStop = false;
            this.btnElimina.Tag = "delete";
            this.btnElimina.Text = "Elimina";
            // 
            // gridDetails
            // 
            this.gridDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDetails.DataMember = "";
            this.gridDetails.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridDetails.Location = new System.Drawing.Point(98, 6);
            this.gridDetails.Name = "gridDetails";
            this.gridDetails.Size = new System.Drawing.Size(830, 258);
            this.gridDetails.TabIndex = 13;
            this.gridDetails.Tag = "finvardetail.default.single";
            // 
            // btnStornoTraUpb
            // 
            this.btnStornoTraUpb.Location = new System.Drawing.Point(6, 114);
            this.btnStornoTraUpb.Name = "btnStornoTraUpb";
            this.btnStornoTraUpb.Size = new System.Drawing.Size(86, 38);
            this.btnStornoTraUpb.TabIndex = 15;
            this.btnStornoTraUpb.TabStop = false;
            this.btnStornoTraUpb.Text = "Inserisci storno tra upb";
            this.btnStornoTraUpb.UseVisualStyleBackColor = true;
            this.btnStornoTraUpb.Click += new System.EventHandler(this.btnStornoTraUpb_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabDettagli);
            this.tabControl1.Controls.Add(this.tabAnnotazioni);
            this.tabControl1.Controls.Add(this.tabRicariche);
            this.tabControl1.Controls.Add(this.tabAttributi);
            this.tabControl1.Controls.Add(this.tabAllegati);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(10, 221);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(945, 296);
            this.tabControl1.TabIndex = 12;
            this.tabControl1.TabStop = false;
            // 
            // btnSimula
            // 
            this.btnSimula.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSimula.Location = new System.Drawing.Point(3, 220);
            this.btnSimula.Name = "btnSimula";
            this.btnSimula.Size = new System.Drawing.Size(89, 44);
            this.btnSimula.TabIndex = 36;
            this.btnSimula.Tag = "";
            this.btnSimula.Text = "Simula approvazione";
            this.btnSimula.Click += new System.EventHandler(this.btnSimula_Click);
            // 
            // Frm_finvar_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(967, 521);
            this.Controls.Add(this.chkDispPresunto);
            this.Controls.Add(this.chkMoneyTransfer);
            this.Controls.Add(this.gboxResponsabile);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.grpAtto);
            this.Controls.Add(this.gboxStato);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtDescrizione);
            this.Controls.Add(this.groupTipoPrevisione);
            this.Controls.Add(this.txtDataContabile);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSaldo);
            this.Controls.Add(this.label8);
            this.Name = "Frm_finvar_default";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Variazione di previsione annuale";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupTipoPrevisione.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.gboxStato.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.grpAtto.ResumeLayout(false);
            this.grpAtto.PerformLayout();
            this.gboxResponsabile.ResumeLayout(false);
            this.gboxResponsabile.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.grpTipoClass.ResumeLayout(false);
            this.grpTipoClass.PerformLayout();
            this.tabAllegati.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).EndInit();
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
            this.tabRicariche.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            this.tabAnnotazioni.ResumeLayout(false);
            this.tabAnnotazioni.PerformLayout();
            this.tabDettagli.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDetails)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        public void MetaData_BeforePost() {
            if (DS.finvar.Rows.Count == 0) return;

            // Add - Invio Mail al cambio stato
            DataRow currRow = DS.finvar.Rows[0];
            DoSendMail = false;
            if (currRow.RowState != DataRowState.Deleted) {
                CurrentStatus = CfgFn.GetNoNullInt32(currRow["idfinvarstatus"]);
                int OriginalStatus;
                if (!Meta.InsertMode)
                    OriginalStatus = CfgFn.GetNoNullInt32(currRow["idfinvarstatus", DataRowVersion.Original]);
                else
                    OriginalStatus = CurrentStatus;


                if (CurrentStatus != OriginalStatus && (CurrentStatus == 3 || CurrentStatus == 4 || CurrentStatus == 5 || CurrentStatus == 6))
                    DoSendMail = true;
                else
                    DoSendMail = false;
            }
        }

        //se lo stato è Edit e ci sono modifiche in finvardetail su idfin/idupb/idunderwriting,
        //non deve essere possibile approvare la variazione
        bool DettaglioModificato() {
            if (DS.finvardetail.Rows.Count == 0) return false;
            foreach (DataRow rDettaglio in DS.finvardetail.Rows) {
                if (rDettaglio.RowState == DataRowState.Modified) {
                    if (!rDettaglio["idfin", DataRowVersion.Original].Equals(rDettaglio["idfin", DataRowVersion.Current]))
                        return true;
                    if (!rDettaglio["idupb", DataRowVersion.Original].Equals(rDettaglio["idupb", DataRowVersion.Current]))
                        return true;
                    if (!rDettaglio["idunderwriting", DataRowVersion.Original].Equals(rDettaglio["idunderwriting", DataRowVersion.Current]))
                        return true;
                }
            }
            return false;
        }

        public void MetaData_AfterPost() {
            if (DoSendMail) {
                DataRow CurrentRow = DS.finvar.Rows[0];

                string MsgBody = "";


                SendMail SM = new SendMail();
                SM.UseSMTPLoginAsFromField = true;
                SM.Conn = Meta.Conn;

                if (CurrentStatus == 5) {
                    // Ciclo sui dettagli variazione card
                    foreach (DataRow rCardVar in DS.lcardvarview.Rows) {
                        object idlcard = rCardVar["idlcard"];

                        string filterCard = QHS.CmpEq("idlcard", idlcard);
                        DataTable TCard = Meta.Conn.RUN_SELECT("lcard", "*", null, filterCard, null, false);

                        if (TCard == null || TCard.Rows.Count == 0) continue;

                        MsgBody = "Sulla Card numero " + TCard.Rows[0]["idlcard"] + " intestata a " + TCard.Rows[0]["title"] + "\r\n";
                        MsgBody += "è stata effettuata una ricarica di importo pari a " + CfgFn.GetNoNullDecimal(rCardVar["amount"]).ToString("c") + " come richiesto .\r\n";

                        object mailtoMan = rCardVar["email"];

                        if (mailtoMan == DBNull.Value) continue;
                        SM.To = mailtoMan.ToString();
                        SM.Subject = "Ricarica Card n° " + TCard.Rows[0]["idlcard"] + " effettuata";
                        SM.MessageBody = MsgBody;

                        if (!SM.Send()) {
                            if (SM.ErrorMessage != "") show(SM.ErrorMessage, "Errore");
                        }
                    }
                }

                if (CurrentRow["idman"] == DBNull.Value) return;
                int idman = CfgFn.GetNoNullInt32(CurrentRow["idman"]);
                string filter = QHS.CmpEq("idman", idman);

                DataTable T = Meta.Conn.RUN_SELECT("manager", "*", null, filter, null, false);
                if (T.Rows[0]["wantswarn"].ToString().ToUpper() != "S") return;

                string mailto = T.Rows[0]["email"].ToString();
                if (mailto == "") return;
                string currstatustext = "";
                switch (CurrentStatus) {
                    case 3:
                        currstatustext = "Da Correggere";
                        break;
                    case 4:
                        currstatustext = "Inserita";
                        break;
                    case 5:
                        currstatustext = "Approvato";
                        break;
                    case 6:
                        currstatustext = "Annullato";
                        break;
                }
                SM.To = mailto;
                MsgBody = "La variazione di bilancio numero " + CurrentRow["nvar"] + " relativa all'esercizio " + CurrentRow["yvar"] + "\r\n";
                MsgBody += "E' passata nello stato '" + currstatustext + "'.\r\n";

                if (true) { //CurrentStatus == 3) {
                    MsgBody += " Dettagli:\r\n";
                    if (CurrentRow["description"].ToString() != "") MsgBody += CurrentRow["description"] + "\r\n";
                    if (CurrentRow["annotation"].ToString() != "") MsgBody += CurrentRow["annotation"] + "\r\n";
                    MsgBody += "\r\n\r\n";
                    foreach (var RD in DS.finvardetail.Select()) {
                        MsgBody += GetTextForFinVarDetail(RD);
                        if (RD["description"].ToString() != "") MsgBody += RD["description"] + "\r\n";
                        if (RD["annotation"].ToString() != "") MsgBody += RD["annotation"] + "\r\n";
                    }
                    MsgBody += "\r\n";

                }
                SM.Subject = "Notifica cambiamento di stato variazione di bilancio";
                SM.MessageBody = MsgBody;

                if (!SM.Send()) {
                    if (SM.ErrorMessage != "") show(SM.ErrorMessage, @"Errore");
                }


                DoSendMail = false;
            }

        }


        string GetTextForFinVarDetail(DataRow R) {
            string S = "";
            object idfin = R["idfin"];
            DataRow Fin = DS.fin.Select(QHC.CmpEq("idfin", idfin))[0];
            S += "Voce Bilancio " + Fin["codefin"].ToString() + " - " + Fin["title"].ToString() + "\r\n";
            object idupb = R["idupb"];
            DataRow Upb = DS.upb.Select(QHC.CmpEq("idupb", idupb))[0];
            S += "UPB " + Upb["codeupb"].ToString() + " - " + Upb["title"].ToString() + "\r\n";
            S += "Importo variazione:" + CfgFn.GetNoNullDecimal(R["amount"]).ToString("c") + "\r\n"; ;
            return S;

        }


        public void MetaData_AfterClear() {
            txtEsercizio.Text = Meta.Conn.GetEsercizio().ToString();
            txtSaldo.Text = "";
            groupTipoPrevisione.Enabled = true;
            gboxStato.Enabled = true;

            chkCrediti.Checked = true;
            chkCassa.Checked = true;
            ckbPrevPrincipale.Checked = true;
            ckbPrevSecondaria.Checked = true;
            chkOfficial.CheckState = CheckState.Indeterminate;
            txtNumUfficiale.ReadOnly = false;
            DisabilitaUfficiale(false);
            chkCrediti.Visible = true;
            chkCassa.Visible = true;
            btnStornoTraUpb.Enabled = false;
            btnStornoDaCard.Enabled = false;
            grpAtto.Tag = "AutoChoose.txtNact.default";
            btnScegliAtto.Tag = "choose.enactment.default";
            Meta.SetAutoMode(grpAtto);

            Meta.UnMarkTableAsNotEntityChild(DS.lcardvarview);
            EnableDisableVariationKind();
            SetMoneyTranferVisibility();
            //cmbStatus.Enabled = true;
            rimuoviColonneSimulazione();
            visualizzaBtnSimulazione();

        }
        CQueryHelper QHC;
        QueryHelper QHS;
        DataAccess Conn;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            DS.finvarstatus.ExtendedProperties["sort_by"] = "idfinvarstatus";
            GetData.SetStaticFilter(DS.enactment, QHS.CmpEq("yenactment", Meta.Conn.GetSys("esercizio")));

            object default_idfinvarstatus = Conn.DO_READ_VALUE("config",
                QHS.CmpEq("ayear", Meta.GetSys("esercizio")), "default_idfinvarstatus");
            if (default_idfinvarstatus == null) {
                show("In configurazione annuale non è stata impostato il valore iniziale per le variazioni di bilancio.",
                    "Avviso");
                default_idfinvarstatus = 5;
            }
            MetaData.SetDefault(DS.finvar, "idfinvarstatus", default_idfinvarstatus);



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
        }

        object GetCtrlByName(string  ctrlName) {
            System.Reflection.FieldInfo Ctrl = this.GetType().GetField(ctrlName);
            if (Ctrl == null) return null;
            //if (!typeof(Label).IsAssignableFrom(Ctrl.FieldType)) return null;                         
            //Label L =  (Label) Ctrl.GetValue(this);                        
            //return L;
            return Ctrl.GetValue(this);
        }

        void SetGBoxClass0(int num, object sortingkind) {
            string nums = num.ToString();
            if (sortingkind == DBNull.Value) {
                GroupBox G = (GroupBox)GetCtrlByName("gboxclass0" + nums);
                G.Visible = false;
                ComboBox C = (ComboBox)GetCtrlByName("cmbCodice0" + nums);
                C.Tag = null;
                C.DataSource = null;
            }
            else {
                string filter = QHS.CmpEq("idsorkind", sortingkind);
                GetData.SetStaticFilter(DS.Tables["sorting0" + nums], filter);
                GroupBox gboxclass = (GroupBox)GetCtrlByName("gboxclass0" + nums);
                Button btnCodice = (Button)GetCtrlByName("btnCodice0" + nums);
                //gboxclass.Tag = "AutoManage.txtCodice0" + nums + ".tree." + filter;
                string title = Conn.DO_READ_VALUE("sortingkind", filter, "description").ToString();
                gboxclass.Text = title;
                btnCodice.Tag = "manage.sorting0" + nums + ".tree." + filter;
                DS.Tables["sorting0" + nums].ExtendedProperties[MetaData.ExtraParams] = filter;
            }
        }
        bool flagcassa = false;

        public void MetaData_AfterActivation() {
            //sets labels for RadioButtons, reading them from persbilancio

            string SqlFilter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            GetData.CacheTable(DS.config, SqlFilter, null, false);
            Meta.myGetData.ReadCached();
            if (DS.Tables["config"].Rows.Count == 0) return;
            DataRow R = DS.Tables["config"].Rows[0];
            flagcredit = Meta.GetSys("flagcredit").ToString().ToUpper();
            flagproceeds = Meta.GetSys("flagproceeds").ToString().ToUpper();
            string nomeprevsecondaria = CfgFn.NomePrevisioneSecondaria(Meta.Conn);
            solaCassa = R["fin_kind"].ToString() == "2";
            if (nomeprevsecondaria == null) {
                ckbPrevSecondaria.Tag = "";
                ckbPrevPrincipale.Checked = true;
                ckbPrevSecondaria.Visible = false;
                flagcassa = false;
            }
            else {
                ckbPrevSecondaria.Text = nomeprevsecondaria;
                flagcassa = true;
            }

            ckbPrevPrincipale.Text = CfgFn.NomePrevisionePrincipale(Meta.Conn);
            btnStornoTraUpb.BackColor = formcolors.GridButtonBackColor();
            btnStornoTraUpb.ForeColor = formcolors.GridButtonForeColor();
            btnStornoDaCard.BackColor = formcolors.GridButtonBackColor();
            btnStornoDaCard.ForeColor = formcolors.GridButtonForeColor();

            if (R["idfin_store"] == DBNull.Value) {
                btnStornoDaCard.Visible = false;
            }
            else {
                btnStornoDaCard.Visible = true;
            }

        }

        private object CalcID(DataRow R, DataColumn C, DataAccess Conn) {
            // I selettori del campo NOFFICIAL sono YVAR e OFFICIAL
            int yvar = CfgFn.GetNoNullInt32(R["yvar"]);
            string official = R["official"].ToString().ToUpper();
            // Se la variazione non è ufficiale non calcolo il campo
            if (official != "S") {
                return null;
            }

            string filter = QHS.AppAnd(QHS.CmpEq("yvar", yvar), QHS.CmpEq("official", 'S'));
            object nOff = Conn.DO_READ_VALUE("finvar", filter, "MAX(nofficial)");
            if (nOff == null) return null;

            int nOfficial = 1 + CfgFn.GetNoNullInt32(nOff);

            return nOfficial;
        }

        private void DisabilitaUfficiale(bool disable) {
            if (disable || Meta.InsertMode) {
                txtNumUfficiale.PasswordChar = ' ';
            }
            else {
                txtNumUfficiale.PasswordChar = Convert.ToChar(0);
            }
            txtNumUfficiale.ReadOnly = disable || Meta.InsertMode;
            if (disable) {
                RowChange.MarkAsAutoincrement(DS.Tables["finvar"].Columns["nofficial"], null, null, 7);
                RowChange.MarkAsCustomAutoincrement(DS.Tables["finvar"].Columns["nofficial"], new RowChange.CustomCalcAutoID(CalcID));
            }
            else {
                RowChange.ClearAutoIncrement(DS.Tables["finvar"].Columns["nofficial"]);
                RowChange.ClearCustomAutoIncrement(DS.Tables["finvar"].Columns["nofficial"]);
            }

            if (Meta.InsertMode) {
                /*
                if (disable) {
                }
                else {
                    txtNumUfficiale.PasswordChar = Convert.ToChar(0);
                }*/
                txtNumUfficiale.Clear();
            }
        }

        private void EnableDisableVariationKind() {
            if ((Meta.IsEmpty) || (Meta.InsertMode)) {
                rdbVarAssestamento.Enabled = true;
                rdbVarNormale.Enabled = true;
                rdbVarRipartizione.Enabled = true;
                rdbVarStorno.Enabled = true;

                rdbVarIniziale.Enabled = true;
            }
            if (Meta.EditMode) {
                DataRow Curr = DS.finvar.Rows[0];
                int variationkind = CfgFn.GetNoNullInt32(Curr["variationkind"]);
                if (variationkind == 5) // tipo variazione iniziale
                {
                    rdbVarAssestamento.Enabled = false;
                    rdbVarNormale.Enabled = false;
                    rdbVarRipartizione.Enabled = false;
                    rdbVarStorno.Enabled = false;

                    rdbVarIniziale.Enabled = true;
                }
                else {
                    rdbVarAssestamento.Enabled = true;
                    rdbVarNormale.Enabled = true;
                    rdbVarRipartizione.Enabled = true;
                    rdbVarStorno.Enabled = true;

                    rdbVarIniziale.Enabled = false;
                }
            }


        }
        private void valorizzaTxtNumUfficiale() {
            if (DS.finvar.Rows.Count == 0) return;
            if (!Meta.EditMode) return;

            DataRow Curr = DS.finvar.Rows[0];
            string ufficiale = (chkOfficial.Checked) ? "S" : "N";

            if (ufficiale == "S") {
                if (Curr["nofficial", DataRowVersion.Original] != DBNull.Value) {
                    int oldValue = CfgFn.GetNoNullInt32(Curr["nofficial", DataRowVersion.Original]);
                    txtNumUfficiale.Text = oldValue.ToString();
                }
            }
            else {
                txtNumUfficiale.Text = "";
            }
        }

        public void MetaData_BeforeFill() {
            if (DS.finvar.Rows.Count == 0) return;
            if (DS.Tables["config"].Rows.Count == 0) return;
            DataRow Curr = DS.finvar.Rows[0];
            string ufficiale = Curr["official"].ToString().ToUpper();
            bool disabilita = (ufficiale == "S") && Meta.InsertMode;
            DisabilitaUfficiale(disabilita);
            if (flagcredit == "N") {
                if (Curr["flagcredit"].ToString().ToUpper() == "S") {
                    chkCrediti.Visible = true;
                }
                else {
                    chkCrediti.Visible = false;
                }
            }
            if (flagproceeds == "N") {
                if (Curr["flagproceeds"].ToString().ToUpper() == "S") {
                    chkCassa.Visible = true;
                }
                else {
                    chkCassa.Visible = false;
                }
            }
            Meta.MarkTableAsNotEntityChild(DS.lcardvarview);

            UnlinkCardVar();
        }

        private void UnlinkCardVar() {
            foreach (DataRow R in DS.lcardvarview.Rows) {
                string filterCard = QHC.CmpEq("idlcard", R["idlcard"]);
                DataRow[] Details = DS.finvardetail.Select(filterCard);
                if (Details.Length == 0) {
                    R["yvar"] = DBNull.Value;
                    R["nvar"] = DBNull.Value;
                }
            }
        }

        public void MetaData_AfterFill() {
            SetChkPresuntoVisibility();
            decimal somma_entrate = MetaData.SumColumn(DS.finvardetail, "!entrata");
            decimal somma_spese = MetaData.SumColumn(DS.finvardetail, "!spesa");
            decimal saldo = somma_entrate - somma_spese;
            txtSaldo.Text = saldo.ToString("c");
            btnStornoTraUpb.Enabled = true;
            btnStornoDaCard.Enabled = true;
            if ((!Meta.IsEmpty) && (Meta.FirstFillForThisRow)) {
                grpAtto.Tag = "AutoChoose.txtNact.default.(idenactmentstatus='1')";
                btnScegliAtto.Tag = "choose.enactment.default.(idenactmentstatus='1')";                
                Meta.SetAutoMode(grpAtto);
            }
            EnableDisableVariationKind();
            SetMoneyTranferVisibility();
            if (Meta.EditMode && hasChanges(DS.finvardetail)) {
                gboxStato.Enabled = false;
                groupTipoPrevisione.Enabled = false;
            }
            else {
                gboxStato.Enabled = true;
                groupTipoPrevisione.Enabled = true;
            }
            visualizzaBtnSimulazione();
        }
        bool hasChanges(DataTable T) {
            foreach (DataRow r in T.Rows) {
                if (r.RowState != DataRowState.Unchanged) return true;
            }
            return false;
        }
        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (Meta.IsEmpty) return;
            DataRow Curr = DS.finvar.Rows[0];
            if (T.TableName == "enactment" && R != null && Meta.DrawStateIsDone) {
                txtProvvedimento.Text = R["description"].ToString();
                txtNumProvv.Text = R["nofficial"].ToString();
                txtDataProvv.Text = HelpForm.StringValue(R["adate"], txtDataProvv.Tag.ToString());
                Curr["enactment"] = R["description"];
                Curr["nenactment"] = R["nofficial"];
                Curr["enactmentdate"] = R["adate"];
                return;
            }
            if (T.TableName == "lcardvarview" && R != null && Meta.DrawStateIsDone && Operating) {
                LinkCardVar(R);
                return;
            }
            /*
             * Se ci sono delle modifiche ai dettagli non posso passare ad Approvata, o viceversa.
             * Va controllato il vecchio e nuovo stato, se lo stato precedente è 'approvato' ( original value), il nuovo non può essere cambiato,
             * si potrebbe anche disabilitare il bottone in questo caso.
             * */

            if (T.TableName == "finvarstatus") {
                if (!Meta.DrawStateIsDone) return;
                if (R == null) return;
                if ((Meta.EditMode) && DettaglioModificato()) {
                    int CurrentStatus = CfgFn.GetNoNullInt32(R["idfinvarstatus"]); // 5 = Approvata
                    if (CurrentStatus == 5) {
                        show("La variazione non può essere Approvata se sono stati modificati dettagli. Salvare le modifiche e poi approvare la variazione.", "Attenzione",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        
                        HelpForm.SetComboBoxValue(cmbStatus, Curr["idfinvarstatus", DataRowVersion.Original]);
                    }
                }
            }
        }
        private void rdbVarStorno_CheckedChanged(object sender, System.EventArgs e) {


            if (Meta.DrawStateIsDone) {
                SetMoneyTranferVisibility();
            }
            if (Meta.InsertMode) {
                if (rdbVarStorno.Checked == true) {
                    if (flagcredit == "S") {
                        chkCrediti.Checked = true;
                    }
                    if (flagproceeds == "S") {
                        chkCassa.Checked = true;
                    }
                    //chkCrediti.Checked = true;
                    //chkCassa.Checked = true;
                    ckbPrevPrincipale.Checked = true;
                    ckbPrevSecondaria.Checked = true;

                }
                else {
                    chkCrediti.Checked = false;
                    chkCassa.Checked = false;
                    ckbPrevPrincipale.Checked = false;
                    ckbPrevSecondaria.Checked = false;
                }

            }
        }

        private void chkOfficial_CheckedChanged(object sender, EventArgs e) {
            if (Meta.InsertMode) {
                DisabilitaUfficiale(chkOfficial.Checked);
            }
            if (Meta.EditMode) {
                valorizzaTxtNumUfficiale();
            }
        }

        private void btnStornoTraUpb_Click(object sender, EventArgs e) {
            if (Meta.EditMode || Meta.InsertMode) {
                bool ok = Meta.GetFormData(true);
                DialogResult dr = new FrmStornoTraUpb(Meta, DS).ShowDialog(this);
                if (dr == DialogResult.OK) {
                    Meta.FreshForm();
                }
            }
        }



        string CalculateFilterForLinking(bool SQL) {
            QueryHelper qh = SQL ? QHS : QHC;
            string MyFilter = "";

            object idman = DS.finvar.Rows[0]["idman"];

            string filterLcard = QHS.CmpEq("active", 'S');

            if (idman != DBNull.Value) filterLcard = QHS.AppAnd(QHS.CmpEq("idman", idman), filterLcard);
            DataTable LCard = Meta.Conn.RUN_SELECT("lcard", "*", null, filterLcard, null, true);

            MyFilter = qh.AppAnd(qh.IsNull("yvar"), qh.FieldIn("idlcard", LCard.Select()), qh.FieldNotIn("idlcardvar", DS.lcardvarview.Select()));

            return MyFilter;
        }

        bool Operating = false;

        private void btnStornoDaCard_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            if (Operating) return;

            Operating = true;
            btnStornoDaCard.Enabled = false;

            Meta.GetFormData(true);


            string MyFilter = CalculateFilterForLinking(true);

            string command = "choose.lcardvarview.default." + MyFilter;
            MetaData.Choose(this, command);

            Operating = false;
            btnStornoDaCard.Enabled = true;
        }

        void LinkCardVar(DataRow RigaSelezionata) {
            if (RigaSelezionata == null) return;

            DataTable TCard = Meta.Conn.RUN_SELECT("lcard", "*", null, QHS.CmpEq("idlcard", RigaSelezionata["idlcard"]), null, true);
            if (TCard.Rows.Count == 0) return;
            DataRow RCard = TCard.Rows[0];
            DataTable TStore = Meta.Conn.RUN_SELECT("store", "*", null, QHS.CmpEq("idstore", RCard["idstore"]), null, true);
            DataRow RStore = TStore.Rows[0];

            DataRow RConf = DS.Tables["config"].Rows[0];
            // Ciclo per la creazione di due nuovi dettagli
            if (RConf["idfin_store"] == DBNull.Value) {
                show(@"Non è stato configurato il conto 'Storni per ricariche card' nella configurazione annuale, sezione Cespiti/Magazzino",
                    @"Errore");
                return;
            }
            DataRow RVar = DS.finvar.Rows[0];

            MetaData metaDT = MetaData.GetMetaData(this, "finvardetail");
            metaDT.SetDefaults(DS.finvardetail);
            DataRow rDT = metaDT.Get_New_Row(RVar, DS.finvardetail);

            rDT["idupb"] = RigaSelezionata["idupb"];
            rDT["idfin"] = RigaSelezionata["idfin"];
            rDT["description"] = RigaSelezionata["description"].ToString();
            rDT["amount"] = -CfgFn.GetNoNullDecimal(RigaSelezionata["amount"]);
            rDT["idlcard"] = RigaSelezionata["idlcard"].ToString();

            DataRow rDT1 = metaDT.Get_New_Row(RVar, DS.finvardetail);
            if (DS.Tables["config"].Rows.Count == 0) return;
          

            rDT1["idupb"] = RStore["idupb"];
            rDT1["idfin"] = RConf["idfin_store"];
            rDT1["description"] = RigaSelezionata["description"].ToString();
            rDT1["amount"] = CfgFn.GetNoNullDecimal(RigaSelezionata["amount"]);

            RigaSelezionata["yvar"] = RVar["yvar"];
            RigaSelezionata["nvar"] = RVar["nvar"];
            Meta.MarkTableAsNotEntityChild(DS.lcardvarview);

            Meta.FreshForm();


        }

        private void chkCassa_CheckedChanged(object sender, EventArgs e) {
            if (Meta.DrawStateIsDone) SetMoneyTranferVisibility();           
        }

        private void rdbVarIniziale_CheckedChanged(object sender, EventArgs e) {
            if (Meta.DrawStateIsDone) SetChkPresuntoVisibility();
        }

        void SetChkPresuntoVisibility() {
            bool show = true;            
            if (!rdbVarIniziale.Checked)
                show= false;
            if ((ckbPrevSecondaria.Checked == false) && (ckbPrevPrincipale.Checked==false)) {
                show = false;
            }
            if (Meta.IsEmpty)
                show = true;
            if (show){
                chkDispPresunto.Visible = true;
            }
            else {
                chkDispPresunto.Checked = false;
                chkDispPresunto.Visible = false;
            }
        }

        private void ckbPrevPrincipale_CheckedChanged(object sender, EventArgs e) {
            if(Meta.DrawStateIsDone)    SetChkPresuntoVisibility();
        }

        private void ckbPrevSecondaria_CheckedChanged(object sender, EventArgs e) {
            if (Meta.DrawStateIsDone) SetChkPresuntoVisibility();
        }

        private void btnSimula_Click(object sender, EventArgs e) {
            if (!Meta.DrawStateIsDone)return;
            applicaSimulazione();
        }
        void visualizzaBtnSimulazione() {
            bool simulazioneAbilitata = (!isApproved()) && (!Meta.IsEmpty) && (!DS.HasChanges());
            btnSimula.Visible = simulazioneAbilitata;
            if (!simulazioneAbilitata) rimuoviColonneSimulazione();

        }
        bool isApproved() {
            if (Meta.IsEmpty) return false;
            if (cmbStatus.SelectedIndex <= 0) return false;
            int status = CfgFn.GetNoNullInt32(cmbStatus.SelectedValue);
            return (status == 5);
        }
        bool isIniziale() {
            if (Meta.IsEmpty) return false;
            if (cmbStatus.SelectedIndex <= 0) return false;
            return (rdbVarIniziale.Checked);
        }
        void rimuoviColonneSimulazione() {
            bool someDone = false;
            for (int i = 1; i <= 1; i++) {
                string suffix = i == 1 ? "" : i.ToString();
                if (DS.finvardetail.Columns.Contains("!prevdisp" + suffix)) {
                    DS.finvardetail.Columns.Remove("!prevdisp" + suffix);
                    someDone = true;
                }
                if (DS.finvardetail.Columns.Contains("!newprevdisp" + suffix)) {
                    DS.finvardetail.Columns.Remove("!newprevdisp" + suffix);
                    someDone = true;
                }
            }
            //if (!someDone) return;
            gridDetails.AllowSorting = false;
            gridDetails.DataSource = null;
            gridDetails.TableStyles.Clear();
            QueryCreator.SetLinkedGrid(DS.finvardetail, null);
            gridDetails.AllowSorting = true;
            HelpForm.SetDataGrid(gridDetails, DS.finvardetail);
        }


        void aggiungiColonneSimulazione() {
            bool someDone = false;
            for (int i = 1; i <= 1; i++) {
                string suffix = i == 1 ? "" : i.ToString();
                if (!DS.finvardetail.Columns.Contains("!prevdisp" + suffix)) {
                    DataColumn C = new DataColumn("!prevdisp" + suffix, typeof(decimal));
                    DS.finvardetail.Columns.Add(C);
                    MetaData.DescribeAColumn(DS.finvardetail, "!prevdisp" + suffix, "Prev.Disponibile " /* + anno */, 
                                    DS.finvardetail.Columns.Count - 1);
                    someDone = true;
                }
                if (!DS.finvardetail.Columns.Contains("!newprevdisp" + suffix)) {
                    DataColumn C = new DataColumn("!newprevdisp" + suffix, typeof(decimal));
                    DS.finvardetail.Columns.Add(C);
                    MetaData.DescribeAColumn(DS.finvardetail, "!newprevdisp" + suffix, "Nuovo Disponibile" /* + anno */,
                        DS.finvardetail.Columns.Count - 1);
                    someDone = true;
                }
            }
            //if (!someDone) return;
            gridDetails.DataSource = null;
            gridDetails.TableStyles.Clear();
            QueryCreator.SetLinkedGrid(DS.finvardetail, null);
            HelpForm.SetDataGrid(gridDetails, DS.finvardetail);
        }
        void applicaSimulazione() {
            aggiungiColonneSimulazione();
            DataRow curr = DS.finvar.First();
            //Calcola disponibile per tutte le righe di dettaglio
            string sql = "select D.rownum," +
                                "UT.currentprev," +
                                "UT.previsionvariation," +
                                "ET.totalcompetency, ET.totalarrears," +
                                "AT.totalcompetency as atotalcompetency, AT.totalarrears as atotalarrears " +
                          "from finvardetail D " +
                          " left outer join upbtotal UT on UT.idfin=D.idfin and UT.idupb=D.idupb " +
                          " left outer join upbexpensetotal ET on UT.idfin=ET.idfin and UT.idupb=ET.idupb and ET.nphase=1" +
                          " left outer join upbincometotal AT on UT.idfin=AT.idfin and UT.idupb=AT.idupb and AT.nphase=1" +
                          " WHERE " + QHS.AppAnd(QHS.CmpEq("D.yvar", curr["yvar"]), QHS.CmpEq("D.nvar", curr["nvar"]));
            DataTable prev = Conn.SQLRunner(sql);
            if (prev == null) {
                return;
            }
            foreach (DataRow r in prev.Rows) {
                DataRow dets = DS.finvardetail.First(QHC.CmpEq("rownum", r["rownum"]));
                if (dets == null) continue;
                for (int i = 1; i <= 1; i++) {
                    string suffix = i == 1 ? "" : i.ToString();
                    decimal previsione = CfgFn.GetNoNullDecimal(r["currentprev" + suffix]) + CfgFn.GetNoNullDecimal(r["previsionvariation" + suffix]);
                    decimal disponibile = previsione;
                    if (i == 1) {
                        decimal impegnato = CfgFn.GetNoNullDecimal(r["totalcompetency" + suffix]);
                        if (solaCassa) impegnato += CfgFn.GetNoNullDecimal(r["totalarrears" + suffix]);
                        decimal accertato = CfgFn.GetNoNullDecimal(r["atotalcompetency" + suffix]);
                        if (solaCassa) accertato += CfgFn.GetNoNullDecimal(r["atotalarrears" + suffix]);
                        disponibile  = disponibile - accertato - impegnato;
                    }
                    dets["!prevdisp" + suffix] = disponibile;
                    dets["!newprevdisp" + suffix] = disponibile;
                }
            }
            for (int i = 0; i < DS.finvardetail.Rows.Count; i++) {
                DataRow Ri = DS.finvardetail.Rows[i];
                for (int j = 0; j < DS.finvardetail.Rows.Count; j++) {
                    DataRow Rj = DS.finvardetail.Rows[j];
                    if (Ri["idfin"].ToString() != Rj["idfin"].ToString()) continue;
                    if (Ri["idupb"].ToString() != Rj["idupb"].ToString()) continue;
                    for (int k = 1; k <= 1; k++) {
                        string suffix = k == 1 ? "" : k.ToString();
                        Rj["!newprevdisp" + suffix] = CfgFn.GetNoNullDecimal(Rj["!newprevdisp" + suffix]) +
                                                                CfgFn.GetNoNullDecimal(Ri["amount" + suffix]);
                    }
                }
            }

            btnSimula.Visible = false;
        }
    }
}
