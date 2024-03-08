
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
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestHelper;
using ep_functions;
using funzioni_configurazione;
using generaSQL;
using ImportazioneSiopePlus;
using metadatalibrary;
using q = metadatalibrary.MetaExpression;

namespace e2e {
    /// <summary>
    /// Summary description for test_testHelper
    /// </summary>
    [TestClass]
    public class test_testHelper {
        static QueryHelper qhs;
        public test_testHelper() {
            
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

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext) {
            
        }

        // Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void MyClassCleanup() { }

        //Use TestInitialize to run code before running each test
        [TestInitialize()]
         public void MyTestInitialize() { }

        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
         public void MyTestCleanup() { }

        #endregion


        [TestMethod]
        public void testMetaDataRegistryCopy() {
	        var t = new TestHelp(new DateTime(2019, 12, 31));
            var ds = t.insertCopyData(q.eq("idreg", 147972), "registry", "anagrafica");
            Assert.IsNotNull(ds,"Copia anagrafica completata");

            DataTable tReg = ds.Tables["registry"];
            object idreg = tReg.Rows[0]["idreg"];
            ds= t.maindeleteData(q.eq("idreg", idreg), "registry", "anagrafica");
            Assert.IsNull(ds,"Cancellazione anagrafica completata");
        }

        [TestMethod]
        public void testMetaDataMandateCopy_withoutCIG() {
            var t = new TestHelp(new DateTime(2018, 12, 31));
            q filterDoc = q.eq("idmankind", "VARI_GEST_nofattura") & q.eq("yman", 2018) & q.eq("nman", 8);

            //Esegue la copia
            var ds = t.insertCopyData(filterDoc, "mandate", "default");
            Assert.IsNotNull(ds, "Copia Contratto Passivo completata");

            //Controlla che il CIG sia dbnull
            DataTable tMandate = ds.Tables["mandate"];
            Assert.AreEqual(DBNull.Value, tMandate.Rows[0]["cigcode"]);

            //Cancella la riga copiata
            q filterDocNew = q.eq("idmankind", tMandate.Rows[0]["idmankind"]) & q.eq("yman", tMandate.Rows[0]["yman"]) & q.eq("nman", tMandate.Rows[0]["nman"]);
            ds = t.maindeleteData(filterDocNew, "mandate", "default");
            Assert.IsNull(ds, "Cancellazione Contratto Passivo(withoutCIG)completata");
        }
	 

		[TestMethod]
		public void testMetaDataMandateCopy() {
		    var t = new TestHelp(new DateTime(2018, 12, 31));
			q filterDoc = q.eq("idmankind", "VARI_GEST_nofattura") & q.eq("yman", 2018) & q.eq("nman", 9);

			//Esegue la copia

		    var mMandate = TestHelp.editDataRow(t.testConn,filterDoc, "mandate", "default");
		    mMandate.EditNewCopy();		    
		    var res= t.saveFormDataNoBL(mMandate);


		    Assert.AreEqual(0,res.Count, "Copia Contratto Passivo completata");

		    var ds = mMandate.ds;

			 
			DataTable tMandate = ds.Tables["mandate"];
 
			Assert.AreEqual("VARI_GEST_nofattura", tMandate.Rows[0]["idmankind"]);
			//Assert.AreEqual(DBNull.Value, tMandate.Rows[0]["idmandatestatus"]);
 
			Assert.AreNotEqual(9, tMandate.Rows[0]["nman"]);
			Assert.AreEqual((Int16)5, tMandate.Rows[0]["idmandatestatus"]);
 
			Assert.IsTrue(CfgFn.GetNoNullInt32(tMandate.Rows[0]["nman"])> 8,"N.ordine  ricalcolato");
			Assert.AreNotEqual(DBNull.Value, tMandate.Rows[0]["idmandatestatus"]);
 
			Assert.AreEqual(DBNull.Value, tMandate.Rows[0]["cigcode"]);

			//Cancella la riga copiata
			q filterDocNew = q.eq("idmankind", tMandate.Rows[0]["idmankind"]) & q.eq("yman", tMandate.Rows[0]["yman"]) & q.eq("nman", tMandate.Rows[0]["nman"]);
			ds = t.maindeleteData(filterDocNew, "mandate", "default");
			Assert.IsNull(ds, "Cancellazione Contratto Passivo(InsertCopy)completata");

			mMandate.ds.AcceptChanges();
			mMandate.dontWarnOnInsertCancel = true;
			mMandate.linkedForm.Close();

		}

		[TestMethod]
		public void testMetaDataAssetAcquireCopy() {
			var t = new TestHelp(new DateTime(2018, 12, 31));
			q filterDoc = q.eq("nassetacquire",55082);

			//Esegue la copia
			var ds = t.insertCopyData(filterDoc, "assetacquire", "default");
			Assert.IsNotNull(ds, "Copia Carico Cespite completata");


			DataTable tAssetAcquire= ds.Tables["assetacquire"];

			//Assert.AreEqual(DBNull.Value, tMandate.Rows[0]["idmandatestatus"]);
			//string[] dontcopy = new string[]{"idassetload","transmitted","number",
			//									"idinvkind","yinv","ninv","invrownum",
			//									"idmankind","yman","nman","rownum"};

		 
			Assert.AreEqual(DBNull.Value, tAssetAcquire.Rows[0]["idassetload"]);
			Assert.AreEqual(DBNull.Value, tAssetAcquire.Rows[0]["idinvkind"]);
			Assert.AreEqual(DBNull.Value, tAssetAcquire.Rows[0]["yinv"]);
			Assert.AreEqual(DBNull.Value, tAssetAcquire.Rows[0]["ninv"]);
			Assert.AreEqual(DBNull.Value, tAssetAcquire.Rows[0]["invrownum"]);
			Assert.AreEqual(DBNull.Value, tAssetAcquire.Rows[0]["idmankind"]);
			Assert.AreEqual(DBNull.Value, tAssetAcquire.Rows[0]["yman"]);
			Assert.AreEqual(DBNull.Value, tAssetAcquire.Rows[0]["nman"]);
			Assert.AreEqual(DBNull.Value, tAssetAcquire.Rows[0]["rownum"]);

			Assert.IsTrue(CfgFn.GetNoNullInt32(tAssetAcquire.Rows[0]["nassetacquire"]) > 55082, "N.carico cespite  ricalcolato");
			Assert.AreEqual(DBNull.Value, tAssetAcquire.Rows[0]["transmitted"]);

			//Cancella la riga copiata
			q filterDocNew = q.eq("nassetacquire", tAssetAcquire.Rows[0]["nassetacquire"]);
			ds = t.maindeleteData(filterDocNew, "assetacquire", "default");
			Assert.IsNull(ds, "Cancellazione Carico Cespite (InsertCopy)completata");
		}

