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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using System.Data;
using funzioni_configurazione;//funzioni_configurazione

namespace csa_agencypaymethod_anagrafica {//PagamentoAnagrafica//
	/// <summary>
	/// Summary description for frmPagamentoAnagrafica.
	/// </summary>
	public class Frm_csa_agencypaymethod_anagrafica : System.Windows.Forms.Form {
        MetaData Meta;
      	private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancButton;
        public vistaForm DS;
        private GroupBox GBoxPagamento;
        private TextBox txtModPagamento;
        private Button btnSelModalita;
        private Label label11;
        private TextBox txtIBAN;
        private TextBox txtRifDocumentoEsterno;
        private Label label9;
        private TextBox txtDelegato;
        private Label label7;
        private ComboBox cmbModPagamento;
        private Label label38;
        private TextBox txtDescrModPagamento;
        private Label label40;
        private Label label32;
        private Label label35;
        private Label label36;
        private Label label37;
        private Label label39;
        private TextBox txtContoCorrente;
        private TextBox txtSportello;
        private TextBox txtBanca;
        private TextBox txtCin;
        private TextBox textBox4;
        private Label label10;
        private TextBox tipo;
        private Label label2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_csa_agencypaymethod_anagrafica() {
			InitializeComponent();
            DataAccess.SetTableForReading(DS.deputy, "registry");
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
            this.OkButton = new System.Windows.Forms.Button();
            this.CancButton = new System.Windows.Forms.Button();
            this.DS = new csa_agencypaymethod_anagrafica.vistaForm();
            this.GBoxPagamento = new System.Windows.Forms.GroupBox();
            this.txtModPagamento = new System.Windows.Forms.TextBox();
            this.btnSelModalita = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtIBAN = new System.Windows.Forms.TextBox();
            this.txtRifDocumentoEsterno = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDelegato = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbModPagamento = new System.Windows.Forms.ComboBox();
            this.label38 = new System.Windows.Forms.Label();
            this.txtDescrModPagamento = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.txtContoCorrente = new System.Windows.Forms.TextBox();
            this.txtSportello = new System.Windows.Forms.TextBox();
            this.txtBanca = new System.Windows.Forms.TextBox();
            this.txtCin = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tipo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.GBoxPagamento.SuspendLayout();
            this.SuspendLayout();
            // 
            // OkButton
            // 
            this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Location = new System.Drawing.Point(360, 354);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 5;
            this.OkButton.Tag = "mainsave";
            this.OkButton.Text = "Ok";
            // 
            // CancButton
            // 
            this.CancButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CancButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancButton.Location = new System.Drawing.Point(448, 354);
            this.CancButton.Name = "CancButton";
            this.CancButton.Size = new System.Drawing.Size(75, 23);
            this.CancButton.TabIndex = 6;
            this.CancButton.Text = "Annulla";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // GBoxPagamento
            // 
            this.GBoxPagamento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GBoxPagamento.Controls.Add(this.txtModPagamento);
            this.GBoxPagamento.Controls.Add(this.btnSelModalita);
            this.GBoxPagamento.Controls.Add(this.label11);
            this.GBoxPagamento.Controls.Add(this.txtIBAN);
            this.GBoxPagamento.Controls.Add(this.txtRifDocumentoEsterno);
            this.GBoxPagamento.Controls.Add(this.label9);
            this.GBoxPagamento.Controls.Add(this.txtDelegato);
            this.GBoxPagamento.Controls.Add(this.label7);
            this.GBoxPagamento.Controls.Add(this.cmbModPagamento);
            this.GBoxPagamento.Controls.Add(this.label38);
            this.GBoxPagamento.Controls.Add(this.txtDescrModPagamento);
            this.GBoxPagamento.Controls.Add(this.label40);
            this.GBoxPagamento.Controls.Add(this.label32);
            this.GBoxPagamento.Controls.Add(this.label35);
            this.GBoxPagamento.Controls.Add(this.label36);
            this.GBoxPagamento.Controls.Add(this.label37);
            this.GBoxPagamento.Controls.Add(this.label39);
            this.GBoxPagamento.Controls.Add(this.txtContoCorrente);
            this.GBoxPagamento.Controls.Add(this.txtSportello);
            this.GBoxPagamento.Controls.Add(this.txtBanca);
            this.GBoxPagamento.Controls.Add(this.txtCin);
            this.GBoxPagamento.Location = new System.Drawing.Point(12, 78);
            this.GBoxPagamento.Name = "GBoxPagamento";
            this.GBoxPagamento.Size = new System.Drawing.Size(596, 264);
            this.GBoxPagamento.TabIndex = 4;
            this.GBoxPagamento.TabStop = false;
            this.GBoxPagamento.Text = "Modalità di pagamento dell\'Anagrafica associata ";
            // 
            // txtModPagamento
            // 
            this.txtModPagamento.Location = new System.Drawing.Point(240, 24);
            this.txtModPagamento.Name = "txtModPagamento";
            this.txtModPagamento.ReadOnly = true;
            this.txtModPagamento.Size = new System.Drawing.Size(338, 20);
            this.txtModPagamento.TabIndex = 3;
            this.txtModPagamento.TabStop = false;
            this.txtModPagamento.Tag = "registrypaymethod.regmodcode";
            // 
            // btnSelModalita
            // 
            this.btnSelModalita.Location = new System.Drawing.Point(96, 23);
            this.btnSelModalita.Name = "btnSelModalita";
            this.btnSelModalita.Size = new System.Drawing.Size(136, 23);
            this.btnSelModalita.TabIndex = 1;
            this.btnSelModalita.TabStop = false;
            this.btnSelModalita.Text = "Seleziona Modalità";
            this.btnSelModalita.UseVisualStyleBackColor = true;
            this.btnSelModalita.Click += new System.EventHandler(this.btnSelModalita_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(72, 82);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 6;
            this.label11.Tag = "";
            this.label11.Text = "IBAN:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtIBAN
            // 
            this.txtIBAN.Enabled = false;
            this.txtIBAN.Location = new System.Drawing.Point(6, 98);
            this.txtIBAN.Name = "txtIBAN";
            this.txtIBAN.ReadOnly = true;
            this.txtIBAN.Size = new System.Drawing.Size(186, 20);
            this.txtIBAN.TabIndex = 7;
            this.txtIBAN.Tag = "registrypaymethod .iban";
            // 
            // txtRifDocumentoEsterno
            // 
            this.txtRifDocumentoEsterno.Location = new System.Drawing.Point(240, 232);
            this.txtRifDocumentoEsterno.Name = "txtRifDocumentoEsterno";
            this.txtRifDocumentoEsterno.ReadOnly = true;
            this.txtRifDocumentoEsterno.Size = new System.Drawing.Size(100, 20);
            this.txtRifDocumentoEsterno.TabIndex = 0;
            this.txtRifDocumentoEsterno.TabStop = false;
            this.txtRifDocumentoEsterno.Tag = "registrypaymethod .refexternaldoc";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(24, 232);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(208, 16);
            this.label9.TabIndex = 20;
            this.label9.Text = "Riferimento Documento Esterno:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDelegato
            // 
            this.txtDelegato.Location = new System.Drawing.Point(240, 200);
            this.txtDelegato.Name = "txtDelegato";
            this.txtDelegato.ReadOnly = true;
            this.txtDelegato.Size = new System.Drawing.Size(304, 20);
            this.txtDelegato.TabIndex = 19;
            this.txtDelegato.TabStop = false;
            this.txtDelegato.Tag = "deputy.title";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(176, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 23);
            this.label7.TabIndex = 18;
            this.label7.Text = "Delegato:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbModPagamento
            // 
            this.cmbModPagamento.DataSource = this.DS.paymethod;
            this.cmbModPagamento.DisplayMember = "description";
            this.cmbModPagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModPagamento.Enabled = false;
            this.cmbModPagamento.Location = new System.Drawing.Point(240, 56);
            this.cmbModPagamento.Name = "cmbModPagamento";
            this.cmbModPagamento.Size = new System.Drawing.Size(338, 21);
            this.cmbModPagamento.TabIndex = 5;
            this.cmbModPagamento.Tag = "registrypaymethod .idpaymethod";
            this.cmbModPagamento.ValueMember = "idpaymethod";
            // 
            // label38
            // 
            this.label38.Location = new System.Drawing.Point(136, 144);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(96, 20);
            this.label38.TabIndex = 16;
            this.label38.Tag = "";
            this.label38.Text = "Descrizione:";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDescrModPagamento
            // 
            this.txtDescrModPagamento.Location = new System.Drawing.Point(240, 144);
            this.txtDescrModPagamento.Multiline = true;
            this.txtDescrModPagamento.Name = "txtDescrModPagamento";
            this.txtDescrModPagamento.ReadOnly = true;
            this.txtDescrModPagamento.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescrModPagamento.Size = new System.Drawing.Size(304, 48);
            this.txtDescrModPagamento.TabIndex = 17;
            this.txtDescrModPagamento.TabStop = false;
            this.txtDescrModPagamento.Tag = "registrypaymethod .paymentdescr";
            // 
            // label40
            // 
            this.label40.Location = new System.Drawing.Point(136, 55);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(96, 20);
            this.label40.TabIndex = 4;
            this.label40.Tag = "";
            this.label40.Text = "Tipo Modalità:";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label32
            // 
            this.label32.Location = new System.Drawing.Point(136, 112);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(96, 20);
            this.label32.TabIndex = 10;
            this.label32.Tag = "";
            this.label32.Text = "C/C:";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label35
            // 
            this.label35.Location = new System.Drawing.Point(376, 88);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(56, 20);
            this.label35.TabIndex = 12;
            this.label35.Tag = "";
            this.label35.Text = "CAB:";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label36
            // 
            this.label36.Location = new System.Drawing.Point(136, 88);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(96, 20);
            this.label36.TabIndex = 8;
            this.label36.Tag = "";
            this.label36.Text = "ABI:";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label37
            // 
            this.label37.Location = new System.Drawing.Point(376, 120);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(56, 20);
            this.label37.TabIndex = 14;
            this.label37.Tag = "";
            this.label37.Text = "CIN:";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label39
            // 
            this.label39.Location = new System.Drawing.Point(136, 24);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(96, 21);
            this.label39.TabIndex = 2;
            this.label39.Tag = "";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtContoCorrente
            // 
            this.txtContoCorrente.Location = new System.Drawing.Point(240, 112);
            this.txtContoCorrente.Name = "txtContoCorrente";
            this.txtContoCorrente.ReadOnly = true;
            this.txtContoCorrente.Size = new System.Drawing.Size(88, 20);
            this.txtContoCorrente.TabIndex = 11;
            this.txtContoCorrente.Tag = "registrypaymethod .cc";
            // 
            // txtSportello
            // 
            this.txtSportello.Location = new System.Drawing.Point(440, 88);
            this.txtSportello.Name = "txtSportello";
            this.txtSportello.ReadOnly = true;
            this.txtSportello.Size = new System.Drawing.Size(104, 20);
            this.txtSportello.TabIndex = 13;
            this.txtSportello.Tag = "registrypaymethod .idcab";
            // 
            // txtBanca
            // 
            this.txtBanca.Location = new System.Drawing.Point(240, 88);
            this.txtBanca.Name = "txtBanca";
            this.txtBanca.ReadOnly = true;
            this.txtBanca.Size = new System.Drawing.Size(88, 20);
            this.txtBanca.TabIndex = 9;
            this.txtBanca.Tag = "registrypaymethod .idbank";
            // 
            // txtCin
            // 
            this.txtCin.Location = new System.Drawing.Point(440, 120);
            this.txtCin.Name = "txtCin";
            this.txtCin.ReadOnly = true;
            this.txtCin.Size = new System.Drawing.Size(104, 20);
            this.txtCin.TabIndex = 15;
            this.txtCin.Tag = "registrypaymethod .cin";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(108, 12);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(69, 20);
            this.textBox4.TabIndex = 1;
            this.textBox4.Tag = "csa_agencypaymethod.idcsa_agencypaymethod";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(82, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "#";
            // 
            // tipo
            // 
            this.tipo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tipo.Location = new System.Drawing.Point(109, 41);
            this.tipo.Name = "tipo";
            this.tipo.Size = new System.Drawing.Size(492, 20);
            this.tipo.TabIndex = 2;
            this.tipo.Tag = "csa_agencypaymethod.vocecsa";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 41);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(88, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Voce CSA:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Frm_csa_agencypaymethod_anagrafica
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.CancButton;
            this.ClientSize = new System.Drawing.Size(620, 384);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tipo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.GBoxPagamento);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.CancButton);
            this.Name = "Frm_csa_agencypaymethod_anagrafica";
            this.Text = "frmPagamentoAnagrafica";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.GBoxPagamento.ResumeLayout(false);
            this.GBoxPagamento.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
        
        CQueryHelper QHC;
        QueryHelper QHS;
		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            DataRow Source = Meta.SourceRow;
            DataRow R = Source.GetParentRow("csa_agency_csa_agencypaymethod"); ;
            string filter = QHS.CmpEq("idreg", R["idreg"]);
            if (CfgFn.GetNoNullInt32(R["idreg"]) == 0) {
                MessageBox.Show(this, "Selezionare prima l'anagrafica", "Avviso");
                return;
            }
            GetData.SetStaticFilter(DS.registrypaymethod, filter);		
         }

        private void btnSelModalita_Click (object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            Meta.GetFormData(true);
            string filter = QHS.CmpEq("active","S");
            Meta.DoMainCommand("choose.registrypaymethod.default." + filter);
        }
        public void MetaData_AfterRowSelect (DataTable T, DataRow R) {
            if (!Meta.DrawStateIsDone) return;
            if (T.TableName == "registrypaymethod") {
                if (R != null) CollegaModalita(R);
            }
        }
        void CollegaModalita (DataRow RegistryPayMethod) {
            if (Meta.IsEmpty) return;
            Meta.GetFormData(true);
            DataRow Curr = DS.csa_agencypaymethod.Rows[0];
            Curr["idregistrypaymethod"] = RegistryPayMethod["idregistrypaymethod"];
            
        }
    }
}