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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using System.Data;
using funzioni_configurazione;

namespace storeunload_default
{
	/// <summary>
	/// Summary description for FrmWizardScegliDettagli.
	/// </summary>
	public class FrmWizardScegliDettagli : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnBack;
		private System.Windows.Forms.Button btnCancel;
        private Crownwood.Magic.Controls.TabPage tabPage1;
		private System.Windows.Forms.Label label14;
		private Crownwood.Magic.Controls.TabPage tabPage2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		MetaData Meta;
        MetaData MetaManager;
        MetaDataDispatcher Disp;
		private System.Windows.Forms.DataGrid gridDettagli;
		string filterstore;
		private Crownwood.Magic.Controls.TabControl tabController;
		ContextMenu ExcelMenu;
        DataTable Storeunloaddetail;
		DataAccess Conn;
        DataTable manager;
        object idstore;
		private System.Windows.Forms.Label labelMsg;
		public DataRow []SelectedRows=null;
        private System.Windows.Forms.Label lblselezautomaticamente;
		public DataRow []SelectedRowsbk;
        QueryHelper QHS;
        private Crownwood.Magic.Controls.TabPage tabPage3;
        private Label label2;
        private TextBox txtMagazzino;
        private GroupBox gboxPrenotazione;
        private TextBox txtNum;
        private Label label13;
        private TextBox txtEserc;
        private Label label3;
        private Button btnSeleziona;
        private Label label12;
        private ComboBox cboResp;
        private TextBox txtNumero;
        private Label label1;
        private TextBox txtEsercizio2;
        private Label label4;
        CQueryHelper QHC;

		public FrmWizardScegliDettagli(MetaData Meta, object idstore, string filterstore,
                DataTable Storeunloaddetail)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.Meta=Meta;
			this.Conn= Meta.Conn;
            this.filterstore = filterstore;
            this.Storeunloaddetail = Storeunloaddetail;
            this.idstore = idstore;
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();

            manager = Conn.CreateTableByName("manager", "*", false);
            GetData.MarkToAddBlankRow(manager);
            GetData.Add_Blank_Row(manager);
            Conn.RUN_SELECT_INTO_TABLE(manager, null, null, null, true);
            MetaManager = Disp.Get("manager");
            SetDataSourceCmb();
          
            ExcelMenu = new ContextMenu();
			ExcelMenu.MenuItems.Add("Excel", new EventHandler(Excel_Click));
			gridDettagli.ContextMenu= ExcelMenu;
			RiempiGrid();

