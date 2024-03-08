
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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using metadatalibrary;
using System.Data;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using q = metadatalibrary.MetaExpression;
using mainform;
using funzioni_configurazione;
using System.Windows.Forms;
using TestHelper;
using metaeasylibrary;

namespace e2e {
	/// <summary>
	/// Test contabilizzazione contratti attivi su form levels
	/// </summary>
	[TestClass]
	public class ContrattiAttivi_Incasso_FormLivelli {
		public ContrattiAttivi_Incasso_FormLivelli() {
			//
			// TODO: Add constructor logic here
			//
		}
		private static testE2EMainHelper mainTester;
		private static TestHelp th;
		private static TestContext staticTestContext;
		private testE2EFrmHelper testF;
       
		[ClassInitialize]
		public static void testInitialize(TestContext t) {
			mainTester = new testE2EMainHelper(new DateTime(2019,12,31));
			th = new TestHelp(new DateTime(2019,12,31));
			staticTestContext = t;
		}
		//Use TestInitialize to run code before running each test
		[TestInitialize()]
		public void MyTestInitialize() {
            
			testE2EFrmHelper.registerFormTest("income", "levels", onActivationForm);
			mainTester.openFromMenuByTitle("Entrate", "2 - Riscossione");
		}

		//Use TestCleanup to run code after each test has run
		[TestCleanup()]
		public void MyTestCleanup() {
			testF.ctrl.DontWarnOnInsertCancel = true;
			testF.closeForm();
			MetaFactory.factory.getSingleton<IMessageShower>().getResponder().clearMessages();
			Application.DoEvents();
		}

		[ClassCleanup]
		public static void testEnd() {
			mainTester.close();
		}
		
		

		public void onActivationForm(Form form) {
			testF = new testE2EFrmHelper(form);
           
			Application.DoEvents();
		}


		private TestContext testContextInstance;

		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext {
			get {
				return testContextInstance;
			}
			set {
				testContextInstance = value;
			}
		}

	

		/// <summary>
		/// Controlla che nel form income levels - incassi quando si seleziona un accertamento collegato a c.attivo
		///		si riempia il grid degli incassi
		/// </summary>
		[TestMethod]
		public void checkRiempimentoIncassi_1() {
			var listMsg = testF.resp.getMessages();
			
			Assert.AreEqual(0, listMsg.Count, $"No messages at start");
			testF.ctrl.DoMainCommand("maininsert");
			var ds = testF.ctrl.ds;

			Assert.AreEqual(0,ds.Tables["incomelastestimatedetail"].Rows.Count,"La tabella degli incassi è inizialmente vuota");

			TextBox txtYPrec = testF.findByName("txtEsercizioFasePrecedente") as TextBox;
			txtYPrec.Focus();
			txtYPrec.Text = "2019";

			TextBox txtNPrec = testF.findByName("txtNumeroFasePrecedente") as TextBox;
			txtNPrec.Focus();
			txtNPrec.Text = "3163";

			//Provoca il leave dal txtNumeroFasePrecedente
			txtYPrec.Focus();

			Assert.AreEqual(1,ds.Tables["incomelastestimatedetail"].Rows.Count,"La tabella degli incassi è stata riempita in automatico");
			DataRow r = ds.Tables["incomelastestimatedetail"].Rows[0];
			Assert.AreEqual("CA_GENERICO/2019/46/2",$"{r["idestimkind"]}/{r["yestim"]}/{r["nestim"]}/{r["rownum"]}","Agganciata la riga CA_GENERICO/2019/46/2");
			Assert.AreEqual(650m,CfgFn.GetNoNullDecimal(r["amount"]),"Importo corretto");
			

			DataGrid g = testF.findByTag("incomelastestimatedetail.detail.detail") as DataGrid;
			Assert.AreEqual(1,g.VisibleRowCount,"Il grid visualizza una riga");

			//Controlla che il totale sia aggiornato
			TextBox tTot = testF.findByName("txtTotDettIncassi") as TextBox;
			Assert.AreEqual((650M).ToString("c"),tTot.Text,"Il txt dei totali è aggiornato");

		}
		/// <summary>
		/// Inserimento incasso sotto Accertamento collegato a CA_GENERICO contabilizzato su più accertamenti
		/// </summary>
		[TestMethod]
		public void checkRiempimentoIncassi_2() {
			var listMsg = testF.resp.getMessages();
			
			Assert.AreEqual(0, listMsg.Count, $"No messages at start");
			//SIMULA IL CLICK DEL BOTTONE INSERISCI 
			testF.ctrl.DoMainCommand("maininsert");
			var ds = testF.ctrl.ds;

			Assert.AreEqual(0,ds.Tables["incomelastestimatedetail"].Rows.Count,"La tabella degli incassi è inizialmente vuota");

			TextBox txtYPrec = testF.findByName("txtEsercizioFasePrecedente") as TextBox;
			txtYPrec.Focus();
			txtYPrec.Text = "2018";

			TextBox txtNPrec = testF.findByName("txtNumeroFasePrecedente") as TextBox;
			txtNPrec.Focus();
			txtNPrec.Text = "126396";
			
			//Provoca il leave dal txtNumeroFasePrecedente
			txtYPrec.Focus();


			Assert.AreEqual(2,ds.Tables["incomelastestimatedetail"].Rows.Count,"La tabella degli incassi è stata riempita in automatico");

			DataRow r = ds.Tables["incomelastestimatedetail"]._Filter(q.eq("rownum",1))[0];
			Assert.AreEqual("CA_GENERICO/2018/71/1",$"{r["idestimkind"]}/{r["yestim"]}/{r["nestim"]}/{r["rownum"]}","Agganciata la riga CA_GENERICO/2018/71/1");
			Assert.AreEqual(3000m,CfgFn.GetNoNullDecimal(r["amount"]),"Importo corretto");

			DataRow r2 = ds.Tables["incomelastestimatedetail"]._Filter(q.eq("rownum",2))[0];
			Assert.AreEqual("CA_GENERICO/2018/71/2",$"{r2["idestimkind"]}/{r2["yestim"]}/{r2["nestim"]}/{r2["rownum"]}","Agganciata la riga CA_GENERICO/2018/71/2");
			Assert.AreEqual(3000m,CfgFn.GetNoNullDecimal(r["amount"]),"Importo corretto");
			
			DataGrid g = testF.findByTag("incomelastestimatedetail.detail.detail") as DataGrid;
			Assert.AreEqual(2,g.VisibleRowCount,"Il grid visualizza due righe");	
		    
			DataRow drMovFinanziario = testF.conn.readTable("income",q.eq("nmov", 126396) & q.eq("ymov",2018)).Rows[0];
			q filterEstConnected = q.eq("idestimkind", "CA_GENERICO") & q.eq("yestim", 2018) & q.eq("nestim", 71) & q.eq("idinc_taxable",drMovFinanziario["idinc"]);
			DataTable testimateDetailColleg =testF.conn.readTable("estimatedetail", filterEstConnected);
			Assert.AreEqual(2,testimateDetailColleg.Rows.Count,"Ci sono due dettagli del contratto collegati al'accertamento finanziario");

			//Controlla che il totale sia aggiornato
			TextBox tTot = testF.findByName("txtTotDettIncassi") as TextBox;
			Assert.AreEqual((6000M).ToString("c"),tTot.Text,"Il txt dei totali è aggiornato");

		}

