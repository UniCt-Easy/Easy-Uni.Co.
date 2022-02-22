
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
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;


namespace customgroupoperation_default//customgroupoperation//
{
	/// <summary>
	/// Summary description for frmcustomgroupoperation.
	/// </summary>
	public class Frm_customgroupoperation_default : MetaDataForm
	{
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox1;
		public /*Rana:customgroupoperation.*/vistaForm DS;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.RadioButton radioButton4;
		private System.Windows.Forms.RadioButton radioButton5;
		private System.Windows.Forms.RadioButton radioButton6;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox comboBox1;
		public MetaData meta;
		
		private System.Windows.Forms.TextBox txtBoxDivieto;
		private System.Windows.Forms.TextBox txtBoxConsenti;
		private System.Windows.Forms.RadioButton rdbVieta;
		private System.Windows.Forms.RadioButton rdbConsenti;
		private System.Windows.Forms.ComboBox comboBox2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_customgroupoperation_default()
		{
			InitializeComponent();
			DS.customgroupoperation.Columns["allowcondition"].ExtendedProperties["sqltype"] = "text";
			DS.customgroupoperation.Columns["denycondition"].ExtendedProperties["sqltype"] = "text";
		}
		
		public void MetaData_AfterLink() 
		{
			meta = MetaData.GetMetaData(this);
			bool IsAdmin=false;
			if (meta.GetSys("IsSystemAdmin")!=null) {
				IsAdmin=(bool)meta.GetSys("IsSystemAdmin");
			}

			if (!IsAdmin)
			{
				meta.CanSave =false;
				meta.CanInsert=false;
				meta.CanCancel=false;
				meta.CanInsertCopy=false;
			}
			GetData.SetStaticFilter(DS.customgroupoperation,"(operation<>'P')");

//			GetData.SetStaticFilter(DS.customgroupoperation,
//					"(tablename in (select objectname from customobject))");
		}

		public void MetaData_AfterFill()
		{
			ControlloVC();
		}

		public void ControlloVC()
		{
			txtBoxConsenti.Enabled=true; 
			txtBoxDivieto.Enabled=true;
			if (meta.IsEmpty)
			{
				return;
			}
			if ((rdbConsenti.Checked==true) && (txtBoxDivieto.Text==""))
			{
				txtBoxConsenti.Enabled=false; 
				txtBoxDivieto.Enabled=true;
			}
			if ((rdbVieta.Checked==true) && (txtBoxConsenti.Text=="") )
			{
				txtBoxDivieto.Enabled=false; 
				txtBoxConsenti.Enabled=true; 
			}
		}
		



