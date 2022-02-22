
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
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DBConn;
using metadatalibrary;
using TestHelper;
using q = metadatalibrary.MetaExpression;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using funzioni_configurazione;

namespace e2e {
	/// <summary>
	/// Summary description for test_OpiSiopePlus
	/// </summary>
	///
	[TestClass]
    public class test_OpiSiopePlus {
		private TestContext testContextInstance;
		static DataAccess conn;
		static QueryHelper QHS;
		static int esercizioCorrente;
		static DateTime dataContabileCorrente;
		#region Gestione della Classe (Init + Cleanup)

		[ClassInitialize]
		public static void testInit(TestContext tc) {


			esercizioCorrente = DateTime.Now.Year;
			dataContabileCorrente = DateTime.Now;

			//Nino: il nome del DSN deve essrre generico altrimenti diventa fuorviante se poi ognuno collega un db diverso
			conn = DbConn.getEasyAccess(esercizioCorrente, dataContabileCorrente, "sample");

			if (conn == null) {
				return;
			}

			QHS = conn.GetQueryHelper();

		}

		[ClassCleanup]
		public static void testEnd() {
			conn.Destroy();
		}

		#endregion



		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

		#region Additional test attributes

		//
		// You can use the following additional attributes as you write your tests:
		//
		// Use ClassInitialize to run code before running the first test in the class
		// [ClassInitialize()]
		// public static void MyClassInitialize(TestContext testContext) { }
		//
		// Use ClassCleanup to run code after all tests in a class have run
		// [ClassCleanup()]
		// public static void MyClassCleanup() { }
		//
		// Use TestInitialize to run code before running each test 
		// [TestInitialize()]
		// public void MyTestInitialize() { }
		//
		// Use TestCleanup to run code after each test has run
		// [TestCleanup()]
		// public void MyTestCleanup() { }
		//

		#endregion


		//// Lancia le sp da testare 
		 
