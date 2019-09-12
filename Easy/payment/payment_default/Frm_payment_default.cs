/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using funzioni_configurazione;//funzioni_configurazione

namespace payment_default{//documentopagamento//
	/// <summary>
	/// Summary description for frmdocumentospesa.
	/// revised by Nino on 1/1/2003
	/// revised by Nino on 26/1/2003
	/// revised by Nino on 7/2/2003 (era sbagliata la ricerca: usava numdocpagamento invece di nummovimento)
	/// revised by Nino 21/2/2003
	/// </summary>
	public class Frm_payment_default : System.Windows.Forms.Form {
        QueryHelper QHS;
        CQueryHelper QHC;
        private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtEsercizioDocumento;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtNumeroDocumento;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnRigaMandato;
		private System.Windows.Forms.ComboBox cmbCodiceIstituto;
		private System.Windows.Forms.ComboBox cmbBollo;
		private System.Windows.Forms.Button btnBollo;
		private System.Windows.Forms.Button btnIstitutoCassiere;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtCreditoreDebitore;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtBilancio;
		private System.Windows.Forms.TextBox txtDescrBilancio;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.Button btnScollega;
		public vistaForm DS;
		private System.Windows.Forms.TextBox txtNumeroRiga;
		private System.Windows.Forms.TextBox txtEsercizioRiga;
		private System.ComponentModel.IContainer components;
		MetaData Meta;
		bool flagcreddeb;
		bool flagbilancio;
		bool flagrespons;
		private System.Windows.Forms.TextBox txtResponsabile;
		private System.Windows.Forms.GroupBox gboxRigaMandato;
		private System.Windows.Forms.TextBox txtBoxInvisibileTipoPagamento;
		private System.Windows.Forms.TextBox txtTipoPagamento;
		bool flagresidui;
		bool CanGoInsert;
		string comandochoose;
		private System.Windows.Forms.TextBox txtImporto;
		public System.Windows.Forms.ToolBar MetaDataToolBar;
		private System.Windows.Forms.ToolBarButton inserisci;
		private System.Windows.Forms.ToolBarButton elimina;
		private System.Windows.Forms.ToolBarButton Salva;
		private System.Windows.Forms.ToolBarButton aggiorna;
		private System.Windows.Forms.ToolBarButton btnEditNotes;
		private System.Windows.Forms.ImageList images;
		private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox3;
        private Label label10;
        private TextBox textBox1;
		bool InChiusura;