		/// <summary>
		/// Inserimento incasso sotto Accertamento collegato a CA_GENERICO, cambiando l’accertamento padre
		/// </summary>
		[TestMethod]
		public void checkRiempimentoIncassi_cambioAccertamentoPadre() {
			//Inserimento incasso sotto Accertamento collegato a CA_GENERICO, cambiando l’accertamento padre

		   //SIMULA IL CLICK DEL BOTTONE INSERISCI 
			testF.ctrl.DoMainCommand("maininsert");
			var ds = testF.ctrl.ds;

			var listMsg = testF.resp.getMessages();
			Assert.AreEqual(0, listMsg.Count, "No messages at start");

			Assert.IsTrue(testF.ctrl.InsertMode,"Il form si trova in insert mode in avvio");
			Assert.AreEqual(0,ds.Tables["incomelastestimatedetail"].Rows.Count,"La tabella degli incassi è vuota in avvio");

			//PRIMO INSERIMENTO DATI
			TextBox txtYprec = testF.findByName("txtEsercizioFasePrecedente") as TextBox;
			txtYprec.Focus();
			txtYprec.Text = "2018";
			TextBox txtNprec = testF.findByName("txtNumeroFasePrecedente") as TextBox;
			txtNprec.Focus();
			txtNprec.Text = "126396";
			//Provoca il leave dal txtNumeroFasePrecedente
			txtYprec.Focus();

			//CAMBIO IL TESTO DELLA TEXTBOX NUMERO FASE PRECEDENTE
			txtNprec.Focus();
			txtNprec.Clear();
			txtNprec.Text = "126397";
			//Provoca il leave dal txtNumeroFasePrecedente
			txtYprec.Focus();

			Assert.AreEqual(3,ds.Tables["incomelastestimatedetail"].Rows.Count,"La tabella degli incassi è stata riempita in automatico");

			DataRow r = ds.Tables["incomelastestimatedetail"]._Filter(q.eq("rownum",1))[0];
			Assert.AreEqual("CA_GENERICO/2018/72/1",$"{r["idestimkind"]}/{r["yestim"]}/{r["nestim"]}/{r["rownum"]}","Agganciata la riga CA_GENERICO/2018/72/1");
			Assert.AreEqual(1200m,CfgFn.GetNoNullDecimal(r["amount"]),"Importo corretto");

			DataRow r2 = ds.Tables["incomelastestimatedetail"]._Filter(q.eq("rownum",2))[0];
			Assert.AreEqual("CA_GENERICO/2018/72/2",$"{r2["idestimkind"]}/{r2["yestim"]}/{r2["nestim"]}/{r2["rownum"]}","Agganciata la riga CA_GENERICO/2018/72/2");
			Assert.AreEqual(1700m,CfgFn.GetNoNullDecimal(r2["amount"]),"Importo corretto");

		    DataRow r3 = ds.Tables["incomelastestimatedetail"]._Filter(q.eq("rownum",3))[0];
			Assert.AreEqual("CA_GENERICO/2018/72/3",$"{r3["idestimkind"]}/{r3["yestim"]}/{r3["nestim"]}/{r3["rownum"]}","Agganciata la riga CA_GENERICO/2018/72/3");
			Assert.AreEqual(4000m,CfgFn.GetNoNullDecimal(r3["amount"]),"Importo corretto");
			
			DataGrid g = testF.findByTag("incomelastestimatedetail.detail.detail") as DataGrid;
			Assert.AreEqual(3,g.VisibleRowCount,"Il grid visualizza tre righe");
			
			//Controlla che il totale sia aggiornato
			TextBox tTot = testF.findByName("txtTotDettIncassi") as TextBox;
			Assert.AreEqual((6900M).ToString("c"),tTot.Text,"Il txt dei totali è aggiornato");

		}

	}

