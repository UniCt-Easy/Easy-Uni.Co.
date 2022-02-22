
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

namespace CambiaDataContabile//CambiaDataContabile//
{
	/// <summary>
	/// Summary description for frmCambiaDataContabile.
	/// </summary>
	public class frmCambiaDataContabile : MetaDataForm
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtDataContabile;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		DataAccess DataAccessLocale;
		EntityDispatcher E;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmCambiaDataContabile(EntityDispatcher E)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.E = E;
			DataAccessLocale = E.Conn;
			txtDataContabile.Text = ((DateTime)E.GetSys("datacontabile")).ToShortDateString();
			HelpForm.ExtLeaveDateTimeTextBox(txtDataContabile, null);
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			this.txtDataContabile = new System.Windows.Forms.TextBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 40);
			this.label1.Name = "label1";
			this.label1.TabIndex = 0;
			this.label1.Text = "Data contabile:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDataContabile
			// 
			this.txtDataContabile.Location = new System.Drawing.Point(120, 40);
			this.txtDataContabile.Name = "txtDataContabile";
			this.txtDataContabile.TabIndex = 1;
			this.txtDataContabile.Text = "";
			this.txtDataContabile.Leave += new System.EventHandler(this.txtDataContabile_Leave);
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(112, 88);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(200, 88);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Annulla";
			// 
			// frmCambiaDataContabile
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(288, 125);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.txtDataContabile);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "frmCambiaDataContabile";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Modifica data contabile";
			this.ResumeLayout(false);

		}
		#endregion

		private void txtDataContabile_Leave(object sender, System.EventArgs e)
		{
			HelpForm.ExtLeaveDateTimeTextBox(txtDataContabile, null);
		}

		public bool DatiValidi(){
			try {
				DateTime TT = (DateTime) HelpForm.GetObjectFromString(typeof(DateTime),
					txtDataContabile.Text.ToString(), "x.y");
			}
			catch {
				show("E' necessario inserire una data valida");
				txtDataContabile.Focus();
				return false;
			}
            DateTime T = (DateTime)HelpForm.GetObjectFromString(typeof(DateTime),
                    txtDataContabile.Text.ToString(), "x.y");
            int esercizio = T.Year;

            if (esercizio < 2000 || esercizio > 2099) {
                show("L'esercizio " + esercizio + " non è presente.");
                txtDataContabile.Focus();
                return false;
            }

            string filteresercizio = "(ayear=" + QueryCreator.quotedstrvalue(esercizio, true) + ")";
            DataTable EsercizioTable =
                DataAccessLocale.RUN_SELECT("accountingyear", "*", null, filteresercizio, null, true);

            if (EsercizioTable.Rows.Count == 0) {
                show("L'esercizio " + esercizio + " non è stato creato.");
                txtDataContabile.Focus();
                return false;
            }
            return true;
		}
        bool CambioDataConsentita(DataAccess DA, DateTime newDate) {
            object idcustomuser = DA.GetSys("idcustomuser");
            object ayear = newDate.Year;
            if (idcustomuser == DBNull.Value) return true;
            QueryHelper QHS = DA.GetQueryHelper();
            string filterall = QHS.CmpEq("idcustomuser", idcustomuser);
            if (DA.RUN_SELECT_COUNT("flowchartuser", filterall, false) == 0) return true; //fuori dall'organigramma
            string filteranno = QHS.Like("idflowchart", ayear.ToString().Substring(2) + "%");
            string filterdate = QHS.AppAnd(filterall,
                filteranno,
                QHS.NullOrLe("start", newDate), QHS.NullOrGe("stop", newDate));
            if (DA.RUN_SELECT_COUNT("flowchartuser", filterdate, false) == 0) return false;
            object oggi = DA.DO_SYS_CMD("select getdate()");
            string filternow = QHS.AppAnd(filterall, filteranno,
                        QHS.NullOrLe("start", oggi), QHS.NullOrGe("stop", newDate));
            if (DA.RUN_SELECT_COUNT("flowchartuser", filternow, false) == 0) return false;
            return true;
        }

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if (!DatiValidi()) return;
			DateTime TT = (DateTime) HelpForm.GetObjectFromString(typeof(DateTime),
				txtDataContabile.Text.ToString(), "x.y");
		    if (TT == null || ((DateTime) TT).Year > 2099 || ((DateTime) TT).Year < 2000) {
		        show("Data non valida", "Errore");
                return;
		    }
            if (!CambioDataConsentita(DataAccessLocale, TT)) {
                show("Accesso non consentito in tale data in base alla gestione della sicurezza");
                return;

            }

			int CurrentEsercizio = (int)E.GetSys("esercizio");
			E.SetSys("datacontabile",TT);
			E.SetSys("esercizio",TT.Year);
			//DataAccessLocale.SetDataContabile(TT);
			//DataAccessLocale.SetEsercizio(TT.Year);
			if (TT.Year!=CurrentEsercizio)
				show("Avvertimento: l'esercizio è stato automaticamente impostato al "+
					E.GetSys("esercizio").ToString());

			DialogResult = DialogResult.OK;
		}

	}
}
