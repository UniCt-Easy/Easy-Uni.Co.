
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
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using ep_functions;
using funzioni_configurazione;

namespace paymenttransmission_generazioneautomatica {//trasmdocpagamento_gener_auto//
	/// <summary>
	/// Summary description for frmtrasmdocpagamento_gener_auto.
	/// Revised by Nino on 10/2/2003 (Removed 2 SqlRunner)
	/// </summary>
    public class Frm_paymenttransmission_generazioneautomatica : MetaDataForm
    {
		private System.Windows.Forms.GroupBox grpConferma;
		private System.Windows.Forms.Button btnNo;
		private System.Windows.Forms.Button btnSiTutti;
		private System.Windows.Forms.Button btnSi;
		private System.Windows.Forms.Button btnChiudi;
		private System.Windows.Forms.Button btnSuccessivo;
		private System.Windows.Forms.Button btnInizia;
		private System.Windows.Forms.DataGrid dgrDocumenti;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtData;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtNumero;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtEsercizio;
		private System.Windows.Forms.Label label1;
		public vistaForm DS;
		bool Started;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		MetaData Meta;
		DataTable TempTable = new DataTable("temptable");
		private System.Windows.Forms.ComboBox cmbResponsabile;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox4;
        private Button btnIstitutoCassiere;
        private ComboBox cmbCodiceIstituto;
        private GroupBox groupBox5;
        private CheckBox chkFlagSendMail;
        private GroupBox groupBox6;
        private CheckBox chkTransmissionKind;
        private ProgressBar progressBarImport;
        private Label lblNotifiche;
		bool flagtrasmresponsabile;
        private EP_Manager EPM;

