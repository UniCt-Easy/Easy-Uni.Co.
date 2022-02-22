
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


using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using funzioni_configurazione;
using System.Data;

namespace casualcontracttax_default//contrattooccritenuta//
{
	/// <summary>
	/// Summary description for frmcontrattooccritenuta.
	/// </summary>
	public class Frm_casualcontracttax_default : MetaDataForm
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.TextBox textBox14;
		private System.Windows.Forms.TextBox textBox15;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox textBox8;
		private System.Windows.Forms.TextBox textBox9;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox textBox12;
		private System.Windows.Forms.TextBox textBox13;
		public vistaForm DS;
		private System.Windows.Forms.TextBox txtImponibileNetto;
		private System.Windows.Forms.TextBox txtAliquotaAmm;
		private System.Windows.Forms.TextBox txtAliquotaDip;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_casualcontracttax_default()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.DS = new casualcontracttax_default.vistaForm();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtImponibileNetto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.txtAliquotaAmm = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtAliquotaDip = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Imponibile Lordo";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Imponibile Netto";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tipo Ritenuta";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DataSource = this.DS.tax;
            this.comboBox1.DisplayMember = "description";
            this.comboBox1.Location = new System.Drawing.Point(128, 8);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(424, 21);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.Tag = "casualcontracttax.taxcode";
            this.comboBox1.ValueMember = "taxcode";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(16, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "Deduzione";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(128, 40);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 6;
            this.textBox1.Tag = "casualcontracttax.taxablegross";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(128, 64);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 7;
            this.textBox2.Tag = "casualcontracttax.deduction";
            // 
            // txtImponibileNetto
            // 
            this.txtImponibileNetto.Location = new System.Drawing.Point(128, 88);
            this.txtImponibileNetto.Name = "txtImponibileNetto";
            this.txtImponibileNetto.Size = new System.Drawing.Size(100, 20);
            this.txtImponibileNetto.TabIndex = 8;
            this.txtImponibileNetto.Tag = "casualcontracttax.taxablenet";
            this.txtImponibileNetto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 9;
            this.label5.Text = "Rit. Dipendente";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(128, 112);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 10;
            this.textBox4.Tag = "casualcontracttax.employtax";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(16, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 11;
            this.label6.Text = "Rit. Ammin.";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(128, 136);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 20);
            this.textBox5.TabIndex = 0;
            this.textBox5.Tag = "casualcontracttax.admintax";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBox14);
            this.groupBox4.Controls.Add(this.textBox15);
            this.groupBox4.Controls.Add(this.panel2);
            this.groupBox4.Location = new System.Drawing.Point(240, 32);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(108, 80);
            this.groupBox4.TabIndex = 41;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Quota imponibile:";
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(24, 56);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(56, 20);
            this.textBox14.TabIndex = 11;
            this.textBox14.Tag = "casualcontracttax.taxabledenominator.n";
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(24, 24);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(56, 20);
            this.textBox15.TabIndex = 10;
            this.textBox15.Tag = "casualcontracttax.taxablenumerator.n";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(16, 48);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(72, 2);
            this.panel2.TabIndex = 28;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox8);
            this.groupBox2.Controls.Add(this.textBox9);
            this.groupBox2.Controls.Add(this.txtAliquotaAmm);
            this.groupBox2.Controls.Add(this.panel5);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(352, 120);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 80);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ritenute c/Amministrazione";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(136, 48);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(56, 20);
            this.textBox8.TabIndex = 2;
            this.textBox8.Tag = "casualcontracttax.admindenominator.n";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(136, 16);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(56, 20);
            this.textBox9.TabIndex = 1;
            this.textBox9.Tag = "casualcontracttax.adminnumerator.n";
            // 
            // txtAliquotaAmm
            // 
            this.txtAliquotaAmm.Location = new System.Drawing.Point(8, 40);
            this.txtAliquotaAmm.Name = "txtAliquotaAmm";
            this.txtAliquotaAmm.Size = new System.Drawing.Size(80, 20);
            this.txtAliquotaAmm.TabIndex = 0;
            this.txtAliquotaAmm.Tag = "casualcontracttax.adminrate.fixed.6..%.100";
            this.txtAliquotaAmm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Location = new System.Drawing.Point(128, 40);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(72, 2);
            this.panel5.TabIndex = 31;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(88, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 22);
            this.label8.TabIndex = 30;
            this.label8.Text = "Quota:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(24, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 22);
            this.label9.TabIndex = 28;
            this.label9.Text = "Aliquota:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel3);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.txtAliquotaDip);
            this.groupBox3.Controls.Add(this.textBox12);
            this.groupBox3.Controls.Add(this.textBox13);
            this.groupBox3.Location = new System.Drawing.Point(352, 32);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 80);
            this.groupBox3.TabIndex = 39;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ritenute c/Dipendente";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(128, 40);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(72, 2);
            this.panel3.TabIndex = 31;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(88, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 22);
            this.label10.TabIndex = 30;
            this.label10.Text = "Quota:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(24, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 22);
            this.label11.TabIndex = 28;
            this.label11.Text = "Aliquota:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAliquotaDip
            // 
            this.txtAliquotaDip.Location = new System.Drawing.Point(8, 40);
            this.txtAliquotaDip.Name = "txtAliquotaDip";
            this.txtAliquotaDip.Size = new System.Drawing.Size(80, 20);
            this.txtAliquotaDip.TabIndex = 0;
            this.txtAliquotaDip.Tag = "casualcontracttax.employrate.fixed.6..%.100";
            this.txtAliquotaDip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(136, 48);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(56, 20);
            this.textBox12.TabIndex = 2;
            this.textBox12.Tag = "casualcontracttax.employdenominator.n";
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(136, 16);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(56, 20);
            this.textBox13.TabIndex = 1;
            this.textBox13.Tag = "casualcontracttax.employnumerator.n";
            // 
            // Frm_casualcontracttax_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(560, 206);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.txtImponibileNetto);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Frm_casualcontracttax_default";
            this.Text = "frmcontrattooccritenuta";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
		public void MetaData_AfterLink()
		{
			MetaData Meta = MetaData.GetMetaData(this);
			bool IsAdmin=false;

			if (Meta.GetSys("manage_prestazioni")!=null) 
				IsAdmin=(Meta.GetSys("manage_prestazioni").ToString()=="S");
			Meta.CanSave=IsAdmin;
			Meta.CanInsert=IsAdmin;
			Meta.CanInsertCopy=IsAdmin;
			Meta.CanCancel=IsAdmin;
			impostaOggettiInSolaLettura(!IsAdmin);
		}

		public void MetaData_AfterFill() {
            //calcolaCampiCalcolati();
		}

		private void impostaOggettiInSolaLettura(bool solalettura)
		{
			textBox1.ReadOnly = solalettura;
			textBox2.ReadOnly = solalettura;
			txtImponibileNetto.ReadOnly = solalettura;
			textBox4.ReadOnly = solalettura;
			textBox5.ReadOnly = solalettura;
			textBox8.ReadOnly = solalettura;
			textBox9.ReadOnly = solalettura;
			txtAliquotaAmm.ReadOnly = solalettura;
			txtAliquotaDip.ReadOnly = solalettura;
			textBox12.ReadOnly = solalettura;
			textBox13.ReadOnly = solalettura;
			textBox14.ReadOnly = solalettura;
			textBox15.ReadOnly = solalettura;
		}

		/// <summary>
		/// Metodo che calcola il rapporto tra numeratore e denominatore
		/// </summary>
		/// <param name="quotanum">Numeratore</param>
		/// <param name="quotaden">Denominatore</param>
		/// <returns>Rapporto tra numeratore e denominatore</returns>
		private decimal rapporto(object quotanum, object quotaden) {
			if (CfgFn.GetNoNullDecimal(quotaden)==0) {
				return (quotanum is DBNull) ? 1 : CfgFn.GetNoNullDecimal(quotanum);
			}
			if (quotanum is DBNull) {
				return 1;
			}
			return CfgFn.GetNoNullDecimal(quotanum) / CfgFn.GetNoNullDecimal(quotaden);
		}

		private void calcolaCampiCalcolati() {
			if (DS.casualcontracttax.Rows.Count == 0) return;
			DataRow Curr = DS.casualcontracttax.Rows[0];
			decimal imponibileNetto = CfgFn.GetNoNullDecimal(Curr["taxablenet"]);
            //object quotaNumImponibile = Curr["taxablenumerator"];
            //object quotaDenImponibile = Curr["taxabledenominator"];
            //decimal frazione = rapporto(quotaNumImponibile, quotaDenImponibile);
            //decimal imponibileNetto = CfgFn.RoundValuta(imponibile * frazione);
            //Curr["!imponibilenetto"] = imponibileNetto;
            //txtImponibileNetto.Text = imponibileNetto.ToString("c");

			decimal aliquotaAmmMedia = (imponibileNetto != 0)
				? CfgFn.GetNoNullDecimal(Curr["admintax"]) / imponibileNetto : 0;
			Curr["!aliquotaamm"] = aliquotaAmmMedia;
			txtAliquotaAmm.Text = aliquotaAmmMedia.ToString("p6");

			decimal aliquotaDipMedia = (imponibileNetto != 0)
				? CfgFn.GetNoNullDecimal(Curr["employtax"]) / imponibileNetto : 0;
			Curr["!aliquotadip"] = aliquotaDipMedia;
			txtAliquotaDip.Text = aliquotaDipMedia.ToString("p6");
		}
	}
}
