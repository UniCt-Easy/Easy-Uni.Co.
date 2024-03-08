
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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

namespace servicetrasmission_default
{
	/// <summary>
	/// Summary description for FrmError.
	/// </summary>
	public class FrmError : MetaDataForm
	{
		private System.Windows.Forms.Button btnOk;
		private DataGrid gridErrori;
		ContextMenu ExcelMenu;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmError(DataTable tError)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			DataSet dsApp = new DataSet();
			if (tError.DataSet == null) {
				dsApp.Tables.Add(tError);
			}
			HelpForm.SetDataGrid(gridErrori, tError);
			ExcelMenu = new ContextMenu();
			ExcelMenu.MenuItems.Add("Excel", new EventHandler(Excel_Click));
			gridErrori.ContextMenu = ExcelMenu;
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		private void Excel_Click(object menusender, EventArgs e) {
			if (menusender == null) return;
			if (!(typeof(MenuItem).IsAssignableFrom(menusender.GetType()))) return;
			object sender = ((MenuItem)menusender).Parent.GetContextMenu().SourceControl;
			if (!(typeof(DataGrid).IsAssignableFrom(sender.GetType()))) return;
			DataGrid G = (DataGrid)sender;
			object DDS = G.DataSource;
			if (DDS == null) return;
			if (!typeof(DataSet).IsAssignableFrom(DDS.GetType())) return;
			string DDT = G.DataMember;
			if (DDT == null) return;
			DataTable T = ((DataSet)DDS).Tables[DDT];
			if (T == null) return;
			exportclass.DataTableToExcel(T, true);
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
			this.btnOk = new System.Windows.Forms.Button();
			this.gridErrori = new System.Windows.Forms.DataGrid();
			((System.ComponentModel.ISupportInitialize)(this.gridErrori)).BeginInit();
			this.SuspendLayout();
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.Yes;
			this.btnOk.Location = new System.Drawing.Point(534, 337);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 0;
			this.btnOk.Text = "OK";
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// gridErrori
			// 
			this.gridErrori.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gridErrori.DataMember = "";
			this.gridErrori.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gridErrori.Location = new System.Drawing.Point(12, 12);
			this.gridErrori.Name = "gridErrori";
			this.gridErrori.Size = new System.Drawing.Size(597, 303);
			this.gridErrori.TabIndex = 31;
			this.gridErrori.Tag = "";
			// 
			// FrmError
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(631, 372);
			this.Controls.Add(this.gridErrori);
			this.Controls.Add(this.btnOk);
			this.Name = "FrmError";
			this.Text = "Errori Incarichi selezionati per la trasmissione";
			((System.ComponentModel.ISupportInitialize)(this.gridErrori)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void btnOk_Click(object sender, EventArgs e) {
			this.Close();
		}
	}
}
