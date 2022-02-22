
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

namespace Install
{
	/// <summary>
	/// Summary description for FrmErrore.
	/// </summary>
	public class FrmErrore : MetaDataForm
	{
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Label labelErrore;
		private System.Windows.Forms.Label lblDomanda;
		private System.Windows.Forms.Button btnSi;
		private System.Windows.Forms.Button btnNo;
		private System.Windows.Forms.Button btnAnnulla;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		DataTable T;


		public FrmErrore(DataRow[] righeErrate, string messaggio, string[,] colonne) 
			: this(copiaTabella(righeErrate, colonne), messaggio) {
		}

		public FrmErrore(DataTable tDest, string messaggioIniziale) 
			: this(tDest, messaggioIniziale, null) {
		}

		public FrmErrore(DataTable tDest, string messaggioIniziale, string domanda) {
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			labelErrore.Text = messaggioIniziale;
			new DataSet().Tables.Add(tDest);
			HelpForm.SetDataGrid(dataGrid1, tDest);
			lblDomanda.Text = domanda;
			if (domanda == null) {
				btnSi.Text = "Ok";
				btnNo.Visible = false;
			}
			this.T=tDest;
		}

		private static DataTable copiaTabella(DataRow[] righeErrate, string[,] colonne) {
			DataTable tSorg = righeErrate[0].Table;
			DataTable tDest = new DataSet().Tables.Add();

			for (int i=0; i<colonne.GetLength(0); i++) {
				DataColumn c = tDest.Columns.Add(colonne[i,0], tSorg.Columns[colonne[i,0]].DataType);
				c.Caption = colonne[i,1];
			}
			foreach (DataRow r in righeErrate) {
				DataRow rBNC = tDest.NewRow();
				foreach (DataColumn c in tDest.Columns) {
					rBNC[c] = r[c.ColumnName];
				}
				tDest.Rows.Add(rBNC);
			}
			return tDest;
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
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.btnSi = new System.Windows.Forms.Button();
			this.btnNo = new System.Windows.Forms.Button();
			this.labelErrore = new System.Windows.Forms.Label();
			this.lblDomanda = new System.Windows.Forms.Label();
			this.btnAnnulla = new System.Windows.Forms.Button();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGrid1
			// 
			this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid1.ContextMenu = this.contextMenu1;
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(8, 32);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(720, 288);
			this.dataGrid1.TabIndex = 0;
			// 
			// btnSi
			// 
			this.btnSi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSi.DialogResult = System.Windows.Forms.DialogResult.Yes;
			this.btnSi.Location = new System.Drawing.Point(544, 328);
			this.btnSi.Name = "btnSi";
			this.btnSi.Size = new System.Drawing.Size(56, 23);
			this.btnSi.TabIndex = 1;
			this.btnSi.Text = "Si";
			// 
			// btnNo
			// 
			this.btnNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNo.DialogResult = System.Windows.Forms.DialogResult.No;
			this.btnNo.Location = new System.Drawing.Point(608, 328);
			this.btnNo.Name = "btnNo";
			this.btnNo.Size = new System.Drawing.Size(56, 23);
			this.btnNo.TabIndex = 2;
			this.btnNo.Text = "No";
			// 
			// labelErrore
			// 
			this.labelErrore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.labelErrore.Location = new System.Drawing.Point(8, 8);
			this.labelErrore.Name = "labelErrore";
			this.labelErrore.Size = new System.Drawing.Size(720, 23);
			this.labelErrore.TabIndex = 3;
			this.labelErrore.Text = "label1";
			// 
			// lblDomanda
			// 
			this.lblDomanda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lblDomanda.Location = new System.Drawing.Point(8, 320);
			this.lblDomanda.Name = "lblDomanda";
			this.lblDomanda.Size = new System.Drawing.Size(536, 40);
			this.lblDomanda.TabIndex = 4;
			this.lblDomanda.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnAnnulla.Location = new System.Drawing.Point(672, 328);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.Size = new System.Drawing.Size(56, 23);
			this.btnAnnulla.TabIndex = 5;
			this.btnAnnulla.Text = "Annulla";
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.Text = "Excel";
			this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
			// 
			// FrmErrore
			// 
			this.AcceptButton = this.btnSi;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnAnnulla;
			this.ClientSize = new System.Drawing.Size(736, 358);
			this.Controls.Add(this.dataGrid1);
			this.Controls.Add(this.btnAnnulla);
			this.Controls.Add(this.lblDomanda);
			this.Controls.Add(this.labelErrore);
			this.Controls.Add(this.btnNo);
			this.Controls.Add(this.btnSi);
			this.Name = "FrmErrore";
			this.Text = "Errore!";
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void menuItem1_Click(object sender, System.EventArgs e) {
			exportclass.DataTableToExcel(T,true);
		}
	}
}
