
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
using q=metadatalibrary.MetaExpression;
using mainform;
using funzioni_configurazione;
using System.Windows.Forms;
using TestHelper;


namespace e2e {
    /// <summary>
    /// Summary description for registry_anagrafica
    /// </summary>
    [TestClass]
    public class registry_anagrafica {
        private static testE2EMainHelper mainTester;
        private static TestContext staticTestContext;
        [ClassInitialize]
        public static void testInitialize(TestContext t) {
            mainTester = new testE2EMainHelper();
			mainTester.clearErrors();
            staticTestContext = t;

        }

        [ClassCleanup]
        public static void testEnd() {
            mainTester.close();
           
        }

        //Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize() {
            testE2EFrmHelper.registerFormTest("registry", "anagrafica", registerTestForm);
			mainTester.openFromMenu("registry", "anagrafica");
        }

        private testE2EFrmHelper testF;
        public void registerTestForm(Form form) {
            testF = new testE2EFrmHelper(form);
            Application.DoEvents();
        }

        [TestMethod]
        public void checkInsertCancelMessage() {
            var listMsg = testF.resp.getMessages();
			testF.resp.clearMessages();
            Assert.AreEqual(0,listMsg.Count,"No messages at start");
            testF.ctrl.DoMainCommand("maininsert");
            testF.ctrl.DontWarnOnInsertCancel = false;
            testF.ctrl.DoMainCommand("maindelete");
            Assert.AreEqual(1,listMsg.Count,"One message at end");
            Assert.AreEqual("Annullo l'inserimento dell'oggetto Cliente/Fornitore nella tabella registry",listMsg[0]);
            testF.closeForm();
        }

        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup() {
            testF.closeForm();
            Assert.AreEqual(false, testF.f.Visible);
            testF.resp.clearMessages();
        }



        [TestMethod]
        public void testLuogoNascitaVisibility() {
            GroupBox grpGeo = testF.findByName("grpGeo") as GroupBox;
            Assert.IsNotNull(grpGeo, "Esiste un group box grpGeo");
            var ctrlTipologia = testF.findByTag("registry.idregistryclass");
            ComboBox cbTipologia = ctrlTipologia as ComboBox;
            Assert.IsTrue(grpGeo.Visible, "grpGeo inizialmente visibile");

            cbTipologia.setDisplay("Anagrafiche complementari");
            Assert.IsFalse(grpGeo.Visible, "grpGeo not visible for anagrafica complementare");


            cbTipologia.setDisplayHaving("persona fisica");
            Assert.IsTrue(grpGeo.Visible, "grpGeo  visible for persona fisica");

            testF.closeForm();
        }

