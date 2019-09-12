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
using funzioni_configurazione;

namespace assetacquire_default
{
	/// <summary>
	/// Summary description for FormHint.
	/// </summary>
	public class FormHint : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox Q1;
		private System.Windows.Forms.TextBox Iva1;
		private System.Windows.Forms.TextBox IvaDet1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox IvaDet2;
		private System.Windows.Forms.TextBox Iva2;
		private System.Windows.Forms.TextBox Q2;
		private System.Windows.Forms.TextBox IvaDet3;
		private System.Windows.Forms.TextBox Iva3;
		private System.Windows.Forms.TextBox Q3;
		private System.Windows.Forms.Label label5;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormHint(decimal totiva, decimal totivadetraibile, int number)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			decimal IvaOne=CfgFn.RoundValuta(totiva/number);
			decimal IvaDetraibileOne=CfgFn.RoundValuta(totivadetraibile/number);
			decimal scartoIvaDecimal= (totiva- CfgFn.RoundValuta(IvaOne*number))*100;
			decimal scartoIvaDetraibileDecimal=(totivadetraibile- CfgFn.RoundValuta(IvaDetraibileOne*number))*100;
			int scartoIvaInt= Convert.ToInt32(scartoIvaDecimal);
			int scartoIvaDetraibileInt = Convert.ToInt32(scartoIvaDetraibileDecimal);
			if (scartoIvaInt<0){
				scartoIvaInt+=number;
				IvaOne-=0.01M;
			}
			if (scartoIvaDetraibileInt<0){
				scartoIvaDetraibileInt+=number;
				IvaDetraibileOne-=0.01M;
			}

			//Caso 1: tutti e due gli scarti sono 0
			if (scartoIvaInt==0 && scartoIvaDetraibileInt==0){
				Q1.Text= number.ToString();
				Iva1.Text= totiva.ToString("c");
				IvaDet1.Text= totivadetraibile.ToString("c");
				return;
			}

			Q2.Visible=true;
			Iva2.Visible=true;
			IvaDet2.Visible=true;

			//Caso 2a:  scartoIvaDetraibile ==0 
			if (scartoIvaInt!=0 && scartoIvaDetraibileInt==0){
				int nbase= number-scartoIvaInt;
				decimal IvaBase= IvaOne* nbase;
				decimal IvaDetrBase = IvaDetraibileOne*nbase;
				decimal IvaSuppl= ((IvaOne+0.01M)* scartoIvaInt);
				decimal IvaDetrSuppl= IvaDetraibileOne*scartoIvaInt;
				Q1.Text= nbase.ToString();
				Iva1.Text= IvaBase.ToString("c");
				IvaDet1.Text= IvaDetrBase.ToString("c");
				Q2.Text= scartoIvaInt.ToString();
				Iva2.Text= IvaSuppl.ToString("c");
				IvaDet2.Text= IvaDetrSuppl.ToString("c");
				return;
			}

			//Caso 2b:  scartoIvaInt ==0 
			if (scartoIvaInt==0 && scartoIvaDetraibileInt!=0){
				int nbase= number-scartoIvaDetraibileInt;
				decimal IvaBase= IvaOne* nbase;
				decimal IvaDetrBase = IvaDetraibileOne*nbase;
				decimal IvaSuppl=  IvaOne* scartoIvaDetraibileInt;
				decimal IvaDetrSuppl= (IvaDetraibileOne+0.01M)*scartoIvaDetraibileInt;
				Q1.Text= nbase.ToString();
				Iva1.Text= IvaBase.ToString("c");
				IvaDet1.Text= IvaDetrBase.ToString("c");
				Q2.Text= scartoIvaDetraibileInt.ToString();
				Iva2.Text= IvaSuppl.ToString("c");
				IvaDet2.Text= IvaDetrSuppl.ToString("c");
				return;
			}

