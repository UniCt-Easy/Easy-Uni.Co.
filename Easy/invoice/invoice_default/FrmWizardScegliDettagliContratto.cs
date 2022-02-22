
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
using System.Linq;
using funzioni_configurazione;
using q = metadatalibrary.MetaExpression;
namespace invoice_default
{
	/// <summary>
	/// Summary description for FrmWizardScegliDettagli.
	/// </summary>
	public class FrmWizardScegliDettagliContratto : MetaDataForm
	{
		private Button btnNext;
		private Button btnBack;
		private Button btnCancel;
		private Crownwood.Magic.Controls.TabPage tabPage1;
		private Button btnSelezionaTutto;
		private Label label16;
		private Label label14;
		private Crownwood.Magic.Controls.TabPage tabPage2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;
		MetaData Meta;
		private DataGrid gridDettagli;
		string filterregistry;
        object _idcurrency;
		private Crownwood.Magic.Controls.TabControl tabController;
		ContextMenu ExcelMenu;
		DataTable InvoiceDetail;
		DataAccess Conn;
		private Label labelMsg;
		public DataRow []SelectedRows=null;
		private Label lblselezautomatica;
        private Label label1;
        private Label lblValuta;
		public DataRow []SelectedRowsbk;

        QueryHelper QHS;
        CQueryHelper QHC;
		public FrmWizardScegliDettagliContratto(MetaData meta, string filterregistry,object idcurrency,DataTable invoiceDetail)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			Meta=meta;
			Conn= meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();

			this.filterregistry= filterregistry;
			this.InvoiceDetail= invoiceDetail;
            this._idcurrency = idcurrency;
			ExcelMenu = new ContextMenu();
			ExcelMenu.MenuItems.Add("Excel", Excel_Click);
			gridDettagli.ContextMenu= ExcelMenu;
			riempiGrid();
			formInit();
		}



		private void Excel_Click(object menusender, EventArgs e) {
		    object sender  = (menusender as MenuItem)?.Parent.GetContextMenu()?.SourceControl;
			if (!(sender is DataGrid))return;
			var g = (DataGrid) sender;
			object dds = g.DataSource;
		    if (!(dds is DataSet))return;
			var ddt = g.DataMember;
			if (ddt==null) return;
			var T = ((DataSet)dds).Tables[ddt];
			if (T==null) return;
			exportclass.DataTableToExcel(T,true);
		}

		string _customTitle;
		void formInit() {
			_customTitle = "Creazione fattura da contratto attivo";
			tabController.HideTabsMode = 
				Crownwood.Magic.Controls.TabControl.HideTabsModes.HideAlways;
			//Selects first tab
			displayTabs(0);
		}
		void displayTabs(int newTab) {
			tabController.SelectedIndex= newTab;
			//Evaluates Buttons Appearance
			btnBack.Visible=(newTab>0);
			btnNext.Text = newTab== tabController.TabPages.Count-1 ? "Fine." : "Avanti >";
			Text = $"{_customTitle} (Pagina {(newTab + 1)} di {tabController.TabPages.Count})";
		}

