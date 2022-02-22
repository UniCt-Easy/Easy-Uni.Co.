
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
using System.Data;

namespace SituazioneViewer//SituazioneViewer//
{
	/// <summary>
	/// Summary description for frmSituazioneViewer.
	/// </summary>
	public class frmSituazioneViewer : MetaDataForm
	{
		private System.Windows.Forms.ListView head_list;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ListView sit_list;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.Button btnExcelBilancio;
		DataSet DS;
        private Button button1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmSituazioneViewer(DataSet DS)
		{
			InitializeComponent();
			this.DS =DS;
			Cursor.Current=Cursors.WaitCursor;
			exportclass.SituazioneToListView(head_list,sit_list, DS.Tables[0]);
			Cursor.Current=Cursors.Default;
			frmSituazioneViewer_Resize(null,null);

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
            this.head_list = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sit_list = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnExcelBilancio = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // head_list
            // 
            this.head_list.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.head_list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader4});
            this.head_list.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.head_list.GridLines = true;
            this.head_list.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.head_list.LabelWrap = false;
            this.head_list.Location = new System.Drawing.Point(8, 40);
            this.head_list.Name = "head_list";
            this.head_list.Scrollable = false;
            this.head_list.Size = new System.Drawing.Size(570, 144);
            this.head_list.TabIndex = 22;
            this.head_list.UseCompatibleStateImageBehavior = false;
            this.head_list.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 0;
            // 
            // columnHeader4
            // 
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 650;
            // 
            // sit_list
            // 
            this.sit_list.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sit_list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3});
            this.sit_list.GridLines = true;
            this.sit_list.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.sit_list.LabelWrap = false;
            this.sit_list.Location = new System.Drawing.Point(8, 190);
            this.sit_list.Name = "sit_list";
            this.sit_list.Size = new System.Drawing.Size(570, 341);
            this.sit_list.TabIndex = 21;
            this.sit_list.UseCompatibleStateImageBehavior = false;
            this.sit_list.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 370;
            // 
            // columnHeader3
            // 
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader3.Width = 180;
            // 
            // btnExcelBilancio
            // 
            this.btnExcelBilancio.Location = new System.Drawing.Point(8, 8);
            this.btnExcelBilancio.Name = "btnExcelBilancio";
            this.btnExcelBilancio.Size = new System.Drawing.Size(72, 23);
            this.btnExcelBilancio.TabIndex = 20;
            this.btnExcelBilancio.Text = "Excel";
            this.btnExcelBilancio.Click += new System.EventHandler(this.btnExcelBilancio_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(97, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 23);
            this.button1.TabIndex = 23;
            this.button1.Text = "CSV";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmSituazioneViewer
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(586, 544);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.head_list);
            this.Controls.Add(this.sit_list);
            this.Controls.Add(this.btnExcelBilancio);
            this.Name = "frmSituazioneViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Situazione";
            this.SizeChanged += new System.EventHandler(this.frmSituazioneViewer_Resize);
            this.Resize += new System.EventHandler(this.frmSituazioneViewer_Resize);
            this.ResumeLayout(false);

		}
		#endregion

		private void btnExcelBilancio_Click(object sender, System.EventArgs e) {
			if (DS.Tables[0].TableName.Length > 31) 
			{
				DS.Tables[0].TableName = DS.Tables[0].TableName.Substring(0,31);
			}
			exportclass.SituazioneToExcel(DS.Tables[0],false);				
		}


		private void frmSituazioneViewer_Resize(object sender, System.EventArgs e) {
			int newsize= sit_list.Width;
			sit_list.Columns[0].Width= (370*newsize)/570;
			sit_list.Columns[1].Width= (180*newsize)/570;
			head_list.Columns[1].Width= head_list.Width;
		}

        private void button1_Click(object sender, EventArgs e) {
            DataTable T = DS.Tables[0].Copy();
            T.Columns.Remove(T.Columns[2]);
            T.Columns[0].Caption = "Descrizione";
            T.Columns[1].Caption = "Importo";
            T.AcceptChanges();
            exportclass.SaveTableToCSV(T, false);
        }

	}
}
