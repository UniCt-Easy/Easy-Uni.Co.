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
using metaeasylibrary;
using System.Data;
using ViewError;//ViewError

namespace auditparameter_recalc//parameterrecalc//
{
	/// <summary>
	/// Summary description for RecalcProgress.
	/// </summary>
	public class RecalcProgress : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtTable;
		private System.Windows.Forms.ProgressBar progBar;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnStop;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		DataAccess Conn;
		ListView LTables;
		ListView LOperations;
        string filterrule;
		bool MustStop;
		bool Running;
		int counttables;
		int tableexamined;
       
		public RecalcProgress(DataAccess Conn, ListView LTables, ListView LOperations, string filterrule)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			this.Conn=Conn;
			this.LTables=LTables;
			this.LOperations=LOperations;
            this.filterrule = filterrule;
			MustStop=false;
			Running=false;

			counttables=0;
			foreach (ListViewItem LT in LTables.Items) {
				if (LT.Checked) counttables++;
			}

			progBar.Maximum= counttables;
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
			this.txtTable = new System.Windows.Forms.TextBox();
			this.progBar = new System.Windows.Forms.ProgressBar();
			this.label2 = new System.Windows.Forms.Label();
			this.btnStop = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(192, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Tabella in elaborazione";
			// 
			// txtTable
			// 
			this.txtTable.Location = new System.Drawing.Point(24, 40);
			this.txtTable.Name = "txtTable";
			this.txtTable.Size = new System.Drawing.Size(232, 20);
			this.txtTable.TabIndex = 1;
			this.txtTable.Text = "";
			// 
			// progBar
			// 
			this.progBar.Location = new System.Drawing.Point(24, 104);
			this.progBar.Name = "progBar";
			this.progBar.Size = new System.Drawing.Size(336, 23);
			this.progBar.Step = 1;
			this.progBar.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(24, 80);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(168, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "Stato di avanzamento";
			// 
			// btnStop
			// 
			this.btnStop.Location = new System.Drawing.Point(160, 144);
			this.btnStop.Name = "btnStop";
			this.btnStop.TabIndex = 4;
			this.btnStop.Text = "Interrompi";
			this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
			// 
			// RecalcProgress
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(386, 199);
			this.Controls.Add(this.btnStop);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.progBar);
			this.Controls.Add(this.txtTable);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "RecalcProgress";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Ricalcolo della business logic in corso...";
			this.TopMost = true;
			this.ResumeLayout(false);

		}
		#endregion

		public void Run(){
			if (Running) return;
			Running=true;
			tableexamined=0;
			foreach(ListViewItem LT in LTables.Items){
				if (!LT.Checked){
					continue;
				}
				tableexamined++;
				txtTable.Text = LT.Text;

				foreach(ListViewItem LO in LOperations.Items){
					if (MustStop) {
						DialogResult = DialogResult.Cancel;
						Close();
						return;
					}
					if (!LO.Checked)continue;
					string err = EasyAudits.RecalcAudit(Conn, LT.Text, LO.Tag.ToString(),filterrule);
					if (err!=null) {
						this.Focus();
						QueryCreator.ShowError(this,
										"Errore nella compilazione della s.p. "+
										LT.Text +"("+ LO.Tag.ToString()+").",
										err);
					}
				}				
				progBar.Value=tableexamined;
				//Application.DoEvents();


			}
			this.Focus();
			MessageBox.Show("Ricompilazione eseguita con successo", "Info",
				MessageBoxButtons.OK, MessageBoxIcon.Information);
			DialogResult = DialogResult.OK;
			Close();

		}


		private void btnStop_Click(object sender, System.EventArgs e) {
			if (MessageBox.Show(this,"Si è sicuri di voler interrompere l'operazione?","Conferma operazione",
				 MessageBoxButtons.YesNo)== DialogResult.Yes) MustStop=true;
				 
		}




	}
}
