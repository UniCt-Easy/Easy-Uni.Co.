
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


namespace allowanceruledetail_single {
    partial class Frm_allowanceruledetail_single {
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
			this.DS = new allowanceruledetail_single.vistaForm();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.btnAnnulla = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.txtLivello = new System.Windows.Forms.TextBox();
			this.labelLivello = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(83, 15);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(49, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Dettaglio";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(131, 12);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(106, 20);
			this.textBox2.TabIndex = 3;
			this.textBox2.Tag = "allowanceruledetail.iddetail";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(5, 51);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Qualifica";
			// 
			// comboBox1
			// 
			this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBox1.DataSource = this.DS.position;
			this.comboBox1.DisplayMember = "description";
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(53, 48);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(266, 21);
			this.comboBox1.TabIndex = 5;
			this.comboBox1.Tag = "allowanceruledetail.idposition";
			this.comboBox1.ValueMember = "idposition";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.textBox4);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.textBox3);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Location = new System.Drawing.Point(8, 112);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(313, 47);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Classe stipendiale";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(199, 19);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(106, 20);
			this.textBox4.TabIndex = 3;
			this.textBox4.Tag = "allowanceruledetail.maxincomeclass";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(151, 22);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(48, 13);
			this.label5.TabIndex = 2;
			this.label5.Text = "Massimo";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(45, 19);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(100, 20);
			this.textBox3.TabIndex = 1;
			this.textBox3.Tag = "allowanceruledetail.minincomeclass";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 22);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(40, 13);
			this.label4.TabIndex = 0;
			this.label4.Text = "Minimo";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(11, 180);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(42, 13);
			this.label6.TabIndex = 7;
			this.label6.Text = "Importo";
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(53, 177);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(100, 20);
			this.textBox5.TabIndex = 8;
			this.textBox5.Tag = "allowanceruledetail.amount";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(159, 180);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(69, 13);
			this.label7.TabIndex = 9;
			this.label7.Text = "Perc.anticipo";
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(226, 177);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(87, 20);
			this.textBox6.TabIndex = 10;
			this.textBox6.Tag = "allowanceruledetail.advancepercentage.fixed.2..%.100";
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnAnnulla.Location = new System.Drawing.Point(241, 216);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.Size = new System.Drawing.Size(72, 24);
			this.btnAnnulla.TabIndex = 15;
			this.btnAnnulla.Text = "Annulla";
			// 
			// btnOk
			// 
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(145, 216);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(72, 24);
			this.btnOk.TabIndex = 14;
			this.btnOk.Tag = "mainsave";
			this.btnOk.Text = "OK";
			// 
			// txtLivello
			// 
			this.txtLivello.Location = new System.Drawing.Point(53, 79);
			this.txtLivello.Name = "txtLivello";
			this.txtLivello.Size = new System.Drawing.Size(100, 20);
			this.txtLivello.TabIndex = 17;
			this.txtLivello.Tag = "allowanceruledetail.livello";
			// 
			// labelLivello
			// 
			this.labelLivello.AutoSize = true;
			this.labelLivello.Location = new System.Drawing.Point(11, 82);
			this.labelLivello.Name = "labelLivello";
			this.labelLivello.Size = new System.Drawing.Size(37, 13);
			this.labelLivello.TabIndex = 16;
			this.labelLivello.Text = "Livello";
			// 
			// Frm_allowanceruledetail_single
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnAnnulla;
			this.ClientSize = new System.Drawing.Size(331, 261);
			this.Controls.Add(this.txtLivello);
			this.Controls.Add(this.labelLivello);
			this.Controls.Add(this.btnAnnulla);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.textBox6);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.textBox5);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label2);
			this.Name = "Frm_allowanceruledetail_single";
			this.Text = "Frm_allowanceruledetail_single";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.TextBox txtLivello;
		private System.Windows.Forms.Label labelLivello;
	}
}
