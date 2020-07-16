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
using metaeasylibrary;
using System.Data;
using funzioni_configurazione;
using movimentofunctions;

namespace ivapay_wizard_acconto {//liquidazioneiva_acconto//
	/// <summary>
	/// Summary description for frmliquidazioneiva_acconto.
	/// </summary>
	public class Frm_ivapay_wizard_acconto : System.Windows.Forms.Form {
		public vistaForm DS;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnBack;
		private Crownwood.Magic.Controls.TabControl tabController;
		private Crownwood.Magic.Controls.TabPage tabpage1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label1;
		private Crownwood.Magic.Controls.TabPage tabPage3;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox txtImporto;
		private System.Windows.Forms.DataGrid gridSpesa;
		private System.Windows.Forms.Button btnScollegaS;
		private System.Windows.Forms.Button btnCollegaS;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private object maxfasespesa;
		private Hashtable errmsg=null;
		private MetaData Meta;
		private DataAccess Conn;
		private MetaDataDispatcher Disp;
		private object esercizio;
		private string CustomTitle;
		private DataTable TAutomatismi;
		private Hashtable RighePadriSpesa;
        private System.Windows.Forms.Label label2;
        private GroupBox grpMetodoAcconto;
        private RadioButton rdbMetodoAcconto1;
        private RadioButton rdbMetodoAcconto3;
        private RadioButton rdbMetodoAcconto2;
        private RadioButton rdbMetodoAcconto4;
        private Button btnCambiaUPBEntrata;
	