		public void MetaData_AfterClear()
		{
			txtBoxDivieto.Enabled=true; 
			txtBoxConsenti.Enabled=true; 
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DS = new customgroupoperation_default.vistaForm();
            this.rdbVieta = new System.Windows.Forms.RadioButton();
            this.rdbConsenti = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.txtBoxDivieto = new System.Windows.Forms.TextBox();
            this.txtBoxConsenti = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Codice gruppo:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 21);
            this.label3.TabIndex = 12;
            this.label3.Text = "Nome tabella:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rdbVieta
            // 
            this.rdbVieta.Location = new System.Drawing.Point(16, 24);
            this.rdbVieta.Name = "rdbVieta";
            this.rdbVieta.Size = new System.Drawing.Size(72, 16);
            this.rdbVieta.TabIndex = 0;
            this.rdbVieta.Tag = "customgroupoperation.defaultisdeny:S";
            this.rdbVieta.Text = "Vieta";
            this.rdbVieta.CheckedChanged += new System.EventHandler(this.rdbVieta_CheckedChanged);
            // 
            // rdbConsenti
            // 
            this.rdbConsenti.Location = new System.Drawing.Point(16, 48);
            this.rdbConsenti.Name = "rdbConsenti";
            this.rdbConsenti.Size = new System.Drawing.Size(72, 16);
            this.rdbConsenti.TabIndex = 1;
            this.rdbConsenti.Tag = "customgroupoperation.defaultisdeny:N";
            this.rdbConsenti.Text = "Consenti";
            this.rdbConsenti.CheckedChanged += new System.EventHandler(this.rdbVieta_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbVieta);
            this.groupBox1.Controls.Add(this.rdbConsenti);
            this.groupBox1.Location = new System.Drawing.Point(224, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(104, 72);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Default";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton6);
            this.groupBox2.Controls.Add(this.radioButton5);
            this.groupBox2.Controls.Add(this.radioButton4);
            this.groupBox2.Controls.Add(this.radioButton3);
            this.groupBox2.Location = new System.Drawing.Point(16, 56);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(176, 72);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Operazione";
            // 
            // radioButton6
            // 
            this.radioButton6.Location = new System.Drawing.Point(16, 48);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(72, 16);
            this.radioButton6.TabIndex = 2;
            this.radioButton6.Tag = "customgroupoperation.operation:D";
            this.radioButton6.Text = "Cancella";
            // 
            // radioButton5
            // 
            this.radioButton5.Location = new System.Drawing.Point(96, 48);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(64, 16);
            this.radioButton5.TabIndex = 3;
            this.radioButton5.Tag = "customgroupoperation.operation:U";
            this.radioButton5.Text = "Modifica";
            // 
            // radioButton4
            // 
            this.radioButton4.Location = new System.Drawing.Point(96, 24);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(72, 16);
            this.radioButton4.TabIndex = 1;
            this.radioButton4.Tag = "customgroupoperation.operation:S";
            this.radioButton4.Text = "Seleziona";
            // 
            // radioButton3
            // 
            this.radioButton3.Location = new System.Drawing.Point(16, 24);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(72, 16);
            this.radioButton3.TabIndex = 0;
            this.radioButton3.Tag = "customgroupoperation.operation:I";
            this.radioButton3.Text = "Inserisci";
            // 
            // txtBoxDivieto
            // 
            this.txtBoxDivieto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxDivieto.Location = new System.Drawing.Point(136, 248);
            this.txtBoxDivieto.Multiline = true;
            this.txtBoxDivieto.Name = "txtBoxDivieto";
            this.txtBoxDivieto.Size = new System.Drawing.Size(372, 121);
            this.txtBoxDivieto.TabIndex = 5;
            this.txtBoxDivieto.Tag = "customgroupoperation.denycondition";
            this.txtBoxDivieto.TextChanged += new System.EventHandler(this.txtBoxConsenti_TextChanged);
            // 
            // txtBoxConsenti
            // 
            this.txtBoxConsenti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxConsenti.Location = new System.Drawing.Point(136, 144);
            this.txtBoxConsenti.Multiline = true;
            this.txtBoxConsenti.Name = "txtBoxConsenti";
            this.txtBoxConsenti.Size = new System.Drawing.Size(372, 96);
            this.txtBoxConsenti.TabIndex = 4;
            this.txtBoxConsenti.Tag = "customgroupoperation.allowcondition";
            this.txtBoxConsenti.TextChanged += new System.EventHandler(this.txtBoxConsenti_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 248);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "Condizione di divieto:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 16);
            this.label4.TabIndex = 18;
            this.label4.Text = "Condizione di consenti:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.DS.customobject;
            this.comboBox1.DisplayMember = "objectname";
            this.comboBox1.Location = new System.Drawing.Point(104, 8);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(320, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.Tag = "customgroupoperation.tablename";
            this.comboBox1.ValueMember = "objectname";
            // 
            // comboBox2
            // 
            this.comboBox2.DataSource = this.DS.customgroup;
            this.comboBox2.DisplayMember = "description";
            this.comboBox2.Location = new System.Drawing.Point(104, 32);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(320, 21);
            this.comboBox2.TabIndex = 19;
            this.comboBox2.Tag = "customgroupoperation.idgroup";
            this.comboBox2.ValueMember = "idcustomgroup";
            // 
            // Frm_customgroupoperation_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(516, 374);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBoxConsenti);
            this.Controls.Add(this.txtBoxDivieto);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "Frm_customgroupoperation_default";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmcustomgroupoperation";
            this.Load += new System.EventHandler(this.frmcustomgroupoperation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void rdbVieta_CheckedChanged(object sender, System.EventArgs e)
		{
			ControlloVC();
		}

		private void txtBoxConsenti_TextChanged(object sender, System.EventArgs e)
		{
			ControlloVC();
		}

		private void frmcustomgroupoperation_Load(object sender, System.EventArgs e)
		{
		
		}

		

		
	}
}
