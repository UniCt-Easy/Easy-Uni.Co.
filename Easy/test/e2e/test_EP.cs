
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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using metadatalibrary;
using TestHelper;
using q = metadatalibrary.MetaExpression;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using funzioni_configurazione;
using metaeasylibrary;
using ep_functions;
using generaSQL;

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

        #region Test Contratti Passivi e Attivi
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
            ProcedureMessageCollection regole = t.generateEP(rMan);

            var dsEP = t.getEpData(t.testConn, rMan);
            Assert.AreEqual(nManDet * 2, dsEP.Tables["entrydetail"].Rows.Count,
                "Ci sono dettagli pari al doppio dei dett. contratti");

            var taxableTotal = tMandateDetail._Filter(null)
                ._Reduce<decimal, DataRow>((x, r) => x += CfgFn.GetNoNullDecimal(r["taxable"]), 0);
            var avere = (decimal)dsEP.Tables["entrydetail"]._Filter(q.gt("amount", 0)).GetSum<decimal>("amount");
            var dare = (decimal)dsEP.Tables["entrydetail"]._Filter(q.lt("amount", 0)).GetSum<decimal>("amount");
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
                metaeasylibrary.Easy_PostData.rulesToIgnore.Add("ECOPA047");
                t.generateEP(rMan);
                metaeasylibrary.Easy_PostData.rulesToIgnore.Clear();
                var dsEP = t.getEpData(t.testConn, rMan);
                Assert.AreEqual(nManDet * 2, dsEP.Tables["entrydetail"].Rows.Count,
                    $"Ci sono dettagli pari al doppio dei dett. del contratto VARI_GEST_nofattura/2018/{nMandate} ");

                var taxableTotal = tMandateDetail._Filter(null)
                    ._Reduce<decimal, DataRow>((x, r) => x = x + CfgFn.GetNoNullDecimal(r["taxable"]), 0);
                var avere = (decimal)dsEP.Tables["entrydetail"]._Filter(q.gt("amount", 0)).GetSum<decimal>("amount");
                var dare = (decimal)dsEP.Tables["entrydetail"]._Filter(q.lt("amount", 0)).GetSum<decimal>("amount");
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
            var avere = (decimal)dsEP.Tables["entrydetail"]._Filter(q.gt("amount", 0)).GetSum<decimal>("amount");
            var dare = (decimal)dsEP.Tables["entrydetail"]._Filter(q.lt("amount", 0)).GetSum<decimal>("amount");
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

            Assert.AreEqual(0, dsEP.Tables["entrydetail"].Rows.Count, $"Non ci sono scritture");

            var totImpegni = (decimal)dsEP.Tables["epexpyear"]._Filter(q.eq("ayear", 2018)).GetSum<decimal>("amount");
            Assert.AreEqual(1571.22m, totImpegni, "Totale impegni pari all'imponibile netto");
            Assert.AreEqual(nManDet, dsEP.Tables["epexp"]._Filter(q.eq("nphase", 1)).Length);
            Assert.AreEqual(nManDet, dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2)).Length);
            }

        [TestMethod]
        public void Test_contratto_passivo_ImpVarBudget() {
            var t = new TestHelp(new DateTime(2018, 12, 31));
            // Tipo contratto passivo B_ORDINE_comm_DIPSS, Esercizio 2018 , Numero 31  
            q filterMan = q.eq("idmankind", "B_ORDINE_comm_DIPSS") & q.eq("yman", 2018) & q.eq("nman", 31);
            t.binaryReplaceSet(filterMan, t.getTableSet(TestHelp.mainObject.mandate));
            DataTable tMandate = t.testConn.readTable("mandate", filterMan);
            Assert.AreEqual(1, tMandate.Rows.Count, "Il contratto esiste");
            DataRow rMan = tMandate.Rows[0];

            DataTable tMandateDetail = t.testConn.readTable("mandatedetail", filterMan);
            int nEstDet = tMandateDetail.Rows.Count;
            Assert.AreEqual(3, nEstDet, "Il contratto  ha dettagli");
            DataRow mandDet1 = tMandateDetail.Rows[0];
            //480232 analisi dottoranda
            var idepex1 = mandDet1["idepexp"];
            DataRow mandDet2 = tMandateDetail.Rows[1];
            //480233 analisi soggetti esterni
            var idepexp2 = mandDet2["idepexp"];
            DataRow mandDet3 = tMandateDetail.Rows[2];
            //494574 bollo
            var idepexp3 = mandDet3["idepexp"];


            t.binaryCopyEp(rMan, false);

            //CONTROLLO PER REGOLE 
            ProcedureMessageCollection regole = t.generateEP(rMan);
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");

            var dsEP = t.getEpData(t.testConn, rMan);

            //VERIFICA VARIAZIONI 
            DataRow[] rEpexpvar = dsEP.Tables["epexpvar"]._Filter(null);
            Assert.AreEqual(0, rEpexpvar.Count(), "Non ci sono variazioni");

            //PRIMO IMPEGNO VAR. BUDGET ASSOCIATO AL CONTRATTO PASSIVO
            DataRow[] rEpexp = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("idepexp", idepex1) & q.eq("yepexp", 2018));
            DataRow[] rEpexpyear = dsEP.Tables["epexpyear"]._Filter(q.eq("ayear", 2018) & q.eq("idepexp", idepex1));
            DataRow dr1_epexpyear = rEpexpyear[0];
            DataRow dr1_epexp = rEpexp[0];
            Assert.AreEqual(dr1_epexp["description"], "Iscrizione corso: \"Analisi e interpretazione dati nella genomica clinica\" GENOVA, 21 settembre 2018 Dott.ssa Fanelli (dottoranda)", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epexpyear["amount"], 100.00m, " L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexpyear["idacc"], "18000200010002000100040002", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexpyear["idupb"], "000100030001000200010063", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexp["idaccmotive"], "000600010002000100040002", "La causale del mov.budget è corrispondente");

            // SECONDO IMPEGNO VAR. BUDGET ASSOCIATO AL CONTRATTO PASSIVO
            DataRow[] rEpexp2 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("idepexp", idepexp2) & q.eq("yepexp", 2018));
            DataRow[] rEpexpyear2 = dsEP.Tables["epexpyear"]._Filter(q.eq("ayear", 2018) & q.eq("idepexp", idepexp2));
            DataRow dr2_epexpyear = rEpexpyear2[0];
            DataRow dr2_epexp = rEpexp2[0];
            Assert.AreEqual(dr2_epexp["description"], "Iscrizione corso: \"Analisi e interpretazione dati nella genomica clinica\" GENOVA, 21 settembre 2018 Dott.ssa Mellone (soggetti esterni)", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr2_epexpyear["amount"], 120.00m, " L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epexpyear["idacc"], "18000200010002000800100005", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epexpyear["idupb"], "000100030001000200010063", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epexp["idaccmotive"], "000600010002000600100005", "La causale del mov.budget è corrispondente");

            //TERZO IMPEGNO VAR. BUDGET ASSOCIATO AL CONTRATTO PASSIVO
            DataRow[] rEpexp3 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("idepexp", idepexp3) & q.eq("yepexp", 2018));
            DataRow[] rEpexpyear3 = dsEP.Tables["epexpyear"]._Filter(q.eq("ayear", 2018) & q.eq("idepexp", idepexp3));
            DataRow dr3_epexpyear = rEpexpyear3[0];
            DataRow dr3_epexp = rEpexp3[0];
            Assert.AreEqual(dr3_epexp["description"], "BOLLO", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr3_epexpyear["amount"], 4.00m, " L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr3_epexpyear["idacc"], "18000200010005000100010003", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr3_epexpyear["idupb"], "000100030001000200010063", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr3_epexp["idaccmotive"], "000600010005000100010003", "La causale del mov.budget è corrispondente");
            }

        [TestMethod]
        public void Test_contratto_passivo_Scritture() {
            var t = new TestHelp(new DateTime(2018, 12, 31));
            // Tipo contratto passivo LAV/FOR/SERnofattura, Esercizio 2018 , Numero 13  
            q filterMan = q.eq("idmankind", "LAV/FOR/SERnofattura") & q.eq("yman", 2018) & q.eq("nman", 13);
            t.binaryReplaceSet(filterMan, t.getTableSet(TestHelp.mainObject.mandate));
            DataTable tMandate = t.testConn.readTable("mandate", filterMan);
            Assert.AreEqual(1, tMandate.Rows.Count, "Il contratto esiste");
            DataRow rMan = tMandate.Rows[0];
            t.deleteEp(rMan);

            //CONTROLLO PER REGOLE 
            ProcedureMessageCollection regole = t.generateEP(rMan);
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");

            var dsEP = t.getEpData(t.testConn, rMan);

            bool scrittureabilitate = t.abilitaScrittureUT(rMan);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");

            var tEntrydetail = dsEP.Tables["entrydetail"];
            var tEntry = dsEP.Tables["entry"];
            DataRow[] rEpexp = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2));
            DataRow dr1_epexp = rEpexp[0];

            //VERIFICA VARIAZIONI 
            DataRow[] rEpexpvar = dsEP.Tables["epexpvar"]._Filter(null);
            Assert.AreEqual(0, rEpexpvar.Count(), "Non ci sono variazioni");

            var date_doc_colleg = new DateTime(2018, 9, 14);
            var date_contab = new DateTime(2018, 9, 20);
            Assert.AreEqual(tEntry.Rows[0]["description"], "Prot. 2018/0131134  - Responsabilità civile - FIAT DOBLO' - targa: DY903TL - dal 30/09/2018 al 30/09/2019", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(tEntry.Rows[0]["doc"], "Prot. 23153", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(tEntry.Rows[0]["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(tEntry.Rows[0]["adate"], date_contab, "La data contabile della scrittura è corrispondente");

            //PRIMO DETTAGLIO SCRITTURA
            Assert.AreEqual(tEntrydetail.Rows[0]["description"], "Contratto Passivo LAV/FOR/SERnofattura 18/13 dett. 1- Prot. 2018/0131134  - Responsabilità civile - FIAT DOBLO' - targa: DY903TL - dal 30/09/2018 al 30/09/2019", "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(tEntrydetail.Rows[0]["idacc"], "18000200010002000800080003", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(tEntrydetail.Rows[0]["idupb"], "000100020001000100010022", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(tEntrydetail.Rows[0]["idreg"], 11925, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(tEntrydetail.Rows[0]["idaccmotive"], "000600010002000600080003", "La causale del dettaglio della scrittura è corrispondente");

            //SECONDO DETTAGLIO SCRITTURA
            Assert.AreEqual(tEntrydetail.Rows[1]["description"], "Contratto passivo LAV/FOR/SERnofattura n.13 / 2018 dett. 1", "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(tEntrydetail.Rows[1]["idacc"], "18000400040001000100090001", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(tEntrydetail.Rows[1]["idupb"], "000100020001000100010022", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(tEntrydetail.Rows[1]["idreg"], 11925, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(tEntrydetail.Rows[1]["idaccmotive"], "000600010002000600080003", "La causale del dettaglio della scrittura è corrispondente");

            //CONTROLLO CORRISPONDENZA TRA SCRITTURA E MOVIMENTO DI BUDGET
            Assert.AreEqual(tEntrydetail.Rows[0]["idepexp"], dr1_epexp["idepexp"]);
            Assert.AreEqual(tEntrydetail.Rows[0]["idrelated"], dr1_epexp["idrelated"]);

            //CONTROLLO CORRISPONDENZA TRA SCRITTURA E MOVIMENTO DI BUDGET
            Assert.AreEqual(tEntrydetail.Rows[1]["idepexp"], dr1_epexp["idepexp"]);
            Assert.AreEqual(tEntrydetail.Rows[1]["idrelated"], dr1_epexp["idrelated"]);

            }

        [TestMethod]
        public void Test_Scrittu_mandate_2017_dettagli_annullati_NonCollFattura() {
            //VARI_GEST_nofattura	2017	210
            var t = new TestHelp(new DateTime(2018, 12, 31));
            q filterMan = q.eq("idmankind", "VARI_GEST_nofattura") & q.eq("yman", 2017) & q.eq("nman", 210);
            t.binaryReplaceSet(filterMan, t.getTableSet(TestHelp.mainObject.mandate));
            DataTable tMandate = t.testConn.readTable("mandate", filterMan);
            Assert.AreEqual(1, tMandate.Rows.Count, "Il contratto esiste");
            DataTable tMandateDetail = t.testConn.readTable("mandatedetail", filterMan & q.isNotNull("stop"));
            int nManDet = tMandateDetail.Rows.Count;
            Assert.AreNotEqual(0, nManDet, "Il contratto non ha dettagli");
            DataRow rMan = tMandate.Rows[0];
            t.binaryCopyEp(rMan, false);

            //CONTROLLO PER REGOLE 
            ProcedureMessageCollection regole = t.generateEP(rMan);
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rMan);

            bool scrittureabilitate = t.abilitaScrittureUT(rMan);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");

            var tEntrydetail = dsEP.Tables["entrydetail"];
            var tEntry = dsEP.Tables["entry"];
            DataRow[] rEpexp = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2));
            DataRow dr1_epexp = rEpexp[0];

            var date_doc_colleg = new DateTime(2017, 7, 5);
            var date_contab = new DateTime(2017, 7, 6);
            Assert.AreEqual(tEntry.Rows[0]["description"], "Perdita su cambio Invoice 339370", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(tEntry.Rows[0]["nentry"], 8503, " NUMERO SCRITTURA description ok");
            Assert.AreEqual(tEntry.Rows[0]["doc"], "Provvisorio uscita 394", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(tEntry.Rows[0]["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(tEntry.Rows[0]["adate"], date_contab, "La data contabile della scrittura è corrispondente");

            //PRIMO DETTAGLIO SCRITTURA
            var descr1 =
                 "Perdita su cambi";
            q filterEDetail1 = q.eq("description", descr1) & q.eq("idacc", "170002001700010003");
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1);
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(EntryDetail1["idupb"], "000100030003000200020676", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idreg"], 123934, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idaccmotive"], "000200170003", "La causale del dettaglio della scrittura è corrispondente");

            //SECONDO DETTAGLIO SCRITTURA
            var descr2 =
                 "Perdita su cambi";
            q filterEDetail2 = q.eq("description", descr2) & q.eq("idacc", "170004000600090001");
            var EntryDetail2Rows = tEntrydetail._Filter(filterEDetail2);
            var EntryDetail2 = EntryDetail2Rows[0];
            Assert.AreEqual(EntryDetail2["idupb"], "000100030003000200020676", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idreg"], 123934, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idaccmotive"], "000200170003", "La causale del dettaglio della scrittura è corrispondente");

            }

        //[TestMethod]
        //public void Test_ImpVar_estimate_2018_dettagli_annullati()
        //{
        //    var t = new TestHelp(new DateTime(2018, 12, 31));
        //    q filterEst = q.eq("idestimkind", "DOCAMM-dimet") & q.eq("yestim", 2018) & q.eq("nestim", 17);
        //    t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
        //    DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
        //    Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
        //    DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst & q.isNotNull("stop"));
        //    int nEstDet = tEstimateDetail.Rows.Count;
        //    Assert.AreNotEqual(0, nEstDet, "Il contratto non ha dettagli");
        //    DataRow rEst = tEstimate.Rows[0];
        //    var dsEP = t.getEpData(t.testConn, rEst);
        //    t.deleteEp(rEst);

        //    //CONTROLLO PER REGOLE 
        //    ProcedureMessageCollection regole = t.generateEP(rEst);
        //    if(regole != null) 
        //        Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");

        //    DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2));
        //    DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2018));

        //    //VERIFICA VARIAZIONI AI MOVIMENTI DI BUDGET
        //    DataRow[] rEpaccpvar = dsEP.Tables["epaccvar"]._Filter(null);
        //    Assert.AreEqual(rEpaccpvar.Length, 2 , "Sono  presenti 2 variazioni");
        //    DataRow dr1_Epaccvr = rEpaccpvar[0];
        //    decimal totale = CfgFn.GetNoNullDecimal(dr1_Epaccvr["amount"]);
        //    for (int i = 2; i <= 5; i++)
        //    {
        //        totale += CfgFn.GetNoNullDecimal(dr1_Epaccvr["amount" + i.ToString()]);
        //    }
        //    Assert.AreEqual(totale, -33000.00m, "L'importo totale della variazione è corrispondente");


        //    var tEntrydetail = dsEP.Tables["entrydetail"];
        //    //PRIMO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO
        //    DataRow dr1_epacc = rEpacc[0];
        //    DataRow dr1_epaccyear = rEpaccyear[0];
        //    Assert.AreEqual(dr1_epacc["description"], "Finanziamento Ass.SviluppoUniversTerritorio Novarese borse di studio Studenti/Assegnisti periodi formativi INTERNAZION USCITA_DIMET-DIPSS 17/18  ", "La descrizione del mov.budget  è corrispondente");
        //    Assert.AreEqual(dr1_epaccyear["amount"], 33000.00m, "L'importo del mov.budget è corrispondente");
        //    Assert.AreEqual(dr1_epaccyear["idacc"], "18000100010002000700010008", "Il n.conto del mov.budget è corrispondente");
        //    Assert.AreEqual(dr1_epaccyear["idupb"], "000100030002000200020016", "L'UPB del mov.budget è corrispondente");
        //    Assert.AreEqual(dr1_epacc["idaccmotive"], "000700010002000700010008", "La causale del mov.budget è corrispondente");

        //    //CONTROLLO CORRISPONDENZA TRA SCRITTURA E MOVIMENTO DI BUDGET
        //    Assert.AreEqual(tEntrydetail.Rows[0]["idepacc"], dr1_epacc["idepacc"]);
        //    Assert.AreEqual(tEntrydetail.Rows[0]["idrelated"], dr1_epacc["idrelated"]);

        //}

        //[TestMethod]
        //public void Test_Scrittu_estimate_2018_dettagli_annullati()
        //{
        //    var t = new TestHelp(new DateTime(2018, 12, 31));
        //    q filterEst = q.eq("idestimkind", "CONTOTERZI-digspes") & q.eq("yestim", 2018) & q.eq("nestim", 24);
        //    t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
        //    DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
        //    Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
        //    DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst & q.isNotNull("stop"));
        //    int nEstDet = tEstimateDetail.Rows.Count;
        //    Assert.AreNotEqual(0, nEstDet, "Il contratto non ha dettagli");
        //    DataRow rEst = tEstimate.Rows[0];
        //    var dsEP = t.getEpData(t.testConn, rEst);
        //    t.deleteEp(rEst);

        //    //CONTROLLO PER REGOLE 
        //    ProcedureMessageCollection regole = t.generateEP(rEst);
        //    if(regole != null) Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");

        //    Assert.AreEqual(0, dsEP.Tables["entrydetail"].Rows.Count, $"Non ci sono scritture");
        //}


        [TestMethod]
        public void Test_Scrittu_estimate_2017_dettagli_annullati_NonCollFattura() {
            var t = new TestHelp(new DateTime(2018, 12, 31));
            q filterEst = q.eq("idestimkind", "DOCAMM-simnova") & q.eq("yestim", 2017) & q.eq("nestim", 87);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst & q.isNotNull("stop"));
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreNotEqual(0, nEstDet, "Il contratto non ha dettagli");
            DataRow rEst = tEstimate.Rows[0];
            var dsEP = t.getEpData(t.testConn, rEst);
            t.deleteEp(rEst);

            //CONTROLLO PER REGOLE 
            ProcedureMessageCollection regole = t.generateEP(rEst);
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");

            bool scrittureabilitate = t.abilitaScrittureUT(rEst);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");

            var tEntrydetail = dsEP.Tables["entrydetail"];
            var tEntry = dsEP.Tables["entry"];
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2));
            DataRow dr1_epacc = rEpacc[0];

            var date_doc_colleg = new DateTime(2017, 6, 22);
            var date_contab = new DateTime(2017, 9, 25);
            Assert.AreEqual(tEntry.Rows[0]["description"], "Corso di formazione per idoneità attività di emergenza sanitaia territoriale 118 - anno 2017", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(tEntry.Rows[0]["nentry"], 12387, " NUMERO SCRITTURA description ok");
            Assert.AreEqual(tEntry.Rows[0]["doc"], "Prot 10229", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(tEntry.Rows[0]["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(tEntry.Rows[0]["adate"], date_contab, "La data contabile della scrittura è corrispondente");

            //PRIMO DETTAGLIO SCRITTURA
            Assert.AreEqual(tEntrydetail.Rows[0]["description"], "Corso di formazione per idoneità attività di emergenza sanitaia territoriale 118 - anno 2017 - prima tranche", "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(tEntrydetail.Rows[0]["idacc"], "170001000400030009", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(tEntrydetail.Rows[0]["idupb"], "000100020003000100010014", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(tEntrydetail.Rows[0]["idreg"], 51, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(tEntrydetail.Rows[0]["idaccmotive"], "0001000400030009", "La causale del dettaglio della scrittura è corrispondente");

            //SECONDO DETTAGLIO SCRITTURA
            Assert.AreEqual(tEntrydetail.Rows[1]["description"], "Contratto attivo DOCAMM-simnova n.87 / 2017", "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(tEntrydetail.Rows[1]["idacc"], "170003000500080006", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(tEntrydetail.Rows[1]["idupb"], "000100020003000100010014", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(tEntrydetail.Rows[1]["idreg"], 51, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(tEntrydetail.Rows[1]["idaccmotive"], "0001000400030009", "La causale del dettaglio della scrittura è corrispondente");

            //CONTROLLO CORRISPONDENZA TRA SCRITTURA E MOVIMENTO DI BUDGET
            Assert.AreEqual(tEntrydetail.Rows[0]["idepacc"], dr1_epacc["idepacc"]);
            Assert.AreEqual(tEntrydetail.Rows[0]["idrelated"], dr1_epacc["idrelated"]);

            //CONTROLLO CORRISPONDENZA TRA SCRITTURA E MOVIMENTO DI BUDGET
            Assert.AreEqual(tEntrydetail.Rows[1]["idepacc"], dr1_epacc["idepacc"]);
            Assert.AreEqual(tEntrydetail.Rows[1]["idrelated"], dr1_epacc["idrelated"]);

            }

        [TestMethod]
        public void Test_Scrittu_estimate_2017_dettagli2018_dettagliAnnullati_CollFattura() {
            var t = new TestHelp(new DateTime(2018, 12, 31));
            q filterEst = q.eq("idestimkind", "CONTOTERZI-digspes") & q.eq("yestim", 2017) & q.eq("nestim", 39);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst & q.isNotNull("stop"));
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreNotEqual(0, nEstDet, "Il contratto non ha dettagli");
            DataRow rEst = tEstimate.Rows[0];

            t.binaryCopyEp(rEst, false);

            //CONTROLLO PER REGOLE 
            ProcedureMessageCollection regole = t.generateEP(rEst);
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rEst);

            var countDetScritt = dsEP.Tables["entrydetail"]._Filter(q.like("idrelated", "estim")).Length;
            Assert.AreEqual(0, countDetScritt, $"Non ci sono scritture poichè contratto collegabile a fattura");

            }

        [TestMethod]
        public void Test_ImpVar_estimate_2017_dettagli_annullati_NonCollFattura() {
            var t = new TestHelp(new DateTime(2018, 12, 31));
            q filterEst = q.eq("idestimkind", "DOCAMM-amm") & q.eq("yestim", 2017) & q.eq("nestim", 574);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst & q.isNotNull("stop"));
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreNotEqual(0, nEstDet, "Il contratto non ha dettagli");
            DataRow rEst = tEstimate.Rows[0];
            var dsEP = t.getEpData(t.testConn, rEst);
            t.deleteEp(rEst);

            //CONTROLLO PER REGOLE 
            ProcedureMessageCollection regole = t.generateEP(rEst);
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");

            bool scrittureabilitate = t.abilitaScrittureUT(rEst);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");

            //VERIFICA VARIAZIONI AI MOVIMENTI DI BUDGET
            DataRow[] rEpaccpvar = dsEP.Tables["epaccvar"]._Filter(null);
            Assert.AreEqual(rEpaccpvar.Length, 2, "Sono  presenti 2 variazioni");
            DataRow dr1_Epaccvr = rEpaccpvar[0];
            decimal totale = CfgFn.GetNoNullDecimal(dr1_Epaccvr["amount"]);
            for (int i = 2; i <= 5; i++) {
                totale += CfgFn.GetNoNullDecimal(dr1_Epaccvr["amount" + i.ToString()]);
                }
            Assert.AreEqual(totale, -30.00m, "L'importo totale della variazione è corrispondente");

            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2));
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2017));
            var tEntrydetail = dsEP.Tables["entrydetail"];
            //PRIMO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            Assert.AreEqual(dr1_epacc["description"], "Incasso ECDL", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epaccyear["amount"], 30.00m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idacc"], "170001000100010007", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idupb"], "000100020003000300010008", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["idaccmotive"], "000100010007", "La causale del mov.budget è corrispondente");

            //CONTROLLO CORRISPONDENZA TRA SCRITTURA E MOVIMENTO DI BUDGET
            Assert.AreEqual(tEntrydetail.Rows[0]["idepacc"], dr1_epacc["idepacc"]);
            Assert.AreEqual(tEntrydetail.Rows[0]["idrelated"], dr1_epacc["idrelated"]);

            }

        [TestMethod]
        public void Test_Scrittu_estimate_2018_dettagli_annullati_NonCollFattura() {
            var t = new TestHelp(new DateTime(2018, 12, 31));
            q filterEst = q.eq("idestimkind", "DOCAMM-amm") & q.eq("yestim", 2018) & q.eq("nestim", 3);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst & q.isNotNull("stop"));
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreNotEqual(0, nEstDet, "Il contratto non ha dettagli");
            DataRow rEst = tEstimate.Rows[0];
            t.binaryCopyEp(rEst, false);

            //CONTROLLO PER REGOLE 
            ProcedureMessageCollection regole = t.generaImpegniScritture(rEst);
            var dsEP = t.getEpData(t.testConn, rEst);
            Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");

            bool scrittureabilitate = t.abilitaScrittureUT(rEst);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");

            var tEntrydetail = dsEP.Tables["entrydetail"];
            var tEntry = dsEP.Tables["entry"];

            var date_doc_colleg = new DateTime(2018, 2, 1);
            var date_contab = new DateTime(2018, 2, 7);
            Assert.AreEqual(tEntry.Rows[0]["description"], "Rimborso costi energia elettrica locali CSI palazzina G VC07 - piazza S. Eusebio 5 Vercelli", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(tEntry.Rows[0]["doc"], "prot. 2872", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(tEntry.Rows[0]["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(tEntry.Rows[0]["adate"], date_contab, "La data contabile della scrittura è corrispondente");

            //PRIMO DETTAGLIO SCRITTURA
            var rdet1 = tEntrydetail._Filter(q.eq("description",
                                                 "Contratto Attivo DOCAMM-amm 18/3 dett. 1- Rimborso costi energia elettrica locali CSI palazzina G VC07 - piazza S. Eusebio 5 Vercelli")
                                             & q.eq("idacc", "18000100010005000100030005")).FirstOrDefault();
            Assert.IsNotNull(rdet1, "Dettaglio 1 con conto e descrizione desiderati trovato");

            Assert.AreEqual(rdet1["idupb"], "000100020002000600030020", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rdet1["idreg"], 828, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rdet1["idaccmotive"], "000700010005000100030005", "La causale del dettaglio della scrittura è corrispondente");

            //SECONDO DETTAGLIO SCRITTURA
            var rdet2 = tEntrydetail._Filter(q.eq("description", "Contratto attivo DOCAMM-amm n.3 / 2018 dett. 1")
                                             & q.eq("idacc", "18000300020002000100090003")).FirstOrDefault();
            Assert.IsNotNull(rdet2, "Dettaglio 1 con conto e descrizione desiderati trovato");
            Assert.AreEqual(rdet2["idupb"], "000100020002000600030020", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rdet2["idreg"], 828, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rdet2["idaccmotive"], "000700010005000100030005", "La causale del dettaglio della scrittura è corrispondente");

            }

        [TestMethod]
        public void Test_Scrittu_estimate_2018_dettagli_annullati_CollFattura() {
            var t = new TestHelp(new DateTime(2018, 12, 31));
            q filterEst = q.eq("idestimkind", "CONTOTERZI-disfar") & q.eq("yestim", 2018) & q.eq("nestim", 4);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst & q.isNotNull("stop"));
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreNotEqual(0, nEstDet, "Il contratto non ha dettagli");
            DataRow rEst = tEstimate.Rows[0];
            var dsEP = t.getEpData(t.testConn, rEst);
            t.deleteEp(rEst);

            //CONTROLLO PER REGOLE 
            ProcedureMessageCollection regole = t.generateEP(rEst);
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");


            Assert.AreEqual(0, dsEP.Tables["entrydetail"].Rows.Count, $"Non ci sono scritture poichè contratto collegabile a fattura");
            }

        //[TestMethod]
        //public void Test_ImpVar_estimate_2018_dettagli_annullati_NonCollFattura()
        //{
        //    var t = new TestHelp(new DateTime(2018, 12, 31));
        //    q filterEst = q.eq("idestimkind", "DOCAMM-dimet") & q.eq("yestim", 2018) & q.eq("nestim", 17);
        //    t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
        //    DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
        //    Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
        //    DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst & q.isNotNull("stop"));
        //    int nEstDet = tEstimateDetail.Rows.Count;
        //    Assert.AreNotEqual(0, nEstDet, "Il contratto non ha dettagli");
        //    DataRow rEst = tEstimate.Rows[0];
        //    var dsEP = t.getEpData(t.testConn, rEst);
        //    t.deleteEp(rEst);

        //    //CONTROLLO PER REGOLE 
        //    ProcedureMessageCollection regole = t.generateEP(rEst);
        //    if(regole != null) 
        //        Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");

        //    //VERIFICA VARIAZIONI AI MOVIMENTI DI BUDGET
        //    DataRow[] rEpaccpvar = dsEP.Tables["epaccvar"]._Filter(null);
        //    Assert.AreEqual(rEpaccpvar.Length, 2, "Sono  presenti 2 variazioni");
        //    DataRow dr1_Epaccvr = rEpaccpvar[0];
        //    decimal totale = CfgFn.GetNoNullDecimal(dr1_Epaccvr["amount"]);
        //    for (int i = 2; i <= 5; i++)
        //    {
        //        totale += CfgFn.GetNoNullDecimal(dr1_Epaccvr["amount" + i.ToString()]);
        //    }
        //    Assert.AreEqual(totale, -33000.00m, "L'importo totale della variazione è corrispondente");

        //    DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2));
        //    DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2018));
        //    var tEntrydetail = dsEP.Tables["entrydetail"];
        //    //PRIMO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO
        //    DataRow dr1_epacc = rEpacc[0];
        //    DataRow dr1_epaccyear = rEpaccyear[0];
        //    Assert.AreEqual(dr1_epacc["description"], "Finanziamento Ass.SviluppoUniversTerritorio Novarese borse di studio Studenti/Assegnisti periodi formativi INTERNAZION USCITA_DIMET-DIPSS 17/18  ", "La descrizione del mov.budget  è corrispondente");
        //    Assert.AreEqual(dr1_epaccyear["amount"], 33000.00m, "L'importo del mov.budget è corrispondente");
        //    Assert.AreEqual(dr1_epaccyear["idacc"], "18000100010002000700010008", "Il n.conto del mov.budget è corrispondente");
        //    Assert.AreEqual(dr1_epaccyear["idupb"], "000100030002000200020016", "L'UPB del mov.budget è corrispondente");
        //    Assert.AreEqual(dr1_epacc["idaccmotive"], "000700010002000700010008", "La causale del mov.budget è corrispondente");

        //    //CONTROLLO CORRISPONDENZA TRA SCRITTURA E MOVIMENTO DI BUDGET
        //    Assert.AreEqual(tEntrydetail.Rows[0]["idepacc"], dr1_epacc["idepacc"]);
        //    Assert.AreEqual(tEntrydetail.Rows[0]["idrelated"], dr1_epacc["idrelated"]);


        //}

        [TestMethod]
        public void Test_ImpVar_estimate_2018_dettagli_annullati_CollFattura() {
            var t = new TestHelp(new DateTime(2018, 12, 31));
            q filterEst = q.eq("idestimkind", "CONTOTERZI-disei") & q.eq("yestim", 2018) & q.eq("nestim", 11);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst & q.isNotNull("stop"));
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreNotEqual(0, nEstDet, "Il contratto non ha dettagli");
            DataRow rEst = tEstimate.Rows[0];
            var dsEP = t.getEpData(t.testConn, rEst);
            t.deleteEp(rEst);

            //CONTROLLO PER REGOLE 
            ProcedureMessageCollection regole = t.generateEP(rEst);
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");

            //VERIFICA VARIAZIONI AI MOVIMENTI DI BUDGET
            DataRow[] rEpaccpvar = dsEP.Tables["epaccvar"]._Filter(null);
            Assert.AreEqual(rEpaccpvar.Length, 0, "Non sono presenti variazioni");

            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(null);
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2018));
            //PRIMO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            Assert.AreEqual(dr1_epacc["description"], "Convenzione per attività di formazione sulle metodologie di ricerca SFA e DEA per l’applicazione al settore dei servizi ferroviari regionali", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epaccyear["amount"], 2400.00m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idacc"], "18000100010001000100030004", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idupb"], "000100030005000100020779", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["idaccmotive"], "000700010001000100030004", "La causale del mov.budget è corrispondente");

            }

        [TestMethod]
        public void Test_Scrittu_mandate_2017_dettagli_annullati_CollFattura() {
            var t = new TestHelp(new DateTime(2018, 12, 31));
            q filterMan = q.eq("idmankind", "B_ORDINE_istit_DFARM") & q.eq("yman", 2017) & q.eq("nman", 243);
            t.binaryReplaceSet(filterMan, t.getTableSet(TestHelp.mainObject.mandate));
            DataTable tMandate = t.testConn.readTable("mandate", filterMan);
            Assert.AreEqual(1, tMandate.Rows.Count, "Il contratto esiste");
            DataTable tMandateDetail = t.testConn.readTable("mandatedetail", filterMan & q.isNotNull("stop"));
            int nManDet = tMandateDetail.Rows.Count;
            Assert.AreNotEqual(0, nManDet, "Il contratto non ha dettagli");
            DataRow rMan = tMandate.Rows[0];
            var dsEP = t.getEpData(t.testConn, rMan);
            t.deleteEp(rMan);

            //CONTROLLO PER REGOLE 
            ProcedureMessageCollection regole = t.generateEP(rMan);
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");


            Assert.AreEqual(0, dsEP.Tables["entrydetail"].Rows.Count, $"Non ci sono scritture poichè contratto collegabile a fattura");

            }

        [TestMethod]
        public void Test_ImpVar_mandate_2017_dettagli_annullati_NonCollFattura() {
            //VARI_GEST_nofattura 2017	210  problema chiedere all'assistenza
            var t = new TestHelp(new DateTime(2018, 12, 31));
            q filterMan = q.eq("idmankind", "TASSE_IMPOSTE") & q.eq("yman", 2017) & q.eq("nman", 55);
            t.binaryReplaceSet(filterMan, t.getTableSet(TestHelp.mainObject.mandate));
            DataTable tMandate = t.testConn.readTable("mandate", filterMan);
            Assert.AreEqual(1, tMandate.Rows.Count, "Il contratto esiste");
            DataTable tMandateDetail = t.testConn.readTable("mandatedetail", filterMan & q.isNotNull("stop"));
            int nManDet = tMandateDetail.Rows.Count;
            Assert.AreNotEqual(0, nManDet, "Il contratto non ha dettagli");
            DataRow rMan = tMandate.Rows[0];
            var dsEP = t.getEpData(t.testConn, rMan);
            t.deleteEp(rMan);

            //CONTROLLO PER REGOLE 
            ProcedureMessageCollection regole = t.generateEP(rMan);
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");

            bool scrittureabilitate = t.abilitaScrittureUT(rMan);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");

            //VERIFICA VARIAZIONI AI MOVIMENTI DI BUDGET
            DataRow[] rEpexpvar = dsEP.Tables["epexpvar"]._Filter(null);
            Assert.AreEqual(rEpexpvar.Length, 2, "Sono  presenti 2 variazioni");
            DataRow dr1_Epexpvar = rEpexpvar[0];
            decimal totale = CfgFn.GetNoNullDecimal(dr1_Epexpvar["amount"]);
            for (int i = 2; i <= 5; i++) {
                totale += CfgFn.GetNoNullDecimal(dr1_Epexpvar["amount" + i.ToString()]);
                }
            Assert.AreEqual(totale, -77.26m, "L'importo totale della variazione è corrispondente");

            DataRow[] rEpexp = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2));
            DataRow[] rEpexpyear = dsEP.Tables["epexpyear"]._Filter(q.eq("ayear", 2017));
            var tEntrydetail = dsEP.Tables["entrydetail"];
            //IMPEGNO VAR. BUDGET ASSOCIATO AL CONTRATTO PASSIVO
            DataRow dr1_epexp = rEpexp[0];
            DataRow dr1_epexpyear = rEpexpyear[0];
            Assert.AreEqual(dr1_epexp["description"], "Iva  EXTRA/CEE su INVOICE ADDGENE N. 316440   DEL  21/02/2017-B.O.41 del 14/02/2017 plasmidi ", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epexpyear["amount"], 77.26m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexpyear["idacc"], "170002000800010001", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexpyear["idupb"], "000100030001000200010026", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexp["idaccmotive"], "000200080001", "La causale del mov.budget è corrispondente");

            //CONTROLLO CORRISPONDENZA TRA SCRITTURA E MOVIMENTO DI BUDGET
            Assert.AreEqual(tEntrydetail.Rows[0]["idepexp"], dr1_epexp["idepexp"]);
            Assert.AreEqual(tEntrydetail.Rows[0]["idrelated"], dr1_epexp["idrelated"]);

            }

        [TestMethod]
        public void Test_ImpVar_mandate_2017_dettagli_annullati_CollFattura() {

            var t = new TestHelp(new DateTime(2018, 12, 31));
            q filterMan = q.eq("idmankind", "B_ORDINE_istit_DIMET") & q.eq("yman", 2017) & q.eq("nman", 610);
            t.binaryReplaceSet(filterMan, t.getTableSet(TestHelp.mainObject.mandate));
            DataTable tMandate = t.testConn.readTable("mandate", filterMan);
            Assert.AreEqual(1, tMandate.Rows.Count, "Il contratto esiste");
            DataTable tMandateDetail = t.testConn.readTable("mandatedetail", filterMan & q.isNotNull("stop"));
            int nManDet = tMandateDetail.Rows.Count;
            Assert.AreNotEqual(0, nManDet, "Il contratto non ha dettagli");
            DataRow rMan = tMandate.Rows[0];
            t.binaryCopyEp(rMan, false);

            //CONTROLLO PER REGOLE 
            ProcedureMessageCollection regole = t.generateEP(rMan);
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rMan);
            //VERIFICA VARIAZIONI AI MOVIMENTI DI BUDGET
            DataRow[] rEpexpvar = dsEP.Tables["epexpvar"]._Filter(null);
            Assert.AreEqual(rEpexpvar.Length, 2 * 2, "sono presenti 2 variazioni");

            DataRow[] rEpexp = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2018) & q.eq("idepexp", 411805));
            DataRow[] rEpexpyear = dsEP.Tables["epexpyear"]._Filter(q.eq("ayear", 2018) & q.eq("idepexp", 411805));
            //IMPEGNO VAR. BUDGET ASSOCIATO AL CONTRATTO PASSIVO
            DataRow dr1_epexp = rEpexp[0];
            DataRow dr1_epexpyear = rEpexpyear[0];
            Assert.AreEqual(dr1_epexp["description"], "Servizi di ristorazione rivolti a studenti (tramite buono d'ordine)", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epexpyear["amount"], 396.00m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexpyear["idacc"], "18000200010002000100040002", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexpyear["idupb"], "000100030002000100020851", "L'UPB del mov.budget è corrispondente");

            //SECONDO IMPEGNO VAR. BUDGET ASSOCIATO AL CONTRATTO PASSIVO
            DataRow[] rEpexp2 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2018) & q.eq("idepexp", 411806));
            DataRow[] rEpexpyear2 = dsEP.Tables["epexpyear"]._Filter(q.eq("ayear", 2018) & q.eq("idepexp", 411806));
            DataRow dr2_epexp = rEpexp2[0];
            DataRow dr2_epexpyear = rEpexpyear2[0];
            Assert.AreEqual(dr2_epexp["description"], "Servizi di ristorazione per relatori a seminari rivolti agli studenti (tramite buono d'ordine)", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr2_epexpyear["amount"], 158.40m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epexpyear["idacc"], "18000200010002000800100005", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epexpyear["idupb"], "000100030002000100020851", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epexp["idaccmotive"], "000600010002000600100005", "La causale del mov.budget è corrispondente");
            }

        [TestMethod]
        public void Test_Scrittu_ImpVar_mandate_2018_dettagli_annullati_NonCollFattura() {
            var t = new TestHelp(new DateTime(2018, 12, 31));
            q filterMan = q.eq("idmankind", "VARI_GEST_nofattura") & q.eq("yman", 2018) & q.eq("nman", 108);
            t.binaryReplaceSet(filterMan, t.getTableSet(TestHelp.mainObject.mandate));
            DataTable tMandate = t.testConn.readTable("mandate", filterMan);
            Assert.AreEqual(1, tMandate.Rows.Count, "Il contratto esiste");
            DataTable tMandateDetailAnnull = t.testConn.readTable("mandatedetail", filterMan & q.isNotNull("stop"));
            int nManDetAnnull = tMandateDetailAnnull.Rows.Count;
            Assert.AreEqual(1, nManDetAnnull, "Il contratto ha 1 dettaglio annullato");
            DataRow rMan = tMandate.Rows[0];
            DataTable tMandateDetail = t.testConn.readTable("mandatedetail", filterMan);

            DataRow manDet1 = tMandateDetail.Rows[0];
            //465925
            object idepexp1 = manDet1["idepexp"];
            DataRow manDet2 = tMandateDetail.Rows[1];
            //465935
            object idepexp2 = manDet2["idepexp"];


            t.binaryCopyEp(rMan, false);

            //CONTROLLO PER REGOLE 
            ProcedureMessageCollection regole = t.generateEP(rMan);
            var dsEP = t.getEpData(t.testConn, rMan);

            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");

            bool scrittureabilitate = t.abilitaScrittureUT(rMan);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");

            var tEntrydetail = dsEP.Tables["entrydetail"];
            var tEntry = dsEP.Tables["entry"];


            //VERIFICA VARIAZIONI AI MOVIMENTI DI BUDGET
            DataRow[] rEpexpvar = dsEP.Tables["epexpvar"]._Filter(null);
            Assert.AreEqual(rEpexpvar.Length, 2, "Sono  presenti 2 variazioni");
            DataRow dr1_Epexpvar = dsEP.Tables["epexpvar"]._Filter(q.eq("idepexp", idepexp1)).FirstOrDefault();
            decimal totale = CfgFn.GetNoNullDecimal(dr1_Epexpvar["amount"]);
            for (int i = 2; i <= 5; i++) {
                totale += CfgFn.GetNoNullDecimal(dr1_Epexpvar["amount" + i.ToString()]);
                }
            Assert.AreEqual(totale, -595.00m, "L'importo totale della variazione è corrispondente");

            //CONTRLLO IMPEGNO DI BUDGET ASSOCIATO AL PRIMO DETTAGLIO DEL CONTRATTO
            DataRow[] rEpexp = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("idepexp", idepexp1));
            DataRow dr1_epexp = rEpexp[0];
            DataRow[] rEpexpyear = dsEP.Tables["epexpyear"]._Filter(q.eq("ayear", 2018) & q.eq("idepexp", idepexp1));
            DataRow dr1_epexpyear = rEpexpyear[0];
            Assert.AreEqual(dr1_epexp["description"], "Iscrizione E-MRS 2018 Spring Meeting - Chiara Vittoni", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epexpyear["amount"], 595.00m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexpyear["idacc"], "18000200010002000800100004", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexpyear["idupb"], "000100030004000100021274", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexp["idaccmotive"], "000600010002000600100004", "La causale del mov.budget è corrispondente");

            //CONTROLLO DATI SCRITTURA IN PARTITA DOPPIA
            var date_doc_colleg = new DateTime(2018, 6, 6);
            var date_contab = new DateTime(2018, 6, 6);
            Assert.AreEqual(tEntry.Rows[0]["description"], "Iscrizione E-MRS 2018 Spring Meeting - Chiara Vittoni", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(tEntry.Rows[0]["doc"], "C.P. VARI_GEST_nofattura 18/108", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(tEntry.Rows[0]["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(tEntry.Rows[0]["adate"], date_contab, "La data contabile della scrittura è corrispondente");

            //PRIMO DETTAGLIO SCRITTURA
            var rDet1 = tEntrydetail._Filter(q.eq("description",
                                                 "Contratto Passivo VARI_GEST_nofattura 18/108 dett. 1- Iscrizione E-MRS 2018 Spring Meeting - Chiara Vittoni")
                                             & q.eq("idacc", "18000200010002000800100004")).FirstOrDefault();

            Assert.IsNotNull(rDet1, "Trovato dettaglio 1 con conto e descrizione corrispondenti");
            Assert.AreEqual(rDet1["idupb"], "000100030004000100021274", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet1["idreg"], 130527, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet1["idaccmotive"], "000600010002000600100004", "La causale del dettaglio della scrittura è corrispondente");

            //SECONDO DETTAGLIO SCRITTURA
            var rDet2 = tEntrydetail._Filter(q.eq("description",
                                                 "Contratto passivo VARI_GEST_nofattura n.108 / 2018 dett. 1")
                                             & q.eq("idacc", "18000400040001000100090001")).FirstOrDefault();
            Assert.IsNotNull(rDet2, "Trovato dettaglio 2 con conto e descrizione corrispondenti");

            Assert.AreEqual(rDet2["idupb"], "000100030004000100021274", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet2["idreg"], 130527, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet2["idaccmotive"], "000600010002000600100004", "La causale del dettaglio della scrittura è corrispondente");

            //CONTROLLO CORRISPONDENZA TRA SCRITTURA E IMPEGNO DI BUDGET
            Assert.AreEqual(rDet1["idepexp"], dr1_epexp["idepexp"]);
            Assert.AreEqual(rDet1["idrelated"], dr1_epexp["idrelated"]);
            }

        [TestMethod]
        public void Test_Scrittu_mandate_2018_dettagli_annullati_CollFattura() {
            var t = new TestHelp(new DateTime(2018, 12, 31));
            q filterMan = q.eq("idmankind", "B_ORDINE_istit_DIMET") & q.eq("yman", 2018) & q.eq("nman", 154);
            t.binaryReplaceSet(filterMan, t.getTableSet(TestHelp.mainObject.mandate));
            DataTable tMandate = t.testConn.readTable("mandate", filterMan);
            Assert.AreEqual(1, tMandate.Rows.Count, "Il contratto esiste");
            DataTable tMandateDetail = t.testConn.readTable("mandatedetail", filterMan & q.isNotNull("stop"));
            int nManDet = tMandateDetail.Rows.Count;
            Assert.AreNotEqual(0, nManDet, "Il contratto non ha dettagli");
            DataRow rMan = tMandate.Rows[0];
            var dsEP = t.getEpData(t.testConn, rMan);
            t.deleteEp(rMan);

            //CONTROLLO PER REGOLE 
            ProcedureMessageCollection regole = t.generateEP(rMan);
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");

            Assert.AreEqual(0, dsEP.Tables["entrydetail"].Rows.Count, $"Non ci sono scritture poichè contratto collegabile a fattura");
            }

        //[TestMethod]
        //public void Test_ImpVar_mandate_2018_dettagli_annullati_CollFattura()
        //{
        //    var t = new TestHelp(new DateTime(2018, 12, 31));
        //    q filterMan = q.eq("idmankind", "B_ORDINE_comm_DIPSS") & q.eq("yman", 2018) & q.eq("nman", 43);
        //    t.binaryReplaceSet(filterMan, t.getTableSet(TestHelp.mainObject.mandate));
        //    DataTable tMandate = t.testConn.readTable("mandate", filterMan);
        //    Assert.AreEqual(1, tMandate.Rows.Count, "Il contratto esiste");
        //    DataTable tMandateDetail = t.testConn.readTable("mandatedetail", filterMan & q.isNotNull("stop"));
        //    int nManDet = tMandateDetail.Rows.Count;
        //    Assert.AreNotEqual(0, nManDet, "Il contratto non ha dettagli");
        //    DataRow rMan = tMandate.Rows[0];
        //    var dsEP = t.getEpData(t.testConn, rMan);
        //    t.deleteEp(rMan);

        //    //CONTROLLO PER REGOLE 
        //    ProcedureMessageCollection regole = t.generateEP(rMan);
        //    if(regole != null) 
        //        Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");

        //    //VERIFICA VARIAZIONI AI MOVIMENTI DI BUDGET
        //    DataRow[] rEpexpvar = dsEP.Tables["epexpvar"]._Filter(null);
        //    Assert.AreEqual(rEpexpvar.Length, 2, "Sono  presenti 2 variazioni");
        //    DataRow dr1_Epexpvar = rEpexpvar[0];
        //    decimal totale = CfgFn.GetNoNullDecimal(dr1_Epexpvar["amount"]);
        //    for (int i = 2; i <= 5; i++)
        //    {
        //        totale += CfgFn.GetNoNullDecimal(dr1_Epexpvar["amount" + i.ToString()]);
        //    }
        //    Assert.AreEqual(totale, -17.02m, "L'importo totale della variazione è corrispondente");

        //    DataRow[] rEpexp = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2));
        //    DataRow[] rEpexpyear = dsEP.Tables["epexpyear"]._Filter(q.eq("ayear", 2018));
        //    //PRIMO IMPEGNO VAR. BUDGET ASSOCIATO AL CONTRATTO PASSIVO
        //    DataRow dr1_epexp = rEpexp[0];
        //    DataRow dr1_epexpyear = rEpexpyear[0];
        //    Assert.AreEqual(dr1_epexp["description"], "5067-4627 _Reagenti DNA alta sensibilità", "La descrizione del mov.budget  è corrispondente");
        //    Assert.AreEqual(dr1_epexpyear["amount"], 276.46m, "L'importo del mov.budget è corrispondente");
        //    Assert.AreEqual(dr1_epexpyear["idacc"], "18000200010002000500010003", "Il n.conto del mov.budget è corrispondente");
        //    Assert.AreEqual(dr1_epexpyear["idupb"], "000100030001000200010063", "L'UPB del mov.budget è corrispondente");
        //    Assert.AreEqual(dr1_epexp["idaccmotive"], "000600010002000400010003", "La causale del mov.budget è corrispondente");

        //}

        [TestMethod]
        public void Test_Scrittu_ImpVar_mandate_2017_dettagli2018_CollFattura() {
            var t = new TestHelp(new DateTime(2018, 12, 31));
            q filterMan = q.eq("idmankind", "B_ORDINE_comm_DFARM") & q.eq("yman", 2017) & q.eq("nman", 21);
            t.binaryReplaceSet(filterMan, t.getTableSet(TestHelp.mainObject.mandate));
            DataTable tMandate = t.testConn.readTable("mandate", filterMan);
            Assert.AreEqual(1, tMandate.Rows.Count, "Il contratto esiste");
            DataTable tMandateDetail = t.testConn.readTable("mandatedetail", filterMan & q.isNotNull("start"));
            int nManDet = tMandateDetail.Rows.Count;
            Assert.AreNotEqual(0, nManDet, "Il contratto non ha dettagli");
            DataRow rMan = tMandate.Rows[0];
            t.binaryCopyEp(rMan, false);

            //CONTROLLO PER REGOLE 
            ProcedureMessageCollection regole = t.generateEP(rMan);
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rMan);

            //VERIFICA VARIAZIONI AI MOVIMENTI DI BUDGET
            DataRow[] rEpexpvar = dsEP.Tables["epexpvar"]._Filter(null);
            Assert.AreEqual(rEpexpvar.Length, 2, "Sono  presenti 2 variazioni");
            DataRow dr1_Epexpvar = rEpexpvar[0];
            decimal totale = CfgFn.GetNoNullDecimal(dr1_Epexpvar["amount"]);
            for (int i = 2; i <= 5; i++) {
                totale += CfgFn.GetNoNullDecimal(dr1_Epexpvar["amount" + i.ToString()]);
                }
            Assert.AreEqual(totale, -541.80m, "L'importo totale della variazione è corrispondente");

            DataRow[] rEpexp = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2017));
            DataRow[] rEpexpyear = dsEP.Tables["epexpyear"]._Filter(q.eq("ayear", 2018));
            //PRIMO IMPEGNO VAR. BUDGET ASSOCIATO AL CONTRATTO PASSIVO
            DataRow dr1_epexp = rEpexp[0];
            DataRow dr1_epexpyear = rEpexpyear[0];
            Assert.AreEqual(dr1_epexp["description"], "Servizi di analisi ed esami di laboratorio", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epexpyear["amount"], 541.80m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexpyear["idacc"], "18000200010002000500010005", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexpyear["idupb"], "000100030003000200020701", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexp["idaccmotive"], "0002000600050001", "La causale del mov.budget è corrispondente");

            //CONTROLLO DATI SCRITTURE
            var countDetScritt = dsEP.Tables["entrydetail"]._Filter(q.like("idrelated", "man")).Length;
            Assert.AreEqual(0, countDetScritt, $"Non ci sono scritture poichè contratto collegabile a fattura");
            }

        [TestMethod]
        public void Test_ImpVar_mandate_2017_dettagli2018_NonCollFattura() {
            var t = new TestHelp(new DateTime(2018, 12, 31));
            q filterMan = q.eq("idmankind", "VARI_GEST_nofattura") & q.eq("yman", 2017) & q.eq("nman", 389);
            t.binaryReplaceSet(filterMan, t.getTableSet(TestHelp.mainObject.mandate));
            DataTable tMandate = t.testConn.readTable("mandate", filterMan);
            Assert.AreEqual(1, tMandate.Rows.Count, "Il contratto esiste");
            DataTable tMandateDetail = t.testConn.readTable("mandatedetail", filterMan & q.isNotNull("start"));
            int nManDet = tMandateDetail.Rows.Count;
            Assert.AreNotEqual(0, nManDet, "Il contratto non ha dettagli");
            DataRow rMan = tMandate.Rows[0];
            t.binaryCopyEp(rMan, false);

            //CONTROLLO PER REGOLE 
            ProcedureMessageCollection regole = t.generateEP(rMan);
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rMan);

            bool scrittureabilitate = t.abilitaScrittureUT(rMan);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");

            //VERIFICA VARIAZIONI AI MOVIMENTI DI BUDGET
            DataRow[] rEpexpvar = dsEP.Tables["epexpvar"]._Filter(null);
            Assert.AreEqual(rEpexpvar.Length, 0, "Sono  presenti 0 variazioni");

            DataRow[] rEpexp = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2018));
            DataRow[] rEpexpyear = dsEP.Tables["epexpyear"]._Filter(q.eq("ayear", 2018));
            var tEntrydetail = dsEP.Tables["entrydetail"]._Filter(q.eq("yentry", 2018));
            //IMPEGNO VAR. BUDGET ASSOCIATO AL CONTRATTO PASSIVO
            DataRow dr1_epexp = rEpexp[0];
            DataRow dr1_epexpyear = rEpexpyear[0];
            Assert.AreEqual(dr1_epexp["description"], "Iscrizione a Convegni e Congressi - riemissione mandato per errore nel'IBAN del destinatario ", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epexpyear["amount"], 329.40m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexpyear["idacc"], "18000200010002000800100003", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexpyear["idupb"], "000100030003000200020072", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexp["idaccmotive"], "000200030006", "La causale del mov.budget è corrispondente");

            //CONTROLLO CORRISPONDENZA TRA SCRITTURA E MOVIMENTO DI BUDGET
            Assert.AreEqual(tEntrydetail[0]["idepexp"], dr1_epexp["idepexp"]);
            Assert.AreEqual(tEntrydetail[0]["idrelated"], dr1_epexp["idrelated"]);
            }

        [TestMethod]
        public void Test_Scrittu_mandate_2017_dettagli2018_NonCollFattura() {
            var t = new TestHelp(new DateTime(2018, 12, 31));
            q filterMan = q.eq("idmankind", "LAV/FOR/SERnofattura") & q.eq("yman", 2017) & q.eq("nman", 21);
            t.binaryReplaceSet(filterMan, t.getTableSet(TestHelp.mainObject.mandate));
            DataTable tMandate = t.testConn.readTable("mandate", filterMan);
            Assert.AreEqual(1, tMandate.Rows.Count, "Il contratto esiste");
            DataTable tMandateDetail = t.testConn.readTable("mandatedetail", filterMan & q.isNotNull("start"));
            int nManDet = tMandateDetail.Rows.Count;
            Assert.AreNotEqual(0, nManDet, "Il contratto non ha dettagli");
            DataRow rMan = tMandate.Rows[0];
            var dsEP = t.getEpData(t.testConn, rMan);
            t.binaryCopyEp(rMan, false);

            //CONTROLLO PER REGOLE 
            ProcedureMessageCollection regole = t.generateEP(rMan);
            dsEP = t.getEpData(t.testConn, rMan);

            bool scrittureabilitate = t.abilitaScrittureUT(rMan);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");

            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");

            var tEntrydetail = dsEP.Tables["entrydetail"];
            var tEntry = dsEP.Tables["entry"];
            DataRow[] rEpexp = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2));
            DataRow dr1_epexp = rEpexp[0];

            var date_doc_colleg = new DateTime(2017, 07, 12);
            var date_contab = new DateTime(2018, 01, 01);
            Assert.AreEqual(tEntry.Rows[0]["description"], "Premio assicurativo Kasko Dipendenti, polizza emittenda, periodo: luglio 2017-dicembre 2019", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(tEntry.Rows[0]["nentry"], 6, " NUMERO SCRITTURA description ok");
            Assert.AreEqual(tEntry.Rows[0]["doc"], "prot. n. 11491 - 22499", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(tEntry.Rows[0]["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(tEntry.Rows[0]["adate"], date_contab, "La data contabile della scrittura è corrispondente");

            //PRIMO DETTAGLIO SCRITTURA
            Assert.AreEqual(tEntrydetail.Rows[0]["description"], "Premio assicurativo Kasko Dipendenti, polizza emittenda, periodo: luglio-dicembre 2017", "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(tEntrydetail.Rows[0]["idacc"], "170002001000020004", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(tEntrydetail.Rows[0]["idupb"], "000100020002000300010004", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(tEntrydetail.Rows[0]["idreg"], 11925, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(tEntrydetail.Rows[0]["idaccmotive"], "0002001000020004", "La causale del dettaglio della scrittura è corrispondente");

            //SECONDO DETTAGLIO SCRITTURA
            Assert.AreEqual(tEntrydetail.Rows[1]["description"], "Premio assicurativo Kasko Dipendenti, polizza emittenda, periodo: luglio-dicembre 2017", "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(tEntrydetail.Rows[1]["idacc"], "170004000600090001", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(tEntrydetail.Rows[1]["idupb"], "000100020002000300010004", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(tEntrydetail.Rows[1]["idreg"], 11925, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(tEntrydetail.Rows[1]["idaccmotive"], "0004000100030013", "La causale del dettaglio della scrittura è corrispondente");

            //CONTROLLO CORRISPONDENZA TRA PRIMO DETTAGLIO SCRITTURA E MOVIMENTO DI BUDGET
            Assert.AreEqual(tEntrydetail.Rows[0]["idepexp"], dr1_epexp["idepexp"]);
            Assert.AreEqual(tEntrydetail.Rows[0]["idrelated"], dr1_epexp["idrelated"]);

            //CONTROLLO CORRISPONDENZA TRA SECONDO DETTAGLIO SCRITTURA E MOVIMENTO DI BUDGET
            Assert.AreEqual(tEntrydetail.Rows[1]["idepexp"], dr1_epexp["idepexp"]);
            Assert.AreEqual(tEntrydetail.Rows[1]["idrelated"], dr1_epexp["idrelated"]);
            }

        [TestMethod]
        public void Test_ImpVar_estimate_2017_dettagli2018_CollFattura() {
            var t = new TestHelp(new DateTime(2018, 12, 31));
            q filterEst = q.eq("idestimkind", "CONTOTERZI-digspes") & q.eq("yestim", 2017) & q.eq("nestim", 50);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst & q.isNotNull("start"));
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreNotEqual(0, nEstDet, "Il contratto non ha dettagli");
            DataRow rEst = tEstimate.Rows[0];
            t.binaryCopyEp(rEst, false);

            //CONTROLLO PER REGOLE 
            ProcedureMessageCollection regole = t.generateEP(rEst);
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rEst);
            //VERIFICA VARIAZIONI AI MOVIMENTI DI BUDGET
            DataRow[] rEpaccpvar = dsEP.Tables["epaccvar"]._Filter(null);
            Assert.AreEqual(rEpaccpvar.Length, 2, "Sono  presenti 2 variazioni");
            DataRow dr1_Epaccvr = rEpaccpvar[0];
            decimal totale = CfgFn.GetNoNullDecimal(dr1_Epaccvr["amount"]);
            for (int i = 2; i <= 5; i++) {
                totale += CfgFn.GetNoNullDecimal(dr1_Epaccvr["amount" + i.ToString()]);
                }
            Assert.AreEqual(totale, -6000.00m, "L'importo totale della variazione è corrispondente");

            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(null);
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2018));
            //PRIMO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            Assert.AreEqual(dr1_epacc["description"], "Convenzione con la Provincia di Novara per la realizzazione di un piano formativo R.S. E. Bruti Liberati", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epaccyear["amount"], 6000.00m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idacc"], "18000100010001000200010001", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idupb"], "000100030007000200020992", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["idaccmotive"], "0001000600020004", "La causale del mov.budget è corrispondente");
            }

        [TestMethod]
        public void Test_ImpVar_estimate_2017_dettagli2018_NonCollFattura() {
            var t = new TestHelp(new DateTime(2017, 12, 31));
            q filterEst = q.eq("idestimkind", "DOCAMM-amm") & q.eq("yestim", 2017) & q.eq("nestim", 356);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst & q.isNotNull("start"));
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreNotEqual(0, nEstDet, "Il contratto non ha dettagli");
            DataRow rEst = tEstimate.Rows[0];
            t.binaryCopyEp(rEst, false);
            t.deleteEp(rEst);
            var dsEP = t.getEpData(t.testConn, rEst);
            //CONTROLLO PER REGOLE 
            ProcedureMessageCollection regole = t.generateEP(rEst);

            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");

            dsEP = t.getEpData(t.testConn, rEst);

            bool scrittureabilitate = t.abilitaScrittureUT(rEst);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");

            //VERIFICA VARIAZIONI AI MOVIMENTI DI BUDGET
            DataRow[] rEpaccpvar = dsEP.Tables["epaccvar"]._Filter(null);
            Assert.AreEqual(rEpaccpvar.Length, 0, "Sono  presenti 0 variazioni");


            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2));
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("idepacc", rEpacc[0]["idepacc"]));
            var tEntrydetail = dsEP.Tables["entrydetail"];
            //ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            Assert.AreEqual(dr1_epacc["description"], "Incasso altre tasse", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epaccyear["amount"], 1850.00m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idacc"], "170001000100010007", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idupb"], "000100020002000300010001", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["idaccmotive"], "000100010007", "La causale del mov.budget è corrispondente");

            //CONTROLLO CORRISPONDENZA TRA SCRITTURA E MOVIMENTO DI BUDGET
            Assert.AreEqual(dr1_epacc["idepacc"], tEntrydetail.Rows[0]["idepacc"]);
            Assert.AreEqual(dr1_epacc["idrelated"], tEntrydetail.Rows[0]["idrelated"]);
            }

        public void Test_Regola_Scrittu_estimate_2017_dettagli2018_CollFattura() {
            var t = new TestHelp(new DateTime(2018, 12, 31));
            q filterEst = q.eq("idestimkind", "CONTOTERZI-digspes") & q.eq("yestim", 2017) & q.eq("nestim", 39);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst & q.isNotNull("start"));
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreNotEqual(0, nEstDet, "Il contratto non ha dettagli");
            DataRow rEst = tEstimate.Rows[0];
            t.deleteEp(rEst);

            //MODIFICO IL DATASET DELL'ESTIMATE DETAIL PER FAR SCATTARE LA REGOLA ESTIM005
            var mEstimate = TestHelp.editDataRow(t.testConn, filterEst, "estimate", "default");
            var ds = mEstimate.ds;
            var testimatedetail = ds.Tables["estimatedetail"];
            var restdet = testimatedetail.Rows[0];
            decimal originalValue = (decimal)restdet["taxable"];
            restdet["taxable"] = originalValue + 1850.00m;

            //SALVO IL DATASET CON IL DATO MODIFICATO
            var res = t.saveFormData(mEstimate);

            Assert.AreNotEqual(0, res.Count, "Sono scattate delle regole sul salvataggio della modifica");
            EasyProcedureMessage regola = (EasyProcedureMessage)res[0];
            Assert.IsInstanceOfType(regola, typeof(EasyProcedureMessage));
            Assert.AreEqual("ESTIM005", regola.AuditID, "E' scattata la ESTIM005");
            var testoRegola =
                "Il dettaglio n. 1 e descrizione Conv. con ANCI PIEMONTE  per atti. di ricerca, studio e condivisione delle conoscenze in tema di RIsk Management negli Enti Locali piemontesi-Acconto  non può essere modificato in quanto esistono dettagli fatture ad esso collegati. ";
            Assert.AreEqual(testoRegola, regola.LongMess, "Il testo della ESTIM005 appare come dovrebbe");
            Assert.AreEqual(false, regola.CanIgnore, "La regola che scatta è ignorabile");

            //METODI POST SALVATAGGIO DS
            mEstimate.DontWarnOnInsertCancel = true;
            mEstimate.ds.AcceptChanges();
            mEstimate.linkedForm.Close();
            }

        //[TestMethod]
        //public void Test_Regola_ImpVar_estimate_2018_dettagli_annullati_NonCollFattura()
        //{
        //    var t = new TestHelp(new DateTime(2018, 12, 31));
        //    q filterEst = q.eq("idestimkind", "DOCAMM-dimet") & q.eq("yestim", 2018) & q.eq("nestim", 17);
        //    t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
        //    DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
        //    Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
        //    DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst & q.isNotNull("stop"));
        //    int nEstDet = tEstimateDetail.Rows.Count;
        //    Assert.AreNotEqual(0, nEstDet, "Il contratto non ha dettagli");
        //    DataRow rEst = tEstimate.Rows[0];
        //    var dsEP = t.getEpData(t.testConn, rEst);
        //    t.deleteEp(rEst);

        //    //MODIFICO IL DATASET DELL'ESTIMATE DETAIL PER FAR SCATTARE LA REGOLA ESTIM005
        //    var mEstimate = t.editDataRow(filterEst, "estimate", "default");
        //    var ds = mEstimate.ds;
        //    var testimatedetail = ds.Tables["estimatedetail"];
        //    var restdet = testimatedetail.Rows[0];
        //    decimal originalValue = (decimal)restdet["taxable"];
        //    restdet["taxable"] = originalValue + 1850.00m;

        //    //SALVO IL DATASET CON IL DATO MODIFICATO
        //    var res = t.saveFormData(mEstimate);
        //    Assert.AreNotEqual(0, res.Count, "Sono scattate delle regole sul salvataggio della modifica");
        //    //METODI POST SALVATAGGIO DS
        //    mEstimate.DontWarnOnInsertCancel = true;
        //    mEstimate.ds.AcceptChanges();
        //    mEstimate.linkedForm.Close();


        //    ProcedureMessageCollection regoleEP = t.generateEP(rEst);
        //    if (regoleEP != null)
        //    {
        //      Assert.AreEqual(0, regoleEP.Count, "Non scatta nessuna regola");
        //    }  

        //    DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2));
        //    DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2018));
        //    var tEntrydetail = dsEP.Tables["entrydetail"];
        //    //PRIMO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO
        //    DataRow dr1_epacc = rEpacc[0];
        //    DataRow dr1_epaccyear = rEpaccyear[0];
        //    Assert.AreEqual(dr1_epacc["description"], "Finanziamento Ass.SviluppoUniversTerritorio Novarese borse di studio Studenti/Assegnisti periodi formativi INTERNAZION USCITA_DIMET-DIPSS 17/18  ", "La descrizione del mov.budget  è corrispondente");
        //    Assert.AreEqual(dr1_epaccyear["amount"], 33000.00m, "L'importo del mov.budget è corrispondente");
        //    Assert.AreEqual(dr1_epaccyear["idacc"], "18000100010002000700010008", "Il n.conto del mov.budget è corrispondente");
        //    Assert.AreEqual(dr1_epaccyear["idupb"], "000100030002000200020016", "L'UPB del mov.budget è corrispondente");
        //    Assert.AreEqual(dr1_epacc["idaccmotive"], "000700010002000700010008", "La causale del mov.budget è corrispondente");

        //    //CONTROLLO CORRISPONDENZA TRA SCRITTURA E MOVIMENTO DI BUDGET
        //    Assert.AreEqual(tEntrydetail.Rows[0]["idepacc"], dr1_epacc["idepacc"]);
        //    Assert.AreEqual(tEntrydetail.Rows[0]["idrelated"], dr1_epacc["idrelated"]);


        //}

        [TestMethod]
        public void Test_Scrittu_estimate_2017_dettagli2018_NonCollFattura() {
            var t = new TestHelp(new DateTime(2018, 12, 31));
            q filterEst = q.eq("idestimkind", "DOCAMM-disei") & q.eq("yestim", 2017) & q.eq("nestim", 6);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst & q.isNotNull("start"));
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreNotEqual(0, nEstDet, "Il contratto non ha dettagli");
            DataRow rEst = tEstimate.Rows[0];
            t.deleteEp(rEst);

            //CONTROLLO PER REGOLE 
            ProcedureMessageCollection regole = t.generateEP(rEst);
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");

            bool scrittureabilitate = t.abilitaScrittureUT(rEst);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");

            var dsEP = t.getEpData(t.testConn, rEst);
            var tEntrydetail = dsEP.Tables["entrydetail"];
            var tEntry = dsEP.Tables["entry"];

            var date_contab = new DateTime(2017, 05, 11);
            Assert.AreEqual(tEntry.Rows[0]["description"], "Contributo assouni per finanziamento borsa di studio Costruzione banca dati studenti immatricolati presso l'UPO", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(tEntry.Rows[0]["nentry"], 5521, " NUMERO SCRITTURA description ok");
            Assert.AreEqual(tEntry.Rows[0]["doc"], "C.A. DOCAMM-disei 17/6", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(tEntry.Rows[0]["adate"], date_contab, "La data contabile della scrittura è corrispondente");

            //PRIMO DETTAGLIO SCRITTURA
            Assert.AreEqual(tEntrydetail.Rows[0]["description"], "Contributo assouni per finanziamento borsa di studio Costruzione banca dati studenti immatricolati presso l'UPO", "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(tEntrydetail.Rows[0]["idacc"], "170001000400080002", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(tEntrydetail.Rows[0]["idupb"], "000100030005000100010005", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(tEntrydetail.Rows[0]["idreg"], 11994, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(tEntrydetail.Rows[0]["idaccmotive"], "0001000400080002", "La causale del dettaglio della scrittura è corrispondente");
            }



        #region Test Task15055   

        /// <summary>
        /// Vogliamo salvare un dettaglio da 100 (rownumber 1) con i dati del primo dettaglio
        /// e generare movimenti e scritture
        /// POI
        /// Modificarlo portandolo a 70 e creare un altro dettaglio da 30 (altri dati tutti uguali) con pari idgroup (rownum 2)
        /// e generare movimenti e scritture
        /// POI
        /// Copiare tali due dettagli nei dettagli 3 e 4 escluso idepacc che diventa null, valorizziamo stop di 3 e 4 e start di 1 e 2
        /// l'importo di 3 e 4 diventa quindi 70 e 30, mentre quello di 1 e 2 lo poniamo a 70 e 0
        /// valutare se valorizzare causale di annullo di 3 e 4
        /// e generare movimenti e scritture
        /// </summary>
        [TestMethod]
        public void Test_estimate_2019_sostituito2019_NonCollFattura_parzCont_Prova() {
            //CASO che ha chiesto Cinzia a lei non generava variazione
            var t = new TestHelp(new DateTime(2019, 12, 31));
            q filterEst = q.eq("idestimkind", "CA_GENERICO") & q.eq("yestim", 2019) & q.eq("nestim", 23);
            t.binaryCopySet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));

            DataTable tEstimate = t.sampleConn.readTable("estimate", filterEst);
            DataRow rEst = tEstimate.Rows[0];

            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");

            t.binaryCopyEp(rEst, false);

            /*
            DataTable estimDetail = t.sampleConn.readFromTable("estimatedetail", filterEst);
            decimal taxable = 0;
            foreach (var rDet in estimDetail._Filter(q.eq("idgroup", 1) & q.isNull("rownum_main"))) {
                //di ogni dettaglio mi da l'ultima versione (in questo caso i dettagli 1 e 2)
                var first = EP_Manager.getFirstRow(rDet);
                taxable += CfgFn.GetNoNullDecimal(first["taxable"]);
            }

            foreach (var rDet in estimDetail._Filter(q.ne("rownum",3))) {
                rDet.Delete();
            }
            estimDetail.AcceptChanges();
            var unico = estimDetail.Rows[0];
            unico["taxable"] = taxable;
            unico["stop"] = DBNull.Value;
            unico["rownum"] = 1;
            unico["rownum_main"] = DBNull.Value;
            unico["idepacc"] = DBNull.Value;
            unico.AcceptChanges();
            estimDetail.TableName = "estimatedetail";
            t.binaryCopy(estimDetail,UpdateType.bulkinsert);


            //CANCELLO I DATI DELLE SCRITTURE
            t.deleteEp(rEst);
            ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);
            if (regole != null) Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
           
            //Uno potrebbe fare delle verifiche sull'unico accertamento da 100 creato

            //Rileggo i dati da sample
            var estimDetailTest = t.testConn.readFromTable("estimatedetail", filterEst);
            var idepaccGenerato = estimDetailTest.Rows[0]["idepacc"];
            
            estimDetail = t.sampleConn.readFromTable("estimatedetail", filterEst);
            foreach (var rDet in estimDetail._Filter(q.lt("rownum",3))) {
	            rDet.Delete();
            }
            estimDetail.AcceptChanges();
            foreach (DataRow rDet in estimDetail.Rows) {
	            int newRownum = CfgFn.GetNoNullInt32(rDet["rownum"]) - 2;
	            rDet["rownum"] = newRownum;
	            rDet["rownum_main"] = DBNull.Value;
	            rDet["stop"] = DBNull.Value;
	            rDet["idepacc"] = DBNull.Value;
	            if (newRownum == 1) rDet["idepacc"] = idepaccGenerato;
            }
            estimDetail.AcceptChanges();
            estimDetail.TableName = "estimatedetail";
            t.binaryDeleteSet(filterEst,new []{"estimatedetail"});
            t.binaryCopy(estimDetail,UpdateType.bulkinsert);

            regole = t.generaAccertamentiScritture(rEst);

            var estimDetailTest2 = t.testConn.readFromTable("estimatedetail", filterEst& q.eq("rownum",2));
            var idepaccGenerato2 = estimDetailTest2.Rows[0]["idepacc"];

            estimDetail = t.sampleConn.readFromTable("estimatedetail", filterEst);
            estimDetail._Filter(q.eq("rownum", 1)).FirstOrDefault()["idepacc"] = idepaccGenerato;
            estimDetail._Filter(q.eq("rownum", 2)).FirstOrDefault()["idepacc"] = idepaccGenerato2;
            estimDetail.AcceptChanges();
            estimDetail.TableName = "estimatedetail";
            t.binaryDeleteSet(filterEst,new []{"estimatedetail"});
            t.binaryCopy(estimDetail,UpdateType.bulkinsert);
            

            */
            var estimDetailTest2 = t.testConn.readFromTable("estimatedetail", filterEst & q.eq("rownum", 2));
            var idepaccGenerato2 = estimDetailTest2.Rows[0]["idepacc"];

            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst);
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreNotEqual(0, nEstDet, "Il contratto non ha dettagli annullati");

            //VERIFICO CHE LA CAUSALE DI RICAVO SIA CORRETTA (CP1.5.01.01.022) 
            DataRow rEstimateDetail = tEstimateDetail.Rows[0];
            string attualCode = rEstimateDetail["idaccmotive"] == DBNull.Value ? "" : (string)rEstimateDetail["idaccmotive"];
            Assert.AreEqual("000700010005000100010022", attualCode, "Il codice della causale di ricavo è corrispondente");

            //GENERO IMPEGNI E SCRITTURE E CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rEst);

            //VERIFICA VARIAZIONI AI MOVIMENTI DI BUDGET
            DataRow[] rEpaccvar = dsEP.Tables["epaccvar"]._Filter(null);
            Assert.AreEqual(2 * 2, rEpaccvar.Length, "Sono presenti 2 variazioni");

            //VERIFICO LA VARIAZIONE SULL'ACCERTAMENTO 1710
            DataRow dr1_Epaccvar = dsEP.Tables["epaccvar"]._Filter(q.eq("idepacc", idepaccGenerato2))[0];
            decimal totale = CfgFn.GetNoNullDecimal(dr1_Epaccvar["amount"]);
            for (int i = 2; i <= 5; i++) {
                totale += CfgFn.GetNoNullDecimal(dr1_Epaccvar["amount" + i.ToString()]);
                }
            Assert.AreEqual(totale, -30.00m, "L'importo totale della variazione è corrispondente");

            //CONTROLLO PRIMO ACCERTAMENTO DI BUDGET 
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("idepacc", idepaccGenerato2));
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepaccGenerato2));
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            Assert.AreEqual(dr1_epacc["description"], "Sostituzione nel 2019 dettaglio parzialmente contabilizzato", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epaccyear["amount"], 30.00m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idacc"], "19000100010005000100010022", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idupb"], "000100030004000200010100", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["idaccmotive"], "000700010005000100010022", "La causale del mov.budget è corrispondente");

            }


        //NUOVI CASI DI TEST CON NUOVA GESTIONE SOSTITUZIONE

        [TestMethod]
        public void Test2_estimate_2018_annullo2019_NonCollFattura() {

            //2018:accertamento di 10, a 0 nel 2019
            //2019:impegno di 10
            //CASO esercizi anni precedenti 1a.1 dettaglio non incassato // OK 
            var t = new TestHelp(new DateTime(2019, 12, 31));
            q filterEst = q.eq("idestimkind", "CA_GENERICO") & q.eq("yestim", 2018) & q.eq("nestim", 36);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            DataRow rEst = tEstimate.Rows[0];
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rEst, false);
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst & q.isNotNull("stop"));
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreEqual(1, nEstDet, "Il contratto ha dettagli annullati");

            //VERIFICO CHE LA CAUSALE DI ANNULLO SIA CORRETTA (CN1.5.01.03.008) 
            DataRow rEstimateDetail = tEstimateDetail.Rows[0];
            string attualCode = rEstimateDetail["idaccmotiveannulment"] == DBNull.Value ? "" : (string)rEstimateDetail["idaccmotiveannulment"];
            Assert.AreEqual("000600010005000100030008", attualCode, "Il codice della causale d'annullo è corrispondente");

            //GENERO LE SCRITTURE E CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rEst);

            bool scrittureabilitate = t.abilitaScrittureUT(rEst);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");

            //CONTROLLO VARIAZIONI AI MOVIMENTI DI BUDGET
            DataRow[] rEpaccpvar = dsEP.Tables["epaccvar"]._Filter(null);
            Assert.AreEqual(rEpaccpvar.Length, 0, "Non Sono  presenti variazioni");

            //CONTROLLO NUMERO IMPEGNI DI BUDGET
            int countNepexp2019 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2019)).Length;
            Assert.AreEqual(1, countNepexp2019, "E' presente un accertamento  di budget");
            int countNepexp2018 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2018)).Length;
            Assert.AreEqual(0, countNepexp2018, "Non ci sono impegni di budget del 2018");

            //CONTROLLO IMPEGNO DI BUDGET
            DataRow[] rEpexp = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2));
            DataRow[] rEpexpeyear = dsEP.Tables["epexpyear"]._Filter(q.eq("ayear", 2019));
            DataRow dr1_epexp = rEpexp[0];
            DataRow dr1_epexpyear = rEpexpeyear[0];
            Assert.AreEqual(dr1_epexp["description"], "annullo nel 2019 VERSIONE 1 con CAUSALE di COSTO CN1.5.01.03.008 - NUOVA GESTIONE", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epexpyear["amount"], 10.00m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexpyear["idacc"], "19000200010005000100030008", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexpyear["idupb"], "000100020001000300010001", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexp["idaccmotive"], "000600010005000100030008", "La causale del mov.budget è corrispondente");



            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019)).Length;
            Assert.AreEqual(0, countNepacc2019, "Non ci sono accertamenti di budget del 2019");
            int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
            Assert.AreEqual(1, countNepacc2018, "E' presente un accertamento di budget del 2018");

            //CONTROLLO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2));
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019));
            DataRow[] rEpaccyear2018 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2018));
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            DataRow dr1_epaccyear2018 = rEpaccyear2018[0];
            Assert.AreEqual(dr1_epacc["description"], "annullo nel 2019 VERSIONE 1 con CAUSALE di COSTO CN1.5.01.03.008 - NUOVA GESTIONE", "La descrizione del mov.budget  è corrispondente");
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], dr1_epaccyear["idepacc"], 2018, 10m);
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], dr1_epaccyear["idepacc"], 2019, 0m);

            Assert.AreEqual(dr1_epaccyear["idacc"], "19000100010005000100010022", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idupb"], "000100020001000300010001", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["idaccmotive"], "000700010005000100010022", "La causale del mov.budget è corrispondente");

            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            var tEntrydetail = dsEP.Tables["entrydetail"];
            var rEntry = dsEP.Tables["entry"].Rows[0];
            var date_doc_colleg = new DateTime(2018, 12, 31);
            var date_contab = new DateTime(2019, 12, 31);
            Assert.AreEqual(rEntry["description"], "annullo nel 2019 VERSIONE 1 con CAUSALE di COSTO CN1.5.01.03.008 - NUOVA GESTIONE", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "C.A. CA_GENERICO 18/36", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");
            //PRIMO DETTAGLIO SCRITTURA
            var descr1 =
                 "Contratto Attivo CA_GENERICO 18/36dett. 1- annullo nel 2019 VERSIONE 1 con CAUSALE di COSTO CN1.5.01.03.008 - NUOVA GESTIONE";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1);
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(EntryDetail1["description"], descr1, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idacc"], "19000200010005000100030008", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idupb"], "000100020001000300010001", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idreg"], 10382, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idaccmotive"], "000600010005000100030008", "La causale del dettaglio della scrittura è corrispondente");
            //SECONDO DETTAGLIO SCRITTURA
            var descr2 =
                "Contratto attivo CA_GENERICO n.36 / 2018 dett. 1";
            q filterEDetail2 = q.eq("description", descr2);
            var EntryDetail2Rows = tEntrydetail._Filter(filterEDetail2);
            var EntryDetail2 = EntryDetail2Rows[0];
            Assert.AreEqual(EntryDetail2["description"], descr2, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idacc"], "19000300020002000100090003", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idupb"], "000100020001000300010001", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idreg"], 10382, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idaccmotive"], "000600010005000100030008", "La causale del dettaglio della scrittura è corrispondente");

            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            Assert.AreEqual(2, dsEP.Tables["entry"]._Filter(null).Length, "Sono presenti due scritture");
            //CONTROLLO DETTAGLI SCRITTURA ESERCIZIO 2019
            Assert.AreEqual(2, dsEP.Tables["entrydetail"]._Filter(q.eq("nentry", rEntry["nentry"])).Length, "Sono presenti sette dettagli relativi alla scrittura");
            var avere = (decimal)dsEP.Tables["entrydetail"]._Filter(q.gt("amount", 0) & q.eq("nentry", rEntry["nentry"])).GetSum<decimal>("amount");
            Assert.AreEqual(10m, avere, "Avere corrispondente");

            //CONTROLLO CORRISPONDENZA TRA SCRITTURA E MOVIMENTO DI BUDGET
            Assert.AreNotEqual(EntryDetail1["idepacc"], dr1_epacc["idepacc"]);
            Assert.AreEqual(EntryDetail2["idrelated"], dr1_epacc["idrelated"]);

            }
        [TestMethod]
        public void Test_mandate_2020_annullo2020_NonCollFattura() {
            // a)Annullo stesso anno CP
            var t = new TestHelp(new DateTime(2020, 12, 31), "sample_2", "test_2");
            q filterMan = q.eq("idmankind", "AMCEN_GEN") & q.eq("yman", 2020) & q.eq("nman", 1);
            t.binaryReplaceSet(filterMan, t.getTableSet(TestHelp.mainObject.mandate));
            DataTable tMandate = t.testConn.readTable("mandate", filterMan);
            DataRow rMan = tMandate.Rows[0];
            Assert.AreEqual(1, tMandate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rMan, false);
            DataTable tMandateDetail = t.testConn.readTable("mandatedetail", filterMan & q.isNotNull("stop"));
            int nManDet = tMandateDetail.Rows.Count;
            Assert.AreEqual(1, nManDet, "Il contratto ha dettagli annullati");

            //VERIFICO CHE LA CAUSALE DI ANNULLO  (Sopravvenienze attive) - Viene cmq ignorata
            DataRow rMandateDetail = tMandateDetail.Rows[0];
            string attualCodeAnn = rMandateDetail["idaccmotiveannulment"] == DBNull.Value ? "" : (string)rMandateDetail["idaccmotiveannulment"];
            Assert.AreEqual("000800110003", attualCodeAnn, "Il codice della causale d'annullo è corrispondente");

            //Verifico la causale di costo "Cancelleria toner e inchiostri"
            string attualCodeCosto = rMandateDetail["idaccmotive"] == DBNull.Value ? "" : (string)rMandateDetail["idaccmotive"];
            Assert.AreEqual("000100020008", attualCodeCosto, "Il codice della causale di costo è corrispondente");

            //GENERO LE SCRITTURE E CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaImpegniScritture(rMan);
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rMan);

            bool scrittureabilitate = t.abilitaScrittureUT(rMan);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");

            //CONTROLLO NUMERO IMPEGNI DI BUDGET    ok
            int countNepexp2020 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2020)).Length;
            Assert.AreEqual(2, countNepexp2020, "Sono presenti due impegni di budget");

            //CONTROLLO VARIAZIONI AI MOVIMENTI DI BUDGET   ok
            int countNVarepexp2020 = dsEP.Tables["epexpvar"]._Filter(q.eq("yvar", 2020)).Length;
            Assert.AreEqual(2, countNVarepexp2020, "E' presente una var. di budget");// Preimpegno e impegno

            DataRow[] EpexpvarAnn = dsEP.Tables["epexpvar"]._Filter(q.eq("yvar", 2020), null, "idepexp desc", true);
            DataRow rEpexpvarAnn = EpexpvarAnn[0];
            object id_epexpvarAnn = rEpexpvarAnn["idepexp"];


            //CONTROLLO IMPEGNO DI BUDGET
            DataRow[] EpexpAtt = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.ne("idepexp", id_epexpvarAnn));
            DataRow rEpexpAtt = EpexpAtt[0];
            object id_epexpAtt = rEpexpAtt["idepexp"];
            DataRow[] EpexpAnn = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("idepexp", id_epexpvarAnn));
            DataRow rEpexpAnn = EpexpAnn[0];

            DataRow[] EpexpeyearAnn = dsEP.Tables["epexpyear"]._Filter(q.eq("ayear", 2020) & q.eq("idepexp", id_epexpvarAnn));
            DataRow rEpexpeyearAnn = EpexpeyearAnn[0];

            DataRow[] EpexpeyearAttivo = dsEP.Tables["epexpyear"]._Filter(q.eq("ayear", 2020) & q.eq("idepexp", id_epexpAtt));
            DataRow rEpexpeyearAttivo = EpexpeyearAttivo[0];

            Assert.AreEqual(rEpexpeyearAnn["amount"], 2000.00m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(rEpexpeyearAnn["idacc"], "20000200010002000100060001", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(rEpexpeyearAnn["idupb"], "00010003", "L'UPB del mov.budget è corrispondente");

            Assert.AreEqual(rEpexpeyearAttivo["amount"], 3500.00m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(rEpexpeyearAttivo["idacc"], "20000200010002000100060001", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(rEpexpeyearAttivo["idupb"], "00010003", "L'UPB del mov.budget è corrispondente");

            Assert.AreEqual(rEpexpAtt["idaccmotive"], "000100020008", "La causale del mov.budget è corrispondente");
            Assert.AreEqual(rEpexpAnn["idaccmotive"], "000100020008", "La causale del mov.budget è corrispondente");


            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET   ok
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2020)).Length;
            Assert.AreEqual(0, countNepacc2019, "Non ci sono accertamenti di budget del 2020");


            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            var tEntrydetail = dsEP.Tables["entrydetail"];
            var rEntry = dsEP.Tables["entry"].Rows[0];
            var date_doc_colleg = new DateTime(2020, 12, 31);
            var date_contab = new DateTime(2020, 12, 31);
            Assert.AreEqual(rEntry["description"], "Test annullo stesso anno CP", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "C.P. AMCEN_GEN 20/1", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");
            //1 DETTAGLIO SCRITTURA
            var descr1 =
                 "Contratto Passivo AMCEN_GEN 20/1 dett. 1- Test annullo stesso anno CP";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1);
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(EntryDetail1["description"], descr1, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idacc"], "20000200010002000100060001", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idupb"], "00010003", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idreg"], 9759, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idaccmotive"], "000100020008", "La causale del dettaglio della scrittura è corrispondente");
            //2 DETTAGLIO SCRITTURA
            var descr2 =
                "Contratto passivo AMCEN_GEN n.1 / 2020 dett. 1";
            q filterEDetail2 = q.eq("description", descr2);
            var EntryDetail2Rows = tEntrydetail._Filter(filterEDetail2);
            var EntryDetail2 = EntryDetail2Rows[0];
            Assert.AreEqual(EntryDetail2["description"], descr2, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idacc"], "20000300040002000100010001", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idupb"], "00010003", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idreg"], 9759, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idaccmotive"], "000100020008", "La causale del dettaglio della scrittura è corrispondente");

            //3 DETTAGLIO SCRITTURA
            var descr3 =
                 "Contratto Passivo AMCEN_GEN 20/1 dett. 2- Test annullo stesso anno CP";
            q filterEDetail3 = q.eq("description", descr3);
            var EntryDetail3Rows = tEntrydetail._Filter(filterEDetail3);
            var EntryDetail3 = EntryDetail3Rows[0];
            Assert.AreEqual(EntryDetail3["description"], descr3, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail3["idacc"], "20000200010002000100060001", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail3["idupb"], "00010003", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail3["idreg"], 9759, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail3["idaccmotive"], "000100020008", "La causale del dettaglio della scrittura è corrispondente");
            //4 DETTAGLIO SCRITTURA
            var descr4 =
                "Contratto passivo AMCEN_GEN n.1 / 2020 dett. 2";
            q filterEDetail4 = q.eq("description", descr4);
            var EntryDetail4Rows = tEntrydetail._Filter(filterEDetail4);
            var EntryDetail4 = EntryDetail4Rows[0];
            Assert.AreEqual(EntryDetail4["description"], descr4, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail4["idacc"], "20000300040002000100010001", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail4["idupb"], "00010003", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail4["idreg"], 9759, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail4["idaccmotive"], "000100020008", "La causale del dettaglio della scrittura è corrispondente");
            //5 DETTAGLIO SCRITTURA
            var descr5 =
                 "Contratto Passivo AMCEN_GEN 20/1 dett. 1- Test annullo stesso anno CP";
            q filterEDetail5 = q.eq("description", descr5);
            var EntryDetail5Rows = tEntrydetail._Filter(filterEDetail5);
            var EntryDetail5 = EntryDetail5Rows[0];
            Assert.AreEqual(EntryDetail5["description"], descr5, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail5["idacc"], "20000200010002000100060001", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail5["idupb"], "00010003", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail5["idreg"], 9759, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail5["idaccmotive"], "000100020008", "La causale del dettaglio della scrittura è corrispondente");
            //6 DETTAGLIO SCRITTURA
            var descr6 =
                "Contratto passivo AMCEN_GEN n.1 / 2020 dett. 1";
            q filterEDetail6 = q.eq("description", descr6);
            var EntryDetail6Rows = tEntrydetail._Filter(filterEDetail6);
            var EntryDetail6 = EntryDetail6Rows[0];
            Assert.AreEqual(EntryDetail6["description"], descr6, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail6["idacc"], "20000300040002000100010001", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail6["idupb"], "00010003", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail6["idreg"], 9759, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail6["idaccmotive"], "000100020008", "La causale del dettaglio della scrittura è corrispondente");
            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            Assert.AreEqual(1, dsEP.Tables["entry"]._Filter(null).Length, "Presente una scrittura");

            Assert.AreEqual(6, dsEP.Tables["entrydetail"]._Filter(q.eq("nentry", rEntry["nentry"])).Length, "Sono presenti sei dettagli relativi alla scrittura");
            var avere = (decimal)dsEP.Tables["entrydetail"]._Filter(q.gt("amount", 0) & q.eq("nentry", rEntry["nentry"])).GetSum<decimal>("amount");
            Assert.AreEqual(7500.00m, avere, "Avere corrispondente");

            //CONTROLLO CORRISPONDENZA TRA SCRITTURA E MOVIMENTO DI BUDGET
            Assert.AreEqual(EntryDetail3["idepexp"], rEpexpAtt["idepexp"]);
            Assert.AreEqual(EntryDetail3["idrelated"], rEpexpAtt["idrelated"]);

            Assert.AreEqual(EntryDetail4["idepexp"], rEpexpAtt["idepexp"]);
            Assert.AreEqual(EntryDetail4["idrelated"], rEpexpAtt["idrelated"]);

            Assert.AreEqual(EntryDetail1["idepexp"], rEpexpAnn["idepexp"]);
            Assert.AreEqual(EntryDetail1["idrelated"], rEpexpAnn["idrelated"]);

            Assert.AreEqual(EntryDetail2["idepexp"], rEpexpAnn["idepexp"]);
            Assert.AreEqual(EntryDetail2["idrelated"], rEpexpAnn["idrelated"]);

            Assert.AreEqual(EntryDetail5["idepexp"], rEpexpAnn["idepexp"]);
            Assert.AreEqual(EntryDetail5["idrelated"], rEpexpAnn["idrelated"]);

            Assert.AreEqual(EntryDetail6["idepexp"], rEpexpAnn["idepexp"]);
            Assert.AreEqual(EntryDetail6["idrelated"], rEpexpAnn["idrelated"]);
            }

        [TestMethod]
        public void Test_mandate_2020_annullo2021_CausCosto_NonCollFattura() {
            // c)Annullo anni successivi con casuale di COSTO 
            var t = new TestHelp(new DateTime(2021, 12, 31), "sample_2", "test_2");
            q filterMan = q.eq("idmankind", "AMCEN_GEN") & q.eq("yman", 2020) & q.eq("nman", 18);
            t.binaryReplaceSet(filterMan, t.getTableSet(TestHelp.mainObject.mandate));
            DataTable tMandate = t.testConn.readTable("mandate", filterMan);
            DataRow rMan = tMandate.Rows[0];
            Assert.AreEqual(1, tMandate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rMan, false);
            DataTable tMandateDetail = t.testConn.readTable("mandatedetail", filterMan & q.isNotNull("stop"));
            int nManDet = tMandateDetail.Rows.Count;
            Assert.AreEqual(2, nManDet, "Il contratto ha 2 dettagli annullati");

            //VERIFICO CHE LA CAUSALE DI ANNULLO  (Sopravvenienze attive) 
            DataRow rMandateDetail = tMandateDetail.Rows[0];
            //string attualCodeAnn = rMandateDetail["idaccmotiveannulment"] == DBNull.Value ? "" : (string)rMandateDetail["idaccmotiveannulment"];
            //Assert.AreEqual("000100020008", attualCodeAnn, "Il codice della causale d'annullo è corrispondente");

            //Verifico la causale di costo "Cancelleria toner e inchiostri"
            string attualCodeCosto = rMandateDetail["idaccmotive"] == DBNull.Value ? "" : (string)rMandateDetail["idaccmotive"];
            Assert.AreEqual("000100020008", attualCodeCosto, "Il codice della causale di costo è corrispondente");

            //GENERO LE SCRITTURE E CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaImpegniScritture(rMan);
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rMan);

            bool scrittureabilitate = t.abilitaScrittureUT(rMan);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");

            //CONTROLLO VARIAZIONI AI MOVIMENTI DI BUDGET   ok
            int countNVarepexp2021 = dsEP.Tables["epexpvar"]._Filter(q.eq("yvar", 2021)).Length;
            Assert.AreEqual(0, countNVarepexp2021, "Non vi sono var. di budget");// Preimpegno e impegno

            //CONTROLLO NUMERO IMPEGNI DI BUDGET
            int countNepexp2020 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2020)).Length;
            Assert.AreEqual(1, countNepexp2020, "E' presente un impegno di budget del 2020");
            int countNepexp2021 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2021) & q.eq("flagvariation", "S")).Length;
            Assert.AreEqual(1, countNepexp2021, "E' presente un impegno di budget del 2021");

            //CONTROLLO IMPEGNO DI BUDGET
            DataRow[] rEpexp20 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2020));
            DataRow[] rEpexpeyear20 = dsEP.Tables["epexpyear"]._Filter(q.eq("ayear", 2021));
            DataRow dr20_epexp = rEpexp20[0];
            DataRow dr20_epexpyear = rEpexpeyear20[0];
            Assert.AreEqual(dr20_epexp["description"], "Annullo anni successivi con causale di COSTO", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr20_epexpyear["idacc"], "21000200010002000100060001", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr20_epexpyear["idupb"], "00010003", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr20_epexp["idaccmotive"], "000100020008", "La causale del mov.budget è corrispondente");
            t.checkImportoInizialeImpBudget(dsEP.Tables["epexp"], dr20_epexp["idepexp"], 2021, 0m);//ora vale 0

            DataRow[] rEpexp21 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2021) & q.eq("flagvariation", "S"));
            DataRow[] rEpexpeyear21 = dsEP.Tables["epexpyear"]._Filter(q.eq("ayear", 2021));
            DataRow dr21_epexp = rEpexp21[0];
            DataRow dr21_epexpyear = rEpexpeyear21[0];
            Assert.AreEqual(dr21_epexp["description"], "Annullo anni successivi con causale di COSTO", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr21_epexpyear["idacc"], "21000200010002000100060001", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr21_epexpyear["idupb"], "00010003", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr21_epexp["idaccmotive"], "000100020008", "La causale del mov.budget è corrispondente");
            t.checkImportoInizialeImpBudget(dsEP.Tables["epexp"], dr21_epexp["idepexp"], 2021, 1000m);

            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET   ok
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2021)).Length;
            Assert.AreEqual(0, countNepacc2019, "Non ci sono accertamenti di budget del 2020");

            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            var tEntrydetail = dsEP.Tables["entrydetail"];
            var rEntry = dsEP.Tables["entry"].Rows[0];
            var date_doc_colleg = new DateTime(2020, 12, 31); 
            var date_contab = (DateTime)rMandateDetail["start"];
            Assert.AreEqual(rEntry["description"], "Annullo anni successivi con causale di COSTO", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "C.P. AMCEN_GEN 20/18", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");
            //1 DETTAGLIO SCRITTURA
            var descr1 =
                 "C.P. AMCEN_GEN 20/182- Annullo anni successivi con causale di COSTO";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1);
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(EntryDetail1["description"], descr1, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idacc"], "21000200010002000100060001", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idupb"], "00010003", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idreg"], 9759, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idaccmotive"], "000100020008", "La causale del dettaglio della scrittura è corrispondente");
            //2 DETTAGLIO SCRITTURA
            var descr2 =
                "Contratto passivo AMCEN_GEN n.18 / 2020 n°2";
            q filterEDetail2 = q.eq("description", descr2);
            var EntryDetail2Rows = tEntrydetail._Filter(filterEDetail2);
            var EntryDetail2 = EntryDetail2Rows[0];
            Assert.AreEqual(EntryDetail2["description"], descr2, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idacc"], "21000300040002000100010001", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idupb"], "00010003", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idreg"], 9759, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idaccmotive"], "000100020008", "La causale del dettaglio della scrittura è corrispondente");

            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            Assert.AreEqual(2, dsEP.Tables["entry"]._Filter(null).Length, "Presente una scrittura");

            Assert.AreEqual(2, dsEP.Tables["entrydetail"]._Filter(q.eq("nentry", rEntry["nentry"])).Length, "Sono presenti due dettagli relativi alla scrittura");
            var avere = (decimal)dsEP.Tables["entrydetail"]._Filter(q.gt("amount", 0) & q.eq("nentry", rEntry["nentry"])).GetSum<decimal>("amount");
            Assert.AreEqual(1000.00m, avere, "Avere corrispondente");

            //CONTROLLO CORRISPONDENZA TRA SCRITTURA E MOVIMENTO DI BUDGET
            Assert.AreEqual(EntryDetail1["idepexp"], dr21_epexp["idepexp"]);
            Assert.AreEqual(EntryDetail1["idrelated"], dr21_epexp["idrelated"]);

            Assert.AreEqual(EntryDetail2["idepexp"], dr20_epexp["idepexp"]);
            Assert.AreEqual(EntryDetail2["idrelated"], dr20_epexp["idrelated"]);
            }

        [TestMethod]
        public void Test_mandate_2020_annullo2021_CausRicavo_NonCollFattura() {
            //public void Test2_estimate_2018_annullo2019_NonCollFattura2() {
            // d)Annullo anni successivi con casuale di RICAVO 
            var t = new TestHelp(new DateTime(2021, 12, 31), "sample_2", "test_2");
            q filterMan = q.eq("idmankind", "AMCEN_GEN") & q.eq("yman", 2020) & q.eq("nman", 27);
            t.binaryReplaceSet(filterMan, t.getTableSet(TestHelp.mainObject.mandate));
            DataTable tMandate = t.testConn.readTable("mandate", filterMan);

            DataRow rMan = tMandate.Rows[0];
            Assert.AreEqual(1, tMandate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rMan, false);
            DataTable tMandateDetail = t.testConn.readTable("mandatedetail", filterMan & q.isNotNull("stop"));
            int nEstDet = tMandateDetail.Rows.Count;
            Assert.AreEqual(1, nEstDet, "Il contratto ha dettagli annullati");

            DataRow estimDet1 = tMandateDetail.Rows[0];

            object idepacc1 = estimDet1["idepacc"];

            //VERIFICO CHE LA CAUSALE DI ANNULLO SIA CORRETTA (CN1.5.01.03.008) 
            DataRow rMandateDetail = tMandateDetail.Rows[0];
            string attualCode = rMandateDetail["idaccmotiveannulment"] == DBNull.Value ? "" : (string)rMandateDetail["idaccmotiveannulment"];
            Assert.AreEqual("000800110003", attualCode, "Il codice della causale d'annullo è corrispondente");

            //GENERO LE SCRITTURE E CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaImpegniScritture(rMan);
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rMan);

            bool scrittureabilitate = t.abilitaScrittureUT(rMan);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");

            //CONTROLLO VARIAZIONI AI MOVIMENTI DI BUDGET
            DataRow[] rEpaccpvar = dsEP.Tables["epaccvar"]._Filter(null);
            Assert.AreEqual(rEpaccpvar.Length, 0, "Non Sono  presenti variazioni");

            //CONTROLLO NUMERO IMPEGNI DI BUDGET
            int countNepexp2019 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2020)).Length;
            Assert.AreEqual(1, countNepexp2019, "E' presente un impegno di budget");
            int countNepexp2018 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2021)).Length;
            Assert.AreEqual(0, countNepexp2018, "Non ci sono impegni di budget del 2021");

            //CONTROLLO IMPEGNO DI BUDGET
            DataRow[] rEpexp = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2));
            DataRow[] rEpexpeyear = dsEP.Tables["epexpyear"]._Filter(q.eq("ayear", 2021));
            DataRow dr1_epexp = rEpexp[0];
            DataRow dr1_epexpyear = rEpexpeyear[0];
            Assert.AreEqual(dr1_epexp["description"], "Annullo anni successivi con causale di RICAVO", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epexpyear["idacc"], "21000200010002000100060001", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexpyear["amount"], 0m, "L'importo 2021 del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexpyear["idupb"], "00010003", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexp["idaccmotive"], "000100020008", "La causale del mov.budget è corrispondente");
            t.checkImportoInizialeImpBudget(dsEP.Tables["epexp"], dr1_epexp["idepexp"], 2021, 0m);

            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2020)).Length;
            Assert.AreEqual(0, countNepacc2019, "Non ci sono accertamenti di budget del 2020");
            int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2021)).Length;
            Assert.AreEqual(1, countNepacc2018, "E' presente un accertamento di budget del 2021");

            // t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2021, 86541, 2018, 100m);
            //CONTROLLO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO Passivo
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2021) & q.eq("idepacc", idepacc1));
            DataRow[] rEpaccyear_2021 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2021) & q.eq("idepacc", idepacc1));
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear_2021 = rEpaccyear_2021[0];
            DataRow drEpaccyear_2021 = rEpaccyear_2021[0];
            Assert.AreEqual(dr1_epacc["description"], "Annullo anni successivi con causale di RICAVO", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epaccyear_2021["amount"], 1000m, "L'importo 2021 del mov.budget è corrispondente");
           Assert.AreEqual(drEpaccyear_2021["idacc"], "21000400040003000100010001", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(drEpaccyear_2021["idupb"], "00010003", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["idaccmotive"], "000800110003", "La causale del mov.budget è corrispondente");

            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            var tEntrydetail = dsEP.Tables["entrydetail"];
            var rEntry = dsEP.Tables["entry"].Rows[0];
            var date_doc_colleg = new DateTime(2020, 12, 31);
            var date_contab = new DateTime(2021, 01, 29);
            Assert.AreEqual(rEntry["description"], "Annullo anni successivi con causale di RICAVO", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "sa", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");
            //PRIMO DETTAGLIO SCRITTURA
            var descr1 =
                 "Contratto passivo AMCEN_GEN n.27 / 2020 n°1";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1);
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(EntryDetail1["description"], descr1, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idacc"], "21000300040002000100010001", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idupb"], "00010003", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idreg"], 9759, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idaccmotive"], "000800110003", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idepexp"], dr1_epexp["idepexp"]);
            Assert.AreEqual(EntryDetail1["idrelated"], dr1_epexp["idrelated"]);
            //SECONDO DETTAGLIO SCRITTURA
            var descr2 =
                "C.P. AMCEN_GEN 20/271- Annullo anni successivi con causale di RICAVO";
            q filterEDetail2 = q.eq("description", descr2);
            var EntryDetail2Rows = tEntrydetail._Filter(filterEDetail2);
            var EntryDetail2 = EntryDetail2Rows[0];
            Assert.AreEqual(EntryDetail2["description"], descr2, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idacc"], "21000400040003000100010001", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idupb"], "00010003", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idreg"], 9759, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idaccmotive"], "000800110003", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idepacc"], idepacc1);
            Assert.AreEqual(EntryDetail2["idrelated"], dr1_epacc["idrelated"]);
            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            Assert.AreEqual(2, dsEP.Tables["entry"]._Filter(null).Length, "Sono presenti due scritture");
            //CONTROLLO DETTAGLI SCRITTURA ESERCIZIO 2019
            Assert.AreEqual(2, dsEP.Tables["entrydetail"]._Filter(q.eq("nentry", rEntry["nentry"])).Length, "Sono presenti 2 dettagli relativi alla scrittura");
            var avere = (decimal)dsEP.Tables["entrydetail"]._Filter(q.gt("amount", 0) & q.eq("nentry", rEntry["nentry"])).GetSum<decimal>("amount");
            Assert.AreEqual(1000m, avere, "Avere corrispondente");
            }

        [TestMethod]
        public void Test_mandate_2020_annullo2020_NonCollFattura_split() {
            // f)	Annullo stesso anno CP righe splittate
            var t = new TestHelp(new DateTime(2020, 12, 31), "sample_2", "test_2");
            q filterMan = q.eq("idmankind", "AMCEN_GEN") & q.eq("yman", 2020) & q.eq("nman", 22);
            t.binaryReplaceSet(filterMan, t.getTableSet(TestHelp.mainObject.mandate));
            DataTable tMandate = t.testConn.readTable("mandate", filterMan);
            DataRow rMan = tMandate.Rows[0];
            Assert.AreEqual(1, tMandate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rMan, false);
            DataTable tMandateDetail = t.testConn.readTable("mandatedetail", filterMan & q.isNotNull("stop"),"*", " rownum ", null);
            int nManDet = tMandateDetail.Rows.Count;
            Assert.AreEqual(2, nManDet, "Il contratto ha due dettagli annullati");

            DataRow manDet1 = tMandateDetail.Rows[0];
            DataRow manDet2 = tMandateDetail.Rows[1];
            // 66723 
            object idepexp1 = manDet1["idepexp"];
            string idrelated1 = BudgetFunction.GetIdForDocument(manDet1);
            string idrelated2 = BudgetFunction.GetIdForDocument(manDet2);
            // 66724
            object idepexp2 = manDet2["idepexp"];
            //Verifico la causale di costo "Cancelleria toner e inchiostri"
            string attualCodeCosto1 = manDet1["idaccmotive"] == DBNull.Value ? "" : (string)manDet1["idaccmotive"];
            Assert.AreEqual("000100020008", attualCodeCosto1, "Il codice della causale di costo è corrispondente");
            string attualCodeCosto2 = manDet2["idaccmotive"] == DBNull.Value ? "" : (string)manDet2["idaccmotive"];
            Assert.AreEqual("000100020008", attualCodeCosto2, "Il codice della causale di costo è corrispondente");

            //GENERO LE SCRITTURE E CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaImpegniScritture(rMan);
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rMan);

            bool scrittureabilitate = t.abilitaScrittureUT(rMan);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");

            //CONTROLLO NUMERO IMPEGNI DI BUDGET    
            int countNepexp = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2020)).Length;
            Assert.AreEqual(2, countNepexp, "Sono presenti due impegni di budget");

            //CONTROLLO VARIAZIONI AI MOVIMENTI DI BUDGET   
            DataRow[] rEpexpvar = dsEP.Tables["epexpvar"]._Filter(q.eq("yvar", 2020));
            Assert.AreEqual(rEpexpvar.Length, 4, "Sono  presenti 4 variazioni");

            //CONTROLLO IMPEGNO DI BUDGET
            DataRow[] rEpexp1 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("idepexp", idepexp1));
            DataRow[] rEpexpeyear1 = dsEP.Tables["epexpyear"]._Filter(q.eq("ayear", 2020) & q.eq("idepexp", idepexp1));
            DataRow dr1_epexp = rEpexp1[0];
            DataRow dr1_epexpyear = rEpexpeyear1[0];
            Assert.AreEqual(dr1_epexp["description"], "Annullo  stesso anno CP righe splittate stesso gruppo", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epexpyear["idacc"], "20000200010002000100060001", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexpyear["idupb"], "00010001", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexp["idaccmotive"], "000100020008", "La causale del mov.budget è corrispondente");
            t.checkImportoInizialeImpBudget(dsEP.Tables["epexp"], dr1_epexp["idepexp"], 2020, 300m);

            DataRow[] rEpexp2 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("idepexp", idepexp2));
            DataRow[] rEpexpeyear2 = dsEP.Tables["epexpyear"]._Filter(q.eq("ayear", 2020) & q.eq("idepexp", idepexp2));
            DataRow dr2_epexp = rEpexp2[0];
            DataRow dr2_epexpyear = rEpexpeyear2[0];
            Assert.AreEqual(dr2_epexp["description"], "Annullo  stesso anno CP righe splittate stesso gruppo", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr2_epexpyear["idacc"], "20000200010002000100060001", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epexpyear["idupb"], "00010003", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epexp["idaccmotive"], "000100020008", "La causale del mov.budget è corrispondente");
            t.checkImportoInizialeImpBudget(dsEP.Tables["epexp"], dr2_epexp["idepexp"], 2020, 700m);

            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            var tEntrydetail = dsEP.Tables["entrydetail"];
            var rEntry = dsEP.Tables["entry"].Rows[0];
            var date_doc_colleg = new DateTime(2020, 12, 31);
            var date_contab = new DateTime(2020, 12, 31);
            Assert.AreEqual(rEntry["description"], "Annullo  stesso anno CP righe splittate stesso gruppo", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "sa", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");
            //PRIMO DETTAGLIO SCRITTURA
            var descr1 =
                 "Contratto Passivo AMCEN_GEN 20/22 dett. 1- Annullo  stesso anno CP righe splittate stesso gruppo";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1);
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(EntryDetail1["description"], descr1, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idupb"], "00010001", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idreg"], 9759, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idaccmotive"], "000100020008", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idepexp"], idepexp1);
            Assert.AreEqual(EntryDetail1["idacc"], "20000200010002000100060001", "Il conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idrelated"], idrelated1);
            //SECONDO DETTAGLIO SCRITTURA
            var descr2 =
                "Contratto passivo AMCEN_GEN n.22 / 2020 dett. 1";
            q filterEDetail2 = q.eq("description", descr2);
            var EntryDetail2Rows = tEntrydetail._Filter(filterEDetail2);
            var EntryDetail2 = EntryDetail2Rows[0];
            Assert.AreEqual(EntryDetail2["description"], descr2, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idupb"], "00010001", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idreg"], 9759, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idaccmotive"], "000100020008", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idepexp"], idepexp1);
            Assert.AreEqual(EntryDetail2["idacc"], "20000300040002000100010001", "Il conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idrelated"], idrelated1);
            //TERZO DETTAGLIO SCRITTURA
            var descr3 =
                "Contratto Passivo AMCEN_GEN 20/22 dett. 2- Annullo  stesso anno CP righe splittate stesso gruppo";
            q filterEDetail3 = q.eq("description", descr3);
            var EntryDetail3Rows = tEntrydetail._Filter(filterEDetail3);
            var EntryDetail3 = EntryDetail3Rows[0];
            Assert.AreEqual(EntryDetail3["description"], descr3, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail3["idupb"], "00010003", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail3["idreg"], 9759, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail3["idaccmotive"], "000100020008", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail3["idepexp"], idepexp2);
            Assert.AreEqual(EntryDetail3["idacc"], "20000200010002000100060001", "Il conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail3["idrelated"], idrelated2);
            //QUARTO DETTAGLIO SCRITTURA
            var descr4 =
                "Contratto passivo AMCEN_GEN n.22 / 2020 dett. 2";
            q filterEDetail4 = q.eq("description", descr4);
            var EntryDetail4Rows = tEntrydetail._Filter(filterEDetail4);
            var EntryDetail4 = EntryDetail4Rows[0];
            Assert.AreEqual(EntryDetail4["description"], descr4, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail4["idupb"], "00010003", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail4["idreg"], 9759, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail4["idaccmotive"], "000100020008", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail4["idepexp"], idepexp2);
            Assert.AreEqual(EntryDetail4["idacc"], "20000300040002000100010001", "Il conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail4["idrelated"], idrelated2);
            //QUINTO DETTAGLIO SCRITTURA
            var descr5 =
                "Contratto Passivo AMCEN_GEN 20/22 dett. 2- Annullo  stesso anno CP righe splittate stesso gruppo";
            q filterEDetail5 = q.eq("description", descr5);
            var EntryDetail5Rows = tEntrydetail._Filter(filterEDetail5);
            var EntryDetail5 = EntryDetail5Rows[0];
            Assert.AreEqual(EntryDetail5["description"], descr5, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail5["idupb"], "00010003", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail5["idreg"], 9759, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail5["idaccmotive"], "000100020008", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail5["idepexp"], idepexp2);
            Assert.AreEqual(EntryDetail5["idacc"], "20000200010002000100060001", "Il conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail5["idrelated"], idrelated2);
            //SESTO DETTAGLIO SCRITTURA
            var descr6 =
                "Contratto passivo AMCEN_GEN n.22 / 2020 dett. 2";
            q filterEDetail6 = q.eq("description", descr6);
            var EntryDetail6Rows = tEntrydetail._Filter(filterEDetail6);
            var EntryDetail6 = EntryDetail6Rows[0];
            Assert.AreEqual(EntryDetail6["description"], descr6, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail6["idupb"], "00010003", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail6["idreg"], 9759, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail6["idaccmotive"], "000100020008", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail6["idepexp"], idepexp2);
            Assert.AreEqual(EntryDetail6["idacc"], "20000300040002000100010001", "Il conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail6["idrelated"], idrelated2);

            var descr7 =
            "Contratto Passivo AMCEN_GEN 20/22 dett. 1- Annullo  stesso anno CP righe splittate stesso gruppo";
            q filterEDetail7 = q.eq("description", descr7);
            var EntryDetail7Rows = tEntrydetail._Filter(filterEDetail7);
            var EntryDetail7 = EntryDetail7Rows[0];
            Assert.AreEqual(EntryDetail7["description"], descr7, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail7["idupb"], "00010001", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail7["idreg"], 9759, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail7["idaccmotive"], "000100020008", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail7["idepexp"], idepexp1);
            Assert.AreEqual(EntryDetail7["idacc"], "20000200010002000100060001", "Il conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail7["idrelated"], idrelated1);

            var descr8 =
                "Contratto passivo AMCEN_GEN n.22 / 2020 dett. 1";
            q filterEDetail8 = q.eq("description", descr8);
            var EntryDetail8Rows = tEntrydetail._Filter(filterEDetail8);
            var EntryDetail8 = EntryDetail8Rows[0];
            Assert.AreEqual(EntryDetail8["description"], descr8, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail8["idupb"], "00010001", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail8["idreg"], 9759, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail8["idaccmotive"], "000100020008", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail8["idepexp"], idepexp1);
            Assert.AreEqual(EntryDetail8["idacc"], "20000300040002000100010001", "Il conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail8["idrelated"], idrelated1);
            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            Assert.AreEqual(1, dsEP.Tables["entry"]._Filter(null).Length, "E' presente una scrittura");
            //CONTROLLO DETTAGLI SCRITTURA ESERCIZIO 2019
            Assert.AreEqual(8, dsEP.Tables["entrydetail"]._Filter(q.eq("nentry", rEntry["nentry"])).Length, "Sono presenti 8 dettagli relativi alla scrittura");
            var avere = (decimal)dsEP.Tables["entrydetail"]._Filter(q.gt("amount", 0) & q.eq("nentry", rEntry["nentry"])).GetSum<decimal>("amount");
            Assert.AreEqual(2000m, avere, "Avere corrispondente");
            }

        [TestMethod]
        public void Test2_mandate_2020_Pagato_righesplit_Annullo() {
            // g)	Annullo stesso anno CP pagato righe splittate
            var t = new TestHelp(new DateTime(2020, 12, 31), "sample_2", "test_2");
            q filterMan = q.eq("idmankind", "AMCEN_GEN") & q.eq("yman", 2020) & q.eq("nman", 21);
            t.binaryReplaceSet(filterMan, t.getTableSet(TestHelp.mainObject.mandate));
            DataTable tMandate = t.testConn.readTable("mandate", filterMan);
            DataRow rMan = tMandate.Rows[0];
            Assert.AreEqual(1, tMandate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rMan, false);
            DataTable tMandateDetail = t.testConn.readTable("mandatedetail", filterMan);
            int nMandDet = tMandateDetail.Rows.Count;
            Assert.AreEqual(2, nMandDet, "Il contratto ha 2 dettagli");

            //MODIFICO IL DATASET DELL'mandateDETAIL(IL PRIMO ROWNUM 1) PER VERIFICARE CHE SCATTI LA REGOLA QUANDO ANNULLO IL DETTAGLIO
            var mMandate = TestHelp.editDataRow(t.testConn, filterMan, "mandate", "default");
            var ds = mMandate.ds;
            var tMandateDet = ds.Tables["mandatedetail"];
            var rManDet = tMandateDet._Filter(q.eq("rownum", 1))[0];
            rManDet["lt"] = new DateTime(2020, 12, 31, 20, 41, 48, 573); ;
            rManDet["lu"] = "assistenza";
            rManDet["stop"] = new DateTime(2020, 12, 31);

            //SALVO I DATI DEL FORM MODIFICATO
            var res = t.saveFormData(mMandate);
            checkExistRule(res, "MOVIM176");
            }

        [TestMethod]
        public void Test_mandate_2020_sostituzione_2020_NonCollFattura() {
            // j)	Sostituzione stesso anno
            var t = new TestHelp(new DateTime(2020, 12, 31), "sample_2", "test_2");
            q filterMan = q.eq("idmankind", "AMCEN_GEN") & q.eq("yman", 2020) & q.eq("nman", 29);
            t.binaryReplaceSet(filterMan, t.getTableSet(TestHelp.mainObject.mandate));
            DataTable tMandate = t.testConn.readTable("mandate", filterMan);
            DataRow rMan = tMandate.Rows[0];
            Assert.AreEqual(1, tMandate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rMan, false);
            DataTable tMandateDetail = t.testConn.readTable("mandatedetail", filterMan & q.isNotNull("stop"), "*", " rownum ", null);
            int nManDet = tMandateDetail.Rows.Count;
            Assert.AreEqual(1, nManDet, "Il contratto ha un dettaglio annullato");

            DataRow manDet = tMandateDetail.Rows[0];
            object idepexp = manDet["idepexp"];
            DataTable tMandateDetailAttivo = t.testConn.readTable("mandatedetail", filterMan & q.isNull("stop"), "*", " rownum ", null);
            int nManDetAttivo = tMandateDetailAttivo.Rows.Count;
            Assert.AreEqual(1, nManDet, "Il contratto ha un dettaglio non annullato");
            string idrelated = BudgetFunction.GetIdForDocument(tMandateDetailAttivo.Rows[0]);

           //Verifico la causale di costo "Cancelleria toner e inchiostri"
            string attualCodeCosto = manDet["idaccmotive"] == DBNull.Value ? "" : (string)manDet["idaccmotive"];
            Assert.AreEqual("000100020008", attualCodeCosto, "Il codice della causale di costo è corrispondente");

            //GENERO LE SCRITTURE E CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaImpegniScritture(rMan);
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rMan);

            bool scrittureabilitate = t.abilitaScrittureUT(rMan);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");

            //CONTROLLO NUMERO IMPEGNI DI BUDGET    ok
            int countNepexp = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2020)).Length;
            Assert.AreEqual(1, countNepexp, "E' presente un impegno di budget");

            //CONTROLLO VARIAZIONI AI MOVIMENTI DI BUDGET   ok
            int countNVarepexp = dsEP.Tables["epexpvar"]._Filter(q.eq("yvar", 2020)).Length;
            Assert.AreEqual(2, countNVarepexp, "Sono presenti due var. di budget");// Preimpegno e impegno

            //CONTROLLO VARIAZIONI AI MOVIMENTI DI BUDGET   
            DataRow[] rEpexpvar = dsEP.Tables["epexpvar"]._Filter(q.eq("yvar", 2020));
            Assert.AreEqual(rEpexpvar.Length, 2, "Ci sono due var di Impegno di budget");

            //CONTROLLO IMPEGNO DI BUDGET
            DataRow[] rEpexp1 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2));
            DataRow[] rEpexpeyear1 = dsEP.Tables["epexpyear"]._Filter(q.eq("ayear", 2020));
            DataRow dr1_epexp = rEpexp1[0];
            DataRow dr1_epexpyear = rEpexpeyear1[0];
            Assert.AreEqual(dr1_epexp["description"], "Sostituzione stesso anno", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epexpyear["idacc"], "20000200010002000100060001", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexpyear["idupb"], "00010003", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexp["idaccmotive"], "000100020008", "La causale del mov.budget è corrispondente");
            t.checkImportoInizialeImpBudget(dsEP.Tables["epexp"], dr1_epexp["idepexp"], 2020, 1000m);

            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            var tEntrydetail = dsEP.Tables["entrydetail"];
            var rEntry = dsEP.Tables["entry"].Rows[0];
            var date_doc_colleg = new DateTime(2020, 12, 31);
            var date_contab = new DateTime(2020, 12, 31);
            Assert.AreEqual(rEntry["description"], "Sostituzione stesso anno", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "sa", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");
            //PRIMO DETTAGLIO SCRITTURA
            var descr1 =
                 "Contratto Passivo AMCEN_GEN 20/29 dett. 1- Sostituzione stesso anno";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1 );
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(EntryDetail1["description"], descr1, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idupb"], "00010003", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idreg"], 9759, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idaccmotive"], "000100020008", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idepexp"], idepexp);
            Assert.AreEqual(EntryDetail1["idacc"], "20000200010002000100060001", "Il conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idrelated"], idrelated);
            //SECONDO DETTAGLIO SCRITTURA
            var descr2 =
                "Contratto passivo AMCEN_GEN n.29 / 2020 dett. 1";
            q filterEDetail2 = q.eq("description", descr2);
            var EntryDetail2Rows = tEntrydetail._Filter(filterEDetail2);
            var EntryDetail2 = EntryDetail2Rows[0];
            Assert.AreEqual(EntryDetail2["description"], descr2, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idupb"], "00010003", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idreg"], 9759, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idaccmotive"], "000100020008", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idepexp"], idepexp);
            Assert.AreEqual(EntryDetail2["idacc"], "20000300040002000100010001", "Il conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idrelated"], idrelated);


            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            Assert.AreEqual(1, dsEP.Tables["entry"]._Filter(null).Length, "E' presente una scrittura");
            //CONTROLLO DETTAGLI SCRITTURA ESERCIZIO 2019
            Assert.AreEqual(2, dsEP.Tables["entrydetail"]._Filter(q.eq("nentry", rEntry["nentry"])).Length, "Sono presenti 2 dettagli relativi alla scrittura");
            var avere = (decimal)dsEP.Tables["entrydetail"]._Filter(q.gt("amount", 0) & q.eq("nentry", rEntry["nentry"])).GetSum<decimal>("amount");
            Assert.AreEqual(700m, avere, "Avere corrispondente");
            }

        [TestMethod]
        public void Test_mandate_2020_sostituzionerigheSplit_2020_NonCollFattura() {
            // k)	Sostituzione stesso anno con righe splittate
            var t = new TestHelp(new DateTime(2020, 12, 31), "sample_2", "test_2");
            q filterMan = q.eq("idmankind", "AMCEN_GEN") & q.eq("yman", 2020) & q.eq("nman", 32);
            t.binaryReplaceSet(filterMan, t.getTableSet(TestHelp.mainObject.mandate));
            DataTable tMandate = t.testConn.readTable("mandate", filterMan);
            DataRow rMan = tMandate.Rows[0];
            Assert.AreEqual(1, tMandate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rMan, false);
            DataTable tMandateDetail = t.testConn.readTable("mandatedetail", filterMan & q.isNotNull("stop"), "*", " rownum ", null);
            int nManDet = tMandateDetail.Rows.Count;
            Assert.AreEqual(2, nManDet, "Il contratto ha due dettagli annullati");

            DataRow manDet3 = tMandateDetail.Rows[0];
            object idepexp3 = manDet3["idepexp"];//66734
            DataRow manDet4 = tMandateDetail.Rows[1];
            object idepexp4 = manDet4["idepexp"];//66733

            DataTable tMandateDetailAttivo = t.testConn.readTable("mandatedetail", filterMan & q.isNull("stop"), "*", " rownum ", null);
            int nManDetAtt = tMandateDetailAttivo.Rows.Count;
            Assert.AreEqual(2, nManDetAtt, "Il contratto ha due dettagli attivi");
            DataRow manDet1 = tMandateDetailAttivo.Rows[0];
            DataRow manDet2 = tMandateDetailAttivo.Rows[1];
            string idrelated1 = BudgetFunction.GetIdForDocument(manDet1);
            string idrelated2 = BudgetFunction.GetIdForDocument(manDet2);
            //Verifico la causale di costo "Cancelleria toner e inchiostri"
            string attualCodeCosto = manDet3["idaccmotive"] == DBNull.Value ? "" : (string)manDet3["idaccmotive"];
            Assert.AreEqual("000100020008", attualCodeCosto, "Il codice della causale di costo è corrispondente");
            Assert.AreEqual("000100020008", attualCodeCosto, "Il codice della causale di costo è corrispondente");
            Assert.AreEqual("000100020008", attualCodeCosto, "Il codice della causale di costo è corrispondente");
            Assert.AreEqual("000100020008", attualCodeCosto, "Il codice della causale di costo è corrispondente");

            //GENERO LE SCRITTURE E CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaImpegniScritture(rMan);
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rMan);

            bool scrittureabilitate = t.abilitaScrittureUT(rMan);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");

            //CONTROLLO NUMERO IMPEGNI DI BUDGET    ok
            int countNepexp = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2020)).Length;
            Assert.AreEqual(2, countNepexp, "E' presente un impegno di budget");

            //CONTROLLO VARIAZIONI AI MOVIMENTI DI BUDGET   ok
            int countNVarepexp = dsEP.Tables["epexpvar"]._Filter(q.eq("yvar", 2020)).Length;
            Assert.AreEqual(4, countNVarepexp, "Sono presenti due var. di budget");// Preimpegno e impegno

            //CONTROLLO IMPEGNO DI BUDGET
            DataRow[] rEpexp1 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("idepexp", idepexp3));
            DataRow[] rEpexpeyear1 = dsEP.Tables["epexpyear"]._Filter(q.eq("ayear", 2020) & q.eq("idepexp", idepexp3));
            DataRow dr1_epexp = rEpexp1[0];
            DataRow dr1_epexpyear = rEpexpeyear1[0];
            Assert.AreEqual(dr1_epexp["description"], "Sostituzione stesso anno", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epexpyear["idacc"], "20000200010002000100060001", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexpyear["idupb"], "00010001", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexp["idaccmotive"], "000100020008", "La causale del mov.budget è corrispondente");
            t.checkImportoInizialeImpBudget(dsEP.Tables["epexp"], dr1_epexp["idepexp"], 2020, 260m);

            DataRow[] rEpexp2 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("idepexp", idepexp4));
            DataRow[] rEpexpeyear2 = dsEP.Tables["epexpyear"]._Filter(q.eq("ayear", 2020) & q.eq("idepexp", idepexp4));
            DataRow dr2_epexp = rEpexp2[0];
            DataRow dr2_epexpyear = rEpexpeyear2[0];
            Assert.AreEqual(dr2_epexp["description"], "Sostituzione stesso anno", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr2_epexpyear["idacc"], "20000200010002000100060001", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epexpyear["idupb"], "00010003", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epexp["idaccmotive"], "000100020008", "La causale del mov.budget è corrispondente");
            t.checkImportoInizialeImpBudget(dsEP.Tables["epexp"], dr2_epexp["idepexp"], 2020, 390m);
            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            var tEntrydetail = dsEP.Tables["entrydetail"];
            var rEntry = dsEP.Tables["entry"].Rows[0];
            var date_doc_colleg = new DateTime(2020, 12, 31);
            var date_contab = new DateTime(2020, 12, 31);
            Assert.AreEqual(rEntry["description"], "Sostituzione stesso anno con righe splittate", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "sa", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");
            //PRIMO DETTAGLIO SCRITTURA
            var descr1 =
                 "Contratto Passivo AMCEN_GEN 20/32 dett. 1- Sostituzione stesso anno";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1 );
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(EntryDetail1["description"], descr1, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idupb"], "00010001", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idreg"], 9759, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idaccmotive"], "000100020008", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idepexp"], idepexp3);
            Assert.AreEqual(EntryDetail1["idrelated"], idrelated1);
            //SECONDO DETTAGLIO SCRITTURA
            var descr2 =
                "Contratto passivo AMCEN_GEN n.32 / 2020 dett. 1";
            q filterEDetail2 = q.eq("description", descr2);
            var EntryDetail2Rows = tEntrydetail._Filter(filterEDetail2);
            var EntryDetail2 = EntryDetail2Rows[0];
            Assert.AreEqual(EntryDetail2["description"], descr2, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idupb"], "00010001", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idreg"], 9759, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idaccmotive"], "000100020008", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idepexp"], idepexp3);
            Assert.AreEqual(EntryDetail2["idrelated"], idrelated1);
            //TERZO DETTAGLIO SCRITTURA
            var descr3 =
                "Contratto Passivo AMCEN_GEN 20/32 dett. 2- Sostituzione stesso anno";
            q filterEDetail3 = q.eq("description", descr3);
            var EntryDetail3Rows = tEntrydetail._Filter(filterEDetail3);
            var EntryDetail3 = EntryDetail3Rows[0];
            Assert.AreEqual(EntryDetail3["description"], descr3, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail3["idupb"], "00010003", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail3["idreg"], 9759, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail3["idaccmotive"], "000100020008", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail3["idepexp"], idepexp4);
            Assert.AreEqual(EntryDetail3["idrelated"], idrelated2);
            //QUARTO DETTAGLIO SCRITTURA
            var descr4 =
                "Contratto passivo AMCEN_GEN n.32 / 2020 dett. 2";
            q filterEDetail4 = q.eq("description", descr4);
            var EntryDetail4Rows = tEntrydetail._Filter(filterEDetail4);
            var EntryDetail4 = EntryDetail4Rows[0];
            Assert.AreEqual(EntryDetail4["description"], descr4, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail4["idupb"], "00010003", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail4["idreg"], 9759, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail4["idaccmotive"], "000100020008", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail4["idepexp"], idepexp4);
            Assert.AreEqual(EntryDetail4["idrelated"], idrelated2);


            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            Assert.AreEqual(1, dsEP.Tables["entry"]._Filter(null).Length, "E' presente una scrittura");
            //CONTROLLO DETTAGLI SCRITTURA ESERCIZIO 2019
            Assert.AreEqual(4, dsEP.Tables["entrydetail"]._Filter(q.eq("nentry", rEntry["nentry"])).Length, "Sono presenti 4 dettagli relativi alla scrittura");
            var avere = (decimal)dsEP.Tables["entrydetail"]._Filter(q.gt("amount", 0) & q.eq("nentry", rEntry["nentry"])).GetSum<decimal>("amount");
            Assert.AreEqual(600m, avere, "Avere corrispondente");
            }

        [TestMethod]
        public void Test2_mandate_2020_SostituzioneAnnoSuccessivo_costo() {
            //l)	Sostituzione anno successivo con causale costo
            var t = new TestHelp(new DateTime(2021, 12, 31), "sample_2", "test_2");
            q filterMan = q.eq("idmankind", "AMCEN_GEN") & q.eq("yman", 2020) & q.eq("nman", 39);
            t.binaryReplaceSet(filterMan, t.getTableSet(TestHelp.mainObject.mandate));
            DataTable tMandate = t.testConn.readTable("mandate", filterMan);

            DataRow rMan = tMandate.Rows[0];
            Assert.AreEqual(1, tMandate.Rows.Count, "Il contratto esiste");

            t.binaryCopyEp(rMan, false);
            DataTable tMandateDetail = t.testConn.readTable("mandatedetail", filterMan);
            int nEstDet = tMandateDetail.Rows.Count;
            Assert.AreEqual(2, nEstDet, "Il contratto ha 2 dettagli");
            DataRow manDet1 = tMandateDetail.Rows[0];
            DataRow manDet2 = tMandateDetail.Rows[1];

            //GENERO GLI ACCERTAMENTI/IMPEGNI CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaImpegniScritture(rMan);
            checkNoRules(regole);

            var dsEP = t.getEpData(t.testConn, rMan);

            bool scrittureabilitate = t.abilitaScrittureUT(rMan);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");

            Assert.AreEqual(0, dsEP.Tables["epexpvar"]._Filter(null).Length / 2, "Non ci sono variazioni ai mov di budget");

             object idepexp1 = manDet1["idepexp"];
            object idepexp2 = manDet2["idepexp"];

            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc = dsEP.Tables["epacc"]._Filter(null).Length;
            Assert.AreEqual(0, countNepacc, "Non ci sono accertamenti di budget");

            //CONTROLLO IMPORTO INIZIALE IMP DI BUDGET ESERCIZIO 2020
            t.checkImportoInizialeImpBudget(dsEP.Tables["epexp"], 2020, 66742, 2020, 1000m);
            //CONTROLLO NUMERO IMPEGNI DI BUDGET
            int countNepexp2021 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2021) & q.eq("flagvariation", "S")).Length;
            Assert.AreEqual(1, countNepexp2021, "E' presente un impegno di budget del 2021 di tipo variazione");
            int countNepexp2020 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2020)).Length;
            Assert.AreEqual(1, countNepexp2020, "E' presente un impegno di budget del 2020");

            //CONTROLLO IMPEGNO DI BUDGET PRESENTE  
            DataRow[] repexp = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2020) & q.eq("idepexp", idepexp1));
            DataRow[] repexpyear = dsEP.Tables["epexpyear"]._Filter(q.eq("ayear", 2021) & q.eq("idepexp", idepexp1));
            DataRow dr1_epexp = repexp[0];
            DataRow dr1_epexpyear = repexpyear[0];
            Assert.AreEqual("Sostituzione anno successivo", dr1_epexp["description"], "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual("21000200010002000100060001", dr1_epexpyear["idacc"], "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual("00010003", dr1_epexpyear["idupb"], "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual("000100020008", dr1_epexp["idaccmotive"], "La causale del mov.budget è corrispondente");
            t.checkImportoInizialeImpBudget(dsEP.Tables["epexp"], idepexp1, 2021, 0m);
            t.checkImportoInizialeImpBudget(dsEP.Tables["epexp"], idepexp1, 2020, 1000m);

            //CONTROLLO SECONDO IMPEGNO DI BUDGET PRESENTE  (tipo variazione)
            DataRow[] repexp2 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2021) & q.eq("idepexp", idepexp2));
            DataRow[] repexpyear2 = dsEP.Tables["epexpyear"]._Filter(q.eq("ayear", 2021) & q.eq("idepexp", idepexp2));
            DataRow dr2_epexp = repexp2[0];
            DataRow dr2_epexpyear = repexpyear2[0];
            Assert.AreEqual("S", dr2_epexp["flagvariation"], "impegno di tipo variazione");
            Assert.AreEqual("Sostituzione anno successivo", dr2_epexp["description"], "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual("21000200010002000100060001", dr2_epexpyear["idacc"], "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual("00010003", dr2_epexpyear["idupb"], "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual("000100020008", dr2_epexp["idaccmotive"], "La causale del mov.budget è corrispondente");
            t.checkImportoInizialeImpBudget(dsEP.Tables["epexp"], idepexp2, 2021, 300m);


            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            var tEntrydetail = dsEP.Tables["entrydetail"];
            var rEntry = dsEP.Tables["entry"].Rows[0];
            var date_doc_colleg = new DateTime(2020, 12, 31);
            var date_contab = (DateTime)manDet1["start"];//new DateTime(2021, 11, 3));//data inizio nuovo dettaglio
            Assert.AreEqual("Sostituzione anno successivo causale costo", rEntry["description"], "La descrizione della scrittura è corrispondente");
            Assert.AreEqual("sa", rEntry["doc"], "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(date_doc_colleg, rEntry["docdate"], "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(date_contab, rEntry["adate"], "La data contabile della scrittura è corrispondente");

            //PRIMO DETTAGLIO SCRITTURA, accertamento di budget 2020 e relativo idrelated
            var descr1 = "C.P. AMCEN_GEN 20/392- Sostituzione anno successivo";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1);
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(descr1, EntryDetail1["description"], "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("21000200010002000100060001", EntryDetail1["idacc"], "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("00010003", EntryDetail1["idupb"], "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(9759, EntryDetail1["idreg"], "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("000100020008", EntryDetail1["idaccmotive"], "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idepexp"], idepexp2);
            Assert.AreEqual(EntryDetail1["idrelated"], dr2_epexp["idrelated"]);


            //SECONDO DETTAGLIO SCRITTURA
            var descr2 = "Contratto passivo AMCEN_GEN n.39 / 2020 n°2";
            q filterEDetail2 = q.eq("description", descr2);
            var EntryDetail2Rows = tEntrydetail._Filter(filterEDetail2);
            var EntryDetail2 = EntryDetail2Rows[0];
            Assert.AreEqual(descr2, EntryDetail2["description"], "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("21000300040002000100010001", EntryDetail2["idacc"], "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("00010003", EntryDetail2["idupb"], "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(9759, EntryDetail2["idreg"], "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("000100020008", EntryDetail2["idaccmotive"], "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idepexp"], dr1_epexp["idepexp"]);
            Assert.AreEqual(EntryDetail2["idrelated"], dr1_epexp["idrelated"]);
            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            Assert.AreEqual(1, dsEP.Tables["entry"]._Filter(q.eq("yentry", 2021)).Length, "E' presente una scrittura");
            //CONTROLLO DETTAGLI SCRITTURA ESERCIZIO 2021
            Assert.AreEqual(2, dsEP.Tables["entrydetail"]._Filter(q.eq("nentry", rEntry["nentry"])).Length, "Sono presenti sette dettagli relativi alla scrittura");
            var avere = (decimal)dsEP.Tables["entrydetail"]._Filter(q.gt("amount", 0) & q.eq("nentry", rEntry["nentry"])).GetSum<decimal>("amount");
            Assert.AreEqual(300.00m, avere, "Avere corrispondente");
            }

        [TestMethod]
        public void Test2_mandate_2020_Sostituzione2021_NoCollFattura_Ricavo() {
            //m)	Sostituzione anno successivo con causale ricavo
            var t = new TestHelp(new DateTime(2020, 12, 31), "sample_2", "test_2");
            q filterMan = q.eq("idmankind", "AMCEN_GEN") & q.eq("yman", 2020) & q.eq("nman", 40);
            t.binaryReplaceSet(filterMan, t.getTableSet(TestHelp.mainObject.mandate));
            DataTable tMandate = t.testConn.readTable("mandate", filterMan);

            DataRow rMan = tMandate.Rows[0];
            Assert.AreEqual(1, tMandate.Rows.Count, "Il contratto esiste");

            t.binaryCopyEp(rMan, false);
            //DataTable tMandateDetail = t.testConn.readTable("mandatedetail", filterMan);
            //int nEstDet = tMandateDetail.Rows.Count;
            //Assert.AreEqual(1, nEstDet, "Il contratto ha 1 dettaglio");
            //DataRow mnDet1 = tMandateDetail.Rows[0];
            DataTable tMandateDetail = t.testConn.readTable("mandatedetail", filterMan & q.isNotNull("stop"), "*", " rownum ", null);
            int nManDet = tMandateDetail.Rows.Count;
            Assert.AreEqual(1, nManDet, "Il contratto ha 1 dettaglio annullati");

            DataRow manDet1 = tMandateDetail.Rows[0];
            object idepexp1 = manDet1["idepexp"];

            DataTable tMandateDetailAttivo = t.testConn.readTable("mandatedetail", filterMan & q.isNull("stop"), "*", " rownum ", null);
            int nManDetAtt = tMandateDetailAttivo.Rows.Count;
            Assert.AreEqual(1, nManDetAtt, "Il contratto ha 1 dettaglio attivi");
            DataRow manDetAtt = tMandateDetailAttivo.Rows[0];
            object idepexpAtt = manDetAtt["idepexp"];
            string idrelated1 = BudgetFunction.GetIdForDocument(manDet1);
            string idrelated2 = BudgetFunction.GetIdForDocument(manDetAtt);

            //GENERO GLI ACCERTAMENTI/IMPEGNI CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaImpegniScritture(rMan);
            checkNoRules(regole);

            var dsEP = t.getEpData(t.testConn, rMan);
            bool scrittureabilitate = t.abilitaScrittureUT(rMan);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");


            Assert.AreEqual(0, dsEP.Tables["epaccvar"]._Filter(null).Length, "Non ci sono variazioni ai mov di budget");

            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2021 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2021)).Length;
            Assert.AreEqual(1, countNepacc2021, "E' presente un accertamento di budget del 2021");
            int countNepacc2020 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2020)).Length;
            Assert.AreEqual(0, countNepacc2020, "Non ci sono accertamento di budget del 2020");

            //CONTROLLO PRIMO ACCERTAMENTo DI BUDGET
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2021));
            DataRow dr1_epacc = rEpacc[0];

            DataRow[] rEpacceyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2021) & q.eq("idepacc", dr1_epacc["idepacc"]));

            DataRow dr1_epaccyear = rEpacceyear[0];

            Assert.AreEqual(dr1_epacc["description"], "Sostituzione anno successivo", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epaccyear["amount"], 200.00M, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idacc"], "21000400040003000100010001", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idupb"], "00010003", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["idaccmotive"], "000800110003", "La causale del mov.budget è corrispondente");

            //CONTROLLO NUMERO IMPEGNI DI BUDGET
            int countNeexp2021 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2021)).Length;
            Assert.AreEqual(0, countNeexp2021, "Non ci sono impegni di budget del 2021");
            int countNeexp2020 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2020)).Length;
            Assert.AreEqual(1, countNeexp2020, "E' presente un impegno di budget del 2020");

            //CONTROLLO IMPEGNO DI BUDGET ASSOCIATO AL CONTRATTO PASSIVO
            DataRow[] rEexp = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2020) & q.eq("idepexp", idepexpAtt));
            DataRow[] rEexpyear = dsEP.Tables["epexpyear"]._Filter(q.eq("ayear", 2021) & q.eq("idepexp", idepexpAtt));
            DataRow dr1_epexp = rEexp[0];
            DataRow dr1_epexpyear = rEexpyear[0];
            Assert.AreEqual("Sostituzione anno successivo", dr1_epexp["description"], "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(0.00m, dr1_epexpyear["amount"], "L'importo del mov.budget è corrispondente");
            Assert.AreEqual("21000200010002000100060001", dr1_epexpyear["idacc"], "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual("00010003", dr1_epexpyear["idupb"], "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual("000100020008", dr1_epexp["idaccmotive"], "La causale del mov.budget è corrispondente");

            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            var tEntrydetail = dsEP.Tables["entrydetail"];
            var rEntry = dsEP.Tables["entry"].Rows[0];
            var date_doc_colleg = new DateTime(2020, 12, 31);
            var date_contab = (DateTime)manDetAtt["start"];
            Assert.AreEqual("Sostituzione anno successivo causale ricavo", rEntry["description"], "La descrizione della scrittura è corrispondente");
            Assert.AreEqual("sa", rEntry["doc"], "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(date_doc_colleg, rEntry["docdate"], "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(date_contab, rEntry["adate"], "La data contabile della scrittura è corrispondente");
            //PRIMO DETTAGLIO SCRITTURA
            var descr1 =
                 "C.P. AMCEN_GEN 20/402- Sostituzione anno successivo";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1);
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(descr1, EntryDetail1["description"], "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("21000400040003000100010001", EntryDetail1["idacc"], "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("00010003", EntryDetail1["idupb"], "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(9759, EntryDetail1["idreg"], "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("000800110003", EntryDetail1["idaccmotive"], "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idepacc"], dr1_epacc["idepacc"]);
            Assert.AreEqual(EntryDetail1["idrelated"], idrelated1);
            //SECONDO DETTAGLIO SCRITTURA
            var descr2 =
                "Contratto passivo AMCEN_GEN n.40 / 2020 n°2";
            q filterEDetail2 = q.eq("description", descr2);
            var EntryDetail2Rows = tEntrydetail._Filter(filterEDetail2);
            var EntryDetail2 = EntryDetail2Rows[0];
            Assert.AreEqual(descr2, EntryDetail2["description"], "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("21000300040002000100010001", EntryDetail2["idacc"], "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("00010003", EntryDetail2["idupb"], "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(9759, EntryDetail2["idreg"], "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("000800110003", EntryDetail2["idaccmotive"], "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idepexp"], idepexpAtt);
            Assert.AreEqual(EntryDetail2["idrelated"], idrelated2);
            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            Assert.AreEqual(1, dsEP.Tables["entry"]._Filter(q.eq("yentry", 2021)).Length, "E' presente una scrittura");
            //CONTROLLO DETTAGLI SCRITTURA ESERCIZIO 2021
            Assert.AreEqual(2, dsEP.Tables["entrydetail"]._Filter(q.eq("nentry", rEntry["nentry"])).Length, "Sono presenti sette dettagli relativi alla scrittura");
            var avere = (decimal)dsEP.Tables["entrydetail"]._Filter(q.gt("amount", 0) & q.eq("nentry", rEntry["nentry"])).GetSum<decimal>("amount");
            Assert.AreEqual(200.00m, avere, "Avere corrispondente");
            }
        [TestMethod]
        public void Test2_mandate_2020_Annullo2021_CPfattdaricevere_Costo() {
            //n)	Annullo anno successivo Fatture da ricevere con causale COSTO
            var t = new TestHelp(new DateTime(2021, 12, 31), "sample_2", "test_2");
            q filterMan = q.eq("idmankind", "AUA_CF_I") & q.eq("yman", 2020) & q.eq("nman", 2);
            t.binaryReplaceSet(filterMan, t.getTableSet(TestHelp.mainObject.mandate));
            DataTable tMandate = t.testConn.readTable("mandate", filterMan);
            DataRow rMan = tMandate.Rows[0];
            Assert.AreEqual(1, tMandate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rMan, false);
            DataTable tMandateDetail = t.testConn.readTable("mandatedetail", filterMan & q.isNotNull("stop"));
            int nManDet = tMandateDetail.Rows.Count;
            Assert.AreEqual(2, nManDet, "Il contratto ha dettagli annullati");

            //VERIFICO CHE LA CAUSALE DI ANNULLO  (Costo - Cancelleria toner e inchiostri) 
            DataRow rMandateDetail = tMandateDetail.Rows[0];
            string attualCodeAnn = rMandateDetail["idaccmotiveannulment"] == DBNull.Value ? "" : (string)rMandateDetail["idaccmotiveannulment"];
            Assert.AreEqual("000100020008", attualCodeAnn, "Il codice della causale d'annullo è corrispondente");

            //Verifico la causale di costo "Cancelleria toner e inchiostri"
            string attualCodeCosto = rMandateDetail["idaccmotive"] == DBNull.Value ? "" : (string)rMandateDetail["idaccmotive"];
            Assert.AreEqual("000100020008", attualCodeCosto, "Il codice della causale di costo è corrispondente");

            bool scrittureabilitate = t.abilitaScrittureUT(rMan);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");

            //GENERO LE SCRITTURE E CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaImpegniScritture(rMan);
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rMan);

            //CONTROLLO VARIAZIONI AI MOVIMENTI DI BUDGET   ok
            int countNVarepexp2021 = dsEP.Tables["epexpvar"]._Filter(q.eq("yvar", 2021)).Length;
            Assert.AreEqual(0, countNVarepexp2021, "Non vi sono var. di budget");// Preimpegno e impegno

            //CONTROLLO NUMERO IMPEGNI DI BUDGET
            int countNepexp2020 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2020)).Length;
            Assert.AreEqual(1, countNepexp2020, "E' presente un impegno di budget del 2020");
            int countNepexp2021 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2021) & q.eq("flagvariation", "S")).Length;
            Assert.AreEqual(1, countNepexp2021, "E' presente un impegno di budget del 2021");
            
            //CONTROLLO IMPEGNO DI BUDGET
            DataRow[] rEpexp20 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2020));
            DataRow[] rEpexpeyear20 = dsEP.Tables["epexpyear"]._Filter(q.eq("ayear", 2021));
            DataRow dr20_epexp = rEpexp20[0];
            DataRow dr20_epexpyear = rEpexpeyear20[0];
            Assert.AreEqual(dr20_epexp["description"], "Test annullo anno successivo Fatture da ricevere con causale COSTO", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr20_epexpyear["idacc"], "21000200010002000100060001", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr20_epexpyear["idupb"], "00010003", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr20_epexp["idaccmotive"], "000100020008", "La causale del mov.budget è corrispondente");
            t.checkImportoInizialeImpBudget(dsEP.Tables["epexp"], dr20_epexp["idepexp"], 2021, 0);//ora vale 0

            DataRow[] rEpexp21 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2021) & q.eq("flagvariation", "S"));
            DataRow[] rEpexpeyear21 = dsEP.Tables["epexpyear"]._Filter(q.eq("ayear", 2021));
            DataRow dr21_epexp = rEpexp21[0];
            DataRow dr21_epexpyear = rEpexpeyear21[0];
            Assert.AreEqual(dr21_epexp["description"], "Test annullo anno successivo Fatture da ricevere con causale COSTO", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr21_epexpyear["idacc"], "21000200010002000100060001", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr21_epexpyear["idupb"], "00010003", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr21_epexp["idaccmotive"], "000100020008", "La causale del mov.budget è corrispondente");
            t.checkImportoInizialeImpBudget(dsEP.Tables["epexp"], dr21_epexp["idepexp"], 2021, 4270m);

            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET   ok 
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2021)).Length;
            Assert.AreEqual(0, countNepacc2019, "Non ci sono accertamenti di budget del 2021");

            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            var tEntrydetail = dsEP.Tables["entrydetail"];
            var rEntry = dsEP.Tables["entry"].Rows[0];
            var date_doc_colleg = new DateTime(2020, 12, 31);
            var date_contab = new DateTime(2021, 02, 11);
            Assert.AreEqual(rEntry["description"], "Test annullo anno successivo Fatture da ricevere con causale COSTO", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "C.P. AUA_CF_I 20/2", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");
            //1 DETTAGLIO SCRITTURA
            var descr1 =
                 "C.P. AUA_CF_I 20/22- Test annullo anno successivo Fatture da ricevere con causale COSTO";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1);
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(EntryDetail1["description"], descr1, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idacc"], "21000200010002000100060001", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idupb"], "00010003", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idreg"], 9759, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idaccmotive"], "000100020008", "La causale del dettaglio della scrittura è corrispondente");
            //2 DETTAGLIO SCRITTURA
            var descr2 =
                "Contratto passivo AUA_CF_I n.2 / 2020 n°2";
            q filterEDetail2 = q.eq("description", descr2);
            var EntryDetail2Rows = tEntrydetail._Filter(filterEDetail2);
            var EntryDetail2 = EntryDetail2Rows[0];
            Assert.AreEqual(EntryDetail2["description"], descr2, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idacc"], "21000300040002000100040001", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idupb"], "00010003", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idreg"], 9759, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idaccmotive"], "000100020008", "La causale del dettaglio della scrittura è corrispondente");

            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            Assert.AreEqual(2, dsEP.Tables["entry"]._Filter(null).Length, "Presente due scritture");

            Assert.AreEqual(2, dsEP.Tables["entrydetail"]._Filter(q.eq("nentry", rEntry["nentry"])).Length, "Sono presenti due dettagli relativi alla scrittura");
            var avere = (decimal)dsEP.Tables["entrydetail"]._Filter(q.gt("amount", 0) & q.eq("nentry", rEntry["nentry"])).GetSum<decimal>("amount");
            Assert.AreEqual(4270.00m, avere, "Avere corrispondente");

            //CONTROLLO CORRISPONDENZA TRA SCRITTURA E MOVIMENTO DI BUDGET
            Assert.AreEqual(EntryDetail1["idepexp"], dr21_epexp["idepexp"]);
            Assert.AreEqual(EntryDetail1["idrelated"], dr21_epexp["idrelated"]);

            Assert.AreEqual(EntryDetail2["idepexp"], dr20_epexp["idepexp"]);
            Assert.AreEqual(EntryDetail2["idrelated"], dr20_epexp["idrelated"]);

            }
        [TestMethod]
        public void Test2_mandate_2020_Annullo2021_CPfattdaricevere_Ricavo() { 
            //o)	Annullo anno successivo Fatture da ricevere con causale RICAVO
            var t = new TestHelp(new DateTime(2021, 12, 31), "sample_2", "test_2");
            q filterMan = q.eq("idmankind", "AUA_CF_I") & q.eq("yman", 2020) & q.eq("nman", 3);
            t.binaryReplaceSet(filterMan, t.getTableSet(TestHelp.mainObject.mandate));
            DataTable tMandate = t.testConn.readTable("mandate", filterMan);
            DataRow rMan = tMandate.Rows[0];
            Assert.AreEqual(1, tMandate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rMan, false);
            DataTable tMandateDetail = t.testConn.readTable("mandatedetail", filterMan & q.isNotNull("stop"));
            int nManDet = tMandateDetail.Rows.Count;
            Assert.AreEqual(2, nManDet, "Il contratto ha dettagli annullati");

            //VERIFICO CHE LA CAUSALE DI ANNULLO  (Costo - Cancelleria toner e inchiostri) 
            DataRow rMandateDetail = tMandateDetail.Rows[0];
            string attualCodeAnn = rMandateDetail["idaccmotiveannulment"] == DBNull.Value ? "" : (string)rMandateDetail["idaccmotiveannulment"];
            Assert.AreEqual("000100020008", attualCodeAnn, "Il codice della causale d'annullo è corrispondente");

            //Verifico la causale di costo "Cancelleria toner e inchiostri"
            string attualCodeCosto = rMandateDetail["idaccmotive"] == DBNull.Value ? "" : (string)rMandateDetail["idaccmotive"];
            Assert.AreEqual("000100020008", attualCodeCosto, "Il codice della causale di costo è corrispondente");

            bool scrittureabilitate = t.abilitaScrittureUT(rMan);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");

            //GENERO LE SCRITTURE E CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaImpegniScritture(rMan);
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rMan);

            //CONTROLLO VARIAZIONI AI MOVIMENTI DI BUDGET   ok
            int countNVarepexp2021 = dsEP.Tables["epexpvar"]._Filter(q.eq("yvar", 2021)).Length;
            Assert.AreEqual(2, countNVarepexp2021, "Non vi sono var. di budget");// Preimpegno e impegno

            //CONTROLLO NUMERO IMPEGNI DI BUDGET
            int countNepexp2020 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2020)).Length;
            Assert.AreEqual(1, countNepexp2020, "E' presente un impegno di budget del 2020");
            int countNepexp2021 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2021) & q.eq("flagvariation", "S")).Length;
            Assert.AreEqual(1, countNepexp2021, "E' presente un impegno di budget del 2021");

            //CONTROLLO IMPEGNO DI BUDGET
            DataRow[] rEpexp20 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2020));
            DataRow[] rEpexpeyear20 = dsEP.Tables["epexpyear"]._Filter(q.eq("ayear", 2021));
            DataRow dr20_epexp = rEpexp20[0];
            DataRow dr20_epexpyear = rEpexpeyear20[0];
            Assert.AreEqual(dr20_epexp["description"], "Test annullo anno successivo Fatture da ricevere con causale RICAVO", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr20_epexpyear["idacc"], "21000200010002000100060001", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr20_epexpyear["idupb"], "00010003", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr20_epexp["idaccmotive"], "000100020008", "La causale del mov.budget è corrispondente");
            t.checkImportoInizialeImpBudget(dsEP.Tables["epexp"], dr20_epexp["idepexp"], 2021, 0);

            DataRow[] rEpexp21 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2021) & q.eq("flagvariation", "S"));
            DataRow[] rEpexpeyear21 = dsEP.Tables["epexpyear"]._Filter(q.eq("ayear", 2021));
            DataRow dr21_epexp = rEpexp21[0];
            DataRow dr21_epexpyear = rEpexpeyear21[0];
            Assert.AreEqual(dr21_epexp["description"], "Test annullo anno successivo Fatture da ricevere con causale RICAVO", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr21_epexpyear["idacc"], "21000200010002000100060001", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr21_epexpyear["idupb"], "00010003", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr21_epexp["idaccmotive"], "000100020008", "La causale del mov.budget è corrispondente");
            t.checkImportoInizialeImpBudget(dsEP.Tables["epexp"], dr21_epexp["idepexp"], 2021, 4270m);

            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET   ok 
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2021)).Length;
            Assert.AreEqual(1, countNepacc2019, "Non ci sono accertamenti di budget del 2021");


            //CONTROLLO ACCERTAMENTO DI BUDGET 
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2021));
            DataRow dr21_epacc = rEpacc[0];

            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            var tEntrydetail = dsEP.Tables["entrydetail"];
            var rEntry = dsEP.Tables["entry"].Rows[0];
            var date_doc_colleg = new DateTime(2020, 12, 31);
            var date_contab = new DateTime(2021, 02, 11);
            Assert.AreEqual(rEntry["description"], "Test annullo anno successivo Fatture da ricevere con causale RICAVO", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "C.P. AUA_CF_I 20/3", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");
             //1 DETTAGLIO SCRITTURA
            var descr1 = "C.P. AUA_CF_I 20/32- Test annullo anno successivo Fatture da ricevere con causale RICAVO";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1);
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(EntryDetail1["description"], descr1, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idacc"], "21000400040003000100010001", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idupb"], "00010003", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idreg"], 9759, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idaccmotive"], "000800110003", "La causale del dettaglio della scrittura è corrispondente");
            //2 DETTAGLIO SCRITTURA
             var descr2 = "Contratto passivo AUA_CF_I n.3 / 2020 n°2";
            q filterEDetail2 = q.eq("description", descr2);
            var EntryDetail2Rows = tEntrydetail._Filter(filterEDetail2);
            var EntryDetail2 = EntryDetail2Rows[0];
            Assert.AreEqual(EntryDetail2["description"], descr2, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idacc"], "21000300040002000100040001", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idupb"], "00010003", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idreg"], 9759, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idaccmotive"], "000800110003", "La causale del dettaglio della scrittura è corrispondente");

            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            Assert.AreEqual(2, dsEP.Tables["entry"]._Filter(null).Length, "Presente due scritture");

            Assert.AreEqual(2, dsEP.Tables["entrydetail"]._Filter(q.eq("nentry", rEntry["nentry"])).Length, "Sono presenti due dettagli relativi alla scrittura");
            var avere = (decimal)dsEP.Tables["entrydetail"]._Filter(q.gt("amount", 0) & q.eq("nentry", rEntry["nentry"])).GetSum<decimal>("amount");
            Assert.AreEqual(4270.00m, avere, "Avere corrispondente");

            //CONTROLLO CORRISPONDENZA TRA SCRITTURA E MOVIMENTO DI BUDGET
            Assert.AreEqual(EntryDetail1["idepacc"], dr21_epacc["idepacc"]);
            Assert.AreEqual(EntryDetail1["idrelated"], dr21_epexp["idrelated"]);

            Assert.AreEqual(EntryDetail2["idepexp"], dr20_epexp["idepexp"]);
            Assert.AreEqual(EntryDetail2["idrelated"], dr20_epexp["idrelated"]);
        }
        [TestMethod]
        public void Test2_mandate_2021_SostituzioneAnnoSuccessivo_CPfattdaricevere_costo(){ 
            //p)	Sostituzione anno successivo Fatture da ricevere con causale COSTO
            var t = new TestHelp(new DateTime(2021, 12, 31), "sample_2", "test_2");
            q filterMan = q.eq("idmankind", "AUA_CF_I") & q.eq("yman", 2020) & q.eq("nman", 4);
            t.binaryReplaceSet(filterMan, t.getTableSet(TestHelp.mainObject.mandate));
            DataTable tMandate = t.testConn.readTable("mandate", filterMan);
            DataRow rMan = tMandate.Rows[0];
            Assert.AreEqual(1, tMandate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rMan, false);
            DataTable tMandateDetail = t.testConn.readTable("mandatedetail", filterMan);
            int nEstDet = tMandateDetail.Rows.Count;
            Assert.AreEqual(2, nEstDet, "Il contratto ha 2 dettagli");
            DataRow manDet1 = tMandateDetail.Rows[1];
            DataRow manDet2 = tMandateDetail.Rows[0];
            //GENERO GLI ACCERTAMENTI/IMPEGNI CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 

            ProcedureMessageCollection regole = t.generaImpegniScritture(rMan);
            checkNoRules(regole);
            var dsEP = t.getEpData(t.testConn, rMan);
          
            bool scrittureabilitate = t.abilitaScrittureUT(rMan);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");
            
            Assert.AreEqual(0, dsEP.Tables["epexpvar"]._Filter(null).Length / 2, "Non ci sono variazioni ai mov di budget");
            object idepexp1 = manDet1["idepexp"];
            object idepexp2 = manDet2["idepexp"];

            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc = dsEP.Tables["epacc"]._Filter(null).Length;
            Assert.AreEqual(0, countNepacc, "Non ci sono accertamenti di budget");
            
            
            //CONTROLLO NUMERO IMPEGNI DI BUDGET
            int countNepexp2021 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2021) & q.eq("flagvariation", "S")).Length;
            Assert.AreEqual(1, countNepexp2021, "E' presente un impegno di budget del 2021 di tipo variazione");
            int countNepexp2020 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2020)).Length;
            Assert.AreEqual(1, countNepexp2020, "E' presente un impegno di budget del 2020");

            //CONTROLLO IMPEGNO DI BUDGET PRESENTE  (tipo variazione)
            DataRow[] repexp = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2021) & q.eq("idepexp", idepexp1));
            DataRow[] repexpyear = dsEP.Tables["epexpyear"]._Filter(q.eq("ayear", 2021) & q.eq("idepexp", idepexp1));
            DataRow dr1_epexp = repexp[0];
            DataRow dr1_epexpyear = repexpyear[0];
            Assert.AreEqual("S", dr1_epexp["flagvariation"], "impegno di tipo variazione");
            Assert.AreEqual("Test sostituzione anno successivo Fatture da ricevere con causale COSTO", dr1_epexp["description"], "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual("21000200010002000100060001", dr1_epexpyear["idacc"], "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual("00010003", dr1_epexpyear["idupb"], "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual("000100020008", dr1_epexp["idaccmotive"], "La causale del mov.budget è corrispondente");
            t.checkImportoInizialeImpBudget(dsEP.Tables["epexp"], idepexp1, 2021, 1220m);

            //CONTROLLO SECONDO IMPEGNO DI BUDGET PRESENTE 
            DataRow[] repexp2 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2020) & q.eq("idepexp", idepexp2));
            DataRow[] repexpyear2 = dsEP.Tables["epexpyear"]._Filter(q.eq("ayear", 2021) & q.eq("idepexp", idepexp2));
            DataRow dr2_epexp = repexp2[0];
            DataRow dr2_epexpyear = repexpyear2[0];         
            Assert.AreEqual("Test sostituzione anno successivo Fatture da ricevere con causale COSTO", dr2_epexp["description"], "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual("21000200010002000100060001", dr2_epexpyear["idacc"], "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual("00010003", dr2_epexpyear["idupb"], "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual("000100020008", dr2_epexp["idaccmotive"], "La causale del mov.budget è corrispondente");
            t.checkImportoInizialeImpBudget(dsEP.Tables["epexp"], idepexp2, 2021, 0m);
            t.checkImportoInizialeImpBudget(dsEP.Tables["epexp"], idepexp2, 2020, 4270m);

            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            var tEntrydetail = dsEP.Tables["entrydetail"];
            var rEntry = dsEP.Tables["entry"].Rows[0];
            Assert.AreEqual("Test sostituzione anno successivo Fatture da ricevere con causale COSTO", rEntry["description"], "La descrizione della scrittura è corrispondente");
            var date_doc_colleg = new DateTime(2020, 12, 31);
            var date_contab = new DateTime(2021, 02, 09);//(DateTime)manDet1["start"];//new DateTime(2021, 11, 3));//data inizio nuovo dettaglio
            Assert.AreEqual("Test sostituzione anno successivo Fatture da ricevere con causale COSTO", rEntry["description"], "La descrizione della scrittura è corrispondente");
            Assert.AreEqual("C.P. AUA_CF_I 20/4", rEntry["doc"], "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(date_doc_colleg, rEntry["docdate"], "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(date_contab, rEntry["adate"], "La data contabile della scrittura è corrispondente");

            //PRIMO DETTAGLIO SCRITTURA
            var descr1 = "C.P. AUA_CF_I 20/42- Test sostituzione anno successivo Fatture da ricevere con causale COSTO";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1);
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(descr1, EntryDetail1["description"], "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("21000200010002000100060001", EntryDetail1["idacc"], "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("00010003", EntryDetail1["idupb"], "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(9759, EntryDetail1["idreg"], "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("000100020008", EntryDetail1["idaccmotive"], "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idepexp"], dr1_epexp["idepexp"]);
            Assert.AreEqual(EntryDetail1["idrelated"], dr1_epexp["idrelated"]);

            //SECONDO DETTAGLIO SCRITTURA, accertamento di budget 2020 e relativo idrelated
            var descr2 = "Contratto passivo AUA_CF_I n.4 / 2020 n°2";
            q filterEDetail2 = q.eq("description", descr2);
            var EntryDetail2Rows = tEntrydetail._Filter(filterEDetail2);
            var EntryDetail2 = EntryDetail2Rows[0];
            Assert.AreEqual(descr2, EntryDetail2["description"], "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("21000300040002000100040001", EntryDetail2["idacc"], "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("00010003", EntryDetail2["idupb"], "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(9759, EntryDetail2["idreg"], "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("000100020008", EntryDetail2["idaccmotive"], "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idepexp"], dr2_epexp["idepexp"]);
            Assert.AreEqual(EntryDetail2["idrelated"], dr2_epexp["idrelated"]);
            
            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            Assert.AreEqual(1, dsEP.Tables["entry"]._Filter(q.eq("yentry", 2021)).Length, "E' presente una scrittura");
            
            //CONTROLLO DETTAGLI SCRITTURA ESERCIZIO 2021
            Assert.AreEqual(2, dsEP.Tables["entrydetail"]._Filter(q.eq("nentry", rEntry["nentry"])).Length, "Sono presenti due dettagli relativi alla scrittura");
            var avere = (decimal)dsEP.Tables["entrydetail"]._Filter(q.gt("amount", 0) & q.eq("nentry", rEntry["nentry"])).GetSum<decimal>("amount");
            Assert.AreEqual(1220m, avere, "Avere corrispondente");
        }
        [TestMethod]
        public void Test2_mandate_2021_SostituzioneAnnoSuccessivo_CPfattdaricevere_ricavo(){ 
            //q)    Sostituzione anno successivo Fatture da ricevere con causale RICAVO
            var t = new TestHelp(new DateTime(2021, 12, 31), "sample_2", "test_2");
            q filterMan = q.eq("idmankind", "AUA_CF_I") & q.eq("yman", 2020) & q.eq("nman", 5);
            t.binaryReplaceSet(filterMan, t.getTableSet(TestHelp.mainObject.mandate));
            DataTable tMandate = t.testConn.readTable("mandate", filterMan);
            DataRow rMan = tMandate.Rows[0];
            Assert.AreEqual(1, tMandate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rMan, false);
            DataTable tMandateDetail = t.testConn.readTable("mandatedetail", filterMan);
            int nEstDet = tMandateDetail.Rows.Count;
            Assert.AreEqual(2, nEstDet, "Il contratto ha 2 dettagli");
            DataRow manDet1 = tMandateDetail.Rows[0]; //968548 impegno
            DataRow manDet2 = tMandateDetail.Rows[1]; //180484 accertamento
            
            //GENERO GLI ACCERTAMENTI/IMPEGNI CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaImpegniScritture(rMan);
            checkNoRules(regole);
            var dsEP = t.getEpData(t.testConn, rMan);
            bool scrittureabilitate = t.abilitaScrittureUT(rMan);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");
            Assert.AreEqual(0, dsEP.Tables["epexpvar"]._Filter(null).Length / 2, "Non ci sono variazioni ai mov di budget");
            object idepexp1 = manDet1["idepexp"];//968548 impegno
            object idepacc1 = manDet2["idepacc"];//180484 accertamento
            
            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2021 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2021)).Length;
            Assert.AreEqual(1, countNepacc2021, "E' presente un accertamento di budget del 2021");

            //CONTROLLO NUMERO IMPEGNI DI BUDGET
            int countNepexp2020 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2020)).Length;
            Assert.AreEqual(1, countNepexp2020, "E' presente un impegno di budget del 2020");

            //CONTROLLO IMPORTO INIZIALE IMPEGNO DI BUDGET ESERCIZIO 2020
            t.checkImportoInizialeImpBudget(dsEP.Tables["epexp"], 2020, 66747, 2020, 4270m);

            //CONTROLLO IMPORTO INIZIALE ACCERTAMENTO DI BUDGET ESERCIZIO 2021
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2021, 20, 2021, 610m);

            //CONTROLLO IMPEGNO DI BUDGET PRESENTE
            DataRow[] repexp = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2020) & q.eq("idepexp", idepexp1));
            DataRow[] repexpyear = dsEP.Tables["epexpyear"]._Filter(q.eq("ayear", 2021) & q.eq("idepexp", idepexp1));
            DataRow dr1_epexp = repexp[0];
            DataRow dr1_epexpyear = repexpyear[0];
            Assert.AreEqual("Test sostituzione anno successivo Fatture da ricevere con causale RICAVO", dr1_epexp["description"], "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual("21000200010002000100060001", dr1_epexpyear["idacc"], "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual("00010003", dr1_epexpyear["idupb"], "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual("000100020008", dr1_epexp["idaccmotive"], "La causale del mov.budget è corrispondente");
            t.checkImportoInizialeImpBudget(dsEP.Tables["epexp"], idepexp1, 2021, 0m);
            t.checkImportoInizialeImpBudget(dsEP.Tables["epexp"], idepexp1, 2020, 4270m);

            //CONTROLLO ACCERTAMENTO DI BUDGET PRESENTE
            DataRow[] repacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2021) & q.eq("idepacc", idepacc1));
            DataRow[] repaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2021) & q.eq("idepacc", idepacc1));
            DataRow dr1_epacc = repacc[0];
            DataRow dr1_epaccyear = repaccyear[0];
            Assert.AreEqual("Test sostituzione anno successivo Fatture da ricevere con causale RICAVO", dr1_epacc["description"], "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual("21000400040003000100010001", dr1_epaccyear["idacc"], "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual("00010003", dr1_epaccyear["idupb"], "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual("000800110003", dr1_epacc["idaccmotive"], "La causale del mov.budget è corrispondente");
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], idepacc1, 2021, 610m);

             //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            var tEntrydetail = dsEP.Tables["entrydetail"];
            var rEntry = dsEP.Tables["entry"].Rows[0];
            var date_doc_colleg = new DateTime(2020, 12, 31);
            var date_contab = new DateTime(2021, 02, 09);//(DateTime)manDet1["start"];//new DateTime(2021, 11, 3));//data inizio nuovo dettaglio
            Assert.AreEqual("Test sostituzione anno successivo Fatture da ricevere con causale RICAVO", rEntry["description"], "La descrizione della scrittura è corrispondente");
            Assert.AreEqual("C.P. AUA_CF_I 20/5", rEntry["doc"], "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(date_doc_colleg, rEntry["docdate"], "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(date_contab, rEntry["adate"], "La data contabile della scrittura è corrispondente");

            //PRIMO DETTAGLIO SCRITTURA
            var descr1 = "C.P. AUA_CF_I 20/52- Test sostituzione anno successivo Fatture da ricevere con causale RICAVO";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1);
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(descr1, EntryDetail1["description"], "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("21000400040003000100010001", EntryDetail1["idacc"], "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("00010003", EntryDetail1["idupb"], "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(9759, EntryDetail1["idreg"], "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("000800110003", EntryDetail1["idaccmotive"], "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idepacc"], dr1_epacc["idepacc"]);
            Assert.AreEqual(EntryDetail1["idrelated"], dr1_epacc["idrelated"]);

            //SECONDO DETTAGLIO SCRITTURA
            var descr2 = "Contratto passivo AUA_CF_I n.5 / 2020 n°2";
            q filterEDetail2 = q.eq("description", descr2);
            var EntryDetail2Rows = tEntrydetail._Filter(filterEDetail2);
            var EntryDetail2 = EntryDetail2Rows[0];
            Assert.AreEqual(descr2, EntryDetail2["description"], "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("21000300040002000100040001", EntryDetail2["idacc"], "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("00010003", EntryDetail2["idupb"], "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(9759, EntryDetail2["idreg"], "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("000800110003", EntryDetail2["idaccmotive"], "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idepexp"], dr1_epexp["idepexp"]);
            Assert.AreEqual(EntryDetail2["idrelated"], dr1_epexp["idrelated"]);

            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            Assert.AreEqual(1, dsEP.Tables["entry"]._Filter(q.eq("yentry", 2021)).Length, "E' presente una scrittura");
            
            //CONTROLLO DETTAGLI SCRITTURA ESERCIZIO 2021
            Assert.AreEqual(2, dsEP.Tables["entrydetail"]._Filter(q.eq("nentry", rEntry["nentry"])).Length, "Sono presenti due dettagli relativi alla scrittura");
            var avere = (decimal)dsEP.Tables["entrydetail"]._Filter(q.gt("amount", 0) & q.eq("nentry", rEntry["nentry"])).GetSum<decimal>("amount");
            Assert.AreEqual(610m, avere, "Avere corrispondente");

        }

        [TestMethod]
        public void Test2_mandate_2020_Annullo2021_CPcommerciale_fattdaricevere_Costo() {
            //r)	Annullo anno successivo Fatture da ricevere con causale COSTO
            var t = new TestHelp(new DateTime(2021, 12, 31), "sample_2", "test_2");
            q filterMan = q.eq("idmankind", "AUA_CF_C") & q.eq("yman", 2020) & q.eq("nman", 15);
            t.binaryReplaceSet(filterMan, t.getTableSet(TestHelp.mainObject.mandate));
            DataTable tMandate = t.testConn.readTable("mandate", filterMan);
            DataRow rMan = tMandate.Rows[0];
            Assert.AreEqual(1, tMandate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rMan, false);
            DataTable tMandateDetail = t.testConn.readTable("mandatedetail", filterMan & q.isNotNull("stop"));
            int nManDet = tMandateDetail.Rows.Count;
            Assert.AreEqual(2, nManDet, "Il contratto ha 1 dettaglio annullato");

            //VERIFICO CHE LA CAUSALE DI ANNULLO  (Costo) 
            DataRow rMandateDetail = tMandateDetail.Rows[0];
            string attualCodeAnn = rMandateDetail["idaccmotiveannulment"] == DBNull.Value ? "" : (string)rMandateDetail["idaccmotiveannulment"];
            Assert.AreEqual("000100020008", attualCodeAnn, "Il codice della causale d'annullo è corrispondente");

            //Verifico la causale di costo "Cancelleria toner e inchiostri"
            string attualCodeCosto = rMandateDetail["idaccmotive"] == DBNull.Value ? "" : (string)rMandateDetail["idaccmotive"];
            Assert.AreEqual("000100020008", attualCodeCosto, "Il codice della causale di costo è corrispondente");

            bool scrittureabilitate = t.abilitaScrittureUT(rMan);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");

            //GENERO LE SCRITTURE E CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaImpegniScritture(rMan);
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rMan);

            //CONTROLLO VARIAZIONI AI MOVIMENTI DI BUDGET   ok
            int countNVarepexp2021 = dsEP.Tables["epexpvar"]._Filter(q.eq("yvar", 2021)).Length;
            Assert.AreEqual(0, countNVarepexp2021, "Vi sono 0 var. di budget");// Preimpegno e impegno

            //CONTROLLO NUMERO IMPEGNI DI BUDGET
            int countNepexp2020 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2020)).Length;
            Assert.AreEqual(1, countNepexp2020, "E' presente un impegno di budget del 2020");

            //CONTROLLO NUMERO IMPEGNI DI BUDGET
            int countNepexp2021 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2021)).Length;
            Assert.AreEqual(1, countNepexp2021, "E' presente un impegno di budget del 2021");

            //CONTROLLO IMPEGNO DI BUDGET/2020
            DataRow[] rEpexp20 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2020));
            DataRow[] rEpexpeyear20 = dsEP.Tables["epexpyear"]._Filter(q.eq("ayear", 2021));
            DataRow dr20_epexp = rEpexp20[0];
            DataRow dr20_epexpyear = rEpexpeyear20[0];
            Assert.AreEqual(dr20_epexp["description"], "Test annullo anno successivo Fatture da ricevere con causale COSTO-\r\nPro rata 2020 80%--Pro rata 2021 100%");
            Assert.AreEqual(dr20_epexpyear["idacc"], "21000200010002000100060001", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr20_epexpyear["idupb"], "00010003", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr20_epexp["idaccmotive"], "000100020008", "La causale del mov.budget è corrispondente");
            t.checkImportoInizialeImpBudget(dsEP.Tables["epexp"], dr20_epexp["idepexp"], 2021, 0m);

            //CONTROLLO IMPEGNO DI BUDGET/2021
            DataRow[] rEpexp21 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2021));
            DataRow[] rEpexpyear21 = dsEP.Tables["epexpyear"]._Filter(q.eq("ayear", 2021));
            DataRow dr21_epexp = rEpexp21[0];
            DataRow dr21_epexpyear = rEpexpyear21[0];
            Assert.AreEqual(dr21_epexp["description"], "Test annullo anno successivo Fatture da ricevere con causale COSTO-\r\nPro rata 2020 80%--Pro rata 2021 100%", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr21_epexpyear["idacc"], "21000200010002000100060001", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr21_epexpyear["idupb"], "00010003", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr21_epexp["idaccmotive"], "000100020008", "La causale del mov.budget è corrispondente");
            t.checkImportoInizialeImpBudget(dsEP.Tables["epexp"], dr21_epexp["idepexp"], 2021, 3654m);

            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET   ok 
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2021)).Length;
            Assert.AreEqual(0, countNepacc2019, "Presenti 0 accertamento di budget del 2021");

            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            var tEntrydetail = dsEP.Tables["entrydetail"];
            var rEntry = dsEP.Tables["entry"].Rows[0];
            var date_doc_colleg = new DateTime(2020, 12, 31);
            var date_contab = new DateTime(2021, 02, 17);
           //Assert.AreEqual(rEntry["description"], "Test annullo anno successivo Fatture da ricevere con causale COSTO-\r\nPro rata 2020 80 % --Pro rata 2021 100 % ", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "C.P. AUA_CF_C 20/15", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");
            //1 DETTAGLIO SCRITTURA
            object nentry = rEntry["nentry"];
            var descr1 = "C.P. AUA_CF_C 20/152- Test annullo anno successivo Fatture da ricevere con causale COSTO-%Pro rata 2020 80%Pro rata 2021 100%";
            q filterEDetail1 = q.like("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1);
            var EntryDetail1 = EntryDetail1Rows[0];
           // Assert.AreEqual(EntryDetail1["description"], descr1, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idacc"], "21000200010002000100060001", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idupb"], "00010003", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idreg"], 9759, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idaccmotive"], "000100020008", "La causale del dettaglio della scrittura è corrispondente");
            //2 DETTAGLIO SCRITTURA
            var descr2 = "Contratto passivo AUA_CF_C n.15 / 2020 n°2";
            q filterEDetail2 = q.eq("description", descr2);
            var EntryDetail2Rows = tEntrydetail._Filter(filterEDetail2);
            var EntryDetail2 = EntryDetail2Rows[0];
            Assert.AreEqual(EntryDetail2["description"], descr2, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idacc"], "21000300040002000100040001", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idupb"], "00010003", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idreg"], 9759, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idaccmotive"], "000100020008", "La causale del dettaglio della scrittura è corrispondente");

            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            Assert.AreEqual(2, dsEP.Tables["entry"]._Filter(null).Length, "Presente due scritture");

            Assert.AreEqual(2, dsEP.Tables["entrydetail"]._Filter(q.eq("nentry", rEntry["nentry"])).Length, "Sono presenti due dettagli relativi alla scrittura");
            var avere = (decimal)dsEP.Tables["entrydetail"]._Filter(q.gt("amount", 0) & q.eq("nentry", rEntry["nentry"])).GetSum<decimal>("amount");
            Assert.AreEqual(3654.00m, avere, "Avere corrispondente");

            //CONTROLLO CORRISPONDENZA TRA SCRITTURA E MOVIMENTO DI BUDGET
            Assert.AreEqual(EntryDetail1["idepexp"], dr21_epexp["idepexp"]);
            Assert.AreEqual(EntryDetail1["idrelated"], dr21_epexp["idrelated"]);

            Assert.AreEqual(EntryDetail2["idepexp"], dr20_epexp["idepexp"]);
            Assert.AreEqual(EntryDetail2["idrelated"], dr20_epexp["idrelated"]);
            }


        [TestMethod]
        public void Test2_mandate_2020_Annullo2021_CPcommerciale_fattdaricevere_Ricavo() {
            //s)	Annullo anno successivo Fatture da ricevere con causale RICAVO
            var t = new TestHelp(new DateTime(2021, 12, 31), "sample_2", "test_2");
            q filterMan = q.eq("idmankind", "BIBATS_CF_C") & q.eq("yman", 2020) & q.eq("nman", 1);
            t.binaryReplaceSet(filterMan, t.getTableSet(TestHelp.mainObject.mandate));
            DataTable tMandate = t.testConn.readTable("mandate", filterMan);
            DataRow rMan = tMandate.Rows[0];
            Assert.AreEqual(1, tMandate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rMan, false);
            DataTable tMandateDetail = t.testConn.readTable("mandatedetail", filterMan & q.isNotNull("stop"));
            int nManDet = tMandateDetail.Rows.Count;
            Assert.AreEqual(1, nManDet, "Il contratto ha 1 dettaglio annullato");

            //VERIFICO CHE LA CAUSALE DI ANNULLO  (Riccavo - Sopravvenienze attive) 
            DataRow rMandateDetail = tMandateDetail.Rows[0];
            string attualCodeAnn = rMandateDetail["idaccmotiveannulment"] == DBNull.Value ? "" : (string)rMandateDetail["idaccmotiveannulment"];
            Assert.AreEqual("000800050005", attualCodeAnn, "Il codice della causale d'annullo è corrispondente");

            //Verifico la causale di costo "Cancelleria toner e inchiostri"
            string attualCodeCosto = rMandateDetail["idaccmotive"] == DBNull.Value ? "" : (string)rMandateDetail["idaccmotive"];
            Assert.AreEqual("000200030004", attualCodeCosto, "Il codice della causale di costo è corrispondente");

            //GENERO LE SCRITTURE E CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaImpegniScritture(rMan);
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rMan);

            //CONTROLLO VARIAZIONI AI MOVIMENTI DI BUDGET   ok
            int countNVarepexp2021 = dsEP.Tables["epexpvar"]._Filter(q.eq("yvar", 2021)).Length;
            Assert.AreEqual(0, countNVarepexp2021, "Non ci sono var. di budget");// Preimpegno e impegno

            //CONTROLLO NUMERO IMPEGNI DI BUDGET
            int countNepexp2020 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2020)).Length;
            Assert.AreEqual(1, countNepexp2020, "E' presente un impegno di budget del 2020");

            //CONTROLLO IMPEGNO DI BUDGET
            DataRow[] rEpexp20 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2020));
            DataRow[] rEpexpeyear20 = dsEP.Tables["epexpyear"]._Filter(q.eq("ayear", 2021));
            DataRow dr20_epexp = rEpexp20[0];
            DataRow dr20_epexpyear = rEpexpeyear20[0];
            Assert.AreEqual(dr20_epexp["description"], "REPLICA caso di test CP commerciale 2020, annullato nel 2021 con causale di Ricavo, marcato Fatt. da ricevere");
            Assert.AreEqual(dr20_epexpyear["idacc"], "21000200010004000800040001", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr20_epexpyear["idupb"], "0001000300010012", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr20_epexp["idaccmotive"], "000200030004", "La causale del mov.budget è corrispondente");
            t.checkImportoInizialeImpBudget(dsEP.Tables["epexp"], dr20_epexp["idepexp"], 2021, 0m);

            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET   ok 
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2021)).Length;
            Assert.AreEqual(1, countNepacc2019, "Presente 1 accertamento di budget del 2021");

            DataRow[] rEpacc21 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2021));
            DataRow[] rEpaccyear21 = dsEP.Tables["epexpyear"]._Filter(q.eq("ayear", 2021));
            DataRow dr21_epacc = rEpacc21[0];
            DataRow dr21_epaccyear = rEpaccyear21[0];
            Assert.AreEqual(dr21_epacc["description"], "REPLICA caso di test CP commerciale 2020, annullato nel 2021 con causale di Ricavo, marcato Fatt. da ricevere", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr21_epaccyear["idacc"], "21000200010004000800040001", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr21_epaccyear["idupb"], "0001000300010012", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr21_epacc["idaccmotive"], "000800050005", "La causale del mov.budget è corrispondente");
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], dr21_epacc["idepacc"], 2021, 1566m);


            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            var tEntrydetail = dsEP.Tables["entrydetail"];
            var rEntry = dsEP.Tables["entry"].Rows[0];
            var date_doc_colleg = new DateTime(2020, 12, 31);
            var date_contab = new DateTime(2021, 12, 31);
            Assert.AreEqual(rEntry["description"], "REPLICA caso di test CP commerciale 2020, annullato nel 2021 con causale di Ricavo, marcato Fatt. da ricevere", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "C.P. BIBATS_CF_C 20/1", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");
            //1 DETTAGLIO SCRITTURA
            var descr1 = "C.P. BIBATS_CF_C 20/11- REPLICA caso di test CP commerciale 2020, annullato nel 2021 con causale di Ricavo, marcato Fatt. da ricevere";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1);
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(EntryDetail1["description"], descr1, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idacc"], "21000400010008000100050001", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idupb"], "0001000300010012", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idreg"], 9347, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idaccmotive"], "000800050005", "La causale del dettaglio della scrittura è corrispondente");
            //2 DETTAGLIO SCRITTURA
            var descr2 = "Contratto passivo BIBATS_CF_C n.1 / 2020 n°1";
            q filterEDetail2 = q.eq("description", descr2);
            var EntryDetail2Rows = tEntrydetail._Filter(filterEDetail2);
            var EntryDetail2 = EntryDetail2Rows[0];
            Assert.AreEqual(EntryDetail2["description"], descr2, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idacc"], "21000300040002000100040001", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idupb"], "0001000300010012", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idreg"], 9347, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idaccmotive"], "000800050005", "La causale del dettaglio della scrittura è corrispondente");

            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            Assert.AreEqual(2, dsEP.Tables["entry"]._Filter(null).Length, "Presente due scritture");

            Assert.AreEqual(2, dsEP.Tables["entrydetail"]._Filter(q.eq("nentry", rEntry["nentry"])).Length, "Sono presenti due dettagli relativi alla scrittura");
            var avere = (decimal)dsEP.Tables["entrydetail"]._Filter(q.gt("amount", 0) & q.eq("nentry", rEntry["nentry"])).GetSum<decimal>("amount");
            Assert.AreEqual(1566.00m, avere, "Avere corrispondente");

            //CONTROLLO CORRISPONDENZA TRA SCRITTURA E MOVIMENTO DI BUDGET
            Assert.AreEqual(EntryDetail1["idepacc"], dr21_epacc["idepacc"]);
            Assert.AreEqual(EntryDetail1["idrelated"], dr21_epacc["idrelated"]);

            Assert.AreEqual(EntryDetail2["idepexp"], dr20_epexp["idepexp"]);
            Assert.AreEqual(EntryDetail2["idrelated"], dr20_epexp["idrelated"]);
            }

        [TestMethod]
        public void Test2_mandate_2020_Pagato_Annullo() {
               //b) Annullo stesso anno CP pagato
            var t = new TestHelp(new DateTime(2020, 12, 31), "sample_2", "test_2");
            q filterMan = q.eq("idmankind", "AMCEN_GEN") & q.eq("yman", 2020) & q.eq("nman", 11);
            t.binaryReplaceSet(filterMan, t.getTableSet(TestHelp.mainObject.mandate));
            DataTable tMandate = t.testConn.readTable("mandate", filterMan);
            DataRow rMan = tMandate.Rows[0];
            Assert.AreEqual(1, tMandate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rMan, false);
            DataTable tMandateDetail = t.testConn.readTable("mandatedetail", filterMan);
            int nMandDet = tMandateDetail.Rows.Count;
            Assert.AreEqual(1, nMandDet, "Il contratto ha 1 dettaglio");

            //MODIFICO IL DATASET DELL'mandateDETAIL(IL PRIMO ROWNUM 1) PER VERIFICARE CHE SCATTI LA REGOLA QUANDO ANNULLO IL DETTAGLIO
            var mMandate = TestHelp.editDataRow(t.testConn, filterMan, "mandate", "default");
            var ds = mMandate.ds;
            var tMandateDet = ds.Tables["mandatedetail"];
            var rManDet = tMandateDet._Filter(q.eq("rownum", 1))[0];
            rManDet["lt"] = new DateTime(2020, 11, 07, 20, 41, 48, 573); ;
            rManDet["lu"] = "assistenza";
            rManDet["stop"] = new DateTime(2020, 12, 31);

            //SALVO I DATI DEL FORM MODIFICATO
            var res = t.saveFormData(mMandate);
            checkExistRule(res, "MOVIM176");
            }

        [TestMethod]
        public void Test2_mandate_2020_Pagato_Annullo_inannosuccessivo_costo() {
               //e) Annullo CP anno successivo al pagato-casuale di costo
            var t = new TestHelp(new DateTime(2021, 12, 31), "sample_2", "test_2");
            q filterMan = q.eq("idmankind", "AMCEN_GEN") & q.eq("yman", 2020) & q.eq("nman", 20);
            t.binaryReplaceSet(filterMan, t.getTableSet(TestHelp.mainObject.mandate));
            DataTable tMandate = t.testConn.readTable("mandate", filterMan);
            DataRow rMan = tMandate.Rows[0];
            Assert.AreEqual(1, tMandate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rMan, false);
            DataTable tMandateDetail = t.testConn.readTable("mandatedetail", filterMan);
            int nMandDet = tMandateDetail.Rows.Count;
            Assert.AreEqual(1, nMandDet, "Il contratto ha 1 dettaglio");

            //MODIFICO IL DATASET DELL'mandateDETAIL(IL PRIMO ROWNUM 1) PER VERIFICARE CHE SCATTI LA REGOLA QUANDO ANNULLO IL DETTAGLIO
            var mMandate = TestHelp.editDataRow(t.testConn, filterMan, "mandate", "default");
            var ds = mMandate.ds;
            var tMandateDet = ds.Tables["mandatedetail"];
            var rManDet = tMandateDet._Filter(q.eq("rownum", 1))[0];
            rManDet["lt"] = new DateTime(2020, 11, 07, 20, 41, 48, 573); ;
            rManDet["lu"] = "assistenza";
            rManDet["stop"] = new DateTime(2021, 12, 31);
            rManDet["idaccmotive"] = "000100020008";//Causale Costo
            //SALVO I DATI DEL FORM MODIFICATO
            var res = t.saveFormData(mMandate);
            checkExistRule(res, "MOVIM176");
            }

        [TestMethod]
        public void Test2_mandate_2020_Pagato_Annullo_inannosuccessivo_ricavo() {
            //e) Annullo CP anno successivo al pagato-casuale di ricavo
            var t = new TestHelp(new DateTime(2021, 12, 31), "sample_2", "test_2");
            q filterMan = q.eq("idmankind", "AMCEN_GEN") & q.eq("yman", 2020) & q.eq("nman", 20);
            t.binaryReplaceSet(filterMan, t.getTableSet(TestHelp.mainObject.mandate));
            DataTable tMandate = t.testConn.readTable("mandate", filterMan);
            DataRow rMan = tMandate.Rows[0];
            Assert.AreEqual(1, tMandate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rMan, false);
            DataTable tMandateDetail = t.testConn.readTable("mandatedetail", filterMan);
            int nMandDet = tMandateDetail.Rows.Count;
            Assert.AreEqual(1, nMandDet, "Il contratto ha 1 dettaglio");

            //MODIFICO IL DATASET DELL'mandateDETAIL(IL PRIMO ROWNUM 1) PER VERIFICARE CHE SCATTI LA REGOLA QUANDO ANNULLO IL DETTAGLIO
            var mMandate = TestHelp.editDataRow(t.testConn, filterMan, "mandate", "default");
            var ds = mMandate.ds;
            var tMandateDet = ds.Tables["mandatedetail"];
            var rManDet = tMandateDet._Filter(q.eq("rownum", 1))[0];
            rManDet["lt"] = new DateTime(2020, 11, 07, 20, 41, 48, 573); ;
            rManDet["lu"] = "assistenza";
            rManDet["stop"] = new DateTime(2021, 12, 31);
            rManDet["idaccmotive"] = "00800110003"; // Causale Ricavo
            //SALVO I DATI DEL FORM MODIFICATO
            var res = t.saveFormData(mMandate);
            checkExistRule(res, "MOVIM176");

            }
        [TestMethod]
        public void Test2_estimate_2018_annullo2019_NonCollFattura2()
        {
            //2018: accertamento di 100, a 0 nel 2019
            //2019: impegno di 100
            //CASO esercizi anni precedenti 1a.2 dettaglio non incassato // OK 
            var t = new TestHelp(new DateTime(2019, 12, 31));
            q filterEst = q.eq("idestimkind", "CA_GENERICO") & q.eq("yestim", 2018) & q.eq("nestim", 48);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            DataRow rEst = tEstimate.Rows[0];
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rEst, false);
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst & q.isNotNull("stop"));
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreEqual(1, nEstDet, "Il contratto ha dettagli annullati");

            DataRow estimDet1 = tEstimateDetail.Rows[0];
            // n86541 id207662 y2018
            object idepacc1 = estimDet1["idepacc"];
         
            //VERIFICO CHE LA CAUSALE DI ANNULLO SIA CORRETTA (CN1.5.01.03.008) 
            DataRow rEstimateDetail = tEstimateDetail.Rows[0];
            string attualCode = rEstimateDetail["idaccmotiveannulment"] == DBNull.Value ? "" : (string)rEstimateDetail["idaccmotiveannulment"];
            Assert.AreEqual("000600010005000100030008", attualCode, "Il codice della causale d'annullo è corrispondente");

            //GENERO LE SCRITTURE E CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rEst);

            bool scrittureabilitate = t.abilitaScrittureUT(rEst);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");

            //CONTROLLO VARIAZIONI AI MOVIMENTI DI BUDGET
            DataRow[] rEpaccpvar = dsEP.Tables["epaccvar"]._Filter(null);
            Assert.AreEqual(rEpaccpvar.Length, 0, "Non Sono  presenti variazioni");

            //CONTROLLO NUMERO IMPEGNI DI BUDGET
            int countNepexp2019 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2019)).Length;
            Assert.AreEqual(1, countNepexp2019, "E' presente un impegno  di budget");
            int countNepexp2018 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2018)).Length;
            Assert.AreEqual(0, countNepexp2018, "Non ci sono impegni di budget del 2018");

            //CONTROLLO IMPEGNO DI BUDGET
            DataRow[] rEpexp = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2));
            DataRow[] rEpexpeyear = dsEP.Tables["epexpyear"]._Filter(q.eq("ayear", 2019));
            DataRow dr1_epexp = rEpexp[0];
            DataRow dr1_epexpyear = rEpexpeyear[0];
            Assert.AreEqual(dr1_epexp["description"], "VERSIONE 2 annullo con CAUSALE di COSTO CN1.5.01.03.008 nuova gest", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epexpyear["idacc"], "19000200010005000100030008", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexpyear["idupb"], "000100030005000200010108", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexp["idaccmotive"], "000600010005000100030008", "La causale del mov.budget è corrispondente");
            t.checkImportoInizialeImpBudget(dsEP.Tables["epexp"],dr1_epexp["idepexp"],2019, 100m);

            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019)).Length;
            Assert.AreEqual(0, countNepacc2019, "Non ci sono accertamenti di budget del 2019");
            int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
            Assert.AreEqual(1, countNepacc2018, "E' presente un accertamento di budget del 2018");

            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"],2018, 86541,2018, 100m);
            //CONTROLLO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc",2018) & q.eq("idepacc", idepacc1));
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc1));
            DataRow[] rEpaccyear_2018 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2018) & q.eq("idepacc", idepacc1));
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            DataRow dr1_epaccyear_2018 = rEpaccyear_2018[0];
            Assert.AreEqual(dr1_epacc["description"], "VERSIONE 2 annullo con CAUSALE di COSTO CN1.5.01.03.008 nuova gest", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epaccyear["amount"], 0m, "L'importo 2019 del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear_2018["amount"], 100.00m, "L'importo 2018 del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idacc"], "19000100010005000100010022", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idupb"], "000100030005000200010108", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["idaccmotive"], "000700010005000100010022", "La causale del mov.budget è corrispondente");

            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            var tEntrydetail = dsEP.Tables["entrydetail"];
            var rEntry = dsEP.Tables["entry"].Rows[0];
            var date_doc_colleg = new DateTime(2018, 12, 31);
            var date_contab = new DateTime(2019, 12, 31);
            Assert.AreEqual(rEntry["description"], "VERSIONE 2 annullo con CAUSALE di COSTO CN1.5.01.03.008 nuova gest", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "C.A. CA_GENERICO 18/48", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");
            //PRIMO DETTAGLIO SCRITTURA
            var descr1 =
                 "Contratto Attivo CA_GENERICO 18/48dett. 1- VERSIONE 2 annullo con CAUSALE di COSTO CN1.5.01.03.008 nuova gest";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1);
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(EntryDetail1["description"], descr1, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idacc"], "19000200010005000100030008", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idupb"], "000100030005000200010108", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idreg"], 10382, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idaccmotive"], "000600010005000100030008", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idepexp"], dr1_epexp["idepexp"]);
            Assert.AreEqual(EntryDetail1["idrelated"], dr1_epexp["idrelated"]);
            //SECONDO DETTAGLIO SCRITTURA
            var descr2 =
                "Contratto attivo CA_GENERICO n.48 / 2018 dett. 1";
            q filterEDetail2 = q.eq("description", descr2);
            var EntryDetail2Rows = tEntrydetail._Filter(filterEDetail2);
            var EntryDetail2 = EntryDetail2Rows[0];
            Assert.AreEqual(EntryDetail2["description"], descr2, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idacc"], "19000300020002000100090003", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idupb"], "000100030005000200010108", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idreg"], 10382, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idaccmotive"], "000600010005000100030008", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idepacc"], idepacc1);
            Assert.AreEqual(EntryDetail2["idrelated"], dr1_epacc["idrelated"]);
            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            Assert.AreEqual(2, dsEP.Tables["entry"]._Filter(null).Length, "Sono presenti due scritture");
            //CONTROLLO DETTAGLI SCRITTURA ESERCIZIO 2019
            Assert.AreEqual(2, dsEP.Tables["entrydetail"]._Filter(q.eq("nentry", rEntry["nentry"])).Length, "Sono presenti sette dettagli relativi alla scrittura");
            var avere = (decimal)dsEP.Tables["entrydetail"]._Filter(q.gt("amount", 0) & q.eq("nentry", rEntry["nentry"])).GetSum<decimal>("amount");
            Assert.AreEqual(100m, avere, "Avere corrispondente");

        }

        [TestMethod]
        public void Test2_estimate_2018_annullo2019_NonCollFattura4()
        {
            //2018:accertamento di 56, a 0 nel 2019
            //2019:
            //CASO esercizi anni precedenti 1a.4 dettaglio non incassato // OK 
            var t = new TestHelp(new DateTime(2019, 12, 31));
            q filterEst = q.eq("idestimkind", "CA_GENERICO") & q.eq("yestim", 2018) & q.eq("nestim", 49);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            DataRow rEst = tEstimate.Rows[0];
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            t.deleteEp(rEst);
            t.binaryCopyEp(rEst, false);
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst & q.isNotNull("stop"));
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreEqual(1, nEstDet, "Il contratto ha 1 dettaglio annullato");

            DataRow estimDet1 = tEstimateDetail.Rows[0];
            // 207664
            object idepacc1 = estimDet1["idepacc"];

            //GENERO LE SCRITTURE E CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rEst);

            bool scrittureabilitate = t.abilitaScrittureUT(rEst);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");

            //CONTROLLO VARIAZIONI AI MOVIMENTI DI BUDGET
            DataRow[] rEpaccpvar = dsEP.Tables["epaccvar"]._Filter(null);
            Assert.AreEqual(rEpaccpvar.Length, 0, "Non Sono  presenti variazioni");

            //CONTROLLO NUMERO IMPEGNI DI BUDGET
            int countNepexp2019 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2019)).Length;
            Assert.AreEqual(0, countNepexp2019, "Non ci sono impegni di budget del 2019");
            int countNepexp2018 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2018)).Length;
            Assert.AreEqual(0, countNepexp2018, "Non ci sono impegni di budget del 2018");

            //

            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019)).Length;
            Assert.AreEqual(0, countNepacc2019, "Non ci sono accertamenti di budget del 2019");
            int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
            Assert.AreEqual(1, countNepacc2018, "E' presente un accertamento di budget del 2018");

            //CONTROLLO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc1));
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc1));
            DataRow[] rEpaccyear2018 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2018) & q.eq("idepacc", idepacc1));
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            DataRow dr1_epaccyear_2018 = rEpaccyear2018[0];
            Assert.AreEqual(dr1_epacc["description"], "VERSIONE 2 con CAUSALE di RICAVO (la stessa del ricavo generato nel 2018", "La descrizione del mov.budget  è corrispondente");
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"],2018, 86542, 2018, 56m);
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"],2018, 86542, 2019, 0m);
            Assert.AreEqual(dr1_epaccyear["idacc"], "19000100010005000100010022", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idupb"], "000100030002000100010008", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["idaccmotive"], "000700010005000100010022", "La causale del mov.budget è corrispondente");

            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            var tEntrydetail = dsEP.Tables["entrydetail"];
            var rEntry = dsEP.Tables["entry"].Rows[0];
            var date_doc_colleg = new DateTime(2018, 12, 31);
            var date_contab = new DateTime(2019, 12, 31);
            Assert.AreEqual(rEntry["description"], "VERSIONE 2 con CAUSALE di RICAVO (la stessa del ricavo generato nel 2018", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "C.A. CA_GENERICO 18/49", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");
            //PRIMO DETTAGLIO SCRITTURA
            var descr1 =
                 "Contratto Attivo CA_GENERICO 18/49dett. 1- VERSIONE 2 con CAUSALE di RICAVO (la stessa del ricavo generato nel 2018";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1);
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(EntryDetail1["description"], descr1, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idacc"], "19000100010005000100010022", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idupb"], "000100030002000100010008", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idreg"], 112387, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idaccmotive"], "000700010005000100010022", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idepacc"], dr1_epacc["idepacc"]);
            Assert.AreEqual(EntryDetail1["idrelated"], dr1_epacc["idrelated"]);
            //SECONDO DETTAGLIO SCRITTURA
            var descr2 =
                "Contratto attivo CA_GENERICO n.49 / 2018 dett. 1";
            q filterEDetail2 = q.eq("description", descr2);
            var EntryDetail2Rows = tEntrydetail._Filter(filterEDetail2);
            var EntryDetail2 = EntryDetail2Rows[0];
            Assert.AreEqual(EntryDetail2["description"], descr2, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idacc"], "19000300020002000100090003", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idupb"], "000100030002000100010008", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idreg"], 112387, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idaccmotive"], "000700010005000100010022", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idepacc"], dr1_epacc["idepacc"]);
            Assert.AreEqual(EntryDetail2["idrelated"], dr1_epacc["idrelated"]);
            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            Assert.AreEqual(2, dsEP.Tables["entry"]._Filter(null).Length, "Sono presenti due scritture");
            //CONTROLLO DETTAGLI SCRITTURA ESERCIZIO 2019
            Assert.AreEqual(2, dsEP.Tables["entrydetail"]._Filter(q.eq("nentry", rEntry["nentry"])).Length, "Sono presenti 2 dettagli relativi alla scrittura");
            var avere = (decimal)dsEP.Tables["entrydetail"]._Filter(q.gt("amount", 0) & q.eq("nentry", rEntry["nentry"])).GetSum<decimal>("amount");
            Assert.AreEqual(56m, avere, "Avere corrispondente");

        }

        [TestMethod]
        public void Test2_estimate_2018_annullo2019_NonCollFattura_parzaccert()
        {
            //CASO esercizi anni precedenti 1b.1 //
            var t = new TestHelp(new DateTime(2019, 12, 31));
            q filterEst = q.eq("idestimkind", "CA_GENERICO") & q.eq("yestim", 2018) & q.eq("nestim", 38);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            DataRow rEst = tEstimate.Rows[0];
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rEst, false);
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst & q.isNotNull("stop"));
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreNotEqual(0, nEstDet, "Il contratto non ha dettagli annullati");

            //VERIFICO CHE LA CAUSALE DI COSTO SIA CORRETTA (CN1.5.01.03.008) 
            DataRow rEstimateDetail = tEstimateDetail.Rows[0];
            string attualCode = rEstimateDetail["idaccmotive"] == DBNull.Value ? "" : (string)rEstimateDetail["idaccmotive"];
            Assert.AreNotEqual("000600010005000100030008", attualCode, "Il codice della causale d'annullo è corrispondente");

            //GENERO IMPEGNI E SCRITTURE E CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rEst);

            bool scrittureabilitate = t.abilitaScrittureUT(rEst);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");

            //CONTROLLO VARIAZIONI AI MOVIMENTI DI BUDGET
            DataRow[] rEpaccpvar = dsEP.Tables["epaccvar"]._Filter(null);
            Assert.AreEqual(2,rEpaccpvar.Length,  "E' presente una variazione");
            t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"],2018, 86495,  -15m,2018);

            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"],2018, 86495,2018, 45m);
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"],2018, 86496,2018, 15m);
            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019)).Length;
            Assert.AreEqual(0, countNepacc2019, "Non ci sono accertamenti di budget del 2019");
            int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
            Assert.AreEqual(2, countNepacc2018, "Ci sono 2 accertamenti di budget del 2018");

            //CONTROLLO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2));
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019));
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            Assert.AreEqual(dr1_epacc["description"], "annullo nel 2019  con causale di costo parz contabilizzato nel 2018 NUOVA GESTIONE", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epaccyear["amount"], 0.00m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idacc"], "19000100010001000100030005", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idupb"], "000100020002000700010021", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["idaccmotive"], "000700010001000100030005", "La causale del mov.budget è corrispondente");

            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            var tEntrydetail = dsEP.Tables["entrydetail"];
            var rEntry = dsEP.Tables["entry"].Rows[0];
            var date_doc_colleg = new DateTime(2018, 12, 31);
            var date_contab = new DateTime(2019, 12, 31);
            Assert.AreEqual(rEntry["description"], "annullo nel 2019  con causale di costo parz contabilizzato nel 2018 NUOVA GESTIONE", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "C.A. CA_GENERICO 18/38", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");
            //PRIMO DETTAGLIO SCRITTURA
            var descr1 =
                 "Contratto Attivo CA_GENERICO 18/38dett. 1- annullo nel 2019  con causale di costo parz contabilizzato nel 2018 NUOVA GESTIONE";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1);
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(EntryDetail1["description"], descr1, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idacc"], "19000200010005000100030008", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idupb"], "000100020002000700010021", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idreg"], 112552, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idaccmotive"], "000600010005000100030008", "La causale del dettaglio della scrittura è corrispondente");
            //SECONDO DETTAGLIO SCRITTURA
            var descr2 =
                "Contratto Attivo CA_GENERICO 18/38dett. 2- annullo nel 2019  con causale di costo parz contabilizzato nel 2018 NUOVA GESTIONE";
            q filterEDetail2 = q.eq("description", descr2);
            var EntryDetail2Rows = tEntrydetail._Filter(filterEDetail2);
            var EntryDetail2 = EntryDetail2Rows[0];
            Assert.AreEqual(EntryDetail2["description"], descr2, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idacc"], "19000200010005000100030008", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idupb"], "000100020002000700010021", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idreg"], 112552, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idaccmotive"], "000600010005000100030008", "La causale del dettaglio della scrittura è corrispondente");

            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            Assert.AreEqual(2, dsEP.Tables["entry"]._Filter(null).Length, "Sono presenti due scritture");
            //CONTROLLO DETTAGLI SCRITTURA ESERCIZIO 2019
            Assert.AreEqual(4, dsEP.Tables["entrydetail"]._Filter(q.eq("nentry", rEntry["nentry"])).Length, "Sono presenti sette dettagli relativi alla scrittura");
            var avere = (decimal)dsEP.Tables["entrydetail"]._Filter(q.gt("amount", 0) & q.eq("nentry", rEntry["nentry"])).GetSum<decimal>("amount");
            Assert.AreEqual(45m, avere, "Avere corrispondente");
        }

        [TestMethod]
        public void Test2_estimate_2018_annullo2019_NonCollFattura_parzaccert2()
        {
            //2018:accertamento di 120 portato a 55, accertamento di 65, tutti a 0 nel 2019
            //2019:impegno di 65, impegno di 55
            //CASO esercizi anni precedenti 1b.2 
            var t = new TestHelp(new DateTime(2019, 12, 31));
            q filterEst = q.eq("idestimkind", "CA_GENERICO") & q.eq("yestim", 2018) & q.eq("nestim", 50);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            DataRow rEst = tEstimate.Rows[0];
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rEst, false);
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst & q.isNotNull("stop"));
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreEqual(2, nEstDet, "Il contratto ha 2 dettagli annullati");

            DataRow estimDet1 = tEstimateDetail.Rows[0];
            DataRow estimDet2 = tEstimateDetail.Rows[1];
            // 20766 
            object idepacc1 = estimDet1["idepacc"];
            // 207668
            object idepacc2 = estimDet2["idepacc"];

            
            //GENERO LE SCRITTURE E CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rEst);

            bool scrittureabilitate = t.abilitaScrittureUT(rEst);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");

            //CONTROLLO VARIAZIONI AI MOVIMENTI DI BUDGET (esercizio 2018)
            DataRow[] rEpaccpvar = dsEP.Tables["epaccvar"]._Filter(null);
            Assert.AreEqual(2, rEpaccpvar.Length, "E' presente variazione");
            t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"],2018, 86543, -55m, 2018);

            //CONTROLLO NUMERO IMPEGNI DI BUDGET
            int countNepexp2019 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2019)).Length;
            Assert.AreEqual(2, countNepexp2019, "Sono presenti 2 accertamenti di budget");
            int countNepexp2018 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2018)).Length;
            Assert.AreEqual(0, countNepexp2018, "Non ci sono impegni di budget del 2018");

            //CONTROLLO PRIMO IMPEGNO DI BUDGET
            DataRow[] rEpexp = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp",2019) & q.eq("idepexp", 578928));
            DataRow[] rEpexpeyear = dsEP.Tables["epexpyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepexp", 578928));
            DataRow dr1_epexp = rEpexp[0];
            DataRow dr1_epexpyear = rEpexpeyear[0];
            Assert.AreEqual(dr1_epexp["description"], "VERSIONE 2 con CAUSALE di RICAVO (la stessa del ricavo generato nel 2018", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epexpyear["amount"], 55.00m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexpyear["idacc"], "19000200010005000100030008", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexpyear["idupb"], "000100030005000200010109", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexp["idaccmotive"], "000600010005000100030008", "La causale del mov.budget è corrispondente");

            //CONTROLLO SECONDO IMPEGNO DI BUDGET
            DataRow[] rEpexp2 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2019) & q.eq("idepexp", 578927));
            DataRow[] rEpexpeyear2 = dsEP.Tables["epexpyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepexp", 578927));
            DataRow dr2_epexp = rEpexp2[0];
            DataRow dr2_epexpyear = rEpexpeyear2[0];
            Assert.AreEqual(dr2_epexp["description"], "VERSIONE 2 con CAUSALE di RICAVO (la stessa del ricavo generato nel 2018", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr2_epexpyear["amount"], 65.00m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epexpyear["idacc"], "19000200010005000100030008", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epexpyear["idupb"], "000100030005000200010109", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epexp["idaccmotive"], "000600010005000100030008", "La causale del mov.budget è corrispondente");

            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"],2018, 86543,2018, 120m);
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"],2018, 86544,2018, 55m);
            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019)).Length;
            Assert.AreEqual(0, countNepacc2019, "Non ci sono accertamenti di budget del 2019");
            int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
            Assert.AreEqual(2, countNepacc2018, "Sono presenti 2 accertamenti di budget del 2018");

            //CONTROLLO PRIMO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc2));
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc2));
            DataRow[] rEpaccyear_2018 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2018) & q.eq("idepacc", idepacc2));
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            DataRow dr1_epaccyear_2018 = rEpaccyear_2018[0];
            Assert.AreEqual(dr1_epacc["description"], "VERSIONE 2 con CAUSALE di RICAVO (la stessa del ricavo generato nel 2018", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epaccyear["amount"], 0m, "L'importo 2019  del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear_2018["amount"], 55.00m, "L'importo 2018 del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idacc"], "19000100010005000100010022", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idupb"], "000100030005000200010109", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["idaccmotive"], "000700010005000100010022", "La causale del mov.budget è corrispondente");

            //CONTROLLO SECONDO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO
            DataRow[] rEpacc2 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc1));
            DataRow[] rEpaccyear2 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc1));
            DataRow[] rEpaccyear2_2018 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2018) & q.eq("idepacc", idepacc1));
            DataRow dr2_epacc = rEpacc2[0];
            DataRow dr2_epaccyear = rEpaccyear2[0];
            DataRow dr2_epaccyear_2018 = rEpaccyear2_2018[0];
            Assert.AreEqual(dr2_epacc["description"], "VERSIONE 2 con CAUSALE di RICAVO (la stessa del ricavo generato nel 2018", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr2_epaccyear["amount"], 0m, "L'importo 2019  del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epaccyear_2018["amount"], 120m, "L'importo 2018 del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epaccyear["idacc"], "19000100010005000100010022", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epaccyear["idupb"], "000100030005000200010109", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epacc["idaccmotive"], "000700010005000100010022", "La causale del mov.budget è corrispondente");

            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            var tEntrydetail = dsEP.Tables["entrydetail"];
            var rEntry = dsEP.Tables["entry"].Rows[0];
            var date_doc_colleg = new DateTime(2018, 12, 31);
            var date_contab = new DateTime(2019, 12, 31);
            Assert.AreEqual(rEntry["description"], "sosti VERSIONE 2 con CAUSALE di COSTO CN1.5.01.03.008  nuova gest", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "C.A. CA_GENERICO 18/50", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");
            //PRIMO DETTAGLIO SCRITTURA
            var descr1 =
                 "Contratto Attivo CA_GENERICO 18/50dett. 1- VERSIONE 2 con CAUSALE di RICAVO (la stessa del ricavo generato nel 2018";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1 & q.eq("idacc", "19000200010005000100030008"));
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(EntryDetail1["description"], descr1, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idupb"], "000100030005000200010109", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idreg"], 112387, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idaccmotive"], "000600010005000100030008", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idepexp"], dr2_epexp["idepexp"]);
            Assert.AreEqual(EntryDetail1["idrelated"], dr2_epexp["idrelated"]);
            //SECONDO DETTAGLIO SCRITTURA
            var descr2 =
                "Contratto attivo CA_GENERICO n.50 / 2018 dett. 1";
            q filterEDetail2 = q.eq("description", descr2);
            var EntryDetail2Rows = tEntrydetail._Filter(filterEDetail2 & q.eq("idacc", "19000300020002000100090003"));
            var EntryDetail2 = EntryDetail2Rows[0];
            Assert.AreEqual(EntryDetail2["description"], descr2, "La descrizione del dettaglio della scrittura è corrispondente");     
            Assert.AreEqual(EntryDetail2["idupb"], "000100030005000200010109", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idreg"], 112387, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idaccmotive"], "000600010005000100030008", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idepacc"], idepacc1);
            Assert.AreEqual(EntryDetail2["idrelated"], dr2_epacc["idrelated"]);
            //TERZO DETTAGLIO SCRITTURA
            var descr3 =
                "Contratto Attivo CA_GENERICO 18/50dett. 2- VERSIONE 2 con CAUSALE di RICAVO (la stessa del ricavo generato nel 2018";
            q filterEDetail3 = q.eq("description", descr3);
            var EntryDetail3Rows = tEntrydetail._Filter(filterEDetail3 & q.eq("idacc", "19000200010005000100030008"));
            var EntryDetail3 = EntryDetail3Rows[0];
            Assert.AreEqual(EntryDetail3["description"], descr3, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail3["idupb"], "000100030005000200010109", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail3["idreg"], 112387, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail3["idaccmotive"], "000600010005000100030008", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail3["idepexp"], dr1_epexp["idepexp"]);
            Assert.AreEqual(EntryDetail3["idrelated"], dr1_epexp["idrelated"]);
            //QUARTO DETTAGLIO SCRITTURA
            var descr4 =
                "Contratto attivo CA_GENERICO n.50 / 2018 dett. 2";
            q filterEDetail4 = q.eq("description", descr4);
            var EntryDetail4Rows = tEntrydetail._Filter(filterEDetail4 & q.eq("idacc", "19000300020002000100090003"));
            var EntryDetail4 = EntryDetail4Rows[0];
            Assert.AreEqual(EntryDetail4["description"], descr4, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail4["idupb"], "000100030005000200010109", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail4["idreg"], 112387, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail4["idaccmotive"], "000600010005000100030008", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(dr1_epacc["idepacc"], dr1_epacc["idepacc"]);
            Assert.AreEqual(dr1_epacc["idrelated"], dr1_epacc["idrelated"]);
            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            Assert.AreEqual(2, dsEP.Tables["entry"]._Filter(null).Length, "Sono presenti due scritture");
            //CONTROLLO DETTAGLI SCRITTURA ESERCIZIO 2019
            Assert.AreEqual(4, dsEP.Tables["entrydetail"]._Filter(q.eq("nentry", rEntry["nentry"])).Length, "Sono presenti 4 dettagli relativi alla scrittura");
            var avere = (decimal)dsEP.Tables["entrydetail"]._Filter(q.gt("amount", 0) & q.eq("nentry", rEntry["nentry"])).GetSum<decimal>("amount");
            Assert.AreEqual(120m, avere, "Avere corrispondente");

        }

        [TestMethod]
        public void Test2_estimate_2018_annullo2019_NonCollFattura_parzaccert3()
        {
            //2018:accertamento di 50 portato a 20, accertamento di 30
            //2019:accetamenti tutti a 0
            //CASO esercizi anni precedenti 1b.3 
            var t = new TestHelp(new DateTime(2019, 12, 31));
            q filterEst = q.eq("idestimkind", "CA_GENERICO") & q.eq("yestim", 2018) & q.eq("nestim", 39);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            DataRow rEst = tEstimate.Rows[0];
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rEst, false);
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst & q.isNotNull("stop"));
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreEqual(2, nEstDet, "Il contratto ha 2 dettagli annullati");

            DataRow estimDet1 = tEstimateDetail.Rows[0];
            DataRow estimDet2 = tEstimateDetail.Rows[1];
            // 207554 
            object idepacc1 = estimDet1["idepacc"];
            // 207556
            object idepacc2 = estimDet2["idepacc"];

            //GENERO LE SCRITTURE E CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rEst);

            bool scrittureabilitate = t.abilitaScrittureUT(rEst);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");

            //CONTROLLO VARIAZIONI AI MOVIMENTI DI BUDGET (esercizio 2018)
            DataRow[] rEpaccpvar = dsEP.Tables["epaccvar"]._Filter(null);
            Assert.AreEqual(2,rEpaccpvar.Length,  "E' presente variazione");
            t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"],2018, 86497, -30m, 2018);

            //CONTROLLO NUMERO IMPEGNI DI BUDGET
            int countNepexp2019 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2019)).Length;
            Assert.AreEqual(0, countNepexp2019, "Non sono presenti impegni  di budget del 2019");
            int countNepexp2018 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2018)).Length;
            Assert.AreEqual(0, countNepexp2018, "Non ci sono impegni di budget del 2018");

            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"],2018, 86498,2018,  30m);
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"],2018, 86497, 2018, 50m);
            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019)).Length;
            Assert.AreEqual(0, countNepacc2019, "Non ci sono accertamenti di budget del 2019");
            int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
            Assert.AreEqual(2, countNepacc2018, "Sono presenti 2 accertamenti di budget del 2018");

            //CONTROLLO PRIMO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc2));
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc2));
            DataRow[] rEpaccyear_2018 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2018) & q.eq("idepacc", idepacc2));
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            DataRow dr1_epaccyear_2018 = rEpaccyear_2018[0];
            Assert.AreEqual(dr1_epacc["description"], "annullo nel 2019  con causale di ricavo parz contabilizzato nel 2018 NUOVA GESTIONE", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epaccyear["amount"], 0m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear_2018["amount"], 30.00m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idacc"], "19000100010001000100030005", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idupb"], "000100010016", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["idaccmotive"], "000700010001000100030005", "La causale del mov.budget è corrispondente");

            //CONTROLLO SECONDO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO
            DataRow[] rEpacc2 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc1));
            DataRow[] rEpaccyear2 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc1));
            DataRow[] rEpaccyear2_2018 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2018) & q.eq("idepacc", idepacc1));
            DataRow dr2_epacc = rEpacc2[0];
            DataRow dr2_epaccyear = rEpaccyear2[0];
            DataRow dr2_epaccyear_2018 = rEpaccyear2_2018[0];
            Assert.AreEqual(dr2_epacc["description"], "annullo nel 2019  con causale di ricavo parz contabilizzato nel 2018 NUOVA GESTIONE", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr2_epaccyear["amount"], 0.00m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epaccyear_2018["amount"], 50m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epaccyear["idacc"], "19000100010001000100030005", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epaccyear["idupb"], "000100010016", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epacc["idaccmotive"], "000700010001000100030005", "La causale del mov.budget è corrispondente");

            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            var tEntrydetail = dsEP.Tables["entrydetail"];
            var rEntry = dsEP.Tables["entry"].Rows[0];
            var date_doc_colleg = new DateTime(2018, 12, 31);
            var date_contab = new DateTime(2019, 12, 31);
            Assert.AreEqual(rEntry["description"], "annullo nel 2019  con causale di ricavo parz contabilizzato nel 2018 NUOVA GESTIONE", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "C.A. CA_GENERICO 18/39", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");
            //PRIMO DETTAGLIO SCRITTURA
            var descr1 =
                 "Contratto Attivo CA_GENERICO 18/39dett. 1- annullo nel 2019  con causale di ricavo parz contabilizzato nel 2018 NUOVA GESTIONE";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1 & q.eq("idacc", "19000100010001000100030005"));
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(EntryDetail1["description"], descr1, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idupb"], "000100010016", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idreg"], 117585, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idaccmotive"], "000700010001000100030005", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idepacc"], dr2_epacc["idepacc"]);
            Assert.AreEqual(EntryDetail1["idrelated"], dr2_epacc["idrelated"]);
            //SECONDO DETTAGLIO SCRITTURA
            var descr2 =
                "Contratto attivo CA_GENERICO n.39 / 2018 dett. 1";
            q filterEDetail2 = q.eq("description", descr2);
            var EntryDetail2Rows = tEntrydetail._Filter(filterEDetail2 & q.eq("idacc", "19000300020002000100090003"));
            var EntryDetail2 = EntryDetail2Rows[0];
            Assert.AreEqual(EntryDetail2["description"], descr2, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idupb"], "000100010016", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idreg"], 117585, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idaccmotive"], "000700010001000100030005", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idepacc"], idepacc1);
            Assert.AreEqual(EntryDetail2["idrelated"], dr2_epacc["idrelated"]);
            //TERZO DETTAGLIO SCRITTURA
            var descr3 =
                "Contratto Attivo CA_GENERICO 18/39dett. 2- annullo nel 2019  con causale di ricavo parz contabilizzato nel 2018 NUOVA GESTIONE";
            q filterEDetail3 = q.eq("description", descr3);
            var EntryDetail3Rows = tEntrydetail._Filter(filterEDetail3 & q.eq("idacc", "19000100010001000100030005"));
            var EntryDetail3 = EntryDetail3Rows[0];
            Assert.AreEqual(EntryDetail3["description"], descr3, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail3["idupb"], "000100010016", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail3["idreg"], 117585, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail3["idaccmotive"], "000700010001000100030005", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail3["idepacc"], dr1_epacc["idepacc"]);
            Assert.AreEqual(EntryDetail3["idrelated"], dr1_epacc["idrelated"]);
            //QUARTO DETTAGLIO SCRITTURA
            var descr4 =
                "Contratto attivo CA_GENERICO n.39 / 2018 dett. 2";
            q filterEDetail4 = q.eq("description", descr4);
            var EntryDetail4Rows = tEntrydetail._Filter(filterEDetail4 & q.eq("idacc", "19000300020002000100090003"));
            var EntryDetail4 = EntryDetail4Rows[0];
            Assert.AreEqual(EntryDetail4["description"], descr4, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail4["idupb"], "000100010016", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail4["idreg"], 117585, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail4["idaccmotive"], "000700010001000100030005", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(dr1_epacc["idepacc"], dr1_epacc["idepacc"]);
            Assert.AreEqual(dr1_epacc["idrelated"], dr1_epacc["idrelated"]);
            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            Assert.AreEqual(2, dsEP.Tables["entry"]._Filter(null).Length, "Sono presenti due scritture");
            //CONTROLLO DETTAGLI SCRITTURA ESERCIZIO 2019
            Assert.AreEqual(4, dsEP.Tables["entrydetail"]._Filter(q.eq("nentry", rEntry["nentry"])).Length, "Sono presenti 4 dettagli relativi alla scrittura");
            var avere = (decimal)dsEP.Tables["entrydetail"]._Filter(q.gt("amount", 0) & q.eq("nentry", rEntry["nentry"])).GetSum<decimal>("amount");
            Assert.AreEqual(50m, avere, "Avere corrispondente");
        }

		//[TestMethod]
		//public void Test2_estimate_2018_annullo2019_NonCollFattura_parzaccert4()
		//{
		//    //2018: accertamento di 110 portato a 70 e accertamento di 40
		//    //2019: accertamenti tutto a 0
		//    //CASO esercizi anni precedenti 1b.4 
		//    var t = new TestHelp(new DateTime(2019, 12, 31));
		//    q filterEst = q.eq("idestimkind", "CA_GENERICO") & q.eq("yestim", 2018) & q.eq("nestim", 51);
		//    t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
		//    DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
		//    DataRow rEst = tEstimate.Rows[0];
		//    Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
		//    t.binaryCopyEp(rEst, false);
		//    DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst & q.isNotNull("stop"));
		//    int nEstDet = tEstimateDetail.Rows.Count;
		//    Assert.AreEqual(2, nEstDet, "Il contratto ha 2 dettagli annullati");

		//    DataRow estimDet1 = tEstimateDetail.Rows[0];
		//    DataRow estimDet2 = tEstimateDetail.Rows[1];
		//    // 207670 
		//    object idepacc1 = estimDet1["idepacc"];
		//    // 207672
		//    object idepacc2 = estimDet2["idepacc"];

		//    //GENERO LE SCRITTURE E CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
		//    ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);
		//    if (regole != null)
		//        Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
		//    var dsEP = t.getEpData(t.testConn, rEst);

		//    //CONTROLLO VARIAZIONI AI MOVIMENTI DI BUDGET (esercizio 2018)
		//    DataRow[] rEpaccpvar = dsEP.Tables["epaccvar"]._Filter(null);
		//    Assert.AreEqual(2, rEpaccpvar.Length,  "E' presente variazione");
		//    t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"],2018, 86545,  -40m,2018);

		//    //CONTROLLO NUMERO IMPEGNI DI BUDGET
		//    int countNepexp2019 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2019)).Length;
		//    Assert.AreEqual(0, countNepexp2019, "Non sono presenti impegni  di budget del 2019");
		//    int countNepexp2018 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2018)).Length;
		//    Assert.AreEqual(0, countNepexp2018, "Non ci sono impegni di budget del 2018");

		//    t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"],2018, 86546,2018, 40m);
		//    t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"],2018, 86545,2018, 110m);
		//    //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
		//    int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019)).Length;
		//    Assert.AreEqual(0, countNepacc2019, "Non ci sono accertamenti di budget del 2019");
		//    int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
		//    Assert.AreEqual(2, countNepacc2018, "Sono presenti 2 accertamenti di budget del 2018");

		//    //CONTROLLO PRIMO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO
		//    DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc2));
		//    DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc2));
		//    DataRow[] rEpaccyear2018 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2018) & q.eq("idepacc", idepacc2));
		//    DataRow dr1_epacc = rEpacc[0];
		//    DataRow dr1_epaccyear = rEpaccyear[0];
		//    DataRow dr1_epaccyear2018 = rEpaccyear2018[0];
		//    Assert.AreEqual(dr1_epacc["description"], "ann VERSIONE 2 con CAUSALE di ricavo  nuova gest", "La descrizione del mov.budget  è corrispondente");

		//    t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"],dr1_epacc["idepacc"],2019, 0m);
		//    t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"],dr1_epacc["idepacc"],2018, 40m);

		//    Assert.AreEqual(dr1_epaccyear["idacc"], "19000100010005000100010022", "Il n.conto del mov.budget è corrispondente");
		//    Assert.AreEqual(dr1_epaccyear["idupb"], "000100030002000100010078", "L'UPB del mov.budget è corrispondente");
		//    Assert.AreEqual(dr1_epacc["idaccmotive"], "000700010005000100010022", "La causale del mov.budget è corrispondente");

		//    //CONTROLLO SECONDO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO
		//    DataRow[] rEpacc2 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc1));
		//    DataRow[] rEpaccyear2 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc1));
		//    DataRow[] rEpaccyear2_2018 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2018) & q.eq("idepacc", idepacc1));
		//    DataRow dr2_epacc = rEpacc2[0];
		//    DataRow dr2_epaccyear = rEpaccyear2[0];
		//    DataRow dr2_epaccyear_2018 = rEpaccyear2_2018[0];
		//    Assert.AreEqual(dr2_epacc["description"], "ann VERSIONE 2 con CAUSALE di ricavo  nuova gest", "La descrizione del mov.budget  è corrispondente");

		//    t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"],dr2_epacc["idepacc"],2019, 0m);
		//    t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"],dr2_epacc["idepacc"],2018, 110m);

		//    Assert.AreEqual(dr2_epaccyear["idacc"], "19000100010005000100010022", "Il n.conto del mov.budget è corrispondente");
		//    Assert.AreEqual(dr2_epaccyear["idupb"], "000100030002000100010078", "L'UPB del mov.budget è corrispondente");
		//    Assert.AreEqual(dr2_epacc["idaccmotive"], "000700010005000100010022", "La causale del mov.budget è corrispondente");

		//    //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
		//    var tEntrydetail = dsEP.Tables["entrydetail"];
		//    var rEntry = dsEP.Tables["entry"].Rows[0];
		//    var date_doc_colleg = new DateTime(2018, 12, 31);
		//    var date_contab = new DateTime(2019, 12, 31);
		//    Assert.AreEqual(rEntry["description"], "ann VERSIONE 2 con CAUSALE di ricavo  nuova gest", "La descrizione della scrittura è corrispondente");
		//    Assert.AreEqual(rEntry["doc"], "C.A. CA_GENERICO 18/51", "La descrizione del documento collegato alla scrittura è corrispondente");
		//    Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
		//    Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");
		//    //PRIMO DETTAGLIO SCRITTURA
		//    var descr1 =
		//         "Contratto Attivo CA_GENERICO 18/51dett. 1- ann VERSIONE 2 con CAUSALE di ricavo  nuova gest";
		//    q filterEDetail1 = q.eq("description", descr1);
		//    var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1 & q.eq("idacc", "19000100010005000100010022"));
		//    var EntryDetail1 = EntryDetail1Rows[0];
		//    Assert.AreEqual(EntryDetail1["description"], descr1, "La descrizione del dettaglio della scrittura è corrispondente");
		//    Assert.AreEqual(EntryDetail1["idupb"], "000100030002000100010078", "L'UPB del dettaglio della scrittura è corrispondente");
		//    Assert.AreEqual(EntryDetail1["idreg"], 112387, "Il cliente del dettaglio della scrittura è corrispondente");
		//    Assert.AreEqual(EntryDetail1["idaccmotive"], "000700010005000100010022", "La causale del dettaglio della scrittura è corrispondente");
		//    Assert.AreEqual(EntryDetail1["idepacc"], dr2_epacc["idepacc"]);
		//    Assert.AreEqual(EntryDetail1["idrelated"], dr2_epacc["idrelated"]);
		//    //SECONDO DETTAGLIO SCRITTURA
		//    var descr2 =
		//        "Contratto attivo CA_GENERICO n.51 / 2018 dett. 1";
		//    q filterEDetail2 = q.eq("description", descr2);
		//    var EntryDetail2Rows = tEntrydetail._Filter(filterEDetail2 & q.eq("idacc", "19000300020002000100090003"));
		//    var EntryDetail2 = EntryDetail2Rows[0];
		//    Assert.AreEqual(EntryDetail2["description"], descr2, "La descrizione del dettaglio della scrittura è corrispondente");
		//    Assert.AreEqual(EntryDetail2["idupb"], "000100030002000100010078", "L'UPB del dettaglio della scrittura è corrispondente");
		//    Assert.AreEqual(EntryDetail2["idreg"], 112387, "Il cliente del dettaglio della scrittura è corrispondente");
		//    Assert.AreEqual(EntryDetail2["idaccmotive"], "000700010005000100010022", "La causale del dettaglio della scrittura è corrispondente");
		//    Assert.AreEqual(EntryDetail2["idepacc"], dr2_epacc["idepacc"]);
		//    Assert.AreEqual(EntryDetail2["idrelated"], dr2_epacc["idrelated"]);
		//    //TERZO DETTAGLIO SCRITTURA
		//    var descr3 =
		//        "Contratto Attivo CA_GENERICO 18/51dett. 2- ann VERSIONE 2 con CAUSALE di ricavo  nuova gest";
		//    q filterEDetail3 = q.eq("description", descr3);
		//    var EntryDetail3Rows = tEntrydetail._Filter(filterEDetail3 & q.eq("idacc", "19000100010005000100010022"));
		//    var EntryDetail3 = EntryDetail3Rows[0];
		//    Assert.AreEqual(EntryDetail3["description"], descr3, "La descrizione del dettaglio della scrittura è corrispondente");
		//    Assert.AreEqual(EntryDetail3["idupb"], "000100030002000100010078", "L'UPB del dettaglio della scrittura è corrispondente");
		//    Assert.AreEqual(EntryDetail3["idreg"], 112387, "Il cliente del dettaglio della scrittura è corrispondente");
		//    Assert.AreEqual(EntryDetail3["idaccmotive"], "000700010005000100010022", "La causale del dettaglio della scrittura è corrispondente");
		//    Assert.AreEqual(EntryDetail3["idepacc"], dr1_epacc["idepacc"]);
		//    Assert.AreEqual(EntryDetail3["idrelated"], dr1_epacc["idrelated"]);
		//    //QUARTO DETTAGLIO SCRITTURA
		//    var descr4 =
		//        "Contratto attivo CA_GENERICO n.51 / 2018 dett. 2";
		//    q filterEDetail4 = q.eq("description", descr4);
		//    var EntryDetail4Rows = tEntrydetail._Filter(filterEDetail4 & q.eq("idacc", "19000300020002000100090003"));
		//    var EntryDetail4 = EntryDetail4Rows[0];
		//    Assert.AreEqual(EntryDetail4["description"], descr4, "La descrizione del dettaglio della scrittura è corrispondente");
		//    Assert.AreEqual(EntryDetail4["idupb"], "000100030002000100010078", "L'UPB del dettaglio della scrittura è corrispondente");
		//    Assert.AreEqual(EntryDetail4["idreg"], 112387, "Il cliente del dettaglio della scrittura è corrispondente");
		//    Assert.AreEqual(EntryDetail4["idaccmotive"], "000700010005000100010022", "La causale del dettaglio della scrittura è corrispondente");
		//    Assert.AreEqual(dr1_epacc["idepacc"], dr1_epacc["idepacc"]);
		//    Assert.AreEqual(dr1_epacc["idrelated"], dr1_epacc["idrelated"]);
		//    //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
		//    Assert.AreEqual(2, dsEP.Tables["entry"]._Filter(null).Length, "Sono presenti due scritture");
		//    //CONTROLLO DETTAGLI SCRITTURA ESERCIZIO 2019
		//    Assert.AreEqual(4, dsEP.Tables["entrydetail"]._Filter(q.eq("nentry", rEntry["nentry"])).Length, "Sono presenti 4 dettagli relativi alla scrittura");
		//    var avere = (decimal)dsEP.Tables["entrydetail"]._Filter(q.gt("amount", 0) & q.eq("nentry", rEntry["nentry"])).GetSum<decimal>("amount");
		//    Assert.AreEqual(110m, avere, "Avere corrispondente");
		//}

		[TestMethod]
		public void Test2_estimate_2018_annullo2019_NonCollFattura_parzaccert4() {
			//2018: Acc.86632 di 2300, Acc. 86631 di 3500 portato a 1200 con var di - 2300, Acc.86630 di 5000 portato a 1500 con var di -3500
			//2019: Acc.1761 di 2300, Acc.1760 di 1200, Acc.1759 di 1500, Acc.86632 di 0, Acc.86631 di 0, Acc. 86630 di 0
			
			var t = new TestHelp(new DateTime(2019, 12, 31));
			q filterEst = q.eq("idestimkind", "CA_GENERICO") & q.eq("yestim", 2018) & q.eq("nestim", 67);
			t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
			DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
			DataRow rEst = tEstimate.Rows[0];
			Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
			t.binaryCopyEp(rEst, false);
			DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst);
			int nEstDet = tEstimateDetail.Rows.Count;
			Assert.AreEqual(6, nEstDet, "Il contratto ha 6  dettagli");

			DataRow estimDet1 = tEstimateDetail.Rows[0];
			DataRow estimDet2 = tEstimateDetail.Rows[1];
            DataRow estimDet3 = tEstimateDetail.Rows[2];
            DataRow estimDet4 = tEstimateDetail.Rows[3];
            DataRow estimDet5 = tEstimateDetail.Rows[4];
            DataRow estimDet6 = tEstimateDetail.Rows[5];
			//207934  
			object idepacc1 = estimDet1["idepacc"];
			//207936 
			object idepacc2 = estimDet2["idepacc"];
            //207938
            object idepacc3 = estimDet3["idepacc"];
            //207942
            object idepacc4 = estimDet4["idepacc"];
            //207943
            object idepacc5 = estimDet5["idepacc"];
            //207944
            object idepacc6 = estimDet6["idepacc"];

			//GENERO LE SCRITTURE E CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
			ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);
			if (regole != null)
				Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
			var dsEP = t.getEpData(t.testConn, rEst);

            bool scrittureabilitate = t.abilitaScrittureUT(rEst);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");

			//CONTROLLO VARIAZIONI AI MOVIMENTI DI BUDGET (esercizio 2018)
			DataRow[] rEpaccpvar = dsEP.Tables["epaccvar"]._Filter(null);
			Assert.AreEqual(2*2, rEpaccpvar.Length, "Sono presenti due varizioni");
			t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"], 2018, 86631, -2300m, 2018);
            t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"], 2018, 86630, -3500m, 2018);

			//CONTROLLO NUMERO IMPEGNI DI BUDGET
			int countNepexp = dsEP.Tables["epexp"]._Filter(null).Length;
			Assert.AreEqual(0, countNepexp, "Non sono presenti impegni di budget");
			
			t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2018, 86632, 2018, 2300m);
			t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2018, 86631, 2018, 3500m);
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2018, 86630, 2018, 5000m);
			//CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
			int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019)).Length;
			Assert.AreEqual(3, countNepacc2019, "Ci sono 3 accertamenti di budget del 2019");
			int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
			Assert.AreEqual(3, countNepacc2018, "Ci sono 3 accertamenti di budget del 2018");

			//CONTROLLO PRIMO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO
			DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019) & q.eq("idepacc", idepacc6));
			DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc6));
			DataRow dr1_epacc = rEpacc[0];
			DataRow dr1_epaccyear = rEpaccyear[0];
			Assert.AreEqual(dr1_epacc["description"], "tasto annulla con causale di ricavo e dettagli splittati", "La descrizione del mov.budget  è corrispondente");
			Assert.AreEqual(dr1_epaccyear["idacc"], "19000100010001000200010001", "Il n.conto del mov.budget è corrispondente");
			Assert.AreEqual(dr1_epaccyear["idupb"], "00010002", "L'UPB del mov.budget è corrispondente");
			Assert.AreEqual(dr1_epacc["idaccmotive"], "0001000600020004", "La causale del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["flagvariation"], "S", "Accertamento di tipo variazione");
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2019, 1761, 2019, 2300m);

			//CONTROLLO SECONDO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO
			DataRow[] rEpacc2 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019) & q.eq("idepacc", idepacc5));
			DataRow[] rEpaccyear2 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc5));
			DataRow dr2_epacc = rEpacc2[0];
			DataRow dr2_epaccyear = rEpaccyear2[0];
			Assert.AreEqual(dr2_epacc["description"], "tasto annulla con causale di ricavo e dettagli splittati", "La descrizione del mov.budget  è corrispondente");
			Assert.AreEqual(dr2_epaccyear["idacc"], "19000100010001000200010001", "Il n.conto del mov.budget è corrispondente");
			Assert.AreEqual(dr2_epaccyear["idupb"], "00010002", "L'UPB del mov.budget è corrispondente");
			Assert.AreEqual(dr2_epacc["idaccmotive"], "0001000600020004", "La causale del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epacc["flagvariation"], "S", "Accertamento di tipo variazione");
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2019, 1760, 2019, 1200m);

            //CONTROLLO TERZO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO
			DataRow[] rEpacc3 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019) & q.eq("idepacc", idepacc4));
			DataRow[] rEpaccyear3 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc4));
			DataRow dr3_epacc = rEpacc3[0];
			DataRow dr3_epaccyear = rEpaccyear3[0];
			Assert.AreEqual(dr3_epacc["description"], "tasto annulla con causale di ricavo e dettagli splittati", "La descrizione del mov.budget  è corrispondente");
			Assert.AreEqual(dr3_epaccyear["idacc"], "19000100010001000200010001", "Il n.conto del mov.budget è corrispondente");
			Assert.AreEqual(dr3_epaccyear["idupb"], "00010002", "L'UPB del mov.budget è corrispondente");
			Assert.AreEqual(dr3_epacc["idaccmotive"], "0001000600020004", "La causale del mov.budget è corrispondente");
            Assert.AreEqual(dr3_epacc["flagvariation"], "S", "Accertamento di tipo variazione");
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2019, 1759, 2019, 1500m);

            //CONTROLLO QUARTO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO
			DataRow[] rEpacc4 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc3));
			DataRow[] rEpaccyear4 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc3));
			DataRow dr4_epacc = rEpacc4[0];
			DataRow dr4_epaccyear = rEpaccyear4[0];
			Assert.AreEqual(dr4_epacc["description"], "tasto annulla con causale di ricavo e dettagli splittati", "La descrizione del mov.budget  è corrispondente");
			Assert.AreEqual(dr4_epaccyear["idacc"], "19000100010001000200010001", "Il n.conto del mov.budget è corrispondente");
			Assert.AreEqual(dr4_epaccyear["idupb"], "00010002", "L'UPB del mov.budget è corrispondente");
			Assert.AreEqual(dr4_epacc["idaccmotive"], "0001000600020004", "La causale del mov.budget è corrispondente");
            Assert.AreEqual(dr4_epacc["flagvariation"], "N", "Accertamento non di tipo variazione");
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2018, 86632, 2019, 0m);

            //CONTROLLO QUINTO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO
			DataRow[] rEpacc5 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc2));
			DataRow[] rEpaccyear5 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc2));
			DataRow dr5_epacc = rEpacc5[0];
			DataRow dr5_epaccyear = rEpaccyear5[0];
			Assert.AreEqual(dr5_epacc["description"], "tasto annulla con causale di ricavo e dettagli splittati", "La descrizione del mov.budget  è corrispondente");
			Assert.AreEqual(dr5_epaccyear["idacc"], "19000100010001000200010001", "Il n.conto del mov.budget è corrispondente");
			Assert.AreEqual(dr5_epaccyear["idupb"], "00010002", "L'UPB del mov.budget è corrispondente");
			Assert.AreEqual(dr5_epacc["idaccmotive"], "0001000600020004", "La causale del mov.budget è corrispondente");
            Assert.AreEqual(dr5_epacc["flagvariation"], "N", "Accertamento non di tipo variazione");
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2018, 86631, 2019, 0m);

            //CONTROLLO SESTO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO
			DataRow[] rEpacc6 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc1));
			DataRow[] rEpaccyear6 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc1));
			DataRow dr6_epacc = rEpacc6[0];
			DataRow dr6_epaccyear = rEpaccyear6[0];
			Assert.AreEqual(dr6_epacc["description"], "tasto annulla con causale di ricavo e dettagli splittati", "La descrizione del mov.budget  è corrispondente");
			Assert.AreEqual(dr6_epaccyear["idacc"], "19000100010001000200010001", "Il n.conto del mov.budget è corrispondente");
			Assert.AreEqual(dr6_epaccyear["idupb"], "00010002", "L'UPB del mov.budget è corrispondente");
			Assert.AreEqual(dr6_epacc["idaccmotive"], "0001000600020004", "La causale del mov.budget è corrispondente");
            Assert.AreEqual(dr6_epacc["flagvariation"], "N", "Accertamento non di tipo variazione");
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2018, 86630, 2019, 0m);

			//CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
			var tEntrydetail = dsEP.Tables["entrydetail"];
			var rEntry = dsEP.Tables["entry"].Rows[0];
			var date_doc_colleg = new DateTime(2018, 12, 31);
			var date_contab = new DateTime(2019, 12, 31);
			Assert.AreEqual(rEntry["description"], "tasto annulla con causale di ricavo e dettagli splittati", "La descrizione della scrittura è corrispondente");
			Assert.AreEqual(rEntry["doc"], "C.A. CA_GENERICO 18/67", "La descrizione del documento collegato alla scrittura è corrispondente");
			Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
			Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");
			//PRIMO DETTAGLIO SCRITTURA
			var descr1 =
				 "Contratto Attivo CA_GENERICO 18/67dett. 4- tasto annulla con causale di ricavo e dettagli splittati";
			q filterEDetail1 = q.eq("description", descr1);
			var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1 & q.eq("idacc", "19000100010001000200010001"));
			var EntryDetail1 = EntryDetail1Rows[0];
			Assert.AreEqual(EntryDetail1["description"], descr1, "La descrizione del dettaglio della scrittura è corrispondente");
			Assert.AreEqual(EntryDetail1["idupb"], "00010002", "L'UPB del dettaglio della scrittura è corrispondente");
			Assert.AreEqual(EntryDetail1["idreg"], 10382, "Il cliente del dettaglio della scrittura è corrispondente");
			Assert.AreEqual(EntryDetail1["idaccmotive"], "0001000600020004", "La causale del dettaglio della scrittura è corrispondente");
			Assert.AreEqual(EntryDetail1["idepacc"], dr3_epacc["idepacc"]);
			Assert.AreEqual(EntryDetail1["idrelated"], dr3_epacc["idrelated"]);
			//SECONDO DETTAGLIO SCRITTURA
			var descr2 =
				"Contratto attivo CA_GENERICO n.67 / 2018 dett. 4";
			q filterEDetail2 = q.eq("description", descr2);
			var EntryDetail2Rows = tEntrydetail._Filter(filterEDetail2 & q.eq("idacc", "19000300020002000100090003"));
			var EntryDetail2 = EntryDetail2Rows[0];
			Assert.AreEqual(EntryDetail2["description"], descr2, "La descrizione del dettaglio della scrittura è corrispondente");
			Assert.AreEqual(EntryDetail2["idupb"], "00010002", "L'UPB del dettaglio della scrittura è corrispondente");
			Assert.AreEqual(EntryDetail2["idreg"], 10382, "Il cliente del dettaglio della scrittura è corrispondente");
			Assert.AreEqual(EntryDetail2["idaccmotive"], "0001000600020004", "La causale del dettaglio della scrittura è corrispondente");
			Assert.AreEqual(EntryDetail2["idepacc"], dr6_epacc["idepacc"]);
			Assert.AreEqual(EntryDetail2["idrelated"], dr6_epacc["idrelated"]);
			//TERZO DETTAGLIO SCRITTURA
			var descr3 =
				"Contratto Attivo CA_GENERICO 18/67dett. 5- tasto annulla con causale di ricavo e dettagli splittati";
			q filterEDetail3 = q.eq("description", descr3);
			var EntryDetail3Rows = tEntrydetail._Filter(filterEDetail3 & q.eq("idacc", "19000100010001000200010001"));
			var EntryDetail3 = EntryDetail3Rows[0];
			Assert.AreEqual(EntryDetail3["description"], descr3, "La descrizione del dettaglio della scrittura è corrispondente");
			Assert.AreEqual(EntryDetail3["idupb"], "00010002", "L'UPB del dettaglio della scrittura è corrispondente");
			Assert.AreEqual(EntryDetail3["idreg"], 10382, "Il cliente del dettaglio della scrittura è corrispondente");
			Assert.AreEqual(EntryDetail3["idaccmotive"], "0001000600020004", "La causale del dettaglio della scrittura è corrispondente");
			Assert.AreEqual(EntryDetail3["idepacc"], dr2_epacc["idepacc"]);
			Assert.AreEqual(EntryDetail3["idrelated"], dr2_epacc["idrelated"]);
			//QUARTO DETTAGLIO SCRITTURA
			var descr4 =
				"Contratto attivo CA_GENERICO n.67 / 2018 dett. 5";
			q filterEDetail4 = q.eq("description", descr4);
			var EntryDetail4Rows = tEntrydetail._Filter(filterEDetail4 & q.eq("idacc", "19000300020002000100090003"));
			var EntryDetail4 = EntryDetail4Rows[0];
			Assert.AreEqual(EntryDetail4["description"], descr4, "La descrizione del dettaglio della scrittura è corrispondente");
			Assert.AreEqual(EntryDetail4["idupb"], "00010002", "L'UPB del dettaglio della scrittura è corrispondente");
			Assert.AreEqual(EntryDetail4["idreg"], 10382, "Il cliente del dettaglio della scrittura è corrispondente");
			Assert.AreEqual(EntryDetail4["idaccmotive"], "0001000600020004", "La causale del dettaglio della scrittura è corrispondente");
			Assert.AreEqual(EntryDetail4["idepacc"], dr5_epacc["idepacc"]);
			Assert.AreEqual(EntryDetail4["idrelated"], dr5_epacc["idrelated"]);
            //QUINTO DETTAGLIO SCRITTURA
			var descr5 =
				"Contratto Attivo CA_GENERICO 18/67dett. 6- tasto annulla con causale di ricavo e dettagli splittati";
			q filterEDetail5 = q.eq("description", descr5);
			var EntryDetail5Rows = tEntrydetail._Filter(filterEDetail5 & q.eq("idacc", "19000100010001000200010001"));
			var EntryDetail5 = EntryDetail5Rows[0];
			Assert.AreEqual(EntryDetail5["description"], descr5, "La descrizione del dettaglio della scrittura è corrispondente");
			Assert.AreEqual(EntryDetail5["idupb"], "00010002", "L'UPB del dettaglio della scrittura è corrispondente");
			Assert.AreEqual(EntryDetail5["idreg"], 10382, "Il cliente del dettaglio della scrittura è corrispondente");
			Assert.AreEqual(EntryDetail5["idaccmotive"], "0001000600020004", "La causale del dettaglio della scrittura è corrispondente");
			Assert.AreEqual(EntryDetail5["idepacc"], dr1_epacc["idepacc"]);
			Assert.AreEqual(EntryDetail5["idrelated"], dr1_epacc["idrelated"]);
            //SESTO DETTAGLIO SCRITTURA
			var descr6 =
				"Contratto attivo CA_GENERICO n.67 / 2018 dett. 6";
			q filterEDetail6 = q.eq("description", descr6);
			var EntryDetail6Rows = tEntrydetail._Filter(filterEDetail6 & q.eq("idacc", "19000300020002000100090003"));
			var EntryDetail6 = EntryDetail6Rows[0];
			Assert.AreEqual(EntryDetail6["description"], descr6, "La descrizione del dettaglio della scrittura è corrispondente");
			Assert.AreEqual(EntryDetail6["idupb"], "00010002", "L'UPB del dettaglio della scrittura è corrispondente");
			Assert.AreEqual(EntryDetail6["idreg"], 10382, "Il cliente del dettaglio della scrittura è corrispondente");
			Assert.AreEqual(EntryDetail6["idaccmotive"], "0001000600020004", "La causale del dettaglio della scrittura è corrispondente");
			Assert.AreEqual(EntryDetail6["idepacc"], dr4_epacc["idepacc"]);
			Assert.AreEqual(EntryDetail6["idrelated"], dr4_epacc["idrelated"]);
			//CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
			Assert.AreEqual(1, dsEP.Tables["entry"]._Filter(q.eq("yentry",2019)).Length, "E' presente una scrittura nell'anno 2019");
			//CONTROLLO DETTAGLI SCRITTURA ESERCIZIO 2019
			Assert.AreEqual(6, dsEP.Tables["entrydetail"]._Filter(q.eq("nentry", rEntry["nentry"])).Length, "Sono presenti 6 dettagli relativi alla scrittura");
			var avere = (decimal)dsEP.Tables["entrydetail"]._Filter(q.gt("amount", 0) & q.eq("nentry", rEntry["nentry"])).GetSum<decimal>("amount");
			Assert.AreEqual(5000m, avere, "Avere corrispondente");
		}

		[TestMethod]
        public void Test2_estimate_2018_sostituito2019_NonCollFattura_nonIncassato()
        {
            //2018: accertamento di budget di 100, a 0 nel 2019
            //2019: impegno di 20
            //CASO esercizi anni precedenti 1d.1 //OK
            var t = new TestHelp(new DateTime(2019, 12, 31));
            q filterEst = q.eq("idestimkind", "CA_GENERICO") & q.eq("yestim", 2018) & q.eq("nestim", 40);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            DataRow rEst = tEstimate.Rows[0];
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rEst, false);
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst & q.isNull("stop"));
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreNotEqual(0, nEstDet, "Il contratto non ha dettagli annullati");

            //VERIFICO CHE LA CAUSALE DI ANNULLO SIA CORRETTA (CN1.5.01.03.008) 
            DataRow rEstimateDetail = tEstimateDetail.Rows[0];
            string attualCode = rEstimateDetail["idaccmotiveannulment"] == DBNull.Value ? "" : (string)rEstimateDetail["idaccmotiveannulment"];
            Assert.AreNotEqual("000600010005000100030008", attualCode, "Il codice della causale d'annullo è corrispondente");

            //GENERO IMPEGNI E SCRITTURE E CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);
            checkNoRules(regole);
            var dsEP = t.getEpData(t.testConn, rEst);

            bool scrittureabilitate = t.abilitaScrittureUT(rEst);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");

            //CONTROLLO VARIAZIONI AI MOVIMENTI DI BUDGET
            DataRow[] rEpaccpvar = dsEP.Tables["epaccvar"]._Filter(null);
            Assert.AreEqual(rEpaccpvar.Length, 0, "Non sono presenti variazioni");

            
            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019)).Length;
            Assert.AreEqual(0, countNepacc2019, "Non sono presenti accertamenti di budget nel 2019");
            int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
            Assert.AreEqual(1, countNepacc2018, "E' presente un accertamento di budget del 2018");

            //CONTROLLO ACCERTAMENTO DI BUDGET 
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("idepacc", 207558));
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", 207558));
            DataRow[] rEpaccyear_2018 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2018) & q.eq("idepacc", 207558));
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            DataRow dr1_epaccyear_2018 = rEpaccyear_2018[0];
            Assert.AreEqual(dr1_epacc["description"], "Sostituzione nel 2019 dettaglio senza data inizio e non incassato o contabilizzato: \r\nVERSIONE 1 con CAUSALE di COSTO CN1.5.01.03.008: NUOVA GEST\r\n", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epaccyear["amount"], 0m, "L'importo 2019 del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear_2018["amount"], 100m, "L'importo 2018 del mov.budget è corrispondente");
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"],dr1_epacc["idepacc"],2018 , 100m);
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"],dr1_epacc["idepacc"],2019 , 0m);

            Assert.AreEqual(dr1_epaccyear["idacc"], "19000100010001000100030005", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idupb"], "000100020002000700010014", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["idaccmotive"], "000700010001000100030005", "La causale del mov.budget è corrispondente");

            //CONTROLLO NUMERO IMPEGNI DI BUDGET
            int countNepexp2019 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2019)).Length;
            Assert.AreEqual(1, countNepexp2019, "E' presente un accertamento  di budget del 2019");
            int countNepexp2018 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2018)).Length;
            Assert.AreEqual(0, countNepexp2018, "Non ci sono impegni di budget del 2018");

            //CONTROLLO IMPEGNO DI BUDGET
            DataRow[] rEpexp = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2));
            DataRow[] rEpexpeyear = dsEP.Tables["epexpyear"]._Filter(q.eq("ayear", 2019));
            DataRow dr1_epexp = rEpexp[0];
            DataRow dr1_epexpyear = rEpexpeyear[0];
            Assert.AreEqual(dr1_epexp["description"], "Sostituzione nel 2019 dettaglio senza data inizio e non incassato o contabilizzato: \r\nVERSIONE 1 con CAUSALE di COSTO CN1.5.01.03.008: NUOVA GEST\r\n", "La descrizione del mov.budget  è corrispondente");
            t.checkImportoInizialeImpBudget(dsEP.Tables["epexp"],dr1_epexp["idepexp"],2019 , 20m);

            Assert.AreEqual(dr1_epexpyear["idacc"], "19000200010005000100030008", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexpyear["idupb"], "000100020002000700010014", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexp["idaccmotive"], "000600010005000100030008", "La causale del mov.budget è corrispondente");

            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            var tEntrydetail = dsEP.Tables["entrydetail"];
            var rEntry = dsEP.Tables["entry"].Rows[0];
            var date_doc_colleg = new DateTime(2018, 12, 31);
            var date_contab = new DateTime(2019, 12, 31);
            Assert.AreEqual(rEntry["description"], "Sostituzione nel 2019 dettaglio senza data inizio e non incassato o contabilizzato: \r\nVERSIONE 1 con CAUSALE di COSTO CN1.5.01.03.008: NUOVA GEST\r\n", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "C.A. CA_GENERICO 18/40", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");
            //PRIMO DETTAGLIO SCRITTURA
            var descr1 =
                 "Contratto Attivo CA_GENERICO 18/40dett. 2- Sostituzione nel 2019 dettaglio senza data inizio e non incassato o contabilizzato: \r\nVERSIONE 1 con CAUSALE di COSTO CN1.5.01.03.008: NUOVA GEST\r\n";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1);
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(EntryDetail1["description"], descr1, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idacc"], "19000200010005000100030008", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idupb"], "000100020002000700010014", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idreg"], 112552, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idaccmotive"], "000600010005000100030008", "La causale del dettaglio della scrittura è corrispondente");
            //SECONDO DETTAGLIO SCRITTURA
            var descr2 =
                "Contratto attivo CA_GENERICO n.40 / 2018 dett. 2";
            q filterEDetail2 = q.eq("description", descr2);
            var EntryDetail2Rows = tEntrydetail._Filter(filterEDetail2);
            var EntryDetail2 = EntryDetail2Rows[0];
            Assert.AreEqual(EntryDetail2["description"], descr2, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idacc"], "19000300020002000100090003", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idupb"], "000100020002000700010014", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idreg"], 112552, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idaccmotive"], "000600010005000100030008", "La causale del dettaglio della scrittura è corrispondente");

            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            Assert.AreEqual(2, dsEP.Tables["entry"]._Filter(null).Length, "Sono presenti due scritture");
            //CONTROLLO DETTAGLI SCRITTURA ESERCIZIO 2019
            Assert.AreEqual(2, dsEP.Tables["entrydetail"]._Filter(q.eq("nentry", rEntry["nentry"])).Length, "Sono presenti sette dettagli relativi alla scrittura");
            var avere = (decimal)dsEP.Tables["entrydetail"]._Filter(q.gt("amount", 0) & q.eq("nentry", rEntry["nentry"])).GetSum<decimal>("amount");
            Assert.AreEqual(20.00m, avere, "Avere corrispondente");

            //CONTROLLO CORRISPONDENZA TRA SCRITTURE E MOVIMENTO DI BUDGET
            Assert.AreEqual(EntryDetail1["idepexp"], dr1_epexp["idepexp"]);
            Assert.AreEqual(EntryDetail1["idrelated"], dr1_epexp["idrelated"]);
            Assert.AreEqual(EntryDetail2["idepacc"], dr1_epacc["idepacc"]);
            Assert.AreEqual(EntryDetail2["idrelated"], dr1_epacc["idrelated"]);
        }

        [TestMethod]
        public void Test2_estimate_2018_sostituito2019_NonCollFattura_nonIncassato2()
        {
            //2018: accertamento di 220, a zero nel 2019
            //2019: impegno di 120
            //CASO esercizi anni precedenti 1b.4 
            var t = new TestHelp(new DateTime(2019, 12, 31));
            q filterEst = q.eq("idestimkind", "CA_GENERICO") & q.eq("yestim", 2018) & q.eq("nestim", 52);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            DataRow rEst = tEstimate.Rows[0];
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rEst, false);
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst);
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreEqual(2, nEstDet, "Il contratto ha 2 dettagli");

            DataRow estimDet1 = tEstimateDetail.Rows[0];   
            // 207674
            object idepacc1 = estimDet1["idepacc"];

            DataRow estimDet2 = tEstimateDetail.Rows[1];
            object idepacc2 = estimDet2["idepacc"];
            // non esiste


            //GENERO LE SCRITTURE E CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);
            checkNoRules(regole);
            var dsEP = t.getEpData(t.testConn, rEst);

            bool scrittureabilitate = t.abilitaScrittureUT(rEst);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");

            //CONTROLLO VARIAZIONI AI MOVIMENTI DI BUDGET
            DataRow[] rEpaccpvar = dsEP.Tables["epaccvar"]._Filter(null);
            Assert.AreEqual(rEpaccpvar.Length, 0, "Non ci sono variazioni ai mov. di budget");

            //CONTROLLO NUMERO IMPEGNI DI BUDGET
            int countNepexp2019 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2019)).Length;
            Assert.AreEqual(1, countNepexp2019, "Non sono presenti impegni  di budget del 2019");
            int countNepexp2018 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2018)).Length;
            Assert.AreEqual(0, countNepexp2018, "Non ci sono impegni di budget del 2018");

            //CONTROLLO IMPEGNO DI BUDGET
            DataRow[] rEpexp = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2019) & q.eq("idepexp", 578930));
            DataRow[] rEpexpeyear = dsEP.Tables["epexpyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepexp", 578930));
            DataRow dr1_epexp = rEpexp[0];
            DataRow dr1_epexpyear = rEpexpeyear[0];
            Assert.AreEqual(dr1_epexp["description"], "Sost VERSIONE 2 con CAUSALE di costo nuova gest", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epexpyear["amount"], 120.00m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexpyear["idacc"], "19000200010005000100030008", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexpyear["idupb"], "000100030002000100010013", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexp["idaccmotive"], "000600010005000100030008", "La causale del mov.budget è corrispondente");

            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019)).Length;
            Assert.AreEqual(0, countNepacc2019, "Non ci sono accertamenti di budget del 2019");
            int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
            Assert.AreEqual(1, countNepacc2018, "Sono presenti 2 accertamenti di budget del 2018");

            //CONTROLLO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc1));
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc1));
            DataRow[] rEpaccyear_2018 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2018) & q.eq("idepacc", idepacc1));
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            DataRow dr1_epaccyear_2018 = rEpaccyear_2018[0];
            Assert.AreEqual(dr1_epacc["description"], "Sost VERSIONE 2 con CAUSALE di costo nuova gest", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epaccyear["amount"], 0m, "L'importo 2019 del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear_2018["amount"], 220m, "L'importo 2018 del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idacc"], "19000100010005000100010022", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idupb"], "000100030002000100010013", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["idaccmotive"], "000700010005000100010022", "La causale del mov.budget è corrispondente");
        
            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            var tEntrydetail = dsEP.Tables["entrydetail"];
            var rEntry = dsEP.Tables["entry"].Rows[0];
            var date_doc_colleg = new DateTime(2018, 12, 31);
            var date_contab = new DateTime(2019, 12, 31);
            Assert.AreEqual(rEntry["description"], "Sost VERSIONE 2 con CAUSALE di costo nuova gest", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "C.A. CA_GENERICO 18/52", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");
            //PRIMO DETTAGLIO SCRITTURA
            var descr1 =
                 "Contratto Attivo CA_GENERICO 18/52dett. 2- Sost VERSIONE 2 con CAUSALE di costo nuova gest";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1 & q.eq("idacc", "19000200010005000100030008"));
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(EntryDetail1["description"], descr1, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idupb"], "000100030002000100010013", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idreg"], 10382, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idaccmotive"], "000600010005000100030008", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idepexp"], dr1_epexp["idepexp"]);
            Assert.AreEqual(EntryDetail1["idrelated"], dr1_epexp["idrelated"]);
            //SECONDO DETTAGLIO SCRITTURA
            var descr2 =
                "Contratto attivo CA_GENERICO n.52 / 2018 dett. 2";
            q filterEDetail2 = q.eq("description", descr2);
            var EntryDetail2Rows = tEntrydetail._Filter(filterEDetail2 & q.eq("idacc", "19000300020002000100090003"));
            var EntryDetail2 = EntryDetail2Rows[0];
            Assert.AreEqual(EntryDetail2["description"], descr2, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idupb"], "000100030002000100010013", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idreg"], 10382, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idaccmotive"], "000600010005000100030008", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idepacc"], dr1_epacc["idepacc"]);
            Assert.AreEqual(EntryDetail2["idrelated"], dr1_epacc["idrelated"]);
            
            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            Assert.AreEqual(2, dsEP.Tables["entry"]._Filter(null).Length, "Sono presenti due scritture");
            //CONTROLLO DETTAGLI SCRITTURA ESERCIZIO 2019
            Assert.AreEqual(2, dsEP.Tables["entrydetail"]._Filter(q.eq("nentry", rEntry["nentry"])).Length, "Sono presenti 2 dettagli relativi alla scrittura");
            var avere = (decimal)dsEP.Tables["entrydetail"]._Filter(q.gt("amount", 0) & q.eq("nentry", rEntry["nentry"])).GetSum<decimal>("amount");
            Assert.AreEqual(120m, avere, "Avere corrispondente");
        }

        [TestMethod]
        public void Test2_estimate_2018_sostituito2019_NonCollFattura_nonIncassato3()
        {
            //2018: accertamento di 80,  a 0 nel 2019
            //2019: accertamento di 35 di tipo variazione
            //CASO esercizi anni precedenti 1d.3 // 
            var t = new TestHelp(new DateTime(2019, 12, 31));
            q filterEst = q.eq("idestimkind", "CA_GENERICO") & q.eq("yestim", 2018) & q.eq("nestim", 41);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            DataRow rEst = tEstimate.Rows[0];
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rEst, false);
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst);
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreNotEqual(0, nEstDet, "Il contratto non ha dettagli annullati");
            DataRow estimDet1 = tEstimateDetail.Rows[0];
            DataRow estimDet2 = tEstimateDetail.Rows[1];
            string idrelated1 = BudgetFunction.GetIdForDocument(estimDet1);
            string idrelated2 = BudgetFunction.GetIdForDocument(estimDet2);
            object idepacc1 = estimDet1["idepacc"];
            object idepacc2 = estimDet2["idepacc"];
            Assert.IsNotNull(idepacc1, "Il primo dettaglio ha accertamento di budget"); //abbiamo rimosso if  not null

            //VERIFICO CHE LA CAUSALE DI RICAVO SIA CORRETTA (CN1.5.01.03.008) 
            DataRow rEstimateDetail = tEstimateDetail.Rows[0];
            string attualCode = rEstimateDetail["idaccmotive"] == DBNull.Value ? "" : (string)rEstimateDetail["idaccmotive"];
            Assert.AreEqual("000700010001000100030005", attualCode, "Il codice della causale d'annullo è corrispondente");

            //GENERO IMPEGNI E SCRITTURE E CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);

            checkNoRules(regole);
            var dsEP = t.getEpData(t.testConn, rEst);

            bool scrittureabilitate = t.abilitaScrittureUT(rEst);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");

            //CONTROLLO VARIAZIONI AI MOVIMENTI DI BUDGET
            DataRow[] rEpaccpvar = dsEP.Tables["epaccvar"]._Filter(q.eq("yvar",2019));
            Assert.AreEqual(0, rEpaccpvar.Length,  "Non sono presenti variazioni 2019");

            DataRow[] rEpaccpvar2018 = dsEP.Tables["epaccvar"]._Filter(q.eq("yvar",2018));
            Assert.AreEqual(0, rEpaccpvar2018.Length,  "Sono presenti 0 variazioni 2018");


            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019)).Length;
            Assert.AreEqual(1, countNepacc2019, "E' presente un accertamento  di budget 2019");
            int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
            Assert.AreEqual(1, countNepacc2018, "Ci sono 1 accertamenti di budget 2018");

            
            //CONTROLLO PRIMO ACCERTAMENTO DI BUDGET 
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2)&q.eq("idepacc",idepacc1));
            Assert.AreEqual(1,rEpacc.Length,$"Esiste l'acc. di budget {idepacc1} ");
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc1));
            Assert.AreEqual(1,rEpaccyear.Length,$"Esiste l'imputazione 2019 dell'acc. di budget {idepacc1} ");
            DataRow[] rEpaccyear_2018 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2018) & q.eq("idepacc", idepacc1));


            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            DataRow dr1_epaccyear_2018 = rEpaccyear_2018[0];
            Assert.AreEqual(dr1_epacc["description"], "Sostituzione nel 2019 dettaglio senza data inizio e non incassato o contabilizzato: \r\nVERSIONE 1 con CAUSALE di ricavo CN1.5.01.03.008: NUOVA GEST\r\n", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(00m, dr1_epaccyear["amount"],  "L'importo 2019 del mov.budget è corrispondente");
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"],dr1_epacc["idepacc"],2018,  80m);
            Assert.AreEqual(dr1_epacc["yepacc"], (Int16) 2018, "Il primo accertamento è 2018");
            Assert.AreEqual(dr1_epaccyear["idacc"], "19000100010001000100030005", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idupb"], "000100010014", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["idaccmotive"], "000700010001000100030005", "La causale del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["idrelated"], idrelated1, "Primo accertamento con idrelated del 2° dettaglio");

            //CONTROLLO SECONDO ACCERTAMENTO DI BUDGET 
            DataRow[] rEpacc2 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2)&q.eq("idepacc",idepacc2));
            DataRow[] rEpaccyear2 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc",idepacc2));
            DataRow dr2_epacc = rEpacc2[0];
            DataRow dr2_epaccyear = rEpaccyear2[0];
            Assert.AreEqual(dr2_epacc["yepacc"], (Int16) 2019, "Il secondo accertamento è del 2019");
            Assert.AreEqual(dr2_epacc["description"], "Sostituzione nel 2019 dettaglio senza data inizio e non incassato o contabilizzato: \r\nVERSIONE 1 con CAUSALE di ricavo CN1.5.01.03.008: NUOVA GEST\r\n", "La descrizione del mov.budget  è corrispondente");
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"],dr2_epacc["idepacc"],2019,  35m);
            Assert.AreEqual(dr2_epaccyear["idacc"], "19000100010001000100030005", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epaccyear["idupb"], "000100010014", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epacc["idaccmotive"], "000700010001000100030005", "La causale del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epacc["idrelated"], idrelated2, "Secondo accertamento con idrelated del 2° dettaglio");


            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            var rEntry = dsEP.Tables["entry"].Rows[0];
            var tEntrydetailRows = dsEP.Tables["entrydetail"]._Filter(q.eq("yentry", 2019) & q.eq("nentry", rEntry["nentry"]));
            Assert.AreEqual(2, tEntrydetailRows.Length, "La scrittura ha due dettagli");
            var date_doc_colleg = new DateTime(2018, 12, 31);
            var date_contab = new DateTime(2019, 12, 31);
            Assert.AreEqual(rEntry["description"], "Sostituzione nel 2019 dettaglio senza data inizio e non incassato o contabilizzato: \r\nVERSIONE 1 con CAUSALE di ricavo CN1.5.01.03.008: NUOVA GEST\r\n", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "C.A. CA_GENERICO 18/41", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");

            //PRIMO DETTAGLIO SCRITTURA
            var descr1 =
                 "Contratto Attivo CA_GENERICO 18/41dett. 2- Sostituzione nel 2019 dettaglio senza data inizio e non incassato o contabilizzato: \r\nVERSIONE 1 con CAUSALE di ricavo CN1.5.01.03.008: NUOVA GEST\r\n";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetailRows._Filter(filterEDetail1).ToArray();
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(EntryDetail1["description"], descr1, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idacc"], "19000100010001000100030005", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idupb"], "000100010014", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idreg"], 112552, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idaccmotive"], "000700010001000100030005", "La causale del dettaglio della scrittura è corrispondente");

            //SECONDO DETTAGLIO SCRITTURA
            var descr2 = "Contratto attivo CA_GENERICO n.41 / 2018 dett. 2";
            q filterEDetail2 = q.eq("description", descr2);
            var EntryDetail2Rows = tEntrydetailRows._Filter(filterEDetail2).ToArray();
            var EntryDetail2 = EntryDetail2Rows[0];
            Assert.AreEqual(EntryDetail2["description"], descr2, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idacc"], "19000300020002000100090003", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idupb"], "000100010014", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idreg"], 112552, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idaccmotive"], "000700010001000100030005", "La causale del dettaglio della scrittura è corrispondente");

            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            Assert.AreEqual(2, dsEP.Tables["entry"]._Filter(null).Length, "Sono presenti due scritture");
            //CONTROLLO DETTAGLI SCRITTURA ESERCIZIO 2019
            Assert.AreEqual(2, dsEP.Tables["entrydetail"]._Filter(q.eq("nentry", rEntry["nentry"])).Length, "Sono presenti sette dettagli relativi alla scrittura");
            var avere = (decimal)dsEP.Tables["entrydetail"]._Filter(q.gt("amount", 0) & q.eq("nentry", rEntry["nentry"])).GetSum<decimal>("amount");
            Assert.AreEqual(35.00m, avere, "Avere corrispondente");

            //CONTROLLO CORRISPONDENZA TRA SCRITTURE E MOVIMENTO DI BUDGET 
            // Ambo i dettagli sono collegati al dettaglio contratto n. 1
            Assert.AreEqual(EntryDetail2["idepacc"], idepacc1,"Primo dettaglio scrittura collegato all'accertamento 2018 del primo dettaglio");

            Assert.AreEqual(idepacc1,EntryDetail2["idepacc"], "Secondo dettaglio scrittura collegato all'accertamento 2018 del primo dettaglio");
            Assert.AreEqual(idrelated1,EntryDetail2["idrelated"], "Secondo dettaglio scrittura con idrelated del primo dettaglio");
            

            //CONTROLLO CORRISPONDENZA TRA ID RELATED SCRITTURA E DETTAGLIO CONTRATTO
            Assert.AreEqual(idrelated2, EntryDetail1["idrelated"],  "Primo dettaglio scrittura con idrelated del secondo dettaglio");
            Assert.AreEqual(idepacc2,EntryDetail1["idepacc"],  "Primo dettaglio scrittura con idepacc del secondo dettaglio");
        }

        [TestMethod]
        public void Test2_estimate_2018_sostituito2019_NonCollFattura_nonIncassato4()
        {
            //2018: accertamento di 180 non incassato
            //2019: accertamento del 2018 a 0  ed uno di 130 euro nota di variazione
            //CASO esercizi anni precedenti 1d.4 
            var t = new TestHelp(new DateTime(2019, 12, 31));
            q filterEst = q.eq("idestimkind", "CA_GENERICO") & q.eq("yestim", 2018) & q.eq("nestim", 53);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            DataRow rEst = tEstimate.Rows[0];
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rEst, false);
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst);
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreEqual(2, nEstDet, "Il contratto ha 2 dettagli");

            DataRow estimDet1 = tEstimateDetail.Rows[0];
            // 207676
            object idepacc1 = estimDet1["idepacc"];
            string idrelated1 = BudgetFunction.GetIdForDocument(estimDet1);
            DataRow estimDet2 = tEstimateDetail.Rows[1];
            object idepacc2 = estimDet2["idepacc"];
            string idrelated2 = BudgetFunction.GetIdForDocument(estimDet2);
            // 207678

            //GENERO LE SCRITTURE E CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);
            checkNoRules(regole);
            var dsEP = t.getEpData(t.testConn, rEst);

            bool scrittureabilitate = t.abilitaScrittureUT(rEst);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");

            //CONTROLLO VARIAZIONI AI MOVIMENTI DI BUDGET
            DataRow[] rEpaccpvar = dsEP.Tables["epaccvar"]._Filter(null);
            Assert.AreEqual(rEpaccpvar.Length, 0, "Non ci sono variazioni ai mov. di budget");

            //CONTROLLO NUMERO IMPEGNI DI BUDGET
            int countNepexp2019 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2019)).Length;
            Assert.AreEqual(0, countNepexp2019, "Non sono presenti impegni  di budget del 2019");
            int countNepexp2018 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2018)).Length;
            Assert.AreEqual(0, countNepexp2018, "Non ci sono impegni di budget del 2018");

            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"],2018, 86548,2018,  180m);
            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019)).Length;
            Assert.AreEqual(1, countNepacc2019, "Non ci sono accertamenti di budget del 2019");
            int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
            Assert.AreEqual(1, countNepacc2018, "Sono presenti 2 accertamenti di budget del 2018");

            //CONTROLLO PRIMO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO 2019
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019) & q.eq("idepacc", idepacc2));
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc2));
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            Assert.AreEqual(dr1_epacc["description"], "Sost VERSIONE 2 con CAUSALE di ricavo nuova gest", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idacc"], "19000100010005000100010022", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idupb"], "000100030001000200010012", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["idaccmotive"], "000700010005000100010022", "La causale del mov.budget è corrispondente");
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2019, 1713, 2019, 130m);
            //CONTROLLO SECONDO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO 2018
            DataRow[] rEpacc2 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc1));
            DataRow[] rEpaccyear2 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc1));
            DataRow[] rEpaccyear2_2018 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2018) & q.eq("idepacc", idepacc1));
            DataRow dr2_epacc = rEpacc2[0];
            DataRow dr2_epaccyear = rEpaccyear2[0];
            DataRow dr2_epaccyear_2018 = rEpaccyear2_2018[0];
            Assert.AreEqual(dr2_epacc["description"], "Sost VERSIONE 2 con CAUSALE di ricavo nuova gest", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(180m,dr2_epaccyear_2018["amount"],  "L'importo del mov.budget 2018 è corrispondente");
            Assert.AreEqual(dr2_epaccyear["idacc"], "19000100010005000100010022", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epaccyear["idupb"], "000100030001000200010012", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epacc["idaccmotive"], "000700010005000100010022", "La causale del mov.budget è corrispondente");
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2018, 86548, 2019, 0m);
            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            var tEntrydetail = dsEP.Tables["entrydetail"];
            var rEntry = dsEP.Tables["entry"].Rows[0];
            var date_doc_colleg = new DateTime(2018, 12, 31);
            var date_contab = new DateTime(2019, 12, 31);
            Assert.AreEqual(rEntry["description"], "Sost VERSIONE 2 con CAUSALE di ricavo nuova gest", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "C.A. CA_GENERICO 18/53", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");
            //PRIMO DETTAGLIO SCRITTURA
            var descr1 =
                 "Contratto Attivo CA_GENERICO 18/53dett. 2- Sost VERSIONE 2 con CAUSALE di ricavo nuova gest";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1 & q.eq("idacc", "19000100010005000100010022"));
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(EntryDetail1["description"], descr1, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idupb"], "000100030001000200010012", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idreg"], 10921, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idaccmotive"], "000700010005000100010022", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idepacc"], dr1_epacc["idepacc"]);
            Assert.AreEqual(-130m,EntryDetail1["amount"] );
            Assert.AreEqual(EntryDetail1["idrelated"], idrelated2);
            //SECONDO DETTAGLIO SCRITTURA
            var descr2 =
                "Contratto attivo CA_GENERICO n.53 / 2018 dett. 2";
            q filterEDetail2 = q.eq("description", descr2);
            var EntryDetail2Rows = tEntrydetail._Filter(filterEDetail2 & q.eq("idacc", "19000300020002000100090003"));
            var EntryDetail2 = EntryDetail2Rows[0];
            Assert.AreEqual(EntryDetail2["description"], descr2, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idupb"], "000100030001000200010012", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idreg"], 10921, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idaccmotive"], "000700010005000100010022", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idepacc"], dr2_epacc["idepacc"]);
            Assert.AreEqual(EntryDetail2["idrelated"], dr2_epacc["idrelated"]);

            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            Assert.AreEqual(2, dsEP.Tables["entry"]._Filter(null).Length, "Sono presenti due scritture");
            //CONTROLLO DETTAGLI SCRITTURA ESERCIZIO 2019
            Assert.AreEqual(2, dsEP.Tables["entrydetail"]._Filter(q.eq("nentry", rEntry["nentry"])).Length, "Sono presenti 2 dettagli relativi alla scrittura");
            var avere = (decimal)dsEP.Tables["entrydetail"]._Filter(q.gt("amount", 0) & q.eq("nentry", rEntry["nentry"])).GetSum<decimal>("amount");
            Assert.AreEqual(130m, avere, "Avere corrispondente");
        }

        [TestMethod]
        public void Test2_estimate_2018_sostituito2019_NonCollFattura_nonIncassato5()
        {
            //CASO esercizi anni precedenti 1d.5 //
            //2018: Acc. di 70 portato a 60 con variazione di -10
            //2019: Acc. di 27.27 portato a 0 con variazione di -27.27 , Acc. di 0
            var t = new TestHelp(new DateTime(2019, 12, 31));
            q filterEst = q.eq("idestimkind", "CA_GENERICO") & q.eq("yestim", 2018) & q.eq("nestim", 42);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            DataRow rEst = tEstimate.Rows[0];
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rEst, false);
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst);
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreNotEqual(0, nEstDet, "Il contratto non ha dettagli annullati");

            //VERIFICO CHE LA CAUSALE DI RICAVO SIA CORRETTA (CN1.5.01.03.008) 
            DataRow rEstimateDetail = tEstimateDetail.Rows[0];
            string attualCode = rEstimateDetail["idaccmotive"] == DBNull.Value ? "" : (string)rEstimateDetail["idaccmotive"];
            Assert.AreNotEqual("000600010005000100030008", attualCode, "Il codice della causale d'annullo è corrispondente");

            //GENERO IMPEGNI E SCRITTURE E CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);
            checkNoRules(regole);
            var dsEP = t.getEpData(t.testConn, rEst);

            bool scrittureabilitate = t.abilitaScrittureUT(rEst);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");

            //CONTROLLO VARIAZIONI AI MOVIMENTI DI BUDGET DEL 2018
            DataRow[] rEpaccpvar = dsEP.Tables["epaccvar"]._Filter(q.eq("yvar",2018));
            Assert.AreEqual(rEpaccpvar.Length, 2, "Sono presenti 2 variazioni nel 2018");
            t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"],2018, 86501, -10m,2018);

            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"],2018, 86501,2018, 70m);
            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019)).Length;
            Assert.AreEqual(1, countNepacc2019, "E' presente un accertamento  di budget");
            int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
            Assert.AreEqual(1, countNepacc2018, "Ci sono 2 accertamenti di budget");

            //CONTROLLO PRIMO ACCERTAMENTO DI BUDGET 
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("idepacc", 207566));
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", 207566));
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            Assert.AreEqual(dr1_epacc["description"], "Sostituzione nel 2018 e 2019 dettaglio senza data inizio e non incassato o contabilizzato: \r\nVERSIONE 1 con CAUSALE di ricavo: NUOVA GEST\r\n", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idacc"], "19000100010005000100010022", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idupb"], "000100030007000100010098", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["idaccmotive"], "000700010005000100010022", "La causale del mov.budget è corrispondente");
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2019, 1704, 2019 ,20m);
            //CONTROLLO SECONDO ACCERTAMENTO DI BUDGET 
            DataRow[] rEpacc2 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("idepacc", 207564));
            DataRow[] rEpaccyear2 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", 207564));
            DataRow dr2_epacc = rEpacc2[0];
            DataRow dr2_epaccyear = rEpaccyear2[0];
            Assert.AreEqual(dr2_epacc["description"], "Sostituzione nel 2018 e 2019 dettaglio senza data inizio e non incassato o contabilizzato: \r\nVERSIONE 1 con CAUSALE di ricavo: NUOVA GEST\r\n", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr2_epaccyear["idacc"], "19000100010005000100010022", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epaccyear["idupb"], "000100030007000100010098", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epacc["idaccmotive"], "000700010005000100010022", "La causale del mov.budget è corrispondente");
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2018, 86501, 2019, 25m);
            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            var tEntrydetail = dsEP.Tables["entrydetail"];
            var rEntry = dsEP.Tables["entry"].Rows[0];
            var date_doc_colleg = new DateTime(2018, 12, 31);
            var date_contab = new DateTime(2019, 12, 31);
            Assert.AreEqual(rEntry["description"], "Sostituzione nel 2018 e 2019 dettaglio senza data inizio e non incassato o contabilizzato: \r\nVERSIONE 1 con CAUSALE di ricavo: NUOVA GEST\r\n", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "C.A. CA_GENERICO 18/42", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");
            //PRIMO DETTAGLIO SCRITTURA
            var descr1 =
                 "Contratto Attivo CA_GENERICO 18/42dett. 3- Sostituzione nel 2018 e 2019 dettaglio senza data inizio e non incassato o contabilizzato: \r\nVERSIONE 1 con CAUSALE di ricavo: NUOVA GEST\r\n";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1);
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(EntryDetail1["description"], descr1, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idacc"], "19000100010005000100010022", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idupb"], "000100030007000100010098", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idreg"], 112552, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idaccmotive"], "000700010005000100010022", "La causale del dettaglio della scrittura è corrispondente");
            //SECONDO DETTAGLIO SCRITTURA
            var descr2 =
                "Contratto attivo CA_GENERICO n.42 / 2018 dett. 3";
            q filterEDetail2 = q.eq("description", descr2);
            var EntryDetail2Rows = tEntrydetail._Filter(filterEDetail2);
            var EntryDetail2 = EntryDetail2Rows[0];
            Assert.AreEqual(EntryDetail2["description"], descr2, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idacc"], "19000300020002000100090003", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idupb"], "000100030007000100010098", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idreg"], 112552, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idaccmotive"], "000700010005000100010022", "La causale del dettaglio della scrittura è corrispondente");

            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            Assert.AreEqual(2, dsEP.Tables["entry"]._Filter(null).Length, "Sono presenti due scritture");
            //CONTROLLO DETTAGLI SCRITTURA ESERCIZIO 2019
            Assert.AreEqual(2, dsEP.Tables["entrydetail"]._Filter(q.eq("nentry", rEntry["nentry"])).Length, "Sono presenti sette dettagli relativi alla scrittura");
            var avere = (decimal)dsEP.Tables["entrydetail"]._Filter(q.gt("amount", 0) & q.eq("nentry", rEntry["nentry"])).GetSum<decimal>("amount");
            Assert.AreEqual(20.00m, avere, "Avere corrispondente");

            //CONTROLLO CORRISPONDENZA TRA ID RELATED SCRITTURA E DETTAGLIO CONTRATTO
            Assert.AreEqual(EntryDetail1["idepacc"], dr1_epacc["idepacc"]);
            string idrelated = (string)EntryDetail1["idrelated"];
            string name = idrelated.Split('§')[1];
            string year = idrelated.Split('§')[2];
            string number = idrelated.Split('§')[3];
            string rownumN = idrelated.Split('§')[4];
            q filterEst2 = q.eq("idestimkind", name) & q.eq("yestim", year) & q.eq("nestim", number) & q.eq("rownum", rownumN);
            DataTable tEstimateDetailcoll = t.testConn.readTable("estimatedetail", filterEst2);
            Assert.AreNotEqual(tEstimateDetailcoll.Rows.Count, 0, "Esiste un dettaglio collegato alla scrittura con quel idrelated");
            var EpaccColl = dsEP.Tables["epacc"]._Filter(q.eq("idepacc", tEstimateDetailcoll.Rows[0]["idepacc"]));
            Assert.AreEqual(EntryDetail1["idrelated"], EpaccColl[0]["idrelated"]);

            //CONTROLLO CORRISPONDENZA TRA SCRITTURE E MOVIMENTO DI BUDGET
            Assert.AreEqual(EntryDetail2["idepacc"], dr2_epacc["idepacc"]);
            Assert.AreEqual(EntryDetail2["idrelated"], dr2_epacc["idrelated"]);
        }

        [TestMethod]
        public void Test2_estimate_2018_sostituito2019_NonCollFattura_nonIncassato7()
        {
            //CASO esercizi anni precedenti 1d.7 
            //2018: 
            //2019:
            var t = new TestHelp(new DateTime(2019, 12, 31));
            q filterEst = q.eq("idestimkind", "CA_GENERICO") & q.eq("yestim", 2018) & q.eq("nestim", 57);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            DataRow rEst = tEstimate.Rows[0];
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rEst, false);
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst);
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreEqual(3, nEstDet, "Il contratto ha 3 dettagli");

            DataRow estimDet1 = tEstimateDetail.Rows[0];
            // 207706
            object idepacc1 = estimDet1["idepacc"];

            //GENERO LE SCRITTURE E CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);
            checkNoRules(regole);
            var dsEP = t.getEpData(t.testConn, rEst);

            bool scrittureabilitate = t.abilitaScrittureUT(rEst);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");

            //CONTROLLO VARIAZIONI AI MOVIMENTI DI BUDGET
            t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"],2018,86561,  -50m,2018);

            //CONTROLLO NUMERO IMPEGNI DI BUDGET
            int countNepexp2019 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2019)).Length;
            Assert.AreEqual(1, countNepexp2019, "Non sono presenti impegni  di budget del 2019");
            int countNepexp2018 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2018)).Length;
            Assert.AreEqual(0, countNepexp2018, "Non ci sono impegni di budget del 2018");

            //CONTROLLO IMPEGNO DI BUDGET
            DataRow[] rEpexp = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2019) & q.eq("idepexp", 578934));
            DataRow[] rEpexpeyear = dsEP.Tables["epexpyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepexp", 578934));
            DataRow dr1_epexp = rEpexp[0];
            DataRow dr1_epexpyear = rEpexpeyear[0];
            Assert.AreEqual(dr1_epexp["description"], "VERSIONE 3 con CAUSALE di RICAVO (dettaglio sostituito prima nel 2018 e poi nel 2019) ", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epexpyear["amount"], 70.00m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexpyear["idacc"], "19000200010005000100030008", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexpyear["idupb"], "000100030001000200010069", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexp["idaccmotive"], "000600010005000100030008", "La causale del mov.budget è corrispondente");

            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"],2018, 86561, 2018, 200m);
            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019)).Length;
            Assert.AreEqual(0, countNepacc2019, "Non ci sono accertamenti di budget del 2019");
            int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
            Assert.AreEqual(1, countNepacc2018, "Sono presenti 2 accertamenti di budget del 2018");

            //CONTROLLO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc1));
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc1));
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            Assert.AreEqual(dr1_epacc["description"], "VERSIONE 3 con CAUSALE di RICAVO (dettaglio sostituito prima nel 2018 e poi nel 2019) ", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epaccyear["amount"], 0.00m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idacc"], "19000100010001000100030005", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idupb"], "000100030001000200010069", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["idaccmotive"], "000700010001000100030005", "La causale del mov.budget è corrispondente");

            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            var tEntrydetail = dsEP.Tables["entrydetail"];
            var rEntry = dsEP.Tables["entry"].Rows[0];
            var date_doc_colleg = new DateTime(2018, 12, 31);
            var date_contab = new DateTime(2019, 12, 31);
            Assert.AreEqual(rEntry["description"], "VERSIONE 3 con CAUSALE di RICAVO (dettaglio sostituito prima nel 2018 e poi nel 2019) CA_GENERICO /2018", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "C.A. CA_GENERICO 18/57", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");
            //PRIMO DETTAGLIO SCRITTURA
            var descr1 =
                 "Contratto Attivo CA_GENERICO 18/57dett. 3- VERSIONE 3 con CAUSALE di RICAVO (dettaglio sostituito prima nel 2018 e poi nel 2019) ";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1 & q.eq("idacc", "19000200010005000100030008"));
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(EntryDetail1["description"], descr1, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idupb"], "000100030001000200010069", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idreg"], 40057, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idaccmotive"], "000600010005000100030008", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idepexp"], dr1_epexp["idepexp"]);
            Assert.AreEqual(EntryDetail1["idrelated"], dr1_epexp["idrelated"]);
            //SECONDO DETTAGLIO SCRITTURA
            var descr2 =
                "Contratto attivo CA_GENERICO n.57 / 2018 dett. 3";
            q filterEDetail2 = q.eq("description", descr2);
            var EntryDetail2Rows = tEntrydetail._Filter(filterEDetail2 & q.eq("idacc", "19000300020002000100090003"));
            var EntryDetail2 = EntryDetail2Rows[0];
            Assert.AreEqual(EntryDetail2["description"], descr2, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idupb"], "000100030001000200010069", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idreg"], 40057, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idaccmotive"], "000600010005000100030008", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idepacc"], dr1_epacc["idepacc"]);
            Assert.AreEqual(EntryDetail2["idrelated"], dr1_epacc["idrelated"]);

            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            Assert.AreEqual(2, dsEP.Tables["entry"]._Filter(null).Length, "Sono presenti due scritture");
            //CONTROLLO DETTAGLI SCRITTURA ESERCIZIO 2019
            Assert.AreEqual(2, dsEP.Tables["entrydetail"]._Filter(q.eq("nentry", rEntry["nentry"])).Length, "Sono presenti 2 dettagli relativi alla scrittura");
            var avere = (decimal)dsEP.Tables["entrydetail"]._Filter(q.gt("amount", 0) & q.eq("nentry", rEntry["nentry"])).GetSum<decimal>("amount");
            Assert.AreEqual(70m, avere, "Avere corrispondente");
        }

        [TestMethod]
        public void Test2_estimate_2018_sostituito2019_NonCollFattura_parzaccert()
        {
            //2018: un accertamento di 50 passato a 30 ed un altro di 20
            //2019 un impegno di 20 e dei due acc. di prima uno non esiste l'altro è a zero
            //CASO esercizi anni precedenti 1e.1 // OK
            var t = new TestHelp(new DateTime(2019, 12, 31));
            q filterEst = q.eq("idestimkind", "CA_GENERICO") & q.eq("yestim", 2018) & q.eq("nestim", 43);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            DataRow rEst = tEstimate.Rows[0];
            t.binaryCopyEp(rEst, false);
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst);
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreNotEqual(0, nEstDet, "Il contratto non ha dettagli annullati");
            
            //VERIFICO CHE LA CAUSALE DI RICAVO SIA CORRETTA (CP1.1.01.03.005) 
            DataRow rEstimateDetail = tEstimateDetail.Rows[0];
            string attualCode = rEstimateDetail["idaccmotive"] == DBNull.Value ? "" : (string)rEstimateDetail["idaccmotive"];
            Assert.AreEqual("000700010001000100030005", attualCode, "Il codice della causale di ricavo è corrispondente");

            //GENERO IMPEGNI E SCRITTURE E CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);
            checkNoRules(regole);
            var dsEP = t.getEpData(t.testConn, rEst);

            bool scrittureabilitate = t.abilitaScrittureUT(rEst);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");

            //CONTROLLO VARIAZIONI AI MOVIMENTI DI BUDGET 2018
            t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"],2018, 86502, -20m, 2018);

            //CONTROLLO NUMERO IMPEGNI DI BUDGET
            int countNepexp2019 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2019)).Length;
            Assert.AreEqual(1, countNepexp2019, "E' presente un accertamento  di budget");
            int countNepexp2018 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2018)).Length;
            Assert.AreEqual(0, countNepexp2018, "Non ci sono impegni di budget del 2018");

            //CONTROLLO IMPEGNO DI BUDGET
            DataRow[] rEpexp = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2));
            DataRow[] rEpexpeyear = dsEP.Tables["epexpyear"]._Filter(q.eq("ayear", 2019));
            DataRow dr1_epexp = rEpexp[0];
            DataRow dr1_epexpyear = rEpexpeyear[0];
            Assert.AreEqual(dr1_epexp["description"], "Sostituzione nel 2019 dettaglio senza data parzialmente accertato/incassato", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epexpyear["amount"], 20.00m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexpyear["idacc"], "19000200010005000100030008", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexpyear["idupb"], "000100020003000200010005", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexp["idaccmotive"], "000600010005000100030008", "La causale del mov.budget è corrispondente");

            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"],2018, 86503, 2018,20m);
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"],2018, 86502, 2018,50m);

            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019)).Length;
            Assert.AreEqual(0, countNepacc2019, "E' presente un accertamento  di budget");
            int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
            Assert.AreEqual(2, countNepacc2018, "Ci sono 2 accertamenti di budget nel 2018");

            //CONTROLLO PRIMO ACCERTAMENTO DI BUDGET
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase",2) & q.eq("yepacc", 2018) & q.eq("idepacc", 207570));
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", 207570));
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            Assert.AreEqual(dr1_epacc["description"], "Sostituzione nel 2019 dettaglio senza data parzialmente accertato/incassato", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epaccyear["amount"],0m, "L'importo del mov.budget 2019 è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idacc"], "19000100010001000100030005", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idupb"], "000100020003000200010005", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["idaccmotive"], "000700010001000100030005", "La causale del mov.budget è corrispondente");

            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            var tEntrydetail = dsEP.Tables["entrydetail"];
            var rEntry = dsEP.Tables["entry"].Rows[0];
            var date_doc_colleg = new DateTime(2018, 12, 31);
            var date_contab = new DateTime(2019, 12, 31);
            Assert.AreEqual(rEntry["description"], "Sostituzione nel 2019 dettaglio senza data parzialmente accertato/incassato", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "C.A. CA_GENERICO 18/43", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");
            //PRIMO DETTAGLIO SCRITTURA
            var descr1 =
                 "Contratto Attivo CA_GENERICO 18/43dett. 4- Sostituzione nel 2019 dettaglio senza data parzialmente accertato/incassato";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1);
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(EntryDetail1["description"], descr1, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idacc"], "19000200010005000100030008", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idupb"], "000100020003000200010005", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idreg"], 10382, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idaccmotive"], "000600010005000100030008", "La causale del dettaglio della scrittura è corrispondente");
            //SECONDO DETTAGLIO SCRITTURA
            var descr2 =
                "Contratto attivo CA_GENERICO n.43 / 2018 dett. 4";
            q filterEDetail2 = q.eq("description", descr2);
            var EntryDetail2Rows = tEntrydetail._Filter(filterEDetail2);
            var EntryDetail2 = EntryDetail2Rows[0];
            Assert.AreEqual(EntryDetail2["description"], descr2, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idacc"], "19000300020002000100090003", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idupb"], "000100020003000200010005", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idreg"], 10382, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idaccmotive"], "000600010005000100030008", "La causale del dettaglio della scrittura è corrispondente");

            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            Assert.AreEqual(2, dsEP.Tables["entry"]._Filter(null).Length, "Sono presenti due scritture");
            //CONTROLLO DETTAGLI SCRITTURA ESERCIZIO 2019
            Assert.AreEqual(2, dsEP.Tables["entrydetail"]._Filter(q.eq("nentry", rEntry["nentry"])).Length, "Sono presenti sette dettagli relativi alla scrittura");
            var avere = (decimal)dsEP.Tables["entrydetail"]._Filter(q.gt("amount", 0) & q.eq("nentry", rEntry["nentry"])).GetSum<decimal>("amount");
            Assert.AreEqual(20.00m, avere, "Avere corrispondente");


            //CONTROLLO CORRISPONDENZA TRA SCRITTURE E MOVIMENTO DI BUDGET
            Assert.AreEqual(EntryDetail1["idepexp"], dr1_epexp["idepexp"]);
            Assert.AreEqual(EntryDetail1["idrelated"], dr1_epexp["idrelated"]);
            Assert.AreEqual(EntryDetail2["idepacc"], dr1_epacc["idepacc"]);
            Assert.AreEqual(EntryDetail2["idrelated"], dr1_epacc["idrelated"]);
        }

        [TestMethod]
        public void Test2_estimate_2018_sostituito2019_NonCollFattura_parzaccert2()
        {
            //2018: due accertamenti di budget, uno di 300 ridotto a 100 l'altro di 200
            //2019: i due accertamenti di prima sono a zero più un impegno di 100
            //CASO esercizi anni precedenti 1d.4 
            var t = new TestHelp(new DateTime(2019, 12, 31));
            q filterEst = q.eq("idestimkind", "CA_GENERICO") & q.eq("yestim", 2018) & q.eq("nestim", 55);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            DataRow rEst = tEstimate.Rows[0];
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rEst, false);
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst);
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreEqual(4, nEstDet, "Il contratto ha 4 dettagli");

            DataRow estimDet1 = tEstimateDetail.Rows[0];
            //207682
            object idepacc1 = estimDet1["idepacc"];
            DataRow estimDet2 = tEstimateDetail.Rows[1];
            //207684
            object idepacc2 = estimDet2["idepacc"];
           
            //GENERO LE SCRITTURE E CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);
            checkNoRules(regole);
            var dsEP = t.getEpData(t.testConn, rEst);

            bool scrittureabilitate = t.abilitaScrittureUT(rEst);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");

            //CONTROLLO VARIAZIONI AI MOVIMENTI DI BUDGET
            t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"],2018, 86550, -200m,2018);

            //CONTROLLO NUMERO IMPEGNI DI BUDGET
            int countNepexp2019 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2019)).Length;
            Assert.AreEqual(1, countNepexp2019, "Non sono presenti impegni  di budget del 2019");
            int countNepexp2018 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2018)).Length;
            Assert.AreEqual(0, countNepexp2018, "Non ci sono impegni di budget del 2018");

            //CONTROLLO IMPEGNO DI BUDGET
            DataRow[] rEpexp = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2019) & q.eq("idepexp", 578932));
            DataRow[] rEpexpeyear = dsEP.Tables["epexpyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepexp", 578932));
            DataRow dr1_epexp = rEpexp[0];
            DataRow dr1_epexpyear = rEpexpeyear[0];
            Assert.AreEqual(dr1_epexp["description"], "sost vERSIONE 2 con CAUSALE di COSTO CN1.5.01.03.008nuova gest, contabilizzato parzialmente", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epexpyear["amount"], 100.00m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexpyear["idacc"], "19000200010005000100030008", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexpyear["idupb"], "000100030005000100010020", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexp["idaccmotive"], "000600010005000100030008", "La causale del mov.budget è corrispondente");

            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"],2018, 86551,2018,  200m);
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"],2018, 86550,2018,  300m);
            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019)).Length;
            Assert.AreEqual(0, countNepacc2019, "Non ci sono accertamenti di budget del 2019");
            int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
            Assert.AreEqual(2, countNepacc2018, "Sono presenti 2 accertamenti di budget del 2018");

            //CONTROLLO PRIMO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO 2019
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc2));
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc2));
            DataRow[] rEpaccyear2018 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2018) & q.eq("idepacc", idepacc2));
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            DataRow dr1_epaccyear2018 = rEpaccyear2018[0];
            Assert.AreEqual(dr1_epacc["description"], "sost vERSIONE 2 con CAUSALE di COSTO CN1.5.01.03.008nuova gest, contabilizzato parzialmente", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(0m, dr1_epaccyear["amount"],  "L'importo del mov.budget 2019 è corrispondente");
            Assert.AreEqual(200m, dr1_epaccyear2018["amount"], "L'importo del mov.budget 2019 è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idacc"], "19000100010005000100020003", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idupb"], "000100030005000100010020", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["idaccmotive"], "000700010005000100020003", "La causale del mov.budget è corrispondente");

            //CONTROLLO SECONDO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO 2018
            DataRow[] rEpacc2 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc1));
            DataRow[] rEpaccyear2 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc1));
            DataRow[] rEpaccyear2_2018 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2018) & q.eq("idepacc", idepacc1));
            DataRow dr2_epacc = rEpacc2[0];
            DataRow dr2_epaccyear = rEpaccyear2[0];
            DataRow dr2_epaccyear_2018 = rEpaccyear2_2018[0];
            Assert.AreEqual(dr2_epacc["description"], "sost vERSIONE 2 con CAUSALE di COSTO CN1.5.01.03.008nuova gest, contabilizzato parzialmente", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr2_epaccyear["amount"], 0.00m, "L'importo del mov.budget 2019 è corrispondente");
            Assert.AreEqual(dr2_epaccyear_2018["amount"],300m, "L'importo del mov.budget 2018 è corrispondente");
            Assert.AreEqual(dr2_epaccyear["idacc"], "19000100010005000100020003", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epaccyear["idupb"], "000100030005000100010020", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epacc["idaccmotive"], "000700010005000100020003", "La causale del mov.budget è corrispondente");

            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            var tEntrydetail = dsEP.Tables["entrydetail"];
            var rEntry = dsEP.Tables["entry"].Rows[0];
            var date_doc_colleg = new DateTime(2018, 12, 31);
            var date_contab = new DateTime(2019, 12, 31);
            Assert.AreEqual(rEntry["description"], "sost vERSIONE 2 con CAUSALE di COSTO CN1.5.01.03.008nuova gest, contabilizzato parzialmente", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "C.A. CA_GENERICO 18/55", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");
            //PRIMO DETTAGLIO SCRITTURA
            var descr1 =
                 "Contratto Attivo CA_GENERICO 18/55dett. 4- sost vERSIONE 2 con CAUSALE di COSTO CN1.5.01.03.008nuova gest, contabilizzato parzialmente";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1 & q.eq("idacc", "19000200010005000100030008"));
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(EntryDetail1["description"], descr1, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idupb"], "000100030005000100010020", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idreg"], 9173, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idaccmotive"], "000600010005000100030008", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idepexp"], dr1_epexp["idepexp"]);
            Assert.AreEqual(EntryDetail1["idrelated"], dr1_epexp["idrelated"]);
            //SECONDO DETTAGLIO SCRITTURA
            var descr2 =
                "Contratto attivo CA_GENERICO n.55 / 2018 dett. 4";
            q filterEDetail2 = q.eq("description", descr2);
            var EntryDetail2Rows = tEntrydetail._Filter(filterEDetail2 & q.eq("idacc", "19000300020002000100090003"));
            var EntryDetail2 = EntryDetail2Rows[0];
            Assert.AreEqual(EntryDetail2["description"], descr2, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idupb"], "000100030005000100010020", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idreg"], 9173, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idaccmotive"], "000600010005000100030008", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idepacc"], dr1_epacc["idepacc"]);
            Assert.AreEqual(EntryDetail2["idrelated"], dr1_epacc["idrelated"]);

            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            Assert.AreEqual(2, dsEP.Tables["entry"]._Filter(null).Length, "Sono presenti due scritture");
            //CONTROLLO DETTAGLI SCRITTURA ESERCIZIO 2019
            Assert.AreEqual(2, dsEP.Tables["entrydetail"]._Filter(q.eq("nentry", rEntry["nentry"])).Length, "Sono presenti 2 dettagli relativi alla scrittura");
            var avere = (decimal)dsEP.Tables["entrydetail"]._Filter(q.gt("amount", 0) & q.eq("nentry", rEntry["nentry"])).GetSum<decimal>("amount");
            Assert.AreEqual(100m, avere, "Avere corrispondente");
        }

        [TestMethod]
        public void Test2_estimate_2018_sostituito2019_NonCollFattura_parzaccert3()
        {
            //Accertamento 2019 di 10 euro
            //2 Accertamenti 2018 :
            // uno di 100 diminuito a 85 , a zero nel 2019
            // uno di 15 , a zero nel 2019
            //CASO esercizi anni precedenti 1e.2 // ok
            var t = new TestHelp(new DateTime(2019, 12, 31));
            q filterEst = q.eq("idestimkind", "CA_GENERICO") & q.eq("yestim", 2018) & q.eq("nestim", 46);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            DataRow rEst = tEstimate.Rows[0];
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rEst, false);

            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst);
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreNotEqual(0, nEstDet, "Il contratto non ha dettagli annullati");
            
            //VERIFICO CHE LA CAUSALE DI RICAVO SIA CORRETTA (CP1.1.01.03.005) 
            DataRow rEstimateDetail = tEstimateDetail.Rows[0];
            string attualCode = rEstimateDetail["idaccmotive"] == DBNull.Value ? "" : (string)rEstimateDetail["idaccmotive"];
            Assert.AreEqual("000700010001000100030005", attualCode, "Il codice della causale di ricavo è corrispondente");

            //GENERO IMPEGNI E SCRITTURE E CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);
            checkNoRules(regole);
            var dsEP = t.getEpData(t.testConn, rEst);

            bool scrittureabilitate = t.abilitaScrittureUT(rEst);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");

            //CONTROLLO VARIAZIONI AI MOVIMENTI DI BUDGET 2018
            t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"],2018, 86509, -15m, 2018);

            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"],2018, 86510, 2018, 15m);
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"],2018, 86509,2018,  100m);
            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019)).Length;
            Assert.AreEqual(1, countNepacc2019, "E' presente un accertamento  di budget 2019");
            int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
            Assert.AreEqual(2, countNepacc2018, "Ci sono 2 accertamenti di budget 2018");

            //CONTROLLO ACCERTAMENTO DI BUDGET (ANNO 2019)
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019) & q.eq("idepacc", 207586));
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", 207586));
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            Assert.AreEqual(dr1_epacc["description"], "sostituzione CA contabilizzato veRSIONE 1 con CAUSALE di RICAVO NUOVA GEST", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epaccyear["amount"], 10.00m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idacc"], "19000100010001000100030005", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idupb"], "000100020003000300010014", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["idaccmotive"], "000700010001000100030005", "La causale del mov.budget è corrispondente");

            //CONTROLLO ACCERTAMENTO DI BUDGET (ANNO 2018)
            DataRow[] rEpacc2 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", 207584));
            DataRow[] rEpaccyear2 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", 207584));
            DataRow[] rEpaccyear2_2018 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2018) & q.eq("idepacc", 207584)).ToArray();
            DataRow dr2_epacc = rEpacc2[0];
            DataRow dr2_epaccyear = rEpaccyear2[0];
            Assert.AreEqual(dr2_epacc["description"], "sostituzione CA contabilizzato veRSIONE 1 con CAUSALE di RICAVO NUOVA GEST", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr2_epaccyear["amount"], 00m, "L'importo 2019 del mov.budget è corrispondente");
            Assert.AreEqual(rEpaccyear2_2018[0]["amount"], 15M, "L'importo 2018 del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epaccyear["idacc"], "19000100010001000100030005", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epaccyear["idupb"], "000100020003000300010014", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epacc["idaccmotive"], "000700010001000100030005", "La causale del mov.budget è corrispondente");

            var tEntrydetail = dsEP.Tables["entrydetail"];
            var rEntry = dsEP.Tables["entry"].Rows[0];
            var date_doc_colleg = new DateTime(2018, 12, 31);
            var date_contab = new DateTime(2019, 12, 31);
            Assert.AreEqual(rEntry["description"], "sostituzione CA contabilizzato veRSIONE 1 con CAUSALE di RICAVO NUOVA GEST", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "C.A. CA_GENERICO 18/46", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");
            //PRIMO DETTAGLIO SCRITTURA
            var descr1 =
                 "Contratto Attivo CA_GENERICO 18/46dett. 4- sostituzione CA contabilizzato veRSIONE 1 con CAUSALE di RICAVO NUOVA GEST";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1);
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(EntryDetail1["description"], descr1, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idacc"], "19000100010001000100030005", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idupb"], "000100020003000300010014", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idreg"], 112387, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idaccmotive"], "000700010001000100030005", "La causale del dettaglio della scrittura è corrispondente");
            //SECONDO DETTAGLIO SCRITTURA
            var descr2 =
                "Contratto attivo CA_GENERICO n.46 / 2018 dett. 4";
            q filterEDetail2 = q.eq("description", descr2);
            var EntryDetail2Rows = tEntrydetail._Filter(filterEDetail2);
            var EntryDetail2 = EntryDetail2Rows[0];
            Assert.AreEqual(EntryDetail2["description"], descr2, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idacc"], "19000300020002000100090003", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idupb"], "000100020003000300010014", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idreg"], 112387, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idaccmotive"], "000700010001000100030005", "La causale del dettaglio della scrittura è corrispondente");

            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            Assert.AreEqual(2, dsEP.Tables["entry"]._Filter(null).Length, "Sono presenti due scritture");
            //CONTROLLO DETTAGLI SCRITTURA ESERCIZIO 2019
            Assert.AreEqual(2, dsEP.Tables["entrydetail"]._Filter(q.eq("nentry", rEntry["nentry"])).Length, "Sono presenti sette dettagli relativi alla scrittura");
            var avere = (decimal)dsEP.Tables["entrydetail"]._Filter(q.gt("amount", 0) & q.eq("nentry", rEntry["nentry"])).GetSum<decimal>("amount");
            Assert.AreEqual(10m, avere, "Avere corrispondente");

            //CONTROLLO CORRISPONDENZA TRA ID RELATED SCRITTURA E DETTAGLIO CONTRATTO
            Assert.AreEqual(EntryDetail1["idepacc"], dr1_epacc["idepacc"]);
            string idrelated = (string)EntryDetail1["idrelated"];
            string name = idrelated.Split('§')[1];
            string year = idrelated.Split('§')[2];
            string number = idrelated.Split('§')[3];
            string rownumN = idrelated.Split('§')[4];
            q filterEst2 = q.eq("idestimkind", name) & q.eq("yestim", year) & q.eq("nestim", number) & q.eq("rownum", rownumN);
            DataTable tEstimateDetailcoll = t.testConn.readTable("estimatedetail", filterEst2);
            Assert.AreNotEqual(tEstimateDetailcoll.Rows.Count, 0, "Esiste un dettaglio collegato alla scrittura con quel idrelated");
            var EpaccColl = dsEP.Tables["epacc"]._Filter(q.eq("idepacc", tEstimateDetailcoll.Rows[0]["idepacc"]));
            Assert.AreEqual(EntryDetail1["idrelated"], EpaccColl[0]["idrelated"]);

            //CONTROLLO CORRISPONDENZA TRA SCRITTURE E MOVIMENTO DI BUDGET
            Assert.AreEqual(EntryDetail2["idepacc"], dr2_epacc["idepacc"]);
            Assert.AreEqual(EntryDetail2["idrelated"], dr2_epacc["idrelated"]);
        }

        [TestMethod]
        public void Test2_estimate_2018_sostituito2019_NonCollFattura_parzaccert4()
        {
            //Due accertamenti a zero nel 2019 ed un acc. di budget di tipo variazione di 30
            //Nel 2018 uno è di 140 diminuito a 90 l'altro di 50
            //CASO esercizi anni precedenti 1d.4 
            var t = new TestHelp(new DateTime(2019, 12, 31));
            q filterEst = q.eq("idestimkind", "CA_GENERICO") & q.eq("yestim", 2018) & q.eq("nestim", 56);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            DataRow rEst = tEstimate.Rows[0];
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rEst, false);
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst);
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreEqual(4, nEstDet, "Il contratto ha 4 dettagli");

            DataRow estimDet1 = tEstimateDetail.Rows[0];
            //207712 86563
            object idepacc1 = estimDet1["idepacc"];
            DataRow estimDet2 = tEstimateDetail.Rows[1];
            //207714  86564
            object idepacc2 = estimDet2["idepacc"];


            //GENERO LE SCRITTURE E CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);
            checkNoRules(regole);
                
            var dsEP = t.getEpData(t.testConn, rEst);

            bool scrittureabilitate = t.abilitaScrittureUT(rEst);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");

            t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"],2018, 86552, -50m, 2018);

            //CONTROLLO NUMERO IMPEGNI DI BUDGET
            int countNepexp2019 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2019)).Length;
            Assert.AreEqual(0, countNepexp2019, "Non sono presenti impegni  di budget del 2019");
            int countNepexp2018 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2018)).Length;
            Assert.AreEqual(0, countNepexp2018, "Non ci sono impegni di budget del 2018");

            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"],2018, 86553, 2018, 50m);
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"],2018, 86552,2018,  140m);
            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019)).Length;
            Assert.AreEqual(1, countNepacc2019, "Non ci sono accertamenti di budget del 2019");
            int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
            Assert.AreEqual(2, countNepacc2018, "Sono presenti 2 accertamenti di budget del 2018");

            //CONTROLLO PRIMO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO 2019
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019) & q.eq("idepacc", 207690));
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", 207690));
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            Assert.AreEqual(dr1_epacc["description"], "sost vERSIONE 2 con CAUSALE di ricavo nuova gest, contabilizzato parzialmente", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epaccyear["amount"], 30m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idacc"], "19000100010001000100030005", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idupb"], "000100030001000200010010", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["idaccmotive"], "000700010001000100030005", "La causale del mov.budget è corrispondente");

            //CONTROLLO SECONDO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO 2018
            DataRow[] rEpacc2 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", 207688));
            DataRow[] rEpaccyear2 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", 207688));
            DataRow dr2_epacc = rEpacc2[0];
            DataRow dr2_epaccyear = rEpaccyear2[0];
            Assert.AreEqual(dr2_epacc["description"], "sost vERSIONE 2 con CAUSALE di ricavo nuova gest, contabilizzato parzialmente", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr2_epaccyear["amount"], 0m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epaccyear["idacc"], "19000100010001000100030005", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epaccyear["idupb"], "000100030001000200010010", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epacc["idaccmotive"], "000700010001000100030005", "La causale del mov.budget è corrispondente");

            //CONTROLLO TERZO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO 2018
            DataRow[] rEpacc3 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", 207686));
            DataRow[] rEpaccyear3 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", 207686));
            DataRow dr3_epacc = rEpacc3[0];
            DataRow dr3_epaccyear = rEpaccyear3[0];
            Assert.AreEqual(dr3_epacc["description"], "sost vERSIONE 2 con CAUSALE di ricavo nuova gest, contabilizzato parzialmente", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr3_epaccyear["amount"], 0.00m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr3_epaccyear["idacc"], "19000100010001000100030005", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr3_epaccyear["idupb"], "000100030001000200010010", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr3_epacc["idaccmotive"], "000700010001000100030005", "La causale del mov.budget è corrispondente");

            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            var tEntrydetail = dsEP.Tables["entrydetail"];
            var rEntry = dsEP.Tables["entry"].Rows[0];
            var date_doc_colleg = new DateTime(2018, 12, 31);
            var date_contab = new DateTime(2019, 12, 31);
            Assert.AreEqual(rEntry["description"], "sost vERSIONE 2 con CAUSALE di ricavo nuova gest, contabilizzato parzialmente", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "C.A. CA_GENERICO 18/56", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");
            //PRIMO DETTAGLIO SCRITTURA
            var descr1 =
                 "Contratto Attivo CA_GENERICO 18/56dett. 4- sost vERSIONE 2 con CAUSALE di ricavo nuova gest, contabilizzato parzialmente";
            q filterEDetail1 = q.eq("description", descr1)& q.eq("yentry",2019);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1 & q.eq("idacc", "19000100010001000100030005"));
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(EntryDetail1["description"], descr1, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idupb"], "000100030001000200010010", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idreg"], 112552, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idaccmotive"], "000700010001000100030005", "La causale del dettaglio della scrittura è corrispondente");
            //SECONDO DETTAGLIO SCRITTURA
            var descr2 =
                "Contratto attivo CA_GENERICO n.56 / 2018 dett. 4";
            q filterEDetail2 = q.eq("description", descr2)& q.eq("yentry",2019);
            var EntryDetail2Rows = tEntrydetail._Filter(filterEDetail2 & q.eq("idacc", "19000300020002000100090003"));
            var EntryDetail2 = EntryDetail2Rows[0];
            Assert.AreEqual(EntryDetail2["description"], descr2, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idupb"], "000100030001000200010010", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idreg"], 112552, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idaccmotive"], "000700010001000100030005", "La causale del dettaglio della scrittura è corrispondente");
            
            Assert.AreEqual(EntryDetail2["idrelated"], dr2_epacc["idrelated"]);         

            Assert.AreEqual(EntryDetail1["idepacc"], dr1_epacc["idepacc"]);
            Assert.AreEqual(EntryDetail2["idepacc"], dr2_epacc["idepacc"]);


            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            Assert.AreEqual(2, dsEP.Tables["entry"]._Filter(null).Length, "Sono presenti due scritture");
            //CONTROLLO DETTAGLI SCRITTURA ESERCIZIO 2019
            Assert.AreEqual(2, dsEP.Tables["entrydetail"]._Filter(q.eq("nentry", rEntry["nentry"])).Length, "Sono presenti 2 dettagli relativi alla scrittura");
            var avere = (decimal)dsEP.Tables["entrydetail"]._Filter(q.gt("amount", 0) & q.eq("nentry", rEntry["nentry"])).GetSum<decimal>("amount");
            Assert.AreEqual(30m, avere, "Avere corrispondente");
        }

        [TestMethod]
        public void Test2_estimate_2018_sostituito2019_NonCollFattura_parzaccert5()
        {
            //CASO esercizi anni precedenti 1d.4 
            var t = new TestHelp(new DateTime(2018, 12, 31));
            q filterEst = q.eq("idestimkind", "CA_GENERICO") & q.eq("yestim", 2018) & q.eq("nestim", 58);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            DataRow rEst = tEstimate.Rows[0];
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rEst, false);
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst);
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreEqual(4, nEstDet, "Il contratto ha 4 dettagli");

            DataRow estimDet1 = tEstimateDetail.Rows[0];
            //207712 86563
            object idepacc1 = estimDet1["idepacc"];
            DataRow estimDet2 = tEstimateDetail.Rows[1];
            //207714  86564
            object idepacc2 = estimDet2["idepacc"];

            //GENERO LE SCRITTURE E CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);
            checkNoRules(regole);
            var dsEP = t.getEpData(t.testConn, rEst);

            bool scrittureabilitate = t.abilitaScrittureUT(rEst);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");

            Assert.AreEqual(2*2, dsEP.Tables["epaccvar"]._Filter(null).Length, "Sono presenti due variazioni ai mov di budget");
            //CONTROLLO VARIAZIONI
            t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"],2018, 86564,  -60m,2018);
            t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"],2018, 86563,  -100m,2018);

            //CONTROLLO NUMERO IMPEGNI DI BUDGET
            int countNepexp2019 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2019)).Length;
            Assert.AreEqual(0, countNepexp2019, "Non sono presenti impegni  di budget del 2019");
            int countNepexp2018 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2018)).Length;
            Assert.AreEqual(0, countNepexp2018, "Non ci sono impegni di budget del 2018");

            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"],2018, 86564,2018, 100m);
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"],2018, 86563,2018,  200m);
            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019)).Length;
            Assert.AreEqual(0, countNepacc2019, "Non ci sono accertamenti di budget del 2019");
            int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
            Assert.AreEqual(2, countNepacc2018, "Sono presenti 2 accertamenti di budget del 2018");

            //CONTROLLO PRIMO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO 2019
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc2));
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2018) & q.eq("idepacc", idepacc2));
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            Assert.AreEqual(dr1_epacc["description"], "VERSIONE 1 SOSTITUZIONI MULTIPLE CA_ generico ", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epaccyear["amount"], 100.00m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idacc"], "18000100010005000100010022", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idupb"], "000100030005000200010100", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["idaccmotive"], "000700010005000100010022", "La causale del mov.budget è corrispondente");

            //CONTROLLO SECONDO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO 2018
            DataRow[] rEpacc2 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc1));
            DataRow[] rEpaccyear2 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2018) & q.eq("idepacc", idepacc1));
            DataRow dr2_epacc = rEpacc2[0];
            DataRow dr2_epaccyear = rEpaccyear2[0];
            Assert.AreEqual(dr2_epacc["description"], "VERSIONE 1 SOSTITUZIONI MULTIPLE CA_ generico ", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr2_epaccyear["amount"], 200.00m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epaccyear["idacc"], "18000100010005000100010022", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epaccyear["idupb"], "000100030005000200010100", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epacc["idaccmotive"], "000700010005000100010022", "La causale del mov.budget è corrispondente");

            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            var tEntrydetail = dsEP.Tables["entrydetail"];
            var rEntry = dsEP.Tables["entry"].Rows[0];
            var date_doc_colleg = new DateTime(2018, 12, 31);
            var date_contab = new DateTime(2018, 12, 20);
            Assert.AreEqual(rEntry["description"], "VERSIONE 1 SOSTITUZIONI MULTIPLE CA_ generico , CAUSALE DI RICAVO. cONTABILIZZATO", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "C.A. CA_GENERICO 18/58", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");
            //PRIMO DETTAGLIO SCRITTURA
            var descr1 =
                 "Contratto Attivo CA_GENERICO 18/58 dett. 1- VERSIONE 1 SOSTITUZIONI MULTIPLE CA_ generico ";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1 & q.eq("idacc", "18000100010005000100010022"));
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(EntryDetail1["description"], descr1, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idupb"], "000100030005000200010100", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idreg"], 112387, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idaccmotive"], "000700010005000100010022", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idepacc"], dr2_epacc["idepacc"]);
            Assert.AreEqual(EntryDetail1["idrelated"], dr2_epacc["idrelated"]);
            //SECONDO DETTAGLIO SCRITTURA
            var descr2 =
                "Contratto attivo CA_GENERICO n.58 / 2018 n° 1";
            q filterEDetail2 = q.eq("description", descr2);
            var EntryDetail2Rows = tEntrydetail._Filter(filterEDetail2 & q.eq("idacc", "18000300020002000100090003"));
            var EntryDetail2 = EntryDetail2Rows[0];
            Assert.AreEqual(EntryDetail2["description"], descr2, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idupb"], "000100030005000200010100", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idreg"], 112387, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idaccmotive"], "000700010005000100010022", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idepacc"], dr2_epacc["idepacc"]);
            Assert.AreEqual(EntryDetail2["idrelated"], dr2_epacc["idrelated"]);
            //TERZO DETTAGLIO SCRITTURA
            var descr3 =
                "Contratto Attivo CA_GENERICO 18/58 dett. 2- VERSIONE 1 SOSTITUZIONI MULTIPLE CA_ generico ";
            q filterEDetail3 = q.eq("description", descr3);
            var EntryDetail3Rows = tEntrydetail._Filter(filterEDetail3 & q.eq("idacc", "18000100010005000100010022"));
            var EntryDetail3 = EntryDetail3Rows[0];
            Assert.AreEqual(EntryDetail3["description"], descr3, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail3["idupb"], "000100030005000200010100", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail3["idreg"], 112387, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail3["idaccmotive"], "000700010005000100010022", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail3["idepacc"], dr1_epacc["idepacc"]);
            Assert.AreEqual(EntryDetail3["idrelated"], dr1_epacc["idrelated"]);
            //QUARTO DETTAGLIO SCRITTURA
            var descr4 =
                "Contratto attivo CA_GENERICO n.58 / 2018 n° 2";
            q filterEDetail4 = q.eq("description", descr4);
            var EntryDetail4Rows = tEntrydetail._Filter(filterEDetail4 & q.eq("idacc", "18000300020002000100090003"));
            var EntryDetail4 = EntryDetail4Rows[0];
            Assert.AreEqual(EntryDetail4["description"], descr4, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail4["idupb"], "000100030005000200010100", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail4["idreg"], 112387, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail4["idaccmotive"], "000700010005000100010022", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail4["idepacc"], dr1_epacc["idepacc"]);
            Assert.AreEqual(EntryDetail4["idrelated"], dr1_epacc["idrelated"]);

            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            Assert.AreEqual(1, dsEP.Tables["entry"]._Filter(null).Length, "E' presente una scrittura");
            //CONTROLLO DETTAGLI SCRITTURA ESERCIZIO 2019
            Assert.AreEqual(4, dsEP.Tables["entrydetail"]._Filter(q.eq("nentry", rEntry["nentry"])).Length, "Sono presenti 4 dettagli relativi alla scrittura");
            var avere = (decimal)dsEP.Tables["entrydetail"]._Filter(q.gt("amount", 0) & q.eq("nentry", rEntry["nentry"])).GetSum<decimal>("amount");
            Assert.AreEqual(140m, avere, "Avere corrispondente");
        }

        [TestMethod]
        public void Test2_estimate_2018_annullo2019_CollFattura()
        {
            //CASO esercizi anni precedenti 1a.1 dettaglio non incassato // OK 
            var t = new TestHelp(new DateTime(2019, 12, 31));
            q filterEst = q.eq("idestimkind", "CA_COLLEGABILE") & q.eq("yestim", 2018) & q.eq("nestim", 1);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            DataRow rEst = tEstimate.Rows[0];
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rEst, false);
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst & q.isNotNull("stop"));
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreNotEqual(0, nEstDet, "Il contratto ha dettagli annullati");

            //GENERO LE SCRITTURE E CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);
            checkNoRules(regole);
            var dsEP = t.getEpData(t.testConn, rEst);

            //CONTROLLO VARIAZIONI AI MOVIMENTI DI BUDGET DEL 2019
            DataRow[] rEpaccpvar = dsEP.Tables["epaccvar"]._Filter(null);
            Assert.AreEqual(rEpaccpvar.Length, 2, "Sono presenti 2 variazioni");
            t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"],2019, 86512, -150m,2019);
            
            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019)).Length;
            Assert.AreEqual(0, countNepacc2019, "Non è presente nessun accertamento  di budget del 2019");
            int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
            Assert.AreEqual(1, countNepacc2018, "E' presente un accertamento di budget del 2018");

            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"],2018, 86512,2019, 150m);
            //CONTROLLO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2));
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc" ,207590));
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            Assert.AreEqual(dr1_epacc["description"], "ANNULLO non contabilizzato nel 2019", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epaccyear["amount"], 150.00m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idacc"], "19000100010001000100030005", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idupb"], "000100030006000100010139", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["idaccmotive"], "000700010001000100030005", "La causale del mov.budget è corrispondente");

            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            Assert.AreEqual(0, dsEP.Tables["entry"].Rows.Count, $"Non ci sono scritture relative al contratto");

        }

        [TestMethod]
        public void Test2_estimate_2018_annullo2019_CollFattura2()
        {
            // 1a.3 
            var t = new TestHelp(new DateTime(2018, 12, 31));
            q filterEst = q.eq("idestimkind", "CA_COLLEGABILE") & q.eq("yestim", 2018) & q.eq("nestim", 13);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            DataRow rEst = tEstimate.Rows[0];
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rEst, false);
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst);
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreEqual(1, nEstDet, "Il contratto ha 1 dettagli");

            DataRow estimDet1 = tEstimateDetail.Rows[0];
            // 207692
            object idepacc1 = estimDet1["idepacc"];
       
            //GENERO GLI ACCERTAMENTI/IMPEGNI CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);
            checkNoRules(regole);
            var dsEP = t.getEpData(t.testConn, rEst);

            Assert.AreEqual(2 * 1, dsEP.Tables["epaccvar"]._Filter(null).Length, "E' presente una variazione ai mov.di budget");
            //CONTROLLO VARIAZIONE 1 AI MOVIMENTI DI BUDGET 2018 
            t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"],2019, 86554, -150m,2019);

            //CONTROLLO NUMERO IMPEGNI DI BUDGET
            int countNepexp2019 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2019)).Length;
            Assert.AreEqual(0, countNepexp2019, "Non sono presenti impegni  di budget del 2019");
            int countNepexp2018 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2018)).Length;
            Assert.AreEqual(0, countNepexp2018, "Non ci sono impegni di budget del 2018");

            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019)).Length;
            Assert.AreEqual(0, countNepacc2019, "Non ci sono accertamenti di budget del 2019");
            int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
            Assert.AreEqual(1, countNepacc2018, "E' presente un accertamento di budget del 2018");

            //CONTROLLO PRIMO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO 2019
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc1));
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc1));
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            Assert.AreEqual(dr1_epacc["description"], "ANNULLO non contabilizzato nel 2019", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epaccyear["amount"], 150.00m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idacc"], "19000100010001000100030005", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idupb"], "000100030006000100010139", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["idaccmotive"], "000700010001000100030005", "La causale del mov.budget è corrispondente");
        }

        [TestMethod]
        public void Test2_estimate_2018_annullo2019_CollFattura_accert()
        {
            //devi prendere gli accertamenti e preaccertamenti "giusti" e verificare che due siano variati a zero e gli altri due lasciati invariati
            //CASO esercizi anni precedenti 1b.1
            var t = new TestHelp(new DateTime(2019, 12, 31));
            q filterEst = q.eq("idestimkind", "CA_COLLEGABILE") & q.eq("yestim", 2018) & q.eq("nestim", 2);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            DataRow rEst = tEstimate.Rows[0];
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rEst, false);
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst & q.isNotNull("stop"));
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreNotEqual(0, nEstDet, "Il contratto ha dettagli annullati");
            
            //GENERO LE SCRITTURE E CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);
            checkNoRules(regole);
            var dsEP = t.getEpData(t.testConn, rEst);

            //CONTROLLO VARIAZIONI AI MOVIMENTI DI BUDGET 
            DataRow[] rEpaccpvar = dsEP.Tables["epaccvar"]._Filter(null);
            Assert.AreEqual(rEpaccpvar.Length, 1*2, "E' presente una variazione");
            t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"],2019, 86513, -22m,2019,1);

            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"],2018, 86513,2019,22m);
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"],2018, 86514,2019,50m);

            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019)).Length;
            Assert.AreEqual(0, countNepacc2019, "Non ci sono accertamenti di budget del 2019");
            int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
            Assert.AreEqual(2, countNepacc2018, "Ci sono 2 accertamenti di budget del 2018");

            //CONTROLLO PRIMO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("nepacc",86514));
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", 207594));
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            Assert.AreEqual(dr1_epacc["description"], "ANNULLO contabilizzato nel 2018 no fatturato", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epaccyear["amount"], 50.00m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idacc"], "19000100010001000100030005", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idupb"], "00010002", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["idaccmotive"], "000700010001000100030005", "La causale del mov.budget è corrispondente");

            //CONTROLLO SECONDO  ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO
            DataRow[] rEpacc2 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("nepacc", 86513));
            DataRow[] rEpaccyear2 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", 207592));
            DataRow dr2_epacc = rEpacc2[0];
            DataRow dr2_epaccyear = rEpaccyear2[0];
            Assert.AreEqual(dr2_epacc["description"], "ANNULLO contabilizzato nel 2018 no fatturato", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr2_epaccyear["amount"], 22.00m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epaccyear["idacc"], "19000100010001000100030005", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epaccyear["idupb"], "00010002", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epacc["idaccmotive"], "000700010001000100030005", "La causale del mov.budget è corrispondente");

            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            Assert.AreEqual(0, dsEP.Tables["entry"].Rows.Count, $"Non ci sono scritture");

        }

        [TestMethod]
        public void Test2_estimate_2018_annullo2019_CollFattura_accert3()
        {
            // 1b.3 
            var t = new TestHelp(new DateTime(2018, 12, 31));
            q filterEst = q.eq("idestimkind", "CA_COLLEGABILE") & q.eq("yestim", 2018) & q.eq("nestim", 14);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            DataRow rEst = tEstimate.Rows[0];
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rEst, false);
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst);
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreEqual(2, nEstDet, "Il contratto ha 1 dettagli");

            DataRow estimDet1 = tEstimateDetail.Rows[0];
            // 207694
            object idepacc1 = estimDet1["idepacc"];
            //207696
            object idepacc2 = tEstimateDetail.Rows[1]["idepacc"];

            //GENERO GLI ACCERTAMENTI/IMPEGNI CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);
            checkNoRules(regole);
            var dsEP = t.getEpData(t.testConn, rEst);

            //CONTROLLO VARIAZIONE 1 AI MOVIMENTI DI BUDGET 
            Assert.AreEqual(3, dsEP.Tables["epaccvar"]._Filter(null).Length / 2, "Sono presenti 3 variazioni ai mov di budget");
            t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"],2018, 86555, -60m, 2018);
            t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"],2019, 86556, -60m,2019);
            t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"],2019, 86555, -90m, 2019);

            //CONTROLLO NUMERO IMPEGNI DI BUDGET
            int countNepexp2019 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2019)).Length;
            Assert.AreEqual(0, countNepexp2019, "Non sono presenti impegni  di budget del 2019");
            int countNepexp2018 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2018)).Length;
            Assert.AreEqual(0, countNepexp2018, "Non ci sono impegni di budget del 2018");

            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"],2018, 86556,2019, 60m);
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"],2018, 86555,2018, 150m);
            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019)).Length;
            Assert.AreEqual(0, countNepacc2019, "Non ci sono accertamenti di budget del 2019");
            int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
            Assert.AreEqual(2, countNepacc2018, "Sono presenti 2 accertamenti di budget del 2018");

            //CONTROLLO PRIMO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO 2019
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc2));
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc2));
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            Assert.AreEqual(dr1_epacc["description"], "ANNULLO non contabilizzato nel 2019", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epaccyear["amount"], 60.00m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idacc"], "19000100010001000100030005", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idupb"], "00010002", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["idaccmotive"], "000700010001000100030005", "La causale del mov.budget è corrispondente");

            //CONTROLLO SECONDO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO 2019
            DataRow[] rEpacc2 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc1));
            DataRow[] rEpaccyear2 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc1));
            DataRow dr2_epacc = rEpacc2[0];
            DataRow dr2_epaccyear = rEpaccyear2[0];
            Assert.AreEqual(dr2_epacc["description"], "ANNULLO non contabilizzato nel 2019", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr2_epaccyear["amount"], 90.00m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epaccyear["idacc"], "19000100010001000100030005", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epaccyear["idupb"], "00010002", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epacc["idaccmotive"], "000700010001000100030005", "La causale del mov.budget è corrispondente");
        }

        [TestMethod]
        public void Test2_estimate_2018_sostituito2019_CollFattura_parzcont()
        {
            //CASO esercizi anni precedenti 1c.2 dettaglio accert// 
            var t = new TestHelp(new DateTime(2019, 12, 31));
            q filterEst = q.eq("idestimkind", "CA_COLLEGABILE") & q.eq("yestim", 2018) & q.eq("nestim", 2);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            DataRow rEst = tEstimate.Rows[0];
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rEst, false);
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst & q.isNotNull("stop"));
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreEqual(1, nEstDet, "Il contratto ha 1 dettaglio annullato");

            //GENERO LE SCRITTURE E CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);
            checkNoRules(regole);
            var dsEP = t.getEpData(t.testConn, rEst);

            //CONTROLLO VARIAZIONI AI MOVIMENTI DI BUDGET 
            DataRow[] rEpaccpvar = dsEP.Tables["epaccvar"]._Filter(null);
            Assert.AreEqual(rEpaccpvar.Length, 1 * 2, "E' presente una variazione");
            t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"],2019, 86513, -22m, 2019);

            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"],2018, 86514, 2019, 50m);
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"],2018, 86513, 2019, 22m);
            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019)).Length;
            Assert.AreEqual(0, countNepacc2019, "Non ci sono accertamenti di budget del 2019");
            int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
            Assert.AreEqual(2, countNepacc2018, "Ci sono 2 accertamenti di budget del 2018");

            //CONTROLLO PRIMO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("nepacc", 86514));
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", 207594));
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            Assert.AreEqual(dr1_epacc["description"], "ANNULLO contabilizzato nel 2018 no fatturato", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epaccyear["amount"], 50.00m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idacc"], "19000100010001000100030005", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idupb"], "00010002", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["idaccmotive"], "000700010001000100030005", "La causale del mov.budget è corrispondente");

            //CONTROLLO SECONDO  ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO
            DataRow[] rEpacc2 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("nepacc", 86513));
            DataRow[] rEpaccyear2 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", 207592));
            DataRow dr2_epacc = rEpacc2[0];
            DataRow dr2_epaccyear = rEpaccyear2[0];
            Assert.AreEqual(dr2_epacc["description"], "ANNULLO contabilizzato nel 2018 no fatturato", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr2_epaccyear["amount"], 22.00m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epaccyear["idacc"], "19000100010001000100030005", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epaccyear["idupb"], "00010002", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epacc["idaccmotive"], "000700010001000100030005", "La causale del mov.budget è corrispondente");

            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            Assert.AreEqual(0, dsEP.Tables["entry"].Rows.Count, $"Non ci sono scritture");

        }

        [TestMethod]
        public void Test2_estimate_2018_sostituito2019_CollFattura_parzcont3()
        {
            // 1c.3 
            var t = new TestHelp(new DateTime(2019, 12, 31));
            q filterEst = q.eq("idestimkind", "CA_COLLEGABILE") & q.eq("yestim", 2018) & q.eq("nestim", 15);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            DataRow rEst = tEstimate.Rows[0];
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rEst, false);
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst);
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreEqual(4, nEstDet, "Il contratto ha 1 dettagli");

            DataRow estimDet1 = tEstimateDetail.Rows[0];
            // 207698
            object idepacc1 = estimDet1["idepacc"];
            // 207700
            object idepacc2 = tEstimateDetail.Rows[1]["idepacc"];

            //GENERO GLI ACCERTAMENTI/IMPEGNI CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);
            checkNoRules(regole);
            var dsEP = t.getEpData(t.testConn, rEst);

            Assert.AreEqual(2 * 2, dsEP.Tables["epaccvar"]._Filter(null).Length, "Sono presenti due variazioni ai mov di budget");
            //CONTROLLO VARIAZIONI
            t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"],2018, 86558,  -30m,2019);
            t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"],2018, 86557,  -50m,2018);

            //CONTROLLO NUMERO IMPEGNI DI BUDGET
            int countNepexp2019 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2019)).Length;
            Assert.AreEqual(0, countNepexp2019, "Non sono presenti impegni  di budget del 2019");
            int countNepexp2018 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2018)).Length;
            Assert.AreEqual(0, countNepexp2018, "Non ci sono impegni di budget del 2018");

            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"],2018, 86558,2019, 50m);
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"],2018, 86557,2018, 150m);
            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019)).Length;
            Assert.AreEqual(0, countNepacc2019, "Non ci sono accertamenti di budget del 2019");
            int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
            Assert.AreEqual(2, countNepacc2018, "Sono presenti 2 accertamenti di budget del 2018");

            //CONTROLLO PRIMO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO 2019
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc2));
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc2));
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            Assert.AreEqual(dr1_epacc["description"], "V.2 sost anel 2019 parzialmente contabilizzato no fatturato", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epaccyear["amount"], 50.00m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idacc"], "19000100010001000100030005", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idupb"], "00010002", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["idaccmotive"], "000700010001000100030005", "La causale del mov.budget è corrispondente");

            //CONTROLLO SECONDO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO 2019
            DataRow[] rEpacc2 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc1));
            DataRow[] rEpaccyear2 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc1));
            DataRow dr2_epacc = rEpacc2[0];
            DataRow dr2_epaccyear = rEpaccyear2[0];
            Assert.AreEqual(dr2_epacc["description"], "V.2 sost anel 2019 parzialmente contabilizzato no fatturato", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr2_epaccyear["amount"], 100.00m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epaccyear["idacc"], "19000100010001000100030005", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epaccyear["idupb"], "00010002", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epacc["idaccmotive"], "000700010001000100030005", "La causale del mov.budget è corrispondente");
        }

        [TestMethod]
        public void Test2_estimate_2018_sostituito2019_CollFattura_parzcont6()
        {
            //2018: accertamento di 100 variato a 50 con due due variazioni una di -20 ed una di -30
            //2019: accertamento del 2018 ha importo iniziale 50, variato a 40
            // 1c.3 
            var t = new TestHelp(new DateTime(2019, 12, 31));
            q filterEst = q.eq("idestimkind", "CA_COLLEGABILE") & q.eq("yestim", 2018) & q.eq("nestim", 22);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            DataRow rEst = tEstimate.Rows[0];
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rEst, false);
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst);
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreEqual(4, nEstDet, "Il contratto ha 1 dettagli");

            DataRow estimDet1 = tEstimateDetail.Rows[0];
            // 207734
            object idepacc1 = estimDet1["idepacc"];

            //GENERO GLI ACCERTAMENTI/IMPEGNI CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);
            checkNoRules(regole);
            var dsEP = t.getEpData(t.testConn, rEst);

            Assert.AreEqual(3, dsEP.Tables["epaccvar"]._Filter(null).Length/2, "Sono presenti 3 variazioni ai mov di budget nell'esercizio 2018");
            //CONTROLLO VARIAZIONI
            t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"],2018, 86569, -10m,2019,3);
            t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"],2018, 86569, -20m,2018,1);
            t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"],2018, 86569, -30m,2018,2);


            //CONTROLLO VARIAZIONE 1 AI MOVIMENTI DI BUDGET ESERCIZIO 2018 (STESSO ACCERTAMENTO)
            DataRow[] rEpaccpvar2 = dsEP.Tables["epaccvar"]._Filter(q.eq("yvar", 2018));
            DataRow dr2_Epaccvar = rEpaccpvar2[0];
            decimal totale2 = CfgFn.GetNoNullDecimal(dr2_Epaccvar["amount"]);
            for (int i = 2; i <= 5; i++)
            {
                totale2 += CfgFn.GetNoNullDecimal(dr2_Epaccvar["amount" + i.ToString()]);
            }
            Assert.AreEqual(totale2, -20.00m, "L'importo totale della variazione è corrispondente");

            //CONTROLLO VARIAZIONE 2 AI MOVIMENTI DI BUDGET ESERCIZIO 2018 (STESSO ACCERTAMENTO)
            DataRow dr3_Epaccvar = rEpaccpvar2[1];
            decimal totale3 = CfgFn.GetNoNullDecimal(dr3_Epaccvar["amount"]);
            for (int i = 2; i <= 5; i++)
            {
                totale3 += CfgFn.GetNoNullDecimal(dr3_Epaccvar["amount" + i.ToString()]);
            }
            Assert.AreEqual(totale3, -30.00m, "L'importo totale della variazione è corrispondente");

            //CONTROLLO NUMERO IMPEGNI DI BUDGET
            int countNepexp2019 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2019)).Length;
            Assert.AreEqual(0, countNepexp2019, "Non sono presenti impegni  di budget del 2019");
            int countNepexp2018 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2018)).Length;
            Assert.AreEqual(0, countNepexp2018, "Non ci sono impegni di budget del 2018");

            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019)).Length;
            Assert.AreEqual(0, countNepacc2019, "Non ci sono accertamenti di budget del 2019");
            int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
            Assert.AreEqual(1, countNepacc2018, "E' presente un accertamento di budget del 2018");

            //CONTROLLO PRIMO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO 2019
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc1));
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc1));
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            Assert.AreEqual(dr1_epacc["description"], "SOSTITUZIONI MULTIPLE ", "La descrizione del mov.budget  è corrispondente");

            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"],2018, 86569,2018, 100m);
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"],2018, 86569,2019, 50m);

            Assert.AreEqual(dr1_epaccyear["idacc"], "19000100010005000100010022", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idupb"], "000100020001000100010016", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["idaccmotive"], "000700010005000100010022", "La causale del mov.budget è corrispondente");

        }

        void checkNoRules(ProcedureMessageCollection rules) {
	        if (rules == null) return;
            StringBuilder sb = new StringBuilder();
            foreach (EasyProcedureMessage r in rules) {
	            sb.AppendLine($"{r.GetKey()} id {r.EnforcementNumber} {(r.CanIgnore?"-ignorabile":"-errore")}");
            }
            Assert.AreEqual("",sb.ToString(),"Non scatta alcuna regola");
        }

        public static void checkExistRule(ProcedureMessageCollection rules,string code) {
	        if (rules == null) return;
	        StringBuilder sb = new StringBuilder();
	        foreach (EasyProcedureMessage r in rules) {
		        if (r.AuditID == code) return;
		        sb.AppendLine($"{r.GetKey()} id {r.EnforcementNumber} {(r.CanIgnore?"-ignorabile":"-errore")}");
	        }
	        Assert.IsTrue(false,$"Scatta la regola {code}");
        }

        [TestMethod]
        public void Test2_estimate_2018_sostituito2019_CollFattura_parzcont8()
        {
            // 1c.8 
            var t = new TestHelp(new DateTime(2019, 12, 31));
            q filterEst = q.eq("idestimkind", "CA_COLLEGABILE") & q.eq("yestim", 2018) & q.eq("nestim", 18);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            DataRow rEst = tEstimate.Rows[0];
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rEst, false);
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst);
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreEqual(3, nEstDet, "Il contratto ha 1 dettagli");

            DataRow estimDet1 = tEstimateDetail.Rows[0];
            // 207708
            object idepacc1 = estimDet1["idepacc"];
            // 
            object idepacc2 = tEstimateDetail.Rows[1]["idepacc"];

            //GENERO GLI ACCERTAMENTI/IMPEGNI CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);
            checkNoRules(regole);
            var dsEP = t.getEpData(t.testConn, rEst);

            Assert.AreEqual(2 * 2, dsEP.Tables["epaccvar"]._Filter(null).Length, "Sono presenti due variazioni ai mov di budget");
            //CONTROLLO VARIAZIONE 1 AI MOVIMENTI DI BUDGET 2019 
            DataRow[] rEpaccpvar = dsEP.Tables["epaccvar"]._Filter(q.eq("idepacc", idepacc1) & q.eq("yvar",2019));
            t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"],2019, 86562, -20m,2019);
            

            //CONTROLLO NUMERO IMPEGNI DI BUDGET
            int countNepexp2019 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2019)).Length;
            Assert.AreEqual(0, countNepexp2019, "Non sono presenti impegni  di budget del 2019");
            int countNepexp2018 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2018)).Length;
            Assert.AreEqual(0, countNepexp2018, "Non ci sono impegni di budget del 2018");

            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019)).Length;
            Assert.AreEqual(0, countNepacc2019, "Non ci sono accertamenti di budget del 2019");
            int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
            Assert.AreEqual(1, countNepacc2018, "E' presente un accertamento di budget del 2018");

            //CONTROLLO PRIMO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO 2019
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc1));
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc1));
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            Assert.AreEqual(dr1_epacc["description"], "VERSIONE 3 SOSTITUZIONI MULTIPLE CA_ COLLEGABILE ", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epaccyear["amount"], 70.00m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idacc"], "19000100010005000100010022", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idupb"], "000100030005000200010100", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["idaccmotive"], "000700010005000100010022", "La causale del mov.budget è corrispondente");
  
        }

        [TestMethod]
        public void Test2_estimate_2018_sostituito2018_ConFattura3()
        {
            // 2018: accertamento di budget 68.03, accertamento di budget di 150 ridotto a 81.97 con variazione di -68.03
            // 2019: un accertamento ha importo iniziale 68.03, il secondo ha importo iniziale 0
            var t = new TestHelp(new DateTime(2018, 12, 31));
            q filterEst = q.eq("idestimkind", "CA_COLLEGABILE") & q.eq("yestim", 2018) & q.eq("nestim", 19);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);

            DataRow rEst = tEstimate.Rows[0];
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rEst, false);
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst);
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreEqual(4, nEstDet, "Il contratto ha 1 dettagli");

            DataRow estimDet1 = tEstimateDetail.Rows[0];
            // 207726
            object idepacc1 = estimDet1["idepacc"];
            // 207728
            object idepacc2 = tEstimateDetail.Rows[1]["idepacc"];

            //GENERO GLI ACCERTAMENTI/IMPEGNI CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);
            checkNoRules(regole);
            var dsEP = t.getEpData(t.testConn, rEst);

            Assert.AreEqual(2, dsEP.Tables["epaccvar"]._Filter(null).Length/2, "Sono presenti due variazioni ai mov di budget");
            //CONTROLLO VARIAZIONI AI MOV DI BUDGET

            t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"],2018, 86565, -68.03m,2018,1);
            t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"],2018, 86566, -68.03m,2019,1);
            

            //CONTROLLO NUMERO IMPEGNI DI BUDGET
            int countNepexp = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) ).Length;
            Assert.AreEqual(0, countNepexp, "Non ci sono impegni di budget");

            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019)).Length;
            Assert.AreEqual(0, countNepacc2019, "Non ci sono accertamenti di budget del 2019");
            int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
            Assert.AreEqual(2, countNepacc2018, "Sono presenti 2 accertamenti di budget del 2018");

            //CONTROLLO PRIMO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO 2019
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc2));
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc2));
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            Assert.AreEqual(dr1_epacc["description"], "Residenze universitarie: docente in camera singola tariffa giornaliera", "La descrizione del mov.budget  è corrispondente");
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"],dr1_epacc["idepacc"], 2019, 68.03m);


            Assert.AreEqual(dr1_epaccyear["idacc"], "19000100010005000100010022", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idupb"], "000100020003000500010001", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["idaccmotive"], "000700010005000100010022", "La causale del mov.budget è corrispondente");

            //CONTROLLO SECONDO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO 2019
            DataRow[] rEpacc2 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc1));
            DataRow[] rEpaccyear2 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc1));
            DataRow dr2_epacc = rEpacc2[0];
            DataRow dr2_epaccyear = rEpaccyear2[0];
            Assert.AreEqual(dr2_epacc["description"], "Residenze universitarie: docente in camera singola tariffa giornaliera", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr2_epaccyear["amount"], 0.00m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epaccyear["idacc"], "19000100010005000100010022", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epaccyear["idupb"], "000100020003000500010001", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epacc["idaccmotive"], "000700010005000100010022", "La causale del mov.budget è corrispondente");

            // CONTROLLO FATTURA COLLEGATA
            DataTable tInvoiceDetail = t.testConn.readTable("invoicedetail", filterEst & q.eq("rownum", 1));
            Assert.AreEqual(1, tInvoiceDetail.Rows.Count, "I dettagli fattura sono collegati al contratto attivo");
            DataRow rInvD = tInvoiceDetail.Rows[0];
            q filterInv = q.eq("idinvkind", rInvD["idinvkind"]) & q.eq("yinv", rInvD["yinv"]) & q.eq("ninv", rInvD["ninv"]);
            t.binaryReplaceSet(filterInv, t.getTableSet(TestHelp.mainObject.invoice));
            DataTable tInvoice = t.testConn.readTable("invoice", filterInv);
            Assert.AreEqual(1, tInvoiceDetail.Rows.Count, "La fattura ha 1 dettaglio");
            DataRow rInv = tInvoice.Rows[0];
            var idrelatedInvD = BudgetFunction.GetIdForDocument(rInvD);
            ProcedureMessageCollection regole2 = t.generaAccertamentiScritture(rInv);
            checkNoRules(regole2);
            var dsEPInv = t.getEpData(t.testConn, rInv);
            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            var tEntrydetail = dsEPInv.Tables["entrydetail"];
            var rEntry = dsEPInv.Tables["entry"].Rows[0];
            var date_doc_colleg = new DateTime(2018, 12, 31);
            var date_contab = new DateTime(2018, 12, 31);
            Assert.AreEqual(rEntry["description"], "parzialmente contabilizzato e fatturato (prima contabilizzazione e poi fattura):", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "18/000002", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");
            //PRIMO DETTAGLIO SCRITTURA
            var descr1 =
                 "Residenze universitarie: docente in camera singola tariffa giornaliera";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1 & q.eq("idacc", "18000100010005000100010022"));
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(EntryDetail1["description"], descr1, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idupb"], "000100020003000500010001", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idreg"], 112387, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idaccmotive"], "000700010005000100010022", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idepacc"], dr2_epacc["idepacc"]);
            Assert.AreEqual(EntryDetail1["idrelated"], idrelatedInvD);
            //SECONDO DETTAGLIO SCRITTURA
            var descr2 =
                "Fattura FE_VENDITE_amm n.2 / 2018";
            q filterEDetail2 = q.eq("description", descr2);
            var EntryDetail2Rows = tEntrydetail._Filter(filterEDetail2 & q.eq("idacc", "18000400040001000200010001"));
            var EntryDetail2 = EntryDetail2Rows[0];
            Assert.AreEqual(EntryDetail2["description"], descr2, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idupb"], "000100020003000500010001", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idreg"], 112387, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idaccmotive"], "000700010005000100010022", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idrelated"], idrelatedInvD);
            //TERZO DETTAGLIO SCRITTURA
            var descr3 =
                "Fattura FE_VENDITE_amm n.2 / 2018";
            q filterEDetail3 = q.eq("description", descr3);
            var EntryDetail3Rows = tEntrydetail._Filter(filterEDetail3 & q.eq("idacc", "18000300020002000100090003"));
            var EntryDetail3 = EntryDetail3Rows[0];
            Assert.AreEqual(EntryDetail3["description"], descr3, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail3["idupb"], "000100020003000500010001", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail3["idreg"], 112387, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail3["idaccmotive"], "000700010005000100010022", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail3["idepacc"], dr2_epacc["idepacc"]);
            Assert.AreEqual(EntryDetail3["idrelated"], idrelatedInvD);
            //QAURTO DETTAGLIO SCRITTURA
            var descr4 =
                "Fattura FE_VENDITE_amm n.2 / 2018";
            q filterEDetail4 = q.eq("description", descr4);
            var EntryDetail4Rows = tEntrydetail._Filter(filterEDetail4 & q.eq("idacc", "18000300020002000100090003"));
            var EntryDetail4 = EntryDetail4Rows[0];
            Assert.AreEqual(EntryDetail4["description"], descr4, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail4["idupb"], "000100020003000500010001", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail4["idreg"], 112387, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail4["idaccmotive"], "000700010005000100010022", "La causale del dettaglio della scrittura è corrispondente"); 
            Assert.AreEqual(EntryDetail4["idrelated"], idrelatedInvD);
            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            Assert.AreEqual(1, dsEPInv.Tables["entry"]._Filter(null).Length, "E presente una scrittura");
            //CONTROLLO DETTAGLI SCRITTURA ESERCIZIO 2019
            Assert.AreEqual(4, dsEPInv.Tables["entrydetail"]._Filter(q.eq("nentry", rEntry["nentry"])).Length, "Sono presenti 4 dettagli relativi alla scrittura della fattura");
            var avere = (decimal)dsEPInv.Tables["entrydetail"]._Filter(q.gt("amount", 0) & q.eq("nentry", rEntry["nentry"])).GetSum<decimal>("amount");
            Assert.AreEqual(100m, avere, "Avere corrispondente");

        }

        [TestMethod]
        public void Test2_estimate_2018_sostituito2019_ConFattura4()
        {
            // 2018: accertamento di budget 27.27, accertamento di budget di 100 ridotto a 72.73 con variazione di -27.27
            // 2019:  accertamento ha importo iniziale 27.07 ridotto a 0 con variazione di -27.07, il secondo ha importo iniziale 0
            var t = new TestHelp(new DateTime(2019, 12, 31));
            q filterEst = q.eq("idestimkind", "CA_COLLEGABILE") & q.eq("yestim", 2018) & q.eq("nestim", 42);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);

            DataRow rEst = tEstimate.Rows[0];
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rEst, false);
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst);
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreEqual(4, nEstDet, "Il contratto ha 4 dettagli");

            DataRow estimDet1 = tEstimateDetail.Rows[0];
            // 207792
            object idepacc1 = estimDet1["idepacc"];
            // 207794
            object idepacc2 = tEstimateDetail.Rows[1]["idepacc"];


            //GENERO GLI ACCERTAMENTI/IMPEGNI CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);
            checkNoRules(regole);
            var dsEP = t.getEpData(t.testConn, rEst);

            //UNA VARIAZIONE NELL'ESERCIZIO 2019 E L'ALTRA NELL'ESERCZIO 2018
            Assert.AreEqual(2 * 2, dsEP.Tables["epaccvar"]._Filter(null).Length, "Sono presenti due variazioni ai mov di budget");
            //CONTROLLO VARIAZIONI
            t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"],2019, 86594,-27.27m,2019);
            t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"],2018, 86593, -27.27m,2018);

            //CONTROLLO NUMERO IMPEGNI DI BUDGET
            int countNepexp2019 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2019)).Length;
            Assert.AreEqual(0, countNepexp2019, "Non sono presenti impegni  di budget del 2019");
            int countNepexp2018 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2018)).Length;
            Assert.AreEqual(0, countNepexp2018, "Non ci sono impegni di budget del 2018");

            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2018, 86594, 2018, 27.27m);
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2018, 86593, 2018, 100m);
            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019)).Length;
            Assert.AreEqual(0, countNepacc2019, "Non ci sono accertamenti di budget del 2019");
            int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
            Assert.AreEqual(2, countNepacc2018, "Sono presenti 2 accertamenti di budget del 2018");

            //CONTROLLO PRIMO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO 2019
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc2));
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc2));
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            Assert.AreEqual(dr1_epacc["description"], "parzialmente contabilizzato e fatturato (prima contabilizzazione e poi fattura), sostituito nel 2019", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idacc"], "19000100010005000100010022", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idupb"], "000100030002000300010058", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["idaccmotive"], "000700010005000100010022", "La causale del mov.budget è corrispondente");
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2018, 86594, 2019, 27.27m);
            //CONTROLLO SECONDO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO 2019
            DataRow[] rEpacc2 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc1));
            DataRow[] rEpaccyear2 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc1));
            DataRow dr2_epacc = rEpacc2[0];
            DataRow dr2_epaccyear = rEpaccyear2[0];
            Assert.AreEqual(dr2_epacc["description"], "parzialmente contabilizzato e fatturato (prima contabilizzazione e poi fattura), sostituito nel 2019", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr2_epaccyear["idacc"], "19000100010005000100010022", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epaccyear["idupb"], "000100030002000300010058", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epacc["idaccmotive"], "000700010005000100010022", "La causale del mov.budget è corrispondente");
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2018, 86593, 2019, 0m);
            // CONTROLLO FATTURA COLLEGATA
            q filterInv2 = q.eq("idinvkind", 127) & q.eq("yinv",2018 ) & q.eq("ninv",3 );
            t.binaryReplaceSet(filterInv2, t.getTableSet(TestHelp.mainObject.invoice));
            DataTable tInvoiceDetail = t.testConn.readTable("invoicedetail", filterEst & q.eq("rownum", 1));
            Assert.AreEqual(1, tInvoiceDetail.Rows.Count, "I dettagli fattura sono collegati al primo dettaglio del CA");
            DataRow rInvD = tInvoiceDetail.Rows[0];
            q filterInv = q.eq("idinvkind", rInvD["idinvkind"]) & q.eq("yinv", rInvD["yinv"]) & q.eq("ninv", rInvD["ninv"]);
            
            DataTable tInvoice = t.testConn.readTable("invoice", filterInv);
            Assert.AreEqual(1, tInvoiceDetail.Rows.Count, "La fattura ha 1 dettaglio");
            DataRow rInv = tInvoice.Rows[0];
            var idrelatedInvD = BudgetFunction.GetIdForDocument(rInvD);
            ProcedureMessageCollection regole2 = t.generaAccertamentiScritture(rInv);
            if (regole2 != null)
                Assert.AreEqual(0, regole2.Count, "Non scatta nessuna regola");
            var dsEPInv = t.getEpData(t.testConn, rInv);
            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            var rEntry = dsEPInv.Tables["entry"]._Filter(q.eq("yentry",2019));
            Assert.AreEqual(0,rEntry.Length,"Non ci sono scritture per la fattura nell'anno 2019");
        }

        [TestMethod]
        public void Test2_estimate_2018_sostituito2018_ConFattura5()
        {
            // 1d 5
            var t = new TestHelp(new DateTime(2019, 12, 31));
            q filterEst = q.eq("idestimkind", "CA_COLLEGABILE") & q.eq("yestim", 2018) & q.eq("nestim", 20);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            
            DataRow rEst = tEstimate.Rows[0];
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rEst, false);
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst);
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreEqual(2, nEstDet, "Il contratto ha 2 dettagli");

            DataRow estimDet1 = tEstimateDetail.Rows[0];
            object idepacc1 = estimDet1["idepacc"];

            //GENERO GLI ACCERTAMENTI/IMPEGNI CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);
            checkNoRules(regole);
            var dsEP = t.getEpData(t.testConn, rEst);

            Assert.AreEqual(2 * 1, dsEP.Tables["epaccvar"]._Filter(null).Length, "E' presente una variazione ai mov di budget");
            //CONTROLLO VARIAZIONE
            t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"],2019, 86567,-100m,2019);

            //CONTROLLO NUMERO IMPEGNI DI BUDGET
            int countNepexp2019 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2019)).Length;
            Assert.AreEqual(0, countNepexp2019, "Non sono presenti impegni  di budget del 2019");
            int countNepexp2018 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2018)).Length;
            Assert.AreEqual(0, countNepexp2018, "Non ci sono impegni di budget del 2018");

            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019)).Length;
            Assert.AreEqual(0, countNepacc2019, "E' presente un accertamento di budget del 2019");
            int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
            Assert.AreEqual(1, countNepacc2018, "E' presente un accertamento di budget del 2018");

            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"],2018, 86567, 2019, 250m);
            //CONTROLLO PRIMO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO 2019
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc1));
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc1));
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            Assert.AreEqual(dr1_epacc["description"], "parzialmente contabilizzato e fatturato(prima fattura e poi contabilizzazione", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epaccyear["amount"], 250.00m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idacc"], "19000100010005000100010022", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idupb"], "000100030003000200010007", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["idaccmotive"], "000700010005000100010022", "La causale del mov.budget è corrispondente");

            // CONTROLLO FATTURA COLLEGATA
            DataTable tInvoiceDetail = t.testConn.readTable("invoicedetail", filterEst & q.eq("rownum", 1));
            Assert.AreEqual(1, tInvoiceDetail.Rows.Count, "I dettagli fattura sono collegati al contratto attivo");
            DataRow rInvD = tInvoiceDetail.Rows[0];
            q filterInv = q.eq("idinvkind", rInvD["idinvkind"]) & q.eq("yinv", rInvD["yinv"]) & q.eq("ninv", rInvD["ninv"]);
            t.binaryReplaceSet(filterInv, t.getTableSet(TestHelp.mainObject.invoice));
            DataTable tInvoice = t.testConn.readTable("invoice", filterInv);
            Assert.AreEqual(1, tInvoiceDetail.Rows.Count, "La fattura ha 1 dettaglio");
            DataRow rInv = tInvoice.Rows[0];
            var idrelatedInvD = BudgetFunction.GetIdForDocument(rInvD);
            ProcedureMessageCollection regole2 = t.generaAccertamentiScritture(rInv);
            checkNoRules(regole2);
            var dsEPInv = t.getEpData(t.testConn, rInv);
            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            var tEntrydetail = dsEPInv.Tables["entrydetail"];
            var rEntry = dsEPInv.Tables["entry"].Rows[0];
            var date_doc_colleg = new DateTime(2019, 12, 31);
            var date_contab = new DateTime(2019, 12, 31);
            Assert.AreEqual(rEntry["description"], "parzialmente contabilizzato e fatturato(prima fattura e poi contabilizzazione) ", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "19/000005", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");
            //PRIMO DETTAGLIO SCRITTURA
            var descr1 =
                 "parzialmente contabilizzato e fatturato(prima fattura e poi contabilizzazione";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1 & q.eq("idacc", "19000100010005000100010022"));
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(EntryDetail1["description"], descr1, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idupb"], "000100030003000200010007", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idreg"], 11925, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idaccmotive"], "000700010005000100010022", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idepacc"], dr1_epacc["idepacc"]);
            Assert.AreEqual(EntryDetail1["idrelated"], idrelatedInvD);
            //SECONDO DETTAGLIO SCRITTURA
            var descr2 =
                "Fattura FE_VENDITE_amm n.5 / 2019";
            q filterEDetail2 = q.eq("description", descr2);
            var EntryDetail2Rows = tEntrydetail._Filter(filterEDetail2 & q.eq("idacc", "19000400040001000200010001"));
            var EntryDetail2 = EntryDetail2Rows[0];
            Assert.AreEqual(EntryDetail2["description"], descr2, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idupb"], "000100030003000200010007", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idreg"], 11925, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idaccmotive"], "000700010005000100010022", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idrelated"], idrelatedInvD);
            //TERZO DETTAGLIO SCRITTURA
            var descr3 =
                "Fattura FE_VENDITE_amm n.5 / 2019";
            q filterEDetail3 = q.eq("description", descr3);
            var EntryDetail3Rows = tEntrydetail._Filter(filterEDetail3 & q.eq("idacc", "19000300020002000100090003"));
            var EntryDetail3 = EntryDetail3Rows[0];
            Assert.AreEqual(EntryDetail3["description"], descr3, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail3["idupb"], "000100030003000200010007", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail3["idreg"], 11925, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail3["idaccmotive"], "000700010005000100010022", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail3["idepacc"], dr1_epacc["idepacc"]);
            Assert.AreEqual(EntryDetail3["idrelated"], idrelatedInvD);
            //QAURTO DETTAGLIO SCRITTURA
            var descr4 =
                "Fattura FE_VENDITE_amm n.5 / 2019";
            q filterEDetail4 = q.eq("description", descr4);
            var EntryDetail4Rows = tEntrydetail._Filter(filterEDetail4 & q.eq("idacc", "19000300020002000100090003"));
            var EntryDetail4 = EntryDetail4Rows[0];
            Assert.AreEqual(EntryDetail4["description"], descr4, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail4["idupb"], "000100030003000200010007", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail4["idreg"], 11925, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail4["idaccmotive"], "000700010005000100010022", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail4["idrelated"], idrelatedInvD);
            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            Assert.AreEqual(1, dsEPInv.Tables["entry"]._Filter(null).Length, "E presente una scrittura");
            //CONTROLLO DETTAGLI SCRITTURA ESERCIZIO 2019
            Assert.AreEqual(4, dsEPInv.Tables["entrydetail"]._Filter(q.eq("nentry", rEntry["nentry"])).Length, "Sono presenti 4 dettagli relativi alla scrittura della fattura");
            var avere = (decimal)dsEPInv.Tables["entrydetail"]._Filter(q.gt("amount", 0) & q.eq("nentry", rEntry["nentry"])).GetSum<decimal>("amount");
            Assert.AreEqual(183m, avere, "Avere corrispondente");
        }

     
        [TestMethod]
        public void Test2_estimate_2018_annullo2019_CollFattura_ScrittRateo2()
        {
            //2018: accertamento di 1200,66  799,34, di 799.34 l'anno dopo, nel 2019 portato a 0 con variazione
            //2019: impegno di 1200,66
            // 1e caso scrittura rateo versione 2  
            var t = new TestHelp(new DateTime(2019, 12, 31));
            q filterEst = q.eq("idestimkind", "CA_COLLEGABILE") & q.eq("yestim", 2018) & q.eq("nestim", 27);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);

            DataRow rEst = tEstimate.Rows[0];
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");

            t.binaryCopyEp(rEst, false);
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst);
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreEqual(1, nEstDet, "Il contratto ha 1 dettaglio");
            DataRow estimDet1 = tEstimateDetail.Rows[0];

            //CONTROLLO DATA FINE COMP. ECONOMICA
            var dateF_compEcon = new DateTime(2019, 08, 31);
            Assert.AreEqual(dateF_compEcon, estimDet1["competencystop"], "La data fine della competenza econ. è corrispondente");

            //GENERO GLI ACCERTAMENTI/IMPEGNI CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);
            checkNoRules(regole);

            var dsEP = t.getEpData(t.testConn, rEst);

            bool scrittureabilitate = t.abilitaScrittureUT(rEst);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");

            Assert.AreEqual(2 * 1, dsEP.Tables["epaccvar"]._Filter(null).Length, "E' presente una variazione ai mov di budget");
            //CONTROLLO VARIAZIONE 1 AI MOVIMENTI DI BUDGET 2019
            object idepacc1 = estimDet1["idepacc"];
            DataRow[] rEpaccpvar = dsEP.Tables["epaccvar"]._Filter(q.eq("idepacc", idepacc1) & q.eq("yvar", 2019));
            t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"],2019, 86578,-799.34m,2019);

            //CONTROLLO NUMERO IMPEGNI DI BUDGET
            int countNepexp2019 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2019)).Length;
            Assert.AreEqual(1, countNepexp2019, "E' presente un impegno di budget del 2019");
            int countNepexp2018 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2018)).Length;
            Assert.AreEqual(0, countNepexp2018, "Non ci sono impegni di budget del 2018");

            //CONTROLLO PRIMO IMPEGNO DI BUDGET
            DataRow[] rEpexp = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2019));
            DataRow dr1_epexp = rEpexp[0];
            DataRow[] rEpexpeyear = dsEP.Tables["epexpyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepexp", dr1_epexp["idepexp"]));
            DataRow dr1_epexpyear = rEpexpeyear[0];
            Assert.AreEqual("caso rateo attivo", dr1_epexp["description"],  "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(1200.66M, dr1_epexpyear["amount"],  "L'importo del mov.budget è corrispondente");
            Assert.AreEqual("19000200010005000100030008", dr1_epexpyear["idacc"],  "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual("000100030007000200010051", dr1_epexpyear["idupb"],  "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual("000600010005000100030008", dr1_epexp["idaccmotive"],  "La causale del mov.budget è corrispondente");

            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019)).Length;
            Assert.AreEqual(0, countNepacc2019, "Nessun accertamento di budget del 2019");
            int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
            Assert.AreEqual(1, countNepacc2018, "E' presente un accertamento di budget del 2018");

            //CONTROLLO PRIMO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO 2019
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc1));
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc1));
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];

            t.checkImportoInizialeImpBudget(dsEP.Tables["epexp"],2019, 7639,2019, 1200.66m);

            Assert.AreEqual("caso rateo attivo", dr1_epacc["description"], "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(799.34m, dr1_epaccyear["amount"], "L'importo del mov.budget è corrispondente");
            Assert.AreEqual("19000100010001000100030005", dr1_epaccyear["idacc"], "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual("000100030007000200010051", dr1_epaccyear["idupb"], "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual("000700010001000100030005", dr1_epacc["idaccmotive"], "La causale del mov.budget è corrispondente");

            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            var tEntrydetail = dsEP.Tables["entrydetail"];
            var rEntry = dsEP.Tables["entry"].Rows[0];
            var date_doc_colleg = new DateTime(2018, 12, 31);
            var date_contab = new DateTime(2019, 12, 31);
            Assert.AreEqual("caso rateo attivo 3", rEntry["description"], "La descrizione della scrittura è corrispondente");
            Assert.AreEqual("C.A. CA_COLLEGABILE 18/27", rEntry["doc"], "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(date_doc_colleg, rEntry["docdate"], "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(date_contab, rEntry["adate"], "La data contabile della scrittura è corrispondente");
            //PRIMO DETTAGLIO SCRITTURA
            var descr1 =
                 "Contratto Attivo CA_COLLEGABILE 18/27dett. 1- caso rateo attivo";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1);
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(descr1, EntryDetail1["description"], "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("19000200010005000100030008", EntryDetail1["idacc"], "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("000100030007000200010051", EntryDetail1["idupb"], "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(131142, EntryDetail1["idreg"], "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("000600010005000100030008", EntryDetail1["idaccmotive"], "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idepexp"], dr1_epexp["idepexp"]);
            Assert.AreEqual(EntryDetail1["idrelated"], dr1_epexp["idrelated"]);
            //SECONDO DETTAGLIO SCRITTURA
            var descr2 =
                "Contratto attivo CA_COLLEGABILE n.27 / 2018 dett. 1";
            q filterEDetail2 = q.eq("description", descr2);
            var EntryDetail2Rows = tEntrydetail._Filter(filterEDetail2);
            var EntryDetail2 = EntryDetail2Rows[0];
            Assert.AreEqual(descr2, EntryDetail2["description"], "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("19000300030001000100010001", EntryDetail2["idacc"], "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("000100030007000200010051", EntryDetail2["idupb"], "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(131142, EntryDetail2["idreg"], "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("000600010005000100030008", EntryDetail2["idaccmotive"], "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idepacc"], dr1_epacc["idepacc"]);
            Assert.AreEqual(EntryDetail2["idrelated"], dr1_epacc["idrelated"]);
            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            Assert.AreEqual(1, dsEP.Tables["entry"]._Filter(q.eq("yentry",2019)).Length, "E' presente una scrittura");
            //CONTROLLO DETTAGLI SCRITTURA ESERCIZIO 2019
            Assert.AreEqual(2, dsEP.Tables["entrydetail"]._Filter(q.eq("nentry", rEntry["nentry"])).Length, "Sono presenti 2 dettagli relativi alla scrittura");
            var avere = (decimal)dsEP.Tables["entrydetail"]._Filter(q.gt("amount", 0) & q.eq("nentry", rEntry["nentry"])).GetSum<decimal>("amount");
            Assert.AreEqual(1200.66m, avere, "Avere corrispondente");
        }

        [TestMethod]
        public void Test2_estimate_2018_annullo2019_CollFattura_FattEmettere()
        {
            // 1e caso con Fatture da emettere
            var t = new TestHelp(new DateTime(2019, 12, 31));
            q filterEst = q.eq("idestimkind", "CA_COLLEGABILE") & q.eq("yestim", 2018) & q.eq("nestim", 39);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);

            DataRow rEst = tEstimate.Rows[0];
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");

            t.binaryCopyEp(rEst, false);
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst);
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreEqual(1, nEstDet, "Il contratto ha 1 dettaglio");
            DataRow estimDet1 = tEstimateDetail.Rows[0];

            //GENERO GLI ACCERTAMENTI/IMPEGNI CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);
            checkNoRules(regole);

            var dsEP = t.getEpData(t.testConn, rEst);

            bool scrittureabilitate = t.abilitaScrittureUT(rEst);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");

            Assert.AreEqual(0, dsEP.Tables["epaccvar"]._Filter(null).Length, "Non ci sono variazioni ai mov di budget");

            object idepacc1 = estimDet1["idepacc"];

            //CONTROLLO NUMERO IMPEGNI DI BUDGET
            int countNepexp2019 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2019)).Length;
            Assert.AreEqual(1, countNepexp2019, "E' presente un impegno di budget del 2019");
            int countNepexp2018 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2018)).Length;
            Assert.AreEqual(0, countNepexp2018, "Non ci sono impegni di budget del 2018");

            //CONTROLLO PRIMO IMPEGNO DI BUDGET
            DataRow[] rEpexp = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2019));
            DataRow dr1_epexp = rEpexp[0];

            DataRow[] rEpexpeyear = dsEP.Tables["epexpyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepexp", dr1_epexp["idepexp"]));

            DataRow dr1_epexpyear = rEpexpeyear[0];
            Assert.AreEqual(dr1_epexp["description"], "caso fatture da emettere", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epexpyear["amount"], 5200.00M, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexpyear["idacc"], "19000200010005000100030008", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexpyear["idupb"], "000100020001000300010002", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexp["idaccmotive"], "000600010005000100030008", "La causale del mov.budget è corrispondente");

            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019)).Length;
            Assert.AreEqual(0, countNepacc2019, "E' presente un accertamento di budget del 2019");
            int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
            Assert.AreEqual(1, countNepacc2018, "E' presente un accertamento di budget del 2018");

            //CONTROLLO PRIMO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO 2019
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc1));
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc1));
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            Assert.AreEqual("caso fatture da emettere", dr1_epacc["description"], "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(0.00m, dr1_epaccyear["amount"], "L'importo del mov.budget è corrispondente");
            Assert.AreEqual("19000100010001000100030005", dr1_epaccyear["idacc"], "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual("000100020001000300010002", dr1_epaccyear["idupb"], "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual("000700010001000100030005", dr1_epacc["idaccmotive"], "La causale del mov.budget è corrispondente");

            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            var tEntrydetail = dsEP.Tables["entrydetail"];
            var rEntry = dsEP.Tables["entry"].Rows[0];
            var date_doc_colleg = new DateTime(2018, 12, 31);
            var date_contab = new DateTime(2019, 10, 23);
            Assert.AreEqual("caso fatture da emettere 6", rEntry["description"], "La descrizione della scrittura è corrispondente");
            Assert.AreEqual("C.A. CA_COLLEGABILE 18/39", rEntry["doc"], "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(date_doc_colleg, rEntry["docdate"], "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(date_contab, rEntry["adate"], "La data contabile della scrittura è corrispondente");
            //PRIMO DETTAGLIO SCRITTURA
            var descr1 =
                 "Contratto Attivo CA_COLLEGABILE 18/39dett. 1- caso fatture da emettere";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1);
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(descr1, EntryDetail1["description"], "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("19000200010005000100030008", EntryDetail1["idacc"], "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("000100020001000300010002", EntryDetail1["idupb"], "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(9054, EntryDetail1["idreg"], "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("000600010005000100030008", EntryDetail1["idaccmotive"], "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idepexp"], dr1_epexp["idepexp"]);
            Assert.AreEqual(EntryDetail1["idrelated"], dr1_epexp["idrelated"]);
            //SECONDO DETTAGLIO SCRITTURA
            var descr2 =
                "Contratto attivo CA_COLLEGABILE n.39 / 2018 dett. 1";
            q filterEDetail2 = q.eq("description", descr2);
            var EntryDetail2Rows = tEntrydetail._Filter(filterEDetail2);
            var EntryDetail2 = EntryDetail2Rows[0];
            Assert.AreEqual(descr2, EntryDetail2["description"], "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("19000300020002000100090005", EntryDetail2["idacc"], "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("000100020001000300010002", EntryDetail2["idupb"], "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(9054, EntryDetail2["idreg"], "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("000600010005000100030008", EntryDetail2["idaccmotive"], "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idepacc"], dr1_epacc["idepacc"]);
            Assert.AreEqual(EntryDetail2["idrelated"], dr1_epacc["idrelated"]);
            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            Assert.AreEqual(1, dsEP.Tables["entry"]._Filter(q.eq("yentry",2019)).Length, "E' presente una scrittura");
            //CONTROLLO DETTAGLI SCRITTURA ESERCIZIO 2019
            Assert.AreEqual(2, dsEP.Tables["entrydetail"]._Filter(q.eq("nentry", rEntry["nentry"])).Length, "Sono presenti sette dettagli relativi alla scrittura");
            var avere = (decimal)dsEP.Tables["entrydetail"]._Filter(q.gt("amount", 0) & q.eq("nentry", rEntry["nentry"])).GetSum<decimal>("amount");
            Assert.AreEqual(5200.00m, avere, "Avere corrispondente");
        }

        [TestMethod]
        public void Test2_estimate_2018_annullo2019_CollFattura_FattEmettere2()
        {
            // 1e caso con Fatture da emettere - causale di annullo è di ricavo
            var t = new TestHelp(new DateTime(2019, 12, 31));
            q filterEst = q.eq("idestimkind", "CA_COLLEGABILE") & q.eq("yestim", 2018) & q.eq("nestim", 36);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);

            DataRow rEst = tEstimate.Rows[0];
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");

            t.binaryCopyEp(rEst, false);
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst);
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreEqual(1, nEstDet, "Il contratto ha 1 dettaglio");
            DataRow estimDet1 = tEstimateDetail.Rows[0];

            //GENERO GLI ACCERTAMENTI/IMPEGNI CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);
            checkNoRules(regole);

            var dsEP = t.getEpData(t.testConn, rEst);

            bool scrittureabilitate = t.abilitaScrittureUT(rEst);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");

            Assert.AreEqual(0, dsEP.Tables["epaccvar"]._Filter(null).Length, "Non ci sono variazioni ai mov di budget");
            //207770
            object idepacc1 = estimDet1["idepacc"];

            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"],2018, 86587, 2018, 700m);

            //CONTROLLO NUMERO IMPEGNI DI BUDGET
            int countNepexp2019 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2019)).Length;
            Assert.AreEqual(0, countNepexp2019, "E' presente un impegno di budget del 2019");
            int countNepexp2018 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2018)).Length;
            Assert.AreEqual(0, countNepexp2018, "Non ci sono impegni di budget del 2018");

            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019)).Length;
            Assert.AreEqual(0, countNepacc2019, "E' presente un accertamento di budget del 2019");
            int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
            Assert.AreEqual(1, countNepacc2018, "E' presente un accertamento di budget del 2018");

            //CONTROLLO PRIMO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO 2019
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc1));
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc1));
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            Assert.AreEqual("caso fatture da emettere", dr1_epacc["description"], "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(0.00m, dr1_epaccyear["amount"], "L'importo del mov.budget è corrispondente");
            Assert.AreEqual("19000100010005000100010022", dr1_epaccyear["idacc"], "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual("000100010018", dr1_epaccyear["idupb"], "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual("000700010005000100010022", dr1_epacc["idaccmotive"], "La causale del mov.budget è corrispondente");

            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            var tEntrydetail = dsEP.Tables["entrydetail"];
            var rEntry = dsEP.Tables["entry"].Rows[0];
            var date_doc_colleg = new DateTime(2018, 12, 31);
            var date_contab = new DateTime(2019, 12, 31);
            Assert.AreEqual("caso fatture da emettere 3 ", rEntry["description"], "La descrizione della scrittura è corrispondente");
            Assert.AreEqual("C.A. CA_COLLEGABILE 18/36", rEntry["doc"], "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(date_doc_colleg, rEntry["docdate"], "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(date_contab, rEntry["adate"], "La data contabile della scrittura è corrispondente");
            //PRIMO DETTAGLIO SCRITTURA
            var descr1 =
                 "Contratto Attivo CA_COLLEGABILE 18/36dett. 1- caso fatture da emettere";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1);
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(descr1, EntryDetail1["description"], "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("19000100010005000100010022", EntryDetail1["idacc"], "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("000100010018", EntryDetail1["idupb"], "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(106105, EntryDetail1["idreg"], "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("000700010005000100010022", EntryDetail1["idaccmotive"], "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idepacc"], dr1_epacc["idepacc"]);
            Assert.AreEqual(EntryDetail1["idrelated"], dr1_epacc["idrelated"]);
            //SECONDO DETTAGLIO SCRITTURA
            var descr2 =
                "Contratto attivo CA_COLLEGABILE n.36 / 2018 dett. 1";
            q filterEDetail2 = q.eq("description", descr2);
            var EntryDetail2Rows = tEntrydetail._Filter(filterEDetail2);
            var EntryDetail2 = EntryDetail2Rows[0];
            Assert.AreEqual(descr2, EntryDetail2["description"], "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("19000300020002000100090005", EntryDetail2["idacc"], "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("000100010018", EntryDetail2["idupb"], "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(106105, EntryDetail2["idreg"], "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("000700010005000100010022", EntryDetail2["idaccmotive"], "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idepacc"], dr1_epacc["idepacc"]);
            Assert.AreEqual(EntryDetail2["idrelated"], dr1_epacc["idrelated"]);
            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            Assert.AreEqual(1, dsEP.Tables["entry"]._Filter(q.eq("yentry",2019)).Length, "E' presente una scrittura");
            //CONTROLLO DETTAGLI SCRITTURA ESERCIZIO 2019
            Assert.AreEqual(2, dsEP.Tables["entrydetail"]._Filter(q.eq("nentry", rEntry["nentry"])&q.eq("yentry",2019)).Length, "Sono presenti due dettagli relativi alla scrittura");
            var avere = (decimal)dsEP.Tables["entrydetail"]._Filter(q.gt("amount", 0) & q.eq("nentry", rEntry["nentry"]) & q.eq("yentry",2019)).GetSum<decimal>("amount");
            Assert.AreEqual(700.00m, avere, "Avere corrispondente");
        }

        [TestMethod]
        public void Test2_estimate_2018_sostituzione2019_CollFattura_FattEmettere()
        {
            // 1e caso con Fatture da emettere
            var t = new TestHelp(new DateTime(2019, 12, 31));
            q filterEst = q.eq("idestimkind", "CA_COLLEGABILE") & q.eq("yestim", 2018) & q.eq("nestim", 38);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);

            DataRow rEst = tEstimate.Rows[0];
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");

            t.binaryCopyEp(rEst, false);
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst);
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreEqual(2, nEstDet, "Il contratto ha 2 dettagli");
            DataRow estimDet1 = tEstimateDetail.Rows[0];

            //GENERO GLI ACCERTAMENTI/IMPEGNI CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);
            checkNoRules(regole);

            var dsEP = t.getEpData(t.testConn, rEst);

            bool scrittureabilitate = t.abilitaScrittureUT(rEst);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");

            Assert.AreEqual(0, dsEP.Tables["epaccvar"]._Filter(null).Length, "Non ci sono variazioni ai mov di budget");

            object idepacc1 = estimDet1["idepacc"];

            //CONTROLLO NUMERO IMPEGNI DI BUDGET
            int countNepexp2019 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2019)).Length;
            Assert.AreEqual(1, countNepexp2019, "E' presente un impegno di budget del 2019");
            int countNepexp2018 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2018)).Length;
            Assert.AreEqual(0, countNepexp2018, "Non ci sono impegni di budget del 2018");

            //CONTROLLO PRIMO IMPEGNO DI BUDGET
            DataRow[] rEpexp = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2019));
            DataRow dr1_epexp = rEpexp[0];
            DataRow[] rEpexpeyear = dsEP.Tables["epexpyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepexp", dr1_epexp["idepexp"]));
            DataRow dr1_epexpyear = rEpexpeyear[0];
            Assert.AreEqual("caso fatture da emettere", dr1_epexp["description"],  "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(1200.00M, dr1_epexpyear["amount"],  "L'importo del mov.budget è corrispondente");
            Assert.AreEqual("19000200010005000100030008", dr1_epexpyear["idacc"],  "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual("000100030003000100010036", dr1_epexpyear["idupb"],  "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual("000600010005000100030008", dr1_epexp["idaccmotive"],  "La causale del mov.budget è corrispondente");

            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"],2018, 86589,2018,5200m);
            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019)).Length;
            Assert.AreEqual(0, countNepacc2019, "E' presente un accertamento di budget del 2019");
            int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
            Assert.AreEqual(1, countNepacc2018, "E' presente un accertamento di budget del 2018");

            //CONTROLLO PRIMO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO 2019
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc1));
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc1));
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            Assert.AreEqual("caso fatture da emettere", dr1_epacc["description"], "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(0.00m, dr1_epaccyear["amount"], "L'importo del mov.budget è corrispondente");
            Assert.AreEqual("19000100010001000100030005", dr1_epaccyear["idacc"], "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual("000100030003000100010036", dr1_epaccyear["idupb"], "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual("000700010001000100030005", dr1_epacc["idaccmotive"], "La causale del mov.budget è corrispondente");

            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            var tEntrydetail = dsEP.Tables["entrydetail"];
            var rEntry = dsEP.Tables["entry"].Rows[0];
            var date_doc_colleg = new DateTime(2018, 12, 31);
            var date_contab = new DateTime(2019, 10, 27);
            Assert.AreEqual("caso fatture da emettere 5", rEntry["description"], "La descrizione della scrittura è corrispondente");
            Assert.AreEqual("C.A. CA_COLLEGABILE 18/38", rEntry["doc"], "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(date_doc_colleg, rEntry["docdate"], "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(date_contab, rEntry["adate"], "La data contabile della scrittura è corrispondente");
            //PRIMO DETTAGLIO SCRITTURA
            var descr1 =
                 "Contratto Attivo CA_COLLEGABILE 18/38dett. 2- caso fatture da emettere";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1);
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(descr1, EntryDetail1["description"], "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("19000200010005000100030008", EntryDetail1["idacc"], "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("000100030003000100010036", EntryDetail1["idupb"], "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(94626, EntryDetail1["idreg"], "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("000600010005000100030008", EntryDetail1["idaccmotive"], "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idepexp"], dr1_epexp["idepexp"]);
            Assert.AreEqual(EntryDetail1["idrelated"], dr1_epexp["idrelated"]);
            //SECONDO DETTAGLIO SCRITTURA
            var descr2 =
                "Contratto attivo CA_COLLEGABILE n.38 / 2018 dett. 2";
            q filterEDetail2 = q.eq("description", descr2);
            var EntryDetail2Rows = tEntrydetail._Filter(filterEDetail2);
            var EntryDetail2 = EntryDetail2Rows[0];
            Assert.AreEqual(descr2, EntryDetail2["description"], "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("19000300020002000100090005", EntryDetail2["idacc"], "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("000100030003000100010036", EntryDetail2["idupb"], "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(94626, EntryDetail2["idreg"], "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("000600010005000100030008", EntryDetail2["idaccmotive"], "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idepacc"], dr1_epacc["idepacc"]);
            Assert.AreEqual(EntryDetail2["idrelated"], dr1_epacc["idrelated"]);
            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            Assert.AreEqual(1, dsEP.Tables["entry"]._Filter(q.eq("yentry", 2019)).Length, "E' presente una scrittura");
            //CONTROLLO DETTAGLI SCRITTURA ESERCIZIO 2019
            Assert.AreEqual(2, dsEP.Tables["entrydetail"]._Filter(q.eq("nentry", rEntry["nentry"])).Length, "Sono presenti sette dettagli relativi alla scrittura");
            var avere = (decimal)dsEP.Tables["entrydetail"]._Filter(q.gt("amount", 0) & q.eq("nentry", rEntry["nentry"])).GetSum<decimal>("amount");
            Assert.AreEqual(1200.00m, avere, "Avere corrispondente");
        }

        [TestMethod]
        public void Test2_estimate_2018_sostituzione2018_CollFattura2()
        {
            // 1.2
            var t = new TestHelp(new DateTime(2018, 12, 31));
            q filterEst = q.eq("idestimkind", "CA_COLLEGABILE") & q.eq("yestim", 2018) & q.eq("nestim", 17);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            DataRow rEst = tEstimate.Rows[0];
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rEst, false);
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst);
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreEqual(2, nEstDet, "Il contratto ha 2 dettagli");

            DataRow estimDet1 = tEstimateDetail.Rows[0];
            // 
            object idepacc1 = estimDet1["idepacc"];
           
            //GENERO GLI ACCERTAMENTI/IMPEGNI CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);
            checkNoRules(regole);
            var dsEP = t.getEpData(t.testConn, rEst);

            //CONTROLLO VARIAZIONE 
            t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"],2018, 86560,-30m,2018);

            //CONTROLLO NUMERO IMPEGNI DI BUDGET
            int countNepexp2019 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2019)).Length;
            Assert.AreEqual(0, countNepexp2019, "Non sono presenti impegni  di budget del 2019");
            int countNepexp2018 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2018)).Length;
            Assert.AreEqual(0, countNepexp2018, "Non ci sono impegni di budget del 2018");

            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019)).Length;
            Assert.AreEqual(0, countNepacc2019, "Non ci sono accertamenti di budget del 2019");
            int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
            Assert.AreEqual(1, countNepacc2018, "E' presente un accertamento di budget del 2018");

            //CONTROLLO PRIMO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO 2019
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc1));
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2018) & q.eq("idepacc", idepacc1));
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            Assert.AreEqual(dr1_epacc["description"], "sostituzione nell'anno V2", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epaccyear["amount"], 110.00m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idacc"], "18000100010001000100030005", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idupb"], "000100030006000100010139", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["idaccmotive"], "000700010001000100030005", "La causale del mov.budget è corrispondente");

        }

        [TestMethod]
        public void Test2_estimate_2019_sostituzione2019_ConFattura1()
        {
            // 2.1
            var t = new TestHelp(new DateTime(2019, 12, 31));
            q filterEst = q.eq("idestimkind", "CA_COLLEGABILE") & q.eq("yestim", 2019) & q.eq("nestim", 1);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            DataRow rEst = tEstimate.Rows[0];
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rEst, false);
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst);
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreEqual(2, nEstDet, "Il contratto ha 2 dettagli");

            // 207716
            DataRow estimDet1 = tEstimateDetail.Rows[0];
            object idepacc1 = tEstimateDetail.Rows[0]["idepacc"];
          
            //GENERO GLI ACCERTAMENTI/IMPEGNI CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);
            checkNoRules(regole);
            var dsEP = t.getEpData(t.testConn, rEst);

            Assert.AreEqual(2, dsEP.Tables["epaccvar"]._Filter(null).Length/2, "Sono presenti due variazioni ai mov di budget");
            //CONTROLLO VARIAZIONI
            t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"], 2019, 1716, 100m, 2019,1);
            t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"], 2019, 1716, -100m, 2019,2);

            //CONTROLLO NUMERO IMPEGNI DI BUDGET
            int countNepexp2019 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2019)).Length;
            Assert.AreEqual(0, countNepexp2019, "Non sono presenti impegni  di budget del 2019");
            int countNepexp2018 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2018)).Length;
            Assert.AreEqual(0, countNepexp2018, "Non ci sono impegni di budget del 2018");

            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019)).Length;
            Assert.AreEqual(1, countNepacc2019, "Non ci sono accertamenti di budget del 2019");
            int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
            Assert.AreEqual(0, countNepacc2018, "Sono presenti 2 accertamenti di budget del 2018");

            //CONTROLLO PRIMO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO 2019
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019) & q.eq("idepacc", idepacc1));
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc1));
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            Assert.AreEqual(dr1_epacc["description"], "fatturato in parte e contabilizzato", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epaccyear["amount"], 100.00m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idacc"], "19000100010005000100010022", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idupb"], "00010002", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["idaccmotive"], "000700010005000100010022", "La causale del mov.budget è corrispondente");

            // CONTROLLO FATTURA COLLEGATA
            DataTable tInvoiceDetail = t.testConn.readTable("invoicedetail", filterEst & q.eq("rownum", 1));
            Assert.AreEqual(1, tInvoiceDetail.Rows.Count, "I dettagli fattura sono collegati al contratto attivo");
            DataRow rInvD = tInvoiceDetail.Rows[0];
            q filterInv = q.eq("idinvkind", rInvD["idinvkind"]) & q.eq("yinv", rInvD["yinv"]) & q.eq("ninv", rInvD["ninv"]);
            t.binaryReplaceSet(filterInv, t.getTableSet(TestHelp.mainObject.invoice));
            DataTable tInvoice = t.testConn.readTable("invoice", filterInv);
            Assert.AreEqual(1, tInvoiceDetail.Rows.Count, "La fattura ha 1 dettaglio");
            DataRow rInv = tInvoice.Rows[0];
            var idrelatedInvD = BudgetFunction.GetIdForDocument(rInvD);
            ProcedureMessageCollection regole2 = t.generaAccertamentiScritture(rInv);
            checkNoRules(regole2);
            var dsEPInv = t.getEpData(t.testConn, rInv);
            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            var tEntrydetail = dsEPInv.Tables["entrydetail"];
            var rEntry = dsEPInv.Tables["entry"].Rows[0];
            var date_doc_colleg = new DateTime(2019, 12, 31);
            var date_contab = new DateTime(2019, 12, 31);
            Assert.AreEqual(rEntry["description"], "fatturato in parte e contabilizzato", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "19/000002", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");
            //PRIMO DETTAGLIO SCRITTURA
            var descr1 =
                 "fatturato in parte e contabilizzato";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1 & q.eq("idacc", "19000100010005000100010022"));
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(EntryDetail1["description"], descr1, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idupb"], "00010002", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idreg"], 10382, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idaccmotive"], "000700010005000100010022", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idepacc"], dr1_epacc["idepacc"]);
            Assert.AreEqual(EntryDetail1["idrelated"], idrelatedInvD);
            //SECONDO DETTAGLIO SCRITTURA
            var descr2 =
                "Fattura FE_VENDITE_amm n.2 / 2019";
            q filterEDetail2 = q.eq("description", descr2);
            var EntryDetail2Rows = tEntrydetail._Filter(filterEDetail2 & q.eq("idacc", "19000400040001000200010001"));
            var EntryDetail2 = EntryDetail2Rows[0];
            Assert.AreEqual(EntryDetail2["description"], descr2, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idupb"], "00010002", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idreg"], 10382, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idaccmotive"], "000700010005000100010022", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idrelated"], idrelatedInvD);
            //TERZO DETTAGLIO SCRITTURA
            var descr3 =
                "Fattura FE_VENDITE_amm n.2 / 2019";
            q filterEDetail3 = q.eq("description", descr3);
            var EntryDetail3Rows = tEntrydetail._Filter(filterEDetail3 & q.eq("idacc", "19000300020002000100090003"));
            var EntryDetail3 = EntryDetail3Rows[0];
            Assert.AreEqual(EntryDetail3["description"], descr3, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail3["idupb"], "00010002", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail3["idreg"], 10382, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail3["idaccmotive"], "000700010005000100010022", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idepacc"], dr1_epacc["idepacc"]);
            Assert.AreEqual(EntryDetail1["idrelated"], idrelatedInvD);
            //QAURTO DETTAGLIO SCRITTURA
            var descr4 =
                "Fattura FE_VENDITE_amm n.2 / 2019";
            q filterEDetail4 = q.eq("description", descr4);
            var EntryDetail4Rows = tEntrydetail._Filter(filterEDetail4 & q.eq("idacc", "19000300020002000100090003"));
            var EntryDetail4 = EntryDetail4Rows[0];
            Assert.AreEqual(EntryDetail4["description"], descr4, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail4["idupb"], "00010002", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail4["idreg"], 10382, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail4["idaccmotive"], "000700010005000100010022", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idepacc"], dr1_epacc["idepacc"]);
            Assert.AreEqual(EntryDetail1["idrelated"], idrelatedInvD);
            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            Assert.AreEqual(1, dsEPInv.Tables["entry"]._Filter(null).Length, "E presente una scrittura");
            //CONTROLLO DETTAGLI SCRITTURA ESERCIZIO 2019
            Assert.AreEqual(4, dsEPInv.Tables["entrydetail"]._Filter(q.eq("nentry", rEntry["nentry"])).Length, "Sono presenti 4 dettagli relativi alla scrittura della fattura");
            var avere = (decimal)dsEPInv.Tables["entrydetail"]._Filter(q.gt("amount", 0) & q.eq("nentry", rEntry["nentry"])).GetSum<decimal>("amount");
            Assert.AreEqual(122m, avere, "Avere corrispondente");

        }

        [TestMethod]
        public void Test2_estimate_2019_sostituzione2019_ConFattura2()
        {
            // 2.2
            var t = new TestHelp(new DateTime(2019, 12, 31));
            q filterEst = q.eq("idestimkind", "CA_COLLEGABILE") & q.eq("yestim", 2019) & q.eq("nestim", 2);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            DataRow rEst = tEstimate.Rows[0];
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rEst, false);
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst);
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreEqual(4, nEstDet, "Il contratto ha 4 dettagli");

            // 207718
            DataRow estimDet1 = tEstimateDetail.Rows[0];
            object idepacc1 = tEstimateDetail.Rows[0]["idepacc"];
            // 207720
            object idepacc2 = tEstimateDetail.Rows[1]["idepacc"];

            //GENERO GLI ACCERTAMENTI/IMPEGNI CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rEst);

            Assert.AreEqual(2, dsEP.Tables["epaccvar"]._Filter(null).Length/2, "Sono presenti due variazioni ai mov di budget");
            //CONTROLLO VARIAZIONI
            t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"], 2019, 1718, -136.07m,2019);
            t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"], 2019, 1717, -136.07m,2019);

            //CONTROLLO NUMERO IMPEGNI DI BUDGET
            int countNepexp2019 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2019)).Length;
            Assert.AreEqual(0, countNepexp2019, "Non sono presenti impegni  di budget del 2019");
            int countNepexp2018 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2018)).Length;
            Assert.AreEqual(0, countNepexp2018, "Non ci sono impegni di budget del 2018");

            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019)).Length;
            Assert.AreEqual(2, countNepacc2019, "Ci sono 2 accertamenti di budget del 2019");
            int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
            Assert.AreEqual(0, countNepacc2018, "Non ci sono accertamenti di budget del 2018");

            //CONTROLLO PRIMO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO 2019
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019) & q.eq("idepacc", idepacc2));
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc2));
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            Assert.AreEqual(dr1_epacc["description"], "fatturato in parte e contabilizzato", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epaccyear["amount"], 136.07m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idacc"], "19000100010005000100010022", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idupb"], "00010002", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["idaccmotive"], "000700010005000100010022", "La causale del mov.budget è corrispondente");

            //CONTROLLO SECONDO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO 2019
            DataRow[] rEpacc2 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019) & q.eq("idepacc", idepacc1));
            DataRow[] rEpaccyear2 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc1));
            DataRow dr2_epacc = rEpacc2[0];
            DataRow dr2_epaccyear = rEpaccyear2[0];
            Assert.AreEqual(dr2_epacc["description"], "fatturato in parte e contabilizzato", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr2_epaccyear["amount"], 300.00m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epaccyear["idacc"], "19000100010005000100010022", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epaccyear["idupb"], "00010002", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epacc["idaccmotive"], "000700010005000100010022", "La causale del mov.budget è corrispondente");

            // CONTROLLO FATTURA COLLEGATA
            DataTable tInvoiceDetail = t.testConn.readTable("invoicedetail", filterEst & q.eq("rownum", 1));
            Assert.AreEqual(1, tInvoiceDetail.Rows.Count, "I dettagli fattura sono collegati al contratto attivo");
            DataRow rInvD = tInvoiceDetail.Rows[0];
            q filterInv = q.eq("idinvkind", rInvD["idinvkind"]) & q.eq("yinv", rInvD["yinv"]) & q.eq("ninv", rInvD["ninv"]);
            t.binaryReplaceSet(filterInv, t.getTableSet(TestHelp.mainObject.invoice));
            DataTable tInvoice = t.testConn.readTable("invoice", filterInv);
            Assert.AreEqual(1, tInvoiceDetail.Rows.Count, "La fattura ha 1 dettaglio");
            DataRow rInv = tInvoice.Rows[0];
            var idrelatedInvD = BudgetFunction.GetIdForDocument(rInvD);
            ProcedureMessageCollection regole2 = t.generaAccertamentiScritture(rInv);
            checkNoRules(regole2);
            var dsEPInv = t.getEpData(t.testConn, rInv);
            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            var tEntrydetail = dsEPInv.Tables["entrydetail"];
            var rEntry = dsEPInv.Tables["entry"].Rows[0];
            var date_doc_colleg = new DateTime(2019, 12, 31);
            var date_contab = new DateTime(2019, 12, 31);
            Assert.AreEqual(rEntry["description"], "fatturato in parte e contabilizzato", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "19/000003", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");
            //PRIMO DETTAGLIO SCRITTURA
            var descr1 =
                 "fatturato in parte e contabilizzato";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1 & q.eq("idacc", "19000100010005000100010022"));
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(EntryDetail1["description"], descr1, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idupb"], "00010002", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idreg"], 10382, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idaccmotive"], "000700010005000100010022", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idepacc"], dr2_epacc["idepacc"]);
            Assert.AreEqual(EntryDetail1["idrelated"], idrelatedInvD);
            //SECONDO DETTAGLIO SCRITTURA
            var descr2 =
                "Fattura FE_VENDITE_amm n.3 / 2019";
            q filterEDetail2 = q.eq("description", descr2);
            var EntryDetail2Rows = tEntrydetail._Filter(filterEDetail2 & q.eq("idacc", "19000400040001000200010001"));
            var EntryDetail2 = EntryDetail2Rows[0];
            Assert.AreEqual(EntryDetail2["description"], descr2, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idupb"], "00010002", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idreg"], 10382, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idaccmotive"], "000700010005000100010022", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idrelated"], idrelatedInvD);
            //TERZO DETTAGLIO SCRITTURA
            var descr3 =
                "Fattura FE_VENDITE_amm n.3 / 2019";
            q filterEDetail3 = q.eq("description", descr3);
            var EntryDetail3Rows = tEntrydetail._Filter(filterEDetail3 & q.eq("idacc", "19000300020002000100090003"));
            var EntryDetail3 = EntryDetail3Rows[0];
            Assert.AreEqual(EntryDetail3["description"], descr3, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail3["idupb"], "00010002", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail3["idreg"], 10382, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail3["idaccmotive"], "000700010005000100010022", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idepacc"], dr2_epacc["idepacc"]);
            Assert.AreEqual(EntryDetail1["idrelated"], idrelatedInvD);
            //QUARTO DETTAGLIO SCRITTURA
            var descr4 =
                "Fattura FE_VENDITE_amm n.3 / 2019";
            q filterEDetail4 = q.eq("description", descr4);
            var EntryDetail4Rows = tEntrydetail._Filter(filterEDetail4 & q.eq("idacc", "19000300020002000100090003"));
            var EntryDetail4 = EntryDetail4Rows[0];
            Assert.AreEqual(EntryDetail4["description"], descr4, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail4["idupb"], "00010002", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail4["idreg"], 10382, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail4["idaccmotive"], "000700010005000100010022", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idrelated"], idrelatedInvD);
            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            Assert.AreEqual(1, dsEPInv.Tables["entry"]._Filter(null).Length, "E presente una scrittura");
            //CONTROLLO DETTAGLI SCRITTURA ESERCIZIO 2019
            Assert.AreEqual(4, dsEPInv.Tables["entrydetail"]._Filter(q.eq("nentry", rEntry["nentry"])).Length, "Sono presenti 4 dettagli relativi alla scrittura della fattura");
            var avere = (decimal)dsEPInv.Tables["entrydetail"]._Filter(q.gt("amount", 0) & q.eq("nentry", rEntry["nentry"])).GetSum<decimal>("amount");
            Assert.AreEqual(200m, avere, "Avere corrispondente");
        }

        [TestMethod]
        public void Test2_estimate_2019_sostituzione2019_ConFattura3()
        {
            // 2.3
            var t = new TestHelp(new DateTime(2019, 12, 31));
            q filterEst = q.eq("idestimkind", "CA_COLLEGABILE") & q.eq("yestim", 2019) & q.eq("nestim", 3);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            DataRow rEst = tEstimate.Rows[0];
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rEst, false);
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst);
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreEqual(4, nEstDet, "Il contratto ha 2 dettagli");

            // 207722
            DataRow estimDet1 = tEstimateDetail.Rows[0];
            object idepacc1 = tEstimateDetail.Rows[0]["idepacc"];
            // 207724
            object idepacc2 = tEstimateDetail.Rows[1]["idepacc"];

            //GENERO GLI ACCERTAMENTI/IMPEGNI CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rEst);

            Assert.AreEqual(3, dsEP.Tables["epaccvar"]._Filter(null).Length/2, "Sono presenti 3 variazioni ai mov di budget");

            //CONTROLLO VARIAZIONI
            t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"], 2019, 1720,-200m,2019);
            t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"], 2019, 1719, 336.07m, 2019,1);
            t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"], 2019, 1719, -200m, 2019,2);
            
            //CONTROLLO NUMERO IMPEGNI DI BUDGET
            int countNepexp2019 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2019)).Length;
            Assert.AreEqual(0, countNepexp2019, "Non sono presenti impegni  di budget del 2019");
            int countNepexp2018 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2018)).Length;
            Assert.AreEqual(0, countNepexp2018, "Non ci sono impegni di budget del 2018");

            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019)).Length;
            Assert.AreEqual(2, countNepacc2019, "Ci sono 2 accertamenti di budget del 2019");
            int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
            Assert.AreEqual(0, countNepacc2018, "Non ci sono accertamenti di budget del 2018");

            //CONTROLLO PRIMO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO 2019
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019) & q.eq("idepacc", idepacc2));
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc2));
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            Assert.AreEqual(dr1_epacc["description"], "fatturato in parte e contabilizzato", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epaccyear["amount"], 200.00m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idacc"], "19000100010005000100010022", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idupb"], "00010002", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["idaccmotive"], "000700010005000100010022", "La causale del mov.budget è corrispondente");

            //CONTROLLO SECONDO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO 2019
            DataRow[] rEpacc2 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019) & q.eq("idepacc", idepacc1));
            DataRow[] rEpaccyear2 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc1));
            DataRow dr2_epacc = rEpacc2[0];
            DataRow dr2_epaccyear = rEpaccyear2[0];
            Assert.AreEqual(dr2_epacc["description"], "fatturato in parte e contabilizzato", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr2_epaccyear["amount"], 163.93m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epaccyear["idacc"], "19000100010005000100010022", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epaccyear["idupb"], "00010002", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epacc["idaccmotive"], "000700010005000100010022", "La causale del mov.budget è corrispondente");

            q filterEpacc2 = q.eq("nphase", 2) & q.eq("yepacc", 2019) & q.eq("idepacc", idepacc1);
            DataTable tEpaccView = t.testConn.readTable("epaccview", filterEpacc2);
            DataRow rEpView = tEpaccView.Rows[0];
            decimal totCrediti = (decimal)rEpView["totalcredit"];
            decimal totDispRicavi = (decimal)rEpView["revenueavailable"];
            Assert.AreEqual(300.00m, totCrediti, "Crediti totali corrispondenti");
            Assert.AreEqual(0.00m, totDispRicavi, "Disponibile per ricavi corrispondente");

            // CONTROLLO FATTURA COLLEGATA
            DataTable tInvoiceDetail = t.testConn.readTable("invoicedetail", filterEst & q.eq("rownum", 1));
            Assert.AreEqual(1, tInvoiceDetail.Rows.Count, "I dettagli fattura sono collegati al contratto attivo");
            DataRow rInvD = tInvoiceDetail.Rows[0];
            q filterInv = q.eq("idinvkind", rInvD["idinvkind"]) & q.eq("yinv", rInvD["yinv"]) & q.eq("ninv", rInvD["ninv"]);
            t.binaryReplaceSet(filterInv, t.getTableSet(TestHelp.mainObject.invoice));
            DataTable tInvoice = t.testConn.readTable("invoice", filterInv);
            Assert.AreEqual(1, tInvoiceDetail.Rows.Count, "La fattura ha 1 dettaglio");
            DataRow rInv = tInvoice.Rows[0];
            var idrelatedInvD = BudgetFunction.GetIdForDocument(rInvD);
            ProcedureMessageCollection regole2 = t.generaAccertamentiScritture(rInv);
            if (regole2 != null)
                Assert.AreEqual(0, regole2.Count, "Non scatta nessuna regola");
            var dsEPInv = t.getEpData(t.testConn, rInv);
            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            var tEntrydetail = dsEPInv.Tables["entrydetail"];
            var rEntry = dsEPInv.Tables["entry"].Rows[0];
            var date_doc_colleg = new DateTime(2019, 12, 31);
            var date_contab = new DateTime(2019, 12, 31);
            Assert.AreEqual(rEntry["description"], "fatturato in parte e contabilizzato", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "19/000004", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");
            //PRIMO DETTAGLIO SCRITTURA
            var descr1 =
                 "fatturato in parte e contabilizzato";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1 & q.eq("idacc", "19000100010005000100010022"));
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(EntryDetail1["description"], descr1, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idupb"], "00010002", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idreg"], 112552, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idaccmotive"], "000700010005000100010022", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idepacc"], dr2_epacc["idepacc"]);
            Assert.AreEqual(EntryDetail1["idrelated"], idrelatedInvD);
            //SECONDO DETTAGLIO SCRITTURA
            var descr2 =
                "Fattura FE_VENDITE_amm n.4 / 2019";
            q filterEDetail2 = q.eq("description", descr2);
            var EntryDetail2Rows = tEntrydetail._Filter(filterEDetail2 & q.eq("idacc", "19000400040001000200010001"));
            var EntryDetail2 = EntryDetail2Rows[0];
            Assert.AreEqual(EntryDetail2["description"], descr2, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idupb"], "00010002", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idreg"], 112552, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idaccmotive"], "000700010005000100010022", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idrelated"], idrelatedInvD);
            //TERZO DETTAGLIO SCRITTURA
            var descr3 =
                "Fattura FE_VENDITE_amm n.4 / 2019";
            q filterEDetail3 = q.eq("description", descr3);
            var EntryDetail3Rows = tEntrydetail._Filter(filterEDetail3 & q.eq("idacc", "19000300020002000100090003"));
            var EntryDetail3 = EntryDetail3Rows[0];
            Assert.AreEqual(EntryDetail3["description"], descr3, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail3["idupb"], "00010002", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail3["idreg"], 112552, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail3["idaccmotive"], "000700010005000100010022", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idepacc"], dr2_epacc["idepacc"]);
            Assert.AreEqual(EntryDetail1["idrelated"], idrelatedInvD);
            //QUARTO DETTAGLIO SCRITTURA
            var descr4 =
                "Fattura FE_VENDITE_amm n.4 / 2019";
            q filterEDetail4 = q.eq("description", descr4);
            var EntryDetail4Rows = tEntrydetail._Filter(filterEDetail4 & q.eq("idacc", "19000300020002000100090003"));
            var EntryDetail4 = EntryDetail4Rows[0];
            Assert.AreEqual(EntryDetail4["description"], descr4, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail4["idupb"], "00010002", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail4["idreg"], 112552, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail4["idaccmotive"], "000700010005000100010022", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idrelated"], idrelatedInvD);
            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            Assert.AreEqual(1, dsEPInv.Tables["entry"]._Filter(null).Length, "E presente una scrittura");
            //CONTROLLO DETTAGLI SCRITTURA ESERCIZIO 2019
            Assert.AreEqual(4, dsEPInv.Tables["entrydetail"]._Filter(q.eq("nentry", rEntry["nentry"])).Length, "Sono presenti 4 dettagli relativi alla scrittura della fattura");
            var avere = (decimal)dsEPInv.Tables["entrydetail"]._Filter(q.gt("amount", 0) & q.eq("nentry", rEntry["nentry"])).GetSum<decimal>("amount");
            Assert.AreEqual(366m, avere, "Avere corrispondente");
        }

        [TestMethod]
        public void Test2_estimate_2019_sostituzione2019_NonCollFattura() {
	        // 2019: un accertamento (il n. 1732) di 150 ridotto a 100
	        //      un accertamento (il 1733) di 125 ridotto a 10
	        var t = new TestHelp(new DateTime(2019, 12, 31));
	        q filterEst = q.eq("idestimkind", "CA_GENERICO") & q.eq("yestim", 2019) & q.eq("nestim", 28);
	        t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
	        DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
	        DataRow rEst = tEstimate.Rows[0];
	        Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
	        t.binaryCopyEp(rEst, false);
	        DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst);
	        int nEstDet = tEstimateDetail.Rows.Count;
	        Assert.AreEqual(4, nEstDet, "Il contratto ha 4 dettagli");

	        // 207811 nepacc 1732
	        object idepacc1 = tEstimateDetail.Rows[0]["idepacc"];
	        // 207812 nepacc 1733
	        object idepacc2 = tEstimateDetail.Rows[1]["idepacc"];

	        //GENERO GLI ACCERTAMENTI/IMPEGNI CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
	        ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);
	        if (regole != null)
		        Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
	        var dsEP = t.getEpData(t.testConn, rEst);

            bool scrittureabilitate = t.abilitaScrittureUT(rEst);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");

	        decimal sumVar = MetaData.SumColumn(dsEP.Tables["epexpvar"], "amount");
	        Assert.AreEqual(0, sumVar, "Non ci sono variazioni agli impegni di budget o la somma è 0");

	        //CONTROLLO VARIAZIONI
	        t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"], 2019, 1733, -115m, 2019);
	        t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"], 2019, 1732, -50m, 2019);

	        //CONTROLLO NUMERO IMPEGNI DI BUDGET
	        int countNepexp2019 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2019)).Length;
	        Assert.AreEqual(0, countNepexp2019, "Non sono presenti impegni  di budget del 2019");
	        int countNepexp2018 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2018)).Length;
	        Assert.AreEqual(0, countNepexp2018, "Non ci sono impegni di budget del 2018");

	        //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
	        int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019)).Length;
	        Assert.AreEqual(2, countNepacc2019, "Ci sono 2 accertamenti di budget del 2019");
	        int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
	        Assert.AreEqual(0, countNepacc2018, "Non ci sono accertamenti di budget del 2018");

	        //CONTROLLO PRIMO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO 2019
	        DataRow[] rEpacc = dsEP.Tables["epacc"]
		        ._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019) & q.eq("idepacc", idepacc2));
	        DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc2));
	        DataRow dr1_epacc = rEpacc[0];
	        DataRow dr1_epaccyear = rEpaccyear[0];
	        Assert.AreEqual(dr1_epacc["description"], "test 15477 ", "La descrizione del mov.budget  è corrispondente");
	        Assert.AreEqual(dr1_epaccyear["amount"], 125.00m, "L'importo del mov.budget è corrispondente");
	        Assert.AreEqual(dr1_epaccyear["idacc"], "19000100010005000100010022",
		        "Il n.conto del mov.budget è corrispondente");
	        Assert.AreEqual(dr1_epaccyear["idupb"], "000100030002000300010047",
		        "L'UPB del mov.budget è corrispondente");
	        Assert.AreEqual(dr1_epacc["idaccmotive"], "000700010005000100010022",
		        "La causale del mov.budget è corrispondente");

	        //CONTROLLO SECONDO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO 2019
	        DataRow[] rEpacc2 = dsEP.Tables["epacc"]
		        ._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019) & q.eq("idepacc", idepacc1));
	        DataRow[] rEpaccyear2 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc1));
	        DataRow dr2_epacc = rEpacc2[0];
	        DataRow dr2_epaccyear = rEpaccyear2[0];
	        Assert.AreEqual(dr2_epacc["description"], "test 15477 ", "La descrizione del mov.budget  è corrispondente");
	        Assert.AreEqual(dr2_epaccyear["amount"], 150.00m, "L'importo del mov.budget è corrispondente");
	        Assert.AreEqual(dr2_epaccyear["idacc"], "19000100010005000100010022",
		        "Il n.conto del mov.budget è corrispondente");
	        Assert.AreEqual(dr2_epaccyear["idupb"], "00010002", "L'UPB del mov.budget è corrispondente");
	        Assert.AreEqual(dr2_epacc["idaccmotive"], "000700010005000100010022",
		        "La causale del mov.budget è corrispondente");

	        //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
	        var tEntrydetail = dsEP.Tables["entrydetail"];
	        var rEntry = dsEP.Tables["entry"].Rows[0];
	        var date_doc_colleg = new DateTime(2019, 12, 31);
	        var date_contab = new DateTime(2019, 12, 31);
	        Assert.AreEqual(rEntry["description"], "test 15477 ", "La descrizione della scrittura è corrispondente");
	        Assert.AreEqual(rEntry["doc"], "C.A. CA_GENERICO 19/28",
		        "La descrizione del documento collegato alla scrittura è corrispondente");
	        Assert.AreEqual(rEntry["docdate"], date_doc_colleg,
		        "La data del doc.collegato alla scrittura è corrispondente");
	        Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");
	        //PRIMO DETTAGLIO SCRITTURA
	        var descr1 =
		        "Contratto Attivo CA_GENERICO 19/28 dett. 1- test 15477 ";
	        q filterEDetail1 = q.eq("description", descr1);
	        var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1 & q.eq("idacc", "19000100010005000100010022"));
	        var EntryDetail1 = EntryDetail1Rows[0];
	        Assert.AreEqual(EntryDetail1["description"], descr1,
		        "La descrizione del dettaglio della scrittura è corrispondente");
	        Assert.AreEqual(EntryDetail1["idupb"], "00010002", "L'UPB del dettaglio della scrittura è corrispondente");
	        Assert.AreEqual(EntryDetail1["idreg"], 112387, "Il cliente del dettaglio della scrittura è corrispondente");
	        Assert.AreEqual(EntryDetail1["idaccmotive"], "000700010005000100010022",
		        "La causale del dettaglio della scrittura è corrispondente");
	        Assert.AreEqual(EntryDetail1["idepacc"], dr2_epacc["idepacc"]);
	        Assert.AreEqual(EntryDetail1["idrelated"], dr2_epacc["idrelated"]);
	        //SECONDO DETTAGLIO SCRITTURA
	        var descr2 =
		        "Contratto attivo CA_GENERICO n.28 / 2019 n° 1";
	        q filterEDetail2 = q.eq("description", descr2);
	        var EntryDetail2Rows = tEntrydetail._Filter(filterEDetail2 & q.eq("idacc", "19000300020002000100090003"));
	        var EntryDetail2 = EntryDetail2Rows[0];
	        Assert.AreEqual(EntryDetail2["description"], descr2,
		        "La descrizione del dettaglio della scrittura è corrispondente");
	        Assert.AreEqual(EntryDetail2["idupb"], "00010002", "L'UPB del dettaglio della scrittura è corrispondente");
	        Assert.AreEqual(EntryDetail2["idreg"], 112387, "Il cliente del dettaglio della scrittura è corrispondente");
	        Assert.AreEqual(EntryDetail2["idaccmotive"], "000700010005000100010022",
		        "La causale del dettaglio della scrittura è corrispondente");
	        Assert.AreEqual(EntryDetail2["idepacc"], dr2_epacc["idepacc"]);
	        Assert.AreEqual(EntryDetail2["idrelated"], dr2_epacc["idrelated"]);
	        //TERZO DETTAGLIO SCRITTURA
	        var descr3 =
		        "Contratto Attivo CA_GENERICO 19/28 dett. 2- dett 2";
	        q filterEDetail3 = q.eq("description", descr3);
	        var EntryDetail3Rows = tEntrydetail._Filter(filterEDetail3 & q.eq("idacc", "19000100010005000100010022"));
	        var EntryDetail3 = EntryDetail3Rows[0];
	        Assert.AreEqual(EntryDetail3["description"], descr3,
		        "La descrizione del dettaglio della scrittura è corrispondente");
	        Assert.AreEqual(EntryDetail3["idupb"], "000100030002000300010047",
		        "L'UPB del dettaglio della scrittura è corrispondente");
	        Assert.AreEqual(EntryDetail3["idreg"], 112387, "Il cliente del dettaglio della scrittura è corrispondente");
	        Assert.AreEqual(EntryDetail3["idaccmotive"], "000700010005000100010022",
		        "La causale del dettaglio della scrittura è corrispondente");
	        Assert.AreEqual(EntryDetail3["idepacc"], dr1_epacc["idepacc"]);
	        Assert.AreEqual(EntryDetail3["idrelated"], dr1_epacc["idrelated"]);
	        //QUARTO DETTAGLIO SCRITTURA
	        var descr4 =
		        "Contratto attivo CA_GENERICO n.28 / 2019 n° 2";
	        q filterEDetail4 = q.eq("description", descr4);
	        var EntryDetail4Rows = tEntrydetail._Filter(filterEDetail4 & q.eq("idacc", "19000300020002000100090003"));
	        var EntryDetail4 = EntryDetail4Rows[0];
	        Assert.AreEqual(EntryDetail4["description"], descr4,
		        "La descrizione del dettaglio della scrittura è corrispondente");
	        Assert.AreEqual(EntryDetail4["idupb"], "000100030002000300010047",
		        "L'UPB del dettaglio della scrittura è corrispondente");
	        Assert.AreEqual(EntryDetail4["idreg"], 112387, "Il cliente del dettaglio della scrittura è corrispondente");
	        Assert.AreEqual(EntryDetail4["idaccmotive"], "000700010005000100010022",
		        "La causale del dettaglio della scrittura è corrispondente");
	        Assert.AreEqual(EntryDetail4["idepacc"], dr1_epacc["idepacc"]);
	        Assert.AreEqual(EntryDetail4["idrelated"], dr1_epacc["idrelated"]);

	        //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
	        Assert.AreEqual(1, dsEP.Tables["entry"]._Filter(null).Length, "E' presente una scrittura");
	        //CONTROLLO DETTAGLI SCRITTURA ESERCIZIO 2019
	        Assert.AreEqual(4, dsEP.Tables["entrydetail"]._Filter(q.eq("nentry", rEntry["nentry"])).Length,
		        "Sono presenti 4 dettagli relativi alla scrittura");
	        var avere = (decimal) dsEP.Tables["entrydetail"]
		        ._Filter(q.gt("amount", 0) & q.eq("nentry", rEntry["nentry"])).GetSum<decimal>("amount");
	        Assert.AreEqual(110m, avere, "Avere corrispondente");
        }

        [TestMethod]
        public void Test2_estimate_2019_sostituzione2019_NonCollFattura2()
        {
            // 
            var t = new TestHelp(new DateTime(2019, 12, 31));
            q filterEst = q.eq("idestimkind", "CA_GENERICO") & q.eq("yestim", 2019) & q.eq("nestim", 29);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            DataRow rEst = tEstimate.Rows[0];
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rEst, false);
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst);
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreEqual(2, nEstDet, "Il contratto ha 2 dettagli");

            // 207862 nepacc 1738
            object idepacc1 = tEstimateDetail.Rows[0]["idepacc"];

            //GENERO GLI ACCERTAMENTI/IMPEGNI CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rEst);

            bool scrittureabilitate = t.abilitaScrittureUT(rEst);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");

            Assert.AreEqual(1, dsEP.Tables["epaccvar"]._Filter(null).Length / 2, "E' presente una variazione ai mov di budget");

            //CONTROLLO VARIAZIONI
            t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"], 2019, 1738, -40m, 2019);

            //CONTROLLO NUMERO IMPEGNI DI BUDGET
            int countNepexp2019 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2019)).Length;
            Assert.AreEqual(0, countNepexp2019, "Non sono presenti impegni  di budget del 2019");
            int countNepexp2018 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2018)).Length;
            Assert.AreEqual(0, countNepexp2018, "Non ci sono impegni di budget del 2018");

            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019)).Length;
            Assert.AreEqual(1, countNepacc2019, "E' presente un accertamento di budget del 2019");
            int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
            Assert.AreEqual(0, countNepacc2018, "Non ci sono accertamenti di budget del 2018");

            //CONTROLLO PRIMO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO 2019
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019) & q.eq("idepacc", idepacc1));
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc1));
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            Assert.AreEqual(dr1_epacc["description"], "test sost dell'anno", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epaccyear["amount"], 100.00m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idacc"], "19000100010005000100010022", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idupb"], "00010002", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["idaccmotive"], "000700010005000100010022", "La causale del mov.budget è corrispondente");
        
            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            var tEntrydetail = dsEP.Tables["entrydetail"];
            var rEntry = dsEP.Tables["entry"].Rows[0];
            var date_doc_colleg = new DateTime(2019, 12, 31);
            var date_contab = new DateTime(2019, 12, 31);
            Assert.AreEqual(rEntry["description"], "test", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "C.A. CA_GENERICO 19/29", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");
            //PRIMO DETTAGLIO SCRITTURA
            var descr1 =
                 "Contratto Attivo CA_GENERICO 19/29 dett. 1- test sost dell'anno";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1 & q.eq("idacc", "19000100010005000100010022"));
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(EntryDetail1["description"], descr1, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idupb"], "00010002", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idreg"], 112387, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idaccmotive"], "000700010005000100010022", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idepacc"], dr1_epacc["idepacc"]);
            Assert.AreEqual(EntryDetail1["idrelated"], dr1_epacc["idrelated"]);
            //SECONDO DETTAGLIO SCRITTURA
            var descr2 =
                "Contratto attivo CA_GENERICO n.29 / 2019 n° 1";
            q filterEDetail2 = q.eq("description", descr2);
            var EntryDetail2Rows = tEntrydetail._Filter(filterEDetail2 & q.eq("idacc", "19000300020002000100090003"));
            var EntryDetail2 = EntryDetail2Rows[0];
            Assert.AreEqual(EntryDetail2["description"], descr2, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idupb"], "00010002", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idreg"], 112387, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idaccmotive"], "000700010005000100010022", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idepacc"], dr1_epacc["idepacc"]);
            Assert.AreEqual(EntryDetail2["idrelated"], dr1_epacc["idrelated"]);
           
            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            Assert.AreEqual(1, dsEP.Tables["entry"]._Filter(null).Length, "E' presente una scrittura");
            //CONTROLLO DETTAGLI SCRITTURA ESERCIZIO 2019
            Assert.AreEqual(2, dsEP.Tables["entrydetail"]._Filter(q.eq("nentry", rEntry["nentry"])).Length, "Sono presenti 4 dettagli relativi alla scrittura");
            var avere = (decimal)dsEP.Tables["entrydetail"]._Filter(q.gt("amount", 0) & q.eq("nentry", rEntry["nentry"])).GetSum<decimal>("amount");
            Assert.AreEqual(60m, avere, "Avere corrispondente");
        }

        [TestMethod]
        public void Test2_estimate_2018_annullo2019_CollFattura_FattEmettere_causaleAnnullo()
        {
            //2018: Acc. di 8000 
            //2019: Acc. di 0 con variazioni di 6000 e -6000
            var t = new TestHelp(new DateTime(2019, 12, 31));
            q filterEst = q.eq("idestimkind", "CA_COLLEGABILE") & q.eq("yestim", 2018) & q.eq("nestim", 48);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);

            DataRow rEst = tEstimate.Rows[0];
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");

            t.binaryCopyEp(rEst, false);
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst);
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreEqual(2, nEstDet, "Il contratto ha 2 dettagli");
            DataRow estimDet1 = tEstimateDetail.Rows[0];
            DataRow estimDet2 = tEstimateDetail.Rows[1];

            //GENERO GLI ACCERTAMENTI/IMPEGNI CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);
            checkNoRules(regole);

            var dsEP = t.getEpData(t.testConn, rEst);

            bool scrittureabilitate = t.abilitaScrittureUT(rEst);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono  abilitate");

            Assert.AreEqual(0, dsEP.Tables["epaccvar"]._Filter(null).Length/2, "Non ci sono variazioni ai mov di budget");

            // 207840
            object idepacc1 = estimDet1["idepacc"];
            object idepacc2 = estimDet2["idepacc"];

            //CONTROLLO NUMERO IMPEGNI DI BUDGET
            int countNepexp = dsEP.Tables["epexp"]._Filter(null).Length;
            Assert.AreEqual(0, countNepexp, "Non ci sono impegni di budget");

            //CONTROLLO IMPORTO INIZIALE ACC DI BUDGET ESERCIZIO 2018
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2018, 86605, 2018, 8000m);
            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019) & q.eq("flagvariation","S")).Length;
            Assert.AreEqual(1, countNepacc2019, "E' presente un accertamento di budget del 2019 di tipo variazione");
            int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
            Assert.AreEqual(1, countNepacc2018, "E' presente un accertamento di budget del 2018");

            //CONTROLLO ACCERTAMENTO DI BUDGET PRESENTE  
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc1));
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc1));
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            Assert.AreEqual("caso fatture da emettere", dr1_epacc["description"], "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual("19000100010001000100030005", dr1_epaccyear["idacc"], "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual("000100020001000300010002", dr1_epaccyear["idupb"], "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual("000700010001000100030005", dr1_epacc["idaccmotive"], "La causale del mov.budget è corrispondente");
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], idepacc1, 2019, 0m);
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], idepacc1, 2018, 8000m);

            //CONTROLLO SECONDO ACCERTAMENTO DI BUDGET PRESENTE  (tipo variazione)
            DataRow[] rEpacc2 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019) & q.eq("idepacc", idepacc2));
            DataRow[] rEpaccyear2 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc2));
            DataRow dr2_epacc = rEpacc2[0];
            DataRow dr2_epaccyear = rEpaccyear2[0];
            Assert.AreEqual("S", dr2_epacc["flagvariation"], "Accertamento di tipo variazione");
            Assert.AreEqual("caso fatture da emettere", dr2_epacc["description"], "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual("19000100010001000100030005", dr2_epaccyear["idacc"], "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual("000100020001000300010002", dr2_epaccyear["idupb"], "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual("000700010001000100030005", dr2_epacc["idaccmotive"], "La causale del mov.budget è corrispondente");
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], idepacc2, 2019, 2000m);


            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            var tEntrydetail = dsEP.Tables["entrydetail"];
            var rEntry = dsEP.Tables["entry"].Rows[0];
            var date_doc_colleg = new DateTime(2018, 12, 31);
            var date_contab = (DateTime) estimDet1["start"];//new DateTime(2019, 11, 3));//data inizio nuovo dettaglio
            Assert.AreEqual("caso fatture da emettere 10", rEntry["description"], "La descrizione della scrittura è corrispondente");
            Assert.AreEqual("C.A. CA_COLLEGABILE 18/48", rEntry["doc"], "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(date_doc_colleg, rEntry["docdate"], "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(date_contab, rEntry["adate"], "La data contabile della scrittura è corrispondente");

            //PRIMO DETTAGLIO SCRITTURA, accertamento di budget 2018 e relativo idrelated
            var descr1 =  "Contratto attivo CA_COLLEGABILE n.48 / 2018 dett. 2";
            q filterEDetail1 = q.gt("amount", 0)& q.eq("yentry",2019)& q.eq("nentry",2183);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1);
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(descr1, EntryDetail1["description"], "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("19000300020002000100090005", EntryDetail1["idacc"], "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("000100020001000300010002", EntryDetail1["idupb"], "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(10382, EntryDetail1["idreg"], "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("000700010001000100030005", EntryDetail1["idaccmotive"], "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idepacc"], idepacc1);
            Assert.AreEqual(EntryDetail1["idrelated"], dr1_epacc["idrelated"]);//estim§CA_COLLEGABILE§2018§48§1


            //SECONDO DETTAGLIO SCRITTURA
            var descr2 =  "Contratto Attivo CA_COLLEGABILE 18/48dett. 2- caso fatture da emettere";
            q filterEDetail2 = q.lt("amount", 0)& q.eq("yentry",2019)& q.eq("nentry",2183);
            var EntryDetail2Rows = tEntrydetail._Filter(filterEDetail2);
            var EntryDetail2 = EntryDetail2Rows[0];
            Assert.AreEqual(descr2, EntryDetail2["description"], "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("19000100010001000100030005", EntryDetail2["idacc"], "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("000100020001000300010002", EntryDetail2["idupb"], "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(10382, EntryDetail2["idreg"], "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("000700010001000100030005", EntryDetail2["idaccmotive"], "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idepacc"], dr2_epacc["idepacc"]);
            Assert.AreEqual(EntryDetail2["idrelated"], dr2_epacc["idrelated"]);//estim§CA_COLLEGABILE§2018§48§1. Il confronto diventa anch inutile perchè so tratta di un conto di ricavo che non verrà epilogato
            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            Assert.AreEqual(1, dsEP.Tables["entry"]._Filter(q.eq("yentry", 2019)).Length, "E' presente una scrittura");
            //CONTROLLO DETTAGLI SCRITTURA ESERCIZIO 2019
            Assert.AreEqual(2, dsEP.Tables["entrydetail"]._Filter(q.eq("nentry", rEntry["nentry"])).Length, "Sono presenti sette dettagli relativi alla scrittura");
            var avere = (decimal)dsEP.Tables["entrydetail"]._Filter(q.gt("amount", 0) & q.eq("nentry", rEntry["nentry"])).GetSum<decimal>("amount");
            Assert.AreEqual(2000.00m, avere, "Avere corrispondente");
        }

        [TestMethod]
        public void Test2_estimate_2018_sostituzione2019_CollFattura_parzCont()
        {
            // 2018: Acc. 86523 di 60, Acc. n 86522 di 75 portato a 15 con var di -60, Acc. n 86521 di 150 portato a 75 con var di -75  
            // 2019: Acc n. 86523 di 60 portato a 0 con 2 var di -36 e -24, Acc. n 86522 di 15 portato a 5 con var di -10
            // 2019 Acc n. 86521 di 75 
            var t = new TestHelp(new DateTime(2019, 12, 31));
            q filterEst = q.eq("idestimkind", "CA_COLLEGABILE") & q.eq("yestim", 2018) & q.eq("nestim", 6);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            DataRow rEst = tEstimate.Rows[0];
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rEst, false);
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst);
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreEqual(9, nEstDet, "Il contratto ha 9 dettagli");

            // 207614 
            object idepacc1 = tEstimateDetail.Rows[0]["idepacc"];
            //207616
            object idepacc2 = tEstimateDetail.Rows[1]["idepacc"];
            //207618
            object idepacc3 = tEstimateDetail.Rows[2]["idepacc"];

            //GENERO GLI ACCERTAMENTI/IMPEGNI CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rEst);

            Assert.AreEqual(5, dsEP.Tables["epaccvar"]._Filter(null).Length / 2, "Sono presenti 5 variazione ai mov di budget");

            //CONTROLLO VARIAZIONI 2018
            t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"], 2018, 86522, -60m, 2018);
            t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"], 2018, 86521, -75m, 2018);
            //CONTROLLO VARIAZIONI 2019
            t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"], 2019, 86523, -36m, 2019,1);
            t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"], 2019, 86523, -24m, 2019,2);
            t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"], 2019, 86522, -10m, 2019);

            //CONTROLLO NUMERO IMPEGNI DI BUDGET
            int countNepexp = dsEP.Tables["epexp"]._Filter(null).Length;
            Assert.AreEqual(0, countNepexp, "Non sono presenti impegni  di budget");
           
            //CONTROLLO IMPORTI INIZIALI ACCERTAMENTI ESERCIZIO 2018
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2018, 86523, 2018, 60m);
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2018, 86522, 2018, 75m);
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2018, 86521, 2018, 150m);
            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019)).Length;
            Assert.AreEqual(0, countNepacc2019, "Non è presente un accertamento di budget del 2019");
            int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
            Assert.AreEqual(3, countNepacc2018, "ci sono 3 accertamenti di budget del 2018");

            //CONTROLLO PRIMO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO 2019
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc3));
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc3));
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            Assert.AreEqual(dr1_epacc["description"], "VERSIONE 1 CA_ COLLEGABILE  parzialmente contabilizzato no fatturato, sostituzioni multiple", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idacc"], "19000100010001000100030005", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idupb"], "000100030001000200010013", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["idaccmotive"], "000700010001000100030005", "La causale del mov.budget è corrispondente");
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2018, 86523, 2019, 60m);

            //CONTROLLO SECONDO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO 2019
            DataRow[] rEpacc2 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc2));
            DataRow[] rEpaccyear2 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc2));
            DataRow dr2_epacc = rEpacc2[0];
            DataRow dr2_epaccyear = rEpaccyear2[0];
            Assert.AreEqual(dr2_epacc["description"], "VERSIONE 1 CA_ COLLEGABILE  parzialmente contabilizzato no fatturato, sostituzioni multiple", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr2_epaccyear["idacc"], "19000100010001000100030005", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epaccyear["idupb"], "000100030001000200010013", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["idaccmotive"], "000700010001000100030005", "La causale del mov.budget è corrispondente");
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2018, 86522, 2019, 15m);

            //CONTROLLO TERZO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO 2019
            DataRow[] rEpacc3 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc1));
            DataRow[] rEpaccyear3 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc1));
            DataRow dr3_epacc = rEpacc3[0];
            DataRow dr3_epaccyear = rEpaccyear3[0];
            Assert.AreEqual(dr3_epacc["description"], "VERSIONE 1 CA_ COLLEGABILE  parzialmente contabilizzato no fatturato, sostituzioni multiple", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr3_epaccyear["idacc"], "19000100010001000100030005", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr3_epaccyear["idupb"], "000100030001000200010013", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr3_epacc["idaccmotive"], "000700010001000100030005", "La causale del mov.budget è corrispondente");
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2018, 86521, 2019, 75m);

        }

        [TestMethod]
        public void Test2_estimate_2018_sostituzione2018_ConFattura_parzCont()
        {
            // 2018: Acc. 86517 di 150 variato a 90 (che va a 0 nel 2019), acc. 86518 di 60 (stesso importo ha nel 2019)
            // 2019: Acc. 1708 di 60 

            var t = new TestHelp(new DateTime(2019, 12, 31));
            q filterEst = q.eq("idestimkind", "CA_COLLEGABILE") & q.eq("yestim", 2018) & q.eq("nestim", 4);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            DataRow rEst = tEstimate.Rows[0];
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rEst, false);
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst);
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreEqual(4, nEstDet, "Il contratto ha 4 dettagli");

            // 207604 
            object idepacc1 = tEstimateDetail.Rows[0]["idepacc"];
            //207606
            object idepacc2 = tEstimateDetail.Rows[1]["idepacc"];
            // NON HA IDEPACC
            object idepacc3 = tEstimateDetail.Rows[2]["idepacc"];
             // 207608
            object idepacc4 = tEstimateDetail.Rows[3]["idepacc"];
            
            var dsEP = t.getEpData(t.testConn, rEst);

            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2019, 1708, 2019, 60m);
            t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"], 2019, 1708, 0m, 2019);

            //GENERO GLI ACCERTAMENTI/IMPEGNI CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);
            checkNoRules(regole);
            dsEP = t.getEpData(t.testConn, rEst);

            Assert.AreEqual(2, dsEP.Tables["epaccvar"]._Filter(q.eq("yvar",2018)).Length, "sono presenti 2 variazioni ai mov di budget");
            
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2019, 1708, 2019, 60m);
            t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"], 2019, 1708, -60m, 2019);//deve annullare l'acc. di budget di tipo variazione



			//CONTROLLO VARIAZIONI 2018
			t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"], 2018, 86517, -60m, 2018);
			t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"], 2018, 86518, 0m, 2018);
			//CONTROLLO VARIAZIONI 2019 (DA VERIFICARE) 
            //t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"], 2018, 86518, -60m, 2019);
			t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"], 2018, 1708, -0m, 2019);
            
			//CONTROLLO NUMERO IMPEGNI DI BUDGET
			int countNepexp = dsEP.Tables["epexp"]._Filter(null).Length;
            Assert.AreEqual(0, countNepexp, "Non sono presenti impegni  di budget");
           
            //CONTROLLO IMPORTI INIZIALI ACCERTAMENTI 2018
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2018, 86518, 2018, 60m);
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2018, 86517, 2018, 150m);

            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019)).Length;
            Assert.AreEqual(1, countNepacc2019, "E' presente un accertamento di budget del 2019");
            int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
            Assert.AreEqual(2, countNepacc2018, "ci sono 2 accertamenti di budget del 2018");

            //CONTROLLO PRIMO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO 2019
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019) & q.eq("idepacc", idepacc4));
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc4));
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            Assert.AreEqual(dr1_epacc["description"], "VERSIONE 1 CA_ COLLEGABILE /2018 parzialmente contabilizzato e fatturato", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idacc"], "19000100010005000100010022", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idupb"], "000100020001000300010002", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["idaccmotive"], "000700010005000100010022", "La causale del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["flagvariation"],"S");
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2019, 1708, 2019, 60m);

            //CONTROLLO SECONDO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO 2019
            DataRow[] rEpacc2 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc2));
            DataRow[] rEpaccyear2 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc2));
            DataRow dr2_epacc = rEpacc2[0];
            DataRow dr2_epaccyear = rEpaccyear2[0];
            Assert.AreEqual(dr2_epacc["description"], "VERSIONE 1 CA_ COLLEGABILE /2018 parzialmente contabilizzato e fatturato", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr2_epaccyear["idacc"], "19000100010005000100010022", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epaccyear["idupb"], "000100020001000300010002", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["idaccmotive"], "000700010005000100010022", "La causale del mov.budget è corrispondente");
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2018, 86518, 2019, 60m);

            //CONTROLLO TERZO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO 2019
            DataRow[] rEpacc3 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc1));
            DataRow[] rEpaccyear3 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc1));
            DataRow dr3_epacc = rEpacc3[0];
            DataRow dr3_epaccyear = rEpaccyear3[0];
            Assert.AreEqual(dr3_epacc["description"], "VERSIONE 1 CA_ COLLEGABILE /2018 parzialmente contabilizzato e fatturato", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr3_epaccyear["idacc"], "19000100010005000100010022", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr3_epaccyear["idupb"], "000100020001000300010002", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr3_epacc["idaccmotive"], "000700010005000100010022", "La causale del mov.budget è corrispondente");
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2018, 86517, 2019, 0m);
        }

        [TestMethod]
        public void Test2_estimate_2018_annullo2019_CollFattura_Rateo()
        {
            // 2018: Acc. 86584 di 147,97
            // 2019: Acc. 86584 di 1742.18 portato a 0, con variazione di -1742.18 
            var t = new TestHelp(new DateTime(2019, 12, 31));
            q filterEst = q.eq("idestimkind", "CA_COLLEGABILE") & q.eq("yestim", 2018) & q.eq("nestim", 33);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            DataRow rEst = tEstimate.Rows[0];
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rEst, false);
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst);
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreEqual(1, nEstDet, "Il contratto ha 1 dettaglio");

            // 207764
            object idepacc1 = tEstimateDetail.Rows[0]["idepacc"];
 
            //GENERO GLI ACCERTAMENTI/IMPEGNI CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);
            checkNoRules(regole);
            var dsEP = t.getEpData(t.testConn, rEst);

            bool scrittureabilitate = t.abilitaScrittureUT(rEst);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");

            Assert.AreEqual(1*2, dsEP.Tables["epaccvar"]._Filter(null).Length, "E' presente una variazione ai mov di budget");
			//CONTROLLO VARIAZIONI 2019
			t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"], 2019, 86584, -5952.03m, 2019);

			//CONTROLLO NUMERO IMPEGNI DI BUDGET
			int countNepexp = dsEP.Tables["epexp"]._Filter(null).Length;
            Assert.AreEqual(0, countNepexp, "Non sono presenti impegni  di budget");
           
            //CONTROLLO IMPORTI INIZIALI ACCERTAMENTI 2018
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2018, 86584, 2018, 147.97m);

            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019)).Length;
            Assert.AreEqual(0, countNepacc2019, "E' presente un accertamento di budget del 2019");
            int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
            Assert.AreEqual(1, countNepacc2018, "E' presente un accertamento di budget del 2018");

            //CONTROLLO PRIMO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO 2019
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc1));
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc1));
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            Assert.AreEqual("caso rateo attivo",dr1_epacc["description"],  "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual("19000100010001000100030005",dr1_epaccyear["idacc"],  "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual("000100030002000300010059",dr1_epaccyear["idupb"],  "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual("000700010001000100030005",dr1_epacc["idaccmotive"],  "La causale del mov.budget è corrispondente");
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2018, 86584, 2019, 1742.18m);

            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            var tEntrydetail = dsEP.Tables["entrydetail"];
            var rEntry = dsEP.Tables["entry"]._Filter(q.eq("yentry",2019))._First();
            Assert.IsNotNull(rEntry,"La scrittura 2019 esiste");

            var date_doc_colleg = new DateTime(2018, 12, 31);
            var date_contab = new DateTime(2019, 10, 27);
            Assert.AreEqual(rEntry["description"], "caso rateo attivo 9", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "C.A. CA_COLLEGABILE 18/33", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");
            //PRIMO DETTAGLIO SCRITTURA
            var descr1 =
                 "Contratto Attivo CA_COLLEGABILE 18/33dett. 1- caso rateo attivo";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1 & q.eq("idacc", "19000100010001000100030005"));
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(EntryDetail1["description"], descr1, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idupb"], "000100030002000300010059", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idreg"], 123711, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idaccmotive"], "000700010001000100030005", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idepacc"], dr1_epacc["idepacc"]);
            Assert.AreEqual(EntryDetail1["idrelated"], dr1_epacc["idrelated"]);
            //SECONDO DETTAGLIO SCRITTURA
            var descr2 =
                "Contratto attivo CA_COLLEGABILE n.33 / 2018 dett. 1";
            q filterEDetail2 = q.eq("description", descr2);
            var EntryDetail2Rows = tEntrydetail._Filter(filterEDetail2 & q.eq("idacc", "19000300030001000100010001"));
            var EntryDetail2 = EntryDetail2Rows[0];
            Assert.AreEqual(EntryDetail2["description"], descr2, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idupb"], "000100030002000300010059", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idreg"], 123711, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idaccmotive"], "000700010001000100030005", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idepacc"], dr1_epacc["idepacc"]);
            Assert.AreEqual(EntryDetail2["idrelated"], dr1_epacc["idrelated"]);
           
            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            Assert.AreEqual(2, dsEP.Tables["entry"]._Filter(null).Length, "Sono presenti due scritture");
            //CONTROLLO DETTAGLI SCRITTURA ESERCIZIO 2019
            Assert.AreEqual(2, dsEP.Tables["entrydetail"]._Filter(q.eq("nentry", rEntry["nentry"])).Length, "Sono presenti 2 dettagli relativi alla scrittura");
            var avere = (decimal)dsEP.Tables["entrydetail"]._Filter(q.gt("amount", 0) & q.eq("nentry", rEntry["nentry"])).GetSum<decimal>("amount");
            Assert.AreEqual(147.97m, avere, "Avere corrispondente");
        }

        [TestMethod]
        public void Test2_estimate_2018_sostituzione2019_CollFattura_Rateo()
        {
            // 2018: Acc. 86585 di 207.77
            // 2019: Acc. 86585 di 2446.38 ridotto a 446.38 con variazione di -2000 
            var t = new TestHelp(new DateTime(2019, 12, 31));
            q filterEst = q.eq("idestimkind", "CA_COLLEGABILE") & q.eq("yestim", 2018) & q.eq("nestim", 34);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            DataRow rEst = tEstimate.Rows[0];
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rEst, false);
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst);
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreEqual(2, nEstDet, "Il contratto ha 2 dettagli");

            // 207766
            object idepacc1 = tEstimateDetail.Rows[0]["idepacc"];

            //GENERO GLI ACCERTAMENTI/IMPEGNI CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);
            checkNoRules(regole);
            var dsEP = t.getEpData(t.testConn, rEst);

            bool scrittureabilitate = t.abilitaScrittureUT(rEst);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");

            Assert.AreEqual(1*2, dsEP.Tables["epaccvar"]._Filter(null).Length, "E' presente una variazione ai mov di budget");
			//CONTROLLO VARIAZIONI 2019
			t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"], 2018, 86585, -2000m, 2019);

			//CONTROLLO NUMERO IMPEGNI DI BUDGET
			int countNepexp = dsEP.Tables["epexp"]._Filter(null).Length;
            Assert.AreEqual(0, countNepexp, "Non sono presenti impegni  di budget");
           
            //CONTROLLO IMPORTI INIZIALI ACCERTAMENTI 2018
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2018, 86585, 2018, 207.77m);

            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019)).Length;
            Assert.AreEqual(0, countNepacc2019, "E' presente un accertamento di budget del 2019");
            int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
            Assert.AreEqual(1, countNepacc2018, "E' presente un accertamento di budget del 2018");

            //CONTROLLO PRIMO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO 2019
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc1));
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc1));
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            Assert.AreEqual("caso rateo attivo",dr1_epacc["description"],  "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual("19000100010001000100030005",dr1_epaccyear["idacc"],  "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual("00010002",dr1_epaccyear["idupb"],  "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual("000700010001000100030005",dr1_epacc["idaccmotive"],  "La causale del mov.budget è corrispondente");
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2018, 86585, 2019, 2446.38m);

            var rEntry = dsEP.Tables["entry"]._Filter(q.eq("yentry",2019));
            Assert.AreEqual(0,rEntry.Length, "Non ci sono scritture");
        }

        [TestMethod]
        public void Test2_estimate_2018_annullo2019_NonCollFattura3()
        {
            //2018:  Acc. n 86614 di 100
            //2019:  Acc. n 1737 di 100, Acc. 86614 di 0
            var t = new TestHelp(new DateTime(2019, 12, 31));
            q filterEst = q.eq("idestimkind", "CA_GENERICO") & q.eq("yestim", 2018) & q.eq("nestim", 61);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            DataRow rEst = tEstimate.Rows[0];
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rEst, false);
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst );
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreEqual(2, nEstDet, "Il contratto ha 2 dettagli");

            // 207858 
            object idepacc1 = tEstimateDetail.Rows[0]["idepacc"];
            // 207860
            object idepacc2 = tEstimateDetail.Rows[1]["idepacc"];
               
            //GENERO LE SCRITTURE E CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);
            checkNoRules(regole);
            var dsEP = t.getEpData(t.testConn, rEst);

            bool scrittureabilitate = t.abilitaScrittureUT(rEst);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");

            //CONTROLLO VARIAZIONI AI MOVIMENTI DI BUDGET
            DataRow[] rEpaccpvar = dsEP.Tables["epaccvar"]._Filter(null);
            Assert.AreEqual(rEpaccpvar.Length, 0, "Non Sono  presenti variazioni");

            //CONTROLLO NUMERO IMPEGNI DI BUDGET
            int countNepexp = dsEP.Tables["epexp"]._Filter(null).Length;
            Assert.AreEqual(0, countNepexp, "Non ci sono impegni  di budget");
           
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2018, 86614, 2018, 100m);
            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019)).Length;
            Assert.AreEqual(1, countNepacc2019, "Non ci sono accertamenti di budget del 2019");
            int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
            Assert.AreEqual(1, countNepacc2018, "E' presente un accertamento di budget del 2018");

            //CONTROLLO PRIMO  ACCERTAMENTO DI BUDGET 
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019) & q.eq("idepacc", idepacc2));
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc2));  
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            Assert.AreEqual(dr1_epacc["description"], "test sost a zero nel 2019", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idacc"], "19000100010005000100010022", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idupb"], "000100010016", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["idaccmotive"], "000700010005000100010022", "La causale del mov.budget è corrispondente");
             t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2019, 1737, 2019, 100m);

            //CONTROLLO SECONDO ACCERTAMENTO DI BUDGET 
            DataRow[] rEpacc2 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc1));
            DataRow[] rEpaccyear2 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc1));
            DataRow dr2_epacc = rEpacc2[0];
            DataRow dr2_epaccyear = rEpaccyear2[0];
            Assert.AreEqual(dr2_epacc["description"], "test sost a zero nel 2019", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr2_epaccyear["idacc"], "19000100010005000100010022", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epaccyear["idupb"], "000100010016", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epacc["idaccmotive"], "000700010005000100010022", "La causale del mov.budget è corrispondente");
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2018, 86614, 2019, 0m);

            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            var tEntrydetail = dsEP.Tables["entrydetail"];
            var rEntry = dsEP.Tables["entry"].Rows[0];
            var date_doc_colleg = new DateTime(2018, 12, 31);
            var date_contab = new DateTime(2019, 11, 02);
            Assert.AreEqual(rEntry["description"], "test sost a zero nel 2019", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "C.A. CA_GENERICO 18/61", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");
            //PRIMO DETTAGLIO SCRITTURA
            var descr1 =
                 "Contratto Attivo CA_GENERICO 18/61dett. 2- test sost a zero nel 2019";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1);
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(EntryDetail1["description"], descr1, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idacc"], "19000100010005000100010022", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idupb"], "000100010016", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idreg"], 112387, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idaccmotive"], "000700010005000100010022", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idepacc"], dr1_epacc["idepacc"]);
            //SECONDO DETTAGLIO SCRITTURA
            var descr2 =
                "Contratto attivo CA_GENERICO n.61 / 2018 dett. 2";
            q filterEDetail2 = q.eq("description", descr2);
            var EntryDetail2Rows = tEntrydetail._Filter(filterEDetail2);
            var EntryDetail2 = EntryDetail2Rows[0];
            Assert.AreEqual(EntryDetail2["description"], descr2, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idacc"], "19000300020002000100090003", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idupb"], "000100010016", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idreg"], 112387, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idaccmotive"], "000700010005000100010022", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idepacc"], dr2_epacc["idepacc"]);
            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            Assert.AreEqual(2, dsEP.Tables["entry"]._Filter(null).Length, "Sono presenti due scritture");
            //CONTROLLO DETTAGLI SCRITTURA ESERCIZIO 2019
            Assert.AreEqual(2, dsEP.Tables["entrydetail"]._Filter(q.eq("nentry", rEntry["nentry"])).Length, "Sono presenti sette dettagli relativi alla scrittura");
            var avere = (decimal)dsEP.Tables["entrydetail"]._Filter(q.gt("amount", 0) & q.eq("nentry", rEntry["nentry"])).GetSum<decimal>("amount");
            Assert.AreEqual(100m, avere, "Avere corrispondente");
        }

        [TestMethod]
        public void Test2_estimate_2018_sostituzione2019_Rateo()
        {
            //SOSTITUZIONE DI UN DETTAGLIO (DA IMPORTO 1 LO PORTO A 0)
            //RATEO SUPERIORE A IMPORTO DETTAGLIO DEVE SCATTARE REGOLA QUANDO SOSTITUISCO

            //INSERT INTO estimatedetail(idestimkind,nestim,rownum,yestim,ct,cu,detaildescription,discount,idupb,lt,lu,number,start,stop,tax,taxable,taxrate,toinvoice,idaccmotive,idivakind,idreg,idgroup,competencystart,competencystop,epkind,idlist,flag,idsor_siope,rownum_main) 
            //VALUES ('CA_COLLEGABILE','45','4','2018',{ts '2020-11-07 20:41:48.573'},'assistenza','caso rateo attivo','0','00010002',{ts '2020-11-07 20:41:48.573'},'assistenza','1',{d '2019-12-31'},{d '2019-12-31'},'0','1','0','N','000700010001000100030005','17','123711','4',{d '2018-12-01'},{d '2019-12-31'},'R','1916','0','6776','1');
            //if (@@ROWCOUNT=0) BEGIN select 0; RETURN; END;
            //UPDATE estimatedetail SET ct={ts '2020-11-07 20:41:36.726'},lt={ts '2020-11-07 20:41:48.733'},taxable='0' WHERE (idestimkind = 'CA_COLLEGABILE') AND (nestim = '45') AND (rownum = '1') AND (yestim = '2018') AND (lu = 'assistenza') AND (lt = {ts '2020-11-06 09:48:17.073'});
            //if (@@ROWCOUNT=0) BEGIN select 1; RETURN; END;
            //SELECT -1
         
            var t = new TestHelp(new DateTime(2019, 12, 31));
            new DateTime(2020,11,07,20,41,48,733);
            q filterEst = q.eq("idestimkind", "CA_COLLEGABILE") & q.eq("yestim", 2018) & q.eq("nestim", 45);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail",filterEst);
            DataRow rEst = tEstimate.Rows[0];
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rEst, false);
           
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreEqual(3, nEstDet, "Il contratto ha 3 dettagli");

            //UPDATE
            var mEstimate = TestHelp.editDataRow(t.testConn,filterEst,"estimate","default");
            var ds = mEstimate.ds;
          
            DataRow[] rowsEstimatedetail = ds.Tables["estimatedetail"]._Filter(filterEst & q.eq("rownum",1));
            DataRow rEstdet = rowsEstimatedetail[0];
            rEstdet["ct"] = new DateTime(2020,11,07,20,41,36,726);
            rEstdet["lt"] = new DateTime(2020,11,07,20,41,48,733);
            rEstdet["taxable"] = (decimal)0;


            //CREO UNA NUOVA RIGA E INSERISCO I VALORI (SIMULO INSERT)
            Meta_EasyDispatcher md = new Meta_EasyDispatcher(t.testConn);
            MetaData meta_estimatedetail  = md.Get("estimatedetail");
            meta_estimatedetail.SetDefaults(ds.Tables["estimatedetail"]);
            DataRow newRow = meta_estimatedetail.Get_New_Row(rEst,ds.Tables["estimatedetail"]);
            newRow["idestimkind"] = "CA_COLLEGABILE";
            newRow["nestim"] = (Int32)45;
            newRow["rownum"] = (Int32)4;
            newRow["yestim"] = (Int16)2018;
            newRow["ct"] = new DateTime(2020,11,07,20,41,48,573);
            newRow["cu"] = "assistenza";
            newRow["detaildescription"] = "caso rateo attivo";
            newRow["discount"] = (Double)0;
            newRow["idupb"] = "00010002";
            newRow["lt"] = new DateTime(2020,11,07,20,41,48,573);
            newRow["lu"] = "assistenza";
            newRow["number"] = (decimal)1;
            newRow["start"] = new DateTime(2019,12,31);
            newRow["stop"] = new DateTime(2019,12,31);
            newRow["tax"] = (Double)0;
            newRow["taxable"] = (decimal)1;
            newRow["taxrate"] = (decimal)0;
            newRow["toinvoice"] = "N";
            newRow["idaccmotive"] = "000700010001000100030005";
            newRow["idivakind"] = (Int32)17;
            newRow["idreg"] = (Int32)123711;
            newRow["idgroup"] = (Int32)4;
            newRow["competencystart"] = new DateTime(2018,12,1);
            newRow["competencystop"] = new DateTime(2019,12,31);
            newRow["epkind"] = "R";
            newRow["idlist"] = (Int32)1916;
            newRow["flag"] = (Int32)0;
            newRow["idsor_siope"] = (Int32)6776;
            newRow["rownum_main"] = (Int32)1;
            newRow["idaccmotiveannulment"]= "000600010005000100030008";


            //SALVO IL DATASET 
            var res = t.saveFormData(mEstimate);
            mEstimate.ds.AcceptChanges();
            mEstimate.linkedForm.Close();

            checkExistRule(res, "ECOPA075");
            
        }

        [TestMethod]
        public void Test2_estimate_2018_sostituzione2019_Rateo2()
        {
            //2018: Acc n 86601 di 166.22
            //2019: Acc n 86601 di 2123.32 
            var t = new TestHelp(new DateTime(2019, 12, 31));
            q filterEst = q.eq("idestimkind", "CA_COLLEGABILE") & q.eq("yestim", 2018) & q.eq("nestim", 44);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            DataRow rEst = tEstimate.Rows[0];
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rEst, false);
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst );
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreEqual(2, nEstDet, "Il contratto ha 2 dettagli");

            // 207832 
            object idepacc1 = tEstimateDetail.Rows[0]["idepacc"];
               
            //GENERO LE SCRITTURE E MOVIMENTI DI BUDGET
            ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);
            checkNoRules(regole);
            var dsEP = t.getEpData(t.testConn, rEst);

            bool scrittureabilitate = t.abilitaScrittureUT(rEst);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");

            //CONTROLLO VARIAZIONI AI MOVIMENTI DI BUDGET
            DataRow[] rEpaccpvar = dsEP.Tables["epaccvar"]._Filter(null);
            Assert.AreEqual(1*2,rEpaccpvar.Length,"E' presente una variazione");
            t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"], 2018, 86601, -7000m, 2019);

            //CONTROLLO NUMERO IMPEGNI DI BUDGET
            int countNepexp = dsEP.Tables["epexp"]._Filter(null).Length;
            Assert.AreEqual(0, countNepexp, "Non ci sono impegni  di budget");
           
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2018, 86601, 2018, 166.22m);
            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019)).Length;
            Assert.AreEqual(0, countNepacc2019, "Non ci sono accertamenti di budget del 2019");
            int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
            Assert.AreEqual(1, countNepacc2018, "E' presente un accertamento di budget del 2018");

            //CONTROLLO PRIMO  ACCERTAMENTO DI BUDGET 
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc1));
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc1));  
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            Assert.AreEqual(dr1_epacc["description"], "caso rateo attivo", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idacc"], "19000100010001000100030005", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idupb"], "00010002", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["idaccmotive"], "000700010001000100030005", "La causale del mov.budget è corrispondente");
            //TODO DA SISTEMARE AMOUNT INIZIALE
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2018, 86601, 2019, 1957.10m);
            //CONTROLLO VARIAZIONI SPECIFICHE DEGLI ANNI
            DataRow[] rEpaccVar = dsEP.Tables["epaccvar"]._Filter(q.eq("yvar", 2019) & q.eq("idepacc", idepacc1));  
            DataRow dr_epaccVar = rEpaccVar[0];
            Assert.AreEqual(-1123.32m, dr_epaccVar["amount"],"La variazione dell'accertamento nell'anno 2019 è -2123.32");
            Assert.AreEqual(-1962.47m, dr_epaccVar["amount2"],"La variazione dell'accertamento nell'anno 2020 è -1962.47");
            Assert.AreEqual(-1957.10m,dr_epaccVar["amount3"],"La variazione dell'accertamento nell'anno 2021 è -1957.10m");
            Assert.AreEqual(-1957.11m, dr_epaccVar["amount4"],"La variazione dell'accertamento nell'anno 2022 è -1957.11");

            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            var rEntry = dsEP.Tables["entry"]._Filter(q.eq("yentry",2019));
            Assert.AreEqual(0,rEntry.Length, "Non ci sono scritture");
        }

        [TestMethod]
        public void Test2_estimate_2018_sostituzione2019_Rateo3()
        {
            //2018: Acc. 86639 di 1497.95, Acc. 86638 di 1497.95, Acc. 86637 di 1497.95
            //2019: Acc. 86639 di 1497.95 portato a -4.10 variato di -1502.05, Acc. 86638 di 1497.95, Acc. 86637 di 1497,95 
            var t = new TestHelp(new DateTime(2019, 12, 31));
            q filterEst = q.eq("idestimkind", "CA_COLLEGABILE") & q.eq("yestim", 2018) & q.eq("nestim", 67);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            DataRow rEst = tEstimate.Rows[0];
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rEst, false);
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst );
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreEqual(4, nEstDet, "Il contratto ha 4 dettagli");

            // 207962
            object idepacc1 = tEstimateDetail.Rows[0]["idepacc"];
            // 207963
            object idepacc2 = tEstimateDetail.Rows[1]["idepacc"];
            //207964
            object idepacc3 = tEstimateDetail.Rows[2]["idepacc"];
               
            //GENERO LE SCRITTURE E MOVIMENTI DI BUDGET
            ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);
            checkNoRules(regole);
            var dsEP = t.getEpData(t.testConn, rEst);

            bool scrittureabilitate = t.abilitaScrittureUT(rEst);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");

            //CONTROLLO VARIAZIONI AI MOVIMENTI DI BUDGET
            DataRow[] rEpaccpvar = dsEP.Tables["epaccvar"]._Filter(null);
            Assert.AreEqual(1*2,rEpaccpvar.Length,"E' presente una variazione");
            t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"], 2018, 86639, -1502.05m, 2019);

            //CONTROLLO NUMERO IMPEGNI DI BUDGET
            int countNepexp = dsEP.Tables["epexp"]._Filter(null).Length;
            Assert.AreEqual(0, countNepexp, "Non ci sono impegni  di budget");
           
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2018, 86639, 2018, 1497.95m);
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2018, 86638, 2018, 1497.95m);
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2018, 86637, 2018, 1497.95m);
            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019)).Length;
            Assert.AreEqual(0, countNepacc2019, "Non ci sono accertamenti di budget del 2019");
            int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
            Assert.AreEqual(3, countNepacc2018, "Sono presenti tre accertamenti di budget del 2018");

            //CONTROLLO PRIMO ACCERTAMENTO DI BUDGET 
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc3));
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc3));  
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            Assert.AreEqual(dr1_epacc["description"], "Sostituzione con rateo attivo", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idacc"], "19000100010001000200010001", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idupb"], "00010002", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["idaccmotive"], "0001000600020004", "La causale del mov.budget è corrispondente");
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2018, 86639, 2019, 1497.95m);
            //CONTROLLO VARIAZIONI SPECIFICHE DEGLI ANNI
            DataRow[] rEpaccVar = dsEP.Tables["epaccvar"]._Filter(q.eq("yvar", 2019) & q.eq("idepacc", idepacc3));  
            DataRow dr_epaccVar = rEpaccVar[0];
            Assert.AreEqual(dr_epaccVar["amount"],-1497.95m,"La variazione dell'accertamento nell'anno 2019 è -1497.95");
            Assert.AreEqual(dr_epaccVar["amount2"],-4.10m,"La variazione dell'accertamento nell'anno 2020 è -4.10m");

            //CONTROLLO SECONDO ACCERTAMENTO DI BUDGET 
            DataRow[] rEpacc2 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc2));
            DataRow[] rEpaccyear2 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc2));  
            DataRow dr2_epacc = rEpacc2[0];
            DataRow dr2_epaccyear = rEpaccyear2[0];
            Assert.AreEqual(dr2_epacc["description"], "Sostituzione con rateo attivo", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr2_epaccyear["idacc"], "19000100010001000200010001", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epaccyear["idupb"], "00010002", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epacc["idaccmotive"], "0001000600020004", "La causale del mov.budget è corrispondente");
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2018, 86638, 2019, 1497.95m);

            //CONTROLLO TERZO ACCERTAMENTO DI BUDGET 
            DataRow[] rEpacc3 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc1));
            DataRow[] rEpaccyear3 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc1));  
            DataRow dr3_epacc = rEpacc3[0];
            DataRow dr3_epaccyear = rEpaccyear3[0];
            Assert.AreEqual(dr3_epacc["description"], "Sostituzione con rateo attivo", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr3_epaccyear["idacc"], "19000100010001000200010001", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr3_epaccyear["idupb"], "00010002", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr3_epacc["idaccmotive"], "0001000600020004", "La causale del mov.budget è corrispondente");
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2018, 86637, 2019, 1497.95m);

            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            var rEntry = dsEP.Tables["entry"]._Filter(q.eq("yentry",2019));
            Assert.AreEqual(0,rEntry.Length, "Non ci sono scritture");
        }

        [TestMethod]
        public void Test2_estimate_2018_annullo2019_Rateo()
        {
            //2018: Acc n 86626 di 166.22
            //2019: Acc n.1757 di 55.15 , Acc. n. 86626 di 1915.55 portato a 0 con var di -1915.55 e tot var -7792.23m
            var t = new TestHelp(new DateTime(2019, 12, 31));
            q filterEst = q.eq("idestimkind", "CA_COLLEGABILE") & q.eq("yestim", 2018) & q.eq("nestim", 62);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            DataRow rEst = tEstimate.Rows[0];
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rEst, false);
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst );
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreEqual(2, nEstDet, "Il contratto ha 2 dettagli");

            //207920
            object idepacc1 = tEstimateDetail.Rows[0]["idepacc"];
            //207924
            object idepacc2 = tEstimateDetail.Rows[1]["idepacc"];
            
            //GENERO LE SCRITTURE E MOVIMENTI DI BUDGET
            ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);
            checkNoRules(regole);
            var dsEP = t.getEpData(t.testConn, rEst);

            bool scrittureabilitate = t.abilitaScrittureUT(rEst);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");

            //CONTROLLO VARIAZIONI AI MOVIMENTI DI BUDGET
            DataRow[] rEpaccpvar = dsEP.Tables["epaccvar"]._Filter(null);
            Assert.AreEqual(1*2,rEpaccpvar.Length,"E' presente una variazione");
            t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"], 2018, 86626, -7792.23m, 2019);

            //CONTROLLO NUMERO IMPEGNI DI BUDGET
            int countNepexp = dsEP.Tables["epexp"]._Filter(null).Length;
            Assert.AreEqual(0, countNepexp, "Non ci sono impegni  di budget");
           
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2018, 86626, 2018, 166.22m);
            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019)).Length;
            Assert.AreEqual(1, countNepacc2019, "E' presente un accertamento di budget del 2019");
            int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
            Assert.AreEqual(1, countNepacc2018, "E' presente un accertamento di budget del 2018");

            //CONTROLLO PRIMO ACCERTAMENTO DI BUDGET 
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019) & q.eq("idepacc", idepacc2));
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc2));  
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            Assert.AreEqual("S", dr1_epacc["flagvariation"], "Accertamento di tipo variazione");
            Assert.AreEqual(50.97m, dr1_epaccyear["amount2"], "Iniziale annuo 2020 di 50.97");
            Assert.AreEqual(50.83m, dr1_epaccyear["amount3"], "Iniziale annuo 2021 di 50.83");
            Assert.AreEqual(50.82m, dr1_epaccyear["amount4"], "Iniziale annuo 2022 di 50.82");
            Assert.AreEqual(dr1_epacc["description"], "caso rateo attivo", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idacc"], "19000100010001000100030005", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idupb"], "00010002", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["idaccmotive"], "000700010001000100030005", "La causale del mov.budget è corrispondente");
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2019, 1757, 2019, 55.15m);

            //CONTROLLO SECONDO ACCERTAMENTO DI BUDGET 
            DataRow[] rEpacc2 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc1));
            DataRow[] rEpaccyear2 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc1));  
            DataRow dr2_epacc = rEpacc2[0];
            DataRow dr2_epaccyear = rEpaccyear2[0];
            Assert.AreEqual(dr2_epacc["description"], "caso rateo attivo", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr2_epaccyear["idacc"], "19000100010001000100030005", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epaccyear["idupb"], "00010002", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epacc["idaccmotive"], "000700010001000100030005", "La causale del mov.budget è corrispondente");
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2018, 86626, 2019, 1915.55m);

            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            var tEntrydetail = dsEP.Tables["entrydetail"];
            var rEntry = dsEP.Tables["entry"]._Filter(q.eq("yentry",2019))[0];
            var date_doc_colleg = new DateTime(2018, 12, 31);
            var date_contab = new DateTime(2019, 11, 13);
            Assert.AreEqual(rEntry["description"], "caso rateo attivo 10", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "C.A. CA_COLLEGABILE 18/62", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");
            //PRIMO DETTAGLIO SCRITTURA
            var descr1 =
                 "Contratto Attivo CA_COLLEGABILE 18/62dett. 2- caso rateo attivo";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1);
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(EntryDetail1["description"], descr1, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idacc"], "19000100010001000100030005", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idupb"], "00010002", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idreg"], 123711, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idaccmotive"], "000700010001000100030005", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idepacc"], dr1_epacc["idepacc"]);
            //SECONDO DETTAGLIO SCRITTURA
            var descr2 =
                "Contratto attivo CA_COLLEGABILE n.62 / 2018 dett. 2";
            q filterEDetail2 = q.eq("description", descr2);
            var EntryDetail2Rows = tEntrydetail._Filter(filterEDetail2);
            var EntryDetail2 = EntryDetail2Rows[0];
            Assert.AreEqual(EntryDetail2["description"], descr2, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idacc"], "19000300030001000100010001", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idupb"], "00010002", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idreg"], 123711, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idaccmotive"], "000700010001000100030005", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idepacc"], dr2_epacc["idepacc"]);
            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            Assert.AreEqual(1, dsEP.Tables["entry"]._Filter(q.eq("yentry",2019)).Length, "E'presente una scrittura");
            //CONTROLLO DETTAGLI SCRITTURA ESERCIZIO 2019
            Assert.AreEqual(2, dsEP.Tables["entrydetail"]._Filter(q.eq("nentry", rEntry["nentry"])).Length, "Sono presenti 2 dettagli relativi alla scrittura");
            var avere = (decimal)dsEP.Tables["entrydetail"]._Filter(q.gt("amount", 0) & q.eq("nentry", rEntry["nentry"])).GetSum<decimal>("amount");
            Assert.AreEqual(207.77m, avere, "Avere corrispondente");
        }

        [TestMethod]
        public void Test2_estimate_2019_IncassiParziali_StessoAnno() {
            //2019: Acc. 1780 di 1000 , Acc 1779 di 3500
            var t = new TestHelp(new DateTime(2019, 12, 31));
            q filterEst = q.eq("idestimkind", "CA_GENERICO") & q.eq("yestim", 2019) & q.eq("nestim", 42);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            DataRow rEst = tEstimate.Rows[0];
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rEst, false);
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst );
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreEqual(2, nEstDet, "Il contratto ha 2 dettagli");

            //208005
            object idepacc1 = tEstimateDetail.Rows[0]["idepacc"];
            //208006
            object idepacc2 = tEstimateDetail.Rows[1]["idepacc"];
            
            //GENERO LE SCRITTURE E MOVIMENTI DI BUDGET
            ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);
            checkNoRules(regole);
            var dsEP = t.getEpData(t.testConn, rEst);

            bool scrittureabilitate = t.abilitaScrittureUT(rEst);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");

            //CONTROLLO VARIAZIONI AI MOVIMENTI DI BUDGET
            DataRow[] rEpaccpvar = dsEP.Tables["epaccvar"]._Filter(null);
            Assert.AreEqual(0,rEpaccpvar.Length,"Non sono presenti variazioni");
            
            //CONTROLLO NUMERO IMPEGNI DI BUDGET
            int countNepexp = dsEP.Tables["epexp"]._Filter(null).Length;
            Assert.AreEqual(0, countNepexp, "Non ci sono impegni  di budget");
           
            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019)).Length;
            Assert.AreEqual(2, countNepacc2019, "Sono presenti 2 accertamenti di budget del 2019");
            int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
            Assert.AreEqual(0, countNepacc2018, "Non sono  presenti accertamenti di budget del 2018");

            //CONTROLLO PRIMO ACCERTAMENTO DI BUDGET 
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019) & q.eq("idepacc", idepacc2));
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc2));  
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            Assert.AreEqual("N", dr1_epacc["flagvariation"], "Accertamento non di tipo variazione");
            Assert.AreEqual(dr1_epacc["description"], "Test incassi parziali", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idacc"], "19000100010005000100010020", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idupb"], "000100030002000100010024", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["idaccmotive"], "000700010005000100010020", "La causale del mov.budget è corrispondente");
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2019, 1780, 2019, 1000.00m);
            q filterEpacc1 = q.eq("nphase", 2) & q.eq("yepacc", 2019) & q.eq("idepacc", idepacc2);
            DataTable tEpaccView = t.testConn.readTable("epaccview", filterEpacc1);
            DataRow rEpView = tEpaccView.Rows[0];
            decimal totCrediti = (decimal)rEpView["totalcredit"];
            Assert.AreEqual(0.00m, totCrediti, "Crediti totali corrispondenti");


            //CONTROLLO SECONDO ACCERTAMENTO DI BUDGET 
            DataRow[] rEpacc2 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019) & q.eq("idepacc", idepacc1));
            DataRow[] rEpaccyear2 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc1));  
            DataRow dr2_epacc = rEpacc2[0];
            DataRow dr2_epaccyear = rEpaccyear2[0];
            Assert.AreEqual("N", dr1_epacc["flagvariation"], "Accertamento non di tipo variazione");
            Assert.AreEqual(dr2_epacc["description"], "Test incassi parziali", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr2_epaccyear["idacc"], "19000100010005000100010020", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epaccyear["idupb"], "000100030002000100010024", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epacc["idaccmotive"], "000700010005000100010020", "La causale del mov.budget è corrispondente");
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2019, 1779, 2019, 3500.00m);
            q filterEpacc2 = q.eq("nphase", 2) & q.eq("yepacc", 2019) & q.eq("idepacc", idepacc1);
            DataTable tEpaccView2 = t.testConn.readTable("epaccview", filterEpacc2);
            DataRow rEpView2 = tEpaccView2.Rows[0];
            decimal totCrediti2 = (decimal)rEpView2["totalcredit"];
            Assert.AreEqual(0.00m, totCrediti2, "Crediti totali corrispondenti");

            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            var tEntrydetail = dsEP.Tables["entrydetail"];
            var rEntry = dsEP.Tables["entry"]._Filter(q.eq("yentry",2019))[0];
            var date_doc_colleg = new DateTime(2019, 12, 31);
            var date_contab = new DateTime(2019, 12, 31);
            Assert.AreEqual(rEntry["description"], "Test incassi parziali", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "C.A. CA_GENERICO 19/42", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");
            //PRIMO DETTAGLIO SCRITTURA
            var descr1 =
                 "Contratto Attivo CA_GENERICO 19/42 dett. 1- Test incassi parziali";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1);
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(EntryDetail1["description"], descr1, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idacc"], "19000100010005000100010020", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idupb"], "000100030002000100010024", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idreg"], 112387, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idaccmotive"], "000700010005000100010020", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idepacc"], dr2_epacc["idepacc"]);
            //SECONDO DETTAGLIO SCRITTURA
            var descr2 =
                "Contratto attivo CA_GENERICO n.42 / 2019 n° 1";
            q filterEDetail2 = q.eq("description", descr2);
            var EntryDetail2Rows = tEntrydetail._Filter(filterEDetail2);
            var EntryDetail2 = EntryDetail2Rows[0];
            Assert.AreEqual(EntryDetail2["description"], descr2, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idacc"], "19000300020002000100090003", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idupb"], "000100030002000100010024", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idreg"], 112387, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idaccmotive"], "000700010005000100010020", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idepacc"], dr2_epacc["idepacc"]);
            //TERZO DETTAGLIO SCRITTURA
            var descr3 =
                "Contratto Attivo CA_GENERICO 19/42 dett. 2- Test incassi parziali";
            q filterEDetail3 = q.eq("description", descr3);
            var EntryDetail3Rows = tEntrydetail._Filter(filterEDetail3);
            var EntryDetail3 = EntryDetail3Rows[0];
            Assert.AreEqual(EntryDetail3["description"], descr3, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail3["idacc"], "19000100010005000100010020", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail3["idupb"], "000100030002000100010024", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail3["idreg"], 112387, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail3["idaccmotive"], "000700010005000100010020", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail3["idepacc"], dr1_epacc["idepacc"]);
            //QUARTO DETTAGLIO SCRITTURA
            var descr4 =
                "Contratto attivo CA_GENERICO n.42 / 2019 n° 2";
            q filterEDetail4 = q.eq("description", descr4);
            var EntryDetail4Rows = tEntrydetail._Filter(filterEDetail4);
            var EntryDetail4 = EntryDetail4Rows[0];
            Assert.AreEqual(EntryDetail4["description"], descr4, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail4["idacc"], "19000300020002000100090003", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail4["idupb"], "000100030002000100010024", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail4["idreg"], 112387, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail4["idaccmotive"], "000700010005000100010020", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail4["idepacc"], dr1_epacc["idepacc"]);
            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            Assert.AreEqual(1, dsEP.Tables["entry"]._Filter(q.eq("yentry",2019)).Length, "E'presente una scrittura");
            //CONTROLLO DETTAGLI SCRITTURA ESERCIZIO 2019
            Assert.AreEqual(4, dsEP.Tables["entrydetail"]._Filter(q.eq("nentry", rEntry["nentry"])).Length, "Sono presenti 2 dettagli relativi alla scrittura");
            var avere = (decimal)dsEP.Tables["entrydetail"]._Filter(q.gt("amount", 0) & q.eq("nentry", rEntry["nentry"])).GetSum<decimal>("amount");
            Assert.AreEqual(4500.00m, avere, "Avere corrispondente");
		}

        [TestMethod]
        public void Test2_estimate_2018_IncassiParziali_StessoAnnoeSucc() {
            //2018: Acc. 86647 di 5000 , Acc. 86646 di 3000 , Acc. 86645 di 8000
            //2019 Accertamenti del 2018 portati a 0
            var t = new TestHelp(new DateTime(2018, 12, 31));
            q filterEst = q.eq("idestimkind", "CA_GENERICO") & q.eq("yestim", 2018) & q.eq("nestim", 68);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            DataRow rEst = tEstimate.Rows[0];
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rEst, false);
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst );
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreEqual(3, nEstDet, "Il contratto ha 3 dettagli");

            //208014
            object idepacc1 = tEstimateDetail.Rows[0]["idepacc"];
            //208013
            object idepacc2 = tEstimateDetail.Rows[1]["idepacc"];
            //208016
            object idepacc3 = tEstimateDetail.Rows[2]["idepacc"];
            
            //GENERO LE SCRITTURE E MOVIMENTI DI BUDGET
            ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);
            checkNoRules(regole);
            var dsEP = t.getEpData(t.testConn, rEst);

            bool scrittureabilitate = t.abilitaScrittureUT(rEst);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");

            //CONTROLLO VARIAZIONI AI MOVIMENTI DI BUDGET
            DataRow[] rEpaccpvar = dsEP.Tables["epaccvar"]._Filter(null);
            Assert.AreEqual(0,rEpaccpvar.Length,"Non sono presenti variazioni");
            
            //CONTROLLO NUMERO IMPEGNI DI BUDGET
            int countNepexp = dsEP.Tables["epexp"]._Filter(null).Length;
            Assert.AreEqual(0, countNepexp, "Non ci sono impegni  di budget");
           
            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019)).Length;
            Assert.AreEqual(0, countNepacc2019, "Sono presenti 0 accertamenti di budget del 2019");
            int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
            Assert.AreEqual(3, countNepacc2018, "Ci sono 3 accertamenti di budget del 2018");

            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2018, 86647, 2019, 0.00m);
            //CONTROLLO PRIMO ACCERTAMENTO DI BUDGET 
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc3));
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2018) & q.eq("idepacc", idepacc3));  
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            Assert.AreEqual("N", dr1_epacc["flagvariation"], "Accertamento non di tipo variazione");
            Assert.AreEqual(dr1_epacc["description"], "Test incassi parziali in anni diversi", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idacc"], "18000100010001000200010001", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idupb"], "00010002", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["idaccmotive"], "000700010001000200010001", "La causale del mov.budget è corrispondente");
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2018, 86647, 2018, 5000.00m);
            q filterEpacc1 = q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc3);
            DataTable tEpaccView1 = t.testConn.readTable("epaccview", filterEpacc1);
            DataRow rEpView1 = tEpaccView1.Rows[0];
            decimal totCrediti1 = (decimal)rEpView1["totalcredit"];
            Assert.AreEqual(2000.00m, totCrediti1, "Crediti totali corrispondenti");

            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2018, 86646, 2019, 0.00m);
            //CONTROLLO SECONDO ACCERTAMENTO DI BUDGET 
            DataRow[] rEpacc2 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc1));
            DataRow[] rEpaccyear2 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2018) & q.eq("idepacc", idepacc1));  
            DataRow dr2_epacc = rEpacc2[0];
            DataRow dr2_epaccyear = rEpaccyear2[0];
            Assert.AreEqual("N", dr1_epacc["flagvariation"], "Accertamento non di tipo variazione");
            Assert.AreEqual(dr2_epacc["description"], "Test incassi parziali in anni diversi", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr2_epaccyear["idacc"], "18000100010001000100010001", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epaccyear["idupb"], "00010002", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epacc["idaccmotive"], "000700010001000100010001", "La causale del mov.budget è corrispondente");
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2018, 86646, 2018, 3000.00m);
            q filterEpacc2 = q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc1);
            DataTable tEpaccView2 = t.testConn.readTable("epaccview", filterEpacc2);
            DataRow rEpView2 = tEpaccView2.Rows[0];
            decimal totCrediti2 = (decimal)rEpView2["totalcredit"];
            Assert.AreEqual(2100.00m, totCrediti2, "Crediti totali corrispondenti");

            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2018, 86645, 2019, 0.00m);
            //CONTROLLO TERZO ACCERTAMENTO DI BUDGET 
            DataRow[] rEpacc3 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc2));
            DataRow[] rEpaccyear3 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2018) & q.eq("idepacc", idepacc2));  
            DataRow dr3_epacc = rEpacc3[0];
            DataRow dr3_epaccyear = rEpaccyear3[0];
            Assert.AreEqual("N", dr1_epacc["flagvariation"], "Accertamento non di tipo variazione");
            Assert.AreEqual(dr3_epacc["description"], "Test incassi parziali in anni diversi", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr3_epaccyear["idacc"], "18000100010001000100010001", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr3_epaccyear["idupb"], "00010002", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr3_epacc["idaccmotive"], "000700010001000100010001", "La causale del mov.budget è corrispondente");
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2018, 86645, 2018, 8000.00m);
            q filterEpacc3 = q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc2);
            DataTable tEpaccView3 = t.testConn.readTable("epaccview", filterEpacc3);
            DataRow rEpView3 = tEpaccView3.Rows[0];
            decimal totCrediti3 = (decimal)rEpView3["totalcredit"];
            Assert.AreEqual(1700.00m, totCrediti3, "Crediti totali corrispondenti");

            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            var tEntrydetail = dsEP.Tables["entrydetail"];
            var rEntry = dsEP.Tables["entry"]._Filter(q.eq("yentry",2018))[0];
            var date_doc_colleg = new DateTime(2018, 12, 31);
            var date_contab = new DateTime(2018, 12, 31);
            Assert.AreEqual(rEntry["description"], "Test incassi parziali in anni diversi", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "C.A. CA_GENERICO 18/68", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");
            //PRIMO DETTAGLIO SCRITTURA
            var descr1 =
                 "Contratto Attivo CA_GENERICO 18/68 dett. 2- Test incassi parziali in anni diversi";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1);
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(descr1, EntryDetail1["description"],  "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("18000100010001000100010001", EntryDetail1["idacc"],  "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("00010002", EntryDetail1["idupb"],  "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(10382, EntryDetail1["idreg"],  "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("000700010001000100010001", EntryDetail1["idaccmotive"],  "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idepacc"], dr3_epacc["idepacc"]);
            //SECONDO DETTAGLIO SCRITTURA
            var descr2 =
                "Contratto attivo CA_GENERICO n.68 / 2018 n° 2";
            q filterEDetail2 = q.eq("description", descr2);
            var EntryDetail2Rows = tEntrydetail._Filter(filterEDetail2);
            var EntryDetail2 = EntryDetail2Rows[0];
            Assert.AreEqual(descr2, EntryDetail2["description"],  "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("18000300020002000100090003", EntryDetail2["idacc"],  "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("00010002", EntryDetail2["idupb"],  "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(10382, EntryDetail2["idreg"],  "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("000700010001000100010001", EntryDetail2["idaccmotive"],  "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idepacc"], dr3_epacc["idepacc"]);
            //TERZO DETTAGLIO SCRITTURA
            var descr3 =
                "Contratto Attivo CA_GENERICO 18/68 dett. 1- Test incassi parziali in anni diversi";
            q filterEDetail3 = q.eq("description", descr3);
            var EntryDetail3Rows = tEntrydetail._Filter(filterEDetail3);
            var EntryDetail3 = EntryDetail3Rows[0];
            Assert.AreEqual(descr3, EntryDetail3["description"],  "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("18000100010001000100010001", EntryDetail3["idacc"],  "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("00010002", EntryDetail3["idupb"],  "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(10382, EntryDetail3["idreg"],  "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("000700010001000100010001", EntryDetail3["idaccmotive"],  "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail3["idepacc"], dr2_epacc["idepacc"]);
            //QUARTO DETTAGLIO SCRITTURA
            var descr4 =
                "Contratto attivo CA_GENERICO n.68 / 2018 n° 1";
            q filterEDetail4 = q.eq("description", descr4);
            var EntryDetail4Rows = tEntrydetail._Filter(filterEDetail4);
            var EntryDetail4 = EntryDetail4Rows[0];
            Assert.AreEqual(descr4, EntryDetail4["description"],  "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("18000300020002000100090003", EntryDetail4["idacc"],  "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("00010002", EntryDetail4["idupb"],  "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(10382, EntryDetail4["idreg"],  "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("000700010001000100010001", EntryDetail4["idaccmotive"],  "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail4["idepacc"], dr2_epacc["idepacc"]);
            //QUINTO DETTAGLIO SCRITTURA
            var descr5 =
                "Contratto Attivo CA_GENERICO 18/68 dett. 3- Test incassi parziali in anni diversi";
            q filterEDetail5 = q.eq("description", descr5);
            var EntryDetail5Rows = tEntrydetail._Filter(filterEDetail5);
            var EntryDetail5 = EntryDetail5Rows[0];
            Assert.AreEqual(descr5,EntryDetail5["description"],  "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("18000100010001000200010001", EntryDetail5["idacc"],  "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("00010002",EntryDetail5["idupb"],  "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(10382, EntryDetail5["idreg"],  "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("000700010001000200010001",EntryDetail5["idaccmotive"],  "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail5["idepacc"], dr1_epacc["idepacc"]);
            //SESTO DETTAGLIO SCRITTURA
            var descr6 =
                "Contratto attivo CA_GENERICO n.68 / 2018 n° 3";
            q filterEDetail6 = q.eq("description", descr6);
            var EntryDetail6Rows = tEntrydetail._Filter(filterEDetail6);
            var EntryDetail6 = EntryDetail6Rows[0];
            Assert.AreEqual(descr6, EntryDetail6["description"],  "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("18000300020002000100090003",EntryDetail6["idacc"],  "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("00010002",EntryDetail6["idupb"],  "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(10382,EntryDetail6["idreg"],  "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual("000700010001000200010001",EntryDetail6["idaccmotive"],  "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail6["idepacc"], dr1_epacc["idepacc"]);
            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            Assert.AreEqual(1, dsEP.Tables["entry"]._Filter(q.eq("yentry",2018)).Length, "E'presente una scrittura");
            //CONTROLLO DETTAGLI SCRITTURA ESERCIZIO 2019
            Assert.AreEqual(6, dsEP.Tables["entrydetail"]._Filter(q.eq("nentry", rEntry["nentry"])).Length, "Sono presenti 2 dettagli relativi alla scrittura");
            var avere = (decimal)dsEP.Tables["entrydetail"]._Filter(q.gt("amount", 0) & q.eq("nentry", rEntry["nentry"])).GetSum<decimal>("amount");
            Assert.AreEqual(16000.00m, avere, "Avere corrispondente");
		}

        [TestMethod]
        public void Test2_estimate_2019_ParzIncassa_SostDettagli() {
            var t = new TestHelp(new DateTime(2019, 12, 31));
            q filterEst = q.eq("idestimkind", "CA_GENERICO") & q.eq("yestim", 2019) & q.eq("nestim", 47);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            DataRow rEst = tEstimate.Rows[0];
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rEst, false);
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst );
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreEqual(3, nEstDet, "Il contratto ha 3 dettagli");

            //208031
            object idepacc1 = tEstimateDetail.Rows[0]["idepacc"];
            //208032
            object idepacc2 = tEstimateDetail.Rows[1]["idepacc"];
          
            //GENERO LE SCRITTURE E MOVIMENTI DI BUDGET
            ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);
            checkNoRules(regole);
            var dsEP = t.getEpData(t.testConn, rEst);

            bool scrittureabilitate = t.abilitaScrittureUT(rEst);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");

            //CONTROLLO VARIAZIONI AI MOVIMENTI DI BUDGET
            DataRow[] rEpaccpvar = dsEP.Tables["epaccvar"]._Filter(null);
            Assert.AreEqual(1*2,rEpaccpvar.Length,"E' presente una variazione");
            t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"], 2019, 1790, -500.00m, 2019);


            //CONTROLLO NUMERO IMPEGNI DI BUDGET
            int countNepexp = dsEP.Tables["epexp"]._Filter(null).Length;
            Assert.AreEqual(0, countNepexp, "Non ci sono impegni  di budget");
           
            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019)).Length;
            Assert.AreEqual(2, countNepacc2019, "Sono presenti 2 accertamenti di budget del 2019");
            int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
            Assert.AreEqual(0, countNepacc2018, "Non sono  presenti accertamenti di budget del 2018");

            //CONTROLLO PRIMO ACCERTAMENTO DI BUDGET 
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019) & q.eq("idepacc", idepacc2));
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc2));  
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            Assert.AreEqual("N", dr1_epacc["flagvariation"], "Accertamento non di tipo variazione");
            Assert.AreEqual("Test incassi parziali", dr1_epacc["description"], "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual("19000100010005000100010020",dr1_epaccyear["idacc"], "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual("000100030002000100010024",dr1_epaccyear["idupb"],  "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual("000700010005000100010020", dr1_epacc["idaccmotive"],  "La causale del mov.budget è corrispondente");
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2019, 1790, 2019, 2300.00m);
            q filterEpacc1 = q.eq("nphase", 2) & q.eq("yepacc", 2019) & q.eq("idepacc", idepacc2);
            DataTable tEpaccView = t.testConn.readTable("epaccview", filterEpacc1);
            DataRow rEpView = tEpaccView.Rows[0];
            decimal totCrediti = (decimal)rEpView["totalcredit"];
            Assert.AreEqual(0.00m, totCrediti, "Crediti totali corrispondenti");

            //CONTROLLO SECONDO ACCERTAMENTO DI BUDGET 
            DataRow[] rEpacc2 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019) & q.eq("idepacc", idepacc1));
            DataRow[] rEpaccyear2 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc1));  
            DataRow dr2_epacc = rEpacc2[0];
            DataRow dr2_epaccyear = rEpaccyear2[0];
            Assert.AreEqual("N", dr1_epacc["flagvariation"], "Accertamento non di tipo variazione");
            Assert.AreEqual(dr2_epacc["description"], "Test incassi parziali", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr2_epaccyear["idacc"], "19000100010005000100010020", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epaccyear["idupb"], "000100030002000100010024", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epacc["idaccmotive"], "000700010005000100010020", "La causale del mov.budget è corrispondente");
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2019, 1789, 2019, 1700.00m);
            q filterEpacc2 = q.eq("nphase", 2) & q.eq("yepacc", 2019) & q.eq("idepacc", idepacc1);
            DataTable tEpaccView2 = t.testConn.readTable("epaccview", filterEpacc2);
            DataRow rEpView2 = tEpaccView2.Rows[0];
            decimal totCrediti2 = (decimal)rEpView2["totalcredit"];
            Assert.AreEqual(750.00m, totCrediti2, "Crediti totali corrispondenti");

            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            var tEntrydetail = dsEP.Tables["entrydetail"];
            var rEntry = dsEP.Tables["entry"]._Filter(q.eq("yentry",2019))[0];
            var date_doc_colleg = new DateTime(2019, 12, 31);
            var date_contab = new DateTime(2019, 12, 31);
            Assert.AreEqual(rEntry["description"], "Test incassi parziali", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "C.A. CA_GENERICO 19/47", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");
            //PRIMO DETTAGLIO SCRITTURA
            var descr1 =
                 "Contratto Attivo CA_GENERICO 19/47 dett. 1- Test incassi parziali";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1);
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(EntryDetail1["description"], descr1, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idacc"], "19000100010005000100010020", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idupb"], "000100030002000100010024", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idreg"], 112387, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idaccmotive"], "000700010005000100010020", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idepacc"], dr2_epacc["idepacc"]);
            //SECONDO DETTAGLIO SCRITTURA
            var descr2 =
                "Contratto attivo CA_GENERICO n.47 / 2019 n° 1";
            q filterEDetail2 = q.eq("description", descr2);
            var EntryDetail2Rows = tEntrydetail._Filter(filterEDetail2);
            var EntryDetail2 = EntryDetail2Rows[0];
            Assert.AreEqual(EntryDetail2["description"], descr2, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idacc"], "19000300020002000100090003", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idupb"], "000100030002000100010024", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idreg"], 112387, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idaccmotive"], "000700010005000100010020", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idepacc"], dr2_epacc["idepacc"]);
            //TERZO DETTAGLIO SCRITTURA
            var descr3 =
                "Contratto Attivo CA_GENERICO 19/47 dett. 2- Test incassi parziali";
            q filterEDetail3 = q.eq("description", descr3);
            var EntryDetail3Rows = tEntrydetail._Filter(filterEDetail3);
            var EntryDetail3 = EntryDetail3Rows[0];
            Assert.AreEqual(EntryDetail3["description"], descr3, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail3["idacc"], "19000100010005000100010020", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail3["idupb"], "000100030002000100010024", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail3["idreg"], 112387, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail3["idaccmotive"], "000700010005000100010020", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail3["idepacc"], dr1_epacc["idepacc"]);
            //QUARTO DETTAGLIO SCRITTURA
            var descr4 =
                "Contratto attivo CA_GENERICO n.47 / 2019 n° 2";
            q filterEDetail4 = q.eq("description", descr4);
            var EntryDetail4Rows = tEntrydetail._Filter(filterEDetail4);
            var EntryDetail4 = EntryDetail4Rows[0];
            Assert.AreEqual(EntryDetail4["description"], descr4, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail4["idacc"], "19000300020002000100090003", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail4["idupb"], "000100030002000100010024", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail4["idreg"], 112387, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail4["idaccmotive"], "000700010005000100010020", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail4["idepacc"], dr1_epacc["idepacc"]);
            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            Assert.AreEqual(1, dsEP.Tables["entry"]._Filter(q.eq("yentry",2019)).Length, "E'presente una scrittura");
            //CONTROLLO DETTAGLI SCRITTURA ESERCIZIO 2019
            Assert.AreEqual(4, dsEP.Tables["entrydetail"]._Filter(q.eq("nentry", rEntry["nentry"])).Length, "Sono presenti 2 dettagli relativi alla scrittura");
            var avere = (decimal)dsEP.Tables["entrydetail"]._Filter(q.gt("amount", 0) & q.eq("nentry", rEntry["nentry"])).GetSum<decimal>("amount");
            Assert.AreEqual(3500.00m, avere, "Avere corrispondente");

            //MODIFICO IL DATASET DELL'ESTIMATEDETAIL(IL PRIMO) PER FAR SCATTARE LA REGOLA QUANDO SOSTITUISCO L'IMPORTO DEL DETTAGLIO
            var mEstimate = TestHelp.editDataRow(t.testConn,filterEst, "estimate", "default");
            var ds = mEstimate.ds;
            var tEstimateDet = ds.Tables["estimatedetail"];
            var rEstDet = tEstimateDet._Filter(q.eq("rownum",1))[0];
            rEstDet["taxable"] = 800m;

            //SALVO I DATI DEL FORM MODIFICATO
            var res = t.saveFormData(mEstimate);
            checkExistRule(res, "MOVIM176");

		}

        [TestMethod]
        public void Test2_estimate_2019_ParzIncassa_SostDettagliAnniSuccessivi() {
            //2018: Acc 86650 di 250 portato a 3000 con var di -1.495,90(2019) e -1.254,10(2020), Acc 86649 di 5000, Acc. 86648 di 8000 
            //2019: Acc 1790 di 5000
            var t = new TestHelp(new DateTime(2019, 12, 31));
            q filterEst = q.eq("idestimkind", "CA_GENERICO") & q.eq("yestim", 2018) & q.eq("nestim", 69);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            DataRow rEst = tEstimate.Rows[0];
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rEst, false);
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst );
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreEqual(5, nEstDet, "Il contratto ha 5 dettagli");

            //208042
            object idepacc1 = tEstimateDetail.Rows[0]["idepacc"];
            //208040
            object idepacc2 = tEstimateDetail.Rows[1]["idepacc"];
            //208041
            object idepacc3 = tEstimateDetail.Rows[2]["idepacc"];
            //208044
            object idepacc4 = tEstimateDetail.Rows[3]["idepacc"];
    
            //GENERO LE SCRITTURE E MOVIMENTI DI BUDGET
            ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);
            checkNoRules(regole);
            var dsEP = t.getEpData(t.testConn, rEst);

            bool scrittureabilitate = t.abilitaScrittureUT(rEst);
            Assert.IsTrue(scrittureabilitate, "Le scritture sono abilitate");

            //CONTROLLO VARIAZIONI AI MOVIMENTI DI BUDGET
            DataRow[] rEpaccpvar = dsEP.Tables["epaccvar"]._Filter(null);
            Assert.AreEqual(1*2,rEpaccpvar.Length,"E' presente una variazione nel 2018 ");
            t.checkImportoTotaleVarAccBudget(dsEP.Tables["epacc"], 2018, 86650, 0.00m, 2018);


            //CONTROLLO NUMERO IMPEGNI DI BUDGET
            int countNepexp = dsEP.Tables["epexp"]._Filter(null).Length;
            Assert.AreEqual(0, countNepexp, "Non ci sono impegni  di budget");
           
            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019)).Length;
            Assert.AreEqual(1, countNepacc2019, "E' presente un accertamento di budget del 2019");
            int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
            Assert.AreEqual(3, countNepacc2018, "Sono presenti 3 accertamenti di budget del 2018");

            //CONTROLLO PRIMO ACCERTAMENTO DI BUDGET 
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019) & q.eq("idepacc", idepacc4));
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc4));  
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            Assert.AreEqual("S", dr1_epacc["flagvariation"], "Accertamento di tipo variazione");
            Assert.AreEqual("Sostituzione in anni successivi di dettagli CA_GENERICO parzialmente incassati", dr1_epacc["description"], "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual("19000100010001000100010001",dr1_epaccyear["idacc"], "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual("00010002",dr1_epaccyear["idupb"],  "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual("000700010001000100010001", dr1_epacc["idaccmotive"],  "La causale del mov.budget è corrispondente");
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2019, 1793, 2019, 5000.00m);
            q filterEpacc1 = q.eq("nphase", 2) & q.eq("yepacc", 2019) & q.eq("idepacc", idepacc4);
            DataTable tEpaccView = t.testConn.readTable("epaccview", filterEpacc1);
            DataRow rEpView = tEpaccView.Rows[0];
            decimal totCrediti = (decimal)rEpView["totalcredit"];
            Assert.AreEqual(0.00m, totCrediti, "Crediti totali corrispondenti");

            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2018, 86650, 2018, 250.00m);
            //CONTROLLO SECONDO ACCERTAMENTO DI BUDGET (nato nel 2018)
            DataRow[] rEpacc2 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc1));
            DataRow[] rEpaccyear2 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc1));  
            DataRow dr2_epacc = rEpacc2[0];
            DataRow dr2_epaccyear = rEpaccyear2[0];
            Assert.AreEqual("N", dr2_epacc["flagvariation"], "Accertamento non di tipo variazione");
            Assert.AreEqual(dr2_epacc["description"], "Sostituzione in anni successivi di dettagli CA_GENERICO parzialmente incassati", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr2_epaccyear["idacc"], "19000100010001000100010001", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epaccyear["idupb"], "00010002", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epacc["idaccmotive"], "000700010001000100010001", "La causale del mov.budget è corrispondente");
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2018, 86650, 2019, 0.00m);
            q filterEpacc2 = q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc1);
            DataTable tEpaccView2 = t.testConn.readTable("epaccview", filterEpacc2 & q.eq("ayear",2019));
            DataRow rEpView2 = tEpaccView2.Rows[0];
            decimal totCrediti2 = (decimal)rEpView2["totalcredit"];
            Assert.AreEqual(400.00m, totCrediti2, "Crediti totali corrispondenti");

            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2018, 86649, 2018, 5000.00m);
            //CONTROLLO TERZO ACCERTAMENTO DI BUDGET (nato nel 2018)
            DataRow[] rEpacc3 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc3));
            DataRow[] rEpaccyear3 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc3));  
            DataRow dr3_epacc = rEpacc3[0];
            DataRow dr3_epaccyear = rEpaccyear3[0];
            Assert.AreEqual("N", dr3_epacc["flagvariation"], "Accertamento non di tipo variazione");
            Assert.AreEqual(dr3_epacc["description"], "Sostituzione in anni successivi di dettagli CA_GENERICO parzialmente incassati", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr3_epaccyear["idacc"], "19000100010001000200010001", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr3_epaccyear["idupb"], "00010002", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr3_epacc["idaccmotive"], "000700010001000200010001", "La causale del mov.budget è corrispondente");
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2018, 86649, 2019, 0.00m);
            q filterEpacc3 = q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc3);
            DataTable tEpaccView3 = t.testConn.readTable("epaccview", filterEpacc3 & q.eq("ayear",2019));
            DataRow rEpView3 = tEpaccView3.Rows[0];
            decimal totCrediti3 = (decimal)rEpView3["totalcredit"];
            Assert.AreEqual(200.00m, totCrediti3, "Crediti totali corrispondenti");

            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2018, 86648, 2018, 8000.00m);
            //CONTROLLO QUARTO ACCERTAMENTO DI BUDGET (nato nel 2018)
            DataRow[] rEpacc4 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc2));
            DataRow[] rEpaccyear4 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc2));  
            DataRow dr4_epacc = rEpacc4[0];
            DataRow dr4_epaccyear = rEpaccyear4[0];
            Assert.AreEqual("N", dr4_epacc["flagvariation"], "Accertamento non di tipo variazione");
            Assert.AreEqual(dr4_epacc["description"], "Sostituzione in anni successivi di dettagli CA_GENERICO parzialmente incassati", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr4_epaccyear["idacc"], "19000100010001000100010001", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr4_epaccyear["idupb"], "00010002", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr4_epacc["idaccmotive"], "000700010001000100010001", "La causale del mov.budget è corrispondente");
            t.checkImportoInizialeAccBudget(dsEP.Tables["epacc"], 2018, 86648, 2019, 0.00m);
            q filterEpacc4 = q.eq("nphase", 2) & q.eq("yepacc", 2018) & q.eq("idepacc", idepacc2);
            DataTable tEpaccView4 = t.testConn.readTable("epaccview", filterEpacc4 & q.eq("ayear",2019));
            DataRow rEpView4 = tEpaccView4.Rows[0];
            decimal totCrediti4 = (decimal)rEpView4["totalcredit"];
            Assert.AreEqual(450.00m, totCrediti4, "Crediti totali corrispondenti");

            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            var tEntrydetail = dsEP.Tables["entrydetail"];
            var rEntry = dsEP.Tables["entry"]._Filter(q.eq("yentry",2019))[0];
            var date_doc_colleg = new DateTime(2018, 12, 31);
            var date_contab = new DateTime(2019, 12, 31);
            Assert.AreEqual(rEntry["description"], "Sostituzione in anni successivi di dettagli CA_GENERICO parzialmente incassati", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "C.A. CA_GENERICO 18/69", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");
            //PRIMO DETTAGLIO SCRITTURA
            var descr1 =
                 "Contratto Attivo CA_GENERICO 18/69dett. 4- Sostituzione in anni successivi di dettagli CA_GENERICO parzialmente incassati";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1);
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(EntryDetail1["description"], descr1, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idacc"], "19000100010001000100010001", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idupb"], "00010002", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idreg"], 10382, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idaccmotive"], "000700010001000100010001", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idepacc"], dr1_epacc["idepacc"]);
            //SECONDO DETTAGLIO SCRITTURA
            var descr2 =
                "Contratto attivo CA_GENERICO n.69 / 2018 dett. 4";
            q filterEDetail2 = q.eq("description", descr2);
            var EntryDetail2Rows = tEntrydetail._Filter(filterEDetail2);
            var EntryDetail2 = EntryDetail2Rows[0];
            Assert.AreEqual(EntryDetail2["description"], descr2, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idacc"], "19000300020002000100090003", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idupb"], "00010002", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idreg"], 10382, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idaccmotive"], "000700010001000100010001", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idepacc"], dr4_epacc["idepacc"]);
            
            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            Assert.AreEqual(1, dsEP.Tables["entry"]._Filter(q.eq("yentry",2019)).Length, "E'presente una scrittura");
            //CONTROLLO DETTAGLI SCRITTURA ESERCIZIO 2019
            Assert.AreEqual(2, dsEP.Tables["entrydetail"]._Filter(q.eq("nentry", rEntry["nentry"])).Length, "Sono presenti 2 dettagli relativi alla scrittura");
            var avere = (decimal)dsEP.Tables["entrydetail"]._Filter(q.gt("amount", 0) & q.eq("nentry", rEntry["nentry"])).GetSum<decimal>("amount");
            Assert.AreEqual(5000.00m, avere, "Avere corrispondente");

            //MODIFICO IL DATASET DELL'ESTIMATEDETAIL(IL PRIMO) PER FAR SCATTARE LA REGOLA QUANDO SOSTITUISCO L'IMPORTO DEL DETTAGLIO
            var mEstimate = TestHelp.editDataRow(t.testConn,filterEst, "estimate", "default");
            var ds = mEstimate.ds;
            var tEstimateDet = ds.Tables["estimatedetail"];
            var rEstDet = tEstimateDet._Filter(q.eq("rownum",1))[0];
            rEstDet["taxable"] = 700.00m;

            //SALVO I DATI DEL FORM MODIFICATO
            var res = t.saveFormData(mEstimate);
            checkExistRule(res, "MOVIM176");

        }

        [TestMethod]
        public void Test2_estimate_2019_ParzIncassa_Annullo() {
            //SQL PROFILER SIMULAZIONE ANNULLO DETTAGLIO IN MEMORIA
            //UPDATE estimatedetail SET lt={ts '2020-12-06 18:51:03.719'},
            //lu='assistenza',stop={d '2019-12-31'}
            //WHERE (idestimkind = 'DOCAMM-simnova') AND (nestim = '112') AND (rownum = '1') AND (yestim = '2019') AND (lu = 'andreea.reva{C_DIP}') AND (lt = {ts '2019-02-22 10:17:19.210'});

            var t = new TestHelp(new DateTime(2019, 12, 31));
            q filterEst = q.eq("idestimkind", "CA_GENERICO") & q.eq("yestim", 2019) & q.eq("nestim", 55);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            DataRow rEst = tEstimate.Rows[0];
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            t.binaryCopyEp(rEst, false);
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst );
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreEqual(5, nEstDet, "Il contratto ha 5 dettagli");

            //MODIFICO IL DATASET DELL'ESTIMATEDETAIL(IL PRIMO ROWNUM 1) PER VERIFICARE CHE SCATTI LA REGOLA QUANDO ANNULLO IL DETTAGLIO
            var mEstimate = TestHelp.editDataRow(t.testConn,filterEst, "estimate", "default");
            var ds = mEstimate.ds;
            var tEstimateDet = ds.Tables["estimatedetail"];
            var rEstDet = tEstimateDet._Filter(q.eq("rownum",1))[0];
            rEstDet["lt"] = new DateTime(2020,11,07,20,41,48,573);;
            rEstDet["lu"] = "assistenza";
            rEstDet["stop"] = new DateTime(2019,12,31);
            
            //SALVO I DATI DEL FORM MODIFICATO
            var res = t.saveFormData(mEstimate);
            checkExistRule(res, "MOVIM176");

        }

        #endregion

        #endregion

        #region Test MovBudget e Scritture Fatture   

        [TestMethod]
        public void Test_FattAcquisto_scritt_2018_CollegMandate()
        {
            var t = new TestHelp(new DateTime(2018, 12, 31));
            q filterInv = q.eq("idinvkind", 90) & q.eq("yinv", 2018) & q.eq("ninv", 13);
            t.binaryReplaceSet(filterInv, t.getTableSet(TestHelp.mainObject.invoice));
            DataTable tInvoice = t.testConn.readTable("invoice", filterInv);
            Assert.AreEqual(1, tInvoice.Rows.Count, "La fattura esiste");
            DataTable tInvoiceDetail = t.testConn.readTable("invoicedetail", filterInv);
            int nEstDet = tInvoiceDetail.Rows.Count;
            Assert.AreNotEqual(0, nEstDet, "La fattura non ha dettagli");
            DataRow rInv = tInvoice.Rows[0];
            DataRow rInvD = tInvoiceDetail.Rows[0];
            var dsEP = t.getEpData(t.testConn, rInv);
            t.binaryCopyEp(rInv, false);

            //CONTROLLO PER REGOLE 
            ProcedureMessageCollection regole = t.generateEP(rInv);
            if(regole != null) 
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
  
            var tEntrydetail = dsEP.Tables["entrydetail"];
            var rEntry = dsEP.Tables["entry"].Rows[0];

            var date_doc_colleg = new DateTime(2018, 2, 19);
            var date_contab = new DateTime(2018, 2, 21);
            Assert.AreEqual(rEntry["description"], "Reagenti BO 6 del 29/01/2018 Q.ta Fresu", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "2018    26/P", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");

            //PRIMO DETTAGLIO SCRITTURA
            var descr1=
                 " Human High Sensitive Interleukin 4 (HS IL-4) ELISA BTB-E3762HU\r\n";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1);
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(EntryDetail1["description"], descr1, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idacc"], "18000200010002000500010003", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idupb"], "000100030003000200020701", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idreg"], 122805, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idaccmotive"], "000600010002000400010003", "La causale del dettaglio della scrittura è corrispondente");

            //SECONDO DETTAGLIO SCRITTURA
            var descr2 =
                " Human Interleukin 10 (IL-10) ELISA BTB-E0102HU\r\n";
            q filterEDetail2 = q.eq("description", descr2) & q.eq("idacc","18000200010002000500010003");
            var EntryDetail2Rows = tEntrydetail._Filter(filterEDetail2);
            var EntryDetail2 = EntryDetail2Rows[0];
            Assert.AreEqual(EntryDetail2["description"], descr2, "La descrizione del dettaglio della scrittura è corrispondente");
            //Assert.AreEqual(EntryDetail2["idacc"], "18000200010002000500010003", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idupb"], "000100030003000200020701", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idreg"], 122805, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idaccmotive"], "000600010002000400010003", "La causale del dettaglio della scrittura è corrispondente");

            //PRENDO I DATI  DEL CONTRATTO PASSIVO ASSOCIATO ALLA FATTURA   
            q filterMan = q.eq("idmankind", rInvD["idmankind"]) & q.eq("yman", rInvD["yman"]) & q.eq("nman", rInvD["nman"]);
            t.binaryReplaceSet(filterMan, t.getTableSet(TestHelp.mainObject.mandate));
            DataTable tMandate = t.testConn.readTable("mandate", filterMan);
            Assert.AreEqual(1, tMandate.Rows.Count, "Il contratto esiste");
            DataTable tMandateDetail = t.testConn.readTable("mandatedetail", filterMan);
            var rMandateDetail = tMandateDetail.Rows[0];

            //CONTROLLO CORRISPONDENZA TRA DETTAGLI CONTRATTO E DETTAGLI SCRITTURA 
            Assert.AreEqual(EntryDetail1["idepexp"], rMandateDetail["idepexp"]);

        }

        [TestMethod]
        public void Test_FattAcquisto_movbudget_2018_CollegMandate()
        {
            var t = new TestHelp(new DateTime(2018, 12, 31));
            q filterInv = q.eq("idinvkind", 90) & q.eq("yinv", 2018) & q.eq("ninv", 13);
            t.binaryReplaceSet(filterInv, t.getTableSet(TestHelp.mainObject.invoice));
            DataTable tInvoice = t.testConn.readTable("invoice", filterInv);
            Assert.AreEqual(1, tInvoice.Rows.Count, "La fattura esiste");
            DataTable tInvoiceDetail = t.testConn.readTable("invoicedetail", filterInv);
            int nEstDet = tInvoiceDetail.Rows.Count;
            Assert.AreNotEqual(0, nEstDet, "La fattura non ha dettagli");
            DataRow rInv = tInvoice.Rows[0];
            var dsEP = t.getEpData(t.testConn, rInv);
            t.deleteEp(rInv);

            //CONTROLLO PER REGOLE 
            ProcedureMessageCollection regole = t.generateEP(rInv);
            if (regole != null) 
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");

            Assert.AreEqual(0, dsEP.Tables["epexp"].Rows.Count, $"Non ci sono movimenti di budget");
        }
       
        [TestMethod]
        public void Test_FattAcquisto_scritt_2018_NonCollegMandate()
        {
            var t = new TestHelp(new DateTime(2018, 12, 31));
            q filterInv = q.eq("idinvkind", 93) & q.eq("yinv", 2018) & q.eq("ninv", 16);
            t.binaryReplaceSet(filterInv, t.getTableSet(TestHelp.mainObject.invoice));
            DataTable tInvoice = t.testConn.readTable("invoice", filterInv);
            DataRow rInv = tInvoice.Rows[0];
            Assert.AreEqual(1, tInvoice.Rows.Count, "La fattura esiste");
            t.binaryCopyEp(rInv, false);
            DataTable tInvoiceDetail = t.testConn.readTable("invoicedetail", filterInv);
            int nInvDet = tInvoiceDetail.Rows.Count;
            Assert.AreEqual(2, nInvDet, "La fattura ha 2 dettagli");
            DataRow invDet1 = tInvoiceDetail.Rows[0];
            DataRow invDet2 = tInvoiceDetail.Rows[1];
            string idrelated1 = BudgetFunction.GetIdForDocument(invDet1);
            object idepexp1 = invDet1["idepexp"];
            t.binaryCopyEp(rInv, false);

            //CONTROLLO PER REGOLE 
            ProcedureMessageCollection regole = t.generateEP(rInv);
            if(regole != null) 
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rInv);
            var tEntrydetail = dsEP.Tables["entrydetail"];
            var tEntry = dsEP.Tables["entry"];
            var rEntry = tEntry.Rows[0];
            DataRow[] rEpexp = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2));
            DataRow dr1_epexp = rEpexp[0];

            var date_doc_colleg = new DateTime(2018, 3, 31);
            var date_contab = new DateTime(2018, 5, 3);
            var descr0 =
	            "Noleggio per 36 mesi n. 1 multifunzione Olivetti in convenzione Apparecchiature Multifunzione 26 - Lotto 3 - Rata 2 Gennaio-Marzo 2018";
            Assert.AreEqual(rEntry["description"], descr0, "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "A20020181000007116", "La descrizione del documento collegato è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del docuemento collegato della scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");

            //PRIMO DETTAGLIO SCRITTURA 
            var descr1 =
                "Arrotondamento negativo. Noleggio per 36 mesi n. 1 multifunzione Olivetti in convenzione Apparecchiature Multifunzione 26 - Lotto 3 - Rata 2 Gen-Mar";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1);
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(EntryDetail1["description"], descr1, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idacc"], "18000200010002001100020003", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idupb"], "000100030005000200010099", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idreg"], 131304, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idaccmotive"], "000600010002000900020003", "La causale del dettaglio della scrittura è corrispondente");

            //SECONDO DETTAGLIO SCRITTURA
            var descr2 =
                "Noleggio per 36 mesi n. 1 multifunzione Olivetti in convenzione Apparecchiature Multifunzione 26 - Lotto 3 - Rata 2 Gennaio-Marzo 2018";
            q filterEDetail2 = q.eq("description", descr2);
            var EntryDetail2Rows = tEntrydetail._Filter(filterEDetail2);
            var EntryDetail2 = EntryDetail2Rows[0];
            Assert.AreEqual(EntryDetail2["description"], descr2, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idacc"], "18000200010002001100020003", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idupb"], "000100030005000200010099", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idreg"], 131304, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idaccmotive"], "000600010002000900020003", "La causale del dettaglio della scrittura è corrispondente");

            //CONTROLLO CORRISPONDENZA TRA PRIMO DETTAGLIO SCRITTURA E MOVIMENTO DI BUDGET
            Assert.AreEqual(EntryDetail1["idepexp"], dr1_epexp["idepexp"]);
            Assert.AreEqual(EntryDetail1["idrelated"], dr1_epexp["idrelated"]);

            //CONTROLLO CORRISPONDENZA TRA SECONDO DETTAGLIO SCRITTURA E MOVIMENTO DI BUDGET
            Assert.AreEqual(EntryDetail2["idepexp"], idepexp1);
            Assert.AreEqual(EntryDetail2["idrelated"], idrelated1);

            q filterEpExp = q.eq("description", descr1) & q.eq("nphase",2);
            var epexpRows = dsEP.Tables["epexp"]._Filter(filterEpExp);
            Assert.IsTrue(CheckDatiFattAcquisto(tEntrydetail, epexpRows,0.91m,1,3));

        }

        [TestMethod]
        public void Test_FattAcquisto_movbudget_2018_NonCollegMandate()
        {
            var t = new TestHelp(new DateTime(2018, 12, 31));
            q filterInv = q.eq("idinvkind", 93) & q.eq("yinv", 2018) & q.eq("ninv", 16);
            t.binaryReplaceSet(filterInv, t.getTableSet(TestHelp.mainObject.invoice));
            DataTable tInvoice = t.testConn.readTable("invoice", filterInv);
            Assert.AreEqual(1, tInvoice.Rows.Count, "La fattura esiste");
            DataTable tInvoiceDetail = t.testConn.readTable("invoicedetail", filterInv & q.isNull("idmankind"));
            int nEstDet = tInvoiceDetail.Rows.Count;
            Assert.AreNotEqual(0, nEstDet, "La fattura non ha dettagli");
            DataRow rInv = tInvoice.Rows[0];
            t.binaryCopyEp(rInv, false);

            //CONTROLLO PER REGOLE 
            ProcedureMessageCollection regole = t.generateEP(rInv);
            if(regole != null) 
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rInv);
            //VERIFICA VARIAZIONI AI MOVIMENTI DI BUDGET
            DataRow[] rEpexpvar = dsEP.Tables["epexpvar"]._Filter(null);
            Assert.AreEqual(rEpexpvar.Length, 0, "Sono  presenti 0 variazioni");
            
            var tEntrydetail = dsEP.Tables["entrydetail"];
            DataRow[] rEpexp = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2));
            DataRow[] rEpexpyear = dsEP.Tables["epexpyear"]._Filter(q.eq("ayear", 2018));
           
            //IMPEGNO VAR. BUDGET ASSOCIATO AL CONTRATTO PASSIVO
            DataRow dr1_epexp = rEpexp[0];
            DataRow dr1_epexpyear = rEpexpyear[0];
            var descr1 =
              "Arrotondamento negativo. Noleggio per 36 mesi n. 1 multifunzione Olivetti in convenzione Apparecchiature Multifunzione 26 - Lotto 3 - Rata 2 Gen-Mar";
            Assert.AreEqual(dr1_epexp["description"], descr1, "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epexpyear["amount"], 0.91m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexpyear["idacc"], "18000200010002001100020003", " Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(dr1_epexpyear["idupb"], "000100030005000200010099", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexp["idaccmotive"], "000600010002000900020003", "La causale del mov.budget è corrispondente");

            //CONTROLLO CORRISPONDENZA TRA SCRITTURA E MOVIMENTO DI BUDGET
            Assert.AreEqual(tEntrydetail.Rows[0]["idepexp"], dr1_epexp["idepexp"]);
            Assert.AreEqual(tEntrydetail.Rows[0]["idrelated"], dr1_epexp["idrelated"]);

            q filterEpExp = q.eq("description", descr1) & q.eq("nphase", 2);
            var epexpRows = dsEP.Tables["epexp"]._Filter(filterEpExp);
            Assert.IsTrue(CheckDatiFattAcquisto(tEntrydetail, epexpRows, 0.91m, 1, 3));
        }

        [TestMethod]
        public void Test_FattVendita_scritt_2018_CollegEstimate()
        {
            var t = new TestHelp(new DateTime(2018, 12, 31));
            q filterInv = q.eq("idinvkind", 10) & q.eq("yinv", 2018) & q.eq("ninv", 2);
            t.binaryReplaceSet(filterInv, t.getTableSet(TestHelp.mainObject.invoice));
            DataTable tInvoice = t.testConn.readTable("invoice", filterInv);
            Assert.AreEqual(1, tInvoice.Rows.Count, "La fattura esiste");
            DataTable tInvoiceDetail = t.testConn.readTable("invoicedetail", filterInv & q.isNotNull("idestimkind"));
            int nEstDet = tInvoiceDetail.Rows.Count;
            Assert.AreNotEqual(0, nEstDet, "La fattura non ha dettagli");
            DataRow rInv = tInvoice.Rows[0];
            DataRow rInvD = tInvoiceDetail.Rows[0];
            
            t.binaryCopyEp(rInv, false);

            //CONTROLLO PER REGOLE 
            ProcedureMessageCollection regole = t.generateEP(rInv);
            if(regole != null) 
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rInv);
            var tEntrydetail = dsEP.Tables["entrydetail"];
            var tEntry = dsEP.Tables["entry"];
            var rEntry = tEntry.Rows[0];

            var date_doc_colleg = new DateTime(2018, 3, 19);
            var date_contab = new DateTime(2018, 3, 19);
            Assert.AreEqual(rEntry["description"], "Affitto sala Cripta presso complesso Sant'Andrea per Convegno\"Apprendere in azienda: un'alleanza per il lavoro\" del 09/02/2018 dalle  09:30 alle 13:30", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "18/000002", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");

            //PRIMO DETTAGLIO SCRITTURA
            var descr1 =
                "Utilizzo Sala Cripta per convegno \"Apprendere in azienda: un'alleanza per il lavoro\" 09/02/2018 dalle ore 09:30 alle 13:30";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1);
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(EntryDetail1["description"], descr1 , "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idacc"], "18000100010005000100010010", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idupb"], "000100030006000100010137", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idreg"], 137789, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idaccmotive"], "000700010005000100010010", "La causale del dettaglio della scrittura è corrispondente");

            //SECONDO DETTAGLIO SCRITTURA
            var descr2 =
                "Fattura FATTVEND-disum n.2 / 2018";
            q filterEDetail2 = q.eq("description", descr2);
            var EntryDetail2Rows = tEntrydetail._Filter(filterEDetail2);
            var EntryDetail2 = EntryDetail2Rows[0];
            Assert.AreEqual(EntryDetail2["description"], descr2, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idacc"], "18000400040001000200010001", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idupb"], "000100010008", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idreg"], 137789, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idaccmotive"], "000700010005000100010010", "La causale del dettaglio della scrittura è corrispondente");

            //PRENDO I DATI  DEL CONTRATTO ATTIVO ASSOCIATO ALLA FATTURA   
            q filterEst = q.eq("idestimkind", rInvD["idestimkind"]) & q.eq("yestim", rInvD["yestim"]) & q.eq("nestim", rInvD["nestim"]);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst);
            var rEstimateDetail = tEstimateDetail.Rows[0];

            //CONTROLLO CORRISPONDENZA TRA DETTAGLI CONTRATTO E DETTAGLI SCRITTURA 
            Assert.AreEqual(EntryDetail1["idepacc"], rEstimateDetail["idepacc"]);
        }

        [TestMethod]
        public void Test_FattVendita_movbudget_2018_CollegEstimate()
        {
            var t = new TestHelp(new DateTime(2018, 12, 31));
            q filterInv = q.eq("idinvkind", 10) & q.eq("yinv", 2018) & q.eq("ninv", 2);
            t.binaryReplaceSet(filterInv, t.getTableSet(TestHelp.mainObject.invoice));
            DataTable tInvoice = t.testConn.readTable("invoice", filterInv);
            Assert.AreEqual(1, tInvoice.Rows.Count, "La fattura esiste");
            DataTable tInvoiceDetail = t.testConn.readTable("invoicedetail", filterInv & q.isNotNull("idestimkind"));
            int nEstDet = tInvoiceDetail.Rows.Count;
            Assert.AreNotEqual(0, nEstDet, "La fattura non ha dettagli");
            DataRow rInv = tInvoice.Rows[0];
            var dsEP = t.getEpData(t.testConn, rInv);
            t.deleteEp(rInv);

            //CONTROLLO PER REGOLE 
            ProcedureMessageCollection regole = t.generateEP(rInv);
            if(regole != null) 
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");

            
            Assert.AreEqual(0, dsEP.Tables["epacc"].Rows.Count, $"Non ci sono movimenti di budget");
        }

        [TestMethod]
        public void Test_FattVendita_scritt_2018_NonCollegEstimate()
        {
            var t = new TestHelp(new DateTime(2018, 12, 31));
            q filterInv = q.eq("idinvkind", 229) & q.eq("yinv", 2018) & q.eq("ninv", 10);
            t.binaryReplaceSet(filterInv, t.getTableSet(TestHelp.mainObject.invoice));
            DataTable tInvoice = t.testConn.readTable("invoice", filterInv);
            Assert.AreEqual(1, tInvoice.Rows.Count, "La fattura esiste");
            DataTable tInvoiceDetail = t.testConn.readTable("invoicedetail", filterInv & q.isNull("idmankind"));
            int nEstDet = tInvoiceDetail.Rows.Count;
            Assert.AreNotEqual(0, nEstDet, "La fattura non ha dettagli");
            DataRow rInv = tInvoice.Rows[0];
            t.binaryCopyEp(rInv, false);

            //CONTROLLO PER REGOLE 
            ProcedureMessageCollection regole = t.generateEP(rInv);
            if(regole != null) 
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rInv);

            var tEntrydetail = dsEP.Tables["entrydetail"];
            var tEntry = dsEP.Tables["entry"];
            var rEntry = tEntry.Rows[0];
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2));
            DataRow dr1_epacc = rEpacc[0];

            var date_doc_colleg = new DateTime(2018, 10, 19);
            var date_contab = new DateTime(2018, 11, 14);
            Assert.AreEqual(rEntry["description"], "Utenza gas maggio-settembre 2018 - AL04  Via Mondovì - storno", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "181902324505", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");

            //DETTAGLIO SCRITTURA 
            var descr1 =
                "Utenza gas maggio-settembre 2018 - AL04  Via Mondovì - storno";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1);
            var EntryDetail1 = EntryDetail1Rows[0];            
            Assert.AreEqual(EntryDetail1["description"], descr1 , "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idacc"], "18000100010005000100020012", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idupb"], "000100020002000600030004", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idreg"], 139358, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idaccmotive"], "000700010005000100020012", "La causale del dettaglio della scrittura è corrispondente");

            //CONTROLLO CORRISPONDENZA TRA SECONDO DETTAGLIO SCRITTURA E MOVIMENTO DI BUDGET
            Assert.AreEqual(tEntrydetail.Rows[1]["idepacc"], dr1_epacc["idepacc"]);
            Assert.AreEqual(tEntrydetail.Rows[1]["idrelated"], dr1_epacc["idrelated"]);

            q filterEpacc = q.eq("description", descr1) & q.eq("nphase", 2);
            var epaccRows = dsEP.Tables["epacc"]._Filter(filterEpacc);
            Assert.IsTrue(CheckDatiFattVendita(tEntrydetail, epaccRows, 207.45m, 1, 4));

        }

        [TestMethod]
        public void Test_FattVendita_movbudget_2018_NonCollegEstimate()
        {
            var t = new TestHelp(new DateTime(2018, 12, 31));
            q filterInv = q.eq("idinvkind", 229) & q.eq("yinv", 2018) & q.eq("ninv", 10);
            t.binaryReplaceSet(filterInv, t.getTableSet(TestHelp.mainObject.invoice));
            DataTable tInvoice = t.testConn.readTable("invoice", filterInv);
            Assert.AreEqual(1, tInvoice.Rows.Count, "La fattura esiste");
            DataTable tInvoiceDetail = t.testConn.readTable("invoicedetail", filterInv & q.isNull("idmankind") & q.isNull("idestimkind"));
            int nEstDet = tInvoiceDetail.Rows.Count;
            Assert.AreNotEqual(0, nEstDet, "La fattura non ha dettagli");
            DataRow rInv = tInvoice.Rows[0];
            t.binaryCopyEp(rInv, false);

            //CONTROLLO PER REGOLE 
            ProcedureMessageCollection regole = t.generateEP(rInv);
            if(regole != null) 
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rInv);
            //VERIFICA VARIAZIONI AI MOVIMENTI DI BUDGET
            DataRow[] rEpaccpvar = dsEP.Tables["epaccvar"]._Filter(null);
            Assert.AreEqual(rEpaccpvar.Length, 0, "Sono  presenti 0 variazioni");
        
            var tEntrydetail = dsEP.Tables["entrydetail"];
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2)); 
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2018));
            //IMPEGNO VAR. BUDGET ASSOCIATO AL CONTRATTO PASSIVO
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            var descr1 =
                "Utenza gas maggio-settembre 2018 - AL04  Via Mondovì - storno";
            Assert.AreEqual(dr1_epacc["description"], descr1, "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epaccyear["amount"], 253.09m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idacc"], "18000100010005000100020012", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idupb"], "000100020002000600030004", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["idaccmotive"], "000700010005000100020012", "La causale del mov.budget è corrispondente");

            //CONTROLLO CORRISPONDENZA TRA SCRITTURA E MOVIMENTO DI BUDGET
            Assert.AreEqual(tEntrydetail.Rows[0]["idepacc"], dr1_epacc["idepacc"]);
            Assert.AreEqual(tEntrydetail.Rows[0]["idrelated"], dr1_epacc["idrelated"]);

            q filterEpacc = q.eq("description", descr1) & q.eq("nphase", 2);
            var epaccRows = dsEP.Tables["epacc"]._Filter(filterEpacc);
            Assert.IsTrue(CheckDatiFattVendita(tEntrydetail, epaccRows, 207.45m, 1, 4));

        }

        [TestMethod]
        public void Test_FattAcquisto_scritt_2017_CollegMandate()
        {
            var t = new TestHelp(new DateTime(2018, 12, 31));
            q filterInv = q.eq("idinvkind", 26) & q.eq("yinv", 2017) & q.eq("ninv", 1);
            t.binaryReplaceSet(filterInv, t.getTableSet(TestHelp.mainObject.invoice));
            DataTable tInvoice = t.testConn.readTable("invoice", filterInv);
            Assert.AreEqual(1, tInvoice.Rows.Count, "La fattura esiste");
            DataTable tInvoiceDetail = t.testConn.readTable("invoicedetail", filterInv);
            int nEstDet = tInvoiceDetail.Rows.Count;
            Assert.AreNotEqual(0, nEstDet, "La fattura non ha dettagli");
            DataRow rInv = tInvoice.Rows[0];
            DataRow rInvD = tInvoiceDetail.Rows[0];
            t.binaryCopyEp(rInv, false);

            //CONTROLLO PER REGOLE 
            ProcedureMessageCollection regole = t.generateEP(rInv);
            if(regole != null) 
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rInv);
            var tEntrydetail = dsEP.Tables["entrydetail"];
            var tEntry = dsEP.Tables["entry"];
            var rEntry = tEntry.Rows[0];

            var date_doc_colleg = new DateTime(2016, 12, 27);
            var date_contab = new DateTime(2017, 1, 31);
            Assert.AreEqual(rEntry["description"], "Materiale di laboratorio ", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "Invoice n. 31001687", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");

            //DETTAGLIO SCRITTURA 
            var descr1 =
                "A12864 L03408 Bromotriphenylmethane";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1);
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(EntryDetail1["description"], descr1 , "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idacc"], "170002000800010001", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idupb"], "000100030003000200020628", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idreg"], 133844, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idaccmotive"], "000200080001", "La causale del dettaglio della scrittura è corrispondente");

            //PRENDO I DATI  DEL CONTRATTO PASSIVO ASSOCIATO ALLA FATTURA   
            q filterMan = q.eq("idmankind", rInvD["idmankind"]) & q.eq("yman", rInvD["yman"]) & q.eq("nman", rInvD["nman"]);
            t.binaryReplaceSet(filterMan, t.getTableSet(TestHelp.mainObject.mandate));
            DataTable tMandate = t.testConn.readTable("mandate", filterMan);
            Assert.AreEqual(1, tMandate.Rows.Count, "Il contratto esiste");
            DataTable tMandateDetail = t.testConn.readTable("mandatedetail", filterMan);
            var rMandateDetail = tMandateDetail.Rows[0];

            //CONTROLLO CORRISPONDENZA TRA DETTAGLI CONTRATTO E DETTAGLI SCRITTURA 
            Assert.AreEqual(tEntrydetail.Rows[0]["idepexp"], rMandateDetail["idepexp"]);
        }

        //[TestMethod]
        //public void Test_FattAcquisto_movbudget_2017_CollegMandate()
        //{
        //    var t = new TestHelp(new DateTime(2018, 12, 31));
        //    q filterInv = q.eq("idinvkind", 26) & q.eq("yinv", 2017) & q.eq("ninv", 1);
        //    t.binaryReplaceSet(filterInv, t.getTableSet(TestHelp.mainObject.invoice));
        //    DataTable tInvoice = t.testConn.readTable("invoice", filterInv);
        //    Assert.AreEqual(1, tInvoice.Rows.Count, "La fattura esiste");
        //    DataTable tInvoiceDetail = t.testConn.readTable("invoicedetail", filterInv);
        //    int nEstDet = tInvoiceDetail.Rows.Count;
        //    Assert.AreNotEqual(0, nEstDet, "La fattura non ha dettagli");
        //    DataRow rInv = tInvoice.Rows[0];
        //    var dsEP = t.getEpData(t.testConn, rInv);
        //    t.deleteEp(rInv);

        //    //CONTROLLO PER REGOLE 
        //    ProcedureMessageCollection regole = t.generateEP(rInv);
        //    if(regole != null) 
        //        Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");

        //    Assert.AreEqual(0, dsEP.Tables["epexp"].Rows.Count, $"Non ci sono movimenti di budget");
        //}

        [TestMethod]
        public void Test_FattAcquisto_scritt_2017_NonCollegMandate()
        {
            var t = new TestHelp(new DateTime(2017, 12, 31));
            q filterInv = q.eq("idinvkind", 81) & q.eq("yinv", 2017) & q.eq("ninv", 16);
            t.binaryReplaceSet(filterInv, t.getTableSet(TestHelp.mainObject.invoice));
            DataTable tInvoice = t.testConn.readTable("invoice", filterInv);
            Assert.AreEqual(1, tInvoice.Rows.Count, "La fattura esiste");
            DataTable tInvoiceDetail = t.testConn.readTable("invoicedetail", filterInv & q.isNull("idmankind"));
            int nEstDet = tInvoiceDetail.Rows.Count;
            Assert.AreNotEqual(0, nEstDet, "La fattura non ha dettagli");
            DataRow rInv = tInvoice.Rows[0];     
            t.binaryCopyEp(rInv, false);

            //CONTROLLO PER REGOLE 
            ProcedureMessageCollection regole = t.generateEP(rInv);
            var dsEP = t.getEpData(t.testConn, rInv);
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            
            var tEntrydetail = dsEP.Tables["entrydetail"];
            var tEntry = dsEP.Tables["entry"];
            var rEntry = tEntry.Rows[0];
            DataRow[] rEpexp = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2));
            DataRow dr1_epexp = rEpexp[0];

            var date_doc_colleg = new DateTime(2017, 2, 28);
            var date_contab = new DateTime(2017, 5, 2);
            Assert.AreEqual(rEntry["description"], "Accesso Area C Milano del 26/01/2016", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "Doc. 309742/A", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");

            //PRIMO DETTAGLIO SCRITTURA 
            var descr1 =
                "Servizi di pedaggio per aree urbane - area c milano";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1);
            var EntryDetail1 = EntryDetail1Rows[0];     
            Assert.AreEqual(EntryDetail1["description"], descr1, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idacc"], "170002001000020010", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idupb"], "000100020002000300010004", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idreg"], 11993, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idaccmotive"], "0002001000020010", "La causale del dettaglio della scrittura è corrispondente");

            //SECONDO DETTAGLIO SCRITTURA
            var descr2 =
                "Fattura ACQIST-amm n.16 / 2017";
            q filterEDetail2 = q.eq("description", descr2);
            var EntryDetail2Rows = tEntrydetail._Filter(filterEDetail2);
            var EntryDetail2 = EntryDetail2Rows[0];
            Assert.AreEqual(EntryDetail2["description"], descr2, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idacc"], "170004000600090001", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idupb"], "000100020002000300010004", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idreg"], 11993, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail2["idaccmotive"], "0002001000020010", "La causale del dettaglio della scrittura è corrispondente");

            //CONTROLLO CORRISPONDENZA TRA PRIMO DETTAGLIO SCRITTURA E MOVIMENTO DI BUDGET
            Assert.AreEqual(EntryDetail1["idepexp"], dr1_epexp["idepexp"]);
            Assert.AreEqual(EntryDetail1["idrelated"], dr1_epexp["idrelated"]);

            //CONTROLLO CORRISPONDENZA TRA SECONDO DETTAGLIO SCRITTURA E MOVIMENTO DI BUDGET
            Assert.AreEqual(EntryDetail2["idepexp"], dr1_epexp["idepexp"]);
            Assert.AreEqual(EntryDetail2["idrelated"], dr1_epexp["idrelated"]);

            q filterEpExp = q.eq("description", descr1) & q.eq("nphase", 2);
            var epexpRows = dsEP.Tables["epexp"]._Filter(filterEpExp & q.eq("nphase", 2));
            Assert.IsTrue(CheckDatiFattAcquisto(tEntrydetail, epexpRows, -5.00m, 1, 3));
        }

        [TestMethod]
        public void Test_FattAcquisto_movbudget_2017_NonCollegMandate()
        {
            var t = new TestHelp(new DateTime(2018, 12, 31));
            q filterInv = q.eq("idinvkind", 81) & q.eq("yinv", 2017) & q.eq("ninv", 16);
            t.binaryReplaceSet(filterInv, t.getTableSet(TestHelp.mainObject.invoice));
            DataTable tInvoice = t.testConn.readTable("invoice", filterInv);
            Assert.AreEqual(1, tInvoice.Rows.Count, "La fattura esiste");
            DataTable tInvoiceDetail = t.testConn.readTable("invoicedetail", filterInv & q.isNull("idmankind"));
            int nEstDet = tInvoiceDetail.Rows.Count;
            Assert.AreNotEqual(0, nEstDet, "La fattura non ha dettagli");
            DataRow rInv = tInvoice.Rows[0];
            var dsEP = t.getEpData(t.testConn, rInv);
            t.deleteEp(rInv);

            //CONTROLLO PER REGOLE 
            ProcedureMessageCollection regole = t.generateEP(rInv);
            if(regole != null) 
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");

            //VERIFICA VARIAZIONI AI MOVIMENTI DI BUDGET
            DataRow[] rEpexpvar = dsEP.Tables["epexpvar"]._Filter(null);
            Assert.AreEqual(rEpexpvar.Length, 0, "Sono  presenti 0 variazioni");
       
            var tEntrydetail = dsEP.Tables["entrydetail"];
            DataRow[] rEpexp = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2));
            DataRow[] rEpexpyear = dsEP.Tables["epexpyear"]._Filter(q.eq("ayear", 2017));

            //IMPEGNO VAR. BUDGET ASSOCIATO AL CONTRATTO PASSIVO
            DataRow dr1_epexp = rEpexp[0];
            DataRow dr1_epexpyear = rEpexpyear[0];
            var descr1 =
                "Servizi di pedaggio per aree urbane - area c milano";
            Assert.AreEqual(dr1_epexp["description"], descr1, "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epexpyear["amount"], 5.00m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexpyear["idacc"], "170002001000020010", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexpyear["idupb"], "000100020002000300010004", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexp["idaccmotive"], "0002001000020010", "La causale del mov.budget è corrispondente");

            //CONTROLLO CORRISPONDENZA TRA SCRITTURA E MOVIMENTO DI BUDGET
            Assert.AreEqual(tEntrydetail.Rows[0]["idepexp"], dr1_epexp["idepexp"]);
            Assert.AreEqual(tEntrydetail.Rows[0]["idrelated"], dr1_epexp["idrelated"]);

            q filterEpExp = q.eq("description", descr1) & q.eq("nphase", 2);
            var epexpRows = dsEP.Tables["epexp"]._Filter(filterEpExp & q.eq("nphase", 2));
            Assert.IsTrue(CheckDatiFattAcquisto(tEntrydetail, epexpRows, -5.00m, 1, 3));
        }

        [TestMethod]
        public void Test_FattVendita_scritt_2017_CollegEstimate()
        {
            var t = new TestHelp(new DateTime(2018, 12, 31));
            q filterInv = q.eq("idinvkind", 19) & q.eq("yinv", 2017) & q.eq("ninv", 4);
            t.binaryReplaceSet(filterInv, t.getTableSet(TestHelp.mainObject.invoice));
            DataTable tInvoice = t.testConn.readTable("invoice", filterInv);
            Assert.AreEqual(1, tInvoice.Rows.Count, "La fattura esiste");
            DataTable tInvoiceDetail = t.testConn.readTable("invoicedetail", filterInv & q.isNotNull("idestimkind"));
            int nEstDet = tInvoiceDetail.Rows.Count;
            Assert.AreNotEqual(0, nEstDet, "La fattura non ha dettagli");
            DataRow rInv = tInvoice.Rows[0];
            DataRow rInvD = tInvoiceDetail.Rows[0];
            var dsEP = t.getEpData(t.testConn, rInv);
            t.deleteEp(rInv);

            //CONTROLLO PER REGOLE 
            ProcedureMessageCollection regole = t.generateEP(rInv);
            if(regole != null) 
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
  
            var tEntrydetail = dsEP.Tables["entrydetail"];
            var tEntry = dsEP.Tables["entry"];
            var rEntry = tEntry.Rows[0];

            var date_doc_colleg = new DateTime(2017, 11, 17);
            var date_contab = new DateTime(2017, 11, 17);
            Assert.AreEqual(rEntry["description"], "consegna diplomi scuola di lingua e cultura italiana", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "17/000004", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");

            //DETTAGLIO SCRITTURA 
            var descr1 =
               "consegna diplomi scuola di lingua e cultura italiana";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1);
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(EntryDetail1["description"], descr1, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idacc"], "170001000600020003", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idupb"], "000100030005000200010110", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idreg"], 134014, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idaccmotive"], "0001000600020003", "La causale del dettaglio della scrittura è corrispondente");

            //PRENDO I DATI  DEL CONTRATTO ATTIVO ASSOCIATO ALLA FATTURA   
            q filterEst = q.eq("idestimkind", rInvD["idestimkind"]) & q.eq("yestim", rInvD["yestim"]) & q.eq("nestim", rInvD["nestim"]);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst);
            var rEstimateDetail = tEstimateDetail.Rows[0];

            //CONTROLLO CORRISPONDENZA TRA DETTAGLI CONTRATTO E DETTAGLI SCRITTURA 
            Assert.AreEqual(EntryDetail1["idepacc"], rEstimateDetail["idepacc"]);
        }

        [TestMethod]
        public void Test_FattVendita_movbudget_2017_CollegEstimate()
        {
            var t = new TestHelp(new DateTime(2018, 12, 31));
            q filterInv = q.eq("idinvkind", 19) & q.eq("yinv", 2017) & q.eq("ninv", 4);
            t.binaryReplaceSet(filterInv, t.getTableSet(TestHelp.mainObject.invoice));
            DataTable tInvoice = t.testConn.readTable("invoice", filterInv);
            Assert.AreEqual(1, tInvoice.Rows.Count, "La fattura esiste");
            DataTable tInvoiceDetail = t.testConn.readTable("invoicedetail", filterInv & q.isNotNull("idestimkind"));
            int nEstDet = tInvoiceDetail.Rows.Count;
            Assert.AreNotEqual(0, nEstDet, "La fattura non ha dettagli");
            DataRow rInv = tInvoice.Rows[0];
            var dsEP = t.getEpData(t.testConn, rInv);
            t.deleteEp(rInv);

            //CONTROLLO PER REGOLE 
            ProcedureMessageCollection regole = t.generateEP(rInv);
            if(regole != null) 
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");

            Assert.AreEqual(0, dsEP.Tables["epacc"].Rows.Count, $"Non ci sono movimenti di budget");
        }

        [TestMethod]
        public void Test_FattVendita_scritt_2017_NonCollegEstimate()
        {
            var t = new TestHelp(new DateTime(2018, 12, 31));
            q filterInv = q.eq("idinvkind", 25) & q.eq("yinv", 2017) & q.eq("ninv", 1);
            t.binaryReplaceSet(filterInv, t.getTableSet(TestHelp.mainObject.invoice));
            DataTable tInvoice = t.testConn.readTable("invoice", filterInv);
            Assert.AreEqual(1, tInvoice.Rows.Count, "La fattura esiste");
            DataTable tInvoiceDetail = t.testConn.readTable("invoicedetail", filterInv & q.isNull("idmankind"));
            int nEstDet = tInvoiceDetail.Rows.Count;
            Assert.AreNotEqual(0, nEstDet, "La fattura non ha dettagli");
            DataRow rInv = tInvoice.Rows[0];
            var dsEP = t.getEpData(t.testConn, rInv);
            t.deleteEp(rInv);

            //CONTROLLO PER REGOLE 
            ProcedureMessageCollection regole = t.generateEP(rInv);
            if(regole != null) 
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");

            
            var tEntrydetail = dsEP.Tables["entrydetail"];
            var tEntry = dsEP.Tables["entry"];
            var rEntry = tEntry.Rows[0];
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2));
            DataRow dr1_epacc = rEpacc[0];

            var date_doc_colleg = new DateTime(2017, 1, 31);
            var date_contab = new DateTime(2017, 1, 31);
            Assert.AreEqual(rEntry["description"], "Corrispettivi fotocopie DiSEI - 31 Gennaio 2017", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "17/000001", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");

            //DETTAGLIO SCRITTURA
            var descr1 =
                "Corrispettivi fotocopie DiSEI - 31 Gennaio 2017";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1);
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(EntryDetail1["description"], descr1 , "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idacc"], "170001000600020004", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idupb"], "000100030005000200010108", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idreg"], 40028, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idaccmotive"], "0001000600020004", "La causale del dettaglio della scrittura è corrispondente");

            //CONTROLLO CORRISPONDENZA TRA SECONDO DETTAGLIO SCRITTURA E MOVIMENTO DI BUDGET
            Assert.AreEqual(EntryDetail1["idepacc"], dr1_epacc["idepacc"]);
            Assert.AreEqual(EntryDetail1["idrelated"], dr1_epacc["idrelated"]);

            q filterEpacc = q.eq("description", descr1) & q.eq("nphase", 2);
            var epaccRows = dsEP.Tables["epacc"]._Filter(filterEpacc);
            Assert.IsTrue(CheckDatiFattVendita(tEntrydetail, epaccRows, 0, 1, 2));
        }
        
        [TestMethod]
        public void Test_FattVendita_movbudget_2017_NonCollegEstimate()
        {
            var t = new TestHelp(new DateTime(2018, 12, 31));
            q filterInv = q.eq("idinvkind", 25) & q.eq("yinv", 2017) & q.eq("ninv", 1);
            t.binaryReplaceSet(filterInv, t.getTableSet(TestHelp.mainObject.invoice));
            DataTable tInvoice = t.testConn.readTable("invoice", filterInv);
            Assert.AreEqual(1, tInvoice.Rows.Count, "La fattura esiste");
            DataTable tInvoiceDetail = t.testConn.readTable("invoicedetail", filterInv & q.isNull("idmankind") & q.isNull("idestimkind"));
            int nEstDet = tInvoiceDetail.Rows.Count;
            Assert.AreNotEqual(0, nEstDet, "La fattura non ha dettagli");
            DataRow rInv = tInvoice.Rows[0];
            var dsEP = t.getEpData(t.testConn, rInv);
            t.deleteEp(rInv);

            //CONTROLLO PER REGOLE 
            ProcedureMessageCollection regole = t.generateEP(rInv);
            if(regole != null) 
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");

            //VERIFICA VARIAZIONI AI MOVIMENTI DI BUDGET
            DataRow[] rEpaccpvar = dsEP.Tables["epaccvar"]._Filter(null);
            Assert.AreEqual(rEpaccpvar.Length, 0, "Sono  presenti 0 variazioni");
            
            var tEntrydetail = dsEP.Tables["entrydetail"];
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2));
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2017));
            //IMPEGNO VAR. BUDGET ASSOCIATO AL CONTRATTO PASSIVO
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            var descr1 =
                "Corrispettivi fotocopie DiSEI - 31 Gennaio 2017";
            Assert.AreEqual(dr1_epacc["description"], descr1, "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epaccyear["amount"], 154.63m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idacc"], "170001000600020004", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idupb"], "000100030005000200010108", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["idaccmotive"], "0001000600020004", "La causale del mov.budget è corrispondente");

            //CONTROLLO CORRISPONDENZA TRA SCRITTURA E MOVIMENTO DI BUDGET
            Assert.AreEqual(tEntrydetail.Rows[0]["idepacc"], dr1_epacc["idepacc"]);
            Assert.AreEqual(tEntrydetail.Rows[0]["idrelated"], dr1_epacc["idrelated"]);

            q filterEpacc = q.eq("description", descr1) & q.eq("nphase", 2);
            var epaccRows = dsEP.Tables["epacc"]._Filter(filterEpacc);
            Assert.IsTrue(CheckDatiFattVendita(tEntrydetail, epaccRows, 0, 1, 2));

        }

        [TestMethod]
        public void testDeleteEPFromMandate_ControlloRegole()
        {
            var t = new TestHelp(new DateTime(2018, 12, 31));
            /*man§VARI_GEST_nofattura§2018§1*/
            q filterMan = q.eq("idmankind", "VARI_GEST_nofattura") & q.eq("yman", 2018) & q.eq("nman", 1);
            t.binaryReplaceSet(filterMan, t.getTableSet(TestHelp.mainObject.mandate));
            DataTable tMandate = t.testConn.readTable("mandate", filterMan);
            Assert.AreEqual(1, tMandate.Rows.Count, "Il contratto passivo esiste");

            DataRow rMan = tMandate.Rows[0];
            t.binaryReplaceEp(rMan, false);
            t.generateEP(rMan);
            var idrelated = BudgetFunction.GetIdForDocument(rMan);
            string table;
            string filterRelated = BudgetFunction.getDocChildCondition(t.testConn.GetQueryHelper(), idrelated);
            int nBeforeEpexp = t.sampleConn.RUN_SELECT_COUNT("epexp", filterRelated, false);
           
            Assert.AreNotEqual(0, nBeforeEpexp /*+ nBeforeEpAcc*/);
            t.deleteEp(rMan);
            int nAfterDeleteEpExp = t.testConn.RUN_SELECT_COUNT("epexp", filterRelated, false);
           
            Assert.AreEqual(0, nAfterDeleteEpExp  /*+nAfterDeleteEpAcc*/);
            int countEPlinked = t.testConn.count("mandatedetail", filterMan & q.isNotNull("idepexp"));
            Assert.AreEqual(0, countEPlinked);

            //metaeasylibrary.Easy_PostData.rulesToIgnore.Add("ECOPA047");

            ProcedureMessageCollection regole = t.generateEP(rMan);
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");

            metaeasylibrary.Easy_PostData.rulesToIgnore.Clear();
            int nAfterGenerateEpExp = t.testConn.RUN_SELECT_COUNT("epexp", filterRelated, false);
           
            t.deleteEp(rMan);
            metaeasylibrary.Easy_PostData.ignoredRules.Clear();
            Assert.AreEqual(nBeforeEpexp, nAfterGenerateEpExp, "Scritture su contratto passivo");
          
        }


        [TestMethod]
        public void Test_AutofatturaIstituzionaleExtraUE_SENZA_flag_RecuperoIntraExtraUE() {
            /* 
             * CASO 1-Autofattura istituzionale Extra-UE SENZA flag "Recupero Intra ed Extra-UE"
            AZAGR-Autofatt. Acq. ISTITUZ. EXTRA UE 1/2021
            - verificare che scrittura 4634, 4635 e 4636/2021 non cambino
             * */
            var t = new TestHelp(new DateTime(2021, 12, 31), "sample_4", "test_4");
            q filterInv = q.eq("idinvkind", 295) & q.eq("yinv", 2021) & q.eq("ninv", 1);
            t.binaryReplaceSet(filterInv, t.getTableSet(TestHelp.mainObject.invoice));
            DataTable tInvoice = t.testConn.readTable("invoice", filterInv);
            Assert.AreEqual(1, tInvoice.Rows.Count, "La fattura esiste");

            DataRow rInv = tInvoice.Rows[0];
            t.binaryCopyEp(rInv, false);

            //CONTROLLO PER REGOLE 
            ProcedureMessageCollection regole = t.generateEP(rInv);
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rInv);

            var tEntrydetail = dsEP.Tables["entrydetail"];
            var tEntry = dsEP.Tables["entry"];
            var rEntry = tEntry.Rows[0];

            var date_doc_colleg = new DateTime(2021, 05, 21);
            var date_contab = new DateTime(2021, 05, 21);
            Assert.AreEqual(rEntry["description"], "IVA estera istituzionale SENZA RECUPERO", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "21/000001", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");

            //DETTAGLIO SCRITTURA 
            var descr1 =
                "IVA estera istituzionale SENZA RECUPERO";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1);
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(EntryDetail1["description"], descr1, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idacc"], "21000200010002000100010001", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idupb"], "0001000300010022", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idreg"], 19713, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idaccmotive"], "000100020001", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["amount"], -732m, "L'importo del dettaglio scrittura è corrispondente");
            //PRIMO DETTAGLIO SCRITTURA
            var rDet2 = tEntrydetail._Filter(q.eq("description",
                                                 "Fattura ACAIX_AZAGR n.1 / 2021")
                                             & q.eq("idacc", "21000300040002000400020001")).FirstOrDefault();

            Assert.IsNotNull(rDet2, "Trovato dettaglio 2 con conto e descrizione corrispondenti");
            Assert.AreEqual(rDet2["idupb"], "0001000300010022", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet2["idreg"], 19713, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet2["idaccmotive"], "000100020001", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet2["amount"], 600m, "L'importo del dettaglio scrittura è corrispondente");
            //SECONDO DETTAGLIO SCRITTURA
            var rDet3 = tEntrydetail._Filter(q.eq("description",
                                                 "Fattura ACAIX_AZAGR n.1 / 2021")
                                             & q.eq("idacc", "21000300040002000500070001")).FirstOrDefault();
            Assert.IsNotNull(rDet3, "Trovato dettaglio 3 con conto e descrizione corrispondenti");
            Assert.AreEqual(rDet3["idupb"], "0001000300010022", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet3["idreg"], 10791, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet3["idaccmotive"], "000100020001", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet3["amount"], 132m, "L'importo del dettaglio scrittura è corrispondente");
        }

        [TestMethod]
        public void Test_AutofatturaIstituzionaleExtraUE_CON_flag_RecuperoIntraExtraUE() {
            /* 
            CASO 2-Autofattura istituzionale Extra-UE CON flag "Recupero Intra ed Extra-UE"
            AUA-Autofatt. Acq. ISTITUZ. EXTRA UE 1/2021
             * */
            var t = new TestHelp(new DateTime(2021, 12, 31), "sample_4", "test_4");
            q filterInv = q.eq("idinvkind", 493) & q.eq("yinv", 2021) & q.eq("ninv", 1);
            t.binaryReplaceSet(filterInv, t.getTableSet(TestHelp.mainObject.invoice));
            DataTable tInvoice = t.testConn.readTable("invoice", filterInv);
            Assert.AreEqual(1, tInvoice.Rows.Count, "La fattura esiste");

            DataRow rInv = tInvoice.Rows[0];
            t.binaryCopyEp(rInv, false);

            //CONTROLLO PER REGOLE 
            ProcedureMessageCollection regole = t.generateEP(rInv);
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rInv);

            var tEntrydetail = dsEP.Tables["entrydetail"];
            var tEntry = dsEP.Tables["entry"];
            var rEntry = tEntry.Rows[0];

            var date_doc_colleg = new DateTime(2021, 05, 21);
            var date_contab = new DateTime(2021, 05, 21);
            Assert.AreEqual(rEntry["description"], "Test Recupero IVA estera istituzionale", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "21/000001", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");

            //DETTAGLIO SCRITTURA 
            var descr1 =
                "Test Recupero IVA estera istituzionale";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1);
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(EntryDetail1["description"], descr1, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idacc"], "21000200010002000100010001", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idupb"], "0001000300010022", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idreg"], 19713, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idaccmotive"], "000100020001", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["amount"], -732m, "L'importo del dettaglio scrittura è corrispondente");
            // Ci sono due dettagli scrittura uguali, che differiscono solo per l'importo. 
            var entryDet = tEntrydetail._Filter(q.eq("description",
                                                 "Fattura ACAIX_AUA n.1 / 2021")
                                             & q.eq("idreg", 19713));
            
            decimal sumDet = (decimal)entryDet.GetSum<decimal>("amount");
            Assert.AreEqual(732m, sumDet, $"La somma dei dettagli scrittura collegati al dettaglio fattura è pari a {732m}");

            //PRIMO DETTAGLIO SCRITTURA

            var rDet2 = tEntrydetail._Filter(q.eq("description",
                                                 "Fattura ACAIX_AUA n.1 / 2021")
                                             & q.eq("idreg", 19713)).FirstOrDefault();

            Assert.IsNotNull(rDet2, "Trovato dettaglio 2 con conto e descrizione corrispondenti");
            Assert.AreEqual(rDet2["idupb"], "0001000300010022", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet2["idacc"], "21000300040002000400020001", "Il conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet2["idaccmotive"], "000100020001", "La causale del dettaglio della scrittura è corrispondente");
            //Assert.AreEqual(rDet2["amount"], 600m, "L'importo del dettaglio scrittura è corrispondente");

            //SECONDO DETTAGLIO SCRITTURA
            var rDet3 = tEntrydetail._Filter(q.eq("description",
                                                 "Fattura ACAIX_AUA n.1 / 2021")
                                             & q.eq("idreg", 19713)).FirstOrDefault();
            Assert.IsNotNull(rDet3, "Trovato dettaglio 3 con conto e descrizione corrispondenti");
            Assert.AreEqual(rDet3["idupb"], "0001000300010022", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet3["idacc"], "21000300040002000400020001", "Il conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet3["idaccmotive"], "000100020001", "La causale del dettaglio della scrittura è corrispondente");
            
            //Assert.AreEqual(rDet3["amount"], 132m, "L'importo del dettaglio scrittura è corrispondente");
        }

        [TestMethod]
        public void Test_AutofatturaIstituzionaleExtraUEComm_CON_flag_RecuperoIntraExtraUE() {
            /* 
            CASO 3-Autofattura commerciale Extra-UE CON flag "Recupero Intra ed Extra-UE"
            DAFNE-Autofatt. Acq. COMMERC. EXTRA UE 2/2021
             * */
            var t = new TestHelp(new DateTime(2021, 12, 31), "sample_4", "test_4");
            q filterInv = q.eq("idinvkind", 366) & q.eq("yinv", 2021) & q.eq("ninv", 2);
            t.binaryReplaceSet(filterInv, t.getTableSet(TestHelp.mainObject.invoice));
            DataTable tInvoice = t.testConn.readTable("invoice", filterInv);
            Assert.AreEqual(1, tInvoice.Rows.Count, "La fattura esiste");

            DataRow rInv = tInvoice.Rows[0];
            t.binaryCopyEp(rInv, false);

            //CONTROLLO PER REGOLE 
            ProcedureMessageCollection regole = t.generateEP(rInv);
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rInv);

            var tEntrydetail = dsEP.Tables["entrydetail"];
            var tEntry = dsEP.Tables["entry"];
            var rEntry = tEntry.Rows[0];

            var date_doc_colleg = new DateTime(2021, 05, 21);
            var date_contab = new DateTime(2021, 05, 21);
            Assert.AreEqual(rEntry["description"], "IVA estera commerciale CON RECUPERO", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "21/000002", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");

            //DETTAGLIO SCRITTURA 
            var descr1 =
                "IVA estera commerciale CON RECUPERO";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1);
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(EntryDetail1["description"], descr1, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idacc"], "21000200010002000100010001", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idupb"], "0001000300010022", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idreg"], 19713, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idaccmotive"], "000100020001", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["amount"], -600m, "L'importo del dettaglio scrittura è corrispondente");

            //PRIMO DETTAGLIO SCRITTURA
            var rDet2 = tEntrydetail._Filter(q.eq("description",
                                                 "Fattura ACACX_DAFNE n.2 / 2021")
                                             & q.eq("idacc", "21000100020002000800020001")).FirstOrDefault();

            Assert.IsNotNull(rDet2, "Trovato dettaglio 2 con conto e descrizione corrispondenti");
            Assert.AreEqual(rDet2["idupb"], "0001000300010022", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet2["idreg"], 19713, "Anagrafica del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet2["idaccmotive"], "000100020001", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet2["amount"], -132m, "L'importo del dettaglio scrittura è corrispondente");

            //SECONDO DETTAGLIO SCRITTURA
            var rDet3 = tEntrydetail._Filter(q.eq("description",
                                                 "Fattura ACACX_DAFNE n.2 / 2021")
                                             & q.eq("idacc", "21000300040002000400020001")).FirstOrDefault();
            Assert.IsNotNull(rDet3, "Trovato dettaglio 3 con conto e descrizione corrispondenti");
            Assert.AreEqual(rDet3["idupb"], "0001000300010022", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet2["idreg"], 19713, "Anagrafica del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet3["idaccmotive"], "000100020001", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet3["amount"], 600m, "L'importo del dettaglio scrittura è corrispondente");
            //TERZO DETTAGLIO SCRITTURA
            var rDet4 = tEntrydetail._Filter(q.eq("description",
                                                 "Fattura ACACX_DAFNE n.2 / 2021")
                                             & q.eq("idacc", "21000300040002000500020001")).FirstOrDefault();
            Assert.IsNotNull(rDet4, "Trovato dettaglio 3 con conto e descrizione corrispondenti");
            Assert.AreEqual(rDet4["idupb"], "0001000300010022", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet2["idreg"], 19713, "Anagrafica del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet4["idaccmotive"], "000100020001", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet4["amount"], 132m, "L'importo del dettaglio scrittura è corrispondente");
        }
        #endregion

        [TestMethod]
        public void Test_FattAcquisto_istituzionale_NonSplitPayment() {
            /*
             * Fattura di acquisto istituzionale non split payment
             * con protocollo in entrate SDIA000000018684 e scrittura 10773/2020
             */

            var t = new TestHelp(new DateTime(2020, 12, 31), "sample_2", "test_2");
            q filterInv = q.eq("yinv", 2020) & q.eq("ninv", 275) & q.eq("arrivalprotocolnum", "SDIA000000018684");
            t.binaryReplaceSet(filterInv, t.getTableSet(TestHelp.mainObject.invoice));
            DataTable tInvoice = t.testConn.readTable("invoice", filterInv);
            Assert.AreEqual(1, tInvoice.Rows.Count, "La fattura esiste");

            DataRow rInv = tInvoice.Rows[0];
            t.binaryCopyEp(rInv, false);

            //CONTROLLO PER REGOLE
            ProcedureMessageCollection regole = t.generateEP(rInv);
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rInv);

            var tEntrydetail = dsEP.Tables["entrydetail"];
            var tEntry = dsEP.Tables["entry"];
            var rEntry = tEntry.Rows[0];

            var date_doc_colleg = new DateTime(2020, 11, 16);
            var date_contab = new DateTime(2020, 11, 17);
            Assert.AreEqual(rEntry["description"], "Incarico professionale prog. PSR INNOSHEEP resp. prof. Ronchi CIG: ZD42D8C4D9 - CUP: F84I17000190009", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "938", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");

            //DETTAGLIO SCRITTURA
            var descr1 = "Incarico professionale prog. PSR INNOSHEEP resp. prof. Ronchi CIG: ZD42D8C4D9 - CUP: F84I17000190009";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1);
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(EntryDetail1["description"], descr1, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idacc"], "20000200010004000400030001", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idupb"], "0001000100221134", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idreg"], 40054, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idaccmotive"], "000200020003", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["amount"], -4300m, "L'importo del dettaglio scrittura è corrispondente");

            //SECONDO DETTAGLIO SCRITTURA
            var rDet2 = tEntrydetail._Filter(q.eq("description", "Fattura FEAII_DAFNE n.275 / 2020")
                                                & q.eq("idacc", "20000300040002000100030001")
                                                & q.eq("amount", 3524.59m)).FirstOrDefault();

            Assert.IsNotNull(rDet2, "Trovato dettaglio 2 con conto e descrizione corrispondenti");
            Assert.AreEqual(rDet2["idupb"], "0001000100221134", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet2["idreg"], 40054, "Anagrafica del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet2["idaccmotive"], "000200020003", "La causale del dettaglio della scrittura è corrispondente");

            //TERZO DETTAGLIO SCRITTURA
            var rDet3 = tEntrydetail._Filter(q.eq("description", "Fattura FEAII_DAFNE n.275 / 2020")
                                                & q.eq("idacc", "20000300040002000100030001")
                                                & q.eq("amount", 775.41m)).FirstOrDefault();

            Assert.IsNotNull(rDet3, "Trovato dettaglio 3 con conto, descrizione e importo corrispondente");
            Assert.AreEqual(rDet3["idupb"], "0001000100221134", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet3["idreg"], 40054, "Anagrafica del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet3["idaccmotive"], "000200020003", "La causale del dettaglio della scrittura è corrispondente");
		}

        [TestMethod]
        public void Test_FattAcquisto_istituzionale_SplitPayment() {
            /*
             * Fattura di acquisto istituzionale split payment
             * con protocollo in entrata SDIA000000018622 e scrittura 12002/2020
             */

            var t = new TestHelp(new DateTime(2020, 12, 31), "sample_2", "test_2");
            q filterInv = q.eq("yinv", 2020) & q.eq("ninv", 414) & q.eq("arrivalprotocolnum", "SDIA000000018622");
            t.binaryReplaceSet(filterInv, t.getTableSet(TestHelp.mainObject.invoice));
            DataTable tInvoice = t.testConn.readTable("invoice", filterInv);
            Assert.AreEqual(1, tInvoice.Rows.Count, "La fattura esiste");

            DataRow rInv = tInvoice.Rows[0];
            t.binaryCopyEp(rInv, false);

            //CONTROLLO PER REGOLE
            ProcedureMessageCollection regole = t.generateEP(rInv);
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rInv);

            var tEntrydetail = dsEP.Tables["entrydetail"];
            var tEntry = dsEP.Tables["entry"];
            var rEntry = tEntry.Rows[0];

            var date_doc_colleg = new DateTime(2020, 11, 11);
            var date_contab = new DateTime(2020, 12, 10);
            Assert.AreEqual(rEntry["description"], "ISTITUTO DI VIGILANZA PRIVATA DELLA PROVINCIA DI VITERBO s.r.l. n.cig. 7910747AEE periodo luglio/agosto 2020 fatt. n. 3/0000384 del 11/11/2020", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "3/0000384", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");

            //DETTAGLIO SCRITTURA
            var descr1 = "ISTITUTO DI VIGILANZA PRIVATA DELLA PROVINCIA DI VITERBO s.r.l. n.cig. 7910747AEE periodo luglio/agosto 2020 fatt. n. 3/0000384 del 11/11/2020";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1);
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(EntryDetail1["description"], descr1, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idacc"], "20000200010004000800020001", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idupb"], "0001000300030008", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idreg"], 2336, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idaccmotive"], "000200030002", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["amount"], -91762.82m, "L'importo del dettaglio scrittura è corrispondente");

            //SECONDO DETTAGLIO SCRITTURA
            var rDet2 = tEntrydetail._Filter(q.eq("description", "Fattura FEAII_STIS n.414 / 2020")
                                                & q.eq("idacc", "20000300040002000100010001")
                                                & q.eq("amount", 16547.39m)).FirstOrDefault();

            Assert.IsNotNull(rDet2, "Trovato dettaglio 2 con conto, descrizione e importo corrispondenti");
            Assert.AreEqual(rDet2["idupb"], "0001000300030008", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet2["idreg"], 2336, "Anagrafica del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet2["idaccmotive"], "000200030002", "La causale del dettaglio della scrittura è corrispondente");

            //TERZO DETTAGLIO SCRITTURA
            var rDet3 = tEntrydetail._Filter(q.eq("description", "Fattura FEAII_STIS n.414 / 2020")
                                                & q.eq("idacc", "20000300040002000100010001")
                                                & q.eq("amount", 75215.43m)).FirstOrDefault();

            Assert.IsNotNull(rDet3, "Trovato dettaglio 3 con conto, descrizione e importo corrispondenti");
            Assert.AreEqual(rDet3["idupb"], "0001000300030008", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet3["idreg"], 2336, "Anagrafica del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet3["idaccmotive"], "000200030002", "La causale del dettaglio della scrittura è corrispondente");
		}

        [TestMethod]
        public void Test_FattAcquisto_commerciale_SplitPayment() {
            /*
             * Fattura di acquisto commerciale split payment
             * con protocollo in entrata SDIA000000018766 e scrittura 12673/2020
             */

            var t = new TestHelp(new DateTime(2020, 12, 31), "sample_2", "test_2");
            q filterInv = q.eq("yinv", 2020) & q.eq("ninv", 100) & q.eq("arrivalprotocolnum", "SDIA000000018766");
            t.binaryReplaceSet(filterInv, t.getTableSet(TestHelp.mainObject.invoice));
            DataTable tInvoice = t.testConn.readTable("invoice", filterInv);
            Assert.AreEqual(1, tInvoice.Rows.Count, "La fattura esiste");

            DataRow rInv = tInvoice.Rows[0];
            t.binaryCopyEp(rInv, false);

            //CONTROLLO PER REGOLE
            ProcedureMessageCollection regole = t.generateEP(rInv);
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rInv);

            var tEntrydetail = dsEP.Tables["entrydetail"];
            var tEntry = dsEP.Tables["entry"];
            var rEntry = tEntry.Rows[0];

            var date_doc_colleg = new DateTime(2020, 11, 23);
            var date_contab = new DateTime(2020, 12, 21);
            Assert.AreEqual(rEntry["description"], "CENTRO UFFICIO SRL-B.O. 80 FATT.FED 000411 DEL 23/11/2020 MATERIALE DI CANCELLERIA", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "FED 000411", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");

            //DETTAGLIO SCRITTURA
            // Ci sono più dettagli scrittura uguali, che differiscono solo per l'importo. 
            var entryDet = tEntrydetail._Filter(q.eq("description", "Fattura FEACI_DIBAF n.100 / 2020")
                                             & q.eq("idacc", "20000100020002000800020001"));
            
            decimal sumDet = (decimal)entryDet.GetSum<decimal>("amount");
            Assert.AreEqual(-24.01m, sumDet, $"La somma dei dettagli scrittura collegati al dettaglio fattura è pari a {-24.01m}");

            var rDet1 = entryDet[0];
            Assert.AreEqual(rDet1["idupb"], "0001000100250501", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet1["idreg"], 2426, "Anagrafica del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet1["idaccmotive"], "000100020008", "La causale del dettaglio della scrittura è corrispondente");

            //SECONDO DETTAGLIO SCRITTURA
            var entryDet2 = tEntrydetail._Filter(q.eq("idacc", "20000200010002000100060001"));

            decimal sumDet2 = (decimal)entryDet2.GetSum<decimal>("amount");
            Assert.AreEqual(-110.51m, sumDet2, $"La somma dei dettagli scrittura collegati al dettaglio fattura è pari a {-110.51m}");

            var rDet2 = entryDet2[0];
            Assert.AreEqual(rDet2["idupb"], "0001000100250501", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet2["idreg"], 2426, "Anagrafica del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet2["idaccmotive"], "000100020008", "La causale del dettaglio della scrittura è corrispondente");

            //TERZO DETTAGLIO SCRITTURA
            var entryDet3 = tEntrydetail._Filter(q.eq("idacc", "20000300040002000100010001"));

            decimal sumDet3 = (decimal)entryDet3.GetSum<decimal>("amount");
            Assert.AreEqual(110.26m, sumDet3, $"La somma dei dettagli scrittura collegati al dettaglio fattura è pari a {110.26m}");

            var rDet3 = entryDet3[0];
            Assert.AreEqual(rDet3["idupb"], "0001000100250501", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet3["idreg"], 2426, "Anagrafica del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet3["idaccmotive"], "000100020008", "La causale del dettaglio della scrittura è corrispondente");

            //QUARTO DETTAGLIO SCRITTURA
            var entryDet4 = tEntrydetail._Filter(q.eq("idacc", "20000300040002000500020001"));

            decimal sumDet4 = (decimal)entryDet4.GetSum<decimal>("amount");
            Assert.AreEqual(24.26m, sumDet4, $"La somma dei dettagli scrittura collegati al dettaglio fattura è pari a {24.26m}");

            var rDet4 = entryDet4[0];
            Assert.AreEqual(rDet4["idupb"], "0001000100250501", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet4["idreg"], 2426, "Anagrafica del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet4["idaccmotive"], "000100020008", "La causale del dettaglio della scrittura è corrispondente");
		}

        [TestMethod]
        public void Test_FattAcquisto_istituzionale_IntraExtraUE() {
            /*
             * Fattura di acquisto istituzionale intra/extra UE
             * con protocollo in entrata 672 e scrittura 12639/2020
             */

            var t = new TestHelp(new DateTime(2020, 12, 31), "sample_2", "test_2");
            q filterInv = q.eq("yinv", 2020) & q.eq("ninv", 22) & q.eq("arrivalprotocolnum", "672");
            t.binaryReplaceSet(filterInv, t.getTableSet(TestHelp.mainObject.invoice));
            DataTable tInvoice = t.testConn.readTable("invoice", filterInv);
            Assert.AreEqual(1, tInvoice.Rows.Count, "La fattura esiste");

            DataRow rInv = tInvoice.Rows[0];
            t.binaryCopyEp(rInv, false);

            //CONTROLLO PER REGOLE
            ProcedureMessageCollection regole = t.generateEP(rInv);
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rInv);

            var tEntrydetail = dsEP.Tables["entrydetail"];
            var tEntry = dsEP.Tables["entry"];
            var rEntry = tEntry.Rows[0];

            var date_doc_colleg = new DateTime(2020, 12, 21);
            var date_contab = new DateTime(2020, 12, 21);
            Assert.AreEqual(rEntry["description"], "PAGAMENTO INVOICE N. 2676217631 B.O. N. 289", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "2676217631", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");

            //DETTAGLIO SCRITTURA
            var descr1 = "PUBBLICAZIONE SU RIVISTA OPEN ACCESS";
            q filterEDetail1 = q.eq("description", descr1);
            var EntryDetail1Rows = tEntrydetail._Filter(filterEDetail1);
            var EntryDetail1 = EntryDetail1Rows[0];
            Assert.AreEqual(EntryDetail1["description"], descr1, "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idacc"], "20000200010004001400030001", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idupb"], "0001000100230735", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idreg"], 25446, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["idaccmotive"], "000200060005", "La causale del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(EntryDetail1["amount"], -1915.40m, "L'importo del dettaglio scrittura è corrispondente");

            //SECONDO DETTAGLIO SCRITTURA
            var rDet2 = tEntrydetail._Filter(q.eq("description", "Fattura FCAIU_DEB n.22 / 2020")
                                                & q.eq("idacc", "20000300040002000100010001")
                                                & q.eq("amount", 1570.00m)).FirstOrDefault();

            Assert.IsNotNull(rDet2, "Trovato dettaglio 2 con conto, descrizione e importo corrispondenti");
            Assert.AreEqual(rDet2["idupb"], "0001000100230735", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet2["idreg"], 25446, "Anagrafica del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet2["idaccmotive"], "000200060005", "La causale del dettaglio della scrittura è corrispondente");

            //TERZO DETTAGLIO SCRITTURA
            var rDet3 = tEntrydetail._Filter(q.eq("description", "Fattura FCAIU_DEB n.22 / 2020")
                                                & q.eq("idacc", "20000300040002000500070001")
                                                & q.eq("amount", 345.40m)).FirstOrDefault();

            Assert.IsNotNull(rDet3, "Trovato dettaglio 3 con conto, descrizione e importo corrispondenti");
            Assert.AreEqual(rDet3["idupb"], "0001000100230735", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet3["idreg"], 10791, "Anagrafica del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet3["idaccmotive"], "000200060005", "La causale del dettaglio della scrittura è corrispondente");
		}

        [TestMethod]
        public void Test_FattAcquisto_commerciale_IntraExtraUE() {
            /*
             * Fattura acquisto commerciale intra/extra UE
             * con protocollo in entrata 497 e scrittura 9614/2020
             */

            var t = new TestHelp(new DateTime(2020, 12, 31), "sample_2", "test_2");
            q filterInv = q.eq("yinv", 2020) & q.eq("ninv", 3) & q.eq("arrivalprotocolnum", "497");
            t.binaryReplaceSet(filterInv, t.getTableSet(TestHelp.mainObject.invoice));
            DataTable tInvoice = t.testConn.readTable("invoice", filterInv);
            Assert.AreEqual(1, tInvoice.Rows.Count, "La fattura esiste");

            DataRow rInv = tInvoice.Rows[0];
            t.binaryCopyEp(rInv, false);

            //CONTROLLO PER REGOLE
            ProcedureMessageCollection regole = t.generateEP(rInv);
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rInv);

            var tEntrydetail = dsEP.Tables["entrydetail"];
            var tEntry = dsEP.Tables["entry"];
            var rEntry = tEntry.Rows[0];

            var date_doc_colleg = new DateTime(2020, 10, 22);
            var date_contab = new DateTime(2020, 10, 22);
            Assert.AreEqual(rEntry["description"], "MATERIALE DI LABORATORIO B.O. N. 19/2017", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "91639164", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");

            //DETTAGLIO SCRITTURA
            var entryDet = tEntrydetail._Filter(q.gt("amount", 0));

            decimal sumDet = (decimal)entryDet.GetSum<decimal>("amount");
            Assert.AreEqual(226.84m, sumDet, $"La somma dei dettagli scrittura collegati al dettaglio fattura è pari a {226.84m}");

            var rDet1 = entryDet[0];
            Assert.AreEqual(rDet1["idupb"], "0001000100230329", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet1["idreg"], 13307, "Anagrafica del dettaglio della scrittura è corrispondente");

            //SECONDO DETTAGLIO SCRITTURA
            var entryDet2 = tEntrydetail._Filter(q.gt(0, "amount"));

            decimal sumDet2 = (decimal)entryDet.GetSum<decimal>("amount");
            Assert.AreEqual(-226.84m, sumDet2, $"La somma dei dettagli scrittura collegati al dettaglio fattura è pari a {-226.84m}");

            var rDet2 = entryDet2[0];
            Assert.AreEqual(rDet2["idupb"], "0001000100230329", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet2["idreg"], 13307, "Anagrafica del dettaglio della scrittura è corrispondente");
		}

        [TestMethod]
        public void Test_BollaDoganale_istituzionale() {
            /*
             * Bolla doganale istituzionale 
             * ninv = 3, yinv = 2020, idinvkind = 627 e scrittura 5938/2020
             */

            var t = new TestHelp(new DateTime(2020, 12, 31), "sample_2", "test_2");
            q filterInv = q.eq("yinv", 2020) & q.eq("ninv", 3) & q.eq("idinvkind", 627);
            t.binaryReplaceSet(filterInv, t.getTableSet(TestHelp.mainObject.invoice));
            DataTable tInvoice = t.testConn.readTable("invoice", filterInv);
            Assert.AreEqual(1, tInvoice.Rows.Count, "La fattura esiste");

            DataRow rInv = tInvoice.Rows[0];
            t.binaryCopyEp(rInv, false);

            //CONTROLLO PER REGOLE
            ProcedureMessageCollection regole = t.generateEP(rInv);
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rInv);

            var tEntrydetail = dsEP.Tables["entrydetail"];
            var tEntry = dsEP.Tables["entry"];
            var rEntry = tEntry.Rows[0];

            var date_doc_colleg = new DateTime(2020, 7, 12);
            var date_contab = new DateTime(2020, 7, 15);
            Assert.AreEqual(rEntry["description"], "STRUMENTI, APPARECCHI E MACCHINE DI MISURA O DI CONTROLLO", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "20AA39474 - 326830", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");

            //DETTAGLIO SCRITTURA
            var entryDet = tEntrydetail._Filter(q.eq("idacc", "20000200010002000200010002")
                                                & q.eq("description", "DAZIO DOGANALE"));

            decimal sumDet = (decimal)entryDet.GetSum<decimal>("amount");
            Assert.AreEqual(0m, sumDet, $"La somma dei dettagli scrittura collegati al dettaglio fattura è pari a {0m}");

            var rDet1 = entryDet[0];
            Assert.AreEqual(rDet1["idupb"], "0001000100510070", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet1["idaccmotive"], "000100020016", "La causale del dettaglio della scrittura è corrispondente");

            //SECONDO DETTAGLIO SCRITTURA
            var entryDet2 = tEntrydetail._Filter(q.eq("description", "DAZIO DOGANALE")
                                                & q.eq("idacc", "20000200010010000100010001"));

            var rDet2 = entryDet2[0];
            Assert.AreEqual(rDet2["idupb"], "0001000100510070", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet2["idreg"], 24599, "Anagrafica del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet2["amount"], -1646.29m, "L'importo del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet2["idaccmotive"], "000100020016", "La causale del dettaglio della scrittura è corrispondente");

            //TERZO DETTAGLIO SCRITTURA
            var entryDet3 = tEntrydetail._Filter(q.eq("description", "Fattura BDOGI_ITEST n.3 / 2020")
                                                & q.eq("idacc", "20000300040002000700040001"));

            decimal sumDet3 = (decimal)entryDet3.GetSum<decimal>("amount");
            Assert.AreEqual(1646.29m, sumDet3, $"La somma dei dettagli scrittura collegati al dettaglio fattura è pari a {1646.29m}");

            var rDet3 = entryDet3[0];
            Assert.AreEqual(rDet3["idupb"], "0001000100510070", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet3["idreg"], 24599, "Anagrafica del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet3["idaccmotive"], "000100020016", "La causale del dettaglio della scrittura è corrispondente");
		}

        [TestMethod]
        public void Test_AutoFattura_Commerciale() {
            /*
             * Autofattura commerciale
             * con protocollo in entrata 1452 e scrittura 12317/2020
             */

            var t = new TestHelp(new DateTime(2020, 12, 31), "sample_2", "test_2");
            q filterInv = q.eq("yinv", 2020) & q.eq("ninv", 6) & q.eq("arrivalprotocolnum", "1452");
            t.binaryReplaceSet(filterInv, t.getTableSet(TestHelp.mainObject.invoice));
            DataTable tInvoice = t.testConn.readTable("invoice", filterInv);
            Assert.AreEqual(1, tInvoice.Rows.Count, "La fattura esiste");

            DataRow rInv = tInvoice.Rows[0];
            t.binaryCopyEp(rInv, false);

            //CONTROLLO PER REGOLE
            ProcedureMessageCollection regole = t.generateEP(rInv);
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rInv);

            var tEntrydetail = dsEP.Tables["entrydetail"];
            var tEntry = dsEP.Tables["entry"];
            var rEntry = tEntry.Rows[0];

            var date_doc_colleg = new DateTime(2020, 12, 15);
            var date_contab = new DateTime(2020, 12, 15);
            Assert.AreEqual(rEntry["description"], "MDPI AG-B.O. 91 DEL 26/11/2020 INVOICE 1017407 DEL 30/11/2020 PUBBLICAZIONE \"FUNCTIONAL INGREDIENTS FROM AGRI-FOOD..\"", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "20/000006", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");

            //DETTAGLIO SCRITTURA
            var entryDet = tEntrydetail._Filter(q.eq("description", "Spese di pubblicazione articolo scientifico")
                                                & q.eq("idacc", "20000200010004001400030001"));
            
            var rDet1 = entryDet[0];
            Assert.AreEqual(rDet1["idupb"], "0001000100250708", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet1["idreg"], 24005, "Anagrafica del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet1["amount"], -1485.70m, "L'importo del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet1["idaccmotive"], "000200060005", "La causale del dettaglio della scrittura è corrispondente");

            //SECONDO DETTAGLIO SCRITTURA
            var entryDet2 = tEntrydetail._Filter(q.eq("description", "Fattura ACACX_DIBAF n.6 / 2020")
                                                & q.eq("idacc", "20000100020002000800020001"));

            var rDet2 = entryDet2[0];
            Assert.AreEqual(rDet2["idupb"], "0001000100250708", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet2["idreg"], 24005, "Anagrafica del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet2["amount"], -322.88m, "L'importo del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet2["idaccmotive"], "000200060005", "La causale del dettaglio della scrittura è corrispondente");

            //TERZO DETTAGLIO SCRITTURA
            var entryDet3 = tEntrydetail._Filter(q.eq("description", "Fattura ACACX_DIBAF n.6 / 2020")
                                                & q.eq("idacc", "20000300040002000100020001"));

            var rDet3 = entryDet3[0];
            Assert.AreEqual(rDet3["idupb"], "0001000100250708", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet3["idreg"], 24005, "Anagrafica del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet3["amount"], 1482.44m, "L'importo del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet3["idaccmotive"], "000200060005", "La causale del dettaglio della scrittura è corrispondente");

            //QUARTO DETTAGLIO SCRITTURA
            var entryDet4 = tEntrydetail._Filter(q.eq("description", "Fattura ACACX_DIBAF n.6 / 2020")
                                                & q.eq("idacc", "20000300040002000500020001"));

            decimal sumDet = (decimal)entryDet4.GetSum<decimal>("amount");
            Assert.AreEqual(326.14m, sumDet, $"La somma dei dettagli scrittura collegati al dettaglio fattura è pari a {326.14m}");

            var rDet4 = entryDet4[0];
            Assert.AreEqual(rDet4["idupb"], "0001000100250708", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet4["idreg"], 24005, "Anagrafica del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet4["idaccmotive"], "000200060005", "La causale del dettaglio della scrittura è corrispondente");
		}

        [TestMethod]
        public void Test_Autofattura_Istituzionale() {
            /*
             * Autofattura istituzionale
             * con protocollo in entrata 1315 e scrittura 12497/2020
             */

            var t = new TestHelp(new DateTime(2020, 12, 31), "sample_2", "test_2");
            q filterInv = q.eq("yinv", 2020) & q.eq("ninv", 22) & q.eq("arrivalprotocolnum", "1315");
            t.binaryReplaceSet(filterInv, t.getTableSet(TestHelp.mainObject.invoice));
            DataTable tInvoice = t.testConn.readTable("invoice", filterInv);
            Assert.AreEqual(1, tInvoice.Rows.Count, "La fattura esiste");

            DataRow rInv = tInvoice.Rows[0];
            t.binaryCopyEp(rInv, false);

            //CONTROLLO PER REGOLE
            ProcedureMessageCollection regole = t.generateEP(rInv);
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rInv);

            var tEntrydetail = dsEP.Tables["entrydetail"];
            var tEntry = dsEP.Tables["entry"];
            var rEntry = tEntry.Rows[0];

            var date_doc_colleg = new DateTime(2020, 12, 17);
            var date_contab = new DateTime(2020, 12, 17);
            Assert.AreEqual(rEntry["description"].ToString().Replace("\r\n", ""), "Manuscript ID (remotesensing-966495). Articolo MDPI Remote Sensing:Tolomio e Casa \"Dynamic crop models and remote sensing irrigationdecision...\"", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "20/000022", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");

            //DETTAGLIO SCRITTURA
            var entryDet = tEntrydetail._Filter(q.eq("description", "Manuscript ID (remotesensing-966495). Articolo MDPI Remote Sensing:\r\nTolomio e Casa \"Dynamic crop models and remote sensing irrigation\r\ndecision...\"")
                                                & q.eq("idacc", "20000200010004001400030001"));

            var rDet1 = entryDet[0];
            Assert.AreEqual(rDet1["idupb"], "0001000100221050", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet1["idreg"], 24005, "Anagrafica del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet1["amount"], -1921.61m, "L'importo del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet1["idaccmotive"], "000200060005", "La causale del dettaglio della scrittura è corrispondente");

            //SECONDO DETTAGLIO SCRITTURA
            var entryDet2 = tEntrydetail._Filter(q.eq("description", "Fattura ACAIX_DAFNE n.22 / 2020")
                                                & q.eq("idacc", "20000300040002000100020001"));

            var rDet2 = entryDet2[0];
            Assert.AreEqual(rDet2["idupb"], "0001000100221050", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet2["idreg"], 24005, "Anagrafica del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet2["amount"], 1575.09m, "L'importo del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet2["idaccmotive"], "000200060005", "La causale del dettaglio della scrittura è corrispondente");

            //TERZO DETTAGLIO SCRITTURA
            var entryDet3 = tEntrydetail._Filter(q.eq("description", "Fattura ACAIX_DAFNE n.22 / 2020")
                                                & q.eq("idacc", "20000300040002000500070001"));

            var rDet3 = entryDet3[0];
            Assert.AreEqual(rDet3["idupb"], "0001000100221050", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet3["idreg"], 10791, "Anagrafica del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet3["amount"], 346.52m, "L'importo del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet3["idaccmotive"], "000200060005", "La causale del dettaglio della scrittura è corrispondente");
		}

        [TestMethod]
        public void Test_NotaDiCredito_FattAcquisto_istituzionale_SplitPayment() {
            /*
             * Nota di credito su fattura acquisto istituzionale split payment
             * con protocollo in entrata SDIA000000018661 e scrittura 11361/2020
             */

            var t = new TestHelp(new DateTime(2020, 12, 31), "sample_2", "test_2");
            q filterInv = q.eq("yinv", 2020) & q.eq("ninv", 17) & q.eq("arrivalprotocolnum", "SDIA000000018661");
            t.binaryReplaceSet(filterInv, t.getTableSet(TestHelp.mainObject.invoice));
            DataTable tInvoice = t.testConn.readTable("invoice", filterInv);
            Assert.AreEqual(1, tInvoice.Rows.Count, "La fattura esiste");

            DataRow rInv = tInvoice.Rows[0];
            t.binaryCopyEp(rInv, false);

            //CONTROLLO PER REGOLE
            ProcedureMessageCollection regole = t.generateEP(rInv);
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rInv);

            var tEntrydetail = dsEP.Tables["entrydetail"];
            var tEntry = dsEP.Tables["entry"];
            var rEntry = tEntry.Rows[0];

            var date_doc_colleg = new DateTime(2020, 10, 21);
            var date_contab = new DateTime(2020, 11, 27);
            Assert.AreEqual(rEntry["description"], "NOTA DI CREDITO DEL 21 OTTOBRE 2020: STORNO FATTURA N. 309 DEL 21 OTTOBRE 2020.", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(rEntry["doc"], "1", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");

            //DETTAGLIO SCRITTURA
            var entryDet = tEntrydetail._Filter(q.eq("description", "SPESE ANTICIPATE PER CONTO, ESCLUSE DA IVA AI SENSI DELL'ART. 15, COM.3")
                                                & q.eq("idacc", "20000200010004000400030001"));

            var rDet1 = entryDet[0];
            Assert.AreEqual(rDet1["idupb"], "000100010025", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet1["idreg"], 24024, "Anagrafica del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet1["amount"], 254.00m, "L'importo del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet1["idaccmotive"], "000200020003", "La causale del dettaglio della scrittura è corrispondente");

            //SECONDO DETTAGLIO SCRITTURA
            var entryDet2 = tEntrydetail._Filter(q.eq("description", "COMPENSI E ALTRE SPESE SOGGETTE AD IVA")
                                                & q.eq("idacc", "20000200010004000400030001"));

            var rDet2 = entryDet2[0];
            Assert.AreEqual(rDet2["idupb"], "000100010025", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet2["idreg"], 24024, "Anagrafica del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet2["amount"], 746.00m, "L'importo del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet2["idaccmotive"], "000200020003", "La causale del dettaglio della scrittura è corrispondente");

            //TERZO DETTAGLIO SCRITTURA
            var entryDet3 = tEntrydetail._Filter(q.eq("description", "Fattura NEAII_DIBAF n.17 / 2020")
                                                & q.eq("idacc", "20000300040002000100030001"));

            decimal sumDet = (decimal)entryDet3.GetSum<decimal>("amount");
            Assert.AreEqual(-1000m, sumDet, $"La somma dei dettagli scrittura collegati al dettaglio fattura è pari a {-1000m}");

            var rDet3 = entryDet3[0];
            Assert.AreEqual(rDet3["idupb"], "000100010025", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet3["idreg"], 24024, "Anagrafica del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet3["idaccmotive"], "000200020003", "La causale del dettaglio della scrittura è corrispondente");
		}

        [TestMethod]
        public void Test_NotaDiCredito_FattAcquisto_commerciale_SplitPayment() {
            /*
             * Nota di credito su fattura acquisto commerciale split payment
             * con protocollo in entrata SDIA000000017748 e scrittura 7535/2020
             */

            var t = new TestHelp(new DateTime(2020, 12, 31), "sample_2", "test_2");
            q filterInv = q.eq("yinv", 2020) & q.eq("ninv", 2) & q.eq("arrivalprotocolnum", "SDIA000000017748");
            t.binaryReplaceSet(filterInv, t.getTableSet(TestHelp.mainObject.invoice));
            DataTable tInvoice = t.testConn.readTable("invoice", filterInv);
            Assert.AreEqual(1, tInvoice.Rows.Count, "La fattura esiste");

            DataRow rInv = tInvoice.Rows[0];
            t.binaryCopyEp(rInv, false);

            //CONTROLLO PER REGOLE
            ProcedureMessageCollection regole = t.generateEP(rInv);
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rInv);

            var tEntrydetail = dsEP.Tables["entrydetail"];
            var tEntry = dsEP.Tables["entry"];
            var rEntry = tEntry.Rows[0];

            var date_doc_colleg = new DateTime(2020, 7, 30);
            var date_contab = new DateTime(2020, 9, 7);
            Assert.AreEqual(rEntry["description"], "MERCK LIFE SCIENCE SRL nota di credito N°8230112468 parziale su fattura 8230108168 per prezzo errato", "La descrizione della scrittura è corrrispondente");
            Assert.AreEqual(rEntry["doc"], "8230112468", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(rEntry["adate"], date_contab, "La data contabile della scrittura è corrispondente");

            //DETTAGLIO SCRITTURA
            var entryDet = tEntrydetail._Filter(q.eq("description", "nEsano p.a. EMPARTA ACS 2,5 L")
                                                & q.eq("idacc", "20000200010002000300020001"));

            var rDet1 = entryDet[0];
            Assert.AreEqual(rDet1["idupb"], "000100010025", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet1["idreg"], 37814, "Anagrafica del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet1["amount"], 58.73m, "L'importo del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet1["idaccmotive"], "000100020011", "La causale del dettaglio della scrittura è corrispondente");

            //SECONDO DETTAGLIO SCRITTURA
            var entryDet2 = tEntrydetail._Filter(q.eq("description", "Fattura NEACI_DIBAF n.2 / 2020")
                                                & q.eq("idacc", "20000100020002000800020001"));

            var rDet2 = entryDet2[0];
            Assert.AreEqual(rDet2["idupb"], "000100010025", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet2["idreg"], 37814, "Anagrafica del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet2["amount"], 12.76m, "L'importo del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet2["idaccmotive"], "000100020011", "La causale del dettaglio della scrittura è corrispondente");

            //TERZO DETTAGLIO SCRITTURA
            var entryDet3 = tEntrydetail._Filter(q.eq("description", "Fattura NEACI_DIBAF n.2 / 2020")
                                                & q.eq("idacc", "20000300040002000100010001"));

            var rDet3 = entryDet3[0];
            Assert.AreEqual(rDet3["idupb"], "000100010025", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet3["idreg"], 37814, "Anagrafica del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet3["amount"], -58.60m, "L'importo del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet3["idaccmotive"], "000100020011", "La causale del dettaglio della scrittura è corrispondente");

            //QUARTO DETTAGLIO SCRITTURA
            var entryDet4 = tEntrydetail._Filter(q.eq ("description", "Fattura NEACI_DIBAF n.2 / 2020")
                                                & q.eq("idacc", "20000300040002000500020001"));

            decimal sumDet = (decimal)entryDet4.GetSum<decimal>("amount");
            Assert.AreEqual(-12.89m, sumDet, $"La somma dei dettagli scrittura collegati al dettaglio fattura è pari a {-12.89m}");

            var rDet4 = entryDet4[0];
            Assert.AreEqual(rDet4["idupb"], "000100010025", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet4["idreg"], 37814, "Anagrafica del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet4["idaccmotive"], "000100020011", "La causale del dettaglio delle scritture è corrispondente");
		}

        public void Test_Regola_Modifica_denominazioneAnagr_collegataMovSpesa()
        {
            //ANAGRAFICA COLLEGATA A UN MOVIMENTO DI SPESA 
            var t = new TestHelp(new DateTime(2018, 12, 31));
            q filterReg = q.eq("idreg", 155414);
            t.binaryReplaceSet(filterReg, t.getTableSet(TestHelp.mainObject.registry));

            //MODIFICO IL DATASET DELL'ANAGRAFICA
            var mRegistry = TestHelp.editDataRow(t.testConn,filterReg, "registry", "anagrafica");
            var ds = mRegistry.ds;
            var tRegistry = ds.Tables["registry"];
            var rreg = tRegistry.Rows[0];
            var originalValue = rreg["title"].ToString();
            rreg["title"] = originalValue + " modified";
            
            //SALVO IL DATASET MODIFICATO
            var res = t.saveFormData(mRegistry);

            Assert.AreNotEqual(0, res.Count, "Sono scattate delle regole sul salvataggio della modifica");
            EasyProcedureMessage regola = (EasyProcedureMessage)res[0];
            Assert.IsInstanceOfType(regola, typeof(EasyProcedureMessage));        
            Assert.AreEqual("MOVIM011", regola.AuditID, "E' scattata la MOVIM011");
            var testoRegola =
                "Non può essere modificata la denominazione di CheMatech SAS modified  se ad esso è imputato un movimento di spesa/entrata inserito in un mandato di pagamento/reversale di incasso.";
            Assert.AreEqual(testoRegola, regola.LongMess, "Il testo della MOVIM011 appare come dovrebbe");
            Assert.AreEqual(false, regola.CanIgnore, "La regola che scatta è bloccante");

            mRegistry.ds.AcceptChanges();
            mRegistry.DontWarnOnInsertCancel = true;
            mRegistry.Destroy();

        }

        public static bool CheckDatiFattAcquisto(DataTable tEntrydetail, DataRow[] epexpRows, decimal sommaDet, int impBudgetNumber, int scrittDetNumber)
        {
            Assert.AreEqual(impBudgetNumber, epexpRows.Length, "C'è un impegno di budget collegato al dettaglio fattura");
            var epexpRow = epexpRows[0];
            var entryDet = tEntrydetail._Filter(q.eq("idepexp", epexpRow["idepexp"]) & q.isNotNull("idrelated"));
            Assert.AreEqual(scrittDetNumber, entryDet.Length, $"Ci sono {scrittDetNumber} dettagli scrittura collegati all'impegno di budget");
            decimal sumDet = (decimal)entryDet.GetSum<decimal>("amount");
            Assert.AreEqual(sommaDet, sumDet, $"La somma dei dettagli scrittura collegati al dettaglio fattura è pari a {sommaDet}");

            //CONTROLLO CORRISPONDENZA TRA DETTAGLI  SCRITTURA E MOVIMENTO DI BUDGET
            foreach (var det in entryDet)
            {
                if (det["idrelated"].ToString().Split('§')[0] == "inv")
                    Assert.AreEqual(epexpRow["idrelated"].ToString(), det["idrelated"].ToString());
            }
            return true;
        }

        public static bool CheckDatiFattVendita(DataTable tEntrydetail, DataRow[] epaccRows, decimal sommaDet, int impBudgetNumber, int scrittDetNumber)
        {
            Assert.AreEqual(impBudgetNumber, epaccRows.Length, "C'è un impegno di budget collegato al dettaglio fattura");
            var epaccRow = epaccRows[0];
            var entryDet = tEntrydetail._Filter(q.eq("idepacc", epaccRow["idepacc"]) & q.isNotNull("idrelated"));
            Assert.AreEqual(scrittDetNumber, entryDet.Length, $"Ci sono {scrittDetNumber} dettagli scrittura collegati all'impegno di budget");
            decimal sumDet = (decimal)entryDet.GetSum<decimal>("amount");
            Assert.AreEqual(sommaDet, sumDet, $"La somma dei dettagli scrittura collegati al dettaglio fattura è {sommaDet}");

            //CONTROLLO CORRISPONDENZA TRA DETTAGLI  SCRITTURA E MOVIMENTO DI BUDGET
            foreach (var det in entryDet)
            {
                if (det["idrelated"].ToString().Split('§')[0] == "inv")
                    Assert.AreEqual(epaccRow["idrelated"].ToString(), det["idrelated"].ToString());
            }
            return true;
        }

    }
}