		[TestMethod]
		public void testMetaDataEnactmentCopy() {
			var t = new TestHelp(new DateTime(2016, 12, 31));
			q filterDoc = q.eq("idenactment", 82);

			//Esegue la copia
			var ds = t.insertCopyData(filterDoc, "enactment", "default");
			Assert.IsNotNull(ds, "Copia Atto Amministrativo completata");


			DataTable tEnactment = ds.Tables["enactment"];
			Assert.AreNotEqual(9, tEnactment.Rows[0]["nofficial"]);
			//Assert.AreEqual(DBNull.Value, tMandate.Rows[0]["idmandatestatus"]);
			//Assert.AreEqual(DBNull.Value, tMandate.Rows[0]["cigcode"]);

			//Cancella la riga copiata
			q filterDocNew = q.eq("idenactment", tEnactment.Rows[0]["idenactment"]);
 
			ds = t.maindeleteData(filterDocNew, "enactment", "default");
			Assert.IsNull(ds, "Cancellazione Atto Amministrativo  (InsertCopy)completata");
		}
		[TestMethod]
		public void testMetaDataEstimateCopy() {
			var t = new TestHelp(new DateTime(2019, 12, 31));
			q filterDoc = q.eq("idestimkind", "CartaDocente") & q.eq("yestim", 2018) & q.eq("nestim", 1);

            //effettua la copia
		    var mEstimate = TestHelp.editDataRow(t.testConn,filterDoc, "estimate", "default");
		    mEstimate.ds.Tables["estimate"].Columns["idestimkind"].DefaultValue = "CartaDocente_1";
		    mEstimate.EditNewCopy();		    

		    var res= t.saveFormDataNoBL(mEstimate);

		    Assert.AreEqual(0,res.Count, "Copia Contratto Attivo completata");

		    var ds = mEstimate.ds;


		    DataTable tEstimate = ds.Tables["estimate"];
		    Assert.AreEqual("CartaDocente", ds.Tables["estimate"].Rows[0]["idestimkind"]);
		    Assert.AreNotEqual(1, tEstimate.Rows[0]["nestim"]);



			//Controlla che i campi da non copiare siano dbnull
			
 

			//Cancella la riga copiata
			q filterDocNew = q.eq("idestimkind", tEstimate.Rows[0]["idestimkind"]) & 
			q.eq("yestim", tEstimate.Rows[0]["yestim"]) & 
			q.eq("nestim", tEstimate.Rows[0]["nestim"]);
			ds = t.maindeleteData(filterDocNew, "estimate", "default");
			Assert.IsNull(ds, "Cancellazione Contratto Attivo(InsertCopy)completata");


			mEstimate.ds.AcceptChanges();
			mEstimate.dontWarnOnInsertCancel = true;
			mEstimate.linkedForm.Close();
		}
		[TestMethod]
		public void testMetaDataEstimateKindCopy() {
			var t = new TestHelp(new DateTime(2019, 12, 31));
			q filterDoc = q.eq("idestimkind", "CartaDocente");

		    //Esegue la copia
		    var mEstimateKind = TestHelp.editDataRow(t.testConn,filterDoc, "estimatekind", "default");
		    mEstimateKind.EditNewCopy();
		    mEstimateKind.ds.Tables["estimatekind"].Rows[0]["idestimkind"] = "CartaDocente_1";
		    
		    var res= t.saveFormDataNoBL(mEstimateKind);

		    Assert.AreEqual(0,res.Count, "Copia Tipo Contratto Attivo completata");

		    var ds = mEstimateKind.ds;

		    //Controlla che i campi da non copiare siano dbnull
			DataTable tEstimatekind = ds.Tables["estimatekind"];
			Assert.AreEqual("CartaDocente_1", tEstimatekind.Rows[0]["idestimkind"]);

			//Cancella la riga copiata
			q filterDocNew = q.eq("idestimkind", "CartaDocente_1")  ;
			 
			ds = t.maindeleteData(filterDocNew, "estimatekind", "default");
			Assert.IsNull(ds, "Cancellazione Tipo Contratto Attivo(InsertCopy)completata");
		}
		[TestMethod]
		public void testMetaDataEpexpCopy() {
			var t = new TestHelp(new DateTime(2018, 12, 31));
			q filterDoc = q.eq("idepexp", 515996);
			  
			//Esegue la copia
			var ds = t.insertCopyData(filterDoc, "epexp", "default");
			Assert.IsNotNull(ds, "Copia Impegno di Budget completata");

			//Controlla che i campi da non copiare siano dbnull
			DataTable tEpExp= ds.Tables["epexp"];
			Assert.AreNotEqual(515996, tEpExp.Rows[0]["idepexp"]);
			Assert.AreNotEqual(515917, tEpExp.Rows[0]["paridepexp"]);
			//Cancella la riga copiata
			q filterDocNew = q.eq("idepexp", tEpExp.Rows[0]["idepexp"])  ;

			ds = t.maindeleteData(filterDocNew, "epexp", "default");
			Assert.IsNull(ds, "Cancellazione Impegno di Budget (InsertCopy)completata");
		}
		[TestMethod]
		public void testMetaDataEpaccCopy() {
			var t = new TestHelp(new DateTime(2018, 12, 31));
			q filterDoc = q.eq("idepacc", 198526);
			  
			//Esegue la copia
			var ds = t.insertCopyData(filterDoc, "epacc", "default");
			Assert.IsNotNull(ds, "Copia Accertamento di Budget completata");

			//Controlla che i campi da non copiare siano dbnull
			DataTable tEpExp= ds.Tables["epacc"];
			Assert.AreNotEqual(198526, tEpExp.Rows[0]["idepacc"]);
			Assert.AreNotEqual(189856, tEpExp.Rows[0]["paridepacc"]);
			//Cancella la riga copiata
			q filterDocNew = q.eq("idepacc", tEpExp.Rows[0]["idepacc"])  ;

			ds = t.maindeleteData(filterDocNew, "epacc", "default");
			Assert.IsNull(ds, "Cancellazione Accertamento di Budget (InsertCopy)completata");

		}
		[TestMethod]
		public void testMetaDataMandateKindCopy() {
			var t = new TestHelp(new DateTime(2019, 12, 31));
			q filterDoc = q.eq("idmankind", "B_ORDINE_comm_AMM");

			//Esegue la copia
		    var mMandateKind = TestHelp.editDataRow(t.testConn,filterDoc, "mandatekind", "default");
		    mMandateKind.EditNewCopy();
		    mMandateKind.ds.Tables["mandatekind"].Rows[0]["idmankind"] = "B_ORDINE_comm_AMZ";
		    var res= t.saveFormDataNoBL(mMandateKind);

			Assert.AreEqual(0,res.Count, "Copia Tipo Contratto Passivo completata");
			var ds = mMandateKind.ds;
			//Controlla che i campi da non copiare siano dbnull
			DataTable tMandatekind = ds.Tables["mandatekind"];
			Assert.AreEqual("B_ORDINE_comm_AMZ", tMandatekind.Rows[0]["idmankind"]);

			//Cancella la riga copiata
			q filterDocNew = q.eq("idmankind","B_ORDINE_comm_AMZ")  ;

			ds = t.maindeleteData(filterDocNew, "mandatekind", "default");
			Assert.IsNull(ds, "Cancellazione Tipo Contratto Passivo(InsertCopy)completata");
		}

		[TestMethod]
		public void testMetaDataExpenseVarCopy() {
			var t = new TestHelp(new DateTime(2018, 12, 31));
			q filterDoc =   q.eq("idexp", 1319834) & q.eq("nvar", 1);

			//Esegue la copia
			var ds = t.insertCopyData(filterDoc, "expensevar", "default");
			//ds = t.insertCopyData(filterDocDetail, "mandatedetail", "single");
			Assert.IsNotNull(ds, "Copia Var Spesa completata");

			//Controlla che ilkpaymenttransmission sia dbnull
			DataTable tVar = ds.Tables["expensevar"];
			Assert.AreEqual(DBNull.Value, tVar.Rows[0]["kpaymenttransmission"]);
 
			//Cancella la riga copiata
			q filterDocNew =   q.eq("idexp", tVar.Rows[0]["idexp"])
			& q.eq("nvar", tVar.Rows[0]["nvar"]);
			ds = t.maindeleteData(filterDocNew, "expensevar", "default");

			Assert.IsNull(ds, "Cancellazione Var. Spesa(InsertCopy)completata");
		}

