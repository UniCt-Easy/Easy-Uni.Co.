
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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using q = metadatalibrary.MetaExpression;
using funzioni_configurazione;
using System.Data;
using System.Linq;

namespace accountvar_default {
    /// <summary>
    /// Summary description for Frm_accountvar_default.
    /// </summary>
    public class Frm_accountvar_default : MetaDataForm {
        MetaData Meta;
        bool DoSendMail;
        int CurrentStatus;
        public accountvar_default.vistaForm DS;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEsercizio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtProvvedimento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDataProvv;
        private System.Windows.Forms.TextBox txtNumProvv;
        private System.Windows.Forms.TextBox txtDescrizione;
        private System.Windows.Forms.TextBox txtDataContabile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGrid gridDetails;
        private System.Windows.Forms.Button btnElimina;
        private System.Windows.Forms.Button btnModifica;
        private System.Windows.Forms.Button btnInserisci;
        private Label label7;
        private GroupBox groupBox7;
        private ComboBox cmbStatus;
        private GroupBox gboxResponsabile;
        public TextBox txtResponsabile;
        private Button button4;
        private GroupBox groupBox1;
        private RadioButton rdbVarIniziale;
        private RadioButton rdbVarNormale;
        private TabControl tabControl1;
        private TabPage tabDettagli;
        private TabPage tabAnnotazioni;
        private Label label4;
        private TextBox textBox1;
        private Label label11;
        private TextBox textBox4;
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
        private TabPage tabAllegati;
        private DataGrid dataGrid3;
        private Button button2;
        private Button button3;
        private Button button1;
        private RadioButton rdbStorno;
        private TextBox txtSaldo;
        private Label label8;
        private Button btnSimula;
        private RadioButton rdbVarAssestamento;
        private GroupBox grpAtto;
        private Button btnScegliAtto;
        private TextBox txtNact;
        private CheckBox chkPresunto;
		private RadioButton rdbIntegraPrevIniziale;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        public Frm_accountvar_default() {
            InitializeComponent();
            DS.accountvardetail.ExtendedProperties["ViewTable"] = DS.accountvardetailview;
            DS.accountvardetailview.ExtendedProperties["RealTable"] = DS.accountvardetail;
            DS.account.ExtendedProperties["ViewTable"] = DS.accountvardetailview;
            DS.upb.ExtendedProperties["ViewTable"] = DS.accountvardetailview;
            DS.costpartition.ExtendedProperties["ViewTable"] = DS.accountvardetailview;

            DS.accountvardetailview.Columns["yvar"].ExtendedProperties["ViewSource"] = "accountvardetail.yvar";
            DS.accountvardetailview.Columns["nvar"].ExtendedProperties["ViewSource"] = "accountvardetail.nvar";
            DS.accountvardetailview.Columns["rownum"].ExtendedProperties["ViewSource"] = "accountvardetail.rownum";
            DS.accountvardetailview.Columns["idacc"].ExtendedProperties["ViewSource"] = "accountvardetail.idacc";
            DS.accountvardetailview.Columns["idupb"].ExtendedProperties["ViewSource"] = "accountvardetail.idupb";
            DS.accountvardetailview.Columns["amount"].ExtendedProperties["ViewSource"] = "accountvardetail.amount";
            DS.accountvardetailview.Columns["description"].ExtendedProperties["ViewSource"] =
                "accountvardetail.description";

            DS.accountvardetailview.Columns["cu"].ExtendedProperties["ViewSource"] = "accountvardetail.cu";
            DS.accountvardetailview.Columns["ct"].ExtendedProperties["ViewSource"] = "accountvardetail.ct";
            DS.accountvardetailview.Columns["lu"].ExtendedProperties["ViewSource"] = "accountvardetail.lu";
            DS.accountvardetailview.Columns["lt"].ExtendedProperties["ViewSource"] = "accountvardetail.lt";

            DS.accountvardetailview.Columns["ayear"].ExtendedProperties["ViewSource"] = "account.ayear";
            DS.accountvardetailview.Columns["flagaccountusage"].ExtendedProperties["ViewSource"] =
                "account.flagaccountusage";
            DS.accountvardetailview.Columns["codeupb"].ExtendedProperties["ViewSource"] = "upb.codeupb";
            DS.accountvardetailview.Columns["upb"].ExtendedProperties["ViewSource"] = "upb.title";
            DS.accountvardetailview.Columns["codeacc"].ExtendedProperties["ViewSource"] = "account.codeacc";
            DS.accountvardetailview.Columns["account"].ExtendedProperties["ViewSource"] = "account.title";

            DS.accountvardetailview.Columns["amount2"].ExtendedProperties["ViewSource"] = "accountvardetail.amount2";
            DS.accountvardetailview.Columns["amount3"].ExtendedProperties["ViewSource"] = "accountvardetail.amount3";
            DS.accountvardetailview.Columns["amount4"].ExtendedProperties["ViewSource"] = "accountvardetail.amount4";
            DS.accountvardetailview.Columns["amount5"].ExtendedProperties["ViewSource"] = "accountvardetail.amount5";
            DS.accountvardetailview.Columns["annotation"].ExtendedProperties["ViewSource"] =
                "accountvardetail.annotation";

            DS.accountvardetailview.Columns["idsor1"].ExtendedProperties["ViewSource"] = "accountvardetail.idsor1";
            DS.accountvardetailview.Columns["idsor2"].ExtendedProperties["ViewSource"] = "accountvardetail.idsor2";
            DS.accountvardetailview.Columns["idsor3"].ExtendedProperties["ViewSource"] = "accountvardetail.idsor3";
            DS.accountvardetailview.Columns["sortcode1"].ExtendedProperties["ViewSource"] = "sorting1.sortcode";
            DS.accountvardetailview.Columns["sortcode2"].ExtendedProperties["ViewSource"] = "sorting2.sortcode";
            DS.accountvardetailview.Columns["sortcode3"].ExtendedProperties["ViewSource"] = "sorting3.sortcode";
            DS.accountvardetailview.Columns["costpartitioncode"].ExtendedProperties["ViewSource"] =
                "costpartition.costpartitioncode";
            DS.accountvardetailview.Columns["idcostpartition"].ExtendedProperties["ViewSource"] =
                "accountvardetail.idcostpartition";
            DS.accountvardetailview.Columns["underwritingkind"].ExtendedProperties["ViewSource"] =
                "accountvardetail.underwritingkind";
            DS.accountvardetailview.Columns["prevcassa"].ExtendedProperties["ViewSource"] =
                "accountvardetail.prevcassa";
			DS.accountvardetailview.Columns["idinv"].ExtendedProperties["ViewSource"] =
			"accountvardetail.idinv";
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
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtEsercizio = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtNumero = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.txtProvvedimento = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtDataProvv = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtNumProvv = new System.Windows.Forms.TextBox();
			this.txtDescrizione = new System.Windows.Forms.TextBox();
			this.txtDataContabile = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.gridDetails = new System.Windows.Forms.DataGrid();
			this.btnElimina = new System.Windows.Forms.Button();
			this.btnModifica = new System.Windows.Forms.Button();
			this.btnInserisci = new System.Windows.Forms.Button();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.cmbStatus = new System.Windows.Forms.ComboBox();
			this.DS = new accountvar_default.vistaForm();
			this.gboxResponsabile = new System.Windows.Forms.GroupBox();
			this.txtResponsabile = new System.Windows.Forms.TextBox();
			this.button4 = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rdbIntegraPrevIniziale = new System.Windows.Forms.RadioButton();
			this.rdbVarAssestamento = new System.Windows.Forms.RadioButton();
			this.rdbStorno = new System.Windows.Forms.RadioButton();
			this.rdbVarIniziale = new System.Windows.Forms.RadioButton();
			this.rdbVarNormale = new System.Windows.Forms.RadioButton();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabDettagli = new System.Windows.Forms.TabPage();
			this.btnSimula = new System.Windows.Forms.Button();
			this.tabAnnotazioni = new System.Windows.Forms.TabPage();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
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
			this.tabAllegati = new System.Windows.Forms.TabPage();
			this.dataGrid3 = new System.Windows.Forms.DataGrid();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.txtSaldo = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.grpAtto = new System.Windows.Forms.GroupBox();
			this.btnScegliAtto = new System.Windows.Forms.Button();
			this.txtNact = new System.Windows.Forms.TextBox();
			this.chkPresunto = new System.Windows.Forms.CheckBox();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridDetails)).BeginInit();
			this.groupBox7.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.gboxResponsabile.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabDettagli.SuspendLayout();
			this.tabAnnotazioni.SuspendLayout();
			this.tabAttributi.SuspendLayout();
			this.gboxclass05.SuspendLayout();
			this.gboxclass04.SuspendLayout();
			this.gboxclass03.SuspendLayout();
			this.gboxclass02.SuspendLayout();
			this.gboxclass01.SuspendLayout();
			this.tabAllegati.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).BeginInit();
			this.grpAtto.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.label3);
			this.groupBox3.Controls.Add(this.txtEsercizio);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Controls.Add(this.txtNumero);
			this.groupBox3.Location = new System.Drawing.Point(12, 3);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(252, 45);
			this.groupBox3.TabIndex = 1;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Variazione";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(128, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 16);
			this.label3.TabIndex = 8;
			this.label3.Text = "Numero:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtEsercizio
			// 
			this.txtEsercizio.Location = new System.Drawing.Point(72, 16);
			this.txtEsercizio.Name = "txtEsercizio";
			this.txtEsercizio.ReadOnly = true;
			this.txtEsercizio.Size = new System.Drawing.Size(48, 20);
			this.txtEsercizio.TabIndex = 1;
			this.txtEsercizio.TabStop = false;
			this.txtEsercizio.Tag = "accountvar.yvar";
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
			// txtNumero
			// 
			this.txtNumero.Location = new System.Drawing.Point(192, 16);
			this.txtNumero.Name = "txtNumero";
			this.txtNumero.Size = new System.Drawing.Size(48, 20);
			this.txtNumero.TabIndex = 2;
			this.txtNumero.Tag = "accountvar.nvar";
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.txtProvvedimento);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.txtDataProvv);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.txtNumProvv);
			this.groupBox2.Location = new System.Drawing.Point(314, 59);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(371, 88);
			this.groupBox2.TabIndex = 5;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Provvedimento";
			// 
			// txtProvvedimento
			// 
			this.txtProvvedimento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtProvvedimento.Location = new System.Drawing.Point(8, 16);
			this.txtProvvedimento.Multiline = true;
			this.txtProvvedimento.Name = "txtProvvedimento";
			this.txtProvvedimento.Size = new System.Drawing.Size(263, 66);
			this.txtProvvedimento.TabIndex = 0;
			this.txtProvvedimento.Tag = "accountvar.enactment";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(254, 9);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(56, 15);
			this.label6.TabIndex = 16;
			this.label6.Text = "Data:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDataProvv
			// 
			this.txtDataProvv.Location = new System.Drawing.Point(276, 24);
			this.txtDataProvv.Name = "txtDataProvv";
			this.txtDataProvv.Size = new System.Drawing.Size(88, 20);
			this.txtDataProvv.TabIndex = 1;
			this.txtDataProvv.Tag = "accountvar.enactmentdate";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(267, 45);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(53, 16);
			this.label7.TabIndex = 20;
			this.label7.Text = "Numero:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtNumProvv
			// 
			this.txtNumProvv.Location = new System.Drawing.Point(277, 62);
			this.txtNumProvv.Name = "txtNumProvv";
			this.txtNumProvv.Size = new System.Drawing.Size(87, 20);
			this.txtNumProvv.TabIndex = 2;
			this.txtNumProvv.Tag = "accountvar.nenactment";
			// 
			// txtDescrizione
			// 
			this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescrizione.Location = new System.Drawing.Point(12, 72);
			this.txtDescrizione.Multiline = true;
			this.txtDescrizione.Name = "txtDescrizione";
			this.txtDescrizione.Size = new System.Drawing.Size(295, 72);
			this.txtDescrizione.TabIndex = 4;
			this.txtDescrizione.Tag = "accountvar.description";
			// 
			// txtDataContabile
			// 
			this.txtDataContabile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDataContabile.Location = new System.Drawing.Point(588, 162);
			this.txtDataContabile.Name = "txtDataContabile";
			this.txtDataContabile.Size = new System.Drawing.Size(88, 20);
			this.txtDataContabile.TabIndex = 7;
			this.txtDataContabile.Tag = "accountvar.adate";
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.Location = new System.Drawing.Point(585, 147);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(88, 16);
			this.label5.TabIndex = 35;
			this.label5.Text = "Data contabile:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 16);
			this.label2.TabIndex = 29;
			this.label2.Text = "Descrizione:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// gridDetails
			// 
			this.gridDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gridDetails.DataMember = "";
			this.gridDetails.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gridDetails.Location = new System.Drawing.Point(102, 14);
			this.gridDetails.Name = "gridDetails";
			this.gridDetails.Size = new System.Drawing.Size(822, 257);
			this.gridDetails.TabIndex = 34;
			this.gridDetails.Tag = "accountvardetail.default.single";
			// 
			// btnElimina
			// 
			this.btnElimina.Location = new System.Drawing.Point(6, 87);
			this.btnElimina.Name = "btnElimina";
			this.btnElimina.Size = new System.Drawing.Size(78, 24);
			this.btnElimina.TabIndex = 33;
			this.btnElimina.Tag = "delete";
			this.btnElimina.Text = "Elimina";
			// 
			// btnModifica
			// 
			this.btnModifica.Location = new System.Drawing.Point(6, 55);
			this.btnModifica.Name = "btnModifica";
			this.btnModifica.Size = new System.Drawing.Size(78, 24);
			this.btnModifica.TabIndex = 32;
			this.btnModifica.Tag = "edit.single";
			this.btnModifica.Text = "Modifica";
			// 
			// btnInserisci
			// 
			this.btnInserisci.Location = new System.Drawing.Point(6, 23);
			this.btnInserisci.Name = "btnInserisci";
			this.btnInserisci.Size = new System.Drawing.Size(78, 24);
			this.btnInserisci.TabIndex = 31;
			this.btnInserisci.Tag = "insert.single";
			this.btnInserisci.Text = "Inserisci";
			// 
			// groupBox7
			// 
			this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox7.Controls.Add(this.cmbStatus);
			this.groupBox7.Location = new System.Drawing.Point(682, 8);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(268, 40);
			this.groupBox7.TabIndex = 3;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Stato";
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
			this.cmbStatus.Size = new System.Drawing.Size(249, 21);
			this.cmbStatus.TabIndex = 43;
			this.cmbStatus.Tag = "accountvar.idaccountvarstatus";
			this.cmbStatus.ValueMember = "idaccountvarstatus";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// gboxResponsabile
			// 
			this.gboxResponsabile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxResponsabile.Controls.Add(this.txtResponsabile);
			this.gboxResponsabile.Controls.Add(this.button4);
			this.gboxResponsabile.Location = new System.Drawing.Point(12, 147);
			this.gboxResponsabile.Name = "gboxResponsabile";
			this.gboxResponsabile.Size = new System.Drawing.Size(561, 40);
			this.gboxResponsabile.TabIndex = 6;
			this.gboxResponsabile.TabStop = false;
			this.gboxResponsabile.Tag = "AutoChoose.txtResponsabile.default.(financeactive=\'S\')";
			// 
			// txtResponsabile
			// 
			this.txtResponsabile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtResponsabile.Location = new System.Drawing.Point(114, 14);
			this.txtResponsabile.Name = "txtResponsabile";
			this.txtResponsabile.Size = new System.Drawing.Size(441, 20);
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
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.rdbIntegraPrevIniziale);
			this.groupBox1.Controls.Add(this.rdbVarAssestamento);
			this.groupBox1.Controls.Add(this.rdbStorno);
			this.groupBox1.Controls.Add(this.rdbVarIniziale);
			this.groupBox1.Controls.Add(this.rdbVarNormale);
			this.groupBox1.Location = new System.Drawing.Point(270, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(406, 42);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Tipo variazione";
			// 
			// rdbIntegraPrevIniziale
			// 
			this.rdbIntegraPrevIniziale.AutoSize = true;
			this.rdbIntegraPrevIniziale.Location = new System.Drawing.Point(284, 14);
			this.rdbIntegraPrevIniziale.Name = "rdbIntegraPrevIniziale";
			this.rdbIntegraPrevIniziale.Size = new System.Drawing.Size(92, 17);
			this.rdbIntegraPrevIniziale.TabIndex = 7;
			this.rdbIntegraPrevIniziale.Tag = "accountvar.variationkind:6";
			this.rdbIntegraPrevIniziale.Text = "Non operativa";
			this.rdbIntegraPrevIniziale.UseVisualStyleBackColor = true;
			// 
			// rdbVarAssestamento
			// 
			this.rdbVarAssestamento.AutoSize = true;
			this.rdbVarAssestamento.Location = new System.Drawing.Point(71, 15);
			this.rdbVarAssestamento.Name = "rdbVarAssestamento";
			this.rdbVarAssestamento.Size = new System.Drawing.Size(91, 17);
			this.rdbVarAssestamento.TabIndex = 6;
			this.rdbVarAssestamento.Tag = "accountvar.variationkind:3";
			this.rdbVarAssestamento.Text = "Assestamento";
			this.rdbVarAssestamento.UseVisualStyleBackColor = true;
			// 
			// rdbStorno
			// 
			this.rdbStorno.AutoSize = true;
			this.rdbStorno.Location = new System.Drawing.Point(165, 14);
			this.rdbStorno.Name = "rdbStorno";
			this.rdbStorno.Size = new System.Drawing.Size(56, 17);
			this.rdbStorno.TabIndex = 5;
			this.rdbStorno.Tag = "accountvar.variationkind:4";
			this.rdbStorno.Text = "Storno";
			this.rdbStorno.UseVisualStyleBackColor = true;
			// 
			// rdbVarIniziale
			// 
			this.rdbVarIniziale.AutoSize = true;
			this.rdbVarIniziale.Location = new System.Drawing.Point(227, 14);
			this.rdbVarIniziale.Name = "rdbVarIniziale";
			this.rdbVarIniziale.Size = new System.Drawing.Size(57, 17);
			this.rdbVarIniziale.TabIndex = 4;
			this.rdbVarIniziale.Tag = "accountvar.variationkind:5";
			this.rdbVarIniziale.Text = "Iniziale";
			this.rdbVarIniziale.UseVisualStyleBackColor = true;
			// 
			// rdbVarNormale
			// 
			this.rdbVarNormale.Location = new System.Drawing.Point(8, 16);
			this.rdbVarNormale.Name = "rdbVarNormale";
			this.rdbVarNormale.Size = new System.Drawing.Size(71, 16);
			this.rdbVarNormale.TabIndex = 0;
			this.rdbVarNormale.Tag = "accountvar.variationkind:1";
			this.rdbVarNormale.Text = "Normale";
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabDettagli);
			this.tabControl1.Controls.Add(this.tabAnnotazioni);
			this.tabControl1.Controls.Add(this.tabAttributi);
			this.tabControl1.Controls.Add(this.tabAllegati);
			this.tabControl1.Location = new System.Drawing.Point(12, 193);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(938, 303);
			this.tabControl1.TabIndex = 8;
			// 
			// tabDettagli
			// 
			this.tabDettagli.Controls.Add(this.btnSimula);
			this.tabDettagli.Controls.Add(this.btnInserisci);
			this.tabDettagli.Controls.Add(this.btnModifica);
			this.tabDettagli.Controls.Add(this.btnElimina);
			this.tabDettagli.Controls.Add(this.gridDetails);
			this.tabDettagli.Location = new System.Drawing.Point(4, 22);
			this.tabDettagli.Name = "tabDettagli";
			this.tabDettagli.Padding = new System.Windows.Forms.Padding(3);
			this.tabDettagli.Size = new System.Drawing.Size(930, 277);
			this.tabDettagli.TabIndex = 0;
			this.tabDettagli.Text = "Dettagli";
			this.tabDettagli.UseVisualStyleBackColor = true;
			// 
			// btnSimula
			// 
			this.btnSimula.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnSimula.Location = new System.Drawing.Point(7, 227);
			this.btnSimula.Name = "btnSimula";
			this.btnSimula.Size = new System.Drawing.Size(89, 44);
			this.btnSimula.TabIndex = 35;
			this.btnSimula.Tag = "";
			this.btnSimula.Text = "Simula approvazione";
			this.btnSimula.Click += new System.EventHandler(this.btnSimula_Click);
			// 
			// tabAnnotazioni
			// 
			this.tabAnnotazioni.Controls.Add(this.label4);
			this.tabAnnotazioni.Controls.Add(this.textBox1);
			this.tabAnnotazioni.Controls.Add(this.label11);
			this.tabAnnotazioni.Controls.Add(this.textBox4);
			this.tabAnnotazioni.Location = new System.Drawing.Point(4, 22);
			this.tabAnnotazioni.Name = "tabAnnotazioni";
			this.tabAnnotazioni.Padding = new System.Windows.Forms.Padding(3);
			this.tabAnnotazioni.Size = new System.Drawing.Size(930, 277);
			this.tabAnnotazioni.TabIndex = 1;
			this.tabAnnotazioni.Text = "Annotazioni";
			this.tabAnnotazioni.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(4, 102);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(88, 16);
			this.label4.TabIndex = 55;
			this.label4.Text = "Annotazioni ";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(7, 118);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(917, 153);
			this.textBox1.TabIndex = 53;
			this.textBox1.Tag = "accountvar.annotation";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(4, 11);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(88, 16);
			this.label11.TabIndex = 54;
			this.label11.Text = "Motivazione";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBox4
			// 
			this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox4.Location = new System.Drawing.Point(7, 27);
			this.textBox4.Multiline = true;
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(919, 59);
			this.textBox4.TabIndex = 52;
			this.textBox4.Tag = "accountvar.reason";
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
			this.tabAttributi.Size = new System.Drawing.Size(930, 277);
			this.tabAttributi.TabIndex = 2;
			this.tabAttributi.Text = "Attributi";
			this.tabAttributi.UseVisualStyleBackColor = true;
			// 
			// gboxclass05
			// 
			this.gboxclass05.Controls.Add(this.txtCodice05);
			this.gboxclass05.Controls.Add(this.btnCodice05);
			this.gboxclass05.Controls.Add(this.txtDenom05);
			this.gboxclass05.Location = new System.Drawing.Point(498, 101);
			this.gboxclass05.Name = "gboxclass05";
			this.gboxclass05.Size = new System.Drawing.Size(432, 82);
			this.gboxclass05.TabIndex = 28;
			this.gboxclass05.TabStop = false;
			this.gboxclass05.Tag = "";
			this.gboxclass05.Text = "Classificazione 5";
			// 
			// txtCodice05
			// 
			this.txtCodice05.Location = new System.Drawing.Point(9, 55);
			this.txtCodice05.Name = "txtCodice05";
			this.txtCodice05.Size = new System.Drawing.Size(415, 20);
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
			this.txtDenom05.Location = new System.Drawing.Point(165, 8);
			this.txtDenom05.Multiline = true;
			this.txtDenom05.Name = "txtDenom05";
			this.txtDenom05.ReadOnly = true;
			this.txtDenom05.Size = new System.Drawing.Size(259, 41);
			this.txtDenom05.TabIndex = 3;
			this.txtDenom05.TabStop = false;
			this.txtDenom05.Tag = "sorting05.description";
			// 
			// gboxclass04
			// 
			this.gboxclass04.Controls.Add(this.txtCodice04);
			this.gboxclass04.Controls.Add(this.btnCodice04);
			this.gboxclass04.Controls.Add(this.txtDenom04);
			this.gboxclass04.Location = new System.Drawing.Point(498, 8);
			this.gboxclass04.Name = "gboxclass04";
			this.gboxclass04.Size = new System.Drawing.Size(429, 86);
			this.gboxclass04.TabIndex = 27;
			this.gboxclass04.TabStop = false;
			this.gboxclass04.Tag = "";
			this.gboxclass04.Text = "Classificazione 4";
			// 
			// txtCodice04
			// 
			this.txtCodice04.Location = new System.Drawing.Point(6, 60);
			this.txtCodice04.Name = "txtCodice04";
			this.txtCodice04.Size = new System.Drawing.Size(415, 20);
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
			this.txtDenom04.Location = new System.Drawing.Point(165, 8);
			this.txtDenom04.Multiline = true;
			this.txtDenom04.Name = "txtDenom04";
			this.txtDenom04.ReadOnly = true;
			this.txtDenom04.Size = new System.Drawing.Size(256, 50);
			this.txtDenom04.TabIndex = 3;
			this.txtDenom04.TabStop = false;
			this.txtDenom04.Tag = "sorting04.description";
			// 
			// gboxclass03
			// 
			this.gboxclass03.Controls.Add(this.txtCodice03);
			this.gboxclass03.Controls.Add(this.btnCodice03);
			this.gboxclass03.Controls.Add(this.txtDenom03);
			this.gboxclass03.Location = new System.Drawing.Point(5, 182);
			this.gboxclass03.Name = "gboxclass03";
			this.gboxclass03.Size = new System.Drawing.Size(485, 88);
			this.gboxclass03.TabIndex = 25;
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
			this.txtDenom03.Size = new System.Drawing.Size(290, 50);
			this.txtDenom03.TabIndex = 3;
			this.txtDenom03.TabStop = false;
			this.txtDenom03.Tag = "sorting03.description";
			// 
			// gboxclass02
			// 
			this.gboxclass02.Controls.Add(this.txtCodice02);
			this.gboxclass02.Controls.Add(this.btnCodice02);
			this.gboxclass02.Controls.Add(this.txtDenom02);
			this.gboxclass02.Location = new System.Drawing.Point(6, 95);
			this.gboxclass02.Name = "gboxclass02";
			this.gboxclass02.Size = new System.Drawing.Size(485, 88);
			this.gboxclass02.TabIndex = 26;
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
			this.txtDenom02.Size = new System.Drawing.Size(292, 52);
			this.txtDenom02.TabIndex = 3;
			this.txtDenom02.TabStop = false;
			this.txtDenom02.Tag = "sorting02.description";
			// 
			// gboxclass01
			// 
			this.gboxclass01.Controls.Add(this.txtCodice01);
			this.gboxclass01.Controls.Add(this.btnCodice01);
			this.gboxclass01.Controls.Add(this.txtDenom01);
			this.gboxclass01.Location = new System.Drawing.Point(6, 6);
			this.gboxclass01.Name = "gboxclass01";
			this.gboxclass01.Size = new System.Drawing.Size(485, 88);
			this.gboxclass01.TabIndex = 24;
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
			this.txtDenom01.Size = new System.Drawing.Size(292, 52);
			this.txtDenom01.TabIndex = 3;
			this.txtDenom01.TabStop = false;
			this.txtDenom01.Tag = "sorting01.description";
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
			this.tabAllegati.Size = new System.Drawing.Size(930, 277);
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
			this.dataGrid3.Location = new System.Drawing.Point(88, 7);
			this.dataGrid3.Name = "dataGrid3";
			this.dataGrid3.ReadOnly = true;
			this.dataGrid3.Size = new System.Drawing.Size(836, 258);
			this.dataGrid3.TabIndex = 31;
			this.dataGrid3.Tag = "accountvarattachment.default.detail";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(7, 91);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(74, 22);
			this.button2.TabIndex = 30;
			this.button2.Tag = "delete";
			this.button2.Text = "Elimina";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(7, 63);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 22);
			this.button3.TabIndex = 29;
			this.button3.TabStop = false;
			this.button3.Tag = "edit.detail";
			this.button3.Text = "Modifica...";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(7, 35);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(74, 22);
			this.button1.TabIndex = 28;
			this.button1.TabStop = false;
			this.button1.Tag = "insert.detail";
			this.button1.Text = "Inserisci...";
			// 
			// txtSaldo
			// 
			this.txtSaldo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSaldo.Location = new System.Drawing.Point(829, 155);
			this.txtSaldo.Name = "txtSaldo";
			this.txtSaldo.ReadOnly = true;
			this.txtSaldo.Size = new System.Drawing.Size(111, 20);
			this.txtSaldo.TabIndex = 36;
			this.txtSaldo.TabStop = false;
			this.txtSaldo.Tag = "";
			this.txtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label8
			// 
			this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label8.Location = new System.Drawing.Point(735, 159);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(88, 16);
			this.label8.TabIndex = 37;
			this.label8.Text = "Saldo R-C-I";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// grpAtto
			// 
			this.grpAtto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.grpAtto.Controls.Add(this.btnScegliAtto);
			this.grpAtto.Controls.Add(this.txtNact);
			this.grpAtto.Location = new System.Drawing.Point(691, 60);
			this.grpAtto.Name = "grpAtto";
			this.grpAtto.Size = new System.Drawing.Size(259, 34);
			this.grpAtto.TabIndex = 38;
			this.grpAtto.TabStop = false;
			this.grpAtto.Tag = "AutoChoose.txtNact.default";
			// 
			// btnScegliAtto
			// 
			this.btnScegliAtto.Location = new System.Drawing.Point(7, 7);
			this.btnScegliAtto.Name = "btnScegliAtto";
			this.btnScegliAtto.Size = new System.Drawing.Size(133, 23);
			this.btnScegliAtto.TabIndex = 13;
			this.btnScegliAtto.TabStop = false;
			this.btnScegliAtto.Tag = "choose.accountenactment.default";
			this.btnScegliAtto.Text = "Atto Amministrativo";
			this.btnScegliAtto.UseVisualStyleBackColor = true;
			this.btnScegliAtto.Click += new System.EventHandler(this.btnScegliAtto_Click);
			// 
			// txtNact
			// 
			this.txtNact.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtNact.Location = new System.Drawing.Point(146, 10);
			this.txtNact.Name = "txtNact";
			this.txtNact.Size = new System.Drawing.Size(103, 20);
			this.txtNact.TabIndex = 10;
			this.txtNact.Tag = "accountenactment.nenactment?accountvarview.enactmentnumber";
			// 
			// chkPresunto
			// 
			this.chkPresunto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chkPresunto.AutoSize = true;
			this.chkPresunto.Location = new System.Drawing.Point(691, 105);
			this.chkPresunto.Name = "chkPresunto";
			this.chkPresunto.Size = new System.Drawing.Size(68, 17);
			this.chkPresunto.TabIndex = 39;
			this.chkPresunto.Tag = "accountvar.flag:0";
			this.chkPresunto.Text = "Presunto";
			this.chkPresunto.UseVisualStyleBackColor = true;
			// 
			// Frm_accountvar_default
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(958, 508);
			this.Controls.Add(this.chkPresunto);
			this.Controls.Add(this.grpAtto);
			this.Controls.Add(this.txtSaldo);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.gboxResponsabile);
			this.Controls.Add(this.groupBox7);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.txtDescrizione);
			this.Controls.Add(this.txtDataContabile);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label2);
			this.Name = "Frm_accountvar_default";
			this.Text = "Frm_accountvar_default";
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridDetails)).EndInit();
			this.groupBox7.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.gboxResponsabile.ResumeLayout(false);
			this.gboxResponsabile.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabDettagli.ResumeLayout(false);
			this.tabAnnotazioni.ResumeLayout(false);
			this.tabAnnotazioni.PerformLayout();
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
			this.tabAllegati.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).EndInit();
			this.grpAtto.ResumeLayout(false);
			this.grpAtto.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        void visualizzaBtnSimulazione() {
            bool simulazioneAbilitata = (!isApproved()) && (!Meta.IsEmpty) && (!DS.HasChanges());
            btnSimula.Visible = simulazioneAbilitata;
            if (!simulazioneAbilitata) rimuoviColonneSimulazione();

        }

        void applicaSimulazione() {
            aggiungiColonneSimulazione();
            DataRow curr = DS.accountvar.First();
            //Calcola disponibile per tutte le righe di dettaglio
            string sql = "select D.rownum," +
                         "UT.currentprev,UT.currentprev2,UT.currentprev3,UT.currentprev4,UT.currentprev5," +
                         "UT.previsionvariation,UT.previsionvariation2,UT.previsionvariation3,UT.previsionvariation4,UT.previsionvariation5," +
                         "ET.total,ET.total2,ET.total3,ET.total4,ET.total5, " +
                         "AT.total as atotal,AT.total2 as atotal2,AT.total3 as atotal3,AT.total4 as atotal4,AT.total5 as atotal5 " +
                         "from accountvardetail D " +
                         " left outer join upbaccounttotal UT on UT.idacc=D.idacc and UT.idupb=D.idupb " +
                         " left outer join upbepexptotal ET on UT.idacc=ET.idacc and UT.idupb=ET.idupb and ET.nphase=1" +
                         " left outer join upbepacctotal AT on UT.idacc=AT.idacc and UT.idupb=AT.idupb and AT.nphase=1" +
                         " WHERE " + QHS.AppAnd(QHS.CmpEq("D.yvar", curr["yvar"]), QHS.CmpEq("D.nvar", curr["nvar"]));
            DataTable prev = Conn.SQLRunner(sql);
            if (prev == null) {
                return;
            }

            foreach (DataRow r in prev.Rows) {
                DataRow dets = DS.accountvardetail.First(QHC.CmpEq("rownum", r["rownum"]));
                if (dets == null) continue;
                for (int i = 1; i <= 5; i++) {
                    string suffix = i == 1 ? "" : i.ToString();
                    decimal previsione = CfgFn.GetNoNullDecimal(r["currentprev" + suffix]) +
                                         CfgFn.GetNoNullDecimal(r["previsionvariation" + suffix]);
                    decimal impegnato = CfgFn.GetNoNullDecimal(r["total" + suffix]);
                    decimal accertato = CfgFn.GetNoNullDecimal(r["atotal" + suffix]);
                    decimal disponibile = previsione - accertato - impegnato;
                    dets["!prevdisp" + suffix] = disponibile;
                    dets["!newprevdisp" + suffix] = disponibile;
                }
            }

            for (int i = 0; i < DS.accountvardetail.Rows.Count; i++) {
                DataRow Ri = DS.accountvardetail.Rows[i];
                for (int j = 0; j < DS.accountvardetail.Rows.Count; j++) {
                    DataRow Rj = DS.accountvardetail.Rows[j];
                    if (Ri["idacc"].ToString() != Rj["idacc"].ToString()) continue;
                    if (Ri["idupb"].ToString() != Rj["idupb"].ToString()) continue;
                    for (int k = 1; k <= 5; k++) {
                        string suffix = k == 1 ? "" : k.ToString();
                        Rj["!newprevdisp" + suffix] = CfgFn.GetNoNullDecimal(Rj["!newprevdisp" + suffix]) +
                                                      CfgFn.GetNoNullDecimal(Ri["amount" + suffix]);
                    }
                }
            }
			Meta.FreshForm(true);
            btnSimula.Visible = false;
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
            for (int i = 1; i <= 5; i++) {
                string suffix = i == 1 ? "" : i.ToString();
                if (DS.accountvardetail.Columns.Contains("!prevdisp" + suffix)) {
                    DS.accountvardetail.Columns.Remove("!prevdisp" + suffix);
                    someDone = true;
                }

                if (DS.accountvardetail.Columns.Contains("!newprevdisp" + suffix)) {
                    DS.accountvardetail.Columns.Remove("!newprevdisp" + suffix);
                    someDone = true;
                }
            }

            if (!someDone) return;
            gridDetails.AllowSorting = false;
            gridDetails.DataSource = null;
            gridDetails.TableStyles.Clear();
            HelpForm.SetDataGrid(gridDetails, DS.accountvardetail);
            gridDetails.AllowSorting = true;
        }

        void aggiungiColonneSimulazione() {
            bool someDone = false;
            for (int i = 1; i <= 5; i++) {
                string suffix = i == 1 ? "" : i.ToString();
                int anno = Conn.GetEsercizio() + i - 1;
                if (!DS.accountvardetail.Columns.Contains("!prevdisp" + suffix)) {
                    DataColumn C = new DataColumn("!prevdisp" + suffix, typeof(Decimal));
                    DS.accountvardetail.Columns.Add(C);
                    MetaData.DescribeAColumn(DS.accountvardetail, "!prevdisp" + suffix, "Budget.Disponibile " + anno,
                        DS.accountvardetail.Columns.Count - 1);
                    someDone = true;
                }

                if (!DS.accountvardetail.Columns.Contains("!newprevdisp" + suffix)) {
                    DataColumn C = new DataColumn("!newprevdisp" + suffix, typeof(Decimal));
                    DS.accountvardetail.Columns.Add(C);
                    MetaData.DescribeAColumn(DS.accountvardetail, "!newprevdisp" + suffix, "Nuovo Disponibile " + anno,
                        DS.accountvardetail.Columns.Count - 1);
                    someDone = true;
                }
            }

            if (!someDone) return;
            gridDetails.TableStyles.Clear();
            HelpForm.SetDataGrid(gridDetails, DS.accountvardetail);
        }

        public void MetaData_AfterClear() {
            txtEsercizio.Text = Meta.GetSys("esercizio").ToString();
            txtSaldo.Text = "";
            EnableDisableVariationKind();
            rimuoviColonneSimulazione();
            visualizzaBtnSimulazione();
			EnableDisableStatus();
		}

        CQueryHelper QHC;
        QueryHelper QHS;
        DataAccess Conn;

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            DataAccess.SetTableForReading(DS.sorting1, "sorting");
            DataAccess.SetTableForReading(DS.sorting2, "sorting");
            DataAccess.SetTableForReading(DS.sorting3, "sorting");

            MetaData.SetDefault(DS.accountvar, "idaccountvarstatus",
                "5"); //Impostiamo per default lo stato in Approvata 

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

            string filteresercizio = QHS.CmpEq("yenactment", Conn.GetEsercizio());
            string filterstatus = QHS.CmpEq("idenactmentstatus", 2); // approvato
            GetData.SetStaticFilter(DS.accountenactment, filteresercizio);

        }

        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (Meta.IsEmpty) return;
            DataRow Curr = DS.accountvar.Rows[0];
			/*
             * Se ci sono delle modifiche ai dettagli non posso passare ad Approvata, o viceversa.
             * Va controllato il vecchio e nuovo stato, se lo stato precedente è 'approvato' ( original value), il nuovo non può essere cambiato,
             * si potrebbe anche disabilitare il bottone in questo caso.
             * */
			if (T.TableName == "accountvarstatus") {
				if (!Meta.DrawStateIsDone) return;
				if (R == null) return;
				if ((Meta.EditMode) && DettaglioModificato()) {
					int CurrentStatus = CfgFn.GetNoNullInt32(R["idaccountvarstatus"]); // 5 = Approvata
					if (CurrentStatus == 5) {
						show(
							"La variazione non può essere Approvata se sono stati modificati dettagli. Salvare le modifiche e poi approvare la variazione.",
							"Attenzione",
							MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						HelpForm.SetComboBoxValue(cmbStatus, Curr["idaccountvarstatus", DataRowVersion.Original]);
					}
				}
			}
			 
        }

        //se lo stato è Edit e ci sono modifiche in finvardetail su idupb/idacc
        //non deve essere possibile approvare la variazione
        bool DettaglioModificato() {
            if (DS.accountvar.Rows.Count == 0) return false;
            foreach (DataRow rDettaglio in DS.accountvardetail.Rows) {
                if (rDettaglio.RowState == DataRowState.Deleted)
                    return true;
                if (rDettaglio.RowState == DataRowState.Added)
                    return true;
                if (rDettaglio.RowState == DataRowState.Modified) {
                    return true;
                }
            }

            return false;
        }

        public void MetaData_BeforePost() {
            if (DS.accountvar.Rows.Count == 0) return;

            // Add - Invio Mail al cambio stato
            DataRow CurrRow = DS.accountvar.Rows[0];
            DoSendMail = false;
            if (CurrRow.RowState != DataRowState.Deleted) {
                CurrentStatus = CfgFn.GetNoNullInt32(CurrRow["idaccountvarstatus"]);
                int OriginalStatus;
                if (!Meta.InsertMode)
                    OriginalStatus = CfgFn.GetNoNullInt32(CurrRow["idaccountvarstatus", DataRowVersion.Original]);
                else
                    OriginalStatus = CurrentStatus;


                if (CurrentStatus != OriginalStatus &&
                    (CurrentStatus == 3 || CurrentStatus == 4 || CurrentStatus == 5 || CurrentStatus == 6))
                    DoSendMail = true;
                else
                    DoSendMail = false;
            }
        }

        public void MetaData_AfterPost() {
            if (DoSendMail) {
                DataRow CurrentRow = DS.accountvar.Rows[0];

                string MsgBody = "";


                SendMail SM = new SendMail();
                SM.UseSMTPLoginAsFromField = true;
                SM.Conn = Meta.Conn;

                //if (CurrentStatus == 5) {
                //    // Ciclo sui dettagli variazione card
                //    foreach (DataRow rCardVar in DS.lcardvarview.Rows) {
                //        object idlcard = rCardVar["idlcard"];

                //        string filterCard = QHS.CmpEq("idlcard", idlcard);
                //        DataTable TCard = Meta.Conn.RUN_SELECT("lcard", "*", null, filterCard, null, false);

                //        if (TCard == null || TCard.Rows.Count == 0) continue;

                //        MsgBody = "Sulla Card numero " + TCard.Rows[0]["idlcard"] + " intestata a " + TCard.Rows[0]["title"] + "\r\n";
                //        MsgBody += "è stata effettuata una ricarica di importo pari a " + CfgFn.GetNoNullDecimal(rCardVar["amount"]).ToString("c") + " come richiesto .\r\n";

                //        object mailtoMan = rCardVar["email"];

                //        if (mailtoMan == DBNull.Value) continue;
                //        SM.To = mailtoMan.ToString();
                //        SM.Subject = "Ricarica Card n° " + TCard.Rows[0]["idlcard"] + " effettuata";
                //        SM.MessageBody = MsgBody;

                //        if (!SM.Send()) {
                //            if (SM.ErrorMessage != "") show(SM.ErrorMessage, "Errore");
                //        }
                //    }
                //}

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
                MsgBody = "La variazione di budget numero " + CurrentRow["nvar"] + " relativa all'esercizio " +
                          CurrentRow["yvar"] + "\r\n";
                MsgBody += "E' passata nello stato '" + currstatustext + "'.\r\n";

                if (true) { //CurrentStatus == 3) {
                    MsgBody += " Dettagli:\r\n";
                    if (CurrentRow["description"].ToString() != "")
                        MsgBody += CurrentRow["description"].ToString() + "\r\n";
                    if (CurrentRow["annotation"].ToString() != "")
                        MsgBody += CurrentRow["annotation"].ToString() + "\r\n";
                    MsgBody += "\r\n\r\n";
                    foreach (DataRow RD in DS.accountvardetail.Select()) {
                        MsgBody += GetTextForAccountVarDetail(RD);
                        if (RD["description"].ToString() != "") MsgBody += RD["description"].ToString() + "\r\n";
                        if (RD["annotation"].ToString() != "") MsgBody += RD["annotation"].ToString() + "\r\n";
                    }

                    MsgBody += "\r\n";

                }

                SM.Subject = "Notifica cambiamento di stato variazione di budget";
                SM.MessageBody = MsgBody;

                if (!SM.Send()) {
                    if (SM.ErrorMessage != "") show(SM.ErrorMessage, "Errore");
                }


                DoSendMail = false;
            }
        }

        string GetTextForAccountVarDetail(DataRow R) {
            string S = "";
            object idacc = R["idacc"];
            DataRow Account = DS.account.Select(QHC.CmpEq("idacc", idacc))[0];
            S += "Conto " + Account["codeacc"].ToString() + " - " + Account["title"].ToString() + "\r\n";
            object idupb = R["idupb"];
            DataRow Upb = DS.upb.Select(QHC.CmpEq("idupb", idupb))[0];
            S += "UPB " + Upb["codeupb"].ToString() + " - " + Upb["title"].ToString() + "\r\n";
            S += "Importo variazione:" + CfgFn.GetNoNullDecimal(R["amount"]).ToString("c") + "\r\n";
            ;
            return S;

        }

        public decimal saldoCostiRicavi() {
            object flagObj = null;
            decimal costi = 0;
            decimal ricavi = 0;
            decimal immobilizzazioni = 0;
            if (DS.accountvar.Rows.Count == 0) return 0;

            foreach (DataRow rDettaglio in DS.accountvardetail.Rows) {
                if (rDettaglio.RowState == DataRowState.Deleted) continue;


                DataRow rAccount = DS.account._get(Conn,q.eq("idacc",rDettaglio["idacc"])).First();
                if (rAccount == null) continue;

                flagObj = rAccount["flagaccountusage"];


                if (flagObj != DBNull.Value) {
                    int flag = Convert.ToInt32(flagObj);
                    bool costo = (flag & 64) != 0;
                    bool ricavo = (flag & 128) != 0;
                    bool immobilizzazione = (flag & 256) != 0;

                    decimal somma_amount_quinquennnio = CfgFn.GetNoNullDecimal(rDettaglio["amount"]) +
                                                        CfgFn.GetNoNullDecimal(rDettaglio["amount2"]) +
                                                        CfgFn.GetNoNullDecimal(rDettaglio["amount3"]) +
                                                        CfgFn.GetNoNullDecimal(rDettaglio["amount4"]) +
                                                        CfgFn.GetNoNullDecimal(rDettaglio["amount5"]);
                    if (costo) costi += somma_amount_quinquennnio;
                    if (ricavo) ricavi += somma_amount_quinquennnio;
                    if (immobilizzazione) immobilizzazioni += somma_amount_quinquennnio;

                }


            }

            return ricavi - costi - immobilizzazioni;

        }

        public void MetaData_AfterFill() {
            decimal somma_entrate = MetaData.SumColumn(DS.accountvardetail, "!aumento");
            decimal somma_spese = MetaData.SumColumn(DS.accountvardetail, "!diminuzione");
            decimal saldo = somma_entrate - somma_spese;
            txtSaldo.Text = saldoCostiRicavi().ToString("c");
            EnableDisableVariationKind();
            visualizzaBtnSimulazione();
			EnableDisableStatus();
		}
		private void EnableDisableStatus() {
			if ((Meta.EditMode) || (Meta.InsertMode)) {
				DataRow Curr = DS.accountvar.Rows[0];
				int CurrentStatus = CfgFn.GetNoNullInt32(Curr["idaccountvarstatus"]);
				int CurrentKind = CfgFn.GetNoNullInt32(Curr["variationkind"]); // 6 = Non operativa
				if (CurrentKind == 6) {
					if (CurrentStatus == 5) {
						show(
							"La variazione non può essere Approvata perchè non è operativa. Verrà impostato lo stato 'Inserita'. " +
							"Sarà quindi necessario salvare le modifiche.",
							"Attenzione",
							MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						HelpForm.SetComboBoxValue(cmbStatus, 4);
					}
				}
			}
		}

		private void EnableDisableVariationKind() {
            if ((Meta.IsEmpty) || (Meta.InsertMode)) {
                rdbVarNormale.Enabled = true;
                rdbVarIniziale.Enabled = true;
                rdbStorno.Enabled = true;
                chkPresunto.Visible = true;
            }

            if (Meta.EditMode) {
                DataRow Curr = DS.accountvar.Rows[0];
                int variationkind = CfgFn.GetNoNullInt32(Curr["variationkind"]);
                if (variationkind == 5) { // tipo variazione iniziale
                    rdbVarNormale.Enabled = false;
                    rdbStorno.Enabled = false;
                    rdbVarIniziale.Enabled = true;
                }
                else {
                    rdbVarNormale.Enabled = true;
                    rdbStorno.Enabled = true;
                    rdbVarIniziale.Enabled = false;
                }
            }

            if (Meta.EditMode || Meta.InsertMode) {
                DataRow Curr = DS.accountvar.Rows[0];
                int variationkind = CfgFn.GetNoNullInt32(Curr["variationkind"]);
                chkPresunto.Visible = (variationkind == 5);
            }

        }

        private void btnSimula_Click(object sender, EventArgs e) {
            applicaSimulazione();
        }

        private void btnScegliAtto_Click(object sender, EventArgs e) {

        }
    }
}
