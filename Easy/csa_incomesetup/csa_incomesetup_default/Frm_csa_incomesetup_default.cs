
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
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;

namespace csa_incomesetup_default
{
	/// <summary>
	/// </summary>
    public class Frm_csa_incomesetup_default : System.Windows.Forms.Form {
        public vistaForm DS;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.ImageList imageList1;
        private TextBox tipo;
        private Label label2;
        private GroupBox groupBox3;
        private TextBox txtEsercizio;
        private Label label1;
        private TextBox textBox5;
        private Label label4;
        private GroupBox groupBox4;
        private GroupBox groupBox2;
        private TextBox textBox3;
        private TextBox txtCodiceContoInt;
        private Button button3;
        private GroupBox grpBilancioEntrata;
        private TextBox txtDescrBilancioEntrata;
        private TextBox txtBilancioEntrataInt;
        private Button btnBilancioEntrata;
        private GroupBox groupBox5;
        private GroupBox groupBox1;
        private TextBox textBox1;
        private Button button1;
        private GroupBox grpBilancioVersamentoRit;
        private TextBox txtDescrBilancioVersamentoRit;
        private TextBox txtBilancioSpesa;
        private Button btnBilancioRit;
        private GroupBox groupBox6;
        private GroupBox gboxConto;
        private TextBox txtDenominazioneConto;
        private TextBox txtCodiceContoDebito;
        private Button button2;
        private GroupBox grpBilancioEntrataRit;
        private TextBox txtDescrBilancioEntrataRit;
        private TextBox txtBilancioEntrata;
        private Button btnBilancioEntrataRit;
        private TextBox txtCodiceContoEnte;
        private GroupBox gBoxContoRicavo;
        private TextBox txtDenominazioneContoRicavo;
        private TextBox txtCodiceContoRicavo;
        private Button button4;
        private GroupBox groupBox7;
        private TextBox textBox2;
        private TextBox txtCodiceContoCreditoEnte;
        private Button button5;
        private GroupBox grpModalitaRecuperi;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        public GroupBox grpSiopeEntrata;
        public Button btnSiopeEntrata;
        private TextBox txtDescrSiopeEntrata;
        private TextBox txtSiopeEntrataInt;
        public GroupBox grpSiopeVersamentoRit;
        public Button btnSiopeRit;
        private TextBox txtDescrSiopeVersamentoRit;
        private TextBox txtSiopeSpesa;
        public GroupBox grpSiopeEntrataRit;
        public Button btnSiopeEntrataRit;
        private TextBox txtDescrSiopeEntrataRit;
        private TextBox txtSiopeEntrataRit;
        private GroupBox grpBilancioSpesaCosto;
        private TextBox textBox4;
        private TextBox txtBilancioSpesaCosto;
        private Button button6;
        private GroupBox grpContoCosto;
        private TextBox textBox8;
        private TextBox txtCodiceContoCosto;
        private Button button7;
        public GroupBox grpSiopeSpesaCosto;
        public Button btnSiopeSpesaCost;
        private TextBox textBox10;
        private TextBox txtSiopeSpesaCosto;
        private Label label3;
        private ComboBox cmbVoceCsaUnified;
        private GroupBox gboxUPB;
        public TextBox txtUPB;
        private Button btnUPB;
        private TextBox txtDescrUPB;
        private GroupBox groupBox8;
        private GroupBox groupBox9;
        private GroupBox groupBox10;
        private Label lblEsitoConfigurazione;
        private Label label5;
        private Label label6;
        private Label label8;
        private Label label7;
        private Label label14;
        private Label label13;
        private Label label9;
        private Label label10;
        private Label label12;
        private Label label11;
        private Label label15;
        private Label label16;
        private Label label20;
        private Label label21;
        private Label label19;
        private Label label18;
        private Label label17;
        private Label label22;
        MetaData Meta;
//		int bilancio;

        Dictionary<Label, Color> saved= new Dictionary<Label, Color>();

	    void saveLabelColor(Control c) {

	        if (typeof(Label) == c.GetType() && c.Text == "Ritenuta" || c.Text == "Contributo" || c.Text == "Recupero") {
	            saved[(Label) c] = c.BackColor;
	        }

	        foreach (Control cc in c.Controls) {
                saveLabelColor(cc);
	        }
	    }
	    void restoreLabelColor() {
	        foreach (Label l in saved.Keys) {
	            l.BackColor = saved[l];
	        }
	    }

