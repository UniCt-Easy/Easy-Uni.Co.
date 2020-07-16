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
using System.Data;
using metadatalibrary;

namespace finvar_default {//VariazioneBilancio//
	/// <summary>
	/// Summary description for frmAutomatismi.
	/// </summary>
	public class frmAutomatismi : System.Windows.Forms.Form {
		private System.Windows.Forms.Button btnChiudi;
		private System.Windows.Forms.DataGrid gridAuto;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmAutomatismi(DataSet DS) {
			InitializeComponent();
			Init(DS);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if(components != null) {
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
		private void InitializeComponent() {
			this.btnChiudi = new System.Windows.Forms.Button();
			this.gridAuto = new System.Windows.Forms.DataGrid();
			((System.ComponentModel.ISupportInitialize)(this.gridAuto)).BeginInit();
			this.SuspendLayout();
			// 
			// btnChiudi
			// 
			this.btnChiudi.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnChiudi.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnChiudi.Location = new System.Drawing.Point(200, 288);
			this.btnChiudi.Name = "btnChiudi";
			this.btnChiudi.Size = new System.Drawing.Size(72, 24);
			this.btnChiudi.TabIndex = 0;
			this.btnChiudi.Text = "Chiudi";
			// 
			// gridAuto
			// 
			this.gridAuto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.gridAuto.CaptionVisible = false;
			this.gridAuto.DataMember = "";
			this.gridAuto.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gridAuto.Location = new System.Drawing.Point(16, 16);
			this.gridAuto.Name = "gridAuto";
			this.gridAuto.Size = new System.Drawing.Size(448, 256);
			this.gridAuto.TabIndex = 1;
			// 
			// frmAutomatismi
			// 
			this.AcceptButton = this.btnChiudi;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(478, 324);
			this.Controls.Add(this.gridAuto);
			this.Controls.Add(this.btnChiudi);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.Name = "frmAutomatismi";
			this.Text = "Automatismi salvati";
			((System.ComponentModel.ISupportInitialize)(this.gridAuto)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void CopiaRiga(DataRow NewRow, DataRow R) {
			NewRow["yvar"]=R["yvar"];
			NewRow["nvar"]=R["nvar"];
			NewRow["description"]=R["description"];
			NewRow["variationkind"]=R["variationkind"];
			NewRow["enactment"]=R["enactment"];
			NewRow["nenactment"]=R["nenactment"];
			NewRow["enactmentdate"]=R["enactementdate"];
		}

		private void Init(DataSet DS) {
			DataTable T=new DataTable("automatismi");
			T.Columns.Add("autokind",typeof(string));
			T.Columns["autokind"].Caption="Tipo automatismo";
			T.Columns.Add("yvar",typeof(int));
			T.Columns["yvar"].Caption="Esercizio";
			T.Columns.Add("nvar",typeof(int));
			T.Columns["nvar"].Caption="Numero";
			T.Columns.Add("description",typeof(string));
			T.Columns["description"].Caption="Descrizione";
			T.Columns.Add("variationkind",typeof(string));
			T.Columns["variationkind"].Caption="Tipo variazione";
			T.Columns.Add("enactment",typeof(string));
			T.Columns["enactment"].Caption="Provvedimento";
			T.Columns.Add("nenactment",typeof(string));
			T.Columns["nenactment"].Caption="Num. provvedimento";
			T.Columns.Add("enactmentdate",typeof(DateTime));
			T.Columns["enactmentdate"].Caption="Data provv.";
			DS.Tables.Add(T);
			foreach (DataRow R in DS.Tables["proceedsvar"].Select()) {
				DataRow NewRow=T.NewRow();
				NewRow["autokind"]="Variazione cassa";
				CopiaRiga(NewRow,R);
				T.Rows.Add(NewRow);
			}
			foreach (DataRow R in DS.Tables["creditvar"].Select()) {
				DataRow NewRow=T.NewRow();
				NewRow["autokind"]="Variazione crediti";
				CopiaRiga(NewRow,R);
				T.Rows.Add(NewRow);
			}
			HelpForm.SetDataGrid(gridAuto,T);
		}
	}
}