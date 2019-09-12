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

namespace registryaddress_default {//cdindirizzo//
	/// <summary>
	/// Summary description for frmcdindirizzo.
	/// </summary>
	public class Frm_registryaddress_default : System.Windows.Forms.Form {
		private System.Windows.Forms.TextBox txtAppunti;
		private System.Windows.Forms.TextBox txtIndirizzo;
		private System.Windows.Forms.TextBox txtNomeUfficio;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmbTipoIndirizzo;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupCredDeb;
		private System.Windows.Forms.TextBox txtCredDeb;
		private System.Windows.Forms.Label label7;
		public vistaForm DS;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private MetaData Meta;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.CheckBox chkEstero;
		private System.Windows.Forms.TextBox txtLocalita;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox grpEstero;
		private System.Windows.Forms.TextBox txtGeoNazione;
		private System.Windows.Forms.Label lblComuneStato;
		private System.Windows.Forms.GroupBox grpItaliano;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox txtProvincia;
		private System.Windows.Forms.TextBox txtLocalitaGeo;
		private System.Windows.Forms.Button buttonAggiornaComune;
		private System.Windows.Forms.TextBox textBoxCap;
		private System.Windows.Forms.TextBox txtDataInizio;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Label label12;
        private TextBox textBox1;
        private Label label14;
		private System.Windows.Forms.CheckBox ckbAttivo;

