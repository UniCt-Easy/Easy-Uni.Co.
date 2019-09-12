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
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;//funzioni_configurazione

namespace proceedspart_assegnazioneautomatica//assegnazioneincassi_automatica//
{
	/// <summary>
	/// Summary description for frmassegnazioneincassi_automatica.
	/// </summary>
	public class Frm_proceedspart_assegnazioneautomatica : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnEseguiTutte;
		private System.Windows.Forms.Button btnEsegui;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DataGrid dgrAssegnazione;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGrid dgrMovEntrata;
		MetaData Meta;
		//DataTable SP_Result;
		int codicefase;
		int esercizio;
		public /*Rana:assegnazioneincassi_automatica.*/vistaForm DS;
		private System.Windows.Forms.Panel panel1;
        private Button btnDoSave;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_proceedspart_assegnazioneautomatica()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
            this.btnEseguiTutte = new System.Windows.Forms.Button();
            this.btnEsegui = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dgrAssegnazione = new System.Windows.Forms.DataGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.dgrMovEntrata = new System.Windows.Forms.DataGrid();
            this.DS = new proceedspart_assegnazioneautomatica.vistaForm();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDoSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgrAssegnazione)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrMovEntrata)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEseguiTutte
            // 
            this.btnEseguiTutte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEseguiTutte.Location = new System.Drawing.Point(80, 304);
            this.btnEseguiTutte.Name = "btnEseguiTutte";
            this.btnEseguiTutte.Size = new System.Drawing.Size(88, 23);
            this.btnEseguiTutte.TabIndex = 13;
            this.btnEseguiTutte.Text = "Assegna tutto";
            this.btnEseguiTutte.Click += new System.EventHandler(this.btnEseguiTutte_Click);
            // 
            // btnEsegui
            // 
            this.btnEsegui.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEsegui.Location = new System.Drawing.Point(80, 264);
            this.btnEsegui.Name = "btnEsegui";
            this.btnEsegui.Size = new System.Drawing.Size(88, 23);
            this.btnEsegui.TabIndex = 12;
            this.btnEsegui.Text = "Assegna";
            this.btnEsegui.Click += new System.EventHandler(this.btnEsegui_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(208, 240);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(248, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Assegnazioni automatiche da effettuare:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgrAssegnazione
            // 
            this.dgrAssegnazione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrAssegnazione.DataMember = "";
            this.dgrAssegnazione.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgrAssegnazione.Location = new System.Drawing.Point(200, 264);
            this.dgrAssegnazione.Name = "dgrAssegnazione";
            this.dgrAssegnazione.Size = new System.Drawing.Size(344, 144);
            this.dgrAssegnazione.TabIndex = 9;
            this.dgrAssegnazione.Tag = "";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(584, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "Movimenti di entrata non assegnati:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgrMovEntrata
            // 
            this.dgrMovEntrata.AllowNavigation = false;
            this.dgrMovEntrata.AllowSorting = false;
            this.dgrMovEntrata.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrMovEntrata.DataMember = "";
            this.dgrMovEntrata.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgrMovEntrata.Location = new System.Drawing.Point(8, 32);
            this.dgrMovEntrata.Name = "dgrMovEntrata";
            this.dgrMovEntrata.Size = new System.Drawing.Size(536, 184);
            this.dgrMovEntrata.TabIndex = 7;
            this.dgrMovEntrata.Tag = "";
            this.dgrMovEntrata.CurrentCellChanged += new System.EventHandler(this.dgrMovEntrata_CurrentCellChanged);
            this.dgrMovEntrata.Click += new System.EventHandler(this.dgrMovEntrata_Click);
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(8, 224);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(536, 2);
            this.panel1.TabIndex = 14;
            // 
            // btnDoSave
            // 
            this.btnDoSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDoSave.Enabled = false;
            this.btnDoSave.Location = new System.Drawing.Point(80, 378);
            this.btnDoSave.Name = "btnDoSave";
            this.btnDoSave.Size = new System.Drawing.Size(88, 25);
            this.btnDoSave.TabIndex = 15;
            this.btnDoSave.TabStop = false;
            this.btnDoSave.Text = "Salva";
            this.btnDoSave.Click += new System.EventHandler(this.btnDoSave_Click);
            // 
            // Frm_proceedspart_assegnazioneautomatica
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(554, 415);
            this.Controls.Add(this.btnDoSave);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnEseguiTutte);
            this.Controls.Add(this.btnEsegui);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgrAssegnazione);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgrMovEntrata);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_proceedspart_assegnazioneautomatica";
            this.Text = "frmassegnazioneincassi_automatica";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmassegnazioneincassi_automatica_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.dgrAssegnazione)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrMovEntrata)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        CQueryHelper QHC;
        QueryHelper QHS;
		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);

            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
			esercizio = Convert.ToInt32(Meta.GetSys("esercizio"));
			DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn,DS.incomephase, null,null, null, true);
            codicefase = CfgFn.GetNoNullInt32(Meta.GetSys("maxincomephase"));
			GetData.LockRead(DS.incomeview);
			GetData.DenyClear(DS.incomeview);
			GetData.LockRead(DS.proceedspart);
			FillEntrataView();
			QueryCreator.SetTableForPosting(DS.incomeview, "income");
            HelpForm.SetAllowMultiSelection(DS.incomeview, true);
			Meta.CanCancel = false;
			Meta.CanInsert = false;
			Meta.CanInsertCopy = false;
			Meta.CanSave = false;
			Meta.SearchEnabled = false;
		}

