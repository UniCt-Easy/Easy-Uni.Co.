
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

namespace AskDate//AskDate//
{
	/// <summary>
	/// Descrizione di riepilogo per frmAskDate.
	/// </summary>
	public class frmAskDate : MetaDataForm
	{
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label CustomLabel;
		public System.Windows.Forms.TextBox txtData;
		/// <summary>
		/// Variabile di progettazione necessaria.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmAskDate(string Label, string Caption)
		{
			//
			// Necessario per il supporto di Progettazione Windows Form
			//
			InitializeComponent();
			CustomLabel.Text= Label;
			Text= Caption;
		}

		/// <summary>
		/// Pulire le risorse in uso.
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
		/// Metodo necessario per il supporto della finestra di progettazione. Non modificare
		/// il contenuto del metodo con l'editor di codice.
		/// </summary>
		private void InitializeComponent()
		{
			this.CustomLabel = new System.Windows.Forms.Label();
			this.txtData = new System.Windows.Forms.TextBox();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// CustomLabel
			// 
			this.CustomLabel.Location = new System.Drawing.Point(16, 16);
			this.CustomLabel.Name = "CustomLabel";
			this.CustomLabel.Size = new System.Drawing.Size(264, 23);
			this.CustomLabel.TabIndex = 0;
			this.CustomLabel.Text = "Inserire filtro SQL da applicare all\'operazione";
			// 
			// txtData
			// 
			this.txtData.Location = new System.Drawing.Point(16, 32);
			this.txtData.Name = "txtData";
			this.txtData.TabIndex = 1;
			this.txtData.Text = "";
			// 
			// btnOk
			// 
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(168, 80);
			this.btnOk.Name = "btnOk";
			this.btnOk.TabIndex = 2;
			this.btnOk.Text = "Ok";
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(48, 80);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Cancel";
			// 
			// frmAskDate
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(292, 133);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnCancel,
																		  this.btnOk,
																		  this.txtData,
																		  this.CustomLabel});
			this.Name = "frmAskDate";
			this.Text = "frmAskDate";
			this.ResumeLayout(false);

		}
		#endregion
	}
}
