
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
using System.Data;
using funzioni_configurazione;
using System.Collections.Generic;

namespace flussocrediti_default{
	/// <summary>
	/// Summary description for FrmWizardScegliDettagli.
	/// </summary>
	public class FrmWizardScegliDettagliFattura : MetaDataForm
	{
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnBack;
		private System.Windows.Forms.Button btnCancel;
		private Crownwood.Magic.Controls.TabPage tabPage2;
		private System.Windows.Forms.Button btnSelezionaTutto;
		private System.Windows.Forms.Label label16;
		private Crownwood.Magic.Controls.TabPage tabPage3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		MetaData Meta;
		private System.Windows.Forms.DataGrid gridDettagli;
		private Crownwood.Magic.Controls.TabControl tabController;
		ContextMenu ExcelMenu;
		DataTable Flussocreditidetail;
		DataAccess Conn;
        DataTable invoicekind;
        private System.Windows.Forms.Label labelMsg;
		public DataRow []SelectedRows=null;
		public DataRow []SelectedRowsbk;

        QueryHelper QHS;
        private Crownwood.Magic.Controls.TabPage tabPage1;
        private GroupBox groupBox1;
        private Label label4;
        private ComboBox cmbTipoFattura;
        private GroupBox groupBox2;
        private Label label2;
        private TextBox txtDataStop;
        private Label label3;
        private TextBox txtDataStart;
        private Label label5;
        private TextBox txtAnagrafica;
        CQueryHelper QHC;
		public FrmWizardScegliDettagliFattura(MetaData Meta, DataTable Flussocreditidetail)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.Meta=Meta;
			this.Conn= Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();

    		this.Flussocreditidetail = Flussocreditidetail;
			ExcelMenu = new ContextMenu();
			ExcelMenu.MenuItems.Add("Excel", new EventHandler(Excel_Click));
			gridDettagli.ContextMenu= ExcelMenu;

            invoicekind = Conn.CreateTableByName("invoicekind", "*", false);
            DataSet D = new DataSet();
            D.Tables.Add(invoicekind);
            GetData.MarkToAddBlankRow(invoicekind);
            GetData.Add_Blank_Row(invoicekind);
            //((invoicekind.flag&1)<>0)
            Conn.RUN_SELECT_INTO_TABLE(invoicekind, "description", QHS.AppAnd(QHS.CmpEq("active", "S"), QHS.BitSet("flag", 0)), null, true);
            cmbTipoFattura.DataSource = invoicekind;
            cmbTipoFattura.ValueMember = "idinvkind";
            cmbTipoFattura.DisplayMember = "description";

