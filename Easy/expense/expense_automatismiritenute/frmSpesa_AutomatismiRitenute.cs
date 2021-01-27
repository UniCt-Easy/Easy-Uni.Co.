
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
using System.Data;
using metadatalibrary;
using funzioni_configurazione;//funzioni_configurazione
using AskInfo;

namespace expense_automatismiritenute{//Spesa_AutomatismiRitenute//
	/// <summary>
	/// Summary description for frmSpesa_AutomatismiRitenute.
	/// </summary>
	public class frmSpesa_AutomatismiRitenute : System.Windows.Forms.Form {
		private System.Windows.Forms.TextBox txtNumMovimento;
		private System.Windows.Forms.Label labelNum;
		private System.Windows.Forms.TextBox txtEsercMovimento;
		private System.Windows.Forms.Label labelEserc;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.DataGrid dataGrid2;
		private System.Windows.Forms.DataGrid dataGrid3;
		private Crownwood.Magic.Controls.TabControl tabs;
		private Crownwood.Magic.Controls.TabPage tabEntrata;
		private Crownwood.Magic.Controls.TabPage tabSpesa;
		private Crownwood.Magic.Controls.TabPage tabVariazioniSpesa;
		private System.Windows.Forms.DataGrid gridEntrata;
		private System.Windows.Forms.DataGrid gridSpesa;
        private System.Windows.Forms.DataGrid gridVarSpesa;
		MetaDataDispatcher Disp;
		DataAccess Conn;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		int maxfasespesa;
		int maxfaseentrata;
		Hashtable RighePadriEntrata;
		private System.Windows.Forms.Button btnScollegaS;
		private System.Windows.Forms.Button btnCollegaS;
		private System.Windows.Forms.Button btnCollegaE;
		private System.Windows.Forms.Button btnScollegaE;
		Hashtable RighePadriSpesa;
		private System.Windows.Forms.CheckBox chkBilancio;
		private System.Windows.Forms.Button btnCambiaBilancioE;
		private System.Windows.Forms.Button btnCambiaBilancioS;
		DataRow []Automatismi;
        private vistaForm DS;
        CQueryHelper QHC;
        private CheckBox chkUpb;
        QueryHelper QHS;

		public frmSpesa_AutomatismiRitenute(MetaDataDispatcher Disp, 
			DataRow [] Automatismi,
			DataRow SpesaRow,
			string title) {
			InitializeComponent();
			this.Text=title;
			this.Disp=Disp;
			this.Conn= Disp.Conn;
            QHS = Conn.GetQueryHelper();
            QHC = new CQueryHelper();
            MetaData.SetColor(this);
			this.Automatismi = Automatismi;
            if (SpesaRow.RowState == DataRowState.Added) {
                labelEserc.Visible = false;
                labelNum.Visible = false;
                txtEsercMovimento.Visible = false;
                txtNumMovimento.Visible = false;
            }
            else {
                txtEsercMovimento.Text = SpesaRow["ymov"].ToString();
                txtNumMovimento.Text = SpesaRow["nmov"].ToString();
            }
			//string filteresercizio="(esercizio='"+Conn.sys["esercizio"].ToString()+"')";
			DataAccess.RUN_SELECT_INTO_TABLE(Conn,DS.incomephase,"nphase",null,null,true);
			DataAccess.RUN_SELECT_INTO_TABLE(Conn,DS.expensephase,"nphase",null,null,true);
            maxfaseentrata = CfgFn.GetNoNullInt32(Disp.GetSys("maxincomephase"));
            maxfasespesa = CfgFn.GetNoNullInt32(Disp.GetSys("maxexpensephase"));
			RighePadriEntrata= new Hashtable();
			RighePadriSpesa= new Hashtable();
			FillTables(Automatismi);			
			GetData.SetSorting(DS.expenseview,"ymov desc, nmov desc");
			if (DS.expenseview.Rows.Count==0){
				tabs.TabPages.Remove(tabSpesa);
			}
			if (DS.incomeview.Rows.Count==0){
				tabs.TabPages.Remove(tabEntrata);
			}
			if (DS.expensevarview.Rows.Count==0){
				tabs.TabPages.Remove(tabVariazioniSpesa);
			}

		}

		/// <summary>
		/// Copia il parametro i in identrata/idspesa di entrata/spesaview, più tutti i valori che può copiare
		/// </summary>
		/// <param name="R"></param>
		/// <param name="T"></param>
		/// <param name="i"></param>
		void AddRowToTable(DataRow R, DataTable T, int i){			
			DataRow NewR = T.NewRow();
			if (T.TableName == "incomeview"){
				NewR["idinc"]=i;
			}
			if (T.TableName == "expenseview"){
				NewR["idexp"]=i;
			}
			foreach(DataColumn C in R.Table.Columns){
				if (C.ColumnName == "movkind") continue;
				if (T.Columns[C.ColumnName]==null) continue;
				NewR[C.ColumnName]= R[C.ColumnName];
			}
			T.Rows.Add(NewR);
			NewR.AcceptChanges();
		}

