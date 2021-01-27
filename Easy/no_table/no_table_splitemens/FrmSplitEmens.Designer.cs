
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


namespace no_table_splitemens
{
    partial class FrmSplitEmens
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtCFPersonaMittente = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCFMittente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCFSoftwarehouse = new System.Windows.Forms.TextBox();
            this.txtRagSocMittente = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLeggi = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.txtDirectory = new System.Windows.Forms.TextBox();
            this.btnDirectory = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gridFile = new System.Windows.Forms.DataGrid();
            this.txtFileXml = new System.Windows.Forms.TextBox();
            this.btnFileXml = new System.Windows.Forms.Button();
            this.DS = new no_table_splitemens.vistaForm();
            this.dsEmens = new no_table_splitemens.VistaEmens();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtSedeINPS = new System.Windows.Forms.TextBox();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnUniEmens = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEmens)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCFPersonaMittente
            // 
            this.txtCFPersonaMittente.Location = new System.Drawing.Point(176, 16);
            this.txtCFPersonaMittente.Name = "txtCFPersonaMittente";
            this.txtCFPersonaMittente.ReadOnly = true;
            this.txtCFPersonaMittente.Size = new System.Drawing.Size(112, 20);
            this.txtCFPersonaMittente.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(408, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 20);
            this.label4.TabIndex = 25;
            this.label4.Text = "C.F. Softwarehouse";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(104, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "C.F. Persona";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCFMittente
            // 
            this.txtCFMittente.Location = new System.Drawing.Point(32, 16);
            this.txtCFMittente.Name = "txtCFMittente";
            this.txtCFMittente.ReadOnly = true;
            this.txtCFMittente.Size = new System.Drawing.Size(72, 20);
            this.txtCFMittente.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "C.F.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCFSoftwarehouse
            // 
            this.txtCFSoftwarehouse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCFSoftwarehouse.Location = new System.Drawing.Point(520, 71);
            this.txtCFSoftwarehouse.Name = "txtCFSoftwarehouse";
            this.txtCFSoftwarehouse.ReadOnly = true;
            this.txtCFSoftwarehouse.Size = new System.Drawing.Size(88, 20);
            this.txtCFSoftwarehouse.TabIndex = 26;
            // 
            // txtRagSocMittente
            // 
            this.txtRagSocMittente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRagSocMittente.Location = new System.Drawing.Point(350, 16);
            this.txtRagSocMittente.Name = "txtRagSocMittente";
            this.txtRagSocMittente.ReadOnly = true;
            this.txtRagSocMittente.Size = new System.Drawing.Size(242, 20);
            this.txtRagSocMittente.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(5, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 20);
            this.label5.TabIndex = 27;
            this.label5.Text = "Sede INPS";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(294, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Rag.Soc.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnLeggi
            // 
            this.btnLeggi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLeggi.Location = new System.Drawing.Point(165, 327);
            this.btnLeggi.Name = "btnLeggi";
            this.btnLeggi.Size = new System.Drawing.Size(106, 24);
            this.btnLeggi.TabIndex = 20;
            this.btnLeggi.Text = "Suddividi E-mens";
            this.btnLeggi.Click += new System.EventHandler(this.btnLeggi_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xml";
            this.saveFileDialog1.Title = "Specificare il nome del file da produrre:";
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.Description = "Indicare la cartella dove sono presenti i file Emens da consolidare:";
            // 
            // txtDirectory
            // 
            this.txtDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDirectory.Location = new System.Drawing.Point(140, 39);
            this.txtDirectory.Name = "txtDirectory";
            this.txtDirectory.ReadOnly = true;
            this.txtDirectory.Size = new System.Drawing.Size(468, 20);
            this.txtDirectory.TabIndex = 19;
            // 
            // btnDirectory
            // 
            this.btnDirectory.Location = new System.Drawing.Point(8, 39);
            this.btnDirectory.Name = "btnDirectory";
            this.btnDirectory.Size = new System.Drawing.Size(126, 23);
            this.btnDirectory.TabIndex = 18;
            this.btnDirectory.Text = "Cartella in cui salvare";
            this.btnDirectory.Click += new System.EventHandler(this.btnDirectory_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtCFPersonaMittente);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtCFMittente);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtRagSocMittente);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(8, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(600, 40);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mittente";
            // 
            // gridFile
            // 
            this.gridFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridFile.DataMember = "";
            this.gridFile.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridFile.Location = new System.Drawing.Point(8, 143);
            this.gridFile.Name = "gridFile";
            this.gridFile.Size = new System.Drawing.Size(600, 176);
            this.gridFile.TabIndex = 21;
            // 
            // txtFileXml
            // 
            this.txtFileXml.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileXml.Location = new System.Drawing.Point(140, 7);
            this.txtFileXml.Name = "txtFileXml";
            this.txtFileXml.ReadOnly = true;
            this.txtFileXml.Size = new System.Drawing.Size(468, 20);
            this.txtFileXml.TabIndex = 23;
            // 
            // btnFileXml
            // 
            this.btnFileXml.Location = new System.Drawing.Point(8, 5);
            this.btnFileXml.Name = "btnFileXml";
            this.btnFileXml.Size = new System.Drawing.Size(126, 23);
            this.btnFileXml.TabIndex = 22;
            this.btnFileXml.Text = "File Xml da Elaborare";
            this.btnFileXml.Click += new System.EventHandler(this.btnFileXml_Click);
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // dsEmens
            // 
            this.dsEmens.DataSetName = "VistaEmens";
            this.dsEmens.EnforceConstraints = false;
            this.dsEmens.Locale = new System.Globalization.CultureInfo("en-US");
            this.dsEmens.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtSedeINPS
            // 
            this.txtSedeINPS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSedeINPS.Location = new System.Drawing.Point(77, 70);
            this.txtSedeINPS.Name = "txtSedeINPS";
            this.txtSedeINPS.ReadOnly = true;
            this.txtSedeINPS.Size = new System.Drawing.Size(325, 20);
            this.txtSedeINPS.TabIndex = 30;
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(520, 327);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 31;
            this.btnAnnulla.TabStop = false;
            this.btnAnnulla.Text = "Chiudi";
            // 
            // btnUniEmens
            // 
            this.btnUniEmens.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUniEmens.Location = new System.Drawing.Point(289, 327);
            this.btnUniEmens.Name = "btnUniEmens";
            this.btnUniEmens.Size = new System.Drawing.Size(129, 24);
            this.btnUniEmens.TabIndex = 32;
            this.btnUniEmens.Text = "Suddividi UniE-mens";
            this.btnUniEmens.Click += new System.EventHandler(this.btnUniEmens_Click);
            // 
            // FrmSplitEmens
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 358);
            this.Controls.Add(this.btnUniEmens);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.txtSedeINPS);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCFSoftwarehouse);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnLeggi);
            this.Controls.Add(this.txtDirectory);
            this.Controls.Add(this.btnDirectory);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gridFile);
            this.Controls.Add(this.txtFileXml);
            this.Controls.Add(this.btnFileXml);
            this.Name = "FrmSplitEmens";
            this.Text = "Spacchetta denunce Emens";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEmens)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.TextBox txtCFPersonaMittente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCFMittente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCFSoftwarehouse;
        private System.Windows.Forms.TextBox txtRagSocMittente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLeggi;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox txtDirectory;
        private System.Windows.Forms.Button btnDirectory;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGrid gridFile;
        private System.Windows.Forms.TextBox txtFileXml;
        private System.Windows.Forms.Button btnFileXml;
        public VistaEmens dsEmens;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtSedeINPS;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Button btnUniEmens;

    }
}
