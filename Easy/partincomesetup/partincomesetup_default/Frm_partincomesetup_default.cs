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
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;

namespace partincomesetup_default//ripassegnazione//
{
	/// <summary>
	/// Summary description for frmripassegnazione.
	/// </summary>
	/// <remarks>Revised by Nino on 19/12/2002
	/// </remarks>
	public class Frm_partincomesetup_default : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox grpBilancioEntrata;
		private System.Windows.Forms.TextBox txtDescrBilancioEntrata;
		private System.Windows.Forms.TextBox txtBilancioEntrata;
		private System.Windows.Forms.Button btnBilancioEntrata;
		private System.Windows.Forms.GroupBox grpBilancioSpesa;
		private System.Windows.Forms.TextBox txtDescrBilancioSpesa;
		private System.Windows.Forms.TextBox txtBilancioSpesa;
		private System.Windows.Forms.Button btnBilancioSpesa;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtPercentuale;
		public vistaForm DS;
		private System.ComponentModel.IContainer components;
		MetaData Meta;
		private System.Windows.Forms.ImageList imageList1;

		public Frm_partincomesetup_default()
		{
			InitializeComponent();
			DataAccess.SetTableForReading(DS.fin1,"fin");
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Frm_partincomesetup_default));
			this.grpBilancioEntrata = new System.Windows.Forms.GroupBox();
			this.txtDescrBilancioEntrata = new System.Windows.Forms.TextBox();
			this.txtBilancioEntrata = new System.Windows.Forms.TextBox();
			this.btnBilancioEntrata = new System.Windows.Forms.Button();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.grpBilancioSpesa = new System.Windows.Forms.GroupBox();
			this.txtDescrBilancioSpesa = new System.Windows.Forms.TextBox();
			this.txtBilancioSpesa = new System.Windows.Forms.TextBox();
			this.btnBilancioSpesa = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtPercentuale = new System.Windows.Forms.TextBox();
			this.DS = new partincomesetup_default.vistaForm();
			this.grpBilancioEntrata.SuspendLayout();
			this.grpBilancioSpesa.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// grpBilancioEntrata
			// 
			this.grpBilancioEntrata.Controls.Add(this.txtDescrBilancioEntrata);
			this.grpBilancioEntrata.Controls.Add(this.txtBilancioEntrata);
			this.grpBilancioEntrata.Controls.Add(this.btnBilancioEntrata);
			this.grpBilancioEntrata.Location = new System.Drawing.Point(16, 16);
			this.grpBilancioEntrata.Name = "grpBilancioEntrata";
			this.grpBilancioEntrata.Size = new System.Drawing.Size(288, 80);
			this.grpBilancioEntrata.TabIndex = 1;
			this.grpBilancioEntrata.TabStop = false;
			this.grpBilancioEntrata.Tag = "AutoManage.txtBilancioEntrata.treeE";
			this.grpBilancioEntrata.Text = "Voce di bilancio di entrata";
			// 
			// txtDescrBilancioEntrata
			// 
			this.txtDescrBilancioEntrata.Location = new System.Drawing.Point(128, 16);
			this.txtDescrBilancioEntrata.Multiline = true;
			this.txtDescrBilancioEntrata.Name = "txtDescrBilancioEntrata";
			this.txtDescrBilancioEntrata.ReadOnly = true;
			this.txtDescrBilancioEntrata.Size = new System.Drawing.Size(152, 56);
			this.txtDescrBilancioEntrata.TabIndex = 54;
			this.txtDescrBilancioEntrata.TabStop = false;
			this.txtDescrBilancioEntrata.Tag = "fin.title";
			this.txtDescrBilancioEntrata.Text = "";
			// 
			// txtBilancioEntrata
			// 
			this.txtBilancioEntrata.Location = new System.Drawing.Point(8, 48);
			this.txtBilancioEntrata.Name = "txtBilancioEntrata";
			this.txtBilancioEntrata.Size = new System.Drawing.Size(104, 20);
			this.txtBilancioEntrata.TabIndex = 52;
			this.txtBilancioEntrata.Tag = "fin.codefin?partincomesetupview.finincomecode";
			this.txtBilancioEntrata.Text = "";
			// 
			// btnBilancioEntrata
			// 
			this.btnBilancioEntrata.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnBilancioEntrata.ImageIndex = 0;
			this.btnBilancioEntrata.ImageList = this.imageList1;
			this.btnBilancioEntrata.Location = new System.Drawing.Point(8, 16);
			this.btnBilancioEntrata.Name = "btnBilancioEntrata";
			this.btnBilancioEntrata.Size = new System.Drawing.Size(104, 24);
			this.btnBilancioEntrata.TabIndex = 62;
			this.btnBilancioEntrata.TabStop = false;
			this.btnBilancioEntrata.Tag = "manage.fin.treeE";
			this.btnBilancioEntrata.Text = "Bilancio:";
			this.btnBilancioEntrata.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// grpBilancioSpesa
			// 
			this.grpBilancioSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.grpBilancioSpesa.Controls.Add(this.txtDescrBilancioSpesa);
			this.grpBilancioSpesa.Controls.Add(this.txtBilancioSpesa);
			this.grpBilancioSpesa.Controls.Add(this.btnBilancioSpesa);
			this.grpBilancioSpesa.Location = new System.Drawing.Point(312, 16);
			this.grpBilancioSpesa.Name = "grpBilancioSpesa";
			this.grpBilancioSpesa.Size = new System.Drawing.Size(288, 80);
			this.grpBilancioSpesa.TabIndex = 2;
			this.grpBilancioSpesa.TabStop = false;
			this.grpBilancioSpesa.Tag = "AutoManage.txtBilancioSpesa.treeS";
			this.grpBilancioSpesa.Text = "Voce di bilancio di spesa";
			// 
			// txtDescrBilancioSpesa
			// 
			this.txtDescrBilancioSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescrBilancioSpesa.Location = new System.Drawing.Point(128, 16);
			this.txtDescrBilancioSpesa.Multiline = true;
			this.txtDescrBilancioSpesa.Name = "txtDescrBilancioSpesa";
			this.txtDescrBilancioSpesa.ReadOnly = true;
			this.txtDescrBilancioSpesa.Size = new System.Drawing.Size(152, 56);
			this.txtDescrBilancioSpesa.TabIndex = 54;
			this.txtDescrBilancioSpesa.TabStop = false;
			this.txtDescrBilancioSpesa.Tag = "fin1.title";
			this.txtDescrBilancioSpesa.Text = "";
			// 
			// txtBilancioSpesa
			// 
			this.txtBilancioSpesa.Location = new System.Drawing.Point(8, 48);
			this.txtBilancioSpesa.Name = "txtBilancioSpesa";
			this.txtBilancioSpesa.Size = new System.Drawing.Size(104, 20);
			this.txtBilancioSpesa.TabIndex = 52;
			this.txtBilancioSpesa.Tag = "fin1.codefin?partincomesetupview.finexpensecode";
			this.txtBilancioSpesa.Text = "";
			// 
			// btnBilancioSpesa
			// 
			this.btnBilancioSpesa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnBilancioSpesa.ImageIndex = 0;
			this.btnBilancioSpesa.ImageList = this.imageList1;
			this.btnBilancioSpesa.Location = new System.Drawing.Point(8, 16);
			this.btnBilancioSpesa.Name = "btnBilancioSpesa";
			this.btnBilancioSpesa.Size = new System.Drawing.Size(104, 24);
			this.btnBilancioSpesa.TabIndex = 62;
			this.btnBilancioSpesa.TabStop = false;
			this.btnBilancioSpesa.Tag = "manage.fin1.treeS";
			this.btnBilancioSpesa.Text = "Bilancio:";
			this.btnBilancioSpesa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point(360, 104);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(160, 16);
			this.label1.TabIndex = 72;
			this.label1.Text = "Percentuale di assegnazione:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtPercentuale
			// 
			this.txtPercentuale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPercentuale.Location = new System.Drawing.Point(528, 104);
			this.txtPercentuale.Name = "txtPercentuale";
			this.txtPercentuale.Size = new System.Drawing.Size(72, 20);
			this.txtPercentuale.TabIndex = 3;
			this.txtPercentuale.Tag = "partincomesetup.percentage.fixed.4..%.100?partincomesetupview.percentage.fixed.4." +
				".%.100";
			this.txtPercentuale.Text = "";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// Frm_partincomesetup_default
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(602, 128);
			this.Controls.Add(this.txtPercentuale);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.grpBilancioSpesa);
			this.Controls.Add(this.grpBilancioEntrata);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "Frm_partincomesetup_default";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmripassegnazione";
			this.grpBilancioEntrata.ResumeLayout(false);
			this.grpBilancioSpesa.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
        
        CQueryHelper QHC;
        QueryHelper QHS;
		public void MetaData_AfterLink(){
			Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();

			string filteresercizio= QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
			GetData.SetStaticFilter(DS.fin, QHS.AppAnd(filteresercizio, QHS.BitClear("flag", 0)));
            GetData.SetStaticFilter(DS.fin1, QHS.AppAnd(filteresercizio, QHS.BitSet("flag", 0)));
		}
	}
}