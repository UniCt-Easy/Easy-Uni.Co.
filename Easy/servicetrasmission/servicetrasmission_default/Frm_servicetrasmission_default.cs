
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
using System.Xml;
using System.Text;
using System.IO;
using funzioni_configurazione;
using System.Globalization;
using System.Security;
using System.Xml.Schema;
using System.Xml.Xsl;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using servicetrasmission_default.service;
using servicetrasmission_default.ServicePerla;
using System.Xml.Serialization;
using q = metadatalibrary.MetaExpression;

namespace servicetrasmission_default {
	/// <summary>
	/// Summary description for Frm_servicetrasmission_default.
	/// </summary>
	public class Frm_servicetrasmission_default : MetaDataForm {
		public servicetrasmission_default.vistaForm DS;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.OpenFileDialog _openFileDialog1;
		private XmlTextWriter writer;
		MetaData meta;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		string filtroNuovoIncarico =
			" (is_delivered ='N' and is_annulled='N' and is_blocked = 'N' and  website_annulled = 'N') ";

		//		string filtroModificaIncarico	= " (is_delivered ='S' and is_changed = 'N' and is_blocked = 'N') ";
		//string filtroTuttiIncarichi = " (is_delivered ='S' and is_blocked = 'N') ";
		string filtroModificaIncarico = " (is_delivered ='S' and is_changed = 'S' and is_blocked = 'N') ";
		string filtroCancellaIncarico = " (is_delivered ='N' and is_annulled='S' and is_blocked = 'N') ";

		string filtroNuovoPagamento = " (is_delivered ='N' and payedamount > '0' and is_blocked = 'N') ";

		string filtroModificaPagamento = " (is_delivered ='S' and is_changed ='S' and is_blocked = 'N') ";

		private enum tipoIncarico {nuovoIncarico, modificaIncarico, cancellaIncarico};


		//string filtroCancellaPagamento = " (is_delivered ='S' and payedamount = '0' and is_blocked = 'N') ";
		private System.Windows.Forms.TabControl tabControl1;
		private TabPage tabDipendenti;
		private Label label6;
		private Label label5;
		private TabPage tabConsulenti;
		private TabPage tabModifica;
		private TabPage tabCancellazione;
		private TabPage tabAltro;
		public Button btnannullaD;
		public Button btnAnnullaC;
		private Label label17;
		private Label label16;
		private Label label18;
		private Label label19;
		private Label label20;
		private TabPage tabAttributi;
		public GroupBox gboxclass05;
		public TextBox txtCodice05;
		public Button btnCodice05;
		private TextBox txtDenom05;
		public GroupBox gboxclass04;
		public TextBox txtCodice04;
		public Button btnCodice04;
		private TextBox txtDenom04;
		public GroupBox gboxclass03;
		public TextBox txtCodice03;
		public Button btnCodice03;
		private TextBox txtDenom03;
		public GroupBox gboxclass02;
		public TextBox txtCodice02;
		public Button btnCodice02;
		private TextBox txtDenom02;
		public GroupBox gboxclass01;
		public TextBox txtCodice01;
		public Button btnCodice01;
		private TextBox txtDenom01;
		public Button btnInviaDipendentiWS;
		public Button btnInviaConsulenti2SemWS;
		public Button btnModificaDatiDipendentiWS;
		public Button btnModificaDatiConsulentiWS;
		public Button btnCancellazioneDipendentiWS;
		public Button btnCancellazioneConsulentiWS;
		private Button btnSelezionaAutoCert;
		private TextBox txtFileAutocertDefault;
		private Label label1;
		private Label label3;
		private TextBox txtAnnoDipendente;
		private Label label2;
		private TextBox txtAnnoConsulente;
		private Label label4;
		private TextBox txtNumeroDipendente;
		private Label label7;
		private TextBox txtNumeroConsulente;
		private Label label8;
		private TabPage tabErrori;
		private Label label9;
		private TextBox txtErrori;
		public IOpenFileDialog openFileDialog1;
		private Label label10;
		private Label label11;
		private Label label12;
		private Label label13;
		private Label label14;
		private Label label15;
		private Label label21;
		private Label label22;

		//int esercizio
		DataAccess Conn;

		public Frm_servicetrasmission_default() {
			InitializeComponent();
			openFileDialog1 = createOpenFileDialog(_openFileDialog1);
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
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this._openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabDipendenti = new System.Windows.Forms.TabPage();
			this.label14 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.txtNumeroDipendente = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtAnnoDipendente = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnInviaDipendentiWS = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.tabConsulenti = new System.Windows.Forms.TabPage();
			this.label15 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.txtNumeroConsulente = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtAnnoConsulente = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btnInviaConsulenti2SemWS = new System.Windows.Forms.Button();
			this.tabModifica = new System.Windows.Forms.TabPage();
			this.label13 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.btnModificaDatiDipendentiWS = new System.Windows.Forms.Button();
			this.btnModificaDatiConsulentiWS = new System.Windows.Forms.Button();
			this.label17 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.tabCancellazione = new System.Windows.Forms.TabPage();
			this.label21 = new System.Windows.Forms.Label();
			this.btnCancellazioneDipendentiWS = new System.Windows.Forms.Button();
			this.btnCancellazioneConsulentiWS = new System.Windows.Forms.Button();
			this.label18 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.tabAltro = new System.Windows.Forms.TabPage();
			this.btnSelezionaAutoCert = new System.Windows.Forms.Button();
			this.txtFileAutocertDefault = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.btnannullaD = new System.Windows.Forms.Button();
			this.btnAnnullaC = new System.Windows.Forms.Button();
			this.tabAttributi = new System.Windows.Forms.TabPage();
			this.gboxclass05 = new System.Windows.Forms.GroupBox();
			this.txtCodice05 = new System.Windows.Forms.TextBox();
			this.btnCodice05 = new System.Windows.Forms.Button();
			this.txtDenom05 = new System.Windows.Forms.TextBox();
			this.gboxclass04 = new System.Windows.Forms.GroupBox();
			this.txtCodice04 = new System.Windows.Forms.TextBox();
			this.btnCodice04 = new System.Windows.Forms.Button();
			this.txtDenom04 = new System.Windows.Forms.TextBox();
			this.gboxclass03 = new System.Windows.Forms.GroupBox();
			this.txtCodice03 = new System.Windows.Forms.TextBox();
			this.btnCodice03 = new System.Windows.Forms.Button();
			this.txtDenom03 = new System.Windows.Forms.TextBox();
			this.gboxclass02 = new System.Windows.Forms.GroupBox();
			this.txtCodice02 = new System.Windows.Forms.TextBox();
			this.btnCodice02 = new System.Windows.Forms.Button();
			this.txtDenom02 = new System.Windows.Forms.TextBox();
			this.gboxclass01 = new System.Windows.Forms.GroupBox();
			this.txtCodice01 = new System.Windows.Forms.TextBox();
			this.btnCodice01 = new System.Windows.Forms.Button();
			this.txtDenom01 = new System.Windows.Forms.TextBox();
			this.tabErrori = new System.Windows.Forms.TabPage();
			this.label9 = new System.Windows.Forms.Label();
			this.txtErrori = new System.Windows.Forms.TextBox();
			this.DS = new servicetrasmission_default.vistaForm();
			this.label22 = new System.Windows.Forms.Label();
			this.tabControl1.SuspendLayout();
			this.tabDipendenti.SuspendLayout();
			this.tabConsulenti.SuspendLayout();
			this.tabModifica.SuspendLayout();
			this.tabCancellazione.SuspendLayout();
			this.tabAltro.SuspendLayout();
			this.tabAttributi.SuspendLayout();
			this.gboxclass05.SuspendLayout();
			this.gboxclass04.SuspendLayout();
			this.gboxclass03.SuspendLayout();
			this.gboxclass02.SuspendLayout();
			this.gboxclass01.SuspendLayout();
			this.tabErrori.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.DefaultExt = "xml";
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabDipendenti);
			this.tabControl1.Controls.Add(this.tabConsulenti);
			this.tabControl1.Controls.Add(this.tabModifica);
			this.tabControl1.Controls.Add(this.tabCancellazione);
			this.tabControl1.Controls.Add(this.tabAltro);
			this.tabControl1.Controls.Add(this.tabAttributi);
			this.tabControl1.Controls.Add(this.tabErrori);
			this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tabControl1.Location = new System.Drawing.Point(8, 8);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(1010, 524);
			this.tabControl1.TabIndex = 28;
			// 
			// tabDipendenti
			// 
			this.tabDipendenti.Controls.Add(this.label22);
			this.tabDipendenti.Controls.Add(this.label14);
			this.tabDipendenti.Controls.Add(this.label10);
			this.tabDipendenti.Controls.Add(this.txtNumeroDipendente);
			this.tabDipendenti.Controls.Add(this.label7);
			this.tabDipendenti.Controls.Add(this.txtAnnoDipendente);
			this.tabDipendenti.Controls.Add(this.label2);
			this.tabDipendenti.Controls.Add(this.btnInviaDipendentiWS);
			this.tabDipendenti.Controls.Add(this.label6);
			this.tabDipendenti.Controls.Add(this.label5);
			this.tabDipendenti.Location = new System.Drawing.Point(4, 22);
			this.tabDipendenti.Name = "tabDipendenti";
			this.tabDipendenti.Size = new System.Drawing.Size(1002, 498);
			this.tabDipendenti.TabIndex = 2;
			this.tabDipendenti.Text = "Dipendenti";
			this.tabDipendenti.UseVisualStyleBackColor = true;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label14.Location = new System.Drawing.Point(24, 388);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(708, 13);
			this.label14.TabIndex = 50;
			this.label14.Text = "NUOVO PAGAMENTO a DIPENDENTE: deve essere non Trasmesso,  non Sospeso  in attesa " +
    "di conferma e con importo > 0";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label10.Location = new System.Drawing.Point(24, 311);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(788, 13);
			this.label10.TabIndex = 49;
			this.label10.Text = "NUOVO INCARICO a DIPENDENTE:  deve essere non Trasmesso, non Annullato , non Annu" +
    "llato tramite WEB, no Incarico da correggere,";
			// 
			// txtNumeroDipendente
			// 
			this.txtNumeroDipendente.Location = new System.Drawing.Point(27, 271);
			this.txtNumeroDipendente.Name = "txtNumeroDipendente";
			this.txtNumeroDipendente.Size = new System.Drawing.Size(100, 20);
			this.txtNumeroDipendente.TabIndex = 48;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(24, 255);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(476, 13);
			this.label7.TabIndex = 47;
			this.label7.Text = "Numero incarico, specificare se si intende limitare l\'invio degli inserimenti all" +
    "la prestazione specificata";
			// 
			// txtAnnoDipendente
			// 
			this.txtAnnoDipendente.Location = new System.Drawing.Point(27, 218);
			this.txtAnnoDipendente.Name = "txtAnnoDipendente";
			this.txtAnnoDipendente.Size = new System.Drawing.Size(100, 20);
			this.txtAnnoDipendente.TabIndex = 46;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(24, 202);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(491, 13);
			this.label2.TabIndex = 45;
			this.label2.Text = "Anno incarichi, specificare se si intende limitare l\'invio degli inserimenti alle" +
    " prestazioni dell\'anno indicato";
			// 
			// btnInviaDipendentiWS
			// 
			this.btnInviaDipendentiWS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnInviaDipendentiWS.Location = new System.Drawing.Point(388, 115);
			this.btnInviaDipendentiWS.Name = "btnInviaDipendentiWS";
			this.btnInviaDipendentiWS.Size = new System.Drawing.Size(188, 34);
			this.btnInviaDipendentiWS.TabIndex = 44;
			this.btnInviaDipendentiWS.Text = "Invia dati  a PERLA";
			this.btnInviaDipendentiWS.UseVisualStyleBackColor = true;
			this.btnInviaDipendentiWS.Click += new System.EventHandler(this.btnInviaDipendenti_Click);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(316, 82);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(331, 13);
			this.label6.TabIndex = 42;
			this.label6.Text = "Comunicazione entro 15 giorni dal conferimento o dall’autorizzazione ";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(113, 44);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(744, 13);
			this.label5.TabIndex = 41;
			this.label5.Text = "Inserimento sul sito PerLa Pa di incarichi conferiti o autorizzati ai propri dipe" +
    "ndenti (con o senza pagamento) sino alla data attuale";
			// 
			// tabConsulenti
			// 
			this.tabConsulenti.Controls.Add(this.label15);
			this.tabConsulenti.Controls.Add(this.label11);
			this.tabConsulenti.Controls.Add(this.txtNumeroConsulente);
			this.tabConsulenti.Controls.Add(this.label8);
			this.tabConsulenti.Controls.Add(this.txtAnnoConsulente);
			this.tabConsulenti.Controls.Add(this.label4);
			this.tabConsulenti.Controls.Add(this.label3);
			this.tabConsulenti.Controls.Add(this.btnInviaConsulenti2SemWS);
			this.tabConsulenti.Location = new System.Drawing.Point(4, 22);
			this.tabConsulenti.Name = "tabConsulenti";
			this.tabConsulenti.Size = new System.Drawing.Size(1002, 498);
			this.tabConsulenti.TabIndex = 3;
			this.tabConsulenti.Text = "Consulenti e Collaboratori esterni";
			this.tabConsulenti.UseVisualStyleBackColor = true;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label15.Location = new System.Drawing.Point(16, 265);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(896, 13);
			this.label15.TabIndex = 52;
			this.label15.Text = "NUOVO PAGAMENTO a CONSULENTE o COLLABORATORE ESTERNO: deve essere non Trasmesso, " +
    " non Sospeso  in attesa di conferma e con importo > 0";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label11.Location = new System.Drawing.Point(16, 238);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(976, 13);
			this.label11.TabIndex = 51;
			this.label11.Text = "NUOVO INCARICO a CONSULENTE  o COLLABORATORE ESTERNO:  deve essere non Trasmesso," +
    " non Annullato , non Annullato tramite WEB, no Incarico da correggere";
			// 
			// txtNumeroConsulente
			// 
			this.txtNumeroConsulente.Location = new System.Drawing.Point(19, 185);
			this.txtNumeroConsulente.Name = "txtNumeroConsulente";
			this.txtNumeroConsulente.Size = new System.Drawing.Size(100, 20);
			this.txtNumeroConsulente.TabIndex = 50;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(16, 169);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(476, 13);
			this.label8.TabIndex = 49;
			this.label8.Text = "Numero incarico, specificare se si intende limitare l\'invio degli inserimenti all" +
    "la prestazione specificata";
			// 
			// txtAnnoConsulente
			// 
			this.txtAnnoConsulente.Location = new System.Drawing.Point(19, 134);
			this.txtAnnoConsulente.Name = "txtAnnoConsulente";
			this.txtAnnoConsulente.Size = new System.Drawing.Size(100, 20);
			this.txtAnnoConsulente.TabIndex = 48;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(16, 118);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(491, 13);
			this.label4.TabIndex = 47;
			this.label4.Text = "Anno incarichi, specificare se si intende limitare l\'invio degli inserimenti alle" +
    " prestazioni dell\'anno indicato";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(216, 18);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(559, 13);
			this.label3.TabIndex = 36;
			this.label3.Text = "Inserimento tramite web Service PerLa Pa di incarichi affidati a Consulenti e Col" +
    "laboratori esterni ";
			// 
			// btnInviaConsulenti2SemWS
			// 
			this.btnInviaConsulenti2SemWS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnInviaConsulenti2SemWS.Location = new System.Drawing.Point(379, 49);
			this.btnInviaConsulenti2SemWS.Name = "btnInviaConsulenti2SemWS";
			this.btnInviaConsulenti2SemWS.Size = new System.Drawing.Size(157, 34);
			this.btnInviaConsulenti2SemWS.TabIndex = 35;
			this.btnInviaConsulenti2SemWS.Text = "Invia dati a PERLA";
			this.btnInviaConsulenti2SemWS.UseVisualStyleBackColor = true;
			this.btnInviaConsulenti2SemWS.Click += new System.EventHandler(this.btnInviaConsulenti2SemWS_Click);
			// 
			// tabModifica
			// 
			this.tabModifica.Controls.Add(this.label13);
			this.tabModifica.Controls.Add(this.label12);
			this.tabModifica.Controls.Add(this.btnModificaDatiDipendentiWS);
			this.tabModifica.Controls.Add(this.btnModificaDatiConsulentiWS);
			this.tabModifica.Controls.Add(this.label17);
			this.tabModifica.Controls.Add(this.label16);
			this.tabModifica.Location = new System.Drawing.Point(4, 22);
			this.tabModifica.Name = "tabModifica";
			this.tabModifica.Size = new System.Drawing.Size(1002, 498);
			this.tabModifica.TabIndex = 6;
			this.tabModifica.Text = "Modifica";
			this.tabModifica.UseVisualStyleBackColor = true;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label13.Location = new System.Drawing.Point(207, 400);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(584, 13);
			this.label13.TabIndex = 44;
			this.label13.Text = "MODIFICA PAGAMENTO: deve essere Trasmesso, da Modificare e non Sospeso in attesa " +
    "di conferma";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label12.Location = new System.Drawing.Point(218, 372);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(521, 13);
			this.label12.TabIndex = 43;
			this.label12.Text = "MODIFICA INCARICO: deve essere Trasmesso, da Modificare e no Incarico da corregge" +
    "re ";
			// 
			// btnModificaDatiDipendentiWS
			// 
			this.btnModificaDatiDipendentiWS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnModificaDatiDipendentiWS.Location = new System.Drawing.Point(419, 244);
			this.btnModificaDatiDipendentiWS.Name = "btnModificaDatiDipendentiWS";
			this.btnModificaDatiDipendentiWS.Size = new System.Drawing.Size(157, 34);
			this.btnModificaDatiDipendentiWS.TabIndex = 42;
			this.btnModificaDatiDipendentiWS.Text = "Invia tramite Web Service";
			this.btnModificaDatiDipendentiWS.UseVisualStyleBackColor = true;
			this.btnModificaDatiDipendentiWS.Click += new System.EventHandler(this.btnModificaDatiDipendentiWS_Click);
			// 
			// btnModificaDatiConsulentiWS
			// 
			this.btnModificaDatiConsulentiWS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnModificaDatiConsulentiWS.Location = new System.Drawing.Point(419, 71);
			this.btnModificaDatiConsulentiWS.Name = "btnModificaDatiConsulentiWS";
			this.btnModificaDatiConsulentiWS.Size = new System.Drawing.Size(157, 34);
			this.btnModificaDatiConsulentiWS.TabIndex = 41;
			this.btnModificaDatiConsulentiWS.Text = "Invia tramite Web Service";
			this.btnModificaDatiConsulentiWS.UseVisualStyleBackColor = true;
			this.btnModificaDatiConsulentiWS.Click += new System.EventHandler(this.btnModificaDatiConsulentiWS_Click);
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label17.Location = new System.Drawing.Point(354, 214);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(273, 13);
			this.label17.TabIndex = 1;
			this.label17.Text = "Invio modifiche dati  Dipendenti di questo Ente";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label16.Location = new System.Drawing.Point(325, 41);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(313, 13);
			this.label16.TabIndex = 0;
			this.label16.Text = "Invio modifiche dati Consulenti e Collaboratori esterni ";
			// 
			// tabCancellazione
			// 
			this.tabCancellazione.Controls.Add(this.label21);
			this.tabCancellazione.Controls.Add(this.btnCancellazioneDipendentiWS);
			this.tabCancellazione.Controls.Add(this.btnCancellazioneConsulentiWS);
			this.tabCancellazione.Controls.Add(this.label18);
			this.tabCancellazione.Controls.Add(this.label19);
			this.tabCancellazione.Location = new System.Drawing.Point(4, 22);
			this.tabCancellazione.Name = "tabCancellazione";
			this.tabCancellazione.Size = new System.Drawing.Size(1002, 498);
			this.tabCancellazione.TabIndex = 7;
			this.tabCancellazione.Text = "Cancellazione";
			this.tabCancellazione.UseVisualStyleBackColor = true;
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label21.Location = new System.Drawing.Point(217, 368);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(530, 13);
			this.label21.TabIndex = 47;
			this.label21.Text = "CANCELLA INCARICO: deve essere non Trasmesso,  Annullato e no Incarico da corregg" +
    "ere ";
			// 
			// btnCancellazioneDipendentiWS
			// 
			this.btnCancellazioneDipendentiWS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCancellazioneDipendentiWS.Location = new System.Drawing.Point(420, 278);
			this.btnCancellazioneDipendentiWS.Name = "btnCancellazioneDipendentiWS";
			this.btnCancellazioneDipendentiWS.Size = new System.Drawing.Size(157, 34);
			this.btnCancellazioneDipendentiWS.TabIndex = 46;
			this.btnCancellazioneDipendentiWS.Text = "Invia tramite Web Service";
			this.btnCancellazioneDipendentiWS.UseVisualStyleBackColor = true;
			this.btnCancellazioneDipendentiWS.Click += new System.EventHandler(this.btnCancellazioneDipendentiWS_Click);
			// 
			// btnCancellazioneConsulentiWS
			// 
			this.btnCancellazioneConsulentiWS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCancellazioneConsulentiWS.Location = new System.Drawing.Point(420, 76);
			this.btnCancellazioneConsulentiWS.Name = "btnCancellazioneConsulentiWS";
			this.btnCancellazioneConsulentiWS.Size = new System.Drawing.Size(157, 34);
			this.btnCancellazioneConsulentiWS.TabIndex = 45;
			this.btnCancellazioneConsulentiWS.Text = "Invia tramite Web Service";
			this.btnCancellazioneConsulentiWS.UseVisualStyleBackColor = true;
			this.btnCancellazioneConsulentiWS.Click += new System.EventHandler(this.btnCancellazioneConsulentiWS_Click);
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label18.Location = new System.Drawing.Point(313, 246);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(416, 13);
			this.label18.TabIndex = 42;
			this.label18.Text = "Cancellazione dei dati già trasmessi relativi ai Dipendenti di questo Ente";
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label19.Location = new System.Drawing.Point(269, 45);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(460, 13);
			this.label19.TabIndex = 41;
			this.label19.Text = "Cancellazione dei dati già trasmessi relativi ai Consulenti e Collaboratori ester" +
    "ni ";
			// 
			// tabAltro
			// 
			this.tabAltro.Controls.Add(this.btnSelezionaAutoCert);
			this.tabAltro.Controls.Add(this.txtFileAutocertDefault);
			this.tabAltro.Controls.Add(this.label1);
			this.tabAltro.Controls.Add(this.label20);
			this.tabAltro.Controls.Add(this.btnannullaD);
			this.tabAltro.Controls.Add(this.btnAnnullaC);
			this.tabAltro.Location = new System.Drawing.Point(4, 22);
			this.tabAltro.Name = "tabAltro";
			this.tabAltro.Size = new System.Drawing.Size(1002, 498);
			this.tabAltro.TabIndex = 8;
			this.tabAltro.Text = "Altro";
			this.tabAltro.UseVisualStyleBackColor = true;
			// 
			// btnSelezionaAutoCert
			// 
			this.btnSelezionaAutoCert.Location = new System.Drawing.Point(655, 279);
			this.btnSelezionaAutoCert.Name = "btnSelezionaAutoCert";
			this.btnSelezionaAutoCert.Size = new System.Drawing.Size(102, 23);
			this.btnSelezionaAutoCert.TabIndex = 36;
			this.btnSelezionaAutoCert.Text = "Seleziona";
			this.btnSelezionaAutoCert.UseVisualStyleBackColor = true;
			this.btnSelezionaAutoCert.Click += new System.EventHandler(this.btnSelezionaAutoCert_Click);
			// 
			// txtFileAutocertDefault
			// 
			this.txtFileAutocertDefault.Location = new System.Drawing.Point(26, 282);
			this.txtFileAutocertDefault.Name = "txtFileAutocertDefault";
			this.txtFileAutocertDefault.ReadOnly = true;
			this.txtFileAutocertDefault.Size = new System.Drawing.Size(600, 20);
			this.txtFileAutocertDefault.TabIndex = 35;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(23, 266);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(236, 13);
			this.label1.TabIndex = 34;
			this.label1.Text = "File da usare per l\'autocertificazione ove assente";
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label20.Location = new System.Drawing.Point(252, 35);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(528, 13);
			this.label20.TabIndex = 33;
			this.label20.Text = "Annullamento della trasmissione di incarichi e di pagamenti, che siano nello stat" +
    "o ‘sospeso’.";
			this.label20.Visible = false;
			// 
			// btnannullaD
			// 
			this.btnannullaD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnannullaD.Location = new System.Drawing.Point(384, 78);
			this.btnannullaD.Name = "btnannullaD";
			this.btnannullaD.Size = new System.Drawing.Size(242, 50);
			this.btnannullaD.TabIndex = 31;
			this.btnannullaD.Text = "Annullamento trasmissione Dipendenti";
			this.btnannullaD.UseVisualStyleBackColor = true;
			this.btnannullaD.Visible = false;
			this.btnannullaD.Click += new System.EventHandler(this.btnannullaD_Click);
			// 
			// btnAnnullaC
			// 
			this.btnAnnullaC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAnnullaC.Location = new System.Drawing.Point(384, 162);
			this.btnAnnullaC.Name = "btnAnnullaC";
			this.btnAnnullaC.Size = new System.Drawing.Size(242, 50);
			this.btnAnnullaC.TabIndex = 32;
			this.btnAnnullaC.Text = "Annullamento trasmissione  \r\nConsulenti e Collaboratori esterni";
			this.btnAnnullaC.UseVisualStyleBackColor = true;
			this.btnAnnullaC.Visible = false;
			this.btnAnnullaC.Click += new System.EventHandler(this.btnAnnullaC_Click);
			// 
			// tabAttributi
			// 
			this.tabAttributi.Controls.Add(this.gboxclass05);
			this.tabAttributi.Controls.Add(this.gboxclass04);
			this.tabAttributi.Controls.Add(this.gboxclass03);
			this.tabAttributi.Controls.Add(this.gboxclass02);
			this.tabAttributi.Controls.Add(this.gboxclass01);
			this.tabAttributi.Location = new System.Drawing.Point(4, 22);
			this.tabAttributi.Name = "tabAttributi";
			this.tabAttributi.Padding = new System.Windows.Forms.Padding(3);
			this.tabAttributi.Size = new System.Drawing.Size(1002, 498);
			this.tabAttributi.TabIndex = 10;
			this.tabAttributi.Text = "Attributi";
			this.tabAttributi.UseVisualStyleBackColor = true;
			// 
			// gboxclass05
			// 
			this.gboxclass05.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxclass05.Controls.Add(this.txtCodice05);
			this.gboxclass05.Controls.Add(this.btnCodice05);
			this.gboxclass05.Controls.Add(this.txtDenom05);
			this.gboxclass05.Location = new System.Drawing.Point(21, 296);
			this.gboxclass05.Name = "gboxclass05";
			this.gboxclass05.Size = new System.Drawing.Size(664, 64);
			this.gboxclass05.TabIndex = 38;
			this.gboxclass05.TabStop = false;
			this.gboxclass05.Tag = "";
			this.gboxclass05.Text = "Classificazione 5";
			// 
			// txtCodice05
			// 
			this.txtCodice05.Location = new System.Drawing.Point(9, 38);
			this.txtCodice05.Name = "txtCodice05";
			this.txtCodice05.Size = new System.Drawing.Size(219, 20);
			this.txtCodice05.TabIndex = 6;
			// 
			// btnCodice05
			// 
			this.btnCodice05.Location = new System.Drawing.Point(8, 16);
			this.btnCodice05.Name = "btnCodice05";
			this.btnCodice05.Size = new System.Drawing.Size(88, 23);
			this.btnCodice05.TabIndex = 4;
			this.btnCodice05.Tag = "manage.sorting05.tree";
			this.btnCodice05.Text = "Codice";
			this.btnCodice05.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtDenom05
			// 
			this.txtDenom05.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDenom05.Location = new System.Drawing.Point(234, 8);
			this.txtDenom05.Multiline = true;
			this.txtDenom05.Name = "txtDenom05";
			this.txtDenom05.ReadOnly = true;
			this.txtDenom05.Size = new System.Drawing.Size(422, 52);
			this.txtDenom05.TabIndex = 3;
			this.txtDenom05.TabStop = false;
			this.txtDenom05.Tag = "sorting05.description";
			// 
			// gboxclass04
			// 
			this.gboxclass04.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxclass04.Controls.Add(this.txtCodice04);
			this.gboxclass04.Controls.Add(this.btnCodice04);
			this.gboxclass04.Controls.Add(this.txtDenom04);
			this.gboxclass04.Location = new System.Drawing.Point(21, 226);
			this.gboxclass04.Name = "gboxclass04";
			this.gboxclass04.Size = new System.Drawing.Size(664, 64);
			this.gboxclass04.TabIndex = 37;
			this.gboxclass04.TabStop = false;
			this.gboxclass04.Tag = "";
			this.gboxclass04.Text = "Classificazione 4";
			// 
			// txtCodice04
			// 
			this.txtCodice04.Location = new System.Drawing.Point(9, 38);
			this.txtCodice04.Name = "txtCodice04";
			this.txtCodice04.Size = new System.Drawing.Size(219, 20);
			this.txtCodice04.TabIndex = 6;
			// 
			// btnCodice04
			// 
			this.btnCodice04.Location = new System.Drawing.Point(8, 16);
			this.btnCodice04.Name = "btnCodice04";
			this.btnCodice04.Size = new System.Drawing.Size(88, 23);
			this.btnCodice04.TabIndex = 4;
			this.btnCodice04.Tag = "manage.sorting04.tree";
			this.btnCodice04.Text = "Codice";
			this.btnCodice04.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtDenom04
			// 
			this.txtDenom04.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDenom04.Location = new System.Drawing.Point(234, 12);
			this.txtDenom04.Multiline = true;
			this.txtDenom04.Name = "txtDenom04";
			this.txtDenom04.ReadOnly = true;
			this.txtDenom04.Size = new System.Drawing.Size(422, 46);
			this.txtDenom04.TabIndex = 3;
			this.txtDenom04.TabStop = false;
			this.txtDenom04.Tag = "sorting04.description";
			// 
			// gboxclass03
			// 
			this.gboxclass03.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxclass03.Controls.Add(this.txtCodice03);
			this.gboxclass03.Controls.Add(this.btnCodice03);
			this.gboxclass03.Controls.Add(this.txtDenom03);
			this.gboxclass03.Location = new System.Drawing.Point(21, 156);
			this.gboxclass03.Name = "gboxclass03";
			this.gboxclass03.Size = new System.Drawing.Size(664, 64);
			this.gboxclass03.TabIndex = 35;
			this.gboxclass03.TabStop = false;
			this.gboxclass03.Tag = "";
			this.gboxclass03.Text = "Classificazione 3";
			// 
			// txtCodice03
			// 
			this.txtCodice03.Location = new System.Drawing.Point(8, 38);
			this.txtCodice03.Name = "txtCodice03";
			this.txtCodice03.Size = new System.Drawing.Size(219, 20);
			this.txtCodice03.TabIndex = 6;
			// 
			// btnCodice03
			// 
			this.btnCodice03.Location = new System.Drawing.Point(8, 16);
			this.btnCodice03.Name = "btnCodice03";
			this.btnCodice03.Size = new System.Drawing.Size(88, 23);
			this.btnCodice03.TabIndex = 4;
			this.btnCodice03.Tag = "manage.sorting03.tree";
			this.btnCodice03.Text = "Codice";
			this.btnCodice03.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtDenom03
			// 
			this.txtDenom03.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDenom03.Location = new System.Drawing.Point(233, 8);
			this.txtDenom03.Multiline = true;
			this.txtDenom03.Name = "txtDenom03";
			this.txtDenom03.ReadOnly = true;
			this.txtDenom03.Size = new System.Drawing.Size(423, 52);
			this.txtDenom03.TabIndex = 3;
			this.txtDenom03.TabStop = false;
			this.txtDenom03.Tag = "sorting03.description";
			// 
			// gboxclass02
			// 
			this.gboxclass02.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxclass02.Controls.Add(this.txtCodice02);
			this.gboxclass02.Controls.Add(this.btnCodice02);
			this.gboxclass02.Controls.Add(this.txtDenom02);
			this.gboxclass02.Location = new System.Drawing.Point(21, 86);
			this.gboxclass02.Name = "gboxclass02";
			this.gboxclass02.Size = new System.Drawing.Size(664, 64);
			this.gboxclass02.TabIndex = 36;
			this.gboxclass02.TabStop = false;
			this.gboxclass02.Tag = "";
			this.gboxclass02.Text = "Classificazione 2";
			// 
			// txtCodice02
			// 
			this.txtCodice02.Location = new System.Drawing.Point(8, 38);
			this.txtCodice02.Name = "txtCodice02";
			this.txtCodice02.Size = new System.Drawing.Size(219, 20);
			this.txtCodice02.TabIndex = 6;
			// 
			// btnCodice02
			// 
			this.btnCodice02.Location = new System.Drawing.Point(8, 16);
			this.btnCodice02.Name = "btnCodice02";
			this.btnCodice02.Size = new System.Drawing.Size(88, 23);
			this.btnCodice02.TabIndex = 4;
			this.btnCodice02.Tag = "manage.sorting02.tree";
			this.btnCodice02.Text = "Codice";
			this.btnCodice02.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtDenom02
			// 
			this.txtDenom02.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDenom02.Location = new System.Drawing.Point(233, 8);
			this.txtDenom02.Multiline = true;
			this.txtDenom02.Name = "txtDenom02";
			this.txtDenom02.ReadOnly = true;
			this.txtDenom02.Size = new System.Drawing.Size(423, 52);
			this.txtDenom02.TabIndex = 3;
			this.txtDenom02.TabStop = false;
			this.txtDenom02.Tag = "sorting02.description";
			// 
			// gboxclass01
			// 
			this.gboxclass01.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxclass01.Controls.Add(this.txtCodice01);
			this.gboxclass01.Controls.Add(this.btnCodice01);
			this.gboxclass01.Controls.Add(this.txtDenom01);
			this.gboxclass01.Location = new System.Drawing.Point(21, 16);
			this.gboxclass01.Name = "gboxclass01";
			this.gboxclass01.Size = new System.Drawing.Size(664, 64);
			this.gboxclass01.TabIndex = 34;
			this.gboxclass01.TabStop = false;
			this.gboxclass01.Tag = "";
			this.gboxclass01.Text = "Classificazione 1";
			// 
			// txtCodice01
			// 
			this.txtCodice01.Location = new System.Drawing.Point(7, 40);
			this.txtCodice01.Name = "txtCodice01";
			this.txtCodice01.Size = new System.Drawing.Size(220, 20);
			this.txtCodice01.TabIndex = 5;
			// 
			// btnCodice01
			// 
			this.btnCodice01.Location = new System.Drawing.Point(8, 16);
			this.btnCodice01.Name = "btnCodice01";
			this.btnCodice01.Size = new System.Drawing.Size(88, 23);
			this.btnCodice01.TabIndex = 4;
			this.btnCodice01.Tag = "manage.sorting01.tree";
			this.btnCodice01.Text = "Codice";
			this.btnCodice01.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtDenom01
			// 
			this.txtDenom01.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDenom01.Location = new System.Drawing.Point(233, 8);
			this.txtDenom01.Multiline = true;
			this.txtDenom01.Name = "txtDenom01";
			this.txtDenom01.ReadOnly = true;
			this.txtDenom01.Size = new System.Drawing.Size(423, 52);
			this.txtDenom01.TabIndex = 3;
			this.txtDenom01.TabStop = false;
			this.txtDenom01.Tag = "sorting01.description";
			// 
			// tabErrori
			// 
			this.tabErrori.Controls.Add(this.label9);
			this.tabErrori.Controls.Add(this.txtErrori);
			this.tabErrori.Location = new System.Drawing.Point(4, 22);
			this.tabErrori.Name = "tabErrori";
			this.tabErrori.Padding = new System.Windows.Forms.Padding(3);
			this.tabErrori.Size = new System.Drawing.Size(1002, 498);
			this.tabErrori.TabIndex = 11;
			this.tabErrori.Text = "Errori";
			this.tabErrori.UseVisualStyleBackColor = true;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(6, 33);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(119, 13);
			this.label9.TabIndex = 1;
			this.label9.Text = "Errori intercorsi nell\'invio";
			// 
			// txtErrori
			// 
			this.txtErrori.AcceptsReturn = true;
			this.txtErrori.AcceptsTab = true;
			this.txtErrori.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtErrori.Location = new System.Drawing.Point(6, 49);
			this.txtErrori.Multiline = true;
			this.txtErrori.Name = "txtErrori";
			this.txtErrori.Size = new System.Drawing.Size(990, 443);
			this.txtErrori.TabIndex = 0;
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label22.Location = new System.Drawing.Point(24, 333);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(817, 13);
			this.label22.TabIndex = 51;
			this.label22.Text = "non deve essere presente nessun indirizzo attivo del tipo \"Anagrafe delle prestaz" +
    "ioni\", da valorizzare solo per i dipendenti di altri Enti Pubblici.";
			// 
			// Frm_servicetrasmission_default
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(1026, 544);
			this.Controls.Add(this.tabControl1);
			this.Name = "Frm_servicetrasmission_default";
			this.Text = "Frm_servicetrasmission_default";
			this.tabControl1.ResumeLayout(false);
			this.tabDipendenti.ResumeLayout(false);
			this.tabDipendenti.PerformLayout();
			this.tabConsulenti.ResumeLayout(false);
			this.tabConsulenti.PerformLayout();
			this.tabModifica.ResumeLayout(false);
			this.tabModifica.PerformLayout();
			this.tabCancellazione.ResumeLayout(false);
			this.tabCancellazione.PerformLayout();
			this.tabAltro.ResumeLayout(false);
			this.tabAltro.PerformLayout();
			this.tabAttributi.ResumeLayout(false);
			this.gboxclass05.ResumeLayout(false);
			this.gboxclass05.PerformLayout();
			this.gboxclass04.ResumeLayout(false);
			this.gboxclass04.PerformLayout();
			this.gboxclass03.ResumeLayout(false);
			this.gboxclass03.PerformLayout();
			this.gboxclass02.ResumeLayout(false);
			this.gboxclass02.PerformLayout();
			this.gboxclass01.ResumeLayout(false);
			this.gboxclass01.PerformLayout();
			this.tabErrori.ResumeLayout(false);
			this.tabErrori.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		CQueryHelper QHC;
		QueryHelper QHS;
		

