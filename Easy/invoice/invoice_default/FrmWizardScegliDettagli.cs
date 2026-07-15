/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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
using System.Linq;

namespace invoice_default
{
	/// <summary>
	/// Summary description for FrmWizardScegliDettagli.
	/// </summary>
	public class FrmWizardScegliDettagli : MetaDataForm
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
		DataTable MandateKind;
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
		private ComboBox cmbTipoOrdine;
		private Button btnDocumento;
		private Label label7;
		private TextBox txtNumDoc;
		private Label label10;
		private TextBox txtEsercDoc;
		private GroupBox groupBox1;
		bool HasDDT;

		bool InsidePaint=false;
		bool DoPaint = false;
		private Button btnAzzeraFiltro;
		// dizionario che contiene le posizioni delle righe per gruppo
		Dictionary<string, List<int>> groupDictionary = new Dictionary<string, List<int>>();
		Timer timer = new Timer();

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

			string filterMandateKind = QHS.AppAnd(QHS.CmpEq("linktoinvoice",'S'), QHS.NullOrEq("isrequest", "N"));

			MandateKind = Conn.CreateTableByName("mandatekind", "*");

			GetData.MarkToAddBlankRow(MandateKind);
			GetData.Add_Blank_Row(MandateKind);

			Conn.RUN_SELECT_INTO_TABLE(MandateKind, "description", filterMandateKind, null, false);
			cmbTipoOrdine.DataSource = MandateKind;