		public Frm_csa_incomesetup_default()
		{
            
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			DataAccess.SetTableForReading(DS.finincome,"fin");
			DataAccess.SetTableForReading(DS.finexpense,"fin");
            DataAccess.SetTableForReading(DS.finexpensecost, "fin");
			DataAccess.SetTableForReading(DS.finincomeclawback,"fin");
            DataAccess.SetTableForReading(DS.accountdebit,"account");
            DataAccess.SetTableForReading(DS.accountente ,"account");
            DataAccess.SetTableForReading(DS.accountclawback,"account");
            DataAccess.SetTableForReading(DS.account_revenue, "account");
            DataAccess.SetTableForReading(DS.accountcreditente, "account");
            DataAccess.SetTableForReading(DS.account_cost, "account");
		    saveLabelColor(this);

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_csa_incomesetup_default));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tipo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtEsercizio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.grpContoCosto = new System.Windows.Forms.GroupBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.txtCodiceContoCosto = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtCodiceContoCreditoEnte = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.gBoxContoRicavo = new System.Windows.Forms.GroupBox();
            this.txtDenominazioneContoRicavo = new System.Windows.Forms.TextBox();
            this.txtCodiceContoRicavo = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtCodiceContoEnte = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.gboxUPB = new System.Windows.Forms.GroupBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtUPB = new System.Windows.Forms.TextBox();
            this.btnUPB = new System.Windows.Forms.Button();
            this.txtDescrUPB = new System.Windows.Forms.TextBox();
            this.grpSiopeSpesaCosto = new System.Windows.Forms.GroupBox();
            this.btnSiopeSpesaCost = new System.Windows.Forms.Button();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.txtSiopeSpesaCosto = new System.Windows.Forms.TextBox();
            this.grpBilancioSpesaCosto = new System.Windows.Forms.GroupBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.txtBilancioSpesaCosto = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.grpSiopeEntrata = new System.Windows.Forms.GroupBox();
            this.btnSiopeEntrata = new System.Windows.Forms.Button();
            this.txtDescrSiopeEntrata = new System.Windows.Forms.TextBox();
            this.txtSiopeEntrataInt = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.txtCodiceContoInt = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.grpBilancioEntrata = new System.Windows.Forms.GroupBox();
            this.txtDescrBilancioEntrata = new System.Windows.Forms.TextBox();
            this.txtBilancioEntrataInt = new System.Windows.Forms.TextBox();
            this.btnBilancioEntrata = new System.Windows.Forms.Button();
            this.DS = new csa_incomesetup_default.vistaForm();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.grpModalitaRecuperi = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.grpSiopeVersamentoRit = new System.Windows.Forms.GroupBox();
            this.btnSiopeRit = new System.Windows.Forms.Button();
            this.txtDescrSiopeVersamentoRit = new System.Windows.Forms.TextBox();
            this.txtSiopeSpesa = new System.Windows.Forms.TextBox();
            this.grpBilancioVersamentoRit = new System.Windows.Forms.GroupBox();
            this.txtDescrBilancioVersamentoRit = new System.Windows.Forms.TextBox();
            this.txtBilancioSpesa = new System.Windows.Forms.TextBox();
            this.btnBilancioRit = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.gboxConto = new System.Windows.Forms.GroupBox();
            this.txtDenominazioneConto = new System.Windows.Forms.TextBox();
            this.txtCodiceContoDebito = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.grpSiopeEntrataRit = new System.Windows.Forms.GroupBox();
            this.btnSiopeEntrataRit = new System.Windows.Forms.Button();
            this.txtDescrSiopeEntrataRit = new System.Windows.Forms.TextBox();
            this.txtSiopeEntrataRit = new System.Windows.Forms.TextBox();
            this.grpBilancioEntrataRit = new System.Windows.Forms.GroupBox();
            this.txtDescrBilancioEntrataRit = new System.Windows.Forms.TextBox();
            this.txtBilancioEntrata = new System.Windows.Forms.TextBox();
            this.btnBilancioEntrataRit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbVoceCsaUnified = new System.Windows.Forms.ComboBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblEsitoConfigurazione = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.grpContoCosto.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.gBoxContoRicavo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gboxUPB.SuspendLayout();
            this.grpSiopeSpesaCosto.SuspendLayout();
            this.grpBilancioSpesaCosto.SuspendLayout();
            this.grpSiopeEntrata.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpBilancioEntrata.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.grpModalitaRecuperi.SuspendLayout();
            this.grpSiopeVersamentoRit.SuspendLayout();
            this.grpBilancioVersamentoRit.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.gboxConto.SuspendLayout();
            this.grpSiopeEntrataRit.SuspendLayout();
            this.grpBilancioEntrataRit.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            // 
            // tipo
            // 
            this.tipo.Location = new System.Drawing.Point(13, 44);
            this.tipo.Name = "tipo";
            this.tipo.Size = new System.Drawing.Size(439, 20);
            this.tipo.TabIndex = 1;
            this.tipo.Tag = "csa_incomesetup.vocecsa";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 26);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(73, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Voce CSA:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.txtEsercizio);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.textBox5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(461, 35);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(326, 69);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // txtEsercizio
            // 
            this.txtEsercizio.Location = new System.Drawing.Point(90, 15);
            this.txtEsercizio.Name = "txtEsercizio";
            this.txtEsercizio.ReadOnly = true;
            this.txtEsercizio.Size = new System.Drawing.Size(80, 20);
            this.txtEsercizio.TabIndex = 1;
            this.txtEsercizio.Tag = "csa_incomesetup.ayear.year";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(40, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 0;
            this.label1.Tag = "";
            this.label1.Text = "Esercizio";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(90, 43);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(80, 20);
            this.textBox5.TabIndex = 2;
            this.textBox5.Tag = "csa_incomesetup.idcsa_incomesetup";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(41, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 20);
            this.label4.TabIndex = 0;
            this.label4.Tag = "";
            this.label4.Text = "Numero";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Bisque;
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.grpContoCosto);
            this.groupBox4.Controls.Add(this.groupBox7);
            this.groupBox4.Controls.Add(this.gBoxContoRicavo);
            this.groupBox4.Controls.Add(this.groupBox1);
            this.groupBox4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox4.Location = new System.Drawing.Point(13, 510);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(946, 177);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Conti EP";
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.Yellow;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(806, 147);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(75, 20);
            this.label20.TabIndex = 23;
            this.label20.Text = "Contributo";
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.Aqua;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(806, 124);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(75, 20);
            this.label21.TabIndex = 22;
            this.label21.Text = "Ritenuta";
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.Yellow;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(372, 140);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(75, 20);
            this.label19.TabIndex = 21;
            this.label19.Text = "Contributo";
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.Aqua;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(372, 117);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(75, 20);
            this.label18.TabIndex = 18;
            this.label18.Text = "Ritenuta";
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Yellow;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(371, 68);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(75, 20);
            this.label17.TabIndex = 10;
            this.label17.Text = "Contributo";
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.SpringGreen;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(806, 46);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 20);
            this.label14.TabIndex = 9;
            this.label14.Text = "Recupero";
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.SpringGreen;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(371, 46);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 20);
            this.label13.TabIndex = 8;
            this.label13.Text = "Recupero";
            // 
            // grpContoCosto
            // 
            this.grpContoCosto.Controls.Add(this.textBox8);
            this.grpContoCosto.Controls.Add(this.txtCodiceContoCosto);
            this.grpContoCosto.Controls.Add(this.button7);
            this.grpContoCosto.Location = new System.Drawing.Point(459, 20);
            this.grpContoCosto.Name = "grpContoCosto";
            this.grpContoCosto.Size = new System.Drawing.Size(341, 72);
            this.grpContoCosto.TabIndex = 7;
            this.grpContoCosto.TabStop = false;
            this.grpContoCosto.Tag = "AutoManage.txtCodiceContoCosto.tree";
            this.grpContoCosto.Text = "Conto di Costo (Recupero negativo)";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(136, 16);
            this.textBox8.Multiline = true;
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox8.Size = new System.Drawing.Size(197, 52);
            this.textBox8.TabIndex = 0;
            this.textBox8.TabStop = false;
            this.textBox8.Tag = "account_cost.title";
            // 
            // txtCodiceContoCosto
            // 
            this.txtCodiceContoCosto.Location = new System.Drawing.Point(8, 48);
            this.txtCodiceContoCosto.Name = "txtCodiceContoCosto";
            this.txtCodiceContoCosto.Size = new System.Drawing.Size(120, 20);
            this.txtCodiceContoCosto.TabIndex = 3;
            this.txtCodiceContoCosto.Tag = "account_cost.codeacc?x";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(8, 16);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(120, 23);
            this.button7.TabIndex = 1;
            this.button7.TabStop = false;
            this.button7.Tag = "manage.account_cost.tree";
            this.button7.Text = "Conto";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.textBox2);
            this.groupBox7.Controls.Add(this.txtCodiceContoCreditoEnte);
            this.groupBox7.Controls.Add(this.button5);
            this.groupBox7.Location = new System.Drawing.Point(459, 101);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(341, 72);
            this.groupBox7.TabIndex = 2;
            this.groupBox7.TabStop = false;
            this.groupBox7.Tag = "AutoManage.txtCodiceContoCreditoEnte.tree";
            this.groupBox7.Text = "Conto di Credito verso Ente";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(136, 16);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(197, 52);
            this.textBox2.TabIndex = 0;
            this.textBox2.TabStop = false;
            this.textBox2.Tag = "accountcreditente.title";
            // 
            // txtCodiceContoCreditoEnte
            // 
            this.txtCodiceContoCreditoEnte.Location = new System.Drawing.Point(8, 43);
            this.txtCodiceContoCreditoEnte.Name = "txtCodiceContoCreditoEnte";
            this.txtCodiceContoCreditoEnte.Size = new System.Drawing.Size(120, 20);
            this.txtCodiceContoCreditoEnte.TabIndex = 3;
            this.txtCodiceContoCreditoEnte.Tag = "accountcreditente.codeacc?csa_incomesetupview.codeacc_agency_credit";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(8, 16);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(120, 23);
            this.button5.TabIndex = 1;
            this.button5.TabStop = false;
            this.button5.Tag = "manage.accountcreditente.tree";
            this.button5.Text = "Conto";
            // 
            // gBoxContoRicavo
            // 
            this.gBoxContoRicavo.Controls.Add(this.txtDenominazioneContoRicavo);
            this.gBoxContoRicavo.Controls.Add(this.txtCodiceContoRicavo);
            this.gBoxContoRicavo.Controls.Add(this.button4);
            this.gBoxContoRicavo.Location = new System.Drawing.Point(8, 20);
            this.gBoxContoRicavo.Name = "gBoxContoRicavo";
            this.gBoxContoRicavo.Size = new System.Drawing.Size(357, 72);
            this.gBoxContoRicavo.TabIndex = 3;
            this.gBoxContoRicavo.TabStop = false;
            this.gBoxContoRicavo.Tag = "AutoManage.txtCodiceContoRicavo.tree";
            this.gBoxContoRicavo.Text = "Conto di Ricavo (Recupero positivo o Contributo negativo)";
            // 
            // txtDenominazioneContoRicavo
            // 
            this.txtDenominazioneContoRicavo.Location = new System.Drawing.Point(136, 16);
            this.txtDenominazioneContoRicavo.Multiline = true;
            this.txtDenominazioneContoRicavo.Name = "txtDenominazioneContoRicavo";
            this.txtDenominazioneContoRicavo.ReadOnly = true;
            this.txtDenominazioneContoRicavo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDenominazioneContoRicavo.Size = new System.Drawing.Size(213, 52);
            this.txtDenominazioneContoRicavo.TabIndex = 0;
            this.txtDenominazioneContoRicavo.TabStop = false;
            this.txtDenominazioneContoRicavo.Tag = "account_revenue.title";
            // 
            // txtCodiceContoRicavo
            // 
            this.txtCodiceContoRicavo.Location = new System.Drawing.Point(8, 48);
            this.txtCodiceContoRicavo.Name = "txtCodiceContoRicavo";
            this.txtCodiceContoRicavo.Size = new System.Drawing.Size(120, 20);
            this.txtCodiceContoRicavo.TabIndex = 3;
            this.txtCodiceContoRicavo.Tag = "account_revenue.codeacc?x";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(8, 16);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(120, 23);
            this.button4.TabIndex = 1;
            this.button4.TabStop = false;
            this.button4.Tag = "manage.account_revenue.tree";
            this.button4.Text = "Conto";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.txtCodiceContoEnte);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(10, 98);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(356, 72);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "AutoManage.txtCodiceContoEnte.tree";
            this.groupBox1.Text = "Conto di Debito verso Ente";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(134, 16);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(214, 52);
            this.textBox1.TabIndex = 0;
            this.textBox1.TabStop = false;
            this.textBox1.Tag = "accountente.title";
            // 
            // txtCodiceContoEnte
            // 
            this.txtCodiceContoEnte.Location = new System.Drawing.Point(8, 42);
            this.txtCodiceContoEnte.Name = "txtCodiceContoEnte";
            this.txtCodiceContoEnte.Size = new System.Drawing.Size(120, 20);
            this.txtCodiceContoEnte.TabIndex = 2;
            this.txtCodiceContoEnte.Tag = "accountente.codeacc?csa_incomesetupview.codeacc_ente";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 23);
            this.button1.TabIndex = 1;
            this.button1.TabStop = false;
            this.button1.Tag = "manage.accountente.tree";
            this.button1.Text = "Conto";
            // 
            // gboxUPB
            // 
            this.gboxUPB.Controls.Add(this.label22);
            this.gboxUPB.Controls.Add(this.txtUPB);
            this.gboxUPB.Controls.Add(this.btnUPB);
            this.gboxUPB.Controls.Add(this.txtDescrUPB);
            this.gboxUPB.Location = new System.Drawing.Point(9, 16);
            this.gboxUPB.Name = "gboxUPB";
            this.gboxUPB.Size = new System.Drawing.Size(569, 81);
            this.gboxUPB.TabIndex = 9;
            this.gboxUPB.TabStop = false;
            this.gboxUPB.Tag = "AutoChoose.txtUPB.default.(active=\'S\')";
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.SpringGreen;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(419, 39);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(75, 20);
            this.label22.TabIndex = 9;
            this.label22.Text = "Recupero";
            // 
            // txtUPB
            // 
            this.txtUPB.Location = new System.Drawing.Point(5, 47);
            this.txtUPB.Name = "txtUPB";
            this.txtUPB.Size = new System.Drawing.Size(193, 20);
            this.txtUPB.TabIndex = 7;
            this.txtUPB.Tag = "upb.codeupb?x";
            // 
            // btnUPB
            // 
            this.btnUPB.Location = new System.Drawing.Point(6, 15);
            this.btnUPB.Name = "btnUPB";
            this.btnUPB.Size = new System.Drawing.Size(110, 24);
            this.btnUPB.TabIndex = 1;
            this.btnUPB.TabStop = false;
            this.btnUPB.Tag = "manage.upb.tree";
            this.btnUPB.Text = "UPB";
            // 
            // txtDescrUPB
            // 
            this.txtDescrUPB.Location = new System.Drawing.Point(219, 15);
            this.txtDescrUPB.Multiline = true;
            this.txtDescrUPB.Name = "txtDescrUPB";
            this.txtDescrUPB.ReadOnly = true;
            this.txtDescrUPB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescrUPB.Size = new System.Drawing.Size(194, 56);
            this.txtDescrUPB.TabIndex = 2;
            this.txtDescrUPB.TabStop = false;
            this.txtDescrUPB.Tag = "upb.title";
            // 
            // grpSiopeSpesaCosto
            // 
            this.grpSiopeSpesaCosto.Controls.Add(this.btnSiopeSpesaCost);
            this.grpSiopeSpesaCosto.Controls.Add(this.textBox10);
            this.grpSiopeSpesaCosto.Controls.Add(this.txtSiopeSpesaCosto);
            this.grpSiopeSpesaCosto.Location = new System.Drawing.Point(458, 101);
            this.grpSiopeSpesaCosto.Name = "grpSiopeSpesaCosto";
            this.grpSiopeSpesaCosto.Size = new System.Drawing.Size(342, 72);
            this.grpSiopeSpesaCosto.TabIndex = 8;
            this.grpSiopeSpesaCosto.TabStop = false;
            this.grpSiopeSpesaCosto.Tag = "AutoManage.txtSiopeSpesaCosto.treeclassmovimenti";
            this.grpSiopeSpesaCosto.Text = "Siope Spese (Recupero negativo)";
            // 
            // btnSiopeSpesaCost
            // 
            this.btnSiopeSpesaCost.Location = new System.Drawing.Point(8, 16);
            this.btnSiopeSpesaCost.Name = "btnSiopeSpesaCost";
            this.btnSiopeSpesaCost.Size = new System.Drawing.Size(88, 23);
            this.btnSiopeSpesaCost.TabIndex = 4;
            this.btnSiopeSpesaCost.TabStop = false;
            this.btnSiopeSpesaCost.Tag = "manage.sortingexpensecost.tree";
            this.btnSiopeSpesaCost.Text = "Codice";
            this.btnSiopeSpesaCost.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBox10
            // 
            this.textBox10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox10.Location = new System.Drawing.Point(102, 16);
            this.textBox10.Multiline = true;
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            this.textBox10.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox10.Size = new System.Drawing.Size(232, 52);
            this.textBox10.TabIndex = 3;
            this.textBox10.TabStop = false;
            this.textBox10.Tag = "sortingexpensecost.description";
            // 
            // txtSiopeSpesaCosto
            // 
            this.txtSiopeSpesaCosto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSiopeSpesaCosto.Location = new System.Drawing.Point(8, 40);
            this.txtSiopeSpesaCosto.Name = "txtSiopeSpesaCosto";
            this.txtSiopeSpesaCosto.Size = new System.Drawing.Size(88, 20);
            this.txtSiopeSpesaCosto.TabIndex = 5;
            this.txtSiopeSpesaCosto.Tag = "sortingexpensecost.sortcode?csa_incomesetupview.sortcode_cost";
            // 
            // grpBilancioSpesaCosto
            // 
            this.grpBilancioSpesaCosto.Controls.Add(this.textBox4);
            this.grpBilancioSpesaCosto.Controls.Add(this.txtBilancioSpesaCosto);
            this.grpBilancioSpesaCosto.Controls.Add(this.button6);
            this.grpBilancioSpesaCosto.Location = new System.Drawing.Point(460, 19);
            this.grpBilancioSpesaCosto.Name = "grpBilancioSpesaCosto";
            this.grpBilancioSpesaCosto.Size = new System.Drawing.Size(345, 72);
            this.grpBilancioSpesaCosto.TabIndex = 6;
            this.grpBilancioSpesaCosto.TabStop = false;
            this.grpBilancioSpesaCosto.Tag = "AutoManage.txtBilancioSpesaCosto.trees";
            this.grpBilancioSpesaCosto.Text = "Capitolo di spesa Recupero negativo";
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.Location = new System.Drawing.Point(144, 16);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox4.Size = new System.Drawing.Size(193, 48);
            this.textBox4.TabIndex = 0;
            this.textBox4.TabStop = false;
            this.textBox4.Tag = "finexpensecost.title";
            // 
            // txtBilancioSpesaCosto
            // 
            this.txtBilancioSpesaCosto.Location = new System.Drawing.Point(8, 40);
            this.txtBilancioSpesaCosto.Name = "txtBilancioSpesaCosto";
            this.txtBilancioSpesaCosto.Size = new System.Drawing.Size(128, 20);
            this.txtBilancioSpesaCosto.TabIndex = 1;
            this.txtBilancioSpesaCosto.Tag = "finexpensecost.codefin?csa_incomesetupview.codefin_cost";
            // 
            // button6
            // 
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.ImageIndex = 0;
            this.button6.ImageList = this.imageList1;
            this.button6.Location = new System.Drawing.Point(8, 16);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(72, 24);
            this.button6.TabIndex = 1;
            this.button6.TabStop = false;
            this.button6.Tag = "manage.finexpensecost.trees";
            this.button6.Text = "Bilancio";
            this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpSiopeEntrata
            // 
            this.grpSiopeEntrata.Controls.Add(this.btnSiopeEntrata);
            this.grpSiopeEntrata.Controls.Add(this.txtDescrSiopeEntrata);
            this.grpSiopeEntrata.Controls.Add(this.txtSiopeEntrataInt);
            this.grpSiopeEntrata.Location = new System.Drawing.Point(459, 19);
            this.grpSiopeEntrata.Name = "grpSiopeEntrata";
            this.grpSiopeEntrata.Size = new System.Drawing.Size(341, 72);
            this.grpSiopeEntrata.TabIndex = 5;
            this.grpSiopeEntrata.TabStop = false;
            this.grpSiopeEntrata.Tag = "AutoManage.txtSiopeEntrataInt.treeclassmovimenti";
            this.grpSiopeEntrata.Text = "Siope Entrate (Recupero positivo o Contributo negativo)";
            // 
            // btnSiopeEntrata
            // 
            this.btnSiopeEntrata.Location = new System.Drawing.Point(8, 16);
            this.btnSiopeEntrata.Name = "btnSiopeEntrata";
            this.btnSiopeEntrata.Size = new System.Drawing.Size(88, 23);
            this.btnSiopeEntrata.TabIndex = 4;
            this.btnSiopeEntrata.TabStop = false;
            this.btnSiopeEntrata.Tag = "manage.sortingincomeclawback.tree";
            this.btnSiopeEntrata.Text = "Codice";
            this.btnSiopeEntrata.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDescrSiopeEntrata
            // 
            this.txtDescrSiopeEntrata.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrSiopeEntrata.Location = new System.Drawing.Point(102, 16);
            this.txtDescrSiopeEntrata.Multiline = true;
            this.txtDescrSiopeEntrata.Name = "txtDescrSiopeEntrata";
            this.txtDescrSiopeEntrata.ReadOnly = true;
            this.txtDescrSiopeEntrata.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescrSiopeEntrata.Size = new System.Drawing.Size(231, 52);
            this.txtDescrSiopeEntrata.TabIndex = 3;
            this.txtDescrSiopeEntrata.TabStop = false;
            this.txtDescrSiopeEntrata.Tag = "sortingincomeclawback.description";
            // 
            // txtSiopeEntrataInt
            // 
            this.txtSiopeEntrataInt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSiopeEntrataInt.Location = new System.Drawing.Point(8, 40);
            this.txtSiopeEntrataInt.Name = "txtSiopeEntrataInt";
            this.txtSiopeEntrataInt.Size = new System.Drawing.Size(88, 20);
            this.txtSiopeEntrataInt.TabIndex = 5;
            this.txtSiopeEntrataInt.Tag = "sortingincomeclawback.sortcode?csa_incomesetupview.sortcode_clawback";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.txtCodiceContoInt);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Location = new System.Drawing.Point(9, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(357, 72);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Tag = "AutoManage.txtCodiceContoInt.tree";
            this.groupBox2.Text = "Conto EP di  Credito interno (recuperi in p. di giro)";
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Location = new System.Drawing.Point(134, 16);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox3.Size = new System.Drawing.Size(216, 52);
            this.textBox3.TabIndex = 0;
            this.textBox3.TabStop = false;
            this.textBox3.Tag = "accountclawback.title";
            // 
            // txtCodiceContoInt
            // 
            this.txtCodiceContoInt.Location = new System.Drawing.Point(8, 42);
            this.txtCodiceContoInt.Name = "txtCodiceContoInt";
            this.txtCodiceContoInt.Size = new System.Drawing.Size(120, 20);
            this.txtCodiceContoInt.TabIndex = 2;
            this.txtCodiceContoInt.Tag = "accountclawback.codeacc?csa_incomesetupvew.codeacc_internalcredit";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(8, 16);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(120, 23);
            this.button3.TabIndex = 1;
            this.button3.TabStop = false;
            this.button3.Tag = "manage.accountclawback.tree";
            this.button3.Text = "Conto";
            // 
            // grpBilancioEntrata
            // 
            this.grpBilancioEntrata.Controls.Add(this.txtDescrBilancioEntrata);
            this.grpBilancioEntrata.Controls.Add(this.txtBilancioEntrataInt);
            this.grpBilancioEntrata.Controls.Add(this.btnBilancioEntrata);
            this.grpBilancioEntrata.Location = new System.Drawing.Point(461, 19);
            this.grpBilancioEntrata.Name = "grpBilancioEntrata";
            this.grpBilancioEntrata.Size = new System.Drawing.Size(345, 72);
            this.grpBilancioEntrata.TabIndex = 1;
            this.grpBilancioEntrata.TabStop = false;
            this.grpBilancioEntrata.Tag = "AutoManage.txtBilancioEntrataInt.treee";
            this.grpBilancioEntrata.Text = "Capitolo di entrata Recuperi o Contributi";
            // 
            // txtDescrBilancioEntrata
            // 
            this.txtDescrBilancioEntrata.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrBilancioEntrata.Location = new System.Drawing.Point(144, 16);
            this.txtDescrBilancioEntrata.Multiline = true;
            this.txtDescrBilancioEntrata.Name = "txtDescrBilancioEntrata";
            this.txtDescrBilancioEntrata.ReadOnly = true;
            this.txtDescrBilancioEntrata.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescrBilancioEntrata.Size = new System.Drawing.Size(193, 48);
            this.txtDescrBilancioEntrata.TabIndex = 0;
            this.txtDescrBilancioEntrata.TabStop = false;
            this.txtDescrBilancioEntrata.Tag = "finincomeclawback.title";
            // 
            // txtBilancioEntrataInt
            // 
            this.txtBilancioEntrataInt.Location = new System.Drawing.Point(8, 40);
            this.txtBilancioEntrataInt.Name = "txtBilancioEntrataInt";
            this.txtBilancioEntrataInt.Size = new System.Drawing.Size(128, 20);
            this.txtBilancioEntrataInt.TabIndex = 1;
            this.txtBilancioEntrataInt.Tag = "finincomeclawback.codefin?csa_incomesetupview.codefin_clawback";
            // 
            // btnBilancioEntrata
            // 
            this.btnBilancioEntrata.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBilancioEntrata.ImageIndex = 0;
            this.btnBilancioEntrata.ImageList = this.imageList1;
            this.btnBilancioEntrata.Location = new System.Drawing.Point(8, 16);
            this.btnBilancioEntrata.Name = "btnBilancioEntrata";
            this.btnBilancioEntrata.Size = new System.Drawing.Size(72, 24);
            this.btnBilancioEntrata.TabIndex = 1;
            this.btnBilancioEntrata.TabStop = false;
            this.btnBilancioEntrata.Tag = "manage.finincomeclawback.treee";
            this.btnBilancioEntrata.Text = "Bilancio";
            this.btnBilancioEntrata.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.gboxUPB);
            this.groupBox5.Controls.Add(this.grpModalitaRecuperi);
            this.groupBox5.Location = new System.Drawing.Point(12, 693);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(947, 103);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "UPB per  i Recuperi";
            // 
            // grpModalitaRecuperi
            // 
            this.grpModalitaRecuperi.Controls.Add(this.radioButton2);
            this.grpModalitaRecuperi.Controls.Add(this.radioButton1);
            this.grpModalitaRecuperi.Location = new System.Drawing.Point(625, 29);
            this.grpModalitaRecuperi.Name = "grpModalitaRecuperi";
            this.grpModalitaRecuperi.Size = new System.Drawing.Size(316, 54);
            this.grpModalitaRecuperi.TabIndex = 6;
            this.grpModalitaRecuperi.TabStop = false;
            this.grpModalitaRecuperi.Text = "Modalità di applicazione (Per Recuperi)";
            // 
            // radioButton2
            // 
            this.radioButton2.Location = new System.Drawing.Point(107, 26);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(185, 20);
            this.radioButton2.TabIndex = 13;
            this.radioButton2.Tag = "csa_incomesetup.flagdirectcsaclawback:N";
            this.radioButton2.Text = "Su Partite di giro";
            // 
            // radioButton1
            // 
            this.radioButton1.Location = new System.Drawing.Point(8, 26);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(80, 20);
            this.radioButton1.TabIndex = 12;
            this.radioButton1.Tag = "csa_incomesetup.flagdirectcsaclawback:S";
            this.radioButton1.Text = "Diretto";
            // 
            // grpSiopeVersamentoRit
            // 
            this.grpSiopeVersamentoRit.Controls.Add(this.btnSiopeRit);
            this.grpSiopeVersamentoRit.Controls.Add(this.txtDescrSiopeVersamentoRit);
            this.grpSiopeVersamentoRit.Controls.Add(this.txtSiopeSpesa);
            this.grpSiopeVersamentoRit.Location = new System.Drawing.Point(9, 101);
            this.grpSiopeVersamentoRit.Name = "grpSiopeVersamentoRit";
            this.grpSiopeVersamentoRit.Size = new System.Drawing.Size(357, 72);
            this.grpSiopeVersamentoRit.TabIndex = 15;
            this.grpSiopeVersamentoRit.TabStop = false;
            this.grpSiopeVersamentoRit.Tag = "AutoManage.txtSiopeSpesa.treeclassmovimenti";
            this.grpSiopeVersamentoRit.Text = "Siope Spese (Ritenuta partita di giro) ";
            // 
            // btnSiopeRit
            // 
            this.btnSiopeRit.Location = new System.Drawing.Point(8, 16);
            this.btnSiopeRit.Name = "btnSiopeRit";
            this.btnSiopeRit.Size = new System.Drawing.Size(88, 23);
            this.btnSiopeRit.TabIndex = 4;
            this.btnSiopeRit.TabStop = false;
            this.btnSiopeRit.Tag = "manage.sortingexpense.tree";
            this.btnSiopeRit.Text = "Codice";
            this.btnSiopeRit.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDescrSiopeVersamentoRit
            // 
            this.txtDescrSiopeVersamentoRit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrSiopeVersamentoRit.Location = new System.Drawing.Point(102, 14);
            this.txtDescrSiopeVersamentoRit.Multiline = true;
            this.txtDescrSiopeVersamentoRit.Name = "txtDescrSiopeVersamentoRit";
            this.txtDescrSiopeVersamentoRit.ReadOnly = true;
            this.txtDescrSiopeVersamentoRit.Size = new System.Drawing.Size(247, 52);
            this.txtDescrSiopeVersamentoRit.TabIndex = 3;
            this.txtDescrSiopeVersamentoRit.TabStop = false;
            this.txtDescrSiopeVersamentoRit.Tag = "sortingexpense.description";
            // 
            // txtSiopeSpesa
            // 
            this.txtSiopeSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSiopeSpesa.Location = new System.Drawing.Point(8, 40);
            this.txtSiopeSpesa.Name = "txtSiopeSpesa";
            this.txtSiopeSpesa.Size = new System.Drawing.Size(88, 20);
            this.txtSiopeSpesa.TabIndex = 4;
            this.txtSiopeSpesa.Tag = "sortingexpense.sortcode?csa_incomesetupview.sortcode_expense";
            // 
            // grpBilancioVersamentoRit
            // 
            this.grpBilancioVersamentoRit.Controls.Add(this.txtDescrBilancioVersamentoRit);
            this.grpBilancioVersamentoRit.Controls.Add(this.txtBilancioSpesa);
            this.grpBilancioVersamentoRit.Controls.Add(this.btnBilancioRit);
            this.grpBilancioVersamentoRit.Location = new System.Drawing.Point(9, 19);
            this.grpBilancioVersamentoRit.Name = "grpBilancioVersamentoRit";
            this.grpBilancioVersamentoRit.Size = new System.Drawing.Size(357, 72);
            this.grpBilancioVersamentoRit.TabIndex = 0;
            this.grpBilancioVersamentoRit.TabStop = false;
            this.grpBilancioVersamentoRit.Tag = "AutoManage.txtBilancioSpesa.trees";
            this.grpBilancioVersamentoRit.Text = "Capitolo di spesa(Ritenuta partita di giro)";
            // 
            // txtDescrBilancioVersamentoRit
            // 
            this.txtDescrBilancioVersamentoRit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrBilancioVersamentoRit.Location = new System.Drawing.Point(144, 16);
            this.txtDescrBilancioVersamentoRit.Multiline = true;
            this.txtDescrBilancioVersamentoRit.Name = "txtDescrBilancioVersamentoRit";
            this.txtDescrBilancioVersamentoRit.ReadOnly = true;
            this.txtDescrBilancioVersamentoRit.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescrBilancioVersamentoRit.Size = new System.Drawing.Size(205, 48);
            this.txtDescrBilancioVersamentoRit.TabIndex = 0;
            this.txtDescrBilancioVersamentoRit.TabStop = false;
            this.txtDescrBilancioVersamentoRit.Tag = "finexpense.title";
            // 
            // txtBilancioSpesa
            // 
            this.txtBilancioSpesa.Location = new System.Drawing.Point(8, 40);
            this.txtBilancioSpesa.Name = "txtBilancioSpesa";
            this.txtBilancioSpesa.Size = new System.Drawing.Size(128, 20);
            this.txtBilancioSpesa.TabIndex = 1;
            this.txtBilancioSpesa.Tag = "finexpense.codefin?csa_incomesetupview.codefin_expense";
            // 
            // btnBilancioRit
            // 
            this.btnBilancioRit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBilancioRit.ImageIndex = 0;
            this.btnBilancioRit.ImageList = this.imageList1;
            this.btnBilancioRit.Location = new System.Drawing.Point(8, 16);
            this.btnBilancioRit.Name = "btnBilancioRit";
            this.btnBilancioRit.Size = new System.Drawing.Size(72, 24);
            this.btnBilancioRit.TabIndex = 1;
            this.btnBilancioRit.TabStop = false;
            this.btnBilancioRit.Tag = "manage.finexpense.trees";
            this.btnBilancioRit.Text = "Bilancio";
            this.btnBilancioRit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.gboxConto);
            this.groupBox6.Controls.Add(this.groupBox2);
            this.groupBox6.Location = new System.Drawing.Point(12, 802);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(708, 94);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Vecchia Configurazione";
            // 
            // gboxConto
            // 
            this.gboxConto.Controls.Add(this.txtDenominazioneConto);
            this.gboxConto.Controls.Add(this.txtCodiceContoDebito);
            this.gboxConto.Controls.Add(this.button2);
            this.gboxConto.Location = new System.Drawing.Point(373, 16);
            this.gboxConto.Name = "gboxConto";
            this.gboxConto.Size = new System.Drawing.Size(329, 72);
            this.gboxConto.TabIndex = 2;
            this.gboxConto.TabStop = false;
            this.gboxConto.Tag = "AutoManage.txtCodiceContoDebito.tree";
            this.gboxConto.Text = "Conto EP di  Debito C/ Ente (per contr. su p. di giro)";
            // 
            // txtDenominazioneConto
            // 
            this.txtDenominazioneConto.Location = new System.Drawing.Point(136, 16);
            this.txtDenominazioneConto.Multiline = true;
            this.txtDenominazioneConto.Name = "txtDenominazioneConto";
            this.txtDenominazioneConto.ReadOnly = true;
            this.txtDenominazioneConto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDenominazioneConto.Size = new System.Drawing.Size(181, 52);
            this.txtDenominazioneConto.TabIndex = 0;
            this.txtDenominazioneConto.TabStop = false;
            this.txtDenominazioneConto.Tag = "accountdebit.title";
            // 
            // txtCodiceContoDebito
            // 
            this.txtCodiceContoDebito.Location = new System.Drawing.Point(8, 43);
            this.txtCodiceContoDebito.Name = "txtCodiceContoDebito";
            this.txtCodiceContoDebito.Size = new System.Drawing.Size(120, 20);
            this.txtCodiceContoDebito.TabIndex = 2;
            this.txtCodiceContoDebito.Tag = "accountdebit.codeacc?csa_incomesetup.codeacc_income";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(8, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 23);
            this.button2.TabIndex = 1;
            this.button2.TabStop = false;
            this.button2.Tag = "manage.accountdebit.tree";
            this.button2.Text = "Conto";
            // 
            // grpSiopeEntrataRit
            // 
            this.grpSiopeEntrataRit.Controls.Add(this.btnSiopeEntrataRit);
            this.grpSiopeEntrataRit.Controls.Add(this.txtDescrSiopeEntrataRit);
            this.grpSiopeEntrataRit.Controls.Add(this.txtSiopeEntrataRit);
            this.grpSiopeEntrataRit.Location = new System.Drawing.Point(11, 19);
            this.grpSiopeEntrataRit.Name = "grpSiopeEntrataRit";
            this.grpSiopeEntrataRit.Size = new System.Drawing.Size(355, 72);
            this.grpSiopeEntrataRit.TabIndex = 15;
            this.grpSiopeEntrataRit.TabStop = false;
            this.grpSiopeEntrataRit.Tag = "AutoManage.txtCodiceSiopeRit.treeclassmovimenti";
            this.grpSiopeEntrataRit.Text = "Siope Entrate (Ritenuta partita di giro)";
            // 
            // btnSiopeEntrataRit
            // 
            this.btnSiopeEntrataRit.Location = new System.Drawing.Point(8, 16);
            this.btnSiopeEntrataRit.Name = "btnSiopeEntrataRit";
            this.btnSiopeEntrataRit.Size = new System.Drawing.Size(88, 23);
            this.btnSiopeEntrataRit.TabIndex = 4;
            this.btnSiopeEntrataRit.TabStop = false;
            this.btnSiopeEntrataRit.Tag = "manage.sortingincome.tree";
            this.btnSiopeEntrataRit.Text = "Codice";
            this.btnSiopeEntrataRit.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDescrSiopeEntrataRit
            // 
            this.txtDescrSiopeEntrataRit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrSiopeEntrataRit.Location = new System.Drawing.Point(102, 16);
            this.txtDescrSiopeEntrataRit.Multiline = true;
            this.txtDescrSiopeEntrataRit.Name = "txtDescrSiopeEntrataRit";
            this.txtDescrSiopeEntrataRit.ReadOnly = true;
            this.txtDescrSiopeEntrataRit.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescrSiopeEntrataRit.Size = new System.Drawing.Size(245, 50);
            this.txtDescrSiopeEntrataRit.TabIndex = 3;
            this.txtDescrSiopeEntrataRit.TabStop = false;
            this.txtDescrSiopeEntrataRit.Tag = "sortingincome.description";
            // 
            // txtSiopeEntrataRit
            // 
            this.txtSiopeEntrataRit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSiopeEntrataRit.Location = new System.Drawing.Point(8, 40);
            this.txtSiopeEntrataRit.Name = "txtSiopeEntrataRit";
            this.txtSiopeEntrataRit.Size = new System.Drawing.Size(88, 20);
            this.txtSiopeEntrataRit.TabIndex = 3;
            this.txtSiopeEntrataRit.Tag = "sortingincome.sortcode?csa_incomesetupview.sortcode_income";
            // 
            // grpBilancioEntrataRit
            // 
            this.grpBilancioEntrataRit.Controls.Add(this.txtDescrBilancioEntrataRit);
            this.grpBilancioEntrataRit.Controls.Add(this.txtBilancioEntrata);
            this.grpBilancioEntrataRit.Controls.Add(this.btnBilancioEntrataRit);
            this.grpBilancioEntrataRit.Location = new System.Drawing.Point(15, 19);
            this.grpBilancioEntrataRit.Name = "grpBilancioEntrataRit";
            this.grpBilancioEntrataRit.Size = new System.Drawing.Size(351, 72);
            this.grpBilancioEntrataRit.TabIndex = 0;
            this.grpBilancioEntrataRit.TabStop = false;
            this.grpBilancioEntrataRit.Tag = "AutoManage.txtBilancioEntrata.treee";
            this.grpBilancioEntrataRit.Text = "Capitolo di entrata(Ritenuta partita di giro)";
            // 
            // txtDescrBilancioEntrataRit
            // 
            this.txtDescrBilancioEntrataRit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrBilancioEntrataRit.Location = new System.Drawing.Point(144, 16);
            this.txtDescrBilancioEntrataRit.Multiline = true;
            this.txtDescrBilancioEntrataRit.Name = "txtDescrBilancioEntrataRit";
            this.txtDescrBilancioEntrataRit.ReadOnly = true;
            this.txtDescrBilancioEntrataRit.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescrBilancioEntrataRit.Size = new System.Drawing.Size(199, 48);
            this.txtDescrBilancioEntrataRit.TabIndex = 0;
            this.txtDescrBilancioEntrataRit.TabStop = false;
            this.txtDescrBilancioEntrataRit.Tag = "finincome.title";
            // 
            // txtBilancioEntrata
            // 
            this.txtBilancioEntrata.Location = new System.Drawing.Point(8, 40);
            this.txtBilancioEntrata.Name = "txtBilancioEntrata";
            this.txtBilancioEntrata.Size = new System.Drawing.Size(128, 20);
            this.txtBilancioEntrata.TabIndex = 1;
            this.txtBilancioEntrata.Tag = "finincome.codefin?csa_incomesetupview.codefin_income";
            // 
            // btnBilancioEntrataRit
            // 
            this.btnBilancioEntrataRit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBilancioEntrataRit.ImageIndex = 0;
            this.btnBilancioEntrataRit.ImageList = this.imageList1;
            this.btnBilancioEntrataRit.Location = new System.Drawing.Point(8, 16);
            this.btnBilancioEntrataRit.Name = "btnBilancioEntrataRit";
            this.btnBilancioEntrataRit.Size = new System.Drawing.Size(72, 24);
            this.btnBilancioEntrataRit.TabIndex = 1;
            this.btnBilancioEntrataRit.TabStop = false;
            this.btnBilancioEntrataRit.Tag = "manage.finincome.treee";
            this.btnBilancioEntrataRit.Text = "Bilancio";
            this.btnBilancioEntrataRit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 16);
            this.label3.TabIndex = 27;
            this.label3.Text = "Voce CSA per Raggruppamento:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbVoceCsaUnified
            // 
            this.cmbVoceCsaUnified.DataSource = this.DS.csa_incomesetup1;
            this.cmbVoceCsaUnified.DisplayMember = "vocecsa";
            this.cmbVoceCsaUnified.Location = new System.Drawing.Point(12, 85);
            this.cmbVoceCsaUnified.Name = "cmbVoceCsaUnified";
            this.cmbVoceCsaUnified.Size = new System.Drawing.Size(443, 21);
            this.cmbVoceCsaUnified.TabIndex = 26;
            this.cmbVoceCsaUnified.Tag = "csa_incomesetup.vocecsaunified";
            this.cmbVoceCsaUnified.ValueMember = "vocecsa";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label15);
            this.groupBox8.Controls.Add(this.label9);
            this.groupBox8.Controls.Add(this.label5);
            this.groupBox8.Controls.Add(this.grpBilancioEntrataRit);
            this.groupBox8.Controls.Add(this.grpBilancioEntrata);
            this.groupBox8.Location = new System.Drawing.Point(12, 106);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(947, 96);
            this.groupBox8.TabIndex = 28;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Capitoli finanziari Entrata";
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Yellow;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(810, 65);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(78, 18);
            this.label15.TabIndex = 4;
            this.label15.Text = "Contributo";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.SpringGreen;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(810, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 20);
            this.label9.TabIndex = 3;
            this.label9.Text = "Recupero";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Aqua;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(372, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 23);
            this.label5.TabIndex = 2;
            this.label5.Text = "Ritenuta";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.label10);
            this.groupBox9.Controls.Add(this.label6);
            this.groupBox9.Controls.Add(this.grpBilancioVersamentoRit);
            this.groupBox9.Controls.Add(this.grpBilancioSpesaCosto);
            this.groupBox9.Location = new System.Drawing.Point(13, 208);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(946, 100);
            this.groupBox9.TabIndex = 29;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Capitoli finanziari Spesa";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.SpringGreen;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(811, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 20);
            this.label10.TabIndex = 7;
            this.label10.Text = "Recupero";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Aqua;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(374, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "Ritenuta";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.label16);
            this.groupBox10.Controls.Add(this.label12);
            this.groupBox10.Controls.Add(this.label11);
            this.groupBox10.Controls.Add(this.label8);
            this.groupBox10.Controls.Add(this.label7);
            this.groupBox10.Controls.Add(this.grpSiopeVersamentoRit);
            this.groupBox10.Controls.Add(this.grpSiopeSpesaCosto);
            this.groupBox10.Controls.Add(this.grpSiopeEntrataRit);
            this.groupBox10.Controls.Add(this.grpSiopeEntrata);
            this.groupBox10.Location = new System.Drawing.Point(12, 325);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(947, 179);
            this.groupBox10.TabIndex = 30;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Codici Siope";
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Yellow;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(806, 59);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(75, 20);
            this.label16.TabIndex = 20;
            this.label16.Text = "Contributo";
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.SpringGreen;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(806, 127);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 20);
            this.label12.TabIndex = 19;
            this.label12.Text = "Recupero";
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.SpringGreen;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(806, 39);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 20);
            this.label11.TabIndex = 18;
            this.label11.Text = "Recupero";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Aqua;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(372, 115);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 20);
            this.label8.TabIndex = 17;
            this.label8.Text = "Ritenuta";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Aqua;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(372, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "Ritenuta";
            // 
            // lblEsitoConfigurazione
            // 
            this.lblEsitoConfigurazione.AutoSize = true;
            this.lblEsitoConfigurazione.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEsitoConfigurazione.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblEsitoConfigurazione.Location = new System.Drawing.Point(282, 9);
            this.lblEsitoConfigurazione.Name = "lblEsitoConfigurazione";
            this.lblEsitoConfigurazione.Size = new System.Drawing.Size(152, 15);
            this.lblEsitoConfigurazione.TabIndex = 31;
            this.lblEsitoConfigurazione.Text = "lblEsitoConfigurazione";
            // 
            // Frm_csa_incomesetup_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(971, 904);
            this.Controls.Add(this.lblEsitoConfigurazione);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbVoceCsaUnified);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.tipo);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Frm_csa_incomesetup_default";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmautomatismincassicsa";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.grpContoCosto.ResumeLayout(false);
            this.grpContoCosto.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.gBoxContoRicavo.ResumeLayout(false);
            this.gBoxContoRicavo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gboxUPB.ResumeLayout(false);
            this.gboxUPB.PerformLayout();
            this.grpSiopeSpesaCosto.ResumeLayout(false);
            this.grpSiopeSpesaCosto.PerformLayout();
            this.grpBilancioSpesaCosto.ResumeLayout(false);
            this.grpBilancioSpesaCosto.PerformLayout();
            this.grpSiopeEntrata.ResumeLayout(false);
            this.grpSiopeEntrata.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpBilancioEntrata.ResumeLayout(false);
            this.grpBilancioEntrata.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.grpModalitaRecuperi.ResumeLayout(false);
            this.grpSiopeVersamentoRit.ResumeLayout(false);
            this.grpSiopeVersamentoRit.PerformLayout();
            this.grpBilancioVersamentoRit.ResumeLayout(false);
            this.grpBilancioVersamentoRit.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.gboxConto.ResumeLayout(false);
            this.gboxConto.PerformLayout();
            this.grpSiopeEntrataRit.ResumeLayout(false);
            this.grpSiopeEntrataRit.PerformLayout();
            this.grpBilancioEntrataRit.ResumeLayout(false);
            this.grpBilancioEntrataRit.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        CQueryHelper QHC;
        QueryHelper QHS;
        int esercizio;
 
        string [] allfields= new string[] {
            "idfin_income","idfin_expense","idsor_siope_income","idsor_siope_expense","idacc_expense","idacc_agency_credit",
            "idfin_incomeclawback","idsor_siope_incomeclawback","idacc_revenue","idfin_cost","idsor_siope_cost","idacc_cost","idupb"
        };
	    string [] ritenuteFields= new string[] 
	        {"idfin_income","idfin_expense","idsor_siope_income","idsor_siope_expense","idacc_expense","idacc_agency_credit"};
            //finincome && finexpense && sortingincome && sortingexpense && accountente && accountcreditente;

	    string []  recuperiFields= new string[] {
            "idfin_incomeclawback","idsor_siope_incomeclawback","idacc_revenue","idfin_cost","idsor_siope_cost",
                    "idacc_cost","idupb"
	    };// finincomeclawback && sortingincomeclawback && account_revenue && finexpensecost  && sortingexpensecost  && account_cost && upb;


	    string [] contributiFields = new string[] {
            "idfin_incomeclawback","idsor_siope_incomeclawback","idacc_revenue","idacc_expense","idacc_agency_credit"
	    };//finincomeclawback && sortingincomeclawback && account_revenue && accountente && accountcreditente;

	    bool checkConfigurazione(DataRow r, string[] cfg) {
	        List<string> elencoVietati = new List<string>();
	        foreach(string field in allfields) elencoVietati.Add(field);

	        foreach (string field in cfg) {
	            if (r[field] == DBNull.Value) return false;
	            elencoVietati.Remove(field);
	        }
	        
	        foreach (string field in elencoVietati) {
	            if (r[field] != DBNull.Value) return false;
	        }

	        return true;
	    }

        public void MetaData_AfterLink(){
			Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            esercizio = (int)Meta.GetSys("esercizio");
        
			string filter =QHS.CmpEq("ayear",esercizio);
            GetData.SetStaticFilter(DS.csa_incomesetup, QHS.CmpEq("ayear", esercizio));				
            GetData.SetStaticFilter(DS.csa_incomesetupview, QHS.CmpEq("ayear",esercizio));				
			GetData.SetStaticFilter(DS.finincome,QHS.AppAnd(filter,QHS.BitClear("flag", 0)));
			GetData.SetStaticFilter(DS.finexpense,QHS.AppAnd(filter,QHS.BitSet("flag", 0)));
            GetData.SetStaticFilter(DS.finexpensecost, QHS.AppAnd(filter, QHS.BitSet("flag", 0)));
            GetData.SetStaticFilter(DS.finincomeclawback, QHS.AppAnd(filter, QHS.BitClear("flag", 0)));
            GetData.SetStaticFilter(DS.accountdebit,filter);
            GetData.SetStaticFilter(DS.accountente, filter);
            GetData.SetStaticFilter(DS.accountclawback,filter);
            GetData.SetStaticFilter(DS.account_revenue, filter);
            GetData.SetStaticFilter(DS.account_cost, filter);
            GetData.SetStaticFilter(DS.accountcreditente, filter);
            GetData.SetStaticFilter(DS.csa_incomesetup1, filter);
            DataAccess.SetTableForReading(DS.csa_incomesetup1, "csa_incomesetup");
            DataAccess.SetTableForReading(DS.sortingexpense, "sorting");
            DataAccess.SetTableForReading(DS.sortingincome, "sorting");
            DataAccess.SetTableForReading(DS.sortingincomeclawback, "sorting");
            DataAccess.SetTableForReading(DS.sortingexpensecost, "sorting");
            GetData.CacheTable(DS.csa_incomesetup1,null, null, true);
            GetData.SetSorting(DS.csa_incomesetup1, "vocecsa asc");

            string filterSiopeS = QHS.CmpEq("codesorkind", Meta.GetSys("codesorkind_siopespese")); 
         
            DataTable tSortingkindS = Meta.Conn.RUN_SELECT("sortingkind", "*", null, filterSiopeS, null, null, true);
            if ((tSortingkindS != null) && (tSortingkindS.Rows.Count > 0)){
                DataRow RS = tSortingkindS.Rows[0];
                object idsorkindS = RS["idsorkind"];
                SetGBoxClass(null,idsorkindS);
            }
            string filterSiopeE = QHS.CmpEq("codesorkind", Meta.GetSys("codesorkind_siopeentrate"));
        
            DataTable tSortingkindE = Meta.Conn.RUN_SELECT("sortingkind", "*", null, filterSiopeE, null, null, true);
            if ((tSortingkindE != null) && (tSortingkindE.Rows.Count > 0)){
                DataRow RE = tSortingkindE.Rows[0];
                object idsorkindE = RE["idsorkind"];
                SetGBoxClass(idsorkindE,null);
            }

    	}
        public void MetaData_AfterClear() {
            restoreLabelColor();
            lblEsitoConfigurazione.Visible = false;
        }
        public void MetaData_AfterFill() {
            if (Meta.IsEmpty) return;
            lblEsitoConfigurazione.Visible = true ;
            ValorizzaLabel();
        }

	    public void ValorizzaLabel() {
	        if (Meta.IsEmpty) {
	            lblEsitoConfigurazione.Visible = false;
	            return;
	        }

	        Meta.GetFormData(true);
	        DataRow r = DS.csa_incomesetup.Rows[0];
	        if (checkConfigurazione(r, ritenuteFields)) {
	            lblEsitoConfigurazione.Text = "Configurazione RITENUTE";
	            return;
	        }

	        if (checkConfigurazione(r, recuperiFields)) {
	            lblEsitoConfigurazione.Text = "Configurazione RECUPERI";
	            return;
	        }

	        if (checkConfigurazione(r, contributiFields)) {
	            lblEsitoConfigurazione.Text = "Configurazione CONTRIBUTI";
	            return;
	        }

	        lblEsitoConfigurazione.Text = "Configurazione incompleta o errata";
	    }

	    public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (Meta.IsEmpty) return;
            DataRow Curr = DS.csa_incomesetup.Rows[0];
            if (Meta.DrawStateIsDone)  ValorizzaLabel();
            

        }

        void SetGBoxClass(object sortingkindE, object sortingkindS){
            if ((sortingkindE!= null)&&(sortingkindE!= DBNull.Value)){
                string filterE = QHS.CmpEq("idsorkind", sortingkindE);
                GetData.SetStaticFilter(DS.sortingincome, filterE);
                GetData.SetStaticFilter(DS.sortingincomeclawback, filterE);
           
                string title = Meta.Conn.DO_READ_VALUE("sortingkind", filterE, "description").ToString();
                grpSiopeEntrataRit.Text = title;
                grpSiopeEntrataRit.Tag = "AutoManage.txtSiopeEntrataRit.tree." + filterE;
                btnSiopeEntrataRit.Tag = "manage.sortingincome.tree." + filterE;

                grpSiopeEntrata.Text=title;
                grpSiopeEntrata.Tag = "AutoManage.txtSiopeEntrataInt.tree." + filterE;
                btnSiopeEntrata.Tag = "manage.sortingincomeclawback.tree." + filterE;
            }
            if ((sortingkindS!= null)&& (sortingkindE!=DBNull.Value)){
                string filterS = QHS.CmpEq("idsorkind", sortingkindS);
                GetData.SetStaticFilter(DS.sortingexpense, filterS);
                GetData.SetStaticFilter(DS.sortingexpensecost, filterS);
                string title = Meta.Conn.DO_READ_VALUE("sortingkind", filterS, "description").ToString();

                grpSiopeVersamentoRit.Text = title;
                grpSiopeVersamentoRit.Tag = "AutoManage.txtSiopeSpesa.tree." + filterS;

                btnSiopeRit.Tag = "manage.sortingexpense.tree." + filterS;

                grpSiopeSpesaCosto.Text = title + " Costo (Recuperi negativi)" ;
                grpSiopeSpesaCosto.Tag = "AutoManage.txtSiopeSpesaCosto.tree." + filterS;

                btnSiopeSpesaCost.Tag = "manage.sortingexpensecost.tree." + filterS;
            }

        }

        private void Frm_csa_incomesetup_default_Load(object sender, EventArgs e)
        {

        }
	}
}
