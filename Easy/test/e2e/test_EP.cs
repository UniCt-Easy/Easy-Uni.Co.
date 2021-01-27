
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
                metaeasylibrary.Easy_PostData.rulesToIgnore.Add("ECOPA047");
                t.generateEP(rMan);
                metaeasylibrary.Easy_PostData.rulesToIgnore.Clear();
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

        [TestMethod]
        public void Test_contratto_passivo_ImpVarBudget()
        {
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
            if(regole != null) 
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");

            var dsEP = t.getEpData(t.testConn, rMan);
        
            //VERIFICA VARIAZIONI 
            DataRow[] rEpexpvar = dsEP.Tables["epexpvar"]._Filter(null);
            Assert.AreEqual(0, rEpexpvar.Count(), "Non ci sono variazioni");

            //PRIMO IMPEGNO VAR. BUDGET ASSOCIATO AL CONTRATTO PASSIVO
            DataRow[] rEpexp = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("idepexp", idepex1) & q.eq("yepexp",2018));
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
        public void Test_contratto_passivo_Scritture()
        {
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
            if(regole != null) 
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");

            var dsEP = t.getEpData(t.testConn, rMan);
            var tEntrydetail = dsEP.Tables["entrydetail"];
            var tEntry = dsEP.Tables["entry"];
            DataRow[] rEpexp = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2));
            DataRow dr1_epexp = rEpexp[0];

            //VERIFICA VARIAZIONI 
            DataRow[] rEpexpvar = dsEP.Tables["epexpvar"]._Filter(null);
            Assert.AreEqual(0, rEpexpvar.Count(), "Non ci sono variazioni");

            var date_doc_colleg = new DateTime(2018, 9, 14);
            var date_contab = new DateTime(2018,9,20);
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
        public void Test_ImpVar_mandate_2018_dettagli_annullati()
        {
            var t = new TestHelp(new DateTime(2018, 12, 31));
            q filterMan = q.eq("idmankind", "VARI_GEST_nofattura") & q.eq("yman", 2018) & q.eq("nman", 108);
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
            if(regole != null) 
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");

            
            DataRow[] rEpexp = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2));
            DataRow[] rEpexpyear = dsEP.Tables["epexpyear"]._Filter(q.eq("ayear", 2018));
            var tEntrydetail = dsEP.Tables["entrydetail"];

            //VERIFICA VARIAZIONI AI MOVIMENTI DI BUDGET
            DataRow[] rEpexpvar = dsEP.Tables["epexpvar"]._Filter(null);
            Assert.AreEqual(rEpexpvar.Length, 2, "Sono  presenti 2 variazioni");
            DataRow dr1_Epexpvar = rEpexpvar[0];
            decimal totale = CfgFn.GetNoNullDecimal(dr1_Epexpvar["amount"]);
            for (int i = 2; i <= 5; i++)
            {
                totale += CfgFn.GetNoNullDecimal(dr1_Epexpvar["amount" + i.ToString()]);
            }
            Assert.AreEqual(totale, -595.00m, "L'importo totale della variazione è corrispondente");

            //PRIMO IMPEGNO VAR. BUDGET ASSOCIATO AL CONTRATTO PASSIVO
            DataRow dr1_epexp = rEpexp[0];
            DataRow dr1_epexpyear = rEpexpyear[0];
            Assert.AreEqual(dr1_epexp["description"], "Iscrizione E-MRS 2018 Spring Meeting - Chiara Vittoni", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epexpyear["amount"], 595.00m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexpyear["idacc"], "18000200010002000800100004", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexpyear["idupb"], "000100030004000100021274", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexp["idaccmotive"], "000600010002000600100004", "La causale del mov.budget è corrispondente");

            //CONTROLLO CORRISPONDENZA TRA SCRITTURA E MOVIMENTO DI BUDGET
            Assert.AreEqual(tEntrydetail.Rows[0]["idepexp"], dr1_epexp["idepexp"]);
            Assert.AreEqual(tEntrydetail.Rows[0]["idrelated"], dr1_epexp["idrelated"]);

        }

        [TestMethod]
        public void Test_Scrittu_mandate_2018_dettagli_annullati()
        {
            var t = new TestHelp(new DateTime(2018, 12, 31));
            q filterMan = q.eq("idmankind", "VARI_GEST_nofattura") & q.eq("yman", 2018) & q.eq("nman", 108);
            t.binaryReplaceSet(filterMan, t.getTableSet(TestHelp.mainObject.mandate));
            DataTable tMandate = t.testConn.readTable("mandate", filterMan);
            Assert.AreEqual(1, tMandate.Rows.Count, "Il contratto esiste");
            DataTable tMandateDetail = t.testConn.readTable("mandatedetail", filterMan & q.isNotNull("stop"));
            int nManDet = tMandateDetail.Rows.Count;
            Assert.AreNotEqual(0, nManDet, "Il contratto non ha dettagli");
            DataRow rMan = tMandate.Rows[0];
            var dsEP = t.getEpData(t.testConn, rMan);
            t.binaryCopyEp(rMan, false);

            //CONTROLLO PER REGOLE 
            ProcedureMessageCollection regole = t.generateEP(rMan);
            dsEP = t.getEpData(t.testConn, rMan);

            if(regole != null) 
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");

            var tEntrydetail = dsEP.Tables["entrydetail"];
            var tEntry = dsEP.Tables["entry"];
            DataRow[] rEpexp = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2));
            DataRow dr1_epexp = rEpexp[0];
            var date_doc_colleg = new DateTime(2018, 6, 6);
            var date_contab = new DateTime(2018, 6, 6);
            Assert.AreEqual(tEntry.Rows[0]["description"], "Iscrizione E-MRS 2018 Spring Meeting - Chiara Vittoni", "La descrizione della scrittura è corrispondente");
            Assert.AreEqual(tEntry.Rows[0]["doc"], "C.P. VARI_GEST_nofattura 18/108", "La descrizione del documento collegato alla scrittura è corrispondente");
            Assert.AreEqual(tEntry.Rows[0]["docdate"], date_doc_colleg, "La data del doc.collegato alla scrittura è corrispondente");
            Assert.AreEqual(tEntry.Rows[0]["adate"], date_contab, "La data contabile della scrittura è corrispondente");

            //PRIMO DETTAGLIO SCRITTURA
            Assert.AreEqual(tEntrydetail.Rows[0]["description"], "Contratto Passivo VARI_GEST_nofattura 18/108 dett. 1- Iscrizione E-MRS 2018 Spring Meeting - Chiara Vittoni", "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(tEntrydetail.Rows[0]["idacc"], "18000200010002000800100004", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(tEntrydetail.Rows[0]["idupb"], "000100030004000100021274", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(tEntrydetail.Rows[0]["idreg"], 130527, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(tEntrydetail.Rows[0]["idaccmotive"], "000600010002000600100004", "La causale del dettaglio della scrittura è corrispondente");

            //SECONDO DETTAGLIO SCRITTURA
            Assert.AreEqual(tEntrydetail.Rows[1]["description"], "Contratto passivo VARI_GEST_nofattura n.108 / 2018 dett. 1", "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(tEntrydetail.Rows[1]["idacc"], "18000400040001000100090001", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(tEntrydetail.Rows[1]["idupb"], "000100030004000100021274", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(tEntrydetail.Rows[1]["idreg"], 130527, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(tEntrydetail.Rows[1]["idaccmotive"], "000600010002000600100004", "La causale del dettaglio della scrittura è corrispondente");

            //CONTROLLO CORRISPONDENZA TRA SCRITTURA E MOVIMENTO DI BUDGET
            Assert.AreEqual(tEntrydetail.Rows[0]["idepexp"], dr1_epexp["idepexp"]);
            Assert.AreEqual(tEntrydetail.Rows[0]["idrelated"], dr1_epexp["idrelated"]);

            //CONTROLLO CORRISPONDENZA TRA SCRITTURA E MOVIMENTO DI BUDGET
            Assert.AreEqual(tEntrydetail.Rows[1]["idepexp"], dr1_epexp["idepexp"]);
            Assert.AreEqual(tEntrydetail.Rows[1]["idrelated"], dr1_epexp["idrelated"]);
        }

        [TestMethod]
        public void Test_ImpVar_mandate_2017_dettagli_annullati()
        {
            //VARI_GEST_nofattura 2017	210  problema chiedere all'assistenza
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
            if(regole != null) 
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rMan);
            
            //VERIFICA VARIAZIONI AI MOVIMENTI DI BUDGET
            DataRow[] rEpexpvar = dsEP.Tables["epexpvar"]._Filter(null);
            Assert.AreEqual(rEpexpvar.Length, 2*2, "Sono  presenti 4 variazioni");
            DataRow dr1_Epexpvar = rEpexpvar[0];
            decimal totale = CfgFn.GetNoNullDecimal(dr1_Epexpvar["amount"]);
            for (int i = 2; i <= 5; i++)
            {
                totale += CfgFn.GetNoNullDecimal(dr1_Epexpvar["amount" + i.ToString()]);
            }
            Assert.AreEqual(totale, -396.00m, "L'importo totale della variazione è corrispondente");

            //IMPEGNO VAR. BUDGET ASSOCIATO AL CONTRATTO PASSIVO
            DataRow[] rEpexp = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2017) & q.eq("idepexp", 358690));
            DataRow[] rEpexpyear = dsEP.Tables["epexpyear"]._Filter(q.eq("ayear", 2018) & q.eq("idepexp", 358690));
            DataRow dr1_epexp = rEpexp[0];
            DataRow dr1_epexpyear = rEpexpyear[0];
            Assert.AreEqual(dr1_epexp["description"], "Servizi di ristorazione rivolti a studenti (tramite buono d'ordine)", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epexpyear["amount"], 396.00m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexpyear["idacc"], "18000200010002000100030017", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexpyear["idupb"], "000100030002000100020851", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexp["idaccmotive"], "0002000400010011", "La causale del mov.budget è corrispondente");

            //SECONDO IMPEGNO VAR. BUDGET ASSOCIATO AL CONTRATTO PASSIVO
            DataRow[] rEpexp2 = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp", 2017) & q.eq("idepexp", 358691));
            DataRow[] rEpexpyear2 = dsEP.Tables["epexpyear"]._Filter(q.eq("ayear", 2018) & q.eq("idepexp", 358691));
            DataRow dr2_epexp = rEpexp2[0];
            DataRow dr2_epexpyear = rEpexpyear2[0];
            Assert.AreEqual(dr2_epexp["description"], "Servizi di ristorazione per relatori a seminari rivolti agli studenti (tramite buono d'ordine)", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr2_epexpyear["amount"], 158.40m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epexpyear["idacc"], "18000200010002000100030017", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epexpyear["idupb"], "000100030002000100020851", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epexp["idaccmotive"], "0002000400010011", "La causale del mov.budget è corrispondente");
        }

        [TestMethod]
        public void Test_Scrittu_mandate_2017_dettagli_annullati()
        {
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
            if(regole != null) 
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rMan);
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
        public void Test_ImpVar_estimate_2017_dettagli_annullati()
        {
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
            if(regole != null) 
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");

            //VERIFICA VARIAZIONI AI MOVIMENTI DI BUDGET
            DataRow[] rEpaccpvar = dsEP.Tables["epaccvar"]._Filter(null);
            Assert.AreEqual(rEpaccpvar.Length, 2, "Sono  presenti 2 variazioni");
            DataRow dr1_Epaccvr = rEpaccpvar[0];
            decimal totale = CfgFn.GetNoNullDecimal(dr1_Epaccvr["amount"]);
            for (int i = 2; i <= 5; i++)
            {
                totale += CfgFn.GetNoNullDecimal(dr1_Epaccvr["amount" + i.ToString()]);
            }
            Assert.AreEqual(totale, -30.00m, "L'importo totale della variazione è corrispondente");

            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2));
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2017));
            var tEntrydetail = dsEP.Tables["entrydetail"];
            //ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO
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
        public void Test_Scrittu_estimate_2017_dettagli_annullati()
        {
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
            if(regole != null) 
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");

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
        public void Test_Scrittu_estimate_2017_dettagli_annullati_NonCollFattura()
        {
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
            if(regole != null) 
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");

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
        public void Test_Scrittu_estimate_2017_dettagli_annullati_CollFattura()
        {
            var t = new TestHelp(new DateTime(2018, 12, 31));
            q filterEst = q.eq("idestimkind", "CONTOTERZI-digspes") & q.eq("yestim", 2017) & q.eq("nestim", 39);
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
            if(regole != null) 
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");

            Assert.AreEqual(0, dsEP.Tables["entrydetail"].Rows.Count, $"Non ci sono scritture poichè contratto collegabile a fattura ");

        }

        [TestMethod]
        public void Test_ImpVar_estimate_2017_dettagli_annullati_NonCollFattura()
        {
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
            if(regole != null) 
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");

            //VERIFICA VARIAZIONI AI MOVIMENTI DI BUDGET
            DataRow[] rEpaccpvar = dsEP.Tables["epaccvar"]._Filter(null);
            Assert.AreEqual(rEpaccpvar.Length, 2, "Sono  presenti 2 variazioni");
            DataRow dr1_Epaccvr = rEpaccpvar[0];
            decimal totale = CfgFn.GetNoNullDecimal(dr1_Epaccvr["amount"]);
            for (int i = 2; i <= 5; i++)
            {
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
        public void Test_ImpVar_estimate_2017_dettagli_annullati_CollFattura()
        {
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
            if(regole != null) 
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");

            //VERIFICA VARIAZIONI AI MOVIMENTI DI BUDGET
            DataRow[] rEpaccpvar = dsEP.Tables["epaccvar"]._Filter(null);
            Assert.AreEqual(rEpaccpvar.Length, 2, "Sono  presenti 2 variazioni");
            DataRow dr1_Epaccvr = rEpaccpvar[0];
            decimal totale = CfgFn.GetNoNullDecimal(dr1_Epaccvr["amount"]);
            for (int i = 2; i <= 5; i++)
            {
                totale += CfgFn.GetNoNullDecimal(dr1_Epaccvr["amount" + i.ToString()]);
            }
            Assert.AreEqual(totale, -30.00m, "L'importo totale della variazione è corrispondente");

            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(null);
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2017));
            //PRIMO ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            Assert.AreEqual(dr1_epacc["description"], "Incasso ECDL", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epaccyear["amount"], 30.00m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idacc"], "170001000100010007", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idupb"], "000100020003000300010008", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["idaccmotive"], "000100010007", "La causale del mov.budget è corrispondente");

        }

        [TestMethod]
        public void Test_Scrittu_estimate_2018_dettagli_annullati_NonCollFattura()
        {
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
        public void Test_Scrittu_estimate_2018_dettagli_annullati_CollFattura()
        {
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
            if(regole != null) 
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
        public void Test_ImpVar_estimate_2018_dettagli_annullati_CollFattura()
        {
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
            if(regole != null) 
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
        public void Test_Scrittu_mandate_2017_dettagli_annullati_NonCollFattura()
        {
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
            var dsEP = t.getEpData(t.testConn, rMan);
            t.deleteEp(rMan);

            //CONTROLLO PER REGOLE 
            ProcedureMessageCollection regole = t.generateEP(rMan);
            if(regole != null) 
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
 
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
            Assert.AreEqual(tEntrydetail.Rows[2]["description"], "Perdita su cambi", "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(tEntrydetail.Rows[2]["idacc"], "170002001700010003", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(tEntrydetail.Rows[2]["idupb"], "000100030003000200020676", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(tEntrydetail.Rows[2]["idreg"], 123934, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(tEntrydetail.Rows[2]["idaccmotive"], "000200170003", "La causale del dettaglio della scrittura è corrispondente");

            //SECONDO DETTAGLIO SCRITTURA
            Assert.AreEqual(tEntrydetail.Rows[3]["description"], "Perdita su cambi", "La descrizione del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(tEntrydetail.Rows[3]["idacc"], "170004000600090001", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(tEntrydetail.Rows[3]["idupb"], "000100030003000200020676", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(tEntrydetail.Rows[3]["idreg"], 123934, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(tEntrydetail.Rows[3]["idaccmotive"], "000200170003", "La causale del dettaglio della scrittura è corrispondente");

            //CONTROLLO CORRISPONDENZA TRA SCRITTURA E MOVIMENTO DI BUDGET
            Assert.AreEqual(tEntrydetail.Rows[2]["idepexp"], dr1_epexp["idepexp"]);
            Assert.AreEqual(tEntrydetail.Rows[2]["idrelated"], dr1_epexp["idrelated"]);

            //CONTROLLO CORRISPONDENZA TRA SCRITTURA E MOVIMENTO DI BUDGET
            Assert.AreEqual(tEntrydetail.Rows[3]["idepexp"], dr1_epexp["idepexp"]);
            Assert.AreEqual(tEntrydetail.Rows[3]["idrelated"], dr1_epexp["idrelated"]);
        }

        [TestMethod]
        public void Test_Scrittu_mandate_2017_dettagli_annullati_CollFattura()
        {
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
            if(regole != null) 
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");

            Assert.AreEqual(0, dsEP.Tables["entrydetail"].Rows.Count, $"Non ci sono scritture poichè contratto collegabile a fattura");

        }

        [TestMethod]
        public void Test_ImpVar_mandate_2017_dettagli_annullati_NonCollFattura()
        {
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
            if(regole != null) 
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");

            //VERIFICA VARIAZIONI AI MOVIMENTI DI BUDGET
            DataRow[] rEpexpvar = dsEP.Tables["epexpvar"]._Filter(null);
            Assert.AreEqual(rEpexpvar.Length, 2, "Sono  presenti 2 variazioni");
            DataRow dr1_Epexpvar = rEpexpvar[0];
            decimal totale = CfgFn.GetNoNullDecimal(dr1_Epexpvar["amount"]);
            for (int i = 2; i <= 5; i++)
            {
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
        public void Test_ImpVar_mandate_2017_dettagli_annullati_CollFattura()
        {
        
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
            if(regole != null) 
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rMan);
            //VERIFICA VARIAZIONI AI MOVIMENTI DI BUDGET
            DataRow[] rEpexpvar = dsEP.Tables["epexpvar"]._Filter(null);
            Assert.AreEqual(rEpexpvar.Length, 2*2, "sono presenti 2 variazioni");

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
        public void Test_Scrittu_mandate_2018_dettagli_annullati_NonCollFattura()
        {
            var t = new TestHelp(new DateTime(2018, 12, 31));
            q filterMan = q.eq("idmankind", "VARI_GEST_nofattura") & q.eq("yman", 2018) & q.eq("nman", 108);
            t.binaryReplaceSet(filterMan, t.getTableSet(TestHelp.mainObject.mandate));
            DataTable tMandate = t.testConn.readTable("mandate", filterMan);
            Assert.AreEqual(1, tMandate.Rows.Count, "Il contratto esiste");
            DataTable tMandateDetail = t.testConn.readTable("mandatedetail", filterMan & q.isNotNull("stop"));
            int nManDet = tMandateDetail.Rows.Count;
            Assert.AreNotEqual(0, nManDet, "Il contratto non ha dettagli");
            DataRow rMan = tMandate.Rows[0];
            var dsEP = t.getEpData(t.testConn, rMan);
            //t.deleteEp(rMan);
            t.binaryCopyEp(rMan, false);

            //CONTROLLO PER REGOLE 
            ProcedureMessageCollection regole = t.generateEP(rMan);
            dsEP = t.getEpData(t.testConn, rMan);

            if(regole != null) 
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");

            var tEntrydetail = dsEP.Tables["entrydetail"];
            var tEntry = dsEP.Tables["entry"];    
            DataRow[] rEpexp = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2));
            DataRow dr1_epexp = rEpexp[0];

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

            Assert.IsNotNull(rDet1,"Trovato dettaglio 1 con conto e descrizione corrispondenti");
            //Assert.AreEqual(tEntrydetail.Rows[0]["idacc"], "18000200010002000800100004", "Il n.conto del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet1["idupb"], "000100030004000100021274", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet1["idreg"], 130527, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet1["idaccmotive"], "000600010002000600100004", "La causale del dettaglio della scrittura è corrispondente");

            //SECONDO DETTAGLIO SCRITTURA
            var rDet2 = tEntrydetail._Filter(q.eq("description",
	                                             "Contratto passivo VARI_GEST_nofattura n.108 / 2018 dett. 1")
                                             & q.eq("idacc", "18000400040001000100090001")).FirstOrDefault();
            Assert.IsNotNull(rDet2,"Trovato dettaglio 2 con conto e descrizione corrispondenti");

            Assert.AreEqual(rDet2["idupb"], "000100030004000100021274", "L'UPB del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet2["idreg"], 130527, "Il cliente del dettaglio della scrittura è corrispondente");
            Assert.AreEqual(rDet2["idaccmotive"], "000600010002000600100004", "La causale del dettaglio della scrittura è corrispondente");

            //CONTROLLO CORRISPONDENZA TRA SCRITTURA E MOVIMENTO DI BUDGET
            Assert.AreEqual(rDet1["idepexp"], dr1_epexp["idepexp"]);
            Assert.AreEqual(rDet1["idrelated"], dr1_epexp["idrelated"]);
        }

        [TestMethod]
        public void Test_Scrittu_mandate_2018_dettagli_annullati_CollFattura()
        {
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
            if(regole != null) 
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");

            Assert.AreEqual(0, dsEP.Tables["entrydetail"].Rows.Count, $"Non ci sono scritture poichè contratto collegabile a fattura");
        }

        [TestMethod]
        public void Test_ImpVar_mandate_2018_dettagli_annullati_NonCollFattura()
        {
            var t = new TestHelp(new DateTime(2018, 12, 31));
            q filterMan = q.eq("idmankind", "VARI_GEST_nofattura") & q.eq("yman", 2018) & q.eq("nman", 108);
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
            if(regole != null) 
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rMan);
            //VERIFICA VARIAZIONI AI MOVIMENTI DI BUDGET
            DataRow[] rEpexpvar = dsEP.Tables["epexpvar"]._Filter(null);
            Assert.AreEqual(rEpexpvar.Length, 2, "Sono  presenti 2 variazioni");
            DataRow dr1_Epexpvar = rEpexpvar[0];
            decimal totale = CfgFn.GetNoNullDecimal(dr1_Epexpvar["amount"]);
            for (int i = 2; i <= 5; i++)
            {
                totale += CfgFn.GetNoNullDecimal(dr1_Epexpvar["amount" + i.ToString()]);
            }
            Assert.AreEqual(totale, -595.00m, "L'importo totale della variazione è corrispondente");

            DataRow[] rEpexp = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2));
            DataRow[] rEpexpyear = dsEP.Tables["epexpyear"]._Filter(q.eq("ayear", 2018));
            var tEntrydetail = dsEP.Tables["entrydetail"];
            //IMPEGNO VAR. BUDGET ASSOCIATO AL CONTRATTO PASSIVO
            DataRow dr1_epexp = rEpexp[0];
            DataRow dr1_epexpyear = rEpexpyear[0];
            Assert.AreEqual(dr1_epexp["description"], "Iscrizione E-MRS 2018 Spring Meeting - Chiara Vittoni", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epexpyear["amount"], 595.00m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexpyear["idacc"], "18000200010002000800100004", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexpyear["idupb"], "000100030004000100021274", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexp["idaccmotive"], "000600010002000600100004", "La causale del mov.budget è corrispondente");

            //CONTROLLO CORRISPONDENZA TRA SCRITTURA E MOVIMENTO DI BUDGET
            Assert.AreEqual(tEntrydetail.Rows[0]["idepexp"], dr1_epexp["idepexp"]);
            Assert.AreEqual(tEntrydetail.Rows[0]["idrelated"], dr1_epexp["idrelated"]);

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
        public void Test_ImpVar_mandate_2017_dettagli2018_CollFattura()
        {
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
            if(regole != null) 
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rMan);
            //VERIFICA VARIAZIONI AI MOVIMENTI DI BUDGET
            DataRow[] rEpexpvar = dsEP.Tables["epexpvar"]._Filter(null);
            Assert.AreEqual(rEpexpvar.Length, 2, "Sono  presenti 2 variazioni");
            DataRow dr1_Epexpvar = rEpexpvar[0];
            decimal totale = CfgFn.GetNoNullDecimal(dr1_Epexpvar["amount"]);
            for (int i = 2; i <= 5; i++)
            {
                totale += CfgFn.GetNoNullDecimal(dr1_Epexpvar["amount" + i.ToString()]);
            }
            Assert.AreEqual(totale, -541.80m, "L'importo totale della variazione è corrispondente");

            DataRow[] rEpexp = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2) & q.eq("yepexp",2017));
            DataRow[] rEpexpyear = dsEP.Tables["epexpyear"]._Filter(q.eq("ayear", 2018));
            //PRIMO IMPEGNO VAR. BUDGET ASSOCIATO AL CONTRATTO PASSIVO
            DataRow dr1_epexp = rEpexp[0];
            DataRow dr1_epexpyear = rEpexpyear[0];
            Assert.AreEqual(dr1_epexp["description"], "Servizi di analisi ed esami di laboratorio", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epexpyear["amount"], 541.80m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexpyear["idacc"], "18000200010002000500010005", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexpyear["idupb"], "000100030003000200020701", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexp["idaccmotive"], "0002000600050001", "La causale del mov.budget è corrispondente");
        }

        [TestMethod]
        public void Test_ImpVar_mandate_2017_dettagli2018_NonCollFattura()
        {
            var t = new TestHelp(new DateTime(2018, 12, 31));
            q filterMan = q.eq("idmankind", "VARI_GEST_nofattura") & q.eq("yman", 2017) & q.eq("nman", 389);
            t.binaryReplaceSet(filterMan, t.getTableSet(TestHelp.mainObject.mandate));
            DataTable tMandate = t.testConn.readTable("mandate", filterMan);
            Assert.AreEqual(1, tMandate.Rows.Count, "Il contratto esiste");
            DataTable tMandateDetail = t.testConn.readTable("mandatedetail", filterMan & q.isNotNull("start"));
            int nManDet = tMandateDetail.Rows.Count;
            Assert.AreNotEqual(0, nManDet, "Il contratto non ha dettagli");
            DataRow rMan = tMandate.Rows[0];
            var dsEP = t.getEpData(t.testConn, rMan);
            t.deleteEp(rMan);

            //CONTROLLO PER REGOLE 
            ProcedureMessageCollection regole = t.generateEP(rMan);
            if(regole != null) 
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");

            //VERIFICA VARIAZIONI AI MOVIMENTI DI BUDGET
            DataRow[] rEpexpvar = dsEP.Tables["epexpvar"]._Filter(null);
            Assert.AreEqual(rEpexpvar.Length, 0, "Sono  presenti 0 variazioni");
            
            DataRow[] rEpexp = dsEP.Tables["epexp"]._Filter(q.eq("nphase", 2));
            DataRow[] rEpexpyear = dsEP.Tables["epexpyear"]._Filter(q.eq("ayear", 2018));
            var tEntrydetail = dsEP.Tables["entrydetail"];
            //IMPEGNO VAR. BUDGET ASSOCIATO AL CONTRATTO PASSIVO
            DataRow dr1_epexp = rEpexp[0];
            DataRow dr1_epexpyear = rEpexpyear[0];
            Assert.AreEqual(dr1_epexp["description"], "Iscrizione a Convegni e Congressi - docenti e collaboratori scientifici", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epexpyear["amount"], 329.40m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexpyear["idacc"], "18000200010002000800100003", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexpyear["idupb"], "000100030003000200020072", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epexp["idaccmotive"], "000200030006", "La causale del mov.budget è corrispondente");

            //CONTROLLO CORRISPONDENZA TRA SCRITTURA E MOVIMENTO DI BUDGET
            Assert.AreEqual(tEntrydetail.Rows[0]["idepexp"], dr1_epexp["idepexp"]);
            Assert.AreEqual(tEntrydetail.Rows[0]["idrelated"], dr1_epexp["idrelated"]);
        }

        [TestMethod]
        public void Test_Scrittu_mandate_2017_dettagli2018_CollFattura()
        {
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
            if(regole != null) 
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rMan);
            var countDetScritt = dsEP.Tables["entrydetail"]._Filter(q.like("idrelated", "man")).Length;
            Assert.AreEqual(0, countDetScritt, $"Non ci sono scritture poichè contratto collegabile a fattura");
        }

        [TestMethod]
        public void Test_Scrittu_mandate_2017_dettagli2018_NonCollFattura()
        {
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

            if(regole != null) 
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
        public void Test_ImpVar_estimate_2017_dettagli2018_CollFattura()
        {
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
            if(regole != null) 
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rEst);
            //VERIFICA VARIAZIONI AI MOVIMENTI DI BUDGET
            DataRow[] rEpaccpvar = dsEP.Tables["epaccvar"]._Filter(null);
            Assert.AreEqual(rEpaccpvar.Length, 2, "Sono  presenti 2 variazioni");
            DataRow dr1_Epaccvr = rEpaccpvar[0];
            decimal totale = CfgFn.GetNoNullDecimal(dr1_Epaccvr["amount"]);
            for (int i = 2; i <= 5; i++)
            {
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
        public void Test_ImpVar_estimate_2017_dettagli2018_NonCollFattura()
        {
            var t = new TestHelp(new DateTime(2018, 12, 31));
            q filterEst = q.eq("idestimkind", "DOCAMM-amm") & q.eq("yestim", 2017) & q.eq("nestim", 356);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst & q.isNotNull("start"));
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreNotEqual(0, nEstDet, "Il contratto non ha dettagli");
            DataRow rEst = tEstimate.Rows[0];
            var dsEP = t.getEpData(t.testConn, rEst);
            t.deleteEp(rEst);

            //CONTROLLO PER REGOLE 
            ProcedureMessageCollection regole = t.generateEP(rEst);
            if(regole != null) 
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");

            //VERIFICA VARIAZIONI AI MOVIMENTI DI BUDGET
            DataRow[] rEpaccpvar = dsEP.Tables["epaccvar"]._Filter(null);
            Assert.AreEqual(rEpaccpvar.Length, 8, "Sono  presenti 8 variazioni");
            DataRow dr1_Epaccvr = rEpaccpvar[0];
            decimal totale = CfgFn.GetNoNullDecimal(dr1_Epaccvr["amount"]);
            for (int i = 2; i <= 5; i++)
            {
                totale += CfgFn.GetNoNullDecimal(dr1_Epaccvr["amount" + i.ToString()]);
            }
            Assert.AreEqual(totale, 550.00m, "L'importo totale della variazione è corrispondente");

            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2));
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(null);
            var tEntrydetail = dsEP.Tables["entrydetail"];
            //ACCERTAMENTO DI BUDGET ASSOCIATO AL CONTRATTO ATTIVO
            DataRow dr1_epacc = rEpacc[1];
            DataRow dr1_epaccyear = rEpaccyear[1];
            Assert.AreEqual(dr1_epacc["description"], "Incasso altre tasse", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epaccyear["amount"], 1850.00m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idacc"], "170001000100010007", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idupb"], "000100020002000300010001", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["idaccmotive"], "000100010007", "La causale del mov.budget è corrispondente");

            //CONTROLLO CORRISPONDENZA TRA SCRITTURA E MOVIMENTO DI BUDGET
            Assert.AreEqual(tEntrydetail.Rows[4]["idepacc"], dr1_epacc["idepacc"]);
            Assert.AreEqual(tEntrydetail.Rows[4]["idrelated"], dr1_epacc["idrelated"]);
        }

        [TestMethod]
        public void Test_Scrittu_estimate_2017_dettagli2018_CollFattura()
        {
            var t = new TestHelp(new DateTime(2018, 12, 31));
            q filterEst = q.eq("idestimkind", "CONTOTERZI-digspes") & q.eq("yestim", 2017) & q.eq("nestim", 39);
            t.binaryReplaceSet(filterEst, t.getTableSet(TestHelp.mainObject.estimate));
            DataTable tEstimate = t.testConn.readTable("estimate", filterEst);
            Assert.AreEqual(1, tEstimate.Rows.Count, "Il contratto esiste");
            DataTable tEstimateDetail = t.testConn.readTable("estimatedetail", filterEst & q.isNotNull("start"));
            int nEstDet = tEstimateDetail.Rows.Count;
            Assert.AreNotEqual(0, nEstDet, "Il contratto non ha dettagli");
            DataRow rEst = tEstimate.Rows[0];
            var dsEP = t.getEpData(t.testConn, rEst);
            t.deleteEp(rEst);

            //CONTROLLO PER REGOLE 
            ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);
            if(regole != null) 
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");

            Assert.AreEqual(0, dsEP.Tables["entrydetail"].Rows.Count, $"Non ci sono scritture poichè contratto collegabile a fattura");
        }

        [TestMethod]
        public void Test_Regola_Scrittu_estimate_2017_dettagli2018_CollFattura()
        {
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
            var mEstimate = t.editDataRow(filterEst, "estimate", "default");
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
        public void Test_Scrittu_estimate_2017_dettagli2018_NonCollFattura()
        {
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
            if(regole != null) 
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");

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
        public void Test_estimate_2019_sostituito2019_NonCollFattura_parzCont_Prova()
        {
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
            var estimDetailTest2 = t.testConn.readFromTable("estimatedetail", filterEst& q.eq("rownum",2));
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
            Assert.AreEqual(2*2, rEpaccvar.Length, "Sono presenti 2 variazioni");

            //VERIFICO LA VARIAZIONE SULL'ACCERTAMENTO 1710
            DataRow dr1_Epaccvar = dsEP.Tables["epaccvar"]._Filter(q.eq("idepacc", idepaccGenerato2))[0];
            decimal totale = CfgFn.GetNoNullDecimal(dr1_Epaccvar["amount"]);
            for (int i = 2; i <= 5; i++)
            {
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
        public void Test2_estimate_2018_annullo2019_NonCollFattura()
        {
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
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(null);
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[1];
            Assert.AreEqual(dr1_epacc["description"], "annullo nel 2019 VERSIONE 1 con CAUSALE di COSTO CN1.5.01.03.008 - NUOVA GESTIONE", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epaccyear["amount"], -10.00m, "L'importo del mov.budget è corrispondente");
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

            //CONTROLLO VARIAZIONI AI MOVIMENTI DI BUDGET
            DataRow[] rEpaccpvar = dsEP.Tables["epaccvar"]._Filter(null);
            Assert.AreEqual(rEpaccpvar.Length, 2, "Sono presenti variazioni");

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
        public void Test2_estimate_2018_sostituito2019_NonCollFattura_nonIncassato()
        {
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
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rEst);

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
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            Assert.AreEqual(dr1_epacc["description"], "Sostituzione nel 2019 dettaglio senza data inizio e non incassato o contabilizzato: \r\nVERSIONE 1 con CAUSALE di COSTO CN1.5.01.03.008: NUOVA GEST\r\n", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epaccyear["amount"], -100.00m, "L'importo del mov.budget è corrispondente");
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
            Assert.AreEqual(dr1_epexpyear["amount"], 20.00m, "L'importo del mov.budget è corrispondente");
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
            //CASO esercizi anni precedenti 1d.2 // 
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

            Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola"); //abbiamo rimosso if  not null
            var dsEP = t.getEpData(t.testConn, rEst);

            //CONTROLLO VARIAZIONI AI MOVIMENTI DI BUDGET
            DataRow[] rEpaccpvar = dsEP.Tables["epaccvar"]._Filter(null);
            Assert.AreEqual(0, rEpaccpvar.Length,  "Non sono presenti variazioni");

            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019)).Length;
            Assert.AreEqual(1, countNepacc2019, "E' presente un accertamento  di budget");
            int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
            Assert.AreEqual(1, countNepacc2018, "Ci sono 1 accertamenti di budget");


            //CONTROLLO PRIMO ACCERTAMENTO DI BUDGET 
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2)&q.eq("idepacc",idepacc1));
            Assert.AreEqual(1,rEpacc.Length,$"Esiste l'acc. di budget {idepacc1} ");
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", idepacc1));
            Assert.AreEqual(1,rEpaccyear.Length,$"Esiste l'imputazione 2019 dell'acc. di budget {idepacc1} ");


            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            Assert.AreEqual(dr1_epacc["description"], "Sostituzione nel 2019 dettaglio senza data inizio e non incassato o contabilizzato: \r\nVERSIONE 1 con CAUSALE di ricavo CN1.5.01.03.008: NUOVA GEST\r\n", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(-80.00m, dr1_epaccyear["amount"],  "L'importo del mov.budget è corrispondente");
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
            Assert.AreEqual(dr2_epaccyear["amount"], 35.00m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epaccyear["idacc"], "19000100010001000100030005", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epaccyear["idupb"], "000100010014", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epacc["idaccmotive"], "000700010001000100030005", "La causale del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epacc["idrelated"], idrelated2, "Secondo accertamento con idrelated del 2° dettaglio");


            //CONTROLLO DATI SCRITTURE IN PARTITA DOPPIA
            var tEntrydetailRows = dsEP.Tables["entrydetail"]._Filter(q.eq("yentry",2019));
            Assert.AreEqual(2,tEntrydetailRows.Length,"La scrittura ha due dettagli");

            var rEntry = dsEP.Tables["entry"].Rows[0];
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

            Assert.AreEqual(EntryDetail2["idepacc"], idepacc1,"Secondo dettaglio scrittura collegato all'accertamento 2018 del primo dettaglio");
            Assert.AreEqual(EntryDetail2["idrelated"], idrelated1,"Secondo dettaglio scrittura con idrelated del primo dettaglio");
            

            //CONTROLLO CORRISPONDENZA TRA ID RELATED SCRITTURA E DETTAGLIO CONTRATTO
            Assert.AreEqual(EntryDetail1["idrelated"],  idrelated1,"Primo dettaglio scrittura con idrelated del primo dettaglio");
            Assert.AreEqual(EntryDetail1["idepacc"],  idepacc2,"Primo dettaglio scrittura con idepacc del secondo dettaglio");
        }

        [TestMethod]
        public void Test2_estimate_2018_sostituito2019_NonCollFattura_nonIncassato3()
        {
            //CASO esercizi anni precedenti 1d.3 // 
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
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rEst);

            //CONTROLLO VARIAZIONI AI MOVIMENTI DI BUDGET DEL 2018
            DataRow[] rEpaccpvar = dsEP.Tables["epaccvar"]._Filter(null);
            Assert.AreEqual(rEpaccpvar.Length, 2, "Sono presenti 2 variazioni");
            DataRow dr1_Epaccvar = rEpaccpvar[0];
            decimal totale = CfgFn.GetNoNullDecimal(dr1_Epaccvar["amount"]);
            for (int i = 2; i <= 5; i++)
            {
                totale += CfgFn.GetNoNullDecimal(dr1_Epaccvar["amount" + i.ToString()]);
            }
            Assert.AreEqual(totale, -10.00m, "L'importo totale della variazione è corrispondente");

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
            Assert.AreEqual(dr1_epaccyear["amount"], 20.00m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idacc"], "19000100010005000100010022", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epaccyear["idupb"], "000100030007000100010098", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr1_epacc["idaccmotive"], "000700010005000100010022", "La causale del mov.budget è corrispondente");

            //CONTROLLO SECONDO ACCERTAMENTO DI BUDGET 
            DataRow[] rEpacc2 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("idepacc", 207564));
            DataRow[] rEpaccyear2 = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", 207564));
            DataRow dr2_epacc = rEpacc2[0];
            DataRow dr2_epaccyear = rEpaccyear2[0];
            Assert.AreEqual(dr2_epacc["description"], "Sostituzione nel 2018 e 2019 dettaglio senza data inizio e non incassato o contabilizzato: \r\nVERSIONE 1 con CAUSALE di ricavo: NUOVA GEST\r\n", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr2_epaccyear["amount"], 25.00m, "L'importo del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epaccyear["idacc"], "19000100010005000100010022", "Il n.conto del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epaccyear["idupb"], "000100030007000100010098", "L'UPB del mov.budget è corrispondente");
            Assert.AreEqual(dr2_epacc["idaccmotive"], "000700010005000100010022", "La causale del mov.budget è corrispondente");

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
        public void Test2_estimate_2018_sostituito2019_NonCollFattura_parzaccert()
        {
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
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rEst);

            //CONTROLLO VARIAZIONI AI MOVIMENTI DI BUDGET 2018
            DataRow[] rEpaccpvar = dsEP.Tables["epaccvar"]._Filter(null);
            Assert.AreEqual(rEpaccpvar.Length, 2, "Sono presenti 2 variazioni");
            DataRow dr1_Epaccvar = rEpaccpvar[0];
            decimal totale = CfgFn.GetNoNullDecimal(dr1_Epaccvar["amount"]);
            for (int i = 2; i <= 5; i++)
            {
                totale += CfgFn.GetNoNullDecimal(dr1_Epaccvar["amount" + i.ToString()]);
            }
            Assert.AreEqual(totale, -20.00m, "L'importo totale della variazione è corrispondente");

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

            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019)).Length;
            Assert.AreEqual(0, countNepacc2019, "E' presente un accertamento  di budget");
            int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
            Assert.AreEqual(2, countNepacc2018, "Ci sono 2 accertamenti di budget");

            //CONTROLLO PRIMO ACCERTAMENTO DI BUDGET
            DataRow[] rEpacc = dsEP.Tables["epacc"]._Filter(q.eq("nphase",2) & q.eq("yepacc", 2018) & q.eq("idepacc", 207570));
            DataRow[] rEpaccyear = dsEP.Tables["epaccyear"]._Filter(q.eq("ayear", 2019) & q.eq("idepacc", 207570));
            DataRow dr1_epacc = rEpacc[0];
            DataRow dr1_epaccyear = rEpaccyear[0];
            Assert.AreEqual(dr1_epacc["description"], "Sostituzione nel 2019 dettaglio senza data parzialmente accertato/incassato", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr1_epaccyear["amount"], -20.00m, "L'importo del mov.budget è corrispondente");
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
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rEst);

            //CONTROLLO VARIAZIONI AI MOVIMENTI DI BUDGET 2018
            DataRow[] rEpaccpvar = dsEP.Tables["epaccvar"]._Filter(null);
            Assert.AreEqual(rEpaccpvar.Length, 2, "Sono presenti 2 variazioni");
            DataRow dr1_Epaccvar = rEpaccpvar[0];
            decimal totale = CfgFn.GetNoNullDecimal(dr1_Epaccvar["amount"]);
            for (int i = 2; i <= 5; i++)
            {
                totale += CfgFn.GetNoNullDecimal(dr1_Epaccvar["amount" + i.ToString()]);
            }
            Assert.AreEqual(totale, -15.00m, "L'importo totale della variazione è corrispondente");

            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019)).Length;
            Assert.AreEqual(1, countNepacc2019, "E' presente un accertamento  di budget");
            int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
            Assert.AreEqual(2, countNepacc2018, "Ci sono 2 accertamenti di budget");

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
            DataRow dr2_epacc = rEpacc2[0];
            DataRow dr2_epaccyear = rEpaccyear2[0];
            Assert.AreEqual(dr2_epacc["description"], "sostituzione CA contabilizzato veRSIONE 1 con CAUSALE di RICAVO NUOVA GEST", "La descrizione del mov.budget  è corrispondente");
            Assert.AreEqual(dr2_epaccyear["amount"], -15.00m, "L'importo del mov.budget è corrispondente");
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
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rEst);

            //CONTROLLO VARIAZIONI AI MOVIMENTI DI BUDGET DEL 2019
            DataRow[] rEpaccpvar = dsEP.Tables["epaccvar"]._Filter(null);
            Assert.AreEqual(rEpaccpvar.Length, 2, "Sono presenti 2 variazioni");
            DataRow dr1_Epaccvar = rEpaccpvar[0];
            decimal totale = CfgFn.GetNoNullDecimal(dr1_Epaccvar["amount"]);
            for (int i = 2; i <= 5; i++)
            {
                totale += CfgFn.GetNoNullDecimal(dr1_Epaccvar["amount" + i.ToString()]);
            }
            Assert.AreEqual(totale, -150.00m, "L'importo totale della variazione è corrispondente");

            //CONTROLLO NUMERO ACCERTAMENTI DI BUDGET
            int countNepacc2019 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2019)).Length;
            Assert.AreEqual(0, countNepacc2019, "E' presente un accertamento  di budget del 2019");
            int countNepacc2018 = dsEP.Tables["epacc"]._Filter(q.eq("nphase", 2) & q.eq("yepacc", 2018)).Length;
            Assert.AreEqual(1, countNepacc2018, "E' presente un accertamento di budget del 2018");

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
            Assert.AreEqual(0, dsEP.Tables["entry"].Rows.Count, $"Non ci sono scritture");

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
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rEst);

            //CONTROLLO VARIAZIONI AI MOVIMENTI DI BUDGET 
            DataRow[] rEpaccpvar = dsEP.Tables["epaccvar"]._Filter(null);
            Assert.AreEqual(rEpaccpvar.Length, 1*2, "E' presente una variazione");
            DataRow dr1_Epaccvar = rEpaccpvar[0];
            decimal totale = CfgFn.GetNoNullDecimal(dr1_Epaccvar["amount"]);
            for (int i = 2; i <= 5; i++)
            {
                totale += CfgFn.GetNoNullDecimal(dr1_Epaccvar["amount" + i.ToString()]);
            }
            Assert.AreEqual(totale, -22.00m, "L'importo totale della variazione è corrispondente");

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
            Assert.AreNotEqual(0, nEstDet, "Il contratto ha dettagli annullati");

            //GENERO LE SCRITTURE E CONTROLLO LE REGOLE CHE MI ASPETTO/NON ASPETTO SCATTINO 
            ProcedureMessageCollection regole = t.generaAccertamentiScritture(rEst);
            if (regole != null)
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            var dsEP = t.getEpData(t.testConn, rEst);

            //CONTROLLO VARIAZIONI AI MOVIMENTI DI BUDGET 
            DataRow[] rEpaccpvar = dsEP.Tables["epaccvar"]._Filter(null);
            Assert.AreEqual(rEpaccpvar.Length, 1 * 2, "E' presente una variazione");
            DataRow dr1_Epaccvar = rEpaccpvar[0];
            decimal totale = CfgFn.GetNoNullDecimal(dr1_Epaccvar["amount"]);
            for (int i = 2; i <= 5; i++)
            {
                totale += CfgFn.GetNoNullDecimal(dr1_Epaccvar["amount" + i.ToString()]);
            }
            Assert.AreEqual(totale, -22.00m, "L'importo totale della variazione è corrispondente");

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
            var dsEP = t.getEpData(t.testConn, rInv);
            t.deleteEp(rInv);

            //CONTROLLO PER REGOLE 
            ProcedureMessageCollection regole = t.generateEP(rInv);
            if(regole != null) 
                Assert.AreEqual(0, regole.Count, "Non scatta nessuna regola");
            
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

        #endregion

        public void Test_Regola_Modifica_denominazioneAnagr_collegataMovSpesa()
        {
            //ANAGRAFICA COLLEGATA A UN MOVIMENTO DI SPESA 
            var t = new TestHelp(new DateTime(2018, 12, 31));
            q filterReg = q.eq("idreg", 155414);
            t.binaryReplaceSet(filterReg, t.getTableSet(TestHelp.mainObject.registry));

            //MODIFICO IL DATASET DELL'ANAGRAFICA
            var mRegistry = t.editDataRow(filterReg, "registry", "anagrafica");
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
