
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

namespace proceedstransmission_generazioneautomatica {//trasmdocincasso_gener_auto//
	/// <summary>
	/// Summary description for frmtrasmdocincasso_gener_auto.
	/// Author: Leo, start 12 Dec 2002 end 13 Dec 2002
	/// Revised By NIno on 9/2/2003 (removed 2 SqlDataAdapters)
	/// </summary>
	public class Frm_proceedstransmission_generazioneautomatica : System.Windows.Forms.Form {
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtNumero;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtEsercizio;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox grpConferma;
		private System.Windows.Forms.Button btnNo;
		private System.Windows.Forms.Button btnSiTutti;
		private System.Windows.Forms.Button btnSi;
		private System.Windows.Forms.Button btnChiudi;
		private System.Windows.Forms.Button btnSuccessivo;
        private System.Windows.Forms.Button btnInizia;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		MetaData Meta;
		DataTable TempTable = new DataTable("temptable");
		public vistaForm DS;
		private System.Windows.Forms.DataGrid dgrDocumenti;
		private System.Windows.Forms.TextBox txtData;
		bool flagtrasmresponsabile;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox4;
        private Button btnIstitutoCassiere;
        private ComboBox cmbCodiceIstituto;
        private GroupBox groupBox6;
        private CheckBox chkTransmissionKind;
		bool Started;