		[TestMethod]
		public void testMetaDataIncomeVarCopy() {
			var t = new TestHelp(new DateTime(2018, 12, 31));
			q filterDoc =   q.eq("idinc", 577379) & q.eq("nvar", 1);

			//Esegue la copia
			var ds = t.insertCopyData(filterDoc, "incomevar", "default");
			//ds = t.insertCopyData(filterDocDetail, "mandatedetail", "single");
			Assert.IsNotNull(ds, "Copia Var Entrata completata");

			//Controlla che ilkpaymenttransmission sia dbnull
			DataTable tVar = ds.Tables["incomevar"];
			Assert.AreEqual(DBNull.Value, tVar.Rows[0]["kproceedstransmission"]);

			//Cancella la riga copiata
			q filterDocNew =   q.eq("idinc", tVar.Rows[0]["idinc"])
			& q.eq("nvar", tVar.Rows[0]["nvar"]);
			ds = t.maindeleteData(filterDocNew, "incomevar", "default");

			Assert.IsNull(ds, "Cancellazione Var. Entrata(InsertCopy)completata");
		}
		//protected override void InsertCopyColumn(DataColumn C, DataRow Source, DataRow Dest) {
		//	if ((C.ColumnName == "ycon") || (C.ColumnName == "ncon") || (C.ColumnName == "taxableothercontracts")) return;
		//	base.InsertCopyColumn(C, Source, Dest);
		//}
		[TestMethod]
		public void testMetaDataWageadditionCopy() {
			var t = new TestHelp(new DateTime(2018, 12, 31));
			q filterDoc =   q.eq("ycon", 2018) & q.eq("ncon", 2);
 
			//Esegue la copia
			var ds = t.insertCopyData(filterDoc, "wageaddition", "default");
			//ds = t.insertCopyData(filterDocDetail, "mandatedetail", "single");
			Assert.IsNotNull(ds, "Copia Contratto Dipendente completata");

			//Controlla che  ncon sia uguale
			DataTable tContract = ds.Tables["wageaddition"];
			Assert.AreNotEqual(2, tContract.Rows[0]["ncon"]);
 

			//Cancella la riga copiata
			q filterDocNew =   q.eq("ycon", tContract.Rows[0]["ycon"])
			& q.eq("ncon", tContract.Rows[0]["ncon"]);
 ;
			ds = t.maindeleteData(filterDocNew, "wageaddition", "default");

			Assert.IsNull(ds, "Cancellazione Contratto Dipendente(InsertCopy)completata");
		}
		[TestMethod]
		public void testMetaDataCasualCopy() {
			var t = new TestHelp(new DateTime(2018, 12, 31));
			q filterDoc =   q.eq("ycon", 2018) & q.eq("ncon", 2);

			//Esegue la copia
			var ds = t.insertCopyData(filterDoc, "casualcontract", "default");
			//ds = t.insertCopyData(filterDocDetail, "mandatedetail", "single");
			Assert.IsNotNull(ds, "Copia Contratto Occasionale completata");

			//Controlla che ncon siano uguale
			DataTable tContract = ds.Tables["casualcontract"];
			Assert.AreNotEqual(2, tContract.Rows[0]["ncon"]);
		 
			//Cancella la riga copiata
			q filterDocNew =   q.eq("ycon", tContract.Rows[0]["ycon"])
			& q.eq("ncon", tContract.Rows[0]["ncon"]);
			;
			ds = t.maindeleteData(filterDocNew, "casualcontract", "default");

			Assert.IsNull(ds, "Cancellazione Contratto Occasionale (InsertCopy)completata");
		}
		[TestMethod]
		public void testMetaDataProfserviceCopy() {
			var t = new TestHelp(new DateTime(2018, 12, 31));
			q filterDoc =   q.eq("ycon", 2018) & q.eq("ncon", 28);

			//Esegue la copia
			var ds = t.insertCopyData(filterDoc, "profservice", "default");
			//ds = t.insertCopyData(filterDocDetail, "mandatedetail", "single");
			Assert.IsNotNull(ds, "Copia Contratto Professionale completata");

			//Controlla che il idinvkind / yinv / ninv siano dbnull
			DataTable tContract = ds.Tables["profservice"];
 
			Assert.AreEqual(DBNull.Value, tContract.Rows[0]["idinvkind"]);
			Assert.AreEqual(DBNull.Value, tContract.Rows[0]["yinv"]);
			Assert.AreEqual(DBNull.Value, tContract.Rows[0]["ninv"]);
			//Cancella la riga copiata
			q filterDocNew =   q.eq("ycon", tContract.Rows[0]["ycon"])
			& q.eq("ncon", tContract.Rows[0]["ncon"]);
			;
			ds = t.maindeleteData(filterDocNew, "profservice", "default");

			Assert.IsNull(ds, "Cancellazione Contratto Professionale (InsertCopy)completata");
		}
		[TestMethod]
		public void testMetaDataMandateDetailCopy() {
			var t = new TestHelp(new DateTime(2018, 12, 31));
			q filterDoc = q.eq("idmankind", "B_ORDINE_comm_DFARM") & q.eq("yman", 2018) & q.eq("nman", 2);
	 
			q filterDocDetail = filterDoc
				& q.eq("rownum", 1);
			//Esegue la copia
			var ds = t.insertCopyData(filterDoc, "mandate", "default");
			//ds = t.insertCopyData(filterDocDetail, "mandatedetail", "single");
			Assert.IsNotNull(ds, "Copia Contratto Passivo completata");
			 
			//Controlla che il CIG sia dbnull
			DataTable tMandateDetail = ds.Tables["mandatedetail"];
			Assert.AreEqual(DBNull.Value, tMandateDetail.Rows[0]["idexp_taxable"]);
			Assert.AreEqual(DBNull.Value, tMandateDetail.Rows[0]["idexp_iva"]);
			Assert.AreEqual(DBNull.Value, tMandateDetail.Rows[0]["idepexp"]);
			Assert.AreEqual(DBNull.Value, tMandateDetail.Rows[0]["cigcode"]);
			Assert.AreEqual(DBNull.Value, tMandateDetail.Rows[0]["idavcp"]);
			Assert.AreEqual(DBNull.Value, tMandateDetail.Rows[0]["idavcp_choice"]);
			Assert.AreEqual(DBNull.Value, tMandateDetail.Rows[0]["avcp_startcontract"]);
			
			//Cancella la riga copiata
			q filterDocNew = q.eq("idmankind", tMandateDetail.Rows[0]["idmankind"]) 
			                & q.eq("yman", tMandateDetail.Rows[0]["yman"]) 
			                & q.eq("nman", tMandateDetail.Rows[0]["nman"]);
			q filterDocDetailNew =  filterDocNew & q.eq("rownum", tMandateDetail.Rows[0]["rownum"]);
			ds = t.maindeleteData(filterDocNew, "mandate", "default");

			Assert.IsNull(ds, "Cancellazione Contratto Passivo(InsertCopy)completata");
		}
		[TestMethod]
		public void testMetaDataEstimateDetailCopy() {
			var t = new TestHelp(new DateTime(2018, 12, 31));
			q filterDoc = q.eq("idestimkind", "CartaDocente") & q.eq("yestim", 2018) & q.eq("nestim", 1);

			q filterDocDetail = filterDoc & q.eq("rownum", 1);
			//Esegue la copia
			var ds = t.insertCopyData(filterDoc, "estimate", "default");
			//ds = t.insertCopyData(filterDocDetail, "estimatedetail", "single");
			Assert.IsNotNull(ds, "Copia Dettaglio Contratto Attivo completata");
		 
			//Controlla che i dati da non copiare siano dbnull
			DataTable tEstimateeDetail = ds.Tables["estimatedetail"];
			Assert.AreEqual(DBNull.Value, tEstimateeDetail.Rows[0]["idinc_taxable"]);
			Assert.AreEqual(DBNull.Value, tEstimateeDetail.Rows[0]["idinc_iva"]);
			Assert.AreEqual(DBNull.Value, tEstimateeDetail.Rows[0]["iduniqueformcode"]);
			Assert.AreEqual(DBNull.Value, tEstimateeDetail.Rows[0]["idepacc"]);
			Assert.AreEqual(DBNull.Value, tEstimateeDetail.Rows[0]["nform"]);
		 

			//Cancella la riga copiata
			q filterDocNew = q.eq("idestimkind", tEstimateeDetail.Rows[0]["idestimkind"])
			& q.eq("yestim", tEstimateeDetail.Rows[0]["yestim"])
			& q.eq("nestim", tEstimateeDetail.Rows[0]["nestim"]);
			q filterDocDetailNew =  filterDocNew & q.eq("rownum", tEstimateeDetail.Rows[0]["rownum"]);
			ds = t.maindeleteData(filterDocNew, "estimate", "default");
			Assert.IsNull(ds, "Cancellazione Dettaglio Contratto Attivo (InsertCopy)completata");
		}
		[TestMethod]
		public void testMetaDataInvoiceDetailCopy() {
			var t = new TestHelp(new DateTime(2018, 12, 31));
			q filterDoc = q.eq("idinvkind", "10") & q.eq("yinv", 2018) & q.eq("ninv", 1);

			q filterDocDetail = filterDoc & q.eq("rownum", 1);
			//Esegue la copia
			var ds = t.insertCopyData(filterDoc, "invoice", "default");
			//ds = t.insertCopyData(filterDocDetail, "estimatedetail", "single");
			Assert.IsNotNull(ds, "Copia Dettaglio Fattura completata");
	
			//Controlla che i dati da non copiare siano dbnull
			DataTable tInvoiceDetail = ds.Tables["invoicedetail"];
			Assert.AreEqual(DBNull.Value, tInvoiceDetail.Rows[0]["idexp_iva"]);
			Assert.AreEqual(DBNull.Value, tInvoiceDetail.Rows[0]["idexp_taxable"]);
			Assert.AreEqual(DBNull.Value, tInvoiceDetail.Rows[0]["idinc_iva"]);
			Assert.AreEqual(DBNull.Value, tInvoiceDetail.Rows[0]["idinc_taxable"]);
			Assert.AreEqual(DBNull.Value, tInvoiceDetail.Rows[0]["idmankind"]);
			Assert.AreEqual(DBNull.Value, tInvoiceDetail.Rows[0]["manrownum"]);
			Assert.AreEqual(DBNull.Value, tInvoiceDetail.Rows[0]["nman"]);
			Assert.AreEqual(DBNull.Value, tInvoiceDetail.Rows[0]["yman"]);
			Assert.AreEqual(DBNull.Value, tInvoiceDetail.Rows[0]["idepexp"]);
			Assert.AreEqual(DBNull.Value, tInvoiceDetail.Rows[0]["idepacc"]);
			Assert.AreEqual(DBNull.Value, tInvoiceDetail.Rows[0]["ycon"]);
			Assert.AreEqual(DBNull.Value, tInvoiceDetail.Rows[0]["ncon"]);
			Assert.AreEqual(DBNull.Value, tInvoiceDetail.Rows[0]["estimrownum"]);
			Assert.AreEqual(DBNull.Value, tInvoiceDetail.Rows[0]["idestimkind"]);
			Assert.AreEqual(DBNull.Value, tInvoiceDetail.Rows[0]["codicetipo"]);
			Assert.AreEqual(DBNull.Value, tInvoiceDetail.Rows[0]["codicevalore"]);
			Assert.AreEqual(DBNull.Value, tInvoiceDetail.Rows[0]["nestim"]);
			Assert.AreEqual(DBNull.Value, tInvoiceDetail.Rows[0]["yestim"]);
			//Cancella la riga copiata
			q filterDocNew = q.eq("idinvkind", tInvoiceDetail.Rows[0]["idinvkind"])
			& q.eq("yinv", tInvoiceDetail.Rows[0]["yinv"])
			& q.eq("ninv", tInvoiceDetail.Rows[0]["ninv"]);
			q filterDocDetailNew =  filterDocNew & q.eq("rownum", tInvoiceDetail.Rows[0]["rownum"]);
			ds = t.maindeleteData(filterDocNew, "invoice", "default");
			Assert.IsNull(ds, "Cancellazione Dettaglio Fattura (InsertCopy)completata");
		}
		[TestMethod]
		public void testMetaDataInvoiceCopy() {
			var t = new TestHelp(new DateTime(2018, 12, 31));
			q filterDoc = q.eq("idinvkind", "10") & q.eq("yinv", 2018) & q.eq("ninv", 1);

			//Esegue la copia
			var ds = t.insertCopyData(filterDoc, "invoice", "default","default");
			Assert.IsNotNull(ds, "Copia Fattura completata");
			/*
			 * if ((C.ColumnName.ToLower()=="documento")&&(RowChange.IsAutoIncrement(C))){
				Dest["documento"]="-";
				return;
			}
            string [] dontcopy = new string[]{"yinv","flag_auto_split_payment","flag_enabled_split_payment","adate",
                    "flag_reverse_charge","idsdi_acquisto","idsdi_vendita","yelectronicinvoice","nelectronicinvoice",
                        "arrivalprotocolnum","resendingpcc","touniqueregister","idinvkind_real","yinv_real","ninv_real",
                        "doc","docdate","officiallyprinted","protocoldate","iduniqueregister",
                        "idinvkind_forwarder","yinv_forwarder","ninv_forwarder"
            };
			 * */
			//Controlla che i dati da non copiare siano dbnull
			DataTable tInvoice  = ds.Tables["invoice"];
			Assert.AreEqual(DBNull.Value, tInvoice.Rows[0]["idsdi_acquisto"]);
			Assert.AreEqual(DBNull.Value, tInvoice.Rows[0]["idsdi_vendita"]);
			Assert.AreEqual(DBNull.Value, tInvoice.Rows[0]["yelectronicinvoice"]);
			Assert.AreEqual(DBNull.Value, tInvoice.Rows[0]["nelectronicinvoice"]);
			Assert.AreEqual(DBNull.Value, tInvoice.Rows[0]["arrivalprotocolnum"]);
			//Assert.AreEqual(DBNull.Value, tInvoice.Rows[0]["touniqueregister"]);
			Assert.AreEqual(DBNull.Value, tInvoice.Rows[0]["idinvkind_real"]);
			Assert.AreEqual(DBNull.Value, tInvoice.Rows[0]["yinv_real"]);
			Assert.AreEqual(DBNull.Value, tInvoice.Rows[0]["ninv_real"]);
			//Assert.AreEqual(DBNull.Value, tInvoice.Rows[0]["doc"]);
			//Assert.AreEqual(DBNull.Value, tInvoice.Rows[0]["docdate"]);
			//Assert.AreEqual(DBNull.Value, tInvoice.Rows[0]["protocoldate"]);
			//Assert.AreEqual(DBNull.Value, tInvoice.Rows[0]["iduniqueregister"]);
			Assert.IsTrue(ds.Tables["uniqueregister"].Rows.Count == 0, "uniqueregister è vuota");
			Assert.AreEqual(DBNull.Value, tInvoice.Rows[0]["idinvkind_forwarder"]);
			Assert.AreEqual(DBNull.Value, tInvoice.Rows[0]["yinv_forwarder"]);
			Assert.AreEqual(DBNull.Value, tInvoice.Rows[0]["ninv_forwarder"]);
			//Cancella la riga copiata
			q filterDocNew = q.eq("idinvkind", tInvoice.Rows[0]["idinvkind"])
			& q.eq("yinv", tInvoice.Rows[0]["yinv"])
			& q.eq("ninv", tInvoice.Rows[0]["ninv"]);
 
			ds = t.maindeleteData(filterDocNew, "invoice", "default");
			Assert.IsNull(ds, "Cancellazione Fattura (InsertCopy)completata");
		}
		[TestMethod]
        public void testClassFatturaSiope_SpesaGerarchico() {
            var t = new TestHelp(new DateTime(2018, 12, 31));
            var qhs = t.testConn.GetQueryHelper();
            t.copiaFattura(203, 2018, 18,false);//203, 2018, 18 : Fattura Acquisti Ist.Intraue - disfar
            t.copiaFattura(230, 2018, 2, false);//230, 2018, 2 : Nota Credito Ricevuta Intraue Ist - difarm
            t.copiaMovimentoSpesa(1377765, false);

            q FilterExp = q.eq("idexp", 1377765);
            DataTable tExpense = t.testConn.readTable("expense", FilterExp);
            DataRow rExp = tExpense.Rows[0];
            //Ottiene il DS di spesa, del form levels
            var ds = t.SampleDataSet(rExp, "levels");

            // Esegue la classificazione automatica
            t.generaClassAutomatica(ds, rExp);
            //Verfica che la class. siope sia uguale all'importo corrente del movimento
            
            string filterkind = qhs.CmpEq("codesorkind", "SIOPE_U_18");
            object idsorkindS = t.testConn.DO_READ_VALUE("sortingkind", filterkind, "idsorkind");
            
            DataTable Siope = t.testConn.RUN_SELECT("sorting", "idsor", null, qhs.AppAnd(qhs.CmpEq("idsorkind", idsorkindS),qhs.CmpEq("nlevel",5)), null, true);
            qhs = t.testConn.GetQueryHelper();
            string listaIdsor = qhs.DistinctVal(Siope.Select(), "idsor");
            string filteridsor = qhs.FieldInList("idsor", listaIdsor);
            DataTable tExpSorted = ds.Tables["expensesorted"];
            object SortAmount = tExpSorted.Compute("sum(amount)", filteridsor);
            q filterPagamento = q.eq("ayear", 2018) & q.eq("idexp", 1377765);
            DataTable tExpensetotal = t.testConn.readTable("expensetotal", filterPagamento);
            object ImportoMov = tExpensetotal.Rows[0]["curramount"];
            Assert.AreEqual(SortAmount, ImportoMov, "Il pagamento è totalmente classificato.");

            ds.RejectChanges();
            
        }


