
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

namespace cab_default_anag//sportellobanca_anagrafica//
{
	/// <summary>
	/// Summary description for frmsportellobanca_anagrafica.
	/// </summary>
	public class Frm_cab_default_anag : MetaDataForm
	{
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox grpGeo;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox txtLocalitaGeo;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox textBox9;
		private System.Windows.Forms.Button btnAnnulla;
		private System.Windows.Forms.Button btnOK;
		public /*Rana:sportellobanca_anagrafica.*/vistaForm DS;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.TextBox textBox10;
        private CheckBox checkBox1;
		private System.Windows.Forms.TextBox textBox2;

		public Frm_cab_default_anag()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            HelpForm.SetDenyNull(DS.cab.Columns["flagusable"], true);
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
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpGeo = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtLocalitaGeo = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.DS = new cab_default_anag.vistaForm();
            this.grpGeo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(240, 230);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 7;
            this.btnAnnulla.Text = "Annulla";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(128, 230);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Tag = "mainsave";
            this.btnOK.Text = "OK";
            // 
            // textBox5
            // 
            this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox5.Location = new System.Drawing.Point(96, 64);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(336, 20);
            this.textBox5.TabIndex = 4;
            this.textBox5.Tag = "cab.address";
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.Location = new System.Drawing.Point(96, 40);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(336, 20);
            this.textBox4.TabIndex = 3;
            this.textBox4.Tag = "cab.description";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 23);
            this.label5.TabIndex = 51;
            this.label5.Text = "Indirizzo";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 50;
            this.label4.Text = "Descrizione";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Location = new System.Drawing.Point(304, 16);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(128, 20);
            this.textBox3.TabIndex = 2;
            this.textBox3.Tag = "cab.idcab";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(256, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 48;
            this.label3.Text = "CAB";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(96, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(128, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Tag = "cab.idbank";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 23);
            this.label1.TabIndex = 46;
            this.label1.Text = "Codice ABI";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpGeo
            // 
            this.grpGeo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpGeo.Controls.Add(this.textBox2);
            this.grpGeo.Controls.Add(this.label17);
            this.grpGeo.Controls.Add(this.textBox10);
            this.grpGeo.Controls.Add(this.label6);
            this.grpGeo.Controls.Add(this.label14);
            this.grpGeo.Controls.Add(this.txtLocalitaGeo);
            this.grpGeo.Controls.Add(this.label15);
            this.grpGeo.Controls.Add(this.textBox9);
            this.grpGeo.Location = new System.Drawing.Point(8, 88);
            this.grpGeo.Name = "grpGeo";
            this.grpGeo.Size = new System.Drawing.Size(424, 96);
            this.grpGeo.TabIndex = 5;
            this.grpGeo.TabStop = false;
            this.grpGeo.Tag = "AutoChoose.txtLocalitaGeo.default.(newcity is null and stop is null)";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(344, 40);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(64, 20);
            this.textBox2.TabIndex = 3;
            this.textBox2.Tag = "cab.cap";
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(24, 40);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 16);
            this.label17.TabIndex = 161;
            this.label17.Text = "Località";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(88, 40);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(192, 20);
            this.textBox10.TabIndex = 2;
            this.textBox10.Tag = "cab.location";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(288, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 18);
            this.label6.TabIndex = 154;
            this.label6.Text = "CAP";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(24, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 16);
            this.label14.TabIndex = 146;
            this.label14.Text = "Comune";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLocalitaGeo
            // 
            this.txtLocalitaGeo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLocalitaGeo.Location = new System.Drawing.Point(88, 16);
            this.txtLocalitaGeo.Name = "txtLocalitaGeo";
            this.txtLocalitaGeo.Size = new System.Drawing.Size(320, 20);
            this.txtLocalitaGeo.TabIndex = 1;
            this.txtLocalitaGeo.Tag = "geo_city.title?x";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(24, 64);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 18);
            this.label15.TabIndex = 133;
            this.label15.Text = "Provincia";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(88, 64);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(192, 20);
            this.textBox9.TabIndex = 4;
            this.textBox9.Tag = "geo_country.title";
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(379, 199);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(53, 17);
            this.checkBox1.TabIndex = 53;
            this.checkBox1.Tag = "cabview.flagusable:S:N";
            this.checkBox1.Text = "Attivo";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // Frm_cab_default_anag
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnAnnulla;
            this.ClientSize = new System.Drawing.Size(448, 275);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.grpGeo);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "Frm_cab_default_anag";
            this.Text = "frmsportellobanca_anagrafica";
            this.grpGeo.ResumeLayout(false);
            this.grpGeo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion



//		public void MetaData_AfterClear() {
//			cboCAP.DataSource=null;
//		}

//		public void MetaData_AfterFill() {
//			DataRow Rprimary = DS.sportellobanca.Rows[0];
//			if (Rprimary!=null) {
//				ImpostaComboCAP(cboCAP, Rprimary["idcomune"].ToString());
//				if (Rprimary["cap"].ToString()!="")
//					HelpForm.SetComboBoxValue(cboCAP,Rprimary["cap"].ToString());
//			}	
//		}

//		public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
//			if (!Meta.DrawStateIsDone) return;
//
//			if (!Meta.IsEmpty && T.TableName=="geo_comune" && R!=null) {
//				ImpostaComboCAP(cboCAP, R["idcomune"].ToString());
//			}
//		}

//		public void MetaData_AfterGetFormData() {
//			DataRow CurrRow=HelpForm.GetLastSelected(DS.sportellobanca);
//			if (Meta.IsEmpty || CurrRow==null || cboCAP.SelectedValue==null) return;
//			string valore=cboCAP.SelectedValue.ToString();
//			if (valore!="")
//				CurrRow["cap"]=valore;
//			else
//				CurrRow["cap"]=DBNull.Value;
//		}

//		private void ImpostaComboCAP(ComboBox cbo, string idcomune) {
//			if (idcomune.Trim()=="") return;
//
//			try {
//				DataSet DScap=Meta.Conn.CallSP("sp_cerca_codici_comune",
//					new object[] {
//									 HelpForm.GetObjectFromString(typeof(int),idcomune,null),
//									 HelpForm.GetObjectFromString(typeof(int),"3",null),
//									 HelpForm.GetObjectFromString(typeof(int),"1",null)
//								 });
//				cbo.DataSource=DScap.Tables[0];
//				cbo.DisplayMember=DScap.Tables[0].Columns[0].Caption;
//				cbo.ValueMember=DScap.Tables[0].Columns[0].Caption;
//			} catch {}
//		}
	}
}
