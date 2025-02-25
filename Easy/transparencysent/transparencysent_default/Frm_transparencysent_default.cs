
/*
Easy
Copyright (C) 2025 Università degli Studi di Catania (www.unict.it)
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
using metadatalibrary;
using funzioni_configurazione;
namespace transparencysent_default
{
	/// <summary>
	/// </summary>
    public class Frm_transparencysent_default : MetaDataForm {
        private System.Windows.Forms.ImageList images;
        public vistaForm DS;
        MetaData Meta;
        private GroupBox groupCredDeb;
        private TextBox txtCredDeb;
        private Label label3;
        private TextBox txtDipartimento;
        private CheckBox chkActive;
        private Label label2;
        private TextBox txtIdSent;
        private TextBox txtDescription;
        private Label label1;
		private TextBox txtCfForeignCf;
		private Label label4;
		private TextBox textBox5;
		private Label label5;
		private TextBox txtData_Transazione;
		private Label label6;
		private TextBox txtImporto_Pagato;
		private Label label7;
		private TextBox txtIdExp;
		private Label label8;
		private TextBox txtIdSorSiope;
		private Label label9;
		private TextBox txtSortCodeSiope;
		private Label label10;
		private TextBox txtDescriptionSiope;
		private Label label11;
		private TextBox txtIdentificativoServizio;
		private Label label12;
		private GroupBox grpTransmStatus;
		private RadioButton radDaModificare;
		private RadioButton radDaAnnullare;
		private RadioButton radInviata;
		private TextBox txtTipologia_Spesa;
		private TextBox txtAmbito_Temporale;
		private Label label13;
		private Label label14;
		private TextBox txtAyear;
		private Label label15;
		private System.ComponentModel.IContainer components;

		public Frm_transparencysent_default()
		{
			InitializeComponent();
			HelpForm.SetDenyNull(DS.transparencysent.Columns["active"], true);
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
        CQueryHelper QHC;
        QueryHelper QHS;
		
        public void MetaData_AfterLink () {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
			GetData.SetStaticFilter(DS.transparencysent, QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
		}

        public void MetaData_AfterFill () {
            if (Meta.IsEmpty) return;
			if(Meta.EditMode)
				AbilitaDisabilita(false);
		}

        public void MetaData_AfterClear () {
			AbilitaDisabilita(true);
		}
		public void AbilitaDisabilita(bool abilita) {
			chkActive.Enabled = abilita;
			groupCredDeb.Enabled = abilita;
			grpTransmStatus.Enabled = abilita;
			txtAmbito_Temporale.ReadOnly = !abilita;
			txtAyear.ReadOnly = !abilita;
			txtCfForeignCf.ReadOnly = !abilita;
			txtCredDeb.ReadOnly = !abilita;
			txtData_Transazione.ReadOnly = !abilita;
			txtDescription.ReadOnly = !abilita;
			txtDescriptionSiope.ReadOnly = !abilita;
			txtDipartimento.ReadOnly = !abilita;
			txtIdentificativoServizio.ReadOnly = !abilita;
			txtIdExp.ReadOnly = !abilita;
			txtIdSent.ReadOnly = !abilita;
			txtIdSorSiope.ReadOnly = !abilita;
			txtImporto_Pagato.ReadOnly = !abilita;
			txtSortCodeSiope.ReadOnly = !abilita;
			txtTipologia_Spesa.ReadOnly = !abilita;
		}

			public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
			if (Meta.IsEmpty) return;
            
			}
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_transparencysent_default));
			this.images = new System.Windows.Forms.ImageList(this.components);
			this.groupCredDeb = new System.Windows.Forms.GroupBox();
			this.txtCredDeb = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtDipartimento = new System.Windows.Forms.TextBox();
			this.chkActive = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtIdSent = new System.Windows.Forms.TextBox();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtCfForeignCf = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtData_Transazione = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtImporto_Pagato = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtIdExp = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtIdSorSiope = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtSortCodeSiope = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.txtDescriptionSiope = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.txtIdentificativoServizio = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.grpTransmStatus = new System.Windows.Forms.GroupBox();
			this.radDaModificare = new System.Windows.Forms.RadioButton();
			this.radDaAnnullare = new System.Windows.Forms.RadioButton();
			this.radInviata = new System.Windows.Forms.RadioButton();
			this.txtTipologia_Spesa = new System.Windows.Forms.TextBox();
			this.txtAmbito_Temporale = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.DS = new transparencysent_default.vistaForm();
			this.txtAyear = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.groupCredDeb.SuspendLayout();
			this.grpTransmStatus.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
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
			// groupCredDeb
			// 
			this.groupCredDeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupCredDeb.Controls.Add(this.txtCredDeb);
			this.groupCredDeb.Location = new System.Drawing.Point(12, 320);
			this.groupCredDeb.Name = "groupCredDeb";
			this.groupCredDeb.Size = new System.Drawing.Size(582, 56);
			this.groupCredDeb.TabIndex = 5;
			this.groupCredDeb.TabStop = false;
			this.groupCredDeb.Tag = "";
			this.groupCredDeb.Text = "Ragione Sociale";
			// 
			// txtCredDeb
			// 
			this.txtCredDeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCredDeb.Location = new System.Drawing.Point(8, 24);
			this.txtCredDeb.Name = "txtCredDeb";
			this.txtCredDeb.Size = new System.Drawing.Size(566, 20);
			this.txtCredDeb.TabIndex = 0;
			this.txtCredDeb.Tag = "transparencysent.ragione_sociale";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(18, 156);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 16);
			this.label3.TabIndex = 0;
			this.label3.Text = "Dipartimento;";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDipartimento
			// 
			this.txtDipartimento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDipartimento.Location = new System.Drawing.Point(96, 153);
			this.txtDipartimento.Name = "txtDipartimento";
			this.txtDipartimento.Size = new System.Drawing.Size(498, 20);
			this.txtDipartimento.TabIndex = 4;
			this.txtDipartimento.Tag = "transparencysent.dipartimento";
			// 
			// chkActive
			// 
			this.chkActive.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.chkActive.Location = new System.Drawing.Point(396, 13);
			this.chkActive.Name = "chkActive";
			this.chkActive.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.chkActive.Size = new System.Drawing.Size(190, 22);
			this.chkActive.TabIndex = 2;
			this.chkActive.Tag = "transparencysent.active:S:N";
			this.chkActive.Text = "Attivo";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(7, 272);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 16);
			this.label2.TabIndex = 0;
			this.label2.Text = "Descrizione:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtIdSent
			// 
			this.txtIdSent.Location = new System.Drawing.Point(321, 14);
			this.txtIdSent.Name = "txtIdSent";
			this.txtIdSent.Size = new System.Drawing.Size(69, 20);
			this.txtIdSent.TabIndex = 1;
			this.txtIdSent.Tag = "transparencysent.idsent";
			// 
			// txtDescription
			// 
			this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescription.Location = new System.Drawing.Point(94, 268);
			this.txtDescription.Multiline = true;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(500, 49);
			this.txtDescription.TabIndex = 3;
			this.txtDescription.Tag = "transparencysent.description";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(171, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(147, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Num. trasmissione:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtCfForeignCf
			// 
			this.txtCfForeignCf.Location = new System.Drawing.Point(90, 380);
			this.txtCfForeignCf.Name = "txtCfForeignCf";
			this.txtCfForeignCf.Size = new System.Drawing.Size(100, 20);
			this.txtCfForeignCf.TabIndex = 7;
			this.txtCfForeignCf.Tag = "transparencysent.cf_foreigncf";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(4, 379);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(83, 21);
			this.label4.TabIndex = 6;
			this.label4.Text = "Cod. Fiscale:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(90, 406);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(100, 20);
			this.textBox5.TabIndex = 9;
			this.textBox5.Tag = "transparencysent.p_iva";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(1, 404);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(83, 18);
			this.label5.TabIndex = 8;
			this.label5.Text = "Partita IVA:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtData_Transazione
			// 
			this.txtData_Transazione.Location = new System.Drawing.Point(364, 408);
			this.txtData_Transazione.Name = "txtData_Transazione";
			this.txtData_Transazione.Size = new System.Drawing.Size(100, 20);
			this.txtData_Transazione.TabIndex = 11;
			this.txtData_Transazione.Tag = "transparencysent.data_transazione";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(244, 410);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(114, 18);
			this.label6.TabIndex = 10;
			this.label6.Text = "Data Transazione:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtImporto_Pagato
			// 
			this.txtImporto_Pagato.Location = new System.Drawing.Point(364, 382);
			this.txtImporto_Pagato.Name = "txtImporto_Pagato";
			this.txtImporto_Pagato.Size = new System.Drawing.Size(100, 20);
			this.txtImporto_Pagato.TabIndex = 13;
			this.txtImporto_Pagato.Tag = "transparencysent.importo_pagato";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(244, 384);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(114, 18);
			this.label7.TabIndex = 12;
			this.label7.Text = "Importo Pagato:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtIdExp
			// 
			this.txtIdExp.Location = new System.Drawing.Point(90, 434);
			this.txtIdExp.Name = "txtIdExp";
			this.txtIdExp.Size = new System.Drawing.Size(100, 20);
			this.txtIdExp.TabIndex = 15;
			this.txtIdExp.Tag = "transparencysent.idexp";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(19, 434);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(68, 20);
			this.label8.TabIndex = 14;
			this.label8.Text = "# idexp:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtIdSorSiope
			// 
			this.txtIdSorSiope.Location = new System.Drawing.Point(95, 187);
			this.txtIdSorSiope.Name = "txtIdSorSiope";
			this.txtIdSorSiope.Size = new System.Drawing.Size(61, 20);
			this.txtIdSorSiope.TabIndex = 17;
			this.txtIdSorSiope.Tag = "transparencysent.idsor_siope";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(3, 187);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(84, 20);
			this.label9.TabIndex = 16;
			this.label9.Text = "# SIOPE:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtSortCodeSiope
			// 
			this.txtSortCodeSiope.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSortCodeSiope.Location = new System.Drawing.Point(247, 187);
			this.txtSortCodeSiope.Name = "txtSortCodeSiope";
			this.txtSortCodeSiope.Size = new System.Drawing.Size(347, 20);
			this.txtSortCodeSiope.TabIndex = 19;
			this.txtSortCodeSiope.Tag = "transparencysent.sortcode_siope";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(160, 187);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(84, 20);
			this.label10.TabIndex = 18;
			this.label10.Text = "Codice SIOPE:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDescriptionSiope
			// 
			this.txtDescriptionSiope.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescriptionSiope.Location = new System.Drawing.Point(95, 215);
			this.txtDescriptionSiope.Multiline = true;
			this.txtDescriptionSiope.Name = "txtDescriptionSiope";
			this.txtDescriptionSiope.Size = new System.Drawing.Size(499, 43);
			this.txtDescriptionSiope.TabIndex = 21;
			this.txtDescriptionSiope.Tag = "transparencysent.description_siope";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(8, 219);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(84, 30);
			this.label11.TabIndex = 20;
			this.label11.Text = "Descrizione SIOPE:";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtIdentificativoServizio
			// 
			this.txtIdentificativoServizio.Location = new System.Drawing.Point(95, 95);
			this.txtIdentificativoServizio.Multiline = true;
			this.txtIdentificativoServizio.Name = "txtIdentificativoServizio";
			this.txtIdentificativoServizio.Size = new System.Drawing.Size(134, 47);
			this.txtIdentificativoServizio.TabIndex = 22;
			this.txtIdentificativoServizio.Tag = "transparencysent.identificativo_servizio";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(19, 102);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(73, 33);
			this.label12.TabIndex = 23;
			this.label12.Text = "Identificativo servizio:";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// grpTransmStatus
			// 
			this.grpTransmStatus.Controls.Add(this.radDaModificare);
			this.grpTransmStatus.Controls.Add(this.radDaAnnullare);
			this.grpTransmStatus.Controls.Add(this.radInviata);
			this.grpTransmStatus.Location = new System.Drawing.Point(11, 43);
			this.grpTransmStatus.Name = "grpTransmStatus";
			this.grpTransmStatus.Size = new System.Drawing.Size(454, 46);
			this.grpTransmStatus.TabIndex = 28;
			this.grpTransmStatus.TabStop = false;
			this.grpTransmStatus.Text = "Stato della Trasmissione";
			// 
			// radDaModificare
			// 
			this.radDaModificare.AutoSize = true;
			this.radDaModificare.Location = new System.Drawing.Point(322, 19);
			this.radDaModificare.Name = "radDaModificare";
			this.radDaModificare.Size = new System.Drawing.Size(91, 17);
			this.radDaModificare.TabIndex = 3;
			this.radDaModificare.Tag = "transparencysent.flagtransmissionstatus:M";
			this.radDaModificare.Text = "Da Modificare";
			this.radDaModificare.UseVisualStyleBackColor = true;
			// 
			// radDaAnnullare
			// 
			this.radDaAnnullare.AutoSize = true;
			this.radDaAnnullare.Location = new System.Drawing.Point(144, 19);
			this.radDaAnnullare.Name = "radDaAnnullare";
			this.radDaAnnullare.Size = new System.Drawing.Size(86, 17);
			this.radDaAnnullare.TabIndex = 2;
			this.radDaAnnullare.Tag = "transparencysent.flagtransmissionstatus:D";
			this.radDaAnnullare.Text = "Da Annullare";
			this.radDaAnnullare.UseVisualStyleBackColor = true;
			// 
			// radInviata
			// 
			this.radInviata.AutoSize = true;
			this.radInviata.Checked = true;
			this.radInviata.Location = new System.Drawing.Point(9, 19);
			this.radInviata.Name = "radInviata";
			this.radInviata.Size = new System.Drawing.Size(57, 17);
			this.radInviata.TabIndex = 1;
			this.radInviata.TabStop = true;
			this.radInviata.Tag = "transparencysent.flagtransmissionstatus:I";
			this.radInviata.Text = "Inviata";
			this.radInviata.UseVisualStyleBackColor = true;
			// 
			// txtTipologia_Spesa
			// 
			this.txtTipologia_Spesa.Location = new System.Drawing.Point(337, 121);
			this.txtTipologia_Spesa.Name = "txtTipologia_Spesa";
			this.txtTipologia_Spesa.Size = new System.Drawing.Size(128, 20);
			this.txtTipologia_Spesa.TabIndex = 30;
			this.txtTipologia_Spesa.Tag = "transparencysent.tipologia_spesa";
			// 
			// txtAmbito_Temporale
			// 
			this.txtAmbito_Temporale.Location = new System.Drawing.Point(337, 96);
			this.txtAmbito_Temporale.Name = "txtAmbito_Temporale";
			this.txtAmbito_Temporale.Size = new System.Drawing.Size(127, 20);
			this.txtAmbito_Temporale.TabIndex = 29;
			this.txtAmbito_Temporale.Tag = "transparencysent.ambito_temporale";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(235, 96);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(100, 20);
			this.label13.TabIndex = 31;
			this.label13.Text = "Ambito Temporale:";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(234, 116);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(100, 20);
			this.label14.TabIndex = 32;
			this.label14.Text = "Tipologia Spesa:";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// txtAyear
			// 
			this.txtAyear.Location = new System.Drawing.Point(146, 15);
			this.txtAyear.Name = "txtAyear";
			this.txtAyear.ReadOnly = true;
			this.txtAyear.Size = new System.Drawing.Size(69, 20);
			this.txtAyear.TabIndex = 34;
			this.txtAyear.Tag = "transparencysent.ayear";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(61, 15);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(82, 17);
			this.label15.TabIndex = 33;
			this.label15.Text = "Esercizio:";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// Frm_transparencysent_default
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(606, 498);
			this.Controls.Add(this.txtAyear);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.txtTipologia_Spesa);
			this.Controls.Add(this.txtAmbito_Temporale);
			this.Controls.Add(this.grpTransmStatus);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.txtIdentificativoServizio);
			this.Controls.Add(this.txtDescriptionSiope);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.txtSortCodeSiope);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.txtIdSorSiope);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.txtIdExp);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.txtImporto_Pagato);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.txtData_Transazione);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.textBox5);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtCfForeignCf);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.groupCredDeb);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtDipartimento);
			this.Controls.Add(this.chkActive);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtIdSent);
			this.Controls.Add(this.txtDescription);
			this.Controls.Add(this.label1);
			this.Name = "Frm_transparencysent_default";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Comunicazioni trasmesse in Trasparenza";
			this.groupCredDeb.ResumeLayout(false);
			this.groupCredDeb.PerformLayout();
			this.grpTransmStatus.ResumeLayout(false);
			this.grpTransmStatus.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion
	}
}
