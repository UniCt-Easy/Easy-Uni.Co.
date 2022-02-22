
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


namespace registrydurc_default
{
    partial class Frm_registrydurc_default
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_registrydurc_default));
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox72 = new System.Windows.Forms.GroupBox();
            this.radioButton22 = new System.Windows.Forms.RadioButton();
            this.radioButton21 = new System.Windows.Forms.RadioButton();
            this.radioButton20 = new System.Windows.Forms.RadioButton();
            this.txtDataContabile = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtINAIL = new System.Windows.Forms.TextBox();
            this.txtINPS = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDataDoc = new System.Windows.Forms.TextBox();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtscadenza = new System.Windows.Forms.TextBox();
            this.txtDataIniziovalidita = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupCredDeb = new System.Windows.Forms.GroupBox();
            this.txtCreDeb = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.DS = new registrydurc_default.vistaForm();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labDurcFileName = new System.Windows.Forms.Label();
            this.btnVisualizzaDurc = new System.Windows.Forms.Button();
            this.btnRimuoviDurc = new System.Windows.Forms.Button();
            this.btnAllegaDurc = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labAutocertFileName = new System.Windows.Forms.Label();
            this.btnVisualizzaAuto = new System.Windows.Forms.Button();
            this.btnRimuoviAuto = new System.Windows.Forms.Button();
            this.btnAllegaAuto = new System.Windows.Forms.Button();
            this._opendlg = new System.Windows.Forms.OpenFileDialog();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox72.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupCredDeb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(259, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(226, 75);
            this.label9.TabIndex = 197;
            this.label9.Text = resources.GetString("label9.Text");
            // 
            // groupBox72
            // 
            this.groupBox72.Controls.Add(this.radioButton22);
            this.groupBox72.Controls.Add(this.radioButton21);
            this.groupBox72.Controls.Add(this.radioButton20);
            this.groupBox72.Location = new System.Drawing.Point(21, 66);
            this.groupBox72.Name = "groupBox72";
            this.groupBox72.Size = new System.Drawing.Size(229, 104);
            this.groupBox72.TabIndex = 9;
            this.groupBox72.TabStop = false;
            this.groupBox72.Text = "Tipo documento";
            // 
            // radioButton22
            // 
            this.radioButton22.AutoSize = true;
            this.radioButton22.Location = new System.Drawing.Point(6, 73);
            this.radioButton22.Name = "radioButton22";
            this.radioButton22.Size = new System.Drawing.Size(107, 17);
            this.radioButton22.TabIndex = 2;
            this.radioButton22.TabStop = true;
            this.radioButton22.Tag = "registrydurc.iddurckind:3";
            this.radioButton22.Text = "DURC telematico";
            this.radioButton22.UseVisualStyleBackColor = true;
            // 
            // radioButton21
            // 
            this.radioButton21.AutoSize = true;
            this.radioButton21.Location = new System.Drawing.Point(6, 49);
            this.radioButton21.Name = "radioButton21";
            this.radioButton21.Size = new System.Drawing.Size(156, 17);
            this.radioButton21.TabIndex = 1;
            this.radioButton21.TabStop = true;
            this.radioButton21.Tag = "registrydurc.iddurckind:2";
            this.radioButton21.Text = "Autocertificazione Verificata";
            this.radioButton21.UseVisualStyleBackColor = true;
            // 
            // radioButton20
            // 
            this.radioButton20.AutoSize = true;
            this.radioButton20.Location = new System.Drawing.Point(6, 25);
            this.radioButton20.Name = "radioButton20";
            this.radioButton20.Size = new System.Drawing.Size(171, 17);
            this.radioButton20.TabIndex = 0;
            this.radioButton20.TabStop = true;
            this.radioButton20.Tag = "registrydurc.iddurckind:1";
            this.radioButton20.Text = "Autocertificazione da Verificare";
            this.radioButton20.UseVisualStyleBackColor = true;
            // 
            // txtDataContabile
            // 
            this.txtDataContabile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDataContabile.Location = new System.Drawing.Point(103, 272);
            this.txtDataContabile.Name = "txtDataContabile";
            this.txtDataContabile.Size = new System.Drawing.Size(80, 20);
            this.txtDataContabile.TabIndex = 13;
            this.txtDataContabile.Tag = "registrydurc.adate";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.Location = new System.Drawing.Point(24, 272);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 16);
            this.label11.TabIndex = 193;
            this.label11.Text = "Data Contabile";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(274, 303);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 191;
            this.label3.Text = "Codice INAIL";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 304);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 190;
            this.label2.Text = "Codice INPS";
            // 
            // txtINAIL
            // 
            this.txtINAIL.Location = new System.Drawing.Point(276, 321);
            this.txtINAIL.Name = "txtINAIL";
            this.txtINAIL.Size = new System.Drawing.Size(179, 20);
            this.txtINAIL.TabIndex = 15;
            this.txtINAIL.Tag = "registrydurc.inailcode";
            // 
            // txtINPS
            // 
            this.txtINPS.Location = new System.Drawing.Point(21, 323);
            this.txtINPS.Name = "txtINPS";
            this.txtINPS.Size = new System.Drawing.Size(178, 20);
            this.txtINPS.TabIndex = 14;
            this.txtINPS.Tag = "registrydurc.inpscode";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDataDoc);
            this.groupBox2.Controls.Add(this.txtDocumento);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(21, 204);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(465, 54);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Documento";
            // 
            // txtDataDoc
            // 
            this.txtDataDoc.Location = new System.Drawing.Point(368, 19);
            this.txtDataDoc.Name = "txtDataDoc";
            this.txtDataDoc.Size = new System.Drawing.Size(80, 20);
            this.txtDataDoc.TabIndex = 14;
            this.txtDataDoc.Tag = "registrydurc.docdate";
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(80, 22);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(160, 20);
            this.txtDocumento.TabIndex = 13;
            this.txtDocumento.Tag = "registrydurc.doc";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(314, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Data";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Documento";
            // 
            // txtscadenza
            // 
            this.txtscadenza.Location = new System.Drawing.Point(365, 173);
            this.txtscadenza.Name = "txtscadenza";
            this.txtscadenza.Size = new System.Drawing.Size(120, 20);
            this.txtscadenza.TabIndex = 11;
            this.txtscadenza.Tag = "registrydurc.stop";
            // 
            // txtDataIniziovalidita
            // 
            this.txtDataIniziovalidita.Location = new System.Drawing.Point(366, 147);
            this.txtDataIniziovalidita.Name = "txtDataIniziovalidita";
            this.txtDataIniziovalidita.Size = new System.Drawing.Size(120, 20);
            this.txtDataIniziovalidita.TabIndex = 10;
            this.txtDataIniziovalidita.Tag = "registrydurc.start";
            this.txtDataIniziovalidita.Leave += new System.EventHandler(this.txtDataIniziovalidita_Leave);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(272, 168);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 23);
            this.label10.TabIndex = 186;
            this.label10.Text = "Data scadenza";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(256, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 30);
            this.label4.TabIndex = 185;
            this.label4.Text = "Data inizio validità";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupCredDeb
            // 
            this.groupCredDeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupCredDeb.Controls.Add(this.txtCreDeb);
            this.groupCredDeb.Controls.Add(this.label6);
            this.groupCredDeb.Location = new System.Drawing.Point(21, 12);
            this.groupCredDeb.Name = "groupCredDeb";
            this.groupCredDeb.Size = new System.Drawing.Size(464, 48);
            this.groupCredDeb.TabIndex = 1;
            this.groupCredDeb.TabStop = false;
            this.groupCredDeb.Tag = "AutoChoose.txtCreDeb.anagrafica.(active<>\'N\')";
            this.groupCredDeb.Text = "Anagrafica";
            // 
            // txtCreDeb
            // 
            this.txtCreDeb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCreDeb.Location = new System.Drawing.Point(120, 16);
            this.txtCreDeb.Name = "txtCreDeb";
            this.txtCreDeb.Size = new System.Drawing.Size(336, 20);
            this.txtCreDeb.TabIndex = 1;
            this.txtCreDeb.Tag = "registry.title?registryDURCview.registry";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(16, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "Denominazione:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(44, 178);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(69, 20);
            this.textBox4.TabIndex = 199;
            this.textBox4.Tag = "registrydurc.idregistrydurc";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 180);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(14, 13);
            this.label12.TabIndex = 200;
            this.label12.Text = "#";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labDurcFileName);
            this.groupBox3.Controls.Add(this.btnVisualizzaDurc);
            this.groupBox3.Controls.Add(this.btnRimuoviDurc);
            this.groupBox3.Controls.Add(this.btnAllegaDurc);
            this.groupBox3.Location = new System.Drawing.Point(22, 506);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(437, 73);
            this.groupBox3.TabIndex = 202;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Allegato DURC";
            // 
            // labDurcFileName
            // 
            this.labDurcFileName.Location = new System.Drawing.Point(10, 16);
            this.labDurcFileName.Name = "labDurcFileName";
            this.labDurcFileName.Size = new System.Drawing.Size(406, 18);
            this.labDurcFileName.TabIndex = 75;
            // 
            // btnVisualizzaDurc
            // 
            this.btnVisualizzaDurc.Location = new System.Drawing.Point(333, 36);
            this.btnVisualizzaDurc.Name = "btnVisualizzaDurc";
            this.btnVisualizzaDurc.Size = new System.Drawing.Size(79, 24);
            this.btnVisualizzaDurc.TabIndex = 2;
            this.btnVisualizzaDurc.Text = "Visualizza";
            this.btnVisualizzaDurc.UseVisualStyleBackColor = true;
            this.btnVisualizzaDurc.Click += new System.EventHandler(this.btnVisualizzaDurc_Click);
            // 
            // btnRimuoviDurc
            // 
            this.btnRimuoviDurc.Location = new System.Drawing.Point(213, 36);
            this.btnRimuoviDurc.Name = "btnRimuoviDurc";
            this.btnRimuoviDurc.Size = new System.Drawing.Size(99, 24);
            this.btnRimuoviDurc.TabIndex = 1;
            this.btnRimuoviDurc.Text = "Rimuovi Allegato";
            this.btnRimuoviDurc.UseVisualStyleBackColor = true;
            this.btnRimuoviDurc.Click += new System.EventHandler(this.btnRimuoviDurc_Click);
            // 
            // btnAllegaDurc
            // 
            this.btnAllegaDurc.Location = new System.Drawing.Point(117, 36);
            this.btnAllegaDurc.Name = "btnAllegaDurc";
            this.btnAllegaDurc.Size = new System.Drawing.Size(79, 24);
            this.btnAllegaDurc.TabIndex = 0;
            this.btnAllegaDurc.Text = "Allega";
            this.btnAllegaDurc.UseVisualStyleBackColor = true;
            this.btnAllegaDurc.Click += new System.EventHandler(this.btnAllegaDurc_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labAutocertFileName);
            this.groupBox1.Controls.Add(this.btnVisualizzaAuto);
            this.groupBox1.Controls.Add(this.btnRimuoviAuto);
            this.groupBox1.Controls.Add(this.btnAllegaAuto);
            this.groupBox1.Location = new System.Drawing.Point(21, 420);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(438, 82);
            this.groupBox1.TabIndex = 201;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Allegato Autocertificazione ";
            // 
            // labAutocertFileName
            // 
            this.labAutocertFileName.Location = new System.Drawing.Point(11, 16);
            this.labAutocertFileName.Name = "labAutocertFileName";
            this.labAutocertFileName.Size = new System.Drawing.Size(407, 16);
            this.labAutocertFileName.TabIndex = 74;
            // 
            // btnVisualizzaAuto
            // 
            this.btnVisualizzaAuto.Location = new System.Drawing.Point(335, 45);
            this.btnVisualizzaAuto.Name = "btnVisualizzaAuto";
            this.btnVisualizzaAuto.Size = new System.Drawing.Size(79, 24);
            this.btnVisualizzaAuto.TabIndex = 2;
            this.btnVisualizzaAuto.Text = "Visualizza";
            this.btnVisualizzaAuto.UseVisualStyleBackColor = true;
            this.btnVisualizzaAuto.Click += new System.EventHandler(this.btnVisualizzaAuto_Click);
            // 
            // btnRimuoviAuto
            // 
            this.btnRimuoviAuto.Location = new System.Drawing.Point(214, 45);
            this.btnRimuoviAuto.Name = "btnRimuoviAuto";
            this.btnRimuoviAuto.Size = new System.Drawing.Size(101, 24);
            this.btnRimuoviAuto.TabIndex = 1;
            this.btnRimuoviAuto.Text = "Rimuovi Allegato";
            this.btnRimuoviAuto.UseVisualStyleBackColor = true;
            this.btnRimuoviAuto.Click += new System.EventHandler(this.btnRimuoviAuto_Click);
            // 
            // btnAllegaAuto
            // 
            this.btnAllegaAuto.Location = new System.Drawing.Point(118, 45);
            this.btnAllegaAuto.Name = "btnAllegaAuto";
            this.btnAllegaAuto.Size = new System.Drawing.Size(79, 24);
            this.btnAllegaAuto.TabIndex = 0;
            this.btnAllegaAuto.Text = "Allega";
            this.btnAllegaAuto.UseVisualStyleBackColor = true;
            this.btnAllegaAuto.Click += new System.EventHandler(this.btnAllegaAuto_Click);
            // 
            // opendlg
            // 
            this._opendlg.Title = "Scegli il file da allegare";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 362);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Codice Cassa Edile";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(20, 380);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(179, 20);
            this.textBox1.TabIndex = 16;
            this.textBox1.Tag = "registrydurc.buildingcode";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(273, 366);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(206, 13);
            this.label8.TabIndex = 204;
            this.label8.Text = "Codice Gestore di Altra Forma assicurativa";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(276, 384);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(179, 20);
            this.textBox2.TabIndex = 18;
            this.textBox2.Tag = "registrydurc.otherinsurancecode";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(275, 275);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(104, 17);
            this.checkBox1.TabIndex = 205;
            this.checkBox1.Tag = "registrydurc.flagirregular:S:N";
            this.checkBox1.Text = "DURC Irregolare";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Frm_registrydurc_default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 601);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.groupCredDeb);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox72);
            this.Controls.Add(this.txtDataContabile);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtINAIL);
            this.Controls.Add(this.txtINPS);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtscadenza);
            this.Controls.Add(this.txtDataIniziovalidita);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label4);
            this.Name = "Frm_registrydurc_default";
            this.Text = "Frm_registrydurc_default";
            this.groupBox72.ResumeLayout(false);
            this.groupBox72.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupCredDeb.ResumeLayout(false);
            this.groupCredDeb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox72;
        private System.Windows.Forms.RadioButton radioButton22;
        private System.Windows.Forms.RadioButton radioButton21;
        private System.Windows.Forms.RadioButton radioButton20;
        private System.Windows.Forms.TextBox txtDataContabile;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtINAIL;
        private System.Windows.Forms.TextBox txtINPS;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDataDoc;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtscadenza;
        private System.Windows.Forms.TextBox txtDataIniziovalidita;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupCredDeb;
        private System.Windows.Forms.TextBox txtCreDeb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label labDurcFileName;
        private System.Windows.Forms.Button btnVisualizzaDurc;
        private System.Windows.Forms.Button btnRimuoviDurc;
        private System.Windows.Forms.Button btnAllegaDurc;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labAutocertFileName;
        private System.Windows.Forms.Button btnVisualizzaAuto;
        private System.Windows.Forms.Button btnRimuoviAuto;
        private System.Windows.Forms.Button btnAllegaAuto;
        private System.Windows.Forms.OpenFileDialog _opendlg;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.CheckBox checkBox1;

    }
}
