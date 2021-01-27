
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
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;

namespace otherinail_default//altrecollaborazioniinail//
{
	/// <summary>
	/// Summary description for frmaltrecollaborazioniinail.
	/// </summary>
	public class Frm_otherinail_default : System.Windows.Forms.Form
	{
		public /*Rana:altrecollaborazioniinail.*/vistaForm DS;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TextBox txtDataInizio;
		private System.Windows.Forms.TextBox txtDataFine;
		private System.Windows.Forms.TextBox txtDurata;
		MetaData Meta;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_otherinail_default()
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

		public void MetaData_AfterLink()
		{
			Meta = MetaData.GetMetaData(this);
		}

		private void RicalcolaDurataMesi()
		{
			if ((Meta.InsertMode)||(Meta.EditMode))
			{
				object inizio = HelpForm.GetObjectFromString(typeof(DateTime), txtDataInizio.Text, txtDataInizio.Tag.ToString());
				object fine = HelpForm.GetObjectFromString(typeof(DateTime), txtDataFine.Text, txtDataFine.Tag.ToString());

				if ((inizio is DateTime) && (fine is DateTime)) {
					DateTime dataInizio = (DateTime) inizio;
					DateTime dataFine = (DateTime) fine;
					int	nmesi = (dataFine.Year - dataInizio.Year)*12 +
						dataFine.Month - dataInizio.Month + 1;
					txtDurata.Text = nmesi.ToString();
				}
			}
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.DS = new otherinail_default.vistaForm();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtDataInizio = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtDataFine = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtDurata = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
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
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.TabIndex = 0;
			this.label1.Text = "Imponibile";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(120, 8);
			this.textBox1.Name = "textBox1";
			this.textBox1.TabIndex = 1;
			this.textBox1.Tag = "otherinail.taxable";
			this.textBox1.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 40);
			this.label2.Name = "label2";
			this.label2.TabIndex = 2;
			this.label2.Text = "Data Inizio";
			// 
			// txtDataInizio
			// 
			this.txtDataInizio.Location = new System.Drawing.Point(120, 40);
			this.txtDataInizio.Name = "txtDataInizio";
			this.txtDataInizio.TabIndex = 3;
			this.txtDataInizio.Tag = "otherinail.start";
			this.txtDataInizio.Text = "";
			this.txtDataInizio.TextChanged += new System.EventHandler(this.txtDataInizio_TextChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 72);
			this.label3.Name = "label3";
			this.label3.TabIndex = 4;
			this.label3.Text = "Data Fine";
			// 
			// txtDataFine
			// 
			this.txtDataFine.Location = new System.Drawing.Point(120, 72);
			this.txtDataFine.Name = "txtDataFine";
			this.txtDataFine.TabIndex = 5;
			this.txtDataFine.Tag = "otherinail.stop";
			this.txtDataFine.Text = "";
			this.txtDataFine.TextChanged += new System.EventHandler(this.txtDataFine_TextChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 104);
			this.label4.Name = "label4";
			this.label4.TabIndex = 6;
			this.label4.Text = "Durata (Mesi)";
			// 
			// txtDurata
			// 
			this.txtDurata.Location = new System.Drawing.Point(120, 104);
			this.txtDurata.Name = "txtDurata";
			this.txtDurata.ReadOnly = true;
			this.txtDurata.TabIndex = 7;
			this.txtDurata.Tag = "otherinail.nmonths";
			this.txtDurata.Text = "";
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Location = new System.Drawing.Point(24, 144);
			this.button1.Name = "button1";
			this.button1.TabIndex = 8;
			this.button1.Tag = "mainsave";
			this.button1.Text = "Ok";
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.Location = new System.Drawing.Point(144, 144);
			this.button2.Name = "button2";
			this.button2.TabIndex = 9;
			this.button2.Text = "Annulla";
			// 
			// Frm_otherinail_default
			// 
			this.AcceptButton = this.button1;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.button2;
			this.ClientSize = new System.Drawing.Size(248, 182);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.txtDurata);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtDataFine);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtDataInizio);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label1);
			this.Name = "Frm_otherinail_default";
			this.Text = "frmaltrecollaborazioniinail";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void txtDataInizio_TextChanged(object sender, System.EventArgs e)
		{
			if (!Meta.DrawStateIsDone)return;
			RicalcolaDurataMesi();
		}

		private void txtDataFine_TextChanged(object sender, System.EventArgs e)
		{
			if (!Meta.DrawStateIsDone)return;
			RicalcolaDurataMesi();
		}

	}
}