	/// <summary>
	/// Test contabilizzazione contratti attivi su form gerarchia
	/// </summary>
	[TestClass]
	public class ContrattiAttivi_Incasso_FormGerarchico{
			public ContrattiAttivi_Incasso_FormGerarchico() {
			//
			// TODO: Add constructor logic here
			//
		}
		private static testE2EMainHelper mainTester;
		private static TestContext staticTestContext;
		private testE2EFrmHelper testF;
       
		[ClassInitialize]
		public static void testInitialize(TestContext t) {
			mainTester = new testE2EMainHelper(new DateTime(2019,12,31));
			staticTestContext = t;
		}
		//Use TestInitialize to run code before running each test
		[TestInitialize()]
		public void MyTestInitialize() {
            
			testE2EFrmHelper.registerFormTest("income", "gerarchico", onActivationForm);
			mainTester.openFromMenuByTitle("Entrate", "Visualizzazione e Modifica");
		}

		//Use TestCleanup to run code after each test has run
		[TestCleanup()]
		public void MyTestCleanup() {
			testF.ctrl.DontWarnOnInsertCancel = true;
			testF.closeForm();
			MetaFactory.factory.getSingleton<IMessageShower>().getResponder().clearMessages();
			Application.DoEvents();
		}

		[ClassCleanup]
		public static void testEnd() {
			mainTester.close();
		}
		
		

		public void onActivationForm(Form form) {
			testF = new testE2EFrmHelper(form);
           
			Application.DoEvents();
		}


		private TestContext testContextInstance;

		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext {
			get {
				return testContextInstance;
			}
			set {
				testContextInstance = value;
			}
		}

		


		/// <summary>
		/// Controlla che nel form income levels - incassi quando si seleziona un accertamento collegato a c.attivo
		///		si riempia il grid degli incassi
		/// </summary>
		[TestMethod]
		public void checkRiempimentoIncassi_1() {
			var ds = testF.ctrl.ds;

			var listMsg = testF.resp.getMessages();
			Assert.AreEqual(0, listMsg.Count, "No messages at start");

			TextBox txtY = testF.findByName("txtEsercizioMovimento") as TextBox;
			txtY.Text = "2019";

			TextBox txtN = testF.findByName("txtNumeroMovimento") as TextBox;
			txtN.Text = "3163";

			testF.ctrl.DoMainCommand("maindosearch");
			Assert.IsTrue(testF.ctrl.EditMode,"Il form si trova in edit mode dopo la ricerca del parent");

			Assert.AreEqual(0,ds.Tables["incomelastestimatedetail"].Rows.Count,"La tabella degli incassi è vuota sull'accertamento");


			testF.ctrl.DoMainCommand("maininsert");
			Assert.IsTrue(testF.ctrl.InsertMode,"Il form si trova in insert mode dopo la ricerca del parent");

			

			Assert.AreEqual(1,ds.Tables["incomelastestimatedetail"].Rows.Count,"La tabella degli incassi è stata riempita in automatico");
			DataRow r = ds.Tables["incomelastestimatedetail"].Rows[0];
			Assert.AreEqual("CA_GENERICO/2019/46/2",$"{r["idestimkind"]}/{r["yestim"]}/{r["nestim"]}/{r["rownum"]}","Agganciata la riga CA_GENERICO/2019/46/2");
			Assert.AreEqual(650m,CfgFn.GetNoNullDecimal(r["amount"]),"Importo corretto");
			

			DataGrid g = testF.findByTag("incomelastestimatedetail.detail.detail") as DataGrid;
			Assert.AreEqual(1,g.VisibleRowCount,"Il grid visualizza una riga");

			//Controlla che il totale sia aggiornato
			TextBox tTot = testF.findByName("txtTotDettIncassi") as TextBox;
			Assert.AreEqual((650M).ToString("c"),tTot.Text,"Il txt dei totali è aggiornato");

		}
	}


	/// <summary>
	/// Test contabilizzazione contratti attivi su form procedura
	/// </summary>
	[TestClass]
	public class ContrattiAttivi_Incasso_FormProcedura{
			public ContrattiAttivi_Incasso_FormProcedura() {
			//
			// TODO: Add constructor logic here
			//
		}
		private static testE2EMainHelper mainTester;
		private static TestHelp th;
		private static TestContext staticTestContext;
		private testE2EFrmHelper testF;
       
