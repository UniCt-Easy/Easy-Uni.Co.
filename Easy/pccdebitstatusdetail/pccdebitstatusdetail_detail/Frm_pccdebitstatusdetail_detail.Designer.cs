
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



namespace pccdebitstatusdetail_detail {
	partial class Frm_pccdebitstatusdetail_detail {
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
			this.DS = new pccdebitstatusdetail_detail.vistaForm();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.grpSospesoContenzioso = new System.Windows.Forms.GroupBox();
			this.txtimp_sosp_contenzioso = new System.Windows.Forms.TextBox();
			this.txtstart_sosp_contenzioso = new System.Windows.Forms.TextBox();
			this.txtiva_sosp_contenzioso = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.grpSospesoDataRegolare = new System.Windows.Forms.GroupBox();
			this.txtimp_sosp_regolareverifica = new System.Windows.Forms.TextBox();
			this.txtstart_sosp_regolareverifica = new System.Windows.Forms.TextBox();
			this.txtiva_sosp_regolareverifica = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.grpNonliquidabile = new System.Windows.Forms.GroupBox();
			this.txtImponibileNoLiq = new System.Windows.Forms.TextBox();
			this.TxtIvaNoLiq = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.grpNonCommerciale = new System.Windows.Forms.GroupBox();
			this.txtimportononcommerciale = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.grpSospesoContestazione = new System.Windows.Forms.GroupBox();
			this.txtimp_sosp_contestazione = new System.Windows.Forms.TextBox();
			this.txtstart_sosp_contestazione = new System.Windows.Forms.TextBox();
			this.txtiva_sosp_contestazione = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.txtidpcc = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.grpSospesoContenzioso.SuspendLayout();
			this.grpSospesoDataRegolare.SuspendLayout();
			this.grpNonliquidabile.SuspendLayout();
			this.grpNonCommerciale.SuspendLayout();
			this.grpSospesoContestazione.SuspendLayout();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(587, 294);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(73, 28);
			this.btnCancel.TabIndex = 72;
			this.btnCancel.Tag = "";
			this.btnCancel.Text = "Annulla";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(486, 294);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(73, 28);
			this.btnOk.TabIndex = 71;
			this.btnOk.Tag = "mainsave";
			this.btnOk.Text = "Ok";
			this.btnOk.UseVisualStyleBackColor = true;
			// 
			// grpSospesoContenzioso
			// 
			this.grpSospesoContenzioso.Controls.Add(this.txtimp_sosp_contenzioso);
			this.grpSospesoContenzioso.Controls.Add(this.txtstart_sosp_contenzioso);
			this.grpSospesoContenzioso.Controls.Add(this.txtiva_sosp_contenzioso);
			this.grpSospesoContenzioso.Controls.Add(this.label4);
			this.grpSospesoContenzioso.Controls.Add(this.label3);
			this.grpSospesoContenzioso.Controls.Add(this.label2);
			this.grpSospesoContenzioso.Location = new System.Drawing.Point(10, 88);
			this.grpSospesoContenzioso.Name = "grpSospesoContenzioso";
			this.grpSospesoContenzioso.Size = new System.Drawing.Size(323, 85);
			this.grpSospesoContenzioso.TabIndex = 20;
			this.grpSospesoContenzioso.TabStop = false;
			this.grpSospesoContenzioso.Text = "Sospeso in Contenzioso";
			// 
			// txtimp_sosp_contenzioso
			// 
			this.txtimp_sosp_contenzioso.Location = new System.Drawing.Point(66, 54);
			this.txtimp_sosp_contenzioso.Name = "txtimp_sosp_contenzioso";
			this.txtimp_sosp_contenzioso.ReadOnly = true;
			this.txtimp_sosp_contenzioso.Size = new System.Drawing.Size(100, 20);
			this.txtimp_sosp_contenzioso.TabIndex = 22;
			this.txtimp_sosp_contenzioso.Tag = "pccdebitstatusdetail.imp_sosp_contenzioso";
			// 
			// txtstart_sosp_contenzioso
			// 
			this.txtstart_sosp_contenzioso.Location = new System.Drawing.Point(66, 27);
			this.txtstart_sosp_contenzioso.Name = "txtstart_sosp_contenzioso";
			this.txtstart_sosp_contenzioso.Size = new System.Drawing.Size(100, 20);
			this.txtstart_sosp_contenzioso.TabIndex = 21;
			this.txtstart_sosp_contenzioso.Tag = "pccdebitstatusdetail.start_sosp_contenzioso";
			// 
			// txtiva_sosp_contenzioso
			// 
			this.txtiva_sosp_contenzioso.Location = new System.Drawing.Point(212, 54);
			this.txtiva_sosp_contenzioso.Name = "txtiva_sosp_contenzioso";
			this.txtiva_sosp_contenzioso.ReadOnly = true;
			this.txtiva_sosp_contenzioso.Size = new System.Drawing.Size(100, 20);
			this.txtiva_sosp_contenzioso.TabIndex = 23;
			this.txtiva_sosp_contenzioso.Tag = "pccdebitstatusdetail.iva_sosp_contenzioso";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(184, 59);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(22, 13);
			this.label4.TabIndex = 2;
			this.label4.Text = "Iva";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 28);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 13);
			this.label3.TabIndex = 1;
			this.label3.Text = "Data inizio";
			this.label3.Click += new System.EventHandler(this.label3_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 58);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(54, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "Imponibile";
			// 
			// grpSospesoDataRegolare
			// 
			this.grpSospesoDataRegolare.Controls.Add(this.txtimp_sosp_regolareverifica);
			this.grpSospesoDataRegolare.Controls.Add(this.txtstart_sosp_regolareverifica);
			this.grpSospesoDataRegolare.Controls.Add(this.txtiva_sosp_regolareverifica);
			this.grpSospesoDataRegolare.Controls.Add(this.label8);
			this.grpSospesoDataRegolare.Controls.Add(this.label9);
			this.grpSospesoDataRegolare.Controls.Add(this.label10);
			this.grpSospesoDataRegolare.Location = new System.Drawing.Point(12, 177);
			this.grpSospesoDataRegolare.Name = "grpSospesoDataRegolare";
			this.grpSospesoDataRegolare.Size = new System.Drawing.Size(321, 86);
			this.grpSospesoDataRegolare.TabIndex = 40;
			this.grpSospesoDataRegolare.TabStop = false;
			this.grpSospesoDataRegolare.Text = "Sospeso per data esito regolare verifica di conformità";
			// 
			// txtimp_sosp_regolareverifica
			// 
			this.txtimp_sosp_regolareverifica.Location = new System.Drawing.Point(68, 57);
			this.txtimp_sosp_regolareverifica.Name = "txtimp_sosp_regolareverifica";
			this.txtimp_sosp_regolareverifica.ReadOnly = true;
			this.txtimp_sosp_regolareverifica.Size = new System.Drawing.Size(100, 20);
			this.txtimp_sosp_regolareverifica.TabIndex = 42;
			this.txtimp_sosp_regolareverifica.Tag = "pccdebitstatusdetail.imp_sosp_regolareverifica";
			// 
			// txtstart_sosp_regolareverifica
			// 
			this.txtstart_sosp_regolareverifica.Location = new System.Drawing.Point(68, 30);
			this.txtstart_sosp_regolareverifica.Name = "txtstart_sosp_regolareverifica";
			this.txtstart_sosp_regolareverifica.Size = new System.Drawing.Size(100, 20);
			this.txtstart_sosp_regolareverifica.TabIndex = 41;
			this.txtstart_sosp_regolareverifica.Tag = "pccdebitstatusdetail.start_sosp_regolareverifica";
			// 
			// txtiva_sosp_regolareverifica
			// 
			this.txtiva_sosp_regolareverifica.Location = new System.Drawing.Point(214, 57);
			this.txtiva_sosp_regolareverifica.Name = "txtiva_sosp_regolareverifica";
			this.txtiva_sosp_regolareverifica.ReadOnly = true;
			this.txtiva_sosp_regolareverifica.Size = new System.Drawing.Size(100, 20);
			this.txtiva_sosp_regolareverifica.TabIndex = 43;
			this.txtiva_sosp_regolareverifica.Tag = "pccdebitstatusdetail.iva_sosp_regolareverifica";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(186, 62);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(22, 13);
			this.label8.TabIndex = 8;
			this.label8.Text = "Iva";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(8, 31);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(56, 13);
			this.label9.TabIndex = 7;
			this.label9.Text = "Data inizio";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(8, 61);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(54, 13);
			this.label10.TabIndex = 6;
			this.label10.Text = "Imponibile";
			// 
			// grpNonliquidabile
			// 
			this.grpNonliquidabile.Controls.Add(this.txtImponibileNoLiq);
			this.grpNonliquidabile.Controls.Add(this.TxtIvaNoLiq);
			this.grpNonliquidabile.Controls.Add(this.label11);
			this.grpNonliquidabile.Controls.Add(this.label13);
			this.grpNonliquidabile.Location = new System.Drawing.Point(9, 23);
			this.grpNonliquidabile.Name = "grpNonliquidabile";
			this.grpNonliquidabile.Size = new System.Drawing.Size(321, 64);
			this.grpNonliquidabile.TabIndex = 10;
			this.grpNonliquidabile.TabStop = false;
			this.grpNonliquidabile.Text = "Non liquidabile";
			// 
			// txtImponibileNoLiq
			// 
			this.txtImponibileNoLiq.Location = new System.Drawing.Point(67, 33);
			this.txtImponibileNoLiq.Name = "txtImponibileNoLiq";
			this.txtImponibileNoLiq.ReadOnly = true;
			this.txtImponibileNoLiq.Size = new System.Drawing.Size(100, 20);
			this.txtImponibileNoLiq.TabIndex = 11;
			this.txtImponibileNoLiq.Tag = "pccdebitstatusdetail.imp_nonliquidabile";
			// 
			// TxtIvaNoLiq
			// 
			this.TxtIvaNoLiq.Location = new System.Drawing.Point(213, 33);
			this.TxtIvaNoLiq.Name = "TxtIvaNoLiq";
			this.TxtIvaNoLiq.ReadOnly = true;
			this.TxtIvaNoLiq.Size = new System.Drawing.Size(100, 20);
			this.TxtIvaNoLiq.TabIndex = 12;
			this.TxtIvaNoLiq.Tag = "pccdebitstatusdetail.iva_nonliquidabile";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(184, 38);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(22, 13);
			this.label11.TabIndex = 8;
			this.label11.Text = "Iva";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(11, 37);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(54, 13);
			this.label13.TabIndex = 6;
			this.label13.Text = "Imponibile";
			// 
			// grpNonCommerciale
			// 
			this.grpNonCommerciale.Controls.Add(this.txtimportononcommerciale);
			this.grpNonCommerciale.Controls.Add(this.label12);
			this.grpNonCommerciale.Location = new System.Drawing.Point(341, 178);
			this.grpNonCommerciale.Name = "grpNonCommerciale";
			this.grpNonCommerciale.Size = new System.Drawing.Size(321, 60);
			this.grpNonCommerciale.TabIndex = 50;
			this.grpNonCommerciale.TabStop = false;
			this.grpNonCommerciale.Text = "Non commerciale";
			// 
			// txtimportononcommerciale
			// 
			this.txtimportononcommerciale.Location = new System.Drawing.Point(66, 25);
			this.txtimportononcommerciale.Name = "txtimportononcommerciale";
			this.txtimportononcommerciale.Size = new System.Drawing.Size(100, 20);
			this.txtimportononcommerciale.TabIndex = 51;
			this.txtimportononcommerciale.Tag = "pccdebitstatusdetail.importononcommerciale";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(14, 32);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(42, 13);
			this.label12.TabIndex = 12;
			this.label12.Text = "Importo";
			// 
			// grpSospesoContestazione
			// 
			this.grpSospesoContestazione.Controls.Add(this.txtimp_sosp_contestazione);
			this.grpSospesoContestazione.Controls.Add(this.txtstart_sosp_contestazione);
			this.grpSospesoContestazione.Controls.Add(this.txtiva_sosp_contestazione);
			this.grpSospesoContestazione.Controls.Add(this.label5);
			this.grpSospesoContestazione.Controls.Add(this.label6);
			this.grpSospesoContestazione.Controls.Add(this.label7);
			this.grpSospesoContestazione.Location = new System.Drawing.Point(341, 89);
			this.grpSospesoContestazione.Name = "grpSospesoContestazione";
			this.grpSospesoContestazione.Size = new System.Drawing.Size(321, 85);
			this.grpSospesoContestazione.TabIndex = 30;
			this.grpSospesoContestazione.TabStop = false;
			this.grpSospesoContestazione.Text = "Sospeso per Contestazione/Adempimenti Normativi";
			// 
			// txtimp_sosp_contestazione
			// 
			this.txtimp_sosp_contestazione.Location = new System.Drawing.Point(66, 55);
			this.txtimp_sosp_contestazione.Name = "txtimp_sosp_contestazione";
			this.txtimp_sosp_contestazione.ReadOnly = true;
			this.txtimp_sosp_contestazione.Size = new System.Drawing.Size(100, 20);
			this.txtimp_sosp_contestazione.TabIndex = 32;
			this.txtimp_sosp_contestazione.Tag = "pccdebitstatusdetail.imp_sosp_contestazione";
			// 
			// txtstart_sosp_contestazione
			// 
			this.txtstart_sosp_contestazione.Location = new System.Drawing.Point(66, 28);
			this.txtstart_sosp_contestazione.Name = "txtstart_sosp_contestazione";
			this.txtstart_sosp_contestazione.Size = new System.Drawing.Size(100, 20);
			this.txtstart_sosp_contestazione.TabIndex = 31;
			this.txtstart_sosp_contestazione.Tag = "pccdebitstatusdetail.start_sosp_contestazione";
			// 
			// txtiva_sosp_contestazione
			// 
			this.txtiva_sosp_contestazione.Location = new System.Drawing.Point(212, 55);
			this.txtiva_sosp_contestazione.Name = "txtiva_sosp_contestazione";
			this.txtiva_sosp_contestazione.ReadOnly = true;
			this.txtiva_sosp_contestazione.Size = new System.Drawing.Size(100, 20);
			this.txtiva_sosp_contestazione.TabIndex = 33;
			this.txtiva_sosp_contestazione.Tag = "pccdebitstatusdetail.iva_sosp_contestazione";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(184, 60);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(22, 13);
			this.label5.TabIndex = 8;
			this.label5.Text = "Iva";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 29);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(56, 13);
			this.label6.TabIndex = 7;
			this.label6.Text = "Data inizio";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(6, 59);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(54, 13);
			this.label7.TabIndex = 6;
			this.label7.Text = "Imponibile";
			// 
			// txtidpcc
			// 
			this.txtidpcc.Location = new System.Drawing.Point(199, 303);
			this.txtidpcc.Name = "txtidpcc";
			this.txtidpcc.ReadOnly = true;
			this.txtidpcc.Size = new System.Drawing.Size(134, 20);
			this.txtidpcc.TabIndex = 60;
			this.txtidpcc.Tag = "pccdebitstatusdetail.idpcc";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(68, 305);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(116, 13);
			this.label1.TabIndex = 97;
			this.label1.Text = "Num. trasmissione PCC";
			// 
			// Frm_pccdebitstatusdetail_detail
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(676, 331);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtidpcc);
			this.Controls.Add(this.grpSospesoContestazione);
			this.Controls.Add(this.grpNonCommerciale);
			this.Controls.Add(this.grpNonliquidabile);
			this.Controls.Add(this.grpSospesoDataRegolare);
			this.Controls.Add(this.grpSospesoContenzioso);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Name = "Frm_pccdebitstatusdetail_detail";
			this.Text = "Stato del debito dettagliato";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.grpSospesoContenzioso.ResumeLayout(false);
			this.grpSospesoContenzioso.PerformLayout();
			this.grpSospesoDataRegolare.ResumeLayout(false);
			this.grpSospesoDataRegolare.PerformLayout();
			this.grpNonliquidabile.ResumeLayout(false);
			this.grpNonliquidabile.PerformLayout();
			this.grpNonCommerciale.ResumeLayout(false);
			this.grpNonCommerciale.PerformLayout();
			this.grpSospesoContestazione.ResumeLayout(false);
			this.grpSospesoContestazione.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public vistaForm DS;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.GroupBox grpSospesoContenzioso;
		private System.Windows.Forms.GroupBox grpSospesoDataRegolare;
		private System.Windows.Forms.GroupBox grpNonliquidabile;
		private System.Windows.Forms.GroupBox grpNonCommerciale;
		private System.Windows.Forms.GroupBox grpSospesoContestazione;
		private System.Windows.Forms.TextBox txtidpcc;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtimp_sosp_contenzioso;
		private System.Windows.Forms.TextBox txtstart_sosp_contenzioso;
		private System.Windows.Forms.TextBox txtiva_sosp_contenzioso;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtimp_sosp_regolareverifica;
		private System.Windows.Forms.TextBox txtstart_sosp_regolareverifica;
		private System.Windows.Forms.TextBox txtiva_sosp_regolareverifica;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtImponibileNoLiq;
		private System.Windows.Forms.TextBox TxtIvaNoLiq;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox txtimportononcommerciale;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox txtimp_sosp_contestazione;
		private System.Windows.Forms.TextBox txtstart_sosp_contestazione;
		private System.Windows.Forms.TextBox txtiva_sosp_contestazione;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
	}
}
