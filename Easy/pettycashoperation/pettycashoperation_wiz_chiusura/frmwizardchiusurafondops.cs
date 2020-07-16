/*
    Easy
    Copyright (C) 2020 Universit√† degli Studi di Catania (www.unict.it)
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
using metaeasylibrary;
using funzioni_configurazione;
using movimentofunctions;
using gestioneclassificazioni;

namespace pettycashoperation_wiz_chiusura {//wizard_chiusurafondops//
	/// <summary>
	/// Summary description for frmwizardchiusurafondops.
	/// </summary>
	public class Frm_pettycashoperation_wiz_chiusura : System.Windows.Forms.Form {
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnBack;
		public vistaForm DS;
		private Crownwood.Magic.Controls.TabControl tabController;
		private Crownwood.Magic.Controls.TabPage tabpage1;
		private Crownwood.Magic.Controls.TabPage tabPage2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmbFondoPS;
		private System.Windows.Forms.DataGrid gridMovEntrata;
		private System.Windows.Forms.Label lblMessaggi;
		private System.Windows.Forms.Button btnScollegaS;
		private System.Windows.Forms.Button btnCollegaS;
		Hashtable Messaggi;
		DataAccess Conn;
		bool CanSave;
        GestioneClassificazioni ManageClassificazioni;
        DataTable SP_Result;
		MetaData Meta;
		string CustomTitle;
		int maxfaseentrata;
		Hashtable RighePadri;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox1;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_pettycashoperation_wiz_chiusura() {
			InitializeComponent();
			
			tabController.HideTabsMode = 
				Crownwood.Magic.Controls.TabControl.HideTabsModes.HideAlways;
			
			RighePadri= new Hashtable();
		}

        CQueryHelper QHC;
        QueryHelper QHS;
		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
			Messaggi = new Hashtable();
			Messaggi.Add("err_fondovuoto", "Errore: non Ë stato selezionato il fondo.");
			Messaggi.Add("err_conffondo", "Errore: non esiste o Ë incompleta la configurazione del fondo selezionato.");
			Messaggi.Add("err_fondochiuso", "Errore: Ë gi‡ presente una operazione di chiusura del fondo selezionato.");
			Messaggi.Add("err_fondoaperto", "Errore: si sta cercando di eseguire una operazione di chiusura su "+
				"un fondo non aperto.");
			Messaggi.Add("warn_fondoaperto", "Avvertimento: si sta cercando di eseguire una operazione di chiusura su "+
				"un fondo non aperto.");
			Messaggi.Add("warn_salvataggio", "Avvertimento: se l'operazione viene confermata, verranno generati i " +
				"seguenti movimenti di contabilit‡ finanziaria. Se si vuole inserire l'operazione di chiusura " +
				"cliccare su Fine.");

			this.Conn=Meta.Conn;
			int esercizio = CfgFn.GetNoNullInt32( Meta.GetSys("esercizio"));
            //DataTable Tpettycashsetup = Conn.RUN_SELECT("pettycashsetup", "idpettycash", null,
            //    QHS.AppAnd(QHS.CmpEq("ayear", esercizio), QHS.BitClear("flag", 0)), null, true);
            DataTable Tpettycashsetup = Conn.RUN_SELECT("pettycashsetup", "idpettycash", null,
                      QHS.CmpEq("ayear", esercizio), null, true);
            string ListIdpettycash = QHC.DistinctVal(Tpettycashsetup.Select(), "idpettycash");
            string filter = QHC.FieldInList("idpettycash", ListIdpettycash);
            GetData.CacheTable(DS.pettycash, filter, "description asc", true);

            GetData.CacheTable(DS.config, QHS.CmpEq("ayear", esercizio), null, true);
            //GetData.CacheTable(DS.pettycashsetup, QHS.AppAnd(QHS.CmpEq("ayear", esercizio), QHS.BitClear("flag", 0)), null, false);
            GetData.CacheTable(DS.pettycashsetup, QHS.CmpEq("ayear", esercizio), null, false);
            GetData.CacheTable(DS.incomephase);
			GetData.SetSorting(DS.incomeview,"ymov desc, nmov desc");

			CanSave=false;
		}

		public void MetaData_AfterClear() {
			// Rimuovo la parola (Ricerca) dal titolo del form
			if (Text.EndsWith("(Ricerca)")) {
				Text = Text.Substring(0,Text.Length - 9);
			}
			Meta.Name = Text;
		}

		public void MetaData_AfterActivation() {
			FormInit();
			maxfaseentrata = CfgFn.GetNoNullInt32(Meta.GetSys("maxincomephase"));
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
			this.DS = new pettycashoperation_wiz_chiusura.vistaForm();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnNext = new System.Windows.Forms.Button();
			this.btnBack = new System.Windows.Forms.Button();
			this.tabController = new Crownwood.Magic.Controls.TabControl();
			this.tabpage1 = new Crownwood.Magic.Controls.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cmbFondoPS = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
			this.btnScollegaS = new System.Windows.Forms.Button();
			this.btnCollegaS = new System.Windows.Forms.Button();
			this.gridMovEntrata = new System.Windows.Forms.DataGrid();
			this.lblMessaggi = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.tabController.SuspendLayout();
			this.tabpage1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridMovEntrata)).BeginInit();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(544, 384);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 7;
			this.btnCancel.Text = "Cancel";
			// 
			// btnNext
			// 
			this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNext.Location = new System.Drawing.Point(440, 384);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(72, 23);
			this.btnNext.TabIndex = 6;
			this.btnNext.Text = "Avanti >";
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// btnBack
			// 
			this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBack.Location = new System.Drawing.Point(360, 384);
			this.btnBack.Name = "btnBack";
			this.btnBack.Size = new System.Drawing.Size(72, 23);
			this.btnBack.TabIndex = 5;
			this.btnBack.Text = "< Indietro";
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
			// 
			// tabController
			// 
			this.tabController.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tabController.IDEPixelArea = true;
			this.tabController.Location = new System.Drawing.Point(8, 8);
			this.tabController.Name = "tabController";
			this.tabController.SelectedIndex = 0;
			this.tabController.SelectedTab = this.tabpage1;
			this.tabController.Size = new System.Drawing.Size(616, 360);
			this.tabController.TabIndex = 8;
			this.tabController.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
																							this.tabpage1,
																							this.tabPage2});
			this.tabController.SelectionChanged += new System.EventHandler(this.tabController_SelectionChanged);
			// 
			// tabpage1
			// 
			this.tabpage1.Controls.Add(this.groupBox1);
			this.tabpage1.Controls.Add(this.label4);
			this.tabpage1.Controls.Add(this.label2);
			this.tabpage1.Controls.Add(this.label1);
			this.tabpage1.Location = new System.Drawing.Point(0, 0);
			this.tabpage1.Name = "tabpage1";
			this.tabpage1.Size = new System.Drawing.Size(616, 335);
			this.tabpage1.TabIndex = 0;
			this.tabpage1.Title = "Pagina 1 di 2";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cmbFondoPS);
			this.groupBox1.Location = new System.Drawing.Point(16, 200);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(584, 56);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Fondo economale";
			// 
			// cmbFondoPS
			// 
			this.cmbFondoPS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.cmbFondoPS.DataSource = this.DS.pettycash;
			this.cmbFondoPS.DisplayMember = "description";
			this.cmbFondoPS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbFondoPS.Location = new System.Drawing.Point(8, 27);
			this.cmbFondoPS.Name = "cmbFondoPS";
			this.cmbFondoPS.Size = new System.Drawing.Size(568, 21);
			this.cmbFondoPS.TabIndex = 2;
			this.cmbFondoPS.ValueMember = "idpettycash";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.Location = new System.Drawing.Point(16, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(584, 23);
			this.label4.TabIndex = 4;
			this.label4.Text = "PROCEDURA GUIDATA DI CHIUSURA DEL FONDO ECONOMALE";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 176);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(288, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Per proseguire, selezionare il fondo e cliccare su Avanti.";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(16, 56);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(592, 40);
			this.label1.TabIndex = 0;
			this.label1.Text = @"ATTENZIONE! Questa procedura Ë l'unica che consente di chiudere un fondo economale, tutti gli altri metodi di procedere NON SONO CORRETTI. Di seguito si potranno generare movimenti di contabilit‡ finanziaria e/o collegarne di esistenti  per chiudere il fondo economale.";
			// 
			// tabPage2
			// 
			this.tabPage2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tabPage2.Controls.Add(this.btnScollegaS);
			this.tabPage2.Controls.Add(this.btnCollegaS);
			this.tabPage2.Controls.Add(this.gridMovEntrata);
			this.tabPage2.Controls.Add(this.lblMessaggi);
			this.tabPage2.Location = new System.Drawing.Point(0, 0);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Selected = false;
			this.tabPage2.Size = new System.Drawing.Size(616, 335);
			this.tabPage2.TabIndex = 2;
			this.tabPage2.Title = "Pagina 2 di 2";
			this.tabPage2.Visible = false;
			// 
			// btnScollegaS
			// 
			this.btnScollegaS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnScollegaS.Location = new System.Drawing.Point(240, 304);
			this.btnScollegaS.Name = "btnScollegaS";
			this.btnScollegaS.Size = new System.Drawing.Size(136, 23);
			this.btnScollegaS.TabIndex = 8;
			this.btnScollegaS.Text = "Annulla il collegamento";
			this.btnScollegaS.Click += new System.EventHandler(this.btnScollegaS_Click);
			// 
			// btnCollegaS
			// 
			this.btnCollegaS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnCollegaS.Location = new System.Drawing.Point(16, 304);
			this.btnCollegaS.Name = "btnCollegaS";
			this.btnCollegaS.Size = new System.Drawing.Size(176, 23);
			this.btnCollegaS.TabIndex = 7;
			this.btnCollegaS.Text = "Collega a movimento esistente...";
			this.btnCollegaS.Click += new System.EventHandler(this.btnCollega_Click);
			// 
			// gridMovEntrata
			// 
			this.gridMovEntrata.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.gridMovEntrata.DataMember = "";
			this.gridMovEntrata.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gridMovEntrata.Location = new System.Drawing.Point(16, 80);
			this.gridMovEntrata.Name = "gridMovEntrata";
			this.gridMovEntrata.Size = new System.Drawing.Size(584, 208);
			this.gridMovEntrata.TabIndex = 1;
			// 
			// lblMessaggi
			// 
			this.lblMessaggi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lblMessaggi.Location = new System.Drawing.Point(16, 16);
			this.lblMessaggi.Name = "lblMessaggi";
			this.lblMessaggi.Size = new System.Drawing.Size(584, 56);
			this.lblMessaggi.TabIndex = 0;
			this.lblMessaggi.Text = "Messaggi";
			// 
			// Frm_pettycashoperation_wiz_chiusura
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(634, 423);
			this.Controls.Add(this.tabController);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnNext);
			this.Controls.Add(this.btnBack);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Frm_pettycashoperation_wiz_chiusura";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmwizardchiusurafondops";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.tabController.ResumeLayout(false);
			this.tabpage1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridMovEntrata)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		void FormInit() {
			CustomTitle = "Chiusura";
			//Selects first tab
			DisplayTabs(0);
			Meta.Name = Text;
		}

		/// <summary>
		/// Displays tab n. NewTab and updates buttons
		/// </summary>
		/// <param name="newTab"></param>
		void DisplayTabs(int newTab) {
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
		void StandardChangeTab(int step) {
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
		/// Verifica che il fondo non sia gi‡ chiuso
		/// </summary>
		/// <param name="fondo"></param>
		/// <returns>
		/// true,  se il fondo non Ë chiuso
		///	false, se il fondo Ë gi‡ stato chiuso
		///	</returns>

		bool CheckSelezioneFondo() {
			if (cmbFondoPS.SelectedIndex==0) return false;
			return true;
		}

        bool CheckAperturaFondo(object fondo) {
            string esercizio = Meta.GetSys("esercizio").ToString();
            string filterapertura =
                QHS.AppAnd(QHS.CmpEq("yoperation", esercizio),
                QHS.AppAnd(QHS.CmpEq("idpettycash", fondo), QHS.BitSet("flag", 0)));
            int opapertura = Conn.RUN_SELECT_COUNT("pettycashoperation", filterapertura, true);
            return (opapertura == 1);
        }

		bool CheckChiusuraFondo(object fondo) {
            string filterchiusura = QHS.AppAnd(QHS.CmpEq("yoperation", Meta.GetSys("esercizio")),
                QHS.CmpEq("idpettycash", fondo), QHS.BitSet("flag", 2));
			int opchiusura = Conn.RUN_SELECT_COUNT("pettycashoperation",filterchiusura, true);
			return (opchiusura==0);
		}


        bool CheckPersPiccoleSpeseConfig(object fondo) {
            //assumo che la tabella sia cached
            if (DS.pettycashsetup.Rows.Count == 0) return false;
            DataRow[] Conf = DS.pettycashsetup.Select(
                QHC.AppAnd(QHC.CmpEq("ayear", Meta.GetSys("esercizio")), QHC.CmpEq("idpettycash", fondo)));
            if (Conf.Length != 1) return false;
            bool generamovimenti = (CfgFn.GetNoNullInt32(Conf[0]["flag"]) & 1) == 0;

            if ((Conf[0]["idfinincome"] == DBNull.Value && generamovimenti) ||
                Conf[0]["registrymanager"] == DBNull.Value ||
                Conf[0]["amount"] == DBNull.Value)
                return false;
            return true;
        }

		/// <summary>
		/// Must return true if operation is possible, and do any
		///  operation related to change from tab oldTab to newTab
		/// </summary>
		/// <param name="oldTab"></param>
		/// <param name="newTab"></param>
		/// <returns></returns>
		bool CustomChangeTab(int oldTab, int newTab) {
			//if (oldTab==0) 	return true ; // 0->1: nothing to do
			if ((oldTab==1)&&(newTab==0)) {
				DS.incomeview.Clear();
				btnNext.Enabled=true;
				return true; //1->0:nothing to do!
			}
			if ((oldTab==0)&&(newTab==1)) {
				if (CheckInputData())
                    return pettycashclosing(); 
				else
					btnNext.Enabled=false;
			}
			return true;
		}

		bool CheckInputData() {
			if (!CheckSelezioneFondo()) {
				lblMessaggi.Text=Messaggi["err_fondovuoto"].ToString();
				CanSave=false;
				return false;
			}

			if (!CheckPersPiccoleSpeseConfig(cmbFondoPS.SelectedValue)) {
				lblMessaggi.Text=Messaggi["err_conffondo"].ToString();
				CanSave=false;
				return false;
			}

			if (!CheckChiusuraFondo(cmbFondoPS.SelectedValue)) {
				lblMessaggi.Text=Messaggi["err_fondochiuso"].ToString();
				CanSave=false;
				return false;
			}
			
			if (!CheckAperturaFondo(cmbFondoPS.SelectedValue)) {
				DialogResult res = MessageBox.Show(this, Messaggi["warn_fondoaperto"].ToString()+"\nContinuare?", 
					"Avvertimento", MessageBoxButtons.YesNo);
				if (res!=DialogResult.Yes) {
					lblMessaggi.Text=Messaggi["err_fondoaperto"].ToString();
					CanSave=false;
					return false;
				}
			}

			lblMessaggi.Text=Messaggi["warn_salvataggio"].ToString();
			CanSave=true;
			return true;
		}


		void AddRowToTable(DataRow R, DataTable T,int i) { 			
			DataRow NewR = T.NewRow();
			if (T.TableName == "incomeview"){
				NewR["idinc"]=i;
			}
			if (T.TableName == "expenseview"){
				NewR["idexp"]=i;
			}
			foreach(DataColumn C in R.Table.Columns) {
				if (C.ColumnName == "idmovimento") continue;
				if (C.ColumnName == "movkind") continue;
				NewR[C.ColumnName]= R[C.ColumnName];
			}
			T.Rows.Add(NewR);
		}
		void FillTables(DataTable Automatismi) {
			MetaDataDispatcher Disp;
			Disp=Meta.Dispatcher;
		
			DS.incomeview.Clear();
			for (int i=0; i<Automatismi.Rows.Count;i++){
				DataRow R = Automatismi.Rows[i];
				//if (R["nphase"].ToString()!=maxfaseentrata)continue;
				AddRowToTable(R, DS.incomeview, i);
			}
			MetaData MEntrataView = Disp.Get("incomeview");
			MEntrataView.DescribeColumns(DS.incomeview,"autogeneratips");

			HelpForm.SetDataGrid(gridMovEntrata, DS.incomeview);			

			RicalcolaCampiCalcolati();
		}

        bool pettycashclosing() {
            int esercizio= Convert.ToInt32(Meta.GetSys("esercizio"));
            object idpettycash = cmbFondoPS.SelectedValue;

            DataRow[] Rpettycash = DS.pettycash.Select(QHC.CmpEq("idpettycash", idpettycash));
            if (Rpettycash.Length == 0) return false;


            DataRow[] descr = DS.pettycash.Select(QHC.CmpEq("idpettycash", idpettycash));
            string descrizione = descr[0]["description"].ToString();
            DataRow[] Conf = DS.pettycashsetup.Select(
                QHC.AppAnd(QHC.CmpEq("ayear", esercizio), QHC.CmpEq("idpettycash", idpettycash)));

            bool generamovimenti = (CfgFn.GetNoNullInt32(Conf[0]["flag"]) & 1) == 0;
            if (!generamovimenti) return true;



            // Le voci di bilancio associate al fondo economale sono sull'UPB libero (0001) se non Ë stato configurato alcun UPB nella config. del Fondo.
            string idupb = "";
            idupb = Conf[0]["idupb"].ToString();
            if (idupb == ""){
                idupb = "0001";
            }
            DataRow[] Rupb = Conn.RUN_SELECT("upb", "*", null, QHS.CmpEq("idupb", idupb), null, true).Select();
            if (Rupb.Length == 0) return false;

            string query = "";
            query = "SELECT "
            + " movkind = 'Entrata' , idreg = registrymanager , registry = manager , idfin = idfinincome , "
            + " codefin = finincomecode ,"
            + " idupb = " + QHS.quote(idupb) + ","
            + " codeupb = " + QHS.quote(Rupb[0]["codeupb"]) + ","
            + " description = " + QHS.quote("Chiusura Fondo Economale" + Rpettycash[0]["description"]) + "," 
            + " amount, "
            + " idman = " + QHS.quote(Rupb[0]["idman"])  
            + " FROM  pettycashsetupview "
            + " WHERE " + QHS.AppAnd(QHS.CmpEq("ayear", esercizio), QHS.CmpEq("idpettycash", idpettycash));

            string errMess;
            DataTable pettycashclosing = Conn.SQLRunner(query, 0, out errMess);

            if (pettycashclosing.Rows.Count == 0) return false;
            pettycashclosing.Columns.Add("idmovimento", typeof(int));

            FillTables(pettycashclosing);
            pettycashclosing.Columns.Add("livsupid", typeof(int));
            SP_Result = pettycashclosing.Copy();
            return true;
        }

        private void btnBack_Click(object sender, System.EventArgs e) {
			StandardChangeTab(-1);
		}

		private void btnNext_Click(object sender, System.EventArgs e) {
			if (tabController.SelectedIndex==tabController.TabPages.Count-1 && CanSave)
				SaveData();
			StandardChangeTab(+1);
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



        void AddVoceFase(object codice, string descr) {
            if (codice == DBNull.Value) return;
            if (DS.incomephase.Select(QHC.CmpEq("nphase", codice)).Length > 0) return;

            DataRow NewFase = DS.incomephase.NewRow();
            NewFase["nphase"] = codice;
            NewFase["description"] = descr;
            DS.incomephase.Rows.Add(NewFase);
            NewFase.AcceptChanges();
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
		void AddVociCollegate(DataRow SP_Row){
			AddVoceBilancio(SP_Row["idfin"], 
				SP_Row["codefin"].ToString());
			AddVoceUpb(SP_Row["idupb"],
				SP_Row["codeupb"].ToString());
			AddVoceCreditore(SP_Row["idreg"],
				SP_Row["registry"].ToString());
		}

		void FillMovimento(DataRow E_S, DataRow Auto){ //, string idmovimento)
			int esercizio= Convert.ToInt32(Meta.GetSys("esercizio"));
			DateTime DataCont= Convert.ToDateTime(Meta.GetSys("datacontabile"));
			E_S.BeginEdit();
			E_S["ymov"]= esercizio;
            //E_S["ycreation"]= esercizio;
			E_S["adate"]= DataCont;
            //E_S["fulfilled"]="N";

			string [] fields_to_copy=new string[] { 
													  "idman","idreg","description","autokind"};
			foreach(string field in fields_to_copy) {
				if (Auto.Table.Columns[field] == null) continue;
				if (E_S.Table.Columns.Contains(field))E_S[field]= Auto[field];
			}
			
            //E_S["amount"]= CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(Auto["amount"]));
			E_S.EndEdit();
		}

		void FillImputazioneMovimento(DataRow ImpMov, DataRow Auto){
			string [] fields_to_copy=new string[] { 
													  "idfin","idupb","codefin"};
			foreach(string field in fields_to_copy) {
				if (Auto.Table.Columns[field] == null) continue;
				if (ImpMov.Table.Columns[field] == null) continue;
				ImpMov[field]= Auto[field];
			}
			ImpMov["amount"]= CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(Auto["amount"]));
		}

        private int getIntSys(string nome) {
            int s = CfgFn.GetNoNullInt32(Meta.GetSys(nome));
            if (s == 0) return 99;
            return s;
        }


        private void SaveData() {
            MetaData MetaM = Meta.Dispatcher.Get("income");
            MetaM.SetDefaults(DS.income);

            MetaData MetaImputazioneEntrata = Meta.Dispatcher.Get("incomeyear");
            MetaImputazioneEntrata.SetDefaults(DS.incomeyear);

            MetaData MetaEntrataLast = Meta.Dispatcher.Get("incomelast");
            MetaEntrataLast.SetDefaults(DS.incomelast);

            int esercizio = getIntSys("esercizio");
            int faseentratamax = getIntSys("maxincomephase");
            int faseCreditoreDebitoreEntrata = getIntSys("incomeregphase");
            int faseBilancioEntrata = getIntSys("incomefinphase");


            object codicefondops = cmbFondoPS.SelectedValue;
            DataRow[] descr = DS.pettycash.Select(QHC.CmpEq("idpettycash", codicefondops));
            string descrizione = descr[0]["description"].ToString();
            DataRow[] Conf = DS.pettycashsetup.Select(
                QHC.AppAnd(QHC.CmpEq("ayear", esercizio), QHC.CmpEq("idpettycash", codicefondops)));

            bool generamovimenti = (CfgFn.GetNoNullInt32(Conf[0]["flag"]) & 1) == 0;


            DS.incomeview.AcceptChanges();

            DS.Tables["income"].Clear();
            DS.Tables["incomeyear"].Clear();
            DS.Tables["incomelast"].Clear();

            DataRow[] Auto = generamovimenti ? SP_Result.Select() : new DataRow[0];
            DataTable Mov = DS.income;
            DataTable ImpMov = DS.incomeyear;
            DataTable LastMov = DS.incomelast;

            foreach (DataRow R in Auto) {
                AddVociCollegate(R);
                DataRow ParentR = null;

                for (int faseCorrente = 1; faseCorrente <= faseentratamax; faseCorrente++) {
                    Mov.Columns["nphase"].DefaultValue = faseCorrente;

                    DataRow NewEntrataRow = MetaM.Get_New_Row(ParentR, Mov);
                    ParentR = NewEntrataRow;

                    FillMovimento(NewEntrataRow, R);
                    R["idmovimento"] = NewEntrataRow["idinc"];
                    NewEntrataRow["nphase"] = faseCorrente;

                    if (faseCorrente < faseCreditoreDebitoreEntrata) {
                        NewEntrataRow["idreg"] = DBNull.Value;
                    }

                    if (faseCorrente == faseentratamax) {
                        DataRow NewLastMov = MetaEntrataLast.Get_New_Row(NewEntrataRow, DS.incomelast);
                    }


                    DataRow NewImpMov = ImpMov.NewRow();

                    FillImputazioneMovimento(NewImpMov, R);
                    //NewImpMov["nphase"] = faseCorrente;
                    NewImpMov["idinc"] = NewEntrataRow["idinc"];
                    NewImpMov["ayear"] = esercizio;

                    if (faseCorrente < faseBilancioEntrata) {
                        NewImpMov["idfin"] = DBNull.Value;
                        NewImpMov["idupb"] = DBNull.Value;
                    }

                    ImpMov.Rows.Add(NewImpMov);
                }
            }
            string idfieldname = "idinc";
            //Imposta il livsupid di tutte le righe per cui Ë necessario
            foreach (DataRow R in Auto) {
                if (R["livsupid"] == DBNull.Value) continue;
                object idtolink = R["livsupid"];

                object idmov = R["idmovimento"];

                int nfasetolink = CfgFn.GetNoNullInt32(Meta.Conn.DO_READ_VALUE("income", QHS.CmpEq("idinc", idtolink), "nphase"));
                DataRow MovSel = Mov.Select(QHC.CmpEq("idinc", idmov))[0];
                int currfase = CfgFn.GetNoNullInt32(MovSel["nphase"]);

                while (currfase > (nfasetolink + 1)) {
                    idmov = MovSel["parentidinc"];
                    MovSel = Mov.Select(QHC.CmpEq("idinc", idmov))[0];
                    currfase--;
                }
                MovSel["parentidinc"] = idtolink;

            }
            //Cancella tutto ciÚ che non ha figli e non Ë di ultima fase sino a che non trova + nulla
            bool keep = true;
            int fasemax = faseentratamax;
            while (keep && generamovimenti) {
                keep = false;
                string filternolastphase = QHC.CmpNe("nphase", fasemax);
                foreach (DataRow Parent in Mov.Select(filternolastphase)) {
                    object idpar = Parent[idfieldname];
                    string filterchild = QHC.CmpEq("parent" + idfieldname, idpar);
                    if (Mov.Select(filterchild).Length == 0) {
                        string filterimp = QHC.CmpEq(idfieldname, Parent[idfieldname]);
                        DataRow Imp = ImpMov.Select(filterimp)[0];
                        Imp.Delete();
                        Parent.Delete();
                        keep = true;
                    }
                }
            }



            // chiamare la SP sp_calc_impaperturapspese oppure prendere l'importo da
            // perspiccolespese (che Ë la stessa cosa che fa la SP)
            DataRow NewOpfondoPSRow = Meta.Get_New_Row(null, DS.pettycashoperation);
            NewOpfondoPSRow["flag"] = 4;
            NewOpfondoPSRow["idpettycash"] = codicefondops;
            NewOpfondoPSRow["amount"] = Conf[0]["amount"];
            NewOpfondoPSRow["description"] = descrizione;
            //DS.opfondopiccolespese.Rows.Add(NewOpfondoPSRow);

            foreach (DataRow R in DS.income.Rows) {
                DataRow NewPS_EntrataRow = DS.pettycashincome.NewRow();
                NewPS_EntrataRow["yoperation"] = NewOpfondoPSRow["yoperation"];
                NewPS_EntrataRow["noperation"] = NewOpfondoPSRow["noperation"];
                NewPS_EntrataRow["idpettycash"] = NewOpfondoPSRow["idpettycash"];
                NewPS_EntrataRow["idinc"] = R["idinc"];
                NewPS_EntrataRow["cu"] = "AAAA";
                NewPS_EntrataRow["ct"] = DateTime.Now;
                NewPS_EntrataRow["lu"] = "AAAAA";
                NewPS_EntrataRow["lt"] = DateTime.Now;
                DS.pettycashincome.Rows.Add(NewPS_EntrataRow);
            }

            foreach (DataRow R in DS.income.Rows) {
                R["autocode"] = codicefondops;
                R["autokind"] = 7;
            }
            bool res = true;
            DataRow rPettyCashSetup = DS.pettycashsetup.Select(QHC.CmpEq("idpettycash", cmbFondoPS.SelectedValue))[0];
            string autoClassify = rPettyCashSetup["autoclassify"].ToString().ToUpper();


            if (generamovimenti) {
                GestioneAutomatismi ga = new GestioneAutomatismi(this, Meta.Conn, Meta.Dispatcher, DS.Copy(),
                    faseentratamax, faseentratamax, "pettycashoperation", true);
                ga.GestioneFondoEconomale = true;
                string newcomputesorting = Meta.Conn.DO_READ_VALUE("siopekind", QHC.CmpEq("codesorkind_siopeentrate", Meta.GetSys("codesorkind_siopeentrate")), "newcomputesorting").ToString();
                if (newcomputesorting == "S") {
                    ManageClassificazioni = new GestioneClassificazioni(Meta, null, null, null, null, null, null, null, null);
                    ManageClassificazioni.ClassificaTramiteClassDocumento(ga.DSP, DS);
                    ManageClassificazioni.completaClassificazioniSiope(ga.DSP.Tables["incomesorted"], ga.DSP);
                }
                if (autoClassify == "S") {
                    ga.GeneraClassificazioniAutomatiche(ga.DSP, true);
                }                

                res = ga.GeneraAutomatismiAfterPost(true);
                if (!res) {
                    MessageBox.Show(this, "Si Ë verificato un errore o si Ë deciso di non salvare! L'operazione sar‡ terminata");
                    return;
                }
                //ga.GeneraClassificazioniIndirette(ga.DSP, true);   vedo come fa in apertura, visto che il task 9791 dice che le duplica

                res = ga.doPost(Meta.Dispatcher);
                if (res) {
                    ViewAutomatismi(ga.DSP);
                }
            }
            else {
                Easy_PostData MyPostData = new Easy_PostData();
                MyPostData.InitClass(DS.Copy(), Conn);
                if (MyPostData.DO_POST()) {
                    MessageBox.Show("Salvataggio effettuato correttamente");
                }
            }

        }

		
		void ViewAutomatismi(DataSet DS){
			string entrata=null;
			if (DS.Tables["income"]!=null){
				DataTable Var = DS.Tables["income"];
                entrata = QHC.FieldIn("idinc", Var.Select(), "idinc");

			}
			
			Form F = ShowAutomatismi.Show(Meta,null,entrata,null,null);
			F.ShowDialog(this);


		}

		string GetFilterForSelection(DataRow []Selected, string table, int livello){
			string filter="";
            int minfasebil = CfgFn.GetNoNullInt32(Meta.GetSys(table + "finphase"));
            int minfasecred = CfgFn.GetNoNullInt32(Meta.GetSys(table + "regphase"));

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



		int GetMaxFaseForSelection(DataRow []Selected, string table){
            int minfasecred = 99;
            int minfasebil = 99;
            if (table == "expense") {
                minfasecred = Convert.ToInt32(Conn.GetSys("expenseregphase"));
                minfasebil = Convert.ToInt32(Conn.GetSys("expensefinphase"));
            }
            if (table == "income") {
                minfasecred = Convert.ToInt32(Conn.GetSys("incomeregphase"));
                minfasebil = Convert.ToInt32(Conn.GetSys("incomefinphase"));
            }
			int fasecurr=99;

			if (table=="income"){
				fasecurr=Convert.ToInt32(maxfaseentrata)-1;
			}

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


		private DataRow[] GetGridSelectedRows(DataGrid G){
			if (G.DataMember==null) return null;
			if (G.DataSource==null) return null;
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


		private void btnCollega_Click(object sender, System.EventArgs e) {
			DataRow []RigheSelezionate= GetGridSelectedRows(gridMovEntrata);
			if (RigheSelezionate==null) return;
			if (RigheSelezionate.Length==0) return;
			string rowfilter;
			int maxfase = GetMaxFaseForSelection(RigheSelezionate, "income");
			if (maxfase<1){
				MessageBox.Show("Non Ë possibile collegare tutte le righe selezionate ad uno stesso movimento.\n"+
					"Le informazioni di bilancio, versante e UPB sono "+
					"troppo diverse tra loro.","Errore");
				return;
			}
			int selectedfase=maxfase;
			if (maxfase>1){
				DataTable Fasi2=  DS.incomephase.Copy();
				foreach (DataRow ToDel in Fasi2.Select(
					"(nphase>"+maxfase+")")){
					ToDel.Delete();
				}
				Fasi2.AcceptChanges();
				FrmAskFase F = new FrmAskFase(Fasi2);
				if (F.ShowDialog()!=DialogResult.OK) return;
				selectedfase = Convert.ToInt32( F.cmbFasi.SelectedValue);
			}
            rowfilter = GetFilterForSelection(RigheSelezionate, "income", selectedfase);
            rowfilter = QHS.AppAnd(rowfilter, QHS.CmpEq("nphase", selectedfase));

			decimal tot = 0;
			foreach (DataRow R in RigheSelezionate){
				tot+= CfgFn.GetNoNullDecimal(R["amount"]);
			}
            rowfilter = QHS.AppAnd(rowfilter, QHS.CmpGe("available", tot));
			MetaData E = Meta.Dispatcher.Get("income");
			E.FilterLocked=true;
			E.DS= DS.Clone();
			DataRow Choosen  = E.SelectOne("default",rowfilter,"income",null);
			if (Choosen==null) return;
			RighePadri[Choosen["idinc"]]= Choosen;
			foreach (DataRow R in RigheSelezionate){
				R["parentidinc"]=Choosen["idinc"];
				int I = Convert.ToInt32(R["idinc"]);
				SP_Result.Rows[I]["livsupid"]= Choosen["idinc"];
			}
			RicalcolaCampiCalcolati();

		}
        //int GetFaseInfo(string flag, string table){
        //    string fasitable=table+"phase";
        //    DataTable Fase= DS.Tables[fasitable];
        //    int faseattivazione;

        //    DataRow[] MyDRfase;
        //    MyDRfase = Fase.Select(QHC.CmpEq(flag, 'S'), "nphase");
        //    if (MyDRfase.Length > 0)
        //        faseattivazione = (Convert.ToInt32(MyDRfase[0]["nphase"]));
        //    else 
        //        faseattivazione = 99;
        //    return faseattivazione;
        //}

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

		void RicalcolaCampiCalcolati(){
			foreach(DataRow RS in DS.incomeview.Rows){
				object livsup= RS["parentidinc"];
                int nfasesup = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("income", QHS.CmpEq("idinc", livsup), "nphase"));
				if (livsup!=DBNull.Value){
					DataRow Sup= (DataRow) RighePadri[livsup];
                    					string nomefasesup = DS.incomephase.Select(QHC.CmpEq("nphase",nfasesup))[0]["description"].ToString();
					string nomefasesup2 = DS.incomephase.Select(QHC.CmpEq("nphase",nfasesup+1))[0]["description"].ToString();

					RS["!livprecedente"]= nomefasesup+" "+
						Sup["ymov"].ToString()+"/"+
						Sup["nmov"].ToString();
					string nomefasemax = DS.incomephase.Select(QHC.CmpEq("nphase",maxfaseentrata))[0]["description"].ToString();

					if (nomefasesup2!= nomefasemax)
						RS["phase"]= nomefasesup2+" - "+ nomefasemax;
					else
						RS["phase"]= nomefasemax;
				}
				else {
					RS["!livprecedente"]="";
					RS["phase"]="Tutte";
				}
			}
			formatgrids FGE= new formatgrids(gridMovEntrata);
			FGE.AutosizeColumnWidth();
		}

		private void btnScollegaS_Click(object sender, System.EventArgs e) {
			DataRow []RigheSelezionate= GetGridSelectedRows(gridMovEntrata);
			if (RigheSelezionate==null) return;
			if (RigheSelezionate.Length==0) return;
			foreach (DataRow R in RigheSelezionate){
				R["parentidinc"]=DBNull.Value;
				int I = Convert.ToInt32(R["idinc"]);
				SP_Result.Rows[I]["livsupid"]= DBNull.Value;
			}
			RicalcolaCampiCalcolati();

		}

		DataRow GetGridRow(DataGrid G, int index){
			string TableName = G.DataMember.ToString();
			DataSet MyDS =(DataSet)G.DataSource;
			DataTable MyTable = MyDS.Tables[TableName];
			string filter;
            if (MyTable.TableName == "expenseview")
                filter = QHC.CmpEq("idexp", G[index, 0]);
            else
                filter = QHC.CmpEq("idinc", G[index, 0]);
            DataRow[] selectresult = MyTable.Select(filter);
			return selectresult[0];
		}
		private void tabController_SelectionChanged(object sender, System.EventArgs e) {
		
		}

	}
}