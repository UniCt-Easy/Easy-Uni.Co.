
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using metadatalibrary;

namespace assetgrant_single {
    public partial class Frm_assetgrant_single : MetaDataForm {


        public MetaData Meta;

        public Frm_assetgrant_single() {
            InitializeComponent();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
			this.btnOk = new System.Windows.Forms.Button();
			this.btnAnnulla = new System.Windows.Forms.Button();
			this.grpSubManager = new System.Windows.Forms.GroupBox();
			this.chkFlag_entryprofitreservedone = new System.Windows.Forms.CheckBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.rdbFlag_financesourceU = new System.Windows.Forms.RadioButton();
			this.rdbFlag_financesourceC = new System.Windows.Forms.RadioButton();
			this.grpBoxImpegniBudget = new System.Windows.Forms.GroupBox();
			this.label34 = new System.Windows.Forms.Label();
			this.label33 = new System.Windows.Forms.Label();
			this.txtNumIxBudget = new System.Windows.Forms.TextBox();
			this.txtEsercIxBudget = new System.Windows.Forms.TextBox();
			this.txtDataDocumento = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtDescrizione = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.gboxFinanziamento = new System.Windows.Forms.GroupBox();
			this.txtFinanziamento = new System.Windows.Forms.TextBox();
			this.btnFinanziamento = new System.Windows.Forms.Button();
			this.gBoxCausale = new System.Windows.Forms.GroupBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.txtCodiceCausale = new System.Windows.Forms.TextBox();
			this.button4 = new System.Windows.Forms.Button();
			this.txtImporto = new System.Windows.Forms.TextBox();
			this.txtAnnoRisc = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.DS = new assetgrant_single.vistaForm();
			this.grpSubManager.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.grpBoxImpegniBudget.SuspendLayout();
			this.gboxFinanziamento.SuspendLayout();
			this.gBoxCausale.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(644, 323);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(69, 23);
			this.btnOk.TabIndex = 8;
			this.btnOk.Tag = "mainsave";
			this.btnOk.Text = "Ok";
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnAnnulla.Location = new System.Drawing.Point(728, 323);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.Size = new System.Drawing.Size(69, 23);
			this.btnAnnulla.TabIndex = 9;
			this.btnAnnulla.Text = "Annulla";
			// 
			// grpSubManager
			// 
			this.grpSubManager.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpSubManager.Controls.Add(this.chkFlag_entryprofitreservedone);
			this.grpSubManager.Controls.Add(this.groupBox2);
			this.grpSubManager.Controls.Add(this.btnAnnulla);
			this.grpSubManager.Controls.Add(this.btnOk);
			this.grpSubManager.Controls.Add(this.grpBoxImpegniBudget);
			this.grpSubManager.Controls.Add(this.txtDataDocumento);
			this.grpSubManager.Controls.Add(this.label6);
			this.grpSubManager.Controls.Add(this.textBox1);
			this.grpSubManager.Controls.Add(this.label3);
			this.grpSubManager.Controls.Add(this.txtDescrizione);
			this.grpSubManager.Controls.Add(this.label5);
			this.grpSubManager.Controls.Add(this.gboxFinanziamento);
			this.grpSubManager.Controls.Add(this.gBoxCausale);
			this.grpSubManager.Controls.Add(this.txtImporto);
			this.grpSubManager.Controls.Add(this.txtAnnoRisc);
			this.grpSubManager.Controls.Add(this.label2);
			this.grpSubManager.Controls.Add(this.label1);
			this.grpSubManager.Location = new System.Drawing.Point(11, 5);
			this.grpSubManager.Name = "grpSubManager";
			this.grpSubManager.Size = new System.Drawing.Size(812, 352);
			this.grpSubManager.TabIndex = 16;
			this.grpSubManager.TabStop = false;
			this.grpSubManager.Tag = "";
			this.grpSubManager.Enter += new System.EventHandler(this.grpSubManager_Enter);
			// 
			// chkFlag_entryprofitreservedone
			// 
			this.chkFlag_entryprofitreservedone.AutoSize = true;
			this.chkFlag_entryprofitreservedone.Location = new System.Drawing.Point(477, 76);
			this.chkFlag_entryprofitreservedone.Name = "chkFlag_entryprofitreservedone";
			this.chkFlag_entryprofitreservedone.Size = new System.Drawing.Size(256, 17);
			this.chkFlag_entryprofitreservedone.TabIndex = 58;
			this.chkFlag_entryprofitreservedone.Tag = "assetgrant.flag_entryprofitreservedone:S:N";
			this.chkFlag_entryprofitreservedone.Text = "Scrittura di costituzione delle riserve già esistente";
			this.chkFlag_entryprofitreservedone.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.rdbFlag_financesourceU);
			this.groupBox2.Controls.Add(this.rdbFlag_financesourceC);
			this.groupBox2.Location = new System.Drawing.Point(471, 9);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(266, 61);
			this.groupBox2.TabIndex = 57;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Tipo finanziamento";
			// 
			// rdbFlag_financesourceU
			// 
			this.rdbFlag_financesourceU.AutoSize = true;
			this.rdbFlag_financesourceU.Location = new System.Drawing.Point(9, 37);
			this.rdbFlag_financesourceU.Name = "rdbFlag_financesourceU";
			this.rdbFlag_financesourceU.Size = new System.Drawing.Size(144, 17);
			this.rdbFlag_financesourceU.TabIndex = 1;
			this.rdbFlag_financesourceU.TabStop = true;
			this.rdbFlag_financesourceU.Tag = "assetgrant.flag_financesource:U";
			this.rdbFlag_financesourceU.Text = "Utili di esercizi precedenti";
			this.rdbFlag_financesourceU.UseVisualStyleBackColor = true;
			this.rdbFlag_financesourceU.CheckedChanged += new System.EventHandler(this.rdbFlag_financesourceU_CheckedChanged);
			// 
			// rdbFlag_financesourceC
			// 
			this.rdbFlag_financesourceC.AutoSize = true;
			this.rdbFlag_financesourceC.Location = new System.Drawing.Point(9, 18);
			this.rdbFlag_financesourceC.Name = "rdbFlag_financesourceC";
			this.rdbFlag_financesourceC.Size = new System.Drawing.Size(235, 17);
			this.rdbFlag_financesourceC.TabIndex = 0;
			this.rdbFlag_financesourceC.TabStop = true;
			this.rdbFlag_financesourceC.Tag = "assetgrant.flag_financesource:C";
			this.rdbFlag_financesourceC.Text = "Contributo agli investimenti finanziato da terzi";
			this.rdbFlag_financesourceC.UseVisualStyleBackColor = true;
			this.rdbFlag_financesourceC.CheckedChanged += new System.EventHandler(this.rdbFlag_financesourceC_CheckedChanged);
			// 
			// grpBoxImpegniBudget
			// 
			this.grpBoxImpegniBudget.Controls.Add(this.label34);
			this.grpBoxImpegniBudget.Controls.Add(this.label33);
			this.grpBoxImpegniBudget.Controls.Add(this.txtNumIxBudget);
			this.grpBoxImpegniBudget.Controls.Add(this.txtEsercIxBudget);
			this.grpBoxImpegniBudget.Location = new System.Drawing.Point(595, 174);
			this.grpBoxImpegniBudget.Name = "grpBoxImpegniBudget";
			this.grpBoxImpegniBudget.Size = new System.Drawing.Size(199, 71);
			this.grpBoxImpegniBudget.TabIndex = 55;
			this.grpBoxImpegniBudget.TabStop = false;
			this.grpBoxImpegniBudget.Text = "Accertamento di Budget";
			// 
			// label34
			// 
			this.label34.AutoSize = true;
			this.label34.Location = new System.Drawing.Point(14, 49);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(44, 13);
			this.label34.TabIndex = 7;
			this.label34.Text = "Numero";
			// 
			// label33
			// 
			this.label33.AutoSize = true;
			this.label33.Location = new System.Drawing.Point(9, 25);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(49, 13);
			this.label33.TabIndex = 6;
			this.label33.Text = "Esercizio";
			this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtNumIxBudget
			// 
			this.txtNumIxBudget.Location = new System.Drawing.Point(78, 45);
			this.txtNumIxBudget.Name = "txtNumIxBudget";
			this.txtNumIxBudget.ReadOnly = true;
			this.txtNumIxBudget.Size = new System.Drawing.Size(64, 20);
			this.txtNumIxBudget.TabIndex = 3;
			this.txtNumIxBudget.TabStop = false;
			this.txtNumIxBudget.Tag = "epacc.nepacc";
			// 
			// txtEsercIxBudget
			// 
			this.txtEsercIxBudget.Location = new System.Drawing.Point(78, 19);
			this.txtEsercIxBudget.Name = "txtEsercIxBudget";
			this.txtEsercIxBudget.ReadOnly = true;
			this.txtEsercIxBudget.Size = new System.Drawing.Size(64, 20);
			this.txtEsercIxBudget.TabIndex = 2;
			this.txtEsercIxBudget.TabStop = false;
			this.txtEsercIxBudget.Tag = "epacc.yepacc";
			// 
			// txtDataDocumento
			// 
			this.txtDataDocumento.Location = new System.Drawing.Point(151, 314);
			this.txtDataDocumento.Name = "txtDataDocumento";
			this.txtDataDocumento.Size = new System.Drawing.Size(80, 20);
			this.txtDataDocumento.TabIndex = 7;
			this.txtDataDocumento.Tag = "assetgrant.docdate";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(38, 314);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(107, 16);
			this.label6.TabIndex = 54;
			this.label6.Text = "Data Documento";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(151, 285);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(425, 20);
			this.textBox1.TabIndex = 6;
			this.textBox1.Tag = "assetgrant.doc";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(59, 284);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(86, 21);
			this.label3.TabIndex = 53;
			this.label3.Text = "Documento";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDescrizione
			// 
			this.txtDescrizione.Location = new System.Drawing.Point(151, 223);
			this.txtDescrizione.Multiline = true;
			this.txtDescrizione.Name = "txtDescrizione";
			this.txtDescrizione.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDescrizione.Size = new System.Drawing.Size(425, 56);
			this.txtDescrizione.TabIndex = 5;
			this.txtDescrizione.Tag = "assetgrant.description";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(59, 222);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(86, 21);
			this.label5.TabIndex = 51;
			this.label5.Text = "Descrizione";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// gboxFinanziamento
			// 
			this.gboxFinanziamento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxFinanziamento.Controls.Add(this.txtFinanziamento);
			this.gboxFinanziamento.Controls.Add(this.btnFinanziamento);
			this.gboxFinanziamento.Location = new System.Drawing.Point(8, 124);
			this.gboxFinanziamento.Name = "gboxFinanziamento";
			this.gboxFinanziamento.Size = new System.Drawing.Size(787, 45);
			this.gboxFinanziamento.TabIndex = 37;
			this.gboxFinanziamento.TabStop = false;
			this.gboxFinanziamento.Tag = "AutoChoose.txtFinanziamento.default.(active = \'S\')";
			this.gboxFinanziamento.Visible = false;
			// 
			// txtFinanziamento
			// 
			this.txtFinanziamento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtFinanziamento.Location = new System.Drawing.Point(118, 14);
			this.txtFinanziamento.Multiline = true;
			this.txtFinanziamento.Name = "txtFinanziamento";
			this.txtFinanziamento.Size = new System.Drawing.Size(658, 22);
			this.txtFinanziamento.TabIndex = 2;
			this.txtFinanziamento.TabStop = false;
			this.txtFinanziamento.Tag = "underwriting.title";
			// 
			// btnFinanziamento
			// 
			this.btnFinanziamento.Location = new System.Drawing.Point(6, 14);
			this.btnFinanziamento.Name = "btnFinanziamento";
			this.btnFinanziamento.Size = new System.Drawing.Size(104, 23);
			this.btnFinanziamento.TabIndex = 0;
			this.btnFinanziamento.Tag = "choose.underwriting.default";
			this.btnFinanziamento.Text = "Finanziamento";
			this.btnFinanziamento.UseVisualStyleBackColor = true;
			// 
			// gBoxCausale
			// 
			this.gBoxCausale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gBoxCausale.Controls.Add(this.textBox3);
			this.gBoxCausale.Controls.Add(this.txtCodiceCausale);
			this.gBoxCausale.Controls.Add(this.button4);
			this.gBoxCausale.Location = new System.Drawing.Point(11, 9);
			this.gBoxCausale.Name = "gBoxCausale";
			this.gBoxCausale.Size = new System.Drawing.Size(454, 87);
			this.gBoxCausale.TabIndex = 36;
			this.gBoxCausale.TabStop = false;
			this.gBoxCausale.Tag = "AutoManage.txtCodiceCausale.tree";
			this.gBoxCausale.Text = "Causale Ricavo/Riserva";
			// 
			// textBox3
			// 
			this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox3.Location = new System.Drawing.Point(212, 10);
			this.textBox3.Multiline = true;
			this.textBox3.Name = "textBox3";
			this.textBox3.ReadOnly = true;
			this.textBox3.Size = new System.Drawing.Size(236, 67);
			this.textBox3.TabIndex = 2;
			this.textBox3.Tag = "accmotive.title?x";
			// 
			// txtCodiceCausale
			// 
			this.txtCodiceCausale.Location = new System.Drawing.Point(6, 56);
			this.txtCodiceCausale.Name = "txtCodiceCausale";
			this.txtCodiceCausale.Size = new System.Drawing.Size(200, 20);
			this.txtCodiceCausale.TabIndex = 1;
			this.txtCodiceCausale.Tag = "accmotive.codemotive?x";
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(6, 18);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(104, 24);
			this.button4.TabIndex = 0;
			this.button4.Tag = "manage.accmotive.tree";
			this.button4.Text = "Causale";
			// 
			// txtImporto
			// 
			this.txtImporto.Location = new System.Drawing.Point(151, 197);
			this.txtImporto.Name = "txtImporto";
			this.txtImporto.Size = new System.Drawing.Size(112, 20);
			this.txtImporto.TabIndex = 4;
			this.txtImporto.Tag = "assetgrant.amount";
			// 
			// txtAnnoRisc
			// 
			this.txtAnnoRisc.Location = new System.Drawing.Point(151, 174);
			this.txtAnnoRisc.Name = "txtAnnoRisc";
			this.txtAnnoRisc.Size = new System.Drawing.Size(112, 20);
			this.txtAnnoRisc.TabIndex = 3;
			this.txtAnnoRisc.Tag = "assetgrant.ygrant.year";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(49, 194);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(96, 17);
			this.label2.TabIndex = 11;
			this.label2.Text = "Importo ";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(65, 174);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 16);
			this.label1.TabIndex = 9;
			this.label1.Text = "Anno";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			// 
			// Frm_assetgrant_single
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnAnnulla;
			this.ClientSize = new System.Drawing.Size(830, 369);
			this.Controls.Add(this.grpSubManager);
			this.Name = "Frm_assetgrant_single";
			this.Text = "frmassetgrantsingle";
			this.Load += new System.EventHandler(this.Frm_assetgrant_single_Load);
			this.grpSubManager.ResumeLayout(false);
			this.grpSubManager.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.grpBoxImpegniBudget.ResumeLayout(false);
			this.grpBoxImpegniBudget.PerformLayout();
			this.gboxFinanziamento.ResumeLayout(false);
			this.gboxFinanziamento.PerformLayout();
			this.gBoxCausale.ResumeLayout(false);
			this.gBoxCausale.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.GroupBox grpSubManager;
        private System.Windows.Forms.TextBox txtImporto;
        private System.Windows.Forms.TextBox txtAnnoRisc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gboxFinanziamento;
        private System.Windows.Forms.TextBox txtFinanziamento;
        private System.Windows.Forms.Button btnFinanziamento;
        private System.Windows.Forms.GroupBox gBoxCausale;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox txtCodiceCausale;
        private System.Windows.Forms.Button button4;

