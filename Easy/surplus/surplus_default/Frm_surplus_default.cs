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
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;


namespace surplus_default {//situazioneammin//
	/// <summary>
	/// Summary description for frmsituazionefinanziaria.
	/// </summary>
	public class Frm_surplus_default : System.Windows.Forms.Form {
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.TextBox txtData;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtEsercizio;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.TextBox textBox18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.TextBox textBox22;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.TextBox textBox26;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.TextBox textBox31;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.Label label37;
		public  vistaForm DS;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.Label label41;
		private System.Windows.Forms.Label label44;
		private System.Windows.Forms.Label label45;
		private System.Windows.Forms.Label label48;
		private System.Windows.Forms.Label label51;
		private System.Windows.Forms.Label label52;
		private System.Windows.Forms.Label label53;
		private System.Windows.Forms.Label label54;
		private System.Windows.Forms.Label label57;
		private System.Windows.Forms.Label label60;
		private System.Windows.Forms.Label label61;
		private System.Windows.Forms.Label label62;
		private System.Windows.Forms.Label label65;
		private System.Windows.Forms.Label label68;
		private System.Windows.Forms.TextBox txtEsercizioAmmPresunta;
		private System.Windows.Forms.TextBox txtpagamentidata;
		private System.Windows.Forms.TextBox txtincassidata;
		private System.Windows.Forms.TextBox txtpagamenti0101;
		private System.Windows.Forms.TextBox txtfondocassa0101;
		private System.Windows.Forms.Button btnRicalcola1;
		private System.Windows.Forms.Button btnRicalcola2;
		private System.Windows.Forms.Button btnRicalcola3;
		private System.Windows.Forms.TextBox txtResiduiPassiviPresunti;
		private System.Windows.Forms.TextBox txtResiduiPassiviPrec;
		private System.Windows.Forms.TextBox txtTotaleResiduiAttiviPres;
		private System.Windows.Forms.TextBox txtResiduiAttiviPresunti;
		private System.Windows.Forms.TextBox txtResiduiAttiviPrec;
		private System.Windows.Forms.TextBox txtFondoCassaPresunto3112;
		private System.Windows.Forms.TextBox txtDataAmmPresunta;
		private System.Windows.Forms.TextBox txtIncassiContoResidui;
		private System.Windows.Forms.TextBox txtIncassiContoCompetenza;
		private System.Windows.Forms.TextBox txtResiduiPassiviAnno;
		private System.Windows.Forms.TextBox txtResiduiPassiviPrecEff;
		private System.Windows.Forms.TextBox txtResiduiAttiviAnno;
		private System.Windows.Forms.TextBox txtResiduiAttiviPrecEff;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.Button btnRicalcola4;
		private System.Windows.Forms.TextBox txtEsercizioFinEffettiva;
		private System.Windows.Forms.TextBox txtEsercizioAmmEffettiva;
		MetaData Meta;
		private System.Windows.Forms.TextBox txtFondoCassa0101bis;
		private System.Windows.Forms.TextBox txtFondopresuntoal3112;
		private System.Windows.Forms.Label labPagamentiPresuntiData;
		private System.Windows.Forms.Label labIncassiPresuntiData;
		private System.Windows.Forms.Label labFondiCassaData;
		private System.Windows.Forms.Label labPagamentiData;
		private System.Windows.Forms.Label labIncassiData;
		private System.Windows.Forms.TextBox txtavammpres3112;
		private System.Windows.Forms.TextBox txtfondocassa3112;
		private System.Windows.Forms.TextBox txtfondocassa3112bis;
		private System.Windows.Forms.TextBox txtavanzoamm3112;
		private System.Windows.Forms.TextBox txttotrespasspres;
		private System.Windows.Forms.Label labFondo1_1;
		private System.Windows.Forms.Label FCassaPres3112;
		private System.Windows.Forms.Label txtAvaCassPres3112;
		private System.Windows.Forms.Label labResPassiviAnno;
		private System.Windows.Forms.Label labResPassPrec;
		private System.Windows.Forms.Label labResAttiviAnno;
		private System.Windows.Forms.Label labAttiviPresPrec;
		private System.Windows.Forms.Label labFCassaPresunto3112;
		private System.Windows.Forms.Label labFondocassa3112;
		private System.Windows.Forms.Label labFondo1_1_bis;
		private System.Windows.Forms.Label labAvaCassa3112;
		private System.Windows.Forms.Label labFcassa3112ter;
		private System.Windows.Forms.Label labResAttiviPrec;
		private System.Windows.Forms.Label labResAttiviAnnobis;
		private System.Windows.Forms.Label labResPassiviPrec;
		private System.Windows.Forms.Label labResPassiviAnnoBis;
		private System.Windows.Forms.Button btnIncassi0101Data;
		private System.Windows.Forms.Button btnPagamenti0101Data;
		private System.Windows.Forms.Button btnIncassiCompetenza;
		private System.Windows.Forms.Button btnIncassiResidui;
		private System.Windows.Forms.Button btnPagamentiCompetenza;
		private System.Windows.Forms.Button btnPagamentiResidui;
		private string flagvaliditadoc;
		private System.Windows.Forms.Button btnResiduiAttiviPrec;
		private System.Windows.Forms.Button btnResiduiAttiviAtt;
		private System.Windows.Forms.Button btnResiduiPassiviPrec;
		private System.Windows.Forms.Button btnResiduiPassiviAtt;
		private string faseaccertamento;
		private string faseimpegno;
		private string filteresercizio;
		private int presunta_effettiva;
		bool CanGoEdit;
		bool CanGoInsert;
        bool IsAdmin;
		private System.Windows.Forms.Button btnIncassiPresunti3112;
		private System.Windows.Forms.Button btnPagamentiPresunti3112;
		private System.Windows.Forms.Button btnResiduiAttiviPresuntiPrec;
		private System.Windows.Forms.Button btnResiduiAttiviPresuntiAtt;
		private System.Windows.Forms.Button btnResiduiPassiviPresuntiPrec;
		private System.Windows.Forms.Button btnResiduiPassiviPresuntiAtt;
		private System.Windows.Forms.TextBox txtDescrIncassi0101Data;
		private System.Windows.Forms.TextBox txtDescrPagamenti0101Data;
		private System.Windows.Forms.TextBox txtDescrIncassiPresunti;
		private System.Windows.Forms.TextBox txtDescrPagamentiPresunti;
		private System.Windows.Forms.TextBox txtDescrIncassiCompetenza;
		private System.Windows.Forms.TextBox txtDescrIncassiResidui;
		private System.Windows.Forms.TextBox txtDescrPagamentiCompetenza;
		private System.Windows.Forms.TextBox txtDescrPagamentiResidui;
		private System.Windows.Forms.TextBox txtDescrFondoCassaPresunto3112;
		private System.Windows.Forms.TextBox txtDescrResiduiAttiviPresuntiPrecedenti;
		private System.Windows.Forms.TextBox txtDescrResiduiAttiviPresuntiCorrenti;
		private System.Windows.Forms.TextBox txtDescrResiduiPassiviPresuntiPrecedenti;
		private System.Windows.Forms.TextBox txtDescrResiduiPassiviPresuntiCorrenti;
		private System.Windows.Forms.TextBox txtDescrResiduiAttiviPrecedenti;
		private System.Windows.Forms.TextBox txtDescrResiduiAttiviCorrenti;
		private System.Windows.Forms.TextBox txtDescrResiduiPassiviPrecedenti;
		private System.Windows.Forms.TextBox txtDescrResiduiPassiviCorrenti;
		private System.Windows.Forms.TextBox txtincassi0101;
		private System.Windows.Forms.TextBox txtPagamentiContoCompetenza;
		private System.Windows.Forms.TextBox txtPagamentiContoResidui;
		private System.Windows.Forms.Button btnStampa1;
		private System.Windows.Forms.Button btnStampa3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_surplus_default() {
			InitializeComponent();
			SetEvent();
			CanGoEdit=true;
			
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
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.btnStampa1 = new System.Windows.Forms.Button();
			this.txtDescrPagamentiPresunti = new System.Windows.Forms.TextBox();
			this.txtDescrIncassiPresunti = new System.Windows.Forms.TextBox();
			this.txtDescrPagamenti0101Data = new System.Windows.Forms.TextBox();
			this.txtDescrIncassi0101Data = new System.Windows.Forms.TextBox();
			this.btnPagamentiPresunti3112 = new System.Windows.Forms.Button();
			this.btnIncassiPresunti3112 = new System.Windows.Forms.Button();
			this.btnPagamenti0101Data = new System.Windows.Forms.Button();
			this.btnIncassi0101Data = new System.Windows.Forms.Button();
			this.label44 = new System.Windows.Forms.Label();
			this.label41 = new System.Windows.Forms.Label();
			this.label38 = new System.Windows.Forms.Label();
			this.txtFondopresuntoal3112 = new System.Windows.Forms.TextBox();
			this.txtpagamentidata = new System.Windows.Forms.TextBox();
			this.txtincassidata = new System.Windows.Forms.TextBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.FCassaPres3112 = new System.Windows.Forms.Label();
			this.labPagamentiPresuntiData = new System.Windows.Forms.Label();
			this.labIncassiPresuntiData = new System.Windows.Forms.Label();
			this.labFondiCassaData = new System.Windows.Forms.Label();
			this.txtpagamenti0101 = new System.Windows.Forms.TextBox();
			this.txtincassi0101 = new System.Windows.Forms.TextBox();
			this.txtfondocassa0101 = new System.Windows.Forms.TextBox();
			this.labPagamentiData = new System.Windows.Forms.Label();
			this.labIncassiData = new System.Windows.Forms.Label();
			this.labFondo1_1 = new System.Windows.Forms.Label();
			this.btnRicalcola1 = new System.Windows.Forms.Button();
			this.txtData = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtEsercizio = new System.Windows.Forms.TextBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.btnStampa3 = new System.Windows.Forms.Button();
			this.txtDescrResiduiPassiviPresuntiCorrenti = new System.Windows.Forms.TextBox();
			this.txtDescrResiduiPassiviPresuntiPrecedenti = new System.Windows.Forms.TextBox();
			this.txtDescrResiduiAttiviPresuntiCorrenti = new System.Windows.Forms.TextBox();
			this.txtDescrResiduiAttiviPresuntiPrecedenti = new System.Windows.Forms.TextBox();
			this.txtDescrFondoCassaPresunto3112 = new System.Windows.Forms.TextBox();
			this.btnResiduiPassiviPresuntiAtt = new System.Windows.Forms.Button();
			this.btnResiduiPassiviPresuntiPrec = new System.Windows.Forms.Button();
			this.btnResiduiAttiviPresuntiAtt = new System.Windows.Forms.Button();
			this.btnResiduiAttiviPresuntiPrec = new System.Windows.Forms.Button();
			this.label52 = new System.Windows.Forms.Label();
			this.label45 = new System.Windows.Forms.Label();
			this.label48 = new System.Windows.Forms.Label();
			this.label51 = new System.Windows.Forms.Label();
			this.txttotrespasspres = new System.Windows.Forms.TextBox();
			this.label20 = new System.Windows.Forms.Label();
			this.txtavammpres3112 = new System.Windows.Forms.TextBox();
			this.txtResiduiPassiviPresunti = new System.Windows.Forms.TextBox();
			this.txtResiduiPassiviPrec = new System.Windows.Forms.TextBox();
			this.txtTotaleResiduiAttiviPres = new System.Windows.Forms.TextBox();
			this.txtAvaCassPres3112 = new System.Windows.Forms.Label();
			this.labResPassiviAnno = new System.Windows.Forms.Label();
			this.labResPassPrec = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.txtResiduiAttiviPresunti = new System.Windows.Forms.TextBox();
			this.txtResiduiAttiviPrec = new System.Windows.Forms.TextBox();
			this.txtFondoCassaPresunto3112 = new System.Windows.Forms.TextBox();
			this.labResAttiviAnno = new System.Windows.Forms.Label();
			this.labAttiviPresPrec = new System.Windows.Forms.Label();
			this.labFCassaPresunto3112 = new System.Windows.Forms.Label();
			this.btnRicalcola2 = new System.Windows.Forms.Button();
			this.txtDataAmmPresunta = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.txtEsercizioAmmPresunta = new System.Windows.Forms.TextBox();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.txtDescrPagamentiResidui = new System.Windows.Forms.TextBox();
			this.txtDescrPagamentiCompetenza = new System.Windows.Forms.TextBox();
			this.txtDescrIncassiResidui = new System.Windows.Forms.TextBox();
			this.txtDescrIncassiCompetenza = new System.Windows.Forms.TextBox();
			this.btnPagamentiResidui = new System.Windows.Forms.Button();
			this.btnPagamentiCompetenza = new System.Windows.Forms.Button();
			this.btnIncassiResidui = new System.Windows.Forms.Button();
			this.btnIncassiCompetenza = new System.Windows.Forms.Button();
			this.label53 = new System.Windows.Forms.Label();
			this.label54 = new System.Windows.Forms.Label();
			this.label57 = new System.Windows.Forms.Label();
			this.label60 = new System.Windows.Forms.Label();
			this.textBox18 = new System.Windows.Forms.TextBox();
			this.label19 = new System.Windows.Forms.Label();
			this.txtfondocassa3112 = new System.Windows.Forms.TextBox();
			this.txtPagamentiContoResidui = new System.Windows.Forms.TextBox();
			this.txtPagamentiContoCompetenza = new System.Windows.Forms.TextBox();
			this.textBox22 = new System.Windows.Forms.TextBox();
			this.labFondocassa3112 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.txtIncassiContoResidui = new System.Windows.Forms.TextBox();
			this.txtIncassiContoCompetenza = new System.Windows.Forms.TextBox();
			this.txtFondoCassa0101bis = new System.Windows.Forms.TextBox();
			this.label25 = new System.Windows.Forms.Label();
			this.label26 = new System.Windows.Forms.Label();
			this.labFondo1_1_bis = new System.Windows.Forms.Label();
			this.btnRicalcola3 = new System.Windows.Forms.Button();
			this.label29 = new System.Windows.Forms.Label();
			this.txtEsercizioFinEffettiva = new System.Windows.Forms.TextBox();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.txtDescrResiduiPassiviCorrenti = new System.Windows.Forms.TextBox();
			this.txtDescrResiduiPassiviPrecedenti = new System.Windows.Forms.TextBox();
			this.txtDescrResiduiAttiviCorrenti = new System.Windows.Forms.TextBox();
			this.txtDescrResiduiAttiviPrecedenti = new System.Windows.Forms.TextBox();
			this.btnResiduiPassiviAtt = new System.Windows.Forms.Button();
			this.btnResiduiPassiviPrec = new System.Windows.Forms.Button();
			this.btnResiduiAttiviAtt = new System.Windows.Forms.Button();
			this.btnResiduiAttiviPrec = new System.Windows.Forms.Button();
			this.label61 = new System.Windows.Forms.Label();
			this.label62 = new System.Windows.Forms.Label();
			this.label65 = new System.Windows.Forms.Label();
			this.label68 = new System.Windows.Forms.Label();
			this.textBox26 = new System.Windows.Forms.TextBox();
			this.label28 = new System.Windows.Forms.Label();
			this.txtavanzoamm3112 = new System.Windows.Forms.TextBox();
			this.txtResiduiPassiviAnno = new System.Windows.Forms.TextBox();
			this.txtResiduiPassiviPrecEff = new System.Windows.Forms.TextBox();
			this.textBox31 = new System.Windows.Forms.TextBox();
			this.labAvaCassa3112 = new System.Windows.Forms.Label();
			this.labResPassiviAnnoBis = new System.Windows.Forms.Label();
			this.labResPassiviPrec = new System.Windows.Forms.Label();
			this.label33 = new System.Windows.Forms.Label();
			this.txtResiduiAttiviAnno = new System.Windows.Forms.TextBox();
			this.txtResiduiAttiviPrecEff = new System.Windows.Forms.TextBox();
			this.txtfondocassa3112bis = new System.Windows.Forms.TextBox();
			this.labResAttiviAnnobis = new System.Windows.Forms.Label();
			this.labResAttiviPrec = new System.Windows.Forms.Label();
			this.labFcassa3112ter = new System.Windows.Forms.Label();
			this.btnRicalcola4 = new System.Windows.Forms.Button();
			this.label37 = new System.Windows.Forms.Label();
			this.txtEsercizioAmmEffettiva = new System.Windows.Forms.TextBox();
			this.DS = new surplus_default.vistaForm();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tabPage4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Location = new System.Drawing.Point(8, 16);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(760, 432);
			this.tabControl1.TabIndex = 11;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.btnStampa1);
			this.tabPage1.Controls.Add(this.txtDescrPagamentiPresunti);
			this.tabPage1.Controls.Add(this.txtDescrIncassiPresunti);
			this.tabPage1.Controls.Add(this.txtDescrPagamenti0101Data);
			this.tabPage1.Controls.Add(this.txtDescrIncassi0101Data);
			this.tabPage1.Controls.Add(this.btnPagamentiPresunti3112);
			this.tabPage1.Controls.Add(this.btnIncassiPresunti3112);
			this.tabPage1.Controls.Add(this.btnPagamenti0101Data);
			this.tabPage1.Controls.Add(this.btnIncassi0101Data);
			this.tabPage1.Controls.Add(this.label44);
			this.tabPage1.Controls.Add(this.label41);
			this.tabPage1.Controls.Add(this.label38);
			this.tabPage1.Controls.Add(this.txtFondopresuntoal3112);
			this.tabPage1.Controls.Add(this.txtpagamentidata);
			this.tabPage1.Controls.Add(this.txtincassidata);
			this.tabPage1.Controls.Add(this.textBox4);
			this.tabPage1.Controls.Add(this.FCassaPres3112);
			this.tabPage1.Controls.Add(this.labPagamentiPresuntiData);
			this.tabPage1.Controls.Add(this.labIncassiPresuntiData);
			this.tabPage1.Controls.Add(this.labFondiCassaData);
			this.tabPage1.Controls.Add(this.txtpagamenti0101);
			this.tabPage1.Controls.Add(this.txtincassi0101);
			this.tabPage1.Controls.Add(this.txtfondocassa0101);
			this.tabPage1.Controls.Add(this.labPagamentiData);
			this.tabPage1.Controls.Add(this.labIncassiData);
			this.tabPage1.Controls.Add(this.labFondo1_1);
			this.tabPage1.Controls.Add(this.btnRicalcola1);
			this.tabPage1.Controls.Add(this.txtData);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.txtEsercizio);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(752, 406);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Finanziaria";
			// 
			// btnStampa1
			// 
			this.btnStampa1.Location = new System.Drawing.Point(552, 16);
			this.btnStampa1.Name = "btnStampa1";
			this.btnStampa1.TabIndex = 54;
			this.btnStampa1.Text = "Stampa";
			this.btnStampa1.Click += new System.EventHandler(this.btnStampa1_Click);
			// 
			// txtDescrPagamentiPresunti
			// 
			this.txtDescrPagamentiPresunti.Location = new System.Drawing.Point(464, 272);
			this.txtDescrPagamentiPresunti.Multiline = true;
			this.txtDescrPagamentiPresunti.Name = "txtDescrPagamentiPresunti";
			this.txtDescrPagamentiPresunti.ReadOnly = true;
			this.txtDescrPagamentiPresunti.Size = new System.Drawing.Size(280, 64);
			this.txtDescrPagamentiPresunti.TabIndex = 53;
			this.txtDescrPagamentiPresunti.TabStop = false;
			this.txtDescrPagamentiPresunti.Text = "Pagamenti Trasmessi dopo la data della situazione finanziaria comunque entro l\'an" +
				"no + Pagamenti non inseriti in mandato + Pagamenti non Trasmessi + Impegni che s" +
				"cadono entro l\'anno o di cui la data di scadenza non Ë specificata";
			// 
			// txtDescrIncassiPresunti
			// 
			this.txtDescrIncassiPresunti.Location = new System.Drawing.Point(464, 208);
			this.txtDescrIncassiPresunti.Multiline = true;
			this.txtDescrIncassiPresunti.Name = "txtDescrIncassiPresunti";
			this.txtDescrIncassiPresunti.ReadOnly = true;
			this.txtDescrIncassiPresunti.Size = new System.Drawing.Size(280, 64);
			this.txtDescrIncassiPresunti.TabIndex = 52;
			this.txtDescrIncassiPresunti.TabStop = false;
			this.txtDescrIncassiPresunti.Text = "Incassi Trasmessi dopo la data della situazione finanziaria comunque entro l\'anno" +
				" + Incassi non inseriti in reversale + Incassi non Trasmessi + Accertamenti che " +
				"scadono entro l\'anno o di cui la data di scadenza non Ë specificata";
			// 
			// txtDescrPagamenti0101Data
			// 
			this.txtDescrPagamenti0101Data.Location = new System.Drawing.Point(464, 136);
			this.txtDescrPagamenti0101Data.Multiline = true;
			this.txtDescrPagamenti0101Data.Name = "txtDescrPagamenti0101Data";
			this.txtDescrPagamenti0101Data.ReadOnly = true;
			this.txtDescrPagamenti0101Data.Size = new System.Drawing.Size(280, 32);
			this.txtDescrPagamenti0101Data.TabIndex = 51;
			this.txtDescrPagamenti0101Data.TabStop = false;
			this.txtDescrPagamenti0101Data.Text = "Sono considerati tutti i pagamenti dell\'anno in corso in base alla configurazione" +
				" di bilancio";
			// 
			// txtDescrIncassi0101Data
			// 
			this.txtDescrIncassi0101Data.Location = new System.Drawing.Point(464, 96);
			this.txtDescrIncassi0101Data.Multiline = true;
			this.txtDescrIncassi0101Data.Name = "txtDescrIncassi0101Data";
			this.txtDescrIncassi0101Data.ReadOnly = true;
			this.txtDescrIncassi0101Data.Size = new System.Drawing.Size(280, 32);
			this.txtDescrIncassi0101Data.TabIndex = 50;
			this.txtDescrIncassi0101Data.TabStop = false;
			this.txtDescrIncassi0101Data.Text = "Sono considerati tutti gli incassi dell\'anno in corso in base alla configurazione" +
				" di bilancio";
			// 
			// btnPagamentiPresunti3112
			// 
			this.btnPagamentiPresunti3112.Location = new System.Drawing.Point(424, 288);
			this.btnPagamentiPresunti3112.Name = "btnPagamentiPresunti3112";
			this.btnPagamentiPresunti3112.Size = new System.Drawing.Size(32, 20);
			this.btnPagamentiPresunti3112.TabIndex = 35;
			this.btnPagamentiPresunti3112.Text = "F";
			this.btnPagamentiPresunti3112.Click += new System.EventHandler(this.btnPagamentiPresunti3112_Click);
			// 
			// btnIncassiPresunti3112
			// 
			this.btnIncassiPresunti3112.Location = new System.Drawing.Point(424, 232);
			this.btnIncassiPresunti3112.Name = "btnIncassiPresunti3112";
			this.btnIncassiPresunti3112.Size = new System.Drawing.Size(32, 20);
			this.btnIncassiPresunti3112.TabIndex = 33;
			this.btnIncassiPresunti3112.Text = "E";
			this.btnIncassiPresunti3112.Click += new System.EventHandler(this.btnIncassiPresunti3112_Click);
			// 
			// btnPagamenti0101Data
			// 
			this.btnPagamenti0101Data.Location = new System.Drawing.Point(424, 144);
			this.btnPagamenti0101Data.Name = "btnPagamenti0101Data";
			this.btnPagamenti0101Data.Size = new System.Drawing.Size(32, 20);
			this.btnPagamenti0101Data.TabIndex = 31;
			this.btnPagamenti0101Data.Text = "C";
			this.btnPagamenti0101Data.Click += new System.EventHandler(this.btnPagamenti0101Data_Click);
			// 
			// btnIncassi0101Data
			// 
			this.btnIncassi0101Data.Location = new System.Drawing.Point(424, 104);
			this.btnIncassi0101Data.Name = "btnIncassi0101Data";
			this.btnIncassi0101Data.Size = new System.Drawing.Size(32, 20);
			this.btnIncassi0101Data.TabIndex = 29;
			this.btnIncassi0101Data.Text = "B";
			this.btnIncassi0101Data.Click += new System.EventHandler(this.btnIncassi0101Data_Click);
			// 
			// label44
			// 
			this.label44.Location = new System.Drawing.Point(408, 336);
			this.label44.Name = "label44";
			this.label44.Size = new System.Drawing.Size(72, 23);
			this.label44.TabIndex = 44;
			this.label44.Text = "G = D + E - F";
			this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label41
			// 
			this.label41.Location = new System.Drawing.Point(408, 184);
			this.label41.Name = "label41";
			this.label41.Size = new System.Drawing.Size(72, 23);
			this.label41.TabIndex = 41;
			this.label41.Text = "D = A + B - C ";
			this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label38
			// 
			this.label38.Location = new System.Drawing.Point(424, 64);
			this.label38.Name = "label38";
			this.label38.Size = new System.Drawing.Size(32, 23);
			this.label38.TabIndex = 38;
			this.label38.Text = "A";
			this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtFondopresuntoal3112
			// 
			this.txtFondopresuntoal3112.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtFondopresuntoal3112.Location = new System.Drawing.Point(280, 336);
			this.txtFondopresuntoal3112.Name = "txtFondopresuntoal3112";
			this.txtFondopresuntoal3112.ReadOnly = true;
			this.txtFondopresuntoal3112.Size = new System.Drawing.Size(120, 20);
			this.txtFondopresuntoal3112.TabIndex = 37;
			this.txtFondopresuntoal3112.TabStop = false;
			this.txtFondopresuntoal3112.Tag = "surplus.!fondocassapres3112";
			this.txtFondopresuntoal3112.Text = "";
			// 
			// txtpagamentidata
			// 
			this.txtpagamentidata.Location = new System.Drawing.Point(280, 288);
			this.txtpagamentidata.Name = "txtpagamentidata";
			this.txtpagamentidata.Size = new System.Drawing.Size(120, 20);
			this.txtpagamentidata.TabIndex = 34;
			this.txtpagamentidata.Tag = "surplus.paymentstoendofyear";
			this.txtpagamentidata.Text = "";
			// 
			// txtincassidata
			// 
			this.txtincassidata.Location = new System.Drawing.Point(280, 232);
			this.txtincassidata.Name = "txtincassidata";
			this.txtincassidata.Size = new System.Drawing.Size(120, 20);
			this.txtincassidata.TabIndex = 32;
			this.txtincassidata.Tag = "surplus.proceedstoendofyear";
			this.txtincassidata.Text = "";
			// 
			// textBox4
			// 
			this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.textBox4.Location = new System.Drawing.Point(280, 184);
			this.textBox4.Name = "textBox4";
			this.textBox4.ReadOnly = true;
			this.textBox4.Size = new System.Drawing.Size(120, 20);
			this.textBox4.TabIndex = 34;
			this.textBox4.TabStop = false;
			this.textBox4.Tag = "surplus.!fondocassadata";
			this.textBox4.Text = "";
			this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
			// 
			// FCassaPres3112
			// 
			this.FCassaPres3112.Location = new System.Drawing.Point(24, 336);
			this.FCassaPres3112.Name = "FCassaPres3112";
			this.FCassaPres3112.Size = new System.Drawing.Size(248, 23);
			this.FCassaPres3112.TabIndex = 33;
			this.FCassaPres3112.Text = "Fondo di cassa presunto al 31/12";
			this.FCassaPres3112.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labPagamentiPresuntiData
			// 
			this.labPagamentiPresuntiData.Location = new System.Drawing.Point(24, 288);
			this.labPagamentiPresuntiData.Name = "labPagamentiPresuntiData";
			this.labPagamentiPresuntiData.Size = new System.Drawing.Size(248, 23);
			this.labPagamentiPresuntiData.TabIndex = 32;
			this.labPagamentiPresuntiData.Text = "Pagamenti presunti dalla data al 31/12";
			this.labPagamentiPresuntiData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labIncassiPresuntiData
			// 
			this.labIncassiPresuntiData.Location = new System.Drawing.Point(24, 232);
			this.labIncassiPresuntiData.Name = "labIncassiPresuntiData";
			this.labIncassiPresuntiData.Size = new System.Drawing.Size(248, 23);
			this.labIncassiPresuntiData.TabIndex = 31;
			this.labIncassiPresuntiData.Text = "Incassi presunti dalla data al 31/12:";
			this.labIncassiPresuntiData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labFondiCassaData
			// 
			this.labFondiCassaData.Location = new System.Drawing.Point(24, 184);
			this.labFondiCassaData.Name = "labFondiCassaData";
			this.labFondiCassaData.Size = new System.Drawing.Size(248, 23);
			this.labFondiCassaData.TabIndex = 30;
			this.labFondiCassaData.Text = "Fondo di cassa alla data:";
			this.labFondiCassaData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtpagamenti0101
			// 
			this.txtpagamenti0101.Location = new System.Drawing.Point(280, 144);
			this.txtpagamenti0101.Name = "txtpagamenti0101";
			this.txtpagamenti0101.Size = new System.Drawing.Size(120, 20);
			this.txtpagamenti0101.TabIndex = 30;
			this.txtpagamenti0101.Tag = "surplus.paymentstilldate";
			this.txtpagamenti0101.Text = "";
			// 
			// txtincassi0101
			// 
			this.txtincassi0101.Location = new System.Drawing.Point(280, 104);
			this.txtincassi0101.Name = "txtincassi0101";
			this.txtincassi0101.Size = new System.Drawing.Size(120, 20);
			this.txtincassi0101.TabIndex = 28;
			this.txtincassi0101.Tag = "surplus.proceedstilldate";
			this.txtincassi0101.Text = "";
			// 
			// txtfondocassa0101
			// 
			this.txtfondocassa0101.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtfondocassa0101.Location = new System.Drawing.Point(280, 64);
			this.txtfondocassa0101.Name = "txtfondocassa0101";
			this.txtfondocassa0101.Size = new System.Drawing.Size(120, 20);
			this.txtfondocassa0101.TabIndex = 27;
			this.txtfondocassa0101.Tag = "surplus.startfloatfund";
			this.txtfondocassa0101.Text = "";
			this.txtfondocassa0101.TextChanged += new System.EventHandler(this.txtfondocassa0101_TextChanged);
			// 
			// labPagamentiData
			// 
			this.labPagamentiData.Location = new System.Drawing.Point(24, 144);
			this.labPagamentiData.Name = "labPagamentiData";
			this.labPagamentiData.Size = new System.Drawing.Size(248, 23);
			this.labPagamentiData.TabIndex = 26;
			this.labPagamentiData.Text = "Pagamenti dal 1/1 alla data:";
			this.labPagamentiData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labIncassiData
			// 
			this.labIncassiData.Location = new System.Drawing.Point(24, 104);
			this.labIncassiData.Name = "labIncassiData";
			this.labIncassiData.Size = new System.Drawing.Size(248, 23);
			this.labIncassiData.TabIndex = 25;
			this.labIncassiData.Text = "Incassi dal 1/1 alla data:";
			this.labIncassiData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labFondo1_1
			// 
			this.labFondo1_1.Location = new System.Drawing.Point(24, 64);
			this.labFondo1_1.Name = "labFondo1_1";
			this.labFondo1_1.Size = new System.Drawing.Size(248, 23);
			this.labFondo1_1.TabIndex = 24;
			this.labFondo1_1.Text = "Fondo di cassa al 1/1:";
			this.labFondo1_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnRicalcola1
			// 
			this.btnRicalcola1.Location = new System.Drawing.Point(456, 16);
			this.btnRicalcola1.Name = "btnRicalcola1";
			this.btnRicalcola1.TabIndex = 23;
			this.btnRicalcola1.Text = "Ricalcola";
			this.btnRicalcola1.Click += new System.EventHandler(this.btnRicalcola1_Click);
			// 
			// txtData
			// 
			this.txtData.Location = new System.Drawing.Point(280, 16);
			this.txtData.Name = "txtData";
			this.txtData.Size = new System.Drawing.Size(104, 20);
			this.txtData.TabIndex = 22;
			this.txtData.Tag = "surplus.previsiondate";
			this.txtData.Text = "";
			this.txtData.TextChanged += new System.EventHandler(this.txtData_TextChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(240, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(32, 16);
			this.label2.TabIndex = 21;
			this.label2.Text = "Data:";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(48, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(57, 16);
			this.label1.TabIndex = 20;
			this.label1.Text = "Esercizio:";
			// 
			// txtEsercizio
			// 
			this.txtEsercizio.Location = new System.Drawing.Point(104, 16);
			this.txtEsercizio.Name = "txtEsercizio";
			this.txtEsercizio.ReadOnly = true;
			this.txtEsercizio.Size = new System.Drawing.Size(77, 20);
			this.txtEsercizio.TabIndex = 19;
			this.txtEsercizio.TabStop = false;
			this.txtEsercizio.Tag = "surplus.ayear.year";
			this.txtEsercizio.Text = "";
			this.txtEsercizio.Leave += new System.EventHandler(this.txtEsercizio_Leave);
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.btnStampa3);
			this.tabPage2.Controls.Add(this.txtDescrResiduiPassiviPresuntiCorrenti);
			this.tabPage2.Controls.Add(this.txtDescrResiduiPassiviPresuntiPrecedenti);
			this.tabPage2.Controls.Add(this.txtDescrResiduiAttiviPresuntiCorrenti);
			this.tabPage2.Controls.Add(this.txtDescrResiduiAttiviPresuntiPrecedenti);
			this.tabPage2.Controls.Add(this.txtDescrFondoCassaPresunto3112);
			this.tabPage2.Controls.Add(this.btnResiduiPassiviPresuntiAtt);
			this.tabPage2.Controls.Add(this.btnResiduiPassiviPresuntiPrec);
			this.tabPage2.Controls.Add(this.btnResiduiAttiviPresuntiAtt);
			this.tabPage2.Controls.Add(this.btnResiduiAttiviPresuntiPrec);
			this.tabPage2.Controls.Add(this.label52);
			this.tabPage2.Controls.Add(this.label45);
			this.tabPage2.Controls.Add(this.label48);
			this.tabPage2.Controls.Add(this.label51);
			this.tabPage2.Controls.Add(this.txttotrespasspres);
			this.tabPage2.Controls.Add(this.label20);
			this.tabPage2.Controls.Add(this.txtavammpres3112);
			this.tabPage2.Controls.Add(this.txtResiduiPassiviPresunti);
			this.tabPage2.Controls.Add(this.txtResiduiPassiviPrec);
			this.tabPage2.Controls.Add(this.txtTotaleResiduiAttiviPres);
			this.tabPage2.Controls.Add(this.txtAvaCassPres3112);
			this.tabPage2.Controls.Add(this.labResPassiviAnno);
			this.tabPage2.Controls.Add(this.labResPassPrec);
			this.tabPage2.Controls.Add(this.label13);
			this.tabPage2.Controls.Add(this.txtResiduiAttiviPresunti);
			this.tabPage2.Controls.Add(this.txtResiduiAttiviPrec);
			this.tabPage2.Controls.Add(this.txtFondoCassaPresunto3112);
			this.tabPage2.Controls.Add(this.labResAttiviAnno);
			this.tabPage2.Controls.Add(this.labAttiviPresPrec);
			this.tabPage2.Controls.Add(this.labFCassaPresunto3112);
			this.tabPage2.Controls.Add(this.btnRicalcola2);
			this.tabPage2.Controls.Add(this.txtDataAmmPresunta);
			this.tabPage2.Controls.Add(this.label17);
			this.tabPage2.Controls.Add(this.label18);
			this.tabPage2.Controls.Add(this.txtEsercizioAmmPresunta);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(752, 406);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Ammininistrativa";
			// 
			// btnStampa3
			// 
			this.btnStampa3.Location = new System.Drawing.Point(552, 16);
			this.btnStampa3.Name = "btnStampa3";
			this.btnStampa3.TabIndex = 73;
			this.btnStampa3.Text = "Stampa";
			this.btnStampa3.Click += new System.EventHandler(this.btnStampa3_Click);
			// 
			// txtDescrResiduiPassiviPresuntiCorrenti
			// 
			this.txtDescrResiduiPassiviPresuntiCorrenti.Location = new System.Drawing.Point(480, 280);
			this.txtDescrResiduiPassiviPresuntiCorrenti.Multiline = true;
			this.txtDescrResiduiPassiviPresuntiCorrenti.Name = "txtDescrResiduiPassiviPresuntiCorrenti";
			this.txtDescrResiduiPassiviPresuntiCorrenti.ReadOnly = true;
			this.txtDescrResiduiPassiviPresuntiCorrenti.Size = new System.Drawing.Size(264, 32);
			this.txtDescrResiduiPassiviPresuntiCorrenti.TabIndex = 72;
			this.txtDescrResiduiPassiviPresuntiCorrenti.TabStop = false;
			this.txtDescrResiduiPassiviPresuntiCorrenti.Text = "Impegni non Pagati nell\'anno con data di scadenza in anni successivi ";
			// 
			// txtDescrResiduiPassiviPresuntiPrecedenti
			// 
			this.txtDescrResiduiPassiviPresuntiPrecedenti.Location = new System.Drawing.Point(480, 232);
			this.txtDescrResiduiPassiviPresuntiPrecedenti.Multiline = true;
			this.txtDescrResiduiPassiviPresuntiPrecedenti.Name = "txtDescrResiduiPassiviPresuntiPrecedenti";
			this.txtDescrResiduiPassiviPresuntiPrecedenti.ReadOnly = true;
			this.txtDescrResiduiPassiviPresuntiPrecedenti.Size = new System.Drawing.Size(264, 32);
			this.txtDescrResiduiPassiviPresuntiPrecedenti.TabIndex = 71;
			this.txtDescrResiduiPassiviPresuntiPrecedenti.TabStop = false;
			this.txtDescrResiduiPassiviPresuntiPrecedenti.Text = "Residui Passivi Precedenti non Pagati nell\'anno con data di scadenza in anni succ" +
				"essivi ";
			// 
			// txtDescrResiduiAttiviPresuntiCorrenti
			// 
			this.txtDescrResiduiAttiviPresuntiCorrenti.Location = new System.Drawing.Point(480, 152);
			this.txtDescrResiduiAttiviPresuntiCorrenti.Multiline = true;
			this.txtDescrResiduiAttiviPresuntiCorrenti.Name = "txtDescrResiduiAttiviPresuntiCorrenti";
			this.txtDescrResiduiAttiviPresuntiCorrenti.ReadOnly = true;
			this.txtDescrResiduiAttiviPresuntiCorrenti.Size = new System.Drawing.Size(264, 32);
			this.txtDescrResiduiAttiviPresuntiCorrenti.TabIndex = 70;
			this.txtDescrResiduiAttiviPresuntiCorrenti.TabStop = false;
			this.txtDescrResiduiAttiviPresuntiCorrenti.Text = "Accertamenti non incassati nell\'anno con data di scadenza in anni successivi ";
			// 
			// txtDescrResiduiAttiviPresuntiPrecedenti
			// 
			this.txtDescrResiduiAttiviPresuntiPrecedenti.Location = new System.Drawing.Point(480, 104);
			this.txtDescrResiduiAttiviPresuntiPrecedenti.Multiline = true;
			this.txtDescrResiduiAttiviPresuntiPrecedenti.Name = "txtDescrResiduiAttiviPresuntiPrecedenti";
			this.txtDescrResiduiAttiviPresuntiPrecedenti.ReadOnly = true;
			this.txtDescrResiduiAttiviPresuntiPrecedenti.Size = new System.Drawing.Size(264, 32);
			this.txtDescrResiduiAttiviPresuntiPrecedenti.TabIndex = 69;
			this.txtDescrResiduiAttiviPresuntiPrecedenti.TabStop = false;
			this.txtDescrResiduiAttiviPresuntiPrecedenti.Text = "Residui Attivi Precedenti non Incassati nell\'anno con data di scadenza in anni su" +
				"ccessivi ";
			// 
			// txtDescrFondoCassaPresunto3112
			// 
			this.txtDescrFondoCassaPresunto3112.Location = new System.Drawing.Point(480, 48);
			this.txtDescrFondoCassaPresunto3112.Multiline = true;
			this.txtDescrFondoCassaPresunto3112.Name = "txtDescrFondoCassaPresunto3112";
			this.txtDescrFondoCassaPresunto3112.ReadOnly = true;
			this.txtDescrFondoCassaPresunto3112.Size = new System.Drawing.Size(264, 48);
			this.txtDescrFondoCassaPresunto3112.TabIndex = 68;
			this.txtDescrFondoCassaPresunto3112.TabStop = false;
			this.txtDescrFondoCassaPresunto3112.Text = "Fondo di Cassa Iniziale + Incassi calcolati alla data della situazione Amministra" +
				"tiva - Pagamenti calcolati alla data della Situazione Amministrativa";
			// 
			// btnResiduiPassiviPresuntiAtt
			// 
			this.btnResiduiPassiviPresuntiAtt.Location = new System.Drawing.Point(440, 288);
			this.btnResiduiPassiviPresuntiAtt.Name = "btnResiduiPassiviPresuntiAtt";
			this.btnResiduiPassiviPresuntiAtt.Size = new System.Drawing.Size(32, 20);
			this.btnResiduiPassiviPresuntiAtt.TabIndex = 54;
			this.btnResiduiPassiviPresuntiAtt.Text = "F";
			this.btnResiduiPassiviPresuntiAtt.Click += new System.EventHandler(this.btnResiduiPassiviPresuntiAtt_Click);
			// 
			// btnResiduiPassiviPresuntiPrec
			// 
			this.btnResiduiPassiviPresuntiPrec.Location = new System.Drawing.Point(440, 240);
			this.btnResiduiPassiviPresuntiPrec.Name = "btnResiduiPassiviPresuntiPrec";
			this.btnResiduiPassiviPresuntiPrec.Size = new System.Drawing.Size(32, 20);
			this.btnResiduiPassiviPresuntiPrec.TabIndex = 52;
			this.btnResiduiPassiviPresuntiPrec.Text = "E";
			this.btnResiduiPassiviPresuntiPrec.Click += new System.EventHandler(this.btnResiduiPassiviPresuntiPrec_Click);
			// 
			// btnResiduiAttiviPresuntiAtt
			// 
			this.btnResiduiAttiviPresuntiAtt.Location = new System.Drawing.Point(440, 160);
			this.btnResiduiAttiviPresuntiAtt.Name = "btnResiduiAttiviPresuntiAtt";
			this.btnResiduiAttiviPresuntiAtt.Size = new System.Drawing.Size(32, 20);
			this.btnResiduiAttiviPresuntiAtt.TabIndex = 50;
			this.btnResiduiAttiviPresuntiAtt.Text = "C";
			this.btnResiduiAttiviPresuntiAtt.Click += new System.EventHandler(this.btnResiduiAttiviPresuntiAtt_Click);
			// 
			// btnResiduiAttiviPresuntiPrec
			// 
			this.btnResiduiAttiviPresuntiPrec.Location = new System.Drawing.Point(440, 112);
			this.btnResiduiAttiviPresuntiPrec.Name = "btnResiduiAttiviPresuntiPrec";
			this.btnResiduiAttiviPresuntiPrec.Size = new System.Drawing.Size(32, 20);
			this.btnResiduiAttiviPresuntiPrec.TabIndex = 48;
			this.btnResiduiAttiviPresuntiPrec.Text = "B";
			this.btnResiduiAttiviPresuntiPrec.Click += new System.EventHandler(this.btnResiduiAttiviPresuntiPrec_Click);
			// 
			// label52
			// 
			this.label52.Location = new System.Drawing.Point(432, 368);
			this.label52.Name = "label52";
			this.label52.Size = new System.Drawing.Size(72, 14);
			this.label52.TabIndex = 67;
			this.label52.Text = "H = A + D - G";
			this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label45
			// 
			this.label45.Location = new System.Drawing.Point(432, 328);
			this.label45.Name = "label45";
			this.label45.Size = new System.Drawing.Size(56, 16);
			this.label45.TabIndex = 66;
			this.label45.Text = "G = E + F";
			this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label48
			// 
			this.label48.Location = new System.Drawing.Point(432, 200);
			this.label48.Name = "label48";
			this.label48.Size = new System.Drawing.Size(56, 23);
			this.label48.TabIndex = 63;
			this.label48.Text = "D = B + C";
			this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label51
			// 
			this.label51.Location = new System.Drawing.Point(440, 64);
			this.label51.Name = "label51";
			this.label51.Size = new System.Drawing.Size(32, 23);
			this.label51.TabIndex = 60;
			this.label51.Text = "A";
			this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txttotrespasspres
			// 
			this.txttotrespasspres.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txttotrespasspres.Location = new System.Drawing.Point(296, 328);
			this.txttotrespasspres.Name = "txttotrespasspres";
			this.txttotrespasspres.ReadOnly = true;
			this.txttotrespasspres.Size = new System.Drawing.Size(120, 20);
			this.txttotrespasspres.TabIndex = 59;
			this.txttotrespasspres.TabStop = false;
			this.txttotrespasspres.Tag = "surplus.!totrespassivipres";
			this.txttotrespasspres.Text = "";
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(24, 328);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(264, 23);
			this.label20.TabIndex = 58;
			this.label20.Text = "Totale residui passivi presunti:";
			this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtavammpres3112
			// 
			this.txtavammpres3112.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtavammpres3112.Location = new System.Drawing.Point(296, 368);
			this.txtavammpres3112.Name = "txtavammpres3112";
			this.txtavammpres3112.ReadOnly = true;
			this.txtavammpres3112.Size = new System.Drawing.Size(120, 20);
			this.txtavammpres3112.TabIndex = 56;
			this.txtavammpres3112.TabStop = false;
			this.txtavammpres3112.Tag = "surplus.!avanzoammpres3112";
			this.txtavammpres3112.Text = "";
			// 
			// txtResiduiPassiviPresunti
			// 
			this.txtResiduiPassiviPresunti.Location = new System.Drawing.Point(296, 288);
			this.txtResiduiPassiviPresunti.Name = "txtResiduiPassiviPresunti";
			this.txtResiduiPassiviPresunti.Size = new System.Drawing.Size(120, 20);
			this.txtResiduiPassiviPresunti.TabIndex = 53;
			this.txtResiduiPassiviPresunti.Tag = "surplus.supposedcurrentexpenditure";
			this.txtResiduiPassiviPresunti.Text = "";
			// 
			// txtResiduiPassiviPrec
			// 
			this.txtResiduiPassiviPrec.Location = new System.Drawing.Point(296, 240);
			this.txtResiduiPassiviPrec.Name = "txtResiduiPassiviPrec";
			this.txtResiduiPassiviPrec.Size = new System.Drawing.Size(120, 20);
			this.txtResiduiPassiviPrec.TabIndex = 51;
			this.txtResiduiPassiviPrec.Tag = "surplus.supposedpreviousexpenditure";
			this.txtResiduiPassiviPrec.Text = "";
			// 
			// txtTotaleResiduiAttiviPres
			// 
			this.txtTotaleResiduiAttiviPres.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtTotaleResiduiAttiviPres.Location = new System.Drawing.Point(296, 200);
			this.txtTotaleResiduiAttiviPres.Name = "txtTotaleResiduiAttiviPres";
			this.txtTotaleResiduiAttiviPres.ReadOnly = true;
			this.txtTotaleResiduiAttiviPres.Size = new System.Drawing.Size(120, 20);
			this.txtTotaleResiduiAttiviPres.TabIndex = 53;
			this.txtTotaleResiduiAttiviPres.TabStop = false;
			this.txtTotaleResiduiAttiviPres.Tag = "surplus.!totresattivipres";
			this.txtTotaleResiduiAttiviPres.Text = "";
			// 
			// txtAvaCassPres3112
			// 
			this.txtAvaCassPres3112.Location = new System.Drawing.Point(24, 368);
			this.txtAvaCassPres3112.Name = "txtAvaCassPres3112";
			this.txtAvaCassPres3112.Size = new System.Drawing.Size(264, 23);
			this.txtAvaCassPres3112.TabIndex = 52;
			this.txtAvaCassPres3112.Text = "Avanzo di amministrazione presunto al 31/12:";
			this.txtAvaCassPres3112.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labResPassiviAnno
			// 
			this.labResPassiviAnno.Location = new System.Drawing.Point(24, 288);
			this.labResPassiviAnno.Name = "labResPassiviAnno";
			this.labResPassiviAnno.Size = new System.Drawing.Size(264, 23);
			this.labResPassiviAnno.TabIndex = 51;
			this.labResPassiviAnno.Text = "Residui passivi presunti dell\'anno:";
			this.labResPassiviAnno.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labResPassPrec
			// 
			this.labResPassPrec.Location = new System.Drawing.Point(24, 240);
			this.labResPassPrec.Name = "labResPassPrec";
			this.labResPassPrec.Size = new System.Drawing.Size(264, 23);
			this.labResPassPrec.TabIndex = 50;
			this.labResPassPrec.Text = "Residui passivi presunti degli anni precedenti:";
			this.labResPassPrec.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(24, 200);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(264, 23);
			this.label13.TabIndex = 49;
			this.label13.Text = "Totale residui attivi presunti:";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtResiduiAttiviPresunti
			// 
			this.txtResiduiAttiviPresunti.Location = new System.Drawing.Point(296, 160);
			this.txtResiduiAttiviPresunti.Name = "txtResiduiAttiviPresunti";
			this.txtResiduiAttiviPresunti.Size = new System.Drawing.Size(120, 20);
			this.txtResiduiAttiviPresunti.TabIndex = 49;
			this.txtResiduiAttiviPresunti.Tag = "surplus.supposedcurrentrevenue";
			this.txtResiduiAttiviPresunti.Text = "";
			// 
			// txtResiduiAttiviPrec
			// 
			this.txtResiduiAttiviPrec.Location = new System.Drawing.Point(296, 112);
			this.txtResiduiAttiviPrec.Name = "txtResiduiAttiviPrec";
			this.txtResiduiAttiviPrec.Size = new System.Drawing.Size(120, 20);
			this.txtResiduiAttiviPrec.TabIndex = 47;
			this.txtResiduiAttiviPrec.Tag = "surplus.supposedpreviousrevenue";
			this.txtResiduiAttiviPrec.Text = "";
			// 
			// txtFondoCassaPresunto3112
			// 
			this.txtFondoCassaPresunto3112.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtFondoCassaPresunto3112.Location = new System.Drawing.Point(296, 64);
			this.txtFondoCassaPresunto3112.Name = "txtFondoCassaPresunto3112";
			this.txtFondoCassaPresunto3112.ReadOnly = true;
			this.txtFondoCassaPresunto3112.Size = new System.Drawing.Size(120, 20);
			this.txtFondoCassaPresunto3112.TabIndex = 46;
			this.txtFondoCassaPresunto3112.TabStop = false;
			this.txtFondoCassaPresunto3112.Tag = "surplus.!fondocassapres3112";
			this.txtFondoCassaPresunto3112.Text = "";
			// 
			// labResAttiviAnno
			// 
			this.labResAttiviAnno.Location = new System.Drawing.Point(24, 160);
			this.labResAttiviAnno.Name = "labResAttiviAnno";
			this.labResAttiviAnno.Size = new System.Drawing.Size(264, 23);
			this.labResAttiviAnno.TabIndex = 45;
			this.labResAttiviAnno.Text = "Residui attivi presunti dell\'anno:";
			this.labResAttiviAnno.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labAttiviPresPrec
			// 
			this.labAttiviPresPrec.Location = new System.Drawing.Point(24, 112);
			this.labAttiviPresPrec.Name = "labAttiviPresPrec";
			this.labAttiviPresPrec.Size = new System.Drawing.Size(264, 23);
			this.labAttiviPresPrec.TabIndex = 44;
			this.labAttiviPresPrec.Text = "Residui attivi presunti degli anni precedenti:";
			this.labAttiviPresPrec.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labFCassaPresunto3112
			// 
			this.labFCassaPresunto3112.Location = new System.Drawing.Point(24, 64);
			this.labFCassaPresunto3112.Name = "labFCassaPresunto3112";
			this.labFCassaPresunto3112.Size = new System.Drawing.Size(264, 23);
			this.labFCassaPresunto3112.TabIndex = 43;
			this.labFCassaPresunto3112.Text = "Fondo di cassa presunto al 31/12:";
			this.labFCassaPresunto3112.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnRicalcola2
			// 
			this.btnRicalcola2.Location = new System.Drawing.Point(456, 16);
			this.btnRicalcola2.Name = "btnRicalcola2";
			this.btnRicalcola2.TabIndex = 42;
			this.btnRicalcola2.Text = "Ricalcola";
			this.btnRicalcola2.Click += new System.EventHandler(this.btnRicalcola2_Click);
			// 
			// txtDataAmmPresunta
			// 
			this.txtDataAmmPresunta.Location = new System.Drawing.Point(280, 16);
			this.txtDataAmmPresunta.Name = "txtDataAmmPresunta";
			this.txtDataAmmPresunta.ReadOnly = true;
			this.txtDataAmmPresunta.Size = new System.Drawing.Size(104, 20);
			this.txtDataAmmPresunta.TabIndex = 41;
			this.txtDataAmmPresunta.TabStop = false;
			this.txtDataAmmPresunta.Tag = "";
			this.txtDataAmmPresunta.Text = "";
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(240, 18);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(32, 16);
			this.label17.TabIndex = 40;
			this.label17.Text = "Data:";
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(48, 16);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(56, 16);
			this.label18.TabIndex = 39;
			this.label18.Text = "Esercizio:";
			// 
			// txtEsercizioAmmPresunta
			// 
			this.txtEsercizioAmmPresunta.Location = new System.Drawing.Point(104, 16);
			this.txtEsercizioAmmPresunta.Name = "txtEsercizioAmmPresunta";
			this.txtEsercizioAmmPresunta.ReadOnly = true;
			this.txtEsercizioAmmPresunta.Size = new System.Drawing.Size(77, 20);
			this.txtEsercizioAmmPresunta.TabIndex = 38;
			this.txtEsercizioAmmPresunta.TabStop = false;
			this.txtEsercizioAmmPresunta.Tag = "";
			this.txtEsercizioAmmPresunta.Text = "";
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.txtDescrPagamentiResidui);
			this.tabPage3.Controls.Add(this.txtDescrPagamentiCompetenza);
			this.tabPage3.Controls.Add(this.txtDescrIncassiResidui);
			this.tabPage3.Controls.Add(this.txtDescrIncassiCompetenza);
			this.tabPage3.Controls.Add(this.btnPagamentiResidui);
			this.tabPage3.Controls.Add(this.btnPagamentiCompetenza);
			this.tabPage3.Controls.Add(this.btnIncassiResidui);
			this.tabPage3.Controls.Add(this.btnIncassiCompetenza);
			this.tabPage3.Controls.Add(this.label53);
			this.tabPage3.Controls.Add(this.label54);
			this.tabPage3.Controls.Add(this.label57);
			this.tabPage3.Controls.Add(this.label60);
			this.tabPage3.Controls.Add(this.textBox18);
			this.tabPage3.Controls.Add(this.label19);
			this.tabPage3.Controls.Add(this.txtfondocassa3112);
			this.tabPage3.Controls.Add(this.txtPagamentiContoResidui);
			this.tabPage3.Controls.Add(this.txtPagamentiContoCompetenza);
			this.tabPage3.Controls.Add(this.textBox22);
			this.tabPage3.Controls.Add(this.labFondocassa3112);
			this.tabPage3.Controls.Add(this.label22);
			this.tabPage3.Controls.Add(this.label23);
			this.tabPage3.Controls.Add(this.label24);
			this.tabPage3.Controls.Add(this.txtIncassiContoResidui);
			this.tabPage3.Controls.Add(this.txtIncassiContoCompetenza);
			this.tabPage3.Controls.Add(this.txtFondoCassa0101bis);
			this.tabPage3.Controls.Add(this.label25);
			this.tabPage3.Controls.Add(this.label26);
			this.tabPage3.Controls.Add(this.labFondo1_1_bis);
			this.tabPage3.Controls.Add(this.btnRicalcola3);
			this.tabPage3.Controls.Add(this.label29);
			this.tabPage3.Controls.Add(this.txtEsercizioFinEffettiva);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(752, 406);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Finanziaria";
			// 
			// txtDescrPagamentiResidui
			// 
			this.txtDescrPagamentiResidui.Location = new System.Drawing.Point(400, 264);
			this.txtDescrPagamentiResidui.Multiline = true;
			this.txtDescrPagamentiResidui.Name = "txtDescrPagamentiResidui";
			this.txtDescrPagamentiResidui.ReadOnly = true;
			this.txtDescrPagamentiResidui.Size = new System.Drawing.Size(312, 24);
			this.txtDescrPagamentiResidui.TabIndex = 93;
			this.txtDescrPagamentiResidui.TabStop = false;
			this.txtDescrPagamentiResidui.Text = "Pagamenti trasmessi durante l\'anno su impegni residui";
			// 
			// txtDescrPagamentiCompetenza
			// 
			this.txtDescrPagamentiCompetenza.Location = new System.Drawing.Point(400, 224);
			this.txtDescrPagamentiCompetenza.Multiline = true;
			this.txtDescrPagamentiCompetenza.Name = "txtDescrPagamentiCompetenza";
			this.txtDescrPagamentiCompetenza.ReadOnly = true;
			this.txtDescrPagamentiCompetenza.Size = new System.Drawing.Size(312, 24);
			this.txtDescrPagamentiCompetenza.TabIndex = 92;
			this.txtDescrPagamentiCompetenza.TabStop = false;
			this.txtDescrPagamentiCompetenza.Text = "Pagamenti trasmessi durante l\'anno su impegni di competenza";
			// 
			// txtDescrIncassiResidui
			// 
			this.txtDescrIncassiResidui.Location = new System.Drawing.Point(400, 144);
			this.txtDescrIncassiResidui.Multiline = true;
			this.txtDescrIncassiResidui.Name = "txtDescrIncassiResidui";
			this.txtDescrIncassiResidui.ReadOnly = true;
			this.txtDescrIncassiResidui.Size = new System.Drawing.Size(312, 24);
			this.txtDescrIncassiResidui.TabIndex = 91;
			this.txtDescrIncassiResidui.TabStop = false;
			this.txtDescrIncassiResidui.Text = "Incassi trasmessi durante l\'anno su accertamenti residui";
			// 
			// txtDescrIncassiCompetenza
			// 
			this.txtDescrIncassiCompetenza.Location = new System.Drawing.Point(400, 104);
			this.txtDescrIncassiCompetenza.Multiline = true;
			this.txtDescrIncassiCompetenza.Name = "txtDescrIncassiCompetenza";
			this.txtDescrIncassiCompetenza.ReadOnly = true;
			this.txtDescrIncassiCompetenza.Size = new System.Drawing.Size(312, 24);
			this.txtDescrIncassiCompetenza.TabIndex = 90;
			this.txtDescrIncassiCompetenza.TabStop = false;
			this.txtDescrIncassiCompetenza.Text = "Incassi trasmessi durante l\'anno su accertamenti di competenza";
			// 
			// btnPagamentiResidui
			// 
			this.btnPagamentiResidui.Location = new System.Drawing.Point(360, 264);
			this.btnPagamentiResidui.Name = "btnPagamentiResidui";
			this.btnPagamentiResidui.Size = new System.Drawing.Size(32, 20);
			this.btnPagamentiResidui.TabIndex = 76;
			this.btnPagamentiResidui.Text = "F";
			this.btnPagamentiResidui.Click += new System.EventHandler(this.btnPagamentiResidui_Click);
			// 
			// btnPagamentiCompetenza
			// 
			this.btnPagamentiCompetenza.Location = new System.Drawing.Point(360, 224);
			this.btnPagamentiCompetenza.Name = "btnPagamentiCompetenza";
			this.btnPagamentiCompetenza.Size = new System.Drawing.Size(32, 20);
			this.btnPagamentiCompetenza.TabIndex = 74;
			this.btnPagamentiCompetenza.Text = "E";
			this.btnPagamentiCompetenza.Click += new System.EventHandler(this.btnPagamentiCompetenza_Click);
			// 
			// btnIncassiResidui
			// 
			this.btnIncassiResidui.Location = new System.Drawing.Point(360, 144);
			this.btnIncassiResidui.Name = "btnIncassiResidui";
			this.btnIncassiResidui.Size = new System.Drawing.Size(32, 20);
			this.btnIncassiResidui.TabIndex = 72;
			this.btnIncassiResidui.Text = "C";
			this.btnIncassiResidui.Click += new System.EventHandler(this.btnIncassiResidui_Click);
			// 
			// btnIncassiCompetenza
			// 
			this.btnIncassiCompetenza.Location = new System.Drawing.Point(360, 104);
			this.btnIncassiCompetenza.Name = "btnIncassiCompetenza";
			this.btnIncassiCompetenza.Size = new System.Drawing.Size(32, 20);
			this.btnIncassiCompetenza.TabIndex = 70;
			this.btnIncassiCompetenza.Text = "B";
			this.btnIncassiCompetenza.Click += new System.EventHandler(this.btnIncassiCompetenza_Click);
			// 
			// label53
			// 
			this.label53.Location = new System.Drawing.Point(352, 336);
			this.label53.Name = "label53";
			this.label53.Size = new System.Drawing.Size(72, 14);
			this.label53.TabIndex = 88;
			this.label53.Text = "H = A + D - G";
			this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label54
			// 
			this.label54.Location = new System.Drawing.Point(352, 296);
			this.label54.Name = "label54";
			this.label54.Size = new System.Drawing.Size(56, 23);
			this.label54.TabIndex = 87;
			this.label54.Text = "G = E + F";
			this.label54.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label57
			// 
			this.label57.Location = new System.Drawing.Point(352, 184);
			this.label57.Name = "label57";
			this.label57.Size = new System.Drawing.Size(56, 23);
			this.label57.TabIndex = 84;
			this.label57.Text = "D = B + C";
			this.label57.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label60
			// 
			this.label60.Location = new System.Drawing.Point(360, 64);
			this.label60.Name = "label60";
			this.label60.Size = new System.Drawing.Size(32, 23);
			this.label60.TabIndex = 81;
			this.label60.Text = "A";
			this.label60.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// textBox18
			// 
			this.textBox18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.textBox18.Location = new System.Drawing.Point(216, 296);
			this.textBox18.Name = "textBox18";
			this.textBox18.ReadOnly = true;
			this.textBox18.Size = new System.Drawing.Size(120, 20);
			this.textBox18.TabIndex = 80;
			this.textBox18.TabStop = false;
			this.textBox18.Tag = "surplus.!totpagamenti";
			this.textBox18.Text = "";
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(24, 296);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(184, 23);
			this.label19.TabIndex = 79;
			this.label19.Text = "Totale pagamenti:";
			this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtfondocassa3112
			// 
			this.txtfondocassa3112.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtfondocassa3112.Location = new System.Drawing.Point(216, 336);
			this.txtfondocassa3112.Name = "txtfondocassa3112";
			this.txtfondocassa3112.ReadOnly = true;
			this.txtfondocassa3112.Size = new System.Drawing.Size(120, 20);
			this.txtfondocassa3112.TabIndex = 78;
			this.txtfondocassa3112.TabStop = false;
			this.txtfondocassa3112.Tag = "surplus.!fondocassa3112";
			this.txtfondocassa3112.Text = "";
			// 
			// txtPagamentiContoResidui
			// 
			this.txtPagamentiContoResidui.Location = new System.Drawing.Point(216, 264);
			this.txtPagamentiContoResidui.Name = "txtPagamentiContoResidui";
			this.txtPagamentiContoResidui.Size = new System.Drawing.Size(120, 20);
			this.txtPagamentiContoResidui.TabIndex = 75;
			this.txtPagamentiContoResidui.Tag = "surplus.residualpayments";
			this.txtPagamentiContoResidui.Text = "";
			// 
			// txtPagamentiContoCompetenza
			// 
			this.txtPagamentiContoCompetenza.Location = new System.Drawing.Point(216, 224);
			this.txtPagamentiContoCompetenza.Name = "txtPagamentiContoCompetenza";
			this.txtPagamentiContoCompetenza.Size = new System.Drawing.Size(120, 20);
			this.txtPagamentiContoCompetenza.TabIndex = 73;
			this.txtPagamentiContoCompetenza.Tag = "surplus.competencypayments";
			this.txtPagamentiContoCompetenza.Text = "";
			// 
			// textBox22
			// 
			this.textBox22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.textBox22.Location = new System.Drawing.Point(216, 184);
			this.textBox22.Name = "textBox22";
			this.textBox22.ReadOnly = true;
			this.textBox22.Size = new System.Drawing.Size(120, 20);
			this.textBox22.TabIndex = 75;
			this.textBox22.TabStop = false;
			this.textBox22.Tag = "surplus.!totincassi";
			this.textBox22.Text = "";
			// 
			// labFondocassa3112
			// 
			this.labFondocassa3112.Location = new System.Drawing.Point(24, 336);
			this.labFondocassa3112.Name = "labFondocassa3112";
			this.labFondocassa3112.Size = new System.Drawing.Size(184, 23);
			this.labFondocassa3112.TabIndex = 74;
			this.labFondocassa3112.Text = "Fondo di cassa al 31/12:";
			this.labFondocassa3112.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(24, 264);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(184, 23);
			this.label22.TabIndex = 73;
			this.label22.Text = "Pagamenti in conto residui:";
			this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label23
			// 
			this.label23.Location = new System.Drawing.Point(24, 224);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(184, 23);
			this.label23.TabIndex = 72;
			this.label23.Text = "Pagamenti in conto competenza:";
			this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label24
			// 
			this.label24.Location = new System.Drawing.Point(24, 184);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(184, 23);
			this.label24.TabIndex = 71;
			this.label24.Text = "Totale incassi:";
			this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtIncassiContoResidui
			// 
			this.txtIncassiContoResidui.Location = new System.Drawing.Point(216, 144);
			this.txtIncassiContoResidui.Name = "txtIncassiContoResidui";
			this.txtIncassiContoResidui.Size = new System.Drawing.Size(120, 20);
			this.txtIncassiContoResidui.TabIndex = 71;
			this.txtIncassiContoResidui.Tag = "surplus.residualproceeds";
			this.txtIncassiContoResidui.Text = "";
			// 
			// txtIncassiContoCompetenza
			// 
			this.txtIncassiContoCompetenza.Location = new System.Drawing.Point(216, 104);
			this.txtIncassiContoCompetenza.Name = "txtIncassiContoCompetenza";
			this.txtIncassiContoCompetenza.Size = new System.Drawing.Size(120, 20);
			this.txtIncassiContoCompetenza.TabIndex = 69;
			this.txtIncassiContoCompetenza.Tag = "surplus.competencyproceeds";
			this.txtIncassiContoCompetenza.Text = "";
			// 
			// txtFondoCassa0101bis
			// 
			this.txtFondoCassa0101bis.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtFondoCassa0101bis.Location = new System.Drawing.Point(216, 64);
			this.txtFondoCassa0101bis.Name = "txtFondoCassa0101bis";
			this.txtFondoCassa0101bis.ReadOnly = true;
			this.txtFondoCassa0101bis.Size = new System.Drawing.Size(120, 20);
			this.txtFondoCassa0101bis.TabIndex = 68;
			this.txtFondoCassa0101bis.TabStop = false;
			this.txtFondoCassa0101bis.Tag = "surplus.startfloatfund";
			this.txtFondoCassa0101bis.Text = "";
			// 
			// label25
			// 
			this.label25.Location = new System.Drawing.Point(24, 144);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(184, 23);
			this.label25.TabIndex = 67;
			this.label25.Text = "Incassi in conto residui:";
			this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label26
			// 
			this.label26.Location = new System.Drawing.Point(24, 104);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(184, 23);
			this.label26.TabIndex = 66;
			this.label26.Text = "Incassi in conto competenza:";
			this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labFondo1_1_bis
			// 
			this.labFondo1_1_bis.Location = new System.Drawing.Point(24, 64);
			this.labFondo1_1_bis.Name = "labFondo1_1_bis";
			this.labFondo1_1_bis.Size = new System.Drawing.Size(184, 23);
			this.labFondo1_1_bis.TabIndex = 65;
			this.labFondo1_1_bis.Text = "Fondo di cassa al 1/1:";
			this.labFondo1_1_bis.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnRicalcola3
			// 
			this.btnRicalcola3.Location = new System.Drawing.Point(456, 16);
			this.btnRicalcola3.Name = "btnRicalcola3";
			this.btnRicalcola3.TabIndex = 64;
			this.btnRicalcola3.Text = "Ricalcola";
			this.btnRicalcola3.Click += new System.EventHandler(this.btnRicalcola3_Click);
			// 
			// label29
			// 
			this.label29.Location = new System.Drawing.Point(48, 16);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(57, 16);
			this.label29.TabIndex = 61;
			this.label29.Text = "Esercizio:";
			// 
			// txtEsercizioFinEffettiva
			// 
			this.txtEsercizioFinEffettiva.Location = new System.Drawing.Point(104, 16);
			this.txtEsercizioFinEffettiva.Name = "txtEsercizioFinEffettiva";
			this.txtEsercizioFinEffettiva.ReadOnly = true;
			this.txtEsercizioFinEffettiva.Size = new System.Drawing.Size(77, 20);
			this.txtEsercizioFinEffettiva.TabIndex = 60;
			this.txtEsercizioFinEffettiva.TabStop = false;
			this.txtEsercizioFinEffettiva.Tag = "";
			this.txtEsercizioFinEffettiva.Text = "";
			this.txtEsercizioFinEffettiva.TextChanged += new System.EventHandler(this.txtEsercizioFinEffettiva_TextChanged);
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.txtDescrResiduiPassiviCorrenti);
			this.tabPage4.Controls.Add(this.txtDescrResiduiPassiviPrecedenti);
			this.tabPage4.Controls.Add(this.txtDescrResiduiAttiviCorrenti);
			this.tabPage4.Controls.Add(this.txtDescrResiduiAttiviPrecedenti);
			this.tabPage4.Controls.Add(this.btnResiduiPassiviAtt);
			this.tabPage4.Controls.Add(this.btnResiduiPassiviPrec);
			this.tabPage4.Controls.Add(this.btnResiduiAttiviAtt);
			this.tabPage4.Controls.Add(this.btnResiduiAttiviPrec);
			this.tabPage4.Controls.Add(this.label61);
			this.tabPage4.Controls.Add(this.label62);
			this.tabPage4.Controls.Add(this.label65);
			this.tabPage4.Controls.Add(this.label68);
			this.tabPage4.Controls.Add(this.textBox26);
			this.tabPage4.Controls.Add(this.label28);
			this.tabPage4.Controls.Add(this.txtavanzoamm3112);
			this.tabPage4.Controls.Add(this.txtResiduiPassiviAnno);
			this.tabPage4.Controls.Add(this.txtResiduiPassiviPrecEff);
			this.tabPage4.Controls.Add(this.textBox31);
			this.tabPage4.Controls.Add(this.labAvaCassa3112);
			this.tabPage4.Controls.Add(this.labResPassiviAnnoBis);
			this.tabPage4.Controls.Add(this.labResPassiviPrec);
			this.tabPage4.Controls.Add(this.label33);
			this.tabPage4.Controls.Add(this.txtResiduiAttiviAnno);
			this.tabPage4.Controls.Add(this.txtResiduiAttiviPrecEff);
			this.tabPage4.Controls.Add(this.txtfondocassa3112bis);
			this.tabPage4.Controls.Add(this.labResAttiviAnnobis);
			this.tabPage4.Controls.Add(this.labResAttiviPrec);
			this.tabPage4.Controls.Add(this.labFcassa3112ter);
			this.tabPage4.Controls.Add(this.btnRicalcola4);
			this.tabPage4.Controls.Add(this.label37);
			this.tabPage4.Controls.Add(this.txtEsercizioAmmEffettiva);
			this.tabPage4.Location = new System.Drawing.Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new System.Drawing.Size(752, 406);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "Amministrativa";
			// 
			// txtDescrResiduiPassiviCorrenti
			// 
			this.txtDescrResiduiPassiviCorrenti.Location = new System.Drawing.Point(456, 264);
			this.txtDescrResiduiPassiviCorrenti.Multiline = true;
			this.txtDescrResiduiPassiviCorrenti.Name = "txtDescrResiduiPassiviCorrenti";
			this.txtDescrResiduiPassiviCorrenti.ReadOnly = true;
			this.txtDescrResiduiPassiviCorrenti.Size = new System.Drawing.Size(264, 32);
			this.txtDescrResiduiPassiviCorrenti.TabIndex = 112;
			this.txtDescrResiduiPassiviCorrenti.TabStop = false;
			this.txtDescrResiduiPassiviCorrenti.Text = "Impegni non Pagati o dei quali il pagamento non Ë stato ancora trasmesso";
			// 
			// txtDescrResiduiPassiviPrecedenti
			// 
			this.txtDescrResiduiPassiviPrecedenti.Location = new System.Drawing.Point(456, 224);
			this.txtDescrResiduiPassiviPrecedenti.Multiline = true;
			this.txtDescrResiduiPassiviPrecedenti.Name = "txtDescrResiduiPassiviPrecedenti";
			this.txtDescrResiduiPassiviPrecedenti.ReadOnly = true;
			this.txtDescrResiduiPassiviPrecedenti.Size = new System.Drawing.Size(264, 24);
			this.txtDescrResiduiPassiviPrecedenti.TabIndex = 111;
			this.txtDescrResiduiPassiviPrecedenti.TabStop = false;
			this.txtDescrResiduiPassiviPrecedenti.Text = "Residui Passivi Precedenti non Pagati nell\'anno";
			// 
			// txtDescrResiduiAttiviCorrenti
			// 
			this.txtDescrResiduiAttiviCorrenti.Location = new System.Drawing.Point(456, 144);
			this.txtDescrResiduiAttiviCorrenti.Multiline = true;
			this.txtDescrResiduiAttiviCorrenti.Name = "txtDescrResiduiAttiviCorrenti";
			this.txtDescrResiduiAttiviCorrenti.ReadOnly = true;
			this.txtDescrResiduiAttiviCorrenti.Size = new System.Drawing.Size(264, 32);
			this.txtDescrResiduiAttiviCorrenti.TabIndex = 110;
			this.txtDescrResiduiAttiviCorrenti.TabStop = false;
			this.txtDescrResiduiAttiviCorrenti.Text = "Accertamenti non Incassati o dei quali l\'incasso non Ë stato ancora trasmesso";
			// 
			// txtDescrResiduiAttiviPrecedenti
			// 
			this.txtDescrResiduiAttiviPrecedenti.Location = new System.Drawing.Point(456, 104);
			this.txtDescrResiduiAttiviPrecedenti.Multiline = true;
			this.txtDescrResiduiAttiviPrecedenti.Name = "txtDescrResiduiAttiviPrecedenti";
			this.txtDescrResiduiAttiviPrecedenti.ReadOnly = true;
			this.txtDescrResiduiAttiviPrecedenti.Size = new System.Drawing.Size(264, 24);
			this.txtDescrResiduiAttiviPrecedenti.TabIndex = 109;
			this.txtDescrResiduiAttiviPrecedenti.TabStop = false;
			this.txtDescrResiduiAttiviPrecedenti.Text = "Residui Attivi Precedenti non Incassati nell\'anno";
			// 
			// btnResiduiPassiviAtt
			// 
			this.btnResiduiPassiviAtt.Location = new System.Drawing.Point(416, 264);
			this.btnResiduiPassiviAtt.Name = "btnResiduiPassiviAtt";
			this.btnResiduiPassiviAtt.Size = new System.Drawing.Size(32, 20);
			this.btnResiduiPassiviAtt.TabIndex = 95;
			this.btnResiduiPassiviAtt.Text = "F";
			this.btnResiduiPassiviAtt.Click += new System.EventHandler(this.btnResiduiPassiviAtt_Click);
			// 
			// btnResiduiPassiviPrec
			// 
			this.btnResiduiPassiviPrec.Location = new System.Drawing.Point(416, 224);
			this.btnResiduiPassiviPrec.Name = "btnResiduiPassiviPrec";
			this.btnResiduiPassiviPrec.Size = new System.Drawing.Size(32, 20);
			this.btnResiduiPassiviPrec.TabIndex = 93;
			this.btnResiduiPassiviPrec.Text = "E";
			this.btnResiduiPassiviPrec.Click += new System.EventHandler(this.btnResiduiPassiviPrec_Click);
			// 
			// btnResiduiAttiviAtt
			// 
			this.btnResiduiAttiviAtt.Location = new System.Drawing.Point(416, 144);
			this.btnResiduiAttiviAtt.Name = "btnResiduiAttiviAtt";
			this.btnResiduiAttiviAtt.Size = new System.Drawing.Size(32, 20);
			this.btnResiduiAttiviAtt.TabIndex = 91;
			this.btnResiduiAttiviAtt.Text = "C";
			this.btnResiduiAttiviAtt.Click += new System.EventHandler(this.btnResiduiAttiviAtt_Click);
			// 
			// btnResiduiAttiviPrec
			// 
			this.btnResiduiAttiviPrec.Location = new System.Drawing.Point(416, 104);
			this.btnResiduiAttiviPrec.Name = "btnResiduiAttiviPrec";
			this.btnResiduiAttiviPrec.Size = new System.Drawing.Size(32, 20);
			this.btnResiduiAttiviPrec.TabIndex = 89;
			this.btnResiduiAttiviPrec.Text = "B";
			this.btnResiduiAttiviPrec.Click += new System.EventHandler(this.btnResiduiAttiviPrec_Click);
			// 
			// label61
			// 
			this.label61.Location = new System.Drawing.Point(408, 344);
			this.label61.Name = "label61";
			this.label61.Size = new System.Drawing.Size(72, 14);
			this.label61.TabIndex = 107;
			this.label61.Text = "H = A + D - G";
			this.label61.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label62
			// 
			this.label62.Location = new System.Drawing.Point(408, 304);
			this.label62.Name = "label62";
			this.label62.Size = new System.Drawing.Size(64, 23);
			this.label62.TabIndex = 106;
			this.label62.Text = "G = E + F";
			this.label62.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label65
			// 
			this.label65.Location = new System.Drawing.Point(408, 184);
			this.label65.Name = "label65";
			this.label65.Size = new System.Drawing.Size(64, 23);
			this.label65.TabIndex = 103;
			this.label65.Text = "D = B + C";
			this.label65.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label68
			// 
			this.label68.Location = new System.Drawing.Point(416, 64);
			this.label68.Name = "label68";
			this.label68.Size = new System.Drawing.Size(32, 23);
			this.label68.TabIndex = 100;
			this.label68.Text = "A";
			this.label68.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// textBox26
			// 
			this.textBox26.Location = new System.Drawing.Point(264, 304);
			this.textBox26.Name = "textBox26";
			this.textBox26.ReadOnly = true;
			this.textBox26.Size = new System.Drawing.Size(120, 20);
			this.textBox26.TabIndex = 99;
			this.textBox26.TabStop = false;
			this.textBox26.Tag = "surplus.!totrespassivi";
			this.textBox26.Text = "";
			// 
			// label28
			// 
			this.label28.Location = new System.Drawing.Point(24, 304);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(232, 23);
			this.label28.TabIndex = 98;
			this.label28.Text = "Totale residui passivi:";
			this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtavanzoamm3112
			// 
			this.txtavanzoamm3112.Location = new System.Drawing.Point(264, 344);
			this.txtavanzoamm3112.Name = "txtavanzoamm3112";
			this.txtavanzoamm3112.ReadOnly = true;
			this.txtavanzoamm3112.Size = new System.Drawing.Size(120, 20);
			this.txtavanzoamm3112.TabIndex = 97;
			this.txtavanzoamm3112.TabStop = false;
			this.txtavanzoamm3112.Tag = "surplus.!avanzoamm3112";
			this.txtavanzoamm3112.Text = "";
			// 
			// txtResiduiPassiviAnno
			// 
			this.txtResiduiPassiviAnno.Location = new System.Drawing.Point(264, 264);
			this.txtResiduiPassiviAnno.Name = "txtResiduiPassiviAnno";
			this.txtResiduiPassiviAnno.Size = new System.Drawing.Size(120, 20);
			this.txtResiduiPassiviAnno.TabIndex = 94;
			this.txtResiduiPassiviAnno.Tag = "surplus.currentexpenditure";
			this.txtResiduiPassiviAnno.Text = "";
			// 
			// txtResiduiPassiviPrecEff
			// 
			this.txtResiduiPassiviPrecEff.Location = new System.Drawing.Point(264, 224);
			this.txtResiduiPassiviPrecEff.Name = "txtResiduiPassiviPrecEff";
			this.txtResiduiPassiviPrecEff.Size = new System.Drawing.Size(120, 20);
			this.txtResiduiPassiviPrecEff.TabIndex = 92;
			this.txtResiduiPassiviPrecEff.Tag = "surplus.previousexpenditure";
			this.txtResiduiPassiviPrecEff.Text = "";
			// 
			// textBox31
			// 
			this.textBox31.Location = new System.Drawing.Point(264, 184);
			this.textBox31.Name = "textBox31";
			this.textBox31.ReadOnly = true;
			this.textBox31.Size = new System.Drawing.Size(120, 20);
			this.textBox31.TabIndex = 94;
			this.textBox31.TabStop = false;
			this.textBox31.Tag = "surplus.!totresattivi";
			this.textBox31.Text = "";
			// 
			// labAvaCassa3112
			// 
			this.labAvaCassa3112.Location = new System.Drawing.Point(24, 344);
			this.labAvaCassa3112.Name = "labAvaCassa3112";
			this.labAvaCassa3112.Size = new System.Drawing.Size(232, 23);
			this.labAvaCassa3112.TabIndex = 93;
			this.labAvaCassa3112.Text = "Avanzo di amministrazione al 31/12:";
			this.labAvaCassa3112.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labResPassiviAnnoBis
			// 
			this.labResPassiviAnnoBis.Location = new System.Drawing.Point(24, 264);
			this.labResPassiviAnnoBis.Name = "labResPassiviAnnoBis";
			this.labResPassiviAnnoBis.Size = new System.Drawing.Size(232, 23);
			this.labResPassiviAnnoBis.TabIndex = 92;
			this.labResPassiviAnnoBis.Text = "Residui passivi dell\'anno:";
			this.labResPassiviAnnoBis.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labResPassiviPrec
			// 
			this.labResPassiviPrec.Location = new System.Drawing.Point(24, 224);
			this.labResPassiviPrec.Name = "labResPassiviPrec";
			this.labResPassiviPrec.Size = new System.Drawing.Size(232, 23);
			this.labResPassiviPrec.TabIndex = 91;
			this.labResPassiviPrec.Text = "Residui passivi degli anni precedenti:";
			this.labResPassiviPrec.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label33
			// 
			this.label33.Location = new System.Drawing.Point(24, 184);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(232, 23);
			this.label33.TabIndex = 90;
			this.label33.Text = "Totale residui attivi:";
			this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtResiduiAttiviAnno
			// 
			this.txtResiduiAttiviAnno.Location = new System.Drawing.Point(264, 144);
			this.txtResiduiAttiviAnno.Name = "txtResiduiAttiviAnno";
			this.txtResiduiAttiviAnno.Size = new System.Drawing.Size(120, 20);
			this.txtResiduiAttiviAnno.TabIndex = 90;
			this.txtResiduiAttiviAnno.Tag = "surplus.currentrevenue";
			this.txtResiduiAttiviAnno.Text = "";
			// 
			// txtResiduiAttiviPrecEff
			// 
			this.txtResiduiAttiviPrecEff.Location = new System.Drawing.Point(264, 104);
			this.txtResiduiAttiviPrecEff.Name = "txtResiduiAttiviPrecEff";
			this.txtResiduiAttiviPrecEff.Size = new System.Drawing.Size(120, 20);
			this.txtResiduiAttiviPrecEff.TabIndex = 88;
			this.txtResiduiAttiviPrecEff.Tag = "surplus.previousrevenue";
			this.txtResiduiAttiviPrecEff.Text = "";
			// 
			// txtfondocassa3112bis
			// 
			this.txtfondocassa3112bis.Location = new System.Drawing.Point(264, 64);
			this.txtfondocassa3112bis.Name = "txtfondocassa3112bis";
			this.txtfondocassa3112bis.ReadOnly = true;
			this.txtfondocassa3112bis.Size = new System.Drawing.Size(120, 20);
			this.txtfondocassa3112bis.TabIndex = 87;
			this.txtfondocassa3112bis.TabStop = false;
			this.txtfondocassa3112bis.Tag = "surplus.!fondocassa3112";
			this.txtfondocassa3112bis.Text = "";
			// 
			// labResAttiviAnnobis
			// 
			this.labResAttiviAnnobis.Location = new System.Drawing.Point(24, 144);
			this.labResAttiviAnnobis.Name = "labResAttiviAnnobis";
			this.labResAttiviAnnobis.Size = new System.Drawing.Size(232, 23);
			this.labResAttiviAnnobis.TabIndex = 86;
			this.labResAttiviAnnobis.Text = "Residui attivi dell\'anno:";
			this.labResAttiviAnnobis.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labResAttiviPrec
			// 
			this.labResAttiviPrec.Location = new System.Drawing.Point(24, 104);
			this.labResAttiviPrec.Name = "labResAttiviPrec";
			this.labResAttiviPrec.Size = new System.Drawing.Size(232, 23);
			this.labResAttiviPrec.TabIndex = 85;
			this.labResAttiviPrec.Text = "Residui attivi degli anni precedenti:";
			this.labResAttiviPrec.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labFcassa3112ter
			// 
			this.labFcassa3112ter.Location = new System.Drawing.Point(24, 64);
			this.labFcassa3112ter.Name = "labFcassa3112ter";
			this.labFcassa3112ter.Size = new System.Drawing.Size(232, 23);
			this.labFcassa3112ter.TabIndex = 84;
			this.labFcassa3112ter.Text = "Fondo di cassa al 31/12:";
			this.labFcassa3112ter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnRicalcola4
			// 
			this.btnRicalcola4.Location = new System.Drawing.Point(456, 16);
			this.btnRicalcola4.Name = "btnRicalcola4";
			this.btnRicalcola4.TabIndex = 83;
			this.btnRicalcola4.Text = "Ricalcola";
			this.btnRicalcola4.Click += new System.EventHandler(this.btnRicalcola4_Click);
			// 
			// label37
			// 
			this.label37.Location = new System.Drawing.Point(48, 16);
			this.label37.Name = "label37";
			this.label37.Size = new System.Drawing.Size(57, 16);
			this.label37.TabIndex = 82;
			this.label37.Text = "Esercizio:";
			// 
			// txtEsercizioAmmEffettiva
			// 
			this.txtEsercizioAmmEffettiva.Location = new System.Drawing.Point(104, 16);
			this.txtEsercizioAmmEffettiva.Name = "txtEsercizioAmmEffettiva";
			this.txtEsercizioAmmEffettiva.ReadOnly = true;
			this.txtEsercizioAmmEffettiva.Size = new System.Drawing.Size(77, 20);
			this.txtEsercizioAmmEffettiva.TabIndex = 81;
			this.txtEsercizioAmmEffettiva.TabStop = false;
			this.txtEsercizioAmmEffettiva.Tag = "";
			this.txtEsercizioAmmEffettiva.Text = "";
			this.txtEsercizioAmmEffettiva.Leave += new System.EventHandler(this.txtEsercizioAmmEffettiva_Leave);
			// 
			// DS
			// 
			this.DS.DataSetName = "DS";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// Frm_surplus_default
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(770, 456);
			this.Controls.Add(this.tabControl1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Frm_surplus_default";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmSituazioneFinanziaria";
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		
		
		private void SetEvent() {
			foreach(Control C in this.tabControl1.Controls) {
				foreach(Control CC in C.Controls) {
					if (typeof(TextBox).IsAssignableFrom(CC.GetType())) {	
						((TextBox)CC).Leave += new System.EventHandler(this.TBoxLeave);
					}
				}
			}
		}

		private void TBoxLeave (object sender, System.EventArgs e) {
			Calcola(true);
		}

		private void Calcola(bool MustRefresh) {
			MetaData Meta = MetaData.GetMetaData(this);
			if (Meta.IsEmpty) return;

			//Leggo i dati dal Form
			if (MustRefresh) MetaData.GetFormData(this,true);
		
			DataRow R = DS.surplus.Rows[0];
			
			//fin. presunta
			R["!fondocassadata"] = CK(R["startfloatfund"]) + CK(R["proceedstilldate"]) - CK(R["paymentstilldate"]);
			
			R["!fondocassapres3112"] = CK(R["!fondocassadata"]) + CK(R["proceedstoendofyear"]) - CK(R["paymentstoendofyear"]);
			
			//amm.presunta
			R["!totresattivipres"] = CK(R["supposedpreviousrevenue"]) + CK(R["supposedcurrentrevenue"]);
			R["!totrespassivipres"] = CK(R["supposedpreviousexpenditure"]) + CK(R["supposedcurrentexpenditure"]);
			R["!avanzoammpres3112"] = CK(R["!fondocassapres3112"]) + CK(R["!totresattivipres"]) - CK(R["!totrespassivipres"]);

			//fin.effettiva
			R["!totincassi"] = CK(R["competencyproceeds"]) + CK(R["residualproceeds"]);
			R["!totpagamenti"] = CK(R["competencypayments"]) + CK(R["residualpayments"]);
			R["!fondocassa3112"] = CK(R["startfloatfund"]) + CK(R["!totincassi"]) - CK(R["!totpagamenti"]);

			//amm.effettiva
			R["!totresattivi"] = CK(R["previousrevenue"]) + CK(R["currentrevenue"]);
			R["!totrespassivi"] = CK(R["previousexpenditure"]) + CK(R["currentexpenditure"]);
			R["!avanzoamm3112"] = CK(R["!fondocassa3112"]) + CK(R["!totresattivi"]) - CK(R["!totrespassivi"]);
			
			//Aggiorna i dati nel form leggendoli dal dataset
			if (MustRefresh) MetaData.FreshForm(this,false);
			
		}


		private void btnRicalcola1_Click(object sender, System.EventArgs e) {
			if(txtDataAmmPresunta.Text=="") {	
				MessageBox.Show("E' necessario inserire la data");
				return;
			}
			if(txtEsercizio.Text=="") {	
				MessageBox.Show("E' necessario inserire l'esercizio");
				return;
			}
			DataAccess Conn = MetaData.GetConnection(this); 
			string MyFilter; 
			string VistaScelta; 
			string strExpr;
			int esercizioCurr = (int)Meta.GetSys("esercizio");
			int esercizioPrec = esercizioCurr - 1;

			decimal fondocassa0101;
            fondocassa0101 = CfgFn.GetNoNullDecimal(DS.surplus.Rows[0]["startfloatfund"]);
			
			decimal incassi0101;
			MyFilter = CreaFiltro_Incassi_Pagamenti("incassi",null);
			strExpr  = "ISNULL(SUM(curramount),0)";
			VistaScelta = ScegliVista("proceeds");
			incassi0101 = CK(Conn.DO_READ_VALUE(VistaScelta,MyFilter,strExpr));
			
			decimal pagamenti0101;
			MyFilter = CreaFiltro_Incassi_Pagamenti("pagamenti",null);
			VistaScelta = ScegliVista("payment");
			pagamenti0101 =  CK(Conn.DO_READ_VALUE(VistaScelta,MyFilter,strExpr));
			

			decimal incassidata;
			MyFilter = CreaFiltro_Fasi_Miste("E");
			strExpr  = "ISNULL(SUM(curramount),0) + ISNULL(SUM(available),0)";
			incassidata = CK(Conn.DO_READ_VALUE("proceedssupposed",MyFilter,strExpr));
			
			decimal pagamentidata;
			MyFilter = CreaFiltro_Fasi_Miste("S");
			pagamentidata = CK(Conn.DO_READ_VALUE("paymentsupposed",MyFilter,strExpr));

			if(MetaData.Empty(this) == true) {
				txtfondocassa0101.Text = fondocassa0101.ToString("C");
				txtincassi0101.Text = incassi0101.ToString("C");
				txtpagamenti0101.Text = pagamenti0101.ToString("C");
				txtincassidata.Text = incassidata.ToString("C");
				txtpagamentidata.Text = pagamentidata.ToString("C");
			
				decimal fondocassadata = fondocassa0101 +  incassi0101 - pagamenti0101;
				textBox4.Text = fondocassadata.ToString("C");

				decimal fondocassapres3112 = fondocassadata + incassidata - pagamentidata;
				txtFondopresuntoal3112.Text = fondocassapres3112.ToString("C");
				txtFondoCassaPresunto3112.Text = fondocassapres3112.ToString("C");
				txtFondoCassa0101bis.Text = fondocassa0101.ToString("C");
				txtfondocassa3112.Text = fondocassa0101.ToString("C");
				txtfondocassa3112bis.Text = fondocassa0101.ToString("C");
				txtavanzoamm3112.Text = fondocassa0101.ToString("C");
			}
			else {
				DataRow R =  DS.surplus.Rows[0];
                //R["startfloatfund"] = fondocassa0101;
				R["proceedstilldate"] = incassi0101;
				R["paymentstilldate"] = pagamenti0101;
				R["proceedstoendofyear"] = incassidata;
				R["paymentstoendofyear"] = pagamentidata;
				//Aggiorna i dati nel form leggendoli dal dataset
				MetaData.FreshForm(this,false);
			}
			
		}
		
		private void btnRicalcola2_Click(object sender, System.EventArgs e) {
			if(txtDataAmmPresunta.Text=="") {	
				MessageBox.Show("E' necessario inserire la data");
				return;
			}
			if(txtEsercizio.Text=="") {	
				MessageBox.Show("E' necessario inserire l'esercizio");
				return;
			}

			DataAccess Conn = MetaData.GetConnection(this);
			string MyFilter; 
			string strExpr;

			decimal ResiduiAttiviPrec;
			MyFilter = CreaFiltro_Residui_Attivi_Passivi("R","P");
			strExpr  = "SUM(ISNULL(residualamount,0))";
			ResiduiAttiviPrec = CK(Conn.DO_READ_VALUE("revenuearrearssupposed",MyFilter,strExpr));
			
			decimal ResiduiAttiviPresunti;
			MyFilter = CreaFiltro_Residui_Attivi_Passivi("C","P");
			ResiduiAttiviPresunti = CK(Conn.DO_READ_VALUE("revenuearrearssupposed",MyFilter,strExpr));
           
			decimal ResiduiPassiviPrec;
			MyFilter = CreaFiltro_Residui_Attivi_Passivi("R","P");
			ResiduiPassiviPrec = CK(Conn.DO_READ_VALUE("expenditurearrearssupposed",MyFilter,strExpr));
      

			decimal ResiduiPassiviPresunti;
			MyFilter = CreaFiltro_Residui_Attivi_Passivi("C","P");
			ResiduiPassiviPresunti = CK(Conn.DO_READ_VALUE("expenditurearrearssupposed",MyFilter,strExpr));
      

			if(MetaData.Empty(this)) {
				
				decimal avanzoammpres3112 = (decimal)HelpForm.GetObjectFromString(
					typeof(decimal),txtFondoCassaPresunto3112.Text
					,"x.y");
				txtavammpres3112.Text = avanzoammpres3112.ToString("C");
				txtResiduiAttiviPrec.Text = (0.0).ToString("C");
				txtResiduiAttiviPresunti.Text = (0.0).ToString("C");
				txtResiduiPassiviPrec.Text = (0.0).ToString("C");
				txtResiduiPassiviPresunti.Text = (0.0).ToString("C");
				txttotrespasspres.Text = (0.0).ToString("C");
				txtTotaleResiduiAttiviPres.Text = (0.0).ToString("C");
				
			}
			else {
				DataRow R = DS.surplus.Rows[0];
			
				R["supposedpreviousrevenue"] = ResiduiAttiviPrec;
				R["supposedpreviousexpenditure"] = ResiduiPassiviPrec;
				R["supposedcurrentrevenue"] = ResiduiAttiviPresunti;
				R["supposedcurrentexpenditure"] = ResiduiPassiviPresunti;
				
				//Aggiorna i dati nel form leggendoli dal dataset
				MetaData.FreshForm(this,false);
			}
		}
		public void MetaData_BeforeFill() {
			Calcola(false);
		}
		
		public void MetaData_AfterFill() {
			if ((txtData.Text == "") && (Convert.ToInt32(Meta.ExtraParameter) == 1)) {
				MessageBox.Show("E' necessario inserire una data");
				txtData.Focus();
			}
		}

		public void MetaData_AfterClear() {
			if (CanGoInsert) {
				CanGoInsert = false;
				MetaData.DoMainCommand(this, "maininsert");
			}
			if (CanGoEdit) {
				CanGoEdit = false;
				MetaData.DoMainCommand(this, "maindosearch.situazioneammin.ayear = " + QueryCreator.quotedstrvalue(Meta.GetSys("esercizio"),true));
			}
			// Imposto il flag a true in modo che se cancello la riga della situazione amministrativa vado direttamente in fase di inserimento
			CanGoInsert = true;
		}

        CQueryHelper QHC;
        QueryHelper QHS;
		public void MetaData_AfterLink(){
			Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
			filteresercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
			
			// Gestione delle icone sulla barra degli strumenti
			// Non devo mai poter inserire una copia della situazione amministrativa e mai poter ricercare
			Meta.CanInsertCopy = false;
			Meta.SearchEnabled = false;
			Meta.CanInsert = false;

			int numrighesitammin = Meta.Conn.RUN_SELECT_COUNT("surplus",filteresercizio,
				true);
			if (numrighesitammin==1) {
				CanGoInsert=false;
				CanGoEdit=true;

			}
			else {
				CanGoInsert=true;
				CanGoEdit=false;
			}
            IsAdmin=false;
			if (Meta.GetSys("manage_prestazioni")!=null) 
				IsAdmin = (Meta.GetSys("manage_prestazioni").ToString()=="S");
            txtFondoCassa0101bis.ReadOnly = !IsAdmin;
		}

		private void btnRicalcola3_Click(object sender, System.EventArgs e) {
			if(MetaData.Empty(this) == true) return;
			
			DataAccess Conn = MetaData.GetConnection(this);
			txtEsercizio.Text = txtEsercizioFinEffettiva.Text;
			string MyFilter; 
			string strExpr;

			decimal IncassiContoCompetenza;
			MyFilter = CreaFiltro_Incassi_Pagamenti("incassi","C");
			strExpr  = "SUM(ISNULL(curramount,0))";
			IncassiContoCompetenza = CK(Conn.DO_READ_VALUE("proceedscommunicated",MyFilter,strExpr));
		
			decimal IncassiContoResidui;
			MyFilter = CreaFiltro_Incassi_Pagamenti("incassi","R");
			IncassiContoResidui = CK(Conn.DO_READ_VALUE("proceedscommunicated",MyFilter,strExpr));
		
			decimal PagamentiContoCompetenza;
			MyFilter = CreaFiltro_Incassi_Pagamenti("pagamenti","C");
			PagamentiContoCompetenza = CK(Conn.DO_READ_VALUE("paymentcommunicated",MyFilter,strExpr));
			
			decimal PagamentiContoResidui;
			MyFilter = CreaFiltro_Incassi_Pagamenti("pagamenti","R");
			PagamentiContoResidui = CK(Conn.DO_READ_VALUE("paymentcommunicated",MyFilter,strExpr));
		

			DataRow R = DS.surplus.Rows[0];
			
			R["competencyproceeds"] = IncassiContoCompetenza;
			R["competencypayments"] = PagamentiContoCompetenza; ;
			R["residualproceeds"]   = IncassiContoResidui;
			R["residualpayments"]   = PagamentiContoResidui;
			
			//Aggiorna i dati nel form leggendoli dal dataset
			MetaData.FreshForm(this,false);
			
		}

		private void btnRicalcola4_Click(object sender, System.EventArgs e) {
			if(MetaData.Empty(this) == true) return;
			txtEsercizio.Text = txtEsercizioAmmEffettiva.Text;

			DataAccess Conn = MetaData.GetConnection(this);
			string MyFilter; 
			string strExpr;

			decimal ResiduiAttiviPrecEff;
			MyFilter = CreaFiltro_Residui_Attivi_Passivi("R","E");
			strExpr  = "SUM(ISNULL(residualamount,0))";
			ResiduiAttiviPrecEff = CK(Conn.DO_READ_VALUE("revenuearrears",MyFilter,strExpr));

			MyFilter = CreaFiltro_Residui_Attivi_Passivi("C", "E");
			decimal ResiduiAttiviAnno = 0;
			//decimal ResiduiAttiviAnno = CK(Conn.DO_READ_VALUE("revenuearrears", MyFilter, strExpr)); 
			string query = "SELECT SUM(residualamount) FROM revenuearrears  "
						  + " WHERE " + MyFilter;

			ResiduiAttiviAnno = CfgFn.GetNoNullDecimal(Conn.DO_SYS_CMD(query));


			decimal ResiduiPassiviPrecEff;
			MyFilter = CreaFiltro_Residui_Attivi_Passivi("R","E");	
			ResiduiPassiviPrecEff = CK(Conn.DO_READ_VALUE("expenditurearrears",MyFilter,strExpr));
			
			decimal ResiduiPassiviAnno;
			MyFilter = CreaFiltro_Residui_Attivi_Passivi("C","E");
			ResiduiPassiviAnno = CK(Conn.DO_READ_VALUE("expenditurearrears",MyFilter,strExpr));

			DataRow R =  DS.surplus.Rows[0];
			
			R["previousrevenue"] = ResiduiAttiviPrecEff;
			R["previousexpenditure"] = ResiduiPassiviPrecEff;
			R["currentrevenue"] = ResiduiAttiviAnno;
			R["currentexpenditure"] = ResiduiPassiviAnno;
			//Aggiorna i dati nel form leggendoli dal dataset
			MetaData.FreshForm(this,false);

		}
		
		private Decimal CK(Object O) {
			try {
				return Convert.ToDecimal(O);
			}
			catch {
				return 0;
			}
		}
		
		private void message() {
			MessageBox.Show("Non Ë stato possibile eseguire la stored procedure! - Dati non sufficienti");
		}


		/// <summary>
		/// Imposta i Tab da visualizzare leggendo 
		/// il campo tipoprevprincipale dalla tabella persbilancio.
		/// </summary>
		public void MetaData_BeforeActivation() {
			DataAccess Conn = MetaData.GetConnection(this);
			if (Conn==null) return;
			GetData.CacheTable(DS.config);
			
			string SqlFilter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
			GetData.SetStaticFilter(DS.config, SqlFilter);
			
			MetaData M = MetaData.GetMetaData(this);
			M.myGetData.ReadCached();
			
			if (DS.config.Rows.Count==0) return;
			DataRow rConfig = DS.config.Rows[0];

			// Fine Modica
			//if (R == null) return;

			// Calcolo della fase assimilabile all'accertamento e all'impegno
			faseaccertamento = rConfig["assessmentphasecode"].ToString();
			faseimpegno = rConfig["appropriationphasecode"].ToString();
			flagvaliditadoc = rConfig["cashvaliditykind"].ToString();

            int finkind = CfgFn.GetNoNullInt32(Conn.GetSys("fin_kind"));

			if ((finkind & 1)==0) {
				tabControl1.Controls.Remove(tabPage2);
				tabControl1.Controls.Remove(tabPage4);
			}
			if ((Meta.ExtraParameter != null)&&(Meta.ExtraParameter!=DBNull.Value)
				&& ((string)Meta.ExtraParameter!="")) {
				presunta_effettiva = CfgFn.GetNoNullInt32(Meta.ExtraParameter);
				if (presunta_effettiva == 1) {
					// Scelgo la situazione Presunta
					Meta.Name = "Situazione Finanziaria/Amministrativa Presunta";
					tabControl1.Controls.Remove(tabPage3);
					tabControl1.Controls.Remove(tabPage4);
					tabControl1.SelectedTab=tabPage1;
					txtEsercizioAmmPresunta.Text = Meta.GetSys("esercizio").ToString();
				}
				else {
					// Scelgo la situazione Effettiva
					Meta.Name = "Situazione Finanziaria/Amministrativa Effettiva";
					tabControl1.Controls.Remove(tabPage1);
					tabControl1.Controls.Remove(tabPage2);
					tabControl1.SelectedTab=tabPage3;
					txtEsercizioFinEffettiva.Text = Meta.GetSys("esercizio").ToString();
					txtEsercizioAmmEffettiva.Text = Meta.GetSys("esercizio").ToString();
				}
			}




		}

		private void txtEsercizioFinEffettiva_TextChanged(object sender, System.EventArgs e) {
			txtDescrIncassiCompetenza.Text = "Incassi trasmessi durante il " + Meta.GetSys("esercizio").ToString() + " su accertamenti di competenza";
			txtDescrIncassiResidui.Text = "Incassi trasmessi durante il " + Meta.GetSys("esercizio").ToString() + " su accertamenti residui";
			txtDescrPagamentiCompetenza.Text = "Pagamenti trasmessi durante il " + Meta.GetSys("esercizio").ToString() + " su impegni di competenza";
			txtDescrPagamentiResidui.Text = "Pagamenti trasmessi durante il " + Meta.GetSys("esercizio").ToString() + " su impegni residui";
		}

		/*		private void txtEsercizio_TextChanged(object sender, System.EventArgs e) {
					string S;
					if (Convert.ToInt16(Meta.ExtraParameter)==1)
					{
						S = txtEsercizio.Text;
						//txtEsercizioAmmEffettiva.Text= S;
						txtEsercizioAmmPresunta.Text=S;
						//txtEsercizioFinEffettiva.Text=S;
					}
					else
					{
						S = Meta.GetSys("esercizio").ToString();
						txtEsercizioAmmEffettiva.Text= S;
						txtEsercizioFinEffettiva.Text=S;
					}

				}*/

		private void txtData_TextChanged(object sender, System.EventArgs e) {
			txtDataAmmPresunta.Text= txtData.Text;
			object myd = HelpForm.GetObjectFromString(
				typeof(DateTime),
				txtData.Text, 
				"x.y");
			DateTime ddd;
			try {
				ddd = Convert.ToDateTime(myd);
			}
			catch{
				return;
			}
			string dd = ddd.Day.ToString() + "/" + ddd.Month.ToString()+"/"+ddd.Year.ToString();
			labFondo1_1.Text = "Fondo cassa al 1/1/"+ddd.Year.ToString();
			labIncassiData.Text = "Incassi dal 1/1/"+ddd.Year.ToString()+" al "+dd+":";
			labPagamentiData.Text = "Pagamenti dal 1/1/"+ddd.Year.ToString()+" al "+dd+":";
			labFondiCassaData.Text = "Fondo di cassa al "+dd+":";
			labIncassiPresuntiData.Text = "Incassi presunti dal "+dd+" al 31/12/"+ddd.Year.ToString()+":";
			labPagamentiPresuntiData.Text= "Pagamenti presunti dal "+dd+" al 31/12/"+ddd.Year.ToString()+":";
			FCassaPres3112.Text = "Fondo di cassa presunto al 31/12/"+ddd.Year.ToString()+":";
			labFCassaPresunto3112.Text="Fondo di cassa presunto al 31/12/"+ddd.Year.ToString()+":";
			labAttiviPresPrec.Text= "Residui attivi presunti degli anni precedenti il "+ddd.Year.ToString()+":";
			labResAttiviAnno.Text = "Residui attivi presunti del "+ddd.Year.ToString();
			labResPassPrec.Text= "Residui passivi presunti degli anni precedenti il "+ddd.Year.ToString();
			labResPassiviAnno.Text = "Residui passivi presunti del "+ddd.Year.ToString()+":";
			txtAvaCassPres3112.Text = "Avanzo di amministrazione presunto al 31/12/"+ddd.Year.ToString()+":";
			labFondo1_1_bis.Text= "Fondo di cassa al 1/1/"+ddd.Year.ToString()+":";
			labFondocassa3112.Text= "Fondo di cassa al 31/12/"+ddd.Year.ToString()+":";
			labFcassa3112ter.Text= "Fondo di cassa al 31/12/"+ddd.Year.ToString()+":";
			labResAttiviPrec.Text = "Residui attivi degli anni precedenti il "+ddd.Year.ToString()+":";
			labResAttiviAnnobis.Text=  "Residui attivi dell'anno "+ddd.Year.ToString()+":";
			labResPassiviPrec.Text=  "Residui passivi degli anni precedenti il "+ddd.Year.ToString()+":";
			labResPassiviAnnoBis.Text= "Residui passivi dell'anno "+ddd.Year.ToString()+":";
			labAvaCassa3112.Text = "Avanzo di amministrazione al 31/12/"+ddd.Year.ToString()+":";
			// Modifica delle text box al cambio della data
			txtDescrIncassi0101Data.Text = DescrizioneConfBilancio("E") + " nel " + ddd.Year.ToString();
			txtDescrPagamenti0101Data.Text = DescrizioneConfBilancio("S") + " nel " + ddd.Year.ToString();
			txtDescrIncassiPresunti.Text = "Incassi Trasmessi dopo il " + ddd.Day.ToString() + "/" + ddd.Month.ToString() + "/" + ddd.Year.ToString() + " e comunque entro l'anno" 
				+ " + Incassi non inseriti in reversale + Incassi non Trasmessi + Accertamenti che scadono entro il 31/12/" + ddd.Year.ToString() + " o di cui la data di scadenza non Ë specificata";
			txtDescrPagamentiPresunti.Text = "Pagamenti Trasmessi dopo il " + ddd.Day.ToString() + "/" + ddd.Month.ToString() + "/" + ddd.Year.ToString() + " e comunque entro l'anno" 
				+ " + Pagamenti non inseriti in mandato + Pagamenti non Trasmessi + Impegni che scadono entro il 31/12/" + ddd.Year.ToString() + " o di cui la data di scadenza non Ë specificata";
			txtDescrIncassiCompetenza.Text = "Incassi trasmessi durante il " + ddd.Year.ToString() + " su accertamenti di competenza";
			txtDescrPagamentiCompetenza.Text = "Pagamenti trasmessi durante il " + ddd.Year.ToString() + " su impegni di competenza";
			txtDescrIncassiResidui.Text = "Incassi trasmessi durante il " + ddd.Year.ToString() + " su accertamenti residui";
			txtDescrPagamentiResidui.Text = "Pagamenti trasmessi durante il " + ddd.Year.ToString() + " su impegni residui";
			txtDescrFondoCassaPresunto3112.Text = "Fondo di Cassa Iniziale + Incassi calcolati al " + ddd.Day.ToString() + "/" + ddd.Month.ToString() + "/" + ddd.Year.ToString()
				+ " - Pagamenti calcolati al " + ddd.Day.ToString() + "/" + ddd.Month.ToString() + "/" + ddd.Year.ToString();
			txtDescrResiduiAttiviPresuntiPrecedenti.Text = "Residui Attivi Precedenti non incassati nel " + ddd.Year.ToString() + " e che hanno scadenza oltre il 31/12/" + ddd.Year.ToString();
			txtDescrResiduiPassiviPresuntiPrecedenti.Text = "Residui Passivi Precedenti non pagati nel " + ddd.Year.ToString() + " e che hanno scadenza oltre il 31/12/" + ddd.Year.ToString();
			txtDescrResiduiAttiviPresuntiCorrenti.Text = "Accertamenti non incassati nel " + ddd.Year.ToString() + " e che hanno scadenza oltre il 31/12/" + ddd.Year.ToString() ;
			txtDescrResiduiPassiviPresuntiCorrenti.Text = "Impegni non pagati nel " + ddd.Year.ToString() + " e che hanno scadenza oltre il 31/12/" + ddd.Year.ToString() ;
			if (txtData.Text=="") MessageBox.Show("Inserire la data di riferimento della situazione");
		}

		// Il parametro entrata_spesa puÚ assumere i valori 
		// "E" : Entrata - "S" : Spesa
		private string DescrizioneConfBilancio(string entrata_spesa) {
			string descrizione;
			if (entrata_spesa == "E") {
				descrizione = "Sono considerati tutti gli incassi per i quali la reversale Ë ";
				switch(flagvaliditadoc) {
					case "1" : 
						descrizione += "stata emessa";
						break;
					case "2" :
						descrizione += "stata stampata";
						break;
					case "3" :
						descrizione += "stata trasmessa";
						break;
					case "4" :
						descrizione += "stata esitata";
						break;
				}
			}
			else {
				descrizione = "Sono considerati tutti i pagamenti per i quali il mandato Ë ";
				switch(flagvaliditadoc) {
					case "1" : 
						descrizione += "stato emesso";
						break;
					case "2" :
						descrizione += "stato stampato";
						break;
					case "3" :
						descrizione += "stato trasmesso";
						break;
					case "4" :
						descrizione += "stato esitato";
						break;
				}
			}
			return descrizione;
		}

		private void txtfondocassa0101_TextChanged(object sender, System.EventArgs e) {
			txtFondoCassa0101bis.Text= txtfondocassa0101.Text;
		}

		private void txtEsercizio_Leave(object sender, System.EventArgs e) {
			if (Meta==null)return;
			if (!Meta.DrawStateIsDone) return;
			Calcola(true);
		}

		private void textBox4_TextChanged(object sender, System.EventArgs e) {
		
		}

		// Bottoni presenti sul TAB Fin. Presunta
		private void btnIncassi0101Data_Click(object sender, System.EventArgs e) {
			DataAccess Conn = MetaData.GetConnection(this);
			string MyFilter;
			string VistaScelta;

			MyFilter = CreaFiltro_Incassi_Pagamenti("incassi",null);
			VistaScelta = ScegliVista("proceeds");

			if (VistaScelta != "") {
				MetaData MIncassi = MetaData.GetMetaData(this,VistaScelta);
				MIncassi.FilterLocked = true;
				MIncassi.DS = DS;
				DataRow MyDR = MIncassi.SelectOne("default",MyFilter,null,null);
				
				if(MyDR != null) {
					SelezionaMovimento(MyDR,"E");
				}
								
			}
			else {
				MessageBox.Show("E' Necessario inserire l'esercizio");
			}

		}

		private void btnPagamenti0101Data_Click(object sender, System.EventArgs e) {
			DataAccess Conn = MetaData.GetConnection(this);
			string MyFilter;
			string VistaScelta;

			MyFilter = CreaFiltro_Incassi_Pagamenti("pagamenti",null);
			VistaScelta = ScegliVista("payment");

			if (VistaScelta != "") {
				MetaData MPagamenti = MetaData.GetMetaData(this,VistaScelta);
				MPagamenti.FilterLocked = true;
				MPagamenti.DS = DS;
				DataRow MyDR = MPagamenti.SelectOne("default",MyFilter,null,null);

				if(MyDR != null) {
					SelezionaMovimento(MyDR,"S");
				}
			}
			else {
				MessageBox.Show("E' necessario inserire l'esercizio");
			}
		}	

		private void btnIncassiPresunti3112_Click(object sender, System.EventArgs e) {
			DataAccess Conn = MetaData.GetConnection(this);
			string MyFilter;
						
			MyFilter = CreaFiltro_Fasi_Miste("E");
			
			MetaData MIncassi = MetaData.GetMetaData(this,"proceedssupposed");
			MIncassi.FilterLocked = true;
			MIncassi.DS = DS;
			DataRow MyDR = MIncassi.SelectOne("default",MyFilter,null,null);

			if(MyDR != null) {
				SelezionaMovimento(MyDR,"E");
			}
		}

		private void btnPagamentiPresunti3112_Click(object sender, System.EventArgs e) {
			DataAccess Conn = MetaData.GetConnection(this);
			string MyFilter;
						
			MyFilter = CreaFiltro_Fasi_Miste("S");
			
			MetaData MPagamenti = MetaData.GetMetaData(this,"paymentsupposed");
			MPagamenti.FilterLocked = true;
			MPagamenti.DS = DS;
			DataRow MyDR = MPagamenti.SelectOne("default",MyFilter,null,null);

			if(MyDR != null) {
				SelezionaMovimento(MyDR,"S");
			}
		}

		// Bottoni presenti sul TAB Ammin. Presunta
		private void btnResiduiAttiviPresuntiPrec_Click(object sender, System.EventArgs e) {
			DataAccess Conn = MetaData.GetConnection(this);
			string MyFilter;
			
			MyFilter = CreaFiltro_Residui_Attivi_Passivi("R","P");
			MetaData MResiduiAttPresPrec = MetaData.GetMetaData(this,"revenuearrearssupposed");
			MResiduiAttPresPrec.FilterLocked = true;
			MResiduiAttPresPrec.DS = DS;
			DataRow MyDR = MResiduiAttPresPrec.SelectOne("default",MyFilter,null,null);
			
			if(MyDR != null) {
				SelezionaMovimento(MyDR,"E");
			}
		
		}

		private void btnResiduiAttiviPresuntiAtt_Click(object sender, System.EventArgs e) {
			DataAccess Conn = MetaData.GetConnection(this);
			string MyFilter;

			MyFilter = CreaFiltro_Residui_Attivi_Passivi("C","P");
			MetaData MResiduiAttPresAtt = MetaData.GetMetaData(this,"revenuearrearssupposed");
			MResiduiAttPresAtt.FilterLocked = true;
			MResiduiAttPresAtt.DS = DS;
			DataRow MyDR = MResiduiAttPresAtt.SelectOne("default",MyFilter,null,null);
			
			if(MyDR != null) {
				SelezionaMovimento(MyDR,"E");
			}
		
		}

		private void btnResiduiPassiviPresuntiPrec_Click(object sender, System.EventArgs e) {
			DataAccess Conn = MetaData.GetConnection(this);
			string MyFilter;

			MyFilter = CreaFiltro_Residui_Attivi_Passivi("R","P");
			MetaData MResiduiPassPresPrec = MetaData.GetMetaData(this,"expenditurearrearssupposed");
			MResiduiPassPresPrec.FilterLocked = true;
			MResiduiPassPresPrec.DS = DS;
			DataRow MyDR = MResiduiPassPresPrec.SelectOne("default",MyFilter,null,null);
			
			if(MyDR != null) {
				SelezionaMovimento(MyDR,"S");
			}
		}

		private void btnResiduiPassiviPresuntiAtt_Click(object sender, System.EventArgs e) {
			DataAccess Conn = MetaData.GetConnection(this);
			string MyFilter;
			
			MyFilter = CreaFiltro_Residui_Attivi_Passivi("C","P");
			MetaData MResiduiPassPresAtt = MetaData.GetMetaData(this,"expenditurearrearssupposed");
			MResiduiPassPresAtt.FilterLocked = true;
			MResiduiPassPresAtt.DS = DS;
			DataRow MyDR = MResiduiPassPresAtt.SelectOne("default",MyFilter,null,null);
			
			if(MyDR != null) {
				SelezionaMovimento(MyDR,"S");
			}		
		}

		// Bottoni presenti sul TAB Fin. Effettiva
		private void btnIncassiCompetenza_Click(object sender, System.EventArgs e) {
			DataAccess Conn = MetaData.GetConnection(this);
			string MyFilter;
			
			MyFilter = CreaFiltro_Incassi_Pagamenti("incassi","C");
			MetaData MIncassiComp = MetaData.GetMetaData(this,"proceedscommunicated");
			MIncassiComp.FilterLocked = true;
			MIncassiComp.DS = DS;
			DataRow MyDR = MIncassiComp.SelectOne("default",MyFilter,null,null);

			if(MyDR != null) {
				SelezionaMovimento(MyDR,"E");
			}
		}

		private void btnIncassiResidui_Click(object sender, System.EventArgs e) {
			DataAccess Conn = MetaData.GetConnection(this);
			string MyFilter;
			
			MyFilter = CreaFiltro_Incassi_Pagamenti("incassi","R");
			MetaData MIncassiComp = MetaData.GetMetaData(this,"proceedscommunicated");
			MIncassiComp.FilterLocked = true;
			MIncassiComp.DS = DS;
			DataRow MyDR = MIncassiComp.SelectOne("default",MyFilter,null,null);
			
			if(MyDR != null) {
				SelezionaMovimento(MyDR,"E");
			}
		}

		private void btnPagamentiCompetenza_Click(object sender, System.EventArgs e) {
			DataAccess Conn = MetaData.GetConnection(this);
			string MyFilter;
			
			MyFilter = CreaFiltro_Incassi_Pagamenti("pagamenti","C");
			MetaData MIncassiComp = MetaData.GetMetaData(this,"paymentcommunicated");
			MIncassiComp.FilterLocked = true;
			MIncassiComp.DS = DS;
			DataRow MyDR = MIncassiComp.SelectOne("default",MyFilter,null,null);

			if(MyDR != null) {
				SelezionaMovimento(MyDR,"S");
			}
		}

		private void btnPagamentiResidui_Click(object sender, System.EventArgs e) {
			DataAccess Conn = MetaData.GetConnection(this);
			string MyFilter;
			
			MyFilter = CreaFiltro_Incassi_Pagamenti("pagamenti","R");
			MetaData MIncassiComp = MetaData.GetMetaData(this,"paymentcommunicated");
			MIncassiComp.FilterLocked = true;
			MIncassiComp.DS = DS;
			DataRow MyDR = MIncassiComp.SelectOne("default",MyFilter,null,null);
			
			if(MyDR != null) {
				SelezionaMovimento(MyDR,"S");
			}
		}
		
		// Bottoni presenti sul TAB Ammin. Effettiva
		private void btnResiduiAttiviPrec_Click(object sender, System.EventArgs e) {
			DataAccess Conn = MetaData.GetConnection(this);
			string MyFilter;
			
			MyFilter = CreaFiltro_Residui_Attivi_Passivi("R","E");
			MetaData MResiduiAttPrec = MetaData.GetMetaData(this,"revenuearrears");
			MResiduiAttPrec.FilterLocked = true;
			MResiduiAttPrec.DS = DS;
			DataRow MyDR = MResiduiAttPrec.SelectOne("default",MyFilter,null,null);
			
			if(MyDR != null) {
				SelezionaMovimento(MyDR,"E");
			}
		}

		private void btnResiduiAttiviAtt_Click(object sender, System.EventArgs e) {
			DataAccess Conn = MetaData.GetConnection(this);
			string MyFilter;
			
			MyFilter = CreaFiltro_Residui_Attivi_Passivi("C","E");
			MetaData MResiduiAttAtt = MetaData.GetMetaData(this,"revenuearrears");
			MResiduiAttAtt.FilterLocked = true;
			MResiduiAttAtt.DS = DS;
			DataRow MyDR = MResiduiAttAtt.SelectOne("default",MyFilter,null,null);
			
			if(MyDR != null) {
				SelezionaMovimento(MyDR,"E");			}
		}

		private void btnResiduiPassiviPrec_Click(object sender, System.EventArgs e) {
			DataAccess Conn = MetaData.GetConnection(this);
			string MyFilter;
			
			MyFilter = CreaFiltro_Residui_Attivi_Passivi("R","E");
			MetaData MResiduiPassPrec = MetaData.GetMetaData(this,"expenditurearrears");
			MResiduiPassPrec.FilterLocked = true;
			MResiduiPassPrec.DS = DS;
			DataRow MyDR = MResiduiPassPrec.SelectOne("default",MyFilter,null,null);
			
			if(MyDR != null) {
				SelezionaMovimento(MyDR,"S");
			}
		}

		private void btnResiduiPassiviAtt_Click(object sender, System.EventArgs e) {
			DataAccess Conn = MetaData.GetConnection(this);
			string MyFilter;
			
			MyFilter = CreaFiltro_Residui_Attivi_Passivi("C","E");
			MetaData MResiduiPassAtt = MetaData.GetMetaData(this,"expenditurearrears");
			MResiduiPassAtt.FilterLocked = true;
			MResiduiPassAtt.DS = DS;
			DataRow MyDR = MResiduiPassAtt.SelectOne("default",MyFilter,null,null);
			
			if(MyDR != null) {
				SelezionaMovimento(MyDR,"S");
			}
		}
     
		private string ScegliVista(string nomeVista) {
		
			if (txtEsercizio.Text != "") {
				// Ricordarsi di togliere questo controllo in quanto ho ripristinato il filtro statico
                if (DS.config.Rows.Count == 0) return "non definito";
                DataRow rApp = DS.config.Rows[0];
				flagvaliditadoc = Convert.ToString(rApp["cashvaliditykind"]);

				switch(flagvaliditadoc) {
					case "1":
						nomeVista += "emitted";
						break;
					case "2":
						nomeVista += "printed";
						break;
					case "3":
						nomeVista += "communicated";
						break;
					case "4":
						nomeVista += "performed";
						break;
				}
			}
			return nomeVista;
		}

		private string CreaFiltro_Incassi_Pagamenti(string incassi_pagamenti,string comp_res) {
			string Filter;
			object data = new object();

			Filter = "";
			data = HelpForm.GetObjectFromString(typeof(DateTime),txtData.Text,txtData.Tag.ToString());
			
			// Filtro sulla fase massima di entrata / spesa
			if (incassi_pagamenti == "incassi")
				Filter = QHS.CmpEq("nphase", Meta.GetSys("maxincomephase"));
			else if (incassi_pagamenti == "pagamenti")
				Filter = QHS.CmpEq("nphase", Meta.GetSys("maxexpensephase"));
			
			// Filtro sull'esercizio
			Filter = QHS.AppAnd(Filter, QHS.CmpEq("ymov", Meta.GetSys("esercizio")));
			
			// Filtro sulla data di riferimento
			if (comp_res == null) {
				if (data != DBNull.Value)
					Filter = QHS.AppAnd(Filter, QHS.CmpLe("competencydate", data));
			}
			
			// Filtro sulla competenza
			if (comp_res == "C")
				Filter = QHS.AppAnd(Filter, QHS.CmpEq("flagarrear",'C'));
			else if (comp_res == "R")
                Filter = QHS.AppAnd(Filter, QHS.CmpEq("flagarrear", 'R'));
			return Filter;
		}

		private string CreaFiltro_Residui_Attivi_Passivi(string comp_res,string presunta_effettiva) {
			string Filter;
			Filter = "";

			// Filtro sull'esercizio
			Filter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
			
			// Filtro sulla competenza
			if (comp_res == "C")
                Filter = QHS.AppAnd(Filter, QHS.CmpEq("flagarrear", 'C'));
			else if (comp_res == "R")
                Filter = QHS.AppAnd(Filter, QHS.CmpEq("flagarrear", 'R'));

			if (presunta_effettiva == "P") {
				// Filtro sulla data di scadenza
				DateTime ultimogiornoanno = new DateTime(Convert.ToInt32(Meta.GetSys("esercizio")),12,31);
                Filter = QHS.AppAnd(Filter,QHS.CmpGt("expiration", ultimogiornoanno));
			}
			return Filter;
		}

		private string CreaFiltro_Fasi_Miste(string entrata_spesa) {
			string Filter;
			object data = new object();
            
						
			Filter = "";
			data = HelpForm.GetObjectFromString(typeof(DateTime),txtData.Text,txtData.Tag.ToString());
			
			// Filtro sull'esercizio
			DateTime ultimoanno = new DateTime(Convert.ToInt32(Meta.GetSys("esercizio")),12,31);
			Filter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));

