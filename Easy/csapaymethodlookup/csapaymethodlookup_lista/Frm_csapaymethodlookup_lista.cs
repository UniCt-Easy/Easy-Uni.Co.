/*
    Easy
    Copyright (C) 2020 Universit√† degli Studi di Catania (www.unict.it)
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
using System.Data;
using System.Windows.Forms;
using metadatalibrary;
using funzioni_configurazione;

namespace csapaymethodlookup_lista
{
	/// <summary>
    /// Summary description for frmcsapaymethodlookup_lista.
	/// </summary>
	public class Frm_csapaymethodlookup_lista : System.Windows.Forms.Form
	{
        public System.Windows.Forms.Panel MetaDataDetail;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtDescrizione;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtCodice;
		public vistaForm DS;
        MetaData Meta;
        private System.Windows.Forms.ImageList images;
		private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private ComboBox cmbModalita;
        private Button ModalitaButton;
        private ComboBox cmbChargeHandling;
        private Button btnChargeHandling;
        private CheckBox chkEsenteSpese;
        private System.ComponentModel.IContainer components;

		public Frm_csapaymethodlookup_lista()
		{
			InitializeComponent();
        }

        CQueryHelper QHC;
        QueryHelper QHS;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            //GetData.CacheTable(DS.currency);
            bool FlagEsenteBanca = LeggiFlagEsenteBancaPredefinita();
            chkEsenteSpese.Visible = FlagEsenteBanca;
        }

        private bool LeggiFlagEsenteBancaPredefinita() {
            DataTable tTreasurer = Meta.Conn.RUN_SELECT("treasurer", "*", null, QHS.AppAnd(QHS.CmpEq("flagdefault", "S"), QHS.BitSet("flag", 1)), null, false);
            if (tTreasurer.Rows.Count == 0) return false;
            else
                return true;
        }

        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
       
            if (Meta.IsEmpty) return;
            switch (T.TableName) {
             
                case "chargehandling": {
                        if (R != null) {
                            if (LeggiFlagEsenteBancaPredefinita()) {
                                int flag_exemption = (CfgFn.GetNoNullInt32(R["flag"]) & 1);
                                chkEsenteSpese.Checked = !((flag_exemption & 1) == 0);
                            }

                        }

                        break;
                    }
            }
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_csapaymethodlookup_lista));
            this.MetaDataDetail = new System.Windows.Forms.Panel();
            this.DS = new csapaymethodlookup_lista.vistaForm();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbModalita = new System.Windows.Forms.ComboBox();
            this.ModalitaButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodice = new System.Windows.Forms.TextBox();
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbChargeHandling = new System.Windows.Forms.ComboBox();
            this.btnChargeHandling = new System.Windows.Forms.Button();
            this.chkEsenteSpese = new System.Windows.Forms.CheckBox();
            this.MetaDataDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // MetaDataDetail
            // 
            this.MetaDataDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MetaDataDetail.Controls.Add(this.groupBox2);
            this.MetaDataDetail.Location = new System.Drawing.Point(12, 111);
            this.MetaDataDetail.Name = "MetaDataDetail";
            this.MetaDataDetail.Size = new System.Drawing.Size(474, 125);
            this.MetaDataDetail.TabIndex = 25;
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbChargeHandling);
            this.groupBox2.Controls.Add(this.btnChargeHandling);
            this.groupBox2.Controls.Add(this.chkEsenteSpese);
            this.groupBox2.Controls.Add(this.cmbModalita);
            this.groupBox2.Controls.Add(this.ModalitaButton);
            this.groupBox2.Location = new System.Drawing.Point(0, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(471, 116);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Corrispondenza Easy";
            // 
            // cmbModalita
            // 
            this.cmbModalita.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbModalita.DataSource = this.DS.paymethod;
            this.cmbModalita.DisplayMember = "description";
            this.cmbModalita.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModalita.Location = new System.Drawing.Point(117, 21);
            this.cmbModalita.Name = "cmbModalita";
            this.cmbModalita.Size = new System.Drawing.Size(348, 21);
            this.cmbModalita.TabIndex = 31;
            this.cmbModalita.Tag = "csapaymethodlookup.idpaymethod";
            this.cmbModalita.ValueMember = "idpaymethod";
            // 
            // ModalitaButton
            // 
            this.ModalitaButton.Location = new System.Drawing.Point(21, 19);
            this.ModalitaButton.Name = "ModalitaButton";
            this.ModalitaButton.Size = new System.Drawing.Size(80, 23);
            this.ModalitaButton.TabIndex = 30;
            this.ModalitaButton.TabStop = false;
            this.ModalitaButton.Tag = "manage.paymethod.anagrafica";
            this.ModalitaButton.Text = "Tipo Modalit‡";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Descrizione:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizione.Location = new System.Drawing.Point(117, 40);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(334, 42);
            this.txtDescrizione.TabIndex = 2;
            this.txtDescrizione.Tag = "csapaymethodlookup.csa_description";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Codice Modalit‡ CSA:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCodice
            // 
            this.txtCodice.Location = new System.Drawing.Point(117, 14);
            this.txtCodice.Name = "txtCodice";
            this.txtCodice.Size = new System.Drawing.Size(113, 20);
            this.txtCodice.TabIndex = 1;
            this.txtCodice.Tag = "csapaymethodlookup.csa_kind";
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
            this.images.Images.SetKeyName(6, "");
            this.images.Images.SetKeyName(7, "");
            this.images.Images.SetKeyName(8, "");
            this.images.Images.SetKeyName(9, "");
            this.images.Images.SetKeyName(10, "");
            this.images.Images.SetKeyName(11, "");
            this.images.Images.SetKeyName(12, "");
            this.images.Images.SetKeyName(13, "");
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtCodice);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtDescrizione);
            this.groupBox3.Location = new System.Drawing.Point(12, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(474, 97);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Dettagli CSA";
            // 
            // cmbChargeHandling
            // 
            this.cmbChargeHandling.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbChargeHandling.DataSource = this.DS.chargehandling;
            this.cmbChargeHandling.DisplayMember = "description";
            this.cmbChargeHandling.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChargeHandling.Location = new System.Drawing.Point(22, 88);
            this.cmbChargeHandling.Name = "cmbChargeHandling";
            this.cmbChargeHandling.Size = new System.Drawing.Size(308, 21);
            this.cmbChargeHandling.TabIndex = 86;
            this.cmbChargeHandling.Tag = "csapaymethodlookup.idchargehandling";
            this.cmbChargeHandling.ValueMember = "idchargehandling";
            // 
            // btnChargeHandling
            // 
            this.btnChargeHandling.Location = new System.Drawing.Point(22, 62);
            this.btnChargeHandling.Name = "btnChargeHandling";
            this.btnChargeHandling.Size = new System.Drawing.Size(80, 23);
            this.btnChargeHandling.TabIndex = 85;
            this.btnChargeHandling.TabStop = false;
            this.btnChargeHandling.Tag = "choose.chargehandling.default.(active<>\'N\')";
            this.btnChargeHandling.Text = "Tratt. Spese";
            // 
            // chkEsenteSpese
            // 
            this.chkEsenteSpese.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkEsenteSpese.Location = new System.Drawing.Point(119, 62);
            this.chkEsenteSpese.Name = "chkEsenteSpese";
            this.chkEsenteSpese.Size = new System.Drawing.Size(192, 24);
            this.chkEsenteSpese.TabIndex = 84;
            this.chkEsenteSpese.Tag = "csapaymethodlookup.flag:0";
            this.chkEsenteSpese.Text = "Esente da Spese Bancarie";
            // 
            // Frm_csapaymethodlookup_lista
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(498, 248);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.MetaDataDetail);
            this.Name = "Frm_csapaymethodlookup_lista";
            this.Text = "frmlookupModalitaPagamentoCSA";
            this.MetaDataDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion


    }
}