		[ClassInitialize]
		public static void testInitialize(TestContext t) {
			mainTester = new testE2EMainHelper(new DateTime(2019,12,31));
			th = new TestHelp(new DateTime(2019,12,31));
			staticTestContext = t;
		}
		//Use TestInitialize to run code before running each test
		[TestInitialize()]
		public void MyTestInitialize() {
            
			testE2EFrmHelper.registerFormTest("income", "procedura", onActivationForm);
			mainTester.openFromMenuByTitle("Entrate", "Inserimento");
		}

		//Use TestCleanup to run code after each test has run
		[TestCleanup()]
		public void MyTestCleanup() {
			testF.ctrl.DontWarnOnInsertCancel = true;
			testF.closeForm();
			MetaFactory.factory.getSingleton<IMessageShower>().getResponder().clearMessages();
			Application.DoEvents();
		}

		[ClassCleanup]
		public static void testEnd() {
			mainTester.close();
		}
		
		

		public void onActivationForm(Form form) {
			testF = new testE2EFrmHelper(form);
           
			Application.DoEvents();
		}


		private TestContext testContextInstance;

		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext {
			get {
				return testContextInstance;
			}
			set {
				testContextInstance = value;
			}
		}

		/// <summary>
		/// Controlla che nel form income levels - incassi quando si seleziona un accertamento collegato a c.attivo
		///		si riempia il grid degli incassi
		/// </summary>
		[TestMethod]
		public void checkRiempimentoIncassi_1() {
			var ds = testF.ctrl.ds;

			var listMsg = testF.resp.getMessages();
			Assert.AreEqual(0, listMsg.Count, "No messages at start");

			Assert.IsTrue(testF.ctrl.InsertMode,"Il form si trova in insert mode in avvio");
			Assert.AreEqual(0,ds.Tables["incomelastestimatedetail"].Rows.Count,"La tabella degli incassi è vuota in avvio");

			//Attiva il primo checkbox nelle fasi
			CheckedListBox l = testF.findByName("chkListaFasi") as CheckedListBox;
			l.SetItemCheckState(1,CheckState.Checked);
			Application.DoEvents();

			TextBox txtYprec = testF.findByName("txtEsercizioFasePrecedente") as TextBox;
			txtYprec.Focus();
			txtYprec.Text = "2019";

			TextBox txtNprec = testF.findByName("txtNumeroFasePrecedente") as TextBox;
			txtNprec.Focus();
			txtNprec.Text = "3163";

			//Provoca il leave dal txtNumeroFasePrecedente
			txtYprec.Focus();

			Assert.AreEqual(1,ds.Tables["incomelastestimatedetail"].Rows.Count,"La tabella degli incassi è stata riempita in automatico");
			DataRow r = ds.Tables["incomelastestimatedetail"].Rows[0];
			Assert.AreEqual("CA_GENERICO/2019/46/2",$"{r["idestimkind"]}/{r["yestim"]}/{r["nestim"]}/{r["rownum"]}","Agganciata la riga CA_GENERICO/2019/46/2");
			Assert.AreEqual(650m,CfgFn.GetNoNullDecimal(r["amount"]),"Importo corretto");
			

			DataGrid g = testF.findByTag("incomelastestimatedetail.detail.detail") as DataGrid;
			Assert.AreEqual(1,g.VisibleRowCount,"Il grid visualizza una riga");

			//Controlla che il totale sia aggiornato
			TextBox tTot = testF.findByName("txtTotDettIncassi") as TextBox;
			Assert.AreEqual((650M).ToString("c"),tTot.Text,"Il txt dei totali è aggiornato");

		}

