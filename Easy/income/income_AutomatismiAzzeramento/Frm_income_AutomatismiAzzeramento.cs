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
using System.Data;
using metadatalibrary;

namespace income_AutomatismiAzzeramento//Entrata_AutomatismiAzzeramento//
{
	/// <summary>
	/// Summary description for frmAutomatismiAzzeramentoEntrata.
	/// </summary>
	public class frm_income_AutomatismiAzzeramento : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.DataGrid gridvariazioni;
	
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frm_income_AutomatismiAzzeramento(DataTable AutoVar) {
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			
			MetaData.DescribeAColumn(AutoVar,"nphase","");
			MetaData.DescribeAColumn(AutoVar,"phase","Fase");
			MetaData.DescribeAColumn(AutoVar,"idinc","");
			MetaData.DescribeAColumn(AutoVar,"ymov","Eserc.Movimento");
			MetaData.DescribeAColumn(AutoVar,"nmov","Num.Movimento");
			MetaData.DescribeAColumn(AutoVar,"description","Descrizione");
			MetaData.DescribeAColumn(AutoVar,"amount","Importo");
			HelpForm.SetDataGrid(gridvariazioni, AutoVar);

			formatgrids FG= new formatgrids(gridvariazioni);
			FG.AutosizeColumnWidth();

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
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.gridvariazioni = new System.Windows.Forms.DataGrid();
			((System.ComponentModel.ISupportInitialize)(this.gridvariazioni)).BeginInit();
			this.SuspendLayout();
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(504, 383);
			this.btnOk.Name = "btnOk";
			this.btnOk.TabIndex = 18;
			this.btnOk.Tag = "mainsave";
			this.btnOk.Text = "Ok";
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(416, 383);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 17;
			this.btnCancel.Text = "Cancel";
			// 
			// gridvariazioni
			// 
			this.gridvariazioni.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.gridvariazioni.DataMember = "";
			this.gridvariazioni.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gridvariazioni.Location = new System.Drawing.Point(8, 15);
			this.gridvariazioni.Name = "gridvariazioni";
			this.gridvariazioni.Size = new System.Drawing.Size(576, 352);
			this.gridvariazioni.TabIndex = 16;
			// 
			// frmAutomatismiAzzeramentoEntrata
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(592, 421);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.gridvariazioni);
			this.Name = "frmAutomatismiAzzeramentoEntrata";
			this.Text = "Variazioni generate automaticamente per azzerare la disponibilità delle fasi prec" +
				"edenti";
			((System.ComponentModel.ISupportInitialize)(this.gridvariazioni)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
	}
}
