/*
    Easy
    Copyright (C) 2020 UniversitÃ  degli Studi di Catania (www.unict.it)
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
using funzioni_configurazione;
using System.Data;

namespace admpay_appropriation_detail {
	/// <summary>
	/// Summary description for FrmAdmPay_Appropriation_Detail.
	/// </summary>
	public class FrmAdmPay_Appropriation_Detail : System.Windows.Forms.Form {
        bool InChiusura = false;
		MetaData Meta;
		string lastUpbFin = "";
        string filterOnReg = "";
		object lastIdExp = DBNull.Value;
		decimal importoResiduo;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox gboxNormale;
		public System.Windows.Forms.GroupBox grpBilancio;
		private System.Windows.Forms.CheckBox chkListTitle;
		private System.Windows.Forms.CheckBox chkFilterAvailable;
		private System.Windows.Forms.Button btnBilancio;
		public System.Windows.Forms.TextBox txtCodiceBilancio;
		private System.Windows.Forms.TextBox txtDenominazioneBilancio;
		private System.Windows.Forms.GroupBox gboxSpesa;
		private System.Windows.Forms.TextBox txtNum;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox txtEserc;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.ComboBox cmbFaseSpesa;
		private System.Windows.Forms.Button btnSpesa;
		private System.Windows.Forms.CheckBox chkSpesa;
		public admpay_appropriation_detail.vistaForm DS;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.TextBox txtImporto;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
        private Label lblWarning;
        private GroupBox gboxUPB;
        public TextBox txtUPB;
        private Button btnUPB;
        private TextBox txtDescrUPB;
        private System.ComponentModel.IContainer components;

		public FrmAdmPay_Appropriation_Detail() {
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
            InChiusura = true;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAdmPay_Appropriation_Detail));
            this.DS = new admpay_appropriation_detail.vistaForm();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtImporto = new System.Windows.Forms.TextBox();
            this.gboxNormale = new System.Windows.Forms.GroupBox();
            this.grpBilancio = new System.Windows.Forms.GroupBox();
            this.chkListTitle = new System.Windows.Forms.CheckBox();
            this.chkFilterAvailable = new System.Windows.Forms.CheckBox();
            this.btnBilancio = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.txtCodiceBilancio = new System.Windows.Forms.TextBox();
            this.txtDenominazioneBilancio = new System.Windows.Forms.TextBox();
            this.gboxSpesa = new System.Windows.Forms.GroupBox();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtEserc = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbFaseSpesa = new System.Windows.Forms.ComboBox();
            this.btnSpesa = new System.Windows.Forms.Button();
            this.chkSpesa = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblWarning = new System.Windows.Forms.Label();
            this.gboxUPB = new System.Windows.Forms.GroupBox();
            this.txtUPB = new System.Windows.Forms.TextBox();
            this.btnUPB = new System.Windows.Forms.Button();
            this.txtDescrUPB = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.gboxNormale.SuspendLayout();
            this.grpBilancio.SuspendLayout();
            this.gboxSpesa.SuspendLayout();
            this.gboxUPB.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "Num Impegnativa:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(104, 8);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 2;
            this.textBox3.Tag = "admpay_appropriation.nappropriation";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(216, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Importo da assegnare:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtImporto
            // 
            this.txtImporto.Location = new System.Drawing.Point(344, 8);
            this.txtImporto.Name = "txtImporto";
            this.txtImporto.Size = new System.Drawing.Size(100, 20);
            this.txtImporto.TabIndex = 4;
            this.txtImporto.Tag = "admpay_appropriation.amount";
            // 
            // gboxNormale
            // 
            this.gboxNormale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxNormale.Controls.Add(this.gboxUPB);
            this.gboxNormale.Controls.Add(this.grpBilancio);
            this.gboxNormale.Location = new System.Drawing.Point(8, 120);
            this.gboxNormale.Name = "gboxNormale";
            this.gboxNormale.Size = new System.Drawing.Size(440, 208);
            this.gboxNormale.TabIndex = 5;
            this.gboxNormale.TabStop = false;
            this.gboxNormale.Text = "Imputazione normale";
            // 
            // grpBilancio
            // 
            this.grpBilancio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBilancio.Controls.Add(this.chkListTitle);
            this.grpBilancio.Controls.Add(this.chkFilterAvailable);
            this.grpBilancio.Controls.Add(this.btnBilancio);
            this.grpBilancio.Controls.Add(this.txtCodiceBilancio);
            this.grpBilancio.Controls.Add(this.txtDenominazioneBilancio);
            this.grpBilancio.Location = new System.Drawing.Point(16, 96);
            this.grpBilancio.Name = "grpBilancio";
            this.grpBilancio.Size = new System.Drawing.Size(416, 104);
            this.grpBilancio.TabIndex = 1;
            this.grpBilancio.TabStop = false;
            this.grpBilancio.Tag = "AutoManage.txtCodiceBilancio.treesupb.(idupb=\'0001\')";
            // 
            // chkListTitle
            // 
            this.chkListTitle.Location = new System.Drawing.Point(8, 32);
            this.chkListTitle.Name = "chkListTitle";
            this.chkListTitle.Size = new System.Drawing.Size(296, 16);
            this.chkListTitle.TabIndex = 15;
            this.chkListTitle.TabStop = false;
            this.chkListTitle.Text = "Cerca per denominazione";
            // 
            // chkFilterAvailable
            // 
            this.chkFilterAvailable.Checked = true;
            this.chkFilterAvailable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFilterAvailable.Location = new System.Drawing.Point(8, 16);
            this.chkFilterAvailable.Name = "chkFilterAvailable";
            this.chkFilterAvailable.Size = new System.Drawing.Size(288, 16);
            this.chkFilterAvailable.TabIndex = 13;
            this.chkFilterAvailable.TabStop = false;
            this.chkFilterAvailable.Text = "Filtra per disponibilità sufficiente";
            // 
            // btnBilancio
            // 
            this.btnBilancio.BackColor = System.Drawing.SystemColors.Control;
            this.btnBilancio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBilancio.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBilancio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBilancio.ImageIndex = 0;
            this.btnBilancio.ImageList = this.imageList1;
            this.btnBilancio.Location = new System.Drawing.Point(8, 48);
            this.btnBilancio.Name = "btnBilancio";
            this.btnBilancio.Size = new System.Drawing.Size(120, 23);
            this.btnBilancio.TabIndex = 1;
            this.btnBilancio.TabStop = false;
            this.btnBilancio.Tag = "";
            this.btnBilancio.Text = "Bilancio:";
            this.btnBilancio.UseVisualStyleBackColor = false;
            this.btnBilancio.Click += new System.EventHandler(this.btnBilancio_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            // 
            // txtCodiceBilancio
            // 
            this.txtCodiceBilancio.Location = new System.Drawing.Point(8, 72);
            this.txtCodiceBilancio.Name = "txtCodiceBilancio";
            this.txtCodiceBilancio.Size = new System.Drawing.Size(120, 20);
            this.txtCodiceBilancio.TabIndex = 0;
            this.txtCodiceBilancio.Tag = "finview.codefin?admpay_appropriationview.codefin";
            // 
            // txtDenominazioneBilancio
            // 
            this.txtDenominazioneBilancio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenominazioneBilancio.Location = new System.Drawing.Point(144, 48);
            this.txtDenominazioneBilancio.Multiline = true;
            this.txtDenominazioneBilancio.Name = "txtDenominazioneBilancio";
            this.txtDenominazioneBilancio.ReadOnly = true;
            this.txtDenominazioneBilancio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDenominazioneBilancio.Size = new System.Drawing.Size(264, 48);
            this.txtDenominazioneBilancio.TabIndex = 2;
            this.txtDenominazioneBilancio.TabStop = false;
            this.txtDenominazioneBilancio.Tag = "finview.title";
            // 
            // gboxSpesa
            // 
            this.gboxSpesa.Controls.Add(this.txtNum);
            this.gboxSpesa.Controls.Add(this.label13);
            this.gboxSpesa.Controls.Add(this.txtEserc);
            this.gboxSpesa.Controls.Add(this.label12);
            this.gboxSpesa.Controls.Add(this.cmbFaseSpesa);
            this.gboxSpesa.Controls.Add(this.btnSpesa);
            this.gboxSpesa.Location = new System.Drawing.Point(8, 389);
            this.gboxSpesa.Name = "gboxSpesa";
            this.gboxSpesa.Size = new System.Drawing.Size(440, 104);
            this.gboxSpesa.TabIndex = 7;
            this.gboxSpesa.TabStop = false;
            this.gboxSpesa.Text = "Selezione del movimento di Spesa a cui collegare il pagamento stipendi";
            // 
            // txtNum
            // 
            this.txtNum.Location = new System.Drawing.Point(56, 64);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(80, 20);
            this.txtNum.TabIndex = 3;
            this.txtNum.Tag = "expenseview.nmov?admpay_appropriationview.nmov";
            this.txtNum.Leave += new System.EventHandler(this.txtNum_Leave);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(16, 72);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 16);
            this.label13.TabIndex = 4;
            this.label13.Text = "Num.";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEserc
            // 
            this.txtEserc.Location = new System.Drawing.Point(56, 40);
            this.txtEserc.Name = "txtEserc";
            this.txtEserc.Size = new System.Drawing.Size(56, 20);
            this.txtEserc.TabIndex = 2;
            this.txtEserc.Tag = "expenseview.ymov.year?admpay_appropriationview.ymov.year";
            this.txtEserc.Leave += new System.EventHandler(this.txtEserc_Leave);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(16, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 16);
            this.label12.TabIndex = 2;
            this.label12.Text = "Eserc.";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbFaseSpesa
            // 
            this.cmbFaseSpesa.DataSource = this.DS.expensephase;
            this.cmbFaseSpesa.DisplayMember = "description";
            this.cmbFaseSpesa.Location = new System.Drawing.Point(8, 16);
            this.cmbFaseSpesa.Name = "cmbFaseSpesa";
            this.cmbFaseSpesa.Size = new System.Drawing.Size(232, 21);
            this.cmbFaseSpesa.TabIndex = 1;
            this.cmbFaseSpesa.Tag = "expenseview.nphase?admpay_appropriationview.nphase";
            this.cmbFaseSpesa.ValueMember = "nphase";
            // 
            // btnSpesa
            // 
            this.btnSpesa.Location = new System.Drawing.Point(296, 16);
            this.btnSpesa.Name = "btnSpesa";
            this.btnSpesa.Size = new System.Drawing.Size(128, 23);
            this.btnSpesa.TabIndex = 0;
            this.btnSpesa.TabStop = false;
            this.btnSpesa.Text = "Scegli Movimento";
            this.btnSpesa.Click += new System.EventHandler(this.btnSpesa_Click);
            // 
            // chkSpesa
            // 
            this.chkSpesa.Location = new System.Drawing.Point(8, 362);
            this.chkSpesa.Name = "chkSpesa";
            this.chkSpesa.Size = new System.Drawing.Size(256, 24);
            this.chkSpesa.TabIndex = 6;
            this.chkSpesa.Text = "Abilita selezione del movimento di spesa";
            this.chkSpesa.CheckedChanged += new System.EventHandler(this.chkSpesa_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(248, 499);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Annulla";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(136, 499);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 12;
            this.btnOk.Tag = "mainsave";
            this.btnOk.Text = "Ok";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Descrizione:";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(8, 56);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(440, 56);
            this.textBox1.TabIndex = 15;
            this.textBox1.Tag = "admpay_appropriation.description";
            // 
            // lblWarning
            // 
            this.lblWarning.Location = new System.Drawing.Point(8, 333);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(440, 32);
            this.lblWarning.TabIndex = 16;
            this.lblWarning.Text = "Sezione disabilitata in quanto sono associati al\'impegnativa più meta movimenti c" +
    "he hanno una anagrafica distinta e, la fase di spesa associata all\'anagrafica è " +
    "la prima";
            // 
            // gboxUPB
            // 
            this.gboxUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxUPB.Controls.Add(this.txtUPB);
            this.gboxUPB.Controls.Add(this.btnUPB);
            this.gboxUPB.Controls.Add(this.txtDescrUPB);
            this.gboxUPB.Location = new System.Drawing.Point(16, 14);
            this.gboxUPB.Name = "gboxUPB";
            this.gboxUPB.Size = new System.Drawing.Size(416, 82);
            this.gboxUPB.TabIndex = 2;
            this.gboxUPB.TabStop = false;
            this.gboxUPB.Tag = "AutoChoose.txtUPB.default.(active=\'S\')";
            // 
            // txtUPB
            // 
            this.txtUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUPB.Location = new System.Drawing.Point(6, 53);
            this.txtUPB.Name = "txtUPB";
            this.txtUPB.Size = new System.Drawing.Size(132, 20);
            this.txtUPB.TabIndex = 7;
            this.txtUPB.Tag = "upb.codeupb?x";
            // 
            // btnUPB
            // 
            this.btnUPB.Location = new System.Drawing.Point(7, 19);
            this.btnUPB.Name = "btnUPB";
            this.btnUPB.Size = new System.Drawing.Size(130, 24);
            this.btnUPB.TabIndex = 1;
            this.btnUPB.TabStop = false;
            this.btnUPB.Tag = "manage.upb.tree";
            this.btnUPB.Text = "UPB";
            // 
            // txtDescrUPB
            // 
            this.txtDescrUPB.Location = new System.Drawing.Point(144, 14);
            this.txtDescrUPB.Multiline = true;
            this.txtDescrUPB.Name = "txtDescrUPB";
            this.txtDescrUPB.ReadOnly = true;
            this.txtDescrUPB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescrUPB.Size = new System.Drawing.Size(264, 62);
            this.txtDescrUPB.TabIndex = 2;
            this.txtDescrUPB.TabStop = false;
            this.txtDescrUPB.Tag = "upb.title";
            // 
            // FrmAdmPay_Appropriation_Detail
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(456, 529);
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.gboxSpesa);
            this.Controls.Add(this.chkSpesa);
            this.Controls.Add(this.gboxNormale);
            this.Controls.Add(this.txtImporto);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Name = "FrmAdmPay_Appropriation_Detail";
            this.Text = "FrmAdmPay_Appropriation_Detail";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.gboxNormale.ResumeLayout(false);
            this.grpBilancio.ResumeLayout(false);
            this.grpBilancio.PerformLayout();
            this.gboxSpesa.ResumeLayout(false);
            this.gboxSpesa.PerformLayout();
            this.gboxUPB.ResumeLayout(false);
            this.gboxUPB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        CQueryHelper QHC;
        QueryHelper QHS;
        DataTable tAdmPayExpense;
		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
			string filterEsercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
			string filter = QHS.AppAnd(filterEsercizio, QHS.BitSet("flag", 0));
			GetData.SetStaticFilter(DS.expenseview, filterEsercizio);
			GetData.SetStaticFilter(DS.finview, filter);
			grpBilancio.Tag+="."+filter;
			btnBilancio.Tag+="."+filter;

            tAdmPayExpense = DataAccess.CreateTableByName(Meta.Conn, "admpay_expense", "*");
            GetData.SetSorting(DS.expensephase, "nphase");
            if (Meta.EditMode) {
                DataRow CurrRow = Meta.SourceRow;
                string f = QHS.CmpKey(CurrRow);
                DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tAdmPayExpense, null, f, null, true);
                string f_expphase = calcolaFiltroSuExpensePhase();
                if (f_expphase != null) {
                    GetData.SetStaticFilter(DS.expensephase, f_expphase);
                }
            }
		}

		public void MetaData_AfterActivation() {
			if (DS.admpay_appropriation.Rows.Count==0) return;
            impostaFilterOnReg();
            manageSezMovimento();

            DataRow CurrRow = DS.admpay_appropriation.Rows[0];
			importoResiduo = CfgFn.GetNoNullDecimal(Meta.ExtraParameter);
			lastUpbFin = CurrRow["idupb"].ToString() + "§" + CurrRow["idfin"].ToString();
			lastIdExp = CurrRow["idexp"];
		}

        /// <summary>
        /// Metodo che riempie la tabella EXPENSEPHASE in base ai meta movimenti associati alla impegnativa
        /// </summary>
        private string calcolaFiltroSuExpensePhase() {
            // Nel caso in cui la tabella dei meta movimenti sia nulla o vuota o abbia un solo meta movimento
            // allora vengono prese tutte le fasi di spesa
            if ((tAdmPayExpense == null) || (tAdmPayExpense.Rows.Count <= 1)) {
                return null;
            }

            int nAnagrafica = 0;
            int currAnagrafica = 0;
            int prevAnagrafica = 0;
            foreach (DataRow r in tAdmPayExpense.Select(null, "idreg")) {
                currAnagrafica = CfgFn.GetNoNullInt32(r["idreg"]);
                if (currAnagrafica != prevAnagrafica) nAnagrafica++;
                prevAnagrafica = currAnagrafica;
            }
            int faseMax = 0;
            // Se i movimenti associati all'impegnativa hanno anagrafiche differenti, potrò avere solamente fasi
            // di spesa senza anagrafica
            if (nAnagrafica <= 1) return null;
            faseMax = CfgFn.GetNoNullInt32(Meta.GetSys("expenseregphase")) - 1;
            return QHS.CmpLe("nphase", faseMax);
        }

        private void impostaFilterOnReg() {
            if (tAdmPayExpense.Rows.Count == 1) {
                object idreg = tAdmPayExpense.Rows[0]["idreg"];
                filterOnReg = QHS.NullOrEq("idreg", idreg);
                return;
            }
            if (tAdmPayExpense.Rows.Count > 1) {
                int nAnagrafica = 0;
                int currAnagrafica = 0;
                int prevAnagrafica = 0;
                object firstNotNullIdreg = null;
                foreach (DataRow r in tAdmPayExpense.Select(null, "idreg")) {
                    currAnagrafica = CfgFn.GetNoNullInt32(r["idreg"]);
                    if (currAnagrafica != prevAnagrafica) {
                        if (currAnagrafica != 0) firstNotNullIdreg = r["idreg"];
                        nAnagrafica++;
                    }
                    prevAnagrafica = currAnagrafica;

                }

                if ((nAnagrafica == 1) && (firstNotNullIdreg != null)){
                    filterOnReg = QHS.NullOrEq("idreg", firstNotNullIdreg);
                }
            }
        }

        private void manageSezMovimento() {
            if (DS.expensephase.Rows.Count <= 1) {
                EnableDisableParteSpesa(false);
                lblWarning.Visible = true;
                chkSpesa.Enabled = false;
            }
            else {
                EnableDisableParteSpesa(true);
                lblWarning.Visible = false;
                chkSpesa.Enabled = true;
            }
        }

		public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
			if (Meta.IsEmpty) return;
			if (T.TableName == "upb"){
                object idupb = "0001";
				if (R!=null) {
					idupb = R["idupb"];
				}
				MetaData.AutoInfo AI;
				AI = Meta.GetAutoInfo(txtCodiceBilancio.Name);
				string filter=QHC.CmpEq("idupb", idupb);
				if (AI!=null) AI.startfilter=filter;
				DS.finview.ExtendedProperties[MetaData.ExtraParams]= filter;
			}
			if (T.TableName == "finview") {
				DataRow Curr = DS.admpay_appropriation.Rows[0];
				if (R!= null) {
					object currUpb = Curr["idupb"];
					object currFin = R["idfin"];
					string currUpbFin = currUpb + "§" + currFin;
					if (lastUpbFin != currUpbFin) {
						ricalcolaImporto(R["availableprevision"]);
					}
					lastUpbFin = currUpbFin;
				}
				else {
					lastUpbFin = Curr["idupb"].ToString() + "§";
				}
			}
			if (T.TableName == "expenseview") {
				if (R != null) {
					ricalcolaImporto(R["available"]);
				}
			}
		}

		public void MetaData_AfterFill() {
            if (Meta.FirstFillForThisRow) {
                fillFinGroupWithoutUPB();
                ImpostaCheckSpesa();
            }
		}

        private void fillFinGroupWithoutUPB() {
            if (DS.admpay_appropriation.Rows.Count == 0) return;
            DataRow Curr = DS.admpay_appropriation.Rows[0];
            if (Curr["idupb"] != DBNull.Value) return;
            if (Curr["idfin"] == DBNull.Value) return;
            object idupb = "0001";
            string f = QHC.AppAnd(QHC.CmpEq("idupb", idupb), QHC.CmpEq("idfin", Curr["idfin"]));
            DataRow[] Bil = DS.finview.Select(f);
            if (Bil.Length == 0) {
                Meta.Conn.RUN_SELECT_INTO_TABLE(DS.finview, null, f, null, true);
                Bil = DS.finview.Select(f);
                if (Bil.Length == 0) return;
            }
            txtCodiceBilancio.Text = Bil[0]["codefin"].ToString();
            txtDenominazioneBilancio.Text = Bil[0]["title"].ToString();
        }

		/// <summary>
		/// Metodo che assegna all'importo dell'impegno o la previsione principale disponibile della coppia UPB-Bilancio
		/// scelto o il disponibile del movimento di spesa scelto
		/// </summary>
		/// <param name="disponibile">Importo disponibile da assegnare all'impegno</param>
		private void ricalcolaImporto(object disponibile) {
			if (Meta.IsEmpty) return;
			if (DS.admpay_appropriation.Rows.Count == 0) return;

			decimal importo = CfgFn.GetNoNullDecimal(disponibile);
			// Se l'importo che viene suggerito è supeiore al residuo del pagamento stipendi allora inserisco
			// proprio il residuo del pagamento stipendi
			if (importo > importoResiduo) importo = importoResiduo;
			decimal importoImpegnativa = CfgFn.GetNoNullDecimal(
				HelpForm.GetObjectFromString(typeof(decimal),txtImporto.Text, txtImporto.Tag.ToString()));
			if ((Meta.EditMode) && (importoImpegnativa != importo)) {
				DialogResult dr = MessageBox.Show(this,"Attenzione! Procedo a cambiare l'importo dell'impegnativa?","Attenzione!", 
					MessageBoxButtons.YesNoCancel,MessageBoxIcon.Information);
				if (dr != DialogResult.Yes) return;
			}
			txtImporto.Text = importo.ToString("c");
			DataRow Curr = DS.admpay_appropriation.Rows[0];
			Curr["amount"] = importo;
		}

		private void btnSpesa_Click(object sender, System.EventArgs e) {
			if (Meta.IsEmpty)return;
			Meta.GetFormData(true);
			DataTable Fasi2=  DS.expensephase.Copy();

            string filterPhase = QHC.AppOr(QHC.CmpEq("nphase", Meta.GetSys("maxexpensephase")),
                QHC.CmpLt("nphase", Meta.GetSys("expensefinphase")));
			foreach (DataRow ToDel in Fasi2.Select(filterPhase)){
				ToDel.Delete();
			}
			Fasi2.AcceptChanges();

			DataRow Curr=DS.admpay_appropriation.Rows[0];
			decimal importo = CfgFn.GetNoNullDecimal(Curr["amount"]);
		    var f = new AskInfo.FrmAskInfo(Meta, "S", true);
		    f.EnableFilterAvailable(importo);
		    f.allowSelectPhase("Seleziona la fase del movimento a cui collegare il pagamento degli stipendi");
		    f.askUpbAs("UPB da associare ai dettagli ai quali non è stato attribuito");

			//FrmAskFase F = new FrmAskFase("S", importo, Fasi2, DS.upb, DS.finview, Meta.Dispatcher, Meta.Conn);
            
			if (f.ShowDialog()!=DialogResult.OK) return;
			int selectedfase = CfgFn.GetNoNullInt32(f.GetFaseMovimento() );//F.cmbFasi.SelectedValue
			string filter="";
			string filterUpb = QHS.CmpEq("idupb", "0001");
			string filterFin = "";
			if (selectedfase>0) filter=GetData.MergeFilters(filter,QHS.CmpEq("nphase", selectedfase));
			// Aggiunta filtro dell'UPB e del Bilancio
		    object idupb = f.GetUPB();
			if (idupb!=DBNull.Value){
					filterUpb = QHS.CmpEq("idupb",idupb);
			}

		    object idfin = f.GetFin();
		    if (idfin != DBNull.Value) {
		        filterFin = QHS.CmpEq("idfin", idfin);
		    }
			filter = GetData.MergeFilters(filter,filterUpb);
			if (filterFin != "") {
				filter = GetData.MergeFilters(filter,filterFin);
			}
			
			if (importo>0) {
				filter=GetData.MergeFilters(filter, QHS.CmpGe("available", importo));
				}
			else {
				filter=GetData.MergeFilters(filter,QHS.CmpGt("available", 0));
			}

            int faseScelta = selectedfase;
            int faseRegistry = CfgFn.GetNoNullInt32(Meta.GetSys("expenseregphase"));
            if (faseScelta >= faseRegistry) {
                filter = QHS.AppAnd(filter, filterOnReg);
            }

			MetaData E = Meta.Dispatcher.Get("expense");
			E.FilterLocked=true;
			E.DS= DS.Clone();
			DataRow Choosen  = E.SelectOne("default",filter,"expense",null);
			if (Choosen==null) {
				lastIdExp = DBNull.Value;
				return;
			}
			Curr["idexp"]= Choosen["idexp"];
			if (!lastIdExp.Equals(Choosen["idexp"])) {
				ricalcolaImporto(Choosen["available"]);
			}
			lastIdExp = Choosen["idexp"];
			DS.expenseview.Clear();
			Meta.Conn.RUN_SELECT_INTO_TABLE(DS.expenseview,null,
				QHS.AppAnd(QHS.CmpEq("idexp", Curr["idexp"]), QHS.CmpEq("ayear", Meta.GetSys("esercizio"))),
				null,true);
			Meta.FreshForm(false);
		}

		private void btnBilancio_Click(object sender, System.EventArgs e) {
			string filter;

			int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
            string filteridfin = QHS.AppAnd(QHS.CmpEq("ayear", esercizio), QHS.BitSet("flag", 0));
						
			//Il filtro sull'UPB c'è sempre
            object idupb = Meta.GetAutoField(txtUPB);
            if (idupb == null) idupb = DBNull.Value;

            if (idupb != DBNull.Value) {
                filter = QHS.CmpEq("idupb", idupb);
            }
            else {
                filter = QHS.CmpEq("idupb", "0001");
            }

            filter = QHS.AppAnd(filteridfin, filter);
			
			//Aggiunge eventualmente il filtro sul disponibile
			if (chkFilterAvailable.Checked){
				decimal currval=0;
				
				if (txtImporto.Text.Trim()!=""){
					currval= CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(
						typeof(decimal),txtImporto.Text,"x.y.c"));
				}

                filter = GetData.MergeFilters(filter, QHS.CmpGe("availableprevision", currval));
			}

			string filteroperativo= "(idfin in (SELECT idfin from finusable where " +
            QHS.CmpEq("ayear", Meta.GetSys("esercizio")) + "))";
			if (chkListTitle.Checked){
				FrmAskDescr FR= new FrmAskDescr(0);
				DialogResult D = FR.ShowDialog(this);
				if (D!= DialogResult.OK) return;
				filter = GetData.MergeFilters(filter, QHS.Like("title", "%"+FR.txtDescrizione.Text+"%"));
				filter= GetData.MergeFilters(filter,filteroperativo);
				MetaData.DoMainCommand(this,"choose.finview.default."+filter);
				return;
			}
			DS.finview.ExtendedProperties[MetaData.ExtraParams]=filter;
			MetaData.DoMainCommand(this,"manage.finview.treesupb");
		}

		private void chkSpesa_CheckedChanged(object sender, System.EventArgs e) {
			if (chkSpesa.Checked){
				EnableDisable(false);
				if (Meta.IsEmpty) return;
				DataRow R= DS.admpay_appropriation.Rows[0];
				if ((R["idfin"]!=DBNull.Value) ||
					(R["idupb"]!=DBNull.Value)) {
					if (MessageBox.Show("Per abilitare la selezione del movimento di spesa è necessario annullare le altre "+
						"attribuzioni su questo pagamento stipendi. Proseguo?","Conferma",
						MessageBoxButtons.OKCancel)!=DialogResult.OK) {
						chkSpesa.Checked=false;
						return;
					}
					lastUpbFin = "";
					R["idfin"]=DBNull.Value;
					R["idupb"]=DBNull.Value;
					DS.finview.Clear();
					txtCodiceBilancio.Text="";
					txtDenominazioneBilancio.Text="";
                    txtDescrUPB.Text = "";
					txtUPB.Text="";
					return;
				}
				lastUpbFin = "";
				return;
			}
			if (Meta.IsEmpty) return;
			
			EnableDisable(true);

			DataRow RR= DS.admpay_appropriation.Rows[0];

			if ( RR["idexp"]!=DBNull.Value){
				if (MessageBox.Show("Per abilitare la selezione delle attribuzioni normali su questa operazione è necessario annullare il collegamento al movimento di spesa "+
					". Proseguo?","Conferma",
					MessageBoxButtons.OKCancel)!=DialogResult.OK) {
					chkSpesa.Checked=true;
					return;
				}
				lastIdExp = DBNull.Value;
				RR["idexp"]=DBNull.Value;
				DS.expenseview.Clear();
				cmbFaseSpesa.SelectedIndex=0;
				txtEserc.Text="";
				txtNum.Text="";
			}
			lastIdExp = DBNull.Value;
		}

		void DisableAll(){
			EnableDisableParteNormale(false);
			EnableDisableParteSpesa(false);
		}

		void EnableDisableParteSpesa(bool enable){
			txtEserc.ReadOnly=!enable;
			txtNum.ReadOnly=!enable;
			cmbFaseSpesa.Enabled=enable;
			btnSpesa.Enabled=enable;

		}
		void EnableDisableParteNormale(bool enable){
			btnBilancio.Enabled = enable;
			btnUPB.Enabled = enable;
			txtUPB.Enabled = enable;
			txtCodiceBilancio.ReadOnly = !enable;
		}

		void EnableDisable(bool parteNormale){
			EnableDisableParteNormale(parteNormale);
			EnableDisableParteSpesa(!parteNormale);
		}

		/// <summary>
		/// Abilita/disabilita il checkbox Spesa e la parte di attribuzione bilancio/idspesa
		/// </summary>
		void ImpostaCheckSpesa(){
			if (Meta.IsEmpty){
				EnableDisable(true);
				gboxNormale.Visible=true;
				gboxSpesa.Visible=false;
				chkSpesa.Visible=false;
				return;
			}
			chkSpesa.Visible=true;
			gboxNormale.Visible=true;
			gboxSpesa.Visible=true;
			chkSpesa.Visible=true;

			chkSpesa.Visible=true;

			DataRow R = DS.admpay_appropriation.Rows[0];
			if (R["idexp"]!=DBNull.Value) 
				chkSpesa.Checked=true;
			else 
				chkSpesa.Checked=false;
			chkSpesa_CheckedChanged(null,null);
		}

        private void txtEserc_Leave(object sender, EventArgs e) {
            if (InChiusura) return;

            string esercspesa = txtEserc.Text.Trim();
            if (esercspesa == "") {
                MetaData.Choose(this, "choose.expenseview.unknown.clear");
                return;
            }

            //if txtEserc is not Empty:
            if (Meta.IsEmpty) return;

            if (DS.expenseview.Rows.Count > 0) {
                if (esercspesa == DS.expenseview.Rows[0]["ymov"].ToString())
                    return;
                else {
                    ClearSpesa(false);
                    return;
                }
            }		
        }

        private void txtNum_Leave(object sender, EventArgs e) {
            if (InChiusura) return;
            if (txtNum.Text.Trim() != "") {
                DoChooseCommand((Control)sender);
                return;
            }
            //if txtNumentrata is empty:
            if (Meta.IsEmpty) return;
            ClearSpesa(false);	
        }

        private void ClearSpesa(bool ClearEsercizio) {
            txtNum.Text = "";
            if (ClearEsercizio) txtEserc.Text = "";
            if (Meta.IsEmpty) return;
            DS.admpay_appropriation.Rows[0]["idexp"] = 0;
            DS.expenseview.Clear();
        }

        private void DoChooseCommand(Control sender) {
            string mycommand = "choose.expenseview.movimentospesa";
            string filter1 = Meta.myHelpForm.GetSpecificCondition(gboxSpesa.Controls, "expenseview");
            DataRow Curr = DS.admpay_appropriation.Rows[0];
            decimal importo = CfgFn.GetNoNullDecimal(Curr["amount"]);
            string fAmount = "";
            if (importo > 0) {
                fAmount = QHS.CmpGe("available", importo);
            }
            else {
                fAmount = QHS.CmpGt("available", 0);
            }

            filter1 = QHS.AppAnd(filter1, fAmount);

            if (cmbFaseSpesa.SelectedIndex > 0) {
                int faseScelta = CfgFn.GetNoNullInt32(cmbFaseSpesa.SelectedValue);
                int faseRegistry = CfgFn.GetNoNullInt32(Meta.GetSys("expenseregphase"));
                if (faseScelta >= faseRegistry) {
                    filter1 = QHS.AppAnd(filter1, filterOnReg);
                }
            }

            if (filter1 != "") mycommand += "." + filter1;
            if (!MetaData.Choose(this, mycommand)) {
                if (sender != null) sender.Focus();
            }
        }

        
	}
}