		//[TestMethod]
		//public void testMetaDataProceedsCopy() {
		//	var t = new TestHelp(new DateTime(2018, 12, 31));
		//	q filterDoc = q.eq("kpro", 53085);

		//	//Esegue la copia
		//	var ds = t.insertCopyData(filterDoc, "proceeds", "default");
		//	Assert.IsNotNull(ds, "Copia Reversale completata");

		//	//Controlla che i campi da non copiare siano dbnull
		//	DataTable tProceeds= ds.Tables["proceeds"];
		//	Assert.AreEqual(DBNull.Value, tProceeds.Rows[0]["kproceedstransmission"]);

		//	//Cancella la riga copiata
		//	q filterDocNew = q.eq("kpro", tProceeds.Rows[0]["kpro"])  ;

		//	ds = t.maindeleteData(filterDocNew, "proceeds", "default");
		//	Assert.IsNull(ds, "Cancellazione Reversale (InsertCopy)completata");
		//}
		[TestMethod]
		public void testMetaDataAssetloadCopy() {
			var t = new TestHelp(new DateTime(2018, 12, 31));
			q filterDoc = q.eq("idassetload", 26890);

			//Esegue la copia
			var ds = t.insertCopyData(filterDoc, "assetload", "default");
			Assert.IsNotNull(ds, "Copia Buono di Carico completata");
		    Assert.IsTrue(ds.Tables["assetload"].Rows.Count > 0, "Il buono carico esiste");
		    Assert.IsTrue(ds.Tables["assetacquireview"].Rows.Count == 0, "Il buono carico è vuoto");

			//Controlla che i campi da non copiare siano dbnull
			DataTable tAssetLoad= ds.Tables["assetload"];
			Assert.AreEqual(DBNull.Value, tAssetLoad.Rows[0]["transmitted"]);

			//Cancella la riga copiata
			q filterDocNew = q.eq("idassetload", tAssetLoad.Rows[0]["idassetload"])  ;

			ds = t.maindeleteData(filterDocNew, "assetload", "default");
			Assert.IsNull(ds, "Cancellazione Buono di Carico (InsertCopy)completata");
		    int nAssetLoadDb = t.testConn.count("assetload", filterDocNew);
            Assert.IsTrue(nAssetLoadDb==0,"Il carico non esiste su db");
		}

		[TestMethod]
		public void testMetaDataAssetUnloadCopy() {
			var t = new TestHelp(new DateTime(2018, 12, 31));
			q filterDoc = q.eq("idassetunload", 57);

			//Esegue la copia
			var ds = t.insertCopyData(filterDoc, "assetunload", "default");
			Assert.IsNotNull(ds, "Copia Buono di Scarico completata");
			Assert.IsTrue(ds.Tables["assetunload"].Rows.Count > 0, "Il buono scarico esiste");
			Assert.IsTrue(ds.Tables["assetpieceview"].Rows.Count == 0, "Il buono scarico non contiene cespiti");
			Assert.IsTrue(ds.Tables["assetamortizationunloadview"].Rows.Count == 0, "Il buono scarico non contiene ammortamenti");
		    Assert.IsTrue(ds.Tables["assetunloadincome"].Rows.Count == 0, "Il buono scarico non è collegato a mov. di entrata");
			//Controlla che i campi da non copiare siano dbnull
			DataTable tAssetUnLoad= ds.Tables["assetunload"];
			Assert.AreEqual(DBNull.Value, tAssetUnLoad.Rows[0]["transmitted"]);

			//Cancella la riga copiata
			q filterDocNew = q.eq("idassetunload", tAssetUnLoad.Rows[0]["idassetunload"])  ;

			ds = t.maindeleteData(filterDocNew, "assetunload", "default");
			Assert.IsNull(ds, "Cancellazione Buono di Scarico (InsertCopy)completata");
			int nAssetLoadDb = t.testConn.count("assetunload", filterDocNew);
			Assert.IsTrue(nAssetLoadDb == 0, "Il buono di scarico non esiste su db");
		}

