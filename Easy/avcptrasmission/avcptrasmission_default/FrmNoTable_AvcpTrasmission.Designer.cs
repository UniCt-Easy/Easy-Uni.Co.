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

﻿namespace avcptrasmission_default {
    partial class FrmNoTable_AvcpTrasmission {
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnGenera = new System.Windows.Forms.Button();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.folderAsk = new System.Windows.Forms.FolderBrowserDialog();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabInformazioni = new System.Windows.Forms.TabPage();
            this.tabAvvisi = new System.Windows.Forms.TabPage();
            this.txtAvvisi = new System.Windows.Forms.TextBox();
            this.DS = new avcptrasmission_default.vistaForm();
            this.tabMain.SuspendLayout();
            this.tabInformazioni.SuspendLayout();
            this.tabAvvisi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Breve descrizione pubblicazione";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(9, 69);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(630, 51);
            this.textBox1.TabIndex = 2;
            this.textBox1.Tag = "avcptrasmission.titolo";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(9, 29);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(630, 20);
            this.textBox2.TabIndex = 1;
            this.textBox2.Tag = "avcptrasmission.abstract";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Titolo della pubblicazione";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(9, 152);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(101, 20);
            this.textBox3.TabIndex = 3;
            this.textBox3.Tag = "avcptrasmission.datapubblicazionedataset";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Data prima pubblicazione indice";
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.Location = new System.Drawing.Point(11, 205);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(628, 20);
            this.textBox4.TabIndex = 6;
            this.textBox4.Tag = "avcptrasmission.entePubblicatore";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(213, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Denominazione ente che pubblica il dataset";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(177, 152);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(101, 20);
            this.textBox5.TabIndex = 4;
            this.textBox5.Tag = "avcptrasmission.dataUltimoAggiornamentoDataset";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(174, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(264, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Data dell’ultima modifica della pubblicazione dell’indice";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(479, 152);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(101, 20);
            this.textBox6.TabIndex = 5;
            this.textBox6.Tag = "avcptrasmission.annoRiferimento";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(476, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Anno riferimento";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 279);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Tipo di licenza applicata";
            // 
            // textBox8
            // 
            this.textBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox8.Location = new System.Drawing.Point(9, 256);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(630, 20);
            this.textBox8.TabIndex = 7;
            this.textBox8.Tag = "avcptrasmission.baseurl";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 239);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(437, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Base URL per la pubblicazione (si  assume che tutti i file saranno pubblicati sot" +
    "to questa url)";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(11, 344);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(132, 20);
            this.textBox9.TabIndex = 9;
            this.textBox9.Tag = "avcptrasmission.codiceFiscaleProp";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 327);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(455, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Codice fiscale della Stazione Appaltante responsabile del procedimento di scelta " +
    "del contraente";
            // 
            // textBox10
            // 
            this.textBox10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox10.Location = new System.Drawing.Point(11, 390);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(628, 20);
            this.textBox10.TabIndex = 10;
            this.textBox10.Tag = "avcptrasmission.denominazione";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 373);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(462, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Denominazione della Stazione Appaltante responsabile del procedimento di scelta d" +
    "el contraente";
            // 
            // btnGenera
            // 
            this.btnGenera.Location = new System.Drawing.Point(502, 428);
            this.btnGenera.Name = "btnGenera";
            this.btnGenera.Size = new System.Drawing.Size(128, 23);
            this.btnGenera.TabIndex = 11;
            this.btnGenera.Text = "Genera file XML";
            this.btnGenera.UseVisualStyleBackColor = true;
            this.btnGenera.Click += new System.EventHandler(this.btnGenera_Click);
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(11, 295);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(267, 20);
            this.textBox7.TabIndex = 8;
            this.textBox7.Tag = "avcptrasmission.licenza";
            // 
            // folderAsk
            // 
            this.folderAsk.Description = "Selezione della cartella dove creare i file. File eventualmente già presenti sara" +
    "nno sovrascritti.";
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabInformazioni);
            this.tabMain.Controls.Add(this.tabAvvisi);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(655, 489);
            this.tabMain.TabIndex = 19;
            // 
            // tabInformazioni
            // 
            this.tabInformazioni.Controls.Add(this.label2);
            this.tabInformazioni.Controls.Add(this.textBox7);
            this.tabInformazioni.Controls.Add(this.label1);
            this.tabInformazioni.Controls.Add(this.btnGenera);
            this.tabInformazioni.Controls.Add(this.textBox1);
            this.tabInformazioni.Controls.Add(this.textBox10);
            this.tabInformazioni.Controls.Add(this.textBox2);
            this.tabInformazioni.Controls.Add(this.label10);
            this.tabInformazioni.Controls.Add(this.label3);
            this.tabInformazioni.Controls.Add(this.textBox9);
            this.tabInformazioni.Controls.Add(this.textBox3);
            this.tabInformazioni.Controls.Add(this.label9);
            this.tabInformazioni.Controls.Add(this.label4);
            this.tabInformazioni.Controls.Add(this.textBox8);
            this.tabInformazioni.Controls.Add(this.textBox4);
            this.tabInformazioni.Controls.Add(this.label8);
            this.tabInformazioni.Controls.Add(this.label5);
            this.tabInformazioni.Controls.Add(this.label7);
            this.tabInformazioni.Controls.Add(this.textBox5);
            this.tabInformazioni.Controls.Add(this.textBox6);
            this.tabInformazioni.Controls.Add(this.label6);
            this.tabInformazioni.Location = new System.Drawing.Point(4, 22);
            this.tabInformazioni.Name = "tabInformazioni";
            this.tabInformazioni.Padding = new System.Windows.Forms.Padding(3);
            this.tabInformazioni.Size = new System.Drawing.Size(647, 463);
            this.tabInformazioni.TabIndex = 0;
            this.tabInformazioni.Text = "Informazioni";
            this.tabInformazioni.UseVisualStyleBackColor = true;
            // 
            // tabAvvisi
            // 
            this.tabAvvisi.Controls.Add(this.txtAvvisi);
            this.tabAvvisi.Location = new System.Drawing.Point(4, 22);
            this.tabAvvisi.Name = "tabAvvisi";
            this.tabAvvisi.Padding = new System.Windows.Forms.Padding(3);
            this.tabAvvisi.Size = new System.Drawing.Size(647, 463);
            this.tabAvvisi.TabIndex = 1;
            this.tabAvvisi.Text = "Errori";
            this.tabAvvisi.UseVisualStyleBackColor = true;
            // 
            // txtAvvisi
            // 
            this.txtAvvisi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAvvisi.Location = new System.Drawing.Point(8, 6);
            this.txtAvvisi.Multiline = true;
            this.txtAvvisi.Name = "txtAvvisi";
            this.txtAvvisi.ReadOnly = true;
            this.txtAvvisi.Size = new System.Drawing.Size(631, 449);
            this.txtAvvisi.TabIndex = 0;
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // FrmNoTable_AvcpTrasmission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 489);
            this.Controls.Add(this.tabMain);
            this.Name = "FrmNoTable_AvcpTrasmission";
            this.Text = "Generazione file AVCP";
            this.tabMain.ResumeLayout(false);
            this.tabInformazioni.ResumeLayout(false);
            this.tabInformazioni.PerformLayout();
            this.tabAvvisi.ResumeLayout(false);
            this.tabAvvisi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnGenera;
        private System.Windows.Forms.TextBox textBox7;
        public vistaForm DS;
        private System.Windows.Forms.FolderBrowserDialog folderAsk;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabInformazioni;
        private System.Windows.Forms.TabPage tabAvvisi;
        private System.Windows.Forms.TextBox txtAvvisi;

    }
}