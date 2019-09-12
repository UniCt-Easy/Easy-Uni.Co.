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
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using System.Data;
using funzioni_configurazione;
using admpay_appropriation_choose;

namespace admpay_admintax_detail {
	/// <summary>
	/// Summary description for FrmAdmPay_AdminTax_Detail.
	/// </summary>
	public class FrmAdmPay_AdminTax_Detail : System.Windows.Forms.Form {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		MetaData Meta;
		public admpay_admintax_detail.vistaForm DS;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.GroupBox gboxSpesa;
		private System.Windows.Forms.TextBox txtNum;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox txtEserc;
		private System.Windows.Forms.Label label12;
		public System.Windows.Forms.GroupBox grpCentroSpesa;
		public System.Windows.Forms.GroupBox grpBilancio;
		public System.Windows.Forms.TextBox txtCodiceBilancio;
		public System.Windows.Forms.TextBox txtUpb;
		private System.Windows.Forms.GroupBox gboxBilancio;
		private System.Windows.Forms.TextBox txtFase;
		private System.Windows.Forms.Button btnImpegnativa;
		private System.Windows.Forms.ComboBox cmbImpegnativa;
		private System.ComponentModel.Container components = null;

		public FrmAdmPay_AdminTax_Detail() {
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

        CQueryHelper QHC;
        QueryHelper QHS;
		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
			string filter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
			GetData.SetStaticFilter(DS.finview, filter);
			GetData.SetStaticFilter(DS.expenseview, filter);
		}

		public void MetaData_BeforeActivation() {
			DataRow rowInParentDS = Meta.SourceRow;
			if (rowInParentDS == null) return;
			string filter = QHS.MCmp(rowInParentDS, new string [] {"yadmpay", "nadmpay"});
			GetData.CacheTable(DS.admpay_appropriationview, filter,"description", true);
		}

		public void MetaData_AfterRowSelect(DataTable T, DataRow R){
			if (Meta.IsEmpty) return;
			if (T.TableName == "admpay_appropriationview") {
				if (R != null) {
					ChangeImputazione(R);
				}
				else {
					ChangeImputazione(null);
				}
			}
		}

		public void MetaData_AfterFill() {
			if (DS.admpay_admintax.Rows.Count == 0) return;
			DataRow Curr = DS.admpay_admintax.Rows[0];
			
			if (Meta.FirstFillForThisRow) {
                string filter = QHC.MCmp(Curr, new string[] { "yadmpay", "nadmpay", "nappropriation" });
				DataRow [] rImpegnativa = DS.admpay_appropriationview.Select(filter);
				DataRow rImp = rImpegnativa.Length > 0 ? rImpegnativa[0] : null;
				ChangeImputazione(rImp);
			}
		}