		[TestMethod]
		public void Test_2019_mandati_ins_79_35() {
			string spName = "trasmele_expense_opisiopeplus_ins";
			string spErrMess;

			int spTimeOut;
			spTimeOut = 1;
			object npaymenttransmission = 79;
			object ndoc = 35;
			// Recupera i parametri da passare alla sp
			object[] spParams = {2019,npaymenttransmission};

			// Lancia le sp da testare 
			DataSet retDS = conn.CallSP(spName, spParams, spTimeOut*60, out spErrMess);
			Assert.IsNull(spErrMess, $"SP: {spName}. Errore: {spErrMess}");
			Assert.IsNotNull(retDS, $"SP: {spName}. DataSet di ritorno è null");
			DataTable T = retDS.Tables[0];
			//q filterClassFatturaSiope = q.eq("kind", "CLASSIFICAZIONI_FATTURASIOPE") & q.eq("ndoc", ndoc) & q.eq("idpay", 1);
			//var rClassFS = T._First(filterClassFatturaSiope);
 
			Assert.AreEqual(T.Rows[3]["codice_cgu"], "1030202001", " CLASSIFICAZIONI_FATTURASIOPE codice_cgu ok");
			Assert.AreEqual(T.Rows[3]["tipo_debito_siope"] , "COMMERCIALE", " CLASSIFICAZIONI_FATTURASIOPEtipo_debito_siope ok");
			Assert.AreEqual(T.Rows[3]["codice_cig_siope"] , "Z7425ED061", " CLASSIFICAZIONI_FATTURASIOPE codice_cig_siope ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[3]["importo_siope"]) , CfgFn.GetNoNullDecimal(121.50), "CLASSIFICAZIONI_FATTURASIOPE importo_siope ok");
			Assert.AreEqual(T.Rows[3]["natura_spesa_siope"], "CORRENTE", "CLASSIFICAZIONI_FATTURASIOPE natura_spesa_siope ok");
			Assert.AreEqual(T.Rows[3]["motivo_scadenza_siope"], "CORRETTA_SCAD_FATTURA", "CLASSIFICAZIONI_FATTURASIOPE motivo_scadenza_siope ok");

			//q filterClassificazioni = q.eq("kind", "CLASSIFICAZIONI") & q.eq("ndoc", ndoc) & q.eq("idpay", 1);
			//var rClass = T._First(filterClassificazioni);
			Assert.AreEqual(T.Rows[9]["codice_cgu"] , "1030202001", "CLASSIFICAZIONI codice_cgu ok");
			Assert.AreEqual(T.Rows[9]["tipo_debito_siope"] ,"COMMERCIALE", "CLASSIFICAZIONI tipo_debito_siope ok");
			Assert.AreEqual(T.Rows[9]["codice_cig_siope"], "Z7425ED061", "CLASSIFICAZIONI codice_cig_siope ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[9]["importoclassificazionemov"]), CfgFn.GetNoNullDecimal(121.50), "CLASSIFICAZIONI importoclassificazionemov ok");
	 
			 
		}

		[TestMethod]
		public void Test_2019_mandati_ins_80_5() {
			string spName = "trasmele_expense_opisiopeplus_ins";
			string spErrMess;

			int spTimeOut;
			spTimeOut = 1;
			object npaymenttransmission = 80;
			object ndoc = 5;
			// Recupera i parametri da passare alla sp
			object[] spParams = { 2019, npaymenttransmission};

			// Lancia le sp da testare 
			DataSet retDS = conn.CallSP(spName, spParams, spTimeOut*60, out spErrMess);
			Assert.IsNull(spErrMess, $"SP: {spName}. Errore: {spErrMess}");
			Assert.IsNotNull(retDS, $"SP: {spName}. DataSet di ritorno è null");
			DataTable T = retDS.Tables[0];
			//q filterClassFatturaSiope = q.eq("kind", "CLASSIFICAZIONI_FATTURASIOPE") & q.eq("ndoc", ndoc) & q.eq("idpay", 1);
			//var rClassFS = T._First(filterClassFatturaSiope);
 
			Assert.AreEqual(T.Rows[3]["codice_cgu"], "1030211008", " CLASSIFICAZIONI_FATTURASIOPE codice_cgu ok");
			Assert.AreEqual(T.Rows[3]["tipo_debito_siope"], "COMMERCIALE", " CLASSIFICAZIONI_FATTURASIOPEtipo_debito_siope ok");
			Assert.AreEqual(T.Rows[3]["codice_cig_siope"], "Z8A25B04C8", " CLASSIFICAZIONI_FATTURASIOPE codice_cig_siope ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[3]["importo_siope"]), CfgFn.GetNoNullDecimal(4060.16), "CLASSIFICAZIONI_FATTURASIOPE importo_siope ok");
			Assert.AreEqual(T.Rows[3]["natura_spesa_siope"], "CORRENTE", "CLASSIFICAZIONI_FATTURASIOPE natura_spesa_siope ok");
			Assert.AreEqual(T.Rows[3]["motivo_scadenza_siope"], "CORRETTA_SCAD_FATTURA", "CLASSIFICAZIONI_FATTURASIOPE motivo_scadenza_siope ok");

			//q filterClassificazioni = q.eq("kind", "CLASSIFICAZIONI") & q.eq("ndoc", ndoc) & q.eq("idpay", 1);
			//var rClass = T._First(filterClassificazioni);
			Assert.AreEqual(T.Rows[5]["codice_cgu"], "1030211008", "CLASSIFICAZIONI codice_cgu ok");
			Assert.AreEqual(T.Rows[5]["tipo_debito_siope"], "COMMERCIALE", "CLASSIFICAZIONI tipo_debito_siope ok");
			Assert.AreEqual(T.Rows[5]["codice_cig_siope"], "Z8A25B04C8", "CLASSIFICAZIONI codice_cig_siope ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[5]["importoclassificazionemov"]), CfgFn.GetNoNullDecimal(4060.16), "CLASSIFICAZIONI importoclassificazionemov ok");
 	 
		}

		[TestMethod]
		public void Test_2019_mandati_ins_82_34() {
			string spName = "trasmele_expense_opisiopeplus_ins";
			string spErrMess;

			int spTimeOut;
			spTimeOut = 1;
			object npaymenttransmission = 82;
			object ndoc = 34;
			// Recupera i parametri da passare alla sp
			object[] spParams = { 2019, npaymenttransmission};

			// Lancia le sp da testare 
			DataSet retDS = conn.CallSP(spName, spParams, spTimeOut*60, out spErrMess);
			Assert.IsNull(spErrMess, $"SP: {spName}. Errore: {spErrMess}");
			Assert.IsNotNull(retDS, $"SP: {spName}. DataSet di ritorno è null");
			DataTable T = retDS.Tables[0];
			//q filterClassFatturaSiope = q.eq("kind", "CLASSIFICAZIONI_FATTURASIOPE") & q.eq("ndoc", ndoc) & q.eq("idpay", 1);
			//var rClassFS = T._First(filterClassFatturaSiope);

			Assert.AreEqual(T.Rows[3]["codice_cgu"], "1030202001", " CLASSIFICAZIONI_FATTURASIOPE codice_cgu ok");
			Assert.AreEqual(T.Rows[3]["tipo_debito_siope"], "COMMERCIALE", " CLASSIFICAZIONI_FATTURASIOPEtipo_debito_siope ok");
			Assert.AreEqual(T.Rows[3]["codice_cig_siope"], "Z6725ECAEA", " CLASSIFICAZIONI_FATTURASIOPE codice_cig_siope ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[3]["importo_siope"]), CfgFn.GetNoNullDecimal(61.75), "CLASSIFICAZIONI_FATTURASIOPE importo_siope ok");
			Assert.AreEqual(T.Rows[3]["natura_spesa_siope"], "CORRENTE", "CLASSIFICAZIONI_FATTURASIOPE natura_spesa_siope ok");
			Assert.AreEqual(T.Rows[3]["motivo_scadenza_siope"], "CORRETTA_SCAD_FATTURA", "CLASSIFICAZIONI_FATTURASIOPE motivo_scadenza_siope ok");

			Assert.AreEqual(T.Rows[5]["codice_cgu"], "1030216999", "CLASSIFICAZIONI_FATTURASIOPE codice_cgu ok");
			Assert.AreEqual(T.Rows[5]["tipo_debito_siope"], "COMMERCIALE", "CLASSIFICAZIONI_FATTURASIOPE tipo_debito_siope ok");
			Assert.AreEqual(T.Rows[5]["codice_cig_siope"], "Z6725ECAEA", "CLASSIFICAZIONI_FATTURASIOPE codice_cig_siope ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[5]["importo_siope"]), CfgFn.GetNoNullDecimal(48.80), "CLASSIFICAZIONI_FATTURASIOPE importo_siope ok");
			Assert.AreEqual(T.Rows[5]["natura_spesa_siope"], "CORRENTE", "CLASSIFICAZIONI_FATTURASIOPE natura_spesa_siope ok");


			//q filterClassificazioni = q.eq("kind", "CLASSIFICAZIONI") & q.eq("ndoc", ndoc) & q.eq("idpay", 1);
			//var rClass = T._First(filterClassificazioni);
			Assert.AreEqual(T.Rows[9]["codice_cgu"], "1030202001", "CLASSIFICAZIONI codice_cgu ok");
			Assert.AreEqual(T.Rows[9]["tipo_debito_siope"], "COMMERCIALE", "CLASSIFICAZIONI tipo_debito_siope ok");
			Assert.AreEqual(T.Rows[9]["codice_cig_siope"], "Z6725ECAEA", "CLASSIFICAZIONI codice_cig_siope ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[9]["importoclassificazionemov"]), CfgFn.GetNoNullDecimal(61.75), "CLASSIFICAZIONI importoclassificazionemov ok");
		 
			Assert.AreEqual(T.Rows[11]["codice_cgu"], "1030216999", "CLASSIFICAZIONI codice_cgu ok");
			Assert.AreEqual(T.Rows[11]["tipo_debito_siope"], "COMMERCIALE", "CLASSIFICAZIONI tipo_debito_siope ok");
			Assert.AreEqual(T.Rows[11]["codice_cig_siope"], "Z6725ECAEA", "CLASSIFICAZIONI codice_cig_siope ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[11]["importoclassificazionemov"]), CfgFn.GetNoNullDecimal(48.80), "CLASSIFICAZIONI importoclassificazionemov ok");
			 
		}

		[TestMethod]
		public void Test_2019_mandati_ins_85_158() {
			string spName = "trasmele_expense_opisiopeplus_ins";
			string spErrMess;

			int spTimeOut;
			spTimeOut = 1;
			object npaymenttransmission = 85;
			object ndoc = 158;
			// Recupera i parametri da passare alla sp
			object[] spParams = { 2019, npaymenttransmission};

			// Lancia le sp da testare 
			DataSet retDS = conn.CallSP(spName, spParams, spTimeOut*60, out spErrMess);
			Assert.IsNull(spErrMess, $"SP: {spName}. Errore: {spErrMess}");
			Assert.IsNotNull(retDS, $"SP: {spName}. DataSet di ritorno è null");
			DataTable T = retDS.Tables[0];
			//q filterClassFatturaSiope = q.eq("kind", "CLASSIFICAZIONI_FATTURASIOPE") & q.eq("ndoc", ndoc) & q.eq("idpay", 1);
			//var rClassFS = T._First(filterClassFatturaSiope);

			
			Assert.AreEqual(T.Rows[3]["codice_cgu"], "1030102007", " CLASSIFICAZIONI_FATTURASIOPE codice_cgu ok");
			Assert.AreEqual(T.Rows[3]["tipo_debito_siope"], "COMMERCIALE", " CLASSIFICAZIONI_FATTURASIOPEtipo_debito_siope ok");
			Assert.AreEqual(T.Rows[3]["codice_cig_siope"], "ZDB267A992", " CLASSIFICAZIONI_FATTURASIOPE codice_cig_siope ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[3]["importo_siope"]), CfgFn.GetNoNullDecimal(251.32), "CLASSIFICAZIONI_FATTURASIOPE importo_siope ok");
			Assert.AreEqual(T.Rows[3]["natura_spesa_siope"], "CORRENTE", "CLASSIFICAZIONI_FATTURASIOPE natura_spesa_siope ok");
			Assert.AreEqual(T.Rows[3]["motivo_scadenza_siope"], "CORRETTA_SCAD_FATTURA", "CLASSIFICAZIONI_FATTURASIOPE motivo_scadenza_siope ok");

			//q filterClassificazioni = q.eq("kind", "CLASSIFICAZIONI") & q.eq("ndoc", ndoc) & q.eq("idpay", 1);
			//var rClass = T._First(filterClassificazioni);
			Assert.AreEqual(T.Rows[5]["codice_cgu"], "1030102007", "CLASSIFICAZIONI codice_cgu ok");
			Assert.AreEqual(T.Rows[5]["tipo_debito_siope"], "COMMERCIALE", "CLASSIFICAZIONI tipo_debito_siope ok");
			Assert.AreEqual(T.Rows[5]["codice_cig_siope"], "ZDB267A992", "CLASSIFICAZIONI codice_cig_siope ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[5]["importoclassificazionemov"]), CfgFn.GetNoNullDecimal(251.32), "CLASSIFICAZIONI importoclassificazionemov ok");
 
		}

		[TestMethod]
		public void Test_2019_mandati_ins_87_198() {
			string spName = "trasmele_expense_opisiopeplus_ins";
			string spErrMess;

			int spTimeOut;
			spTimeOut = 1;
			object npaymenttransmission = 87;
			object ndoc = 198;
			// Recupera i parametri da passare alla sp
			object[] spParams = { 2019, npaymenttransmission};

			// Lancia le sp da testare 
			DataSet retDS = conn.CallSP(spName, spParams, spTimeOut*60, out spErrMess);
			Assert.IsNull(spErrMess, $"SP: {spName}. Errore: {spErrMess}");
			Assert.IsNotNull(retDS, $"SP: {spName}. DataSet di ritorno è null");
			DataTable T = retDS.Tables[0];
			//q filterClassFatturaSiope = q.eq("kind", "CLASSIFICAZIONI_FATTURASIOPE") & q.eq("ndoc", ndoc) & q.eq("idpay", 1);
			//var rClassFS = T._First(filterClassFatturaSiope);

			Assert.AreEqual(T.Rows[3]["codice_cgu"], "1020102001", " CLASSIFICAZIONI_FATTURASIOPE codice_cgu ok");
			Assert.AreEqual(T.Rows[3]["tipo_debito_siope"], "COMMERCIALE", " CLASSIFICAZIONI_FATTURASIOPEtipo_debito_siope ok");
			Assert.AreEqual(T.Rows[3]["codice_cig_siope"], "ZD921C7973", " CLASSIFICAZIONI_FATTURASIOPE codice_cig_siope ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[3]["importo_siope"]), CfgFn.GetNoNullDecimal(2.00), "CLASSIFICAZIONI_FATTURASIOPE importo_siope ok");
			Assert.AreEqual(T.Rows[3]["natura_spesa_siope"], "CORRENTE", "CLASSIFICAZIONI_FATTURASIOPE natura_spesa_siope ok");
			Assert.AreEqual(T.Rows[3]["motivo_scadenza_siope"], "CORRETTA_SCAD_FATTURA", "CLASSIFICAZIONI_FATTURASIOPE motivo_scadenza_siope ok");

			Assert.AreEqual(T.Rows[4]["codice_cgu"], "1030212001", " CLASSIFICAZIONI_FATTURASIOPE codice_cgu ok");
			Assert.AreEqual(T.Rows[4]["tipo_debito_siope"], "COMMERCIALE", " CLASSIFICAZIONI_FATTURASIOPEtipo_debito_siope ok");
			Assert.AreEqual(T.Rows[4]["codice_cig_siope"], "ZD921C7973", " CLASSIFICAZIONI_FATTURASIOPE codice_cig_siope ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[4]["importo_siope"]), CfgFn.GetNoNullDecimal(1945.40), "CLASSIFICAZIONI_FATTURASIOPE importo_siope ok");
			Assert.AreEqual(T.Rows[4]["natura_spesa_siope"], "CORRENTE", "CLASSIFICAZIONI_FATTURASIOPE natura_spesa_siope ok");
			Assert.AreEqual(T.Rows[4]["motivo_scadenza_siope"], "CORRETTA_SCAD_FATTURA", "CLASSIFICAZIONI_FATTURASIOPE motivo_scadenza_siope ok");

			//q filterClassificazioni = q.eq("kind", "CLASSIFICAZIONI") & q.eq("ndoc", ndoc) & q.eq("idpay", 1);
			//var rClass = T._First(filterClassificazioni);
			Assert.AreEqual(T.Rows[7]["codice_cgu"], "1020102001", "CLASSIFICAZIONI codice_cgu ok");
			Assert.AreEqual(T.Rows[7]["tipo_debito_siope"], "COMMERCIALE", "CLASSIFICAZIONI tipo_debito_siope ok");
			Assert.AreEqual(T.Rows[7]["codice_cig_siope"], "ZD921C7973", "CLASSIFICAZIONI codice_cig_siope ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[7]["importoclassificazionemov"]), CfgFn.GetNoNullDecimal(2.00), "CLASSIFICAZIONI importoclassificazionemov ok");

			Assert.AreEqual(T.Rows[8]["codice_cgu"], "1030212001", "CLASSIFICAZIONI codice_cgu ok");
			Assert.AreEqual(T.Rows[8]["tipo_debito_siope"], "COMMERCIALE", "CLASSIFICAZIONI tipo_debito_siope ok");
			Assert.AreEqual(T.Rows[8]["codice_cig_siope"], "ZD921C7973", "CLASSIFICAZIONI codice_cig_siope ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[8]["importoclassificazionemov"]), CfgFn.GetNoNullDecimal(1945.40), "CLASSIFICAZIONI importoclassificazionemov ok");

		}


		[TestMethod]
		public void Test_2019_mandati_ins_89_41() {
			string spName = "trasmele_expense_opisiopeplus_ins";
			string spErrMess;

			int spTimeOut;
			spTimeOut = 1;
			object npaymenttransmission = 89;
			object ndoc = 41;
			// Recupera i parametri da passare alla sp
			object[] spParams = { 2019, npaymenttransmission};

			// Lancia le sp da testare 
			DataSet retDS = conn.CallSP(spName, spParams, spTimeOut*60, out spErrMess);
			Assert.IsNull(spErrMess, $"SP: {spName}. Errore: {spErrMess}");
			Assert.IsNotNull(retDS, $"SP: {spName}. DataSet di ritorno è null");
			DataTable T = retDS.Tables[0];
			//q filterClassFatturaSiope = q.eq("kind", "CLASSIFICAZIONI_FATTURASIOPE") & q.eq("ndoc", ndoc) & q.eq("idpay", 1);
			//var rClassFS = T._First(filterClassFatturaSiope);

			Assert.AreEqual(T.Rows[3]["codice_cgu"], "1030219007", " CLASSIFICAZIONI_FATTURASIOPE codice_cgu ok");
			Assert.AreEqual(T.Rows[3]["tipo_debito_siope"], "COMMERCIALE", " CLASSIFICAZIONI_FATTURASIOPEtipo_debito_siope ok");
			Assert.AreEqual(T.Rows[3]["codice_cig_siope"], "Z6F2637166", " CLASSIFICAZIONI_FATTURASIOPE codice_cig_siope ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[3]["importo_siope"]), CfgFn.GetNoNullDecimal(8979.20), "CLASSIFICAZIONI_FATTURASIOPE importo_siope ok");
			Assert.AreEqual(T.Rows[3]["natura_spesa_siope"], "CAPITALE", "CLASSIFICAZIONI_FATTURASIOPE natura_spesa_siope ok");
			Assert.AreEqual(T.Rows[3]["motivo_scadenza_siope"], "CORRETTA_SCAD_FATTURA", "CLASSIFICAZIONI_FATTURASIOPE motivo_scadenza_siope ok");

			//q filterClassificazioni = q.eq("kind", "CLASSIFICAZIONI") & q.eq("ndoc", ndoc) & q.eq("idpay", 1);
			//var rClass = T._First(filterClassificazioni);
			Assert.AreEqual(T.Rows[5]["codice_cgu"], "1030219007", "CLASSIFICAZIONI codice_cgu ok");
			Assert.AreEqual(T.Rows[5]["tipo_debito_siope"], "COMMERCIALE", "CLASSIFICAZIONI tipo_debito_siope ok");
			Assert.AreEqual(T.Rows[5]["codice_cig_siope"], "Z6F2637166", "CLASSIFICAZIONI codice_cig_siope ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[5]["importoclassificazionemov"]), CfgFn.GetNoNullDecimal(8979.20), "CLASSIFICAZIONI importoclassificazionemov ok");
		 
		}

		[TestMethod]
		public void Test_2019_mandati_ins_91_129() {
			string spName = "trasmele_expense_opisiopeplus_ins";
			string spErrMess;

			int spTimeOut;
			spTimeOut = 1;
			object npaymenttransmission = 91;
			object ndoc = 129;
			// Recupera i parametri da passare alla sp
			object[] spParams = { 2019, npaymenttransmission};

			// Lancia le sp da testare 
			DataSet retDS = conn.CallSP(spName, spParams, spTimeOut*60, out spErrMess);
			Assert.IsNull(spErrMess, $"SP: {spName}. Errore: {spErrMess}");
			Assert.IsNotNull(retDS, $"SP: {spName}. DataSet di ritorno è null");
			DataTable T = retDS.Tables[0];
			//q filterClassFatturaSiope = q.eq("kind", "CLASSIFICAZIONI_FATTURASIOPE") & q.eq("ndoc", ndoc) & q.eq("idpay", 1);
			//var rClassFS = T._First(filterClassFatturaSiope);

			Assert.AreEqual(T.Rows[3]["codice_cgu"], "1030299999", " CLASSIFICAZIONI_FATTURASIOPE codice_cgu ok");
			Assert.AreEqual(T.Rows[3]["tipo_debito_siope"], "COMMERCIALE", " CLASSIFICAZIONI_FATTURASIOPEtipo_debito_siope ok");
			Assert.AreEqual(T.Rows[3]["codice_cig_siope"], "Z3226071EB", " CLASSIFICAZIONI_FATTURASIOPE codice_cig_siope ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[3]["importo_siope"]), CfgFn.GetNoNullDecimal(37057.50), "CLASSIFICAZIONI_FATTURASIOPE importo_siope ok");
			Assert.AreEqual(T.Rows[3]["natura_spesa_siope"], "CORRENTE", "CLASSIFICAZIONI_FATTURASIOPE natura_spesa_siope ok");
			Assert.AreEqual(T.Rows[3]["motivo_scadenza_siope"], "CORRETTA_SCAD_FATTURA", "CLASSIFICAZIONI_FATTURASIOPE motivo_scadenza_siope ok");

			//q filterClassificazioni = q.eq("kind", "CLASSIFICAZIONI") & q.eq("ndoc", ndoc) & q.eq("idpay", 1);
			//var rClass = T._First(filterClassificazioni);
			Assert.AreEqual(T.Rows[5]["codice_cgu"], "1030299999", "CLASSIFICAZIONI codice_cgu ok");
			Assert.AreEqual(T.Rows[5]["tipo_debito_siope"], "COMMERCIALE", "CLASSIFICAZIONI tipo_debito_siope ok");
			Assert.AreEqual(T.Rows[5]["codice_cig_siope"], "Z3226071EB", "CLASSIFICAZIONI codice_cig_siope ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[5]["importoclassificazionemov"]), CfgFn.GetNoNullDecimal(37057.50), "CLASSIFICAZIONI importoclassificazionemov ok");

		}


		[TestMethod]
		public void Test_2019_mandati_ins_93_125() {
			string spName = "trasmele_expense_opisiopeplus_ins";
			string spErrMess;

			int spTimeOut;
			spTimeOut = 1;
			object npaymenttransmission = 93;
			object ndoc = 125;
			// Recupera i parametri da passare alla sp
			object[] spParams = { 2019, npaymenttransmission};

			// Lancia le sp da testare 
			DataSet retDS = conn.CallSP(spName, spParams, spTimeOut*60, out spErrMess);
			Assert.IsNull(spErrMess, $"SP: {spName}. Errore: {spErrMess}");
			Assert.IsNotNull(retDS, $"SP: {spName}. DataSet di ritorno è null");
			DataTable T = retDS.Tables[0];
			//q filterClassFatturaSiope = q.eq("kind", "CLASSIFICAZIONI_FATTURASIOPE") & q.eq("ndoc", ndoc) & q.eq("idpay", 1);
			//var rClassFS = T._First(filterClassFatturaSiope);

			Assert.AreEqual(T.Rows[4]["codice_cgu"], "1030213001", " CLASSIFICAZIONI_FATTURASIOPE codice_cgu ok");
			Assert.AreEqual(T.Rows[4]["tipo_debito_siope"], "COMMERCIALE", " CLASSIFICAZIONI_FATTURASIOPEtipo_debito_siope ok");
			Assert.AreEqual(T.Rows[4]["codice_cig_siope"], "Z3A22E48EA", " CLASSIFICAZIONI_FATTURASIOPE codice_cig_siope ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[4]["importo_siope"]), CfgFn.GetNoNullDecimal(880.35), "CLASSIFICAZIONI_FATTURASIOPE importo_siope ok");
			Assert.AreEqual(T.Rows[4]["natura_spesa_siope"], "CORRENTE", "CLASSIFICAZIONI_FATTURASIOPE natura_spesa_siope ok");
			Assert.AreEqual(T.Rows[4]["motivo_scadenza_siope"], "CORRETTA_SCAD_FATTURA", "CLASSIFICAZIONI_FATTURASIOPE motivo_scadenza_siope ok");
			
			Assert.AreEqual(T.Rows[5]["codice_cgu"], "1030213001", " CLASSIFICAZIONI_FATTURASIOPE codice_cgu ok");
			Assert.AreEqual(T.Rows[5]["tipo_debito_siope"], "COMMERCIALE", " CLASSIFICAZIONI_FATTURASIOPEtipo_debito_siope ok");
			Assert.AreEqual(T.Rows[5]["codice_cig_siope"], "Z3A22E48EA", " CLASSIFICAZIONI_FATTURASIOPE codice_cig_siope ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[5]["importo_siope"]), CfgFn.GetNoNullDecimal(739.81), "CLASSIFICAZIONI_FATTURASIOPE importo_siope ok");
			Assert.AreEqual(T.Rows[5]["natura_spesa_siope"], "CORRENTE", "CLASSIFICAZIONI_FATTURASIOPE natura_spesa_siope ok");
			Assert.AreEqual(T.Rows[5]["motivo_scadenza_siope"], "CORRETTA_SCAD_FATTURA", "CLASSIFICAZIONI_FATTURASIOPE motivo_scadenza_siope ok");

			//q filterClassificazioni = q.eq("kind", "CLASSIFICAZIONI") & q.eq("ndoc", ndoc) & q.eq("idpay", 1);
			//var rClass = T._First(filterClassificazioni);
			Assert.AreEqual(T.Rows[7]["codice_cgu"], "1030213001", "CLASSIFICAZIONI codice_cgu ok");
			Assert.AreEqual(T.Rows[7]["tipo_debito_siope"], "COMMERCIALE", "CLASSIFICAZIONI tipo_debito_siope ok");
			Assert.AreEqual(T.Rows[7]["codice_cig_siope"], "Z3A22E48EA", "CLASSIFICAZIONI codice_cig_siope ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[7]["importoclassificazionemov"]), CfgFn.GetNoNullDecimal(880.35), "CLASSIFICAZIONI importoclassificazionemov ok");

			Assert.AreEqual(T.Rows[8]["codice_cgu"], "1030213001", "CLASSIFICAZIONI codice_cgu ok");
			Assert.AreEqual(T.Rows[8]["tipo_debito_siope"], "COMMERCIALE", "CLASSIFICAZIONI tipo_debito_siope ok");
			Assert.AreEqual(T.Rows[8]["codice_cig_siope"], "Z3A22E48EA", "CLASSIFICAZIONI codice_cig_siope ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[8]["importoclassificazionemov"]), CfgFn.GetNoNullDecimal(739.81), "CLASSIFICAZIONI importoclassificazionemov ok");

		}

		[TestMethod]
		public void Test_2019_mandati_ins_97_1296() {
			string spName = "trasmele_expense_opisiopeplus_ins";
			string spErrMess;

			int spTimeOut;
			spTimeOut = 1;
			object npaymenttransmission = 97;
			object ndoc = 1296;
			// Recupera i parametri da passare alla sp
			object[] spParams = { 2019, npaymenttransmission};

			// Lancia le sp da testare 
			DataSet retDS = conn.CallSP(spName, spParams, spTimeOut*60, out spErrMess);
			Assert.IsNull(spErrMess, $"SP: {spName}. Errore: {spErrMess}");
			Assert.IsNotNull(retDS, $"SP: {spName}. DataSet di ritorno è null");
			DataTable T = retDS.Tables[0];
			//q filterClassFatturaSiope = q.eq("kind", "CLASSIFICAZIONI_FATTURASIOPE") & q.eq("ndoc", ndoc) & q.eq("idpay", 1);
			//var rClassFS = T._First(filterClassFatturaSiope);
			Assert.AreEqual(T.Rows[3]["codice_cgu"], "1030102003", " CLASSIFICAZIONI_FATTURASIOPE codice_cgu ok");
			Assert.AreEqual(T.Rows[3]["tipo_debito_siope"], "COMMERCIALE", " CLASSIFICAZIONI_FATTURASIOPEtipo_debito_siope ok");
			Assert.AreEqual(T.Rows[3]["codice_cig_siope"], "1234567895", " CLASSIFICAZIONI_FATTURASIOPE codice_cig_siope ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[3]["importo_siope"]), CfgFn.GetNoNullDecimal(1647.00), "CLASSIFICAZIONI_FATTURASIOPE importo_siope ok");
			Assert.AreEqual(T.Rows[3]["natura_spesa_siope"], "CORRENTE", "CLASSIFICAZIONI_FATTURASIOPE natura_spesa_siope ok");
			Assert.AreEqual(T.Rows[3]["motivo_scadenza_siope"], "CORRETTA_SCAD_FATTURA", "CLASSIFICAZIONI_FATTURASIOPE motivo_scadenza_siope ok");

			Assert.AreEqual(T.Rows[4]["codice_cgu"], "1030102003", " CLASSIFICAZIONI_FATTURASIOPE codice_cgu ok");
			Assert.AreEqual(T.Rows[4]["tipo_debito_siope"], "COMMERCIALE", " CLASSIFICAZIONI_FATTURASIOPEtipo_debito_siope ok");
			Assert.AreEqual(T.Rows[4]["codice_cig_siope"], "1234567895", " CLASSIFICAZIONI_FATTURASIOPE codice_cig_siope ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[4]["importo_siope"]), CfgFn.GetNoNullDecimal(-427.00), "CLASSIFICAZIONI_FATTURASIOPE importo_siope ok");
			Assert.AreEqual(T.Rows[4]["natura_spesa_siope"], "CORRENTE", "CLASSIFICAZIONI_FATTURASIOPE natura_spesa_siope ok");
			Assert.AreEqual(T.Rows[4]["motivo_scadenza_siope"], "CORRETTA_SCAD_FATTURA", "CLASSIFICAZIONI_FATTURASIOPE motivo_scadenza_siope ok");

		
			//q filterClassificazioni = q.eq("kind", "CLASSIFICAZIONI") & q.eq("ndoc", ndoc) & q.eq("idpay", 1);
			//var rClass = T._First(filterClassificazioni);
			Assert.AreEqual(T.Rows[6]["codice_cgu"], "1030102003", "CLASSIFICAZIONI codice_cgu ok");
			Assert.AreEqual(T.Rows[6]["tipo_debito_siope"], "COMMERCIALE", "CLASSIFICAZIONI tipo_debito_siope ok");
			Assert.AreEqual(T.Rows[6]["codice_cig_siope"], "1234567895", "CLASSIFICAZIONI codice_cig_siope ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[6]["importoclassificazionemov"]), CfgFn.GetNoNullDecimal(1220.00), "CLASSIFICAZIONI importoclassificazionemov ok");
		}


		[TestMethod]
		public void Test_2019_mandati_ins_105_1302() {
			string spName = "trasmele_expense_opisiopeplus_ins";
			string spErrMess;

			int spTimeOut;
			spTimeOut = 1;
			object npaymenttransmission = 105;
			object ndoc = 1302;
			// Recupera i parametri da passare alla sp
			object[] spParams = { 2019, npaymenttransmission};

			// Lancia le sp da testare 
			DataSet retDS = conn.CallSP(spName, spParams, spTimeOut*60, out spErrMess);
			Assert.IsNull(spErrMess, $"SP: {spName}. Errore: {spErrMess}");
			Assert.IsNotNull(retDS, $"SP: {spName}. DataSet di ritorno è null");
			DataTable T = retDS.Tables[0];
			//q filterClassFatturaSiope = q.eq("kind", "CLASSIFICAZIONI_FATTURASIOPE") & q.eq("ndoc", ndoc) & q.eq("idpay", 1);
			//var rClassFS = T._First(filterClassFatturaSiope);
			Assert.AreEqual(T.Rows[3]["codice_cgu"], "1030102003", " CLASSIFICAZIONI_FATTURASIOPE codice_cgu ok");
			Assert.AreEqual(T.Rows[3]["tipo_debito_siope"], "COMMERCIALE", " CLASSIFICAZIONI_FATTURASIOPEtipo_debito_siope ok");
			Assert.AreEqual(T.Rows[3]["codice_cig_siope"], "ZE325A4AF3", " CLASSIFICAZIONI_FATTURASIOPE codice_cig_siope ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[3]["importo_siope"]), CfgFn.GetNoNullDecimal(384.30), "CLASSIFICAZIONI_FATTURASIOPE importo_siope ok");
			Assert.AreEqual(T.Rows[3]["natura_spesa_siope"], "CORRENTE", "CLASSIFICAZIONI_FATTURASIOPE natura_spesa_siope ok");
			Assert.AreEqual(T.Rows[3]["motivo_scadenza_siope"], "CORRETTA_SCAD_FATTURA", "CLASSIFICAZIONI_FATTURASIOPE motivo_scadenza_siope ok");

			Assert.AreEqual(T.Rows[4]["codice_cgu"], "1030102008", " CLASSIFICAZIONI_FATTURASIOPE codice_cgu ok");
			Assert.AreEqual(T.Rows[4]["tipo_debito_siope"], "COMMERCIALE", " CLASSIFICAZIONI_FATTURASIOPEtipo_debito_siope ok");
			Assert.AreEqual(T.Rows[4]["codice_cig_siope"], "ZE325A4AF3", " CLASSIFICAZIONI_FATTURASIOPE codice_cig_siope ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[4]["importo_siope"]), CfgFn.GetNoNullDecimal(1106.17), "CLASSIFICAZIONI_FATTURASIOPE importo_siope ok");
			Assert.AreEqual(T.Rows[4]["natura_spesa_siope"], "CORRENTE", "CLASSIFICAZIONI_FATTURASIOPE natura_spesa_siope ok");
			Assert.AreEqual(T.Rows[4]["motivo_scadenza_siope"], "CORRETTA_SCAD_FATTURA", "CLASSIFICAZIONI_FATTURASIOPE motivo_scadenza_siope ok");

			Assert.AreEqual(T.Rows[5]["codice_cgu"], "1030102008", " CLASSIFICAZIONI_FATTURASIOPE codice_cgu ok");
			Assert.AreEqual(T.Rows[5]["tipo_debito_siope"], "COMMERCIALE", " CLASSIFICAZIONI_FATTURASIOPEtipo_debito_siope ok");
			Assert.AreEqual(T.Rows[5]["codice_cig_siope"], "ZE325A4AF3", " CLASSIFICAZIONI_FATTURASIOPE codice_cig_siope ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[5]["importo_siope"]), CfgFn.GetNoNullDecimal(-487.74), "CLASSIFICAZIONI_FATTURASIOPE importo_siope ok");
			Assert.AreEqual(T.Rows[5]["natura_spesa_siope"], "CORRENTE", "CLASSIFICAZIONI_FATTURASIOPE natura_spesa_siope ok");
			Assert.AreEqual(T.Rows[5]["motivo_scadenza_siope"], "CORRETTA_SCAD_FATTURA", "CLASSIFICAZIONI_FATTURASIOPE motivo_scadenza_siope ok");

			//q filterClassificazioni = q.eq("kind", "CLASSIFICAZIONI") & q.eq("ndoc", ndoc) & q.eq("idpay", 1);
			//var rClass = T._First(filterClassificazioni);
			Assert.AreEqual(T.Rows[6]["codice_cgu"], "1030102003", "CLASSIFICAZIONI codice_cgu ok");
			Assert.AreEqual(T.Rows[6]["tipo_debito_siope"], "COMMERCIALE", "CLASSIFICAZIONI tipo_debito_siope ok");
			Assert.AreEqual(T.Rows[6]["codice_cig_siope"], "ZE325A4AF3", "CLASSIFICAZIONI codice_cig_siope ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[6]["importoclassificazionemov"]), CfgFn.GetNoNullDecimal(384.30), "CLASSIFICAZIONI importoclassificazionemov ok");
			Assert.AreEqual(T.Rows[7]["codice_cgu"], "1030102008", "CLASSIFICAZIONI codice_cgu ok");
			Assert.AreEqual(T.Rows[7]["tipo_debito_siope"], "COMMERCIALE", "CLASSIFICAZIONI tipo_debito_siope ok");
			Assert.AreEqual(T.Rows[7]["codice_cig_siope"], "ZE325A4AF3", "CLASSIFICAZIONI codice_cig_siope ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[7]["importoclassificazionemov"]), CfgFn.GetNoNullDecimal(618.43), "CLASSIFICAZIONI importoclassificazionemov ok");


		}


		[TestMethod]
		public void Test_2019_mandati_var_84_5() {
			string spName = "trasmele_expense_opisiopeplus_var";
			string spErrMess;

			int spTimeOut;
			spTimeOut = 1;
			object npaymenttransmission = 84;
			object ndoc = 5;
			// Recupera i parametri da passare alla sp
			object[] spParams = { 2019, npaymenttransmission};

			// Lancia le sp da testare 
			DataSet retDS = conn.CallSP(spName, spParams, spTimeOut*60, out spErrMess);
			Assert.IsNull(spErrMess, $"SP: {spName}. Errore: {spErrMess}");
			Assert.IsNotNull(retDS, $"SP: {spName}. DataSet di ritorno è null");
			DataTable T = retDS.Tables[0];
			//q filterClassFatturaSiope = q.eq("kind", "CLASSIFICAZIONI_FATTURASIOPE") & q.eq("ndoc", ndoc) & q.eq("idpay", 1);
			//var rClassFS = T._First(filterClassFatturaSiope);
			Assert.AreEqual(T.Rows[3]["codice_cgu"], "1030211008", " CLASSIFICAZIONI_FATTURASIOPE codice_cgu ok");
			Assert.AreEqual(T.Rows[3]["tipo_debito_siope"], "COMMERCIALE", " CLASSIFICAZIONI_FATTURASIOPEtipo_debito_siope ok");
			Assert.AreEqual(T.Rows[3]["codice_cig_siope"], "Z8A25B04C8", " CLASSIFICAZIONI_FATTURASIOPE codice_cig_siope ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[3]["importo_siope"]), CfgFn.GetNoNullDecimal(4060.16), "CLASSIFICAZIONI_FATTURASIOPE importo_siope ok");
			Assert.AreEqual(T.Rows[3]["natura_spesa_siope"], "CORRENTE", "CLASSIFICAZIONI_FATTURASIOPE natura_spesa_siope ok");
			Assert.AreEqual(T.Rows[3]["motivo_scadenza_siope"], "CORRETTA_SCAD_FATTURA", "CLASSIFICAZIONI_FATTURASIOPE motivo_scadenza_siope ok");
 

			//q filterClassificazioni = q.eq("kind", "CLASSIFICAZIONI") & q.eq("ndoc", ndoc) & q.eq("idpay", 1);
			//var rClass = T._First(filterClassificazioni);
			Assert.AreEqual(T.Rows[5]["codice_cgu"], "1030211008", "CLASSIFICAZIONI codice_cgu ok");
			Assert.AreEqual(T.Rows[5]["tipo_debito_siope"], "COMMERCIALE", "CLASSIFICAZIONI tipo_debito_siope ok");
			Assert.AreEqual(T.Rows[5]["codice_cig_siope"], "Z8A25B04C8", "CLASSIFICAZIONI codice_cig_siope ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[5]["importoclassificazionemov"]), CfgFn.GetNoNullDecimal(4060.16), "CLASSIFICAZIONI importoclassificazionemov ok");
		}



		[TestMethod]
		public void Test_2019_mandati_var_86_158() {
			string spName = "trasmele_expense_opisiopeplus_var";
			string spErrMess;

			int spTimeOut;
			spTimeOut = 1;
			object npaymenttransmission = 86;
			object ndoc = 158;
			// Recupera i parametri da passare alla sp
			object[] spParams = { 2019, npaymenttransmission};

			// Lancia le sp da testare 
			DataSet retDS = conn.CallSP(spName, spParams, spTimeOut*60, out spErrMess);
			Assert.IsNull(spErrMess, $"SP: {spName}. Errore: {spErrMess}");
			Assert.IsNotNull(retDS, $"SP: {spName}. DataSet di ritorno è null");
			DataTable T = retDS.Tables[0];
			//q filterClassFatturaSiope = q.eq("kind", "CLASSIFICAZIONI_FATTURASIOPE") & q.eq("ndoc", ndoc) & q.eq("idpay", 1);
			//var rClassFS = T._First(filterClassFatturaSiope);
			Assert.AreEqual(T.Rows[3]["codice_cgu"], "1030102007", " CLASSIFICAZIONI_FATTURASIOPE codice_cgu ok");
			Assert.AreEqual(T.Rows[3]["tipo_debito_siope"], "COMMERCIALE", " CLASSIFICAZIONI_FATTURASIOPEtipo_debito_siope ok");
			Assert.AreEqual(T.Rows[3]["codice_cig_siope"], "ZDB267A992", " CLASSIFICAZIONI_FATTURASIOPE codice_cig_siope ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[3]["importo_siope"]), CfgFn.GetNoNullDecimal(251.32), "CLASSIFICAZIONI_FATTURASIOPE importo_siope ok");
			Assert.AreEqual(T.Rows[3]["natura_spesa_siope"], "CORRENTE", "CLASSIFICAZIONI_FATTURASIOPE natura_spesa_siope ok");
			Assert.AreEqual(T.Rows[3]["motivo_scadenza_siope"], "CORRETTA_SCAD_FATTURA", "CLASSIFICAZIONI_FATTURASIOPE motivo_scadenza_siope ok");


			//q filterClassificazioni = q.eq("kind", "CLASSIFICAZIONI") & q.eq("ndoc", ndoc) & q.eq("idpay", 1);
			//var rClass = T._First(filterClassificazioni);
			Assert.AreEqual(T.Rows[5]["codice_cgu"], "1030102007", "CLASSIFICAZIONI codice_cgu ok");
			Assert.AreEqual(T.Rows[5]["tipo_debito_siope"], "COMMERCIALE", "CLASSIFICAZIONI tipo_debito_siope ok");
			Assert.AreEqual(T.Rows[5]["codice_cig_siope"], "ZDB267A992", "CLASSIFICAZIONI codice_cig_siope ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[5]["importoclassificazionemov"]), CfgFn.GetNoNullDecimal(251.32), "CLASSIFICAZIONI importoclassificazionemov ok");
		}

        [TestMethod]
        public void Test_2019_mandati_var_106_2019() {
            //Verifica che in cas di var. di annullo totale la sezione ARCONET sia assente
            string spName = "trasmele_expense_opisiopeplus_var";
            string spErrMess;

            int spTimeOut;
            spTimeOut = 1;
            object npaymenttransmission = 106;
            // Recupera i parametri da passare alla sp
            object[] spParams = { 2019, npaymenttransmission};

            // Lancia le sp da testare 
            DataSet retDS = conn.CallSP(spName, spParams, spTimeOut*60, out spErrMess);
            Assert.IsNull(spErrMess, $"SP: {spName}. Errore: {spErrMess}");
            Assert.IsNotNull(retDS, $"SP: {spName}. DataSet di ritorno è null");
            DataTable T = retDS.Tables[0];
            Assert.AreEqual(T.Rows[1]["tipo_operazione"], "ANNULLO", " VAR. ANNULLO TOTALE presente");
            // non esiste la riga ARCONET
            q filterArconet = q.eq("kind", "ARCONET");
            var rArconet = T._First(filterArconet);
            Assert.IsNull(rArconet, "Sezione ARCONET ASSENTE ok");
        }

        [TestMethod]
		public void Test_2019_mandati_var_88_198() {
			string spName = "trasmele_expense_opisiopeplus_var";
			string spErrMess;

			int spTimeOut;
			spTimeOut = 1;
			object npaymenttransmission = 88;
			object ndoc = 198;
			// Recupera i parametri da passare alla sp
			object[] spParams = { 2019, npaymenttransmission};

			// Lancia le sp da testare 
			DataSet retDS = conn.CallSP(spName, spParams, spTimeOut*60, out spErrMess);
			Assert.IsNull(spErrMess, $"SP: {spName}. Errore: {spErrMess}");
			Assert.IsNotNull(retDS, $"SP: {spName}. DataSet di ritorno è null");
			DataTable T = retDS.Tables[0];
			//q filterClassFatturaSiope = q.eq("kind", "CLASSIFICAZIONI_FATTURASIOPE") & q.eq("ndoc", ndoc) & q.eq("idpay", 1);
			//var rClassFS = T._First(filterClassFatturaSiope);
			Assert.AreEqual(T.Rows[3]["codice_cgu"], "1020102001", " CLASSIFICAZIONI_FATTURASIOPE codice_cgu ok");
			Assert.AreEqual(T.Rows[3]["tipo_debito_siope"], "COMMERCIALE", " CLASSIFICAZIONI_FATTURASIOPEtipo_debito_siope ok");
			Assert.AreEqual(T.Rows[3]["codice_cig_siope"], "ZD921C7973", " CLASSIFICAZIONI_FATTURASIOPE codice_cig_siope ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[3]["importo_siope"]), CfgFn.GetNoNullDecimal(2.00), "CLASSIFICAZIONI_FATTURASIOPE importo_siope ok");
			Assert.AreEqual(T.Rows[3]["natura_spesa_siope"], "CORRENTE", "CLASSIFICAZIONI_FATTURASIOPE natura_spesa_siope ok");
			Assert.AreEqual(T.Rows[3]["motivo_scadenza_siope"], "CORRETTA_SCAD_FATTURA", "CLASSIFICAZIONI_FATTURASIOPE motivo_scadenza_siope ok");

			Assert.AreEqual(T.Rows[4]["codice_cgu"], "1030212001", " CLASSIFICAZIONI_FATTURASIOPE codice_cgu ok");
			Assert.AreEqual(T.Rows[4]["tipo_debito_siope"], "COMMERCIALE", " CLASSIFICAZIONI_FATTURASIOPEtipo_debito_siope ok");
			Assert.AreEqual(T.Rows[4]["codice_cig_siope"], "ZD921C7973", " CLASSIFICAZIONI_FATTURASIOPE codice_cig_siope ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[4]["importo_siope"]), CfgFn.GetNoNullDecimal(1945.40), "CLASSIFICAZIONI_FATTURASIOPE importo_siope ok");
			Assert.AreEqual(T.Rows[4]["natura_spesa_siope"], "CORRENTE", "CLASSIFICAZIONI_FATTURASIOPE natura_spesa_siope ok");
			Assert.AreEqual(T.Rows[4]["motivo_scadenza_siope"], "CORRETTA_SCAD_FATTURA", "CLASSIFICAZIONI_FATTURASIOPE motivo_scadenza_siope ok");

			//q filterClassificazioni = q.eq("kind", "CLASSIFICAZIONI") & q.eq("ndoc", ndoc) & q.eq("idpay", 1);
			//var rClass = T._First(filterClassificazioni);
			Assert.AreEqual(T.Rows[7]["codice_cgu"], "1020102001", "CLASSIFICAZIONI codice_cgu ok");
			Assert.AreEqual(T.Rows[7]["tipo_debito_siope"], "COMMERCIALE", "CLASSIFICAZIONI tipo_debito_siope ok");
			Assert.AreEqual(T.Rows[7]["codice_cig_siope"], "ZD921C7973", "CLASSIFICAZIONI codice_cig_siope ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[7]["importoclassificazionemov"]), CfgFn.GetNoNullDecimal(2.00), "CLASSIFICAZIONI importoclassificazionemov ok");

			Assert.AreEqual(T.Rows[8]["codice_cgu"], "1030212001", "CLASSIFICAZIONI codice_cgu ok");
			Assert.AreEqual(T.Rows[8]["tipo_debito_siope"], "COMMERCIALE", "CLASSIFICAZIONI tipo_debito_siope ok");
			Assert.AreEqual(T.Rows[8]["codice_cig_siope"], "ZD921C7973", "CLASSIFICAZIONI codice_cig_siope ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[8]["importoclassificazionemov"]), CfgFn.GetNoNullDecimal(1945.40), "CLASSIFICAZIONI importoclassificazionemov ok");
		}


		[TestMethod]
		public void Test_2019_mandati_var_98_1296() {
			string spName = "trasmele_expense_opisiopeplus_var";
			string spErrMess;

			int spTimeOut;
			spTimeOut = 1;
			object npaymenttransmission = 98;
			object ndoc = 1296;
			// Recupera i parametri da passare alla sp
			object[] spParams = { 2019, npaymenttransmission};

			// Lancia le sp da testare 
			DataSet retDS = conn.CallSP(spName, spParams, spTimeOut*60, out spErrMess);
			Assert.IsNull(spErrMess, $"SP: {spName}. Errore: {spErrMess}");
			Assert.IsNotNull(retDS, $"SP: {spName}. DataSet di ritorno è null");
			DataTable T = retDS.Tables[0];
			//q filterClassFatturaSiope = q.eq("kind", "CLASSIFICAZIONI_FATTURASIOPE") & q.eq("ndoc", ndoc) & q.eq("idpay", 1);
			//var rClassFS = T._First(filterClassFatturaSiope);
			Assert.AreEqual(T.Rows[3]["codice_cgu"], "1030102003", " CLASSIFICAZIONI_FATTURASIOPE codice_cgu ok");
			Assert.AreEqual(T.Rows[3]["tipo_debito_siope"], "COMMERCIALE", " CLASSIFICAZIONI_FATTURASIOPEtipo_debito_siope ok");
			Assert.AreEqual(T.Rows[3]["codice_cig_siope"], "1234567895", " CLASSIFICAZIONI_FATTURASIOPE codice_cig_siope ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[3]["importo_siope"]), CfgFn.GetNoNullDecimal(1647.00), "CLASSIFICAZIONI_FATTURASIOPE importo_siope ok");
			Assert.AreEqual(T.Rows[3]["natura_spesa_siope"], "CORRENTE", "CLASSIFICAZIONI_FATTURASIOPE natura_spesa_siope ok");
			Assert.AreEqual(T.Rows[3]["motivo_scadenza_siope"], "CORRETTA_SCAD_FATTURA", "CLASSIFICAZIONI_FATTURASIOPE motivo_scadenza_siope ok");

			Assert.AreEqual(T.Rows[4]["codice_cgu"], "1030102003", " CLASSIFICAZIONI_FATTURASIOPE codice_cgu ok");
			Assert.AreEqual(T.Rows[4]["tipo_debito_siope"], "COMMERCIALE", " CLASSIFICAZIONI_FATTURASIOPEtipo_debito_siope ok");
			Assert.AreEqual(T.Rows[4]["codice_cig_siope"], "1234567895", " CLASSIFICAZIONI_FATTURASIOPE codice_cig_siope ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[4]["importo_siope"]), CfgFn.GetNoNullDecimal(-427.00), "CLASSIFICAZIONI_FATTURASIOPE importo_siope ok");
			Assert.AreEqual(T.Rows[4]["natura_spesa_siope"], "CORRENTE", "CLASSIFICAZIONI_FATTURASIOPE natura_spesa_siope ok");
			Assert.AreEqual(T.Rows[4]["motivo_scadenza_siope"], "CORRETTA_SCAD_FATTURA", "CLASSIFICAZIONI_FATTURASIOPE motivo_scadenza_siope ok");


			//q filterClassificazioni = q.eq("kind", "CLASSIFICAZIONI") & q.eq("ndoc", ndoc) & q.eq("idpay", 1);
			//var rClass = T._First(filterClassificazioni);
			Assert.AreEqual(T.Rows[6]["codice_cgu"], "1030102003", "CLASSIFICAZIONI codice_cgu ok");
			Assert.AreEqual(T.Rows[6]["tipo_debito_siope"], "COMMERCIALE", "CLASSIFICAZIONI tipo_debito_siope ok");
			Assert.AreEqual(T.Rows[6]["codice_cig_siope"], "1234567895", "CLASSIFICAZIONI codice_cig_siope ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[6]["importoclassificazionemov"]), CfgFn.GetNoNullDecimal(1220.00), "CLASSIFICAZIONI importoclassificazionemov ok");

		}

		[TestMethod]
		public void Test_2019_reversali_ins_1() {
			string spName = "trasmele_income_opisiopeplus_ins";
			string spErrMess;

			int spTimeOut;
			spTimeOut = 1;
			object nproceedstransmission = 1;
			 
			// Recupera i parametri da passare alla sp
			object[] spParams = {2019,nproceedstransmission};

			// Lancia le sp da testare 
			DataSet retDS = conn.CallSP(spName, spParams, spTimeOut*60, out spErrMess);
			Assert.IsNull(spErrMess, $"SP: {spName}. Errore: {spErrMess}");
			Assert.IsNotNull(retDS, $"SP: {spName}. DataSet di ritorno è null");
			DataTable T = retDS.Tables[0];


			//q filterClassFatturaSiope = q.eq("kind", "CLASSIFICAZIONI_FATTURASIOPE") & q.eq("ndoc", ndoc) & q.eq("idpay", 1);
			//var rClassFS = T._First(filterClassFatturaSiope);
			Assert.AreEqual(T.Rows[27]["codice_cge"], "9010102001", " CLASSIFICAZIONI_FATTURASIOPE codice_cgu ok");
			Assert.AreEqual(T.Rows[27]["tipo_debito_siope"], "COMMERCIALE", " CLASSIFICAZIONI_FATTURASIOPEtipo_debito_siope ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[27]["importo_siope"]), CfgFn.GetNoNullDecimal(79.42), "CLASSIFICAZIONI_FATTURASIOPE importo_siope ok");
			Assert.AreEqual(T.Rows[27]["natura_spesa_siope"], "CORRENTE", "CLASSIFICAZIONI_FATTURASIOPE natura_spesa_siope ok");
			Assert.AreEqual(T.Rows[27]["motivo_scadenza_siope"], "CORRETTA_SCAD_FATTURA", "CLASSIFICAZIONI_FATTURASIOPE motivo_scadenza_siope ok");

			Assert.AreEqual(T.Rows[28]["codice_cge"], "9010102001", " CLASSIFICAZIONI_FATTURASIOPE codice_cgu ok");
			Assert.AreEqual(T.Rows[28]["tipo_debito_siope"], "COMMERCIALE", " CLASSIFICAZIONI_FATTURASIOPEtipo_debito_siope ok");
	
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[28]["importo_siope"]), CfgFn.GetNoNullDecimal(145.64), "CLASSIFICAZIONI_FATTURASIOPE importo_siope ok");
			Assert.AreEqual(T.Rows[28]["natura_spesa_siope"], "CORRENTE", "CLASSIFICAZIONI_FATTURASIOPE natura_spesa_siope ok");
			Assert.AreEqual(T.Rows[28]["motivo_scadenza_siope"], "CORRETTA_SCAD_FATTURA", "CLASSIFICAZIONI_FATTURASIOPE motivo_scadenza_siope ok");

			Assert.AreEqual(T.Rows[29]["codice_cge"], "9010102001", " CLASSIFICAZIONI_FATTURASIOPE codice_cgu ok");
			Assert.AreEqual(T.Rows[29]["tipo_debito_siope"], "COMMERCIALE", " CLASSIFICAZIONI_FATTURASIOPEtipo_debito_siope ok");

			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[29]["importo_siope"]), CfgFn.GetNoNullDecimal(179.01), "CLASSIFICAZIONI_FATTURASIOPE importo_siope ok");
			Assert.AreEqual(T.Rows[29]["natura_spesa_siope"], "CORRENTE", "CLASSIFICAZIONI_FATTURASIOPE natura_spesa_siope ok");
			Assert.AreEqual(T.Rows[29]["motivo_scadenza_siope"], "CORRETTA_SCAD_FATTURA", "CLASSIFICAZIONI_FATTURASIOPE motivo_scadenza_siope ok");

			Assert.AreEqual(T.Rows[30]["codice_cge"], "9010102001", " CLASSIFICAZIONI_FATTURASIOPE codice_cgu ok");
			Assert.AreEqual(T.Rows[30]["tipo_debito_siope"], "COMMERCIALE", " CLASSIFICAZIONI_FATTURASIOPEtipo_debito_siope ok");

			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[30]["importo_siope"]), CfgFn.GetNoNullDecimal(305.83), "CLASSIFICAZIONI_FATTURASIOPE importo_siope ok");
			Assert.AreEqual(T.Rows[30]["natura_spesa_siope"], "CAPITALE", "CLASSIFICAZIONI_FATTURASIOPE natura_spesa_siope ok");
			Assert.AreEqual(T.Rows[30]["motivo_scadenza_siope"], "CORRETTA_SCAD_FATTURA", "CLASSIFICAZIONI_FATTURASIOPE motivo_scadenza_siope ok");

			Assert.AreEqual(T.Rows[31]["codice_cge"], "9010102001", " CLASSIFICAZIONI_FATTURASIOPE codice_cgu ok");
			Assert.AreEqual(T.Rows[31]["tipo_debito_siope"], "COMMERCIALE", " CLASSIFICAZIONI_FATTURASIOPEtipo_debito_siope ok");

			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[31]["importo_siope"]), CfgFn.GetNoNullDecimal(118.80), "CLASSIFICAZIONI_FATTURASIOPE importo_siope ok");
			Assert.AreEqual(T.Rows[31]["natura_spesa_siope"], "CAPITALE", "CLASSIFICAZIONI_FATTURASIOPE natura_spesa_siope ok");
			Assert.AreEqual(T.Rows[31]["motivo_scadenza_siope"], "CORRETTA_SCAD_FATTURA", "CLASSIFICAZIONI_FATTURASIOPE motivo_scadenza_siope ok");

			//q filterClassificazioni = q.eq("kind", "CLASSIFICAZIONI") & q.eq("ndoc", ndoc) & q.eq("idpay", 1);
			//var rClass = T._First(filterClassificazioni);
			Assert.AreEqual(T.Rows[40]["codice_cge"], "9010102001", "CLASSIFICAZIONI codice_cgu ok");
			Assert.AreEqual(T.Rows[40]["tipo_debito_siope"], "COMMERCIALE", "CLASSIFICAZIONI tipo_debito_siope ok");
 
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[40]["importoclassificazionemov"]), CfgFn.GetNoNullDecimal(79.42), "CLASSIFICAZIONI importoclassificazionemov ok");

			Assert.AreEqual(T.Rows[41]["codice_cge"], "9010102001", "CLASSIFICAZIONI codice_cgu ok");
			Assert.AreEqual(T.Rows[41]["tipo_debito_siope"], "COMMERCIALE", "CLASSIFICAZIONI tipo_debito_siope ok");

			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[41]["importoclassificazionemov"]), CfgFn.GetNoNullDecimal(145.64), "CLASSIFICAZIONI importoclassificazionemov ok");

			Assert.AreEqual(T.Rows[42]["codice_cge"], "9010102001", "CLASSIFICAZIONI codice_cgu ok");
			Assert.AreEqual(T.Rows[42]["tipo_debito_siope"], "COMMERCIALE", "CLASSIFICAZIONI tipo_debito_siope ok");

			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[42]["importoclassificazionemov"]), CfgFn.GetNoNullDecimal(179.01), "CLASSIFICAZIONI importoclassificazionemov ok");

			Assert.AreEqual(T.Rows[43]["codice_cge"], "9010102001", "CLASSIFICAZIONI codice_cgu ok");
			Assert.AreEqual(T.Rows[43]["tipo_debito_siope"], "COMMERCIALE", "CLASSIFICAZIONI tipo_debito_siope ok");
	
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[43]["importoclassificazionemov"]), CfgFn.GetNoNullDecimal(305.83), "CLASSIFICAZIONI importoclassificazionemov ok");

			Assert.AreEqual(T.Rows[44]["codice_cge"], "9010102001", "CLASSIFICAZIONI codice_cgu ok");
			Assert.AreEqual(T.Rows[44]["tipo_debito_siope"], "COMMERCIALE", "CLASSIFICAZIONI tipo_debito_siope ok");
	
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[44]["importoclassificazionemov"]), CfgFn.GetNoNullDecimal(118.80), "CLASSIFICAZIONI importoclassificazionemov ok");

		}

		[TestMethod]
		public void Test_2019_reversali_ins_68() {
			string spName = "trasmele_income_opisiopeplus_ins";
			string spErrMess;

			int spTimeOut;
			spTimeOut = 1;
			object nproceedstransmission = 68;

			// Recupera i parametri da passare alla sp
			object[] spParams = {2019,nproceedstransmission};

			// Lancia le sp da testare 
			DataSet retDS = conn.CallSP(spName, spParams, spTimeOut*60, out spErrMess);
			Assert.IsNull(spErrMess, $"SP: {spName}. Errore: {spErrMess}");
			Assert.IsNotNull(retDS, $"SP: {spName}. DataSet di ritorno è null");
			DataTable T = retDS.Tables[0];

			//q filterClassFatturaSiope = q.eq("kind", "CLASSIFICAZIONI_FATTURASIOPE") & q.eq("ndoc", ndoc) & q.eq("idpay", 1);
			//var rClassFS = T._First(filterClassFatturaSiope);
 
			Assert.AreEqual(T.Rows[5]["codice_cge"], "9010102001", " CLASSIFICAZIONI_FATTURASIOPE codice_cgu ok");
			Assert.AreEqual(T.Rows[5]["tipo_debito_siope"], "COMMERCIALE", " CLASSIFICAZIONI_FATTURASIOPEtipo_debito_siope ok");
 
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[5]["importo_siope"]), CfgFn.GetNoNullDecimal(198.00), "CLASSIFICAZIONI_FATTURASIOPE importo_siope ok");
			Assert.AreEqual(T.Rows[5]["natura_spesa_siope"], "CORRENTE", "CLASSIFICAZIONI_FATTURASIOPE natura_spesa_siope ok");
			Assert.AreEqual(T.Rows[5]["motivo_scadenza_siope"], "CORRETTA_SCAD_FATTURA", "CLASSIFICAZIONI_FATTURASIOPE motivo_scadenza_siope ok");

			Assert.AreEqual(T.Rows[6]["codice_cge"], "3050203004", " CLASSIFICAZIONI_FATTURASIOPE codice_cgu ok");
			Assert.AreEqual(T.Rows[6]["tipo_debito_siope"], "NON COMMERCIALE", " CLASSIFICAZIONI_FATTURASIOPEtipo_debito_siope ok");
			Assert.AreEqual(T.Rows[6]["importo_siope"], DBNull.Value, "CLASSIFICAZIONI_FATTURASIOPE importo_siope ok");
			Assert.AreEqual(T.Rows[6]["natura_spesa_siope"], DBNull.Value, "CLASSIFICAZIONI_FATTURASIOPE natura_spesa_siope ok");
			Assert.AreEqual(T.Rows[6]["motivo_scadenza_siope"], DBNull.Value, "CLASSIFICAZIONI_FATTURASIOPE motivo_scadenza_siope ok");

			//q filterClassificazioni = q.eq("kind", "CLASSIFICAZIONI") & q.eq("ndoc", ndoc) & q.eq("idpay", 1);
			//var rClass = T._First(filterClassificazioni);
			Assert.AreEqual(T.Rows[7]["codice_cge"], "9010102001", "CLASSIFICAZIONI codice_cgu ok");
			Assert.AreEqual(T.Rows[7]["tipo_debito_siope"], "COMMERCIALE", "CLASSIFICAZIONI tipo_debito_siope ok");
 
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[7]["importoclassificazionemov"]), CfgFn.GetNoNullDecimal(198.00), "CLASSIFICAZIONI importoclassificazionemov ok");

			Assert.AreEqual(T.Rows[8]["codice_cge"], "3050203004", "CLASSIFICAZIONI codice_cgu ok");
			Assert.AreEqual(T.Rows[8]["tipo_debito_siope"], "NON COMMERCIALE", "CLASSIFICAZIONI tipo_debito_siope ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[8]["importoclassificazionemov"]), CfgFn.GetNoNullDecimal(200.00), "CLASSIFICAZIONI importoclassificazionemov ok");

		}



		[TestMethod]
		public void Test_2019_reversali_ins_69() {
			string spName = "trasmele_income_opisiopeplus_ins";
			string spErrMess;

			int spTimeOut;
			spTimeOut = 1;
			object nproceedstransmission = 69;

			// Recupera i parametri da passare alla sp
			object[] spParams = {2019,nproceedstransmission};

			// Lancia le sp da testare 
			DataSet retDS = conn.CallSP(spName, spParams, spTimeOut*60, out spErrMess);
			Assert.IsNull(spErrMess, $"SP: {spName}. Errore: {spErrMess}");
			Assert.IsNotNull(retDS, $"SP: {spName}. DataSet di ritorno è null");
			DataTable T = retDS.Tables[0];

			//q filterClassFatturaSiope = q.eq("kind", "CLASSIFICAZIONI_FATTURASIOPE") & q.eq("ndoc", ndoc) & q.eq("idpay", 1);
			//var rClassFS = T._First(filterClassFatturaSiope);

			Assert.AreEqual(T.Rows[5]["codice_cge"], "3010201023", " CLASSIFICAZIONI_FATTURASIOPE codice_cgu ok");
			Assert.AreEqual(T.Rows[5]["tipo_debito_siope"], "NON COMMERCIALE", " CLASSIFICAZIONI_FATTURASIOPEtipo_debito_siope ok");
 
			Assert.AreEqual(T.Rows[5]["importo_siope"], DBNull.Value, "CLASSIFICAZIONI_FATTURASIOPE importo_siope ok");
			Assert.AreEqual(T.Rows[5]["natura_spesa_siope"], DBNull.Value, "CLASSIFICAZIONI_FATTURASIOPE natura_spesa_siope ok");
			Assert.AreEqual(T.Rows[5]["motivo_scadenza_siope"], DBNull.Value, "CLASSIFICAZIONI_FATTURASIOPE motivo_scadenza_siope ok");

			Assert.AreEqual(T.Rows[4]["codice_cge"], "3050203002", " CLASSIFICAZIONI_FATTURASIOPE codice_cgu ok");
			Assert.AreEqual(T.Rows[4]["tipo_debito_siope"], "NON COMMERCIALE", " CLASSIFICAZIONI_FATTURASIOPEtipo_debito_siope ok");
		 	Assert.AreEqual(T.Rows[4]["importo_siope"], DBNull.Value, "CLASSIFICAZIONI_FATTURASIOPE importo_siope ok");
			Assert.AreEqual(T.Rows[4]["natura_spesa_siope"], DBNull.Value, "CLASSIFICAZIONI_FATTURASIOPE natura_spesa_siope ok");
			Assert.AreEqual(T.Rows[4]["motivo_scadenza_siope"], DBNull.Value, "CLASSIFICAZIONI_FATTURASIOPE motivo_scadenza_siope ok");

			//q filterClassificazioni = q.eq("kind", "CLASSIFICAZIONI") & q.eq("ndoc", ndoc) & q.eq("idpay", 1);
			//var rClass = T._First(filterClassificazioni);
			Assert.AreEqual(T.Rows[5]["codice_cge"], "3010201023", "CLASSIFICAZIONI codice_cgu ok");
			Assert.AreEqual(T.Rows[5]["tipo_debito_siope"], "NON COMMERCIALE", "CLASSIFICAZIONI tipo_debito_siope ok");
			 Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[5]["importoclassificazionemov"]), CfgFn.GetNoNullDecimal(960.00), "CLASSIFICAZIONI importoclassificazionemov ok");

			Assert.AreEqual(T.Rows[6]["codice_cge"], "3050203002", "CLASSIFICAZIONI codice_cgu ok");
			Assert.AreEqual(T.Rows[6]["tipo_debito_siope"], "NON COMMERCIALE", "CLASSIFICAZIONI tipo_debito_siope ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[6]["importoclassificazionemov"]), CfgFn.GetNoNullDecimal(2.00), "CLASSIFICAZIONI importoclassificazionemov ok");

		}

		[TestMethod]
		public void Test_2019_reversali_ins_70() {
			string spName = "trasmele_income_opisiopeplus_ins";
			string spErrMess;

			int spTimeOut;
			spTimeOut = 1;
			object nproceedstransmission = 70;

			// Recupera i parametri da passare alla sp
			object[] spParams = {2019,nproceedstransmission};

			// Lancia le sp da testare 
			DataSet retDS = conn.CallSP(spName, spParams, spTimeOut*60, out spErrMess);
			Assert.IsNull(spErrMess, $"SP: {spName}. Errore: {spErrMess}");
			Assert.IsNotNull(retDS, $"SP: {spName}. DataSet di ritorno è null");
			DataTable T = retDS.Tables[0];

			//q filterClassFatturaSiope = q.eq("kind", "CLASSIFICAZIONI_FATTURASIOPE") & q.eq("ndoc", ndoc) & q.eq("idpay", 1);
			//var rClassFS = T._First(filterClassFatturaSiope);

			Assert.AreEqual(T.Rows[4]["codice_cge"], "3010201023", " CLASSIFICAZIONI_FATTURASIOPE codice_cgu ok");
			Assert.AreEqual(T.Rows[4]["tipo_debito_siope"], "NON COMMERCIALE", " CLASSIFICAZIONI_FATTURASIOPEtipo_debito_siope ok");
			Assert.AreEqual(T.Rows[4]["importo_siope"], DBNull.Value, "CLASSIFICAZIONI_FATTURASIOPE importo_siope ok");
			Assert.AreEqual(T.Rows[4]["natura_spesa_siope"], DBNull.Value, "CLASSIFICAZIONI_FATTURASIOPE natura_spesa_siope ok");
			Assert.AreEqual(T.Rows[4]["motivo_scadenza_siope"], DBNull.Value, "CLASSIFICAZIONI_FATTURASIOPE motivo_scadenza_siope ok");

			Assert.AreEqual(T.Rows[5]["codice_cge"], "3010201023", " CLASSIFICAZIONI_FATTURASIOPE codice_cgu ok");
			Assert.AreEqual(T.Rows[5]["tipo_debito_siope"], "NON COMMERCIALE", " CLASSIFICAZIONI_FATTURASIOPEtipo_debito_siope ok");
			Assert.AreEqual(T.Rows[5]["importo_siope"], DBNull.Value, "CLASSIFICAZIONI_FATTURASIOPE importo_siope ok");
			Assert.AreEqual(T.Rows[5]["natura_spesa_siope"], DBNull.Value, "CLASSIFICAZIONI_FATTURASIOPE natura_spesa_siope ok");
			Assert.AreEqual(T.Rows[5]["motivo_scadenza_siope"], DBNull.Value, "CLASSIFICAZIONI_FATTURASIOPE motivo_scadenza_siope ok");


			//q filterClassificazioni = q.eq("kind", "CLASSIFICAZIONI") & q.eq("ndoc", ndoc) & q.eq("idpay", 1);
			//var rClass = T._First(filterClassificazioni);
			Assert.AreEqual(T.Rows[6]["codice_cge"], "3010201023", "CLASSIFICAZIONI codice_cgu ok");
			Assert.AreEqual(T.Rows[6]["tipo_debito_siope"], "NON COMMERCIALE", "CLASSIFICAZIONI tipo_debito_siope ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[6]["importoclassificazionemov"]), CfgFn.GetNoNullDecimal(984.00), "CLASSIFICAZIONI importoclassificazionemov ok");

			Assert.AreEqual(T.Rows[7]["codice_cge"], "3010201023", "CLASSIFICAZIONI codice_cgu ok");
			Assert.AreEqual(T.Rows[7]["tipo_debito_siope"], "NON COMMERCIALE", "CLASSIFICAZIONI tipo_debito_siope ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[7]["importoclassificazionemov"]), CfgFn.GetNoNullDecimal(756.00), "CLASSIFICAZIONI importoclassificazionemov ok");

		}


		[TestMethod]
		public void Test_2019_reversali_ins_82() {
			string spName = "trasmele_income_opisiopeplus_ins";
			string spErrMess;

			int spTimeOut;
			spTimeOut = 1;
			object nproceedstransmission = 82;

			// Recupera i parametri da passare alla sp
			object[] spParams = {2019,nproceedstransmission};

			// Lancia le sp da testare 
			DataSet retDS = conn.CallSP(spName, spParams, spTimeOut*60, out spErrMess);
			Assert.IsNull(spErrMess, $"SP: {spName}. Errore: {spErrMess}");
			Assert.IsNotNull(retDS, $"SP: {spName}. DataSet di ritorno è null");
			DataTable T = retDS.Tables[0];

			//q filterClassFatturaSiope = q.eq("kind", "CLASSIFICAZIONI_FATTURASIOPE") & q.eq("ndoc", ndoc) & q.eq("idpay", 1);
			//var rClassFS = T._First(filterClassFatturaSiope);

			Assert.AreEqual(T.Rows[3]["codice_cge"], "3010201027", " CLASSIFICAZIONI_FATTURASIOPE codice_cgu ok");
			Assert.AreEqual(T.Rows[3]["tipo_debito_siope"], "NON COMMERCIALE", " CLASSIFICAZIONI_FATTURASIOPEtipo_debito_siope ok");
			Assert.AreEqual(T.Rows[3]["importo_siope"], DBNull.Value, "CLASSIFICAZIONI_FATTURASIOPE importo_siope ok");
			Assert.AreEqual(T.Rows[3]["natura_spesa_siope"], DBNull.Value, "CLASSIFICAZIONI_FATTURASIOPE natura_spesa_siope ok");
			Assert.AreEqual(T.Rows[3]["motivo_scadenza_siope"], DBNull.Value, "CLASSIFICAZIONI_FATTURASIOPE motivo_scadenza_siope ok");

			Assert.AreEqual(T.Rows[4]["codice_cge"], "3010202002", " CLASSIFICAZIONI_FATTURASIOPE codice_cgu ok");
			Assert.AreEqual(T.Rows[4]["tipo_debito_siope"], "NON COMMERCIALE", " CLASSIFICAZIONI_FATTURASIOPEtipo_debito_siope ok");
			Assert.AreEqual(T.Rows[4]["importo_siope"], DBNull.Value, "CLASSIFICAZIONI_FATTURASIOPE importo_siope ok");
			Assert.AreEqual(T.Rows[4]["natura_spesa_siope"], DBNull.Value, "CLASSIFICAZIONI_FATTURASIOPE natura_spesa_siope ok");
			Assert.AreEqual(T.Rows[4]["motivo_scadenza_siope"], DBNull.Value, "CLASSIFICAZIONI_FATTURASIOPE motivo_scadenza_siope ok");


			//q filterClassificazioni = q.eq("kind", "CLASSIFICAZIONI") & q.eq("ndoc", ndoc) & q.eq("idpay", 1);
			//var rClass = T._First(filterClassificazioni);
			Assert.AreEqual(T.Rows[5]["codice_cge"], "3010201027", "CLASSIFICAZIONI codice_cgu ok");
			Assert.AreEqual(T.Rows[5]["tipo_debito_siope"], "NON COMMERCIALE", "CLASSIFICAZIONI tipo_debito_siope ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[5]["importoclassificazionemov"]), CfgFn.GetNoNullDecimal(122.00), "CLASSIFICAZIONI importoclassificazionemov ok");

			Assert.AreEqual(T.Rows[6]["codice_cge"], "3010202002", "CLASSIFICAZIONI codice_cgu ok");
			Assert.AreEqual(T.Rows[6]["tipo_debito_siope"], "NON COMMERCIALE", "CLASSIFICAZIONI tipo_debito_siope ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[6]["importoclassificazionemov"]), CfgFn.GetNoNullDecimal(183.00), "CLASSIFICAZIONI importoclassificazionemov ok");

		}

		[TestMethod]
		public void Test_2019_reversali_ins_107() {
			string spName = "trasmele_income_opisiopeplus_ins";
			string spErrMess;

			int spTimeOut;
			spTimeOut = 1;
			object nproceedstransmission = 107;

			// Recupera i parametri da passare alla sp
			object[] spParams = { 2019, nproceedstransmission };

			// Lancia le sp da testare 
			DataSet retDS = conn.CallSP(spName, spParams, spTimeOut * 60, out spErrMess);
			Assert.IsNull(spErrMess, $"SP: {spName}. Errore: {spErrMess}");
			Assert.IsNotNull(retDS, $"SP: {spName}. DataSet di ritorno è null");
			DataTable T = retDS.Tables[0];

			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[1]["ndoc"]), 527, "REVERSALE importo ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[1]["importo_reversale"]), CfgFn.GetNoNullDecimal(66.00), "REVERSALE importo ok");

			Assert.AreEqual(T.Rows[3]["codice_cge"], "9010102001", " CLASSIFICAZIONI_FATTURASIOPE codice_cgu ok");
			Assert.AreEqual(T.Rows[3]["tipo_debito_siope"], "COMMERCIALE", " CLASSIFICAZIONI_FATTURASIOPEtipo_debito_siope ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[3]["importo_siope"]), CfgFn.GetNoNullDecimal(220.00), "CLASSIFICAZIONI_FATTURASIOPE importo_siope ok");
			Assert.AreEqual(T.Rows[4]["codice_cge"], "9010102001", " CLASSIFICAZIONI_FATTURASIOPE codice_cgu ok");
			Assert.AreEqual(T.Rows[4]["tipo_debito_siope"], "COMMERCIALE", " CLASSIFICAZIONI_FATTURASIOPEtipo_debito_siope ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[4]["importo_siope"]), CfgFn.GetNoNullDecimal(-154.00), "CLASSIFICAZIONI_FATTURASIOPE importo_siope ok");

			Assert.AreEqual(T.Rows[5]["codice_cge"], "9010102001", "CLASSIFICAZIONI codice_cgu ok");
			Assert.AreEqual(T.Rows[5]["tipo_debito_siope"], "COMMERCIALE", "CLASSIFICAZIONI tipo_debito_siope ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[5]["importoclassificazionemov"]), CfgFn.GetNoNullDecimal(66.00), "CLASSIFICAZIONI importoclassificazionemov ok");

			}
		[TestMethod]
		public void Test_2019_reversali_var_80_491() {
			string spName = "trasmele_income_opisiopeplus_var";
			string spErrMess;

			int spTimeOut;
			spTimeOut = 1;
			object nproceedstransmission = 80;

			// Recupera i parametri da passare alla sp
			object[] spParams = {2019,nproceedstransmission};

			// Lancia le sp da testare 
			DataSet retDS = conn.CallSP(spName, spParams, spTimeOut*60, out spErrMess);
			Assert.IsNull(spErrMess, $"SP: {spName}. Errore: {spErrMess}");
			Assert.IsNotNull(retDS, $"SP: {spName}. DataSet di ritorno è null");
			DataTable T = retDS.Tables[0];

			//q filterClassFatturaSiope = q.eq("kind", "CLASSIFICAZIONI_FATTURASIOPE") & q.eq("ndoc", ndoc) & q.eq("idpay", 1);
			//var rClassFS = T._First(filterClassFatturaSiope);

			Assert.AreEqual(T.Rows[3]["codice_cge"], "3010201038", " CLASSIFICAZIONI_FATTURASIOPE codice_cgu ok");
			Assert.AreEqual(T.Rows[3]["tipo_debito_siope"], "NON COMMERCIALE", " CLASSIFICAZIONI_FATTURASIOPEtipo_debito_siope ok");
			Assert.AreEqual(T.Rows[3]["importo_siope"], DBNull.Value, "CLASSIFICAZIONI_FATTURASIOPE importo_siope ok");
			Assert.AreEqual(T.Rows[3]["natura_spesa_siope"], DBNull.Value, "CLASSIFICAZIONI_FATTURASIOPE natura_spesa_siope ok");
			Assert.AreEqual(T.Rows[3]["motivo_scadenza_siope"], DBNull.Value, "CLASSIFICAZIONI_FATTURASIOPE motivo_scadenza_siope ok");

			 

			//q filterClassificazioni = q.eq("kind", "CLASSIFICAZIONI") & q.eq("ndoc", ndoc) & q.eq("idpay", 1);
			//var rClass = T._First(filterClassificazioni);
			Assert.AreEqual(T.Rows[4]["codice_cge"], "3010201038", "CLASSIFICAZIONI codice_cgu ok");
			Assert.AreEqual(T.Rows[4]["tipo_debito_siope"], "NON COMMERCIALE", "CLASSIFICAZIONI tipo_debito_siope ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[4]["importoclassificazionemov"]), CfgFn.GetNoNullDecimal(183.00), "CLASSIFICAZIONI importoclassificazionemov ok");

			 
		}

		[TestMethod]
		public void Test_2019_reversali_ins_83() {
			string spName = "trasmele_income_opisiopeplus_ins";
			string spErrMess;

			int spTimeOut;
			spTimeOut = 1;
			object nproceedstransmission = 83;

			// Recupera i parametri da passare alla sp
			object[] spParams = {2019,nproceedstransmission};

			// Lancia le sp da testare 
			DataSet retDS = conn.CallSP(spName, spParams, spTimeOut*60, out spErrMess);
			Assert.IsNull(spErrMess, $"SP: {spName}. Errore: {spErrMess}");
			Assert.IsNotNull(retDS, $"SP: {spName}. DataSet di ritorno è null");
			DataTable T = retDS.Tables[0];

			//q filterClassFatturaSiope = q.eq("kind", "CLASSIFICAZIONI_FATTURASIOPE") & q.eq("ndoc", ndoc) & q.eq("idpay", 1);
			//var rClassFS = T._First(filterClassFatturaSiope);

			Assert.AreEqual(T.Rows[3]["codice_cge"], "3010201027", " CLASSIFICAZIONI_FATTURASIOPE codice_cgu ok");
			Assert.AreEqual(T.Rows[3]["tipo_debito_siope"], "NON COMMERCIALE", " CLASSIFICAZIONI_FATTURASIOPEtipo_debito_siope ok");
			Assert.AreEqual(T.Rows[3]["importo_siope"], DBNull.Value, "CLASSIFICAZIONI_FATTURASIOPE importo_siope ok");
			Assert.AreEqual(T.Rows[3]["natura_spesa_siope"], DBNull.Value, "CLASSIFICAZIONI_FATTURASIOPE natura_spesa_siope ok");
			Assert.AreEqual(T.Rows[3]["motivo_scadenza_siope"], DBNull.Value, "CLASSIFICAZIONI_FATTURASIOPE motivo_scadenza_siope ok");

			Assert.AreEqual(T.Rows[4]["codice_cge"], "3010202002", " CLASSIFICAZIONI_FATTURASIOPE codice_cgu ok");
			Assert.AreEqual(T.Rows[4]["tipo_debito_siope"], "NON COMMERCIALE", " CLASSIFICAZIONI_FATTURASIOPEtipo_debito_siope ok");
			Assert.AreEqual(T.Rows[4]["importo_siope"], DBNull.Value, "CLASSIFICAZIONI_FATTURASIOPE importo_siope ok");
			Assert.AreEqual(T.Rows[4]["natura_spesa_siope"], DBNull.Value, "CLASSIFICAZIONI_FATTURASIOPE natura_spesa_siope ok");
			Assert.AreEqual(T.Rows[4]["motivo_scadenza_siope"], DBNull.Value, "CLASSIFICAZIONI_FATTURASIOPE motivo_scadenza_siope ok");


			//q filterClassificazioni = q.eq("kind", "CLASSIFICAZIONI") & q.eq("ndoc", ndoc) & q.eq("idpay", 1);
			//var rClass = T._First(filterClassificazioni);
			Assert.AreEqual(T.Rows[5]["codice_cge"], "3010201027", "CLASSIFICAZIONI codice_cgu ok");
			Assert.AreEqual(T.Rows[5]["tipo_debito_siope"], "NON COMMERCIALE", "CLASSIFICAZIONI tipo_debito_siope ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[5]["importoclassificazionemov"]), CfgFn.GetNoNullDecimal(100.00), "CLASSIFICAZIONI importoclassificazionemov ok");

			Assert.AreEqual(T.Rows[6]["codice_cge"], "3010202002", "CLASSIFICAZIONI codice_cgu ok");
			Assert.AreEqual(T.Rows[6]["tipo_debito_siope"], "NON COMMERCIALE", "CLASSIFICAZIONI tipo_debito_siope ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[6]["importoclassificazionemov"]), CfgFn.GetNoNullDecimal(150.00), "CLASSIFICAZIONI importoclassificazionemov ok");

		}

		[TestMethod]
		public void Test_2020_mandati_ins_108_2019() {
			string spName = "trasmele_expense_opisiopeplus_ins";
			string spErrMess;

			int spTimeOut;
			spTimeOut = 1;
			object npaymenttransmission = 108;
			// Recupera i parametri da passare alla sp
			object[] spParams = { 2019, npaymenttransmission };

			// Lancia le sp da testare 
			DataSet retDS = conn.CallSP(spName, spParams, spTimeOut * 60, out spErrMess);
			Assert.IsNull(spErrMess, $"SP: {spName}. Errore: {spErrMess}");
			Assert.IsNotNull(retDS, $"SP: {spName}. DataSet di ritorno è null");
			DataTable T = retDS.Tables[0];
			//Verifica che scriva solo 4 righe classificazione, e non scriva le righe che li colidono fattura - NC = 0 
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[10]["importoclassificazionemov"]), CfgFn.GetNoNullDecimal(181.50), "CLASSIFICAZIONI importoclassificazionemov ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[11]["importoclassificazionemov"]), CfgFn.GetNoNullDecimal(170.00), "CLASSIFICAZIONI importoclassificazionemov ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[12]["importoclassificazionemov"]), CfgFn.GetNoNullDecimal(181.50), "CLASSIFICAZIONI importoclassificazionemov ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[13]["importoclassificazionemov"]), CfgFn.GetNoNullDecimal(300.00), "CLASSIFICAZIONI importoclassificazionemov ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[14]["kind"]), "RITENUTE", "Importo class. 0 omesso ok");
			}

		[TestMethod]
		public void Test_2020_mandati_var_109_2019() {
			string spName = "trasmele_expense_opisiopeplus_var";
			string spErrMess;

			int spTimeOut;
			spTimeOut = 1;
			object npaymenttransmission = 109;
			// Recupera i parametri da passare alla sp
			object[] spParams = { 2019, npaymenttransmission };

			// Lancia le sp da testare 
			DataSet retDS = conn.CallSP(spName, spParams, spTimeOut * 60, out spErrMess);
			Assert.IsNull(spErrMess, $"SP: {spName}. Errore: {spErrMess}");
			Assert.IsNotNull(retDS, $"SP: {spName}. DataSet di ritorno è null");
			DataTable T = retDS.Tables[0];
			//Verifica che scriva solo 4 righe classificazione, e non scriva le righe che li colidono fattura - NC = 0 
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[10]["importoclassificazionemov"]), CfgFn.GetNoNullDecimal(181.50), "CLASSIFICAZIONI importoclassificazionemov ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[11]["importoclassificazionemov"]), CfgFn.GetNoNullDecimal(170.00), "CLASSIFICAZIONI importoclassificazionemov ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[12]["importoclassificazionemov"]), CfgFn.GetNoNullDecimal(181.50), "CLASSIFICAZIONI importoclassificazionemov ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[13]["importoclassificazionemov"]), CfgFn.GetNoNullDecimal(300.00), "CLASSIFICAZIONI importoclassificazionemov ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[14]["kind"]), "RITENUTE", "Importo class. 0 omesso ok");
			}

		[TestMethod]
		public void Test_2020_mandati_ins_107_2019() {
			string spName = "trasmele_expense_opisiopeplus_ins";
			string spErrMess;

			int spTimeOut;
			spTimeOut = 1;
			object npaymenttransmission = 107;
			//object ndoc = 1302;
			// Recupera i parametri da passare alla sp
			object[] spParams = { 2019, npaymenttransmission };

			// Lancia le sp da testare 
			DataSet retDS = conn.CallSP(spName, spParams, spTimeOut * 60, out spErrMess);
			Assert.IsNull(spErrMess, $"SP: {spName}. Errore: {spErrMess}");
			Assert.IsNotNull(retDS, $"SP: {spName}. DataSet di ritorno è null");
			DataTable T = retDS.Tables[0];
			//Verifica che scriva solo una riuga classificazione in presenza di due dettagli fattura Liq e LiqdaSosp
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[3]["importo_siope"]), CfgFn.GetNoNullDecimal(4265.12), "CLASSIFICAZIONI_FATTURASIOPE importo_siope ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[4]["importoclassificazionemov"]), CfgFn.GetNoNullDecimal(4265.12), "CLASSIFICAZIONI importoclassificazionemov ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[5]["importo_ritenute"]), CfgFn.GetNoNullDecimal(769.12), "RITENUTE importo_ritenute ok");
			int nrow = T.Rows.Count;
			Assert.AreEqual(nrow, 6, "Numero righe 6 - ok");
		}

		[TestMethod]
		public void Test_2020_reversale_ins_84_2019() {
			string spName = "trasmele_income_opisiopeplus_ins";
			string spErrMess;

			int spTimeOut;
			spTimeOut = 1;
			object nproceedstransmission = 84;
			// Recupera i parametri da passare alla sp
			object[] spParams = { 2019, nproceedstransmission };

			// Lancia le sp da testare 
			DataSet retDS = conn.CallSP(spName, spParams, spTimeOut * 60, out spErrMess);
			Assert.IsNull(spErrMess, $"SP: {spName}. Errore: {spErrMess}");
			Assert.IsNotNull(retDS, $"SP: {spName}. DataSet di ritorno è null");
			DataTable T = retDS.Tables[0];
			
			//Verifica che scriva solo una riuga classificazione in presenza di due dettagli fattura Liq e LiqdaSosp
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[3]["importo_siope"]), CfgFn.GetNoNullDecimal(769.12), "CLASSIFICAZIONI_FATTURASIOPE importo_siope ok");
			Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[4]["importoclassificazionemov"]), CfgFn.GetNoNullDecimal(769.12), "CLASSIFICAZIONI importoclassificazionemov ok");
			int nrow = T.Rows.Count;
			Assert.AreEqual(nrow, 5, "Numero righe 5 - ok");
		}


		[TestMethod]
		public void Test_2018_reversali_var_257_2316() {
			string spName = "trasmele_income_opisiopeplus_var";
			string spErrMess;

			int spTimeOut;
			spTimeOut = 1;
			object nproceedstransmission = 257;

			// Recupera i parametri da passare alla sp
			object[] spParams = {2018,nproceedstransmission};

			// Lancia le sp da testare 
			DataSet retDS = conn.CallSP(spName, spParams, spTimeOut*60, out spErrMess);
			Assert.IsNull(spErrMess, $"SP: {spName}. Errore: {spErrMess}");
			Assert.IsNotNull(retDS, $"SP: {spName}. DataSet di ritorno è null");
			DataTable T = retDS.Tables[0];
 
			//q filterClassFatturaSiope = q.eq("kind", "CLASSIFICAZIONI_FATTURASIOPE") & q.eq("ndoc", ndoc) & q.eq("idpay", 1);
			//var rClassFS = T._First(filterClassFatturaSiope);
			Assert.AreEqual(T.Rows[2]["codice_cge"], "9020501001", " CLASSIFICAZIONI_FATTURASIOPE codice_cge ok");
			Assert.AreEqual(T.Rows[2]["tipo_debito_siope"], "NON COMMERCIALE", " CLASSIFICAZIONI_FATTURASIOPEtipo_debito_siope ok");
			Assert.AreEqual(T.Rows[2]["importo_siope"], DBNull.Value, "CLASSIFICAZIONI_FATTURASIOPE importo_siope ok");
			Assert.AreEqual(T.Rows[2]["natura_spesa_siope"], DBNull.Value, "CLASSIFICAZIONI_FATTURASIOPE natura_spesa_siope ok");
			Assert.AreEqual(T.Rows[2]["motivo_scadenza_siope"], DBNull.Value, "CLASSIFICAZIONI_FATTURASIOPE motivo_scadenza_siope ok");

			Assert.AreEqual(T.Rows[3]["codice_cge"], "9020501001", " CLASSIFICAZIONI_FATTURASIOPE codice_cge ok");
			Assert.AreEqual(T.Rows[3]["tipo_debito_siope"], "NON COMMERCIALE", " CLASSIFICAZIONI_FATTURASIOPEtipo_debito_siope ok");
			Assert.AreEqual(T.Rows[3]["importo_siope"], DBNull.Value, "CLASSIFICAZIONI_FATTURASIOPE importo_siope ok");
			Assert.AreEqual(T.Rows[3]["natura_spesa_siope"], DBNull.Value, "CLASSIFICAZIONI_FATTURASIOPE natura_spesa_siope ok");
			Assert.AreEqual(T.Rows[3]["motivo_scadenza_siope"], DBNull.Value, "CLASSIFICAZIONI_FATTURASIOPE motivo_scadenza_siope ok");

			Assert.AreEqual(T.Rows[4]["codice_cge"], "9020501001", " CLASSIFICAZIONI_FATTURASIOPE codice_cge ok");
			Assert.AreEqual(T.Rows[4]["tipo_debito_siope"], "NON COMMERCIALE", " CLASSIFICAZIONI_FATTURASIOPEtipo_debito_siope ok");
			Assert.AreEqual(T.Rows[4]["importo_siope"], DBNull.Value, "CLASSIFICAZIONI_FATTURASIOPE importo_siope ok");
			Assert.AreEqual(T.Rows[4]["natura_spesa_siope"], DBNull.Value, "CLASSIFICAZIONI_FATTURASIOPE natura_spesa_siope ok");
			Assert.AreEqual(T.Rows[4]["motivo_scadenza_siope"], DBNull.Value, "CLASSIFICAZIONI_FATTURASIOPE motivo_scadenza_siope ok");

			Assert.AreEqual(T.Rows[5]["codice_cge"], "9020501001", " CLASSIFICAZIONI_FATTURASIOPE codice_cge ok");
			Assert.AreEqual(T.Rows[5]["tipo_debito_siope"], "NON COMMERCIALE", " CLASSIFICAZIONI_FATTURASIOPEtipo_debito_siope ok");
			Assert.AreEqual(T.Rows[5]["importo_siope"], DBNull.Value, "CLASSIFICAZIONI_FATTURASIOPE importo_siope ok");
			Assert.AreEqual(T.Rows[5]["natura_spesa_siope"], DBNull.Value, "CLASSIFICAZIONI_FATTURASIOPE natura_spesa_siope ok");
			Assert.AreEqual(T.Rows[5]["motivo_scadenza_siope"], DBNull.Value, "CLASSIFICAZIONI_FATTURASIOPE motivo_scadenza_siope ok");

			Assert.AreEqual(T.Rows[6]["codice_cge"], "3050203004", " CLASSIFICAZIONI_FATTURASIOPE codice_cge ok");
			Assert.AreEqual(T.Rows[6]["tipo_debito_siope"], "NON COMMERCIALE", " CLASSIFICAZIONI_FATTURASIOPEtipo_debito_siope ok");
			Assert.AreEqual(T.Rows[6]["importo_siope"], DBNull.Value, "CLASSIFICAZIONI_FATTURASIOPE importo_siope ok");
			Assert.AreEqual(T.Rows[6]["natura_spesa_siope"], DBNull.Value, "CLASSIFICAZIONI_FATTURASIOPE natura_spesa_siope ok");
			Assert.AreEqual(T.Rows[6]["motivo_scadenza_siope"], DBNull.Value, "CLASSIFICAZIONI_FATTURASIOPE motivo_scadenza_siope ok");

			Assert.AreEqual(T.Rows[7]["codice_cge"], "3050203004", " CLASSIFICAZIONI_FATTURASIOPE codice_cge ok");
			Assert.AreEqual(T.Rows[7]["tipo_debito_siope"], "NON COMMERCIALE", " CLASSIFICAZIONI_FATTURASIOPEtipo_debito_siope ok");
			Assert.AreEqual(T.Rows[7]["importo_siope"], DBNull.Value, "CLASSIFICAZIONI_FATTURASIOPE importo_siope ok");
			Assert.AreEqual(T.Rows[7]["natura_spesa_siope"], DBNull.Value, "CLASSIFICAZIONI_FATTURASIOPE natura_spesa_siope ok");
			Assert.AreEqual(T.Rows[7]["motivo_scadenza_siope"], DBNull.Value, "CLASSIFICAZIONI_FATTURASIOPE motivo_scadenza_siope ok");

			Assert.AreEqual(T.Rows[8]["codice_cge"], "9020501001", " CLASSIFICAZIONI_FATTURASIOPE codice_cge ok");
			Assert.AreEqual(T.Rows[8]["tipo_debito_siope"], "NON COMMERCIALE", " CLASSIFICAZIONI_FATTURASIOPEtipo_debito_siope ok");
			Assert.AreEqual(T.Rows[8]["importo_siope"], DBNull.Value, "CLASSIFICAZIONI_FATTURASIOPE importo_siope ok");
			Assert.AreEqual(T.Rows[8]["natura_spesa_siope"], DBNull.Value, "CLASSIFICAZIONI_FATTURASIOPE natura_spesa_siope ok");
			Assert.AreEqual(T.Rows[8]["motivo_scadenza_siope"], DBNull.Value, "CLASSIFICAZIONI_FATTURASIOPE motivo_scadenza_siope ok");

			Assert.AreEqual(T.Rows[9]["codice_cge"], "3050203004", " CLASSIFICAZIONI_FATTURASIOPE codice_cge ok");
			Assert.AreEqual(T.Rows[9]["tipo_debito_siope"], "NON COMMERCIALE", " CLASSIFICAZIONI_FATTURASIOPEtipo_debito_siope ok");
			Assert.AreEqual(T.Rows[9]["importo_siope"], DBNull.Value, "CLASSIFICAZIONI_FATTURASIOPE importo_siope ok");
			Assert.AreEqual(T.Rows[9]["natura_spesa_siope"], DBNull.Value, "CLASSIFICAZIONI_FATTURASIOPE natura_spesa_siope ok");
			Assert.AreEqual(T.Rows[9]["motivo_scadenza_siope"], DBNull.Value, "CLASSIFICAZIONI_FATTURASIOPE motivo_scadenza_siope ok");


			//Assert.AreEqual(T.Rows[982]["codice_cge"], "9020501001", "CLASSIFICAZIONI codice_cge ok");
			//Assert.AreEqual(T.Rows[982]["tipo_debito_siope"], "NON COMMERCIALE", "codice_cge tipo_debito_siope ok");
			//Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[982]["importoclassificazionemov"]), CfgFn.GetNoNullDecimal(140.00), "CLASSIFICAZIONI importoclassificazionemov ok");

			//Assert.AreEqual(T.Rows[983]["codice_cge"], "9020501001", "CLASSIFICAZIONI codice_cge ok");
			//Assert.AreEqual(T.Rows[983]["tipo_debito_siope"], "NON COMMERCIALE", "codice_cge tipo_debito_siope ok");
			//Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[983]["importoclassificazionemov"]), CfgFn.GetNoNullDecimal(140.00), "CLASSIFICAZIONI importoclassificazionemov ok");

			//Assert.AreEqual(T.Rows[984]["codice_cge"], "9020501001", "CLASSIFICAZIONI codice_cge ok");
			//Assert.AreEqual(T.Rows[984]["tipo_debito_siope"], "NON COMMERCIALE", "codice_cge tipo_debito_siope ok");
			//Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[984]["importoclassificazionemov"]), CfgFn.GetNoNullDecimal(140.00), "CLASSIFICAZIONI importoclassificazionemov ok");

			//Assert.AreEqual(T.Rows[985]["codice_cge"], "9020501001", "CLASSIFICAZIONI codice_cge ok");
			//Assert.AreEqual(T.Rows[985]["tipo_debito_siope"], "NON COMMERCIALE", "codice_cge tipo_debito_siope ok");
			//Assert.AreEqual(CfgFn.GetNoNullDecimal(T.Rows[985]["importoclassificazionemov"]), CfgFn.GetNoNullDecimal(140.00), "CLASSIFICAZIONI importoclassificazionemov ok");


			////q filterClassificazioni = q.eq("kind", "CLASSIFICAZIONI") & q.eq("ndoc", ndoc) & q.eq("idpay", 1);
			////var rClass = T._First(filterClassificazioni);
			 

		}

		//
	}
}
