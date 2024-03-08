
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

namespace invoice_default {
	/// <summary>
	/// Summary description for FrmAskFase.
	/// </summary>
	public class FrmAskInfoIva : MetaDataForm {
		public System.Windows.Forms.ComboBox cmbIvakind;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
        private TextBox txtDescrizione;
        private TextBox txtImporto;
        private Label label2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        public FrmAskInfoIva (DataTable Ivakind, object amount, object description) {
			InitializeComponent();
            cmbIvakind.DataSource = Ivakind;
            cmbIvakind.ValueMember = "idivakind";
            cmbIvakind.DisplayMember = "description";
            txtDescrizione.Text = description.ToString();
            txtImporto.Text = amount.ToString();
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.cmbIvakind = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.txtImporto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(395, 138);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(283, 138);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "Ok";
            // 
            // cmbIvakind
            // 
            this.cmbIvakind.Location = new System.Drawing.Point(19, 91);
            this.cmbIvakind.Name = "cmbIvakind";
            this.cmbIvakind.Size = new System.Drawing.Size(272, 21);
            this.cmbIvakind.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 22);
            this.label1.TabIndex = 8;
            this.label1.Text = "Seleziona il tipo IVA per la spesa";
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Location = new System.Drawing.Point(19, 31);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.ReadOnly = true;
            this.txtDescrizione.Size = new System.Drawing.Size(272, 44);
            this.txtDescrizione.TabIndex = 12;
            this.txtDescrizione.TabStop = false;
            this.txtDescrizione.Tag = "";
            // 
            // txtImporto
            // 
            this.txtImporto.Location = new System.Drawing.Point(306, 31);
            this.txtImporto.Multiline = true;
            this.txtImporto.Name = "txtImporto";
            this.txtImporto.ReadOnly = true;
            this.txtImporto.Size = new System.Drawing.Size(136, 21);
            this.txtImporto.TabIndex = 13;
            this.txtImporto.TabStop = false;
            this.txtImporto.Tag = "";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(308, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "Importo";
            // 
            // FrmAskInfoIva
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(487, 170);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtImporto);
            this.Controls.Add(this.txtDescrizione);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cmbIvakind);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "FrmAskInfoIva";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Selezione Tipo Iva";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAskInfoIva_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
        #endregion

        private void FrmAskInfoIva_FormClosing(object sender, FormClosingEventArgs e) {
            this.ActiveControl = null;
        }
    }
}