		/// <summary>
		/// Riempie le tabelle incomeview, expenseview e expensevarview in base alle righe di automatismi
		/// </summary>
		/// <param name="Automatismi"></param>
		void FillTables(DataRow [] Automatismi){
			for (int i=0;i< Automatismi.Length; i++){
				DataRow R = Automatismi[i];
				switch(R["movkind"].ToString().ToLower()){
					case "spesa":
						AddRowToTable(R, DS.expenseview, i);
						break;
					case "entrata":
						AddRowToTable(R, DS.incomeview, i);
						break;
					case "variazione spesa":
						AddRowToTable(R, DS.expensevarview, i);
						break;
				}
			}
			MetaData MSpesaView = Disp.Get("expenseview");
			MSpesaView.DescribeColumns(DS.expenseview, "autogenerati");
			
			MetaData MEntrataView = Disp.Get("incomeview");
			MEntrataView.DescribeColumns(DS.incomeview,"autogenerati");

			MetaData MVarSpesaView = Disp.Get("expensevarview");
			MVarSpesaView.DescribeColumns(DS.expensevarview,"autogenerati");

			HelpForm.SetDataGrid(gridEntrata, DS.incomeview);			
			HelpForm.SetDataGrid(gridSpesa, DS.expenseview);
			HelpForm.SetDataGrid(gridVarSpesa, DS.expensevarview);


			//formatgrids FGSpesa= new formatgrids(gridSpesa);
			//FGSpesa.AutosizeColumnWidth();

			//formatgrids FGEntrata = new formatgrids(gridEntrata);
			//FGEntrata.AutosizeColumnWidth();

			formatgrids FGVarSpesa= new formatgrids(gridVarSpesa);
			FGVarSpesa.AutosizeColumnWidth();

			RicalcolaCampiCalcolati();

		}

		/// <summary>
		/// Cambia info bilancio di MView in base a MChoosen
		/// </summary>
		/// <param name="MView"></param>
		/// <param name="MChoosen"></param>
		void CambiaVoceBilancio(DataRow MView,DataRow MChoosen){
			//Per ogni movimento in income/expenseview con livsupid non vuoto copia idfin/codefin
			//  dal movimento padre ove questo sia dotato di tali informazioni.
			//string table;
			//if (MView.Table.TableName == "expenseview")
			//	table="expense";
			//else
			//	table="income";

//			if (MView["nphase"].ToString().CompareTo(GetFaseInfo("flagfinance",table).ToString())<0)return; 
			//if (MChoosen["idbilancio"]==DBNull.Value)return;
			MView["idfin"]=MChoosen["idfin"];
			MView["codefin"]=MChoosen["codefin"];
			MView["finance"]=MChoosen["finance"];

			MView["idupb"]=MChoosen["idupb"];
			MView["codeupb"]=MChoosen["codeupb"];
			MView["upb"]=MChoosen["upb"];

		}

		// Rusciano G. Aggiunto 04.03.2005
		// Imposta le informazioni sul centro di spesa
		void CambiaVoceUPB(DataRow MView,DataRow MChoosen) {
			//string table;
			//if (MView.Table.TableName == "expenseview")
			//	table="expense";
			//else
			//	table="income";

//			if (MView["nphase"].ToString().CompareTo(GetFaseInfo("flagfinance",table).ToString())<0)return; 
			MView["idupb"] = MChoosen["idupb"];
			MView["codeupb"] = MChoosen["codeupb"];
			MView["upb"] = MChoosen["upb"];
		}

		void CambiaVoceCreditore(DataRow MView,DataRow MChoosen) {
			//string table;
			//if (MView.Table.TableName == "expenseview")
			//	table="expense";
			//else
			//	table="income";

//			if (MView["nphase"].ToString().CompareTo(GetFaseInfo("flagregistry",table).ToString())<0)return; 
			MView["idreg"] = MChoosen["idreg"];
			MView["registry"] = MChoosen["registry"];
		}


		void AllineaAutomatismo(DataRow MView,int row){
			DataRow A = Automatismi[row];
			//Per ogni livello con bilancio cambia almeno una riga dal vecchio all'eventuale nuovo idbilancio
			//int codicefase= CfgFn.GetNoNullInt32(A["nphase"]);
			object originalidbilancio= A["idfin"];
			object originalidupb= A["idupb"];
			A["idfin"]=MView["idfin"];
			A["codefin"]=MView["codefin"];
			A["idupb"]=MView["idupb"];
			A["codeupb"]=MView["codeupb"];

            string filter = QHC.MCmp(A, "amount", "description", "idman");
			//filter += "AND(codicefase='"+i.ToString()+"')";

            //filter += QHC.NullOrEq("idfin", originalidbilancio);
            filter = QHC.AppAnd(filter, QHC.NullOrEq("idfin", originalidbilancio));
             //filter += QHC.NullOrEq("idupb", originalidupb);
             filter = QHC.AppAnd(filter, QHC.NullOrEq("idupb", originalidupb));
            foreach (string fieldname in
                    new string[] { "idreg" }) {
                if (A[fieldname] != DBNull.Value) {
                    filter = QHC.AppAnd(filter, QHC.NullOrEq(fieldname, A[fieldname]));
                }
            }


			DataTable TableAutomatismi = A.Table;
			filter=QHC.AppAnd(filter,QHC.CmpEq("movkind",A["movkind"]));
			DataRow []Found= TableAutomatismi.Select(filter);
			if (Found.Length>0){
				if (Found[0]["idfin"]!=DBNull.Value){
					Found[0]["idfin"]=MView["idfin"];
					Found[0]["codefin"]=MView["codefin"];
				}
				if (Found[0]["idupb"] != DBNull.Value) {
					Found[0]["idupb"] = MView["idupb"];
					Found[0]["codeupb"] = MView["codeupb"];
				}
			}

		}
		void AllineaVociBilancio(){
			//Per ogni automatismo di tipo entrata/spesa cui sia associato un movimento padre ricalcola
			// le info di bilancio per tutti i livelli di quel movimento di spesa/entrata
			foreach(DataRow S in DS.expenseview.Rows){
				int i= CfgFn.GetNoNullInt32(S["idexp"]);
				DataRow Automatismo= Automatismi[i];
				if (Automatismo["livsupid"]!=DBNull.Value){
					//Allinea gli automatismi parent di questo
					AllineaAutomatismo(S,i);
				}
			}
			foreach(DataRow E in DS.incomeview.Rows){
				int i= CfgFn.GetNoNullInt32(E["idinc"]);
				DataRow Automatismo= Automatismi[i];
				if (Automatismo["livsupid"]!=DBNull.Value){
					//Allinea gli automatismi parent di questo
					AllineaAutomatismo(E,i);
				}
			}

		}

