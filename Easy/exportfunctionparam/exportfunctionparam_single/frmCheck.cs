
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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

namespace exportfunctionparam_single
{
	/// <summary>
	/// Summary description for frmCheck.
	/// </summary>
	public class frmCheck : MetaDataForm
	{
		private System.Windows.Forms.TextBox txtCheckNo;
		private System.Windows.Forms.TextBox txtCheckDesc;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtCheckYes;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		public string GetValue="";

		public frmCheck(string command)
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
			txtCheckYes.Text=token[0];
			txtCheckNo.Text=token[1];
			txtCheckDesc.Text=token[2];
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
            this.txtCheckNo = new System.Windows.Forms.TextBox();
            this.txtCheckDesc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCheckYes = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtCheckNo
            // 
            this.txtCheckNo.Location = new System.Drawing.Point(192, 40);
            this.txtCheckNo.Name = "txtCheckNo";
            this.txtCheckNo.Size = new System.Drawing.Size(100, 20);
            this.txtCheckNo.TabIndex = 2;
            // 
            // txtCheckDesc
            // 
            this.txtCheckDesc.Location = new System.Drawing.Point(192, 64);
            this.txtCheckDesc.Name = "txtCheckDesc";
            this.txtCheckDesc.Size = new System.Drawing.Size(352, 20);
            this.txtCheckDesc.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(16, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "Descrizione";
            // 
            // txtCheckYes
            // 
            this.txtCheckYes.Location = new System.Drawing.Point(192, 16);
            this.txtCheckYes.Name = "txtCheckYes";
            this.txtCheckYes.Size = new System.Drawing.Size(100, 20);
            this.txtCheckYes.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Valore del check non selezionato";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Valore del check selezionato";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(291, 128);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Annulla";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(195, 128);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmCheck
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(560, 181);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtCheckNo);
            this.Controls.Add(this.txtCheckDesc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCheckYes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmCheck";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Impostazione valori per un Check Box";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void ShowMsg() {
			show("La condizione è incompleta, valorizzare tutti i campi","Attenzione",
				MessageBoxButtons.OK,MessageBoxIcon.Information);
		}

		private void btnOK_Click(object sender, System.EventArgs e) {
			foreach (Control ctrl in this.Controls) {
				if (ctrl.GetType()!=typeof(TextBox)) continue;
				if (ctrl.Text.Trim()=="") {
					ShowMsg();
					return;
				}
			}
			GetValue=txtCheckYes.Text+"|"+txtCheckNo.Text+"|"+txtCheckDesc.Text;
			this.DialogResult=DialogResult.OK;
		}
	}
}
