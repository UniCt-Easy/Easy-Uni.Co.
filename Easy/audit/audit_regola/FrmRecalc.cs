/*
    Easy
    Copyright (C) 2020 Universit√† degli Studi di Catania (www.unict.it)
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
//using ViewError;//ViewError


namespace audit_regola//businessrule//
{
	/// <summary>
	/// Summary description for FrmRecalc.
	/// </summary>
	public class FrmRecalc : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnStop;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ProgressBar progBar;
		private System.Windows.Forms.TextBox txtTable;
		private System.Windows.Forms.Label label1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		DataAccess Conn;
		bool MustStop;
		bool Running;
		int counttables;
		int tableexamined;
		DataTable ToRecalc;
        string filterrule;

		public FrmRecalc(DataAccess Conn, DataTable ToRecalc,string filterrule) {
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			this.Conn=Conn;
			this.ToRecalc = ToRecalc;
            this.filterrule = filterrule;

			MustStop=false;
			Running=false;

			counttables=ToRecalc.Rows.Count;

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
			this.btnStop = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.progBar = new System.Windows.Forms.ProgressBar();
			this.txtTable = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnStop
			// 
			this.btnStop.Location = new System.Drawing.Point(144, 128);
			this.btnStop.Name = "btnStop";
			this.btnStop.TabIndex = 9;
			this.btnStop.Text = "Interrompi";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(168, 23);
			this.label2.TabIndex = 8;
			this.label2.Text = "Stato di avanzamento";
			// 
			// progBar
			// 
			this.progBar.Location = new System.Drawing.Point(8, 88);
			this.progBar.Name = "progBar";
			this.progBar.Size = new System.Drawing.Size(336, 23);
			this.progBar.Step = 1;
			this.progBar.TabIndex = 7;
			// 
			// txtTable
			// 
			this.txtTable.Location = new System.Drawing.Point(8, 24);
			this.txtTable.Name = "txtTable";
			this.txtTable.Size = new System.Drawing.Size(232, 20);
			this.txtTable.TabIndex = 6;
			this.txtTable.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(192, 23);
			this.label1.TabIndex = 5;
			this.label1.Text = "Tabella in elaborazione";
			// 
			// FrmRecalc
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(360, 173);
			this.Controls.Add(this.btnStop);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.progBar);
			this.Controls.Add(this.txtTable);
			this.Controls.Add(this.label1);
			this.Name = "FrmRecalc";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FrmRecalc";
			this.ResumeLayout(false);

		}
		#endregion

		public void Run(){
			if (Running) return;
			Running=true;
        
			tableexamined=0;
			foreach(DataRow R in ToRecalc.Rows){

				if (MustStop) {
					DialogResult = DialogResult.Cancel;
					Close();
					return;
				}

				tableexamined++;
				txtTable.Text = R["tablename"].ToString();

				
//				RecalcRule(Conn, R["dbtable"].ToString(), R["dboperation"].ToString());
				string err = EasyAudits.RecalcAudit(Conn, R["tablename"].ToString(), R["opkind"].ToString(),filterrule);
					if (err!=null) {
						QueryCreator.ShowError(this,"Errore nella compilazione della s.p. "+
										R["tablename"].ToString()+"("+R["opkind"].ToString()+").",
										err);
					}

				progBar.Value=tableexamined;
				//Application.DoEvents();
			}
			//MessageBox.Show("Ricompilazione eseguita con successo");
			DialogResult = DialogResult.OK;
			Close();

		}


		private void btnStop_Click(object sender, System.EventArgs e) {
			if (MessageBox.Show(this,"Si Ë sicuri di voler interrompere l'operazione?","Conferma operazione",
				MessageBoxButtons.YesNo)== DialogResult.Yes) MustStop=true;
				 
		}



	}
}
