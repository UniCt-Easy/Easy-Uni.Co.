
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
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;
using System.Reflection;

namespace epaccvar_default {
    /// <summary>
    /// Summary description for Frm_epaccvardefault.
    /// </summary>
    public class Frm_epaccvardefault : MetaDataForm {
        public epaccvar_default.vistaForm DS;
        private System.Windows.Forms.GroupBox grpVariazione;
        private System.Windows.Forms.TextBox txtEsercVariazione;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNumVariazione;
        private System.Windows.Forms.GroupBox grpMovSpesa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEsercMovimento;
        private System.Windows.Forms.TextBox txtNumMovimento;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDataContabile;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtImporto;
        private System.Windows.Forms.RadioButton rdbAumento;
        private System.Windows.Forms.RadioButton rdbDiminuzione;
        public System.Windows.Forms.GroupBox grpImporto1;
        private string command;
        private bool InChiusura;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;
        MetaData Meta;
        private System.Windows.Forms.Button btnEpexp;
        public GroupBox grpImporto2;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private TextBox textBox2;
        public GroupBox grpImporto3;
        private RadioButton radioButton3;
        private RadioButton radioButton4;
        private TextBox textBox3;
        public GroupBox grpImporto4;
        private RadioButton radioButton5;
        private RadioButton radioButton6;
        private TextBox textBox4;
        public GroupBox grpImporto5;
        private RadioButton radioButton7;
        private RadioButton radioButton8;
        private TextBox textBox5;
        private TextBox txtTotale;
        private Label label7;
        private GroupBox groupBox5;
        private RadioButton radAccertamento;
        private RadioButton radPreaccertamento;
        private DataAccess Conn;

