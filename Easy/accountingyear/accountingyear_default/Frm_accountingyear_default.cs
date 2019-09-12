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
using System.IO;
using funzioni_configurazione;

namespace accountingyear_default//esercizio_creazione//
{
	/// <summary>
	/// Summary description for frmesercizio_creazione.
	/// </summary>
	public class Frm_accountingyear_default : System.Windows.Forms.Form
	{
		private Crownwood.Magic.Controls.TabControl tabController;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnBack;
		private Crownwood.Magic.Controls.TabPage tabPage1;
		private Crownwood.Magic.Controls.TabPage tabPage2;
		private Crownwood.Magic.Controls.TabPage tabPage3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private DataAccess Conn;
		private System.Windows.Forms.DataGrid gridCheck;
		private System.Windows.Forms.TextBox txtSave;
		private Crownwood.Magic.Controls.TabPage tabPageInizio;
		private System.Windows.Forms.Label lblFase2;
		private System.Windows.Forms.Label lblFase4;
		private System.Windows.Forms.Label lblFase3;
		private System.Windows.Forms.Label lblFase5;
		private System.Windows.Forms.Label lblFase7;
		private System.Windows.Forms.Label lblFase6;
		private System.Windows.Forms.Button btnFase2;
		private System.Windows.Forms.Button btnFase3;
		private System.Windows.Forms.Button btnFase4;
		private System.Windows.Forms.Button btnFase5;
		private System.Windows.Forms.Button btnFase6;
		private System.Windows.Forms.Button btnFase7;
		private int esercizio;
        private int flagdbo = 0;
		private int flagcreazioneesercizio=1;
		private int flagtrasfbilancio=2;
		private int flagtrasfconfigbilancio=3;
		private int flagtrasfresiduientrata=4;
		private int flagtrasfresiduispesa=5;
		private int flagchiusuraesercizio=6;
        private string[] Flags = new string[7] { "N", "N", "N", "N", "N", "N", "S" };
		public /*Rana:esercizio_creazione.*/vistaForm DS;
		private System.Windows.Forms.Label lbl_1_3;
		private System.Windows.Forms.Label lbl_1_2;
		private System.Windows.Forms.Label lbl_1_1;
		private System.Windows.Forms.Label lbl_2_1;
		private int FASE=0;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.TextBox txtFine;
		private System.Windows.Forms.Label lbl_3_1;
		private System.Windows.Forms.TextBox txtFineSave;
		private System.Windows.Forms.Button btnFineSave;
		private MetaData Meta;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.TextBox txtFase2;
		private System.Windows.Forms.TextBox txtFase3;
		private System.Windows.Forms.TextBox txtFase4;
		private System.Windows.Forms.TextBox txtFase5;
		private System.Windows.Forms.TextBox txtFase6;
		private System.Windows.Forms.TextBox txtFase7;
        private TextBox txtFase1;
        private Button btnFase1;
        private Label lblFase1;
        private Button btnManuale;
        private Panel panel2;
        private TextBox txtManuale;
        private Panel panel1;
        private TextBox txtFase8;
        private Button btnFase8;
        private Label lblFase8;
        private TextBox textBox1;
        private Button btnAssestaManuale;
        private Panel panel3;
        private Panel panel4;
        private TextBox textBox2;
        private Button btnCopiavariniziali;
        private TextBox textBox3;
        private Button btnValorizzaSaldo;
        private Panel panel5;
		private string[] Titolo = new string[9];

		public Frm_accountingyear_default()
		{
			InitializeComponent();
			tabController.HideTabsMode = 
				Crownwood.Magic.Controls.TabControl.HideTabsModes.HideAlways;

			DisplayTabs(0);
			Titolo[0]="Chiusura - Fase Corrente";
            Titolo[1] = "Trasferimento Tabelle in Comune";
			Titolo[2]="Creazione Esercizio";
			Titolo[3]="Trasferimento Bilancio";
			Titolo[4]="Trasferimento Configurazione Bilancio";
			Titolo[5]="Trasferimento Residui Entrata";
			Titolo[6]="Trasferimento Residui Spesa";
			Titolo[7]="Chiusura Esercizio Corrente";
            Titolo[8] = "Riapertura Esercizio Corrente";
		}

        CQueryHelper QHC;
        QueryHelper QHS;
		public void MetaData_AfterLink() {
			Meta=MetaData.GetMetaData(this);
			Meta.CanInsert=false;
			Meta.CanSave=false;
			Meta.CanCancel=false;
			Meta.SearchEnabled=false;
			this.Conn=Meta.Conn;
			esercizio=Convert.ToInt32(Meta.GetSys("esercizio"));
			CalcolaMessaggiHelp();
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
		}

		void CalcolaMessaggiHelp(){
			int eserciziosucc= esercizio+1;
			txtFase4.Text="Da effettuarsi dopo l'1/1/"+eserciziosucc.ToString();
			txtFase5.Text="Da effettuarsi dopo essere sicuri di non dover più inserire/modificare/eliminare accertamenti del "+
					esercizio.ToString()+".";
			txtFase6.Text="Da effettuarsi dopo essere sicuri di non dover più inserire/modificare/eliminare impegni del "+
				esercizio.ToString()+".";
			txtFase7.Text="Da effettuarsi dopo essere sicuri di non dover effettuare più alcuna modifica "+
						"nell'esercizio "+esercizio.ToString();
            txtFase8.Text = "Fase che consente la riapertura dell'esercizio " + esercizio.ToString()
                + " precedentemente chiuso ";
		}