//		public void MetaData_AfterClear() {
//			this.Text="Assegnazione automatica incassi";
//		}

		void FillEntrataView(){
			string MyQuery = "SELECT * FROM incomeview WHERE " +
                QHS.AppAnd(QHS.CmpEq("ayear", esercizio), QHS.CmpEq("nphase", codicefase),
                QHS.CmpGt("unpartitioned", 0), "(idfin IN (SELECT idfinincome FROM partincomesetup))");

			DataTable MovEntrata = Meta.Conn.SQLRunner(MyQuery);
			MetaDataDispatcher Disp;
			Disp=Meta.Dispatcher;
			DS.incomeview.Clear();
			foreach (DataRow R in MovEntrata.Rows)
				AddRowToTable(R, DS.incomeview);
			MetaData MEntrataView = Disp.Get("incomeview");
			MEntrataView.DescribeColumns(DS.incomeview,"assegnautocreditiincassi");

			HelpForm.SetDataGrid(dgrMovEntrata, DS.incomeview);			

			formatgrids FGEntrata = new formatgrids(dgrMovEntrata);
			FGEntrata.AutosizeColumnWidth();

			DS.incomeview.AcceptChanges();
			if (DS.incomeview.Rows.Count==0){
				btnEsegui.Enabled=false;
				btnEseguiTutte.Enabled=false;
				return;
			}
			btnEsegui.Enabled=true;
			btnEseguiTutte.Enabled=true;
			try {
				dgrMovEntrata.Select(0);
			}
			catch {
			}
			dgrMovEntrata_CurrentCellChanged(null, null);
		}

		bool CallStoredProcedure(DataRow ParentEntrataRow) {
		 
			DataSet Out=  Meta.Conn.CallSP("compute_partincome", 
				new object[] {esercizio, ParentEntrataRow["idinc"]});
			if (Out==null) return false;
			if (Out.Tables.Count==0) return true; //no answer from sp
			FillTableAssegnazioni(ParentEntrataRow, Out.Tables[0]);
			//SP_Result = Out.Tables[0].Copy();		
			return true;
		}

		void FillTableAssegnazioni(DataRow ParentEntrataRow, DataTable Automatismi) {
	 
			foreach (DataRow R in Automatismi.Rows) {
				AddVociCollegate(R);
				AddRowToTableAssegnazioni(ParentEntrataRow, R, DS.proceedspart);
			}
			Meta.DescribeColumns(DS.proceedspart,"assegnautomatica");

			HelpForm.SetDataGrid(dgrAssegnazione, DS.proceedspart);			

			formatgrids FGAssegnazione = new formatgrids(dgrAssegnazione);
			FGAssegnazione.AutosizeColumnWidth();

		}

		void AddRowToTable(DataRow R, DataTable T) {			
			DataRow NewR = T.NewRow();
			foreach(DataColumn C in R.Table.Columns) {
				if( T.Columns[C.ColumnName]!= null)
					NewR[C.ColumnName]= R[C.ColumnName];
			}
			T.Rows.Add(NewR);
		}

		void AddRowToTableAssegnazioni(DataRow ParentEntrataRow, DataRow R, DataTable T) {			
			//DataRow NewR = T.NewRow();
			Meta.SetDefaults(T);
			DataRow NewR = Meta.Get_New_Row(ParentEntrataRow,T);
			foreach(DataColumn C in R.Table.Columns) {
				if (C.ColumnName == "codefin") {
					NewR["!codicebilancio"]=R["codefin"];
					continue;
				}
                if (C.ColumnName == "codeupb")
                {
                    NewR["!codeupb"] = R["codeupb"];
                    continue;
                }
				NewR[C.ColumnName]= R[C.ColumnName];
			}
			//T.Rows.Add(NewR);
		}

        private DataRow[] GetGridSelectedRows(DataGrid G)
        {
            string TableName = G.DataMember.ToString();
            DataSet MyDS = (DataSet)G.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];
            int numrighetemp = MyTable.Rows.Count;
            int numrighe = 0;
            int i;
            for (i = 0; i < numrighetemp; i++)
            {
                if (G.IsSelected(i))
                {
                    numrighe++;
                }
            }

            DataRow[] Res = new DataRow[numrighe];
            int count = 0;
            for (i = 0; i < numrighetemp; i++)
            {
                if (G.IsSelected(i))
                {
                    Res[count++] = GetGridRow(G, i);
                }
            }
            return Res;
        }


        DataRow GetGridRow(DataGrid G, int index)
        {
            string TableName = G.DataMember.ToString();
            DataSet MyDS = (DataSet)G.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];
            string filter = "";
            if (MyTable.TableName == "incomeview")
                filter = QHC.CmpEq("idinc", G[index, 9]);

            DataRow[] selectresult = MyTable.Select(filter);
            return selectresult[0];
        }

		bool SaveData(){
			Easy_PostData MyPostData = new Easy_PostData();
			MyPostData.InitClass(DS, Meta.Conn);

			return MyPostData.DO_POST();
		}

		DataRow GetLastEntrataRow(){
			DataRowView DRView = null;
			DRView = (DataRowView)dgrMovEntrata.BindingContext[DS, "incomeview"].Current;
			if (DRView == null) return null;
			return DRView.Row;
		}

		void AddVoceBilancio(object ID, string codbil){
			if (ID==DBNull.Value) return;
			if (DS.fin.Select(QHC.CmpEq("idfin", ID)).Length>0)return;
			DataRow NewBil = DS.fin.NewRow();
			NewBil["idfin"]=ID;
			NewBil["codefin"]=codbil;
			DS.fin.Rows.Add(NewBil);
			NewBil.AcceptChanges();
		}

		void AddVociCollegate(DataRow SP_Row){
			AddVoceBilancio(SP_Row["idfin"].ToString(), 
				SP_Row["codefin"].ToString());
		}

		private void dgrMovEntrata_CurrentCellChanged(object sender, System.EventArgs e) {
		}

		private void btnEsegui_Click(object sender, System.EventArgs e) {
            if (DS.incomeview.Rows.Count == 0) return;
            DataRow[] R = GetGridSelectedRows(dgrMovEntrata);
            if (R.Length == 0) return;
            bool doSave = true;
            foreach (DataRow Row in R)
            {
                if (!CallStoredProcedure(Row))
                    doSave = false;
            }
            btnDoSave.Enabled = doSave;
	 
		}

		private void btnEseguiTutte_Click(object sender, System.EventArgs e) {
			if (DS.incomeview.Rows.Count==0) return;

            for (int i = 0; i < DS.Tables["incomeview"].Rows.Count; i++) dgrMovEntrata.Select(i);

            bool doSave = true;
            foreach (DataRow R in DS.incomeview.Rows)
            {
                if (!CallStoredProcedure(R))
                    doSave = false;
            }
            btnDoSave.Enabled = doSave;
			 
		}

		private void btnChiudi_Click(object sender, System.EventArgs e) {
			DS.AcceptChanges();

			DialogResult=DialogResult.Cancel;
		}

		private void frmassegnazioneincassi_automatica_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
			DS.AcceptChanges();
		}

        private void dgrMovEntrata_Click(object sender, EventArgs e)
        {
            DS.proceedspart.Clear();
            btnDoSave.Enabled = false;
        }

        private void btnDoSave_Click(object sender, EventArgs e)
        {
            SaveData();
            FillEntrataView();
            btnDoSave.Enabled = false;
        }

	}
}
