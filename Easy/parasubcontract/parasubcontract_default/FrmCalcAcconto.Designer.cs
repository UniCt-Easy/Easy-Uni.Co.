
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


namespace parasubcontract_default {
    partial class FrmCalcAcconto {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            inChiusura = true;
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
            this.lblRedditoComplessivo = new System.Windows.Forms.Label();
            this.txtRedditoComplessivo = new System.Windows.Forms.TextBox();
            this.txtComuneResidenza = new System.Windows.Forms.TextBox();
            this.txtAcconto = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblRedditoComplessivo
            // 
            this.lblRedditoComplessivo.Location = new System.Drawing.Point(12, 9);
            this.lblRedditoComplessivo.Name = "lblRedditoComplessivo";
            this.lblRedditoComplessivo.Size = new System.Drawing.Size(351, 59);
            this.lblRedditoComplessivo.TabIndex = 0;
            this.lblRedditoComplessivo.Text = "Abbiamo stimato che il reddito complessivo per l\'esercizio XXX sia pari a € yyy. " +
                "Il calcolo è stato fatto tenendo sommando gli imponibili fiscali delle prestazio" +
                "ni pagate al percipiente.";
            // 
            // txtRedditoComplessivo
            // 
            this.txtRedditoComplessivo.Location = new System.Drawing.Point(169, 149);
            this.txtRedditoComplessivo.Name = "txtRedditoComplessivo";
            this.txtRedditoComplessivo.Size = new System.Drawing.Size(185, 20);
            this.txtRedditoComplessivo.TabIndex = 1;
            this.txtRedditoComplessivo.Leave += new System.EventHandler(this.txtRedditoComplessivo_Leave);
            // 
            // txtComuneResidenza
            // 
            this.txtComuneResidenza.Location = new System.Drawing.Point(169, 175);
            this.txtComuneResidenza.Name = "txtComuneResidenza";
            this.txtComuneResidenza.ReadOnly = true;
            this.txtComuneResidenza.Size = new System.Drawing.Size(184, 20);
            this.txtComuneResidenza.TabIndex = 2;
            // 
            // txtAcconto
            // 
            this.txtAcconto.Location = new System.Drawing.Point(169, 201);
            this.txtAcconto.Name = "txtAcconto";
            this.txtAcconto.ReadOnly = true;
            this.txtAcconto.Size = new System.Drawing.Size(185, 20);
            this.txtAcconto.TabIndex = 3;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(200, 231);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(281, 231);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 5;
            this.btnAnnulla.Text = "Annulla";
            this.btnAnnulla.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(33, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Reddito Complessivo:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(49, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 32);
            this.label3.TabIndex = 7;
            this.label3.Text = "Comune di Residenza:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(62, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Acconto:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(339, 45);
            this.label1.TabIndex = 9;
            this.label1.Text = "Per effettuare il calcolo dell\'acconto bisogna necessariamente inserire il reddit" +
                "o complessivo nella casella di testo";
            // 
            // FrmCalcAcconto
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 266);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtAcconto);
            this.Controls.Add(this.txtComuneResidenza);
            this.Controls.Add(this.txtRedditoComplessivo);
            this.Controls.Add(this.lblRedditoComplessivo);
            this.Name = "FrmCalcAcconto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Calcola Acconto";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRedditoComplessivo;
        private System.Windows.Forms.TextBox txtRedditoComplessivo;
        private System.Windows.Forms.TextBox txtComuneResidenza;
        private System.Windows.Forms.TextBox txtAcconto;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
    }
}
