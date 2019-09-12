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

namespace customgroupoperation_print//customgroupprint//
{
	/// <summary>
	/// Summary description for frmCustomGroupPrint.
	/// </summary>
	public class Frm_customgroupoperation_print : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtBoxConsenti;
		private System.Windows.Forms.TextBox txtBoxDivieto;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rdbVieta;
		private System.Windows.Forms.RadioButton rdbConsenti;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		public vistaForm DS;
		public MetaData Meta;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_customgroupoperation_print()
		{
			InitializeComponent();
			DS.customgroupoperation.Columns["allowcondition"].ExtendedProperties["sqltype"] = "text";
			DS.customgroupoperation.Columns["denycondition"].ExtendedProperties["sqltype"] = "text";
		}

		public void MetaData_AfterLink(){
			Meta = MetaData.GetMetaData(this);
			MetaData.SetDefault(DS.customgroupoperation, "operation","P");
			GetData.SetStaticFilter(DS.customgroupoperation,"(operation='P')");
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
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.DS = new customgroupoperation_print.vistaForm();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtBoxConsenti = new System.Windows.Forms.TextBox();
			this.txtBoxDivieto = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rdbVieta = new System.Windows.Forms.RadioButton();
			this.rdbConsenti = new System.Windows.Forms.RadioButton();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// comboBox2
			// 
			this.comboBox2.DataSource = this.DS.customgroup;
			this.comboBox2.DisplayMember = "description";
			this.comboBox2.Location = new System.Drawing.Point(16, 64);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(408, 21);
			this.comboBox2.TabIndex = 29;
			this.comboBox2.Tag = "customgroupoperation.idgroup";
			this.comboBox2.ValueMember = "idcustomgroup";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// comboBox1
			// 
			this.comboBox1.DataSource = this.DS.report;
			this.comboBox1.DisplayMember = "description";
			this.comboBox1.Location = new System.Drawing.Point(16, 24);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(528, 21);
			this.comboBox1.TabIndex = 20;
			this.comboBox1.Tag = "customgroupoperation.tablename";
			this.comboBox1.ValueMember = "reportname";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(20, 134);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(128, 16);
			this.label4.TabIndex = 28;
			this.label4.Text = "Condizione di consenti:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(20, 254);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(120, 16);
			this.label1.TabIndex = 27;
			this.label1.Text = "Condizione di divieto:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtBoxConsenti
			// 
			this.txtBoxConsenti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtBoxConsenti.Location = new System.Drawing.Point(148, 134);
			this.txtBoxConsenti.Multiline = true;
			this.txtBoxConsenti.Name = "txtBoxConsenti";
			this.txtBoxConsenti.Size = new System.Drawing.Size(400, 96);
			this.txtBoxConsenti.TabIndex = 23;
			this.txtBoxConsenti.Tag = "customgroupoperation.allowcondition";
			this.txtBoxConsenti.Text = "";
			// 
			// txtBoxDivieto
			// 
			this.txtBoxDivieto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtBoxDivieto.Location = new System.Drawing.Point(148, 254);
			this.txtBoxDivieto.Multiline = true;
			this.txtBoxDivieto.Name = "txtBoxDivieto";
			this.txtBoxDivieto.Size = new System.Drawing.Size(400, 96);
			this.txtBoxDivieto.TabIndex = 24;
			this.txtBoxDivieto.Tag = "customgroupoperation.denycondition";
			this.txtBoxDivieto.Text = "";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.rdbVieta);
			this.groupBox1.Controls.Add(this.rdbConsenti);
			this.groupBox1.Location = new System.Drawing.Point(448, 56);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(104, 72);
			this.groupBox1.TabIndex = 22;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Default";
			// 
			// rdbVieta
			// 
			this.rdbVieta.Location = new System.Drawing.Point(16, 24);
			this.rdbVieta.Name = "rdbVieta";
			this.rdbVieta.Size = new System.Drawing.Size(72, 16);
			this.rdbVieta.TabIndex = 0;
			this.rdbVieta.Tag = "customgroupoperation.defaultisdeny:S";
			this.rdbVieta.Text = "Vieta";
			// 
			// rdbConsenti
			// 
			this.rdbConsenti.Location = new System.Drawing.Point(16, 48);
			this.rdbConsenti.Name = "rdbConsenti";
			this.rdbConsenti.Size = new System.Drawing.Size(72, 16);
			this.rdbConsenti.TabIndex = 1;
			this.rdbConsenti.Tag = "customgroupoperation.defaultisdeny:N";
			this.rdbConsenti.Text = "Consenti";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(88, 16);
			this.label3.TabIndex = 26;
			this.label3.Text = "Nome report:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 16);
			this.label2.TabIndex = 25;
			this.label2.Text = "Gruppo:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// Frm_customgroupoperation_print
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(560, 357);
			this.Controls.Add(this.comboBox2);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtBoxConsenti);
			this.Controls.Add(this.txtBoxDivieto);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Name = "Frm_customgroupoperation_print";
			this.Text = "frmCustomGroupPrint";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
	}
}
