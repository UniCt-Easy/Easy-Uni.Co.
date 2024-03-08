
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


namespace upbcommessa_default {
    partial class frmupb_commessa {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
			this.btnRicalcola = new System.Windows.Forms.Button();
			this.btnGeneraEP = new System.Windows.Forms.Button();
			this.btnVisualizzaEP = new System.Windows.Forms.Button();
			this.labEP = new System.Windows.Forms.Label();
			this.btnVisualizzaPreimpegni = new System.Windows.Forms.Button();
			this.btnGeneraPreimpegni = new System.Windows.Forms.Button();
			this.btnGeneraEpExp = new System.Windows.Forms.Button();
			this.btnVisualizzaEpExp = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.txtEsercizio = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label38 = new System.Windows.Forms.Label();
			this.textBox13 = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.textBox11 = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.textBox9 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.textBox21 = new System.Windows.Forms.TextBox();
			this.label31 = new System.Windows.Forms.Label();
			this.textBox22 = new System.Windows.Forms.TextBox();
			this.label32 = new System.Windows.Forms.Label();
			this.textBox23 = new System.Windows.Forms.TextBox();
			this.label33 = new System.Windows.Forms.Label();
			this.textBox24 = new System.Windows.Forms.TextBox();
			this.label34 = new System.Windows.Forms.Label();
			this.textBox14 = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.textBox12 = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.textBox10 = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.gboxUPB = new System.Windows.Forms.GroupBox();
			this.txtAnnoFine = new System.Windows.Forms.TextBox();
			this.label24 = new System.Windows.Forms.Label();
			this.txtAnnoInizio = new System.Windows.Forms.TextBox();
			this.label23 = new System.Windows.Forms.Label();
			this.txtUPB = new System.Windows.Forms.TextBox();
			this.txtDescrUPB = new System.Windows.Forms.TextBox();
			this.btnUPBCode = new System.Windows.Forms.Button();
			this.cmbEPUPBKind = new System.Windows.Forms.ComboBox();
			this.DS = new upbcommessa_default.dsmeta();
			this.label1 = new System.Windows.Forms.Label();
			this.chkRiscontaAmmortamentiFuturi = new System.Windows.Forms.CheckBox();
			this.labelNoCommessaCompletata = new System.Windows.Forms.Label();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.gboxUPB.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.tabPage3.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnRicalcola
			// 
			this.btnRicalcola.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRicalcola.Location = new System.Drawing.Point(606, 149);
			this.btnRicalcola.Name = "btnRicalcola";
			this.btnRicalcola.Size = new System.Drawing.Size(179, 23);
			this.btnRicalcola.TabIndex = 0;
			this.btnRicalcola.Text = "Ricalcola valori";
			this.btnRicalcola.UseVisualStyleBackColor = true;
			this.btnRicalcola.Click += new System.EventHandler(this.btnRicalcola_Click);
			// 
			// btnGeneraEP
			// 
			this.btnGeneraEP.Location = new System.Drawing.Point(27, 80);
			this.btnGeneraEP.Name = "btnGeneraEP";
			this.btnGeneraEP.Size = new System.Drawing.Size(224, 23);
			this.btnGeneraEP.TabIndex = 6;
			this.btnGeneraEP.Text = "Genera le scritture in partita doppia";
			this.btnGeneraEP.UseVisualStyleBackColor = true;
			// 
			// btnVisualizzaEP
			// 
			this.btnVisualizzaEP.Location = new System.Drawing.Point(28, 44);
			this.btnVisualizzaEP.Name = "btnVisualizzaEP";
			this.btnVisualizzaEP.Size = new System.Drawing.Size(224, 23);
			this.btnVisualizzaEP.TabIndex = 5;
			this.btnVisualizzaEP.Text = "Visualizza le scritture in partita doppia";
			this.btnVisualizzaEP.UseVisualStyleBackColor = true;
			// 
			// labEP
			// 
			this.labEP.AutoSize = true;
			this.labEP.Location = new System.Drawing.Point(25, 15);
			this.labEP.Name = "labEP";
			this.labEP.Size = new System.Drawing.Size(237, 13);
			this.labEP.TabIndex = 4;
			this.labEP.Text = "Le scritture in partita doppia sono state generate.";
			// 
			// btnVisualizzaPreimpegni
			// 
			this.btnVisualizzaPreimpegni.Location = new System.Drawing.Point(480, 80);
			this.btnVisualizzaPreimpegni.Name = "btnVisualizzaPreimpegni";
			this.btnVisualizzaPreimpegni.Size = new System.Drawing.Size(168, 23);
			this.btnVisualizzaPreimpegni.TabIndex = 46;
			this.btnVisualizzaPreimpegni.TabStop = false;
			this.btnVisualizzaPreimpegni.Text = "Visualizza Preimpegni di Budget";
			// 
			// btnGeneraPreimpegni
			// 
			this.btnGeneraPreimpegni.Location = new System.Drawing.Point(480, 44);
			this.btnGeneraPreimpegni.Name = "btnGeneraPreimpegni";
			this.btnGeneraPreimpegni.Size = new System.Drawing.Size(168, 23);
			this.btnGeneraPreimpegni.TabIndex = 45;
			this.btnGeneraPreimpegni.TabStop = false;
			this.btnGeneraPreimpegni.Text = "Genera Preimpegni di Budget";
			// 
			// btnGeneraEpExp
			// 
			this.btnGeneraEpExp.Location = new System.Drawing.Point(306, 44);
			this.btnGeneraEpExp.Name = "btnGeneraEpExp";
			this.btnGeneraEpExp.Size = new System.Drawing.Size(168, 23);
			this.btnGeneraEpExp.TabIndex = 43;
			this.btnGeneraEpExp.TabStop = false;
			this.btnGeneraEpExp.Text = "Genera Impegni di Budget";
			// 
			// btnVisualizzaEpExp
			// 
			this.btnVisualizzaEpExp.Location = new System.Drawing.Point(306, 80);
			this.btnVisualizzaEpExp.Name = "btnVisualizzaEpExp";
			this.btnVisualizzaEpExp.Size = new System.Drawing.Size(168, 23);
			this.btnVisualizzaEpExp.TabIndex = 44;
			this.btnVisualizzaEpExp.TabStop = false;
			this.btnVisualizzaEpExp.Text = "Visualizza Impegni di Budget";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(802, 455);
			this.tabControl1.TabIndex = 49;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.txtEsercizio);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.groupBox2);
			this.tabPage1.Controls.Add(this.groupBox1);
			this.tabPage1.Controls.Add(this.gboxUPB);
			this.tabPage1.Controls.Add(this.cmbEPUPBKind);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.chkRiscontaAmmortamentiFuturi);
			this.tabPage1.Controls.Add(this.labelNoCommessaCompletata);
			this.tabPage1.Controls.Add(this.btnRicalcola);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(794, 429);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Informazioni su UPB";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// txtEsercizio
			// 
			this.txtEsercizio.Location = new System.Drawing.Point(82, 22);
			this.txtEsercizio.Name = "txtEsercizio";
			this.txtEsercizio.ReadOnly = true;
			this.txtEsercizio.Size = new System.Drawing.Size(69, 20);
			this.txtEsercizio.TabIndex = 68;
			this.txtEsercizio.Tag = "upbcommessa.ayear.year";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(30, 25);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(49, 13);
			this.label2.TabIndex = 67;
			this.label2.Text = "Esercizio";
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.textBox4);
			this.groupBox2.Controls.Add(this.label38);
			this.groupBox2.Controls.Add(this.textBox13);
			this.groupBox2.Controls.Add(this.label13);
			this.groupBox2.Controls.Add(this.textBox11);
			this.groupBox2.Controls.Add(this.label11);
			this.groupBox2.Controls.Add(this.textBox9);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.textBox8);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Location = new System.Drawing.Point(607, 177);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(176, 247);
			this.groupBox2.TabIndex = 66;
			this.groupBox2.TabStop = false;
			// 
			// textBox4
			// 
			this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox4.Location = new System.Drawing.Point(9, 218);
			this.textBox4.Name = "textBox4";
			this.textBox4.ReadOnly = true;
			this.textBox4.Size = new System.Drawing.Size(151, 20);
			this.textBox4.TabIndex = 61;
			this.textBox4.Tag = "upbcommessa.assetamortization";
			// 
			// label38
			// 
			this.label38.AutoSize = true;
			this.label38.Location = new System.Drawing.Point(6, 202);
			this.label38.Name = "label38";
			this.label38.Size = new System.Drawing.Size(131, 13);
			this.label38.TabIndex = 60;
			this.label38.Text = "Totale ammortamenti futuri";
			// 
			// textBox13
			// 
			this.textBox13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox13.Location = new System.Drawing.Point(9, 171);
			this.textBox13.Name = "textBox13";
			this.textBox13.ReadOnly = true;
			this.textBox13.Size = new System.Drawing.Size(151, 20);
			this.textBox13.TabIndex = 59;
			this.textBox13.Tag = "upbcommessa.accruals";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(6, 155);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(85, 13);
			this.label13.TabIndex = 58;
			this.label13.Text = "Totale ratei attivi";
			// 
			// textBox11
			// 
			this.textBox11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox11.Location = new System.Drawing.Point(9, 123);
			this.textBox11.Name = "textBox11";
			this.textBox11.ReadOnly = true;
			this.textBox11.Size = new System.Drawing.Size(151, 20);
			this.textBox11.TabIndex = 57;
			this.textBox11.Tag = "upbcommessa.reserve";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(6, 106);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(71, 13);
			this.label11.TabIndex = 56;
			this.label11.Text = "Totale riserve";
			// 
			// textBox9
			// 
			this.textBox9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox9.Location = new System.Drawing.Point(9, 73);
			this.textBox9.Name = "textBox9";
			this.textBox9.ReadOnly = true;
			this.textBox9.Size = new System.Drawing.Size(151, 20);
			this.textBox9.TabIndex = 55;
			this.textBox9.Tag = "upbcommessa.revenue";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 56);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(65, 13);
			this.label6.TabIndex = 54;
			this.label6.Text = "Totale ricavi";
			// 
			// textBox8
			// 
			this.textBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox8.Location = new System.Drawing.Point(9, 24);
			this.textBox8.Name = "textBox8";
			this.textBox8.ReadOnly = true;
			this.textBox8.Size = new System.Drawing.Size(151, 20);
			this.textBox8.TabIndex = 53;
			this.textBox8.Tag = "upbcommessa.cost";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 8);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(62, 13);
			this.label5.TabIndex = 52;
			this.label5.Text = "Totale costi";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.textBox21);
			this.groupBox1.Controls.Add(this.label31);
			this.groupBox1.Controls.Add(this.textBox22);
			this.groupBox1.Controls.Add(this.label32);
			this.groupBox1.Controls.Add(this.textBox23);
			this.groupBox1.Controls.Add(this.label33);
			this.groupBox1.Controls.Add(this.textBox24);
			this.groupBox1.Controls.Add(this.label34);
			this.groupBox1.Controls.Add(this.textBox14);
			this.groupBox1.Controls.Add(this.label14);
			this.groupBox1.Controls.Add(this.textBox12);
			this.groupBox1.Controls.Add(this.label12);
			this.groupBox1.Controls.Add(this.textBox10);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.textBox7);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Location = new System.Drawing.Point(26, 177);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(575, 203);
			this.groupBox1.TabIndex = 57;
			this.groupBox1.TabStop = false;
			// 
			// textBox21
			// 
			this.textBox21.Location = new System.Drawing.Point(296, 165);
			this.textBox21.Name = "textBox21";
			this.textBox21.ReadOnly = true;
			this.textBox21.Size = new System.Drawing.Size(263, 20);
			this.textBox21.TabIndex = 65;
			this.textBox21.Tag = "account_accruals_original.codeacc";
			// 
			// label31
			// 
			this.label31.AutoSize = true;
			this.label31.Location = new System.Drawing.Point(293, 149);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(88, 13);
			this.label31.TabIndex = 64;
			this.label31.Text = "Conto Ratei attivi";
			// 
			// textBox22
			// 
			this.textBox22.Location = new System.Drawing.Point(296, 116);
			this.textBox22.Name = "textBox22";
			this.textBox22.ReadOnly = true;
			this.textBox22.Size = new System.Drawing.Size(263, 20);
			this.textBox22.TabIndex = 63;
			this.textBox22.Tag = "account_deferredcost_original.codeacc";
			// 
			// label32
			// 
			this.label32.AutoSize = true;
			this.label32.Location = new System.Drawing.Point(293, 100);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(111, 13);
			this.label32.TabIndex = 62;
			this.label32.Text = "Conto Risconti passivi";
			// 
			// textBox23
			// 
			this.textBox23.Location = new System.Drawing.Point(296, 77);
			this.textBox23.Name = "textBox23";
			this.textBox23.ReadOnly = true;
			this.textBox23.Size = new System.Drawing.Size(263, 20);
			this.textBox23.TabIndex = 61;
			this.textBox23.Tag = "account_revenue_original.codeacc";
			// 
			// label33
			// 
			this.label33.AutoSize = true;
			this.label33.Location = new System.Drawing.Point(293, 61);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(72, 13);
			this.label33.TabIndex = 60;
			this.label33.Text = "Conto Ricavo";
			// 
			// textBox24
			// 
			this.textBox24.Location = new System.Drawing.Point(296, 28);
			this.textBox24.Name = "textBox24";
			this.textBox24.ReadOnly = true;
			this.textBox24.Size = new System.Drawing.Size(263, 20);
			this.textBox24.TabIndex = 59;
			this.textBox24.Tag = "account_cost_original.codeacc";
			// 
			// label34
			// 
			this.label34.AutoSize = true;
			this.label34.Location = new System.Drawing.Point(293, 12);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(65, 13);
			this.label34.TabIndex = 58;
			this.label34.Text = "Conto Costo";
			// 
			// textBox14
			// 
			this.textBox14.Location = new System.Drawing.Point(18, 165);
			this.textBox14.Name = "textBox14";
			this.textBox14.ReadOnly = true;
			this.textBox14.Size = new System.Drawing.Size(263, 20);
			this.textBox14.TabIndex = 57;
			this.textBox14.Tag = "accmotive_accruals_original.codemotive";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(15, 149);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(98, 13);
			this.label14.TabIndex = 56;
			this.label14.Text = "Causale Ratei attivi";
			// 
			// textBox12
			// 
			this.textBox12.Location = new System.Drawing.Point(18, 116);
			this.textBox12.Name = "textBox12";
			this.textBox12.ReadOnly = true;
			this.textBox12.Size = new System.Drawing.Size(263, 20);
			this.textBox12.TabIndex = 55;
			this.textBox12.Tag = "accmotive_deferredcost_original.codemotive";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(15, 100);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(121, 13);
			this.label12.TabIndex = 54;
			this.label12.Text = "Causale Risconti passivi";
			// 
			// textBox10
			// 
			this.textBox10.Location = new System.Drawing.Point(18, 77);
			this.textBox10.Name = "textBox10";
			this.textBox10.ReadOnly = true;
			this.textBox10.Size = new System.Drawing.Size(263, 20);
			this.textBox10.TabIndex = 53;
			this.textBox10.Tag = "accmotive_revenue_original.codemotive";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(15, 61);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(82, 13);
			this.label10.TabIndex = 52;
			this.label10.Text = "Causale Ricavo";
			// 
			// textBox7
			// 
			this.textBox7.Location = new System.Drawing.Point(18, 28);
			this.textBox7.Name = "textBox7";
			this.textBox7.ReadOnly = true;
			this.textBox7.Size = new System.Drawing.Size(263, 20);
			this.textBox7.TabIndex = 51;
			this.textBox7.Tag = "accmotive_cost_original.codemotive";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(15, 12);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(75, 13);
			this.label4.TabIndex = 50;
			this.label4.Text = "Causale Costo";
			// 
			// gboxUPB
			// 
			this.gboxUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxUPB.Controls.Add(this.txtAnnoFine);
			this.gboxUPB.Controls.Add(this.label24);
			this.gboxUPB.Controls.Add(this.txtAnnoInizio);
			this.gboxUPB.Controls.Add(this.label23);
			this.gboxUPB.Controls.Add(this.txtUPB);
			this.gboxUPB.Controls.Add(this.txtDescrUPB);
			this.gboxUPB.Controls.Add(this.btnUPBCode);
			this.gboxUPB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.gboxUPB.Location = new System.Drawing.Point(27, 51);
			this.gboxUPB.Name = "gboxUPB";
			this.gboxUPB.Size = new System.Drawing.Size(758, 89);
			this.gboxUPB.TabIndex = 56;
			this.gboxUPB.TabStop = false;
			this.gboxUPB.Tag = "AutoChoose.txtUPB.limitespesa.(active=\'S\' )";
			// 
			// txtAnnoFine
			// 
			this.txtAnnoFine.Location = new System.Drawing.Point(682, 45);
			this.txtAnnoFine.Name = "txtAnnoFine";
			this.txtAnnoFine.ReadOnly = true;
			this.txtAnnoFine.Size = new System.Drawing.Size(71, 20);
			this.txtAnnoFine.TabIndex = 35;
			this.txtAnnoFine.Tag = "upbcommessa.yearstop.year";
			// 
			// label24
			// 
			this.label24.AutoSize = true;
			this.label24.Location = new System.Drawing.Point(618, 48);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(52, 13);
			this.label24.TabIndex = 34;
			this.label24.Text = "Anno fine";
			// 
			// txtAnnoInizio
			// 
			this.txtAnnoInizio.Location = new System.Drawing.Point(682, 19);
			this.txtAnnoInizio.Name = "txtAnnoInizio";
			this.txtAnnoInizio.ReadOnly = true;
			this.txtAnnoInizio.Size = new System.Drawing.Size(71, 20);
			this.txtAnnoInizio.TabIndex = 33;
			this.txtAnnoInizio.Tag = "upbcommessa.yearstart.year";
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.Location = new System.Drawing.Point(618, 22);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(58, 13);
			this.label23.TabIndex = 32;
			this.label23.Text = "Anno inizio";
			// 
			// txtUPB
			// 
			this.txtUPB.Location = new System.Drawing.Point(11, 60);
			this.txtUPB.Name = "txtUPB";
			this.txtUPB.Size = new System.Drawing.Size(603, 20);
			this.txtUPB.TabIndex = 5;
			this.txtUPB.Tag = "upb.codeupb?x";
			// 
			// txtDescrUPB
			// 
			this.txtDescrUPB.Location = new System.Drawing.Point(146, 10);
			this.txtDescrUPB.Multiline = true;
			this.txtDescrUPB.Name = "txtDescrUPB";
			this.txtDescrUPB.ReadOnly = true;
			this.txtDescrUPB.Size = new System.Drawing.Size(467, 44);
			this.txtDescrUPB.TabIndex = 4;
			this.txtDescrUPB.TabStop = false;
			this.txtDescrUPB.Tag = "upb.title";
			// 
			// btnUPBCode
			// 
			this.btnUPBCode.BackColor = System.Drawing.SystemColors.Control;
			this.btnUPBCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnUPBCode.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnUPBCode.Location = new System.Drawing.Point(11, 34);
			this.btnUPBCode.Name = "btnUPBCode";
			this.btnUPBCode.Size = new System.Drawing.Size(112, 20);
			this.btnUPBCode.TabIndex = 2;
			this.btnUPBCode.TabStop = false;
			this.btnUPBCode.Tag = "manage.upb.tree";
			this.btnUPBCode.Text = "UPB";
			this.btnUPBCode.UseVisualStyleBackColor = false;
			// 
			// cmbEPUPBKind
			// 
			this.cmbEPUPBKind.DataSource = this.DS.epupbkind_original;
			this.cmbEPUPBKind.DisplayMember = "title";
			this.cmbEPUPBKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbEPUPBKind.Location = new System.Drawing.Point(241, 150);
			this.cmbEPUPBKind.Name = "cmbEPUPBKind";
			this.cmbEPUPBKind.Size = new System.Drawing.Size(360, 21);
			this.cmbEPUPBKind.TabIndex = 55;
			this.cmbEPUPBKind.Tag = "epupbkind_original.idepupbkind?upbcommessaview.idepupbkind";
			this.cmbEPUPBKind.ValueMember = "idepupbkind";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(23, 155);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(212, 13);
			this.label1.TabIndex = 54;
			this.label1.Text = "Tipo UPB ai fini dell\'economico patrimoniale";
			// 
			// chkRiscontaAmmortamentiFuturi
			// 
			this.chkRiscontaAmmortamentiFuturi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.chkRiscontaAmmortamentiFuturi.AutoSize = true;
			this.chkRiscontaAmmortamentiFuturi.Enabled = false;
			this.chkRiscontaAmmortamentiFuturi.Location = new System.Drawing.Point(624, 13);
			this.chkRiscontaAmmortamentiFuturi.Name = "chkRiscontaAmmortamentiFuturi";
			this.chkRiscontaAmmortamentiFuturi.Size = new System.Drawing.Size(162, 17);
			this.chkRiscontaAmmortamentiFuturi.TabIndex = 53;
			this.chkRiscontaAmmortamentiFuturi.Text = "Risconta ammortamenti futuri";
			this.chkRiscontaAmmortamentiFuturi.UseVisualStyleBackColor = true;
			this.chkRiscontaAmmortamentiFuturi.Visible = false;
			// 
			// labelNoCommessaCompletata
			// 
			this.labelNoCommessaCompletata.AutoSize = true;
			this.labelNoCommessaCompletata.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelNoCommessaCompletata.ForeColor = System.Drawing.Color.Silver;
			this.labelNoCommessaCompletata.Location = new System.Drawing.Point(29, 397);
			this.labelNoCommessaCompletata.Name = "labelNoCommessaCompletata";
			this.labelNoCommessaCompletata.Size = new System.Drawing.Size(0, 13);
			this.labelNoCommessaCompletata.TabIndex = 52;
			this.labelNoCommessaCompletata.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.labEP);
			this.tabPage3.Controls.Add(this.btnVisualizzaPreimpegni);
			this.tabPage3.Controls.Add(this.btnVisualizzaEP);
			this.tabPage3.Controls.Add(this.btnGeneraPreimpegni);
			this.tabPage3.Controls.Add(this.btnGeneraEP);
			this.tabPage3.Controls.Add(this.btnGeneraEpExp);
			this.tabPage3.Controls.Add(this.btnVisualizzaEpExp);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(794, 429);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "EP";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// frmupb_commessa
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(802, 455);
			this.Controls.Add(this.tabControl1);
			this.Name = "frmupb_commessa";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Integrazione commessa completata";
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.gboxUPB.ResumeLayout(false);
			this.gboxUPB.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        public upbcommessa_default.dsmeta DS;
        private System.Windows.Forms.Button btnRicalcola;
        private System.Windows.Forms.Button btnGeneraEP;
        private System.Windows.Forms.Button btnVisualizzaEP;
        private System.Windows.Forms.Label labEP;
        private System.Windows.Forms.Button btnVisualizzaPreimpegni;
        private System.Windows.Forms.Button btnGeneraPreimpegni;
        private System.Windows.Forms.Button btnGeneraEpExp;
        private System.Windows.Forms.Button btnVisualizzaEpExp;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Label labelNoCommessaCompletata;
		private System.Windows.Forms.CheckBox chkRiscontaAmmortamentiFuturi;
		private System.Windows.Forms.ComboBox cmbEPUPBKind;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox gboxUPB;
		public System.Windows.Forms.TextBox txtUPB;
		private System.Windows.Forms.TextBox txtDescrUPB;
		private System.Windows.Forms.Button btnUPBCode;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox textBox21;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.TextBox textBox22;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.TextBox textBox23;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.TextBox textBox24;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.TextBox textBox14;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox textBox12;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox textBox10;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.TextBox textBox13;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox textBox11;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox textBox9;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBox8;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtAnnoFine;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.TextBox txtAnnoInizio;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.TextBox txtEsercizio;
		private System.Windows.Forms.Label label2;
	}
}

