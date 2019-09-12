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

namespace incomelinkedproceeds_default//dettentrateincassi//
{
	/// <summary>
	/// Summary description for FrmDettEntrateIncassi.
	/// </summary>
	public class Frm_incomelinkedproceeds_default : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Button btnEntrata;
		public  vistaForm DS;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_incomelinkedproceeds_default()
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
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.DS = new incomelinkedproceeds_default.vistaForm();
			this.btnEntrata = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(352, 80);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(80, 23);
			this.btnCancel.TabIndex = 17;
			this.btnCancel.Tag = "";
			this.btnCancel.Text = "Annulla";
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(264, 80);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 16;
			this.btnOK.Tag = "mainsave";
			this.btnOK.Text = "OK";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(72, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(46, 16);
			this.label1.TabIndex = 15;
			this.label1.Text = "Importo:";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(128, 48);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(120, 20);
			this.textBox1.TabIndex = 14;
			this.textBox1.Tag = "incomelinkedproceeds.amount";
			this.textBox1.Text = "";
			// 
			// comboBox1
			// 
			this.comboBox1.DataSource = this.DS.linkedincome;
			this.comboBox1.DisplayMember = "description";
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.Location = new System.Drawing.Point(128, 8);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(304, 21);
			this.comboBox1.TabIndex = 13;
			this.comboBox1.Tag = "incomelinkedproceeds.idlinkedincome";
			this.comboBox1.ValueMember = "idlinkedincome";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// btnEntrata
			// 
			this.btnEntrata.BackColor = System.Drawing.SystemColors.Control;
			this.btnEntrata.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnEntrata.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnEntrata.Location = new System.Drawing.Point(8, 8);
			this.btnEntrata.Name = "btnEntrata";
			this.btnEntrata.Size = new System.Drawing.Size(112, 23);
			this.btnEntrata.TabIndex = 12;
			this.btnEntrata.Tag = "manage.linkedincome.lista";
			this.btnEntrata.Text = "Entrata Collegata";
			// 
			// Frm_incomelinkedproceeds_default
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(440, 110);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.btnEntrata);
			this.Name = "Frm_incomelinkedproceeds_default";
			this.Text = "FrmDettEntrateIncassi";
			this.Load += new System.EventHandler(this.Frm_incomelinkedproceeds_default_Load);
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void Frm_incomelinkedproceeds_default_Load(object sender, System.EventArgs e) {
		
		}
	}
}
