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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using System.Data;

namespace sorting_treeall//classmovimentiselect//
{
	/// <summary>
	/// Descrizione di riepilogo per frmClassMovimentiSelect.
	/// </summary>
	public class Frm_sorting_treeall : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.ImageList icons;
		private System.Windows.Forms.DataGrid dataGrid1;
		public System.Windows.Forms.TreeView tree;
		public /*Rana:classmovimentiselect.*/vistaForm DS;
		public System.Windows.Forms.Button MetaDataDetail;
		private System.Windows.Forms.Button btnCancel;
		private System.ComponentModel.IContainer components;

		public Frm_sorting_treeall()
		{
			//
			// Necessario per il supporto di Progettazione Windows Form
			//
			InitializeComponent();

			//
			// TODO: aggiungere il codice del costruttore dopo la chiamata a InitializeComponent.
			//
		}

		/// <summary>
		/// Pulire le risorse in uso.
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
			DataTable FilterTable =  MetaData.GetMetaData(this).ExtraParameter as DataTable;
			if (FilterTable!=null){
				HelpForm.SetFilterToTree(DS.sorting, FilterTable);
				//DS.classmovimenti.ExtendedProperties[HelpForm.FilterTree] = FilterTable;
				if (FilterTable.Rows.Count==0) return;
				DataRow OneRow = FilterTable.Rows[0];
				string filtercodice= "(codicetipoclass='"+OneRow["codicetipoclass"].ToString()+"')";				
				GetData.CacheTable(DS.sortinglevel,filtercodice,null,false);
			}
			else {
				object filter=MetaData.GetMetaData(this).ExtraParameter;
				string f=null;
				if (filter!=null) f=filter.ToString();
				GetData.CacheTable(DS.sortinglevel,f,null,false);
			}
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Metodo necessario per il supporto della finestra di progettazione. Non modificare
		/// il contenuto del metodo con l'editor di codice.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmClassMovimentiSelect));
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.icons = new System.Windows.Forms.ImageList(this.components);
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.tree = new System.Windows.Forms.TreeView();
			this.MetaDataDetail = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.DS = new /*Rana:classmovimentiselect.*/vistaForm();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
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
			this.dataGrid1.Location = new System.Drawing.Point(216, 0);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(496, 376);
			this.dataGrid1.TabIndex = 2;
			this.dataGrid1.Tag = "TreeNavigator.tree";
			// 
			// tree
			// 
			this.tree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.tree.HideSelection = false;
			this.tree.ImageIndex = 1;
			this.tree.ImageList = this.icons;
			this.tree.Location = new System.Drawing.Point(8, 0);
			this.tree.Name = "tree";
			this.tree.ShowPlusMinus = false;
			this.tree.Size = new System.Drawing.Size(200, 376);
			this.tree.TabIndex = 3;
			this.tree.Tag = "sorting.tree";
			// 
			// MetaDataDetail
			// 
			this.MetaDataDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.MetaDataDetail.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.MetaDataDetail.Location = new System.Drawing.Point(520, 384);
			this.MetaDataDetail.Name = "MetaDataDetail";
			this.MetaDataDetail.TabIndex = 4;
			this.MetaDataDetail.Tag = "mainselect";
			this.MetaDataDetail.Text = "Ok";
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(632, 384);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Cancel";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// frmClassMovimentiSelect
			// 
			this.AcceptButton = this.MetaDataDetail;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(728, 421);
			this.Controls.Add(this.MetaDataDetail);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.tree);
			this.Controls.Add(this.dataGrid1);
			this.Name = "frmClassMovimentiSelect";
			this.Text = "frmClassMovimentiSelect";
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
	}
}
