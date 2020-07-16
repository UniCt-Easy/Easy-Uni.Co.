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

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using metaeasylibrary;
using metadatalibrary;

namespace expenseclawback_default//dettagliorecuperi//
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Frm_expenseclawback_default : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ComboBox cmbTipoRecupero;
		private System.Windows.Forms.Button btnRecupero;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtImporto;
		public vistaForm DS;
        private GroupBox grpF24EP;
        private Label label11;
        private GroupBox groupBox2;
        private Label label2;
        private ComboBox cmbMese1;
        private TextBox txtEsercizio1;
        private Label label3;
        private GroupBox groupBox3;
        private Label label10;
        private TextBox txtRifa;
        private Label label6;
        private ComboBox cmbMese;
        private TextBox txtEsercizio;
        private Label label7;
        private Label label9;
        private TextBox txtCode;
        private Label label8;
        private Label label5;
        private TextBox txtMarks;
        private ComboBox cmbTipo;
        private Label label4;
        private TextBox txtFiscalTaxCode;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_expenseclawback_default()
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
				if (components != null) 
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
            this.cmbTipoRecupero = new System.Windows.Forms.ComboBox();
            this.DS = new expenseclawback_default.vistaForm();
            this.btnRecupero = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtImporto = new System.Windows.Forms.TextBox();
            this.grpF24EP = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFiscalTaxCode = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbMese1 = new System.Windows.Forms.ComboBox();
            this.txtEsercizio1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtRifa = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbMese = new System.Windows.Forms.ComboBox();
            this.txtEsercizio = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMarks = new System.Windows.Forms.TextBox();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.grpF24EP.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbTipoRecupero
            // 
            this.cmbTipoRecupero.DataSource = this.DS.clawback;
            this.cmbTipoRecupero.DisplayMember = "description";
            this.cmbTipoRecupero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoRecupero.Location = new System.Drawing.Point(120, 16);
            this.cmbTipoRecupero.Name = "cmbTipoRecupero";
            this.cmbTipoRecupero.Size = new System.Drawing.Size(288, 21);
            this.cmbTipoRecupero.TabIndex = 15;
            this.cmbTipoRecupero.Tag = "expenseclawback.idclawback";
            this.cmbTipoRecupero.ValueMember = "idclawback";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // btnRecupero
            // 
            this.btnRecupero.BackColor = System.Drawing.SystemColors.Control;
            this.btnRecupero.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnRecupero.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRecupero.Location = new System.Drawing.Point(16, 16);
            this.btnRecupero.Name = "btnRecupero";
            this.btnRecupero.Size = new System.Drawing.Size(88, 23);
            this.btnRecupero.TabIndex = 14;
            this.btnRecupero.Tag = "manage.clawback.default";
            this.btnRecupero.Text = "Recupero";
            this.btnRecupero.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(474, 481);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 23);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Tag = "";
            this.btnCancel.Text = "Cancel";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(562, 481);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 18;
            this.btnOK.Tag = "mainsave";
            this.btnOK.Text = "OK";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(440, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "Importo:";
            // 
            // txtImporto
            // 
            this.txtImporto.Location = new System.Drawing.Point(504, 19);
            this.txtImporto.Name = "txtImporto";
            this.txtImporto.Size = new System.Drawing.Size(120, 20);
            this.txtImporto.TabIndex = 16;
            this.txtImporto.Tag = "expenseclawback.amount";
            // 
            // grpF24EP
            // 
            this.grpF24EP.Controls.Add(this.label4);
            this.grpF24EP.Controls.Add(this.txtFiscalTaxCode);
            this.grpF24EP.Controls.Add(this.label11);
            this.grpF24EP.Controls.Add(this.groupBox2);
            this.grpF24EP.Controls.Add(this.groupBox3);
            this.grpF24EP.Controls.Add(this.label9);
            this.grpF24EP.Controls.Add(this.txtCode);
            this.grpF24EP.Controls.Add(this.label8);
            this.grpF24EP.Controls.Add(this.label5);
            this.grpF24EP.Controls.Add(this.txtMarks);
            this.grpF24EP.Controls.Add(this.cmbTipo);
            this.grpF24EP.Location = new System.Drawing.Point(16, 45);
            this.grpF24EP.Name = "grpF24EP";
            this.grpF24EP.Size = new System.Drawing.Size(621, 415);
            this.grpF24EP.TabIndex = 20;
            this.grpF24EP.TabStop = false;
            this.grpF24EP.Text = "Intervento sostitutivo - Dettagli Versamento F24EP";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(455, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 20);
            this.label4.TabIndex = 41;
            this.label4.Text = "Codice Tributo";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFiscalTaxCode
            // 
            this.txtFiscalTaxCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFiscalTaxCode.Location = new System.Drawing.Point(458, 76);
            this.txtFiscalTaxCode.Name = "txtFiscalTaxCode";
            this.txtFiscalTaxCode.Size = new System.Drawing.Size(117, 20);
            this.txtFiscalTaxCode.TabIndex = 42;
            this.txtFiscalTaxCode.TabStop = false;
            this.txtFiscalTaxCode.Tag = "expenseclawback.fiscaltaxcode";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label11.Location = new System.Drawing.Point(15, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(465, 13);
            this.label11.TabIndex = 40;
            this.label11.Text = "I dati devono essere compilati secondo le indicazioni ricevute dall\'Ente Creditor" +
    "e";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cmbMese1);
            this.groupBox2.Controls.Add(this.txtEsercizio1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(17, 331);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(290, 73);
            this.groupBox2.TabIndex = 39;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Riferimento B (Termine del Periodo di Riferimento)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(107, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Mese";
            // 
            // cmbMese1
            // 
            this.cmbMese1.DataSource = this.DS.monthname2;
            this.cmbMese1.DisplayMember = "title";
            this.cmbMese1.FormattingEnabled = true;
            this.cmbMese1.Location = new System.Drawing.Point(110, 37);
            this.cmbMese1.Name = "cmbMese1";
            this.cmbMese1.Size = new System.Drawing.Size(154, 21);
            this.cmbMese1.TabIndex = 2;
            this.cmbMese1.Tag = "expenseclawback.rifb_month";
            this.cmbMese1.ValueMember = "code";
            // 
            // txtEsercizio1
            // 
            this.txtEsercizio1.Location = new System.Drawing.Point(13, 37);
            this.txtEsercizio1.Name = "txtEsercizio1";
            this.txtEsercizio1.Size = new System.Drawing.Size(76, 20);
            this.txtEsercizio1.TabIndex = 1;
            this.txtEsercizio1.TabStop = false;
            this.txtEsercizio1.Tag = "expenseclawback.rifb_year.year";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(10, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 16);
            this.label3.TabIndex = 27;
            this.label3.Text = "A Anno";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txtRifa);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.cmbMese);
            this.groupBox3.Controls.Add(this.txtEsercizio);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(18, 214);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(510, 107);
            this.groupBox3.TabIndex = 38;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Riferimento A (Inizio del Periodo di Riferimento o altra dicitura comunicata dall" +
    "\'Ente Creditore";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.Location = new System.Drawing.Point(23, 72);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 20);
            this.label10.TabIndex = 3;
            this.label10.Text = "Causale ";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRifa
            // 
            this.txtRifa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRifa.Location = new System.Drawing.Point(110, 73);
            this.txtRifa.Name = "txtRifa";
            this.txtRifa.Size = new System.Drawing.Size(154, 20);
            this.txtRifa.TabIndex = 4;
            this.txtRifa.TabStop = false;
            this.txtRifa.Tag = "expenseclawback.rifa";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(109, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Mese";
            // 
            // cmbMese
            // 
            this.cmbMese.DataSource = this.DS.monthname1;
            this.cmbMese.DisplayMember = "title";
            this.cmbMese.FormattingEnabled = true;
            this.cmbMese.Location = new System.Drawing.Point(112, 35);
            this.cmbMese.Name = "cmbMese";
            this.cmbMese.Size = new System.Drawing.Size(154, 21);
            this.cmbMese.TabIndex = 2;
            this.cmbMese.Tag = "expenseclawback.rifa_month";
            this.cmbMese.ValueMember = "code";
            // 
            // txtEsercizio
            // 
            this.txtEsercizio.Location = new System.Drawing.Point(15, 35);
            this.txtEsercizio.Name = "txtEsercizio";
            this.txtEsercizio.Size = new System.Drawing.Size(76, 20);
            this.txtEsercizio.TabIndex = 1;
            this.txtEsercizio.TabStop = false;
            this.txtEsercizio.Tag = "expenseclawback.rifa_year.year";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(12, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 16);
            this.label7.TabIndex = 25;
            this.label7.Text = "Da Anno ";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(14, 108);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(340, 23);
            this.label9.TabIndex = 37;
            this.label9.Text = "Codice (Sede INPS, Sede INAIL, ecc..)";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(14, 134);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(123, 20);
            this.txtCode.TabIndex = 34;
            this.txtCode.TabStop = false;
            this.txtCode.Tag = "expenseclawback.code";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(15, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 23);
            this.label8.TabIndex = 32;
            this.label8.Text = "Sezione";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(14, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(394, 23);
            this.label5.TabIndex = 36;
            this.label5.Text = "Estremi Identificativi (Matricola INPS, Cod. posizione assicurativa ecc..)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMarks
            // 
            this.txtMarks.Location = new System.Drawing.Point(18, 189);
            this.txtMarks.Name = "txtMarks";
            this.txtMarks.Size = new System.Drawing.Size(213, 20);
            this.txtMarks.TabIndex = 35;
            this.txtMarks.TabStop = false;
            this.txtMarks.Tag = "expenseclawback.identifying_marks";
            // 
            // cmbTipo
            // 
            this.cmbTipo.DataSource = this.DS.lookup_tiporigaf24ep;
            this.cmbTipo.DisplayMember = "description";
            this.cmbTipo.Location = new System.Drawing.Point(17, 76);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(265, 21);
            this.cmbTipo.TabIndex = 33;
            this.cmbTipo.Tag = "expenseclawback.tiporiga";
            this.cmbTipo.ValueMember = "tiporiga";
            // 
            // Frm_expenseclawback_default
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(649, 516);
            this.Controls.Add(this.grpF24EP);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtImporto);
            this.Controls.Add(this.cmbTipoRecupero);
            this.Controls.Add(this.btnRecupero);
            this.Name = "Frm_expenseclawback_default";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.grpF24EP.ResumeLayout(false);
            this.grpF24EP.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        MetaData Meta;
        QueryHelper QHS;
        public void MetaData_AfterLink()
        {
            Meta = MetaData.GetMetaData(this);
            QHS = Meta.Conn.GetQueryHelper();

            DataAccess.SetTableForReading(DS.monthname1, "monthname");
            DataAccess.SetTableForReading(DS.monthname2, "monthname");
            GetData.MarkToAddBlankRow(DS.monthname1);
            GetData.MarkToAddBlankRow(DS.monthname2);
            GetData.CacheTable(DS.monthname1);
            GetData.CacheTable(DS.monthname2);

            DataRow DR = Meta.SourceRow;
            DataRow ParentR = Meta.SourceRow.GetParentRow("clawbackexpenseclawback");
            DisabilitaTuttoPerSplit(ParentR);
        }


        public void MetaData_AfterFill()
        {
            DataRow DR = Meta.SourceRow;

            DataRow ParentR = Meta.SourceRow.GetParentRow("clawbackexpenseclawback");
            AbilitaControlliF24EP(ParentR);
           
        }

        public void MetaData_AfterRowSelect(DataTable T, DataRow R)
        {
            
            if (T.TableName == "clawback")
            {
                if (!Meta.DrawStateIsDone) return;
                AbilitaControlliF24EP(R);
                return;
            }
        }
        
        void DisabilitaTuttoPerSplit(DataRow R) {
            if (R == null)
                return;
            if (R["clawbackref"].ToString().ToUpper() == "15_SPLIT_PAYMENT" ||
                R["clawbackref"].ToString().ToUpper() == "16_SPLIT_PAYMENT_C") {
                    btnRecupero.Enabled = false;
                    cmbTipoRecupero.Enabled = false;
                    txtImporto.ReadOnly = true;
            }

        }


        void AbilitaControlliF24EP(DataRow R)
        {
            bool enabled = true;
            if (R == null) {
                enabled = false;
            }
            else {
                if ((R["flagf24ep"]) == DBNull.Value)
                    enabled = false;
                else
                    enabled = (R["flagf24ep"].ToString() == "S");
            }
            grpF24EP.Enabled = enabled;
            DataRow R1 = DS.expenseclawback.Rows[0];
            if (!enabled)
            {
                R1["tiporiga"] = DBNull.Value;
                cmbTipo.SelectedIndex = -1;

                R1["fiscaltaxcode"] = DBNull.Value;
                txtFiscalTaxCode.Text = "";
                R1["code"] = DBNull.Value;
                txtCode.Text = "";
                R1["identifying_marks"] = DBNull.Value;
                txtMarks.Text = "";
                R1["rifa"] = DBNull.Value;
                txtRifa.Text = "";
                R1["rifa_year"] = DBNull.Value;
                txtEsercizio.Text = "";
                R1["rifb_year"] = DBNull.Value;
                txtEsercizio1.Text = "";
                R1["rifa_month"] = DBNull.Value;
                cmbMese .SelectedIndex = -1;
                R1["rifb_month"] = DBNull.Value;
                cmbMese1.SelectedIndex = -1;
            }
        

        }

	}
}
