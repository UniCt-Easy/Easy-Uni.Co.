
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

namespace payrollview_calcolomultiplo
{
	/// <summary>
	/// Summary description for AskOperation.
	/// </summary>
	public class AskOperation : System.Windows.Forms.Form {
		public enum operazione {Si, SiTutti, No, NoTutti};
		private System.Windows.Forms.Button btnSi;
		private System.Windows.Forms.Button btnSiTutti;
		private System.Windows.Forms.Button btnNo;
		private System.Windows.Forms.Button btnNoTutti;
		private System.Windows.Forms.Label lblQuestion;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AskOperation(int idCedolino)
		{
			InitializeComponent();
			lblQuestion.Text = "Vuoi generare gli impegni di budget per il cedolino n. " + idCedolino
				+ "?\nSe si risponde Si, Tutti questa domanda non verrà rifatta per i cedolini successivi per i quali verranno generati gli impengi di budget"
				+ "\nSe si risponde No, Tutti questa domanda non verrà rifatta per i cedolini successivi per i quali non verranno generati gli impegni di budget";
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
			this.btnSi = new System.Windows.Forms.Button();
			this.btnSiTutti = new System.Windows.Forms.Button();
			this.btnNo = new System.Windows.Forms.Button();
			this.btnNoTutti = new System.Windows.Forms.Button();
			this.lblQuestion = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnSi
			// 
			this.btnSi.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSi.Location = new System.Drawing.Point(40, 88);
			this.btnSi.Name = "btnSi";
			this.btnSi.TabIndex = 0;
			this.btnSi.Text = "Si";
			this.btnSi.Click += new System.EventHandler(this.btnSi_Click);
			// 
			// btnSiTutti
			// 
			this.btnSiTutti.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSiTutti.Location = new System.Drawing.Point(176, 88);
			this.btnSiTutti.Name = "btnSiTutti";
			this.btnSiTutti.TabIndex = 1;
			this.btnSiTutti.Text = "Si, Tutti";
			this.btnSiTutti.Click += new System.EventHandler(this.btnSiTutti_Click);
			// 
			// btnNo
			// 
			this.btnNo.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnNo.Location = new System.Drawing.Point(320, 88);
			this.btnNo.Name = "btnNo";
			this.btnNo.TabIndex = 2;
			this.btnNo.Text = "No";
			this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
			// 
			// btnNoTutti
			// 
			this.btnNoTutti.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnNoTutti.Location = new System.Drawing.Point(480, 88);
			this.btnNoTutti.Name = "btnNoTutti";
			this.btnNoTutti.TabIndex = 3;
			this.btnNoTutti.Text = "No, Tutti";
			this.btnNoTutti.Click += new System.EventHandler(this.btnNoTutti_Click);
			// 
			// lblQuestion
			// 
			this.lblQuestion.Location = new System.Drawing.Point(8, 8);
			this.lblQuestion.Name = "lblQuestion";
			this.lblQuestion.Size = new System.Drawing.Size(568, 64);
			this.lblQuestion.TabIndex = 4;
			// 
			// AskOperation
			// 
			this.AcceptButton = this.btnSi;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(584, 118);
			this.Controls.Add(this.lblQuestion);
			this.Controls.Add(this.btnNoTutti);
			this.Controls.Add(this.btnNo);
			this.Controls.Add(this.btnSiTutti);
			this.Controls.Add(this.btnSi);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "AskOperation";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "AskOperation";
			this.ResumeLayout(false);

		}
		#endregion

		
		public operazione operazioneScelta;

		private void btnSi_Click(object sender, System.EventArgs e) {
			operazioneScelta = operazione.Si;
		}

		private void btnSiTutti_Click(object sender, System.EventArgs e) {
			operazioneScelta = operazione.SiTutti;
		}

		private void btnNo_Click(object sender, System.EventArgs e) {
			operazioneScelta = operazione.No;
		}

		private void btnNoTutti_Click(object sender, System.EventArgs e) {
			operazioneScelta = operazione.NoTutti;
		}
	}
}
