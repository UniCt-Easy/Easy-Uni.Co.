
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
using System.Data;

namespace trasmissioneritenute//trasmissioneritenute//
{
	/// <summary>
	/// Summary description for SubForm.
	/// </summary>
	public class SubForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabCredDeb;
		private System.Windows.Forms.TabPage tabRitenute;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DataGrid dataGrid2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SubForm(DataTable tabCreditoriErrati, DataTable tabRitenuteErrate)
		{
			InitializeComponent();
			if (tabCreditoriErrati.Rows.Count == 0)
			{
				tabControl1.Controls.Remove(tabCredDeb);
			}
			else
			{
				HelpForm.SetDataGrid(dataGrid1, tabCreditoriErrati);
			}
			if (tabRitenuteErrate.Rows.Count == 0)
			{
				tabControl1.Controls.Remove(tabRitenute);
			}
			else
			{
				HelpForm.SetDataGrid(dataGrid2, tabRitenuteErrate);
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
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabCredDeb = new System.Windows.Forms.TabPage();
			this.tabRitenute = new System.Windows.Forms.TabPage();
			this.label2 = new System.Windows.Forms.Label();
			this.dataGrid2 = new System.Windows.Forms.DataGrid();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabCredDeb.SuspendLayout();
			this.tabRitenute.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGrid1
			// 
			this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(8, 24);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(624, 240);
			this.dataGrid1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(624, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Non è possibile effettuare la trasmissione delle ritenute se non si correggono i " +
				"dati anagrafici dei seguenti creditori/debitori:";
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Location = new System.Drawing.Point(280, 320);
			this.button1.Name = "button1";
			this.button1.TabIndex = 2;
			this.button1.Text = "OK";
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabCredDeb);
			this.tabControl1.Controls.Add(this.tabRitenute);
			this.tabControl1.Location = new System.Drawing.Point(8, 8);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(648, 304);
			this.tabControl1.TabIndex = 3;
			// 
			// tabCredDeb
			// 
			this.tabCredDeb.Controls.Add(this.label1);
			this.tabCredDeb.Controls.Add(this.dataGrid1);
			this.tabCredDeb.Location = new System.Drawing.Point(4, 22);
			this.tabCredDeb.Name = "tabCredDeb";
			this.tabCredDeb.Size = new System.Drawing.Size(640, 278);
			this.tabCredDeb.TabIndex = 0;
			this.tabCredDeb.Text = "Creditori/Debitori";
			// 
			// tabRitenute
			// 
			this.tabRitenute.Controls.Add(this.dataGrid2);
			this.tabRitenute.Controls.Add(this.label2);
			this.tabRitenute.Location = new System.Drawing.Point(4, 22);
			this.tabRitenute.Name = "tabRitenute";
			this.tabRitenute.Size = new System.Drawing.Size(640, 278);
			this.tabRitenute.TabIndex = 1;
			this.tabRitenute.Text = "Ritenute";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.label2.Location = new System.Drawing.Point(8, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(624, 32);
			this.label2.TabIndex = 2;
			this.label2.Text = "Non è possibile effettuare la trasmissione delle ritenute se non si correggono i " +
				"dati inerenti le ritenute:";
			// 
			// dataGrid2
			// 
			this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid2.DataMember = "";
			this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid2.Location = new System.Drawing.Point(8, 27);
			this.dataGrid2.Name = "dataGrid2";
			this.dataGrid2.Size = new System.Drawing.Size(624, 237);
			this.dataGrid2.TabIndex = 3;
			// 
			// SubForm
			// 
			this.AcceptButton = this.button1;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(664, 350);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.button1);
			this.Name = "SubForm";
			this.Text = "Elenco Errori";
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabCredDeb.ResumeLayout(false);
			this.tabRitenute.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
	}
}
