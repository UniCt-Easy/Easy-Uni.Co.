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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using System.Data;


namespace placcount_tree
{
	/// <summary>
	/// Summary description for Frm_placcount_tree.
	/// </summary>
	public class Frm_placcount_tree : System.Windows.Forms.Form
	{
		public System.Windows.Forms.TreeView tree;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button btnCancel;
		public System.Windows.Forms.Button MetaDataDetail;
		public placcount_tree.vistaForm DS;
		MetaData Meta;
		private System.Windows.Forms.ImageList icons;
		private System.ComponentModel.IContainer components;

		public Frm_placcount_tree()
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

		public void MetaData_AfterLink(){
			Meta= MetaData.GetMetaData(this);
            string param = Meta.ExtraParameter as string;
			string filterEsercizio=Meta.QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            string filter = GetData.MergeFilters(filterEsercizio, param);
            string oldfilter = GetData.MergeFilters(null, DS.placcountlevel);
            if (oldfilter != null) GetData.SetStaticFilter(DS.placcountlevel, filter);
			GetData.CacheTable(DS.placcountlevel);
            if (Meta.edit_type != "treecnew" && Meta.edit_type != "treernew")
            {
                // Filtro su esercizio deve funzionare acnhe su altri eercizi.
                GetData.SetStaticFilter(DS.placcount, filter);
            }
		}

//		public void MetaData_AfterActivation() {
//			if (tree.Nodes.Count > 0) {
//				if (!tree.Nodes[0].IsExpanded) {
//					tree.Nodes[0].Expand();
//				}
//			}
//		}
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_placcount_tree));
            this.tree = new System.Windows.Forms.TreeView();
            this.icons = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.btnCancel = new System.Windows.Forms.Button();
            this.MetaDataDetail = new System.Windows.Forms.Button();
            this.DS = new placcount_tree.vistaForm();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // tree
            // 
            this.tree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tree.HideSelection = false;
            this.tree.ImageIndex = 0;
            this.tree.ImageList = this.icons;
            this.tree.Location = new System.Drawing.Point(0, 0);
            this.tree.Name = "tree";
            this.tree.SelectedImageIndex = 0;
            this.tree.ShowPlusMinus = false;
            this.tree.Size = new System.Drawing.Size(375, 405);
            this.tree.TabIndex = 2;
            this.tree.Tag = "placcount.tree";
            // 
            // icons
            // 
            this.icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("icons.ImageStream")));
            this.icons.TransparentColor = System.Drawing.Color.Transparent;
            this.icons.Images.SetKeyName(0, "");
            this.icons.Images.SetKeyName(1, "");
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(377, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(490, 405);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGrid1);
            this.tabPage1.Controls.Add(this.btnCancel);
            this.tabPage1.Controls.Add(this.MetaDataDetail);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(482, 379);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Dettaglio";
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(8, 16);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(466, 312);
            this.dataGrid1.TabIndex = 2;
            this.dataGrid1.Tag = "TreeNavigator.tree";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(402, 349);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Annulla";
            // 
            // MetaDataDetail
            // 
            this.MetaDataDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.MetaDataDetail.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.MetaDataDetail.Location = new System.Drawing.Point(306, 349);
            this.MetaDataDetail.Name = "MetaDataDetail";
            this.MetaDataDetail.Size = new System.Drawing.Size(75, 23);
            this.MetaDataDetail.TabIndex = 4;
            this.MetaDataDetail.Tag = "mainselect";
            this.MetaDataDetail.Text = "Ok";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // Frm_placcount_tree
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(867, 405);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.tree);
            this.Name = "Frm_placcount_tree";
            this.Text = "Frm_placcount_tree";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
	}
}
