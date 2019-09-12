/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;

namespace ivaregisterkind_default {//tiporegistroiva//
	/// <summary>
	/// Summary description for frmtiporegistroiva.
	/// </summary>
	public class Frm_ivaregisterkind_default : System.Windows.Forms.Form {
		private System.Windows.Forms.ImageList images;
		public System.Windows.Forms.Panel MetaDataDetail;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton3;
		public vistaForm DS;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox3;
        private GroupBox groupBox2;
        private RadioButton radioButton4;
        private RadioButton radioButton5;
        private RadioButton radioButton6;
        private Button btnCopyAll;
        private RadioButton radioButton7;
        private CheckBox checkBox1;
        private GroupBox grpTesorierePerIncasso;
        private ComboBox cmbCodiceIstituto;
		private System.ComponentModel.IContainer components;

		public Frm_ivaregisterkind_default() {
			InitializeComponent();
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ivaregisterkind_default));
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.MetaDataDetail = new System.Windows.Forms.Panel();
            this.grpTesorierePerIncasso = new System.Windows.Forms.GroupBox();
            this.cmbCodiceIstituto = new System.Windows.Forms.ComboBox();
            this.DS = new ivaregisterkind_default.vistaForm();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnCopyAll = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.MetaDataDetail.SuspendLayout();
            this.grpTesorierePerIncasso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // images
            // 
            this.images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("images.ImageStream")));
            this.images.TransparentColor = System.Drawing.Color.Transparent;
            this.images.Images.SetKeyName(0, "");
            this.images.Images.SetKeyName(1, "");
            this.images.Images.SetKeyName(2, "");
            this.images.Images.SetKeyName(3, "");
            this.images.Images.SetKeyName(4, "");
            this.images.Images.SetKeyName(5, "");
            this.images.Images.SetKeyName(6, "");
            this.images.Images.SetKeyName(7, "");
            this.images.Images.SetKeyName(8, "");
            this.images.Images.SetKeyName(9, "");
            this.images.Images.SetKeyName(10, "");
            this.images.Images.SetKeyName(11, "");
            this.images.Images.SetKeyName(12, "");
            this.images.Images.SetKeyName(13, "");
            // 
            // MetaDataDetail
            // 
            this.MetaDataDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MetaDataDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MetaDataDetail.Controls.Add(this.grpTesorierePerIncasso);
            this.MetaDataDetail.Controls.Add(this.checkBox1);
            this.MetaDataDetail.Controls.Add(this.btnCopyAll);
            this.MetaDataDetail.Controls.Add(this.groupBox2);
            this.MetaDataDetail.Controls.Add(this.textBox3);
            this.MetaDataDetail.Controls.Add(this.label3);
            this.MetaDataDetail.Controls.Add(this.label2);
            this.MetaDataDetail.Controls.Add(this.textBox1);
            this.MetaDataDetail.Controls.Add(this.textBox2);
            this.MetaDataDetail.Controls.Add(this.label1);
            this.MetaDataDetail.Controls.Add(this.groupBox1);
            this.MetaDataDetail.Location = new System.Drawing.Point(11, 12);
            this.MetaDataDetail.Name = "MetaDataDetail";
            this.MetaDataDetail.Size = new System.Drawing.Size(600, 412);
            this.MetaDataDetail.TabIndex = 1;
            // 
            // grpTesorierePerIncasso
            // 
            this.grpTesorierePerIncasso.Controls.Add(this.cmbCodiceIstituto);
            this.grpTesorierePerIncasso.Location = new System.Drawing.Point(4, 288);
            this.grpTesorierePerIncasso.Name = "grpTesorierePerIncasso";
            this.grpTesorierePerIncasso.Size = new System.Drawing.Size(381, 50);
            this.grpTesorierePerIncasso.TabIndex = 22;
            this.grpTesorierePerIncasso.TabStop = false;
            this.grpTesorierePerIncasso.Text = "Tesoriere collegato";
            // 
            // cmbCodiceIstituto
            // 
            this.cmbCodiceIstituto.DataSource = this.DS.treasurer;
            this.cmbCodiceIstituto.DisplayMember = "description";
            this.cmbCodiceIstituto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCodiceIstituto.Location = new System.Drawing.Point(5, 19);
            this.cmbCodiceIstituto.Name = "cmbCodiceIstituto";
            this.cmbCodiceIstituto.Size = new System.Drawing.Size(353, 21);
            this.cmbCodiceIstituto.TabIndex = 0;
            this.cmbCodiceIstituto.Tag = "ivaregisterkind.idtreasurer";
            this.cmbCodiceIstituto.ValueMember = "idtreasurer";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(250, 262);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(116, 17);
            this.checkBox1.TabIndex = 21;
            this.checkBox1.Tag = "ivaregisterkind.compensation:S:N";
            this.checkBox1.Text = "registro corrispettivi";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // btnCopyAll
            // 
            this.btnCopyAll.Location = new System.Drawing.Point(191, 358);
            this.btnCopyAll.Name = "btnCopyAll";
            this.btnCopyAll.Size = new System.Drawing.Size(240, 23);
            this.btnCopyAll.TabIndex = 20;
            this.btnCopyAll.Text = "Copia il Tipo Registro su tutti gli altri Dipartimenti";
            this.btnCopyAll.UseVisualStyleBackColor = true;
            this.btnCopyAll.Click += new System.EventHandler(this.btnCopyAll_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton7);
            this.groupBox2.Controls.Add(this.radioButton4);
            this.groupBox2.Controls.Add(this.radioButton5);
            this.groupBox2.Controls.Add(this.radioButton6);
            this.groupBox2.Location = new System.Drawing.Point(190, 117);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(195, 113);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipo di Attività";
            // 
            // radioButton7
            // 
            this.radioButton7.Location = new System.Drawing.Point(9, 86);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(164, 21);
            this.radioButton7.TabIndex = 3;
            this.radioButton7.Tag = "ivaregisterkind.flagactivity:4";
            this.radioButton7.Text = "Qualsiasi/Non specificata";
            // 
            // radioButton4
            // 
            this.radioButton4.Location = new System.Drawing.Point(9, 64);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(105, 16);
            this.radioButton4.TabIndex = 2;
            this.radioButton4.Tag = "ivaregisterkind.flagactivity:3";
            this.radioButton4.Text = "Promiscua";
            // 
            // radioButton5
            // 
            this.radioButton5.Location = new System.Drawing.Point(9, 40);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(105, 16);
            this.radioButton5.TabIndex = 1;
            this.radioButton5.Tag = "ivaregisterkind.flagactivity:2";
            this.radioButton5.Text = "Commerciale";
            // 
            // radioButton6
            // 
            this.radioButton6.Location = new System.Drawing.Point(9, 16);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(120, 16);
            this.radioButton6.TabIndex = 0;
            this.radioButton6.Tag = "ivaregisterkind.flagactivity:1";
            this.radioButton6.Text = "Istituzionale";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(8, 262);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(112, 20);
            this.textBox3.TabIndex = 4;
            this.textBox3.Tag = "ivaregisterkind.idivaregisterkindunified";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 246);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Codice di Consolidamento:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(7, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Descrizione:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(8, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(280, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Tag = "ivaregisterkind.codeivaregisterkind";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(8, 63);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(377, 48);
            this.textBox2.TabIndex = 1;
            this.textBox2.Tag = "ivaregisterkind.description";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Codice:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(7, 117);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(154, 113);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo di Protocollo";
            // 
            // radioButton3
            // 
            this.radioButton3.Location = new System.Drawing.Point(8, 64);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(64, 16);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Tag = "ivaregisterkind.registerclass:A";
            this.radioButton3.Text = "Acquisti";
            // 
            // radioButton2
            // 
            this.radioButton2.Location = new System.Drawing.Point(8, 40);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(64, 16);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Tag = "ivaregisterkind.registerclass:V";
            this.radioButton2.Text = "Vendite";
            // 
            // radioButton1
            // 
            this.radioButton1.Location = new System.Drawing.Point(8, 16);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(120, 16);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Tag = "ivaregisterkind.registerclass:P";
            this.radioButton1.Text = "Protocollo generale";
            // 
            // Frm_ivaregisterkind_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(623, 430);
            this.Controls.Add(this.MetaDataDetail);
            this.Name = "Frm_ivaregisterkind_default";
            this.Text = "frmtiporegistroiva";
            this.MetaDataDetail.ResumeLayout(false);
            this.MetaDataDetail.PerformLayout();
            this.grpTesorierePerIncasso.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

        public void MetaData_AfterLink()
        {
            MetaData Meta = MetaData.GetMetaData(this);
            bool IsAdmin = false;

            if (Meta.GetUsr("consolidamento") != null)
                IsAdmin = (Meta.GetUsr("consolidamento").ToString() == "S");
            if (Meta.GetSys("IsSystemAdmin") != null)
                IsAdmin = IsAdmin || (bool)Meta.GetSys("IsSystemAdmin");

            if (!IsAdmin) btnCopyAll.Visible = false;
            HelpForm.SetDenyNull(DS.ivaregisterkind.Columns["compensation"],true);
        }

        private void btnCopyAll_Click(object sender, EventArgs e)
        {
            MetaData Meta = MetaData.GetMetaData(this);
            if (Meta.IsEmpty) return;
            Meta.SaveFormData();
            if (DS.HasChanges()) return;
            DataRow R = HelpForm.GetLastSelected(DS.ivaregisterkind);

            if (MessageBox.Show("Copiare tutte le informazioni del tipo registro di codice " +
                    R["codeivaregisterkind"].ToString() + " su tutti i dipartimenti?", "Attenzione", MessageBoxButtons.YesNo) !=
                    DialogResult.Yes) return;

            Meta.Conn.CallSP("copyrow_ivaregisterkind", new object[1] { R["idivaregisterkind"] });
        }
	}
}