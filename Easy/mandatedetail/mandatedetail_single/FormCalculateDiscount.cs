
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


using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using funzioni_configurazione;

namespace mandatedetail_single
{
	/// <summary>
	/// Summary description for FormCalculateDiscount.
	/// </summary>
	public class FormCalculateDiscount : MetaDataForm
	{
		private Label ScontoPercentuale;
		private TextBox txtScontoPercentuale;
		private Label ImportoFinale;
		private TextBox txtImportoFinale;
		private Label ScontoApplicato;
		private Label ImportoTotale;
		private TextBox txtScontoApplicato;
		private TextBox txtImportoTot;
		private Button btnCancel;
		private Button btnOk;		
		private GroupBox grpValoreValuta;
		private Label Quantità;
		private TextBox txtQuantita;
		private Label IVA;
		private TextBox txtIvaEUR;
		private Label Imponibile;
		private TextBox txtImponibileEUR;
		private Label ImportoUnitario;
		private TextBox txtImponibile;
		private Label ImportoIva;
		private TextBox txtImportoIva;
		private decimal taxRate;
		public decimal sconto;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormCalculateDiscount(decimal imponibileTot, double percSconto,  decimal imponibile, int quantita, 
										decimal ivaEUR, decimal imponibileEUR, double aliquota)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			txtImportoTot.Text = imponibileTot.ToString("c");
			txtScontoPercentuale.Text = percSconto.ToString("p");
			txtImponibile.Text = imponibile.ToString("c");
			txtQuantita.Text = quantita.ToString("c");
			txtIvaEUR.Text = ivaEUR.ToString("c");
			txtImponibileEUR.Text = imponibileEUR.ToString("c");
			sconto = CfgFn.GetNoNullDecimal(percSconto);
			//prendo il valore dell'aliquota dal form chiamante
			taxRate = CfgFn.GetNoNullDecimal(aliquota);			

			//prendo iva e imponibile dal form chiamante e calcolo l'importo totale inclusa l'iva
			decimal iva = CfgFn.GetNoNullDecimal(txtIvaEUR.Text);
			decimal prezzoPieno = CfgFn.GetNoNullDecimal(txtImponibileEUR.Text);
			decimal importoiva = prezzoPieno + iva;			
			txtImportoIva.Text = HelpForm.StringValue(importoiva, "x.y.fixed.2...1");