		/// <summary>
		/// Changes tab backward/forward
		/// </summary>
		/// <param name="step"></param>
		void standardChangeTab(int step) {
			var oldTab= tabController.SelectedIndex;
			var newTab= oldTab+step;
			if ((newTab<0)||(newTab>tabController.TabPages.Count))return;
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
			if ((oldTab==0)&&(newTab==1)) return scegliDocs();
			if ((oldTab==1)&&(newTab==2)) return true;

			//			//if (oldTab==0) 	return true ; // 0->1: nothing to do
			//			if ((oldTab==1)&&(newTab==0)) {
			//				DS.incomeview.Clear();
			//				btnNext.Enabled=true;
			//				return true; //1->0:nothing to do!
			//			}
			//			if ((oldTab==0)&&(newTab==1)) {
			//				if (CheckInputData())
			//					return CallStoredProcedure(); 
			//				else
			//					btnNext.Enabled=false;
			//			}
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblselezautomatica = new System.Windows.Forms.Label();
            this.btnSelezionaTutto = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.gridDettagli = new System.Windows.Forms.DataGrid();
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.labelMsg = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblValuta = new System.Windows.Forms.Label();
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
            this.tabController.Size = new System.Drawing.Size(600, 408);
            this.tabController.TabIndex = 14;
            this.tabController.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage2});
            this.tabController.SelectionChanged += new System.EventHandler(this.tabControl1_SelectionChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblValuta);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.lblselezautomatica);
            this.tabPage1.Controls.Add(this.btnSelezionaTutto);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.gridDettagli);
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(600, 383);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Title = "Pagina 1 di 2";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(5, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(315, 16);
            this.label1.TabIndex = 35;
            this.label1.Text = "Attenzione: i dettagli si riferiscono a contratti attivi in valuta:";
            // 
            // lblselezautomatica
            // 
            this.lblselezautomatica.Location = new System.Drawing.Point(8, 40);
            this.lblselezautomatica.Name = "lblselezautomatica";
            this.lblselezautomatica.Size = new System.Drawing.Size(576, 16);
            this.lblselezautomatica.TabIndex = 31;
            this.lblselezautomatica.Text = "NB: Saranno selezionati automaticamente tutti i detttagli dello stesso gruppo del" +
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
            this.label14.Size = new System.Drawing.Size(240, 16);
            this.label14.TabIndex = 28;
            this.label14.Text = "Dettagli contratto attivo da inserire in fattura";
            // 
            // gridDettagli
            // 
            this.gridDettagli.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDettagli.CaptionVisible = false;
            this.gridDettagli.DataMember = "";
            this.gridDettagli.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridDettagli.Location = new System.Drawing.Point(8, 98);
            this.gridDettagli.Name = "gridDettagli";
            this.gridDettagli.Size = new System.Drawing.Size(584, 270);
            this.gridDettagli.TabIndex = 27;
            this.gridDettagli.Paint += new System.Windows.Forms.PaintEventHandler(this.gridDettagli_Paint);
            this.gridDettagli.CurrentCellChanged += new System.EventHandler(this.gridDettagli_CurrentCellChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.labelMsg);
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            this.tabPage2.Size = new System.Drawing.Size(600, 383);
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
            // lblValuta
            // 
            this.lblValuta.AutoSize = true;
            this.lblValuta.Location = new System.Drawing.Point(326, 76);
            this.lblValuta.Name = "lblValuta";
            this.lblValuta.Size = new System.Drawing.Size(181, 13);
            this.lblValuta.TabIndex = 36;
            this.lblValuta.Text = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
            // 
            // FrmWizardScegliDettagliContratto
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(616, 461);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tabController);
            this.Name = "FrmWizardScegliDettagliContratto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selezione dettagli contratto attivo";
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

		void selezionaTutto(){
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
		private void btnSelezionaTutto_Click(object sender, EventArgs e) {
			selezionaTutto();
		}
		


		void riempiGrid(){
            var filtercurrency = QHS.CmpEq("idcurrency", _idcurrency);
            filtercurrency = QHS.DoPar(QHS.AppOr(filtercurrency, QHS.IsNull("idcurrency")));
            var filter = QHS.AppAnd(filtercurrency, filterregistry);
            filter = QHS.AppAnd(filter, QHS.CmpNe("toinvoice", "N"), QHS.CmpEq("linktoinvoice", "S"));
            var currency = Conn.DO_READ_VALUE("currency", filtercurrency, "description");
            if (currency != null)
            {
                lblValuta.Text = currency.ToString().ToUpper();
            } 
            var estimateDetail = 
				Conn.RUN_SELECT("estimatedetailtoinvoice","*","idestimkind ASC,yestim DESC,nestim DESC,rownum ASC, idgroup ASC",
				filter,null,false);
            Conn.DeleteAllUnselectable(estimateDetail);
			if (estimateDetail.Rows.Count !=0) {
				estimateDetail.PrimaryKey= new[]{estimateDetail.Columns["idestimkind"],
															  estimateDetail.Columns["yestim"],
															  estimateDetail.Columns["nestim"],
															  estimateDetail.Columns["rownum"]};
				//Ora ha messo in EstimateDetail tutto ciò che da DB risulta 'da fatturare'.
			
				//Effettua ora una serie di allineamenti sul DataTable per renderlo più coerente con quello
				//che c'è nel DataSet del form padre.

				//Per ogni riga del DataSet in stato di INSERT/UPDATE effettua una sottrazione ed eventualmente
				//un delete su MandateDetail se la riga corrispondente risulta essere esaurita.
				foreach (var r in InvoiceDetail.Select()){
					if (r.RowState!=DataRowState.Added) continue;
					if (r["idmankind"]==DBNull.Value)continue; //Non è una riga collegata a dettagli ordine
					var filterestim= QHC.CmpMulti(r,"idestimkind", "yestim","nestim");
					filterestim= QHC.AppAnd(filterestim,QHC.CmpEq("rownum",r["estimrownum"]));
					var rm= estimateDetail.Select(filterestim);
					if (rm.Length==0) continue;
					var detail=rm[0];
					decimal oldnumber=0;
					decimal newnumber= CfgFn.GetNoNullDecimal(r["number",DataRowVersion.Current]);
					decimal oldinvoiced= CfgFn.GetNoNullDecimal(detail["invoiced"]);
					decimal newinvoiced= oldinvoiced+newnumber-oldnumber;
					detail["invoiced"]= newinvoiced;
				}

				foreach (var r in InvoiceDetail.Select()){
					if (r.RowState!=DataRowState.Modified) continue;
                    string filterestim = QHC.CmpMulti(r, "idestimkind", "yestim", "nestim");
                    filterestim = QHC.AppAnd(filterestim, QHC.CmpEq("rownum", r["estimrownum"]));
                    var rm = estimateDetail.Select(filterestim);
					if ((rm.Length==0)) continue;
					DataRow detail=rm[0];
					decimal oldnumber;
					if (r["idestimkind",DataRowVersion.Original]==DBNull.Value) 
						oldnumber=0;
					else
						oldnumber= CfgFn.GetNoNullDecimal(r["number",DataRowVersion.Original]);

					decimal newnumber;
					if (r["idestimkind",DataRowVersion.Current]==DBNull.Value) 
						newnumber=0;
					else
						newnumber= CfgFn.GetNoNullDecimal(r["number",DataRowVersion.Current]);

					var oldinvoiced= CfgFn.GetNoNullDecimal(detail["invoiced"]);
					var newinvoiced= oldinvoiced+newnumber-oldnumber;
					detail["invoiced"]= newinvoiced;
				}

				foreach (DataRow r in InvoiceDetail.Rows){
					if (r.RowState!=DataRowState.Deleted) continue;
					if (r["idestimkind",DataRowVersion.Original]==DBNull.Value) continue;

                    string filterestim = QHC.CmpMulti(r, "idestimkind", "yestim", "nestim");
                    filterestim = QHC.AppAnd(filterestim, QHC.CmpEq("rownum", r["estimrownum", DataRowVersion.Original]));

					var rm= estimateDetail.Select(filterestim);
					if ((rm.Length==0)) continue;
					var detail=rm[0];
					var oldnumber= CfgFn.GetNoNullDecimal(r["number",DataRowVersion.Original]);
					decimal newnumber=0;
					var oldinvoiced= CfgFn.GetNoNullDecimal(detail["invoiced"]);
					var newinvoiced= oldinvoiced+newnumber-oldnumber;
					detail["invoiced"]= newinvoiced;
				}

				foreach (var r in estimateDetail.Select()){
					var invoiced= CfgFn.GetNoNullDecimal(r["invoiced"]);
					var ordered= CfgFn.GetNoNullDecimal(r["ordered"]);
					var residual = ordered-invoiced;
					r["residual"]= residual;
					if (residual==0) r.Delete();
				}

				estimateDetail.AcceptChanges();
			    if (estimateDetail.Select().Length <= 0) return;
			    var map= Meta.Dispatcher.Get("estimatedetailtoinvoice");
			    map.DescribeColumns(estimateDetail,"default");
			    var d= new DataSet();
			    d.Tables.Add(estimateDetail);
			    HelpForm.SetDataGrid(gridDettagli,estimateDetail);
			    gridDettagli.TableStyles.Clear();
			    HelpForm.SetGridStyle(gridDettagli,estimateDetail);
			    var format= new formatgrids(gridDettagli);
			    format.AutosizeColumnWidth();
			    HelpForm.SetAllowMultiSelection(estimateDetail,true);
			    selezionaTutto();
			}
		}

		bool scegliDocs(){
			SelectedRows = getGridSelectedRows(gridDettagli);
			if ((SelectedRows==null)||(SelectedRows.Length==0)){
				show("Non è stato selezionato alcun dettaglio.");
				return false;
			}
			if (SelectedRows.Length>1)
				labelMsg.Text="Saranno aggiunti alla fattura "+SelectedRows.Length.ToString()+" dettagli.";
			else 
				labelMsg.Text="Sarà aggiunto alla fattura un dettaglio.";
			return true;
		}


		DataRow getGridRow(DataGrid g, int index){
			string tableName = g.DataMember;
			DataSet myDs =(DataSet)g.DataSource;
			DataTable myTable = myDs.Tables[tableName];
		    var filter = QHC.AppAnd(QHC.CmpEq("idestimkind", g[index, 0]),
		        QHC.CmpEq("yestim", g[index, 2]),
		        QHC.CmpEq("nestim", g[index, 3]),
		        QHC.CmpEq("rownum", g[index, 4]));

			var selectresult = myTable.Select(filter);
			return selectresult[0];		
		}

		private DataRow[] getGridSelectedRows(DataGrid g){
			if (g.DataMember==null) return null;
			if (g.DataSource==null) return null;
			string tableName = g.DataMember;
			var myDs =(DataSet)g.DataSource;
			var myTable = myDs.Tables[tableName];
			int numrighetemp=myTable.Rows.Count;

			int numrighe=0;
			int i;
			for (i=0; i<numrighetemp; i++){
				if(g.IsSelected(i)){
					numrighe++;
				}
			}
			DataRow[] res=new DataRow[numrighe]; 		

			int count=0;
			for (i=0; i<numrighetemp; i++)
			{
				if(g.IsSelected(i))
				{
					res[count++]= getGridRow(g,i);
				}
			}
			
			return res;
		}

		private bool alreadyselected(DataRow currRowgrid, DataRow[] rrowSelected) {
		    return rrowSelected.Any(r => r == currRowgrid);
		}
	
		void SelectGridRowsIdemGroup(DataRow r,DataGrid g,bool select)
		{
			string tableName = g.DataMember;
			var myDs =(DataSet)g.DataSource;
			DataTable myTable = myDs.Tables[tableName];
	
			for(var i=0; i< myTable.Rows.Count; i++) 
			{
				if( g[i,0].ToString() == r["idestimkind"].ToString()
					&&  g[i,2].ToString() == r["yestim"].ToString()
					&&  g[i,3].ToString() == r["nestim"].ToString()
					&&  g[i,4].ToString() != r["rownum"].ToString()
					&&  g[i,5].ToString() == r["idgroup"].ToString())
				{
					if (select)g.Select(i);
					if (!select)g.UnSelect(i);
				}
			}
		}

		bool InsidePaint;

		private void gridDettagli_Paint(object sender, PaintEventArgs e)	{
			if (string.IsNullOrEmpty(gridDettagli.DataMember)) return;
			if (InsidePaint) return;
			InsidePaint=true;
			int i;
	
			string tableName = gridDettagli.DataMember;
			var myDs =(DataSet)gridDettagli.DataSource;
			var myTable = myDs.Tables[tableName];

			var numrighetemp=myTable.Rows.Count;

// Contiene le righe selezionate RowSelectedbk, lo fa solo una volta
			if (SelectedRowsbk==null)
					SelectedRowsbk = new DataRow[numrighetemp];
			
			for (i=0; i<numrighetemp; i++)
			{
			    DataRow gridrow;
			    if(gridDettagli.IsSelected(i))
				{
					gridrow = getGridRow(gridDettagli,i);
					if (alreadyselected(gridrow,SelectedRowsbk)) continue;
					SelectGridRowsIdemGroup(gridrow,gridDettagli,true);
				}
				if(!(gridDettagli.IsSelected(i))){
					gridrow = getGridRow(gridDettagli,i);
					if (!(alreadyselected(gridrow,SelectedRowsbk))) continue;
					//deve de-selezionare ciò che era selezionato
					SelectGridRowsIdemGroup(gridrow,gridDettagli,false);
				}
			}
			
			SelectedRowsbk =getGridSelectedRows(gridDettagli);
			InsidePaint=false;
		}

		private void gridDettagli_CurrentCellChanged(object sender, System.EventArgs e)	{
		}


	
	}
}