			FormInit();

		}

        private void SetDataSourceCmb () {
            ComboBox C = cboResp; 
            C.DataSource = manager;
            C.ValueMember = "idman";
            C.DisplayMember = "title";
        }

		private void Excel_Click(object menusender, EventArgs e) {
			if (menusender==null) return;
			if (!(typeof(MenuItem).IsAssignableFrom(menusender.GetType())))return;
			object sender  = ((MenuItem) menusender).Parent.GetContextMenu().SourceControl;
			if (!(typeof(DataGrid).IsAssignableFrom(sender.GetType())))return;
			DataGrid G = (DataGrid) sender;
			object DDS = G.DataSource;
			if (DDS==null) return;
			if (!typeof(DataSet).IsAssignableFrom(DDS.GetType()))return;
			string DDT = G.DataMember;
			if (DDT==null) return;
			DataTable T = ((DataSet)DDS).Tables[DDT];
			if (T==null) return;
			exportclass.DataTableToExcel(T,true);
		}

		string CustomTitle;
		void FormInit() {
			CustomTitle = "Creazione scarico da prenotazione";
			tabController.HideTabsMode = 
				Crownwood.Magic.Controls.TabControl.HideTabsModes.HideAlways;

			//Selects first tab
			DisplayTabs(0);
		}
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
		/// Must return true if operation is possible, and do any
		///  operation related to change from tab oldTab to newTab
		/// </summary>
		/// <param name="oldTab"></param>
		/// <param name="newTab"></param>
		/// <returns></returns>
		bool CustomChangeTab(int oldTab, int newTab) {
			if ((oldTab==0)&&(newTab==1)) return ScegliDocs();
			if ((oldTab==1)&&(newTab==2)) return true;
			return true;
		}
		

		private void btnBack_Click(object sender, System.EventArgs e) {
			StandardChangeTab(-1);
		}

		private void btnNext_Click(object sender, System.EventArgs e) {	
			StandardChangeTab(+1);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
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
		private void InitializeComponent()
		{
            this.tabController = new Crownwood.Magic.Controls.TabControl();
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEsercizio2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblselezautomaticamente = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.gridDettagli = new System.Windows.Forms.DataGrid();
            this.tabPage3 = new Crownwood.Magic.Controls.TabPage();
            this.gboxPrenotazione = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cboResp = new System.Windows.Forms.ComboBox();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtEserc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSeleziona = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMagazzino = new System.Windows.Forms.TextBox();
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.labelMsg = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabController.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDettagli)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.gboxPrenotazione.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
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
            this.tabController.SelectedTab = this.tabPage3;
            this.tabController.Size = new System.Drawing.Size(600, 408);
            this.tabController.TabIndex = 14;
            this.tabController.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage3,
            this.tabPage1,
            this.tabPage2});
            this.tabController.SelectionChanged += new System.EventHandler(this.tabControl1_SelectionChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtNumero);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtEsercizio2);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.lblselezautomaticamente);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.gridDettagli);
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Selected = false;
            this.tabPage1.Size = new System.Drawing.Size(600, 383);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Title = "Pagina 2 di 3";
            // 
            // txtNumero
            // 
            this.txtNumero.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumero.Location = new System.Drawing.Point(163, 13);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(73, 21);
            this.txtNumero.TabIndex = 34;
            this.txtNumero.Tag = "";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(117, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 35;
            this.label1.Text = "Num.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercizio2
            // 
            this.txtEsercizio2.Location = new System.Drawing.Point(53, 13);
            this.txtEsercizio2.Name = "txtEsercizio2";
            this.txtEsercizio2.Size = new System.Drawing.Size(56, 21);
            this.txtEsercizio2.TabIndex = 33;
            this.txtEsercizio2.Tag = "";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(7, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 32;
            this.label4.Text = "Eserc.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblselezautomaticamente
            // 
            this.lblselezautomaticamente.Location = new System.Drawing.Point(9, 56);
            this.lblselezautomaticamente.Name = "lblselezautomaticamente";
            this.lblselezautomaticamente.Size = new System.Drawing.Size(544, 16);
            this.lblselezautomaticamente.TabIndex = 31;
            this.lblselezautomaticamente.Text = "NB: Saranno selezionati automaticamente tutti i dettagli della prenotazione scelt" +
                "a";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(8, 82);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(249, 16);
            this.label14.TabIndex = 28;
            this.label14.Text = "Dettagli prenotazione da inserire nello scarico magazzino";
            // 
            // gridDettagli
            // 
            this.gridDettagli.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDettagli.CaptionVisible = false;
            this.gridDettagli.DataMember = "";
            this.gridDettagli.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridDettagli.Location = new System.Drawing.Point(8, 101);
            this.gridDettagli.Name = "gridDettagli";
            this.gridDettagli.Size = new System.Drawing.Size(584, 267);
            this.gridDettagli.TabIndex = 27;
            this.gridDettagli.Paint += new System.Windows.Forms.PaintEventHandler(this.gridDettagli_Paint);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.gboxPrenotazione);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.txtMagazzino);
            this.tabPage3.Location = new System.Drawing.Point(0, 0);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(600, 383);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Title = "Pagina 1 di 3";
            // 
            // gboxPrenotazione
            // 
            this.gboxPrenotazione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxPrenotazione.Controls.Add(this.label12);
            this.gboxPrenotazione.Controls.Add(this.cboResp);
            this.gboxPrenotazione.Controls.Add(this.txtNum);
            this.gboxPrenotazione.Controls.Add(this.label13);
            this.gboxPrenotazione.Controls.Add(this.txtEserc);
            this.gboxPrenotazione.Controls.Add(this.label3);
            this.gboxPrenotazione.Controls.Add(this.btnSeleziona);
            this.gboxPrenotazione.Location = new System.Drawing.Point(11, 68);
            this.gboxPrenotazione.Name = "gboxPrenotazione";
            this.gboxPrenotazione.Size = new System.Drawing.Size(412, 126);
            this.gboxPrenotazione.TabIndex = 29;
            this.gboxPrenotazione.TabStop = false;
            this.gboxPrenotazione.Text = "Prenotazione";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(3, 29);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 23);
            this.label12.TabIndex = 28;
            this.label12.Text = "Responsabile";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboResp
            // 
            this.cboResp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboResp.DisplayMember = "title";
            this.cboResp.Location = new System.Drawing.Point(79, 29);
            this.cboResp.MaxDropDownItems = 25;
            this.cboResp.Name = "cboResp";
            this.cboResp.Size = new System.Drawing.Size(327, 21);
            this.cboResp.TabIndex = 27;
            this.cboResp.ValueMember = "idman";
            // 
            // txtNum
            // 
            this.txtNum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNum.Location = new System.Drawing.Point(189, 61);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(73, 21);
            this.txtNum.TabIndex = 4;
            this.txtNum.Tag = "";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(143, 61);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 16);
            this.label13.TabIndex = 4;
            this.label13.Text = "Num.";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEserc
            // 
            this.txtEserc.Location = new System.Drawing.Point(79, 61);
            this.txtEserc.Name = "txtEserc";
            this.txtEserc.Size = new System.Drawing.Size(56, 21);
            this.txtEserc.TabIndex = 3;
            this.txtEserc.Tag = "";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(33, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Eserc.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSeleziona
            // 
            this.btnSeleziona.Location = new System.Drawing.Point(7, 97);
            this.btnSeleziona.Name = "btnSeleziona";
            this.btnSeleziona.Size = new System.Drawing.Size(128, 23);
            this.btnSeleziona.TabIndex = 1;
            this.btnSeleziona.TabStop = false;
            this.btnSeleziona.Text = "Seleziona";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 23);
            this.label2.TabIndex = 28;
            this.label2.Text = "Magazzino";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMagazzino
            // 
            this.txtMagazzino.Location = new System.Drawing.Point(87, 18);
            this.txtMagazzino.Name = "txtMagazzino";
            this.txtMagazzino.Size = new System.Drawing.Size(262, 21);
            this.txtMagazzino.TabIndex = 27;
            this.txtMagazzino.Tag = "";
            this.txtMagazzino.Visible = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.labelMsg);
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            this.tabPage2.Size = new System.Drawing.Size(600, 383);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Title = "Pagina 3 di 3";
            // 
            // labelMsg
            // 
            this.labelMsg.Location = new System.Drawing.Point(8, 8);
            this.labelMsg.Name = "labelMsg";
            this.labelMsg.Size = new System.Drawing.Size(576, 23);
            this.labelMsg.TabIndex = 0;
            this.labelMsg.Text = "label1";
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(432, 424);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(72, 23);
            this.btnNext.TabIndex = 12;
            this.btnNext.Text = "Avanti >";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(352, 424);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(72, 23);
            this.btnBack.TabIndex = 11;
            this.btnBack.Text = "< Indietro";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(536, 424);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            // 
            // FrmWizardScegliDettagli
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(616, 461);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tabController);
            this.Name = "FrmWizardScegliDettagli";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selezione dettagli ordine";
            this.tabController.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDettagli)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.gboxPrenotazione.ResumeLayout(false);
            this.gboxPrenotazione.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void tabControl1_SelectionChanged(object sender, System.EventArgs e) {
		
		}

		void SelezionaTutto(){
			object dataSource = gridDettagli.DataSource;
			if (dataSource==null) return;

			CurrencyManager cm = (CurrencyManager) 
				gridDettagli.BindingContext[dataSource, gridDettagli.DataMember];

			DataView view = cm.List as DataView;

			if (view != null) {
				for (int i=0; i<view.Count; i++) {
					gridDettagli.Select(i);
				}
			}
		}
		private void btnSelezionaTutto_Click(object sender, System.EventArgs e) {
			SelezionaTutto();
		}
		


		void RiempiGrid(){
         /*
            string filtercurrency = QHS.CmpEq("idcurrency", idcurrency);
            filtercurrency = QHS.DoPar(QHS.AppOr(filtercurrency,QHS.IsNull("idcurrency")));
            string filter = QHS.AppAnd(filterregistry, filterflagmixed);
            filter = QHS.AppAnd(filter, filtercurrency);
            filter = QHS.AppAnd(filter, QHS.CmpNe("toinvoice",'N'),QHS.CmpEq("linktoinvoice",'S'));
            filter = QHS.AppAnd(filter, QHS.CmpEq("idmandatestatus", 5)); // stato approvato

            object currency = Conn.DO_READ_VALUE("currency", filtercurrency, "description");
            if (currency != null)
            {
                lblValuta.Text = currency.ToString().ToUpper();
            }
            DataTable MandateDetail = 
		    Conn.RUN_SELECT("mandatedetailtoinvoice","*","idmankind ASC,yman DESC,nman DESC,rownum ASC, idgroup ASC",
			filter,null,false);

            Conn.DeleteAllUnselectable(MandateDetail);

			if (MandateDetail.Rows.Count !=0) {
				MandateDetail.PrimaryKey= new DataColumn[]{MandateDetail.Columns["idmankind"],
															  MandateDetail.Columns["yman"],
															  MandateDetail.Columns["nman"],
															  MandateDetail.Columns["rownum"]};
				//Ora ha messo in MandateDetail tutto ciÚ che da DB risulta 'da fatturare'.
			
				//Effettua ora una serie di allineamenti sul DataTable per renderlo pi˘ coerente con quello
				// che c'Ë nel DataSet del form padre.

				//Per ogni riga del DataSet in stato di INSERT/UPDATE effettua una sottrazione ed eventualmente
				// un delete su MandateDetail se la riga corrispondente risulta essere esaurita.
				foreach (DataRow R in InvoiceDetail.Select()){
					if (R.RowState!=DataRowState.Added) continue;
					if (R["idmankind"]==DBNull.Value)continue; //Non Ë una riga collegata a dettagli ordine
					string filtermand= QHC.CmpMulti(R,"idmankind", "yman","nman");
					filtermand= QHC.AppAnd(filtermand,QHC.CmpEq("rownum",R["manrownum"]));
					
                    DataRow []RM= MandateDetail.Select(filtermand);
					if ((RM==null)||(RM.Length==0)) continue;
					DataRow Detail=RM[0];
					decimal oldnumber=0;
					decimal newnumber= CfgFn.GetNoNullDecimal(R["number",DataRowVersion.Current]);
					decimal oldinvoiced= CfgFn.GetNoNullDecimal(Detail["invoiced"]);
					decimal newinvoiced= oldinvoiced+newnumber-oldnumber;
					Detail["invoiced"]= newinvoiced;
				}

				foreach (DataRow R in InvoiceDetail.Select()){
					if (R.RowState!=DataRowState.Modified) continue;
                    string filtermand = QHC.CmpMulti(R, "idmankind", "yman", "nman");
                    filtermand = QHC.AppAnd(filtermand, QHC.CmpEq("rownum", R["manrownum"]));
                    DataRow[] RM = MandateDetail.Select(filtermand);
					if ((RM==null)||(RM.Length==0)) continue;
					DataRow Detail=RM[0];
					decimal oldnumber;
					if (R["idmankind",DataRowVersion.Original]==DBNull.Value) 
						oldnumber=0;
					else
						oldnumber= CfgFn.GetNoNullDecimal(R["number",DataRowVersion.Original]);

					decimal newnumber;
					if (R["idmankind",DataRowVersion.Current]==DBNull.Value) 
						newnumber=0;
					else
						newnumber= CfgFn.GetNoNullDecimal(R["number",DataRowVersion.Current]);


					decimal oldinvoiced= CfgFn.GetNoNullDecimal(Detail["invoiced"]);
					decimal newinvoiced= oldinvoiced+newnumber-oldnumber;
					Detail["invoiced"]= newinvoiced;
				}

				foreach (DataRow R in InvoiceDetail.Rows){
					if (R.RowState!=DataRowState.Deleted) continue;
					if (R["idmankind",DataRowVersion.Original]==DBNull.Value) continue;

                    string filtermand = QHC.CmpMulti(R, "idmankind", "yman", "nman");
                    filtermand = QHC.AppAnd(filtermand, QHC.CmpEq("rownum", R["manrownum",DataRowVersion.Original]));

                    DataRow []RM= MandateDetail.Select(filtermand);
					if ((RM==null)||(RM.Length==0)) continue;
					DataRow Detail=RM[0];
					decimal oldnumber= CfgFn.GetNoNullDecimal(R["number",DataRowVersion.Original]);
					decimal newnumber=0;
					decimal oldinvoiced= CfgFn.GetNoNullDecimal(Detail["invoiced"]);
					decimal newinvoiced= oldinvoiced+newnumber-oldnumber;
					Detail["invoiced"]= newinvoiced;
				}

				foreach (DataRow R in MandateDetail.Select()){
					decimal invoiced= CfgFn.GetNoNullDecimal(R["invoiced"]);
					decimal ordered= CfgFn.GetNoNullDecimal(R["ordered"]);
					decimal residual = ordered-invoiced;
					R["residual"]= residual;
					if (residual==0) R.Delete();
				}

				MandateDetail.AcceptChanges();
				if (MandateDetail.Select().Length>0){
					MetaData MAP= Meta.Dispatcher.Get("mandatedetailtoinvoice");
					MAP.DescribeColumns(MandateDetail,"default");
					DataSet D= new DataSet();
					D.Tables.Add(MandateDetail);
					HelpForm.SetDataGrid(gridDettagli,MandateDetail);
					gridDettagli.TableStyles.Clear();
					HelpForm.SetGridStyle(gridDettagli,MandateDetail);
					formatgrids format= new formatgrids(gridDettagli);
					format.AutosizeColumnWidth();
					HelpForm.SetAllowMultiSelection(MandateDetail,true);
					SelezionaTutto();
				}
			}*/
		}

		bool ScegliDocs(){
			SelectedRows= GetGridSelectedRows(gridDettagli);
			if ((SelectedRows==null)||(SelectedRows.Length==0)){
				MessageBox.Show("Non Ë stato selezionato alcun dettaglio.");
				return false;
			}
			if (SelectedRows.Length>1)
				labelMsg.Text="Saranno aggiunti alla fattura "+SelectedRows.Length.ToString()+" dettagli.";
			else 
				labelMsg.Text="Sar‡ aggiunto alla fattura un dettaglio.";
			return true;
		}


		DataRow GetGridRow(DataGrid G, int index){
			string TableName = G.DataMember.ToString();
			DataSet MyDS =(DataSet)G.DataSource;
			DataTable MyTable = MyDS.Tables[TableName];
			string filter;
            filter = QHC.AppAnd(QHC.CmpEq("idmankind", G[index, 0]),
                            QHC.CmpEq("yman", G[index, 2]),
                            QHC.CmpEq("nman", G[index, 3]),
                            QHC.CmpEq("rownum", G[index, 4]));

			DataRow[] selectresult = MyTable.Select(filter);
			return selectresult[0];		
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

		void SelectGridRowsIdemGroup(DataRow R,DataGrid G,bool select)
		{
			string TableName = G.DataMember.ToString();
			DataSet MyDS =(DataSet)G.DataSource;
			DataTable MyTable = MyDS.Tables[TableName];
	
			for(int i=0; i< MyTable.Rows.Count; i++) 
			{
				if( G[i,0].ToString() == R["idmankind"].ToString()
					&&  G[i,2].ToString() == R["yman"].ToString()
					&&  G[i,3].ToString() == R["nman"].ToString()
					&&  G[i,4].ToString() != R["rownum"].ToString()
					&&  G[i,5].ToString() == R["idgroup"].ToString())
				{
					if (select)G.Select(i);
					if (!select)G.UnSelect(i);
				}
			}
		}

		
		private bool alreadyselected(DataRow curr_rowgrid, DataRow[] RrowSelected)
		{
			foreach (DataRow R in RrowSelected)
				if (R==curr_rowgrid) return true;
			return false;

		}
	
		bool InsidePaint=false;
		private void gridDettagli_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			if (gridDettagli.DataMember==null || gridDettagli.DataMember=="") return;
			if (InsidePaint) return;
			InsidePaint=true;
			int i;
	
			string TableName = gridDettagli.DataMember.ToString();
			DataSet MyDS =(DataSet)gridDettagli.DataSource;
			DataTable MyTable = MyDS.Tables[TableName];

			int numrighetemp=MyTable.Rows.Count;
			DataRow gridrow=null;

			// Contiene le righe selezionate RowSelectedbk, lo fa solo una volta
			if (SelectedRowsbk==null)
				SelectedRowsbk = new DataRow[numrighetemp];
			
			for (i=0; i<numrighetemp; i++)
			{
				if(gridDettagli.IsSelected(i))
				{
					gridrow = GetGridRow(gridDettagli,i);
					if (alreadyselected(gridrow,SelectedRowsbk)) continue;
					SelectGridRowsIdemGroup(gridrow,gridDettagli,true);
				}
				if(!(gridDettagli.IsSelected(i)))
				{
					gridrow = GetGridRow(gridDettagli,i);
					if (!(alreadyselected(gridrow,SelectedRowsbk))) continue;
					//deve de-selezionare ciÚ che era selezionato
					SelectGridRowsIdemGroup(gridrow,gridDettagli,false);
				}
			}
			
			SelectedRowsbk =GetGridSelectedRows(gridDettagli);
			InsidePaint=false;
		
		}

     


	}
}
