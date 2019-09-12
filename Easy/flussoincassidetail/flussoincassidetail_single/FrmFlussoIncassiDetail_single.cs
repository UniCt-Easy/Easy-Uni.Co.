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

namespace flussoincassidetail_single
{
	/// <summary>
	/// Summary description for Frmflussoincassidetail_single.
	/// </summary>
	public class Frmflussoincassidetail_single : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnAnnulla;
		private System.Windows.Forms.Button btnOK;
		MetaData Meta;
        public flussoincassidetail_single.vistaForm DS;
        private TextBox textBox3;
        private Label labelImporto;
        private TextBox textBox5;
        private Label label1;
        private Label label2;
        private TextBox txtUniqueFCode;
        private Label label3;
        private TextBox txtCodiceFiscale;
		private Label label4;
		private TextBox txtPiva;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frmflussoincassidetail_single()
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
			this.DS = new flussoincassidetail_single.vistaForm();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.labelImporto = new System.Windows.Forms.Label();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtUniqueFCode = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtCodiceFiscale = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtPiva = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnAnnulla.Location = new System.Drawing.Point(270, 242);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
			this.btnAnnulla.TabIndex = 16;
			this.btnAnnulla.Text = "Annulla";
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(166, 242);
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
			// textBox3
			// 
			this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox3.Location = new System.Drawing.Point(252, 39);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(87, 20);
			this.textBox3.TabIndex = 2;
			this.textBox3.Tag = "flussoincassidetail.importo";
			this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// labelImporto
			// 
			this.labelImporto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelImporto.Location = new System.Drawing.Point(252, 19);
			this.labelImporto.Name = "labelImporto";
			this.labelImporto.Size = new System.Drawing.Size(87, 16);
			this.labelImporto.TabIndex = 132;
			this.labelImporto.Text = "Importo";
			this.labelImporto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(25, 39);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(207, 20);
			this.textBox5.TabIndex = 1;
			this.textBox5.Tag = "flussoincassidetail.iuv";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(25, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 16);
			this.label1.TabIndex = 137;
			this.label1.Text = "IUV";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(25, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(182, 16);
			this.label2.TabIndex = 139;
			this.label2.Text = "Codice Bollettino Univoco";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtUniqueFCode
			// 
			this.txtUniqueFCode.Location = new System.Drawing.Point(25, 91);
			this.txtUniqueFCode.Name = "txtUniqueFCode";
			this.txtUniqueFCode.Size = new System.Drawing.Size(207, 20);
			this.txtUniqueFCode.TabIndex = 3;
			this.txtUniqueFCode.Tag = "flussoincassidetail.iduniqueformcode";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(25, 122);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(182, 16);
			this.label3.TabIndex = 141;
			this.label3.Text = "Codice Fiscale";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtCodiceFiscale
			// 
			this.txtCodiceFiscale.Location = new System.Drawing.Point(25, 141);
			this.txtCodiceFiscale.Name = "txtCodiceFiscale";
			this.txtCodiceFiscale.Size = new System.Drawing.Size(207, 20);
			this.txtCodiceFiscale.TabIndex = 140;
			this.txtCodiceFiscale.Tag = "flussoincassidetail.cf";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(25, 174);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(182, 16);
			this.label4.TabIndex = 143;
			this.label4.Text = "Partita iva";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtPiva
			// 
			this.txtPiva.Location = new System.Drawing.Point(25, 193);
			this.txtPiva.Name = "txtPiva";
			this.txtPiva.Size = new System.Drawing.Size(207, 20);
			this.txtPiva.TabIndex = 142;
			this.txtPiva.Tag = "flussoincassidetail.p_iva";
			// 
			// Frmflussoincassidetail_single
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnAnnulla;
			this.ClientSize = new System.Drawing.Size(368, 277);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtPiva);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtCodiceFiscale);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtUniqueFCode);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox5);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.labelImporto);
			this.Controls.Add(this.btnAnnulla);
			this.Controls.Add(this.btnOK);
			this.Name = "Frmflussoincassidetail_single";
			this.Text = "Frmflussoincassidetail_single";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

        CQueryHelper QHC;
        QueryHelper QHS;
		public void MetaData_AfterLink(){
			Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
			string filter = Meta.QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            
 
            GetData.SetStaticFilter(DS.flussoincassi, filter);

 
		}
 

	}
}
