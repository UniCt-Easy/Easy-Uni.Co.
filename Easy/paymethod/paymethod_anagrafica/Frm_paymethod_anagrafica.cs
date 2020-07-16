/*
    Easy
    Copyright (C) 2020 UniversitÃ  degli Studi di Catania (www.unict.it)
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

namespace paymethod_anagrafica//modalitapagamentoanagrafica//
{
	/// <summary>
	/// Summary description for frmModalitaPagamentoAnagrafica.
	/// </summary>
	public class Frm_paymethod_anagrafica : System.Windows.Forms.Form
	{
		public System.Windows.Forms.Panel MetaDataDetail;
		private System.Windows.Forms.CheckBox chkStampaAvviso;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtDescrizione;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtCodice;
		private System.Windows.Forms.DataGrid dataGrid1;
		public vistaForm DS;
		public System.Windows.Forms.ToolBar MetaDataToolBar;
		private System.Windows.Forms.ToolBarButton seleziona;
		private System.Windows.Forms.ToolBarButton impostaricerca;
		private System.Windows.Forms.ToolBarButton effettuaricerca;
		private System.Windows.Forms.ToolBarButton modifica;
		private System.Windows.Forms.ToolBarButton inserisci;
		private System.Windows.Forms.ToolBarButton inseriscicopia;
		private System.Windows.Forms.ToolBarButton elimina;
		private System.Windows.Forms.ToolBarButton Salva;
		private System.Windows.Forms.ToolBarButton aggiorna;
		private System.Windows.Forms.ImageList images;
		private System.Windows.Forms.CheckBox chkAttivo;
		private System.Windows.Forms.TextBox txtCodModBanca;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.CheckBox chkDelegato;
		private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private CheckBox chkDivietoCoordBanc;
        private CheckBox chkObbligoCoordBanc;
        private CheckBox chkContoCorrPostale;
        private GroupBox groupBox4;
        private GroupBox gboxEsecuzione;
        private GroupBox groupBox6;
        private Label label6;
        private Label label5;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private Label label7;
        private Label label8;
        private TextBox textBox5;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox4;
        private CheckBox checkBox3;
        private CheckBox checkBox5;
        private CheckBox checkBox7;
        private CheckBox checkBox6;
        private GroupBox groupBox5;
        private CheckBox chkEstero;
        private CheckBox chKSEPA;
		private Label label9;
		private ComboBox cmbabilabel;
		private System.ComponentModel.IContainer components;

		public Frm_paymethod_anagrafica()
		{
			InitializeComponent();
			HelpForm.SetDenyNull(DS.paymethod.Columns["active"],true);
			HelpForm.SetDenyNull(DS.paymethod.Columns["allowdeputy"],true);
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_paymethod_anagrafica));
			this.MetaDataDetail = new System.Windows.Forms.Panel();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtCodice = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtDescrizione = new System.Windows.Forms.TextBox();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.label8 = new System.Windows.Forms.Label();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtCodModBanca = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.chkEstero = new System.Windows.Forms.CheckBox();
			this.chKSEPA = new System.Windows.Forms.CheckBox();
			this.checkBox7 = new System.Windows.Forms.CheckBox();
			this.gboxEsecuzione = new System.Windows.Forms.GroupBox();
			this.checkBox6 = new System.Windows.Forms.CheckBox();
			this.checkBox5 = new System.Windows.Forms.CheckBox();
			this.checkBox4 = new System.Windows.Forms.CheckBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.chkObbligoCoordBanc = new System.Windows.Forms.CheckBox();
			this.chkDivietoCoordBanc = new System.Windows.Forms.CheckBox();
			this.chkContoCorrPostale = new System.Windows.Forms.CheckBox();
			this.chkDelegato = new System.Windows.Forms.CheckBox();
			this.chkAttivo = new System.Windows.Forms.CheckBox();
			this.chkStampaAvviso = new System.Windows.Forms.CheckBox();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.MetaDataToolBar = new System.Windows.Forms.ToolBar();
			this.seleziona = new System.Windows.Forms.ToolBarButton();
			this.impostaricerca = new System.Windows.Forms.ToolBarButton();
			this.effettuaricerca = new System.Windows.Forms.ToolBarButton();
			this.modifica = new System.Windows.Forms.ToolBarButton();
			this.inserisci = new System.Windows.Forms.ToolBarButton();
			this.inseriscicopia = new System.Windows.Forms.ToolBarButton();
			this.elimina = new System.Windows.Forms.ToolBarButton();
			this.Salva = new System.Windows.Forms.ToolBarButton();
			this.aggiorna = new System.Windows.Forms.ToolBarButton();
			this.images = new System.Windows.Forms.ImageList(this.components);
			this.DS = new paymethod_anagrafica.vistaForm();
			this.cmbabilabel = new System.Windows.Forms.ComboBox();
			this.MetaDataDetail.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.gboxEsecuzione.SuspendLayout();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// MetaDataDetail
			// 
			this.MetaDataDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.MetaDataDetail.Controls.Add(this.groupBox3);
			this.MetaDataDetail.Controls.Add(this.groupBox6);
			this.MetaDataDetail.Controls.Add(this.textBox1);
			this.MetaDataDetail.Controls.Add(this.label4);
			this.MetaDataDetail.Controls.Add(this.groupBox2);
			this.MetaDataDetail.Controls.Add(this.groupBox1);
			this.MetaDataDetail.Location = new System.Drawing.Point(8, 258);
			this.MetaDataDetail.Name = "MetaDataDetail";
			this.MetaDataDetail.Size = new System.Drawing.Size(925, 361);
			this.MetaDataDetail.TabIndex = 25;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Controls.Add(this.txtCodice);
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Controls.Add(this.txtDescrizione);
			this.groupBox3.Location = new System.Drawing.Point(8, 7);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(417, 88);
			this.groupBox3.TabIndex = 27;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Dettagli Generici";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(1, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(86, 13);
			this.label1.TabIndex = 23;
			this.label1.Text = "Codice Modalità:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtCodice
			// 
			this.txtCodice.Location = new System.Drawing.Point(93, 14);
			this.txtCodice.Name = "txtCodice";
			this.txtCodice.Size = new System.Drawing.Size(113, 20);
			this.txtCodice.TabIndex = 1;
			this.txtCodice.Tag = "paymethod.idpaymethod";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(16, 51);
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
			this.txtDescrizione.Location = new System.Drawing.Point(93, 40);
			this.txtDescrizione.Multiline = true;
			this.txtDescrizione.Name = "txtDescrizione";
			this.txtDescrizione.Size = new System.Drawing.Size(318, 42);
			this.txtDescrizione.TabIndex = 2;
			this.txtDescrizione.Tag = "paymethod.description";
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.label8);
			this.groupBox6.Controls.Add(this.textBox5);
			this.groupBox6.Controls.Add(this.label7);
			this.groupBox6.Controls.Add(this.label6);
			this.groupBox6.Controls.Add(this.label5);
			this.groupBox6.Controls.Add(this.textBox4);
			this.groupBox6.Controls.Add(this.textBox3);
			this.groupBox6.Controls.Add(this.textBox2);
			this.groupBox6.Location = new System.Drawing.Point(11, 285);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(414, 67);
			this.groupBox6.TabIndex = 34;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Commissioni Bancarie";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(68, 23);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(37, 13);
			this.label8.TabIndex = 10;
			this.label8.Text = "Carico";
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(111, 20);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(44, 20);
			this.textBox5.TabIndex = 3;
			this.textBox5.Tag = "paymethod.committeecode";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(7, 48);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(42, 13);
			this.label7.TabIndex = 8;
			this.label7.Text = "Importo";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(214, 44);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(85, 13);
			this.label6.TabIndex = 7;
			this.label6.Text = "Importo massimo";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(222, 23);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(77, 13);
			this.label5.TabIndex = 6;
			this.label5.Text = "Importo minimo";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(305, 18);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(95, 20);
			this.textBox4.TabIndex = 5;
			this.textBox4.Tag = "paymethod.minamount";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(55, 45);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(100, 20);
			this.textBox3.TabIndex = 4;
			this.textBox3.Tag = "paymethod.committeeamount";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(305, 43);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(95, 20);
			this.textBox2.TabIndex = 6;
			this.textBox2.Tag = "paymethod.maxamount";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(95, 207);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox1.Size = new System.Drawing.Size(330, 72);
			this.textBox1.TabIndex = 32;
			this.textBox1.Tag = "paymethod.footerpaymentadvice";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 207);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(81, 64);
			this.label4.TabIndex = 33;
			this.label4.Text = "Piè Pagina dell\'Avviso di Pagamento";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.cmbabilabel);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.txtCodModBanca);
			this.groupBox2.Location = new System.Drawing.Point(8, 96);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(417, 105);
			this.groupBox2.TabIndex = 30;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Importante per l\'esportazione elettronica dei Mandati";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(3, 47);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(128, 13);
			this.label9.TabIndex = 31;
			this.label9.Text = "Tipo pagamento SIOPE+:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(4, 22);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(138, 13);
			this.label3.TabIndex = 29;
			this.label3.Text = "Cod. Modalità per la Banca:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtCodModBanca
			// 
			this.txtCodModBanca.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCodModBanca.Location = new System.Drawing.Point(145, 19);
			this.txtCodModBanca.Name = "txtCodModBanca";
			this.txtCodModBanca.Size = new System.Drawing.Size(266, 20);
			this.txtCodModBanca.TabIndex = 3;
			this.txtCodModBanca.Tag = "paymethod.methodbankcode";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.groupBox5);
			this.groupBox1.Controls.Add(this.checkBox7);
			this.groupBox1.Controls.Add(this.gboxEsecuzione);
			this.groupBox1.Controls.Add(this.groupBox4);
			this.groupBox1.Controls.Add(this.chkContoCorrPostale);
			this.groupBox1.Controls.Add(this.chkDelegato);
			this.groupBox1.Controls.Add(this.chkAttivo);
			this.groupBox1.Controls.Add(this.chkStampaAvviso);
			this.groupBox1.Location = new System.Drawing.Point(431, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(486, 348);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Opzioni";
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.chkEstero);
			this.groupBox5.Controls.Add(this.chKSEPA);
			this.groupBox5.Location = new System.Drawing.Point(8, 95);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(195, 48);
			this.groupBox5.TabIndex = 17;
			this.groupBox5.TabStop = false;
			// 
			// chkEstero
			// 
			this.chkEstero.AutoSize = true;
			this.chkEstero.Location = new System.Drawing.Point(7, 28);
			this.chkEstero.Name = "chkEstero";
			this.chkEstero.Size = new System.Drawing.Size(97, 17);
			this.chkEstero.TabIndex = 18;
			this.chkEstero.Tag = "paymethod.flag:14";
			this.chkEstero.Text = "Bonifico Estero";
			this.chkEstero.UseVisualStyleBackColor = true;
			this.chkEstero.CheckStateChanged += new System.EventHandler(this.CheckBoxVincolatoChange);
			// 
			// chKSEPA
			// 
			this.chKSEPA.AutoSize = true;
			this.chKSEPA.Location = new System.Drawing.Point(7, 11);
			this.chKSEPA.Name = "chKSEPA";
			this.chKSEPA.Size = new System.Drawing.Size(95, 17);
			this.chKSEPA.TabIndex = 17;
			this.chKSEPA.Tag = "paymethod.flag:13";
			this.chKSEPA.Text = "Bonifico SEPA";
			this.chKSEPA.UseVisualStyleBackColor = true;
			this.chKSEPA.CheckStateChanged += new System.EventHandler(this.CheckBoxVincolatoChange);
			// 
			// checkBox7
			// 
			this.checkBox7.AutoSize = true;
			this.checkBox7.Location = new System.Drawing.Point(8, 213);
			this.checkBox7.Name = "checkBox7";
			this.checkBox7.Size = new System.Drawing.Size(247, 17);
			this.checkBox7.TabIndex = 14;
			this.checkBox7.Tag = "paymethod.flag:12";
			this.checkBox7.Text = "Fruttifera (Tipo Cont. Ente Ricevente Girofondi)";
			this.checkBox7.UseVisualStyleBackColor = true;
			// 
			// gboxEsecuzione
			// 
			this.gboxEsecuzione.Controls.Add(this.checkBox6);
			this.gboxEsecuzione.Controls.Add(this.checkBox5);
			this.gboxEsecuzione.Controls.Add(this.checkBox4);
			this.gboxEsecuzione.Controls.Add(this.checkBox3);
			this.gboxEsecuzione.Controls.Add(this.checkBox2);
			this.gboxEsecuzione.Controls.Add(this.checkBox1);
			this.gboxEsecuzione.Location = new System.Drawing.Point(209, 19);
			this.gboxEsecuzione.Name = "gboxEsecuzione";
			this.gboxEsecuzione.Size = new System.Drawing.Size(271, 138);
			this.gboxEsecuzione.TabIndex = 10;
			this.gboxEsecuzione.TabStop = false;
			this.gboxEsecuzione.Text = "Modalità esecuzione";
			// 
			// checkBox6
			// 
			this.checkBox6.AutoSize = true;
			this.checkBox6.Location = new System.Drawing.Point(6, 96);
			this.checkBox6.Name = "checkBox6";
			this.checkBox6.Size = new System.Drawing.Size(144, 17);
			this.checkBox6.TabIndex = 13;
			this.checkBox6.Tag = "paymethod.flag:11";
			this.checkBox6.Text = "Girofondi vincolati TAB B";
			this.checkBox6.UseVisualStyleBackColor = true;
			this.checkBox6.CheckStateChanged += new System.EventHandler(this.CheckBoxVincolatoChange);
			// 
			// checkBox5
			// 
			this.checkBox5.AutoSize = true;
			this.checkBox5.Location = new System.Drawing.Point(6, 74);
			this.checkBox5.Name = "checkBox5";
			this.checkBox5.Size = new System.Drawing.Size(139, 17);
			this.checkBox5.TabIndex = 12;
			this.checkBox5.Tag = "paymethod.flag:10";
			this.checkBox5.Text = "Girofondi ordinari TAB B";
			this.checkBox5.UseVisualStyleBackColor = true;
			this.checkBox5.CheckStateChanged += new System.EventHandler(this.CheckBoxVincolatoChange);
			// 
			// checkBox4
			// 
			this.checkBox4.AutoSize = true;
			this.checkBox4.Location = new System.Drawing.Point(6, 55);
			this.checkBox4.Name = "checkBox4";
			this.checkBox4.Size = new System.Drawing.Size(144, 17);
			this.checkBox4.TabIndex = 11;
			this.checkBox4.Tag = "paymethod.flag:9";
			this.checkBox4.Text = "Girofondi vincolati TAB A";
			this.checkBox4.UseVisualStyleBackColor = true;
			this.checkBox4.CheckStateChanged += new System.EventHandler(this.CheckBoxVincolatoChange);
			// 
			// checkBox3
			// 
			this.checkBox3.AutoSize = true;
			this.checkBox3.Location = new System.Drawing.Point(6, 37);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(139, 17);
			this.checkBox3.TabIndex = 10;
			this.checkBox3.Tag = "paymethod.flag:8";
			this.checkBox3.Text = "Girofondi ordinari TAB A";
			this.checkBox3.UseVisualStyleBackColor = true;
			this.checkBox3.CheckStateChanged += new System.EventHandler(this.CheckBoxVincolatoChange);
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Location = new System.Drawing.Point(6, 118);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(67, 17);
			this.checkBox2.TabIndex = 9;
			this.checkBox2.Tag = "paymethod.flag:7";
			this.checkBox2.Text = "Sportello";
			this.checkBox2.UseVisualStyleBackColor = true;
			this.checkBox2.CheckStateChanged += new System.EventHandler(this.CheckBoxVincolatoChange);
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(6, 19);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(68, 17);
			this.checkBox1.TabIndex = 8;
			this.checkBox1.Tag = "paymethod.flag:6";
			this.checkBox1.Text = "Girofondi";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckStateChanged += new System.EventHandler(this.CheckBoxVincolatoChange);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.chkObbligoCoordBanc);
			this.groupBox4.Controls.Add(this.chkDivietoCoordBanc);
			this.groupBox4.Location = new System.Drawing.Point(7, 149);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(195, 52);
			this.groupBox4.TabIndex = 9;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Coordinate bancarie";
			// 
			// chkObbligoCoordBanc
			// 
			this.chkObbligoCoordBanc.AutoSize = true;
			this.chkObbligoCoordBanc.Location = new System.Drawing.Point(6, 14);
			this.chkObbligoCoordBanc.Name = "chkObbligoCoordBanc";
			this.chkObbligoCoordBanc.Size = new System.Drawing.Size(82, 17);
			this.chkObbligoCoordBanc.TabIndex = 4;
			this.chkObbligoCoordBanc.Tag = "paymethod.flag:2";
			this.chkObbligoCoordBanc.Text = "Obbligatorie";
			this.chkObbligoCoordBanc.UseVisualStyleBackColor = true;
			this.chkObbligoCoordBanc.CheckStateChanged += new System.EventHandler(this.CheckBoxVincolatoChange);
			// 
			// chkDivietoCoordBanc
			// 
			this.chkDivietoCoordBanc.AutoSize = true;
			this.chkDivietoCoordBanc.Location = new System.Drawing.Point(6, 31);
			this.chkDivietoCoordBanc.Name = "chkDivietoCoordBanc";
			this.chkDivietoCoordBanc.Size = new System.Drawing.Size(115, 17);
			this.chkDivietoCoordBanc.TabIndex = 5;
			this.chkDivietoCoordBanc.Tag = "paymethod.flag:3";
			this.chkDivietoCoordBanc.Text = "Da non specificare";
			this.chkDivietoCoordBanc.UseVisualStyleBackColor = true;
			this.chkDivietoCoordBanc.CheckStateChanged += new System.EventHandler(this.CheckBoxVincolatoChange);
			// 
			// chkContoCorrPostale
			// 
			this.chkContoCorrPostale.AutoSize = true;
			this.chkContoCorrPostale.Location = new System.Drawing.Point(13, 73);
			this.chkContoCorrPostale.Name = "chkContoCorrPostale";
			this.chkContoCorrPostale.Size = new System.Drawing.Size(133, 17);
			this.chkContoCorrPostale.TabIndex = 8;
			this.chkContoCorrPostale.Tag = "paymethod.flag:1";
			this.chkContoCorrPostale.Text = "Conto corrente postale";
			this.chkContoCorrPostale.UseVisualStyleBackColor = true;
			// 
			// chkDelegato
			// 
			this.chkDelegato.AutoSize = true;
			this.chkDelegato.Location = new System.Drawing.Point(13, 37);
			this.chkDelegato.Name = "chkDelegato";
			this.chkDelegato.Size = new System.Drawing.Size(109, 17);
			this.chkDelegato.TabIndex = 3;
			this.chkDelegato.Tag = "paymethod.allowdeputy:S:N";
			this.chkDelegato.Text = "Ammetti Delegato";
			// 
			// chkAttivo
			// 
			this.chkAttivo.AutoSize = true;
			this.chkAttivo.Location = new System.Drawing.Point(13, 19);
			this.chkAttivo.Name = "chkAttivo";
			this.chkAttivo.Size = new System.Drawing.Size(53, 17);
			this.chkAttivo.TabIndex = 1;
			this.chkAttivo.Tag = "paymethod.active:S:N";
			this.chkAttivo.Text = "Attivo";
			// 
			// chkStampaAvviso
			// 
			this.chkStampaAvviso.AutoSize = true;
			this.chkStampaAvviso.Location = new System.Drawing.Point(13, 55);
			this.chkStampaAvviso.Name = "chkStampaAvviso";
			this.chkStampaAvviso.Size = new System.Drawing.Size(163, 17);
			this.chkStampaAvviso.TabIndex = 2;
			this.chkStampaAvviso.Tag = "paymethod.flag:0";
			this.chkStampaAvviso.Text = "Stampa avviso di pagamento";
			// 
			// dataGrid1
			// 
			this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(8, 52);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.ReadOnly = true;
			this.dataGrid1.Size = new System.Drawing.Size(925, 200);
			this.dataGrid1.TabIndex = 23;
			this.dataGrid1.Tag = "paymethod.anagrafica";
			// 
			// MetaDataToolBar
			// 
			this.MetaDataToolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.MetaDataToolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.seleziona,
            this.impostaricerca,
            this.effettuaricerca,
            this.modifica,
            this.inserisci,
            this.inseriscicopia,
            this.elimina,
            this.Salva,
            this.aggiorna});
			this.MetaDataToolBar.ButtonSize = new System.Drawing.Size(56, 56);
			this.MetaDataToolBar.DropDownArrows = true;
			this.MetaDataToolBar.ImageList = this.images;
			this.MetaDataToolBar.Location = new System.Drawing.Point(0, 0);
			this.MetaDataToolBar.Name = "MetaDataToolBar";
			this.MetaDataToolBar.ShowToolTips = true;
			this.MetaDataToolBar.Size = new System.Drawing.Size(941, 56);
			this.MetaDataToolBar.TabIndex = 26;
			this.MetaDataToolBar.Tag = "";
			// 
			// seleziona
			// 
			this.seleziona.ImageIndex = 1;
			this.seleziona.Name = "seleziona";
			this.seleziona.Tag = "mainselect";
			this.seleziona.Text = "Seleziona";
			this.seleziona.ToolTipText = "Seleziona l\'elemento desiderato";
			// 
			// impostaricerca
			// 
			this.impostaricerca.ImageIndex = 10;
			this.impostaricerca.Name = "impostaricerca";
			this.impostaricerca.Tag = "mainsetsearch";
			this.impostaricerca.Text = "Imposta Ricerca";
			this.impostaricerca.ToolTipText = "Imposta una nuova ricerca";
			// 
			// effettuaricerca
			// 
			this.effettuaricerca.ImageIndex = 12;
			this.effettuaricerca.Name = "effettuaricerca";
			this.effettuaricerca.Tag = "maindosearch";
			this.effettuaricerca.Text = "Effettua Ricerca";
			this.effettuaricerca.ToolTipText = "Cerca in base ai dati immessi";
			// 
			// modifica
			// 
			this.modifica.ImageIndex = 6;
			this.modifica.Name = "modifica";
			this.modifica.Tag = "mainedit";
			this.modifica.Text = "Modifica";
			this.modifica.ToolTipText = "Modifica l\'elemento selezionato";
			// 
			// inserisci
			// 
			this.inserisci.ImageIndex = 0;
			this.inserisci.Name = "inserisci";
			this.inserisci.Tag = "maininsert";
			this.inserisci.Text = "Inserisci";
			this.inserisci.ToolTipText = "Inserisci un nuovo elemento";
			// 
			// inseriscicopia
			// 
			this.inseriscicopia.ImageIndex = 9;
			this.inseriscicopia.Name = "inseriscicopia";
			this.inseriscicopia.Tag = "maininsertcopy";
			this.inseriscicopia.Text = "Inserisci copia";
			this.inseriscicopia.ToolTipText = "Inserisci un nuovo elemento copiando i dati da quello attuale";
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
			this.aggiorna.ImageIndex = 13;
			this.aggiorna.Name = "aggiorna";
			this.aggiorna.Tag = "mainrefresh";
			this.aggiorna.Text = "Aggiorna";
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
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// cmbabilabel
			// 
			this.cmbabilabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbabilabel.DataSource = this.DS.abi_label_lookup;
			this.cmbabilabel.DisplayMember = "description";
			this.cmbabilabel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbabilabel.Location = new System.Drawing.Point(4, 69);
			this.cmbabilabel.Name = "cmbabilabel";
			this.cmbabilabel.Size = new System.Drawing.Size(407, 21);
			this.cmbabilabel.TabIndex = 18;
			this.cmbabilabel.Tag = "paymethod.abi_label";
			this.cmbabilabel.ValueMember = "abi_label";
			// 
			// Frm_paymethod_anagrafica
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(941, 631);
			this.Controls.Add(this.MetaDataDetail);
			this.Controls.Add(this.dataGrid1);
			this.Controls.Add(this.MetaDataToolBar);
			this.Name = "Frm_paymethod_anagrafica";
			this.Text = "frmModalitaPagamentoAnagrafica";
			this.MetaDataDetail.ResumeLayout(false);
			this.MetaDataDetail.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.gboxEsecuzione.ResumeLayout(false);
			this.gboxEsecuzione.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

        

        void DeselezionaAltriCheckBox(GroupBox G, CheckBox C) {
            if (C.CheckState != CheckState.Checked) return;
            foreach (Control c in G.Controls) {
                if (c == C) continue;
                CheckBox chk = c as CheckBox;
                if (chk == null) continue;
                if (chk.CheckState == CheckState.Checked) chk.Checked = false;
            }
        }

        private void CheckBoxVincolatoChange(object sender, EventArgs e) {
            CheckBox C = sender as CheckBox;
            if (C==null) {
                MessageBox.Show("Metodo CheckBoxVincolatoChange con parametro non checkbox","Errore");
                return;
            }
            GroupBox  CParent = C.Parent as GroupBox;
            if (CParent==null){
                MessageBox.Show("Metodo CheckBoxVincolatoChange con parametro checkbox non contenuto in g.box","Errore");
                return;
            }
            DeselezionaAltriCheckBox(CParent, C);
        }
    }
}