		public Frm_proceedstransmission_generazioneautomatica() {
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
            this.dgrDocumenti = new System.Windows.Forms.DataGrid();
            this.label7 = new System.Windows.Forms.Label();
            this.txtData = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEsercizio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpConferma = new System.Windows.Forms.GroupBox();
            this.btnNo = new System.Windows.Forms.Button();
            this.btnSiTutti = new System.Windows.Forms.Button();
            this.btnSi = new System.Windows.Forms.Button();
            this.btnChiudi = new System.Windows.Forms.Button();
            this.btnSuccessivo = new System.Windows.Forms.Button();
            this.btnInizia = new System.Windows.Forms.Button();
            this.DS = new proceedstransmission_generazioneautomatica.vistaForm();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnIstitutoCassiere = new System.Windows.Forms.Button();
            this.cmbCodiceIstituto = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.chkTransmissionKind = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgrDocumenti)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grpConferma.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgrDocumenti
            // 
            this.dgrDocumenti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrDocumenti.DataMember = "";
            this.dgrDocumenti.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgrDocumenti.Location = new System.Drawing.Point(8, 16);
            this.dgrDocumenti.Name = "dgrDocumenti";
            this.dgrDocumenti.Size = new System.Drawing.Size(392, 339);
            this.dgrDocumenti.TabIndex = 75;
            this.dgrDocumenti.Tag = "proceeds.elencoautomatico";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(6, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(144, 16);
            this.label7.TabIndex = 73;
            this.label7.Text = "Responsabile della distinta:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(120, 16);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(144, 20);
            this.txtData.TabIndex = 2;
            this.txtData.Tag = "proceedstransmission.transmissiondate?proceedstransmissionview.transmissiondate";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 16);
            this.label3.TabIndex = 71;
            this.label3.Text = "Data trasmissione:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNumero);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtEsercizio);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(9, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(271, 48);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Distinta di trasmissione";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(192, 16);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(72, 20);
            this.txtNumero.TabIndex = 1;
            this.txtNumero.Tag = "proceedstransmission.nproceedstransmission?proceedstransmissionview.nproceedstran" +
                "smission";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(136, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Numero:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercizio
            // 
            this.txtEsercizio.Location = new System.Drawing.Point(72, 16);
            this.txtEsercizio.Name = "txtEsercizio";
            this.txtEsercizio.ReadOnly = true;
            this.txtEsercizio.Size = new System.Drawing.Size(56, 20);
            this.txtEsercizio.TabIndex = 1;
            this.txtEsercizio.TabStop = false;
            this.txtEsercizio.Tag = "proceedstransmission.yproceedstransmission?proceedstransmissionview.yproceedstran" +
                "smission";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Esercizio:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpConferma
            // 
            this.grpConferma.Controls.Add(this.btnNo);
            this.grpConferma.Controls.Add(this.btnSiTutti);
            this.grpConferma.Controls.Add(this.btnSi);
            this.grpConferma.Enabled = false;
            this.grpConferma.Location = new System.Drawing.Point(280, 0);
            this.grpConferma.Name = "grpConferma";
            this.grpConferma.Size = new System.Drawing.Size(312, 48);
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
            this.btnSiTutti.Location = new System.Drawing.Point(240, 16);
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
            this.btnChiudi.TabIndex = 92;
            this.btnChiudi.Text = "Termina";
            this.btnChiudi.Click += new System.EventHandler(this.btnChiudi_Click);
            // 
            // btnSuccessivo
            // 
            this.btnSuccessivo.Enabled = false;
            this.btnSuccessivo.Location = new System.Drawing.Point(96, 16);
            this.btnSuccessivo.Name = "btnSuccessivo";
            this.btnSuccessivo.Size = new System.Drawing.Size(80, 23);
            this.btnSuccessivo.TabIndex = 91;
            this.btnSuccessivo.Text = "Prossimo >>";
            this.btnSuccessivo.Click += new System.EventHandler(this.btnSuccessivo_Click);
            // 
            // btnInizia
            // 
            this.btnInizia.Location = new System.Drawing.Point(8, 16);
            this.btnInizia.Name = "btnInizia";
            this.btnInizia.Size = new System.Drawing.Size(80, 23);
            this.btnInizia.TabIndex = 90;
            this.btnInizia.Text = "Inizia Ricerca";
            this.btnInizia.Click += new System.EventHandler(this.btnInizia_Click);
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.DS.manager;
            this.comboBox1.DisplayMember = "title";
            this.comboBox1.Enabled = false;
            this.comboBox1.Location = new System.Drawing.Point(6, 134);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(256, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.Tag = "proceedstransmission.idman";
            this.comboBox1.ValueMember = "idman";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnIstitutoCassiere);
            this.groupBox2.Controls.Add(this.cmbCodiceIstituto);
            this.groupBox2.Controls.Add(this.txtData);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Location = new System.Drawing.Point(8, 96);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(272, 161);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dati Contabili";
            // 
            // btnIstitutoCassiere
            // 
            this.btnIstitutoCassiere.Location = new System.Drawing.Point(9, 46);
            this.btnIstitutoCassiere.Name = "btnIstitutoCassiere";
            this.btnIstitutoCassiere.Size = new System.Drawing.Size(80, 24);
            this.btnIstitutoCassiere.TabIndex = 98;
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
            this.cmbCodiceIstituto.Location = new System.Drawing.Point(8, 76);
            this.cmbCodiceIstituto.Name = "cmbCodiceIstituto";
            this.cmbCodiceIstituto.Size = new System.Drawing.Size(254, 21);
            this.cmbCodiceIstituto.TabIndex = 97;
            this.cmbCodiceIstituto.Tag = "proceedstransmission.idtreasurer";
            this.cmbCodiceIstituto.ValueMember = "idtreasurer";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnInizia);
            this.groupBox3.Controls.Add(this.btnChiudi);
            this.groupBox3.Controls.Add(this.btnSuccessivo);
            this.groupBox3.Location = new System.Drawing.Point(8, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(272, 48);
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
            this.groupBox4.Size = new System.Drawing.Size(408, 363);
            this.groupBox4.TabIndex = 76;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Reversali incluse nella distinta di trasmissione";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.chkTransmissionKind);
            this.groupBox6.Location = new System.Drawing.Point(9, 263);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(271, 36);
            this.groupBox6.TabIndex = 106;
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
            this.chkTransmissionKind.Tag = "proceedstransmission.transmissionkind:V:I";
            this.chkTransmissionKind.Text = "Elenco di Variazioni e Annullamenti";
            this.chkTransmissionKind.UseVisualStyleBackColor = true;
            // 
            // Frm_proceedstransmission_generazioneautomatica
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(698, 419);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpConferma);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Name = "Frm_proceedstransmission_generazioneautomatica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmtrasmdocincasso_gener_auto";
            ((System.ComponentModel.ISupportInitialize)(this.dgrDocumenti)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpConferma.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		public void MetaData_AfterFill(){
			CalcButtons();
			//txtResponsabile.ReadOnly=!(flagtrasmresponsabile.ToUpper()=="S");
		}

		public void MetaData_AfterClear(){
			CalcButtons();
		}
        QueryHelper QHS;
        CQueryHelper QHC;
        int esercizio;
        private EP_Manager EPM;

        public void MetaData_AfterLink(){
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
            string filterEsercizio = QHS.CmpEq("ayear", esercizio);
            GetData.CacheTable(DS.config, filterEsercizio, null, false);
			GetData.CacheTable(DS.accountkind);
			HelpForm.SetAllowMultiSelection(DS.proceeds,true);
            btnIstitutoCassiere.Enabled = false;
            cmbCodiceIstituto.Enabled = false;
            HelpForm.SetDenyNull(DS.proceedstransmission.Columns["transmissionkind"], true);
            EPM = new EP_Manager(Meta, null, null, null, null, null, null, null, null, "proceedstransmission");
        }

		public void MetaData_AfterActivation(){
			CalcButtons();
            byte proceeds_flag = (byte)DS.Tables["config"].Rows[0]["proceeds_flag"];
            flagtrasmresponsabile = (proceeds_flag & 1) == 1;
			//			if (Convert.ToInt32(Meta.Conn.sys["esercizio"])>2001) chbEuro.Visible=false;
			impostaColoreBottoni();
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
            ParteWhere = QHS.AppAnd(QHS.IsNull("kproceedstransmission"),
                 QHS.IsNotNull("printdate"), QHS.CmpEq("ypro", esercizio));
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
			TempTable = Meta.Conn.RUN_SELECT("proceeds",ParteSelect,ParteOrderBy,ParteWhere, null, ParteGroupBy, true);
		}
			
		private void CollegaRigheADocumento(){
			if (TempTable.Rows.Count==0){
				MetaFactory.factory.getSingleton<IMessageShower>().Show("Non ci sono reversali di incasso da elaborare");
				btnSuccessivo.Enabled=false;
				grpConferma.Enabled=false;
				return;
			}
			//MetaData.GetFormData(this,true);
			//Meta.Conn.sys["esercizio"].ToString();
            int eserccorrente = esercizio;
            string condizioniaggiuntive = "";

			object codiceistituto = TempTable.Rows[0]["idtreasurer"];
			MetaData.SetDefault(DS.proceedstransmission, "idtreasurer", codiceistituto);

            condizioniaggiuntive = QHS.AppAnd(condizioniaggiuntive, QHS.CmpEq("idtreasurer", codiceistituto));

			if (flagtrasmresponsabile){
				object codiceresponsabile = TempTable.Rows[0]["idman"];
				MetaData.SetDefault(DS.proceedstransmission, "idman", codiceresponsabile);
                condizioniaggiuntive = QHS.AppAnd(condizioniaggiuntive, QHS.CmpEq("idman", codiceresponsabile));
            }
			else {
				MetaData.SetDefault(DS.proceedstransmission, "idman", DBNull.Value);
			}
			MetaData.GetMetaData(this).EditNew();
			
			DS.proceeds.Clear();
            string MyFilter = QHS.AppAnd(QHS.IsNull("kproceedstransmission"),
                QHS.IsNotNull("printdate"), QHS.CmpEq("ypro", esercizio), condizioniaggiuntive);

			DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn,DS.proceeds, 
				"ypro  ASC, npro ASC",
				MyFilter,
				null,
				true);

			GetData.DenyClear(DS.proceeds);
			MetaData.GetFormData(this, true);
			MetaData.FreshForm(this, false);
			int max=DS.proceeds.Rows.Count;
			for (int i=0; i<max; i++){
				dgrDocumenti.Select(i);
			}
			CalcButtons();
		}