            object faseMax = null;
            string fieldDocDate = null;
            object faseResiduo = null;
			if (entrata_spesa == "E") {
				// Filtro sui movimenti dell'ultima fase
                faseMax = Meta.GetSys("maxincomephase");
                fieldDocDate = "proceedsadate";
                faseResiduo = faseaccertamento;
                
                //Filter += " AND (((nphase=" + QueryCreator.quotedstrvalue(Meta.GetSys("maxincomephase"),true) + ")";
                //Filter += " AND (transmissiondate IS NULL) OR ((transmissiondate > " + QueryCreator.quotedstrvalue(data,true) + ")";
                //Filter += " AND (transmissiondate <= " + QueryCreator.quotedstrvalue(ultimoanno,true) + ")";
                //Filter += " AND (proceedsadate > " + QueryCreator.quotedstrvalue(data, true) + ")))";
                //// Filtro sui movimenti nella fase di accertamento
                //Filter += " OR ((nphase>=" + QueryCreator.quotedstrvalue(faseaccertamento,true) + ")";
                //Filter += "AND (nphase < " + QueryCreator.quotedstrvalue(Meta.GetSys("maxincomephase"),true) + ")";
                //Filter += " AND ((expiration IS NULL) OR (expiration <= " + QueryCreator.quotedstrvalue(ultimoanno,true) + "))))";
			}
			else if (entrata_spesa == "S") {
                faseMax = Meta.GetSys("maxexpensephase");
                fieldDocDate = "paymentadate";
                faseResiduo = faseimpegno;
				// Filtro sui movimenti dell'ultima fase
                //Filter += " AND (((nphase=" + QueryCreator.quotedstrvalue(Meta.GetSys("maxexpensephase"),true) + ")";
                //Filter += " AND (transmissiondate IS NULL) OR ((transmissiondate > " + QueryCreator.quotedstrvalue(data,true) + ")";
                //Filter += " AND (transmissiondate <= " + QueryCreator.quotedstrvalue(ultimoanno,true) + ")";
                //Filter += " AND (paymentadate > " + QueryCreator.quotedstrvalue(data, true) + ")))";
                //// Filtro sui movimenti nella fase di impegno
                //Filter += " OR ((nphase>=" + QueryCreator.quotedstrvalue(faseimpegno,true) + ")";
                //Filter += "AND (nphase < " + QueryCreator.quotedstrvalue(Meta.GetSys("maxexpensephase"),true) + ")";
                //Filter += " AND ((expiration IS NULL) OR (expiration <= " + QueryCreator.quotedstrvalue(ultimoanno,true) + "))))";
			}
            string bloccoDate="";
            if (CfgFn.GetNoNullInt32(flagvaliditadoc)<=2)
             bloccoDate = QHS.DoPar(QHS.AppAnd(
                            QHS.CmpGt("transmissiondate", data), QHS.CmpLe("transmissiondate", ultimoanno),QHS.CmpGt(fieldDocDate, data)
                                        ));
            else
             bloccoDate = QHS.DoPar(QHS.AppAnd(
                                    QHS.CmpGt("transmissiondate", data), QHS.CmpLe("transmissiondate", ultimoanno)
                                          ));