		[TestMethod]
		public void testMetaDataParasubcontractCopy() {
			var t = new TestHelp(new DateTime(2018, 12, 31));
			q filterDoc = q.eq("idcon", "18001116");

			//Esegue la copia
			var ds = t.insertCopyData(filterDoc, "parasubcontract", "default");
			Assert.IsNotNull(ds, "Copia Contratto Parasubordinato completata");

			//Controlla che i campi da non copiare siano dbnull
			DataTable tInvoicekind = ds.Tables["parasubcontract"];
			Assert.AreNotEqual("18001116", tInvoicekind.Rows[0]["idcon"]);

			//Cancella la riga copiata
			q filterDocNew = q.eq("idcon", tInvoicekind.Rows[0]["idcon"])  ;

			ds = t.maindeleteData(filterDocNew, "parasubcontract", "default");
			Assert.IsNull(ds, "Cancellazione Contratto Parasubordinato (InsertCopy)completata");
		}

		[TestMethod]
		public void testMetaDataServiceRegistryCopy() {
			var t = new TestHelp(new DateTime(2018, 12, 31));
			q filterDoc = q.eq("yservreg", "2018") & q.eq("nservreg", "2") ;

			//Esegue la copia
			var ds = t.insertCopyData(filterDoc, "serviceregistry", "default");
			Assert.IsNotNull(ds, "Copia Anagrafe Prestazioni completata");

			//Controlla che i campi da non copiare siano dbnull
			DataTable tServiceRegistry = ds.Tables["serviceregistry"];
			Assert.AreEqual(DBNull.Value, tServiceRegistry.Rows[0]["id_service"]);
			Assert.AreEqual(DBNull.Value, tServiceRegistry.Rows[0]["idrelated"]);
			Assert.AreEqual(DBNull.Value, tServiceRegistry.Rows[0]["idreg"]);
			//Cancella la riga copiata
			q filterDocNew = q.eq("yservreg", tServiceRegistry.Rows[0]["yservreg"])
							&q.eq("nservreg", tServiceRegistry.Rows[0]["nservreg"]);

			ds = t.maindeleteData(filterDocNew, "serviceregistry", "default");
			Assert.IsNull(ds, "Cancellazione Anagrafe Prestazioni (InsertCopy)completata");
		}


		[TestMethod]
        public void testGenerazioneRecuperoIvaEstera() {
            var t = new TestHelp(new DateTime(2018, 12, 31));
            var qhs = t.testConn.GetQueryHelper();
            t.copiaFattura(205, 2018, 58, false);//205, 2018, 58 : Fattura Acquisti Ist.Intraue - disit
            t.copiaMovimentoSpesa(1380311, false);

            q FilterExp = q.eq("idexp", 1380311);
            var mExpense = TestHelp.editDataRow(t.testConn,FilterExp, "expense", "gerarchico");
            var ds = t.saveFormDataNoBL(mExpense);
            
        }
        [TestMethod]
        public void testBinaryDeleteRegistry() {
	        var t = new TestHelp(new DateTime(2019, 12, 31));
            var ds = t.insertCopyData(q.eq("idreg", 147972), "registry", "anagrafica");
            Assert.IsNotNull(ds,"Copia anagrafica completata");

            DataTable tReg = ds.Tables["registry"];
            object idreg = tReg.Rows[0]["idreg"];
            t.binaryDeleteSet(q.eq("idreg", idreg), t.getTableSet(TestHelp.mainObject.registry));
            Assert.IsNotNull(ds,"Cancellazione anagrafica completata");
            
        }

        [TestMethod]
        public void testBinaryGetDeleteCopyRegistry() {
	        var t = new TestHelp(new DateTime(2019, 12, 31));
            var ds = t.insertCopyData(q.eq("idreg", 147972), "registry", "anagrafica");
            Assert.IsNotNull(ds,"Copia anagrafica completata");
            DataTable tReg = ds.Tables["registry"];
            object idreg = tReg.Rows[0]["idreg"];
            q filterIdReg = q.eq("idreg", idreg);
            DataSet dSource = TestHelp.binaryGetSet(t.testConn,filterIdReg, t.getTableSet(TestHelp.mainObject.registry));
            t.binaryDeleteSet(dSource);
            int nAfterDelete = t.testConn.count("registry", filterIdReg);
            t.binaryCopySet(dSource);
            int nAfterCopySet = t.testConn.count("registry", filterIdReg);
            t.binaryDeleteSet(dSource);
            int nAfterDelete2 = t.testConn.count("registry", filterIdReg);
            
            Assert.AreEqual(0,nAfterDelete);
            Assert.AreEqual(1,nAfterCopySet);
            Assert.AreEqual(0,nAfterDelete2);
            Assert.IsNotNull(ds,"Cancellazione anagrafica completata");
            
        }

        [TestMethod]
        public void testDeleteEP() {
            var t= new TestHelp(new DateTime(2018,12,31));
            q filterMan = q.eq("idmankind", "B_ORDINE_comm_DFARM") & q.eq("yman", 2018) & q.eq("nman", 29);
            DataTable tMandate = t.testConn.readTable("mandate",filterMan);
            Assert.AreEqual(1,tMandate.Rows.Count,"Il c.passivo esiste");
            DataRow rMan = tMandate.Rows[0];
            var idrelated= BudgetFunction.GetIdForDocument(rMan);
            string table;
            string filterRelated = BudgetFunction.getDocChildCondition(t.testConn.GetQueryHelper(), idrelated);
            int nBefore = t.testConn.RUN_SELECT_COUNT("epexp", filterRelated, false);
            Assert.AreNotEqual(0, nBefore);
            t.deleteEp(rMan);
            int nAfterDelete = t.testConn.RUN_SELECT_COUNT("epexp", filterRelated, false);
            Assert.AreEqual(0, nAfterDelete);
            int countEPlinked = t.testConn.count("mandatedetail", filterMan & q.isNotNull("idepexp"));
            Assert.AreEqual(0, countEPlinked);
            t.generateEP(rMan);
            int nAfterGenerate = t.testConn.RUN_SELECT_COUNT("epexp", filterRelated, false);
            Assert.AreEqual(nBefore, nAfterGenerate);
        }

		[TestMethod]
		public void testDeleteEPFromInvoice() {
			var t= new TestHelp(new DateTime(2018,12,31));
			/*inv§164§2015§1§2*/
			q filterInv = q.eq("idinvkind", 167) & q.eq("yinv", 2018) & q.eq("ninv", 4);
            t.binaryReplaceSet(filterInv,t.getTableSet(TestHelp.mainObject.invoice));
		    DataTable tInvoice = t.testConn.readTable("invoice",filterInv);
		    Assert.AreEqual(1, tInvoice.Rows.Count, "La fattura esiste");

		    DataRow rInv = tInvoice.Rows[0];
			t.binaryReplaceEp(rInv,false);
		    t.generateEP(rInv);
			var idrelated= BudgetFunction.GetIdForDocument(rInv);
			string table;
			string filterRelated = BudgetFunction.getDocChildCondition(t.testConn.GetQueryHelper(), idrelated);
			int nBeforeEpexp = t.testConn.RUN_SELECT_COUNT("epexp", filterRelated, false);
			int nBeforeEpAcc = t.testConn.RUN_SELECT_COUNT("epacc", filterRelated, false);
			Assert.AreNotEqual(0, nBeforeEpexp + nBeforeEpAcc);
			t.deleteEp(rInv);
			int nAfterDeleteEpExp = t.testConn.RUN_SELECT_COUNT("epexp", filterRelated, false);
			int nAfterDeleteEpAcc = t.testConn.RUN_SELECT_COUNT("epacc", filterRelated, false);
			Assert.AreEqual(0, nAfterDeleteEpExp + nAfterDeleteEpAcc);
			int countEPlinked = t.testConn.count("invoicedetail", filterInv & q.isNotNull("idepexp"));
			Assert.AreEqual(0, countEPlinked);
			int countEPlinkedEpAcc = t.testConn.count("invoicedetail", filterInv & q.isNotNull("idepacc"));
			Assert.AreEqual(0, countEPlinkedEpAcc);
			t.generateEP(rInv);
			int nAfterGenerateEpExp  = t.testConn.RUN_SELECT_COUNT("epexp", filterRelated, false);
			int nAfterGenerateEpAcc  = t.testConn.RUN_SELECT_COUNT("epacc", filterRelated, false);
		    Assert.AreEqual(nBeforeEpexp, nAfterGenerateEpExp);
		    Assert.AreEqual(nBeforeEpAcc, nAfterGenerateEpAcc);
		    t.deleteEp(rInv);
		    nAfterDeleteEpExp  = t.testConn.RUN_SELECT_COUNT("epexp", filterRelated, false);
		    nAfterDeleteEpAcc  = t.testConn.RUN_SELECT_COUNT("epacc", filterRelated, false);
		    Assert.AreEqual(0, nAfterDeleteEpExp);
		    Assert.AreEqual(0, nAfterGenerateEpAcc);
		}

		/*
		man§VARI_GEST_nofattura§2018§1
		paytrans§2018§1
		man§VARI_GEST_nofattura§2018§2
		protrans§2018§1
		payroll§12394§2018§1
		pettycashoperation§29§2018§3
		bankimport§1147
		estim§DOCAMM-dimet§2018§1
		cascon§2018§2
		taxpay§2018§2§18
		*/

