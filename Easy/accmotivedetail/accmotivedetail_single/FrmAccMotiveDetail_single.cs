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

namespace accmotivedetail_single
{
	/// <summary>
	/// Summary description for FrmAccMotiveDetail_single.
	/// </summary>
	public class FrmAccMotiveDetail_single : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox gboxConto;
		private System.Windows.Forms.TextBox txtDenominazioneConto;
		private System.Windows.Forms.TextBox txtCodiceConto;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button btnAnnulla;
		private System.Windows.Forms.Button btnOK;
		MetaData Meta;
		public accmotivedetail_single.vistaForm DS;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmAccMotiveDetail_single()
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
			this.gboxConto = new System.Windows.Forms.GroupBox();
			this.txtDenominazioneConto = new System.Windows.Forms.TextBox();
			this.txtCodiceConto = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.btnAnnulla = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.DS = new accmotivedetail_single.vistaForm();
			this.gboxConto.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// gboxConto
			// 
			this.gboxConto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.gboxConto.Controls.Add(this.txtDenominazioneConto);
			this.gboxConto.Controls.Add(this.txtCodiceConto);
			this.gboxConto.Controls.Add(this.button1);
			this.gboxConto.Location = new System.Drawing.Point(8, 8);
			this.gboxConto.Name = "gboxConto";
			this.gboxConto.Size = new System.Drawing.Size(296, 72);
			this.gboxConto.TabIndex = 14;
			this.gboxConto.TabStop = false;
			this.gboxConto.Tag = "AutoManage.txtCodiceConto.tree";
			this.gboxConto.Text = "Conto da movimentare";
			// 
			// txtDenominazioneConto
			// 
			this.txtDenominazioneConto.Location = new System.Drawing.Point(136, 16);
			this.txtDenominazioneConto.Multiline = true;
			this.txtDenominazioneConto.Name = "txtDenominazioneConto";
			this.txtDenominazioneConto.ReadOnly = true;
			this.txtDenominazioneConto.Size = new System.Drawing.Size(152, 52);
			this.txtDenominazioneConto.TabIndex = 2;
			this.txtDenominazioneConto.TabStop = false;
			this.txtDenominazioneConto.Tag = "account.title";
			this.txtDenominazioneConto.Text = "";
			// 
			// txtCodiceConto
			// 
			this.txtCodiceConto.Location = new System.Drawing.Point(8, 48);
			this.txtCodiceConto.Name = "txtCodiceConto";
			this.txtCodiceConto.Size = new System.Drawing.Size(120, 20);
			this.txtCodiceConto.TabIndex = 1;
			this.txtCodiceConto.Tag = "account.codeacc?x";
			this.txtCodiceConto.Text = "";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(8, 16);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(120, 23);
			this.button1.TabIndex = 0;
			this.button1.Tag = "manage.account.tree";
			this.button1.Text = "Conto";
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnAnnulla.Location = new System.Drawing.Point(224, 96);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.TabIndex = 16;
			this.btnAnnulla.Text = "Annulla";
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(120, 96);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 15;
			this.btnOK.Tag = "mainsave";
			this.btnOK.Text = "OK";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// FrmAccMotiveDetail_single
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnAnnulla;
			this.ClientSize = new System.Drawing.Size(416, 133);
			this.Controls.Add(this.btnAnnulla);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.gboxConto);
			this.Name = "FrmAccMotiveDetail_single";
			this.Text = "FrmAccMotiveDetail_single";
			this.gboxConto.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public void MetaData_AfterLink(){
			Meta = MetaData.GetMetaData(this);
			string filter = Meta.QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
			GetData.SetStaticFilter(DS.account,filter);
		}
	}
}
