
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

namespace sorting_tree//classmovimentiselect//
{
	/// <summary>
	/// Descrizione di riepilogo per frmClassMovimentiSelect.
	/// </summary>
	public class Frm_sorting_tree : MetaDataForm
	{
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.ImageList icons;
		private System.Windows.Forms.DataGrid dataGrid1;
		public System.Windows.Forms.TreeView tree;
		public vistaForm DS;
		public System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
        public GroupBox MetaDataDetail;
        private Splitter splitter1;
		private System.ComponentModel.IContainer components;

		public Frm_sorting_tree()
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
        QueryHelper QHS;
		public void MetaData_AfterLink(){
			DataTable FilterTable =  MetaData.GetMetaData(this).ExtraParameter as DataTable;
            MetaData Meta = MetaData.GetMetaData(this);
            int esercizio = (int)Meta.GetSys("esercizio");
            QHS = Meta.Conn.GetQueryHelper();
		    Meta.CanInsert = false;
		    Meta.CanInsertCopy = false;
		    Meta.CanCancel = false;
		    Meta.CanSave = false;
			if (FilterTable!=null){
				//DS.classmovimenti.ExtendedProperties[HelpForm.FilterTree] = FilterTable;
                if (FilterTable.Rows.Count == 0) {
                    HelpForm.SetFilterToTree(DS.sorting, FilterTable);
                    return;
                }
				DataRow OneRow = FilterTable.Rows[0];
                string filtercodice = QHS.CmpEq("idsorkind", OneRow["idsorkind"]);
                GetData.CacheTable(DS.sortinglevel, filtercodice, null, false);
                FilterTable.ExtendedProperties["idsorkindFilter"] = filtercodice;
                HelpForm.SetFilterToTree(DS.sorting, FilterTable);
			}
			else {
				object filter=MetaData.GetMetaData(this).ExtraParameter;
				string f=null;
				if (filter!=null) f=filter.ToString();
				GetData.CacheTable(DS.sortinglevel,f,null,false);
                GetData.SetStaticFilter(DS.sorting,
                    QHS.AppAnd(QHS.NullOrLe("start", Meta.GetSys("esercizio")),
                            QHS.NullOrGe("stop", Meta.GetSys("esercizio"))));
			}
		    if (Meta.edit_type == "tree5") {
		        tree.Tag = "sorting.tree5";
		        //DataGrid.Tag = "TreeNavigator.tree5";
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_sorting_tree));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.icons = new System.Windows.Forms.ImageList(this.components);
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.tree = new System.Windows.Forms.TreeView();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.DS = new sorting_tree.vistaForm();
            this.MetaDataDetail = new System.Windows.Forms.GroupBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.MetaDataDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // icons
            // 
            this.icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("icons.ImageStream")));
            this.icons.TransparentColor = System.Drawing.Color.Transparent;
            this.icons.Images.SetKeyName(0, "");
            this.icons.Images.SetKeyName(1, "");
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(9, 12);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(556, 365);
            this.dataGrid1.TabIndex = 2;
            this.dataGrid1.Tag = "TreeNavigator.tree";
            // 
            // tree
            // 
            this.tree.Dock = System.Windows.Forms.DockStyle.Left;
            this.tree.HideSelection = false;
            this.tree.ImageIndex = 1;
            this.tree.ImageList = this.icons;
            this.tree.Location = new System.Drawing.Point(0, 0);
            this.tree.Name = "tree";
            this.tree.SelectedImageIndex = 0;
            this.tree.ShowPlusMinus = false;
            this.tree.Size = new System.Drawing.Size(332, 421);
            this.tree.TabIndex = 3;
            this.tree.Tag = "sorting.tree";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOk.Location = new System.Drawing.Point(387, 383);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Tag = "mainselect";
            this.btnOk.Text = "Ok";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(490, 383);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Annulla";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // MetaDataDetail
            // 
            this.MetaDataDetail.Controls.Add(this.dataGrid1);
            this.MetaDataDetail.Controls.Add(this.btnOk);
            this.MetaDataDetail.Controls.Add(this.btnCancel);
            this.MetaDataDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MetaDataDetail.Location = new System.Drawing.Point(332, 0);
            this.MetaDataDetail.Name = "MetaDataDetail";
            this.MetaDataDetail.Size = new System.Drawing.Size(571, 421);
            this.MetaDataDetail.TabIndex = 6;
            this.MetaDataDetail.TabStop = false;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(332, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 421);
            this.splitter1.TabIndex = 7;
            this.splitter1.TabStop = false;
            // 
            // Frm_sorting_tree
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(903, 421);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.MetaDataDetail);
            this.Controls.Add(this.tree);
            this.Name = "Frm_sorting_tree";
            this.Text = "frmClassMovimentiSelect";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.MetaDataDetail.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
	}
}