		[TestMethod]
		public void testDeleteEPFromMandate() {
			var t= new TestHelp(new DateTime(2018,12,31));
			/*man§VARI_GEST_nofattura§2018§1*/
			q filterMan = q.eq("idmankind", "VARI_GEST_nofattura") & q.eq("yman", 2018) & q.eq("nman", 1);
			t.binaryReplaceSet(filterMan, t.getTableSet(TestHelp.mainObject.mandate));
			DataTable tMandate= t.testConn.readTable("mandate",filterMan);
			Assert.AreEqual(1, tMandate.Rows.Count, "Il contratto passivo esiste");

			DataRow rMan = tMandate.Rows[0];
			t.binaryReplaceEp(rMan,false);
			t.generateEP(rMan);
			var idrelated= BudgetFunction.GetIdForDocument(rMan);
			string table;
			string filterRelated = BudgetFunction.getDocChildCondition(t.testConn.GetQueryHelper(), idrelated);
			int nBeforeEpexp = t.sampleConn.RUN_SELECT_COUNT("epexp", filterRelated, false);
			//int nBeforeEpAcc = t.testConn.RUN_SELECT_COUNT("epacc", filterRelated, false);
			Assert.AreNotEqual(0, nBeforeEpexp /*+ nBeforeEpAcc*/);
			t.deleteEp(rMan);
			int nAfterDeleteEpExp = t.testConn.RUN_SELECT_COUNT("epexp", filterRelated, false);
			//int nAfterDeleteEpAcc = t.testConn.RUN_SELECT_COUNT("epacc", filterRelated, false);
			Assert.AreEqual(0, nAfterDeleteEpExp  /*+nAfterDeleteEpAcc*/);
			int countEPlinked = t.testConn.count("mandatedetail", filterMan & q.isNotNull("idepexp"));
			Assert.AreEqual(0, countEPlinked);
			//int countEPlinkedEpAcc = t.testConn.count("mandatedetail", filterMan & q.isNotNull("idepacc"));
			//Assert.AreEqual(0, countEPlinkedEpAcc);
		    metaeasylibrary.Easy_PostData.rulesToIgnore.Add("ECOPA047");
			t.generateEP(rMan);
		    metaeasylibrary.Easy_PostData.rulesToIgnore.Clear();
			int nAfterGenerateEpExp  = t.testConn.RUN_SELECT_COUNT("epexp", filterRelated, false);
			//int nAfterGenerateEpAcc  = t.testConn.RUN_SELECT_COUNT("epacc", filterRelated, false);
			t.deleteEp(rMan);
		    metaeasylibrary.Easy_PostData.ignoredRules.Clear();
			Assert.AreEqual(nBeforeEpexp, nAfterGenerateEpExp, "Scritture su contratto passivo");
			//Assert.AreEqual(nBeforeEpAcc, nAfterGenerateEpAcc);
		}

		[TestMethod]
		public void testDeleteEPFromEstimate() {
			var t= new TestHelp(new DateTime(2018,12,31));
			/*estim§DOCAMM-dimet§2018§1*/
			q filterEstim = q.eq("idestimkind", "DOCAMM-dimet") & q.eq("yestim", 2018) & q.eq("nestim", 1);
			t.binaryReplaceSet(filterEstim, t.getTableSet(TestHelp.mainObject.estimate));
			DataTable tEstimate= t.testConn.readTable("estimate",filterEstim);
			Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto attivo esiste");

			DataRow rEstim= tEstimate.Rows[0];
			t.binaryReplaceEp(rEstim,false);
			t.generateEP(rEstim);
			var idrelated= BudgetFunction.GetIdForDocument(rEstim);
			string table;
			string filterRelated = BudgetFunction.getDocChildCondition(t.testConn.GetQueryHelper(), idrelated);
			//int nBeforeEpexp = t.testConn.RUN_SELECT_COUNT("epexp", filterRelated, false);
			int nBeforeEpAcc = t.testConn.RUN_SELECT_COUNT("epacc", filterRelated, false);
			//Assert.AreNotEqual(0, nBeforeEpexp /*+ nBeforeEpAcc*/);
			Assert.AreNotEqual(0, /*nBeforeEpexp */+nBeforeEpAcc);
			t.deleteEp(rEstim);
			//int nAfterDeleteEpExp = t.testConn.RUN_SELECT_COUNT("epexp", filterRelated, false);
			int nAfterDeleteEpAcc = t.testConn.RUN_SELECT_COUNT("epacc", filterRelated, false);
			//Assert.AreEqual(0, nAfterDeleteEpExp + /*nAfterDeleteEpAcc*/);
			Assert.AreEqual(0, /*nAfterDeleteEpExp +*/ nAfterDeleteEpAcc);
			int countEPlinkedEpAcc = t.testConn.count("estimatedetail", filterEstim & q.isNotNull("idepacc"));
			//Assert.AreEqual(0, countEPlinked);
			//int countEPlinkedEpAcc = t.testConn.count("mandatedetail", filterMan & q.isNotNull("idepacc"));
			Assert.AreEqual(0, countEPlinkedEpAcc);
			t.generateEP(rEstim);
			//int nAfterGenerateEpExp  = t.testConn.RUN_SELECT_COUNT("epexp", filterRelated, false);
			int nAfterGenerateEpAcc  = t.testConn.RUN_SELECT_COUNT("epacc", filterRelated, false);
			t.deleteEp(rEstim);
			//Assert.AreEqual(nBeforeEpexp, nAfterGenerateEpExp);
			Assert.AreEqual(nBeforeEpAcc, nAfterGenerateEpAcc);
		}
		[TestMethod]
		public void testDeleteEPFromProceedsTransmission() {
			var t= new TestHelp(new DateTime(2018,12,31));
			/*protrans§2018§1*/
			q filterProTrans = q.eq("kproceedstransmission", 9896);
			t.binaryReplaceSet(filterProTrans, t.getTableSet(TestHelp.mainObject.proceedstransmission));
			DataTable tProceedsTransmission= t.testConn.readTable("proceedstransmission",filterProTrans);
			Assert.AreEqual(1, tProceedsTransmission.Rows.Count, "La distinta di trasmissione reversali esiste");

			DataRow rProceedsTransmission= tProceedsTransmission.Rows[0];
			t.binaryReplaceEp(rProceedsTransmission,false);
			t.generateEP(rProceedsTransmission);
			var idrelated= EP_functions.GetIdForDocument(rProceedsTransmission);
			string table;
	 
			var qhs = t.testConn.GetQueryHelper();
			string filterEntry = qhs.AppAnd(qhs.CmpEq("idrelated", idrelated) ,qhs.CmpEq("yentry", 2018));
			//int nBeforeEpexp = t.testConn.RUN_SELECT_COUNT("epexp", filterRelated, false);
			int nBeforeEntry = t.testConn.RUN_SELECT_COUNT("entry", filterEntry, false);
			//Assert.AreNotEqual(0, nBeforeEpexp /*+ nBeforeEpAcc*/);
			Assert.AreNotEqual(0, /*nBeforeEpexp +*/nBeforeEntry);
			t.deleteEp(rProceedsTransmission);
			//int nAfterDeleteEpExp = t.testConn.RUN_SELECT_COUNT("epexp", filterRelated, false);
			int nAfterDeleteEntry = t.testConn.RUN_SELECT_COUNT("entry", filterEntry, false);
			//Assert.AreEqual(0, nAfterDeleteEpExp + /*nAfterDeleteEpAccfilterEntry
			//Assert.AreEqual(0, /*nAfterDeleteEpExp +*/ nAfterDeleteEntry);
			t.generateEP(rProceedsTransmission);
			//int nAfterGenerateEpExp  = t.testConn.RUN_SELECT_COUNT("epexp", filterRelated, false);
			int nAfterGenerateEntry  = t.testConn.RUN_SELECT_COUNT("entry", filterEntry, false);
			t.deleteEp(rProceedsTransmission);
			//Assert.AreEqual(nBeforeEpexp, nAfterGenerateEpExp);
			Assert.AreEqual(nBeforeEntry, nAfterGenerateEntry);
		}


