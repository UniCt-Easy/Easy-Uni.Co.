
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


namespace no_table_ivapay {
    partial class Frm_ivapay {
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
            this.gridLiquidazioni = new System.Windows.Forms.DataGrid();
            this.gboxFatture = new System.Windows.Forms.GroupBox();
            this.btnStampa = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNomeFile = new System.Windows.Forms.TextBox();
            this.txtPercorso = new System.Windows.Forms.TextBox();
            this.btnGenera = new System.Windows.Forms.Button();
            this.txtEsercizio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DS = new no_table_ivapay.vistaForm();
            this.cmbTrimestre = new System.Windows.Forms.ComboBox();
            this.labelTrimestre = new System.Windows.Forms.Label();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnIvaACredito = new System.Windows.Forms.Button();
            this.btnOpPassive = new System.Windows.Forms.Button();
            this.btnIvaADebito = new System.Windows.Forms.Button();
            this.btnOpAttive = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridLiquidazioni)).BeginInit();
            this.gboxFatture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridLiquidazioni
            // 
            this.gridLiquidazioni.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridLiquidazioni.DataMember = "";
            this.gridLiquidazioni.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridLiquidazioni.Location = new System.Drawing.Point(8, 21);
            this.gridLiquidazioni.Name = "gridLiquidazioni";
            this.gridLiquidazioni.Size = new System.Drawing.Size(593, 191);
            this.gridLiquidazioni.TabIndex = 0;
            // 
            // gboxFatture
            // 
            this.gboxFatture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxFatture.Controls.Add(this.gridLiquidazioni);
            this.gboxFatture.Location = new System.Drawing.Point(25, 276);
            this.gboxFatture.Name = "gboxFatture";
            this.gboxFatture.Padding = new System.Windows.Forms.Padding(5);
            this.gboxFatture.Size = new System.Drawing.Size(609, 234);
            this.gboxFatture.TabIndex = 1;
            this.gboxFatture.TabStop = false;
            this.gboxFatture.Text = "Liquidazioni Iva";
            // 
            // btnStampa
            // 
            this.btnStampa.AutoSize = true;
            this.btnStampa.Location = new System.Drawing.Point(160, 168);
            this.btnStampa.Name = "btnStampa";
            this.btnStampa.Size = new System.Drawing.Size(117, 23);
            this.btnStampa.TabIndex = 49;
            this.btnStampa.Text = "Stampa Modello PDF";
            this.btnStampa.UseVisualStyleBackColor = true;
            this.btnStampa.Click += new System.EventHandler(this.btnStampa_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(36, 237);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 17);
            this.label5.TabIndex = 59;
            this.label5.Text = "Nome File";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNomeFile
            // 
            this.txtNomeFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNomeFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeFile.Location = new System.Drawing.Point(99, 237);
            this.txtNomeFile.Name = "txtNomeFile";
            this.txtNomeFile.ReadOnly = true;
            this.txtNomeFile.Size = new System.Drawing.Size(528, 20);
            this.txtNomeFile.TabIndex = 58;
            this.txtNomeFile.Tag = "";
            // 
            // txtPercorso
            // 
            this.txtPercorso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPercorso.Location = new System.Drawing.Point(35, 211);
            this.txtPercorso.Name = "txtPercorso";
            this.txtPercorso.ReadOnly = true;
            this.txtPercorso.Size = new System.Drawing.Size(592, 20);
            this.txtPercorso.TabIndex = 57;
            // 
            // btnGenera
            // 
            this.btnGenera.AutoSize = true;
            this.btnGenera.Location = new System.Drawing.Point(37, 168);
            this.btnGenera.Name = "btnGenera";
            this.btnGenera.Size = new System.Drawing.Size(117, 23);
            this.btnGenera.TabIndex = 56;
            this.btnGenera.Text = "Genera File";
            this.btnGenera.UseVisualStyleBackColor = true;
            this.btnGenera.Click += new System.EventHandler(this.btnGenera_Click);
            // 
            // txtEsercizio
            // 
            this.txtEsercizio.Location = new System.Drawing.Point(81, 23);
            this.txtEsercizio.Name = "txtEsercizio";
            this.txtEsercizio.Size = new System.Drawing.Size(65, 20);
            this.txtEsercizio.TabIndex = 53;
            this.txtEsercizio.Tag = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 52;
            this.label2.Text = "Esercizio";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // cmbTrimestre
            // 
            this.cmbTrimestre.DataSource = this.DS.trimestre;
            this.cmbTrimestre.DisplayMember = "descrizione";
            this.cmbTrimestre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.cmbTrimestre.ItemHeight = 13;
            this.cmbTrimestre.Location = new System.Drawing.Point(81, 57);
            this.cmbTrimestre.Name = "cmbTrimestre";
            this.cmbTrimestre.Size = new System.Drawing.Size(216, 21);
            this.cmbTrimestre.TabIndex = 67;
            this.cmbTrimestre.ValueMember = "idtrimestre";
            // 
            // labelTrimestre
            // 
            this.labelTrimestre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.labelTrimestre.Location = new System.Drawing.Point(30, 55);
            this.labelTrimestre.Name = "labelTrimestre";
            this.labelTrimestre.Size = new System.Drawing.Size(51, 23);
            this.labelTrimestre.TabIndex = 68;
            this.labelTrimestre.Text = "Trimestre";
            this.labelTrimestre.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(554, 522);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 71;
            this.btnAnnulla.Text = "Annulla";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(466, 522);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 70;
            this.btnOK.Tag = "";
            this.btnOK.Text = "OK";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xml";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnIvaACredito);
            this.groupBox1.Controls.Add(this.btnOpPassive);
            this.groupBox1.Controls.Add(this.btnIvaADebito);
            this.groupBox1.Controls.Add(this.btnOpAttive);
            this.groupBox1.Location = new System.Drawing.Point(303, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 183);
            this.groupBox1.TabIndex = 72;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Verifiche";
            // 
            // btnIvaACredito
            // 
            this.btnIvaACredito.AutoSize = true;
            this.btnIvaACredito.Location = new System.Drawing.Point(9, 107);
            this.btnIvaACredito.Name = "btnIvaACredito";
            this.btnIvaACredito.Size = new System.Drawing.Size(214, 23);
            this.btnIvaACredito.TabIndex = 60;
            this.btnIvaACredito.Text = "Iva  detratta";
            this.btnIvaACredito.UseVisualStyleBackColor = true;
            this.btnIvaACredito.Click += new System.EventHandler(this.btnIva_Click);
            // 
            // btnOpPassive
            // 
            this.btnOpPassive.AutoSize = true;
            this.btnOpPassive.Location = new System.Drawing.Point(9, 49);
            this.btnOpPassive.Name = "btnOpPassive";
            this.btnOpPassive.Size = new System.Drawing.Size(214, 23);
            this.btnOpPassive.TabIndex = 59;
            this.btnOpPassive.Text = "Operazioni Passive registrate nel periodo";
            this.btnOpPassive.UseVisualStyleBackColor = true;
            this.btnOpPassive.Click += new System.EventHandler(this.btnOpAttivePassive_Click);
            // 
            // btnIvaADebito
            // 
            this.btnIvaADebito.AutoSize = true;
            this.btnIvaADebito.Location = new System.Drawing.Point(9, 78);
            this.btnIvaADebito.Name = "btnIvaADebito";
            this.btnIvaADebito.Size = new System.Drawing.Size(214, 23);
            this.btnIvaADebito.TabIndex = 58;
            this.btnIvaADebito.Text = "Iva esigibile";
            this.btnIvaADebito.UseVisualStyleBackColor = true;
            this.btnIvaADebito.Click += new System.EventHandler(this.btnIva_Click);
            // 
            // btnOpAttive
            // 
            this.btnOpAttive.AutoSize = true;
            this.btnOpAttive.Location = new System.Drawing.Point(9, 19);
            this.btnOpAttive.Name = "btnOpAttive";
            this.btnOpAttive.Size = new System.Drawing.Size(214, 23);
            this.btnOpAttive.TabIndex = 57;
            this.btnOpAttive.Text = "Operazioni Attive registrate nel periodo";
            this.btnOpAttive.UseVisualStyleBackColor = true;
            this.btnOpAttive.Click += new System.EventHandler(this.btnOpAttivePassive_Click);
            // 
            // Frm_ivapay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 567);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cmbTrimestre);
            this.Controls.Add(this.labelTrimestre);
            this.Controls.Add(this.btnStampa);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNomeFile);
            this.Controls.Add(this.txtPercorso);
            this.Controls.Add(this.btnGenera);
            this.Controls.Add(this.txtEsercizio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gboxFatture);
            this.Name = "Frm_ivapay";
            this.Text = "Frm_ivapay";
            ((System.ComponentModel.ISupportInitialize)(this.gridLiquidazioni)).EndInit();
            this.gboxFatture.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGrid gridLiquidazioni;
        private System.Windows.Forms.GroupBox gboxFatture;
        public no_table_ivapay.vistaForm DS;
        private System.Windows.Forms.Button btnStampa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNomeFile;
        private System.Windows.Forms.TextBox txtPercorso;
        private System.Windows.Forms.Button btnGenera;
        private System.Windows.Forms.TextBox txtEsercizio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTrimestre;
        private System.Windows.Forms.Label labelTrimestre;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnIvaADebito;
        private System.Windows.Forms.Button btnOpAttive;
        private System.Windows.Forms.Button btnOpPassive;
        private System.Windows.Forms.Button btnIvaACredito;
    }
}
