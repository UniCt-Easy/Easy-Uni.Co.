/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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
using System.Diagnostics;
using metadatalibrary;

namespace bankdispositionsetup_trasmissione//pergenautomovimenti_trasmissione//
{
	/// <summary>
	/// Summary description for frmPersGenAutomovimenti_Trasmissione.
	/// </summary>
	public class frmPersGenAutomovimenti_Trasmissione : System.Windows.Forms.Form
	{
		public vistaForm DS;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Label labExe;
		private System.Windows.Forms.Timer timer1;
		string sw;
		private System.Windows.Forms.Label label1;
		bool activated;

		public frmPersGenAutomovimenti_Trasmissione(string sw)
		{
			InitializeComponent();

			this.sw=sw;

		}
                    
		public void MetaData_AfterLink(){
            DataAccess.SetTableForReading(DS.bankdispositionsetup, "config");
        }
		public void MetaData_AfterClear(){
			labExe.Text += sw;
			try {
				Process.Start(sw);
			}
			catch (Exception E){
				QueryCreator.ShowException(E);
			}
			activated=true;
			
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
			this.components = new System.ComponentModel.Container();
			this.DS = new vistaForm();
			this.labExe = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaPersGen";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// labExe
			// 
			this.labExe.Location = new System.Drawing.Point(24, 56);
			this.labExe.Name = "labExe";
			this.labExe.Size = new System.Drawing.Size(408, 32);
			this.labExe.TabIndex = 0;
			this.labExe.Text = "Esecuzione di ";
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 2000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 96);
			this.label1.Name = "label1";
			this.label1.TabIndex = 1;
			this.label1.Text = "Attendere prego...";
			// 
			// frmPersGenAutomovimenti_Trasmissione
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(456, 141);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.labExe);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "frmPersGenAutomovimenti_Trasmissione";
			this.ShowInTaskbar = false;
			this.Text = "frmPersGenAutomovimenti_Trasmissione";
			this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void timer1_Tick(object sender, System.EventArgs e) {
			if (activated) Close();
		}
	}
}