		private string codiceFiscalePa;
		private string codicePaIpa;
		private string codiceAooIpa;
		private string codiceUoIpa;
		
		public void MetaData_AfterLink() {
			meta = MetaData.GetMetaData(this);
			QHC = new CQueryHelper();
			QHS = meta.Conn.GetQueryHelper();
			Conn = meta.Conn;
			meta.CanCancel = false;
			GetData.SetSorting(DS.servicetrasmissionkind, "listingorder asc");
			int esercizioCurr = (int) meta.GetSys("esercizio");
			int esercizioPrec = esercizioCurr - 1;

			DataAccess.SetTableForReading(DS.sorting01, "sorting");
			DataAccess.SetTableForReading(DS.sorting02, "sorting");
			DataAccess.SetTableForReading(DS.sorting03, "sorting");
			DataAccess.SetTableForReading(DS.sorting04, "sorting");
			DataAccess.SetTableForReading(DS.sorting05, "sorting");

			DataTable tUniConfig = Conn.RUN_SELECT("uniconfig", "*", null,
				null, null, null, true);
			if ((tUniConfig != null) && (tUniConfig.Rows.Count > 0)) {
				DataRow r = tUniConfig.Rows[0];
				object idsorkind1 = r["idsorkind01"];
				object idsorkind2 = r["idsorkind02"];
				object idsorkind3 = r["idsorkind03"];
				object idsorkind4 = r["idsorkind04"];
				object idsorkind5 = r["idsorkind05"];
				CfgFn.SetGBoxClass0(this, 1, idsorkind1);
				CfgFn.SetGBoxClass0(this, 2, idsorkind2);
				CfgFn.SetGBoxClass0(this, 3, idsorkind3);
				CfgFn.SetGBoxClass0(this, 4, idsorkind4);
				CfgFn.SetGBoxClass0(this, 5, idsorkind5);
				if (idsorkind1 == DBNull.Value && idsorkind2 == DBNull.Value &&
				    idsorkind3 == DBNull.Value && idsorkind4 == DBNull.Value && idsorkind5 == DBNull.Value) {
					tabControl1.TabPages.Remove(tabAttributi);
				}
				codicePaIpa = r["perla_codicepaipa"]==DBNull.Value? null: r["perla_codicepaipa"].ToString();
				codiceAooIpa = r["perla_codiceaoopa"]==DBNull.Value? null: r["perla_codiceaoopa"].ToString();  
				codiceUoIpa = r["perla_codiceuopa"]==DBNull.Value? null: r["perla_codiceuopa"].ToString();
				codiceFiscalePa = r["perla_codicefiscalepa"]==DBNull.Value? null: r["perla_codicefiscalepa"].ToString();
				if (codiceAooIpa != null) codiceUoIpa = null; //Sono sempre mutualm. esclusivi

			}
			

			if (codiceFiscalePa == null) {
				var cf = Conn.readValue("license", null, "cf");
				codiceFiscalePa = (cf == DBNull.Value) ? null : cf.ToString();
			}

			apActivitykind = Conn.readSimpleDictionary<string, string>("apactivitykind", q.eq("ayear", esercizioCurr),
				"idapactivitykind", "description");

			var model = MetaFactory.factory.getSingleton<IMetaModel>();
			model.denyClear(DS.serviceregistry);
			model.denyClear(DS.servicepayment);

			model.lockRead(DS.serviceregistry);
			model.lockRead(DS.servicepayment);
		}

		private Dictionary<string, string> apActivitykind;
	
		/// <summary>
		/// Effettia dei controlli sulle prestazioni presenti su db
		/// </summary>
		/// <param name="kind"></param>
		/// <returns></returns>
		private bool controlla_validita_codici(string kind, tipoIncarico tipo_incarico) {
			int anno = (kind.ToLowerInvariant() == "d") ? getAnnoDipendenti() : getAnnoConsulenti();
			int numero = (kind.ToLowerInvariant() == "d") ? getNumeroDipendenti() : getNumeroConsulenti();
			bool error = false;
			string mess1 = " ";
			string mess2 = " ";
			string mess3 = " ";
			string mess4 = " ";
			string mess5 = " ";
			string mess6 = " ";
			string mess7 = " ";
			string mess8 = " ";
			string filterAnno = (anno == 0) ? "" : $" AND (yservreg= {anno}) ";
			string filterNumero = (numero == 0) ? "" : $" AND (nservreg= {numero}) ";
			string filterIncarico = "";
			
			if (tipo_incarico == tipoIncarico.nuovoIncarico) {
				filterIncarico = filtroNuovoIncarico;
			}
			
			if (tipo_incarico == tipoIncarico.modificaIncarico) {
				filterIncarico = filtroModificaIncarico;
			}

			if (tipo_incarico == tipoIncarico.cancellaIncarico) {
				filterIncarico = filtroCancellaIncarico;
			}

			String MyQuery =
				" ( SELECT yservreg, nservreg FROM serviceregistry " +
				" JOIN financialactivity " +
				" ON serviceregistry.idfinancialactivity=financialactivity.idfinancialactivity " +
				" left outer JOIN serviceregistrykind " +
				" ON serviceregistry.idserviceregistrykind=serviceregistrykind.idserviceregistrykind " +
				" WHERE financialactivity.ayear = yservreg and financialactivity.active='N' and  ( serviceregistrykind.totransmit = 'S' or serviceregistry.idserviceregistrykind is null)"
					+ filterAnno
					+ filterNumero
					+ " AND " + filterIncarico
					+")";
			
			if (kind == "d") {
				DataTable financialactivity = meta.Conn.SQLRunner(MyQuery);
				foreach (DataRow R in financialactivity.Rows) {
					mess1 = mess1 + R["nservreg"].ToString() + "/" + R["yservreg"].ToString() + "," + " ";
				}

				if (financialactivity.Rows.Count != 0) {
					mess1 = "I seguenti incarichi:" + mess1 + " hanno codice Attività Economica non valido. \n\r";
					error = true;
				}
			}

			MyQuery =
				" ( SELECT yservreg, nservreg FROM serviceregistry " +
				" JOIN apcontractkind " +
				" ON serviceregistry.idapcontractkind=apcontractkind.idapcontractkind " +
				" left outer JOIN serviceregistrykind " +
				" ON serviceregistry.idserviceregistrykind=serviceregistrykind.idserviceregistrykind " +
				" WHERE apcontractkind.ayear = yservreg and apcontractkind.active='N' and  ( serviceregistrykind.totransmit = 'S' or serviceregistry.idserviceregistrykind is null)"+
				 filterAnno + filterNumero + " AND " +  filterIncarico + ")";
			if (kind == "c") {
				DataTable apcontractkind = meta.Conn.SQLRunner(MyQuery);
				foreach (DataRow R in apcontractkind.Rows) {
					mess2 = mess2 + R["nservreg"].ToString() + "/" + R["yservreg"].ToString() + "," + " ";
				}

				if (apcontractkind.Rows.Count != 0) {
					mess2 = "I seguenti incarichi:" + mess2 + " hanno codice Tipo Rapporto non valido. \n\r";
					error = true;
				}
			}

			MyQuery =
				" ( SELECT yservreg, nservreg FROM serviceregistry " +
				" JOIN acquirekind " +
				" ON serviceregistry.idacquirekind=acquirekind.idacquirekind " +
				" left outer JOIN serviceregistrykind " +
				" ON serviceregistry.idserviceregistrykind=serviceregistrykind.idserviceregistrykind " +
				" WHERE acquirekind.ayear = yservreg and acquirekind.active='N' and  ( serviceregistrykind.totransmit = 'S' or serviceregistry.idserviceregistrykind is null) "+
				filterAnno + filterNumero + " AND " +  filterIncarico + ")";
			if (kind == "c") {
				DataTable acquirekind = meta.Conn.SQLRunner(MyQuery);
				foreach (DataRow R in acquirekind.Rows) {
					mess3 = mess3 + R["nservreg"].ToString() + "/" + R["yservreg"].ToString() + "," + " ";
				}

				if (acquirekind.Rows.Count != 0) {
					mess3 = "I seguenti incarichi:" + mess3 + " hanno codice Modalità Acquisizione non valido. \n\r";
					error = true;
				}
			}

			MyQuery =
				" SELECT yservreg, nservreg FROM serviceregistry " +
				" JOIN serviceregistrykind " +
				" ON serviceregistry.idserviceregistrykind=serviceregistrykind.idserviceregistrykind " +
				" WHERE (yservreg> year(stop) and year(stop) is not null and serviceregistrykind.totransmit = 'S')"+ filterAnno + filterNumero
				+ " AND " +  filterIncarico;



			DataTable Dataincarico = meta.Conn.SQLRunner(MyQuery);
			foreach (DataRow R in Dataincarico.Rows) {
				mess4 = mess4 + R["nservreg"].ToString() + "/" + R["yservreg"].ToString() + "," + " ";
			}

			if (Dataincarico.Rows.Count != 0) {
				mess4 = "I seguenti incarichi:" + mess4 + " hanno Esercizio Incarico incoerente con " +
				        " il periodo della prestazione. \n\r";
				error = true;
			}

			MyQuery =
				" SELECT yservreg, nservreg FROM serviceregistry " +
				" JOIN serviceregistrykind " +
				" ON serviceregistry.idserviceregistrykind=serviceregistrykind.idserviceregistrykind " +
				" WHERE ( (conferring_piva is not null and len(conferring_piva)<>11) " +
				" or (pa_cf is not null and len(pa_cf)<>11 and len(pa_cf)<>16) )" +
				"  and serviceregistrykind.totransmit = 'S'" + filterAnno + filterNumero + " AND " + filterIncarico;
			if (kind == "d") {
				DataTable PivaConferenteErrata = meta.Conn.SQLRunner(MyQuery);
				foreach (DataRow R in PivaConferenteErrata.Rows) {
					mess5 = mess5 + R["nservreg"].ToString() + "/" + R["yservreg"].ToString() + "," + " ";
				}

				if (PivaConferenteErrata.Rows.Count != 0) {
					mess5 = "I seguenti incarichi: \n\r" + mess5 +
					        "\n\r hanno la Partita IVA o il Codice Fiscale del conferente con lunghezza errata.\n\r";
					error = true;
				}
			}

			MyQuery =
				" SELECT yservreg, nservreg FROM serviceregistry " +
				" left outer JOIN serviceregistrykind " +
				" ON serviceregistry.idserviceregistrykind=serviceregistrykind.idserviceregistrykind " +
				" WHERE serviceregistry.employkind = 'D' and  start is null and  ( serviceregistrykind.totransmit = 'S' or serviceregistry.idserviceregistrykind is null) "
					+ filterAnno + filterNumero + " AND " + filterIncarico;
			if (kind == "d") {
				DataTable DataInizioNull = meta.Conn.SQLRunner(MyQuery);
				foreach (DataRow R in DataInizioNull.Rows) {
					mess6 = mess6 + R["nservreg"].ToString() + "/" + R["yservreg"].ToString() + "," + " ";
				}

				if (DataInizioNull.Rows.Count != 0) {
					mess6 = "I seguenti incarichi a dipendenti:\n\r" + mess6 +
					        " \n\r hanno Data Inizio non valorizzata.\n\r";
					error = true;
				}
			}

			MyQuery =
				" SELECT yservreg, nservreg FROM serviceregistry " +
				" left outer JOIN serviceregistrykind " +
				" ON serviceregistry.idserviceregistrykind=serviceregistrykind.idserviceregistrykind " +
				" WHERE serviceregistry.employkind = 'D' and ( substring(conferring_piva,1,1) between '0' and '9')  and " +
				" ((idapregistrykind = 6 and yservreg<2019 ) or (idapregistrykind = 5 and yservreg>=2019 ))  "+	//era 6
					"and ( serviceregistrykind.totransmit = 'S' or serviceregistry.idserviceregistrykind is null)" + filterAnno + filterNumero
				+ " AND " +  filterIncarico;
			if (kind == "d") {
				DataTable PivaConferente = meta.Conn.SQLRunner(MyQuery);
				foreach (DataRow R in PivaConferente.Rows) {
					mess7 = mess7 + R["nservreg"].ToString() + "/" + R["yservreg"].ToString() + "," + " ";
				}

				if (PivaConferente.Rows.Count != 0) {
					mess7 = "I seguenti incarichi a dipendenti:\n\r" + mess7 +
					        " \n\r hanno Conferente = PERSONA GIURIDICA SENZA CF RILASCIATO IN ITALIA ma la p.iva non è estera.\n\r";
					error = true;
				}
			}

			MyQuery =
				" SELECT SR.yservreg, SR.nservreg FROM serviceregistry SR " +
				" join registry A " +
				" 	on SR.idreg = A.idreg " +
				" left outer JOIN serviceregistrykind " +
				" ON SR.idserviceregistrykind=serviceregistrykind.idserviceregistrykind " +
				" where len(SR.cf) = 16 and isnull(SR.flaghuman,'N') = 'N' and SR.employkind <>'D' " +
				" and A.idregistryclass = 22 and (serviceregistrykind.totransmit= 'S' or SR.idserviceregistrykind is null )"
				+ filterAnno + filterNumero + " AND " +  filterIncarico;
			if (kind == "c") {
				DataTable PF_Societa = meta.Conn.SQLRunner(MyQuery);
				foreach (DataRow R in PF_Societa.Rows) {
					mess8 = mess8 + R["nservreg"].ToString() + "/" + R["yservreg"].ToString() + "," + " ";
				}

				if (PF_Societa.Rows.Count != 0) {
					mess8 = "I seguenti incarichi a consulenti:\n\r" + mess8 +
					        " \n\r hanno Tipologia consulente =Società ma sono registrate nell'Anagrafica come Persona Fisica, infatti hanno il codice Fiscale di 16 cifre.\n\r";
					error = true;
				}
			}

			if (error) {
				show(this,
					"Sono stati riscontrati i seguenti impedimenti che causeranno lo scarto del file XML.\n\r" + mess1 +
					mess2 + mess3
					+ mess4 + mess5 + mess6 + mess7 + mess8);
			}

			return true;
		}

		public void MetaData_AfterClear() {
			DS.serviceregistry.Clear();
			DS.servicepayment.Clear();

			//txtNomeFile.Text = null;
			//btnVisualizzaFile.Enabled = false;
			//btnSalvaXml.Enabled = false;
			//btnSalvaFile.Enabled = false;

			btnInviaConsulenti2SemWS.Enabled = false;
			btnInviaDipendentiWS.Enabled = false;
			btnModificaDatiConsulentiWS.Enabled = false;
			btnModificaDatiDipendentiWS.Enabled = false;
			btnCancellazioneConsulentiWS.Enabled = false;
			btnCancellazioneDipendentiWS.Enabled = false;
			btnannullaD.Enabled = false;
			btnAnnullaC.Enabled = false;
			//webBrowser1.DocumentStream = null;
			//cmbTipologia.Enabled = true;
		}

		public void MetaData_BeforePost() {
			if (DS.servicetrasmission.Rows.Count == 0) {
				DS.RejectChanges();
			}
		}

		//public void MetaData_AfterFill() {
		//    cmbTipologia.Enabled = false;
		//}

		public void MetaData_AfterFill() {
			//cmbTipologia.Enabled = false;

			btnInviaConsulenti2SemWS.Enabled = abilitaNuoviInvii();
			btnInviaDipendentiWS.Enabled = abilitaNuoviInvii();
			btnModificaDatiConsulentiWS.Enabled = abilitaNuoviInvii();
			btnModificaDatiDipendentiWS.Enabled = abilitaNuoviInvii();
			btnCancellazioneConsulentiWS.Enabled = abilitaNuoviInvii();
			btnCancellazioneDipendentiWS.Enabled = abilitaNuoviInvii();
			btnannullaD.Enabled = (meta.InsertMode);
			btnAnnullaC.Enabled = (meta.InsertMode);

			if (!meta.FirstFillForThisRow) return;
			//btnVisualizzaFile.Enabled = AbilitaDisabilitaVisualizzaFile();
			//btnSalvaXml.Enabled = AbilitaDisabilitaVisualizzaFile();
		}

		bool abilitaNuoviInvii() {
			if (meta.IsEmpty) return false;

			if (meta.InsertMode) return true;
			DataRow Curr = DS.servicetrasmission.Rows[0];
			if (Curr["rtf"] == DBNull.Value) {
				return true;
			}

			return false;

		}

		public bool AbilitaDisabilitaVisualizzaFile() {
			if (meta.IsEmpty) return false;

			if (meta.InsertMode) return false;
			DataRow Curr = DS.servicetrasmission.Rows[0];
			if (Curr["rtf"] == DBNull.Value) {
				return false;
			}

			return true;
		}

	

		

		List<dipendente_typeNuovoPagamento> esportaPagamentoDipendente(DataRow R, string filter, string tag,
			bool cancellapagamento) {
			List<dipendente_typeNuovoPagamento> listaPag = new List<dipendente_typeNuovoPagamento>();
			//string filtropagamento;          
			if (R["employkind"].ToString().ToUpper() != "D") {
				foreach (DataRow Pag in DS.servicepayment.Select(filter, "semesterpay")) {
					var wsPag = new consulente_typeNuovoPagamento();
					writer.WriteStartElement(tag);
					scriviXml(Pag,
						new string[] {"anno", "semestre"},
						new string[] {"ypay", "semesterpay"});
					wsPag.anno = Pag["ypay"].ToString();
					wsPag.semestre = Pag["semesterpay"].ToString();
					if (!cancellapagamento) {
						decimal payedamount = (CfgFn.GetNoNullDecimal(Pag["payedamount"]));
						writer.WriteAttributeString("importo", sostituiscivirgolaconpunto(payedamount));
						wsPag.importo = payedamount;
					}

					//listaPag.Add(wsPag);
					writer.WriteEndElement();
					setPayment_Blocked(Pag);
				}
			}
			else { // se è un Dipendente non deve scrivere il semestre e sommare gli importi
				DataRow[] allPayments = DS.servicepayment.Select(filter);
				if (allPayments.Length > 0) {
					var wsPag = new dipendente_typeNuovoPagamento();
					DataRow first = allPayments[0];
					decimal totale = 0;
					writer.WriteStartElement(tag);
					writer.WriteAttributeString("anno", first["ypay"].ToString());
					wsPag.anno = first["ypay"].ToString();
					foreach (DataRow curr in allPayments) {
						totale += CfgFn.GetNoNullDecimal(curr["payedamount"]);
						setPayment_Blocked(curr);
					}

					if (!cancellapagamento) {
						writer.WriteAttributeString("importo", sostituiscivirgolaconpunto(totale));
						wsPag.importo = totale;
					}

					listaPag.Add(wsPag);
					writer.WriteEndElement();
				}
			}

			return listaPag;
		}


