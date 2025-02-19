
/*
Easy
Copyright (C) 2024 UniversitÓ degli Studi di Catania (www.unict.it)
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

namespace locationview_tree//UbicazioneViewTree//
{
	/// <summary>
	/// Summary description for frmUbicazioneViewTree.
	/// </summary>
	public class Frm_locationview_tree : MetaDataForm
	{
		public System.Windows.Forms.Button btnok;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.DataGrid dataGrid1;
		public System.Windows.Forms.TreeView tree;
		public vistaForm DS;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.ImageList icons;
		private System.ComponentModel.IContainer components;
        MetaData Meta;
        public GroupBox MetaDataDetail;
        DataAccess Conn;

		public Frm_locationview_tree()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_locationview_tree));
            this.btnok = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.tree = new System.Windows.Forms.TreeView();
            this.icons = new System.Windows.Forms.ImageList(this.components);
            this.DS = new locationview_tree.vistaForm();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.MetaDataDetail = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.MetaDataDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnok
            // 
            this.btnok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnok.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnok.Location = new System.Drawing.Point(461, 371);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(75, 23);
            this.btnok.TabIndex = 14;
            this.btnok.Tag = "mainselect";
            this.btnok.Text = "Ok";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(557, 371);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(6, 19);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(641, 322);
            this.dataGrid1.TabIndex = 13;
            this.dataGrid1.Tag = "TreeNavigator.tree";
            // 
            // tree
            // 
            this.tree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tree.HideSelection = false;
            this.tree.ImageIndex = 1;
            this.tree.ImageList = this.icons;
            this.tree.Location = new System.Drawing.Point(8, 16);
            this.tree.Name = "tree";
            this.tree.SelectedImageIndex = 0;
            this.tree.ShowPlusMinus = false;
            this.tree.Size = new System.Drawing.Size(301, 394);
            this.tree.TabIndex = 12;
            this.tree.Tag = "locationview.tree";
            // 
            // icons
            // 
            this.icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("icons.ImageStream")));
            this.icons.TransparentColor = System.Drawing.Color.Transparent;
            this.icons.Images.SetKeyName(0, "");
            this.icons.Images.SetKeyName(1, "");
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // MetaDataDetail
            // 
            this.MetaDataDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MetaDataDetail.Controls.Add(this.dataGrid1);
            this.MetaDataDetail.Controls.Add(this.btnok);
            this.MetaDataDetail.Controls.Add(this.btnCancel);
            this.MetaDataDetail.Location = new System.Drawing.Point(316, 16);
            this.MetaDataDetail.Name = "MetaDataDetail";
            this.MetaDataDetail.Size = new System.Drawing.Size(653, 400);
            this.MetaDataDetail.TabIndex = 16;
            this.MetaDataDetail.TabStop = false;
            this.MetaDataDetail.Text = "Ubicazione";
            // 
            // Frm_locationview_tree
            // 
            this.AcceptButton = this.btnok;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(978, 428);
            this.Controls.Add(this.MetaDataDetail);
            this.Controls.Add(this.tree);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Frm_locationview_tree";
            this.Text = "frmUbicazioneViewTree";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.MetaDataDetail.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

        QueryHelper QHS;
		public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHS = Conn.GetQueryHelper();
			GetData.CacheTable(DS.locationlevel);
            GetData.SetStaticFilter(DS.locationview,QHS.CmpEq("active","S"));
		    tree.Tag = "locationview." + Meta.edit_type;


		}
	}
}
