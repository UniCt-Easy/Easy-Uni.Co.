
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
using funzioni_configurazione;
using System.Data;
using admpay_appropriation_choose;

namespace admpay_expense_default {
	/// <summary>
	/// Summary description for FrmAdmPay_Expense_Default.
	/// </summary>
	public class FrmAdmPay_Expense_Default : MetaDataForm {
		MetaData Meta;
		public admpay_expense_default.vistaForm DS;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox txtCredDeb;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.TextBox txtNumero;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPrincipale;
		private System.Windows.Forms.TabPage tabRitenute;
		private System.Windows.Forms.TabPage tabRecuperi;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.DataGrid dataGrid2;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.DataGrid dataGrid3;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.Button button10;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.DataGrid DGridClassificazioni;
		private System.Windows.Forms.GroupBox groupBox15;
		private System.Windows.Forms.Button btnDelClass;
		private System.Windows.Forms.Button btnEditClass;
		private System.Windows.Forms.Button btnInsertClass;
		private System.Windows.Forms.DataGrid DGridDettagliClassificazioni;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.GroupBox gboxContrEnte;
		private System.Windows.Forms.Label label50;
		private System.Windows.Forms.TextBox txtFiscaliEnte;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtAssicurativeEnte;
		private System.Windows.Forms.Label label47;
		private System.Windows.Forms.TextBox txtCostoTotaleEnte;
		private System.Windows.Forms.Label label48;
		private System.Windows.Forms.TextBox txtAltreEnte;
		private System.Windows.Forms.Label label49;
		private System.Windows.Forms.TextBox txtPrevidenzialiEnte;
		private System.Windows.Forms.TextBox txtAssistenzialiEnte;
		private System.Windows.Forms.Label label51;
		private System.Windows.Forms.GroupBox gboxRitDipendente;
		private System.Windows.Forms.TextBox txtAssicurativeDip;
		private System.Windows.Forms.Label label41;
		private System.Windows.Forms.TextBox txtImportonettoDip;
		private System.Windows.Forms.Label label42;
		private System.Windows.Forms.TextBox txtAltreDip;
		private System.Windows.Forms.Label label43;
		private System.Windows.Forms.TextBox txtFiscaliDip;
		private System.Windows.Forms.Label label44;
		private System.Windows.Forms.TextBox txtPrevidenzialiDip;
		private System.Windows.Forms.Label label45;
		private System.Windows.Forms.TextBox txtAssistenzialiDip;
		private System.Windows.Forms.Label label46;
		private System.Windows.Forms.TabPage tabClassSup;
		private System.Windows.Forms.ComboBox cmbImpegnativa;
		private System.Windows.Forms.TextBox txtEsercizio;
		private System.Windows.Forms.Button btnImpegnativa;
		private System.ComponentModel.IContainer components;

		public FrmAdmPay_Expense_Default() {
			InitializeComponent();
			DS.admpay_expensesorted.ExtendedProperties["gridmaster"]="sortingkind";
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
			string filterYAdmPay = QHS.CmpEq("yadmpay", Meta.GetSys("esercizio"));
			GetData.SetStaticFilter(DS.admpay_expense,filterYAdmPay);
			GetData.CacheTable(DS.clawback);
			GetData.CacheTable(DS.tax);
            string filterEsercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
			GetData.SetStaticFilter(DS.finview, filterEsercizio);
			GetData.SetStaticFilter(DS.expenseview, filterEsercizio);
            GetData.SetSorting(DS.sortingkind, "description");
            GetData.CacheTable(DS.sortingkind, QHS.IsNotNull("nphaseexpense"),"description", false);
            PostData.MarkAsTemporaryTable(DS.admpay_appropriationview, false);
            GetData.DenyClear(DS.admpay_appropriationview);
		}
        public void DisplayMember_impegnativa(string filter)
        {
            if (Meta.IsEmpty) return;
            DS.admpay_appropriationview.Clear();
            GetData.MarkToAddBlankRow(DS.admpay_appropriationview);
            GetData.Add_Blank_Row(DS.admpay_appropriationview);
            cmbImpegnativa.DataSource = null;
          
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.admpay_appropriationview, null, filter, null, true);// da commentare
            cmbImpegnativa.DataSource = DS.admpay_appropriationview;
            cmbImpegnativa.DisplayMember = "!nappropriation_description";
            cmbImpegnativa.ValueMember = "nappropriation";
            cmbImpegnativa.SelectedIndex = -1;
            foreach (DataRow R in DS.admpay_appropriationview.Rows)
            {
                if (CfgFn.GetNoNullInt32(R["nappropriation"]) == 0) {
                    R["!nappropriation_description"] = DBNull.Value;

                }
                else {
                    R["!nappropriation_description"] = R["nappropriation"].ToString() + " - "+R["description"].ToString();
                }
            }
            DS.admpay_appropriationview.AcceptChanges();
        }

		public void MetaData_AfterActivation() {
			btnInsertClass.BackColor = formcolors.GridButtonBackColor();
			btnInsertClass.ForeColor = formcolors.GridButtonForeColor();
			btnEditClass.BackColor = formcolors.GridButtonBackColor();
			btnEditClass.ForeColor = formcolors.GridButtonForeColor();
			btnDelClass.BackColor = formcolors.GridButtonBackColor();
    		btnDelClass.ForeColor = formcolors.GridButtonForeColor();
		}

		public void MetaData_BeforeFill() {
            PostData.MarkAsTemporaryTable((DataTable)cmbImpegnativa.DataSource, false);

			if (DS.admpay_expense.Rows.Count == 0) return;
			CalcolaTotaliClassificazioni();

			DataRow Curr = DS.admpay_expense.Rows[0];
			if (Meta.FirstFillForThisRow) {
				string filter = QHS.MCmp(Curr, new string [] {"yadmpay", "nadmpay"});

                DisplayMember_impegnativa(filter); 

			}
		}

		public void MetaData_AfterFill() {
			Meta.myGetData.GetTemporaryValues(DS.admpay_admintax);
			RefreshTabPrestazione();
			if (Meta.FirstFillForThisRow) {
				btnImpegnativa.Enabled = true;
			}
            DataRow CurrSorKind = HelpForm.GetLastSelected(DS.sortingkind);
            if (CurrSorKind != null) {
                string f = QHC.CmpEq("!idsorkind", CurrSorKind["idsorkind"]);
                DS.admpay_expensesorted.ExtendedProperties["CustomParentRelation"] = f;
            }
		}

		public void MetaData_AfterClear() {
			RefreshTabPrestazione();
			btnImpegnativa.Enabled = false;
			((DataTable)(cmbImpegnativa.DataSource)).Clear();
		}

        public void MetaData_BeforeRowSelect(DataTable T, DataRow R) {
            if (Meta.DrawStateIsDone && T.TableName == "sortingkind") {
                if (R != null) {
                    string f = QHC.CmpEq("!idsorkind", R["idsorkind"]);
                    DS.admpay_expensesorted.ExtendedProperties["CustomParentRelation"] = f;
                }
            }
        }

