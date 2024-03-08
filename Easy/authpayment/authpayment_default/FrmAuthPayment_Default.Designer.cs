
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


namespace authpayment_default {
    partial class FrmAuthPayment_Default {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            inChiusura = true;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAuthPayment_Default));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEsercMovimento = new System.Windows.Forms.TextBox();
            this.txtNumMovimento = new System.Windows.Forms.TextBox();
            this.DS = new authpayment_default.vistaForm();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtNoteStato = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtCreditoreDebitore = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtAutorizzazione = new System.Windows.Forms.TextBox();
            this.txtInvio = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.txtDataDoc = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtTotale = new System.Windows.Forms.TextBox();
            this.btnDelExpense = new System.Windows.Forms.Button();
            this.btnEditExpense = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btnInsertExpense = new System.Windows.Forms.Button();
            this.dgDetail = new System.Windows.Forms.DataGrid();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtEsercMovimento);
            this.groupBox1.Controls.Add(this.txtNumMovimento);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(160, 80);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dati";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Esercizio:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Numero:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercMovimento
            // 
            this.txtEsercMovimento.Location = new System.Drawing.Point(72, 16);
            this.txtEsercMovimento.Name = "txtEsercMovimento";
            this.txtEsercMovimento.ReadOnly = true;
            this.txtEsercMovimento.Size = new System.Drawing.Size(80, 20);
            this.txtEsercMovimento.TabIndex = 3;
            this.txtEsercMovimento.Tag = "authpayment.yauthpayment.year";
            // 
            // txtNumMovimento
            // 
            this.txtNumMovimento.Location = new System.Drawing.Point(72, 48);
            this.txtNumMovimento.Name = "txtNumMovimento";
            this.txtNumMovimento.Size = new System.Drawing.Size(80, 20);
            this.txtNumMovimento.TabIndex = 4;
            this.txtNumMovimento.Tag = "authpayment.nauthpayment";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtNoteStato);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Location = new System.Drawing.Point(177, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(537, 97);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Stato Autorizzativo";
            // 
            // txtNoteStato
            // 
            this.txtNoteStato.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNoteStato.Location = new System.Drawing.Point(6, 44);
            this.txtNoteStato.Multiline = true;
            this.txtNoteStato.Name = "txtNoteStato";
            this.txtNoteStato.ReadOnly = true;
            this.txtNoteStato.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNoteStato.Size = new System.Drawing.Size(525, 47);
            this.txtNoteStato.TabIndex = 9;
            this.txtNoteStato.Tag = "";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DataSource = this.DS.authstatus;
            this.comboBox1.DisplayMember = "description";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(419, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.Tag = "authpayment.idauthstatus";
            this.comboBox1.ValueMember = "idauthstatus";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.txtCreditoreDebitore);
            this.groupBox3.Location = new System.Drawing.Point(6, 105);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(708, 48);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Tag = "AutoChoose.txtCreditoreDebitore.lista.(active=\'S\')";
            this.groupBox3.Text = "Percipiente";
            // 
            // txtCreditoreDebitore
            // 
            this.txtCreditoreDebitore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCreditoreDebitore.Location = new System.Drawing.Point(8, 16);
            this.txtCreditoreDebitore.Name = "txtCreditoreDebitore";
            this.txtCreditoreDebitore.Size = new System.Drawing.Size(694, 20);
            this.txtCreditoreDebitore.TabIndex = 1;
            this.txtCreditoreDebitore.Tag = "registrymainview.title?authpaymenthview.registry";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "Descrizione:";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(3, 173);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(599, 60);
            this.textBox1.TabIndex = 4;
            this.textBox1.Tag = "authpayment.description";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtAutorizzazione);
            this.groupBox5.Controls.Add(this.txtInvio);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Location = new System.Drawing.Point(220, 239);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(219, 74);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Date";
            // 
            // txtAutorizzazione
            // 
            this.txtAutorizzazione.Location = new System.Drawing.Point(133, 47);
            this.txtAutorizzazione.Name = "txtAutorizzazione";
            this.txtAutorizzazione.Size = new System.Drawing.Size(80, 20);
            this.txtAutorizzazione.TabIndex = 9;
            this.txtAutorizzazione.Tag = "authpayment.authorize_date";
            // 
            // txtInvio
            // 
            this.txtInvio.Location = new System.Drawing.Point(133, 17);
            this.txtInvio.Name = "txtInvio";
            this.txtInvio.Size = new System.Drawing.Size(80, 20);
            this.txtInvio.TabIndex = 8;
            this.txtInvio.Tag = "authpayment.sent_date";
            this.txtInvio.Leave += new System.EventHandler(this.txtInvio_Leave);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "Tacita autorizzazione:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(11, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "di Invio:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Documento";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(22, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Data";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(76, 17);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(127, 20);
            this.txtDocumento.TabIndex = 8;
            this.txtDocumento.Tag = "authpayment.doc";
            // 
            // txtDataDoc
            // 
            this.txtDataDoc.Location = new System.Drawing.Point(76, 43);
            this.txtDataDoc.Name = "txtDataDoc";
            this.txtDataDoc.Size = new System.Drawing.Size(80, 20);
            this.txtDataDoc.TabIndex = 9;
            this.txtDataDoc.Tag = "authpayment.docdate";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtDataDoc);
            this.groupBox4.Controls.Add(this.txtDocumento);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(6, 239);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(208, 74);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Documento";
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.textBox5);
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.Location = new System.Drawing.Point(612, 159);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(100, 74);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Importi";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(9, 43);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(80, 20);
            this.textBox5.TabIndex = 8;
            this.textBox5.Tag = "authpayment.attach_amount";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(11, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 16);
            this.label9.TabIndex = 6;
            this.label9.Text = "da Pignorare:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox7.Controls.Add(this.txtTotale);
            this.groupBox7.Controls.Add(this.btnDelExpense);
            this.groupBox7.Controls.Add(this.btnEditExpense);
            this.groupBox7.Controls.Add(this.label8);
            this.groupBox7.Controls.Add(this.btnInsertExpense);
            this.groupBox7.Controls.Add(this.dgDetail);
            this.groupBox7.Location = new System.Drawing.Point(3, 317);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(711, 211);
            this.groupBox7.TabIndex = 8;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Movimenti Finanziari";
            // 
            // txtTotale
            // 
            this.txtTotale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotale.Location = new System.Drawing.Point(605, 13);
            this.txtTotale.Name = "txtTotale";
            this.txtTotale.ReadOnly = true;
            this.txtTotale.Size = new System.Drawing.Size(94, 20);
            this.txtTotale.TabIndex = 9;
            this.txtTotale.TabStop = false;
            this.txtTotale.Tag = "";
            this.txtTotale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnDelExpense
            // 
            this.btnDelExpense.Location = new System.Drawing.Point(182, 16);
            this.btnDelExpense.Name = "btnDelExpense";
            this.btnDelExpense.Size = new System.Drawing.Size(75, 23);
            this.btnDelExpense.TabIndex = 9;
            this.btnDelExpense.TabStop = false;
            this.btnDelExpense.Tag = "delete";
            this.btnDelExpense.Text = "Cancella";
            // 
            // btnEditExpense
            // 
            this.btnEditExpense.Location = new System.Drawing.Point(94, 16);
            this.btnEditExpense.Name = "btnEditExpense";
            this.btnEditExpense.Size = new System.Drawing.Size(75, 23);
            this.btnEditExpense.TabIndex = 8;
            this.btnEditExpense.TabStop = false;
            this.btnEditExpense.Tag = "edit.single";
            this.btnEditExpense.Text = "Correggi";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(524, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 16);
            this.label8.TabIndex = 7;
            this.label8.Text = "Totale:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnInsertExpense
            // 
            this.btnInsertExpense.Location = new System.Drawing.Point(6, 16);
            this.btnInsertExpense.Name = "btnInsertExpense";
            this.btnInsertExpense.Size = new System.Drawing.Size(75, 23);
            this.btnInsertExpense.TabIndex = 7;
            this.btnInsertExpense.TabStop = false;
            this.btnInsertExpense.Tag = "insert.single";
            this.btnInsertExpense.Text = "Aggiungi";
            // 
            // dgDetail
            // 
            this.dgDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgDetail.DataMember = "";
            this.dgDetail.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgDetail.Location = new System.Drawing.Point(6, 45);
            this.dgDetail.Name = "dgDetail";
            this.dgDetail.Size = new System.Drawing.Size(697, 160);
            this.dgDetail.TabIndex = 0;
            this.dgDetail.Tag = "authpaymentexpense.single.single";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(445, 239);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(269, 78);
            this.textBox2.TabIndex = 9;
            this.textBox2.TabStop = false;
            this.textBox2.Text = resources.GetString("textBox2.Text");
            // 
            // FrmAuthPayment_Default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 540);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmAuthPayment_Default";
            this.Text = "FrmAuthPayment_Default";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEsercMovimento;
        private System.Windows.Forms.TextBox txtNumMovimento;
        public vistaForm DS;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtCreditoreDebitore;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtAutorizzazione;
        private System.Windows.Forms.TextBox txtInvio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.TextBox txtDataDoc;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btnDelExpense;
        private System.Windows.Forms.Button btnEditExpense;
        private System.Windows.Forms.Button btnInsertExpense;
        private System.Windows.Forms.DataGrid dgDetail;
        private System.Windows.Forms.TextBox txtTotale;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNoteStato;
        private System.Windows.Forms.TextBox textBox2;
    }
}