		public Frm_ivapay_wizard_acconto() {
			InitializeComponent();
			tabController.HideTabsMode = 
				Crownwood.Magic.Controls.TabControl.HideTabsModes.HideAlways;
			GetData.CacheTable(DS.config);
			GetData.CacheTable(DS.expensephase);
			GetData.SetSorting(DS.expenseview,"ymov DESC,nmov DESC");
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
            this.DS = new ivapay_wizard_acconto.vistaForm();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.tabController = new Crownwood.Magic.Controls.TabControl();
            this.tabpage1 = new Crownwood.Magic.Controls.TabPage();
            this.grpMetodoAcconto = new System.Windows.Forms.GroupBox();
            this.rdbMetodoAcconto4 = new System.Windows.Forms.RadioButton();
            this.rdbMetodoAcconto1 = new System.Windows.Forms.RadioButton();
            this.rdbMetodoAcconto3 = new System.Windows.Forms.RadioButton();
            this.rdbMetodoAcconto2 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtImporto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage3 = new Crownwood.Magic.Controls.TabPage();
            this.btnCambiaUPBEntrata = new System.Windows.Forms.Button();
            this.gridSpesa = new System.Windows.Forms.DataGrid();
            this.btnScollegaS = new System.Windows.Forms.Button();
            this.btnCollegaS = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.tabController.SuspendLayout();
            this.tabpage1.SuspendLayout();
            this.grpMetodoAcconto.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSpesa)).BeginInit();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(706, 344);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Cancel";
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(602, 344);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(72, 23);
            this.btnNext.TabIndex = 21;
            this.btnNext.Text = "Avanti >";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(522, 344);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(72, 23);
            this.btnBack.TabIndex = 20;
            this.btnBack.Text = "< Indietro";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // tabController
            // 
            this.tabController.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabController.IDEPixelArea = true;
            this.tabController.Location = new System.Drawing.Point(16, 16);
            this.tabController.Name = "tabController";
            this.tabController.SelectedIndex = 0;
            this.tabController.SelectedTab = this.tabpage1;
            this.tabController.Size = new System.Drawing.Size(778, 312);
            this.tabController.TabIndex = 23;
            this.tabController.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabpage1,
            this.tabPage3});
            // 
            // tabpage1
            // 
            this.tabpage1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabpage1.Controls.Add(this.grpMetodoAcconto);
            this.tabpage1.Controls.Add(this.label2);
            this.tabpage1.Controls.Add(this.label6);
            this.tabpage1.Controls.Add(this.txtImporto);
            this.tabpage1.Controls.Add(this.label5);
            this.tabpage1.Controls.Add(this.label1);
            this.tabpage1.Location = new System.Drawing.Point(0, 0);
            this.tabpage1.Name = "tabpage1";
            this.tabpage1.Size = new System.Drawing.Size(778, 287);
            this.tabpage1.TabIndex = 0;
            this.tabpage1.Tag = "tabella.campo.fixed.2..%.100";
            this.tabpage1.Title = "Pagina 1 di 2";
            // 
            // grpMetodoAcconto
            // 
            this.grpMetodoAcconto.Controls.Add(this.rdbMetodoAcconto4);
            this.grpMetodoAcconto.Controls.Add(this.rdbMetodoAcconto1);
            this.grpMetodoAcconto.Controls.Add(this.rdbMetodoAcconto3);
            this.grpMetodoAcconto.Controls.Add(this.rdbMetodoAcconto2);
            this.grpMetodoAcconto.Location = new System.Drawing.Point(11, 162);
            this.grpMetodoAcconto.Name = "grpMetodoAcconto";
            this.grpMetodoAcconto.Size = new System.Drawing.Size(620, 111);
            this.grpMetodoAcconto.TabIndex = 12;
            this.grpMetodoAcconto.TabStop = false;
            this.grpMetodoAcconto.Text = "Metodo usato per calcolare l\'Acconto";
            // 
            // rdbMetodoAcconto4
            // 
            this.rdbMetodoAcconto4.AutoSize = true;
            this.rdbMetodoAcconto4.Location = new System.Drawing.Point(15, 83);
            this.rdbMetodoAcconto4.Name = "rdbMetodoAcconto4";
            this.rdbMetodoAcconto4.Size = new System.Drawing.Size(459, 19);
            this.rdbMetodoAcconto4.TabIndex = 35;
            this.rdbMetodoAcconto4.TabStop = true;
            this.rdbMetodoAcconto4.Tag = "";
            this.rdbMetodoAcconto4.Text = "4 - Soggetti operanti nei settori delle telecomunicazioni,  energia elettrica, ec" +
    "cetera";
            this.rdbMetodoAcconto4.UseVisualStyleBackColor = true;
            // 
            // rdbMetodoAcconto1
            // 
            this.rdbMetodoAcconto1.AutoSize = true;
            this.rdbMetodoAcconto1.Location = new System.Drawing.Point(15, 19);
            this.rdbMetodoAcconto1.Name = "rdbMetodoAcconto1";
            this.rdbMetodoAcconto1.Size = new System.Drawing.Size(123, 19);
            this.rdbMetodoAcconto1.TabIndex = 34;
            this.rdbMetodoAcconto1.TabStop = true;
            this.rdbMetodoAcconto1.Tag = "";
            this.rdbMetodoAcconto1.Text = "1 - Metodo storico";
            this.rdbMetodoAcconto1.UseVisualStyleBackColor = true;
            // 
            // rdbMetodoAcconto3
            // 
            this.rdbMetodoAcconto3.AutoSize = true;
            this.rdbMetodoAcconto3.Location = new System.Drawing.Point(15, 59);
            this.rdbMetodoAcconto3.Name = "rdbMetodoAcconto3";
            this.rdbMetodoAcconto3.Size = new System.Drawing.Size(179, 19);
            this.rdbMetodoAcconto3.TabIndex = 33;
            this.rdbMetodoAcconto3.TabStop = true;
            this.rdbMetodoAcconto3.Tag = "";
            this.rdbMetodoAcconto3.Text = "3 - Metodo analitico effettivo";
            this.rdbMetodoAcconto3.UseVisualStyleBackColor = true;
            // 
            // rdbMetodoAcconto2
            // 
            this.rdbMetodoAcconto2.AutoSize = true;
            this.rdbMetodoAcconto2.Location = new System.Drawing.Point(15, 39);
            this.rdbMetodoAcconto2.Name = "rdbMetodoAcconto2";
            this.rdbMetodoAcconto2.Size = new System.Drawing.Size(150, 19);
            this.rdbMetodoAcconto2.TabIndex = 32;
            this.rdbMetodoAcconto2.TabStop = true;
            this.rdbMetodoAcconto2.Tag = "";
            this.rdbMetodoAcconto2.Text = "2 - Metodo previsionale";
            this.rdbMetodoAcconto2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(512, 23);
            this.label2.TabIndex = 11;
            this.label2.Text = "PROCEDURA GUIDATA PER L\'ACCONTO DELLA LIQUIDAZIONE IVA";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(11, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(504, 24);
            this.label6.TabIndex = 9;
            this.label6.Text = "Per proseguire, inserire l\'importo dell\'acconto e cliccare su Avanti";
            // 
            // txtImporto
            // 
            this.txtImporto.Location = new System.Drawing.Point(11, 126);
            this.txtImporto.Name = "txtImporto";
            this.txtImporto.Size = new System.Drawing.Size(80, 23);
            this.txtImporto.TabIndex = 8;
            this.txtImporto.Tag = "";
            this.txtImporto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtImporto.Enter += new System.EventHandler(this.txtImporto_Enter);
            this.txtImporto.Leave += new System.EventHandler(this.txtImporto_Leave);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(11, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 24);
            this.label5.TabIndex = 7;
            this.label5.Text = "Importo dell\'acconto IVA:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(512, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Questa procedura permette di creare i movimenti di contabilità finanziaria connes" +
    "si con il versamento dell\'acconto IVA.";
            // 
            // tabPage3
            // 
            this.tabPage3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabPage3.Controls.Add(this.btnCambiaUPBEntrata);
            this.tabPage3.Controls.Add(this.gridSpesa);
            this.tabPage3.Controls.Add(this.btnScollegaS);
            this.tabPage3.Controls.Add(this.btnCollegaS);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Location = new System.Drawing.Point(0, 0);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Selected = false;
            this.tabPage3.Size = new System.Drawing.Size(778, 287);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Title = "Pagina 2 di 2";
            this.tabPage3.Visible = false;
            // 
            // btnCambiaUPBEntrata
            // 
            this.btnCambiaUPBEntrata.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCambiaUPBEntrata.Location = new System.Drawing.Point(586, 249);
            this.btnCambiaUPBEntrata.Name = "btnCambiaUPBEntrata";
            this.btnCambiaUPBEntrata.Size = new System.Drawing.Size(176, 23);
            this.btnCambiaUPBEntrata.TabIndex = 23;
            this.btnCambiaUPBEntrata.Text = "Cambia UPB";
            this.btnCambiaUPBEntrata.Click += new System.EventHandler(this.btnCambiaUPBSpesa_Click);
            // 
            // gridSpesa
            // 
            this.gridSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridSpesa.CaptionVisible = false;
            this.gridSpesa.DataMember = "";
            this.gridSpesa.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridSpesa.Location = new System.Drawing.Point(16, 48);
            this.gridSpesa.Name = "gridSpesa";
            this.gridSpesa.Size = new System.Drawing.Size(746, 184);
            this.gridSpesa.TabIndex = 22;
            // 
            // btnScollegaS
            // 
            this.btnScollegaS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnScollegaS.Location = new System.Drawing.Point(233, 248);
            this.btnScollegaS.Name = "btnScollegaS";
            this.btnScollegaS.Size = new System.Drawing.Size(184, 24);
            this.btnScollegaS.TabIndex = 21;
            this.btnScollegaS.Text = "Annulla il collegamento";
            this.btnScollegaS.Click += new System.EventHandler(this.btnScollegaS_Click);
            // 
            // btnCollegaS
            // 
            this.btnCollegaS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCollegaS.Location = new System.Drawing.Point(16, 248);
            this.btnCollegaS.Name = "btnCollegaS";
            this.btnCollegaS.Size = new System.Drawing.Size(184, 24);
            this.btnCollegaS.TabIndex = 20;
            this.btnCollegaS.Text = "Collega a movimento esistente";
            this.btnCollegaS.Click += new System.EventHandler(this.btnCollegaS_Click);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.Location = new System.Drawing.Point(16, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(746, 24);
            this.label11.TabIndex = 2;
            this.label11.Text = "Spingendo il bottone Fine saranno creati i seguenti movimenti di spesa";
            // 
            // Frm_ivapay_wizard_acconto
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(810, 390);
            this.Controls.Add(this.tabController);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnBack);
            this.Name = "Frm_ivapay_wizard_acconto";
            this.Text = "frmliquidazioneiva_acconto";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.tabController.ResumeLayout(false);
            this.tabpage1.ResumeLayout(false);
            this.tabpage1.PerformLayout();
            this.grpMetodoAcconto.ResumeLayout(false);
            this.grpMetodoAcconto.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSpesa)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
        QueryHelper QHS;
        CQueryHelper QHC;
		public void MetaData_AfterLink() {
			errmsg = new Hashtable();
			errmsg.Add("err_persiva", "Impossibile proseguire. Non è stata definita la configurazione "+
				"del modulo IVA relativa all'esercizio corrente");

			Meta=MetaData.GetMetaData(this);
			this.Conn=Meta.Conn;
			this.Disp=Meta.Dispatcher;

            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();

			Meta.CanCancel=false;
			Meta.CanInsert=false;
			Meta.CanInsertCopy=false;
			Meta.CanSave=false;
			Meta.SearchEnabled=false;
			esercizio=Meta.GetSys("esercizio");
            GetData.CacheTable(DS.config,QHS.CmpEq("ayear", esercizio),null, false);
            GetData.SetStaticFilter(DS.payment, QHS.CmpEq("ypay", esercizio));
        }

        bool generaTuttelafasi = true;

        public void MetaData_AfterActivation() {
			FormInit();
            DataRow CfgRow = DS.config.Rows[0];
            if (CfgRow["flagivaregphase"].ToString().ToUpper() == "S")
                generaTuttelafasi = false;
            else
                generaTuttelafasi = true;

            maxfasespesa = Meta.GetSys("maxexpensephase");
		}

		private void FormInit() {
			CustomTitle = "Wizard Acconto IVA";
			CheckInit();
			txtImporto.Enter+=new EventHandler(txtImporto_Enter);
			txtImporto.Leave+=new EventHandler(txtImporto_Leave);
			//Selects first tab
			DisplayTabs(0);

		}


		private void txtImporto_Enter(object sender, EventArgs e) {
             HelpForm.ExtEnterDecTextBox(txtImporto, "ivapay.creditamount");
		}
		private void txtImporto_Leave(object sender, EventArgs e) {
             HelpForm.ExtLeaveDecTextBox(txtImporto, "ivapay.creditamount");
		}	

		/// <summary>
		/// Messaggi di warning
		/// </summary>
		private void ShowMsg(string msg) {
			ShowMsg(msg,null);
		}
		/// <summary>
		/// Errori
		/// </summary>
		private void ShowMsg(string msg, string error) {
			if (error==null || error=="")
				MessageBox.Show(msg,"Attenzione",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
			else
				QueryCreator.ShowError(this,msg,error);
		}

		/// <summary>
		/// Controlla la presenza di righe di configurazione, persiva e tipoliquidperiodiva
		/// </summary>
		private void CheckInit() {
			if (DS.config.Rows.Count==0) {
				ShowMsg(errmsg["err_persiva"].ToString());
				btnNext.Enabled=false;
				return;
			}
		}

		/// <summary>
		/// Displays tab n. NewTab and updates buttons
		/// </summary>
		/// <param name="newTab"></param>
		private void DisplayTabs(int newTab) {
			tabController.SelectedIndex= newTab;
			//Evaluates Buttons Appearance
			btnBack.Visible=(newTab>0);
			if (newTab== tabController.TabPages.Count-1)
				btnNext.Text="Fine.";
			else
				btnNext.Text="Avanti >";
			Text = CustomTitle+ " (Pagina "+(newTab+1)+" di "+tabController.TabPages.Count+")";
		}

		/// <summary>
		/// Changes tab backward/forward
		/// </summary>
		/// <param name="step"></param>
		private void StandardChangeTab(int step) {
			int oldTab= tabController.SelectedIndex;
			int newTab= oldTab+step;
			if ((newTab<0)||(newTab>tabController.TabPages.Count))return;
			if (!CustomChangeTab(oldTab,newTab))return;
			if (newTab==tabController.TabPages.Count) {
				DialogResult= DialogResult.OK;
				return;
			}
			DisplayTabs(newTab);
		}

		/// <summary>
		/// Must return true if operation is possible, and do any
		///  operation related to change from tab oldTab to newTab
		/// </summary>
		/// <param name="oldTab"></param>
		/// <param name="newTab"></param>
		/// <returns></returns>
		bool CustomChangeTab(int oldTab, int newTab) {
			if ((oldTab==0)&&(newTab==1)) {
                if (!(rdbMetodoAcconto1.Checked || rdbMetodoAcconto2.Checked || rdbMetodoAcconto3.Checked || rdbMetodoAcconto4.Checked)) {
                    MessageBox.Show(this, "Selezionare il Metodo usato per il calcolo dell'Acconto");
                    return false;
                }
                CheckImporto();
				return GeneraMovimenti();
			}
			if ((oldTab==1)&&(newTab==2)) {
				SaveData();
			}
			return true;
		}

		private void CheckImporto() {
			object obj=HelpForm.GetObjectFromString(typeof(decimal),txtImporto.Text,null);
			if (obj==DBNull.Value || obj==null) txtImporto.Text="0";
		}

		private void AddRowToTable(DataRow R, DataTable T, int i){			
			Meta.SetDefaults(T);
			DataRow NewR = T.NewRow();
			if (T.TableName == "expenseview"){
				NewR["idexp"]=i;
			}
			NewR["description"]="Acconto IVA";
			foreach(DataColumn C in R.Table.Columns){
				if (C.ColumnName == "movkind") continue;
				if (T.Columns[C.ColumnName]==null) continue;
				NewR[C.ColumnName]= R[C.ColumnName];
			}
			T.Rows.Add(NewR);
		}

		private void RicalcolaCampiCalcolati(){
			foreach(DataRow RS in DS.expenseview.Rows){
                object livsup = RS["parentidexp"];
                int nfasesup = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("expense", QHS.CmpEq("idexp", livsup), "nphase"));
                if (livsup != DBNull.Value) {
					DataRow Sup= (DataRow) RighePadriSpesa[livsup];
                    string nomefasesup = DS.expensephase.Select(QHC.CmpEq("nphase", nfasesup))[0]["description"].ToString();
                    string nomefasesup2 = DS.expensephase.Select(QHC.CmpEq("nphase", nfasesup + 1))[0]["description"].ToString();
                    RS["!livprecedente"] = nomefasesup + " " +
						Sup["ymov"].ToString()+"/"+
						Sup["nmov"].ToString();
                    string nomefasemax = DS.expensephase.Select(QHC.CmpEq("nphase", maxfasespesa))[0]["description"].ToString();
                    if (nomefasesup2 != nomefasemax)
						RS["phase"]= nomefasesup2+" - "+ nomefasemax;
					else
						RS["phase"]= nomefasemax;
				}
				else {
					RS["!livprecedente"]="";
					RS["phase"]="Tutte";
				}
			}
			formatgrids FGSpesa= new formatgrids(gridSpesa);
			FGSpesa.AutosizeColumnWidth();
		}

		private void FillTables(DataRow[] Automatismi){
			DS.expenseview.Clear();
			for (int i=0;i< Automatismi.Length; i++){
				DataRow R = Automatismi[i];
				switch(R["movkind"].ToString().ToLower()){
					case "spesa":
						AddRowToTable(R, DS.expenseview, i);
						break;
				}
			}
			MetaData MSpesaView = Disp.Get("expenseview");
			MSpesaView.DescribeColumns(DS.expenseview, "autogeneratips");
			
			HelpForm.SetDataGrid(gridSpesa, DS.expenseview);

			RicalcolaCampiCalcolati();
		}

		private bool GeneraMovimenti() {
			DataTable tIva = calcolaAnticipo();
			if (tIva == null) {
				MessageBox.Show(this, "Manca la cfg. del modulo iva. Andare in Menu/Configurazione/.. ed impostarli");
				return false;
			}
			tIva.Columns.Add("idmovimento", typeof(string));
			tIva.Columns.Add("parentidexp", typeof(int));
			TAutomatismi=tIva;
			RighePadriSpesa = new Hashtable();
			FillTables(TAutomatismi.Select());
			return true;
		}

		private DataTable calcolaAnticipo() {
			object esercizio = Meta.GetSys("esercizio");
			object importo = HelpForm.GetObjectFromString(typeof(decimal),txtImporto.Text,null);
			object[] param=new object[]{esercizio,importo};
			
			string filter = "(ayear = '" + esercizio + "')";
			if (DS.config.Rows.Count == 0) return null;
			DataRow rInvoiceSetup = DS.config.Rows[0];

			DataTable tIva = new DataTable();
			tIva.Columns.Add("movkind");
			tIva.Columns.Add("idreg",typeof(int));
			tIva.Columns.Add("idfin",typeof(int));
			tIva.Columns.Add("idupb",typeof(string));
			tIva.Columns.Add("amount",typeof(decimal));
			tIva.Columns.Add("registry");
			tIva.Columns.Add("codefin");
			tIva.Columns.Add("codeupb");

			object idreg = rInvoiceSetup["paymentagency"];
			if ((idreg == null) || (idreg == DBNull.Value)) return null;
			object registry = Meta.Conn.DO_READ_VALUE("registry", QHS.CmpEq("idreg",idreg), "title");

			object idfin = rInvoiceSetup["idfinivapayment"];
			if ((idfin == null) || (idfin == DBNull.Value)) return null;
			object codefin = Meta.Conn.DO_READ_VALUE("fin", QHS.CmpEq("idfin",idfin), "title");

			string idupb = "0001";
			object codeupb = Meta.Conn.DO_READ_VALUE("upb", QHS.CmpEq("idupb",idupb), "title");

			DataRow rIva = tIva.NewRow();
			rIva["movkind"] = "Spesa";
			rIva["idreg"] = idreg;
			rIva["registry"] = registry;
			rIva["idfin"] = idfin;
			rIva["codefin"] = codefin;
			rIva["idupb"] = idupb;
			rIva["codeupb"] = codeupb;
			rIva["amount"] = importo;

			tIva.Rows.Add(rIva);
			
			return tIva;
		}

		private void btnBack_Click(object sender, System.EventArgs e) {
			StandardChangeTab(-1);
		}

		private void btnNext_Click(object sender, System.EventArgs e) {
			StandardChangeTab(+1);
		}
		private DataRow[] GetGridSelectedRows(DataGrid G){
			string TableName = G.DataMember.ToString();
			DataSet MyDS =(DataSet)G.DataSource;
			DataTable MyTable = MyDS.Tables[TableName];
			int numrighetemp=MyTable.Rows.Count;
			int numrighe=0;
			int i;
			for (i=0; i<numrighetemp; i++){
				if(G.IsSelected(i)){
					numrighe++;
				}
			}

			DataRow[] Res=new DataRow[numrighe]; 			
			int count=0;
			for (i=0; i<numrighetemp; i++){
				if(G.IsSelected(i)){
					Res[count++]= GetGridRow(G,i);
				}
			}
			return Res;
		}
		int GetMaxFaseForSelection(DataRow []Selected, string table){
            int minfasecred = 99;
            int minfasebil = 99;
            if (table == "expense")
            {
                minfasecred = Convert.ToInt32(Conn.GetSys("expenseregphase"));
                minfasebil = Convert.ToInt32(Conn.GetSys("expensefinphase"));
            }
            if (table == "income")
            {
                minfasecred = Convert.ToInt32(Conn.GetSys("incomeregphase"));
                minfasebil = Convert.ToInt32(Conn.GetSys("incomefinphase"));
            }

			int fasecurr=99;
			fasecurr=Convert.ToInt32(maxfasespesa)-1;
			if (nvaloridiversi("idfin",Selected)>1){
				if (fasecurr >= minfasebil) fasecurr= minfasebil-1;
			}

			if (nvaloridiversi("idreg",Selected)>1){
				if (fasecurr >= minfasecred) fasecurr= minfasecred-1;
			}

			if (nvaloridiversi("idupb",Selected)>1){
				if (fasecurr >= minfasebil) fasecurr= minfasebil-1;
			}
			return fasecurr;
		}
		
		int nvaloridiversi(string column, DataRow []ROWS){
			string outstring="";
			int diversi=0;
			foreach (DataRow R in ROWS){
				//if (R[column]==DBNull.Value) continue;
				string quoted = QueryCreator.quotedstrvalue(R[column],false);
				if (outstring.IndexOf(quoted)>=0) continue;
				if (outstring!="")outstring+=",";
				outstring+=quoted;
				diversi++;
			}
			return diversi;
		}

        //int GetFaseInfo(string flag, string table) {
        //    string fasitable = table + "phase";
        //    DataTable Fase = DS.Tables[fasitable];
        //    int faseattivazione;

        //    DataRow[] MyDRfase;
        //    MyDRfase = Fase.Select(QHC.CmpEq(flag, 'S'), "nphase");
        //    if (MyDRfase.Length > 0)
        //        faseattivazione = (Convert.ToInt32(MyDRfase[0]["nphase"]));
        //    else
        //        faseattivazione = 99;
        //    return faseattivazione;
        //}




        DataRow GetGridRow(DataGrid G, int index) {
            string TableName = G.DataMember.ToString();
            DataSet MyDS = (DataSet)G.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];
            string filter;
            if (MyTable.TableName == "expenseview")
                filter = QHC.CmpEq("idexp", G[index, 0]);
            else
                filter = QHC.CmpEq("idinc", G[index, 0]);
            DataRow[] selectresult = MyTable.Select(filter);
            return selectresult[0];
        }


        string GetFilterForSelection(DataRow[] Selected, string table, int livello) {
            string filter = "";
            int minfasecred = 99;
            int minfasebil = 99;
            if (table == "expense")
            {
                minfasecred = Convert.ToInt32(Conn.GetSys("expenseregphase"));
                minfasebil = Convert.ToInt32(Conn.GetSys("expensefinphase"));
            }
            if (table == "income")
            {
                minfasecred = Convert.ToInt32(Conn.GetSys("incomeregphase"));
                minfasebil = Convert.ToInt32(Conn.GetSys("incomefinphase"));
            }

            if (livello >= minfasebil) {
                object O = Selected[0]["idfin"];
                if (O != DBNull.Value) {
                    filter = QHS.AppAnd(filter, QHS.CmpEq("idfin", O));
                }
            }

            if (livello >= minfasecred) {
                object O = Selected[0]["idreg"];
                if (O != DBNull.Value) {
                    filter = QHS.AppAnd(filter, QHS.CmpEq("idreg", O));
                }
            }

            if (livello >= minfasebil) {
                object O = Selected[0]["idupb"];
                if (O != DBNull.Value) {
                    filter = QHS.AppAnd(filter, QHS.CmpEq("idupb", O));
                }
            }
            return filter;
        }


		private void btnCollegaS_Click(object sender, System.EventArgs e) {
			DataRow []RigheSelezionate= GetGridSelectedRows(gridSpesa);
			if (RigheSelezionate==null) return;
			if (RigheSelezionate.Length==0) return;
			string rowfilter;
			int maxfase = GetMaxFaseForSelection(RigheSelezionate, "expense");
			if (maxfase<1){
				MessageBox.Show("Non è possibile collegare tutte le righe selezionate ad uno stesso movimento.\n"+
					"Le informazioni di U.P.B., bilancio, percipiente sono troppo diverse tra loro.","Errore");
				return;
			}
			int selectedfase=maxfase;
			if (maxfase>1){
				DataTable Fasi2=  DS.expensephase.Copy();
				foreach (DataRow ToDel in Fasi2.Select(
					QHC.CmpGt("nphase",maxfase))){
					ToDel.Delete();
				}
				Fasi2.AcceptChanges();
				FrmAskFase F = new FrmAskFase(Fasi2);
				if (F.ShowDialog()!=DialogResult.OK) return;
				selectedfase = Convert.ToInt32( F.cmbFasi.SelectedValue);
			}
			rowfilter= GetFilterForSelection(RigheSelezionate, "expense", selectedfase);
			rowfilter = QHS.AppAnd(rowfilter, QHS.CmpEq("nphase",selectedfase)
                );
			decimal tot = 0;
			foreach (DataRow R in RigheSelezionate){
				tot+= CfgFn.GetNoNullDecimal(R["amount"]);
			}
			rowfilter = QHS.AppAnd(rowfilter,QHS.CmpGe("available",tot));
			MetaData S = Disp.Get("expense");
			S.DS= DS.Clone();
			S.FilterLocked=true;
			DataRow Choosen  = S.SelectOne("default",rowfilter,"expense",null);
			if (Choosen==null) return;
			RighePadriSpesa[Choosen["idexp"].ToString()]= Choosen;
			foreach (DataRow R in RigheSelezionate){
				R["parentidexp"]=Choosen["idexp"];
				int I = Convert.ToInt32(R["idexp"].ToString());
				TAutomatismi.Rows[I]["parentidexp"]= Choosen["idexp"];
			}
			RicalcolaCampiCalcolati();
		}

		private void btnScollegaS_Click(object sender, System.EventArgs e) {
			DataRow []RigheSelezionate= GetGridSelectedRows(gridSpesa);
			if (RigheSelezionate==null) return;
			if (RigheSelezionate.Length==0) return;
			foreach (DataRow R in RigheSelezionate){
				R["parentidexp"]=DBNull.Value;
				int I = Convert.ToInt32(R["idexp"].ToString());
				TAutomatismi.Rows[I]["parentidexp"]= DBNull.Value;
			}
			RicalcolaCampiCalcolati();
		}

        void AddVoceBilancio(object ID, string codbil) {
            if (ID == DBNull.Value) return;
            if (DS.fin.Select(QHC.CmpEq("idfin", ID)).Length > 0) return;
            DataRow NewBil = DS.fin.NewRow();
            NewBil["idfin"] = ID;
            NewBil["codefin"] = codbil;
            DS.fin.Rows.Add(NewBil);
            NewBil.AcceptChanges();
        }

        void AddVoceUpb(object ID, string codupb) {
            if (ID == DBNull.Value) return;
            if (DS.upb.Select(QHC.CmpEq("idupb", ID)).Length > 0) return;

            DataRow NewUpb = DS.upb.NewRow();
            NewUpb["idupb"] = ID;
            NewUpb["codeupb"] = codupb;
            DS.upb.Rows.Add(NewUpb);
            NewUpb.AcceptChanges();
        }


        void AddVoceCreditore(object codice, string denominazione) {
            if (codice == DBNull.Value) return;
            if (DS.registry.Select(QHC.CmpEq("idreg", codice)).Length > 0) return;

            DataRow NewCred = DS.registry.NewRow();
            NewCred["idreg"] = codice;
            NewCred["title"] = denominazione;
            DS.registry.Rows.Add(NewCred);
            NewCred.AcceptChanges();
        }

        void AddVociCollegate(DataRow SP_Row) {
            AddVoceBilancio(SP_Row["idfin"], SP_Row["codefin"].ToString());
            AddVoceUpb(SP_Row["idupb"], SP_Row["codeupb"].ToString());
            AddVoceCreditore(SP_Row["idreg"], SP_Row["registry"].ToString());
        }

        void FillMovimento(DataRow E_S, DataRow Auto) { //, string idmovimento)
            int esercizio = Convert.ToInt32(Meta.GetSys("esercizio"));
            DateTime DataCont = Convert.ToDateTime(Meta.GetSys("datacontabile"));
            E_S.BeginEdit();
            E_S["ymov"] = esercizio;
            E_S["adate"] = DataCont;
            //E_S["flag"]="N";
            //E_S["autotaxflag"]="N";
            //E_S["autoclawbackflag"]="N";

            string[] fields_to_copy = new string[] { 
													  "idman","idreg","description","autokind"};
            foreach (string field in fields_to_copy) {
                if (Auto.Table.Columns[field] == null) continue;
                if (E_S.Table.Columns.Contains(field)) E_S[field] = Auto[field];
            }

            //E_S["amount"]= CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(Auto["amount"]));
            E_S.EndEdit();
        }


        void FillImputazioneMovimento(DataRow ImpMov, DataRow Auto) {
            string[] fields_to_copy = new string[] { "idfin", "idupb", "codefin", "codeupb" };
            foreach (string field in fields_to_copy) {
                if (Auto.Table.Columns[field] == null) continue;
                if (ImpMov.Table.Columns[field] == null) continue;
                ImpMov[field] = Auto[field];
            }
            ImpMov["amount"] = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(Auto["amount"]));
        }




        private int getIntSys(string nome) {
            int s = CfgFn.GetNoNullInt32(Meta.GetSys(nome));
            if (s == 0) return 99;
            return s;
        }

        bool MovimentiFinanziariConfigurati() {
            DataRow rConfIVA = DS.config.Rows[0];
            if ((rConfIVA["flagpayment"].ToString().ToUpper() == "S") &&
                (rConfIVA["paymentagency"] != DBNull.Value))
                return true;
            return false;
        }


		private bool insertMov(DataRow rIvaPay) {
            if (!MovimentiFinanziariConfigurati()) return true;

			MetaData MetaM = Meta.Dispatcher.Get("expense");
			MetaM.SetDefaults(DS.Tables["expense"]);
			MetaData MetaImputazioneM = Meta.Dispatcher.Get("expenseyear");
			MetaImputazioneM.SetDefaults(DS.Tables["expenseyear"]);
            MetaData MetaSpesaLast = Meta.Dispatcher.Get("expenselast");
            MetaSpesaLast.SetDefaults(DS.expenselast);


			int fasemax = 0;
			int faseCreditoreDebitore = 0;
			int faseBilancio = 0;

			fasemax = getIntSys("maxexpensephase");
			faseCreditoreDebitore = getIntSys("expenseregphase");
			faseBilancio = getIntSys("expensefinphase");
            int faselast = (generaTuttelafasi) ? getIntSys("maxexpensephase") : getIntSys("expenseregphase");

            DS.Tables["expenseview"].AcceptChanges();

			DS.Tables["expense"].Clear();
			DS.Tables["expenseyear"].Clear();
            DS.Tables["expenselast"].Clear();
            string filterMovKind = QHC.CmpEq("movkind","Spesa");

			DataRow [] Auto = TAutomatismi.Select(filterMovKind);
			DataTable Mov = DS.Tables["expense"];
			DataTable ImpMov = DS.Tables["expenseyear"];
            DataTable LastMov = DS.Tables["expenselast"];
			foreach(DataRow R in Auto){
				AddVociCollegate(R);
				DataRow ParentR = null;

				for(int faseCorrente = 1; faseCorrente <= faselast; faseCorrente++) {
					Mov.Columns["nphase"].DefaultValue = faseCorrente;

					DataRow NewMovRow = MetaM.Get_New_Row(ParentR, Mov);
					ParentR = NewMovRow;

					FillMovimento(NewMovRow,R);
					R["idmovimento"]= NewMovRow["idexp"];
					NewMovRow["nphase"] = faseCorrente;

					if (faseCorrente < faseCreditoreDebitore) {
						NewMovRow["idreg"] = DBNull.Value;
					}
	
					if (faseCorrente==fasemax) {
                        object codicecreddeb = R["idreg"];
                        DataRow ModPagam = CfgFn.ModalitaPagamentoDefault(Meta.Conn, codicecreddeb);
                        if (ModPagam == null) {
                            MessageBox.Show(this,
                                "E' necessario che sia definita almeno una modalità di pagamento per il percipiente " +
                                "\"" + R["registry"].ToString() + "\"\n\n" +
                                "Dati non salvati", "Errore", MessageBoxButtons.OK);
                            return false;
                        }
                        DataRow NewLastMov = MetaSpesaLast.Get_New_Row(NewMovRow, LastMov);
                        NewLastMov["idregistrypaymethod"] = ModPagam["idregistrypaymethod"];
                        NewLastMov["idpaymethod"] = ModPagam["idpaymethod"];
                        NewLastMov["iban"] = ModPagam["iban"];
                        NewLastMov["cin"] = ModPagam["cin"];
                        NewLastMov["idbank"] = ModPagam["idbank"];
                        NewLastMov["idcab"] = ModPagam["idcab"];
                        NewLastMov["cc"] = ModPagam["cc"];
                        NewLastMov["paymentdescr"] = ModPagam["paymentdescr"];
                        NewLastMov["iddeputy"] = ModPagam["iddeputy"];
                        NewLastMov["refexternaldoc"] = ModPagam["refexternaldoc"];

                        NewLastMov["biccode"] = ModPagam["biccode"];
                        NewLastMov["extracode"] = ModPagam["extracode"];
                        NewLastMov["idchargehandling"] = ModPagam["idchargehandling"];
                        if (LeggiFlagEsenteBancaPredefinita())
                        {
                            int flag = CfgFn.GetNoNullInt32(NewLastMov["flag"]);
                            int flag_exemption = (CfgFn.GetNoNullInt32(NewLastMov["flag"]) & 0xF7) | ((CfgFn.GetNoNullInt32(ModPagam["flag"]) & 1) << 3);
                            NewLastMov["flag"] = flag_exemption;
                        }
                        object idpaymethod = ModPagam["idpaymethod"];
                        string filterpaymethod = QHS.CmpEq("idpaymethod", idpaymethod);

                        DataTable TPaymethod = Conn.RUN_SELECT("paymethod", "*", null, filterpaymethod, null, true);

                        if ((TPaymethod != null) && (TPaymethod.Rows.Count > 0))
                        {
                            object paymethod_allowdeputy = TPaymethod.Rows[0]["allowdeputy"];
                            object paymethod_flag = TPaymethod.Rows[0]["flag"];
                            NewLastMov["paymethod_allowdeputy"] = paymethod_allowdeputy;
                            NewLastMov["paymethod_flag"] = paymethod_flag;
                        }
					}




					DataRow NewImpMov = ImpMov.NewRow();

					FillImputazioneMovimento(NewImpMov, R);
					NewImpMov["idexp"]= NewMovRow["idexp"];
					NewImpMov["ayear"]= esercizio;

					if (faseCorrente < faseBilancio) {
						NewImpMov["idfin"] = DBNull.Value;
						NewImpMov["idupb"] = DBNull.Value;
					}
					ImpMov.Rows.Add(NewImpMov);
				}
			}
            string idfield_name = "idexp";

            //Imposta il livsupid di tutte le righe per cui è necessario
            string tName = Mov.TableName;
            string paridfield = (tName == "expense") ? "parentidexp" : "parentidinc";
            foreach (DataRow R in Auto) {
                if (R["parentidexp"] == DBNull.Value) continue;
                object idtolink = R["parentidexp"];

                object idmov = R["idmovimento"];

                int nfasetolink = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE(tName, QHS.CmpEq("idexp", idtolink), "nphase"));
                DataRow MovSel = Mov.Select(QHC.CmpEq(idfield_name, idmov))[0];
                int currfase = CfgFn.GetNoNullInt32(MovSel["nphase"]);

                while (currfase > (nfasetolink + 1)) {
                    idmov = MovSel[paridfield];
                    MovSel = Mov.Select(QHC.CmpEq(idfield_name, idmov))[0];
                    currfase--;
                }
                MovSel[paridfield] = idtolink;

            }

            //Cancella tutto ciò che non ha figli e non è di ultima fase sino a che non trova + nulla
            bool keep = true;
            while (keep) {
                keep = false;
                string filternolastphase = QHC.CmpNe("nphase", faselast);                
                foreach (DataRow Parent in Mov.Select(filternolastphase)) {
                    object idpar = Parent[idfield_name];
                    string filterchild = QHC.CmpEq("parent" + idfield_name, idpar);
                    if (Mov.Select(filterchild).Length == 0) {
                        string filterimp = QHC.CmpEq(idfield_name, Parent[idfield_name]);
                        DataRow Imp = ImpMov.Select(filterimp)[0];
                        Imp.Delete();
                        Parent.Delete();
                        keep = true;
                    }
                }
            }


			foreach (DataRow R in DS.Tables["expense"].Rows) {
				DataRow NewIvaPay_MovRow = DS.Tables["ivapayexpense"].NewRow();
				NewIvaPay_MovRow["yivapay"] = rIvaPay["yivapay"];
				NewIvaPay_MovRow["nivapay"] = rIvaPay["nivapay"];
				NewIvaPay_MovRow["idexp"]=R["idexp"];
				NewIvaPay_MovRow["cu"]="AAAA";
				NewIvaPay_MovRow["ct"]=DateTime.Now;
				NewIvaPay_MovRow["lu"]="AAAAA";
				NewIvaPay_MovRow["lt"]=DateTime.Now;
				DS.Tables["ivapayexpense"].Rows.Add(NewIvaPay_MovRow);
			}

			foreach (DataRow R in DS.Tables["expense"].Rows){
                R["autokind"] = 13;
				R["description"]="Acconto IVA";
			}

			return true;

			//JTR 31.10.2006 Commentata, funzione che deve essere svolta dalla classe GestioneAutomatismi
			//generaMandatiReversali(DS);
		}

        private bool LeggiFlagEsenteBancaPredefinita()
        {
            DataTable tTreasurer = Meta.Conn.RUN_SELECT("treasurer", "*", null, QHS.AppAnd(QHS.CmpEq("flagdefault", "S"), QHS.BitSet("flag", 1)), null, false);
            if (tTreasurer.Rows.Count == 0) return false;
            else
                return true;
        }
        void ViewAutomatismi(DataSet DS) {
            string spesa = null;
            if (DS.Tables["expense"] != null) {
                DataTable Var = DS.Tables["expense"];
                spesa = QHC.FieldIn("idexp", Var.Select(), "idexp");
            }

            Form F = ShowAutomatismi.Show(Meta, spesa, null, null, null);
            F.ShowDialog(this);
        }
        private string LeggiMetodoUsato() {
            if (rdbMetodoAcconto1.Checked)
                return "1";
            if (rdbMetodoAcconto2.Checked)
                return "2";
            if (rdbMetodoAcconto3.Checked)
                return "3";
            if (rdbMetodoAcconto4.Checked)
                return "4";
            return null;
        }

        private void SaveData() {
			//INSERT_MovimentiSpesa();

			//riga di liquidazioneiva
            DS.Tables["expenseview"].AcceptChanges();
			Meta.SetDefaults(DS.ivapay);
			DataRow Rliquidazione=Meta.Get_New_Row(null,DS.ivapay);
			Rliquidazione["paymentkind"]="A";
			Rliquidazione["start"]=Meta.GetSys("datacontabile");
			Rliquidazione["stop"]=Meta.GetSys("datacontabile");
			Rliquidazione["creditamount"]=HelpForm.GetObjectFromString(typeof(decimal),txtImporto.Text,null);
            Rliquidazione["creditamount"] = HelpForm.GetObjectFromString(typeof(decimal), txtImporto.Text, null);
            Rliquidazione["totalcredit"] = HelpForm.GetObjectFromString(typeof(decimal), txtImporto.Text, null);
            Rliquidazione["flag"] = 3;
            Rliquidazione["advancecomputemethod"] = LeggiMetodoUsato();
            if (!MovimentiFinanziariConfigurati()) {
                Easy_PostData EP = new Easy_PostData();
                EP.InitClass(DS, Conn);
                bool res2 = EP.DO_POST();
                if (res2) MessageBox.Show("Acconto creato correttamente.");
                return;
            }

			bool itsOk = insertMov(Rliquidazione);
			if (!itsOk) return;
			int fasespesamax = CfgFn.GetNoNullInt32(Meta.GetSys("maxexpensephase"));
			GestioneAutomatismi ga = new GestioneAutomatismi(this, Meta.Conn, Meta.Dispatcher, DS.Copy(),
				fasespesamax, fasespesamax, "ivapay",true);
            ga.GeneraClassificazioniAutomatiche(ga.DSP, true);
            bool res = ga.GeneraAutomatismiAfterPost(true);
			if (!res) {
				MessageBox.Show(this, "Si è verificato un errore o si è deciso di non salvare! L'operazione sarà terminata");
				return;
			}
            //ga.GeneraClassificazioniIndirette(ga.DSP, true);lo fa già GeneraClassificazioniAutomatiche
            res = ga.doPost(Meta.Dispatcher);
			if (res) {
				ViewAutomatismi(ga.DSP);
				return;
			}

        }

        private void btnCambiaUPBSpesa_Click(object sender, EventArgs e) {
            DataRow[] RigheSelezionate = GetGridSelectedRows(gridSpesa);
            if (RigheSelezionate == null) return;
            if (RigheSelezionate.Length == 0) return;
            cambiaUPB(RigheSelezionate);
        }
        void cambiaUPB(DataRow[] RigheSelezionate) {
            if (RigheSelezionate == null) return;
            if (RigheSelezionate.Length == 0) return;

            object idupb = RigheSelezionate[0]["idupb"];
            object idfin = RigheSelezionate[0]["idfin"];

            FrmAskInfo AskUpb = new FrmAskInfo(idupb, idfin, Disp, Conn);

            if (AskUpb.ShowDialog() != DialogResult.OK) return;
            if (AskUpb.SelectedUpb == null) return;
            if (AskUpb.SelectedUpb["idupb"] == DBNull.Value) return;

            for (int i = 0; i < RigheSelezionate.Length; i++) {
                RigheSelezionate[i]["idupb"] = AskUpb.SelectedUpb["idupb"];
                RigheSelezionate[i]["codeupb"] = AskUpb.SelectedUpb["codeupb"];
                TAutomatismi.Rows[i]["idupb"] = AskUpb.SelectedUpb["idupb"];
                TAutomatismi.Rows[i]["codeupb"] = AskUpb.SelectedUpb["codeupb"];
                TAutomatismi.Rows[i].AcceptChanges();
            }
        }
	}
}