			if (txtScontoPercentuale.Text != "") {
				calcolaScontoApplicato();
			}
					
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if(disposing && (components != null))
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
            this.txtImportoTot = new System.Windows.Forms.TextBox();
            this.txtScontoApplicato = new System.Windows.Forms.TextBox();
            this.ImportoTotale = new System.Windows.Forms.Label();
            this.ScontoApplicato = new System.Windows.Forms.Label();
            this.txtImportoFinale = new System.Windows.Forms.TextBox();
            this.ImportoFinale = new System.Windows.Forms.Label();
            this.txtScontoPercentuale = new System.Windows.Forms.TextBox();
            this.ScontoPercentuale = new System.Windows.Forms.Label();
            this.grpValoreValuta = new System.Windows.Forms.GroupBox();
            this.ImportoIva = new System.Windows.Forms.Label();
            this.txtImportoIva = new System.Windows.Forms.TextBox();
            this.ImportoUnitario = new System.Windows.Forms.Label();
            this.txtImponibile = new System.Windows.Forms.TextBox();
            this.Imponibile = new System.Windows.Forms.Label();
            this.txtImponibileEUR = new System.Windows.Forms.TextBox();
            this.IVA = new System.Windows.Forms.Label();
            this.txtIvaEUR = new System.Windows.Forms.TextBox();
            this.Quantità = new System.Windows.Forms.Label();
            this.txtQuantita = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.grpValoreValuta.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtImportoTot
            // 
            this.txtImportoTot.Location = new System.Drawing.Point(268, 153);
            this.txtImportoTot.Name = "txtImportoTot";
            this.txtImportoTot.ReadOnly = true;
            this.txtImportoTot.Size = new System.Drawing.Size(76, 20);
            this.txtImportoTot.TabIndex = 0;
            // 
            // txtScontoApplicato
            // 
            this.txtScontoApplicato.Location = new System.Drawing.Point(136, 218);
            this.txtScontoApplicato.Name = "txtScontoApplicato";
            this.txtScontoApplicato.Size = new System.Drawing.Size(76, 20);
            this.txtScontoApplicato.TabIndex = 1;
            this.txtScontoApplicato.Leave += new System.EventHandler(this.txtScontoApplicato_Leave);
            // 
            // ImportoTotale
            // 
            this.ImportoTotale.AutoSize = true;
            this.ImportoTotale.Location = new System.Drawing.Point(266, 136);
            this.ImportoTotale.Name = "ImportoTotale";
            this.ImportoTotale.Size = new System.Drawing.Size(84, 13);
            this.ImportoTotale.TabIndex = 2;
            this.ImportoTotale.Text = "Importo Totale €";
            // 
            // ScontoApplicato
            // 
            this.ScontoApplicato.AutoSize = true;
            this.ScontoApplicato.Location = new System.Drawing.Point(134, 202);
            this.ScontoApplicato.Name = "ScontoApplicato";
            this.ScontoApplicato.Size = new System.Drawing.Size(61, 13);
            this.ScontoApplicato.TabIndex = 3;
            this.ScontoApplicato.Text = "Sconto in €";
            // 
            // txtImportoFinale
            // 
            this.txtImportoFinale.Location = new System.Drawing.Point(268, 218);
            this.txtImportoFinale.Name = "txtImportoFinale";
            this.txtImportoFinale.ReadOnly = true;
            this.txtImportoFinale.Size = new System.Drawing.Size(76, 20);
            this.txtImportoFinale.TabIndex = 4;
            this.txtImportoFinale.TabStop = false;
            // 
            // ImportoFinale
            // 
            this.ImportoFinale.AutoSize = true;
            this.ImportoFinale.Location = new System.Drawing.Point(266, 202);
            this.ImportoFinale.Name = "ImportoFinale";
            this.ImportoFinale.Size = new System.Drawing.Size(82, 13);
            this.ImportoFinale.TabIndex = 5;
            this.ImportoFinale.Text = "Importo Finale €";
            // 
            // txtScontoPercentuale
            // 
            this.txtScontoPercentuale.Location = new System.Drawing.Point(136, 153);
            this.txtScontoPercentuale.Name = "txtScontoPercentuale";
            this.txtScontoPercentuale.ReadOnly = true;
            this.txtScontoPercentuale.Size = new System.Drawing.Size(76, 20);
            this.txtScontoPercentuale.TabIndex = 7;
            // 
            // ScontoPercentuale
            // 
            this.ScontoPercentuale.AutoSize = true;
            this.ScontoPercentuale.Location = new System.Drawing.Point(134, 137);
            this.ScontoPercentuale.Name = "ScontoPercentuale";
            this.ScontoPercentuale.Size = new System.Drawing.Size(63, 13);
            this.ScontoPercentuale.TabIndex = 8;
            this.ScontoPercentuale.Text = "Sconto in %";
            // 
            // grpValoreValuta
            // 
            this.grpValoreValuta.BackColor = System.Drawing.Color.Transparent;
            this.grpValoreValuta.Controls.Add(this.ImportoIva);
            this.grpValoreValuta.Controls.Add(this.txtImportoIva);
            this.grpValoreValuta.Controls.Add(this.ImportoUnitario);
            this.grpValoreValuta.Controls.Add(this.txtImponibile);
            this.grpValoreValuta.Controls.Add(this.Imponibile);
            this.grpValoreValuta.Controls.Add(this.txtImponibileEUR);
            this.grpValoreValuta.Controls.Add(this.IVA);
            this.grpValoreValuta.Controls.Add(this.txtIvaEUR);
            this.grpValoreValuta.Controls.Add(this.Quantità);
            this.grpValoreValuta.Controls.Add(this.txtQuantita);
            this.grpValoreValuta.Controls.Add(this.ScontoPercentuale);
            this.grpValoreValuta.Controls.Add(this.txtImportoTot);
            this.grpValoreValuta.Controls.Add(this.txtScontoPercentuale);
            this.grpValoreValuta.Controls.Add(this.txtScontoApplicato);
            this.grpValoreValuta.Controls.Add(this.ImportoTotale);
            this.grpValoreValuta.Controls.Add(this.ImportoFinale);
            this.grpValoreValuta.Controls.Add(this.ScontoApplicato);
            this.grpValoreValuta.Controls.Add(this.txtImportoFinale);
            this.grpValoreValuta.Location = new System.Drawing.Point(9, 18);
            this.grpValoreValuta.Name = "grpValoreValuta";
            this.grpValoreValuta.Size = new System.Drawing.Size(380, 254);
            this.grpValoreValuta.TabIndex = 18;
            this.grpValoreValuta.TabStop = false;
            this.grpValoreValuta.Text = "Valore in valuta (Euro)";
            // 
            // ImportoIva
            // 
            this.ImportoIva.AutoSize = true;
            this.ImportoIva.Location = new System.Drawing.Point(266, 74);
            this.ImportoIva.Name = "ImportoIva";
            this.ImportoIva.Size = new System.Drawing.Size(92, 13);
            this.ImportoIva.TabIndex = 20;
            this.ImportoIva.Text = "Importo con IVA €";
            // 
            // txtImportoIva
            // 
            this.txtImportoIva.Location = new System.Drawing.Point(268, 90);
            this.txtImportoIva.Name = "txtImportoIva";
            this.txtImportoIva.ReadOnly = true;
            this.txtImportoIva.Size = new System.Drawing.Size(76, 20);
            this.txtImportoIva.TabIndex = 19;
            // 
            // ImportoUnitario
            // 
            this.ImportoUnitario.AutoSize = true;
            this.ImportoUnitario.Location = new System.Drawing.Point(20, 137);
            this.ImportoUnitario.Name = "ImportoUnitario";
            this.ImportoUnitario.Size = new System.Drawing.Size(90, 13);
            this.ImportoUnitario.TabIndex = 18;
            this.ImportoUnitario.Text = "Importo Unitario €";
            // 
            // txtImponibile
            // 
            this.txtImponibile.Location = new System.Drawing.Point(22, 154);
            this.txtImponibile.Name = "txtImponibile";
            this.txtImponibile.ReadOnly = true;
            this.txtImponibile.Size = new System.Drawing.Size(76, 20);
            this.txtImponibile.TabIndex = 17;
            // 
            // Imponibile
            // 
            this.Imponibile.AutoSize = true;
            this.Imponibile.Location = new System.Drawing.Point(20, 74);
            this.Imponibile.Name = "Imponibile";
            this.Imponibile.Size = new System.Drawing.Size(63, 13);
            this.Imponibile.TabIndex = 16;
            this.Imponibile.Text = "Imponibile €";
            // 
            // txtImponibileEUR
            // 
            this.txtImponibileEUR.Location = new System.Drawing.Point(22, 90);
            this.txtImponibileEUR.Name = "txtImponibileEUR";
            this.txtImponibileEUR.ReadOnly = true;
            this.txtImponibileEUR.Size = new System.Drawing.Size(76, 20);
            this.txtImponibileEUR.TabIndex = 15;
            // 
            // IVA
            // 
            this.IVA.AutoSize = true;
            this.IVA.Location = new System.Drawing.Point(134, 74);
            this.IVA.Name = "IVA";
            this.IVA.Size = new System.Drawing.Size(33, 13);
            this.IVA.TabIndex = 14;
            this.IVA.Text = "IVA €";
            // 
            // txtIvaEUR
            // 
            this.txtIvaEUR.Location = new System.Drawing.Point(136, 90);
            this.txtIvaEUR.Name = "txtIvaEUR";
            this.txtIvaEUR.ReadOnly = true;
            this.txtIvaEUR.Size = new System.Drawing.Size(76, 20);
            this.txtIvaEUR.TabIndex = 13;
            // 
            // Quantità
            // 
            this.Quantità.AutoSize = true;
            this.Quantità.Location = new System.Drawing.Point(20, 23);
            this.Quantità.Name = "Quantità";
            this.Quantità.Size = new System.Drawing.Size(47, 13);
            this.Quantità.TabIndex = 12;
            this.Quantità.Text = "Quantità";
            // 
            // txtQuantita
            // 
            this.txtQuantita.Location = new System.Drawing.Point(22, 39);
            this.txtQuantita.Name = "txtQuantita";
            this.txtQuantita.ReadOnly = true;
            this.txtQuantita.Size = new System.Drawing.Size(76, 20);
            this.txtQuantita.TabIndex = 11;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(291, 321);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(76, 24);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Annulla";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(173, 321);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(84, 24);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // FormCalculateDiscount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 361);
            this.Controls.Add(this.grpValoreValuta);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Name = "FormCalculateDiscount";
            this.Text = "Calcolo Sconto Percentuale";
            this.grpValoreValuta.ResumeLayout(false);
            this.grpValoreValuta.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion
		
