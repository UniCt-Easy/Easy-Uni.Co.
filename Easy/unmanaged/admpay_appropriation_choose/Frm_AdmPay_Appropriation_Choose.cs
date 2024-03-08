
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

namespace admpay_appropriation_choose
{
	/// <summary>
	/// Summary description for Frm_AdmPay_Appropriation_Choose.
	/// </summary>
	public class Frm_AdmPay_Appropriation_Choose : MetaDataForm
	{
		DataTable Impegnativa;
		MetaData Meta;
		DataSet DS;
		public DataRow Choosen;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnAnnulla;
		private System.Windows.Forms.DataGrid dgImpegnative;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_AdmPay_Appropriation_Choose(DataTable ListaImpegnative, MetaData Parent) {
			InitializeComponent();
			this.Text = "Scelta dell'Impegnativa";
			this.Meta = Parent;
			this.Impegnativa = ListaImpegnative;
			this.DS = Impegnativa.DataSet;
			
			MetaData MImpegnativa = Meta.Dispatcher.Get("admpay_appropriationview");
			MImpegnativa.DescribeColumns(Impegnativa, "default");
			HelpForm.SetDataGrid(dgImpegnative, Impegnativa);
			formatgrids FGImpegnativa = new formatgrids(dgImpegnative);
			FGImpegnativa.AutosizeColumnWidth();
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
			this.dgImpegnative = new System.Windows.Forms.DataGrid();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnAnnulla = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgImpegnative)).BeginInit();
			this.SuspendLayout();
			// 
			// dgImpegnative
			// 
			this.dgImpegnative.AllowNavigation = false;
			this.dgImpegnative.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dgImpegnative.DataMember = "";
			this.dgImpegnative.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgImpegnative.Location = new System.Drawing.Point(8, 8);
			this.dgImpegnative.Name = "dgImpegnative";
			this.dgImpegnative.Size = new System.Drawing.Size(568, 288);
			this.dgImpegnative.TabIndex = 0;
			this.dgImpegnative.DoubleClick += new System.EventHandler(this.dgImpegnative_DoubleClick);
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(368, 304);
			this.btnOk.Name = "btnOk";
			this.btnOk.TabIndex = 1;
			this.btnOk.Text = "Ok";
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnAnnulla.Location = new System.Drawing.Point(496, 304);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.TabIndex = 2;
			this.btnAnnulla.Text = "Annulla";
			// 
			// Frm_AdmPay_Appropriation_Choose
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(584, 342);
			this.Controls.Add(this.btnAnnulla);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.dgImpegnative);
			this.Name = "Frm_AdmPay_Appropriation_Choose";
			this.Text = "Frm_AdmPay_Appropriation_Choose";
			((System.ComponentModel.ISupportInitialize)(this.dgImpegnative)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void btnOk_Click(object sender, System.EventArgs e) {
			Choosen = selezioneRiga();
		}

		private DataRow selezioneRiga() {
			string dataMember = dgImpegnative.DataMember;
			CurrencyManager cm = (CurrencyManager) dgImpegnative.BindingContext[DS, dataMember];
			DataView view = cm.List as DataView;
			if (view == null) return null;
			int rigaSelezionata = getRigaSelezionata(view);
			if (rigaSelezionata == -1) return null;
			DataRowView rChoosenView = view[rigaSelezionata];
			// Attenzione filtro solo x nappropriation in quanto tutte le impegnative
			// hanno gli altri 2 campi che compongono la chiave uguali
            CQueryHelper QHC = new CQueryHelper();
			string filtro = QHC.CmpEq("nappropriation", rChoosenView["nappropriation"]);
			DataRow [] rChoosen = Impegnativa.Select(filtro);
			return (rChoosen.Length > 0) ? rChoosen[0] : null;
		}

		private int getRigaSelezionata(DataView view) {
			for (int i=0; i<view.Count; i++) {
				if (dgImpegnative.IsSelected(i)) {
					return i;
				}
			}
			return -1;
		}

		private void dgImpegnative_DoubleClick(object sender, System.EventArgs e) {
			Choosen = selezioneRiga();
			this.DialogResult = (Choosen != null) ? DialogResult.OK : DialogResult.Cancel;
			this.Close();
		}
	}
}
