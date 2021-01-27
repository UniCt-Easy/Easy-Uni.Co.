
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


namespace inventorytree_uniforma {
    partial class FrmInventoryTree_Uniforma {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInventoryTree_Uniforma));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClassSup = new System.Windows.Forms.Button();
            this.btnUniforma = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.DS = new inventorytree_uniforma.vistaForm();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fase 1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fase 2";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnClassSup
            // 
            this.btnClassSup.Location = new System.Drawing.Point(75, 12);
            this.btnClassSup.Name = "btnClassSup";
            this.btnClassSup.Size = new System.Drawing.Size(154, 38);
            this.btnClassSup.TabIndex = 3;
            this.btnClassSup.Text = "Esegui script classificazione alla class. inv.";
            this.btnClassSup.UseVisualStyleBackColor = true;
            this.btnClassSup.Click += new System.EventHandler(this.btnClassSup_Click);
            // 
            // btnUniforma
            // 
            this.btnUniforma.Location = new System.Drawing.Point(75, 78);
            this.btnUniforma.Name = "btnUniforma";
            this.btnUniforma.Size = new System.Drawing.Size(154, 35);
            this.btnUniforma.TabIndex = 4;
            this.btnUniforma.Text = "Uniforma Riferimenti";
            this.btnUniforma.UseVisualStyleBackColor = true;
            this.btnUniforma.Click += new System.EventHandler(this.btnUniforma_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(235, 15);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(338, 35);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "In questa fase viene installata la classificazione della classificazione inventar" +
                "iale";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(235, 78);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(338, 51);
            this.textBox2.TabIndex = 7;
            this.textBox2.Text = "In questa fase vengono uniformate tutte le tabelle dove la classificazione invent" +
                "ariale è stata adoperata. Successivamente viene installata la classificazione in" +
                "ventariale uniformata.";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // FrmInventoryTree_Uniforma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 142);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnUniforma);
            this.Controls.Add(this.btnClassSup);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmInventoryTree_Uniforma";
            this.Text = "FrmInventoryTree_Uniforma";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClassSup;
        private System.Windows.Forms.Button btnUniforma;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        public vistaForm DS;
    }
}
