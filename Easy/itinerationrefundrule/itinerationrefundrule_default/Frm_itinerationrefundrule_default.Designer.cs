
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


namespace itinerationrefundrule_default {
    partial class Frm_itinerationrefundrule_default {
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.btnIndElimina = new System.Windows.Forms.Button();
            this.btnIndInserisci = new System.Windows.Forms.Button();
            this.btnIndModifica = new System.Windows.Forms.Button();
            this.DS = new itinerationrefundrule_default.vistaForm();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(103, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Regola";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(147, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Tag = "itinerationrefundrule.iditinerationrefundrule";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(8, 47);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(616, 20);
            this.textBox2.TabIndex = 3;
            this.textBox2.Tag = "itinerationrefundrule.description";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Descrizione";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(265, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Inizio validità";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(338, 12);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 6;
            this.textBox3.Tag = "itinerationrefundrule.start";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnIndElimina);
            this.groupBox1.Controls.Add(this.btnIndInserisci);
            this.groupBox1.Controls.Add(this.btnIndModifica);
            this.groupBox1.Controls.Add(this.dataGrid1);
            this.groupBox1.Location = new System.Drawing.Point(2, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(628, 371);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dettagli";
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(6, 38);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(616, 327);
            this.dataGrid1.TabIndex = 0;
            this.dataGrid1.Tag = "itinerationrefundruledetail.default";
            // 
            // btnIndElimina
            // 
            this.btnIndElimina.Location = new System.Drawing.Point(222, 10);
            this.btnIndElimina.Name = "btnIndElimina";
            this.btnIndElimina.Size = new System.Drawing.Size(68, 22);
            this.btnIndElimina.TabIndex = 19;
            this.btnIndElimina.Tag = "delete";
            this.btnIndElimina.Text = "Elimina";
            // 
            // btnIndInserisci
            // 
            this.btnIndInserisci.Location = new System.Drawing.Point(62, 10);
            this.btnIndInserisci.Name = "btnIndInserisci";
            this.btnIndInserisci.Size = new System.Drawing.Size(68, 22);
            this.btnIndInserisci.TabIndex = 17;
            this.btnIndInserisci.Tag = "insert.default";
            this.btnIndInserisci.Text = "Inserisci...";
            // 
            // btnIndModifica
            // 
            this.btnIndModifica.Location = new System.Drawing.Point(142, 10);
            this.btnIndModifica.Name = "btnIndModifica";
            this.btnIndModifica.Size = new System.Drawing.Size(69, 22);
            this.btnIndModifica.TabIndex = 18;
            this.btnIndModifica.Tag = "edit.default";
            this.btnIndModifica.Text = "Modifica...";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Frm_itinerationrefundrule_default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 446);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "Frm_itinerationrefundrule_default";
            this.Text = "Frm_itinerationrefundrule_default";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.Button btnIndElimina;
        private System.Windows.Forms.Button btnIndInserisci;
        private System.Windows.Forms.Button btnIndModifica;
        public vistaForm DS;
       
    }
}
