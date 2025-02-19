
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
using System.Data;

namespace accountsorting_imputazione {
	/// <summary>
	/// Summary description for Frm_accountsorting_imputazione.
	/// </summary>
	public class Frm_accountsorting_imputazione : MetaDataForm {
        public accountsorting_imputazione.vistaForm DS;
        public string param;
      
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        CQueryHelper QHC;
        QueryHelper QHS;
        private GroupBox grpTipoClass;
        private PictureBox pictureBox1;
        private GroupBox gboxclass;
        private TextBox txtDescrizione;
        private TextBox txtCodice;
        private Button btnCodice;
        private TextBox textBox1;
        private Label label2;
		private GroupBox gboxConto;
		private TextBox txtDenominazioneConto;
		private TextBox txtCodiceConto;
		private Button btnConto;
		MetaData Meta;
		public Frm_accountsorting_imputazione() {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_accountsorting_imputazione));
			this.grpTipoClass = new System.Windows.Forms.GroupBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.gboxclass = new System.Windows.Forms.GroupBox();
			this.txtDescrizione = new System.Windows.Forms.TextBox();
			this.txtCodice = new System.Windows.Forms.TextBox();
			this.btnCodice = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.gboxConto = new System.Windows.Forms.GroupBox();
			this.txtDenominazioneConto = new System.Windows.Forms.TextBox();
			this.txtCodiceConto = new System.Windows.Forms.TextBox();
			this.btnConto = new System.Windows.Forms.Button();
			this.DS = new accountsorting_imputazione.vistaForm();
			this.grpTipoClass.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.gboxclass.SuspendLayout();
			this.gboxConto.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// grpTipoClass
			// 
			this.grpTipoClass.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpTipoClass.Controls.Add(this.pictureBox1);
			this.grpTipoClass.Controls.Add(this.gboxclass);
			this.grpTipoClass.Controls.Add(this.textBox1);
			this.grpTipoClass.Controls.Add(this.label2);
			this.grpTipoClass.Location = new System.Drawing.Point(8, 117);
			this.grpTipoClass.Name = "grpTipoClass";
			this.grpTipoClass.Size = new System.Drawing.Size(556, 152);
			this.grpTipoClass.TabIndex = 12;
			this.grpTipoClass.TabStop = false;
			this.grpTipoClass.Tag = "";
			this.grpTipoClass.Text = "Classificazione";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(24, 66);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(64, 48);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 15;
			this.pictureBox1.TabStop = false;
			// 
			// gboxclass
			// 
			this.gboxclass.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxclass.Controls.Add(this.txtDescrizione);
			this.gboxclass.Controls.Add(this.txtCodice);
			this.gboxclass.Controls.Add(this.btnCodice);
			this.gboxclass.Location = new System.Drawing.Point(184, 19);
			this.gboxclass.Name = "gboxclass";
			this.gboxclass.Size = new System.Drawing.Size(366, 127);
			this.gboxclass.TabIndex = 2;
			this.gboxclass.TabStop = false;
			this.gboxclass.Tag = "AutoManage.txtCodice.tree";
			// 
			// txtDescrizione
			// 
			this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescrizione.Location = new System.Drawing.Point(120, 16);
			this.txtDescrizione.Multiline = true;
			this.txtDescrizione.Name = "txtDescrizione";
			this.txtDescrizione.ReadOnly = true;
			this.txtDescrizione.Size = new System.Drawing.Size(222, 79);
			this.txtDescrizione.TabIndex = 6;
			this.txtDescrizione.TabStop = false;
			this.txtDescrizione.Tag = "sorting.description";
			// 
			// txtCodice
			// 
			this.txtCodice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCodice.Location = new System.Drawing.Point(6, 101);
			this.txtCodice.Name = "txtCodice";
			this.txtCodice.Size = new System.Drawing.Size(336, 20);
			this.txtCodice.TabIndex = 2;
			this.txtCodice.Tag = "sorting.sortcode?accountsortingview.sortcode";
			// 
			// btnCodice
			// 
			this.btnCodice.Location = new System.Drawing.Point(6, 72);
			this.btnCodice.Name = "btnCodice";
			this.btnCodice.Size = new System.Drawing.Size(96, 23);
			this.btnCodice.TabIndex = 1;
			this.btnCodice.TabStop = false;
			this.btnCodice.Tag = "manage.sorting.tree";
			this.btnCodice.Text = "Codice";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(104, 23);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(72, 20);
			this.textBox1.TabIndex = 1;
			this.textBox1.Tag = "accountsorting.quota.fixed.2..%.100";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(24, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 12;
			this.label2.Text = "Quota:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// gboxConto
			// 
			this.gboxConto.Controls.Add(this.txtDenominazioneConto);
			this.gboxConto.Controls.Add(this.txtCodiceConto);
			this.gboxConto.Controls.Add(this.btnConto);
			this.gboxConto.Location = new System.Drawing.Point(8, 4);
			this.gboxConto.Name = "gboxConto";
			this.gboxConto.Size = new System.Drawing.Size(556, 113);
			this.gboxConto.TabIndex = 61;
			this.gboxConto.TabStop = false;
			this.gboxConto.Tag = "AutoChoose.txtCodiceConto.default";
			// 
			// txtDenominazioneConto
			// 
			this.txtDenominazioneConto.Location = new System.Drawing.Point(134, 19);
			this.txtDenominazioneConto.Multiline = true;
			this.txtDenominazioneConto.Name = "txtDenominazioneConto";
			this.txtDenominazioneConto.ReadOnly = true;
			this.txtDenominazioneConto.Size = new System.Drawing.Size(416, 64);
			this.txtDenominazioneConto.TabIndex = 2;
			this.txtDenominazioneConto.TabStop = false;
			this.txtDenominazioneConto.Tag = "account.title";
			// 
			// txtCodiceConto
			// 
			this.txtCodiceConto.Location = new System.Drawing.Point(6, 87);
			this.txtCodiceConto.Name = "txtCodiceConto";
			this.txtCodiceConto.Size = new System.Drawing.Size(544, 20);
			this.txtCodiceConto.TabIndex = 1;
			this.txtCodiceConto.Tag = "account.codeacc?accountsortingview.codeacc";
			// 
			// btnConto
			// 
			this.btnConto.Location = new System.Drawing.Point(8, 57);
			this.btnConto.Name = "btnConto";
			this.btnConto.Size = new System.Drawing.Size(120, 23);
			this.btnConto.TabIndex = 0;
			this.btnConto.TabStop = false;
			this.btnConto.Tag = "manage.account.tree";
			this.btnConto.Text = "Conto";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// Frm_accountsorting_imputazione
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(576, 281);
			this.Controls.Add(this.gboxConto);
			this.Controls.Add(this.grpTipoClass);
			this.Name = "Frm_accountsorting_imputazione";
			this.Text = "Frm_accountsorting_imputazione";
			this.grpTipoClass.ResumeLayout(false);
			this.grpTipoClass.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.gboxclass.ResumeLayout(false);
			this.gboxclass.PerformLayout();
			this.gboxConto.ResumeLayout(false);
			this.gboxConto.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            object idsorkind = null;
            param = Meta.ExtraParameter?.ToString();
            DataTable DescrClass = Meta.Conn.RUN_SELECT("sortingkind", "description", null,
                QHS.CmpEq("idsorkind", param), null, null, true);
            if (DescrClass.Rows.Count == 0)
                Meta.Name = "Piano dei conti a \"" + param + "\"";
            else
                Meta.Name = "Piano dei conti  a \"" +
                    DescrClass.Rows[0]["description"].ToString() + "\"";

            Meta.DefaultListType = "elenco." + param;
            idsorkind = param;
            string filter = QHS.CmpEq("idsorkind", idsorkind);
			GetData.SetStaticFilter(DS.accountsortingview, QHS.AppAnd(QHS.CmpEq("ayear", Meta.GetSys("esercizio")), filter));
			//GetData.SetStaticFilter(DS.accountsorting, filter);
            GetData.SetStaticFilter(DS.sorting, filter);

            GetData.CacheTable(DS.sortingkind, filter, null, false);
            gboxclass.Tag += "." + filter;
            btnCodice.Tag += "." + filter;
            DS.sorting.ExtendedProperties[MetaData.ExtraParams] = filter;
        }
        public void MetaData_AfterClear () {
            txtCodice.ReadOnly = false;
        }
        public void MetaData_AfterFill () {
            if (Meta.EditMode)
                txtCodice.ReadOnly = true;
            else
                txtCodice.ReadOnly = false;
        }
	}
}