		public Frm_registryaddress_default() {
			InitializeComponent();
			HelpForm.SetDenyNull(DS.registryaddress.Columns["active"], true);
			DataAccess.SetTableForReading(DS.geo_nazione_alias, "geo_nation");
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_registryaddress_default));
            this.txtAppunti = new System.Windows.Forms.TextBox();
            this.txtIndirizzo = new System.Windows.Forms.TextBox();
            this.txtNomeUfficio = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtDataInizio = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTipoIndirizzo = new System.Windows.Forms.ComboBox();
            this.DS = new registryaddress_default.vistaForm();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupCredDeb = new System.Windows.Forms.GroupBox();
            this.txtCredDeb = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ckbAttivo = new System.Windows.Forms.CheckBox();
            this.textBoxCap = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkEstero = new System.Windows.Forms.CheckBox();
            this.txtLocalita = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.grpEstero = new System.Windows.Forms.GroupBox();
            this.txtGeoNazione = new System.Windows.Forms.TextBox();
            this.lblComuneStato = new System.Windows.Forms.Label();
            this.grpItaliano = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtProvincia = new System.Windows.Forms.TextBox();
            this.txtLocalitaGeo = new System.Windows.Forms.TextBox();
            this.buttonAggiornaComune = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupCredDeb.SuspendLayout();
            this.grpEstero.SuspendLayout();
            this.grpItaliano.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAppunti
            // 
            this.txtAppunti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAppunti.Location = new System.Drawing.Point(128, 430);
            this.txtAppunti.Multiline = true;
            this.txtAppunti.Name = "txtAppunti";
            this.txtAppunti.Size = new System.Drawing.Size(352, 162);
            this.txtAppunti.TabIndex = 12;
            this.txtAppunti.Tag = "registryaddress.annotations";
            // 
            // txtIndirizzo
            // 
            this.txtIndirizzo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIndirizzo.Location = new System.Drawing.Point(128, 283);
            this.txtIndirizzo.Name = "txtIndirizzo";
            this.txtIndirizzo.Size = new System.Drawing.Size(352, 20);
            this.txtIndirizzo.TabIndex = 5;
            this.txtIndirizzo.Tag = "registryaddress.address.indirizzo";
            // 
            // txtNomeUfficio
            // 
            this.txtNomeUfficio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNomeUfficio.Location = new System.Drawing.Point(214, 252);
            this.txtNomeUfficio.Name = "txtNomeUfficio";
            this.txtNomeUfficio.Size = new System.Drawing.Size(264, 20);
            this.txtNomeUfficio.TabIndex = 4;
            this.txtNomeUfficio.Tag = "registryaddress.officename";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(368, 143);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(112, 20);
            this.textBox2.TabIndex = 3;
            this.textBox2.Tag = "registryaddress.stop";
            // 
            // txtDataInizio
            // 
            this.txtDataInizio.Location = new System.Drawing.Point(128, 143);
            this.txtDataInizio.Name = "txtDataInizio";
            this.txtDataInizio.Size = new System.Drawing.Size(120, 20);
            this.txtDataInizio.TabIndex = 2;
            this.txtDataInizio.Tag = "registryaddress.start";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(63, 427);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 24);
            this.label11.TabIndex = 92;
            this.label11.Text = "Note";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.Location = new System.Drawing.Point(269, 138);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 33);
            this.label10.TabIndex = 91;
            this.label10.Text = "Decorrenza Fine Indirizzo:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(102, 252);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 16);
            this.label2.TabIndex = 88;
            this.label2.Text = "Nome ufficio:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(17, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 87;
            this.label1.Text = "Tipologia:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbTipoIndirizzo
            // 
            this.cmbTipoIndirizzo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTipoIndirizzo.DataSource = this.DS.address;
            this.cmbTipoIndirizzo.DisplayMember = "description";
            this.cmbTipoIndirizzo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoIndirizzo.Location = new System.Drawing.Point(127, 113);
            this.cmbTipoIndirizzo.Name = "cmbTipoIndirizzo";
            this.cmbTipoIndirizzo.Size = new System.Drawing.Size(272, 21);
            this.cmbTipoIndirizzo.TabIndex = 1;
            this.cmbTipoIndirizzo.Tag = "registryaddress.idaddresskind";
            this.cmbTipoIndirizzo.ValueMember = "idaddress";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(18, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 33);
            this.label4.TabIndex = 90;
            this.label4.Text = "Decorrenza Inizio Indirizzo:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(17, 283);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 16);
            this.label3.TabIndex = 89;
            this.label3.Text = "Indirizzo";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupCredDeb
            // 
            this.groupCredDeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupCredDeb.Controls.Add(this.txtCredDeb);
            this.groupCredDeb.Controls.Add(this.label7);
            this.groupCredDeb.Location = new System.Drawing.Point(14, 48);
            this.groupCredDeb.Name = "groupCredDeb";
            this.groupCredDeb.Size = new System.Drawing.Size(464, 56);
            this.groupCredDeb.TabIndex = 0;
            this.groupCredDeb.TabStop = false;
            this.groupCredDeb.Tag = "AutoChoose.txtCredDeb.anagrafica.(active!=\'N\')";
            this.groupCredDeb.Text = "Anagrafica";
            // 
            // txtCredDeb
            // 
            this.txtCredDeb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCredDeb.Location = new System.Drawing.Point(112, 22);
            this.txtCredDeb.Name = "txtCredDeb";
            this.txtCredDeb.Size = new System.Drawing.Size(344, 20);
            this.txtCredDeb.TabIndex = 0;
            this.txtCredDeb.Tag = "registry.title?registryaddressview.registry";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(8, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 16);
            this.label7.TabIndex = 1;
            this.label7.Text = "Denominazione:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ckbAttivo
            // 
            this.ckbAttivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckbAttivo.Location = new System.Drawing.Point(399, 113);
            this.ckbAttivo.Name = "ckbAttivo";
            this.ckbAttivo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ckbAttivo.Size = new System.Drawing.Size(80, 16);
            this.ckbAttivo.TabIndex = 13;
            this.ckbAttivo.Tag = "registryaddress.active:S:N";
            this.ckbAttivo.Text = "Attivo";
            this.ckbAttivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxCap
            // 
            this.textBoxCap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCap.Location = new System.Drawing.Point(418, 400);
            this.textBoxCap.Name = "textBoxCap";
            this.textBoxCap.Size = new System.Drawing.Size(60, 20);
            this.textBoxCap.TabIndex = 11;
            this.textBoxCap.Tag = "registryaddress.cap";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.Location = new System.Drawing.Point(376, 400);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 18);
            this.label8.TabIndex = 168;
            this.label8.Text = "C.A.P.";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkEstero
            // 
            this.chkEstero.Location = new System.Drawing.Point(128, 315);
            this.chkEstero.Name = "chkEstero";
            this.chkEstero.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkEstero.Size = new System.Drawing.Size(72, 16);
            this.chkEstero.TabIndex = 6;
            this.chkEstero.Tag = "registryaddress.flagforeign:S:N";
            this.chkEstero.Text = "Estero";
            this.chkEstero.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkEstero.CheckedChanged += new System.EventHandler(this.chkEstero_CheckedChanged);
            // 
            // txtLocalita
            // 
            this.txtLocalita.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLocalita.Location = new System.Drawing.Point(128, 400);
            this.txtLocalita.Name = "txtLocalita";
            this.txtLocalita.Size = new System.Drawing.Size(248, 20);
            this.txtLocalita.TabIndex = 10;
            this.txtLocalita.Tag = "registryaddress.location";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(55, 400);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 18);
            this.label5.TabIndex = 165;
            this.label5.Text = "Località";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpEstero
            // 
            this.grpEstero.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpEstero.Controls.Add(this.txtGeoNazione);
            this.grpEstero.Location = new System.Drawing.Point(128, 344);
            this.grpEstero.Name = "grpEstero";
            this.grpEstero.Size = new System.Drawing.Size(352, 48);
            this.grpEstero.TabIndex = 9;
            this.grpEstero.TabStop = false;
            this.grpEstero.Tag = "AutoChoose.txtGeoNazione.default";
            // 
            // txtGeoNazione
            // 
            this.txtGeoNazione.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGeoNazione.Location = new System.Drawing.Point(8, 16);
            this.txtGeoNazione.Name = "txtGeoNazione";
            this.txtGeoNazione.Size = new System.Drawing.Size(336, 20);
            this.txtGeoNazione.TabIndex = 3;
            this.txtGeoNazione.Tag = "geo_nazione_alias.title?registryaddressview.nation";
            // 
            // lblComuneStato
            // 
            this.lblComuneStato.Location = new System.Drawing.Point(32, 360);
            this.lblComuneStato.Name = "lblComuneStato";
            this.lblComuneStato.Size = new System.Drawing.Size(80, 16);
            this.lblComuneStato.TabIndex = 162;
            this.lblComuneStato.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpItaliano
            // 
            this.grpItaliano.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpItaliano.Controls.Add(this.label13);
            this.grpItaliano.Controls.Add(this.txtProvincia);
            this.grpItaliano.Controls.Add(this.txtLocalitaGeo);
            this.grpItaliano.Location = new System.Drawing.Point(128, 344);
            this.grpItaliano.Name = "grpItaliano";
            this.grpItaliano.Size = new System.Drawing.Size(352, 48);
            this.grpItaliano.TabIndex = 8;
            this.grpItaliano.TabStop = false;
            this.grpItaliano.Tag = "AutoChoose.txtLocalitaGeo.default";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.Location = new System.Drawing.Point(248, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 18);
            this.label13.TabIndex = 154;
            this.label13.Text = "Prov.";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtProvincia
            // 
            this.txtProvincia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProvincia.Location = new System.Drawing.Point(288, 16);
            this.txtProvincia.Name = "txtProvincia";
            this.txtProvincia.ReadOnly = true;
            this.txtProvincia.Size = new System.Drawing.Size(48, 20);
            this.txtProvincia.TabIndex = 153;
            this.txtProvincia.TabStop = false;
            this.txtProvincia.Tag = "geo_country.province";
            // 
            // txtLocalitaGeo
            // 
            this.txtLocalitaGeo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLocalitaGeo.Location = new System.Drawing.Point(8, 16);
            this.txtLocalitaGeo.Name = "txtLocalitaGeo";
            this.txtLocalitaGeo.Size = new System.Drawing.Size(232, 20);
            this.txtLocalitaGeo.TabIndex = 3;
            this.txtLocalitaGeo.Tag = "geo_city.title?registryaddressview.city";
            // 
            // buttonAggiornaComune
            // 
            this.buttonAggiornaComune.Location = new System.Drawing.Point(256, 315);
            this.buttonAggiornaComune.Name = "buttonAggiornaComune";
            this.buttonAggiornaComune.Size = new System.Drawing.Size(122, 23);
            this.buttonAggiornaComune.TabIndex = 169;
            this.buttonAggiornaComune.Text = "Aggiorna Stato estero";
            this.buttonAggiornaComune.Click += new System.EventHandler(this.buttonAggiornaComune_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Location = new System.Drawing.Point(8, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(480, 32);
            this.label6.TabIndex = 181;
            this.label6.Text = "Domicilio fiscale: I non residenti in Italia hanno il domicilio fiscale nel Comun" +
                "e italiano nel quale si è prodotto il reddito più elevato.";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.Location = new System.Drawing.Point(8, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(480, 16);
            this.label9.TabIndex = 180;
            this.label9.Text = "Indirizzo predefinito: Residenza abituale dell\'anagrafica";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(32, 299);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(88, 50);
            this.pictureBox1.TabIndex = 182;
            this.pictureBox1.TabStop = false;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(7, 175);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(481, 31);
            this.label12.TabIndex = 183;
            this.label12.Text = "La decorrenza di un indirizzo è la data utilizzata ai fini dei calcoli e dovrebbe" +
                " essere almeno di 60 giorni successiva alla variazione anagrafica effettiva";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(214, 216);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(263, 20);
            this.textBox1.TabIndex = 184;
            this.textBox1.Tag = "registryaddress.recipientagency";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(9, 206);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(199, 46);
            this.label14.TabIndex = 185;
            this.label14.Text = "Ente di provenienza (per anagrafe prestazioni):";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Frm_registryaddress_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(496, 598);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.buttonAggiornaComune);
            this.Controls.Add(this.grpItaliano);
            this.Controls.Add(this.textBoxCap);
            this.Controls.Add(this.txtLocalita);
            this.Controls.Add(this.txtAppunti);
            this.Controls.Add(this.txtIndirizzo);
            this.Controls.Add(this.txtNomeUfficio);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.txtDataInizio);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.chkEstero);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.grpEstero);
            this.Controls.Add(this.lblComuneStato);
            this.Controls.Add(this.ckbAttivo);
            this.Controls.Add(this.groupCredDeb);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbTipoIndirizzo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Name = "Frm_registryaddress_default";
            this.Text = "frmcdindirizzo";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupCredDeb.ResumeLayout(false);
            this.groupCredDeb.PerformLayout();
            this.grpEstero.ResumeLayout(false);
            this.grpEstero.PerformLayout();
            this.grpItaliano.ResumeLayout(false);
            this.grpItaliano.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
        
        CQueryHelper QHC;
        QueryHelper QHS;
		public void MetaData_AfterLink() {
			Meta=MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
			HelpForm.SetDenyNull(DS.registryaddress.Columns["flagforeign"], true);
			ConfiguraCampiGeo();
		}

		public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
			if (T.TableName == "geo_nazione_alias" && R!=null) {			
				VisualizzaBottoneComune(null, R["idnation"]);
			}

			if ((!Meta.IsEmpty) && (R!=null) && (T.TableName == "geo_city")) {
				object idgeo = R["idcity"];
				VisualizzaBottoneComune(idgeo, null);
				aggiornaCap(idgeo);
			}
		}

		private void chkEstero_CheckedChanged(object sender, System.EventArgs e) {
			ConfiguraCampiGeo();
		}

		private void VisualizzaCampiGeo() {
			if (chkEstero.CheckState==CheckState.Checked) {
				grpItaliano.Visible=false;
				grpEstero.Visible=true;
				lblComuneStato.Text="Stato estero";
			}
			else {
				grpItaliano.Visible=true;
				grpEstero.Visible=false;
				lblComuneStato.Text="Comune";
			}
		}

		private void ConfiguraCampiGeo() {
			VisualizzaCampiGeo();

			if (!Meta.DrawStateIsDone) return;

			if (chkEstero.CheckState==CheckState.Checked) {
				label8.Visible = false;
				textBoxCap.Visible = false;
				if (!Meta.IsEmpty) {
					Meta.GetFormData(true);
					DS.registryaddress.Rows[0]["idcity"]=DBNull.Value;
					DS.geo_city.Rows.Clear();
					DS.geo_country.Rows.Clear();
					Meta.FreshForm(grpItaliano.Controls,true,"registryaddress");
				}
			}
			else {
				label8.Visible = true;
				textBoxCap.Visible = true;
				if (!Meta.IsEmpty) {
					Meta.GetFormData(true);
					DS.registryaddress.Rows[0]["idnation"]=DBNull.Value;
					DS.geo_nazione_alias.Rows.Clear();
					Meta.FreshForm(grpEstero.Controls,true,"registryaddress");
				}
			}
		}

		public void MetaData_AfterFill() {
			object idComune = DS.registryaddress.Rows[0]["idcity"];
			object idStatoEstero = DS.registryaddress.Rows[0]["idnation"];
			VisualizzaBottoneComune(idComune, idStatoEstero);

            if (DS.address.Select(QHC.CmpEq("codeaddress", "07_SW_DEF")).Length == 1) {
                DataRow def = DS.address.Select(QHC.CmpEq("codeaddress", "07_SW_DEF"))[0];
                MetaData.SetDefault(DS.registryaddress, "idaddresskind", def["idaddress"]);
            }

		}

		public void MetaData_AfterClear() {
			buttonAggiornaComune.Visible = false;
		}

        private void VisualizzaBottoneComune(object idcomune, object idnazione) {
			bool visible=false;
			if (idcomune!=null && idcomune!=DBNull.Value) {
				object val=Meta.Conn.DO_READ_VALUE("geo_cityusable", QHS.CmpEq("idcity", idcomune), "idcity");
				if (val==null) {
					buttonAggiornaComune.Text = "Aggiorna Comune";
					visible = true;
				}
			}
            if (idnazione != null && idnazione != DBNull.Value) {
				object val=Meta.Conn.DO_READ_VALUE("geo_nationusable", QHS.CmpEq("idnation", idnazione), "idnation");
				if (val==null) {
					buttonAggiornaComune.Text = "Aggiorna Stato estero";
					visible = true;
				}
			}
			buttonAggiornaComune.Visible=visible;
		}

		private void aggiornaStatoEstero() {
			Meta.GetFormData(true);
			object idstatoestero=DS.registryaddress.Rows[0]["idnation"];
			if (idstatoestero == DBNull.Value) return;
			object[] list=new object[]{idstatoestero,"S"};
			DataSet DSout=Meta.Conn.CallSP("compute_history_nation",list,true,-1);
			if (DSout==null || DSout.Tables.Count==0 || DS.Tables[0].Rows.Count==0) return;
			DataTable T=DSout.Tables[0];
			if (T.Rows.Count==1) {
				DS.registryaddress.Rows[0]["idnation"]=T.Rows[0]["idnazione"];
			}
			else {
				string filtro = QHS.FieldIn("idnation", T.Select());
				MetaData metaStatoEstero = MetaData.GetMetaData(this, "geo_nation");
				metaStatoEstero.DS = DS.Copy();
				metaStatoEstero.FilterLocked = true;

				DataRow r = metaStatoEstero.SelectOne("default", filtro, null, null);

				if (r!=null) {
					DS.registryaddress.Rows[0]["idnation"]=r["idnation"];
				}
			}
			Meta.FreshForm(true);
		}

		private void aggiornaComune() {
			Meta.GetFormData(true);
			object idcomune = DS.registryaddress.Rows[0]["idcity"];
			object[] list = new object[] {idcomune, "S"};
			DataSet DSout = Meta.Conn.CallSP("compute_history_city", list, true, -1);
			if (DSout==null || DSout.Tables.Count==0 || DS.Tables[0].Rows.Count==0) return;
			DataTable T = DSout.Tables[0];
			object idComune = null;
			if (T.Rows.Count==1) {
				idComune = T.Rows[0]["idcity"];
			}
			else {
				string filtro = QHS.FieldIn("idcity", T.Select());
				MetaData metaComune = MetaData.GetMetaData(this, "geo_cityview");
				metaComune.DS = DS.Copy();
				metaComune.FilterLocked = true;

				DataRow r = metaComune.SelectOne("storia", filtro, null, null);

				if (r != null) {
					idComune = r["idcity"];
				} 
				else {
					idComune = DS.registryaddress.Rows[0]["idcity"];
				}
			}
			DS.registryaddress.Rows[0]["idcity"] = idComune;
			Meta.FreshForm(true);
			aggiornaCap(idComune);
		}

		private void buttonAggiornaComune_Click(object sender, System.EventArgs e) {
			if (Meta.IsEmpty) return;
			if (chkEstero.Checked) {
				aggiornaStatoEstero();
			} 
			else {
				aggiornaComune();
			}
		}

        private void aggiornaCap(object idComune) {
            object capPrincipale = Meta.Conn.DO_READ_VALUE("geo_city_agency",
                QHS.AppAnd(QHS.CmpEq("idagency", 3), QHS.CmpEq("idcode", 1), QHS.CmpEq("idcity", idComune),
                    QHS.IsNull("stop")), "value");
            if (capPrincipale != null) {
                string cap = textBoxCap.Text;
                if (cap == "") {
                    textBoxCap.Text = capPrincipale.ToString();
                }
                else {
                    string query = "select value from geo_city_agency where " +
                        QHS.AppAnd(QHS.CmpEq("idagency", 3), QHS.CmpEq("idcity", idComune), QHS.CmpEq("value", cap),
                                    QHS.IsNull("stop"));
                    DataTable t = Meta.Conn.SQLRunner(query);
                    if ((cap != capPrincipale.ToString()) && (t.Rows.Count == 0)) {
                        DialogResult dr = MessageBox.Show(this, "Il C.A.P. non è coerente con il comune scelto. Si desidera aggiornarlo?", "Avviso", MessageBoxButtons.YesNo);
                        if (dr == DialogResult.Yes) {
                            textBoxCap.Text = capPrincipale.ToString();
                        }
                    }
                }
            }
        }


	}
}