
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
using System.Data;
using metadatalibrary;

namespace BackupRestore//BackupRestore//
{
	/// <summary>
	/// Summary description for frmInfo.
	/// </summary>
	public class frmInfo : MetaDataForm
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtDesc;
		private System.Windows.Forms.Label lblNome;
		private System.Windows.Forms.Label lblDataInizio;
		private System.Windows.Forms.Label lblDataFine;
		private System.Windows.Forms.Label lblServer;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Label lblSize;
		private System.Windows.Forms.Label lblTipo;
		private System.Windows.Forms.Label label8;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmInfo(DataRow row, bool RestoreFromDB)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			if (row==null) return;
			if (RestoreFromDB) {
				lblNome.Text=row["name"].ToString();
				txtDesc.Text=row["description"].ToString();
				lblTipo.Text=row["tipo"].ToString();
				lblSize.Text=row["backup_size"].ToString()+" byte";
				lblDataInizio.Text=row["backup_start_date"].ToString();
				lblDataFine.Text=row["backup_finish_date"].ToString();
				lblServer.Text=row["server_name"].ToString();
			}
			else {
				lblNome.Text=row["BackupName"].ToString();
				txtDesc.Text=row["BackupDescription"].ToString();
				lblTipo.Text=row["tipo"].ToString();
				lblSize.Text=row["BackupSize"].ToString()+" byte";
				lblDataInizio.Text=row["BackupStartDate"].ToString();
				lblDataFine.Text=row["BackupFinishDate"].ToString();
				lblServer.Text=row["ServerName"].ToString();
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
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.txtDesc = new System.Windows.Forms.TextBox();
			this.lblNome = new System.Windows.Forms.Label();
			this.lblDataInizio = new System.Windows.Forms.Label();
			this.lblDataFine = new System.Windows.Forms.Label();
			this.lblServer = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.lblSize = new System.Windows.Forms.Label();
			this.lblTipo = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Nome";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Descrizione";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 128);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 23);
			this.label3.TabIndex = 2;
			this.label3.Text = "Dimensioni";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 152);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(80, 23);
			this.label4.TabIndex = 3;
			this.label4.Text = "Data inizio";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 176);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(80, 23);
			this.label5.TabIndex = 4;
			this.label5.Text = "Data fine";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(16, 200);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(80, 23);
			this.label6.TabIndex = 5;
			this.label6.Text = "Nome server";
			// 
			// txtDesc
			// 
			this.txtDesc.Location = new System.Drawing.Point(96, 40);
			this.txtDesc.Multiline = true;
			this.txtDesc.Name = "txtDesc";
			this.txtDesc.ReadOnly = true;
			this.txtDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDesc.Size = new System.Drawing.Size(296, 48);
			this.txtDesc.TabIndex = 7;
			this.txtDesc.Text = "";
			// 
			// lblNome
			// 
			this.lblNome.Location = new System.Drawing.Point(96, 16);
			this.lblNome.Name = "lblNome";
			this.lblNome.Size = new System.Drawing.Size(192, 23);
			this.lblNome.TabIndex = 8;
			// 
			// lblDataInizio
			// 
			this.lblDataInizio.Location = new System.Drawing.Point(96, 152);
			this.lblDataInizio.Name = "lblDataInizio";
			this.lblDataInizio.Size = new System.Drawing.Size(192, 23);
			this.lblDataInizio.TabIndex = 10;
			// 
			// lblDataFine
			// 
			this.lblDataFine.Location = new System.Drawing.Point(96, 176);
			this.lblDataFine.Name = "lblDataFine";
			this.lblDataFine.Size = new System.Drawing.Size(192, 23);
			this.lblDataFine.TabIndex = 11;
			// 
			// lblServer
			// 
			this.lblServer.Location = new System.Drawing.Point(96, 200);
			this.lblServer.Name = "lblServer";
			this.lblServer.Size = new System.Drawing.Size(192, 23);
			this.lblServer.TabIndex = 12;
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(166, 240);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 13;
			this.btnOK.Text = "OK";
			// 
			// lblSize
			// 
			this.lblSize.Location = new System.Drawing.Point(96, 128);
			this.lblSize.Name = "lblSize";
			this.lblSize.Size = new System.Drawing.Size(192, 23);
			this.lblSize.TabIndex = 9;
			// 
			// lblTipo
			// 
			this.lblTipo.Location = new System.Drawing.Point(96, 104);
			this.lblTipo.Name = "lblTipo";
			this.lblTipo.Size = new System.Drawing.Size(192, 23);
			this.lblTipo.TabIndex = 15;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(16, 104);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(80, 23);
			this.label8.TabIndex = 14;
			this.label8.Text = "Tipo";
			// 
			// frmInfo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(406, 284);
			this.Controls.Add(this.lblTipo);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.lblServer);
			this.Controls.Add(this.lblDataFine);
			this.Controls.Add(this.lblDataInizio);
			this.Controls.Add(this.lblSize);
			this.Controls.Add(this.lblNome);
			this.Controls.Add(this.txtDesc);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.Name = "frmInfo";
			this.Text = "Proprietà del set di backup";
			this.ResumeLayout(false);

		}
		#endregion

	}
}
