
/*
Easy
Copyright (C) 2024 UniversitÓ degli Studi di Catania (www.unict.it)
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
using metaeasylibrary;
using System.Data;

namespace inventorytreesorting_single {//classtreeclassinventariosingle//
	/// <summary>
	/// Summary description for frmclasstreeclassinventariosingle.
	/// </summary>
	public class Frm_inventorytreesorting_single : MetaDataForm {
		private System.Windows.Forms.TextBox txtDescrizione;
		private System.Windows.Forms.Button btnCodice;
		private System.Windows.Forms.TextBox txtCodice;
		private System.Windows.Forms.ComboBox cmbTipo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnAnnulla;
		public vistaForm DS;
		private System.Windows.Forms.GroupBox gboxclass;
        private System.Windows.Forms.GroupBox mygbox;
		private System.Windows.Forms.PictureBox pictureBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;


		public Frm_inventorytreesorting_single() {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_inventorytreesorting_single));
            this.gboxclass = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mygbox = new System.Windows.Forms.GroupBox();
            this.txtCodice = new System.Windows.Forms.TextBox();
            this.btnCodice = new System.Windows.Forms.Button();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.DS = new inventorytreesorting_single.vistaForm();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.gboxclass.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.mygbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // gboxclass
            // 
            this.gboxclass.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxclass.Controls.Add(this.pictureBox1);
            this.gboxclass.Controls.Add(this.mygbox);
            this.gboxclass.Controls.Add(this.cmbTipo);
            this.gboxclass.Controls.Add(this.label1);
            this.gboxclass.Location = new System.Drawing.Point(8, 0);
            this.gboxclass.Name = "gboxclass";
            this.gboxclass.Size = new System.Drawing.Size(488, 145);
            this.gboxclass.TabIndex = 14;
            this.gboxclass.TabStop = false;
            this.gboxclass.Tag = "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(8, 90);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // mygbox
            // 
            this.mygbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mygbox.Controls.Add(this.txtCodice);
            this.mygbox.Controls.Add(this.btnCodice);
            this.mygbox.Controls.Add(this.txtDescrizione);
            this.mygbox.Location = new System.Drawing.Point(104, 56);
            this.mygbox.Name = "mygbox";
            this.mygbox.Size = new System.Drawing.Size(376, 80);
            this.mygbox.TabIndex = 16;
            this.mygbox.TabStop = false;
            this.mygbox.Tag = "AutoManage.txtCodice.tree";
            // 
            // txtCodice
            // 
            this.txtCodice.Location = new System.Drawing.Point(8, 56);
            this.txtCodice.Name = "txtCodice";
            this.txtCodice.ReadOnly = true;
            this.txtCodice.Size = new System.Drawing.Size(96, 20);
            this.txtCodice.TabIndex = 15;
            this.txtCodice.Tag = "sorting.sortcode?x";
            // 
            // btnCodice
            // 
            this.btnCodice.Enabled = false;
            this.btnCodice.Location = new System.Drawing.Point(8, 24);
            this.btnCodice.Name = "btnCodice";
            this.btnCodice.Size = new System.Drawing.Size(96, 23);
            this.btnCodice.TabIndex = 13;
            this.btnCodice.Tag = "manage.sorting.tree";
            this.btnCodice.Text = "Codice";
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizione.Location = new System.Drawing.Point(112, 16);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.ReadOnly = true;
            this.txtDescrizione.Size = new System.Drawing.Size(256, 60);
            this.txtDescrizione.TabIndex = 14;
            this.txtDescrizione.TabStop = false;
            this.txtDescrizione.Tag = "sorting.description";
            // 
            // cmbTipo
            // 
            this.cmbTipo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTipo.DataSource = this.DS.sortingapplicabilityview;
            this.cmbTipo.DisplayMember = "description";
            this.cmbTipo.Location = new System.Drawing.Point(104, 32);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(376, 21);
            this.cmbTipo.TabIndex = 1;
            this.cmbTipo.Tag = "sorting.idsorkind?x";
            this.cmbTipo.ValueMember = "idsorkind";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Classificazione:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(312, 152);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 13;
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
            this.btnAnnulla.TabIndex = 12;
            this.btnAnnulla.Text = "Annulla";
            // 
            // Frm_inventorytreesorting_single
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(498, 176);
            this.Controls.Add(this.gboxclass);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnAnnulla);
            this.Name = "Frm_inventorytreesorting_single";
            this.Text = "frmclasstreeclassinventariosingle";
            this.gboxclass.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.mygbox.ResumeLayout(false);
            this.mygbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
		public void MetaData_AfterRowSelect(DataTable T, DataRow R){
			if (T!= DS.sortingapplicabilityview) return;

			if (MetaData.GetMetaData(this).DrawState== MetaData.form_drawstates.done) {
				if ((!MetaData.Empty(this))){
					DS.inventorytreesorting.Rows[0]["idsor"]=0;
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
				object tipoclassificazione = cmbTipo.SelectedValue;
				string filter = Meta.QHS.CmpEq("idsorkind", tipoclassificazione);
				btnCodice.Tag="manage.sorting.tree."+filter;
				//label per il form di selezione della voce di classificazione +"."+ filtro
				DS.sorting.ExtendedProperties[MetaData.ExtraParams]=filter;
				//AutoManage.txtCodiceClass.tree
                mygbox.Tag = "AutoManage.txtCodice.tree." + filter;
				MetaData.GetMetaData(this).SetAutoMode(mygbox);
			}
		}


		public void MetaData_AfterFill(){
			SetCodice();
		}

        MetaData Meta;
        QueryHelper QHS;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHS = Meta.Conn.GetQueryHelper();

            string filterCT = QHS.CmpEq("tablename", "inventorytree");
            GetData.CacheTable(DS.sortingapplicabilityview, filterCT, null, true);

            string filterActive = QHS.DoPar(QHS.AppOr(QHS.NullOrEq("active", 'S'), QHS.CmpEq("active", "")));
            string filterI = QHS.DoPar(QHS.AppOr(QHS.DoPar(QHS.AppAnd(QHS.NullOrLe("start", Meta.GetSys("esercizio")),
                    QHS.NullOrGe("stop", Meta.GetSys("esercizio")), filterActive, filterCT)), QHS.CmpEq("idsorkind", 0)));

            QueryCreator.SetFilterForInsert(DS.sortingapplicabilityview, filterI);
        }
	}
}