			//Caso 3a: entrambi scarti !=0, uguali tra loro
			if (scartoIvaInt==scartoIvaDetraibileInt){
				int nbase= number-scartoIvaDetraibileInt;
				decimal IvaBase= IvaOne* nbase;
				decimal IvaDetrBase = IvaDetraibileOne*nbase;
				decimal IvaSuppl=  (IvaOne+0.01M)* scartoIvaDetraibileInt;
				decimal IvaDetrSuppl= (IvaDetraibileOne+0.01M)*scartoIvaDetraibileInt;
				Q1.Text= nbase.ToString();
				Iva1.Text= IvaBase.ToString("c");
				IvaDet1.Text= IvaDetrBase.ToString("c");
				Q2.Text= scartoIvaDetraibileInt.ToString();
				Iva2.Text= IvaSuppl.ToString("c");
				IvaDet2.Text= IvaDetrSuppl.ToString("c");
				return;
			}

			Q3.Visible=true;
			Iva3.Visible=true;
			IvaDet3.Visible=true;

			//Caso 3b: entrambi scarti !=0 e diversi tra loro
			if (scartoIvaInt<scartoIvaDetraibileInt){
				int nbase= number-scartoIvaDetraibileInt;
				decimal IvaBase= IvaOne* nbase;
				decimal IvaDetrBase = IvaDetraibileOne*nbase;
				Q1.Text= nbase.ToString();
				Iva1.Text= IvaBase.ToString("c");
				IvaDet1.Text= IvaDetrBase.ToString("c");

				decimal IvaSuppl=  (IvaOne+0.01M)* scartoIvaInt;
				decimal IvaDetrSuppl= (IvaDetraibileOne+0.01M)*scartoIvaInt;
				Q2.Text= scartoIvaInt.ToString();
				Iva2.Text= IvaSuppl.ToString("c");
				IvaDet2.Text= IvaDetrSuppl.ToString("c");

				int q3= scartoIvaDetraibileInt-scartoIvaInt;

				decimal IvaSuppl2=  IvaOne* q3;
				decimal IvaDetrSuppl2= (IvaDetraibileOne+0.01M)*q3;
				Q3.Text= q3.ToString();
				Iva3.Text= IvaSuppl2.ToString("c");
				IvaDet3.Text= IvaDetrSuppl2.ToString("c");
				return;
			}
			else {

				int nbase= number-scartoIvaInt;
				decimal IvaBase= IvaOne* nbase;
				decimal IvaDetrBase = IvaDetraibileOne*nbase;
				Q1.Text= nbase.ToString();
				Iva1.Text= IvaBase.ToString("c");
				IvaDet1.Text= IvaDetrBase.ToString("c");

				decimal IvaSuppl=  (IvaOne+0.01M)* scartoIvaDetraibileInt;
				decimal IvaDetrSuppl= (IvaDetraibileOne+0.01M)*scartoIvaDetraibileInt;
				Q2.Text= scartoIvaDetraibileInt.ToString();
				Iva2.Text= IvaSuppl.ToString("c");
				IvaDet2.Text= IvaDetrSuppl.ToString("c");

				int q3= scartoIvaInt-scartoIvaDetraibileInt;

				decimal IvaSuppl2=  (IvaOne+0.01M)* q3;
				decimal IvaDetrSuppl2= IvaDetraibileOne*q3;
				Q3.Text= q3.ToString();
				Iva3.Text= IvaSuppl2.ToString("c");
				IvaDet3.Text= IvaDetrSuppl2.ToString("c");
			}




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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.Q1 = new System.Windows.Forms.TextBox();
			this.Iva1 = new System.Windows.Forms.TextBox();
			this.IvaDet1 = new System.Windows.Forms.TextBox();
			this.IvaDet2 = new System.Windows.Forms.TextBox();
			this.Iva2 = new System.Windows.Forms.TextBox();
			this.Q2 = new System.Windows.Forms.TextBox();
			this.IvaDet3 = new System.Windows.Forms.TextBox();
			this.Iva3 = new System.Windows.Forms.TextBox();
			this.Q3 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(288, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Suggerimento su come effettuare il carico";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "Quantità";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(120, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 16);
			this.label3.TabIndex = 2;
			this.label3.Text = "Iva";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(224, 64);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 16);
			this.label4.TabIndex = 3;
			this.label4.Text = "Iva Detraibile";
			// 
			// Q1
			// 
			this.Q1.Location = new System.Drawing.Point(16, 88);
			this.Q1.Name = "Q1";
			this.Q1.ReadOnly = true;
			this.Q1.TabIndex = 4;
			this.Q1.Text = "";
			this.Q1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// Iva1
			// 
			this.Iva1.Location = new System.Drawing.Point(120, 88);
			this.Iva1.Name = "Iva1";
			this.Iva1.ReadOnly = true;
			this.Iva1.TabIndex = 5;
			this.Iva1.Text = "";
			this.Iva1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// IvaDet1
			// 
			this.IvaDet1.Location = new System.Drawing.Point(224, 88);
			this.IvaDet1.Name = "IvaDet1";
			this.IvaDet1.ReadOnly = true;
			this.IvaDet1.TabIndex = 6;
			this.IvaDet1.Text = "";
			this.IvaDet1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// IvaDet2
			// 
			this.IvaDet2.Location = new System.Drawing.Point(224, 120);
			this.IvaDet2.Name = "IvaDet2";
			this.IvaDet2.ReadOnly = true;
			this.IvaDet2.TabIndex = 9;
			this.IvaDet2.Text = "";
			this.IvaDet2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.IvaDet2.Visible = false;
			// 
			// Iva2
			// 
			this.Iva2.Location = new System.Drawing.Point(120, 120);
			this.Iva2.Name = "Iva2";
			this.Iva2.ReadOnly = true;
			this.Iva2.TabIndex = 8;
			this.Iva2.Text = "";
			this.Iva2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.Iva2.Visible = false;
			// 
			// Q2
			// 
			this.Q2.Location = new System.Drawing.Point(16, 120);
			this.Q2.Name = "Q2";
			this.Q2.ReadOnly = true;
			this.Q2.TabIndex = 7;
			this.Q2.Text = "";
			this.Q2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.Q2.Visible = false;
			// 
			// IvaDet3
			// 
			this.IvaDet3.Location = new System.Drawing.Point(224, 152);
			this.IvaDet3.Name = "IvaDet3";
			this.IvaDet3.ReadOnly = true;
			this.IvaDet3.TabIndex = 12;
			this.IvaDet3.Text = "";
			this.IvaDet3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.IvaDet3.Visible = false;
			// 
			// Iva3
			// 
			this.Iva3.Location = new System.Drawing.Point(120, 152);
			this.Iva3.Name = "Iva3";
			this.Iva3.ReadOnly = true;
			this.Iva3.TabIndex = 11;
			this.Iva3.Text = "";
			this.Iva3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.Iva3.Visible = false;
			// 
			// Q3
			// 
			this.Q3.Location = new System.Drawing.Point(16, 152);
			this.Q3.Name = "Q3";
			this.Q3.ReadOnly = true;
			this.Q3.TabIndex = 10;
			this.Q3.Text = "";
			this.Q3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.Q3.Visible = false;
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Location = new System.Drawing.Point(120, 192);
			this.button1.Name = "button1";
			this.button1.TabIndex = 13;
			this.button1.Text = "Chiudi";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 24);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(328, 40);
			this.label5.TabIndex = 14;
			this.label5.Text = "Può essere importante per fare quadrare le imposte unitarie con quelle totali";
			// 
			// FormHint
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(352, 231);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.IvaDet3);
			this.Controls.Add(this.Iva3);
			this.Controls.Add(this.Q3);
			this.Controls.Add(this.IvaDet2);
			this.Controls.Add(this.Iva2);
			this.Controls.Add(this.Q2);
			this.Controls.Add(this.IvaDet1);
			this.Controls.Add(this.Iva1);
			this.Controls.Add(this.Q1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "FormHint";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Suggerimenti";
			this.TopMost = true;
			this.ResumeLayout(false);

		}
		#endregion

		private void button1_Click(object sender, System.EventArgs e) {
			this.Close();
		}
	}
}
