
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


namespace servicepayment_assegnazioneautomatica
{
    partial class Frm_servicepayment_assegnazioneautomatica
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnoccasionale = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgrprestazioni1 = new System.Windows.Forms.DataGrid();
            this.btndipendente = new System.Windows.Forms.Button();
            this.btnEsegui1 = new System.Windows.Forms.Button();
            this.DS = new servicepayment_assegnazioneautomatica.dsmeta();
            this.dgrprestazioni2 = new System.Windows.Forms.DataGrid();
            this.btnEsegui2 = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnMissione = new System.Windows.Forms.Button();
            this.btnProfessionale = new System.Windows.Forms.Button();
            this.btnparasubordinati = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgrprestazioni1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrprestazioni2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnoccasionale
            // 
            this.btnoccasionale.Location = new System.Drawing.Point(31, 37);
            this.btnoccasionale.Name = "btnoccasionale";
            this.btnoccasionale.Size = new System.Drawing.Size(84, 23);
            this.btnoccasionale.TabIndex = 0;
            this.btnoccasionale.Text = "Occasionali";
            this.btnoccasionale.UseVisualStyleBackColor = true;
            this.btnoccasionale.Click += new System.EventHandler(this.btnoccasionale_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(456, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Selezionare il tipo di prestazione per cui si desidera aggiornare il pagamento de" +
                "ll\' Anagrafe delle \r\nPrestazioni associato.";
            // 
            // dgrprestazioni1
            // 
            this.dgrprestazioni1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrprestazioni1.DataMember = "";
            this.dgrprestazioni1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgrprestazioni1.Location = new System.Drawing.Point(12, 83);
            this.dgrprestazioni1.Name = "dgrprestazioni1";
            this.dgrprestazioni1.Size = new System.Drawing.Size(514, 124);
            this.dgrprestazioni1.TabIndex = 2;
            // 
            // btndipendente
            // 
            this.btndipendente.Location = new System.Drawing.Point(125, 37);
            this.btndipendente.Name = "btndipendente";
            this.btndipendente.Size = new System.Drawing.Size(84, 23);
            this.btndipendente.TabIndex = 3;
            this.btndipendente.Text = "Dipendenti";
            this.btndipendente.UseVisualStyleBackColor = true;
            this.btndipendente.Click += new System.EventHandler(this.btndipendente_Click);
            // 
            // btnEsegui1
            // 
            this.btnEsegui1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEsegui1.Location = new System.Drawing.Point(435, 208);
            this.btnEsegui1.Name = "btnEsegui1";
            this.btnEsegui1.Size = new System.Drawing.Size(91, 24);
            this.btnEsegui1.TabIndex = 4;
            this.btnEsegui1.Text = "Esegui";
            this.btnEsegui1.UseVisualStyleBackColor = true;
            this.btnEsegui1.Click += new System.EventHandler(this.btnEsegui1_Click);
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm1";
            this.DS.EnforceConstraints = false;
            // 
            // dgrprestazioni2
            // 
            this.dgrprestazioni2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrprestazioni2.DataMember = "";
            this.dgrprestazioni2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgrprestazioni2.Location = new System.Drawing.Point(12, 239);
            this.dgrprestazioni2.Name = "dgrprestazioni2";
            this.dgrprestazioni2.Size = new System.Drawing.Size(514, 138);
            this.dgrprestazioni2.TabIndex = 5;
            // 
            // btnEsegui2
            // 
            this.btnEsegui2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEsegui2.Location = new System.Drawing.Point(435, 383);
            this.btnEsegui2.Name = "btnEsegui2";
            this.btnEsegui2.Size = new System.Drawing.Size(91, 24);
            this.btnEsegui2.TabIndex = 6;
            this.btnEsegui2.Text = "Esegui";
            this.btnEsegui2.UseVisualStyleBackColor = true;
            this.btnEsegui2.Click += new System.EventHandler(this.btnEsegui2_Click);
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(219, 396);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(91, 24);
            this.btnAnnulla.TabIndex = 8;
            this.btnAnnulla.Text = "Chiudi";
            this.btnAnnulla.UseVisualStyleBackColor = true;
            // 
            // btnMissione
            // 
            this.btnMissione.Location = new System.Drawing.Point(309, 37);
            this.btnMissione.Name = "btnMissione";
            this.btnMissione.Size = new System.Drawing.Size(84, 23);
            this.btnMissione.TabIndex = 9;
            this.btnMissione.Text = "Missioni";
            this.btnMissione.UseVisualStyleBackColor = true;
            this.btnMissione.Click += new System.EventHandler(this.btnMissione_Click);
            // 
            // btnProfessionale
            // 
            this.btnProfessionale.Location = new System.Drawing.Point(219, 37);
            this.btnProfessionale.Name = "btnProfessionale";
            this.btnProfessionale.Size = new System.Drawing.Size(84, 23);
            this.btnProfessionale.TabIndex = 10;
            this.btnProfessionale.Text = "Professionali";
            this.btnProfessionale.UseVisualStyleBackColor = true;
            this.btnProfessionale.Click += new System.EventHandler(this.btnProfessionale_Click);
            // 
            // btnparasubordinati
            // 
            this.btnparasubordinati.Location = new System.Drawing.Point(399, 37);
            this.btnparasubordinati.Name = "btnparasubordinati";
            this.btnparasubordinati.Size = new System.Drawing.Size(98, 23);
            this.btnparasubordinati.TabIndex = 11;
            this.btnparasubordinati.Text = "Parasubordinati";
            this.btnparasubordinati.UseVisualStyleBackColor = true;
            this.btnparasubordinati.Click += new System.EventHandler(this.btnparasubordinati_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Pagamenti relativi al Primo Semestre:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Pagamenti relativi al Secondo Semestre:";
            // 
            // Frm_servicepayment_assegnazioneautomatica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 432);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnparasubordinati);
            this.Controls.Add(this.btnProfessionale);
            this.Controls.Add(this.btnMissione);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnEsegui2);
            this.Controls.Add(this.dgrprestazioni2);
            this.Controls.Add(this.btnEsegui1);
            this.Controls.Add(this.btndipendente);
            this.Controls.Add(this.dgrprestazioni1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnoccasionale);
            this.Name = "Frm_servicepayment_assegnazioneautomatica";
            this.Text = "Frm_servicepayment_assegnazioneautomatica";
            ((System.ComponentModel.ISupportInitialize)(this.dgrprestazioni1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrprestazioni2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public dsmeta DS;
        private System.Windows.Forms.Button btnoccasionale;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGrid dgrprestazioni1;
        private System.Windows.Forms.Button btndipendente;
        private System.Windows.Forms.Button btnEsegui1;
        private System.Windows.Forms.DataGrid dgrprestazioni2;
        private System.Windows.Forms.Button btnEsegui2;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Button btnMissione;
        private System.Windows.Forms.Button btnProfessionale;
        private System.Windows.Forms.Button btnparasubordinati;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;

    }
}
