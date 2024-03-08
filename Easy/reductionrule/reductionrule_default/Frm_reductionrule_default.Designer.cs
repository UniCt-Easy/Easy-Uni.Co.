
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


namespace reductionrule_default
{
    partial class Frm_reductionrule_default
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
            this.DS = new reductionrule_default.vistaForm();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnIndElimina = new System.Windows.Forms.Button();
            this.btnIndInserisci = new System.Windows.Forms.Button();
            this.btnIndModifica = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.txtStart = new System.Windows.Forms.TextBox();
            this.txtRegola = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
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
            this.groupBox1.Location = new System.Drawing.Point(3, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(448, 289);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dettagli della regola";
            // 
            // btnIndElimina
            // 
            this.btnIndElimina.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIndElimina.Location = new System.Drawing.Point(375, 19);
            this.btnIndElimina.Name = "btnIndElimina";
            this.btnIndElimina.Size = new System.Drawing.Size(68, 22);
            this.btnIndElimina.TabIndex = 19;
            this.btnIndElimina.Tag = "delete";
            this.btnIndElimina.Text = "Elimina";
            // 
            // btnIndInserisci
            // 
            this.btnIndInserisci.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIndInserisci.Location = new System.Drawing.Point(215, 19);
            this.btnIndInserisci.Name = "btnIndInserisci";
            this.btnIndInserisci.Size = new System.Drawing.Size(68, 22);
            this.btnIndInserisci.TabIndex = 17;
            this.btnIndInserisci.Tag = "insert.default";
            this.btnIndInserisci.Text = "Inserisci...";
            // 
            // btnIndModifica
            // 
            this.btnIndModifica.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIndModifica.Location = new System.Drawing.Point(295, 19);
            this.btnIndModifica.Name = "btnIndModifica";
            this.btnIndModifica.Size = new System.Drawing.Size(69, 22);
            this.btnIndModifica.TabIndex = 18;
            this.btnIndModifica.Tag = "edit.default";
            this.btnIndModifica.Text = "Modifica...";
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(11, 47);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(431, 236);
            this.dataGrid1.TabIndex = 0;
            this.dataGrid1.Tag = "reductionruledetail.default";
            // 
            // txtStart
            // 
            this.txtStart.Location = new System.Drawing.Point(278, 12);
            this.txtStart.Name = "txtStart";
            this.txtStart.Size = new System.Drawing.Size(103, 20);
            this.txtStart.TabIndex = 8;
            this.txtStart.Tag = "reductionrule.start";
            // 
            // txtRegola
            // 
            this.txtRegola.Location = new System.Drawing.Point(72, 12);
            this.txtRegola.Name = "txtRegola";
            this.txtRegola.Size = new System.Drawing.Size(77, 20);
            this.txtRegola.TabIndex = 7;
            this.txtRegola.Tag = "reductionrule.idreductionrule";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(204, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Inizio Validità";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Regola";
            // 
            // Frm_reductionrule_default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 353);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtStart);
            this.Controls.Add(this.txtRegola);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Frm_reductionrule_default";
            this.Text = "Frm_reductionrule_default";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnIndElimina;
        private System.Windows.Forms.Button btnIndInserisci;
        private System.Windows.Forms.Button btnIndModifica;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.TextBox txtStart;
        private System.Windows.Forms.TextBox txtRegola;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;

    }
}
