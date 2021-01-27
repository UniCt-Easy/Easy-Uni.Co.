
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


using System.Windows.Forms;
using metadatalibrary;

namespace webpayment_prenotazioni_default
{
    public class Frm_webpayment_prenotazioni_default : Form
	{
		MetaData Meta;
        public dsmeta DS;
        private Label label1;
        private TextBox txtCodPagamento;
        private TextBox txtEsercizio;
        private Label label2;
        private TextBox txtNumero;
        private Label label3;
        private ComboBox cmbStatoCorrente;
        private Label label4;
        private TextBox txtEmail;
        private Label label5;
        private TextBox txtCognome;
        private Label label6;
        private TextBox txtNome;
        private Label label7;
        private TextBox txtDenominazione;
        private TextBox txtPiva;
        private Label label10;
        private TextBox txtCF;
        private Label label11;
        private TextBox txtData;
        private Label label12;
		private GroupBox groupBox1;
		private GroupBox groupBox2;
        private DataGrid gridDettagli;
        private Button buttonEdit;
        private Label label8;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

		public Frm_webpayment_prenotazioni_default()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_webpayment_prenotazioni_default));
           
          
            InitializeComponent();
        }

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
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
			this.DS = new webpayment_prenotazioni_default.dsmeta();
			this.label1 = new System.Windows.Forms.Label();
			this.txtCodPagamento = new System.Windows.Forms.TextBox();
			this.txtEsercizio = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtNumero = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.cmbStatoCorrente = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtEmail = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtCognome = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtNome = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtDenominazione = new System.Windows.Forms.TextBox();
			this.txtPiva = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.txtCF = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.txtData = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.gridDettagli = new System.Windows.Forms.DataGrid();
			this.buttonEdit = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridDettagli)).BeginInit();
			((System.ComponentModel.ISupportInitialize) (this.DS)).BeginInit();
			this.SuspendLayout();
			this.DS.DataSetName = "dsmeta";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(83, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Cod.Pagamento";
			// 
			// txtCodPagamento
			// 
			this.txtCodPagamento.Location = new System.Drawing.Point(16, 32);
			this.txtCodPagamento.Name = "txtCodPagamento";
			this.txtCodPagamento.Size = new System.Drawing.Size(162, 20);
			this.txtCodPagamento.TabIndex = 1;
			this.txtCodPagamento.Tag = "webpayment.idwebpayment";
			// 
			// txtEsercizio
			// 
			this.txtEsercizio.Location = new System.Drawing.Point(194, 32);
			this.txtEsercizio.Name = "txtEsercizio";
			this.txtEsercizio.Size = new System.Drawing.Size(162, 20);
			this.txtEsercizio.TabIndex = 3;
			this.txtEsercizio.Tag = "webpayment.ywebpayment";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(190, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(49, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Esercizio";
			// 
			// txtNumero
			// 
			this.txtNumero.Location = new System.Drawing.Point(372, 32);
			this.txtNumero.Name = "txtNumero";
			this.txtNumero.Size = new System.Drawing.Size(162, 20);
			this.txtNumero.TabIndex = 5;
			this.txtNumero.Tag = "webpayment.nwebpayment";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(368, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(44, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Numero";
			// 
			// cmbStatoCorrente
			// 
			this.cmbStatoCorrente.DataSource = this.DS.webpaymentstatus;
			this.cmbStatoCorrente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbStatoCorrente.DisplayMember = "description";
			this.cmbStatoCorrente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbStatoCorrente.Location = new System.Drawing.Point(552, 32);
			this.cmbStatoCorrente.Name = "cmbStatoCorrente";
			this.cmbStatoCorrente.Size = new System.Drawing.Size(231, 21);
			this.cmbStatoCorrente.TabIndex = 7;
			this.cmbStatoCorrente.Tag = "webpaymentstatus.idwebpaymentstatus?webpayment_prenotazioniview.idwebpaymentstatu" +
    "s";
			this.cmbStatoCorrente.ValueMember = "idwebpaymentstatus";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(548, 9);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(75, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Stato Corrente";
			// 
			// txtEmail
			// 
			this.txtEmail.Location = new System.Drawing.Point(345, 165);
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.Size = new System.Drawing.Size(151, 20);
			this.txtEmail.TabIndex = 13;
			this.txtEmail.Tag = "registry.email_fe?webpayment_prenotazioniview.email_fe";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(341, 142);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(32, 13);
			this.label5.TabIndex = 12;
			this.label5.Text = "Email";
			// 
			// txtCognome
			// 
			this.txtCognome.Location = new System.Drawing.Point(335, 113);
			this.txtCognome.Name = "txtCognome";
			this.txtCognome.Size = new System.Drawing.Size(298, 20);
			this.txtCognome.TabIndex = 11;
			this.txtCognome.Tag = "registry.surname?webpayment_prenotazioniview.surname";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(331, 90);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(52, 13);
			this.label6.TabIndex = 10;
			this.label6.Text = "Cognome";
			// 
			// txtNome
			// 
			this.txtNome.Location = new System.Drawing.Point(11, 113);
			this.txtNome.Name = "txtNome";
			this.txtNome.Size = new System.Drawing.Size(298, 20);
			this.txtNome.TabIndex = 9;
			this.txtNome.Tag = "registry.forename?webpayment_prenotazioniview.forename";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(7, 90);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(35, 13);
			this.label7.TabIndex = 8;
			this.label7.Text = "Nome";
			// 
			// txtDenominazione
			// 
			this.txtDenominazione.Location = new System.Drawing.Point(6, 19);
			this.txtDenominazione.Name = "txtDenominazione";
			this.txtDenominazione.Size = new System.Drawing.Size(617, 20);
			this.txtDenominazione.TabIndex = 15;
			this.txtDenominazione.Tag = "registry.title?webpayment_prenotazioniview.title";
			// 
			// txtPiva
			// 
			this.txtPiva.Location = new System.Drawing.Point(177, 165);
			this.txtPiva.Name = "txtPiva";
			this.txtPiva.Size = new System.Drawing.Size(151, 20);
			this.txtPiva.TabIndex = 19;
			this.txtPiva.Tag = "registry.p_iva?webpayment_prenotazioniview.p_iva";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(173, 142);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(55, 13);
			this.label10.TabIndex = 18;
			this.label10.Text = "Partita Iva";
			// 
			// txtCF
			// 
			this.txtCF.Location = new System.Drawing.Point(11, 165);
			this.txtCF.Name = "txtCF";
			this.txtCF.Size = new System.Drawing.Size(151, 20);
			this.txtCF.TabIndex = 17;
			this.txtCF.Tag = "registry.cf?webpayment_prenotazioniview.cf";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(7, 142);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(76, 13);
			this.label11.TabIndex = 16;
			this.label11.Text = "Codice Fiscale";
			// 
			// txtData
			// 
			this.txtData.Location = new System.Drawing.Point(512, 165);
			this.txtData.Name = "txtData";
			this.txtData.Size = new System.Drawing.Size(121, 20);
			this.txtData.TabIndex = 23;
			this.txtData.Tag = "webpayment.adate";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(508, 149);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(30, 13);
			this.label12.TabIndex = 22;
			this.label12.Text = "Data";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.groupBox2);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.txtData);
			this.groupBox1.Controls.Add(this.txtNome);
			this.groupBox1.Controls.Add(this.label12);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.txtPiva);
			this.groupBox1.Controls.Add(this.txtCognome);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.txtCF);
			this.groupBox1.Controls.Add(this.txtEmail);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Location = new System.Drawing.Point(16, 70);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(766, 207);
			this.groupBox1.TabIndex = 24;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Anagrafica";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.txtDenominazione);
			this.groupBox2.Location = new System.Drawing.Point(10, 19);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(750, 59);
			this.groupBox2.TabIndex = 24;
			this.groupBox2.TabStop = false;
			this.groupBox2.Tag = "AutoChoose.txtDenominazione.default.(active=\'S\')";
			this.groupBox2.Text = "Denominazione";
			// 
			// gridDettagli
			// 
			this.gridDettagli.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gridDettagli.CaptionVisible = false;
			this.gridDettagli.DataMember = "";
			this.gridDettagli.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gridDettagli.Location = new System.Drawing.Point(107, 319);
			this.gridDettagli.Name = "gridDettagli";
			this.gridDettagli.Size = new System.Drawing.Size(676, 312);
			this.gridDettagli.TabIndex = 25;
			this.gridDettagli.Tag = "webpaymentdetail.list.single";
			// 
			// buttonEdit
			// 
			this.buttonEdit.Location = new System.Drawing.Point(15, 319);
			this.buttonEdit.Name = "buttonEdit";
			this.buttonEdit.Size = new System.Drawing.Size(75, 23);
			this.buttonEdit.TabIndex = 26;
			this.buttonEdit.Tag = "edit.single";
			this.buttonEdit.Text = "Visualizza";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(104, 293);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(43, 13);
			this.label8.TabIndex = 27;
			this.label8.Text = "Dettagli";
			// 
			// Frm_webpayment_prenotazioni_default
			// 
			this.ClientSize = new System.Drawing.Size(798, 643);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.buttonEdit);
			this.Controls.Add(this.gridDettagli);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.cmbStatoCorrente);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtNumero);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtEsercizio);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtCodPagamento);
			this.Controls.Add(this.label1);
			this.Name = "Frm_webpayment_prenotazioni_default";
			this.Text = "Pagamenti Web";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridDettagli)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
			((System.ComponentModel.ISupportInitialize) (this.DS)).EndInit();

		}

        #endregion

        CQueryHelper QHC;
        QueryHelper QHS;

		public void MetaData_AfterLink()
		{
			Meta = MetaData.GetMetaData(this);
			QHC = new CQueryHelper();
			QHS = Meta.Conn.GetQueryHelper();
        }
	}
}
