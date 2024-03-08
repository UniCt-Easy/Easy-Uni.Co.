
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


namespace underwritingappropriation_default {
    partial class Frm_underwritingappropriation_default {
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
            this.gboxFinanziamento = new System.Windows.Forms.GroupBox();
            this.txtUnderwriting = new System.Windows.Forms.TextBox();
            this.btnFinanziamento = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.DS = new underwritingappropriation_default.vistaForm();
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtAdateExpense = new System.Windows.Forms.TextBox();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.txtDescrExpense = new System.Windows.Forms.TextBox();
            this.groupCredDeb = new System.Windows.Forms.GroupBox();
            this.txtCredDeb = new System.Windows.Forms.TextBox();
            this.gboxMovimento = new System.Windows.Forms.GroupBox();
            this.txtFaseSpesa = new System.Windows.Forms.TextBox();
            this.btnSelectMov = new System.Windows.Forms.Button();
            this.txtNmovExpense = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtYmovExpense = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblFaseMovimento = new System.Windows.Forms.Label();
            this.gboxDocCollegato = new System.Windows.Forms.GroupBox();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDataDocumento = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.gboxResponsabile = new System.Windows.Forms.GroupBox();
            this.txtResponsabile = new System.Windows.Forms.TextBox();
            this.gboxFinanziamento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox20.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.groupCredDeb.SuspendLayout();
            this.gboxMovimento.SuspendLayout();
            this.gboxDocCollegato.SuspendLayout();
            this.gboxResponsabile.SuspendLayout();
            this.SuspendLayout();
            // 
            // gboxFinanziamento
            // 
            this.gboxFinanziamento.Controls.Add(this.txtUnderwriting);
            this.gboxFinanziamento.Controls.Add(this.btnFinanziamento);
            this.gboxFinanziamento.Location = new System.Drawing.Point(12, 181);
            this.gboxFinanziamento.Name = "gboxFinanziamento";
            this.gboxFinanziamento.Size = new System.Drawing.Size(380, 71);
            this.gboxFinanziamento.TabIndex = 6;
            this.gboxFinanziamento.TabStop = false;
            this.gboxFinanziamento.Tag = "AutoChoose.txtUnderwriting.default.(active = \'S\')";
            // 
            // txtUnderwriting
            // 
            this.txtUnderwriting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUnderwriting.Location = new System.Drawing.Point(5, 45);
            this.txtUnderwriting.Name = "txtUnderwriting";
            this.txtUnderwriting.Size = new System.Drawing.Size(258, 20);
            this.txtUnderwriting.TabIndex = 3;
            this.txtUnderwriting.Tag = "underwriting.title?underwritingappropriationview.underwriting";
            // 
            // btnFinanziamento
            // 
            this.btnFinanziamento.Location = new System.Drawing.Point(5, 16);
            this.btnFinanziamento.Name = "btnFinanziamento";
            this.btnFinanziamento.Size = new System.Drawing.Size(104, 23);
            this.btnFinanziamento.TabIndex = 2;
            this.btnFinanziamento.Tag = "choose.underwriting.default";
            this.btnFinanziamento.Text = "Finanziamento";
            this.btnFinanziamento.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 262);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Importo finanziato";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(109, 258);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(145, 20);
            this.txtAmount.TabIndex = 7;
            this.txtAmount.Tag = "underwritingappropriation.amount?underwritingappropriationview.amount";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // groupBox20
            // 
            this.groupBox20.Controls.Add(this.label15);
            this.groupBox20.Controls.Add(this.txtAdateExpense);
            this.groupBox20.Location = new System.Drawing.Point(12, 140);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Size = new System.Drawing.Size(380, 40);
            this.groupBox20.TabIndex = 4;
            this.groupBox20.TabStop = false;
            this.groupBox20.Text = "Data";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(2, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 20);
            this.label15.TabIndex = 0;
            this.label15.Text = "Contabile";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAdateExpense
            // 
            this.txtAdateExpense.Location = new System.Drawing.Point(67, 15);
            this.txtAdateExpense.Name = "txtAdateExpense";
            this.txtAdateExpense.Size = new System.Drawing.Size(72, 20);
            this.txtAdateExpense.TabIndex = 1;
            this.txtAdateExpense.Tag = "expense.adate?underwritingappropriationview.adate";
            this.txtAdateExpense.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox17
            // 
            this.groupBox17.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox17.Controls.Add(this.txtDescrExpense);
            this.groupBox17.Location = new System.Drawing.Point(399, 12);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(345, 80);
            this.groupBox17.TabIndex = 1;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "Descrizione";
            // 
            // txtDescrExpense
            // 
            this.txtDescrExpense.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrExpense.Location = new System.Drawing.Point(8, 16);
            this.txtDescrExpense.Multiline = true;
            this.txtDescrExpense.Name = "txtDescrExpense";
            this.txtDescrExpense.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescrExpense.Size = new System.Drawing.Size(329, 58);
            this.txtDescrExpense.TabIndex = 1;
            this.txtDescrExpense.Tag = "expense.description?underwritingappropriationview.description";
            // 
            // groupCredDeb
            // 
            this.groupCredDeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupCredDeb.Controls.Add(this.txtCredDeb);
            this.groupCredDeb.Location = new System.Drawing.Point(398, 98);
            this.groupCredDeb.Name = "groupCredDeb";
            this.groupCredDeb.Size = new System.Drawing.Size(346, 40);
            this.groupCredDeb.TabIndex = 3;
            this.groupCredDeb.TabStop = false;
            this.groupCredDeb.Tag = "AutoChoose.txtCredDeb.lista.(active=\'S\')";
            this.groupCredDeb.Text = "Percipiente";
            // 
            // txtCredDeb
            // 
            this.txtCredDeb.Location = new System.Drawing.Point(8, 16);
            this.txtCredDeb.Name = "txtCredDeb";
            this.txtCredDeb.Size = new System.Drawing.Size(326, 20);
            this.txtCredDeb.TabIndex = 1;
            this.txtCredDeb.Tag = "registry.title?underwritingappropriationview.registry";
            // 
            // gboxMovimento
            // 
            this.gboxMovimento.Controls.Add(this.txtFaseSpesa);
            this.gboxMovimento.Controls.Add(this.btnSelectMov);
            this.gboxMovimento.Controls.Add(this.txtNmovExpense);
            this.gboxMovimento.Controls.Add(this.label4);
            this.gboxMovimento.Controls.Add(this.txtYmovExpense);
            this.gboxMovimento.Controls.Add(this.label5);
            this.gboxMovimento.Controls.Add(this.lblFaseMovimento);
            this.gboxMovimento.Location = new System.Drawing.Point(12, 12);
            this.gboxMovimento.Name = "gboxMovimento";
            this.gboxMovimento.Size = new System.Drawing.Size(380, 80);
            this.gboxMovimento.TabIndex = 0;
            this.gboxMovimento.TabStop = false;
            this.gboxMovimento.Tag = "";
            this.gboxMovimento.Text = "Movimento";
            // 
            // txtFaseSpesa
            // 
            this.txtFaseSpesa.Location = new System.Drawing.Point(140, 18);
            this.txtFaseSpesa.Name = "txtFaseSpesa";
            this.txtFaseSpesa.ReadOnly = true;
            this.txtFaseSpesa.Size = new System.Drawing.Size(197, 20);
            this.txtFaseSpesa.TabIndex = 2;
            this.txtFaseSpesa.Tag = "expensephase.description?underwritingappropriationview.expensephase";
            // 
            // btnSelectMov
            // 
            this.btnSelectMov.Location = new System.Drawing.Point(15, 17);
            this.btnSelectMov.Name = "btnSelectMov";
            this.btnSelectMov.Size = new System.Drawing.Size(75, 23);
            this.btnSelectMov.TabIndex = 0;
            this.btnSelectMov.Tag = "";
            this.btnSelectMov.Text = "Seleziona";
            this.btnSelectMov.Click += new System.EventHandler(this.btnSelectMov_Click);
            // 
            // txtNmovExpense
            // 
            this.txtNmovExpense.Location = new System.Drawing.Point(140, 49);
            this.txtNmovExpense.Name = "txtNmovExpense";
            this.txtNmovExpense.Size = new System.Drawing.Size(48, 20);
            this.txtNmovExpense.TabIndex = 6;
            this.txtNmovExpense.Tag = "expense.nmov?underwritingappropriationview.nmov";
            this.txtNmovExpense.Leave += new System.EventHandler(this.txtNmovExpense_Leave);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(102, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Num.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtYmovExpense
            // 
            this.txtYmovExpense.Location = new System.Drawing.Point(52, 49);
            this.txtYmovExpense.Name = "txtYmovExpense";
            this.txtYmovExpense.Size = new System.Drawing.Size(39, 20);
            this.txtYmovExpense.TabIndex = 4;
            this.txtYmovExpense.Tag = "expense.ymov.year?underwritingappropriationview.ymov";
            this.txtYmovExpense.Leave += new System.EventHandler(this.txtYmovExpense_Leave);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(12, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Eserc.";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFaseMovimento
            // 
            this.lblFaseMovimento.Location = new System.Drawing.Point(102, 19);
            this.lblFaseMovimento.Name = "lblFaseMovimento";
            this.lblFaseMovimento.Size = new System.Drawing.Size(32, 20);
            this.lblFaseMovimento.TabIndex = 1;
            this.lblFaseMovimento.Text = "Fase";
            this.lblFaseMovimento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gboxDocCollegato
            // 
            this.gboxDocCollegato.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxDocCollegato.Controls.Add(this.txtDocumento);
            this.gboxDocCollegato.Controls.Add(this.label10);
            this.gboxDocCollegato.Controls.Add(this.txtDataDocumento);
            this.gboxDocCollegato.Controls.Add(this.label14);
            this.gboxDocCollegato.Location = new System.Drawing.Point(398, 140);
            this.gboxDocCollegato.Name = "gboxDocCollegato";
            this.gboxDocCollegato.Size = new System.Drawing.Size(347, 56);
            this.gboxDocCollegato.TabIndex = 5;
            this.gboxDocCollegato.TabStop = false;
            this.gboxDocCollegato.Text = "Documento collegato";
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(8, 32);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(200, 20);
            this.txtDocumento.TabIndex = 1;
            this.txtDocumento.Tag = "expense.doc?underwritingappropriationview.doc";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(8, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 18);
            this.label10.TabIndex = 0;
            this.label10.Text = "Descrizione";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDataDocumento
            // 
            this.txtDataDocumento.Location = new System.Drawing.Point(232, 32);
            this.txtDataDocumento.Name = "txtDataDocumento";
            this.txtDataDocumento.Size = new System.Drawing.Size(72, 20);
            this.txtDataDocumento.TabIndex = 2;
            this.txtDataDocumento.Tag = "expense.docdate?underwritingappropriationview.docdate";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(232, 14);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 18);
            this.label14.TabIndex = 0;
            this.label14.Text = "Data";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gboxResponsabile
            // 
            this.gboxResponsabile.Controls.Add(this.txtResponsabile);
            this.gboxResponsabile.Location = new System.Drawing.Point(12, 98);
            this.gboxResponsabile.Name = "gboxResponsabile";
            this.gboxResponsabile.Size = new System.Drawing.Size(380, 40);
            this.gboxResponsabile.TabIndex = 2;
            this.gboxResponsabile.TabStop = false;
            this.gboxResponsabile.Tag = "AutoChoose.txtResponsabile.default.(financeactive=\'S\')";
            this.gboxResponsabile.Text = "Responsabile";
            // 
            // txtResponsabile
            // 
            this.txtResponsabile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResponsabile.Location = new System.Drawing.Point(5, 14);
            this.txtResponsabile.Name = "txtResponsabile";
            this.txtResponsabile.Size = new System.Drawing.Size(369, 20);
            this.txtResponsabile.TabIndex = 0;
            this.txtResponsabile.Tag = "manager.title?x";
            // 
            // Frm_underwritingappropriation_default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 296);
            this.Controls.Add(this.gboxResponsabile);
            this.Controls.Add(this.gboxDocCollegato);
            this.Controls.Add(this.groupBox20);
            this.Controls.Add(this.groupBox17);
            this.Controls.Add(this.groupCredDeb);
            this.Controls.Add(this.gboxMovimento);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gboxFinanziamento);
            this.Name = "Frm_underwritingappropriation_default";
            this.Tag = "";
            this.Text = "Frm_underwritingappropriation_default";
            this.gboxFinanziamento.ResumeLayout(false);
            this.gboxFinanziamento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox20.ResumeLayout(false);
            this.groupBox20.PerformLayout();
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.groupCredDeb.ResumeLayout(false);
            this.groupCredDeb.PerformLayout();
            this.gboxMovimento.ResumeLayout(false);
            this.gboxMovimento.PerformLayout();
            this.gboxDocCollegato.ResumeLayout(false);
            this.gboxDocCollegato.PerformLayout();
            this.gboxResponsabile.ResumeLayout(false);
            this.gboxResponsabile.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.GroupBox gboxFinanziamento;
        private System.Windows.Forms.TextBox txtUnderwriting;
        private System.Windows.Forms.Button btnFinanziamento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.GroupBox groupBox20;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtAdateExpense;
        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.TextBox txtDescrExpense;
        private System.Windows.Forms.GroupBox groupCredDeb;
        private System.Windows.Forms.TextBox txtCredDeb;
        private System.Windows.Forms.GroupBox gboxMovimento;
        private System.Windows.Forms.TextBox txtFaseSpesa;
        private System.Windows.Forms.Button btnSelectMov;
        private System.Windows.Forms.TextBox txtNmovExpense;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtYmovExpense;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblFaseMovimento;
        private System.Windows.Forms.GroupBox gboxDocCollegato;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDataDocumento;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox gboxResponsabile;
        public System.Windows.Forms.TextBox txtResponsabile;

    }
}
