
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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

namespace sortingservicefilter_default {//filtraclassspese_config//
	/// <summary>
	/// Summary description for FormFiltraClassSpese_Config.
	/// </summary>
	public class Frm_sortingservicefilter_default : System.Windows.Forms.Form {
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.ComboBox cmbTipoMov;
		private System.Windows.Forms.Label label2;
		public vistaForm DS;
		MetaData Meta;
		DataAccess Conn;
		private System.Windows.Forms.ImageList imageList1;
        private ComboBox cmbTipoPrestazione;
        private Button button2;
        private GroupBox gboxClassCompensi;
        private TextBox txtDescrizioneMov;
        private TextBox txtCodiceMov;
        private Button btnCodiceClass;
        private System.ComponentModel.IContainer components;

		public Frm_sortingservicefilter_default() {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_sortingservicefilter_default));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbTipoMov = new System.Windows.Forms.ComboBox();
            this.DS = new sortingservicefilter_default.vistaForm();
            this.label2 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.cmbTipoPrestazione = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.gboxClassCompensi = new System.Windows.Forms.GroupBox();
            this.txtDescrizioneMov = new System.Windows.Forms.TextBox();
            this.txtCodiceMov = new System.Windows.Forms.TextBox();
            this.btnCodiceClass = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.gboxClassCompensi.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.gboxClassCompensi);
            this.groupBox3.Controls.Add(this.cmbTipoMov);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(8, 53);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(517, 166);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Tag = "";
            this.groupBox3.Text = "Classificazione Tipo Prestazione";
            // 
            // cmbTipoMov
            // 
            this.cmbTipoMov.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTipoMov.DataSource = this.DS.sortingkind;
            this.cmbTipoMov.DisplayMember = "description";
            this.cmbTipoMov.Location = new System.Drawing.Point(80, 24);
            this.cmbTipoMov.Name = "cmbTipoMov";
            this.cmbTipoMov.Size = new System.Drawing.Size(429, 21);
            this.cmbTipoMov.TabIndex = 1;
            this.cmbTipoMov.Tag = "sortingservicefilter.idsorkind";
            this.cmbTipoMov.ValueMember = "idsorkind";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tipo:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            // 
            // cmbTipoPrestazione
            // 
            this.cmbTipoPrestazione.DataSource = this.DS.service;
            this.cmbTipoPrestazione.DisplayMember = "description";
            this.cmbTipoPrestazione.Location = new System.Drawing.Point(137, 16);
            this.cmbTipoPrestazione.Name = "cmbTipoPrestazione";
            this.cmbTipoPrestazione.Size = new System.Drawing.Size(388, 21);
            this.cmbTipoPrestazione.TabIndex = 21;
            this.cmbTipoPrestazione.Tag = "sortingservicefilter.idser";
            this.cmbTipoPrestazione.ValueMember = "idser";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(21, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 23);
            this.button2.TabIndex = 22;
            this.button2.TabStop = false;
            this.button2.Tag = "choose.service.default";
            this.button2.Text = "Tipo Prestazione";
            // 
            // gboxClassCompensi
            // 
            this.gboxClassCompensi.Controls.Add(this.txtDescrizioneMov);
            this.gboxClassCompensi.Controls.Add(this.txtCodiceMov);
            this.gboxClassCompensi.Controls.Add(this.btnCodiceClass);
            this.gboxClassCompensi.Location = new System.Drawing.Point(6, 60);
            this.gboxClassCompensi.Name = "gboxClassCompensi";
            this.gboxClassCompensi.Size = new System.Drawing.Size(503, 87);
            this.gboxClassCompensi.TabIndex = 11;
            this.gboxClassCompensi.TabStop = false;
            // 
            // txtDescrizioneMov
            // 
            this.txtDescrizioneMov.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizioneMov.Location = new System.Drawing.Point(120, 19);
            this.txtDescrizioneMov.Multiline = true;
            this.txtDescrizioneMov.Name = "txtDescrizioneMov";
            this.txtDescrizioneMov.ReadOnly = true;
            this.txtDescrizioneMov.Size = new System.Drawing.Size(377, 48);
            this.txtDescrizioneMov.TabIndex = 12;
            this.txtDescrizioneMov.TabStop = false;
            this.txtDescrizioneMov.Tag = "sorting.description";
            // 
            // txtCodiceMov
            // 
            this.txtCodiceMov.Location = new System.Drawing.Point(3, 43);
            this.txtCodiceMov.Name = "txtCodiceMov";
            this.txtCodiceMov.Size = new System.Drawing.Size(106, 20);
            this.txtCodiceMov.TabIndex = 13;
            this.txtCodiceMov.Tag = "sorting.sortcode?sortingservicefilterview.sortingcode";
            // 
            // btnCodiceClass
            // 
            this.btnCodiceClass.Location = new System.Drawing.Point(3, 19);
            this.btnCodiceClass.Name = "btnCodiceClass";
            this.btnCodiceClass.Size = new System.Drawing.Size(66, 23);
            this.btnCodiceClass.TabIndex = 11;
            this.btnCodiceClass.Tag = "manage.sorting.tree";
            this.btnCodiceClass.Text = "Codice";
            this.btnCodiceClass.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // Frm_sortingservicefilter_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(537, 232);
            this.Controls.Add(this.cmbTipoPrestazione);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox3);
            this.Name = "Frm_sortingservicefilter_default";
            this.Text = "FormFiltraClassCompensi_Config";
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.gboxClassCompensi.ResumeLayout(false);
            this.gboxClassCompensi.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion
        CQueryHelper QHC;
        QueryHelper QHS;
		public void MetaData_AfterLink() {
			Meta= MetaData.GetMetaData(this);
			Conn= Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
            string filtereserc = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            string filter = QHS.NullOrEq("flagdalia", "S");
            GetData.SetStaticFilter(DS.service, filter);
            //GetData.CacheTable(DS.service);

            GetData.MarkToAddBlankRow(DS.service);
            GetData.Add_Blank_Row(DS.service);

            string filterActive = QHS.DoPar(QHS.AppOr(QHS.NullOrEq("active", 'S'), QHS.CmpEq("active", "")));
            string filterI = QHS.DoPar(QHS.AppOr(QHS.DoPar(QHS.AppAnd(QHS.NullOrLe("start", Meta.GetSys("esercizio")),
                    QHS.NullOrGe("stop", Meta.GetSys("esercizio")), filterActive)), QHS.CmpEq("idsorkind", 0)));

            QueryCreator.SetFilterForInsert(DS.sortingapplicabilityview, filterI);

            string filterI_SK = QHS.DoPar(QHS.AppOr(QHS.DoPar(QHS.AppAnd(QHS.NullOrLe("start", Meta.GetSys("esercizio")),
                QHS.NullOrGe("stop", Meta.GetSys("esercizio")), filterActive)), QHS.CmpEq("idsorkind", 0)));
            
            QueryCreator.SetFilterForInsert(DS.sortingkind, filterI_SK);
		}


		public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
		 
			if (T.TableName == "sortingkind") {
				if (MetaData.GetMetaData(this).DrawState== MetaData.form_drawstates.done) {
					if ((!MetaData.Empty(this))) {
						DS.sortingservicefilter.Rows[0]["idsor"]=0;
						DS.sortingservicefilter.Rows[0]["idsorkind"]=0;
					}
					txtCodiceMov.Text="";
					txtDescrizioneMov.Text="";
					DS.sorting.Clear();
				}
				SetCodiceMovim();
			}

		}

		 
		void SetCodiceMovim() {
			btnCodiceClass.Enabled= (cmbTipoMov.SelectedIndex>0);
			txtCodiceMov.ReadOnly= (cmbTipoMov.SelectedIndex<=0);
			if (cmbTipoMov.SelectedIndex<=0) {
				txtCodiceMov.Text="";
				txtDescrizioneMov.Text="";
			}
			else {
                string filter = QHS.CmpEq("idsorkind", cmbTipoMov.SelectedValue);
				DataTable Available= Conn.RUN_SELECT("sorting","*",null,filter,null,null,true);
				btnCodiceClass.Tag="manage.sorting.tree."+filter;
				gboxClassCompensi.Tag="AutoManage.txtCodiceMov.tree."+filter;

				MetaData.AutoInfo AI = Meta.GetAutoInfo(txtCodiceMov.Name);
				if (AI!=null) AI.startfilter=filter;
				DS.sorting.ExtendedProperties[MetaData.ExtraParams]=Available;
			}
		}

		public void MetaData_AfterFill() {
 
			SetCodiceMovim();
		}

		private void btnDerived_Click(object sender, System.EventArgs e) {
            string filter = "";

            if ((!MetaData.Empty(this))) {
				Meta.GetFormData(true);
				string excludecurrent="";
				DataRow Curr = DS.sortingservicefilter.Rows[0];
				object idautosort= Curr["idautosort"];
                excludecurrent = QHS.CmpNe("idautosort", idautosort);
				filter =  excludecurrent;	
			}
			DataRow Selected = Meta.SelectOne(Meta.DefaultListType,filter,null,null);
			if (Selected!=null) Meta.SelectRow(Selected,Meta.DefaultListType);
			
		}
	}
}
