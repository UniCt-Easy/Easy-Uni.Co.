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
using System.Data;
using metadatalibrary;
using funzioni_configurazione;

namespace registryaddress_anagraficasingle//cdindirizzo_anagrafica//
{
    /// <summary>
    /// Summary description for frmcdindirizzo_anagrafica.
    /// </summary>
    public class Frm_registryaddress_anagraficasingle : System.Windows.Forms.Form {
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Button btnOk;
        public vistaForm DS;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtIndirizzo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNomeUfficio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTipoIndirizzo;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDataInizio;
        private System.Windows.Forms.TextBox txtAppunti;
        private System.Windows.Forms.Label label11;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        private System.Windows.Forms.CheckBox ckbAttivo;
        private System.Windows.Forms.GroupBox grpItaliano;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtProvincia;
        private System.Windows.Forms.TextBox txtLocalitaGeo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkEstero;
        private System.Windows.Forms.TextBox txtLocalita;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grpEstero;
        private System.Windows.Forms.TextBox txtGeoNazione;
        private System.Windows.Forms.Label lblComuneStato;
        private System.Windows.Forms.TextBox textBoxCap;
        private System.Windows.Forms.Button buttonAggiornaComune;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetaData Meta;
        CQueryHelper QHC;
        private Label label9;
        private Label label14;
        private TextBox textBox1;
        QueryHelper QHS;