            string bloccoFase = QHS.AppAnd(QHS.CmpGe("nphase", faseResiduo),
                QHS.CmpLt("nphase", faseMax));

            string bloccoExpiration = QHS.DoPar(QHS.AppOr(QHS.IsNull("expiration"), QHS.CmpLe("expiration", ultimoanno)));

            string b1 = QHS.DoPar(QHS.AppOr(QHS.AppAnd(QHS.CmpEq("nphase", faseMax), QHS.IsNull("transmissiondate")), bloccoDate));
            string b2 = QHS.DoPar(QHS.AppAnd(bloccoFase, bloccoExpiration));

            Filter = QHS.AppAnd(Filter, QHS.DoPar(QHS.AppOr(b1, b2)));

			return Filter;
		}

		private void SelezionaMovimento(DataRow MyDR,string entrata_spesa) {
			
			if (entrata_spesa == "E") {
				MetaData newEntrata = Meta.Dispatcher.Get("income");
				newEntrata.Edit(this.ParentForm, "default", false);
				DataRow R2 = newEntrata.SelectOne(newEntrata.DefaultListType,
					QHS.CmpEq("idinc", MyDR["idinc"]) ,"income",null);
				if (R2!=null) newEntrata.SelectRow(R2, newEntrata.DefaultListType);
			}
			if (entrata_spesa == "S") {
				MetaData newSpesa = Meta.Dispatcher.Get("expense");
				newSpesa.Edit(this.ParentForm, "default", false);
				DataRow R2 = newSpesa.SelectOne(newSpesa.DefaultListType,
					QHS.CmpEq("idexp", MyDR["idexp"]) ,"expense",null);
				if (R2!=null) newSpesa.SelectRow(R2, newSpesa.DefaultListType);
			}
		}

		private void txtEsercizioAmmEffettiva_Leave(object sender, System.EventArgs e) {
			txtDescrResiduiAttiviPrecedenti.Text = "Residui Attivi Precedenti non Incassati nel " + Meta.GetSys("esercizio").ToString();
			txtDescrResiduiPassiviPrecedenti.Text = "Residui Passivi Precedenti non Pagati nel " + Meta.GetSys("esercizio").ToString();

		}

		private void btnStampa1_Click(object sender, System.EventArgs e) {
			Stampa("C");
		}

		private void btnStampa3_Click(object sender, System.EventArgs e) {
			Stampa("A");
		}

		void Stampa(string tipo){
			if (Meta.IsEmpty) return;
			if (Meta.InsertMode) return;
			PostData.RemoveFalseUpdates(DS);
			if (DS.HasChanges()){
				MessageBox.Show("PoichÈ non Ë ancora stato effettuato il salvataggio dei dati, la stampa potrebbe "+
					"non rispecchiare fedelmente i dati di questa schermata.");
			}
			MetaData MetaReport= MetaData.GetMetaData(this,"resultparameter");
            if (tipo == "C")
                Meta.Dispatcher.Edit(this, "resultparameter", "default", false, "Finanziaria.avanzocassapresunto");
            else
                Meta.Dispatcher.Edit(this, "resultparameter", "default", false, "Finanziaria.avanzoamministrazionepresunto");

		}
	}
}