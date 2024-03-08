
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


namespace grantload_default {
    partial class Frm_grantload_default {
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
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabDefinizioneScarico = new System.Windows.Forms.TabControl();
			this.tabPageContributi = new System.Windows.Forms.TabPage();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btnModifica = new System.Windows.Forms.Button();
			this.btnScollega = new System.Windows.Forms.Button();
			this.dgrContributi = new System.Windows.Forms.DataGrid();
			this.btnCollega = new System.Windows.Forms.Button();
			this.tabPageRisconti = new System.Windows.Forms.TabPage();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.btnModificaVar = new System.Windows.Forms.Button();
			this.btnScollegaVar = new System.Windows.Forms.Button();
			this.dgrRisconti = new System.Windows.Forms.DataGrid();
			this.btnCollegaRisconti = new System.Windows.Forms.Button();
			this.txtAnno = new System.Windows.Forms.TextBox();
			this.lbAnno = new System.Windows.Forms.Label();
			this.gBoxTransmissionKind = new System.Windows.Forms.GroupBox();
			this.chkDefinizione = new System.Windows.Forms.CheckBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.labEP = new System.Windows.Forms.Label();
			this.btnVisualizzaPreimpegni = new System.Windows.Forms.Button();
			this.btnGeneraPreimpegni = new System.Windows.Forms.Button();
			this.btnGeneraEpExp = new System.Windows.Forms.Button();
			this.btnVisualizzaEpExp = new System.Windows.Forms.Button();
			this.btnGeneraEP = new System.Windows.Forms.Button();
			this.btnVisualizzaEP = new System.Windows.Forms.Button();
			this.DS = new grantload_default.dsmeta();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabDefinizioneScarico.SuspendLayout();
			this.tabPageContributi.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrContributi)).BeginInit();
			this.tabPageRisconti.SuspendLayout();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrRisconti)).BeginInit();
			this.gBoxTransmissionKind.SuspendLayout();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(2, 12);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(922, 345);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.textBox1);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.tabDefinizioneScarico);
			this.tabPage1.Controls.Add(this.txtAnno);
			this.tabPage1.Controls.Add(this.lbAnno);
			this.tabPage1.Controls.Add(this.gBoxTransmissionKind);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(914, 319);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Principale";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabDefinizioneScarico
			// 
			this.tabDefinizioneScarico.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabDefinizioneScarico.Controls.Add(this.tabPageContributi);
			this.tabDefinizioneScarico.Controls.Add(this.tabPageRisconti);
			this.tabDefinizioneScarico.Location = new System.Drawing.Point(9, 92);
			this.tabDefinizioneScarico.Name = "tabDefinizioneScarico";
			this.tabDefinizioneScarico.SelectedIndex = 0;
			this.tabDefinizioneScarico.Size = new System.Drawing.Size(884, 221);
			this.tabDefinizioneScarico.TabIndex = 83;
			// 
			// tabPageContributi
			// 
			this.tabPageContributi.Controls.Add(this.groupBox2);
			this.tabPageContributi.Location = new System.Drawing.Point(4, 22);
			this.tabPageContributi.Name = "tabPageContributi";
			this.tabPageContributi.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageContributi.Size = new System.Drawing.Size(876, 195);
			this.tabPageContributi.TabIndex = 0;
			this.tabPageContributi.Text = "Costituzione risconto/Riserva";
			this.tabPageContributi.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.btnModifica);
			this.groupBox2.Controls.Add(this.btnScollega);
			this.groupBox2.Controls.Add(this.dgrContributi);
			this.groupBox2.Controls.Add(this.btnCollega);
			this.groupBox2.Location = new System.Drawing.Point(6, 6);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(864, 183);
			this.groupBox2.TabIndex = 5;
			this.groupBox2.TabStop = false;
			// 
			// btnModifica
			// 
			this.btnModifica.Location = new System.Drawing.Point(16, 64);
			this.btnModifica.Name = "btnModifica";
			this.btnModifica.Size = new System.Drawing.Size(75, 23);
			this.btnModifica.TabIndex = 78;
			this.btnModifica.TabStop = false;
			this.btnModifica.Tag = "";
			this.btnModifica.Text = "Modifica...";
			this.btnModifica.Click += new System.EventHandler(this.btnModifica_Click);
			// 
			// btnScollega
			// 
			this.btnScollega.Location = new System.Drawing.Point(16, 104);
			this.btnScollega.Name = "btnScollega";
			this.btnScollega.Size = new System.Drawing.Size(75, 23);
			this.btnScollega.TabIndex = 77;
			this.btnScollega.TabStop = false;
			this.btnScollega.Tag = "unlink";
			this.btnScollega.Text = "Rimuovi";
			// 
			// dgrContributi
			// 
			this.dgrContributi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgrContributi.CaptionVisible = false;
			this.dgrContributi.DataMember = "";
			this.dgrContributi.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrContributi.Location = new System.Drawing.Point(96, 24);
			this.dgrContributi.Name = "dgrContributi";
			this.dgrContributi.Size = new System.Drawing.Size(760, 137);
			this.dgrContributi.TabIndex = 75;
			this.dgrContributi.Tag = "assetgrant.collegati";
			// 
			// btnCollega
			// 
			this.btnCollega.Location = new System.Drawing.Point(16, 24);
			this.btnCollega.Name = "btnCollega";
			this.btnCollega.Size = new System.Drawing.Size(75, 23);
			this.btnCollega.TabIndex = 76;
			this.btnCollega.TabStop = false;
			this.btnCollega.Tag = "";
			this.btnCollega.Text = "Inserisci";
			// 
			// tabPageRisconti
			// 
			this.tabPageRisconti.Controls.Add(this.groupBox4);
			this.tabPageRisconti.Location = new System.Drawing.Point(4, 22);
			this.tabPageRisconti.Name = "tabPageRisconti";
			this.tabPageRisconti.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageRisconti.Size = new System.Drawing.Size(876, 195);
			this.tabPageRisconti.TabIndex = 1;
			this.tabPageRisconti.Text = "Consumo Risconto/Riserva";
			this.tabPageRisconti.UseVisualStyleBackColor = true;
			// 
			// groupBox4
			// 
			this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox4.Controls.Add(this.btnModificaVar);
			this.groupBox4.Controls.Add(this.btnScollegaVar);
			this.groupBox4.Controls.Add(this.dgrRisconti);
			this.groupBox4.Controls.Add(this.btnCollegaRisconti);
			this.groupBox4.Location = new System.Drawing.Point(6, 6);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(864, 183);
			this.groupBox4.TabIndex = 6;
			this.groupBox4.TabStop = false;
			// 
			// btnModificaVar
			// 
			this.btnModificaVar.Location = new System.Drawing.Point(16, 64);
			this.btnModificaVar.Name = "btnModificaVar";
			this.btnModificaVar.Size = new System.Drawing.Size(75, 23);
			this.btnModificaVar.TabIndex = 78;
			this.btnModificaVar.TabStop = false;
			this.btnModificaVar.Tag = "";
			this.btnModificaVar.Text = "Modifica...";
			this.btnModificaVar.Click += new System.EventHandler(this.btnModificaRisconti_Click);
			// 
			// btnScollegaVar
			// 
			this.btnScollegaVar.Location = new System.Drawing.Point(16, 104);
			this.btnScollegaVar.Name = "btnScollegaVar";
			this.btnScollegaVar.Size = new System.Drawing.Size(75, 23);
			this.btnScollegaVar.TabIndex = 77;
			this.btnScollegaVar.TabStop = false;
			this.btnScollegaVar.Tag = "unlink";
			this.btnScollegaVar.Text = "Rimuovi";
			// 
			// dgrRisconti
			// 
			this.dgrRisconti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgrRisconti.CaptionVisible = false;
			this.dgrRisconti.DataMember = "";
			this.dgrRisconti.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrRisconti.Location = new System.Drawing.Point(96, 24);
			this.dgrRisconti.Name = "dgrRisconti";
			this.dgrRisconti.Size = new System.Drawing.Size(760, 137);
			this.dgrRisconti.TabIndex = 75;
			this.dgrRisconti.Tag = "assetgrantdetail.collegati";
			// 
			// btnCollegaRisconti
			// 
			this.btnCollegaRisconti.Location = new System.Drawing.Point(16, 24);
			this.btnCollegaRisconti.Name = "btnCollegaRisconti";
			this.btnCollegaRisconti.Size = new System.Drawing.Size(75, 23);
			this.btnCollegaRisconti.TabIndex = 76;
			this.btnCollegaRisconti.TabStop = false;
			this.btnCollegaRisconti.Tag = "";
			this.btnCollegaRisconti.Text = "Inserisci";
			// 
			// txtAnno
			// 
			this.txtAnno.Location = new System.Drawing.Point(94, 14);
			this.txtAnno.Name = "txtAnno";
			this.txtAnno.Size = new System.Drawing.Size(88, 20);
			this.txtAnno.TabIndex = 92;
			this.txtAnno.Tag = "grantload.yload";
			// 
			// lbAnno
			// 
			this.lbAnno.Location = new System.Drawing.Point(16, 12);
			this.lbAnno.Name = "lbAnno";
			this.lbAnno.Size = new System.Drawing.Size(72, 22);
			this.lbAnno.TabIndex = 91;
			this.lbAnno.Tag = "";
			this.lbAnno.Text = "Esercizio";
			this.lbAnno.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// gBoxTransmissionKind
			// 
			this.gBoxTransmissionKind.Controls.Add(this.chkDefinizione);
			this.gBoxTransmissionKind.Location = new System.Drawing.Point(3, 56);
			this.gBoxTransmissionKind.Name = "gBoxTransmissionKind";
			this.gBoxTransmissionKind.Size = new System.Drawing.Size(440, 36);
			this.gBoxTransmissionKind.TabIndex = 85;
			this.gBoxTransmissionKind.TabStop = false;
			this.gBoxTransmissionKind.Text = "Tipo scrittura da generare";
			// 
			// chkDefinizione
			// 
			this.chkDefinizione.AutoSize = true;
			this.chkDefinizione.Location = new System.Drawing.Point(16, 13);
			this.chkDefinizione.Name = "chkDefinizione";
			this.chkDefinizione.Size = new System.Drawing.Size(218, 17);
			this.chkDefinizione.TabIndex = 82;
			this.chkDefinizione.Tag = "grantload.kind:D:U";
			this.chkDefinizione.Text = "Costituzione risconto/Riserva";
			this.chkDefinizione.UseVisualStyleBackColor = true;
			this.chkDefinizione.CheckedChanged += new System.EventHandler(this.chkScarico_CheckedChanged);
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.labEP);
			this.tabPage2.Controls.Add(this.btnVisualizzaPreimpegni);
			this.tabPage2.Controls.Add(this.btnGeneraPreimpegni);
			this.tabPage2.Controls.Add(this.btnGeneraEpExp);
			this.tabPage2.Controls.Add(this.btnVisualizzaEpExp);
			this.tabPage2.Controls.Add(this.btnGeneraEP);
			this.tabPage2.Controls.Add(this.btnVisualizzaEP);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(914, 319);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "E/P";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// labEP
			// 
			this.labEP.AutoSize = true;
			this.labEP.Location = new System.Drawing.Point(15, 266);
			this.labEP.Name = "labEP";
			this.labEP.Size = new System.Drawing.Size(237, 13);
			this.labEP.TabIndex = 60;
			this.labEP.Text = "Le scritture in partita doppia sono state generate.";
			// 
			// btnVisualizzaPreimpegni
			// 
			this.btnVisualizzaPreimpegni.Location = new System.Drawing.Point(18, 220);
			this.btnVisualizzaPreimpegni.Name = "btnVisualizzaPreimpegni";
			this.btnVisualizzaPreimpegni.Size = new System.Drawing.Size(203, 23);
			this.btnVisualizzaPreimpegni.TabIndex = 59;
			this.btnVisualizzaPreimpegni.TabStop = false;
			this.btnVisualizzaPreimpegni.Text = "Visualizza Preaccertamenti di Budget";
			// 
			// btnGeneraPreimpegni
			// 
			this.btnGeneraPreimpegni.Location = new System.Drawing.Point(18, 181);
			this.btnGeneraPreimpegni.Name = "btnGeneraPreimpegni";
			this.btnGeneraPreimpegni.Size = new System.Drawing.Size(203, 23);
			this.btnGeneraPreimpegni.TabIndex = 58;
			this.btnGeneraPreimpegni.TabStop = false;
			this.btnGeneraPreimpegni.Text = "Genera Preaccertamenti di Budget";
			// 
			// btnGeneraEpExp
			// 
			this.btnGeneraEpExp.Location = new System.Drawing.Point(18, 100);
			this.btnGeneraEpExp.Name = "btnGeneraEpExp";
			this.btnGeneraEpExp.Size = new System.Drawing.Size(203, 23);
			this.btnGeneraEpExp.TabIndex = 56;
			this.btnGeneraEpExp.TabStop = false;
			this.btnGeneraEpExp.Text = "Genera Accertamenti di Budget";
			// 
			// btnVisualizzaEpExp
			// 
			this.btnVisualizzaEpExp.Location = new System.Drawing.Point(18, 140);
			this.btnVisualizzaEpExp.Name = "btnVisualizzaEpExp";
			this.btnVisualizzaEpExp.Size = new System.Drawing.Size(203, 23);
			this.btnVisualizzaEpExp.TabIndex = 57;
			this.btnVisualizzaEpExp.TabStop = false;
			this.btnVisualizzaEpExp.Text = "Visualizza Accertamenti di Budget";
			// 
			// btnGeneraEP
			// 
			this.btnGeneraEP.Location = new System.Drawing.Point(18, 57);
			this.btnGeneraEP.Name = "btnGeneraEP";
			this.btnGeneraEP.Size = new System.Drawing.Size(203, 23);
			this.btnGeneraEP.TabIndex = 55;
			this.btnGeneraEP.Text = "Genera le scritture in partita doppia";
			this.btnGeneraEP.UseVisualStyleBackColor = true;
			// 
			// btnVisualizzaEP
			// 
			this.btnVisualizzaEP.Location = new System.Drawing.Point(18, 28);
			this.btnVisualizzaEP.Name = "btnVisualizzaEP";
			this.btnVisualizzaEP.Size = new System.Drawing.Size(203, 23);
			this.btnVisualizzaEP.TabIndex = 54;
			this.btnVisualizzaEP.Text = "Visualizza le scritture in partita doppia";
			this.btnVisualizzaEP.UseVisualStyleBackColor = true;
			// 
			// DS
			// 
			this.DS.DataSetName = "dsmeta";
			this.DS.EnforceConstraints = false;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(355, 14);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(88, 20);
			this.textBox1.TabIndex = 94;
			this.textBox1.Tag = "grantload.idgrantload";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(277, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 22);
			this.label1.TabIndex = 93;
			this.label1.Tag = "";
			this.label1.Text = "#";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// Frm_grantload_default
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(936, 373);
			this.Controls.Add(this.tabControl1);
			this.Name = "Frm_grantload_default";
			this.Text = "Frm_grantload";
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabDefinizioneScarico.ResumeLayout(false);
			this.tabPageContributi.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgrContributi)).EndInit();
			this.tabPageRisconti.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgrRisconti)).EndInit();
			this.gBoxTransmissionKind.ResumeLayout(false);
			this.gBoxTransmissionKind.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtAnno;
        private System.Windows.Forms.Label lbAnno;
        private System.Windows.Forms.GroupBox gBoxTransmissionKind;
        private System.Windows.Forms.CheckBox chkDefinizione;
        private System.Windows.Forms.TabControl tabDefinizioneScarico;
        private System.Windows.Forms.TabPage tabPageContributi;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnModifica;
        private System.Windows.Forms.Button btnScollega;
        private System.Windows.Forms.DataGrid dgrContributi;
        private System.Windows.Forms.Button btnCollega;
        private System.Windows.Forms.TabPage tabPageRisconti;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnModificaVar;
        private System.Windows.Forms.Button btnScollegaVar;
        private System.Windows.Forms.DataGrid dgrRisconti;
        private System.Windows.Forms.Button btnCollegaRisconti;
        public dsmeta DS;
        private System.Windows.Forms.Label labEP;
        private System.Windows.Forms.Button btnVisualizzaPreimpegni;
        private System.Windows.Forms.Button btnGeneraPreimpegni;
        private System.Windows.Forms.Button btnGeneraEpExp;
        private System.Windows.Forms.Button btnVisualizzaEpExp;
        private System.Windows.Forms.Button btnGeneraEP;
        private System.Windows.Forms.Button btnVisualizzaEP;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
	}
}