		/// <summary>
		/// Inserimento incasso sotto Accertamento collegato a CA_GENERICO contabilizzato su più accertamenti
		/// </summary>
		[TestMethod]
		public void checkRiempimentoIncassi_2() {
			var ds = testF.ctrl.ds;

			var listMsg = testF.resp.getMessages();
			Assert.AreEqual(0, listMsg.Count, "No messages at start");

			Assert.IsTrue(testF.ctrl.InsertMode,"Il form si trova in insert mode in avvio");
			Assert.AreEqual(0,ds.Tables["incomelastestimatedetail"].Rows.Count,"La tabella degli incassi è vuota in avvio");

			//Attiva il secondo checkbox nelle fasi (riscossione)
			CheckedListBox l = testF.findByName("chkListaFasi") as CheckedListBox;
			l.SetItemCheckState(1,CheckState.Checked);
			Application.DoEvents();

			TextBox txtYprec = testF.findByName("txtEsercizioFasePrecedente") as TextBox;
			txtYprec.Focus();
			txtYprec.Text = "2018";

			TextBox txtNprec = testF.findByName("txtNumeroFasePrecedente") as TextBox;
			txtNprec.Focus();
			txtNprec.Text = "126396";

			//Provoca il leave dal txtNumeroFasePrecedente
			txtYprec.Focus();
					
			Assert.AreEqual(2,ds.Tables["incomelastestimatedetail"].Rows.Count,"La tabella degli incassi è stata riempita in automatico");

			DataRow r = ds.Tables["incomelastestimatedetail"]._Filter(q.eq("rownum",1))[0];
			Assert.AreEqual("CA_GENERICO/2018/71/1",$"{r["idestimkind"]}/{r["yestim"]}/{r["nestim"]}/{r["rownum"]}","Agganciata la riga CA_GENERICO/2018/71/1");
			Assert.AreEqual(3000m,CfgFn.GetNoNullDecimal(r["amount"]),"Importo corretto");

			DataRow r2 = ds.Tables["incomelastestimatedetail"]._Filter(q.eq("rownum",2))[0];
			Assert.AreEqual("CA_GENERICO/2018/71/2",$"{r2["idestimkind"]}/{r2["yestim"]}/{r2["nestim"]}/{r2["rownum"]}","Agganciata la riga CA_GENERICO/2018/71/2");
			Assert.AreEqual(3000m,CfgFn.GetNoNullDecimal(r["amount"]),"Importo corretto");
			
			DataGrid g = testF.findByTag("incomelastestimatedetail.detail.detail") as DataGrid;
			Assert.AreEqual(2,g.VisibleRowCount,"Il grid visualizza due righe");
			
		    DataRow drMovFinanziario = testF.conn.readTable("income",q.eq("nmov", 126396) & q.eq("ymov",2018)).Rows[0];
			q filterEstConnected = q.eq("idestimkind", "CA_GENERICO") & q.eq("yestim", 2018) & q.eq("nestim", 71) & q.eq("idinc_taxable",drMovFinanziario["idinc"]);
			DataTable testimateDetailColleg =testF.conn.readTable("estimatedetail", filterEstConnected);
			Assert.AreEqual(2,testimateDetailColleg.Rows.Count,"Ci sono due dettagli del contratto collegati al'accertamento finanziario");


			//Controlla che il totale sia aggiornato
			TextBox tTot = testF.findByName("txtTotDettIncassi") as TextBox;
			Assert.AreEqual((6000M).ToString("c"),tTot.Text,"Il txt dei totali è aggiornato");

		}

		/// <summary>
		/// Inserimento incasso sotto Accertamento collegato a CA_GENERICO, cambiando l’accertamento padre
		/// </summary>
		[TestMethod]
		public void checkRiempimentoIncassi_cambioAccertamentoPadre() {
			var ds = testF.ctrl.ds;

			var listMsg = testF.resp.getMessages();
			Assert.AreEqual(0, listMsg.Count, "No messages at start");

			Assert.IsTrue(testF.ctrl.InsertMode,"Il form si trova in insert mode in avvio");
			Assert.AreEqual(0,ds.Tables["incomelastestimatedetail"].Rows.Count,"La tabella degli incassi è vuota in avvio");

			//Attiva il secondo checkbox nelle fasi (riscossione)
			CheckedListBox l = testF.findByName("chkListaFasi") as CheckedListBox;
			l.SetItemCheckState(1,CheckState.Checked);
			Application.DoEvents();

			//PRIMO INSERIMENTO DATI
			TextBox txtYprec = testF.findByName("txtEsercizioFasePrecedente") as TextBox;
			txtYprec.Focus();
			txtYprec.Text = "2018";
			TextBox txtNprec = testF.findByName("txtNumeroFasePrecedente") as TextBox;
			txtNprec.Focus();
			txtNprec.Text = "126396";
			//Provoca il leave dal txtNumeroFasePrecedente
			txtYprec.Focus();

			//CAMBIO IL TESTO DELLA TEXTBOX NUMERO FASE PRECEDENTE
			txtNprec.Focus();
			txtNprec.Clear();
			txtNprec.Text = "126397";
			//Provoca il leave dal txtNumeroFasePrecedente
			txtYprec.Focus();

			Assert.AreEqual(3,ds.Tables["incomelastestimatedetail"].Rows.Count,"La tabella degli incassi è stata riempita in automatico");

			DataRow r = ds.Tables["incomelastestimatedetail"]._Filter(q.eq("rownum",1))[0];
			Assert.AreEqual("CA_GENERICO/2018/72/1",$"{r["idestimkind"]}/{r["yestim"]}/{r["nestim"]}/{r["rownum"]}","Agganciata la riga CA_GENERICO/2018/72/1");
			Assert.AreEqual(1200m,CfgFn.GetNoNullDecimal(r["amount"]),"Importo corretto");

			DataRow r2 = ds.Tables["incomelastestimatedetail"]._Filter(q.eq("rownum",2))[0];
			Assert.AreEqual("CA_GENERICO/2018/72/2",$"{r2["idestimkind"]}/{r2["yestim"]}/{r2["nestim"]}/{r2["rownum"]}","Agganciata la riga CA_GENERICO/2018/72/2");
			Assert.AreEqual(1700m,CfgFn.GetNoNullDecimal(r2["amount"]),"Importo corretto");

		    DataRow r3 = ds.Tables["incomelastestimatedetail"]._Filter(q.eq("rownum",3))[0];
			Assert.AreEqual("CA_GENERICO/2018/72/3",$"{r3["idestimkind"]}/{r3["yestim"]}/{r3["nestim"]}/{r3["rownum"]}","Agganciata la riga CA_GENERICO/2018/72/3");
			Assert.AreEqual(4000m,CfgFn.GetNoNullDecimal(r3["amount"]),"Importo corretto");
			
			DataGrid g = testF.findByTag("incomelastestimatedetail.detail.detail") as DataGrid;
			Assert.AreEqual(3,g.VisibleRowCount,"Il grid visualizza tre righe");
			
			//Controlla che il totale sia aggiornato
			TextBox tTot = testF.findByName("txtTotDettIncassi") as TextBox;
			Assert.AreEqual((6900M).ToString("c"),tTot.Text,"Il txt dei totali è aggiornato");

		}

