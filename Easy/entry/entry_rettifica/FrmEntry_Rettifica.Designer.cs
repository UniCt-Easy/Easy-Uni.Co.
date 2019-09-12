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

namespace entry_rettifica {
    partial class FrmEntry_Rettifica {
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
            this.DS = new entry_rettifica.vistaForm();
            this.btnRettifica = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.chkCommerciale = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPluriennali = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // btnRettifica
            // 
            this.btnRettifica.Location = new System.Drawing.Point(371, 60);
            this.btnRettifica.Name = "btnRettifica";
            this.btnRettifica.Size = new System.Drawing.Size(104, 23);
            this.btnRettifica.TabIndex = 3;
            this.btnRettifica.Text = "Inizia Rettifica";
            this.btnRettifica.UseVisualStyleBackColor = true;
            this.btnRettifica.Click += new System.EventHandler(this.btnRettifica_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(59, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(403, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "PROCEDURA CHE RETTIFICA I COSTI/RICAVI CON COMPETENZA OLTRE L\'ESERCIZIO CORRENTE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // chkCommerciale
            // 
            this.chkCommerciale.AutoSize = true;
            this.chkCommerciale.Location = new System.Drawing.Point(25, 59);
            this.chkCommerciale.Name = "chkCommerciale";
            this.chkCommerciale.Size = new System.Drawing.Size(204, 17);
            this.chkCommerciale.TabIndex = 4;
            this.chkCommerciale.Text = "Assumi Anno commerciale (360 giorni)";
            this.chkCommerciale.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(41, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(403, 35);
            this.label2.TabIndex = 5;
            this.label2.Text = "PROCEDURA ASSESTAMENTO PROGETTI PLURIENNALI";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnPluriennali
            // 
            this.btnPluriennali.Location = new System.Drawing.Point(303, 161);
            this.btnPluriennali.Name = "btnPluriennali";
            this.btnPluriennali.Size = new System.Drawing.Size(172, 23);
            this.btnPluriennali.TabIndex = 6;
            this.btnPluriennali.Text = "Inizia assestamento";
            this.btnPluriennali.UseVisualStyleBackColor = true;
            this.btnPluriennali.Click += new System.EventHandler(this.btnPluriennali_Click);
            // 
            // FrmEntry_Rettifica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 214);
            this.Controls.Add(this.btnPluriennali);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkCommerciale);
            this.Controls.Add(this.btnRettifica);
            this.Controls.Add(this.label1);
            this.Name = "FrmEntry_Rettifica";
            this.Text = "FrmEntry_Rettifica";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.Button btnRettifica;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkCommerciale;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPluriennali;

    }
}