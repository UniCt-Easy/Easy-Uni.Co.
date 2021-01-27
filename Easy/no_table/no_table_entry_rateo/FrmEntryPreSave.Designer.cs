
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


namespace no_table_entry_rateo {
    partial class FrmEntryPreSave {
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dgRatPassivi = new System.Windows.Forms.DataGrid();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtTotRPassivi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtTotFattRic = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgFattRicevere = new System.Windows.Forms.DataGrid();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtTotRAttivi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgRatAttivi = new System.Windows.Forms.DataGrid();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.txtTotFattEmettere = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgFattEmettere = new System.Windows.Forms.DataGrid();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.txtTotRateiParcelle = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgRateiParcelle = new System.Windows.Forms.DataGrid();
            this.txtTotParcelleRicevere = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dgParcelleRicevere = new System.Windows.Forms.DataGrid();
            ((System.ComponentModel.ISupportInitialize)(this.dgRatPassivi)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFattRicevere)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRatAttivi)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFattEmettere)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRateiParcelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgParcelleRicevere)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(843, 409);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Annulla";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(734, 409);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dgRatPassivi
            // 
            this.dgRatPassivi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgRatPassivi.DataMember = "";
            this.dgRatPassivi.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgRatPassivi.Location = new System.Drawing.Point(6, 35);
            this.dgRatPassivi.Name = "dgRatPassivi";
            this.dgRatPassivi.Size = new System.Drawing.Size(886, 324);
            this.dgRatPassivi.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(906, 391);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtTotRPassivi);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.dgRatPassivi);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(898, 365);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Ratei passivi su ordini";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtTotRPassivi
            // 
            this.txtTotRPassivi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotRPassivi.Location = new System.Drawing.Point(788, 9);
            this.txtTotRPassivi.Name = "txtTotRPassivi";
            this.txtTotRPassivi.ReadOnly = true;
            this.txtTotRPassivi.Size = new System.Drawing.Size(100, 20);
            this.txtTotRPassivi.TabIndex = 11;
            this.txtTotRPassivi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(742, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Saldo:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtTotFattRic);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.dgFattRicevere);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(898, 365);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Fatture da ricevere su ordini";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtTotFattRic
            // 
            this.txtTotFattRic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotFattRic.Location = new System.Drawing.Point(788, 13);
            this.txtTotFattRic.Name = "txtTotFattRic";
            this.txtTotFattRic.ReadOnly = true;
            this.txtTotFattRic.Size = new System.Drawing.Size(100, 20);
            this.txtTotFattRic.TabIndex = 13;
            this.txtTotFattRic.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(742, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Saldo:";
            // 
            // dgFattRicevere
            // 
            this.dgFattRicevere.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgFattRicevere.DataMember = "";
            this.dgFattRicevere.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgFattRicevere.Location = new System.Drawing.Point(6, 39);
            this.dgFattRicevere.Name = "dgFattRicevere";
            this.dgFattRicevere.Size = new System.Drawing.Size(886, 320);
            this.dgFattRicevere.TabIndex = 6;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtTotRAttivi);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.dgRatAttivi);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(898, 365);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Ratei attivi";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtTotRAttivi
            // 
            this.txtTotRAttivi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotRAttivi.Location = new System.Drawing.Point(790, 8);
            this.txtTotRAttivi.Name = "txtTotRAttivi";
            this.txtTotRAttivi.ReadOnly = true;
            this.txtTotRAttivi.Size = new System.Drawing.Size(100, 20);
            this.txtTotRAttivi.TabIndex = 13;
            this.txtTotRAttivi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(744, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Saldo:";
            // 
            // dgRatAttivi
            // 
            this.dgRatAttivi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgRatAttivi.DataMember = "";
            this.dgRatAttivi.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgRatAttivi.Location = new System.Drawing.Point(6, 38);
            this.dgRatAttivi.Name = "dgRatAttivi";
            this.dgRatAttivi.Size = new System.Drawing.Size(886, 321);
            this.dgRatAttivi.TabIndex = 6;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.txtTotFattEmettere);
            this.tabPage4.Controls.Add(this.label4);
            this.tabPage4.Controls.Add(this.dgFattEmettere);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(898, 365);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Fatture da emettere";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // txtTotFattEmettere
            // 
            this.txtTotFattEmettere.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotFattEmettere.Location = new System.Drawing.Point(790, 15);
            this.txtTotFattEmettere.Name = "txtTotFattEmettere";
            this.txtTotFattEmettere.ReadOnly = true;
            this.txtTotFattEmettere.Size = new System.Drawing.Size(100, 20);
            this.txtTotFattEmettere.TabIndex = 13;
            this.txtTotFattEmettere.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(744, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Saldo:";
            // 
            // dgFattEmettere
            // 
            this.dgFattEmettere.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgFattEmettere.DataMember = "";
            this.dgFattEmettere.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgFattEmettere.Location = new System.Drawing.Point(6, 41);
            this.dgFattEmettere.Name = "dgFattEmettere";
            this.dgFattEmettere.Size = new System.Drawing.Size(886, 318);
            this.dgFattEmettere.TabIndex = 6;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.txtTotRateiParcelle);
            this.tabPage5.Controls.Add(this.label5);
            this.tabPage5.Controls.Add(this.dgRateiParcelle);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(898, 365);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Ratei passivi su parcelle";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.txtTotParcelleRicevere);
            this.tabPage6.Controls.Add(this.label6);
            this.tabPage6.Controls.Add(this.dgParcelleRicevere);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(898, 365);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Fatture da ricevere su parcelle";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // txtTotRateiParcelle
            // 
            this.txtTotRateiParcelle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotRateiParcelle.Location = new System.Drawing.Point(788, 7);
            this.txtTotRateiParcelle.Name = "txtTotRateiParcelle";
            this.txtTotRateiParcelle.ReadOnly = true;
            this.txtTotRateiParcelle.Size = new System.Drawing.Size(100, 20);
            this.txtTotRateiParcelle.TabIndex = 14;
            this.txtTotRateiParcelle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(742, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Saldo:";
            // 
            // dgRateiParcelle
            // 
            this.dgRateiParcelle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgRateiParcelle.DataMember = "";
            this.dgRateiParcelle.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgRateiParcelle.Location = new System.Drawing.Point(6, 33);
            this.dgRateiParcelle.Name = "dgRateiParcelle";
            this.dgRateiParcelle.Size = new System.Drawing.Size(886, 324);
            this.dgRateiParcelle.TabIndex = 12;
            // 
            // txtTotParcelleRicevere
            // 
            this.txtTotParcelleRicevere.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotParcelleRicevere.Location = new System.Drawing.Point(788, 7);
            this.txtTotParcelleRicevere.Name = "txtTotParcelleRicevere";
            this.txtTotParcelleRicevere.ReadOnly = true;
            this.txtTotParcelleRicevere.Size = new System.Drawing.Size(100, 20);
            this.txtTotParcelleRicevere.TabIndex = 14;
            this.txtTotParcelleRicevere.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(742, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Saldo:";
            // 
            // dgParcelleRicevere
            // 
            this.dgParcelleRicevere.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgParcelleRicevere.DataMember = "";
            this.dgParcelleRicevere.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgParcelleRicevere.Location = new System.Drawing.Point(6, 33);
            this.dgParcelleRicevere.Name = "dgParcelleRicevere";
            this.dgParcelleRicevere.Size = new System.Drawing.Size(886, 324);
            this.dgParcelleRicevere.TabIndex = 12;
            // 
            // FrmEntryPreSave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 446);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "FrmEntryPreSave";
            this.Text = "FrmEntryPreSave";
            ((System.ComponentModel.ISupportInitialize)(this.dgRatPassivi)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFattRicevere)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRatAttivi)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFattEmettere)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRateiParcelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgParcelleRicevere)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGrid dgRatPassivi;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtTotRPassivi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotFattRic;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGrid dgFattRicevere;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txtTotRAttivi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGrid dgRatAttivi;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox txtTotFattEmettere;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGrid dgFattEmettere;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TextBox txtTotRateiParcelle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGrid dgRateiParcelle;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TextBox txtTotParcelleRicevere;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGrid dgParcelleRicevere;
    }
}
