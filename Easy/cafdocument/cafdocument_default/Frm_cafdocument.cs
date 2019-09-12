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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;

namespace cafdocument_default//comunicazionedacaf//
{
	/// <summary>
	/// Summary description for frmcomunicazionedacaf.
	/// </summary>
	public class Frm_cafdocument : System.Windows.Forms.Form {
		private System.Windows.Forms.GroupBox groupBox9;
		private System.Windows.Forms.Label label50;
		private System.Windows.Forms.Label label51;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label52;
		private System.Windows.Forms.Label label53;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TextBox SubEntity_txtsecondarataaccontoirpef;
		private System.Windows.Forms.Label label47;
		private System.Windows.Forms.Label label46;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Label label45;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.GroupBox groupBox12;
		private System.Windows.Forms.Label label48;
		private System.Windows.Forms.Label label49;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton3;
		MetaData Meta;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox txtnumerorateprimarata;
		private System.Windows.Forms.ComboBox cmbMeseInizioPrimaRataIrpef;
		private System.Windows.Forms.TextBox txtnumeroratesecondarata;
		private System.Windows.Forms.ComboBox cmbMeseInizioSecondaRataIrpef;
		private System.Windows.Forms.TextBox txtprimarataaccontoirpef;
		private System.Windows.Forms.TextBox txtreddititassazioneseparatacon;
		private System.Windows.Forms.TextBox txtreddititassazioneseparatadich;
		private System.Windows.Forms.TextBox txtaddirpefcomdarimborsarecon;
		private System.Windows.Forms.TextBox txtaddirpefcomdatrattenerecon;
		private System.Windows.Forms.TextBox txtaddirpefcomdarimborsaredich;
		private System.Windows.Forms.TextBox txtaddirpefcomdatratteneredich;
		private System.Windows.Forms.TextBox txtaddirpefregdarimborsarecon;
		private System.Windows.Forms.TextBox txtaddirpefregdatrattenerecon;
		private System.Windows.Forms.TextBox txtaddirpefregdarimborsaredich;
		private System.Windows.Forms.TextBox txtaddirpefregdatratteneredich;
		private System.Windows.Forms.TextBox txtirpefdarimborsare;
		private System.Windows.Forms.TextBox txtirpefdatrattenere;
		private System.Windows.Forms.TextBox txtnumerorate;
		private System.Windows.Forms.ComboBox cmbMeseInizioAddCaf;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		public cafdocument_default.vistaForm DS;
        private GroupBox groupBox4;
        private ComboBox comboBox1;
        private GroupBox groupBox5;
        private Label label6;
        private Label label5;
        private Label label4;
        private TextBox txtProv;
        private TextBox txtComune;
        private TextBox txtCodiceComune;
        private TabControl tabControl1;
        private TabPage tabMain;
        private TabPage tabAcconti;
        private TextBox textBox4;
        private TextBox textBox5;
        private Label label8;
        private Label label9;
        private Label label7;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_cafdocument()
		{
			InitializeComponent();
			HelpForm.SetDenyNull(DS.cafdocument.Columns["cafdocumentkind"],true);
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

        QueryHelper QHS;
        CQueryHelper QHC;
		public void MetaData_AfterLink(){
			Meta = MetaData.GetMetaData(this);
            QHS = Meta.Conn.GetQueryHelper();
            QHC = new CQueryHelper();
			GetData.SetSorting(DS.monthname,"code");
            GetData.SetSorting(DS.monthname1, "code");
            GetData.SetSorting(DS.monthname2, "code");
		    DataAccess.SetTableForReading(DS.monthname1, "monthname");
            DataAccess.SetTableForReading(DS.monthname2, "monthname");
            GetData.SetSorting(DS.fiscaltaxregion, "title");
            string filterAgency = QHS.AppAnd(QHS.CmpEq("idagency", 1), QHS.CmpEq("idcode", 1), QHS.CmpEq("version", 1),
                QHS.IsNull("newcity"), QHS.IsNull("stop"));
            GetData.SetStaticFilter(DS.geo_city_agencyview, filterAgency);
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtProv = new System.Windows.Forms.TextBox();
            this.txtComune = new System.Windows.Forms.TextBox();
            this.txtCodiceComune = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.DS = new cafdocument_default.vistaForm();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label50 = new System.Windows.Forms.Label();
            this.txtnumerorateprimarata = new System.Windows.Forms.TextBox();
            this.cmbMeseInizioPrimaRataIrpef = new System.Windows.Forms.ComboBox();
            this.label51 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label52 = new System.Windows.Forms.Label();
            this.txtnumeroratesecondarata = new System.Windows.Forms.TextBox();
            this.label53 = new System.Windows.Forms.Label();
            this.cmbMeseInizioSecondaRataIrpef = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SubEntity_txtsecondarataaccontoirpef = new System.Windows.Forms.TextBox();
            this.txtprimarataaccontoirpef = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.txtreddititassazioneseparatacon = new System.Windows.Forms.TextBox();
            this.txtreddititassazioneseparatadich = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label45 = new System.Windows.Forms.Label();
            this.txtaddirpefcomdarimborsarecon = new System.Windows.Forms.TextBox();
            this.txtaddirpefcomdatrattenerecon = new System.Windows.Forms.TextBox();
            this.txtaddirpefcomdarimborsaredich = new System.Windows.Forms.TextBox();
            this.txtaddirpefcomdatratteneredich = new System.Windows.Forms.TextBox();
            this.txtaddirpefregdarimborsarecon = new System.Windows.Forms.TextBox();
            this.txtaddirpefregdatrattenerecon = new System.Windows.Forms.TextBox();
            this.txtaddirpefregdarimborsaredich = new System.Windows.Forms.TextBox();
            this.txtaddirpefregdatratteneredich = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtirpefdarimborsare = new System.Windows.Forms.TextBox();
            this.txtirpefdatrattenere = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.txtnumerorate = new System.Windows.Forms.TextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.cmbMeseInizioAddCaf = new System.Windows.Forms.ComboBox();
            this.label49 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.tabAcconti = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox9.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabAcconti.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.txtProv);
            this.groupBox5.Controls.Add(this.txtComune);
            this.groupBox5.Controls.Add(this.txtCodiceComune);
            this.groupBox5.Location = new System.Drawing.Point(8, 193);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(549, 40);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Tag = "AutoChoose.txtCodiceComune.default";
            this.groupBox5.Text = "Comune per addizionale comunale:";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(433, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 17);
            this.label6.TabIndex = 57;
            this.label6.Text = "Prov:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(147, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 17);
            this.label5.TabIndex = 56;
            this.label5.Text = "Comune:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 17);
            this.label4.TabIndex = 55;
            this.label4.Text = "Codice:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtProv
            // 
            this.txtProv.Location = new System.Drawing.Point(497, 13);
            this.txtProv.Name = "txtProv";
            this.txtProv.ReadOnly = true;
            this.txtProv.Size = new System.Drawing.Size(47, 20);
            this.txtProv.TabIndex = 2;
            this.txtProv.TabStop = false;
            this.txtProv.Tag = "geo_city_agencyview.provincecode?x";
            // 
            // txtComune
            // 
            this.txtComune.Location = new System.Drawing.Point(208, 13);
            this.txtComune.Name = "txtComune";
            this.txtComune.ReadOnly = true;
            this.txtComune.Size = new System.Drawing.Size(221, 20);
            this.txtComune.TabIndex = 1;
            this.txtComune.TabStop = false;
            this.txtComune.Tag = "geo_city_agencyview.title?x";
            // 
            // txtCodiceComune
            // 
            this.txtCodiceComune.Location = new System.Drawing.Point(64, 15);
            this.txtCodiceComune.Name = "txtCodiceComune";
            this.txtCodiceComune.Size = new System.Drawing.Size(77, 20);
            this.txtCodiceComune.TabIndex = 0;
            this.txtCodiceComune.Tag = "geo_city_agencyview.value?cafdocumentview.citycode";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.comboBox1);
            this.groupBox4.Location = new System.Drawing.Point(12, 81);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(434, 42);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Regione per addizionale regionale:";
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.DS.fiscaltaxregion;
            this.comboBox1.DisplayMember = "title";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(5, 15);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(417, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.Tag = "cafdocument.idfiscaltaxregion";
            this.comboBox1.ValueMember = "idfiscaltaxregion";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.label50);
            this.groupBox9.Controls.Add(this.txtnumerorateprimarata);
            this.groupBox9.Controls.Add(this.cmbMeseInizioPrimaRataIrpef);
            this.groupBox9.Controls.Add(this.label51);
            this.groupBox9.Location = new System.Drawing.Point(6, 28);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(456, 32);
            this.groupBox9.TabIndex = 17;
            this.groupBox9.TabStop = false;
            // 
            // label50
            // 
            this.label50.Location = new System.Drawing.Point(8, 8);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(56, 16);
            this.label50.TabIndex = 44;
            this.label50.Text = "N.ro Rate";
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtnumerorateprimarata
            // 
            this.txtnumerorateprimarata.Location = new System.Drawing.Point(72, 8);
            this.txtnumerorateprimarata.Name = "txtnumerorateprimarata";
            this.txtnumerorateprimarata.Size = new System.Drawing.Size(48, 20);
            this.txtnumerorateprimarata.TabIndex = 46;
            this.txtnumerorateprimarata.Tag = "cafdocument.nquotafirstinstalment";
            // 
            // cmbMeseInizioPrimaRataIrpef
            // 
            this.cmbMeseInizioPrimaRataIrpef.DataSource = this.DS.monthname1;
            this.cmbMeseInizioPrimaRataIrpef.DisplayMember = "title";
            this.cmbMeseInizioPrimaRataIrpef.Location = new System.Drawing.Point(312, 8);
            this.cmbMeseInizioPrimaRataIrpef.Name = "cmbMeseInizioPrimaRataIrpef";
            this.cmbMeseInizioPrimaRataIrpef.Size = new System.Drawing.Size(136, 21);
            this.cmbMeseInizioPrimaRataIrpef.TabIndex = 47;
            this.cmbMeseInizioPrimaRataIrpef.Tag = "cafdocument.monthfirstinstalment";
            this.cmbMeseInizioPrimaRataIrpef.ValueMember = "code";
            // 
            // label51
            // 
            this.label51.Location = new System.Drawing.Point(240, 8);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(64, 16);
            this.label51.TabIndex = 45;
            this.label51.Text = "Mese Inizio";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label52);
            this.groupBox3.Controls.Add(this.txtnumeroratesecondarata);
            this.groupBox3.Controls.Add(this.label53);
            this.groupBox3.Controls.Add(this.cmbMeseInizioSecondaRataIrpef);
            this.groupBox3.Location = new System.Drawing.Point(6, 98);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(456, 32);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            // 
            // label52
            // 
            this.label52.Location = new System.Drawing.Point(8, 8);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(56, 16);
            this.label52.TabIndex = 48;
            this.label52.Text = "N.ro Rate";
            this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtnumeroratesecondarata
            // 
            this.txtnumeroratesecondarata.Enabled = false;
            this.txtnumeroratesecondarata.Location = new System.Drawing.Point(72, 8);
            this.txtnumeroratesecondarata.Name = "txtnumeroratesecondarata";
            this.txtnumeroratesecondarata.Size = new System.Drawing.Size(48, 20);
            this.txtnumeroratesecondarata.TabIndex = 50;
            this.txtnumeroratesecondarata.Tag = "cafdocument.nquotasecondinstalment";
            // 
            // label53
            // 
            this.label53.Location = new System.Drawing.Point(240, 8);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(64, 16);
            this.label53.TabIndex = 49;
            this.label53.Text = "Mese Inizio";
            this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbMeseInizioSecondaRataIrpef
            // 
            this.cmbMeseInizioSecondaRataIrpef.DataSource = this.DS.monthname2;
            this.cmbMeseInizioSecondaRataIrpef.DisplayMember = "title";
            this.cmbMeseInizioSecondaRataIrpef.Location = new System.Drawing.Point(312, 8);
            this.cmbMeseInizioSecondaRataIrpef.Name = "cmbMeseInizioSecondaRataIrpef";
            this.cmbMeseInizioSecondaRataIrpef.Size = new System.Drawing.Size(136, 21);
            this.cmbMeseInizioSecondaRataIrpef.TabIndex = 51;
            this.cmbMeseInizioSecondaRataIrpef.Tag = "cafdocument.monthsecondinstalment";
            this.cmbMeseInizioSecondaRataIrpef.ValueMember = "code";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(6, 68);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(527, 2);
            this.panel2.TabIndex = 52;
            // 
            // SubEntity_txtsecondarataaccontoirpef
            // 
            this.SubEntity_txtsecondarataaccontoirpef.Location = new System.Drawing.Point(174, 76);
            this.SubEntity_txtsecondarataaccontoirpef.Name = "SubEntity_txtsecondarataaccontoirpef";
            this.SubEntity_txtsecondarataaccontoirpef.Size = new System.Drawing.Size(100, 20);
            this.SubEntity_txtsecondarataaccontoirpef.TabIndex = 18;
            this.SubEntity_txtsecondarataaccontoirpef.Tag = "cafdocument.secondrateadvance";
            // 
            // txtprimarataaccontoirpef
            // 
            this.txtprimarataaccontoirpef.Location = new System.Drawing.Point(174, 5);
            this.txtprimarataaccontoirpef.Name = "txtprimarataaccontoirpef";
            this.txtprimarataaccontoirpef.Size = new System.Drawing.Size(100, 20);
            this.txtprimarataaccontoirpef.TabIndex = 16;
            this.txtprimarataaccontoirpef.Tag = "cafdocument.firstrateadvance";
            // 
            // label47
            // 
            this.label47.Location = new System.Drawing.Point(6, 78);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(160, 16);
            this.label47.TabIndex = 37;
            this.label47.Text = "Seconda Rata Acconto IRPEF";
            this.label47.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label46
            // 
            this.label46.Location = new System.Drawing.Point(6, 7);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(160, 16);
            this.label46.TabIndex = 36;
            this.label46.Text = "Prima Rata Acconto IRPEF";
            this.label46.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtreddititassazioneseparatacon
            // 
            this.txtreddititassazioneseparatacon.Location = new System.Drawing.Point(334, 370);
            this.txtreddititassazioneseparatacon.Name = "txtreddititassazioneseparatacon";
            this.txtreddititassazioneseparatacon.Size = new System.Drawing.Size(104, 20);
            this.txtreddititassazioneseparatacon.TabIndex = 14;
            this.txtreddititassazioneseparatacon.Tag = "cafdocument.separatedincomehusband";
            // 
            // txtreddititassazioneseparatadich
            // 
            this.txtreddititassazioneseparatadich.Location = new System.Drawing.Point(78, 370);
            this.txtreddititassazioneseparatadich.Name = "txtreddititassazioneseparatadich";
            this.txtreddititassazioneseparatadich.Size = new System.Drawing.Size(104, 20);
            this.txtreddititassazioneseparatadich.TabIndex = 13;
            this.txtreddititassazioneseparatadich.Tag = "cafdocument.separatedincome";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(8, 342);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(515, 2);
            this.panel1.TabIndex = 33;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Location = new System.Drawing.Point(11, 46);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(515, 2);
            this.panel5.TabIndex = 32;
            // 
            // label45
            // 
            this.label45.Location = new System.Drawing.Point(126, 356);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(224, 16);
            this.label45.TabIndex = 25;
            this.label45.Text = "Acconto 20% Redditi Tassazione Separata";
            this.label45.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtaddirpefcomdarimborsarecon
            // 
            this.txtaddirpefcomdarimborsarecon.Location = new System.Drawing.Point(358, 261);
            this.txtaddirpefcomdarimborsarecon.Name = "txtaddirpefcomdarimborsarecon";
            this.txtaddirpefcomdarimborsarecon.Size = new System.Drawing.Size(88, 20);
            this.txtaddirpefcomdarimborsarecon.TabIndex = 12;
            this.txtaddirpefcomdarimborsarecon.Tag = "cafdocument.citytaxtorefundhusband";
            // 
            // txtaddirpefcomdatrattenerecon
            // 
            this.txtaddirpefcomdatrattenerecon.Location = new System.Drawing.Point(358, 237);
            this.txtaddirpefcomdatrattenerecon.Name = "txtaddirpefcomdatrattenerecon";
            this.txtaddirpefcomdatrattenerecon.Size = new System.Drawing.Size(88, 20);
            this.txtaddirpefcomdatrattenerecon.TabIndex = 10;
            this.txtaddirpefcomdatrattenerecon.Tag = "cafdocument.citytaxtoretainhusband";
            // 
            // txtaddirpefcomdarimborsaredich
            // 
            this.txtaddirpefcomdarimborsaredich.Location = new System.Drawing.Point(102, 261);
            this.txtaddirpefcomdarimborsaredich.Name = "txtaddirpefcomdarimborsaredich";
            this.txtaddirpefcomdarimborsaredich.Size = new System.Drawing.Size(88, 20);
            this.txtaddirpefcomdarimborsaredich.TabIndex = 11;
            this.txtaddirpefcomdarimborsaredich.Tag = "cafdocument.citytaxtorefund";
            // 
            // txtaddirpefcomdatratteneredich
            // 
            this.txtaddirpefcomdatratteneredich.Location = new System.Drawing.Point(102, 237);
            this.txtaddirpefcomdatratteneredich.Name = "txtaddirpefcomdatratteneredich";
            this.txtaddirpefcomdatratteneredich.Size = new System.Drawing.Size(88, 20);
            this.txtaddirpefcomdatratteneredich.TabIndex = 9;
            this.txtaddirpefcomdatratteneredich.Tag = "cafdocument.citytaxtoretain";
            // 
            // txtaddirpefregdarimborsarecon
            // 
            this.txtaddirpefregdarimborsarecon.Location = new System.Drawing.Point(358, 150);
            this.txtaddirpefregdarimborsarecon.Name = "txtaddirpefregdarimborsarecon";
            this.txtaddirpefregdarimborsarecon.Size = new System.Drawing.Size(88, 20);
            this.txtaddirpefregdarimborsarecon.TabIndex = 7;
            this.txtaddirpefregdarimborsarecon.Tag = "cafdocument.regionaltaxtorefundhusband";
            // 
            // txtaddirpefregdatrattenerecon
            // 
            this.txtaddirpefregdatrattenerecon.Location = new System.Drawing.Point(358, 126);
            this.txtaddirpefregdatrattenerecon.Name = "txtaddirpefregdatrattenerecon";
            this.txtaddirpefregdatrattenerecon.Size = new System.Drawing.Size(88, 20);
            this.txtaddirpefregdatrattenerecon.TabIndex = 5;
            this.txtaddirpefregdatrattenerecon.Tag = "cafdocument.regionaltaxtoretainhusband";
            // 
            // txtaddirpefregdarimborsaredich
            // 
            this.txtaddirpefregdarimborsaredich.Location = new System.Drawing.Point(102, 150);
            this.txtaddirpefregdarimborsaredich.Name = "txtaddirpefregdarimborsaredich";
            this.txtaddirpefregdarimborsaredich.Size = new System.Drawing.Size(88, 20);
            this.txtaddirpefregdarimborsaredich.TabIndex = 6;
            this.txtaddirpefregdarimborsaredich.Tag = "cafdocument.regionaltaxtorefund";
            // 
            // txtaddirpefregdatratteneredich
            // 
            this.txtaddirpefregdatratteneredich.Location = new System.Drawing.Point(102, 126);
            this.txtaddirpefregdatratteneredich.Name = "txtaddirpefregdatratteneredich";
            this.txtaddirpefregdatratteneredich.Size = new System.Drawing.Size(88, 20);
            this.txtaddirpefregdatratteneredich.TabIndex = 4;
            this.txtaddirpefregdatratteneredich.Tag = "cafdocument.regionaltaxtoretain";
            // 
            // label34
            // 
            this.label34.Location = new System.Drawing.Point(262, 261);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(88, 16);
            this.label34.TabIndex = 16;
            this.label34.Text = "Da Rimborsare:";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label32
            // 
            this.label32.Location = new System.Drawing.Point(270, 237);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(80, 16);
            this.label32.TabIndex = 15;
            this.label32.Text = "Da Trattenere:";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label31
            // 
            this.label31.Location = new System.Drawing.Point(10, 261);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(88, 16);
            this.label31.TabIndex = 14;
            this.label31.Text = "Da Rimborsare:";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label29
            // 
            this.label29.Location = new System.Drawing.Point(18, 236);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(80, 16);
            this.label29.TabIndex = 13;
            this.label29.Text = "Da Trattenere:";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label28
            // 
            this.label28.Location = new System.Drawing.Point(174, 176);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(136, 16);
            this.label28.TabIndex = 12;
            this.label28.Text = "Addizionale COMUNALE";
            this.label28.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(262, 150);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(88, 16);
            this.label27.TabIndex = 11;
            this.label27.Text = "Da Rimborsare:";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(270, 126);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(80, 16);
            this.label26.TabIndex = 10;
            this.label26.Text = "Da Trattenere:";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(10, 150);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(88, 16);
            this.label25.TabIndex = 9;
            this.label25.Text = "Da Rimborsare:";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(18, 126);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(80, 16);
            this.label24.TabIndex = 8;
            this.label24.Text = "Da Trattenere:";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(334, 51);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(100, 16);
            this.label23.TabIndex = 7;
            this.label23.Text = "Coniuge";
            this.label23.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(62, 51);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(100, 16);
            this.label22.TabIndex = 6;
            this.label22.Text = "Dichiarante";
            this.label22.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(174, 64);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(136, 16);
            this.label21.TabIndex = 5;
            this.label21.Text = "Addizionale REGIONALE";
            this.label21.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtirpefdarimborsare
            // 
            this.txtirpefdarimborsare.Location = new System.Drawing.Point(362, 20);
            this.txtirpefdarimborsare.Name = "txtirpefdarimborsare";
            this.txtirpefdarimborsare.Size = new System.Drawing.Size(88, 20);
            this.txtirpefdarimborsare.TabIndex = 2;
            this.txtirpefdarimborsare.Tag = "cafdocument.irpeftorefund";
            // 
            // txtirpefdatrattenere
            // 
            this.txtirpefdatrattenere.Location = new System.Drawing.Point(106, 20);
            this.txtirpefdatrattenere.Name = "txtirpefdatrattenere";
            this.txtirpefdatrattenere.Size = new System.Drawing.Size(88, 20);
            this.txtirpefdatrattenere.TabIndex = 1;
            this.txtirpefdatrattenere.Tag = "cafdocument.irpeftoretain";
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(266, 20);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(88, 16);
            this.label20.TabIndex = 2;
            this.label20.Text = "Da Rimborsare:";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(18, 20);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(80, 16);
            this.label19.TabIndex = 1;
            this.label19.Text = "Da Trattenere:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(194, 4);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(100, 16);
            this.label18.TabIndex = 0;
            this.label18.Text = "IRPEF";
            this.label18.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.txtnumerorate);
            this.groupBox12.Controls.Add(this.label48);
            this.groupBox12.Controls.Add(this.cmbMeseInizioAddCaf);
            this.groupBox12.Controls.Add(this.label49);
            this.groupBox12.Location = new System.Drawing.Point(6, 394);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(455, 40);
            this.groupBox12.TabIndex = 15;
            this.groupBox12.TabStop = false;
            // 
            // txtnumerorate
            // 
            this.txtnumerorate.Location = new System.Drawing.Point(65, 15);
            this.txtnumerorate.Name = "txtnumerorate";
            this.txtnumerorate.Size = new System.Drawing.Size(48, 20);
            this.txtnumerorate.TabIndex = 42;
            this.txtnumerorate.Tag = "cafdocument.ratequantity";
            // 
            // label48
            // 
            this.label48.Location = new System.Drawing.Point(3, 16);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(56, 16);
            this.label48.TabIndex = 40;
            this.label48.Text = "N.ro Rate";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbMeseInizioAddCaf
            // 
            this.cmbMeseInizioAddCaf.DataSource = this.DS.monthname;
            this.cmbMeseInizioAddCaf.DisplayMember = "title";
            this.cmbMeseInizioAddCaf.Location = new System.Drawing.Point(199, 13);
            this.cmbMeseInizioAddCaf.Name = "cmbMeseInizioAddCaf";
            this.cmbMeseInizioAddCaf.Size = new System.Drawing.Size(153, 21);
            this.cmbMeseInizioAddCaf.TabIndex = 43;
            this.cmbMeseInizioAddCaf.Tag = "cafdocument.startmonth";
            this.cmbMeseInizioAddCaf.ValueMember = "code";
            // 
            // label49
            // 
            this.label49.Location = new System.Drawing.Point(129, 15);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(64, 16);
            this.label49.TabIndex = 41;
            this.label49.Text = "Mese Inizio";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(636, 64);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dati Generali della Comunicazione dal Centro di Assistenza Fiscale";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(80, 16);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(72, 20);
            this.textBox3.TabIndex = 6;
            this.textBox3.TabStop = false;
            this.textBox3.Tag = "cafdocument.ayear.year";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Esercizio:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton3);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Location = new System.Drawing.Point(336, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(294, 39);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipo Comunicazione";
            // 
            // radioButton3
            // 
            this.radioButton3.Location = new System.Drawing.Point(164, 16);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(104, 16);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Tag = "cafdocument.cafdocumentkind:R";
            this.radioButton3.Text = "Rettificativa";
            // 
            // radioButton2
            // 
            this.radioButton2.Location = new System.Drawing.Point(80, 16);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(104, 16);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Tag = "cafdocument.cafdocumentkind:I";
            this.radioButton2.Text = "Integrativa";
            // 
            // radioButton1
            // 
            this.radioButton1.Location = new System.Drawing.Point(8, 16);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(104, 16);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Tag = "cafdocument.cafdocumentkind:O";
            this.radioButton1.Text = "Ordinaria";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Data:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(168, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Numero:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(80, 39);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 1;
            this.textBox2.Tag = "cafdocument.docdate";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(240, 17);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(72, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.TabStop = false;
            this.textBox1.Tag = "cafdocument.idcafdocument";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(579, 488);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 23);
            this.button1.TabIndex = 3;
            this.button1.Tag = "mainsave";
            this.button1.Text = "Ok";
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(579, 520);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(64, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Annulla";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabMain);
            this.tabControl1.Controls.Add(this.tabAcconti);
            this.tabControl1.Location = new System.Drawing.Point(9, 78);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(568, 469);
            this.tabControl1.TabIndex = 5;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.textBox4);
            this.tabMain.Controls.Add(this.textBox5);
            this.tabMain.Controls.Add(this.label8);
            this.tabMain.Controls.Add(this.label9);
            this.tabMain.Controls.Add(this.label7);
            this.tabMain.Controls.Add(this.groupBox5);
            this.tabMain.Controls.Add(this.label19);
            this.tabMain.Controls.Add(this.groupBox4);
            this.tabMain.Controls.Add(this.label18);
            this.tabMain.Controls.Add(this.txtreddititassazioneseparatacon);
            this.tabMain.Controls.Add(this.label20);
            this.tabMain.Controls.Add(this.txtreddititassazioneseparatadich);
            this.tabMain.Controls.Add(this.txtirpefdatrattenere);
            this.tabMain.Controls.Add(this.panel1);
            this.tabMain.Controls.Add(this.txtirpefdarimborsare);
            this.tabMain.Controls.Add(this.label45);
            this.tabMain.Controls.Add(this.panel5);
            this.tabMain.Controls.Add(this.txtaddirpefcomdarimborsarecon);
            this.tabMain.Controls.Add(this.label22);
            this.tabMain.Controls.Add(this.txtaddirpefcomdatrattenerecon);
            this.tabMain.Controls.Add(this.groupBox12);
            this.tabMain.Controls.Add(this.txtaddirpefcomdarimborsaredich);
            this.tabMain.Controls.Add(this.label21);
            this.tabMain.Controls.Add(this.txtaddirpefcomdatratteneredich);
            this.tabMain.Controls.Add(this.label23);
            this.tabMain.Controls.Add(this.txtaddirpefregdarimborsarecon);
            this.tabMain.Controls.Add(this.label24);
            this.tabMain.Controls.Add(this.txtaddirpefregdatrattenerecon);
            this.tabMain.Controls.Add(this.label25);
            this.tabMain.Controls.Add(this.txtaddirpefregdarimborsaredich);
            this.tabMain.Controls.Add(this.label26);
            this.tabMain.Controls.Add(this.txtaddirpefregdatratteneredich);
            this.tabMain.Controls.Add(this.label27);
            this.tabMain.Controls.Add(this.label34);
            this.tabMain.Controls.Add(this.label28);
            this.tabMain.Controls.Add(this.label32);
            this.tabMain.Controls.Add(this.label29);
            this.tabMain.Controls.Add(this.label31);
            this.tabMain.Location = new System.Drawing.Point(4, 22);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMain.Size = new System.Drawing.Size(560, 443);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "Principale";
            this.tabMain.UseVisualStyleBackColor = true;
            // 
            // tabAcconti
            // 
            this.tabAcconti.Controls.Add(this.label46);
            this.tabAcconti.Controls.Add(this.txtprimarataaccontoirpef);
            this.tabAcconti.Controls.Add(this.groupBox3);
            this.tabAcconti.Controls.Add(this.panel2);
            this.tabAcconti.Controls.Add(this.groupBox9);
            this.tabAcconti.Controls.Add(this.SubEntity_txtsecondarataaccontoirpef);
            this.tabAcconti.Controls.Add(this.label47);
            this.tabAcconti.Location = new System.Drawing.Point(4, 22);
            this.tabAcconti.Name = "tabAcconti";
            this.tabAcconti.Padding = new System.Windows.Forms.Padding(3);
            this.tabAcconti.Size = new System.Drawing.Size(572, 387);
            this.tabAcconti.TabIndex = 1;
            this.tabAcconti.Text = "Altri Acconti IRPEF";
            this.tabAcconti.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(155, 295);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(176, 16);
            this.label7.TabIndex = 34;
            this.label7.Text = "Acconto Addizionale COMUNALE";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(358, 316);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(88, 20);
            this.textBox4.TabIndex = 36;
            this.textBox4.Tag = "cafdocument.citytaxaccounthusband";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(102, 316);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(88, 20);
            this.textBox5.TabIndex = 35;
            this.textBox5.Tag = "cafdocument.citytaxaccount";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(270, 316);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 16);
            this.label8.TabIndex = 38;
            this.label8.Text = "Da Trattenere:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(18, 315);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 16);
            this.label9.TabIndex = 37;
            this.label9.Text = "Da Trattenere:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Frm_cafdocument
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(646, 549);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_cafdocument";
            this.Text = "frmcomunicazionedacaf";
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabMain.PerformLayout();
            this.tabAcconti.ResumeLayout(false);
            this.tabAcconti.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

    }
}
