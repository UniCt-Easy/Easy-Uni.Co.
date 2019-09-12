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
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;

namespace entry_shrink
{
	/// <summary>
	/// Summary description for .
	/// </summary>
	public class Frm_CompattaDettagliScritture : System.Windows.Forms.Form
	{
		MetaData Meta;
		private System.Windows.Forms.Button btnAnnulla;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.TextBox txtEsercizio;
		private System.Windows.Forms.TextBox textBox1;
		public vistaForm DS;
		DataAccess Conn;
		private System.Windows.Forms.Label label1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_CompattaDettagliScritture()
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
			this.btnAnnulla = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.txtEsercizio = new System.Windows.Forms.TextBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.DS = new vistaForm();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnAnnulla.Location = new System.Drawing.Point(232, 120);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.TabIndex = 6;
			this.btnAnnulla.Text = "Annulla";
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(144, 120);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 5;
			this.btnOK.Tag = "";
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// txtEsercizio
			// 
			this.txtEsercizio.Location = new System.Drawing.Point(16, 24);
			this.txtEsercizio.Name = "txtEsercizio";
			this.txtEsercizio.Size = new System.Drawing.Size(72, 20);
			this.txtEsercizio.TabIndex = 9;
			this.txtEsercizio.Text = "";
			this.txtEsercizio.Leave += new System.EventHandler(this.txtEsercizio_Leave);
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(120, 16);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(192, 56);
			this.textBox1.TabIndex = 23;
			this.textBox1.TabStop = false;
			this.textBox1.Text = "Per procedere all\'operazione, selezionare l\'esercizio delle scritture da compatta" +
				"re e premere Ok. ";
			this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 16);
			this.label1.TabIndex = 24;
			this.label1.Text = "Esercizio";
			// 
			// Frm_CompattaDettagliScritture
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnAnnulla;
			this.ClientSize = new System.Drawing.Size(320, 157);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnAnnulla);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.txtEsercizio);
			this.Controls.Add(this.textBox1);
			this.Name = "Frm_CompattaDettagliScritture";
			this.Text = "Compatta numerazione scritture E/P";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

	
		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
			Conn= Meta.Conn;
			Meta.CanInsert = false;
			Meta.CanInsertCopy = false;
			Meta.CanCancel = false;
			txtEsercizio.Text = Meta.GetSys("esercizio").ToString();
		}

		private void txtEsercizio_Leave(object sender, System.EventArgs e) {
			HelpForm.FormatLikeYear(txtEsercizio);
		}
		
		public bool DatiValidi(){
			int esercizio;
			try {
				esercizio = (int) HelpForm.GetObjectFromString(typeof(int),
					txtEsercizio.Text.ToString(), "x.y.year");
				if ((esercizio<0)) {
					MessageBox.Show("L'esercizio non può essere negativo");
					txtEsercizio.Focus();
					return false;
				}
			}
			catch {
				MessageBox.Show("E' necessario inserire un esercizio");
				txtEsercizio.Focus();
				return false;
			}

			txtEsercizio.Focus();
			return true;
		}		

		private void btnOK_Click(object sender, System.EventArgs e) {
			if (!DatiValidi()) return;
			int esercizio = (int) HelpForm.GetObjectFromString(typeof(int),
				txtEsercizio.Text.ToString(), "x.y.year");
			Conn.CallSP("entry_shrink",new object[]{esercizio},false,6000);
			MessageBox.Show("Operazione eseguita.");
		}

	}
}
