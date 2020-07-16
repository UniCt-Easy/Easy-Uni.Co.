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
using metadatalibrary;
using System.Data;

namespace registrylegalstatus_anagraficadetail {//posgiuridicadetailanagrafica//
	/// <summary>
	/// Summary description for frmposgiuridicadetailanagrafica.
	/// </summary>
	public class Frm_registrylegalstatus_anagraficadetail : System.Windows.Forms.Form {
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button btnQualifica;
		public vistaForm DS;
		private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Button btnOK;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.TextBox txtClasseStip;
        private GroupBox groupBox6;
        private TextBox txtCompartoCSA;
        private TextBox txtInquadrcsa;
        private Label label14;
        private Label label13;
        private Label lblRuoloCSA;
        private TextBox txtRuoloCSA;
        private TextBox textBox2;
        private Label label2;
        private GroupBox groupBox1;
        private Label label6;
        private TextBox textBox4;
        private ComboBox cmb_dalia_position;
        MetaData Meta;

		public Frm_registrylegalstatus_anagraficadetail() {
			InitializeComponent();
			HelpForm.SetDenyNull(DS.registrylegalstatus.Columns["active"], true);
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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.DS = new registrylegalstatus_anagraficadetail.vistaForm();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.txtClasseStip = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnQualifica = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtCompartoCSA = new System.Windows.Forms.TextBox();
            this.txtInquadrcsa = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblRuoloCSA = new System.Windows.Forms.Label();
            this.txtRuoloCSA = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.cmb_dalia_position = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(288, 14);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(112, 24);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Tag = "registrylegalstatus.active:S:N";
            this.checkBox1.Text = "Attivo";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 16);
            this.label4.TabIndex = 64;
            this.label4.Text = "Classe stipendiale:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(216, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 16);
            this.label3.TabIndex = 63;
            this.label3.Text = "Data decorrenza:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 61;
            this.label1.Text = "Data delibera:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.DS.position;
            this.comboBox1.DisplayMember = "description";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Location = new System.Drawing.Point(112, 48);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(328, 21);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.Tag = "registrylegalstatus.idposition";
            this.comboBox1.ValueMember = "idposition";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(320, 80);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(120, 20);
            this.textBox3.TabIndex = 7;
            this.textBox3.Tag = "registrylegalstatus.incomeclassvalidity";
            // 
            // txtClasseStip
            // 
            this.txtClasseStip.Location = new System.Drawing.Point(112, 80);
            this.txtClasseStip.Name = "txtClasseStip";
            this.txtClasseStip.Size = new System.Drawing.Size(104, 20);
            this.txtClasseStip.TabIndex = 6;
            this.txtClasseStip.Tag = "registrylegalstatus.incomeclass";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(112, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(120, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.Tag = "registrylegalstatus.start";
            // 
            // btnQualifica
            // 
            this.btnQualifica.Location = new System.Drawing.Point(40, 48);
            this.btnQualifica.Name = "btnQualifica";
            this.btnQualifica.Size = new System.Drawing.Size(64, 23);
            this.btnQualifica.TabIndex = 4;
            this.btnQualifica.Tag = "manage.position.lista.(active=\'S\')";
            this.btnQualifica.Text = "Qualifica";
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(357, 291);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 71;
            this.btnAnnulla.Text = "Annulla";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(253, 291);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 12;
            this.btnOK.Tag = "mainsave";
            this.btnOK.Text = "OK";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtCompartoCSA);
            this.groupBox6.Controls.Add(this.txtInquadrcsa);
            this.groupBox6.Controls.Add(this.label14);
            this.groupBox6.Controls.Add(this.label13);
            this.groupBox6.Controls.Add(this.lblRuoloCSA);
            this.groupBox6.Controls.Add(this.txtRuoloCSA);
            this.groupBox6.Location = new System.Drawing.Point(30, 130);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(410, 53);
            this.groupBox6.TabIndex = 104;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Dati CSA";
            // 
            // txtCompartoCSA
            // 
            this.txtCompartoCSA.Location = new System.Drawing.Point(79, 17);
            this.txtCompartoCSA.Name = "txtCompartoCSA";
            this.txtCompartoCSA.ReadOnly = true;
            this.txtCompartoCSA.Size = new System.Drawing.Size(52, 20);
            this.txtCompartoCSA.TabIndex = 108;
            this.txtCompartoCSA.Tag = "registrylegalstatus.csa_compartment";
            // 
            // txtInquadrcsa
            // 
            this.txtInquadrcsa.Location = new System.Drawing.Point(326, 17);
            this.txtInquadrcsa.Name = "txtInquadrcsa";
            this.txtInquadrcsa.ReadOnly = true;
            this.txtInquadrcsa.Size = new System.Drawing.Size(78, 20);
            this.txtInquadrcsa.TabIndex = 107;
            this.txtInquadrcsa.Tag = "registrylegalstatus.csa_class";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(18, 17);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(52, 13);
            this.label14.TabIndex = 106;
            this.label14.Text = "Comparto";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(244, 20);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 13);
            this.label13.TabIndex = 105;
            this.label13.Text = "Inquadramento";
            // 
            // lblRuoloCSA
            // 
            this.lblRuoloCSA.AutoSize = true;
            this.lblRuoloCSA.Location = new System.Drawing.Point(138, 17);
            this.lblRuoloCSA.Name = "lblRuoloCSA";
            this.lblRuoloCSA.Size = new System.Drawing.Size(35, 13);
            this.lblRuoloCSA.TabIndex = 104;
            this.lblRuoloCSA.Text = "Ruolo";
            // 
            // txtRuoloCSA
            // 
            this.txtRuoloCSA.Location = new System.Drawing.Point(175, 17);
            this.txtRuoloCSA.Name = "txtRuoloCSA";
            this.txtRuoloCSA.ReadOnly = true;
            this.txtRuoloCSA.Size = new System.Drawing.Size(59, 20);
            this.txtRuoloCSA.TabIndex = 103;
            this.txtRuoloCSA.Tag = "registrylegalstatus.csa_role";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(320, 108);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(120, 20);
            this.textBox2.TabIndex = 109;
            this.textBox2.Tag = "registrylegalstatus.stop";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(261, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 108;
            this.label2.Text = "Termine";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.cmb_dalia_position);
            this.groupBox1.Location = new System.Drawing.Point(30, 189);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 80);
            this.groupBox1.TabIndex = 110;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Banca Dati DALIA";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 110;
            this.label6.Text = "Codice DALIA";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(6, 40);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(90, 20);
            this.textBox4.TabIndex = 109;
            this.textBox4.Tag = "dalia_position.codedaliaposition";
            // 
            // cmb_dalia_position
            // 
            this.cmb_dalia_position.DataSource = DS.dalia_position;
            this.cmb_dalia_position.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_dalia_position.DisplayMember = "description";
            this.cmb_dalia_position.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_dalia_position.Location = new System.Drawing.Point(102, 40);
            this.cmb_dalia_position.Name = "cmb_dalia_position";
            this.cmb_dalia_position.Size = new System.Drawing.Size(296, 21);
            this.cmb_dalia_position.TabIndex = 6;
            this.cmb_dalia_position.Tag = "registrylegalstatus.iddaliaposition";
            this.cmb_dalia_position.ValueMember = "iddaliaposition";
            // 
            // Frm_registrylegalstatus_anagraficadetail
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnAnnulla;
            this.ClientSize = new System.Drawing.Size(445, 329);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.txtClasseStip);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnQualifica);
            this.Name = "Frm_registrylegalstatus_anagraficadetail";
            this.Text = "frmposgiuridicadetailanagrafica";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
		public void MetaData_AfterLink(){
			Meta = MetaData.GetMetaData(this);
		}

		public void MetaData_AfterRowSelect(DataTable T, DataRow R){
			if (!Meta.DrawStateIsDone) return;
			if (Meta.IsEmpty) return;
			if ((T.TableName == "position")&&(R!=null)){
				if (R["maxincomeclass"].ToString()=="0"){
					txtClasseStip.Text="0";
				}
			}
		}
	}
}