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

namespace foreignallowancerule_default {
    partial class Frm_foreignallowancerule_default {
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
            this.DS = new foreignallowancerule_default.vistaForm();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnLocalita = new System.Windows.Forms.Button();
            this.cmbLocalita = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnIndElimina = new System.Windows.Forms.Button();
            this.btnIndInserisci = new System.Windows.Forms.Button();
            this.btnIndModifica = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Regola";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(59, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Tag = "foreignallowancerule.idforeignallowancerule";
            // 
            // btnLocalita
            // 
            this.btnLocalita.Location = new System.Drawing.Point(3, 41);
            this.btnLocalita.Name = "btnLocalita";
            this.btnLocalita.Size = new System.Drawing.Size(88, 23);
            this.btnLocalita.TabIndex = 9;
            this.btnLocalita.TabStop = false;
            this.btnLocalita.Tag = "manage.foreigncountry.default";
            this.btnLocalita.Text = "Località Estera:";
            this.btnLocalita.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbLocalita
            // 
            this.cmbLocalita.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbLocalita.DataSource = this.DS.foreigncountry;
            this.cmbLocalita.DisplayMember = "description";
            this.cmbLocalita.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocalita.Location = new System.Drawing.Point(97, 43);
            this.cmbLocalita.Name = "cmbLocalita";
            this.cmbLocalita.Size = new System.Drawing.Size(529, 21);
            this.cmbLocalita.TabIndex = 10;
            this.cmbLocalita.Tag = "foreignallowancerule.idforeigncountry";
            this.cmbLocalita.ValueMember = "idforeigncountry";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(174, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Inizio validità";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(247, 6);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 12;
            this.textBox2.Tag = "foreignallowancerule.start";
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(6, 42);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(611, 325);
            this.dataGrid1.TabIndex = 13;
            this.dataGrid1.Tag = "foreignallowanceruledetail.default";
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
            this.groupBox1.Location = new System.Drawing.Point(3, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(623, 373);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dettagli della regola";
            // 
            // btnIndElimina
            // 
            this.btnIndElimina.Location = new System.Drawing.Point(276, 14);
            this.btnIndElimina.Name = "btnIndElimina";
            this.btnIndElimina.Size = new System.Drawing.Size(68, 22);
            this.btnIndElimina.TabIndex = 16;
            this.btnIndElimina.Tag = "delete";
            this.btnIndElimina.Text = "Elimina";
            // 
            // btnIndInserisci
            // 
            this.btnIndInserisci.Location = new System.Drawing.Point(116, 14);
            this.btnIndInserisci.Name = "btnIndInserisci";
            this.btnIndInserisci.Size = new System.Drawing.Size(68, 22);
            this.btnIndInserisci.TabIndex = 14;
            this.btnIndInserisci.Tag = "insert.default";
            this.btnIndInserisci.Text = "Inserisci...";
            // 
            // btnIndModifica
            // 
            this.btnIndModifica.Location = new System.Drawing.Point(196, 14);
            this.btnIndModifica.Name = "btnIndModifica";
            this.btnIndModifica.Size = new System.Drawing.Size(69, 22);
            this.btnIndModifica.TabIndex = 15;
            this.btnIndModifica.Tag = "edit.default";
            this.btnIndModifica.Text = "Modifica...";
            // 
            // Frm_foreignallowancerule_default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 446);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnLocalita);
            this.Controls.Add(this.cmbLocalita);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "Frm_foreignallowancerule_default";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnLocalita;
        private System.Windows.Forms.ComboBox cmbLocalita;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnIndElimina;
        private System.Windows.Forms.Button btnIndInserisci;
        private System.Windows.Forms.Button btnIndModifica;
        
    }
}