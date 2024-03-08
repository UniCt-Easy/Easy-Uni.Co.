
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

namespace epoperation_default
{
	/// <summary>
	/// Summary description for FrmAccMotive_default.
	/// </summary>
	public class FrmEPOperation_default : MetaDataForm
	{
		private System.Windows.Forms.ImageList icons;
		private System.Windows.Forms.Splitter splitter1;
		public System.Windows.Forms.TabControl MetaDataDetail;
		private System.Windows.Forms.TabPage tabPrincipale;
		private System.Windows.Forms.TextBox txtDenominazione;
		private System.Windows.Forms.Label lblDenominazione;
		private System.Windows.Forms.TextBox txtCodice;
		private System.Windows.Forms.Label lblCodice;
		private System.Windows.Forms.GroupBox gboxBilancio;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.ComponentModel.IContainer components;
		public epoperation_default.vistaForm DS;
        private ImageList imageList1;

		MetaData Meta;

		public FrmEPOperation_default()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

   //         DS.accmotiveepoperation.ExtendedProperties["ViewTable"]= DS.accmotiveapplied;
			//DS.accmotiveapplied.ExtendedProperties["RealTable"]= DS.accmotiveepoperation;

			//DS.accmotiveapplied.Columns["idepoperation"].ExtendedProperties["ViewSource"]="accmotiveepoperation.idaccmotive";
			//DS.accmotiveapplied.Columns["idaccmotive"].ExtendedProperties["ViewSource"]= "accmotiveepoperation.idaccmotive";

			//DS.accmotiveapplied.Columns["cu"].ExtendedProperties["ViewSource"]="accmotiveepoperation.cu";
			//DS.accmotiveapplied.Columns["ct"].ExtendedProperties["ViewSource"]="accmotiveepoperation.ct";
			//DS.accmotiveapplied.Columns["lu"].ExtendedProperties["ViewSource"]="accmotiveepoperation.lu";
			//DS.accmotiveapplied.Columns["lt"].ExtendedProperties["ViewSource"]="accmotiveepoperation.lt";


   //         DS.accmotiveapplied.Columns["motive"].ExtendedProperties["ViewSource"] = "accmotive.title";
			//DS.accmotiveapplied.Columns["codemotive"].ExtendedProperties["ViewSource"]= "accmotive.codemotive";
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEPOperation_default));
			this.icons = new System.Windows.Forms.ImageList(this.components);
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.MetaDataDetail = new System.Windows.Forms.TabControl();
			this.tabPrincipale = new System.Windows.Forms.TabPage();
			this.gboxBilancio = new System.Windows.Forms.GroupBox();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.txtDenominazione = new System.Windows.Forms.TextBox();
			this.lblDenominazione = new System.Windows.Forms.Label();
			this.txtCodice = new System.Windows.Forms.TextBox();
			this.lblCodice = new System.Windows.Forms.Label();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.DS = new epoperation_default.vistaForm();
			this.MetaDataDetail.SuspendLayout();
			this.tabPrincipale.SuspendLayout();
			this.gboxBilancio.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
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
			this.splitter1.Location = new System.Drawing.Point(0, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 379);
			this.splitter1.TabIndex = 4;
			this.splitter1.TabStop = false;
			// 
			// MetaDataDetail
			// 
			this.MetaDataDetail.Controls.Add(this.tabPrincipale);
			this.MetaDataDetail.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MetaDataDetail.ImageList = this.imageList1;
			this.MetaDataDetail.Location = new System.Drawing.Point(3, 0);
			this.MetaDataDetail.Name = "MetaDataDetail";
			this.MetaDataDetail.SelectedIndex = 0;
			this.MetaDataDetail.Size = new System.Drawing.Size(526, 379);
			this.MetaDataDetail.TabIndex = 5;
			// 
			// tabPrincipale
			// 
			this.tabPrincipale.Controls.Add(this.gboxBilancio);
			this.tabPrincipale.Controls.Add(this.txtDenominazione);
			this.tabPrincipale.Controls.Add(this.lblDenominazione);
			this.tabPrincipale.Controls.Add(this.txtCodice);
			this.tabPrincipale.Controls.Add(this.lblCodice);
			this.tabPrincipale.Location = new System.Drawing.Point(4, 23);
			this.tabPrincipale.Name = "tabPrincipale";
			this.tabPrincipale.Size = new System.Drawing.Size(518, 352);
			this.tabPrincipale.TabIndex = 0;
			this.tabPrincipale.Text = "Principale";
			this.tabPrincipale.UseVisualStyleBackColor = true;
			// 
			// gboxBilancio
			// 
			this.gboxBilancio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxBilancio.Controls.Add(this.dataGrid1);
			this.gboxBilancio.Location = new System.Drawing.Point(16, 128);
			this.gboxBilancio.Name = "gboxBilancio";
			this.gboxBilancio.Size = new System.Drawing.Size(494, 213);
			this.gboxBilancio.TabIndex = 22;
			this.gboxBilancio.TabStop = false;
			this.gboxBilancio.Text = "Causali associate";
			// 
			// dataGrid1
			// 
			this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(6, 24);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(480, 181);
			this.dataGrid1.TabIndex = 22;
			this.dataGrid1.Tag = "accmotiveepoperation.lista";
			// 
			// txtDenominazione
			// 
			this.txtDenominazione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDenominazione.Location = new System.Drawing.Point(16, 80);
			this.txtDenominazione.Multiline = true;
			this.txtDenominazione.Name = "txtDenominazione";
			this.txtDenominazione.Size = new System.Drawing.Size(494, 42);
			this.txtDenominazione.TabIndex = 4;
			this.txtDenominazione.Tag = "epoperation.title";
			// 
			// lblDenominazione
			// 
			this.lblDenominazione.Location = new System.Drawing.Point(8, 56);
			this.lblDenominazione.Name = "lblDenominazione";
			this.lblDenominazione.Size = new System.Drawing.Size(88, 24);
			this.lblDenominazione.TabIndex = 18;
			this.lblDenominazione.Text = "Denominazione:";
			this.lblDenominazione.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtCodice
			// 
			this.txtCodice.Location = new System.Drawing.Point(16, 32);
			this.txtCodice.Name = "txtCodice";
			this.txtCodice.Size = new System.Drawing.Size(160, 20);
			this.txtCodice.TabIndex = 1;
			this.txtCodice.Tag = "epoperation.idepoperation";
			// 
			// lblCodice
			// 
			this.lblCodice.Location = new System.Drawing.Point(16, 8);
			this.lblCodice.Name = "lblCodice";
			this.lblCodice.Size = new System.Drawing.Size(56, 24);
			this.lblCodice.TabIndex = 15;
			this.lblCodice.Text = "Codice:";
			this.lblCodice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "");
			this.imageList1.Images.SetKeyName(1, "");
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// FrmEPOperation_default
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(529, 379);
			this.Controls.Add(this.MetaDataDetail);
			this.Controls.Add(this.splitter1);
			this.Name = "FrmEPOperation_default";
			this.Text = "FrmEPOperation_default";
			this.MetaDataDetail.ResumeLayout(false);
			this.tabPrincipale.ResumeLayout(false);
			this.tabPrincipale.PerformLayout();
			this.gboxBilancio.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public void MetaData_AfterLink(){
			Meta= MetaData.GetMetaData(this);

            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
            Meta.CanCancel = false;
            Meta.CanSave = false;

        }

       
	}
}
