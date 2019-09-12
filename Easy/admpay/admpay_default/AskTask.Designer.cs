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

namespace admpay_default {
    partial class AskTask {
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
            this.btnLordi = new System.Windows.Forms.Button();
            this.btnReversali = new System.Windows.Forms.Button();
            this.btnContributi = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLordi
            // 
            this.btnLordi.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnLordi.Location = new System.Drawing.Point(12, 12);
            this.btnLordi.Name = "btnLordi";
            this.btnLordi.Size = new System.Drawing.Size(186, 23);
            this.btnLordi.TabIndex = 0;
            this.btnLordi.Text = "Generazione Lordi";
            this.btnLordi.UseVisualStyleBackColor = true;
            this.btnLordi.Click += new System.EventHandler(this.btnLordi_Click);
            // 
            // btnReversali
            // 
            this.btnReversali.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnReversali.Location = new System.Drawing.Point(12, 51);
            this.btnReversali.Name = "btnReversali";
            this.btnReversali.Size = new System.Drawing.Size(186, 23);
            this.btnReversali.TabIndex = 1;
            this.btnReversali.Text = "Generazione Reversali Ritenute";
            this.btnReversali.UseVisualStyleBackColor = true;
            this.btnReversali.Click += new System.EventHandler(this.btnReversali_Click);
            // 
            // btnContributi
            // 
            this.btnContributi.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnContributi.Location = new System.Drawing.Point(12, 89);
            this.btnContributi.Name = "btnContributi";
            this.btnContributi.Size = new System.Drawing.Size(186, 23);
            this.btnContributi.TabIndex = 2;
            this.btnContributi.Text = "Generazione Versamenti";
            this.btnContributi.UseVisualStyleBackColor = true;
            this.btnContributi.Click += new System.EventHandler(this.btnContributi_Click);
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(12, 128);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(186, 23);
            this.btnAnnulla.TabIndex = 3;
            this.btnAnnulla.Text = "Annulla";
            this.btnAnnulla.UseVisualStyleBackColor = true;
            // 
            // AskTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 158);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnContributi);
            this.Controls.Add(this.btnReversali);
            this.Controls.Add(this.btnLordi);
            this.Name = "AskTask";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Scelta dell\'operazione";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLordi;
        private System.Windows.Forms.Button btnReversali;
        private System.Windows.Forms.Button btnContributi;
        private System.Windows.Forms.Button btnAnnulla;
    }
}