		void CalcButtons(){
			btnInizia.Enabled=(Started==false);
			int righe_da_collegare = DS.proceeds.Select(QHC.IsNull("kproceedstransmission")).Length;
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
				DS.proceeds.AcceptChanges();
				TempTable.Rows.RemoveAt(0);
				TempTable.AcceptChanges();
				MetaData.FreshForm(this, true);
			}
			grpConferma.Enabled=false;
			btnSuccessivo.Enabled=true;
			//CalcButtons();
		}

		private void btnSi_Click(object sender, System.EventArgs e) {
			bool res=AccettaDocumento(false); //<-
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

		public void MetaData_AfterPost() {
            DataRow curr = DS.proceedstransmission.Rows[0];
            if (EPM.abilitaScritture(curr)) {
                EPM.generaScritture();
            }
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="all">TRUE: se premuto il bottone Si,Tutte FALSE: altrimenti</param>
		private bool AccettaDocumento(bool all){
			bool success=true; //<-
			int gridrowsnumber=DS.proceeds.Rows.Count;
			int i;
			int kelenco=CfgFn.GetNoNullInt32(DS.proceedstransmission.Rows[0]["kproceedstransmission"]);
			for(i=0; i<gridrowsnumber; i++){
				if(dgrDocumenti.IsSelected(i)){
                    string filter = QHC.AppAnd(QHC.CmpEq("ypro", dgrDocumenti[i, 0]), 
                            QHC.CmpEq("npro", dgrDocumenti[i, 1]));
					DataRow [] selrow = DS.proceeds.Select(filter);
                    selrow[0]["kproceedstransmission"] = kelenco;
				}
			}
			MetaData.DoMainCommand(this, "mainsave");
			if (all || !DS.HasChanges()){
				TempTable.Rows.RemoveAt(0);
				TempTable.AcceptChanges();
				success=true;
			}
			else {
				success=false;
				return success;
			}
			return success;
			//CalcButtons();
		}
		

		private void btnSiTutti_Click(object sender, System.EventArgs e) {
			while (TempTable.Rows.Count > 0){
				bool esito = AccettaDocumento(true);
				if (!esito) 	break;
				CollegaRigheADocumento();
				//MetaData.FreshForm(this, true);
			}
			CalcButtons();
			Meta.DontWarnOnInsertCancel=true;
		}

		private void btnChiudi_Click(object sender, System.EventArgs e) {
			if (DS.proceeds.Rows.Count==0) DS.proceedstransmission.AcceptChanges();
		}
	}
}
