/*
    Easy
    Copyright (C) 2019 Universit� degli Studi di Catania (www.unict.it)

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

﻿using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    /// Summary description for test_EP
    /// </summary>
    [TestClass]
    public class test_EP {
        public test_EP() {
            //
            // TODO: Add constructor logic here
            //
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
        public void Test_mandate_contratto_studenti() {
            var t = new TestHelp(new DateTime(2018, 12, 31));
            //TASSE_IMPOSTE 2018 1 
            q filterMan = q.eq("idmankind", "TASSE_IMPOSTE") & q.eq("yman", 2018) & q.eq("nman", 1);
            t.binaryReplaceSet(filterMan, t.getTableSet(TestHelp.mainObject.mandate));
            DataTable tMandate = t.testConn.readTable("mandate", filterMan);
            DataTable tMandateDetail = t.testConn.readTable("mandatedetail", filterMan);
            int nManDet = tMandateDetail.Rows.Count;
            Assert.AreEqual(1, tMandate.Rows.Count, "Il contratto esiste");
            DataRow rMan = tMandate.Rows[0];
            t.deleteEp(rMan);
            t.generateEP(rMan);
            var dsEP = t.getEpData(t.testConn, rMan);
            Assert.AreEqual(nManDet * 2, dsEP.Tables["entrydetail"].Rows.Count,
                "Ci sono dettagli pari al doppio dei dett. contratti");

            var taxableTotal = tMandateDetail._Filter(null)
                ._Reduce<decimal, DataRow>((x, r) => x = x + CfgFn.GetNoNullDecimal(r["taxable"]), 0);
            var avere = (decimal) dsEP.Tables["entrydetail"]._Filter(q.gt("amount", 0)).GetSum<decimal>("amount");
            var dare = (decimal) dsEP.Tables["entrydetail"]._Filter(q.lt("amount", 0)).GetSum<decimal>("amount");
            Assert.AreEqual(taxableTotal, -dare, "Dare pari all'imponibile");
            Assert.AreEqual(taxableTotal, avere, "Avere pari all'imponibile");
        }

        [TestMethod]
        public void Test_mandate_dettagli_attivi() {
            var t = new TestHelp(new DateTime(2018, 12, 31));
            for (int nMandate = 1; nMandate <= 5; nMandate++) {
                //TASSE_IMPOSTE 2018 1 
                q filterMan = q.eq("idmankind", "VARI_GEST_nofattura") & q.eq("yman", 2018) & q.eq("nman", nMandate);
                t.binaryReplaceSet(filterMan, t.getTableSet(TestHelp.mainObject.mandate));
                DataTable tMandate = t.testConn.readTable("mandate", filterMan);
                DataTable tMandateDetail = t.testConn.readTable("mandatedetail", filterMan & q.isNull("stop"));
                int nManDet = tMandateDetail.Rows.Count;
                Assert.AreEqual(1, tMandate.Rows.Count, "Il contratto esiste");
                DataRow rMan = tMandate.Rows[0];
                t.deleteEp(rMan);
                t.generateEP(rMan);
                var dsEP = t.getEpData(t.testConn, rMan);
                Assert.AreEqual(nManDet * 2, dsEP.Tables["entrydetail"].Rows.Count,
                    $"Ci sono dettagli pari al doppio dei dett. del contratto VARI_GEST_nofattura/2018/{nMandate} ");

                var taxableTotal = tMandateDetail._Filter(null)
                    ._Reduce<decimal, DataRow>((x, r) => x = x + CfgFn.GetNoNullDecimal(r["taxable"]), 0);
                var avere = (decimal) dsEP.Tables["entrydetail"]._Filter(q.gt("amount", 0)).GetSum<decimal>("amount");
                var dare = (decimal) dsEP.Tables["entrydetail"]._Filter(q.lt("amount", 0)).GetSum<decimal>("amount");
                Assert.AreEqual(taxableTotal, -dare, "Dare pari all'imponibile");
                Assert.AreEqual(taxableTotal, avere, "Avere pari all'imponibile");

            }
        }

        [TestMethod]
        public void Test_mandate_dettagli_annullati() {
            var t = new TestHelp(new DateTime(2018, 12, 31));
            //TASSE_IMPOSTE 2018 1 
            q filterMan = q.eq("idmankind", "VARI_GEST_nofattura") & q.eq("yman", 2018) & q.eq("nman", 4);
            t.binaryReplaceSet(filterMan, t.getTableSet(TestHelp.mainObject.mandate));
            DataTable tMandate = t.testConn.readTable("mandate", filterMan);
            DataTable tMandateDetail = t.testConn.readTable("mandatedetail", filterMan);
            int nManDet = tMandateDetail.Rows.Count;
            Assert.AreEqual(1, tMandate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(tMandate.Rows[0]);

            Assert.AreEqual(2, tMandateDetail.Rows.Count, "Ha  due dettagli");
            Assert.AreNotEqual(DBNull.Value, tMandateDetail.Rows[0]["stop"], "Il dettaglio è annullato");
            object idepexp1 = tMandateDetail.Rows[0]["idepexp"];
            Assert.AreNotEqual(DBNull.Value, idepexp1, "Il dettaglio 1 ha impegno di budget");
            object idepexp2 = tMandateDetail.Rows[1]["idepexp"];
            Assert.AreNotEqual(DBNull.Value, idepexp2, "Il dettaglio 2 ha impegno di budget");

            DataRow rMan = tMandate.Rows[0];
            t.deleteEp(rMan);
            t.generateEP(rMan);
            var dsEP = t.getEpData(t.testConn, rMan);
            Assert.AreEqual(0, dsEP.Tables["entrydetail"].Rows.Count,
                "Non ci sono dettagli scrittura per dettaglio annullato senza impegno budget");

            var taxableTotal = tMandateDetail._Filter(null)
                ._Reduce<decimal, DataRow>((x, r) => x = x + CfgFn.GetNoNullDecimal(r["taxable"]), 0);
            var avere = (decimal) dsEP.Tables["entrydetail"]._Filter(q.gt("amount", 0)).GetSum<decimal>("amount");
            var dare = (decimal) dsEP.Tables["entrydetail"]._Filter(q.lt("amount", 0)).GetSum<decimal>("amount");
            Assert.AreEqual(0, -dare, "Dare pari a zero");
            Assert.AreEqual(0, avere, "Avere pari a zero");
            Assert.AreEqual(0, dsEP.Tables["epexp"].Rows.Count, "Nessun impegno rigenerato per il dettaglio.");
        }

        [TestMethod]
        public void Test_mandate_no_scritture_con_sconto() {
            var t = new TestHelp(new DateTime(2018, 12, 31));
            q filterMan = q.eq("idmankind", "B_ORDINE_comm_DFARM") & q.eq("yman", 2018) & q.eq("nman", 1);
            t.binaryReplaceSet(filterMan, t.getTableSet(TestHelp.mainObject.mandate));
            DataTable tMandate = t.testConn.readTable("mandate", filterMan);
            DataTable tMandateDetail = t.testConn.readTable("mandatedetailview", filterMan & q.isNull("stop"));
            int nManDet = tMandateDetail.Rows.Count;
            Assert.AreEqual(1, tMandate.Rows.Count, "Il contratto esiste");
            DataRow rMan = tMandate.Rows[0];
            t.deleteEp(rMan);
            t.generateEP(rMan);
            var dsEP = t.getEpData(t.testConn, rMan);
            Assert.AreEqual(0, dsEP.Tables["entrydetail"].Rows.Count,$"Non ci sono scritture");

            var totImpegni = (decimal) dsEP.Tables["epexpyear"]._Filter(q.eq("ayear",2018)).GetSum<decimal>("amount");
            Assert.AreEqual(1571.22m, totImpegni, "Totale impegni pari all'imponibile netto");
            Assert.AreEqual(nManDet,dsEP.Tables["epexp"]._Filter(q.eq("nphase",1)).Length);
            Assert.AreEqual(nManDet,dsEP.Tables["epexp"]._Filter(q.eq("nphase",2)).Length);            
        }

        //
    }
}