        [TestMethod]
        public void testSurNameVisibility() {
            TestContext = staticTestContext;
            var ctrlTipologia = testF.findByTag("registry.idregistryclass");
            TextBox tSurName = testF.findByTag("registry.surname") as TextBox;
            Assert.IsTrue(tSurName.Visible, "Surname visible for anagrafica complementare");
            Assert.IsNotNull(ctrlTipologia, "Esiste un controllo che indica il tipo anagrafica");
            Assert.IsInstanceOfType(ctrlTipologia, typeof(ComboBox), "Tipologia è un combo");
            ComboBox cbTipologia = ctrlTipologia as ComboBox;
            Assert.IsTrue(cbTipologia.Visible, "combo tipologia visibile");
            Assert.IsTrue(cbTipologia.Enabled, "combo tipologia abilitato");
            cbTipologia.setDisplay("Anagrafiche complementari");
            Assert.IsFalse(tSurName.Visible, "Surname not visible for anagrafica complementare");
            cbTipologia.setDisplayHaving("fisica");
            Assert.IsTrue(tSurName.Visible, "Surname visible for persone senza p.iva");
            cbTipologia.setDisplay("Persona fisica");
            Assert.IsTrue(tSurName.Visible, "Surname visible for persone senza p.iva");
            cbTipologia.setDisplayHaving("Enti non commerciali ed istituzioni internazionali");
            Assert.IsFalse(tSurName.Visible, "Surname visible for persone senza p.iva");
            cbTipologia.setDisplayHaving("enti commerciali");
            Assert.IsFalse(tSurName.Visible, "Surname visible for persone senza p.iva");

            cbTipologia.SelectedIndex = 0;
            Assert.IsTrue(tSurName.Visible, "Surname visible for no selection in combo tipologia");

            testF.closeForm();
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

    [TestClass]
    public class registry_registrypaymethod_gestioneflag {
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
            testE2EFrmHelper.registerFormTest("registry", "anagrafica", registerTestForm);
            testE2EFrmHelper.registerFormTest("registrypaymethod", "anagrafica", testGestioneFlagEsenteSpese);
            mainTester.openFromMenu("registry", "anagrafica");
        }
        private testE2EFrmHelper testFRegistry;
        private testE2EFrmHelper testFRegistryPaymethod;

        public void registerTestForm(Form form) {
            if (form.Name == "Frm_registry_anagrafica") {
                testFRegistry = new testE2EFrmHelper(form);
                testFRegistry.ctrl.DoMainCommand("maininsert");
                testFRegistry.ctrl.DontWarnOnInsertCancel = true;
                Assert.IsTrue(testFRegistry.ctrl.InsertMode);
                Assert.IsTrue(testFRegistry.ctrl.DrawStateIsDone);
                Assert.IsTrue(testFRegistry.ctrl.formInited);
               
                Application.DoEvents();
               

            }
            Application.DoEvents();
        }
        public void testGestioneFlagEsenteSpese(Form form) {
            testFRegistryPaymethod = new testE2EFrmHelper(form);
            //MessageBox.Show("stop");
            Assert.IsNotNull(testFRegistryPaymethod);

            var ctrlTipologiaSpese = testFRegistryPaymethod.findByTag("registrypaymethod.idchargehandling");
            Assert.IsNotNull(ctrlTipologiaSpese, "Esiste un controllo che indica il tipo anagrafica");
            Assert.IsTrue(ctrlTipologiaSpese.Visible, "Tipologia Spese visible for anagrafica complementare");
		
            Assert.IsInstanceOfType(ctrlTipologiaSpese, typeof(ComboBox), "Tipologia è un combo");
            ComboBox cbTipologia = ctrlTipologiaSpese as ComboBox;
            Assert.IsTrue(cbTipologia.Visible, "combo tipologia trattamento spese visibile");
            Assert.IsTrue(cbTipologia.Enabled, "combo tipologia trattamento spese abilitato");
            cbTipologia.SelectedIndex = 0;
            DataTable TChargeHandling = testFRegistryPaymethod.conn.RUN_SELECT("chargehandling","*",null, null, null, false);
            var ctrlFlagEsenteSpese = testFRegistryPaymethod.findByTag("registrypaymethod.flag:0");
            CheckBox chklFlagEsenteSpese = ctrlFlagEsenteSpese as CheckBox;
            cbTipologia.setDisplayHaving("esente");
 
            Assert.IsTrue(chklFlagEsenteSpese.Checked, "gestione flag esente abilitato");

            //foreach (DataRow rCh in TChargeHandling.Rows) {
            //	int flag_exemption = (CfgFn.GetNoNullInt32(rCh["flag"]) & 1);
            //	cbTipologia.setDisplayHaving(rCh["description"].ToString());
            //	Assert.IsTrue(chklFlagEsenteSpese.Checked == !((flag_exemption & 1) == 0), "gestione flag esente abilitato"); 
            //}

            //cbTipologia.SelectedIndex = 0;
            testFRegistryPaymethod.ctrl.DontWarnOnInsertCancel= true;
            testFRegistryPaymethod.closeForm();
        }

        [TestMethod]
        public void testChildFormRegistryPayMethodFlagSpese() {            
            testFRegistry.ctrl.DoMainCommand("maininsert");
            testFRegistry.clickByName("btnPagInserisci");
            Assert.IsTrue(testE2EFrmHelper.hasBeenInvoked("registrypaymethod","anagrafica"));
            testFRegistry.closeForm();
           
        }

    }

    [TestClass]
    public class registry_registrypaymethod {
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
            testE2EFrmHelper.registerFormTest("registry", "anagrafica", registerTestForm);
			testE2EFrmHelper.registerFormTest("registrypaymethod", "anagrafica", testchildFormVisibility);
			mainTester.openFromMenu("registry", "anagrafica");
        }

