
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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

namespace finmotivedetail_single
{
	/// <summary>
	/// Summary description for FrmfinmotiveDetail_single.
	/// </summary>
	public class FrmfinmotiveDetail_single : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox gboxBilancio;
		private System.Windows.Forms.TextBox txtDenominazioneBilancio;
		private System.Windows.Forms.TextBox txtCodiceBilancio;
		private System.Windows.Forms.Button btnBilancio;
		private System.Windows.Forms.Button btnAnnulla;
		private System.Windows.Forms.Button btnOK;
		MetaData Meta;
        public finmotivedetail_single.vistaForm DS;
        public RadioButton rdbEntrata;
        public RadioButton rdbSpesa;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmfinmotiveDetail_single()
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
            this.gboxBilancio = new System.Windows.Forms.GroupBox();
            this.rdbEntrata = new System.Windows.Forms.RadioButton();
            this.rdbSpesa = new System.Windows.Forms.RadioButton();
            this.txtDenominazioneBilancio = new System.Windows.Forms.TextBox();
            this.txtCodiceBilancio = new System.Windows.Forms.TextBox();
            this.btnBilancio = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.DS = new finmotivedetail_single.vistaForm();
            this.gboxBilancio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // gboxBilancio
            // 
            this.gboxBilancio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxBilancio.Controls.Add(this.rdbEntrata);
            this.gboxBilancio.Controls.Add(this.rdbSpesa);
            this.gboxBilancio.Controls.Add(this.txtDenominazioneBilancio);
            this.gboxBilancio.Controls.Add(this.txtCodiceBilancio);
            this.gboxBilancio.Controls.Add(this.btnBilancio);
            this.gboxBilancio.Location = new System.Drawing.Point(10, 8);
            this.gboxBilancio.Name = "gboxBilancio";
            this.gboxBilancio.Size = new System.Drawing.Size(396, 117);
            this.gboxBilancio.TabIndex = 14;
            this.gboxBilancio.TabStop = false;
            this.gboxBilancio.Tag = "AutoManage.txtCodiceBilancio.tree";
            this.gboxBilancio.Text = "Bilancio da movimentare";
            // 
            // rdbEntrata
            // 
            this.rdbEntrata.Checked = true;
            this.rdbEntrata.Location = new System.Drawing.Point(13, 25);
            this.rdbEntrata.Name = "rdbEntrata";
            this.rdbEntrata.Size = new System.Drawing.Size(64, 16);
            this.rdbEntrata.TabIndex = 5;
            this.rdbEntrata.TabStop = true;
            this.rdbEntrata.Tag = "finview.finpart:E?x";
            this.rdbEntrata.Text = "Entrata";
            this.rdbEntrata.CheckedChanged += new System.EventHandler(this.rdbEntrata_CheckedChanged);
            // 
            // rdbSpesa
            // 
            this.rdbSpesa.Location = new System.Drawing.Point(85, 17);
            this.rdbSpesa.Name = "rdbSpesa";
            this.rdbSpesa.Size = new System.Drawing.Size(64, 31);
            this.rdbSpesa.TabIndex = 6;
            this.rdbSpesa.Tag = "finview.finpart:S?x";
            this.rdbSpesa.Text = "Spesa";
            this.rdbSpesa.CheckedChanged += new System.EventHandler(this.rdbSpesa_CheckedChanged);
            // 
            // txtDenominazioneBilancio
            // 
            this.txtDenominazioneBilancio.Location = new System.Drawing.Point(136, 50);
            this.txtDenominazioneBilancio.Multiline = true;
            this.txtDenominazioneBilancio.Name = "txtDenominazioneBilancio";
            this.txtDenominazioneBilancio.ReadOnly = true;
            this.txtDenominazioneBilancio.Size = new System.Drawing.Size(254, 52);
            this.txtDenominazioneBilancio.TabIndex = 2;
            this.txtDenominazioneBilancio.TabStop = false;
            this.txtDenominazioneBilancio.Tag = "finview.title";
            // 
            // txtCodiceBilancio
            // 
            this.txtCodiceBilancio.Location = new System.Drawing.Point(8, 82);
            this.txtCodiceBilancio.Name = "txtCodiceBilancio";
            this.txtCodiceBilancio.Size = new System.Drawing.Size(120, 20);
            this.txtCodiceBilancio.TabIndex = 1;
            this.txtCodiceBilancio.Tag = "finview.codefin?x";
            // 
            // btnBilancio
            // 
            this.btnBilancio.Location = new System.Drawing.Point(8, 50);
            this.btnBilancio.Name = "btnBilancio";
            this.btnBilancio.Size = new System.Drawing.Size(120, 23);
            this.btnBilancio.TabIndex = 0;
            this.btnBilancio.Tag = "";
            this.btnBilancio.Text = "Bilancio";
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(224, 142);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 16;
            this.btnAnnulla.Text = "Annulla";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(120, 142);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 15;
            this.btnOK.Tag = "mainsave";
            this.btnOK.Text = "OK";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // FrmfinmotiveDetail_single
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnAnnulla;
            this.ClientSize = new System.Drawing.Size(416, 179);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gboxBilancio);
            this.Name = "FrmfinmotiveDetail_single";
            this.Text = "FrmfinmotiveDetail_single";
            this.gboxBilancio.ResumeLayout(false);
            this.gboxBilancio.PerformLayout();
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
			string filter = Meta.QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            string filterupb = QHS.CmpEq("idupb", "0001");

            filter = GetData.MergeFilters(filter, filterupb);
            GetData.SetStaticFilter(DS.finview, filter);

			GetData.SetStaticFilter(DS.finview,filter);
		}

        private void rdbEntrata_CheckedChanged(object sender, EventArgs e) {    
			if (rdbEntrata.Checked)
			{
                string filter = QHS.AppAnd(QHS.CmpEq("idupb", "0001"), QHS.CmpEq("finpart", "E"));
                DS.finview.ExtendedProperties[MetaData.ExtraParams] = filter;
                btnBilancio.Tag = "manage.finview.treeeupb." + filter; 
                gboxBilancio.Tag = "AutoManage.txtCodiceBilancio.treealle."+filter;
                Meta.SetAutoMode(gboxBilancio);
			}
			if (!Meta.DrawStateIsDone)return;
			DS.finview.Clear();
			if (Meta.IsEmpty) return;
		}

        private void rdbSpesa_CheckedChanged(object sender, EventArgs e) {
            if (rdbSpesa.Checked) {
                string filter = QHS.AppAnd(QHS.CmpEq("idupb", "0001"), QHS.CmpEq("finpart", "S"));
                DS.finview.ExtendedProperties[MetaData.ExtraParams] = filter;
                btnBilancio.Tag = "manage.finview.treesupb." + filter;
                gboxBilancio.Tag = "AutoManage.txtCodiceBilancio.treealls." + filter;
                Meta.SetAutoMode(gboxBilancio);
            }
            if (!Meta.DrawStateIsDone) return;
            DS.finview.Clear();
            if (Meta.IsEmpty) return;
        }

	}
}