            FormInit();
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
			CustomTitle = "Inserimento multiplo dettagli Fatture attive";
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
			if ((oldTab==0)&&(newTab==1)) return ProponiDocs();
            if ((oldTab == 1) && (newTab == 2)) return ScegliDocs();
            if ((oldTab==2)&&(newTab==3)) return true;

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
            this.label5 = new System.Windows.Forms.Label();
            this.txtAnagrafica = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDataStop = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDataStart = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbTipoFattura = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.btnSelezionaTutto = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.gridDettagli = new System.Windows.Forms.DataGrid();
            this.tabPage3 = new Crownwood.Magic.Controls.TabPage();
            this.labelMsg = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabController.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDettagli)).BeginInit();
            this.tabPage3.SuspendLayout();
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
            this.tabController.SelectedTab = this.tabPage1;
            this.tabController.Size = new System.Drawing.Size(600, 408);
            this.tabController.TabIndex = 14;
            this.tabController.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage2,
            this.tabPage3});
            this.tabController.SelectionChanged += new System.EventHandler(this.tabControl1_SelectionChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtAnagrafica);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(600, 383);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Title = "Pagina 1 di 3";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(14, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 22);
            this.label5.TabIndex = 21;
            this.label5.Text = "Anagrafica:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAnagrafica
            // 
            this.txtAnagrafica.Location = new System.Drawing.Point(100, 193);
            this.txtAnagrafica.Name = "txtAnagrafica";
            this.txtAnagrafica.Size = new System.Drawing.Size(485, 23);
            this.txtAnagrafica.TabIndex = 20;
            this.txtAnagrafica.Tag = "";
            this.txtAnagrafica.Leave += new System.EventHandler(this.txtAnagrafica_Leave);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtDataStop);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtDataStart);
            this.groupBox2.Location = new System.Drawing.Point(4, 111);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(581, 58);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data Registrazione";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(299, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 22);
            this.label2.TabIndex = 11;
            this.label2.Text = "al:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDataStop
            // 
            this.txtDataStop.Location = new System.Drawing.Point(340, 21);
            this.txtDataStop.Name = "txtDataStop";
            this.txtDataStop.Size = new System.Drawing.Size(133, 23);
            this.txtDataStop.TabIndex = 10;
            this.txtDataStop.Tag = "";
            this.txtDataStop.Leave += new System.EventHandler(this.txtDataStop_Leave);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(81, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 22);
            this.label3.TabIndex = 9;
            this.label3.Text = "dal:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDataStart
            // 
            this.txtDataStart.Location = new System.Drawing.Point(144, 21);
            this.txtDataStart.Name = "txtDataStart";
            this.txtDataStart.Size = new System.Drawing.Size(133, 23);
            this.txtDataStart.TabIndex = 8;
            this.txtDataStart.Tag = "";
            this.txtDataStart.Leave += new System.EventHandler(this.txtDataStart_Leave);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbTipoFattura);
            this.groupBox1.Location = new System.Drawing.Point(4, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(581, 60);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleziona";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(7, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 23);
            this.label4.TabIndex = 17;
            this.label4.Text = "Tipo documento:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbTipoFattura
            // 
            this.cmbTipoFattura.DisplayMember = "description";
            this.cmbTipoFattura.Location = new System.Drawing.Point(147, 27);
            this.cmbTipoFattura.Name = "cmbTipoFattura";
            this.cmbTipoFattura.Size = new System.Drawing.Size(426, 23);
            this.cmbTipoFattura.TabIndex = 16;
            this.cmbTipoFattura.Tag = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnSelezionaTutto);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.gridDettagli);
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            this.tabPage2.Size = new System.Drawing.Size(600, 383);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Title = "Pagina 2 di 3";
            // 
            // btnSelezionaTutto
            // 
            this.btnSelezionaTutto.Location = new System.Drawing.Point(8, 8);
            this.btnSelezionaTutto.Name = "btnSelezionaTutto";
            this.btnSelezionaTutto.Size = new System.Drawing.Size(88, 23);
            this.btnSelezionaTutto.TabIndex = 30;
            this.btnSelezionaTutto.Text = "Seleziona tutto";
            this.btnSelezionaTutto.Click += new System.EventHandler(this.btnSelezionaTutto_Click);
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(112, 8);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(464, 32);
            this.label16.TabIndex = 29;
            this.label16.Text = "Tenere premuto il tasto CTRL o MAIUSC e contemporaneamente cliccare con il mouse " +
    "per selezionare più dettagli da inserire";
            // 
            // gridDettagli
            // 
            this.gridDettagli.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDettagli.CaptionVisible = false;
            this.gridDettagli.DataMember = "";
            this.gridDettagli.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridDettagli.Location = new System.Drawing.Point(8, 43);
            this.gridDettagli.Name = "gridDettagli";
            this.gridDettagli.Size = new System.Drawing.Size(584, 325);
            this.gridDettagli.TabIndex = 27;
            this.gridDettagli.CurrentCellChanged += new System.EventHandler(this.gridDettagli_CurrentCellChanged);
            this.gridDettagli.Paint += new System.Windows.Forms.PaintEventHandler(this.gridDettagli_Paint);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.labelMsg);
            this.tabPage3.Location = new System.Drawing.Point(0, 0);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Selected = false;
            this.tabPage3.Size = new System.Drawing.Size(600, 383);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Title = "Pagina 3 di 3";
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
            // FrmWizardScegliDettagliFattura
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(616, 461);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tabController);
            this.Name = "FrmWizardScegliDettagliFattura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selezione dettagli contratto attivo";
            this.tabController.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDettagli)).EndInit();
            this.tabPage3.ResumeLayout(false);
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
            string filter = "";
            filter = QHS.IsNull("iduniqueformcode");
		    filter=  QHS.AppAnd(filter,QHS.IsNull("idflussocrediti"));
            if (cmbTipoFattura.SelectedValue != null) {
                filter=  QHS.AppAnd(filter,QHS.CmpEq("idinvkind", cmbTipoFattura.SelectedValue));
            }
            filter = QHS.AppAnd(filter, QHS.NullOrEq("flagbankitaliaproceeds","N"), QHS.IsNotNull("idfinmotive"));

            if (txtAnagrafica.Text != "") {
                filter = QHS.AppAnd(filter, QHS.CmpEq("registry", txtAnagrafica.Text.ToString()));
            }
            if (txtDataStart.Text != "") {
                object datainizio = HelpForm.GetObjectFromString(typeof(DateTime), txtDataStart.Text, txtDataStart.Tag.ToString());
                filter = QHS.AppAnd(filter, QHS.CmpGe("adate", datainizio));
            }
            if (txtDataStop.Text != "") {
                object datafine = HelpForm.GetObjectFromString(typeof(DateTime), txtDataStop.Text, txtDataStop.Tag.ToString());
                filter = QHS.AppAnd(filter, QHS.CmpLe("adate", datafine));
            }
            DataTable InvoiceDetail = 
				Conn.RUN_SELECT("invoicedetailview", "*", "idinvkind ASC, yinv DESC, ninv DESC, rownum ASC, idgroup ASC",
				filter,null,false);
            Conn.DeleteAllUnselectable(InvoiceDetail);
			if (InvoiceDetail.Rows.Count !=0) {
                InvoiceDetail.PrimaryKey= new DataColumn[]{InvoiceDetail.Columns["idinvkind"],
                                                              InvoiceDetail.Columns["yinv"],
                                                              InvoiceDetail.Columns["ninv"],
                                                              InvoiceDetail.Columns["rownum"]

                };
				//Ora ha messo in EstimateDetail tutto ciò che da DB risulta 'da fatturare'.
			
				//Effettua ora una serie di allineamenti sul DataTable per renderlo più coerente con quello
				//che c'è nel DataSet del form padre.

                foreach (DataRow R in Flussocreditidetail.Select()) {
                    if (R.RowState != DataRowState.Added) continue;
                    if (R["idinvkind"] == DBNull.Value) continue; //Non è una riga collegata a dettagli contratto attivo
                    string filterInv = QHC.CmpMulti(R, "idinvkind", "yinv", "ninv");
                    filterInv = QHC.AppAnd(filterInv, QHC.CmpEq("rownum", R["invrownum"]));
                    foreach (DataRow Re in InvoiceDetail.Select(filterInv)) {
                        Re.Delete();
                    }
                }

                InvoiceDetail.AcceptChanges();
				if (InvoiceDetail.Select().Length>0){
					MetaData MAP= Meta.Dispatcher.Get("invoicedetailview");
					MAP.DescribeColumns(InvoiceDetail, "flussocrediti");
					DataSet D= new DataSet();
					D.Tables.Add(InvoiceDetail);
					HelpForm.SetDataGrid(gridDettagli, InvoiceDetail);
					gridDettagli.TableStyles.Clear();
					HelpForm.SetGridStyle(gridDettagli, InvoiceDetail);
					formatgrids format= new formatgrids(gridDettagli);
					format.AutosizeColumnWidth();
					HelpForm.SetAllowMultiSelection(InvoiceDetail, true);
					SelezionaTutto();
				}
			}
		}

        bool ProponiDocs() {
            RiempiGrid();
            return true;
        }

        bool ScegliDocs(){
			SelectedRows = GetGridSelectedRows(gridDettagli);
			if ((SelectedRows==null)||(SelectedRows.Length==0)){
				show("Non è stato selezionato alcun dettaglio.");
				return false;
			}
			if (SelectedRows.Length>1)
				labelMsg.Text="Saranno aggiunti  "+SelectedRows.Length.ToString()+" dettagli.";
			else 
				labelMsg.Text="Sarà aggiunto un dettaglio.";
			return true;
		}


		DataRow GetGridRow(DataGrid G, int index){
			string TableName = G.DataMember.ToString();
			DataSet MyDS =(DataSet)G.DataSource;
			DataTable MyTable = MyDS.Tables[TableName];
			string filter;
            filter = QHC.AppAnd(QHC.CmpEq("idinvkind", G[index, 0]),
                            QHC.CmpEq("yinv", G[index, 2]),
                            QHC.CmpEq("ninv", G[index, 3]),
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
            List <DataRow> res = new List<DataRow>();
            for (int i=0; i<MyTable.Rows.Count; i++){
				if(G.IsSelected(i)){
					res.Add(GetGridRow(G,i));
				}
			}
            return res.ToArray();
		}

		private bool alreadyselected(DataRow curr_rowgrid, DataRow[] RrowSelected)
		{
			foreach (DataRow R in RrowSelected)
				if (R==curr_rowgrid) return true;
			return false;

		}
	
		//void SelectGridRowsIdemGroup(DataRow R,DataGrid G,bool select){
		//	string TableName = G.DataMember.ToString();
		//	DataSet MyDS =(DataSet)G.DataSource;
		//	DataTable MyTable = MyDS.Tables[TableName];
	
		//	for(int i=0; i< MyTable.Rows.Count; i++) 
		//	{
		//		if( G[i,0].ToString() == R["idinvkind"].ToString()
		//			&&  G[i,2].ToString() == R["yinv"].ToString()
		//			&&  G[i,3].ToString() == R["ninv"].ToString()
		//			&&  G[i,4].ToString() != R["rownum"].ToString()
		//			&&  G[i,5].ToString() == R["idgroup"].ToString())
		//		{
		//			if (select)G.Select(i);
		//			if (!select)G.UnSelect(i);
		//		}
		//	}
		//}

		bool InsidePaint=false;

		private void gridDettagli_Paint(object sender, System.Windows.Forms.PaintEventArgs e)	{
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
					//SelectGridRowsIdemGroup(gridrow,gridDettagli,true); // CONTROLLARE
				}
				if(!(gridDettagli.IsSelected(i))){
					gridrow = GetGridRow(gridDettagli,i);
					if (!(alreadyselected(gridrow,SelectedRowsbk))) continue;
                    //deve de-selezionare ciò che era selezionato
                    //SelectGridRowsIdemGroup(gridrow,gridDettagli,false); // CONTROLLARE
                    }
                }
			
			SelectedRowsbk =GetGridSelectedRows(gridDettagli);
			InsidePaint=false;
		}

		private void gridDettagli_CurrentCellChanged(object sender, System.EventArgs e)	{
		}

        private void riempiTextBox(DataRow R) {
            txtAnagrafica.Text = R?["title"].ToString() ?? "";
            }
        private void txtAnagrafica_Leave(object sender, EventArgs e) {
            if (txtAnagrafica.Text.Trim() == "") {
                txtAnagrafica.Text = "";
                return;
                }
            DataSet D;
            D = new DataSet();
            string filter = QHS.CmpEq("active", "S");

            string Testo = txtAnagrafica.Text;
            if (!Testo.EndsWith("%")) Testo += "%";
            //if (!Testo.StartsWith("%")) Testo = "%" + Testo;
            filter = QHS.AppAnd(filter, QHS.Like("title", Testo));
            MetaData E = Meta.Dispatcher.Get("registrymainview");
            E.FilterLocked = true;
            E.DS = D.Clone();

            riempiTextBox(E.SelectOne("default", filter, "registrymainview", null));
            }

        

        private void txtDataStart_Leave(object sender, EventArgs e) {
            HelpForm.ExtLeaveDateTimeTextBox(txtDataStart, null);
        }

        private void txtDataStop_Leave(object sender, EventArgs e) {
            HelpForm.ExtLeaveDateTimeTextBox(txtDataStop, null);
        }
    }
}
