
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
using System.Data;
using funzioni_configurazione;

namespace banktransaction_payment {
	/// <summary>
	/// Summary description for Frm_banktransaction_payment.
	/// </summary>
	public class Frm_banktransaction_payment : MetaDataForm {
		MetaData Meta;
        string standardTagBtnMovSpesa = "";
        public banktransaction_payment.vistaForm DS;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnAnnulla;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.TextBox txtidpay;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtnpay;
		private System.Windows.Forms.TextBox txtypay;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button btnProceeds;
		private System.Windows.Forms.GroupBox grpMovSpesa;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Button btnMovSpesa;
		private System.Windows.Forms.TextBox txtNumMovSpesa;
		private System.Windows.Forms.TextBox txtEsercMovSpesa;
		private System.Windows.Forms.TextBox txtImportoEsito;
        private Button btnCollegaBankImport;
        private GroupBox groupBox6;
        private Label label11;
        private TextBox textBox4;
        private Label label12;
        private TextBox textBox7;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

		public Frm_banktransaction_payment() {
			InitializeComponent();
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

        QueryHelper QHS;
        CQueryHelper QHC;
		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
			string filtro = "";
			if (DS.banktransaction.ExtendedProperties[MetaData.ExtraParams] != null) {
				filtro = DS.banktransaction.ExtendedProperties[MetaData.ExtraParams].ToString();
			}
			DataRow Parent= Meta.SourceRow;
            string filterpayment = QHS.MCmp(Parent, "kpay");
			GetData.SetStaticFilter(DS.payment_bankview, filterpayment);

            string filtroSpesa = QHS.AppAnd(filtro, QHS.CmpEq("nphase", Meta.GetSys("maxexpensephase")));

            string filtrostatico = filtroSpesa;
            if (Meta.SourceRow != null) {
                DataRow Curr = Meta.SourceRow;
                if (Curr["idexp"] != DBNull.Value) {
                    filtrostatico = QHS.DoPar(QHS.AppOr(QHS.DoPar(filtroSpesa), QHS.CmpEq("idexp", Curr["idexp"])));
                }
            }
			
				
			GetData.SetStaticFilter(DS.expenseview, filtrostatico);

            object nomeFase = Meta.Conn.DO_READ_VALUE("expensephase", QHS.CmpEq("nphase", Meta.GetSys("maxexpensephase")), "description");
			string fase = (nomeFase != null) ? nomeFase.ToString() : "";
			grpMovSpesa.Text = fase;
			btnMovSpesa.Text = fase;
			standardTagBtnMovSpesa = HelpForm.GetStandardTag(btnMovSpesa.Tag);
            btnCollegaBankImport.Tag = btnCollegaBankImport.Tag + "." + QHS.DoPar(QHS.CmpEq("ayear", Meta.GetSys("esercizio")));

        }

        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
			if (T.TableName == "payment_bankview") {
				if (R == null) {
					grpMovSpesa.Enabled = false;
					btnMovSpesa.Tag = standardTagBtnMovSpesa;
				}
				else {
					MetaData.AutoInfo AI;
					AI = Meta.GetAutoInfo(txtNumMovSpesa.Name);
                    string filter = QHS.CmpEq("idpay", R["idpay"]);
					if (AI!=null) AI.startfilter=filter;
					grpMovSpesa.Enabled = true;

					string filtroTag = QHS.MCmp(R,"kpay","idpay");
					btnMovSpesa.Tag = standardTagBtnMovSpesa + "." + filtroTag;
				}
			}
			if (T.TableName == "expenseview") {
				if (R == null) return;
				decimal importo = calcolaImportoDaEsitare(R);
				DS.banktransaction.Rows[0]["amount"] = importo;
				DS.banktransaction.Rows[0]["idpay"]  = R["idpay"];
				txtImportoEsito.Text = importo.ToString("c");
				// Aggiungo la valorizzazione del relativo gruppo	
				txtidpay.Text = R["idpay"].ToString();
                string filter = QHC.MCmp(R, "ypay", "npay", "idpay");
				DataRow[] gruppi = DS.payment_bankview.Select(filter);
				if (gruppi.Length == 0) {
					DS.payment_bankview.Clear();
					DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.payment_bankview,null, filter, null, true);
				}
			}
		}

		private decimal calcolaImportoDaEsitare(DataRow rSpesa) {
			decimal importoCorrente = CfgFn.GetNoNullDecimal(rSpesa["curramount"]);

			DataRow rMandato = Meta.SourceRow.GetParentRow("paymentbanktransaction");
			if (rMandato == null) return -1;
			DataRow [] rEsiti = rMandato.GetChildRows("paymentbanktransaction");

			DataRow Curr = DS.banktransaction.Rows[0];
			decimal importoGiaEsitato = 0;

			foreach(DataRow rEsito in rEsiti) {
				if ((rEsito["idexp"].ToString() == Curr["idexp"].ToString()) &&
					(rEsito["kpay"].ToString() == Curr["kpay"].ToString())) {
					if (//(Meta.EditMode) && 
						(rEsito["nban"].ToString() == Curr["nban"].ToString())) continue;
					importoGiaEsitato += CfgFn.GetNoNullDecimal(rEsito["amount"]);
				}
			}

			importoCorrente -= importoGiaEsitato;
			return importoCorrente;
		}
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.DS = new banktransaction_payment.vistaForm();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnCollegaBankImport = new System.Windows.Forms.Button();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.label11 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtImportoEsito = new System.Windows.Forms.TextBox();
			this.btnAnnulla = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.txtidpay = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtnpay = new System.Windows.Forms.TextBox();
			this.txtypay = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.btnProceeds = new System.Windows.Forms.Button();
			this.grpMovSpesa = new System.Windows.Forms.GroupBox();
			this.txtNumMovSpesa = new System.Windows.Forms.TextBox();
			this.txtEsercMovSpesa = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.btnMovSpesa = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.grpMovSpesa.SuspendLayout();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnCollegaBankImport);
			this.groupBox1.Controls.Add(this.groupBox6);
			this.groupBox1.Controls.Add(this.groupBox4);
			this.groupBox1.Controls.Add(this.groupBox3);
			this.groupBox1.Controls.Add(this.groupBox2);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.txtImportoEsito);
			this.groupBox1.Location = new System.Drawing.Point(8, 120);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(496, 209);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Dati inerenti l\'esito ricevuti dal cassiere";
			// 
			// btnCollegaBankImport
			// 
			this.btnCollegaBankImport.Location = new System.Drawing.Point(8, 25);
			this.btnCollegaBankImport.Name = "btnCollegaBankImport";
			this.btnCollegaBankImport.Size = new System.Drawing.Size(234, 23);
			this.btnCollegaBankImport.TabIndex = 12;
			this.btnCollegaBankImport.Tag = "choose.bankimport.default";
			this.btnCollegaBankImport.Text = "Collega a Importazione esiti e sospesi";
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.label11);
			this.groupBox6.Controls.Add(this.textBox4);
			this.groupBox6.Controls.Add(this.label12);
			this.groupBox6.Controls.Add(this.textBox7);
			this.groupBox6.Location = new System.Drawing.Point(250, 11);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(240, 48);
			this.groupBox6.TabIndex = 11;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Importazione esiti Bancari";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(128, 16);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(48, 16);
			this.label11.TabIndex = 3;
			this.label11.Text = "Numero";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(176, 16);
			this.textBox4.Name = "textBox4";
			this.textBox4.ReadOnly = true;
			this.textBox4.Size = new System.Drawing.Size(56, 20);
			this.textBox4.TabIndex = 2;
			this.textBox4.Tag = "bankimport.idbankimport";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(8, 16);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(56, 16);
			this.label12.TabIndex = 1;
			this.label12.Text = "Esercizio";
			// 
			// textBox7
			// 
			this.textBox7.Location = new System.Drawing.Point(64, 16);
			this.textBox7.Name = "textBox7";
			this.textBox7.ReadOnly = true;
			this.textBox7.Size = new System.Drawing.Size(56, 20);
			this.textBox7.TabIndex = 0;
			this.textBox7.Tag = "bankimport.ayear";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.label5);
			this.groupBox4.Controls.Add(this.label1);
			this.groupBox4.Controls.Add(this.textBox6);
			this.groupBox4.Controls.Add(this.textBox5);
			this.groupBox4.Location = new System.Drawing.Point(8, 60);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(240, 48);
			this.groupBox4.TabIndex = 8;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Transazione Bancaria";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(128, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(48, 16);
			this.label5.TabIndex = 3;
			this.label5.Text = "Numero";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Esercizio";
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(64, 16);
			this.textBox6.Name = "textBox6";
			this.textBox6.ReadOnly = true;
			this.textBox6.Size = new System.Drawing.Size(56, 20);
			this.textBox6.TabIndex = 1;
			this.textBox6.Tag = "banktransaction.yban";
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(176, 16);
			this.textBox5.Name = "textBox5";
			this.textBox5.ReadOnly = true;
			this.textBox5.Size = new System.Drawing.Size(56, 20);
			this.textBox5.TabIndex = 0;
			this.textBox5.Tag = "banktransaction.nban";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.textBox2);
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Controls.Add(this.label3);
			this.groupBox3.Controls.Add(this.textBox3);
			this.groupBox3.Location = new System.Drawing.Point(8, 116);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(480, 56);
			this.groupBox3.TabIndex = 1;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Date comunicate";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(96, 24);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(136, 20);
			this.textBox2.TabIndex = 1;
			this.textBox2.Tag = "banktransaction.transactiondate";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 23);
			this.label2.TabIndex = 5;
			this.label2.Text = "Operazione:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(256, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 23);
			this.label3.TabIndex = 6;
			this.label3.Text = "Valuta:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(336, 24);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(136, 20);
			this.textBox3.TabIndex = 2;
			this.textBox3.Tag = "banktransaction.valuedate";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.textBox1);
			this.groupBox2.Location = new System.Drawing.Point(248, 60);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(240, 48);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Riferimenti della banca";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(8, 16);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(224, 20);
			this.textBox1.TabIndex = 0;
			this.textBox1.Tag = "banktransaction.bankreference";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 180);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(96, 23);
			this.label4.TabIndex = 7;
			this.label4.Text = "Importo dell\'esito:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtImportoEsito
			// 
			this.txtImportoEsito.Location = new System.Drawing.Point(104, 180);
			this.txtImportoEsito.Name = "txtImportoEsito";
			this.txtImportoEsito.Size = new System.Drawing.Size(136, 20);
			this.txtImportoEsito.TabIndex = 2;
			this.txtImportoEsito.Tag = "banktransaction.amount";
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnAnnulla.Location = new System.Drawing.Point(432, 335);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.Size = new System.Drawing.Size(72, 24);
			this.btnAnnulla.TabIndex = 6;
			this.btnAnnulla.Text = "Annulla";
			// 
			// btnOk
			// 
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(336, 335);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(72, 24);
			this.btnOk.TabIndex = 5;
			this.btnOk.Tag = "mainsave";
			this.btnOk.Text = "OK";
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.txtidpay);
			this.groupBox5.Controls.Add(this.label8);
			this.groupBox5.Controls.Add(this.txtnpay);
			this.groupBox5.Controls.Add(this.txtypay);
			this.groupBox5.Controls.Add(this.label7);
			this.groupBox5.Controls.Add(this.label6);
			this.groupBox5.Controls.Add(this.btnProceeds);
			this.groupBox5.Location = new System.Drawing.Point(8, 8);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(496, 48);
			this.groupBox5.TabIndex = 8;
			this.groupBox5.TabStop = false;
			this.groupBox5.Tag = "AutoChoose.txtidpay.default";
			this.groupBox5.Text = "Movimento Bancario";
			// 
			// txtidpay
			// 
			this.txtidpay.Location = new System.Drawing.Point(416, 16);
			this.txtidpay.Name = "txtidpay";
			this.txtidpay.Size = new System.Drawing.Size(72, 20);
			this.txtidpay.TabIndex = 6;
			this.txtidpay.Tag = "payment_bankview.idpay?banktransaction.idpay";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(344, 20);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(64, 16);
			this.label8.TabIndex = 5;
			this.label8.Text = "Progressivo:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// txtnpay
			// 
			this.txtnpay.Location = new System.Drawing.Point(264, 16);
			this.txtnpay.Name = "txtnpay";
			this.txtnpay.ReadOnly = true;
			this.txtnpay.Size = new System.Drawing.Size(72, 20);
			this.txtnpay.TabIndex = 4;
			this.txtnpay.Tag = "payment_bankview.npay?x.x";
			// 
			// txtypay
			// 
			this.txtypay.Location = new System.Drawing.Point(160, 16);
			this.txtypay.Name = "txtypay";
			this.txtypay.ReadOnly = true;
			this.txtypay.Size = new System.Drawing.Size(48, 20);
			this.txtypay.TabIndex = 3;
			this.txtypay.Tag = "payment_bankview.ypay.year?x.x";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(216, 20);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(48, 16);
			this.label7.TabIndex = 2;
			this.label7.Text = "Numero:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(104, 20);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(56, 16);
			this.label6.TabIndex = 1;
			this.label6.Text = "Esercizio:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// btnProceeds
			// 
			this.btnProceeds.Location = new System.Drawing.Point(8, 16);
			this.btnProceeds.Name = "btnProceeds";
			this.btnProceeds.Size = new System.Drawing.Size(88, 23);
			this.btnProceeds.TabIndex = 0;
			this.btnProceeds.Tag = "choose.payment_bank.default";
			this.btnProceeds.Text = "Mov. Bancario";
			// 
			// grpMovSpesa
			// 
			this.grpMovSpesa.Controls.Add(this.txtNumMovSpesa);
			this.grpMovSpesa.Controls.Add(this.txtEsercMovSpesa);
			this.grpMovSpesa.Controls.Add(this.label9);
			this.grpMovSpesa.Controls.Add(this.label10);
			this.grpMovSpesa.Controls.Add(this.btnMovSpesa);
			this.grpMovSpesa.Location = new System.Drawing.Point(8, 64);
			this.grpMovSpesa.Name = "grpMovSpesa";
			this.grpMovSpesa.Size = new System.Drawing.Size(496, 48);
			this.grpMovSpesa.TabIndex = 9;
			this.grpMovSpesa.TabStop = false;
			this.grpMovSpesa.Tag = "AutoChoose.txtNumMovSpesa.default";
			this.grpMovSpesa.Text = "Movimento di Spesa";
			// 
			// txtNumMovSpesa
			// 
			this.txtNumMovSpesa.Location = new System.Drawing.Point(264, 14);
			this.txtNumMovSpesa.Name = "txtNumMovSpesa";
			this.txtNumMovSpesa.Size = new System.Drawing.Size(72, 20);
			this.txtNumMovSpesa.TabIndex = 8;
			this.txtNumMovSpesa.Tag = "expenseview.nmov?x.x";
			// 
			// txtEsercMovSpesa
			// 
			this.txtEsercMovSpesa.Location = new System.Drawing.Point(160, 14);
			this.txtEsercMovSpesa.Name = "txtEsercMovSpesa";
			this.txtEsercMovSpesa.ReadOnly = true;
			this.txtEsercMovSpesa.Size = new System.Drawing.Size(48, 20);
			this.txtEsercMovSpesa.TabIndex = 7;
			this.txtEsercMovSpesa.Tag = "expenseview.ymov.year?x.x";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(216, 18);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(48, 16);
			this.label9.TabIndex = 6;
			this.label9.Text = "Numero:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(104, 18);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(56, 16);
			this.label10.TabIndex = 5;
			this.label10.Text = "Esercizio:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// btnMovSpesa
			// 
			this.btnMovSpesa.Location = new System.Drawing.Point(8, 16);
			this.btnMovSpesa.Name = "btnMovSpesa";
			this.btnMovSpesa.Size = new System.Drawing.Size(88, 23);
			this.btnMovSpesa.TabIndex = 0;
			this.btnMovSpesa.Tag = "choose.expenseview.default";
			this.btnMovSpesa.Text = "movimento";
			// 
			// Frm_banktransaction_payment
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(512, 371);
			this.Controls.Add(this.grpMovSpesa);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnAnnulla);
			this.Controls.Add(this.btnOk);
			this.Name = "Frm_banktransaction_payment";
			this.Text = "Frm_banktransaction_payment";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.grpMovSpesa.ResumeLayout(false);
			this.grpMovSpesa.PerformLayout();
			this.ResumeLayout(false);

		}
		#endregion
	}
}