		List<consulente_typeNuovoPagamento> esportaPagamentoConsulente(DataRow R, string filter, string tag,
			bool cancellapagamento) {
			List<consulente_typeNuovoPagamento> listaPag = new List<consulente_typeNuovoPagamento>();
			//string filtropagamento;          
			if (R["employkind"].ToString().ToUpper() != "D") {
				foreach (DataRow Pag in DS.servicepayment.Select(filter, "semesterpay")) {
					var wsPag = new consulente_typeNuovoPagamento();
					writer.WriteStartElement(tag);
					scriviXml(Pag,
						new string[] {"anno", "semestre"},
						new string[] {"ypay", "semesterpay"});
					wsPag.anno = Pag["ypay"].ToString();
					wsPag.semestre = Pag["semesterpay"].ToString();
					if (!cancellapagamento) {
						decimal payedamount = (CfgFn.GetNoNullDecimal(Pag["payedamount"]));
						writer.WriteAttributeString("importo", sostituiscivirgolaconpunto(payedamount));
						wsPag.importo = payedamount;
					}

					//listaPag.Add(wsPag);
					writer.WriteEndElement();
					setPayment_Blocked(Pag);
				}
			}
			else { // se è un Dipendente non deve scrivere il semestre e sommare gli importi
				DataRow[] allPayments = DS.servicepayment.Select(filter);
				if (allPayments.Length > 0) {
					var wsPag = new dipendente_typeNuovoPagamento();
					DataRow first = allPayments[0];
					decimal totale = 0;
					writer.WriteStartElement(tag);
					writer.WriteAttributeString("anno", first["ypay"].ToString());
					wsPag.anno = first["ypay"].ToString();
					foreach (DataRow curr in allPayments) {
						totale += CfgFn.GetNoNullDecimal(curr["payedamount"]);
						setPayment_Blocked(curr);
					}

					if (!cancellapagamento) {
						writer.WriteAttributeString("importo", sostituiscivirgolaconpunto(totale));
						wsPag.importo = totale;
					}

					//listaPag.Add(wsPag);
					writer.WriteEndElement();
				}
			}

			return listaPag;
		}

		//        void esportasaldoincaricoOLD(string employkind)
		//        {
		////Se ho Tx la cancellazione dell'incarico non devo Tx anche il SaldoIncarico,

		////quindi x la Tx del SaldoIncarico scarto gli incarichi di cui ha trasmesso la cancellazione

		//            string scartoCancIncaricoTx = QHC.AppAnd(QHC.CmpNe("is_delivered", 'N'), QHC.CmpNe("is_annulled", 'S'),
		//                QHC.CmpEq("is_blocked", 'S'));
		//            string saldo_daTx = QHC.AppAnd(QHC.CmpEq("employkind", employkind), QHC.CmpEq("payment", 'S'));

		//            saldo_daTx = GetData.MergeFilters(scartoCancIncaricoTx,saldo_daTx);
		//            foreach(DataRow rincaricato in  DS.serviceregistry.Select(saldo_daTx))
		//            {
		//                writer.WriteStartElement("saldoIncarico");// esporto Saldo Incarico
		//                string Incarico = QHC.CmpEq("id_service", rincaricato["id_service"]);

		//                DataRow [] saldoincarico = DS.serviceregistry.Select(QHC.AppAnd(Incarico, saldo_daTx));
		//                foreach (DataRow Rsaldoincarico in saldoincarico)
		//                {
		////Controlla che ci siano dei pagamenti di saldi non bloccati, ovvero controlla che 
		////ci siano dei pagamenti da trasmettere,x evitare la scrittura nel file xml dei soli campi id e saldo.
		//                    if (DS.servicepayment.Select(QHC.AppAnd(QHC.CmpEq("yservreg", Rsaldoincarico["yservreg"]),
		//                        QHC.CmpEq("nservreg", Rsaldoincarico["nservreg"]), QHC.CmpEq("is_blocked", 'N'))).Length >0) 
		//                    {
		//                        writer.WriteAttributeString("id",Rsaldoincarico["id_service"].ToString());
		//                        writer.WriteAttributeString("saldo","true");

		//                        esportaPagamento(Rsaldoincarico,filtroNuovoPagamento, "nuovoPagamento", false);
		//                        esportaPagamento(Rsaldoincarico,filtroCancellaPagamento, "cancellaPagamento", true);
		//                        esportaPagamento(Rsaldoincarico,filtroModificaPagamento, "modificaPagamento", false);

		//                        blocked_incarico(rincaricato);
		//                    }
		//                }
		//                writer.WriteEndElement();//Saldo Incarico
		//            }
		//        }

		void setIncarico_Blocked(DataRow R) {
			if (R == null) return;
			R["is_blocked"] = 'S';

		}

		void setPayment_Blocked(DataRow R) {
			if (R == null) return;
			R["is_blocked"] = 'S';
		}

		

		private void scriviXml(DataRow row, string[] col, string[] sourcecol) {
			for (int i = 0; i < col.Length; i++) {
				string c = col[i];
				string source = sourcecol[i];
				if (!(row[source] is DBNull)) {
					if (row[source] is DateTime) {
						//lavora i DateTime
						DateTime d = (DateTime) row[source];
						writer.WriteAttributeString(c.ToString(), d.ToString("yyyy-MM-dd"));
					}
					else {
						if (row[source] is Decimal) {
							// Lavora i decimali
							decimal amount = CfgFn.GetNoNullDecimal(row[source]);
							writer.WriteAttributeString(c.ToString(), sostituiscivirgolaconpunto(amount));
						}
						else {
							string apostrofo = "'";
							string doppioapice = " \"";
							if ((row[source] is string)
							    && (row[source].ToString().Contains(apostrofo) ||
							        row[source].ToString().Contains(doppioapice))
							) {
								writer.WriteAttributeString(c, row[source].ToString());
							}
							else {
								//Tutto il resto
								writer.WriteAttributeString(c,
									SecurityElement.Escape(row[source].ToString().Replace("\n", "").Replace("\r", "")));
							}
						}

					}
				}
			}
		}

		private string sostituiscivirgolaconpunto(decimal importo) {
			string group = System.Globalization.NumberFormatInfo.CurrentInfo.NumberGroupSeparator;
			string dec = System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
			string s1 = importo.ToString("g").Replace(group, "");
			return s1.Replace(dec, ".");
		}

		private string valore(DataRow r, object valueMember, string displayMember) {
			if (valueMember == DBNull.Value)
				return " is null ";
			return " = " + QueryCreator.quotedstrvalue(r[displayMember], false) + "";
		}

		private void btnGeneraFile_Click(object sender, System.EventArgs e) {
		}


		private void btnApriFile_Click(object sender, System.EventArgs e) {
			if (DS.servicetrasmission.Rows.Count == 0) {
				return;
			}

			if (!meta.GetFormData(false))
				return;

			byte[] xml = (byte[]) DS.servicetrasmission.Rows[0]["rtf"];

			Stream transformedData = new MemoryStream(xml);
			transformedData.Seek(0, SeekOrigin.Begin);
			//webBrowser1.DocumentStream = transformedData;

			//XmlDocument document = new XmlDocument();
			//DialogResult dr = openFileDialog1.ShowDialog(this);
			//if (dr != DialogResult.OK) return;
			//txtNomeFile.Text = openFileDialog1.FileName;
			//try{
			//    runProcess(txtNomeFile.Text, true);
			//    document.Load(txtNomeFile.Text);
			//}
			//catch(Exception ex){
			//    string messaggio = "Non riesco ad aprire il file: " + txtNomeFile.Text +
			//        "\nErrore: " + ex.Message;
			//    show(this,messaggio);
			//    return;
			//}
		}

		/// <summary>
		/// Sblocca tutte le  prestazioni e i pagamenti in sospeso 
		/// </summary>
		/// <param name="tipo"></param>
		/// <returns></returns>
		private bool Annulla(string tipo) {
			DS.serviceregistry.Clear();
			DS.servicepayment.Clear();

			string filter_incarico = "";
			if (tipo.ToUpper() == "D") {
				filter_incarico = QHS.CmpEq("employkind", "D");
			}
			else {
				filter_incarico = QHS.CmpNe("employkind", "D");
			}
			//string keyfilter = "";

			object esercizio = meta.GetSys("esercizio");
			string filtereserc_service = QHS.CmpLe("yservreg", esercizio);
			string filtereserc_payment = QHS.CmpLe("ypay", esercizio);


			String codeaddress = "07_SW_ANP";
			object idaddresskind =
				meta.Conn.DO_READ_VALUE("address", QHS.CmpEq("codeaddress", codeaddress), "idaddress");
			DataTable Address = DataAccess.RUN_SELECT(meta.Conn, "registryaddress", "*", null,
				QHS.CmpEq("idaddresskind", idaddresskind), false);

			// solo per i propri dipendenti
			string filter_own = "";
			if (tipo.ToUpper() == "D") {
				// per i dipendenti filtri solo quelli che non appartengono ad altra amministrazione
				// ovvero non hanno un indirizzo del tipo anagrafe delle prestazioni
				filter_own = QHS.FieldNotIn("idreg", Address.Select(), "idreg");
			}

			string securityServiceRegistry = Conn.SelectCondition("serviceregistry", true);
			securityServiceRegistry = QHS.AppAnd(securityServiceRegistry, getFilterSicurezza());
			if (securityServiceRegistry != null && securityServiceRegistry != "") {
				filter_own = QHS.AppAnd(filter_own, securityServiceRegistry);
			}


			DataAccess.RUN_SELECT_INTO_TABLE(meta.Conn, DS.serviceregistry, null,
				QHS.AppAnd(filter_incarico, filtereserc_service, filter_own, QHS.CmpEq("is_blocked", 'S')), null, true);

			filtereserc_service = QHS.AppAnd(QHS.CmpLe("yservreg", esercizio),
				QHS.CmpEq("is_delivered", "S"),
				//QHS.CmpEq("is_blocked", "N"),
				" EXISTS (SELECT * from servicepayment  SS where " +
				" SS.yservreg=serviceregistry.yservreg and SS.nservreg=serviceregistry.nservreg " +
				" AND SS.is_blocked = 'S' " +
				" AND ((SS.is_delivered ='N' and SS.payedamount > 0 ) OR " +
				"   (SS.is_delivered ='S' and SS.is_changed ='S' ) ) )");

			DataAccess.RUN_SELECT_INTO_TABLE(meta.Conn, DS.serviceregistry, null,
				QHS.AppAnd(filter_incarico, filtereserc_service, filter_own), null, true);


			if (DS.serviceregistry.Rows.Count == 0) {
				show(this, "Non ci sono Incarichi Trasmessi da annullare");
				return false;
			}

			//inserisce in servicepayment solo i pagamenti dei C o D
			foreach (DataRow rSer in DS.serviceregistry.Rows) {
				string filterPayment = QHS.AppAnd(QHS.CmpKey(rSer), QHS.CmpEq("is_blocked", 'S'));
				DataAccess.RUN_SELECT_INTO_TABLE(meta.Conn, DS.servicepayment, null, filterPayment, null, true);
			}


			string mess = (tipo == "d" ? "DIPENDENTI" : "CONSULENTI");
			if (show(this, "Sarà annullata la Trasmissione di TUTTI gli Incarichi e i Pagamenti dei " +
			                          mess + " precedentemente effettuata. Proseguo?",
				    "Avviso", MessageBoxButtons.YesNo) != DialogResult.Yes) return false;

			AnnullaTrasmissione(tipo);
			return true;
		}

		private void AnnullaTrasmissione(string tipo) {
			// Sblocco gli incarichi dei C o D
			foreach (DataRow rincarico in DS.serviceregistry.Select(QHC.CmpEq("is_blocked", 'S'))) {
				rincarico["is_blocked"] = "N";
				rincarico["perla_error"] = DBNull.Value;
			}

			// Sblocco i Pagamenti dei C o D
			foreach (DataRow rpagamento in DS.servicepayment.Select(QHC.CmpEq("is_blocked", 'S'))) {
				rpagamento["is_blocked"] = "N";
				rpagamento["perla_error"] = DBNull.Value;
			}
		}

