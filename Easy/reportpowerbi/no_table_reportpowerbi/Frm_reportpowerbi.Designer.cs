/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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


namespace no_table_reportpowerbi {
	partial class Frm_reportpowerbi {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.DS = new no_table_reportpowerbi.vistaForm();
			this.reportpbi = new Microsoft.Web.WebView2.WinForms.WebView2();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.reportpbi)).BeginInit();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// reportpbi
			// 
			this.reportpbi.AllowExternalDrop = true;
			this.reportpbi.CreationProperties = null;
			this.reportpbi.DefaultBackgroundColor = System.Drawing.Color.White;
			this.reportpbi.Location = new System.Drawing.Point(12, 29);
			this.reportpbi.Name = "reportpbi";
			this.reportpbi.Size = new System.Drawing.Size(1342, 812);
			this.reportpbi.TabIndex = 1;
			this.reportpbi.ZoomFactor = 1D;
			// 
			// Frm_reportpowerbi
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1632, 925);
			this.Controls.Add(this.reportpbi);
			this.Name = "Frm_reportpowerbi";
			this.Text = "Frm_reportpowerbi";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.reportpbi)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		public vistaForm DS;
		private Microsoft.Web.WebView2.WinForms.WebView2 reportpbi;
	}
}