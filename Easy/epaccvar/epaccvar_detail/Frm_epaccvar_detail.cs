
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
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;
using System.Reflection;

namespace epaccvar_detail
{
	/// <summary>
	/// Summary description for Frm_epaccvar_detail.
	/// </summary>
	public class Frm_epaccvar_detail : System.Windows.Forms.Form
	{
		public epaccvar_detail.vistaForm DS;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtEsercVariazione;
        private System.Windows.Forms.TextBox txtNumVariazione;
        private System.Windows.Forms.GroupBox grpVariazione;
		MetaData Meta;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
        public GroupBox grpImporto5;
        private RadioButton radioButton7;
        private RadioButton radioButton8;
        private TextBox textBox1;
        public GroupBox grpImporto4;
        private RadioButton radioButton5;
        private RadioButton radioButton6;
        private TextBox textBox4;
        public GroupBox grpImporto3;
        private RadioButton radioButton3;
        private RadioButton radioButton4;
        private TextBox textBox3;
        public GroupBox grpImporto2;
        private RadioButton radioButton9;
        private RadioButton radioButton10;
        private TextBox textBox2;
        public GroupBox grpImporto1;
        private RadioButton rdbDiminuzione;
        private RadioButton rdbAumento;
        private TextBox txtImporto;
        private TextBox txtTotale;
        private Label label7;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_epaccvar_detail(){
			InitializeComponent();

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ){
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
            this.grpVariazione = new System.Windows.Forms.GroupBox();
            this.txtNumVariazione = new System.Windows.Forms.TextBox();
            this.txtEsercVariazione = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpImporto5 = new System.Windows.Forms.GroupBox();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.grpImporto4 = new System.Windows.Forms.GroupBox();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.grpImporto3 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.grpImporto2 = new System.Windows.Forms.GroupBox();
            this.radioButton9 = new System.Windows.Forms.RadioButton();
            this.radioButton10 = new System.Windows.Forms.RadioButton();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.grpImporto1 = new System.Windows.Forms.GroupBox();
            this.rdbDiminuzione = new System.Windows.Forms.RadioButton();
            this.rdbAumento = new System.Windows.Forms.RadioButton();
            this.txtImporto = new System.Windows.Forms.TextBox();
            this.DS = new epaccvar_detail.vistaForm();
            this.txtTotale = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.grpVariazione.SuspendLayout();
            this.grpImporto5.SuspendLayout();
            this.grpImporto4.SuspendLayout();
            this.grpImporto3.SuspendLayout();
            this.grpImporto2.SuspendLayout();
            this.grpImporto1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // grpVariazione
            // 
            this.grpVariazione.Controls.Add(this.txtNumVariazione);
            this.grpVariazione.Controls.Add(this.txtEsercVariazione);
            this.grpVariazione.Controls.Add(this.label2);
            this.grpVariazione.Controls.Add(this.label1);
            this.grpVariazione.Location = new System.Drawing.Point(16, 8);
            this.grpVariazione.Name = "grpVariazione";
            this.grpVariazione.Size = new System.Drawing.Size(352, 56);
            this.grpVariazione.TabIndex = 0;
            this.grpVariazione.TabStop = false;
            this.grpVariazione.Text = "Variazione";
            // 
            // txtNumVariazione
            // 
            this.txtNumVariazione.Location = new System.Drawing.Point(256, 24);
            this.txtNumVariazione.Name = "txtNumVariazione";
            this.txtNumVariazione.ReadOnly = true;
            this.txtNumVariazione.Size = new System.Drawing.Size(72, 20);
            this.txtNumVariazione.TabIndex = 3;
            this.txtNumVariazione.Tag = "epaccvar.nvar";
            // 
            // txtEsercVariazione
            // 
            this.txtEsercVariazione.Location = new System.Drawing.Point(80, 24);
            this.txtEsercVariazione.Name = "txtEsercVariazione";
            this.txtEsercVariazione.ReadOnly = true;
            this.txtEsercVariazione.Size = new System.Drawing.Size(64, 20);
            this.txtEsercVariazione.TabIndex = 2;
            this.txtEsercVariazione.Tag = "epaccvar.yvar";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(192, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Numero";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Esercizio";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(16, 89);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(478, 67);
            this.textBox5.TabIndex = 2;
            this.textBox5.Tag = "epaccvar.description";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(13, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Descrizione";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(382, 51);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(112, 20);
            this.textBox7.TabIndex = 3;
            this.textBox7.Tag = "epaccvar.adate";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(379, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Data contabile";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(640, 267);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 9;
            this.btnOK.Tag = "mainsave";
            this.btnOK.Text = "OK";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(776, 267);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            // 
            // grpImporto5
            // 
            this.grpImporto5.Controls.Add(this.radioButton7);
            this.grpImporto5.Controls.Add(this.radioButton8);
            this.grpImporto5.Controls.Add(this.textBox1);
            this.grpImporto5.Location = new System.Drawing.Point(700, 161);
            this.grpImporto5.Name = "grpImporto5";
            this.grpImporto5.Size = new System.Drawing.Size(148, 88);
            this.grpImporto5.TabIndex = 8;
            this.grpImporto5.TabStop = false;
            this.grpImporto5.Tag = "epaccvar.amount5.valuesigned";
            this.grpImporto5.Text = "Importo variazione anno";
            // 
            // radioButton7
            // 
            this.radioButton7.Location = new System.Drawing.Point(6, 40);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(104, 21);
            this.radioButton7.TabIndex = 3;
            this.radioButton7.Tag = "-";
            this.radioButton7.Text = "Diminuzione";
            // 
            // radioButton8
            // 
            this.radioButton8.Location = new System.Drawing.Point(6, 19);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(104, 24);
            this.radioButton8.TabIndex = 2;
            this.radioButton8.Tag = "+";
            this.radioButton8.Text = "Aumento";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 62);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(104, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Tag = "epaccvar.amount5";
            this.textBox1.Leave += new System.EventHandler(this.txtImportoLeave);
            // 
            // grpImporto4
            // 
            this.grpImporto4.Controls.Add(this.radioButton5);
            this.grpImporto4.Controls.Add(this.radioButton6);
            this.grpImporto4.Controls.Add(this.textBox4);
            this.grpImporto4.Location = new System.Drawing.Point(534, 161);
            this.grpImporto4.Name = "grpImporto4";
            this.grpImporto4.Size = new System.Drawing.Size(148, 88);
            this.grpImporto4.TabIndex = 7;
            this.grpImporto4.TabStop = false;
            this.grpImporto4.Tag = "epaccvar.amount3.valuesigned";
            this.grpImporto4.Text = "Importo variazione anno";
            // 
            // radioButton5
            // 
            this.radioButton5.Location = new System.Drawing.Point(6, 40);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(104, 21);
            this.radioButton5.TabIndex = 3;
            this.radioButton5.Tag = "-";
            this.radioButton5.Text = "Diminuzione";
            // 
            // radioButton6
            // 
            this.radioButton6.Location = new System.Drawing.Point(6, 19);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(104, 24);
            this.radioButton6.TabIndex = 2;
            this.radioButton6.Tag = "+";
            this.radioButton6.Text = "Aumento";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(6, 62);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(104, 20);
            this.textBox4.TabIndex = 1;
            this.textBox4.Tag = "epaccvar.amount4";
            this.textBox4.Leave += new System.EventHandler(this.txtImportoLeave);
            // 
            // grpImporto3
            // 
            this.grpImporto3.Controls.Add(this.radioButton3);
            this.grpImporto3.Controls.Add(this.radioButton4);
            this.grpImporto3.Controls.Add(this.textBox3);
            this.grpImporto3.Location = new System.Drawing.Point(362, 161);
            this.grpImporto3.Name = "grpImporto3";
            this.grpImporto3.Size = new System.Drawing.Size(148, 88);
            this.grpImporto3.TabIndex = 6;
            this.grpImporto3.TabStop = false;
            this.grpImporto3.Tag = "epaccvar.amount3.valuesigned";
            this.grpImporto3.Text = "Importo variazione anno";
            // 
            // radioButton3
            // 
            this.radioButton3.Location = new System.Drawing.Point(6, 40);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(104, 21);
            this.radioButton3.TabIndex = 3;
            this.radioButton3.Tag = "-";
            this.radioButton3.Text = "Diminuzione";
            // 
            // radioButton4
            // 
            this.radioButton4.Location = new System.Drawing.Point(6, 19);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(104, 24);
            this.radioButton4.TabIndex = 2;
            this.radioButton4.Tag = "+";
            this.radioButton4.Text = "Aumento";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(6, 62);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(104, 20);
            this.textBox3.TabIndex = 1;
            this.textBox3.Tag = "epaccvar.amount3";
            this.textBox3.Leave += new System.EventHandler(this.txtImportoLeave);
            // 
            // grpImporto2
            // 
            this.grpImporto2.Controls.Add(this.radioButton9);
            this.grpImporto2.Controls.Add(this.radioButton10);
            this.grpImporto2.Controls.Add(this.textBox2);
            this.grpImporto2.Location = new System.Drawing.Point(179, 161);
            this.grpImporto2.Name = "grpImporto2";
            this.grpImporto2.Size = new System.Drawing.Size(148, 88);
            this.grpImporto2.TabIndex = 5;
            this.grpImporto2.TabStop = false;
            this.grpImporto2.Tag = "epaccvar.amount2.valuesigned";
            this.grpImporto2.Text = "Importo variazione anno";
            // 
            // radioButton9
            // 
            this.radioButton9.Location = new System.Drawing.Point(6, 40);
            this.radioButton9.Name = "radioButton9";
            this.radioButton9.Size = new System.Drawing.Size(104, 21);
            this.radioButton9.TabIndex = 3;
            this.radioButton9.Tag = "-";
            this.radioButton9.Text = "Diminuzione";
            // 
            // radioButton10
            // 
            this.radioButton10.Location = new System.Drawing.Point(6, 19);
            this.radioButton10.Name = "radioButton10";
            this.radioButton10.Size = new System.Drawing.Size(104, 24);
            this.radioButton10.TabIndex = 2;
            this.radioButton10.Tag = "+";
            this.radioButton10.Text = "Aumento";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(6, 62);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(104, 20);
            this.textBox2.TabIndex = 1;
            this.textBox2.Tag = "epaccvar.amount2";
            this.textBox2.Leave += new System.EventHandler(this.txtImportoLeave);
            // 
            // grpImporto1
            // 
            this.grpImporto1.Controls.Add(this.rdbDiminuzione);
            this.grpImporto1.Controls.Add(this.rdbAumento);
            this.grpImporto1.Controls.Add(this.txtImporto);
            this.grpImporto1.Location = new System.Drawing.Point(16, 161);
            this.grpImporto1.Name = "grpImporto1";
            this.grpImporto1.Size = new System.Drawing.Size(148, 88);
            this.grpImporto1.TabIndex = 4;
            this.grpImporto1.TabStop = false;
            this.grpImporto1.Tag = "epaccvar.amount.valuesigned";
            this.grpImporto1.Text = "Importo variazione anno";
            // 
            // rdbDiminuzione
            // 
            this.rdbDiminuzione.Location = new System.Drawing.Point(6, 40);
            this.rdbDiminuzione.Name = "rdbDiminuzione";
            this.rdbDiminuzione.Size = new System.Drawing.Size(104, 21);
            this.rdbDiminuzione.TabIndex = 3;
            this.rdbDiminuzione.Tag = "-";
            this.rdbDiminuzione.Text = "Diminuzione";
            // 
            // rdbAumento
            // 
            this.rdbAumento.Location = new System.Drawing.Point(6, 19);
            this.rdbAumento.Name = "rdbAumento";
            this.rdbAumento.Size = new System.Drawing.Size(104, 24);
            this.rdbAumento.TabIndex = 2;
            this.rdbAumento.Tag = "+";
            this.rdbAumento.Text = "Aumento";
            // 
            // txtImporto
            // 
            this.txtImporto.Location = new System.Drawing.Point(6, 62);
            this.txtImporto.Name = "txtImporto";
            this.txtImporto.Size = new System.Drawing.Size(104, 20);
            this.txtImporto.TabIndex = 1;
            this.txtImporto.Tag = "epaccvar.amount";
            this.txtImporto.Leave += new System.EventHandler(this.txtImportoLeave);
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // txtTotale
            // 
            this.txtTotale.Location = new System.Drawing.Point(512, 105);
            this.txtTotale.Name = "txtTotale";
            this.txtTotale.ReadOnly = true;
            this.txtTotale.Size = new System.Drawing.Size(104, 20);
            this.txtTotale.TabIndex = 56;
            this.txtTotale.Tag = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(509, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 55;
            this.label7.Text = "Totale pluriennale";
            // 
            // Frm_epaccvar_detail
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(868, 317);
            this.Controls.Add(this.txtTotale);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.grpImporto5);
            this.Controls.Add(this.grpImporto4);
            this.Controls.Add(this.grpImporto3);
            this.Controls.Add(this.grpImporto2);
            this.Controls.Add(this.grpImporto1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.grpVariazione);
            this.Name = "Frm_epaccvar_detail";
            this.Text = "Frm_epaccvar_detail";
            this.grpVariazione.ResumeLayout(false);
            this.grpVariazione.PerformLayout();
            this.grpImporto5.ResumeLayout(false);
            this.grpImporto5.PerformLayout();
            this.grpImporto4.ResumeLayout(false);
            this.grpImporto4.PerformLayout();
            this.grpImporto3.ResumeLayout(false);
            this.grpImporto3.PerformLayout();
            this.grpImporto2.ResumeLayout(false);
            this.grpImporto2.PerformLayout();
            this.grpImporto1.ResumeLayout(false);
            this.grpImporto1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
		public void MetaData_AfterLink(){
			Meta = MetaData.GetMetaData(this);
            SetImportoName();
		}

        public void MetaData_AfterFill()
        {
            CalcolaTotale(false);
        }

        object GetCtrlByName(string Name)
        {
            System.Reflection.FieldInfo Ctrl = this.GetType().GetField(Name);
            if (Ctrl == null)
                return null;
            return Ctrl.GetValue(this);
        }

        void SetImportoName()
        {
            int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
            for (int i = 1; i <= 5; i++)
            {
                GroupBox G = (GroupBox)GetCtrlByName("grpImporto" + i.ToString());
                int N = esercizio + i - 1;
                G.Text = G.Text.Replace("anno", N.ToString());
            }
        }

        void CalcolaTotale(bool read)
        {
            if (Meta == null)
                return;
            if (Meta.IsEmpty)
                return;
            if (DS.epaccvar.Rows.Count == 0)
                return;
            if (read) Meta.GetFormData(true);
            DataRow R = DS.epaccvar.Rows[0];
            decimal totale = CfgFn.GetNoNullDecimal(R["amount"]);
            for (int i = 2; i <= 5; i++)
            {
                totale += CfgFn.GetNoNullDecimal(R["amount" + i.ToString()]);
            }
            txtTotale.Text = totale.ToString("c");
        }

        private void txtImportoLeave(object sender, EventArgs e)
        {
            CalcolaTotale(Meta.DrawStateIsDone);
        }

	}
}
