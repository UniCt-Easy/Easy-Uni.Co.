
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
using metadatalibrary;
using System.Data;

namespace sortingexpensefilter_single {
	/// <summary>
	/// Summary description for Frm_sortingexpensefilter_single.
	/// </summary>
	public class Frm_sortingexpensefilter_single : MetaDataForm {
        public sortingexpensefilter_single.vistaForm DS;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnAnnulla;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        CQueryHelper QHC;
        QueryHelper QHS;
        private GroupBox groupBox3;
        private Label label4;
        private GroupBox gboxClassMov;
        private TextBox txtDescrizioneMov;
        private TextBox txtCodiceMov;
        private Button btnCodiceMov;
        private ComboBox cmbTipoMov;
        private Label label2;
        MetaData Meta;
        private CheckBox checkBoxFlagunisciamenospecifici;
        DataAccess Conn;
		public Frm_sortingexpensefilter_single() {
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
            this.DS = new sortingexpensefilter_single.vistaForm();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gboxClassMov = new System.Windows.Forms.GroupBox();
            this.txtDescrizioneMov = new System.Windows.Forms.TextBox();
            this.txtCodiceMov = new System.Windows.Forms.TextBox();
            this.btnCodiceMov = new System.Windows.Forms.Button();
            this.cmbTipoMov = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxFlagunisciamenospecifici = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.gboxClassMov.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(316, 227);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 12;
            this.btnOk.Tag = "mainsave";
            this.btnOk.Text = "Ok";
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(412, 227);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 13;
            this.btnAnnulla.Text = "Annulla";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.gboxClassMov);
            this.groupBox3.Controls.Add(this.cmbTipoMov);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(12, 74);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(478, 134);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Tag = "";
            this.groupBox3.Text = "Classificazione movimento";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(48, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 8);
            this.label4.TabIndex = 262;
            this.label4.Text = "__________________________";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // gboxClassMov
            // 
            this.gboxClassMov.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxClassMov.Controls.Add(this.txtDescrizioneMov);
            this.gboxClassMov.Controls.Add(this.txtCodiceMov);
            this.gboxClassMov.Controls.Add(this.btnCodiceMov);
            this.gboxClassMov.Location = new System.Drawing.Point(8, 40);
            this.gboxClassMov.Name = "gboxClassMov";
            this.gboxClassMov.Size = new System.Drawing.Size(396, 64);
            this.gboxClassMov.TabIndex = 2;
            this.gboxClassMov.TabStop = false;
            this.gboxClassMov.Tag = "AutoManage.txtCodiceMov.tree";
            // 
            // txtDescrizioneMov
            // 
            this.txtDescrizioneMov.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizioneMov.Location = new System.Drawing.Point(128, 8);
            this.txtDescrizioneMov.Multiline = true;
            this.txtDescrizioneMov.Name = "txtDescrizioneMov";
            this.txtDescrizioneMov.ReadOnly = true;
            this.txtDescrizioneMov.Size = new System.Drawing.Size(260, 48);
            this.txtDescrizioneMov.TabIndex = 6;
            this.txtDescrizioneMov.TabStop = false;
            this.txtDescrizioneMov.Tag = "sorting.description";
            // 
            // txtCodiceMov
            // 
            this.txtCodiceMov.Location = new System.Drawing.Point(8, 32);
            this.txtCodiceMov.Name = "txtCodiceMov";
            this.txtCodiceMov.Size = new System.Drawing.Size(112, 20);
            this.txtCodiceMov.TabIndex = 1;
            this.txtCodiceMov.Tag = "sorting.sortcode?sortingexpensefilterview.sortingcode";
            // 
            // btnCodiceMov
            // 
            this.btnCodiceMov.Location = new System.Drawing.Point(8, 8);
            this.btnCodiceMov.Name = "btnCodiceMov";
            this.btnCodiceMov.Size = new System.Drawing.Size(72, 23);
            this.btnCodiceMov.TabIndex = 2;
            this.btnCodiceMov.TabStop = false;
            this.btnCodiceMov.Tag = "manage.sorting.tree";
            this.btnCodiceMov.Text = "Codice";
            this.btnCodiceMov.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // cmbTipoMov
            // 
            this.cmbTipoMov.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTipoMov.DataSource = this.DS.sortingkind;
            this.cmbTipoMov.DisplayMember = "description";
            this.cmbTipoMov.Location = new System.Drawing.Point(70, 16);
            this.cmbTipoMov.Name = "cmbTipoMov";
            this.cmbTipoMov.Size = new System.Drawing.Size(334, 21);
            this.cmbTipoMov.TabIndex = 1;
            this.cmbTipoMov.Tag = "sortingexpensefilter.idsorkind";
            this.cmbTipoMov.ValueMember = "idsorkind";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tipo:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // checkBoxFlagunisciamenospecifici
            // 
            this.checkBoxFlagunisciamenospecifici.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxFlagunisciamenospecifici.Location = new System.Drawing.Point(331, 16);
            this.checkBoxFlagunisciamenospecifici.Name = "checkBoxFlagunisciamenospecifici";
            this.checkBoxFlagunisciamenospecifici.Size = new System.Drawing.Size(144, 24);
            this.checkBoxFlagunisciamenospecifici.TabIndex = 23;
            this.checkBoxFlagunisciamenospecifici.Tag = "sortingexpensefilter.jointolessspecifics:S:N";
            this.checkBoxFlagunisciamenospecifici.Text = "Unisci a meno specifici";
            // 
            // Frm_sortingexpensefilter_single
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnAnnulla;
            this.ClientSize = new System.Drawing.Size(496, 257);
            this.Controls.Add(this.checkBoxFlagunisciamenospecifici);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnAnnulla);
            this.Name = "Frm_sortingexpensefilter_single";
            this.Text = "Frm_sortingexpensefilter_single";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.gboxClassMov.ResumeLayout(false);
            this.gboxClassMov.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            Conn = Meta.Conn;
            string filtereserc = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            DataRow ParentRow = Meta.SourceRow;
            //string filterupb = QHS.CmpEq("idupb", ParentRow["idupb"]);
            //string filter = QHS.AppAnd(QHS.IsNull("idfin"), QHS.IsNull("idman"), QHS.IsNull("idsorreg"), QHS.IsNull("idsorkindreg"));
            //filter = QHS.AppAnd(filter, filtereserc, filterupb);
            //GetData.SetStaticFilter(DS.sortingexpensefilter, filter);
            //GetData.SetStaticFilter(DS.sortingexpensefilterview, filter);