		private void TrasmissioneApprovata(XmlElement esitoIncarichi, string operationKind) {
			string totalfilter = "";
			string id_incarico = "";
			string idMittente = "";

			//DS.serviceregistry.Clear();
			//DS.servicepayment.Clear();

			//DataAccess.RUN_SELECT_INTO_TABLE(meta.Conn, DS.serviceregistry, null, null, null, true);
			//DataAccess.RUN_SELECT_INTO_TABLE(meta.Conn, DS.servicepayment, null, null, null, true);

			// NUOVI INCARICHI
			if (operationKind == "I") {
				// Consulente
				foreach (XmlElement consulente in esitoIncarichi.GetElementsByTagName("consulente")) {
					totalfilter = "";
					idMittente = consulente.GetAttributeNode("idMittente").Value.ToString();
					id_incarico = consulente.GetAttributeNode("id").Value.ToString();
					string filterConsulente = QHC.CmpEq("senderreporting", idMittente);
					totalfilter = GetData.MergeFilters(filterConsulente,
						QHC.AppAnd(QHC.CmpEq("is_blocked", 'S'), QHC.CmpEq("is_delivered", 'N')));
					DataRow[] rincarico = DS.serviceregistry.Select(totalfilter);
					if (rincarico.Length > 0) {
						if (rincarico[0]["is_blocked"].ToString().ToUpper() == "S") {
							rincarico[0]["is_blocked"] = 'N';
							rincarico[0]["is_delivered"] = 'S';
							rincarico[0]["id_service"] = id_incarico;
						}

						//SbloccaNuoviPagamenti(rincarico[0]);
					}
				}

				// Dipendente
				foreach (XmlElement dipendente in esitoIncarichi.GetElementsByTagName("dipendente")) {
					totalfilter = "";
					idMittente = dipendente.GetAttributeNode("idMittente").Value.ToString();
					id_incarico = dipendente.GetAttributeNode("id").Value.ToString();
					string filterDipendente = QHC.CmpEq("senderreporting", idMittente);
					totalfilter = GetData.MergeFilters(filterDipendente,
						QHC.AppAnd(QHC.CmpEq("is_blocked", 'S'), QHC.CmpEq("is_delivered", 'N')));
					DataRow[] rincarico = DS.serviceregistry.Select(totalfilter);
					if (rincarico.Length > 0) {
						if (rincarico[0]["is_blocked"].ToString().ToUpper() == "S") {
							rincarico[0]["is_blocked"] = 'N';
							rincarico[0]["is_delivered"] = 'S';
							rincarico[0]["id_service"] = id_incarico;
						}

						//SbloccaNuoviPagamenti(rincarico[0]);
					}
				}
			}

			// MODIFICA INCARICHI 
			if (operationKind == "M") {
				// Consulente
				foreach (XmlElement consulente in esitoIncarichi.GetElementsByTagName("consulente")) {
					idMittente = consulente.GetAttributeNode("idMittente").Value.ToString();
					string filterConsulente = QHC.AppAnd(QHC.CmpEq("senderreporting", idMittente),
						QHC.CmpEq("id_service", id_incarico));
					DataRow[] rincarico = DS.serviceregistry.Select(filterConsulente);
					if (rincarico.Length > 0) {
						if (rincarico[0]["is_blocked"].ToString().ToUpper() == "S") {
							rincarico[0]["is_blocked"] = 'N';
							rincarico[0]["is_changed"] = 'N';
							rincarico[0]["is_delivered"] = 'S';
						}

						//SbloccaNuoviPagamenti(rincarico[0]);
						//SbloccaModificaPagamenti(rincarico[0]);
						//SbloccaCancellaPagamenti(rincarico[0]);
					}
				}

				//// Dipendenti
				foreach (XmlElement dipendente in esitoIncarichi.GetElementsByTagName("dipendente")) {
					idMittente = dipendente.GetAttributeNode("idMittente").Value.ToString();
					string filterDipendente = QHC.AppAnd(QHC.CmpEq("senderreporting", idMittente),
						QHC.CmpEq("id_service", id_incarico));
					DataRow[] rincarico = DS.serviceregistry.Select(filterDipendente);
					if (rincarico.Length > 0) {
						if (rincarico[0]["is_blocked"].ToString().ToUpper() == "S") {
							rincarico[0]["is_blocked"] = 'N';
							rincarico[0]["is_changed"] = 'N';
							rincarico[0]["is_delivered"] = 'S';
						}

						//SbloccaNuoviPagamenti(rincarico[0]);
						//SbloccaModificaPagamenti(rincarico[0]);
						//SbloccaCancellaPagamenti(rincarico[0]);
					}
				}
			}

			// CANCELLAZIONE INCARICHI 
			if (operationKind == "C") {
				// Consulente
				foreach (XmlElement consulente in esitoIncarichi.GetElementsByTagName("consulente")) {
					idMittente = consulente.GetAttributeNode("idMittente").Value.ToString();
					string filterConsulente = QHC.CmpEq("senderreporting", idMittente);
					DataRow[] rincarico = DS.serviceregistry.Select(filterConsulente);
					if (rincarico.Length > 0) {
						rincarico[0]["is_blocked"] = 'N';
						rincarico[0]["is_delivered"] = 'S';
						rincarico[0]["idrelated"] = DBNull.Value;
					}
				}

				//// Dipendente
				foreach (XmlElement dipendente in esitoIncarichi.GetElementsByTagName("dipendente")) {
					idMittente = dipendente.GetAttributeNode("idMittente").Value.ToString();
					string filterDipendente = QHC.CmpEq("senderreporting", idMittente);
					DataRow[] rincarico = DS.serviceregistry.Select(filterDipendente);
					if (rincarico.Length > 0) {
						rincarico[0]["is_blocked"] = 'N';
						rincarico[0]["is_delivered"] = 'S';
						rincarico[0]["idrelated"] = DBNull.Value;
					}
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="service"></param>
		/// <param name="esitoIncarichi"></param>
		/// <param name="operationKind">I Inserimento M Modifica C Cancellazione</param>
			private void TrasmissioneApprovata(DataRow rincarico, XmlElement esitoIncarichi, string operationKind) {
			rincarico["is_blocked"] = 'N';
			rincarico["is_delivered"] = 'S';
			rincarico["is_changed"] = 'N';

			XmlNamespaceManager nsmgr = new XmlNamespaceManager(esitoIncarichi.OwnerDocument.NameTable);
			nsmgr.AddNamespace("ab", "http://perlapa.gov.it/");

			// NUOVI INCARICHI
			if (operationKind == "I") {
				var listaIncarichi = esitoIncarichi.SelectSingleNode("//ab:idIncarico", nsmgr);
				if (listaIncarichi != null) {
					foreach (XmlText idIncarico in listaIncarichi) {
						if (idIncarico == null) continue;
						rincarico["id_service"] = idIncarico.Value;
					}
				}

				// Consulente
				listaIncarichi = esitoIncarichi.SelectSingleNode("//ab:consulente", nsmgr);
				if (listaIncarichi != null) {
					foreach (XmlElement consulente in listaIncarichi) {
						if (consulente == null) continue;
						rincarico["id_service"] = consulente.GetAttributeNode("id").Value;
					}
				}

				// Dipendente
				listaIncarichi = esitoIncarichi.SelectSingleNode("//ab:dipendente", nsmgr);
				if (listaIncarichi != null) {
					foreach (XmlElement dipendente in listaIncarichi) {
						if (dipendente == null) continue;
						rincarico["id_service"] = dipendente.GetAttributeNode("id").Value;
					}
				}

				//foreach (DataRow Pag in DS.servicepayment.Select(QHC.CmpEq("yservreg", rincarico["yservreg"]),
				//	QHC.CmpEq("nservreg", rincarico["nservreg"]))) {
				//	Pag["is_blocked"] = 'N';
				//	Pag["is_changed"] = 'N';
				//	Pag["is_delivered"] = 'S';
				//}
			}

			// MODIFICA INCARICHI 
			//if (operationKind == "M") {
			//	foreach (DataRow Pag in DS.servicepayment.Select(QHC.CmpEq("yservreg", rincarico["yservreg"]),
			//		QHC.CmpEq("nservreg", rincarico["nservreg"]))) {
			//		Pag["is_blocked"] = 'N';
			//		Pag["is_changed"] = 'N';
			//		Pag["is_delivered"] = 'S';
			//	}

			//}

			// CANCELLAZIONE INCARICHI 
			if (operationKind == "C") {
				rincarico["idrelated"] = DBNull.Value;
			}



		}

		private string decodificaXML(XmlAttribute valoreletto) {
			if (valoreletto == null) {
				return " is null ";
			}

			string valoredecodificato = valoreletto.Value.ToString();
			return " = " + QueryCreator.quotedstrvalue(valoredecodificato, false) + " ";
		}

		private string decodificadoveriUfficio(XmlAttribute valoreletto) {
			if (valoreletto == null) {
				return " is null ";
			}

			string valoredecodificato = (valoreletto.Value.ToString().ToUpper() == "2" ? "S" : "N");
			return " = " + QueryCreator.quotedstrvalue(valoredecodificato, false) + " ";
		}

		private string decodificaBool(XmlAttribute valoreletto) {
			if (valoreletto == null)
				return " is null ";

			string valoredecodificato = (valoreletto.Value.ToString().ToUpper() == "TRUE" ? "S" : "N");
			return " = " + QueryCreator.quotedstrvalue(valoredecodificato, false) + " ";
		}

		private string decodificaImporto(XmlAttribute valoreletto) {
			// sostituisce '.' con  ','
			if (valoreletto == null) return " = 0 ";

			string dec = System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
			decimal amount = Decimal.Parse(valoreletto.Value.Replace(".", dec));
			return " = " + QueryCreator.quotedstrvalue(amount, false) + " ";
		}

		private string decodificaData(XmlAttribute valoreletto) {
			if (valoreletto == null) {
				return " is null ";
			}

			string valoredecodificato = valoreletto.Value;
			DateTime data = DateTime.ParseExact(valoredecodificato, "yyyy-MM-dd", DateTimeFormatInfo.CurrentInfo);
			return " = " + QueryCreator.quotedstrvalue(data, false) + " ";
		}



		void MessageShow(string message, string title, List<string> msgs = null) {
			if (msgs != null) {
				msgs.Add(title + ": " + message);
			}
			else {
				show(this, message, title, MessageBoxButtons.OK);
			}
		}

		/// <summary>
		/// Elabora il file di ritorno e cambia il dataset in base al suo esito ove positivo
		/// </summary>
		/// <param name="document"></param>
		/// <param name="messages"></param>
		/// <returns></returns>
		private bool ElaboraFileRitorno(XmlDocument document, List<string> messages = null) {
			XmlElement Comunicazione = document.DocumentElement;
			// ESITO INSERIMENTO INCARICHI

			foreach (XmlElement esitoInserimentoIncarichi in Comunicazione.GetElementsByTagName("esitoInserimentoIncarichi")) {
				XmlAttribute esitoFile = esitoInserimentoIncarichi.GetAttributeNode("esitoFile");
				if (esitoFile.Value.ToString().ToUpper() == "KO") {
					MessageShow(
						"Il file Trasmesso è stato elaborato con Esito Errato. Verificare gli errori segnalati nel file.",
						"Attenzione", messages);
					return false;
				}

				foreach (XmlElement esitoNuoviIncarichi in esitoInserimentoIncarichi.GetElementsByTagName("esitoNuoviIncarichi")) {
					foreach (XmlElement dipendente in esitoNuoviIncarichi.GetElementsByTagName("dipendente")) {
						XmlAttribute esito = dipendente.GetAttributeNode("esito");
						if (esito == null) {
							MessageShow("Controllare che il file selezionato sia quello di Risposta", "Attenzione",
								messages);
							return false;
						}

						if (esito.Value.ToString().ToUpper() == "OK") {
							// show(this, "Il file Trasmesso è stato APPROVATO. Procedere col salvataggio... ");
							TrasmissioneApprovata(esitoNuoviIncarichi, "I");
						}
						else {
							if (esito.Value.ToString().ToUpper() == "KO") {
								XmlAttribute idMittente = dipendente.GetAttributeNode("idMittente");
								MessageShow(
									"Nel file Trasmesso, l'incarico con Identificativo incarico mittente= " +
									idMittente.ToString() + ", risulta ERRATO. Correggere i dati inseriti.", "Errore",
									messages);
								return false;
							}

						}
					}

					foreach (XmlElement consulente in esitoNuoviIncarichi.GetElementsByTagName("consulente")) {
						XmlAttribute esito = consulente.GetAttributeNode("esito");
						if (esito == null) {
							MessageShow("Controllare che il file selezionato sia quello di Risposta", "Attenzione",
								messages);
							return false;
						}

						if (esito.Value.ToString().ToUpper() == "OK") {
							TrasmissioneApprovata(esitoNuoviIncarichi, "I");
						}
						else {
							if (esito.Value.ToString().ToUpper() == "KO") {
								XmlAttribute idMittente = consulente.GetAttributeNode("idMittente");
								MessageShow(
									"Nel file Trasmesso, l'incarico con Identificativo incarico mittente= " +
									idMittente.ToString() + ", risulta ERRATO. Correggere i dati inseriti.", "Errore",
									messages);
								return false;
							}
						}
					}
				}
			}
			// ESITO MODIFICA INCARICHI

			foreach (XmlElement esitoVariazioneIncarichi in Comunicazione.GetElementsByTagName(
				"esitoVariazioneIncarichi")) {
				foreach (XmlElement esitoModificaIncarichi in esitoVariazioneIncarichi.GetElementsByTagName(
					"esitoModificaIncarichi")) {
					foreach (XmlElement dipendente in esitoModificaIncarichi.GetElementsByTagName("dipendente")) {
						var esito = dipendente.GetAttributeNode("esito");
						if (esito == null) {
							MessageShow("Controllare che il file selezionato sia quello di Risposta", "Attenzione",
								messages);
							return false;
						}

						if (esito.Value.ToString().ToUpper() == "OK") {
							// show(this, "Il file Trasmesso è stato APPROVATO. Procedere col salvataggio... ");
							TrasmissioneApprovata(esitoModificaIncarichi, "M");
						}
						else {
							if (esito.Value.ToString().ToUpper() == "KO") {
								var idMittente = dipendente.GetAttributeNode("idMittente");
								MessageShow(
									"Nel file Trasmesso, l'incarico con Identificativo incarico mittente= " +
									idMittente.ToString() + ", risulta ERRATO. Correggere i dati inseriti.", "Errore",
									messages);
								return false;
							}
						}
					}

					foreach (XmlElement consulente in esitoModificaIncarichi.GetElementsByTagName("consulente")) {
						var esito = consulente.GetAttributeNode("esito");
						if (esito == null) {
							MessageShow("Controllare che il file selezionato sia quello di Risposta", "Attenzione",
								messages);
							return false;
						}

						if (esito.Value.ToString().ToUpper() == "OK") {
							TrasmissioneApprovata(esitoModificaIncarichi, "M");
						}
						else {
							if (esito.Value.ToString().ToUpper() == "KO") {
								var idMittente = consulente.GetAttributeNode("idMittente");
								MessageShow(
									"Nel file Trasmesso, l'incarico con Identificativo incarico mittente= " +
									idMittente.ToString() + ", risulta ERRATO. Correggere i dati inseriti.", "Errore",
									messages);
								return false;
							}
						}
					}
				}
			}

			// ESITO CANCELLAZIONI INCARICHI
			foreach (XmlElement esitoCancellazioneIncarichi in Comunicazione.GetElementsByTagName(
				"esitoCancellazioneIncarichi")) {
				foreach (XmlElement esitoIncarichi in esitoCancellazioneIncarichi.GetElementsByTagName("esitoIncarichi")
				) {
					foreach (XmlElement dipendente in esitoIncarichi.GetElementsByTagName("dipendente")) {
						XmlAttribute esito = dipendente.GetAttributeNode("esito");
						if (esito == null) {
							MessageShow("Controllare che il file selezionato sia quello di Risposta", "Attenzione",
								messages);
							return false;
						}

						if (esito.Value.ToString().ToUpper() == "OK") {
							// show(this, "Il file Trasmesso è stato APPROVATO. Procedere col salvataggio... ");
							TrasmissioneApprovata(esitoIncarichi, "C");
						}
						else {
							if (esito.Value.ToString().ToUpper() == "KO") {
								XmlAttribute idMittente = dipendente.GetAttributeNode("idMittente");
								MessageShow(
									"Nel file Trasmesso, l'incarico con Identificativo incarico mittente= " +
									idMittente.ToString() + ", risulta ERRATO. Correggere i dati inseriti.", "Errore",
									messages);
								return false;
							}
						}
					}

					foreach (XmlElement consulente in esitoIncarichi.GetElementsByTagName("consulente")) {
						XmlAttribute esito = consulente.GetAttributeNode("esito");
						if (esito == null) {
							MessageShow("Controllare che il file selezionato sia quello di Risposta", "Attenzione",
								messages);
							return false;
						}

						if (esito.Value.ToString().ToUpper() == "OK") {
							TrasmissioneApprovata(esitoIncarichi, "C");
						}
						else {
							if (esito.Value.ToString().ToUpper() == "KO") {
								XmlAttribute idMittente = consulente.GetAttributeNode("idMittente");
								MessageShow(
									"Nel file Trasmesso, l'incarico con Identificativo incarico mittente= " +
									idMittente.ToString() + ", risulta ERRATO. Correggere i dati inseriti.", "Errore",
									messages);
								return false;
							}
						}
					}
				}
			}

			return true;

		}

		private void richTextBox1_LinkClicked(object sender, System.Windows.Forms.LinkClickedEventArgs e) {
			runProcess(e.LinkText, true);
		}

		bool personaFisica(DataRow r) {
			int anno = CfgFn.GetNoNullInt32(r["yservreg"]);
			if (anno < 2019) {
				return r["idapregistrykind"].ToString() == "3" || r["idapregistrykind"].ToString() == "4";
			}
			return r["idapregistrykind"].ToString() == "2" || r["idapregistrykind"].ToString() == "3";
		}
		bool personaGiuridica(DataRow r) {
			return !personaFisica(r);
		}

		private void UpdateDipendenti(bool modpagamenti, comunicazione_type wsCom) {

			string fieldvalue = "";
			if (modpagamenti) {
				var wsNuoviIncarichi = wsCom.inserimentoIncarichi.nuoviIncarichi;

				if (wsNuoviIncarichi.dipendente == null) {
					wsNuoviIncarichi.dipendente = new dipendente_type[0];
				}

				// Genera il file xml solo per i Pagamenti dei DIPENDENTI
				writer.WriteStartElement("modificaIncarichi"); // Apre - MODIFICA INCARICHI
				List<dipendente_type> wsDipList;

				if (wsNuoviIncarichi.dipendente.Length == 0) {
					wsDipList = new List<dipendente_type>();
				}
				else {
					wsDipList = new List<dipendente_type>(wsNuoviIncarichi.dipendente);
				}

				foreach (
					DataRow rDipendente in
					DS.serviceregistry.Select(QHC.CmpEq("employkind", 'D'))) {

					var wsDipendente = new dipendente_type();

					//Esporto Pagamenti (tutti quelli dell'anno)
					string filtropagamento = QHC.MCmp(rDipendente, new string[] {"yservreg", "nservreg"});
					string filterNew = QHC.AppAnd(filtropagamento, filtroNuovoPagamento);
					string filterMod = QHC.AppAnd(filtropagamento, filtroModificaPagamento);

					if (DS.servicepayment.Select(filterNew).Length > 0 ||
					    DS.servicepayment.Select(filterMod).Length > 0) {

						writer.WriteStartElement("dipendente"); // Apre - DIPENDENTE
						writer.WriteAttributeString("idMittente", rDipendente["senderreporting"].ToString());
						wsDipendente.idMittente = rDipendente["senderreporting"].ToString();

						writer.WriteStartElement("incarico"); // Apre -  INCARICO
						writer.WriteAttributeString("id", rDipendente["id_service"].ToString());
						writer.WriteEndElement(); //incarico             // Chiude - INCARICO

						writer.WriteStartElement("pagamenti"); // Apre PAGAMENTI
						var wsPagamenti = esportaPagamentoDipendente(rDipendente, filterNew, "nuovoPagamento", false);
						wsDipendente.pagamenti = wsPagamenti.ToArray();

						esportaPagamentoDipendente(rDipendente, filterMod, "modificaPagamento", false);
						//esportaPagamento(rDipendente, filtroCancellaPagamento, "cancellaPagamento", true);
						writer.WriteEndElement(); // Chiude PAGAMENTI

						writer.WriteEndElement(); // Chiude - DIPENDENTE



					}

					wsDipList.Add(wsDipendente);
					//blocked_incarico(rDipendente);

				} // Chiude foreach

				wsNuoviIncarichi.dipendente = wsDipList.ToArray();
				wsCom.inserimentoIncarichi.nuoviIncarichi = wsNuoviIncarichi;

				writer.WriteEndElement(); // Chiude - MODIFICA INCARICHI
			}

			else {
				// Genera il file xml solo per le modifiche dei dati dei DIPENDENTI
				writer.WriteStartElement("modificaIncarichi"); // Apre - MODIFICA INCARICHI
				foreach (
					DataRow rDipendente in
					DS.serviceregistry.Select(QHC.AppAnd(QHC.CmpEq("employkind", 'D'), filtroModificaIncarico))) {
					writer.WriteStartElement("dipendente"); // Apre - DIPENDENTE
					writer.WriteAttributeString("idMittente", rDipendente["senderreporting"].ToString());

					writer.WriteStartElement("incaricato"); // Apre - INCARICATO
					scriviXml(rDipendente,
						new string[] {"qualifica"},
						new string[] {"idapmanager"}
					);
					writer.WriteEndElement(); // Chiude - INCARICATO

					writer.WriteStartElement("conferente"); // Apre - CONFERENTE
					scriviXml(rDipendente,
						new string[] {"tipologia", "codiceFiscale", "denominazione"},
						new string[] {"idApregistrykind", "pa_cf", "pa_title"}
					);
					
					

					if (personaGiuridica(rDipendente)) {
						//<personaGiuridica codiceFiscale="" denominazione="" estero="Y/N" tipologiaAzienda="" codiceComuneSede="" />
						writer.WriteStartElement("modificaPersona");
						writer.WriteStartElement("personaGiuridica"); // Apre - personaGiuridica
						writer.WriteAttributeString("codiceFiscale", rDipendente["pa_cf"].ToString());
						writer.WriteAttributeString("denominazione",
							rDipendente["pa_title"].ToString().Replace("\n", "").Replace("\r", ""));
						fieldvalue = rDipendente["conferring_flagforeign"].ToString().ToUpper();
						if (fieldvalue == "S") {
							writer.WriteAttributeString("estero", "Y");
							if (rDipendente["idconsultingkind"].ToString() != "") {
								writer.WriteAttributeString("tipologiaAzienda",
									rDipendente["idconsultingkind"].ToString());
							}
						}
						else {
							writer.WriteAttributeString("estero", "N");
							if (rDipendente["idconsultingkind"].ToString() != "") {
								writer.WriteAttributeString("tipologiaAzienda",
									rDipendente["idconsultingkind"].ToString());
							}

							writer.WriteAttributeString("codiceComuneSede",
								rDipendente["conferring_codcity"].ToString());
						}

						writer.WriteEndElement(); // Chiude - personaGiuridica
						writer.WriteEndElement(); // Chiude - modificaPersona
					}

					if (personaFisica(rDipendente)) {
						//<personaFisica dataNascita="AAAA-MM-GG" sesso="M/F" estero="Y/N" nome="" cognome="" codiceFiscale=""/>
						writer.WriteStartElement("modificaPersona");
						writer.WriteStartElement("personaFisica"); // Apre - personaFisica
						scriviXml(rDipendente,
							new string[] {"dataNascita"},
							new string[] {"conferring_birthdate"}
						);
						writer.WriteAttributeString("sesso", rDipendente["conferring_gender"].ToString());
						writer.WriteAttributeString("estero", rDipendente["conferring_flagforeign"].ToString());
						writer.WriteAttributeString("nome",
							rDipendente["conferring_forename"].ToString().Replace("\n", "").Replace("\r", ""));
						writer.WriteAttributeString("cognome",
							rDipendente["conferring_surname"].ToString().Replace("\n", "").Replace("\r", ""));
						writer.WriteAttributeString("codiceFiscale", rDipendente["pa_cf"].ToString());
						writer.WriteEndElement(); // Chiude - personaFisica
						writer.WriteEndElement(); // Chiude - modificaPersona
					}

					writer.WriteEndElement(); // Chiude - CONFERENTE

					writer.WriteStartElement("incarico"); // Apre -  INCARICO
					writer.WriteAttributeString("id", rDipendente["id_service"].ToString());
					scriviXml(rDipendente,
						new string[] {"tipologia", "dataAutorizzazione", "dataInizio", "dataFine"},
						new string[] {"idapactivitykind", "authorizationdate", "start", "stop"}

					);

					fieldvalue = rDipendente["payment"].ToString().ToUpper();
					switch (fieldvalue) {
						case "S":
							writer.WriteAttributeString("incaricoSaldato", "1");
							break;
						case "N":
							writer.WriteAttributeString("incaricoSaldato", "2");
							break;
						case "Q":
							writer.WriteAttributeString("incaricoSaldato", "3");
							break;
					}

					//writer.WriteAttributeString("incaricoSaldato", (fieldvalue == "S" ? "1" : "2"));
					decimal expectedamount = (CfgFn.GetNoNullDecimal(rDipendente["expectedamount"]));
					writer.WriteAttributeString("importo", sostituiscivirgolaconpunto(expectedamount));

					if (rDipendente["annotation"] != DBNull.Value) {
						writer.WriteAttributeString("note",
							rDipendente["annotation"].ToString().Replace("\n", "").Replace("\r", ""));
					}

					if (rDipendente["idreferencerule"] != DBNull.Value) {
						writer.WriteStartElement("riferimentoNormativo"); // Apre - RIFERIMENTO NORMATIVO
						scriviXml(rDipendente,
							new string[] {"riferimento", "data", "numero", "articolo", "comma"},
							new string[] {"idreferencerule", "referencedate", "articlenumber", "article", "paragraph"}
						);
						writer.WriteEndElement(); // Chiude - RIFERIMENTO NORMATIVO
					}

					writer.WriteEndElement(); //incarico             // Chiude - INCARICO

					string filtropagamento = QHC.MCmp(rDipendente, new string[] {"yservreg", "nservreg"});

					string filterNew = QHC.AppAnd(filtropagamento, filtroNuovoPagamento);
					string filterMod = QHC.AppAnd(filtropagamento, filtroModificaPagamento);

					if (DS.servicepayment.Select(filterNew).Length > 0 ||
					    DS.servicepayment.Select(filterMod).Length > 0) {
						writer.WriteStartElement("pagamenti"); // Apre PAGAMENTI
						esportaPagamentoDipendente(rDipendente, filterNew, "nuovoPagamento", false);
						esportaPagamentoDipendente(rDipendente, filterMod, "modificaPagamento", false);
						//esportaPagamento(rDipendente, filtroCancellaPagamento, "cancellaPagamento", true);
						writer.WriteEndElement(); // Chiude PAGAMENTI
					}

					setIncarico_Blocked(rDipendente);
					writer.WriteEndElement(); // Chiude - DIPENDENTE
				} // Chiude foreach

				writer.WriteEndElement(); // Chiude - MODIFICA INCARICHI

			}
		}

		private void UpdateConsulenti(object semestre, bool modpagamenti, comunicazione_type wsCom) {
			string fieldvalue = "";
			if (modpagamenti) {
				var wsNuoviIncarichi = wsCom.inserimentoIncarichi.nuoviIncarichi;


				if (wsNuoviIncarichi.consulente == null) {
					wsNuoviIncarichi.consulente = new consulente_type[0];
				}

				// Genera il file xml solo per i pagamenti dei CONSULENTI
				writer.WriteStartElement("modificaIncarichi"); // Apre - MODIFICA INCARICHI

				List<consulente_type> wsConsList;

				if (wsNuoviIncarichi.dipendente.Length == 0) {
					wsConsList = new List<consulente_type>();
				}
				else {
					wsConsList = new List<consulente_type>(wsNuoviIncarichi.consulente);
				}


				foreach (
					DataRow rConsulente in
					DS.serviceregistry.Select(QHC.CmpNe("employkind", 'D'))) {
					string filtropagamento = QHC.MCmp(rConsulente, new string[] {"yservreg", "nservreg"});
					string filtroNew = QHC.AppAnd(filtropagamento, filtroNuovoPagamento,
						QHC.CmpEq("semesterpay", semestre));
					string filtroMod = QHC.AppAnd(filtropagamento, filtroModificaPagamento,
						QHC.CmpEq("semesterpay", semestre));

					var wsConsulente = new consulente_type();

					//Esporto Pagamento
					if (DS.servicepayment.Select(filtroNew).Length > 0 ||
					    DS.servicepayment.Select(filtroMod).Length > 0) {
						writer.WriteStartElement("consulente"); // Apre - CONSULENTE
						writer.WriteAttributeString("idMittente", rConsulente["senderreporting"].ToString());
						wsConsulente.idMittente = rConsulente["senderreporting"].ToString();

						writer.WriteStartElement("incarico"); // Apre -  INCARICO
						writer.WriteAttributeString("id", rConsulente["id_service"].ToString());
						writer.WriteEndElement(); //incarico             // Chiude - INCARICO

						writer.WriteStartElement("pagamenti"); // Apre PAGAMENTI
						var wsPagamenti = esportaPagamentoConsulente(rConsulente, filtroNew, "nuovoPagamento", false);
						wsConsulente.pagamenti = wsPagamenti.ToArray();

						esportaPagamentoConsulente(rConsulente, filtroMod, "modificaPagamento", false);
						//esportaPagamento(rConsulente, filtroCancellaPagamento, "cancellaPagamento", true);
						writer.WriteEndElement(); // Chiude PAGAMENTI

						writer.WriteEndElement(); //fine consulente              // Chiude - CONSULENTE
					}

					wsConsList.Add(wsConsulente);
					//blocked_incarico(rConsulente);

				} // Chiude foreach

				wsNuoviIncarichi.consulente = wsConsList.ToArray();
				wsCom.inserimentoIncarichi.nuoviIncarichi = wsNuoviIncarichi;

				writer.WriteEndElement(); //fine nuoviIncarichi          // Chiude - MODIFICA INCARICHI
			}
			else {
				// Genera il file xml solo per le modifcihe algli incarichi dei CONSULENTI
				writer.WriteStartElement("modificaIncarichi"); // Apre - MODIFICA INCARICHI
				foreach (
					DataRow rConsulente in
					DS.serviceregistry.Select(QHC.AppAnd(QHC.CmpNe("employkind", 'D'), filtroModificaIncarico))) {
					string filtropagamento = QHC.MCmp(rConsulente, new string[] {"yservreg", "nservreg"});
					string filtroNew = QHC.AppAnd(filtropagamento, filtroNuovoPagamento,
						QHC.CmpEq("semesterpay", semestre));
					string filtroMod = QHC.AppAnd(filtropagamento, filtroModificaPagamento,
						QHC.CmpEq("semesterpay", semestre));


					writer.WriteStartElement("consulente"); // Apre - CONSULENTE
					writer.WriteAttributeString("idMittente", rConsulente["senderreporting"].ToString());

					writer.WriteStartElement("incarico"); // Apre -  INCARICO
					writer.WriteAttributeString("id", rConsulente["id_service"].ToString());
					if (CfgFn.GetNoNullInt32(rConsulente["yservreg"]) < 2011) {
						// Cambia il nome del campo attività economica: fino al 2010 è idfinancialactivity, dal 2011 diventa apfinancialactivitycode.
						scriviXml(rConsulente,
							new string[] {
								"modalitaAcquisizione", "tipoRapporto",
								"attivitaEconomica", "descrizioneIncarico"
							},
							new string[] {
								"referencesemester", "idacquirekind", "idapcontractkind",
								"idfinancialactivity", "description"
							}
						);
					}
					else {
						scriviXml(rConsulente,
							new string[] {"modalitaAcquisizione", "tipoRapporto"},
							new string[] {"idacquirekind", "idapcontractkind"}
						);
						object apfinancialactivitycode_obj = meta.Conn.DO_READ_VALUE("apfinancialactivity",
							QHS.CmpEq("idapfinancialactivity", rConsulente["idapfinancialactivity"]),
							"apfinancialactivitycode");
						string apfinancialactivitycode = "";
						if ((apfinancialactivitycode_obj != DBNull.Value) && (apfinancialactivitycode_obj != null))
							// dal 3 marzo 2011
							apfinancialactivitycode = apfinancialactivitycode_obj.ToString();
						else // fino al 2 marzo 2011
							apfinancialactivitycode = rConsulente["idfinancialactivity"].ToString();
						writer.WriteAttributeString("attivitaEconomica", apfinancialactivitycode);
						writer.WriteAttributeString("descrizioneIncarico",
							rConsulente["description"].ToString().Replace("\n", "").Replace("\r", ""));

					}

					fieldvalue = rConsulente["regulation"].ToString().ToUpper();
					writer.WriteAttributeString("riferimentoRegolamento", (fieldvalue == "S" ? "Y" : "N"));
					scriviXml(rConsulente,
						new string[] {"dataAffidamento", "dataInizio", "dataFine"},
						new string[] {"expectationsdate", "start", "stop"}
					);
					fieldvalue = rConsulente["payment"].ToString().ToUpper();
					switch (fieldvalue) {
						case "S":
							writer.WriteAttributeString("incaricoSaldato", "1");
							break;
						case "N":
							writer.WriteAttributeString("incaricoSaldato", "2");
							break;
						case "Q":
							writer.WriteAttributeString("incaricoSaldato", "3");
							break;
					}
					//writer.WriteAttributeString("incaricoSaldato", (fieldvalue == "S" ? "1" : "2"));

					decimal expectedamount = (CfgFn.GetNoNullDecimal(rConsulente["expectedamount"]));
					writer.WriteAttributeString("importo", sostituiscivirgolaconpunto(expectedamount));

					if (rConsulente["idreferencerule"] != DBNull.Value) {
						writer.WriteStartElement("riferimentoNormativo"); // Apre - RIFERIMENTO NORMATIVO
						scriviXml(rConsulente,
							new string[] {"riferimento", "data", "numero", "articolo", "comma"},
							new string[] {"idreferencerule", "referencedate", "articlenumber", "article", "paragraph"}
						);
						writer.WriteEndElement(); //riferimentoNormativo     // Chiude - RIFERIMENTO NORMATIVO
					}

					writer.WriteEndElement(); //incarico             // Chiude - INCARICO
					// Trasmesse anche gli eventuali pagamenti 
					if (DS.servicepayment.Select(filtroNew).Length > 0 ||
					    DS.servicepayment.Select(filtroMod).Length > 0) {
						writer.WriteStartElement("pagamenti"); // Apre PAGAMENTI
						esportaPagamentoConsulente(rConsulente, filtroNew, "nuovoPagamento", false);
						esportaPagamentoConsulente(rConsulente, filtroMod, "modificaPagamento", false);
						writer.WriteEndElement(); // Chiude PAGAMENTI
					}

					setIncarico_Blocked(rConsulente);
					writer.WriteEndElement(); //fine consulente              // Chiude - CONSULENTE
				} // Chiude foreach

				writer.WriteEndElement(); //fine nuoviIncarichi          // Chiude - MODIFICA INCARICHI
			}

		}


		private bool GenerazioneFileUpdate(string tipo, int semestre, bool modpagamenti, int tipologia,
			bool PERLA = false) {
			if (meta.IsEmpty) return false;
			DialogResult dialogResult = saveFileDialog1.ShowDialog(this);
			if (dialogResult == DialogResult.Cancel) return false;


			meta.GetFormData(true);
			ValorizzaTipologia(tipologia);


			//object esercizio = meta.GetSys("esercizio");
			//// Anche per la variazione come per l'inserimento prendiamo le modifiche a incarichi 2010 + variazioni fatte a pagamenti di incarichi 2010
			//// Quindi nel 2010 creo e comunico l'incarico. Poi a Gennaio 2011 creo il pagamento a questo incarico. 
			//// Per comunicare questi pagamenti, essendo di incarichi 2010, dovrò generare il file nel 2010 perchè
			//// comunichiamo l'Anno di Riferimento degli incarichi

			int esercizio = Conn.GetEsercizio();
			string filtereserc_service;

			String codeaddress = "07_SW_ANP";
			object idaddresskind =
				meta.Conn.DO_READ_VALUE("address", QHS.CmpEq("codeaddress", codeaddress), "idaddress");
			DataTable Address = DataAccess.RUN_SELECT(meta.Conn, "registryaddress", "*", null,
				QHS.CmpEq("idaddresskind", idaddresskind), false);


			// solo per i dipendenti
			string filter_own = "";
			if (tipo.ToUpper() == "D") {
				// per i dipendenti filtri solo quelli che non appartengono ad altra amministrazione
				// ovvero non hanno un indirizzo del tipo anagrafe delle prestazioni
				filter_own = QHS.FieldNotIn("idreg", Address.Select(), "idreg");
			}

			string securityServiceRegistry = Conn.SelectCondition("serviceregistry", true);
			if (securityServiceRegistry != null && securityServiceRegistry != "") {
				filter_own = QHS.AppAnd(filter_own, securityServiceRegistry);
			}

			filter_own = QHS.AppAnd(filter_own, getFilterSicurezza());
			int AnnoRif = esercizio;

			if (modpagamenti) {
				string filtroPagamenti = PERLA
					? " AND (SS.is_delivered ='N' and SS.payedamount > 0 ) "
					: " AND ((SS.is_delivered ='N' and SS.payedamount > 0 ) OR (SS.is_delivered ='S' and SS.is_changed ='S' ) ) )";
				filtereserc_service = QHS.AppAnd(QHS.CmpLe("yservreg", esercizio),
					QHS.CmpEq("is_delivered", "S"),
					QHS.CmpEq("is_blocked", "N"),
					" EXISTS (SELECT * from servicepayment  SS where " +
					" SS.yservreg=serviceregistry.yservreg and SS.nservreg=serviceregistry.nservreg " +
					" AND SS.is_blocked = 'N' " +
					filtroPagamenti);
				if (tipo.ToUpper() == "D") {
					//Per i dipendenti pretende anche che non ci sia nessun pagamento bloccato
					filtereserc_service = QHS.AppAnd(filtereserc_service,
						" NOT EXISTS (SELECT * from servicepayment  SS2 where " +
						" SS2.yservreg=serviceregistry.yservreg and SS2.nservreg=serviceregistry.nservreg " +
						" AND SS2.is_blocked = 'S' ) "
					);
				}
			}
			else {
				//= " (is_delivered ='S' and is_changed = 'S' and is_blocked = 'N') ";
				filtereserc_service = QHS.AppAnd(QHS.CmpLe("yservreg", esercizio), filtroModificaIncarico);
			}

			string filtereserc_payment = QHS.CmpLe("ypay", esercizio);
			if (tipo.ToUpper() == "D") {
				filtereserc_payment = QHS.CmpEq("ypay", esercizio - 1);
				AnnoRif = AnnoRif - 1;
			}
			else {
				if (semestre == 2) {
					filtereserc_payment =
						QHS.AppAnd(QHS.CmpEq("ypay", esercizio - 1), QHS.CmpEq("semesterpay", semestre));
					AnnoRif = AnnoRif - 1;
				}

				if (semestre == 1) {
					filtereserc_payment = QHS.AppAnd(QHS.CmpEq("ypay", esercizio), QHS.CmpEq("semesterpay", semestre));
				}

				if (semestre == 0) {
					//Se 0 legge tutti i pagamenti dell'anno
					filtereserc_payment = QHS.CmpLe("ypay", esercizio);
				}
			}

			DS.serviceregistry.Clear();
			DS.servicepayment.Clear();
			// inserisci in serviceregistry solo gli incarichi dei C o D


			if (tipo.ToUpper() == "D") {
				//kind= D
				DataAccess.RUN_SELECT_INTO_TABLE(meta.Conn, DS.serviceregistry, null,
					QHS.AppAnd(QHS.CmpEq("employkind", "D"), filtereserc_service, filter_own), null, true);
			}
			else {
				//kind = C o A
				DataAccess.RUN_SELECT_INTO_TABLE(meta.Conn, DS.serviceregistry, null,
					QHS.AppAnd(QHS.CmpNe("employkind", "D"), filtereserc_service, filter_own), null, true);
			}



			// inserisce in servicepayment solo i pagamenti dei C o D 
			foreach (DataRow rSer in DS.serviceregistry.Rows) {
				string filterPayment = QHS.AppAnd(QHS.CmpKey(rSer), filtereserc_payment, filtroNuovoPagamento);
				DataAccess.RUN_SELECT_INTO_TABLE(meta.Conn, DS.servicepayment, null, filterPayment, null, true);

				filterPayment = QHS.AppAnd(QHS.CmpKey(rSer), filtereserc_payment, filtroModificaPagamento);
				DataAccess.RUN_SELECT_INTO_TABLE(meta.Conn, DS.servicepayment, null, filterPayment, null, true);
			}


			DataRow Curr = DS.servicetrasmission.Rows[0];

			var wsReq = creaRichiestaPerla(saveFileDialog1.FileName);
			var wsCom = wsReq.InserimentoIncarichi.wsdlRequest.comunicazione;


			StringWriter sw = new StringWriter();
			writer = new XmlTextWriter(sw);
			writer.Formatting = Formatting.Indented;

			writer.WriteProcessingInstruction("xml", "version='1.0' encoding='UTF-8' standalone='yes' ");
			writer.WriteStartElement("comunicazione",
				"http://com.accenture.perla.it/anagrafeprestazioni_variazioneincarichi"); // Apre - COMUNICAZIONE

			wsCom.inserimentoIncarichi = new comunicazione_typeInserimentoIncarichi();
			writer.WriteStartElement("variazioneIncarichi"); // Apre - VARIAZIONE INCARICHI

			string securityServiceagency = Conn.SelectCondition("serviceagency", true);
			securityServiceagency = QHS.AppAnd(securityServiceagency, getFilterSicurezza());

			DataTable serviceagency = DataAccess.RUN_SELECT(meta.Conn, "serviceagency", "*", null,
				securityServiceagency,
				false);
			DataRow rServiceagency = serviceagency.Rows[0];
			writer.WriteAttributeString("codiceEnte", rServiceagency["pa_code"].ToString());
			wsCom.inserimentoIncarichi.codiceEnte = Convert.ToInt64(rServiceagency["pa_code"]);

			wsCom.inserimentoIncarichi.annoRiferimento = AnnoRif.ToString(); //???

			string mess = (tipo == "d" ? "Dipendenti" : "Consulenti");
			if (DS.serviceregistry.Select(QHC.CmpEq("is_blocked", 'S')).Length != 0) {
				show(this, @"Ci sono Incarichi di " + mess + @" da correggere");
				return false;
			}

			if (modpagamenti) {
				if (tipo == "d") {
					if (!EsistonoPagamentiNuoviOModificati(tipo, semestre)) {
						show(this, "Non ci sono Pagamenti nuovi o modificati a Dipendenti da trasmettere nel semestre " + semestre);
						return false;
					}

					UpdateDipendenti(modpagamenti, wsCom);
				}
				else {
					if (!EsistonoPagamentiNuoviOModificati(tipo, semestre)) {
						show(this, "Non ci sono Pagamenti nuovi o modificati a Consulenti da trasmettere nel semestre" + semestre);
						return false;
					}

					UpdateConsulenti(semestre, modpagamenti, wsCom);
				}
			}
			else {
				if (!EsistonoIncarichiModificati(tipo)) {
					string tipoIncarico;
					if (tipo == "d") {
						tipoIncarico = "Dipendente";
					}
					else {
						tipoIncarico = "Consulente";
					}
					show(this, "Non ci sono Modifiche a Incarichi da trasmettere di tipo " + tipoIncarico);
					return false;
				}

				if (tipo == "d") {
					UpdateDipendenti(modpagamenti, wsCom);
				}
				else {
					UpdateConsulenti(semestre, modpagamenti, wsCom);
				}
			}

			writer.WriteEndElement(); // Chiude - VARIAZIONE INCARICHI

			writer.WriteEndElement(); // Comunicazione           // Chiude - COMUNICAZIONE
			writer.Close();

			string xmlString = sw.ToString();
			byte[] xml = new UTF8Encoding().GetBytes(xmlString);
			DS.servicetrasmission.Rows[0]["rtf"] = xml;
			meta.SaveFormData();

			if (PERLA) {
				var ser = EServizio.Create(user, password);
				ser.InserimentoIncarichi(wsReq);
				show(this, @"Dati inviati", @"Informazione");

			}
			else {
				FileStream stw = new FileStream(saveFileDialog1.FileName, FileMode.Create);
				stw.Write(xml, 0, xml.Length);
				stw.Flush();
				stw.Close();

				//btnVisualizzaFile.Enabled = true;
				//btnSalvaXml.Enabled = true;
			}

			return true;
			//btnSalvaFile.Enabled = true;
		}


		private bool inviaModificheWS(string tipo, int tipologia) {
			if (meta.IsEmpty) return false;
		
			frmAskPassword f = new frmAskPassword(user, password);
			if (f.ShowDialog(this) == DialogResult.OK) {
				user = f.txtUser.Text;
				password = f.txtPassword.Text;
			}

			meta.GetFormData(true);
			ValorizzaTipologia(tipologia);

			int esercizio = Conn.GetEsercizio();

			var codeaddress = "07_SW_ANP";
			object idaddresskind =
				meta.Conn.DO_READ_VALUE("address", QHS.CmpEq("codeaddress", codeaddress), "idaddress");
			var Address = DataAccess.RUN_SELECT(meta.Conn, "registryaddress", "*", null,
				QHS.CmpEq("idaddresskind", idaddresskind), false);


			// solo per i dipendenti
			string filter_own = "";
			if (tipo.ToUpper() == "D") {
				// per i dipendenti filtri solo quelli che non appartengono ad altra amministrazione
				// ovvero non hanno un indirizzo del tipo anagrafe delle prestazioni
				filter_own = QHS.FieldNotIn("idreg", Address.Select(), "idreg");
			}

			string securityServiceRegistry = Conn.SelectCondition("serviceregistry", true);
			if (securityServiceRegistry != null && securityServiceRegistry != "") {
				filter_own = QHS.AppAnd(filter_own, securityServiceRegistry);
			}

			filter_own = QHS.AppAnd(filter_own, getFilterSicurezza());
			int AnnoRif = esercizio;

			//pagamenti di prestazioni trasmesse
			string filtereser_service = QHS.AppAnd(QHS.CmpLe("yservreg", esercizio),
				QHS.CmpEq("is_delivered", "S"),
				QHS.CmpEq("is_blocked", "N"),
				QHS.CmpEq("is_changed","S"),
				filter_own
			);

			DS.serviceregistry.Clear();
			DS.servicepayment.Clear();
			// inserisci in serviceregistry solo gli incarichi dei C o D


			if (tipo.ToUpper() == "D") {
				//kind= D
				filtereser_service = QHS.AppAnd(filtereser_service, QHS.CmpEq("employkind", "D"));

			}
			else {
				//kind = C o A
				filtereser_service = QHS.AppAnd(filtereser_service, QHS.CmpNe("employkind", "D"));
			}

			DataAccess.RUN_SELECT_INTO_TABLE(meta.Conn, DS.serviceregistry, null, filtereser_service, null, true);

			if (DS.serviceregistry.Rows.Count == 0) {
				show(this, "Non ci sono Modifiche a Incarichi da trasmettere");
				return false;
			}


			var ser = new EServizioNew().Create(user, password);

			var messages = new List<string>();
			int skipped = 0;

			DataRow Curr = DS.servicetrasmission.Rows[0];
			string requestString="";
			string responceString = "";

			if (tipo.ToUpper() == "D") {
				foreach (DataRow service in DS.serviceregistry.Select()) {
					var d = updateDipendente(service);
					if (d == null) {
						meta.SaveFormData();
						skipped++;
						continue;
					}
					impostaBloccoPrestazione(service, true);
					meta.SaveFormData();
					if (DS.HasChanges()) {
						messages.Add("Procedura interrotta per errori durante il salvataggio");
						break;
					}

					var com = new comunicazione();
					com.Item = d;
					var req = new variazioneIncarico_DipendenteRequest(user, password, SerializeToXmlElement(com));
					requestString = ToXML(req.incarico);
					var res = ser.variazioneIncarico_Dipendente(req);
					responceString = ToXML(res);
					var localMessages = new List<string>();
					elaboraFileRitorno(service,SerializeToXmlDocument(res), requestString,responceString, out string errore);
					if (errore != null) messages.Add($"{service["yservreg"]}/{service["nservreg"]}: {errore}");
					meta.SaveFormData();
					if (DS.HasChanges()) {
						messages.Add("Procedura interrotta per errori durante il salvataggio");
						break;
					}
				}
			}
			else {
				foreach (DataRow service in DS.serviceregistry.Select()) {
					var d =  updateConsulente(service);
					if (d == null) {
						meta.SaveFormData();
						skipped++;
						continue;
					}
					impostaBloccoPrestazione(service, true);
					meta.SaveFormData();
					if (DS.HasChanges()) {
						messages.Add("Procedura interrotta per errori durante il salvataggio");
						break;
					}

					var com = new comunicazione();
					com.Item = d;
					var req = new variazioneIncarico_ConsulenteRequest(user, password, SerializeToXmlElement(com));
					requestString = ToXML(req);
					var res = ser.variazioneIncarico_Consulente(req);
					responceString = ToXML(res);
					var localMessages = new List<string>();
					elaboraFileRitorno(service,SerializeToXmlDocument(res), requestString,responceString, out string errore);
					if (errore != null) messages.Add($"{service["yservreg"]}/{service["nservreg"]}: {errore}");

					meta.SaveFormData();
					if (DS.HasChanges()) {
						messages.Add("Procedura interrotta per errori durante il salvataggio");
						break;
					}
				}
			}
			if (skipped > 0) {
				//Mostra i messaggi messages ove ve ne siano
				show(
					$"{skipped} prestazioni non sono state inviate per presenza di errori. Elencare le prestazioni bloccate e correggerle.",
					"Errore");

			}

			if (DS.serviceregistry.Rows.Count > skipped) {
				show(this, @"Dati inviati", @"Informazione");
			}
			else {
				show(this, @"Nessun dato inviato", @"Informazione");
			}


			txtErrori.Text = "";
			if (messages.Count > 0) {
				var sb=new StringBuilder();
				foreach (var s in messages) sb.AppendLine(s);
				txtErrori.Text = sb.ToString();
				tabControl1.SelectedTab = tabErrori;
			}

			//btnVisualizzaFile.Enabled = true;
			//btnSalvaXml.Enabled = true;
			return true;
			//btnSalvaFile.Enabled = true;
		}


		private bool EsistonoPagamentiNuoviOModificati(string tipo, int semestre) {
			//Controlla che vi siano pagamenti da trasmettere
			string filterTipoIncarico = "";
			int semestrerif = CfgFn.GetNoNullInt32(semestre);
			if (tipo == "c") {
				filterTipoIncarico = QHC.CmpNe("employkind", 'D');
			}
			else {
				filterTipoIncarico = QHC.CmpEq("employkind", 'D');
			}

			foreach (
				DataRow rIncarico in DS.serviceregistry.Select(filterTipoIncarico)) {
				string filtropagamento = QHC.MCmp(rIncarico, new string[] {"yservreg", "nservreg"});
				filtropagamento = QHC.AppAnd(filtropagamento,
					QHC.DoPar(QHC.AppOr(filtroNuovoPagamento, filtroModificaPagamento))
				);
				if (tipo == "c") {
					filtropagamento = QHC.AppAnd(filtropagamento, QHC.CmpEq("semesterpay", semestrerif));
				}

				if (DS.servicepayment.Select(filtropagamento).Length > 0) {
					return true;
				}
			}

			return false;
		}

		string getFilterSicurezza() {
			string filter = "";
			if (meta.IsEmpty) return "";
			DataRow curr = DS.servicetrasmission.Rows[0];
			for (int i = 1; i <= 5; i++) {
				string field = "idsor0" + i.ToString();
				if (curr[field] != DBNull.Value) filter = QHS.AppAnd(filter, QHS.CmpEq(field, curr[field]));
			}

			return filter;
		}

		private bool EsistonoIncarichiModificati(string tipo) {
			string filterTipoIncarico = "";
			if (tipo == "c") {
				filterTipoIncarico = QHC.CmpNe("employkind", 'D');
			}
			else {
				filterTipoIncarico = QHC.CmpEq("employkind", 'D');
			}

			if (DS.serviceregistry.Select(QHC.AppAnd(filterTipoIncarico, filtroModificaIncarico)).Length > 0) {
				return true;
			}

			return false;
		}


		InserimentoIncarichiRequest getIncarichiRequest(string fileName, string user, string password) {
			var req = new InserimentoIncarichiRequest();
			var wsdl = new wsdlRequest {
				fileName = fileName,
				pwd = password,
				userName = user
			};
			if (wsdl.comunicazione == null) wsdl.comunicazione = new comunicazione_type();
			req.InserimentoIncarichi = new InserimentoIncarichi {wsdlRequest = wsdl};
			return req;
		}

		/// <summary>
		/// Genera file, se anno impostato 
		/// </summary>
		/// <param name="tipo">d15 = dipendenti alla data,C Consulenti semestre D dipendenti anno prec.</param>
		private bool GenerazioneFileInsert(string tipo, object semestre, int tipologia, bool perla = false) {
			if (meta.IsEmpty) return false;
			DialogResult dialogResult = saveFileDialog1.ShowDialog(this);
			if (dialogResult == DialogResult.Cancel)
				return false;


			meta.GetFormData(true);
			ValorizzaTipologia(tipologia);
			string filtereserc_service = "";
			string filtereserc_payment = "";
			int esercizio = Convert.ToInt32(meta.Conn.GetSys("esercizio"));

			int AnnoRif = esercizio;
			DateTime DataRif = (DateTime) meta.GetSys("datacontabile");
			string filter_tipologia =
				"(idserviceregistrykind is null OR idserviceregistrykind  in (select idserviceregistrykind from serviceregistrykind where " +
				QHS.CmpEq("totransmit", "S") + "))";

			string filter_IncarichiEsclusi = "";
			//Saranno esclusi i D con data conferimento null, e di C con data affidamento null e data inizio null.

			//Dipendenti
			if (tipo.ToUpper() == "D15") {
				//Prima prendevano gli incarichi autorizzati negli ultimi 15 gg. In seguito alla richiesta di Bari, prendiamo tutti gli incarichi autorizzati alla data contabile.
				//DateTime adate_tocompare = adate.AddDays(-15);
				filtereserc_service = QHS.AppAnd(filter_tipologia, filtroNuovoIncarico,
					QHS.CmpLe("authorizationdate", DataRif), QHS.CmpEq("yservreg", AnnoRif));
				filtereserc_payment = QHS.AppAnd(filtroNuovoPagamento, QHS.CmpEq("yservreg", AnnoRif));
				filter_IncarichiEsclusi = QHS.AppAnd(filtroNuovoIncarico, QHS.CmpEq("yservreg", AnnoRif));
				//l'esercizio va scritto nel file quindi deve essere univoco, a cavallo d'anno andranno generati 2 file
				tipo = "D";
			}
			else {
				int semestreRif = CfgFn.GetNoNullInt32(semestre);
				if (semestreRif == 2) {
					AnnoRif -= 1;
				}

				//Consulenti 2° semetre esercizio precedente Oppure Consulenti 1° semetre esercizio corrente
				filter_IncarichiEsclusi = QHS.AppAnd(filtroNuovoIncarico, QHS.CmpEq("yservreg", AnnoRif),
					QHS.CmpEq("referencesemester", semestreRif));
				filtereserc_service = QHS.AppAnd(filter_tipologia, filtroNuovoIncarico, QHS.CmpEq("yservreg", AnnoRif),
					QHS.CmpEq("referencesemester", semestreRif));
				filtereserc_payment = QHS.AppAnd(filtroNuovoPagamento, QHS.CmpEq("yservreg", AnnoRif));
			}

			DS.serviceregistry.Clear();
			DS.servicepayment.Clear();

			// solo per i dipendenti
			string filter_own = "";
			string not_filter_own = "";
			String codeaddress = "07_SW_ANP";
			object idaddresskind =
				meta.Conn.DO_READ_VALUE("address", QHS.CmpEq("codeaddress", codeaddress), "idaddress");
			if (tipo.ToUpper() == "D") {
				// per i dipendenti filtra solo quelli che non appartengono ad altra amministrazione
				// ovvero non hanno un indirizzo del tipo anagrafe delle prestazioni
				filter_own = "(idreg not in (select idreg from registryaddress where "
				             + QHS.AppAnd(QHS.CmpEq("idaddresskind", idaddresskind), QHS.CmpEq("active", "S")) + "))";
				not_filter_own = "(idreg in (select idreg from registryaddress where "
				                 + QHS.AppAnd(QHS.CmpEq("idaddresskind", idaddresskind), QHS.CmpEq("active", "S")) +
				                 "))";
				//QHS.FieldNotIn("idreg", Address.Select(), "idreg");
			}

			if (tipo.ToUpper() == "D") {
				// Per i Dipendenti deve escludere gli incarichi con data conferimento NULL
				filter_IncarichiEsclusi = QHS.AppAnd(filter_IncarichiEsclusi,
					QHS.DoPar(QHS.AppOr(QHS.IsNull("authorizationdate"), not_filter_own))
				);
			}
			else {
				//Per i Consulenti, deve escludere gli incarichi con data affidamento NULL e data inizio null
				filter_IncarichiEsclusi = QHS.AppAnd(filter_IncarichiEsclusi,
					QHS.DoPar(QHS.AppOr(QHS.IsNull("expectationsdate"), QHS.IsNull("start"))));
			}


			string security = Conn.SelectCondition("serviceregistry", true);
			security = QHS.AppAnd(security, getFilterSicurezza());
			// inserisci in serviceregistry solo gli incarichi dei C o D
			if (tipo.ToUpper() == "D") {
				//kind = 
				string filterDip = QHS.AppAnd(QHS.CmpEq("employkind", "D"),
					filtereserc_service,
					filter_own, security,
					QHS.IsNotNull("authorizationdate"));
				//Filtro sull'importo maggiore di 0 !!!!Sara
				//filterDip = QHS.AppAnd(filterDip, QHS.CmpGt("expectedamount", 0));
				DataAccess.RUN_SELECT_INTO_TABLE(meta.Conn, DS.serviceregistry, null, filterDip, "1000", true);
				if (DS.serviceregistry.Rows.Count == 1000) {
					int n = Conn.RUN_SELECT_COUNT("serviceregistry", filterDip, false);
					if (n > 1000) {
						show(this,
							"Ci sono più di 1000  incarichi da trasmettere, ma in base alle specifiche tecniche di trasmissione, " +
							"il file ne può contenere massimo 1000. Si dovrà, quindi, procedere con una seconda trasmissione.");
					}
				}

			}
			else {
				//kind= C or A 
				string filterCon = QHS.AppAnd(QHS.CmpNe("employkind", "D"),
					filtereserc_service, security,
					QHS.IsNotNull("expectationsdate"),
					QHS.IsNotNull("start"));
				DataAccess.RUN_SELECT_INTO_TABLE(meta.Conn, DS.serviceregistry, null, filterCon, "1000", true);
				if (DS.serviceregistry.Rows.Count == 1000) {
					int n = Conn.RUN_SELECT_COUNT("serviceregistry", filterCon, false);
					if (n > 1000) {
						show(this,
							"Ci sono più di 1000 incarichi da trasmettere, ma in base alle specifiche tecniche di trasmissione, " +
							"il file ne può contenere massimo 1000. Si dovrà, quindi, procedere con una seconda trasmissione.");
					}
				}
			}

			//filtroNuovoIncarico
			var wsReq = creaRichiestaPerla(saveFileDialog1.FileName);
			var wsCom = wsReq.InserimentoIncarichi.wsdlRequest.comunicazione;


			// inserisce in servicepayment solo i pagamenti dei C o D 
			string keyfilter = "";
			keyfilter = QHS.FieldIn("nservreg", DS.serviceregistry.Select());

			DataAccess.RUN_SELECT_INTO_TABLE(meta.Conn, DS.servicepayment, null,
				QHS.AppAnd(QHS.DoPar(keyfilter), filtereserc_payment), null, true);

			DataRow Curr = DS.servicetrasmission.Rows[0];

			StringWriter sw = new StringWriter();
			writer = new XmlTextWriter(sw);
			writer.Formatting = Formatting.Indented;

			writer.WriteProcessingInstruction("xml", "version='1.0' encoding='UTF-8' standalone='yes' ");
			writer.WriteStartElement("comunicazione",
				"http://com.accenture.perla.it/anagrafeprestazioni_inserimentoincarichi"); // Apre - COMUNICAZIONE

			wsCom.inserimentoIncarichi = new comunicazione_typeInserimentoIncarichi();
			writer.WriteStartElement("inserimentoIncarichi"); // Apre - INSERIMENTO INCARICHI

			string securityServiceagency = Conn.SelectCondition("serviceagency", true);
			securityServiceagency = QHS.AppAnd(securityServiceagency, getFilterSicurezza());
			if (securityServiceagency.ToString() == "") securityServiceagency = null;
			DataTable serviceagency =
				DataAccess.RUN_SELECT(meta.Conn, "serviceagency", "*", null, securityServiceagency, false);
			if (serviceagency.Rows.Count == 0) {
				QueryCreator.ShowError(this,
					"Inserire il Codice Ente. Andare in Compensi - Banca dati incarichi - Codice Ente.",
					"Filtro applicato:" + securityServiceagency);
				return false;
			}


			DataRow rServiceagency = serviceagency.Rows[0];
			writer.WriteAttributeString("codiceEnte", rServiceagency["pa_code"].ToString());
			wsCom.inserimentoIncarichi.codiceEnte = Convert.ToInt64(rServiceagency["pa_code"]);

			writer.WriteAttributeString("annoRiferimento", AnnoRif.ToString());
			wsCom.inserimentoIncarichi.annoRiferimento = AnnoRif.ToString();


			if (DS.serviceregistry.Rows.Count == 0) {
				show(this, "Per la tipologia incarico selezionata sull'incarico non è previsto l'invio a PerlaPA, interfacciarsi con la propria amministrazione");
				if (DS.servicepayment.Rows.Count == 0) {
					show(this, "Non ci sono Pagamenti da trasmettere");
					return false;
				}
			}

			string filter_IncarichiEsclusiDip = QHS.AppAnd(filter_IncarichiEsclusi, QHS.CmpEq("employkind", 'D'));
			DataTable TincarichiEsclusiDip = DataAccess.RUN_SELECT(meta.Conn, "serviceregistry", "*", null,
				filter_IncarichiEsclusiDip, false);
			if ((tipo.ToUpper() == "D") && (TincarichiEsclusiDip.Rows.Count > 0)) {
				//kind = D
				if (show(
					    "Ci sono incarichi a Dipendenti con data Conferimento NON valorizzata che saranno esclusi dal file. " +
					    "Si desidera procede ugualmente?",
					    "Conferma", MessageBoxButtons.OKCancel) == DialogResult.Cancel) {
					return false;
				}
			}

			string filter_IncarichiEsclusiCons = QHS.AppAnd(filter_IncarichiEsclusi, QHS.CmpNe("employkind", 'D'));
			DataTable TincarichiEsclusiCons = DataAccess.RUN_SELECT(meta.Conn, "serviceregistry", "*", null,
				filter_IncarichiEsclusiCons, false);
			if ((tipo.ToUpper() != "D") && (TincarichiEsclusiCons.Rows.Count > 0)) {
				//kind= C or A
				if (show("Ci sono incarichi a Consulenti o Dipendenti di Altri enti pubblici,  " +
				                    "con data Affidamento NON valorizzata che saranno esclusi dal file. " +
				                    "Si desidera procede ugualmente?",
					    "Conferma", MessageBoxButtons.OKCancel) == DialogResult.Cancel) {
					return false;
				}
			}

			string mess = (tipo.ToUpper() == "D" ? "Dipendenti" : "Consulenti");
			if (DS.serviceregistry.Select(QHC.CmpEq("is_blocked", 'S')).Length != 0) {
				show(this, "Ci sono Incarichi di " + mess + " in sospeso");
				return false;
			}

			if (tipo.ToUpper() == "D") {
				InsertDipendenti(wsCom);
			}
			else {
				InsertConsulenti(wsCom);
			}

			writer.WriteEndElement(); //fine inserimentoIncarichi            // Chiude - INSERIMENTO INCARICHI

			writer.WriteEndElement(); // Comunicazione           // Chiude - COMUNICAZIONE
			writer.Close();

			string xmlString = sw.ToString();
			byte[] xml = new UTF8Encoding().GetBytes(xmlString);
			DS.servicetrasmission.Rows[0]["rtf"] = xml;
			meta.SaveFormData();

			//txtNomeFile.Text = saveFileDialog1.FileName;
			if (perla) {
				var ser = EServizio.Create(user, password);
				ser.InserimentoIncarichi(wsReq);
				show(this, @"Dati inviati", @"Informazione");

			}
			else {
				FileStream stw = new FileStream(saveFileDialog1.FileName, FileMode.Create);
				stw.Write(xml, 0, xml.Length);
				stw.Flush();
				stw.Close();
				//btnVisualizzaFile.Enabled = true;
				//btnSalvaXml.Enabled = true;
			}


			return true;
			//btnSalvaFile.Enabled = true;
		}

		//password in uso 
		private string user = "", password = "";

		/// <summary>
		/// Crea la richiesta vuota per il vecchio servizio web 
		/// </summary>
		/// <param name="fileName"></param>
		/// <returns></returns>
		InserimentoIncarichiRequest creaRichiestaPerla(string fileName) {
			frmAskPassword f = new frmAskPassword(user, password);
			if (f.ShowDialog(this) == DialogResult.OK) {
				user = f.txtUser.Text;
				password = f.txtPassword.Text;
			}

			return getIncarichiRequest("x", user, password);
		}




		private void InsertConsulenti(comunicazione_type wsCom) {
			string fieldvalue = "";

			var wsNuoviIncarichi = wsCom.inserimentoIncarichi.nuoviIncarichi;
			if (wsNuoviIncarichi == null) {
				wsNuoviIncarichi = new comunicazione_typeInserimentoIncarichiNuoviIncarichi();
			}

			;
			if (wsNuoviIncarichi.consulente == null) {
				wsNuoviIncarichi.consulente = new consulente_type[0];
			}

			// Genera il file xml solo per i CONSULENTI
			writer.WriteStartElement("nuoviIncarichi"); // Apre - NUOVI INCARICHI

			List<consulente_type> wsConsList;
			if (wsNuoviIncarichi.consulente.Length == 0) {
				wsConsList = new List<consulente_type>();
			}
			else {
				wsConsList = new List<consulente_type>(wsNuoviIncarichi.consulente);
			}


			foreach (
				DataRow rConsulente in
				DS.serviceregistry.Select(QHC.AppAnd(QHC.CmpNe("employkind", 'D'), filtroNuovoIncarico))) {

				var wsConsulente = new consulente_type();

				writer.WriteStartElement("consulente"); // Apre - CONSULENTE
				writer.WriteAttributeString("idMittente", rConsulente["senderreporting"].ToString());
				wsConsulente.idMittente = rConsulente["senderreporting"].ToString();

				var wsIncaricato = new consulente_typeIncaricato();
				writer.WriteStartElement("incaricato"); // Apre - INCARICATO
				//if (rConsulente["idconsultingkind"].ToString() == "P1"){
				if (rConsulente["flaghuman"].ToString() == "S") {
					//	personaFisica

					var wsPersFisica = new personaFisica_type();
					writer.WriteStartElement("personaFisica"); // Apre - PERSONA FISICA
					if (rConsulente["cf"] != DBNull.Value) {
						writer.WriteAttributeString("codiceFiscale", rConsulente["cf"].ToString());
						wsPersFisica.codiceFiscale = rConsulente["cf"].ToString();
					}

					if (rConsulente["p_iva"] != DBNull.Value) {
						writer.WriteAttributeString("partitaIva", rConsulente["p_iva"].ToString());
						wsPersFisica.partitaIva = rConsulente["cf"].ToString();
					}

					scriviXml(rConsulente, new string[] {"cognome", "nome"}, new string[] {"surname", "forename"});
					if (rConsulente["surname"] != DBNull.Value) {
						wsPersFisica.cognome = rConsulente["surname"].ToString();
					}

					if (rConsulente["forename"] != DBNull.Value) {
						wsPersFisica.nome = rConsulente["forename"].ToString();
					}

					fieldvalue = rConsulente["flagforeign"].ToString().ToUpper();
					writer.WriteAttributeString("estero", (fieldvalue == "S" ? "Y" : "N"));
					if (rConsulente["gender"] != DBNull.Value) {
						writer.WriteAttributeString("sesso", rConsulente["gender"].ToString());
						wsPersFisica.sesso = rConsulente["gender"].ToString().ToUpper() == "F"
							? sesso_type.F
							: sesso_type.M;
						wsPersFisica.sessoSpecified = true;
					}

					if (rConsulente["birthdate"] != DBNull.Value) {
						DateTime d = (DateTime) rConsulente["birthdate"];
						writer.WriteAttributeString("dataNascita", d.ToString("yyyy-MM-dd"));
						wsPersFisica.dataNascita = d;
						wsPersFisica.dataNascitaSpecified = true;
					}

					wsIncaricato.personaFisica = wsPersFisica;
					writer.WriteEndElement(); //	personaFisica       // Chiude - PERSONA FISICA
				}

				//if (rConsulente["idconsultingkind"].ToString() != "P1"){
				if (rConsulente["flaghuman"].ToString() != "S") {
					//	personaGiuridica			
					var wsPersGiuridica = new personaGiuridica_type();
					writer.WriteStartElement("personaGiuridica"); // Apre - PERSONA GIURIDICA
					if ((rConsulente["cf"] != DBNull.Value) && (rConsulente["cf"].ToString().Length == 11)) {
						writer.WriteAttributeString("codiceFiscale", rConsulente["cf"].ToString());
						wsPersGiuridica.codiceFiscale = rConsulente["cf"].ToString();
					}

					if (((rConsulente["cf"] == DBNull.Value) || (rConsulente["cf"].ToString().Length != 11))
					    && (rConsulente["p_iva"] != DBNull.Value)) {
						writer.WriteAttributeString("partitaIva", rConsulente["p_iva"].ToString());
						wsPersGiuridica.partitaIva = rConsulente["p_iva"].ToString();
					}

					writer.WriteAttributeString("denominazione",
						rConsulente["title"].ToString().Replace("\n", "").Replace("\r", ""));
					wsPersGiuridica.denominazione = rConsulente["title"].ToString().Replace("\n", "").Replace("\r", "");

					fieldvalue = rConsulente["flagforeign"].ToString().ToUpper();
					if (fieldvalue == "S") {
						writer.WriteAttributeString("estero", "Y");
						wsPersGiuridica.estero = yesNo_type.Y;
						writer.WriteAttributeString("tipologiaAzienda", rConsulente["idconsultingkind"].ToString());
						wsPersGiuridica.tipologiaAzienda = rConsulente["idconsultingkind"].ToString();
					}
					else {
						writer.WriteAttributeString("estero", "N");
						wsPersGiuridica.estero = yesNo_type.N;
						writer.WriteAttributeString("tipologiaAzienda", rConsulente["idconsultingkind"].ToString());
						wsPersGiuridica.tipologiaAzienda = rConsulente["idconsultingkind"].ToString();
						writer.WriteAttributeString("codiceComuneSede", rConsulente["codcity"].ToString());
						wsPersGiuridica.codiceComuneSede = rConsulente["conferring_codcity"].ToString();
					}

					wsIncaricato.personaGiuridica = wsPersGiuridica;
					writer.WriteEndElement(); //	personaGiuridica        // Chiude - PERSONA GIURIDICA
				}

				wsConsulente.incaricato = wsIncaricato;
				writer.WriteEndElement(); //	incaricato          // Chiude - INCARICATO

				var wsIncarico = new consulente_typeIncarico();
				writer.WriteStartElement("incarico"); // Apre -  INCARICO
				if (CfgFn.GetNoNullInt32(rConsulente["yservreg"]) < 2011) {
					// Cambia il nome del campo attività economica: fino al 2010 è idfinancialactivity, dal 2011 diventa apfinancialactivitycode.
					scriviXml(rConsulente,
						new string[] {
							"semestreRiferimento", "modalitaAcquisizione", "tipoRapporto",
							"attivitaEconomica", "descrizioneIncarico"
						},
						new string[] {
							"referencesemester", "idacquirekind", "idapcontractkind",
							"idfinancialactivity", "description"
						}
					);
					wsIncarico.semestreRiferimento = rConsulente["referencesemester"].ToString();
					wsIncarico.modalitaAcquisizione = rConsulente["idacquirekind"].ToString();
					wsIncarico.tipoRapporto = rConsulente["idapcontractkind"].ToString();
					wsIncarico.attivitaEconomica = rConsulente["idfinancialactivity"].ToString();
					if (rConsulente["description"] != DBNull.Value) {
						wsIncarico.descrizioneIncarico =
							rConsulente["description"].ToString().Replace("\n", "").Replace("\r", "");
					}

				}
				else {
					scriviXml(rConsulente,
						new string[] {"semestreRiferimento", "modalitaAcquisizione", "tipoRapporto"},
						new string[] {"referencesemester", "idacquirekind", "idapcontractkind"}
					);
					wsIncarico.semestreRiferimento = rConsulente["referencesemester"].ToString();
					wsIncarico.modalitaAcquisizione = rConsulente["idacquirekind"].ToString();
					wsIncarico.tipoRapporto = rConsulente["idapcontractkind"].ToString();

					object apfinancialactivitycode_obj = meta.Conn.DO_READ_VALUE("apfinancialactivity",
						QHS.CmpEq("idapfinancialactivity", rConsulente["idapfinancialactivity"]),
						"apfinancialactivitycode");
					string apfinancialactivitycode = "";
					if ((apfinancialactivitycode_obj != DBNull.Value) && (apfinancialactivitycode_obj != null))
						// dal 3 marzo 2011
						apfinancialactivitycode = apfinancialactivitycode_obj.ToString();
					else // fino al 2 marzo 2011
						apfinancialactivitycode = rConsulente["idfinancialactivity"].ToString();
					writer.WriteAttributeString("attivitaEconomica", apfinancialactivitycode);
					wsIncarico.attivitaEconomica = apfinancialactivitycode;
					writer.WriteAttributeString("descrizioneIncarico",
						rConsulente["description"].ToString().Replace("\n", "").Replace("\r", ""));
					if (rConsulente["description"] != DBNull.Value) {
						wsIncarico.descrizioneIncarico =
							rConsulente["description"].ToString().Replace("\n", "").Replace("\r", "");
					}

				}

				fieldvalue = rConsulente["regulation"].ToString().ToUpper();
				writer.WriteAttributeString("riferimentoRegolamento", (fieldvalue == "S" ? "Y" : "N"));
				wsIncarico.riferimentoRegolamento = fieldvalue == "S" ? yesNo_type.Y : yesNo_type.N;
				scriviXml(rConsulente,
					new string[] {"dataAffidamento", "dataInizio", "dataFine"},
					new string[] {"expectationsdate", "start", "stop"}
				);
				if (rConsulente["expectationsdate"] != DBNull.Value) {
					wsIncarico.dataAffidamento = (DateTime) rConsulente["expectationsdate"];
				}

				if (rConsulente["start"] != DBNull.Value) {
					wsIncarico.dataInizio = (DateTime) rConsulente["start"];
				}


				if (rConsulente["stop"] != DBNull.Value) {
					wsIncarico.dataFine = (DateTime) rConsulente["stop"];
					wsIncarico.dataFineSpecified = true;
				}

				fieldvalue = rConsulente["payment"].ToString().ToUpper();
				switch (fieldvalue) {
					case "S":
						writer.WriteAttributeString("incaricoSaldato", "1");
						wsIncarico.incaricoSaldato = "1";
						break;
					case "N":
						writer.WriteAttributeString("incaricoSaldato", "2");
						wsIncarico.incaricoSaldato = "2";
						break;
					case "Q":
						writer.WriteAttributeString("incaricoSaldato", "3");
						wsIncarico.incaricoSaldato = "3";
						break;
				}
				//writer.WriteAttributeString("incaricoSaldato", (fieldvalue == "S" ? "1" : "2"));

				decimal expectedamount = (CfgFn.GetNoNullDecimal(rConsulente["expectedamount"]));
				writer.WriteAttributeString("importo", sostituiscivirgolaconpunto(expectedamount));
				wsIncarico.importo = expectedamount;

				if (rConsulente["idreferencerule"] != DBNull.Value) {
					var wsRifNormativo = new riferimentoNormativo_type();
					writer.WriteStartElement("riferimentoNormativo"); // Apre - RIFERIMENTO NORMATIVO
					scriviXml(rConsulente,
						new string[] {"riferimento", "data", "numero", "articolo", "comma"},
						new string[] {"idreferencerule", "referencedate", "articlenumber", "article", "paragraph"}
					);
					if (rConsulente["idreferencerule"] != DBNull.Value)
						wsRifNormativo.riferimento = rConsulente["idreferencerule"].ToString();
					if (rConsulente["referencedate"] != DBNull.Value) {
						wsRifNormativo.data = (DateTime) rConsulente["referencedate"];
					}

					if (rConsulente["articlenumber"] != DBNull.Value)
						wsRifNormativo.numero = rConsulente["articlenumber"].ToString();
					if (rConsulente["article"] != DBNull.Value)
						wsRifNormativo.articolo = rConsulente["article"].ToString();
					if (rConsulente["paragraph"] != DBNull.Value)
						wsRifNormativo.comma = rConsulente["paragraph"].ToString();
					writer.WriteEndElement(); //riferimentoNormativo     // Chiude - RIFERIMENTO NORMATIVO
					wsIncarico.riferimentoNormativo = wsRifNormativo;
				}

				writer.WriteEndElement(); //incarico             // Chiude - INCARICO
				//Esporto Nuovo Pagamento
				string filtropagamento = QHC.AppAnd(
					filtroNuovoPagamento, //" (is_delivered ='N' and payedamount > '0' and is_blocked = 'N') "
					QHC.MCmp(rConsulente, new string[] {"yservreg", "nservreg"}));
				if (DS.servicepayment.Select(filtropagamento, "semesterpay").Length > 0) {
					writer.WriteStartElement("pagamenti"); // Apre PAGAMENTI
					var wsPagamenti = esportaPagamentoConsulente(rConsulente, filtropagamento, "nuovoPagamento", false);
					wsConsulente.pagamenti = wsPagamenti.ToArray();
					writer.WriteEndElement(); // Chiude PAGAMENTI
				}

				setIncarico_Blocked(rConsulente);
				wsConsList.Add(wsConsulente);
				writer.WriteEndElement(); //fine consulente              // Chiude - CONSULENTE
			} // Chiude foreach

			wsNuoviIncarichi.consulente = wsConsList.ToArray();
			wsCom.inserimentoIncarichi.nuoviIncarichi = wsNuoviIncarichi;
			writer.WriteEndElement(); //fine nuoviIncarichi          // Chiude - NUOVI INCARICHI
		}

		private void InsertDipendenti(comunicazione_type wsCom) {
			string fieldvalue = "";
			// Genera il file xml solo per i DIPENDENTI


			var wsNuoviIncarichi = wsCom.inserimentoIncarichi.nuoviIncarichi;
			if (wsNuoviIncarichi == null) {
				wsNuoviIncarichi = new comunicazione_typeInserimentoIncarichiNuoviIncarichi();
			}

			;
			if (wsNuoviIncarichi.dipendente == null) {
				wsNuoviIncarichi.dipendente = new dipendente_type[0];
			}

			writer.WriteStartElement("nuoviIncarichi"); // Apre - NUOVI INCARICHI
			List<dipendente_type> wsDipList;
			if (wsNuoviIncarichi.dipendente.Length == 0) {
				wsDipList = new List<dipendente_type>();
			}
			else {
				wsDipList = new List<dipendente_type>(wsNuoviIncarichi.dipendente);
			}

			foreach (
				DataRow rDipendente in
				DS.serviceregistry.Select(QHC.AppAnd(QHC.CmpEq("employkind", 'D'), filtroNuovoIncarico))) {
				var wsDipendente = new dipendente_type();

				writer.WriteStartElement("dipendente"); // Apre - DIPENDENTE

				wsDipendente.idMittente = rDipendente["senderreporting"].ToString();
				writer.WriteAttributeString("idMittente", rDipendente["senderreporting"].ToString());
				writer.WriteStartElement("incaricato"); // Apre - INCARICATO
				scriviXml(rDipendente,
					new string[] {"codiceFiscale", "cognome", "nome", "qualifica"},
					new string[] {"cf", "surname", "forename", "idapmanager"}
				);
				var wsIncaricato = new dipendente_typeIncaricato();

				if (rDipendente["cf"] != DBNull.Value) {
					wsIncaricato.codiceFiscale = rDipendente["cf"].ToString();
				}

				if (rDipendente["surname"] != DBNull.Value) {
					wsIncaricato.cognome = rDipendente["surname"].ToString();
				}

				if (rDipendente["forename"] != DBNull.Value) {
					wsIncaricato.nome = rDipendente["forename"].ToString();
				}

				if (rDipendente["idapmanager"] != DBNull.Value) {
					wsIncaricato.qualifica = rDipendente["idapmanager"].ToString();
				}


				wsDipendente.incaricato = wsIncaricato;
				writer.WriteEndElement(); // Chiude - INCARICATO

				writer.WriteStartElement("conferente"); // Apre - CONFERENTE
				scriviXml(rDipendente,
					new string[] {"denominazione", "codiceFiscale", "tipologia",},
					new string[] {"pa_title", "pa_cf", "idapregistrykind"}
				);
				var wsConferente = new dipendente_typeConferente() {
					denominazione = rDipendente["pa_title"].ToString(),
					codiceFiscale = rDipendente["pa_cf"].ToString(),
					tipologia = rDipendente["idapregistrykind"].ToString()
				};

				if (personaGiuridica(rDipendente)) {	
					var wsNuovaPersona = new dipendente_typeConferenteNuovaPersona();
					writer.WriteStartElement("nuovaPersona");

					var wsPersGiuridica = new personaGiuridica_type();
					//<personaGiuridica codiceFiscale="" denominazione="" estero="Y/N" tipologiaAzienda="" codiceComuneSede="" />
					writer.WriteStartElement("personaGiuridica"); // Apre - personaGiuridica
					if (rDipendente["pa_cf"].ToString() != "") {
						writer.WriteAttributeString("codiceFiscale", rDipendente["pa_cf"].ToString());
						wsPersGiuridica.codiceFiscale = rDipendente["pa_cf"].ToString();
					}

					if (rDipendente["conferring_piva"].ToString() != "") {
						writer.WriteAttributeString("partitaIva", rDipendente["conferring_piva"].ToString());
						wsPersGiuridica.partitaIva = rDipendente["conferring_piva"].ToString();
					}

					writer.WriteAttributeString("denominazione",
						rDipendente["pa_title"].ToString().Replace("\n", "").Replace("\r", ""));
					wsPersGiuridica.denominazione =
						rDipendente["pa_title"].ToString().Replace("\n", "").Replace("\r", "");

					fieldvalue = rDipendente["conferring_flagforeign"].ToString().ToUpper();
					if (fieldvalue == "S") {
						writer.WriteAttributeString("estero", "Y");
						wsPersGiuridica.estero = yesNo_type.Y;
						if (rDipendente["idconsultingkind"].ToString() != "") {
							writer.WriteAttributeString("tipologiaAzienda", rDipendente["idconsultingkind"].ToString());
							wsPersGiuridica.tipologiaAzienda = rDipendente["idconsultingkind"].ToString();
						}
					}
					else {
						writer.WriteAttributeString("estero", "N");
						wsPersGiuridica.estero = yesNo_type.N;
						if (rDipendente["idconsultingkind"].ToString() != "") {
							writer.WriteAttributeString("tipologiaAzienda", rDipendente["idconsultingkind"].ToString());
							wsPersGiuridica.tipologiaAzienda = rDipendente["idconsultingkind"].ToString();
						}

						writer.WriteAttributeString("codiceComuneSede", rDipendente["conferring_codcity"].ToString());
						wsPersGiuridica.codiceComuneSede = rDipendente["conferring_codcity"].ToString();
					}


					writer.WriteEndElement(); // Chiude - personaGiuridica
					wsNuovaPersona.personaGiuridica = wsPersGiuridica;

					writer.WriteEndElement(); // Chiude - nuovaPersona
					wsConferente.nuovaPersona = wsNuovaPersona;

				} //nuova Persona

				if (personaFisica(rDipendente)) {
					var wsNuovaPersona = new dipendente_typeConferenteNuovaPersona();
					writer.WriteStartElement("nuovaPersona");
					//<personaFisica dataNascita="AAAA-MM-GG" sesso="M/F" estero="Y/N" nome="" cognome="" codiceFiscale=""/>
					var wsPersFisica = new personaFisica_type();
					writer.WriteStartElement("personaFisica"); // Apre - personaFisica
					scriviXml(rDipendente,
						new string[] {"dataNascita"},
						new string[] {"conferring_birthdate"}
					);
					if (rDipendente["conferring_birthdate"] != DBNull.Value) {
						wsPersFisica.dataNascita = (DateTime) rDipendente["conferring_birthdate"];
						wsPersFisica.dataNascitaSpecified = true;
					}

					writer.WriteAttributeString("sesso", rDipendente["conferring_gender"].ToString());
					wsPersFisica.sesso =
						rDipendente["conferring_gender"].ToString().ToUpper() == "M" ? sesso_type.M : sesso_type.F;
					wsPersFisica.sessoSpecified = true;

					writer.WriteAttributeString("estero", rDipendente["conferring_flagforeign"].ToString());
					wsPersFisica.estero = rDipendente["conferring_flagforeign"].ToString().ToUpper() == "S"
						? yesNo_type.Y
						: yesNo_type.N;

					writer.WriteAttributeString("nome",
						rDipendente["conferring_forename"].ToString().Replace("\n", "").Replace("\r", ""));
					wsPersFisica.nome = rDipendente["conferring_forename"].ToString().Replace("\n", "")
						.Replace("\r", "");

					writer.WriteAttributeString("cognome",
						rDipendente["conferring_surname"].ToString().Replace("\n", "").Replace("\r", ""));
					wsPersFisica.cognome =
						rDipendente["conferring_surname"].ToString().Replace("\n", "").Replace("\r", "");

					writer.WriteAttributeString("codiceFiscale", rDipendente["pa_cf"].ToString());
					wsPersFisica.codiceFiscale = rDipendente["pa_cf"].ToString();

					writer.WriteEndElement(); // Chiude - personaFisica
					wsNuovaPersona.personaFisica = wsPersFisica;

					writer.WriteEndElement(); // Chiude - nuovaPersona
					wsConferente.nuovaPersona = wsNuovaPersona;
				}


				wsDipendente.conferente = wsConferente;
				writer.WriteEndElement(); // Chiude - CONFERENTE

				var wsIncarico = new dipendente_typeIncarico();
				writer.WriteStartElement("incarico"); // Apre -  INCARICO
				scriviXml(rDipendente,
					new string[] {"tipologia", "dataAutorizzazione", "dataInizio", "dataFine"},
					new string[] {"idapactivitykind", "authorizationdate", "start", "stop"}
				);
				wsIncarico.tipologia = rDipendente["idapactivitykind"].ToString();
				wsIncarico.dataAutorizzazione = (DateTime) rDipendente["authorizationdate"];
				if (rDipendente["start"] != DBNull.Value) {
					wsIncarico.dataInizio = (DateTime) rDipendente["start"];
				}

				if (rDipendente["stop"] != DBNull.Value) {
					wsIncarico.dataFine = (DateTime) rDipendente["stop"];
					wsIncarico.dataFineSpecified = true;
				}





				fieldvalue = rDipendente["officeduty"].ToString().ToUpper();
				writer.WriteAttributeString("doveriUfficio", (fieldvalue == "S" ? "7" : "8"));
				wsIncarico.doveriUfficio = (fieldvalue == "S" ? "7" : "8");
				fieldvalue = rDipendente["payment"].ToString().ToUpper();
				switch (fieldvalue) {
					case "S":
						writer.WriteAttributeString("incaricoSaldato", "1");
						wsIncarico.incaricoSaldato = "1";
						break;
					case "N":
						writer.WriteAttributeString("incaricoSaldato", "2");
						wsIncarico.incaricoSaldato = "2";
						break;
					case "Q":
						writer.WriteAttributeString("incaricoSaldato", "3");
						wsIncarico.incaricoSaldato = "3";
						break;
				}

				//writer.WriteAttributeString("incaricoSaldato", (fieldvalue == "S" ? "1" : "2"));
				decimal expectedamount = (CfgFn.GetNoNullDecimal(rDipendente["expectedamount"]));
				writer.WriteAttributeString("importo", sostituiscivirgolaconpunto(expectedamount));
				wsIncarico.importo = expectedamount;

				if (rDipendente["annotation"] != DBNull.Value) {
					writer.WriteAttributeString("note",
						rDipendente["annotation"].ToString().Replace("\n", "").Replace("\r", ""));
					wsIncarico.note = rDipendente["annotation"].ToString().Replace("\n", "").Replace("\r", "");
				}

				if (rDipendente["idreferencerule"] != DBNull.Value) {
					var wsRifNormativo = new riferimentoNormativo_type();
					writer.WriteStartElement(
						"riferimentoNormativo"); // Apre - RIFERIMENTO NORMATIVO                    
					scriviXml(rDipendente,
						new string[] {"riferimento", "data", "numero", "articolo", "comma"},
						new string[] {"idreferencerule", "referencedate", "articlenumber", "article", "paragraph"}
					);
					if (rDipendente["idreferencerule"] != DBNull.Value)
						wsRifNormativo.riferimento = rDipendente["idreferencerule"].ToString();
					if (rDipendente["referencedate"] != DBNull.Value) {
						wsRifNormativo.data = (DateTime) rDipendente["referencedate"];
					}

					if (rDipendente["articlenumber"] != DBNull.Value)
						wsRifNormativo.numero = rDipendente["articlenumber"].ToString();
					if (rDipendente["article"] != DBNull.Value)
						wsRifNormativo.articolo = rDipendente["article"].ToString();
					if (rDipendente["paragraph"] != DBNull.Value)
						wsRifNormativo.comma = rDipendente["paragraph"].ToString();

					wsIncarico.riferimentoNormativo = wsRifNormativo;
					writer.WriteEndElement(); //riferimentoNormativo     // Chiude - RIFERIMENTO NORMATIVO

				}

				wsDipendente.incarico = wsIncarico;
				writer.WriteEndElement(); //incarico             // Chiude - INCARICO


				//Esporto Nuovo Pagamento
				string filtropagamento = QHC.AppAnd(filtroNuovoPagamento,
					QHC.MCmp(rDipendente, new string[] {"yservreg", "nservreg"}));
				if (DS.servicepayment.Select(filtropagamento, "semesterpay").Length > 0) {
					writer.WriteStartElement("pagamenti"); // Apre PAGAMENTI
					var wsPagamenti = esportaPagamentoDipendente(rDipendente, filtropagamento, "nuovoPagamento", false);
					wsDipendente.pagamenti = wsPagamenti.ToArray();
					writer.WriteEndElement(); // Chiude PAGAMENTI
				}

				setIncarico_Blocked(rDipendente);
				wsDipList.Add(wsDipendente);
				writer.WriteEndElement(); // Chiude - DIPENDENTE
			}

			wsNuoviIncarichi.dipendente = wsDipList.ToArray();

			wsCom.inserimentoIncarichi.nuoviIncarichi = wsNuoviIncarichi;
			writer.WriteEndElement(); // Chiude - NUOVI INCARICHI
		}

		private void DeleteDipendenti() {
			// Genera il file xml solo per i DIPENDENTI
			writer.WriteStartElement("incarichi"); // Apre -  INCARICHI
			foreach (
				DataRow rDipendente in
				DS.serviceregistry.Select(QHC.AppAnd(QHC.CmpEq("employkind", 'D'), filtroCancellaIncarico))) {
				writer.WriteStartElement("dipendente"); // Apre - DIPENDENTE
				writer.WriteAttributeString("idMittente", rDipendente["senderreporting"].ToString());
				writer.WriteAttributeString("id", rDipendente["id_service"].ToString());
				setIncarico_Blocked(rDipendente);
				writer.WriteEndElement(); // Chiude - DIPENDENTE
			}

			writer.WriteEndElement(); // Chiude -  INCARICHI
		}

		private void DeleteConsulenti() {
			// Genera il file xml solo per i CONSULENTI

			writer.WriteStartElement("incarichi"); // Apre -  INCARICHI
			foreach (
				DataRow rConsulente in
				DS.serviceregistry.Select(QHC.AppAnd(QHC.CmpNe("employkind", 'D'), filtroCancellaIncarico))) {
				writer.WriteStartElement("consulente"); // Apre - CONSULENTE
				writer.WriteAttributeString("idMittente", rConsulente["senderreporting"].ToString());
				writer.WriteAttributeString("id", rConsulente["id_service"].ToString());
				setIncarico_Blocked(rConsulente);
				writer.WriteEndElement(); // Chiude - CONSULENTE
			}

			writer.WriteEndElement(); // Chiude -  INCARICHI
		}

		private bool GenerazioneFileDelete(string tipo, int tipologia) {
			DialogResult dialogResult = saveFileDialog1.ShowDialog(this);
			if (dialogResult == DialogResult.Cancel) return false;

			meta.GetFormData(true);
			//object esercizio = meta.GetSys("esercizio");
			//string filtereserc_service = QHS.CmpEq("yservreg", esercizio);// Per l'inserimento prendiamo solo quelli = all'esercizio corrente
			//string filtereserc_payment = QHS.CmpEq("yservreg", esercizio);
			object esercizio = meta.GetSys("esercizio");
			string filtereserc_service = QHS.AppAnd(QHS.CmpLe("yservreg", esercizio), filtroCancellaIncarico);
			string filtereserc_payment = QHS.CmpLe("ypay", esercizio);

			DS.serviceregistry.Clear();
			DS.servicepayment.Clear();
			// inserisci in serviceregistry solo gli incarcichi dei C o D

			String codeaddress = "07_SW_ANP";
			object idaddresskind =
				meta.Conn.DO_READ_VALUE("address", QHS.CmpEq("codeaddress", codeaddress), "idaddress");
			DataTable Address = DataAccess.RUN_SELECT(meta.Conn, "registryaddress", "*", null,
				QHS.CmpEq("idaddresskind", idaddresskind), false);

			// solo per i dipendenti
			string filter_own = "";
			if (tipo.ToUpper() == "D") {
				// per i dipendenti filtri solo quelli che non appartengono ad altra amministrazione
				// ovvero non hanno un indirizzo del tipo anagrafe delle prestazioni
				filter_own = QHS.FieldNotIn("idreg", Address.Select(), "idreg");
			}

			string security = Conn.SelectCondition("serviceregistry", true);
			security = QHS.AppAnd(security, getFilterSicurezza());
			if (tipo.ToUpper() == "D") {
				//kind = D
				DataAccess.RUN_SELECT_INTO_TABLE(meta.Conn, DS.serviceregistry, null,
					QHS.AppAnd(QHS.CmpEq("employkind", "D"), filtereserc_service, filter_own, security), null, true);
			}
			else {
				//kind= C or A
				DataAccess.RUN_SELECT_INTO_TABLE(meta.Conn, DS.serviceregistry, null,
					QHS.AppAnd(QHS.CmpNe("employkind", "D"), filtereserc_service, filter_own, security), null, true);
			}

			// insetrisce in servicepayment solo i pagamenti dei C o D 
			string keyfilter = "";
			foreach (DataRow R in DS.serviceregistry.Select()) {
				keyfilter = QHS.AppOr(keyfilter, QHS.CmpKey(R));
			}

			DataAccess.RUN_SELECT_INTO_TABLE(meta.Conn, DS.servicepayment, null,
				QHS.AppAnd(QHS.DoPar(keyfilter), filtereserc_payment), null, true);

			DataRow Curr = DS.servicetrasmission.Rows[0];
			// Controllo che siano presenti i dati editabili nel form
			string messaggio = "";

			bool eseguiGenerazione = (messaggio == "");
			if (!eseguiGenerazione) {
				show(this, "Inserire " + messaggio.Substring(1));
				return false;
			}

			StringWriter sw = new StringWriter();
			writer = new XmlTextWriter(sw);
			writer.Formatting = Formatting.Indented;

			writer.WriteProcessingInstruction("xml", "version='1.0' encoding='UTF-8' standalone='yes' ");
			writer.WriteStartElement("comunicazione",
				"http://com.accenture.perla.it/anagrafeprestazioni_cancellazioneincarichi"); // Apre - COMUNICAZIONE


			writer.WriteStartElement("cancellazioneIncarichi"); // Apre - CANCELLAZIONE INCARICHI

			string securityServiceagency = Conn.SelectCondition("serviceagency", true);
			securityServiceagency = QHS.AppAnd(securityServiceagency, getFilterSicurezza());

			DataTable serviceagency = DataAccess.RUN_SELECT(meta.Conn, "serviceagency", "*", null, securityServiceagency, false);
			DataRow rServiceagency = serviceagency.Rows[0];
			writer.WriteAttributeString("codiceEnte", rServiceagency["pa_code"].ToString());

			string filterTipoIncarico = "";
			if (tipo == "c") {
				filterTipoIncarico = QHC.CmpNe("employkind", 'D');
			}
			else {
				filterTipoIncarico = QHC.CmpEq("employkind", 'D');
			}

			if (DS.serviceregistry.Select(QHC.AppAnd(filterTipoIncarico, filtroCancellaIncarico)).Length == 0) {
				show(this, "Non ci sono Incarichi Annullati da trasmettere");
				return false;
			}

			string mess = (tipo == "d" ? "Dipendenti" : "Consulenti");
			if (DS.serviceregistry.Select(QHC.CmpEq("is_blocked", 'S')).Length != 0) {
				show(this, "Ci sono Incarichi di " + mess + " in sospeso");
				return false;
			}

			if (tipo == "d") {
				DeleteDipendenti();
			}
			else {
				DeleteConsulenti();
			}

			writer.WriteEndElement(); //fine inserimentoIncarichi            // Chiude - CANCELLAZIONE INCARICHI

			writer.WriteEndElement(); // Comunicazione           // Chiude - COMUNICAZIONE
			writer.Close();

			string xmlString = sw.ToString();
			byte[] xml = new UTF8Encoding().GetBytes(xmlString);
			DS.servicetrasmission.Rows[0]["rtf"] = xml;
			meta.SaveFormData();
			//txtNomeFile.Text = saveFileDialog1.FileName;
			FileStream stw = new FileStream(saveFileDialog1.FileName, FileMode.Create);
			stw.Write(xml, 0, xml.Length);
			stw.Flush();
			stw.Close();


			//btnVisualizzaFile.Enabled = true;
			//btnSalvaXml.Enabled = true;
			return true;
			//btnSalvaFile.Enabled = true;
		}

		private void btnAnnullaC_Click(object sender, EventArgs e) {
			if (Annulla("c")) {
				DisabilitaButtons(((Control) sender).Name);
				ValorizzaTipologia(12);
			}
		}

		private void btnannullaD_Click(object sender, EventArgs e) {
			if (Annulla("d")) {
				DisabilitaButtons(((Control) sender).Name);
				ValorizzaTipologia(11);
			}
		}

		private void chkyear_CheckedChanged(object sender, EventArgs e) {
		}

		private void ValorizzaTipologia(object kind) {
			if (DS.servicetrasmission.Rows.Count == 0) return;
			DataRow Curr = DS.servicetrasmission.Rows[0];
			//HelpForm.SetComboBoxValue(cmbTipologia, kind);
			Curr["idservicetrasmissionkind"] = kind;
		}

		int getAnnoDipendenti() {
			if (txtAnnoDipendente.Text == "") {
				return 0;
			}
			return  CfgFn.GetNoNullInt32(txtAnnoDipendente.Text);
		}
		int getAnnoConsulenti() {
			if (txtAnnoConsulente.Text == "") {
				return 0;
			}
			return  CfgFn.GetNoNullInt32(txtAnnoConsulente.Text);
		}
		int getNumeroDipendenti() {
			if (txtNumeroDipendente.Text == "") {
				return 0;
			}
			return  CfgFn.GetNoNullInt32(txtNumeroDipendente.Text);
		}
		int getNumeroConsulenti() {
			if (txtNumeroConsulente.Text == "") {
				return 0;
			}
			return  CfgFn.GetNoNullInt32(txtNumeroConsulente.Text);
		}

		private void btnDipendenti_Click(object sender, EventArgs e) {	
			tipoIncarico nuovo_incarico = tipoIncarico.nuovoIncarico;
			//Dipendenti Nuovo incarico
			if (!controlla_validita_codici("d", nuovo_incarico))
				return;

			if (GenerazioneFileInsert("d", null, 1)) {
				DisabilitaButtons(((Control) sender).Name);
				//ValorizzaTipologia(1);
			}
		}

		private void DisabilitaButtons(string nomeButton) {
			List<string> button_da_disabilitare = new List<string>(
				new string[] {
					"btnConsulenti1Sem", "btnConsulenti2Sem", "btnDipendenti15gg",
					"btnModifichePagamentiDipendenti", "btnModifichePagamentiConsulenti2Sem",
					"btnModifichePagamentiConsulenti1Sem", "btnModificaDatiConsulenti",
					"btnModificaDatiDipendenti", "btnCancellazioneConsulenti",
					"btnCancellazioneDipendenti", "btnfilerisposta", "btnannullaD", "btnAnnullaC"
				});
			foreach (string S in button_da_disabilitare) {
				if (S != nomeButton) {
					Button btnToDisable = (Button) GetCtrlByName(S);
					if (btnToDisable == null) continue;
					btnToDisable.Enabled = false;
				}
			}
		}

		object GetCtrlByName(string Name) {
			System.Reflection.FieldInfo Ctrl = this.GetType().GetField(Name);
			if (Ctrl == null)
				return null;
			return Ctrl.GetValue(this);
		}

		
		private void btnSalvaXml_Click(object sender, EventArgs e) {


			byte[] xml = (byte[]) DS.servicetrasmission.Rows[0]["rtf"];


			DialogResult dialogResult = saveFileDialog1.ShowDialog(this);
			if (dialogResult == DialogResult.Cancel) return;

			FileStream stw = new FileStream(saveFileDialog1.FileName, FileMode.Create);
			stw.Write(xml, 0, xml.Length);
			stw.Flush();
			stw.Close();
		}

		private void btnInviaDipendenti15gg_Click(object sender, EventArgs e) {
			tipoIncarico nuovo_incarico = tipoIncarico.nuovoIncarico;
			//Dipendenti Nuovo incarico
			if (!controlla_validita_codici("d", nuovo_incarico))
				return;

			if (GenerazioneFileInsert("d15", null, 1, true)) {
				DisabilitaButtons(((Control) sender).Name);
				//ValorizzaTipologia(1);
			}
		}

		private void btnInviaConsulenti2Sem_Click(object sender, EventArgs e) {
			tipoIncarico nuovo_incarico = tipoIncarico.nuovoIncarico;
			if (!controlla_validita_codici("c", nuovo_incarico))
				return;
			//Consulenti Nuovo Incarico 2° semestre esercizo precedente
			if (GenerazioneFileInsert("c", 2, 3, true)) {
				DisabilitaButtons(((Control) sender).Name);
			}
		}

		private void btnInviaConsulenti1Sem_Click(object sender, EventArgs e) {
			tipoIncarico nuovo_incarico = tipoIncarico.nuovoIncarico;
			if (!controlla_validita_codici("c", nuovo_incarico))
				return;
			//Consulenti Nuovo Incarico 1° semestre esercizo corrente
			if (GenerazioneFileInsert("c", 1, 2, true)) {
				DisabilitaButtons(((Control) sender).Name);
			}
		}


		private void btnInviaModifichePagamentiDipendenti_Click_1(object sender, EventArgs e) {
			tipoIncarico modifica_incarico = tipoIncarico.modificaIncarico;
			if (!controlla_validita_codici("d", modifica_incarico)) return;
			//Dipendenti: solo pagamenti nuovi o modificati, di incarichi modificati
			if (GenerazioneFileUpdate("d", 0, true, 4, true)) {
				DisabilitaButtons(((Control) sender).Name);
			}
		}

		private void btnInviaModifichePagamentiConsulenti2Sem_Click(object sender, EventArgs e) {
			tipoIncarico modifica_incarico = tipoIncarico.modificaIncarico;
			if (!controlla_validita_codici("c", modifica_incarico))
				return;
			//Consulenti: solo pagamenti nuovi o modificati, di incarichi del 2° semestre, esercizio precedente, modificati.
			if (GenerazioneFileUpdate("c", 2, true, 6, true)) {
				DisabilitaButtons(((Control) sender).Name);
			}
		}



		private void btnInviaModifichePagamentiConsulenti1Sem_Click(object sender, EventArgs e) {
			tipoIncarico modifica_incarico = tipoIncarico.modificaIncarico;
			if (!controlla_validita_codici("c", modifica_incarico)) return;
			//Consulenti: solo pagamenti nuovi o modificati, di incarichi del 1° semestre, esercizio corrente, modificati.
			if (GenerazioneFileUpdate("c", 1, true, 5, true)) {
				DisabilitaButtons(((Control) sender).Name);
			}
		}

		private void btnInviaDipendenti_Click(object sender, EventArgs e) {
			tipoIncarico nuovo_incarico = tipoIncarico.nuovoIncarico;
			//Dipendenti Nuovo incarico
			if (!controlla_validita_codici("d", nuovo_incarico))
				return;

			if (inviaInserimentiWS("d", 1)) {
				DisabilitaButtons(((Control) sender).Name);
				//ValorizzaTipologia(1);
			}

		}

		public XmlDocument SerializeToXmlDocument(object input) {
			XmlSerializer ser = new XmlSerializer(input.GetType(), "http://schemas.yournamespace.com");

			XmlDocument xd = null;

			using (MemoryStream memStm = new MemoryStream()) {
				ser.Serialize(memStm, input);

				memStm.Position = 0;

				XmlReaderSettings settings = new XmlReaderSettings();
				settings.IgnoreWhitespace = true;

				using (var xtr = XmlReader.Create(memStm, settings)) {
					xd = new XmlDocument();
					xd.Load(xtr);
				}
			}

			return xd;
		}

		public XmlElement SerializeToXmlElement(object o) {
			XmlDocument doc = new XmlDocument();
			XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
			ns.Add("","");

			
			using (XmlWriter writer = doc.CreateNavigator().AppendChild()) {
				new XmlSerializer(o.GetType()).Serialize(writer, o,ns);
			}

			return doc.DocumentElement;
		}

		/// <summary>
		/// invia dati al web service perla
		/// </summary>
		/// <param name="tipo">C Consulenti  D dipendenti anno prec.</param>
		/// <returns>true if no errors</returns>
		private bool inviaInserimentiWS(string tipo, int tipologia) {
			if (meta.IsEmpty) return false;
		
			frmAskPassword f = new frmAskPassword(user, password);
			if (f.ShowDialog(this) == DialogResult.OK) {
				user = f.txtUser.Text;
				password = f.txtPassword.Text;
			}

			meta.GetFormData(true);
			//Valorizza il campo idservicetrasmissionkind della riga principale
			ValorizzaTipologia(tipologia);
			int esercizio = Convert.ToInt32(meta.Conn.GetSys("esercizio"));

			int AnnoRif = esercizio;
			DateTime DataRif = (DateTime) meta.GetSys("datacontabile");
			string filter_tipologia =
				"(idserviceregistrykind is null OR idserviceregistrykind  in (select idserviceregistrykind from serviceregistrykind where " +
				QHS.CmpEq("totransmit", "S") + "))";
			string filter_IncarichiEsclusi;
			string filtereserc_service;
			//string filtereserc_payment;
			//Saranno esclusi i D con data conferimento null, e di C con data affidamento null e data inizio null.

			filtereserc_service = QHS.AppAnd(filter_tipologia, filtroNuovoIncarico); // " (is_delivered ='N' and is_annulled='N' and is_blocked = 'N' and  website_annulled = 'N') "
			filtereserc_service = QHS.AppAnd(filtereserc_service,QHS.DoPar(QHS.AppOr(QHS.IsNotNull("codiceaooipa"), QHS.IsNotNull("codiceuoipa"))));

			DS.serviceregistry.Clear();
			DS.servicepayment.Clear();

			// solo per i dipendenti
			string filter_own = "";
			string not_filter_own = "";
			String codeaddress = "07_SW_ANP";
			object idaddresskind =
				meta.Conn.DO_READ_VALUE("address", QHS.CmpEq("codeaddress", codeaddress), "idaddress");
			if (tipo.ToUpper() == "D") {
				// per i dipendenti filtra solo quelli che non appartengono ad altra amministrazione
				// ovvero non hanno un indirizzo del tipo anagrafe delle prestazioni
				filter_own = "(idreg not in (select idreg from registryaddress where "
				             + QHS.AppAnd(QHS.CmpEq("idaddresskind", idaddresskind), QHS.CmpEq("active", "S")) + "))";
				not_filter_own = "(idreg in (select idreg from registryaddress where "
				                 + QHS.AppAnd(QHS.CmpEq("idaddresskind", idaddresskind), QHS.CmpEq("active", "S")) +
				                 "))";
				//QHS.FieldNotIn("idreg", Address.Select(), "idreg");
			}

			string anno = (tipo.ToUpper() == "D") ? txtAnnoDipendente.Text : txtAnnoConsulente.Text;
			if (anno.Trim() != "") {
				int annoFiltro = CfgFn.GetNoNullInt32(anno);
				if (annoFiltro != 0)
					filtereserc_service = QHS.AppAnd(filtereserc_service, QHS.CmpEq("yservreg", annoFiltro));
			}

			string numero = (tipo.ToUpper() == "D") ? txtNumeroDipendente.Text : txtNumeroConsulente.Text;
			if (numero.Trim() != "") {
				int numeroFiltro = CfgFn.GetNoNullInt32(numero);
				if (numeroFiltro != 0)
					filtereserc_service = QHS.AppAnd(filtereserc_service, QHS.CmpEq("nservreg", numeroFiltro));
			}



			if (tipo.ToUpper() == "D") {
				// Per i Dipendenti deve escludere gli incarichi con data conferimento NULL
				filter_IncarichiEsclusi = QHS.AppAnd(filtereserc_service,
					QHS.DoPar(QHS.AppOr(QHS.IsNull("authorizationdate"), not_filter_own))
				);
			}
			else {
				//Per i Consulenti, deve escludere gli incarichi con data affidamento NULL e data inizio null
				filter_IncarichiEsclusi = QHS.AppAnd(filtereserc_service,
					QHS.DoPar(QHS.AppOr(QHS.IsNull("expectationsdate"), QHS.IsNull("start"))));
			}


			string security = Conn.SelectCondition("serviceregistry", true);
			security = QHS.AppAnd(security, getFilterSicurezza());
			// inserisci in serviceregistry solo gli incarichi dei C o D
			string filterIncarichi;
			if (tipo.ToUpper() == "D") { //kind = D
				filterIncarichi = QHS.AppAnd(QHS.CmpEq("employkind", "D"),
					filtereserc_service, filter_own, security,
					QHS.IsNotNull("authorizationdate"),
					QHS.IsNotNull("ordinancelink"));
				if (codicePaIpa == null) filterIncarichi = QHS.AppAnd(filterIncarichi, QHS.IsNotNull("codicepaipa"));
			}
			else { //kind= C or A 
				filterIncarichi = QHS.AppAnd(QHS.CmpNe("employkind", "D"),
						filtereserc_service, security, 
						QHS.IsNotNull("expectationsdate"), 
						QHS.IsNotNull("expectationsdate"), 
						QHS.IsNotNull("start"),
						QHS.IsNotNull("ordinancelink")
						);
			}

			DataAccess.RUN_SELECT_INTO_TABLE(meta.Conn, DS.serviceregistry, null,filterIncarichi, null, false);

			var Curr = DS.servicetrasmission.Rows[0];

			if (DS.serviceregistry.Rows.Count == 0) {
				show(this, "Per la tipologia incarico selezionata sull'incarico non è previsto l'invio a PerlaPA, interfacciarsi con la propria amministrazione");
			}


			string securityServiceagency = Conn.SelectCondition("serviceagency", true);
			securityServiceagency = QHS.AppAnd(securityServiceagency, getFilterSicurezza());
			if (securityServiceagency.ToString() == "") securityServiceagency = null;
			DataTable serviceagency =
				DataAccess.RUN_SELECT(meta.Conn, "serviceagency", "*", null, securityServiceagency, false);
			if (serviceagency.Rows.Count == 0) {
				QueryCreator.ShowError(this,
					"Inserire il Codice Ente. Andare in Compensi - Banca dati incarichi - Codice Ente.",
					"Filtro applicato:" + securityServiceagency);
				return false;
			}


			DataRow rServiceagency = serviceagency.Rows[0];
			//string codice_pa = rServiceagency["pa_code"].ToString(); //ex codiceEnte


			string filter_IncarichiEsclusiDip = QHS.AppAnd(filter_IncarichiEsclusi, QHS.CmpEq("employkind", 'D'));
			DataTable TincarichiEsclusiDip = DataAccess.RUN_SELECT(meta.Conn, "serviceregistry", "*", null, filter_IncarichiEsclusiDip, false);
			if ((tipo.ToUpper() == "D") && (TincarichiEsclusiDip.Rows.Count > 0)) {
				//kind = D
				if (show(
					    "Ci sono incarichi a Dipendenti con data Conferimento NON valorizzata che saranno esclusi dal file. " +
					    "Si desidera procede ugualmente?",
					    "Conferma", MessageBoxButtons.OKCancel) == DialogResult.Cancel) {
					return false;
				}
			}

			string filter_IncarichiEsclusiCons = QHS.AppAnd(filter_IncarichiEsclusi, QHS.CmpNe("employkind", 'D'));
			DataTable TincarichiEsclusiCons = DataAccess.RUN_SELECT(meta.Conn, "serviceregistry", "*", null, filter_IncarichiEsclusiCons, false);
			if ((tipo.ToUpper() != "D") && (TincarichiEsclusiCons.Rows.Count > 0)) {
				//kind= C or A
				if (show("Ci sono incarichi a Consulenti o Dipendenti di Altri enti pubblici,  " +
				                    "con data Affidamento NON valorizzata che saranno esclusi dalla trasmissione " +
				                    "Si desidera procede ugualmente?",
					    "Conferma", MessageBoxButtons.OKCancel) == DialogResult.Cancel) {
					return false;
				}
			}

			string mess = (tipo.ToUpper() == "D" ? "Dipendenti" : "Consulenti");
			if (DS.serviceregistry.Select(QHC.CmpEq("is_blocked", 'S')).Length != 0) {
				show(this, "Ci sono Incarichi di " + mess + " in sospeso");
				return false;
			}

			var ser = new EServizioNew().Create(user, password);

			var messages = new List<string>();
			int skipped = 0;
			string requestString="";
			string responceString = "";
			if (tipo.ToUpper() == "D") {
				//InsertDipendenti(wsCom);

				foreach (DataRow service in DS.serviceregistry.Select()) {
					
					var d = inserisciDipendente(service);
					impostaBloccoPrestazione(service, true);
					meta.SaveFormData();
					if (d == null) {
						skipped++;
						continue;
					}
					if (DS.HasChanges()) {
						messages.Add("Procedura interrotta per errori durante il salvataggio");
						break;

					}

					try {
						var com = new comunicazione();
						com.Item = d;
						var xml = SerializeToXmlElement(com);
						requestString = ToXML(d);
						Console.WriteLine(requestString);

						var req = new inserimentoIncarico_DipendenteRequest(user, password, xml);
						var res = ser.inserimentoIncarico_Dipendente(req);
						responceString = ToXML(res);
						Console.WriteLine(responceString);
						elaboraFileRitorno(service,SerializeToXmlDocument(res),requestString, responceString, out string errore);
						if (errore != null) messages.Add($"{service["yservreg"]}/{service["nservreg"]}: {errore}");

					}
					catch (Exception e) {
						service["perla_error"] = e.ToString();
						impostaBloccoPrestazione(service, false);
						meta.SaveFormData();
						QueryCreator.ShowException("Errore nella trasmissione perla",e);
						messages.Add("Procedura interrotta per errori durante il salvataggio");
						break;

					}

					meta.SaveFormData();
					if (DS.HasChanges()) {
						messages.Add("Procedura interrotta per errori durante il salvataggio");
						break;

					}
				}
			}
			else {
				//InsertConsulenti(wsCom);

				foreach (DataRow service in DS.serviceregistry.Select()) {
					var c = inserisciConsulente(service);
					impostaBloccoPrestazione(service, true);
					meta.SaveFormData();
					if (c == null) {
						skipped++;
						continue;
					}

					if (DS.HasChanges()) {
						messages.Add("Procedura interrotta per errori durante il salvataggio");
						break;

					}

					try {
						var com = new comunicazione();
						com.Item = c;
						var xml = SerializeToXmlElement(com);


						c.allegati.fileCv = "omissis";//non ingolfiamo il testo
						c.allegati.fileDichiarazioneIncarichi = "omissis";
						requestString = ToXML(c);
						Console.WriteLine(requestString);

						//Console.Write(  ToXML(xml));
						var req = new inserimentoIncarico_ConsulenteRequest(user, password, xml);
						var res = ser.inserimentoIncarico_Consulente(req);
						


						responceString = ToXML(res);
						Console.Write(responceString);

						elaboraFileRitorno(service, SerializeToXmlDocument(res), requestString, responceString, out string errore);
						if (errore != null) messages.Add($"{service["yservreg"]}/{service["nservreg"]}: {errore}");
					}
					catch (Exception e) {
						service["perla_error"] = e.ToString();
						impostaBloccoPrestazione(service, true);
						meta.SaveFormData();
						QueryCreator.ShowException("Errore nella trasmissione perla", e);
						messages.Add("Procedura interrotta per errori durante il salvataggio");
						break;

					}

					meta.SaveFormData();
					if (DS.HasChanges()) {
						messages.Add("Procedura interrotta per errori durante il salvataggio");
						break;
					}

				}

			}

			if (skipped > 0) {
				//Mostra i messaggi messages ove ve ne siano
				show(
					$"{skipped} prestazioni non sono state inviate per presenza di errori. Elencare le prestazioni bloccate e correggerle.",
					"Errore");

			}

			//txtNomeFile.Text = saveFileDialog1.FileName;
			if (DS.serviceregistry.Rows.Count > skipped) {
				show(this, @"Dati inviati", @"Informazione");
			}
			//else {
			//	show(this, @"Nessun dato inviato", @"Informazione");
			//}

			txtErrori.Text = "";
			if (messages.Count > 0) {
				var sb=new StringBuilder();
				foreach (var s in messages) sb.AppendLine(s);
				txtErrori.Text = sb.ToString();
				tabControl1.SelectedTab = tabErrori;
			}


			return true;
			//btnSalvaFile.Enabled = true;
		}

		
		public string ToXML(object o)
		{
			using(var stringwriter = new Utf8StringWriter())
			{ 
				var serializer = new XmlSerializer(o.GetType());
				serializer.Serialize(stringwriter, o);
				return stringwriter.ToString();
			}
		}

		

		void impostaBloccoPrestazione(DataRow rIncarico, bool blocca) {
			string value = blocca ? "S" : "N";
			//string filtroIncarico = QHC.MCmp(rIncarico, new string[] {"yservreg", "nservreg"});
			//foreach (var Pag in DS.servicepayment.Select(filtroIncarico)) {
			//	Pag["is_blocked"] = value;
			//}

			rIncarico["is_blocked"] = value;
		}

		variazione_incarico_dipendente updateDipendente( DataRow rDipendente) {
			var w = new variazione_incarico_dipendente();
			w.amministrazionedichiarante.codiceFiscalePa = codiceFiscalePa;

			if (rDipendente["codicepaipa"] != DBNull.Value) {
				w.amministrazionedichiarante.codicePaIpa = rDipendente["codicepaipa"].ToString();
			}
			else {
				w.amministrazionedichiarante.codicePaIpa = codicePaIpa;
			}

			if (rDipendente["codiceaooipa"] != DBNull.Value) {
				w.amministrazionedichiarante.codiceAooIpa = rDipendente["codiceaooipa"].ToString();
			}
			else {
				w.amministrazionedichiarante.codiceAooIpa = codiceAooIpa; 
			}

			if (w.amministrazionedichiarante.codiceAooIpa == null) {
				if (rDipendente["codiceuoipa"] != DBNull.Value) {
					w.amministrazionedichiarante.codiceUoIpa = rDipendente["codiceuoipa"].ToString();
				}
				else {
					w.amministrazionedichiarante.codiceUoIpa = codiceUoIpa; 
				}
			}


		


			w.datiincarico.idIncarico = Convert.ToUInt64(rDipendente["id_service"]);

			if (rDipendente["idapmanager"] != DBNull.Value) {
				w.percettore.qualifica = rDipendente["idapmanager"].ToString();
			}

			w.conferente = getConferente(rDipendente);
			if (rDipendente["idapactivitykind"] != DBNull.Value) {
				w.datiincarico.oggettoIncarico = rDipendente["idapactivitykind"].ToString(); //apActivitykind[];
			}
			//w.datiincarico.dataRevoca = non c'è

			string fieldvalue = rDipendente["officeduty"].ToString().ToUpper();
			w.datiincarico.doveriUfficio = fieldvalue == "S" ? yesNo.Y : yesNo.N;

			if (rDipendente["stop"] != DBNull.Value) {
				w.datiincarico.dateconomici.dataFine = (DateTime) rDipendente["stop"];
				w.datiincarico.dateconomici.dataFineSpecified = true;
			}

			if (rDipendente["ordinancelink"] != DBNull.Value) {
				w.datiincarico.sitoWebTrasparenza = rDipendente["ordinancelink"].ToString();
			}

			if (rDipendente["idreferencerule"] != DBNull.Value) {
				w.riferimentonormativo.riferimento = rDipendente["idreferencerule"].ToString();
				w.riferimentonormativo.numero = rDipendente["articlenumber"].ToString();
				w.riferimentonormativo.articolo = rDipendente["article"].ToString();
				if (rDipendente["paragraph"] != DBNull.Value) {
					w.riferimentonormativo.comma = rDipendente["paragraph"].ToString();
				}

				w.riferimentonormativo.data = (DateTime) rDipendente["referencedate"];
			}
			else {
				w.riferimentonormativo = null;
			}


			decimal pagato = CfgFn.GetNoNullDecimal(Conn.readValue("servicepayment",q.keyCmp(rDipendente),"sum(payedamount)"));

			w.datiincarico.dateconomici._ammontareErogato = pagato;
			decimal importoPresunto = CfgFn.GetNoNullDecimal(rDipendente["expectedamount"]);
			w.datiincarico.dateconomici._compenso = importoPresunto;
			w.datiincarico.dateconomici.tipoCompenso = (importoPresunto == 0) ? "3" : "2"; //presunto se > 0 altr. gratuito
			w.datiincarico.dateconomici.incaricoSaldato =
				(rDipendente["payment"].ToString().ToUpper() == "S") ? yesNo.Y : yesNo.N;
			if (rDipendente["stop"] != DBNull.Value) {
				w.datiincarico.dateconomici.dataFine = (DateTime) rDipendente["stop"];
				w.datiincarico.dateconomici.dataFineSpecified = true;
			}

			return w;
		}

		inserimentoincaricodipendente inserisciDipendente(DataRow rDipendente) {
			var w = new inserimentoincaricodipendente();
			w.amministrazionedichiarante.codiceFiscalePa = codiceFiscalePa;// rDipendente["pa_cf"].ToString();

			if (rDipendente["codicepaipa"] != DBNull.Value) {
				w.amministrazionedichiarante.codicePaIpa = rDipendente["codicepaipa"].ToString();
			}
			else {
				w.amministrazionedichiarante.codicePaIpa = codicePaIpa;
			}

			if (rDipendente["codiceaooipa"] != DBNull.Value) {
				w.amministrazionedichiarante.codiceAooIpa = rDipendente["codiceaooipa"].ToString();
			}
			else {
				w.amministrazionedichiarante.codiceAooIpa = codiceAooIpa; 
			}

			if (w.amministrazionedichiarante.codiceAooIpa == null) {
				if (rDipendente["codiceuoipa"] != DBNull.Value) {
					w.amministrazionedichiarante.codiceUoIpa = rDipendente["codiceuoipa"].ToString();
				}
				else {
					w.amministrazionedichiarante.codiceUoIpa = codiceUoIpa;
				}
			}



			if (rDipendente["cf"] != DBNull.Value) {
				w.percettore.codiceFiscale = rDipendente["cf"].ToString();
			}

			if (rDipendente["surname"] != DBNull.Value) {
				w.percettore.cognome = rDipendente["surname"].ToString();
			}

			if (rDipendente["forename"] != DBNull.Value) {
				w.percettore.nome = rDipendente["forename"].ToString();
			}

			if (rDipendente["idapmanager"] != DBNull.Value) {
				w.percettore.qualifica = rDipendente["idapmanager"].ToString();
			}

			if (rDipendente["birthdate"] != DBNull.Value) {
				w.percettore.dataNascita = (DateTime) rDipendente["birthdate"];
			}
			else {
				rDipendente["perla_error"] = "Data nascita percettore assente";
				return null;
			}

			if (rDipendente["gender"] != DBNull.Value) {
				w.percettore.genere = rDipendente["gender"].ToString().ToUpper() == "F" ? Sesso.F : Sesso.M;
			}

			object idcity = Conn.readValue("registry", q.eq("idreg", rDipendente["idreg"]), "idcity");

			if (idcity != DBNull.Value) {
				w.percettore.comuneNascita = stringFromObject( //codice catastale
					Conn.readValue("geo_city_agency",
						q.eq("idcity", idcity) & q.eq("idagency", 1) & q.eq("idcode", 1),
						"value")); //codice catastale nascita
			}
		 
			else {
					object idnation = Conn.readValue("registry", q.eq("idreg", rDipendente["idreg"]), "idnation");
					w.percettore.comuneNascita = stringFromObject( //codice catastale
						Conn.readValue("geo_nation_agency",
							q.eq("idnation", idnation) & q.eq("idagency", 1) & q.eq("idcode", 1),
							"value")); //codice nazione nascita

				}
				
			if (w.percettore.comuneNascita == "")
				{
					rDipendente["perla_error"] = "Comune o nazione nascita Percettore assente";
					return null;
				}
			w.conferente = getConferente(rDipendente);
			if (w.conferente == null) return null;
			
			if (rDipendente["idapactivitykind"] != DBNull.Value) {
				w.datiincarico.oggettoIncarico = rDipendente["idapactivitykind"].ToString();
				//if (apActivitykind.ContainsKey(rDipendente["idapactivitykind"].ToString())) {
				//	w.datiincarico.oggettoIncarico = apActivitykind[rDipendente["idapactivitykind"].ToString()];
				//}
				//else {
				//	rDipendente["perla_error"] = $"Tipo attività {rDipendente["idapactivitykind"]} non trovato.";
				//	return null;
				//}
			}
			

			if (rDipendente["authorizationdate"] == DBNull.Value) {
				rDipendente["perla_error"] = "Data Autorizzazione Conferimento assente";
				return null;
			}
			w.datiincarico.dataAutorizzazioneConferimento = (DateTime) rDipendente["authorizationdate"];
			if (rDipendente["start"] != DBNull.Value) {
				w.datiincarico.dataInizio = (DateTime) rDipendente["start"];
			}
			else {
				rDipendente["perla_error"] = "Data incarico iniziale assente";
				return null;
			}

			string fieldvalue = rDipendente["officeduty"].ToString().ToUpper();
			w.datiincarico.doveriUfficio = fieldvalue == "S" ? yesNo.Y : yesNo.N;

		

			if (rDipendente["ordinancelink"] != DBNull.Value) {
				w.datiincarico.sitoWebTrasparenza = rDipendente["ordinancelink"].ToString();
			}


			if (rDipendente["idreferencerule"] != DBNull.Value) {
				w.riferimentonormativo.riferimento = rDipendente["idreferencerule"].ToString();
				w.riferimentonormativo.numero = rDipendente["articlenumber"].ToString();
				w.riferimentonormativo.articolo = rDipendente["article"].ToString();
				if (rDipendente["paragraph"] != DBNull.Value) {
					w.riferimentonormativo.comma = rDipendente["paragraph"].ToString();
				}

				w.riferimentonormativo.data = (DateTime) rDipendente["referencedate"];
			}
			else {
				w.riferimentonormativo = null;
			}

			//string filtroNuovoPagamento = " (is_delivered ='N' and payedamount > '0' and is_blocked = 'N') ";
			
			decimal pagato = CfgFn.GetNoNullDecimal(Conn.readValue("servicepayment",q.keyCmp(rDipendente),"sum(payedamount)"));

			//if (pagato > 0) {
				w.datiincarico.dateconomici._ammontareErogato = pagato;
				if (rDipendente["stop"] != DBNull.Value) {
					w.datiincarico.dateconomici.dataFine = (DateTime) rDipendente["stop"];
					w.datiincarico.dateconomici.dataFineSpecified = true;
				}

				decimal importoPresunto = CfgFn.GetNoNullDecimal(rDipendente["expectedamount"]);
				w.datiincarico.dateconomici._compenso = importoPresunto;
				w.datiincarico.dateconomici.tipoCompenso =
					(importoPresunto == 0) ? "3" : "2"; //presunto se > 0 altr. gratuito
				w.datiincarico.dateconomici.incaricoSaldato =
					(rDipendente["payment"].ToString().ToUpper() == "S") ? yesNo.Y : yesNo.N;
				if (rDipendente["stop"] != DBNull.Value) {
					w.datiincarico.dateconomici.dataFine = (DateTime) rDipendente["stop"];
					w.datiincarico.dateconomici.dataFineSpecified = true;
				}
			//}
			//else {
			//	w.datiincarico.dateconomici = null;
			//}

			return w;
		}

		conferente getConferente(DataRow rService) {
			var conf = new conferente();
			conf.tipologia = rService["idapregistrykind"].ToString();

			// SELECT idapregistrykind, description FROM apregistrykind WHERE ayear = 2020
			if (personaGiuridica(rService)) { //Persona giuridica  era 4 o 5 --> era 3 o 4
				conf.Item = new conferentepg() {
					codiceFiscale = stringFromObject(rService["pa_cf"]),
					denominazione = stringFromObject(rService["pa_title"])
				};
			}

			if (conf.tipologia == "1") { //Conferente pubblico
				var conferente = new conferentepubblico() {
					codiceFiscalePa = stringFromObject(rService["pa_cf"]),
					codicePaIpa = stringFromObject(Conn.readValue("registry", q.eq("idreg", rService["idconferring"]), "ipa_perlapa"))
				};
				if (conferente.codicePaIpa == null) {
					rService["perla_error"] = "Manca il Codice IPA nell'anagrafica del conferente";
					return null;
				}
				conf.Item = conferente;
			}

			if (personaFisica(rService)) { //Persona fisica
				var cc = new conferentepf() {
					codiceFiscale = stringFromObject(rService["pa_cf"]),
					cognome = stringFromObject(rService["conferring_surname"]),
					nome = stringFromObject(rService["conferring_forename"]),
					genere = rService["conferring_gender"].ToString().ToUpper() == "M" ? Sesso.M : Sesso.F
				};

				if(rService["idcity"] != DBNull.Value) {
					string codiceCastaleComune = stringFromObject(Conn.readValue("geo_city_agency", q.eq("idcity", rService["idcity"]) & q.eq("idcode",1) & q.eq("idagency", 1), "value"));
					if (codiceCastaleComune != "")
						cc.comuneNascita = codiceCastaleComune;
				}
				if (rService["conferring_birthdate"] != DBNull.Value) {
					cc.dataNascita = (DateTime) rService["conferring_birthdate"];
				}
				else {
					rService["perla_error"] = "Data nascita Conferente assente";
					return null;
				}
				conf.Item = cc;
			}

			return conf;
		}

		string stringFromObject(object s) {
			if (s == DBNull.Value || s == null) return null;
			return s.ToString();
		}

		System.Byte[] getCurriculum(object idreg) {
			var curriculum = Conn.readFromTable("registrycvattachment", q.eq("idreg", idreg), "*", "referencedate desc",
				"1");
			if ((curriculum.Rows.Count > 0) &&
			    (curriculum.Rows[0]["attachment"] != DBNull.Value)) {
				return (System.Byte[]) curriculum.Rows[0]["attachment"];
			}

			return null;
		}

		private string lastFileDeclarationName = null;
		private System.Byte[] defaultDeclaration = null;

		private byte[] getAllegato(byte []sequence) {


			int offset = GetOffsetForData(sequence);
			var newArray = new byte[sequence.Length - offset];
			Array.Copy(sequence, offset, newArray, 0, newArray.Length);

			return newArray;
			
		}

		int GetOffsetForData(Byte[] B) {
			int i = 0;
			while (i < B.Length && B[i] != 0) i++;
			return i + 1;
		}

		System.Byte[] getFileDichiarazioneIncarichi(DataRow rService) {
			if (rService["dichiarazione_incarichi"] != DBNull.Value) {
				return getAllegato((System.Byte[]) rService["dichiarazione_incarichi"]);
			}

			if (txtFileAutocertDefault.Text == "") return null;
			return readAllegatoAutoCertificazione();

		}

		System.Byte[] readAllegatoAutoCertificazione() {
			// Legge il file indicato dall'utente 
			if (txtFileAutocertDefault.Text == "") return null;
			if (txtFileAutocertDefault.Text == lastFileDeclarationName) return defaultDeclaration;
			FileStream FS;
			try {
				FS = new FileStream(txtFileAutocertDefault.Text, FileMode.Open, FileAccess.Read);
			}
			catch (Exception e) {
				QueryCreator.ShowException("Errore nell'apertura del file", e);
				return null;
			}


			try {
				var ff = File.ReadAllBytes(txtFileAutocertDefault.Text);
				lastFileDeclarationName = txtFileAutocertDefault.Text;
				defaultDeclaration = ff;
				return defaultDeclaration;
			}
			catch {
			}

			return null;

		}

		int lengthForFileName(string S) {
			string fname = Path.GetFileName(S);
			return fname.Length + 1;
		}

		void setBytesForFileName(string S, byte[] B) {
			string fname = Path.GetFileName(S);
			byte[] b = Encoding.Default.GetBytes(fname);
			for (int i = 0; i < b.Length; i++) B[i] = b[i];
			B[b.Length] = 0;
		}

		private void btnSelezionaAutoCert_Click(object sender, EventArgs e) {
			DialogResult dialogResult;
			try {
				dialogResult = openFileDialog1.ShowDialog(this);
			}
			catch (Exception E) {
				QueryCreator.ShowException("Errore nella selezione  del file", E);
				return;
			}

			if (dialogResult == DialogResult.Cancel) return;
			txtFileAutocertDefault.Text = openFileDialog1.FileName;
		}

		private void btnInviaConsulenti2SemWS_Click(object sender, EventArgs e) {
			tipoIncarico nuovo_incarico = tipoIncarico.nuovoIncarico;
			if (!controlla_validita_codici("c", nuovo_incarico))
				return;
			//Consulenti Nuovo Incarico 2° semestre esercizo precedente
			if (inviaInserimentiWS("c", 3)) {
				DisabilitaButtons(((Control) sender).Name);
			}
		}



		private void btnInviaModifichePagamentiDipendentiWS_Click(object sender, EventArgs e) {		
			tipoIncarico modifica_incarico = tipoIncarico.modificaIncarico;
			if (!controlla_validita_codici("d", modifica_incarico)) return;
			//Dipendenti: solo pagamenti nuovi o modificati, di incarichi modificati
			if (inviaModificheWS("d", 4)) {
				DisabilitaButtons(((Control) sender).Name);
			}
		}

		private void btnInviaModifichePagamentiConsulentiWS_Click(object sender, EventArgs e) {
			tipoIncarico modifica_incarico = tipoIncarico.modificaIncarico;
			if (!controlla_validita_codici("c", modifica_incarico))
				return;
			//Consulenti: solo pagamenti nuovi o modificati, di incarichi del 2° semestre, esercizio precedente, modificati.
			if (inviaModificheWS("c", 6)) {
				DisabilitaButtons(((Control) sender).Name);
			}
		}



		private void btnModificaDatiConsulentiWS_Click(object sender, EventArgs e) {
			tipoIncarico modifica_incarico = tipoIncarico.modificaIncarico;
			if (!controlla_validita_codici("c", modifica_incarico))
				return;

			//Consulenti: solo dati di incarichi modificati. Tutti gli incarichi trasmessi. 
			if (inviaModificheWS("c", 7)) {
				DisabilitaButtons(((Control) sender).Name);
			}
		}

		private void btnModificaDatiDipendentiWS_Click(object sender, EventArgs e) {
			tipoIncarico modifica_incarico = tipoIncarico.modificaIncarico;
			if (!controlla_validita_codici("d", modifica_incarico))
				return;

			//Dipendenti: solo dati di incarichi modificati. Tutti gli incarichi trasmessi. 
			if (inviaModificheWS("d", 8)) {
				DisabilitaButtons(((Control) sender).Name);
			}
		}

		private void btnCancellazioneConsulentiWS_Click(object sender, EventArgs e) {
			tipoIncarico cancella_incarico = tipoIncarico.cancellaIncarico;
			if (!controlla_validita_codici("c", cancella_incarico))
				return;
			if (inviaCancellazioniWS("c", 9)) {
				DisabilitaButtons(((Control) sender).Name);
			}
		}

		private void btnCancellazioneDipendentiWS_Click(object sender, EventArgs e) {
			tipoIncarico cancella_incarico = tipoIncarico.cancellaIncarico;
			if (!controlla_validita_codici("d", cancella_incarico))
				return;
			if (inviaCancellazioniWS("d", 10)) {
				DisabilitaButtons(((Control) sender).Name);
			}
		}

		inserimento_incarico_consulente inserisciConsulente(DataRow rConsulente) {
			var w = new inserimento_incarico_consulente();
			w.amministrazionedichiarante.codiceFiscalePa = codiceFiscalePa;

			if (rConsulente["codicepaipa"] != DBNull.Value) {
				w.amministrazionedichiarante.codicePaIpa = rConsulente["codicepaipa"].ToString();
			}
			else {
				w.amministrazionedichiarante.codicePaIpa = codicePaIpa;
			}

			if (rConsulente["codiceaooipa"] != DBNull.Value) {
				w.amministrazionedichiarante.codiceAooIpa = rConsulente["codiceaooipa"].ToString();
			}
			else {
				w.amministrazionedichiarante.codiceAooIpa = codiceAooIpa; 
			}

			if (w.amministrazionedichiarante.codiceAooIpa == null) {
				if (rConsulente["codiceuoipa"] != DBNull.Value) {
					w.amministrazionedichiarante.codiceUoIpa = rConsulente["codiceuoipa"].ToString();
				}
				else {
					w.amministrazionedichiarante.codiceUoIpa = codiceUoIpa;
				}
			}



			w.percettore.tipologia = rConsulente["flaghuman"].ToString().ToUpper() == "S"
				? tipoConsulente.F
				: tipoConsulente.G;
			if (w.percettore.tipologia == tipoConsulente.F) {
				w.allegati.fileCv = getCurriculum(rConsulente["idreg"]);
				w.allegati.fileDichiarazioneIncarichi = getFileDichiarazioneIncarichi(rConsulente);
			}

			if (w.percettore.tipologia == tipoConsulente.F) {
				var percPF = new inserimento_incarico_consulentePercettorePercettorepf() {
					estero = rConsulente["flagforeign"].ToString().ToUpper() == "S" ? yesNo.Y : yesNo.N,
					codiceFiscale = stringFromObject(rConsulente["cf"]),
					cognome = rConsulente["surname"].ToString(),
					nome = rConsulente["forename"].ToString(),
					genere = rConsulente["gender"].ToString().ToUpper() == "F" ? Sesso.F : Sesso.M
				};
				if ( rConsulente["birthdate"]!=DBNull.Value) {
					percPF.dataNascita = (DateTime) rConsulente["birthdate"];
				}
				else {
					rConsulente["perla_error"] = "Data nascita Consulente assente";
					return null;
				}
				object idcity = Conn.readValue("registry", q.eq("idreg", rConsulente["idreg"]), "idcity");
				if (idcity != DBNull.Value) {
					percPF.comuneNascita = stringFromObject( //codice catastale
						Conn.readValue("geo_city_agency",
							q.eq("idcity", idcity) & q.eq("idagency", 1) & q.eq("idcode", 1),
							"value")); //codice catastale nascita
				}
				else {
					object idnation = Conn.readValue("registry", q.eq("idreg", rConsulente["idreg"]), "idnation");
					percPF.comuneNascita = stringFromObject( //codice catastale
						Conn.readValue("geo_nation_agency",
							q.eq("idnation", idnation) & q.eq("idagency", 1) & q.eq("idcode", 1),
							"value")); //codice nazione nascita

				}
				
				if (percPF.comuneNascita == "")

					{
						rConsulente["perla_error"] = "Comune o nazione nascita del Consulente assente";
						return null;
					}

				w.percettore.Item = percPF;
			}
			else {
				w.percettore.Item = new inserimento_incarico_consulentePercettorePercettorepg() {
					estero = rConsulente["flagforeign"].ToString().ToUpper() == "S" ? yesNo.Y : yesNo.N,
					codiceFiscale = stringFromObject(rConsulente["cf"]),
					denominazione = rConsulente["title"].ToString().Replace("\n", "").Replace("\r", "")
				};
			}

			if (rConsulente["idapactivitykind"] != DBNull.Value) {
				w.datiincarico.oggettoIncarico = rConsulente["idapactivitykind"].ToString(); //apActivitykind[];
			}

			if (rConsulente["authorizationdate"] != DBNull.Value) {
				w.datiincarico.dataConferimento = (DateTime) rConsulente["authorizationdate"];
			}
			else {
				rConsulente["perla_error"] = "data conferimento assente";
				return null;
			}
			w.datiincarico.dataInizio = (DateTime) rConsulente["start"];
			w.datiincarico.estremiAttoConferimento = stringFromObject(rConsulente["actreference"]);
			w.datiincarico.tipoRapporto = rConsulente["idapcontractkind"].ToString();
			w.datiincarico.naturaConferimento = rConsulente["idacquirekind"].ToString() == "1" ? "1" : "2";
			if (rConsulente["ordinancelink"] != DBNull.Value) {
				w.datiincarico.sitoWebTrasparenza = rConsulente["ordinancelink"].ToString();
			}
			else {
				rConsulente["perla_error"] = "Link al decreto di conferimento dell’incarico assente";
				return null;
			}

			w.datiincarico.attestazioneVerificaInsussistenza =
				(rConsulente["certinterestconflicts"].ToString() != "") ? yesNo.Y : yesNo.N;
			string fieldvalue = rConsulente["regulation"].ToString().ToUpper();
			w.datiincarico.riferimentoRegolamento = (fieldvalue == "S") ? yesNo.Y : yesNo.N;

			if (rConsulente["idreferencerule"] != DBNull.Value) {
				w.riferimentonormativo.riferimento = rConsulente["idreferencerule"].ToString();
				w.riferimentonormativo.numero = rConsulente["articlenumber"].ToString();
				w.riferimentonormativo.articolo = rConsulente["article"].ToString();
				if (rConsulente["paragraph"] != DBNull.Value) {
					w.riferimentonormativo.comma = rConsulente["paragraph"].ToString();
				}

				w.riferimentonormativo.data = (DateTime) rConsulente["referencedate"];
			}
			else {
				w.riferimentonormativo = null;
			}

			decimal pagato = CfgFn.GetNoNullDecimal(Conn.readValue("servicepayment",q.keyCmp(rConsulente),"sum(payedamount)"));

			decimal importoPresunto = CfgFn.GetNoNullDecimal(rConsulente["expectedamount"]);
			//if (pagato > 0) {
				w.datiincarico.dateconomici._compenso = importoPresunto;
				w.datiincarico.dateconomici.componentiVariabilCompenso = yesNo.N;
				w.datiincarico.dateconomici.tipoCompenso =
					(importoPresunto == 0) ? "3" : "2"; //presunto se > 0 altr. gratuito

				w.datiincarico.dateconomici._ammontareErogato = pagato;
				w.datiincarico.dateconomici.incaricoSaldato =
					(rConsulente["payment"].ToString().ToUpper() == "S") ? yesNo.Y : yesNo.N;
				if (rConsulente["stop"] != DBNull.Value) {
					w.datiincarico.dateconomici.dataFine = (DateTime) rConsulente["stop"];
					w.datiincarico.dateconomici.dataFineSpecified = true;
				}
			//}
			//else {
			//	w.datiincarico.dateconomici = null;
			//}


			return w;
		}


		variazione_incarico_consulente updateConsulente(DataRow rConsulente) {
			var w = new variazione_incarico_consulente();
			w.amministrazionedichiarante.codiceFiscalePa = codiceFiscalePa;

			if (rConsulente["codicepaipa"] != DBNull.Value) {
				w.amministrazionedichiarante.codicePaIpa = rConsulente["codicepaipa"].ToString();
			}
			else {
				w.amministrazionedichiarante.codicePaIpa = codicePaIpa;
			}

			if (rConsulente["codiceaooipa"] != DBNull.Value) {
				w.amministrazionedichiarante.codiceAooIpa = rConsulente["codiceaooipa"].ToString();
			}
			else {
				w.amministrazionedichiarante.codiceAooIpa = codiceAooIpa; 
			}

			if (w.amministrazionedichiarante.codiceAooIpa == null) {
				if (rConsulente["codiceuoipa"] != DBNull.Value) {
					w.amministrazionedichiarante.codiceUoIpa = rConsulente["codiceuoipa"].ToString();
				}
				else {
					w.amministrazionedichiarante.codiceUoIpa = codiceUoIpa;
				}
			}

			w.datiincarico.idIncarico = Convert.ToUInt64(rConsulente["id_service"]);

			var tipologia = rConsulente["flaghuman"].ToString().ToUpper() == "S" ? tipoConsulente.F : tipoConsulente.G;
			if (tipologia == tipoConsulente.F) {
				w.allegati.fileCv = getCurriculum(rConsulente["idreg"]);
				w.allegati.fileDichiarazioneIncarichi = getFileDichiarazioneIncarichi(rConsulente);
			}

			w.datiincarico.oggettoIncarico = rConsulente["idapactivitykind"].ToString(); //apActivitykind[];
			w.datiincarico.estremiAttoConferimento = stringFromObject(rConsulente["actreference"]);
			w.datiincarico.tipoRapporto = rConsulente["idapcontractkind"].ToString();
			w.datiincarico.naturaConferimento = rConsulente["idacquirekind"].ToString() == "1" ? "1" : "2";
			if (rConsulente["ordinancelink"] != DBNull.Value) {
				w.datiincarico.sitoWebTrasparenza = rConsulente["ordinancelink"].ToString();
			}

			w.datiincarico.attestazioneVerificaInsussistenza =
				(rConsulente["certinterestconflicts"].ToString() != "") ? yesNo.Y : yesNo.N;
			string fieldvalue = rConsulente["regulation"].ToString().ToUpper();
			w.datiincarico.riferimentoRegolamento = (fieldvalue == "S") ? yesNo.Y : yesNo.N;

			if (rConsulente["idreferencerule"] != DBNull.Value) {
				w.riferimentonormativo.riferimento = rConsulente["idreferencerule"].ToString();
				w.riferimentonormativo.numero = rConsulente["articlenumber"].ToString();
				w.riferimentonormativo.articolo = rConsulente["article"].ToString();
				if (rConsulente["paragraph"] != DBNull.Value) {
					w.riferimentonormativo.comma = rConsulente["paragraph"].ToString();
				}

				if (rConsulente["referencedate"] == DBNull.Value) {
					rConsulente["perla_error"] = "Data riferimento normativo assente";
					return null;
				}
				w.riferimentonormativo.data = (DateTime) rConsulente["referencedate"];
			}
			else {
				w.riferimentonormativo = null;
			}

			string filtroPagamento = QHC.MCmp(rConsulente, new string[] {"yservreg", "nservreg"});

			decimal importoPresunto = CfgFn.GetNoNullDecimal(rConsulente["expectedamount"]);
			w.datiincarico.dateconomici._compenso = importoPresunto;
			w.datiincarico.dateconomici.componentiVariabilCompenso = yesNo.N;
			w.datiincarico.dateconomici.tipoCompenso =
				(importoPresunto == 0) ? "3" : "2"; //presunto se > 0 altr. gratuito

			decimal pagato = CfgFn.GetNoNullDecimal(Conn.readValue("servicepayment",q.keyCmp(rConsulente),"sum(payedamount)"));

			w.datiincarico.dateconomici._ammontareErogato = pagato;
			w.datiincarico.dateconomici.incaricoSaldato =
				(rConsulente["payment"].ToString().ToUpper() == "S") ? yesNo.Y : yesNo.N;
			if (rConsulente["stop"] != DBNull.Value) {
				w.datiincarico.dateconomici.dataFine = (DateTime) rConsulente["stop"];
				w.datiincarico.dateconomici.dataFineSpecified = true;
			}

			return w;
		}

		private bool inviaCancellazioniWS(string tipo, int tipologia) {

			frmAskPassword f = new frmAskPassword(user, password);
			if (f.ShowDialog(this) == DialogResult.OK) {
				user = f.txtUser.Text;
				password = f.txtPassword.Text;
			}

			meta.GetFormData(true);
			//object esercizio = meta.GetSys("esercizio");
			//string filtereserc_service = QHS.CmpEq("yservreg", esercizio);// Per l'inserimento prendiamo solo quelli = all'esercizio corrente
			//string filtereserc_payment = QHS.CmpEq("yservreg", esercizio);
			object esercizio = meta.GetSys("esercizio");

			//filtroCancellaIncarico  = " (is_delivered ='N' and is_annulled='S' and is_blocked = 'N') ";
			string filtereserc_service = filtroCancellaIncarico;


			DS.serviceregistry.Clear();
			// inserisci in serviceregistry solo gli incarcichi dei C o D




			string security = Conn.SelectCondition("serviceregistry", true);
			security = QHS.AppAnd(security, getFilterSicurezza());
			if (tipo.ToUpper() == "D") {
				//kind = D
				DataAccess.RUN_SELECT_INTO_TABLE(meta.Conn, DS.serviceregistry, null,
					QHS.AppAnd(QHS.CmpEq("employkind", "D"), filtereserc_service, security), null, true);
			}
			else {
				//kind= C or A
				DataAccess.RUN_SELECT_INTO_TABLE(meta.Conn, DS.serviceregistry, null,
					QHS.AppAnd(QHS.CmpNe("employkind", "D"), filtereserc_service, security), null, true);
			}

			DataRow Curr = DS.servicetrasmission.Rows[0];


			if (DS.serviceregistry.Rows.Count == 0) {
				show(this, "Non ci sono Annullamenti di incarichi da trasmettere");
				return false;
			}

			var ser = new EServizioNew().Create(user, password);
			var messages = new List<string>();

			string mess = (tipo == "d" ? "Dipendenti" : "Consulenti");

			foreach (DataRow service in DS.serviceregistry.Select()) {
				var d = new cancellazioneincarico_incarico();
				d.datiincarico.idIncarico = Convert.ToUInt64(service["id_service"]);
				impostaBloccoPrestazione(service, true);
				meta.SaveFormData();
				if (DS.HasChanges()) {
					return false;
				}

				var com = new comunicazione();
				com.Item = d;
				var req = new cancellazioneIncaricoRequest(user, password, SerializeToXmlElement(com));
				var res = ser.cancellazioneIncarico(req);
				var localMessages = new List<string>();
				ElaboraFileRitorno(SerializeToXmlDocument(res), localMessages);
				if (localMessages.Count > 0) {
					var sb = new StringBuilder();
					foreach (string m in localMessages) {
						sb.AppendLine(m);
						messages.Add(m);
					}

					service["perla_error"] = sb.ToString();
				}

				impostaBloccoPrestazione(service, false);
				meta.SaveFormData();
				if (DS.HasChanges()) {
					return false;
				}
			}

			show(this, @"Dati inviati", @"Informazione");

			//btnVisualizzaFile.Enabled = true;
			//btnSalvaXml.Enabled = true;
			return true;
			//btnSalvaFile.Enabled = true;
		}



		/// <summary>
		/// Elabora il file di ritorno e cambia il dataset in base al suo esito ove positivo
		/// </summary>
		/// <param name="service"></param>
		/// <param name="document"></param>
		/// <param name="messages"></param>
		/// <returns></returns>
		private bool elaboraFileRitorno(DataRow service, XmlDocument document,string req, string resp, out string error) {
			error = null;
			XmlElement Comunicazione = document.DocumentElement;
			// ESITO INSERIMENTO INCARICHI
			string errorField = "";
			XmlNamespaceManager nsmgr = new XmlNamespaceManager(document.NameTable);
			nsmgr.AddNamespace("ab", "http://perlapa.gov.it/");
			var esitoFile = Comunicazione.SelectSingleNode("//ab:esito",nsmgr);
			if (esitoFile.InnerText.ToUpper() == "KO") {
				error = Comunicazione.SelectSingleNode("//ab:descrizioneEsitoKO",nsmgr).InnerText.Replace("\n","\r\n");
				error += "\r\n\r\nRichiesta:\r\n" + req + "\r\n\r\n";
				error+="Risposta:\r\n" + resp+ "\r\n";
				service["perla_error"] = error;
				error = service["perla_error"].ToString();
				return false;
			}

			foreach (XmlElement c in Comunicazione.GetElementsByTagName("inserimentoIncarico_DipendenteResult")) {
				if (c == null) continue;
				TrasmissioneApprovata(service, c, "I");
			}
			foreach (XmlElement c in Comunicazione.GetElementsByTagName("inserimentoIncarico_ConsulenteResult")) {
				if (c == null) continue;
				TrasmissioneApprovata(service, c, "I");
			}
			foreach (XmlElement c in Comunicazione.GetElementsByTagName("variazioneIncarico_ConsulenteResult")) {
				if (c == null) continue;
				TrasmissioneApprovata(service, c, "M");
			}
			foreach (XmlElement c in Comunicazione.GetElementsByTagName("variazioneIncarico_DipendenteResult")) {
				if (c == null) continue;
				TrasmissioneApprovata(service, c, "M");
			}

			foreach (XmlElement c in Comunicazione.GetElementsByTagName("cancellazioneIncaricoResult")) {
				TrasmissioneApprovata(service, c, "C");
			}
			// ESITO MODIFICA INCARICHI

			
			return true;

		}


	}
	public class Utf8StringWriter : StringWriter
	{
		public override Encoding Encoding => Encoding.UTF8;
	}
}

