
/*
Easy
Copyright (C) 2022 UniversitÃ  degli Studi di Catania (www.unict.it)
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
using pagoPaService;

namespace e2e {
	/// <summary>
	/// Summary description for test_webServiceUnicredit
	/// </summary>
	[TestClass]
	public class test_webServiceUnicredit {
		public test_webServiceUnicredit() {
			//
			// TODO: Add constructor logic here
			//
		}

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

		[TestMethod]
		public void CheckGetToken() {
			//
			// TODO: Add test logic here
			//
		

		
			string errore;
			var enteGen = PagoPaService.getInformazioniEnte(conn, out errore);

			Assert.IsNull(errore);

			//var ente = PagoPaService.getEnteCreditore(enteGen);
			string error = "";
			string esito = "";

			//var partners = PagoPaService.getListaPartnerConfig(conn).First(x => x.Code=="unicredit");

			string configDb =
				"WSINSPOS9004000C|dcd2a75260575e4a19c01a|0000010|0|01|https://tesopen.unicredit.it/gestoreposizioni/services/soap/gestorePosizioni|8088888583398";

			var config = configDb.Split('|');

			var Errors = new List<string>();

			var esercizio = conn.GetEsercizio();
			var dataContabile = conn.GetDataContabile();
			var utenteRest = "unicredit_consumer"; //"**********";   // utente ambiente SOAP pc  "**********"
			var passwordRest = "a55ffcfa708cde6"; // "**********"; //config[1]; // password ambiente SOAP 
			string codiceEnte = "0000709";// config[2]; // codice azienda
			string urlSoap = config[3]; // url ambiente SOAP
			string userRest = config[4]; // utente ambiente REST
			string pwdRest = config[5]; //password ambiente REST
			var grant_type =   "password";
			var codiceIstituto = "02008";
			string urlRest = " https://web.pasemplice.eu/connettorenodo/services/deb";
			 //"https://tesopen.unicredit.it/gestoreposizioni/services/soap/gestorePosizioni";//config[6]; // url ambiente REST

			UnicreditREST rClientRest = new UnicreditREST(urlRest, utenteRest, passwordRest);

			var idEnte = "4AAFDBCE9F2BC99A";
			var idDominio = "02044190615";

			var access_token = rClientRest.GetToken(grant_type, codiceIstituto, codiceEnte, idEnte, idDominio,
				out error, out esito);
			Assert.IsNull(error);
			Assert.IsNotNull(access_token);

		}
	}
}