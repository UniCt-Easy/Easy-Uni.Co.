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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using funzioni_configurazione;//funzioni_configurazione
using System.Data;

namespace ivaregister_default {//registroiva//
	/// <summary>
	/// Summary description for frmregistroiva.
	/// </summary>
	public class Frm_ivaregister_default : System.Windows.Forms.Form {
		public vistaForm DS;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.GroupBox grpValoreUnitInValuta;
		private System.Windows.Forms.TextBox txtImpDeduc;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox txtImposta;
		private System.Windows.Forms.TextBox txtImponibile;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TextBox txtNumProt;
		private System.Windows.Forms.TextBox txtNumReg;
		private System.Windows.Forms.ComboBox cmbTipoReg;
		private System.Windows.Forms.TextBox txtDataDoc;
		private System.Windows.Forms.TextBox txtDocumento;
		private System.Windows.Forms.TextBox txtCredDeb;
		private System.Windows.Forms.TextBox txtNumDoc;
		private System.Windows.Forms.TextBox txtEsercDoc;
		private System.Windows.Forms.ComboBox cmbTipoDoc;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.TextBox txtTotale;
		private MetaData Meta;

		public Frm_ivaregister_default() {
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
			this.DS = new ivaregister_default.vistaForm();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtNumProt = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtNumReg = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.cmbTipoReg = new System.Windows.Forms.ComboBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.grpValoreUnitInValuta = new System.Windows.Forms.GroupBox();
			this.txtImpDeduc = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.txtImposta = new System.Windows.Forms.TextBox();
			this.txtTotale = new System.Windows.Forms.TextBox();
			this.txtImponibile = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.txtDataDoc = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtDocumento = new System.Windows.Forms.TextBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.txtCredDeb = new System.Windows.Forms.TextBox();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.txtNumDoc = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtEsercDoc = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.cmbTipoDoc = new System.Windows.Forms.ComboBox();
			this.label10 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.grpValoreUnitInValuta.SuspendLayout();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtNumProt);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.txtNumReg);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.cmbTipoReg);
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(352, 96);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Registrazione";
			// 
			// txtNumProt
			// 
			this.txtNumProt.Location = new System.Drawing.Point(264, 58);
			this.txtNumProt.Name = "txtNumProt";
			this.txtNumProt.Size = new System.Drawing.Size(72, 20);
			this.txtNumProt.TabIndex = 10;
			this.txtNumProt.Tag = "ivaregister.protocolnum";
			this.txtNumProt.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(200, 58);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 16);
			this.label3.TabIndex = 12;
			this.label3.Text = "Protocollo";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtNumReg
			// 
			this.txtNumReg.Location = new System.Drawing.Point(72, 58);
			this.txtNumReg.Name = "txtNumReg";
			this.txtNumReg.Size = new System.Drawing.Size(48, 20);
			this.txtNumReg.TabIndex = 9;
			this.txtNumReg.Tag = "ivaregister.nivaregister";
			this.txtNumReg.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 58);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 16);
			this.label2.TabIndex = 11;
			this.label2.Text = "Numero";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 26);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 16);
			this.label1.TabIndex = 13;
			this.label1.Text = "Tipo:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cmbTipoReg
			// 
			this.cmbTipoReg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.cmbTipoReg.DataSource = this.DS.ivaregisterkind;
			this.cmbTipoReg.DisplayMember = "description";
			this.cmbTipoReg.Location = new System.Drawing.Point(72, 26);
			this.cmbTipoReg.Name = "cmbTipoReg";
			this.cmbTipoReg.Size = new System.Drawing.Size(264, 21);
			this.cmbTipoReg.TabIndex = 8;
			this.cmbTipoReg.Tag = "ivaregister.idivaregisterkind";
			this.cmbTipoReg.ValueMember = "idivaregisterkind";
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.Controls.Add(this.grpValoreUnitInValuta);
			this.groupBox3.Controls.Add(this.label11);
			this.groupBox3.Controls.Add(this.txtDataDoc);
			this.groupBox3.Controls.Add(this.label9);
			this.groupBox3.Controls.Add(this.txtDocumento);
			this.groupBox3.Controls.Add(this.groupBox4);
			this.groupBox3.Controls.Add(this.dataGrid1);
			this.groupBox3.Controls.Add(this.txtNumDoc);
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Controls.Add(this.txtEsercDoc);
			this.groupBox3.Controls.Add(this.label7);
			this.groupBox3.Controls.Add(this.label8);
			this.groupBox3.Controls.Add(this.cmbTipoDoc);
			this.groupBox3.Location = new System.Drawing.Point(8, 112);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(696, 296);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Documento";
			// 
			// grpValoreUnitInValuta
			// 
			this.grpValoreUnitInValuta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.grpValoreUnitInValuta.Controls.Add(this.txtImpDeduc);
			this.grpValoreUnitInValuta.Controls.Add(this.label12);
			this.grpValoreUnitInValuta.Controls.Add(this.txtImposta);
			this.grpValoreUnitInValuta.Controls.Add(this.txtTotale);
			this.grpValoreUnitInValuta.Controls.Add(this.txtImponibile);
			this.grpValoreUnitInValuta.Controls.Add(this.label16);
			this.grpValoreUnitInValuta.Controls.Add(this.label17);
			this.grpValoreUnitInValuta.Controls.Add(this.label18);
			this.grpValoreUnitInValuta.Location = new System.Drawing.Point(480, 104);
			this.grpValoreUnitInValuta.Name = "grpValoreUnitInValuta";
			this.grpValoreUnitInValuta.Size = new System.Drawing.Size(208, 176);
			this.grpValoreUnitInValuta.TabIndex = 20;
			this.grpValoreUnitInValuta.TabStop = false;
			this.grpValoreUnitInValuta.Text = "Totali documento";
			// 
			// txtImpDeduc
			// 
			this.txtImpDeduc.Location = new System.Drawing.Point(96, 104);
			this.txtImpDeduc.Name = "txtImpDeduc";
			this.txtImpDeduc.ReadOnly = true;
			this.txtImpDeduc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.txtImpDeduc.Size = new System.Drawing.Size(88, 20);
			this.txtImpDeduc.TabIndex = 4;
			this.txtImpDeduc.Tag = "";
			this.txtImpDeduc.Text = "";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(16, 106);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(72, 16);
			this.label12.TabIndex = 40;
			this.label12.Text = "Indetraibile";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtImposta
			// 
			this.txtImposta.Location = new System.Drawing.Point(96, 56);
			this.txtImposta.Name = "txtImposta";
			this.txtImposta.ReadOnly = true;
			this.txtImposta.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.txtImposta.Size = new System.Drawing.Size(88, 20);
			this.txtImposta.TabIndex = 2;
			this.txtImposta.Tag = "";
			this.txtImposta.Text = "";
			// 
			// txtTotale
			// 
			this.txtTotale.Location = new System.Drawing.Point(96, 80);
			this.txtTotale.Name = "txtTotale";
			this.txtTotale.ReadOnly = true;
			this.txtTotale.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.txtTotale.Size = new System.Drawing.Size(88, 20);
			this.txtTotale.TabIndex = 1;
			this.txtTotale.Tag = "";
			this.txtTotale.Text = "";
			// 
			// txtImponibile
			// 
			this.txtImponibile.Location = new System.Drawing.Point(96, 32);
			this.txtImponibile.Name = "txtImponibile";
			this.txtImponibile.ReadOnly = true;
			this.txtImponibile.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.txtImponibile.Size = new System.Drawing.Size(88, 20);
			this.txtImponibile.TabIndex = 0;
			this.txtImponibile.Tag = "";
			this.txtImponibile.Text = "";
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(16, 56);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(72, 16);
			this.label16.TabIndex = 36;
			this.label16.Text = "IVA";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(16, 80);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(72, 16);
			this.label17.TabIndex = 35;
			this.label17.Text = "Totale";
			this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(16, 34);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(72, 16);
			this.label18.TabIndex = 34;
			this.label18.Text = "Imponibile";
			this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(8, 80);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(64, 16);
			this.label11.TabIndex = 20;
			this.label11.Text = "Documento";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtDataDoc
			// 
			this.txtDataDoc.Location = new System.Drawing.Point(264, 80);
			this.txtDataDoc.Name = "txtDataDoc";
			this.txtDataDoc.Size = new System.Drawing.Size(72, 20);
			this.txtDataDoc.TabIndex = 17;
			this.txtDataDoc.Tag = "invoice.docdate?ivaregisterview.docdate";
			this.txtDataDoc.Text = "";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(200, 80);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(56, 16);
			this.label9.TabIndex = 19;
			this.label9.Text = "Data doc.";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDocumento
			// 
			this.txtDocumento.Location = new System.Drawing.Point(72, 80);
			this.txtDocumento.Name = "txtDocumento";
			this.txtDocumento.Size = new System.Drawing.Size(120, 20);
			this.txtDocumento.TabIndex = 16;
			this.txtDocumento.Tag = "invoice.doc?ivaregisterview.doc";
			this.txtDocumento.Text = "";
			// 
			// groupBox4
			// 
			this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox4.Controls.Add(this.txtCredDeb);
			this.groupBox4.Location = new System.Drawing.Point(352, 16);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(336, 80);
			this.groupBox4.TabIndex = 18;
			this.groupBox4.TabStop = false;
			this.groupBox4.Tag = "AutoChoose.txtCredDeb.lista";
			this.groupBox4.Text = "Versante / Percipiente";
			// 
			// txtCredDeb
			// 
			this.txtCredDeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtCredDeb.Location = new System.Drawing.Point(16, 24);
			this.txtCredDeb.Multiline = true;
			this.txtCredDeb.Name = "txtCredDeb";
			this.txtCredDeb.Size = new System.Drawing.Size(304, 40);
			this.txtCredDeb.TabIndex = 11;
			this.txtCredDeb.Tag = "registry.title?ivaregisterview.registry";
			this.txtCredDeb.Text = "";
			// 
			// dataGrid1
			// 
			this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.dataGrid1.CaptionVisible = false;
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(16, 112);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(456, 168);
			this.dataGrid1.TabIndex = 19;
			this.dataGrid1.Tag = "invoicedetail.documento.documento";
			// 
			// txtNumDoc
			// 
			this.txtNumDoc.Location = new System.Drawing.Point(264, 56);
			this.txtNumDoc.Name = "txtNumDoc";
			this.txtNumDoc.Size = new System.Drawing.Size(72, 20);
			this.txtNumDoc.TabIndex = 10;
			this.txtNumDoc.Tag = "ivaregister.ninv";
			this.txtNumDoc.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(192, 56);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 16);
			this.label4.TabIndex = 12;
			this.label4.Text = "Numero";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtEsercDoc
			// 
			this.txtEsercDoc.Location = new System.Drawing.Point(72, 56);
			this.txtEsercDoc.Name = "txtEsercDoc";
			this.txtEsercDoc.Size = new System.Drawing.Size(48, 20);
			this.txtEsercDoc.TabIndex = 9;
			this.txtEsercDoc.Tag = "ivaregister.yinv.year";
			this.txtEsercDoc.Text = "";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(8, 56);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(56, 16);
			this.label7.TabIndex = 11;
			this.label7.Text = "Esercizio";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(8, 26);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(48, 16);
			this.label8.TabIndex = 13;
			this.label8.Text = "Tipo:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cmbTipoDoc
			// 
			this.cmbTipoDoc.DataSource = this.DS.invoicekind;
			this.cmbTipoDoc.DisplayMember = "description";
			this.cmbTipoDoc.Location = new System.Drawing.Point(72, 26);
			this.cmbTipoDoc.Name = "cmbTipoDoc";
			this.cmbTipoDoc.Size = new System.Drawing.Size(264, 21);
			this.cmbTipoDoc.TabIndex = 8;
			this.cmbTipoDoc.Tag = "ivaregister.idinvkind";
			this.cmbTipoDoc.ValueMember = "idinvkind";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(0, 0);
			this.label10.Name = "label10";
			this.label10.TabIndex = 0;
			// 
			// Frm_ivaregister_default
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(720, 422);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox1);
			this.Name = "Frm_ivaregister_default";
			this.Text = "frmregistroiva";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.grpValoreUnitInValuta.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public void MetaData_AfterLink() {
			Meta=MetaData.GetMetaData(this);
		}

		public void MetaData_AfterClear() {
			DisabilitaCampi(false);
			CalcolaTotali();
		}

		public void MetaData_AfterFill() {
			DisabilitaCampi(true);
			CalcolaTotali();
		}

		private void DisabilitaCampi(bool disable) {
			txtNumProt.ReadOnly=disable;
			cmbTipoDoc.Enabled=!disable;
			txtEsercDoc.ReadOnly=disable;
			txtNumDoc.ReadOnly=disable;
			txtDocumento.ReadOnly=disable;
			txtDataDoc.ReadOnly=disable;
			txtCredDeb.ReadOnly=disable;
		}

        private decimal RoundDecimal6(decimal valuta) {
            decimal truncated = Decimal.Truncate(valuta * 10000000);
            if (truncated > 0)
            {
                if ((truncated % 10) >= 5) truncated += 5;
            }
            else
            {
                if (((-truncated) % 10) >= 5) truncated -= 5;
            }
            truncated = truncated / 10;
            truncated = Decimal.Truncate(truncated);
            return truncated / 1000000;
        }

		private void CalcolaTotali(){
            if ((DS.invoice.Rows.Count) == 0) return;
            DataRow Curr = DS.invoice.Rows[0];
            decimal tassocambio = RoundDecimal6(CfgFn.GetNoNullDecimal(Curr["exchangerate"]));

            decimal imponibile = 0;
            decimal imponibileEur = 0;
            decimal imposta = 0;
            decimal indetraibile = 0;
            decimal totale = 0;
            foreach (DataRow R in DS.invoicedetail.Rows)
            {
                if (R.RowState == DataRowState.Deleted) continue;
                decimal R_imponibile = CfgFn.GetNoNullDecimal(R["taxable"]);
                decimal R_quantita = CfgFn.GetNoNullDecimal(R["npackage"]);
                decimal R_sconto = RoundDecimal6(CfgFn.GetNoNullDecimal(R["discount"]));
                imponibile += CfgFn.RoundValuta((R_imponibile * R_quantita * (1 - R_sconto)) * tassocambio);
                imposta += CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(R["tax"]));
                indetraibile += CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(R["unabatable"]));
            }
            imponibileEur = CfgFn.RoundValuta(imponibile);
            totale = imponibileEur + imposta;
            txtImponibile.Text = imponibileEur.ToString("c");
			txtImposta.Text=imposta.ToString("c");
			txtTotale.Text=totale.ToString("c");
			txtImpDeduc.Text=indetraibile.ToString("c");
		}

	}
}
