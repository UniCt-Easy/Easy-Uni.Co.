/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
using metadatalibrary;

namespace entrysetup_default {
	/// <summary>
	/// Summary description for Frm_entrysetup_default.
	/// </summary>
	public class Frm_entrysetup_default : System.Windows.Forms.Form {
		public entrysetup_default.vistaForm DS;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		MetaData Meta;
		bool CanGoEdit;
		bool CanGoInsert;
		private System.Windows.Forms.GroupBox gboxConto;
		private System.Windows.Forms.TextBox txtDenominazioneConto;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.TextBox textBox9;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.TextBox txtCodiceContoCustomer;
		private System.Windows.Forms.TextBox txtCodiceContoSupplier;
		private System.Windows.Forms.TextBox txtCodiceContoIvaDaVersare;
		private System.Windows.Forms.TextBox txtCodiceContoIvaDaRimborsare;
		private System.Windows.Forms.Button btnAnnulla;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox checkBox1;
        private GroupBox groupBox4;
        private TextBox textBox2;
        private TextBox txtCodiceContoRateiAttivi;
        private Button button3;
        private GroupBox groupBox6;
        private TextBox textBox4;
        private TextBox txtCodiceContoRateiPassivi;
        private Button button5;
        private GroupBox groupBox7;
        private TextBox textBox7;
        private TextBox txtCodiceContoRiscontiAttivi;
        private Button button7;
        private GroupBox groupBox8;
        private TextBox textBox10;
        private TextBox txtCodiceContoRiscontiPassivi;
        private Button button8;
        private GroupBox groupBox9;
        private TabControl tabControl1;
        private TabPage tabAnagrafica;
        private TabPage tabIva;
        private TabPage tabRR;
        private TabPage tabAP;
        private GroupBox groupBox12;
        private TextBox textBox8;
        private TextBox txtCodiceContoPL;
        private Button button10;
        private GroupBox groupBox11;
        private TextBox textBox3;
        private TextBox txtCodiceContoPat;
        private Button button9;
		private System.ComponentModel.Container components = null;

		public Frm_entrysetup_default() {
			InitializeComponent();
			DataAccess.SetTableForReading(DS.account_customer,"account");
			DataAccess.SetTableForReading(DS.account_supplier,"account");
			DataAccess.SetTableForReading(DS.account_ivapayment,"account");
			DataAccess.SetTableForReading(DS.account_ivarefund,"account");
            DataAccess.SetTableForReading(DS.account_accruedcost, "account");
            DataAccess.SetTableForReading(DS.account_accruedrevenue, "account");
            DataAccess.SetTableForReading(DS.account_deferredcost, "account");
            DataAccess.SetTableForReading(DS.account_deferredrevenue, "account");
            DataAccess.SetTableForReading(DS.account_pl, "account");
            DataAccess.SetTableForReading(DS.account_pat, "account");
			HelpForm.SetDenyNull(DS.entrysetup.Columns["flagepexp"], true);
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

		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
			string filteresercizio= "(ayear = '" + Meta.GetSys("esercizio") + "')";
			int numRigheEntrySetup = Meta.Conn.RUN_SELECT_COUNT("entrysetup",filteresercizio,
				true);
			if (numRigheEntrySetup == 1) {
				CanGoInsert=false;
				CanGoEdit=true;
			}
			else {
				CanGoInsert=true;
				CanGoEdit=false;
			}
			GetData.SetStaticFilter(DS.entrysetup, filteresercizio);
			GetData.SetStaticFilter(DS.account_customer, filteresercizio);
			GetData.SetStaticFilter(DS.account_supplier, filteresercizio);
			GetData.SetStaticFilter(DS.account_ivapayment, filteresercizio);
			GetData.SetStaticFilter(DS.account_ivarefund, filteresercizio);
            GetData.SetStaticFilter(DS.account_accruedcost, filteresercizio);
            GetData.SetStaticFilter(DS.account_accruedrevenue, filteresercizio);
            GetData.SetStaticFilter(DS.account_deferredcost, filteresercizio);
            GetData.SetStaticFilter(DS.account_deferredrevenue, filteresercizio);
            GetData.SetStaticFilter(DS.account_pl, filteresercizio);
            GetData.SetStaticFilter(DS.account_pat, filteresercizio);
		}

