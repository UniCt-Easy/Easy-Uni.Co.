
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

namespace reportparameter_single//reportparametersingle//
{
	/// <summary>
	/// Summary description for frmRadio.
	/// </summary>
	public class frmRadio : MetaDataForm
	{
		private System.Windows.Forms.TextBox txtRadioDesc2;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox txtRadioVal2;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox txtRadioDesc3;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtRadioVal3;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox txtRadioDesc4;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtRadioVal4;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtRadioDesc5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtRadioVal5;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtRadioDesc1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtRadioVal1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		public string GetValue="";

		public frmRadio(string command)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			ImpostaValori(command);
		}

		private void ImpostaValori(string cmd) {
			if (cmd=="") return;
			string[] token = cmd.Split('|');
			for (int i=0, j=1; i<token.Length; i+=2, j++) {
				foreach (Control ctrl in this.Controls) {
					if (ctrl.GetType()!=typeof(TextBox)) continue;
					if (ctrl.Name.EndsWith(j.ToString())) {
						if (ctrl.Name.StartsWith("txtRadioVal"))
							ctrl.Text=token[i];
						else
							ctrl.Text=token[i+1];
					}
				}
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
			this.txtRadioDesc2 = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.txtRadioVal2 = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.txtRadioDesc3 = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.txtRadioVal3 = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.txtRadioDesc4 = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtRadioVal4 = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtRadioDesc5 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtRadioVal5 = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtRadioDesc1 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtRadioVal1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtRadioDesc2
			// 
			this.txtRadioDesc2.Location = new System.Drawing.Point(208, 48);
			this.txtRadioDesc2.Name = "txtRadioDesc2";
			this.txtRadioDesc2.Size = new System.Drawing.Size(336, 20);
			this.txtRadioDesc2.TabIndex = 4;
			this.txtRadioDesc2.Text = "";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(152, 48);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(56, 16);
			this.label12.TabIndex = 38;
			this.label12.Text = "Descr. 2";
			// 
			// txtRadioVal2
			// 
			this.txtRadioVal2.Location = new System.Drawing.Point(72, 48);
			this.txtRadioVal2.Name = "txtRadioVal2";
			this.txtRadioVal2.Size = new System.Drawing.Size(72, 20);
			this.txtRadioVal2.TabIndex = 3;
			this.txtRadioVal2.Text = "";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(16, 48);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(48, 16);
			this.label13.TabIndex = 36;
			this.label13.Text = "Valore 2";
			// 
			// txtRadioDesc3
			// 
			this.txtRadioDesc3.Location = new System.Drawing.Point(208, 72);
			this.txtRadioDesc3.Name = "txtRadioDesc3";
			this.txtRadioDesc3.Size = new System.Drawing.Size(336, 20);
			this.txtRadioDesc3.TabIndex = 6;
			this.txtRadioDesc3.Text = "";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(152, 72);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(56, 16);
			this.label10.TabIndex = 34;
			this.label10.Text = "Descr. 3";
			// 
			// txtRadioVal3
			// 
			this.txtRadioVal3.Location = new System.Drawing.Point(72, 72);
			this.txtRadioVal3.Name = "txtRadioVal3";
			this.txtRadioVal3.Size = new System.Drawing.Size(72, 20);
			this.txtRadioVal3.TabIndex = 5;
			this.txtRadioVal3.Text = "";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(16, 72);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(48, 16);
			this.label11.TabIndex = 32;
			this.label11.Text = "Valore 3";
			// 
			// txtRadioDesc4
			// 
			this.txtRadioDesc4.Location = new System.Drawing.Point(208, 96);
			this.txtRadioDesc4.Name = "txtRadioDesc4";
			this.txtRadioDesc4.Size = new System.Drawing.Size(336, 20);
			this.txtRadioDesc4.TabIndex = 8;
			this.txtRadioDesc4.Text = "";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(152, 96);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(56, 16);
			this.label8.TabIndex = 30;
			this.label8.Text = "Descr. 4";
			// 
			// txtRadioVal4
			// 
			this.txtRadioVal4.Location = new System.Drawing.Point(72, 96);
			this.txtRadioVal4.Name = "txtRadioVal4";
			this.txtRadioVal4.Size = new System.Drawing.Size(72, 20);
			this.txtRadioVal4.TabIndex = 7;
			this.txtRadioVal4.Text = "";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(16, 96);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(48, 16);
			this.label9.TabIndex = 28;
			this.label9.Text = "Valore 4";
			// 
			// txtRadioDesc5
			// 
			this.txtRadioDesc5.Location = new System.Drawing.Point(208, 120);
			this.txtRadioDesc5.Name = "txtRadioDesc5";
			this.txtRadioDesc5.Size = new System.Drawing.Size(336, 20);
			this.txtRadioDesc5.TabIndex = 10;
			this.txtRadioDesc5.Text = "";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(152, 120);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(56, 16);
			this.label6.TabIndex = 26;
			this.label6.Text = "Descr. 5";
			// 
			// txtRadioVal5
			// 
			this.txtRadioVal5.Location = new System.Drawing.Point(72, 120);
			this.txtRadioVal5.Name = "txtRadioVal5";
			this.txtRadioVal5.Size = new System.Drawing.Size(72, 20);
			this.txtRadioVal5.TabIndex = 9;
			this.txtRadioVal5.Text = "";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(16, 120);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(48, 16);
			this.label7.TabIndex = 24;
			this.label7.Text = "Valore 5";
			// 
			// txtRadioDesc1
			// 
			this.txtRadioDesc1.Location = new System.Drawing.Point(208, 24);
			this.txtRadioDesc1.Name = "txtRadioDesc1";
			this.txtRadioDesc1.Size = new System.Drawing.Size(336, 20);
			this.txtRadioDesc1.TabIndex = 2;
			this.txtRadioDesc1.Text = "";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(152, 24);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(56, 16);
			this.label5.TabIndex = 22;
			this.label5.Text = "Descr. 1";
			// 
			// txtRadioVal1
			// 
			this.txtRadioVal1.Location = new System.Drawing.Point(72, 24);
			this.txtRadioVal1.Name = "txtRadioVal1";
			this.txtRadioVal1.Size = new System.Drawing.Size(72, 20);
			this.txtRadioVal1.TabIndex = 1;
			this.txtRadioVal1.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 16);
			this.label1.TabIndex = 20;
			this.label1.Text = "Valore 1";
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(291, 176);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 12;
			this.btnCancel.Text = "Annulla";
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(195, 176);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 11;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// frmRadio
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(560, 229);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.txtRadioDesc2);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.txtRadioVal2);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.txtRadioDesc3);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.txtRadioVal3);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.txtRadioDesc4);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.txtRadioVal4);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.txtRadioDesc5);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txtRadioVal5);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.txtRadioDesc1);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtRadioVal1);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.Name = "frmRadio";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Impostazione valori per Radio Button";
			this.ResumeLayout(false);

		}
		#endregion

		private void ShowMsg(string msg) {
			show(msg, "Attenzione",
				MessageBoxButtons.OK,MessageBoxIcon.Information);
		}

		private void btnOK_Click(object sender, System.EventArgs e) {
			GetValue="";
			int righe=0;
			if ((txtRadioVal1.Text!="") ^ (txtRadioDesc1.Text!="")) {
				ShowMsg("La riga 1 è incompleta.");
				return;
			}
			if ((txtRadioVal1.Text!="") && (txtRadioDesc1.Text!="")) {
				AggiungiCondizione(1);
				++righe;
			}

			if ((txtRadioVal2.Text!="") ^ (txtRadioDesc2.Text!="")) {
				ShowMsg("La riga 2 è incompleta.");
				return;
			}
			if ((txtRadioVal2.Text!="") && (txtRadioDesc2.Text!="")) {
				AggiungiCondizione(2);
				++righe;
			}

			if ((txtRadioVal3.Text!="") ^ (txtRadioDesc3.Text!="")) {
				ShowMsg("La riga 3 è incompleta.");
				return;
			}
			if ((txtRadioVal3.Text!="") && (txtRadioDesc3.Text!="")) {
				AggiungiCondizione(3);
				++righe;
			}

			if ((txtRadioVal4.Text!="") ^ (txtRadioDesc4.Text!="")) {
				ShowMsg("La riga 4 è incompleta.");
				return;
			}
			if ((txtRadioVal4.Text!="") && (txtRadioDesc4.Text!="")) {
				AggiungiCondizione(4);
				++righe;
			}

			if ((txtRadioVal5.Text!="") ^ (txtRadioDesc5.Text!="")) {
				ShowMsg("La riga 5 è incompleta.");
				return;
			}
			if ((txtRadioVal5.Text!="") && (txtRadioDesc5.Text!="")) {
				AggiungiCondizione(5);
				++righe;
			}

			//almeno due righe sono necessarie
			if (righe<2) {
				ShowMsg("Per il tipo radio button sono necessarie almeno due condizioni");
				return;
			}
			this.DialogResult=DialogResult.OK;
		}

		private void AggiungiCondizione(int riga) {
			string valore="";
			string descrizione="";
			foreach (Control ctrl in this.Controls) {
				if (ctrl.GetType()!=typeof(TextBox)) continue;
				if (!ctrl.Name.EndsWith(riga.ToString())) continue;
				if (ctrl.Name=="txtRadioVal"+riga.ToString())
					valore=ctrl.Text;
				if (ctrl.Name=="txtRadioDesc"+riga.ToString())
					descrizione=ctrl.Text;
			}
			if (riga>1) GetValue+="|";
			GetValue+=valore+"|"+descrizione;
		}
	}
}
