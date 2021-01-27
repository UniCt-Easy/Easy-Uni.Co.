
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


namespace expense_ct_stornocompetenzaclass {
    partial class Frm_expense_ct_stornocompetenzaclass {
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
            this.btnEsegui = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtImportoDaStornare = new System.Windows.Forms.TextBox();
            this.grpBilancioNew = new System.Windows.Forms.GroupBox();
            this.txtDenominazioneBil = new System.Windows.Forms.TextBox();
            this.txtCodiceBilancioNew = new System.Windows.Forms.TextBox();
            this.btnBilancio = new System.Windows.Forms.Button();
            this.gboxUPB = new System.Windows.Forms.GroupBox();
            this.txtCodeUPBnew = new System.Windows.Forms.TextBox();
            this.txtDenominazioneUPBnew = new System.Windows.Forms.TextBox();
            this.btnUPBCode = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblImportoDisponibile = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtImportoDisponibile = new System.Windows.Forms.TextBox();
            this.txtImportoCorrente = new System.Windows.Forms.TextBox();
            this.gboxUPBOriginale = new System.Windows.Forms.GroupBox();
            this.txtCodeUPB = new System.Windows.Forms.TextBox();
            this.txtDenominazioneUPB = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.SubEntity_txtImportoMovimento = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.gboxBilAnnuale = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCodiceBilancio = new System.Windows.Forms.TextBox();
            this.txtDenominazioneBilancio = new System.Windows.Forms.TextBox();
            this.gboxMovimento = new System.Windows.Forms.GroupBox();
            this.btnSelectMov = new System.Windows.Forms.Button();
            this.txtNumeroMovimento = new System.Windows.Forms.TextBox();
            this.labNum = new System.Windows.Forms.Label();
            this.txtEsercizioMovimento = new System.Windows.Forms.TextBox();
            this.labEserc = new System.Windows.Forms.Label();
            this.DS = new expense_ct_stornocompetenzaclass.vistaForm();
            this.groupBox1.SuspendLayout();
            this.grpBilancioNew.SuspendLayout();
            this.gboxUPB.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gboxUPBOriginale.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.gboxBilAnnuale.SuspendLayout();
            this.gboxMovimento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEsegui
            // 
            this.btnEsegui.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEsegui.Location = new System.Drawing.Point(582, 467);
            this.btnEsegui.Name = "btnEsegui";
            this.btnEsegui.Size = new System.Drawing.Size(93, 24);
            this.btnEsegui.TabIndex = 103;
            this.btnEsegui.Text = "Esegui";
            this.btnEsegui.UseVisualStyleBackColor = true;
            this.btnEsegui.Click += new System.EventHandler(this.btnEsegui_Click);
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(688, 467);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 24);
            this.btnAnnulla.TabIndex = 104;
            this.btnAnnulla.Text = "Annulla";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtImportoDaStornare);
            this.groupBox1.Controls.Add(this.grpBilancioNew);
            this.groupBox1.Controls.Add(this.gboxUPB);
            this.groupBox1.Location = new System.Drawing.Point(7, 298);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(761, 163);
            this.groupBox1.TabIndex = 102;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "NUOVA IMPUTAZIONE (lasciare vuoto se non si desidera modificare la UPB o il Bilan" +
    "cio )";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 20);
            this.label2.TabIndex = 101;
            this.label2.Text = "Importo da stornare";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtImportoDaStornare
            // 
            this.txtImportoDaStornare.Location = new System.Drawing.Point(148, 137);
            this.txtImportoDaStornare.Name = "txtImportoDaStornare";
            this.txtImportoDaStornare.Size = new System.Drawing.Size(192, 20);
            this.txtImportoDaStornare.TabIndex = 15;
            this.txtImportoDaStornare.Tag = "";
            this.txtImportoDaStornare.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtImportoDaStornare.Leave += new System.EventHandler(this.txtImportoDaStornare_Leave);
            // 
            // grpBilancioNew
            // 
            this.grpBilancioNew.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBilancioNew.Controls.Add(this.txtDenominazioneBil);
            this.grpBilancioNew.Controls.Add(this.txtCodiceBilancioNew);
            this.grpBilancioNew.Controls.Add(this.btnBilancio);
            this.grpBilancioNew.Location = new System.Drawing.Point(358, 22);
            this.grpBilancioNew.Name = "grpBilancioNew";
            this.grpBilancioNew.Size = new System.Drawing.Size(400, 106);
            this.grpBilancioNew.TabIndex = 13;
            this.grpBilancioNew.TabStop = false;
            this.grpBilancioNew.Tag = "";
            this.grpBilancioNew.Text = "Bilancio";
            // 
            // txtDenominazioneBil
            // 
            this.txtDenominazioneBil.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenominazioneBil.Location = new System.Drawing.Point(128, 12);
            this.txtDenominazioneBil.Multiline = true;
            this.txtDenominazioneBil.Name = "txtDenominazioneBil";
            this.txtDenominazioneBil.ReadOnly = true;
            this.txtDenominazioneBil.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDenominazioneBil.Size = new System.Drawing.Size(264, 57);
            this.txtDenominazioneBil.TabIndex = 7;
            this.txtDenominazioneBil.TabStop = false;
            this.txtDenominazioneBil.Tag = "finview.title";
            // 
            // txtCodiceBilancioNew
            // 
            this.txtCodiceBilancioNew.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodiceBilancioNew.Location = new System.Drawing.Point(6, 78);
            this.txtCodiceBilancioNew.Name = "txtCodiceBilancioNew";
            this.txtCodiceBilancioNew.Size = new System.Drawing.Size(386, 20);
            this.txtCodiceBilancioNew.TabIndex = 14;
            this.txtCodiceBilancioNew.Tag = "finview.codefin?expenseview.codefin";
            this.txtCodiceBilancioNew.Leave += new System.EventHandler(this.txtCodiceBilancioNew_Leave);
            // 
            // btnBilancio
            // 
            this.btnBilancio.Location = new System.Drawing.Point(6, 49);
            this.btnBilancio.Name = "btnBilancio";
            this.btnBilancio.Size = new System.Drawing.Size(104, 23);
            this.btnBilancio.TabIndex = 6;
            this.btnBilancio.Tag = "";
            this.btnBilancio.Text = "Codice";
            this.btnBilancio.Click += new System.EventHandler(this.btnBilancio_Click);
            // 
            // gboxUPB
            // 
            this.gboxUPB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gboxUPB.Controls.Add(this.txtCodeUPBnew);
            this.gboxUPB.Controls.Add(this.txtDenominazioneUPBnew);
            this.gboxUPB.Controls.Add(this.btnUPBCode);
            this.gboxUPB.Location = new System.Drawing.Point(6, 22);
            this.gboxUPB.Name = "gboxUPB";
            this.gboxUPB.Size = new System.Drawing.Size(344, 105);
            this.gboxUPB.TabIndex = 11;
            this.gboxUPB.TabStop = false;
            this.gboxUPB.Tag = "AutoChoose.txtCodeUPBnew.default.(active=\'S\')";
            // 
            // txtCodeUPBnew
            // 
            this.txtCodeUPBnew.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodeUPBnew.Location = new System.Drawing.Point(8, 79);
            this.txtCodeUPBnew.Name = "txtCodeUPBnew";
            this.txtCodeUPBnew.Size = new System.Drawing.Size(327, 20);
            this.txtCodeUPBnew.TabIndex = 12;
            this.txtCodeUPBnew.Tag = "upb_new.codeupb?x";
            // 
            // txtDenominazioneUPBnew
            // 
            this.txtDenominazioneUPBnew.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenominazioneUPBnew.Location = new System.Drawing.Point(152, 12);
            this.txtDenominazioneUPBnew.Multiline = true;
            this.txtDenominazioneUPBnew.Name = "txtDenominazioneUPBnew";
            this.txtDenominazioneUPBnew.ReadOnly = true;
            this.txtDenominazioneUPBnew.Size = new System.Drawing.Size(183, 62);
            this.txtDenominazioneUPBnew.TabIndex = 4;
            this.txtDenominazioneUPBnew.TabStop = false;
            this.txtDenominazioneUPBnew.Tag = "upb_new.title";
            // 
            // btnUPBCode
            // 
            this.btnUPBCode.BackColor = System.Drawing.SystemColors.Control;
            this.btnUPBCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUPBCode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUPBCode.Location = new System.Drawing.Point(8, 51);
            this.btnUPBCode.Name = "btnUPBCode";
            this.btnUPBCode.Size = new System.Drawing.Size(112, 20);
            this.btnUPBCode.TabIndex = 2;
            this.btnUPBCode.TabStop = false;
            this.btnUPBCode.Tag = "manage.upb_new.tree";
            this.btnUPBCode.Text = "UPB";
            this.btnUPBCode.UseVisualStyleBackColor = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lblImportoDisponibile);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtImportoDisponibile);
            this.groupBox2.Controls.Add(this.txtImportoCorrente);
            this.groupBox2.Location = new System.Drawing.Point(367, 224);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(398, 64);
            this.groupBox2.TabIndex = 109;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Situazione riassuntiva importo del movimento";
            // 
            // lblImportoDisponibile
            // 
            this.lblImportoDisponibile.Location = new System.Drawing.Point(8, 40);
            this.lblImportoDisponibile.Name = "lblImportoDisponibile";
            this.lblImportoDisponibile.Size = new System.Drawing.Size(192, 20);
            this.lblImportoDisponibile.TabIndex = 0;
            this.lblImportoDisponibile.Text = "Disponibile:";
            this.lblImportoDisponibile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(8, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(200, 24);
            this.label12.TabIndex = 0;
            this.label12.Text = "Attuale (comprensivo delle variazioni):";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtImportoDisponibile
            // 
            this.txtImportoDisponibile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImportoDisponibile.Location = new System.Drawing.Point(242, 39);
            this.txtImportoDisponibile.Name = "txtImportoDisponibile";
            this.txtImportoDisponibile.ReadOnly = true;
            this.txtImportoDisponibile.Size = new System.Drawing.Size(150, 20);
            this.txtImportoDisponibile.TabIndex = 0;
            this.txtImportoDisponibile.TabStop = false;
            this.txtImportoDisponibile.Tag = "";
            this.txtImportoDisponibile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtImportoCorrente
            // 
            this.txtImportoCorrente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImportoCorrente.Location = new System.Drawing.Point(242, 15);
            this.txtImportoCorrente.Name = "txtImportoCorrente";
            this.txtImportoCorrente.ReadOnly = true;
            this.txtImportoCorrente.Size = new System.Drawing.Size(150, 20);
            this.txtImportoCorrente.TabIndex = 0;
            this.txtImportoCorrente.TabStop = false;
            this.txtImportoCorrente.Tag = "";
            this.txtImportoCorrente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gboxUPBOriginale
            // 
            this.gboxUPBOriginale.Controls.Add(this.txtCodeUPB);
            this.gboxUPBOriginale.Controls.Add(this.txtDenominazioneUPB);
            this.gboxUPBOriginale.Controls.Add(this.button1);
            this.gboxUPBOriginale.Location = new System.Drawing.Point(15, 134);
            this.gboxUPBOriginale.Name = "gboxUPBOriginale";
            this.gboxUPBOriginale.Size = new System.Drawing.Size(341, 90);
            this.gboxUPBOriginale.TabIndex = 108;
            this.gboxUPBOriginale.TabStop = false;
            this.gboxUPBOriginale.Tag = "";
            // 
            // txtCodeUPB
            // 
            this.txtCodeUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodeUPB.Location = new System.Drawing.Point(8, 65);
            this.txtCodeUPB.Name = "txtCodeUPB";
            this.txtCodeUPB.ReadOnly = true;
            this.txtCodeUPB.Size = new System.Drawing.Size(324, 20);
            this.txtCodeUPB.TabIndex = 5;
            this.txtCodeUPB.TabStop = false;
            this.txtCodeUPB.Tag = "upb.codeupb?x";
            // 
            // txtDenominazioneUPB
            // 
            this.txtDenominazioneUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenominazioneUPB.Location = new System.Drawing.Point(126, 10);
            this.txtDenominazioneUPB.Multiline = true;
            this.txtDenominazioneUPB.Name = "txtDenominazioneUPB";
            this.txtDenominazioneUPB.ReadOnly = true;
            this.txtDenominazioneUPB.Size = new System.Drawing.Size(206, 48);
            this.txtDenominazioneUPB.TabIndex = 4;
            this.txtDenominazioneUPB.TabStop = false;
            this.txtDenominazioneUPB.Tag = "upb.title";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(8, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 20);
            this.button1.TabIndex = 2;
            this.button1.TabStop = false;
            this.button1.Tag = "";
            this.button1.Text = "UPB:";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // groupBox18
            // 
            this.groupBox18.Controls.Add(this.SubEntity_txtImportoMovimento);
            this.groupBox18.Controls.Add(this.label11);
            this.groupBox18.Location = new System.Drawing.Point(15, 93);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(341, 40);
            this.groupBox18.TabIndex = 107;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "Importo";
            // 
            // SubEntity_txtImportoMovimento
            // 
            this.SubEntity_txtImportoMovimento.Location = new System.Drawing.Point(225, 12);
            this.SubEntity_txtImportoMovimento.Name = "SubEntity_txtImportoMovimento";
            this.SubEntity_txtImportoMovimento.ReadOnly = true;
            this.SubEntity_txtImportoMovimento.Size = new System.Drawing.Size(112, 20);
            this.SubEntity_txtImportoMovimento.TabIndex = 1;
            this.SubEntity_txtImportoMovimento.TabStop = false;
            this.SubEntity_txtImportoMovimento.Tag = "";
            this.SubEntity_txtImportoMovimento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(8, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 20);
            this.label11.TabIndex = 0;
            this.label11.Text = "Originale:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox17
            // 
            this.groupBox17.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox17.Controls.Add(this.txtDescrizione);
            this.groupBox17.Location = new System.Drawing.Point(368, 13);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(398, 72);
            this.groupBox17.TabIndex = 106;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "Descrizione";
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizione.Location = new System.Drawing.Point(8, 16);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.ReadOnly = true;
            this.txtDescrizione.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescrizione.Size = new System.Drawing.Size(380, 48);
            this.txtDescrizione.TabIndex = 1;
            this.txtDescrizione.TabStop = false;
            this.txtDescrizione.Tag = "";
            // 
            // gboxBilAnnuale
            // 
            this.gboxBilAnnuale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxBilAnnuale.Controls.Add(this.label9);
            this.gboxBilAnnuale.Controls.Add(this.txtCodiceBilancio);
            this.gboxBilAnnuale.Controls.Add(this.txtDenominazioneBilancio);
            this.gboxBilAnnuale.Location = new System.Drawing.Point(367, 133);
            this.gboxBilAnnuale.Name = "gboxBilAnnuale";
            this.gboxBilAnnuale.Size = new System.Drawing.Size(400, 91);
            this.gboxBilAnnuale.TabIndex = 105;
            this.gboxBilAnnuale.TabStop = false;
            this.gboxBilAnnuale.Tag = "";
            // 
            // label9
            // 
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.ImageIndex = 0;
            this.label9.Location = new System.Drawing.Point(6, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 18);
            this.label9.TabIndex = 3;
            this.label9.Text = "Bilancio";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtCodiceBilancio
            // 
            this.txtCodiceBilancio.Location = new System.Drawing.Point(3, 65);
            this.txtCodiceBilancio.Name = "txtCodiceBilancio";
            this.txtCodiceBilancio.ReadOnly = true;
            this.txtCodiceBilancio.Size = new System.Drawing.Size(385, 20);
            this.txtCodiceBilancio.TabIndex = 1;
            this.txtCodiceBilancio.TabStop = false;
            this.txtCodiceBilancio.Tag = "";
            // 
            // txtDenominazioneBilancio
            // 
            this.txtDenominazioneBilancio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenominazioneBilancio.Location = new System.Drawing.Point(107, 8);
            this.txtDenominazioneBilancio.Multiline = true;
            this.txtDenominazioneBilancio.Name = "txtDenominazioneBilancio";
            this.txtDenominazioneBilancio.ReadOnly = true;
            this.txtDenominazioneBilancio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDenominazioneBilancio.Size = new System.Drawing.Size(285, 51);
            this.txtDenominazioneBilancio.TabIndex = 2;
            this.txtDenominazioneBilancio.TabStop = false;
            this.txtDenominazioneBilancio.Tag = "";
            // 
            // gboxMovimento
            // 
            this.gboxMovimento.Controls.Add(this.btnSelectMov);
            this.gboxMovimento.Controls.Add(this.txtNumeroMovimento);
            this.gboxMovimento.Controls.Add(this.labNum);
            this.gboxMovimento.Controls.Add(this.txtEsercizioMovimento);
            this.gboxMovimento.Controls.Add(this.labEserc);
            this.gboxMovimento.Location = new System.Drawing.Point(12, 11);
            this.gboxMovimento.Name = "gboxMovimento";
            this.gboxMovimento.Size = new System.Drawing.Size(344, 80);
            this.gboxMovimento.TabIndex = 101;
            this.gboxMovimento.TabStop = false;
            this.gboxMovimento.Tag = "";
            this.gboxMovimento.Text = "Movimento";
            // 
            // btnSelectMov
            // 
            this.btnSelectMov.Location = new System.Drawing.Point(15, 17);
            this.btnSelectMov.Name = "btnSelectMov";
            this.btnSelectMov.Size = new System.Drawing.Size(75, 23);
            this.btnSelectMov.TabIndex = 4;
            this.btnSelectMov.TabStop = false;
            this.btnSelectMov.Tag = "";
            this.btnSelectMov.Text = "Seleziona";
            this.btnSelectMov.Click += new System.EventHandler(this.btnSelectMov_Click);
            // 
            // txtNumeroMovimento
            // 
            this.txtNumeroMovimento.Location = new System.Drawing.Point(134, 49);
            this.txtNumeroMovimento.Name = "txtNumeroMovimento";
            this.txtNumeroMovimento.Size = new System.Drawing.Size(48, 20);
            this.txtNumeroMovimento.TabIndex = 3;
            this.txtNumeroMovimento.Tag = "";
            this.txtNumeroMovimento.Leave += new System.EventHandler(this.txtNumeroMovimento_Leave);
            // 
            // labNum
            // 
            this.labNum.Location = new System.Drawing.Point(102, 49);
            this.labNum.Name = "labNum";
            this.labNum.Size = new System.Drawing.Size(32, 20);
            this.labNum.TabIndex = 0;
            this.labNum.Text = "Num.";
            this.labNum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercizioMovimento
            // 
            this.txtEsercizioMovimento.Location = new System.Drawing.Point(52, 49);
            this.txtEsercizioMovimento.Name = "txtEsercizioMovimento";
            this.txtEsercizioMovimento.Size = new System.Drawing.Size(39, 20);
            this.txtEsercizioMovimento.TabIndex = 2;
            this.txtEsercizioMovimento.Tag = "";
            // 
            // labEserc
            // 
            this.labEserc.Location = new System.Drawing.Point(12, 49);
            this.labEserc.Name = "labEserc";
            this.labEserc.Size = new System.Drawing.Size(40, 20);
            this.labEserc.TabIndex = 0;
            this.labEserc.Text = "Eserc.";
            this.labEserc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // Frm_expense_ct_stornocompetenzaclass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 503);
            this.Controls.Add(this.btnEsegui);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gboxUPBOriginale);
            this.Controls.Add(this.groupBox18);
            this.Controls.Add(this.groupBox17);
            this.Controls.Add(this.gboxBilAnnuale);
            this.Controls.Add(this.gboxMovimento);
            this.Name = "Frm_expense_ct_stornocompetenzaclass";
            this.Text = "Frm_expense_ct_stornocompetenzaclass";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpBilancioNew.ResumeLayout(false);
            this.grpBilancioNew.PerformLayout();
            this.gboxUPB.ResumeLayout(false);
            this.gboxUPB.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gboxUPBOriginale.ResumeLayout(false);
            this.gboxUPBOriginale.PerformLayout();
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.gboxBilAnnuale.ResumeLayout(false);
            this.gboxBilAnnuale.PerformLayout();
            this.gboxMovimento.ResumeLayout(false);
            this.gboxMovimento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEsegui;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtImportoDaStornare;
        private System.Windows.Forms.GroupBox grpBilancioNew;
        private System.Windows.Forms.TextBox txtDenominazioneBil;
        private System.Windows.Forms.TextBox txtCodiceBilancioNew;
        private System.Windows.Forms.Button btnBilancio;
        private System.Windows.Forms.GroupBox gboxUPB;
        public System.Windows.Forms.TextBox txtCodeUPBnew;
        private System.Windows.Forms.TextBox txtDenominazioneUPBnew;
        private System.Windows.Forms.Button btnUPBCode;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblImportoDisponibile;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtImportoDisponibile;
        private System.Windows.Forms.TextBox txtImportoCorrente;
        private System.Windows.Forms.GroupBox gboxUPBOriginale;
        public System.Windows.Forms.TextBox txtCodeUPB;
        private System.Windows.Forms.TextBox txtDenominazioneUPB;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox18;
        private System.Windows.Forms.TextBox SubEntity_txtImportoMovimento;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.TextBox txtDescrizione;
        private System.Windows.Forms.GroupBox gboxBilAnnuale;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCodiceBilancio;
        private System.Windows.Forms.TextBox txtDenominazioneBilancio;
        private System.Windows.Forms.GroupBox gboxMovimento;
        private System.Windows.Forms.Button btnSelectMov;
        private System.Windows.Forms.TextBox txtNumeroMovimento;
        private System.Windows.Forms.Label labNum;
        private System.Windows.Forms.TextBox txtEsercizioMovimento;
        private System.Windows.Forms.Label labEserc;
        public vistaForm DS;
    }
}
