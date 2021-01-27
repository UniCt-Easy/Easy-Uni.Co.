
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


using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using System.Data;

namespace servicepayment_detail
{
	/// <summary>
	/// Summary description for Frm_servicepayment_detail.
	/// </summary>
	public class Frm_servicepayment_detail : System.Windows.Forms.Form
	{
		public servicepayment_detail.vistaForm DS;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.GroupBox grbpagamento;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox txtimportopagato;
		private System.Windows.Forms.TextBox txtanopagamento;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox txtannopagamento;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox grpContratto;
		private System.Windows.Forms.TextBox txteser;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.GroupBox grbSemestre;
		private System.Windows.Forms.RadioButton rdbgenderf;
		private System.Windows.Forms.RadioButton rdbgenderm;
		private System.Windows.Forms.TextBox txtnum;
		private System.Windows.Forms.RadioButton rdbprimo;
		private System.Windows.Forms.RadioButton rdbsecondo;
		private System.Windows.Forms.CheckBox chkischanged;
		private System.Windows.Forms.CheckBox chkisdelivery;
		private System.Windows.Forms.CheckBox chkblocked;
		private System.Windows.Forms.Label lblpagamentoblocato;
		MetaData Meta;

		public Frm_servicepayment_detail()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
            this.DS = new servicepayment_detail.vistaForm();
            this.grbpagamento = new System.Windows.Forms.GroupBox();
            this.grbSemestre = new System.Windows.Forms.GroupBox();
            this.rdbsecondo = new System.Windows.Forms.RadioButton();
            this.rdbprimo = new System.Windows.Forms.RadioButton();
            this.txtannopagamento = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtimportopagato = new System.Windows.Forms.TextBox();
            this.rdbgenderf = new System.Windows.Forms.RadioButton();
            this.rdbgenderm = new System.Windows.Forms.RadioButton();
            this.txtanopagamento = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.grpContratto = new System.Windows.Forms.GroupBox();
            this.lblpagamentoblocato = new System.Windows.Forms.Label();
            this.chkblocked = new System.Windows.Forms.CheckBox();
            this.chkischanged = new System.Windows.Forms.CheckBox();
            this.chkisdelivery = new System.Windows.Forms.CheckBox();
            this.txteser = new System.Windows.Forms.TextBox();
            this.txtnum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.grbpagamento.SuspendLayout();
            this.grbSemestre.SuspendLayout();
            this.grpContratto.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // grbpagamento
            // 
            this.grbpagamento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grbpagamento.Controls.Add(this.grbSemestre);
            this.grbpagamento.Controls.Add(this.txtannopagamento);
            this.grbpagamento.Controls.Add(this.label1);
            this.grbpagamento.Controls.Add(this.label16);
            this.grbpagamento.Controls.Add(this.txtimportopagato);
            this.grbpagamento.Location = new System.Drawing.Point(16, 120);
            this.grbpagamento.Name = "grbpagamento";
            this.grbpagamento.Size = new System.Drawing.Size(304, 112);
            this.grbpagamento.TabIndex = 13;
            this.grbpagamento.TabStop = false;
            this.grbpagamento.Text = "Pagamento";
            // 
            // grbSemestre
            // 
            this.grbSemestre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grbSemestre.Controls.Add(this.rdbsecondo);
            this.grbSemestre.Controls.Add(this.rdbprimo);
            this.grbSemestre.Location = new System.Drawing.Point(112, 8);
            this.grbSemestre.Name = "grbSemestre";
            this.grbSemestre.Size = new System.Drawing.Size(184, 40);
            this.grbSemestre.TabIndex = 31;
            this.grbSemestre.TabStop = false;
            this.grbSemestre.Text = "Semestre Pagamento";
            // 
            // rdbsecondo
            // 
            this.rdbsecondo.Location = new System.Drawing.Point(104, 16);
            this.rdbsecondo.Name = "rdbsecondo";
            this.rdbsecondo.Size = new System.Drawing.Size(72, 16);
            this.rdbsecondo.TabIndex = 1;
            this.rdbsecondo.Tag = "servicepayment.semesterpay:2";
            this.rdbsecondo.Text = "Secondo";
            // 
            // rdbprimo
            // 
            this.rdbprimo.Location = new System.Drawing.Point(16, 16);
            this.rdbprimo.Name = "rdbprimo";
            this.rdbprimo.Size = new System.Drawing.Size(72, 16);
            this.rdbprimo.TabIndex = 0;
            this.rdbprimo.Tag = "servicepayment.semesterpay:1";
            this.rdbprimo.Text = "Primo";
            // 
            // txtannopagamento
            // 
            this.txtannopagamento.Location = new System.Drawing.Point(48, 24);
            this.txtannopagamento.Name = "txtannopagamento";
            this.txtannopagamento.Size = new System.Drawing.Size(56, 20);
            this.txtannopagamento.TabIndex = 16;
            this.txtannopagamento.Tag = "servicepayment.ypay.year";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "Anno";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(24, 80);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(80, 16);
            this.label16.TabIndex = 0;
            this.label16.Text = "Importo pagato";
            // 
            // txtimportopagato
            // 
            this.txtimportopagato.Location = new System.Drawing.Point(112, 80);
            this.txtimportopagato.Name = "txtimportopagato";
            this.txtimportopagato.Size = new System.Drawing.Size(80, 20);
            this.txtimportopagato.TabIndex = 13;
            this.txtimportopagato.Tag = "servicepayment.payedamount";
            // 
            // rdbgenderf
            // 
            this.rdbgenderf.Location = new System.Drawing.Point(0, 0);
            this.rdbgenderf.Name = "rdbgenderf";
            this.rdbgenderf.Size = new System.Drawing.Size(104, 24);
            this.rdbgenderf.TabIndex = 0;
            // 
            // rdbgenderm
            // 
            this.rdbgenderm.Location = new System.Drawing.Point(0, 0);
            this.rdbgenderm.Name = "rdbgenderm";
            this.rdbgenderm.Size = new System.Drawing.Size(104, 24);
            this.rdbgenderm.TabIndex = 0;
            // 
            // txtanopagamento
            // 
            this.txtanopagamento.Location = new System.Drawing.Point(0, 0);
            this.txtanopagamento.Name = "txtanopagamento";
            this.txtanopagamento.Size = new System.Drawing.Size(200, 20);
            this.txtanopagamento.TabIndex = 0;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(0, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 23);
            this.label15.TabIndex = 0;
            // 
            // grpContratto
            // 
            this.grpContratto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpContratto.Controls.Add(this.lblpagamentoblocato);
            this.grpContratto.Controls.Add(this.chkblocked);
            this.grpContratto.Controls.Add(this.chkischanged);
            this.grpContratto.Controls.Add(this.chkisdelivery);
            this.grpContratto.Controls.Add(this.txteser);
            this.grpContratto.Controls.Add(this.txtnum);
            this.grpContratto.Controls.Add(this.label3);
            this.grpContratto.Controls.Add(this.label2);
            this.grpContratto.Location = new System.Drawing.Point(16, 8);
            this.grpContratto.Name = "grpContratto";
            this.grpContratto.Size = new System.Drawing.Size(304, 112);
            this.grpContratto.TabIndex = 14;
            this.grpContratto.TabStop = false;
            this.grpContratto.Text = "Incarico";
            // 
            // lblpagamentoblocato
            // 
            this.lblpagamentoblocato.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpagamentoblocato.Location = new System.Drawing.Point(32, 72);
            this.lblpagamentoblocato.Name = "lblpagamentoblocato";
            this.lblpagamentoblocato.Size = new System.Drawing.Size(248, 32);
            this.lblpagamentoblocato.TabIndex = 9;
            this.lblpagamentoblocato.Text = "Il pagamento è sospeso perchè in attesa di conferma da parte dell\'Amministrazione" +
                "";
            // 
            // chkblocked
            // 
            this.chkblocked.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkblocked.Location = new System.Drawing.Point(16, 72);
            this.chkblocked.Name = "chkblocked";
            this.chkblocked.Size = new System.Drawing.Size(280, 32);
            this.chkblocked.TabIndex = 8;
            this.chkblocked.Tag = "servicepayment.is_blocked:S:N";
            this.chkblocked.Text = "Il pagamento è sospeso perchè in attesa di conferma da parte dell\'Amministrazione" +
                "";
            // 
            // chkischanged
            // 
            this.chkischanged.Location = new System.Drawing.Point(120, 48);
            this.chkischanged.Name = "chkischanged";
            this.chkischanged.Size = new System.Drawing.Size(96, 16);
            this.chkischanged.TabIndex = 7;
            this.chkischanged.TabStop = false;
            this.chkischanged.Tag = "servicepayment.is_changed:S:N";
            this.chkischanged.Text = "Da modificare";
            this.chkischanged.CheckedChanged += new System.EventHandler(this.chkischanged_CheckedChanged);
            // 
            // chkisdelivery
            // 
            this.chkisdelivery.Location = new System.Drawing.Point(16, 48);
            this.chkisdelivery.Name = "chkisdelivery";
            this.chkisdelivery.Size = new System.Drawing.Size(104, 16);
            this.chkisdelivery.TabIndex = 6;
            this.chkisdelivery.TabStop = false;
            this.chkisdelivery.Tag = "servicepayment.is_delivered:S:N";
            this.chkisdelivery.Text = "Trasmesso";
            // 
            // txteser
            // 
            this.txteser.Location = new System.Drawing.Point(72, 16);
            this.txteser.Name = "txteser";
            this.txteser.ReadOnly = true;
            this.txteser.Size = new System.Drawing.Size(64, 20);
            this.txteser.TabIndex = 1;
            this.txteser.Tag = "servicepayment.yservreg.year";
            // 
            // txtnum
            // 
            this.txtnum.Location = new System.Drawing.Point(200, 16);
            this.txtnum.Name = "txtnum";
            this.txtnum.ReadOnly = true;
            this.txtnum.Size = new System.Drawing.Size(64, 20);
            this.txtnum.TabIndex = 2;
            this.txtnum.Tag = "servicepayment.nservreg";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Esercizio";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(144, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Numero";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(192, 240);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 116;
            this.btnOk.Tag = "mainsave";
            this.btnOk.Text = "Ok";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(64, 240);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 115;
            this.btnCancel.Text = "Cancel";
            // 
            // Frm_servicepayment_detail
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(336, 278);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grpContratto);
            this.Controls.Add(this.grbpagamento);
            this.Name = "Frm_servicepayment_detail";
            this.Text = "Frm_servicepayment_detail";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.grbpagamento.ResumeLayout(false);
            this.grbpagamento.PerformLayout();
            this.grbSemestre.ResumeLayout(false);
            this.grpContratto.ResumeLayout(false);
            this.grpContratto.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion
		public void MetaData_AfterLink() 
		{	
			Meta = MetaData.GetMetaData(this);
			
			HelpForm.SetDenyNull(DS.servicepayment.Columns["is_delivered"], true);
			HelpForm.SetDenyNull(DS.servicepayment.Columns["is_changed"], true);
			HelpForm.SetDenyNull(DS.servicepayment.Columns["is_blocked"], true);
		}