		public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
			if ((T.TableName == "sortingkind")&& Meta.DrawStateIsDone) {				
				ManageTipoClassMovimentiRowChanged(
					GetImportoPerClassificazione(), R);
				return;
			}
			if (T.TableName == "admpay" && Meta.DrawStateIsDone) {
				if (R!= null) {
					string filter = QHS.MCmp(R, new string [] {"yadmpay", "nadmpay"});
					if (Meta.InsertMode) {
						filter = QHS.AppAnd(filter, QHC.CmpGt("available", 0));
					}
                    DisplayMember_impegnativa(filter); 
          	    }
				else {
					((DataTable)(cmbImpegnativa.DataSource)).Clear();
				}
			}
		}

		#region Ritenute
		private void RefreshTabPrestazione() {
			if ((DS.admpay_admintax.Rows.Count == 0) && 
				(DS.admpay_employtax.Rows.Count == 0))	{
				txtImportonettoDip.Text		= "";
				txtCostoTotaleEnte.Text		= "";	
				txtAssistenzialiDip.Text	= "";
				txtAssistenzialiEnte.Text	= "";
				txtFiscaliDip.Text			= "";
				txtFiscaliEnte.Text			= "";
				txtPrevidenzialiDip.Text	= "";
				txtPrevidenzialiEnte.Text	= "";
				txtAltreDip.Text			= "";
				txtAltreEnte.Text			= "";
				txtAssicurativeDip.Text		= "";
				txtAssicurativeEnte.Text	= "";
				return;
			}

			decimal TotDip = 0;
			decimal TotAmm = 0;
			decimal AssicurativeDip = 0;
			decimal AssicurativeEnte = 0;
			decimal AssistenzialiDip = 0;
			decimal AssistenzialiEnte = 0;
			decimal FiscaliDip = 0;
			decimal FiscaliEnte = 0;
			decimal PrevidenzialiDip = 0;
			decimal PrevidenzialiEnte = 0;
			decimal AltreDip = 0;
			decimal AltreEnte = 0;
			decimal MyImporto = CfgFn.GetNoNullDecimal(DS.admpay_expense.Rows[0]["amount"]);
				
			foreach(DataRow rAdminTax in DS.admpay_admintax.Select()) {
				decimal DecAmm = CfgFn.GetNoNullDecimal(rAdminTax["amount"]);
				TotAmm += DecAmm;

				string MyFilter = QHC.CmpEq("taxcode", rAdminTax["taxcode"]);
				DataRow[] DRTipo = DS.Tables["tax"].Select(MyFilter);
				if (DRTipo.Length==0){
					string errmess= "La ritenuta con codice "+rAdminTax["taxcode"]+
						" non è stata trovata nella tabella TAX. "+
						" E' consigliabile rivolgersi al servizio assistenza. "+
						"Questo può portare ad ERRORI GRAVI nei calcoli. ";
					QueryCreator.ShowError(this,errmess,errmess);
					AltreEnte += DecAmm;
					continue;
				}
				//In base al tipo di ritenuta:
				switch(DRTipo[0]["taxkind"].ToString().ToUpper()) {		
					case "A":
						AssistenzialiEnte += DecAmm;
						break;
					case "F":
						FiscaliEnte += DecAmm;
						break;
					case "P":
						PrevidenzialiEnte += DecAmm;
						break;
					case "N":
						AssicurativeEnte += DecAmm;
						break;
					case "O":
						AltreEnte += DecAmm;
						break;
					default:
						AltreEnte += DecAmm;
						break;
				}
			}

			foreach(DataRow rEmployTax in DS.admpay_employtax.Select()) {
				decimal DecDip =  CfgFn.GetNoNullDecimal(rEmployTax["amount"]);
				TotDip += DecDip;

				string MyFilter = QHC.CmpEq("taxcode", rEmployTax["taxcode"]);
				DataRow[] DRTipo = DS.Tables["tax"].Select(MyFilter);
				if (DRTipo.Length==0){
					string errmess= "La ritenuta con codice "+rEmployTax["taxcode"]+
						" non è stata trovata nella tabella TAX. "+
						" E' consigliabile rivolgersi al servizio assistenza. "+
						"Questo può portare ad ERRORI GRAVI nei calcoli. ";
					QueryCreator.ShowError(this,errmess,errmess);
					AltreDip += DecDip;
					continue;
				}

				//In base al tipo di ritenuta:
				switch(DRTipo[0]["taxkind"].ToString().ToUpper()) {		
					case "A":
						AssistenzialiDip += DecDip;
						break;
					case "F":
						FiscaliDip += DecDip;
						break;
					case "P":
						PrevidenzialiDip += DecDip;
						break;
					case "N":
						AssicurativeDip += DecDip;
						break;
					case "O":
						AltreDip += DecDip;
						break;
					default:
						AltreDip += DecDip;
						break;
				}
			}//fine foreach

			txtImportonettoDip.Text		= Str(MyImporto - TotDip);
			txtCostoTotaleEnte.Text		= Str(MyImporto + TotAmm);	
			txtAssistenzialiDip.Text	= Str(AssistenzialiDip);
			txtAssistenzialiEnte.Text	= Str(AssistenzialiEnte);
			txtFiscaliDip.Text			= Str(FiscaliDip);
			txtFiscaliEnte.Text			= Str(FiscaliEnte);
			txtPrevidenzialiDip.Text	= Str(PrevidenzialiDip);
			txtPrevidenzialiEnte.Text	= Str(PrevidenzialiEnte);
			txtAltreDip.Text			= Str(AltreDip);
			txtAltreEnte.Text			= Str(AltreEnte);
			txtAssicurativeDip.Text		= Str(AssicurativeDip);
			txtAssicurativeEnte.Text	= Str(AssicurativeEnte);
		}
		#endregion

		//restituisce una stringa da un decimal
		private string Str(decimal D) {
			if(D == 0) return "";
			return D.ToString("c");
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAdmPay_Expense_Default));
            this.DS = new admpay_expense_default.vistaForm();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnImpegnativa = new System.Windows.Forms.Button();
            this.txtEsercizio = new System.Windows.Forms.TextBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.cmbImpegnativa = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCredDeb = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPrincipale = new System.Windows.Forms.TabPage();
            this.tabRitenute = new System.Windows.Forms.TabPage();
            this.gboxContrEnte = new System.Windows.Forms.GroupBox();
            this.label50 = new System.Windows.Forms.Label();
            this.txtFiscaliEnte = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAssicurativeEnte = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.txtCostoTotaleEnte = new System.Windows.Forms.TextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.txtAltreEnte = new System.Windows.Forms.TextBox();
            this.label49 = new System.Windows.Forms.Label();
            this.txtPrevidenzialiEnte = new System.Windows.Forms.TextBox();
            this.txtAssistenzialiEnte = new System.Windows.Forms.TextBox();
            this.label51 = new System.Windows.Forms.Label();
            this.gboxRitDipendente = new System.Windows.Forms.GroupBox();
            this.txtAssicurativeDip = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.txtImportonettoDip = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.txtAltreDip = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.txtFiscaliDip = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.txtPrevidenzialiDip = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.txtAssistenzialiDip = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.tabRecuperi = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dataGrid3 = new System.Windows.Forms.DataGrid();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.tabClassSup = new System.Windows.Forms.TabPage();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.btnDelClass = new System.Windows.Forms.Button();
            this.btnEditClass = new System.Windows.Forms.Button();
            this.btnInsertClass = new System.Windows.Forms.Button();
            this.DGridDettagliClassificazioni = new System.Windows.Forms.DataGrid();
            this.DGridClassificazioni = new System.Windows.Forms.DataGrid();
            this.label8 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPrincipale.SuspendLayout();
            this.tabRitenute.SuspendLayout();
            this.gboxContrEnte.SuspendLayout();
            this.gboxRitDipendente.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.tabRecuperi.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).BeginInit();
            this.tabClassSup.SuspendLayout();
            this.groupBox15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGridDettagliClassificazioni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGridClassificazioni)).BeginInit();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(176, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Numero:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Esercizio:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnImpegnativa
            // 
            this.btnImpegnativa.Location = new System.Drawing.Point(8, 72);
            this.btnImpegnativa.Name = "btnImpegnativa";
            this.btnImpegnativa.Size = new System.Drawing.Size(88, 23);
            this.btnImpegnativa.TabIndex = 2;
            this.btnImpegnativa.TabStop = false;
            this.btnImpegnativa.Tag = "";
            this.btnImpegnativa.Text = "Impegnativa";
            this.btnImpegnativa.Click += new System.EventHandler(this.btnImpegnativa_Click);
            // 
            // txtEsercizio
            // 
            this.txtEsercizio.Location = new System.Drawing.Point(96, 24);
            this.txtEsercizio.Name = "txtEsercizio";
            this.txtEsercizio.Size = new System.Drawing.Size(64, 20);
            this.txtEsercizio.TabIndex = 1;
            this.txtEsercizio.Tag = "admpay.yadmpay.year?admpay_expense.yadmpay.year";
            // 
            // txtNumero
            // 
            this.txtNumero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumero.Location = new System.Drawing.Point(256, 24);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(100, 20);
            this.txtNumero.TabIndex = 2;
            this.txtNumero.Tag = "admpay.nadmpay?admpay_expense.nadmpay";
            // 
            // cmbImpegnativa
            // 
            this.cmbImpegnativa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbImpegnativa.DataSource = this.DS.admpay_appropriationview;
            this.cmbImpegnativa.Location = new System.Drawing.Point(104, 72);
            this.cmbImpegnativa.Name = "cmbImpegnativa";
            this.cmbImpegnativa.Size = new System.Drawing.Size(480, 21);
            this.cmbImpegnativa.TabIndex = 2;
            this.cmbImpegnativa.Tag = "admpay_expense.nappropriation";
            this.cmbImpegnativa.ValueMember = "nappropriation";
            this.cmbImpegnativa.DisplayMember = "!nappropriation_description";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtEsercizio);
            this.groupBox1.Controls.Add(this.txtNumero);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 56);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "AutoChoose.txtNumero.default";
            this.groupBox1.Text = "Pagamento Stipendi";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "Num. Movimento:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(120, 112);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(80, 20);
            this.textBox3.TabIndex = 3;
            this.textBox3.Tag = "admpay_expense.nexpense";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtCredDeb);
            this.groupBox2.Location = new System.Drawing.Point(8, 296);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(576, 48);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Tag = "AutoChoose.txtCredDeb.lista.(active=\'S\')";
            this.groupBox2.Text = "Percipiente";
            // 
            // txtCredDeb
            // 
            this.txtCredDeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCredDeb.Location = new System.Drawing.Point(8, 16);
            this.txtCredDeb.Name = "txtCredDeb";
            this.txtCredDeb.Size = new System.Drawing.Size(560, 20);
            this.txtCredDeb.TabIndex = 1;
            this.txtCredDeb.Tag = "registry.title?admpay_expenseview.registry";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.comboBox2);
            this.groupBox3.Location = new System.Drawing.Point(8, 352);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(576, 48);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Prestazione";
            // 
            // comboBox2
            // 
            this.comboBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox2.DataSource = this.DS.service;
            this.comboBox2.DisplayMember = "description";
            this.comboBox2.Location = new System.Drawing.Point(8, 16);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(560, 21);
            this.comboBox2.TabIndex = 1;
            this.comboBox2.Tag = "admpay_expense.idser";
            this.comboBox2.ValueMember = "idser";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 416);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 23);
            this.label4.TabIndex = 11;
            this.label4.Text = "Data Inizio:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Location = new System.Drawing.Point(384, 416);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 23);
            this.label5.TabIndex = 12;
            this.label5.Text = "Data Fine:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(96, 416);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 8;
            this.textBox4.Tag = "admpay_expense.start";
            // 
            // textBox5
            // 
            this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox5.Location = new System.Drawing.Point(472, 416);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 20);
            this.textBox5.TabIndex = 9;
            this.textBox5.Tag = "admpay_expense.stop";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 23);
            this.label6.TabIndex = 15;
            this.label6.Tag = "";
            this.label6.Text = "Importo:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(8, 176);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 23);
            this.label7.TabIndex = 16;
            this.label7.Text = "Descrizione:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(120, 144);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 20);
            this.textBox6.TabIndex = 4;
            this.textBox6.Tag = "admpay_expense.amount";
            // 
            // textBox7
            // 
            this.textBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox7.Location = new System.Drawing.Point(8, 200);
            this.textBox7.Multiline = true;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(576, 88);
            this.textBox7.TabIndex = 5;
            this.textBox7.Tag = "admpay_expense.description";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPrincipale);
            this.tabControl1.Controls.Add(this.tabRitenute);
            this.tabControl1.Controls.Add(this.tabRecuperi);
            this.tabControl1.Controls.Add(this.tabClassSup);
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Location = new System.Drawing.Point(8, 8);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(600, 480);
            this.tabControl1.TabIndex = 17;
            this.tabControl1.Enter += new System.EventHandler(this.tabClassSup_Enter);
            // 
            // tabPrincipale
            // 
            this.tabPrincipale.Controls.Add(this.groupBox1);
            this.tabPrincipale.Controls.Add(this.cmbImpegnativa);
            this.tabPrincipale.Controls.Add(this.btnImpegnativa);
            this.tabPrincipale.Controls.Add(this.label3);
            this.tabPrincipale.Controls.Add(this.textBox3);
            this.tabPrincipale.Controls.Add(this.label6);
            this.tabPrincipale.Controls.Add(this.textBox6);
            this.tabPrincipale.Controls.Add(this.label7);
            this.tabPrincipale.Controls.Add(this.textBox7);
            this.tabPrincipale.Controls.Add(this.groupBox2);
            this.tabPrincipale.Controls.Add(this.groupBox3);
            this.tabPrincipale.Controls.Add(this.label4);
            this.tabPrincipale.Controls.Add(this.label5);
            this.tabPrincipale.Controls.Add(this.textBox4);
            this.tabPrincipale.Controls.Add(this.textBox5);
            this.tabPrincipale.Location = new System.Drawing.Point(4, 23);
            this.tabPrincipale.Name = "tabPrincipale";
            this.tabPrincipale.Size = new System.Drawing.Size(592, 453);
            this.tabPrincipale.TabIndex = 0;
            this.tabPrincipale.Text = "Principale";
            // 
            // tabRitenute
            // 
            this.tabRitenute.Controls.Add(this.gboxContrEnte);
            this.tabRitenute.Controls.Add(this.gboxRitDipendente);
            this.tabRitenute.Controls.Add(this.groupBox4);
            this.tabRitenute.Controls.Add(this.groupBox5);
            this.tabRitenute.Location = new System.Drawing.Point(4, 23);
            this.tabRitenute.Name = "tabRitenute";
            this.tabRitenute.Size = new System.Drawing.Size(592, 453);
            this.tabRitenute.TabIndex = 1;
            this.tabRitenute.Text = "Ritenute";
            // 
            // gboxContrEnte
            // 
            this.gboxContrEnte.Controls.Add(this.label50);
            this.gboxContrEnte.Controls.Add(this.txtFiscaliEnte);
            this.gboxContrEnte.Controls.Add(this.label9);
            this.gboxContrEnte.Controls.Add(this.txtAssicurativeEnte);
            this.gboxContrEnte.Controls.Add(this.label47);
            this.gboxContrEnte.Controls.Add(this.txtCostoTotaleEnte);
            this.gboxContrEnte.Controls.Add(this.label48);
            this.gboxContrEnte.Controls.Add(this.txtAltreEnte);
            this.gboxContrEnte.Controls.Add(this.label49);
            this.gboxContrEnte.Controls.Add(this.txtPrevidenzialiEnte);
            this.gboxContrEnte.Controls.Add(this.txtAssistenzialiEnte);
            this.gboxContrEnte.Controls.Add(this.label51);
            this.gboxContrEnte.Location = new System.Drawing.Point(8, 64);
            this.gboxContrEnte.Name = "gboxContrEnte";
            this.gboxContrEnte.Size = new System.Drawing.Size(576, 56);
            this.gboxContrEnte.TabIndex = 8;
            this.gboxContrEnte.TabStop = false;
            this.gboxContrEnte.Text = "Contributi a carico dell\'ente";
            // 
            // label50
            // 
            this.label50.Location = new System.Drawing.Point(104, 16);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(72, 16);
            this.label50.TabIndex = 10;
            this.label50.Text = "Previdenziali:";
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFiscaliEnte
            // 
            this.txtFiscaliEnte.Location = new System.Drawing.Point(184, 32);
            this.txtFiscaliEnte.Name = "txtFiscaliEnte";
            this.txtFiscaliEnte.ReadOnly = true;
            this.txtFiscaliEnte.Size = new System.Drawing.Size(88, 20);
            this.txtFiscaliEnte.TabIndex = 17;
            this.txtFiscaliEnte.TabStop = false;
            this.txtFiscaliEnte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(200, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 16);
            this.label9.TabIndex = 18;
            this.label9.Text = "Fiscali:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAssicurativeEnte
            // 
            this.txtAssicurativeEnte.Location = new System.Drawing.Point(272, 32);
            this.txtAssicurativeEnte.Name = "txtAssicurativeEnte";
            this.txtAssicurativeEnte.ReadOnly = true;
            this.txtAssicurativeEnte.Size = new System.Drawing.Size(88, 20);
            this.txtAssicurativeEnte.TabIndex = 3;
            this.txtAssicurativeEnte.TabStop = false;
            this.txtAssicurativeEnte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label47
            // 
            this.label47.Location = new System.Drawing.Point(288, 16);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(72, 16);
            this.label47.TabIndex = 16;
            this.label47.Text = "Assicurativi:";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCostoTotaleEnte
            // 
            this.txtCostoTotaleEnte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCostoTotaleEnte.Location = new System.Drawing.Point(464, 32);
            this.txtCostoTotaleEnte.Name = "txtCostoTotaleEnte";
            this.txtCostoTotaleEnte.ReadOnly = true;
            this.txtCostoTotaleEnte.Size = new System.Drawing.Size(104, 21);
            this.txtCostoTotaleEnte.TabIndex = 5;
            this.txtCostoTotaleEnte.TabStop = false;
            this.txtCostoTotaleEnte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label48
            // 
            this.label48.Location = new System.Drawing.Point(464, 16);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(88, 16);
            this.label48.TabIndex = 14;
            this.label48.Text = "Costo totale:";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAltreEnte
            // 
            this.txtAltreEnte.Location = new System.Drawing.Point(360, 32);
            this.txtAltreEnte.Name = "txtAltreEnte";
            this.txtAltreEnte.ReadOnly = true;
            this.txtAltreEnte.Size = new System.Drawing.Size(88, 20);
            this.txtAltreEnte.TabIndex = 4;
            this.txtAltreEnte.TabStop = false;
            this.txtAltreEnte.Tag = "";
            this.txtAltreEnte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label49
            // 
            this.label49.Location = new System.Drawing.Point(384, 16);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(32, 16);
            this.label49.TabIndex = 12;
            this.label49.Text = "Altri:";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPrevidenzialiEnte
            // 
            this.txtPrevidenzialiEnte.Location = new System.Drawing.Point(96, 32);
            this.txtPrevidenzialiEnte.Name = "txtPrevidenzialiEnte";
            this.txtPrevidenzialiEnte.ReadOnly = true;
            this.txtPrevidenzialiEnte.Size = new System.Drawing.Size(88, 20);
            this.txtPrevidenzialiEnte.TabIndex = 2;
            this.txtPrevidenzialiEnte.TabStop = false;
            this.txtPrevidenzialiEnte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtAssistenzialiEnte
            // 
            this.txtAssistenzialiEnte.Location = new System.Drawing.Point(8, 32);
            this.txtAssistenzialiEnte.Name = "txtAssistenzialiEnte";
            this.txtAssistenzialiEnte.ReadOnly = true;
            this.txtAssistenzialiEnte.Size = new System.Drawing.Size(88, 20);
            this.txtAssistenzialiEnte.TabIndex = 1;
            this.txtAssistenzialiEnte.TabStop = false;
            this.txtAssistenzialiEnte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label51
            // 
            this.label51.Location = new System.Drawing.Point(16, 16);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(72, 16);
            this.label51.TabIndex = 8;
            this.label51.Text = "Assistenziali:";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gboxRitDipendente
            // 
            this.gboxRitDipendente.Controls.Add(this.txtAssicurativeDip);
            this.gboxRitDipendente.Controls.Add(this.label41);
            this.gboxRitDipendente.Controls.Add(this.txtImportonettoDip);
            this.gboxRitDipendente.Controls.Add(this.label42);
            this.gboxRitDipendente.Controls.Add(this.txtAltreDip);
            this.gboxRitDipendente.Controls.Add(this.label43);
            this.gboxRitDipendente.Controls.Add(this.txtFiscaliDip);
            this.gboxRitDipendente.Controls.Add(this.label44);
            this.gboxRitDipendente.Controls.Add(this.txtPrevidenzialiDip);
            this.gboxRitDipendente.Controls.Add(this.label45);
            this.gboxRitDipendente.Controls.Add(this.txtAssistenzialiDip);
            this.gboxRitDipendente.Controls.Add(this.label46);
            this.gboxRitDipendente.Location = new System.Drawing.Point(8, 8);
            this.gboxRitDipendente.Name = "gboxRitDipendente";
            this.gboxRitDipendente.Size = new System.Drawing.Size(576, 56);
            this.gboxRitDipendente.TabIndex = 7;
            this.gboxRitDipendente.TabStop = false;
            this.gboxRitDipendente.Text = "Ritenute a carico del dipendente";
            // 
            // txtAssicurativeDip
            // 
            this.txtAssicurativeDip.Location = new System.Drawing.Point(272, 28);
            this.txtAssicurativeDip.Name = "txtAssicurativeDip";
            this.txtAssicurativeDip.ReadOnly = true;
            this.txtAssicurativeDip.Size = new System.Drawing.Size(88, 20);
            this.txtAssicurativeDip.TabIndex = 4;
            this.txtAssicurativeDip.TabStop = false;
            this.txtAssicurativeDip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label41
            // 
            this.label41.Location = new System.Drawing.Point(288, 12);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(72, 12);
            this.label41.TabIndex = 18;
            this.label41.Text = "Assicurative:";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtImportonettoDip
            // 
            this.txtImportonettoDip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImportonettoDip.Location = new System.Drawing.Point(464, 28);
            this.txtImportonettoDip.Name = "txtImportonettoDip";
            this.txtImportonettoDip.ReadOnly = true;
            this.txtImportonettoDip.Size = new System.Drawing.Size(104, 21);
            this.txtImportonettoDip.TabIndex = 6;
            this.txtImportonettoDip.TabStop = false;
            this.txtImportonettoDip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label42
            // 
            this.label42.Location = new System.Drawing.Point(464, 12);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(88, 12);
            this.label42.TabIndex = 16;
            this.label42.Text = "Importo netto:";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAltreDip
            // 
            this.txtAltreDip.Location = new System.Drawing.Point(360, 28);
            this.txtAltreDip.Name = "txtAltreDip";
            this.txtAltreDip.ReadOnly = true;
            this.txtAltreDip.Size = new System.Drawing.Size(88, 20);
            this.txtAltreDip.TabIndex = 5;
            this.txtAltreDip.TabStop = false;
            this.txtAltreDip.Tag = "";
            this.txtAltreDip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label43
            // 
            this.label43.Location = new System.Drawing.Point(376, 12);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(40, 12);
            this.label43.TabIndex = 14;
            this.label43.Text = "Altre:";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFiscaliDip
            // 
            this.txtFiscaliDip.Location = new System.Drawing.Point(184, 28);
            this.txtFiscaliDip.Name = "txtFiscaliDip";
            this.txtFiscaliDip.ReadOnly = true;
            this.txtFiscaliDip.Size = new System.Drawing.Size(88, 20);
            this.txtFiscaliDip.TabIndex = 3;
            this.txtFiscaliDip.TabStop = false;
            this.txtFiscaliDip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label44
            // 
            this.label44.Location = new System.Drawing.Point(200, 12);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(48, 12);
            this.label44.TabIndex = 12;
            this.label44.Text = "Fiscali:";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPrevidenzialiDip
            // 
            this.txtPrevidenzialiDip.Location = new System.Drawing.Point(96, 28);
            this.txtPrevidenzialiDip.Name = "txtPrevidenzialiDip";
            this.txtPrevidenzialiDip.ReadOnly = true;
            this.txtPrevidenzialiDip.Size = new System.Drawing.Size(88, 20);
            this.txtPrevidenzialiDip.TabIndex = 2;
            this.txtPrevidenzialiDip.TabStop = false;
            this.txtPrevidenzialiDip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label45
            // 
            this.label45.Location = new System.Drawing.Point(104, 12);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(80, 12);
            this.label45.TabIndex = 10;
            this.label45.Text = "Previdenziali:";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAssistenzialiDip
            // 
            this.txtAssistenzialiDip.Location = new System.Drawing.Point(8, 28);
            this.txtAssistenzialiDip.Name = "txtAssistenzialiDip";
            this.txtAssistenzialiDip.ReadOnly = true;
            this.txtAssistenzialiDip.Size = new System.Drawing.Size(88, 20);
            this.txtAssistenzialiDip.TabIndex = 1;
            this.txtAssistenzialiDip.TabStop = false;
            this.txtAssistenzialiDip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label46
            // 
            this.label46.Location = new System.Drawing.Point(24, 12);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(72, 12);
            this.label46.TabIndex = 8;
            this.label46.Text = "Assistenziali:";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.dataGrid1);
            this.groupBox4.Controls.Add(this.button4);
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Location = new System.Drawing.Point(8, 296);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(576, 152);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Contributi a carico dell\'ente";
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(8, 56);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(560, 88);
            this.dataGrid1.TabIndex = 3;
            this.dataGrid1.Tag = "admpay_admintax.detail";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(184, 24);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 2;
            this.button4.TabStop = false;
            this.button4.Tag = "delete";
            this.button4.Text = "Cancella";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(96, 24);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 1;
            this.button3.TabStop = false;
            this.button3.Tag = "edit.detail";
            this.button3.Text = "Correggi";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(8, 24);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            this.button2.TabStop = false;
            this.button2.Tag = "insert.detail";
            this.button2.Text = "Aggiungi";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.dataGrid2);
            this.groupBox5.Controls.Add(this.button7);
            this.groupBox5.Controls.Add(this.button6);
            this.groupBox5.Controls.Add(this.button5);
            this.groupBox5.Location = new System.Drawing.Point(8, 128);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(576, 168);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Ritenute a carico del dipendente";
            // 
            // dataGrid2
            // 
            this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid2.DataMember = "";
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(8, 56);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.Size = new System.Drawing.Size(560, 104);
            this.dataGrid2.TabIndex = 3;
            this.dataGrid2.Tag = "admpay_employtax.detail";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(184, 24);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 2;
            this.button7.TabStop = false;
            this.button7.Tag = "delete";
            this.button7.Text = "Cancella";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(96, 24);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 1;
            this.button6.TabStop = false;
            this.button6.Tag = "edit.detail";
            this.button6.Text = "Correggi";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(8, 24);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 0;
            this.button5.TabStop = false;
            this.button5.Tag = "insert.detail";
            this.button5.Text = "Aggiungi";
            // 
            // tabRecuperi
            // 
            this.tabRecuperi.Controls.Add(this.groupBox6);
            this.tabRecuperi.Location = new System.Drawing.Point(4, 23);
            this.tabRecuperi.Name = "tabRecuperi";
            this.tabRecuperi.Size = new System.Drawing.Size(592, 453);
            this.tabRecuperi.TabIndex = 2;
            this.tabRecuperi.Text = "Recuperi";
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.dataGrid3);
            this.groupBox6.Controls.Add(this.button8);
            this.groupBox6.Controls.Add(this.button9);
            this.groupBox6.Controls.Add(this.button10);
            this.groupBox6.Location = new System.Drawing.Point(8, 8);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(576, 440);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Recuperi";
            // 
            // dataGrid3
            // 
            this.dataGrid3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid3.DataMember = "";
            this.dataGrid3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid3.Location = new System.Drawing.Point(8, 56);
            this.dataGrid3.Name = "dataGrid3";
            this.dataGrid3.Size = new System.Drawing.Size(560, 376);
            this.dataGrid3.TabIndex = 3;
            this.dataGrid3.Tag = "admpay_clawback.detail";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(184, 24);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 2;
            this.button8.TabStop = false;
            this.button8.Tag = "delete";
            this.button8.Text = "Cancella";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(96, 24);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 1;
            this.button9.TabStop = false;
            this.button9.Tag = "edit.detail";
            this.button9.Text = "Correggi";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(8, 24);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 0;
            this.button10.TabStop = false;
            this.button10.Tag = "insert.detail";
            this.button10.Text = "Aggiungi";
            // 
            // tabClassSup
            // 
            this.tabClassSup.Controls.Add(this.groupBox15);
            this.tabClassSup.Controls.Add(this.DGridClassificazioni);
            this.tabClassSup.Controls.Add(this.label8);
            this.tabClassSup.ImageIndex = 1;
            this.tabClassSup.Location = new System.Drawing.Point(4, 23);
            this.tabClassSup.Name = "tabClassSup";
            this.tabClassSup.Size = new System.Drawing.Size(592, 453);
            this.tabClassSup.TabIndex = 3;
            this.tabClassSup.Text = "Classificazioni";
            // 
            // groupBox15
            // 
            this.groupBox15.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox15.Controls.Add(this.btnDelClass);
            this.groupBox15.Controls.Add(this.btnEditClass);
            this.groupBox15.Controls.Add(this.btnInsertClass);
            this.groupBox15.Controls.Add(this.DGridDettagliClassificazioni);
            this.groupBox15.Location = new System.Drawing.Point(8, 168);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(576, 271);
            this.groupBox15.TabIndex = 28;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Dettagli classificazioni";
            // 
            // btnDelClass
            // 
            this.btnDelClass.Location = new System.Drawing.Point(192, 24);
            this.btnDelClass.Name = "btnDelClass";
            this.btnDelClass.Size = new System.Drawing.Size(75, 23);
            this.btnDelClass.TabIndex = 3;
            this.btnDelClass.TabStop = false;
            this.btnDelClass.Tag = "";
            this.btnDelClass.Text = "Cancella";
            this.btnDelClass.Click += new System.EventHandler(this.btnDelClass_Click);
            // 
            // btnEditClass
            // 
            this.btnEditClass.Location = new System.Drawing.Point(104, 24);
            this.btnEditClass.Name = "btnEditClass";
            this.btnEditClass.Size = new System.Drawing.Size(75, 23);
            this.btnEditClass.TabIndex = 2;
            this.btnEditClass.TabStop = false;
            this.btnEditClass.Tag = "";
            this.btnEditClass.Text = "Correggi";
            this.btnEditClass.Click += new System.EventHandler(this.btnEditClass_Click);
            // 
            // btnInsertClass
            // 
            this.btnInsertClass.Location = new System.Drawing.Point(16, 24);
            this.btnInsertClass.Name = "btnInsertClass";
            this.btnInsertClass.Size = new System.Drawing.Size(75, 23);
            this.btnInsertClass.TabIndex = 1;
            this.btnInsertClass.TabStop = false;
            this.btnInsertClass.Tag = "";
            this.btnInsertClass.Text = "Aggiungi";
            this.btnInsertClass.Click += new System.EventHandler(this.btnInsertClass_Click);
            // 
            // DGridDettagliClassificazioni
            // 
            this.DGridDettagliClassificazioni.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DGridDettagliClassificazioni.DataMember = "";
            this.DGridDettagliClassificazioni.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.DGridDettagliClassificazioni.Location = new System.Drawing.Point(8, 56);
            this.DGridDettagliClassificazioni.Name = "DGridDettagliClassificazioni";
            this.DGridDettagliClassificazioni.ReadOnly = true;
            this.DGridDettagliClassificazioni.Size = new System.Drawing.Size(560, 207);
            this.DGridDettagliClassificazioni.TabIndex = 7;
            this.DGridDettagliClassificazioni.Tag = "admpay_expensesorted.detail";
            // 
            // DGridClassificazioni
            // 
            this.DGridClassificazioni.AllowNavigation = false;
            this.DGridClassificazioni.AllowSorting = false;
            this.DGridClassificazioni.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DGridClassificazioni.DataMember = "";
            this.DGridClassificazioni.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.DGridClassificazioni.Location = new System.Drawing.Point(8, 24);
            this.DGridClassificazioni.Name = "DGridClassificazioni";
            this.DGridClassificazioni.ParentRowsVisible = false;
            this.DGridClassificazioni.ReadOnly = true;
            this.DGridClassificazioni.Size = new System.Drawing.Size(576, 136);
            this.DGridClassificazioni.TabIndex = 8;
            this.DGridClassificazioni.Tag = "sortingkind.default";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(8, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "Classificazioni";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            // 
            // FrmAdmPay_Expense_Default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(616, 494);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmAdmPay_Expense_Default";
            this.Text = "FrmAdmPay_Expense_Default";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPrincipale.ResumeLayout(false);
            this.tabPrincipale.PerformLayout();
            this.tabRitenute.ResumeLayout(false);
            this.gboxContrEnte.ResumeLayout(false);
            this.gboxContrEnte.PerformLayout();
            this.gboxRitDipendente.ResumeLayout(false);
            this.gboxRitDipendente.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            this.tabRecuperi.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).EndInit();
            this.tabClassSup.ResumeLayout(false);
            this.groupBox15.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGridDettagliClassificazioni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGridClassificazioni)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region Classificazioni

		decimal GetImportoPerClassificazione(){
			if (DS.admpay_expense.Rows.Count == 0) return 0;
			DataRow R = DS.admpay_expense.Rows[0];
			decimal importo = CfgFn.GetNoNullDecimal(R["amount"]);
			return importo;
		}

		public void ManageTipoClassMovimentiRowChanged(decimal ImportoPerClassificazione,
			DataRow Curr) {
			if (Curr==null) {
				btnEditClass.Enabled=false;
				btnInsertClass.Enabled=false;
				btnDelClass.Enabled=false;
				return;
			}
			btnEditClass.Enabled=true;
			btnInsertClass.Enabled=true;
			btnDelClass.Enabled=true;

			CalcImpClassMovHeaders(ImportoPerClassificazione);
		}

		/// <summary>
		/// Calcs column names of impclassspesa grid and freshes grid
		/// </summary>
		void CalcImpClassMovHeaders(decimal importoperclassificazione) {
			DataTable T;
			DataRow Curr;

			bool res = Meta.myHelpForm.GetCurrentRow(DGridClassificazioni, out T, out Curr);
			if (Curr==null)return;

			RefillDettagliClassificazioni(importoperclassificazione);
		}

		/// <summary>
		/// redraws grid
		/// </summary>
		/// <param name="importoperclassificazione"></param>
		public void RefillDettagliClassificazioni(decimal importoperclassificazione){
			if (Meta.IsEmpty) return;
			DS.admpay_expensesorted.ExtendedProperties["TotaleImporto"]= importoperclassificazione;
			GetData.CalculateTable(DS.admpay_expensesorted);
			DGridDettagliClassificazioni.TableStyles.Clear();
			HelpForm.SetGridStyle(DGridDettagliClassificazioni, DS.admpay_expensesorted);
			if (DGridDettagliClassificazioni.DataSource==null) return;
			formatgrids format = new formatgrids(DGridDettagliClassificazioni);
			format.AutosizeColumnWidth();	
			HelpForm.SetDataGrid(DGridDettagliClassificazioni, DS.admpay_expensesorted);
		}

		private void btnInsertClass_Click(object sender, System.EventArgs e) {
			if (Meta.IsEmpty) return;
			if (DS.admpay_expense.Rows.Count == 0) return;
			Meta.GetFormData(true);
			DataRow Curr = DS.admpay_expense.Rows[0];
			decimal importo = CfgFn.GetNoNullDecimal(Curr["amount"]);

			CalcImpClassMovDefaults(importo); 

			DataTable T;
			DataRow CurrTipoClass;
			bool res = Meta.myHelpForm.GetCurrentRow(DGridClassificazioni, out T, out CurrTipoClass);
			if (!res) return;
			if (CurrTipoClass==null) return;
			string filter = QHS.CmpEq("idsorkind", CurrTipoClass["idsorkind"]);
			DataTable ClassMovAllowed = DS.sorting.Clone();
			ClassMovAllowed.Clear();
			Meta.Conn.RUN_SELECT_INTO_TABLE(ClassMovAllowed,null,filter,null,true);
			if (ClassMovAllowed.Rows.Count == 0) return;

			DS.admpay_expensesorted.ExtendedProperties[MetaData.ExtraParams]= ClassMovAllowed;
			DS.admpay_expensesorted.ExtendedProperties["importoresiduo"]= Convert.ToDecimal(0);

			DataRow Added = MetaData.Insert_Grid(DGridDettagliClassificazioni, "detail");
			if (Added==null) return;

			Meta.FreshForm(true);
		}

		private void btnEditClass_Click(object sender, System.EventArgs e) {
			if (Meta.IsEmpty) return;
			if (DS.admpay_expense.Rows.Count == 0) return;
			Meta.GetFormData(true);
			DataRow Curr = DS.admpay_expense.Rows[0];
			decimal importo = CfgFn.GetNoNullDecimal(Curr["amount"]);
			CalcImpClassMovDefaults(importo);

			DataTable T;
			DataRow CurrTipoClass;
			bool res = Meta.myHelpForm.GetCurrentRow(DGridClassificazioni, out T, out CurrTipoClass);
			if (!res) return;
			if (CurrTipoClass==null) return;
			DataTable SourceTable;
			DataRow CurrDR;            
			res = Meta.myHelpForm.GetCurrentRow(DGridDettagliClassificazioni, out SourceTable, out CurrDR);
			if (!res) return;
			if (CurrDR==null) return;

			string filter = QHS.CmpEq("idsorkind", CurrTipoClass["idsorkind"]);
			DataTable ClassMovAllowed = DS.sorting.Clone();
			ClassMovAllowed.Clear();
			Meta.Conn.RUN_SELECT_INTO_TABLE(ClassMovAllowed,null,filter,null,true);
			if (ClassMovAllowed.Rows.Count == 0) return;
			DS.admpay_expensesorted.ExtendedProperties[MetaData.ExtraParams]= ClassMovAllowed;
			DataRow Modified = MetaData.Edit_Grid(DGridDettagliClassificazioni, "detail");
			if (Modified==null) return;

			Meta.FreshForm(true);
		}

		private void btnDelClass_Click(object sender, System.EventArgs e) {
			if (Meta.IsEmpty) return;
			if (DS.admpay_expense.Rows.Count == 0) return;
			Meta.GetFormData(true);
			DataRow Curr = DS.admpay_expense.Rows[0];
			
			DataTable SourceTable;
			DataRow CurrDR;
            
			bool res = Meta.myHelpForm.GetCurrentRow(DGridDettagliClassificazioni, 
				out SourceTable, out CurrDR);
			if (!res) return ;
			if (CurrDR==null) return;

			
			if (show(
				"Cancello la classificazione selezionata?",
				"Richiesta di conferma", 
				MessageBoxButtons.YesNo)!=DialogResult.Yes) return;


			DeleteImpClassMov(CurrDR);
			
			HelpForm.SetLastSelected(SourceTable,null);
			Meta.myHelpForm.SetDataRowRelated(DGridClassificazioni.FindForm(), SourceTable, null);
			Meta.myHelpForm.ControlChanged(DGridClassificazioni,null);
			Meta.FreshForm();
		}

		void AbilitaSubMovimenti() {
			RowChange.MarkAsAutoincrement(
				DS.admpay_expensesorted.Columns["idsubclass"], 
				null,
				null,
				7,
				false);
            //RowChange.SetSelector(DS.admpay_expensesorted, "idsorkind");
			RowChange.SetSelector(DS.admpay_expensesorted, "idsor");
			RowChange.SetSelector(DS.admpay_expensesorted, "nadmpay");
			RowChange.SetSelector(DS.admpay_expensesorted, "yadmpay");
			RowChange.SetSelector(DS.admpay_expensesorted, "nexpense");
		}

		public void CalcImpClassMovDefaults(decimal ImportoPerClassificazione) {
			DataTable T;
			DataRow Curr;
			bool res = Meta.myHelpForm.GetCurrentRow(DGridClassificazioni, 
				out T, out Curr);
			if (Curr==null)return;

            //DS.admpay_expensesorted.Columns["idsorkind"].DefaultValue = Curr["idsorkind"];

			AbilitaSubMovimenti();
			DataRow CurrMov = DS.admpay_expense.Rows[0];
            string f = QHC.CmpEq("idsorkind", Curr["idsorkind"]);

			decimal importoclassificato = CfgFn.GetNoNullDecimal(DS.admpay_expensesorted.Compute("SUM(amount)",
                QHC.FieldIn("idsor", DS.sorting.Select(f))));
			
			decimal importototale  = ImportoPerClassificazione;
			decimal importoresiduo = importototale - importoclassificato;

			if (Curr["totalexpression"].ToString()=="")
				DS.admpay_expensesorted.Columns["amount"].DefaultValue = importoresiduo;
			else 
				DS.admpay_expensesorted.Columns["amount"].DefaultValue = 0;

			DS.admpay_expensesorted.ExtendedProperties["importoresiduo"]= importoresiduo;
			DS.admpay_expensesorted.ExtendedProperties["importototale"]= importototale;
			btnEditClass.Enabled=true;
			btnInsertClass.Enabled=true;
			btnDelClass.Enabled=true;
		}

		/// <summary>
		/// Deletes epexp with all sub-autoclasses
		/// </summary>
		/// <param name="R"></param>
		void DeleteImpClassMov(DataRow R) {
			R.Delete();
		}

		public void CalcolaTotaliClassificazioni(){
			foreach (DataRow TR in DS.sortingkind.Rows) {
				decimal importo=0;
				string filter= QHC.CmpEq("idsorkind", TR["idsorkind"]);
				string expression= TR["totalexpression"].ToString();
				if (expression=="")expression="SUM(amount)";
                string filterMovSor = QHC.FieldIn("idsor", DS.sorting.Select(filter));
				object importoo = null;
				try {
                    importoo = DS.admpay_expensesorted.Compute(expression, filterMovSor);
				}
				catch {
				}
				importo = CfgFn.GetNoNullDecimal(importoo);
				TR["!importo"]=importo;
				TR.AcceptChanges();
			}

		}

		public void SelectTipoClassMovimenti(){		
			DataTable T;
			DataRow CurrTipoClass;
			bool res = Meta.myHelpForm.GetCurrentRow(DGridClassificazioni, 
				out T, out CurrTipoClass);
			if (!res) {
				return;
			}
			if (CurrTipoClass!=null) {
				if (DGridDettagliClassificazioni.DataSource==null)
					Meta.myHelpForm.ControlChanged(DGridClassificazioni, null);
				return;
			}
			if (T.Rows.Count==0) {
				return;
			}
			DGridDettagliClassificazioni.CurrentRowIndex=0;
			Meta.myHelpForm.ControlChanged(DGridClassificazioni, null);
			res = Meta.myHelpForm.GetCurrentRow(DGridClassificazioni, 
				out T, out CurrTipoClass);
		}

		public void EnterTabClassificazioni(){
			if (Meta.IsEmpty) return;
			CalcolaTotaliClassificazioni();
			SelectTipoClassMovimenti();

		}
		#endregion

		private void tabClassSup_Enter(object sender, System.EventArgs e) {
			if (Meta==null) return;
			if (!Meta.DrawStateIsDone) return;
			if (tabControl1.SelectedTab==tabClassSup){
				EnterTabClassificazioni();
			}
		}

		private void btnImpegnativa_Click(object sender, System.EventArgs e) {
			// Passo 1. Ottengo tutte le impegnative in base alla chiave specificata
			if (DS.admpay_expense.Rows.Count == 0) return;
			DataRow Curr = DS.admpay_expense.Rows[0];
			string filter = QHS.MCmp(Curr, new string []{"yadmpay", "nadmpay"});

            DataTable admpay_appropriationview_temp = Meta.Conn.RUN_SELECT("admpay_appropriationview", null, "nappropriation", filter, null, true);

            if (admpay_appropriationview_temp.Rows.Count == 0) return;

			// Passo 2. Correggo il disponibile delle impegnative
			// Caso 1: InsertMode - devo sottrarre tutti i contributi della spesa corrente
			// Caso 2: EditMode - devo sommarre l'importo originale della spesa; devo sommare tutti gli importi originali
			// dei contributi e devo sottrarre quelli correnti
			if (Meta.EditMode) {
                aggiornaDisponibileImpegnativa(Curr, DataRowVersion.Original, admpay_appropriationview_temp);
			}
			foreach(DataRow rAdminTax in DS.admpay_admintax.Rows) {
                if (rAdminTax.RowState != DataRowState.Deleted) aggiornaDisponibileImpegnativa(rAdminTax, DataRowVersion.Default, admpay_appropriationview_temp);
                if (rAdminTax.RowState != DataRowState.Added) aggiornaDisponibileImpegnativa(rAdminTax, DataRowVersion.Original, admpay_appropriationview_temp);
			}
			
			// Passo 3. Passo il DataTable al form delle impegnative
            
            DataSet D = new DataSet();
            D.Tables.Add(admpay_appropriationview_temp);
            
            Frm_AdmPay_Appropriation_Choose f = new Frm_AdmPay_Appropriation_Choose(admpay_appropriationview_temp, Meta);
			f.ShowDialog(this);
			if (f.DialogResult != DialogResult.OK) return;
			if (f.Choosen == null) return;
			DataRow rImpSel = f.Choosen;
			int nAppropriation = CfgFn.GetNoNullInt32(rImpSel["nappropriation"]);
			cmbImpegnativa.SelectedValue = nAppropriation;
			// Passo 4. Dopo aver chiamato il form seleziono l'impegnativa scelta dal combo box
		}

		/// <summary>
		/// /// Metodo che aggiorna il disponibile dell'impegnativa
		/// </summary>
		/// <param name="Curr">Riga da interrogare per determinare l'impegnativa associata</param>
		/// <param name="toConsider">Versione della riga da considerare</param>
		private void aggiornaDisponibileImpegnativa(DataRow Curr, DataRowVersion toConsider,DataTable AdmPay_Appr) {
			decimal importo = CfgFn.GetNoNullDecimal(Curr["amount", toConsider]);
			importo = (toConsider == DataRowVersion.Original) ? importo : -importo;
			string filtro = QHC.AppAnd(QHC.CmpEq("yadmpay", Curr["yadmpay", toConsider]),
                QHC.CmpEq("nadmpay", Curr["nadmpay", toConsider]),
                QHC.CmpEq("nappropriation", Curr["nappropriation", toConsider]));

            DataRow[] rImpegnativa = AdmPay_Appr.Select(filtro);
			if (rImpegnativa.Length != 0) {
				DataRow currImpegnativa = rImpegnativa[0];
				currImpegnativa["available"] = CfgFn.GetNoNullDecimal(currImpegnativa["available"])
					+ importo;
			}
		}
	}
}
