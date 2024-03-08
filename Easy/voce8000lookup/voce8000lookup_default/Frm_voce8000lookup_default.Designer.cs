
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


namespace voce8000lookup_default {
    partial class Frm_voce8000lookup_default {
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
            this.DS = new voce8000lookup_default.vistaForm();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTipoRitenuta = new System.Windows.Forms.ComboBox();
            this.grpvoce8000 = new System.Windows.Forms.GroupBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtvoce8000 = new System.Windows.Forms.TextBox();
            this.buttonvoce8000 = new System.Windows.Forms.Button();
            this.txtDescrVoce8000 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVoce8000Impon = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.chkCsaUsability8 = new System.Windows.Forms.CheckBox();
            this.chkCsaUsability7 = new System.Windows.Forms.CheckBox();
            this.chkCsaUsability6 = new System.Windows.Forms.CheckBox();
            this.chkCsaUsability5 = new System.Windows.Forms.CheckBox();
            this.chkCsaUsability4 = new System.Windows.Forms.CheckBox();
            this.chkCsaUsability3 = new System.Windows.Forms.CheckBox();
            this.chkCsaUsability2 = new System.Windows.Forms.CheckBox();
            this.chkCsaUsability1 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtVoce8000QuotaEsente = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.grpvoce8000.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton5);
            this.groupBox2.Controls.Add(this.radioButton7);
            this.groupBox2.Location = new System.Drawing.Point(342, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(326, 42);
            this.groupBox2.TabIndex = 90;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Applicazione";
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(174, 17);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(89, 17);
            this.radioButton5.TabIndex = 16;
            this.radioButton5.Tag = "voce8000lookup.conto:D";
            this.radioButton5.Text = "c/dipendente";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.Location = new System.Drawing.Point(30, 17);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(110, 17);
            this.radioButton7.TabIndex = 17;
            this.radioButton7.Tag = "voce8000lookup.conto:A";
            this.radioButton7.Text = "c/amministrazione";
            this.radioButton7.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(15, 398);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 23);
            this.label1.TabIndex = 96;
            this.label1.Text = "Imposta associata";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbTipoRitenuta
            // 
            this.cmbTipoRitenuta.DataSource = this.DS.tax;
            this.cmbTipoRitenuta.DisplayMember = "description";
            this.cmbTipoRitenuta.Location = new System.Drawing.Point(126, 398);
            this.cmbTipoRitenuta.Name = "cmbTipoRitenuta";
            this.cmbTipoRitenuta.Size = new System.Drawing.Size(594, 21);
            this.cmbTipoRitenuta.TabIndex = 95;
            this.cmbTipoRitenuta.Tag = "voce8000lookup.taxcode";
            this.cmbTipoRitenuta.ValueMember = "taxcode";
            // 
            // grpvoce8000
            // 
            this.grpvoce8000.Controls.Add(this.textBox6);
            this.grpvoce8000.Controls.Add(this.label2);
            this.grpvoce8000.Controls.Add(this.txtvoce8000);
            this.grpvoce8000.Controls.Add(this.buttonvoce8000);
            this.grpvoce8000.Controls.Add(this.txtDescrVoce8000);
            this.grpvoce8000.Location = new System.Drawing.Point(341, 281);
            this.grpvoce8000.Name = "grpvoce8000";
            this.grpvoce8000.Size = new System.Drawing.Size(379, 108);
            this.grpvoce8000.TabIndex = 97;
            this.grpvoce8000.TabStop = false;
            this.grpvoce8000.Tag = "AutoChoose.txtvoce8000.default.(kind<>\'I\')";
            this.grpvoce8000.Text = "Imposta CSA";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(128, 71);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(245, 20);
            this.textBox6.TabIndex = 22;
            this.textBox6.Tag = "voce8000lookup.capitolovoce";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(36, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "Capitolo CSA:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtvoce8000
            // 
            this.txtvoce8000.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtvoce8000.Location = new System.Drawing.Point(6, 45);
            this.txtvoce8000.Name = "txtvoce8000";
            this.txtvoce8000.Size = new System.Drawing.Size(105, 20);
            this.txtvoce8000.TabIndex = 6;
            this.txtvoce8000.Tag = "voce8000.voce?x";
            // 
            // buttonvoce8000
            // 
            this.buttonvoce8000.BackColor = System.Drawing.SystemColors.Control;
            this.buttonvoce8000.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonvoce8000.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonvoce8000.Location = new System.Drawing.Point(4, 19);
            this.buttonvoce8000.Name = "buttonvoce8000";
            this.buttonvoce8000.Size = new System.Drawing.Size(112, 20);
            this.buttonvoce8000.TabIndex = 5;
            this.buttonvoce8000.TabStop = false;
            this.buttonvoce8000.Tag = "manage.voce8000.default";
            this.buttonvoce8000.Text = "Voce 8000";
            this.buttonvoce8000.UseVisualStyleBackColor = false;
            // 
            // txtDescrVoce8000
            // 
            this.txtDescrVoce8000.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrVoce8000.Location = new System.Drawing.Point(128, 16);
            this.txtDescrVoce8000.Multiline = true;
            this.txtDescrVoce8000.Name = "txtDescrVoce8000";
            this.txtDescrVoce8000.ReadOnly = true;
            this.txtDescrVoce8000.Size = new System.Drawing.Size(245, 49);
            this.txtDescrVoce8000.TabIndex = 4;
            this.txtDescrVoce8000.TabStop = false;
            this.txtDescrVoce8000.Tag = "voce8000.description";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox3);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtVoce8000Impon);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Location = new System.Drawing.Point(342, 63);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(379, 105);
            this.groupBox3.TabIndex = 98;
            this.groupBox3.TabStop = false;
            this.groupBox3.Tag = "AutoChoose.txtVoce8000Impon.default.(kind = \'I\')";
            this.groupBox3.Text = "Imponibile CSA";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(127, 73);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(245, 20);
            this.textBox3.TabIndex = 22;
            this.textBox3.Tag = "voce8000lookup.capitoloimponibile";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(27, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 23;
            this.label3.Text = "Capitolo CSA:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtVoce8000Impon
            // 
            this.txtVoce8000Impon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVoce8000Impon.Location = new System.Drawing.Point(4, 45);
            this.txtVoce8000Impon.Name = "txtVoce8000Impon";
            this.txtVoce8000Impon.Size = new System.Drawing.Size(105, 20);
            this.txtVoce8000Impon.TabIndex = 7;
            this.txtVoce8000Impon.Tag = "voce8000_impon.voce?x";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(6, 45);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(18, 20);
            this.textBox1.TabIndex = 6;
            this.textBox1.Tag = "voce8000.voce?x";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(4, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 20);
            this.button1.TabIndex = 5;
            this.button1.TabStop = false;
            this.button1.Tag = "manage.voce8000_impon.default";
            this.button1.Text = "Voce 8000";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(128, 16);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(244, 51);
            this.textBox2.TabIndex = 4;
            this.textBox2.TabStop = false;
            this.textBox2.Tag = "voce8000_impon.description";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.chkCsaUsability8);
            this.groupBox6.Controls.Add(this.chkCsaUsability7);
            this.groupBox6.Controls.Add(this.chkCsaUsability6);
            this.groupBox6.Controls.Add(this.chkCsaUsability5);
            this.groupBox6.Controls.Add(this.chkCsaUsability4);
            this.groupBox6.Controls.Add(this.chkCsaUsability3);
            this.groupBox6.Controls.Add(this.chkCsaUsability2);
            this.groupBox6.Controls.Add(this.chkCsaUsability1);
            this.groupBox6.Location = new System.Drawing.Point(12, 14);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(323, 285);
            this.groupBox6.TabIndex = 99;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Usabilità  per Record 8000";
            // 
            // chkCsaUsability8
            // 
            this.chkCsaUsability8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkCsaUsability8.AutoSize = true;
            this.chkCsaUsability8.Location = new System.Drawing.Point(11, 243);
            this.chkCsaUsability8.Name = "chkCsaUsability8";
            this.chkCsaUsability8.Size = new System.Drawing.Size(29, 17);
            this.chkCsaUsability8.TabIndex = 104;
            this.chkCsaUsability8.Tag = "voce8000lookup.flagcsausability:7";
            this.chkCsaUsability8.Text = " ";
            this.chkCsaUsability8.Visible = false;
            // 
            // chkCsaUsability7
            // 
            this.chkCsaUsability7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkCsaUsability7.AutoSize = true;
            this.chkCsaUsability7.Location = new System.Drawing.Point(11, 220);
            this.chkCsaUsability7.Name = "chkCsaUsability7";
            this.chkCsaUsability7.Size = new System.Drawing.Size(29, 17);
            this.chkCsaUsability7.TabIndex = 103;
            this.chkCsaUsability7.Tag = "voce8000lookup.flagcsausability:6";
            this.chkCsaUsability7.Text = " ";
            this.chkCsaUsability7.Visible = false;
            // 
            // chkCsaUsability6
            // 
            this.chkCsaUsability6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkCsaUsability6.AutoSize = true;
            this.chkCsaUsability6.Location = new System.Drawing.Point(11, 193);
            this.chkCsaUsability6.Name = "chkCsaUsability6";
            this.chkCsaUsability6.Size = new System.Drawing.Size(29, 17);
            this.chkCsaUsability6.TabIndex = 102;
            this.chkCsaUsability6.Tag = "voce8000lookup.flagcsausability:5";
            this.chkCsaUsability6.Text = " ";
            this.chkCsaUsability6.Visible = false;
            // 
            // chkCsaUsability5
            // 
            this.chkCsaUsability5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkCsaUsability5.AutoSize = true;
            this.chkCsaUsability5.Location = new System.Drawing.Point(11, 164);
            this.chkCsaUsability5.Name = "chkCsaUsability5";
            this.chkCsaUsability5.Size = new System.Drawing.Size(29, 17);
            this.chkCsaUsability5.TabIndex = 101;
            this.chkCsaUsability5.Tag = "voce8000lookup.flagcsausability:4";
            this.chkCsaUsability5.Text = " ";
            this.chkCsaUsability5.Visible = false;
            // 
            // chkCsaUsability4
            // 
            this.chkCsaUsability4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkCsaUsability4.AutoSize = true;
            this.chkCsaUsability4.Location = new System.Drawing.Point(11, 136);
            this.chkCsaUsability4.Name = "chkCsaUsability4";
            this.chkCsaUsability4.Size = new System.Drawing.Size(29, 17);
            this.chkCsaUsability4.TabIndex = 100;
            this.chkCsaUsability4.Tag = "voce8000lookup.flagcsausability:3";
            this.chkCsaUsability4.Text = " ";
            this.chkCsaUsability4.Visible = false;
            // 
            // chkCsaUsability3
            // 
            this.chkCsaUsability3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkCsaUsability3.AutoSize = true;
            this.chkCsaUsability3.Location = new System.Drawing.Point(11, 104);
            this.chkCsaUsability3.Name = "chkCsaUsability3";
            this.chkCsaUsability3.Size = new System.Drawing.Size(29, 17);
            this.chkCsaUsability3.TabIndex = 99;
            this.chkCsaUsability3.Tag = "voce8000lookup.flagcsausability:2";
            this.chkCsaUsability3.Text = " ";
            this.chkCsaUsability3.Visible = false;
            // 
            // chkCsaUsability2
            // 
            this.chkCsaUsability2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkCsaUsability2.AutoSize = true;
            this.chkCsaUsability2.Location = new System.Drawing.Point(11, 72);
            this.chkCsaUsability2.Name = "chkCsaUsability2";
            this.chkCsaUsability2.Size = new System.Drawing.Size(29, 17);
            this.chkCsaUsability2.TabIndex = 98;
            this.chkCsaUsability2.Tag = "voce8000lookup.flagcsausability:1";
            this.chkCsaUsability2.Text = " ";
            this.chkCsaUsability2.Visible = false;
            // 
            // chkCsaUsability1
            // 
            this.chkCsaUsability1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkCsaUsability1.AutoSize = true;
            this.chkCsaUsability1.Location = new System.Drawing.Point(11, 41);
            this.chkCsaUsability1.Name = "chkCsaUsability1";
            this.chkCsaUsability1.Size = new System.Drawing.Size(29, 17);
            this.chkCsaUsability1.TabIndex = 97;
            this.chkCsaUsability1.Tag = "voce8000lookup.flagcsausability:0";
            this.chkCsaUsability1.Text = " ";
            this.chkCsaUsability1.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtVoce8000QuotaEsente);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Location = new System.Drawing.Point(341, 174);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(379, 104);
            this.groupBox1.TabIndex = 100;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "AutoChoose.txtVoce8000QuotaEsente.default.(kind = \'I\')";
            this.groupBox1.Text = "Quota Esente CSA";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(128, 78);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(245, 20);
            this.textBox7.TabIndex = 22;
            this.textBox7.Tag = "voce8000lookup.capitoloquotaesente";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(36, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 20);
            this.label4.TabIndex = 23;
            this.label4.Text = "Capitolo CSA:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtVoce8000QuotaEsente
            // 
            this.txtVoce8000QuotaEsente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVoce8000QuotaEsente.Location = new System.Drawing.Point(4, 45);
            this.txtVoce8000QuotaEsente.Name = "txtVoce8000QuotaEsente";
            this.txtVoce8000QuotaEsente.Size = new System.Drawing.Size(105, 20);
            this.txtVoce8000QuotaEsente.TabIndex = 7;
            this.txtVoce8000QuotaEsente.Tag = "voce8000_quotaesente.voce?x";
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.Location = new System.Drawing.Point(6, 45);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(18, 20);
            this.textBox4.TabIndex = 6;
            this.textBox4.Tag = "voce8000.voce?x";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button2.Location = new System.Drawing.Point(4, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 20);
            this.button2.TabIndex = 5;
            this.button2.TabStop = false;
            this.button2.Tag = "manage.voce8000_quotaesente.default";
            this.button2.Text = "Voce 8000";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // textBox5
            // 
            this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox5.Location = new System.Drawing.Point(128, 16);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(245, 49);
            this.textBox5.TabIndex = 4;
            this.textBox5.TabStop = false;
            this.textBox5.Tag = "voce8000_quotaesente.description";
            // 
            // Frm_voce8000lookup_default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 444);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.grpvoce8000);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbTipoRitenuta);
            this.Controls.Add(this.groupBox2);
            this.Name = "Frm_voce8000lookup_default";
            this.Text = "Frm_voce8000lookup_default";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpvoce8000.ResumeLayout(false);
            this.grpvoce8000.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTipoRitenuta;
        private System.Windows.Forms.GroupBox grpvoce8000;
        public System.Windows.Forms.TextBox txtvoce8000;
        private System.Windows.Forms.Button buttonvoce8000;
        private System.Windows.Forms.TextBox txtDescrVoce8000;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        public System.Windows.Forms.TextBox txtVoce8000Impon;
        private System.Windows.Forms.GroupBox groupBox6;
        public System.Windows.Forms.CheckBox chkCsaUsability7;
        public System.Windows.Forms.CheckBox chkCsaUsability6;
        public System.Windows.Forms.CheckBox chkCsaUsability5;
        public System.Windows.Forms.CheckBox chkCsaUsability4;
        public System.Windows.Forms.CheckBox chkCsaUsability3;
        public System.Windows.Forms.CheckBox chkCsaUsability2;
        public System.Windows.Forms.CheckBox chkCsaUsability1;
        public System.Windows.Forms.CheckBox chkCsaUsability8;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox txtVoce8000QuotaEsente;
        public System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label4;

    }
}