        public Frm_registryaddress_anagraficasingle() {
            InitializeComponent();
            HelpForm.SetDenyNull(DS.registryaddress.Columns["active"], true);
            DataAccess.SetTableForReading(DS.geo_nazione_alias, "geo_nation");
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (components != null) {
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
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(typeof(Frm_registryaddress_anagraficasingle));
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.DS = new registryaddress_anagraficasingle.vistaForm();
            this.label10 = new System.Windows.Forms.Label();
            this.txtIndirizzo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNomeUfficio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTipoIndirizzo = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDataInizio = new System.Windows.Forms.TextBox();
            this.txtAppunti = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.ckbAttivo = new System.Windows.Forms.CheckBox();
            this.grpItaliano = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtProvincia = new System.Windows.Forms.TextBox();
            this.txtLocalitaGeo = new System.Windows.Forms.TextBox();
            this.textBoxCap = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkEstero = new System.Windows.Forms.CheckBox();
            this.txtLocalita = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.grpEstero = new System.Windows.Forms.GroupBox();
            this.txtGeoNazione = new System.Windows.Forms.TextBox();
            this.lblComuneStato = new System.Windows.Forms.Label();
            this.buttonAggiornaComune = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize) (this.DS)).BeginInit();
            this.grpItaliano.SuspendLayout();
            this.grpEstero.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(424, 530);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(72, 24);
            this.btnAnnulla.TabIndex = 13;
            this.btnAnnulla.Text = "Annulla";
            // 
            // btnOk
            // 
            this.btnOk.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(328, 530);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(72, 24);
            this.btnOk.TabIndex = 12;
            this.btnOk.Tag = "mainsave";
            this.btnOk.Text = "OK";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(265, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 36);
            this.label10.TabIndex = 62;
            this.label10.Text = "Decorrenza Fine Indirizzo";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtIndirizzo
            // 
            this.txtIndirizzo.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top |
                                                        System.Windows.Forms.AnchorStyles.Left)
                                                       | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIndirizzo.Location = new System.Drawing.Point(120, 218);
            this.txtIndirizzo.Name = "txtIndirizzo";
            this.txtIndirizzo.Size = new System.Drawing.Size(376, 20);
            this.txtIndirizzo.TabIndex = 5;
            this.txtIndirizzo.Tag = "registryaddress.address.indirizzo";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 16);
            this.label2.TabIndex = 54;
            this.label2.Text = "Nome ufficio:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNomeUfficio
            // 
            this.txtNomeUfficio.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top |
                                                        System.Windows.Forms.AnchorStyles.Left)
                                                       | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNomeUfficio.Location = new System.Drawing.Point(120, 194);
            this.txtNomeUfficio.Name = "txtNomeUfficio";
            this.txtNomeUfficio.Size = new System.Drawing.Size(256, 20);
            this.txtNomeUfficio.TabIndex = 3;
            this.txtNomeUfficio.Tag = "registryaddress.officename";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 52;
            this.label1.Text = "Tipologia:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbTipoIndirizzo
            // 
            this.cmbTipoIndirizzo.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top |
                                                        System.Windows.Forms.AnchorStyles.Left)
                                                       | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTipoIndirizzo.DataSource = this.DS.address;
            this.cmbTipoIndirizzo.DisplayMember = "description";
            this.cmbTipoIndirizzo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoIndirizzo.Location = new System.Drawing.Point(120, 56);
            this.cmbTipoIndirizzo.Name = "cmbTipoIndirizzo";
            this.cmbTipoIndirizzo.Size = new System.Drawing.Size(376, 21);
            this.cmbTipoIndirizzo.TabIndex = 0;
            this.cmbTipoIndirizzo.Tag = "registryaddress.idaddresskind";
            this.cmbTipoIndirizzo.ValueMember = "idaddress";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(376, 83);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(120, 20);
            this.textBox2.TabIndex = 2;
            this.textBox2.Tag = "registryaddress.stop";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 36);
            this.label4.TabIndex = 58;
            this.label4.Text = "Decorrenza Inizio Indirizzo";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 16);
            this.label3.TabIndex = 56;
            this.label3.Text = "Indirizzo:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDataInizio
            // 
            this.txtDataInizio.Location = new System.Drawing.Point(120, 83);
            this.txtDataInizio.Name = "txtDataInizio";
            this.txtDataInizio.Size = new System.Drawing.Size(120, 20);
            this.txtDataInizio.TabIndex = 1;
            this.txtDataInizio.Tag = "registryaddress.start";
            // 
            // txtAppunti
            // 
            this.txtAppunti.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top |
                                                         System.Windows.Forms.AnchorStyles.Bottom)
                                                        | System.Windows.Forms.AnchorStyles.Left)
                                                       | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAppunti.Location = new System.Drawing.Point(120, 358);
            this.txtAppunti.Multiline = true;
            this.txtAppunti.Name = "txtAppunti";
            this.txtAppunti.Size = new System.Drawing.Size(376, 166);
            this.txtAppunti.TabIndex = 11;
            this.txtAppunti.Tag = "registryaddress.annotations";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(32, 362);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 27);
            this.label11.TabIndex = 72;
            this.label11.Text = "Note:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ckbAttivo
            // 
            this.ckbAttivo.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.ckbAttivo.Location = new System.Drawing.Point(408, 194);
            this.ckbAttivo.Name = "ckbAttivo";
            this.ckbAttivo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ckbAttivo.Size = new System.Drawing.Size(80, 16);
            this.ckbAttivo.TabIndex = 4;
            this.ckbAttivo.Tag = "registryaddress.active:S:N";
            this.ckbAttivo.Text = "Attivo";
            this.ckbAttivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpItaliano
            // 
            this.grpItaliano.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top |
                                                        System.Windows.Forms.AnchorStyles.Left)
                                                       | System.Windows.Forms.AnchorStyles.Right)));
            this.grpItaliano.Controls.Add(this.label13);
            this.grpItaliano.Controls.Add(this.txtProvincia);
            this.grpItaliano.Controls.Add(this.txtLocalitaGeo);
            this.grpItaliano.Location = new System.Drawing.Point(120, 269);
            this.grpItaliano.Name = "grpItaliano";
            this.grpItaliano.Size = new System.Drawing.Size(376, 48);
            this.grpItaliano.TabIndex = 7;
            this.grpItaliano.TabStop = false;
            this.grpItaliano.Tag = "AutoChoose.txtLocalitaGeo.default";
            // 
            // label13
            // 
            this.label13.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.label13.Location = new System.Drawing.Point(280, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 18);
            this.label13.TabIndex = 154;
            this.label13.Text = "Prov.";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtProvincia
            // 
            this.txtProvincia.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.txtProvincia.Location = new System.Drawing.Point(312, 16);
            this.txtProvincia.Name = "txtProvincia";
            this.txtProvincia.ReadOnly = true;
            this.txtProvincia.Size = new System.Drawing.Size(56, 20);
            this.txtProvincia.TabIndex = 153;
            this.txtProvincia.TabStop = false;
            this.txtProvincia.Tag = "geo_country.province";
            // 
            // txtLocalitaGeo
            // 
            this.txtLocalitaGeo.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top |
                                                        System.Windows.Forms.AnchorStyles.Left)
                                                       | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLocalitaGeo.Location = new System.Drawing.Point(8, 16);
            this.txtLocalitaGeo.Name = "txtLocalitaGeo";
            this.txtLocalitaGeo.Size = new System.Drawing.Size(264, 20);
            this.txtLocalitaGeo.TabIndex = 3;
            this.txtLocalitaGeo.Tag = "geo_city.title?registryaddressview.city";
            // 
            // textBoxCap
            // 
            this.textBoxCap.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCap.Location = new System.Drawing.Point(432, 325);
            this.textBoxCap.Name = "textBoxCap";
            this.textBoxCap.Size = new System.Drawing.Size(60, 20);
            this.textBoxCap.TabIndex = 10;
            this.textBoxCap.Tag = "registryaddress.cap";
            // 
            // label8
            // 
            this.label8.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.label8.Location = new System.Drawing.Point(392, 325);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 18);
            this.label8.TabIndex = 176;
            this.label8.Text = "C.A.P.";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkEstero
            // 
            this.chkEstero.Location = new System.Drawing.Point(121, 242);
            this.chkEstero.Name = "chkEstero";
            this.chkEstero.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkEstero.Size = new System.Drawing.Size(64, 24);
            this.chkEstero.TabIndex = 6;
            this.chkEstero.Tag = "registryaddress.flagforeign:S:N";
            this.chkEstero.Text = "Estero";
            this.chkEstero.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkEstero.CheckedChanged += new System.EventHandler(this.chkEstero_CheckedChanged);
            // 
            // txtLocalita
            // 
            this.txtLocalita.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top |
                                                        System.Windows.Forms.AnchorStyles.Left)
                                                       | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLocalita.Location = new System.Drawing.Point(120, 325);
            this.txtLocalita.Name = "txtLocalita";
            this.txtLocalita.Size = new System.Drawing.Size(272, 20);
            this.txtLocalita.TabIndex = 9;
            this.txtLocalita.Tag = "registryaddress.location";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(48, 325);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 18);
            this.label5.TabIndex = 173;
            this.label5.Text = "Località";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpEstero
            // 
            this.grpEstero.Controls.Add(this.txtGeoNazione);
            this.grpEstero.Location = new System.Drawing.Point(120, 269);
            this.grpEstero.Name = "grpEstero";
            this.grpEstero.Size = new System.Drawing.Size(376, 48);
            this.grpEstero.TabIndex = 8;
            this.grpEstero.TabStop = false;
            this.grpEstero.Tag = "AutoChoose.txtGeoNazione.default";
            // 
            // txtGeoNazione
            // 
            this.txtGeoNazione.Location = new System.Drawing.Point(8, 16);
            this.txtGeoNazione.Name = "txtGeoNazione";
            this.txtGeoNazione.Size = new System.Drawing.Size(360, 20);
            this.txtGeoNazione.TabIndex = 3;
            this.txtGeoNazione.Tag = "geo_nazione_alias.title?registryaddressview.nation";
            // 
            // lblComuneStato
            // 
            this.lblComuneStato.Location = new System.Drawing.Point(32, 293);
            this.lblComuneStato.Name = "lblComuneStato";
            this.lblComuneStato.Size = new System.Drawing.Size(80, 16);
            this.lblComuneStato.TabIndex = 170;
            this.lblComuneStato.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonAggiornaComune
            // 
            this.buttonAggiornaComune.Location = new System.Drawing.Point(240, 242);
            this.buttonAggiornaComune.Name = "buttonAggiornaComune";
            this.buttonAggiornaComune.Size = new System.Drawing.Size(122, 23);
            this.buttonAggiornaComune.TabIndex = 177;
            this.buttonAggiornaComune.Text = "Aggiorna Stato estero";
            this.buttonAggiornaComune.Click += new System.EventHandler(this.buttonAggiornaComune_Click);
            // 
            // label6
            // 
            this.label6.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top |
                                                        System.Windows.Forms.AnchorStyles.Left)
                                                       | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Location = new System.Drawing.Point(8, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(504, 16);
            this.label6.TabIndex = 178;
            this.label6.Text = "Indirizzo predefinito: Residenza abituale del cred./deb.";
            // 
            // label7
            // 
            this.label7.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top |
                                                        System.Windows.Forms.AnchorStyles.Left)
                                                       | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Location = new System.Drawing.Point(8, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(504, 40);
            this.label7.TabIndex = 179;
            this.label7.Text = "Domicilio fiscale: I non residenti in Italia hanno il domicilio fiscale nel Comun" +
                               "e italiano nel quale si è prodotto il reddito più elevato.";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = ((System.Drawing.Image) (resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(24, 234);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(88, 50);
            this.pictureBox1.TabIndex = 180;
            this.pictureBox1.TabStop = false;
            // 
            // label9
            // 
            this.label9.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top |
                                                        System.Windows.Forms.AnchorStyles.Left)
                                                       | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(8, 118);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(504, 31);
            this.label9.TabIndex = 181;
            this.label9.Text = "La decorrenza di un indirizzo è la data utilizzata ai fini dei calcoli e dovrebbe" +
                               " essere almeno di 60 giorni successiva alla variazione anagrafica effettiva";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(6, 149);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(106, 46);
            this.label14.TabIndex = 187;
            this.label14.Text = "Ente di provenienza (per anagrafe prestazioni):";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox1
            // 
            this.textBox1.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top |
                                                        System.Windows.Forms.AnchorStyles.Left)
                                                       | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(120, 161);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(255, 20);
            this.textBox1.TabIndex = 186;
            this.textBox1.Tag = "registryaddress.recipientagency";
            // 
            // Frm_registryaddress_anagraficasingle
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(514, 560);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cmbTipoIndirizzo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
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
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOk);
            this.Name = "Frm_registryaddress_anagraficasingle";
            this.Text = "frmcdindirizzo_anagrafica";
            ((System.ComponentModel.ISupportInitialize) (this.DS)).EndInit();
            this.grpItaliano.ResumeLayout(false);
            this.grpItaliano.PerformLayout();
            this.grpEstero.ResumeLayout(false);
            this.grpEstero.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            HelpForm.SetDenyNull(DS.registryaddress.Columns["flagforeign"], true);
            VisualizzaCampiGeo();
        }

        private DateTime getMaxDataFine(DataRow[] rIndir) {
            DateTime dataContabile = new DateTime(CfgFn.GetNoNullInt32(Meta.GetSys("esercizio")), 1, 1);

            if (rIndir.Length == 0) return dataContabile;
            if (rIndir[0]["stop"] == DBNull.Value) return dataContabile;

            DateTime max = (DateTime) rIndir[0]["stop"];

            for (int i = 1; i < rIndir.Length; i++) {
                if (rIndir[i]["stop"] == DBNull.Value) return dataContabile;
                DateTime curr = (DateTime) rIndir[i]["stop"];
                if (curr > max) {
                    max = curr;
                }
            }

            return max.AddDays(1);
        }

        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (!Meta.DrawStateIsDone) return;
            if (!Meta.IsEmpty && T.TableName == "geo_nation_alias" && R != null) {
                VisualizzaBottoneComune(null, R["idnation"]);
            }

            if (Meta.InsertMode && (T.TableName == "address") && (R != null)) {
                DateTime dataInizio = QueryCreator.EmptyDate();
                if (DS.registryaddress.Rows[0]["start"] != DBNull.Value) {
                    dataInizio = (DateTime) DS.registryaddress.Rows[0]["start"];
                }

                object tipoIndirizzo = R["idaddress"];
                string filtro = QHC.CmpEq("idaddresskind", tipoIndirizzo);
                if (Meta.SourceRow.Table.Select(filtro).Length > 0) {
                    bool dataNulla = dataInizio == QueryCreator.EmptyDate();
                    if (!dataNulla) {
                        filtro = QHC.AppAnd(filtro, QHC.CmpNe("start", dataInizio));
                    }

                    DataRow[] rIndir = Meta.SourceRow.Table.Select(filtro);
                    DateTime max = getMaxDataFine(rIndir);
                    if (!dataNulla && (max != dataInizio)) {
                        DialogResult dr = MessageBox.Show(this,
                            "Vuoi impostare '" + max.ToString("d") + "' come data di inizio validità?",
                            "Conferma", MessageBoxButtons.YesNo);
                        dataNulla = dr == DialogResult.Yes;
                    }

                    if (dataNulla) {
                        DS.registryaddress.Rows[0]["start"] = max;
                        txtDataInizio.Text = max.ToString("d");
                    }
                }
            }

            if (!Meta.IsEmpty && (T.TableName == "geo_city") && (R != null)) {
                string idgeo = R["idcity"].ToString();
                VisualizzaBottoneComune(idgeo, null);
                aggiornaCap(idgeo);
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
                                   QHS.AppAnd(QHS.CmpEq("idagency", 3), QHS.CmpEq("idcity", idComune),
                                       QHS.CmpEq("value", cap),
                                       QHS.IsNull("stop"));
                    DataTable t = Meta.Conn.SQLRunner(query);
                    if ((cap != capPrincipale.ToString()) && (t.Rows.Count == 0)) {
                        DialogResult dr = MessageBox.Show(this,
                            "Il C.A.P. non è coerente con il comune scelto. Si desidera aggiornarlo?", "Avviso",
                            MessageBoxButtons.YesNo);
                        if (dr == DialogResult.Yes) {
                            textBoxCap.Text = capPrincipale.ToString();
                        }
                    }
                }
            }
        }


        public void MetaData_AfterFill() {
            object idComune = DS.registryaddress.Rows[0]["idcity"];
            object idStatoEstero = DS.registryaddress.Rows[0]["idnation"];
            VisualizzaBottoneComune(idComune, idStatoEstero);
        }

        private void chkEstero_CheckedChanged(object sender, System.EventArgs e) {
            ConfiguraCampiGeo();
        }


        private void VisualizzaCampiGeo() {
            if (chkEstero.CheckState == CheckState.Checked) {
                grpItaliano.Visible = false;
                grpEstero.Visible = true;
                lblComuneStato.Text = "Stato estero";
                textBoxCap.Visible = false;
                label8.Visible = false;
            }
            else {
                grpItaliano.Visible = true;
                grpEstero.Visible = false;
                lblComuneStato.Text = "Comune";
                label8.Visible = true;
                textBoxCap.Visible = true;
            }
        }

        private void ConfiguraCampiGeo() {
            VisualizzaCampiGeo();

            if (!Meta.DrawStateIsDone) return;

            if (chkEstero.CheckState == CheckState.Checked) {
                if (!Meta.IsEmpty) {
                    Meta.GetFormData(true);
                    DS.registryaddress.Rows[0]["idcity"] = DBNull.Value;
                    DS.geo_city.Rows.Clear();
                    DS.geo_country.Rows.Clear();
                    Meta.FreshForm(grpItaliano.Controls, true, "registryaddress");
                }
            }
            else {
                if (!Meta.IsEmpty) {
                    Meta.GetFormData(true);
                    DS.registryaddress.Rows[0]["idnation"] = DBNull.Value;
                    DS.geo_nazione_alias.Rows.Clear();
                    Meta.FreshForm(grpEstero.Controls, true, "registryaddress");
                }
            }
        }

        /// <summary>
        /// Visualliza il bottone aggiorna comune in base all'idcomune
        /// </summary>
        /// <param name="R">riga di creditoredebitore</param>
        private void VisualizzaBottoneComune(object idcomune, object idnazione) {
            bool visible = false;
            if (idcomune != null && idcomune != DBNull.Value) {
                object val = Meta.Conn.DO_READ_VALUE("geo_cityusable", QHS.CmpEq("idcity", idcomune), "idcity");
                if (val == null) {
                    buttonAggiornaComune.Text = "Aggiorna Comune";
                    visible = true;
                }
            }

            if (idnazione != null && idnazione != DBNull.Value) {
                object val = Meta.Conn.DO_READ_VALUE("geo_nationusable", QHS.CmpEq("idnation", idnazione), "idnation");
                if (val == null) {
                    buttonAggiornaComune.Text = "Aggiorna Stato estero";
                    visible = true;
                }
            }

            buttonAggiornaComune.Visible = visible;
        }

        public void MetaData_AfterClear() {
            buttonAggiornaComune.Visible = false;
        }

        private void aggiornaStatoEstero() {
            Meta.GetFormData(true);
            object idstatoestero = DS.registryaddress.Rows[0]["idnation"];
            if (idstatoestero == DBNull.Value) return;
            object[] list = new object[] {idstatoestero, "S"};
            DataSet DSout = Meta.Conn.CallSP("compute_history_nation", list, true, -1);
            if (DSout == null || DSout.Tables.Count == 0 || DS.Tables[0].Rows.Count == 0) return;
            DataTable T = DSout.Tables[0];
            if (T.Rows.Count == 1) {
                DS.registryaddress.Rows[0]["idnation"] = T.Rows[0]["idnation"];
            }
            else {
                string filtro = QHS.FieldInList("idnation", QHS.DistinctVal(T.Select(), "idnation"));
                MetaData metaStatoEstero = MetaData.GetMetaData(this, "geo_nation");
                metaStatoEstero.FilterLocked = true;

                DataRow r = metaStatoEstero.SelectOne("default", filtro, null, null);

                if (r != null) {
                    DS.registryaddress.Rows[0]["idnation"] = r["idnation"];
                }
            }

            Meta.FreshForm(true);
        }

        private void aggiornaComune() {
            Meta.GetFormData(true);
            object idcomune = DS.registryaddress.Rows[0]["idcity"];
            object[] list = new object[] {idcomune, "S"};
            DataSet DSout = Meta.Conn.CallSP("compute_history_city", list, true, -1);
            if (DSout == null || DSout.Tables.Count == 0 || DS.Tables[0].Rows.Count == 0) return;
            DataTable T = DSout.Tables[0];
            object idComune = null;
            if (T.Rows.Count == 1) {
                idComune = T.Rows[0]["idcity"];
            }
            else {
                string filtro = QHS.FieldInList("idcity", QHS.DistinctVal(T.Select(), "idcity"));
                MetaData metaComune = MetaData.GetMetaData(this, "geo_cityview");
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

    }
}