		[TestMethod]
		public void testDeleteEPFromPaymentTransmission() {
			var t= new TestHelp(new DateTime(2018,12,31));
			/*paytrans§2018§1*/
			/*
			 * 15010
				15011
				15012
				15013
				15014
				15015
				15016
				15017
				15018
				15019
				15020
				15021
				15022
				15023
			 * */
			q filterPayTrans = q.eq("kpaymenttransmission", 15010);
			t.binaryReplaceSet(filterPayTrans, t.getTableSet(TestHelp.mainObject.paymenttransmission));
			DataTable tPaymentransmission= t.testConn.readTable("paymenttransmission",filterPayTrans);
			Assert.AreEqual(1, tPaymentransmission.Rows.Count, "La distinta di trasmissione mandati esiste");

			DataRow rPaymentransmission= tPaymentransmission.Rows[0];
			t.binaryReplaceEp(rPaymentransmission,false);
			t.generateEP(rPaymentransmission);
			var idrelated= EP_functions.GetIdForDocument(rPaymentransmission);
			string table;

			var qhs = t.testConn.GetQueryHelper();
			string filterRelated = qhs.AppAnd(qhs.CmpEq("idrelated", idrelated) ,qhs.CmpEq("yentry", 2018));
			int nBeforeEntry = t.testConn.RUN_SELECT_COUNT("entry", filterRelated, false);
			//int nBeforeEpAcc = t.testConn.RUN_SELECT_COUNT("epacc", filterRelated, false);
			Assert.AreNotEqual(0, nBeforeEntry /*+ nBeforeEpAcc*/);
			//Assert.AreNotEqual(0, /*nBeforeEpexp +*/nBeforeEpAcc);
			t.deleteEp(rPaymentransmission);
			int nAfterDeleteEntry = t.testConn.RUN_SELECT_COUNT("entry", filterRelated, false);
			//int nAfterDeleteEpAcc = t.testConn.RUN_SELECT_COUNT("epacc", filterRelated, false);
			//Assert.AreEqual(0, nAfterDeleteEntry /* + nAfterDeleteEpAcc*/);
			//Assert.AreEqual(0, /*nAfterDeleteEpExp +*/ nAfterDeleteEpAcc);
	 
			t.generateEP(rPaymentransmission);
			int nAfterGenerateEntry  = t.testConn.RUN_SELECT_COUNT("entry", filterRelated, false);
			//int nAfterGenerateEpAcc  = t.testConn.RUN_SELECT_COUNT("epacc", filterRelated, false);
			t.deleteEp(rPaymentransmission);
			Assert.AreEqual(nBeforeEntry, nAfterGenerateEntry);
			//Assert.AreEqual(nBeforeEpAcc, nAfterGenerateEpAcc);
		}
		[TestMethod]
		public void testDeleteEPFromItineration() {
			var t= new TestHelp(new DateTime(2018,12,31));

			q filterItineration = q.eq("iditineration", 23098) ;
			DataTable tItineration= t.testConn.readTable("itineration",filterItineration);
			Assert.AreEqual(1, tItineration.Rows.Count, "La missione esiste");
			DataRow rItineration = tItineration.Rows[0];
		    t.binaryCopySet(filterItineration, t.getTableSet(TestHelp.mainObject.itineration));
		    t.binaryReplaceEp(rItineration,false);


			t.generateEP(rItineration);
			var idrelated= BudgetFunction.GetIdForDocument(rItineration);
			string table;
			string filterRelated = BudgetFunction.getDocChildCondition(t.testConn.GetQueryHelper(), idrelated);
			int nBefore = t.testConn.RUN_SELECT_COUNT("epexp", filterRelated, false);
			Assert.AreNotEqual(0, nBefore);

			t.deleteEp(rItineration);
			int nAfterDelete = t.testConn.RUN_SELECT_COUNT("epexp", filterRelated, false);
			Assert.AreEqual(0, nAfterDelete);
		

			t.generateEP(rItineration);
			int nAfterGenerate = t.testConn.RUN_SELECT_COUNT("epexp", filterRelated, false);
			Assert.AreEqual(nBefore, nAfterGenerate);
		}

		[TestMethod]
		public void testDeleteEPFromProfService() {
			var t= new TestHelp(new DateTime(2019,12,31));

			q filterProfService= q.eq("ycon", 2019) & q.eq("ncon", 1);
			DataTable tProfService= t.testConn.readTable("profservice",filterProfService);
			Assert.AreEqual(1, tProfService.Rows.Count, "Il contratto professionale esiste");
			DataRow rProfService = tProfService.Rows[0];
			t.binaryCopySet(filterProfService, t.getTableSet(TestHelp.mainObject.profservice));
			t.binaryReplaceEp(rProfService,false);
			var idrelated= BudgetFunction.GetIdForDocument(rProfService);
			string filterRelated = BudgetFunction.getDocChildCondition(t.testConn.GetQueryHelper(), idrelated);
			int nSample = t.sampleConn.RUN_SELECT_COUNT("epexp", filterRelated, false);
			t.generateEP(rProfService);
		
			int nAfterGenerate = t.testConn.RUN_SELECT_COUNT("epexp", filterRelated, false);
			Assert.AreEqual(nSample, nAfterGenerate);
			t.deleteEp(rProfService);
			int nAfterDelete = t.testConn.RUN_SELECT_COUNT("epexp", filterRelated, false);
			Assert.AreEqual(0, nAfterDelete);
			t.generateEP(rProfService);
			int nAfterGenerate2 = t.testConn.RUN_SELECT_COUNT("epexp", filterRelated, false);
			Assert.AreEqual(nSample, nAfterGenerate2);
		}

		[TestMethod]
		public void testDeleteEPFromPettyCashOperation() {
			var t= new TestHelp(new DateTime(2019,12,31));
			//idpettycash, yoperation, noperation
			//pettycashoperation§29§2019§9
			q filterPettyCashOperation= q.eq("idpettycash", 29) & q.eq("yoperation", 2019) & q.eq("noperation", 9);
			DataTable tPettyCashOperation= t.testConn.readTable("pettycashoperation",filterPettyCashOperation);
			Assert.AreEqual(1, tPettyCashOperation.Rows.Count, "L'operazione fondo economale esiste");
			DataRow rPettyCashOperation = tPettyCashOperation.Rows[0];
			t.binaryCopySet(filterPettyCashOperation, t.getTableSet(TestHelp.mainObject.pettycashoperation));
			t.binaryReplaceEp(rPettyCashOperation,false);
			var idrelated= BudgetFunction.GetIdForDocument(rPettyCashOperation);
			string filterRelated = BudgetFunction.getDocChildCondition(t.testConn.GetQueryHelper(), idrelated);
			int nBefore1 = t.sampleConn.RUN_SELECT_COUNT("epexp", filterRelated, false);
			t.generateEP(rPettyCashOperation);
			
			int nAfterGenerate1 = t.testConn.RUN_SELECT_COUNT("epexp", filterRelated, false);
			Assert.AreEqual(nAfterGenerate1, nBefore1);
			t.deleteEp(rPettyCashOperation);
			int nAfterDelete = t.testConn.RUN_SELECT_COUNT("epexp", filterRelated, false);
			Assert.AreEqual(0, nAfterDelete);
			t.generateEP(rPettyCashOperation);
			int nAfterGenerate = t.testConn.RUN_SELECT_COUNT("epexp", filterRelated, false);
			Assert.AreEqual(nBefore1, nAfterGenerate);
		}

		[TestMethod]
		public void testDeleteEPFromCasualContract() {
			var t= new TestHelp(new DateTime(2019,12,31));
			//ycon, ncon
			//cascon§2019§3
			q filterCasualContract=  q.eq("ycon", 2019) & q.eq("ncon", 3);
			DataTable tCasualContract= t.testConn.readTable("casualcontract",filterCasualContract);
			Assert.AreEqual(1, tCasualContract.Rows.Count, "L'operazione fondo economale esiste");
			DataRow rCasualContract = tCasualContract.Rows[0];
			t.binaryCopySet(filterCasualContract, t.getTableSet(TestHelp.mainObject.casualcontract));
			t.binaryReplaceEp(rCasualContract,false);
			var idrelated= BudgetFunction.GetIdForDocument(rCasualContract);
			string filterRelated = BudgetFunction.getDocChildCondition(t.testConn.GetQueryHelper(), idrelated);
			int nBefore1 = t.testConn.RUN_SELECT_COUNT("epexp", filterRelated, false);
			t.generateEP(rCasualContract);

			string table;

			int nBefore = t.testConn.RUN_SELECT_COUNT("epexp", filterRelated, false);
			Assert.AreNotEqual(0, nBefore);
			t.deleteEp(rCasualContract);
			int nAfterDelete = t.testConn.RUN_SELECT_COUNT("epexp", filterRelated, false);
			Assert.AreEqual(0, nAfterDelete);
			t.generateEP(rCasualContract);
			int nAfterGenerate = t.testConn.RUN_SELECT_COUNT("epexp", filterRelated, false);
			Assert.AreEqual(nBefore, nAfterGenerate);
		}

		[TestMethod]
		public void testDeleteEPFromWageAddition() {
			var t= new TestHelp(new DateTime(2019,12,31));
			//ycon, ncon
			//wageadd§2019§2
			q filterWageAddition=  q.eq("ycon", 2019) & q.eq("ncon", 2);
			DataTable tWageAddition= t.testConn.readTable("wageaddition",filterWageAddition);
			Assert.AreEqual(1, tWageAddition.Rows.Count, "L'operazione fondo economale esiste");
			DataRow rWageAddition = tWageAddition.Rows[0];
			t.binaryCopySet(filterWageAddition, t.getTableSet(TestHelp.mainObject.wageaddition));
			t.binaryReplaceEp(rWageAddition,false);
			var idrelated= BudgetFunction.GetIdForDocument(rWageAddition);
			string filterRelated = BudgetFunction.getDocChildCondition(t.testConn.GetQueryHelper(), idrelated);
			int nBefore1 = t.sampleConn.RUN_SELECT_COUNT("epexp", filterRelated, false);
			t.generateEP(rWageAddition);

			string table;

			int nAfter1 = t.testConn.RUN_SELECT_COUNT("epexp", filterRelated, false);
			Assert.AreEqual(nBefore1, nAfter1);
			t.deleteEp(rWageAddition);
			int nAfterDelete = t.testConn.RUN_SELECT_COUNT("epexp", filterRelated, false);
			Assert.AreEqual(0, nAfterDelete);
			t.generateEP(rWageAddition);
			int nAfterGenerate = t.testConn.RUN_SELECT_COUNT("epexp", filterRelated, false);
			Assert.AreEqual(nBefore1, nAfterGenerate);
		}