        private testE2EFrmHelper testFRegistry;
        private testE2EFrmHelper testFRegistryPaymethod;
        public void registerTestForm(Form form) {
            if (form.Name == "Frm_registry_anagrafica") {
                testFRegistry = new testE2EFrmHelper(form);
                testFRegistry.ctrl.DoMainCommand("maininsert");
                testFRegistry.ctrl.DontWarnOnInsertCancel = true;
                Assert.IsTrue(testFRegistry.ctrl.InsertMode);
                Assert.IsTrue(testFRegistry.ctrl.DrawStateIsDone);
                Assert.IsTrue(testFRegistry.ctrl.formInited);
               
                Application.DoEvents();
               

            }
            Application.DoEvents();
        }

        public void testchildFormVisibility(Form form) {
            testFRegistryPaymethod = new testE2EFrmHelper(form);
            //MessageBox.Show("stop");
            Assert.IsNotNull(testFRegistryPaymethod);
            Assert.IsTrue(testFRegistryPaymethod.f.Visible);
            Assert.AreEqual("registrypaymethod",testFRegistryPaymethod.meta.TableName);
            testFRegistryPaymethod.ctrl.DontWarnOnInsertCancel = true;
            testFRegistryPaymethod.ctrl.DoMainCommand("maindelete");
            Application.DoEvents();
            Assert.AreEqual(testFRegistryPaymethod.f.DialogResult,DialogResult.Cancel);
            Assert.AreEqual(0,testFRegistry.f.OwnedForms.Length);
        }


	

