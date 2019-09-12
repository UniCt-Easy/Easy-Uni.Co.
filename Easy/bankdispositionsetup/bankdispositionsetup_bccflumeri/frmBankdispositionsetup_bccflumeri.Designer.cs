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

namespace bankdispositionsetup_bccflumeri {
    partial class frmbankdispositionsetup_bccflumeri {
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
            this.gboxPagamenti = new System.Windows.Forms.GroupBox();
            this.btnGeneraFilePagamenti = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNPaymentTransmission = new System.Windows.Forms.TextBox();
            this.btnPaymentTransm = new System.Windows.Forms.Button();
            this.gboxIncassi = new System.Windows.Forms.GroupBox();
            this.btnGeneraFileIncassi = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNproceedsTransm = new System.Windows.Forms.TextBox();
            this.btnProceedsTransm = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.DS = new bankdispositionsetup_bccflumeri.vistaForm();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.gboxPagamenti.SuspendLayout();
            this.gboxIncassi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gboxPagamenti
            // 
            this.gboxPagamenti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxPagamenti.Controls.Add(this.btnGeneraFilePagamenti);
            this.gboxPagamenti.Controls.Add(this.label1);
            this.gboxPagamenti.Controls.Add(this.txtNPaymentTransmission);
            this.gboxPagamenti.Controls.Add(this.btnPaymentTransm);
            this.gboxPagamenti.Location = new System.Drawing.Point(3, 6);
            this.gboxPagamenti.Name = "gboxPagamenti";
            this.gboxPagamenti.Size = new System.Drawing.Size(943, 63);
            this.gboxPagamenti.TabIndex = 0;
            this.gboxPagamenti.TabStop = false;
            this.gboxPagamenti.Tag = "AutoChoose.txtNPaymentTransmission.lista.( ypaymenttransmission=%<esercizio>%)";
            this.gboxPagamenti.Text = "Trasmissione mandati";
            // 
            // btnGeneraFilePagamenti
            // 
            this.btnGeneraFilePagamenti.Location = new System.Drawing.Point(317, 19);
            this.btnGeneraFilePagamenti.Name = "btnGeneraFilePagamenti";
            this.btnGeneraFilePagamenti.Size = new System.Drawing.Size(193, 23);
            this.btnGeneraFilePagamenti.TabIndex = 4;
            this.btnGeneraFilePagamenti.Text = "Genera file trasmissione distinta";
            this.btnGeneraFilePagamenti.UseVisualStyleBackColor = true;
            this.btnGeneraFilePagamenti.Click += new System.EventHandler(this.btnGeneraFilePagamenti_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(178, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "N.";
            // 
            // txtNPaymentTransmission
            // 
            this.txtNPaymentTransmission.Location = new System.Drawing.Point(202, 21);
            this.txtNPaymentTransmission.Name = "txtNPaymentTransmission";
            this.txtNPaymentTransmission.Size = new System.Drawing.Size(100, 20);
            this.txtNPaymentTransmission.TabIndex = 2;
            this.txtNPaymentTransmission.Tag = "paymenttransmission.npaymenttransmission?paymenttransmission.npaymenttransmission" +
    "";
            // 
            // btnPaymentTransm
            // 
            this.btnPaymentTransm.Location = new System.Drawing.Point(13, 19);
            this.btnPaymentTransm.Name = "btnPaymentTransm";
            this.btnPaymentTransm.Size = new System.Drawing.Size(159, 23);
            this.btnPaymentTransm.TabIndex = 0;
            this.btnPaymentTransm.Tag = "choose.paymenttransmission.lista.( ypaymenttransmission=%<esercizio>%)";
            this.btnPaymentTransm.Text = "Elenco di Trasmissione";
            this.btnPaymentTransm.UseVisualStyleBackColor = true;
            // 
            // gboxIncassi
            // 
            this.gboxIncassi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxIncassi.Controls.Add(this.btnGeneraFileIncassi);
            this.gboxIncassi.Controls.Add(this.label2);
            this.gboxIncassi.Controls.Add(this.txtNproceedsTransm);
            this.gboxIncassi.Controls.Add(this.btnProceedsTransm);
            this.gboxIncassi.Location = new System.Drawing.Point(3, 75);
            this.gboxIncassi.Name = "gboxIncassi";
            this.gboxIncassi.Size = new System.Drawing.Size(943, 64);
            this.gboxIncassi.TabIndex = 1;
            this.gboxIncassi.TabStop = false;
            this.gboxIncassi.Tag = "AutoChoose.txtNproceedsTransm.lista.(yproceedstransmission=%<esercizio>%)";
            this.gboxIncassi.Text = "Trasmissione reversali";
            // 
            // btnGeneraFileIncassi
            // 
            this.btnGeneraFileIncassi.Location = new System.Drawing.Point(317, 19);
            this.btnGeneraFileIncassi.Name = "btnGeneraFileIncassi";
            this.btnGeneraFileIncassi.Size = new System.Drawing.Size(193, 23);
            this.btnGeneraFileIncassi.TabIndex = 6;
            this.btnGeneraFileIncassi.Text = "Genera file trasmissione distinta";
            this.btnGeneraFileIncassi.UseVisualStyleBackColor = true;
            this.btnGeneraFileIncassi.Click += new System.EventHandler(this.btnGeneraFileIncassi_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(178, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "N.";
            // 
            // txtNproceedsTransm
            // 
            this.txtNproceedsTransm.Location = new System.Drawing.Point(202, 21);
            this.txtNproceedsTransm.Name = "txtNproceedsTransm";
            this.txtNproceedsTransm.Size = new System.Drawing.Size(100, 20);
            this.txtNproceedsTransm.TabIndex = 4;
            this.txtNproceedsTransm.Tag = "proceedstransmission.nproceedstransmission?proceedstransmission.nproceedstransmis" +
    "sion";
            // 
            // btnProceedsTransm
            // 
            this.btnProceedsTransm.Location = new System.Drawing.Point(13, 19);
            this.btnProceedsTransm.Name = "btnProceedsTransm";
            this.btnProceedsTransm.Size = new System.Drawing.Size(159, 23);
            this.btnProceedsTransm.TabIndex = 1;
            this.btnProceedsTransm.Tag = "choose.proceedstransmission.lista.( yproceedstransmission=%<esercizio>%)";
            this.btnProceedsTransm.Text = "Elenco di Trasmissione";
            this.btnProceedsTransm.UseVisualStyleBackColor = true;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xml";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(660, 482);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gboxPagamenti);
            this.tabPage1.Controls.Add(this.gboxIncassi);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(652, 456);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Trasmissione distinte alla banca";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.webBrowser1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(652, 456);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "XML";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(21, 22);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(602, 392);
            this.webBrowser1.TabIndex = 1;
            // 
            // frmbankdispositionsetup_bccflumeri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 482);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmbankdispositionsetup_bccflumeri";
            this.Text = "frmbankdispositionsetup_bccflumeri";
            this.gboxPagamenti.ResumeLayout(false);
            this.gboxPagamenti.PerformLayout();
            this.gboxIncassi.ResumeLayout(false);
            this.gboxIncassi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gboxPagamenti;
        private System.Windows.Forms.GroupBox gboxIncassi;
        private System.Windows.Forms.Button btnPaymentTransm;
        private System.Windows.Forms.Button btnProceedsTransm;
        private System.Windows.Forms.TextBox txtNPaymentTransmission;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNproceedsTransm;
        private System.Windows.Forms.Button btnGeneraFilePagamenti;
        private System.Windows.Forms.Button btnGeneraFileIncassi;
        public vistaForm DS;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.WebBrowser webBrowser1;
    }
}