		/// <summary>
		/// Inserimento incasso sotto Accertamento collegato a CA_GENERICO, con dettagli già parzialmente incassati nell’esercizio precedente.
		/// </summary>
		[TestMethod]
		public void checkRiempimentoIncassi_dettagliParzIncassatiEsPrecendente() {
			var ds = testF.ctrl.ds;

			var listMsg = testF.resp.getMessages();
			Assert.AreEqual(0, listMsg.Count, "No messages at start");

			Assert.IsTrue(testF.ctrl.InsertMode,"Il form si trova in insert mode in avvio");
			Assert.AreEqual(0,ds.Tables["incomelastestimatedetail"].Rows.Count,"La tabella degli incassi è vuota in avvio");

			//Attiva il secondo checkbox nelle fasi (riscossione)
			CheckedListBox l = testF.findByName("chkListaFasi") as CheckedListBox;
			l.SetItemCheckState(1,CheckState.Checked);
			Application.DoEvents();

			//PRIMO INSERIMENTO DATI
			TextBox txtYprec = testF.findByName("txtEsercizioFasePrecedente") as TextBox;
			txtYprec.Focus();
			txtYprec.Text = "2018";
			TextBox txtNprec = testF.findByName("txtNumeroFasePrecedente") as TextBox;
			txtNprec.Focus();
			txtNprec.Text = "126398";
			//Provoca il leave dal txtNumeroFasePrecedente
			txtYprec.Focus();

			Assert.AreEqual(2,ds.Tables["incomelastestimatedetail"].Rows.Count,"La tabella degli incassi è stata riempita in automatico");

			DataRow r = ds.Tables["incomelastestimatedetail"]._Filter(q.eq("rownum",1))[0];
			Assert.AreEqual("CA_GENERICO/2018/73/1",$"{r["idestimkind"]}/{r["yestim"]}/{r["nestim"]}/{r["rownum"]}","Agganciata la riga CA_GENERICO/2018/72/1");
			Assert.AreEqual(1000m,CfgFn.GetNoNullDecimal(r["amount"]),"Importo corretto");

			DataRow r2 = ds.Tables["incomelastestimatedetail"]._Filter(q.eq("rownum",2))[0];
			Assert.AreEqual("CA_GENERICO/2018/73/2",$"{r2["idestimkind"]}/{r2["yestim"]}/{r2["nestim"]}/{r2["rownum"]}","Agganciata la riga CA_GENERICO/2018/72/2");
			Assert.AreEqual(1550m,CfgFn.GetNoNullDecimal(r2["amount"]),"Importo corretto");
			
			DataGrid g = testF.findByTag("incomelastestimatedetail.detail.detail") as DataGrid;
			Assert.AreEqual(2,g.VisibleRowCount,"Il grid visualizza tre righe");
			
			//Controlla che il totale sia aggiornato
			TextBox tTot = testF.findByName("txtTotDettIncassi") as TextBox;
			Assert.AreEqual((2550M).ToString("c"),tTot.Text,"Il txt dei totali è aggiornato");

		}

		/// <summary>
		/// Inserimento Incasso sotto accertamento padre collegato a CA_GENERICO, senza nessuna riga in  Contratti Attivi
		/// </summary>
		[TestMethod]
		public void checkRiempimentoIncassi_dettagliSplittatiParzIncassati() {
			
			var ds = testF.ctrl.ds;

			var listMsg = testF.resp.getMessages();
			Assert.AreEqual(0, listMsg.Count, "No messages at start");

			Assert.IsTrue(testF.ctrl.InsertMode,"Il form si trova in insert mode in avvio");
			Assert.AreEqual(0,ds.Tables["incomelastestimatedetail"].Rows.Count,"La tabella degli incassi è vuota in avvio");

			//Attiva il secondo checkbox nelle fasi (riscossione)
			CheckedListBox l = testF.findByName("chkListaFasi") as CheckedListBox;
			l.SetItemCheckState(1,CheckState.Checked);
			Application.DoEvents();

			//PRIMO INSERIMENTO DATI
			TextBox txtYprec = testF.findByName("txtEsercizioFasePrecedente") as TextBox;
			txtYprec.Focus();
			txtYprec.Text = "2019";
			TextBox txtNprec = testF.findByName("txtNumeroFasePrecedente") as TextBox;
			txtNprec.Focus();
			txtNprec.Text = "3170";
			//Provoca il leave dal txtNumeroFasePrecedente
			txtYprec.Focus();

			Assert.AreEqual(2,ds.Tables["incomelastestimatedetail"].Rows.Count,"La tabella degli incassi è stata riempita in automatico");

			DataRow r = ds.Tables["incomelastestimatedetail"]._Filter(q.eq("rownum",1))[0];
			Assert.AreEqual("CA_GENERICO/2019/54/1",$"{r["idestimkind"]}/{r["yestim"]}/{r["nestim"]}/{r["rownum"]}","Agganciata la riga CA_GENERICO/2019/54/1");
			Assert.AreEqual(30m,CfgFn.GetNoNullDecimal(r["amount"]),"Importo corretto");

			DataRow r2 = ds.Tables["incomelastestimatedetail"]._Filter(q.eq("rownum",3))[0];
			Assert.AreEqual("CA_GENERICO/2019/54/3",$"{r2["idestimkind"]}/{r2["yestim"]}/{r2["nestim"]}/{r2["rownum"]}","Agganciata la riga CA_GENERICO/2019/54/3");
			Assert.AreEqual(200m,CfgFn.GetNoNullDecimal(r2["amount"]),"Importo corretto");
			
			DataGrid g = testF.findByTag("incomelastestimatedetail.detail.detail") as DataGrid;
			Assert.AreEqual(2,g.VisibleRowCount,"Il grid visualizza tre righe");
			
			//Controlla che il totale sia aggiornato
			TextBox tTot = testF.findByName("txtTotDettIncassi") as TextBox;
			Assert.AreEqual((230M).ToString("c"),tTot.Text,"Il txt dei totali è aggiornato");

		}

