
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


namespace securitycondition_default {
    partial class FrmSecurityCondition_Default {
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
            this.DS = new securitycondition_default.vistaForm();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxConsenti = new System.Windows.Forms.TextBox();
            this.txtBoxDivieto = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbVieta = new System.Windows.Forms.RadioButton();
            this.rdbConsenti = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // comboBox2
            // 
            this.comboBox2.DataSource = this.DS.customgroup;
            this.comboBox2.DisplayMember = "description";
            this.comboBox2.Location = new System.Drawing.Point(104, 84);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(320, 21);
            this.comboBox2.TabIndex = 4;
            this.comboBox2.Tag = "securitycondition.idcustomgroup";
            this.comboBox2.ValueMember = "idcustomgroup";
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.DS.customobject;
            this.comboBox1.DisplayMember = "objectname";
            this.comboBox1.Location = new System.Drawing.Point(104, 58);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(320, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.Tag = "securitycondition.tablename";
            this.comboBox1.ValueMember = "objectname";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 16);
            this.label4.TabIndex = 28;
            this.label4.Text = "Condizione di consenti:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 297);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 16);
            this.label1.TabIndex = 27;
            this.label1.Text = "Condizione di divieto:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBoxConsenti
            // 
            this.txtBoxConsenti.AcceptsReturn = true;
            this.txtBoxConsenti.AcceptsTab = true;
            this.txtBoxConsenti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxConsenti.Location = new System.Drawing.Point(136, 193);
            this.txtBoxConsenti.Multiline = true;
            this.txtBoxConsenti.Name = "txtBoxConsenti";
            this.txtBoxConsenti.Size = new System.Drawing.Size(288, 96);
            this.txtBoxConsenti.TabIndex = 7;
            this.txtBoxConsenti.Tag = "securitycondition.allowcondition";
            // 
            // txtBoxDivieto
            // 
            this.txtBoxDivieto.AcceptsReturn = true;
            this.txtBoxDivieto.AcceptsTab = true;
            this.txtBoxDivieto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxDivieto.Location = new System.Drawing.Point(136, 297);
            this.txtBoxDivieto.Multiline = true;
            this.txtBoxDivieto.Name = "txtBoxDivieto";
            this.txtBoxDivieto.Size = new System.Drawing.Size(288, 96);
            this.txtBoxDivieto.TabIndex = 8;
            this.txtBoxDivieto.Tag = "securitycondition.denycondition";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton6);
            this.groupBox2.Controls.Add(this.radioButton5);
            this.groupBox2.Controls.Add(this.radioButton4);
            this.groupBox2.Controls.Add(this.radioButton3);
            this.groupBox2.Location = new System.Drawing.Point(19, 115);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(176, 72);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Operazione";
            // 
            // radioButton6
            // 
            this.radioButton6.Location = new System.Drawing.Point(16, 48);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(72, 16);
            this.radioButton6.TabIndex = 2;
            this.radioButton6.Tag = "securitycondition.operation:D";
            this.radioButton6.Text = "Cancella";
            // 
            // radioButton5
            // 
            this.radioButton5.Location = new System.Drawing.Point(96, 48);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(72, 16);
            this.radioButton5.TabIndex = 3;
            this.radioButton5.Tag = "securitycondition.operation:U";
            this.radioButton5.Text = "Modifica";
            // 
            // radioButton4
            // 
            this.radioButton4.Location = new System.Drawing.Point(96, 24);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(72, 16);
            this.radioButton4.TabIndex = 1;
            this.radioButton4.Tag = "securitycondition.operation:S";
            this.radioButton4.Text = "Seleziona";
            // 
            // radioButton3
            // 
            this.radioButton3.Location = new System.Drawing.Point(16, 24);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(72, 16);
            this.radioButton3.TabIndex = 0;
            this.radioButton3.Tag = "securitycondition.operation:I";
            this.radioButton3.Text = "Inserisci";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbVieta);
            this.groupBox1.Controls.Add(this.rdbConsenti);
            this.groupBox1.Location = new System.Drawing.Point(227, 115);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(104, 72);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Default";
            // 
            // rdbVieta
            // 
            this.rdbVieta.Location = new System.Drawing.Point(16, 24);
            this.rdbVieta.Name = "rdbVieta";
            this.rdbVieta.Size = new System.Drawing.Size(72, 16);
            this.rdbVieta.TabIndex = 0;
            this.rdbVieta.Tag = "securitycondition.defaultisdeny:S";
            this.rdbVieta.Text = "Vieta";
            this.rdbVieta.CheckedChanged += new System.EventHandler(this.rdbVieta_CheckedChanged);
            // 
            // rdbConsenti
            // 
            this.rdbConsenti.Location = new System.Drawing.Point(16, 48);
            this.rdbConsenti.Name = "rdbConsenti";
            this.rdbConsenti.Size = new System.Drawing.Size(72, 16);
            this.rdbConsenti.TabIndex = 1;
            this.rdbConsenti.Tag = "securitycondition.defaultisdeny:N";
            this.rdbConsenti.Text = "Consenti";
            this.rdbConsenti.CheckedChanged += new System.EventHandler(this.rdbConsenti_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 21);
            this.label3.TabIndex = 26;
            this.label3.Text = "Nome tabella:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 16);
            this.label2.TabIndex = 25;
            this.label2.Text = "Codice gruppo:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBox3
            // 
            this.comboBox3.DataSource = this.DS.restrictedfunction;
            this.comboBox3.DisplayMember = "description";
            this.comboBox3.Location = new System.Drawing.Point(104, 31);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(320, 21);
            this.comboBox3.TabIndex = 2;
            this.comboBox3.Tag = "securitycondition.idrestrictedfunction";
            this.comboBox3.ValueMember = "idrestrictedfunction";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 21);
            this.label5.TabIndex = 31;
            this.label5.Text = "Funzione di Restr.:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(3, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 21);
            this.label6.TabIndex = 32;
            this.label6.Text = "ID Condizione.:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(104, 7);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(133, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Tag = "securitycondition.idsecuritycondition";
            // 
            // FrmSecurityCondition_Default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 403);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBoxConsenti);
            this.Controls.Add(this.txtBoxDivieto);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "FrmSecurityCondition_Default";
            this.Text = "FrmSecurityCondition_Default";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxConsenti;
        private System.Windows.Forms.TextBox txtBoxDivieto;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbVieta;
        private System.Windows.Forms.RadioButton rdbConsenti;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;

    }
}
