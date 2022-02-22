
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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


namespace pettycashoperationunderwriting_default
{
    partial class Frm_pettycashoperationunderwriting_default
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
            this.gboxDocCollegato = new System.Windows.Forms.GroupBox();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDataDocumento = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtAdateExpense = new System.Windows.Forms.TextBox();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.txtDescrExpense = new System.Windows.Forms.TextBox();
            this.groupCredDeb = new System.Windows.Forms.GroupBox();
            this.txtCredDeb = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gboxFinanziamento = new System.Windows.Forms.GroupBox();
            this.txtUnderwriting = new System.Windows.Forms.TextBox();
            this.btnFinanziamento = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbFondoPS = new System.Windows.Forms.ComboBox();
            this.DS = new pettycashoperationunderwriting_default.vistaForm();
            this.grpOperazione = new System.Windows.Forms.GroupBox();
            this.txtNumOp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEsercOp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gboxDocCollegato.SuspendLayout();
            this.groupBox20.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.groupCredDeb.SuspendLayout();
            this.gboxFinanziamento.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.grpOperazione.SuspendLayout();
            this.SuspendLayout();
            // 
            // gboxDocCollegato
            // 
            this.gboxDocCollegato.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxDocCollegato.Controls.Add(this.txtDocumento);
            this.gboxDocCollegato.Controls.Add(this.label10);
            this.gboxDocCollegato.Controls.Add(this.txtDataDocumento);
            this.gboxDocCollegato.Controls.Add(this.label14);
            this.gboxDocCollegato.Location = new System.Drawing.Point(368, 155);
            this.gboxDocCollegato.Name = "gboxDocCollegato";
            this.gboxDocCollegato.Size = new System.Drawing.Size(345, 56);
            this.gboxDocCollegato.TabIndex = 14;
            this.gboxDocCollegato.TabStop = false;
            this.gboxDocCollegato.Text = "Documento collegato";
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(8, 32);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(200, 20);
            this.txtDocumento.TabIndex = 1;
            this.txtDocumento.Tag = "pettycashoperation.doc?pettycashopunderwritingview.doc";
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
            this.txtDataDocumento.Tag = "pettycashoperation.docdate?pettycashopunderwritingview.docdate";
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
            // groupBox20
            // 
            this.groupBox20.Controls.Add(this.label15);
            this.groupBox20.Controls.Add(this.txtAdateExpense);
            this.groupBox20.Location = new System.Drawing.Point(12, 131);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Size = new System.Drawing.Size(344, 40);
            this.groupBox20.TabIndex = 8;
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
            this.txtAdateExpense.Tag = "pettycashoperation.adate?pettycashopunderwritingview.adate";
            this.txtAdateExpense.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox17
            // 
            this.groupBox17.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox17.Controls.Add(this.txtDescrExpense);
            this.groupBox17.Location = new System.Drawing.Point(367, 33);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(344, 80);
            this.groupBox17.TabIndex = 12;
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
            this.txtDescrExpense.Size = new System.Drawing.Size(328, 48);
            this.txtDescrExpense.TabIndex = 1;
            this.txtDescrExpense.Tag = "pettycashoperation.description?pettycashopunderwritingview.description";
            // 
            // groupCredDeb
            // 
            this.groupCredDeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupCredDeb.Controls.Add(this.txtCredDeb);
            this.groupCredDeb.Location = new System.Drawing.Point(367, 112);
            this.groupCredDeb.Name = "groupCredDeb";
            this.groupCredDeb.Size = new System.Drawing.Size(344, 40);
            this.groupCredDeb.TabIndex = 13;
            this.groupCredDeb.TabStop = false;
            this.groupCredDeb.Tag = "AutoChoose.txtCredDeb.lista.(active=\'S\')";
            this.groupCredDeb.Text = "Percipiente";
            // 
            // txtCredDeb
            // 
            this.txtCredDeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCredDeb.Location = new System.Drawing.Point(8, 16);
            this.txtCredDeb.Name = "txtCredDeb";
            this.txtCredDeb.Size = new System.Drawing.Size(327, 20);
            this.txtCredDeb.TabIndex = 1;
            this.txtCredDeb.Tag = "registry.title?pettycashopunderwritingview.registry";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(107, 240);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(145, 20);
            this.txtAmount.TabIndex = 11;
            this.txtAmount.Tag = "pettycashoperationunderwriting.amount?pettycashopunderwritingview.amount";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 247);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Importo finanziato";
            // 
            // gboxFinanziamento
            // 
            this.gboxFinanziamento.Controls.Add(this.txtUnderwriting);
            this.gboxFinanziamento.Controls.Add(this.btnFinanziamento);
            this.gboxFinanziamento.Location = new System.Drawing.Point(12, 172);
            this.gboxFinanziamento.Name = "gboxFinanziamento";
            this.gboxFinanziamento.Size = new System.Drawing.Size(344, 61);
            this.gboxFinanziamento.TabIndex = 9;
            this.gboxFinanziamento.TabStop = false;
            this.gboxFinanziamento.Tag = "AutoChoose.txtUnderwriting.default.(active = \'S\')";
            // 
            // txtUnderwriting
            // 
            this.txtUnderwriting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUnderwriting.Location = new System.Drawing.Point(116, 22);
            this.txtUnderwriting.Name = "txtUnderwriting";
            this.txtUnderwriting.Size = new System.Drawing.Size(222, 20);
            this.txtUnderwriting.TabIndex = 3;
            this.txtUnderwriting.Tag = "underwriting.title?pettycashopunderwritingview.underwriting";
            // 
            // btnFinanziamento
            // 
            this.btnFinanziamento.Location = new System.Drawing.Point(6, 19);
            this.btnFinanziamento.Name = "btnFinanziamento";
            this.btnFinanziamento.Size = new System.Drawing.Size(104, 23);
            this.btnFinanziamento.TabIndex = 2;
            this.btnFinanziamento.Tag = "choose.underwriting.default";
            this.btnFinanziamento.Text = "Finanziamento";
            this.btnFinanziamento.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbFondoPS);
            this.groupBox1.Location = new System.Drawing.Point(18, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 40);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fondo Economale";
            // 
            // cmbFondoPS
            // 
            this.cmbFondoPS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFondoPS.DataSource = this.DS.pettycash;
            this.cmbFondoPS.DisplayMember = "description";
            this.cmbFondoPS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFondoPS.Location = new System.Drawing.Point(8, 16);
            this.cmbFondoPS.Name = "cmbFondoPS";
            this.cmbFondoPS.Size = new System.Drawing.Size(296, 21);
            this.cmbFondoPS.TabIndex = 1;
            this.cmbFondoPS.Tag = "pettycashoperationunderwriting.idpettycash";
            this.cmbFondoPS.ValueMember = "idpettycash";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // grpOperazione
            // 
            this.grpOperazione.Controls.Add(this.txtNumOp);
            this.grpOperazione.Controls.Add(this.label3);
            this.grpOperazione.Controls.Add(this.txtEsercOp);
            this.grpOperazione.Controls.Add(this.label2);
            this.grpOperazione.Location = new System.Drawing.Point(18, 33);
            this.grpOperazione.Name = "grpOperazione";
            this.grpOperazione.Size = new System.Drawing.Size(312, 40);
            this.grpOperazione.TabIndex = 16;
            this.grpOperazione.TabStop = false;
            this.grpOperazione.Text = "Operazione";
            // 
            // txtNumOp
            // 
            this.txtNumOp.Location = new System.Drawing.Point(232, 16);
            this.txtNumOp.Name = "txtNumOp";
            this.txtNumOp.Size = new System.Drawing.Size(72, 20);
            this.txtNumOp.TabIndex = 1;
            this.txtNumOp.Tag = "pettycashoperation.noperation?pettycashopunderwritingview.noperation";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(184, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Numero:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercOp
            // 
            this.txtEsercOp.Location = new System.Drawing.Point(128, 16);
            this.txtEsercOp.Name = "txtEsercOp";
            this.txtEsercOp.ReadOnly = true;
            this.txtEsercOp.Size = new System.Drawing.Size(56, 20);
            this.txtEsercOp.TabIndex = 1;
            this.txtEsercOp.TabStop = false;
            this.txtEsercOp.Tag = "pettycashoperation.yoperation?pettycashopunderwritingview.yoperation";
            this.txtEsercOp.Leave += new System.EventHandler(this.txtEsercOp_Leave);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(64, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Esercizio:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Frm_pettycashoperationunderwriting_default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 290);
            this.Controls.Add(this.grpOperazione);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gboxDocCollegato);
            this.Controls.Add(this.groupBox20);
            this.Controls.Add(this.groupBox17);
            this.Controls.Add(this.groupCredDeb);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gboxFinanziamento);
            this.Name = "Frm_pettycashoperationunderwriting_default";
            this.Text = "Frm_pettycashoperationunderwriting_default";
            this.gboxDocCollegato.ResumeLayout(false);
            this.gboxDocCollegato.PerformLayout();
            this.groupBox20.ResumeLayout(false);
            this.groupBox20.PerformLayout();
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.groupCredDeb.ResumeLayout(false);
            this.groupCredDeb.PerformLayout();
            this.gboxFinanziamento.ResumeLayout(false);
            this.gboxFinanziamento.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.grpOperazione.ResumeLayout(false);
            this.grpOperazione.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.GroupBox gboxDocCollegato;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDataDocumento;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox20;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtAdateExpense;
        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.TextBox txtDescrExpense;
        private System.Windows.Forms.GroupBox groupCredDeb;
        private System.Windows.Forms.TextBox txtCredDeb;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gboxFinanziamento;
        private System.Windows.Forms.TextBox txtUnderwriting;
        private System.Windows.Forms.Button btnFinanziamento;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbFondoPS;
        private System.Windows.Forms.GroupBox grpOperazione;
        private System.Windows.Forms.TextBox txtNumOp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEsercOp;
        private System.Windows.Forms.Label label2;

    }
}
