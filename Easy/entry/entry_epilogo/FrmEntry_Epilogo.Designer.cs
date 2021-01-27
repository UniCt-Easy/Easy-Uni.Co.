
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


namespace entry_epilogo {
    partial class FrmEntry_Epilogo {
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
            this.btnEpilogo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DS = new entry_epilogo.vistaForm();
            this.chkContoEconomico = new System.Windows.Forms.CheckBox();
            this.chkStatoPatrimoniale = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEpilogo
            // 
            this.btnEpilogo.Location = new System.Drawing.Point(436, 47);
            this.btnEpilogo.Name = "btnEpilogo";
            this.btnEpilogo.Size = new System.Drawing.Size(104, 23);
            this.btnEpilogo.TabIndex = 3;
            this.btnEpilogo.Text = "Inizia Epilogo";
            this.btnEpilogo.UseVisualStyleBackColor = true;
            this.btnEpilogo.Click += new System.EventHandler(this.btnEpilogo_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(540, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "PROCEDURA CHE EFFETTUA L\'EPILOGO DELLE SCRITTURE PER L\'ESERCIZIO IN CORSO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // chkContoEconomico
            // 
            this.chkContoEconomico.AutoSize = true;
            this.chkContoEconomico.Checked = true;
            this.chkContoEconomico.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkContoEconomico.Location = new System.Drawing.Point(6, 19);
            this.chkContoEconomico.Name = "chkContoEconomico";
            this.chkContoEconomico.Size = new System.Drawing.Size(110, 17);
            this.chkContoEconomico.TabIndex = 4;
            this.chkContoEconomico.Text = "Conto Economico";
            this.chkContoEconomico.UseVisualStyleBackColor = true;
            // 
            // chkStatoPatrimoniale
            // 
            this.chkStatoPatrimoniale.AutoSize = true;
            this.chkStatoPatrimoniale.Checked = true;
            this.chkStatoPatrimoniale.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStatoPatrimoniale.Location = new System.Drawing.Point(6, 50);
            this.chkStatoPatrimoniale.Name = "chkStatoPatrimoniale";
            this.chkStatoPatrimoniale.Size = new System.Drawing.Size(111, 17);
            this.chkStatoPatrimoniale.TabIndex = 5;
            this.chkStatoPatrimoniale.Text = "Stato Patrimoniale";
            this.chkStatoPatrimoniale.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkContoEconomico);
            this.groupBox1.Controls.Add(this.chkStatoPatrimoniale);
            this.groupBox1.Location = new System.Drawing.Point(12, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 85);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Scritture da generare";
            // 
            // FrmEntry_Epilogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 136);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnEpilogo);
            this.Controls.Add(this.label1);
            this.Name = "FrmEntry_Epilogo";
            this.Text = "FrmEntry_Epilogo";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEpilogo;
        private System.Windows.Forms.Label label1;
        public vistaForm DS;
        private System.Windows.Forms.CheckBox chkContoEconomico;
        private System.Windows.Forms.CheckBox chkStatoPatrimoniale;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
