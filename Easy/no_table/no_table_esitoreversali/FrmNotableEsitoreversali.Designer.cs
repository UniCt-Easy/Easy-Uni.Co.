/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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

namespace no_table_esitoreversali {
    partial class FrmNotableEsitoreversali {
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
            this.gridReversali = new System.Windows.Forms.DataGrid();
            this.btnSeleziona = new System.Windows.Forms.Button();
            this.txtDocumentiSelezionati = new System.Windows.Forms.TextBox();
            this.txtSelezione = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtImporto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDataValuta = new System.Windows.Forms.TextBox();
            this.txtRifBanca = new System.Windows.Forms.TextBox();
            this.txtDataOperaz = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSalva = new System.Windows.Forms.Button();
            this.DS = new no_table_esitoreversali.vistaForm();
            ((System.ComponentModel.ISupportInitialize)(this.gridReversali)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // gridReversali
            // 
            this.gridReversali.AllowNavigation = false;
            this.gridReversali.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridReversali.DataMember = "";
            this.gridReversali.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridReversali.Location = new System.Drawing.Point(10, 21);
            this.gridReversali.Name = "gridReversali";
            this.gridReversali.Size = new System.Drawing.Size(725, 270);
            this.gridReversali.TabIndex = 51;
            this.gridReversali.Tag = "proceedsview.esitoreversali";
            this.gridReversali.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridReversali_MouseClick);
            this.gridReversali.CurrentCellChanged += new System.EventHandler(this.gridReversali_CurrentCellChanged);
            // 
            // btnSeleziona
            // 
            this.btnSeleziona.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSeleziona.Location = new System.Drawing.Point(12, 310);
            this.btnSeleziona.Name = "btnSeleziona";
            this.btnSeleziona.Size = new System.Drawing.Size(96, 23);
            this.btnSeleziona.TabIndex = 53;
            this.btnSeleziona.Text = "Seleziona";
            this.btnSeleziona.Click += new System.EventHandler(this.btnSeleziona_Click);
            // 
            // txtDocumentiSelezionati
            // 
            this.txtDocumentiSelezionati.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDocumentiSelezionati.Location = new System.Drawing.Point(108, 334);
            this.txtDocumentiSelezionati.Name = "txtDocumentiSelezionati";
            this.txtDocumentiSelezionati.ReadOnly = true;
            this.txtDocumentiSelezionati.Size = new System.Drawing.Size(629, 20);
            this.txtDocumentiSelezionati.TabIndex = 58;
            // 
            // txtSelezione
            // 
            this.txtSelezione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSelezione.Location = new System.Drawing.Point(108, 310);
            this.txtSelezione.Name = "txtSelezione";
            this.txtSelezione.Size = new System.Drawing.Size(629, 20);
            this.txtSelezione.TabIndex = 52;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.Location = new System.Drawing.Point(4, 334);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 16);
            this.label4.TabIndex = 57;
            this.label4.Text = "Mov. selezionati";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 294);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(696, 13);
            this.label2.TabIndex = 56;
            this.label2.Text = "Immettere i numeri e/o gli intervalli delle reversali separati da virgole. Es.: p" +
                "er selezionare le reversali 1,4,6,7,8 scrivere 1,4,6-8 e premere Seleziona.";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(549, 13);
            this.label1.TabIndex = 55;
            this.label1.Text = "Tenere premuto il tasto CTRL o MAIUSC e contemporaneamente cliccare con il mouse " +
                "per selezionare più reversali";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtImporto);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtDataValuta);
            this.groupBox1.Controls.Add(this.txtRifBanca);
            this.groupBox1.Controls.Add(this.txtDataOperaz);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.btnSalva);
            this.groupBox1.Location = new System.Drawing.Point(10, 352);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(725, 93);
            this.groupBox1.TabIndex = 54;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informazioni sugli esiti delle reversali selezionati";
            // 
            // txtImporto
            // 
            this.txtImporto.Location = new System.Drawing.Point(540, 28);
            this.txtImporto.Name = "txtImporto";
            this.txtImporto.ReadOnly = true;
            this.txtImporto.Size = new System.Drawing.Size(170, 20);
            this.txtImporto.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(537, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Importo Totale Reversali";
            // 
            // txtDataValuta
            // 
            this.txtDataValuta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDataValuta.Location = new System.Drawing.Point(96, 64);
            this.txtDataValuta.Name = "txtDataValuta";
            this.txtDataValuta.Size = new System.Drawing.Size(414, 20);
            this.txtDataValuta.TabIndex = 14;
            this.txtDataValuta.Tag = "";
            this.txtDataValuta.Leave += new System.EventHandler(this.txtDataValuta_Leave);
            // 
            // txtRifBanca
            // 
            this.txtRifBanca.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRifBanca.Location = new System.Drawing.Point(96, 16);
            this.txtRifBanca.Name = "txtRifBanca";
            this.txtRifBanca.Size = new System.Drawing.Size(414, 20);
            this.txtRifBanca.TabIndex = 10;
            this.txtRifBanca.Tag = "";
            // 
            // txtDataOperaz
            // 
            this.txtDataOperaz.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDataOperaz.Location = new System.Drawing.Point(96, 40);
            this.txtDataOperaz.Name = "txtDataOperaz";
            this.txtDataOperaz.Size = new System.Drawing.Size(414, 20);
            this.txtDataOperaz.TabIndex = 12;
            this.txtDataOperaz.Tag = "";
            this.txtDataOperaz.Leave += new System.EventHandler(this.txtDataOperaz_Leave);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(8, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 20);
            this.label8.TabIndex = 11;
            this.label8.Text = "Data operazione";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(8, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "Data valuta";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(8, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 20);
            this.label9.TabIndex = 9;
            this.label9.Text = "Rif. banca";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSalva
            // 
            this.btnSalva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalva.Location = new System.Drawing.Point(540, 53);
            this.btnSalva.Name = "btnSalva";
            this.btnSalva.Size = new System.Drawing.Size(171, 32);
            this.btnSalva.TabIndex = 18;
            this.btnSalva.Text = "Esita";
            this.btnSalva.Click += new System.EventHandler(this.btnSalva_Click);
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // FrmNotableEsitoreversali
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 451);
            this.Controls.Add(this.gridReversali);
            this.Controls.Add(this.btnSeleziona);
            this.Controls.Add(this.txtDocumentiSelezionati);
            this.Controls.Add(this.txtSelezione);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmNotableEsitoreversali";
            this.Text = "FrmNotableEsitoreversali";
            ((System.ComponentModel.ISupportInitialize)(this.gridReversali)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGrid gridReversali;
        private System.Windows.Forms.Button btnSeleziona;
        private System.Windows.Forms.TextBox txtDocumentiSelezionati;
        private System.Windows.Forms.TextBox txtSelezione;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtImporto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDataValuta;
        private System.Windows.Forms.TextBox txtRifBanca;
        private System.Windows.Forms.TextBox txtDataOperaz;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSalva;
        public vistaForm DS;
    }
}