		void RicalcolaCampiCalcolati(){
			foreach(DataRow RS in DS.expensevarview.Rows){
				RS["phase"]="Tutte";
			}
			foreach(DataRow RS in DS.expenseview.Rows){
				object livsup= RS["parentidexp"];
                //int nfase = CfgFn.GetNoNullInt32(RS["nphase"]);
                //int nfasesup = nfase - 1;
				if (livsup!=DBNull.Value){
                    //int nfase = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("expense", QHS.CmpEq("idexp", livsup), "nphase"));
                    DataRow Sup = (DataRow)RighePadriSpesa[livsup];
                    int nfase = CfgFn.GetNoNullInt32(Sup["nphase"]);
                    
                    //string nomefasesup = DS.expensephase.Select(QHC.CmpEq("nphase",nfasesup))[0]["description"].ToString();
                    //string nomefasesup2 = DS.expensephase.Select(QHC.CmpEq("nphase",nfase))[0]["description"].ToString();
                    string nomefasesup = DS.expensephase.Select(QHC.CmpEq("nphase", nfase))[0]["description"].ToString();
                    string nomefasesup2 = DS.expensephase.Select(QHC.CmpEq("nphase", nfase+1))[0]["description"].ToString();

                    RS["!livprecedente"] = nomefasesup + " " +
						Sup["ymov"].ToString()+"/"+
						Sup["nmov"].ToString();
					string nomefasemax = DS.expensephase.Select(QHC.CmpEq("nphase",maxfasespesa))[0]["description"].ToString();
					if (nomefasesup2!= nomefasemax)
						RS["phase"]= nomefasesup2+" - "+ nomefasemax;
					else
						RS["phase"]= nomefasemax;
					//RS["fase"]= nomefasesup+" - "+ nomefasemax;
				}
				else {
					RS["!livprecedente"]="";
					RS["phase"]="Tutte";
				}
			}
			foreach(DataRow RS in DS.incomeview.Rows){
                object livsup = RS["parentidinc"];
                //int nfase = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("income", QHS.CmpEq("idinc", livsup), "nphase"));
                //int nfase = CfgFn.GetNoNullInt32(RS["nphase"]);
                //int nfasesup = nfase - 1;
                if (livsup != DBNull.Value) {
                    DataRow Sup = (DataRow)RighePadriEntrata[livsup];
                    int nfase = CfgFn.GetNoNullInt32(Sup["nphase"]);
                    //string nomefasesup = DS.incomephase.Select(QHC.CmpEq("nphase", nfasesup))[0]["description"].ToString();
                    //string nomefasesup2 = DS.incomephase.Select(QHC.CmpEq("nphase", nfase))[0]["description"].ToString();
                    string nomefasesup = DS.incomephase.Select(QHC.CmpEq("nphase", nfase))[0]["description"].ToString();
                    string nomefasesup2 = DS.incomephase.Select(QHC.CmpEq("nphase", nfase + 1))[0]["description"].ToString();

					RS["!livprecedente"]= nomefasesup+" "+
						Sup["ymov"].ToString()+"/"+
						Sup["nmov"].ToString();
					string nomefasemax = DS.incomephase.Select(QHC.CmpEq("nphase",maxfaseentrata))[0]["description"].ToString();
					if (nomefasesup2!=nomefasemax)
						RS["phase"]= "Da "+nomefasesup2+" a "+ nomefasemax;
					else 
						RS["phase"]= nomefasesup2;
				}
				else {
					RS["!livprecedente"]="";
					RS["phase"]="Tutte";
				}
			}
			formatgrids FGSpesa= new formatgrids(gridSpesa);
			FGSpesa.AutosizeColumnWidth();
			formatgrids FGEntrata = new formatgrids(gridEntrata);
			FGEntrata.AutosizeColumnWidth();
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
            this.txtNumMovimento = new System.Windows.Forms.TextBox();
            this.labelNum = new System.Windows.Forms.Label();
            this.txtEsercMovimento = new System.Windows.Forms.TextBox();
            this.labelEserc = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.dataGrid3 = new System.Windows.Forms.DataGrid();
            this.tabs = new Crownwood.Magic.Controls.TabControl();
            this.tabSpesa = new Crownwood.Magic.Controls.TabPage();
            this.btnCambiaBilancioS = new System.Windows.Forms.Button();
            this.btnScollegaS = new System.Windows.Forms.Button();
            this.btnCollegaS = new System.Windows.Forms.Button();
            this.gridSpesa = new System.Windows.Forms.DataGrid();
            this.tabEntrata = new Crownwood.Magic.Controls.TabPage();
            this.btnCambiaBilancioE = new System.Windows.Forms.Button();
            this.btnScollegaE = new System.Windows.Forms.Button();
            this.btnCollegaE = new System.Windows.Forms.Button();
            this.gridEntrata = new System.Windows.Forms.DataGrid();
            this.tabVariazioniSpesa = new Crownwood.Magic.Controls.TabPage();
            this.gridVarSpesa = new System.Windows.Forms.DataGrid();
            this.chkBilancio = new System.Windows.Forms.CheckBox();
            this.DS = new expense_automatismiritenute.vistaForm();
            this.chkUpb = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).BeginInit();
            this.tabs.SuspendLayout();
            this.tabSpesa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSpesa)).BeginInit();
            this.tabEntrata.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEntrata)).BeginInit();
            this.tabVariazioniSpesa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridVarSpesa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNumMovimento
            // 
            this.txtNumMovimento.Location = new System.Drawing.Point(272, 16);
            this.txtNumMovimento.Name = "txtNumMovimento";
            this.txtNumMovimento.ReadOnly = true;
            this.txtNumMovimento.Size = new System.Drawing.Size(88, 20);
            this.txtNumMovimento.TabIndex = 10;
            this.txtNumMovimento.Tag = "income.nmov";
            this.txtNumMovimento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelNum
            // 
            this.labelNum.Location = new System.Drawing.Point(216, 16);
            this.labelNum.Name = "labelNum";
            this.labelNum.Size = new System.Drawing.Size(56, 16);
            this.labelNum.TabIndex = 9;
            this.labelNum.Text = "Numero";
            this.labelNum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercMovimento
            // 
            this.txtEsercMovimento.Location = new System.Drawing.Point(88, 16);
            this.txtEsercMovimento.Name = "txtEsercMovimento";
            this.txtEsercMovimento.ReadOnly = true;
            this.txtEsercMovimento.Size = new System.Drawing.Size(96, 20);
            this.txtEsercMovimento.TabIndex = 8;
            this.txtEsercMovimento.Tag = "income.ymov";
            this.txtEsercMovimento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelEserc
            // 
            this.labelEserc.Location = new System.Drawing.Point(16, 16);
            this.labelEserc.Name = "labelEserc";
            this.labelEserc.Size = new System.Drawing.Size(72, 16);
            this.labelEserc.TabIndex = 7;
            this.labelEserc.Text = "Esercizio";
            this.labelEserc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(651, 448);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 13;
            this.btnOk.Tag = "mainsave";
            this.btnOk.Text = "Ok";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(555, 448);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(8, 8);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(584, 280);
            this.dataGrid1.TabIndex = 0;
            // 
            // dataGrid2
            // 
            this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid2.DataMember = "";
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(8, 8);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.Size = new System.Drawing.Size(584, 280);
            this.dataGrid2.TabIndex = 0;
            // 
            // dataGrid3
            // 
            this.dataGrid3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid3.DataMember = "";
            this.dataGrid3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid3.Location = new System.Drawing.Point(8, 8);
            this.dataGrid3.Name = "dataGrid3";
            this.dataGrid3.Size = new System.Drawing.Size(592, 280);
            this.dataGrid3.TabIndex = 0;
            // 
            // tabs
            // 
            this.tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabs.IDEPixelArea = true;
            this.tabs.Location = new System.Drawing.Point(8, 48);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.SelectedTab = this.tabEntrata;
            this.tabs.Size = new System.Drawing.Size(715, 380);
            this.tabs.TabIndex = 14;
            this.tabs.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabEntrata,
            this.tabSpesa,
            this.tabVariazioniSpesa});
            // 
            // tabSpesa
            // 
            this.tabSpesa.Controls.Add(this.btnCambiaBilancioS);
            this.tabSpesa.Controls.Add(this.btnScollegaS);
            this.tabSpesa.Controls.Add(this.btnCollegaS);
            this.tabSpesa.Controls.Add(this.gridSpesa);
            this.tabSpesa.Location = new System.Drawing.Point(0, 0);
            this.tabSpesa.Name = "tabSpesa";
            this.tabSpesa.Selected = false;
            this.tabSpesa.Size = new System.Drawing.Size(715, 355);
            this.tabSpesa.TabIndex = 1;
            this.tabSpesa.Title = "Movimenti Spesa";
            // 
            // btnCambiaBilancioS
            // 
            this.btnCambiaBilancioS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCambiaBilancioS.Location = new System.Drawing.Point(430, 308);
            this.btnCambiaBilancioS.Name = "btnCambiaBilancioS";
            this.btnCambiaBilancioS.Size = new System.Drawing.Size(269, 23);
            this.btnCambiaBilancioS.TabIndex = 5;
            this.btnCambiaBilancioS.Text = "Cambia Voce di Bilancio/UPB/Responsabile";
            this.btnCambiaBilancioS.Click += new System.EventHandler(this.btnCambiaBilancioS_Click);
            // 
            // btnScollegaS
            // 
            this.btnScollegaS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnScollegaS.Location = new System.Drawing.Point(227, 308);
            this.btnScollegaS.Name = "btnScollegaS";
            this.btnScollegaS.Size = new System.Drawing.Size(181, 23);
            this.btnScollegaS.TabIndex = 4;
            this.btnScollegaS.Text = "Annulla il collegamento";
            this.btnScollegaS.Click += new System.EventHandler(this.btnScollegaS_Click);
            // 
            // btnCollegaS
            // 
            this.btnCollegaS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCollegaS.Location = new System.Drawing.Point(16, 308);
            this.btnCollegaS.Name = "btnCollegaS";
            this.btnCollegaS.Size = new System.Drawing.Size(176, 23);
            this.btnCollegaS.TabIndex = 3;
            this.btnCollegaS.Text = "Collega a movimento esistente...";
            this.btnCollegaS.Click += new System.EventHandler(this.btnCollegaS_Click);
            // 
            // gridSpesa
            // 
            this.gridSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridSpesa.DataMember = "";
            this.gridSpesa.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridSpesa.Location = new System.Drawing.Point(8, 8);
            this.gridSpesa.Name = "gridSpesa";
            this.gridSpesa.Size = new System.Drawing.Size(699, 292);
            this.gridSpesa.TabIndex = 0;
            this.gridSpesa.Paint += new System.Windows.Forms.PaintEventHandler(this.gridSpesa_Paint);
            // 
            // tabEntrata
            // 
            this.tabEntrata.Controls.Add(this.btnCambiaBilancioE);
            this.tabEntrata.Controls.Add(this.btnScollegaE);
            this.tabEntrata.Controls.Add(this.btnCollegaE);
            this.tabEntrata.Controls.Add(this.gridEntrata);
            this.tabEntrata.Location = new System.Drawing.Point(0, 0);
            this.tabEntrata.Name = "tabEntrata";
            this.tabEntrata.Size = new System.Drawing.Size(715, 355);
            this.tabEntrata.TabIndex = 0;
            this.tabEntrata.Title = "Movimenti Entrata";
            // 
            // btnCambiaBilancioE
            // 
            this.btnCambiaBilancioE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCambiaBilancioE.Location = new System.Drawing.Point(440, 308);
            this.btnCambiaBilancioE.Name = "btnCambiaBilancioE";
            this.btnCambiaBilancioE.Size = new System.Drawing.Size(259, 23);
            this.btnCambiaBilancioE.TabIndex = 3;
            this.btnCambiaBilancioE.Text = "Cambia Voce di Bilancio/UPB/Responsabile";
            this.btnCambiaBilancioE.Click += new System.EventHandler(this.btnCambiaBilancioE_Click);
            // 
            // btnScollegaE
            // 
            this.btnScollegaE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnScollegaE.Location = new System.Drawing.Point(227, 308);
            this.btnScollegaE.Name = "btnScollegaE";
            this.btnScollegaE.Size = new System.Drawing.Size(175, 23);
            this.btnScollegaE.TabIndex = 2;
            this.btnScollegaE.Text = "Annulla il collegamento";
            this.btnScollegaE.Click += new System.EventHandler(this.btnScollegaE_Click);
            // 
            // btnCollegaE
            // 
            this.btnCollegaE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCollegaE.Location = new System.Drawing.Point(16, 308);
            this.btnCollegaE.Name = "btnCollegaE";
            this.btnCollegaE.Size = new System.Drawing.Size(176, 23);
            this.btnCollegaE.TabIndex = 1;
            this.btnCollegaE.Text = "Collega a movimento esistente...";
            this.btnCollegaE.Click += new System.EventHandler(this.btnCollegaE_Click);
            // 
            // gridEntrata
            // 
            this.gridEntrata.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridEntrata.DataMember = "";
            this.gridEntrata.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridEntrata.Location = new System.Drawing.Point(8, 8);
            this.gridEntrata.Name = "gridEntrata";
            this.gridEntrata.Size = new System.Drawing.Size(699, 292);
            this.gridEntrata.TabIndex = 0;
            this.gridEntrata.Paint += new System.Windows.Forms.PaintEventHandler(this.gridEntrata_Paint);
            // 
            // tabVariazioniSpesa
            // 
            this.tabVariazioniSpesa.Controls.Add(this.gridVarSpesa);
            this.tabVariazioniSpesa.Location = new System.Drawing.Point(0, 0);
            this.tabVariazioniSpesa.Name = "tabVariazioniSpesa";
            this.tabVariazioniSpesa.Selected = false;
            this.tabVariazioniSpesa.Size = new System.Drawing.Size(715, 355);
            this.tabVariazioniSpesa.TabIndex = 2;
            this.tabVariazioniSpesa.Title = "Variazioni Spesa";
            // 
            // gridVarSpesa
            // 
            this.gridVarSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridVarSpesa.DataMember = "";
            this.gridVarSpesa.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridVarSpesa.Location = new System.Drawing.Point(8, 8);
            this.gridVarSpesa.Name = "gridVarSpesa";
            this.gridVarSpesa.Size = new System.Drawing.Size(699, 332);
            this.gridVarSpesa.TabIndex = 0;
            // 
            // chkBilancio
            // 
            this.chkBilancio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkBilancio.Checked = true;
            this.chkBilancio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBilancio.Location = new System.Drawing.Point(8, 434);
            this.chkBilancio.Name = "chkBilancio";
            this.chkBilancio.Size = new System.Drawing.Size(472, 19);
            this.chkBilancio.TabIndex = 3;
            this.chkBilancio.Text = "Scegli il movimento a cui collegare l\'automatismo tra quelli con la stessa voce d" +
    "i bilancio";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // chkUpb
            // 
            this.chkUpb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkUpb.Checked = true;
            this.chkUpb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUpb.Location = new System.Drawing.Point(8, 451);
            this.chkUpb.Name = "chkUpb";
            this.chkUpb.Size = new System.Drawing.Size(472, 22);
            this.chkUpb.TabIndex = 15;
            this.chkUpb.Text = "Scegli il movimento a cui collegare l\'automatismo tra quelli con lo stesso UPB";
            // 
            // frmSpesa_AutomatismiRitenute
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(731, 485);
            this.Controls.Add(this.chkUpb);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.txtNumMovimento);
            this.Controls.Add(this.txtEsercMovimento);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.labelNum);
            this.Controls.Add(this.labelEserc);
            this.Controls.Add(this.chkBilancio);
            this.Name = "frmSpesa_AutomatismiRitenute";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Automatismi Ritenute";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).EndInit();
            this.tabs.ResumeLayout(false);
            this.tabSpesa.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSpesa)).EndInit();
            this.tabEntrata.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEntrata)).EndInit();
            this.tabVariazioniSpesa.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridVarSpesa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion


		private void btnCollegaE_Click(object sender, System.EventArgs e) {
			DataRow []RigheSelezionate= GetGridSelectedRows(gridEntrata);
			if (RigheSelezionate==null) return;
			if (RigheSelezionate.Length==0) return;
			string rowfilter;
			int maxfase = GetMaxFaseForSelection(RigheSelezionate, "income");
			if (maxfase<1){
				MessageBox.Show("Non è possibile collegare tutte le righe selezionate ad uno stesso movimento.\n"+
					"Le informazioni di U.P.B., bilancio, versante sono troppo diverse tra loro.","Errore");
				return;
			}
			int selectedfase=maxfase;
			if (maxfase>1){
				DataTable Fasi2=  DS.incomephase.Copy();
				foreach (DataRow ToDel in Fasi2.Select(QHC.CmpGt("nphase",maxfase))){
					ToDel.Delete();
				}
				Fasi2.AcceptChanges();
				FrmAskFase F = new FrmAskFase(Fasi2);
				if (F.ShowDialog()!=DialogResult.OK) return;
				selectedfase = Convert.ToInt32( F.cmbFasi.SelectedValue);
			}
			rowfilter= GetFilterForSelection(RigheSelezionate, "income", selectedfase);
            rowfilter = QHS.AppAnd(rowfilter, QHS.CmpEq("nphase", selectedfase));
			decimal tot = 0;
			foreach (DataRow R in RigheSelezionate){
				tot+= CfgFn.GetNoNullDecimal(R["amount"]);
			}
            rowfilter = QHS.AppAnd(rowfilter, QHS.CmpGe("available", tot));
			MetaData E = Disp.Get("income");
			E.DS= DS.Clone();
			E.FilterLocked=true;
			DataRow Choosen  = E.SelectOne("default",rowfilter,"amount",null);
			if (Choosen==null) return;
			RighePadriEntrata[Choosen["idinc"]]= Choosen;
			foreach (DataRow R in RigheSelezionate){
				R["parentidinc"]=Choosen["idinc"];
				int I = Convert.ToInt32(R["idinc"]);
				Automatismi[I]["livsupid"]= Choosen["idinc"];
				CambiaVoceBilancio(R,Choosen);
				CambiaVoceUPB(R,Choosen);
				CambiaVoceCreditore(R,Choosen);
			}
			RicalcolaCampiCalcolati();
		}

		int GetFaseInfo(string flag, string table){
			string fasitable=table+"phase";
			DataTable Fase= DS.Tables[fasitable];
			int faseattivazione;

			DataRow[] MyDRfase;
			MyDRfase  = Fase.Select(QHS.CmpEq(flag,'S'),"nphase");			
			if (MyDRfase.Length > 0)
				faseattivazione = (Convert.ToInt32(MyDRfase[0]["nphase"]));
			else 
				faseattivazione = 99;
			return faseattivazione;
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

		string GetFilterForSelection(DataRow []Selected, string table, int livello){
            string filter = QHS.CmpEq("ayear", Disp.GetSys("esercizio")); ;
            int minfasebil = CfgFn.GetNoNullInt32(Conn.GetSys(table + "finphase"));
            int minfasecred = CfgFn.GetNoNullInt32(Conn.GetSys(table + "regphase"));
			bool vincolabil= chkBilancio.Checked;
            bool vincolaupb = chkUpb.Checked;

            if (vincolabil && (livello >= minfasebil)){
                object O = Selected[0]["idfin"];
                if (O != DBNull.Value)
                {
                    filter = QHS.AppAnd(filter, QHS.CmpEq("idfin", O));
                }
            }

            if (vincolaupb && (livello >= minfasebil)){
                    object P = Selected[0]["idupb"];
                    if (P != DBNull.Value)
                    {
                        filter = QHS.AppAnd(filter, QHS.CmpEq("idupb", P));
                    }
                }
			
			if (livello>=minfasecred){
				object O  = Selected[0]["idreg"];
				if (O!=DBNull.Value){
                    filter = QHS.AppAnd(filter, QHS.CmpEq("idreg", O));
				}
			}
			return filter;
		}

		int GetMaxFaseForSelection(DataRow []Selected, string table){
            int minfasebil = CfgFn.GetNoNullInt32(Conn.GetSys(table + "finphase"));
            int minfasecred = CfgFn.GetNoNullInt32(Conn.GetSys(table + "regphase"));
			bool vincolabil= chkBilancio.Checked;
            bool vincolaupb = chkUpb.Checked;
			int fasecurr=99;
			if (table=="income"){
				fasecurr=Convert.ToInt32(maxfaseentrata)-1;
			}
			else {
				fasecurr=Convert.ToInt32(maxfasespesa)-1;
			}
            if ((nvaloridiversi("idfin", Selected) > 1) && vincolabil ){
				if (fasecurr >= minfasebil) fasecurr= minfasebil-1;
			}
            if ((nvaloridiversi("idupb", Selected) > 1)  && vincolaupb){
				if (fasecurr >= minfasebil) fasecurr= minfasebil-1;
			}

			if (nvaloridiversi("idreg",Selected)>1){
				if (fasecurr >= minfasecred) fasecurr= minfasecred-1;
			}
			return fasecurr;
		}

		DataRow GetGridRow(DataGrid G, int index){
			string TableName = G.DataMember.ToString();
			DataSet MyDS =(DataSet)G.DataSource;
			DataTable MyTable = MyDS.Tables[TableName];
			string filter;
			if (MyTable.TableName == "expenseview")
				filter= QHC.CmpEq("idexp",G[index,0]);
			else
				filter= QHC.CmpEq("idinc",G[index,0]);
			DataRow[] selectresult = MyTable.Select(filter);
			return selectresult[0];
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

		private void btnCollegaS_Click(object sender, System.EventArgs e) {
			DataRow []RigheSelezionate= GetGridSelectedRows(gridSpesa);
			if (RigheSelezionate==null) return;
			if (RigheSelezionate.Length==0) return;
			string rowfilter;
			int maxfase = GetMaxFaseForSelection(RigheSelezionate, "expense");
			if (maxfase<1){
				MessageBox.Show("Non è possibile collegare tutte le righe selezionate ad uno stesso movimento.\n"+
					"Le informazioni di U.P.B., bilancio, percipiente sono "+
					"troppo diverse tra loro.","Errore");
				return;
			}
			int selectedfase=maxfase;
			if (maxfase>1){
				DataTable Fasi2=  DS.expensephase.Copy();
				foreach (DataRow ToDel in Fasi2.Select(QHC.CmpGt("nphase",maxfase))){
					ToDel.Delete();
				}
				Fasi2.AcceptChanges();
				FrmAskFase F = new FrmAskFase(Fasi2);
				if (F.ShowDialog()!=DialogResult.OK) return;
				selectedfase = Convert.ToInt32( F.cmbFasi.SelectedValue);
			}
			rowfilter= GetFilterForSelection(RigheSelezionate, "expense", selectedfase);
            rowfilter = QHS.AppAnd(rowfilter, QHS.CmpEq("nphase", selectedfase));
			decimal tot = 0;
			foreach (DataRow R in RigheSelezionate){
				tot+= CfgFn.GetNoNullDecimal(R["amount"]);
			}
            rowfilter = QHS.AppAnd(rowfilter, QHS.CmpGe("available", tot));
			MetaData S = Disp.Get("expense");
			S.DS= DS.Clone();
			S.FilterLocked=true;
			DataRow Choosen  = S.SelectOne("default",rowfilter,"expense",null);
			if (Choosen==null) return;
			RighePadriSpesa[Choosen["idexp"]]= Choosen;
			foreach (DataRow R in RigheSelezionate){
				R["parentidexp"]=Choosen["idexp"];
				int I = Convert.ToInt32(R["idexp"]);
				Automatismi[I]["livsupid"]= Choosen["idexp"];
				CambiaVoceBilancio(R,Choosen);
				CambiaVoceUPB(R,Choosen);
				CambiaVoceCreditore(R,Choosen);
			}
			RicalcolaCampiCalcolati();
		}

		private void btnScollegaE_Click(object sender, System.EventArgs e) {
			DataRow []RigheSelezionate= GetGridSelectedRows(gridEntrata);
			if (RigheSelezionate==null) return;
			if (RigheSelezionate.Length==0) return;
			foreach (DataRow R in RigheSelezionate){
				R["parentidinc"]=DBNull.Value;
				int I = Convert.ToInt32(R["idinc"]);
				Automatismi[I]["livsupid"]= DBNull.Value;
				R.RejectChanges();	//CambiaVoceBilancio(R,Automatismi[I]);
			}
			RicalcolaCampiCalcolati();
		}

		private void btnScollegaS_Click(object sender, System.EventArgs e) {
			DataRow []RigheSelezionate= GetGridSelectedRows(gridSpesa);
			if (RigheSelezionate==null) return;
			if (RigheSelezionate.Length==0) return;
			foreach (DataRow R in RigheSelezionate){
				R["parentidexp"]=DBNull.Value;
				int I = Convert.ToInt32(R["idexp"]);
				Automatismi[I]["livsupid"]= DBNull.Value;
				R.RejectChanges(); //	CambiaVoceBilancio(R,Automatismi[I]);
			}
			RicalcolaCampiCalcolati();
		}

		private void btnOk_Click(object sender, System.EventArgs e) {
			AllineaVociBilancio();
		}

		private void btnCambiaBilancioS_Click(object sender, System.EventArgs e) {
			DataRow []RigheSelezionate= GetGridSelectedRows(gridSpesa);
			if (RigheSelezionate==null) return;
			if (RigheSelezionate.Length==0) return;
			cambiaVoceBilancio("S",RigheSelezionate);
		}

		void cambiaVoceBilancio(string E_S,DataRow [] RigheSelezionate) {
            //string filter_upb = RigheSelezionate[0]["idupb"].ToString();
            //FrmAskBilancio Bil = new FrmAskBilancio(E_S,filter_upb,Disp,Conn);
            //DataRow[] RigheSelezionate = GetGridSelectedRows(gridMovSpesa);
            if (RigheSelezionate == null) return;
            if (RigheSelezionate.Length == 0) return;

            object idupb = RigheSelezionate[0]["idupb"];
            object idfin = RigheSelezionate[0]["idfin"];
            object idman = RigheSelezionate[0]["idman"];
            decimal importo = 0;
            foreach (DataRow riga in RigheSelezionate) {
                importo += CfgFn.GetNoNullDecimal(riga["amount"]);
            }
            //FrmAskBilancio Bil = new FrmAskBilancio(E_S,idupb, idfin, importo, Disp, Conn);
		    MetaData mExpense = Disp.Get("expense");

		    FrmAskInfo fInfo = new FrmAskInfo(mExpense, E_S, true)
		        .SetUPB(idupb)
		        .EnableUPBSelection(true)
		        .SetFin(idfin)
		        .EnableFinSelection(true)
		        .EnableFilterAvailable(importo)
		        .SetManager(idman)
		        .EnableManagerSelection(true)
		        .AllowNoFinSelection(false)
		        .AllowNoUpbSelection(false)
                .AllowNoManagerSelection(true);
            
		    fInfo.gboxUPB.Text = "";
		    fInfo.Text = "Selezione nuova voce di bilancio";
		    if (fInfo.ShowDialog() != DialogResult.OK) return;



			//if (Bil.ShowDialog()!=DialogResult.OK) return;
			//if (Bil.Selected==null) return;
			//if (Bil.Selected["idfin"] == DBNull.Value) return;
		
			string campo = (E_S == "S") ? "idexp" : "idinc";
			for(int i = 0;i < RigheSelezionate.Length;i++) {
			    RigheSelezionate[i]["idfin"] = fInfo.GetFin(); // Bil.Selected["idfin"];
			    RigheSelezionate[i]["codefin"] = fInfo.GetFinCode();//  Bil.Selected["codefin"];
			    RigheSelezionate[i]["idupb"] = fInfo.GetUPB();// Bil.Selected["idupb"];
			    RigheSelezionate[i]["codeupb"] = fInfo.GetUpbCode(); //Bil.Selected["codeupb"];
                if (fInfo.GetManager() != DBNull.Value) { //Bil.Selected["idman"] != DBNull.Value
                    RigheSelezionate[i]["idman"] = fInfo.GetManager(); //Bil.Selected["idman"];
                    RigheSelezionate[i]["manager"] = fInfo.GetManagerTitle();  //Bil.Selected["manager"];
                }
                //else {
                //    if (Bil.cmbResponsabile.SelectedIndex > 0) {
                //        RigheSelezionate[i]["idman"] = Bil.cmbResponsabile.SelectedValue;
                //        RigheSelezionate[i]["manager"] = Bil.cmbResponsabile.Text;
                //    }
                //}
				int N = Convert.ToInt32(RigheSelezionate[i][campo].ToString());
				Automatismi[N]["idfin"] = fInfo.GetFin(); // Bil.Selected["idfin"];
                Automatismi[N]["codefin"] = fInfo.GetFinCode();//  Bil.Selected["codefin"];
                Automatismi[N]["idupb"] = fInfo.GetUPB();// Bil.Selected["idupb"];
                Automatismi[N]["codeupb"] = fInfo.GetUpbCode(); //Bil.Selected["codeupb"];
                if (fInfo.GetManager() != DBNull.Value) { //Bil.Selected["idman"] != DBNull.Value
                    Automatismi[N]["idman"] = fInfo.GetManager(); //Bil.Selected["idman"];
                    Automatismi[N]["manager"] = fInfo.GetManagerTitle();  //Bil.Selected["manager"];
                }
                //else {
                //    if (Bil.cmbResponsabile.SelectedIndex > 0) {
                //        Automatismi[N]["idman"] = Bil.cmbResponsabile.SelectedValue;
                //        Automatismi[N]["manager"] = Bil.cmbResponsabile.Text;
                //    }
                //}


			}
		}

		private void btnCambiaBilancioE_Click(object sender, System.EventArgs e) {
			DataRow []RigheSelezionate= GetGridSelectedRows(gridEntrata);
			if (RigheSelezionate==null) return;
			if (RigheSelezionate.Length==0) return;
			cambiaVoceBilancio("E",RigheSelezionate);
		}

		private void gridEntrata_Paint(object sender, System.Windows.Forms.PaintEventArgs e) {
			object dataSource = gridEntrata.DataSource;
			if (dataSource==null) return;

			CurrencyManager cm = (CurrencyManager) 
				gridEntrata.BindingContext[dataSource, gridEntrata.DataMember];

			DataView view = cm.List as DataView;

			bool esisteSelezione = false;

			if (view != null) {
				for (int i=0; i<view.Count; i++) {
					if (gridEntrata.IsSelected(i)) {
						esisteSelezione = true;
						object  livPrecedente = view[i]["parentidinc"];
						if (livPrecedente != DBNull.Value) {
							btnCollegaE.Enabled = false;
							btnCambiaBilancioE.Enabled = false;
							btnScollegaE.Enabled = true;
							return;
						}
					}
				}
			}
			btnCambiaBilancioE.Enabled = esisteSelezione;
			btnCollegaE.Enabled = esisteSelezione;
			btnScollegaE.Enabled = false;
		}

		private void gridSpesa_Paint(object sender, System.Windows.Forms.PaintEventArgs e) {
			object dataSource = gridSpesa.DataSource;
			if (dataSource==null) return;

			CurrencyManager cm = (CurrencyManager) 
				gridSpesa.BindingContext[dataSource, gridSpesa.DataMember];

			DataView view = cm.List as DataView;

			bool esisteSelezione = false;

			if (view != null) {
				for (int i=0; i<view.Count; i++) {
					if (gridSpesa.IsSelected(i)) {
						esisteSelezione = true;
						object livPrecedente = view[i]["parentidexp"];
						if (livPrecedente != DBNull.Value) {
							btnCollegaS.Enabled = false;
							btnCambiaBilancioS.Enabled = false;
							btnScollegaS.Enabled = true;
							return;
						}
					}
				}
			}
			btnCambiaBilancioS.Enabled = esisteSelezione;
			btnCollegaS.Enabled = esisteSelezione;
			btnScollegaS.Enabled = false;
		}
	}
}
