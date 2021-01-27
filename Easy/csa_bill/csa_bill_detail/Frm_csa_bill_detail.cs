
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
using System.Collections.Generic;

namespace csa_bill_detail
{
	/// <summary>
	/// </summary>
    public class Frm_csa_bill_detail : System.Windows.Forms.Form {
        private System.Windows.Forms.ImageList images;
        public vistaForm DS;
        MetaData Meta;
        private GroupBox groupCredDeb;
        private TextBox txtCredDeb;
        private Label label3;
        private TextBox txtIdcsa_bill;
        private Label label1;
        private TextBox txtBillMotive;
        private GroupBox grpImportazione;
        private TextBox txtEsercImport;
        private Label label4;
        private TextBox txtNumImport;
        private Label label5;
        private Label label6;
        private TextBox txtAmount;
        private Label label7;
        private TextBox txtAdate;
        private Button btnOk;
        private Button btnAnnulla;
        private TextBox txtDescription;
        private Label label2;
        private GroupBox gboxBolletta;
        private TextBox txtBolletta;
        private Button btnBolletta;
        private System.ComponentModel.IContainer components;
        private DataAccess Conn;

		public Frm_csa_bill_detail()
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
            Conn = Meta.Conn;

            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            DS.bill.setStaticFilter(QHS.CmpEq("billkind", "D"));
            DS.bill.setStaticFilter(QHS.CmpEq("ybill", Meta.GetSys("esercizio")));

            this.btnBolletta.Tag = "choose.bill.default.((billkind = \'D\') AND(active= \'S\') AND (isnull(total,0)-isnul" +
    "l(reduction,0)>covered ) AND (ISNULL(toregularize,0)>0))" + $" AND (ybill = \'{Meta.GetSys("esercizio")}\')";
        }

