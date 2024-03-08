
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

namespace inventorytreeview_tree//ClassInventarioViewTree//
{
	/// <summary>
	/// Summary description for frmClassInventarioViewTree.
	/// </summary>
	public class Frm_inventorytreeview_tree : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.DataGrid dataGrid1;
		public System.Windows.Forms.Button MetaDataDetail;
		private System.Windows.Forms.Button btnCancel;
		public System.Windows.Forms.TreeView tree;
		private System.Windows.Forms.ImageList icons;
		public vistaForm DS;
		private System.ComponentModel.IContainer components;

		public Frm_inventorytreeview_tree()
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Frm_inventorytreeview_tree));
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.tree = new System.Windows.Forms.TreeView();
			this.icons = new System.Windows.Forms.ImageList(this.components);
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.MetaDataDetail = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.DS = new inventorytreeview_tree.vistaForm();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// tree
			// 
			this.tree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.tree.HideSelection = false;
			this.tree.ImageIndex = 1;
			this.tree.ImageList = this.icons;
			this.tree.Location = new System.Drawing.Point(8, 8);
			this.tree.Name = "tree";
			this.tree.ShowPlusMinus = false;
			this.tree.Size = new System.Drawing.Size(256, 328);
			this.tree.TabIndex = 0;
			this.tree.Tag = "inventorytreeview.tree";
			// 
			// icons
			// 
			this.icons.ImageSize = new System.Drawing.Size(16, 16);
			this.icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("icons.ImageStream")));
			this.icons.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// dataGrid1
			// 
			this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(264, 8);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(424, 328);
			this.dataGrid1.TabIndex = 1;
			this.dataGrid1.Tag = "TreeNavigator.tree";
			// 
			// MetaDataDetail
			// 
			this.MetaDataDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.MetaDataDetail.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.MetaDataDetail.Location = new System.Drawing.Point(512, 344);
			this.MetaDataDetail.Name = "MetaDataDetail";
			this.MetaDataDetail.TabIndex = 10;
			this.MetaDataDetail.Tag = "mainselect";
			this.MetaDataDetail.Text = "Ok";
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(608, 344);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 11;
			this.btnCancel.Text = "Cancel";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// Frm_inventorytreeview_tree
			// 
			this.AcceptButton = this.MetaDataDetail;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(690, 383);
			this.Controls.Add(this.MetaDataDetail);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.dataGrid1);
			this.Controls.Add(this.tree);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Frm_inventorytreeview_tree";
			this.Text = "frmClassInventarioViewTree";
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public void MetaData_AfterLink() {
			GetData.CacheTable(DS.inventorysortinglevel);		
		}
	}
}