		[TestMethod]
        public void testChildFormRegistryPayMethod() {            
            testFRegistry.ctrl.DoMainCommand("maininsert");
            testFRegistry.clickByName("btnPagInserisci");
            Assert.IsTrue(testE2EFrmHelper.hasBeenInvoked("registrypaymethod","anagrafica"));
            testFRegistry.closeForm();
        }

    
    }

	[TestClass]
	public class registry_address_base {
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
			testE2EFrmHelper.registerFormTest("registry", "anagrafica", registerTestForm);
			testE2EFrmHelper.registerFormTest("registryaddress", "anagraficasingle", testchildFormVisibility);
			mainTester.openFromMenu("registry", "anagrafica");
		}

		private testE2EFrmHelper testFRegistry;
		private testE2EFrmHelper testFRegistryAddress;
		public void registerTestForm(Form form) {
			if (form.Name == "Frm_registry_anagrafica") {
				testFRegistry = new testE2EFrmHelper(form);
				testFRegistry.ctrl.DoMainCommand("maininsert");
				testFRegistry.ctrl.DontWarnOnInsertCancel = true;
				Assert.IsTrue(testFRegistry.ctrl.InsertMode);
				Assert.IsTrue(testFRegistry.ctrl.DrawStateIsDone);
				Assert.IsTrue(testFRegistry.ctrl.formInited);

				Application.DoEvents();


			}
			Application.DoEvents();
		}

		public void testchildFormVisibility(Form form) {
			testFRegistryAddress = new testE2EFrmHelper(form);
			//MessageBox.Show("stop");
			Assert.IsNotNull(testFRegistryAddress);
			Assert.IsTrue(testFRegistryAddress.f.Visible);
			Assert.AreEqual("registryaddress", testFRegistryAddress.meta.TableName);
			testFRegistryAddress.ctrl.DontWarnOnInsertCancel = true;
			testFRegistryAddress.ctrl.DoMainCommand("maindelete");
			Application.DoEvents();
			Assert.AreEqual(testFRegistryAddress.f.DialogResult, DialogResult.Cancel);
			Assert.AreEqual(0, testFRegistry.f.OwnedForms.Length);
		    testFRegistryAddress.ctrl.DontWarnOnInsertCancel = true;
            testFRegistryAddress.closeForm();
		}


		[TestMethod]
		public void testChildFormRegistryAddress() {
			testFRegistry.ctrl.DoMainCommand("maininsert");
			testFRegistry.clickByName("btnIndInserisci");
			Assert.IsTrue(testE2EFrmHelper.hasBeenInvoked("registryaddress", "anagraficasingle"));
            testFRegistry.closeForm();

        }



	}


    [TestClass]
	public class registry_address_ind_estero {
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
			testE2EFrmHelper.registerFormTest("registry", "anagrafica", registerTestForm);
			testE2EFrmHelper.registerFormTest("registryaddress", "anagraficasingle", testIndirizzoEsteroVisibility);
			mainTester.openFromMenu("registry", "anagrafica");
		}

		private testE2EFrmHelper testFRegistry;
		private testE2EFrmHelper testFRegistryAddress;
		public void registerTestForm(Form form) {
			if (form.Name == "Frm_registry_anagrafica") {
				testFRegistry = new testE2EFrmHelper(form);
				testFRegistry.ctrl.DoMainCommand("maininsert");
				testFRegistry.ctrl.DontWarnOnInsertCancel = true;
				Assert.IsTrue(testFRegistry.ctrl.InsertMode);
				Assert.IsTrue(testFRegistry.ctrl.DrawStateIsDone);
				Assert.IsTrue(testFRegistry.ctrl.formInited);

				Application.DoEvents();


			}
			Application.DoEvents();
		}



		[TestMethod]
		public void testChildFormRegistryAddress() {
			testFRegistry.ctrl.DoMainCommand("maininsert");
			testFRegistry.clickByName("btnIndInserisci");
			Assert.IsTrue(testE2EFrmHelper.hasBeenInvoked("registryaddress", "anagraficasingle"));
			testFRegistry.closeForm();
		}

		
		public void testIndirizzoEsteroVisibility(Form form) {
			testFRegistryAddress = new testE2EFrmHelper(form);
			Assert.IsNotNull(testFRegistryAddress, "Test Inizializzato");
			GroupBox grpEstero = testFRegistryAddress.findByName("grpEstero") as GroupBox;
			Assert.IsNotNull(grpEstero, "Esiste un group box grpEstero");
			var ctrlFlagEstero = testFRegistryAddress.findByTag("registryaddress.flagforeign:S:N");
			CheckBox chkFlagEstero = ctrlFlagEstero as CheckBox;
			Assert.IsTrue(!grpEstero.Visible, "grpEstero inizialmente non visibile");
			chkFlagEstero.Checked = true;
		
			Assert.IsTrue(grpEstero.Visible, "grpEstero visibile for flag estero");
			chkFlagEstero.Checked = false;
			Assert.IsTrue(!grpEstero.Visible, "grpEstero non visibile for flag estero non selezionato");
		    testFRegistryAddress.closeForm();
		}
        




	}


    [TestClass]
	public class registry_address_italia {
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
			testE2EFrmHelper.registerFormTest("registry", "anagrafica", registerTestForm);
			testE2EFrmHelper.registerFormTest("registryaddress", "anagraficasingle", testIndirizzoItaliaVisibility);
			mainTester.openFromMenu("registry", "anagrafica");
		}

		private testE2EFrmHelper testFRegistry;
		private testE2EFrmHelper testFRegistryAddress;

		public void registerTestForm(Form form) {
			if (form.Name == "Frm_registry_anagrafica") {
				testFRegistry = new testE2EFrmHelper(form);
				testFRegistry.ctrl.DoMainCommand("maininsert");
				testFRegistry.ctrl.DontWarnOnInsertCancel = true;
				Assert.IsTrue(testFRegistry.ctrl.InsertMode);
				Assert.IsTrue(testFRegistry.ctrl.DrawStateIsDone);
				Assert.IsTrue(testFRegistry.ctrl.formInited);

				Application.DoEvents();


			}
			Application.DoEvents();
		}
        


		[TestMethod]
		public void testChildFormRegistryAddress() {
			testFRegistry.ctrl.DoMainCommand("maininsert");
			testFRegistry.clickByName("btnIndInserisci");
			Assert.IsTrue(testE2EFrmHelper.hasBeenInvoked("registryaddress", "anagraficasingle"));
			testFRegistry.closeForm();
		}

		
		public void testIndirizzoItaliaVisibility(Form form) {
			testFRegistryAddress = new testE2EFrmHelper(form);
			Assert.IsNotNull(testFRegistryAddress, "Test Inizializzato");
			GroupBox grpItaliano = testFRegistryAddress.findByName("grpItaliano") as GroupBox;
			Assert.IsNotNull(grpItaliano, "Esiste un group box grpItaliano");
			var ctrlFlagEstero = testFRegistryAddress.findByTag("registryaddress.flagforeign:S:N");
			CheckBox chkFlagEstero = ctrlFlagEstero as CheckBox;
			Assert.IsTrue(grpItaliano.Visible, "grpItaliano inizialmente visibile");
			chkFlagEstero.Checked = true;
			Assert.IsTrue(!grpItaliano.Visible, "grpItaliano non visibile for flag estero");
			chkFlagEstero.Checked = false;
			Assert.IsTrue(grpItaliano.Visible, "grpItaliano visibile for flag estero non selezionato");
            testFRegistryAddress.closeForm();
		}




	}


	[TestClass]
	public class registrydurc {
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
			testE2EFrmHelper.registerFormTest("registry", "anagrafica", registerTestForm);
			testE2EFrmHelper.registerFormTest("registrydurc", "anagraficadetail", testchildFormVisibility);
			mainTester.openFromMenu("registry", "anagrafica");
		}

		private testE2EFrmHelper testFRegistry;
		private testE2EFrmHelper testFRegistryDurc;
		public void registerTestForm(Form form) {
			if (form.Name == "Frm_registry_anagrafica") {
				testFRegistry = new testE2EFrmHelper(form);
				testFRegistry.ctrl.DoMainCommand("maininsert");
				testFRegistry.ctrl.DontWarnOnInsertCancel = true;
				Assert.IsTrue(testFRegistry.ctrl.InsertMode);
				Assert.IsTrue(testFRegistry.ctrl.DrawStateIsDone);
				Assert.IsTrue(testFRegistry.ctrl.formInited);

				Application.DoEvents();


			}
			Application.DoEvents();
		}

		public void testchildFormVisibility(Form form) {
			testFRegistryDurc= new testE2EFrmHelper(form);
			//MessageBox.Show("stop");
			Assert.IsNotNull(testFRegistryDurc);
			Assert.IsTrue(testFRegistryDurc.f.Visible);
			Assert.AreEqual("registrydurc", testFRegistryDurc.meta.TableName);
			testFRegistryDurc.ctrl.DontWarnOnInsertCancel = true;
			testFRegistryDurc.ctrl.DoMainCommand("maindelete");
			Application.DoEvents();
			Assert.AreEqual(testFRegistryDurc.f.DialogResult, DialogResult.Cancel);
			Assert.AreEqual(0, testFRegistry.f.OwnedForms.Length);
		}


		[TestMethod]
		public void testChildFormRegistryDurc() {
			testFRegistry.ctrl.DoMainCommand("maininsert");
			testFRegistry.clickByName("button13");
			Assert.IsTrue(testE2EFrmHelper.hasBeenInvoked("registrydurc", "anagraficadetail"));
            testFRegistry.closeForm();
        }

	}
	[TestClass]
	public class registrycvattachment {
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
			testE2EFrmHelper.registerFormTest("registry", "anagrafica", registerTestForm);
			testE2EFrmHelper.registerFormTest("registrycvattachment", "default", testchildFormVisibility);
			mainTester.openFromMenu("registry", "anagrafica");
		}

		private testE2EFrmHelper testFRegistry;
		private testE2EFrmHelper testFRegistryCvAttachement;
		public void registerTestForm(Form form) {
			if (form.Name == "Frm_registry_anagrafica") {
				testFRegistry = new testE2EFrmHelper(form);
				testFRegistry.ctrl.DoMainCommand("maininsert");
				testFRegistry.ctrl.DontWarnOnInsertCancel = true;
				Assert.IsTrue(testFRegistry.ctrl.InsertMode);
				Assert.IsTrue(testFRegistry.ctrl.DrawStateIsDone);
				Assert.IsTrue(testFRegistry.ctrl.formInited);

				Application.DoEvents();


			}
			Application.DoEvents();
		}

		public void testchildFormVisibility(Form form) {
			testFRegistryCvAttachement = new testE2EFrmHelper(form);
			//MessageBox.Show("stop");
			Assert.IsNotNull(testFRegistryCvAttachement);
			Assert.IsTrue(testFRegistryCvAttachement.f.Visible);
			Assert.AreEqual("registrycvattachment", testFRegistryCvAttachement.meta.TableName);
			testFRegistryCvAttachement.ctrl.DontWarnOnInsertCancel = true;
			testFRegistryCvAttachement.ctrl.DoMainCommand("maindelete");
			Application.DoEvents();
			Assert.AreEqual(testFRegistryCvAttachement.f.DialogResult, DialogResult.Cancel);
			Assert.AreEqual(0, testFRegistry.f.OwnedForms.Length);
		    testFRegistryCvAttachement.ctrl.DontWarnOnInsertCancel = true;
            testFRegistryCvAttachement.closeForm();
		}


		[TestMethod]
		public void testChildFormRegistryCvAttachment() {			
			testFRegistry.clickByName("btnInsAtt");
			Assert.IsTrue(testE2EFrmHelper.hasBeenInvoked("registrycvattachment", "default"));
			testFRegistry.closeForm();

		}

		[TestClass]
		public class registryreference {
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
				testE2EFrmHelper.registerFormTest("registry", "anagrafica", registerTestForm);
				testE2EFrmHelper.registerFormTest("registryreference", "default", testchildFormVisibility);
				mainTester.openFromMenu("registry", "anagrafica");
			}

            [TestCleanup()]
            public void MyTestCleanup() {
                testFRegistryReference.closeForm();
                testFRegistry.closeForm();
            }


			private testE2EFrmHelper testFRegistry;
			private testE2EFrmHelper testFRegistryReference;
			public void registerTestForm(Form form) {
				if (form.Name == "Frm_registry_anagrafica") {
					testFRegistry = new testE2EFrmHelper(form);
					testFRegistry.ctrl.DoMainCommand("maininsert");
					testFRegistry.ctrl.DontWarnOnInsertCancel = true;
					Assert.IsTrue(testFRegistry.ctrl.InsertMode);
					Assert.IsTrue(testFRegistry.ctrl.DrawStateIsDone);
					Assert.IsTrue(testFRegistry.ctrl.formInited);

					Application.DoEvents();


				}
				Application.DoEvents();
			}

			public void testchildFormVisibility(Form form) {
				testFRegistryReference = new testE2EFrmHelper(form);
				//MessageBox.Show("stop");
				Assert.IsNotNull(testFRegistryReference);
				Assert.IsTrue(testFRegistryReference.f.Visible);
				Assert.AreEqual("registryreference", testFRegistryReference.meta.TableName);
				testFRegistryReference.ctrl.DontWarnOnInsertCancel = true;
				testFRegistryReference.ctrl.DoMainCommand("maindelete");
				Application.DoEvents();
				Assert.AreEqual(testFRegistryReference.f.DialogResult, DialogResult.Cancel);
				Assert.AreEqual(0, testFRegistry.f.OwnedForms.Length);
			}


			[TestMethod]
			public void testChildFormRegistryReference() {
				testFRegistry.ctrl.DoMainCommand("maininsert");
				var ctrlInsertReference = testFRegistry.findByName("btnContInserisci");
				Button btnlInsertReference = ctrlInsertReference as Button;
				Assert.IsTrue(btnlInsertReference.Enabled, "Button inizialmente abilitato");
				testFRegistry.clickByName("btnContInserisci");
				Assert.IsTrue(testE2EFrmHelper.hasBeenInvoked("registryreference", "default"));
				testFRegistry.closeForm();
			}

		}
		[TestClass]
		public class registrycf {
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
				testE2EFrmHelper.registerFormTest("registry", "anagrafica", registerTestForm);
				testE2EFrmHelper.registerFormTest("registrycf", "default", testchildFormVisibility);
				mainTester.openFromMenu("registry", "anagrafica");
			}

			private testE2EFrmHelper testFRegistry;
			private testE2EFrmHelper testFRegistryCf;
			public void registerTestForm(Form form) {
				if (form.Name == "Frm_registry_anagrafica") {
					testFRegistry = new testE2EFrmHelper(form);
					testFRegistry.ctrl.DoMainCommand("maininsert");
					testFRegistry.ctrl.DontWarnOnInsertCancel = true;
					Assert.IsTrue(testFRegistry.ctrl.InsertMode);
					Assert.IsTrue(testFRegistry.ctrl.DrawStateIsDone);
					Assert.IsTrue(testFRegistry.ctrl.formInited);

					Application.DoEvents();


				}
				Application.DoEvents();
			}

			public void testchildFormVisibility(Form form) {
				testFRegistryCf = new testE2EFrmHelper(form);
				//MessageBox.Show("stop");
				Assert.IsNotNull(testFRegistryCf);
				Assert.IsTrue(testFRegistryCf.f.Visible);
				Assert.AreEqual("registrycf", testFRegistryCf.meta.TableName);
				testFRegistryCf.ctrl.DontWarnOnInsertCancel = true;
				testFRegistryCf.ctrl.DoMainCommand("maindelete");
				Application.DoEvents();
				Assert.AreEqual(testFRegistryCf.f.DialogResult, DialogResult.Cancel);
				Assert.AreEqual(0, testFRegistry.f.OwnedForms.Length);
			}


			[TestMethod]
			public void testChildFormRegistryCf() {
				testFRegistry.ctrl.DoMainCommand("maininsert");
				var ctrlInsertCf = testFRegistry.findByName("button3");
				Button btnlInsertCf = ctrlInsertCf as Button;
				Assert.IsTrue(!btnlInsertCf.Enabled, "Button inizialmente non abilitato");
	 
				//testFRegistry.clickByName("button3");
				//Assert.IsTrue(!testE2EFrmHelper.hasBeenInvoked("registrycf", "default"));
				testFRegistry.closeForm();

			}

		}
		[TestClass]
		public class registryvisura {
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
				testE2EFrmHelper.registerFormTest("registry", "anagrafica", registerTestForm);
				testE2EFrmHelper.registerFormTest("registryvisura", "anagraficadetail", testchildFormVisibility);
				mainTester.openFromMenu("registry", "anagrafica");
			}

			private testE2EFrmHelper testFRegistry;
			private testE2EFrmHelper testFRegistryVisura;
			public void registerTestForm(Form form) {
				if (form.Name == "Frm_registry_anagrafica") {
					testFRegistry = new testE2EFrmHelper(form);
					testFRegistry.ctrl.DoMainCommand("maininsert");
					testFRegistry.ctrl.DontWarnOnInsertCancel = true;
					Assert.IsTrue(testFRegistry.ctrl.InsertMode);
					Assert.IsTrue(testFRegistry.ctrl.DrawStateIsDone);
					Assert.IsTrue(testFRegistry.ctrl.formInited);

					Application.DoEvents();


				}
				Application.DoEvents();
			}

			public void testchildFormVisibility(Form form) {

				testFRegistryVisura = new testE2EFrmHelper(form);
				//MessageBox.Show("stop");
				Assert.IsNotNull(testFRegistryVisura);
				Assert.IsTrue(testFRegistryVisura.f.Visible);
				Assert.AreEqual("registryvisura", testFRegistryVisura.meta.TableName);
				testFRegistryVisura.ctrl.DontWarnOnInsertCancel = true;
				testFRegistryVisura.ctrl.DoMainCommand("maindelete");
				Application.DoEvents();
				Assert.AreEqual(testFRegistryVisura.f.DialogResult, DialogResult.Cancel);
				Assert.AreEqual(0, testFRegistry.f.OwnedForms.Length);
			}


			[TestMethod]
			public void testChildFormRegistryVisura() {
				testFRegistry.ctrl.DoMainCommand("maininsert");
				var ctrlInsertVisura= testFRegistry.findByName("btnInsAtt");
				Button btnlInsertVisura = ctrlInsertVisura as Button;
				Assert.IsTrue(btnlInsertVisura.Enabled, "Button inizialmente abilitato");
				testFRegistry.clickByName("button19");
				Assert.IsTrue(testE2EFrmHelper.hasBeenInvoked("registryvisura", "anagraficadetail"));

			}

		}
	}
}