        public void MetaData_AfterRowSelect(DataTable T, DataRow R)
        {
            if (Meta.IsEmpty) return;

            if (T.TableName == "bill")
            {
                if (R == null) return;
                if (Meta.InsertMode) {
                    string filter = QueryCreator.WHERE_KEY_CLAUSE(R, DataRowVersion.Default, true);
                    Conn.RUN_SELECT_INTO_TABLE(DS.csa_bill_sosp_tocoverview, null, filter, null, true);

                    DataRow[] allresults = DS.csa_bill_sosp_tocoverview.Select(QHC.CmpKey(R));
                    if (allresults.Length > 0) {
                        DataRow selected = allresults[0];

                        /*decimal alreadyadded = 0;
                        DataTable dataorigin =  Meta.SourceRow.Table;
                        foreach (DataRow temp in dataorigin.Rows)
                            //righe non ancora salvate
                            if (temp.RowState == DataRowState.Added && temp["nbill"] == selected["nbill"])
                                alreadyadded += CfgFn.GetNoNullDecimal(temp["amount"]);*/

                        this.txtAmount.Text = (CfgFn.GetNoNullDecimal(selected["tocover"]) /*- alreadyadded*/).ToString();
                    }
                }
            }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_csa_bill_detail));
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.groupCredDeb = new System.Windows.Forms.GroupBox();
            this.txtCredDeb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIdcsa_bill = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBillMotive = new System.Windows.Forms.TextBox();
            this.grpImportazione = new System.Windows.Forms.GroupBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEsercImport = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNumImport = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAdate = new System.Windows.Forms.TextBox();
            this.DS = new csa_bill_detail.vistaForm();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.gboxBolletta = new System.Windows.Forms.GroupBox();
            this.txtBolletta = new System.Windows.Forms.TextBox();
            this.btnBolletta = new System.Windows.Forms.Button();
            this.groupCredDeb.SuspendLayout();
            this.grpImportazione.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.gboxBolletta.SuspendLayout();
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
            this.groupCredDeb.Location = new System.Drawing.Point(12, 286);
            this.groupCredDeb.Name = "groupCredDeb";
            this.groupCredDeb.Size = new System.Drawing.Size(448, 56);
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
            this.txtCredDeb.Size = new System.Drawing.Size(432, 20);
            this.txtCredDeb.TabIndex = 0;
            this.txtCredDeb.Tag = "registry.title";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(22, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 28);
            this.label3.TabIndex = 0;
            this.label3.Text = "Causale:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtIdcsa_bill
            // 
            this.txtIdcsa_bill.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIdcsa_bill.Location = new System.Drawing.Point(70, 13);
            this.txtIdcsa_bill.Name = "txtIdcsa_bill";
            this.txtIdcsa_bill.Size = new System.Drawing.Size(53, 20);
            this.txtIdcsa_bill.TabIndex = 1;
            this.txtIdcsa_bill.Tag = "csa_bill.idcsa_bill";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(288, 12);
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
            this.txtBillMotive.Location = new System.Drawing.Point(85, 48);
            this.txtBillMotive.Multiline = true;
            this.txtBillMotive.Name = "txtBillMotive";
            this.txtBillMotive.Size = new System.Drawing.Size(356, 49);
            this.txtBillMotive.TabIndex = 3;
            this.txtBillMotive.Tag = "bill.motive";
            // 
            // grpImportazione
            // 
            this.grpImportazione.Controls.Add(this.txtDescription);
            this.grpImportazione.Controls.Add(this.label2);
            this.grpImportazione.Controls.Add(this.txtEsercImport);
            this.grpImportazione.Controls.Add(this.label4);
            this.grpImportazione.Controls.Add(this.txtNumImport);
            this.grpImportazione.Controls.Add(this.label7);
            this.grpImportazione.Controls.Add(this.label5);
            this.grpImportazione.Controls.Add(this.txtAdate);
            this.grpImportazione.Location = new System.Drawing.Point(12, 42);
            this.grpImportazione.Name = "grpImportazione";
            this.grpImportazione.Size = new System.Drawing.Size(449, 131);
            this.grpImportazione.TabIndex = 13;
            this.grpImportazione.TabStop = false;
            this.grpImportazione.Text = "Importazione";
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(13, 71);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(430, 49);
            this.txtDescription.TabIndex = 20;
            this.txtDescription.Tag = "csa_import.description";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(14, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 19;
            this.label2.Text = "Descrizione:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercImport
            // 
            this.txtEsercImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEsercImport.Location = new System.Drawing.Point(74, 20);
            this.txtEsercImport.Name = "txtEsercImport";
            this.txtEsercImport.Size = new System.Drawing.Size(62, 20);
            this.txtEsercImport.TabIndex = 1;
            this.txtEsercImport.Tag = "csa_import.yimport.year";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(18, 19);
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
            this.txtNumImport.Location = new System.Drawing.Point(199, 20);
            this.txtNumImport.Name = "txtNumImport";
            this.txtNumImport.Size = new System.Drawing.Size(80, 20);
            this.txtNumImport.TabIndex = 2;
            this.txtNumImport.Tag = "csa_import.nimport";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(318, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 23);
            this.label7.TabIndex = 17;
            this.label7.Text = "Data:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Location = new System.Drawing.Point(142, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 20);
            this.label5.TabIndex = 0;
            this.label5.Tag = "";
            this.label5.Text = "Numero:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAdate
            // 
            this.txtAdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAdate.Location = new System.Drawing.Point(358, 21);
            this.txtAdate.Name = "txtAdate";
            this.txtAdate.Size = new System.Drawing.Size(86, 20);
            this.txtAdate.TabIndex = 18;
            this.txtAdate.Tag = "csa_import.adate";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Location = new System.Drawing.Point(9, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 16);
            this.label6.TabIndex = 15;
            this.label6.Text = "N. riga:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAmount
            // 
            this.txtAmount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAmount.Location = new System.Drawing.Point(359, 12);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(100, 20);
            this.txtAmount.TabIndex = 16;
            // riporto la creazione del tag anche nella afterfill in maniera dinamica
            this.txtAmount.Tag = "csa_bill.amount";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(281, 364);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 210;
            this.btnOk.TabStop = false;
            this.btnOk.Tag = "mainsave";
            this.btnOk.Text = "Ok";
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(385, 364);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 211;
            this.btnAnnulla.TabStop = false;
            this.btnAnnulla.Text = "Annulla";
            // 
            // gboxBolletta
            // 
            this.gboxBolletta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxBolletta.Controls.Add(this.txtBolletta);
            this.gboxBolletta.Controls.Add(this.btnBolletta);
            this.gboxBolletta.Controls.Add(this.txtBillMotive);
            this.gboxBolletta.Controls.Add(this.label3);
            this.gboxBolletta.Location = new System.Drawing.Point(12, 175);
            this.gboxBolletta.Name = "gboxBolletta";
            this.gboxBolletta.Size = new System.Drawing.Size(449, 104);
            this.gboxBolletta.TabIndex = 212;
            this.gboxBolletta.TabStop = false;
            this.gboxBolletta.Tag = "AutoChoose.txtBolletta.default.(active = \'S\')";
            // 
            // txtBolletta
            // 
            this.txtBolletta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBolletta.Location = new System.Drawing.Point(116, 22);
            this.txtBolletta.Name = "txtBolletta";
            this.txtBolletta.Size = new System.Drawing.Size(94, 20);
            this.txtBolletta.TabIndex = 3;
            this.txtBolletta.Tag = "bill.nbill?csa_bill.nbill";
            // 
            // btnBolletta
            // 
            this.btnBolletta.Location = new System.Drawing.Point(6, 19);
            this.btnBolletta.Name = "btnBolletta";
            this.btnBolletta.Size = new System.Drawing.Size(104, 23);
            this.btnBolletta.TabIndex = 2;
            // riporto la creazione del tag nella afterlink in maniera dinamica
            //this.btnBolletta.Tag = "choose.bill.default.((billkind = \'D\') AND(active= \'S\') AND (isnull(total,0)-isnul" +
    //"l(reduction,0)>covered ) AND (ISNULL(toregularize,0)>0) )";
            this.btnBolletta.Text = "N.bolletta";
            this.btnBolletta.UseVisualStyleBackColor = true;
            // 
            // Frm_csa_bill_detail
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(476, 415);
            this.Controls.Add(this.gboxBolletta);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.grpImportazione);
            this.Controls.Add(this.groupCredDeb);
            this.Controls.Add(this.txtIdcsa_bill);
            this.Controls.Add(this.label1);
            this.Name = "Frm_csa_bill_detail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmEnte";
            this.groupCredDeb.ResumeLayout(false);
            this.groupCredDeb.PerformLayout();
            this.grpImportazione.ResumeLayout(false);
            this.grpImportazione.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.gboxBolletta.ResumeLayout(false);
            this.gboxBolletta.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
        #endregion
 
    }
}