		public Frm_payment_default() {
			InitializeComponent();
			CanGoInsert=true;
			InChiusura=false;
			QueryCreator.SetTableForPosting(DS.expenselastview, "expenselast");
			QueryCreator.SetTableForPosting(DS.payment_bankview,"payment_bank");
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			InChiusura=true;
			if( disposing ) {
				if(components != null) {
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		public void MetaData_AfterClear(){
			DS.expenselastview.Clear();
			FillDettagliMovSpesa();
			txtNumeroDocumento.Text="";
            btnIstitutoCassiere.Enabled = true;
            cmbCodiceIstituto.Enabled = true;
			if (!CanGoInsert)return;
			CanGoInsert=false;
			MetaData.MainAdd(this);
		}

		DataRow GetLinkedRow(){
			if (Meta.IsEmpty) return null;
			if (DS.payment.Rows.Count==0) return null;
			DataRow CurrRow = DS.payment.Rows[0];
			foreach (DataRow MyRow in DS.expenselastview.Rows){
				if (MyRow.RowState== DataRowState.Deleted) continue;
				if (MyRow["kpay"].ToString()==CurrRow["kpay"].ToString()){
					return MyRow;
				}
			}
			return null;
		}
		
		void ScollegaRiga(){
			DataRow linked= GetLinkedRow();
			if (linked!=null) {
				DataRow DocPagamento= DS.payment.Rows[0];
				DocPagamento["idreg"]=DBNull.Value;
				DocPagamento["idfin"]=DBNull.Value;
				DocPagamento["idman"]=DBNull.Value;
				Meta.unlink(linked);
			}
			txtNumeroRiga.Text="";
			FillDettagliMovSpesa();
		} 

		void FillDettagliMovSpesa(){
			DataRow linked= GetLinkedRow();
			if (linked==null){
				txtCreditoreDebitore.Text="";
				txtBilancio.Text="";
				txtDescrBilancio.Text="";
				txtResponsabile.Text="";
				txtImporto.Text="";
                txtNumeroRiga.Text = "";
            }
			else {
          
                txtCreditoreDebitore.Text = linked["registry"].ToString();

                object newidfin = calcolaBilancioPerMandato(linked["idfin"]);
              
                DataTable tFin = Meta.Conn.RUN_SELECT("fin", null, null, QHS.CmpEq("idfin", newidfin), null, true);

                if (tFin.Rows.Count > 0)
                {
                    txtBilancio.Text = tFin.Rows[0]["codefin"].ToString();
                    txtDescrBilancio.Text = tFin.Rows[0]["title"].ToString();
                }
				txtResponsabile.Text=linked["manager"].ToString();
				if (linked["curramount"]!=DBNull.Value)
					txtImporto.Text= ((decimal)linked["curramount"]).ToString("c");
				else 
					txtImporto.Text="";
                txtNumeroRiga.Text = linked["nmov"].ToString();

			}
		}

		private void SetButtonsCollegaScollega(){
			bool res= (GetLinkedRow()!=null);
			btnScollega.Enabled=res;
			btnRigaMandato.Enabled=!res;
			txtNumeroRiga.ReadOnly=res;
		}

		public void MetaData_AfterActivation(){
//			chbEuro.Visible=(Convert.ToInt16(Meta.GetSys("esercizio")) < 2002);
            int UltimaFase = CfgFn.GetNoNullInt32(Meta.GetSys("maxexpensephase")); 
			string DescrFase = DS.expensephase.Rows[UltimaFase-1]["description"].ToString();
			gboxRigaMandato.Text=DescrFase;
			btnRigaMandato.Text=DescrFase;
			DataRow rPersSpesa= DS.Tables["config"].Rows[0];
            byte payment_flag = (byte)rPersSpesa["payment_flag"];
            flagcreddeb = (payment_flag & 4) == 4;
            flagbilancio = (payment_flag & 2) == 2;
            flagrespons = (payment_flag & 16) == 16;
            flagresidui = (payment_flag & 8) == 8;
			/*if (!flagresidui) 
				DS.payment.Columns["kind"].DefaultValue="M";
			else 
				DS.payment.Columns["kind"].DefaultValue="C";
			*/
            int flag=CfgFn.GetNoNullInt32(DS.payment.Columns["flag"].DefaultValue);
            if (!flagresidui) {
                flag = flag & 0xF8;
                flag = flag + 4;
                DS.payment.Columns["flag"].DefaultValue = flag;
            }
            else {
                flag = flag & 0xF8;
                flag = flag + 1;
                DS.payment.Columns["flag"].DefaultValue = flag;
            }
			DataRow[] bollo = DS.stamphandling.Select(QHC.CmpEq("flagdefault","S"));
			if (bollo.Length==1) MetaData.SetDefault(DS.payment,"idstamphandling",bollo[0]["idstamphandling"]);

            DataRow[] cassiere = DS.treasurer.Select(QHC.CmpEq("flagdefault", "S"));
			if (cassiere.Length==1) MetaData.SetDefault(DS.payment, "idtreasurer", cassiere[0]["idtreasurer"]);

            if (DS.treasurer.Select(QHC.CmpNe("idtreasurer", 0)).Length == 1) {
                object codiceistituto = DS.treasurer.Select(QHC.CmpNe("idtreasurer", 0))[0]["idtreasurer"];
                MetaData.SetDefault(DS.payment, "idtreasurer", codiceistituto);
            }
	

            int codicefase = CfgFn.GetNoNullInt32(Meta.GetSys("maxexpensephase"));

			string MyFilter = QHS.AppAnd(QHS.CmpEq("nphase",codicefase),
                        QHS.IsNull("kpay"),
                        QHS.CmpEq("ayear",Meta.GetSys("esercizio")));
			comandochoose = "choose.expenselastview.movimentiaperti." + MyFilter;
            btnRigaMandato.Tag= comandochoose;

			//MetaData.MainAdd(this);
		}

		void AfterLinkBody(){
            QHS = Meta.Conn.GetQueryHelper();
            QHC = new CQueryHelper();
            Meta.DontWarnOnInsertCancel = true;
			string filteresercizio = QHS.CmpEq("ayear",Meta.GetSys("esercizio"));
			GetData.CacheTable(DS.config,filteresercizio,null,false);
			DS.Tables["expensephase"].ExtendedProperties["sort_by"]="nphase";
			GetData.CacheTable(DS.expensephase);
            GetData.SetStaticFilter(DS.expenselastview, QHS.CmpEq("ymov", Meta.GetSys("esercizio")));
            HelpForm.SetDenyNull(DS.payment.Columns["idtreasurer"], true);

		}
		public void MetaData_AfterLink(){
			Meta = MetaData.GetMetaData(this);
			AfterLinkBody();
            GetData.SetStaticFilter(DS.payment, QHS.CmpEq("ypay", Meta.GetSys("esercizio")));
        }

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_payment_default));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNumeroDocumento = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEsercizioDocumento = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTipoPagamento = new System.Windows.Forms.TextBox();
            this.txtBoxInvisibileTipoPagamento = new System.Windows.Forms.TextBox();
            this.gboxRigaMandato = new System.Windows.Forms.GroupBox();
            this.btnScollega = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumeroRiga = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEsercizioRiga = new System.Windows.Forms.TextBox();
            this.btnRigaMandato = new System.Windows.Forms.Button();
            this.btnIstitutoCassiere = new System.Windows.Forms.Button();
            this.cmbCodiceIstituto = new System.Windows.Forms.ComboBox();
            this.DS = new payment_default.vistaForm();
            this.cmbBollo = new System.Windows.Forms.ComboBox();
            this.btnBollo = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCreditoreDebitore = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.txtBilancio = new System.Windows.Forms.TextBox();
            this.txtDescrBilancio = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtResponsabile = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtImporto = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.MetaDataToolBar = new System.Windows.Forms.ToolBar();
            this.inserisci = new System.Windows.Forms.ToolBarButton();
            this.elimina = new System.Windows.Forms.ToolBarButton();
            this.Salva = new System.Windows.Forms.ToolBarButton();
            this.aggiorna = new System.Windows.Forms.ToolBarButton();
            this.btnEditNotes = new System.Windows.Forms.ToolBarButton();
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gboxRigaMandato.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtNumeroDocumento);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtEsercizioDocumento);
            this.groupBox1.Location = new System.Drawing.Point(8, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(152, 80);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Documento";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Numero:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNumeroDocumento
            // 
            this.txtNumeroDocumento.Location = new System.Drawing.Point(72, 56);
            this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            this.txtNumeroDocumento.ReadOnly = true;
            this.txtNumeroDocumento.Size = new System.Drawing.Size(72, 20);
            this.txtNumeroDocumento.TabIndex = 2;
            this.txtNumeroDocumento.TabStop = false;
            this.txtNumeroDocumento.Tag = "payment.npay";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Esercizio:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercizioDocumento
            // 
            this.txtEsercizioDocumento.Location = new System.Drawing.Point(72, 16);
            this.txtEsercizioDocumento.Name = "txtEsercizioDocumento";
            this.txtEsercizioDocumento.ReadOnly = true;
            this.txtEsercizioDocumento.Size = new System.Drawing.Size(56, 20);
            this.txtEsercizioDocumento.TabIndex = 0;
            this.txtEsercizioDocumento.TabStop = false;
            this.txtEsercizioDocumento.Tag = "payment.ypay";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtTipoPagamento);
            this.groupBox2.Controls.Add(this.txtBoxInvisibileTipoPagamento);
            this.groupBox2.Location = new System.Drawing.Point(176, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(176, 40);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipo";
            // 
            // txtTipoPagamento
            // 
            this.txtTipoPagamento.Location = new System.Drawing.Point(8, 16);
            this.txtTipoPagamento.Name = "txtTipoPagamento";
            this.txtTipoPagamento.ReadOnly = true;
            this.txtTipoPagamento.Size = new System.Drawing.Size(112, 20);
            this.txtTipoPagamento.TabIndex = 2;
            this.txtTipoPagamento.TabStop = false;
            // 
            // txtBoxInvisibileTipoPagamento
            // 
            this.txtBoxInvisibileTipoPagamento.Location = new System.Drawing.Point(128, 16);
            this.txtBoxInvisibileTipoPagamento.Name = "txtBoxInvisibileTipoPagamento";
            this.txtBoxInvisibileTipoPagamento.Size = new System.Drawing.Size(32, 20);
            this.txtBoxInvisibileTipoPagamento.TabIndex = 1;
            this.txtBoxInvisibileTipoPagamento.Tag = "payment.flag";
            this.txtBoxInvisibileTipoPagamento.Visible = false;
            // 
            // gboxRigaMandato
            // 
            this.gboxRigaMandato.Controls.Add(this.btnScollega);
            this.gboxRigaMandato.Controls.Add(this.label3);
            this.gboxRigaMandato.Controls.Add(this.txtNumeroRiga);
            this.gboxRigaMandato.Controls.Add(this.label4);
            this.gboxRigaMandato.Controls.Add(this.txtEsercizioRiga);
            this.gboxRigaMandato.Controls.Add(this.btnRigaMandato);
            this.gboxRigaMandato.Location = new System.Drawing.Point(8, 152);
            this.gboxRigaMandato.Name = "gboxRigaMandato";
            this.gboxRigaMandato.Size = new System.Drawing.Size(344, 88);
            this.gboxRigaMandato.TabIndex = 2;
            this.gboxRigaMandato.TabStop = false;
            this.gboxRigaMandato.Text = "Riga mandato";
            // 
            // btnScollega
            // 
            this.btnScollega.Enabled = false;
            this.btnScollega.Location = new System.Drawing.Point(16, 56);
            this.btnScollega.Name = "btnScollega";
            this.btnScollega.Size = new System.Drawing.Size(104, 24);
            this.btnScollega.TabIndex = 8;
            this.btnScollega.TabStop = false;
            this.btnScollega.Tag = "";
            this.btnScollega.Text = "Rimuovi riga";
            this.btnScollega.Click += new System.EventHandler(this.btnScollega_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(128, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Numero:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNumeroRiga
            // 
            this.txtNumeroRiga.Location = new System.Drawing.Point(192, 56);
            this.txtNumeroRiga.Name = "txtNumeroRiga";
            this.txtNumeroRiga.Size = new System.Drawing.Size(96, 20);
            this.txtNumeroRiga.TabIndex = 1;
            this.txtNumeroRiga.Tag = "expenselastview.nmov?x";
            this.txtNumeroRiga.Leave += new System.EventHandler(this.txtNumeroRiga_Leave);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(128, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Esercizio:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercizioRiga
            // 
            this.txtEsercizioRiga.Location = new System.Drawing.Point(192, 24);
            this.txtEsercizioRiga.Name = "txtEsercizioRiga";
            this.txtEsercizioRiga.ReadOnly = true;
            this.txtEsercizioRiga.Size = new System.Drawing.Size(56, 20);
            this.txtEsercizioRiga.TabIndex = 0;
            this.txtEsercizioRiga.TabStop = false;
            this.txtEsercizioRiga.Tag = "expenselastview.ymov?x";
            // 
            // btnRigaMandato
            // 
            this.btnRigaMandato.Enabled = false;
            this.btnRigaMandato.Location = new System.Drawing.Point(16, 20);
            this.btnRigaMandato.Name = "btnRigaMandato";
            this.btnRigaMandato.Size = new System.Drawing.Size(104, 24);
            this.btnRigaMandato.TabIndex = 6;
            this.btnRigaMandato.TabStop = false;
            this.btnRigaMandato.Tag = "";
            this.btnRigaMandato.Text = "Riga mandato:";
            this.btnRigaMandato.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnIstitutoCassiere
            // 
            this.btnIstitutoCassiere.Location = new System.Drawing.Point(8, 16);
            this.btnIstitutoCassiere.Name = "btnIstitutoCassiere";
            this.btnIstitutoCassiere.Size = new System.Drawing.Size(88, 24);
            this.btnIstitutoCassiere.TabIndex = 7;
            this.btnIstitutoCassiere.TabStop = false;
            this.btnIstitutoCassiere.Tag = "choose.treasurer.lista.(active=\'S\')";
            this.btnIstitutoCassiere.Text = "Cassiere:";
            this.btnIstitutoCassiere.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbCodiceIstituto
            // 
            this.cmbCodiceIstituto.DataSource = this.DS.treasurer;
            this.cmbCodiceIstituto.DisplayMember = "description";
            this.cmbCodiceIstituto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCodiceIstituto.Location = new System.Drawing.Point(104, 16);
            this.cmbCodiceIstituto.Name = "cmbCodiceIstituto";
            this.cmbCodiceIstituto.Size = new System.Drawing.Size(232, 21);
            this.cmbCodiceIstituto.TabIndex = 1;
            this.cmbCodiceIstituto.Tag = "payment.idtreasurer";
            this.cmbCodiceIstituto.ValueMember = "idtreasurer";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // cmbBollo
            // 
            this.cmbBollo.DataSource = this.DS.stamphandling;
            this.cmbBollo.DisplayMember = "description";
            this.cmbBollo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBollo.Location = new System.Drawing.Point(104, 48);
            this.cmbBollo.Name = "cmbBollo";
            this.cmbBollo.Size = new System.Drawing.Size(232, 21);
            this.cmbBollo.TabIndex = 2;
            this.cmbBollo.Tag = "payment.idstamphandling";
            this.cmbBollo.ValueMember = "idstamphandling";
            // 
            // btnBollo
            // 
            this.btnBollo.Location = new System.Drawing.Point(8, 48);
            this.btnBollo.Name = "btnBollo";
            this.btnBollo.Size = new System.Drawing.Size(88, 24);
            this.btnBollo.TabIndex = 10;
            this.btnBollo.TabStop = false;
            this.btnBollo.Tag = "manage.stamphandling.lista";
            this.btnBollo.Text = "Bollo:";
            this.btnBollo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(10, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "Percipiente:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCreditoreDebitore
            // 
            this.txtCreditoreDebitore.Location = new System.Drawing.Point(10, 133);
            this.txtCreditoreDebitore.Name = "txtCreditoreDebitore";
            this.txtCreditoreDebitore.ReadOnly = true;
            this.txtCreditoreDebitore.Size = new System.Drawing.Size(328, 20);
            this.txtCreditoreDebitore.TabIndex = 12;
            this.txtCreditoreDebitore.TabStop = false;
            this.txtCreditoreDebitore.Tag = "";
            // 
            // label6
            // 
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.ImageIndex = 0;
            this.label6.ImageList = this.imageList1;
            this.label6.Location = new System.Drawing.Point(10, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 16);
            this.label6.TabIndex = 15;
            this.label6.Text = "Bilancio:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            // 
            // txtBilancio
            // 
            this.txtBilancio.Location = new System.Drawing.Point(10, 189);
            this.txtBilancio.Name = "txtBilancio";
            this.txtBilancio.ReadOnly = true;
            this.txtBilancio.Size = new System.Drawing.Size(96, 20);
            this.txtBilancio.TabIndex = 14;
            this.txtBilancio.TabStop = false;
            this.txtBilancio.Tag = "";
            // 
            // txtDescrBilancio
            // 
            this.txtDescrBilancio.Location = new System.Drawing.Point(114, 165);
            this.txtDescrBilancio.Multiline = true;
            this.txtDescrBilancio.Name = "txtDescrBilancio";
            this.txtDescrBilancio.ReadOnly = true;
            this.txtDescrBilancio.Size = new System.Drawing.Size(224, 48);
            this.txtDescrBilancio.TabIndex = 16;
            this.txtDescrBilancio.TabStop = false;
            this.txtDescrBilancio.Tag = "";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(10, 213);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 16);
            this.label7.TabIndex = 18;
            this.label7.Text = "Responsabile:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtResponsabile
            // 
            this.txtResponsabile.Location = new System.Drawing.Point(10, 237);
            this.txtResponsabile.Name = "txtResponsabile";
            this.txtResponsabile.ReadOnly = true;
            this.txtResponsabile.Size = new System.Drawing.Size(328, 20);
            this.txtResponsabile.TabIndex = 17;
            this.txtResponsabile.TabStop = false;
            this.txtResponsabile.Tag = "";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(10, 261);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 16);
            this.label8.TabIndex = 20;
            this.label8.Text = "Importo:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtImporto
            // 
            this.txtImporto.Location = new System.Drawing.Point(10, 277);
            this.txtImporto.Name = "txtImporto";
            this.txtImporto.ReadOnly = true;
            this.txtImporto.Size = new System.Drawing.Size(96, 20);
            this.txtImporto.TabIndex = 19;
            this.txtImporto.TabStop = false;
            this.txtImporto.Tag = "";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(240, 199);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 16);
            this.label9.TabIndex = 22;
            this.label9.Text = "Data contabile:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(240, 215);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(96, 20);
            this.textBox5.TabIndex = 3;
            this.textBox5.Tag = "payment.adate";
            // 
            // MetaDataToolBar
            // 
            this.MetaDataToolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.MetaDataToolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.inserisci,
            this.elimina,
            this.Salva,
            this.aggiorna,
            this.btnEditNotes});
            this.MetaDataToolBar.ButtonSize = new System.Drawing.Size(32, 32);
            this.MetaDataToolBar.DropDownArrows = true;
            this.MetaDataToolBar.ImageList = this.images;
            this.MetaDataToolBar.Location = new System.Drawing.Point(0, 0);
            this.MetaDataToolBar.Name = "MetaDataToolBar";
            this.MetaDataToolBar.ShowToolTips = true;
            this.MetaDataToolBar.Size = new System.Drawing.Size(362, 58);
            this.MetaDataToolBar.TabIndex = 24;
            this.MetaDataToolBar.Tag = "";
            // 
            // inserisci
            // 
            this.inserisci.ImageIndex = 0;
            this.inserisci.Name = "inserisci";
            this.inserisci.Tag = "maininsert";
            this.inserisci.Text = "Inserisci";
            this.inserisci.ToolTipText = "Inserisci un nuovo elemento";
            // 
            // elimina
            // 
            this.elimina.ImageIndex = 3;
            this.elimina.Name = "elimina";
            this.elimina.Tag = "maindelete";
            this.elimina.Text = "Elimina";
            this.elimina.ToolTipText = "Elimina l\'elemento selezionato";
            // 
            // Salva
            // 
            this.Salva.ImageIndex = 2;
            this.Salva.Name = "Salva";
            this.Salva.Tag = "mainsave";
            this.Salva.Text = "Salva";
            this.Salva.ToolTipText = "Salva le modifiche effettuate";
            // 
            // aggiorna
            // 
            this.aggiorna.ImageIndex = 4;
            this.aggiorna.Name = "aggiorna";
            this.aggiorna.Tag = "mainrefresh";
            this.aggiorna.Text = "Aggiorna";
            // 
            // btnEditNotes
            // 
            this.btnEditNotes.ImageIndex = 5;
            this.btnEditNotes.Name = "btnEditNotes";
            this.btnEditNotes.Tag = "editnotes";
            this.btnEditNotes.Text = "Appunti";
            this.btnEditNotes.ToolTipText = "Modifica gli appunti associati all\'oggetto selezionato";
            // 
            // images
            // 
            this.images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("images.ImageStream")));
            this.images.TransparentColor = System.Drawing.Color.Transparent;
            this.images.Images.SetKeyName(0, "");
            this.images.Images.SetKeyName(1, "");
            this.images.Images.SetKeyName(2, "");
            this.images.Images.SetKeyName(3, "");
            this.images.Images.SetKeyName(4, "");
            this.images.Images.SetKeyName(5, "");
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.btnIstitutoCassiere);
            this.groupBox3.Controls.Add(this.cmbCodiceIstituto);
            this.groupBox3.Controls.Add(this.btnBollo);
            this.groupBox3.Controls.Add(this.cmbBollo);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtCreditoreDebitore);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtBilancio);
            this.groupBox3.Controls.Add(this.txtDescrBilancio);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtResponsabile);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtImporto);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.textBox5);
            this.groupBox3.Location = new System.Drawing.Point(8, 248);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(344, 315);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Dati Riepilogativi";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(150, 84);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(108, 32);
            this.label10.TabIndex = 28;
            this.label10.Text = "Numero Progr. Cassiere:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(264, 93);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(72, 20);
            this.textBox1.TabIndex = 27;
            this.textBox1.TabStop = false;
            this.textBox1.Tag = "payment.npay_treasurer";
            // 
            // Frm_payment_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(362, 570);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.MetaDataToolBar);
            this.Controls.Add(this.gboxRigaMandato);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Frm_payment_default";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gboxRigaMandato.ResumeLayout(false);
            this.gboxRigaMandato.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		void FillTxtTipoPagamento(){
			//string codetipo = DS.payment.Rows[0]["kind"].ToString().ToUpper();
            byte flag = CfgFn.GetNoNullByte(DS.payment.Rows[0]["flag"]);
            if ((flag&4)!= 0) txtTipoPagamento.Text = "Misto";
            if ((flag&1)!= 0) txtTipoPagamento.Text = "Competenza";
            if ((flag&2)!= 0) txtTipoPagamento.Text = "Residui";
		}

		public void MetaData_AfterFill(){
			txtEsercizioRiga.Text=Meta.GetSys("esercizio").ToString();
			FillTxtTipoPagamento();
			SetButtonsCollegaScollega();
			FillDettagliMovSpesa();
            if (Meta.EditMode)
            {
                btnIstitutoCassiere.Enabled = false;
                cmbCodiceIstituto.Enabled = false;
            }
		}

		public void MetaData_BeforePost() {
			azzeraMovBancarioInSpesa();
             object flagautostampa= Meta.Conn.DO_READ_VALUE("config", "(ayear='"+Meta.GetSys("esercizio").ToString()+"')", "payment_flagautoprintdate");
             if (Meta.InsertMode && (DS.payment.Rows.Count != 0) &&
                (flagautostampa != null) && (flagautostampa.ToString().ToUpper() == "S")) {
                DS.payment.Rows[0]["printdate"] = DS.payment.Rows[0]["adate"];
            }
           

		}


      

		public void MetaData_AfterPost() {
			DataRow R = GetLinkedRow();
			if (R==null) DS.expenselastview.Clear();
			if (DS.payment.Rows.Count == 0) return;
			fillPaymentBank();
			DS.payment_bankview.Clear();
			DataRow Curr = DS.payment.Rows[0];
            string filter = QHS.CmpKey(Curr);
			DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.payment_bankview, "idpay", filter, null, true);
		}

		public void MetaData_AfterRowSelect(DataTable T, DataRow R){
			if (Meta.IsEmpty) return;
			if (T.TableName == "expenselastview"){
				if (R==null) return;
                if (!Meta.DrawStateIsDone) return;
				Meta.GetFormData(true);
                foreach(DataRow DD in DS.expenselastview.Select()){
                    if (DD["nmov"].ToString() == R["nmov"].ToString()) continue;
                    if (DD["kpay", DataRowVersion.Original] == DBNull.Value) {
                        DD.Delete();
                        DD.AcceptChanges();
                        continue;
                    }
                    if (DD["nmov"].ToString() != R["nmov"].ToString()) {
                        DD["kpay"] = DBNull.Value;
                    }

                }
                DataRow DocPagamento = DS.payment.Rows[0];
				if (flagresidui) {
                    string flagarrear = R["flagarrear"].ToString().ToUpper();
                    int flag = CfgFn.GetNoNullInt32(DS.payment.Columns["flag"].DefaultValue);
                    flag = flag & 0xF8;
                    if (flagarrear == "C") {
                        flag = flag + 1;
                        DocPagamento["flag"] = flag; //C
                    }
                    else {
                        flag = flag + 2;
                        DocPagamento["flag"] = flag; //R
                    }
                }
                if (flagcreddeb)DocPagamento["idreg"]=R["idreg"];
                if (flagbilancio)
                {
                    DocPagamento["idfin"] = calcolaBilancioPerMandato(R["idfin"]);
                    
                }
				if (flagrespons)DocPagamento["idman"]=R["idman"];
				Meta.FreshForm(false);
			}
		}

        int GetPaymentLevelForFin(int idfin, int level) {
            if (level == 0)
                return idfin;          
            int newidfin = idfin;
            object O = Meta.Conn.DO_READ_VALUE(
                "finlink", QHS.AppAnd(
                        QHS.CmpEq("idchild", idfin),
                        QHS.CmpEq("nlevel", level)),
                "idparent");
            if (O != DBNull.Value)
                newidfin = CfgFn.GetNoNullInt32(O);
                        
            return newidfin;

        }

        object calcolaBilancioPerMandato(object idfin) {
            int  idbilanciomandato = CfgFn.GetNoNullInt32( idfin);
            byte payment_flag = (byte)DS.Tables["config"].Rows[0]["payment_flag"];            
            bool flagbilancio = (payment_flag & 2) == 2;
            object payment_finlevel = DS.Tables["config"].Rows[0]["payment_finlevel"];
            object maxlivbilancio = Meta.Conn.DO_READ_VALUE("finlevel",
                            QHS.CmpEq("ayear", Meta.Conn.GetEsercizio()), "max(nlevel)");
                     
            if (flagbilancio &&
                (payment_finlevel != DBNull.Value) &&
                (!payment_finlevel.Equals(maxlivbilancio))
                ) {
                int liv = CfgFn.GetNoNullInt32(payment_finlevel);
                idbilanciomandato = GetPaymentLevelForFin(idbilanciomandato, liv);
            }
            return idbilanciomandato;
        }

		private void azzeraMovBancarioInSpesa() {
			if (DS.payment.Rows.Count == 0) return;
			string filtro = QHS.AppAnd(QHS.IsNull("ypay"),QHS.IsNotNull("idpay"));
			foreach(DataRow R in DS.expenselastview.Select(filtro)) {
				R["idpay"] = DBNull.Value;
			}
		}

		private void btnScollega_Click(object sender, System.EventArgs e) {
			ScollegaRiga();
		}

		private void txtNumeroRiga_Leave(object sender, System.EventArgs e) {
			if (InChiusura) return;
            if (!Meta.DrawStateIsDone) return;
			if (txtNumeroRiga.ReadOnly==true) return;
			if (txtNumeroRiga.Enabled==false) return;
			if (Meta.IsEmpty) return;
			string nummov= txtNumeroRiga.Text.Trim();
			if (nummov=="" && DS.expenselastview.Rows.Count>0) {
				ScollegaRiga();
				return;
			}
            if (nummov == "") return;
            if (DS.expenselastview.Rows.Count == 1) {
                DataRow Curr = DS.expenselastview.Rows[0];
                if (Curr["nmov"].ToString() == nummov) return;
            }
            ScollegaRiga();
			if (!MetaData.Choose(this, comandochoose+"AND"+QHS.CmpEq("nmov",nummov))){
				txtNumeroRiga.Focus();
			}		
		}

		private void fillPaymentBank() {
			DataRow Curr = DS.payment.Rows[0];
			DataSet Out = Meta.Conn.CallSP("compute_payment_bank",
				new object[] {Curr["kpay"]}, false, 0);
		}

	}
}