		public void MetaData_AfterActivation() {
            int nextesercizio = esercizio + 1;
            int prevesercizio = esercizio - 1;
            abilitaCopiaVariazioniIniziali();

            if (!EsercizioChiuso(prevesercizio)) {
                string msg = "Non sarà possibile creare un nuovo esercizio (il " + nextesercizio.ToString() +
					") in quanto l'esercizio precedente (il "+prevesercizio.ToString()+") non è ancora chiuso.";
				MessageBox.Show(msg, "Chiusura corrente",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
				this.Focus();
				return;
			}

			if (EsercizioChiuso(esercizio)) {
				string msg="Questo esercizio (il "+esercizio.ToString()+") è stato chiuso e non è più modificabile.";
				MessageBox.Show(msg, "Chiusura corrente",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
				this.Focus();
                if (!EsercizioConTrasferimenti(esercizio + 1)) {
                    abilitaRiapertura();
                }
				return;
			}
			AbilitaFunzioni();
            abilitaBottoneTrasfPrev();
            abilitaBottoneStornaPrev();
		}

		public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
			Text=Titolo[0];
		}

		/// <summary>
		/// A seconda dei flag presenti nella riga esercizio abilita/disabilita
		/// le funzioni
		/// </summary>
		private void AbilitaFunzioni() {
			for (int i=0; i<Flags.Length; i++) {
				if (AbilitaControllo(i+1, Flags[i])) {
					return;
				}
			}
		}

        private void abilitaBottoneTrasfPrev() {
            if (DS.accountingyear.Rows.Count == 0) return;
            DataRow[] Esercizio = DS.accountingyear.Select(QHC.CmpEq("ayear", Meta.GetSys("esercizio")));
            if (Esercizio.Length == 0) return;
            DataRow Curr = Esercizio[0];
            bool abilita =( (CfgFn.GetNoNullInt32(Curr["flag"]) & 0x0F )  >= 2 )&&
                            ( (CfgFn.GetNoNullInt32(Curr["flag"]) & 0x0F )  <= 3 );
            btnManuale.Enabled = abilita;
        }

        bool CanTransferInitialPrev(int esercizio) {
            //l'esercizio corrente bene o male esiste ma non deve essere stata eseguita la fase 4 dell'anno precedente
            string[] flags = GetFlagForYear(esercizio-1);
            if (flags == null) return true;
            return (flags[flagtrasfconfigbilancio] == "N");
        }

        private void abilitaCopiaVariazioniIniziali(){
            btnCopiavariniziali.Enabled = true;
        }
        private void abilitaBottoneStornaPrev() {
            if (DS.accountingyear.Rows.Count == 0) return;
            DataRow[] Esercizio = DS.accountingyear.Select(QHC.CmpEq("ayear", Meta.GetSys("esercizio")));
            if (Esercizio.Length == 0) return;
            DataRow Curr = Esercizio[0];
            bool abilita = ((CfgFn.GetNoNullInt32(Curr["flag"]) & 0x0F) >= 3);
            btnAssestaManuale.Enabled = abilita;
        }

        private void abilitaRiapertura() {
            if (DS.accountingyear.Rows.Count == 0) return;
            DataRow[] Esercizio = DS.accountingyear.Select(QHC.CmpEq("ayear", Meta.GetSys("esercizio")));
            if (Esercizio.Length == 0) return;
            DataRow Curr = Esercizio[0];
            bool abilita =( (CfgFn.GetNoNullInt32(Curr["flag"]) & 0x0F ) == 6 );
            btnFase8.Enabled = abilita;
        }
        
		/// <summary>
		/// Restituisce il controllo dato il nome
		/// </summary>
		/// <param name="nome">nome del controllo da cercare</param>
		/// <returns>il controllo da cercare</returns>
		private Control GetControl(Control container, string nome) {
			foreach (Control ctrl in container.Controls) {
				if (ctrl.Name==nome) return ctrl;
			}
			return null;
		}

		/// <summary>
		/// Abilita/disabilita il bottone della fase in input
		/// Se il flag=N restituisce true
		/// </summary>
		/// <param name="fase">fase</param>
		/// <param name="flag">valore flag</param>
		/// <returns>True quando flag = N</returns>
		private bool AbilitaControllo(int fase, string flag) {
			//Coloro la label
			string nome_label="lblFase"+fase;
			Label lbl = (Label)GetControl(tabController.TabPages[0],nome_label);
			lbl.ForeColor=GetColor(flag);
			//Abilito il button
			string nome_button="btnFase"+fase;
			Button btn = (Button)GetControl(tabController.TabPages[0],nome_button);
			btn.Enabled=(flag!="S");
			return (flag=="N");
		}

		private Color GetColor(string valore) {
			if (valore=="S")
				return Color.Blue;
			else
				return Color.Green;
		}

        /// <summary>
        /// restituisce null se l'esercizio in input non esiste
        /// </summary>
        /// <param name="esercizio"></param>
        /// <returns></returns>
        string[] GetFlagForYear(int esercizio) {
            string fCurrYear_C = QHC.CmpEq("ayear", esercizio);
            string fCurrYear_SQL = QHS.CmpEq("ayear", esercizio);
            int N = Conn.RUN_SELECT_COUNT("mainaccountingyear", fCurrYear_SQL, false);
            if (N == 0) return null;

            DataTable MyMainAccountingYear = Conn.RUN_SELECT("mainaccountingyear", "*", null, fCurrYear_SQL, null, false);
            if (MyMainAccountingYear == null || MyMainAccountingYear.Rows.Count == 0) return null;

            DataTable MyAccountingYear = Conn.RUN_SELECT("accountingyear", "*", null, fCurrYear_SQL, null, false);
            if (MyAccountingYear == null || MyAccountingYear.Rows.Count == 0) return null;


            DataRow MAY = MyMainAccountingYear.Rows[0];
            DataRow AY = MyAccountingYear.Rows[0];
            string[] myFlags = new string[7];

            object completed = MAY["completed"];

            if ((completed == null) || (completed == DBNull.Value)) {
                myFlags[flagdbo] = "N";
            }
            else {
                myFlags[flagdbo] = completed.ToString().ToUpper();
            }
            myFlags[flagcreazioneesercizio] = ((CfgFn.GetNoNullInt32(AY["flag"]) & 0x0F) >= 1) ? "S" : "N";
            myFlags[flagtrasfbilancio] = ((CfgFn.GetNoNullInt32(AY["flag"]) & 0x0F) >= 2) ? "S" : "N";
            myFlags[flagtrasfconfigbilancio] = ((CfgFn.GetNoNullInt32(AY["flag"]) & 0x0F) >= 3) ? "S" : "N";
            myFlags[flagtrasfresiduientrata] = ((CfgFn.GetNoNullInt32(AY["flag"]) & 0x0F) >= 4) ? "S" : "N";
            myFlags[flagtrasfresiduispesa] = ((CfgFn.GetNoNullInt32(AY["flag"]) & 0x0F) >= 5) ? "S" : "N";

            bool cinque_flag_a_S = true;
            for (int i = 0; i < myFlags.Length - 1; i++) {
                if (myFlags[i].ToString().ToUpper() != "S") {
                    cinque_flag_a_S = false;
                    break;
                }
            }
            //Il flag chiusura vale N (cioè è da eseguire) se tutti i cinque flag sono = S
            // e lo stato di finanza o patrimonio non è CHIUSO
            if (cinque_flag_a_S &&
                (//Rows[0]["financestatus"].ToString().ToUpper()!="CHIUSO"
                    ((CfgFn.GetNoNullInt32(AY["flag"]) & 0x0F) == 6)
                )) {
                myFlags[flagchiusuraesercizio] = "S";
            }
            else
                myFlags[flagchiusuraesercizio] = "N";

            return myFlags;

        }
		/// <summary>
		/// Lettura dei flag (per operazione) relativi all'esercizio
		/// </summary>
		/// <param name="esercizio">esercizio</param>
		/// <returns>True se per quell'esercizio sono state eseguite tutte le chiusure</returns>
		private bool EsercizioChiuso(int esercizio) {
            string[] FlagsRead = GetFlagForYear(esercizio);
            if (FlagsRead == null) return true; //se non c'è l'esercizio allora è come se fosse chiuso

            for (int i = 0; i < 7; i++) Flags[i] = FlagsRead[i];
            return (Flags[flagchiusuraesercizio] == "S");
            
		}

        private bool EsercizioConTrasferimenti(int esercizio) {
            string fCurrYear_C = QHC.CmpEq("ayear", esercizio);
            string fCurrYear_SQL = QHS.CmpEq("ayear", esercizio);

            DataRow[] Rows = DS.accountingyear.Select(fCurrYear_C);
            if (Rows.Length == 0) return false;

            int flag = CfgFn.GetNoNullInt32(Rows[0]["flag"]) & 0x0f;
            return (flag > 1);
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
            this.tabController = new Crownwood.Magic.Controls.TabControl();
            this.tabPageInizio = new Crownwood.Magic.Controls.TabPage();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.btnValorizzaSaldo = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnCopiavariniziali = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnAssestaManuale = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtFase8 = new System.Windows.Forms.TextBox();
            this.btnFase8 = new System.Windows.Forms.Button();
            this.lblFase8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtManuale = new System.Windows.Forms.TextBox();
            this.btnManuale = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtFase1 = new System.Windows.Forms.TextBox();
            this.btnFase1 = new System.Windows.Forms.Button();
            this.lblFase1 = new System.Windows.Forms.Label();
            this.txtFase7 = new System.Windows.Forms.TextBox();
            this.txtFase6 = new System.Windows.Forms.TextBox();
            this.txtFase5 = new System.Windows.Forms.TextBox();
            this.txtFase4 = new System.Windows.Forms.TextBox();
            this.txtFase3 = new System.Windows.Forms.TextBox();
            this.txtFase2 = new System.Windows.Forms.TextBox();
            this.btnFase7 = new System.Windows.Forms.Button();
            this.btnFase6 = new System.Windows.Forms.Button();
            this.btnFase5 = new System.Windows.Forms.Button();
            this.btnFase4 = new System.Windows.Forms.Button();
            this.btnFase3 = new System.Windows.Forms.Button();
            this.btnFase2 = new System.Windows.Forms.Button();
            this.lblFase6 = new System.Windows.Forms.Label();
            this.lblFase7 = new System.Windows.Forms.Label();
            this.lblFase5 = new System.Windows.Forms.Label();
            this.lblFase3 = new System.Windows.Forms.Label();
            this.lblFase4 = new System.Windows.Forms.Label();
            this.lblFase2 = new System.Windows.Forms.Label();
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.lbl_1_3 = new System.Windows.Forms.Label();
            this.lbl_1_2 = new System.Windows.Forms.Label();
            this.lbl_1_1 = new System.Windows.Forms.Label();
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.lbl_2_1 = new System.Windows.Forms.Label();
            this.txtSave = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.gridCheck = new System.Windows.Forms.DataGrid();
            this.tabPage3 = new Crownwood.Magic.Controls.TabPage();
            this.txtFineSave = new System.Windows.Forms.TextBox();
            this.btnFineSave = new System.Windows.Forms.Button();
            this.lbl_3_1 = new System.Windows.Forms.Label();
            this.txtFine = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.DS = new accountingyear_default.vistaForm();
            this.tabController.SuspendLayout();
            this.tabPageInizio.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCheck)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // tabController
            // 
            this.tabController.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabController.IDEPixelArea = true;
            this.tabController.Location = new System.Drawing.Point(8, 8);
            this.tabController.Name = "tabController";
            this.tabController.SelectedIndex = 0;
            this.tabController.SelectedTab = this.tabPageInizio;
            this.tabController.Size = new System.Drawing.Size(855, 579);
            this.tabController.TabIndex = 0;
            this.tabController.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPageInizio,
            this.tabPage1,
            this.tabPage2,
            this.tabPage3});
            // 
            // tabPageInizio
            // 
            this.tabPageInizio.Controls.Add(this.textBox3);
            this.tabPageInizio.Controls.Add(this.btnValorizzaSaldo);
            this.tabPageInizio.Controls.Add(this.panel5);
            this.tabPageInizio.Controls.Add(this.textBox2);
            this.tabPageInizio.Controls.Add(this.btnCopiavariniziali);
            this.tabPageInizio.Controls.Add(this.panel4);
            this.tabPageInizio.Controls.Add(this.textBox1);
            this.tabPageInizio.Controls.Add(this.btnAssestaManuale);
            this.tabPageInizio.Controls.Add(this.panel3);
            this.tabPageInizio.Controls.Add(this.txtFase8);
            this.tabPageInizio.Controls.Add(this.btnFase8);
            this.tabPageInizio.Controls.Add(this.lblFase8);
            this.tabPageInizio.Controls.Add(this.panel1);
            this.tabPageInizio.Controls.Add(this.txtManuale);
            this.tabPageInizio.Controls.Add(this.btnManuale);
            this.tabPageInizio.Controls.Add(this.panel2);
            this.tabPageInizio.Controls.Add(this.txtFase1);
            this.tabPageInizio.Controls.Add(this.btnFase1);
            this.tabPageInizio.Controls.Add(this.lblFase1);
            this.tabPageInizio.Controls.Add(this.txtFase7);
            this.tabPageInizio.Controls.Add(this.txtFase6);
            this.tabPageInizio.Controls.Add(this.txtFase5);
            this.tabPageInizio.Controls.Add(this.txtFase4);
            this.tabPageInizio.Controls.Add(this.txtFase3);
            this.tabPageInizio.Controls.Add(this.txtFase2);
            this.tabPageInizio.Controls.Add(this.btnFase7);
            this.tabPageInizio.Controls.Add(this.btnFase6);
            this.tabPageInizio.Controls.Add(this.btnFase5);
            this.tabPageInizio.Controls.Add(this.btnFase4);
            this.tabPageInizio.Controls.Add(this.btnFase3);
            this.tabPageInizio.Controls.Add(this.btnFase2);
            this.tabPageInizio.Controls.Add(this.lblFase6);
            this.tabPageInizio.Controls.Add(this.lblFase7);
            this.tabPageInizio.Controls.Add(this.lblFase5);
            this.tabPageInizio.Controls.Add(this.lblFase3);
            this.tabPageInizio.Controls.Add(this.lblFase4);
            this.tabPageInizio.Controls.Add(this.lblFase2);
            this.tabPageInizio.Location = new System.Drawing.Point(0, 0);
            this.tabPageInizio.Name = "tabPageInizio";
            this.tabPageInizio.Size = new System.Drawing.Size(855, 554);
            this.tabPageInizio.TabIndex = 6;
            this.tabPageInizio.Title = "Inizio";
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Location = new System.Drawing.Point(326, 467);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(511, 28);
            this.textBox3.TabIndex = 46;
            this.textBox3.TabStop = false;
            this.textBox3.Text = "Copia il saldo iniziale di TUTTI i cassieri leggendolo dall\'esercizio precedente." +
    "";
            // 
            // btnValorizzaSaldo
            // 
            this.btnValorizzaSaldo.Location = new System.Drawing.Point(7, 467);
            this.btnValorizzaSaldo.Name = "btnValorizzaSaldo";
            this.btnValorizzaSaldo.Size = new System.Drawing.Size(312, 28);
            this.btnValorizzaSaldo.TabIndex = 45;
            this.btnValorizzaSaldo.Text = "Copia saldo iniziale dall\'esercizio precedente";
            this.btnValorizzaSaldo.UseVisualStyleBackColor = true;
            this.btnValorizzaSaldo.Click += new System.EventHandler(this.btnValorizzaSaldo_Click);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Location = new System.Drawing.Point(8, 501);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(670, 2);
            this.panel5.TabIndex = 42;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(325, 336);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(511, 56);
            this.textBox2.TabIndex = 41;
            this.textBox2.TabStop = false;
            this.textBox2.Text = "La copia si riferisce all\'esercizio corrente, saranno copiate le variazioni inizi" +
    "ali di previsione dell\'esercizio corrente nella previsione iniziale corrente.";
            // 
            // btnCopiavariniziali
            // 
            this.btnCopiavariniziali.Enabled = false;
            this.btnCopiavariniziali.Location = new System.Drawing.Point(7, 341);
            this.btnCopiavariniziali.Name = "btnCopiavariniziali";
            this.btnCopiavariniziali.Size = new System.Drawing.Size(312, 50);
            this.btnCopiavariniziali.TabIndex = 40;
            this.btnCopiavariniziali.Text = "Copia variazioni iniziali nella previsione iniziale";
            this.btnCopiavariniziali.Click += new System.EventHandler(this.btnCopiavariniziali_Click);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Location = new System.Drawing.Point(10, 397);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(670, 2);
            this.panel4.TabIndex = 39;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(325, 405);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(511, 50);
            this.textBox1.TabIndex = 38;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "Per eseguire gli storni di assestamento devono essere state eseguite le prime 4 f" +
    "asi di chiusura";
            // 
            // btnAssestaManuale
            // 
            this.btnAssestaManuale.Enabled = false;
            this.btnAssestaManuale.Location = new System.Drawing.Point(7, 405);
            this.btnAssestaManuale.Name = "btnAssestaManuale";
            this.btnAssestaManuale.Size = new System.Drawing.Size(312, 50);
            this.btnAssestaManuale.TabIndex = 37;
            this.btnAssestaManuale.Text = "Storna le previsioni disponibile dell\'esercizio nel successivo (non usare la sche" +
    "rmata del bil. di assestamento)";
            this.btnAssestaManuale.Click += new System.EventHandler(this.btnAssestaManuale_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(7, 459);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(670, 2);
            this.panel3.TabIndex = 36;
            // 
            // txtFase8
            // 
            this.txtFase8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFase8.Location = new System.Drawing.Point(326, 508);
            this.txtFase8.Multiline = true;
            this.txtFase8.Name = "txtFase8";
            this.txtFase8.ReadOnly = true;
            this.txtFase8.Size = new System.Drawing.Size(511, 40);
            this.txtFase8.TabIndex = 35;
            this.txtFase8.TabStop = false;
            this.txtFase8.Text = "Fase che consente la riapertura di un esercizio precedentemente chiuso";
            // 
            // btnFase8
            // 
            this.btnFase8.Enabled = false;
            this.btnFase8.Location = new System.Drawing.Point(245, 506);
            this.btnFase8.Name = "btnFase8";
            this.btnFase8.Size = new System.Drawing.Size(75, 23);
            this.btnFase8.TabIndex = 34;
            this.btnFase8.Text = "Esegui";
            this.btnFase8.Click += new System.EventHandler(this.btnFase8_Click);
            // 
            // lblFase8
            // 
            this.lblFase8.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.lblFase8.Location = new System.Drawing.Point(5, 507);
            this.lblFase8.Name = "lblFase8";
            this.lblFase8.Size = new System.Drawing.Size(216, 16);
            this.lblFase8.TabIndex = 33;
            this.lblFase8.Text = "Riapertura Esercizio Corrente";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(8, 332);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(670, 2);
            this.panel1.TabIndex = 32;
            // 
            // txtManuale
            // 
            this.txtManuale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtManuale.Location = new System.Drawing.Point(325, 274);
            this.txtManuale.Multiline = true;
            this.txtManuale.Name = "txtManuale";
            this.txtManuale.ReadOnly = true;
            this.txtManuale.Size = new System.Drawing.Size(511, 50);
            this.txtManuale.TabIndex = 31;
            this.txtManuale.TabStop = false;
            this.txtManuale.Text = "Per eseguire il travaso devono essere state eseguite le prime 3 fasi di chiusura";
            // 
            // btnManuale
            // 
            this.btnManuale.Enabled = false;
            this.btnManuale.Location = new System.Drawing.Point(7, 273);
            this.btnManuale.Name = "btnManuale";
            this.btnManuale.Size = new System.Drawing.Size(312, 50);
            this.btnManuale.TabIndex = 30;
            this.btnManuale.Text = "Travasa le previsioni dell\'esercizio nel successivo (non usare la schermata del b" +
    "il. di previsione)";
            this.btnManuale.Click += new System.EventHandler(this.btnManuale_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(7, 265);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(670, 2);
            this.panel2.TabIndex = 29;
            // 
            // txtFase1
            // 
            this.txtFase1.Location = new System.Drawing.Point(325, 19);
            this.txtFase1.Name = "txtFase1";
            this.txtFase1.ReadOnly = true;
            this.txtFase1.Size = new System.Drawing.Size(336, 23);
            this.txtFase1.TabIndex = 22;
            this.txtFase1.TabStop = false;
            this.txtFase1.Text = "Fase propedeutica alla apertura del nuovo esercizio";
            // 
            // btnFase1
            // 
            this.btnFase1.Enabled = false;
            this.btnFase1.Location = new System.Drawing.Point(244, 17);
            this.btnFase1.Name = "btnFase1";
            this.btnFase1.Size = new System.Drawing.Size(75, 23);
            this.btnFase1.TabIndex = 21;
            this.btnFase1.Text = "Esegui";
            this.btnFase1.Click += new System.EventHandler(this.btnFase1_Click);
            // 
            // lblFase1
            // 
            this.lblFase1.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.lblFase1.Location = new System.Drawing.Point(4, 22);
            this.lblFase1.Name = "lblFase1";
            this.lblFase1.Size = new System.Drawing.Size(216, 16);
            this.lblFase1.TabIndex = 20;
            this.lblFase1.Text = "Trasferimento dati in comune";
            // 
            // txtFase7
            // 
            this.txtFase7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFase7.Location = new System.Drawing.Point(325, 229);
            this.txtFase7.Multiline = true;
            this.txtFase7.Name = "txtFase7";
            this.txtFase7.ReadOnly = true;
            this.txtFase7.Size = new System.Drawing.Size(511, 23);
            this.txtFase7.TabIndex = 19;
            this.txtFase7.TabStop = false;
            this.txtFase7.Text = "Fase propedeutica alla redazione del bilancio di previsione";
            // 
            // txtFase6
            // 
            this.txtFase6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFase6.Location = new System.Drawing.Point(325, 197);
            this.txtFase6.Multiline = true;
            this.txtFase6.Name = "txtFase6";
            this.txtFase6.ReadOnly = true;
            this.txtFase6.Size = new System.Drawing.Size(511, 23);
            this.txtFase6.TabIndex = 18;
            this.txtFase6.TabStop = false;
            this.txtFase6.Text = "Fase propedeutica alla redazione del bilancio di previsione";
            // 
            // txtFase5
            // 
            this.txtFase5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFase5.Location = new System.Drawing.Point(325, 149);
            this.txtFase5.Multiline = true;
            this.txtFase5.Name = "txtFase5";
            this.txtFase5.ReadOnly = true;
            this.txtFase5.Size = new System.Drawing.Size(511, 40);
            this.txtFase5.TabIndex = 17;
            this.txtFase5.TabStop = false;
            this.txtFase5.Text = "Da effettuarsi dopo essere sicuri ";
            // 
            // txtFase4
            // 
            this.txtFase4.Location = new System.Drawing.Point(325, 117);
            this.txtFase4.Name = "txtFase4";
            this.txtFase4.ReadOnly = true;
            this.txtFase4.Size = new System.Drawing.Size(336, 23);
            this.txtFase4.TabIndex = 16;
            this.txtFase4.TabStop = false;
            this.txtFase4.Text = "Da effettuarsi dopo l\'1/1/";
            // 
            // txtFase3
            // 
            this.txtFase3.Location = new System.Drawing.Point(325, 85);
            this.txtFase3.Name = "txtFase3";
            this.txtFase3.ReadOnly = true;
            this.txtFase3.Size = new System.Drawing.Size(336, 23);
            this.txtFase3.TabIndex = 15;
            this.txtFase3.TabStop = false;
            this.txtFase3.Text = "Fase propedeutica alla redazione del bilancio di previsione";
            // 
            // txtFase2
            // 
            this.txtFase2.Location = new System.Drawing.Point(325, 53);
            this.txtFase2.Name = "txtFase2";
            this.txtFase2.ReadOnly = true;
            this.txtFase2.Size = new System.Drawing.Size(336, 23);
            this.txtFase2.TabIndex = 13;
            this.txtFase2.TabStop = false;
            this.txtFase2.Text = "Fase propedeutica alla redazione del bilancio di previsione";
            // 
            // btnFase7
            // 
            this.btnFase7.Enabled = false;
            this.btnFase7.Location = new System.Drawing.Point(244, 227);
            this.btnFase7.Name = "btnFase7";
            this.btnFase7.Size = new System.Drawing.Size(75, 23);
            this.btnFase7.TabIndex = 11;
            this.btnFase7.Text = "Esegui";
            this.btnFase7.Click += new System.EventHandler(this.btnFase7_Click);
            // 
            // btnFase6
            // 
            this.btnFase6.Enabled = false;
            this.btnFase6.Location = new System.Drawing.Point(244, 195);
            this.btnFase6.Name = "btnFase6";
            this.btnFase6.Size = new System.Drawing.Size(75, 23);
            this.btnFase6.TabIndex = 10;
            this.btnFase6.Text = "Esegui";
            this.btnFase6.Click += new System.EventHandler(this.btnFase6_Click);
            // 
            // btnFase5
            // 
            this.btnFase5.Enabled = false;
            this.btnFase5.Location = new System.Drawing.Point(244, 147);
            this.btnFase5.Name = "btnFase5";
            this.btnFase5.Size = new System.Drawing.Size(75, 23);
            this.btnFase5.TabIndex = 9;
            this.btnFase5.Text = "Esegui";
            this.btnFase5.Click += new System.EventHandler(this.btnFase5_Click);
            // 
            // btnFase4
            // 
            this.btnFase4.Enabled = false;
            this.btnFase4.Location = new System.Drawing.Point(244, 115);
            this.btnFase4.Name = "btnFase4";
            this.btnFase4.Size = new System.Drawing.Size(75, 23);
            this.btnFase4.TabIndex = 8;
            this.btnFase4.Text = "Esegui";
            this.btnFase4.Click += new System.EventHandler(this.btnFase4_Click);
            // 
            // btnFase3
            // 
            this.btnFase3.Enabled = false;
            this.btnFase3.Location = new System.Drawing.Point(244, 83);
            this.btnFase3.Name = "btnFase3";
            this.btnFase3.Size = new System.Drawing.Size(75, 23);
            this.btnFase3.TabIndex = 7;
            this.btnFase3.Text = "Esegui";
            this.btnFase3.Click += new System.EventHandler(this.btnFase3_Click);
            // 
            // btnFase2
            // 
            this.btnFase2.Enabled = false;
            this.btnFase2.Location = new System.Drawing.Point(244, 51);
            this.btnFase2.Name = "btnFase2";
            this.btnFase2.Size = new System.Drawing.Size(75, 23);
            this.btnFase2.TabIndex = 6;
            this.btnFase2.Text = "Esegui";
            this.btnFase2.Click += new System.EventHandler(this.btnFase2_Click);
            // 
            // lblFase6
            // 
            this.lblFase6.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.lblFase6.Location = new System.Drawing.Point(4, 196);
            this.lblFase6.Name = "lblFase6";
            this.lblFase6.Size = new System.Drawing.Size(216, 16);
            this.lblFase6.TabIndex = 5;
            this.lblFase6.Text = "Trasferimento Residui Uscita";
            // 
            // lblFase7
            // 
            this.lblFase7.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.lblFase7.Location = new System.Drawing.Point(4, 228);
            this.lblFase7.Name = "lblFase7";
            this.lblFase7.Size = new System.Drawing.Size(216, 16);
            this.lblFase7.TabIndex = 4;
            this.lblFase7.Text = "Chiusura Esercizio Corrente";
            // 
            // lblFase5
            // 
            this.lblFase5.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.lblFase5.Location = new System.Drawing.Point(4, 148);
            this.lblFase5.Name = "lblFase5";
            this.lblFase5.Size = new System.Drawing.Size(216, 16);
            this.lblFase5.TabIndex = 3;
            this.lblFase5.Text = "Trasferimento Residui Entrata";
            // 
            // lblFase3
            // 
            this.lblFase3.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.lblFase3.Location = new System.Drawing.Point(4, 84);
            this.lblFase3.Name = "lblFase3";
            this.lblFase3.Size = new System.Drawing.Size(216, 16);
            this.lblFase3.TabIndex = 2;
            this.lblFase3.Text = "Trasferimento Bilancio";
            // 
            // lblFase4
            // 
            this.lblFase4.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.lblFase4.Location = new System.Drawing.Point(4, 116);
            this.lblFase4.Name = "lblFase4";
            this.lblFase4.Size = new System.Drawing.Size(226, 16);
            this.lblFase4.TabIndex = 1;
            this.lblFase4.Text = "Trasferimento Configurazione Bilancio";
            // 
            // lblFase2
            // 
            this.lblFase2.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.lblFase2.Location = new System.Drawing.Point(4, 52);
            this.lblFase2.Name = "lblFase2";
            this.lblFase2.Size = new System.Drawing.Size(216, 16);
            this.lblFase2.TabIndex = 0;
            this.lblFase2.Text = "Creazione Nuovo Esercizio";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lbl_1_3);
            this.tabPage1.Controls.Add(this.lbl_1_2);
            this.tabPage1.Controls.Add(this.lbl_1_1);
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Selected = false;
            this.tabPage1.Size = new System.Drawing.Size(855, 554);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Title = "Page1";
            // 
            // lbl_1_3
            // 
            this.lbl_1_3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_1_3.Location = new System.Drawing.Point(8, 128);
            this.lbl_1_3.Name = "lbl_1_3";
            this.lbl_1_3.Size = new System.Drawing.Size(831, 56);
            this.lbl_1_3.TabIndex = 2;
            // 
            // lbl_1_2
            // 
            this.lbl_1_2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_1_2.Location = new System.Drawing.Point(8, 48);
            this.lbl_1_2.Name = "lbl_1_2";
            this.lbl_1_2.Size = new System.Drawing.Size(831, 72);
            this.lbl_1_2.TabIndex = 1;
            // 
            // lbl_1_1
            // 
            this.lbl_1_1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_1_1.Location = new System.Drawing.Point(8, 8);
            this.lbl_1_1.Name = "lbl_1_1";
            this.lbl_1_1.Size = new System.Drawing.Size(831, 32);
            this.lbl_1_1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lbl_2_1);
            this.tabPage2.Controls.Add(this.txtSave);
            this.tabPage2.Controls.Add(this.btnSave);
            this.tabPage2.Controls.Add(this.gridCheck);
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            this.tabPage2.Size = new System.Drawing.Size(855, 554);
            this.tabPage2.TabIndex = 4;
            this.tabPage2.Title = "Page2";
            // 
            // lbl_2_1
            // 
            this.lbl_2_1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_2_1.Location = new System.Drawing.Point(16, 16);
            this.lbl_2_1.Name = "lbl_2_1";
            this.lbl_2_1.Size = new System.Drawing.Size(823, 40);
            this.lbl_2_1.TabIndex = 3;
            // 
            // txtSave
            // 
            this.txtSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSave.Location = new System.Drawing.Point(88, 515);
            this.txtSave.Name = "txtSave";
            this.txtSave.ReadOnly = true;
            this.txtSave.Size = new System.Drawing.Size(751, 23);
            this.txtSave.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(8, 515);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Salva in ...";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gridCheck
            // 
            this.gridCheck.AllowNavigation = false;
            this.gridCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridCheck.CaptionVisible = false;
            this.gridCheck.DataMember = "";
            this.gridCheck.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridCheck.Location = new System.Drawing.Point(8, 64);
            this.gridCheck.Name = "gridCheck";
            this.gridCheck.Size = new System.Drawing.Size(831, 443);
            this.gridCheck.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtFineSave);
            this.tabPage3.Controls.Add(this.btnFineSave);
            this.tabPage3.Controls.Add(this.lbl_3_1);
            this.tabPage3.Controls.Add(this.txtFine);
            this.tabPage3.Location = new System.Drawing.Point(0, 0);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Selected = false;
            this.tabPage3.Size = new System.Drawing.Size(855, 554);
            this.tabPage3.TabIndex = 5;
            this.tabPage3.Title = "Page3";
            // 
            // txtFineSave
            // 
            this.txtFineSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFineSave.Location = new System.Drawing.Point(88, 523);
            this.txtFineSave.Name = "txtFineSave";
            this.txtFineSave.ReadOnly = true;
            this.txtFineSave.Size = new System.Drawing.Size(759, 23);
            this.txtFineSave.TabIndex = 4;
            // 
            // btnFineSave
            // 
            this.btnFineSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFineSave.Location = new System.Drawing.Point(8, 523);
            this.btnFineSave.Name = "btnFineSave";
            this.btnFineSave.Size = new System.Drawing.Size(75, 23);
            this.btnFineSave.TabIndex = 3;
            this.btnFineSave.Text = "Salva in ...";
            this.btnFineSave.Click += new System.EventHandler(this.btnFineSave_Click);
            // 
            // lbl_3_1
            // 
            this.lbl_3_1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_3_1.Location = new System.Drawing.Point(8, 467);
            this.lbl_3_1.Name = "lbl_3_1";
            this.lbl_3_1.Size = new System.Drawing.Size(839, 48);
            this.lbl_3_1.TabIndex = 2;
            // 
            // txtFine
            // 
            this.txtFine.AcceptsReturn = true;
            this.txtFine.AcceptsTab = true;
            this.txtFine.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFine.Location = new System.Drawing.Point(8, 8);
            this.txtFine.Multiline = true;
            this.txtFine.Name = "txtFine";
            this.txtFine.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtFine.Size = new System.Drawing.Size(839, 443);
            this.txtFine.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(783, 595);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Annulla";
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(679, 595);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 8;
            this.btnNext.Text = "Avanti >";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(599, 595);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 7;
            this.btnBack.Text = "< Indietro";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(32, 595);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(130, 32);
            this.dataGrid1.TabIndex = 10;
            this.dataGrid1.Tag = "accountingyear.default";
            this.dataGrid1.Visible = false;
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // Frm_accountingyear_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(871, 632);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.tabController);
            this.Name = "Frm_accountingyear_default";
            this.Text = "frmesercizio_creazione";
            this.tabController.ResumeLayout(false);
            this.tabPageInizio.ResumeLayout(false);
            this.tabPageInizio.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCheck)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		void DisplayTabs(int newTab){
			tabController.SelectedIndex = newTab;
			//Evaluates Buttons Appearance
			btnBack.Visible=(newTab>1&&newTab<tabController.TabPages.Count-1);
			btnNext.Visible=(newTab>0);
			btnCancel.Visible=(newTab<tabController.TabPages.Count-1);
			if (newTab== tabController.TabPages.Count-1)
				btnNext.Text="Fine";
			else
				btnNext.Text="Avanti >";
			//non considera il primo tab
			string tabCount = Convert.ToString(tabController.TabPages.Count-1);
			if (newTab>0)
				Text=Titolo[FASE]+" (Pagina "+(newTab)+" di "+tabCount+")";
//			else
//				Text=CustomTitle;
		}

		private void btnBack_Click(object sender, System.EventArgs e) {
			StandardChangeTab(-1);
		}

		private void btnNext_Click(object sender, System.EventArgs e) {
			StandardChangeTab(+1);
		}

		void StandardChangeTab(int step){
			int oldTab= tabController.SelectedIndex;
			int newTab= oldTab+step;
			if ((newTab<0)||(newTab>tabController.TabPages.Count))return;
			if (!CustomChangeTab(oldTab, newTab)) return;
			if (newTab==tabController.TabPages.Count){
				DialogResult= DialogResult.OK;
				return;
			}
			DisplayTabs(newTab);
		}

		private bool CustomChangeTab(int oldTab, int newTab){
			if ((oldTab==1)&&(newTab==2)) {
				bool res= Check();
				ImpostaMessaggi(FASE);
				return res;
			}
			if ((oldTab==2)&&(newTab==3)) {
				return Fine();
			}
			return true;
		}

		private string GetCheckValue(CheckBox chk) {
			if (chk.Checked)
				return "S";
			else
				return "N";
		}

		private bool Check() {
			object[] list = new object[1] {esercizio};
			switch(FASE) {
                case 1:
                    return CheckFase("closeyear_check_commontable", list);
				case 2:
					return CheckFase("closeyear_check_yearcreate",list);
				case 3:
					return CheckFase("closeyear_check_fincopy",list);
				case 4:
					return CheckFase("closeyear_check_finsetupcopy",list);
				case 5:
					return CheckFase("closeyear_check_incomearrearscopy",list);
				case 6:
					return CheckFase("closeyear_check_expensearrearscopy",list);
			}
			return false;
		}

		private bool CheckFase(string spname,object[] list) {
			try {
				DataSet ds = Conn.CallSP(spname,list);
				DataTable T=ds.Tables[0];
				btnSave.Enabled=(T.Rows.Count>0);
				T.Columns[0].Caption="Errore";
				HelpForm.SetDataGrid(gridCheck,T);
				return true;
			}
			catch (Exception E) {
				MessageBox.Show("Errore: "+E.Message+"\r\rDettaglio: "+Conn.LastError,Titolo[FASE],
					MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}
		}

		private bool Fine() {
			if (!CanExecuteFase()) return false;
			object[] list = new object[1] {esercizio};
			switch(FASE) {
                case 1:
                    return ExecuteFase("closeyear_commontable", list);
				case 2:
					return ExecuteFase("closeyear_yearcreate",list);
				case 3:
					//object data=null;
					return ExecuteFase("closeyear_fincopy",list);
                    case 4: {
                        if (DateTime.Now.Year <= esercizio) {
                            MessageBox.Show("Attendere l'anno successivo per proseguire con le fasi di chiusura.");
                            return false;
                        }
                        return ExecuteFase("closeyear_finsetupcopy", list);
                    }
				case 5:
					return ExecuteFase("closeyear_incomearrearscopy",list);
				case 6:
					return ExecuteFase("closeyear_expensearrearscopy",list);
			}
			return false;
		}

		private bool CanExecuteFase() {
			DataTable T=GetGridTable();
			if (T.Rows.Count>0) {
				MessageBox.Show("Non è possibile procedere poiché ci sono "+
					"degli impedimenti.", "Attenzione",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
				return false;
			}
			return true;
		}

		private bool ExecuteFase(string spname, object[] list) {
			try {
                string errMess = Conn.BeginTransaction(IsolationLevel.ReadCommitted);
                if (errMess != null) {
                    QueryCreator.ShowError(this, "Errore aprendo la transazione", errMess);                    
                    return false;
                }
                DataSet ds = Conn.CallSP(spname, list, 60000, out errMess);
                if (errMess != null) {
                    Conn.RollBack();
                    QueryCreator.ShowError(this, "Errore nella chiamata della procedura " + spname +
                        "la transazione è stata interrotta.Contattare il servizio assistenza", errMess);
                   
                    return false;
                }

				//succede solo in fase 6 (chiusura esercizio)
                if ((spname == "closeyear_closeayear") || (spname == "closeyear_reopenayear")){
                    Conn.Commit();
                    return true;
                }
				DataTable T=ds.Tables[0];
                bool isOk = (T.Rows.Count > 0);
                if (isOk) {
                    string res = Conn.Commit();
                    if (res != null) {
                        MessageBox.Show("Errore nel salvataggio dei dati.\r\n" + res, "Errore");
                        return false;
                    }
                }
                else {
                    Conn.RollBack();
                    QueryCreator.ShowError(this, "Esecuzione della procedura " + spname +
                        "annullata.", "La procedura ha restituito dei messaggi di errore");
                    return false;
                    
                }
				btnFineSave.Enabled=isOk;

				foreach (DataRow R in T.Rows) {
					txtFine.Text+=QueryCreator.GetPrintable(R[0].ToString()+"\n");
				}
				return isOk;
			}
			catch (Exception E) {
			    Conn.RollBack();
				string msg="Errore nella chiamata alla procedura "+spname+
					"\r\rDettaglio: "+Conn.LastError;
				QueryCreator.ShowException(msg, E);
				return false;
			}
		}

		void ImpostaMessaggi(int fase){
			int NErrors= GetGridTable().Rows.Count;
			if (NErrors>0){
				SetLabelText(lbl_2_1,"Sono stati rilevati i seguenti impedimenti all'operazione richiesta."+
					" E' possibile salvarli su un file con il bottone in basso.");
				btnSave.Visible=true;
				txtSave.Visible=true;
				gridCheck.Visible=true;
			}
			else {
				SetLabelText(lbl_2_1,"Non ci sono impedimenti all'operazione. E' possibile proseguire.");
				btnSave.Visible=false;
				txtSave.Visible=false;
				gridCheck.Visible=false;
			}
		}

		private void SetTabLayout(int fase) {
			FASE=fase;
			this.Text=Titolo[fase];
			switch(fase) {
                case 1:
                    SetLabelText(lbl_1_1, "Trasferimento dati in comune.");
                    SetLabelText(lbl_1_2, "Verranno travasati i dati delle tabelle che hanno le stesse informazioni per " +
                    "tutti i dipartimenti.");
                    SetLabelText(lbl_1_3,"");
					SetLabelText(lbl_2_1,"Verifica in corso...");
					SetLabelText(lbl_3_1,"Dati travasati. Ora è possibile procedere "+
						"con la creazione dell'esercizio.");
                    break;
				case 2:
					SetLabelText(lbl_1_1,"Creazione di un nuovo esercizio.");
					SetLabelText(lbl_1_2,"Verrà creato un nuovo esercizio e trasferite alcune informazioni "+
						"indipendenti dalla struttura di bilancio.");
					SetLabelText(lbl_1_3,"");
					SetLabelText(lbl_2_1,"Verifica in corso...");
					SetLabelText(lbl_3_1,"Il nuovo esercizio è stato creato. Ora è possibile procedere "+
						"con il trasferimento del bilancio.");
					break;
				case 3:
					SetLabelText(lbl_1_1,"Traferimento del bilancio.");
					SetLabelText(lbl_1_2,"In questa fase è creata la struttura del bilancio per l'anno successivo.");
					SetLabelText(lbl_1_3,"");
					SetLabelText(lbl_2_1,"Verifica in corso...");
					SetLabelText(lbl_3_1,"La struttura del bilancio è stata trasferita al nuovo esercizio. "+
						"E' possibile ora creare il bilancio di previsione, ed usare il form "+
						" Configurazione/Chiusura/Converti voci del bilancio annuale "+
						"per creare delle speciali corrispondenze tra voci di bilancio.");
					break;
				case 4:
					SetLabelText(lbl_1_1,"Trasferimento della configurazione informazioni"+
						"dipendenti dal bilancio.");
					SetLabelText(lbl_1_2,"Saranno trasferite al nuovo esercizio tutte le configurazioni "+
						"connesse con la struttura del bilancio (ad esempio automatismi ritenute).");
					SetLabelText(lbl_1_3,"Nel trasferimento, ove presente, è utilizzata la tabella di conversione "+
						"del bilancio.");
					SetLabelText(lbl_2_1,"Verifica in corso...");
					SetLabelText(lbl_3_1,"Configurazione trasferita. Ora è possibile "+
						"iniziare ad operare sul nuovo esercizio e completare l'inserimento degli accertamenti "+
						"e impegni dell'anno in corso.");
					break;
				case 5:
					SetLabelText(lbl_1_1,"Trasferimento dei residui attivi.");
					SetLabelText(lbl_1_2,"Saranno trasferiti al nuovo esercizio i movimenti di entrata "+
						"non ancora completamente incassati.");
					SetLabelText(lbl_1_3,"");
					SetLabelText(lbl_2_1,"Verifica in corso...");
					SetLabelText(lbl_3_1,"I residui attivi sono stati trasferiti al nuovo esercizio. "+
						"E' possibile ora completare l'inserimento degli impegni dell'anno in corso per poi "+
						"trasferire i residui passivi.");
					break;
				case 6:
					SetLabelText(lbl_1_1,"Trasferimento dei residui passivi.");
					SetLabelText(lbl_1_2,"Saranno trasferiti al nuovo esercizio i movimenti di spesa "+
						"non ancora interamente pagati.");
					SetLabelText(lbl_1_3,"");
					SetLabelText(lbl_2_1,"Verifica in corso...");
					SetLabelText(lbl_3_1,"I residui passivi sono stati trasferiti al nuovo esercizio. "+
						"E' possibile ora eseguire l'assestamento del bilancio del nuovo esercizio.");
					break;
				case 7:
					SetLabelText(lbl_1_1,"");
					SetLabelText(lbl_1_2,"");
					SetLabelText(lbl_1_3,"");
					SetLabelText(lbl_2_1,"");
					SetLabelText(lbl_3_1,"");
					break;
                case 8:
                    SetLabelText(lbl_1_1, "");
                    SetLabelText(lbl_1_2, "");
                    SetLabelText(lbl_1_3, "");
                    SetLabelText(lbl_2_1, "");
                    SetLabelText(lbl_3_1, "");
                    break;
			}
            switch (fase) {
                case 7: {
                        ChiusuraEsercizio();
                        break;
                    }
                case 8: {
                        RiaperturaEsercizio("F");
                        break;
                    }
                default: {
                        DisplayTabs(1);
                        break;
                    }
            }
		}

		private void ChiusuraEsercizio() {
			string msg="Questa operazione chiude l'esercizio corrente. "+
				"Non sarà più possibile modificare alcun dato dell'esercizio. Confermi? ";
			if (MessageBox.Show(msg,Titolo[FASE],
				MessageBoxButtons.YesNo,MessageBoxIcon.Question)!=DialogResult.Yes)
				return;
			object[] list = new object[1]{esercizio};
			if (ExecuteFase("closeyear_closeayear", list)) {
				MessageBox.Show("Chiusura dell'esercizio " + esercizio,Titolo[FASE]+" effettuata.",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			Close();
		}

        private void RiaperturaEsercizio(string kind) {
            string msg = "Questa operazione riapre l'esercizio corrente. " +
                "I dati saranno resi nuovamente modificabili nell'esercizio in corso. Confermi? ";
            if (MessageBox.Show(msg, Titolo[FASE],
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            object[] list = new object[2] { esercizio, kind };
            if (ExecuteFase("closeyear_reopenayear", list)) {
                MessageBox.Show("Apertura dell'esercizio " + esercizio, Titolo[FASE] + " effettuata.",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Close();
        }



		private void SetLabelText(Label lbl, string testo) {
			lbl.Text=testo;
		}

        private void btnFase1_Click(object sender, EventArgs e) {
            SetTabLayout(1);
        }

        private void btnFase2_Click(object sender, System.EventArgs e) {
			SetTabLayout(2);
		}

        private void btnFase3_Click(object sender, System.EventArgs e) {
			SetTabLayout(3);
		}

        private void btnFase4_Click(object sender, System.EventArgs e) {
			SetTabLayout(4);
		}

        private void btnFase5_Click(object sender, System.EventArgs e) {
			SetTabLayout(5);
		}

		private void btnFase6_Click(object sender, System.EventArgs e) {
			SetTabLayout(6);
		}

		private void btnFase7_Click(object sender, System.EventArgs e) {
			SetTabLayout(7);
		}

        private void btnFase8_Click(object sender, EventArgs e) {
            SetTabLayout(8);
        }

		private void btnSave_Click(object sender, System.EventArgs e) {
            DataTable T = GetGridTable();
            if (T == null) {
                MessageBox.Show(this, "Nulla da salvare", "Avviso");
                return;
            }


                SaveFileDialog sf =new SaveFileDialog();
			sf.Title="Selezionare il file in cui verranno memorizzati "+
				"gli impedimenti";
			if (sf.ShowDialog()!=DialogResult.OK) return;
			string fullname=sf.FileName;
			txtSave.Text=fullname;
			try {
				StreamWriter sw=new StreamWriter(fullname,false,System.Text.Encoding.Default);
				foreach (DataRow R in T.Rows) {
					sw.WriteLine(R[0].ToString());
				}
				sw.Close();
			} catch {}
		}

		private DataTable GetGridTable() {
            if (gridCheck.DataSource == null) return null;
			return ((DataSet)gridCheck.DataSource).Tables[gridCheck.DataMember];
		}

		private void btnFineSave_Click(object sender, System.EventArgs e) {
			SaveFileDialog sf=new SaveFileDialog();
			sf.Title="Selezionare il file in cui verranno memorizzati i messaggi.";
			if (sf.ShowDialog()!=DialogResult.OK) return;
			string fullname=sf.FileName;
			txtFineSave.Text=fullname;
			try {
				StreamWriter sw=new StreamWriter(fullname,false,System.Text.Encoding.Default);
				sw.WriteLine(txtFine.Text);
				sw.Close();
			} catch {}
		}

        private void btnManuale_Click(object sender, EventArgs e) {
            string t = "Data su cui calcolare il bilancio di previsione:";
            AskDate frm = new AskDate(t, Meta.Conn);
            DialogResult dr = frm.ShowDialog();
            if ((dr != DialogResult.OK) || (frm.txtData.Text == "")){
                MessageBox.Show(this, "Non è stata impostata la data su cui calcolare il bilancio di previsione",
                    "Operazione Interrotta");
                return;
            }

            Conn.BeginTransaction(IsolationLevel.ReadCommitted);
            string errMess;

            DataSet ds = Conn.CallSP("exp_not_spread_prevision", new object[] {Meta.GetSys("esercizio")}, 600, out errMess);
            if (errMess != null) {
                MessageBox.Show(this, "Errore nella chiamata della procedura che controlla le previsioni non spalmate " +
                    "\r\rContattare il servizio assistenza"
                    + "\r\rDettaglio dell'errore :\r\r" + errMess, "Errore");
                Conn.RollBack();
                return;
            }

            DataTable tResult = ds.Tables[0];
            if (tResult.Rows.Count != 0) {
                string title = "Elenco voci di bilancio con previsione superiore ai figli";
                FrmError fErr = new FrmError(title, tResult);
                DialogResult drErr = fErr.ShowDialog();
                if (drErr != DialogResult.OK) {
                    MessageBox.Show(this, "Si è deciso di interrompere la procedura");
                    Conn.RollBack();
                    return;
                }
            }
            object dataPrevisione = HelpForm.GetObjectFromString(typeof(DateTime), frm.txtData.Text, "x.y");
            if ((dataPrevisione == null) || (dataPrevisione == DBNull.Value)){
                MessageBox.Show(this, "La data immessa non è valida, procedura interrotta", "Errore");
                Conn.RollBack();
                return;
            }
            ds = Conn.CallSP("compute_transf_prevision",
                new object[] { Meta.GetSys("esercizio"), dataPrevisione },
                600, out errMess);
            if (errMess != null) {
                MessageBox.Show(this, "Errore nella chiamata della procedura che trasferisce le previsioni " +
                     "nell'anno successivo la transazione è stata interrotta\r\rContattare il servizio assistenza"
                    + "\r\rDettaglio dell'errore :\r\r" + errMess, "Errore");
                Conn.RollBack();
                return;
            }
            MessageBox.Show(this, "Previsioni Trasferite", "Informazione", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Conn.Commit();

        }

        private void btnAssestaManuale_Click(object sender, EventArgs e) {
            string t = "Data su cui calcolare lo storno sulle previsioni:";
            AskDate frm = new AskDate(t, Meta.Conn);
            DialogResult dr = frm.ShowDialog();
            if ((dr != DialogResult.OK) || (frm.txtData.Text == "")) {
                MessageBox.Show(this, "Non è stata impostata la data su cui calcolare il bilancio di previsione",
                    "Operazione Interrotta");
                return;
            }

            Conn.BeginTransaction(IsolationLevel.ReadCommitted);
            string errMess;

            DataSet dsE = Conn.CallSP("exp_prevavailable_upb_fin", new object[] { Meta.GetSys("esercizio"), "E" }, 600, out errMess);
            if (errMess != null) {
                MessageBox.Show(this, "Errore nella chiamata della procedura che controlla le previsioni disponibili " +
                    "\r\rContattare il servizio assistenza"
                    + "\r\rDettaglio dell'errore :\r\r" + errMess, "Errore");
                Conn.RollBack();
                return;
            }
            int nRow = 0;
            if ((dsE != null) && (dsE.Tables.Count > 0)) {
                string title = "Elenco voci di bilancio di ENTRATA con previsione disponibile";
                FrmError fErr = new FrmError(title, dsE.Tables[0]);
                DialogResult drErr = fErr.ShowDialog();
                if (drErr != DialogResult.OK) {
                    MessageBox.Show(this, "Si è deciso di interrompere la procedura");
                    Conn.RollBack();
                    return;
                }
                nRow = dsE.Tables[0].Rows.Count;
            }

            DataSet dsS = Conn.CallSP("exp_prevavailable_upb_fin", new object[] { Meta.GetSys("esercizio"), "S" }, 600, out errMess);
            if (errMess != null) {
                MessageBox.Show(this, "Errore nella chiamata della procedura che controlla le previsioni disponibili " +
                    "\r\rContattare il servizio assistenza"
                    + "\r\rDettaglio dell'errore :\r\r" + errMess, "Errore");
                Conn.RollBack();
                return;
            }

            if ((dsS != null) && (dsS.Tables.Count > 0)) {
                string title = "Elenco voci di bilancio di SPESA con previsione disponibile";
                FrmError fErr = new FrmError(title, dsS.Tables[0]);
                DialogResult drErr = fErr.ShowDialog();
                if (drErr != DialogResult.OK) {
                    MessageBox.Show(this, "Si è deciso di interrompere la procedura");
                    Conn.RollBack();
                    return;
                }
                nRow += dsS.Tables[0].Rows.Count;
            }

            if (nRow == 0) {
                MessageBox.Show(this, "Non ci sono previsioni da stornare");
                Conn.RollBack();
                return;
            }

            object dataPrevisione = HelpForm.GetObjectFromString(typeof(DateTime), frm.txtData.Text, "x.y");
            if ((dataPrevisione == null) || (dataPrevisione == DBNull.Value)) {
                MessageBox.Show(this, "La data immessa non è valida, procedura interrotta", "Errore");
                Conn.RollBack();
                return;
            }

            DataSet ds = Conn.CallSP("compute_transf_prevavailable_upb_fin",
                new object[] { Meta.GetSys("esercizio"), dataPrevisione },
                600, out errMess);
            if (errMess != null) {
                MessageBox.Show(this, "Errore nella chiamata della procedura che effettua gli storni di previsione " +
                     "nell'anno successivo la transazione è stata interrotta\r\rContattare il servizio assistenza"
                    + "\r\rDettaglio dell'errore :\r\r" + errMess, "Errore");
                Conn.RollBack();
                return;
            }
            MessageBox.Show(this, "Previsioni Stornate", "Informazione", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Conn.Commit();

        }

        private void btnCopiavariniziali_Click(object sender, EventArgs e){
            if (!CanTransferInitialPrev(esercizio)) {
                MessageBox.Show("Il Bilancio di previsione " + esercizio + " è stata redatto, tuttavia sarà possibile procedere con l'operazione.");
            }

            string t = "Data alla quale considerare le variazioni iniziali di previsione:";
            AskDateAndMore frm = new AskDateAndMore(t, Meta.Conn);
            DialogResult dr = frm.ShowDialog();
            if ((dr != DialogResult.OK) || (frm.txtData.Text == ""))
            {
                MessageBox.Show(this, "Non è stata impostata la data alla quale considerare le variazioni iniziali di previsione",
                    "Operazione Interrotta");
                return;
            }

            Conn.BeginTransaction(IsolationLevel.ReadCommitted);
            string errMess;

            object datadiriferimento = HelpForm.GetObjectFromString(typeof(DateTime), frm.txtData.Text, "x.y");
            if ((datadiriferimento == null) || (datadiriferimento == DBNull.Value))
            {
                Conn.RollBack();
                MessageBox.Show(this, "La data immessa non è valida, procedura interrotta", "Errore");
                return;
            }
            object CopiaPrevPrecente = frm.CopiaPrevPrecente;
            DataSet ds = Conn.CallSP("compute_copy_variationinitial",
                new object[] { Meta.GetSys("esercizio"), datadiriferimento, CopiaPrevPrecente },
                600, out errMess);
            if (errMess != null)
            {
                Conn.RollBack();
                MessageBox.Show(this, "Errore nella chiamata della procedura che copia le variazioni iniziali di previsione " +
                     " nella previsione iniziale. La transazione è stata interrotta\r\rContattare il servizio assistenza"
                    + "\r\rDettaglio dell'errore :\r\r" + errMess, "Errore");
                return;
            }

            string filter =  "IsNull(UC.totprev, 0) > IsNull(FY.limit,0)";
            filter = QHS.AppAnd(filter,QHS.IsNotNull("FY.limit"), 
                    QHS.CmpEq("FY.ayear", CfgFn.GetNoNullInt32 (Meta.GetSys("esercizio"))  ));

            DataTable T = Conn.SQLRunner(

              " SELECT  FY.codeupb as UPB_Padre, FY.finpart as E_S, FY.codefin as Bilancio, "+
                    "FY.limit as Limite, UC.totprev as TotPrev FROM  " +
              " upbconstotal UC " +
	          " JOIN finyearview FY on UC.idfin=FY.idfin and UC.idupb= FY.idupb	" +
              " WHERE " + filter + " ORDER BY  FY.codeupb,  FY.finpart, FY.codefin",false,600);

            if ((T == null) || (T.Rows.Count == 0))
            {
                Conn.Commit();
                MessageBox.Show(this, "Previsioni Copiate.", "Informazione", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Conn.RollBack();

                string title = "Elenco voci di bilancio - UPB con limite di previsione superato";
                FrmError fErr = new FrmError(title, T);
                DialogResult drErr = fErr.ShowDialog();
          
                MessageBox.Show(this, "Previsioni Non Copiate.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnValorizzaSaldo_Click(object sender, EventArgs e){
            object idtreasurer;
            int ayearPrec = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio")) - 1;
            int ayear = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
            DataTable Treasurer = Conn.RUN_SELECT("treasurer", "idtreasurer, description", null, null, null, false);
            foreach (DataRow R in Treasurer.Rows)
            {
                idtreasurer = R["idtreasurer"];
                string filter = QHS.AppAnd(QHS.CmpEq("idtreasurer", idtreasurer), QHS.CmpEq("ayear", ayearPrec));
                decimal currentfloatfund = CfgFn.GetNoNullDecimal(Meta.Conn.DO_READ_VALUE("treasurercashtotal", filter, "currentfloatfund"));
                
                string script =
                " IF exists(SELECT * FROM [treasurerstart] WHERE ayear = " + QueryCreator.quotedstrvalue(ayear, true) + " AND idtreasurer =" + QueryCreator.quotedstrvalue(idtreasurer, true) + ")" +
                " BEGIN " +
                " UPDATE [treasurerstart] SET amount = " + QueryCreator.quotedstrvalue(currentfloatfund, true) + " ,ct = getdate(),cu = 'TreasurerstarCopy',lt = getdate(),lu = 'TreasurerstarCopy' " +
                " WHERE ayear = " + QueryCreator.quotedstrvalue(ayear, true) + " AND idtreasurer =" + QueryCreator.quotedstrvalue(idtreasurer, true) +
                " END " +
                " ELSE " +
                " BEGIN " +
                " INSERT INTO [treasurerstart] (ayear,idtreasurer,amount,ct,cu,lt,lu) " +
                " VALUES (" + QueryCreator.quotedstrvalue(ayear, true) + "," + QueryCreator.quotedstrvalue(idtreasurer, true) + "," + QueryCreator.quotedstrvalue(currentfloatfund, true) + "," +
                " getdate(),'TreasurerstarCopy',getdate(),'TreasurerstarCopy')" +
                " END ";

                Meta.Conn.DO_SYS_CMD(script, false);
                MessageBox.Show("Copia eseguita per il cassiere: " + R["description"].ToString());
            }
          

        }
	}
}
