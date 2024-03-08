
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
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;
using gestioneclassificazioni;
using movimentofunctions;

namespace pettycashoperation_wiz_reintegro {//wizard_reintegrofondops//
	/// <summary>
	/// Summary description for frmwizard_reintegrofondops.
	/// </summary>
	public class Frm_pettycashoperation_wiz_reintegro : MetaDataForm {
		private Crownwood.Magic.Controls.TabControl tabController;
		private Crownwood.Magic.Controls.TabPage tabpage1;
		private System.Windows.Forms.ComboBox cmbFondoPS;
		private System.Windows.Forms.Label label2;
		private Crownwood.Magic.Controls.TabPage tabPage2;
		private System.Windows.Forms.DataGrid gridMovSpesa;
		private System.Windows.Forms.Label lblMessaggi;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnBack;
		public vistaForm DS;
        private System.Windows.Forms.Button btnScollegaS;
		private System.Windows.Forms.Button btnCollegaS;
		Hashtable Messaggi;
		DataAccess Conn;
		string esercizio;
		bool CanSave;
		DataTable SP_Result;
		MetaData Meta;
		string CustomTitle;
		int maxfasespesa;
		Hashtable RighePadri;
		private System.Windows.Forms.CheckBox chkParziale;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox groupBox1;
        private GroupBox grpNList;
        private TextBox txtNList;
        private Label label11;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_pettycashoperation_wiz_reintegro() {
			InitializeComponent();
			tabController.HideTabsMode = 
				Crownwood.Magic.Controls.TabControl.HideTabsModes.HideAlways;

			RighePadri= new Hashtable();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_pettycashoperation_wiz_reintegro));
            this.tabController = new Crownwood.Magic.Controls.TabControl();
            this.tabpage1 = new Crownwood.Magic.Controls.TabPage();
            this.grpNList = new System.Windows.Forms.GroupBox();
            this.txtNList = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbFondoPS = new System.Windows.Forms.ComboBox();
            this.DS = new pettycashoperation_wiz_reintegro.vistaForm();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.chkParziale = new System.Windows.Forms.CheckBox();
            this.btnScollegaS = new System.Windows.Forms.Button();
            this.btnCollegaS = new System.Windows.Forms.Button();
            this.gridMovSpesa = new System.Windows.Forms.DataGrid();
            this.lblMessaggi = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.tabController.SuspendLayout();
            this.tabpage1.SuspendLayout();
            this.grpNList.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMovSpesa)).BeginInit();
            this.SuspendLayout();
            // 
            // tabController
            // 
            this.tabController.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabController.IDEPixelArea = true;
            this.tabController.Location = new System.Drawing.Point(9, 8);
            this.tabController.Name = "tabController";
            this.tabController.SelectedIndex = 1;
            this.tabController.SelectedTab = this.tabPage2;
            this.tabController.Size = new System.Drawing.Size(835, 392);
            this.tabController.TabIndex = 13;
            this.tabController.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabpage1,
            this.tabPage2});
            // 
            // tabpage1
            // 
            this.tabpage1.Controls.Add(this.grpNList);
            this.tabpage1.Controls.Add(this.groupBox1);
            this.tabpage1.Controls.Add(this.label4);
            this.tabpage1.Controls.Add(this.label5);
            this.tabpage1.Controls.Add(this.label2);
            this.tabpage1.Location = new System.Drawing.Point(0, 0);
            this.tabpage1.Name = "tabpage1";
            this.tabpage1.Selected = false;
            this.tabpage1.Size = new System.Drawing.Size(835, 367);
            this.tabpage1.TabIndex = 0;
            this.tabpage1.Title = "Pagina 1 di 2";
            // 
            // grpNList
            // 
            this.grpNList.Controls.Add(this.txtNList);
            this.grpNList.Controls.Add(this.label11);
            this.grpNList.Location = new System.Drawing.Point(16, 278);
            this.grpNList.Name = "grpNList";
            this.grpNList.Size = new System.Drawing.Size(198, 42);
            this.grpNList.TabIndex = 75;
            this.grpNList.TabStop = false;
            this.grpNList.Text = "Nota Spese";
            // 
            // txtNList
            // 
            this.txtNList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNList.Location = new System.Drawing.Point(71, 13);
            this.txtNList.Name = "txtNList";
            this.txtNList.Size = new System.Drawing.Size(108, 20);
            this.txtNList.TabIndex = 6;
            this.txtNList.Tag = "";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(33, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 16);
            this.label11.TabIndex = 5;
            this.label11.Text = "Num.";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbFondoPS);
            this.groupBox1.Location = new System.Drawing.Point(16, 216);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(584, 56);
            this.groupBox1.TabIndex = 9;
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
            this.cmbFondoPS.Size = new System.Drawing.Size(568, 23);
            this.cmbFondoPS.TabIndex = 2;
            this.cmbFondoPS.ValueMember = "idpettycash";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(592, 56);
            this.label4.TabIndex = 8;
            this.label4.Text = resources.GetString("label4.Text");
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(28, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(568, 23);
            this.label5.TabIndex = 7;
            this.label5.Text = "PROCEDURA GUIDATA DI REINTEGRO DELLE OPERAZIONI DI SPESA DEL FONDO ECONOMALE";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(288, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Per proseguire, selezionare il fondo e cliccare su Avanti.";
            // 
            // tabPage2
            // 
            this.tabPage2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabPage2.Controls.Add(this.chkParziale);
            this.tabPage2.Controls.Add(this.btnScollegaS);
            this.tabPage2.Controls.Add(this.btnCollegaS);
            this.tabPage2.Controls.Add(this.gridMovSpesa);
            this.tabPage2.Controls.Add(this.lblMessaggi);
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(835, 367);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Title = "Pagina 2 di 2";
            this.tabPage2.Visible = false;
            // 
            // chkParziale
            // 
            this.chkParziale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkParziale.Location = new System.Drawing.Point(525, 328);
            this.chkParziale.Name = "chkParziale";
            this.chkParziale.Size = new System.Drawing.Size(302, 24);
            this.chkParziale.TabIndex = 7;
            this.chkParziale.Text = "Reintegra solo i movimenti selezionati";
            // 
            // btnScollegaS
            // 
            this.btnScollegaS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnScollegaS.Location = new System.Drawing.Point(216, 328);
            this.btnScollegaS.Name = "btnScollegaS";
            this.btnScollegaS.Size = new System.Drawing.Size(163, 23);
            this.btnScollegaS.TabIndex = 6;
            this.btnScollegaS.Text = "Annulla il collegamento";
            this.btnScollegaS.Click += new System.EventHandler(this.btnScollegaS_Click);
            // 
            // btnCollegaS
            // 
            this.btnCollegaS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCollegaS.Location = new System.Drawing.Point(16, 328);
            this.btnCollegaS.Name = "btnCollegaS";
            this.btnCollegaS.Size = new System.Drawing.Size(176, 23);
            this.btnCollegaS.TabIndex = 5;
            this.btnCollegaS.Text = "Collega a movimento esistente...";
            this.btnCollegaS.Click += new System.EventHandler(this.btnCollega_Click);
            // 
            // gridMovSpesa
            // 
            this.gridMovSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridMovSpesa.DataMember = "";
            this.gridMovSpesa.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridMovSpesa.Location = new System.Drawing.Point(16, 80);
            this.gridMovSpesa.Name = "gridMovSpesa";
            this.gridMovSpesa.Size = new System.Drawing.Size(803, 240);
            this.gridMovSpesa.TabIndex = 1;
            this.gridMovSpesa.Paint += new System.Windows.Forms.PaintEventHandler(this.gridSpesa_Paint);
            // 
            // lblMessaggi
            // 
            this.lblMessaggi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMessaggi.Location = new System.Drawing.Point(16, 16);
            this.lblMessaggi.Name = "lblMessaggi";
            this.lblMessaggi.Size = new System.Drawing.Size(803, 56);
            this.lblMessaggi.TabIndex = 0;
            this.lblMessaggi.Text = "Messaggi";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(771, 408);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Annulla";
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(667, 408);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(72, 23);
            this.btnNext.TabIndex = 15;
            this.btnNext.Text = "Avanti >";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(587, 408);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(72, 23);
            this.btnBack.TabIndex = 14;
            this.btnBack.Text = "< Indietro";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // Frm_pettycashoperation_wiz_reintegro
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(853, 439);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.tabController);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_pettycashoperation_wiz_reintegro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmwizard_reintegrofondops";
            this.tabController.ResumeLayout(false);
            this.tabpage1.ResumeLayout(false);
            this.grpNList.ResumeLayout(false);
            this.grpNList.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMovSpesa)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        CQueryHelper QHC;
        QueryHelper QHS;

		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            
            Messaggi = new Hashtable();
			Messaggi.Add("err_fondovuoto", "Errore: non è stato selezionato il fondo.");
			Messaggi.Add("err_conffondo", "Errore: non esiste o è incompleta la configurazione del fondo selezionato.");
			Messaggi.Add("err_fondoaperto", "Errore: si sta cercando di eseguire una operazione di reintegro su "+
				"un fondo non aperto.");
			Messaggi.Add("err_fondochiuso", "Errore: si sta cercando di eseguire una operazione di reintegro su "+
				"un fondo già chiuso.");
			Messaggi.Add("warn_fondoaperto", "Avvertimento: si sta cercando di eseguire una operazione di reintegro su "+
				"un fondo non aperto.");
			Messaggi.Add("warn_fondochiuso", "Avvertimento: si sta cercando di eseguire una operazione di reintegro su "+
				"un fondo chiuso.");
			Messaggi.Add("err_nopsrend", "Errore: non ci sono operazioni da reintegrare sul fondo selezionato.");
			Messaggi.Add("warn_salvataggio", "Avvertimento: se l'operazione viene confermata, verranno generati i " +
				"seguenti movimenti di contabilità finanziaria. Se si vuole inserire l'operazione di reintegro " +
				"cliccare su Fine.");

			this.Conn=Meta.Conn;
			esercizio = Meta.GetSys("esercizio").ToString();
			GetData.CacheTable(DS.pettycash, null, "description asc", true);
            GetData.CacheTable(DS.config, QHS.CmpEq("ayear", esercizio), null, false);
			GetData.CacheTable(DS.sortingkind, null, null,false);
            GetData.CacheTable(DS.pettycashsetup, QHS.CmpEq("ayear", esercizio), null, false);
            GetData.CacheTable(DS.expensephase);
			GetData.SetSorting(DS.expenseview,"ymov desc, nmov desc");
			CanSave=false;
		}

		public void MetaData_AfterActivation() {
			FormInit();
            maxfasespesa = CfgFn.GetNoNullInt32(Meta.GetSys("maxexpensephase"));
		}

		public void MetaData_AfterClear() {
			// Rimuovo la parola (Ricerca) dal titolo del form
			if (Text.EndsWith("(Ricerca)")) {
				Text = Text.Substring(0,Text.Length - 9);
			}
			Meta.Name = Text;
		}

		void FormInit() {
			CustomTitle = "Reintegro";
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
		/// Verifica che il fondo non sia già chiuso
		/// </summary>
		/// <param name="fondo"></param>
		/// <returns>
		/// true,  se il fondo non è chiuso
		///	false, se il fondo è già stato chiuso
		///	</returns>

		bool CheckSelezioneFondo() {
			if (cmbFondoPS.SelectedIndex==0) return false;
			return true;
		}
		
		bool CheckPSDaRendicontare(object fondo) {
			string esercizio = Meta.GetSys("esercizio").ToString();
            string filter = QHS.AppAnd(QHS.CmpEq("yoperation", esercizio),
                QHS.CmpEq("idpettycash", fondo), QHS.BitSet("flag", 3)); 
            filter= QHS.AppAnd(filter,QHS.DoPar(QHS.AppOr(QHS.IsNotNull("idfin"),QHS.IsNotNull("idexp"))));
            filter = QHS.AppAnd(filter, QHS.AppAnd(QHS.IsNull("yrestore"),QHS.IsNull("nrestore")));
            int nList = 0;
           
            string nList_str = txtNList.Text.Trim();
            if ((nList_str != "") && (isNumeric(nList_str, out nList)))
            {
                nList = CfgFn.GetNoNullInt32(HelpForm.GetObjectFromString(typeof(int), nList_str, "x.y"));
                filter = QHS.AppAnd(filter, QHS.CmpEq("nlist",nList));
            }
			int opdarend = Conn.RUN_SELECT_COUNT("pettycashoperation",filter, true);
			return (opdarend > 0);
		}

        private bool isNumeric(string str, out int valore)
        {
            valore = 0;
            try
            {
                valore = Convert.ToInt32(str);
                return true;
            }
            catch {
                return false;
            }
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
            string esercizio = Meta.GetSys("esercizio").ToString();
            string filterchiusura =
                QHS.AppAnd(QHS.CmpEq("yoperation", esercizio),
                QHS.AppAnd(QHS.CmpEq("idpettycash", fondo), QHS.BitSet("flag", 2)));
            int opchiusura = Conn.RUN_SELECT_COUNT("pettycashoperation", filterchiusura, true);
            return (opchiusura == 0);
        }

        bool CheckPersPiccoleSpeseConfig(object fondo) {
            //assumo che la tabella sia cached
            string esercizio = Meta.GetSys("esercizio").ToString();
            if (DS.pettycashsetup.Rows.Count == 0) return false;
            DataRow[] Conf = DS.pettycashsetup.Select(
                QHC.AppAnd(QHC.CmpEq("ayear", esercizio), QHC.CmpEq("idpettycash", fondo)));
            if (Conf.Length != 1) return false;
            if (Conf[0]["registrymanager"] == DBNull.Value ||
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
				DS.expenseview.Clear();
				btnNext.Enabled=true;
				return true; //1->0:nothing to do!
			}
			if ((oldTab==0)&&(newTab==1)) {
				if (CheckInputData())
					return CallStoredProcedure(); 
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

			if (!CheckAperturaFondo(cmbFondoPS.SelectedValue)) {
				DialogResult res = show(this, Messaggi["warn_fondoaperto"].ToString()+"\nContinuare?", 
					"Avvertimento", MessageBoxButtons.YesNo);
				if (res!=DialogResult.Yes) {
					lblMessaggi.Text=Messaggi["err_fondoaperto"].ToString();
					CanSave=false;
					return false;
				}
			}
			
			if (!CheckChiusuraFondo(cmbFondoPS.SelectedValue)) {
				DialogResult res = show(this, Messaggi["warn_fondochiuso"].ToString()+"\nContinuare?", 
					"Avvertimento", MessageBoxButtons.YesNo);
				if (res!=DialogResult.Yes) {
					lblMessaggi.Text=Messaggi["err_fondochiuso"].ToString();
					CanSave=false;
					return false;
				}
			}

			if (!CheckPSDaRendicontare(cmbFondoPS.SelectedValue)) {
				lblMessaggi.Text=Messaggi["err_nopsrend"].ToString();
				CanSave=false;
				return false;
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
				if (C.ColumnName == "movkind") continue;
				if (C.ColumnName == "idmovimento") continue;
				if (C.ColumnName== "!n_op") continue;
				NewR[C.ColumnName]= R[C.ColumnName];
			}
			T.Rows.Add(NewR);
			NewR.AcceptChanges();
		}

		void FillTables(DataTable Automatismi) {
			MetaDataDispatcher Disp;
			Disp=Meta.Dispatcher;
		
			DS.expenseview.Clear();
			for (int i=0; i<Automatismi.Rows.Count;i++){
				DataRow R = Automatismi.Rows[i];
				//if (R["nphase"].ToString()!=maxfasespesa)continue;
				AddRowToTable(R, DS.expenseview, i);
			}
			MetaData MSpesaView = Disp.Get("expenseview");
			MSpesaView.DescribeColumns(DS.expenseview,"autogeneratips");

			HelpForm.SetDataGrid(gridMovSpesa, DS.expenseview);			

			RicalcolaCampiCalcolati();
		}

		bool CallStoredProcedure() {
			//string esercizio = Conn.sys["esercizio"].ToString();
			string codicefondops = cmbFondoPS.SelectedValue.ToString();
            int nList = 0;
            //string filter = null;
            string nList_str = txtNList.Text.Trim();
            if ((nList_str != "") && (isNumeric(nList_str, out nList)))
            {
                nList = CfgFn.GetNoNullInt32(HelpForm.GetObjectFromString(typeof(int), nList_str, "x.y"));
            }
			DataSet Out=  Conn.CallSP("compute_pettycashrestore",
                new object[] { esercizio, codicefondops, nList, });
			if (Out==null) return false;
			if (Out.Tables.Count==0) return false; //no answer from sp

           
			Out.Tables[0].Columns.Add("idmovimento", typeof(string));
			Out.Tables[0].Columns.Add("!n_op", typeof(int));
			for (int i=0; i< Out.Tables[0].Rows.Count; i++) 
				Out.Tables[0].Rows[i]["!n_op"]=i;

            string filterSpesa =
                QHS.AppAnd(QHS.FieldIn("idexp", Out.Tables[0].Select(), "parentidexp"), QHS.CmpEq("ayear", esercizio));
			DataTable dt = DataAccess.RUN_SELECT(Meta.Conn,"expenseview",null,null,filterSpesa,null,null,true);
			
			foreach(DataRow r in Out.Tables[0].Select(QHC.IsNotNull("parentidexp"))) {
                var rrFound = dt.Select(
                    QHC.CmpEq("idexp", r["parentidexp"]));
                if (rrFound.Length == 0) {
                    string err = $"La riga di spesa avente id {r["parentidexp"]} non appartiene all'esercizio {esercizio}";
                    show(err, "Errore");
                    MetaData.mainLogError(Meta, Conn, err, null);
                    continue;
                }

                RighePadri[r["parentidexp"]] = rrFound[0];
			}

			FillTables(Out.Tables[0]);
			//Out.Tables[0].Columns.Add("livsupid", typeof(string));
			SP_Result = Out.Tables[0].Copy();
			
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
            //E_S["fulfilled"] = "N";
            //E_S["autotaxflag"] = "N";
            //E_S["autoclawbackflag"] = "N";
			

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



		void EliminaAutomatismo(DataRow MView){
			int I = Convert.ToInt32(MView["idexp"]);
			SP_Result.Rows[I].Delete();			
		}


		void CaricaOpFondoPiccoleSpeseDaAggiornare(){
			DS.pettycashoperation.Clear();
			DS.pettycashoperationsorted.Clear();
            DS.pettycashoperationunderwriting.Clear();

			if (DS.pettycashoperation.Columns["!n_op"]==null){
				DS.pettycashoperation.Columns.Add("!n_op",typeof(int));
			}

			int fasespesamax = getIntSys("maxexpensephase");
			string codicefondops = cmbFondoPS.SelectedValue.ToString();

			foreach (DataRow R in SP_Result.Select()){
				// livsupidspesa, codicecreddeb,	idbilancio, codicefondo, codiceripartizione,importo
                string filter = QHS.AppAnd(QHS.BitSet("flag", 3), QHS.IsNull("yrestore"),
                    QHS.CmpEq("idpettycash", codicefondops),
                    QHS.DoPar(QHS.AppOr(QHS.IsNotNull("idfin"), QHS.IsNotNull("idexp"))));

                int nList = 0;
                string nList_str = txtNList.Text.Trim();
                if ((nList_str != "") && (isNumeric(nList_str, out nList)))
                {
                    nList = CfgFn.GetNoNullInt32(HelpForm.GetObjectFromString(typeof(int), nList_str, "x.y"));
                }

                if (nList!=0) 
                    filter = QHS.AppAnd(filter,QHS.CmpEq("nlist",nList));

				foreach( string fieldname in 
					new string[] {"idfin", "idupb", "parentidexp","idman","nbill"}){
					string myname=fieldname;
					if (myname=="parentidexp") myname="idexp";

					//l'idspesa prevale sul bilancio!!
					if ((fieldname=="idfin" || fieldname=="idupb" || fieldname == "idman")
                            && R["parentidexp",DataRowVersion.Original]!=DBNull.Value)continue;
					
					if (fieldname=="parentidexp" && R["parentidexp",DataRowVersion.Original]==DBNull.Value){
                        filter = QHS.AppAnd(filter, QHS.IsNull(myname));
						continue;
					}

					if (R[fieldname]!=DBNull.Value){
                        filter = QHS.AppAnd(filter, QHS.CmpEq(myname,R[fieldname]));
                    }
					else {
                        filter = QHS.AppAnd(filter, QHS.IsNull(myname));
                    }
				}
				Conn.RUN_SELECT_INTO_TABLE(DS.pettycashoperation,null,filter,null,false);
				int n_op= CfgFn.GetNoNullInt32(R["!n_op"]);
				foreach(DataRow RR in DS.pettycashoperation.Select("!n_op is null"))RR["!n_op"]=n_op;
			}
			//Legge le classificazioni sulle operazioni da reintegrare
			foreach(DataRow RR in DS.pettycashoperation.Rows){
				string filterclass= QueryCreator.WHERE_KEY_CLAUSE(RR,DataRowVersion.Default,true);
				Conn.RUN_SELECT_INTO_TABLE(DS.pettycashoperationsorted,null,filterclass,null,true);
			}

            //Legge i finanziamenti delle operazioni da reintegrare
            foreach (DataRow RR in DS.pettycashoperation.Rows) {
                string filterclass = QueryCreator.WHERE_KEY_CLAUSE(RR, DataRowVersion.Default, true);
                Conn.RUN_SELECT_INTO_TABLE(DS.pettycashoperationunderwriting, null, filterclass, null, true);
            }

		}

		void EliminaMovimentiNonSelezionati(){
			if (!chkParziale.Checked)return;
			DataRow []RigheSelezionate = GetGridSelectedRows(gridMovSpesa);
			
			//Cancella da SP_Result un gruppo di righe per ogni riga NON selezionata nel grid			
			foreach(DataRow ToDel in DS.expenseview.Rows){
				bool todel=true;
				foreach(DataRow R in RigheSelezionate){
					if (R==ToDel) {
						todel=false;
						break;
					}
				}
				if (!todel) continue;
				EliminaAutomatismo(ToDel);
			}
		}

		private int getIntSys(string nome) {
			int s = CfgFn.GetNoNullInt32(Meta.GetSys(nome));
			if (s==0) return 99;
			return s;
		}

		private void SaveData() {		
			EliminaMovimentiNonSelezionati();
			CaricaOpFondoPiccoleSpeseDaAggiornare();
			SP_Result.AcceptChanges();
			MetaData MetaM= Meta.Dispatcher.Get("expense");
			MetaM.SetDefaults(DS.expense);

			MetaData MetaImputazioneSpesa = Meta.Dispatcher.Get("expenseyear");
			MetaImputazioneSpesa.SetDefaults(DS.expenseyear);

            MetaData MetaSpesaLast = Meta.Dispatcher.Get("expenselast");
            MetaSpesaLast.SetDefaults(DS.expenselast);

            int fasespesamax = getIntSys("maxexpensephase");
			int faseCreditoreDebitoreSpesa = getIntSys("expenseregphase");
			int faseBilancioSpesa = getIntSys("expensefinphase");

			DS.expenseview.AcceptChanges();

			DS.Tables["expense"].Clear();
			DS.Tables["expenseyear"].Clear();

			if (DS.Tables["expense"].Columns["!n_op"]==null){
				DS.Tables["expense"].Columns.Add("!n_op",typeof(int));
			}

			DataRow [] Auto = SP_Result.Select();			
			DataTable Mov = DS.expense;
			DataTable ImpMov = DS.expenseyear;			
			decimal importoreintegro=0;
			foreach(DataRow R in Auto){
				AddVociCollegate(R);
				DataRow ParentR = null;

				for(int faseCorrente = 1; faseCorrente <= fasespesamax; faseCorrente++) {
					Mov.Columns["nphase"].DefaultValue= faseCorrente;

					DataRow NewSpesaRow = MetaM.Get_New_Row(ParentR, Mov);
					ParentR = NewSpesaRow;

					FillMovimento(NewSpesaRow,R);
					R["idmovimento"]= NewSpesaRow["idexp"];
					NewSpesaRow["!n_op"]=R["!n_op"];
					NewSpesaRow["nphase"] = faseCorrente;

					if (faseCorrente < faseCreditoreDebitoreSpesa) {
						NewSpesaRow["idreg"] = DBNull.Value;
					}
	
					if (faseCorrente==fasespesamax) {
                        object codicecreddeb = R["idreg"];
                        DataRow ModPagam = CfgFn.ModalitaPagamentoDefault(Meta.Conn, codicecreddeb);
                        if (ModPagam == null) {
                            show(this,
                                "E' necessario che sia definita almeno una modalità di pagamento per il percipiente " +
                                "\"" + R["registry"].ToString() + "\"\n\n" +
                                "Dati non salvati", "Errore", MessageBoxButtons.OK);
                            return;
                        }
                        DataRow NewLastMov = MetaSpesaLast.Get_New_Row(NewSpesaRow, DS.expenselast);
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
                        NewLastMov["extracode"] = ModPagam["extracode"];
                        NewLastMov["idchargehandling"] = ModPagam["idchargehandling"];
                        if (LeggiFlagEsenteBancaPredefinita())
                        {
                            int flag = CfgFn.GetNoNullInt32(NewLastMov["flag"]);
                            int flag_exemption = (CfgFn.GetNoNullInt32(NewLastMov["flag"]) & 0xF7) | ((CfgFn.GetNoNullInt32(ModPagam["flag"]) & 1) << 3);
                            NewLastMov["flag"] = flag_exemption;
                        }
                        NewLastMov["nbill"] = R["nbill"];
                        if (R["nbill"].ToString() != "") {
                            NewLastMov["flag"] = CfgFn.GetNoNullInt32(NewLastMov["flag"]) | 1;
                        }

                        NewLastMov["biccode"] = ModPagam["biccode"];
                        NewLastMov["extracode"] = ModPagam["extracode"];
                        NewLastMov["idchargehandling"] = ModPagam["idchargehandling"];
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
						importoreintegro+=CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(R["amount"]));
					}

					DataRow NewImpMov = ImpMov.NewRow();

					FillImputazioneMovimento(NewImpMov, R);
					NewImpMov["idexp"]= NewSpesaRow["idexp"];
					NewImpMov["ayear"]= esercizio;

					if (faseCorrente < faseBilancioSpesa) {
						NewImpMov["idfin"] = DBNull.Value;
						NewImpMov["idupb"] = DBNull.Value;
					}
					ImpMov.Rows.Add(NewImpMov);

				}
			}

            string idfieldname = "idexp";
            //Imposta il livsupid di tutte le righe per cui è necessario
            foreach (DataRow R in Auto) {
                if (R["parentidexp"] == DBNull.Value) continue;
                object idtolink = R["parentidexp"];

                object idmov = R["idmovimento"];

                int nfasetolink = CfgFn.GetNoNullInt32(Meta.Conn.DO_READ_VALUE("expense", QHS.CmpEq("idexp", idtolink), "nphase"));
                DataRow MovSel = Mov.Select(QHC.CmpEq("idexp", idmov))[0];
                int currfase = CfgFn.GetNoNullInt32(MovSel["nphase"]);

                while (currfase > (nfasetolink + 1)) {
                    idmov = MovSel["parentidexp"];
                    MovSel = Mov.Select(QHC.CmpEq("idexp", idmov))[0];
                    currfase--;
                }
                MovSel["parentidexp"] = idtolink;

            }
            //Cancella tutto ciò che non ha figli e non è di ultima fase sino a che non trova + nulla
            bool keep = true;
            int fasemax = fasespesamax;
            while (keep) {
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

			object codicefondops = cmbFondoPS.SelectedValue;
            DataRow[] descr = DS.pettycash.Select(QHC.CmpEq("idpettycash", codicefondops));
            string descrizione = descr[0]["description"].ToString();
            DataRow[] Conf = DS.pettycashsetup.Select(
                QHC.AppAnd(QHC.CmpEq("ayear", esercizio), QHC.CmpEq("idpettycash", codicefondops)));

            Meta.SetDefaults(DS.pettycashoperation);
            MetaData.SetDefault(DS.pettycashoperation, "idpettycash", codicefondops);            
            DataRow NewOpfondoPSRow = Meta.Get_New_Row(null, DS.pettycashoperation);
			NewOpfondoPSRow["flag"]=2;
			//NewOpfondoPSRow["idpettycash"]=codicefondops;
			NewOpfondoPSRow["amount"]=importoreintegro; //Conf[0]["importo"];
			NewOpfondoPSRow["description"]=descrizione;

			int esercnewop = CfgFn.GetNoNullInt32( NewOpfondoPSRow["yoperation"]);
			int numnewop= CfgFn.GetNoNullInt32( NewOpfondoPSRow["noperation"]);
			foreach(DataRow OpSpe in DS.pettycashoperation.Select(QHC.BitSet("flag",3))){
				OpSpe["yrestore"]=esercnewop;
				OpSpe["nrestore"]=numnewop;
			}


			foreach (DataRow R in DS.expense.Rows) {
				DataRow NewPS_SpesaRow = DS.pettycashexpense.NewRow();
				NewPS_SpesaRow["yoperation"]=NewOpfondoPSRow["yoperation"];
				NewPS_SpesaRow["noperation"]=NewOpfondoPSRow["noperation"];
				NewPS_SpesaRow["idpettycash"]=NewOpfondoPSRow["idpettycash"];
				NewPS_SpesaRow["idexp"]=R["idexp"];
				NewPS_SpesaRow["cu"]="AAAA";
				NewPS_SpesaRow["ct"]=DateTime.Now;
				NewPS_SpesaRow["lu"]="AAAAA";
				NewPS_SpesaRow["lt"]=DateTime.Now;
				DS.pettycashexpense.Rows.Add(NewPS_SpesaRow);
			}

			foreach (DataRow R in DS.expense.Rows){
				R["autokind"]=3;
				R["autocode"]=codicefondops;
			}

			//GeneraAutoMandatiReversali(DS);

            bool automatiche = CalcolaClassificazioni(Conn, DS);
            CalcolaFinanziamenti(Conn, DS);

			if (DS.expense.Rows.Count==0){
				show("Non sono state selezionate righe da reintegrare.");
				DS.AcceptChanges();
				return;
			}

			GestioneAutomatismi ga = new GestioneAutomatismi(this, Meta.Conn, Meta.Dispatcher, DS.Copy(),
				fasespesamax, fasespesamax, "pettycashoperation", true);
            ga.GestioneFondoEconomale = true;

            //qui è sicuro che calcola le class.indirette dei movimenti di reintegro perché sono automatismi
            // infatti chiama indirettamente GeneraClassificazioniIndirette( ,false) che comunque opera sugli automatismi
            bool res = ga.GeneraAutomatismiAfterPost(true); 
			if (!res) {
				show(this, "Si è verificato un errore o si è deciso di non salvare! L'operazione sarà terminata");
				return;
			}

            if (Meta.Conn.RUN_SELECT_COUNT("sortingtranslation", null, false) > 0 && !automatiche) {
                if (show(this, "Calcolo le classificazioni indirette a partire da quelle presenti?", "Conferma",
                        MessageBoxButtons.YesNo) ==
                    DialogResult.Yes) {
                    //GeneraClassificazioniIndiretteMov(DS, "expense");
                    ga.GeneraClassificazioniIndirette(ga.DSP, true);
                }
            }

			res = ga.doPost(Meta.Dispatcher);
			if (res) ViewAutomatismi(ga.DSP);
			
//			DS.pettycashoperation.Columns.Remove("!n_op");
//			DS.expense.Columns.Remove("!n_op");
//
//			Easy_PostData MyPostData = new Easy_PostData();
//			MyPostData.InitClass(DS, Conn);
//
//			creaMovBank("payment");
//
//			if (MyPostData.DO_POST())ViewAutomatismi(DS);
		}

        private bool LeggiFlagEsenteBancaPredefinita()
        {
            DataTable tTreasurer = Meta.Conn.RUN_SELECT("treasurer", "*", null, QHS.AppAnd(QHS.CmpEq("flagdefault", "S"), QHS.BitSet("flag", 1)), null, false);
            if (tTreasurer.Rows.Count == 0) return false;
            else
                return true;
        }
        void GeneraClassificazioniAutomatiche() {
            GeneraClassificazioniAutomatichePerAutomatismi("expense");
            SmistaClassificazioni(DS, "expense"); 
        }

		DataTable AllTipoClassMov;

        void GeneraClassificazioniAutomatichePerAutomatismi(string movtable) {
			if (DS.Tables[movtable]==null) return;
			if (AllTipoClassMov==null) AllTipoClassMov = Meta.Conn.RUN_SELECT("sortingkind",
										   "idsorkind, nphaseincome, nphaseexpense",null,
                                           QHS.IsNotNull("nphaseexpense"),
                                           null,true);
			DataTable ImpClass=DS.Tables[movtable+"sorted"];

			string idmovimento= movtable=="expense" ? "idexp" : "idinc";
			
			foreach(DataRow CurrMov in DS.Tables[movtable].Select()) {
				string filterid =  QHC.CmpEq(idmovimento,CurrMov[idmovimento]);
				DataRow CurrImputazioneMov = DS.Tables[movtable+"year"].Select(filterid)[0];	
				
				int currfase = CfgFn.GetNoNullInt32(CurrMov["nphase"]);
			
				object IDForSP = DBNull.Value;
				if (!Meta.InsertMode) IDForSP= CurrMov[idmovimento];

				DataSet OutDS;
				try {
					OutDS=	Meta.Conn.CallSP("sort_auto_single"+movtable,
						new object[]{	  
										Meta.GetSys("esercizio"),
										IDForSP,
										CurrMov["idreg"],
										CurrImputazioneMov["idupb"],
										currfase,
										currfase,
										CurrImputazioneMov["idfin"],
										CurrMov["idman"],
										CurrImputazioneMov["amount"]
									});
				}
				catch (Exception E) {
					show(E.Message);
					return;
				}
				if ((OutDS==null) ||(OutDS.Tables.Count==0)) return; //no autoclass

				RowChange.MarkAsAutoincrement(
					ImpClass.Columns["idsubclass"], 
					null,
					null,
					7,
					false);
                //RowChange.SetSelector(ImpClass, "idsorkind");
				RowChange.SetSelector(ImpClass, idmovimento);
				RowChange.SetSelector(ImpClass, "idsor");

				DataTable AutoClasses = OutDS.Tables[0];
			
				//for every row in OutDS.Tables[0]:
				// - add row to impclassspesa
				// - evaluates temporary AutoIncrement fields
				foreach (DataRow AutoClass in AutoClasses.Rows) {
					DataRow MyDR =  ImpClass.NewRow();
					foreach(DataColumn DC in ImpClass.Columns) {
						if (DC.ColumnName.StartsWith("!")) continue;
						MyDR[DC.ColumnName] = AutoClass[DC.ColumnName];
					}
					///TODO: Aggiungere la riga seguente a tutti gli altri form con classificazioni
					if (MyDR[idmovimento]==DBNull.Value) 
						MyDR[idmovimento]= CurrMov[idmovimento];
					RowChange.CalcTemporaryID(MyDR);
					ImpClass.Rows.Add(MyDR);

                    object currcodtipoclass = AutoClass["idsorkind"];
                    DataRow[] ArrCurrTipo = AllTipoClassMov.Select(QHC.CmpEq("idsorkind", currcodtipoclass));

					GestioneClassificazioni.CalcFlag(Meta.Conn, MyDR,currcodtipoclass);

					if ((ArrCurrTipo!=null) && (ArrCurrTipo.Length>0)){
						DataRow CurrTipo = ArrCurrTipo[0];
						CalcAutoClasses(MyDR,CurrTipo, CurrMov, CurrImputazioneMov, ImpClass);
					}
				}
			}
		}

		/// <summary>
		/// Calcola le classificazioni automatiche (incluse class.indirette)
		/// </summary>
		/// <param name="CurrImpClass"></param>
		void CalcAutoClasses(DataRow CurrImpClass, DataRow CurrTipoClass,
			DataRow CurrMov, DataRow CurrImputazioneMov, DataTable ImpClass) {

			int currfase = CfgFn.GetNoNullInt32(CurrMov["nphase"]);
			string movtable = CurrMov.Table.TableName;
			string idmovimento = movtable == "expense" ? "idexp" : "idinc";
			
			object IDForSP = DBNull.Value;
			if (!Meta.InsertMode) IDForSP= CurrMov[idmovimento];

			DataSet OutDS;
			try {
				OutDS=	Meta.Conn.CallSP("create_autoclasses_"+movtable,
					new object[]{	  
									Meta.GetSys("esercizio"),
									IDForSP,
									CurrMov["idreg"],
									CurrImputazioneMov["idupb"],
									currfase,
									CurrImputazioneMov["idfin"],
									CurrMov["idman"],
									CurrImputazioneMov["amount"],
                                    //CurrTipoClass["idsorkind"],
									CurrImpClass["idsor"],
									CurrImpClass["idsubclass"],
									CurrImpClass["amount"],
									CurrImpClass["description"],
									CurrImpClass["flagnodate"],
									CurrImpClass["tobecontinued"],
									CurrImpClass["start"],
									CurrImpClass["stop"],
									CurrImpClass["valueN1"],
									CurrImpClass["valueN2"],
									CurrImpClass["valueN3"],
									CurrImpClass["valueN4"],
									CurrImpClass["valueN5"],
									CurrImpClass["valueS1"],
									CurrImpClass["valueS2"],
									CurrImpClass["valueS3"],
									CurrImpClass["valueS4"],
									CurrImpClass["valueS5"],
									CurrImpClass["valueV1"],
									CurrImpClass["valueV2"],
									CurrImpClass["valueV3"],
									CurrImpClass["valueV4"],
									CurrImpClass["valueV5"]
								});
			}
			catch (Exception E) {
				show(E.Message);
				return;
			}
			if ((OutDS==null)||(OutDS.Tables.Count==0)) return; //no autoclass

			RowChange.MarkAsAutoincrement(
				ImpClass.Columns["idsubclass"], 
				null,
				null,
				7,
				false);
            //RowChange.SetSelector(ImpClass, "idsorkind");
			RowChange.SetSelector(ImpClass, idmovimento);
			RowChange.SetSelector(ImpClass, "idsor");

			DataTable AutoClasses = OutDS.Tables[0];
			//for every row in OutDS.Tables[0]:
			// - add row to impclassspesa
			// - evaluates temporary AutoIncrement fields
			foreach (DataRow AutoClass in AutoClasses.Rows) {
				DataRow MyDR =  ImpClass.NewRow();
				foreach(DataColumn DC in ImpClass.Columns) {
					if (DC.ColumnName.StartsWith("!")) continue;
					MyDR[DC.ColumnName] = AutoClass[DC.ColumnName];
				}
				///TODO: Aggiungere la riga seguente a tutti gli altri form con classificazioni
				if (MyDR[idmovimento]==DBNull.Value) 
					MyDR[idmovimento]= CurrMov[idmovimento];
				RowChange.CalcTemporaryID(MyDR);
				ImpClass.Rows.Add(MyDR);
                GestioneClassificazioni.CalcFlag(Meta.Conn, MyDR, AutoClass["idsorkind"]);
			}
		}


        void SmistaClassificazioni (DataSet Auto, string movkind) {
            if (Auto.Tables[movkind] == null) return;
            if (Auto.Tables[movkind + "sorted"] == null) return;
            DataTable T = Auto.Tables[movkind];
            DataTable TSorted = Auto.Tables[movkind + "sorted"];
            string idmovimento = movkind == "expense" ? "idexp" : "idinc";

            foreach (DataRow RSorted in TSorted.Select()) {
                string filterIdSor;
                object idsorkind;
                if (Auto.Tables["sorting"] != null) {
                    filterIdSor = QHC.CmpEq("idsor", RSorted["idsor"]);
                    DataRow[] SortKind = Auto.Tables["sorting"].Select(filterIdSor);
                    idsorkind = SortKind[0]["idsokind"];
                }
                else {
                    filterIdSor = QHS.CmpEq("idsor", RSorted["idsor"]);
                    idsorkind = Conn.DO_READ_VALUE("sorting", filterIdSor, "idsorkind");
                }

                string filter = QHC.CmpEq("idsorkind", idsorkind);
				if (AllTipoClassMov.Select(filter).Length == 0) continue;
                DataRow TipoR = AllTipoClassMov.Select(filter)[0];
                int nphase;
                string filterAutoMov;
                filterAutoMov = QHC.CmpEq(idmovimento, RSorted[idmovimento]);
                DataRow[] AutoMov = T.Select(filterAutoMov);
                if (AutoMov.Length == 0) return;
                nphase = CfgFn.GetNoNullInt32(TipoR["nphaseexpense"]);
                AssegnaRigaAClassSpesa(Auto, RSorted, AutoMov[0], nphase);
             
            }
        }

        void SommaFinanziamento(ref DataTable Table, object idunderwriting, object idexp, object amount)
        {
            // se c'è la riga con idexp e idunderwriting sommi l'importo
            // altrimenti la crei
            string filter = QHC.AppAnd(QHC.CmpEq("idunderwriting", idunderwriting), QHC.CmpEq("idexp", idexp));
            DataRow[] R_U = Table.Select(filter);
            if (R_U.Length > 0) {
                DataRow MyDR_u = R_U[0];
                 MyDR_u["amount"] = CfgFn.GetNoNullDecimal(  MyDR_u["amount"] ) + 
                                    CfgFn.GetNoNullDecimal(  amount );
            }
            else {
                DataRow MyDR_u = Table.NewRow();
                MyDR_u["idexp"] = idexp;
                MyDR_u["idunderwriting"] = idunderwriting;
                MyDR_u["amount"] = amount;

                RowChange.CalcTemporaryID(MyDR_u);
                Table.Rows.Add(MyDR_u);
            }
            return ;
        }
        bool CalcolaFinanziamenti(DataAccess Conn, DataSet Auto) {
            

            //Genera i finanziamenti per ogni automatismo di spesa
            MetaData MetaUnderwritingappropriation = Meta.Dispatcher.Get("underwritingappropriation");
            DataTable Underwritingappropriation = Auto.Tables["underwritingappropriation"];
            MetaUnderwritingappropriation.SetDefaults(Underwritingappropriation);

            MetaData MetaUnderwritingpayment = Meta.Dispatcher.Get("underwritingpayment");
            DataTable Underwritingpayment = Auto.Tables["underwritingpayment"];
            MetaUnderwritingpayment.SetDefaults(Underwritingpayment);


            Underwritingappropriation.Clear();
            Underwritingpayment.Clear();

            DataTable tUnderwriting = DataAccess.CreateTableByName(Meta.Conn, "underwriting", "idunderwriting, title,codeunderwriting");

            foreach (DataRow CF in Auto.Tables["pettycashoperationunderwriting"].Rows) {
                //Aggiunge la classificazione CS al movimento di spesa corrispondente
                DataRow rUnderwriting = null;
                DataRow[] rss = tUnderwriting.Select(QHC.CmpEq("idunderwriting", CF["idunderwriting"]));
                if (rss.Length > 0) rUnderwriting = rss[0];

                if (rUnderwriting == null) {
                    DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tUnderwriting, null, QHS.CmpEq("idunderwriting", CF["idunderwriting"]), null, true);
                    DataRow[] RUNDERWS = tUnderwriting.Select(QHC.CmpEq("idunderwriting", CF["idunderwriting"]));
                    if (RUNDERWS.Length > 0)
                        rUnderwriting = RUNDERWS[0];
                }
                if (rUnderwriting == null) continue;

                object nfaseappropriation = Conn.GetSys("appropriationphase");
                object nfasepayment = Conn.GetSys("maxexpensephase");

                string filterop =
                    QHS.AppAnd(QHS.CmpEq("idpettycash", CF["idpettycash"]),
                                QHS.CmpEq("yoperation", CF["yoperation"]),
                                QHS.CmpEq("noperation", CF["noperation"]));

                //Cerca le righe di pettycashexpense
                DataRow PSS = Auto.Tables["pettycashoperation"].Select(filterop)[0];
                int n_op = CfgFn.GetNoNullInt32(PSS["!n_op"]);

                string filter_nop_appropriation = QHC.AppAnd(QHC.CmpEq("!n_op", n_op), QHC.CmpEq("nphase", nfaseappropriation));
                DataRow[] SSpesa_appropriation = Auto.Tables["expense"].Select(filter_nop_appropriation);
                if (SSpesa_appropriation.Length > 0) {
                    DataRow Spesa_approriation = SSpesa_appropriation[0];

                    object id_to_consider_appropriation = Spesa_approriation["idexp"];
                    SommaFinanziamento(ref Underwritingappropriation, CF["idunderwriting"],
                                                                   id_to_consider_appropriation, CF["amount"]);
                }

                string filter_nop_payment = QHC.AppAnd(QHC.CmpEq("!n_op", n_op), QHC.CmpEq("nphase", nfasepayment));
                DataRow[] SSpesa_payment = Auto.Tables["expense"].Select(filter_nop_payment);
                if (SSpesa_payment.Length > 0) {
                    DataRow Spesa_payment = SSpesa_payment[0];

                    object id_to_consider_payment = Spesa_payment["idexp"];
                     SommaFinanziamento(ref Underwritingpayment, CF["idunderwriting"],
                                                id_to_consider_payment, CF["amount"]);

                }




            }
            return true;
        }

        void AssegnaRigaAClassSpesa (DataSet Auto, DataRow RSorted, DataRow R, int nphase) {
            if (Auto.Tables["expense"] == null) return;
            object idexp = R["idexp"];
            DataTable T = Auto.Tables["expense"];
            string childfilter = QHC.CmpEq("parentidexp", idexp);
            DataRow[] childs = T.Select(childfilter);
            if (childs.Length == 0) return;
            if (CfgFn.GetNoNullInt32(childs[0]["nphase"]) != nphase)
                AssegnaRigaAClassSpesa(Auto, RSorted, childs[0], nphase);
            else RSorted["idexp"] = childs[0]["idexp"];
        }

		bool CalcolaClassificazioni(DataAccess Conn,DataSet Auto){
	 
			DataTable AllTipoClassMov=DS.sortingkind;
			DataRow rPettyCashSetup = Auto.Tables["pettycashsetup"].Select(QHC.CmpEq("idpettycash", cmbFondoPS.SelectedValue))[0];
			string autoClassify = rPettyCashSetup["autoclassify"].ToString().ToUpper();
			if (autoClassify == "S") {
				GeneraClassificazioniAutomatiche();
			 
				return true;
			}
			//Genera le class.automatiche per ogni automatismo di spesa
			MetaData MetaImpClassSpesa = Meta.Dispatcher.Get("expensesorted");
			DataTable ImpClassSpesa = Auto.Tables["expensesorted"];
			MetaImpClassSpesa.SetDefaults(ImpClassSpesa);


			RowChange.MarkAsAutoincrement(
				ImpClassSpesa.Columns["idsubclass"], 
				null,
				null,
				7,
				false);
            //RowChange.SetSelector(ImpClassSpesa, "idsorkind");
			RowChange.SetSelector(ImpClassSpesa, "idexp");
			RowChange.SetSelector(ImpClassSpesa, "idsor");

			ImpClassSpesa.Clear();
            DataTable tSorting = DataAccess.CreateTableByName(Meta.Conn, "sorting", "idsorkind, idsor");

			foreach(DataRow CF in Auto.Tables["pettycashoperationsorted"].Rows){				
				//Aggiunge la classificazione CS al movimento di spesa corrispondente
                DataRow rSorting = null;
                DataRow[] rss = tSorting.Select(QHC.CmpEq("idsor", CF["idsor"]));
                if (rss.Length > 0) rSorting = rss[0];

                if (rSorting == null) {
                    DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tSorting, null, QHS.CmpEq("idsor", CF["idsor"]), null, true);        
                    DataRow [] RCLASS = tSorting.Select(QHC.CmpEq("idsor", CF["idsor"]));
                    if (RCLASS.Length > 0)
                    rSorting = RCLASS[0];
                }
                if (rSorting == null) continue;
                object codicetipoclass = rSorting["idsorkind"];
				if (codicetipoclass==DBNull.Value)continue;
                string filtertipoclass = QHC.CmpEq("idsorkind", codicetipoclass);
				DataRow TipoR= AllTipoClassMov.Select(filtertipoclass)[0];
				int codicefaseclass= CfgFn.GetNoNullInt32(TipoR["nphaseexpense"]);

                string filterop =
                    QHS.AppAnd(QHS.CmpEq("idpettycash", CF["idpettycash"]),
                                QHS.CmpEq("yoperation", CF["yoperation"]),
                                QHS.CmpEq("noperation", CF["noperation"]));

				//Cerca le righe di pettycashexpense
				DataRow PSS = Auto.Tables["pettycashoperation"].Select(filterop)[0];
				int n_op= CfgFn.GetNoNullInt32(PSS["!n_op"]);
                string filter_nop = QHC.AppAnd(QHC.CmpEq("!n_op", n_op), QHC.CmpEq("nphase", codicefaseclass));
				DataRow []SSpesa= Auto.Tables["expense"].Select(filter_nop);
				if (SSpesa.Length==0) continue;
				DataRow Spesa=SSpesa[0];

				// in pettycashexpense noperation è sempre uguale a quello di reintegro (Maria)
				string id_to_consider=Spesa["idexp"].ToString();
				DataRow MyDR =  ImpClassSpesa.NewRow();
				foreach(DataColumn DC in ImpClassSpesa.Columns) {
					if (DC.ColumnName.StartsWith("!")) continue;
					if (DC.ColumnName == "idexp") continue;
					if (DC.ColumnName == "paridsor") continue;
					if (DC.ColumnName == "paridsubclass") continue;
					if (DC.ColumnName == "ayear") continue;
                    if (!ImpClassSpesa.Columns.Contains(DC.ColumnName)) continue;
					MyDR[DC.ColumnName] = CF[DC.ColumnName];
				}
				///TODO: Aggiungere la riga seguente a tutti gli altri form con classificazioni
				MyDR["idexp"]= id_to_consider;
				RowChange.CalcTemporaryID(MyDR);
				ImpClassSpesa.Rows.Add(MyDR);
                GestioneClassificazioni.CalcFlag(Conn, MyDR, codicetipoclass);

                
			}
            return false;
		}
		
	

        int CalcRealIDMovimento(DataTable Mov, object idmovimento, int fase) {
            DataRow RealR = getRowPhase(Mov, idmovimento, fase, Conn);
            if (RealR == null) return 0;
            string idfield = "id" + Mov.TableName.ToLower().Substring(0, 3);
            return CfgFn.GetNoNullInt32(RealR[idfield]);

        }

        public static DataRow getRowPhase(DataTable Mov, object idMov, int nphase, DataAccess Conn) {
            CQueryHelper QHC = new CQueryHelper();
            QueryHelper QHS = Conn.GetQueryHelper();
            string filter = "";
            string field = "";

            if (Mov.TableName == "expense") {
                field = "idexp";
            }
            else {
                field = "idinc";
            }
            filter = QHC.CmpEq(field, idMov);
            DataRow[] R = Mov.Select(filter);
            if (R.Length == 0) {
                filter = QHS.CmpEq(field, idMov);
                DataTable T = Conn.RUN_SELECT(Mov.TableName, "*", null, filter, null, true);
                R = T.Select();
            }
            if (CfgFn.GetNoNullInt32(R[0]["nphase"]) == nphase) return R[0];
            string parentField = "parent" + field;
            if (R[0][parentField] == DBNull.Value) return null;
            return getRowPhase(Mov, R[0][parentField], nphase, Conn);
        }




		void ViewAutomatismi(DataSet DS){
			string spesa=null;
			if (DS.Tables["expense"]!=null){
				DataTable Var = DS.Tables["expense"];
				foreach (DataRow R in Var.Rows){
					if (spesa!=null) spesa+="OR";
					string clause= "(idexp="+
						QueryCreator.quotedstrvalue(R["idexp"],true)+
						")";
					spesa+=clause;
				}
			}
            
			Form F = ShowAutomatismi.Show(Meta,spesa,null,null,null);
            createForm(F, this);
            F.ShowDialog(this);
		}

		//DataRow []Automatismi;

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
            if (table == "expense"){
                minfasecred = Convert.ToInt32(Conn.GetSys("expenseregphase"));
                minfasebil = Convert.ToInt32(Conn.GetSys("expensefinphase"));
            }
            if (table == "income") {
                minfasecred = Convert.ToInt32(Conn.GetSys("incomeregphase"));
                minfasebil = Convert.ToInt32(Conn.GetSys("incomefinphase"));
            }
			int fasecurr=99;
			if (table=="income"){
				//fasecurr=Convert.ToInt32(maxfaseentrata)-1;
			}
			else {
                fasecurr = maxfasespesa - 1;
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
			if (G.DataSource==null) return null;
			if (G.DataMember==null) return null;
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
			DataRow []RigheSelezionate= GetGridSelectedRows(gridMovSpesa);
			if (RigheSelezionate==null) return;
			if (RigheSelezionate.Length==0) return;
			string rowfilter;
			int maxfase = GetMaxFaseForSelection(RigheSelezionate, "expense");
			if (maxfase<1){
				show("Non è possibile collegare tutte le righe selezionate ad uno stesso movimento.\n"+
					"Le informazioni di bilancio, percipiente e UPB sono "+
					"troppo diverse tra loro.","Errore");
				return;
			}
			int selectedfase=maxfase;
			if (maxfase>1){
				DataTable Fasi2=  DS.expensephase.Copy();
				foreach (DataRow ToDel in Fasi2.Select(
					"(nphase>"+maxfase+")")){
					ToDel.Delete();
				}
				Fasi2.AcceptChanges();
				FrmAskFase F = new FrmAskFase(Fasi2);
                createForm(F, null);
                if (F.ShowDialog()!=DialogResult.OK) return;
				selectedfase = Convert.ToInt32( F.cmbFasi.SelectedValue);
			}
            rowfilter = GetFilterForSelection(RigheSelezionate, "expense", selectedfase);
            rowfilter = QHS.AppAnd(rowfilter, QHS.CmpEq("nphase", selectedfase));
            decimal tot = 0;
			foreach (DataRow R in RigheSelezionate){
				tot+= CfgFn.GetNoNullDecimal(R["amount"]);
			}
			rowfilter = QHS.AppAnd(rowfilter, QHS.CmpGe("available",tot));
			MetaData E = Meta.Dispatcher.Get("expense");
			E.FilterLocked=true;
			E.DS= DS.Clone();
			DataRow Choosen  = E.SelectOne("default",rowfilter,"expense",null);
			if (Choosen==null) return;
			RighePadri[Choosen["idexp"]]= Choosen;
			foreach (DataRow R in RigheSelezionate){
				R["parentidexp"]=Choosen["idexp"];
				int I = Convert.ToInt32(R["idexp"]);
				SP_Result.Rows[I]["parentidexp"]= Choosen["idexp"];
			}
			RicalcolaCampiCalcolati();

		}

        //int GetFaseInfo(string flag, string table){
        //    string fasitable=table+"phase";
        //    DataTable Fase= DS.Tables[fasitable];
        //    int faseattivazione;

        //    DataRow[] MyDRfase;
        //    MyDRfase  = Fase.Select("("+flag+"='S')","nphase");			
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
			foreach(DataRow RS in DS.expenseview.Rows){
                object livsup = RS["parentidexp"];
                
                int nfasesup = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("expense", QHS.CmpEq("idexp", livsup), "nphase"));
                if (livsup != DBNull.Value) {
                    string nomefasesup = DS.expensephase.Select(QHC.CmpEq("nphase", nfasesup))[0]["description"].ToString();
                    

                    DataRow Sup = RighePadri[livsup] as DataRow;
                    if (Sup==null) {
                        show($"Il movimento di spesa {nomefasesup} di id {livsup} non esiste o non è accessibile con il ruolo corrente", 
                                "Errore");
                        RS["!livprecedente"] = $"{nomefasesup} di id {livsup} inaccessibile";                    
                    }
                    else {
                        RS["!livprecedente"] = nomefasesup + " " +
                       Sup["ymov"].ToString() + "/" +
                       Sup["nmov"].ToString();
                    }

                    string nomefasesup2 = DS.expensephase.Select(QHC.CmpEq("nphase", nfasesup + 1))[0]["description"].ToString();                   
                    string nomefasemax = DS.expensephase.Select(QHC.CmpEq("nphase", maxfasespesa))[0]["description"].ToString();
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
			formatgrids FGSpesa= new formatgrids(gridMovSpesa);
			FGSpesa.AutosizeColumnWidth();
		}

		private void btnScollegaS_Click(object sender, System.EventArgs e) {
			DataRow []RigheSelezionate= GetGridSelectedRows(gridMovSpesa);
			if (RigheSelezionate==null) return;
			if (RigheSelezionate.Length==0) return;
			foreach (DataRow R in RigheSelezionate){
                if (RighePadri.ContainsKey(R["idexp"])){
                    RighePadri.Remove(R["idexp"]);
                }
				R["parentidexp"]=DBNull.Value;
				int I = Convert.ToInt32(R["idexp"]);
				SP_Result.Rows[I]["parentidexp"]= DBNull.Value;
				R.RejectChanges();
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


		private void gridSpesa_Paint(object sender, System.Windows.Forms.PaintEventArgs e) {
			object dataSource = gridMovSpesa.DataSource;
			if (dataSource==null) return;

			CurrencyManager cm = (CurrencyManager) 
				gridMovSpesa.BindingContext[dataSource, gridMovSpesa.DataMember];

			DataView view = cm.List as DataView;

			bool esisteSelezione = false;
			bool esisteSelezioneBloccata=false;
			bool esisteSelezioneCollegata=false;

			if (view != null) {
				for (int i=0; i<view.Count; i++) {
					if (gridMovSpesa.IsSelected(i)) {
						esisteSelezione = true;
						object livPrecedente = view[i]["parentidexp"];
						if (livPrecedente != DBNull.Value) {
							esisteSelezioneCollegata=true;
						}
						DataRow RR= view[i].Row;
						if (RR["parentidexp",DataRowVersion.Original]!=DBNull.Value){
							esisteSelezioneBloccata=true;
						}
					}
				}
			}
			btnCollegaS.Enabled = esisteSelezione && !esisteSelezioneCollegata;
			btnScollegaS.Enabled = esisteSelezione&& esisteSelezioneCollegata && ! esisteSelezioneBloccata;
		}
	}
}
