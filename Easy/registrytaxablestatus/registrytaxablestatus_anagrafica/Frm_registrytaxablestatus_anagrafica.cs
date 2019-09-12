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

namespace registrytaxablestatus_anagrafica {//posretributivanagrafica//
	/// <summary>
	/// Summary description for frmposretributivanagrafica.
	/// </summary>
	public class Frm_registrytaxablestatus_anagrafica : System.Windows.Forms.Form {
		private System.Windows.Forms.GroupBox groupCredDeb;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtCreDeb;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtValidita;
		private System.Windows.Forms.TextBox textBox1;
		public /*Rana:posretributivanagrafica.*/vistaForm DS;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.GroupBox groupBox2;
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_registrytaxablestatus_anagrafica() {
			InitializeComponent();
			HelpForm.SetDenyNull(DS.registrytaxablestatus.Columns["active"], true);
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
			this.groupCredDeb = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtCreDeb = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.txtValidita = new System.Windows.Forms.TextBox();
			this.DS = new registrytaxablestatus_anagrafica.vistaForm();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupCredDeb.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupCredDeb
			// 
			this.groupCredDeb.Controls.Add(this.label4);
			this.groupCredDeb.Controls.Add(this.txtCreDeb);
			this.groupCredDeb.Location = new System.Drawing.Point(16, 8);
			this.groupCredDeb.Name = "groupCredDeb";
			this.groupCredDeb.Size = new System.Drawing.Size(464, 56);
			this.groupCredDeb.TabIndex = 1;
			this.groupCredDeb.TabStop = false;
			this.groupCredDeb.Tag = "AutoChoose.txtCreDeb.anagrafica.(active<>\'N\')";
			this.groupCredDeb.Text = "Anagrafica";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 26);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(104, 16);
			this.label4.TabIndex = 1;
			this.label4.Text = "Denominazione";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtCreDeb
			// 
			this.txtCreDeb.Location = new System.Drawing.Point(112, 24);
			this.txtCreDeb.Name = "txtCreDeb";
			this.txtCreDeb.Size = new System.Drawing.Size(344, 20);
			this.txtCreDeb.TabIndex = 0;
			this.txtCreDeb.Tag = "registry.title?registrytaxablestatusview.registry";
			this.txtCreDeb.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 16);
			this.label1.TabIndex = 11;
			this.label1.Text = "Validità dal:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(16, 128);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(464, 56);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Reddito ai fini della determinazione delle aliquote ";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 16);
			this.label2.TabIndex = 14;
			this.label2.Text = "Reddito Annuo:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(104, 24);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(104, 20);
			this.textBox1.TabIndex = 1;
			this.textBox1.Tag = "registrytaxablestatus.supposedincome";
			this.textBox1.Text = "";
			// 
			// txtValidita
			// 
			this.txtValidita.Location = new System.Drawing.Point(96, 16);
			this.txtValidita.Name = "txtValidita";
			this.txtValidita.Size = new System.Drawing.Size(104, 20);
			this.txtValidita.TabIndex = 2;
			this.txtValidita.Tag = "registrytaxablestatus.start";
			this.txtValidita.Text = "";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// checkBox2
			// 
			this.checkBox2.Location = new System.Drawing.Point(376, 16);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.checkBox2.Size = new System.Drawing.Size(56, 16);
			this.checkBox2.TabIndex = 4;
			this.checkBox2.Tag = "registrytaxablestatus.active:S:N";
			this.checkBox2.Text = "Attivo";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.txtValidita);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.checkBox2);
			this.groupBox2.Location = new System.Drawing.Point(16, 72);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(464, 48);
			this.groupBox2.TabIndex = 12;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Dati Generali";
			// 
			// Frm_registrytaxablestatus_anagrafica
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(488, 190);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupCredDeb);
			this.Controls.Add(this.groupBox1);
			this.Name = "Frm_registrytaxablestatus_anagrafica";
			this.Text = "frmposretributivanagrafica";
			this.groupCredDeb.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
	}
}