        ///// <summary>
        ///// Clean up any resources being used.
        ///// </summary>
        ///// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing) {
        //    if (disposing && (components != null)) {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
        //protected override void Dispose(bool disposing) {
        //    inChiusura = true;
        //    if (disposing) {
        //        if (components != null) {
        //            components.Dispose();
        //        }
        //    }
        //    base.Dispose(disposing);
        //}

        public void MetaData_AfterClear() {
            enableControls(true);
        }

        private void enableControls(bool abilita) {
            bool readOnly = !abilita;

            txtAnnoRisc.Enabled = abilita;
        }

		public void MetaData_AfterLink() {
			HelpForm.SetDenyNull(DS.assetgrant.Columns["flag_entryprofitreservedone"], true);
		}
			public void MetaData_AfterFill() {

            enableControls(false);
        }


        private void Frm_assetgrant_single_Load(object sender, EventArgs e) {

        }

        private void grpSubManager_Enter(object sender, EventArgs e) {

        }

		private void rdbFlag_financesourceC_CheckedChanged(object sender, EventArgs e) {
			bool Contributo = !rdbFlag_financesourceU.Checked;
			if (Contributo) {
				chkFlag_entryprofitreservedone.Enabled = false;
			}
			else {
				chkFlag_entryprofitreservedone.Enabled = true;
			}
		}

		private void rdbFlag_financesourceU_CheckedChanged(object sender, EventArgs e) {
			bool Utile = !rdbFlag_financesourceC.Checked;
			if (Utile) {
				chkFlag_entryprofitreservedone.Enabled = true;
			}
			else {
				chkFlag_entryprofitreservedone.Enabled = false;
			}
		}
	}
}
