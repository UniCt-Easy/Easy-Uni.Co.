
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


namespace parasubcontract_senzacedolini {//contratto_senzacedolini//
	/// <summary>
	/// Summary description for frmcontratto_senzacedolini.
	/// </summary>
	public class Frm_parasubcontract_senzacedolini : MetaDataForm {
		private System.Windows.Forms.DataGrid dgContratto;
		public vistaForm DS;
		MetaData Meta;
		private System.Windows.Forms.Button btnChiudi;
		private System.Windows.Forms.Button btnExcel;
		public System.Windows.Forms.GroupBox MetaDataDetail;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_parasubcontract_senzacedolini() {
			InitializeComponent();
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
			this.dgContratto = new System.Windows.Forms.DataGrid();
			this.btnChiudi = new System.Windows.Forms.Button();
			this.DS = new vistaForm();
			this.btnExcel = new System.Windows.Forms.Button();
			this.MetaDataDetail = new System.Windows.Forms.GroupBox();
			((System.ComponentModel.ISupportInitialize)(this.dgContratto)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// dgContratto
			// 
			this.dgContratto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dgContratto.CaptionVisible = false;
			this.dgContratto.DataMember = "";
			this.dgContratto.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgContratto.Location = new System.Drawing.Point(8, 16);
			this.dgContratto.Name = "dgContratto";
			this.dgContratto.Size = new System.Drawing.Size(432, 272);
			this.dgContratto.TabIndex = 0;
			// 
			// btnChiudi
			// 
			this.btnChiudi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnChiudi.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnChiudi.Location = new System.Drawing.Point(360, 304);
			this.btnChiudi.Name = "btnChiudi";
			this.btnChiudi.TabIndex = 2;
			this.btnChiudi.Text = "Chiudi";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// btnExcel
			// 
			this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnExcel.Location = new System.Drawing.Point(8, 304);
			this.btnExcel.Name = "btnExcel";
			this.btnExcel.TabIndex = 1;
			this.btnExcel.Text = "Excel";
			this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
			// 
			// MetaDataDetail
			// 
			this.MetaDataDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.MetaDataDetail.Location = new System.Drawing.Point(160, 296);
			this.MetaDataDetail.Name = "MetaDataDetail";
			this.MetaDataDetail.Size = new System.Drawing.Size(96, 24);
			this.MetaDataDetail.TabIndex = 3;
			this.MetaDataDetail.TabStop = false;
			this.MetaDataDetail.Visible = false;
			// 
			// frmcontratto_senzacedolini
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(448, 334);
			this.Controls.Add(this.MetaDataDetail);
			this.Controls.Add(this.btnExcel);
			this.Controls.Add(this.btnChiudi);
			this.Controls.Add(this.dgContratto);
			this.Name = "frmcontratto_senzacedolini";
			this.Text = "frmcontratto_senzacedolini";
			((System.ComponentModel.ISupportInitialize)(this.dgContratto)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
        QueryHelper QHS;
        CQueryHelper QHC;
        int esercizio;
		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            esercizio = (int)Meta.GetSys("esercizio");
			Esegui();
		}

		private void Esegui() {
			string filterCedolini = QHS.AppAnd(QHS.CmpEq("ayear",esercizio),
                "((SELECT COUNT(*) FROM payroll " +
				" WHERE "+QHS.AppAnd(QHS.CmpEq("fiscalyear",esercizio),QHS.CmpEq("flagbalance","S"),
                    " (parasubcontractview.idcon = payroll.idcon)")+
                " = 0)");

			DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn,DS.parasubcontractview,null,filterCedolini,null,false);
			
			if (DS.parasubcontractview.Rows.Count == 0) return;

			foreach (DataColumn C in DS.parasubcontractview.Columns) {
				C.Caption = "";
			}

			DS.parasubcontractview.Columns["ycon"].Caption = "Esercizio";
			DS.parasubcontractview.Columns["ncon"].Caption = "Numero";
			DS.parasubcontractview.Columns["registry"].Caption = "Percipiente";

			if (dgContratto.DataSource == null) {
				HelpForm.SetDataGrid(dgContratto,DS.parasubcontractview);
				new formatgrids(dgContratto).AutosizeColumnWidth();
			}
		}

		private void btnExcel_Click(object sender, System.EventArgs e) {
			string dataMember = dgContratto.DataMember;
			CurrencyManager cm = (CurrencyManager) dgContratto.BindingContext[DS, dataMember];
			DataView view = cm.List as DataView;
			DS.parasubcontractview.ExtendedProperties["ExcelSort"] = view.Sort;
			exportclass.DataTableToExcel(DS.parasubcontractview,true);
		}
	}
}
