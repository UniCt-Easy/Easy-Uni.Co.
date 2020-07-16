/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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

namespace entrydetailaccrual_default
{
    partial class Frm_entrydetailaccrual_default
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gboxClienteFornitore = new System.Windows.Forms.GroupBox();
            this.txtClienteFornitore = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDenominazioneConto = new System.Windows.Forms.TextBox();
            this.txtCodiceConto = new System.Windows.Forms.TextBox();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbEntryKind = new System.Windows.Forms.ComboBox();
            this.DS = new entrydetailaccrual_default.vistaForm();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEsercizio = new System.Windows.Forms.TextBox();
            this.txtDataContabile = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSelezionaRateo = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtImporto = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnRateoPluriennale = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gboxClienteFornitore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gboxClienteFornitore);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtDenominazioneConto);
            this.groupBox1.Controls.Add(this.txtCodiceConto);
            this.groupBox1.Controls.Add(this.txtDescrizione);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbEntryKind);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtNumero);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtEsercizio);
            this.groupBox1.Controls.Add(this.txtDataContabile);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(12, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(451, 427);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dettaglio Scrittura corrente";
            // 
            // gboxClienteFornitore
            // 
            this.gboxClienteFornitore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxClienteFornitore.Controls.Add(this.txtClienteFornitore);
            this.gboxClienteFornitore.Location = new System.Drawing.Point(10, 165);
            this.gboxClienteFornitore.Name = "gboxClienteFornitore";
            this.gboxClienteFornitore.Size = new System.Drawing.Size(428, 48);
            this.gboxClienteFornitore.TabIndex = 39;
            this.gboxClienteFornitore.TabStop = false;
            this.gboxClienteFornitore.Tag = "";
            this.gboxClienteFornitore.Text = "Cliente/Fornitore";
            // 
            // txtClienteFornitore
            // 
            this.txtClienteFornitore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClienteFornitore.Location = new System.Drawing.Point(8, 16);
            this.txtClienteFornitore.Name = "txtClienteFornitore";
            this.txtClienteFornitore.Size = new System.Drawing.Size(412, 20);
            this.txtClienteFornitore.TabIndex = 0;
            this.txtClienteFornitore.Tag = "entrydetailview.registry";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(19, 290);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 38;
            this.label2.Text = "Conto:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDenominazioneConto
            // 
            this.txtDenominazioneConto.Location = new System.Drawing.Point(113, 219);
            this.txtDenominazioneConto.Multiline = true;
            this.txtDenominazioneConto.Name = "txtDenominazioneConto";
            this.txtDenominazioneConto.ReadOnly = true;
            this.txtDenominazioneConto.Size = new System.Drawing.Size(325, 98);
            this.txtDenominazioneConto.TabIndex = 2;
            this.txtDenominazioneConto.TabStop = false;
            this.txtDenominazioneConto.Tag = "entrydetailview.account";
            // 
            // txtCodiceConto
            // 
            this.txtCodiceConto.Location = new System.Drawing.Point(14, 320);
            this.txtCodiceConto.Name = "txtCodiceConto";
            this.txtCodiceConto.Size = new System.Drawing.Size(424, 20);
            this.txtCodiceConto.TabIndex = 1;
            this.txtCodiceConto.Tag = "entrydetailview.codeacc";
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Location = new System.Drawing.Point(13, 87);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(417, 72);
            this.txtDescrizione.TabIndex = 36;
            this.txtDescrizione.Tag = "entrydetailview.description";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(11, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 16);
            this.label7.TabIndex = 37;
            this.label7.Text = "Descrizione:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(9, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 18);
            this.label6.TabIndex = 34;
            this.label6.Text = "Tipo ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbEntryKind
            // 
            this.cmbEntryKind.DataSource = this.DS.entrykind;
            this.cmbEntryKind.DisplayMember = "description";
            this.cmbEntryKind.Location = new System.Drawing.Point(43, 46);
            this.cmbEntryKind.Name = "cmbEntryKind";
            this.cmbEntryKind.Size = new System.Drawing.Size(260, 21);
            this.cmbEntryKind.TabIndex = 33;
            this.cmbEntryKind.Tag = "entrydetailview.identrykind";
            this.cmbEntryKind.ValueMember = "identrykind";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Esercizio:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(188, 19);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(64, 20);
            this.txtNumero.TabIndex = 10;
            this.txtNumero.Tag = "entrydetailview.nentry";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(137, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Numero:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercizio
            // 
            this.txtEsercizio.Location = new System.Drawing.Point(63, 19);
            this.txtEsercizio.Name = "txtEsercizio";
            this.txtEsercizio.ReadOnly = true;
            this.txtEsercizio.Size = new System.Drawing.Size(64, 20);
            this.txtEsercizio.TabIndex = 12;
            this.txtEsercizio.TabStop = false;
            this.txtEsercizio.Tag = "entrydetailview.yentry";
            this.txtEsercizio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDataContabile
            // 
            this.txtDataContabile.Location = new System.Drawing.Point(22, 369);
            this.txtDataContabile.Name = "txtDataContabile";
            this.txtDataContabile.ReadOnly = true;
            this.txtDataContabile.Size = new System.Drawing.Size(80, 20);
            this.txtDataContabile.TabIndex = 21;
            this.txtDataContabile.TabStop = false;
            this.txtDataContabile.Tag = "entrydetailview.adate";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(19, 354);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 16);
            this.label5.TabIndex = 20;
            this.label5.Text = "Data contabile:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btnRateoPluriennale);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.btnSelezionaRateo);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Controls.Add(this.textBox5);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.comboBox2);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.textBox6);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.textBox7);
            this.groupBox3.Controls.Add(this.textBox8);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Location = new System.Drawing.Point(469, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(484, 427);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Rateo Associato (da anno precedente)";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Location = new System.Drawing.Point(11, 223);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(462, 48);
            this.groupBox2.TabIndex = 42;
            this.groupBox2.TabStop = false;
            this.groupBox2.Tag = "";
            this.groupBox2.Text = "Cliente/Fornitore";
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Location = new System.Drawing.Point(8, 16);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(446, 20);
            this.textBox3.TabIndex = 0;
            this.textBox3.Tag = "entrydetailview_linked.registry";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(16, 331);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 41;
            this.label4.Text = "Conto:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSelezionaRateo
            // 
            this.btnSelezionaRateo.Location = new System.Drawing.Point(50, 23);
            this.btnSelezionaRateo.Name = "btnSelezionaRateo";
            this.btnSelezionaRateo.Size = new System.Drawing.Size(202, 23);
            this.btnSelezionaRateo.TabIndex = 43;
            this.btnSelezionaRateo.Text = "Seleziona Rateo Normale";
            this.btnSelezionaRateo.UseVisualStyleBackColor = true;
            this.btnSelezionaRateo.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(104, 273);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(369, 74);
            this.textBox1.TabIndex = 40;
            this.textBox1.TabStop = false;
            this.textBox1.Tag = "entrydetailview_linked.account";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.txtImporto);
            this.groupBox4.Location = new System.Drawing.Point(282, 33);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(192, 42);
            this.groupBox4.TabIndex = 44;
            this.groupBox4.TabStop = false;
            this.groupBox4.Tag = "";
            this.groupBox4.Text = "Importo";
            // 
            // txtImporto
            // 
            this.txtImporto.BackColor = System.Drawing.SystemColors.Window;
            this.txtImporto.Location = new System.Drawing.Point(52, 17);
            this.txtImporto.Name = "txtImporto";
            this.txtImporto.Size = new System.Drawing.Size(128, 20);
            this.txtImporto.TabIndex = 7;
            this.txtImporto.Tag = "entrydetailaccrual.amount";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(19, 350);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(454, 20);
            this.textBox2.TabIndex = 39;
            this.textBox2.Tag = "entrydetailview_linked.codeacc";
            // 
            // textBox5
            // 
            this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox5.Location = new System.Drawing.Point(13, 170);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(458, 48);
            this.textBox5.TabIndex = 36;
            this.textBox5.Tag = "entrydetailview_linked.description";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(11, 153);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 16);
            this.label11.TabIndex = 37;
            this.label11.Text = "Descrizione:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(9, 130);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(28, 18);
            this.label12.TabIndex = 34;
            this.label12.Text = "Tipo ";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox2
            // 
            this.comboBox2.DataSource = this.DS.entrykind_linked;
            this.comboBox2.DisplayMember = "description";
            this.comboBox2.Location = new System.Drawing.Point(43, 129);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(260, 21);
            this.comboBox2.TabIndex = 33;
            this.comboBox2.Tag = "entrydetailview_linked.identrykind";
            this.comboBox2.ValueMember = "identrykind";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(7, 102);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 16);
            this.label13.TabIndex = 11;
            this.label13.Text = "Esercizio:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(188, 102);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(64, 20);
            this.textBox6.TabIndex = 10;
            this.textBox6.Tag = "entrydetailaccrual.nentrylinked";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(136, 102);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 16);
            this.label14.TabIndex = 13;
            this.label14.Text = "Numero:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(63, 102);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(64, 20);
            this.textBox7.TabIndex = 12;
            this.textBox7.TabStop = false;
            this.textBox7.Tag = "entrydetailaccrual.yentrylinked";
            this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(13, 400);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(80, 20);
            this.textBox8.TabIndex = 21;
            this.textBox8.TabStop = false;
            this.textBox8.Tag = "entrydetailview_linked.adate";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(10, 384);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(80, 16);
            this.label15.TabIndex = 20;
            this.label15.Text = "Data contabile:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(868, 437);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 46;
            this.btnAnnulla.Text = "Annulla";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(764, 437);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 45;
            this.btnOK.Tag = "mainsave";
            this.btnOK.Text = "OK";
            // 
            // btnRateoPluriennale
            // 
            this.btnRateoPluriennale.Location = new System.Drawing.Point(19, 52);
            this.btnRateoPluriennale.Name = "btnRateoPluriennale";
            this.btnRateoPluriennale.Size = new System.Drawing.Size(257, 23);
            this.btnRateoPluriennale.TabIndex = 45;
            this.btnRateoPluriennale.Text = "Seleziona Rateo Progetti Pluriennali";
            this.btnRateoPluriennale.UseVisualStyleBackColor = true;
            this.btnRateoPluriennale.Click += new System.EventHandler(this.btnRateoPluriennale_Click);
            // 
            // Frm_entrydetailaccrual_default
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnAnnulla;
            this.ClientSize = new System.Drawing.Size(961, 472);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_entrydetailaccrual_default";
            this.Text = "Frm_entrydetailaccrual_default";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gboxClienteFornitore.ResumeLayout(false);
            this.gboxClienteFornitore.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDescrizione;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        public  System.Windows.Forms.ComboBox cmbEntryKind;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEsercizio;
        private System.Windows.Forms.TextBox txtDataContabile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        public  System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtDenominazioneConto;
        private System.Windows.Forms.TextBox txtCodiceConto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox gboxClienteFornitore;
        private System.Windows.Forms.TextBox txtClienteFornitore;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button btnSelezionaRateo;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtImporto;
        public vistaForm DS;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnRateoPluriennale;
      
    }
}