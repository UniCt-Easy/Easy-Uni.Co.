
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
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using funzioni_configurazione;

namespace expenselast_modpaga//spesamodcreddebi//
{
	/// <summary>
	/// Summary description for frmaskbban.
	/// </summary>
	public class frmaskbban : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox txtBBAN;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Label label1;
//		bool inChiusura = false;
		public string insertedBBAN = "";
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        public frmaskbban(string bban) {
            InitializeComponent();
            txtBBAN.Text = bban;
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
            this.txtBBAN = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtBBAN
            // 
            this.txtBBAN.Location = new System.Drawing.Point(144, 18);
            this.txtBBAN.Name = "txtBBAN";
            this.txtBBAN.Size = new System.Drawing.Size(200, 20);
            this.txtBBAN.TabIndex = 15;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(192, 94);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Annulla";
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(80, 94);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 13;
            this.btnOk.Text = "Ok";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Inserisci il codice BBAN:";
            // 
            // frmaskbban
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(352, 134);
            this.Controls.Add(this.txtBBAN);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label1);
            this.Name = "frmaskbban";
            this.Text = "frmaskbban";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        private void btnOk_Click(object sender, EventArgs e) {
            //            if (inChiusura) return;
            //Lunghezza del BBAN = 1 (CIN) + 5 (ABI) + 5(CAB) + 12 (C/C) = 23
            string bban = CfgFn.normalizzaIBAN(txtBBAN.Text.ToUpper());
            if (bban.Length != 23) {
                MessageBox.Show(this, "Attenzione: Il codice BBAN deve essere composto da 23 caratteri!");
                insertedBBAN = "";
                DialogResult = DialogResult.None;
                return;
            }
            if (CfgFn.CheckLetter(bban.Substring(1), 22) != bban[0]) {
                MessageBox.Show(this, "Attenzione il BBAN inserito non è corretto!");
                insertedBBAN = "";
                DialogResult = DialogResult.None;
                return;
            }
            insertedBBAN = bban;
        }
    }
}
