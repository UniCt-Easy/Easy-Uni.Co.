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

namespace account_tree {
	/// <summary>
	/// Summary description for Frm_account_tree.
	/// </summary>
	public class Frm_account_tree : System.Windows.Forms.Form {
		MetaData Meta;
        public TabControl MetaDataDetail;
        private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button btnCancel;
		public System.Windows.Forms.Button btnOk;
		public System.Windows.Forms.TreeView tree;
		public account_tree.vistaForm DS;
		private System.Windows.Forms.ImageList icons;
		private System.Windows.Forms.Splitter splitter1;
		private System.ComponentModel.IContainer components;

		public Frm_account_tree() {
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

		public void MetaData_AfterLink(){
            Meta = MetaData.GetMetaData(this);
            string param = Meta.ExtraParameter as string;
		    QueryHelper q = Meta.QHS;
            string filterEsercizio = q.CmpEq("ayear", Meta.GetSys("esercizio"));
            string filter = GetData.MergeFilters(filterEsercizio, param);
            string oldfilter = GetData.MergeFilters(null, DS.accountlevel);
            if (oldfilter != null) GetData.SetStaticFilter(DS.accountlevel, filter);
            GetData.CacheTable(DS.accountlevel);
            if (Meta.edit_type != "treenew")
            {
                // Filtro su esercizio deve funzionare acnhe su altri eercizi.
                GetData.SetStaticFilter(DS.account, filter);
            }
            else {
                tree.Tag = "account.treenew";
            }
		    if (Meta.edit_type == "treeminusable") {
		        string filterenablebudgetprev = q.NullOrEq("flagenablebudgetprev", "S");
		        GetData.SetStaticFilter(DS.account,q.AppAnd(filter,filterenablebudgetprev));
                tree.Tag = "account.treeminusable";
                dataGrid1.Tag = "TreeNavigator.treeminusable";
		    }
            GetData.SetSorting(DS.account, "printingorder");
		}

		public void MetaData_AfterActivation() {
			if (tree.Nodes.Count > 0) {
				if (!tree.Nodes[0].IsExpanded) {
					tree.Nodes[0].Expand();
				}
			}
		}


		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_account_tree));
            this.DS = new account_tree.vistaForm();
            this.MetaDataDetail = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.tree = new System.Windows.Forms.TreeView();
            this.icons = new System.Windows.Forms.ImageList(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.MetaDataDetail.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // MetaDataDetail
            // 
            this.MetaDataDetail.Controls.Add(this.tabPage1);
            this.MetaDataDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MetaDataDetail.Location = new System.Drawing.Point(294, 0);
            this.MetaDataDetail.Name = "MetaDataDetail";
            this.MetaDataDetail.SelectedIndex = 0;
            this.MetaDataDetail.Size = new System.Drawing.Size(603, 405);
            this.MetaDataDetail.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGrid1);
            this.tabPage1.Controls.Add(this.btnCancel);
            this.tabPage1.Controls.Add(this.btnOk);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(595, 379);
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
            this.dataGrid1.Size = new System.Drawing.Size(579, 312);
            this.dataGrid1.TabIndex = 2;
            this.dataGrid1.Tag = "TreeNavigator.tree";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(515, 349);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Annulla";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOk.Location = new System.Drawing.Point(419, 349);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Tag = "mainselect";
            this.btnOk.Text = "Ok";
            // 
            // tree
            // 
            this.tree.Dock = System.Windows.Forms.DockStyle.Left;
            this.tree.HideSelection = false;
            this.tree.ImageIndex = 0;
            this.tree.ImageList = this.icons;
            this.tree.Location = new System.Drawing.Point(0, 0);
            this.tree.Name = "tree";
            this.tree.SelectedImageIndex = 0;
            this.tree.ShowPlusMinus = false;
            this.tree.Size = new System.Drawing.Size(294, 405);
            this.tree.TabIndex = 9;
            this.tree.Tag = "account.tree";
            // 
            // icons
            // 
            this.icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("icons.ImageStream")));
            this.icons.TransparentColor = System.Drawing.Color.Transparent;
            this.icons.Images.SetKeyName(0, "");
            this.icons.Images.SetKeyName(1, "");
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(294, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 405);
            this.splitter1.TabIndex = 11;
            this.splitter1.TabStop = false;
            // 
            // Frm_account_tree
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(897, 405);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.MetaDataDetail);
            this.Controls.Add(this.tree);
            this.Name = "Frm_account_tree";
            this.Text = "Frm_account_tree";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.MetaDataDetail.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
	}
}