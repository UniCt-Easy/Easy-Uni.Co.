
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
using funzioni_configurazione;
namespace csa_bill_default
{
	/// <summary>
	/// </summary>
    public class Frm_csa_bill_default : System.Windows.Forms.Form {
        private System.Windows.Forms.ImageList images;
        public vistaForm DS;
        MetaData Meta;
        private GroupBox groupCredDeb;
        private TextBox txtCredDeb;
        private Label label3;
        private Label label2;
        private TextBox txtIdcsa_bill;
        private Label label1;
        private TextBox txtBillMotive;
        private GroupBox grpImportazione;
        private TextBox txtEsercImport;
        private Label label4;
        private TextBox txtNumImport;
        private Label label5;
        private TextBox txtDescription;
        private Label label6;
        private TextBox txtAmount;
        private Label label7;
        private TextBox txtAdate;
        private System.ComponentModel.IContainer components;

		public Frm_csa_bill_default()
		{
			InitializeComponent();
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
        CQueryHelper QHC;
        QueryHelper QHS;
		
        public void MetaData_AfterLink () {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            DS.bill.setStaticFilter(QHS.CmpEq("billkind", "D"));
            DS.bill.setStaticFilter(QHS.CmpEq("ybill", Meta.GetSys("esercizio")));
        }

        public void MetaData_AfterFill () {
            EnableDisableControls(false);
        }

        public void MetaData_AfterClear() {
            EnableDisableControls(true);
        }


        void EnableDisableControls(bool enable) {

            txtEsercImport.ReadOnly = !enable;
            txtNumImport.ReadOnly = !enable;
            txtAdate.ReadOnly = !enable;
            txtAmount.ReadOnly = !enable;
            txtBillMotive.ReadOnly = !enable;
            txtCredDeb.ReadOnly = !enable;
            txtDescription.ReadOnly = !enable;
            txtIdcsa_bill.ReadOnly = !enable;

        }
        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_csa_bill_default));
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.groupCredDeb = new System.Windows.Forms.GroupBox();
            this.txtCredDeb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdcsa_bill = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBillMotive = new System.Windows.Forms.TextBox();
            this.grpImportazione = new System.Windows.Forms.GroupBox();
            this.txtEsercImport = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNumImport = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.DS = new csa_bill_default.vistaForm();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAdate = new System.Windows.Forms.TextBox();
            this.groupCredDeb.SuspendLayout();
            this.grpImportazione.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
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
            // groupCredDeb
            // 
            this.groupCredDeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupCredDeb.Controls.Add(this.txtCredDeb);
            this.groupCredDeb.Location = new System.Drawing.Point(25, 247);
            this.groupCredDeb.Name = "groupCredDeb";
            this.groupCredDeb.Size = new System.Drawing.Size(435, 56);
            this.groupCredDeb.TabIndex = 5;
            this.groupCredDeb.TabStop = false;
            this.groupCredDeb.Tag = "AutoChoose.txtCredDeb.lista.(active=\'S\')";
            this.groupCredDeb.Text = "Anagrafica";
            // 
            // txtCredDeb
            // 
            this.txtCredDeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCredDeb.Location = new System.Drawing.Point(8, 24);
            this.txtCredDeb.Name = "txtCredDeb";
            this.txtCredDeb.Size = new System.Drawing.Size(419, 20);
            this.txtCredDeb.TabIndex = 0;
            this.txtCredDeb.Tag = "registry.title?csa_billview.registry";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(24, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 28);
            this.label3.TabIndex = 0;
            this.label3.Text = "Causale del sospeso:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(11, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Descrizione:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtIdcsa_bill
            // 
            this.txtIdcsa_bill.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIdcsa_bill.Location = new System.Drawing.Point(361, 32);
            this.txtIdcsa_bill.Name = "txtIdcsa_bill";
            this.txtIdcsa_bill.Size = new System.Drawing.Size(100, 20);
            this.txtIdcsa_bill.TabIndex = 1;
            this.txtIdcsa_bill.Tag = "csa_bill.idcsa_bill";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(290, 326);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Importo:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBillMotive
            // 
            this.txtBillMotive.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBillMotive.Location = new System.Drawing.Point(110, 178);
            this.txtBillMotive.Multiline = true;
            this.txtBillMotive.Name = "txtBillMotive";
            this.txtBillMotive.Size = new System.Drawing.Size(350, 49);
            this.txtBillMotive.TabIndex = 3;
            this.txtBillMotive.Tag = "bill.motive?csa_billview.motive";
            // 
            // grpImportazione
            // 
            this.grpImportazione.Controls.Add(this.txtEsercImport);
            this.grpImportazione.Controls.Add(this.label4);
            this.grpImportazione.Controls.Add(this.txtNumImport);
            this.grpImportazione.Controls.Add(this.label5);
            this.grpImportazione.Location = new System.Drawing.Point(12, 12);
            this.grpImportazione.Name = "grpImportazione";
            this.grpImportazione.Size = new System.Drawing.Size(343, 45);
            this.grpImportazione.TabIndex = 13;
            this.grpImportazione.TabStop = false;
            this.grpImportazione.Text = "Importazione";
            // 
            // txtEsercImport
            // 
            this.txtEsercImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEsercImport.Location = new System.Drawing.Point(74, 19);
            this.txtEsercImport.Name = "txtEsercImport";
            this.txtEsercImport.Size = new System.Drawing.Size(62, 20);
            this.txtEsercImport.TabIndex = 1;
            this.txtEsercImport.Tag = "csa_import.yimport.year?csa_billview.yimport.year";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(18, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 20);
            this.label4.TabIndex = 0;
            this.label4.Tag = "";
            this.label4.Text = "Esercizio:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNumImport
            // 
            this.txtNumImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumImport.Location = new System.Drawing.Point(245, 20);
            this.txtNumImport.Name = "txtNumImport";
            this.txtNumImport.Size = new System.Drawing.Size(80, 20);
            this.txtNumImport.TabIndex = 2;
            this.txtNumImport.Tag = "csa_import.nimport?csa_billview.nimport";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Location = new System.Drawing.Point(188, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 20);
            this.label5.TabIndex = 0;
            this.label5.Tag = "";
            this.label5.Text = "Numero:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(110, 117);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(350, 49);
            this.txtDescription.TabIndex = 14;
            this.txtDescription.Tag = "csa_import.description?csa_billview.description";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Location = new System.Drawing.Point(405, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 16);
            this.label6.TabIndex = 15;
            this.label6.Text = "#:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAmount
            // 
            this.txtAmount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAmount.Location = new System.Drawing.Point(361, 326);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(100, 20);
            this.txtAmount.TabIndex = 16;
            this.txtAmount.Tag = "csa_bill.amount";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(318, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 23);
            this.label7.TabIndex = 17;
            this.label7.Text = "Data:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAdate
            // 
            this.txtAdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAdate.Location = new System.Drawing.Point(361, 74);
            this.txtAdate.Name = "txtAdate";
            this.txtAdate.Size = new System.Drawing.Size(100, 20);
            this.txtAdate.TabIndex = 18;
            this.txtAdate.Tag = "csa_import.adate?csa_billview.adate";
            // 
            // Frm_csa_bill_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(476, 427);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtAdate);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.grpImportazione);
            this.Controls.Add(this.groupCredDeb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIdcsa_bill);
            this.Controls.Add(this.txtBillMotive);
            this.Controls.Add(this.label1);
            this.Name = "Frm_csa_bill_default";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmEnte";
            this.groupCredDeb.ResumeLayout(false);
            this.groupCredDeb.PerformLayout();
            this.grpImportazione.ResumeLayout(false);
            this.grpImportazione.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
	}
}
