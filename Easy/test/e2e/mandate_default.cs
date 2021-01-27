
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
            
            testE2EFrmHelper.registerFormTest("mandate", "default", mandateTestForm);
            mainTester.openFromMenu("mandate", "default");
        }

        private testE2EFrmHelper testF;

        public void mandateTestForm(Form form) {
            testF = new testE2EFrmHelper(form);
           
            Application.DoEvents();
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
