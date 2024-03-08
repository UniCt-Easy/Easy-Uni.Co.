
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


namespace e2e {
    /// <summary>
    /// Summary description for mandate_default
    /// </summary>
    [TestClass]
    public class mandate_default_ANAC {
        private static testE2EMainHelper mainTester;
        private static TestContext staticTestContext;
       
        [ClassInitialize]
        public static void testInitialize(TestContext t) {
            mainTester = new testE2EMainHelper();
            staticTestContext = t;
        }

        [ClassCleanup]
        public static void testEnd() {
            mainTester.close();
        }
        //Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize() {
            
            testE2EFrmHelper.registerFormTest("mandate", "default", testTab_ANAC_Present);
        }
        
        private testE2EFrmHelper testF;
        
        public void testTab_ANAC_Present(Form form) {
            testF = new testE2EFrmHelper(form);
            TabControl tabControl1 = testF.findByName("tabControl1") as TabControl;
            Assert.IsNotNull(tabControl1, "Esiste il tabControl1");
            TabPage tabAnac = testF.findByName("tabAnac") as TabPage;
            Assert.IsNotNull(tabAnac, "Esiste il tabAnac");
            Assert.IsTrue(tabControl1.TabPages.Contains(tabAnac), "Tab ANAC inizialmente visibile");

            var ctrlTipoCP = testF.findByTag("mandate.idmankind");
            ComboBox cbTipoCP = ctrlTipoCP as ComboBox;
            cbTipoCP.setDisplay("Tasse, Imposte e Diritti ");
            Assert.IsFalse(tabControl1.TabPages.Contains(tabAnac), "Tab ANAC non visibile");
        }

        [TestMethod]
        public void testChildFormRegistryPayMethod() {            
            mainTester.openFromMenu("mandate", "default");
            Assert.IsTrue(testE2EFrmHelper.hasBeenInvoked("mandate","default"));
        }



        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup() {
            testF.closeForm();
        }
    }

    /// <summary>
    /// Summary description for mandate_default
    /// </summary>
    [TestClass]
    public class mandate_default {
        private static testE2EMainHelper mainTester;
        private static TestContext staticTestContext;

        [ClassInitialize]
        public static void testInitialize(TestContext t) {
            mainTester = new testE2EMainHelper(new DateTime(2021, 12, 31), "test_2");
            staticTestContext = t;

        }

        [ClassCleanup]
        public static void testEnd() {
            mainTester.close();
        }

        //Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize() {
            
            testE2EFrmHelper.registerFormTest("mandate", "default", mandateTestForm);
          
            mainTester.openFromMenu("mandate", "default");
        }

        private void Target(FormActivated @event) {
	        var form = @event.f;
	        var btnSostituisciDettaglio = q.getField("btnSostituisciDettaglio", form);

	        ((Button) testE2EFrmHelper.findByName(form, "btnSelect")).PerformClick();//Siamo nel from WizSostituisciDettaglio.cs
            //var CountRow = form.GetType().GetField("count");
            TextBox txtOldIdGroup = (TextBox)testE2EFrmHelper.findByName(form, "txtOldIdGroup");//Siamo nel from WizSostituisciDettaglio.cs
            Assert.AreEqual(3, CfgFn.GetNoNullInt32(txtOldIdGroup.Text), "Dettaglio correttamente selezionato");
            
            
            MethodInfo formMethod = form.GetType().GetMethod("calcola", BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance); 
	        if (formMethod != null) {
		        formMethod.Invoke(form, new object[2] {1, 2});
	        };
            form.Close();
        }

        private testE2EFrmHelper testF;

        public void mandateTestForm(Form form) {
            testF = new testE2EFrmHelper(form);
            Application.DoEvents();
            
        }

        [TestMethod]
        public void testBtnSostituisciMessage_t() {
	        var t = new TestHelp(new DateTime(2021, 12, 31), "sample_2", "test_2");
	        q filterMan = q.eq("idmankind", "AUA_CF_C") & q.eq("yman", 2020) & q.eq("nman", 23);
	        t.binaryReplaceSet(filterMan, t.getTableSet(TestHelp.mainObject.mandate));
	        DataTable tMandate = t.testConn.readTable("mandate", filterMan);
	        DataRow rMan = tMandate.Rows[0];
	        Assert.AreEqual(1, tMandate.Rows.Count, "Il contratto esiste");
	        t.binaryCopyEp(rMan, false);


	        var ds = testF.ctrl.ds;
	        var listMsg = testF.resp.getMessages();
	        Assert.AreEqual(0, listMsg.Count, "No messages at start");

	        //SELEZIONO IL TIPO DI CONTRATTO DALLA COMBOBOX
	        var ctrlTipologia = testF.findByName("cmbTipoOrdine");
	        ComboBox cbTipoContratto = ctrlTipologia as ComboBox;
	        cbTipoContratto.setDisplay("AUA-Buono d'ordine Commerciale"); //("AUA_CF_C");
	        //INSERISCO L'ANNO DEL CONTRATTO
	        TextBox txtYContr = testF.findByName("txtEsercOrdine") as TextBox;
	        txtYContr.Focus();
	        txtYContr.Text = "2020";

	        TextBox txtNCont = testF.findByName("txtNumOrdine") as TextBox;
	        txtNCont.Focus();
	        txtNCont.Text = "23";
	        //Provoca il leave dal txtNumContratto
	        txtYContr.Focus();

	        //PREMO IL BOTTONE EFFETTUA RICERCA
	        testF.ctrl.DoMainCommand("maindosearch");

	        var ctrlbtnSostituisciDettaglio = testF.findByName("btnSostituisciDettaglio");
	        Button btnSostituisciDettaglio = ctrlbtnSostituisciDettaglio as Button;
	        Assert.IsTrue(btnSostituisciDettaglio.Enabled, "Button Sostituisci Abilitato");
	        var listener = new ApplicationEventHandlerDelegate<FormActivated>(Target);
	        FormController.MainEventsManager.addListener(listener);

	        testF.clickByName("btnSostituisciDettaglio");
	        //string Mess1 =
		       // "Vi sono alcun dettagli marcati come 'Fatture da ricevere o Rateo', per essi si dovrà procedere con L' ANNULLO.";
	        //Assert.AreEqual(1, listMsg.Count, "One message at end");
	        //Assert.AreEqual(Mess1, listMsg[0]);

            FormController.MainEventsManager.removeListener(listener);
            testF.closeForm();
        }

        [TestMethod]
        public void checkInsertCancelMessageCP() {
            var listMsg = testF.resp.getMessages();
            Assert.AreEqual(0, listMsg.Count, "No messages at start");
            testF.ctrl.DoMainCommand("maininsert");
            testF.ctrl.DoMainCommand("maindelete");
            Assert.AreEqual(1, listMsg.Count, "One message at end");
            Assert.AreEqual("Annullo l'inserimento dell'oggetto Contratto Passivo nella tabella mandate", listMsg[0]);
        }

        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup() {
            testF.closeForm();
            Application.DoEvents();
        }


        

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }
    }
}