		private void ChangeImputazione(DataRow rImpegnativa) {
			if (Meta.IsEmpty) return;
			if (DS.admpay_admintax.Rows.Count == 0) return;
			DataRow Curr = DS.admpay_admintax.Rows[0];
			if (rImpegnativa == null) {
				gboxBilancio.Visible = false;
				gboxSpesa.Visible = false;
				return;
			}
			if (rImpegnativa["idexp"] != DBNull.Value) {
				gboxBilancio.Visible = false;
				gboxSpesa.Visible = true;
				DS.expenseview.Clear();
				string filterExpense = QHS.CmpEq("idexp", rImpegnativa["idexp"]);
				Meta.Conn.RUN_SELECT_INTO_TABLE(DS.expenseview, "ymov, nmov, nphase", filterExpense, null, true);
				DataRow rExpenseView = DS.expenseview.Select(filterExpense)[0];
				txtFase.Text = rExpenseView["phase"].ToString();
				txtEserc.Text = CfgFn.GetNoNullInt32(rExpenseView["ymov"]).ToString();
				txtNum.Text = CfgFn.GetNoNullInt32(rExpenseView["nmov"]).ToString();
				txtCodiceBilancio.Text = "";
				txtUpb.Text = "";
				return;
			}
			if (rImpegnativa["idupb"] != DBNull.Value) {
				gboxBilancio.Visible = true;
				gboxSpesa.Visible = false;
				DS.finview.Clear();
                string filterFin = QHS.MCmp(rImpegnativa, new string[] { "idupb", "idfin" });
				Meta.Conn.RUN_SELECT_INTO_TABLE(DS.finview, "codeupb,codefin", filterFin, null, true);
				DataRow rFinView = DS.finview.Select(filterFin)[0];
				txtCodiceBilancio.Text = rFinView["codefin"].ToString();
				txtUpb.Text = rFinView["codeupb"].ToString();
				txtFase.Text = "";
				txtEserc.Text = "";
				txtNum.Text = "";
			}
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.DS = new admpay_admintax_detail.vistaForm();
			this.button3 = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.button1 = new System.Windows.Forms.Button();
			this.cmbImpegnativa = new System.Windows.Forms.ComboBox();
			this.btnImpegnativa = new System.Windows.Forms.Button();
			this.gboxSpesa = new System.Windows.Forms.GroupBox();
			this.txtFase = new System.Windows.Forms.TextBox();
			this.txtNum = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.txtEserc = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.gboxBilancio = new System.Windows.Forms.GroupBox();
			this.grpCentroSpesa = new System.Windows.Forms.GroupBox();
			this.txtUpb = new System.Windows.Forms.TextBox();
			this.grpBilancio = new System.Windows.Forms.GroupBox();
			this.txtCodiceBilancio = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.gboxSpesa.SuspendLayout();
			this.gboxBilancio.SuspendLayout();
			this.grpCentroSpesa.SuspendLayout();
			this.grpBilancio.SuspendLayout();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// button3
			// 
			this.button3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button3.Location = new System.Drawing.Point(288, 352);
			this.button3.Name = "button3";
			this.button3.TabIndex = 9;
			this.button3.TabStop = false;
			this.button3.Text = "Annulla";
			// 
			// btnOk
			// 
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(104, 352);
			this.btnOk.Name = "btnOk";
			this.btnOk.TabIndex = 8;
			this.btnOk.TabStop = false;
			this.btnOk.Tag = "mainsave";
			this.btnOk.Text = "Ok";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(112, 68);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(120, 20);
			this.textBox1.TabIndex = 2;
			this.textBox1.Tag = "admpay_admintax.amount";
			this.textBox1.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 68);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 23);
			this.label1.TabIndex = 6;
			this.label1.Text = "Importo:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.comboBox1);
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Location = new System.Drawing.Point(8, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(440, 48);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			// 
			// comboBox1
			// 
			this.comboBox1.DataSource = this.DS.tax;
			this.comboBox1.DisplayMember = "description";
			this.comboBox1.Location = new System.Drawing.Point(104, 16);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(320, 21);
			this.comboBox1.TabIndex = 0;
			this.comboBox1.Tag = "admpay_admintax.taxcode";
			this.comboBox1.ValueMember = "taxcode";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(8, 16);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(80, 23);
			this.button1.TabIndex = 1;
			this.button1.TabStop = false;
			this.button1.Tag = "manage.tax.default";
			this.button1.Text = "Tipo Ritenuta";
			// 
			// cmbImpegnativa
			// 
			this.cmbImpegnativa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.cmbImpegnativa.DataSource = this.DS.admpay_appropriationview;
			this.cmbImpegnativa.DisplayMember = "description";
			this.cmbImpegnativa.Location = new System.Drawing.Point(120, 104);
			this.cmbImpegnativa.Name = "cmbImpegnativa";
			this.cmbImpegnativa.Size = new System.Drawing.Size(328, 21);
			this.cmbImpegnativa.TabIndex = 3;
			this.cmbImpegnativa.Tag = "admpay_admintax.nappropriation";
			this.cmbImpegnativa.ValueMember = "nappropriation";
			// 
			// btnImpegnativa
			// 
			this.btnImpegnativa.Location = new System.Drawing.Point(8, 104);
			this.btnImpegnativa.Name = "btnImpegnativa";
			this.btnImpegnativa.Size = new System.Drawing.Size(104, 23);
			this.btnImpegnativa.TabIndex = 222;
			this.btnImpegnativa.TabStop = false;
			this.btnImpegnativa.Tag = "";
			this.btnImpegnativa.Text = "Num. Impegnativa";
			this.btnImpegnativa.Click += new System.EventHandler(this.btnImpegnativa_Click);
			// 
			// gboxSpesa
			// 
			this.gboxSpesa.Controls.Add(this.txtFase);
			this.gboxSpesa.Controls.Add(this.txtNum);
			this.gboxSpesa.Controls.Add(this.label13);
			this.gboxSpesa.Controls.Add(this.txtEserc);
			this.gboxSpesa.Controls.Add(this.label12);
			this.gboxSpesa.Location = new System.Drawing.Point(8, 264);
			this.gboxSpesa.Name = "gboxSpesa";
			this.gboxSpesa.Size = new System.Drawing.Size(440, 80);
			this.gboxSpesa.TabIndex = 225;
			this.gboxSpesa.TabStop = false;
			this.gboxSpesa.Text = "Movimento di Spesa associato all\'impegnativa";
			// 
			// txtFase
			// 
			this.txtFase.Location = new System.Drawing.Point(8, 16);
			this.txtFase.Name = "txtFase";
			this.txtFase.ReadOnly = true;
			this.txtFase.Size = new System.Drawing.Size(424, 20);
			this.txtFase.TabIndex = 5;
			this.txtFase.TabStop = false;
			this.txtFase.Tag = "expenseview.phase";
			this.txtFase.Text = "";
			// 
			// txtNum
			// 
			this.txtNum.Location = new System.Drawing.Point(216, 48);
			this.txtNum.Name = "txtNum";
			this.txtNum.ReadOnly = true;
			this.txtNum.Size = new System.Drawing.Size(80, 20);
			this.txtNum.TabIndex = 3;
			this.txtNum.TabStop = false;
			this.txtNum.Tag = "expenseview.nmov";
			this.txtNum.Text = "";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(160, 48);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(48, 16);
			this.label13.TabIndex = 4;
			this.label13.Text = "Numero:";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtEserc
			// 
			this.txtEserc.Location = new System.Drawing.Point(80, 48);
			this.txtEserc.Name = "txtEserc";
			this.txtEserc.ReadOnly = true;
			this.txtEserc.Size = new System.Drawing.Size(56, 20);
			this.txtEserc.TabIndex = 2;
			this.txtEserc.TabStop = false;
			this.txtEserc.Tag = "expenseview.ymov";
			this.txtEserc.Text = "";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(16, 48);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(56, 16);
			this.label12.TabIndex = 2;
			this.label12.Text = "Esercizio:";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// gboxBilancio
			// 
			this.gboxBilancio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.gboxBilancio.Controls.Add(this.grpCentroSpesa);
			this.gboxBilancio.Controls.Add(this.grpBilancio);
			this.gboxBilancio.Location = new System.Drawing.Point(8, 136);
			this.gboxBilancio.Name = "gboxBilancio";
			this.gboxBilancio.Size = new System.Drawing.Size(440, 120);
			this.gboxBilancio.TabIndex = 223;
			this.gboxBilancio.TabStop = false;
			this.gboxBilancio.Text = "U.P.B. - Bilancio associato all\'impegnativa";
			// 
			// grpCentroSpesa
			// 
			this.grpCentroSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.grpCentroSpesa.Controls.Add(this.txtUpb);
			this.grpCentroSpesa.Location = new System.Drawing.Point(8, 16);
			this.grpCentroSpesa.Name = "grpCentroSpesa";
			this.grpCentroSpesa.Size = new System.Drawing.Size(424, 48);
			this.grpCentroSpesa.TabIndex = 2;
			this.grpCentroSpesa.TabStop = false;
			this.grpCentroSpesa.Tag = "";
			this.grpCentroSpesa.Text = "UPB";
			// 
			// txtUpb
			// 
			this.txtUpb.Location = new System.Drawing.Point(8, 16);
			this.txtUpb.Name = "txtUpb";
			this.txtUpb.ReadOnly = true;
			this.txtUpb.Size = new System.Drawing.Size(408, 20);
			this.txtUpb.TabIndex = 4;
			this.txtUpb.TabStop = false;
			this.txtUpb.Tag = "finview.codeupb";
			this.txtUpb.Text = "";
			// 
			// grpBilancio
			// 
			this.grpBilancio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.grpBilancio.Controls.Add(this.txtCodiceBilancio);
			this.grpBilancio.Location = new System.Drawing.Point(8, 72);
			this.grpBilancio.Name = "grpBilancio";
			this.grpBilancio.Size = new System.Drawing.Size(424, 40);
			this.grpBilancio.TabIndex = 1;
			this.grpBilancio.TabStop = false;
			this.grpBilancio.Tag = "";
			this.grpBilancio.Text = "Bilancio";
			// 
			// txtCodiceBilancio
			// 
			this.txtCodiceBilancio.Location = new System.Drawing.Point(8, 16);
			this.txtCodiceBilancio.Name = "txtCodiceBilancio";
			this.txtCodiceBilancio.ReadOnly = true;
			this.txtCodiceBilancio.Size = new System.Drawing.Size(408, 20);
			this.txtCodiceBilancio.TabIndex = 0;
			this.txtCodiceBilancio.TabStop = false;
			this.txtCodiceBilancio.Tag = "finview.codefin";
			this.txtCodiceBilancio.Text = "";
			// 
			// FrmAdmPay_AdminTax_Detail
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(456, 382);
			this.Controls.Add(this.gboxSpesa);
			this.Controls.Add(this.gboxBilancio);
			this.Controls.Add(this.cmbImpegnativa);
			this.Controls.Add(this.btnImpegnativa);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.groupBox1);
			this.Name = "FrmAdmPay_AdminTax_Detail";
			this.Text = "FrmAdmPay_AdminTax_Detail";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.gboxSpesa.ResumeLayout(false);
			this.gboxBilancio.ResumeLayout(false);
			this.grpCentroSpesa.ResumeLayout(false);
			this.grpBilancio.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnImpegnativa_Click(object sender, System.EventArgs e) {
			// Passo 1. Ottengo tutte le impegnative in base alla chiave specificata
			if (DS.admpay_admintax.Rows.Count == 0) return;
			DataRow Curr = Meta.SourceRow;
			string filter = QHS.MCmp(Curr, new string [] {"yadmpay", "nadmpay"});
			DS.admpay_appropriationview.Clear();
			Meta.Conn.RUN_SELECT_INTO_TABLE(DS.admpay_appropriationview, "description", filter, null, true);
			if (DS.admpay_appropriationview.Rows.Count == 0) return;

			DataRow CurrSpesa = Meta.SourceRow.GetParentRow("admpay_expenseadmpay_admintax");
			// Passo 2. Correggo il disponibile delle impegnative
			// Caso 1.: InsertMode del contributo
			if (Meta.InsertMode) {
				string rigaCorrente = Curr["taxcode"] + "§" + Curr["nbracket"];
				// Caso 1.1.: Riga Padre in EditMode 
				// Sottraggo il vecchio importo del padre
				// Sommo il nuovo importo del padre
				// Sottraggo il vecchio importo degli altri admintax
				// Sommo il nuovo importo degli altri admintax
				if (CurrSpesa.RowState != DataRowState.Added) {
					aggiornaDisponibileImpegnativa(CurrSpesa, DataRowVersion.Original);
					aggiornaDisponibileImpegnativa(CurrSpesa, DataRowVersion.Default);

					foreach(DataRow rAdminTax in CurrSpesa.GetChildRows("admpay_expenseadmpay_admintax")) {
						string rRitAmministrazione = rAdminTax["taxcode"] + "§" + rAdminTax["nbracket"];
						if (rigaCorrente == rRitAmministrazione) continue;
						if (rAdminTax.RowState != DataRowState.Deleted) aggiornaDisponibileImpegnativa(rAdminTax, DataRowVersion.Default);
						if (rAdminTax.RowState != DataRowState.Added) aggiornaDisponibileImpegnativa(rAdminTax, DataRowVersion.Original);
					}
				}
				// Caso 1.2.: Riga Padre in InsertMode
				// Sottraggo l'importo della riga padre
				// Sottraggo l'importo degli altri admintax
				else {
					aggiornaDisponibileImpegnativa(CurrSpesa, DataRowVersion.Default);
					
					foreach(DataRow rAdminTax in CurrSpesa.GetChildRows("admpay_expenseadmpay_admintax")) {
						string rRitAmministrazione = rAdminTax["taxcode"] + "§" + rAdminTax["nbracket"];
						if (rigaCorrente == rRitAmministrazione) continue;
						aggiornaDisponibileImpegnativa(rAdminTax, DataRowVersion.Default);
					}
				}
			}
			
			// Caso 2: EditMode - devo sommarre l'importo originale della spesa; devo sommare tutti gli importi originali
			// dei contributi e devo sottrarre quelli correnti
			if (Meta.EditMode) {
				string rigaCorrente = Curr["taxcode"] + "§" + Curr["nbracket"];
				aggiornaDisponibileImpegnativa(Curr, DataRowVersion.Original);
				aggiornaDisponibileImpegnativa(CurrSpesa, DataRowVersion.Original);
				aggiornaDisponibileImpegnativa(CurrSpesa, DataRowVersion.Default);

				foreach(DataRow rAdminTax in CurrSpesa.GetChildRows("admpay_expenseadmpay_admintax")) {
					string rRitAmministrazione = rAdminTax["taxcode"] + "§" + rAdminTax["nbracket"];
					if (rigaCorrente == rRitAmministrazione) continue;
					if (rAdminTax.RowState != DataRowState.Deleted) aggiornaDisponibileImpegnativa(rAdminTax, DataRowVersion.Default);
					if (rAdminTax.RowState != DataRowState.Added) aggiornaDisponibileImpegnativa(rAdminTax, DataRowVersion.Original);
				}
			}
			DS.admpay_appropriationview.AcceptChanges();
			// Passo 3. Passo il DataTable al form delle impegnative
			Frm_AdmPay_Appropriation_Choose f = new Frm_AdmPay_Appropriation_Choose(DS.admpay_appropriationview, Meta);
			f.ShowDialog(this);
			if (f.DialogResult != DialogResult.OK) return;
			if (f.Choosen == null) return;
			// Passo 4. Dopo aver chiamato il form seleziono l'impegnativa scelta dal combo box
			DataRow rImpSel = f.Choosen;
			int nAppropriation = CfgFn.GetNoNullInt32(rImpSel["nappropriation"]);
			cmbImpegnativa.SelectedValue = nAppropriation;
			ChangeImputazione(rImpSel);
		}

		/// <summary>
		/// /// Metodo che aggiorna il disponibile dell'impegnativa
		/// </summary>
		/// <param name="Curr">Riga da interrogare per determinare l'impegnativa associata</param>
		/// <param name="toConsider">Versione della riga da considerare</param>
		private void aggiornaDisponibileImpegnativa(DataRow Curr, DataRowVersion toConsider) {
			decimal importo = CfgFn.GetNoNullDecimal(Curr["amount", toConsider]);
			importo = (toConsider == DataRowVersion.Original) ? importo : -importo;
			string filtro = QHS.AppAnd(QHS.CmpEq("yadmpay", Curr["yadmpay", toConsider]),
                QHS.CmpEq("nadmpay", Curr["nadmpay", toConsider]),
                QHS.CmpEq("nappropriation", Curr["nappropriation", toConsider]));

			DataRow [] rImpegnativa = DS.admpay_appropriationview.Select(filtro);
			if (rImpegnativa.Length != 0) {
				DataRow currImpegnativa = rImpegnativa[0];
				currImpegnativa["available"] = CfgFn.GetNoNullDecimal(currImpegnativa["available"])
					+ importo;
			}
		}
	}
}