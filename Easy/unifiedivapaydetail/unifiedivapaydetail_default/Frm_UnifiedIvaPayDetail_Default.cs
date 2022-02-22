
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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using System.Data;
using funzioni_configurazione;

namespace unifiedivapaydetail_default {
	/// <summary>
	/// Summary description for Frm_UnifiedIvaPayDetail_Default.
	/// </summary>
	public class Frm_UnifiedIvaPayDetail_Default : MetaDataForm {
		MetaData Meta;
		bool inChiusura = false;
		decimal lastPromiscuo;
		decimal lastProRata;
		decimal lastIvaLorda;
		decimal lastIvaLordaDiff;
		decimal lastIvaIndetraibile;
		decimal lastIvaIndetraibileDiff;
		public unifiedivapaydetail_default.vistaForm DS;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.TextBox txtIvaLorda;
		private System.Windows.Forms.TextBox txtIvaIndetraibile;
		private System.Windows.Forms.TextBox txtProRata;
		private System.Windows.Forms.TextBox txtPromiscuo;
		private System.Windows.Forms.TextBox txtIvaNetta;
		private System.Windows.Forms.TextBox txtIvaNettaDiff;
		private System.Windows.Forms.TextBox txtIvaIndetraibileDiff;
		private System.Windows.Forms.TextBox txtIvaLordaDiff;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_UnifiedIvaPayDetail_Default() {
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			inChiusura = true;
			if( disposing ) {
				if(components != null) {
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		public void MetaData_AfterActivation() {
			assegnaVarDiConfronto();
		}

		public void assegnaVarDiConfronto() {
			if (DS.unifiedivapaydetail.Rows.Count == 0) return;
			DataRow Curr = DS.unifiedivapaydetail.Rows[0];
			lastIvaLorda = CfgFn.GetNoNullDecimal(Curr["iva"]);
			lastIvaLordaDiff = CfgFn.GetNoNullDecimal(Curr["ivadeferred"]);
			lastIvaIndetraibile = CfgFn.GetNoNullDecimal(Curr["unabatable"]);
			lastIvaIndetraibileDiff = CfgFn.GetNoNullDecimal(Curr["unabatabledeferred"]);
			lastProRata = CfgFn.GetNoNullDecimal(Curr["prorata"]);
			lastPromiscuo = (Curr["mixed"] == DBNull.Value) ? 1 : (decimal) Curr["mixed"];
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.DS = new unifiedivapaydetail_default.vistaForm();
			this.button1 = new System.Windows.Forms.Button();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtIvaLorda = new System.Windows.Forms.TextBox();
			this.txtIvaIndetraibile = new System.Windows.Forms.TextBox();
			this.txtProRata = new System.Windows.Forms.TextBox();
			this.txtPromiscuo = new System.Windows.Forms.TextBox();
			this.txtIvaNetta = new System.Windows.Forms.TextBox();
			this.txtIvaNettaDiff = new System.Windows.Forms.TextBox();
			this.txtIvaIndetraibileDiff = new System.Windows.Forms.TextBox();
			this.txtIvaLordaDiff = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.btnOk = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(8, 16);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(136, 23);
			this.button1.TabIndex = 0;
			this.button1.TabStop = false;
			this.button1.Tag = "manage.ivaregisterkind.default";
			this.button1.Text = "Registro IVA";
			// 
			// comboBox1
			// 
			this.comboBox1.DataSource = this.DS.ivaregisterkind;
			this.comboBox1.DisplayMember = "description";
			this.comboBox1.Location = new System.Drawing.Point(152, 16);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(320, 21);
			this.comboBox1.TabIndex = 1;
			this.comboBox1.Tag = "unifiedivapaydetail.idivaregisterkindunified";
			this.comboBox1.ValueMember = "idivaregisterkindunified";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtIvaNetta);
			this.groupBox1.Controls.Add(this.txtIvaIndetraibile);
			this.groupBox1.Controls.Add(this.txtIvaLorda);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(8, 112);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(528, 88);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Gestione IVA Immediata";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.txtIvaNettaDiff);
			this.groupBox2.Controls.Add(this.txtIvaIndetraibileDiff);
			this.groupBox2.Controls.Add(this.txtIvaLordaDiff);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Location = new System.Drawing.Point(8, 208);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(528, 80);
			this.groupBox2.TabIndex = 5;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Gestione IVA Differita";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 24);
			this.label1.Name = "label1";
			this.label1.TabIndex = 0;
			this.label1.Text = "IVA Lorda:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 64);
			this.label2.Name = "label2";
			this.label2.TabIndex = 1;
			this.label2.Text = "% di Pro Rata:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(304, 64);
			this.label3.Name = "label3";
			this.label3.TabIndex = 2;
			this.label3.Text = "% di Promiscuo:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 56);
			this.label4.Name = "label4";
			this.label4.TabIndex = 3;
			this.label4.Text = "IVA Netta:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(304, 24);
			this.label5.Name = "label5";
			this.label5.TabIndex = 4;
			this.label5.Text = "IVA Indetraibile:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtIvaLorda
			// 
			this.txtIvaLorda.Location = new System.Drawing.Point(120, 24);
			this.txtIvaLorda.Name = "txtIvaLorda";
			this.txtIvaLorda.TabIndex = 1;
			this.txtIvaLorda.Tag = "unifiedivapaydetail.iva";
			this.txtIvaLorda.Text = "";
			this.txtIvaLorda.Leave += new System.EventHandler(this.txtIvaLorda_Leave);
			// 
			// txtIvaIndetraibile
			// 
			this.txtIvaIndetraibile.Location = new System.Drawing.Point(416, 24);
			this.txtIvaIndetraibile.Name = "txtIvaIndetraibile";
			this.txtIvaIndetraibile.TabIndex = 2;
			this.txtIvaIndetraibile.Tag = "unifiedivapaydetail.unabatable";
			this.txtIvaIndetraibile.Text = "";
			this.txtIvaIndetraibile.Leave += new System.EventHandler(this.txtIvaIndetraibile_Leave);
			// 
			// txtProRata
			// 
			this.txtProRata.Location = new System.Drawing.Point(128, 64);
			this.txtProRata.Name = "txtProRata";
			this.txtProRata.TabIndex = 2;
			this.txtProRata.Tag = "unifiedivapaydetail.prorata.fixed.4..%.100";
			this.txtProRata.Text = "";
			this.txtProRata.Leave += new System.EventHandler(this.txtProRata_Leave);
			// 
			// txtPromiscuo
			// 
			this.txtPromiscuo.Location = new System.Drawing.Point(424, 64);
			this.txtPromiscuo.Name = "txtPromiscuo";
			this.txtPromiscuo.TabIndex = 3;
			this.txtPromiscuo.Tag = "unifiedivapaydetail.mixed.fixed.4..%.100";
			this.txtPromiscuo.Text = "";
			this.txtPromiscuo.Leave += new System.EventHandler(this.txtPromiscuo_Leave);
			// 
			// txtIvaNetta
			// 
			this.txtIvaNetta.Location = new System.Drawing.Point(120, 56);
			this.txtIvaNetta.Name = "txtIvaNetta";
			this.txtIvaNetta.TabIndex = 3;
			this.txtIvaNetta.Tag = "unifiedivapaydetail.ivanet";
			this.txtIvaNetta.Text = "";
			// 
			// txtIvaNettaDiff
			// 
			this.txtIvaNettaDiff.Location = new System.Drawing.Point(120, 48);
			this.txtIvaNettaDiff.Name = "txtIvaNettaDiff";
			this.txtIvaNettaDiff.TabIndex = 3;
			this.txtIvaNettaDiff.Tag = "unifiedivapaydetail.ivanetdeferred";
			this.txtIvaNettaDiff.Text = "";
			// 
			// txtIvaIndetraibileDiff
			// 
			this.txtIvaIndetraibileDiff.Location = new System.Drawing.Point(416, 17);
			this.txtIvaIndetraibileDiff.Name = "txtIvaIndetraibileDiff";
			this.txtIvaIndetraibileDiff.TabIndex = 2;
			this.txtIvaIndetraibileDiff.Tag = "unifiedivapaydetail.unabatabledeferred";
			this.txtIvaIndetraibileDiff.Text = "";
			this.txtIvaIndetraibileDiff.Leave += new System.EventHandler(this.txtIvaIndetraibileDiff_Leave);
			// 
			// txtIvaLordaDiff
			// 
			this.txtIvaLordaDiff.Location = new System.Drawing.Point(120, 17);
			this.txtIvaLordaDiff.Name = "txtIvaLordaDiff";
			this.txtIvaLordaDiff.TabIndex = 1;
			this.txtIvaLordaDiff.Tag = "unifiedivapaydetail.ivadeferred";
			this.txtIvaLordaDiff.Text = "";
			this.txtIvaLordaDiff.Leave += new System.EventHandler(this.txtIvaLordaDiff_Leave);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(304, 17);
			this.label6.Name = "label6";
			this.label6.TabIndex = 14;
			this.label6.Text = "IVA Indetraibile:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(8, 48);
			this.label7.Name = "label7";
			this.label7.TabIndex = 13;
			this.label7.Text = "IVA Netta:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(8, 17);
			this.label10.Name = "label10";
			this.label10.TabIndex = 10;
			this.label10.Text = "IVA Lorda:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnOk
			// 
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(160, 296);
			this.btnOk.Name = "btnOk";
			this.btnOk.TabIndex = 6;
			this.btnOk.TabStop = false;
			this.btnOk.Tag = "mainsave";
			this.btnOk.Text = "OK";
			// 
			// button3
			// 
			this.button3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button3.Location = new System.Drawing.Point(304, 296);
			this.button3.Name = "button3";
			this.button3.TabIndex = 7;
			this.button3.TabStop = false;
			this.button3.Text = "Annulla";
			// 
			// Frm_UnifiedIvaPayDetail_Default
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(544, 334);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.txtProRata);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtPromiscuo);
			this.Name = "Frm_UnifiedIvaPayDetail_Default";
			this.Text = "Frm_UnifiedIvaPayDetail_Default";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
			string filterRegister = "(idivaregisterkindunified IS NOT NULL AND idivaregisterkindunified <> '')";
			GetData.SetStaticFilter(DS.ivaregisterkind, filterRegister);
		}