        public Frm_epaccvardefault() {
            InitializeComponent();
            InChiusura = false;
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing) {
            InChiusura = true;
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.grpVariazione = new System.Windows.Forms.GroupBox();
            this.txtNumVariazione = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEsercVariazione = new System.Windows.Forms.TextBox();
            this.grpMovSpesa = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.radAccertamento = new System.Windows.Forms.RadioButton();
            this.radPreaccertamento = new System.Windows.Forms.RadioButton();
            this.btnEpexp = new System.Windows.Forms.Button();
            this.txtNumMovimento = new System.Windows.Forms.TextBox();
            this.txtEsercMovimento = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDataContabile = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.grpImporto1 = new System.Windows.Forms.GroupBox();
            this.rdbDiminuzione = new System.Windows.Forms.RadioButton();
            this.rdbAumento = new System.Windows.Forms.RadioButton();
            this.txtImporto = new System.Windows.Forms.TextBox();
            this.grpImporto2 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.grpImporto3 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.grpImporto4 = new System.Windows.Forms.GroupBox();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.grpImporto5 = new System.Windows.Forms.GroupBox();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.DS = new epaccvar_default.vistaForm();
            this.txtTotale = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.grpVariazione.SuspendLayout();
            this.grpMovSpesa.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.grpImporto1.SuspendLayout();
            this.grpImporto2.SuspendLayout();
            this.grpImporto3.SuspendLayout();
            this.grpImporto4.SuspendLayout();
            this.grpImporto5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // grpVariazione
            // 
            this.grpVariazione.Controls.Add(this.txtNumVariazione);
            this.grpVariazione.Controls.Add(this.label2);
            this.grpVariazione.Controls.Add(this.label1);
            this.grpVariazione.Controls.Add(this.txtEsercVariazione);
            this.grpVariazione.Location = new System.Drawing.Point(16, 16);
            this.grpVariazione.Name = "grpVariazione";
            this.grpVariazione.Size = new System.Drawing.Size(168, 96);
            this.grpVariazione.TabIndex = 0;
            this.grpVariazione.TabStop = false;
            this.grpVariazione.Text = "Variazione";
            // 
            // txtNumVariazione
            // 
            this.txtNumVariazione.Location = new System.Drawing.Point(88, 56);
            this.txtNumVariazione.Name = "txtNumVariazione";
            this.txtNumVariazione.Size = new System.Drawing.Size(64, 20);
            this.txtNumVariazione.TabIndex = 2;
            this.txtNumVariazione.Tag = "epaccvar.nvar";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Numero";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Esercizio";
            // 
            // txtEsercVariazione
            // 
            this.txtEsercVariazione.Location = new System.Drawing.Point(88, 24);
            this.txtEsercVariazione.Name = "txtEsercVariazione";
            this.txtEsercVariazione.Size = new System.Drawing.Size(64, 20);
            this.txtEsercVariazione.TabIndex = 1;
            this.txtEsercVariazione.Tag = "epaccvar.yvar.year";
            // 
            // grpMovSpesa
            // 
            this.grpMovSpesa.Controls.Add(this.groupBox5);
            this.grpMovSpesa.Controls.Add(this.btnEpexp);
            this.grpMovSpesa.Controls.Add(this.txtNumMovimento);
            this.grpMovSpesa.Controls.Add(this.txtEsercMovimento);
            this.grpMovSpesa.Controls.Add(this.label4);
            this.grpMovSpesa.Controls.Add(this.label3);
            this.grpMovSpesa.Location = new System.Drawing.Point(192, 16);
            this.grpMovSpesa.Name = "grpMovSpesa";
            this.grpMovSpesa.Size = new System.Drawing.Size(388, 96);
            this.grpMovSpesa.TabIndex = 1;
            this.grpMovSpesa.TabStop = false;
            this.grpMovSpesa.Text = "Accertamento di budget";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.radAccertamento);
            this.groupBox5.Controls.Add(this.radPreaccertamento);
            this.groupBox5.Location = new System.Drawing.Point(155, 8);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(224, 36);
            this.groupBox5.TabIndex = 29;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Tipo";
            // 
            // radAccertamento
            // 
            this.radAccertamento.AutoSize = true;
            this.radAccertamento.Location = new System.Drawing.Point(127, 11);
            this.radAccertamento.Name = "radAccertamento";
            this.radAccertamento.Size = new System.Drawing.Size(91, 17);
            this.radAccertamento.TabIndex = 1;
            this.radAccertamento.TabStop = true;
            this.radAccertamento.Tag = "epaccview.nphase:2?epaccvarview.nphase:2";
            this.radAccertamento.Text = "Accertamento";
            this.radAccertamento.UseVisualStyleBackColor = true;
            // 
            // radPreaccertamento
            // 
            this.radPreaccertamento.AutoSize = true;
            this.radPreaccertamento.Location = new System.Drawing.Point(17, 12);
            this.radPreaccertamento.Name = "radPreaccertamento";
            this.radPreaccertamento.Size = new System.Drawing.Size(106, 17);
            this.radPreaccertamento.TabIndex = 0;
            this.radPreaccertamento.TabStop = true;
            this.radPreaccertamento.Tag = "epaccview.nphase:1?epaccvarview.nphase:1";
            this.radPreaccertamento.Text = "Preaccertamento";
            this.radPreaccertamento.UseVisualStyleBackColor = true;
            // 
            // btnEpexp
            // 
            this.btnEpexp.Location = new System.Drawing.Point(69, 15);
            this.btnEpexp.Name = "btnEpexp";
            this.btnEpexp.Size = new System.Drawing.Size(80, 24);
            this.btnEpexp.TabIndex = 1;
            this.btnEpexp.Tag = "choose.epaccview.default";
            this.btnEpexp.Text = "Scegli";
            // 
            // txtNumMovimento
            // 
            this.txtNumMovimento.Location = new System.Drawing.Point(120, 72);
            this.txtNumMovimento.Name = "txtNumMovimento";
            this.txtNumMovimento.Size = new System.Drawing.Size(80, 20);
            this.txtNumMovimento.TabIndex = 3;
            this.txtNumMovimento.Tag = "epaccview.nepacc?epaccvarview.nepacc";
            this.txtNumMovimento.Leave += new System.EventHandler(this.txtNumMovimento_Leave);
            // 
            // txtEsercMovimento
            // 
            this.txtEsercMovimento.Location = new System.Drawing.Point(120, 48);
            this.txtEsercMovimento.Name = "txtEsercMovimento";
            this.txtEsercMovimento.Size = new System.Drawing.Size(80, 20);
            this.txtEsercMovimento.TabIndex = 2;
            this.txtEsercMovimento.Tag = "epaccview.yepacc.year?epaccvarview.yepacc.year";
            this.txtEsercMovimento.Leave += new System.EventHandler(this.txtEsercMovimento_Leave);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(24, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Numero";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(24, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Esercizio";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.Location = new System.Drawing.Point(586, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "Data Contabile";
            // 
            // txtDataContabile
            // 
            this.txtDataContabile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDataContabile.Location = new System.Drawing.Point(586, 96);
            this.txtDataContabile.Name = "txtDataContabile";
            this.txtDataContabile.Size = new System.Drawing.Size(104, 20);
            this.txtDataContabile.TabIndex = 4;
            this.txtDataContabile.Tag = "epaccvar.adate";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(16, 136);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(666, 51);
            this.textBox1.TabIndex = 2;
            this.textBox1.Tag = "epaccvar.description";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(16, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(152, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Descrizione della Variazione";
            // 
            // grpImporto1
            // 
            this.grpImporto1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grpImporto1.Controls.Add(this.rdbDiminuzione);
            this.grpImporto1.Controls.Add(this.rdbAumento);
            this.grpImporto1.Controls.Add(this.txtImporto);
            this.grpImporto1.Location = new System.Drawing.Point(16, 202);
            this.grpImporto1.Name = "grpImporto1";
            this.grpImporto1.Size = new System.Drawing.Size(148, 88);
            this.grpImporto1.TabIndex = 3;
            this.grpImporto1.TabStop = false;
            this.grpImporto1.Tag = "epaccvar.amount.valuesigned";
            this.grpImporto1.Text = "Importo variazione anno";
            // 
            // rdbDiminuzione
            // 
            this.rdbDiminuzione.Location = new System.Drawing.Point(6, 40);
            this.rdbDiminuzione.Name = "rdbDiminuzione";
            this.rdbDiminuzione.Size = new System.Drawing.Size(104, 21);
            this.rdbDiminuzione.TabIndex = 3;
            this.rdbDiminuzione.Tag = "-";
            this.rdbDiminuzione.Text = "Diminuzione";
            // 
            // rdbAumento
            // 
            this.rdbAumento.Location = new System.Drawing.Point(6, 19);
            this.rdbAumento.Name = "rdbAumento";
            this.rdbAumento.Size = new System.Drawing.Size(104, 24);
            this.rdbAumento.TabIndex = 2;
            this.rdbAumento.Tag = "+";
            this.rdbAumento.Text = "Aumento";
            // 
            // txtImporto
            // 
            this.txtImporto.Location = new System.Drawing.Point(6, 62);
            this.txtImporto.Name = "txtImporto";
            this.txtImporto.Size = new System.Drawing.Size(104, 20);
            this.txtImporto.TabIndex = 1;
            this.txtImporto.Tag = "epaccvar.amount";
            this.txtImporto.TextChanged += new System.EventHandler(this.txtImporto_TextChanged);
            this.txtImporto.Leave += new System.EventHandler(this.txtImportoLeave);
            // 
            // grpImporto2
            // 
            this.grpImporto2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grpImporto2.Controls.Add(this.radioButton1);
            this.grpImporto2.Controls.Add(this.radioButton2);
            this.grpImporto2.Controls.Add(this.textBox2);
            this.grpImporto2.Location = new System.Drawing.Point(179, 202);
            this.grpImporto2.Name = "grpImporto2";
            this.grpImporto2.Size = new System.Drawing.Size(148, 88);
            this.grpImporto2.TabIndex = 6;
            this.grpImporto2.TabStop = false;
            this.grpImporto2.Tag = "epaccvar.amount2.valuesigned";
            this.grpImporto2.Text = "Importo variazione anno";
            // 
            // radioButton1
            // 
            this.radioButton1.Location = new System.Drawing.Point(6, 40);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(104, 21);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.Tag = "-";
            this.radioButton1.Text = "Diminuzione";
            // 
            // radioButton2
            // 
            this.radioButton2.Location = new System.Drawing.Point(6, 19);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(104, 24);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.Tag = "+";
            this.radioButton2.Text = "Aumento";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(6, 62);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(104, 20);
            this.textBox2.TabIndex = 1;
            this.textBox2.Tag = "epaccvar.amount2";
            this.textBox2.Leave += new System.EventHandler(this.txtImportoLeave);
            // 
            // grpImporto3
            // 
            this.grpImporto3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grpImporto3.Controls.Add(this.radioButton3);
            this.grpImporto3.Controls.Add(this.radioButton4);
            this.grpImporto3.Controls.Add(this.textBox3);
            this.grpImporto3.Location = new System.Drawing.Point(347, 202);
            this.grpImporto3.Name = "grpImporto3";
            this.grpImporto3.Size = new System.Drawing.Size(148, 88);
            this.grpImporto3.TabIndex = 7;
            this.grpImporto3.TabStop = false;
            this.grpImporto3.Tag = "epaccvar.amount3.valuesigned";
            this.grpImporto3.Text = "Importo variazione anno";
            // 
            // radioButton3
            // 
            this.radioButton3.Location = new System.Drawing.Point(6, 40);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(104, 21);
            this.radioButton3.TabIndex = 3;
            this.radioButton3.Tag = "-";
            this.radioButton3.Text = "Diminuzione";
            // 
            // radioButton4
            // 
            this.radioButton4.Location = new System.Drawing.Point(6, 19);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(104, 24);
            this.radioButton4.TabIndex = 2;
            this.radioButton4.Tag = "+";
            this.radioButton4.Text = "Aumento";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(6, 62);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(104, 20);
            this.textBox3.TabIndex = 1;
            this.textBox3.Tag = "epaccvar.amount3";
            this.textBox3.Leave += new System.EventHandler(this.txtImportoLeave);
            // 
            // grpImporto4
            // 
            this.grpImporto4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grpImporto4.Controls.Add(this.radioButton5);
            this.grpImporto4.Controls.Add(this.radioButton6);
            this.grpImporto4.Controls.Add(this.textBox4);
            this.grpImporto4.Location = new System.Drawing.Point(519, 202);
            this.grpImporto4.Name = "grpImporto4";
            this.grpImporto4.Size = new System.Drawing.Size(148, 88);
            this.grpImporto4.TabIndex = 8;
            this.grpImporto4.TabStop = false;
            this.grpImporto4.Tag = "epaccvar.amount3.valuesigned";
            this.grpImporto4.Text = "Importo variazione anno";
            // 
            // radioButton5
            // 
            this.radioButton5.Location = new System.Drawing.Point(6, 40);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(104, 21);
            this.radioButton5.TabIndex = 3;
            this.radioButton5.Tag = "-";
            this.radioButton5.Text = "Diminuzione";
            // 
            // radioButton6
            // 
            this.radioButton6.Location = new System.Drawing.Point(6, 19);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(104, 24);
            this.radioButton6.TabIndex = 2;
            this.radioButton6.Tag = "+";
            this.radioButton6.Text = "Aumento";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(6, 62);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(104, 20);
            this.textBox4.TabIndex = 1;
            this.textBox4.Tag = "epaccvar.amount4";
            this.textBox4.Leave += new System.EventHandler(this.txtImportoLeave);
            // 
            // grpImporto5
            // 
            this.grpImporto5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grpImporto5.Controls.Add(this.radioButton7);
            this.grpImporto5.Controls.Add(this.radioButton8);
            this.grpImporto5.Controls.Add(this.textBox5);
            this.grpImporto5.Location = new System.Drawing.Point(685, 202);
            this.grpImporto5.Name = "grpImporto5";
            this.grpImporto5.Size = new System.Drawing.Size(148, 88);
            this.grpImporto5.TabIndex = 9;
            this.grpImporto5.TabStop = false;
            this.grpImporto5.Tag = "epaccvar.amount5.valuesigned";
            this.grpImporto5.Text = "Importo variazione anno";
            // 
            // radioButton7
            // 
            this.radioButton7.Location = new System.Drawing.Point(6, 40);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(104, 21);
            this.radioButton7.TabIndex = 3;
            this.radioButton7.Tag = "-";
            this.radioButton7.Text = "Diminuzione";
            // 
            // radioButton8
            // 
            this.radioButton8.Location = new System.Drawing.Point(6, 19);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(104, 24);
            this.radioButton8.TabIndex = 2;
            this.radioButton8.Tag = "+";
            this.radioButton8.Text = "Aumento";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(6, 62);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(104, 20);
            this.textBox5.TabIndex = 1;
            this.textBox5.Tag = "epaccvar.amount5";
            this.textBox5.Leave += new System.EventHandler(this.txtImportoLeave);
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // txtTotale
            // 
            this.txtTotale.Location = new System.Drawing.Point(700, 167);
            this.txtTotale.Name = "txtTotale";
            this.txtTotale.ReadOnly = true;
            this.txtTotale.Size = new System.Drawing.Size(104, 20);
            this.txtTotale.TabIndex = 56;
            this.txtTotale.Tag = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(697, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 55;
            this.label7.Text = "Totale pluriennale";
            // 
            // Frm_epaccvardefault
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(984, 341);
            this.Controls.Add(this.txtTotale);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.grpImporto5);
            this.Controls.Add(this.grpImporto4);
            this.Controls.Add(this.grpImporto3);
            this.Controls.Add(this.grpImporto2);
            this.Controls.Add(this.grpImporto1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtDataContabile);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.grpMovSpesa);
            this.Controls.Add(this.grpVariazione);
            this.Name = "Frm_epaccvardefault";
            this.Text = "Frm_epaccvardefault";
            this.grpVariazione.ResumeLayout(false);
            this.grpVariazione.PerformLayout();
            this.grpMovSpesa.ResumeLayout(false);
            this.grpMovSpesa.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.grpImporto1.ResumeLayout(false);
            this.grpImporto1.PerformLayout();
            this.grpImporto2.ResumeLayout(false);
            this.grpImporto2.PerformLayout();
            this.grpImporto3.ResumeLayout(false);
            this.grpImporto3.PerformLayout();
            this.grpImporto4.ResumeLayout(false);
            this.grpImporto4.PerformLayout();
            this.grpImporto5.ResumeLayout(false);
            this.grpImporto5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        CQueryHelper QHC;
        QueryHelper QHS;
        public void MetaData_AfterLink() {
            string filteresercizio;
            Meta = MetaData.GetMetaData(this);
            this.Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
            filteresercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            command = "choose.epaccview.default";
            GetData.SetStaticFilter(DS.epaccview, filteresercizio);
            SetImportoName();
            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
        }


        object GetCtrlByName(string Name)
        {
            System.Reflection.FieldInfo Ctrl = this.GetType().GetField(Name);
            if (Ctrl == null)
                return null;
            return Ctrl.GetValue(this);
        }

        void SetImportoName()
        {
            int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
            for (int i = 1; i <= 5; i++)
            {
                GroupBox G = (GroupBox)GetCtrlByName("grpImporto" + i.ToString());
                int N = esercizio + i - 1;
                G.Text = G.Text.Replace("anno", N.ToString());
            }
        }
        public void MetaData_AfterClear() {
            txtEsercVariazione.Text = Meta.GetSys("esercizio").ToString();
            txtEsercVariazione.ReadOnly = false;
  
        }


        private void DoChooseCommand(Control sender) {
            string mycommand = command;
            string filter = Meta.myHelpForm.GetSpecificCondition(grpMovSpesa.Controls, "epaccview");

            if (filter != "")
                mycommand += "." + filter;
            if (!MetaData.Choose(this, mycommand)) {
                if (sender != null)
                    sender.Focus();
            }
        }

        public void MetaData_AfterFill() {
            txtEsercVariazione.ReadOnly = true;
            CalcolaTotale(false);
            Meta.canSave= false;
           
        }
        private void ClearSpesa(bool ClearEsercizio) {
            //causa errore dopo un getformdata
            txtNumMovimento.Text = "";
            if (ClearEsercizio)
                txtEsercMovimento.Text = "";
            if (Meta.IsEmpty)
                return;
            if (!Meta.InsertMode)
                return; //idpsesa can be changed only on insert!

            DS.epaccvar.Rows[0]["nvar"] = 0;
            DS.epaccvar.Rows[0]["yvar"] = 0;

        }

        private void txtEsercMovimento_Leave(object sender, System.EventArgs e) {
            if (InChiusura)
                return;
            if (Meta.EditMode)
                return;
            string esercspesa = txtEsercMovimento.Text.Trim();
            if (esercspesa == "") {
                MetaData.Choose(this, "choose.epaccview.unknown.clear");
                return;
            }

            //if txtEsercEntrata is not Empty:
            if (Meta.IsEmpty)
                return;
       

            if (DS.epaccview.Rows.Count > 0)
            {
                if (esercspesa == DS.epaccview.Rows[0]["yepacc"].ToString())
                    return;
                else
                {
                    ClearSpesa(false);
                    return;
                }
            }		


        }

        void CalcolaTotale(bool read)
        {
            if (Meta == null)
                return;
            if (Meta.IsEmpty)
                return;
            if (DS.epaccvar.Rows.Count == 0)
                return;
            if (read) Meta.GetFormData(true);
            DataRow R = DS.epaccvar.Rows[0];
            decimal totale = CfgFn.GetNoNullDecimal(R["amount"]);
            for (int i = 2; i <= 5; i++)
            {
                totale += CfgFn.GetNoNullDecimal(R["amount" + i.ToString()]);
            }
            txtTotale.Text = totale.ToString("c");
        }

        private void txtImportoLeave(object sender, EventArgs e)
        {
            CalcolaTotale(Meta.DrawStateIsDone);
        }

        private void txtNumMovimento_Leave(object sender, System.EventArgs e) {
            if (InChiusura)
                return;
            if (Meta.EditMode)
                return;
            if (txtNumMovimento.Text.Trim() != "") {
                DoChooseCommand((Control)sender);
                return;
            }
            if (Meta.IsEmpty) return;
            ClearSpesa(false);	
        }

        private void txtImporto_TextChanged(object sender, EventArgs e) {

        }

    }
}
