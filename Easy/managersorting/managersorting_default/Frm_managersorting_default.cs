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
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;

namespace managersorting_default//classtreeresponsabilesingle//
{
	/// <summary>
	/// Summary description for frmclasstreeresponsabilesingle.
	/// Revised By Nino on 10/1/2003
	/// </summary>
	public class Frm_managersorting_default : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox txtCodice;
		private System.Windows.Forms.Button btnCodice;
		private System.Windows.Forms.TextBox txtDescrizione;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnAnnulla;
		public vistaForm DS;
		private System.Windows.Forms.GroupBox gboxclass;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cmbTipo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.PictureBox pictureBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        CQueryHelper QHC;
        QueryHelper QHS;
		public Frm_managersorting_default()
		{
			InitializeComponent();
		}

        public void MetaData_AfterLink() {
            MetaData Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            string filterCT = QHS.CmpEq("tablename", "manager");
            GetData.CacheTable(DS.sortingapplicabilityview, filterCT, null, true);

            string filterActive = QHS.DoPar(QHS.AppOr(QHS.NullOrEq("active", 'S'), QHS.CmpEq("active", "")));
            string filterI = QHS.DoPar(QHS.AppOr(QHS.DoPar(QHS.AppAnd(QHS.NullOrLe("start", Meta.GetSys("esercizio")),
                QHS.NullOrGe("stop", Meta.GetSys("esercizio")), filterActive, filterCT)), QHS.CmpEq("idsorkind", 0)));

            QueryCreator.SetFilterForInsert(DS.sortingapplicabilityview, filterI);

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_managersorting_default));
			this.DS = new managersorting_default.vistaForm();
			this.gboxclass = new System.Windows.Forms.GroupBox();
			this.txtCodice = new System.Windows.Forms.TextBox();
			this.btnCodice = new System.Windows.Forms.Button();
			this.txtDescrizione = new System.Windows.Forms.TextBox();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnAnnulla = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cmbTipo = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.gboxclass.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// gboxclass
			// 
			this.gboxclass.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxclass.Controls.Add(this.txtCodice);
			this.gboxclass.Controls.Add(this.btnCodice);
			this.gboxclass.Controls.Add(this.txtDescrizione);
			this.gboxclass.Location = new System.Drawing.Point(184, 56);
			this.gboxclass.Name = "gboxclass";
			this.gboxclass.Size = new System.Drawing.Size(296, 81);
			this.gboxclass.TabIndex = 10;
			this.gboxclass.TabStop = false;
			this.gboxclass.Tag = "AutoManage.txtCodice.treeclassmovimenti";
			// 
			// txtCodice
			// 
			this.txtCodice.Location = new System.Drawing.Point(8, 56);
			this.txtCodice.Name = "txtCodice";
			this.txtCodice.ReadOnly = true;
			this.txtCodice.Size = new System.Drawing.Size(96, 20);
			this.txtCodice.TabIndex = 2;
			this.txtCodice.Tag = "sorting.sortcode?x";
			// 
			// btnCodice
			// 
			this.btnCodice.Enabled = false;
			this.btnCodice.Location = new System.Drawing.Point(8, 24);
			this.btnCodice.Name = "btnCodice";
			this.btnCodice.Size = new System.Drawing.Size(96, 23);
			this.btnCodice.TabIndex = 1;
			this.btnCodice.Tag = "manage.sorting.tree";
			this.btnCodice.Text = "Codice";
			// 
			// txtDescrizione
			// 
			this.txtDescrizione.Location = new System.Drawing.Point(112, 16);
			this.txtDescrizione.Multiline = true;
			this.txtDescrizione.Name = "txtDescrizione";
			this.txtDescrizione.ReadOnly = true;
			this.txtDescrizione.Size = new System.Drawing.Size(174, 57);
			this.txtDescrizione.TabIndex = 3;
			this.txtDescrizione.TabStop = false;
			this.txtDescrizione.Tag = "sorting.description";
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(312, 152);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 6;
			this.btnOk.TabStop = false;
			this.btnOk.Tag = "mainsave";
			this.btnOk.Text = "Ok";
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnAnnulla.Location = new System.Drawing.Point(416, 152);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
			this.btnAnnulla.TabIndex = 7;
			this.btnAnnulla.TabStop = false;
			this.btnAnnulla.Text = "Annulla";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(104, 72);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(72, 20);
			this.textBox1.TabIndex = 2;
			this.textBox1.Tag = "managersorting.quota.fixed.2..%.100";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(32, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 20;
			this.label2.Text = "Quota:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// cmbTipo
			// 
			this.cmbTipo.DataSource = this.DS.sortingapplicabilityview;
			this.cmbTipo.DisplayMember = "description";
			this.cmbTipo.Location = new System.Drawing.Point(104, 32);
			this.cmbTipo.Name = "cmbTipo";
			this.cmbTipo.Size = new System.Drawing.Size(376, 21);
			this.cmbTipo.TabIndex = 1;
			this.cmbTipo.Tag = "sorting.idsorkind?x";
			this.cmbTipo.ValueMember = "idsorkind";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 16);
			this.label1.TabIndex = 17;
			this.label1.Text = "Classificazione:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.pictureBox1);
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.cmbTipo);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.gboxclass);
			this.groupBox1.Location = new System.Drawing.Point(8, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(488, 145);
			this.groupBox1.TabIndex = 21;
			this.groupBox1.TabStop = false;
			this.groupBox1.Tag = "";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(8, 90);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(64, 48);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 21;
			this.pictureBox1.TabStop = false;
			// 
			// Frm_managersorting_default
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnAnnulla;
			this.ClientSize = new System.Drawing.Size(502, 180);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.btnAnnulla);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "Frm_managersorting_default";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmclasstreeresponsabilesingle";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.gboxclass.ResumeLayout(false);
			this.gboxclass.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion


		public void MetaData_AfterRowSelect(DataTable T, DataRow R){
			if (T!= DS.sortingapplicabilityview) return;

			if (MetaData.GetMetaData(this).DrawState== MetaData.form_drawstates.done) {
				if ((!MetaData.Empty(this))){
					DS.managersorting.Rows[0]["idsor"]=0;
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
                string filter = QHS.CmpEq("idsorkind", cmbTipo.SelectedValue);
				btnCodice.Tag="manage.sorting.tree."+filter;
				//label per il form di selezione della voce di classificazione +"."+ filtro
				DS.sorting.ExtendedProperties[MetaData.ExtraParams]=filter;
				//AutoManage.txtCodiceClass.tree
				gboxclass.Tag="AutoManage.txtCodice.tree."+filter;
				MetaData.GetMetaData(this).SetAutoMode(gboxclass);
			}
		}

		public void MetaData_AfterFill()
		{
			SetCodice();
		}
}
}
