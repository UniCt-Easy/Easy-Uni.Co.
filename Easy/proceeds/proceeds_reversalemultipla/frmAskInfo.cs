
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
using System.Data;
using metadatalibrary;
using System.Globalization;

namespace proceeds_reversalemultipla
{
	/// <summary>
	/// Summary description for frmaskbban.
	/// </summary>
	public class frmAskInfo : MetaDataForm
	{
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox2;
		public System.Windows.Forms.TextBox txtDataValuta;
		public System.Windows.Forms.TextBox txtDataOperazione;
		public System.Windows.Forms.TextBox txtRifBanca;
		public object dataValuta=DBNull.Value;
		public object dataOperazione=DBNull.Value;
		public object rifBanca=DBNull.Value;
		/// <date>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmAskInfo(int maxLenReference)
		{
			InitializeComponent();
			((TextBox)txtDataOperazione).LostFocus += new System.EventHandler(GeneralLeaveDateTextBox);
			((TextBox)txtDataValuta).LostFocus += new System.EventHandler(GeneralLeaveDateTextBox);
			txtRifBanca.MaxLength = maxLenReference;
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtDataOperazione = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDataValuta = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtRifBanca = new System.Windows.Forms.TextBox();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(168, 168);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Cancel";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(56, 168);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Ok";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtDataOperazione);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtDataValuta);
            this.groupBox3.Location = new System.Drawing.Point(8, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(240, 96);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Date comunicate";
            // 
            // txtDataOperazione
            // 
            this.txtDataOperazione.Location = new System.Drawing.Point(96, 24);
            this.txtDataOperazione.Name = "txtDataOperazione";
            this.txtDataOperazione.Size = new System.Drawing.Size(112, 20);
            this.txtDataOperazione.TabIndex = 1;
            this.txtDataOperazione.Tag = "";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Operazione:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(24, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Valuta:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDataValuta
            // 
            this.txtDataValuta.Location = new System.Drawing.Point(96, 56);
            this.txtDataValuta.Name = "txtDataValuta";
            this.txtDataValuta.Size = new System.Drawing.Size(112, 20);
            this.txtDataValuta.TabIndex = 2;
            this.txtDataValuta.Tag = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtRifBanca);
            this.groupBox2.Location = new System.Drawing.Point(8, 104);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(240, 48);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Riferimenti della banca";
            // 
            // txtRifBanca
            // 
            this.txtRifBanca.Location = new System.Drawing.Point(8, 16);
            this.txtRifBanca.Name = "txtRifBanca";
            this.txtRifBanca.Size = new System.Drawing.Size(224, 20);
            this.txtRifBanca.TabIndex = 0;
            this.txtRifBanca.Tag = "";
            // 
            // frmAskInfo
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(256, 221);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "frmAskInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informazioni Esito";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmAskInfo_Closing);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion
		
		public void GeneralLeaveDateTextBox(object sender, System.EventArgs e){
			TextBox T = (TextBox)sender;
			if (T.IsDisposed) return;
			if (!T.Enabled) return; 
			if (T.ReadOnly) return;
			if (T.Text=="") return;
			string tag= "x.y.d"; 
			string hhsep = CultureInfo.CurrentCulture.DateTimeFormat.TimeSeparator;
			string ppsep = CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator;
			string S = T.Text;
			try {
				object O1 = HelpForm.GetObjectFromString(typeof(DateTime), S, tag);
				if ((O1!=null)&&(O1!=DBNull.Value)){
					T.Text= HelpForm.StringValue(O1, tag);
					return;
				}
			}
			catch{
			}
			S+=hhsep+"0"+ppsep+"0";

			int len = S.Length;
			object O = DBNull.Value;
			while (len>0){
				try {
					O = HelpForm.GetObjectFromString(typeof(DateTime), S, tag);
					if ((O!=null)&&(O!=DBNull.Value)) break;
				}
				catch {
				}
				len=len-1;
				S= S.Substring(0, len);
			}
			T.Text= HelpForm.StringValue(O, tag);
			return;
		}
		

			private void frmAskInfo_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
				if (e.Cancel==true) return;
				if (DialogResult == DialogResult.Cancel) return;
				dataOperazione = HelpForm.GetObjectFromString(typeof(DateTime), txtDataOperazione.Text, "x.y.d");
				dataValuta = HelpForm.GetObjectFromString(typeof(DateTime), txtDataValuta.Text, "x.y.d");
				rifBanca = HelpForm.GetObjectFromString(typeof(String), txtRifBanca.Text, "x.y.d");

				if (dataOperazione==DBNull.Value){
					MetaFactory.factory.getSingleton<IMessageShower>().Show("Selezionare la Data Operazione");
					txtDataOperazione.Focus();
					e.Cancel=true;
					return;
				}
			}

	}
}
