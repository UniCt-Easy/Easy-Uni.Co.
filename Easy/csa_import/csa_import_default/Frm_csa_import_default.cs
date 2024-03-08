
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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
using System.Data.OleDb;
using System.IO;
using System.Text;
using System.Globalization;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;
using System.Diagnostics;
using movimentofunctions;
using ep_functions;
using System.Collections.Generic;
using System.Linq;
using emistiParser;

namespace csa_import_default {
	/// <summary>
	/// </summary>
	public class Frm_csa_import_default : MetaDataForm {
		private System.Windows.Forms.ImageList images;

		//private System.Data.DataTable mData = new System.Data.DataTable();
		public vistaForm DS;
		private Label label2;
		private TextBox textBox2;
		private System.ComponentModel.IContainer components;
		private MetaData Meta;
		private GroupBox grpImportazione;
		private TextBox txtEsercImport;
		private Label label3;
		private TextBox txtNumImport;
		private Label label4;
		private Label label1;
		private TextBox textBox1;
		private GroupBox grpExcel;
		private Button btnVerToExcel;
		private Button btnRiepToExcel;
		private GroupBox groupBox1;
		private TextBox txtInputFile;

		private Button btnInputRiepiloghi;

		//private string ConnectionString;
		private System.Windows.Forms.OpenFileDialog _openInputFileDlg;
		private System.Windows.Forms.SaveFileDialog _saveOutputFileDlg;
		private ProgressBar progressBarImport;
		private Button btnInputVersamenti;
		private Button btnDelete;
		private GroupBox groupBox2;
		private Button btnVersamenti;
		private Button btnLordi;
		private Label lblTask;
		private Label lblRigheVer;
		private Label lblRigheRiep;
		private GroupBox grpVerifiche;

		private DataAccess Conn;

		//private Hashtable RighePadriIncome;
		//private Hashtable RighePadriExpense;
		MyListener TS;

		/// <summary>
		/// Ouutput raggruppato della SP 
		/// </summary>
		private DataTable SP_Result;

		/// <summary>
		/// Output della SP NON RAGGRUPPATO
		/// </summary>
		private DataTable OutTable;

		private GroupBox groupBox3;
		private RadioButton rdbExpToListing;
		private RadioButton rdbExpToCsv;
		private RadioButton rdbExpToExcel;
		private Label lblIndividuazione;
		private Button btnElabora;
		public csa_import_default.dsFinancial dsFinancial;
		private DataGrid dgrVerificheFin;
		private Button btnVerificaIndividuazione;
		private TabControl tabControl1;
		private TabPage tabPage1;
		private TabPage tabPage2;
		private Button btnGeneraPreImpegni;
		private Button btnViewPreimpegni;
		private Button btnGeneraEpExp;
		private Button btnVisualizzaEpExp;
		private Button btnGeneraEP;
		private Button btnVisualizzaEP;
		private Label labEP;
		private GroupBox grpScrittureChiusuraDebito;
		private Label labEPDebit;
		private Button btnGeneDebit;
		private Button btnViewDebit;
		private GroupBox groupBox5;
		private DataGrid dgrVerificheEP;
		private Button btnVerificaIndividuazioneEP;
		System.EventHandler[] AllList = new System.EventHandler[100];
		System.EventHandler[] AllListEP = new System.EventHandler[100];
		private Button btnShowOutput;
		private GroupBox gboxBollettaNetti;
		private TextBox txtNumBollettaNetti;
		private TextBox txtEsercBollettaNetti;
		private Button btnBolletta;
		private GroupBox gBoxBollettaVersamenti;
		private TextBox txtNumBollettaVersamenti;
		private TextBox txtEsercBollettaVersamenti;
		private Button btnBollettaVersamenti;
		private Label label6;
		private Label label5;
		private Label label8;
		private Label label7;
		private TextBox txtErrori;
		private Button btnInputSospesi;
		private TabPage tabPage3;
		private GroupBox groupBox4;
		private DataGrid dgrSospesi;
		private ContextMenu CMenu;
		private MenuItem MenuEnterPwd;
		private Button btnAddBolletta;
		private Button btnDelBolletta;
		private Button btnEditBolletta;
		private ToolTip toolTipSospesi;
		private Button btnSimulaEPGenera;
		private Label label9;
		private TextBox txtRefExternalDoc;
		private Label label10;
		private TextBox textBox3;
        private Button btnImportEmisti;
        private GroupBox grpImportEmisti;
        private Label label12;
        private Label label11;
        private TextBox txtEmistiYimport;
        private TextBox txtEmistiNimport;
        private TextBox txtEmistiAdate;

        // Lookup di Csa_Agency
        Dictionary<object, bool> entiCsa = new Dictionary<object, bool>();

		public IOpenFileDialog openInputFileDlg;
		public ISaveFileDialog saveOutputFileDlg;

		public Frm_csa_import_default() {
			InitializeComponent();
			//RighePadriIncome = new Hashtable();
			//RighePadriExpense = new Hashtable();
			openInputFileDlg = createOpenFileDialog(_openInputFileDlg);
			saveOutputFileDlg = createSaveFileDialog(_saveOutputFileDlg);
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

		private CQueryHelper QHC;
		private QueryHelper QHS;
		private EP_Manager epm;
		private EP_Manager epm_debit;
		bool usePartition = false;
		public ISecurity security;

		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
			Conn = Meta.Conn;
			QHC = new CQueryHelper();
			QHS = Conn.GetQueryHelper();
			string filter = QHS.CmpEq("yimport", Meta.GetSys("esercizio"));
			GetData.SetStaticFilter(DS.csa_import, filter);
			security = this.getInstance<ISecurity>();

			DataAccess.SetTableForReading(DS.registry1, "registry");
			DataAccess.SetTableForReading(DS.registry_sospesi, "registry");
			DataAccess.SetTableForReading(DS.bill_netti, "bill");
			DataAccess.SetTableForReading(DS.bill_versamenti, "bill");
			DataAccess.SetTableForReading(DS.bill_ripartizione, "bill");
			DS.bill_netti.setStaticFilter(QHS.CmpEq("billkind", "D"));
			DS.bill_versamenti.setStaticFilter(QHS.CmpEq("billkind", "D"));
			DS.bill_ripartizione.setStaticFilter(QHS.AppAnd(QHS.CmpEq("billkind", "D"),
				QHS.CmpEq("ybill", Meta.GetSys("esercizio"))));

			//string filterbill_netti = QHS.AppAnd(QHS.CmpEq("bill", Meta.GetSys("esercizio")), QHS.CmpEq("billkind","D"));
			//string filterbill_versamenti = QHS.AppAnd(QHS.CmpEq("bill", Meta.GetSys("esercizio")), QHS.CmpEq("billkind", "D"));

			rdbExpToExcel.Checked = true;
			ClearDataSet.RemoveConstraints(dsFinancial);
			epm = new EP_Manager(Meta, btnGeneraEpExp, btnVisualizzaEpExp, btnGeneraPreImpegni, btnViewPreimpegni,
				btnGeneraEP, btnVisualizzaEP,
				labEP, null, "csa_import");
			epm_debit = new EP_Manager(Meta, null, null, null, null, btnGeneDebit, btnViewDebit, labEPDebit, null,
				"csa_import");
			epm_debit.tipoScrittura = "debito";
			InitializeAllList();
			InitializeAllListEP();
			if (TS == null) {
				TS = new MyListener();
				Debug.Listeners.Add(TS);
			}

			btnSimulaEPGenera.Visible = UsaBudget();

			btnInputSospesi.ContextMenu = CMenu;
			toolTipSospesi.SetToolTip(btnInputSospesi,
				"Il file deve contenere le intestazioni. Tasto destro per visualizzare il tracciato");

			int []fieldValue = new int[] { CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("uniconfig", null, "flag", null)) };
			BitArray flags = new BitArray(fieldValue);
			btnImportEmisti.Visible = flags[6];
			grpImportEmisti.Visible = flags[6];
		}

		private void InitializeAllList() {
			//1) Esercizio non valorizzato riepiloghi
			AllList[0] = this.btn01_Click;
			//2) Esercizio non valorizzato versamenti
			AllList[1] = this.btn02_Click;
			//3) Regola generale o specifica CSA non determinata riepiloghi
			AllList[2] = this.btn03_Click;
			//4) Regola generale o specifica CSA non determinata versamenti
			AllList[3] = this.btn04_Click;
			//5) Recupero, Ritenuta o Contributo senza imputazione
			AllList[4] = this.btn05_Click;
			//6) Versamenti con Ente o Anagrafica Ente non valorizzati
			AllList[5] = this.btn06_Click;
			// 7) Recupero Senza Capitolo di Entrata Lordi idfin_income o idfin_incomeclawback a seconda dei casi
			// Se recupero diretto, capitolo entrata interno idfin_incomeclawback OR
			// Se recupero su partita di giro, capitolo entrata della reversale idfin_income
			AllList[6] = this.btn07_Click;
			//8) Recupero su partita di giro : idfin_expense --> idfin_income e viceversa
			AllList[7] = this.btn08_Click;
			//9) Recupero diretto : idfin_expense  is null, capitolo spesa non valorizzato per lerighe negative
			AllList[8] = this.btn09_Click;
			//10) Recupero su partita di giro senza idfin_incomeclawback per movimento di entrata post- versamento 
			AllList[9] = this.btn10_Click;
			//11) Contributi senza Capitolo di Costo o di Spesa per il Versamento , controllare la coerenza con la sp
			AllList[10] = this.btn11_Click;
			//12)  Ritenuta o Contributo: idfin_expense --> idfin_income
			AllList[11] = this.btn12_Click;
			//13)  Ritenuta o Contributo: idfin_income --> idfin_expense
			AllList[12] = this.btn13_Click;
			//14)   Verifica ripartizione delle classificazioni dei contratti
			AllList[13] = this.btn14_Click;
			//15)   Verifica ripartizione delle classificazioni dei contributi
			AllList[14] = this.btn15_Click;
			//16)   Verifica upb non presente sulle righe di riepilogo
			AllList[15] = this.btn16_Click;
			//17)   Verifica upb non presente sulle righe di versamento per recuperi non figurativi
			AllList[16] = this.btn17_Click;
			//18)   Verifica upb non presente sulle righe di versamento per contributi non figurativi
			AllList[17] = this.btn18_Click;
			//19)  Verifica upb non presente sulle righe di versamento per RITENUTE
			AllList[18] = this.btn19_Click;
			//20) Cerca contributi con importo negativo
			AllList[19] = this.btn20_Click;
			// 21) Righe Versamenti Associate a Config. Contributi e non a Configurazione Incassi (Contributi o Recuperi Figurativi)
			AllList[20] = this.btn21_Click;
			// 22) Righe Versamenti Associate non configurate correttamente nè come Contributi, nè come Ritenute, nè Recuperi
			AllList[21] = this.btn22_Click;
			// 23) Recuperi negativi su partita di giro : idfin_cost per movimento di spesa  di ricavo
			AllList[22] = this.btn23_Click;
			// 24) Righe versamento con voce CSA ai fini del raggruppamento aventi configurazione non omogenea  
			AllList[23] = this.btn24_Click;
			// 25) Movimenti padre con disponibile insufficiente
			AllList[24] = this.btn25_Click;
			// 26) Upb Bilancio con disponibile insufficiente
			AllList[25] = this.btn26_Click;
			// 27) Voce di Bilancio e Movimento finanziario non determinati in righe riepiloghi
			AllList[26] = this.btn27_Click;
			// 28) Ente CSA associato ad anagrafiche non attive in righe versamenti
			AllList[27] = this.btn28_Click;
			// 29)  Ripartizione dei contratti in presenza di un movimento di spesa principale
			AllList[28] = this.btn29_Click;
			// 30)   Ripartizione dei contributi in presenza di un movimento di spesa 
			AllList[29] = this.btn30_Click;
			// 31)  Righe di riepilogo con ripartizione del costo del lordo in presenza di un movimento di spesa principale 
			AllList[30] = this.btn31_Click;
			// 32)  Righe di versamento Contributi con ripartizione del costo in presenza anche di un movimento di spesa 
			AllList[31] = this.btn32_Click;
			// 33)    Righe di riepilogo con ripartizione tra impegni di budget in presenza di un impegno di budget
			AllList[32] = this.btn33_Click;
			// 34)   Righe di versamento Contributi con ripartizione tra impegni di budget in presenza anche di un impegno di budget principale
			AllList[33] = this.btn34_Click;
			// 35)   Ripartizione dei contratti in impegni di budget  in presenza di un impegno di budget nella scheda principale
			AllList[34] = this.btn35_Click;
			// 36)   Ripartizione dei contributi in impegni di budget in presenza di un impegno di budget
			AllList[35] = this.btn36_Click;
			// 37)  Contributi su partita di giro senza Capitolo di Costo o Movimento di Spesa configurato
			AllList[36] = this.btn37_Click;

			///////////////////////////////////////////////////////////////////////////////////////////////

			//38)   Verifica ripartizione finanziaria dei contratti (riepiloghi)
			AllList[37] = this.btn38_Click;
			//39)   Verifica ripartizione finanziaria dei contributi (versamenti)
			AllList[38] = this.btn39_Click;
			//40)   Verifica ripartizione EP dei contratti
			AllList[39] = this.btn40_Click;
			//41)   Verifica ripartizione EP dei contributi
			AllList[40] = this.btn41_Click;
			//42)  Righe di riepilogo con ripartizione del costo del lordo in presenza di un movimento di spesa principale
			AllList[41] = this.btn42_Click;
			//43)  Righe di versamento Contributi con ripartizione del costo in presenza anche di un movimento di spesa
			AllList[42] = this.btn43_Click;
			//44)  Righe di riepilogo con ripartizione tra impegni di budget in presenza di un impegno di budget
			AllList[43] = this.btn44_Click;
			//45)  Righe di versamento Contributi con ripartizione tra impegni di budget in presenza anche di un impegno di budget principale
			AllList[44] = this.btn45_Click;
			//46)  Ritenute  con importo negativo senza  il Conto di Credito verso Ente
			AllList[45] = this.btn46_Click;
			//47)  Ripartizione finanziaria dei contratti (csa_contractexpense)  ' +
			//' senza una corrispondente ripartizione  EP (csa_contractepexp) con stesso upb e quota 
			AllList[46] = this.btn47_Click;
			//48)  Ripartizione finanziaria dei contributi (csa_contracttaxexpense)  senza una corrispondente ' +
			// 'ripartizione  EP (csa_contracttaxtepexp) con stesso upb e quota 
			AllList[47] = this.btn48_Click;
			//49 Esistono movimenti finanziari mal ripartiti su finanziamenti
			AllList[48] = btn49_Click;
			//50 Righe di riepilogo comn movimento di spesa senza imputazione nell''esercizio corrente
			AllList[49] = btn50_Click;
			//51 Righe di versamento con movimento di spesa senza imputazione nell''esercizio corrente
			AllList[50] = btn51_Click;
			//52 Contratti con movimento di spesa principale senza imputazione nell''esercizio corrente
			AllList[51] = btn52_Click;
			//53 Movimento di spesa principale impostato nei contributi contratti senza imputazione nell''esercizio corrente 
			AllList[52] = btn53_Click;
			//54 Movimento di spesa principale impostato nella ripartizione dei contributi senza imputazione nell''esercizio corrente
			AllList[53] = btn54_Click;
			//55 Movimento di spesa principale impostato nella ripartizione dei contratti senza imputazione nell''esercizio corrente
			AllList[54] = btn55_Click;
			//56 Righe di riepilogo con UPB incoerente tra impegno finanziario e impegno di budget
			AllList[55] = btn56_Click;
			//57 Righe di versamento con UPB incoerente tra impegno finanziario e impegno di budget
			AllList[56] = btn57_Click;
			//58 Ripartizione finanziaria dei contratti (csa_contractexpense)  
			//senza una corrispondente ripartizione  EP (csa_contractepexp) con stesso upb e quota
			AllList[57] = btn58_Click;
			//59 Ripartizione finanziaria dei contributi (csa_contracttaxexpense)  senza una corrispondente 
			//ripartizione  EP (csa_contracttaxtepexp) con stesso upb e quota
			AllList[58] = btn59_Click;
			//60) Righe di versamento non ripartite,  deve sempre essere presente almeno una riga
			// sia che si tratti di contributi, di recuperi o di ritenute
			AllList[59] = btn60_Click;
			//61) Righe di riepilogo non ripartite,deve sempre essere presente almeno una riga
			AllList[60] = btn61_Click;
			//62) Nell''importazione manca il sospeso uscita da collegare ai pagamenti netti per l''elaborazione dei lordi
			AllList[61] = btn62_Click;
			//63)  Sospeso uscita per elaborazione dei versamenti non valorizzato - esercizio corrente
			AllList[62] = btn63_Click;
			//64)Sospeso uscita per elaborazione dei versamenti di dicembre non valorizzato - esercizio successivo
			AllList[63] = btn64_Click;
			//65)CONFIGURAZIONE REGOLE SPECIFICHE E CONTRIBUTI: PARTIZIONE UNICA NON CREATA PER INCOERENZA NELLE RIPARTIZIONI ORIGINALI
			AllList[64] = this.btn65_Click;
			//66)RIEPILOGHI: PER INCOERENZA NELLE RIPARTIZIONI FINANZIARIA ED EP
			AllList[65] = this.btn66_Click;
			//67)VERSAMENTI: PER INCOERENZA NELLE RIPARTIZIONI FINANZIARIA ED EP
			AllList[66] = this.btn67_Click;
			//68) ANAGRAFICHE RIEPILOGHI PRIVE DI MODALITA' DI PAGAMENTO STANDARD
			// NON SERVE , IL NETTO A PAGARE DEVE ESSERE A REGOLARIZZAZIONE
			// AllList[67] = this.btn68_Click;
			//69) ANAGRAFICHE ENTI VERSAMENTO CSA PRIVE DI MODALITA' DI PAGAMENTO STANDARD
			AllList[68] = this.btn69_Click;
			//70) ANAGRAFICHE RIEPILOGHI CSA INCOERENTI CON QUELLE DEI MOVIMENTI FINANZIARI DELLA RIPARTIZIONE PER NUOVA GESTIONE
			AllList[69] = this.btn70_Click;
			//71)  Regole specifiche  ripartite con movimenti di spesa con anagrafica
			AllList[70] = this.btn71_Click;
			//72)  Contributi di Regole specifiche  ripartite con movimenti di spesa con anagrafica
			AllList[71] = this.btn72_Click;
			//73)  Movimenti spesa con netto negativo nella fase versamenti
			AllList[72] = this.btn73_Click;
			//74)     Ritenuta con capitolo  costo valorizzato
			AllList[73] = this.btn74_Click;
			//75) Ripartizione Ritenuta con capitolo  costo valorizzato
			AllList[74] = this.btn75_Click;
			//76) Contributi con importo negativo senza capitolo di entrata o classificazione Siope entrata configurati
			AllList[75] = this.btn76_Click;
			//77) Riepiloghi senza capitolo ,   
			AllList[76] = this.btn77_Click;
			//78) Anagrafiche enti di versamento non sono a regolarizzazione e non hanno il tipo trattamento spese nella modalità predefinita
			AllList[77] = this.btn78_Click;
			//79) Anagrafiche enti di versamento non sono a regolarizzazione e non hanno il tipo trattamento spese nella modalità specifica configurata per il CSA   
			AllList[78] = this.btn79_Click;

			//80) ( 12 siope ) Ritenute senza SIOPE Cap. Entrata
			AllList[79] = this.btn80_Click;
			//81 (13 siope )  Ritenute senza SIOPE Cap. Spesa
			AllList[80] = this.btn81_Click;
			//82) ( 7 SIOPE ) Recupero senza SIOPE di Entrata (Lordi)
			AllList[81] = this.btn82_Click;

			//83) ( 9 SIOPE ) Recupero senza SIOPE sul capitolo di spesa
			AllList[82] = this.btn83_Click;

			//84) ( 11 SIOPE ) Contributi senza SIOPE sul Capitolo di Costo
			AllList[83] = this.btn84_Click;

			//85) Riepiloghi con Anagrafica Ente non valorizzati
			AllList[84] = this.btn85_Click;

			//86) Anagrafica con modalità di pagamento predefinita non valorizzata
			AllList[85] = this.btn86_Click;

		}

		private void InitializeAllListEP() {
			//1) LORDI POSITIVI: Conto di costo (idacc_cost) non valorizzato riepiloghi positivi
			AllListEP[0] = this.btnEP0_Click;
			//2)  LORDI NEGATIVI: Conto di ricavo lordi (idacc_revenue_gross_csa) non valorizzato riepiloghi negativi (in config)
			AllListEP[1] = this.btnEP1_Click;
			//3) CONTRIBUTI con importo POSITIVO: Conto di costo non configurato per contributi positivi
			// --Costo a debito con idacc_cost ove COSTO = idacc_cost DEBITO = ISNULL(_debit, _expense)
			AllListEP[2] = this.btnEP2_Click;
			//4)  CONTRIBUTI CON IMPORTO POSITIVO: Conto di debito conto erario  e conto di debito verso erario entrambi non configurati per contributi positivi
			//--_debit per i contributi con transito dalle partite di giro
			//-- _expense per i contributi a liquidazione diretta
			AllListEP[3] = this.btnEP3_Click;
			//5)  VERSAMENTO RECUPERI: Viene generata una scrittura di COSTO   A  debito vs percipiente
			AllListEP[4] = this.btnEP4_Click;
			//6)  CONTRIBUTI NEGATIVI: credito vs erario A  RICAVO 
			AllListEP[5] = this.btnEP5_Click;
			//7)  RECUPERI POSITIVI: credito vs erario A  RICAVO 
			//--Versamento recuperi credito vs percipiente A RICAVO
			AllListEP[6] = this.btnEP6_Click;
			//8)  RITENUTE POSITIVE: credito vs percipiente       A debito vs erario  ("ente csa")      (diversi     A idacc_expense )
			AllListEP[7] = this.btnEP7_Click;
			//9) ) RITENUTE NEGATIVE   credito vs erario ("ente csa") A debito vs percipiente ("diversi")  (idacc_agency_credit  A   diversi) 
			AllListEP[8] = this.btnEP8_Click;
			//10)  CONTRIBUTI NEGATIVI   credito vs erario A  RICAVO 
			AllListEP[9] = this.btnEP9_Click;
			//11)  Conto di costo per il lordo (idacc_main) non valorizzato in righe Contratti CSA
			AllListEP[10] = this.btnEP10_Click;
			//12)  Conto di costo per contributi di contratto (idacc) non valorizzato in righe Contributi CSA - Regola generale
			AllListEP[11] = this.btnEP11_Click;
			//13)   Conto di costo per   il lordo (idacc_main) non valorizzato in righe di regole generali CSA
			AllListEP[12] = this.btnEP12_Click;
			//14)  Conto di costo per contributi di Regola generale CSA (idacc) non valorizzato in righe Contributi di Tipi Contratti CSA
			AllListEP[13] = this.btnEP13_Click;
			//15)  Ripartizione EP dei contratti (csa_contractexpense)  ' +
			//' senza una corrispondente ripartizione  finanziaria (csa_contractepexp) con stesso upb e quota 
			AllListEP[14] = this.btnEP14_Click;
			//16)  Ripartizione EP  dei contributi (csa_contracttaxexpense)  senza una corrispondente ' +
			// 'ripartizione  finanziaria (csa_contracttaxtepexp) con stesso upb e quota 
			AllListEP[15] = this.btnEP15_Click;
			//17) CONFIGURAZIONE CONTRIBUTI POSITIVI E NEGATIVI A LIQUIDAIZONE DIRETTA: Conto di debito verso ente o Conto EP di Credito Verso Ente o Conto di Ricavo non configurati nella scheda Voce CSA
			//_expense per i contributi a liquidazione diretta
			//_agency_credit(Conto EP di Credito Verso Ente(Contributi e Ritenute negativi))
			//_revenue(Conto EP di Ricavo(Contributi e Ritenute negativi))
			AllListEP[16] = this.btnEP16_Click;
			//18) CONFIGURAZIONE CONTRIBUTI POSITIVI E NEGATIVI SU PARTITA DI GIRO: Conto di debito verso ente o Conto EP di Credito Verso Ente o Conto di dEBITO c/ente non configurati nella scheda Voce CSA
			//_expense per i contributi a liquidazione diretta
			//_agency_credit(Conto EP di Credito Verso Ente(Contributi e Ritenute negativi))
			//_debit(Conto EP di Debito C/Ente
			AllListEP[17] = this.btnEP17_Click;
			//19)CONFIGURAZIONE REGOLE SPECIFICHE E CONTRIBUTI: PARTIZIONE UNICA NON CREATA PER INCOERENZA NELLE RIPARTIZIONI ORIGINALI
			AllListEP[18] = this.btn65_Click;
			//20)RIEPILOGHI: PER INCOERENZA NELLE RIPARTIZIONI FINANZIARIA ED EP
			AllListEP[19] = this.btn66_Click;
			//21)VERSAMENTI: PER INCOERENZA NELLE RIPARTIZIONI FINANZIARIA ED EP
			AllListEP[20] = this.btn67_Click;

			//22) Righe di versamento con preimpegno di budget avente conto incoerente con quello della ripartizione nell''esercizio corrente
			AllListEP[21] = this.btnEP21_Click;
			//23) Righe di versamento con preimpegno di budget avente upb incoerente con quello della ripartizione nell''esercizio corrente
			AllListEP[22] = this.btnEP22_Click;
			//24) Righe di riepilogo con preimpegno di budget avente conto incoerente con quello della ripartizione nell''esercizio corrente
			AllListEP[23] = this.btnEP23_Click;
			//25) Righe di riepilogo con preimpegno di budget avente upb incoerente con quello della ripartizione nell''esercizio corrente
			AllListEP[24] = this.btnEP24_Click;
			//26) Riepiloghi con Anagrafica   non valorizzata
			AllListEP[25] = this.btn85_Click;
			//27) Riepiloghi con Anagrafica  valorizzata ma causale di debito non valorizzata nella scheda Altri Dati - Mandati nominativi
			AllListEP[26] = this.btnEP25_Click;
		}


		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_csa_import_default));
			this.images = new System.Windows.Forms.ImageList(this.components);
			this.label2 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.grpImportazione = new System.Windows.Forms.GroupBox();
			this.txtEsercImport = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtNumImport = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.grpExcel = new System.Windows.Forms.GroupBox();
			this.btnVerToExcel = new System.Windows.Forms.Button();
			this.btnRiepToExcel = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnImportEmisti = new System.Windows.Forms.Button();
			this.lblIndividuazione = new System.Windows.Forms.Label();
			this.btnElabora = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnInputVersamenti = new System.Windows.Forms.Button();
			this.txtInputFile = new System.Windows.Forms.TextBox();
			this.btnInputRiepiloghi = new System.Windows.Forms.Button();
			this.btnInputSospesi = new System.Windows.Forms.Button();
			this.lblRigheVer = new System.Windows.Forms.Label();
			this.lblRigheRiep = new System.Windows.Forms.Label();
			this.progressBarImport = new System.Windows.Forms.ProgressBar();
			this._openInputFileDlg = new System.Windows.Forms.OpenFileDialog();
			this._saveOutputFileDlg = new System.Windows.Forms.SaveFileDialog();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btnVersamenti = new System.Windows.Forms.Button();
			this.btnLordi = new System.Windows.Forms.Button();
			this.lblTask = new System.Windows.Forms.Label();
			this.grpVerifiche = new System.Windows.Forms.GroupBox();
			this.dgrVerificheFin = new System.Windows.Forms.DataGrid();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.rdbExpToListing = new System.Windows.Forms.RadioButton();
			this.rdbExpToCsv = new System.Windows.Forms.RadioButton();
			this.rdbExpToExcel = new System.Windows.Forms.RadioButton();
			this.btnVerificaIndividuazione = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.label9 = new System.Windows.Forms.Label();
			this.txtRefExternalDoc = new System.Windows.Forms.TextBox();
			this.btnVerificaIndividuazioneEP = new System.Windows.Forms.Button();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.dgrVerificheEP = new System.Windows.Forms.DataGrid();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.btnSimulaEPGenera = new System.Windows.Forms.Button();
			this.txtErrori = new System.Windows.Forms.TextBox();
			this.grpScrittureChiusuraDebito = new System.Windows.Forms.GroupBox();
			this.labEPDebit = new System.Windows.Forms.Label();
			this.btnGeneDebit = new System.Windows.Forms.Button();
			this.btnViewDebit = new System.Windows.Forms.Button();
			this.btnGeneraPreImpegni = new System.Windows.Forms.Button();
			this.btnViewPreimpegni = new System.Windows.Forms.Button();
			this.btnGeneraEpExp = new System.Windows.Forms.Button();
			this.btnVisualizzaEpExp = new System.Windows.Forms.Button();
			this.btnGeneraEP = new System.Windows.Forms.Button();
			this.btnVisualizzaEP = new System.Windows.Forms.Button();
			this.labEP = new System.Windows.Forms.Label();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.btnAddBolletta = new System.Windows.Forms.Button();
			this.btnDelBolletta = new System.Windows.Forms.Button();
			this.btnEditBolletta = new System.Windows.Forms.Button();
			this.dgrSospesi = new System.Windows.Forms.DataGrid();
			this.btnShowOutput = new System.Windows.Forms.Button();
			this.gboxBollettaNetti = new System.Windows.Forms.GroupBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtNumBollettaNetti = new System.Windows.Forms.TextBox();
			this.txtEsercBollettaNetti = new System.Windows.Forms.TextBox();
			this.btnBolletta = new System.Windows.Forms.Button();
			this.gBoxBollettaVersamenti = new System.Windows.Forms.GroupBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.txtNumBollettaVersamenti = new System.Windows.Forms.TextBox();
			this.txtEsercBollettaVersamenti = new System.Windows.Forms.TextBox();
			this.btnBollettaVersamenti = new System.Windows.Forms.Button();
			this.CMenu = new System.Windows.Forms.ContextMenu();
			this.MenuEnterPwd = new System.Windows.Forms.MenuItem();
			this.dsFinancial = new csa_import_default.dsFinancial();
			this.toolTipSospesi = new System.Windows.Forms.ToolTip(this.components);
			this.label10 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.grpImportEmisti = new System.Windows.Forms.GroupBox();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.txtEmistiYimport = new System.Windows.Forms.TextBox();
			this.txtEmistiNimport = new System.Windows.Forms.TextBox();
			this.txtEmistiAdate = new System.Windows.Forms.TextBox();
			this.DS = new csa_import_default.vistaForm();
			this.grpImportazione.SuspendLayout();
			this.grpExcel.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.grpVerifiche.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrVerificheFin)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrVerificheEP)).BeginInit();
			this.tabPage2.SuspendLayout();
			this.grpScrittureChiusuraDebito.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrSospesi)).BeginInit();
			this.gboxBollettaNetti.SuspendLayout();
			this.gBoxBollettaVersamenti.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dsFinancial)).BeginInit();
			this.grpImportEmisti.SuspendLayout();
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
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(14, 53);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 16);
			this.label2.TabIndex = 0;
			this.label2.Text = "Descrizione:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(14, 71);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox2.Size = new System.Drawing.Size(344, 49);
			this.textBox2.TabIndex = 3;
			this.textBox2.Tag = "csa_import.description";
			// 
			// grpImportazione
			// 
			this.grpImportazione.Controls.Add(this.txtEsercImport);
			this.grpImportazione.Controls.Add(this.label3);
			this.grpImportazione.Controls.Add(this.txtNumImport);
			this.grpImportazione.Controls.Add(this.label4);
			this.grpImportazione.Location = new System.Drawing.Point(15, 6);
			this.grpImportazione.Name = "grpImportazione";
			this.grpImportazione.Size = new System.Drawing.Size(343, 45);
			this.grpImportazione.TabIndex = 1;
			this.grpImportazione.TabStop = false;
			this.grpImportazione.Text = "Importazione";
			// 
			// txtEsercImport
			// 
			this.txtEsercImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtEsercImport.Location = new System.Drawing.Point(74, 19);
			this.txtEsercImport.Name = "txtEsercImport";
			this.txtEsercImport.Size = new System.Drawing.Size(62, 20);
			this.txtEsercImport.TabIndex = 1;
			this.txtEsercImport.Tag = "csa_import.yimport.year";
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.Location = new System.Drawing.Point(18, 18);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(57, 20);
			this.label3.TabIndex = 0;
			this.label3.Tag = "";
			this.label3.Text = "Esercizio:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtNumImport
			// 
			this.txtNumImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtNumImport.Location = new System.Drawing.Point(245, 20);
			this.txtNumImport.Name = "txtNumImport";
			this.txtNumImport.Size = new System.Drawing.Size(80, 20);
			this.txtNumImport.TabIndex = 2;
			this.txtNumImport.Tag = "csa_import.nimport";
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.Location = new System.Drawing.Point(188, 19);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(54, 20);
			this.label4.TabIndex = 0;
			this.label4.Tag = "";
			this.label4.Text = "Numero:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(653, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(82, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Data Contabile:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(741, 9);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(100, 20);
			this.textBox1.TabIndex = 2;
			this.textBox1.Tag = "csa_import.adate";
			// 
			// grpExcel
			// 
			this.grpExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.grpExcel.Controls.Add(this.btnVerToExcel);
			this.grpExcel.Controls.Add(this.btnRiepToExcel);
			this.grpExcel.Location = new System.Drawing.Point(17, 400);
			this.grpExcel.Name = "grpExcel";
			this.grpExcel.Size = new System.Drawing.Size(193, 50);
			this.grpExcel.TabIndex = 8;
			this.grpExcel.TabStop = false;
			this.grpExcel.Text = "Esporta";
			// 
			// btnVerToExcel
			// 
			this.btnVerToExcel.Location = new System.Drawing.Point(99, 19);
			this.btnVerToExcel.Name = "btnVerToExcel";
			this.btnVerToExcel.Size = new System.Drawing.Size(86, 23);
			this.btnVerToExcel.TabIndex = 2;
			this.btnVerToExcel.Text = "Versamenti";
			this.btnVerToExcel.UseVisualStyleBackColor = true;
			this.btnVerToExcel.Click += new System.EventHandler(this.btnVerToExcel_Click);
			// 
			// btnRiepToExcel
			// 
			this.btnRiepToExcel.Location = new System.Drawing.Point(7, 19);
			this.btnRiepToExcel.Name = "btnRiepToExcel";
			this.btnRiepToExcel.Size = new System.Drawing.Size(86, 23);
			this.btnRiepToExcel.TabIndex = 1;
			this.btnRiepToExcel.Text = "Riepiloghi";
			this.btnRiepToExcel.UseVisualStyleBackColor = true;
			this.btnRiepToExcel.Click += new System.EventHandler(this.btnRiepToExcel_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnImportEmisti);
			this.groupBox1.Controls.Add(this.lblIndividuazione);
			this.groupBox1.Controls.Add(this.btnElabora);
			this.groupBox1.Controls.Add(this.btnDelete);
			this.groupBox1.Controls.Add(this.btnInputVersamenti);
			this.groupBox1.Controls.Add(this.txtInputFile);
			this.groupBox1.Controls.Add(this.btnInputRiepiloghi);
			this.groupBox1.Location = new System.Drawing.Point(13, 122);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(657, 96);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Input";
			// 
			// btnImportEmisti
			// 
			this.btnImportEmisti.Location = new System.Drawing.Point(349, 17);
			this.btnImportEmisti.Name = "btnImportEmisti";
			this.btnImportEmisti.Size = new System.Drawing.Size(163, 23);
			this.btnImportEmisti.TabIndex = 16;
			this.btnImportEmisti.Text = "Importa Dati da File Emisti";
			this.btnImportEmisti.UseVisualStyleBackColor = true;
			this.btnImportEmisti.Click += new System.EventHandler(this.btnImportEmisti_Click);
			// 
			// lblIndividuazione
			// 
			this.lblIndividuazione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblIndividuazione.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.lblIndividuazione.Location = new System.Drawing.Point(195, 66);
			this.lblIndividuazione.Name = "lblIndividuazione";
			this.lblIndividuazione.Size = new System.Drawing.Size(456, 23);
			this.lblIndividuazione.TabIndex = 14;
			this.lblIndividuazione.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnElabora
			// 
			this.btnElabora.Location = new System.Drawing.Point(9, 66);
			this.btnElabora.Name = "btnElabora";
			this.btnElabora.Size = new System.Drawing.Size(184, 23);
			this.btnElabora.TabIndex = 15;
			this.btnElabora.Text = "Elabora";
			this.btnElabora.UseVisualStyleBackColor = true;
			this.btnElabora.Click += new System.EventHandler(this.btnElabora_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(525, 17);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(127, 23);
			this.btnDelete.TabIndex = 3;
			this.btnDelete.Text = "Cancella Dati";
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnInputVersamenti
			// 
			this.btnInputVersamenti.Location = new System.Drawing.Point(180, 17);
			this.btnInputVersamenti.Name = "btnInputVersamenti";
			this.btnInputVersamenti.Size = new System.Drawing.Size(163, 23);
			this.btnInputVersamenti.TabIndex = 2;
			this.btnInputVersamenti.Text = "Importa Dati da File Versamenti";
			this.btnInputVersamenti.Click += new System.EventHandler(this.btnInputFile_Click);
			// 
			// txtInputFile
			// 
			this.txtInputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtInputFile.Location = new System.Drawing.Point(11, 43);
			this.txtInputFile.Name = "txtInputFile";
			this.txtInputFile.ReadOnly = true;
			this.txtInputFile.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
			this.txtInputFile.Size = new System.Drawing.Size(641, 20);
			this.txtInputFile.TabIndex = 0;
			// 
			// btnInputRiepiloghi
			// 
			this.btnInputRiepiloghi.Location = new System.Drawing.Point(11, 17);
			this.btnInputRiepiloghi.Name = "btnInputRiepiloghi";
			this.btnInputRiepiloghi.Size = new System.Drawing.Size(163, 23);
			this.btnInputRiepiloghi.TabIndex = 1;
			this.btnInputRiepiloghi.Text = "Importa Dati da File Riepiloghi";
			this.btnInputRiepiloghi.Click += new System.EventHandler(this.btnInputFile_Click);
			// 
			// btnInputSospesi
			// 
			this.btnInputSospesi.Location = new System.Drawing.Point(87, 17);
			this.btnInputSospesi.Name = "btnInputSospesi";
			this.btnInputSospesi.Size = new System.Drawing.Size(167, 23);
			this.btnInputSospesi.TabIndex = 21;
			this.btnInputSospesi.Text = "Importa Dati da File Sospesi";
			this.btnInputSospesi.Click += new System.EventHandler(this.btnInputFile_Click);
			// 
			// lblRigheVer
			// 
			this.lblRigheVer.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.lblRigheVer.Location = new System.Drawing.Point(364, 46);
			this.lblRigheVer.Name = "lblRigheVer";
			this.lblRigheVer.Size = new System.Drawing.Size(214, 21);
			this.lblRigheVer.TabIndex = 5;
			this.lblRigheVer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblRigheRiep
			// 
			this.lblRigheRiep.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblRigheRiep.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.lblRigheRiep.Location = new System.Drawing.Point(597, 46);
			this.lblRigheRiep.Name = "lblRigheRiep";
			this.lblRigheRiep.Size = new System.Drawing.Size(289, 21);
			this.lblRigheRiep.TabIndex = 4;
			this.lblRigheRiep.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// progressBarImport
			// 
			this.progressBarImport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.progressBarImport.Location = new System.Drawing.Point(10, 720);
			this.progressBarImport.Name = "progressBarImport";
			this.progressBarImport.Size = new System.Drawing.Size(993, 22);
			this.progressBarImport.TabIndex = 10;
			this.progressBarImport.Visible = false;
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.groupBox2.Controls.Add(this.btnVersamenti);
			this.groupBox2.Controls.Add(this.btnLordi);
			this.groupBox2.Location = new System.Drawing.Point(226, 400);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(188, 50);
			this.groupBox2.TabIndex = 9;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Crea";
			// 
			// btnVersamenti
			// 
			this.btnVersamenti.Location = new System.Drawing.Point(96, 19);
			this.btnVersamenti.Name = "btnVersamenti";
			this.btnVersamenti.Size = new System.Drawing.Size(86, 23);
			this.btnVersamenti.TabIndex = 2;
			this.btnVersamenti.Text = "Versamenti";
			this.btnVersamenti.UseVisualStyleBackColor = true;
			this.btnVersamenti.Click += new System.EventHandler(this.btnVersamenti_Click);
			// 
			// btnLordi
			// 
			this.btnLordi.Location = new System.Drawing.Point(5, 19);
			this.btnLordi.Name = "btnLordi";
			this.btnLordi.Size = new System.Drawing.Size(86, 23);
			this.btnLordi.TabIndex = 1;
			this.btnLordi.Text = "Lordi";
			this.btnLordi.UseVisualStyleBackColor = true;
			this.btnLordi.Click += new System.EventHandler(this.btnLordi_Click);
			// 
			// lblTask
			// 
			this.lblTask.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblTask.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.lblTask.Location = new System.Drawing.Point(364, 103);
			this.lblTask.Name = "lblTask";
			this.lblTask.Size = new System.Drawing.Size(296, 14);
			this.lblTask.TabIndex = 9;
			// 
			// grpVerifiche
			// 
			this.grpVerifiche.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpVerifiche.Controls.Add(this.dgrVerificheFin);
			this.grpVerifiche.Location = new System.Drawing.Point(6, 8);
			this.grpVerifiche.Name = "grpVerifiche";
			this.grpVerifiche.Size = new System.Drawing.Size(798, 184);
			this.grpVerifiche.TabIndex = 7;
			this.grpVerifiche.TabStop = false;
			this.grpVerifiche.Text = "Verifiche";
			// 
			// dgrVerificheFin
			// 
			this.dgrVerificheFin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgrVerificheFin.DataMember = "";
			this.dgrVerificheFin.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrVerificheFin.Location = new System.Drawing.Point(10, 19);
			this.dgrVerificheFin.Name = "dgrVerificheFin";
			this.dgrVerificheFin.Size = new System.Drawing.Size(780, 154);
			this.dgrVerificheFin.TabIndex = 4;
			this.dgrVerificheFin.DoubleClick += new System.EventHandler(this.dgrVerifiche_DoubleClick);
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.Controls.Add(this.rdbExpToListing);
			this.groupBox3.Controls.Add(this.rdbExpToCsv);
			this.groupBox3.Controls.Add(this.rdbExpToExcel);
			this.groupBox3.Location = new System.Drawing.Point(833, 139);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(135, 107);
			this.groupBox3.TabIndex = 11;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Esporta dati ";
			// 
			// rdbExpToListing
			// 
			this.rdbExpToListing.AutoSize = true;
			this.rdbExpToListing.Location = new System.Drawing.Point(18, 79);
			this.rdbExpToListing.Name = "rdbExpToListing";
			this.rdbExpToListing.Size = new System.Drawing.Size(88, 17);
			this.rdbExpToListing.TabIndex = 3;
			this.rdbExpToListing.TabStop = true;
			this.rdbExpToListing.Text = "Come Elenco";
			this.rdbExpToListing.UseVisualStyleBackColor = true;
			// 
			// rdbExpToCsv
			// 
			this.rdbExpToCsv.AutoSize = true;
			this.rdbExpToCsv.Location = new System.Drawing.Point(18, 48);
			this.rdbExpToCsv.Name = "rdbExpToCsv";
			this.rdbExpToCsv.Size = new System.Drawing.Size(96, 17);
			this.rdbExpToCsv.TabIndex = 2;
			this.rdbExpToCsv.TabStop = true;
			this.rdbExpToCsv.Text = "In formato CSV";
			this.rdbExpToCsv.UseVisualStyleBackColor = true;
			// 
			// rdbExpToExcel
			// 
			this.rdbExpToExcel.AutoSize = true;
			this.rdbExpToExcel.Location = new System.Drawing.Point(18, 19);
			this.rdbExpToExcel.Name = "rdbExpToExcel";
			this.rdbExpToExcel.Size = new System.Drawing.Size(63, 17);
			this.rdbExpToExcel.TabIndex = 1;
			this.rdbExpToExcel.TabStop = true;
			this.rdbExpToExcel.Text = "In Excel";
			this.rdbExpToExcel.UseVisualStyleBackColor = true;
			// 
			// btnVerificaIndividuazione
			// 
			this.btnVerificaIndividuazione.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnVerificaIndividuazione.Location = new System.Drawing.Point(833, 44);
			this.btnVerificaIndividuazione.Name = "btnVerificaIndividuazione";
			this.btnVerificaIndividuazione.Size = new System.Drawing.Size(137, 23);
			this.btnVerificaIndividuazione.TabIndex = 16;
			this.btnVerificaIndividuazione.Text = "Verifica";
			this.btnVerificaIndividuazione.UseVisualStyleBackColor = true;
			this.btnVerificaIndividuazione.Click += new System.EventHandler(this.btnVerificaIndividuazione_Click);
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Location = new System.Drawing.Point(12, 224);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(996, 490);
			this.tabControl1.TabIndex = 17;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.label9);
			this.tabPage1.Controls.Add(this.txtRefExternalDoc);
			this.tabPage1.Controls.Add(this.btnVerificaIndividuazioneEP);
			this.tabPage1.Controls.Add(this.groupBox5);
			this.tabPage1.Controls.Add(this.grpExcel);
			this.tabPage1.Controls.Add(this.grpVerifiche);
			this.tabPage1.Controls.Add(this.groupBox2);
			this.tabPage1.Controls.Add(this.btnVerificaIndividuazione);
			this.tabPage1.Controls.Add(this.groupBox3);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(988, 464);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Tag = "csa_import.refexternaldoc";
			this.tabPage1.Text = "Principale";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// label9
			// 
			this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label9.Location = new System.Drawing.Point(460, 390);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(336, 16);
			this.label9.TabIndex = 19;
			this.label9.Text = "Rif. doc esterno per Fase Lordi:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtRefExternalDoc
			// 
			this.txtRefExternalDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.txtRefExternalDoc.Location = new System.Drawing.Point(463, 409);
			this.txtRefExternalDoc.Multiline = true;
			this.txtRefExternalDoc.Name = "txtRefExternalDoc";
			this.txtRefExternalDoc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtRefExternalDoc.Size = new System.Drawing.Size(344, 41);
			this.txtRefExternalDoc.TabIndex = 20;
			this.txtRefExternalDoc.Tag = "csa_import.refexternaldoc";
			// 
			// btnVerificaIndividuazioneEP
			// 
			this.btnVerificaIndividuazioneEP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnVerificaIndividuazioneEP.Location = new System.Drawing.Point(833, 323);
			this.btnVerificaIndividuazioneEP.Name = "btnVerificaIndividuazioneEP";
			this.btnVerificaIndividuazioneEP.Size = new System.Drawing.Size(137, 23);
			this.btnVerificaIndividuazioneEP.TabIndex = 18;
			this.btnVerificaIndividuazioneEP.Text = "Verifica EP";
			this.btnVerificaIndividuazioneEP.UseVisualStyleBackColor = true;
			this.btnVerificaIndividuazioneEP.Click += new System.EventHandler(this.btnVerificaIndividuazione_Click);
			// 
			// groupBox5
			// 
			this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox5.Controls.Add(this.dgrVerificheEP);
			this.groupBox5.Location = new System.Drawing.Point(6, 198);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(798, 190);
			this.groupBox5.TabIndex = 17;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Verifiche EP";
			// 
			// dgrVerificheEP
			// 
			this.dgrVerificheEP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgrVerificheEP.DataMember = "";
			this.dgrVerificheEP.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrVerificheEP.Location = new System.Drawing.Point(10, 19);
			this.dgrVerificheEP.Name = "dgrVerificheEP";
			this.dgrVerificheEP.Size = new System.Drawing.Size(780, 165);
			this.dgrVerificheEP.TabIndex = 4;
			this.dgrVerificheEP.DoubleClick += new System.EventHandler(this.dgrVerifiche_DoubleClick);
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.btnSimulaEPGenera);
			this.tabPage2.Controls.Add(this.txtErrori);
			this.tabPage2.Controls.Add(this.grpScrittureChiusuraDebito);
			this.tabPage2.Controls.Add(this.btnGeneraPreImpegni);
			this.tabPage2.Controls.Add(this.btnViewPreimpegni);
			this.tabPage2.Controls.Add(this.btnGeneraEpExp);
			this.tabPage2.Controls.Add(this.btnVisualizzaEpExp);
			this.tabPage2.Controls.Add(this.btnGeneraEP);
			this.tabPage2.Controls.Add(this.btnVisualizzaEP);
			this.tabPage2.Controls.Add(this.labEP);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(988, 464);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "EP";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// btnSimulaEPGenera
			// 
			this.btnSimulaEPGenera.Location = new System.Drawing.Point(674, 78);
			this.btnSimulaEPGenera.Name = "btnSimulaEPGenera";
			this.btnSimulaEPGenera.Size = new System.Drawing.Size(224, 23);
			this.btnSimulaEPGenera.TabIndex = 27;
			this.btnSimulaEPGenera.Text = "Simula Generazione Movimenti di Budget";
			this.btnSimulaEPGenera.Click += new System.EventHandler(this.btnSimulaEPGenera_Click);
			// 
			// txtErrori
			// 
			this.txtErrori.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtErrori.Location = new System.Drawing.Point(16, 282);
			this.txtErrori.MaxLength = 900000;
			this.txtErrori.Multiline = true;
			this.txtErrori.Name = "txtErrori";
			this.txtErrori.ReadOnly = true;
			this.txtErrori.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtErrori.Size = new System.Drawing.Size(966, 166);
			this.txtErrori.TabIndex = 26;
			// 
			// grpScrittureChiusuraDebito
			// 
			this.grpScrittureChiusuraDebito.Controls.Add(this.labEPDebit);
			this.grpScrittureChiusuraDebito.Controls.Add(this.btnGeneDebit);
			this.grpScrittureChiusuraDebito.Controls.Add(this.btnViewDebit);
			this.grpScrittureChiusuraDebito.Location = new System.Drawing.Point(16, 191);
			this.grpScrittureChiusuraDebito.Name = "grpScrittureChiusuraDebito";
			this.grpScrittureChiusuraDebito.Size = new System.Drawing.Size(663, 85);
			this.grpScrittureChiusuraDebito.TabIndex = 25;
			this.grpScrittureChiusuraDebito.TabStop = false;
			this.grpScrittureChiusuraDebito.Text = "Scritture sulla chiusura dei debiti e crediti";
			// 
			// labEPDebit
			// 
			this.labEPDebit.Location = new System.Drawing.Point(10, 24);
			this.labEPDebit.Name = "labEPDebit";
			this.labEPDebit.Size = new System.Drawing.Size(352, 16);
			this.labEPDebit.TabIndex = 23;
			this.labEPDebit.Text = "Le scritture in partita doppia sono state generate.";
			// 
			// btnGeneDebit
			// 
			this.btnGeneDebit.Location = new System.Drawing.Point(389, 53);
			this.btnGeneDebit.Name = "btnGeneDebit";
			this.btnGeneDebit.Size = new System.Drawing.Size(224, 23);
			this.btnGeneDebit.TabIndex = 22;
			this.btnGeneDebit.Text = "Genera le scritture in partita doppia.";
			// 
			// btnViewDebit
			// 
			this.btnViewDebit.Location = new System.Drawing.Point(389, 17);
			this.btnViewDebit.Name = "btnViewDebit";
			this.btnViewDebit.Size = new System.Drawing.Size(224, 23);
			this.btnViewDebit.TabIndex = 21;
			this.btnViewDebit.Text = "Visualizza le scritture in partita doppia";
			// 
			// btnGeneraPreImpegni
			// 
			this.btnGeneraPreImpegni.Location = new System.Drawing.Point(96, 78);
			this.btnGeneraPreImpegni.Name = "btnGeneraPreImpegni";
			this.btnGeneraPreImpegni.Size = new System.Drawing.Size(282, 23);
			this.btnGeneraPreImpegni.TabIndex = 24;
			this.btnGeneraPreImpegni.Text = "Genera preimpegni di Budget";
			// 
			// btnViewPreimpegni
			// 
			this.btnViewPreimpegni.Location = new System.Drawing.Point(96, 110);
			this.btnViewPreimpegni.Name = "btnViewPreimpegni";
			this.btnViewPreimpegni.Size = new System.Drawing.Size(282, 23);
			this.btnViewPreimpegni.TabIndex = 23;
			this.btnViewPreimpegni.Text = "Visualizza preimpegni di Budget";
			// 
			// btnGeneraEpExp
			// 
			this.btnGeneraEpExp.Location = new System.Drawing.Point(405, 78);
			this.btnGeneraEpExp.Name = "btnGeneraEpExp";
			this.btnGeneraEpExp.Size = new System.Drawing.Size(224, 23);
			this.btnGeneraEpExp.TabIndex = 22;
			this.btnGeneraEpExp.Text = "Genera Impegni di Budget";
			// 
			// btnVisualizzaEpExp
			// 
			this.btnVisualizzaEpExp.Location = new System.Drawing.Point(405, 110);
			this.btnVisualizzaEpExp.Name = "btnVisualizzaEpExp";
			this.btnVisualizzaEpExp.Size = new System.Drawing.Size(224, 23);
			this.btnVisualizzaEpExp.TabIndex = 21;
			this.btnVisualizzaEpExp.Text = "Visualizza Impegni di Budget";
			// 
			// btnGeneraEP
			// 
			this.btnGeneraEP.Location = new System.Drawing.Point(405, 39);
			this.btnGeneraEP.Name = "btnGeneraEP";
			this.btnGeneraEP.Size = new System.Drawing.Size(224, 23);
			this.btnGeneraEP.TabIndex = 20;
			this.btnGeneraEP.Text = "Genera le scritture in partita doppia.";
			// 
			// btnVisualizzaEP
			// 
			this.btnVisualizzaEP.Location = new System.Drawing.Point(405, 7);
			this.btnVisualizzaEP.Name = "btnVisualizzaEP";
			this.btnVisualizzaEP.Size = new System.Drawing.Size(224, 23);
			this.btnVisualizzaEP.TabIndex = 19;
			this.btnVisualizzaEP.Text = "Visualizza le scritture in partita doppia";
			// 
			// labEP
			// 
			this.labEP.Location = new System.Drawing.Point(13, 15);
			this.labEP.Name = "labEP";
			this.labEP.Size = new System.Drawing.Size(352, 16);
			this.labEP.TabIndex = 18;
			this.labEP.Text = "Le scritture in partita doppia sono state generate.";
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.groupBox4);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(988, 464);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Sospesi";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// groupBox4
			// 
			this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox4.Controls.Add(this.btnAddBolletta);
			this.groupBox4.Controls.Add(this.btnDelBolletta);
			this.groupBox4.Controls.Add(this.btnEditBolletta);
			this.groupBox4.Controls.Add(this.btnInputSospesi);
			this.groupBox4.Controls.Add(this.dgrSospesi);
			this.groupBox4.Location = new System.Drawing.Point(8, 6);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(968, 299);
			this.groupBox4.TabIndex = 8;
			this.groupBox4.TabStop = false;
			// 
			// btnAddBolletta
			// 
			this.btnAddBolletta.Location = new System.Drawing.Point(6, 47);
			this.btnAddBolletta.Name = "btnAddBolletta";
			this.btnAddBolletta.Size = new System.Drawing.Size(75, 23);
			this.btnAddBolletta.TabIndex = 22;
			this.btnAddBolletta.TabStop = false;
			this.btnAddBolletta.Tag = "insert.detail";
			this.btnAddBolletta.Text = "Inserisci...";
			// 
			// btnDelBolletta
			// 
			this.btnDelBolletta.Location = new System.Drawing.Point(6, 105);
			this.btnDelBolletta.Name = "btnDelBolletta";
			this.btnDelBolletta.Size = new System.Drawing.Size(75, 23);
			this.btnDelBolletta.TabIndex = 24;
			this.btnDelBolletta.TabStop = false;
			this.btnDelBolletta.Tag = "delete";
			this.btnDelBolletta.Text = "Elimina";
			// 
			// btnEditBolletta
			// 
			this.btnEditBolletta.Location = new System.Drawing.Point(6, 76);
			this.btnEditBolletta.Name = "btnEditBolletta";
			this.btnEditBolletta.Size = new System.Drawing.Size(75, 23);
			this.btnEditBolletta.TabIndex = 23;
			this.btnEditBolletta.TabStop = false;
			this.btnEditBolletta.Tag = "edit.detail";
			this.btnEditBolletta.Text = "Modifica...";
			// 
			// dgrSospesi
			// 
			this.dgrSospesi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgrSospesi.DataMember = "";
			this.dgrSospesi.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrSospesi.Location = new System.Drawing.Point(87, 47);
			this.dgrSospesi.Name = "dgrSospesi";
			this.dgrSospesi.Size = new System.Drawing.Size(869, 235);
			this.dgrSospesi.TabIndex = 4;
			this.dgrSospesi.Tag = "csa_bill.lista.detail";
			// 
			// btnShowOutput
			// 
			this.btnShowOutput.Location = new System.Drawing.Point(884, 7);
			this.btnShowOutput.Name = "btnShowOutput";
			this.btnShowOutput.Size = new System.Drawing.Size(75, 23);
			this.btnShowOutput.TabIndex = 18;
			this.btnShowOutput.Text = "Show Ouput";
			this.btnShowOutput.UseVisualStyleBackColor = true;
			this.btnShowOutput.Visible = false;
			this.btnShowOutput.Click += new System.EventHandler(this.btnShowOutput_Click);
			// 
			// gboxBollettaNetti
			// 
			this.gboxBollettaNetti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxBollettaNetti.Controls.Add(this.label6);
			this.gboxBollettaNetti.Controls.Add(this.label5);
			this.gboxBollettaNetti.Controls.Add(this.txtNumBollettaNetti);
			this.gboxBollettaNetti.Controls.Add(this.txtEsercBollettaNetti);
			this.gboxBollettaNetti.Controls.Add(this.btnBolletta);
			this.gboxBollettaNetti.Location = new System.Drawing.Point(676, 85);
			this.gboxBollettaNetti.Name = "gboxBollettaNetti";
			this.gboxBollettaNetti.Size = new System.Drawing.Size(327, 64);
			this.gboxBollettaNetti.TabIndex = 19;
			this.gboxBollettaNetti.TabStop = false;
			this.gboxBollettaNetti.Tag = "AutoChoose.txtNumBollettaNetti.spesa.(active=\'S\')";
			this.gboxBollettaNetti.Text = "Netti";
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label6.Location = new System.Drawing.Point(207, 13);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(54, 20);
			this.label6.TabIndex = 4;
			this.label6.Tag = "";
			this.label6.Text = "Numero:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.Location = new System.Drawing.Point(108, 14);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(57, 20);
			this.label5.TabIndex = 3;
			this.label5.Tag = "";
			this.label5.Text = "Esercizio:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtNumBollettaNetti
			// 
			this.txtNumBollettaNetti.Location = new System.Drawing.Point(217, 36);
			this.txtNumBollettaNetti.Name = "txtNumBollettaNetti";
			this.txtNumBollettaNetti.Size = new System.Drawing.Size(100, 20);
			this.txtNumBollettaNetti.TabIndex = 2;
			this.txtNumBollettaNetti.Tag = "bill_netti.nbill?csa_import.nbill_netti";
			// 
			// txtEsercBollettaNetti
			// 
			this.txtEsercBollettaNetti.Location = new System.Drawing.Point(111, 36);
			this.txtEsercBollettaNetti.Name = "txtEsercBollettaNetti";
			this.txtEsercBollettaNetti.Size = new System.Drawing.Size(100, 20);
			this.txtEsercBollettaNetti.TabIndex = 1;
			this.txtEsercBollettaNetti.Tag = "bill_netti.ybill.year";
			// 
			// btnBolletta
			// 
			this.btnBolletta.Location = new System.Drawing.Point(17, 35);
			this.btnBolletta.Name = "btnBolletta";
			this.btnBolletta.Size = new System.Drawing.Size(88, 23);
			this.btnBolletta.TabIndex = 0;
			this.btnBolletta.TabStop = false;
			this.btnBolletta.Tag = "";
			this.btnBolletta.Text = "N. sospeso";
			this.btnBolletta.Click += new System.EventHandler(this.btnBolletta_Click);
			// 
			// gBoxBollettaVersamenti
			// 
			this.gBoxBollettaVersamenti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gBoxBollettaVersamenti.Controls.Add(this.label8);
			this.gBoxBollettaVersamenti.Controls.Add(this.label7);
			this.gBoxBollettaVersamenti.Controls.Add(this.txtNumBollettaVersamenti);
			this.gBoxBollettaVersamenti.Controls.Add(this.txtEsercBollettaVersamenti);
			this.gBoxBollettaVersamenti.Controls.Add(this.btnBollettaVersamenti);
			this.gBoxBollettaVersamenti.Location = new System.Drawing.Point(676, 153);
			this.gBoxBollettaVersamenti.Name = "gBoxBollettaVersamenti";
			this.gBoxBollettaVersamenti.Size = new System.Drawing.Size(327, 65);
			this.gBoxBollettaVersamenti.TabIndex = 20;
			this.gBoxBollettaVersamenti.TabStop = false;
			this.gBoxBollettaVersamenti.Tag = "AutoChoose.txtNumBollettaVersamenti.spesa.(active=\'S\')";
			this.gBoxBollettaVersamenti.Text = "Versamenti";
			// 
			// label8
			// 
			this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label8.Location = new System.Drawing.Point(216, 13);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(54, 20);
			this.label8.TabIndex = 4;
			this.label8.Tag = "";
			this.label8.Text = "Numero:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label7
			// 
			this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label7.Location = new System.Drawing.Point(107, 12);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(57, 20);
			this.label7.TabIndex = 3;
			this.label7.Tag = "";
			this.label7.Text = "Esercizio:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtNumBollettaVersamenti
			// 
			this.txtNumBollettaVersamenti.Location = new System.Drawing.Point(216, 35);
			this.txtNumBollettaVersamenti.Name = "txtNumBollettaVersamenti";
			this.txtNumBollettaVersamenti.Size = new System.Drawing.Size(100, 20);
			this.txtNumBollettaVersamenti.TabIndex = 2;
			this.txtNumBollettaVersamenti.Tag = "bill_versamenti.nbill?csa_import.nbill_versamenti";
			// 
			// txtEsercBollettaVersamenti
			// 
			this.txtEsercBollettaVersamenti.Location = new System.Drawing.Point(110, 35);
			this.txtEsercBollettaVersamenti.Name = "txtEsercBollettaVersamenti";
			this.txtEsercBollettaVersamenti.Size = new System.Drawing.Size(100, 20);
			this.txtEsercBollettaVersamenti.TabIndex = 1;
			this.txtEsercBollettaVersamenti.Tag = "bill_versamenti.ybill.ayear";
			// 
			// btnBollettaVersamenti
			// 
			this.btnBollettaVersamenti.Location = new System.Drawing.Point(14, 32);
			this.btnBollettaVersamenti.Name = "btnBollettaVersamenti";
			this.btnBollettaVersamenti.Size = new System.Drawing.Size(88, 23);
			this.btnBollettaVersamenti.TabIndex = 0;
			this.btnBollettaVersamenti.TabStop = false;
			this.btnBollettaVersamenti.Tag = "";
			this.btnBollettaVersamenti.Text = "N. sospeso";
			this.btnBollettaVersamenti.Click += new System.EventHandler(this.btnBollettaVersamenti_Click);
			// 
			// CMenu
			// 
			this.CMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuEnterPwd});
			// 
			// MenuEnterPwd
			// 
			this.MenuEnterPwd.Index = 0;
			this.MenuEnterPwd.Text = "Visualizza tracciato";
			this.MenuEnterPwd.Click += new System.EventHandler(this.MenuEnterPwd_Click);
			// 
			// dsFinancial
			// 
			this.dsFinancial.DataSetName = "dsFinancial";
			this.dsFinancial.EnforceConstraints = false;
			this.dsFinancial.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(383, 9);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(140, 23);
			this.label10.TabIndex = 21;
			this.label10.Text = "Data Competenza Stipendi:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(524, 9);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(100, 20);
			this.textBox3.TabIndex = 22;
			this.textBox3.Tag = "csa_import.referencedate";
			// 
			// grpImportEmisti
			// 
			this.grpImportEmisti.Controls.Add(this.label12);
			this.grpImportEmisti.Controls.Add(this.label11);
			this.grpImportEmisti.Controls.Add(this.txtEmistiYimport);
			this.grpImportEmisti.Controls.Add(this.txtEmistiNimport);
			this.grpImportEmisti.Controls.Add(this.txtEmistiAdate);
			this.grpImportEmisti.Location = new System.Drawing.Point(364, 65);
			this.grpImportEmisti.Name = "grpImportEmisti";
			this.grpImportEmisti.Size = new System.Drawing.Size(298, 55);
			this.grpImportEmisti.TabIndex = 23;
			this.grpImportEmisti.TabStop = false;
			this.grpImportEmisti.Text = "Emisti";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(53, 23);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(12, 13);
			this.label12.TabIndex = 4;
			this.label12.Text = "/";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(157, 23);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(28, 13);
			this.label11.TabIndex = 3;
			this.label11.Text = "data";
			// 
			// txtEmistiYimport
			// 
			this.txtEmistiYimport.Location = new System.Drawing.Point(71, 20);
			this.txtEmistiYimport.Name = "txtEmistiYimport";
			this.txtEmistiYimport.Size = new System.Drawing.Size(46, 20);
			this.txtEmistiYimport.TabIndex = 2;
			this.txtEmistiYimport.Tag = "emisti_import.yimport";
			// 
			// txtEmistiNimport
			// 
			this.txtEmistiNimport.Location = new System.Drawing.Point(11, 20);
			this.txtEmistiNimport.Name = "txtEmistiNimport";
			this.txtEmistiNimport.Size = new System.Drawing.Size(36, 20);
			this.txtEmistiNimport.TabIndex = 1;
			this.txtEmistiNimport.Tag = "emisti_import.nimport";
			// 
			// txtEmistiAdate
			// 
			this.txtEmistiAdate.Location = new System.Drawing.Point(192, 20);
			this.txtEmistiAdate.Name = "txtEmistiAdate";
			this.txtEmistiAdate.Size = new System.Drawing.Size(100, 20);
			this.txtEmistiAdate.TabIndex = 0;
			this.txtEmistiAdate.Tag = "emisti_import.adate";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// Frm_csa_import_default
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(1015, 754);
			this.Controls.Add(this.grpImportEmisti);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.gBoxBollettaVersamenti);
			this.Controls.Add(this.gboxBollettaNetti);
			this.Controls.Add(this.btnShowOutput);
			this.Controls.Add(this.lblTask);
			this.Controls.Add(this.lblRigheVer);
			this.Controls.Add(this.lblRigheRiep);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.progressBarImport);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.grpImportazione);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.tabControl1);
			this.Name = "Frm_csa_import_default";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.grpImportazione.ResumeLayout(false);
			this.grpImportazione.PerformLayout();
			this.grpExcel.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.grpVerifiche.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgrVerificheFin)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgrVerificheEP)).EndInit();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.grpScrittureChiusuraDebito.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgrSospesi)).EndInit();
			this.gboxBollettaNetti.ResumeLayout(false);
			this.gboxBollettaNetti.PerformLayout();
			this.gBoxBollettaVersamenti.ResumeLayout(false);
			this.gBoxBollettaVersamenti.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dsFinancial)).EndInit();
			this.grpImportEmisti.ResumeLayout(false);
			this.grpImportEmisti.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		bool anyGenerated() {
			if (esistonoMovFinanziari("L")) return true;
			if (esistonoMovFinanziari("V")) return true;
			if (esistonoScritture()) return true;
			return false;
		}

		public void MetaData_AfterFill() {
			epm.mostraEtichette();
			epm_debit.mostraEtichette();
			txtEsercImport.ReadOnly = true;
			usePartition = nuovaGestione();
			if (Meta.InsertMode || Meta.EditMode) {
				CalcolaRighe();
				//RiempiVisteCollegate();
				EnableDisableDatiImport(false);
				if (usePartition) {
					//le scritture su debiti e crediti "nuove" saranno negli elenchi trasmissione
					grpScrittureChiusuraDebito.Enabled = false;
					//btnViewDebit.Enabled = false;
					//btnGeneDebit.Enabled = false;
				}

				bool generazioniEffettuate = anyGenerated();
				if (generazioniEffettuate) {
					btnDelete.Enabled = false;
				}
				else {
					btnDelete.Enabled = true;
				}
			}
 
			else {
				EnableDisableDatiImport(true);
				btnDelete.Enabled = false;
				btnInputRiepiloghi.Enabled = false;
				btnInputVersamenti.Enabled = false;
				btnImportEmisti.Enabled = false;
				txtRefExternalDoc.ReadOnly = false;
			}

			if (Meta.InsertMode) {
				btnInputRiepiloghi.Enabled = false;
				btnInputVersamenti.Enabled = false;
				btnImportEmisti.Enabled = false;
				btnInputSospesi.Enabled = false;
				
			}
			
			if ((Meta.EditMode)&&(esistonoMovFinanziari("L"))) {
				txtRefExternalDoc.ReadOnly = true;
			}
			else{
				txtRefExternalDoc.ReadOnly = false;
			}

			if ((Meta.EditMode) && ((esistonoMovFinanziari("L")|| esistonoMovFinanziari("V")))) {
				btnElabora.Enabled = false;
			}
			else {
				btnElabora.Enabled = true;
			}
			
			 
		}

		private void EnableDisableDatiImport(bool enable) {
			//txtEsercImport.ReadOnly = !enable;
			txtNumImport.ReadOnly = !enable;
		}

		/// <summary>
		/// Conta le righe di riepilogo e versamento e restituisce true se ve n'è almeno una su db
		/// </summary>
		/// <returns></returns>
		private bool CalcolaRighe() {
			//if (Meta.IsEmpty) return false;
			DataRow Curr = DS.csa_import.Rows[0];
			int countRiep = CfgFn.GetNoNullInt32(Meta.Conn.DO_READ_VALUE("csa_importriep",
				QHS.CmpEq("idcsa_import", Curr["idcsa_import"]), "count(*)"));
			int countVer = CfgFn.GetNoNullInt32(Meta.Conn.DO_READ_VALUE("csa_importver",
				QHS.CmpEq("idcsa_import", Curr["idcsa_import"]), "count(*)"));
			int countSospesi = CfgFn.GetNoNullInt32(Meta.Conn.DO_READ_VALUE("csa_bill",
				QHS.CmpEq("idcsa_import", Curr["idcsa_import"]), "count(*)"));

			if (Meta.EditMode) {
				bool checkElab = anyGenerated() == false;
				bool checkEmisti = esisteImportazioneEmisti();
				btnInputRiepiloghi.Enabled = checkElab || (countRiep == 0);
				btnInputVersamenti.Enabled = checkElab || (countVer == 0);

				btnImportEmisti.Enabled = false;
				btnImportEmisti.Enabled = (countRiep == 0 && countVer == 0 && !checkEmisti);
				btnInputSospesi.Enabled = true;
			}
			else {
				btnInputRiepiloghi.Enabled = false;
				btnInputVersamenti.Enabled = false;
				btnImportEmisti.Enabled = false;
			}

		 

			lblRigheRiep.Text = "Righe Riepiloghi Importate:" + countRiep.ToString();
			lblRigheVer.Text = "Righe Versamenti Importate:" + countVer.ToString();

			return (countRiep > 0) || (countVer > 0) || (countSospesi > 0);
		}

		private bool esistonoMovFinanziari(string kind) {
			//if (Meta.IsEmpty) return false;
			string filterMovKind = null;
			string listaMovKind = null;
			if (kind == "L") {
				listaMovKind = QHS.List(1, 2, 3, 5, 7, 8, 12, 14, 15, 16);
			}
			else {
				listaMovKind = QHS.List(4, 6, 9, 11, 13, 17);
			}

			filterMovKind = QHS.FieldInList("movkind", listaMovKind);

			DataRow Curr = DS.csa_import.Rows[0];
			int countIncome = CfgFn.GetNoNullInt32(Meta.Conn.DO_READ_VALUE("csa_import_income",
				QHS.AppAnd(filterMovKind,
					QHS.CmpEq("idcsa_import",
						Curr["idcsa_import"])),
				"count(*)"));

			int countExpense = CfgFn.GetNoNullInt32(Meta.Conn.DO_READ_VALUE("csa_import_expense",
				QHS.AppAnd(filterMovKind,
					QHS.CmpEq("idcsa_import",
						Curr["idcsa_import"])),
				"count(*)"));
			if ((countIncome > 0) || (countExpense > 0)) {
				
				return true;
			}

			return false;
		}

		private bool esistonoScritture() {
			//if (Meta.IsEmpty) return false;
			DataRow Curr = DS.csa_import.Rows[0];

			EP_functions EP = new EP_functions(Meta.Dispatcher);
			string idrelated = EP_functions.GetIdForDocument(Curr);
			string filterrelated = QHS.CmpEq("idrelated", idrelated);
			DataTable T = Conn.RUN_SELECT("entry", "*", null, filterrelated, null, true);

			if (T.Rows.Count > 0) {

				return true;
			}

			return false;
		}

		private bool esisteImportazioneEmisti() {
			//if (Meta.IsEmpty) return false;
			DataRow Curr = DS.csa_import.Rows[0];

			EP_functions EP = new EP_functions(Meta.Dispatcher);
 
			string filterrelated = QHS.CmpEq("idcsa_import", Curr["idcsa_import"]);
			DataTable T = Conn.RUN_SELECT("emisti_import", "*", null, filterrelated, null, true);

			if (T.Rows.Count > 0) {

				return true;
			}

			return false;
		}


		private bool esistonoMovBudget() {

			DataRow Curr = DS.csa_import.Rows[0];

			string idrelated = BudgetFunction.GetIdForDocument(Curr);
			string filterrelated = QHS.Like("idrelated", idrelated + "%");
			DataTable impegni = Conn.RUN_SELECT("epexp", "*", null, filterrelated, null, true);

			if (impegni.Rows.Count > 0) {
				return true;
			}

			DataTable accertamenti = Conn.RUN_SELECT("epacc", "*", null, filterrelated, null, true);

			if (accertamenti.Rows.Count > 0) {
				return true;
			}

			return false;
		}

		private bool VerificaIndividuazione(object sender) {
			if (Meta.IsEmpty) return false;
			if (DS.csa_importriep.Rows.Count == 0 && DS.csa_importver.Rows.Count == 0) return false;
			bool usa_partizioni = nuovaGestione();
			string sp_name = "check_csa_individuazione";
			if (usa_partizioni) sp_name = "check_csa_individuazione_partition";
			Button button = (Button) sender;
			DataGrid dgr = dgrVerificheFin;

			if (button.Name == "btnVerificaIndividuazioneEP") {
				sp_name = "check_csa_individuazione_ep";
				if (usa_partizioni) sp_name = "check_csa_individuazione_partition_ep";
				dgr = dgrVerificheEP;
			}

			DataRow Curr = DS.csa_import.Rows[0];
			object esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
			string errMess;


			DataSet ds = Conn.CallSP(sp_name,
				new object[] {Curr["idcsa_import"], Meta.GetSys("esercizio")}, 3600, out errMess);
			if (errMess != null) {
				show(this, "Errore nella chiamata della procedura di verifica: " + errMess, "Errore");
				return false;
			}

			DataTable tResult = ds.Tables[0];
			if (tResult.Rows.Count != 0) {
				// Visualizzazione del grid

				dgr.DataBindings.Clear();
				dgr.DataSource = null;
				dgr.TableStyles.Clear();
				HelpForm.SetDataGrid(dgr, tResult);
				FormatDataGrid(dgr, tResult);

				if (tResult.Select(QHC.CmpEq("blockingerror", "S")).Length > 0)
					return false;
				else {
					return true;
				}
			}
			else return true;
		}


		private DataRow GetGridSelectedRows(DataGrid G) {
			DataSet DSV = (DataSet) G.DataSource;
			if (DSV == null) return null;
			DataTable TV = DSV.Tables[G.DataMember];
			if (TV == null) return null;

			if (TV.Rows.Count == 0) return null;
			DataRowView DV = null;
			try {
				DV = (DataRowView) G.BindingContext[DSV, TV.TableName].Current;
			}
			catch {
				DV = null;
			}

			if (DV == null) return null;

			DataRow R = DV.Row;
			return R;
		}

		private void FormatDataGrid(DataGrid dgr, DataTable tResult) {

			foreach (DataColumn C in tResult.Columns) {
				tResult.Columns[C.ColumnName].Caption = "";
			}

			tResult.Columns["errorcode"].Caption = "#";
			tResult.Columns["errordescr"].Caption = "Descrizione";
			tResult.Columns["blockingerror"].Caption = "Bloccante";

			tResult.Columns["errorcode"].ExtendedProperties["ListColPos"] = 0;
			tResult.Columns["errordescr"].ExtendedProperties["ListColPos"] = 1;
			tResult.Columns["blockingerror"].ExtendedProperties["ListColPos"] = 2;

			HelpForm.SetGridStyle(dgr, tResult);
			metadatalibrary.formatgrids fg = new formatgrids(dgr);
			fg.AutosizeColumnWidth();
		}

		public void MetaData_AfterClear() {
			epm.mostraEtichette();
			epm_debit.mostraEtichette();
			lblIndividuazione.Text = "";
			lblRigheRiep.Text = "";
			lblRigheVer.Text = "";
			lblTask.Text = "";
			txtInputFile.Text = "";
			txtEsercImport.ReadOnly = true;
			txtEsercImport.Text = security.GetEsercizio().ToString();
			btnInputRiepiloghi.Enabled = true;
			btnInputVersamenti.Enabled = true;
			btnImportEmisti.Enabled = true;
			btnInputSospesi.Enabled = true;
			btnDelete.Enabled = true;
			btnElabora.Enabled = true;
			EnableDisableDatiImport(true);
			dgrVerificheFin.DataSource = null;
			dgrVerificheEP.DataSource = null;
			txtRefExternalDoc.ReadOnly = false;
		}


		public void MetaData_BeforePost() {
			//epm.beforePost();
			//epm_debit.beforePost();

		}

		public void MetaData_AfterPost() {
			//epm.afterPost();
			//epm_debit.afterPost();
		}




		private void btnRiepToExcel_Click(object sender, EventArgs e) {
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.CmpEq("idcsa_import", Curr["idcsa_import"]);
			string sqlCmd = " SELECT " +
			                //" ayear as 'Eserc.', " +
			                " idriep as 'Numero Riepilogo'," +
			                //" yimport as 'Eserc. Import'," +
			                //" nimport as 'Num. Import.'," +
			                " ycontract as 'Eserc Contr.'," +
			                " ncontract as 'Num. Contr.'," +
			                " csa_contractkind as 'Regola generale CSA'," +
			                " competenza ," +
			                " ruolocsa as 'Ruolo CSA'," +
			                " capitolocsa as 'Capitolo CSA'," +
			                " matricola as 'Matricola'," +
			                " importo as 'Importo'," +
			                " registry as 'Anagrafica'," +
			                " flagcr as 'Comp./Residui'," +
			                " codeupb as 'Cod. UPB'," +
			                " upb as 'UPB'," +
			                " codeacc as 'Cod. C/Costo'," +
			                " account as 'C/Costo'," +
			                " codefin as 'Cod. Bilancio Spesa'," +
			                " fin as 'Bilancio Spesa'," +
			                " phase as 'Fase Mov. spesa'," +
			                " ymov as 'Eserc. Mov.'," +
			                " nmov as 'Num. Mov.'" +
			                " FROM csa_importriepview " +
			                " WHERE " + filter;


			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati(sender, e, T, "csa_importriep", "default", filter);
			}
		}

		private void VisualizzaDati2(object sender, EventArgs e, DataTable T, string dataTable, string view,
			string listType, string filter, string filterView) {
			int testInt = 0;

			testInt = (rdbExpToExcel.Checked) ? 1 : testInt;
			testInt = (rdbExpToCsv.Checked) ? 2 : testInt;
			testInt = (rdbExpToListing.Checked) ? 3 : testInt;

			switch (testInt) {
				case 1: {
					Excel_Click(sender, e, T);
					break;
				}

				case 2: {
					Csv_Click(sender, e, T);
					break;
				}

				case 3: {
					Listing_Click(sender, e, dataTable, view, "default", null, filter, filterView);
					break;
				}

				default: {
					Excel_Click(sender, e, T);
					break;
				}
			}

		}

		private void VisualizzaDati3(object sender, EventArgs e, DataTable T, string dataTable, string view,
			string listType, string editType, string filter, string filterView) {
			int testInt = 0;

			testInt = (rdbExpToExcel.Checked) ? 1 : testInt;
			testInt = (rdbExpToCsv.Checked) ? 2 : testInt;
			testInt = (rdbExpToListing.Checked) ? 3 : testInt;

			switch (testInt) {
				case 1: {
					Excel_Click(sender, e, T);
					break;
				}

				case 2: {
					Csv_Click(sender, e, T);
					break;
				}

				case 3: {
					Listing_Click(sender, e, dataTable, view, "default", editType, filter, filterView);
					break;
				}

				default: {
					Excel_Click(sender, e, T);
					break;
				}
			}

		}


		private void VisualizzaDati(object sender, EventArgs e, DataTable T, string dataTable,
			string listType, string filter) {

			VisualizzaDati2(sender, e, T, dataTable, dataTable, listType, filter, filter);

		}




		private void VisualizzaElenchi(string kind, int errorcode) {
			if (Meta.IsEmpty) return;
			if (errorcode <= 0) return;


			if (kind == "EP") {
				if (errorcode > AllListEP.Length) {
					show(
						"Aggiornare il programma, la DLL di importazione CSA non è allineata con i check del db.",
						"Errore");
					return;
				}

				AllListEP[errorcode - 1](null, null);
			}
			else {
				if (errorcode > AllList.Length) {
					show(
						"Aggiornare il programma, la DLL di importazione CSA non è allineata con i check del db.",
						"Errore");
					return;
				}

				AllList[errorcode - 1](null, null);
			}
		}

		private void Excel_Click(object sender, EventArgs e, DataTable T) {
			if (T.Rows.Count == 0) {
				show("Nessun elemento trovato");
				return;
			}

			exportclass.DataTableToExcel(T, true);
		}



		private void Listing_Click(object sender, EventArgs e, string dataTable, string view, string listType,
			string editType,
			string filter, string filterView) {
			if (editType == null) editType = "default";
			MetaData MElenco = MetaData.GetMetaData(this, dataTable);
			int rowsfound = Conn.RUN_SELECT_COUNT(view, filterView, true);
			if (rowsfound == 0) {
				show("Nessun elemento trovato");
				return;
			}

			if (MElenco == null) return;
			MElenco.ContextFilter = filterView;
			bool result = MElenco.Edit(Meta.linkedForm.ParentForm, editType, false);
			DataRow R = MElenco.SelectOne(listType, filterView, null, null);
			if (R != null) MElenco.SelectRow(R, listType);
		}


		private void Csv_Click(object sender, EventArgs e, DataTable T) {
			if (T.Rows.Count == 0) {
				show("Nessun elemento trovato");
				return;
			}

			OpenFileDialog FD = new OpenFileDialog();
			FD.Title = "Seleziona il file CSV da creare";
			FD.AddExtension = true;
			FD.DefaultExt = "CSV";
			FD.CheckFileExists = false;
			FD.CheckPathExists = true;
			FD.Multiselect = false;
			DialogResult DR = FD.ShowDialog();
			if (DR != DialogResult.OK) {
				show("Non è stata scelta la destinazione");
				txtInputFile.Text = "";
				return;
			}

			try {
				exportclass.dataTableToCommaSeparatedValues(T, true, FD.FileName);
				Process.Start(FD.FileName);
			}
			catch (Exception E) {
				QueryCreator.ShowException(E);
			}

		}



		private void btnVerToExcel_Click(object sender, EventArgs e) {
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.CmpEq("idcsa_import", Curr["idcsa_import"]);
			string sqlCmd = " SELECT " +
			                " ayear as 'Eserc.', " +
			                " idver as 'Numero Versam.'," +
			                " yimport as 'Eserc. Import'," +
			                " nimport as 'Num. Import.'," +
			                " ycontract as 'Eserc Contr.'," +
			                " ncontract as 'Num. Contr.'," +
			                " csa_contractkind as 'Regola generale CSA'," +
			                " ruolocsa as 'Ruolo CSA'," +
			                " capitolocsa as 'Capitolo CSA'," +
			                " matricola as 'Matricola'," +
			                " ente as 'Ente'," +
			                " vocecsa as 'Voce CSA'," +
			                " importo as 'Importo'," +
			                " registry as 'Anagrafica'," +
			                " agency as 'Ente CSA'," +
			                " registry_agency as 'Anagr. Ente CSA'," +
			                " codeacc_debit as 'Cod. C/Debito'," +
			                " account_debit as 'C/Debito'," +
			                " codeacc_expense as 'Cod. C/Vers. Imposte'," +
			                " account_expense as 'C/Vers. Imposte'," +
			                " codeacc_internalcredit as 'Cod. C/Credito Interno'," +
			                " account_internalcredit as 'C/Credito Interno'," +
			                " codeacc_cost as 'Cod. C/Costo'," +
			                " account_cost as 'C/Costo'," +
			                " codeupb as 'Cod. UPB'," +
			                " upb as 'UPB'," +
			                " codefin_income as 'Cod. Bil. Entrata'," +
			                " fin_income as 'Bil. Entrata'," +
			                " codefin_expense as 'Cod. Bil. Spesa'," +
			                " fin_expense as 'Cod. Bil. Spesa'," +
			                " codefin_incomeclawback as 'Cod. Bil. Entrata per Recuperi'," +
			                " fin_incomeclawback as 'Bil. Entrata per Recuperi'," +
			                " codefin_cost as 'Cod. Bilancio Spesa Costo'," +
			                " fin_cost as 'Bilancio Spesa Costo'," +
			                " phase_cost as 'Fase Mov. spesa Costo'," +
			                " ymov_cost as 'Eserc. Mov. Costo'," +
			                " nmov_cost as 'Num. Mov. Costo'," +
			                " flagcr as 'Comp./Residui'," +
			                " flagclawback as 'Recupero'" +
			                " FROM csa_importverview " +
			                " WHERE " + filter;


			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati(sender, e, T, "csa_importver", "default", filter);
			}
		}

		private void btnElabora_Click(object sender, System.EventArgs e) {
			if (Meta.IsEmpty) return;
			if (Meta.InsertMode) return;
			btnElabora.Visible = false;
			if (!CalcolaRighe()) {
				btnElabora.Visible = true;
				show(this, "Non ci sono dati da elaborare");
				return;
			}

			lblIndividuazione.Text = "Individuazione Contratti, Anagrafiche, Enti. Attendere...";
			dgrVerificheFin.DataSource = null;
			dgrVerificheEP.DataSource = null;
			//Meta.FreshForm();
			Application.DoEvents();
			DataRow Curr = DS.csa_import.Rows[0];
			DataSet OutDS = Meta.Conn.CallSP("calc_csaimport",
				new object[2] {
					Curr["idcsa_import"],
					Meta.GetSys("esercizio"),
				}, false, 3600);
			lblIndividuazione.Text = "";
			if (OutDS == null) {
				btnElabora.Visible = true;
				return;
			}

			Conn.RUN_SELECT_INTO_TABLE(DS.csa_importriep, null, QHS.CmpEq("idcsa_import", Curr["idcsa_import"]), null,
				false);
			Conn.RUN_SELECT_INTO_TABLE(DS.csa_importver, null, QHS.CmpEq("idcsa_import", Curr["idcsa_import"]), null,
				false);

			Conn.RUN_SELECT_INTO_TABLE(DS.csa_importriep_partition, null,
				QHS.CmpEq("idcsa_import", Curr["idcsa_import"]), null,
				false);
			Conn.RUN_SELECT_INTO_TABLE(DS.csa_importver_partition, null,
				QHS.CmpEq("idcsa_import", Curr["idcsa_import"]), null,
				false);

			//Conn.RUN_SELECT_INTO_TABLE(DS.csa_importriep_partitionview, null, QHS.CmpEq("idcsa_import", Curr["idcsa_import"]), null,
			//   false);
			//Conn.RUN_SELECT_INTO_TABLE(DS.csa_importver_partitionview, null, QHS.CmpEq("idcsa_import", Curr["idcsa_import"]), null,
			//    false);

			if (DS.csa_importriep_partition.Rows.Count == 0 && DS.csa_importver_partition.Rows.Count == 0) {
				Conn.RUN_SELECT_INTO_TABLE(DS.csa_importriep_epexp, null,
					QHS.CmpEq("idcsa_import", Curr["idcsa_import"]), null,
					false);
				Conn.RUN_SELECT_INTO_TABLE(DS.csa_importver_epexp, null,
					QHS.CmpEq("idcsa_import", Curr["idcsa_import"]), null,
					false);
				Conn.RUN_SELECT_INTO_TABLE(DS.csa_importriep_expense, null,
					QHS.CmpEq("idcsa_import", Curr["idcsa_import"]), null,
					false);
				Conn.RUN_SELECT_INTO_TABLE(DS.csa_importver_expense, null,
					QHS.CmpEq("idcsa_import", Curr["idcsa_import"]), null,
					false);


				foreach (DataRow r in DS.csa_importriep.Rows) {
					if (r["idexp"] != DBNull.Value) continue;
					if (r["idcsa_contract"] == DBNull.Value) continue;
					if (DS.csa_importriep_expense.Select(QHC.AppAnd(QHC.CmpEq("idriep", r["idriep"]),
						    QHC.CmpEq("idcsa_import", r["idcsa_import"]))).Length == 0)
						fillcsa_importriep_expense(r);
				}

				foreach (DataRow r in DS.csa_importriep.Rows) {
					if (r["idexp"] != DBNull.Value) continue;
					if (r["idcsa_contract"] == DBNull.Value) continue;
					if (DS.csa_importriep_epexp.Select(QHC.AppAnd(QHC.CmpEq("idriep", r["idriep"]),
						    QHC.CmpEq("idcsa_import", r["idcsa_import"]))).Length == 0)
						fillcsa_importriep_epexp(r);
				}


				foreach (DataRow r in DS.csa_importver.Rows) {
					if (r["idexp_cost"] != DBNull.Value) continue;
					if (r["idcsa_contracttax"] == DBNull.Value) continue;
					if (DS.csa_importver_expense.Select(QHC.AppAnd(QHC.CmpEq("idver", r["idver"]),
						    QHC.CmpEq("idcsa_import", r["idcsa_import"]))).Length == 0)
						fillcsa_importver_expense(r);
				}

				foreach (DataRow r in DS.csa_importver.Rows) {
					if (r["idepexp"] != DBNull.Value) continue;
					if (r["idcsa_contracttax"] == DBNull.Value) continue;
					if (DS.csa_importver_epexp.Select(QHC.AppAnd(QHC.CmpEq("idver", r["idver"]),
						    QHC.CmpEq("idcsa_import", r["idcsa_import"]))).Length == 0)
						fillcsa_importver_epexp(r);
				}


			}






			Meta.SaveFormData();
			if (DS.HasChanges()) {
				show(this, "Elaborazione fallita, è necessario cancellarla e rifarla.", "Errore");
				return;
			}

			//Meta.FreshForm();
			show(this, "Elaborazione effettuata.");
			btnElabora.Visible = true;
		}


		private DataTable interrogaFileExcel(string task) {
			if (txtInputFile.Text == "") {
				show("Non è stato scelto alcun file!");
				return null;
			}

			DataTable t;
			try {
				string fileName = openInputFileDlg.FileName;
				//ConnectionString = ExcelImport.ExcelConnString(fileName);
				t = createTable(task);
				readCurrentSheet(t, fileName);
			}
			catch (Exception ex) {
				show(this, "Errore nell'apertura del file! Processo Terminato\n" + ex.Message);
				return null;
			}

			//if (!verificaValiditaFileExcel(t,task)) {
			//	show(this, "Il file selezionato non è valido per il compito selezionato", "Errore");
			//	return null;
			//}

			return t;
		}

		/// <summary>
		/// legge i dati dal foglio di Excel a mData
		/// </summary>
		private void readCurrentSheet(DataTable t, string fileName) {
			try {
				lblTask.Text = "Apertura del file...Attendere";
				// open the connection to the file
				//using (OleDbConnection connection =
				//    new OleDbConnection(ConnectionString)) {
				//    connection.Open();
				//    System.Data.DataTable sheetData = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
				//    string foglioLavoro = sheetData.Rows[0]["TABLE_NAME"].ToString();
				//    string sql =
				//        string.Format("select * from [{0}]", foglioLavoro);
				//    // create an adapter
				//    using (OleDbDataAdapter adapter =
				//        new OleDbDataAdapter(sql, connection)) {
				//        // clear the datatable to avoid old data persistance
				//        mData.Clear();
				//        mData.Columns.Clear();

				//        // fille the datatable
				//        lblTask.Text = "Riempimento della tabella temporanea Fase 2 di 2 ...ATTENDERE";
				//        adapter.Fill(mData);
				//        lblTask.Text = "";
				//    }
				//}
				if (fileName.EndsWith("xls") || fileName.EndsWith("xlsx")) {
					// con header
					ExcelImport x = new ExcelImport();
					//ConnectionString = ExcelImport.ExcelConnString(fileName);
					x.ImportTable(fileName, t, true, 2);
				}

				lblTask.Text = "";
			}
			catch (Exception ex) {
				show(this, ex.Message);
			}
		}



		string[] tracciato_sospeso =
			new string[] {
				"CODICE_ANAGRAFICA;Cod. Anagrafica (idreg numerico);Intero;8",
				"N_SOSPESO;Numero sospeso(nbill);Intero;8",
				"IMPORTO;Importo;Numero;22"
			};

		private DataTable createTable(string kind) {
			DataTable t = new DataTable("data");
			t.CaseSensitive = false;
			switch (kind) {
				case "R": {
					t.Columns.Add("RUOLO", typeof(string));
					t.Columns.Add("CAPITOLO", typeof(string));
					t.Columns.Add("COMPETENZA", typeof(int));
					t.Columns.Add("MATRICOLA", typeof(string));
					t.Columns.Add("LORDO", typeof(decimal));
					break;
				}

				case "V": {
					t.Columns.Add("ENTE", typeof(string));
					t.Columns.Add("ENTE_DESCR", typeof(string));
					t.Columns.Add("VOCE", typeof(string));
					t.Columns.Add("RUOLO", typeof(string));
					t.Columns.Add("CAPITOLO", typeof(string));
					t.Columns.Add("COMPETENZA", typeof(int));
					t.Columns.Add("MATRICOLA", typeof(string));
					t.Columns.Add("IMP_TOT", typeof(decimal));
					break;
				}

				case "S": {
					t.Columns.Add("CODICE_ANAGRAFICA", typeof(int));
					t.Columns.Add("N_SOSPESO", typeof(int));
					t.Columns.Add("IMPORTO", typeof(decimal));
					break;
				}
			}
	

			return t;
		}



		private void btnInputFile_Click(object sender, EventArgs e) {
			if (Meta.IsEmpty) return;

			DialogResult dr = openInputFileDlg.ShowDialog();
			if (dr != DialogResult.OK) {
				show("Non è stato scelto alcun file");
				txtInputFile.Text = "";
				return;
			}

			string fileName = openInputFileDlg.FileName;
			txtInputFile.Text = fileName;

			Button B = (Button) sender;
			if (B.IsDisposed) return;
			if (!B.Enabled) return;
			switch (B.Name) {
				case "btnInputRiepiloghi": {
					var res = interrogaFileExcel("R");
					if (res == null) return;
					fillRiepiloghi(res);
					break;
				}

				case "btnInputVersamenti": {
					var res = interrogaFileExcel("V");
					if (res == null) return;
					fillVersamenti(res);
					break;
				}

				case "btnInputSospesi": {
					var res = interrogaFileExcel("S");
					fillSospesi(res);
					break;
				}

			}

			CalcolaRighe();
		}

		/// <summary>
		/// Riempie la tabella dei RIEPILOGHI a partire dalla tabella mData (che rappresenta il foglio di excel importato)
		///  e salva i dati su db
		/// </summary>
		private void fillRiepiloghi(DataTable t) {
			if (Meta.IsEmpty) return;
			int step = t.Rows.Count / 100;
			if (step < 100) step = 100;
			progressBarImport.Visible = true;
			progressBarImport.Value = 0;
			progressBarImport.Maximum = t.Rows.Count;
			// riempie il Dataset con le righe dei dettagli 
			// a partire dalla tabella temporanea mData
			lblTask.Text = "Riempimento della tabella dei riepiloghi. Attendere...";
			if (DS.csa_import.Rows.Count == 0) return;
			DataRow RCurr = DS.csa_import.Rows[0];
			MetaData MetaDetail = MetaData.GetMetaData(this, "csa_importriep");
			MetaDetail.SetDefaults(DS.csa_importriep);
			int numparz = 0;
			int numtot = 0;

			RowChange.SetOptimized(DS.csa_importriep, true);
			RowChange.ClearMaxCache(DS.csa_importriep);
			foreach (DataColumn c in t.Columns) c.ColumnName = c.ColumnName.ToLowerInvariant();
			foreach (DataRow rFile in t.Rows) {
				numparz++;
				numtot++;
				if (CfgFn.GetNoNullDecimal(rFile["lordo"]) != 0) {
					DataRow rNew = MetaDetail.Get_New_Row(RCurr, DS.csa_importriep);
					//rNew["idriep"] = numtot + 1;
					rNew["ruolocsa"] = rFile["ruolo"];
					rNew["capitolocsa"] = rFile["capitolo"];
					rNew["competenza"] = rFile["competenza"];
					rNew["matricola"] = rFile["matricola"];
					rNew["ayear"] = Meta.GetSys("esercizio");
					rNew["importo"] = CfgFn.GetNoNullDecimal(rFile["lordo"]);
					rNew["lt"] = DateTime.Now;
					rNew["lu"] = "Import";


				}

				if (numparz == step) {
					//Salva i dati
					if (!SaveData()) return;
					numparz = 0;
					progressBarImport.Value = progressBarImport.Value + step;
					//Application.DoEvents();
					DS.csa_importriep.Clear();

					RowChange.ClearMaxCache(DS.csa_importriep);
				}
			}

			if (numparz > 0) {
				//Salva i dati
				if (!SaveData()) return;
				progressBarImport.Value = progressBarImport.Value + numparz;
				//Application.DoEvents();
				DS.csa_importriep.Clear();
				RowChange.ClearMaxCache(DS.csa_importriep);
			}

			progressBarImport.Visible = false;
			lblTask.Text = "";

		}

		public void fillcsa_importriep_expense(DataRow rImportRiep) {
			DataRow Curr = DS.csa_import.Rows[0];
			DataTable t = Conn.RUN_SELECT("csa_contractexpense", "*", "ndetail",
				QHS.AppAnd(QHS.CmpEq("idcsa_contract", rImportRiep["idcsa_contract"]),
					QHS.CmpEq("ayear", Conn.GetEsercizio())), null,
				false);
			if (t == null || t.Rows.Count == 0) return;
			MetaData metaImportRiep_Expense = Meta.Dispatcher.Get("csa_importriep_expense");
			decimal totaleperc_residuo = MetaData.SumColumn(t, "quota");
			decimal totale_residuo = CfgFn.GetNoNullDecimal(rImportRiep["importo"]);
			metaImportRiep_Expense.SetDefaults(DS.csa_importriep_expense);
			foreach (DataRow r in t.Rows) {
				decimal quotaCorrente = CfgFn.GetNoNullDecimal(r["quota"]);
				decimal quotaDaConsiderare = quotaCorrente / totaleperc_residuo;
				decimal quotaImporto = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(quotaDaConsiderare) * totale_residuo);
				MetaData.SetDefault(DS.csa_importriep_expense, "ndetail", r["ndetail"]);
				MetaData.SetDefault(DS.csa_importriep_expense, "idriep", rImportRiep["idriep"]);
				DataRow newR = metaImportRiep_Expense.Get_New_Row(Curr, DS.csa_importriep_expense);
				newR["idexp"] = r["idexp"];
				newR["amount"] = quotaImporto;
				totale_residuo -= quotaImporto;
				totaleperc_residuo -= quotaCorrente;
			}
		}





		public void fillcsa_importver_expense(DataRow rImportVer) {
			DataRow Curr = DS.csa_import.Rows[0];
			DataTable t = Conn.RUN_SELECT("csa_contracttaxexpense", "*", "ndetail",
				QHS.AppAnd(QHS.CmpEq("idcsa_contract", rImportVer["idcsa_contract"]),
					QHS.CmpEq("idcsa_contracttax", rImportVer["idcsa_contracttax"]),
					QHS.CmpEq("ayear", Conn.GetEsercizio())), null,
				false);
			if (t == null || t.Rows.Count == 0) return;
			MetaData metaImportVer_Expense = Meta.Dispatcher.Get("csa_importver_expense");
			decimal totaleperc_residuo = MetaData.SumColumn(t, "quota");
			decimal totale_residuo = CfgFn.GetNoNullDecimal(rImportVer["importo"]);
			metaImportVer_Expense.SetDefaults(DS.csa_importver_expense);
			foreach (DataRow r in t.Rows) {
				if (totale_residuo == 0 || totaleperc_residuo == 0) break;
				decimal quotaCorrente = CfgFn.GetNoNullDecimal(r["quota"]);
				decimal quotaDaConsiderare = quotaCorrente / totaleperc_residuo;
				decimal quotaImporto = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(quotaDaConsiderare) * totale_residuo);
				MetaData.SetDefault(DS.csa_importver_expense, "ndetail", r["ndetail"]);
				MetaData.SetDefault(DS.csa_importver_expense, "idver", rImportVer["idver"]);
				DataRow newR = metaImportVer_Expense.Get_New_Row(Curr, DS.csa_importver_expense);
				newR["idexp"] = r["idexp"];
				newR["amount"] = quotaImporto;
				totale_residuo -= quotaImporto;
				totaleperc_residuo -= quotaCorrente;
			}
		}





		public void fillcsa_importriep_epexp(DataRow rImportRiep) {
			DataRow Curr = DS.csa_import.Rows[0];
			DataTable t = Conn.RUN_SELECT("csa_contractepexp", "*", "ndetail",
				QHS.AppAnd(QHS.CmpEq("idcsa_contract", rImportRiep["idcsa_contract"]),
					QHS.CmpEq("ayear", Conn.GetEsercizio())), null,
				false);
			if (t == null || t.Rows.Count == 0) return;
			MetaData metaImportRiep_EpExp = Meta.Dispatcher.Get("csa_importriep_epexp");
			metaImportRiep_EpExp.SetDefaults(DS.csa_importriep_epexp
			);
			foreach (DataRow r in t.Rows) {
				MetaData.SetDefault(DS.csa_importriep_epexp, "ndetail", r["ndetail"]);
				MetaData.SetDefault(DS.csa_importriep_epexp, "idriep", rImportRiep["idriep"]);
				DataRow newR = metaImportRiep_EpExp.Get_New_Row(Curr, DS.csa_importriep_epexp);
				newR["idepexp"] = r["idepexp"];
				newR["quota"] = r["quota"];
			}
		}

		public void fillcsa_importver_epexp(DataRow rImportVer) {
			DataRow Curr = DS.csa_import.Rows[0];
			DataTable t = Conn.RUN_SELECT("csa_contracttaxepexp", "*", "ndetail",
				QHS.AppAnd(QHS.CmpEq("idcsa_contract", rImportVer["idcsa_contract"]),
					QHS.CmpEq("idcsa_contracttax", rImportVer["idcsa_contracttax"]),
					QHS.CmpEq("ayear", Conn.GetEsercizio())), null,
				false);
			if (t == null || t.Rows.Count == 0) return;
			MetaData metaImportVer_EpExp = Meta.Dispatcher.Get("csa_importver_expense");
			metaImportVer_EpExp.SetDefaults(DS.csa_importriep_epexp);
			foreach (DataRow r in t.Rows) {
				MetaData.SetDefault(DS.csa_importver_epexp, "ndetail", r["ndetail"]);
				MetaData.SetDefault(DS.csa_importver_epexp, "idver", rImportVer["idver"]);
				DataRow newR = metaImportVer_EpExp.Get_New_Row(Curr, DS.csa_importver_epexp);
				newR["idepexp"] = r["idepexp"];
				newR["quota"] = r["quota"];
			}
		}

		/// <summary>
		/// Riempie la tabella dei VERSAMENTI a partire dalla tabella mData (che rappresenta il foglio di excel importato)
		///  e salva i dati su db
		/// </summary>
		private void fillVersamenti(DataTable t) {
			if (Meta.IsEmpty) return;
			int step = t.Rows.Count / 100;
			if (step < 100) step = 100;
			progressBarImport.Visible = true;
			progressBarImport.Value = 0;
			progressBarImport.Maximum = t.Rows.Count;
			// riempie il Dataset con le righe dei dettagli 
			// a partire dalla tabella temporanea mData
			if (DS.csa_import.Rows.Count == 0) return;
			lblTask.Text = "Riempimento della tabella dei versamenti. Attendere...";
			int numparz = 0;
			int numtot = 0;
			DataRow RCurr = DS.csa_import.Rows[0];

			RowChange.SetOptimized(DS.csa_importver, true);
			RowChange.ClearMaxCache(DS.csa_importver);

			MetaData MetaDetail = MetaData.GetMetaData(this, "csa_importver");
			MetaDetail.SetDefaults(DS.csa_importver);

			foreach (DataColumn c in t.Columns) c.ColumnName = c.ColumnName.ToLowerInvariant().Trim();

			foreach (DataRow rFile in t.Rows) {
				numparz++;
				numtot++;
				if (CfgFn.GetNoNullDecimal(rFile["imp_tot"]) != 0) {
					DataRow rNew = MetaDetail.Get_New_Row(RCurr, DS.csa_importver);
					//rNew["idver"] = numtot + 1;
					rNew["ruolocsa"] = rFile["ruolo"];
					rNew["capitolocsa"] = rFile["capitolo"];
					rNew["competenza"] = rFile["competenza"];
					rNew["matricola"] = rFile["matricola"];
					if (rFile["ente_descr"] == DBNull.Value) {
						rNew["ente"] = rFile["ente"];
					}
					else {
						rNew["ente"] = rFile["ente"] + " - " + rFile["ente_descr"];
					}

					rNew["ruolocsa"] = rFile["ruolo"];
					rNew["vocecsa"] = rFile["voce"];
					rNew["ayear"] = Meta.GetSys("esercizio");
					rNew["importo"] = CfgFn.GetNoNullDecimal(rFile["imp_tot"]);
					rNew["lt"] = DateTime.Now;
					rNew["lu"] = "Import";


				}

				if (numparz == step) {
					//Salva i dati
					if (!SaveData()) return;
					numparz = 0;
					progressBarImport.Value = progressBarImport.Value + step;
					//Application.DoEvents();
					DS.csa_importver.Clear();

					RowChange.ClearMaxCache(DS.csa_importver);
				}
			}

			if (numparz > 0) {
				//Salva i dati
				if (!SaveData()) return;
				progressBarImport.Value = progressBarImport.Value + numparz;
				//Application.DoEvents();
				DS.csa_importver.Clear();
				RowChange.ClearMaxCache(DS.csa_importver);
			}

			lblTask.Text = "";
			progressBarImport.Visible = false;
		}


		private void fillSospesi(DataTable t) {
			if (Meta.IsEmpty) return;
			if (!VerificaFileSospesi(t)) return;
			int step = t.Rows.Count / 100;
			if (step < 100) step = 100;
			progressBarImport.Visible = true;
			progressBarImport.Value = 0;
			progressBarImport.Maximum = t.Rows.Count;
			// riempie il Dataset con le righe dei dettagli 
			// a partire dalla tabella temporanea mData
			if (DS.csa_import.Rows.Count == 0) return;
			lblTask.Text = "Riempimento della tabella dei sospesi. Attendere...";
			int numparz = 0;
			int numtot = 0;
			DataRow RCurr = DS.csa_import.Rows[0];

			RowChange.SetOptimized(DS.csa_bill, true);
			RowChange.ClearMaxCache(DS.csa_bill);

			MetaData MetaDetail = MetaData.GetMetaData(this, "csa_bill");
			MetaDetail.SetDefaults(DS.csa_bill);

			foreach (DataColumn c in t.Columns) c.ColumnName = c.ColumnName.ToUpperInvariant();

			foreach (DataRow rFile in t.Rows) {
				numparz++;
				numtot++;
				if (CfgFn.GetNoNullDecimal(rFile["importo"]) != 0) {
					DataRow rNew = MetaDetail.Get_New_Row(RCurr, DS.csa_bill);
					rNew["idreg"] = GetAnagrafica(rFile["codice_anagrafica"]);
					rNew["nbill"] = rFile["N_SOSPESO"];
					rNew["amount"] = CfgFn.GetNoNullDecimal(rFile["IMPORTO"]);
					rNew["ct"] = DateTime.Now;
					rNew["cu"] = "Import";
					rNew["lt"] = DateTime.Now;
					rNew["lu"] = "Import";
				}

			}

			for (int i = 0; i < DS.csa_bill.Rows.Count; i++) {
				if (DS.csa_bill.Rows[i].RowState == DataRowState.Deleted) continue;
				VisualizzaVociCollegate(DS.csa_bill.Rows[i]);
			}

			if (numparz > 0) {
				//Salva i dati
				if (!SaveData()) return;
				progressBarImport.Value = progressBarImport.Value + numparz;
				//Application.DoEvents();
				//DS.csa_bill.Clear();
				RowChange.ClearMaxCache(DS.csa_bill);
			}

			lblTask.Text = "";
			progressBarImport.Visible = false;
		}

		private bool VerificaFileSospesi(DataTable mData) {


			bool ok = true;
			DataSet Out = new DataSet();
			DataTable T = new DataTable();
			T.Columns.Add("errors", typeof(System.String), "");
			for (int i = 0; i < tracciato_sospeso.Length; i++) {
				string fmt = tracciato_sospeso[i];
				bool datiValidi = GetField(fmt, T, mData);
				if (!datiValidi) ok = false;
			}

			Out.Tables.Add(T);

			if (!ok) {
				FrmViewError View = new FrmViewError(Out);
				View.Show();
			}

			return ok;
		}


		bool GetField(string tracciato_field, DataTable errors, DataTable mData) {


			bool ok = true;
			string[] ff = tracciato_field.Split(';');
			string fieldname = ff[0].ToLower();

			int len = Convert.ToInt32(ff[3]);
			string ftype = ff[2].ToLower().Trim(); //(intero/numero/stringa/codificato/data)
			int rownum = 0;
			foreach (DataRow riga in mData.Select()) {
				string val = riga[fieldname].ToString().Trim();
				rownum++;
				switch (fieldname) {

					case "importo":

						if (CfgFn.GetNoNullDecimal(val) <= 0) {
							string err = "Valore non previsto per il campo " + fieldname + " di tipo " + ftype +
							             " e di valore " +
							             val.Trim() + " alla riga " + rownum + ": inserire un importo maggiore di zero";
							DataRow row = errors.NewRow();
							row["errors"] = err;
							errors.Rows.Add(row);
							ok = false;
						}

						break;
					case "codice_anagrafica":
						if ((GetAnagrafica(val) == DBNull.Value) || (GetAnagrafica(val) == null)) {
							string err = "Anagrafica non trovata (o esiste ma disattiva) nella lettura del campo " + fieldname +
							             " di tipo " + ftype + " e di valore " +
							             val.Trim() + " alla riga " + rownum;
							DataRow row = errors.NewRow();
							row["errors"] = err;
							errors.Rows.Add(row);
							ok = false;
						}

						break;
					case "n_sospeso":
						if (CheckSospeso(val) == false) {
							string err = "Sospeso di uscita non valido nella lettura del campo " + fieldname +
							             " di tipo " + ftype + " e di valore " +
							             val.Trim() + " alla riga " + rownum;
							DataRow row = errors.NewRow();
							row["errors"] = err;
							errors.Rows.Add(row);
							ok = false;
						}

						break;
				}
			}

			return ok;
		}

		void VisualizzaVoceCreditore(DataRow R) {
			if (R["idreg"] == DBNull.Value) return;
			R["!registry"] = GetTitleForIdReg(R["idreg"]);
		}

		void VisualizzaCausaleSospeso(DataRow R) {
			if (R["nbill"] == DBNull.Value) return;
			R["!motive"] = GetMotiveForNbill(R["nbill"]);
		}

		void VisualizzaDataSospeso(DataRow R) {
			if (R["nbill"] == DBNull.Value) return;
			R["!datasospeso"] = GetDateForNbill(R["nbill"]);
		}

		void VisualizzaVociCollegate(DataRow Row) {

			if (Row.Table.TableName == "csa_bill") {
				VisualizzaVoceCreditore(Row);
				VisualizzaCausaleSospeso(Row);
				VisualizzaDataSospeso(Row);
			}
		}

		Dictionary<int, string> __billMotive = new Dictionary<int, string>();

		string GetMotiveForNbill(object nbill) {
			if (nbill == DBNull.Value)
				return "";
			int n = Convert.ToInt32(nbill);
			if (__billMotive.ContainsKey(n))
				return __billMotive[n];
			object motive = Conn.DO_READ_VALUE("bill",
				QHS.AppAnd(QHS.CmpEq("nbill", nbill), QHS.CmpEq("billkind", "D"),
					QHS.CmpEq("ybill", Meta.GetSys("esercizio"))), "motive");
			if (motive == null) {
				motive = "[sospeso numero " + nbill + "]";
			}

			__billMotive[n] = motive.ToString();
			return motive.ToString();
		}


		Dictionary<int, string> __billDate = new Dictionary<int, string>();

		object GetDateForNbill(object nbill) {
			if (nbill == DBNull.Value)
				return "";
			int n = Convert.ToInt32(nbill);
			if (__billDate.ContainsKey(n))
				return __billDate[n];
			object date = Conn.DO_READ_VALUE("bill",
				QHS.AppAnd(QHS.CmpEq("nbill", nbill), QHS.CmpEq("billkind", "D"),
					QHS.CmpEq("ybill", Meta.GetSys("esercizio"))), "adate");
			if (date == null) {
				date = "[data sospeso numero " + nbill + "]";
			}

			__billDate[n] = date.ToString();
			return date;
		}


		private bool SaveData() {
			Easy_PostData MyPostData = new Easy_PostData();
			MyPostData.InitClass(DS, Meta.Conn);
			bool res = MyPostData.DO_POST();
			return res;
		}

		/// <summary>
		/// Cancella i dati relativi ad una importazione, esclusi i movimenti finanziari collegati 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDelete_Click(object sender, EventArgs e) {
			if (Meta.IsEmpty) return;
			if (Meta.InsertMode) return;
			if (esistonoMovFinanziari("L")) return;
			if (esistonoMovFinanziari("V")) return;
			if (esistonoScritture()) return;
			if (esistonoMovBudget()) return;

			if (!CalcolaRighe()) {
				show(this, "Non ci sono dati da elaborare");
				return;
			}

			DataRow Curr = DS.csa_import.Rows[0];

			if (show(
				    "Confermi la cancellazione dei dati importati (File Riepiloghi, Versamenti e Ripartizione in Sospesi)?",
				    "Cancella",
				    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != DialogResult.Yes)
				return;

			string deleteFrom = "";

			lblIndividuazione.Text = "Cancellazione versamenti, riepiloghi e sospesi importati. Attendere...";
			Meta.FreshForm();
			epm.beforePost(true);

			deleteFrom = " DELETE FROM csa_importver WHERE " + QHS.CmpEq("idcsa_import", Curr["idcsa_import"]);
			Conn.SQLRunner(deleteFrom);

			deleteFrom = " DELETE FROM csa_importver_expense WHERE " + QHS.CmpEq("idcsa_import", Curr["idcsa_import"]);
			Conn.SQLRunner(deleteFrom);

			deleteFrom = " DELETE FROM csa_importver_epexp WHERE " + QHS.CmpEq("idcsa_import", Curr["idcsa_import"]);
			Conn.SQLRunner(deleteFrom);

			deleteFrom = " DELETE FROM csa_importriep WHERE " + QHS.CmpEq("idcsa_import", Curr["idcsa_import"]);
			Conn.SQLRunner(deleteFrom);

			deleteFrom = " DELETE FROM csa_importriep_expense WHERE " + QHS.CmpEq("idcsa_import", Curr["idcsa_import"]);
			Conn.SQLRunner(deleteFrom);

			deleteFrom = " DELETE FROM csa_importriep_epexp WHERE " + QHS.CmpEq("idcsa_import", Curr["idcsa_import"]);
			Conn.SQLRunner(deleteFrom);

			deleteFrom = " DELETE FROM csa_importriep_partition WHERE " +
			             QHS.CmpEq("idcsa_import", Curr["idcsa_import"]);
			Conn.SQLRunner(deleteFrom);

			deleteFrom = " DELETE FROM csa_importver_partition WHERE " +
			             QHS.CmpEq("idcsa_import", Curr["idcsa_import"]);
			Conn.SQLRunner(deleteFrom);

			deleteFrom = " DELETE FROM csa_bill WHERE " + QHS.CmpEq("idcsa_import", Curr["idcsa_import"]);
			Conn.SQLRunner(deleteFrom);


			lblIndividuazione.Text = "Cancellazione dei movimenti finanziari collegati. Attendere...";
			Meta.FreshForm();

			CalcolaRighe();

			lblIndividuazione.Text = " Cancellazione scritture ed impegni di budget. Attendere...";
			epm.afterPost();
			Meta.FreshForm();

			lblIndividuazione.Text = " ";
			RowChange.ClearMaxCache(DS.csa_importriep);
			RowChange.ClearMaxCache(DS.csa_importver);
			DS.csa_importriep.Clear();
			DS.csa_importver.Clear();
			DS.csa_importver_expense.Clear();
			DS.csa_importver_epexp.Clear();
			DS.csa_importriep_epexp.Clear();
			DS.csa_importriep_expense.Clear();
			DS.csa_bill.Clear();
			Meta.FreshForm();
		}

		/*
            un controllo potrebbe essere, per i recuperi, che ci sia il cap. di entrata (quello relativo ai lordi)
            flagclawback = 'S': idfin_income

            e poi se ha il cap. di spesa nel versamento deve avere anche l'entrata e viceversa (sempre per i recuperi)
            flagclawback = 'S': idfin_expense --> idfin_incomeclawback
            flagclawback = 'S': idfin_incomeclawback--> idfin_expense


            ok per i non recuperi invece, è obbligatorio che ci sia il o il cap. spesa O il cap. di versamento
            flagclawback = 'N': idfin_cost OR idfin_expense


            e se c'è il cap. di entrata dei lordi ci deve essere anche il cap. di spesa dei versamenti
            flagclawback = 'N': idfin_income -> idfin_expense

            e se c'è il cap. di spesa dei lordi ci devono essere anche entrata dei lordi e pure spesa versamenti
            flagclawback = 'N': idfin_cost -- > idfin_income and idfin_expense. ora è cambiato 
            idfin_cost può fungere anche da versamento
         */

		private void btn03_Click(object sender, EventArgs e) {
			//3) Regola generale o specifica non determinata in righe riepilogo
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]),
				QHS.IsNull("idcsa_contractkind"));
			string sqlCmd = " SELECT ayear as 'Eserc.', " +
			                " idriep as 'Numero Riepilogo', " +
			                " yimport as 'Eserc. Import', " +
			                " nimport as 'Num. Import.', " +
			                " ruolocsa as 'Ruolo CSA', " +
			                " capitolocsa as 'Capitolo CSA', " +
			                " matricola as 'Matricola', " +
			                " importo as 'Importo', " +
			                " registry as 'Anagrafica', " +
			                " flagcr as 'Comp./Residui' " +
			                " FROM csa_importriepview " +
			                " WHERE  " + filter;


			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati(sender, e, T, "csa_importriep", "default", filter);
			}
		}


		private void btn01_Click(object sender, EventArgs e) {
			//1) Esercizio non valorizzato riepiloghi
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]),
				QHS.IsNull("ayear"));
			string sqlCmd = " SELECT ayear as 'Eserc.', " +
			                " idriep as 'Numero Riepilogo', " +
			                " yimport as 'Eserc. Import', " +
			                " nimport as 'Num. Import.', " +
			                " ruolocsa as 'Ruolo CSA', " +
			                " capitolocsa as 'Capitolo CSA', " +
			                " matricola as 'Matricola', " +
			                " importo as 'Importo', " +
			                " registry as 'Anagrafica', " +
			                " flagcr as 'Comp./Residui' " +
			                " FROM csa_importriepview " +
			                " WHERE  " + filter;


			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati(sender, e, T, "csa_importriep", "default", filter);
			}
		}

		private void btn05_Click(object sender, EventArgs e) {
			//--5) Recupero, Ritenuta o Contributo senza imputazione
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]),
				QHS.IsNull("idfin_cost"),
				QHS.IsNull("idexp_cost"),
				QHS.IsNull("idcsa_contractkinddata"),
				QHS.IsNull("idcsa_contracttax"),
				QHS.IsNull("idcsa_incomesetup"));
			string sqlCmd =
				" SELECT CASE flagclawback WHEN 'S' THEN 'Recupero' ELSE 'Ritenuta/Contributo' END as 'Tipo'," +
				" ayear as 'Eserc.', " +
				" idver as 'Numero Versamento', " +
				" yimport as 'Eserc. Import', " +
				" nimport as 'Num. Import.', " +
				" ruolocsa as 'Ruolo CSA', " +
				" capitolocsa as 'Capitolo CSA', " +
				" ente as 'Ente CSA', " +
				" vocecsa as 'Voce CSA', " +
				" matricola as 'Matricola', " +
				" importo as 'Importo', " +
				" registry as 'Anagrafica', " +
				" flagcr as 'Comp./Residui', " +
				" idcsa_contracttax as 'Conf. Contributi CSA - Regola specifica ', " +
				" idcsa_contractkinddata as 'Attribuzione da Regola generale CSA', " +
				" idcsa_incomesetup as 'Conf. Incassi'" +
				" FROM csa_importverview " +
				" WHERE  " + filter;


			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati(sender, e, T, "csa_importver", "default", filter);
			}
		}




		private void btn16_Click(object sender, EventArgs e) {
			// 16) Riepiloghi senza UPB , 
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = "";
			if (!usePartition) {
				filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]),
					QHS.IsNull("idupb"), QHS.IsNull("idexp"));

				string filter_ripartizione = " NOT EXISTS  (SELECT * FROM csa_contractexpense " +
				                             "  WHERE csa_importriepview.idcsa_contract = csa_contractexpense.idcsa_contract " +
				                             " 	AND csa_importriepview.ayear = csa_contractexpense.ayear)";

				filter = QHS.AppAnd(filter, filter_ripartizione);
			}
			else {
				filter = QHS.CmpEq("idcsa_import", Curr["idcsa_import"]);
				filter +=
					" and (not exists(select * from csa_importriep_partition CP where " +
					"  CP.idcsa_import = csa_importriepview.idcsa_import and " +
					"  CP.idriep = csa_importriepview.idriep " +
					"  )  OR " +
					" exists(select * from csa_importriep_partition CP where " +
					"  CP.idcsa_import = csa_importriepview.idcsa_import and " +
					"  CP.idriep = csa_importriepview.idriep and " +
					"  CP.idupb is null " +
					"  ))";
			}

			string sqlCmd = " SELECT ayear as 'Eserc.', " +
			                " idriep as 'Numero Riepilogo', " +
			                " yimport as 'Eserc. Import', " +
			                " nimport as 'Num. Import.', " +
			                " ruolocsa as 'Ruolo CSA', " +
			                " capitolocsa as 'Capitolo CSA', " +
			                " matricola as 'Matricola', " +
			                " importo as 'Importo', " +
			                " registry as 'Anagrafica', " +
			                " flagcr as 'Comp./Residui' " +
			                " FROM csa_importriepview " +
			                " WHERE  " + filter;

			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati2(sender, e, T, "csa_importriep", "csa_importriepview", "default",
					filter.Replace("csa_importriepview", "csa_importriep"), filter);
			}
		}



		private void btn77_Click(object sender, EventArgs e) {
			// 77) Riepiloghi senza capitolo , 
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = "";
			if (!usePartition) {
				filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]),
					QHS.IsNull("idupb"), QHS.IsNull("idexp"));

				string filter_ripartizione = " NOT EXISTS  (SELECT * FROM csa_contractexpense " +
				                             "  WHERE csa_importriepview.idcsa_contract = csa_contractexpense.idcsa_contract " +
				                             " 	AND csa_importriepview.ayear = csa_contractexpense.ayear)";

				filter = QHS.AppAnd(filter, filter_ripartizione);
			}
			else {
				filter = QHS.CmpEq("idcsa_import", Curr["idcsa_import"]);
				filter +=
					" and (not exists(select * from csa_importriep_partition CP where " +
					"  CP.idcsa_import = csa_importriepview.idcsa_import and " +
					"  CP.idriep = csa_importriepview.idriep " +
					"  )  OR " +
					" exists(select * from csa_importriep_partition CP where " +
					"  CP.idcsa_import = csa_importriepview.idcsa_import and " +
					"  CP.idriep = csa_importriepview.idriep and " +
					"  CP.idfin is null " +
					"  ))";
			}

			string sqlCmd = " SELECT ayear as 'Eserc.', " +
			                " idriep as 'Numero Riepilogo', " +
			                " yimport as 'Eserc. Import', " +
			                " nimport as 'Num. Import.', " +
			                " ruolocsa as 'Ruolo CSA', " +
			                " capitolocsa as 'Capitolo CSA', " +
			                " matricola as 'Matricola', " +
			                " importo as 'Importo', " +
			                " registry as 'Anagrafica', " +
			                " flagcr as 'Comp./Residui' " +
			                " FROM csa_importriepview " +
			                " WHERE  " + filter;

			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati2(sender, e, T, "csa_importriep", "csa_importriepview", "default",
					filter.Replace("csa_importriepview", "csa_importriep"), filter);
			}
		}


		private void btn78_Click(object sender, EventArgs e) {
			// 78) Versamenti con Anagrafiche Enti che non hanno il tipo trattamento spese nella modalità di pagamento predefinita
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]),
				QHS.IsNotNull("idreg_agency"), QHS.IsNull("idcsa_agencypaymethod"));

			filter = QHS.AppAnd(filter,
				" NOT EXISTS(SELECT * FROM registrypaymethod  RGP WHERE RGP.idreg = csa_importverview.idreg_agency AND RGP.flagstandard = 'S' AND RGP.idchargehandling IS NOT NULL " +
				") ");
			filter = QHS.AppAnd(filter, " (ISNULL(csa_agency.flag, 0)&2) <> 0 "); /*_agency_not_use_nbill*/

			string sqlCmd =
				" SELECT CASE flagclawback WHEN 'S' THEN 'Recupero' ELSE 'Ritenuta/Contributo' END as 'Tipo'," +
				" ayear as 'Eserc.', " +
				" idver as 'Numero Versamento', " +
				" yimport as 'Eserc. Import', " +
				" nimport as 'Num. Import.', " +
				" ruolocsa as 'Ruolo CSA', " +
				" capitolocsa as 'Capitolo CSA', " +
				" csa_importverview.ente as 'Ente CSA', " +
				" csa_importverview.vocecsa as 'Voce CSA', " +
				" matricola as 'Matricola', " +
				" importo as 'Importo', " +
				" registry_agency as 'Anagrafica Ente', " +
				" agency as 'Ente', " +
				" csa_importverview.idcsa_agencypaymethod as ' # Mod. Pagamento Ente', " +
				" codefin_cost as 'Cod. Capitolo Costo'," +
				" codefin_income as 'Cod. Capitolo Entrata'," +
				" codefin_expense as 'Cod. Capitolo Spesa'," +
				" codefin_incomeclawback as 'Cod. Capitolo Entrata Interno'," +
				" flagcr as 'Comp./Residui' " +
				" FROM csa_importverview " +
				" JOIN csa_agency " +
				" ON csa_agency.idcsa_agency = csa_importverview.idcsa_agency " +
				" WHERE  " + filter;


			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati2(sender, e, T, "csa_importver", "csa_importverview", "default",
					filter, filter);
			}
		}



		private void btn79_Click(object sender, EventArgs e) {
			// 79) Versamenti con Anagrafiche Enti che non hanno il tipo trattamento spese nella modalità di pagamento specifica congurata
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]),
				QHS.IsNotNull("idreg_agency"), QHS.IsNotNull("csa_importverview.idcsa_agencypaymethod"));

			filter = QHS.AppAnd(filter,
				" NOT EXISTS(SELECT * FROM registrypaymethod  RGP WHERE RGP.idreg = csa_importverview.idreg_agency " +
				" AND RGP.idregistrypaymethod = csa_agencypaymethod.idregistrypaymethod AND RGP.idchargehandling IS NOT NULL " +
				") ");
			filter = QHS.AppAnd(filter, " (ISNULL(csa_agency.flag, 0)&2) <> 0 "); // /*_agency_not_use_nbill*/

			string sqlCmd =
				" SELECT CASE flagclawback WHEN 'S' THEN 'Recupero' ELSE 'Ritenuta/Contributo' END as 'Tipo'," +
				" ayear as 'Eserc.', " +
				" idver as 'Numero Versamento', " +
				" yimport as 'Eserc. Import', " +
				" nimport as 'Num. Import.', " +
				" ruolocsa as 'Ruolo CSA', " +
				" capitolocsa as 'Capitolo CSA', " +
				" csa_importverview.ente as 'Ente CSA', " +
				" csa_importverview.vocecsa as 'Voce CSA', " +
				" matricola as 'Matricola', " +
				" importo as 'Importo', " +
				" registry_agency as 'Anagrafica Ente', " +
				" agency as 'Ente', " +
				" csa_importverview.idcsa_agencypaymethod as ' # Mod. Pagamento Ente', " +
				" codefin_cost as 'Cod. Capitolo Costo'," +
				" codefin_income as 'Cod. Capitolo Entrata'," +
				" codefin_expense as 'Cod. Capitolo Spesa'," +
				" codefin_incomeclawback as 'Cod. Capitolo Entrata Interno'," +
				" flagcr as 'Comp./Residui' " +
				" FROM csa_importverview " +
				" JOIN csa_agency " +
				" ON csa_agency.idcsa_agency = csa_importverview.idcsa_agency " +
				" JOIN csa_agencypaymethod " +
				" ON csa_agencypaymethod.idcsa_agency = csa_importverview.idcsa_agency " +
				" AND csa_agencypaymethod.idcsa_agencypaymethod = csa_importverview.idcsa_agencypaymethod " +
				" WHERE  " + filter;


			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati2(sender, e, T, "csa_importver", "csa_importverview", "default",
					filter, filter);
			}
		}

		private void btn17_Click(object sender, EventArgs e) {
			//17) Upb non presente sulle righe di versamento per recuperi non figurativi
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]),
				QHS.CmpEq("flagclawback", "S"),
				QHS.IsNull("idcsa_contractkinddata"),
				QHS.IsNull("idcsa_contracttax"),
				QHS.IsNotNull("idcsa_incomesetup"),
				QHS.IsNull("idupb"));
			if (usePartition) {
				string filter_partition = " AND ( NOT EXISTS(select * from  csa_importver_partition CP  where " +
				                          QHS.AppAnd(
					                          QHS.CmpEq("CP.idcsa_import", QHS.Field("csa_importverview.idcsa_import")),
					                          QHS.CmpEq("CP.idver", QHS.Field("csa_importverview.idver"))
				                          ) + ")";

				filter_partition += " OR ( EXISTS(select * from  csa_importver_partition CP  where " +
				                    QHS.AppAnd(
					                    QHS.CmpEq("CP.idcsa_import", QHS.Field("csa_importverview.idcsa_import")),
					                    QHS.CmpEq("CP.idver", QHS.Field("csa_importverview.idver")),
					                    QHS.IsNull("CP.idupb")
				                    ) + ")))";
				filter += filter_partition;
			}

			string sqlCmd =
				" SELECT CASE flagclawback WHEN 'S' THEN 'Recupero' ELSE 'Ritenuta/Contributo' END as 'Tipo'," +
				" ayear as 'Eserc.', " +
				" idver as 'Numero Versamento', " +
				" yimport as 'Eserc. Import', " +
				" nimport as 'Num. Import.', " +
				" ruolocsa as 'Ruolo CSA', " +
				" capitolocsa as 'Capitolo CSA', " +
				" ente as 'Ente CSA', " +
				" vocecsa as 'Voce CSA', " +
				" matricola as 'Matricola', " +
				" importo as 'Importo', " +
				" registry as 'Anagrafica', " +
				" flagcr as 'Comp./Residui', " +
				" idcsa_contracttax as 'Conf. Contributi CSA - Regola specifica', " +
				" idcsa_contractkinddata as 'Attribuzione da Regola generale CSA', " +
				" idcsa_incomesetup as 'Conf. Incassi'" +
				" FROM csa_importverview " +
				" WHERE  " + filter;

			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati(sender, e, T, "csa_importver", "default", filter);
			}
		}



		private void btn18_Click(object sender, EventArgs e) {
			// 18)   Verifica upb non presente sulle righe di versamento per contributi non figurativi

			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]),
				QHS.CmpEq("flagclawback", "N"),
				QHS.DoPar(QHS.AppOr(
					QHS.IsNotNull("idcsa_contractkinddata"),
					QHS.IsNotNull("idcsa_contracttax"))
				),
				//QHS.IsNotNull("idcsa_incomesetup"),
				QHS.IsNull("idupb"), QHS.IsNull("idexp_cost"));
			string filter_ripartizione = " NOT EXISTS  (SELECT * FROM csa_contracttaxexpense " +
			                             " WHERE csa_importverview.idcsa_contract = csa_contracttaxexpense.idcsa_contract " +
			                             "	AND csa_importverview.idcsa_contracttax = csa_contracttaxexpense.idcsa_contracttax " +
			                             "	AND csa_importverview.ayear = csa_contracttaxexpense.ayear)";

			filter = QHS.AppAnd(filter, filter_ripartizione);

			string sqlCmd =
				" SELECT CASE flagclawback WHEN 'S' THEN 'Recupero' ELSE 'Ritenuta/Contributo' END as 'Tipo'," +
				" ayear as 'Eserc.', " +
				" idver as 'Numero Versamento', " +
				" yimport as 'Eserc. Import', " +
				" nimport as 'Num. Import.', " +
				" ruolocsa as 'Ruolo CSA', " +
				" capitolocsa as 'Capitolo CSA', " +
				" ente as 'Ente CSA', " +
				" vocecsa as 'Voce CSA', " +
				" matricola as 'Matricola', " +
				" importo as 'Importo', " +
				" registry as 'Anagrafica', " +
				" flagcr as 'Comp./Residui', " +
				" idcsa_contracttax as 'Conf. Contributi CSA - Regola specifica', " +
				" idcsa_contractkinddata as 'Attribuzione da Regola generale CSA', " +
				" idcsa_incomesetup as 'Conf. Incassi'" +
				" FROM csa_importverview " +
				" WHERE  " + filter;

			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati2(sender, e, T, "csa_importver", "csa_importverview", "default",
					filter, filter);
			}
		}

		// 19)  Verifica upb non presente sulle righe di versamento per RITENUTE,errato, i movimenti relativi alle ritenute vanno su 0001
		private void btn19_Click(object sender, EventArgs e) {
			/*
            if (Meta.IsEmpty) return;
            DataRow Curr = DS.csa_import.Rows[0];
            string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]),
                                       QHS.CmpEq("flagclawback", "N"),
                                       QHS.IsNull("idcsa_contractkinddata"),
                                       QHS.IsNull("idcsa_contracttax") ,
                                       QHS.IsNotNull("idcsa_incomesetup"),
                                       QHS.IsNull("idupb"));
            string sqlCmd = " SELECT CASE flagclawback WHEN 'S' THEN 'Recupero' ELSE 'Ritenuta/Contributo' END as 'Tipo'," +
                            " ayear as 'Eserc.', " +
                            " idver as 'Numero Versamento', " +
                            " yimport as 'Eserc. Import', " +
                            " nimport as 'Num. Import.', " +
                            " ruolocsa as 'Ruolo CSA', " +
                            " capitolocsa as 'Capitolo CSA', " +
                            " ente as 'Ente CSA', " +
                            " vocecsa as 'Voce CSA', " +
                            " matricola as 'Matricola', " +
                            " importo as 'Importo', " +
                            " registry as 'Anagrafica', " +
                            " flagcr as 'Comp./Residui', " +
                            " idcsa_contracttax as 'Conf. Contributi CSA - Regola specifica', " +
                            " idcsa_contractkinddata as 'Attribuzione da Regola generale CSA', " +
                            " idcsa_incomesetup as 'Conf. Incassi'" +
                            " FROM csa_importverview " +
                            " WHERE  " + filter;

            DataTable T = Conn.SQLRunner(sqlCmd);

            if (T != null)
            {
                VisualizzaDati(sender, e, T, "csa_importver", "default", filter);
            }
             */
		}


		private void btn06_Click(object sender, EventArgs e) {
			// 6) Versamenti con Ente o Anagrafica Ente non valorizzati
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]),
				QHS.DoPar(QHS.AppOr(QHS.IsNull("idcsa_agency"), QHS.NullOrEq("idreg_agency", 0))));
			string sqlCmd =
				" SELECT CASE flagclawback WHEN 'S' THEN 'Recupero' ELSE 'Ritenuta/Contributo' END as 'Tipo'," +
				" ayear as 'Eserc.', " +
				" idver as 'Numero Versamento', " +
				" yimport as 'Eserc. Import', " +
				" nimport as 'Num. Import.', " +
				" ruolocsa as 'Ruolo CSA', " +
				" capitolocsa as 'Capitolo CSA', " +
				" ente as 'Ente CSA', " +
				" vocecsa as 'Voce CSA', " +
				" matricola as 'Matricola', " +
				" importo as 'Importo', " +
				" registry as 'Anagrafica', " +
				" agency as 'Ente', " +
				" idcsa_agencypaymethod as ' # Mod. Pagamento Ente', " +
				" flagcr as 'Comp./Residui' " +
				" FROM csa_importverview " +
				" WHERE  " + filter;

			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati(sender, e, T, "csa_importver", "default", filter);
			}
		}

		private void btn07_Click(object sender, EventArgs e) {
			//7) Recupero Senza Capitolo di Entrata Lordi  idfin_incomeclawback
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			//object flagdirectcsaclawback = Get_Flag_Direct_Revenue_CSA();
			string filterBilancioEntrata = null;

			// Nella nuova gestione i recuperi non saranno più su partite di giro, saranno invece tutti diretti
			// Se recupero diretto, capitolo entrata interno OR
			// Se recupero su partita di giro, capitolo entrata della reversale
			// filtra direttamente la configurazione dell'esercizio corrente

			if (!usePartition) {
				filterBilancioEntrata = QHS.AppAnd(QHS.CmpEq("flagdirectcsaclawback", "N"), QHS.IsNull("idfin_income"));

				filterBilancioEntrata = QHS.AppOr(filterBilancioEntrata,
					QHS.DoPar(QHS.AppAnd(QHS.CmpEq("flagdirectcsaclawback", "S"), QHS.IsNull("idfin_incomeclawback"))));
			}
			else {
				filterBilancioEntrata = QHS.IsNull("idfin_incomeclawback");
			}

			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]),
				QHS.CmpEq("flagclawback", "S"),
				filterBilancioEntrata);

			string sqlCmd =
				" SELECT CASE flagclawback WHEN 'S' THEN 'Recupero' ELSE 'Ritenuta/Contributo' END as 'Tipo'," +
				" ayear as 'Eserc.', " +
				" idver as 'Numero Versamento', " +
				" yimport as 'Eserc. Import', " +
				" nimport as 'Num. Import.', " +
				" ruolocsa as 'Ruolo CSA', " +
				" capitolocsa as 'Capitolo CSA', " +
				" ente as 'Ente CSA', " +
				" vocecsa as 'Voce CSA', " +
				" matricola as 'Matricola', " +
				" importo as 'Importo', " +
				" registry as 'Anagrafica', " +
				" agency as 'Ente', " +
				" idcsa_agencypaymethod as ' # Mod. Pagamento Ente', " +
				" flagcr as 'Comp./Residui', " +
				" codefin_income as 'Cap. Entrata Recupero'," +
				" codefin_incomeclawback as 'Cap. Entrata Recupero Diretto'" +
				" FROM csa_importverview " +
				" WHERE  " + filter;

			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati(sender, e, T, "csa_importver", "default", filter);
			}
		}

		private void btn82_Click(object sender, EventArgs e) {
			// SIOPE Speculare al 7
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			//object flagdirectcsaclawback = Get_Flag_Direct_Revenue_CSA();
			string filterBilancioEntrata = null;

			filterBilancioEntrata = QHS.AppAnd(QHS.IsNull("idsor_siope_incomeclawback"), QHS.IsNotNull("idfin_incomeclawback"));
			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]),
				QHS.CmpEq("flagclawback", "S"),
				filterBilancioEntrata);

			string sqlCmd =
				" SELECT CASE flagclawback WHEN 'S' THEN 'Recupero' ELSE 'Ritenuta/Contributo' END as 'Tipo'," +
				" ayear as 'Eserc.', " +
				" idver as 'Numero Versamento', " +
				" yimport as 'Eserc. Import', " +
				" nimport as 'Num. Import.', " +
				" ruolocsa as 'Ruolo CSA', " +
				" capitolocsa as 'Capitolo CSA', " +
				" ente as 'Ente CSA', " +
				" vocecsa as 'Voce CSA', " +
				" matricola as 'Matricola', " +
				" importo as 'Importo', " +
				" registry as 'Anagrafica', " +
				" agency as 'Ente', " +
				" idcsa_agencypaymethod as ' # Mod. Pagamento Ente', " +
				" flagcr as 'Comp./Residui', " +
				" codefin_income as 'Cap. Entrata Recupero'," +
				" codefin_incomeclawback as 'Cap. Entrata Recupero Diretto'" +
				" FROM csa_importverview " +
				" WHERE  " + filter;

			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati(sender, e, T, "csa_importver", "default", filter);
			}
		}
		private void btn08_Click(object sender, EventArgs e) {
			//8) Recupero su partita di giro: idfin_expense-- > idfin_income e viceversa
			if (Meta.IsEmpty) return;

			if (usePartition) return; //con l'uso delle ripartizioni non abbiamo piu' i recuperi su partite di giro
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]),
				QHS.CmpEq("flagclawback", "S"), QHS.CmpEq("flagdirectcsaclawback", "N"),
				QHS.DoPar(QHS.AppOr(QHS.DoPar(QHS.AppAnd(QHS.IsNull("idfin_expense"),
						QHS.IsNotNull("idfin_income"))),
					QHS.DoPar(QHS.AppAnd(QHS.IsNull("idfin_income"),
						QHS.IsNotNull("idfin_expense")))))
			);

			string sqlCmd =
				" SELECT CASE flagclawback WHEN 'S' THEN 'Recupero' ELSE 'Ritenuta/Contributo' END as 'Tipo'," +
				" ayear as 'Eserc.', " +
				" idver as 'Numero Versamento', " +
				" yimport as 'Eserc. Import', " +
				" nimport as 'Num. Import.', " +
				" ruolocsa as 'Ruolo CSA', " +
				" capitolocsa as 'Capitolo CSA', " +
				" ente as 'Ente CSA', " +
				" vocecsa as 'Voce CSA', " +
				" matricola as 'Matricola', " +
				" importo as 'Importo', " +
				" registry as 'Anagrafica', " +
				" agency as 'Ente', " +
				" idcsa_agencypaymethod as ' # Mod. Pagamento Ente', " +
				" codefin_cost as 'Cod. Capitolo Costo'," +
				" codefin_income as 'Cod. Capitolo Entrata'," +
				" codefin_expense as 'Cod. Capitolo Spesa'," +
				" codefin_incomeclawback as 'Cod. Capitolo Entrata Interno'," +
				" flagcr as 'Comp./Residui' " +
				" FROM csa_importverview " +
				" WHERE  " + filter;


			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati(sender, e, T, "csa_importver", "default", filter);
			}
		}

		private void btn11_Click(object sender, EventArgs e) {
			//11) Contributi senza Capitolo di Costo  ,   
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]),
				QHS.DoPar(QHS.AppOr(QHS.IsNotNull("idcsa_contractkinddata"), QHS.IsNotNull("idcsa_contracttax"))),
				QHS.NullOrEq("flagclawback", "N"));

			if (!usePartition) {
				filter = QHS.AppAnd(filter, QHS.IsNull("idfin_cost"), QHS.IsNull("idexp_cost"),
					QHS.IsNull("idfin_expense")
				);
				filter += " AND NOT EXISTS(select * from csa_contracttaxexpense CE where " +
				          QHS.AppAnd(QHS.CmpEq("CE.idcsa_contract", QHS.Field("csa_importverview.idcsa_contract")),
					          QHS.CmpEq("CE.idcsa_contracttax", QHS.Field("csa_importverview.idcsa_contracttax")),
					          QHS.CmpEq("CE.ayear", Conn.GetSys("esercizio"))
				          )
				          + ")";
			}
			else {
				string filter_partition = " AND ( NOT EXISTS(select * from  csa_importver_partition CP  where " +
				                          QHS.AppAnd(
					                          QHS.CmpEq("CP.idcsa_import", QHS.Field("csa_importverview.idcsa_import")),
					                          QHS.CmpEq("CP.idver", QHS.Field("csa_importverview.idver"))
				                          ) + ")";

				filter_partition += " OR ( EXISTS(select * from  csa_importver_partition CP  where " +
				                    QHS.AppAnd(
					                    QHS.CmpEq("CP.idcsa_import", QHS.Field("csa_importverview.idcsa_import")),
					                    QHS.CmpEq("CP.idver", QHS.Field("csa_importverview.idver")),
					                    QHS.DoPar(QHS.AppOr(QHS.IsNull("CP.idfin"), QHS.IsNull("CP.idupb")))
				                    ) + ")))";
				filter += filter_partition;
			}


			string sqlCmd =
				" SELECT CASE flagclawback WHEN 'S' THEN 'Recupero' ELSE 'Ritenuta/Contributo' END as 'Tipo'," +
				" ayear as 'Eserc.', " +
				" idver as 'Numero Versamento', " +
				" yimport as 'Eserc. Import', " +
				" nimport as 'Num. Import.', " +
				" ruolocsa as 'Ruolo CSA', " +
				" capitolocsa as 'Capitolo CSA', " +
				" ente as 'Ente CSA', " +
				" vocecsa as 'Voce CSA', " +
				" matricola as 'Matricola', " +
				" importo as 'Importo', " +
				" registry as 'Anagrafica', " +
				" agency as 'Ente', " +
				" idcsa_agencypaymethod as ' # Mod. Pagamento Ente', " +
				" codefin_cost as 'Cod. Capitolo Costo'," +
				" codefin_income as 'Cod. Capitolo Entrata'," +
				" codefin_expense as 'Cod. Capitolo Spesa'," +
				" codefin_incomeclawback as 'Cod. Capitolo Entrata Interno'," +
				" flagcr as 'Comp./Residui' " +
				" FROM csa_importverview " +
				" WHERE  " + filter;


			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati2(sender, e, T, "csa_importver", "csa_importverview", "default",
					filter, filter);
			}
		}

		private void btn84_Click(object sender, EventArgs e) {
			//SIOPE Speculare a 11
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]),
				QHS.DoPar(QHS.AppOr(QHS.IsNotNull("idcsa_contractkinddata"), QHS.IsNotNull("idcsa_contracttax"))),
				QHS.NullOrEq("flagclawback", "N"));

			if (!usePartition) {
				filter = QHS.AppAnd(filter, QHS.IsNull("idfin_cost"), QHS.IsNull("idexp_cost"),
					QHS.IsNull("idfin_expense")
				);
				filter += " AND NOT EXISTS(select * from csa_contracttaxexpense CE where " +
						  QHS.AppAnd(QHS.CmpEq("CE.idcsa_contract", QHS.Field("csa_importverview.idcsa_contract")),
							  QHS.CmpEq("CE.idcsa_contracttax", QHS.Field("csa_importverview.idcsa_contracttax")),
							  QHS.CmpEq("CE.ayear", Conn.GetSys("esercizio"))
						  )
						  + ")";
			}
			else {
				string filter_partition = " AND ( NOT EXISTS(select * from  csa_importver_partition CP  where " +
										  QHS.AppAnd(
											  QHS.CmpEq("CP.idcsa_import", QHS.Field("csa_importverview.idcsa_import")),
											  QHS.CmpEq("CP.idver", QHS.Field("csa_importverview.idver"))
										  ) + ")";

				filter_partition += " OR ( EXISTS(select * from  csa_importver_partition CP  where " +
									QHS.AppAnd(
										QHS.CmpEq("CP.idcsa_import", QHS.Field("csa_importverview.idcsa_import")),
										QHS.CmpEq("CP.idver", QHS.Field("csa_importverview.idver")),
										QHS.IsNull("idsor_siope"),
										QHS.DoPar(QHS.AppOr(QHS.IsNotNull("CP.idfin"), QHS.IsNotNull("CP.idexp")))
									) + ")))";
				filter += filter_partition;
			}


			string sqlCmd =
				" SELECT CASE flagclawback WHEN 'S' THEN 'Recupero' ELSE 'Ritenuta/Contributo' END as 'Tipo'," +
				" ayear as 'Eserc.', " +
				" idver as 'Numero Versamento', " +
				" yimport as 'Eserc. Import', " +
				" nimport as 'Num. Import.', " +
				" ruolocsa as 'Ruolo CSA', " +
				" capitolocsa as 'Capitolo CSA', " +
				" ente as 'Ente CSA', " +
				" vocecsa as 'Voce CSA', " +
				" matricola as 'Matricola', " +
				" importo as 'Importo', " +
				" registry as 'Anagrafica', " +
				" agency as 'Ente', " +
				" idcsa_agencypaymethod as ' # Mod. Pagamento Ente', " +
				" codefin_cost as 'Cod. Capitolo Costo'," +
				" codefin_income as 'Cod. Capitolo Entrata'," +
				" codefin_expense as 'Cod. Capitolo Spesa'," +
				" codefin_incomeclawback as 'Cod. Capitolo Entrata Interno'," +
				" flagcr as 'Comp./Residui' " +
				" FROM csa_importverview " +
				" WHERE  " + filter;


			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati2(sender, e, T, "csa_importver", "csa_importverview", "default",
					filter, filter);
			}
		}



		private void btn85_Click(object sender, EventArgs e) {
			//1) Anagrafica non valorizzata in riepiloghi
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]),
				QHS.DoPar(QHS.AppOr(QHS.IsNull("idreg"),QHS.CmpEq("idreg", 0))));
			string sqlCmd = " SELECT ayear as 'Eserc.', " +
			                " idriep as 'Numero Riepilogo', " +
			                " yimport as 'Eserc. Import', " +
			                " nimport as 'Num. Import.', " +
			                " ruolocsa as 'Ruolo CSA', " +
			                " capitolocsa as 'Capitolo CSA', " +
			                " matricola as 'Matricola', " +
			                " importo as 'Importo', " +
			                " registry as 'Anagrafica', " +
			                " flagcr as 'Comp./Residui' " +
			                " FROM csa_importriepview " +
			                " WHERE  " + filter +" order by matricola ";


			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati(sender, e, T, "csa_importriep", "default", filter);
			}
		}

		private void btn86_Click(object sender, EventArgs e) {
			//1) Anagrafica non valorizzata in riepiloghi
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.CmpEq("idcsa_import", Curr["idcsa_import"]);

			filter = QHS.AppAnd(filter, "NOT EXISTS(select * from registrypaymethod where registrypaymethod.idreg =  csa_importriepview.idreg" +
										" AND ISNULL(active, 'S') = 'S'" +
										" AND ISNULL(flagstandard, 'N') = 'S')");

			string sqlCmd = " SELECT ayear as 'Eserc.', " +
							" idriep as 'Numero Riepilogo', " +
							" yimport as 'Eserc. Import', " +
							" nimport as 'Num. Import.', " +
							" ruolocsa as 'Ruolo CSA', " +
							" capitolocsa as 'Capitolo CSA', " +
							" matricola as 'Matricola', " +
							" importo as 'Importo', " +
							" registry as 'Anagrafica', " +
							" flagcr as 'Comp./Residui', " +
							" idreg as 'Codice Anagrafica' " +
							" FROM csa_importriepview " +
							" WHERE " + filter + " order by matricola ";


			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati(sender, e, T, "csa_importriep", "default", filter);
			}
		}


		private void btn12_Click(object sender, EventArgs e) {
			//12)  Ritenuta : idfin_expense --> idfin_income
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]),
				QHS.NullOrEq("flagclawback", "N"),
				QHS.IsNull("idfin_income"),
				QHS.IsNotNull("idfin_expense"));

			string sqlCmd =
				" SELECT CASE flagclawback WHEN 'S' THEN 'Recupero' ELSE 'Ritenuta/Contributo' END as 'Tipo'," +
				" ayear as 'Eserc.', " +
				" idver as 'Numero Versamento', " +
				" yimport as 'Eserc. Import', " +
				" nimport as 'Num. Import.', " +
				" ruolocsa as 'Ruolo CSA', " +
				" capitolocsa as 'Capitolo CSA', " +
				" ente as 'Ente CSA', " +
				" vocecsa as 'Voce CSA', " +
				" matricola as 'Matricola', " +
				" importo as 'Importo', " +
				" registry as 'Anagrafica', " +
				" agency as 'Ente', " +
				" idcsa_agencypaymethod as ' # Mod. Pagamento Ente', " +
				" codefin_cost as 'Cod. Capitolo Costo'," +
				" codefin_income as 'Cod. Capitolo Entrata'," +
				" codefin_expense as 'Cod. Capitolo Spesa'," +
				" codefin_incomeclawback as 'Cod. Capitolo Entrata Interno'," +
				" flagcr as 'Comp./Residui' " +
				" FROM csa_importverview " +
				" WHERE  " + filter;

			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati(sender, e, T, "csa_importver", "default", filter);
			}
		}

		private void btn80_Click(object sender, EventArgs e) {
			// Specula al Check 12
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]),
				QHS.NullOrEq("flagclawback", "N"),
				QHS.IsNull("idsor_siope_expense"),
				QHS.IsNotNull("idfin_expense"));

			string sqlCmd =
				" SELECT CASE flagclawback WHEN 'S' THEN 'Recupero' ELSE 'Ritenuta/Contributo' END as 'Tipo'," +
				" ayear as 'Eserc.', " +
				" idver as 'Numero Versamento', " +
				" yimport as 'Eserc. Import', " +
				" nimport as 'Num. Import.', " +
				" ruolocsa as 'Ruolo CSA', " +
				" capitolocsa as 'Capitolo CSA', " +
				" ente as 'Ente CSA', " +
				" vocecsa as 'Voce CSA', " +
				" matricola as 'Matricola', " +
				" importo as 'Importo', " +
				" registry as 'Anagrafica', " +
				" agency as 'Ente', " +
				" idcsa_agencypaymethod as ' # Mod. Pagamento Ente', " +
				" codefin_cost as 'Cod. Capitolo Costo'," +
				" codefin_income as 'Cod. Capitolo Entrata'," +
				" codefin_expense as 'Cod. Capitolo Spesa'," +
				" codefin_incomeclawback as 'Cod. Capitolo Entrata Interno'," +
				" flagcr as 'Comp./Residui' " +
				" FROM csa_importverview " +
				" WHERE  " + filter;

			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati(sender, e, T, "csa_importver", "default", filter);
			}
		}
		private void btn13_Click(object sender, EventArgs e) {
			//13)  Ritenuta: idfin_income --> idfin_expense
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]),
				QHS.NullOrEq("flagclawback", "N"),
				QHS.IsNotNull("idfin_income"),
				QHS.IsNull("idfin_expense"));

			string sqlCmd =
				" SELECT CASE flagclawback WHEN 'S' THEN 'Recupero' ELSE 'Ritenuta/Contributo' END as 'Tipo'," +
				" ayear as 'Eserc.', " +
				" idver as 'Numero Versamento', " +
				" yimport as 'Eserc. Import', " +
				" nimport as 'Num. Import.', " +
				" ruolocsa as 'Ruolo CSA', " +
				" capitolocsa as 'Capitolo CSA', " +
				" ente as 'Ente CSA', " +
				" vocecsa as 'Voce CSA', " +
				" matricola as 'Matricola', " +
				" importo as 'Importo', " +
				" registry as 'Anagrafica', " +
				" agency as 'Ente', " +
				" idcsa_agencypaymethod as ' # Mod. Pagamento Ente', " +
				" codefin_cost as 'Cod. Capitolo Costo'," +
				" codefin_income as 'Cod. Capitolo Entrata'," +
				" codefin_expense as 'Cod. Capitolo Spesa'," +
				" codefin_incomeclawback as 'Cod. Capitolo Entrata Interno'," +
				" flagcr as 'Comp./Residui' " +
				" FROM csa_importverview " +
				" WHERE  " + filter;

			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati(sender, e, T, "csa_importver", "default", filter);
			}
		}

		private void btn81_Click(object sender, EventArgs e) {
			// SIOPE - speculare a 13
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]),
				QHS.NullOrEq("flagclawback", "N"),
				QHS.IsNotNull("idfin_income"),
				QHS.IsNull("idsor_siope_income"));

			string sqlCmd =
				" SELECT CASE flagclawback WHEN 'S' THEN 'Recupero' ELSE 'Ritenuta/Contributo' END as 'Tipo'," +
				" ayear as 'Eserc.', " +
				" idver as 'Numero Versamento', " +
				" yimport as 'Eserc. Import', " +
				" nimport as 'Num. Import.', " +
				" ruolocsa as 'Ruolo CSA', " +
				" capitolocsa as 'Capitolo CSA', " +
				" ente as 'Ente CSA', " +
				" vocecsa as 'Voce CSA', " +
				" matricola as 'Matricola', " +
				" importo as 'Importo', " +
				" registry as 'Anagrafica', " +
				" agency as 'Ente', " +
				" idcsa_agencypaymethod as ' # Mod. Pagamento Ente', " +
				" codefin_cost as 'Cod. Capitolo Costo'," +
				" codefin_income as 'Cod. Capitolo Entrata'," +
				" codefin_expense as 'Cod. Capitolo Spesa'," +
				" codefin_incomeclawback as 'Cod. Capitolo Entrata Interno'," +
				" flagcr as 'Comp./Residui' " +
				" FROM csa_importverview " +
				" WHERE  " + filter;

			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati(sender, e, T, "csa_importver", "default", filter);
			}
		}
		object _myreg_CSA = null;

		/// <summary>
		/// Ottiene l'anagrafica per le importazioni csa  da config
		/// </summary>
		/// <returns></returns>
		private object Get_Registry_Csa() {
			if (Meta.IsEmpty) return DBNull.Value;
			if (_myreg_CSA != null)
				return _myreg_CSA;
			object esercizio = Meta.GetSys("esercizio");
			string filter = QHS.CmpEq("ayear", Conn.GetSys("esercizio"));
			DataTable t = Conn.RUN_SELECT("config", "*", null, filter, null, null, true);
			if (t == null) return DBNull.Value;
			if (t.Rows.Count == 0) return DBNull.Value;
			DataRow rConfig = t.Rows[0];
			_myreg_CSA = rConfig["idreg_csa"];
			return rConfig["idreg_csa"];
		}

		object _myRegistry_Auto = null;

		/// <summary>
		/// Ottiene l'anagrafica per le partite di giro
		/// </summary>
		/// <returns></returns>
		private object Get_Registry_Auto() {
			if (Meta.IsEmpty) return DBNull.Value;
			if (_myRegistry_Auto != null)
				return _myRegistry_Auto;
			_myRegistry_Auto = DBNull.Value;
			object esercizio = Meta.GetSys("esercizio");
			string filter = QHS.CmpEq("ayear", Conn.GetSys("esercizio"));
			DataTable t = Conn.RUN_SELECT("config", "*", null, filter, null, null, true);
			if (t == null) return DBNull.Value;
			if (t.Rows.Count == 0) return DBNull.Value;
			DataRow rConfig = t.Rows[0];
			_myRegistry_Auto = rConfig["idregauto"];
			return rConfig["idregauto"];
		}

		object _myFlagLinkToExp = null;

		/// <summary>
		/// Verifica se bisogna collegare le reversali delle ritenute ai movimenti di spesa dei lordi
		/// </summary>
		/// <returns></returns>
		private object Get_FlagLinkToExp() {
			if (Meta.IsEmpty) return DBNull.Value;
			if (_myFlagLinkToExp != null)
				return _myFlagLinkToExp;
			object esercizio = Meta.GetSys("esercizio");
			string filter = QHS.CmpEq("ayear", Conn.GetSys("esercizio"));
			DataTable t = Conn.RUN_SELECT("config", "*", null, filter, null, null, true);
			if (t == null) return DBNull.Value;
			if (t.Rows.Count == 0) return DBNull.Value;
			DataRow rConfig = t.Rows[0];
			if (rConfig["csa_flaglinktoexp"] == DBNull.Value)
				_myFlagLinkToExp = "N";
			else
				_myFlagLinkToExp = rConfig["csa_flaglinktoexp"];
			return _myFlagLinkToExp;
		}

		object _myFlagBalanceCSA = null;

		/// <summary>
		/// Verifica se bisogna collegare le reversali delle ritenute ai movimenti di spesa dei lordi
		/// </summary>
		/// <returns></returns>
		private object Get_FlagBalanceCSA() {
			if (Meta.IsEmpty) return DBNull.Value;
			if (_myFlagBalanceCSA != null)
				return _myFlagBalanceCSA;
			object esercizio = Meta.GetSys("esercizio");
			string filter = QHS.CmpEq("ayear", Conn.GetSys("esercizio"));
			DataTable t = Conn.RUN_SELECT("config", "*", null, filter, null, null, true);
			if (t == null) return DBNull.Value;
			if (t.Rows.Count == 0) return DBNull.Value;
			DataRow rConfig = t.Rows[0];
			if (rConfig["flagbalance_csa"] == DBNull.Value)
				_myFlagBalanceCSA = "N";

			_myFlagBalanceCSA = rConfig["flagbalance_csa"];
			return _myFlagBalanceCSA;
		}

		object __myAccount_Revenue_CSA = null;

		/// <summary>
		/// prende idacc_revenue_gross_csa da config
		/// </summary>
		/// <returns></returns>
		private object Get_Account_Revenue_CSA() {
			// conto ricavo standard per la gestione dei riepiloghi negativi
			if (Meta.IsEmpty) return DBNull.Value;
			if (__myAccount_Revenue_CSA != null)
				return __myAccount_Revenue_CSA;
			object esercizio = Meta.GetSys("esercizio");
			string filter = QHS.CmpEq("ayear", Conn.GetSys("esercizio"));
			DataTable t = Conn.RUN_SELECT("config", "*", null, filter, null, null, true);
			if (t == null) return DBNull.Value;
			if (t.Rows.Count == 0) return DBNull.Value;
			DataRow rConfig = t.Rows[0];
			__myAccount_Revenue_CSA = rConfig["idacc_revenue_gross_csa"];
			return rConfig["idacc_revenue_gross_csa"];
		}


		private bool Get_Partition() {
			// Determino se usa la ripartizione unica 
			object esercizio = Meta.GetSys("esercizio");
			string filter = QHS.CmpEq("ayear", Conn.GetSys("esercizio"));
			DataTable t = Conn.RUN_SELECT("csa_contract_partition", "*", null, filter, null, null, true);
			if ((t == null) || (t.Rows.Count == 0)) {
				t = Conn.RUN_SELECT("csa_contracttax_partition", "*", null, filter, null, null, true);
			}

			if ((t == null) || (t.Rows.Count == 0)) return false;
			else return true;
		}

		object __myFlag_Direct_Revenue_CSA = null;

		private object Get_Flag_Direct_Revenue_CSA() {
			// flag di gestione dei Recuperi
			if (Meta.IsEmpty) return DBNull.Value;
			if (__myFlag_Direct_Revenue_CSA != null)
				return __myFlag_Direct_Revenue_CSA;
			object esercizio = Meta.GetSys("esercizio");
			string filter = QHS.CmpEq("ayear", Conn.GetSys("esercizio"));
			DataTable t = Conn.RUN_SELECT("config", "*", null, filter, null, null, true);
			if (t == null) return DBNull.Value;
			if (t.Rows.Count == 0) return DBNull.Value;
			DataRow rConfig = t.Rows[0];
			__myFlag_Direct_Revenue_CSA = rConfig["flagdirectcsaclawback"];
			return rConfig["flagdirectcsaclawback"];
		}

		object __myidchargehandliing_CSA = null;

		private object Get_idchargehandling_CSA() {
			// flag di gestione del tipo trattamento spese CSA, obbligatorio per circolare ABI 36
			if (Meta.IsEmpty) return DBNull.Value;
			if (__myidchargehandliing_CSA != null)
				return __myidchargehandliing_CSA;
			object esercizio = Meta.GetSys("esercizio");
			string filter = QHS.CmpEq("ayear", Conn.GetSys("esercizio"));
			DataTable t = Conn.RUN_SELECT("config", "*", null, filter, null, null, true);
			if (t == null) return DBNull.Value;
			if (t.Rows.Count == 0) return DBNull.Value;
			DataRow rConfig = t.Rows[0];
			__myidchargehandliing_CSA = rConfig["csa_idchargehandling"];
			return rConfig["csa_idchargehandling"];
		}

		object __myFlagEsenteSpese_CSA = null;

		private object Get_FlagEsenteSpese_CSA() {
			// flag di gestione dell'esenzione da spese, per chi non usa Circ. ABI 26, come Unicredit
			if (Meta.IsEmpty) return DBNull.Value;
			if (__myFlagEsenteSpese_CSA != null)
				return __myFlagEsenteSpese_CSA;
			object esercizio = Meta.GetSys("esercizio");
			string filter = QHS.CmpEq("ayear", Conn.GetSys("esercizio"));
			DataTable t = Conn.RUN_SELECT("config", "*", null, filter, null, null, true);
			if (t == null) return DBNull.Value;
			if (t.Rows.Count == 0) return DBNull.Value;
			DataRow rConfig = t.Rows[0];
			__myFlagEsenteSpese_CSA = rConfig["csa_flag"];
			return rConfig["csa_flag"];
		}



		private int getIntSys(string nome) {
			int s = CfgFn.GetNoNullInt32(Meta.GetSys(nome));
			if (s == 0) return 99;
			return s;
		}

		Hashtable voceCsaPerIdInc = new Hashtable();
		Hashtable voceCsaPerIdExp = new Hashtable();
		Hashtable enteCsaPerIdExp = new Hashtable();

		/// <summary>
		/// Genera i movimenti finanziari per i lordi (kind=L) o per i versamenti (kind= V)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <param name="kind">L lordi V versamenti</param>
		private void btnGeneraMovFin_Click(object sender, System.EventArgs e, string kind) {
			if (Meta.IsEmpty) return;
			if (Meta.InsertMode) return;
			Meta.GetFormData(true);
			string fEsercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
			if (!VerificaIndividuazione(btnVerificaIndividuazione)) {
				show(this,
					"Sono stati riscontrati errori nell'individuazione di Anagrafiche, Contratti, Enti relativamente ai file importati");
				return;
			}

			if (esistonoMovFinanziari(kind)) {
				show("Esistono Movimenti finanziari collegati all'Importazione. Operazione annullata");
				return;
			}
			if (!CalcolaRighe()) {
				show(this, "Non ci sono dati da elaborare");
				return;
			}

			dsFinancial.Clear();
			dsFinancial.AcceptChanges();
			RowChange.SetOptimized(dsFinancial.expensesorted, true);
			RowChange.ClearMaxCache(dsFinancial.expensesorted);
			RowChange.SetOptimized(dsFinancial.incomesorted, true);
			RowChange.ClearMaxCache(dsFinancial.incomesorted);
			RowChange.SetOptimized(dsFinancial.underwritingappropriation, true);
			RowChange.ClearMaxCache(dsFinancial.underwritingappropriation);
			RowChange.SetOptimized(dsFinancial.underwritingpayment, true);
			RowChange.ClearMaxCache(dsFinancial.underwritingpayment);

			if (CallStoredProcedure(kind)) {
				clearHashTabelleCollegate();
				if (dsFinancial.config.Rows.Count == 0) {
					DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, dsFinancial.config, null, fEsercizio, null, true);
				}

				if (dsFinancial.sortingkind.Rows.Count == 0) {
					DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, dsFinancial.sortingkind, null, null, null, true);
				}

				IdExpPerIndice = new Hashtable();
				voceCsaPerIdInc = new Hashtable();
				voceCsaPerIdExp = new Hashtable();
				DataRow curr = DS.csa_import.Rows[0];
				bool LiquidazioneDicembre = false;
				if (curr["adate"] != DBNull.Value) {
					DateTime d = (DateTime) curr["adate"];
					if (d.Month == 12) LiquidazioneDicembre = true;
				}



				var listaSospesi = new Dictionary<int, Dictionary<int, decimal>>();

				DataTable csaBill = Conn.RUN_SELECT("csa_bill", "*", null,
					QHS.CmpEq("idcsa_import", curr["idcsa_import"]), null, false);
				listaSospesi = getElencoSospesi(csaBill);


				if (!generaMovPrincipali("E", LiquidazioneDicembre, listaSospesi, kind == "L")) {
					show(this, "Errore nella generazione dei movimenti finanziari di spesa");
					clearHashTabelleCollegate();
					dsFinancial.Clear();
					dsFinancial.AcceptChanges();
					return;
				}

				listaSospesi = new Dictionary<int, Dictionary<int, decimal>>();
				if (!generaMovPrincipali("I", false, listaSospesi, kind == "L")) {
					show(this, "Errore nella generazione dei movimenti finanziari di entrata");
					clearHashTabelleCollegate();
					dsFinancial.Clear();
					dsFinancial.AcceptChanges();
					return;
				}


				if (vecchiaGestione()) {

					if (kind == "V") {
						collegaEntrateaSpese();
					}

					scollegaEntratedaSpese();
				}

				doSave(kind);
			}
		}

		Hashtable hashFin = new Hashtable();
		Hashtable hashUpb = new Hashtable();
		Hashtable hashReg = new Hashtable();

		private void AddVoceBilancio(object ID, string codbil) {
			if (ID == DBNull.Value) return;
			if (hashFin.ContainsKey(ID.ToString())) return;
			//if (dsFinancial.fin.Select(QHC.CmpEq("idfin", ID)).Length > 0) return;
			DataRow NewBil = dsFinancial.fin.NewRow();
			NewBil["idfin"] = ID;
			NewBil["codefin"] = codbil;
			dsFinancial.fin.Rows.Add(NewBil);
			NewBil.AcceptChanges();
			hashFin[ID] = NewBil;
		}

		private void AddVoceUpb(object ID, string codupb) {
			if (ID == DBNull.Value) return;
			if (hashUpb.ContainsKey(ID.ToString())) return;
			//if (dsFinancial.upb.Select(QHC.CmpEq("idupb", ID)).Length > 0) return;

			DataRow NewUpb = dsFinancial.upb.NewRow();
			NewUpb["idupb"] = ID;
			NewUpb["codeupb"] = codupb;
			dsFinancial.upb.Rows.Add(NewUpb);
			NewUpb.AcceptChanges();
			hashUpb[ID] = NewUpb;
		}

		private void AddVoceCreditore(object codice, string denominazione) {
			if (codice == DBNull.Value) return;
			if (hashReg.ContainsKey(codice.ToString())) return;
			//if (dsFinancial.registry.Select(QHC.CmpEq("idreg", codice)).Length > 0) return;

			DataRow NewCred = dsFinancial.registry.NewRow();
			NewCred["idreg"] = codice;
			NewCred["title"] = denominazione;
			dsFinancial.registry.Rows.Add(NewCred);
			NewCred.AcceptChanges();
			hashReg[codice] = NewCred;
		}

		void clearHashTabelleCollegate() {
			hashFin.Clear();
			dsFinancial.fin.Clear();

			hashReg.Clear();
			dsFinancial.registry.Clear();

			hashUpb.Clear();
			dsFinancial.upb.Clear();
		}

		/// <summary>
		/// Aggiunge le righe collegate di bilancio, upb e creditore ai fini del salvataggio
		/// </summary>
		/// <param name="SP_Row"></param>
		private void AddVociCollegate(DataRow SP_Row) {
			AddVoceBilancio(SP_Row["idfin"], SP_Row["codefin"].ToString());
			AddVoceUpb(SP_Row["idupb"], SP_Row["codeupb"].ToString());
			AddVoceCreditore(SP_Row["idreg"], SP_Row["registry"].ToString());
		}

		/// <summary>
		/// Riempie i campi della riga E_S, in base alla riga di automatismo Auto
		/// </summary>
		/// <param name="E_S">riga da riempire</param>
		/// <param name="Auto">riga di automatismo</param>
		private void FillMovimento(DataRow E_S, DataRow Auto) {
			//, string idmovimento)
			int esercizio = Convert.ToInt32(Meta.GetSys("esercizio"));
			DateTime DataCont = Convert.ToDateTime(Meta.GetSys("datacontabile"));
			E_S.BeginEdit();
			E_S["ymov"] = esercizio;
			E_S["adate"] = DataCont;

			string[] fields_to_copy = new string[] {"idman", "idreg", "description"};
			foreach (string field in fields_to_copy) {
				if (Auto.Table.Columns[field] == null) continue;
				if (E_S.Table.Columns.Contains(field)) E_S[field] = Auto[field];
			}

			E_S.EndEdit();
		}

		private void FillImportMov(DataRow ImportMovRow, DataRow Auto, object idcsa_import) {
			ImportMovRow["idcsa_import"] = idcsa_import;
			ImportMovRow["movkind"] = Auto["movkind"];
			ImportMovRow["cu"] = "import";
			ImportMovRow["ct"] = DateTime.Now;
			ImportMovRow["lu"] = "import";
			ImportMovRow["lt"] = DateTime.Now;
			if (ImportMovRow.Table.Columns.Contains("idriep")) {
				ImportMovRow["idriep"] = Auto["idriep"];
			}

			if (ImportMovRow.Table.Columns.Contains("ndetail")) {
				ImportMovRow["ndetail"] = Auto["ndetail"];
			}

			if (ImportMovRow.Table.Columns.Contains("idver")) {
				ImportMovRow["idver"] = Auto["idver"];
			}

			if (ImportMovRow.Table.Columns.Contains("amount")) {
				ImportMovRow["amount"] = Auto["amount"];
			}
		}

		Dictionary<int, int> __kind_of_sorting = new Dictionary<int, int>();
		Dictionary<int, int> __e_phase_sorkind = new Dictionary<int, int>();
		Dictionary<int, int> __i_phase_sorkind = new Dictionary<int, int>();

		int DetectFaseSortingParent(string IoE) {
			string kind = (IoE == "I") ? "Entrata" : "Spesa";
			string phasefieldname = (IoE == "I") ? "nphaseincome" : "nphaseexpense";
			//Prende la prima riga che trova classificata come parent della siope
			DataRow[] RUnGrouped = OutTable.Select(QHC.AppAnd(QHC.IsNotNull("parentidsor"), QHC.CmpEq("kind", kind)));
			if (RUnGrouped == null || RUnGrouped.Length == 0) {
				return -1;
			}

			object idsor = RUnGrouped[0]["parentidsor"];
			int nidsor = Convert.ToInt32(idsor);
			int idsorkind = 0;
			if (__kind_of_sorting.ContainsKey(nidsor)) {
				idsorkind = __kind_of_sorting[nidsor];
			}
			else {
				idsorkind = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("sorting", QHS.CmpEq("idsor", idsor), "idsorkind"));
				__kind_of_sorting[nidsor] = idsorkind;
			}

			Dictionary<int, int> myphasedict = (IoE == "I") ? __i_phase_sorkind : __e_phase_sorkind;
			if (myphasedict.ContainsKey(idsorkind)) {
				return myphasedict[idsorkind];
			}

			object nphase = Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("idsorkind", idsorkind), phasefieldname);
			//show("IoE="+IoE+" idsor="+idsor.ToString()+" idsorkind="+idsorkind.ToString()+ 
			//                " Fase ="+nphase+ " + kind +  = " + kind+" phasefieldname="+phasefieldname);

			if (nphase == null || nphase == DBNull.Value) {
				myphasedict[idsorkind] = -1;
			}
			else {
				myphasedict[idsorkind] = CfgFn.GetNoNullInt32(nphase);
			}

			return myphasedict[idsorkind];
		}

		private void FillMovSortedFaseParent(int index, string IoE, DataRow NewMovRow) {
			FillMovSorted(index, IoE, NewMovRow, "parentidsor");
		}

		private void FillMovSortedFaseMAX(int index, string IoE, DataRow NewMovRow) {
			FillMovSorted(index, IoE, NewMovRow, "idsor");
		}

		private void FillMovSorted(int index, string IoE, DataRow NewMovRow, string field_for_idsor) {
			string tMainSorted = (IoE == "I") ? "incomesorted" : "expensesorted";
			string idMovField = (IoE == "I") ? "idinc" : "idexp";
			string kind = (IoE == "I") ? "Entrata" : "Spesa";
			DataRow[] RUnGrouped;
			if (vecchiaGestione()) {
				RUnGrouped = OutTable.Select(QHC.AppAnd(QHC.CmpEq("nriga", index), QHC.CmpEq("kind", kind)));
			}
			else {
				//nriga è sempre l'indice della riga stessa
				RUnGrouped = new DataRow[] {SP_Result.Rows[index]}; //penso che potesse andare bene anche con la vecchia
			}

			if (RUnGrouped.Length == 0) return;
			MetaData MetaSortedMov = Meta.Dispatcher.Get(tMainSorted);
			MetaSortedMov.SetDefaults(dsFinancial.Tables[tMainSorted]);
			int esercizio = getIntSys("esercizio");

			foreach (DataRow R in RUnGrouped) {
				if (R[field_for_idsor] == DBNull.Value) continue;

				dsFinancial.Tables[tMainSorted].Columns["idsor"].DefaultValue = R[field_for_idsor];
				DataRow SortedMovRow = MetaSortedMov.Get_New_Row(NewMovRow, dsFinancial.Tables[tMainSorted]);
				SortedMovRow["idsor"] = R[field_for_idsor];
				SortedMovRow["amount"] = R["amount"];
				SortedMovRow[idMovField] = NewMovRow[idMovField];
				SortedMovRow["ayear"] = esercizio;
				SortedMovRow["cu"] = "import";
				SortedMovRow["ct"] = DateTime.Now;
				SortedMovRow["lu"] = "import";
				SortedMovRow["lt"] = DateTime.Now;

			}
		}

		/// <summary>
		/// Aggiunge i finanziamenti alla riga NewMovRow, corrispondente alla riga  raggruppata di spesa (di fase 1) di indice index
		///     questa parte NON viene utilizzata quando al movimento è associato un impegno, visto che in quel caso la fase 1 
		///     non è da generare. Aggiunge un finanziamento (eventualmente accorpandoli) per ogni riga non raggruppata  associata al
		///     movimento in fase di generazione
		/// </summary>
		/// <param name="index">indice della riga di spesa raggruppata</param>
		/// <param name="NewMovRow">riga di spesa in fase di creazione</param>
		private void FillUnderwritingAppropriation(int index, DataRow NewMovRow) {
			string tUnderwritingAppropriation = "underwritingappropriation";
			string kind = "Spesa";

			//Ottiene tutte le righe NON raggruppate che puntano alla riga in esame
			DataRow[] RUnGrouped; //= OutTable.Select(QHC.AppAnd(QHC.CmpEq("nriga", index), QHC.CmpEq("kind", kind)));
			if (vecchiaGestione()) {
				RUnGrouped = OutTable.Select(QHC.AppAnd(QHC.CmpEq("nriga", index), QHC.CmpEq("kind", kind)));
			}
			else {
				//nriga è sempre l'indice della riga stessa
				RUnGrouped = new DataRow[] {SP_Result.Rows[index]}; //penso che potesse andare bene anche con la vecchia
			}

			if (RUnGrouped.Length == 0) return;

			MetaData MetaUnderwritingAppropriation = Meta.Dispatcher.Get(tUnderwritingAppropriation);
			MetaUnderwritingAppropriation.SetDefaults(dsFinancial.Tables[tUnderwritingAppropriation]);

			foreach (DataRow R in RUnGrouped) {
				if (R["idunderwriting"] == DBNull.Value) continue;
				// Verifica l'esistenza di un'altra riga avente lo stesso idunderwriting e idexp
				string filter = QHC.AppAnd(QHC.CmpEq("idunderwriting", R["idunderwriting"]),
					QHC.CmpEq("idexp", NewMovRow["idexp"]));
				DataRow[] UnderwritingAppropriation = dsFinancial.Tables[tUnderwritingAppropriation].Select(filter);
				if (UnderwritingAppropriation.Length > 0)
					UnderwritingAppropriation[0]["amount"] =
						CfgFn.GetNoNullDecimal(UnderwritingAppropriation[0]["amount"]) +
						CfgFn.GetNoNullDecimal(R["amount"]);
				else {
					DataRow UnderwritingAppropritionRow = MetaUnderwritingAppropriation.Get_New_Row(NewMovRow,
						dsFinancial.Tables[tUnderwritingAppropriation]);
					UnderwritingAppropritionRow["idunderwriting"] = R["idunderwriting"];
					UnderwritingAppropritionRow["amount"] = R["amount"];
					UnderwritingAppropritionRow["idexp"] = NewMovRow["idexp"];
					UnderwritingAppropritionRow["cu"] = "import";
					UnderwritingAppropritionRow["ct"] = DateTime.Now;
					UnderwritingAppropritionRow["lu"] = "import";
					UnderwritingAppropritionRow["lt"] = DateTime.Now;
				}
			}


		}

		/// <summary>
		/// Aggiunge i finanziamenti alla riga NewMovRow, corrispondente alla riga  raggruppata di spesa (di fase max) di indice index
		/// Aggiunge un finanziamento (eventualmente accorpandoli) per ogni riga non raggruppata associata al movimento in fase di creazione
		/// Se nessuna riga associata a quella corrente ha dei finanzimenti, viene utilizzato il metodo CercaFinanziamento_SolaCassa
		/// </summary>
		/// <param name="index">indice della riga di spesa raggruppata</param>
		/// <param name="NewMovRow">riga di spesa in fase di creazione</param>
		private void FillUnderwritingPayment(int index, DataRow NewMovRow) {
			string tUnderwritingPayment = "underwritingpayment";
			string kind = "Spesa";
			DataRow SP_R = SP_Result.Rows[index];
			//Ottiene tutte le righe NON raggruppate che puntano alla riga in esame
			DataRow[] RUnGrouped = OutTable.Select(QHC.AppAnd(QHC.CmpEq("nriga", index), QHC.CmpEq("kind", kind),
				QHC.IsNotNull("idunderwriting")));

			if (RUnGrouped.Length == 0) {
				CercaFinanziamento_SolaCassa(SP_R["idfin"], SP_R["idupb"], CfgFn.GetNoNullDecimal(SP_R["amount"]),
					NewMovRow);
				return;
			}

			MetaData MetaUnderwritingPayment = Meta.Dispatcher.Get(tUnderwritingPayment);
			MetaUnderwritingPayment.SetDefaults(dsFinancial.Tables[tUnderwritingPayment]);

			foreach (DataRow R in RUnGrouped) {
				if (R["idunderwriting"] == DBNull.Value) continue;
				// Verifica l'esistenza di un'altra riga avente lo stesso idunderwriting e idexp
				string filter = QHC.AppAnd(QHC.CmpEq("idunderwriting", R["idunderwriting"]),
					QHC.CmpEq("idexp", NewMovRow["idexp"]));
				DataRow[] UnderwritingPayment = dsFinancial.Tables[tUnderwritingPayment].Select(filter);
				if (UnderwritingPayment.Length > 0)
					UnderwritingPayment[0]["amount"] = CfgFn.GetNoNullDecimal(UnderwritingPayment[0]["amount"]) +
					                                   CfgFn.GetNoNullDecimal(R["amount"]);
				else {
					DataRow UnderwritingPaymentRow = MetaUnderwritingPayment.Get_New_Row(NewMovRow,
						dsFinancial.Tables[tUnderwritingPayment]);
					UnderwritingPaymentRow["idunderwriting"] = R["idunderwriting"];
					UnderwritingPaymentRow["amount"] = R["amount"];
					UnderwritingPaymentRow["idexp"] = NewMovRow["idexp"];
					UnderwritingPaymentRow["cu"] = "import";
					UnderwritingPaymentRow["ct"] = DateTime.Now;
					UnderwritingPaymentRow["lu"] = "import";
					UnderwritingPaymentRow["lt"] = DateTime.Now;
				}
			}
		}




		/*
		 * topay = finanziamenti impegnato e non pagati
		 *          Ossia quanto è stato finanziato in fase di impegno ma non ancora portato in pagamento
		 * paymentprevavailable = prev. di cassa disponibile
		 *          Ossia quanto hai previsto di PAGARE e non hai ancora PAGATO
		 * proceedsavailable  = CASSA disponibile
		 *          Ossia quanto hai assegnato in cassa e non ancora utilizzato nei PAGAMENTI
		 */

		/// <summary>
		/// Inserisce i finanziamenti sul pagamento cercando di fare il meglio che può. In particolare:
		///  - 1 se l'utente non usa crediti o competenza associa i finanziamenti sulla semplice disponibilità che trova a finanziare
		///  - 2 se ci sono righe non raggruppate associate con dei finanziamenti espliciti, usa quelli 
		///  - 3 se l'impegno non è associato a dei finanziamenti o questi non hanno disponibilità, vale il caso 1
		///  - Altrimenti usa i finanziamenti dell'impegno con disponibilità, considerando in particolarei finanziamenti associati in fase 
		///     di impegno e non associati a pagamenti, prendendoli in ordine di:
		///      * previsione disponibile a pagare  se uno non usa le assegazioni di cassa
		///      * assegnazioni disponibili di cassa se uno usa le assegnazioni di cassa 
		/// </summary>
		/// <param name="index"></param>
		/// <param name="R">Riga di automatismo raggruppata</param>
		/// <param name="Curr">Riga di spesa in fase di generazione</param>
		void CercaFinanziamentoCassa(int index, DataRow Curr) {

			DataRow R = SP_Result.Rows[index];
			//Se non usa i crediti e nemmeno la competenza, la disponibilità a pagare non può essere ricercata considerando l'impegno
			//  sarà dunque effettuata sulla semplice base della coppia upb/bilancio in uscita (considerando tutti i finanziamenti presenti)
			// Questa parte quindi prescinde dal fatto che uno abbia o meno selezionato un impegno
			if (!(UsaCrediti() || UsaPrevCompetenza())) {
				FillUnderwritingPayment(index, Curr);
				return;
			}

			//Ottiene tutte le righe NON raggruppate che puntano alla riga in esame e che hanno associato un finanziamento
			DataRow[] RUnGroupedWithUnderwriting =
				OutTable.Select(QHC.AppAnd(QHC.CmpEq("nriga", index), QHC.CmpEq("kind", "Spesa"),
					QHC.IsNotNull("idunderwriting")));

			//Se ci sono delle righe sono associate a finanziamenti, allora non deve prendere i dati dagli impegni ma dalle righe 
			// non raggruppate direttamente
			if (RUnGroupedWithUnderwriting.Length > 0) {
				FillUnderwritingPayment(index, Curr);
				return;
			}

			object parentidexp = R["parentidexp"];

			//Se usa i crediti o la competenza ->  si presume ci siano uno più finanziamenti associati all'impegno .
			//La disponibilità sarà considerata nell'ambito del pagato relativo a tali finanziamenti e non esclusivamente 
			// sulla coppia bilancio/upb in uscita

			string fieldtouse = "paymentsavailable";
			// = disp. a pagare =  previsione di cassa in uscita - pagamenti effettuati
			if (UsaCassa()) {
				fieldtouse = "proceedsavailable"; //incassi disponibili (cassa assegnata e non utilizzata nei pagamenti)
			}

			//Prende prima le righe aventi disponibilità nei sensi di fieldtouse e POI quelle che non ce l'hanno
			DataTable F = Conn.RUN_SELECT("expensecreditproceedsview", "*", fieldtouse + " asc",
				QHS.AppAnd(QHS.CmpEq("idexp", GetIDImpegno(parentidexp)), QHS.CmpEq("ayear", Conn.GetSys("esercizio")),
					QHS.CmpGt(fieldtouse, 0), QHS.CmpGt("topay", 0)), null, false);
			Conn.RUN_SELECT_INTO_TABLE(F, fieldtouse + " desc",
				QHS.AppAnd(QHS.CmpEq("idexp", GetIDImpegno(parentidexp)), QHS.CmpEq("ayear", Conn.GetSys("esercizio")),
					QHS.CmpLe(fieldtouse, 0), QHS.CmpGt("topay", 0)), null, false);

			if (F == null || F.Rows.Count == 0) {

				//show(this, "Non ci sono finanziamenti per questa coppia progetto-voce di bilancio",
				//    "Informazione");

				// Se non ci sono finanziamenti associati a questo movimento, fai finta che di non dover collegare alcun movimento
				//  andando a considerare direttamente le previsioni
				CercaFinanziamento_SolaCassa(R["idfin"], R["idupb"], CfgFn.GetNoNullDecimal(R["amount"]), Curr);
				return;
			}


			//Ottiene una tabella con le colonne idunderwriting e topay (disponibile a pagare sul finanziamento dell'impegno)

			MetaData MetaUA = Meta.Dispatcher.Get("underwritingpayment");

			decimal to_cover = CfgFn.GetNoNullDecimal(R["amount"]); //prende l'importo della riga corrente


			foreach (DataRow Rf in F.Rows) {
				decimal available = CfgFn.GetNoNullDecimal(Rf["topay"]);
				if (available == 0) continue;

				object idunderwriting_found = Rf["idunderwriting"];

				DataRow newrow = null;


				string filterpay = QHS.AppAnd(QHS.CmpEq("idexp", Curr["idexp"]),
					QHS.CmpEq("idunderwriting", idunderwriting_found));

				if (dsFinancial.Tables["underwritingpayment"].Select(filterpay).Length == 0) {
					MetaUA.SetDefaults(dsFinancial.Tables["underwritingpayment"]);
					DataRow toadd = MetaUA.Get_New_Row(Curr, dsFinancial.Tables["underwritingpayment"]);
					toadd["idunderwriting"] = idunderwriting_found;
					newrow = toadd;
				}
				else {
					newrow = dsFinancial.Tables["underwritingpayment"].Select(filterpay)[0];
				}

				if (to_cover <= available) {
					newrow["amount"] = CfgFn.GetNoNullDecimal(newrow["amount"]) + to_cover;
					to_cover = 0;
				}
				else {
					newrow["amount"] = CfgFn.GetNoNullDecimal(newrow["amount"]) + available;
					to_cover -= available;
				}

				if (to_cover == 0) break;
			}

		}

		/*
		 * upbunderwritingyearview
		 *  incomeprevavailable 

		 */

		/// <summary>
		/// Ricerca i finanziamenti disponibili per la coppia bilancio/upb considerata nei casi in cui non ci siano finanziamenti 
		///  in fase di impegno.
		/// La ricerca riguarda quindi solo la previsione e non i finanziamenti. Le previsioni sono prese in ordine crescente 
		///  di disponibilità.
		/// </summary>
		/// <param name="idfin">IDfin per la riga da considerare</param>
		/// <param name="idupb">IDupb per la riga da considerare</param>
		/// <param name="Curr">Riga di spesa in fase di generazione</param>
		void CercaFinanziamento_SolaCassa(object idfin, object idupb, decimal amount, DataRow Curr) {
			// Curr nuovo movimento di spesa in fase di creazione
			string fieldtouse = "paymentprevavailable"; // = disp. a pagare

			//object idfin = Curr["idfin"];
			//object idupb = Curr["idupb"];

			//Legge l'elenco di tutti i finanziamenti aventi previsione disponibile per il pagamento
			//  per la voce upb/bilancio del movimento di spesa, in ordine crescente di disponibilità
			DataTable F = Conn.RUN_SELECT("upbunderwritingyearview", "*", fieldtouse + " asc",
				QHS.AppAnd(QHS.CmpEq("idfin", idfin), QHS.CmpEq("idupb", idupb), QHS.CmpGt(fieldtouse, 0)), null,
				false);

			if (F == null || F.Rows.Count == 0) {
				//show(this, "Non ci sono finanziamenti per questa coppia progetto-voce di bilancio",
				//    "Informazione");
				return;
			}

			MetaData MetaUA = Meta.Dispatcher.Get("underwritingpayment");

			decimal to_cover = amount; //prende l'importo corrente dell movimento di spesa

			foreach (DataRow Rf in F.Rows) {
				object idunderwriting_found = Rf["idunderwriting"];
				string filterunderwriting = QHC.AppAnd(
					QHC.CmpEq("idexp", Curr["idexp"]),
					QHC.CmpEq("idunderwriting", idunderwriting_found)
				);
				DataRow newrow = null;
				decimal available = CfgFn.GetNoNullDecimal(Rf[fieldtouse]);

				if (dsFinancial.Tables["underwritingpayment"].Select(filterunderwriting).Length == 0) {
					//in available la disponibilità a pagare                    
					MetaUA.SetDefaults(dsFinancial.Tables["underwritingpayment"]);
					DataRow toadd = MetaUA.Get_New_Row(Curr, dsFinancial.Tables["underwritingpayment"]);
					toadd["idunderwriting"] = idunderwriting_found;

					newrow = toadd;
				}
				else {
					newrow = dsFinancial.Tables["underwritingpayment"].Select(filterunderwriting)[0];
				}

				if (to_cover <= available) {
					newrow["amount"] = CfgFn.GetNoNullDecimal(newrow["amount"]) + to_cover;
					to_cover = 0;
				}
				else {
					newrow["amount"] = CfgFn.GetNoNullDecimal(newrow["amount"]) + available;
					to_cover -= available;
				}

				if (to_cover == 0) break;
			}

		}

		/// <summary>
		/// Ottiene  la chiave dell'impegno a partire dalla chiave di un movimento di spesa di un livello generico
		/// </summary>
		/// <param name="parentidexp">chiave di un movimento di spesa salvato</param>
		/// <returns>chiave dell'antenato del movimento dato, avente fase pari a quella del bilancio (la prima in genere)</returns>
		object GetIDImpegno(object parentidexp) {
			int parid = CfgFn.GetNoNullInt32(parentidexp);
			if (__getImpegnoofIdExp.ContainsKey(parid)) return __getImpegnoofIdExp[parid];
			int faseBilancio = getIntSys("expensefinphase");
			object idlivbil = Conn.DO_READ_VALUE("expenselink",
				QHS.AppAnd(QHS.CmpEq("idchild", parid), QHS.CmpEq("nlevel", faseBilancio)),
				"idparent");
			__getImpegnoofIdExp[parid] = CfgFn.GetNoNullInt32(idlivbil);
			return idlivbil;
		}

		Dictionary<int, int> __getImpegnoofIdExp = new Dictionary<int, int>();

		/// <summary>
		/// Calcola i finanziamenti sull'impegno associati ad un movimento di spesa il cui padre ha chiave parentidexp
		///  le colonne sono idunderwriting e topay (parte del credito assegnata e non pagata)
		/// </summary>
		/// <param name="parentidexp"></param>
		/// <returns>Finanziamenti associati in fase impegno ad un movimento generico di fase successiva</returns>

		string __myflagcredit = null;

		/// <summary>
		/// Verifica se l'utente gestisce le assegnazioni dei crediti
		/// </summary>
		/// <returns></returns>
		bool UsaCrediti() {
			if (__myflagcredit != null) {
				return __myflagcredit == "S";
			}

			object esercizio = Meta.GetSys("esercizio");
			string filter = QHS.CmpEq("ayear", Conn.GetSys("esercizio"));
			DataTable t = Conn.RUN_SELECT("config", "*", null, filter, null, null, true);
			if (t == null) return false;
			if (t.Rows.Count == 0) return false;
			DataRow rConfig = t.Rows[0];
			__myflagcredit = rConfig["flagcredit"].ToString().ToUpper();
			if (__myflagcredit == "S")
				return true;
			return false;
		}



		string __myflagproceeds = null;

		/// <summary>
		/// Verifica se l'utente gestisce le assegnazioni di cassa
		/// </summary>
		/// <returns></returns>
		bool UsaCassa() {
			if (__myflagproceeds != null) {
				return __myflagproceeds == "S";
			}

			object esercizio = Meta.GetSys("esercizio");
			string filter = QHS.CmpEq("ayear", Conn.GetSys("esercizio"));
			DataTable t = Conn.RUN_SELECT("config", "*", null, filter, null, null, true);
			if (t == null) return false;
			if (t.Rows.Count == 0) return false;
			DataRow rConfig = t.Rows[0];
			__myflagproceeds = rConfig["flagproceeds"].ToString().ToUpper();
			if (__myflagproceeds == "S")
				return true;
			return false;
		}

		int __myfin_kind = -1;

		/// <summary>
		/// Verifica se l'utente gestisce la previsione di competenza
		/// </summary>
		/// <returns></returns>
		bool UsaPrevCompetenza() {
			if (__myfin_kind != -1) {
				return (__myfin_kind == 1 || __myfin_kind == 3);
			}

			object esercizio = Meta.GetSys("esercizio");
			string filter = QHS.CmpEq("ayear", Conn.GetSys("esercizio"));
			DataTable t = Conn.RUN_SELECT("config", "*", null, filter, null, null, true);
			if (t == null) return false;
			if (t.Rows.Count == 0) return false;
			DataRow rConfig = t.Rows[0];
			__myfin_kind = CfgFn.GetNoNullInt32(rConfig["fin_kind"]);
			if (__myfin_kind == 1 || __myfin_kind == 3) return true;
			return false;
		}

		/// <summary>
		/// Verifica se l'utente gestisce la previsione di cassa
		/// </summary>
		/// <returns></returns>
		bool UsaPrevCassa() {
			if (__myfin_kind != -1) {
				return (__myfin_kind == 2 || __myfin_kind == 3);
			}

			object esercizio = Meta.GetSys("esercizio");
			string filter = QHS.CmpEq("ayear", Conn.GetSys("esercizio"));
			DataTable t = Conn.RUN_SELECT("config", "*", null, filter, null, null, true);
			if (t == null) return false;
			if (t.Rows.Count == 0) return false;
			DataRow rConfig = t.Rows[0];
			__myfin_kind = CfgFn.GetNoNullInt32(rConfig["fin_kind"]);
			if (__myfin_kind == 2 || __myfin_kind == 3) return true;
			return false;
		}

		string __flagEpExp = null;

		bool UsaBudget() {
			if (__flagEpExp != null) {
				return __flagEpExp == "S";
			}

			object esercizio = Meta.GetSys("esercizio");
			string filter = QHS.CmpEq("ayear", Conn.GetSys("esercizio"));
			DataTable t = Conn.RUN_SELECT("config", "*", null, filter, null, null, true);
			if (t == null) return false;
			if (t.Rows.Count == 0) return false;
			DataRow rConfig = t.Rows[0];
			__flagEpExp = rConfig["flagepexp"].ToString().ToUpper();
			if (__flagEpExp == "S")
				return true;
			return false;
		}

		private void FillImputazioneMovimento(DataRow ImpMov, DataRow Auto) {
			string[] fields_to_copy = new string[] {
				"idfin", "idupb", "codefin"
			};
			foreach (string field in fields_to_copy) {
				if (Auto.Table.Columns[field] == null) continue;
				if (ImpMov.Table.Columns[field] == null) continue;
				ImpMov[field] = Auto[field];
			}

			ImpMov["amount"] = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(Auto["amount"]));
		}

		bool vecchiaGestioneOutTable(string kind, DataTable OutTable) {

			SP_Result = CalcAutoGrouped(OutTable);


			// A questo punto consideriamo che i collegamenti eventualmente individuati nella fase precedente,
			// debbano essere invece gestiti diversamente, a questo punto si cercherà di produrre movimenti finanziari
			// spesa a importo netto, compensando le righe positive con le corrispondenti righe negative. Se tale compensazione non sarà
			// possibile, si cercherà al contrario di compensare le entrate con le spese

			object flagBalance = Get_FlagBalanceCSA();
			if (flagBalance.ToString() == "S")
				SP_Result = CompensaEntrateESpese(SP_Result, OutTable);

			//formtest frm = new formtest(OutTable, SP_Result);

			//DialogResult dr = frm.ShowDialog();
			SP_Result.Columns.Add("idmovimento", typeof(string));

			//riempie un paio di hashtable utili ai fini della visualizzazione
			if (kind == "L") {
			}

			FillTables(SP_Result);
			return true;
		}




		/// <summary>
		/// Chiama la SP che calcoli i movimenti per i Lordi o per i Versamenti
		/// Calcola la tabella OutTable (righe non raggruppate) e la tabella SP_Result (righe raggruppate)
		/// </summary>
		/// <param name="kind">L/V</param>
		/// <returns>false on errors</returns>
		private bool CallStoredProcedure(string kind) {
			DataRow Curr = DS.csa_import.Rows[0];

			object esercizio = Conn.GetEsercizio();

			string procName = "";
			procName = kind == "L" ? "compute_csa_lordi" : "compute_csa_versamenti";
			if (nuovaGestione())
				procName = kind == "L" ? "compute_csa_lordi_partition" : "compute_csa_versamenti_partition";
			DataSet Out = new DataSet();
			if (kind == "L") {
				Out = Conn.CallSP(procName,
					new object[] {esercizio, Curr["idcsa_import"]});
			}
			else {
				StringBuilder sb = new StringBuilder();
				sb.AppendLine("DECLARE @lista_idcsa_import AS int_list;");
				sb.AppendLine("");
				sb.AppendLine("DECLARE @lista_idreg AS int_list;");
				sb.AppendLine(
					$"exec  compute_csa_versamenti_partition {esercizio},{Curr["idcsa_import"]},@lista_idcsa_import, @lista_idreg");
				DataTable T = Conn.SQLRunner(sb.ToString());
				if (T == null) return false;
				if (T.Rows.Count == 0) return false;
				Out.Tables.Add(T);

			}

			if (Out == null) return false;
			if (Out.Tables.Count == 0) return false; //no answer from sp
			movimentiRaggruppati = null;

			OutTable = Out.Tables[0];

			if (vecchiaGestione()) {
				return vecchiaGestioneOutTable(kind, OutTable);
			}


			SP_Result = nuovaGestionOutTable.calcola(OutTable, Conn, out movimentiRaggruppati);

			if (SP_Result == null) return false;

			object nBill = getSospeso(kind == "L");

			if (nuovaGestione()) {
				//nuova gestione
				SP_Result.Columns.Add("nbill", typeof(Int32));

				if (nBill != DBNull.Value) {
					//Imposta il sospeso quando è stato impostato il n. di sospeso 

					foreach (DataRow r in SP_Result.Rows) {
						if (CfgFn.GetNoNullDecimal(r["netto"]) != 0) {
							r["nbill"] = nBill;
						}

						// Per alcuni enti versamento non si deve specificare il sospeso sui movimenti di tipo 4, Versamento Contributi e Ritenute
						if ((kind == "V") && (agency_not_use_nbill(r["idcsa_agency"]))) {
							r["nbill"] = DBNull.Value;
						}
					}
				}

				if (nBill == DBNull.Value) {
					//Imposta il sospeso nei casi in cui non sia stato impostato il n. di sospeso


				}

			}



			FillTables(SP_Result);
			return true;
		}

		private QuoteCsa movimentiRaggruppati = null;

		object getSospeso(bool lordi) {
			//TODO: ottenere il n. di sospeso dal dataset
			if (lordi) return DS.csa_import.Rows[0]["nbill_netti"];
			return DS.csa_import.Rows[0]["nbill_versamenti"];
		}

		Dictionary<object, bool> _agency_not_use_nbill = new Dictionary<object, bool>();

		bool agency_not_use_nbill(object idcsa_agency) {
			if (_agency_not_use_nbill.ContainsKey(idcsa_agency)) {
				return _agency_not_use_nbill[idcsa_agency];
			}
			else {
				int flag = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("csa_agency",
					QHS.CmpEq("idcsa_agency", idcsa_agency), "(ISNULL(csa_agency.flag, 0)&2)"));
				_agency_not_use_nbill[idcsa_agency] = flag != 0;
				return _agency_not_use_nbill[idcsa_agency];
			}
		}

		//  + movkind 1 mov. entrata ritenute/contributi su partite di giro (fase LORDI)
		//  -movkind 8 mov. spesa ritenute  (negativi) (fase LORDI)
		//  -movkind 12 mov. spesa contributi (negativi) con transito p. di giro (fase LORDI)

		//  +movkind 2 mov. spesa costo contributi su p. di giro (fase LORDI)
		//  -movkind 10 mov. entrata ricavo contributi (negativi) (fase LORDI se su partita di giro  oppure VERSAMENTI se liquidazione diretta)


		//  +movkind 3 mov. spesa costo  lordi (fase LORDI)
		//  -movkind 7 mov. entrata ricavo lordi (negativi) (fase LORDI)

		//  +movkind 5 mov. entrata recuperi su partite di giro (fase LORDI)
		//  -movkind 14 mov. spesa recuperi su partita di giro (negativi) (fase LORDI)
		//  -movkind 15 mov. entrata recuperi diretti (fase LORDI)  
		// - movkind 16 mov. spesa recuperi diretti (negativi) (fase LORDI)

		//  +movkind 4 mov. spesa contributi/ritenute/recuperi (fase VERSAMENTI)  (anche versamento contributi su liq. diretta)
		//  -movkind 9 mov. entrata (dall'erario) ritenute (negative) (fase VERSAMENTI)
		//  -movkind 10 mov. entrata di ricavo contributi (negativi) (fase LORDI se su partita di giro  oppure VERSAMENTI se liquidazione diretta)
		//  -movkind 11 mov. entrata incasso contributi su partita di giro da erario (fase VERSAMENTI)  
		//  -movkind 17 mov. entrata (dall'erario) recuperi (negativi) (fase VERSAMENTI)

		//  +movkind 6 mov. entrata recuperi post versamento con transito p. di giro (fase VERSAMENTI)
		//  -movkind 13 mov. spesa costo recuperi su partita di giro (negativi) (fase VERSAMENTI)


		/// <summary>
		/// Dalla tabella in input ne ottiene una nuova in cui:
		/// -  i movimenti di spesa sono raggruppati su bilancio/upb/mov. di spesa/descrizione, ossia in modo da minimizzarne il numero
		/// -  per le righe di entrata la colonna indice punta alla corripondente in spesa 
		/// -  la colonna nriga della tabella raggruppata   rappresenta il numero di riga nel datatable di cui fa parte
		/// -  nelle righe  di spesa la colonna indice è pari a nriga, ossia l'indice della riga raggruppata
		/// -  per spesa: NRIGA = indice della riga raggruppata (sia nella tabella raggruppata che quella non raggruppata)
		/// -  per ENTRATA: NRIGA = indice della riga raggruppata (sia nella tabella raggruppata che quella non raggruppata)
		/// -  per spesa: INDICE = indice della riga raggruppata (sia nella tabella raggruppata che quella non raggruppata)
		/// -  per alcune entrate: INDICE = indice della riga di spesa raggruppata
		/// </summary>
		/// <param name="Auto"></param>
		/// <returns></returns>
		/// 
		private DataTable CompensaEntrateESpese(DataTable Auto, DataTable AutoNoGrouped) {
			Auto.AcceptChanges();
			//1) Scorro le righe di Entrata della Tabella Automatismi Raggruppati, allo scopo di effettuare le compensazioni
			for (int i = 0; i < Auto.Rows.Count; i++) {
				DataRow R = Auto.Rows[i];
				if (R["kind"].ToString() == "Spesa") continue;
				if (R["indice"] == DBNull.Value) continue;
				if (CfgFn.GetNoNullInt32(R["movkind"]) == 1)
					continue; // non deve effettuare le compensazioni tra lordi e le righe delle ritenute
				if (CfgFn.GetNoNullInt32(R["movkind"]) == 5)
					continue; // non deve effettuare le compensazioni tra lordi e le righe dei recuperi diretti
				if (CfgFn.GetNoNullInt32(R["movkind"]) == 6)
					continue;
				// non deve effettuare le compensazioni tra versamenti e le righe dei recuperi su p. di giro
				if (CfgFn.GetNoNullInt32(R["movkind"]) == 9)
					continue; // non deve effettuare le compensazioni tra versamenti e le righe delle ritenute negative
				if (CfgFn.GetNoNullInt32(R["movkind"]) == 10)
					continue;
				// non deve effettuare le compensazioni tra lordi/versamenti e le righe dei contributi negativi
				if (CfgFn.GetNoNullInt32(R["movkind"]) == 11)
					continue;
				// non deve effettuare le compensazioni tra versamenti e le righe di incasso dall'erario dei contributi su p. di giro
				if (CfgFn.GetNoNullInt32(R["movkind"]) == 15)
					continue; // non deve effettuare le compensazioni tra lordi e le righe dei recuperi su p. di giro
				if (CfgFn.GetNoNullInt32(R["movkind"]) == 17)
					continue;
				// non deve effettuare le compensazioni tra versamenti recuperi  e le righe dei recuperi su p. di giro

				decimal incomeAmount = CfgFn.GetNoNullDecimal(R["amount"]);
				//e detto expenseAmount l'importo della riga di Auto avente indice E[indice]
				decimal expenseAmount = 0;
				string filter = QHC.AppAnd(QHC.CmpEq("kind", "Spesa"), QHC.CmpEq("nriga", R["indice"]));
				DataRow[] RExp = Auto.Select(filter);
				if (RExp.Length == 0) continue;

				DataRow RExpense = RExp[0];

				expenseAmount = CfgFn.GetNoNullDecimal(RExpense["amount"]);

				// Confronto i valori tra loro, modificando a causa della compensazione, o l'importo della riga di entrata,
				// o l'importo della riga di spesa associata

				if (incomeAmount > expenseAmount) {
					R["amount"] = incomeAmount - expenseAmount;
					RExpense["amount"] = 0;
				}
				else {
					R["amount"] = 0;
					RExpense["amount"] = expenseAmount - incomeAmount;
				}
			}

			// Riallinea gli importi delle righe non raggruppate, allo scopo di riproporzionare tutto ai nuovi importo delle righe raggruppate
			for (int i = 0; i < Auto.Rows.Count; i++) {
				DataRow R = Auto.Rows[i];

				decimal amount = CfgFn.GetNoNullDecimal(R["amount"]);
				decimal originalAmount = CfgFn.GetNoNullDecimal(R["amount", DataRowVersion.Original]);

				if (amount == originalAmount) continue;
				string filterLinked = QHC.AppAnd(QHC.CmpEq("kind", R["kind"]), QHC.CmpEq("nriga", R["nriga"]));

				DataRow[] RLinked = AutoNoGrouped.Select(filterLinked);
				foreach (DataRow RRLink in RLinked) {
					// a_i, valori originali delle righe non raggruppate , sommati danno originalamount = a
					// b_i, valori modificati delle righe non raggruppate , sommati danno amount = b
					// spalmo gli errori di arrotondamento su tutte le righe non raggruppate su cui ciclo
					// b = b-b_i  a = a- a_i, dividendo membro a membro il rapporto  b/a è uguale a  (b- b_i) / (a - a_i)
					decimal a_i = CfgFn.GetNoNullDecimal(RRLink["amount"]);
					RRLink["amount"] =
						CfgFn.RoundValuta((CfgFn.GetNoNullDecimal(RRLink["amount"]) / originalAmount) * amount);
					decimal b_i = CfgFn.GetNoNullDecimal(RRLink["amount"]);

					originalAmount = originalAmount - a_i;
					amount = amount - b_i;
				}
			}

			Auto.AcceptChanges();
			AutoNoGrouped.AcceptChanges();

			// Cancello le righe di entrata raggruppate azzerate
			for (int i = 0; i < Auto.Rows.Count; i++) {
				DataRow R = Auto.Rows[i];
				if (R["kind"].ToString() == "Spesa") continue;

				decimal incomeAmount = CfgFn.GetNoNullDecimal(R["amount"]);

				if (incomeAmount == 0) {
					string filterLinked = QHC.AppAnd(QHC.CmpEq("kind", "Entrata"), QHC.CmpEq("nriga", R["nriga"]));
					DataRow[] RIncLinked = AutoNoGrouped.Select(filterLinked);
					foreach (DataRow RRInc in RIncLinked) {
						RRInc.Delete();
					}

					R.Delete();
				}
			}

			Auto.AcceptChanges();
			AutoNoGrouped.AcceptChanges();
			// Cancello le righe di spesa  raggruppate azzerate
			for (int i = 0; i < Auto.Rows.Count; i++) {
				DataRow R = Auto.Rows[i];
				if (R["kind"].ToString() == "Entrata") continue;

				decimal expenseAmount = CfgFn.GetNoNullDecimal(R["amount"]);

				if (expenseAmount == 0) {
					string filter = QHC.AppAnd(QHC.CmpEq("kind", "Entrata"), QHC.CmpEq("indice", i));
					DataRow[] RIncome = Auto.Select(filter);
					foreach (DataRow RRInc in RIncome) {
						RRInc["indice"] = DBNull.Value;
					}

					string filterLinked = QHC.AppAnd(QHC.CmpEq("kind", "Spesa"), QHC.CmpEq("nriga", R["nriga"]));
					DataRow[] RExpLinked = AutoNoGrouped.Select(filterLinked);
					foreach (DataRow RRExp in RExpLinked) {
						RRExp.Delete();
					}

					R.Delete();
				}
			}

			Auto.AcceptChanges();
			AutoNoGrouped.AcceptChanges();
			return Auto;
		}

		private DataTable CalcAutoGrouped(DataTable Auto) {
			//1) Scorro le righe dettagliate restituite dalla stored procedure

			//Riempio una seconda tabella con gli automatismi di spesa e poi di entrata 
			//raggruppando le righe senza distinguere Regola specifica, Regola generale CSA, classificazioni e finanziamenti
			Auto.Columns.Add("indice", typeof(Int32));
			Auto.Columns.Add("nriga", typeof(Int32));
			// nriga serve sia per le entrate che per le spese
			// a conservare un riferimento ai corrispondenti movimenti raggruppati
			//Ho implementato un DataGrid che è collegato a un DataTable.


			DataTable AutoGrouped = Auto.Clone();
			AutoGrouped.Columns.Remove("idcsa_contractkind");
			AutoGrouped.Columns.Remove("idcsa_contract");
			AutoGrouped.Columns.Remove("idsor");
			AutoGrouped.Columns.Remove("sortcode");
			AutoGrouped.Columns.Remove("idunderwriting");
			AutoGrouped.Columns.Remove("codeunderwriting");
			Dictionary<int, int> nReve = new Dictionary<int, int>();
			Dictionary<int, decimal> amountReve = new Dictionary<int, decimal>();
			Dictionary<int, decimal> speseRaggruppate = new Dictionary<int, decimal>();
			// groupedRows[indice]= elenco di righe di Auto collegate a AutoGrouped[indice]
			Dictionary<int, List<DataRow>> groupedRows = new Dictionary<int, List<DataRow>>();
			//Crea le righe di spesa raggruppate
			for (int i = 0; i < Auto.Rows.Count; i++) {
				DataRow R = Auto.Rows[i];
				if (R["kind"].ToString() == "Entrata")
					continue;

				//Facciamo il raggruppamento per tutte le spese, anche per il versamento dei contributi/ritenute/recupero
				//  e per i movimenti di spesa per ritenute e recuperi negativi
				//Visto che raggruppiamo anche per idreg non abbiamo problemi             

				string filter = QHC.MCmp(R, "kind", "movkind", "parentidexp", "idreg", "idcsa_agency",
					"idcsa_agencypaymethod", "idfin", "idupb", "idman", "description", "idacc", "vocecsa");

				//cerca nelle righe raggruppata una riga in cui inserire R, aumentandone l'importo
				DataRow[] RGrouped = AutoGrouped.Select(filter);
				if (RGrouped.Length == 0) {
					DataRow NewR = AddRowToTableGrouped(R, AutoGrouped);
					//indice  e nriga del DataRow di spesa raggruppata contengono l'indice di riga del DataRow stesso
					int indice = AutoGrouped.Rows.Count - 1;
					NewR["indice"] = indice;
					NewR["nriga"] = indice;
					nReve[indice] = 0;
					amountReve[indice] = 0;
					// indice e nriga  della riga di spesa dettagliata contengono l'indice della riga raggruppata
					R["indice"] = NewR["indice"];
					R["nriga"] = NewR["nriga"];
					groupedRows[indice] = new List<DataRow>();
					groupedRows[indice].Add(R);
					speseRaggruppate[indice] = CfgFn.GetNoNullDecimal(R["amount"]);
				}
				else {
					//il campo indice della riga non raggruppata è pari al campo indice della riga raggruppata
					int indice = CfgFn.GetNoNullInt32(RGrouped[0]["indice"]);
					R["indice"] = indice;
					R["nriga"] = indice;
					RGrouped[0]["amount"] = CfgFn.GetNoNullDecimal(RGrouped[0]["amount"]) +
					                        CfgFn.GetNoNullDecimal(R["amount"]);
					groupedRows[indice].Add(R);
					speseRaggruppate[indice] = CfgFn.GetNoNullDecimal(RGrouped[0]["amount"]);
				}

			}


			//Collega le righe (alcune tipologie) di entrata non raggruppate ai movimenti di spesa raggruppati
			object idreg_csa = Get_Registry_Csa();
			for (int i = 0; i < Auto.Rows.Count; i++) {
				DataRow R = Auto.Rows[i];
				if (R["kind"].ToString() == "Spesa")
					continue;

				if (CfgFn.GetNoNullInt32(R["movkind"]) == 6)
					continue; // Le entrate post versamento recuperi non vanno associate  (fase versamenti)
				if (CfgFn.GetNoNullInt32(R["movkind"]) == 10)
					continue;
				// escludo anche i ricavi contributi negativi  (fase lordi oppure versamenti in base alla modalità gestione contributi)
				if (CfgFn.GetNoNullInt32(R["movkind"]) == 11)
					continue; // escludo anche i rimborsi contributi negativi da erario (solo fase versamenti)
				if (CfgFn.GetNoNullInt32(R["movkind"]) == 17)
					continue; // escludo anche i recuperi negativi su partita di giro (fase versamenti)
				// se l'Ente CSA è configurato in modo da non collegare automatismi allora non ccrea l'associazione entrata-spesa
				object idcsa_agency = R["idcsa_agency"];
				// Su questi movimenti di entrata della fase lordi non deve interrogare la configurazione dell'ENTE CSA
				// movkind 1 mov.entrata ritenute/ contributi su partite di giro (fase LORDI)
				// movkind 5 mov.entrata recuperi su partite di giro (fase LORDI)
				// movkind 7 mov. entrata ricavo lordi (negativi) (fase LORDI)

				//if ((CfgFn.GetNoNullInt32(R["movkind"]) != 1) &&
				//    (CfgFn.GetNoNullInt32(R["movkind"]) != 5) &&
				//    (CfgFn.GetNoNullInt32(R["movkind"]) != 7) && 
				//    (!CollegaAutomatismiEnteCSA(idcsa_agency))) continue;

				// Nessun limite neanche per il raggruppamento delle entrate
				//if ((CfgFn.GetNoNullInt32(R["movkind"]) != 1) && //mov. entrata ritenute/contributi(esclusi dopo) (fase LORDI)
				//    (CfgFn.GetNoNullInt32(R["movkind"]) != 5) && // mov. entrata recuperi (fase LORDI)
				//    (CfgFn.GetNoNullInt32(R["movkind"]) != 7) && //mov. entrata lordi (negativi) (fase LORDI)
				//    (R["idreg"] != idreg_csa)) continue; // salta i mov. di entrata per i contributi (LORDI)

				//Solo per entrate dovute a ritenute/recuperi/lordi negativi: collega la riga di entrata al corrispondente movimento di spesa tramite il campo indice
				// Cerco il corrispondente movimento di spesa 
				string filterexp = "";
				if (CfgFn.GetNoNullInt32(R["idreg"]) == CfgFn.GetNoNullInt32(idreg_csa)) {
					filterexp = QHC.AppAnd(QHC.MCmp(R, "idreg"
							//, "idcsa_contract"
							, "idcsa_contractkind"
						),
						QHC.CmpEq("kind", "Spesa"),
						QHC.CmpEq("movkind", 3) //lordi positivi
					);
				}
				else {
					// Cerca qui di associare cosa, movimenti di entrata di incasso ritenute  da erario, 
					// a movimenti di spesa di tipo 4 (Versamento di ritenute , contributi , recuperi).
					// Quindi si tratta di movimenti  di entrata di tipo 9
					filterexp = QHC.AppAnd(QHC.MCmp(R, "idreg", "idcsa_agency", "vocecsa"
							//,"idcsa_contract"
							, "idcsa_contractkind"
						),
						QHC.CmpEq("kind", "Spesa"), QHC.CmpEq("movkind", 4));
				}

				DataRow[] RExpUnGrouped = Auto.Select(filterexp);
				DataRow rExpFound = null;
				DataRow rExpFoundFull = null;
				decimal amountIncasso = CfgFn.GetNoNullDecimal(R["amount"]);
				//cerca un raggruppamento ove il totale superi il nuovo incasso e con meno di 30 ritenute
				foreach (DataRow r in RExpUnGrouped) {

					int indice = CfgFn.GetNoNullInt32(r["indice"]);
					decimal amountPagamento = speseRaggruppate[indice]; //CfgFn.GetNoNullDecimal(r["amount"]);
					if (amountPagamento < amountReve[indice] + amountIncasso)
						continue; //il raggruppamento non ha capienza
					if (nReve[indice] < 30) {
						rExpFound = r; //Il pagamento ha capienza e meno di 30 incassi
						break;
					}

					rExpFoundFull = r; //Il pagamento ha capienza ma già 30 incassi
				}

				//
				if (rExpFound != null) {
					int indice = CfgFn.GetNoNullInt32(rExpFound["indice"]);
					//QueryCreator.MarkEvent("RExpUnGrouped =" + indice + " rexpfound = " + rExpFound["indice"]);
					R["indice"] = indice; // valorizza indice in entrata con indice del movimento di spesa      
					amountReve[indice] += amountIncasso;
					nReve[indice] += 1;
					continue;
				}

				//rExpFoundFull è valorizzato se ha capienza ma ha già 30 ritenute
				if (rExpFoundFull == null) continue;

				//Spezza rExpFoundFull in due pezzi, uno con 30 e l'altro con zero incassi
				int indiceFull = CfgFn.GetNoNullInt32(rExpFoundFull["indice"]);
				decimal amountRevePag = amountReve[indiceFull];

				decimal newAmount = 0; //Importo NUOVO movimento
				decimal oldAmount = speseRaggruppate[indiceFull]; //vecchio importo raggruppamento

				List<DataRow> oldList = groupedRows[indiceFull];
				List<DataRow> newList = new List<DataRow>();
				//Sposta i pagamenti non necessari a coprire le vecchie reversali sul nuovo pagamento (nuovoIndice)                
				foreach (DataRow r in oldList) {
					decimal amount = CfgFn.GetNoNullDecimal(r["amount"]);
					if (oldAmount - amount < amountRevePag) continue;
					newList.Add(r);
					newAmount += CfgFn.GetNoNullDecimal(r["amount"]);
					oldAmount -= CfgFn.GetNoNullDecimal(r["amount"]);
				}

				if (newAmount > amountIncasso) {
					//E' riuscito a sottrarre dal vecchio movimento un tot di movimenti atti a coprire le vecchie reversali
					//  inoltre nel movimento rimanente c'è capienza per l'incasso
					DataRow NewR = AddRowToTableGrouped(rExpFoundFull, AutoGrouped);
					int vecchioIndice = CfgFn.GetNoNullInt32(rExpFoundFull["indice"]);
					int nuovoIndice = AutoGrouped.Rows.Count - 1;
					nReve[nuovoIndice] = 0;
					amountReve[nuovoIndice] = 0;
					NewR["indice"] = nuovoIndice;
					NewR["nriga"] = nuovoIndice;
					foreach (DataRow r in newList) {
						oldList.Remove(r);
						r["indice"] = nuovoIndice;
						r["nriga"] = nuovoIndice;
					}

					//rExpFoundFull["amount"] = oldAmount; //Imposta il nuovo importo del vecchio movimento
					AutoGrouped.Rows[vecchioIndice]["amount"] = oldAmount;
					speseRaggruppate[vecchioIndice] = oldAmount;

					NewR["amount"] = newAmount; //assegna l'importo del nuovo raggruppamento
					speseRaggruppate[nuovoIndice] = newAmount;
					groupedRows[nuovoIndice] = newList;

					R["indice"] = nuovoIndice; // valorizza indice in entrata con indice del movimento di spesa      
					amountReve[nuovoIndice] += amountIncasso;
					nReve[nuovoIndice] += 1;
					continue;
				}

				DataRow rUnicoFound = null;


				//A questo punto cerchiamo un movimento singolo da splittare
				foreach (DataRow r in oldList) {
					decimal amount = CfgFn.GetNoNullDecimal(r["amount"]);
					if (amount < amountIncasso) continue;
					rUnicoFound = r;
					break;
				}

				if (rUnicoFound == null) continue;

				//Dobbiamo creare una riga in Auto con gli stessi valori di rUnicoFound
				//e suddividere l'importo di RunicoFound tra se stessa e la nuova riga cosi: amountRevePag e CfgFn.GetNoNullDecimal(rExpFoundFull["amount"])-amountRevePag
				// creare il nuovo raggruppamento e far puntare la nuova riga al nuovo raggruppamento
				newList = new List<DataRow>();

				DataRow NewRAuto = Auto.NewRow();
				foreach (DataColumn C in Auto.Columns) {
					NewRAuto[C.ColumnName] = rUnicoFound[C.ColumnName];
				}

				NewRAuto["amount"] = amountIncasso;
				rUnicoFound["amount"] = CfgFn.GetNoNullDecimal(rUnicoFound["amount"]) -
				                        CfgFn.GetNoNullDecimal(NewRAuto["amount"]);
				int indicerUnico = CfgFn.GetNoNullInt32(rUnicoFound["indice"]);
				speseRaggruppate[indicerUnico] -= amountIncasso;
				AutoGrouped.Rows[indicerUnico]["amount"] = speseRaggruppate[indicerUnico];


				// Creare il nuovo raggruppamento  
				DataRow NewRGrouped = AddRowToTableGrouped(NewRAuto, AutoGrouped);
				int nuovoIndice1 = AutoGrouped.Rows.Count - 1;
				nReve[nuovoIndice1] = 0;
				amountReve[nuovoIndice1] = 0;
				NewRGrouped["indice"] = nuovoIndice1;
				NewRGrouped["nriga"] = nuovoIndice1;

				NewRAuto["indice"] = nuovoIndice1;
				NewRAuto["nriga"] = nuovoIndice1;
				newList.Add(NewRAuto);
				groupedRows[nuovoIndice1] = newList;
				R["indice"] = nuovoIndice1; // valorizza indice in entrata con indice del movimento di spesa      
				amountReve[nuovoIndice1] += amountIncasso;
				nReve[nuovoIndice1] += 1;
				Auto.Rows.Add(NewRAuto);
				speseRaggruppate[nuovoIndice1] = amountIncasso;


			}


			//raggruppa le entrate ma distinguendo anche sul riferimento alla riga di  spesa
			for (int i = 0; i < Auto.Rows.Count; i++) {
				DataRow R = Auto.Rows[i];
				if (R["kind"].ToString() == "Spesa")
					continue;
				string filter = QHC.MCmp(R, "kind", "movkind", "indice", "idreg", "idcsa_agency",
					"idcsa_agencypaymethod", "idfin", "idupb", "description", "idacc");

				DataRow[] RGrouped = AutoGrouped.Select(filter);
				//il campo nriga del DataRow  raggruppato punta al DataRow di entrata raggruppata
				//il campo nriga nel DataRow  di entrata raggruppata è l'indice di riga del DataRow stesso underwritingappropriation
				if (RGrouped.Length == 0) {
					DataRow NewR = AddRowToTableGrouped(R, AutoGrouped);
					NewR["nriga"] = AutoGrouped.Rows.Count - 1;
					R["nriga"] = AutoGrouped.Rows.Count - 1;
				}
				else {
					RGrouped[0]["amount"] = CfgFn.GetNoNullDecimal(RGrouped[0]["amount"]) +
					                        CfgFn.GetNoNullDecimal(R["amount"]);
					R["nriga"] = RGrouped[0]["nriga"];
				}
			}

			return AutoGrouped;
		}

		/// <summary>
		/// Aggiunge alla tabella T una riga copia di R e restituisce la riga creata
		/// </summary>
		/// <param name="R">Riga da copiare</param>
		/// <param name="T">Tabella in cui creare la riga</param>
		/// <returns>copia della riga</returns>
		private DataRow AddRowToTableGrouped(DataRow R, DataTable T) {
			DataRow NewR = T.NewRow();
			foreach (DataColumn C in T.Columns) {
				NewR[C.ColumnName] = R[C.ColumnName];
			}

			T.Rows.Add(NewR);
			return NewR;
		}

		private void AddRowToTable(DataRow R, DataTable T, int i) {
			DataRow NewR = T.NewRow();
			if (T.TableName == "incomeview") {
				NewR["idinc"] = i;
			}

			if (T.TableName == "expenseview") {
				NewR["idexp"] = i;
			}

			foreach (DataColumn C in R.Table.Columns) {
				if (C.ColumnName == "idmovimento") continue;
				if (C.ColumnName == "indice") continue;
				if (C.ColumnName == "movkind") continue;
				if (C.ColumnName == "kind") continue;
				if (C.ColumnName == "idacc") continue;
				if (C.ColumnName == "codeacc") continue;
				if (C.ColumnName == "idcsa_agency") continue;
				if (C.ColumnName == "idcsa_agencypaymethod") continue;
				if (C.ColumnName == "indice") continue;
				if (C.ColumnName == "nriga") continue;
				if (C.ColumnName == "idsor") continue;
				if (C.ColumnName == "vocecsa") continue;
				if (C.ColumnName == "idunderwriting") continue;
				if ((T.TableName == "incomeview") && (C.ColumnName == "parentidexp")) continue;
				if ((T.TableName == "expenseview") && (C.ColumnName == "parentidinc")) continue;
				if (!T.Columns.Contains(C.ColumnName)) continue;
				NewR[C.ColumnName] = R[C.ColumnName];
			}

			T.Rows.Add(NewR);
		}

		/// <summary>
		/// Riempie le tabelle per i grid a partire dalla tabella in input, ai fini dell'anteprima
		/// </summary>
		/// <param name="Automatismi"></param>
		private void FillTables(DataTable Automatismi) {
			dsFinancial.expenseview.Clear();
			for (int i = 0; i < Automatismi.Rows.Count; i++) {
				DataRow R = Automatismi.Rows[i];
				AddRowToTable(R, dsFinancial.expenseview, i);
			}

			dsFinancial.incomeview.Clear();
			for (int i = 0; i < Automatismi.Rows.Count; i++) {
				DataRow R = Automatismi.Rows[i];
				AddRowToTable(R, dsFinancial.incomeview, i);
			}

			dsFinancial.expenseview.AcceptChanges();
			dsFinancial.incomeview.AcceptChanges();
		}




		/// <summary>
		/// Collega le entrate alle spesa sulla semplice base di avere pari creditore, a patto che vi sia un unico 
		///  movimento di spesa avente quel creditore in uscita. In quel caso idpayment di income viene posto uguale 
		///  all'idexp del movimento di spesa
		/// </summary>
		private void collegaEntrateaSpese() {
			int faseentratamax = getIntSys("maxincomephase");
			int fasespesamax = getIntSys("maxexpensephase");
			// Ciclo sugli automatismi di entrata per determinare l'eventuale movimento di spesa da associare
			DataTable Income = dsFinancial.Tables["income"];
			DataTable Expense = dsFinancial.Tables["expense"];
			foreach (DataRow R in Income.Select(QHC.CmpEq("nphase", faseentratamax))) {
				object vocecsa_incasso = voceCsaPerIdInc[CfgFn.GetNoNullInt32(R["idinc"])];
				if (R["idpayment"] != DBNull.Value) continue;

				object idreg_csa = R["idreg"];
				DataRow[] RExp =
					Expense.Select(QHC.AppAnd(QHC.CmpEq("nphase", fasespesamax), QHC.CmpEq("idreg", idreg_csa)));
				foreach (DataRow r in RExp) {
					object vocecsa_pagamento = voceCsaPerIdExp[CfgFn.GetNoNullInt32(r["idexp"])];
					object idcsa_agency = enteCsaPerIdExp[CfgFn.GetNoNullInt32(r["idexp"])];
					//if (!CollegaAutomatismiEnteCSA(idcsa_agency)) continue;
					if (vocecsa_pagamento == null && vocecsa_incasso == null) {
						R["idpayment"] = r["idexp"];
						break;
					}

					if (vocecsa_pagamento == null || vocecsa_incasso == null) {
						continue;
					}

					if (vocecsa_pagamento.ToString() == vocecsa_incasso.ToString()) {
						R["idpayment"] = r["idexp"];
						break;
					}

					continue;
				}


			}

			return;
		}

		private void scollegaEntratedaSpese() {
			// Questo metodo scollega le entrate collegate alle spese se il loro importo è superiore
			// in quanto potrebbe derminare dei mandati a netto negativo
			int faseentratamax = getIntSys("maxincomephase");
			int fasespesamax = getIntSys("maxexpensephase");
			// Ciclo sugli automatismi di spesa eventualmente associati a movimenti di entrata
			DataTable Expense = dsFinancial.Tables["expense"];
			DataTable Income = dsFinancial.Tables["income"];

			DataTable ExpenseYear = dsFinancial.Tables["expenseyear"];
			DataTable IncomeYear = dsFinancial.Tables["incomeyear"];
			bool unlinked = false;

			foreach (DataRow R in Expense.Select(QHC.CmpEq("nphase", fasespesamax))) {
				object idpayment = R["idexp"];
				string filter = QHC.AppAnd(QHC.CmpEq("nphase", faseentratamax), QHC.CmpEq("idpayment", idpayment));

				DataRow[] linkedIncome = Income.Select(filter);

				if (linkedIncome.Length == 0) continue;

				string filterExpenseYear = QHC.AppAnd(QHC.CmpEq("ayear", Meta.GetSys("esercizio")),
					QHC.CmpEq("idexp", idpayment));

				DataRow[] linkedExpenseYear = ExpenseYear.Select(filterExpenseYear);
				decimal amountExp = 0;

				if (linkedExpenseYear.Length > 0) {
					DataRow rExp = linkedExpenseYear[0];
					amountExp = CfgFn.GetNoNullDecimal(rExp["amount"]);
				}

				string filterIncomeYear = QHC.AppAnd(QHC.CmpEq("ayear", Meta.GetSys("esercizio")),
					QHC.FieldIn("idinc", linkedIncome, "idinc"));

				DataRow[] linkedIncomeYear = IncomeYear.Select(filterIncomeYear);
				decimal totLinked = 0;

				foreach (DataRow RLinked in linkedIncomeYear) {
					totLinked += CfgFn.GetNoNullDecimal(RLinked["amount"]);
				}

				if (totLinked > amountExp) {
					foreach (DataRow R1 in Income.Select(QHC.CmpEq("idpayment", idpayment))) {
						R1["idpayment"] = DBNull.Value;
						unlinked = true;
					}
				}
			}

			if (unlinked) {
				show(
					"Sono stati scollegati alcuni movimenti di entrata dai relativi movimenti di spesa per evitare mandati con importo netto negativo");
			}

			return;
		}

		/// <summary>
		/// Contiene gli idexp (temporanei) dei DataRow di spesa raggruppati, ha come chiave l'indice delle stesse nel relativo datatable
		/// </summary>
		private Hashtable IdExpPerIndice = new Hashtable();

		private Hashtable vocecsaPerIndice = new Hashtable();


		//Dictionary<int, Dictionary<int,decimal>> elencoSospesi = new Dictionary<int, Dictionary<int, decimal>>();

		Dictionary<int, Dictionary<int, decimal>> getElencoSospesi(DataTable t) {
			var l = new Dictionary<int, Dictionary<int, decimal>>();
			foreach (DataRow r in t.Rows) {
				//campi nbill, idreg, amount
				int nBill = (int) r["nbill"];
				int idreg = (int) r["idreg"];
				decimal amount = (decimal) r["amount"];
				if (!l.ContainsKey(idreg)) {
					l[idreg] = new Dictionary<int, decimal>();
				}

				var listaSospesi = l[idreg];
				if (!listaSospesi.ContainsKey(nBill)) {
					//show("listaSospesi " + idreg.ToString() + nBill.ToString());
					listaSospesi[nBill] = 0;
				}

				listaSospesi[nBill] += amount;
			}

			//show("sospesi " + l.Count.ToString());
			return l;
		}


		string getHash(DataRow r, string[] listaCampi) {
			if ((listaCampi != null) && (listaCampi.Length > 0))
				return string.Join("§", (from field in listaCampi select r[field].ToString()).ToArray());

			string[] fields = null;
			if (r.Table.TableName.ToString() == "epexpyear") {
				fields = new[] {"ayear", "idepexp"};
			}

			if (r.Table.TableName.ToString() == "epaccyear") {
				fields = new[] {"ayear", "idepacc"};
			}

			return string.Join("§", (from field in fields select r[field].ToString()).ToArray());
		}

		Dictionary<int, decimal> getSospesiPerAnagrafica(int idReg, Dictionary<int, Dictionary<int, decimal>> sospesi,
			decimal amountToCover) {
			var l = new Dictionary<int, decimal>();

			if (!sospesi.ContainsKey(idReg)) return l;
			var listaSospesi = sospesi[idReg];
			foreach (var nbill in listaSospesi.Keys.ToArray()) {
				//show("sospeso " + nbill.ToString() + idReg.ToString());
				decimal residuo = listaSospesi[nbill];
				if (residuo == 0) continue; //superflua ma toglierla appare controintuitivo
				decimal amount = (residuo > amountToCover) ? amountToCover : residuo; //minimo tra i due
				residuo -= amount;
				amountToCover -= amount;
				listaSospesi[nbill] = residuo;
				l[nbill] = amount;
				if (amountToCover == 0) break;
			}

			return l;
		}



		/// <summary>
		/// Genera i movimenti di entrata e di spesa a partire dalle tabelle raggruppate
		/// </summary>
		/// <param name="IoE"></param>
		/// <returns></returns>
		private bool generaMovPrincipali(string IoE, bool nonPagareNettiPositivi,
			Dictionary<int, Dictionary<int, decimal>> sospesi, bool lordi) {

			//for (int i = 0; i < SP_Result.Rows.Count; i++)
			//{
			//    DataRow R = SP_Result.Rows[i];
			//    if (i != CfgFn.GetNoNullInt32(R["nriga"]))
			//        show("Errore", R["kind"].ToString() + " indice:" + i.ToString() + 
			//                   " nriga: " + R["nriga"].ToString());

			//}
			//if (Meta.IsEmpty) return false;
			string tMain = (IoE == "I") ? "income" : "expense";
			string tMainYear = (IoE == "I") ? "incomeyear" : "expenseyear";
			string tMainLast = (IoE == "I") ? "incomelast" : "expenselast";
			string tMainBill = (IoE == "I") ? "incomebill" : "expensebill";
			string tMainSorted = (IoE == "I") ? "incomesorted" : "expensesorted";
			string tImportMain = (IoE == "I") ? "csa_import_income" : "csa_import_expense";
			string tImportMainVerPlus =
				(IoE == "I") ? "csa_importver_partition_income" : "csa_importver_partition_expense";
			string tImportMainRiepPlus =
				(IoE == "I") ? "csa_importriep_partition_income" : "csa_importriep_partition_expense";

			MetaData MetaM = Meta.Dispatcher.Get(tMain);
			MetaM.SetDefaults(dsFinancial.Tables[tMain]);

			MetaData MetaMBill = Meta.Dispatcher.Get(tMainBill);
			MetaMBill.SetDefaults(dsFinancial.Tables[tMainBill]);

			MetaData MetaL = Meta.Dispatcher.Get(tMainLast);
			MetaL.SetDefaults(dsFinancial.Tables[tMainLast]);

			MetaData MetaImputazioneMov = Meta.Dispatcher.Get(tMainYear);
			MetaImputazioneMov.SetDefaults(dsFinancial.Tables[tMainYear]);

			string maxPhaseName = (IoE == "I") ? "maxincomephase" : "maxexpensephase";
			int fasemax = getIntSys(maxPhaseName);

			string regPhaseName = (IoE == "I") ? "incomeregphase" : "expenseregphase";
			int faseCreditoreDebitore = getIntSys(regPhaseName);

			string finPhaseName = (IoE == "I") ? "incomefinphase" : "expensefinphase";
			int faseBilancio = getIntSys(finPhaseName);

			string idMovField = (IoE == "I") ? "idinc" : "idexp";
			string idParMovField = (IoE == "I") ? "parentidinc" : "parentidexp";

			string idAcc = (IoE == "I") ? "idacccredit" : "idaccdebit";
			int esercizio = getIntSys("esercizio");

			DataRow csa = DS.csa_import.Rows[0];
			string csaDescr = $"Importazione n.{csa["nimport"]}/{csa["yimport"]} {csa["description"]}";
			string descrLoV = (lordi) ? "Lordi " : "Versamenti ";

			DataTable Mov = dsFinancial.Tables[tMain];
			DataTable ImpMov = dsFinancial.Tables[tMainYear];
			DataTable ImportMov = dsFinancial.Tables[tImportMain];
			DataTable ImportMovRiepPlus = dsFinancial.Tables[tImportMainRiepPlus];
			DataTable ImportMovVerPlus = dsFinancial.Tables[tImportMainVerPlus];

			if (IoE == "E") {
				RowChange.SetOptimized(Mov, true);
				RowChange.ClearMaxCache(Mov);
				RowChange.SetOptimized(ImpMov, true);
				RowChange.ClearMaxCache(ImpMov);
				RowChange.SetOptimized(ImportMov, true);
				RowChange.ClearMaxCache(ImportMov);
				RowChange.SetOptimized(ImportMovRiepPlus, true);
				RowChange.ClearMaxCache(ImportMovRiepPlus);
				RowChange.SetOptimized(ImportMovVerPlus, true);
				RowChange.ClearMaxCache(ImportMovVerPlus);
			}

			RowChange.SetOptimized(dsFinancial.Tables[tMainSorted], true);
			RowChange.ClearMaxCache(dsFinancial.Tables[tMainSorted]);


			DataTable AllPaymethod = Conn.RUN_SELECT("paymethod", "*", null, null, null, true);


			//fase classificazione MIUR   (<= 0 se non presente)
			int faseSortingPARENT = DetectFaseSortingParent(IoE);

			// Automatismi di entrata o spesa
			string filterAuto = (IoE == "I") ? QHC.CmpEq("kind", "Entrata") : QHC.CmpEq("kind", "Spesa");
			string kind = (IoE == "I") ? "Entrata" : "Spesa";
			//DataRow[] Auto = SP_Result.Select(filterAuto);
			EP_functions EP = new EP_functions(Meta.Dispatcher);
			object idreg_csa = Get_Registry_Csa();
			if (EP.attivo) {

				object idaccSupplierAccountForRegistry = EP.GetSupplierAccountForRegistry(null, idreg_csa);
				object idaccCustomerAccountForRegistry = EP.GetCustomerAccountForRegistry(null, idreg_csa);

				foreach (DataRow R in SP_Result.Rows) {
					if (R["kind"].ToString() != kind) continue;

					if (CfgFn.GetNoNullInt32(R["movkind"]) == 3 || // movimento spesa lordi (fase LORDI)
					    CfgFn.GetNoNullInt32(R["movkind"]) == 8) {
						// movimento spesa ritenute (negative) (fase LORDI)                                      
						// conto di debito verso fornitori (anagrafica CSA "diversi")
						R["idacc"] = idaccSupplierAccountForRegistry;
					}

					if ((CfgFn.GetNoNullInt32(R["movkind"]) == 5) || // entrata recuperi (lordi)
					    (CfgFn.GetNoNullInt32(R["movkind"]) == 7)) {
						// entrata lordi (negativi) (fase LORDI)                                         
						// conto di credito verso clienti (anagrafica CSA "diversi")
						R["idacc"] = idaccCustomerAccountForRegistry;
					}
				}
			}

			List<DataRow> Auto = new List<DataRow>();
			bool flagEsenteBancaPredefinita = LeggiFlagEsenteBancaPredefinita();
			bool _nuovaGestione = nuovaGestione();
			bool _vecchiaGestione = !_nuovaGestione;
			object csa_flaglinktoexp = Get_FlagLinkToExp();
			Dictionary<int, bool> ExpenseToPreserve = new Dictionary<int, bool>();
			for (int ii = 0; ii < SP_Result.Rows.Count; ii++) {
				DataRow R = SP_Result.Rows[ii];
				if (R["kind"].ToString() != kind) continue;

				if (movimentiRaggruppati != null) {
					var linkedCsa = movimentiRaggruppati.getLinkedToMov(R);
					if (linkedCsa.Count > 1) {
						R["description"] = csaDescr;
					}
				}

				Auto.Add(R);
				int NRIGA = CfgFn.GetNoNullInt32(R["nriga"]);
				AddVociCollegate(R);
				DataRow ParentR = null;
				object parentidmov = DBNull.Value; //All'inizio il movimento parent corrente è null
				int movkind = CfgFn.GetNoNullInt32(R["movkind"]);
				int faseIniziale = 1;
				if (R["parent_phase"] != DBNull.Value) {
					faseIniziale = CfgFn.GetNoNullInt32(R["parent_phase"]) + 1;
					parentidmov = R["parent" + idMovField];
				}


				//facciamo partire la generazione direttamente dalla fase giusta cosi non c'è bisogno poi di cancellare niente
				for (int faseCorrente = faseIniziale; faseCorrente <= fasemax; faseCorrente++) {
					if (_nuovaGestione) {
						if (kind == "E" && faseCorrente == fasemax && nonPagareNettiPositivi) {
							decimal netto = CfgFn.GetNoNullDecimal(R["netto"]);
							if (netto != 0) continue;
						}
					}

					Mov.Columns["nphase"].DefaultValue = faseCorrente;
					DataRow NewMovRow = MetaM.Get_New_Row(ParentR, Mov);
					if (_nuovaGestione && nonPagareNettiPositivi && kind == "E" && faseCorrente == fasemax - 1) {
						ExpenseToPreserve.Add(CfgFn.GetNoNullInt32(NewMovRow["idexp"]), true);
					}

					//Imposta il movimento parent tramite il livsupid. Il movimento parent è quello generato nella fase precedente
					NewMovRow[idParMovField] = parentidmov;

					//si predispone per la prossima iterazione
					parentidmov = NewMovRow[idMovField];
					ParentR = NewMovRow;
					object currIdMov = NewMovRow[idMovField];

					FillMovimento(NewMovRow, R);

					string description = NewMovRow["description"].ToString();
					if (!description.Contains(descrLoV))
						description = "Fase " + descrLoV + description;
					if (description.Length > 150) description = description.Substring(0, 150);
					NewMovRow["description"] = description;

					NewMovRow["nphase"] = faseCorrente;

					if (faseCorrente < faseCreditoreDebitore) {
						NewMovRow["idreg"] = DBNull.Value;
					}

					if (movkind == 1 || movkind == 2 || movkind == 4 ||
					    movkind == 5 || movkind == 6 || movkind == 8 ||
					    movkind == 9 || movkind == 10 || movkind == 11 || movkind == 12 ||
					    movkind == 13 || movkind == 14 || movkind == 15 || movkind == 16 || movkind == 17 ||
					    movkind == 18 || movkind == 19) {
						if (!_nuovaGestione)
							NewMovRow["autokind"] = 20; //Ritenute/Contributi/Recuperi da Importazione Stipendi CSA
						else
							NewMovRow["autokind"] = 31;

					}

					if ((movkind == 3) || (movkind == 7)) {
						if (!_nuovaGestione)
							NewMovRow["autokind"] = 21; //Lordo da Importazione Stipendi CSA (movimento principale, 
						//marcato come auto solo per consentire mandati automatici)
						else
							NewMovRow["autokind"] = 30;
					}

					if (movkind == 1) {
						// serve in fase di trasmissione, a generare dettagli scritture con                    
						NewMovRow["autocode"] = R["idcsa_agency"]; // anagrafiche distinte
					}


					//Se c'è la configurazione apposita e se  il movimento è di entrata, lo collega alla spesa corrispondente 
					// al campo "indice" della tabella raggruppata

					if ((IoE == "I") && (_nuovaGestione || csa_flaglinktoexp.ToString() == "S")) {
						if (R["indice"] != DBNull.Value)
							if (IdExpPerIndice[CfgFn.GetNoNullInt32(R["indice"])] != null) {
								NewMovRow["idpayment"] = IdExpPerIndice[CfgFn.GetNoNullInt32(R["indice"])];
							}
							else {
								show("Errore di programma, indice interno non trovato");
							}
					}

					//Se sta generando questa fase, deve generare i finanziamenti
					if ((faseCorrente == faseBilancio) && (IoE == "E")) { //&& R["idmovimento"] != DBNull.Value
						//Riempimento UnderWritingAppropriation
						FillUnderwritingAppropriation(NRIGA, NewMovRow);
					}

					R["idmovimento"] =
						currIdMov; //r["idmovimento"] è valorizzata con l'id del mov. di spesa corrispondente alla riga della sp considerata

					if (faseCorrente == faseSortingPARENT) {
						FillMovSortedFaseParent(NRIGA, IoE, NewMovRow);
					}

					//QueryCreator.MarkEvent($"reached NRIGA {NRIGA}-{R["indice"]}-fase {faseCorrente}");
					if (faseCorrente == fasemax) {
						if (R["indice"] != DBNull.Value) {
							int indice = CfgFn.GetNoNullInt32(R["indice"]);
							if (IoE == "E") {
								voceCsaPerIdExp[currIdMov] = SP_Result.Rows[indice]["vocecsa"];
								enteCsaPerIdExp[currIdMov] = SP_Result.Rows[indice]["idcsa_agency"];
							}
							else {
								voceCsaPerIdInc[currIdMov] = SP_Result.Rows[indice]["vocecsa"];
							}

							if (IoE == "E" && R["indice"] != DBNull.Value) {
								IdExpPerIndice[indice] = currIdMov;
							}
						}

						DataRow NewLastRow = MetaL.Get_New_Row(NewMovRow, dsFinancial.Tables[tMainLast]);
						if (IoE == "E") {
							object codicecreddeb = R["idreg"];
							DataRow ModPagam = null;
							if (!lordi) { //if (movkind == 4)
								// versamento imposte o recuperi
								// modalità pagamento Ente CSA
								// solo se non deve essere a regolarizzazione
								if (agency_not_use_nbill(R["idcsa_agency"])) {
									ModPagam = GetModalitaPagamento(codicecreddeb, R["idcsa_agency"],
										R["idcsa_agencypaymethod"]);
								}
							}

							if ((ModPagam == null) && (!_nuovaGestione)) {
								string key = codicecreddeb.ToString();
								if (__myModPagam.ContainsKey(key)) {
									ModPagam = __myModPagam[key];
								}
								else {
									ModPagam = CfgFn.ModalitaPagamentoDefault(Conn, codicecreddeb);
									__myModPagam[key] = ModPagam;
								}
							}

							if ((ModPagam == null) && (!_nuovaGestione)) {
								object registry = GetTitleForIdReg(codicecreddeb);
								show(this,
									"E' necessario che sia definita almeno una modalità di pagamento per il percipiente " +
									"\"" + registry.ToString() + "\"\n\n" +
									"Dati non salvati", "Errore", MessageBoxButtons.OK);
								return false;
							}

							NewLastRow["flag"] = 0;
							int datiModPagam = 0;
							object idchargehandling = DBNull.Value;
							if (ModPagam != null) { // vecchia gestione o pagamenti non a regolarizzazione
								datiModPagam = CfgFn.GetNoNullInt32(ModPagam["flag"]);
								idchargehandling = ModPagam["idchargehandling"];
							}
							else {
								// nuova gestione
								datiModPagam = CfgFn.GetNoNullInt32(Get_FlagEsenteSpese_CSA());
								idchargehandling = Get_idchargehandling_CSA();
							}

							NewLastRow["idchargehandling"] = idchargehandling;
							// show("sospeso " + R["nbill"].ToString() + " " + "anagr." + codicecreddeb.ToString());
							//show("nuova gestione" +_nuovaGestione.ToString());
							bool regolarizzazioneEffettuata = false;
							if (_nuovaGestione) {
								// Verifico l'esistenza di sospesi multipli
								decimal amount = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(R["amount"]));
								//show(elencoSospesi.ToArray().ToString());
								decimal netto = CfgFn.GetNoNullDecimal(R["netto"]);

								if (netto != 0) {
									var bill = getSospesiPerAnagrafica(CfgFn.GetNoNullInt32(codicecreddeb), sospesi,
										amount);
									if (bill.Keys.Count == 1) {
										var Bill = bill.First();
										NewLastRow["nbill"] = Bill.Key;
										NewLastRow["flag"] = CfgFn.GetNoNullInt32(NewLastRow["flag"]) | 1;
										regolarizzazioneEffettuata = true;
									}

									if (bill.Keys.Count > 1) {
										foreach (int nBill in bill.Keys) {
											var newBill = MetaMBill.Get_New_Row(NewMovRow,
												dsFinancial.Tables[tMainBill]);
											newBill["nbill"] = nBill;
											newBill["ybill"] = esercizio;
											newBill["amount"] = bill[nBill];
											NewLastRow["flag"] = CfgFn.GetNoNullInt32(NewLastRow["flag"]) | 1;
											regolarizzazioneEffettuata = true;
											//show("ripartizione sospeso su movimento " + NewLastRow["nbill"].ToString() + " " + "anagr." + codicecreddeb.ToString());
										}
									}

									if ((bill.Keys.Count == 0) && (R["nbill"] != DBNull.Value)) {
										NewLastRow["nbill"] = R["nbill"];
										NewLastRow["flag"] = CfgFn.GetNoNullInt32(NewLastRow["flag"]) | 1;
										regolarizzazioneEffettuata = true;
									}

									// Questo caso include la fase lordi, nei casi in cui non sia stato impostato un sospeso
									if ((bill.Keys.Count == 0) && (R["nbill"] == DBNull.Value)) {
										string key = codicecreddeb.ToString();
										if (__myModPagam.ContainsKey(key)) {
											ModPagam = __myModPagam[key];
										}
										else {
											ModPagam = CfgFn.ModalitaPagamentoDefault(Conn, codicecreddeb);
											__myModPagam[key] = ModPagam;
										}
									}
								}

								NewLastRow["paymethod_flag"] = 0;
								//show("sospeso su movimento " + NewLastRow["nbill"].ToString() + " " + "anagr." + codicecreddeb.ToString());
							}

							if (ModPagam != null && regolarizzazioneEffettuata == false) {
								#region riempimento mod. pagamento

								//aggiungere le informazioni della modalità di pagamento
								NewLastRow["idregistrypaymethod"] = ModPagam["idregistrypaymethod"];
								NewLastRow["idpaymethod"] = ModPagam["idpaymethod"];
								NewLastRow["iban"] = ModPagam["iban"];
								NewLastRow["cin"] = ModPagam["cin"];
								NewLastRow["idbank"] = ModPagam["idbank"];
								NewLastRow["idcab"] = ModPagam["idcab"];
								NewLastRow["cc"] = ModPagam["cc"];
								NewLastRow["iddeputy"] = ModPagam["iddeputy"];
								NewLastRow["refexternaldoc"] = ModPagam["refexternaldoc"];
								DataRow RImport = null;
								if (DS.csa_import.Rows.Count>0)  
									 RImport = DS.csa_import.Rows[0];
								// Pagamento Lordi- Ritenute Negative - Recuperi negativi, metto eventuale riferimento CBI scritto nell'importazione
								// dovrebbe apparire nel flusso solo in caso di pagamento cumulativo con disposizione
								// esterna allegata
								if ((RImport!=null)&&
									
									((movkind == 3 /*3 mov. spesa lordi (positivi)*/ )||
									(movkind == 8 /*8 mov. spesa ritenute  (negativi) */ )||
									(movkind == 16 /*16 mov. spesa recuperi diretti (negativi)*/))&&

									(CfgFn.GetNoNullInt32(codicecreddeb) == CfgFn.GetNoNullInt32(idreg_csa))&&
									(RImport["refexternaldoc"]!=DBNull.Value)) {
											NewLastRow["paymentdescr"] = RImport["refexternaldoc"];
								}
								else {
											NewLastRow["paymentdescr"] = ModPagam["paymentdescr"];
								}
							
								NewLastRow["biccode"] = ModPagam["biccode"];
								NewLastRow["extracode"] = ModPagam["extracode"];

								object idpaymethod = ModPagam["idpaymethod"];
								string filterpaymethod = QHC.CmpEq("idpaymethod", idpaymethod);

								//DataTable TPaymethod = Conn.RUN_SELECT("paymethod", "*", null, filterpaymethod, null, true);
								DataRow[] pmethods = AllPaymethod.Select(filterpaymethod);
								if (pmethods.Length > 0) {
									object paymethod_allowdeputy = pmethods[0]["allowdeputy"];
									object paymethod_flag = pmethods[0]["flag"];
									NewLastRow["paymethod_allowdeputy"] = paymethod_allowdeputy;
									NewLastRow["paymethod_flag"] = paymethod_flag;
								}

								#endregion
							}

							if (flagEsenteBancaPredefinita) {
								int flag = CfgFn.GetNoNullInt32(NewLastRow["flag"]);
								int flag_exemption = (CfgFn.GetNoNullInt32(NewLastRow["flag"]) & 0xF7) |
								                     ((datiModPagam & 1) << 3);
								NewLastRow["flag"] = flag_exemption;
							}



						}

						NewLastRow[idAcc] = R["idacc"];

						FillMovSortedFaseMAX(NRIGA, IoE, NewMovRow); // inserisce le classificazioni 

						if ((IoE == "E") && _vecchiaGestione) {
							if (R["parentidexp"] == DBNull.Value) {
								//Riempimento UnderWritingPayment a partire dai finanziamenti delle righe non raggruppate
								FillUnderwritingPayment(NRIGA, NewMovRow);
							}
							else {
								CercaFinanziamentoCassa(NRIGA, NewMovRow);
								// if movkind == 3
								// si tratta del pagamento del lordo di una prestazione agganciata 
								// a un movimento finanziario di costo specificato nel Regola specifica CSA
								// in questo caso il costo di eventuali contributi deve essere attributo secondo una delle due modalità di seguito descritte:
								// 1) se i contributi sono a loro volta agganciati a specifici impegni, vanno attributi ai finanziamenti degli impegni
								// 2) se non sono agganciati a specifici impegni, il loro costo deve essere ripartito tra gli stessi 
								// finanziamenti del movimento di spesa del Regola specifica CSA
								// RipartisciContributiRegola specifica CSA(R);

							}
						}
					}

					DataRow NewImpMov = ImpMov.NewRow();

					FillImputazioneMovimento(NewImpMov, R);
					NewImpMov[idMovField] = currIdMov;
					NewImpMov["ayear"] = esercizio;

					if (faseCorrente < faseBilancio) {
						NewImpMov["idfin"] = DBNull.Value;
						NewImpMov["idupb"] = DBNull.Value;
					}

					ImpMov.Rows.Add(NewImpMov);

					object idcsa_import = _nuovaGestione ? R["idcsa_import"] : DS.csa_import.Rows[0]["idcsa_import"];

					DataRow NewImportMovRow = ImportMov.NewRow();
					FillImportMov(NewImportMovRow, R, idcsa_import);
					NewImportMovRow[idMovField] = currIdMov; // R["idmovimento"];

					ImportMov.Rows.Add(NewImportMovRow);

					if (_nuovaGestione) {
						if (movimentiRaggruppati == null) {
							if (R["idver"] != DBNull.Value) {
								DataRow NewImportMovPlusRow = ImportMovVerPlus.NewRow();
								FillImportMov(NewImportMovPlusRow, R, idcsa_import);
								NewImportMovPlusRow[idMovField] =
									currIdMov; //R["idmovimento"];//R è la stessa della riga di spesa collegata alla riga della sp in oggetto
								ImportMovVerPlus.Rows.Add(NewImportMovPlusRow);

							}
							else { // Riepiloghi, solo fase Lordi
								DataRow NewImportMovPlusRow = ImportMovRiepPlus.NewRow();
								FillImportMov(NewImportMovPlusRow, R, idcsa_import);
								NewImportMovPlusRow[idMovField] = currIdMov; // R["idmovimento"];
								ImportMovRiepPlus.Rows.Add(NewImportMovPlusRow);
							}
						}
						else {
							foreach (var rQuota in movimentiRaggruppati.getLinkedToMov(R)) {
								if (R["idver"] != DBNull.Value) {
									//show(/*"idriep" + rQuota.mov["idriep"].ToString() +*/ "idver " + rQuota.mov["idver"].ToString() + " curridmov " + currIdMov + " ndetail " +
									//			 rQuota.mov["ndetail"].ToString() + "amount " + rQuota.mov["amount"].ToString());
									////show(rQuota.ToString(), "quota");
									DataRow NewImportMovPlusRow = ImportMovVerPlus.NewRow();
									rQuota.mov["amount"] = rQuota.quota;
									FillImportMov(NewImportMovPlusRow, rQuota.mov, idcsa_import);
									NewImportMovPlusRow[idMovField] =
										currIdMov; //R["idmovimento"];//R è la stessa della riga di spesa collegata alla riga della sp in oggetto
									//NewImportMovPlusRow["idver"] = R["idver"];
									ImportMovVerPlus.Rows.Add(NewImportMovPlusRow);
								}
								else { // Riepiloghi, solo fase Lordi
									DataRow NewImportMovPlusRow = ImportMovRiepPlus.NewRow();
									rQuota.mov["amount"] = rQuota.quota;
									//show(/*"idriep" + rQuota.mov["idriep"].ToString() +*/ "idriep " + rQuota.mov["idriep"].ToString() + " curridmov " + currIdMov + " ndetail " +
									//			 rQuota.mov["ndetail"].ToString() + "amount " + rQuota.mov["amount"].ToString());
									//if ((rQuota.mov["idriep"]==DBNull.Value)&& (rQuota.mov["idver"] != DBNull.Value)) {

									//	 show( "curridmov " + currIdMov);
									//	show("idver " + rQuota.mov["idver"].ToString());
									//	show("movkind " + rQuota.mov["movkind"].ToString() );
									//}
									FillImportMov(NewImportMovPlusRow, rQuota.mov, idcsa_import);

									NewImportMovPlusRow[idMovField] = currIdMov; // R["idmovimento"];

									//NewImportMovPlusRow["idriep"] = R["idriep"];
									ImportMovRiepPlus.Rows.Add(NewImportMovPlusRow);
								}
							}
						}

					}
				}
			}

			return true;
		}


		private bool LeggiFlagEsenteBancaPredefinita() {
			DataTable tTreasurer = Meta.Conn.RUN_SELECT("treasurer", "*", null,
				QHS.AppAnd(QHS.CmpEq("flagdefault", "S"), QHS.BitSet("flag", 1)), null, false);
			if (tTreasurer.Rows.Count == 0) return false;
			else
				return true;
		}



		string getIdList(DataRow[] rr, string field, int threeshold) {
			Dictionary<int, bool> sl = new Dictionary<int, bool>();
			foreach (DataRow r in rr) {
				if (r.RowState == DataRowState.Deleted) continue;
				int n = CfgFn.GetNoNullInt32(r[field]);
				if (n == 0 || n >= threeshold) continue;
				if (sl.ContainsKey(n)) continue;
				sl.Add(n, true);
			}

			string res = "";
			foreach (int k in sl.Keys) {
				if (res.Length > 0) res += ",";
				res += k.ToString();
			}

			return res;
		}

		Dictionary<int, string> __regTitles = new Dictionary<int, string>();

		string GetTitleForIdReg(object idreg) {
			if (idreg == DBNull.Value)
				return "";
			int n = Convert.ToInt32(idreg);
			if (__regTitles.ContainsKey(n))
				return __regTitles[n];
			object title = Meta.Conn.DO_READ_VALUE("registry", QHS.CmpEq("idreg", idreg), "title");
			if (title == null) {
				title = "[anagrafica di codice " + idreg + "]";
			}

			__regTitles[n] = title.ToString();
			return title.ToString();
		}



		private void doSave(string kind) {
			int faseMax = CfgFn.GetNoNullInt32(Meta.GetSys("maxexpensephase"));

			GestioneAutomatismi ga = new GestioneAutomatismi(this, Meta.Conn, Meta.Dispatcher, dsFinancial,
				faseMax, faseMax, "expense", true);
			ga.GeneraClassificazioniAutomatiche(ga.DSP, true);
			ga.GeneraClassificazioniIndirette(ga.DSP, true);


			bool res = ga.GeneraAutomatismiAfterPost(true);
			if (!res) {
				show(this,
					"Si è verificato un errore o si è deciso di non salvare! L'operazione sarà terminata");
			}
			else {
				if (kind == "V") {
					//Verifica, se ci sono riepiloghi, che siano stati generati i movimenti finanziari dei riepiloghi
					int countRiep = CfgFn.GetNoNullInt32(Meta.Conn.DO_READ_VALUE("csa_importriep",QHS.CmpEq("idcsa_import", DS.csa_import.Rows[0]["idcsa_import"]), "count(*)"));
					if (countRiep > 0) {
						if (!esistonoMovFinanziari("L")) {
							show(this,
								"Non sono stati ancora generati i movimenti finanziari dei lordi, non sarà possibile generare i movimenti finanziari dei versamenti.",
								"Errore");
							dsFinancial.Clear();
							dsFinancial.AcceptChanges();
							Meta.FreshForm();
							return;
						}
					}
				}
				if (!esistonoScritture()) {
					show(this,
						"Non sono state ancora generate le scritture in PD, non sarà possibile generare i movimenti finanziari ",
						"Errore");
					return;
				}

				res = ga.doPost(Meta.Dispatcher);
				if (res) {
					show(this, "Salvataggio dei movimenti finanziari avvenuto con successo");
				}
				else {
					show(this,
						"Si è verificato un errore o si è deciso di non salvare! L'operazione sarà terminata");
				}
			}

			dsFinancial.Clear();
			dsFinancial.AcceptChanges();
			Meta.FreshForm();
		}

		private void btnVersamenti_Click(object sender, EventArgs e) {
			if (executing) return;

			btnVersamenti.Visible = false;
			executing = true;

			try {
				btnGeneraMovFin_Click(sender, e, "V");
			}
			catch {
				executing = false;
				throw;
			}

			btnVersamenti.Visible = true;
			executing = false; // Consente di rieseguire la procedura
		}

		private bool executing = false;

		bool vecchiaGestione() {
			return DS.csa_importriep_partition.Rows.Count == 0 && DS.csa_importver_partition.Rows.Count == 0;
		}

		bool nuovaGestione() {
			return DS.csa_importriep_partition.Rows.Count > 0 || DS.csa_importver_partition.Rows.Count > 0;
		}

		private void btnLordi_Click(object sender, EventArgs e) {
			if (executing) return;
			btnLordi.Visible = false;
			executing = true;
			try {
				btnGeneraMovFin_Click(sender, e, "L");
			}
			catch (Exception E) {
				executing = false;
				QueryCreator.ShowException(E);

			}

			btnLordi.Visible = true;
			executing = false; // Consente di rieseguire la procedura
		}

		private void btnScritture_Click(object sender, EventArgs e) {
			if (executing) return;
			executing = true;
			try {
				//GeneraScritture();
			}
			catch (Exception E) {
				executing = false;
				QueryCreator.ShowException(E);
			}

			executing = false; // Consente di rieseguire la procedura
		}



		bool CollegaAutomatismiEnteCSA(object idcsa_agency) {
			if (idcsa_agency == DBNull.Value) return false;
			if (entiCsa.ContainsKey(idcsa_agency)) return entiCsa[idcsa_agency];
			if (entiCsa.Count == 0) {
				DataTable Csa_Agency = Conn.RUN_SELECT("csa_agency", "*", null, null, null, false);
				foreach (DataRow RCA in Csa_Agency.Select()) {
					int flag = CfgFn.GetNoNullInt32(RCA["flag"]);
					bool collegaAutomatismi = ((flag & 1) == 0);
					entiCsa[RCA["idcsa_agency"]] = collegaAutomatismi;
				}
			}

			return entiCsa[idcsa_agency];
		}

		Dictionary<object, int> __myNBill = new Dictionary<object, int>();

		private bool CheckSospeso(object n_sospeso) {
			if ((n_sospeso == null) || (n_sospeso == DBNull.Value)) return false;
			string key = n_sospeso.ToString();
			if (__myNBill.ContainsKey(key))
				return true;

			string filtro = QHS.AppAnd(QHS.CmpEq("nbill", n_sospeso), QHS.CmpEq("ybill", Meta.GetSys("esercizio")),
				QHS.CmpEq("billkind", "D"));
			DataTable Bill = Conn.RUN_SELECT("bill", "*", null, filtro, null, true);
			if (Bill.Rows.Count == 0) return false;
			DataRow DefRow = Bill.Rows[0];
			__myNBill[key] = CfgFn.GetNoNullInt32(DefRow["nbill"]);
			return true;
		}

		// Evito di far scegliere anagrafiche non attive
		Dictionary<int, int> __myidReg = new Dictionary<int, int>();

		private object GetAnagrafica(object codice_anagrafica) {
			int key = CfgFn.GetNoNullInt32(codice_anagrafica);

			if ((codice_anagrafica == null) || (codice_anagrafica == DBNull.Value) || (key == 0)) return null;
			if (__myidReg.ContainsKey(key))
				return __myidReg[key];

			string filtro = QHS.AppAnd(QHS.CmpEq("idreg", codice_anagrafica), QHS.NullOrEq("active", "S"))  ;
			DataTable Registry = Conn.RUN_SELECT("registry", "idreg", null, filtro, null, true);
			if (Registry.Rows.Count == 0) return null;
			DataRow DefRow = Registry.Rows[0];
			__myidReg[key] = CfgFn.GetNoNullInt32(DefRow["idreg"]);
			return __myidReg[key];
		}


		Dictionary<string, DataRow> __myModPagam = new Dictionary<string, DataRow>();

		private DataRow GetModalitaPagamento(object idreg_agency, object idcsa_agency, object idcsa_agencypaymethod) {
			if ((idreg_agency == null) || (idreg_agency == DBNull.Value)) return null;
			string key = idreg_agency.ToString() + "-" + idcsa_agency.ToString() + "-" + idcsa_agencypaymethod;
			if (__myModPagam.ContainsKey(key))
				return __myModPagam[key];

			string filtro = QHS.AppAnd(QHS.CmpEq("idcsa_agency", idcsa_agency),
				QHS.CmpEq("idcsa_agencypaymethod", idcsa_agencypaymethod));
			DataTable AgencyPagam = Conn.RUN_SELECT("csa_agencypaymethod", "*", null, filtro, null, true);
			if (AgencyPagam.Rows.Count == 0) {
				// cerco la modalità di pagamento di defualt 
				__myModPagam[key] = CfgFn.ModalitaPagamentoDefault(Conn, idreg_agency);
				return __myModPagam[key];
			}

			DataRow DefRow = AgencyPagam.Rows[0];
			object idregistrypaymethod = DefRow["idregistrypaymethod"];

			string filtermodpag = QHS.AppAnd(QHS.CmpEq("idreg", idreg_agency),
				QHS.CmpEq("idregistrypaymethod", idregistrypaymethod));
			DataTable ModPagam = Conn.RUN_SELECT("registrypaymethod", "*", null, filtermodpag, null, true);


			if (ModPagam.Rows.Count == 0) {
				// cerco la modalità di pagamento di default 
				__myModPagam[key] = CfgFn.ModalitaPagamentoDefault(Conn, idreg_agency);
				return __myModPagam[key];
			}
			else {
				__myModPagam[key] = ModPagam.Rows[0];
				return ModPagam.Rows[0];
			}
		}




		private void EditEntry() {
			if (DS.csa_import.Rows.Count == 0) return;
			DataRow R = DS.csa_import.Rows[0];
			EP_functions EP = new EP_functions(Meta.Dispatcher);
			string idrelated = EP_functions.GetIdForDocument(R);
			EP.EditRelatedEntry(Meta, idrelated);
		}

		private void btnVisualizzaScritture_Click(object sender, EventArgs e) {
			if (esistonoScritture()) //esistono scritture in PD
				EditEntry();
		}

		private void btn04_Click(object sender, EventArgs e) {
			//4) Regola generale o specifica non determinato in righe versamenti
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]),
				QHS.IsNull("idcsa_contractkind"));
			string sqlCmd = " SELECT ayear as 'Eserc.', " +
			                " idver as 'Numero Versamento', " +
			                " yimport as 'Eserc. Import', " +
			                " nimport as 'Num. Import.', " +
			                " ruolocsa as 'Ruolo CSA', " +
			                " capitolocsa as 'Capitolo CSA', " +
			                " ente as 'Ente CSA', " +
			                " vocecsa as 'Voce CSA', " +
			                " matricola as 'Matricola', " +
			                " importo as 'Importo', " +
			                " registry as 'Anagrafica', " +
			                " agency as 'Ente', " +
			                " flagcr as 'Comp./Residui' " +
			                " FROM csa_importverview " +
			                " WHERE  " + filter;

			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati(sender, e, T, "csa_importver", "default", filter);
			}

		}

		private void btn02_Click(object sender, EventArgs e) {
			//2) Esercizio non valorizzato versamenti
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]),
				QHS.IsNull("ayear"));
			string sqlCmd = " SELECT ayear as 'Eserc.', " +
			                " idver as 'Numero Versamento', " +
			                " yimport as 'Eserc. Import', " +
			                " nimport as 'Num. Import.', " +
			                " ruolocsa as 'Ruolo CSA', " +
			                " capitolocsa as 'Capitolo CSA', " +
			                " ente as 'Ente CSA', " +
			                " vocecsa as 'Voce CSA', " +
			                " matricola as 'Matricola', " +
			                " importo as 'Importo', " +
			                " registry as 'Anagrafica', " +
			                " agency as 'Ente', " +
			                " flagcr as 'Comp./Residui' " +
			                " FROM csa_importverview " +
			                " WHERE  " + filter;

			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati(sender, e, T, "csa_importver", "default", filter);
			}

		}

		private void btn20_Click(object sender, EventArgs e) {
			//20) Elenco contributi con importo negativo
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]),
				QHS.NullOrEq("flagclawback", "N"), QHS.DoPar(QHS.AppOr(
					QHS.IsNotNull("idcsa_contractkinddata"), QHS.IsNotNull("idcsa_contracttax"))),
				QHS.CmpLt("importo", 0));
			string sqlCmd = " SELECT 'Contributo' as 'Tipo'," +
			                " ayear as 'Eserc.', " +
			                " idver as 'Numero Versamento', " +
			                " yimport as 'Eserc. Import', " +
			                " nimport as 'Num. Import.', " +
			                " ruolocsa as 'Ruolo CSA', " +
			                " capitolocsa as 'Capitolo CSA', " +
			                " ente as 'Ente CSA', " +
			                " vocecsa as 'Voce CSA', " +
			                " matricola as 'Matricola', " +
			                " importo as 'Importo', " +
			                " registry as 'Anagrafica', " +
			                " agency as 'Ente', " +
			                " idcsa_agencypaymethod as ' # Mod. Pagamento Ente', " +
			                " codefin_cost as 'Cod. Capitolo Costo'," +
			                " codefin_income as 'Cod. Capitolo Entrata'," +
			                " codefin_expense as 'Cod. Capitolo Spesa'," +
			                " codefin_incomeclawback as 'Cod. Capitolo Entrata Interno'," +
			                " flagcr as 'Comp./Residui' " +
			                " FROM csa_importverview " +
			                " WHERE  " + filter;


			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati(sender, e, T, "csa_importver", "default", filter);
			}
		}
		
		private void btn14_Click(object sender, EventArgs e) {
			//14)   Errata configurazione ripartizione delle regole specifiche CSA
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("C.active", "S"), QHS.CmpEq("C.ayear", Conn.GetSys("esercizio")));
			string sqlCmd = "";
			if (!usePartition) {
				sqlCmd =
					"SELECT C.idcsa_contract , C.ycontract as 'Eserc.Regola specifica CSA', C.ncontract as Numero, sum(CE.quota) " +
					" from csa_contractexpense CE " +
					"	join csa_contract C on C.idcsa_contract=CE.idcsa_contract and CE.ayear=C.ayear " +
					" where " + filter +
					" group by  C.ycontract,C.ncontract, C.idcsa_contract  " +
					"	having abs(sum(CE.quota)-1) > 0.000001";
			}
			else {
				sqlCmd =
					"SELECT C.idcsa_contract , C.ycontract as 'Eserc.Regola specifica CSA', C.ncontract as Numero, sum(CP.quota) " +
					" from csa_contract_partition CP " +
					"	join csa_contract C on C.idcsa_contract=CP.idcsa_contract and CP.ayear=C.ayear " +
					" where " + filter +
					" group by  C.ycontract,C.ncontract, C.idcsa_contract  " +
					"	having abs(sum(CP.quota)-1) > 0.000001";
			}

			DataTable TT = Conn.SQLRunner(sqlCmd);
			if (TT == null) return;
			if (TT.Rows.Count == 0) return;

			string filter2 =
				QHS.AppAnd(QHS.FieldIn("idcsa_contract", TT.Select()).Replace("idcsa_contract", "C.idcsa_contract"),
					filter);
			if (!usePartition) {
				sqlCmd = "select  C.ycontract as 'Eserc.Regola specifica CSA', " +
				         "C.ncontract as Numero, sum(quota) as Quota, " +
				         "C.title as 'Regola specifica CSA', C.description as Descrizione " +
				         "from csa_contractexpense CE " +
				         "	join csa_contract C on C.idcsa_contract=CE.idcsa_contract and CE.ayear=C.ayear " +
				         " where " + filter2 +
				         " group by C.idcsa_contract, C.ayear, C.ycontract,C.ncontract ,C.description,C.title " +
				         "	having abs(sum(quota)-1) > 0.000001";
			}
			else {
				sqlCmd = "select  C.ycontract as 'Eserc.Regola specifica CSA', " +
				         "C.ncontract as Numero, sum(quota) as Quota, " +
				         "C.title as 'Regola specifica CSA', C.description as Descrizione " +
				         "from csa_contract_partition CP " +
				         "	join csa_contract C on C.idcsa_contract=CP.idcsa_contract and CP.ayear=C.ayear " +
				         " where " + filter2 +
				         " group by C.idcsa_contract, C.ayear, C.ycontract,C.ncontract ,C.description,C.title " +
				         "	having abs(sum(quota)-1) > 0.000001";
			}

			// show(sqlCmd);
			string filtercontract = QHS.AppAnd(QHS.FieldIn("idcsa_contract", TT.Select()),
				QHS.CmpEq("ayear", Conn.GetSys("esercizio")));
			DataTable T = Conn.SQLRunner(sqlCmd);
			if (T != null) {
				VisualizzaDati(sender, e, T, "csa_contract", "default", filtercontract);
			}
		}

		private void btn15_Click(object sender, EventArgs e) {
			//15) Errata configurazione ripartizione unica dei contributi
			if (Meta.IsEmpty) return;
			if (rdbExpToListing.Checked) {
				show("La modalità di verifica 'elenco' non è disponibile per questo controllo.", "Avviso");
				return;
			}

			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("C.active", "S"), QHS.CmpEq("C.ayear", Conn.GetSys("esercizio")));
			string sqlCmd = "";
			if (!usePartition)
				sqlCmd =
					"select C.idcsa_contract,  C.ycontract as 'Eserc.Regola specifica CSA',C.ncontract as Numero, " +
					" C.description as 'Descrizione',vocecsa, sum(quota) as Quota " +
					" from csa_contracttaxexpense CTE " +
					" join csa_contracttax CT on CTE.idcsa_contract=CT.idcsa_contract and " +
					" CTE.idcsa_contracttax = CT.idcsa_contracttax and " +
					" CTE.ayear = CT.ayear " +
					" join csa_contract C on C.idcsa_contract=CTE.idcsa_contract and CTE.ayear=C.ayear " +
					" where " + filter +
					" group by C.idcsa_contract,  C.ycontract,C.ncontract ,vocecsa, C.description " +
					" having abs(sum(quota)-1) > 0.000001 ";
			else {
				sqlCmd =
					"select C.idcsa_contract,  C.ycontract as 'Eserc.Regola specifica CSA',C.ncontract as Numero, " +
					" C.description as 'Descrizione',vocecsa, sum(quota) as Quota " +
					" from csa_contracttax_partition CTE " +
					" join csa_contracttax CT on CTE.idcsa_contract=CT.idcsa_contract and " +
					" CTE.idcsa_contracttax = CT.idcsa_contracttax and " +
					" CTE.ayear = CT.ayear " +
					" join csa_contract C on C.idcsa_contract=CTE.idcsa_contract and CTE.ayear=C.ayear " +
					" where " + filter +
					" group by C.idcsa_contract,  C.ycontract,C.ncontract ,vocecsa, C.description " +
					" having abs(sum(quota)-1) > 0.000001 ";
			}


			DataTable TT = Conn.SQLRunner(sqlCmd);
			if (TT == null) return;
			if (TT.Rows.Count == 0) return;

			string filter2 =
				QHS.AppAnd(QHS.FieldIn("idcsa_contract", TT.Select()).Replace("idcsa_contract", "C.idcsa_contract"),
					filter);

			if (!usePartition)

				sqlCmd =
					"select    C.ycontract as 'Eserc.Regola specifica CSA', C.ncontract as Numero, vocecsa as 'Voce CSA', " +
					"sum(quota) as Quota,  " +
					"C.title as 'Regola specifica CSA', C.description as Descrizione " +
					" from csa_contracttaxexpense CTE " +
					" join csa_contracttax CT on CTE.idcsa_contract=CT.idcsa_contract and " +
					" CTE.idcsa_contracttax = CT.idcsa_contracttax and " +
					" CTE.ayear = CT.ayear " +
					" join csa_contract C on C.idcsa_contract=CTE.idcsa_contract and CTE.ayear=C.ayear " +
					" where " + filter2 +
					" group by C.idcsa_contract, C.ayear, C.ycontract,C.ncontract ,vocecsa, C.description,C.title " +
					" having abs(sum(quota)-1) > 0.000001 ";
			else
				sqlCmd =
					"select    C.ycontract as 'Eserc.Regola specifica CSA', C.ncontract as Numero, vocecsa as 'Voce CSA', " +
					"sum(quota) as Quota,  " +
					"C.title as 'Regola specifica CSA', C.description as Descrizione " +
					" from csa_contracttax_partition CTE " +
					" join csa_contracttax CT on CTE.idcsa_contract=CT.idcsa_contract and " +
					" CTE.idcsa_contracttax = CT.idcsa_contracttax and " +
					" CTE.ayear = CT.ayear " +
					" join csa_contract C on C.idcsa_contract=CTE.idcsa_contract and CTE.ayear=C.ayear " +
					" where " + filter2 +
					" group by C.idcsa_contract, C.ayear, C.ycontract,C.ncontract ,vocecsa, C.description,C.title " +
					" having abs(sum(quota)-1) > 0.000001 ";
			//show(sqlCmd);
			DataTable T = Conn.SQLRunner(sqlCmd);

			string filtercontract = QHS.AppAnd(QHS.FieldIn("idcsa_contract", TT.Select()),
				QHS.CmpEq("ayear", Conn.GetSys("esercizio")));

			if (T != null) {
				VisualizzaDati(sender, e, T, "csa_contracttax", "elenco", filtercontract);
			}
		}

		private void btn21_Click(object sender, EventArgs e) {
			//21) Righe Versamenti Associate a Config. Contributi e non a Configurazione Scheda Voce CSA
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]),
				QHS.DoPar(QHS.AppOr(QHS.IsNotNull("idcsa_contractkinddata"), QHS.IsNotNull("idcsa_contracttax"))),
				QHS.IsNull("idcsa_incomesetup"));

			string sqlCmd =
				" SELECT CASE flagclawback WHEN 'S' THEN 'Recupero' ELSE 'Ritenuta/Contributo' END as 'Tipo'," +
				" ayear as 'Eserc.', " +
				" idver as 'Numero Versamento', " +
				" yimport as 'Eserc. Import', " +
				" nimport as 'Num. Import.', " +
				" ruolocsa as 'Ruolo CSA', " +
				" capitolocsa as 'Capitolo CSA', " +
				" ente as 'Ente CSA', " +
				" vocecsa as 'Voce CSA', " +
				" matricola as 'Matricola', " +
				" importo as 'Importo', " +
				" registry as 'Anagrafica', " +
				" flagcr as 'Comp./Residui', " +
				" idcsa_contracttax as 'Conf. Contributi CSA  - Regola specifica ', " +
				" idcsa_contractkinddata as 'Attribuzione da Regola generale CSA', " +
				" idcsa_incomesetup as 'Conf. Incassi'" +
				" FROM csa_importverview " +
				" WHERE  " + filter;


			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati(sender, e, T, "csa_importver", "default", filter);
			}

		}

		private void btn22_Click(object sender, EventArgs e) {
			//22) Righe Versamenti Associate non configurate correttamente nè come Contributi, nè come Ritenute, nè Recuperi
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]),
				QHS.NullOrEq("flagclawback", "N"),
				QHS.IsNull("idcsa_contractkinddata"),
				QHS.IsNull("idcsa_contracttax"),
				QHS.IsNull("idfin_income"), QHS.IsNull("idfin_expense"));

			string sqlCmd =
				" SELECT CASE flagclawback WHEN 'S' THEN 'Recupero' ELSE 'Ritenuta/Contributo' END as 'Tipo'," +
				" ayear as 'Eserc.', " +
				" idver as 'Numero Versamento', " +
				" yimport as 'Eserc. Import', " +
				" nimport as 'Num. Import.', " +
				" ruolocsa as 'Ruolo CSA', " +
				" capitolocsa as 'Capitolo CSA', " +
				" ente as 'Ente CSA', " +
				" vocecsa as 'Voce CSA', " +
				" matricola as 'Matricola', " +
				" importo as 'Importo', " +
				" registry as 'Anagrafica', " +
				" flagcr as 'Comp./Residui', " +
				" idcsa_contracttax as 'Conf. Contributi CSA  - Regola specifica ', " +
				" idcsa_contractkinddata as 'Attribuzione da Regola generale CSA', " +
				" idcsa_incomesetup as 'Conf. Incassi'" +
				" FROM csa_importverview " +
				" WHERE  " + filter;


			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati(sender, e, T, "csa_importver", "default", filter);
			}
		}


		private void btn23_Click(object sender, EventArgs e) {
			//23) Recuperi negativi su partita di giro : idfin_cost per movimento di spesa  di ricavo
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]), QHS.CmpEq("flagclawback", "S"),
				QHS.IsNull("idfin_cost"),
				QHS.CmpLt("importo", 0));

			string sqlCmd =
				" SELECT CASE flagclawback WHEN 'S' THEN 'Recupero' ELSE 'Ritenuta/Contributo' END as 'Tipo'," +
				" ayear as 'Eserc.', " +
				" idver as 'Numero Versamento', " +
				" yimport as 'Eserc. Import', " +
				" nimport as 'Num. Import.', " +
				" ruolocsa as 'Ruolo CSA', " +
				" capitolocsa as 'Capitolo CSA', " +
				" ente as 'Ente CSA', " +
				" vocecsa as 'Voce CSA', " +
				" matricola as 'Matricola', " +
				" importo as 'Importo', " +
				" registry as 'Anagrafica', " +
				" flagcr as 'Comp./Residui', " +
				" idcsa_contracttax as 'Conf. Contributi CSA  - Regola specifica ', " +
				" idcsa_contractkinddata as 'Attribuzione da Regola generale CSA', " +
				" idcsa_incomesetup as 'Conf. Incassi'" +
				" FROM csa_importverview " +
				" WHERE  " + filter;


			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati(sender, e, T, "csa_importver", "default", filter);
			}
		}


		private void btn24_Click(object sender, EventArgs e) {
			//24) Righe versamento con voce CSA ai fini del raggruppamento aventi configurazione non omogenea  
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]),
				QHS.IsNotNull("vocecsaunified"));

			string filter1 =
				" ( SELECT  COUNT(*) from csa_importverview T2 WHERE " +
				" ISNULL(T2.vocecsaunified, T2.vocecsa)= T.vocecsaunified AND " +
				" T2.idcsa_import= T.idcsa_import AND " +
				" (isnull(T.ente,'') <>isnull(T2.ente,'') OR " +
				" isnull(T.flagcr,'') <>isnull(T2.flagcr,'') OR " +
				" isnull(T.ayear,0) <>isnull(T2.ayear,0) OR " +
				" isnull(T.idcsa_agency,0) <>isnull(T2.idcsa_agency,0) OR " +
				" isnull(T.idfin_income,0) <>isnull(T2.idfin_income,0) OR " +
				" isnull(T.idacc_debit,'') <>isnull(T2.idacc_debit,'') OR " +
				" isnull(T.idfin_expense,0) <>isnull(T2.idfin_expense,0) OR " +
				" isnull(T.idacc_expense,'') <>isnull(T2.idacc_expense,'') OR " +
				" isnull(T.idfin_incomeclawback,0) <>isnull(T2.idfin_incomeclawback,0) OR " +
				" isnull(T.idacc_internalcredit,0) <>isnull(T2.idacc_internalcredit,0) OR " +
				" isnull(T.idreg_agency,0) <>isnull(T2.idreg_agency,0) OR " +
				" isnull(T.idcsa_agencypaymethod,0) <>isnull(T2.idcsa_agencypaymethod,0) OR " +
				" isnull(T.idexp_cost,0) <>isnull(T2.idexp_cost,0) OR " +
				" isnull(T.idfin_cost,0) <>isnull(T2.idfin_cost,0) OR " +
				" isnull(T.idacc_cost,'') <>isnull(T2.idacc_cost,'') OR " +
				" isnull(T.flagclawback,'') <>isnull(T2.flagclawback,'') OR " +
				" isnull(T.idreg,0) <>isnull(T2.idreg,0) OR " +
				" isnull(T.idupb,'') <>isnull(T2.idupb,'') OR " +
				" isnull(T.idacc_revenue,'') <>isnull(T2.idacc_revenue,'') OR " +
				" isnull(T.competency,'') <>isnull(T2.competency,'') OR " +
				" isnull(T.idacc_agency_credit,'') <>isnull(T2.idacc_agency_credit,'') OR " +
				" isnull(T.flagdirectcsaclawback,'') <>isnull(T2.flagdirectcsaclawback,'') OR " +
				" isnull(T.idsor_siope_income,0) <>isnull(T2.idsor_siope_income,0) OR " +
				" isnull(T.idsor_siope_expense,0) <>isnull(T2.idsor_siope_expense,0) OR " +
				" isnull(T.idsor_siope_cost,0) <>isnull(T2.idsor_siope_cost,0) OR " +
				" isnull(T.idunderwriting,0) <>isnull(T2.idunderwriting,0) " +
				" )) >0 ";

			filter = QHS.AppAnd(filter, filter1);

			string sqlCmd =
				" SELECT CASE flagclawback WHEN 'S' THEN 'Recupero' ELSE 'Ritenuta/Contributo' END as 'Tipo'," +
				" ayear as 'Eserc.', " +
				" idver as 'Numero Versamento', " +
				" yimport as 'Eserc. Import', " +
				" nimport as 'Num. Import.', " +
				" ruolocsa as 'Ruolo CSA', " +
				" capitolocsa as 'Capitolo CSA', " +
				" ente as 'Ente CSA', " +
				" vocecsa as 'Voce CSA', " +
				" matricola as 'Matricola', " +
				" importo as 'Importo', " +
				" registry as 'Anagrafica', " +
				" agency as 'Ente', " +
				" idcsa_agencypaymethod as ' # Mod. Pagamento Ente', " +
				" codefin_cost as 'Cod. Capitolo Costo'," +
				" codefin_income as 'Cod. Capitolo Entrata'," +
				" codefin_expense as 'Cod. Capitolo Spesa'," +
				" codefin_incomeclawback as 'Cod. Capitolo Entrata Interno'," +
				" flagcr as 'Comp./Residui' " +
				" FROM csa_importverview T " +
				" WHERE  " + filter;

			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati(sender, e, T, "csa_importver", "default", filter);
			}
		}

		private void btn10_Click(object sender, EventArgs e) {
			// 10) Recupero su partita di giro : idfin_incomeclawback per movimento di entrata post- versamento 
			if (Meta.IsEmpty) return;

			if (usePartition) return; //con l'uso delle ripartizioni non abbiamo piu' i recuperi su partite di giro
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]),
				QHS.CmpEq("flagclawback", "S"), QHS.CmpEq("flagdirectcsaclawback", "N"),
				QHS.IsNull("idfin_incomeclawback"));


			string sqlCmd =
				" SELECT CASE flagclawback WHEN 'S' THEN 'Recupero' ELSE 'Ritenuta/Contributo' END as 'Tipo'," +
				" ayear as 'Eserc.', " +
				" idver as 'Numero Versamento', " +
				" yimport as 'Eserc. Import', " +
				" nimport as 'Num. Import.', " +
				" ruolocsa as 'Ruolo CSA', " +
				" capitolocsa as 'Capitolo CSA', " +
				" ente as 'Ente CSA', " +
				" vocecsa as 'Voce CSA', " +
				" matricola as 'Matricola', " +
				" importo as 'Importo', " +
				" registry as 'Anagrafica', " +
				" agency as 'Ente', " +
				" idcsa_agencypaymethod as ' # Mod. Pagamento Ente', " +
				" codefin_cost as 'Cod. Capitolo Costo'," +
				" codefin_income as 'Cod. Capitolo Entrata'," +
				" codefin_expense as 'Cod. Capitolo Spesa'," +
				" codefin_incomeclawback as 'Cod. Capitolo Entrata Interno'," +
				" flagcr as 'Comp./Residui' " +
				" FROM csa_importverview " +
				" WHERE  " + filter;


			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati(sender, e, T, "csa_importver", "default", filter);
			}
		}

		private void btn09_Click(object sender, EventArgs e) {
			//9) Recupero diretto, capitolo spesa non valorizzato per le righe negative
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			// dobbiamo introdurre una distinzione nel filtro, tra chi usa le ripartizioni e chi no

			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]),
				QHS.CmpEq("flagclawback", "S"), QHS.CmpLt("importo", 0));
			if (!usePartition)
				filter = QHS.AppAnd(filter, QHS.CmpEq("flagdirectcsaclawback", "S"), QHS.IsNull("idfin_cost"));
			else {
				string filter_partition = QHS.DoPar(QHS.AppOr(
					"not exists(select * from csa_importver_partition CP where " +
					" CP.idcsa_import = csa_importverview.idcsa_import and " +
					" CP.idver = csa_importverview.idver ) ",
					" exists (select * from csa_importver_partition CP where " +
					" CP.idcsa_import = csa_importverview.idcsa_import and " +
					" CP.idver = csa_importverview.idver and " +
					" CP.idfin is null) "));
				filter = QHS.AppAnd(filter, filter_partition);
			}





			string sqlCmd =
				" SELECT CASE flagclawback WHEN 'S' THEN 'Recupero' ELSE 'Ritenuta/Contributo' END as 'Tipo'," +
				" ayear as 'Eserc.', " +
				" idver as 'Numero Versamento', " +
				" yimport as 'Eserc. Import', " +
				" nimport as 'Num. Import.', " +
				" ruolocsa as 'Ruolo CSA', " +
				" capitolocsa as 'Capitolo CSA', " +
				" ente as 'Ente CSA', " +
				" vocecsa as 'Voce CSA', " +
				" matricola as 'Matricola', " +
				" importo as 'Importo', " +
				" registry as 'Anagrafica', " +
				" agency as 'Ente', " +
				" idcsa_agencypaymethod as ' # Mod. Pagamento Ente', " +
				" codefin_cost as 'Cod. Capitolo Costo'," +
				" codefin_income as 'Cod. Capitolo Entrata'," +
				" codefin_expense as 'Cod. Capitolo Spesa'," +
				" codefin_incomeclawback as 'Cod. Capitolo Entrata Interno'," +
				" flagcr as 'Comp./Residui' " +
				" FROM csa_importverview " +
				" WHERE  " + filter;


			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati(sender, e, T, "csa_importver", "default", filter);
			}
		}

		private void btn83_Click(object sender, EventArgs e) {
			//SIOPE speculare 9
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			// dobbiamo introdurre una distinzione nel filtro, tra chi usa le ripartizioni e chi no

			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]),
				QHS.CmpEq("flagclawback", "S"), QHS.CmpLt("importo", 0));
			if (!usePartition)
				filter = QHS.AppAnd(filter, QHS.CmpEq("flagdirectcsaclawback", "S"), QHS.IsNull("idfin_cost"));
			else {
				string filter_partition = QHS.DoPar(QHS.AppOr(
					"not exists(select * from csa_importver_partition CP where " +
					" CP.idcsa_import = csa_importverview.idcsa_import and " +
					" CP.idver = csa_importverview.idver ) ",
					" exists (select * from csa_importver_partition CP where " +
					" CP.idcsa_import = csa_importverview.idcsa_import and " +
					" CP.idver = csa_importverview.idver and " +
					" CP.idfin is not null  and CP.idsor_siope is null) "));
				filter = QHS.AppAnd(filter, filter_partition);
			}





			string sqlCmd =
				" SELECT CASE flagclawback WHEN 'S' THEN 'Recupero' ELSE 'Ritenuta/Contributo' END as 'Tipo'," +
				" ayear as 'Eserc.', " +
				" idver as 'Numero Versamento', " +
				" yimport as 'Eserc. Import', " +
				" nimport as 'Num. Import.', " +
				" ruolocsa as 'Ruolo CSA', " +
				" capitolocsa as 'Capitolo CSA', " +
				" ente as 'Ente CSA', " +
				" vocecsa as 'Voce CSA', " +
				" matricola as 'Matricola', " +
				" importo as 'Importo', " +
				" registry as 'Anagrafica', " +
				" agency as 'Ente', " +
				" idcsa_agencypaymethod as ' # Mod. Pagamento Ente', " +
				" codefin_cost as 'Cod. Capitolo Costo'," +
				" codefin_income as 'Cod. Capitolo Entrata'," +
				" codefin_expense as 'Cod. Capitolo Spesa'," +
				" codefin_incomeclawback as 'Cod. Capitolo Entrata Interno'," +
				" flagcr as 'Comp./Residui' " +
				" FROM csa_importverview " +
				" WHERE  " + filter;


			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati(sender, e, T, "csa_importver", "default", filter);
			}
		}
		private void btn28_Click(object sender, EventArgs e) {
			//28) Ente CSA associato ad anagrafiche non attive in righe versamenti 
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.CmpEq("idcsa_import", Curr["idcsa_import"]);
			filter +=
				" AND EXISTS (SELECT * FROM registry WHERE registry.idreg = idreg_agency AND ISNULL (active, 'S') = 'N')";
			string sqlCmd = " SELECT 'Contributo' as 'Tipo'," +
			                " ayear as 'Eserc.', " +
			                " idver as 'Numero Versamento', " +
			                " yimport as 'Eserc. Import', " +
			                " nimport as 'Num. Import.', " +
			                " ruolocsa as 'Ruolo CSA', " +
			                " capitolocsa as 'Capitolo CSA', " +
			                " ente as 'Ente CSA', " +
			                " vocecsa as 'Voce CSA', " +
			                " matricola as 'Matricola', " +
			                " importo as 'Importo', " +
			                " agency as 'Ente', " +
			                " registry_agency as 'Anagrafica Ente CSA', " +
			                " idcsa_agencypaymethod as ' # Mod. Pagamento Ente', " +
			                " codefin_cost as 'Cod. Capitolo Costo'," +
			                " codefin_income as 'Cod. Capitolo Entrata'," +
			                " codefin_expense as 'Cod. Capitolo Spesa'," +
			                " codefin_incomeclawback as 'Cod. Capitolo Entrata Interno'," +
			                " flagcr as 'Comp./Residui' " +
			                " FROM csa_importverview" +
			                " WHERE  " + filter
				;


			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati(sender, e, T, "csa_importver", "default", filter);
			}
		}

		// 29 Ripartizione dei contratti in presenza di un movimento di spesa principale
		private void btn29_Click(object sender, EventArgs e) {
			if (Meta.IsEmpty) return;

			string filter = QHS.AppAnd(QHS.CmpEq("C.active", "S"),
				QHS.CmpEq("C.ayear", Conn.GetSys("esercizio")),
				QHS.IsNotNull("C.idexp_main"));

			filter += " and exists (select * from csa_contractexpense CE where " +
			          " C.idcsa_contract = CE.idcsa_contract and C.ayear = CE.ayear) ";

			string sqlCmd =
				" SELECT C.idcsa_contract , C.ycontract as 'Eserc.Regola specifica CSA', C.ncontract as Numero, " +
				" C.idexp_main as '#idexp_main'  " +
				" from csa_contract C " +
				" where " + filter;

			DataTable T = Conn.SQLRunner(sqlCmd);
			if (T != null) {
				VisualizzaDati(sender, e, T, "csa_contract", "default", filter);
			}
		}

		// 30 Ripartizione del costo contributi in presenza anche di un movimento di spesa
		private void btn30_Click(object sender, EventArgs e) {
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("C.active", "S"),
				QHS.CmpEq("C.ayear", Conn.GetSys("esercizio")),
				QHS.IsNotNull("CT.idexp"));

			filter += " and exists (select * from csa_contracttaxexpense CTE where " +
			          " CTE.idcsa_contract = CT.idcsa_contract and " +
			          " CTE.idcsa_contracttax = CT.idcsa_contracttax and " +
			          " CTE.ayear = CT.ayear) ";
			string sqlCmd =
				" select distinct C.idcsa_contract,  C.ycontract as 'Eserc.Regola specifica CSA', C.ncontract as Numero, " +
				" C.description as 'Descrizione'" +
				" from csa_contract C" +
				" join csa_contracttax CT on C.idcsa_contract = CT.idcsa_contract and CT.ayear = C.ayear " +
				" where " + filter;

			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati(sender, e, T, "csa_contract", "default", filter);
			}
		}


		// 32 Righe di versamento Contributi con ripartizione del costo in presenza anche di un movimento di spesa
		private void btn32_Click(object sender, EventArgs e) {
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]),
				QHS.CmpEq("flagclawback", "N"),
				QHS.IsNotNull("idexp_cost"),
				QHS.IsNotNull("idcsa_contracttax"));
			filter += "AND EXISTS(select * from csa_importver_expense CE where " +
			          " CE.idcsa_import = csa_importverview.idcsa_import and " +
			          " CE.idver = csa_importverview.idver) ";

			string sqlCmd = " SELECT 'Contributo' as 'Tipo'," +
			                " ayear as 'Eserc.', " +
			                " idver as 'Numero Versamento', " +
			                " yimport as 'Eserc. Import', " +
			                " nimport as 'Num. Import.', " +
			                " ruolocsa as 'Ruolo CSA', " +
			                " capitolocsa as 'Capitolo CSA', " +
			                " ente as 'Ente CSA', " +
			                " vocecsa as 'Voce CSA', " +
			                " matricola as 'Matricola', " +
			                " importo as 'Importo', " +
			                " agency as 'Ente', " +
			                " registry_agency as 'Anagrafica Ente CSA', " +
			                " idcsa_agencypaymethod as ' # Mod. Pagamento Ente', " +
			                " codefin_cost as 'Cod. Capitolo Costo'," +
			                " codefin_income as 'Cod. Capitolo Entrata'," +
			                " codefin_expense as 'Cod. Capitolo Spesa'," +
			                " codefin_incomeclawback as 'Cod. Capitolo Entrata Interno'," +
			                " flagcr as 'Comp./Residui' " +
			                " FROM csa_importverview" +
			                " WHERE  " + filter
				;


			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati2(sender, e, T, "csa_importver", "csa_importverview", "default", filter, filter);
			}

		}

		// 31  Righe di riepilogo con ripartizione del costo del lordo in presenza di un movimento di spesa principale
		private void btn31_Click(object sender, EventArgs e) {
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]), QHS.IsNotNull("idcsa_contract"),
				QHS.IsNotNull("idexp"));

			filter +=
				" AND EXISTS(SELECT * FROM csa_importriep_expense C where C.idcsa_import = csa_importriepview.idcsa_import " +
				" and C.idriep = csa_importriepview.idriep) ";

			string sqlCmd = " SELECT ayear as 'Eserc.', " +
			                " idriep as 'Numero Riepilogo', " +
			                " yimport as 'Eserc. Import', " +
			                " nimport as 'Num. Import.', " +
			                " ruolocsa as 'Ruolo CSA', " +
			                " capitolocsa as 'Capitolo CSA', " +
			                " matricola as 'Matricola', " +
			                " importo as 'Importo', " +
			                " registry as 'Anagrafica', " +
			                " flagcr as 'Comp./Residui' " +
			                " FROM csa_importriepview " +
			                " WHERE  " + filter;


			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati2(sender, e, T, "csa_importriep", "csa_importriepview", "default", filter, filter);

			}
		}

		// 33 Righe di riepilogo con ripartizione tra impegni di budget in presenza di un impegno di budget impostato sulla scheda generale
		private void btn33_Click(object sender, EventArgs e) {
			if (Meta.IsEmpty) return;

			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]), QHS.IsNotNull("idcsa_contract"),
				QHS.IsNotNull("idepexp"));

			filter +=
				" AND EXISTS(SELECT * FROM csa_importriep_epexp C where C.idcsa_import = csa_importriepview.idcsa_import " +
				" and C.idriep = csa_importriepview.idriep) ";

			string sqlCmd = " SELECT ayear as 'Eserc.', " +
			                " idriep as 'Numero Riepilogo', " +
			                " yimport as 'Eserc. Import', " +
			                " nimport as 'Num. Import.', " +
			                " ruolocsa as 'Ruolo CSA', " +
			                " capitolocsa as 'Capitolo CSA', " +
			                " matricola as 'Matricola', " +
			                " importo as 'Importo', " +
			                " registry as 'Anagrafica', " +
			                " flagcr as 'Comp./Residui' " +
			                " FROM csa_importriepview " +
			                " WHERE  " + filter;


			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati2(sender, e, T, "csa_importriep", "csa_importriepview", "default",
					filter.Replace("csa_importriepview", "csa_importriep"), filter);
			}
		}

		// 34 Righe di versamento Contributi con ripartizione tra impegni di budget in presenza anche di un impegno di budget principale
		private void btn34_Click(object sender, EventArgs e) {
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]),
				QHS.CmpEq("flagclawback", "N"),
				QHS.IsNotNull("idepexp"),
				QHS.IsNotNull("idcsa_contracttax"));
			filter += " AND EXISTS(select * from csa_importver_epexp CE where " +
			          " CE.idcsa_import = csa_importverview.idcsa_import and " +
			          " CE.idver = csa_importverview.idver) ";

			string sqlCmd = " SELECT 'Contributo' as 'Tipo'," +
			                " ayear as 'Eserc.', " +
			                " idver as 'Numero Versamento', " +
			                " yimport as 'Eserc. Import', " +
			                " nimport as 'Num. Import.', " +
			                " ruolocsa as 'Ruolo CSA', " +
			                " capitolocsa as 'Capitolo CSA', " +
			                " ente as 'Ente CSA', " +
			                " vocecsa as 'Voce CSA', " +
			                " matricola as 'Matricola', " +
			                " importo as 'Importo', " +
			                " agency as 'Ente', " +
			                " registry_agency as 'Anagrafica Ente CSA', " +
			                " idcsa_agencypaymethod as ' # Mod. Pagamento Ente', " +
			                " codefin_cost as 'Cod. Capitolo Costo'," +
			                " codefin_income as 'Cod. Capitolo Entrata'," +
			                " codefin_expense as 'Cod. Capitolo Spesa'," +
			                " codefin_incomeclawback as 'Cod. Capitolo Entrata Interno'," +
			                " flagcr as 'Comp./Residui' " +
			                " FROM csa_importverview" +
			                " WHERE  " + filter
				;


			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati2(sender, e, T, "csa_importver", "csa_importverview", "default", filter, filter);
			}
		}


		// 35 Ripartizione dei contratti in impegni di budget  in presenza di un  impegno di budget principale
		private void btn35_Click(object sender, EventArgs e) {
			if (Meta.IsEmpty) return;

			string filter = QHS.AppAnd(QHS.CmpEq("C.active", "S"),
				QHS.CmpEq("C.ayear", Conn.GetSys("esercizio")),
				QHS.IsNotNull("C.idepexp_main"));

			filter += " and exists (select * from csa_contractepexp CE where " +
			          " C.idcsa_contract = CE.idcsa_contract and C.ayear = CE.ayear) ";

			string sqlCmd =
				" SELECT C.idcsa_contract , C.ycontract as 'Eserc.Regola specifica CSA', C.ncontract as Numero, " +
				" C.idepexp_main as '#idepexp_main'  " +
				" from csa_contract C " +
				" where " + filter;

			DataTable T = Conn.SQLRunner(sqlCmd);
			if (T != null) {
				VisualizzaDati(sender, e, T, "csa_contract", "default", filter);
			}
		}

		// 36 Ripartizione del costo contributi in impegni di budget  in presenza anche di un impegno di budget principale
		private void btn36_Click(object sender, EventArgs e) {
			if (Meta.IsEmpty) return;
			if (rdbExpToListing.Checked) {
				show("La modalità di verifica 'elenco' non è disponibile per questo controllo.", "Avviso");
				return;
			}

			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("C.active", "S"),
				QHS.CmpEq("C.ayear", Conn.GetSys("esercizio")),
				QHS.IsNotNull("CT.idepexp"));

			filter += " and exists (select * from csa_contracttaxepexp CTE where " +
			          " CTE.idcsa_contract = CT.idcsa_contract and " +
			          " CTE.idcsa_contracttax = CT.idcsa_contracttax and " +
			          " CTE.ayear = CT.ayear) ";
			string sqlCmd =
				" select distinct C.idcsa_contract,  C.ycontract as 'Eserc.Regola specifica CSA', C.ncontract as Numero, " +
				" C.description as 'Descrizione'" +
				" from csa_contract C " +
				" join csa_contracttax CT on C.idcsa_contract = CT.idcsa_contract and CT.ayear = C.ayear " +
				" where " + filter;

			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati(sender, e, T, "csa_contract", "default", filter);
			}
		}

		//37 Contributi su partita di giro senza Capitolo di Costo o Movimento di Spesa configurato
		private void btn37_Click(object sender, EventArgs e) {
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]),
				QHS.NullOrEq("flagclawback", "N"),

				QHS.DoPar(QHS.AppOr(QHS.IsNotNull("idcsa_contractkinddata"), QHS.IsNotNull("idcsa_contracttax"))),

				QHS.IsNull("idfin_cost"), QHS.IsNull("idexp_cost"),
				QHS.IsNotNull("idfin_expense"), QHS.IsNotNull("idfin_income")
			);
			filter += " AND NOT EXISTS(select * from csa_contracttaxexpense CE where " +
			          QHS.AppAnd(QHS.CmpEq("CE.idcsa_contract", QHS.Field("csa_importverview.idcsa_contract")),
				          QHS.CmpEq("CE.idcsa_contracttax", QHS.Field("csa_importverview.idcsa_contracttax")),
				          QHS.CmpEq("CE.ayear", Conn.GetSys("esercizio"))
			          )
			          + ")";

			string sqlCmd = " SELECT CASE flagclawback WHEN 'S' THEN 'Recupero' ELSE 'Contributo' END as 'Tipo'," +
			                " ayear as 'Eserc.', " +
			                " idver as 'Numero Versamento', " +
			                " yimport as 'Eserc. Import', " +
			                " nimport as 'Num. Import.', " +
			                " ruolocsa as 'Ruolo CSA', " +
			                " capitolocsa as 'Capitolo CSA', " +
			                " ente as 'Ente CSA', " +
			                " vocecsa as 'Voce CSA', " +
			                " matricola as 'Matricola', " +
			                " importo as 'Importo', " +
			                " registry as 'Anagrafica', " +
			                " agency as 'Ente', " +
			                " idcsa_agencypaymethod as ' # Mod. Pagamento Ente', " +
			                " codefin_cost as 'Cod. Capitolo Costo'," +
			                " phase_cost as 'Fase Mov.Costo', " +
			                " ymov_cost  as 'Eserc. Mov. Costo'," +
			                " nmov_cost  as 'Numero. Mov. Costo'," +
			                " codefin_income as 'Cod. Capitolo Entrata'," +
			                " codefin_expense as 'Cod. Capitolo Spesa'," +
			                " codefin_incomeclawback as 'Cod. Capitolo Entrata Interno'," +
			                " flagcr as 'Comp./Residui' " +
			                " FROM csa_importverview " +
			                " WHERE  " + filter;


			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati2(sender, e, T, "csa_importver", "csa_importverview", "default",
					filter, filter);
			}
		}



		private void btn38_Click(object sender, EventArgs e) {
			//38)   Importo mal ripartito nelle righe di riepilogo
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.CmpEq("idcsa_import", Curr["idcsa_import"]);


			if (!usePartition) {

				filter +=
					" AND EXISTS(SELECT * FROM csa_importriep_expense CE where  csa_importriepview.idcsa_import = CE.idcsa_import and  csa_importriepview.idriep = CE.idriep  " +
					" ) ";

				filter +=
					" AND (SELECT sum(CE.amount)  from csa_importriep_expense CE WHERE  csa_importriepview.idcsa_import = CE.idcsa_import and csa_importriepview.idriep = CE.idriep  " +
					" ) <>  csa_importriepview.importo ";
			}
			else {
				filter +=
					" AND (SELECT sum(CE.amount)  from csa_importriep_partition CE WHERE  csa_importriepview.idcsa_import = CE.idcsa_import and csa_importriepview.idriep = CE.idriep  " +
					" ) <>  csa_importriepview.importo ";
			}

			string sqlCmd = " SELECT ayear as 'Eserc.', " +
			                " idriep as 'Numero Riepilogo', " +
			                " (select sum(CE.amount)  from csa_importriep_partition CE " +
			                " where csa_importriepview.idcsa_import = CE.idcsa_import and csa_importriepview.idriep = CE.idriep) as Somma, " +

			                " yimport as 'Eserc. Import', " +
			                " nimport as 'Num. Import.', " +
			                " ruolocsa as 'Ruolo CSA', " +
			                " capitolocsa as 'Capitolo CSA', " +
			                " matricola as 'Matricola', " +
			                " importo as 'Importo', " +
			                " registry as 'Anagrafica', " +
			                " flagcr as 'Comp./Residui' " +
			                " FROM csa_importriepview  " +
			                " WHERE  " + filter;


			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati2(sender, e, T, "csa_importriep", "csa_importriepview", "default",
					filter.Replace("csa_importriepview", "csa_importriep"), filter);
			}
		}

		private void btn39_Click(object sender, EventArgs e) {
			// 39)  Importo mal ripartito nelle righe dei contributi(versamenti)
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.CmpEq("idcsa_import", Curr["idcsa_import"]);


			if (!usePartition) {
				filter +=
					" AND EXISTS(SELECT * FROM csa_importver_expense CE where csa_importverview.idcsa_import = CE.idcsa_import and  csa_importverview.idver = CE.idver  " +
					" ) ";
				filter +=
					" AND (SELECT sum(CE.amount)  from csa_importver_expense CE WHERE csa_importverview.idcsa_import = CE.idcsa_import and csa_importverview.idver = CE.idver  " +
					" ) <> csa_importverview.importo ";
			}
			else {
				filter +=
					" AND (SELECT sum(CE.amount)  from csa_importver_partition CE WHERE csa_importverview.idcsa_import = CE.idcsa_import and csa_importverview.idver = CE.idver  " +
					" ) <> csa_importverview.importo ";

			}

			string sqlCmd = " SELECT    CASE flagclawback WHEN 'S' THEN 'Recupero' ELSE 'Contributo' END as 'Tipo'," +
			                " ayear as 'Eserc.', " +
			                " idver as 'Numero Versamento', " +
			                " (select sum(CE.amount)  from csa_importver_expense CE " +
			                " where csa_importverview.idcsa_import = CE.idcsa_import and csa_importverview.idver = CE.idver) as Somma, " +
			                " yimport as 'Eserc. Import', " +
			                " nimport as 'Num. Import.', " +
			                " ruolocsa as 'Ruolo CSA', " +
			                " capitolocsa as 'Capitolo CSA', " +
			                " ente as 'Ente CSA', " +
			                " vocecsa as 'Voce CSA', " +
			                " agency as 'Ente', " +
			                " matricola as 'Matricola', " +
			                " importo as 'Importo', " +
			                " registry as 'Anagrafica', " +
			                " flagcr as 'Comp./Residui' " +
			                " FROM csa_importverview " +
			                " WHERE  " + filter;


			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati2(sender, e, T, "csa_importver", "csa_importverview", "default",
					filter.Replace("csa_importverview", "csa_importver"), filter);
			}

		}

		//40)   Verifica ripartizione EP dei contratti
		private void btn40_Click(object sender, EventArgs e) {
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.CmpEq("idcsa_import", Curr["idcsa_import"]);

			filter +=
				" AND EXISTS(SELECT * FROM csa_importriep_epexp CE where csa_importriepview.idcsa_import = CE.idcsa_import and  csa_importriepview.idriep = CE.idriep  " +
				" ) ";

			filter +=
				" AND (select abs(sum(CE.quota) - 1) from csa_importriep_epexp CE WHERE csa_importriepview.idcsa_import = CE.idcsa_import and csa_importriepview.idriep = CE.idriep  " +
				" ) > 0.000001 ";

			string sqlCmd = " SELECT csa_importriepview.ayear as 'Eserc.', " +
			                " csa_importriepview.idriep as 'Numero Riepilogo', " +
			                " (select sum(CE.quota)  from csa_importriep_epexp CE " +
			                " where csa_importriepview.idcsa_import = CE.idcsa_import and csa_importriepview.idriep = CE.idriep) as Quota, " +

			                " yimport as 'Eserc. Import', " +
			                " nimport as 'Num. Import.', " +
			                " ruolocsa as 'Ruolo CSA', " +
			                " capitolocsa as 'Capitolo CSA', " +
			                " matricola as 'Matricola', " +
			                " importo as 'Importo', " +
			                " registry as 'Anagrafica', " +
			                " flagcr as 'Comp./Residui' " +
			                " FROM csa_importriepview " +
			                " WHERE  " + filter;


			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati(sender, e, T, "csa_importriep", "default", filter);
			}

		}

		//41)   Verifica ripartizione EP dei contributi
		private void btn41_Click(object sender, EventArgs e) {
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.CmpEq("idcsa_import", Curr["idcsa_import"]);

			filter +=
				" AND EXISTS(SELECT * FROM csa_importver_epexp CE where csa_importverview.idcsa_import = CE.idcsa_import and  csa_importverview.idver = CE.idver  " +
				" ) ";

			filter +=
				" AND ( select abs(sum(CE.quota) - 1)  from csa_importver_epexp CE WHERE csa_importverview.idcsa_import = CE.idcsa_import and  csa_importverview.idver = CE.idver  " +
				" ) > 0.000001 ";

			string sqlCmd = " SELECT    CASE flagclawback WHEN 'S' THEN 'Recupero' ELSE 'Contributo' END as 'Tipo'," +
			                " ayear as 'Eserc.', " +
			                " idver as 'Numero Versamento', " +
			                " (select sum(CE.quota)  from csa_importver_epexp CE " +
			                " where csa_importverview.idcsa_import = CE.idcsa_import and csa_importverview.idver = CE.idver) as Quota, " +
			                " yimport as 'Eserc. Import', " +
			                " nimport as 'Num. Import.', " +
			                " ruolocsa as 'Ruolo CSA', " +
			                " capitolocsa as 'Capitolo CSA', " +
			                " ente as 'Ente CSA', " +
			                " vocecsa as 'Voce CSA', " +
			                " agency as 'Ente', " +
			                " matricola as 'Matricola', " +
			                " importo as 'Importo', " +
			                " registry as 'Anagrafica', " +
			                " flagcr as 'Comp./Residui' " +
			                " FROM csa_importverview  " +
			                " WHERE  " + filter;

			DataTable T = Conn.SQLRunner(sqlCmd);
			if (T != null) {
				VisualizzaDati(sender, e, T, "csa_importver", "default", filter);
			}

		}

		//42)  Righe di riepilogo con ripartizione del costo del lordo in presenza di un movimento di spesa principale
		private void btn42_Click(object sender, EventArgs e) {

			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]), QHS.IsNotNull("idcsa_contract"),
				QHS.IsNotNull("idexp"));

			filter +=
				" AND EXISTS(SELECT * FROM csa_importriep_expense CE where csa_importriepview.idcsa_import = CE.idcsa_import and csa_importriepview.idriep = CE.idriep  " +
				" ) ";

			string sqlCmd = " SELECT ayear as 'Eserc.', " +
			                " idriep as 'Numero Riepilogo', " +
			                " (select sum(CE.amount)  from csa_importriep_expense CE " +
			                " where csa_importriepview.idcsa_import = CE.idcsa_import and csa_importriepview.idriep = CE.idriep) as Importo, " +

			                " yimport as 'Eserc. Import', " +
			                " nimport as 'Num. Import.', " +
			                " ruolocsa as 'Ruolo CSA', " +
			                " capitolocsa as 'Capitolo CSA', " +
			                " matricola as 'Matricola', " +
			                " importo as 'Importo', " +
			                " registry as 'Anagrafica', " +
			                " flagcr as 'Comp./Residui' " +
			                " FROM csa_importriepview  " +
			                " WHERE  " + filter;


			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati(sender, e, T, "csa_importriep", "default", filter);
			}

		}

		//43)  Righe di versamento Contributi con ripartizione del costo in presenza anche di un movimento di spesa
		private void btn43_Click(object sender, EventArgs e) {
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]),
				QHS.IsNotNull("idcsa_contracttax"),
				QHS.IsNotNull("idexp_cost"), QHS.NullOrEq("flagclawback", "N"));

			filter +=
				" AND EXISTS(SELECT * FROM csa_importver_expense CE where csa_importverview.idcsa_import = CE.idcsa_import and csa_importverview.idver = CE.idver  " +
				" ) ";


			string sqlCmd = " SELECT    CASE flagclawback WHEN 'S' THEN 'Recupero' ELSE 'Contributo' END as 'Tipo'," +
			                " ayear as 'Eserc.', " +
			                " idver as 'Numero Versamento', " +
			                " (select sum(CE.amount)  from csa_importver_expense CE " +
			                " where csa_importverview.idcsa_import = CE.idcsa_import and csa_importverview.idver = CE.idver) as Importo, " +
			                " yimport as 'Eserc. Import', " +
			                " nimport as 'Num. Import.', " +
			                " ruolocsa as 'Ruolo CSA', " +
			                " capitolocsa as 'Capitolo CSA', " +
			                " ente as 'Ente CSA', " +
			                " vocecsa as 'Voce CSA', " +
			                " agency as 'Ente', " +
			                " matricola as 'Matricola', " +
			                " importo as 'Importo', " +
			                " registry as 'Anagrafica', " +
			                " flagcr as 'Comp./Residui' " +
			                " FROM csa_importverview  " +
			                " WHERE  " + filter;

			DataTable T = Conn.SQLRunner(sqlCmd);
			if (T != null) {
				VisualizzaDati(sender, e, T, "csa_importver", "default", filter);
			}

		}

		//44)  Righe di riepilogo con ripartizione tra impegni di budget in presenza anche di un impegno di budget principale
		private void btn44_Click(object sender, EventArgs e) {

			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]), QHS.IsNotNull("idcsa_contract"),
				QHS.IsNotNull("idepexp"));

			filter +=
				" AND EXISTS(SELECT * FROM csa_importriep_epexp CE where csa_importriepview.idcsa_import = CE.idcsa_import and csa_importriepview.idriep = CE.idriep  " +
				" ) ";

			string sqlCmd = " SELECT ayear as 'Eserc.', " +
			                " idriep as 'Numero Riepilogo', " +
			                " (select sum(CE.quota)  from csa_importriep_epexp CE " +
			                " where csa_importriepview.idcsa_import = CE.idcsa_import and csa_importriepview.idriep = CE.idriep) as Quota, " +
			                " yimport as 'Eserc. Import', " +
			                " nimport as 'Num. Import.', " +
			                " ruolocsa as 'Ruolo CSA', " +
			                " capitolocsa as 'Capitolo CSA', " +
			                " matricola as 'Matricola', " +
			                " importo as 'Importo', " +
			                " registry as 'Anagrafica', " +
			                " flagcr as 'Comp./Residui' " +
			                " FROM csa_importriepview  " +
			                " WHERE  " + filter;


			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati2(sender, e, T, "csa_importriep", "csa_importriepview", "default",
					filter.Replace("csa_importriepview", "csa_importriep"), filter);
			}


		}

		//45)  Righe di versamento Contributi con ripartizione tra impegni di budget in presenza anche di un impegno di budget principale
		private void btn45_Click(object sender, EventArgs e) {

			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]),
				QHS.IsNotNull("idcsa_contracttax"),
				QHS.IsNotNull("idepexp"), QHS.NullOrEq("flagclawback", "N"));

			filter +=
				" AND EXISTS(SELECT * FROM csa_importver_epexp CE where csa_importverview.idcsa_import = CE.idcsa_import and csa_importverview.idver = CE.idver  " +
				" ) ";


			string sqlCmd = " SELECT    CASE flagclawback WHEN 'S' THEN 'Recupero' ELSE 'Contributo' END as 'Tipo'," +
			                " ayear as 'Eserc.', " +
			                " idver as 'Numero Versamento', " +
			                " (select sum(CE.quota)  from csa_importver_epexp CE " +
			                " where csa_importverview.idcsa_import = CE.idcsa_import and csa_importverview.idver = CE.idver) as Quota, " +
			                " yimport as 'Eserc. Import', " +
			                " nimport as 'Num. Import.', " +
			                " ruolocsa as 'Ruolo CSA', " +
			                " capitolocsa as 'Capitolo CSA', " +
			                " ente as 'Ente CSA', " +
			                " vocecsa as 'Voce CSA', " +
			                " agency as 'Ente', " +
			                " matricola as 'Matricola', " +
			                " importo as 'Importo', " +
			                " registry as 'Anagrafica', " +
			                " flagcr as 'Comp./Residui' " +
			                " FROM csa_importverview  " +
			                " WHERE  " + filter;

			DataTable T = Conn.SQLRunner(sqlCmd);
			if (T != null) {
				VisualizzaDati(sender, e, T, "csa_importver", "default", filter);
			}
		}

		//46) Ritenute  con importo negativo senza  il Conto di Credito verso Ente
		private void btn46_Click(object sender, EventArgs e) {
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]),
				QHS.CmpEq("flagclawback", "N"), QHS.CmpLt("importo", 0),
				QHS.IsNull("idfin_cost"), QHS.IsNull("idexp_cost"),
				QHS.IsNotNull("idfin_income"), QHS.IsNotNull("idfin_expense"),
				QHS.IsNull("idacc_agency_credit"));

			string sqlCmd =
				" SELECT CASE flagclawback WHEN 'S' THEN 'Recupero' ELSE 'Ritenuta/Contributo' END as 'Tipo'," +
				" ayear as 'Eserc.', " +
				" idver as 'Numero Versamento', " +
				" yimport as 'Eserc. Import', " +
				" nimport as 'Num. Import.', " +
				" ruolocsa as 'Ruolo CSA', " +
				" capitolocsa as 'Capitolo CSA', " +
				" ente as 'Ente CSA', " +
				" vocecsa as 'Voce CSA', " +
				" matricola as 'Matricola', " +
				" importo as 'Importo', " +
				" registry as 'Anagrafica', " +
				" agency as 'Ente', " +
				" codeacc_agency_credit as 'Codice Conto Credito V/Ente'," +
				" account_agency_credit as 'Conto Credito V/Ente' ," +
				" idcsa_agencypaymethod as ' # Mod. Pagamento Ente', " +
				" codefin_cost as 'Cod. Capitolo Costo'," +
				" codefin_income as 'Cod. Capitolo Entrata'," +
				" codefin_expense as 'Cod. Capitolo Spesa'," +
				" codefin_incomeclawback as 'Cod. Capitolo Entrata Interno'," +
				" flagcr as 'Comp./Residui' " +
				" FROM csa_importverview " +
				" WHERE  " + filter;


			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati(sender, e, T, "csa_importver", "default", filter);
			}
		}


		private void btn47_Click(object sender, EventArgs e) {
			//47) Ripartizione in impegni di budget  (csa_contractepexp )senza una corrispondente ripartizione  nel finanziario  (csa_contractexpense) 

			if (Meta.IsEmpty) return;
			if (rdbExpToListing.Checked) {
				show("La modalità di verifica 'elenco' non è disponibile per questo controllo.", "Avviso");
				return;
			}

			DataRow Curr = DS.csa_import.Rows[0];
			string filter = " not exists ( " +
			                " select * from csa_contractexpenseview RipFin " +
			                " where csa_contractepexpview.idcsa_contract = RipFin.idcsa_contract " +
			                " and  csa_contractepexpview.ayear =RipFin.ayear " +
			                " and  csa_contractepexpview.ndetail =RipFin.ndetail " +
			                " and  csa_contractepexpview.idupb = RipFin.idupb " +
			                " and csa_contractepexpview.quota = RipFin.quota) ";
			filter = QHS.AppAnd(QHS.CmpEq("ayear", Curr["yimport"]), filter);
			// ayear, contractkindcode, contractkind, ycontract,ncontract, phase, yepexp, nepexp, quota, codeupb,upb
			string sqlCmd = " SELECT ayear as 'Eserc.', " +
			                " idcsa_contractkind as '#id Regola generale CSA', " +
			                " contractkindcode as 'Cod. Regola generale CSA', " +
			                " contractkind as 'Regola generale CSA', " +
			                " idcsa_contract as '#id Regola specifica CSA', " +
			                " ycontract as 'Eserc. Regola specifica CSA', " +
			                " ncontract as 'Num. Regola specifica CSA', " +
			                " ndetail as '#id. dettaglio ripart.', " +
			                " quota as 'Quota Ripartizione Regola specifica CSA', " +
			                " phase as 'Fase', " +
			                " yepexp as 'Eserc. Preimpegno', " +
			                " nepexp as 'Num. Preimpegno', " +
			                " codeupb as 'Codice UPB Preimpegno', " +
			                " upb as 'UPB Preimpegno' " +
			                " FROM csa_contractepexpview " +
			                " WHERE  " + filter;

			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati2(sender, e, T, "csa_contractepexpview", "csa_contractepexp", "default", filter, filter);
			}
		}

		private void btn48_Click(object sender, EventArgs e) {
			//48) Ripartizione in impegni di budget   dei contributi (csa_contracttaxtepexp) senza una corrispondente  ripartizione finanziaria (csa_contracttaxexpense) 
			if (Meta.IsEmpty) return;
			if (rdbExpToListing.Checked) {
				show("La modalità di verifica 'elenco' non è disponibile per questo controllo.", "Avviso");
				return;
			}

			DataRow Curr = DS.csa_import.Rows[0];
			string filter = " not exists ( " +
			                " select * from csa_contracttaxexpenseview RipFIN" +
			                " where RipFIN.idcsa_contract = csa_contracttaxepexpview.idcsa_contract " +
			                " and  RipFIN.ayear =csa_contracttaxepexpview.ayear " +
			                " and  RipFIN.ndetail =csa_contracttaxepexpview.ndetail " +
			                " and  RipFIN.idupb = csa_contracttaxepexpview.idupb " +
			                " and RipFIN.quota = csa_contracttaxepexpview.quota) ";
			filter = QHS.AppAnd(QHS.CmpEq("ayear", Curr["yimport"]), filter);
			// ayear, contractkindcode, contractkind, ycontract,ncontract, phase, yepexp, nepexp, quota, codeupb,upb
			string sqlCmd = " SELECT ayear as 'Eserc.', " +
			                " idcsa_contractkind as '#id Regola generale CSA', " +
			                " contractkindcode as 'Cod. Regola generale CSA', " +
			                " contractkind as 'Regola generale CSA', " +
			                " idcsa_contract as '#id Regola specifica CSA', " +
			                " ycontract as 'Eserc. Regola specifica CSA', " +
			                " ncontract as 'Num. Regola specifica CSA', " +
			                " idcsa_contracttax as '#id rip. contributo', " +
			                " voceCSA as 'Voce CSA', " +
			                " ndetail as '#id. dettaglio ripart.' ," +
			                " quota as 'Quota Ripartizione Regola specifica CSA', " +
			                " phase as 'Fase', " +
			                " yepexp as 'Eserc. Preimpegno', " +
			                " nepexp as 'Num. Preimpegno', " +
			                " codeupb as 'Codice UPB Preimpegno', " +
			                " upb as 'UPB Preimpegno' " +
			                " FROM csa_contracttaxepexpview " +
			                " WHERE  " + filter;

			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati2(sender, e, T, "csa_contracttaxexpenseview", "csa_contracttaxexpense", "default", filter,
					filter);
			}
		}

		private void btn49_Click(object sender, EventArgs e) {
			// 49)'Esistono movimenti finanziari mal ripartiti su finanziamenti'    
			if (Meta.IsEmpty) return;
			if (rdbExpToListing.Checked) {
				show("La modalità di verifica 'elenco' non è disponibile per questo controllo.", "Avviso");
				return;
			}

			DataRow Curr = DS.csa_import.Rows[0];


			// ayear, contractkindcode, contractkind, ycontract,ncontract, phase, yepexp, nepexp, quota, codeupb,upb
			string sqlCmd = "select distinct ymov as 'eserc. mov.', " +
			                " nmov as 'n.mov'," +
			                " curramount as 'importo movimento'," +
			                " (select sum(E2.appropriation) from expensecreditproceedsview E2 where E1.idexp = E2.idexp and E1.ayear = E2.ayear) as 'finanziamento'," +
			                " description as 'descrizione'," +
			                " upb, underwriting as 'finanziamento' from expensecreditproceedsview E1 " +
			                " join expenselink EL on EL.idparent = E1.idexp " +
			                " where curramount<> " +
			                "(select sum(E2.appropriation) from expensecreditproceedsview E2 where E1.idexp = E2.idexp and E1.ayear = E2.ayear) " +
			                " and E1.ayear = " + QHS.quote(Curr["yimport"]) + " and " +
			                " (EL.idchild in (select idexp from csa_importriep where idcsa_import = " +
			                QHS.quote(Curr["idcsa_import"]) + ") OR " +
			                " EL.idchild in (select idexp_cost from csa_importver where idcsa_import = " +
			                QHS.quote(Curr["idcsa_import"]) + ") OR " +
			                " EL.idchild in (select idexp from csa_importriep_expense where idcsa_import = " +
			                QHS.quote(Curr["idcsa_import"]) + ") OR " +
			                " EL.idchild in (select idexp from csa_importver_expense where idcsa_import = " +
			                QHS.quote(Curr["idcsa_import"]) + ")  OR " +
			                " EL.idchild in (select idexp from csa_importver_partition where idcsa_import = " +
			                QHS.quote(Curr["idcsa_import"]) + ") " +
			                " ) " +
			                " order by ymov, nmov ";

			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati(sender, e, T, null, null, null);
			}
		}


		private void btn50_Click(object sender, EventArgs e) {
			//50) Righe di riepilogo con movimento di spesa senza imputazione nell''esercizio corrente
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];

			string filter = QHS.CmpEq("idcsa_import", Curr["idcsa_import"]);


			if (!usePartition) {
				filter = QHS.AppAnd(filter, QHS.IsNotNull("R.idexp"));
				filter += " AND NOT EXISTS (select * from expenseyear EY where " +
				          " EY.idexp = R.idexp AND " +
				          " R.ayear = EY.ayear) ";
			}
			else {
				filter += " AND EXISTS (select * from csa_importriep_partition RP where " +
				          " R.idcsa_import = RP.idcsa_import AND " +
				          " R.idriep = RP.idriep AND" +
				          " RP.idexp IS NOT NULL) ";
				filter += " AND NOT EXISTS (select * from expenseyear EY " +
				          " JOIN csa_importriep_partition RP ON " +
				          " R.idcsa_import = RP.idcsa_import AND " +
				          " R.idriep = RP.idriep AND " +
				          " EY.idexp = RP.idexp AND " +
				          " R.ayear = EY.ayear ) ";
			}

			string sqlCmd = " SELECT ayear as 'Eserc.', " +
			                " idriep as 'Numero Riepilogo', " +
			                " yimport as 'Eserc. Import', " +
			                " nimport as 'Num. Import.', " +
			                " ruolocsa as 'Ruolo CSA', " +
			                " capitolocsa as 'Capitolo CSA', " +
			                " matricola as 'Matricola', " +
			                " importo as 'Importo', " +
			                " registry as 'Anagrafica', " +
			                " flagcr as 'Comp./Residui' " +
			                " FROM csa_importriepview R" +
			                " WHERE  " + filter;

			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati(sender, e, T, "csa_importriep", "default", filter);
			}
		}

		private void btn51_Click(object sender, EventArgs e) {
			//51) Righe di versamento con movimento di spesa senza imputazione nell''esercizio corrente
			if (Meta.IsEmpty) return;

			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.CmpEq("idcsa_import", Curr["idcsa_import"]);

			if (!usePartition) {
				filter = QHS.AppAnd(filter, QHS.IsNotNull("R.idexp_cost"));
				filter += " AND NOT EXISTS (select * from expenseyear EY where " +
				          " EY.idexp = R.idexp_cost AND " +
				          " R.ayear = EY.ayear) ";
			}
			else {
				filter += " AND EXISTS (select * from csa_importver_partition RP where " +
				          " R.idcsa_import = RP.idcsa_import AND " +
				          " R.idver = RP.idver AND" +
				          " RP.idexp IS NOT NULL) ";
				filter += " AND NOT EXISTS (select * from expenseyear EY " +
				          " JOIN csa_importver_partition RP ON " +
				          " R.idcsa_import = RP.idcsa_import AND " +
				          " R.idver = RP.idver AND " +
				          " EY.idexp = RP.idexp AND " +
				          " R.ayear = EY.ayear ) ";
			}

			string sqlCmd = " SELECT ayear as 'Eserc.', " +
			                " idver as 'Numero Versamento', " +
			                " yimport as 'Eserc. Import', " +
			                " nimport as 'Num. Import.', " +
			                " ruolocsa as 'Ruolo CSA', " +
			                " capitolocsa as 'Capitolo CSA', " +
			                " ente as 'Ente CSA', " +
			                " vocecsa as 'Voce CSA', " +
			                " matricola as 'Matricola', " +
			                " importo as 'Importo', " +
			                " registry as 'Anagrafica', " +
			                " agency as 'Ente', " +
			                " flagcr as 'Comp./Residui' " +
			                " FROM csa_importverview R " +
			                " WHERE  " + filter;

			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati(sender, e, T, "csa_importver", "default", filter);
			}
		}

		private void btn52_Click(object sender, EventArgs e) {
			//52)   Movimento di spesa principale impostato nei contratti senza imputazione nell'esercizio corrente
			if (Meta.IsEmpty) return;
			if (rdbExpToListing.Checked) {
				show("La modalità di verifica 'elenco' non è disponibile per questo controllo.", "Avviso");
				return;
			}

			var Curr = DS.csa_import.Rows[0];
			var idcsa_import = Curr["idcsa_import"];
			string sqlCmd = "";
			string filter = "";
			if (!usePartition) {
				filter = QHS.AppAnd(QHS.CmpEq("active", "S"),
					QHS.CmpEq("ayear", Conn.GetSys("esercizio")),
					QHS.IsNotNull("idexp_main"));

				filter += " and not exists (select * from expenseyear EY where " +
				          "                  EY.idexp = csa_contract.idexp_main AND " +
				          "                  csa_contract.ayear = EY.ayear) ";

				filter +=
					$" and exists (select * from csa_importriep R where idcsa_import = {idcsa_import} and idcsa_contract=csa_contract.idcsa_contract )		";

				sqlCmd =
					" SELECT idcsa_contract , ycontract as 'Eserc.Regola specifica CSA', ncontract as Numero, description as Descrizione " +
					" from csa_contract  " +
					" where " + filter;
				DataTable T = Conn.SQLRunner(sqlCmd);
				if (T != null) {
					VisualizzaDati(sender, e, T, "csa_contract", "default", filter);
				}
			}
			else {
				filter = QHS.AppAnd(QHS.CmpEq("C.active", "S"),
					QHS.CmpEq("C.ayear", Conn.GetSys("esercizio")));
				filter = QHS.AppAnd(filter, QHS.IsNotNull("CP.idexp"));

				filter += " and not exists (select * from expenseyear EY where " +
				          "                  EY.idexp = CP.idexp AND " +
				          "                  CP.ayear = EY.ayear) ";
				filter +=
					$" and exists (select * from csa_importriep R where idcsa_import = {idcsa_import} and idcsa_contract=C.idcsa_contract )		";

				sqlCmd =
					" SELECT CP.idcsa_contract , CP.ycontract as 'Eserc.Regola specifica CSA', CP.ncontract as Numero, " +
					" CP.ndetail as 'Dett'," +
					" CP.ymov as 'Eserc.Movimento', " +
					" CP.nmov as 'Eserc.Movimento' " +
					" from csa_contract_partitionview CP " +
					" join csa_contract C " +
					" on C.idcsa_contract = CP.idcsa_contract " +
					" and C.ayear = CP.ayear " +
					" where " + filter;

				DataTable T = Conn.SQLRunner(sqlCmd);
				if (T != null) {
					VisualizzaDati2(sender, e, T, "csa_contract_partition", "csa_contract_partitionview", "default",
						filter, filter);
				}
			}


		}

		private void btn53_Click(object sender, EventArgs e) {
			//53)    Movimento di spesa principale impostato nei contributi contratti senza imputazione nell'esercizio corrente
			if (Meta.IsEmpty) return;
			if (rdbExpToListing.Checked) {
				show("La modalità di verifica 'elenco' non è disponibile per questo controllo.", "Avviso");
				return;
			}

			var Curr = DS.csa_import.Rows[0];
			var idcsa_import = Curr["idcsa_import"];

			string sqlCmd = "";
			string filter = "";
			if (!usePartition) {

				filter = QHS.AppAnd(QHS.CmpEq("ayear", Curr["yimport"]), QHS.IsNotNull("idexp"),
					QHS.CmpEq("active", "S"));
				filter += " and not exists (select * from expenseyear EY where " +
				          "                  EY.idexp = csa_contracttaxview.idexp AND " +
				          "                  csa_contracttaxview.ayear = EY.ayear) ";
				filter +=
					$" and exists (select * from csa_importriep R where idcsa_import = {idcsa_import} and idcsa_contract=csa_contracttaxview.idcsa_contract )		";
				sqlCmd = " SELECT ayear as 'Eserc.', " +
				         " ycontract as 'Eserc. Regola specifica CSA', " +
				         " ncontract as 'Num. Regola specifica CSA.', " +
				         " contractkindcode as 'Cod. Regola generale CSA', " +
				         " contractkind as 'Regola generale CSA', " +
				         " voceCSA as 'Voce CSA' " +
				         " FROM csa_contracttaxview " +
				         " WHERE  " + filter;


				DataTable T = Conn.SQLRunner(sqlCmd);
				string filterT = filter.Replace("csa_contracttaxview", "csa_contracttax");
				if (T != null) {
					//VisualizzaDati(sender, e, T, "csa_contracttax", "elenco", filter);
					VisualizzaDati2(sender, e, T, "csa_contracttax", "csa_contracttaxview", "elenco", filterT, filter);
				}
			}
			else {
				filter = QHS.AppAnd(QHS.CmpEq("C.active", "S"),
					QHS.CmpEq("C.ayear", Conn.GetSys("esercizio")));
				filter = QHS.AppAnd(filter, QHS.IsNotNull("CP.idexp"));

				filter += " and not exists (select * from expenseyear EY where " +
				          "                  EY.idexp = CP.idexp AND " +
				          "                  CP.ayear = EY.ayear)";
				filter +=
					$" and exists (select * from csa_importriep R where idcsa_import = {idcsa_import} and idcsa_contract=C.idcsa_contract )		";

				sqlCmd =
					" SELECT CP.idcsa_contract , CP.ycontract as 'Eserc.Regola specifica CSA', CP.ncontract as Numero, " +
					" CP.ndetail as 'Dett'," +
					" CP.ymov as 'Eserc.Movimento', " +
					" CP.nmov as 'Eserc.Movimento', " +
					" CP.voceCSA as 'Voce CSA' " +
					" from csa_contracttax_partitionview CP " +
					" join csa_contract C " +
					" on C.idcsa_contract = CP.idcsa_contract " +
					" and C.ayear = CP.ayear " +
					" where " + filter;
				DataTable T = Conn.SQLRunner(sqlCmd);
				if (T != null) {
					VisualizzaDati2(sender, e, T, "csa_contracttax_partition", "csa_contracttax_partitionview",
						"default", filter, filter);
				}

			}
		}

		private void btn54_Click(object sender, EventArgs e) {
			//54)    Movimento di spesa principale impostato nella ripartizione dei contributi senza imputazione nell'esercizio corrente
			if (Meta.IsEmpty) return;
			if (rdbExpToListing.Checked) {
				show("La modalità di verifica 'elenco' non è disponibile per questo controllo.", "Avviso");
				return;
			}

			DataRow Curr = DS.csa_import.Rows[0];

			string filter = QHS.AppAnd(QHS.CmpEq("ayear", Curr["yimport"]), QHS.IsNotNull("idexp"),
				QHS.CmpEq("active", "S"));
			// aggiungere active alla view csa_contracttaxexpenseview
			filter += " and not exists (select * from expenseyear EY where " +
			          "                  EY.idexp = csa_contracttaxexpenseview.idexp AND " +
			          "                  csa_contracttaxexpenseview.ayear = EY.ayear)";

			string sqlCmd = " SELECT ayear as 'Eserc.', " +
			                " ycontract as 'Eserc. Regola specifica CSA', " +
			                " ncontract as 'Num. Regola specifica CSA.', " +
			                " contractkindcode as 'Cod. Regola generale CSA', " +
			                " contractkind as 'Regola generale CSA', " +
			                " voceCSA as 'Voce CSA' " +
			                " from csa_contracttaxexpenseview   " +
			                " where " + filter;

			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati2(sender, e, T, "csa_contracttaxexpense", "csa_contracttaxexpenseview", "elenco", filter,
					filter);
			}
		}

		private void btn55_Click(object sender, EventArgs e) {
			//55)   Movimento di spesa principale impostato nella ripartizione dei contratti senza imputazione nell'esercizio corrente
			if (Meta.IsEmpty) return;
			if (rdbExpToListing.Checked) {
				show("La modalità di verifica 'elenco' non è disponibile per questo controllo.", "Avviso");
				return;
			}

			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("ayear", Curr["yimport"]), QHS.IsNotNull("idexp"),
				QHS.CmpEq("active", "S"));
			filter += " and not exists (select * from expenseyear EY where " +
			          "                  EY.idexp = csa_contractexpenseview.idexp AND " +
			          "                  csa_contractexpenseview.ayear = EY.ayear)";

			string sqlCmd = " SELECT ayear as 'Eserc.', " +
			                " idcsa_contractkind as '#id Regola generale CSA', " +
			                " contractkindcode as 'Cod. Regola generale CSA', " +
			                " contractkind as 'Regola generale CSA', " +
			                " idcsa_contract as '#id Regola specifica CSA', " +
			                " ycontract as 'Eserc. Regola specifica CSA', " +
			                " ncontract as 'Num. Regola specifica CSA', " +
			                " ndetail as '#id. dettaglio ripart.', " +
			                " quota as 'Quota Ripartizione Regola specifica CSA', " +
			                " phase as 'Fase', " +
			                " ymov as 'Eserc. Mov. Fin.', " +
			                " nmov as 'Num. Mov. Fin.', " +
			                " codeupb as 'Codice UPB Mov. Fin.', " +
			                " upb as 'UPB Preimpegno' " +
			                " FROM csa_contractexpenseview " +
			                " WHERE  " + filter;

			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati2(sender, e, T, "csa_contractexpenseview", "csa_contractexpense", "default", filter,
					filter);
			}
		}

		private void btn56_Click(object sender, EventArgs e) {
			//56) Righe di riepilogo con UPB incoerente tra movimento di spesa singolo ed impegno di budget singolo collegato
			if (Meta.IsEmpty) return;
			if (rdbExpToListing.Checked) {
				show("La modalità di verifica 'elenco' non è disponibile per questo controllo.", "Avviso");
				return;
			}

			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]),
				QHS.IsNotNull("csa_importriepview.idexp"),
				QHS.IsNotNull("csa_importriepview.idepexp"));

			string sqlCmd = " SELECT csa_importriepview.ayear as 'Eserc.', " +
			                " csa_importriepview.idriep as 'Numero Riepilogo', " +
			                " csa_importriepview.yimport as 'Eserc. Import', " +
			                " csa_importriepview.nimport as 'Num. Import.', " +
			                " csa_importriepview.ruolocsa as 'Ruolo CSA', " +
			                " csa_importriepview.capitolocsa as 'Capitolo CSA', " +
			                " csa_importriepview.matricola  as 'Matricola', " +
			                " csa_importriepview.importo as 'Importo', " +
			                " csa_importriepview.registry as 'Anagrafica', " +
			                " csa_importriepview.flagcr as 'Comp./Residui' " +
			                " FROM csa_importriepview " +
			                " left outer join expenseyear EY ON EY.idexp = csa_importriepview.idexp AND  csa_importriepview.ayear = EY.ayear " +
			                " left outer join epexpyear   EPY ON EPY.idepexp = csa_importriepview.idepexp AND csa_importriepview.ayear = EPY.ayear " +
			                " WHERE  " + filter +
			                " AND isnull(EY.idupb, '0001') <> isnull(EPY.idupb, '0001') ";
			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati(sender, e, T, "csa_importriep", "default", filter);
			}
		}

		private void btn57_Click(object sender, EventArgs e) {
			//57) Righe di versamento con UPB incoerente tra movimento di spesa singolo ed impegno di budget singolo collegato
			if (Meta.IsEmpty) return;
			if (rdbExpToListing.Checked) {
				show("La modalità di verifica 'elenco' non è disponibile per questo controllo.", "Avviso");
				return;
			}

			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("csa_importverview.idcsa_import", Curr["idcsa_import"]),
				QHS.IsNotNull("csa_importverview.idexp_cost"),
				QHS.IsNotNull("csa_importverview.idepexp"));

			string sqlCmd = " SELECT csa_importverview.ayear as 'Eserc.', " +
			                " csa_importverview.idver as 'Numero Versamento', " +
			                " csa_importverview.yimport as 'Eserc. Import', " +
			                " csa_importverview.nimport as 'Num. Import.', " +
			                " csa_importverview.ruolocsa as 'Ruolo CSA', " +
			                " csa_importverview.capitolocsa as 'Capitolo CSA', " +
			                " csa_importverview.ente as 'Ente CSA', " +
			                " csa_importverview.vocecsa as 'Voce CSA', " +
			                " csa_importverview.matricola as 'Matricola', " +
			                " csa_importverview.importo as 'Importo', " +
			                " csa_importverview.registry as 'Anagrafica', " +
			                " csa_importverview.agency as 'Ente', " +
			                " csa_importverview.flagcr as 'Comp./Residui' " +
			                " FROM csa_importverview " +
			                " left outer join expenseyear EY ON EY.idexp = csa_importverview.idexp_cost AND  csa_importverview.ayear = EY.ayear " +
			                " left outer join epexpyear   EPY ON EPY.idepexp = csa_importverview.idepexp AND csa_importverview.ayear = EPY.ayear " +
			                " WHERE  " + filter +
			                " AND isnull(EY.idupb, '0001') <> isnull(EPY.idupb, '0001') ";

			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati(sender, e, T, "csa_importver", "default", filter);
			}
		}

		private void btn58_Click(object sender, EventArgs e) {
			//58) Ripartizione finanziaria dei contratti  (csa_contractexpense)senza una corrispondente ripartizione  nel finanziario(csa_contractepexp)
			if (Meta.IsEmpty) return;
			if (rdbExpToListing.Checked) {
				show("La modalità di verifica 'elenco' non è disponibile per questo controllo.", "Avviso");
				return;
			}

			DataRow Curr = DS.csa_import.Rows[0];
			string filter = " not exists ( " +
			                " select * from csa_contractepexpview RipEP " +
			                " where csa_contractexpenseview.idcsa_contract = RipEP.idcsa_contract " +
			                " and  csa_contractexpenseview.ayear =RipEP.ayear " +
			                " and  csa_contractexpenseview.ndetail =RipEP.ndetail " +
			                " and  csa_contractexpenseview.idupb = RipEP.idupb " +
			                " and  csa_contractexpenseview.quota = RipEP.quota) ";
			filter = QHS.AppAnd(QHS.CmpEq("ayear", Curr["yimport"]), filter);
			// ayear, contractkindcode, contractkind, ycontract,ncontract, phase, ymov, nmov, quota, codeupb,upb
			string sqlCmd = " SELECT ayear as 'Eserc.', " +
			                " idcsa_contractkind as '#id Regola generale CSA', " +
			                " contractkindcode as 'Cod. Regola generale CSA', " +
			                " contractkind as 'Regola generale CSA', " +
			                " idcsa_contract as '#id Regola specifica CSA', " +
			                " ycontract as 'Eserc. Regola specifica CSA', " +
			                " ncontract as 'Num. Regola specifica CSA', " +
			                " ndetail as '#id. dettaglio ripart.', " +
			                " quota as 'Quota Ripartizione Regola specifica CSA', " +
			                " phase as 'Fase', " +
			                " ymov as 'Eserc. Movimento', " +
			                " nmov as 'Num. Movimento', " +
			                " codeupb as 'Codice UPB Movimento', " +
			                " upb as 'UPB Movimento' " +
			                " FROM csa_contractexpenseview " +
			                " WHERE  " + filter;

			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati2(sender, e, T, "csa_contractexpenseview", "csa_contractexpense", "default", filter,
					filter);
			}
		}

		private void btn62_63_64_Click(object sender, EventArgs e, int errcode) {

			//62) Sospeso uscita per elaborazione dei lordi non valorizzato
			//63) Sospeso uscita per elaborazione dei versamenti non valorizzato - esercizio corrente
			//64) Sospeso uscita per elaborazione dei versamenti di dicembre non valorizzato - esercizio successivo -- commento non serve più
			if (!usePartition) return;
			int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
			int new_esercizio = esercizio + 1;
			if (Meta.IsEmpty) return;
			if (rdbExpToListing.Checked) {
				show("La modalità di verifica 'elenco' non è disponibile per questo controllo.", "Avviso");
				return;
			}

			DataRow Curr = DS.csa_import.Rows[0];
			string filter_62 = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]), QHS.IsNull("ybill_netti"));
			string filter_63 = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]),
				QHS.NullOrEq("ybill_versamenti", esercizio));
			string filter_64 = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]),
				QHS.NullOrEq("ybill_versamenti", new_esercizio),
				QHS.CmpEq("month(adate)", 12));
			string filter = "";
			if (errcode == 62) filter = filter_62;
			if (errcode == 63) filter = filter_63;
			if (errcode == 64) filter = filter_64;


			string sqlCmd = " SELECT yimport as 'Eserc. importazione', " +
			                " nimport as 'Numero importazione ', " +
			                " adate as 'Data contabile', " +
			                " month(adate) as 'Mese', " +
			                " ybill_netti as 'Eserc. sospeso netti', " +
			                " nbill_netti as 'Num. sospeso netti', " +
			                " ybill_versamenti as 'Eserc. sospeso versamenti', " +
			                " nbill_versamenti as 'Num. sospeso versamenti' " +

			                " FROM csa_import  " +
			                " WHERE  " + filter;

			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati2(sender, e, T, "csa_import", "csa_importview", "default", filter, filter);
			}
		}

		private void btn62_Click(object sender, EventArgs e) {
			btn62_63_64_Click(sender, e, 62);
		}

		private void btn63_Click(object sender, EventArgs e) {
			btn62_63_64_Click(sender, e, 63);
		}

		private void btn64_Click(object sender, EventArgs e) {
			btn62_63_64_Click(sender, e, 64);
		}


		private void btn59_Click(object sender, EventArgs e) {
			//59) Ripartizione finanziaria  dei contributi (csa_contracttaxtexpense)senza una corrispondente  ripartizione finanziaria(csa_contracttaxepexp)
			if (Meta.IsEmpty) return;
			if (rdbExpToListing.Checked) {
				show("La modalità di verifica 'elenco' non è disponibile per questo controllo.", "Avviso");
				return;
			}

			DataRow Curr = DS.csa_import.Rows[0];
			string filter = " not exists ( " +
			                " select * from csa_contracttaxepexpview RipEP " +
			                " where csa_contracttaxexpenseview.idcsa_contract = RipEP.idcsa_contract " +
			                " and  csa_contracttaxexpenseview.ayear =RipEP.ayear " +
			                " and  csa_contracttaxexpenseview.ndetail =RipEP.ndetail " +
			                " and  csa_contracttaxexpenseview.idupb = RipEP.idupb " +
			                " and csa_contracttaxexpenseview.quota = RipEP.quota) ";
			filter = QHS.AppAnd(QHS.CmpEq("ayear", Curr["yimport"]), filter);
			// ayear, contractkindcode, contractkind, ycontract,ncontract, phase, ymov, nmov, quota, codeupb,upb
			string sqlCmd = " SELECT ayear as 'Eserc.', " +
			                " idcsa_contractkind as '#id Regola generale CSA', " +
			                " contractkindcode as 'Cod. Regola generale CSA', " +
			                " contractkind as 'Regola generale CSA', " +
			                " idcsa_contract as '#id Regola specifica CSA', " +
			                " ycontract as 'Eserc. Regola specifica CSA', " +
			                " ncontract as 'Num. Regola specifica CSA', " +
			                " idcsa_contracttax as '#id rip. contributo', " +
			                " voceCSA as 'Voce CSA', " +
			                " ndetail as '#id. dettaglio ripart.' ," +
			                " quota as 'Quota Ripartizione Regola specifica CSA', " +
			                " phase as 'Fase', " +
			                " ymov as 'Eserc. Mov. Fin.', " +
			                " nmov as 'Num. Mov. Fin.', " +
			                " codeupb as 'Codice UPB Mov. Fin.', " +
			                " upb as 'UPB Mov. Fin.' " +
			                " FROM csa_contracttaxexpenseview  " +
			                " WHERE  " + filter;

			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati2(sender, e, T, "csa_contracttaxexpenseview", "csa_contracttaxexpense", "default", filter,
					filter);
			}
		}

		private void btn60_Click(object sender, EventArgs e) {
			//60)  Righe di versamento non ripartite
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.CmpEq("idcsa_import", Curr["idcsa_import"]);

			filter +=
				" AND NOT EXISTS(SELECT * FROM csa_importver_partition CE where csa_importverview.idcsa_import = CE.idcsa_import and csa_importverview.idver = CE.idver  " +
				" ) ";

			string sqlCmd = " SELECT ayear as 'Eserc.', " +
			                " idver as 'Numero Versamento', " +
			                " yimport as 'Eserc. Import', " +
			                " nimport as 'Num. Import.', " +
			                " ruolocsa as 'Ruolo CSA', " +
			                " capitolocsa as 'Capitolo CSA', " +
			                " ente as 'Ente CSA', " +
			                " vocecsa as 'Voce CSA', " +
			                " matricola as 'Matricola', " +
			                " importo as 'Importo', " +
			                " registry as 'Anagrafica', " +
			                " agency as 'Ente', " +
			                " flagcr as 'Comp./Residui' " +
			                " FROM csa_importverview " +
			                " WHERE  " + filter;


			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati2(sender, e, T, "csa_importver", "csa_importverview", "default",
					filter.Replace("csa_importverview", "csa_importver"), filter);
			}
		}


		private void btn61_Click(object sender, EventArgs e) {
			// 61) Righe di riepilogo non ripartite
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]));

			filter +=
				" AND NOT EXISTS(SELECT * FROM csa_importriep_partition CE where csa_importriepview.idcsa_import = CE.idcsa_import and csa_importriepview.idriep = CE.idriep  " +
				" ) ";

			string sqlCmd = " SELECT ayear as 'Eserc.', " +
			                " idriep as 'Numero Riepilogo', " +
			                " (select sum(CE.quota)  from csa_importriep_epexp CE " +
			                " where csa_importriepview.idcsa_import = CE.idcsa_import and csa_importriepview.idriep = CE.idriep) as Quota, " +
			                " yimport as 'Eserc. Import', " +
			                " nimport as 'Num. Import.', " +
			                " ruolocsa as 'Ruolo CSA', " +
			                " capitolocsa as 'Capitolo CSA', " +
			                " matricola as 'Matricola', " +
			                " importo as 'Importo', " +
			                " registry as 'Anagrafica', " +
			                " flagcr as 'Comp./Residui' " +
			                " FROM csa_importriepview  " +
			                " WHERE  " + filter;


			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati(sender, e, T, "csa_importriep", "default", filter);
			}
		}


		private void btnEP0_Click(object sender, EventArgs e) {
			//'Conto di costo (idacc_cost) non valorizzato su alcune righe positive del file riepiloghi'
			if (Meta.IsEmpty) return;

			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]),
				QHS.CmpGt("importo", 0));
			if (!usePartition)
				filter = QHS.AppAnd(filter, QHS.IsNull("idacc"));
			else

				filter += " AND NOT EXISTS (select * from csa_importriep_partition RP where " +
				          " csa_importriepview.idcsa_import = RP.idcsa_import AND " +
				          " csa_importriepview.idriep = RP.idriep" +
				          " ) ";
			filter += " OR EXISTS (select * from csa_importriep_partition RP where " +
			          " csa_importriepview.idcsa_import = RP.idcsa_import AND " +
			          " csa_importriepview.idriep = RP.idriep AND" +
			          " RP.idacc IS NULL) ";

			string sqlCmd = " SELECT ayear as 'Eserc.', " +
			                " idriep as 'Numero Riepilogo', " +
			                " yimport as 'Eserc. Import', " +
			                " nimport as 'Num. Import.', " +
			                " ruolocsa as 'Ruolo CSA', " +
			                " capitolocsa as 'Capitolo CSA', " +
			                " matricola as 'Matricola', " +
			                " importo as 'Importo', " +
			                " registry as 'Anagrafica', " +
			                " flagcr as 'Comp./Residui' " +
			                " FROM csa_importriepview " +
			                " WHERE  " + filter;


			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				if (T != null) {
					VisualizzaDati2(sender, e, T, "csa_importriep", "csa_importriepview", "default",
						filter.Replace("csa_importriepview", "csa_importriep"), filter);
				}

			}
		}

		private void btnEP1_Click(object sender, EventArgs e) {
			//'Conto di ricavo lordi (idacc_revenue_gross_csa in configurazione anuuale) non valorizzato riepiloghi negativi ' 
			object idacc_revenue_gross_csa = Get_Account_Revenue_CSA();
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]),
				QHS.CmpLt("importo", 0));
			string sqlCmd = " SELECT ayear as 'Eserc.', " +
			                " idriep as 'Numero Riepilogo', " +
			                " yimport as 'Eserc. Import', " +
			                " nimport as 'Num. Import.', " +
			                " ruolocsa as 'Ruolo CSA', " +
			                " capitolocsa as 'Capitolo CSA', " +
			                " matricola as 'Matricola', " +
			                " importo as 'Importo', " +
			                " registry as 'Anagrafica', " +
			                " flagcr as 'Comp./Residui' " +
			                " FROM csa_importriepview " +
			                " WHERE  " + filter;

			DataTable T = Conn.SQLRunner(sqlCmd);

			if ((T != null) && (idacc_revenue_gross_csa == DBNull.Value)) {
				VisualizzaDati(sender, e, T, "csa_importriep", "default", filter);
			}
		}

		private void btnEP2_Click(object sender, EventArgs e) {
			//'Conto di costo (idacc_cost ) non valorizzato in righe versamento di contributi positivi ' 
			if (Meta.IsEmpty) return;

			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]), QHS.CmpEq("flagclawback", "N"),
				QHS.DoPar(QHS.AppOr(QHS.IsNotNull("idcsa_contracttax"), QHS.IsNotNull("idcsa_contractkinddata"))),
				//QHS.IsNotNull("idcsa_incomesetup"),
				QHS.CmpGt("importo", 0));
			if (!usePartition)
				filter = QHS.AppAnd(filter, QHS.IsNull("idacc_cost"));
			else {
				filter += " AND (NOT EXISTS (select * from csa_importver_partition RP where " +
				          " csa_importverview.idcsa_import = RP.idcsa_import AND " +
				          " csa_importverview.idver= RP.idver" +
				          " )  ";
				filter += " OR EXISTS (select * from csa_importver_partition RP where " +
				          " csa_importverview.idcsa_import = RP.idcsa_import AND " +
				          " csa_importverview.idver= RP.idver AND" +
				          " RP.idacc IS NULL)) ";

			}

			string sqlCmd = " SELECT ayear as 'Eserc.', " +
			                " idver as 'Numero Versamento', " +
			                " yimport as 'Eserc. Import', " +
			                " nimport as 'Num. Import.', " +
			                " ruolocsa as 'Ruolo CSA', " +
			                " capitolocsa as 'Capitolo CSA', " +
			                " ente as 'Ente CSA', " +
			                " vocecsa as 'Voce CSA', " +
			                " matricola as 'Matricola', " +
			                " importo as 'Importo', " +
			                " registry as 'Anagrafica', " +
			                " agency as 'Ente', " +
			                " flagcr as 'Comp./Residui' " +
			                " FROM csa_importverview " +
			                " WHERE  " + filter;

			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati2(sender, e, T, "csa_importver", "csa_importverview", "default", filter, filter);
			}
		}

		private void btnEP3_Click(object sender, EventArgs e) {
			//'Conto di debito conto/verso erario non valorizzati in contributi'
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];

			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]), QHS.CmpEq("flagclawback", "N"),
				QHS.DoPar(QHS.AppOr(QHS.IsNotNull("idcsa_contracttax"), QHS.IsNotNull("idcsa_contractkinddata"))),
				//QHS.IsNotNull("idcsa_incomesetup"),
				QHS.IsNull("idacc_expense"), QHS.CmpGt("importo", 0));
			// per la gestione con ripartizioni non si usa "idacc_debit"
			if (!usePartition)
				filter += QHS.IsNull("idacc_debit");
			string sqlCmd = " SELECT ayear as 'Eserc.', " +
			                " idver as 'Numero Versamento', " +
			                " yimport as 'Eserc. Import', " +
			                " nimport as 'Num. Import.', " +
			                " ruolocsa as 'Ruolo CSA', " +
			                " capitolocsa as 'Capitolo CSA', " +
			                " ente as 'Ente CSA', " +
			                " vocecsa as 'Voce CSA', " +
			                " matricola as 'Matricola', " +
			                " importo as 'Importo', " +
			                " registry as 'Anagrafica', " +
			                " agency as 'Ente', " +
			                " flagcr as 'Comp./Residui' " +
			                " FROM csa_importverview " +
			                " WHERE  " + filter;

			DataTable T = Conn.SQLRunner(sqlCmd);


			if (T != null) {
				VisualizzaDati2(sender, e, T, "csa_importver", "csa_importverview", "default", filter, filter);
			}
		}

		private void btnEP4_Click(object sender, EventArgs e) {
			//'Conto di costo non valorizzato in righe versamento di recuperi negativi'          if (Meta.IsEmpty) return;

			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]), QHS.CmpEq("flagclawback", "S")
				, QHS.CmpLt("importo", 0));
			if (!usePartition)
				filter = QHS.AppAnd(filter, QHS.IsNull("idacc_cost"));
			else {
				filter += " AND NOT EXISTS (select * from csa_importver_partition RP where " +
				          " csa_importverview.idcsa_import = RP.idcsa_import AND " +
				          " csa_importverview.idver= RP.idver" +
				          " ) ";
				filter += " AND EXISTS (select * from csa_importver_partition RP where " +
				          " csa_importverview.idcsa_import = RP.idcsa_import AND " +
				          " csa_importverview.idver= RP.idver AND " +
				          " RP.idacc IS NULL) ";
			}

			string sqlCmd = " SELECT ayear as 'Eserc.', " +
			                " idver as 'Numero Versamento', " +
			                " yimport as 'Eserc. Import', " +
			                " nimport as 'Num. Import.', " +
			                " ruolocsa as 'Ruolo CSA', " +
			                " capitolocsa as 'Capitolo CSA', " +
			                " ente as 'Ente CSA', " +
			                " vocecsa as 'Voce CSA', " +
			                " matricola as 'Matricola', " +
			                " importo as 'Importo', " +
			                " registry as 'Anagrafica', " +
			                " agency as 'Ente', " +
			                " flagcr as 'Comp./Residui' " +
			                " FROM csa_importverview " +
			                " WHERE  " + filter;

			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati2(sender, e, T, "csa_importver", "csa_importverview", "default", filter, filter);
			}
		}

		private void btnEP5_Click(object sender, EventArgs e) {
			//'Conto di ricavo (idacc_revenue) non valorizzato in righe versamento di contributi negativi'
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]), QHS.CmpEq("flagclawback", "N"),
				QHS.DoPar(QHS.AppOr(QHS.IsNotNull("idcsa_contracttax"), QHS.IsNotNull("idcsa_contractkinddata"))),
				//QHS.IsNotNull("idcsa_incomesetup"),
				QHS.IsNull("idacc_revenue"), QHS.CmpLt("importo", 0));
			string sqlCmd = " SELECT ayear as 'Eserc.', " +
			                " idver as 'Numero Versamento', " +
			                " yimport as 'Eserc. Import', " +
			                " nimport as 'Num. Import.', " +
			                " ruolocsa as 'Ruolo CSA', " +
			                " capitolocsa as 'Capitolo CSA', " +
			                " ente as 'Ente CSA', " +
			                " vocecsa as 'Voce CSA', " +
			                " matricola as 'Matricola', " +
			                " importo as 'Importo', " +
			                " registry as 'Anagrafica', " +
			                " agency as 'Ente', " +
			                " flagcr as 'Comp./Residui' " +
			                " FROM csa_importverview " +
			                " WHERE  " + filter;

			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati(sender, e, T, "csa_importver", "default", filter);
			}
		}

		private void btnEP6_Click(object sender, EventArgs e) {
			//'Conto di ricavo (idacc_revenue) non valorizzato in righe versamento di recuperi positivi'
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]), QHS.CmpEq("flagclawback", "S"),
				QHS.IsNull("idacc_revenue"), QHS.CmpGt("importo", 0));
			string sqlCmd = " SELECT ayear as 'Eserc.', " +
			                " idver as 'Numero Versamento', " +
			                " yimport as 'Eserc. Import', " +
			                " nimport as 'Num. Import.', " +
			                " ruolocsa as 'Ruolo CSA', " +
			                " capitolocsa as 'Capitolo CSA', " +
			                " ente as 'Ente CSA', " +
			                " vocecsa as 'Voce CSA', " +
			                " matricola as 'Matricola', " +
			                " importo as 'Importo', " +
			                " registry as 'Anagrafica', " +
			                " agency as 'Ente', " +
			                " flagcr as 'Comp./Residui' " +
			                " FROM csa_importverview " +
			                " WHERE  " + filter;

			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati(sender, e, T, "csa_importver", "default", filter);
			}
		}

		private void btnEP7_Click(object sender, EventArgs e) {
			//'Conto di debito verso erario (idacc_expense) non valorizzato in righe versamento di ritenute positive'
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]), QHS.CmpEq("flagclawback", "N"),
				QHS.IsNull("idcsa_contracttax"), QHS.IsNull("idcsa_contractkinddata"),
				QHS.IsNotNull("idcsa_incomesetup"),
				QHS.IsNull("idacc_expense"), QHS.CmpGt("importo", 0));
			string sqlCmd = " SELECT ayear as 'Eserc.', " +
			                " idver as 'Numero Versamento', " +
			                " yimport as 'Eserc. Import', " +
			                " nimport as 'Num. Import.', " +
			                " ruolocsa as 'Ruolo CSA', " +
			                " capitolocsa as 'Capitolo CSA', " +
			                " ente as 'Ente CSA', " +
			                " vocecsa as 'Voce CSA', " +
			                " matricola as 'Matricola', " +
			                " importo as 'Importo', " +
			                " registry as 'Anagrafica', " +
			                " agency as 'Ente', " +
			                " flagcr as 'Comp./Residui' " +
			                " FROM csa_importverview " +
			                " WHERE  " + filter;

			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati(sender, e, T, "csa_importver", "default", filter);
			}
		}

		private void btnEP8_Click(object sender, EventArgs e) {
			//INSERT INTO #errors VALUES('Conto di credito verso erario (idacc_agency_credit) non valorizzato in righe versamento di ritenute negative', 9,'S')
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]), QHS.CmpEq("flagclawback", "N"),
				QHS.IsNull("idcsa_contracttax"), QHS.IsNull("idcsa_contractkinddata"),
				QHS.IsNotNull("idcsa_incomesetup"),
				QHS.IsNull("idacc_agency_credit"), QHS.CmpLt("importo", 0));
			string sqlCmd = " SELECT ayear as 'Eserc.', " +
			                " idver as 'Numero Versamento', " +
			                " yimport as 'Eserc. Import', " +
			                " nimport as 'Num. Import.', " +
			                " ruolocsa as 'Ruolo CSA', " +
			                " capitolocsa as 'Capitolo CSA', " +
			                " ente as 'Ente CSA', " +
			                " vocecsa as 'Voce CSA', " +
			                " matricola as 'Matricola', " +
			                " importo as 'Importo', " +
			                " registry as 'Anagrafica', " +
			                " agency as 'Ente', " +
			                " flagcr as 'Comp./Residui' " +
			                " FROM csa_importverview " +
			                " WHERE  " + filter;

			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati(sender, e, T, "csa_importver", "default", filter);
			}
		}

		private void btnEP9_Click(object sender, EventArgs e) {
			//INSERT INTO #errors VALUES('Conto di credito verso erario (idacc_agency_credit) non valorizzato in righe versamento di contributi negativi', 10,'S')        }
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]), QHS.CmpEq("flagclawback", "N"),
				QHS.DoPar(QHS.AppOr(QHS.IsNotNull("idcsa_contracttax"), QHS.IsNotNull("idcsa_contractkinddata"))),
				//QHS.IsNotNull("idcsa_incomesetup"),
				QHS.IsNull("idacc_agency_credit"), QHS.CmpLt("importo", 0));
			string sqlCmd = " SELECT ayear as 'Eserc.', " +
			                " idver as 'Numero Versamento', " +
			                " yimport as 'Eserc. Import', " +
			                " nimport as 'Num. Import.', " +
			                " ruolocsa as 'Ruolo CSA', " +
			                " capitolocsa as 'Capitolo CSA', " +
			                " ente as 'Ente CSA', " +
			                " vocecsa as 'Voce CSA', " +
			                " matricola as 'Matricola', " +
			                " importo as 'Importo', " +
			                " registry as 'Anagrafica', " +
			                " agency as 'Ente', " +
			                " flagcr as 'Comp./Residui' " +
			                " FROM csa_importverview " +
			                " WHERE  " + filter;

			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati(sender, e, T, "csa_importver", "default", filter);
			}
		}

		private void btnEP10_Click(object sender, EventArgs e) {
			// 11) Conto di costo per il lordo non valorizzato in righe Contratti CSA
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];

			string filter = QHS.AppAnd(QHS.CmpEq("ayear", Curr["yimport"]), QHS.CmpEq("active", "S"));
			if (!usePartition)
				filter = QHS.AppAnd(filter, QHS.IsNull("idacc_main"));
			else {
				filter += " AND (NOT EXISTS (select * from csa_contract_partition RP where " +
				          " csa_contractview.idcsa_contract = RP.idcsa_contract AND " +
				          " csa_contractview.ayear= RP.ayear" +
				          " ) ";
				filter += " OR EXISTS (select * from csa_contract_partition RP where " +
				          " csa_contractview.idcsa_contract = RP.idcsa_contract AND " +
				          " csa_contractview.ayear= RP.ayear AND" +
				          " RP.idacc IS NULL)) ";
			}

			string sqlCmd = " SELECT ayear as 'Eserc.', " +
			                " idcsa_contract as '#id Regola specifica CSA', " +
			                " ycontract as 'Eserc. Regola specifica CSA', " +
			                " ncontract as 'Num. Regola specifica CSA.', " +
			                " csa_contractkindcode as 'Cod. Regola generale CSA', " +
			                " csa_contractkind as 'Regola generale CSA', " +
			                " title as 'Denominazione', " +
			                " description as 'Descrizione' " +
			                " FROM csa_contractview   " +
			                " WHERE  " + filter;

			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati2(sender, e, T, "csa_contract", "csa_contractview", "elenco", filter, filter);
			}

		}

		// 12) Conto di costo per contributi di Regola specifica CSA (idacc) non valorizzato in righe Contributi di Contratti CSA
		// non bloccante
		private void btnEP11_Click(object sender, EventArgs e) {
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("ayear", Curr["yimport"]), QHS.CmpEq("active", "S"));

			if (!usePartition)
				filter = filter = QHS.AppAnd(filter, QHS.IsNull("idacc"));
			else {
				filter += " AND NOT EXISTS (select * from csa_contracttax_partition RP where " +
				          " csa_contracttaxview.idcsa_contract = RP.idcsa_contract AND " +
				          " csa_contracttaxview.idcsa_contracttax = RP.idcsa_contracttax AND " +
				          " csa_contracttaxview.ayear= RP.ayear" +
				          " ) ";
				filter += " OR EXISTS (select * from csa_contracttax_partition RP where " +
				          " csa_contracttaxview.idcsa_contract = RP.idcsa_contract AND " +
				          " csa_contracttaxview.idcsa_contracttax = RP.idcsa_contracttax AND " +
				          " csa_contracttaxview.ayear= RP.ayear AND" +
				          " RP.idacc IS NULL) ";
			}

			string sqlCmd = " SELECT ayear as 'Eserc.', " +
			                " idcsa_contract as '#id Regola specifica CSA', " +
			                " idcsa_contracttax as '#id Regola specifica CSA', " +
			                " ycontract as 'Eserc. Regola specifica CSA', " +
			                " ncontract as 'Num. Regola specifica CSA.', " +
			                " contractkindcode as 'Cod. Regola generale CSA', " +
			                " contractkind as 'Regola generale CSA', " +
			                " voceCSA as 'Voce CSA' " +
			                " FROM csa_contracttaxview  " +
			                " WHERE  " + filter;

			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati2(sender, e, T, "csa_contracttax", "csa_contracttaxview", "elenco", filter, filter);
			}
		}

		// 13) Conto di costo per   il lordo(idacc_main) non valorizzato in righe Tipi di Contratti CSA attivi
		// non bloccante, dipende dalle situazioni, se ci sono contratti prevale la configurazione dei contratti
		private void btnEP12_Click(object sender, EventArgs e) {
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("ayear", Curr["yimport"]), QHS.IsNull("idacc_main"),
				QHS.CmpEq("active", "S"));
			string sqlCmd = " SELECT ayear as 'Eserc.', " +
			                " idcsa_contractkind as '#id Regola generale CSA', " +
			                " contractkindcode as 'Cod. Regola generale CSA', " +
			                " description as 'Regola generale CSA' " +
			                " FROM csa_contractkindview " +
			                " WHERE  " + filter;

			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati2(sender, e, T, "csa_contractkind", "csa_contractkindview", "default", filter, filter);
			}
		}

		//14) Conto di costo per contributi di Regola generale CSA(idacc) non valorizzato in righe Contributi di Tipi Contratti CSA
		//non bloccante, dipende dalle situazioni
		private void btnEP13_Click(object sender, EventArgs e) {
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("ayear", Curr["yimport"]), QHS.IsNull("idacc"));
			string sqlCmd = " SELECT ayear as 'Eserc.', " +
			                " idcsa_contractkind as '#id Regola generale CSA', " +
			                " csa_contractkindcode as 'Cod. Regola generale CSA', " +
			                " csa_contractkind as 'Regola generale CSA', " +
			                " voceCSA as 'Voce CSA' " +
			                " FROM csa_contractkinddataview " +
			                " WHERE  " + filter;

			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati2(sender, e, T, "csa_contractkinddata", "csa_contractkinddata", "default", filter,
					filter);
			}
		}

		//14) Ripartizione in Impegni di Budget dei contratti dei contratti(csa_contractepexp) 
		//senza una corrispondente ripartizione nel finanziario(csa_contractexpense) con stesso upb e quota

		private void btnEP14_Click(object sender, EventArgs e) {

			if (Meta.IsEmpty) return;
			if (rdbExpToListing.Checked) {
				show("La modalità di verifica 'elenco' non è disponibile per questo controllo.", "Avviso");
				return;
			}

			DataRow Curr = DS.csa_import.Rows[0];
			string filter = " not exists ( " +
			                " select * from csa_contractexpenseview Ripfin " +
			                " where csa_contractepexpview.idcsa_contract = Ripfin.idcsa_contract " +
			                " and  csa_contractepexpview.ayear = Ripfin.ayear " +
			                " and  csa_contractepexpview.ndetail = Ripfin.ndetail " +
			                " and  csa_contractepexpview.idupb = Ripfin.idupb " +
			                " and  csa_contractepexpview.quota = Ripfin.quota) ";
			filter = QHS.AppAnd(QHS.CmpEq("ayear", Curr["yimport"]), filter);
			// ayear, contractkindcode, contractkind, ycontract,ncontract, phase, yepexp, nepexp, quota, codeupb,upb
			string sqlCmd = " SELECT ayear as 'Eserc.', " +
			                " idcsa_contractkind as '#id Regola generale CSA', " +
			                " contractkindcode as 'Cod. Regola generale CSA', " +
			                " contractkind as 'Regola generale CSA', " +
			                " idcsa_contract as '#id Regola specifica CSA', " +
			                " ycontract as 'Eserc. Regola specifica CSA', " +
			                " ncontract as 'Num. Regola specifica CSA', " +
			                " ndetail as '#id. dettaglio ripart.', " +
			                " quota as 'Quota Ripartizione Regola specifica CSA', " +
			                " phase as 'Fase', " +
			                " yepexp as 'Eserc. Preimpegno', " +
			                " nepexp as 'Num. Preimpegno', " +
			                " codeupb as 'Codice UPB Preimpegno', " +
			                " upb as 'UPB Preimpegno' " +
			                " FROM csa_contractepexpview  " +
			                " WHERE  " + filter;

			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				//VisualizzaDati(sender, e, T, "csa_contractepexp", "elenco", filter);
				VisualizzaDati2(sender, e, T, "csa_contractepexp", "csa_contractepexpview", "elenco",
					filter, filter);
			}
		}

		//15) Ripartizione in Impegni di Budget dei contributi(tabella csa_contracttaxtepexp) 
		//senza una corrispondente ripartizione nel finanziario(csa_contractexpense) con stesso upb e quota
		private void btnEP15_Click(object sender, EventArgs e) {

			if (Meta.IsEmpty) return;
			if (rdbExpToListing.Checked) {
				show("La modalità di verifica 'elenco' non è disponibile per questo controllo.", "Avviso");
				return;
			}

			DataRow Curr = DS.csa_import.Rows[0];
			string filter = " not exists ( " +
			                " select * from csa_contracttaxexpenseview RipTaxfin " +
			                " where csa_contracttaxepexpview.idcsa_contract = RipTaxfin.idcsa_contract " +
			                " and  csa_contracttaxepexpview.ayear = RipTaxfin.ayear " +
			                " and  csa_contracttaxepexpview.ndetail = RipTaxfin.ndetail " +
			                " and  csa_contracttaxepexpview.idupb = RipTaxfin.idupb " +
			                " and  csa_contracttaxepexpview.quota = RipTaxfin.quota) ";
			filter = QHS.AppAnd(QHS.CmpEq("csa_contracttaxepexpview.ayear", Curr["yimport"]), filter,
				QHS.CmpEq("csa_contract.active", "S"));
			// ayear, contractkindcode, contractkind, ycontract,ncontract, phase, yepexp, nepexp, quota, codeupb,upb
			string sqlCmd = " SELECT csa_contracttaxepexpview.ayear as 'Eserc.', " +
			                " csa_contracttaxepexpview.idcsa_contractkind as '#id Regola generale CSA', " +
			                " csa_contracttaxepexpview.contractkindcode as 'Cod. Regola generale CSA', " +
			                " csa_contracttaxepexpview.contractkind as 'Regola generale CSA', " +
			                " csa_contracttaxepexpview.idcsa_contract as '#id Regola specifica CSA', " +
			                " csa_contracttaxepexpview.idcsa_contracttax as '#id Regola specifica CSA', " +
			                " csa_contracttaxepexpview.ycontract as 'Eserc. Regola specifica CSA', " +
			                " csa_contracttaxepexpview.ncontract as 'Num. Regola specifica CSA', " +
			                " csa_contracttaxepexpview.voceCSA as 'Voce CSA', " +
			                " csa_contracttaxepexpview.ndetail as '#id. dettaglio ripart.', " +
			                " csa_contracttaxepexpview.phase as 'Fase', " +
			                " csa_contracttaxepexpview.yepexp as 'Eserc. Preimpegno', " +
			                " csa_contracttaxepexpview.nepexp as 'Num. Preimpegno', " +
			                " csa_contracttaxepexpview.quota as 'Quota Ripartizione Regola specifica CSA', " +
			                " csa_contracttaxepexpview.codeupb as 'Codice UPB Preimpegno', " +
			                " upb as 'UPB Preimpegno' " +
			                " FROM csa_contracttaxepexpview " +
			                " join csa_contract  on csa_contract.idcsa_contract =csa_contracttaxepexpview.idcsa_contract " +
			                " WHERE  " + filter;

			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				//VisualizzaDati(sender, e, T, "csa_contracttaxepexp", "elenco", filter);
				VisualizzaDati2(sender, e, T, "csa_contracttaxepexp", "csa_contracttaxepexpview", "elenco",
					filter, filter);
			}
		}

		private void btnEP16_Click(object sender, EventArgs e) {
			// 'Contributi a liquidazione diretta Conto di Debito verso ente,  Conto di Credito verso ente o conto di ricavo ' +
			//' non configurati nella scheda Voce CSA del contruto (idacc_expense, idacc_agency_credit, idacc_revenue in csa_importver)
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = " (exists ( " +
			                " select * from csa_contracttax  " +
			                " where csa_contracttax.vocecsa = csa_incomesetupview.vocecsa " +
			                " and  csa_contracttax.ayear = csa_incomesetupview.ayear) " +
			                " or exists ( " +
			                " select * from csa_contractkinddata  " +
			                " where csa_contractkinddata.vocecsa = csa_incomesetupview.vocecsa " +
			                " and  csa_contractkinddata.ayear = csa_incomesetupview.ayear)) ";
			filter = QHS.AppAnd(QHS.CmpEq("ayear", Meta.GetSys("esercizio")), filter,
				QHS.DoPar(QHS.AppOr(QHS.IsNull("idacc_revenue"),
					QHS.IsNull("idacc_expense"), QHS.IsNull("idacc_agency_credit"))), QHS.IsNull("idfin_income"));
			string sqlCmd = " SELECT csa_incomesetupview.ayear as 'Eserc.', " +
			                " csa_incomesetupview.vocecsa as 'Voce CSA', " +
			                " csa_incomesetupview.codeupb as 'Cod. UPB', " +
			                " csa_incomesetupview.upb as 'UPB', " +
			                " csa_incomesetupview.codeacc_expense as 'Conto di Debito Verso Ente', " +
			                " csa_incomesetupview.codeacc_revenue as 'Conto di Ricavo', " +
			                " csa_incomesetupview.codeacc_agency_credit as 'Conto di Credito verso ente' " +
			                " FROM csa_incomesetupview " +
			                " WHERE  " + filter;

			DataTable T = Conn.SQLRunner(sqlCmd);
			if (T != null) {
				//VisualizzaDati(sender, e, T, "csa_contracttaxepexp", "elenco", filter);
				VisualizzaDati2(sender, e, T, "csa_incomesetup", "csa_incomesetupview", "default",
					filter, filter);
			}
		}


		private void btnEP17_Click(object sender, EventArgs e) {
			// 'Contributi su partita di giro: Conto di Debito verso ente,  Conto di Credito verso ente, Conto di Debito Conto Ente o Conto di Ricavo ' +
			//' non configurati nella scheda Voce CSA del contruto (idacc_expense, idacc_agency_credit, idacc_revenue in csa_incomesetup)
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = " (exists ( " +
			                " select * from csa_contracttax  " +
			                " where csa_contracttax.vocecsa = csa_incomesetupview.vocecsa " +
			                " and  csa_contracttax.ayear = csa_incomesetupview.ayear) " +
			                " or exists ( " +
			                " select * from csa_contractkinddata  " +
			                " where csa_contractkinddata.vocecsa = csa_incomesetupview.vocecsa " +
			                " and  csa_contractkinddata.ayear = csa_incomesetupview.ayear)) ";
			filter = QHS.AppAnd(QHS.CmpEq("ayear", Meta.GetSys("esercizio")), filter,
				QHS.DoPar(QHS.AppOr(QHS.IsNull("idacc_debit"),
					QHS.IsNull("idacc_expense"), QHS.IsNull("idacc_agency_credit"), QHS.IsNull("idacc_revenue"))),
				QHS.IsNull("idfin_income"));
			string sqlCmd = " SELECT csa_incomesetupview.ayear as 'Eserc.', " +
			                " csa_incomesetupview.vocecsa as 'Voce CSA', " +
			                " csa_incomesetupview.codeupb as 'Cod. UPB', " +
			                " csa_incomesetupview.upb as 'UPB', " +
			                " csa_incomesetupview.codeacc_expense as 'Conto di Debito Verso Ente', " +
			                " csa_incomesetupview.codeacc_debit as 'Conto di Debito Conto Ente', " +
			                " csa_incomesetupview.codeacc_agency_credit as 'Conto di Credito verso ente', " +
			                " csa_incomesetupview.codeacc_revenue as 'Conto di Ricavo' " +
			                " FROM csa_incomesetupview " +
			                " WHERE  " + filter;

			DataTable T = Conn.SQLRunner(sqlCmd);
			if (T != null) {
				//VisualizzaDati(sender, e, T, "csa_contracttaxepexp", "elenco", filter);
				VisualizzaDati2(sender, e, T, "csa_incomesetup", "csa_incomesetupview", "default",
					filter, filter);
			}
		}

		//--22)  Righe di versamento con preimpegno di budget avente conto incoerente con quello della ripartizione nell''esercizio corrente
		private void btnEP21_Click(object sender, EventArgs e) {
			//Righe di versamento con preipegno di budget avente conto incoerente con quello della ripartizione nell''esercizio corrente

			if (Meta.IsEmpty) return;

			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]),
				QHS.CmpEq("ayear", Conn.GetEsercizio()));


			//filter += " AND EXISTS (select * from csa_importver_partition RP where " +
			//	  " R.idcsa_import = RP.idcsa_import AND " +
			//	  " R.idver = RP.idver AND" +
			//	  " RP.idepexp IS NOT NULL) ";
			filter += " AND EXISTS (select * from epexpyear EY " +
			          " JOIN csa_importver_partition RP ON " +
			          " csa_importverview.idcsa_import = RP.idcsa_import AND " +
			          " csa_importverview.idver = RP.idver AND " +
			          " EY.idepexp = RP.idepexp AND " +
			          " EY.idacc <> RP.idacc AND " +
			          " csa_importverview.ayear = EY.ayear ) ";


			string sqlCmd = " SELECT ayear as 'Eserc.', " +
			                " idver as 'Numero Versamento', " +
			                " yimport as 'Eserc. Import', " +
			                " nimport as 'Num. Import.', " +
			                " ruolocsa as 'Ruolo CSA', " +
			                " capitolocsa as 'Capitolo CSA', " +
			                " ente as 'Ente CSA', " +
			                " vocecsa as 'Voce CSA', " +
			                " matricola as 'Matricola', " +
			                " importo as 'Importo', " +
			                " registry as 'Anagrafica', " +
			                " agency as 'Ente', " +
			                " flagcr as 'Comp./Residui' " +
			                " FROM csa_importverview  " +
			                " WHERE  " + filter;

			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {

				VisualizzaDati(sender, e, T, "csa_importver", "default",
					filter.Replace("csa_importverview.", "csa_importver."));
			}
		}

//--23)  Righe di versamento con preimpegno di budget avente UPB incoerente con quello della ripartizione nell''esercizio corrente
		private void btnEP22_Click(object sender, EventArgs e) {
			if (Meta.IsEmpty) return;

			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]),
				QHS.CmpEq("ayear", Conn.GetEsercizio()));


			//filter += " AND EXISTS (select * from csa_importver_partition RP where " +
			//	  " R.idcsa_import = RP.idcsa_import AND " +
			//	  " R.idver = RP.idver AND" +
			//	  " RP.idepexp IS NOT NULL) ";
			filter += " AND EXISTS (select * from epexpyear EY " +
			          " JOIN csa_importver_partition VP ON " +
			          " csa_importverview.idcsa_import = VP.idcsa_import AND " +
			          " csa_importverview.idver = VP.idver AND " +
			          " EY.idepexp = VP.idepexp AND " +
			          " EY.idupb <> VP.idupb AND " +
			          " csa_importverview.ayear = EY.ayear ) ";


			string sqlCmd = " SELECT ayear as 'Eserc.', " +
			                " idver as 'Numero Versamento', " +
			                " yimport as 'Eserc. Import', " +
			                " nimport as 'Num. Import.', " +
			                " ruolocsa as 'Ruolo CSA', " +
			                " capitolocsa as 'Capitolo CSA', " +
			                " ente as 'Ente CSA', " +
			                " vocecsa as 'Voce CSA', " +
			                " matricola as 'Matricola', " +
			                " importo as 'Importo', " +
			                " registry as 'Anagrafica', " +
			                " agency as 'Ente', " +
			                " flagcr as 'Comp./Residui' " +
			                " FROM csa_importverview " +
			                " WHERE  " + filter;

			DataTable T = Conn.SQLRunner(sqlCmd, false, 600);

			if (T != null) {
				VisualizzaDati(sender, e, T, "csa_importver", "default",
					filter.Replace("csa_importverview.", "csa_importver."));
			}
		}

//--24)  Righe di riepilogo con preimpegno di budget avente conto incoerente con quello della ripartizione nell''esercizio corrente
		private void btnEP23_Click(object sender, EventArgs e) {

			if (Meta.IsEmpty) return;

			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]),
				QHS.CmpEq("ayear", Conn.GetEsercizio()));

			//filter += " AND EXISTS (select * from csa_importriep_partition RP where " +
			//	  " R.idcsa_import = RP.idcsa_import AND " +
			//	  " R.idriep = RP.idriep AND" +
			//	  " RP.idepexp IS NOT NULL) ";
			filter += " AND EXISTS (select * from epexpyear EY " +
			          " JOIN csa_importriep_partition RP ON " +
			          " csa_importriepview.idcsa_import = RP.idcsa_import AND " +
			          " csa_importriepview.idriep = RP.idriep AND " +
			          " EY.idepexp = RP.idepexp AND " +
			          " EY.idacc <> RP.idacc AND " +
			          " csa_importriepview.ayear = EY.ayear ) ";


			string sqlCmd = " SELECT ayear as 'Eserc.', " +
			                " idriep as 'Numero Riepilogo', " +
			                " yimport as 'Eserc. Import', " +
			                " nimport as 'Num. Import.', " +
			                " ruolocsa as 'Ruolo CSA', " +
			                " capitolocsa as 'Capitolo CSA', " +
			                " matricola as 'Matricola', " +
			                " importo as 'Importo', " +
			                " registry as 'Anagrafica', " +
			                " flagcr as 'Comp./Residui' " +
			                " FROM csa_importriepview " +
			                " WHERE  " + filter;

			DataTable T = Conn.SQLRunner(sqlCmd, false, 600);

			if (T != null) {

				VisualizzaDati(sender, e, T, "csa_importriep", "default",
					filter.Replace("csa_importriepview.", "csa_importriep."));
			}
		}

//--25)  Righe di riepilogo con preimpegno di budget avente UPB incoerente con quello della ripartizione nell''esercizio corrente
		private void btnEP24_Click(object sender, EventArgs e) {
			if (Meta.IsEmpty) return;

			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]),
				QHS.CmpEq("ayear", Conn.GetEsercizio()));


			//filter += " AND EXISTS (select * from csa_importriep_partition RP where " +
			//	  " R.idcsa_import = RP.idcsa_import AND " +
			//	  " R.idriep = RP.idriep AND" +
			//	  " RP.idepexp IS NOT NULL) ";
			filter += " AND EXISTS (select * from epexpyear EY " +
			          " JOIN csa_importriep_partition RP ON " +
			          " csa_importriepview.idcsa_import = RP.idcsa_import AND " +
			          " csa_importriepview.idriep = RP.idriep AND " +
			          " EY.idepexp = RP.idepexp AND " +
			          " EY.idupb <> RP.idupb AND " +
			          " csa_importriepview.ayear = EY.ayear ) ";


			string sqlCmd = " SELECT ayear as 'Eserc.', " +
			                " idriep as 'Numero Riepilogo', " +
			                " yimport as 'Eserc. Import', " +
			                " nimport as 'Num. Import.', " +
			                " ruolocsa as 'Ruolo CSA', " +
			                " capitolocsa as 'Capitolo CSA', " +
			                " matricola as 'Matricola', " +
			                " importo as 'Importo', " +
			                " registry as 'Anagrafica', " +
			                " flagcr as 'Comp./Residui' " +
			                " FROM csa_importriepview " +
			                " WHERE  " + filter;

			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {

				VisualizzaDati(sender, e, T, "csa_importriep", "default",
					filter.Replace("csa_importriepview.", "csa_importriep."));
			}
		}


		//26)  Righe di riepilogo con anagrafica valorizzata senza causale di Debto , Mandati nominativi
		private void btnEP25_Click(object sender, EventArgs e) {
			if (Meta.IsEmpty) return;

			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd( QHS.CmpEq("idcsa_import", Curr["idcsa_import"]), QHS.IsNotNull("idreg"));


			filter = QHS.AppAnd(filter, " (NOT EXISTS(select * from registry where registry.idreg =  csa_importriepview.idreg" +
										" AND registry.idaccmotivedebit is not null ) OR " +
										" NOT EXISTS(select * from registry where registry.idreg =  csa_importriepview.idreg" +
										" AND registry.idaccmotivecredit is not null ))");

			string sqlCmd = " SELECT ayear as 'Eserc.', " +
							" idriep as 'Numero Riepilogo', " +
							" yimport as 'Eserc. Import', " +
							" nimport as 'Num. Import.', " +
							" idreg as 'Codice Anagrafica', " +
							" registry as 'Anagrafica', " +
							" ruolocsa as 'Ruolo CSA', " +
							" capitolocsa as 'Capitolo CSA', " +
							" matricola as 'Matricola', " +
							" importo as 'Importo', " +
							" flagcr as 'Comp./Residui' " +
							" FROM csa_importriepview " +
							" WHERE " + filter + " order by matricola ";


			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati(sender, e, T, "csa_importriep", "default", filter);
			}
		}
			private void dgrVerifiche_DoubleClick(object sender, EventArgs e) {
			DataGrid dataGrid = (DataGrid) sender;
			DataRow RigheSelezionata = GetGridSelectedRows(dataGrid);
			string kind_of_errors = "FIN";
			if (dataGrid.Name == "dgrVerificheEP")
				kind_of_errors = "EP";

			if (RigheSelezionata == null)
				return;

			if (CfgFn.GetNoNullInt32(RigheSelezionata["errorcode"]) > 0)
				VisualizzaElenchi(kind_of_errors, CfgFn.GetNoNullInt32(RigheSelezionata["errorcode"]));
		}

		private void dgrSospesi_DoubleClick(object sender, EventArgs e) {
			DataGrid dataGrid = (DataGrid) sender;
			DataRow RigheSelezionata = GetGridSelectedRows(dataGrid);

			if (RigheSelezionata == null)
				return;
			VisualizzaRigaSelezionata(RigheSelezionata, "csa_bill", null, "default", "default");
		}

		private void VisualizzaRigaSelezionata(DataRow Riga, string table, string view, string listType,
			string editType) {
			if (Riga == null) return;
			string filter = QueryCreator.WHERE_KEY_CLAUSE(Riga, DataRowVersion.Default, true);
			if (editType == null) editType = "default";
			var MElenco = MetaData.GetMetaData(this, table);

			if (MElenco == null) return;

			bool result = MElenco.Edit(this, editType, false);
			DataRow R = MElenco.SelectOne(listType, filter, null, null);
			MElenco.SelectRow(R, listType);
		}



		private void btnVerificaIndividuazione_Click(object sender, EventArgs e) {
			VerificaIndividuazione(sender);
		}

		private void btn25_Click(object sender, EventArgs e) {
			//25) Movimenti padre con disponibile insufficiente
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			object esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
			string errMess;
			DataSet ds = Conn.CallSP("exp_csa_expense_available_partition",
				new object[] {Meta.GetSys("esercizio"), Curr["idcsa_import"]}, 600, out errMess);
			if (errMess != null) {
				show(this, "Errore nella chiamata della procedura di verifica: " + errMess, "Errore");
			}



			DataTable tResult = ds.Tables[0];
			if (tResult.Rows.Count != 0) {
				string filter = QHC.FieldIn("idexp", tResult.Select(), "idexp");
				string filterview = QHC.AppAnd(filter, QHC.CmpEq("ayear", esercizio));

				VisualizzaDati2(sender, e, tResult, "expense", "expenseview", "default",
					filter, filterview);
			}
		}

		private void btn65_Click(object sender, EventArgs e) {
			//65) Ripartizione unica non creata per ripartizioni di partenza errate
			if (Meta.IsEmpty) return;
			if (rdbExpToListing.Checked) {
				show("La modalità di verifica 'elenco' non è disponibile per questo controllo.", "Avviso");
				return;
			}

			DataRow Curr = DS.csa_import.Rows[0];
			object esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
			string errMess;
			String sp_name = "check_csa_partition_not_created";
			if (!usePartition)
				sp_name = "check_csa_partition_inconsistent";
			DataSet ds = Conn.CallSP(sp_name,
				new object[] {Meta.GetSys("esercizio")}, 600, out errMess);
			if (errMess != null) {
				show(this, "Errore nella chiamata della procedura di verifica: " + errMess, "Errore");
			}

			DataTable tResult = ds.Tables[0];
			if (tResult.Rows.Count != 0) {
				VisualizzaDati(sender, e, tResult, "csa_contract", "default", null);
			}
		}

		private void btn66_Click(object sender, EventArgs e) {
			//66) Riepiloghi, ripartizioni incoerenti
			if (Meta.IsEmpty) return;

			DataRow Curr = DS.csa_import.Rows[0];
			if (rdbExpToListing.Checked) {
				show("La modalità di verifica 'elenco' non è disponibile per questo controllo.", "Avviso");
				return;
			}

			string filter = QHS.CmpEq("idcsa_import", Curr["idcsa_import"]);
			object esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
			string errMess;
			string sp_name = "check_csa_partition_inconsistent_riep";
			DataSet ds = Conn.CallSP(sp_name,
				new object[] {Meta.GetSys("esercizio"), Curr["idcsa_import"]}, 600, out errMess);
			if (errMess != null) {
				show(this, "Errore nella chiamata della procedura di verifica: " + errMess, "Errore");
			}

			DataTable tResult = ds.Tables[0];
			if (tResult.Rows.Count != 0) {
				VisualizzaDati(sender, e, tResult, "csa_importriep", "default", null);
			}
		}

		private void btn67_Click(object sender, EventArgs e) {
			//67) Versamenti, ripartizioni incoerenti
			if (Meta.IsEmpty) return;

			DataRow Curr = DS.csa_import.Rows[0];

			string filter = QHS.CmpEq("idcsa_import", Curr["idcsa_import"]);
			object esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
			string errMess;

			string sp_name = "check_csa_partition_inconsistent_ver";
			DataSet ds = Conn.CallSP(sp_name,
				new object[] {Meta.GetSys("esercizio"), Curr["idcsa_import"]}, 600, out errMess);
			if (errMess != null) {
				show(this, "Errore nella chiamata della procedura di verifica: " + errMess, "Errore");
			}

			DataTable tResult = ds.Tables[0];
			if (tResult.Rows.Count != 0) {
				VisualizzaDati(sender, e, tResult, "csa_importver", "default", null);
			}
		}

		private void btn68_Click(object sender, EventArgs e) {
			//68) ANAGRAFICHE RIEPILOGHI PRIVE DI MODALITA' DI PAGAMENTO STANDARD
			// NON SERVE , IL NETTO A PAGARE DEVE ESSERE A REGOLARIZZAZIONE
			/*
			if (Meta.IsEmpty) return;

			DataRow Curr = DS.csa_import.Rows[0];

			string filter_import = QHS.CmpEq("idcsa_import", Curr["idcsa_import"]);
			string filter_modpag = "(SELECT count(*)  " +
			                                  " FROM registrypaymethod " +
			                                  " WHERE flagstandard = 'S' " +
			                                  " AND  idreg = registry.idreg) = 0  ";
			string filter = QHS.AppAnd(filter_import, filter_modpag);

			string filter_registry = "  idreg in (SELECT idreg " +
			                                 " FROM csa_importriep " +
			                                 " WHERE " + filter_import + ")";  

			string sqlCmd = " SELECT DISTINCT registry.idreg as '#idreg'," +
			                " registry.title as 'Denominazione', " +
			                " registry.cf as 'Codice Fiscale' " +
			                " FROM  registry " +
			                " JOIN csa_importriep  on registry.idreg = csa_importriep.idreg " +
			                " WHERE  " + filter;

			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
			    VisualizzaDati3(sender, e, T, "registry", "registrymainview", "anagrafica","anagrafica", QHS.AppAnd(filter_registry, filter_modpag), 
			                                                                         QHS.AppAnd(filter_registry, filter_modpag.Replace("registry.", "registrymainview.")));
			}
			*/

		}

		private void btn69_Click(object sender, EventArgs e) {
			//69) ANAGRAFICHE ENTI VERSAMENTO CSA PRIVE DI MODALITA' DI PAGAMENTO STANDARD
			if (Meta.IsEmpty) return;

			DataRow Curr = DS.csa_import.Rows[0];

			string filter_import = QHS.CmpEq("idcsa_import", Curr["idcsa_import"]);
			//string filter_agency = QHS.CmpEq("csa_importver.idcsa_agency", Curr["idcsa_agency"]);
			string filter_modpag = "(SELECT count(*)  " +
			                       " FROM registrypaymethod " +
			                       " WHERE flagstandard = 'S' " +
			                       " AND  idreg = registry.idreg) = 0  ";
			string filter = QHS.AppAnd(filter_import, filter_modpag);

			string filter_registry = "  idreg in (SELECT idreg_agency " +
			                         " FROM csa_importver " +
			                         " WHERE " + filter_import + ")" +
			                         "   AND (SELECT count(*) " +
			                         "   FROM csa_agency " +
			                         "   WHERE (ISNULL(csa_agency.flag,0) &2) <>0  " +
			                         "   AND csa_agency.idcsa_agency= csa_importver.idcsa_agency) <> 0 ";



			string sqlCmd = " SELECT DISTINCT registry.idreg as '#idreg'," +
			                " registry.title as 'Denominazione', " +
			                " registry.cf as 'Codice Fiscale' " +
			                " FROM  registry " +
			                " JOIN csa_importver  on registry.idreg = csa_importver.idreg_agency " +
			                " WHERE  " + filter;

			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati3(sender, e, T, "registry", "registrymainview", "anagrafica", "anagrafica",
					QHS.AppAnd(filter_registry, filter_modpag),
					QHS.AppAnd(filter_registry, filter_modpag.Replace("registry.", "registrymainview.")));
			}
		}

		private void btn70_Click(object sender, EventArgs e) {
			//70)  ANAGRAFICHE RIEPILOGHI INCOERENTI CON QUELLE DEI MOVIMENTI FINANZIARI DELLA RIPARTIZIONE -- SOLO NUOVA GESTIONE
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]),
				QHS.IsNotNull("csa_importriepview.idreg"));

			filter = QHS.AppAnd(filter,
				" (SELECT COUNT(csa_importriep_partition.idexp) FROM expense JOIN csa_importriep_partition ON expense.idexp = csa_importriep_partition.idexp " +
				" WHERE csa_importriep_partition.idcsa_import = csa_importriepview.idcsa_import " +
				" AND csa_importriep_partition.idriep = csa_importriepview.idriep " +
				" AND csa_importriep_partition.idexp IS NOT NULL AND expense.idreg IS NOT NULL  AND ISNULL(expense.idreg, 0) <> ISNULL(csa_importriepview.idreg, 0)) <> 0 ");

			string sqlCmd = " SELECT ayear as 'Eserc.', " +
			                " idriep as 'Numero Riepilogo', " +
			                " yimport as 'Eserc. Import', " +
			                " nimport as 'Num. Import.', " +
			                " ruolocsa as 'Ruolo CSA', " +
			                " capitolocsa as 'Capitolo CSA', " +
			                " matricola as 'Matricola', " +
			                " importo as 'Importo', " +
			                " registry as 'Anagrafica', " +
			                " flagcr as 'Comp./Residui' " +
			                " FROM csa_importriepview  " +
			                " WHERE  " + filter;

			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati2(sender, e, T, "csa_importriep", "csa_importriepview", "default",
					filter.Replace("csa_importriepview", "csa_importriep"), filter);
			}

		}


		private void btn71_Click(object sender, EventArgs e) {
			//71)  Regole specifiche ripartite con movimenti di spesa con anagrafica
			if (Meta.IsEmpty) return;

			if (rdbExpToListing.Checked) {
				show("La modalità di verifica 'elenco' non è disponibile per questo controllo.", "Avviso");
				return;
			}

			DataRow Curr = DS.csa_import.Rows[0];
			object esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
			string errMess;
			string filter = QHS.AppAnd(QHS.CmpEq("CP.ayear", Conn.GetSys("esercizio")), QHS.IsNotNull("CP.idexp"));
			filter += " AND EXISTS  (SELECT * FROM  expense  E WHERE " +
			          " E.idexp = CP.idexp AND " +
			          " E.idreg IS NOT NULL)  ";
			string sqlCmd =
				"SELECT C.idcsa_contract , C.ycontract as 'Eserc.Regola specifica CSA', C.ncontract as Numero " +
				" from csa_contract_partition CP " +
				" join csa_contract C on C.idcsa_contract=CP.idcsa_contract and CP.ayear=C.ayear " +
				" where " + filter;

			DataTable TT = Conn.SQLRunner(sqlCmd);
			if (TT == null) return;
			if (TT.Rows.Count == 0) return;


			// show(sqlCmd);
			string filtercontract = QHS.AppAnd(QHS.FieldIn("idcsa_contract", TT.Select()),
				QHS.CmpEq("ayear", Conn.GetSys("esercizio")));
			DataTable T = Conn.SQLRunner(sqlCmd);
			if (T != null) {
				VisualizzaDati(sender, e, T, "csa_contract", "default", filtercontract);
			}
		}

		private void btn72_Click(object sender, EventArgs e) {
			//72)  Contributi Regole specifiche ripartite con movimenti di spesa con anagrafica
			if (Meta.IsEmpty) return;

			if (rdbExpToListing.Checked) {
				show("La modalità di verifica 'elenco' non è disponibile per questo controllo.", "Avviso");
				return;
			}

			DataRow Curr = DS.csa_import.Rows[0];
			object esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
			string errMess;
			string filter = QHS.AppAnd(QHS.CmpEq("CTP.ayear", Conn.GetSys("esercizio")), QHS.IsNotNull("CTP.idexp"));
			filter += " AND EXISTS  (SELECT * FROM  expense  E WHERE " +
			          " E.idexp = CTP.idexp AND " +
			          " E.idreg IS NOT NULL)  ";
			string sqlCmd =
				"SELECT C.idcsa_contract , C.ycontract as 'Eserc.Regola specifica CSA', C.ncontract as Numero, CT.voceCSA as 'Voce CSA', CTP.ndetail as '# Dett.' " +
				" from csa_contracttax_partition CTP " +
				" join csa_contracttax CT on CTP.idcsa_contract=CT.idcsa_contract and  CTP.idcsa_contracttax=CT.idcsa_contracttax and CTP.ayear=CT.ayear " +
				" join csa_contract C on C.idcsa_contract=CT.idcsa_contract and CT.ayear=C.ayear " +
				" where " + filter;

			DataTable TT = Conn.SQLRunner(sqlCmd);
			if (TT == null) return;
			if (TT.Rows.Count == 0) return;


			// show(sqlCmd);
			string filtercontract = QHS.AppAnd(QHS.FieldIn("idcsa_contract", TT.Select()),
				QHS.CmpEq("CP.ayear", Conn.GetSys("esercizio")));
			DataTable T = Conn.SQLRunner(sqlCmd);
			if (T != null) {
				VisualizzaDati(sender, e, T, "csa_contracttax", "default", filtercontract);
			}
		}


		private void btn73_Click(object sender, EventArgs e) {
			//73)  Movimenti spesa con netto negativo nella fase versamenti
			if (Meta.IsEmpty) return;

			if (rdbExpToListing.Checked) {
				show("La modalità di verifica 'elenco' non è disponibile per questo controllo.", "Avviso");
				return;
			}

			DataRow Curr = DS.csa_import.Rows[0];
			object esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
			string errMess;
			string filter = QHS.CmpEq("idcsa_import", Curr["idcsa_import"]);
			string sqlCmd =
				" SELECT sum(importo) as 'Importo Netto', idreg_agency as '#idreg Anagr. Ente', registry_agency as 'Anagr. Ente' FROM csa_importverview " +
				" WHERE " + filter +
				" GROUP BY idreg_agency,registry_agency HAVING sum(importo)<0 ";

			DataTable TT = Conn.SQLRunner(sqlCmd);
			if (TT == null) return;
			if (TT.Rows.Count == 0) return;

			DataTable T = Conn.SQLRunner(sqlCmd);
			if (T != null) {
				VisualizzaDati(sender, e, T, "csa_importver", "default", filter);
			}
		}


		private void btn74_Click(object sender, EventArgs e) {
			//74)    Ritenuta con capitolo  costo o movimento spesa costo valorizzato 
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]),
				QHS.IsNull("idcsa_contractkinddata"), QHS.IsNull("idcsa_contracttax"),
				QHS.NullOrEq("flagclawback", "N"), QHS.IsNotNull("idfin_income"),
				QHS.DoPar(QHS.AppOr(QHS.IsNotNull("idfin_cost"), QHS.IsNotNull("idexp_cost"))));



			string sqlCmd =
				" SELECT CASE flagclawback WHEN 'S' THEN 'Recupero' ELSE 'Ritenuta/Contributo' END as 'Tipo'," +
				" ayear as 'Eserc.', " +
				" idver as 'Numero Versamento', " +
				" yimport as 'Eserc. Import', " +
				" nimport as 'Num. Import.', " +
				" ruolocsa as 'Ruolo CSA', " +
				" capitolocsa as 'Capitolo CSA', " +
				" ente as 'Ente CSA', " +
				" vocecsa as 'Voce CSA', " +
				" matricola as 'Matricola', " +
				" importo as 'Importo', " +
				" registry as 'Anagrafica', " +
				" agency as 'Ente', " +
				" idcsa_agencypaymethod as ' # Mod. Pagamento Ente', " +
				" codefin_cost as 'Cod. Capitolo Costo'," +
				" codefin_income as 'Cod. Capitolo Entrata'," +
				" codefin_expense as 'Cod. Capitolo Spesa'," +
				" codefin_incomeclawback as 'Cod. Capitolo Entrata Interno'," +
				" flagcr as 'Comp./Residui' " +
				" FROM csa_importverview " +
				" WHERE  " + filter;


			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati2(sender, e, T, "csa_importver", "csa_importverview", "default",
					filter, filter);
			}
		}


		private void btn75_Click(object sender, EventArgs e) {
			// 75) Ripartizione Ritenuta con capitolo di costo valorizzato
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]),
				QHS.IsNull("idcsa_contractkinddata"), QHS.IsNull("idcsa_contracttax"),
				QHS.NullOrEq("flagclawback", "N"), QHS.IsNotNull("idfin_income"));

			filter = QHS.AppAnd(filter,
				" EXISTS(SELECT * FROM csa_importver_partition CE where csa_importverview.idcsa_import = CE.idcsa_import and csa_importverview.idver = CE.idver  " +
				" AND (CE.idfin IS NOT NULL or CE.idexp IS NOT NULL)) ");

			string sqlCmd =
				" SELECT CASE flagclawback WHEN 'S' THEN 'Recupero' ELSE 'Ritenuta/Contributo' END as 'Tipo'," +
				" ayear as 'Eserc.', " +
				" idver as 'Numero Versamento', " +
				" yimport as 'Eserc. Import', " +
				" nimport as 'Num. Import.', " +
				" ruolocsa as 'Ruolo CSA', " +
				" capitolocsa as 'Capitolo CSA', " +
				" ente as 'Ente CSA', " +
				" vocecsa as 'Voce CSA', " +
				" matricola as 'Matricola', " +
				" importo as 'Importo', " +
				" registry as 'Anagrafica', " +
				" agency as 'Ente', " +
				" idcsa_agencypaymethod as ' # Mod. Pagamento Ente', " +
				" codefin_cost as 'Cod. Capitolo Costo'," +
				" codefin_income as 'Cod. Capitolo Entrata'," +
				" codefin_expense as 'Cod. Capitolo Spesa'," +
				" codefin_incomeclawback as 'Cod. Capitolo Entrata Interno'," +
				" flagcr as 'Comp./Residui' " +
				" FROM csa_importverview " +
				" WHERE  " + filter;


			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati2(sender, e, T, "csa_importver", "csa_importverview", "default",
					filter, filter);
			}
		}

		private void btn76_Click(object sender, EventArgs e) {
			//76) Contributi con importo negativo senza capitolo di entrata o classificazione Siope entrata configurati
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]),
				QHS.NullOrEq("flagclawback", "N"), QHS.DoPar(QHS.AppOr(
					QHS.IsNotNull("idcsa_contractkinddata"), QHS.IsNotNull("idcsa_contracttax"))),
				QHS.CmpLt("importo", 0), QHS.DoPar(QHS.AppOr(
					QHS.IsNull("idfin_incomeclawback"), QHS.IsNull("idsor_siope_incomeclawback"))));
			string sqlCmd = " SELECT 'Contributo' as 'Tipo'," +
			                " ayear as 'Eserc.', " +
			                " idver as 'Numero Versamento', " +
			                " yimport as 'Eserc. Import', " +
			                " nimport as 'Num. Import.', " +
			                " ruolocsa as 'Ruolo CSA', " +
			                " capitolocsa as 'Capitolo CSA', " +
			                " ente as 'Ente CSA', " +
			                " vocecsa as 'Voce CSA', " +
			                " matricola as 'Matricola', " +
			                " importo as 'Importo', " +
			                " registry as 'Anagrafica', " +
			                " agency as 'Ente', " +
			                " idcsa_agencypaymethod as ' # Mod. Pagamento Ente', " +
			                " codefin_cost as 'Cod. Capitolo Costo'," +
			                " codefin_expense as 'Cod. Capitolo Spesa'," +
			                " codefin_incomeclawback as 'Cod. Capitolo Entrata Contr. Negativi'," +
			                " sortcode_incomeclawback as 'Siope Entrata Contr. Negativi'," +
			                " flagcr as 'Comp./Residui' " +
			                " FROM csa_importverview " +
			                " WHERE  " + filter;


			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati(sender, e, T, "csa_importver", "default", filter);
			}
		}

		private void btn26_Click(object sender, EventArgs e) {
			//26) Coppie Bilancio - UPB con previsione disponibile insufficiente 
			if (Meta.IsEmpty) return;

			if (rdbExpToListing.Checked) {
				show("La modalità di verifica 'elenco' non è disponibile per questo controllo.", "Avviso");
				return;
			}

			DataRow Curr = DS.csa_import.Rows[0];
			object esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
			string errMess;
			DataSet ds = Conn.CallSP("exp_csa_fin_upb_available",
				new object[] {Meta.GetSys("esercizio"), Curr["idcsa_import"]}, 600, out errMess);
			if (errMess != null) {
				show(this, "Errore nella chiamata della procedura di verifica: " + errMess, "Errore");
			}

			DataTable tResult = ds.Tables[0];
			if (tResult.Rows.Count != 0) {


				VisualizzaDati2(sender, e, tResult, "finview", "finview", "relation",
					null, null);
			}

		}

		private void btn27_Click(object sender, EventArgs e) {
			// 27) Voce di Bilancio e Movimento finanziario non determinati in righe riepiloghi
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.csa_import.Rows[0];
			string filter = QHS.AppAnd(QHS.CmpEq("idcsa_import", Curr["idcsa_import"]),
				QHS.IsNotNull("idcsa_contractkind"), QHS.IsNull("idfin"), QHS.IsNull("idexp"));
			string sqlCmd = " SELECT ayear as 'Eserc.', " +
			                " idriep as 'Numero Riepilogo', " +
			                " yimport as 'Eserc. Import', " +
			                " nimport as 'Num. Import.', " +
			                " ruolocsa as 'Ruolo CSA', " +
			                " capitolocsa as 'Capitolo CSA', " +
			                " matricola as 'Matricola', " +
			                " importo as 'Importo', " +
			                " registry as 'Anagrafica', " +
			                " flagcr as 'Comp./Residui' " +
			                " FROM csa_importriepview " +
			                " WHERE  " + filter +
			                " AND NOT EXISTS(SELECT * FROM csa_contractexpense C where C.ayear=csa_importriepview.ayear " +
			                " and C.idcsa_contract = csa_importriepview.idcsa_contract)";


			DataTable T = Conn.SQLRunner(sqlCmd, false, 60);

			if (T != null) {
				VisualizzaDati(sender, e, T, "csa_importriep", "default", filter);
			}
		}

		private void dataGrid2_Navigate(object sender, NavigateEventArgs ne) {

		}

		private void btnVerificaIndividuazioneEP_Click(object sender, EventArgs e) {

		}

		private void button1_Click(object sender, EventArgs e) {
			btnEP15_Click(sender, e);
		}

		private void btnShowOutput_Click(object sender, EventArgs e) {
			TS.ShowErrors();
		}

		private void btnBolletta_Click(object sender, EventArgs e) {
			if (Meta.IsEmpty) return;
			DataRow curr = DS.csa_import.Rows[0];
			MetaData.GetFormData(this, true);

			string filter = QHS.CmpEq("ybill", Meta.GetSys("esercizio"));
			filter = QHS.AppAnd(filter, QHS.CmpEq("billkind", "D"), QHS.CmpGt("toregularize", 0));

			string VistaScelta = "billview";

			MetaData meta_bill = Meta.Dispatcher.Get(VistaScelta);
			meta_bill.FilterLocked = true;
			meta_bill.DS = DS;
			DataRow myDr = meta_bill.SelectOne("default", filter, null, null);

			if (myDr != null) {
				curr["ybill_netti"] = myDr["ybill"];
				curr["nbill_netti"] = myDr["nbill"];
				DS.bill_netti.Clear();
				Meta.Conn.RUN_SELECT_INTO_TABLE(DS.bill_netti, null,
					QHS.AppAnd(QHS.CmpEq("ybill", myDr["ybill"]),
						QHS.CmpEq("nbill", myDr["nbill"]),
						QHS.CmpEq("billkind", "D")),
					null, true);
				//txtEsercBollettaNetti.Text= myDr["ybill"].ToString();
				//txtNumBollettaNetti.Text = myDr["nbill"].ToString();

				Meta.FreshForm();
			}
		}

		private void btnBollettaVersamenti_Click(object sender, EventArgs e) {
			if (Meta.IsEmpty) return;
			DataRow curr = DS.csa_import.Rows[0];
			MetaData.GetFormData(this, true);
			string filteresercizio = QHS.CmpEq("ybill", Meta.GetSys("esercizio"));
			int annosuccessivo = Convert.ToInt32(Meta.GetSys("esercizio")) + 1;
			string filteresercizionew = QHS.CmpEq("ybill", annosuccessivo);

			string filter = (QHS.DoPar(QHS.AppOr(filteresercizio, filteresercizionew)));

			filter = QHS.AppAnd(filter, QHS.CmpEq("billkind", "D"), QHS.CmpGt("toregularize", 0));

			string VistaScelta = "billview";

			MetaData meta_bill = Meta.Dispatcher.Get(VistaScelta);
			meta_bill.FilterLocked = true;
			meta_bill.DS = DS;
			DataRow myDr = meta_bill.SelectOne("default", filter, null, null);
			if (myDr != null) {
				curr["ybill_versamenti"] = myDr["ybill"];
				curr["nbill_versamenti"] = myDr["nbill"];
				DS.bill_netti.Clear();
				Meta.Conn.RUN_SELECT_INTO_TABLE(DS.bill_netti, null,
					QHS.AppAnd(QHS.CmpEq("ybill", myDr["ybill"]),
						QHS.CmpEq("nbill", myDr["nbill"]),
						QHS.CmpEq("billkind", "D")),
					null, true);
				//txtEsercBollettaVersamenti.Text = myDr["ybill"].ToString();
				//txtNumBollettaVersamenti.Text = myDr["nbill"].ToString();

				Meta.FreshForm();
			}
		}

		#region importazione bollette

		private void ImpostaColonneTracciatoDettagli(DataTable mData) {
			mData.Columns.Clear();
			mData.Columns.Add("codice_anagrafica", typeof(int));
			mData.Columns.Add("n_sospeso", typeof(int));
			mData.Columns.Add("importo", typeof(decimal));
		}

		//private bool verificaValiditaCampiExcel(DataTable mData) {


		//    bool ok = true;
		//    DataSet Out = new DataSet();
		//    DataTable T = new DataTable();
		//    T.Columns.Add("errors", typeof(System.String), "");
		//    for (int i = 0; i < tracciato_sospeso.Length; i++) {
		//        string fmt = tracciato_sospeso[i];
		//        bool datiValidi = GetField(fmt, T, mData);
		//        if (!datiValidi) ok = false;
		//    }

		//    Out.Tables.Add(T);

		//    if (!ok) {
		//        FrmViewError View = new FrmViewError(Out);
		//        View.Show();
		//    }

		//    return ok;
		//}

		public string GetTracciato(string[] tracciato) {
			string res = "";
			int pos = 0;
			foreach (string t in tracciato) {
				string[] ss = t.Split(';');
				string field = ss[0].PadLeft(30) + ": Pos." + pos.ToString().PadLeft(5) + " lunghezza " +
				               ss[3].PadLeft(4) +
				               " Tipo: " + ss[2].PadLeft(15);
				if (ss[2].ToLower() == "codificato") {
					field += " Codifica:" + ss[4];
				}

				field += " Descrizione: " + ss[1];
				field += "\r\n";
				pos += CfgFn.GetNoNullInt32(ss[3]);
				res += field;
			}

			return res;
		}

		public DataTable GetTableTracciato(string[] tracciato) {
			int pos = 0;
			DataTable T = new DataTable("t");
			T.Columns.Add("nome", typeof(string));
			T.Columns.Add("posizione", typeof(int));
			T.Columns.Add("lunghezza", typeof(string));
			T.Columns.Add("tipo", typeof(string));
			T.Columns.Add("codifica", typeof(string));
			T.Columns.Add("Descrizione", typeof(string));

			foreach (string t in tracciato) {
				DataRow r = T.NewRow();
				string[] ss = t.Split(';');
				r["nome"] = ss[0];
				r["posizione"] = pos;
				r["lunghezza"] = CfgFn.GetNoNullInt32(ss[3]);
				r["tipo"] = ss[2];
				if (ss.Length == 5) r["codifica"] = ss[4];
				r["Descrizione"] = ss[1];
				pos += CfgFn.GetNoNullInt32(ss[3]);

				T.Rows.Add(r);
			}

			return T;
		}



		DataTable callSpAccountUpbPrevision(DataAccess Conn, List<object[]> idAccIdupbList) {
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("DECLARE @lista_idacc_idupb AS account_upb_list;");
			//int currblockLen = 0;
			foreach (object[] id in idAccIdupbList) {
				sb.Append(
					$"insert into @lista_idacc_idupb values ({QHS.quote(id[0])},{QHS.quote(id[1])},{QHS.quote(CfgFn.GetNoNullDecimal(id[2]))})");
			}

			//if (currblockLen > 0)
			sb.AppendLine(";");
			sb.AppendLine($"exec  compute_account_upb_prevision {Conn.GetEsercizio()},@lista_idacc_idupb");
			return Conn.SQLRunner(sb.ToString());
		}

		DataTable callSpEpexpAvailable(DataAccess Conn, List<object[]> epexp_list) {
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("DECLARE @lista_idepexp AS epexp_list;");
			//int currblockLen = 0;
			foreach (object[] id in epexp_list) {
				sb.Append($"insert into @lista_idepexp values ({QHS.quote(id[0])},{QHS.quote(id[1])})");
				sb.AppendLine(";");
			}

			sb.AppendLine($"exec  compute_epexp_available {Conn.GetEsercizio()},@lista_idepexp");
			return Conn.SQLRunner(sb.ToString());
		}

		DataTable callSpEpaccAvailable(DataAccess Conn, List<object[]> epacc_list) {
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("DECLARE @lista_idepacc AS epacc_list;");
			foreach (object[] id in epacc_list) {
				sb.Append($"insert into @lista_idepacc values ({QHS.quote(id[0])},{QHS.quote(id[1])})");
				sb.AppendLine(";");
			}

			sb.AppendLine($"exec  compute_epacc_available {Conn.GetEsercizio()},@lista_idepacc");
			return Conn.SQLRunner(sb.ToString());
		}


		public DataTable GetTableAccountUpb() {
			// Legge da Db la disponibilità attuale delle coppie idacc idupb movimentate nella creazione di nuovi PreImpegni o Preaccertamenti
			// al fine di verificare che, nell'eseguire relamente la generazione, non vadano in negativo
			List<object[]> param = new List<object[]>();
			if (AccountUpb_Pre.Count == 0) return null;
			DataTable T = new DataTable();

			foreach (string key in AccountUpb_Pre.Keys) {
				string[] ss = key.Split('§');
				param.Add(new object[] {ss[0], ss[1], AccountUpb_Pre[key]});
			}

			T = callSpAccountUpbPrevision(Conn, (from r in param select r).ToList());
			if (T == null || !T.Columns.Contains("Upb")) {
				return null;
			}

			return T;
		}

		public DataTable GetDataPreEpexp() {
			// Legge da Db la disponibilità attuale di PreImpegni già memorizzati sul db
			List<object[]> param = new List<object[]>();
			if (Pre_Epexp_Existing_Childs.Count == 0) return null;
			foreach (string key in Pre_Epexp_Existing_Childs.Keys) {
				string[] ss = key.Split('§');
				int idepexp = CfgFn.GetNoNullInt32(ss[0]);
				param.Add(new object[] {idepexp, Pre_Epexp_Existing_Childs[key]});
			}

			DataTable T = callSpEpexpAvailable(Conn, (from r in param select r).ToList());
			if (T == null || !T.Columns.Contains("Upb")) {
				return null;
			}

			return T;
		}

		public DataTable GetDataPreEpacc() {
			// Legge da Db la disponibilità attuale di PreAccertamenti già memorizzati sul db
			List<object[]> param = new List<object[]>();
			if (Pre_Epacc_Existing_Childs.Count == 0) return null;
			foreach (string key in Pre_Epacc_Existing_Childs.Keys) {
				string[] ss = key.Split('§');
				int idepacc = CfgFn.GetNoNullInt32(ss[0]);
				param.Add(new object[] {idepacc, Pre_Epacc_Existing_Childs[key]});
			}

			DataTable T = callSpEpaccAvailable(Conn, (from r in param select r).ToList());
			if (T == null || !T.Columns.Contains("Upb")) {
				return null;
			}

			return T;
		}

		//public DataTable GetAvailablePreEpexp() {
		//	// Calcola disponibilità di PreImpegni che si stanno creando, sottraendo gli impegni figli
		//	List<object[]> param = new List<object[]>();
		//	foreach (string key in Pre_Epexp_Existing_Childs.Keys) {
		//		string[] ss = key.Split('§');
		//		int idepexp = CfgFn.GetNoNullInt32(ss[0]);
		//		param.Add(new object[] { idepexp, Pre_Epexp_Existing_Childs[key] });
		//	}
		//	DataTable T =  callSpEpexpAvailable(Conn,(from r in param select r).ToList());
		//	if (T == null || !T.Columns.Contains("available")) {
		//		return null;
		//	}
		//	return T;
		//}

		//public DataTable GetAvailablePreEpacc() {
		//	// Calcola disponibilità di PreAccertamenti che si stanno creando, sottraendo gli accertamenti figli
		//	List<object[]> param = new List<object[]>();
		//	foreach (string key in Pre_Epacc_Existing_Childs.Keys) {
		//		string[] ss = key.Split('§');
		//		int idepacc = CfgFn.GetNoNullInt32(ss[0]);
		//		param.Add(new object[] { idepacc, Pre_Epacc_Existing_Childs[key] });
		//	}
		//	DataTable T =  callSpEpaccAvailable(Conn,(from r in param select r).ToList());
		//	if (T == null || !T.Columns.Contains("available")) {
		//		return null;
		//	}
		//	return T;
		//}


		private void MenuEnterPwd_Click(object sender, EventArgs e) {
			if (sender == null) return;
			if (!(typeof(MenuItem).IsAssignableFrom(sender.GetType()))) return;
			object mysender = ((MenuItem) sender).Parent.GetContextMenu().SourceControl;
			string tracciato = "";
			DataTable TableTracciato = null;

			tracciato = GetTracciato(tracciato_sospeso);
			TableTracciato = GetTableTracciato(tracciato_sospeso);
			FrmShowTracciato FT = new FrmShowTracciato(tracciato, TableTracciato, "struttura");
            createForm(FT, null);
            FT.ShowDialog();
		}



		#endregion

		Dictionary<string, decimal> AccountUpb_Pre = new Dictionary<string, decimal>();
		Dictionary<string, decimal> Pre_Epexp_Childs = new Dictionary<string, decimal>();
		Dictionary<string, decimal> Pre_Epexp_Existing_Childs = new Dictionary<string, decimal>();
		Dictionary<string, DataRow> Pre_Epexp_New = new Dictionary<string, DataRow>();
		Dictionary<string, DataRow> Pre_Epacc_New = new Dictionary<string, DataRow>();
		Dictionary<string, DataRow> Epexp = new Dictionary<string, DataRow>();
		Dictionary<string, decimal> Pre_Epacc_Childs = new Dictionary<string, decimal>();
		Dictionary<string, decimal> Pre_Epacc_Existing_Childs = new Dictionary<string, decimal>();
		Dictionary<string, DataRow> Epacc = new Dictionary<string, DataRow>();

		private void ClearSimulaEpGenera() {
			AccountUpb_Pre.Clear();
			Pre_Epexp_Childs.Clear();
			Pre_Epexp_Existing_Childs.Clear();
			Pre_Epexp_New.Clear();
			Pre_Epacc_New.Clear();
			Epexp.Clear();
			Pre_Epacc_Childs.Clear();
			Pre_Epacc_Existing_Childs.Clear();
			Epacc.Clear();
		}

		private void btnSimulaEPGenera_Click(object sender, EventArgs e) {
			ClearSimulaEpGenera();
			var epManager = new EP_Manager(Meta, null, null, null, null, null, null, null, null, "csa_import");

			var fakePosting = new Fake_EpPoster(epManager);

			var res = fakePosting.DO_POST_SERVICE();

			//PostData post = Meta.Get_PostData();
			//DataSet d = new DataSet();
			//var res1 = fakePosting.saveData(d,post);
			DataSet toAnalyze = fakePosting.getDataSet();
			bool message = false;
			string keyRow;
			if (toAnalyze == null) {
				show("Non ci sono dati da mostrare");
				return;
			}

			if (toAnalyze.Tables.Contains("epexp")) {
				DataTable tEpexp = toAnalyze.Tables["epexp"];
				int minTemp = tEpexp.getMinimumTempValue("idepexp");
				foreach (DataRow rEpexp in tEpexp.Rows) {
					if ((CfgFn.GetNoNullInt32(rEpexp["nphase"]) == 1)) {
						keyRow = getHash(rEpexp, new[] {"idepexp"});

						if (CfgFn.GetNoNullInt32(rEpexp["idepexp"]) > minTemp)
							// riga di nuova creazione
							if ((Pre_Epexp_Childs != null) && (Pre_Epexp_Childs.ContainsKey(keyRow)))
								continue;
							else {
								Pre_Epexp_Childs[keyRow] = 0;
								// andrò poi a inserire le righe con gli importi da epexpyear
							}
					}
					else { // nphase = 2
						if (CfgFn.GetNoNullInt32(rEpexp["idepexp"]) > minTemp) {
							// riga di nuova creazione
							keyRow = getHash(rEpexp, new[] {"idepexp"});
							Epexp[keyRow] = rEpexp;
						}

						if (CfgFn.GetNoNullInt32(rEpexp["paridepexp"]) < minTemp) {
							// pre-impegni esistenti, valorizzo solo le chiavi
							keyRow = getHash(rEpexp, new[] {"paridepexp"});
							if ((Pre_Epexp_Existing_Childs != null) && (Pre_Epexp_Existing_Childs.ContainsKey(keyRow)))
								continue;
							else {
								Pre_Epexp_Existing_Childs[keyRow] = 0;
								// andrò poi a inserire le righe dei figli  con gli importi da epexpyear
							}
						}
					}
				}
			}

			if (toAnalyze.Tables.Contains("epacc")) {
				DataTable tEpacc = toAnalyze.Tables["epacc"];
				int minTemp1 = tEpacc.getMinimumTempValue("idepacc");
				foreach (DataRow rEpacc in tEpacc.Rows) {
					if ((CfgFn.GetNoNullInt32(rEpacc["nphase"]) == 1)) {
						keyRow = getHash(rEpacc, new[] {"idepacc"});
						if (CfgFn.GetNoNullInt32(rEpacc["idepacc"]) > minTemp1)
							// riga di preaccertamento di nuova creazione, valorizzo solo le chiavi
							if ((Pre_Epacc_Childs != null) && (Pre_Epacc_Childs.ContainsKey(keyRow)))
								continue;
							else {
								Pre_Epacc_Childs[keyRow] = 0;
								// andrò poi a inserire le righe con gli importi da epaccyear
							}

					}
					else { // nphase = 2
						if (CfgFn.GetNoNullInt32(rEpacc["idepacc"]) > minTemp1) {
							// riga di nuova creazione
							keyRow = getHash(rEpacc, new[] {"idepacc"});
							Epacc[keyRow] = rEpacc;
						}

						if (CfgFn.GetNoNullInt32(rEpacc["paridepacc"]) < minTemp1) {
							//pre-accertamenti esistenti, valorizzo solo le chiavi
							keyRow = getHash(rEpacc, new[] {"paridepacc"});
							if ((Pre_Epacc_Existing_Childs != null) && (Pre_Epacc_Existing_Childs.ContainsKey(keyRow)))
								continue;
							else {
								Pre_Epacc_Existing_Childs[keyRow] = 0;
								// andrò poi a inserire le righe dei figli con gli importi da epaccyear
							}
						}

					}
				}
			}



			if (toAnalyze.Tables.Contains("epexpyear")) {
				//raggruppamenti su conto, upb, 
				// il dictionary AccountUpb_Pre associa alla chiave idacc idupb una lista dei preimpegni di nuova creazione ad essa imputati ai fini del calcolo 
				// della previsione disponibile post salvataggio
				foreach (DataRow rEpexpYear in toAnalyze.Tables["epexpyear"].Rows) {
					if (rEpexpYear.RowState != DataRowState.Added)
						continue; // Considero solo le righe di nuova creazione ai fini del calcolo della disponibilità
					string keyRowMov = getHash(rEpexpYear, new[] {"idepexp"});
					// Considero solo le righe di prima fase , le seconde fasi non interessano 
					if (!Pre_Epexp_Childs.ContainsKey(keyRowMov)) continue;

					// Memorizzo il preimpegno di nuova creazione nel relativo Dictionary
					if (!Pre_Epexp_New.ContainsKey(keyRowMov)) Pre_Epexp_New[keyRowMov] = rEpexpYear;

					//Aggiungo l'importo del preimpegno di nuova creazione al dictionary AccountUpb_Pre, in corrispondenza della chiave idacc idupb
					keyRow = getHash(rEpexpYear, new[] {"idacc", "idupb"});
					if ((AccountUpb_Pre != null) && (AccountUpb_Pre.ContainsKey(keyRow)))
						AccountUpb_Pre[keyRow] += CfgFn.GetNoNullDecimal(rEpexpYear["amount"]);
					else {
						AccountUpb_Pre[keyRow] = 0;
						AccountUpb_Pre[keyRow] += CfgFn.GetNoNullDecimal(rEpexpYear["amount"]);
					}
				}

				// Il seguente ciclo consente di riempire i dictionary  Pre_Epexp_Childs e Pre_Epexp_Existing_Childs (già valorizzati prima con le chiavi dei preimpegni)
				// associando a ogni chiave idepexp, l'importo totale degli impegni figli che saranno generati. I Dictionary sono due: 
				// 1) Pre_Epexp_Childs ha come chiave un preimpegno che si sta generando ora
				// 2) Pre_Epexp_Existing_Childs ha come chiave un preimpegno già memorizzato su db (presente in configurazione ecc.)
				foreach (DataRow rEpexpYear in toAnalyze.Tables["epexpyear"].Rows) {
					// Considero solo gli impegni di nuova creazione ai fini del calcolo della disponibilità del relativo preimpegno
					if (rEpexpYear.RowState != DataRowState.Added) continue;
					string keyRowMov = getHash(rEpexpYear, new[] {"idepexp"});
					if (!Epexp.ContainsKey(keyRowMov)) continue; // Non è di seconda fase, non interessa 
					DataRow REpexp = Epexp[keyRowMov];
					string keyRowPreMov = getHash(REpexp, new[] {"paridepexp"});
					// Se la riga impegno è figlia di un preimpegno di nuova creazione, ne aggiungo l'importo al relativo dictionary
					if (Pre_Epexp_Childs.ContainsKey(keyRowPreMov))
						Pre_Epexp_Childs[keyRowPreMov] += CfgFn.GetNoNullDecimal(rEpexpYear["amount"]);
					// Se la riga impegno è figlia di un preimpegno preesistente, ne aggiungo l'importo al relativo  dictionary
					if (Pre_Epexp_Existing_Childs.ContainsKey(keyRowPreMov))
						Pre_Epexp_Existing_Childs[keyRowPreMov] += CfgFn.GetNoNullDecimal(rEpexpYear["amount"]);

				}
			}

			if (toAnalyze.Tables.Contains("epaccyear")) {
				//raggruppamenti su conto, upb, 
				// il dictionary AccountUpb_Pre associa alla chiave idacc idupb una lista dei preaccertamenti di nuova creazione ad essa imputati ai fini del calcolo 
				// della previsione disponibile post salvataggio
				foreach (DataRow rEpaccYear in toAnalyze.Tables["epaccyear"].Rows) {
					// Considero solo le righe di prima fase e nuova creazione ai fini del calcolo della disponibilità
					if (rEpaccYear.RowState != DataRowState.Added) continue;
					string keyRowMov = getHash(rEpaccYear, new[] {"idepacc"});
					// Se non è un preaccertamento lo salto, si tratta di un accertamento
					if (!Pre_Epacc_Childs.ContainsKey(keyRowMov)) continue;

					// Memorizzo i preaccertamenti di nuova creazione nel relativo Dictionary
					if (!Pre_Epacc_New.ContainsKey(keyRowMov)) Pre_Epacc_New[keyRowMov] = rEpaccYear;

					//Aggiungo l'importo del preaccertamento di nuova creazione al dictionary AccountUpb_Pre, in corrispondenza della chiave idacc idupb
					keyRow = getHash(rEpaccYear, new[] {"idacc", "idupb"});
					if ((AccountUpb_Pre != null) && (AccountUpb_Pre.ContainsKey(keyRow)))
						AccountUpb_Pre[keyRow] += CfgFn.GetNoNullDecimal(rEpaccYear["amount"]);
					else {
						AccountUpb_Pre[keyRow] = 0;
						AccountUpb_Pre[keyRow] += CfgFn.GetNoNullDecimal(rEpaccYear["amount"]);
					}
				}

				// il seguente ciclo consente di riempire i dictionary  Pre_Epacc_Childs e Pre_Epacc_Existing_Childs (già valorizzati prima con le chiavi dei preaccertamenti)
				// associando a ogni chiave, importo totale  degli accertamenti figli che saranno generati 
				foreach (DataRow rEpaccYear in toAnalyze.Tables["epaccyear"].Rows) {
					if (rEpaccYear.RowState != DataRowState.Added)
						continue; // Considero solo le righe di nuova creazione ai fini del calcolo della disponibilità
					string keyRowMov = getHash(rEpaccYear, new[] {"idepacc"});
					// Considero solo le righe di seconda fase  di nuova creazione,
					if (!Epacc.ContainsKey(keyRowMov)) continue;
					DataRow REpacc = Epacc[keyRowMov];
					string keyRowPreMov = getHash(REpacc, new[] {"paridepacc"});
					// Se la riga accertamento è figlia di un preaccertamento di nuova creazione, aggiungo l'importo al relativo dictionary
					if (Pre_Epacc_Childs.ContainsKey(keyRowPreMov))
						Pre_Epacc_Childs[keyRowPreMov] += CfgFn.GetNoNullDecimal(rEpaccYear["amount"]);
					// Se la riga accertamento è figlia di un preaccertamento esistente, aggiungo l'importo  al relativo dictionary
					if (Pre_Epacc_Existing_Childs.ContainsKey(keyRowPreMov))
						Pre_Epacc_Existing_Childs[keyRowPreMov] += CfgFn.GetNoNullDecimal(rEpaccYear["amount"]);
				}
			}

			// Recuperare le informazioni da DB relativamente alle coppie Conto UPB movimentate, Preimpegni e Preaccertamenti
			DataTable T = GetDataPreEpacc();
			if (T != null) exportclass.DataTableToExcel(T, true);
			DataTable T1 = GetDataPreEpexp();
			if (T1 != null) exportclass.DataTableToExcel(T1, true);
			DataTable T2 = GetTableAccountUpb();
			if (T2 != null) exportclass.DataTableToExcel(T2, true);
			if ((T == null) && (T1 == null) && (T2 == null)) message = true;
			if (message)
				show("Non ci sono dati da mostrare. Controllare l'eventuale presenza di errori bloccanti");
			//visualizzazione


		}

        private void btnImportEmisti_Click(object sender, EventArgs e) {

			if (Meta.IsEmpty) return;
			if (Meta.InsertMode) return;

			using (var input = new OpenFileDialog()) {

				DialogResult result = input.ShowDialog();

				if (!(result == DialogResult.OK) || string.IsNullOrWhiteSpace(input.FileName))
					return;

				txtInputFile.Text = input.FileName;
			}

            dsmeta emistiDS = new dsmeta();

			foreach (var table in emistiDS.Tables) {
				RowChange.SetOptimized((DataTable)table, true);
			}

			List<ParseError> errs = new List<ParseError>(EmistiImporter.Load(Conn, txtInputFile.Text, emistiDS, textBox2.Text));

			if (errs.Count > 0) {
				var frmErrors = new FrmViewEmistiErrors(errs);
				frmErrors.Show();
				return;
            }

            var postData = new Easy_PostData_NoBL();
            postData.initClass(emistiDS, Conn);

            ProcedureMessageCollection errors = postData.DO_POST_SERVICE();
            IEnumerable<string> messages = errors.ToArray().Cast<ProcedureMessage>().Select(pm => pm.LongMess);

            if (messages.Any()) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(string.Format("Errori durante il salvataggio dei dati Emisti, ritentare l'importazione: \r\n\r\n{0}", string.Join("\r\n\r\n", messages)));
                return;
            }

			int emistiImportKey = emistiDS.emisti_import[0].idemisti_import;
			Conn.RUN_SELECT_INTO_TABLE(DS.emisti_import, "idemisti_import desc", QHS.CmpEq("idemisti_import", emistiImportKey), "1", false);
			if (emistiDS.emisti_import.Rows.Count > 0) {

				DS.emisti_import.AsEnumerable()
					.Where(row => (int)row["idemisti_import"] == emistiImportKey)
					.First()["idcsa_import"] = (int?)currentRow["idcsa_import"];
			}

            DS.csa_importver.Clear();
			DS.csa_importriep.Clear();
			
			DataSet versamentiDS = Conn.CallSP("Emisti_Crea_Versamenti", new object[] { emistiImportKey });
			DataSet riepiloghiDS = Conn.CallSP("Emisti_Crea_riepiloghi", new object[] { emistiImportKey });

			if (versamentiDS != null && riepiloghiDS != null && versamentiDS.Tables.Count > 0 && riepiloghiDS.Tables.Count > 0) {

				fillVersamenti(versamentiDS.Tables[0]);
				fillRiepiloghi(riepiloghiDS.Tables[0]);
			}

			btnImportEmisti.Enabled = false;
		}
    }


    class Fake_EpPoster : ep_poster {
		private DataSet d = null;

		private EP_Manager epm;

		//public PostData p;
		public Fake_EpPoster(EP_Manager ep_manager) : base(ep_manager) {
			this.epm = ep_manager;
			epm.setPostingClass(this);
		}

		public override ProcedureMessageCollection DO_POST_SERVICE() {
			//effettua tutte le operazioni che avrebbe fatto
			// Il beforePost è già stato invocato correttamente
			epm.silent = true;
			epm.silentBlocked = true;
			epm.clearMessages();
			epm.invokedByInnerPosting = true;
			epm.afterPost(true);
			epm.invokedByInnerPosting = false;
			return epm.getMessages();
		}

		public override bool saveData(DataSet d, PostData post) {
			this.d = d;

			return true;
		}

		public DataSet getDataSet() {
			return d;
		}
	}
}
