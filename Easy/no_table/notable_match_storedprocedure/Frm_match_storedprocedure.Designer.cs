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

namespace notable_match_storedprocedure
{
    partial class Frm_match_storedprocedure
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
            this.DS = new notable_match_storedprocedure.vistaForm();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFields = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTime2 = new System.Windows.Forms.TextBox();
            this.txtTime1 = new System.Windows.Forms.TextBox();
            this.btnMatch = new System.Windows.Forms.Button();
            this.txFilterNewSP = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txFilterOldSP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNewSP = new System.Windows.Forms.TextBox();
            this.txtOldSP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtparameter = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridOldSP = new System.Windows.Forms.DataGrid();
            this.label6 = new System.Windows.Forms.Label();
            this.txtParamOld = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridNewSP = new System.Windows.Forms.DataGrid();
            this.label7 = new System.Windows.Forms.Label();
            this.txtParamNew = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOldSP)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridNewSP)).BeginInit();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(841, 502);
            this.tabControl1.TabIndex = 21;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.txtFields);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.txtTime2);
            this.tabPage1.Controls.Add(this.txtTime1);
            this.tabPage1.Controls.Add(this.btnMatch);
            this.tabPage1.Controls.Add(this.txFilterNewSP);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txFilterOldSP);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtNewSP);
            this.tabPage1.Controls.Add(this.txtOldSP);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtparameter);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(833, 476);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Principale";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 254);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(433, 13);
            this.label10.TabIndex = 37;
            this.label10.Text = "Elenco di campi da confrontare(Elencare i campi da confrontare separandoli con la" +
    " virgola)";
            // 
            // txtFields
            // 
            this.txtFields.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFields.Location = new System.Drawing.Point(9, 273);
            this.txtFields.Name = "txtFields";
            this.txtFields.Size = new System.Drawing.Size(818, 20);
            this.txtFields.TabIndex = 36;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(419, 376);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(140, 13);
            this.label9.TabIndex = 35;
            this.label9.Text = "Tempo esecuzione(secondi)";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 378);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(140, 13);
            this.label8.TabIndex = 34;
            this.label8.Text = "Tempo esecuzione(secondi)";
            // 
            // txtTime2
            // 
            this.txtTime2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTime2.Location = new System.Drawing.Point(565, 375);
            this.txtTime2.Name = "txtTime2";
            this.txtTime2.Size = new System.Drawing.Size(140, 20);
            this.txtTime2.TabIndex = 33;
            // 
            // txtTime1
            // 
            this.txtTime1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTime1.Location = new System.Drawing.Point(154, 375);
            this.txtTime1.Name = "txtTime1";
            this.txtTime1.Size = new System.Drawing.Size(140, 20);
            this.txtTime1.TabIndex = 32;
            // 
            // btnMatch
            // 
            this.btnMatch.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnMatch.Location = new System.Drawing.Point(334, 423);
            this.btnMatch.Name = "btnMatch";
            this.btnMatch.Size = new System.Drawing.Size(168, 41);
            this.btnMatch.TabIndex = 26;
            this.btnMatch.Text = "Confronta Risultati SP";
            this.btnMatch.UseVisualStyleBackColor = true;
            this.btnMatch.Click += new System.EventHandler(this.btnMatch_Click);
            // 
            // txFilterNewSP
            // 
            this.txFilterNewSP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txFilterNewSP.Location = new System.Drawing.Point(423, 339);
            this.txFilterNewSP.Name = "txFilterNewSP";
            this.txFilterNewSP.Size = new System.Drawing.Size(407, 20);
            this.txFilterNewSP.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(420, 316);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(259, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Filtro da applicare sulle righe di output della nuova SP";
            // 
            // txFilterOldSP
            // 
            this.txFilterOldSP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txFilterOldSP.Location = new System.Drawing.Point(11, 338);
            this.txFilterOldSP.Name = "txFilterOldSP";
            this.txFilterOldSP.Size = new System.Drawing.Size(405, 20);
            this.txFilterOldSP.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 316);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(267, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Filtro da applicare sulle righe di output della vecchia SP";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(423, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Nome della nuova SP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Nome della vecchia SP";
            // 
            // txtNewSP
            // 
            this.txtNewSP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNewSP.Location = new System.Drawing.Point(423, 34);
            this.txtNewSP.Name = "txtNewSP";
            this.txtNewSP.Size = new System.Drawing.Size(407, 20);
            this.txtNewSP.TabIndex = 22;
            // 
            // txtOldSP
            // 
            this.txtOldSP.Location = new System.Drawing.Point(9, 35);
            this.txtOldSP.Name = "txtOldSP";
            this.txtOldSP.Size = new System.Drawing.Size(407, 20);
            this.txtOldSP.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Parametri con cui eseguire le SP";
            // 
            // txtparameter
            // 
            this.txtparameter.AcceptsReturn = true;
            this.txtparameter.AcceptsTab = true;
            this.txtparameter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtparameter.Location = new System.Drawing.Point(6, 90);
            this.txtparameter.Multiline = true;
            this.txtparameter.Name = "txtparameter";
            this.txtparameter.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtparameter.Size = new System.Drawing.Size(824, 149);
            this.txtparameter.TabIndex = 23;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridOldSP);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.txtParamOld);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(833, 476);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Vecchia SP";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridOldSP
            // 
            this.dataGridOldSP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridOldSP.DataMember = "";
            this.dataGridOldSP.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridOldSP.Location = new System.Drawing.Point(3, 37);
            this.dataGridOldSP.Name = "dataGridOldSP";
            this.dataGridOldSP.Size = new System.Drawing.Size(832, 411);
            this.dataGridOldSP.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Parametri della chiama";
            // 
            // txtParamOld
            // 
            this.txtParamOld.Location = new System.Drawing.Point(165, 9);
            this.txtParamOld.Name = "txtParamOld";
            this.txtParamOld.Size = new System.Drawing.Size(393, 20);
            this.txtParamOld.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridNewSP);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.txtParamNew);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(833, 476);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Nuova SP";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridNewSP
            // 
            this.dataGridNewSP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridNewSP.DataMember = "";
            this.dataGridNewSP.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridNewSP.Location = new System.Drawing.Point(3, 35);
            this.dataGridNewSP.Name = "dataGridNewSP";
            this.dataGridNewSP.Size = new System.Drawing.Size(835, 416);
            this.dataGridNewSP.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Parametri della chiama";
            // 
            // txtParamNew
            // 
            this.txtParamNew.Location = new System.Drawing.Point(166, 9);
            this.txtParamNew.Name = "txtParamNew";
            this.txtParamNew.Size = new System.Drawing.Size(369, 20);
            this.txtParamNew.TabIndex = 1;
            // 
            // Frm_match_storedprocedure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 520);
            this.Controls.Add(this.tabControl1);
            this.Name = "Frm_match_storedprocedure";
            this.Text = "Frm_match_storedprocedure";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOldSP)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridNewSP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnMatch;
        private System.Windows.Forms.TextBox txFilterNewSP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txFilterOldSP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNewSP;
        private System.Windows.Forms.TextBox txtOldSP;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtparameter;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtParamOld;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtParamNew;
        private System.Windows.Forms.DataGrid dataGridOldSP;
        private System.Windows.Forms.DataGrid dataGridNewSP;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTime2;
        private System.Windows.Forms.TextBox txtTime1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtFields;

    }
}