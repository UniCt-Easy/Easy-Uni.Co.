/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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

namespace creditpart_assegnazioneautomatica//assegnazionecrediti_automatica//
{
	/// <summary>
	/// Summary description for frmassegnazionecrediti_automatica.
	/// </summary>
	public class Frm_creditpart_assegnazioneautomatica : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DataGrid dgrMovEntrata;
		private System.Windows.Forms.DataGrid dgrAssegnazione;
		private System.Windows.Forms.Button btnEsegui;
		private System.Windows.Forms.Button btnEseguiTutte;
		MetaData Meta;
		//DataTable SP_Result;
		int codicefase;
		int esercizio;
		public vistaForm DS;
		private System.Windows.Forms.Panel panel1;
        private Button btnDoSave;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_creditpart_assegnazioneautomatica()
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
            this.dgrMovEntrata = new System.Windows.Forms.DataGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgrAssegnazione = new System.Windows.Forms.DataGrid();
            this.btnEsegui = new System.Windows.Forms.Button();
            this.btnEseguiTutte = new System.Windows.Forms.Button();
            this.DS = new creditpart_assegnazioneautomatica.vistaForm();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDoSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgrMovEntrata)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrAssegnazione)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // dgrMovEntrata
            // 
            this.dgrMovEntrata.AllowNavigation = false;
            this.dgrMovEntrata.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrMovEntrata.DataMember = "";
            this.dgrMovEntrata.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgrMovEntrata.Location = new System.Drawing.Point(8, 32);
            this.dgrMovEntrata.Name = "dgrMovEntrata";
            this.dgrMovEntrata.Size = new System.Drawing.Size(536, 184);
            this.dgrMovEntrata.TabIndex = 0;
            this.dgrMovEntrata.Tag = "";
            this.dgrMovEntrata.CurrentCellChanged += new System.EventHandler(this.dgrMovEntrata_CurrentCellChanged);
            this.dgrMovEntrata.Click += new System.EventHandler(this.dgrMovEntrata_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(584, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Movimenti di entrata non assegnati:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Location = new System.Drawing.Point(208, 232);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(384, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Assegnazioni automatiche da effettuare:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgrAssegnazione
            // 
            this.dgrAssegnazione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrAssegnazione.DataMember = "";
            this.dgrAssegnazione.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgrAssegnazione.Location = new System.Drawing.Point(200, 256);
            this.dgrAssegnazione.Name = "dgrAssegnazione";
            this.dgrAssegnazione.Size = new System.Drawing.Size(344, 144);
            this.dgrAssegnazione.TabIndex = 2;
            this.dgrAssegnazione.Tag = "";
            // 
            // btnEsegui
            // 
            this.btnEsegui.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEsegui.Location = new System.Drawing.Point(88, 275);
            this.btnEsegui.Name = "btnEsegui";
            this.btnEsegui.Size = new System.Drawing.Size(88, 23);
            this.btnEsegui.TabIndex = 5;
            this.btnEsegui.TabStop = false;
            this.btnEsegui.Text = "Assegna";
            this.btnEsegui.Click += new System.EventHandler(this.btnEsegui_Click);
            // 
            // btnEseguiTutte
            // 
            this.btnEseguiTutte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEseguiTutte.Location = new System.Drawing.Point(88, 304);
            this.btnEseguiTutte.Name = "btnEseguiTutte";
            this.btnEseguiTutte.Size = new System.Drawing.Size(88, 23);
            this.btnEseguiTutte.TabIndex = 6;
            this.btnEseguiTutte.TabStop = false;
            this.btnEseguiTutte.Text = "Assegna tutto";
            this.btnEseguiTutte.Click += new System.EventHandler(this.btnEseguiTutte_Click);
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
            this.panel1.TabIndex = 7;
            // 
            // btnDoSave
            // 
            this.btnDoSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDoSave.Enabled = false;
            this.btnDoSave.Location = new System.Drawing.Point(88, 379);
            this.btnDoSave.Name = "btnDoSave";
            this.btnDoSave.Size = new System.Drawing.Size(88, 21);
            this.btnDoSave.TabIndex = 8;
            this.btnDoSave.TabStop = false;
            this.btnDoSave.Text = "Salva";
            this.btnDoSave.Click += new System.EventHandler(this.btnDoSave_Click);
            // 
            // Frm_creditpart_assegnazioneautomatica
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
            this.Name = "Frm_creditpart_assegnazioneautomatica";
            this.Text = "frmassegnazionecrediti_automatica";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmassegnazionecrediti_automatica_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.dgrMovEntrata)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrAssegnazione)).EndInit();
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
			codicefase = Convert.ToInt32(Meta.GetSys("incomefinphase"));
			GetData.LockRead(DS.incomeview);
			GetData.DenyClear(DS.incomeview);
			GetData.LockRead(DS.creditpart);
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
//			this.Text="Assegnazione automatica crediti";
//		}

		void FillEntrataView(){
			string MyQuery = "SELECT * FROM incomeview WHERE " + QHS.AppAnd(
                QHS.CmpEq("ayear", esercizio), QHS.CmpEq("nphase", codicefase), 
                QHS.CmpGt("unpartitioned",0), "(idfin IN (SELECT idfinincome FROM partincomesetup))");

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
				AddRowToTableAssegnazioni(ParentEntrataRow, R, DS.creditpart);
			}
			Meta.DescribeColumns(DS.creditpart,"assegnautomatica");

			HelpForm.SetDataGrid(dgrAssegnazione, DS.creditpart);			

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

		void AddRowToTableAssegnazioni(DataRow ParentEntrataRow,DataRow R, DataTable T) {			
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

		bool SaveData(){
			Easy_PostData MyPostData = new Easy_PostData();
			MyPostData.InitClass(DS, Meta.Conn);

			return MyPostData.DO_POST();
		}

		private void btnEsegui_Click(object sender, System.EventArgs e) {
            if (DS.incomeview.Rows.Count == 0) return;
            DS.creditpart.Clear();
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

		private void btnChiudi_Click(object sender, System.EventArgs e) {
			DS.AcceptChanges();

			DialogResult=DialogResult.Cancel;
		}

		DataRow GetLastEntrataRow(){
			DataRowView DRView = null;
			DRView = (DataRowView)dgrMovEntrata.BindingContext[DS, "incomeview"].Current;
			if (DRView == null) return null;
			return DRView.Row;
		}

        private void dgrMovEntrata_CurrentCellChanged(object sender, System.EventArgs e)
        {
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

		private void frmassegnazionecrediti_automatica_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
			DS.AcceptChanges();
		}

		void AddVoceBilancio(object ID, string codbil){
            if (ID == DBNull.Value) return;
			if (DS.fin.Select(QHC.CmpEq("idfin", ID)).Length>0)return;
			DataRow NewBil = DS.fin.NewRow();
			NewBil["idfin"]=ID;
			NewBil["codefin"]=codbil;
			DS.fin.Rows.Add(NewBil);
			NewBil.AcceptChanges();
		}

		void AddVociCollegate(DataRow SP_Row){
			AddVoceBilancio(SP_Row["idfin"], 
				SP_Row["codefin"].ToString());
		}

		private void btnEseguiTutte_Click(object sender, System.EventArgs e) {
			if (DS.incomeview.Rows.Count==0) return;
            for (int i = 0; i < DS.Tables["incomeview"].Rows.Count; i++) dgrMovEntrata.Select(i);
            DS.creditpart.Clear();
            bool doSave = true;
			foreach (DataRow R in DS.incomeview.Rows){
                if (!CallStoredProcedure(R))
                    doSave = false;      
			}
            btnDoSave.Enabled = doSave;
		 
		}

        private void dgrMovEntrata_Click(object sender, EventArgs e)
        {
            DS.creditpart.Clear();
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
