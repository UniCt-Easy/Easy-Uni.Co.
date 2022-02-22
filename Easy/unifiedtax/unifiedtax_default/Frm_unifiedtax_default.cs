
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
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using funzioni_configurazione;
using metadatalibrary;

namespace unifiedtax_default// Ritenute centralizzate
{
    public partial class Frm_unifiedtax_default : MetaDataForm
    {
        private TextBox textBox19;
        private Label label13;
        private Label label12;
        private GroupBox groupBox4;
        private TextBox textBox14;
        private TextBox textBox16;
        private GroupBox groupBox5;
        private TextBox txtCreDeb;
        private GroupBox groupBox2;
        private ComboBox comboBox1;
        private Label label8;
        private Label label9;
        private TextBox textBox9;
        private TextBox textBox10;
        private TextBox textBox11;
        private GroupBox groupBox3;
        private TextBox txtEsercMov;
        private TextBox textBox3;
        private Label label1;
        private Label label2;
        private GroupBox groupBox1;
        private TextBox textBox5;
        private Label label4;
        private Label label17;
        private TextBox txtNum;
        private GroupBox groupBox6;
        private TextBox txtnbracket;
        private Label labNumscaglione;
        private TextBox txtDetrazioni;
        private TextBox textBox2;
        private Label label14;
        private Label label15;
        private Label label10;
        private TextBox textBox18;
        public vistaForm DS;
        private TextBox textBox15;
        private ComboBox cmbBoxDepartment;
        private GroupBox groupBox8;
        private Label label11;
        private TextBox txtEserc;
        private Label label16;
        private Label label3;
        private TextBox textBox4;
        private Label label5;
        private TextBox textBox6;
        private Button btnScollega;
        MetaData Meta;
        private TextBox textBox1;
        private Label label6;
        private GroupBox gboxService;
        private Label label7;
        private TextBox txtstop;
        private Label label18;
        private TextBox txtstart;
        DataAccess Conn;