            string filterActive = QHS.DoPar(QHS.AppOr(QHS.NullOrEq("active", 'S'), QHS.CmpEq("active", "")));
            string filterI_SK = QHS.DoPar(QHS.AppOr(QHS.DoPar(QHS.AppAnd(QHS.NullOrLe("start", Meta.GetSys("esercizio")),
            QHS.NullOrGe("stop", Meta.GetSys("esercizio")), filterActive,
            QHS.IsNotNull("nphaseexpense"))), QHS.CmpEq("idsorkind", 0)));
            QueryCreator.SetFilterForInsert(DS.sortingkind, filterI_SK);
        }

		public void MetaData_AfterRowSelect(DataTable T, DataRow R){
            if (T.TableName == "sortingkind")
            {
                if (MetaData.GetMetaData(this).DrawState == MetaData.form_drawstates.done)
                {
                    if ((!MetaData.Empty(this)))
                    {
                        DS.sortingexpensefilter.Rows[0]["idsor"] = DBNull.Value;
                        DS.sortingexpensefilter.Rows[0]["idsorkind"] = 0;
                    }
                    txtCodiceMov.Text = "";
                    txtDescrizioneMov.Text = "";
                    DS.sorting.Clear();
                }
                SetCodiceMovim();
          
            }
		}

      
   
        public void MetaData_AfterFill()
        {
            SetCodiceMovim();
        }

        void SetCodiceMovim()
        {
            btnCodiceMov.Enabled = (cmbTipoMov.SelectedIndex > 0);
            txtCodiceMov.ReadOnly = (cmbTipoMov.SelectedIndex <= 0);
            if (cmbTipoMov.SelectedIndex <= 0)
            {
                txtCodiceMov.Text = "";
                txtDescrizioneMov.Text = "";
            }
            else
            {
                string filter = QHS.CmpEq("idsorkind", cmbTipoMov.SelectedValue);
                DataTable Available = Conn.RUN_SELECT("sorting", "*", null, filter, null, null, true);
                btnCodiceMov.Tag = "manage.sorting.tree." + filter;
                gboxClassMov.Tag = "AutoManage.txtCodiceMov.tree." + filter;
                MetaData.AutoInfo AI = Meta.GetAutoInfo(txtCodiceMov.Name);
                if (AI != null) AI.startfilter = filter;
                DS.sorting.ExtendedProperties[MetaData.ExtraParams] = Available;
            }
        }
	}
}
