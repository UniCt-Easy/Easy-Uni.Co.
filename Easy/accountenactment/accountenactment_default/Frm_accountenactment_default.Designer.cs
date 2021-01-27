
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


namespace accountenactment_default {
    partial class Frm_accountenactment_default {
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageVariazioni = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnModifica = new System.Windows.Forms.Button();
            this.dgrVariazioni = new System.Windows.Forms.DataGrid();
            this.btnScollega = new System.Windows.Forms.Button();
            this.btnCollega = new System.Windows.Forms.Button();
            this.tabPageAttributi = new System.Windows.Forms.TabPage();
            this.gboxclass05 = new System.Windows.Forms.GroupBox();
            this.txtCodice05 = new System.Windows.Forms.TextBox();
            this.btnCodice05 = new System.Windows.Forms.Button();
            this.txtDenom05 = new System.Windows.Forms.TextBox();
            this.gboxclass04 = new System.Windows.Forms.GroupBox();
            this.txtCodice04 = new System.Windows.Forms.TextBox();
            this.btnCodice04 = new System.Windows.Forms.Button();
            this.txtDenom04 = new System.Windows.Forms.TextBox();
            this.gboxclass03 = new System.Windows.Forms.GroupBox();
            this.txtCodice03 = new System.Windows.Forms.TextBox();
            this.btnCodice03 = new System.Windows.Forms.Button();
            this.txtDenom03 = new System.Windows.Forms.TextBox();
            this.gboxclass02 = new System.Windows.Forms.GroupBox();
            this.txtCodice02 = new System.Windows.Forms.TextBox();
            this.btnCodice02 = new System.Windows.Forms.Button();
            this.txtDenom02 = new System.Windows.Forms.TextBox();
            this.gboxclass01 = new System.Windows.Forms.GroupBox();
            this.txtCodice01 = new System.Windows.Forms.TextBox();
            this.btnCodice01 = new System.Windows.Forms.Button();
            this.txtDenom01 = new System.Windows.Forms.TextBox();
            this.btnWait = new System.Windows.Forms.Button();
            this.btnApprova = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDataContabile = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNumeroDocumento = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEsercizioDocumento = new System.Windows.Forms.TextBox();
            this.gboxStato = new System.Windows.Forms.GroupBox();
            this.rdbInAttesa = new System.Windows.Forms.RadioButton();
            this.rdbAnnullato = new System.Windows.Forms.RadioButton();
            this.rdbApprovato = new System.Windows.Forms.RadioButton();
            this.DS = new accountenactment_default.vistaForm();
            this.tabControl1.SuspendLayout();
            this.tabPageVariazioni.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrVariazioni)).BeginInit();
            this.tabPageAttributi.SuspendLayout();
            this.gboxclass05.SuspendLayout();
            this.gboxclass04.SuspendLayout();
            this.gboxclass03.SuspendLayout();
            this.gboxclass02.SuspendLayout();
            this.gboxclass01.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gboxStato.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageVariazioni);
            this.tabControl1.Controls.Add(this.tabPageAttributi);
            this.tabControl1.Location = new System.Drawing.Point(11, 227);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(778, 323);
            this.tabControl1.TabIndex = 120;
            // 
            // tabPageVariazioni
            // 
            this.tabPageVariazioni.Controls.Add(this.groupBox2);
            this.tabPageVariazioni.Location = new System.Drawing.Point(4, 22);
            this.tabPageVariazioni.Name = "tabPageVariazioni";
            this.tabPageVariazioni.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageVariazioni.Size = new System.Drawing.Size(770, 297);
            this.tabPageVariazioni.TabIndex = 0;
            this.tabPageVariazioni.Text = "Variazioni";
            this.tabPageVariazioni.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnModifica);
            this.groupBox2.Controls.Add(this.dgrVariazioni);
            this.groupBox2.Controls.Add(this.btnScollega);
            this.groupBox2.Controls.Add(this.btnCollega);
            this.groupBox2.Location = new System.Drawing.Point(13, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(751, 278);
            this.groupBox2.TabIndex = 102;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Variazioni di Bilancio inserite nell\'Atto";
            // 
            // btnModifica
            // 
            this.btnModifica.Location = new System.Drawing.Point(8, 88);
            this.btnModifica.Name = "btnModifica";
            this.btnModifica.Size = new System.Drawing.Size(75, 23);
            this.btnModifica.TabIndex = 5;
            this.btnModifica.Text = "Modifica...";
            this.btnModifica.Click += new System.EventHandler(this.btnModifica_Click);
            // 
            // dgrVariazioni
            // 
            this.dgrVariazioni.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrVariazioni.DataMember = "";
            this.dgrVariazioni.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgrVariazioni.Location = new System.Drawing.Point(96, 16);
            this.dgrVariazioni.Name = "dgrVariazioni";
            this.dgrVariazioni.Size = new System.Drawing.Size(647, 254);
            this.dgrVariazioni.TabIndex = 3;
            this.dgrVariazioni.TabStop = false;
            this.dgrVariazioni.Tag = "accountvarview.documentocollegato";
            // 
            // btnScollega
            // 
            this.btnScollega.Location = new System.Drawing.Point(8, 56);
            this.btnScollega.Name = "btnScollega";
            this.btnScollega.Size = new System.Drawing.Size(75, 23);
            this.btnScollega.TabIndex = 2;
            this.btnScollega.Tag = "";
            this.btnScollega.Text = "Rimuovi";
            this.btnScollega.Click += new System.EventHandler(this.btnScollega_Click);
            // 
            // btnCollega
            // 
            this.btnCollega.Location = new System.Drawing.Point(8, 24);
            this.btnCollega.Name = "btnCollega";
            this.btnCollega.Size = new System.Drawing.Size(75, 23);
            this.btnCollega.TabIndex = 1;
            this.btnCollega.Tag = "";
            this.btnCollega.Text = "Inserisci";
            this.btnCollega.Click += new System.EventHandler(this.btnCollega_Click);
            // 
            // tabPageAttributi
            // 
            this.tabPageAttributi.Controls.Add(this.gboxclass05);
            this.tabPageAttributi.Controls.Add(this.gboxclass04);
            this.tabPageAttributi.Controls.Add(this.gboxclass03);
            this.tabPageAttributi.Controls.Add(this.gboxclass02);
            this.tabPageAttributi.Controls.Add(this.gboxclass01);
            this.tabPageAttributi.Location = new System.Drawing.Point(4, 22);
            this.tabPageAttributi.Name = "tabPageAttributi";
            this.tabPageAttributi.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAttributi.Size = new System.Drawing.Size(770, 297);
            this.tabPageAttributi.TabIndex = 1;
            this.tabPageAttributi.Text = "Attributi";
            this.tabPageAttributi.UseVisualStyleBackColor = true;
            // 
            // gboxclass05
            // 
            this.gboxclass05.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxclass05.Controls.Add(this.txtCodice05);
            this.gboxclass05.Controls.Add(this.btnCodice05);
            this.gboxclass05.Controls.Add(this.txtDenom05);
            this.gboxclass05.Location = new System.Drawing.Point(387, 108);
            this.gboxclass05.Name = "gboxclass05";
            this.gboxclass05.Size = new System.Drawing.Size(370, 82);
            this.gboxclass05.TabIndex = 26;
            this.gboxclass05.TabStop = false;
            this.gboxclass05.Tag = "";
            this.gboxclass05.Text = "Classificazione 5";
            // 
            // txtCodice05
            // 
            this.txtCodice05.Location = new System.Drawing.Point(9, 55);
            this.txtCodice05.Name = "txtCodice05";
            this.txtCodice05.Size = new System.Drawing.Size(337, 20);
            this.txtCodice05.TabIndex = 6;
            // 
            // btnCodice05
            // 
            this.btnCodice05.Location = new System.Drawing.Point(8, 26);
            this.btnCodice05.Name = "btnCodice05";
            this.btnCodice05.Size = new System.Drawing.Size(88, 23);
            this.btnCodice05.TabIndex = 4;
            this.btnCodice05.Tag = "manage.sorting05.tree";
            this.btnCodice05.Text = "Codice";
            this.btnCodice05.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom05
            // 
            this.txtDenom05.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom05.Location = new System.Drawing.Point(123, 8);
            this.txtDenom05.Multiline = true;
            this.txtDenom05.Name = "txtDenom05";
            this.txtDenom05.ReadOnly = true;
            this.txtDenom05.Size = new System.Drawing.Size(223, 41);
            this.txtDenom05.TabIndex = 3;
            this.txtDenom05.TabStop = false;
            this.txtDenom05.Tag = "sorting05.description";
            // 
            // gboxclass04
            // 
            this.gboxclass04.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxclass04.Controls.Add(this.txtCodice04);
            this.gboxclass04.Controls.Add(this.btnCodice04);
            this.gboxclass04.Controls.Add(this.txtDenom04);
            this.gboxclass04.Location = new System.Drawing.Point(387, 18);
            this.gboxclass04.Name = "gboxclass04";
            this.gboxclass04.Size = new System.Drawing.Size(370, 86);
            this.gboxclass04.TabIndex = 25;
            this.gboxclass04.TabStop = false;
            this.gboxclass04.Tag = "";
            this.gboxclass04.Text = "Classificazione 4";
            // 
            // txtCodice04
            // 
            this.txtCodice04.Location = new System.Drawing.Point(6, 60);
            this.txtCodice04.Name = "txtCodice04";
            this.txtCodice04.Size = new System.Drawing.Size(340, 20);
            this.txtCodice04.TabIndex = 6;
            // 
            // btnCodice04
            // 
            this.btnCodice04.Location = new System.Drawing.Point(6, 31);
            this.btnCodice04.Name = "btnCodice04";
            this.btnCodice04.Size = new System.Drawing.Size(88, 23);
            this.btnCodice04.TabIndex = 4;
            this.btnCodice04.Tag = "manage.sorting04.tree";
            this.btnCodice04.Text = "Codice";
            this.btnCodice04.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom04
            // 
            this.txtDenom04.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom04.Location = new System.Drawing.Point(123, 6);
            this.txtDenom04.Multiline = true;
            this.txtDenom04.Name = "txtDenom04";
            this.txtDenom04.ReadOnly = true;
            this.txtDenom04.Size = new System.Drawing.Size(223, 50);
            this.txtDenom04.TabIndex = 3;
            this.txtDenom04.TabStop = false;
            this.txtDenom04.Tag = "sorting04.description";
            // 
            // gboxclass03
            // 
            this.gboxclass03.Controls.Add(this.txtCodice03);
            this.gboxclass03.Controls.Add(this.btnCodice03);
            this.gboxclass03.Controls.Add(this.txtDenom03);
            this.gboxclass03.Location = new System.Drawing.Point(8, 192);
            this.gboxclass03.Name = "gboxclass03";
            this.gboxclass03.Size = new System.Drawing.Size(364, 88);
            this.gboxclass03.TabIndex = 23;
            this.gboxclass03.TabStop = false;
            this.gboxclass03.Tag = "";
            this.gboxclass03.Text = "Classificazione 3";
            // 
            // txtCodice03
            // 
            this.txtCodice03.Location = new System.Drawing.Point(9, 62);
            this.txtCodice03.Name = "txtCodice03";
            this.txtCodice03.Size = new System.Drawing.Size(327, 20);
            this.txtCodice03.TabIndex = 6;
            // 
            // btnCodice03
            // 
            this.btnCodice03.Location = new System.Drawing.Point(9, 35);
            this.btnCodice03.Name = "btnCodice03";
            this.btnCodice03.Size = new System.Drawing.Size(88, 23);
            this.btnCodice03.TabIndex = 4;
            this.btnCodice03.Tag = "manage.sorting03.tree";
            this.btnCodice03.Text = "Codice";
            this.btnCodice03.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom03
            // 
            this.txtDenom03.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom03.Location = new System.Drawing.Point(126, 8);
            this.txtDenom03.Multiline = true;
            this.txtDenom03.Name = "txtDenom03";
            this.txtDenom03.ReadOnly = true;
            this.txtDenom03.Size = new System.Drawing.Size(210, 50);
            this.txtDenom03.TabIndex = 3;
            this.txtDenom03.TabStop = false;
            this.txtDenom03.Tag = "sorting03.description";
            // 
            // gboxclass02
            // 
            this.gboxclass02.Controls.Add(this.txtCodice02);
            this.gboxclass02.Controls.Add(this.btnCodice02);
            this.gboxclass02.Controls.Add(this.txtDenom02);
            this.gboxclass02.Location = new System.Drawing.Point(9, 105);
            this.gboxclass02.Name = "gboxclass02";
            this.gboxclass02.Size = new System.Drawing.Size(364, 88);
            this.gboxclass02.TabIndex = 24;
            this.gboxclass02.TabStop = false;
            this.gboxclass02.Tag = "";
            this.gboxclass02.Text = "Classificazione 2";
            // 
            // txtCodice02
            // 
            this.txtCodice02.Location = new System.Drawing.Point(6, 61);
            this.txtCodice02.Name = "txtCodice02";
            this.txtCodice02.Size = new System.Drawing.Size(332, 20);
            this.txtCodice02.TabIndex = 6;
            // 
            // btnCodice02
            // 
            this.btnCodice02.Location = new System.Drawing.Point(8, 32);
            this.btnCodice02.Name = "btnCodice02";
            this.btnCodice02.Size = new System.Drawing.Size(88, 23);
            this.btnCodice02.TabIndex = 4;
            this.btnCodice02.Tag = "manage.sorting02.tree";
            this.btnCodice02.Text = "Codice";
            this.btnCodice02.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom02
            // 
            this.txtDenom02.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom02.Location = new System.Drawing.Point(126, 6);
            this.txtDenom02.Multiline = true;
            this.txtDenom02.Name = "txtDenom02";
            this.txtDenom02.ReadOnly = true;
            this.txtDenom02.Size = new System.Drawing.Size(212, 52);
            this.txtDenom02.TabIndex = 3;
            this.txtDenom02.TabStop = false;
            this.txtDenom02.Tag = "sorting02.description";
            // 
            // gboxclass01
            // 
            this.gboxclass01.Controls.Add(this.txtCodice01);
            this.gboxclass01.Controls.Add(this.btnCodice01);
            this.gboxclass01.Controls.Add(this.txtDenom01);
            this.gboxclass01.Location = new System.Drawing.Point(9, 16);
            this.gboxclass01.Name = "gboxclass01";
            this.gboxclass01.Size = new System.Drawing.Size(364, 88);
            this.gboxclass01.TabIndex = 22;
            this.gboxclass01.TabStop = false;
            this.gboxclass01.Tag = "";
            this.gboxclass01.Text = "Classificazione 1";
            // 
            // txtCodice01
            // 
            this.txtCodice01.Location = new System.Drawing.Point(6, 62);
            this.txtCodice01.Name = "txtCodice01";
            this.txtCodice01.Size = new System.Drawing.Size(332, 20);
            this.txtCodice01.TabIndex = 5;
            // 
            // btnCodice01
            // 
            this.btnCodice01.Location = new System.Drawing.Point(6, 33);
            this.btnCodice01.Name = "btnCodice01";
            this.btnCodice01.Size = new System.Drawing.Size(88, 23);
            this.btnCodice01.TabIndex = 4;
            this.btnCodice01.Tag = "manage.sorting01.tree";
            this.btnCodice01.Text = "Codice";
            this.btnCodice01.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom01
            // 
            this.txtDenom01.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom01.Location = new System.Drawing.Point(126, 8);
            this.txtDenom01.Multiline = true;
            this.txtDenom01.Name = "txtDenom01";
            this.txtDenom01.ReadOnly = true;
            this.txtDenom01.Size = new System.Drawing.Size(212, 52);
            this.txtDenom01.TabIndex = 3;
            this.txtDenom01.TabStop = false;
            this.txtDenom01.Tag = "sorting01.description";
            // 
            // btnWait
            // 
            this.btnWait.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWait.Location = new System.Drawing.Point(674, 20);
            this.btnWait.Name = "btnWait";
            this.btnWait.Size = new System.Drawing.Size(107, 23);
            this.btnWait.TabIndex = 119;
            this.btnWait.Tag = "";
            this.btnWait.Text = "Rimetti in attesa";
            this.btnWait.Click += new System.EventHandler(this.btnWait_Click);
            // 
            // btnApprova
            // 
            this.btnApprova.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApprova.Location = new System.Drawing.Point(674, 51);
            this.btnApprova.Name = "btnApprova";
            this.btnApprova.Size = new System.Drawing.Size(107, 23);
            this.btnApprova.TabIndex = 118;
            this.btnApprova.Tag = "";
            this.btnApprova.Text = "Approva l\'atto";
            this.btnApprova.Click += new System.EventHandler(this.btnApprova_Click);
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.Location = new System.Drawing.Point(674, 83);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(107, 23);
            this.btnAnnulla.TabIndex = 117;
            this.btnAnnulla.Tag = "";
            this.btnAnnulla.Text = "Annulla l\'atto";
            this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizione.Location = new System.Drawing.Point(12, 141);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(777, 54);
            this.txtDescrizione.TabIndex = 115;
            this.txtDescrizione.Tag = "accountenactment.description";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(9, 122);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 16);
            this.label8.TabIndex = 116;
            this.label8.Text = "Descrizione:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.Location = new System.Drawing.Point(565, 202);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 16);
            this.label9.TabIndex = 114;
            this.label9.Text = "Data approvazione:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDataContabile
            // 
            this.txtDataContabile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDataContabile.Location = new System.Drawing.Point(694, 201);
            this.txtDataContabile.Name = "txtDataContabile";
            this.txtDataContabile.Size = new System.Drawing.Size(96, 20);
            this.txtDataContabile.TabIndex = 113;
            this.txtDataContabile.Tag = "accountenactment.adate";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtNumeroDocumento);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtEsercizioDocumento);
            this.groupBox1.Location = new System.Drawing.Point(11, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 96);
            this.groupBox1.TabIndex = 111;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Atto";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(80, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Numero:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNumeroDocumento
            // 
            this.txtNumeroDocumento.Location = new System.Drawing.Point(154, 48);
            this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            this.txtNumeroDocumento.Size = new System.Drawing.Size(62, 20);
            this.txtNumeroDocumento.TabIndex = 2;
            this.txtNumeroDocumento.Tag = "accountenactment.nenactment";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(80, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Esercizio:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercizioDocumento
            // 
            this.txtEsercizioDocumento.Location = new System.Drawing.Point(154, 24);
            this.txtEsercizioDocumento.Name = "txtEsercizioDocumento";
            this.txtEsercizioDocumento.ReadOnly = true;
            this.txtEsercizioDocumento.Size = new System.Drawing.Size(62, 20);
            this.txtEsercizioDocumento.TabIndex = 1;
            this.txtEsercizioDocumento.TabStop = false;
            this.txtEsercizioDocumento.Tag = "accountenactment.yenactment";
            // 
            // gboxStato
            // 
            this.gboxStato.Controls.Add(this.rdbInAttesa);
            this.gboxStato.Controls.Add(this.rdbAnnullato);
            this.gboxStato.Controls.Add(this.rdbApprovato);
            this.gboxStato.Location = new System.Drawing.Point(242, 6);
            this.gboxStato.Name = "gboxStato";
            this.gboxStato.Size = new System.Drawing.Size(195, 96);
            this.gboxStato.TabIndex = 112;
            this.gboxStato.TabStop = false;
            this.gboxStato.Text = "Stato";
            // 
            // rdbInAttesa
            // 
            this.rdbInAttesa.Location = new System.Drawing.Point(6, 21);
            this.rdbInAttesa.Name = "rdbInAttesa";
            this.rdbInAttesa.Size = new System.Drawing.Size(155, 16);
            this.rdbInAttesa.TabIndex = 3;
            this.rdbInAttesa.Tag = "accountenactment.idenactmentstatus:1";
            this.rdbInAttesa.Text = "In attesa di approvazione";
            // 
            // rdbAnnullato
            // 
            this.rdbAnnullato.Location = new System.Drawing.Point(6, 66);
            this.rdbAnnullato.Name = "rdbAnnullato";
            this.rdbAnnullato.Size = new System.Drawing.Size(96, 16);
            this.rdbAnnullato.TabIndex = 1;
            this.rdbAnnullato.Tag = "accountenactment.idenactmentstatus:3";
            this.rdbAnnullato.Text = "Annullato";
            // 
            // rdbApprovato
            // 
            this.rdbApprovato.Location = new System.Drawing.Point(6, 37);
            this.rdbApprovato.Name = "rdbApprovato";
            this.rdbApprovato.Size = new System.Drawing.Size(96, 28);
            this.rdbApprovato.TabIndex = 0;
            this.rdbApprovato.Tag = "accountenactment.idenactmentstatus:2";
            this.rdbApprovato.Text = "Approvato";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // Frm_accountenactment_default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 556);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnWait);
            this.Controls.Add(this.btnApprova);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.txtDescrizione);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtDataContabile);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gboxStato);
            this.Name = "Frm_accountenactment_default";
            this.Text = "Frm_accountenactment_default";
            this.tabControl1.ResumeLayout(false);
            this.tabPageVariazioni.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrVariazioni)).EndInit();
            this.tabPageAttributi.ResumeLayout(false);
            this.gboxclass05.ResumeLayout(false);
            this.gboxclass05.PerformLayout();
            this.gboxclass04.ResumeLayout(false);
            this.gboxclass04.PerformLayout();
            this.gboxclass03.ResumeLayout(false);
            this.gboxclass03.PerformLayout();
            this.gboxclass02.ResumeLayout(false);
            this.gboxclass02.PerformLayout();
            this.gboxclass01.ResumeLayout(false);
            this.gboxclass01.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gboxStato.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageVariazioni;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnModifica;
        private System.Windows.Forms.DataGrid dgrVariazioni;
        private System.Windows.Forms.Button btnScollega;
        private System.Windows.Forms.Button btnCollega;
        private System.Windows.Forms.TabPage tabPageAttributi;
        public System.Windows.Forms.GroupBox gboxclass05;
        public System.Windows.Forms.TextBox txtCodice05;
        public System.Windows.Forms.Button btnCodice05;
        private System.Windows.Forms.TextBox txtDenom05;
        public System.Windows.Forms.GroupBox gboxclass04;
        public System.Windows.Forms.TextBox txtCodice04;
        public System.Windows.Forms.Button btnCodice04;
        private System.Windows.Forms.TextBox txtDenom04;
        public System.Windows.Forms.GroupBox gboxclass03;
        public System.Windows.Forms.TextBox txtCodice03;
        public System.Windows.Forms.Button btnCodice03;
        private System.Windows.Forms.TextBox txtDenom03;
        public System.Windows.Forms.GroupBox gboxclass02;
        public System.Windows.Forms.TextBox txtCodice02;
        public System.Windows.Forms.Button btnCodice02;
        private System.Windows.Forms.TextBox txtDenom02;
        public System.Windows.Forms.GroupBox gboxclass01;
        public System.Windows.Forms.TextBox txtCodice01;
        public System.Windows.Forms.Button btnCodice01;
        private System.Windows.Forms.TextBox txtDenom01;
        private System.Windows.Forms.Button btnWait;
        private System.Windows.Forms.Button btnApprova;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.TextBox txtDescrizione;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDataContabile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNumeroDocumento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEsercizioDocumento;
        private System.Windows.Forms.GroupBox gboxStato;
        private System.Windows.Forms.RadioButton rdbInAttesa;
        private System.Windows.Forms.RadioButton rdbAnnullato;
        private System.Windows.Forms.RadioButton rdbApprovato;
    }
}