        public Frm_unifiedtax_default(){
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtCreDeb = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.DS = new unifiedtax_default.vistaForm();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtEsercMov = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtEserc = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtnbracket = new System.Windows.Forms.TextBox();
            this.labNumscaglione = new System.Windows.Forms.Label();
            this.txtDetrazioni = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbBoxDepartment = new System.Windows.Forms.ComboBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.btnScollega = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.gboxService = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtstop = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtstart = new System.Windows.Forms.TextBox();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.gboxService.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox19
            // 
            this.textBox19.Location = new System.Drawing.Point(360, 391);
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(112, 20);
            this.textBox19.TabIndex = 21;
            this.textBox19.Tag = "unifiedtax.admintax?unifiedtaxview.admintax";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(8, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 16);
            this.label13.TabIndex = 12;
            this.label13.Text = "Aliquota:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(104, 32);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 16);
            this.label12.TabIndex = 13;
            this.label12.Text = "Quota:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBox14);
            this.groupBox4.Controls.Add(this.textBox15);
            this.groupBox4.Controls.Add(this.textBox16);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Location = new System.Drawing.Point(232, 439);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(240, 80);
            this.groupBox4.TabIndex = 23;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Contributi c/amministrazione";
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(153, 48);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(80, 20);
            this.textBox14.TabIndex = 3;
            this.textBox14.Tag = "unifiedtax.admindenominator";
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(154, 24);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(80, 20);
            this.textBox15.TabIndex = 2;
            this.textBox15.Tag = "unifiedtax.adminnumerator";
            // 
            // textBox16
            // 
            this.textBox16.Location = new System.Drawing.Point(8, 32);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(80, 20);
            this.textBox16.TabIndex = 1;
            this.textBox16.Tag = "unifiedtax.adminrate.fixed.2..%.100";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtCreDeb);
            this.groupBox5.Location = new System.Drawing.Point(8, 206);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(472, 48);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Tag = "AutoChoose.txtCreDeb.default";
            this.groupBox5.Text = "Percipiente";
            // 
            // txtCreDeb
            // 
            this.txtCreDeb.Location = new System.Drawing.Point(8, 21);
            this.txtCreDeb.Name = "txtCreDeb";
            this.txtCreDeb.Size = new System.Drawing.Size(456, 20);
            this.txtCreDeb.TabIndex = 6;
            this.txtCreDeb.Tag = "registry.title?unifiedtaxview.registry";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Location = new System.Drawing.Point(8, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(472, 48);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ritenuta";
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.DS.tax;
            this.comboBox1.DisplayMember = "description";
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.comboBox1.Location = new System.Drawing.Point(85, 16);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(384, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.Tag = "unifiedtax.taxcode?unifiedtaxview.taxcode";
            this.comboBox1.ValueMember = "taxcode";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(16, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 16);
            this.label8.TabIndex = 0;
            this.label8.Text = "Aliquota:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(96, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 16);
            this.label9.TabIndex = 1;
            this.label9.Text = "Quota:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(8, 32);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(80, 20);
            this.textBox9.TabIndex = 1;
            this.textBox9.Tag = "unifiedtax.employrate.fixed.2..%.100";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(136, 24);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(72, 20);
            this.textBox10.TabIndex = 2;
            this.textBox10.Tag = "unifiedtax.employnumerator";
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(136, 48);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(72, 20);
            this.textBox11.TabIndex = 3;
            this.textBox11.Tag = "unifiedtax.employdenominator";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox11);
            this.groupBox3.Controls.Add(this.textBox10);
            this.groupBox3.Controls.Add(this.textBox9);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(8, 439);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(224, 80);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ritenute c/dipendente";
            // 
            // txtEsercMov
            // 
            this.txtEsercMov.Location = new System.Drawing.Point(72, 20);
            this.txtEsercMov.Name = "txtEsercMov";
            this.txtEsercMov.Size = new System.Drawing.Size(104, 20);
            this.txtEsercMov.TabIndex = 1;
            this.txtEsercMov.Tag = "unifiedtax.ymov.year";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(72, 48);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(104, 20);
            this.textBox3.TabIndex = 2;
            this.textBox3.Tag = "unifiedtax.nmov";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Numero:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Esercizio:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.txtEsercMov);
            this.groupBox1.Location = new System.Drawing.Point(8, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(192, 97);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Movimento";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Mandato:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(72, 72);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(104, 20);
            this.textBox4.TabIndex = 3;
            this.textBox4.Tag = "unifiedtax.npay";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(112, 295);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(112, 20);
            this.textBox5.TabIndex = 11;
            this.textBox5.Tag = "unifiedtax.taxablenet?unifiedtaxview.taxablenet";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(16, 295);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 24);
            this.label4.TabIndex = 10;
            this.label4.Text = "Imponibile netto:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(21, 41);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 23);
            this.label17.TabIndex = 1;
            this.label17.Text = "Numero";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNum
            // 
            this.txtNum.Location = new System.Drawing.Point(92, 44);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(104, 20);
            this.txtNum.TabIndex = 5;
            this.txtNum.Tag = "unifiedtax.idunifiedf24ep";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtEserc);
            this.groupBox6.Controls.Add(this.label16);
            this.groupBox6.Controls.Add(this.txtNum);
            this.groupBox6.Controls.Add(this.label17);
            this.groupBox6.Location = new System.Drawing.Point(208, 108);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(216, 88);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "F24 EP";
            // 
            // txtEserc
            // 
            this.txtEserc.Location = new System.Drawing.Point(92, 18);
            this.txtEserc.Name = "txtEserc";
            this.txtEserc.Size = new System.Drawing.Size(104, 20);
            this.txtEserc.TabIndex = 4;
            this.txtEserc.Tag = "unifiedf24ep.ayear.year?unifiedtaxview.f24ep_ayear.year";
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(21, 16);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 23);
            this.label16.TabIndex = 3;
            this.label16.Text = "Esercizio";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtnbracket
            // 
            this.txtnbracket.Location = new System.Drawing.Point(144, 327);
            this.txtnbracket.Name = "txtnbracket";
            this.txtnbracket.Size = new System.Drawing.Size(80, 20);
            this.txtnbracket.TabIndex = 15;
            this.txtnbracket.Tag = "unifiedtax.nbracket?unifiedtaxview.nbracket";
            // 
            // labNumscaglione
            // 
            this.labNumscaglione.Location = new System.Drawing.Point(16, 335);
            this.labNumscaglione.Name = "labNumscaglione";
            this.labNumscaglione.Size = new System.Drawing.Size(104, 16);
            this.labNumscaglione.TabIndex = 14;
            this.labNumscaglione.Text = "Num. Scaglione";
            // 
            // txtDetrazioni
            // 
            this.txtDetrazioni.Location = new System.Drawing.Point(112, 359);
            this.txtDetrazioni.Name = "txtDetrazioni";
            this.txtDetrazioni.Size = new System.Drawing.Size(112, 20);
            this.txtDetrazioni.TabIndex = 17;
            this.txtDetrazioni.Tag = "unifiedtax.abatements?unifiedtaxview.abatements";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(112, 263);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(112, 20);
            this.textBox2.TabIndex = 7;
            this.textBox2.Tag = "unifiedtax.taxablegross?unifiedtaxview.taxablegross";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(16, 263);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(88, 16);
            this.label14.TabIndex = 6;
            this.label14.Text = "Imponibile lordo";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(16, 367);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(88, 16);
            this.label15.TabIndex = 16;
            this.label15.Text = "Detrazioni";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(16, 399);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 24);
            this.label10.TabIndex = 18;
            this.label10.Text = "Importo c/dip";
            // 
            // textBox18
            // 
            this.textBox18.Location = new System.Drawing.Point(112, 391);
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(112, 20);
            this.textBox18.TabIndex = 19;
            this.textBox18.Tag = "unifiedtax.employtax?unifiedtaxview.employtax";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(240, 399);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 24);
            this.label11.TabIndex = 20;
            this.label11.Text = "Importo c/ammin";
            // 
            // cmbBoxDepartment
            // 
            this.cmbBoxDepartment.DataSource = this.DS.dbdepartment;
            this.cmbBoxDepartment.DisplayMember = "description";
            this.cmbBoxDepartment.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmbBoxDepartment.Location = new System.Drawing.Point(85, 16);
            this.cmbBoxDepartment.Name = "cmbBoxDepartment";
            this.cmbBoxDepartment.Size = new System.Drawing.Size(384, 21);
            this.cmbBoxDepartment.TabIndex = 1;
            this.cmbBoxDepartment.Tag = "unifiedtax.iddbdepartment?unifiedtaxview.iddbdepartment";
            this.cmbBoxDepartment.ValueMember = "iddbdepartment";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.cmbBoxDepartment);
            this.groupBox8.Location = new System.Drawing.Point(7, 59);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(472, 48);
            this.groupBox8.TabIndex = 2;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Dipartimento";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(243, 263);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Data Competenza:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(348, 263);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(128, 20);
            this.textBox6.TabIndex = 9;
            this.textBox6.Tag = "unifiedtax.competencydate";
            // 
            // btnScollega
            // 
            this.btnScollega.Location = new System.Drawing.Point(300, 321);
            this.btnScollega.Name = "btnScollega";
            this.btnScollega.Size = new System.Drawing.Size(172, 26);
            this.btnScollega.TabIndex = 0;
            this.btnScollega.Text = "Scollega dettaglio dall\'F24EP";
            this.btnScollega.UseVisualStyleBackColor = true;
            this.btnScollega.Click += new System.EventHandler(this.btnScollega_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(385, 289);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(90, 20);
            this.textBox1.TabIndex = 13;
            this.textBox1.Tag = "unifiedtax.ayear.year";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(249, 286);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 23);
            this.label6.TabIndex = 12;
            this.label6.Text = "Anno Competenza";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gboxService
            // 
            this.gboxService.Controls.Add(this.label7);
            this.gboxService.Controls.Add(this.txtstop);
            this.gboxService.Controls.Add(this.label18);
            this.gboxService.Controls.Add(this.txtstart);
            this.gboxService.Location = new System.Drawing.Point(10, 525);
            this.gboxService.Name = "gboxService";
            this.gboxService.Size = new System.Drawing.Size(310, 53);
            this.gboxService.TabIndex = 24;
            this.gboxService.TabStop = false;
            this.gboxService.Text = "Prestazione";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(196, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 16);
            this.label7.TabIndex = 22;
            this.label7.Text = "Data Fine";
            // 
            // txtstop
            // 
            this.txtstop.Location = new System.Drawing.Point(196, 29);
            this.txtstop.Name = "txtstop";
            this.txtstop.Size = new System.Drawing.Size(100, 20);
            this.txtstop.TabIndex = 12;
            this.txtstop.Tag = "unifiedtax.servicestop";
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(69, 14);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(100, 16);
            this.label18.TabIndex = 20;
            this.label18.Text = "Data Inizio";
            // 
            // txtstart
            // 
            this.txtstart.Location = new System.Drawing.Point(69, 30);
            this.txtstart.Name = "txtstart";
            this.txtstart.Size = new System.Drawing.Size(100, 20);
            this.txtstart.TabIndex = 11;
            this.txtstart.Tag = "unifiedtax.servicestart";
            // 
            // Frm_unifiedtax_default
            // 
            this.ClientSize = new System.Drawing.Size(488, 621);
            this.Controls.Add(this.gboxService);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnScollega);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox18);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.txtDetrazioni);
            this.Controls.Add(this.labNumscaglione);
            this.Controls.Add(this.txtnbracket);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.textBox19);
            this.Name = "Frm_unifiedtax_default";
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.gboxService.ResumeLayout(false);
            this.gboxService.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        QueryHelper QHS;
        public void MetaData_AfterLink()
        {
            Meta = MetaData.GetMetaData(this);
            Meta.CanInsertCopy = false;
            Conn = Meta.Conn;
            QHS = Conn.GetQueryHelper();
            int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
            string filter = QHS.AppAnd(QHS.CmpEq("ymov", esercizio), QHS.CmpEq("ayear", esercizio));
            //GetData.SetStaticFilter(DS.unifiedtax, filter);
            Meta.StartFilter = filter;
        }

        public void MetaData_AfterClear() {
            txtEsercMov.Text = Meta.GetSys("esercizio").ToString();
            VisualizzabtnScollega();
        }

        public void MetaData_AfterFill() {
            Text = "Ritenute centralizzate";
            if (Meta.FirstFillForThisRow && Meta.EditMode){
                VisualizzabtnScollega();
            }
        }

        void VisualizzabtnScollega(){
            if (DS.unifiedtax.Rows.Count > 0 && (DS.unifiedtax.Rows[0].RowState == DataRowState.Unchanged))
            {
                DataRow Curr = DS.unifiedtax.Rows[0];
                if (Curr["idunifiedf24ep"] == DBNull.Value){
                    btnScollega.Enabled = false;
                }
                else{
                    btnScollega.Enabled = true;
                }
            }
            else
            {
                if (Meta.InsertMode || DS.unifiedtax.Rows.Count == 0)
                {
                    btnScollega.Enabled = false;
                    return;
                }
            }
        }

        private void btnScollega_Click(object sender, EventArgs e){
            if (show(this, "Si è deciso di scollegare il dettaglio della ritenuta dall'E24EP'.\r" +
                "Procedo a rimuovere il dettaglio?", "Avviso", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            DataRow Curr = DS.unifiedtax.Rows[0];
            Curr["idunifiedf24ep"] = DBNull.Value;
            txtNum.Text = "";
            txtEserc.Text = "";
        }
    }
}
