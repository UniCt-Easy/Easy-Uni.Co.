
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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

namespace parasubcontractsetup_default {//perscontratto//
	/// <summary>
	/// Summary description for frmperscontratto.
	/// </summary>
	public class Frm_parasubcontractsetup_default : System.Windows.Forms.Form {
		public vistaForm DS;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabNumerazione;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		MetaData Meta;
		bool CanGoEdit;
		bool CanGoInsert;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_parasubcontractsetup_default() {
			InitializeComponent();
			CanGoEdit=true;
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

		public void MetaData_AfterClear() {
			if (CanGoInsert) {
				CanGoInsert=false;
				MetaData.DoMainCommand(this, "maininsert");
			}
			if (CanGoEdit) {
				CanGoEdit=false;
				MetaData.DoMainCommand(this, "maindosearch.perscontratto");
			}
		}

		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);

			string filteresercizio= "(ayear='"+Meta.GetSys("esercizio").ToString()+"')";

			int numrigheperscontratto = Meta.Conn.RUN_SELECT_COUNT("parasubcontractsetup",filteresercizio,
				true);
			if (numrigheperscontratto==1) {
				CanGoInsert=false;
				CanGoEdit=true;
			}
			else {
				CanGoInsert=true;
				CanGoEdit=false;
			}
			GetData.SetStaticFilter(DS.parasubcontractsetup,filteresercizio);
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.DS = new parasubcontractsetup_default.vistaForm();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabNumerazione = new System.Windows.Forms.TabPage();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabNumerazione.SuspendLayout();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabNumerazione);
			this.tabControl1.Location = new System.Drawing.Point(8, 8);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(496, 224);
			this.tabControl1.TabIndex = 0;
			// 
			// tabNumerazione
			// 
			this.tabNumerazione.Controls.Add(this.button2);
			this.tabNumerazione.Controls.Add(this.button1);
			this.tabNumerazione.Controls.Add(this.radioButton2);
			this.tabNumerazione.Controls.Add(this.radioButton1);
			this.tabNumerazione.Location = new System.Drawing.Point(4, 22);
			this.tabNumerazione.Name = "tabNumerazione";
			this.tabNumerazione.Size = new System.Drawing.Size(488, 198);
			this.tabNumerazione.TabIndex = 0;
			this.tabNumerazione.Text = "Numerazione";
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button2.Location = new System.Drawing.Point(120, 160);
			this.button2.Name = "button2";
			this.button2.TabIndex = 2;
			this.button2.Tag = "mainsave";
			this.button2.Text = "Ok";
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button1.Location = new System.Drawing.Point(280, 160);
			this.button1.Name = "button1";
			this.button1.TabIndex = 3;
			this.button1.Text = "Annulla";
			// 
			// radioButton2
			// 
			this.radioButton2.Location = new System.Drawing.Point(24, 64);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.TabIndex = 1;
			this.radioButton2.Tag = "parasubcontractsetup.numerationkind:A";
			this.radioButton2.Text = "Automatica";
			// 
			// radioButton1
			// 
			this.radioButton1.Location = new System.Drawing.Point(24, 24);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.TabIndex = 0;
			this.radioButton1.Tag = "parasubcontractsetup.numerationkind:M";
			this.radioButton1.Text = "Manuale";
			// 
			// Frm_parasubcontractsetup_default
			// 
			this.AcceptButton = this.button2;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.button1;
			this.ClientSize = new System.Drawing.Size(512, 238);
			this.Controls.Add(this.tabControl1);
			this.Name = "Frm_parasubcontractsetup_default";
			this.Text = "frmperscontratto";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabNumerazione.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
	}
}
