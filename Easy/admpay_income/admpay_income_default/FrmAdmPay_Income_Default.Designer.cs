
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


namespace admpay_income_default {
    partial class FrmAdmPay_Income_Default {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAdmPay_Income_Default));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPrincipale = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEsercizio = new System.Windows.Forms.TextBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.cmbAccertamento = new System.Windows.Forms.ComboBox();
            this.DS = new admpay_income_default.vistaForm();
            this.btnAccertamento = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCredDeb = new System.Windows.Forms.TextBox();
            this.tabClassSup = new System.Windows.Forms.TabPage();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.btnDelClass = new System.Windows.Forms.Button();
            this.btnEditClass = new System.Windows.Forms.Button();
            this.btnInsertClass = new System.Windows.Forms.Button();
            this.DGridDettagliClassificazioni = new System.Windows.Forms.DataGrid();
            this.DGridClassificazioni = new System.Windows.Forms.DataGrid();
            this.label8 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPrincipale.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabClassSup.SuspendLayout();
            this.groupBox15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGridDettagliClassificazioni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGridClassificazioni)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPrincipale);
            this.tabControl1.Controls.Add(this.tabClassSup);
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Location = new System.Drawing.Point(8, 7);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(600, 392);
            this.tabControl1.TabIndex = 18;
            // 
            // tabPrincipale
            // 
            this.tabPrincipale.Controls.Add(this.groupBox1);
            this.tabPrincipale.Controls.Add(this.cmbAccertamento);
            this.tabPrincipale.Controls.Add(this.btnAccertamento);
            this.tabPrincipale.Controls.Add(this.label3);
            this.tabPrincipale.Controls.Add(this.textBox3);
            this.tabPrincipale.Controls.Add(this.label6);
            this.tabPrincipale.Controls.Add(this.textBox6);
            this.tabPrincipale.Controls.Add(this.label7);
            this.tabPrincipale.Controls.Add(this.textBox7);
            this.tabPrincipale.Controls.Add(this.groupBox2);
            this.tabPrincipale.Location = new System.Drawing.Point(4, 23);
            this.tabPrincipale.Name = "tabPrincipale";
            this.tabPrincipale.Size = new System.Drawing.Size(592, 365);
            this.tabPrincipale.TabIndex = 0;
            this.tabPrincipale.Text = "Principale";
            this.tabPrincipale.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtEsercizio);
            this.groupBox1.Controls.Add(this.txtNumero);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 56);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "AutoChoose.txtNumero.default";
            this.groupBox1.Text = "Pagamento Stipendi";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(176, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Numero:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Esercizio:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercizio
            // 
            this.txtEsercizio.Location = new System.Drawing.Point(96, 24);
            this.txtEsercizio.Name = "txtEsercizio";
            this.txtEsercizio.Size = new System.Drawing.Size(64, 20);
            this.txtEsercizio.TabIndex = 1;
            this.txtEsercizio.Tag = "admpay.yadmpay.year?admpay_income.yadmpay.year";
            // 
            // txtNumero
            // 
            this.txtNumero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumero.Location = new System.Drawing.Point(256, 24);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(100, 20);
            this.txtNumero.TabIndex = 2;
            this.txtNumero.Tag = "admpay.nadmpay?admpay_income.nadmpay";
            // 
            // cmbAccertamento
            // 
            this.cmbAccertamento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbAccertamento.DataSource = this.DS.admpay_assessmentview;
            this.cmbAccertamento.DisplayMember = "!nassessment_description";
            this.cmbAccertamento.Location = new System.Drawing.Point(104, 72);
            this.cmbAccertamento.Name = "cmbAccertamento";
            this.cmbAccertamento.Size = new System.Drawing.Size(480, 21);
            this.cmbAccertamento.TabIndex = 2;
            this.cmbAccertamento.Tag = "admpay_income.nassessment";
            this.cmbAccertamento.ValueMember = "nassessment";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // btnAccertamento
            // 
            this.btnAccertamento.Location = new System.Drawing.Point(8, 72);
            this.btnAccertamento.Name = "btnAccertamento";
            this.btnAccertamento.Size = new System.Drawing.Size(88, 23);
            this.btnAccertamento.TabIndex = 2;
            this.btnAccertamento.TabStop = false;
            this.btnAccertamento.Tag = "";
            this.btnAccertamento.Text = "Accertamento";
            this.btnAccertamento.Click += new System.EventHandler(this.btnAccertamento_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "Num. Movimento:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(120, 112);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(80, 20);
            this.textBox3.TabIndex = 3;
            this.textBox3.Tag = "admpay_income.nincome";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 23);
            this.label6.TabIndex = 15;
            this.label6.Tag = "";
            this.label6.Text = "Importo:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(120, 144);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 20);
            this.textBox6.TabIndex = 4;
            this.textBox6.Tag = "admpay_income.amount";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(8, 176);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 23);
            this.label7.TabIndex = 16;
            this.label7.Text = "Descrizione:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox7
            // 
            this.textBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox7.Location = new System.Drawing.Point(8, 200);
            this.textBox7.Multiline = true;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(576, 88);
            this.textBox7.TabIndex = 5;
            this.textBox7.Tag = "admpay_income.description";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtCredDeb);
            this.groupBox2.Location = new System.Drawing.Point(8, 296);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(576, 48);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Tag = "AutoChoose.txtCredDeb.lista.(active=\'S\')";
            this.groupBox2.Text = "Versante";
            // 
            // txtCredDeb
            // 
            this.txtCredDeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCredDeb.Location = new System.Drawing.Point(8, 16);
            this.txtCredDeb.Name = "txtCredDeb";
            this.txtCredDeb.Size = new System.Drawing.Size(560, 20);
            this.txtCredDeb.TabIndex = 1;
            this.txtCredDeb.Tag = "registry.title?admpay_incomeview.registry";
            // 
            // tabClassSup
            // 
            this.tabClassSup.Controls.Add(this.groupBox15);
            this.tabClassSup.Controls.Add(this.DGridClassificazioni);
            this.tabClassSup.Controls.Add(this.label8);
            this.tabClassSup.ImageIndex = 1;
            this.tabClassSup.Location = new System.Drawing.Point(4, 23);
            this.tabClassSup.Name = "tabClassSup";
            this.tabClassSup.Size = new System.Drawing.Size(592, 365);
            this.tabClassSup.TabIndex = 3;
            this.tabClassSup.Text = "Classificazioni";
            this.tabClassSup.UseVisualStyleBackColor = true;
            this.tabClassSup.Enter += new System.EventHandler(this.tabClassSup_Enter);
            // 
            // groupBox15
            // 
            this.groupBox15.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox15.Controls.Add(this.btnDelClass);
            this.groupBox15.Controls.Add(this.btnEditClass);
            this.groupBox15.Controls.Add(this.btnInsertClass);
            this.groupBox15.Controls.Add(this.DGridDettagliClassificazioni);
            this.groupBox15.Location = new System.Drawing.Point(8, 168);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(576, 183);
            this.groupBox15.TabIndex = 28;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Dettagli classificazioni";
            // 
            // btnDelClass
            // 
            this.btnDelClass.Location = new System.Drawing.Point(192, 24);
            this.btnDelClass.Name = "btnDelClass";
            this.btnDelClass.Size = new System.Drawing.Size(75, 23);
            this.btnDelClass.TabIndex = 3;
            this.btnDelClass.TabStop = false;
            this.btnDelClass.Tag = "";
            this.btnDelClass.Text = "Cancella";
            this.btnDelClass.Click += new System.EventHandler(this.btnDelClass_Click);
            // 
            // btnEditClass
            // 
            this.btnEditClass.Location = new System.Drawing.Point(104, 24);
            this.btnEditClass.Name = "btnEditClass";
            this.btnEditClass.Size = new System.Drawing.Size(75, 23);
            this.btnEditClass.TabIndex = 2;
            this.btnEditClass.TabStop = false;
            this.btnEditClass.Tag = "";
            this.btnEditClass.Text = "Correggi";
            this.btnEditClass.Click += new System.EventHandler(this.btnEditClass_Click);
            // 
            // btnInsertClass
            // 
            this.btnInsertClass.Location = new System.Drawing.Point(16, 24);
            this.btnInsertClass.Name = "btnInsertClass";
            this.btnInsertClass.Size = new System.Drawing.Size(75, 23);
            this.btnInsertClass.TabIndex = 1;
            this.btnInsertClass.TabStop = false;
            this.btnInsertClass.Tag = "";
            this.btnInsertClass.Text = "Aggiungi";
            this.btnInsertClass.Click += new System.EventHandler(this.btnInsertClass_Click);
            // 
            // DGridDettagliClassificazioni
            // 
            this.DGridDettagliClassificazioni.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DGridDettagliClassificazioni.DataMember = "";
            this.DGridDettagliClassificazioni.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.DGridDettagliClassificazioni.Location = new System.Drawing.Point(8, 56);
            this.DGridDettagliClassificazioni.Name = "DGridDettagliClassificazioni";
            this.DGridDettagliClassificazioni.ReadOnly = true;
            this.DGridDettagliClassificazioni.Size = new System.Drawing.Size(560, 119);
            this.DGridDettagliClassificazioni.TabIndex = 7;
            this.DGridDettagliClassificazioni.Tag = "admpay_incomesorted.detail";
            // 
            // DGridClassificazioni
            // 
            this.DGridClassificazioni.AllowNavigation = false;
            this.DGridClassificazioni.AllowSorting = false;
            this.DGridClassificazioni.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DGridClassificazioni.DataMember = "";
            this.DGridClassificazioni.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.DGridClassificazioni.Location = new System.Drawing.Point(8, 24);
            this.DGridClassificazioni.Name = "DGridClassificazioni";
            this.DGridClassificazioni.ParentRowsVisible = false;
            this.DGridClassificazioni.ReadOnly = true;
            this.DGridClassificazioni.Size = new System.Drawing.Size(576, 136);
            this.DGridClassificazioni.TabIndex = 8;
            this.DGridClassificazioni.Tag = "sortingkind.default";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(8, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "Classificazioni";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            // 
            // FrmAdmPay_Income_Default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 406);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmAdmPay_Income_Default";
            this.Text = "FrmAdmPay_Income_Default";
            this.tabControl1.ResumeLayout(false);
            this.tabPrincipale.ResumeLayout(false);
            this.tabPrincipale.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabClassSup.ResumeLayout(false);
            this.groupBox15.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGridDettagliClassificazioni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGridClassificazioni)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPrincipale;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEsercizio;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.ComboBox cmbAccertamento;
        private System.Windows.Forms.Button btnAccertamento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtCredDeb;
        private System.Windows.Forms.TabPage tabClassSup;
        private System.Windows.Forms.GroupBox groupBox15;
        private System.Windows.Forms.Button btnDelClass;
        private System.Windows.Forms.Button btnEditClass;
        private System.Windows.Forms.Button btnInsertClass;
        private System.Windows.Forms.DataGrid DGridDettagliClassificazioni;
        private System.Windows.Forms.DataGrid DGridClassificazioni;
        private System.Windows.Forms.Label label8;
        public vistaForm DS;
        private System.Windows.Forms.ImageList imageList1;
    }
}
