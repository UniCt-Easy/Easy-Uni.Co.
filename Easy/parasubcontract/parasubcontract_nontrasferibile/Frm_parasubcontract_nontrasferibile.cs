
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

namespace parasubcontract_nontrasferibile {//contratto_nontrasferibile//
	/// <summary>
	/// Summary description for frmcontratto_nontrasferibile.
	/// </summary>
	public class Frm_parasubcontract_nontrasferibile : MetaDataForm {
		public vistaForm DS;
		private System.Windows.Forms.Button btnExcel;
		private System.Windows.Forms.Button btnChiudi;
		public System.Windows.Forms.GroupBox MetaDataDetail;
		MetaData Meta;
		private System.Windows.Forms.DataGrid dgContratto;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_parasubcontract_nontrasferibile() {
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
			this.DS = new vistaForm();
			this.dgContratto = new System.Windows.Forms.DataGrid();
			this.btnExcel = new System.Windows.Forms.Button();
			this.btnChiudi = new System.Windows.Forms.Button();
			this.MetaDataDetail = new System.Windows.Forms.GroupBox();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgContratto)).BeginInit();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dgContratto
			// 
			this.dgContratto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dgContratto.CaptionVisible = false;
			this.dgContratto.DataMember = "";
			this.dgContratto.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgContratto.Location = new System.Drawing.Point(8, 24);
			this.dgContratto.Name = "dgContratto";
			this.dgContratto.Size = new System.Drawing.Size(576, 320);
			this.dgContratto.TabIndex = 0;
			// 
			// btnExcel
			// 
			this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnExcel.Location = new System.Drawing.Point(8, 360);
			this.btnExcel.Name = "btnExcel";
			this.btnExcel.TabIndex = 1;
			this.btnExcel.Text = "Excel";
			this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
			// 
			// btnChiudi
			// 
			this.btnChiudi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnChiudi.Location = new System.Drawing.Point(504, 360);
			this.btnChiudi.Name = "btnChiudi";
			this.btnChiudi.TabIndex = 2;
			this.btnChiudi.Text = "Chiudi";
			this.btnChiudi.Click += new System.EventHandler(this.btnChiudi_Click);
			// 
			// MetaDataDetail
			// 
			this.MetaDataDetail.Location = new System.Drawing.Point(120, 352);
			this.MetaDataDetail.Name = "MetaDataDetail";
			this.MetaDataDetail.Size = new System.Drawing.Size(200, 32);
			this.MetaDataDetail.TabIndex = 3;
			this.MetaDataDetail.TabStop = false;
			this.MetaDataDetail.Visible = false;
			// 
			// frmcontratto_nontrasferibile
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(592, 390);
			this.Controls.Add(this.MetaDataDetail);
			this.Controls.Add(this.btnChiudi);
			this.Controls.Add(this.btnExcel);
			this.Controls.Add(this.dgContratto);
			this.Name = "frmcontratto_nontrasferibile";
			this.Text = "frmcontratto_nontrasferibile";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgContratto)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

        QueryHelper QHS;
        CQueryHelper QHC;
        int esercizio;
		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
            esercizio = (int)Meta.GetSys("esercizio");
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();

			Meta.CanCancel = false;
			Meta.CanInsert = false;
			Meta.CanInsertCopy = false;
			Meta.SearchEnabled = false;
			riempiContrattoNonTrasferibile();
		}

		private void riempiContrattoNonTrasferibile() {
			int eserciziosucc = esercizio + 1;
			string sortContratti = "idcon";
			string filtraContrattiNT = QHS.AppAnd(QHS.CmpLe("ycon",esercizio),
                QHS.CmpEq("ycon",esercizio))+
				" AND NOT EXISTS(SELECT * FROM parasubcontractyear WHERE (ayear = " +
				QHS.quote(eserciziosucc) + " ) AND (parasubcontractview.idcon = parasubcontractyear.idcon)) " +
				" AND ((SELECT COUNT(*) FROM payroll WHERE "+
                QHS.AppAnd(QHS.CmpEq("fiscalyear",esercizio),QHS.IsNull("disbursementdate"),
                    QHS.CmpEq("flagbalance","S"),"(parasubcontractview.idcon = payroll.idcon)")+
                ") > 0)";
			DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn,DS.parasubcontractview,sortContratti,filtraContrattiNT,null,false);

			foreach(DataRow drContratto in DS.parasubcontractview.Rows) {
				drContratto["!causa"] = "Cedolino di conguaglio Non Erogato";
			}

			assegnaCaption();

			if (dgContratto.DataSource == null) {
				HelpForm.SetDataGrid(dgContratto,DS.parasubcontractview);
				new formatgrids(dgContratto).AutosizeColumnWidth();
			}
		}

		private void assegnaCaption() {
			foreach(DataColumn C in DS.parasubcontractview.Columns) {
				C.Caption = "";
			}
			DS.parasubcontractview.Columns["ycon"].Caption = "Eserc. Contratto";
			DS.parasubcontractview.Columns["ncon"].Caption = "Num. Contratto";
			DS.parasubcontractview.Columns["registry"].Caption = "Percipiente";
			DS.parasubcontractview.Columns["!causa"].Caption = "Causa";
		}

		private void btnExcel_Click(object sender, System.EventArgs e) {
			string dataMember = dgContratto.DataMember;
			CurrencyManager cm = (CurrencyManager) dgContratto.BindingContext[DS, dataMember];
			DataView view = cm.List as DataView;
			DS.parasubcontractview.ExtendedProperties["ExcelSort"] = view.Sort;
			exportclass.DataTableToExcel(DS.parasubcontractview,true);
		}

		private void btnChiudi_Click(object sender, System.EventArgs e) {
			Close();
		}
	}
}