        public Frm_paymenttransmission_generazioneautomatica() {
			InitializeComponent();
			Started=false;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if(components != null) {
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
		private void InitializeComponent() {
            this.grpConferma = new System.Windows.Forms.GroupBox();
            this.btnNo = new System.Windows.Forms.Button();
            this.btnSiTutti = new System.Windows.Forms.Button();
            this.btnSi = new System.Windows.Forms.Button();
            this.btnChiudi = new System.Windows.Forms.Button();
            this.btnSuccessivo = new System.Windows.Forms.Button();
            this.btnInizia = new System.Windows.Forms.Button();
            this.dgrDocumenti = new System.Windows.Forms.DataGrid();
            this.label7 = new System.Windows.Forms.Label();
            this.txtData = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEsercizio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DS = new paymenttransmission_generazioneautomatica.vistaForm();
            this.cmbResponsabile = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnIstitutoCassiere = new System.Windows.Forms.Button();
            this.cmbCodiceIstituto = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chkFlagSendMail = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.chkTransmissionKind = new System.Windows.Forms.CheckBox();
            this.progressBarImport = new System.Windows.Forms.ProgressBar();
            this.lblNotifiche = new System.Windows.Forms.Label();
            this.grpConferma.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrDocumenti)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpConferma
            // 
            this.grpConferma.Controls.Add(this.btnNo);
            this.grpConferma.Controls.Add(this.btnSiTutti);
            this.grpConferma.Controls.Add(this.btnSi);
            this.grpConferma.Enabled = false;
            this.grpConferma.Location = new System.Drawing.Point(288, 0);
            this.grpConferma.Name = "grpConferma";
            this.grpConferma.Size = new System.Drawing.Size(296, 48);
            this.grpConferma.TabIndex = 4;
            this.grpConferma.TabStop = false;
            this.grpConferma.Text = "Genera Distinta";
            // 
            // btnNo
            // 
            this.btnNo.Location = new System.Drawing.Point(88, 16);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(64, 23);
            this.btnNo.TabIndex = 74;
            this.btnNo.TabStop = false;
            this.btnNo.Tag = "unlink";
            this.btnNo.Text = "No";
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // btnSiTutti
            // 
            this.btnSiTutti.Location = new System.Drawing.Point(224, 16);
            this.btnSiTutti.Name = "btnSiTutti";
            this.btnSiTutti.Size = new System.Drawing.Size(64, 23);
            this.btnSiTutti.TabIndex = 73;
            this.btnSiTutti.TabStop = false;
            this.btnSiTutti.Text = "Sì tutti";
            this.btnSiTutti.Click += new System.EventHandler(this.btnSiTutti_Click);
            // 
            // btnSi
            // 
            this.btnSi.Location = new System.Drawing.Point(8, 16);
            this.btnSi.Name = "btnSi";
            this.btnSi.Size = new System.Drawing.Size(64, 23);
            this.btnSi.TabIndex = 72;
            this.btnSi.TabStop = false;
            this.btnSi.Text = "Sì";
            this.btnSi.Click += new System.EventHandler(this.btnSi_Click);
            // 
            // btnChiudi
            // 
            this.btnChiudi.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnChiudi.Location = new System.Drawing.Point(184, 16);
            this.btnChiudi.Name = "btnChiudi";
            this.btnChiudi.Size = new System.Drawing.Size(80, 23);
            this.btnChiudi.TabIndex = 105;
            this.btnChiudi.TabStop = false;
            this.btnChiudi.Text = "Termina";
            this.btnChiudi.Click += new System.EventHandler(this.btnChiudi_Click);
            // 
            // btnSuccessivo
            // 
            this.btnSuccessivo.Enabled = false;
            this.btnSuccessivo.Location = new System.Drawing.Point(96, 16);
            this.btnSuccessivo.Name = "btnSuccessivo";
            this.btnSuccessivo.Size = new System.Drawing.Size(80, 23);
            this.btnSuccessivo.TabIndex = 104;
            this.btnSuccessivo.TabStop = false;
            this.btnSuccessivo.Text = "Prossimo >>";
            this.btnSuccessivo.Click += new System.EventHandler(this.btnSuccessivo_Click);
            // 
            // btnInizia
            // 
            this.btnInizia.Location = new System.Drawing.Point(8, 16);
            this.btnInizia.Name = "btnInizia";
            this.btnInizia.Size = new System.Drawing.Size(80, 23);
            this.btnInizia.TabIndex = 103;
            this.btnInizia.TabStop = false;
            this.btnInizia.Text = "Inizia Ricerca";
            this.btnInizia.Click += new System.EventHandler(this.btnInizia_Click);
            // 
            // dgrDocumenti
            // 
            this.dgrDocumenti.AllowNavigation = false;
            this.dgrDocumenti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrDocumenti.DataMember = "";
            this.dgrDocumenti.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgrDocumenti.Location = new System.Drawing.Point(8, 16);
            this.dgrDocumenti.Name = "dgrDocumenti";
            this.dgrDocumenti.ReadOnly = true;
            this.dgrDocumenti.Size = new System.Drawing.Size(364, 311);
            this.dgrDocumenti.TabIndex = 102;
            this.dgrDocumenti.Tag = "payment.elencoautomatico";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(8, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(144, 16);
            this.label7.TabIndex = 101;
            this.label7.Text = "Responsabile della distinta:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(120, 16);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(144, 20);
            this.txtData.TabIndex = 2;
            this.txtData.Tag = "paymenttransmission.transmissiondate?paymenttransmissionview.transmissiondate";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 16);
            this.label3.TabIndex = 99;
            this.label3.Text = "Data trasmissione:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNumero);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtEsercizio);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 53);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Distinta di trasmissione";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(208, 24);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(56, 20);
            this.txtNumero.TabIndex = 1;
            this.txtNumero.Tag = "paymenttransmission.npaymenttransmission?paymenttransmissionview.npaymenttransmis" +
    "sion";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(144, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Numero:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercizio
            // 
            this.txtEsercizio.Location = new System.Drawing.Point(80, 24);
            this.txtEsercizio.Name = "txtEsercizio";
            this.txtEsercizio.ReadOnly = true;
            this.txtEsercizio.Size = new System.Drawing.Size(56, 20);
            this.txtEsercizio.TabIndex = 1;
            this.txtEsercizio.TabStop = false;
            this.txtEsercizio.Tag = "paymenttransmission.ypaymenttransmission?paymenttransmissionview.ypaymenttransmis" +
    "sion";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Esercizio:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // cmbResponsabile
            // 
            this.cmbResponsabile.DataSource = this.DS.manager;
            this.cmbResponsabile.DisplayMember = "title";
            this.cmbResponsabile.Enabled = false;
            this.cmbResponsabile.Location = new System.Drawing.Point(8, 111);
            this.cmbResponsabile.Name = "cmbResponsabile";
            this.cmbResponsabile.Size = new System.Drawing.Size(256, 21);
            this.cmbResponsabile.TabIndex = 3;
            this.cmbResponsabile.Tag = "paymenttransmission.idman";
            this.cmbResponsabile.ValueMember = "idman";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnIstitutoCassiere);
            this.groupBox2.Controls.Add(this.cmbCodiceIstituto);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cmbResponsabile);
            this.groupBox2.Controls.Add(this.txtData);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(8, 104);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(272, 141);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dati Contabili";
            // 
            // btnIstitutoCassiere
            // 
            this.btnIstitutoCassiere.Location = new System.Drawing.Point(8, 42);
            this.btnIstitutoCassiere.Name = "btnIstitutoCassiere";
            this.btnIstitutoCassiere.Size = new System.Drawing.Size(80, 24);
            this.btnIstitutoCassiere.TabIndex = 103;
            this.btnIstitutoCassiere.TabStop = false;
            this.btnIstitutoCassiere.Tag = "choose.treasurer.lista";
            this.btnIstitutoCassiere.Text = "Cassiere:";
            this.btnIstitutoCassiere.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbCodiceIstituto
            // 
            this.cmbCodiceIstituto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCodiceIstituto.DataSource = this.DS.treasurer;
            this.cmbCodiceIstituto.DisplayMember = "description";
            this.cmbCodiceIstituto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCodiceIstituto.Location = new System.Drawing.Point(8, 70);
            this.cmbCodiceIstituto.Name = "cmbCodiceIstituto";
            this.cmbCodiceIstituto.Size = new System.Drawing.Size(254, 21);
            this.cmbCodiceIstituto.TabIndex = 102;
            this.cmbCodiceIstituto.Tag = "paymenttransmission.idtreasurer";
            this.cmbCodiceIstituto.ValueMember = "idtreasurer";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnChiudi);
            this.groupBox3.Controls.Add(this.btnSuccessivo);
            this.groupBox3.Controls.Add(this.btnInizia);
            this.groupBox3.Location = new System.Drawing.Point(8, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(271, 48);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Operazioni";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.dgrDocumenti);
            this.groupBox4.Location = new System.Drawing.Point(288, 48);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(380, 335);
            this.groupBox4.TabIndex = 103;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Mandati inclusi nella distinta di trasmissione";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.chkFlagSendMail);
            this.groupBox5.Location = new System.Drawing.Point(10, 253);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(270, 46);
            this.groupBox5.TabIndex = 104;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Notifiche";
            // 
            // chkFlagSendMail
            // 
            this.chkFlagSendMail.AutoSize = true;
            this.chkFlagSendMail.Location = new System.Drawing.Point(9, 19);
            this.chkFlagSendMail.Name = "chkFlagSendMail";
            this.chkFlagSendMail.Size = new System.Drawing.Size(122, 17);
            this.chkFlagSendMail.TabIndex = 82;
            this.chkFlagSendMail.Tag = "";
            this.chkFlagSendMail.Text = "Invia Notifiche Email";
            this.chkFlagSendMail.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.chkTransmissionKind);
            this.groupBox6.Location = new System.Drawing.Point(8, 347);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(271, 36);
            this.groupBox6.TabIndex = 105;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Tipo elenco";
            // 
            // chkTransmissionKind
            // 
            this.chkTransmissionKind.AutoSize = true;
            this.chkTransmissionKind.Enabled = false;
            this.chkTransmissionKind.Location = new System.Drawing.Point(66, 13);
            this.chkTransmissionKind.Name = "chkTransmissionKind";
            this.chkTransmissionKind.Size = new System.Drawing.Size(190, 17);
            this.chkTransmissionKind.TabIndex = 82;
            this.chkTransmissionKind.Tag = "paymenttransmission.transmissionkind:V:I";
            this.chkTransmissionKind.Text = "Elenco di Variazioni e Annullamenti";
            this.chkTransmissionKind.UseVisualStyleBackColor = true;
            // 
            // progressBarImport
            // 
            this.progressBarImport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarImport.Location = new System.Drawing.Point(8, 322);
            this.progressBarImport.Name = "progressBarImport";
            this.progressBarImport.Size = new System.Drawing.Size(275, 19);
            this.progressBarImport.TabIndex = 106;
            this.progressBarImport.Visible = false;
            // 
            // lblNotifiche
            // 
            this.lblNotifiche.Location = new System.Drawing.Point(8, 302);
            this.lblNotifiche.Name = "lblNotifiche";
            this.lblNotifiche.Size = new System.Drawing.Size(271, 16);
            this.lblNotifiche.TabIndex = 107;
            this.lblNotifiche.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Frm_paymenttransmission_generazioneautomatica
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(678, 391);
            this.Controls.Add(this.lblNotifiche);
            this.Controls.Add(this.progressBarImport);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpConferma);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_paymenttransmission_generazioneautomatica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmtrasmdocpagamento_gener_auto";
            this.grpConferma.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrDocumenti)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		public void MetaData_AfterFill(){
			CalcButtons();
		}

		public void MetaData_AfterClear(){
			CalcButtons();
		}
        QueryHelper QHS;
        CQueryHelper QHC;
        int esercizio;

		public void MetaData_AfterLink(){
			Meta=MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
            string filterEsercizio = QHS.CmpEq("ayear", esercizio);
            GetData.CacheTable(DS.config, filterEsercizio, null, false);
			GetData.CacheTable(DS.accountkind);
            GetData.CacheTable(DS.tax, null, null, false);
            HelpForm.SetAllowMultiSelection(DS.payment, true);
            btnIstitutoCassiere.Enabled = false;
            cmbCodiceIstituto.Enabled = false;
            HelpForm.SetDenyNull(DS.paymenttransmission.Columns["transmissionkind"], true);
            EPM = new EP_Manager(Meta, null, null, null, null, null, null, null, null, "paymenttransmission");

        }

        string emaildep = "";
		public void MetaData_AfterActivation(){
			CalcButtons();
            byte paymentFlag = (byte)DS.config.Rows[0]["payment_flag"];
            emaildep = DS.config.Rows[0]["email"].ToString();
            flagtrasmresponsabile = (paymentFlag & 1) == 1;
			impostaColoreBottoni();
		}

		public void MetaData_AfterPost() {
            DataRow curr = DS.paymenttransmission.Rows[0];
		    if (EPM.abilitaScritture(curr)) {
		        EPM.generaScritture();
		    }
		}

        bool sent = false;
        public void MetaData_BeforePost()
        {
            if (chkFlagSendMail.Checked)
            {
                sent = false;
                SendNotification();
                SendNotificationDisp();
                DataRow curr = DS.paymenttransmission.Rows[0];
                if (sent)
                {
                    MetaFactory.factory.getSingleton<IMessageShower>().Show("Notifiche inviate");
                    sent = false;
                    curr["flagmailsent"] = "S";
                    Meta.DoMainCommand("mainsave");
                }
            }
           
        }

        private void SendNotification() {
            if (DS.paymenttransmission.Rows.Count == 0) return;
            if (DS.payment.Rows.Count == 0) return;
            string MsgBody = "";
            string MsgNotes = " ";
            string MsgHeader = " ";
            string filtroMandati = QHC.IsNotNull("kpaymenttransmission");
            DataRow[] rMandati = DS.payment.Select(filtroMandati);

            object idtreasurer;
            idtreasurer = DS.paymenttransmission.Rows[0]["idtreasurer"];
            // costruisco la stringa dei mandati interessati
            string filtermand = "";

            DataTable tLicenza = Meta.Conn.RUN_SELECT("license", null, null, null, null, true);
            DataRow rLicenza = tLicenza.Rows[0];
            DataTable TTreasurer = Meta.Conn.RUN_SELECT("treasurer", "*", null, QHS.CmpEq("idtreasurer", idtreasurer),
                null, false);
            DataRow RTreasurer = TTreasurer.Rows[0];

            foreach (DataRow Mandato in rMandati) {
                if (Mandato["kpaymenttransmission", DataRowVersion.Original] == DBNull.Value)
                    filtermand = QHS.CmpEq("kpay", Mandato["kpay"]);
                else continue;
                DataTable TDisp = Meta.Conn.RUN_SELECT("paydispositionview", "*", null, filtermand, null, false);
 
                if (TDisp.Rows.Count > 0) continue;

                DataTable T = Meta.Conn.RUN_SELECT("expenselastview", "*", null, filtermand, null, false);

                if (T == null || T.Rows.Count == 0) continue;

                progressBarImport.Visible = true;
                progressBarImport.Value = 0;
                progressBarImport.Maximum = T.Rows.Count;
                lblNotifiche.Text = "Invio notifiche in corso per Mandato n° " + Mandato["npay"];

                // Ciclo sui beneficiari delle righe di mandato
                foreach (DataRow rExp in T.Rows) {
                    if (progressBarImport.Value < progressBarImport.Maximum) progressBarImport.Value++;
                    Application.DoEvents();
                    object idreg = rExp["idreg"];
                    object description = rExp["description"];
                    object registry = rExp["registry"];
                    object paymentadate = rExp["paymentadate"];
                    object npay = rExp["npay"];
                    object ypay = rExp["ypay"];
                    decimal amount = CfgFn.GetNoNullDecimal(rExp["amount"]);
                    object doc = rExp["doc"];
                    object docdate = rExp["docdate"];


                    decimal linkedIncome = CfgFn.GetNoNullDecimal(Meta.Conn.DO_SYS_CMD(
                        "SELECT sum(IIT.curramount) from 		income II with (nolock) " +
                        " join incometotal IIT  with (nolock)  on II.idinc=IIT.idinc and IIT.ayear=" +
                        QHS.quote(Meta.Conn.GetEsercizio()) +
                        " join incomelast IL with (nolock) on IL.idinc=II.idinc " +
                        "WHERE II.idpayment = " + QHS.quote(rExp["idexp"]) + " AND " +
                        "((II.autokind=4 and II.idreg = " + QHS.quote(idreg) + ") or II.autokind in (6,14,20,21)) ",
                        true));

                    amount -= linkedIncome;

                    string doc_docdate = "";
                    if ((doc != DBNull.Value) && (doc != null)) {
                        doc_docdate = " Documento collegato: " + doc.ToString();

                        if ((docdate != DBNull.Value) && (docdate != null))
                            doc_docdate += " del " + ((DateTime) docdate).ToShortDateString();

                        doc_docdate += ".\r\n";
                    }

                    string filterReference = QHS.AppAnd(QHS.CmpEq("idreg", idreg), QHS.CmpEq("flagdefault", "S"));
                    DataTable TReference =
                        Meta.Conn.RUN_SELECT("registryreference", "*", null, filterReference, null, false);

                    if (TReference == null || TReference.Rows.Count == 0) continue;

                    string mailto = TReference.Rows[0]["email"].ToString();
                    bool avviso_errore = false;
                    if (mailto == "") avviso_errore = true;
                    if (avviso_errore && emaildep == "") continue;

                    DataTable Tpaymethod = Meta.Conn.RUN_SELECT("paymethod", "*", null,
                        QHS.CmpEq("idpaymethod", rExp["idpaymethod"]), null, false);
                    DataRow Rpaymethod = Tpaymethod.Rows[0];


                    MsgHeader = "";
                    if (avviso_errore) MsgHeader = "EMAIL NON INVIATA per assenza di indirizzo email\r\n";

                    if (RTreasurer["idbank"].ToString() == "03067") {
                        MsgHeader += " Si informa che presso l'Istituto cassiere di questa Università, " + "\r\n" +
                                     " in tutte le agenzie e filiali di Banca CARIME S.P.A., " + "\r\n";
                    }
                    else {
                        MsgHeader += " Si informa che presso il servizio di Cassa di questa Università: " + "\r\n" +
                                     rLicenza["agencyname"] + " - " + rLicenza["departmentname"] + "\r\n";
                    }


                    MsgBody = MsgHeader +
                              " è in pagamento per il Beneficiario " + registry + " \r\n" +
                              " il Mandato numero " + npay.ToString() + " relativo all'esercizio " + ypay.ToString() +
                              "\r\n" +
                              " del " + ((DateTime) paymentadate).ToShortDateString() + ".\r\n" +
                              " Modalità di pagamento: " + Rpaymethod["description"] + "\r\n" +
                              " Causale del pagamento: " + description.ToString() + ".\r\n" +
                              doc_docdate +
                              " Importo del pagamento: " + CfgFn.GetNoNullDecimal(amount).ToString("c") +
                              ".\r\n" +
                              "\r\n" +
                              "\r\n" +
                              "\r\n";

                    MsgNotes = RTreasurer["annotations"].ToString();

                    foreach (DataColumn C in RTreasurer.Table.Columns) {
                        MsgNotes = MsgNotes.Replace("<%" + C.ColumnName + "%>", RTreasurer[C.ColumnName].ToString());
                    }

                    MsgBody += MsgNotes;

                    SendMail SM = new SendMail();
                    SM.UseSMTPLoginAsFromField = true;
                    if (avviso_errore) {
                        SM.Subject = "MAIL NON INVIATA: Emissione Mandato di Pagamento n° " + npay.ToString() + "/" +
                                     ypay.ToString();
                        SM.To = emaildep;
                    }
                    else {
                        SM.Subject = "Emissione Mandato di Pagamento n° " + npay.ToString() + "/" + ypay.ToString();
                        SM.To = mailto;
                        if (emaildep != "") SM.Cc = emaildep;
                    }

                    SM.MessageBody = MsgBody;
                    SM.Conn = Meta.Conn;
                    //if (SM.NoConfig == false) continue;
                    if (!SM.Send()) {
                        if (SM.ErrorMessage.Trim() != "")
                            MetaFactory.factory.getSingleton<IMessageShower>().Show(SM.ErrorMessage, "Errore");
                    }
                    else sent = true;
                }

                progressBarImport.Value = 0;
                progressBarImport.Visible = false;
                lblNotifiche.Text = "";
            }
        }

        private void SendNotificationDisp()
        {
            if (DS.paymenttransmission.Rows.Count == 0) return;
            if (DS.payment.Rows.Count == 0) return;
            string MsgBody = "";
            string MsgNotes = "";
            string MsgHeader = "";

            string filtroMandati = QHC.IsNotNull("kpaymenttransmission"); 
            DataRow[] rMandati = DS.payment.Select(filtroMandati);

            DataTable TTreasurer = Meta.Conn.RUN_SELECT("treasurer", "*", null, QHS.CmpEq("idtreasurer", DS.paymenttransmission.Rows[0]["idtreasurer"]), null, false);
            DataRow RTreasurer = TTreasurer.Rows[0];

            DataTable tLicenza = Meta.Conn.RUN_SELECT("license", null, null, null, null, true);
            DataRow rLicenza = tLicenza.Rows[0];
           
            // costruisco la stringa dei mandati interessati
            string filtermand = "";
            string filter = "";
            foreach (DataRow Mandato in rMandati)
            {
                if (Mandato["kpaymenttransmission", DataRowVersion.Original] == DBNull.Value)
                    filtermand = QHS.CmpEq("kpay", Mandato["kpay"]);
                else continue;

				// Ci sono ora due modalità di generazione mandati per le disposizioni di pagamento
				//1) Mandato singolo associato alla disposizione, unico pagamento cumulativo su Anagrafica "Studenti Diversi"
				//2) Più mandati corrispondenti alle liquidazioni generate singolarmente sui dettagli mediante wizard
				filtermand = QHS.CmpEq("kpay", Mandato["kpay"]);
				filter = QHS.AppAnd(QHS.CmpGt("amount", 0), filtermand);

				DataTable T = Meta.Conn.RUN_SELECT("paydispositionview", "*", null, filtermand, null, false);
				DataTable TDetails = Meta.Conn.RUN_SELECT("paydispositiondetailview", "*", null, filter, null, false);

				if (T == null || T.Rows.Count == 0) {
					// Mandati su liquidazion
					filtermand = QHS.CmpEq("kpaydett", Mandato["kpay"]);
					filter = QHS.AppAnd(QHS.CmpGt("amount", 0), filtermand);
					TDetails = Meta.Conn.RUN_SELECT("paydispositiondetailview", "*", null, filter, null, false);
				}

				if ((TDetails == null) || (TDetails.Rows.Count == 0)) continue;

				progressBarImport.Visible = true;
                progressBarImport.Value = 0;
                progressBarImport.Maximum = T.Rows.Count;
                lblNotifiche.Text = "Invio notifiche in corso per Mandato n° " + Mandato["npay"];
                
                // Ciclo sui beneficiari della disposizione di pagamento
                foreach (DataRow rDispDetailsRow in TDetails.Rows)
                {
                    if (progressBarImport.Value < progressBarImport.Maximum) progressBarImport.Value++;
                    Application.DoEvents();
                    object description = rDispDetailsRow["maindescription"];
                    object surname = rDispDetailsRow["surname"];
                    object forename = rDispDetailsRow["forename"];
                    object title = rDispDetailsRow["title"];
                    object paymentadate = Mandato["adate"];
                    object npay = Mandato["npay"];
                    object ypay = Mandato["ypay"];
                    object amount = rDispDetailsRow["amount"];
                    object iban = rDispDetailsRow["iban"];

                    string ModPagamento = "";
                    if (iban != DBNull.Value){
                        ModPagamento = "Bonifico";
                    }
                    else{
                        ModPagamento = "Per Cassa";
                    }

                    string registry = "";
                    if (title != DBNull.Value)
                        registry = title.ToString();
                    else
                    {
                        if (surname != DBNull.Value)
                        {
                            registry = surname.ToString();
                        }
                        if (forename != DBNull.Value)
                        {
                            registry = registry + " " + forename.ToString();
                        }
                    }
               
                    string mailto = rDispDetailsRow["email"].ToString();
                    if (mailto == "") continue;

                    if (RTreasurer["idbank"].ToString() == "03067")
                    {
                        MsgHeader = " Si informa che presso l'Istituto cassiere di questa Università, " + "\r\n" +
                             " in tutte le agenzie e filiali di Banca CARIME S.P.A., " + "\r\n";
                    }
                    else
                    {
                        MsgHeader = " Si informa che presso il servizio di Cassa di questa Università: " + "\r\n" +
                        rLicenza["agencyname"] + " - " + rLicenza["departmentname"] + "\r\n";
                    }
                    string causale = rDispDetailsRow["motive"].ToString();
                    if (causale == "") causale = rDispDetailsRow["mainmotive"].ToString();
                    causale += "\r\n";

                    MsgBody = MsgHeader  +
                              " è in pagamento per il Beneficiario " + registry + " \r\n" +
                              " il Mandato numero " + npay.ToString() + " relativo all'esercizio " + ypay.ToString() + "\r\n" +
                              " del " + ((DateTime)paymentadate).ToShortDateString() + ".\r\n" +
                              " Modalità di pagamento: " + ModPagamento + "\r\n" +
                              " Causale del pagamento: " + description.ToString() + ".\r\n" +causale+
                              " Importo del pagamento: " + CfgFn.GetNoNullDecimal(amount).ToString("c") + 
                              ".\r\n" +
                              "\r\n" +
                              "\r\n" +
                              "\r\n";

                    MsgNotes = RTreasurer["annotations"].ToString();

                    foreach (DataColumn C in RTreasurer.Table.Columns)
                    {
                        MsgNotes = MsgNotes.Replace("<%" + C.ColumnName + "%>", RTreasurer[C.ColumnName].ToString());
                    }


                    MsgBody += MsgNotes;

                    SendMail SM = new SendMail();
                    SM.UseSMTPLoginAsFromField = true;
                    SM.To = mailto;
                    if (emaildep != "") SM.Cc = emaildep;
                    SM.Subject = "Emissione Mandato di Pagamento n° " + npay.ToString() + "/" + ypay.ToString();
                    SM.MessageBody = MsgBody;
                    SM.Conn = Meta.Conn;
                    //if (SM.NoConfig == false) continue;
                    if (!SM.Send())
                    {
                        if (SM.ErrorMessage.Trim() != "")
                            MetaFactory.factory.getSingleton<IMessageShower>().Show(SM.ErrorMessage, "Errore");
                    }
                    else sent = true;
                }
                progressBarImport.Value = 0;
                progressBarImport.Visible = false;
                lblNotifiche.Text = "";
            }
        }

		private void impostaColoreBottoni() {
			btnInizia.BackColor = formcolors.GridButtonBackColor();
			btnInizia.ForeColor = formcolors.GridButtonForeColor();
			btnSuccessivo.BackColor = formcolors.GridButtonBackColor();
			btnSuccessivo.ForeColor = formcolors.GridButtonForeColor();
			btnChiudi.BackColor = formcolors.GridButtonBackColor();
			btnChiudi.ForeColor = formcolors.GridButtonForeColor();
			btnSi.BackColor = formcolors.GridButtonBackColor();
			btnSi.ForeColor = formcolors.GridButtonForeColor();
			btnSiTutti.BackColor = formcolors.GridButtonBackColor();
			btnSiTutti.ForeColor = formcolors.GridButtonForeColor();
		}

		private void FillTempTable(){
			string ParteSelect,  ParteWhere, ParteGroupBy, ParteOrderBy;

    		ParteSelect="idtreasurer";
            ParteWhere = QHS.AppAnd(QHS.IsNull("kpaymenttransmission"), 
                            QHS.IsNotNull("printdate"), QHS.CmpEq("ypay", esercizio));
            object idflowchart = Meta.GetSys("idflowchart");
            if (idflowchart != null && idflowchart != DBNull.Value) {
                //La persona appartiene all'organigramma
                if (DS.treasurer.Rows.Count == 1) {
                    ParteWhere = GetData.MergeFilters(ParteWhere, QHS.CmpEq("idtreasurer", DS.treasurer.Rows[0]["idtreasurer"]));
                }
                else {
                    string listaTreasurer = QHS.DistinctVal(DS.treasurer.Select(), "idtreasurer");
                    ParteWhere = GetData.MergeFilters(ParteWhere, QHS.CmpNe("idtreasurer", 0));
                    ParteWhere = GetData.MergeFilters(ParteWhere, QHS.FieldInList("idtreasurer", listaTreasurer));
                }
            }
			ParteGroupBy="idtreasurer";
			ParteOrderBy="idtreasurer ASC";

			if (flagtrasmresponsabile){
				ParteSelect+=", idman ";
				ParteGroupBy+=", idman ";
				ParteOrderBy+=", idman ASC ";
			}
			TempTable = Meta.Conn.RUN_SELECT("payment",ParteSelect,ParteOrderBy,ParteWhere, null, ParteGroupBy, true);
		}
			

		private void CollegaRigheADocumento(){
			if (TempTable.Rows.Count==0){
				MetaFactory.factory.getSingleton<IMessageShower>().Show("Non ci sono mandati di pagamento da elaborare");
				btnSuccessivo.Enabled=false;
				grpConferma.Enabled=false;
				return;
			}
			//MetaData.GetFormData(this,true);
			//Meta.Conn.sys["esercizio"].ToString();
			int eserccorrente=esercizio;
			string condizioniaggiuntive="";

			object codiceistituto = TempTable.Rows[0]["idtreasurer"];
			MetaData.SetDefault(DS.paymenttransmission, "idtreasurer", codiceistituto);

            condizioniaggiuntive = QHS.AppAnd(condizioniaggiuntive, QHS.CmpEq("idtreasurer", codiceistituto));



			if (flagtrasmresponsabile){
				object codiceresponsabile = TempTable.Rows[0]["idman"];
				MetaData.SetDefault(DS.paymenttransmission, "idman", codiceresponsabile);
                condizioniaggiuntive = QHS.AppAnd(condizioniaggiuntive, QHS.CmpEq("idman", codiceresponsabile));    
			}
			else {
				MetaData.SetDefault(DS.paymenttransmission, "idman", DBNull.Value);
			}
			MetaData.GetMetaData(this).EditNew();
			
			DS.payment.Clear();
            string MyFilter = QHS.AppAnd(QHS.IsNull("kpaymenttransmission"), 
                            QHS.IsNotNull("printdate"), QHS.CmpEq("ypay", esercizio),condizioniaggiuntive);

			DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn,DS.payment, 
				"ypay ASC, npay ASC",
				MyFilter,
				null,
				true);

			GetData.DenyClear(DS.payment);
			MetaData.GetFormData(this, true);
			MetaData.FreshForm(this, false);
			int max=DS.payment.Rows.Count;
			for (int i=0; i<max; i++){
				dgrDocumenti.Select(i);
			}
			CalcButtons();
		}

		void CalcButtons(){
			btnInizia.Enabled=(Started==false);
			int righe_da_collegare = DS.payment.Select(QHC.IsNull("kpaymenttransmission")).Length;
			grpConferma.Enabled= Started && (TempTable.Rows.Count>0) &&(righe_da_collegare>0);
			//btnSuccessivo.Enabled= Started&&(TempTable.Rows.Count>=0) &&(righe_da_collegare==0);
		}

		private void btnSuccessivo_Click(object sender, System.EventArgs e) {
			CollegaRigheADocumento();
			CalcButtons();
			btnSuccessivo.Enabled=false;
			if (TempTable.Rows.Count==0) Meta.DontWarnOnInsertCancel=true;
		}
	
		private void btnNo_Click(object sender, System.EventArgs e) {
			if (TempTable.Rows.Count > 0){
				DS.payment.AcceptChanges();
				TempTable.Rows.RemoveAt(0);
				TempTable.AcceptChanges();
				MetaData.FreshForm(this, true);
			}
			grpConferma.Enabled=false;
			btnSuccessivo.Enabled=true;
			//CalcButtons();
		}

		private void btnSi_Click(object sender, System.EventArgs e) {
			bool res=accettaDocumento(false); //<-
			if (res) {
				grpConferma.Enabled=false;
				btnSuccessivo.Enabled=true;
			}
			//CalcButtons();
		}

		private void btnInizia_Click(object sender, System.EventArgs e) {
			FillTempTable();
			CollegaRigheADocumento();
			Started=true;
			CalcButtons();
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="all">TRUE: Se premuto il bottone Si,Tutti FALSE: Altrimenti</param>
		private bool accettaDocumento(bool all) {
			bool success=true;
			int gridrowsnumber=DS.payment.Rows.Count;
			int i;
			int keyelenco=CfgFn.GetNoNullInt32(DS.paymenttransmission.Rows[0]["kpaymenttransmission"]);
			for(i=0; i<gridrowsnumber; i++) {
				if(dgrDocumenti.IsSelected(i)) {
                    string filter = QHC.AppAnd(QHC.CmpEq("ypay", dgrDocumenti[i, 0]), QHC.CmpEq("npay", dgrDocumenti[i, 1]));
					DataRow [] selrow = DS.payment.Select(filter);					
					selrow[0]["kpaymenttransmission"]=keyelenco;
				}
			}
			MetaData.DoMainCommand(this, "mainsave");
			if (all || !DS.HasChanges()) {
				TempTable.Rows.RemoveAt(0);
				TempTable.AcceptChanges();
				success=true;
			}
			else {
				success=false;
			}
			return success;
			//CalcButtons();
		}

		

		

		private void btnSiTutti_Click(object sender, System.EventArgs e) {
			while (TempTable.Rows.Count > 0) {
				bool esito = accettaDocumento(true);
				if (!esito) 	break;
				CollegaRigheADocumento();
				//MetaData.FreshForm(this, true);
			}	
			CalcButtons();
			Meta.DontWarnOnInsertCancel=true;
		}

		private void btnChiudi_Click(object sender, System.EventArgs e) {
			if (DS.payment.Rows.Count==0) DS.paymenttransmission.AcceptChanges();
		}
	}
}
