
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


namespace flussoincassidetail_bollettino {
	partial class Frm_flussoincassidetail_bollettino {
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
			this.DS = new flussoincassidetail_bollettino.vistaForm();
			this.label13 = new System.Windows.Forms.Label();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.gboxDettagli = new System.Windows.Forms.GroupBox();
			this.gBoxRicevutaTelematica = new System.Windows.Forms.GroupBox();
			this.label10 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtPiva = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtCodiceFiscale = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtUniqueFCode = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtIUV = new System.Windows.Forms.TextBox();
			this.txtImporto = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.gboxBill = new System.Windows.Forms.GroupBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtBill = new System.Windows.Forms.TextBox();
			this.txtImportoTotale = new System.Windows.Forms.TextBox();
			this.labelImporto = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtEsercizio = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtDataIncasso = new System.Windows.Forms.TextBox();
			this.chbElaborato = new System.Windows.Forms.CheckBox();
			this.txtTRN = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.chbAttivo = new System.Windows.Forms.CheckBox();
			this.txtCausale = new System.Windows.Forms.TextBox();
			this.lblCausale = new System.Windows.Forms.Label();
			this.txtCodice = new System.Windows.Forms.TextBox();
			this.lblCodiceFlusso = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.gboxDettagli.SuspendLayout();
			this.gBoxRicevutaTelematica.SuspendLayout();
			this.gboxBill.SuspendLayout();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			// 
			// label13
			// 
			this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label13.Location = new System.Drawing.Point(106, 18);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(70, 16);
			this.label13.TabIndex = 172;
			this.label13.Text = "ID dettaglio";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBox6
			// 
			this.textBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox6.Location = new System.Drawing.Point(9, 37);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(87, 20);
			this.textBox6.TabIndex = 171;
			this.textBox6.Tag = "flussoincassidetail.idflusso";
			this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label14
			// 
			this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label14.Location = new System.Drawing.Point(9, 17);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(56, 16);
			this.label14.TabIndex = 169;
			this.label14.Text = "ID flusso";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBox7
			// 
			this.textBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox7.Location = new System.Drawing.Point(103, 37);
			this.textBox7.Name = "textBox7";
			this.textBox7.Size = new System.Drawing.Size(121, 20);
			this.textBox7.TabIndex = 170;
			this.textBox7.Tag = "flussoincassidetail.iddetail";
			this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// gboxDettagli
			// 
			this.gboxDettagli.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxDettagli.Controls.Add(this.gBoxRicevutaTelematica);
			this.gboxDettagli.Controls.Add(this.label4);
			this.gboxDettagli.Controls.Add(this.txtPiva);
			this.gboxDettagli.Controls.Add(this.label3);
			this.gboxDettagli.Controls.Add(this.txtCodiceFiscale);
			this.gboxDettagli.Controls.Add(this.label5);
			this.gboxDettagli.Controls.Add(this.txtUniqueFCode);
			this.gboxDettagli.Controls.Add(this.label6);
			this.gboxDettagli.Controls.Add(this.txtIUV);
			this.gboxDettagli.Controls.Add(this.txtImporto);
			this.gboxDettagli.Controls.Add(this.label8);
			this.gboxDettagli.Location = new System.Drawing.Point(12, 318);
			this.gboxDettagli.Name = "gboxDettagli";
			this.gboxDettagli.Size = new System.Drawing.Size(712, 194);
			this.gboxDettagli.TabIndex = 168;
			this.gboxDettagli.TabStop = false;
			this.gboxDettagli.Text = "Dettagli";
			// 
			// gBoxRicevutaTelematica
			// 
			this.gBoxRicevutaTelematica.Controls.Add(this.label10);
			this.gBoxRicevutaTelematica.Controls.Add(this.textBox4);
			this.gBoxRicevutaTelematica.Controls.Add(this.label11);
			this.gBoxRicevutaTelematica.Controls.Add(this.textBox2);
			this.gBoxRicevutaTelematica.Controls.Add(this.label12);
			this.gBoxRicevutaTelematica.Controls.Add(this.textBox1);
			this.gBoxRicevutaTelematica.Location = new System.Drawing.Point(463, 13);
			this.gBoxRicevutaTelematica.Name = "gBoxRicevutaTelematica";
			this.gBoxRicevutaTelematica.Size = new System.Drawing.Size(203, 167);
			this.gBoxRicevutaTelematica.TabIndex = 154;
			this.gBoxRicevutaTelematica.TabStop = false;
			this.gBoxRicevutaTelematica.Text = "Ricevuta Telematica";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(6, 101);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(111, 13);
			this.label10.TabIndex = 149;
			this.label10.Text = "Data esito pagamento";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(3, 120);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(194, 20);
			this.textBox4.TabIndex = 148;
			this.textBox4.Tag = "flussoincassidetail.dataesitopagamento";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(6, 63);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(127, 13);
			this.label11.TabIndex = 147;
			this.label11.Text = "Identificativo Riscossione";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(5, 79);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(192, 20);
			this.textBox2.TabIndex = 146;
			this.textBox2.Tag = "flussoincassidetail.identificativounivocoriscossione";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(10, 21);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(64, 13);
			this.label12.TabIndex = 145;
			this.label12.Text = "Codice PSP";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(5, 39);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(192, 20);
			this.textBox1.TabIndex = 144;
			this.textBox1.Tag = "flussoincassidetail.codicepsp";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(236, 79);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(182, 16);
			this.label4.TabIndex = 153;
			this.label4.Text = "Partita iva";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtPiva
			// 
			this.txtPiva.Location = new System.Drawing.Point(236, 98);
			this.txtPiva.Name = "txtPiva";
			this.txtPiva.Size = new System.Drawing.Size(207, 20);
			this.txtPiva.TabIndex = 152;
			this.txtPiva.Tag = "flussoincassidetail.p_iva";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(16, 79);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(182, 16);
			this.label3.TabIndex = 151;
			this.label3.Text = "Codice Fiscale";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtCodiceFiscale
			// 
			this.txtCodiceFiscale.Location = new System.Drawing.Point(16, 98);
			this.txtCodiceFiscale.Name = "txtCodiceFiscale";
			this.txtCodiceFiscale.Size = new System.Drawing.Size(207, 20);
			this.txtCodiceFiscale.TabIndex = 150;
			this.txtCodiceFiscale.Tag = "flussoincassidetail.cf";
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(233, 28);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(182, 16);
			this.label5.TabIndex = 149;
			this.label5.Text = "Codice Bollettino Univoco";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtUniqueFCode
			// 
			this.txtUniqueFCode.Location = new System.Drawing.Point(233, 47);
			this.txtUniqueFCode.Name = "txtUniqueFCode";
			this.txtUniqueFCode.Size = new System.Drawing.Size(207, 20);
			this.txtUniqueFCode.TabIndex = 146;
			this.txtUniqueFCode.Tag = "flussoincassidetail.iduniqueformcode";
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(13, 28);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(32, 16);
			this.label6.TabIndex = 148;
			this.label6.Text = "IUV";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtIUV
			// 
			this.txtIUV.Location = new System.Drawing.Point(13, 47);
			this.txtIUV.Name = "txtIUV";
			this.txtIUV.Size = new System.Drawing.Size(207, 20);
			this.txtIUV.TabIndex = 144;
			this.txtIUV.Tag = "flussoincassidetail.iuv";
			// 
			// txtImporto
			// 
			this.txtImporto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtImporto.Location = new System.Drawing.Point(13, 144);
			this.txtImporto.Name = "txtImporto";
			this.txtImporto.Size = new System.Drawing.Size(87, 20);
			this.txtImporto.TabIndex = 145;
			this.txtImporto.Tag = "flussoincassidetail.importo";
			this.txtImporto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(13, 124);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(87, 16);
			this.label8.TabIndex = 147;
			this.label8.Text = "Importo";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// gboxBill
			// 
			this.gboxBill.Controls.Add(this.label9);
			this.gboxBill.Controls.Add(this.txtBill);
			this.gboxBill.Location = new System.Drawing.Point(12, 257);
			this.gboxBill.Name = "gboxBill";
			this.gboxBill.Size = new System.Drawing.Size(360, 55);
			this.gboxBill.TabIndex = 167;
			this.gboxBill.TabStop = false;
			this.gboxBill.Tag = "";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(31, 15);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(56, 24);
			this.label9.TabIndex = 140;
			this.label9.Text = "N° bolletta";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtBill
			// 
			this.txtBill.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtBill.Location = new System.Drawing.Point(100, 20);
			this.txtBill.Name = "txtBill";
			this.txtBill.Size = new System.Drawing.Size(242, 20);
			this.txtBill.TabIndex = 0;
			this.txtBill.Tag = "flussoincassi.nbill?flussoincassidetailview.nbill";
			// 
			// txtImportoTotale
			// 
			this.txtImportoTotale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtImportoTotale.Location = new System.Drawing.Point(281, 218);
			this.txtImportoTotale.Name = "txtImportoTotale";
			this.txtImportoTotale.Size = new System.Drawing.Size(88, 20);
			this.txtImportoTotale.TabIndex = 166;
			this.txtImportoTotale.Tag = "flussoincassi.importo?flussoincassidetailview.importotale";
			this.txtImportoTotale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// labelImporto
			// 
			this.labelImporto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelImporto.Location = new System.Drawing.Point(279, 200);
			this.labelImporto.Name = "labelImporto";
			this.labelImporto.Size = new System.Drawing.Size(87, 16);
			this.labelImporto.TabIndex = 165;
			this.labelImporto.Text = "Importo Totale";
			this.labelImporto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(106, 81);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(70, 16);
			this.label2.TabIndex = 164;
			this.label2.Text = "Data Incasso";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtEsercizio
			// 
			this.txtEsercizio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtEsercizio.Location = new System.Drawing.Point(9, 101);
			this.txtEsercizio.Name = "txtEsercizio";
			this.txtEsercizio.Size = new System.Drawing.Size(87, 20);
			this.txtEsercizio.TabIndex = 163;
			this.txtEsercizio.Tag = "flussoincassi.ayear?flussoincassidetailview.ayear";
			this.txtEsercizio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(9, 81);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(56, 16);
			this.label7.TabIndex = 161;
			this.label7.Text = "Esercizio";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtDataIncasso
			// 
			this.txtDataIncasso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtDataIncasso.Location = new System.Drawing.Point(103, 101);
			this.txtDataIncasso.Name = "txtDataIncasso";
			this.txtDataIncasso.Size = new System.Drawing.Size(121, 20);
			this.txtDataIncasso.TabIndex = 162;
			this.txtDataIncasso.Tag = "flussoincassi.dataincasso?flussoincassidetailview.dataincasso";
			this.txtDataIncasso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// chbElaborato
			// 
			this.chbElaborato.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chbElaborato.Location = new System.Drawing.Point(609, 217);
			this.chbElaborato.Name = "chbElaborato";
			this.chbElaborato.Size = new System.Drawing.Size(88, 25);
			this.chbElaborato.TabIndex = 160;
			this.chbElaborato.Tag = "flussoincassi.elaborato:S:N?flussoincassidetailview.elaborato:S:N";
			this.chbElaborato.Text = "Elaborato";
			// 
			// txtTRN
			// 
			this.txtTRN.Location = new System.Drawing.Point(9, 219);
			this.txtTRN.Name = "txtTRN";
			this.txtTRN.Size = new System.Drawing.Size(267, 20);
			this.txtTRN.TabIndex = 158;
			this.txtTRN.Tag = "flussoincassi.trn?flussoincassidetailview.trn";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(9, 195);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 24);
			this.label1.TabIndex = 159;
			this.label1.Text = "TRN";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// chbAttivo
			// 
			this.chbAttivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chbAttivo.Location = new System.Drawing.Point(538, 217);
			this.chbAttivo.Name = "chbAttivo";
			this.chbAttivo.Size = new System.Drawing.Size(66, 25);
			this.chbAttivo.TabIndex = 157;
			this.chbAttivo.Tag = "flussoincassi.active:S:N?flussoincassidetailview.active:S:N";
			this.chbAttivo.Text = "Attivo";
			// 
			// txtCausale
			// 
			this.txtCausale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCausale.Location = new System.Drawing.Point(9, 150);
			this.txtCausale.Multiline = true;
			this.txtCausale.Name = "txtCausale";
			this.txtCausale.Size = new System.Drawing.Size(697, 42);
			this.txtCausale.TabIndex = 154;
			this.txtCausale.Tag = "flussoincassi.causale?flussoincassidetailview.causale";
			// 
			// lblCausale
			// 
			this.lblCausale.Location = new System.Drawing.Point(8, 126);
			this.lblCausale.Name = "lblCausale";
			this.lblCausale.Size = new System.Drawing.Size(88, 24);
			this.lblCausale.TabIndex = 156;
			this.lblCausale.Text = "Causale";
			this.lblCausale.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtCodice
			// 
			this.txtCodice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCodice.Location = new System.Drawing.Point(232, 101);
			this.txtCodice.Name = "txtCodice";
			this.txtCodice.Size = new System.Drawing.Size(474, 20);
			this.txtCodice.TabIndex = 153;
			this.txtCodice.Tag = "flussoincassi.codiceflusso?flussoincassidetailview.codiceflusso";
			// 
			// lblCodiceFlusso
			// 
			this.lblCodiceFlusso.Location = new System.Drawing.Point(232, 77);
			this.lblCodiceFlusso.Name = "lblCodiceFlusso";
			this.lblCodiceFlusso.Size = new System.Drawing.Size(160, 24);
			this.lblCodiceFlusso.TabIndex = 155;
			this.lblCodiceFlusso.Text = "Codice Flusso";
			this.lblCodiceFlusso.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// Frm_flussoincassidetail_bollettino
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(732, 529);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.textBox6);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.textBox7);
			this.Controls.Add(this.gboxDettagli);
			this.Controls.Add(this.gboxBill);
			this.Controls.Add(this.txtImportoTotale);
			this.Controls.Add(this.labelImporto);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtEsercizio);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.txtDataIncasso);
			this.Controls.Add(this.chbElaborato);
			this.Controls.Add(this.txtTRN);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.chbAttivo);
			this.Controls.Add(this.txtCausale);
			this.Controls.Add(this.lblCausale);
			this.Controls.Add(this.txtCodice);
			this.Controls.Add(this.lblCodiceFlusso);
			this.Name = "Frm_flussoincassidetail_bollettino";
			this.Text = "Frm_flussoincassidetail_bollettino";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.gboxDettagli.ResumeLayout(false);
			this.gboxDettagli.PerformLayout();
			this.gBoxRicevutaTelematica.ResumeLayout(false);
			this.gBoxRicevutaTelematica.PerformLayout();
			this.gboxBill.ResumeLayout(false);
			this.gboxBill.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public vistaForm DS;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.GroupBox gboxDettagli;
		private System.Windows.Forms.GroupBox gBoxRicevutaTelematica;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtPiva;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtCodiceFiscale;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtUniqueFCode;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtIUV;
		private System.Windows.Forms.TextBox txtImporto;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.GroupBox gboxBill;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtBill;
		private System.Windows.Forms.TextBox txtImportoTotale;
		private System.Windows.Forms.Label labelImporto;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtEsercizio;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtDataIncasso;
		private System.Windows.Forms.CheckBox chbElaborato;
		private System.Windows.Forms.TextBox txtTRN;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox chbAttivo;
		private System.Windows.Forms.TextBox txtCausale;
		private System.Windows.Forms.Label lblCausale;
		private System.Windows.Forms.TextBox txtCodice;
		private System.Windows.Forms.Label lblCodiceFlusso;
	}
}
