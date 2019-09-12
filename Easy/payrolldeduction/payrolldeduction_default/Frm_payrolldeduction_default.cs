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

namespace payrolldeduction_default {//dettagliodeduzionecedolino//
	/// <summary>
	/// Summary description for frmdettagliodeduzionecedolino.
	/// </summary>
	public class Frm_payrolldeduction_default : System.Windows.Forms.Form {
		public vistaForm DS;
		MetaData Meta;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox2;
		string filteresercizio;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_payrolldeduction_default() {
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.DS = new payrolldeduction_default.vistaForm();
			this.label1 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.button1 = new System.Windows.Forms.Button();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.TabIndex = 0;
			this.label1.Text = "Tipo Deduzione";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// comboBox1
			// 
			this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.comboBox1.DataSource = this.DS.deductioncode;
			this.comboBox1.DisplayMember = "description";
			this.comboBox1.Location = new System.Drawing.Point(128, 16);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(344, 21);
			this.comboBox1.TabIndex = 1;
			this.comboBox1.Tag = "payrolldeduction.iddeduction";
			this.comboBox1.ValueMember = "iddeduction";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(8, 48);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(112, 23);
			this.button1.TabIndex = 2;
			this.button1.Tag = "manage.taxablekind.default";
			this.button1.Text = "Tipo Imponibile";
			// 
			// comboBox2
			// 
			this.comboBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.comboBox2.DataSource = this.DS.taxablekind;
			this.comboBox2.DisplayMember = "description";
			this.comboBox2.Location = new System.Drawing.Point(128, 48);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(344, 21);
			this.comboBox2.TabIndex = 3;
			this.comboBox2.Tag = "payrolldeduction.taxablecode";
			this.comboBox2.ValueMember = "taxablecode";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 80);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(112, 23);
			this.label2.TabIndex = 4;
			this.label2.Text = "Importo Annuo";
			this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(128, 80);
			this.textBox1.Name = "textBox1";
			this.textBox1.TabIndex = 5;
			this.textBox1.Tag = "payrolldeduction.annualamount";
			this.textBox1.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 112);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(112, 23);
			this.label3.TabIndex = 6;
			this.label3.Text = "Importo Corrente";
			this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(128, 112);
			this.textBox2.Name = "textBox2";
			this.textBox2.TabIndex = 7;
			this.textBox2.Tag = "payrolldeduction.curramount";
			this.textBox2.Text = "";
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(280, 168);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 9;
			this.btnCancel.Text = "Annulla";
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(104, 168);
			this.btnOk.Name = "btnOk";
			this.btnOk.TabIndex = 8;
			this.btnOk.Tag = "mainsave";
			this.btnOk.Text = "Ok";
			// 
			// Frm_payrolldeduction_default
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(480, 206);
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
			this.Name = "Frm_payrolldeduction_default";
			this.Text = "frmdettagliodeduzionecedolino";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
		
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
			GetData.CacheTable(DS.taxablekind,filteresercizio,null,true);
			GetData.CacheTable(DS.deductioncode,filteresercizio,null,true);
		}
	}
}