		public void MetaData_AfterClear() {
			if (CanGoInsert) {
				CanGoInsert=false;
				MetaData.DoMainCommand(this, "maininsert");
			}
			if (CanGoEdit) {
				CanGoEdit=false;
				MetaData.DoMainCommand(this, "maindosearch.entrysetup");
			}
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.DS = new entrysetup_default.vistaForm();
            this.gboxConto = new System.Windows.Forms.GroupBox();
            this.txtDenominazioneConto = new System.Windows.Forms.TextBox();
            this.txtCodiceContoCustomer = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtCodiceContoSupplier = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.txtCodiceContoIvaDaVersare = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.txtCodiceContoIvaDaRimborsare = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtCodiceContoRateiAttivi = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.txtCodiceContoRateiPassivi = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.txtCodiceContoRiscontiAttivi = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.txtCodiceContoRiscontiPassivi = new System.Windows.Forms.TextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabAnagrafica = new System.Windows.Forms.TabPage();
            this.tabIva = new System.Windows.Forms.TabPage();
            this.tabRR = new System.Windows.Forms.TabPage();
            this.tabAP = new System.Windows.Forms.TabPage();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.txtCodiceContoPat = new System.Windows.Forms.TextBox();
            this.button9 = new System.Windows.Forms.Button();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.txtCodiceContoPL = new System.Windows.Forms.TextBox();
            this.button10 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.gboxConto.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabAnagrafica.SuspendLayout();
            this.tabIva.SuspendLayout();
            this.tabRR.SuspendLayout();
            this.tabAP.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // gboxConto
            // 
            this.gboxConto.Controls.Add(this.txtDenominazioneConto);
            this.gboxConto.Controls.Add(this.txtCodiceContoCustomer);
            this.gboxConto.Controls.Add(this.button1);
            this.gboxConto.Location = new System.Drawing.Point(6, 6);
            this.gboxConto.Name = "gboxConto";
            this.gboxConto.Size = new System.Drawing.Size(320, 72);
            this.gboxConto.TabIndex = 1;
            this.gboxConto.TabStop = false;
            this.gboxConto.Tag = "AutoManage.txtCodiceContoCustomer.tree";
            this.gboxConto.Text = "Crediti v/Clienti";
            // 
            // txtDenominazioneConto
            // 
            this.txtDenominazioneConto.Location = new System.Drawing.Point(136, 16);
            this.txtDenominazioneConto.Multiline = true;
            this.txtDenominazioneConto.Name = "txtDenominazioneConto";
            this.txtDenominazioneConto.ReadOnly = true;
            this.txtDenominazioneConto.Size = new System.Drawing.Size(179, 52);
            this.txtDenominazioneConto.TabIndex = 2;
            this.txtDenominazioneConto.TabStop = false;
            this.txtDenominazioneConto.Tag = "account_customer.title";
            // 
            // txtCodiceContoCustomer
            // 
            this.txtCodiceContoCustomer.Location = new System.Drawing.Point(8, 48);
            this.txtCodiceContoCustomer.Name = "txtCodiceContoCustomer";
            this.txtCodiceContoCustomer.Size = new System.Drawing.Size(120, 20);
            this.txtCodiceContoCustomer.TabIndex = 1;
            this.txtCodiceContoCustomer.Tag = "account_customer.codeacc?x";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 23);
            this.button1.TabIndex = 0;
            this.button1.TabStop = false;
            this.button1.Tag = "manage.account_customer.tree";
            this.button1.Text = "Conto";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.txtCodiceContoSupplier);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Location = new System.Drawing.Point(332, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(319, 72);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "AutoManage.txtCodiceContoSupplier.tree";
            this.groupBox1.Text = "Debiti v/Fornitori";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(136, 16);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(176, 52);
            this.textBox1.TabIndex = 2;
            this.textBox1.TabStop = false;
            this.textBox1.Tag = "account_supplier.title";
            // 
            // txtCodiceContoSupplier
            // 
            this.txtCodiceContoSupplier.Location = new System.Drawing.Point(8, 48);
            this.txtCodiceContoSupplier.Name = "txtCodiceContoSupplier";
            this.txtCodiceContoSupplier.Size = new System.Drawing.Size(120, 20);
            this.txtCodiceContoSupplier.TabIndex = 1;
            this.txtCodiceContoSupplier.Tag = "account_supplier.codeacc?x";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(8, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 23);
            this.button2.TabIndex = 0;
            this.button2.TabStop = false;
            this.button2.Tag = "manage.account_supplier.tree";
            this.button2.Text = "Conto";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox5);
            this.groupBox3.Controls.Add(this.txtCodiceContoIvaDaVersare);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Location = new System.Drawing.Point(312, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(296, 72);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Tag = "AutoManage.txtCodiceContoIvaDaVersare.tree";
            this.groupBox3.Text = "Versamento IVA";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(136, 16);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(152, 52);
            this.textBox5.TabIndex = 2;
            this.textBox5.TabStop = false;
            this.textBox5.Tag = "account_ivapayment.title";
            // 
            // txtCodiceContoIvaDaVersare
            // 
            this.txtCodiceContoIvaDaVersare.Location = new System.Drawing.Point(8, 48);
            this.txtCodiceContoIvaDaVersare.Name = "txtCodiceContoIvaDaVersare";
            this.txtCodiceContoIvaDaVersare.Size = new System.Drawing.Size(120, 20);
            this.txtCodiceContoIvaDaVersare.TabIndex = 1;
            this.txtCodiceContoIvaDaVersare.Tag = "account_ivapayment.codeacc?x";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(8, 16);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(120, 23);
            this.button4.TabIndex = 0;
            this.button4.TabStop = false;
            this.button4.Tag = "manage.account_ivapayment.tree";
            this.button4.Text = "Conto";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBox9);
            this.groupBox5.Controls.Add(this.txtCodiceContoIvaDaRimborsare);
            this.groupBox5.Controls.Add(this.button6);
            this.groupBox5.Location = new System.Drawing.Point(8, 16);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(296, 72);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Tag = "AutoManage.txtCodiceContoIvaDaRimborsare.tree";
            this.groupBox5.Text = "Rimborso IVA";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(136, 16);
            this.textBox9.Multiline = true;
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(152, 52);
            this.textBox9.TabIndex = 2;
            this.textBox9.TabStop = false;
            this.textBox9.Tag = "account_ivarefund.title";
            // 
            // txtCodiceContoIvaDaRimborsare
            // 
            this.txtCodiceContoIvaDaRimborsare.Location = new System.Drawing.Point(8, 48);
            this.txtCodiceContoIvaDaRimborsare.Name = "txtCodiceContoIvaDaRimborsare";
            this.txtCodiceContoIvaDaRimborsare.Size = new System.Drawing.Size(120, 20);
            this.txtCodiceContoIvaDaRimborsare.TabIndex = 1;
            this.txtCodiceContoIvaDaRimborsare.Tag = "account_ivarefund.codeacc?x";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(8, 16);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(120, 23);
            this.button6.TabIndex = 0;
            this.button6.TabStop = false;
            this.button6.Tag = "manage.account_ivarefund.tree";
            this.button6.Text = "Conto";
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(544, 217);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 32;
            this.btnAnnulla.Text = "Annulla";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(440, 217);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 31;
            this.btnOK.Tag = "mainsave";
            this.btnOK.Text = "OK";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(616, 96);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Configurazione Liquidazione periodica IVA";
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox1.Location = new System.Drawing.Point(8, 217);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(280, 24);
            this.checkBox1.TabIndex = 33;
            this.checkBox1.Tag = "entrysetup.flagepexp:S:N";
            this.checkBox1.Text = "Genera gli impegni di budget";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBox2);
            this.groupBox4.Controls.Add(this.txtCodiceContoRateiAttivi);
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Location = new System.Drawing.Point(7, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(296, 72);
            this.groupBox4.TabIndex = 34;
            this.groupBox4.TabStop = false;
            this.groupBox4.Tag = "AutoManage.txtCodiceContoRateiAttivi.tree";
            this.groupBox4.Text = "Ratei Attivi";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(136, 16);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(152, 52);
            this.textBox2.TabIndex = 2;
            this.textBox2.TabStop = false;
            this.textBox2.Tag = "account_accruedrevenue.title";
            // 
            // txtCodiceContoRateiAttivi
            // 
            this.txtCodiceContoRateiAttivi.Location = new System.Drawing.Point(8, 48);
            this.txtCodiceContoRateiAttivi.Name = "txtCodiceContoRateiAttivi";
            this.txtCodiceContoRateiAttivi.Size = new System.Drawing.Size(120, 20);
            this.txtCodiceContoRateiAttivi.TabIndex = 1;
            this.txtCodiceContoRateiAttivi.Tag = "account_accruedrevenue.codeacc?x";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(8, 16);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(120, 23);
            this.button3.TabIndex = 0;
            this.button3.TabStop = false;
            this.button3.Tag = "manage.account_accruedrevenue.tree";
            this.button3.Text = "Conto";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.textBox4);
            this.groupBox6.Controls.Add(this.txtCodiceContoRateiPassivi);
            this.groupBox6.Controls.Add(this.button5);
            this.groupBox6.Location = new System.Drawing.Point(311, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(296, 72);
            this.groupBox6.TabIndex = 35;
            this.groupBox6.TabStop = false;
            this.groupBox6.Tag = "AutoManage.txtCodiceContoRateiPassivi.tree";
            this.groupBox6.Text = "Ratei Passivi";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(136, 16);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(152, 52);
            this.textBox4.TabIndex = 2;
            this.textBox4.TabStop = false;
            this.textBox4.Tag = "account_accruedcost.title";
            // 
            // txtCodiceContoRateiPassivi
            // 
            this.txtCodiceContoRateiPassivi.Location = new System.Drawing.Point(8, 48);
            this.txtCodiceContoRateiPassivi.Name = "txtCodiceContoRateiPassivi";
            this.txtCodiceContoRateiPassivi.Size = new System.Drawing.Size(120, 20);
            this.txtCodiceContoRateiPassivi.TabIndex = 1;
            this.txtCodiceContoRateiPassivi.Tag = "account_accruedcost.codeacc?x";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(8, 16);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(120, 23);
            this.button5.TabIndex = 0;
            this.button5.TabStop = false;
            this.button5.Tag = "manage.account_accruedcost.tree";
            this.button5.Text = "Conto";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.textBox7);
            this.groupBox7.Controls.Add(this.txtCodiceContoRiscontiAttivi);
            this.groupBox7.Controls.Add(this.button7);
            this.groupBox7.Location = new System.Drawing.Point(8, 85);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(296, 72);
            this.groupBox7.TabIndex = 36;
            this.groupBox7.TabStop = false;
            this.groupBox7.Tag = "AutoManage.txtCodiceRiscontiAttivi.tree";
            this.groupBox7.Text = "Risconti Attivi";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(136, 16);
            this.textBox7.Multiline = true;
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(152, 52);
            this.textBox7.TabIndex = 2;
            this.textBox7.TabStop = false;
            this.textBox7.Tag = "account_deferredcost.title";
            // 
            // txtCodiceContoRiscontiAttivi
            // 
            this.txtCodiceContoRiscontiAttivi.Location = new System.Drawing.Point(8, 48);
            this.txtCodiceContoRiscontiAttivi.Name = "txtCodiceContoRiscontiAttivi";
            this.txtCodiceContoRiscontiAttivi.Size = new System.Drawing.Size(120, 20);
            this.txtCodiceContoRiscontiAttivi.TabIndex = 1;
            this.txtCodiceContoRiscontiAttivi.Tag = "account_deferredcost.codeacc?x";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(8, 16);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(120, 23);
            this.button7.TabIndex = 0;
            this.button7.TabStop = false;
            this.button7.Tag = "manage.account_deferredcost.tree";
            this.button7.Text = "Conto";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.textBox10);
            this.groupBox8.Controls.Add(this.txtCodiceContoRiscontiPassivi);
            this.groupBox8.Controls.Add(this.button8);
            this.groupBox8.Location = new System.Drawing.Point(312, 85);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(296, 72);
            this.groupBox8.TabIndex = 37;
            this.groupBox8.TabStop = false;
            this.groupBox8.Tag = "AutoManage.txtCodiceContoRiscontiPassivi.tree";
            this.groupBox8.Text = "Risconti Passivi";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(136, 16);
            this.textBox10.Multiline = true;
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            this.textBox10.Size = new System.Drawing.Size(152, 52);
            this.textBox10.TabIndex = 2;
            this.textBox10.TabStop = false;
            this.textBox10.Tag = "account_deferredrevenue.title";
            // 
            // txtCodiceContoRiscontiPassivi
            // 
            this.txtCodiceContoRiscontiPassivi.Location = new System.Drawing.Point(8, 48);
            this.txtCodiceContoRiscontiPassivi.Name = "txtCodiceContoRiscontiPassivi";
            this.txtCodiceContoRiscontiPassivi.Size = new System.Drawing.Size(120, 20);
            this.txtCodiceContoRiscontiPassivi.TabIndex = 1;
            this.txtCodiceContoRiscontiPassivi.Tag = "account_deferredrevenue.codeacc?x";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(8, 16);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(120, 23);
            this.button8.TabIndex = 0;
            this.button8.TabStop = false;
            this.button8.Tag = "manage.account_deferredrevenue.tree";
            this.button8.Text = "Conto";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.groupBox7);
            this.groupBox9.Controls.Add(this.groupBox8);
            this.groupBox9.Controls.Add(this.groupBox6);
            this.groupBox9.Controls.Add(this.groupBox4);
            this.groupBox9.Location = new System.Drawing.Point(3, 3);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(616, 163);
            this.groupBox9.TabIndex = 38;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Ratei e Risconti";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabAnagrafica);
            this.tabControl1.Controls.Add(this.tabIva);
            this.tabControl1.Controls.Add(this.tabRR);
            this.tabControl1.Controls.Add(this.tabAP);
            this.tabControl1.Location = new System.Drawing.Point(8, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(668, 199);
            this.tabControl1.TabIndex = 39;
            // 
            // tabAnagrafica
            // 
            this.tabAnagrafica.Controls.Add(this.gboxConto);
            this.tabAnagrafica.Controls.Add(this.groupBox1);
            this.tabAnagrafica.Location = new System.Drawing.Point(4, 22);
            this.tabAnagrafica.Name = "tabAnagrafica";
            this.tabAnagrafica.Padding = new System.Windows.Forms.Padding(3);
            this.tabAnagrafica.Size = new System.Drawing.Size(660, 173);
            this.tabAnagrafica.TabIndex = 0;
            this.tabAnagrafica.Text = "Anagrafica";
            this.tabAnagrafica.UseVisualStyleBackColor = true;
            // 
            // tabIva
            // 
            this.tabIva.Controls.Add(this.groupBox2);
            this.tabIva.Location = new System.Drawing.Point(4, 22);
            this.tabIva.Name = "tabIva";
            this.tabIva.Padding = new System.Windows.Forms.Padding(3);
            this.tabIva.Size = new System.Drawing.Size(660, 173);
            this.tabIva.TabIndex = 1;
            this.tabIva.Text = "Liquidazione IVA";
            this.tabIva.UseVisualStyleBackColor = true;
            // 
            // tabRR
            // 
            this.tabRR.Controls.Add(this.groupBox9);
            this.tabRR.Location = new System.Drawing.Point(4, 22);
            this.tabRR.Name = "tabRR";
            this.tabRR.Size = new System.Drawing.Size(660, 173);
            this.tabRR.TabIndex = 2;
            this.tabRR.Text = "Ratei - Risconti";
            this.tabRR.UseVisualStyleBackColor = true;
            // 
            // tabAP
            // 
            this.tabAP.Controls.Add(this.groupBox12);
            this.tabAP.Controls.Add(this.groupBox11);
            this.tabAP.Location = new System.Drawing.Point(4, 22);
            this.tabAP.Name = "tabAP";
            this.tabAP.Size = new System.Drawing.Size(660, 173);
            this.tabAP.TabIndex = 3;
            this.tabAP.Text = "Apertura - Chiusura";
            this.tabAP.UseVisualStyleBackColor = true;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.textBox3);
            this.groupBox11.Controls.Add(this.txtCodiceContoPat);
            this.groupBox11.Controls.Add(this.button9);
            this.groupBox11.Location = new System.Drawing.Point(3, 3);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(296, 72);
            this.groupBox11.TabIndex = 3;
            this.groupBox11.TabStop = false;
            this.groupBox11.Tag = "AutoManage.txtCodiceContoPat.tree";
            this.groupBox11.Text = "Conto Associato allo Stato Patrimoniale";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(136, 16);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(152, 52);
            this.textBox3.TabIndex = 2;
            this.textBox3.TabStop = false;
            this.textBox3.Tag = "account_pat.title";
            // 
            // txtCodiceContoPat
            // 
            this.txtCodiceContoPat.Location = new System.Drawing.Point(8, 48);
            this.txtCodiceContoPat.Name = "txtCodiceContoPat";
            this.txtCodiceContoPat.Size = new System.Drawing.Size(120, 20);
            this.txtCodiceContoPat.TabIndex = 1;
            this.txtCodiceContoPat.Tag = "account_pat.codeacc?x";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(8, 16);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(120, 23);
            this.button9.TabIndex = 0;
            this.button9.TabStop = false;
            this.button9.Tag = "manage.account_pat.tree";
            this.button9.Text = "Conto";
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.textBox8);
            this.groupBox12.Controls.Add(this.txtCodiceContoPL);
            this.groupBox12.Controls.Add(this.button10);
            this.groupBox12.Location = new System.Drawing.Point(305, 3);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(296, 72);
            this.groupBox12.TabIndex = 4;
            this.groupBox12.TabStop = false;
            this.groupBox12.Tag = "AutoManage.txtCodiceContoPL.tree";
            this.groupBox12.Text = "Conto Associato al Conto Economico";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(136, 16);
            this.textBox8.Multiline = true;
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(152, 52);
            this.textBox8.TabIndex = 2;
            this.textBox8.TabStop = false;
            this.textBox8.Tag = "account_pl.title";
            // 
            // txtCodiceContoPL
            // 
            this.txtCodiceContoPL.Location = new System.Drawing.Point(8, 48);
            this.txtCodiceContoPL.Name = "txtCodiceContoPL";
            this.txtCodiceContoPL.Size = new System.Drawing.Size(120, 20);
            this.txtCodiceContoPL.TabIndex = 1;
            this.txtCodiceContoPL.Tag = "account_pl.codeacc?x";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(8, 16);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(120, 23);
            this.button10.TabIndex = 0;
            this.button10.TabStop = false;
            this.button10.Tag = "manage.account_pl.tree";
            this.button10.Text = "Conto";
            // 
            // Frm_entrysetup_default
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(684, 247);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOK);
            this.Name = "Frm_entrysetup_default";
            this.Text = "Frm_entrysetup_default";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.gboxConto.ResumeLayout(false);
            this.gboxConto.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabAnagrafica.ResumeLayout(false);
            this.tabIva.ResumeLayout(false);
            this.tabRR.ResumeLayout(false);
            this.tabAP.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion
	}
}