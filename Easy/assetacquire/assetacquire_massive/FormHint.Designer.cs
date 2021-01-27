
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


namespace assetacquire_massive {
    partial class FormHint {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Liberare le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent() {
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.IvaDet3 = new System.Windows.Forms.TextBox();
            this.Iva3 = new System.Windows.Forms.TextBox();
            this.Q3 = new System.Windows.Forms.TextBox();
            this.IvaDet2 = new System.Windows.Forms.TextBox();
            this.Iva2 = new System.Windows.Forms.TextBox();
            this.Q2 = new System.Windows.Forms.TextBox();
            this.IvaDet1 = new System.Windows.Forms.TextBox();
            this.Iva1 = new System.Windows.Forms.TextBox();
            this.Q1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(2, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(328, 40);
            this.label5.TabIndex = 29;
            this.label5.Text = "Può essere importante per fare quadrare le imposte unitarie con quelle totali";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(114, 193);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 28;
            this.button1.Text = "Chiudi";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // IvaDet3
            // 
            this.IvaDet3.Location = new System.Drawing.Point(218, 153);
            this.IvaDet3.Name = "IvaDet3";
            this.IvaDet3.ReadOnly = true;
            this.IvaDet3.Size = new System.Drawing.Size(100, 20);
            this.IvaDet3.TabIndex = 27;
            this.IvaDet3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.IvaDet3.Visible = false;
            // 
            // Iva3
            // 
            this.Iva3.Location = new System.Drawing.Point(114, 153);
            this.Iva3.Name = "Iva3";
            this.Iva3.ReadOnly = true;
            this.Iva3.Size = new System.Drawing.Size(100, 20);
            this.Iva3.TabIndex = 26;
            this.Iva3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Iva3.Visible = false;
            // 
            // Q3
            // 
            this.Q3.Location = new System.Drawing.Point(10, 153);
            this.Q3.Name = "Q3";
            this.Q3.ReadOnly = true;
            this.Q3.Size = new System.Drawing.Size(100, 20);
            this.Q3.TabIndex = 25;
            this.Q3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Q3.Visible = false;
            // 
            // IvaDet2
            // 
            this.IvaDet2.Location = new System.Drawing.Point(218, 121);
            this.IvaDet2.Name = "IvaDet2";
            this.IvaDet2.ReadOnly = true;
            this.IvaDet2.Size = new System.Drawing.Size(100, 20);
            this.IvaDet2.TabIndex = 24;
            this.IvaDet2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.IvaDet2.Visible = false;
            // 
            // Iva2
            // 
            this.Iva2.Location = new System.Drawing.Point(114, 121);
            this.Iva2.Name = "Iva2";
            this.Iva2.ReadOnly = true;
            this.Iva2.Size = new System.Drawing.Size(100, 20);
            this.Iva2.TabIndex = 23;
            this.Iva2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Iva2.Visible = false;
            // 
            // Q2
            // 
            this.Q2.Location = new System.Drawing.Point(10, 121);
            this.Q2.Name = "Q2";
            this.Q2.ReadOnly = true;
            this.Q2.Size = new System.Drawing.Size(100, 20);
            this.Q2.TabIndex = 22;
            this.Q2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Q2.Visible = false;
            // 
            // IvaDet1
            // 
            this.IvaDet1.Location = new System.Drawing.Point(218, 89);
            this.IvaDet1.Name = "IvaDet1";
            this.IvaDet1.ReadOnly = true;
            this.IvaDet1.Size = new System.Drawing.Size(100, 20);
            this.IvaDet1.TabIndex = 21;
            this.IvaDet1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Iva1
            // 
            this.Iva1.Location = new System.Drawing.Point(114, 89);
            this.Iva1.Name = "Iva1";
            this.Iva1.ReadOnly = true;
            this.Iva1.Size = new System.Drawing.Size(100, 20);
            this.Iva1.TabIndex = 20;
            this.Iva1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Q1
            // 
            this.Q1.Location = new System.Drawing.Point(10, 89);
            this.Q1.Name = "Q1";
            this.Q1.ReadOnly = true;
            this.Q1.Size = new System.Drawing.Size(100, 20);
            this.Q1.TabIndex = 19;
            this.Q1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(218, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 16);
            this.label4.TabIndex = 18;
            this.label4.Text = "Iva Detraibile";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(114, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "Iva";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(10, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "Quantità";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(2, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "Suggerimento su come effettuare il carico";
            // 
            // FormHint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 241);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.IvaDet3);
            this.Controls.Add(this.Iva3);
            this.Controls.Add(this.Q3);
            this.Controls.Add(this.IvaDet2);
            this.Controls.Add(this.Iva2);
            this.Controls.Add(this.Q2);
            this.Controls.Add(this.IvaDet1);
            this.Controls.Add(this.Iva1);
            this.Controls.Add(this.Q1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormHint";
            this.Text = "Suggerimenti";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox IvaDet3;
        private System.Windows.Forms.TextBox Iva3;
        private System.Windows.Forms.TextBox Q3;
        private System.Windows.Forms.TextBox IvaDet2;
        private System.Windows.Forms.TextBox Iva2;
        private System.Windows.Forms.TextBox Q2;
        private System.Windows.Forms.TextBox IvaDet1;
        private System.Windows.Forms.TextBox Iva1;
        private System.Windows.Forms.TextBox Q1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