		//calcola lo sconto applicato in €, sapendo già la percentuale di sconto applicata
		public void calcolaScontoApplicato() {
			decimal prezzoPieno = CfgFn.GetNoNullDecimal(txtImponibile.Text);	
			decimal iva = CfgFn.GetNoNullDecimal(txtIvaEUR.Text);

			decimal scontoApplicato = (prezzoPieno * sconto);
			decimal importoiva = prezzoPieno + iva;

			txtScontoApplicato.Text = HelpForm.StringValue(scontoApplicato, "x.y.fixed.2...1");
			txtImportoIva.Text = HelpForm.StringValue(importoiva, "x.y.fixed.2...1");
		}

		private void btnCalcoloScontoPercentuale_Click(object sender, EventArgs e)
		{

		}

		private void btnOk_Click(object sender, EventArgs e) {
			Close();
			return;
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			Close();
			return;
		}

		//calcola lo sconto in percentuale applicato, inserendo nel form lo sconto in € applicato
		private void txtScontoApplicato_Leave(object sender, EventArgs e) {

			bool isValid = txtScontoApplicato_validate();
			if (!isValid) return;

			decimal prezzoPieno = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(decimal), txtImponibile.Text, "x.y.c"));	
			decimal scontoApplicato = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(decimal), txtScontoApplicato.Text, "x.y.c"));	
			decimal iva = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(decimal), txtIvaEUR.Text, "x.y.c"));
            decimal quantita = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(decimal), txtQuantita.Text, "x.y.c"));
			decimal prezzoFinale = (prezzoPieno * quantita) - scontoApplicato;
			decimal scontoPerc = (100 - ((prezzoFinale * 100) / prezzoPieno));
			decimal importoiva = prezzoPieno + iva;
			
			txtImportoFinale.Text = HelpForm.StringValue(prezzoFinale, "x.y.fixed.2...1");	
			txtScontoPercentuale.Text = HelpForm.StringValue(scontoPerc, "x.y.fixed.4....%.100");				
			/*scontoPercentuale*/ sconto  = Math.Round(scontoPerc, 4);
			txtImportoIva.Text = HelpForm.StringValue(importoiva, "x.y.fixed.2...1");	
			
			if (txtScontoApplicato.Text != "") {
				//decimal temp = CfgFn.GetNoNullDouble(txtImponibileEUR.Text); vecchio valore
				txtImponibileEUR.Text = txtImportoFinale.Text;
				prezzoPieno = CfgFn.GetNoNullDecimal(txtImponibileEUR.Text);
				importoiva = (taxRate * prezzoPieno);
				txtIvaEUR.Text = HelpForm.StringValue(importoiva, "x.y.fixed.2...1");
				txtImportoIva.Text = HelpForm.StringValue((prezzoPieno + importoiva), "x.y.fixed.2...1");	
			}
						
		}

		//verifico se l'input del textbox txtScontoApplicato è corretto
		private bool txtScontoApplicato_validate() {
			HelpForm.ExtLeaveDecTextBox(txtScontoApplicato, "x.y");
			decimal sconto = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(decimal), txtScontoApplicato.Text, "x.y.c"));
			
			if (sconto < 0) {
				txtScontoApplicato.Text = "";				
				return false;
			}

			return true;
		}
	}
}
