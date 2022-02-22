
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

namespace userenvironment_default//userenvironment//
{
	/// <summary>
	/// Summary description for frmuserenvironment.
	/// </summary>
	public class Frm_userenvironment_default : MetaDataForm
	{
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox grpTipo;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton3;
		public /*Rana:userenvironment.*/vistaForm DS;
		MetaData  Meta;
		private System.Windows.Forms.CheckBox chkAdminVar;
		private System.Windows.Forms.TextBox txtValore;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtActualValue;
		private System.Windows.Forms.TextBox txtVarName;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_userenvironment_default()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

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

		public void MetaData_AfterLink(){
			Meta = MetaData.GetMetaData(this);
		}

		public void MetaData_AfterFill(){
			DataAccess Conn = Meta.Conn;
			if (((bool)Meta.GetSys("IsSystemAdmin"))==false){
				chkAdminVar.Enabled=false;
				if (Meta.InsertMode){
					chkAdminVar.Checked=false;
				}
				else {
					grpTipo.Enabled=false;
					txtValore.ReadOnly=true;
					btnOk.Enabled=false;
				}
			}
			if (Meta.EditMode){
				string varname= txtVarName.Text;
				txtActualValue.Text="";
				if (Meta.GetUsr(varname)!=null)txtActualValue.Text= Meta.GetUsr(varname).ToString();
			}
		}


		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.DS = new userenvironment_default.vistaForm();
            this.txtVarName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtValore = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkAdminVar = new System.Windows.Forms.CheckBox();
            this.grpTipo = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtActualValue = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.grpTipo.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtVarName
            // 
            this.txtVarName.Location = new System.Drawing.Point(112, 16);
            this.txtVarName.Name = "txtVarName";
            this.txtVarName.Size = new System.Drawing.Size(200, 20);
            this.txtVarName.TabIndex = 3;
            this.txtVarName.Tag = "userenvironment.variablename";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nome variabile:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtValore
            // 
            this.txtValore.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValore.Location = new System.Drawing.Point(16, 96);
            this.txtValore.Multiline = true;
            this.txtValore.Name = "txtValore";
            this.txtValore.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtValore.Size = new System.Drawing.Size(512, 144);
            this.txtValore.TabIndex = 5;
            this.txtValore.Tag = "userenvironment.value";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Valore variabile:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkAdminVar
            // 
            this.chkAdminVar.Location = new System.Drawing.Point(24, 48);
            this.chkAdminVar.Name = "chkAdminVar";
            this.chkAdminVar.Size = new System.Drawing.Size(208, 16);
            this.chkAdminVar.TabIndex = 6;
            this.chkAdminVar.Tag = "userenvironment.flagadmin:S:N";
            this.chkAdminVar.Text = "Modificabile solo dall\'amministratore";
            // 
            // grpTipo
            // 
            this.grpTipo.Controls.Add(this.radioButton3);
            this.grpTipo.Controls.Add(this.radioButton2);
            this.grpTipo.Controls.Add(this.radioButton1);
            this.grpTipo.Location = new System.Drawing.Point(328, 8);
            this.grpTipo.Name = "grpTipo";
            this.grpTipo.Size = new System.Drawing.Size(200, 72);
            this.grpTipo.TabIndex = 7;
            this.grpTipo.TabStop = false;
            this.grpTipo.Text = "Tipo";
            // 
            // radioButton3
            // 
            this.radioButton3.Location = new System.Drawing.Point(8, 48);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(184, 16);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Tag = "userenvironment.kind:S";
            this.radioButton3.Text = "Lista da Stored Procedure";
            // 
            // radioButton2
            // 
            this.radioButton2.Location = new System.Drawing.Point(8, 32);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(184, 16);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Tag = "userenvironment.kind:C";
            this.radioButton2.Text = "Lista da comando SQL";
            // 
            // radioButton1
            // 
            this.radioButton1.Location = new System.Drawing.Point(8, 16);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(184, 16);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Tag = "userenvironment.kind:K";
            this.radioButton1.Text = "Costante";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(176, 368);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Annulla";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(312, 368);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(72, 24);
            this.btnOk.TabIndex = 9;
            this.btnOk.Tag = "mainsave";
            this.btnOk.Text = "Ok";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Location = new System.Drawing.Point(16, 264);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(360, 23);
            this.label1.TabIndex = 10;
            this.label1.Text = "Valore attuale, calcolato al momento della connessione";
            // 
            // txtActualValue
            // 
            this.txtActualValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtActualValue.Location = new System.Drawing.Point(16, 280);
            this.txtActualValue.Multiline = true;
            this.txtActualValue.Name = "txtActualValue";
            this.txtActualValue.ReadOnly = true;
            this.txtActualValue.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtActualValue.Size = new System.Drawing.Size(512, 64);
            this.txtActualValue.TabIndex = 11;
            // 
            // Frm_userenvironment_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(536, 405);
            this.Controls.Add(this.txtActualValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grpTipo);
            this.Controls.Add(this.chkAdminVar);
            this.Controls.Add(this.txtValore);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtVarName);
            this.Controls.Add(this.label2);
            this.Name = "Frm_userenvironment_default";
            this.Tag = "userenvironment.userenvironment.";
            this.Text = "frmuserenvironment";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.grpTipo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
	}
}