		private void gestioneFlag() 
		{
			if 	(chkblocked.Checked)
			{
				grbpagamento.Enabled = false;
				chkischanged.Enabled = false;
				return;
			}
			if (chkisdelivery.Checked)
			{
				grbpagamento.Enabled = false;
				chkischanged.Enabled = true;	
				// come il flag annulla del form principale quando si clicca su Mx e si salva il check rimane abilitato
				if (chkischanged.Checked )
				{
					chkischanged.Enabled = chkischanged.Checked;
					grbpagamento.Enabled  = chkischanged.Checked;
				}
			}
			else // Se non è Tx abilita tutti i gruppi 
			{	
				grbpagamento.Enabled  = ! chkischanged.Checked;
				chkischanged.Enabled = chkischanged.Checked;
			}

		}
		
		public void MetaData_AfterActivation()
		{
			DataRow ParentServiceregistry = Meta.SourceRow.Table.DataSet.Tables["serviceregistry"].Rows[0];
			txteser.Text = ParentServiceregistry["yservreg"].ToString();
			txtnum.Text = ParentServiceregistry["nservreg"].ToString();
		}
		
		public void MetaData_AfterFill()
		{
			gestioneFlag(); 
			chkisdelivery.Enabled = false;
			chkblocked.Enabled = false;
			lblpagamentoblocato.Visible = false;

			if (!Meta.InsertMode)
			{
				grbSemestre.Enabled= false;
				if (DS.servicepayment.Rows.Count == 0) return;
				DataRow Curr = DS.servicepayment.Rows[0];
				
//				chkblocked.Enabled = (Curr["is_blocked"].ToString().ToUpper()=="S"?true:false);
				lblpagamentoblocato.Visible = (Curr["is_blocked"].ToString().ToUpper()=="S"?true:false);

			}

		}

		private void chkischanged_CheckedChanged(object sender, System.EventArgs e)
		{
			if ((Meta!=null)&&Meta.DrawStateIsDone)
			{
				gestioneFlag();
			}
		}


	}
}