		/// <summary>
		/// Inserimento Incasso sotto accertamento padre collegato a CA_GENERICO, senza nessuna riga in  Contratti Attivi
		/// </summary>
		[TestMethod]
		public void checkRiempimentoIncassi_senzaRigheInContrattiAttivi() {

			var ds = testF.ctrl.ds;
			
			var listMsg = testF.resp.getMessages();
			
			Assert.AreEqual(0, listMsg.Count, "No messages at start");

			Assert.IsTrue(testF.ctrl.InsertMode,"Il form si trova in insert mode in avvio");
			Assert.AreEqual(0,ds.Tables["incomelastestimatedetail"].Rows.Count,"La tabella degli incassi è vuota in avvio");

			//Attiva il secondo checkbox nelle fasi (riscossione)
			CheckedListBox l = testF.findByName("chkListaFasi") as CheckedListBox;
			l.SetItemCheckState(1,CheckState.Checked);
			Application.DoEvents();

			//PRIMO INSERIMENTO DATI
			TextBox txtYprec = testF.findByName("txtEsercizioFasePrecedente") as TextBox;
			txtYprec.Focus();
			txtYprec.Text = "2019";
			TextBox txtNprec = testF.findByName("txtNumeroFasePrecedente") as TextBox;
			txtNprec.Focus();
			//txtNprec.Text = "3172";
			txtNprec.Text = "2971";
			//Provoca il leave dal txtNumeroFasePrecedente
			txtYprec.Focus();

			//rimetti a 3
			Assert.AreEqual(1,ds.Tables["incomelastestimatedetail"].Rows.Count,"La tabella degli incassi è stata riempita in automatico");
			
			DataGrid g = testF.findByTag("incomelastestimatedetail.detail.detail") as DataGrid;
			
			//CANCELLO LE RIGHE DAL GRID
		    ds.Tables["incomelastestimatedetail"].Rows.Clear();
			Assert.AreEqual(0,g.VisibleRowCount,"Il grid visualizza 0 righe");

			Meta_EasyDispatcher md = new Meta_EasyDispatcher(testF.conn);
            MetaData meta_Income  = md.Get("income");
			meta_Income.DS = ds;
			var res = th.saveFormData(meta_Income);

			test_EP.checkExistRule(res,"MOVIM169");
			
			////testF.ctrl.SaveFormData();
			//testF.ctrl.DontWarnOnInsertCancel = false;
			//testF.ctrl.DoMainCommand("mainsave");
			//Assert.AreEqual(1,listMsg.Count,"One message at end");

		}

	}


	/// <summary>
	/// Test contabilizzazione contratti attivi su form contratto 
	/// </summary>
	[TestClass]
	public class ContrattiAttivi_Incasso_FormContrAttivoDefault{
			public ContrattiAttivi_Incasso_FormContrAttivoDefault() {
			//
			// TODO: Add constructor logic here
			//
		}
		private static testE2EMainHelper mainTester;
		private static TestHelp th;
		private static TestContext staticTestContext;
		private testE2EFrmHelper testF;
       
		[ClassInitialize]
		public static void testInitialize(TestContext t) {
			mainTester = new testE2EMainHelper(new DateTime(2019,12,31));
			th = new TestHelp(new DateTime(2019,12,31));
			staticTestContext = t;
		}
		//Use TestInitialize to run code before running each test
		[TestInitialize()]
		public void MyTestInitialize() {
            
			testE2EFrmHelper.registerFormTest("estimate", "default", onActivationForm);
			mainTester.openFromMenuByTitle("Entrate", "Contratto attivo");
		}

		//Use TestCleanup to run code after each test has run
		[TestCleanup()]
		public void MyTestCleanup() {
			testF.ctrl.DontWarnOnInsertCancel = true;
			testF.closeForm();
			MetaFactory.factory.getSingleton<IMessageShower>().getResponder().clearMessages();
			Application.DoEvents();
		}

		[ClassCleanup]
		public static void testEnd() {
			mainTester.close();
		}
		
		

		public void onActivationForm(Form form) {
			testF = new testE2EFrmHelper(form);
           
			Application.DoEvents();
		}


