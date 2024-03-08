
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

namespace csapositionlookup_lista
{
	/// <summary>
    /// Summary description for frmlookupQualificaCSA.
	/// </summary>
	public class Frm_csapositionlookup_lista : MetaDataForm
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtCodice;
		public vistaForm DS;
		MetaData Meta;
		private System.Windows.Forms.ImageList images;
		private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private ComboBox cmbqualifica;
        private Button btnQualifica;
        private TextBox txtRuolo;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label4;
        private TextBox txtcomparto;
        private Label label5;
		private ComboBox cmbInquadramento;
		private TextBox textBox3;
		private Label label6;
		private Label label7;
		private System.ComponentModel.IContainer components;

		public Frm_csapositionlookup_lista()
		{
			InitializeComponent();
		}

		CQueryHelper QHC;
		QueryHelper QHS;
		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
			QHC = new CQueryHelper();
			QHS = Meta.Conn.GetQueryHelper();
			//HelpForm.SetDenyNull(DS.csapositionlookup.Columns["csa_role"], true);
		}
		public void metaData_AfterRowSelect(DataTable T, DataRow R) {
			if (T.TableName == "position" && drawStateIsDone && Meta.InsertMode) {
				if (R == null) {
					setAutoInquadramento(DBNull.Value);
				}
				else {
					DataRow Curr = DS.csapositionlookup.Rows[0];
					if (DS.csapositionlookup.Rows[0]["idinquadramento"] == DBNull.Value || DS.csapositionlookup.Rows[0]["idinquadramento"] == null) {
						setAutoInquadramento(R["idposition"]);
					}
				}
				clearCab();
			}
		}
		void clearCab() {
			DS.inquadramento.Clear();
			if (!isEmpty) {
				currentRow["idinquadramento"] = DBNull.Value;
			}
			if (cmbInquadramento.SelectedIndex > 0) {
				cmbInquadramento.SelectedIndex = -1;
			}
		}

		void setAutoInquadramento(object CurrIdposition) {
			
			DS.inquadramento.Clear();
			cmbInquadramento.DataSource = null;
			string filtrocmb = QHS.CmpEq("idposition", CurrIdposition);
			GetData.Add_Blank_Row(DS.inquadramento);
			DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.inquadramento, null, filtrocmb, null, true);
			cmbInquadramento.DataSource = DS.inquadramento;
			cmbInquadramento.DisplayMember = "title";
			cmbInquadramento.ValueMember = "idinquadramento";
			Meta.myHelpForm.PreFillControlsTable(cmbInquadramento, null);
			if (DS.csapositionlookup.Rows.Count > 0) {
				HelpForm.SetComboBoxValue(cmbInquadramento, DS.csapositionlookup.Rows[0]["idinquadramento"]);
			}
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_csapositionlookup_lista));
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.cmbInquadramento = new System.Windows.Forms.ComboBox();
			this.DS = new csapositionlookup_lista.vistaForm();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.cmbqualifica = new System.Windows.Forms.ComboBox();
			this.btnQualifica = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtCodice = new System.Windows.Forms.TextBox();
			this.images = new System.Windows.Forms.ImageList(this.components);
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.txtcomparto = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtRuolo = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.cmbInquadramento);
			this.groupBox2.Controls.Add(this.textBox3);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.textBox1);
			this.groupBox2.Controls.Add(this.cmbqualifica);
			this.groupBox2.Controls.Add(this.btnQualifica);
			this.groupBox2.Location = new System.Drawing.Point(367, 19);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(522, 168);
			this.groupBox2.TabIndex = 30;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Corrispondenza Easy";
			// 
			// cmbInquadramento
			// 
			this.cmbInquadramento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbInquadramento.DataSource = this.DS.inquadramento;
			this.cmbInquadramento.DisplayMember = "title";
			this.cmbInquadramento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbInquadramento.Location = new System.Drawing.Point(119, 86);
			this.cmbInquadramento.Name = "cmbInquadramento";
			this.cmbInquadramento.Size = new System.Drawing.Size(397, 21);
			this.cmbInquadramento.TabIndex = 30;
			this.cmbInquadramento.Tag = "csapositionlookup.idinquadramento";
			this.cmbInquadramento.ValueMember = "idinquadramento";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(117, 55);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(81, 20);
			this.textBox3.TabIndex = 29;
			this.textBox3.Tag = "csapositionlookup.livello";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(69, 57);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(37, 13);
			this.label6.TabIndex = 28;
			this.label6.Text = "Livello";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(25, 91);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(81, 13);
			this.label7.TabIndex = 27;
			this.label7.Text = "Inquadramento:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 126);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(98, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "Imponibile presunto";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(119, 119);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(137, 20);
			this.textBox1.TabIndex = 7;
			this.textBox1.Tag = "csapositionlookup.supposedtaxable";
			// 
			// cmbqualifica
			// 
			this.cmbqualifica.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbqualifica.DataSource = this.DS.position;
			this.cmbqualifica.DisplayMember = "description";
			this.cmbqualifica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbqualifica.Location = new System.Drawing.Point(115, 21);
			this.cmbqualifica.Name = "cmbqualifica";
			this.cmbqualifica.Size = new System.Drawing.Size(401, 21);
			this.cmbqualifica.TabIndex = 6;
			this.cmbqualifica.Tag = "csapositionlookup.idposition";
			this.cmbqualifica.ValueMember = "idposition";
			// 
			// btnQualifica
			// 
			this.btnQualifica.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnQualifica.Location = new System.Drawing.Point(6, 19);
			this.btnQualifica.Name = "btnQualifica";
			this.btnQualifica.Size = new System.Drawing.Size(103, 23);
			this.btnQualifica.TabIndex = 5;
			this.btnQualifica.TabStop = false;
			this.btnQualifica.Tag = "manage.position.lista";
			this.btnQualifica.Text = "Qualifica";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(151, 44);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(81, 13);
			this.label1.TabIndex = 23;
			this.label1.Text = "Inquadramento:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtCodice
			// 
			this.txtCodice.Location = new System.Drawing.Point(234, 40);
			this.txtCodice.Name = "txtCodice";
			this.txtCodice.Size = new System.Drawing.Size(109, 20);
			this.txtCodice.TabIndex = 1;
			this.txtCodice.Tag = "csapositionlookup.csa_class";
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
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.groupBox3.Controls.Add(this.txtcomparto);
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Controls.Add(this.textBox2);
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Controls.Add(this.txtRuolo);
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Controls.Add(this.txtCodice);
			this.groupBox3.Location = new System.Drawing.Point(12, 19);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(349, 121);
			this.groupBox3.TabIndex = 27;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Dettagli CSA";
			// 
			// txtcomparto
			// 
			this.txtcomparto.Location = new System.Drawing.Point(77, 15);
			this.txtcomparto.Name = "txtcomparto";
			this.txtcomparto.Size = new System.Drawing.Size(68, 20);
			this.txtcomparto.TabIndex = 29;
			this.txtcomparto.Tag = "csapositionlookup.csa_compartment";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(19, 18);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(52, 13);
			this.label5.TabIndex = 28;
			this.label5.Text = "Comparto";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(77, 66);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(266, 49);
			this.textBox2.TabIndex = 27;
			this.textBox2.Tag = "csapositionlookup.csa_description";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(8, 62);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(62, 13);
			this.label4.TabIndex = 26;
			this.label4.Text = "Descrizione";
			// 
			// txtRuolo
			// 
			this.txtRuolo.Location = new System.Drawing.Point(76, 41);
			this.txtRuolo.Name = "txtRuolo";
			this.txtRuolo.Size = new System.Drawing.Size(69, 20);
			this.txtRuolo.TabIndex = 25;
			this.txtRuolo.Tag = "csapositionlookup.csa_role";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(35, 43);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 13);
			this.label2.TabIndex = 24;
			this.label2.Text = "Ruolo";
			// 
			// Frm_csapositionlookup_lista
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(901, 205);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox3);
			this.Name = "Frm_csapositionlookup_lista";
			this.Text = "frmlookupQualificaCSA";
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);

		}
		#endregion


    }
}
