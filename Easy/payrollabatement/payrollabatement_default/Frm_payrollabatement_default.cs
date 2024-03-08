
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

namespace payrollabatement_default {//dettagliodetrazionecedolino//
	/// <summary>
	/// Summary description for frmdettagliodetrazionecedolino.
	/// </summary>
	public class Frm_payrollabatement_default : MetaDataForm {
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label1;
		MetaData Meta;
		string filteresercizio;
		public vistaForm DS;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_payrollabatement_default() {
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

		private void rendiDiSolaLettura(Control control) {
			foreach (Control c in control.Controls) {
				if (c.HasChildren) {
					rendiDiSolaLettura(c);
				} 
				else {
					TextBox t = c as TextBox;
					if (t != null) {
						t.ReadOnly = true;
					}

					RadioButton rb = c as RadioButton;
					if (rb != null) {
						rb.Enabled = false;
					}

					ComboBox cb = c as ComboBox;
					if (cb != null) {
						cb.Enabled = false;
					}

					Button b = c as Button;
					if ((b != null) && (b != btnOk) && (b != btnCancel)) {
						b.Enabled = false;
					}
				}
			}
		}

		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
			if (Meta.edit_type=="readonly") {
				Meta.CanSave = false;
				rendiDiSolaLettura(this);
			}
			filteresercizio = Meta.QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
			GetData.CacheTable(DS.abatementcode,filteresercizio,null,true);
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.DS = new payrollabatement_default.vistaForm();
			this.button1 = new System.Windows.Forms.Button();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(80, 168);
			this.btnOk.Name = "btnOk";
			this.btnOk.TabIndex = 5;
			this.btnOk.Tag = "mainsave";
			this.btnOk.Text = "Ok";
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(232, 168);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 6;
			this.btnCancel.Text = "Annulla";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(136, 112);
			this.textBox2.Name = "textBox2";
			this.textBox2.TabIndex = 4;
			this.textBox2.Tag = "payrollabatement.curramount";
			this.textBox2.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 112);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(112, 23);
			this.label3.TabIndex = 16;
			this.label3.Text = "Importo Corrente";
			this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(136, 80);
			this.textBox1.Name = "textBox1";
			this.textBox1.TabIndex = 3;
			this.textBox1.Tag = "payrollabatement.annualamount";
			this.textBox1.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 80);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(112, 23);
			this.label2.TabIndex = 14;
			this.label2.Text = "Importo Annuo";
			this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// comboBox2
			// 
			this.comboBox2.DataSource = this.DS.tax;
			this.comboBox2.DisplayMember = "description";
			this.comboBox2.Location = new System.Drawing.Point(136, 48);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(232, 21);
			this.comboBox2.TabIndex = 2;
			this.comboBox2.Tag = "payrollabatement.taxcode";
			this.comboBox2.ValueMember = "taxcode";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(16, 48);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(112, 23);
			this.button1.TabIndex = 12;
			this.button1.TabStop = false;
			this.button1.Tag = "manage.tax.default";
			this.button1.Text = "Tipo Ritenuta";
			// 
			// comboBox1
			// 
			this.comboBox1.DataSource = this.DS.abatementcode;
			this.comboBox1.DisplayMember = "description";
			this.comboBox1.Location = new System.Drawing.Point(136, 16);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(232, 21);
			this.comboBox1.TabIndex = 1;
			this.comboBox1.Tag = "payrollabatement.idabatement";
			this.comboBox1.ValueMember = "idabatement";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 16);
			this.label1.Name = "label1";
			this.label1.TabIndex = 10;
			this.label1.Text = "Tipo Detrazione";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// Frm_payrollabatement_default
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(384, 206);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.comboBox2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.label1);
			this.Name = "Frm_payrollabatement_default";
			this.Text = "frmdettagliodetrazionecedolino";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
	}
}
