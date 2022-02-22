
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
using System.Windows.Forms;
using metadatalibrary;
using funzioni_configurazione;//funzioni_configurazione
using System.Data;
using AskInfo;

namespace expensetax_default {//dettaglioritenute//
	/// <summary>
	/// Summary description for frmdettaglioritenute.
	/// Revised By Nino on 14/3/2003 (mancavano tutte le formule)
	/// </summary>
	public class Frm_expensetax_default : MetaDataForm {
		decimal lastImponibileLordo;
		decimal lastQuotaEsente;
		decimal lastImponibileNetto;
		decimal lastAliquotaDip;
		decimal lastQuotaNumDip;
		decimal lastQuotaDenDip;
		decimal lastDetrazioni;
		decimal lastAliquotaAmm;
		decimal lastQuotaNumAmm;
		decimal lastQuotaDenAmm;

		private System.Windows.Forms.Button btnRitenuta;
		public vistaForm DS;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ComboBox cmbTipoRitenuta;
		private System.Windows.Forms.TextBox txtDataCompetenza;
		private System.Windows.Forms.TextBox txtDetrazioni;
		private System.Windows.Forms.TextBox txtQuotaEsente;
		private System.Windows.Forms.TextBox txtImportoDip;
		private System.Windows.Forms.TextBox txtQuotaDip2;
		private System.Windows.Forms.TextBox txtQuotaDip1;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnAnnulla;
		MetaData Meta;
		bool inChiusura = false;
		private System.Windows.Forms.GroupBox gBoxScaglione;
		private System.Windows.Forms.GroupBox gBoxGenerale;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.TextBox txtImponibileLordo;
		private System.Windows.Forms.TextBox txtImponibileNetto;
		private System.Windows.Forms.TextBox txtQuotaAmm2;
		private System.Windows.Forms.TextBox txtQuotaAmm1;
		private System.Windows.Forms.TextBox txtAliquotaAmm;
		private System.Windows.Forms.TextBox txtImportoAmm;
		private System.Windows.Forms.TextBox txtAliquotaDip;
        private GroupBox grpRegion;
        private ComboBox cmbRegioneFiscale;
        private GroupBox grpCity;
        private Label label20;
        private TextBox txtProvincia;
        private TextBox txtGeoComune0101;
        private TextBox textBox8;
        private Label label13;
        private TextBox txtAyear;
        private GroupBox gboxentrata;
        private Button btnSelectMov;
        private TextBox txtNumeroMovimento;
        private Label labNum;
        private TextBox txtEsercizioMovimento;
        private Label labEserc;
        private GroupBox groupBox5;
        private TextBox textBox9;
        private Label label14;
        private TextBox textBox10;
        private Label label15;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_expensetax_default() {
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.btnRitenuta = new System.Windows.Forms.Button();
            this.cmbTipoRitenuta = new System.Windows.Forms.ComboBox();
            this.DS = new expensetax_default.vistaForm();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtImponibileLordo = new System.Windows.Forms.TextBox();
            this.txtDataCompetenza = new System.Windows.Forms.TextBox();
            this.txtDetrazioni = new System.Windows.Forms.TextBox();
            this.txtQuotaEsente = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtImportoDip = new System.Windows.Forms.TextBox();
            this.txtQuotaDip2 = new System.Windows.Forms.TextBox();
            this.txtQuotaDip1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAliquotaDip = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtImportoAmm = new System.Windows.Forms.TextBox();
            this.txtQuotaAmm2 = new System.Windows.Forms.TextBox();
            this.txtQuotaAmm1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAliquotaAmm = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.gBoxScaglione = new System.Windows.Forms.GroupBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtImponibileNetto = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.gBoxGenerale = new System.Windows.Forms.GroupBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtAyear = new System.Windows.Forms.TextBox();
            this.grpRegion = new System.Windows.Forms.GroupBox();
            this.cmbRegioneFiscale = new System.Windows.Forms.ComboBox();
            this.grpCity = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtProvincia = new System.Windows.Forms.TextBox();
            this.txtGeoComune0101 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.gboxentrata = new System.Windows.Forms.GroupBox();
            this.btnSelectMov = new System.Windows.Forms.Button();
            this.txtNumeroMovimento = new System.Windows.Forms.TextBox();
            this.labNum = new System.Windows.Forms.Label();
            this.txtEsercizioMovimento = new System.Windows.Forms.TextBox();
            this.labEserc = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gBoxScaglione.SuspendLayout();
            this.gBoxGenerale.SuspendLayout();
            this.grpRegion.SuspendLayout();
            this.grpCity.SuspendLayout();
            this.gboxentrata.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRitenuta
            // 
            this.btnRitenuta.Location = new System.Drawing.Point(16, 16);
            this.btnRitenuta.Name = "btnRitenuta";
            this.btnRitenuta.Size = new System.Drawing.Size(96, 23);
            this.btnRitenuta.TabIndex = 0;
            this.btnRitenuta.TabStop = false;
            this.btnRitenuta.Tag = "choose.tax.default";
            this.btnRitenuta.Text = "Ritenuta";
            // 
            // cmbTipoRitenuta
            // 
            this.cmbTipoRitenuta.DataSource = this.DS.tax;
            this.cmbTipoRitenuta.DisplayMember = "description";
            this.cmbTipoRitenuta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoRitenuta.Location = new System.Drawing.Point(120, 16);
            this.cmbTipoRitenuta.Name = "cmbTipoRitenuta";
            this.cmbTipoRitenuta.Size = new System.Drawing.Size(360, 21);
            this.cmbTipoRitenuta.TabIndex = 1;
            this.cmbTipoRitenuta.Tag = "expensetax.taxcode";
            this.cmbTipoRitenuta.ValueMember = "taxcode";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Imponibile Lordo:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 30);
            this.label2.TabIndex = 3;
            this.label2.Text = "Quota Esente / Deduzioni:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(24, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Detrazioni:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(16, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Data Competenza:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtImponibileLordo
            // 
            this.txtImponibileLordo.Location = new System.Drawing.Point(120, 94);
            this.txtImponibileLordo.Name = "txtImponibileLordo";
            this.txtImponibileLordo.Size = new System.Drawing.Size(112, 20);
            this.txtImponibileLordo.TabIndex = 3;
            this.txtImponibileLordo.Tag = "expensetax.taxablegross.c";
            this.txtImponibileLordo.Leave += new System.EventHandler(this.txtImponibileLordo_Leave);
            // 
            // txtDataCompetenza
            // 
            this.txtDataCompetenza.Location = new System.Drawing.Point(120, 70);
            this.txtDataCompetenza.Name = "txtDataCompetenza";
            this.txtDataCompetenza.Size = new System.Drawing.Size(112, 20);
            this.txtDataCompetenza.TabIndex = 2;
            this.txtDataCompetenza.Tag = "expensetax.competencydate";
            // 
            // txtDetrazioni
            // 
            this.txtDetrazioni.Location = new System.Drawing.Point(128, 76);
            this.txtDetrazioni.Name = "txtDetrazioni";
            this.txtDetrazioni.Size = new System.Drawing.Size(104, 20);
            this.txtDetrazioni.TabIndex = 2;
            this.txtDetrazioni.Tag = "expensetax.abatements.c";
            this.txtDetrazioni.Leave += new System.EventHandler(this.txtDetrazioni_Leave);
            // 
            // txtQuotaEsente
            // 
            this.txtQuotaEsente.Location = new System.Drawing.Point(120, 134);
            this.txtQuotaEsente.Name = "txtQuotaEsente";
            this.txtQuotaEsente.Size = new System.Drawing.Size(112, 20);
            this.txtQuotaEsente.TabIndex = 4;
            this.txtQuotaEsente.Tag = "expensetax.exemptionquota.c";
            this.txtQuotaEsente.Leave += new System.EventHandler(this.txtQuotaEsente_Leave);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtImportoDip);
            this.groupBox1.Controls.Add(this.txtQuotaDip2);
            this.groupBox1.Controls.Add(this.txtQuotaDip1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtAliquotaDip);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(8, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 62);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ritenute c/dipendente";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(267, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "Importo:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtImportoDip
            // 
            this.txtImportoDip.Location = new System.Drawing.Point(267, 33);
            this.txtImportoDip.Name = "txtImportoDip";
            this.txtImportoDip.Size = new System.Drawing.Size(120, 20);
            this.txtImportoDip.TabIndex = 4;
            this.txtImportoDip.Tag = "expensetax.employtax.c";
            this.txtImportoDip.Leave += new System.EventHandler(this.txtImportoDip_Leave);
            // 
            // txtQuotaDip2
            // 
            this.txtQuotaDip2.Location = new System.Drawing.Point(192, 38);
            this.txtQuotaDip2.Name = "txtQuotaDip2";
            this.txtQuotaDip2.Size = new System.Drawing.Size(67, 20);
            this.txtQuotaDip2.TabIndex = 3;
            this.txtQuotaDip2.Tag = "expensetax.employdenominator.n";
            this.txtQuotaDip2.Leave += new System.EventHandler(this.txtQuotaDip2_Leave);
            // 
            // txtQuotaDip1
            // 
            this.txtQuotaDip1.Location = new System.Drawing.Point(192, 14);
            this.txtQuotaDip1.Name = "txtQuotaDip1";
            this.txtQuotaDip1.Size = new System.Drawing.Size(67, 20);
            this.txtQuotaDip1.TabIndex = 2;
            this.txtQuotaDip1.Tag = "expensetax.employnumerator.n";
            this.txtQuotaDip1.Leave += new System.EventHandler(this.txtQuotaDip1_Leave);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(144, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "Quota:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAliquotaDip
            // 
            this.txtAliquotaDip.Location = new System.Drawing.Point(8, 32);
            this.txtAliquotaDip.Name = "txtAliquotaDip";
            this.txtAliquotaDip.Size = new System.Drawing.Size(120, 20);
            this.txtAliquotaDip.TabIndex = 1;
            this.txtAliquotaDip.Tag = "expensetax.employrate.fixed.4..%.100";
            this.txtAliquotaDip.Leave += new System.EventHandler(this.txtAliquotaDip_Leave);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Aliquota:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtImportoAmm);
            this.groupBox2.Controls.Add(this.txtQuotaAmm2);
            this.groupBox2.Controls.Add(this.txtQuotaAmm1);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtAliquotaAmm);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(414, 100);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(400, 62);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Contributi c/amministrazione";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(267, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 16);
            this.label8.TabIndex = 20;
            this.label8.Text = "Importo:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtImportoAmm
            // 
            this.txtImportoAmm.Location = new System.Drawing.Point(267, 32);
            this.txtImportoAmm.Name = "txtImportoAmm";
            this.txtImportoAmm.Size = new System.Drawing.Size(120, 20);
            this.txtImportoAmm.TabIndex = 4;
            this.txtImportoAmm.Tag = "expensetax.admintax.c";
            this.txtImportoAmm.Leave += new System.EventHandler(this.txtImportoAmm_Leave);
            // 
            // txtQuotaAmm2
            // 
            this.txtQuotaAmm2.Location = new System.Drawing.Point(192, 36);
            this.txtQuotaAmm2.Name = "txtQuotaAmm2";
            this.txtQuotaAmm2.Size = new System.Drawing.Size(67, 20);
            this.txtQuotaAmm2.TabIndex = 3;
            this.txtQuotaAmm2.Tag = "expensetax.admindenominator.n";
            this.txtQuotaAmm2.Leave += new System.EventHandler(this.txtQuotaAmm2_Leave);
            // 
            // txtQuotaAmm1
            // 
            this.txtQuotaAmm1.Location = new System.Drawing.Point(192, 12);
            this.txtQuotaAmm1.Name = "txtQuotaAmm1";
            this.txtQuotaAmm1.Size = new System.Drawing.Size(67, 20);
            this.txtQuotaAmm1.TabIndex = 2;
            this.txtQuotaAmm1.Tag = "expensetax.adminnumerator.n";
            this.txtQuotaAmm1.Leave += new System.EventHandler(this.txtQuotaAmm1_Leave);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(144, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 16);
            this.label9.TabIndex = 16;
            this.label9.Text = "Quota:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAliquotaAmm
            // 
            this.txtAliquotaAmm.Location = new System.Drawing.Point(8, 32);
            this.txtAliquotaAmm.Name = "txtAliquotaAmm";
            this.txtAliquotaAmm.Size = new System.Drawing.Size(120, 20);
            this.txtAliquotaAmm.TabIndex = 1;
            this.txtAliquotaAmm.Tag = "expensetax.adminrate.fixed.4..%.100";
            this.txtAliquotaAmm.Leave += new System.EventHandler(this.txtAliquotaAmm_Leave);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(8, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 16);
            this.label10.TabIndex = 14;
            this.label10.Text = "Aliquota:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(315, 483);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(88, 23);
            this.btnOK.TabIndex = 12;
            this.btnOK.Tag = "mainsave";
            this.btnOK.Text = "OK";
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(443, 483);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(88, 23);
            this.btnAnnulla.TabIndex = 13;
            this.btnAnnulla.TabStop = false;
            this.btnAnnulla.Text = "Annulla";
            // 
            // gBoxScaglione
            // 
            this.gBoxScaglione.Controls.Add(this.textBox7);
            this.gBoxScaglione.Controls.Add(this.textBox6);
            this.gBoxScaglione.Controls.Add(this.label12);
            this.gBoxScaglione.Controls.Add(this.textBox2);
            this.gBoxScaglione.Controls.Add(this.txtDetrazioni);
            this.gBoxScaglione.Controls.Add(this.label3);
            this.gBoxScaglione.Controls.Add(this.txtImponibileNetto);
            this.gBoxScaglione.Controls.Add(this.label11);
            this.gBoxScaglione.Controls.Add(this.groupBox1);
            this.gBoxScaglione.Controls.Add(this.groupBox2);
            this.gBoxScaglione.Location = new System.Drawing.Point(8, 238);
            this.gBoxScaglione.Name = "gBoxScaglione";
            this.gBoxScaglione.Size = new System.Drawing.Size(828, 175);
            this.gBoxScaglione.TabIndex = 2;
            this.gBoxScaglione.TabStop = false;
            this.gBoxScaglione.Text = "Dati inerenti lo scaglione";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(238, 76);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(576, 20);
            this.textBox7.TabIndex = 10;
            this.textBox7.TabStop = false;
            this.textBox7.Text = "Detrazioni applicate sulla ritenuta scaglionata";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(238, 38);
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(576, 32);
            this.textBox6.TabIndex = 9;
            this.textBox6.TabStop = false;
            this.textBox6.Text = "Imponibile su cui si applicano effettivamente le aliquote della ritenuta";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(24, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(96, 20);
            this.label12.TabIndex = 8;
            this.label12.Text = "Num. Scaglione:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(128, 18);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(40, 20);
            this.textBox2.TabIndex = 7;
            this.textBox2.TabStop = false;
            this.textBox2.Tag = "expensetax.nbracket";
            // 
            // txtImponibileNetto
            // 
            this.txtImponibileNetto.Location = new System.Drawing.Point(128, 44);
            this.txtImponibileNetto.Name = "txtImponibileNetto";
            this.txtImponibileNetto.Size = new System.Drawing.Size(104, 20);
            this.txtImponibileNetto.TabIndex = 1;
            this.txtImponibileNetto.Tag = "expensetax.taxablenet.c";
            this.txtImponibileNetto.Leave += new System.EventHandler(this.txtImponibileNetto_Leave);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(24, 44);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 16);
            this.label11.TabIndex = 3;
            this.label11.Text = "Imponibile Netto:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gBoxGenerale
            // 
            this.gBoxGenerale.Controls.Add(this.textBox8);
            this.gBoxGenerale.Controls.Add(this.label13);
            this.gBoxGenerale.Controls.Add(this.txtAyear);
            this.gBoxGenerale.Controls.Add(this.grpRegion);
            this.gBoxGenerale.Controls.Add(this.grpCity);
            this.gBoxGenerale.Controls.Add(this.textBox5);
            this.gBoxGenerale.Controls.Add(this.textBox4);
            this.gBoxGenerale.Controls.Add(this.textBox3);
            this.gBoxGenerale.Controls.Add(this.txtImponibileLordo);
            this.gBoxGenerale.Controls.Add(this.label1);
            this.gBoxGenerale.Controls.Add(this.txtQuotaEsente);
            this.gBoxGenerale.Controls.Add(this.label2);
            this.gBoxGenerale.Controls.Add(this.btnRitenuta);
            this.gBoxGenerale.Controls.Add(this.cmbTipoRitenuta);
            this.gBoxGenerale.Controls.Add(this.label4);
            this.gBoxGenerale.Controls.Add(this.txtDataCompetenza);
            this.gBoxGenerale.Location = new System.Drawing.Point(8, 8);
            this.gBoxGenerale.Name = "gBoxGenerale";
            this.gBoxGenerale.Size = new System.Drawing.Size(488, 224);
            this.gBoxGenerale.TabIndex = 1;
            this.gBoxGenerale.TabStop = false;
            this.gBoxGenerale.Text = "Dati Generali della Ritenuta";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(238, 43);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(242, 20);
            this.textBox8.TabIndex = 11;
            this.textBox8.TabStop = false;
            this.textBox8.Text = "Anno di Competenza per la liquidazione";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(16, 42);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(104, 16);
            this.label13.TabIndex = 19;
            this.label13.Text = "Anno Competenza:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAyear
            // 
            this.txtAyear.Location = new System.Drawing.Point(120, 42);
            this.txtAyear.Name = "txtAyear";
            this.txtAyear.Size = new System.Drawing.Size(112, 20);
            this.txtAyear.TabIndex = 8;
            this.txtAyear.Tag = "expensetax.ayear.year";
            // 
            // grpRegion
            // 
            this.grpRegion.Controls.Add(this.cmbRegioneFiscale);
            this.grpRegion.Location = new System.Drawing.Point(4, 177);
            this.grpRegion.Name = "grpRegion";
            this.grpRegion.Size = new System.Drawing.Size(376, 43);
            this.grpRegion.TabIndex = 17;
            this.grpRegion.TabStop = false;
            this.grpRegion.Text = "Regione Fiscale:";
            // 
            // cmbRegioneFiscale
            // 
            this.cmbRegioneFiscale.DataSource = this.DS.fiscaltaxregion;
            this.cmbRegioneFiscale.DisplayMember = "title";
            this.cmbRegioneFiscale.FormattingEnabled = true;
            this.cmbRegioneFiscale.Location = new System.Drawing.Point(6, 16);
            this.cmbRegioneFiscale.Name = "cmbRegioneFiscale";
            this.cmbRegioneFiscale.Size = new System.Drawing.Size(363, 21);
            this.cmbRegioneFiscale.TabIndex = 0;
            this.cmbRegioneFiscale.Tag = "expensetax.idfiscaltaxregion";
            this.cmbRegioneFiscale.ValueMember = "idfiscaltaxregion";
            // 
            // grpCity
            // 
            this.grpCity.Controls.Add(this.label20);
            this.grpCity.Controls.Add(this.txtProvincia);
            this.grpCity.Controls.Add(this.txtGeoComune0101);
            this.grpCity.Location = new System.Drawing.Point(4, 172);
            this.grpCity.Name = "grpCity";
            this.grpCity.Size = new System.Drawing.Size(376, 48);
            this.grpCity.TabIndex = 16;
            this.grpCity.TabStop = false;
            this.grpCity.Tag = "AutoChoose.txtGeoComune0101.default";
            this.grpCity.Text = "Comune:";
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(300, 16);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(41, 18);
            this.label20.TabIndex = 154;
            this.label20.Text = "Prov.";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtProvincia
            // 
            this.txtProvincia.Location = new System.Drawing.Point(344, 15);
            this.txtProvincia.Name = "txtProvincia";
            this.txtProvincia.ReadOnly = true;
            this.txtProvincia.Size = new System.Drawing.Size(25, 20);
            this.txtProvincia.TabIndex = 153;
            this.txtProvincia.TabStop = false;
            this.txtProvincia.Tag = "geo_cityview.provincecode";
            // 
            // txtGeoComune0101
            // 
            this.txtGeoComune0101.Location = new System.Drawing.Point(8, 16);
            this.txtGeoComune0101.Name = "txtGeoComune0101";
            this.txtGeoComune0101.Size = new System.Drawing.Size(286, 20);
            this.txtGeoComune0101.TabIndex = 3;
            this.txtGeoComune0101.Tag = "geo_cityview.title?expensetaxview.city";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(238, 134);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(242, 32);
            this.textBox5.TabIndex = 8;
            this.textBox5.TabStop = false;
            this.textBox5.Text = "Totale delle deduzioni associate alla ritenuta (uguale per tutti gli scaglioni)";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(238, 94);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(242, 32);
            this.textBox4.TabIndex = 7;
            this.textBox4.TabStop = false;
            this.textBox4.Text = "Imponibile Lordo complessivo della ritenuta (uguale per tutti gli scaglioni)";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(238, 70);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(242, 20);
            this.textBox3.TabIndex = 6;
            this.textBox3.TabStop = false;
            this.textBox3.Text = "Data di Competenza per la liquidazione";
            // 
            // gboxentrata
            // 
            this.gboxentrata.Controls.Add(this.btnSelectMov);
            this.gboxentrata.Controls.Add(this.txtNumeroMovimento);
            this.gboxentrata.Controls.Add(this.labNum);
            this.gboxentrata.Controls.Add(this.txtEsercizioMovimento);
            this.gboxentrata.Controls.Add(this.labEserc);
            this.gboxentrata.Location = new System.Drawing.Point(16, 419);
            this.gboxentrata.Name = "gboxentrata";
            this.gboxentrata.Size = new System.Drawing.Size(347, 48);
            this.gboxentrata.TabIndex = 14;
            this.gboxentrata.TabStop = false;
            this.gboxentrata.Text = "Movimento di Entrata per rimborso";
            // 
            // btnSelectMov
            // 
            this.btnSelectMov.Location = new System.Drawing.Point(6, 17);
            this.btnSelectMov.Name = "btnSelectMov";
            this.btnSelectMov.Size = new System.Drawing.Size(75, 23);
            this.btnSelectMov.TabIndex = 8;
            this.btnSelectMov.Tag = "";
            this.btnSelectMov.Text = "Seleziona";
            this.btnSelectMov.Click += new System.EventHandler(this.btnSelectMov_Click);
            // 
            // txtNumeroMovimento
            // 
            this.txtNumeroMovimento.Location = new System.Drawing.Point(273, 18);
            this.txtNumeroMovimento.Name = "txtNumeroMovimento";
            this.txtNumeroMovimento.Size = new System.Drawing.Size(58, 20);
            this.txtNumeroMovimento.TabIndex = 7;
            this.txtNumeroMovimento.Tag = "incomeview.nmov?x";
            this.txtNumeroMovimento.Leave += new System.EventHandler(this.txtNumeroMovimento_Leave);
            // 
            // labNum
            // 
            this.labNum.Location = new System.Drawing.Point(219, 18);
            this.labNum.Name = "labNum";
            this.labNum.Size = new System.Drawing.Size(48, 20);
            this.labNum.TabIndex = 5;
            this.labNum.Text = "Numero:";
            this.labNum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercizioMovimento
            // 
            this.txtEsercizioMovimento.Location = new System.Drawing.Point(161, 19);
            this.txtEsercizioMovimento.Name = "txtEsercizioMovimento";
            this.txtEsercizioMovimento.Size = new System.Drawing.Size(52, 20);
            this.txtEsercizioMovimento.TabIndex = 6;
            this.txtEsercizioMovimento.Tag = "incomeview.ymov.year?x";
            // 
            // labEserc
            // 
            this.labEserc.Location = new System.Drawing.Point(87, 18);
            this.labEserc.Name = "labEserc";
            this.labEserc.Size = new System.Drawing.Size(66, 20);
            this.labEserc.TabIndex = 4;
            this.labEserc.Text = "Esercizio:";
            this.labEserc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBox9);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.textBox10);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Location = new System.Drawing.Point(569, 419);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(267, 48);
            this.groupBox5.TabIndex = 15;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Liquidazione Ritenute:";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(195, 16);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(58, 20);
            this.textBox9.TabIndex = 11;
            this.textBox9.TabStop = false;
            this.textBox9.Tag = "expensetax.ntaxpay";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(141, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 20);
            this.label14.TabIndex = 9;
            this.label14.Text = "Numero:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(83, 17);
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            this.textBox10.Size = new System.Drawing.Size(52, 20);
            this.textBox10.TabIndex = 10;
            this.textBox10.TabStop = false;
            this.textBox10.Tag = "expensetax.ytaxpay.year";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(9, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(66, 20);
            this.label15.TabIndex = 8;
            this.label15.Text = "Esercizio:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Frm_expensetax_default
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnAnnulla;
            this.ClientSize = new System.Drawing.Size(855, 521);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.gboxentrata);
            this.Controls.Add(this.gBoxGenerale);
            this.Controls.Add(this.gBoxScaglione);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Frm_expensetax_default";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dettaglio Ritenute";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_expensetax_default_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gBoxScaglione.ResumeLayout(false);
            this.gBoxScaglione.PerformLayout();
            this.gBoxGenerale.ResumeLayout(false);
            this.gBoxGenerale.PerformLayout();
            this.grpRegion.ResumeLayout(false);
            this.grpCity.ResumeLayout(false);
            this.grpCity.PerformLayout();
            this.gboxentrata.ResumeLayout(false);
            this.gboxentrata.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion
        object idSer;
		// Attenzione il form chiamante deve sempre passare come ExtraParameter il codice della prestazione
        CQueryHelper QHC;
        QueryHelper QHS;
		public void MetaData_AfterLink(){
			Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
			idSer = DBNull.Value;
			if (Meta.ExtraParameter!=null) {
				idSer=Meta.ExtraParameter;
			}
			else {
				show("E' necessario inserire il tipo prestazione prima di aprire questa maschera.");
			}

            rendiReadOnly();

            string f = QHS.AppAnd(QHS.CmpEq("ayear", Meta.GetSys("esercizio")),
                QHS.CmpEq("nphase", Meta.GetSys("maxincomephase")));
            GetData.SetStaticFilter(DS.incomeview, f);
			//if (Meta.InsertMode) {
				//string filterPrestazione = QueryCreator.quotedstrvalue(idSer,false);
					//DataTable ritenutaPrestazione = DataAccess.RUN_SELECT(Meta.Conn,"servicetax",
					//		"taxcode","taxcode",filterPrestazione,null,null,true);
					//string elencoRitenute = QueryCreator.ColumnValues(ritenutaPrestazione,null,"taxcode",false);
					//string filter = (elencoRitenute != "")
					//	? "(taxcode IN (" + elencoRitenute + "))" : "(taxcode = '')";
					//GetData.SetStaticFilter(DS.tax,filter);
					
				//}
			//}
		}

        /// <summary>
        /// Metodo che rende read only gli oggetti non modificabili del form
        /// </summary>
        private void rendiReadOnly() {
            DataRow ExpTaxParent = Meta.SourceRow;

            string solaLettura = (ExpTaxParent.Table.ExtendedProperties["readonly"] != null)
                ? ExpTaxParent.Table.ExtendedProperties["readonly"].ToString().ToUpper()
                : "S";

            if (solaLettura == "S") {
                //gBoxGenerale.Enabled = false;
                cmbTipoRitenuta.Enabled = false;
                btnRitenuta.Enabled = false;
                gBoxScaglione.Enabled = false;
                grpCity.Enabled = false;
                grpRegion.Enabled = false;
                txtDataCompetenza.Enabled = false;
                txtImponibileLordo.Enabled = false;
                txtQuotaEsente.Enabled = false;
                // Do_Read_Value
                // se modulo Dipendenti 
                // l'anno competenza della ritenuta viene reso editabile
                // necessario per F24EP (principio di cassa allargato)
                string filterservice = QHS.CmpEq("idser", idSer);
                object module = Meta.Conn.DO_READ_VALUE("service", filterservice, "module");
                if ((module!=null) && (module!=DBNull.Value)&& (module.ToString().ToUpper()=="DIPENDENTE"))
                    txtAyear.Enabled = true; 
                else
                    txtAyear.Enabled = false; 
            }
        }

        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (T.TableName == "tax") {
                if (!Meta.DrawStateIsDone) return;
                DataRow Curr = DS.expensetax.Rows[0];
                if (R == null) {
                    grpCity.Visible = false;
                    grpRegion.Visible = false;
                    Curr["idcity"] = DBNull.Value;
                    Curr["idfiscaltaxregion"] = DBNull.Value;
                }
                else {
                    DataRow[] Tax = DS.tax.Select(QHC.CmpEq("taxcode", R["taxcode"]));
                    if (Tax.Length > 0) {
                        DataRow rTax = Tax[0];
                        string geo = rTax["geoappliance"].ToString().ToUpper();
                        switch (geo) {
                            case "C": {
                                    grpCity.Visible = true;
                                    grpRegion.Visible = false;
                                    Curr["idfiscaltaxregion"] = DBNull.Value;
                                    HelpForm.SetComboBoxValue(cmbRegioneFiscale, -1);
                                    break;
                                }
                            case "R": {
                                    grpCity.Visible = false;
                                    grpRegion.Visible = true;
                                    Curr["idcity"] = DBNull.Value;
                                    txtGeoComune0101.Text = "";
                                    txtProvincia.Text = "";
                                    break;
                                }
                            default: {
                                    grpCity.Visible = false;
                                    grpRegion.Visible = false;
                                    Curr["idcity"] = DBNull.Value;
                                    Curr["idfiscaltaxregion"] = DBNull.Value;
                                    txtGeoComune0101.Text = "";
                                    txtProvincia.Text = "";
                                    HelpForm.SetComboBoxValue(cmbRegioneFiscale, -1);
                                    break;
                                }
                        }
                    }
                }
            }
        }

		public void MetaData_AfterFill() {
			if (Meta.FirstFillForThisRow && Meta.EditMode) {
				calcolaVarConfronto();
			}

            if ((Meta.FirstFillForThisRow) && (DS.expensetax.Rows.Count > 0)){
                DataRow Curr = DS.expensetax.Rows[0];
                if (CfgFn.GetNoNullInt32(Curr["taxcode"]) == 0) {
                    grpCity.Visible = false;
                    grpRegion.Visible = false;
                }
                else {
                    DataRow [] Tax = DS.tax.Select(QHC.CmpEq("taxcode", Curr["taxcode"]));
                    if (Tax.Length > 0) {
                        DataRow rTax = Tax[0];
                        string geo = rTax["geoappliance"].ToString().ToUpper();
                        switch (geo) {
                            case "C": {
                                    grpCity.Visible = true;
                                    grpRegion.Visible = false;
                                    break;
                                }
                            case "R": {
                                    grpCity.Visible = false;
                                    grpRegion.Visible = true;
                                    break;
                                }
                            default: {
                                    grpCity.Visible = false;
                                    grpRegion.Visible = false;
                                    break;
                                }
                        }
                    }
                }
                abilitaGrpMovimento();
            }
		}

        private void abilitaGrpMovimento() {
            if (DS.expensetax.Rows.Count == 0) return;
            decimal importoDip = CfgFn.GetNoNullDecimal(
                HelpForm.GetObjectFromString(typeof(decimal), txtImportoDip.Text, "expensetax.employtax"));
            decimal importoAmm = CfgFn.GetNoNullDecimal(
                HelpForm.GetObjectFromString(typeof(decimal), txtImportoAmm.Text, "expensetax.admintax"));

            decimal importo = importoDip + importoAmm;

            if (importo >= 0) {
                txtNumeroMovimento.Text = "";
                txtEsercizioMovimento.Text = "";
                DataRow Curr = DS.expensetax.Rows[0];
                Curr["idinc"] = DBNull.Value;
                gboxentrata.Enabled = false;
            }
            else {
                gboxentrata.Enabled = true;
            }

            
        }

		private void calcolaVarConfronto() {
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.expensetax.Rows[0];
			lastImponibileLordo = CfgFn.GetNoNullDecimal(Curr["taxablegross"]);
			lastQuotaEsente = CfgFn.GetNoNullDecimal(Curr["exemptionquota"]);
			lastImponibileNetto = CfgFn.GetNoNullDecimal(Curr["taxablenet"]);

			lastAliquotaDip = CfgFn.GetNoNullDecimal(Curr["employrate"]);
			lastQuotaNumDip = CfgFn.GetNoNullDecimal(Curr["employnumerator"]);
			lastQuotaDenDip = CfgFn.GetNoNullDecimal(Curr["employdenominator"]);
			lastDetrazioni = CfgFn.GetNoNullDecimal(Curr["abatements"]);

			lastAliquotaAmm = CfgFn.GetNoNullDecimal(Curr["adminrate"]);
			lastQuotaNumAmm = CfgFn.GetNoNullDecimal(Curr["adminnumerator"]);
			lastQuotaDenAmm = CfgFn.GetNoNullDecimal(Curr["admindenominator"]);
		}

		private decimal calcRitenutaAmm() {
			DataRow Curr= DS.expensetax.Rows[0];
			decimal imponibileNetto = CfgFn.GetNoNullDecimal(Curr["taxablenet"]);
			decimal aliquota = CfgFn.GetNoNullDecimal(Curr["adminrate"]);
			double quotaNum = CfgFn.GetNoNullDouble(Curr["adminnumerator"]);
			double quotaDen = CfgFn.GetNoNullDouble(Curr["admindenominator"]);
			
			decimal imponibile = CfgFn.DecMulDiv(imponibileNetto, quotaNum, quotaDen);
			decimal importoRitenuta = imponibile * aliquota;
			return CfgFn.RoundValuta(importoRitenuta);
		}

		private decimal calcRitenutaDip() {
			DataRow Curr= DS.expensetax.Rows[0];
			decimal imponibileNetto = CfgFn.GetNoNullDecimal(Curr["taxablenet"]);
			decimal aliquota = CfgFn.GetNoNullDecimal(Curr["employrate"]);
			double quotaNum = CfgFn.GetNoNullDouble(Curr["employnumerator"]);
			double quotaDen = CfgFn.GetNoNullDouble(Curr["employdenominator"]);
			decimal detrazioni = CfgFn.GetNoNullDecimal(Curr["abatements"]);

			decimal imponibile = CfgFn.DecMulDiv(imponibileNetto, quotaNum, quotaDen);
			decimal importoRitenuta = imponibile * aliquota;
			importoRitenuta -= detrazioni;
			return CfgFn.RoundValuta(importoRitenuta);
		}

		private void txtImponibileLordo_Leave(object sender, System.EventArgs e) {
			if (inChiusura|| Meta.formController.isClosing) return;
			if (!Meta.InsertMode) return;
			object o = HelpForm.GetObjectFromString(typeof(decimal),txtImponibileLordo.Text,txtImponibileLordo.Tag.ToString());
            decimal imponibileLordo = CfgFn.GetNoNullDecimal(o);
			if (lastImponibileLordo != imponibileLordo) {
				decimal imponibileNetto = calcolaImponibileNetto(imponibileLordo,lastQuotaEsente);
                txtImponibileNetto.Text = HelpForm.StringValue(imponibileNetto, "x.y.c");
                    //imponibileNetto.ToString("c");
				Meta.GetFormData(true);
				calcolaRitenutaAggiornaTextBox("D");
				calcolaRitenutaAggiornaTextBox("A");
				lastImponibileLordo = imponibileLordo;
			}
		}

		private void txtQuotaEsente_Leave(object sender, System.EventArgs e) {
            if (inChiusura || Meta.formController.isClosing) return;
            if (!Meta.InsertMode) return;
			object o = HelpForm.GetObjectFromString(typeof(decimal),txtQuotaEsente.Text,txtQuotaEsente.Tag.ToString());
            decimal quotaEsente = CfgFn.GetNoNullDecimal(o);
			if (lastQuotaEsente != quotaEsente) {
				decimal imponibileNetto = calcolaImponibileNetto(lastImponibileLordo,quotaEsente);
				txtImponibileNetto.Text = imponibileNetto.ToString("c");
				Meta.GetFormData(true);
				calcolaRitenutaAggiornaTextBox("D");
				calcolaRitenutaAggiornaTextBox("A");
				lastQuotaEsente = quotaEsente;
			}
		}

		private decimal calcolaImponibileNetto(decimal imponibileLordo, decimal quotaEsente) {
			decimal imponibileNetto = (imponibileLordo > quotaEsente) ? imponibileLordo - quotaEsente : 0;
			return imponibileNetto;
		}

		/// <summary>
		/// Metodo che richiama il calcola della ritenuta dipendente e amministrazione ed aggiorna
		/// il text box corrispondente dell'importo della ritenuta
		/// </summary>
		/// <param name="tipo">D: Dipendente - A: Amministrazione</param>
		private void calcolaRitenutaAggiornaTextBox(string tipo) {
            if (Meta.destroyed) return;
            if (DS.expensetax.Rows.Count == 0) return;
            DataRow Curr = DS.expensetax.Rows[0];
			if (tipo == "D") {
                if(Curr["employrate"] != DBNull.Value && Curr["taxablenet"] != DBNull.Value) {
                    decimal ritDip = calcRitenutaDip();
                    txtImportoDip.Text = ritDip.ToString("c");
                }
			}
			if (tipo == "A") {
                if(Curr["adminrate"] != DBNull.Value && Curr["taxablenet"] != DBNull.Value) {
                    decimal ritAmm = calcRitenutaAmm();
                    txtImportoAmm.Text = ritAmm.ToString("c");
                }
			}
		}

		private decimal decimalDaTextBox(TextBox text) {
			object o = HelpForm.GetObjectFromString(typeof(decimal),text.Text,text.Tag.ToString());
			return ((o == null) || (o == DBNull.Value)) ? 0 : (decimal)o;
		}

		private void txtDetrazioni_Leave(object sender, System.EventArgs e) {
            if (inChiusura || Meta.formController.isClosing) return;
            decimal detrazioni = decimalDaTextBox(txtDetrazioni);
			if (detrazioni == lastDetrazioni) return;
			Meta.GetFormData(true);
			calcolaRitenutaAggiornaTextBox("D");
            abilitaGrpMovimento();
		}
		
		private void txtAliquotaDip_Leave(object sender, System.EventArgs e) {
            if (inChiusura || Meta.formController.isClosing) return;
            decimal aliquotaDip = decimalDaTextBox(txtAliquotaDip);
			if (aliquotaDip == lastAliquotaDip) return;
			Meta.GetFormData(true);
			calcolaRitenutaAggiornaTextBox("D");
            abilitaGrpMovimento();
		}

		private void txtQuotaDip1_Leave(object sender, System.EventArgs e) {
            if (inChiusura || Meta.formController.isClosing) return;
            decimal quotaNumDip = decimalDaTextBox(txtQuotaDip1);
			if (quotaNumDip == lastQuotaNumDip) return;
			Meta.GetFormData(true);
			calcolaRitenutaAggiornaTextBox("D");
            abilitaGrpMovimento();
		}

		private void txtQuotaDip2_Leave(object sender, System.EventArgs e) {
            if (inChiusura || Meta.formController.isClosing) return;
            decimal quotaDenDip = decimalDaTextBox(txtQuotaDip2);
			if (quotaDenDip == lastQuotaDenDip) return;
			Meta.GetFormData(true);
			calcolaRitenutaAggiornaTextBox("D");
            abilitaGrpMovimento();
		}

		private void txtAliquotaAmm_Leave(object sender, System.EventArgs e) {
            if (inChiusura || Meta.formController.isClosing) return;
            decimal aliquotaAmm = decimalDaTextBox(txtAliquotaAmm);
			if (aliquotaAmm == lastAliquotaAmm) return;
			Meta.GetFormData(true);
			calcolaRitenutaAggiornaTextBox("A");
            abilitaGrpMovimento();
		}

		private void txtQuotaAmm1_Leave(object sender, System.EventArgs e) {
            if (inChiusura || Meta.formController.isClosing) return;
            decimal quotaNumAmm = decimalDaTextBox(txtQuotaAmm1);
			if (quotaNumAmm == lastQuotaNumAmm) return;
			Meta.GetFormData(true);
			calcolaRitenutaAggiornaTextBox("A");
            abilitaGrpMovimento();
		}

		private void txtQuotaAmm2_Leave(object sender, System.EventArgs e) {
            if (inChiusura || Meta.formController.isClosing) return;
            decimal quotaDenAmm = decimalDaTextBox(txtQuotaAmm2);
			if (quotaDenAmm == lastQuotaDenAmm) return;
			Meta.GetFormData(true);
			calcolaRitenutaAggiornaTextBox("A");
            abilitaGrpMovimento();
		}

		private void txtImponibileNetto_Leave(object sender, System.EventArgs e) {
            if (inChiusura || Meta.formController.isClosing) return;
            decimal imponibileNetto = decimalDaTextBox(txtImponibileNetto);
			if (imponibileNetto == lastImponibileNetto) return;
			Meta.GetFormData(true);
			calcolaRitenutaAggiornaTextBox("D");
			calcolaRitenutaAggiornaTextBox("A");
            abilitaGrpMovimento();
		}

	    private void btnSelectMov_Click(object sender, EventArgs e) {
	        if (Meta.IsEmpty) return;
	        Meta.GetFormData(true);

	        string filterPhase = QHC.CmpEq("nphase", Meta.GetSys("maxincomephase"));

	        DataRow Curr = DS.expensetax.Rows[0];
	        decimal importo = -(CfgFn.GetNoNullDecimal(Curr["employtax"])
	                            + CfgFn.GetNoNullDecimal(Curr["admintax"]));

	        //DataTable tUpb = DataAccess.RUN_SELECT(Meta.Conn, "upb", "*", null, QHS.CmpEq("idupb", "0001"),
	        //    null, null, true);

	        //DataTable tFinView = DataAccess.RUN_SELECT(Meta.Conn, "finview", "*", null,
	        //    QHS.AppAnd(QHS.CmpEq("idupb", "0001"), QHS.CmpEq("ayear", Meta.GetSys("esercizio")),
	        //    QHS.BitSet("flag", 0)), 
	        //    null, null, true);

	        //FrmAskFase F = new FrmAskFase(importo, tUpb, tFinView, Meta.Dispatcher, Meta.Conn);
	        //if (F.ShowDialog() != DialogResult.OK) return;

	        FrmAskInfo fInfo = new FrmAskInfo(Meta, "E", true)
	            .EnableManagerSelection(true)
	            .AllowNoManagerSelection(true)
	            .EnableFinSelection(true)
	            .EnableUPBSelection(true)
	            .AllowNoUpbSelection(true)
	            .AllowNoFinSelection(true)
                .AllowNoManagerSelection(true)
                .EnableFilterAvailable(importo);
	        fInfo.Text = "Impostazione filtro per ricerca movimento";
	        fInfo.gboxUPB.Text = "Selezionare l'UPB  (opzionale)";
	        fInfo.gboxBilAnnuale.Text = "Selezionare la voce di bilancio (opzionale)";
	        if (fInfo.ShowDialog() != DialogResult.OK) return;

	        int selectedfase = CfgFn.GetNoNullInt32(Meta.GetSys("maxincomephase"));

	        string filter = "";
	        string filterUpb = QHS.CmpEq("idupb", "0001");
	        string filterFin = "";
	        string filterMan = "";

	        if (selectedfase > 0) filter = GetData.MergeFilters(filter, QHS.CmpEq("nphase", selectedfase));
	        // Aggiunta filtro dell'UPB e del Bilancio

	        if (fInfo.GetUPB() != DBNull.Value) {
	            filterUpb = QHS.CmpEq("idupb", fInfo.GetUPB());
	        }
	        if (fInfo.GetFin() != DBNull.Value) {
	            filterFin = QHS.CmpEq("idfin", fInfo.GetFin());
	        }

	        if (fInfo.GetManager() != DBNull.Value) {
	            filterMan = QHS.CmpEq("idman", fInfo.GetManager());
	        }
	        filter = GetData.MergeFilters(filter, filterUpb);
	        if (filterFin != "") {
	            filter = GetData.MergeFilters(filter, filterFin);
	        }
	        if (filterMan != "") {
	            filter = GetData.MergeFilters(filter, filterMan);
	        }

	        if (importo > 0) {
	            filter = GetData.MergeFilters(filter, QHS.CmpGe("curramount", importo));
	        }
	        else {
	            filter = GetData.MergeFilters(filter, QHS.CmpGt("curramount", 0));
	        }

	        MetaData E = Meta.Dispatcher.Get("income");
	        E.FilterLocked = true;
	        E.DS = DS.Clone();
	        DataRow Choosen = E.SelectOne("default", filter, "income", null);
	        if (Choosen == null) {
	            return;
	        }
	        Curr["idinc"] = Choosen["idinc"];

	        DS.incomeview.Clear();
	        Meta.Conn.RUN_SELECT_INTO_TABLE(DS.incomeview, null,
	            QHS.AppAnd(QHS.CmpEq("idinc", Curr["idinc"]),
	                QHS.DoPar(
	                    QHS.AppOr(QHS.CmpEq("ayear", Meta.GetSys("esercizio")),
	                        QHS.CmpEq("ayear", 1 + CfgFn.GetNoNullInt32(Meta.GetSys("esercizio")))
	                        )
	                    )),
	            null, true);
	        Meta.FreshForm(false);
	    }

	    private void txtNumeroMovimento_Leave(object sender, EventArgs e) {
            if (inChiusura || Meta.formController.isClosing) return;
            if (txtNumeroMovimento.Text.Trim() != "") {
                DoChooseCommand((Control)sender);
                return;
            }
            //if txtNumentrata is empty:
            if (Meta.IsEmpty) return;
            ClearEntrata(false);	
        }

        private void ClearEntrata(bool ClearEsercizio) {
            txtNumeroMovimento.Text = "";
            if (ClearEsercizio) txtEsercizioMovimento.Text = "";
            if (Meta.IsEmpty) return;
            DS.expensetax.Rows[0]["idinc"] = DBNull.Value;
            DS.incomeview.Clear();
        }

        private void DoChooseCommand(Control sender) {
            string mycommand = "choose.incomeview.movimentoentrata";
            string filter1 = "";
            if (txtEsercizioMovimento.Text.Trim() != "") {
                filter1 = QHS.CmpEq("ymov", txtEsercizioMovimento.Text);
            }

            if (txtNumeroMovimento.Text.Trim() != "") {
                filter1 = QHS.AppAnd(filter1, QHS.CmpEq("nmov", txtNumeroMovimento.Text));
            }

            DataRow Curr = DS.expensetax.Rows[0];
            decimal importo = - (CfgFn.GetNoNullDecimal(Curr["employtax"]) + 
                CfgFn.GetNoNullDecimal(Curr["admintax"]));
            string fAmount = "";
            if (importo > 0) {
                fAmount = QHS.CmpGe("curramount", importo);
            }
            else {
                fAmount = QHS.CmpGt("curramount", 0);
            }
            filter1 = QHS.AppAnd(filter1, fAmount);

            filter1 = QHS.AppAnd(filter1, QHS.CmpEq("nphase", Meta.GetSys("maxincomephase")));

            if (filter1 != "") mycommand += "." + filter1;
            if (!MetaData.Choose(this, mycommand)) {
                if (sender != null) sender.Focus();
            }
        }

        private void txtImportoDip_Leave(object sender, EventArgs e) {
            abilitaGrpMovimento();
        }

        private void txtImportoAmm_Leave(object sender, EventArgs e) {
            abilitaGrpMovimento();
        }

        private void Frm_expensetax_default_FormClosing(object sender, FormClosingEventArgs e) {
            inChiusura = true;
        }
    }
}