		private TestContext testContextInstance;

		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext {
			get {
				return testContextInstance;
			}
			set {
				testContextInstance = value;
			}
		}

		/// <summary>
		/// Verifica Importo incassato sul Dettaglio CA con incassi in più esercizi
		/// </summary>
		[TestMethod]
		public void testImportoIncassatoDettagliContrattoAttivo_IncassiEsericzioDiverso() {
			
			var ds = testF.ctrl.ds;

			var listMsg = testF.resp.getMessages();
			Assert.AreEqual(0, listMsg.Count, "No messages at start");

			//SELEZIONO IL TIPO DI CONTRATTO DALLA COMBOBOX
			var ctrlTipologia = testF.findByName("cmbTipoContratto");
			ComboBox cbTipoContratto = ctrlTipologia as ComboBox;
			cbTipoContratto.setDisplay("CA_GENERICO");
			//INSERISCO L'ANNO DEL CONTRATTO
			TextBox txtYContr = testF.findByName("txtEsercContratto") as TextBox;
			txtYContr.Focus();
			txtYContr.Text = "2018";

			TextBox txtNCont = testF.findByName("txtNumContratto") as TextBox;
			txtNCont.Focus();
			txtNCont.Text = "69";
			//Provoca il leave dal txtNumContratto
			txtYContr.Focus();

			//PREMO IL BOTTONE EFFETTUA RICERCA
			testF.ctrl.DoMainCommand("maindosearch");

			//lista incassi da verificare per i dettagli non annullati
			decimal[] IncassoList = new decimal[]{ 2600,2550,4800};
			Assert.AreEqual(IncassoList.Length,ds.Tables["estimatedetail"]._Filter(q.isNull("stop")).Length,$"Il contratto ha {IncassoList.Length} dettagli");
			for (int i = 0; i < ds.Tables["estimatedetail"]._Filter(q.isNull("stop")).Length; i++) {
				DataRow dr = ds.Tables["estimatedetail"].Rows[i];
				string idestimkind = dr["idestimkind"].ToString();
				int yestim = int.Parse(dr["yestim"].ToString());
				int nestim = int.Parse(dr["nestim"].ToString());
				int rownum = int.Parse(dr["rownum"].ToString());

				q filterEst = q.eq("idestimkind", idestimkind) & q.eq("yestim", yestim) & q.eq("nestim", nestim)  & q.eq("rownum", rownum);
				DataTable tEstimate = testF.conn.readTable("estimatedetail_extview", filterEst);
				decimal CurrIncasso = decimal.Parse(tEstimate.Rows[0]["cashed"].ToString());
				Assert.AreEqual(IncassoList[i],CurrIncasso,"Incasso corrispondente");

			}

		}

		/// <summary>
		/// Verifica Importo incassato sul Dettaglio CA con incassi stesso esercizio
		/// </summary>
		[TestMethod]
		public void testImportoIncassatoDettagliContrattoAttivo_IncassiStessoEsercizio() {
			
			var ds = testF.ctrl.ds;

			var listMsg = testF.resp.getMessages();
			Assert.AreEqual(0, listMsg.Count, "No messages at start");

			//SELEZIONO IL TIPO DI CONTRATTO DALLA COMBOBOX
			var ctrlTipologia = testF.findByName("cmbTipoContratto");
			ComboBox cbTipoContratto = ctrlTipologia as ComboBox;
			cbTipoContratto.setDisplay("CA_GENERICO");
			//INSERISCO L'ANNO DEL CONTRATTO
			TextBox txtYContr = testF.findByName("txtEsercContratto") as TextBox;
			txtYContr.Focus();
			txtYContr.Text = "2019";

			TextBox txtNCont = testF.findByName("txtNumContratto") as TextBox;
			txtNCont.Focus();
			txtNCont.Text = "55";
			//Provoca il leave dal txtNumContratto
			txtYContr.Focus();

			//PREMO IL BOTTONE EFFETTUA RICERCA
			testF.ctrl.DoMainCommand("maindosearch");

			//lista incassi da verificare
			decimal[] IncassoList = new decimal[]{ 100,150,0,100,250};
			Assert.AreEqual(IncassoList.Length,ds.Tables["estimatedetail"].Rows.Count,$"Il contratto ha {IncassoList.Length} dettagli");
			for (int i = 0; i < ds.Tables["estimatedetail"].Rows.Count; i++) {
				DataRow dr = ds.Tables["estimatedetail"].Rows[i];
				string idestimkind = dr["idestimkind"].ToString();
				int yestim = int.Parse(dr["yestim"].ToString());
				int nestim = int.Parse(dr["nestim"].ToString());
				int rownum = int.Parse(dr["rownum"].ToString());

				q filterEst = q.eq("idestimkind", idestimkind) & q.eq("yestim", yestim) & q.eq("nestim", nestim)  & q.eq("rownum", rownum);
				DataTable tEstimate = testF.conn.readTable("estimatedetail_extview", filterEst);
				decimal CurrIncasso = decimal.Parse(tEstimate.Rows[0]["cashed"].ToString());
				Assert.AreEqual(IncassoList[i],CurrIncasso,"Incasso corrispondente");

			}

		}

	}
}