		private void txtProRata_Leave(object sender, System.EventArgs e) {
			if (inChiusura) return;
			decimal proRata = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(decimal),
				txtProRata.Text, txtProRata.Tag.ToString()));
			if (proRata == lastProRata) return;
			calcolaIvaNetta(false);
			calcolaIvaNetta(true);
			lastProRata = proRata;
		}

		private void txtPromiscuo_Leave(object sender, System.EventArgs e) {
			if (inChiusura) return;
			object promiscuoObj = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(decimal),
				txtPromiscuo.Text, txtPromiscuo.Tag.ToString()));
			decimal promiscuo = ((promiscuoObj == null)||(promiscuoObj == DBNull.Value)) ? 1: (decimal) promiscuoObj;
			if (promiscuo == lastPromiscuo) return;
			calcolaIvaNetta(false);
			calcolaIvaNetta(true);
			lastPromiscuo = promiscuo;
		}

		private void txtIvaLorda_Leave(object sender, System.EventArgs e) {
			if (inChiusura) return;
			decimal ivaLorda = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(decimal),
				txtIvaLorda.Text, txtIvaLorda.Tag.ToString()));
			if (ivaLorda == lastIvaLorda) return;
			calcolaIvaNetta(false);
			lastIvaLorda = ivaLorda;
		}

		private void txtIvaIndetraibile_Leave(object sender, System.EventArgs e) {
			if (inChiusura) return;
			decimal ivaIndetraibile = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(decimal),
				txtIvaIndetraibile.Text, txtIvaIndetraibile.Tag.ToString()));
			if (ivaIndetraibile == lastIvaIndetraibile) return;
			calcolaIvaNetta(false);
			lastIvaIndetraibile = ivaIndetraibile;
		}

		private void txtIvaLordaDiff_Leave(object sender, System.EventArgs e) {
			if (inChiusura) return;
			decimal ivaLordaDiff = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(decimal),
				txtIvaLordaDiff.Text, txtIvaLordaDiff.Tag.ToString()));
			if (ivaLordaDiff == lastIvaLordaDiff) return;
			calcolaIvaNetta(true);
			lastIvaLordaDiff = ivaLordaDiff;
		}

		private void txtIvaIndetraibileDiff_Leave(object sender, System.EventArgs e) {
			if (inChiusura) return;
			decimal ivaIndetraibileDiff = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(decimal),
				txtIvaIndetraibileDiff.Text, txtIvaIndetraibileDiff.Tag.ToString()));
			if (ivaIndetraibileDiff == lastIvaIndetraibileDiff) return;
			calcolaIvaNetta(true);
			lastIvaIndetraibileDiff = ivaIndetraibileDiff;
		}

		/// <summary>
		/// Metodo che calcola l'IVA netta
		/// </summary>
		/// <param name="isDifferita">TRUE: Se ci si riferisce all'IVA Differita; FALSE Se ci si riferisce all'IVA immediata</param>
		private void calcolaIvaNetta(bool isDifferita) {
			decimal ivaLorda = 0;
			decimal ivaIndetraibile = 0;
			decimal proRata = 0;
			decimal promiscuo = 0;
			object promiscuoObj = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(decimal),
				txtPromiscuo.Text, txtPromiscuo.Tag.ToString()));
			promiscuo = ((promiscuoObj == null)||(promiscuoObj == DBNull.Value)) ? 1: CfgFn.GetNoNullDecimal(promiscuoObj);

			proRata = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(decimal),
				txtProRata.Text, txtProRata.Tag.ToString()));

			if (isDifferita) {
				ivaLorda = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(decimal),
					txtIvaLordaDiff.Text, txtIvaLordaDiff.Tag.ToString()));
				ivaIndetraibile = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(decimal),
					txtIvaIndetraibileDiff.Text, txtIvaIndetraibileDiff.Tag.ToString()));
			}
			else {
				ivaLorda = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(decimal),
					txtIvaLorda.Text, txtIvaLorda.Tag.ToString()));
				ivaIndetraibile = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(decimal),
					txtIvaIndetraibile.Text, txtIvaIndetraibile.Tag.ToString()));
			}

			decimal ivaNetta = CfgFn.RoundValuta((ivaLorda - ivaIndetraibile) * proRata * promiscuo);
			if (isDifferita) {
				txtIvaNettaDiff.Text = ivaNetta.ToString("c");
			}
			else {
				txtIvaNetta.Text = ivaNetta.ToString("c");
			}
		}
	}
}