		[TestMethod]
		public void testQuadraturaScritturaEP() {
			var t= new TestHelp(new DateTime(2019,12,31));
		    q filterEntry=  q.eq("yentry", 2019) & q.eq("nentry", 1);
		    t.binaryCopySet(filterEntry, t.getTableSet(TestHelp.mainObject.entry));
		    t.testConn.SQLRunner("exec rebuild_entrytotal 2019");
		
			DataTable tEntry = t.testConn.readTable("entry",filterEntry);
			DataTable tEntryDetail = t.testConn.readTable("entrydetail",filterEntry);
			Assert.AreEqual(1, tEntry.Rows.Count, "La scrittura esiste");
			decimal amount = CfgFn.GetNoNullDecimal(tEntryDetail.Compute("sum(amount)",null));
			Assert.AreEqual(0, amount,"La scrittura quadra (sum(amount)=0)");
		}

		[TestMethod]
		public void testQuadraturaScritturaEPTotalizzatore() {
			var t= new TestHelp(new DateTime(2018,12,31));
		    q filterEntry=   q.eq("yentry", 2018) & q.eq("nentry", 1);
		    t.binaryCopySet(filterEntry, t.getTableSet(TestHelp.mainObject.entry));
		    t.testConn.SQLRunner("exec rebuild_entrytotal 2018");

			DataTable tEntry = t.testConn.readTable("entrytotal",filterEntry);
			Assert.AreEqual(1, tEntry.Rows.Count, "La scrittura esiste");
			Assert.AreEqual(0, CfgFn.GetNoNullDecimal(tEntry.Rows[0]["amount"]), "Il totalizzatore della scritture è 0");
		}

		[TestMethod]
        public void testcheckImpegnoBudgetCPassivo() {
            var t= new TestHelp(new DateTime(2018,12,31));
            q filterMan = q.eq("idmankind", "B_ORDINE_comm_DFARM") & q.eq("yman", 2018) & q.eq("nman", 5);
            DataTable tMandate = t.testConn.readTable("mandate",filterMan);
            Assert.IsTrue(t.checkImpegnoBudget(tMandate.Rows[0],
                    withChild:true,
                preImpegno:true,
                    codiceConto: "CN1.2.05.01.003", 
                    codiceUPB:"RCEpiralitABC17",
                    filterDetail: q.eq("amount", 227.03)),"Preimpegno con conto, importo, upb presente su ordine");
            Assert.IsTrue(t.checkImpegnoBudget(tMandate.Rows[0],
                withChild:true,
                preImpegno:false,
                codiceConto: "CN1.2.05.01.003", 
                codiceUPB:"RCEpiralitABC17",
                filterDetail: q.eq("amount", 227.03)),"Impegno con conto, importo, upb presente su ordine");
        }

        [TestMethod]
        public void testcheckImpegnoBudgetCPassivoDetail() {
            var t= new TestHelp(new DateTime(2018,12,31));
            q filterMan = q.eq("idmankind", "B_ORDINE_comm_DFARM") & q.eq("yman", 2018) & q.eq("nman", 5) & q.eq("rownum",4);
            DataTable tMandateDetail = t.testConn.readTable("mandatedetail",filterMan);
            Assert.IsTrue(t.checkImpegnoBudget(tMandateDetail.Rows[0],
                withChild:false,
                preImpegno:true,
                codiceConto: "CN1.2.08.14.012", 
                codiceUPB:"RCEpiralitABC17",
                filterDetail: q.eq("amount", 70)),"Preimpegno con conto, importo, upb presente su dettaglio ordine");
            Assert.IsTrue(t.checkImpegnoBudget(tMandateDetail.Rows[0],
                withChild:false,
                preImpegno:false,
                codiceConto: "CN1.2.08.14.012", 
                codiceUPB:"RCEpiralitABC17",
                filterDetail: q.eq("amount", 70.0)),"Impegno con conto, importo, upb presente su dettaglio ordine");
        }

        [TestMethod]
        public void testcheckAccertamentoBudgetCAttivoDetail() {
            var t= new TestHelp(new DateTime(2018,12,31));
            q filterMan = q.eq("idestimkind", "CONTOTERZI-amm") & q.eq("yestim", 2018) & q.eq("nestim", 9) & q.eq("rownum",7);
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail",filterMan);
            Assert.IsTrue(t.checkAccertamentoBudget(tEstimateDetail.Rows[0],
                withChild:false,
                preAccertamento:true,
                codiceConto: "CP1.5.01.01.022", 
                codiceUPB:"DCVsdssRESIDENZE",
                filterDetail: q.eq("amount", 227.27)),"Preimpegno con conto, importo, upb presente su dettaglio ordine");
            Assert.IsTrue(t.checkAccertamentoBudget(tEstimateDetail.Rows[0],
                withChild:false,
                preAccertamento:false,
                codiceConto: "CP1.5.01.01.022", 
                codiceUPB:"DCVsdssRESIDENZE",
                filterDetail: q.eq("amount", 227.27)),"Impegno con conto, importo, upb presente su dettaglio ordine");
        }


        [TestMethod]
        public void testcheckAccertamentoBudgetCAttivo() {
            var t= new TestHelp(new DateTime(2018,12,31));
            q filterMan = q.eq("idestimkind", "CONTOTERZI-amm") & q.eq("yestim", 2018) & q.eq("nestim", 9) ;
            DataTable tEstimate = t.testConn.readTable("estimate",filterMan);
            Assert.IsTrue(t.checkAccertamentoBudget(tEstimate.Rows[0],
                withChild:true,
                preAccertamento:true,
                codiceConto: "CP1.5.01.01.022", 
                codiceUPB:"DCVsdssRESIDENZE",
                filterDetail: q.eq("amount", 227.27)),"Preaccertamento con conto, importo, upb presente su dettaglio ordine");
            Assert.IsTrue(t.checkAccertamentoBudget(tEstimate.Rows[0],
                withChild:true,
                preAccertamento:false,
                codiceConto: "CP1.5.01.01.022", 
                codiceUPB:"DCVsdssRESIDENZE",
                filterDetail: q.eq("amount", 227.27)),"Preaccertamento con conto, importo, upb presente su dettaglio ordine");
        }

        [TestMethod]
        public void testcheckScrittureDistintaPagamento() {
            var t= new TestHelp(new DateTime(2018,12,31));
            q filterDoc = q.eq("ypaymenttransmission", 2018) & q.eq("npaymenttransmission", 112)  ;
            DataTable tPaymentTrasm = t.testConn.readTable("paymenttransmission",filterDoc);
            Assert.IsTrue(t.checkScritturaAvere(tPaymentTrasm.Rows[0],
                importo: 25.70m,
                codiceConto:"PA2.4.01.02.001",
                codiceUPB:"AIVdigspSERVIZI_GENERALI",
                filterDetail:q.eq("description","Liquidazione n° 6962/2018 Mand.  n° 2494/2018")));
            Assert.IsTrue(t.checkScritturaDare(tPaymentTrasm.Rows[0],
                importo: 66.23m,
                codiceConto:"PA2.4.02.01.001",
                codiceUPB:"AIVdigspSERVIZI_GENERALI",                
                filterDetail:q.eq("description","Liquidazione n° 6963/2018 Mand.  n° 2494/2018")));
        }

        [TestMethod]
        public void testcheckScrittureCPassivo() {
            var t= new TestHelp(new DateTime(2018,12,31));
            q filterDoc = q.eq("idmankind", "TASSE_IMPOSTE") & q.eq("yman", 2018) & q.eq("nman", 23)  ;
            DataTable tDoc = t.testConn.readTable("mandate",filterDoc);
            Assert.IsTrue(t.checkScritturaAvere(tDoc.Rows[0],
                importo: 48.10m,
                codiceConto:"PP4.1.01.02.006",
                codiceUPB:"RIEsavoiapRICFIN14-17",
                codiceCausale:"CN1.2.08.14.012",
                filterDetail:q.eq("description","Contratto passivo TASSE_IMPOSTE n.23 / 2018")));
            Assert.IsTrue(t.checkScritturaDare(tDoc.Rows[0],
                importo: 4.49m,
                codiceConto:"CN1.2.08.06.003",
                codiceUPB:"RIEsavoiapRICFIN14-17",
                codiceCausale:"CN1.2.08.06.003",
                filterDetail:q.eq("description","IVA Extraue - American Journal Experts - Invoice# S68Y4FL6Q of 23 jan 2018. Commissioni_bancarie. Imponibile al 22%  € 20,39")));
        }

        //[TestMethod]
        //public void testDownloadGiornaleCassa() {
        //    var t = new TestHelp(new DateTime(2018, 12, 31));
        //    var qhs = t.testConn.GetQueryHelper();
        //    DateTime inizio = DateTime.Now;
        //    DateTime fine = DateTime.Now;
        //    var errore = string.Empty;
        //    ImportaEsiti IE = new ImportaEsiti();
        //    try {
        //        errore = IE.ImportaDaWS(inizio, fine);
        //    }
        //    catch (Exception e) {
        //        errore = e.Message + " " + e.ToString();
        //    }
        //    Assert.AreEqual(errore, string.Empty, "DownloadGiornaleCassa eseguito senza errori.");

        //}

    }
}
