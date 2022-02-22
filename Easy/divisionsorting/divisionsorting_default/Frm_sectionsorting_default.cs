
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
using metaeasylibrary;
using metadatalibrary;

namespace sectionsorting_default//classtreesezionesingle//
{
	/// <summary>
	/// Summary description for frmclasstreesezionesingle.
	/// Revised By Nino on 10/1/2003
	/// </summary>
	public class Frm_sectionsorting_default : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox txtCodice;
		private System.Windows.Forms.Button btnCodice;
		private System.Windows.Forms.ComboBox cmbTipo;
		private System.Windows.Forms.TextBox txtDescrizione;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnAnnulla;
		public /*Rana:classtreesezionesingle.*/vistaForm DS;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox gboxclass;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_sectionsorting_default()
		{
			InitializeComponent();
			GetData.CacheTable(DS.sortingapplicabilityview,"(nometabella='sezione')",null,true);
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
			this.gboxclass = new System.Windows.Forms.GroupBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtCodice = new System.Windows.Forms.TextBox();
			this.btnCodice = new System.Windows.Forms.Button();
			this.cmbTipo = new System.Windows.Forms.ComboBox();
			this.DS = new /*Rana:classtreesezionesingle.*/vistaForm();
			this.txtDescrizione = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnAnnulla = new System.Windows.Forms.Button();
			this.gboxclass.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// gboxclass
			// 
			this.gboxclass.Controls.Add(this.textBox1);
			this.gboxclass.Controls.Add(this.label2);
			this.gboxclass.Controls.Add(this.txtCodice);
			this.gboxclass.Controls.Add(this.btnCodice);
			this.gboxclass.Controls.Add(this.cmbTipo);
			this.gboxclass.Controls.Add(this.txtDescrizione);
			this.gboxclass.Controls.Add(this.label1);
			this.gboxclass.Location = new System.Drawing.Point(8, 8);
			this.gboxclass.Name = "gboxclass";
			this.gboxclass.Size = new System.Drawing.Size(456, 184);
			this.gboxclass.TabIndex = 17;
			this.gboxclass.TabStop = false;
			this.gboxclass.Tag = "AutoManage.txtCodice.treeclassmovimenti";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(104, 64);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(72, 20);
			this.textBox1.TabIndex = 2;
			this.textBox1.Tag = "sectionsorting.quota.fixed.2..%.100";
			this.textBox1.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(32, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 14;
			this.label2.Text = "Quota:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// txtCodice
			// 
			this.txtCodice.Location = new System.Drawing.Point(104, 96);
			this.txtCodice.Name = "txtCodice";
			this.txtCodice.ReadOnly = true;
			this.txtCodice.Size = new System.Drawing.Size(112, 20);
			this.txtCodice.TabIndex = 4;
			this.txtCodice.Tag = "sorting.sortcode?x";
			this.txtCodice.Text = "";
			// 
			// btnCodice
			// 
			this.btnCodice.Enabled = false;
			this.btnCodice.Location = new System.Drawing.Point(24, 96);
			this.btnCodice.Name = "btnCodice";
			this.btnCodice.Size = new System.Drawing.Size(72, 23);
			this.btnCodice.TabIndex = 3;
			this.btnCodice.Tag = "manage.sorting.tree";
			this.btnCodice.Text = "Codice";
			this.btnCodice.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// cmbTipo
			// 
			this.cmbTipo.DataSource = this.DS.sortingapplicabilityview;
			this.cmbTipo.DisplayMember = "descrizione";
			this.cmbTipo.Location = new System.Drawing.Point(104, 32);
			this.cmbTipo.Name = "cmbTipo";
			this.cmbTipo.Size = new System.Drawing.Size(328, 21);
			this.cmbTipo.TabIndex = 1;
			this.cmbTipo.Tag = "sectionsorting.idsorkind?x";
			this.cmbTipo.ValueMember = "codicetipoclass";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// txtDescrizione
			// 
			this.txtDescrizione.Location = new System.Drawing.Point(232, 96);
			this.txtDescrizione.Multiline = true;
			this.txtDescrizione.Name = "txtDescrizione";
			this.txtDescrizione.ReadOnly = true;
			this.txtDescrizione.Size = new System.Drawing.Size(200, 72);
			this.txtDescrizione.TabIndex = 6;
			this.txtDescrizione.TabStop = false;
			this.txtDescrizione.Tag = "sorting.description";
			this.txtDescrizione.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(32, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Tipo:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// btnOk
			// 
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(288, 200);
			this.btnOk.Name = "btnOk";
			this.btnOk.TabIndex = 16;
			this.btnOk.Tag = "mainsave";
			this.btnOk.Text = "Ok";
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnAnnulla.Location = new System.Drawing.Point(392, 200);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.TabIndex = 15;
			this.btnAnnulla.Text = "Annulla";
			// 
			// frmclasstreesezionesingle
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnAnnulla;
			this.ClientSize = new System.Drawing.Size(472, 231);
			this.Controls.Add(this.gboxclass);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.btnAnnulla);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "frmclasstreesezionesingle";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmclasstreesezionesingle";
			this.gboxclass.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion


		public void MetaData_AfterRowSelect(DataTable T, DataRow R){
			if (T!= DS.sortingapplicabilityview) return;

			if (MetaData.GetMetaData(this).DrawState== MetaData.form_drawstates.done) {
				if ((!MetaData.Empty(this))){
					DS.sectionsorting.Rows[0]["idsor"]="";
					DS.sectionsorting.Rows[0]["idsorkind"]="";
				}
				txtCodice.Text="";
				txtDescrizione.Text="";
				DS.sorting.Clear();
			}
			SetCodice();
		}



		void SetCodice(){
			MetaData Meta = MetaData.GetMetaData(this);
			if (Meta.EditMode) return;
			btnCodice.Enabled= (cmbTipo.SelectedIndex>0);
			txtCodice.ReadOnly= (cmbTipo.SelectedIndex<=0);
			if (cmbTipo.SelectedIndex<=0){
				txtCodice.Text="";
				txtDescrizione.Text="";
			}
			else {
				string filter = "(codicetipoclass='"+cmbTipo.SelectedValue.ToString()+"')";
				btnCodice.Tag="manage.classmovimenti.tree."+filter;
				//label per il form di selezione della voce di classificazione +"."+ filtro
				DS.sorting.ExtendedProperties[MetaData.ExtraParams]=filter;
				//AutoManage.txtCodiceClass.tree
				gboxclass.Tag="AutoManage.txtCodice.tree."+filter;
				MetaData.GetMetaData(this).SetAutoMode(gboxclass);
			}
		}


		public void MetaData_AfterFill(){
			SetCodice();
		}

	}

}
