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

namespace assetusage_dettaglioquota//DettUtilizzoCarico//
{
	/// <summary>
	/// Summary description for rfmDettUtilizzoCarico.
	/// </summary>
	public class Frm_assetusage_dettaglioquota : System.Windows.Forms.Form
	{
		public vistaForm DS;
		private System.Windows.Forms.GroupBox grpTipo;
		private System.Windows.Forms.ComboBox cboTipo;
		private System.Windows.Forms.GroupBox grpQuota;
		private System.Windows.Forms.TextBox txtQuota;
		private System.Windows.Forms.Button btnAnnulla;
		private System.Windows.Forms.Button btnOK;
        private CheckBox chkTransmitted;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_assetusage_dettaglioquota()
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
            this.DS = new assetusage_dettaglioquota.vistaForm();
            this.grpTipo = new System.Windows.Forms.GroupBox();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.grpQuota = new System.Windows.Forms.GroupBox();
            this.txtQuota = new System.Windows.Forms.TextBox();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.chkTransmitted = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.grpTipo.SuspendLayout();
            this.grpQuota.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // grpTipo
            // 
            this.grpTipo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpTipo.Controls.Add(this.cboTipo);
            this.grpTipo.Location = new System.Drawing.Point(16, 8);
            this.grpTipo.Name = "grpTipo";
            this.grpTipo.Size = new System.Drawing.Size(288, 48);
            this.grpTipo.TabIndex = 4;
            this.grpTipo.TabStop = false;
            this.grpTipo.Text = "Tipo";
            // 
            // cboTipo
            // 
            this.cboTipo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTipo.DataSource = this.DS.assetusagekind;
            this.cboTipo.DisplayMember = "description";
            this.cboTipo.Location = new System.Drawing.Point(32, 16);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(240, 21);
            this.cboTipo.TabIndex = 1;
            this.cboTipo.Tag = "assetusage.idassetusagekind.(active=\'S\')";
            this.cboTipo.ValueMember = "idassetusagekind";
            // 
            // grpQuota
            // 
            this.grpQuota.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpQuota.Controls.Add(this.txtQuota);
            this.grpQuota.Location = new System.Drawing.Point(16, 64);
            this.grpQuota.Name = "grpQuota";
            this.grpQuota.Size = new System.Drawing.Size(139, 48);
            this.grpQuota.TabIndex = 5;
            this.grpQuota.TabStop = false;
            this.grpQuota.Text = "Quota";
            // 
            // txtQuota
            // 
            this.txtQuota.Location = new System.Drawing.Point(32, 16);
            this.txtQuota.Name = "txtQuota";
            this.txtQuota.Size = new System.Drawing.Size(80, 20);
            this.txtQuota.TabIndex = 2;
            this.txtQuota.Tag = "assetusage.usagequota.fixed.2..%.100";
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(168, 128);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 4;
            this.btnAnnulla.Text = "Annulla";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(80, 128);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Tag = "mainsave";
            this.btnOK.Text = "OK";
            // 
            // chkTransmitted
            // 
            this.chkTransmitted.AutoSize = true;
            this.chkTransmitted.Location = new System.Drawing.Point(172, 84);
            this.chkTransmitted.Name = "chkTransmitted";
            this.chkTransmitted.Size = new System.Drawing.Size(77, 17);
            this.chkTransmitted.TabIndex = 6;
            this.chkTransmitted.Tag = "assetusage.transmitted:S:N";
            this.chkTransmitted.Text = "Trasmesso";
            this.chkTransmitted.UseVisualStyleBackColor = true;
            // 
            // Frm_assetusage_dettaglioquota
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnAnnulla;
            this.ClientSize = new System.Drawing.Size(314, 167);
            this.Controls.Add(this.chkTransmitted);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.grpQuota);
            this.Controls.Add(this.grpTipo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Frm_assetusage_dettaglioquota";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.grpTipo.ResumeLayout(false);
            this.grpQuota.ResumeLayout(false);
            this.grpQuota.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

	}
}
