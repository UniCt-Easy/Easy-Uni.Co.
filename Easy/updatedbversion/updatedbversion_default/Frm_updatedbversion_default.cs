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

namespace updatedbversion_default//updatedbversion//
{
	/// <summary>
	/// Summary description for frmupdatedbversion.
	/// </summary>
	public class Frm_updatedbversion_default : System.Windows.Forms.Form
	{
		public /*Rana:updatedbversion.*/vistaForm DS;
		private System.Windows.Forms.ImageList images;
		private System.ComponentModel.IContainer components;
        private GroupBox groupBox2;
        private Button btnModifica;
        private DataGrid gridScript;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private CheckBox chlFlagErrore;
        private CheckBox chkFlagAdmin;
        private TextBox txtScriptList;
        private TextBox txtDescription;
        private TextBox txtVersioneSW;
        private TextBox txtVersionname;
        private MetaData Meta;

		public Frm_updatedbversion_default()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			DS.updatedbversion.ExtendedProperties["sort_by"] = "versionname DESC";
		 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_updatedbversion_default));
            this.DS = new updatedbversion_default.vistaForm();
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnModifica = new System.Windows.Forms.Button();
            this.gridScript = new System.Windows.Forms.DataGrid();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chlFlagErrore = new System.Windows.Forms.CheckBox();
            this.chkFlagAdmin = new System.Windows.Forms.CheckBox();
            this.txtScriptList = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtVersioneSW = new System.Windows.Forms.TextBox();
            this.txtVersionname = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridScript)).BeginInit();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // images
            // 
            this.images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("images.ImageStream")));
            this.images.TransparentColor = System.Drawing.Color.Transparent;
            this.images.Images.SetKeyName(0, "");
            this.images.Images.SetKeyName(1, "");
            this.images.Images.SetKeyName(2, "");
            this.images.Images.SetKeyName(3, "");
            this.images.Images.SetKeyName(4, "");
            this.images.Images.SetKeyName(5, "");
            this.images.Images.SetKeyName(6, "");
            this.images.Images.SetKeyName(7, "");
            this.images.Images.SetKeyName(8, "");
            this.images.Images.SetKeyName(9, "");
            this.images.Images.SetKeyName(10, "");
            this.images.Images.SetKeyName(11, "");
            this.images.Images.SetKeyName(12, "");
            this.images.Images.SetKeyName(13, "");
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnModifica);
            this.groupBox2.Controls.Add(this.gridScript);
            this.groupBox2.Location = new System.Drawing.Point(21, 131);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(524, 208);
            this.groupBox2.TabIndex = 49;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Script";
            // 
            // btnModifica
            // 
            this.btnModifica.Location = new System.Drawing.Point(72, 16);
            this.btnModifica.Name = "btnModifica";
            this.btnModifica.Size = new System.Drawing.Size(75, 23);
            this.btnModifica.TabIndex = 12;
            this.btnModifica.Tag = "edit.default";
            this.btnModifica.Text = "Dettagli";
            // 
            // gridScript
            // 
            this.gridScript.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridScript.CaptionVisible = false;
            this.gridScript.DataMember = "";
            this.gridScript.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridScript.Location = new System.Drawing.Point(8, 48);
            this.gridScript.Name = "gridScript";
            this.gridScript.Size = new System.Drawing.Size(508, 152);
            this.gridScript.TabIndex = 10;
            this.gridScript.Tag = "updatedbscript.default.default";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(13, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 40);
            this.label4.TabIndex = 53;
            this.label4.Text = "Script eseguiti per questa versione";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(13, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 52;
            this.label3.Text = "Descrizione";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(213, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 16);
            this.label2.TabIndex = 51;
            this.label2.Text = "Versione del Software supportata";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 50;
            this.label1.Text = "Versione DB";
            // 
            // chlFlagErrore
            // 
            this.chlFlagErrore.Location = new System.Drawing.Point(109, 95);
            this.chlFlagErrore.Name = "chlFlagErrore";
            this.chlFlagErrore.Size = new System.Drawing.Size(104, 32);
            this.chlFlagErrore.TabIndex = 47;
            this.chlFlagErrore.Tag = "updatedbversion.flagerror:1:0";
            this.chlFlagErrore.Text = "Versione errata";
            // 
            // chkFlagAdmin
            // 
            this.chkFlagAdmin.Enabled = false;
            this.chkFlagAdmin.Location = new System.Drawing.Point(357, 95);
            this.chkFlagAdmin.Name = "chkFlagAdmin";
            this.chkFlagAdmin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkFlagAdmin.Size = new System.Drawing.Size(144, 32);
            this.chkFlagAdmin.TabIndex = 48;
            this.chkFlagAdmin.Tag = "updatedbversion.flagadmin:1:0";
            this.chkFlagAdmin.Text = "Diritti di amministratore";
            // 
            // txtScriptList
            // 
            this.txtScriptList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtScriptList.Location = new System.Drawing.Point(109, 55);
            this.txtScriptList.Multiline = true;
            this.txtScriptList.Name = "txtScriptList";
            this.txtScriptList.ReadOnly = true;
            this.txtScriptList.Size = new System.Drawing.Size(436, 40);
            this.txtScriptList.TabIndex = 46;
            this.txtScriptList.Tag = "updatedbversion.scriptlist";
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(109, 31);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(436, 20);
            this.txtDescription.TabIndex = 45;
            this.txtDescription.Tag = "updatedbversion.description";
            // 
            // txtVersioneSW
            // 
            this.txtVersioneSW.Location = new System.Drawing.Point(389, 7);
            this.txtVersioneSW.Name = "txtVersioneSW";
            this.txtVersioneSW.ReadOnly = true;
            this.txtVersioneSW.Size = new System.Drawing.Size(104, 20);
            this.txtVersioneSW.TabIndex = 44;
            this.txtVersioneSW.Tag = "updatedbversion.swversion";
            // 
            // txtVersionname
            // 
            this.txtVersionname.Location = new System.Drawing.Point(109, 7);
            this.txtVersionname.Name = "txtVersionname";
            this.txtVersionname.ReadOnly = true;
            this.txtVersionname.Size = new System.Drawing.Size(88, 20);
            this.txtVersionname.TabIndex = 43;
            this.txtVersionname.Tag = "updatedbversion.versionname";
            // 
            // Frm_updatedbversion_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(550, 354);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chlFlagErrore);
            this.Controls.Add(this.chkFlagAdmin);
            this.Controls.Add(this.txtScriptList);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtVersioneSW);
            this.Controls.Add(this.txtVersionname);
            this.Name = "Frm_updatedbversion_default";
            this.Text = "frmupdatedbversion";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridScript)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
		    var disp = this.getInstance<ISecurity>();
		    object  isAdmin = disp.GetSys("IsSystemAdmin") ;
		    if (isAdmin != null) {
		        if ((bool) (isAdmin) == false) {
		            Meta.canCancel = false;
		            Meta.canSave = false;
		        }
		    }

			//serve per poter eliminare righe da tabelle con campo text
            Meta.Conn.AddExtendedProperty(DS.updatedbscript);
		}
	}
}