			timer.Interval = 50;
			timer.Tick += TimerFillGroupDictionary_Tick;

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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cmbTipoOrdine = new System.Windows.Forms.ComboBox();
			this.btnDocumento = new System.Windows.Forms.Button();
			this.txtEsercDoc = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.txtNumDoc = new System.Windows.Forms.TextBox();
			this.labDDT = new System.Windows.Forms.Label();
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
			this.btnAzzeraFiltro = new System.Windows.Forms.Button();
			this.tabController.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox1.SuspendLayout();
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
			this.tabController.Size = new System.Drawing.Size(779, 511);
			this.tabController.TabIndex = 14;
			this.tabController.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage2});
			this.tabController.SelectionChanged += new System.EventHandler(this.tabControl1_SelectionChanged);
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.groupBox1);
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
			this.tabPage1.Size = new System.Drawing.Size(779, 486);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Title = "Pagina 1 di 2";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnAzzeraFiltro);
			this.groupBox1.Controls.Add(this.cmbTipoOrdine);
			this.groupBox1.Controls.Add(this.btnDocumento);
			this.groupBox1.Controls.Add(this.txtEsercDoc);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.txtNumDoc);
			this.groupBox1.Location = new System.Drawing.Point(11, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(760, 46);
			this.groupBox1.TabIndex = 129;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Contratto Passivo";
			// 
			// cmbTipoOrdine
			// 
			this.cmbTipoOrdine.DisplayMember = "description";
			this.cmbTipoOrdine.Location = new System.Drawing.Point(6, 18);
			this.cmbTipoOrdine.Name = "cmbTipoOrdine";
			this.cmbTipoOrdine.Size = new System.Drawing.Size(344, 23);
			this.cmbTipoOrdine.TabIndex = 128;
			this.cmbTipoOrdine.ValueMember = "idmankind";
			// 
			// btnDocumento
			// 
			this.btnDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDocumento.Location = new System.Drawing.Point(580, 19);
			this.btnDocumento.Name = "btnDocumento";
			this.btnDocumento.Size = new System.Drawing.Size(85, 20);
			this.btnDocumento.TabIndex = 127;
			this.btnDocumento.Text = "Applica Filtro";
			this.btnDocumento.Click += new System.EventHandler(this.btnDocumento_Click);
			// 
			// txtEsercDoc
			// 
			this.txtEsercDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtEsercDoc.Location = new System.Drawing.Point(411, 20);
			this.txtEsercDoc.Name = "txtEsercDoc";
			this.txtEsercDoc.Size = new System.Drawing.Size(56, 20);
			this.txtEsercDoc.TabIndex = 124;
			this.txtEsercDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtEsercDoc.Leave += new System.EventHandler(this.txtEsercDoc_Leave);
			// 
			// label10
			// 
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label10.Location = new System.Drawing.Point(474, 20);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(32, 16);
			this.label10.TabIndex = 125;
			this.label10.Text = "Num.";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(354, 20);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(55, 16);
			this.label7.TabIndex = 123;
			this.label7.Text = "Esercizio";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtNumDoc
			// 
			this.txtNumDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtNumDoc.Location = new System.Drawing.Point(507, 20);
			this.txtNumDoc.Name = "txtNumDoc";
			this.txtNumDoc.Size = new System.Drawing.Size(64, 20);
			this.txtNumDoc.TabIndex = 126;
			this.txtNumDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// labDDT
			// 
			this.labDDT.AutoSize = true;
			this.labDDT.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
			this.labDDT.Location = new System.Drawing.Point(8, 140);
			this.labDDT.Name = "labDDT";
			this.labDDT.Size = new System.Drawing.Size(616, 13);
			this.labDDT.TabIndex = 35;
			this.labDDT.Text = "La merce  arrivata con DDT deve essere caricata col pulsante \"Inserisci da DDT\" e" +
    " non con questa maschera";
			// 
			// lblValuta
			// 
			this.lblValuta.AutoSize = true;
			this.lblValuta.Location = new System.Drawing.Point(341, 118);
			this.lblValuta.Name = "lblValuta";
			this.lblValuta.Size = new System.Drawing.Size(217, 15);
			this.lblValuta.TabIndex = 34;
			this.lblValuta.Text = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 118);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(315, 16);
			this.label1.TabIndex = 33;
			this.label1.Text = "Attenzione: i dettagli si riferiscono a contratti passivi in valuta:";
			// 
			// lblselezautomaticamente
			// 
			this.lblselezautomaticamente.Location = new System.Drawing.Point(8, 86);
			this.lblselezautomaticamente.Name = "lblselezautomaticamente";
			this.lblselezautomaticamente.Size = new System.Drawing.Size(568, 16);
			this.lblselezautomaticamente.TabIndex = 31;
			this.lblselezautomaticamente.Text = "NB: Saranno selezionati automaticamente tutti i detttagli dello stesso gruppo del" +
    "la riga del contratto scelta.";
			// 
			// btnSelezionaTutto
			// 
			this.btnSelezionaTutto.Location = new System.Drawing.Point(8, 54);
			this.btnSelezionaTutto.Name = "btnSelezionaTutto";
			this.btnSelezionaTutto.Size = new System.Drawing.Size(88, 23);
			this.btnSelezionaTutto.TabIndex = 30;
			this.btnSelezionaTutto.Text = "Seleziona tutto";
			this.btnSelezionaTutto.Click += new System.EventHandler(this.btnSelezionaTutto_Click);
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(112, 54);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(464, 32);
			this.label16.TabIndex = 29;
			this.label16.Text = "Tenere premuto il tasto CTRL o MAIUSC e contemporaneamente cliccare con il mouse " +
    "per selezionare più dettagli da inserire in fattura";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(8, 102);
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
			this.gridDettagli.DataMember = "";
			this.gridDettagli.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gridDettagli.Location = new System.Drawing.Point(8, 157);
			this.gridDettagli.Name = "gridDettagli";
			this.gridDettagli.Size = new System.Drawing.Size(763, 323);
			this.gridDettagli.TabIndex = 27;
			this.gridDettagli.CurrentCellChanged += new System.EventHandler(this.gridDettagli_CurrentCellChanged);
			this.gridDettagli.Paint += new System.Windows.Forms.PaintEventHandler(this.gridDettagli_Paint);
			this.gridDettagli.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridDettagli_MouseClick);
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.labelMsg);
			this.tabPage2.Location = new System.Drawing.Point(0, 0);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Selected = false;
			this.tabPage2.Size = new System.Drawing.Size(779, 486);
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
			this.btnNext.Location = new System.Drawing.Point(611, 527);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(72, 23);
			this.btnNext.TabIndex = 12;
			this.btnNext.Text = "Avanti >";
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// btnBack
			// 
			this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBack.Location = new System.Drawing.Point(531, 527);
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
			this.btnCancel.Location = new System.Drawing.Point(715, 527);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 13;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnAzzeraFiltro
			// 
			this.btnAzzeraFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAzzeraFiltro.Location = new System.Drawing.Point(675, 19);
			this.btnAzzeraFiltro.Name = "btnAzzeraFiltro";
			this.btnAzzeraFiltro.Size = new System.Drawing.Size(75, 20);
			this.btnAzzeraFiltro.TabIndex = 129;
			this.btnAzzeraFiltro.Text = "Azzera Filtro";
			this.btnAzzeraFiltro.Click += new System.EventHandler(this.btnAzzeraFiltro_Click);
			// 
			// FrmWizardScegliDettagli
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(795, 564);
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
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
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

			if (cmbTipoOrdine.SelectedIndex > 0)
				filter = QHS.AppAnd(filter, QHS.CmpEq("idmankind", cmbTipoOrdine.SelectedValue));

			int esercizio = 0;

			if (!string.IsNullOrEmpty(txtEsercDoc.Text.ToString()))
				esercizio = (int)HelpForm.GetObjectFromString(typeof(int), txtEsercDoc.Text.ToString(), "x.y.year");

			if (esercizio > 0)
				filter = QHS.AppAnd(filter, QHS.CmpEq("yman", esercizio));

			if (!string.IsNullOrEmpty(txtNumDoc.Text.ToString()))
				filter = QHS.AppAnd(filter, QHS.CmpEq("nman", txtNumDoc.Text.ToString()));
			
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
								
				if (mandateDetail.Select().Length > 0)
				{					
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

					groupDictionary.Clear();

					SelezionaTutto();
				}
			}
		}

		bool ScegliDocs(){
			SelectedRows= GetGridSelectedRows(gridDettagli);
			if ((SelectedRows==null)||(SelectedRows.Length==0)){
				show("Non è stato selezionato alcun dettaglio.");
				return false;
			}
			if (SelectedRows.Length>1)
				labelMsg.Text="Saranno aggiunti alla fattura "+SelectedRows.Length+" dettagli.";
			else 
				labelMsg.Text="Sarà aggiunto alla fattura un dettaglio.";
			return true;
		}

		DataRow GetGridRow(DataGrid G, int index)
		{
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
			int numrighe=MyTable.Rows.Count;

			List<DataRow> selectedRow = new List<DataRow>();

			for (int i = 0; i < numrighe; i++)
			{
				if (G.IsSelected(i))
				{
					selectedRow.Add(GetGridRow(G, i));
				}
			}

			return selectedRow.ToArray();
		}

		private void gridDettagli_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			if (string.IsNullOrEmpty(gridDettagli.DataMember)) return;
			if (InsidePaint) return;
						
			if (!DoPaint) return;

			InsidePaint = true;

			string TableName = gridDettagli.DataMember;
			DataSet MyDS =(DataSet)gridDettagli.DataSource;
			DataTable MyTable = MyDS.Tables[TableName];

			int numrighe=MyTable.Rows.Count;

			if (groupDictionary.Count() == 0)
			{
				for (int i = 0; i < numrighe; i++)
				{
					DataRow row = MyTable.Rows[i];

					string groupKey = $"{row["idmankind"]}_{row["yman"]}_{row["nman"]}_{row["idgroup"]}";

					if (!groupDictionary.ContainsKey(groupKey))
					{
						groupDictionary[groupKey] = new List<int>();
					}
					groupDictionary[groupKey].Add(i);
				}
			}

			foreach(KeyValuePair<string, List<int>> group in groupDictionary)
			{
				if (group.Value.Count() > 1 && group.Value.Contains(gridDettagli.CurrentRowIndex))
				{
					foreach (int rowIndex in group.Value)
					{
						if (gridDettagli.IsSelected(rowIndex) || gridDettagli.IsSelected(gridDettagli.CurrentRowIndex))
						{
							gridDettagli.Select(rowIndex);
						}						
						else if ((!gridDettagli.IsSelected(rowIndex) && rowIndex == gridDettagli.CurrentRowIndex) || !gridDettagli.IsSelected(gridDettagli.CurrentRowIndex))
						{
							gridDettagli.UnSelect(rowIndex);
						}
					}
				}
			}
			
			gridDettagli.Refresh();

			DoPaint = false;
			InsidePaint = false;
			MetaFactory.factory.getSingleton<IFormCreationListener>().refresh();
		}

		private void gridDettagli_CurrentCellChanged(object sender, System.EventArgs e)
		{
			if (string.IsNullOrEmpty(gridDettagli.DataMember)) return;
			if (InsidePaint) return;
			
			DoPaint = true;
		}
		
		private void TimerFillGroupDictionary_Tick(object sender, EventArgs e)
		{
			timer.Stop();

			string TableName = gridDettagli.DataMember;
			DataSet MyDS =(DataSet)gridDettagli.DataSource;
			DataTable MyTable = MyDS.Tables[TableName];

			int numrighe=MyTable.Rows.Count;

			for (int i = 0; i < numrighe; i++)
			{
				DataRow row = GetGridRow(gridDettagli, i);

				string groupKey = $"{row["idmankind"]}_{row["yman"]}_{row["nman"]}_{row["idgroup"]}";

				if (!groupDictionary.ContainsKey(groupKey))
				{
					groupDictionary[groupKey] = new List<int>();
				}
				groupDictionary[groupKey].Add(i);
			}
		}

		private void gridDettagli_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (string.IsNullOrEmpty(gridDettagli.DataMember)) return;
			if (InsidePaint) return;

			if (e.Y < gridDettagli.GetCellBounds(0, 0).Height + 4 && e.X > 36)
			{
				groupDictionary.Clear();
				
				timer.Start();				
			}
		}

		private void btnCancel_Click(object sender, EventArgs e) {

		}

		private void txtEsercDoc_Leave(object sender, System.EventArgs e)
		{
			HelpForm.FormatLikeYear(txtEsercDoc);
		}

		private void btnDocumento_Click(object sender, System.EventArgs e)
		{			
			gridDettagli.DataSource = null;

			riempiGrid();
		}

		private void btnAzzeraFiltro_Click(object sender, EventArgs e)
		{
			cmbTipoOrdine.SelectedIndex = -1;
			txtEsercDoc.Text = string.Empty;
			txtNumDoc.Text = string.Empty;

			cmbTipoOrdine.Refresh();
			txtEsercDoc.Refresh();
			txtNumDoc.Refresh();

			gridDettagli.DataSource = null;

			riempiGrid();
		}
	}
}
