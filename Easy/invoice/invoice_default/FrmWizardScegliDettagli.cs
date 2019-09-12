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

namespace invoice_default
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
		private System.Windows.Forms.Button btnSelezionaTutto;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label14;
		private Crownwood.Magic.Controls.TabPage tabPage2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		MetaData Meta;
		private System.Windows.Forms.DataGrid gridDettagli;
		string filterregistry;
		string filterflagmixed;
        object idcurrency;
		private Crownwood.Magic.Controls.TabControl tabController;
		ContextMenu ExcelMenu;
		DataTable InvoiceDetail;
		DataAccess Conn;
		private System.Windows.Forms.Label labelMsg;
		public DataRow []SelectedRows=null;
        private System.Windows.Forms.Label lblselezautomaticamente;
        private Label label1;
        private Label lblValuta;
		public DataRow []SelectedRowsbk;
        QueryHelper QHS;
        CQueryHelper QHC;
        private Label labDDT;
        bool HasDDT;
		public FrmWizardScegliDettagli(MetaData Meta, string filterregistry,string filterflagmixed,
                    object idcurrency, DataTable invoiceDetail,bool hasDdt)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.Meta=Meta;
			this.Conn= Meta.Conn;
			this.filterregistry= filterregistry;
			this.InvoiceDetail= invoiceDetail;
			this.filterflagmixed = filterflagmixed;
            this.idcurrency = idcurrency;
            this.HasDDT = hasDdt;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();

            ExcelMenu = new ContextMenu();
			ExcelMenu.MenuItems.Add("Excel", Excel_Click);
			gridDettagli.ContextMenu= ExcelMenu;
			riempiGrid();

			FormInit();
		}



		private static void Excel_Click(object menusender, EventArgs e) {
		    object sender  = (menusender as MenuItem)?.Parent.GetContextMenu()?.SourceControl;
			if (!(sender is DataGrid))return;
			var g = (DataGrid) sender;
			var dds = g.DataSource;
		    if (!(dds is DataSet))return;
			var ddt = g.DataMember;
			if (ddt==null) return;
			var T = ((DataSet)dds).Tables[ddt];
			if (T==null) return;
			exportclass.DataTableToExcel(T,true);
		}

		string CustomTitle;
		void FormInit() {
			CustomTitle = "Creazione fattura da ordini";
			tabController.HideTabsMode = 
				Crownwood.Magic.Controls.TabControl.HideTabsModes.HideAlways;

			//Selects first tab
			displayTabs(0);
		}
		void displayTabs(int newTab) {
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
		void standardChangeTab(int step) {
			var oldTab= tabController.SelectedIndex;
			var newTab= oldTab+step;
			if (newTab<0||(newTab>tabController.TabPages.Count))return;
			if (!customChangeTab(oldTab,newTab))return;
			if (newTab==tabController.TabPages.Count) {
				DialogResult= DialogResult.OK;
				return;
			}
			displayTabs(newTab);
		}

		/// <summary>
		/// Must return true if operation is possible, and do any
		///  operation related to change from tab oldTab to newTab
		/// </summary>
		/// <param name="oldTab"></param>
		/// <param name="newTab"></param>
		/// <returns></returns>
		bool customChangeTab(int oldTab, int newTab) {
			if ((oldTab==0)&&(newTab==1)) return ScegliDocs();
			if ((oldTab==1)&&(newTab==2)) return true;
			return true;
		}
		

		private void btnBack_Click(object sender, System.EventArgs e) {
			standardChangeTab(-1);
		}

		private void btnNext_Click(object sender, System.EventArgs e) {	
			standardChangeTab(+1);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing ) {
			    components?.Dispose();
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
            this.lblValuta = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblselezautomaticamente = new System.Windows.Forms.Label();
            this.btnSelezionaTutto = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.gridDettagli = new System.Windows.Forms.DataGrid();
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.labelMsg = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.labDDT = new System.Windows.Forms.Label();
            this.tabController.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDettagli)).BeginInit();
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
            this.tabController.SelectedTab = this.tabPage1;
            this.tabController.Size = new System.Drawing.Size(779, 479);
            this.tabController.TabIndex = 14;
            this.tabController.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage2});
            this.tabController.SelectionChanged += new System.EventHandler(this.tabControl1_SelectionChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.labDDT);
            this.tabPage1.Controls.Add(this.lblValuta);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.lblselezautomaticamente);
            this.tabPage1.Controls.Add(this.btnSelezionaTutto);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.gridDettagli);
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(779, 454);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Title = "Pagina 1 di 2";
            // 
            // lblValuta
            // 
            this.lblValuta.AutoSize = true;
            this.lblValuta.Location = new System.Drawing.Point(341, 72);
            this.lblValuta.Name = "lblValuta";
            this.lblValuta.Size = new System.Drawing.Size(187, 13);
            this.lblValuta.TabIndex = 34;
            this.lblValuta.Text = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(315, 16);
            this.label1.TabIndex = 33;
            this.label1.Text = "Attenzione: i dettagli si riferiscono a contratti passivi in valuta:";
            // 
            // lblselezautomaticamente
            // 
            this.lblselezautomaticamente.Location = new System.Drawing.Point(8, 40);
            this.lblselezautomaticamente.Name = "lblselezautomaticamente";
            this.lblselezautomaticamente.Size = new System.Drawing.Size(568, 16);
            this.lblselezautomaticamente.TabIndex = 31;
            this.lblselezautomaticamente.Text = "NB: Saranno selezionati automaticamente tutti i detttagli dello stesso gruppo del" +
                "la riga del contratto scelta.";
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
                "per selezionare più dettagli da inserire in fattura";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(8, 56);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(192, 16);
            this.label14.TabIndex = 28;
            this.label14.Text = "Dettagli ordine da inserire in fattura";
            // 
            // gridDettagli
            // 
            this.gridDettagli.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDettagli.CaptionVisible = false;
            this.gridDettagli.DataMember = "";
            this.gridDettagli.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridDettagli.Location = new System.Drawing.Point(8, 120);
            this.gridDettagli.Name = "gridDettagli";
            this.gridDettagli.Size = new System.Drawing.Size(763, 319);
            this.gridDettagli.TabIndex = 27;
            this.gridDettagli.Paint += new System.Windows.Forms.PaintEventHandler(this.gridDettagli_Paint);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.labelMsg);
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            this.tabPage2.Size = new System.Drawing.Size(779, 454);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Title = "Pagina 2 di 2";
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
            this.btnNext.Location = new System.Drawing.Point(611, 495);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(72, 23);
            this.btnNext.TabIndex = 12;
            this.btnNext.Text = "Avanti >";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(531, 495);
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
            this.btnCancel.Location = new System.Drawing.Point(715, 495);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            // 
            // labDDT
            // 
            this.labDDT.AutoSize = true;
            this.labDDT.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.labDDT.Location = new System.Drawing.Point(8, 104);
            this.labDDT.Name = "labDDT";
            this.labDDT.Size = new System.Drawing.Size(616, 13);
            this.labDDT.TabIndex = 35;
            this.labDDT.Text = "La merce  arrivata con DDT deve essere caricata col pulsante \"Inserisci da DDT\" e" +
                " non con questa maschera";
            // 
            // FrmWizardScegliDettagli
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(795, 532);
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
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void tabControl1_SelectionChanged(object sender, System.EventArgs e) {
		
		}

		void SelezionaTutto(){
			object dataSource = gridDettagli.DataSource;
			if (dataSource==null) return;

			var cm = (CurrencyManager) 
				gridDettagli.BindingContext[dataSource, gridDettagli.DataMember];

			var view = cm.List as DataView;

			if (view != null) {
				for (int i=0; i<view.Count; i++) {
					gridDettagli.Select(i);
				}
			}
		}
		private void btnSelezionaTutto_Click(object sender, System.EventArgs e) {
			SelezionaTutto();
		}

		void riempiGrid(){
            if (!HasDDT)
                labDDT.Visible = false;

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
            DataTable mandateDetail;
            if (HasDDT) {
                mandateDetail = Conn.RUN_SELECT("mandatedetailstockedtoinvoice", "*",
                            "idmankind ASC,yman DESC,nman DESC,rownum ASC, idgroup ASC",
                                filter, null, false);
            }
            else {
                mandateDetail= Conn.RUN_SELECT("mandatedetailnoddttoinvoice", "*", 
                            "idmankind ASC,yman DESC,nman DESC,rownum ASC, idgroup ASC", 
                                filter, null, false);
            }

            Conn.DeleteAllUnselectable(mandateDetail);

			if (mandateDetail.Rows.Count !=0) {
				mandateDetail.PrimaryKey= new[]{mandateDetail.Columns["idmankind"],
															  mandateDetail.Columns["yman"],
															  mandateDetail.Columns["nman"],
															  mandateDetail.Columns["rownum"]};
				//Ora ha messo in MandateDetail tutto ciò che da DB risulta 'da fatturare'.
			
				//Effettua ora una serie di allineamenti sul DataTable per renderlo più coerente con quello
				// che c'è nel DataSet del form padre.

				//Per ogni riga del DataSet in stato di INSERT/UPDATE effettua una sottrazione ed eventualmente
				// un delete su MandateDetail se la riga corrispondente risulta essere esaurita.
				foreach (DataRow R in InvoiceDetail.Select()){
					if (R.RowState!=DataRowState.Added) continue;
					if (R["idmankind"]==DBNull.Value)continue; //Non è una riga collegata a dettagli ordine
					string filtermand= QHC.CmpMulti(R,"idmankind", "yman","nman");
					filtermand= QHC.AppAnd(filtermand,QHC.CmpEq("rownum",R["manrownum"]));
					
                    DataRow []RM= mandateDetail.Select(filtermand);
					if ((RM.Length==0)) continue;
					var detail=RM[0];
					decimal oldnumber=0;
					decimal newnumber= CfgFn.GetNoNullDecimal(R["number",DataRowVersion.Current]);
					decimal oldresidual= CfgFn.GetNoNullDecimal(detail["residual"]);
                    decimal newresidual = oldresidual - newnumber + oldnumber;
                    detail["residual"] = newresidual;
				}

				foreach (DataRow R in InvoiceDetail.Select()){
					if (R.RowState!=DataRowState.Modified) continue;
                    string filtermand = QHC.CmpMulti(R, "idmankind", "yman", "nman");
                    filtermand = QHC.AppAnd(filtermand, QHC.CmpEq("rownum", R["manrownum"]));
                    DataRow[] RM = mandateDetail.Select(filtermand);
					if ((RM.Length==0)) continue;
					DataRow detail=RM[0];
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


                    decimal oldresidual = CfgFn.GetNoNullDecimal(detail["residual"]);
                    decimal newresidual = oldresidual - newnumber + oldnumber;
                    detail["residual"] = newresidual;
				}

				foreach (DataRow r in InvoiceDetail.Rows){
					if (r.RowState!=DataRowState.Deleted) continue;
					if (r["idmankind",DataRowVersion.Original]==DBNull.Value) continue;

                    string filtermand = QHC.CmpMulti(r, "idmankind", "yman", "nman");
                    filtermand = QHC.AppAnd(filtermand, QHC.CmpEq("rownum", r["manrownum",DataRowVersion.Original]));

                    DataRow []RM= mandateDetail.Select(filtermand);
					if ((RM.Length==0)) continue;
					DataRow Detail=RM[0];
					decimal oldnumber= CfgFn.GetNoNullDecimal(r["number",DataRowVersion.Original]);
					decimal newnumber=0;
                    decimal oldresidual = CfgFn.GetNoNullDecimal(Detail["residual"]);
                    decimal newresidual = oldresidual - newnumber + oldnumber;
                    Detail["residual"] = newresidual;
				}

				foreach (DataRow R in mandateDetail.Select()){
                    decimal residual = CfgFn.GetNoNullDecimal(R["residual"]);
					if (residual==0) R.Delete();
				}

				mandateDetail.AcceptChanges();
				if (mandateDetail.Select().Length>0){
                    MetaData MAP;
                    if (HasDDT) {
                        MAP = Meta.Dispatcher.Get("mandatedetailstockedtoinvoice");
                    }
                    else {
                        MAP = Meta.Dispatcher.Get("mandatedetailnoddttoinvoice");
                    }
					MAP.DescribeColumns(mandateDetail,"default"); 
					DataSet D= new DataSet();
					D.Tables.Add(mandateDetail);
					HelpForm.SetDataGrid(gridDettagli,mandateDetail);
					gridDettagli.TableStyles.Clear();
					HelpForm.SetGridStyle(gridDettagli,mandateDetail);
					formatgrids format= new formatgrids(gridDettagli);
					format.AutosizeColumnWidth();
					HelpForm.SetAllowMultiSelection(mandateDetail,true);
					SelezionaTutto();
				}
			}
		}

		bool ScegliDocs(){
			SelectedRows= GetGridSelectedRows(gridDettagli);
			if ((SelectedRows==null)||(SelectedRows.Length==0)){
				MessageBox.Show("Non è stato selezionato alcun dettaglio.");
				return false;
			}
			if (SelectedRows.Length>1)
				labelMsg.Text="Saranno aggiunti alla fattura "+SelectedRows.Length+" dettagli.";
			else 
				labelMsg.Text="Sarà aggiunto alla fattura un dettaglio.";
			return true;
		}


		DataRow GetGridRow(DataGrid G, int index){
			string TableName = G.DataMember;
			DataSet MyDS =(DataSet)G.DataSource;
			DataTable MyTable = MyDS.Tables[TableName];
			string filter;
            filter = QHC.AppAnd(QHC.CmpEq("idmankind", G[index, 0]),
                            QHC.CmpEq("yman", G[index, 2]),
                            QHC.CmpEq("nman", G[index, 3]),
                            QHC.CmpEq("rownum", G[index, 4]));

			DataRow[] selectresult = MyTable.Select(filter);
            if (selectresult.Length == 0) return null;
			return selectresult[0];		
		}


		private DataRow[] GetGridSelectedRows(DataGrid G){
			if (G.DataMember==null) return null;
			if (G.DataSource==null) return null;
			string TableName = G.DataMember;
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

        void SelectGridRowsIdemGroup(DataRow R, DataGrid G, bool select) {
            string TableName = G.DataMember;
            DataSet MyDS = (DataSet)G.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];

            for (int i = 0; i < MyTable.Rows.Count; i++) {
                if (G[i, 0].ToString() == R["idmankind"].ToString()
                    && G[i, 2].ToString() == R["yman"].ToString()
                    && G[i, 3].ToString() == R["nman"].ToString()
                    && G[i, 4].ToString() != R["rownum"].ToString()
                    && G[i, 5].ToString() == R["idgroup"].ToString()) {
                    if (select) G.Select(i);
                    if (!select) G.UnSelect(i);
                }
            }
        }

		
		private bool alreadyselected(DataRow currRowgrid, DataRow[] rrowSelected)
		{
			foreach (DataRow R in rrowSelected)
				if (R==currRowgrid) return true;
			return false;

		}
	
		bool InsidePaint=false;
		private void gridDettagli_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			if (string.IsNullOrEmpty(gridDettagli.DataMember)) return;
			if (InsidePaint) return;
			InsidePaint=true;
			int i;
	
			string TableName = gridDettagli.DataMember;
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
					//deve de-selezionare ciò che era selezionato
					SelectGridRowsIdemGroup(gridrow,gridDettagli,false);
				}
			}
			
			SelectedRowsbk =GetGridSelectedRows(gridDettagli);
			InsidePaint=false;
		
		}

     


	}
}
