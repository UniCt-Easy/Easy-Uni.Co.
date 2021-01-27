
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
using funzioni_configurazione;//funzioni_configurazione

namespace profservicesetup_default//perscontrattoprof//
{
	/// <summary>
	/// Summary description for frmperscontrattoprof.
	/// </summary>
	public class Frm_profservicesetup_default : System.Windows.Forms.Form
	{
		public vistaForm DS;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabNumerazione;
		private System.Windows.Forms.CheckBox chkAzzera;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.RadioButton rdbAutomatica;
		private System.Windows.Forms.RadioButton rdbManuale;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		MetaData Meta;
		bool CanGoEdit;
		bool CanGoInsert;

		public Frm_profservicesetup_default()
		{
			InitializeComponent();
			HelpForm.SetDenyNull(DS.profservicesetup.Columns["flagrestart"], true);
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

		public void MetaData_AfterClear()
		{
			if (CanGoInsert) 
			{
				CanGoInsert=false;
				MetaData.DoMainCommand(this, "maininsert");
			}
			if (CanGoEdit) 
			{
				CanGoEdit=false;
				MetaData.DoMainCommand(this, "maindosearch.perscontrattoprof");
			}
		}

		public void MetaData_AfterLink() 
		{
			Meta = MetaData.GetMetaData(this);

			string filteresercizio= "(ayear='"+Meta.GetSys("esercizio").ToString()+"')";

			int numrigheperscontratto = Meta.Conn.RUN_SELECT_COUNT("profservicesetup",filteresercizio,
				true);
			if (numrigheperscontratto==1) 
			{
				CanGoInsert=false;
				CanGoEdit=true;
			}
			else 
			{
				CanGoInsert=true;
				CanGoEdit=false;
			}
			GetData.SetStaticFilter(DS.profservicesetup,filteresercizio);
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.DS = new vistaForm();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabNumerazione = new System.Windows.Forms.TabPage();
			this.chkAzzera = new System.Windows.Forms.CheckBox();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.rdbAutomatica = new System.Windows.Forms.RadioButton();
			this.rdbManuale = new System.Windows.Forms.RadioButton();
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
			this.tabControl1.Location = new System.Drawing.Point(4, 5);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(424, 248);
			this.tabControl1.TabIndex = 3;
			// 
			// tabNumerazione
			// 
			this.tabNumerazione.Controls.Add(this.chkAzzera);
			this.tabNumerazione.Controls.Add(this.button2);
			this.tabNumerazione.Controls.Add(this.button1);
			this.tabNumerazione.Controls.Add(this.rdbAutomatica);
			this.tabNumerazione.Controls.Add(this.rdbManuale);
			this.tabNumerazione.Location = new System.Drawing.Point(4, 22);
			this.tabNumerazione.Name = "tabNumerazione";
			this.tabNumerazione.Size = new System.Drawing.Size(416, 222);
			this.tabNumerazione.TabIndex = 0;
			this.tabNumerazione.Text = "Numerazione";
			// 
			// chkAzzera
			// 
			this.chkAzzera.Location = new System.Drawing.Point(256, 24);
			this.chkAzzera.Name = "chkAzzera";
			this.chkAzzera.Size = new System.Drawing.Size(152, 24);
			this.chkAzzera.TabIndex = 4;
			this.chkAzzera.Tag = "profservicesetup.flagrestart:S:N";
			this.chkAzzera.Text = "Azzera ad ogni esercizio";
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button2.Location = new System.Drawing.Point(192, 184);
			this.button2.Name = "button2";
			this.button2.TabIndex = 3;
			this.button2.Tag = "mainsave";
			this.button2.Text = "Ok";
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button1.Location = new System.Drawing.Point(312, 184);
			this.button1.Name = "button1";
			this.button1.TabIndex = 2;
			this.button1.Text = "Annulla";
			// 
			// rdbAutomatica
			// 
			this.rdbAutomatica.Location = new System.Drawing.Point(16, 24);
			this.rdbAutomatica.Name = "rdbAutomatica";
			this.rdbAutomatica.TabIndex = 1;
			this.rdbAutomatica.Tag = "profservicesetup.flagnumbering:A";
			this.rdbAutomatica.Text = "Automatica";
			this.rdbAutomatica.CheckedChanged += new System.EventHandler(this.rdbAutomatica_CheckedChanged);
			// 
			// rdbManuale
			// 
			this.rdbManuale.Location = new System.Drawing.Point(16, 72);
			this.rdbManuale.Name = "rdbManuale";
			this.rdbManuale.TabIndex = 0;
			this.rdbManuale.Tag = "profservicesetup.flagnumbering:M";
			this.rdbManuale.Text = "Manuale";
			this.rdbManuale.CheckedChanged += new System.EventHandler(this.rdbManuale_CheckedChanged);
			// 
			// frmperscontrattoprof
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(440, 266);
			this.Controls.Add(this.tabControl1);
			this.Name = "frmperscontrattoprof";
			this.Text = "frmperscontrattoprof";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabNumerazione.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void rdbAutomatica_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rdbAutomatica.Checked)
			{
				chkAzzera.Enabled = true;
			}
		}

		private void rdbManuale_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rdbManuale.Checked)
			{
				chkAzzera.Checked = false;
				chkAzzera.Enabled = false;
			}
		}
	}
}
