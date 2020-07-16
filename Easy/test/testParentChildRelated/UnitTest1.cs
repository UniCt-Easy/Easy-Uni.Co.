/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using metadatalibrary;
using System.Data;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Dynamic;
using System.Reflection;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using q = metadatalibrary.MetaExpression;
using meta_account;
using meta_config;

namespace testParentChildRelated {
    [TestClass]
    public class UnitTest1 {
        //static DataAccess conn;
        //static QueryHelper QHS;

        //[ClassInitialize]
        //public static void testInit(TestContext tc) {

        //    bool isFoundDSN; // Utilizzata per verificare l'esistenza della Key all'interno del file di configurazione

        //    DBConn.DBConn dbConnection = new DBConn.DBConn("DSN1", out isFoundDSN);

        //    if (isFoundDSN) {
        //        conn = dbConnection.getDataAccess(DateTime.Now.Year, DateTime.Now);
        //        // Ritorna il DataAccess             
        //        QHS = conn.GetQueryHelper();
        //    }
        //    else
        //        // Inserire qui il codice per la gestione dell'errore!
        //        return;

        //}

        //[ClassCleanup]
        //public static void testEnd() {
        //    conn.Destroy();
        //}

        /// <summary>
        /// TEST sui parent
        /// </summary>
        [TestMethod]
        public void TestParent() {

            //public static S parent<R, S>(this R row, MetaTableBase<S> table, string relationName = null) where R : MetaRow where S : MetaRow

            //DS.account.First().childs(DS.config.First())
            dsmeta DS = new testParentChildRelated.dsmeta();
            DataAccess.SetTableForReading(DS.account_accruedcost, "account");
            restoreDataset(DS);

            DataRow r = DS.account.First();
            
            var a = r.childs(DS.config).ToArray();
            Assert.AreEqual(a.Count(), 3); //mi aspetto sia 3 perché ho 3 colonne in config con idacc_pl = ID1 
            var x = r.GetChildRows("account_config").ToArray();
            Assert.AreEqual(a.Count(), x.Count()); //verifico che childs = GetChildRows
            var ar = r.related(DS.config).ToArray();
            Assert.AreEqual(ar.Count(), 3); //mi aspetto sia 3 perché ho 3 colonne in config con idacc_pl = ID1  
            Assert.AreEqual(a.Count(), ar.Count()); //verifico che childs = related
            Assert.AreEqual(x.Count(), ar.Count()); //verifico che GetChildRows = related

            
            var aa = r.childs(DS.config).First(); //prendo la prima riga del figlio
            var aaa = aa.related(DS.account); //prendo la riga del padre
            Assert.AreEqual(aaa.ToArray().Count(),1); //mi aspetto sia 1 perché in account solo 1 riga ha idacc = ID1

            //var aaaa = aaa.related(DS.account); //aaaa = config
            //Assert.AreEqual(aaaa.ToArray().Count(), 3); 

            var c = r.childs(DS.account).ToArray(); //faccio il childs su se stesso
            Assert.AreEqual(c.Count(), 0); //mi aspetto 0 perché non esiste la relazione su se stesso

            var d = r.related(DS.account).ToArray(); //faccio il related su se stesso
            Assert.AreEqual(c.Count(), 0); //mi aspetto 0 perché non esiste la relazione su se stesso

            var p = r.parent(DS.account); //faccio il padre di se stesso
            Assert.IsNull(p); //mi aspetto null perché non esiste la relazione su se stesso

            var p2 = r.parent(DS.config); //faccio il parent su confing
            Assert.IsNull(p2); //mi aspetto null perché non esiste la relazione su se stesso

            var b1 = r.childs(DS.config).First(); //prendo la prima riga del figlio perchè la usero per trovare il suo padre
            var b2 = b1.parent(DS.account); //prendo la riga del padre
            var b3 = b2.childs(DS.config).First();//ritorno alla situazione b1
            var b4 = b3.parent(DS.account);
            Assert.AreEqual(b2, b4);
            Assert.AreEqual(b1, b3); 
            Assert.AreEqual(b2.ayear, b4.ayear);
            Assert.AreEqual(b1.ayear, b3.ayear);//Come atteso non perdo dati nello spostarmi tra padre e figlio
            Assert.AreNotEqual(b1, b2);
            Assert.AreNotEqual(b3, b4); //Come atteso sono diversi


            var aar = r.childs(DS.config).ToArray()[0];
            Assert.AreEqual(aar.ayear, (short)2017);
            Assert.AreEqual(aar.idacc_plValue, "ID1");
            Assert.AreEqual(aar.agencycodeValue, DBNull.Value);
            Assert.AreNotEqual(aar.appnameValue, null); //Risultati attesi
            var rar = r.related(DS.config).ToArray()[0];
            Assert.AreEqual(aar.idacc_plValue, rar.idacc_plValue);



            DataRow r2 = DS.config.First(); //situazione opposta, parto dal figlio avente riga "ayear", "2017", "idacc_pl", "ID1"
            var p3 = r2.parent(DS.account);
            Assert.AreEqual(p3.ayearValue, (short)2017); // mi aspetto 2017 perché lo ho valorizzato a 2017 all'inizio
            //Assert.IsNull(p3.ayearOriginal); //non ha un valore originale nel db quella riga essendo creata in modo virtuale
            Assert.AreEqual(p3.ayear, (short)2017); //funziona come ayearValue
            Assert.AreEqual(p3.investmentbudget_signValue,DBNull.Value); //DBNull perché non valorizzato 
            Assert.AreNotEqual(p3.investmentbudget_signValue, null); //perché è DBNull e non null

            var re = r2.related(DS.account);
            Assert.AreEqual(re.ToArray().Count(), 1);
            var ree = re.ToArray()[0];
            Assert.AreEqual(ree.ayearValue, p3.ayearValue);//Come atteso related funziona come parent

            Assert.AreEqual(ree.ayear, (short)2017); 
            Assert.AreEqual(ree.investmentbudget_signValue, DBNull.Value); 
            Assert.AreNotEqual(ree.investmentbudget_signValue, null); //Come atteso related funziona come parent

            DataRow r3 = DS.account_accruedcost.First();

            //var t = r.childs(DS.config).First();
            //var t2 = t.parent(DS.account_accruedcost);
            //Assert.AreEqual(t2.) //mi aspetto che t2. mi faccia vedere i campi di account_accruedcost, non posso neanche fare t2.ToArray()


            var fore = r.childs(DS.config); 
            fore._forEach(fe => fe.ayear = (short)2016); //mi imposta tutte le righe della colonna "ayer" a 2016
            Assert.AreEqual(fore.ToArray().Length, 3);
            Assert.AreEqual(fore.ToArray()[0].ayear, (short)2016);
            Assert.AreEqual(fore.ToArray()[0].ayear, fore.ToArray()[1].ayear);
            Assert.AreEqual(fore.ToArray()[0].ayear, fore.ToArray()[2].ayear); //come atteso tutte le righe della colonna "ayer" ora sono valorizzate a 2016

            fore._forEach((fe,i)=> fe.ayear = (short)i);
            Assert.AreEqual(fore.ToArray().Length, 3);
            Assert.AreEqual(fore.ToArray()[0].ayear, (short)0);
            Assert.AreEqual(fore.ToArray()[1].ayear, (short)1);
            Assert.AreEqual(fore.ToArray()[2].ayear, (short)2); //come atteso la i viene incrementata ad ogni riga

            fore._forEach((fe, i) => fe.ayear = i.Equals(1) ? (short)2014 : (short)2015 ); //uso la i in modo più "intelligente"
            Assert.AreEqual(fore.ToArray().Length, 3);
            Assert.AreEqual(fore.ToArray()[0].ayear, (short)2015);
            Assert.AreEqual(fore.ToArray()[1].ayear, (short)2014);
            Assert.AreEqual(fore.ToArray()[2].ayear, (short)2015); //ho impostato le righe ==1 a 2014, le altre a 2015

            restoreDataset(DS);
            r = DS.account.First();
            r2 = DS.config.First();
            r3 = DS.account_accruedcost.First();

            r = DS.account.ToArray()[2];
            Assert.AreEqual(r.childs(DS.config)._IsEmpty(), true);
            Assert.AreEqual(r.childs(DS.config)._HasRows(), false);
            var forelimits = r.childs(DS.config);
            Assert.AreEqual(forelimits._IsEmpty(),true);
            Assert.AreEqual(forelimits._HasRows(), false);
            Assert.AreEqual(forelimits.ToArray().Length, 0); //siamo nel caso in cui la colleziona è vuota
            forelimits._forEach(fe => fe.ayear = (short)2016);
            Assert.AreEqual(forelimits._IsEmpty(), true);
            Assert.AreEqual(forelimits._HasRows(), false);
            Assert.AreEqual(forelimits.ToArray().Length, 0); //la collezione rimane vuota
            forelimits._forEach(fe => fe.ayear = null);
            Assert.AreEqual(forelimits._IsEmpty(), true);
            Assert.AreEqual(forelimits._HasRows(), false);
            Assert.AreEqual(forelimits.ToArray().Length, 0); //la collezione rimane vuota

            restoreDataset(DS);
            r = DS.account.First();
            r2 = DS.config.First();
            r3 = DS.account_accruedcost.First();

            var forelimits2 = r.childs(DS.config);
            forelimits2._forEach(fe => fe.ayear = null); //mi imposta tutte le righe della colonna "ayer" a null
            Assert.AreEqual(forelimits2._IsEmpty(), false);
            Assert.AreEqual(forelimits2._HasRows(), true);
            Assert.AreEqual(forelimits2.ToArray().Length, 3);
            Assert.IsNull(forelimits2.ToArray()[0].ayear); // == null

            restoreDataset(DS);
            r = DS.account.First();
            r2 = DS.config.First();
            r3 = DS.account_accruedcost.First();


            var filter = r.childs(DS.config);

            filter = filter._Filter(fi => fi.ayear == 2016);
            Assert.AreEqual(filter.ToArray().Length, 1);
            Assert.AreEqual(filter.ToArray()[0].ayear, (short)2016); //prendo == 2016

            filter = r.childs(DS.config);
            filter = filter._Filter(fi => fi.ayear == null);
            Assert.AreEqual(filter.ToArray().Length, 0);

            filter = r.childs(DS.config);
            filter = filter._Filter(fi => fi.agencycode == null);
            Assert.AreEqual(filter.ToArray().Length, 3);
            Assert.IsNull(filter.ToArray()[0].agencycode); // == null

            filter = DS.account.ToArray()[2].childs(DS.config);
            Assert.AreEqual(filter._IsEmpty(), true);
            Assert.AreEqual(filter._HasRows(), false);
            filter = filter._Filter(fi => fi.agencycode == null);
            Assert.AreEqual(filter.ToArray().Length, 0);


            var reject = r.childs(DS.config);
            reject = reject._Reject(rej => rej.ayear == 2016);
            Assert.AreEqual(reject.ToArray()[0].ayear, (short)2017);
            Assert.AreEqual(reject.ToArray()[0].ayear, reject.ToArray()[1].ayear); //prendo != 2016

            Assert.IsNotNull(reject.ToArray()[0].ayear); // != null and != DBNull and != ""
            Assert.AreNotEqual((reject.ToArray()[0].ayearValue), DBNull.Value);
            //Assert.AreEqual(BorderLine(reject.ToArray()[0].ayearOriginal), 8);
            //Il metodo di test testParentChildRelated.UnitTest1.TestParent ha generato un'eccezione: 
            //System.Data.VersionNotFoundException: Nessun dato originale a cui accedere.

            Assert.IsNull(reject.ToArray()[0].balancekind);

            reject = r.childs(DS.config);
            reject = reject._Reject(rej => rej.ayear == null);
            Assert.AreEqual(reject.ToArray()[0].ayear, (short)2017);
            Assert.AreEqual(reject.ToArray()[0].ayear, reject.ToArray()[1].ayear); //prendo != null

            reject = DS.account.ToArray()[2].childs(DS.config);
            Assert.AreEqual(reject._IsEmpty(), true);
            Assert.AreEqual(reject._HasRows(), false);
            reject = reject._Reject(fi => fi.agencycode == null);
            Assert.AreEqual(reject.ToArray().Length, 0);
            Assert.AreEqual(reject._IsEmpty(), true);
            Assert.AreEqual(reject._HasRows(), false);


            var found = r.childs(DS.config)._Find(fin => fin.ayear == (short)2016);
            Assert.AreNotEqual(found.ayear, (short)2017);
            Assert.AreEqual(found.ayear, (short)2016); //come atteso found. ci fa vedere i campi, ed è una sola riga
            Assert.IsNotNull(found.ayear);
            Assert.IsNotNull(found.ayearValue);

            var childs = DS.account._Find(fin => fin.idacc == "ID2").childs(DS.config);
            Assert.AreEqual(childs.ToArray().Length, 1); //come atteso è 1
            Assert.AreEqual(childs.ToArray()[0].ayear, (short)2016); //come atteso found. ci fa vedere i campi, ed è una sola riga
            Assert.IsNotNull(childs.ToArray()[0].ayear); // != null
            Assert.IsNotNull(childs.ToArray()[0].ayearValue); // != null

            var found2 = DS.account.ToArray()[2].childs(DS.config);
            Assert.AreEqual(found2._IsEmpty(), true);
            var found3 = found2._Find(fin => fin.ayear == (short)2016);
            Assert.IsNull(found3);

            //if (cboTipo.SelectedIndex <= 0) return 1;
            //var found = DS.invoicekindregisterkind.f_Eq("idinvkind", cboTipo.SelectedValue)
            //        .Join(DS.ivaregisterkind, (r1, r2) => r1["idivaregisterkind"].Equals(r2.idivaregisterkindValue)
            //                                                 && r2.registerclass.ToUpper() != "P")
            //                .FirstOrDefault()?.Item2.flagactivity;
            //return found.HasValue ? (int)found : 1;

            //var x = DS.assetload._joinAs("al")
            //        .join(DS.assetacquireview._as("as"), on: q.eqf("al.nassetload", "as.nassetload"))
            //        .join(DS.registry._as("reg"), on: q.eqf("reg.idreg", "as.idreg"))
            //        .join(DS.assetloadkind._as("alk"), on: q.eqf("alk.idassetloadkind", "al.idassetloadkind"));



            var join1 = DS.account.Join(DS.config, (table1, table2) => table1["idacc"].Equals(table2.idacc_plValue));

            var leftjoin1 = DS.account.LeftJoin(DS.config, (table1, table2) => table1["idacc"].Equals(table2.idacc_plValue));         

            var joina1 = DS.account._joinAs("acc").join(DS.config._as("con"), on: q.eqf("acc.idacc", "con.idacc_pl"));



            Assert.IsNotNull(join1);
            if (join1._HasRows()) {
                Assert.AreEqual(join1.ToArray()[0].Item1.ayear, (short)2017);
                Assert.AreEqual(join1.ToArray()[0].Item1.idaccValue, join1.ToArray()[0].Item2.idacc_plValue);
                Assert.AreEqual(4,join1.Count());
            }

            Assert.IsNotNull(leftjoin1);
            if (leftjoin1._HasRows()) {
                Assert.AreEqual(leftjoin1.ToArray()[0].Item1.ayearValue, (short)2017);
                Assert.AreEqual(5, leftjoin1.Count());
            }


            Assert.IsNotNull(joina1);



            DS.Clear();

            createRow(DS.account, new string[] { "idacc", "ID1", "ayear", "2017", "codeacc", "C1" });
            createRow(DS.account, new string[] { "idacc", "ID2", "ayear", "2017", "codeacc", "C1" });
            createRow(DS.account, new string[] { "idacc", "ID3", "ayear", "2017", "codeacc", "C1" });

            //CI METTIAMO IN UN CASO ESTREMO DOVE CONFIG é VUOTA (config è la table 2 nelle espressioni)

            var join2 = DS.account.Join(DS.config, (table1, table2) => table1["idacc"].Equals(table2.idacc_plValue));

            var leftjoin2 = DS.account.LeftJoin(DS.config, (table1, table2) => table1["idacc"].Equals(table2.idacc_plValue));

            Assert.IsNotNull(join2);  //L'assert riesce quindi join non è null, ma attenzione non contiene righe
            if (join2._HasRows()) {
                Assert.AreEqual(join2.ToArray()[0].Item1.ayear, (short)2017);
                Assert.AreEqual(join2.ToArray()[0].Item1.idaccValue, join1.ToArray()[0].Item2.idacc_plValue);
                Assert.AreEqual(4, join2.Count());
            }

            Assert.IsNotNull(leftjoin2);
            if (leftjoin2._HasRows()) {
                Assert.AreEqual(leftjoin2.ToArray()[0].Item1.ayearValue, (short)2017);
                Assert.AreEqual(3, leftjoin2.Count());
            }


            DS.Clear();
            //CI METTIAMO IN UN CASO ESTREMO DOVE SIA ACCOUNT (table1) CHE CONFIG (table2) SONO VUOTE

            join2 = DS.account.Join(DS.config, (table1, table2) => table1["idacc"].Equals(table2.idacc_plValue));

            leftjoin2 = DS.account.LeftJoin(DS.config, (table1, table2) => table1["idacc"].Equals(table2.idacc_plValue));

            Assert.IsNotNull(join2);
            if (join2._HasRows()) {
                Assert.AreEqual(join2.ToArray()[0].Item1.ayear, (short)2017);
                Assert.AreEqual(join2.ToArray()[0].Item1.idaccValue, join1.ToArray()[0].Item2.idacc_plValue);
                Assert.AreEqual(4, join2.Count());
            }

            Assert.IsNotNull(leftjoin2);
            if (leftjoin2._HasRows()) {
                Assert.AreEqual(leftjoin2.ToArray()[0].Item1.ayearValue, (short)2017);
                Assert.AreEqual(3, leftjoin2.Count());
            }

            //UN APPUNTO:
            //se noi al posto di "if (join2._HasRows())" avessimo messo "if (join2 != null)" saremmo entrati nell'if
            //e avremmo avuto una eccezione!!


        }




        /// <summary>
        /// Restore DS to default value, 3 rows for account; 3 rows for account_accruedcost; 4 rows for config
        /// </summary>
        /// <param name="DS"></param>
        private void restoreDataset(dsmeta DS) {
            //MODIFICARE IL NUMERO DI RIGHE O I VALORI DI QUESTE POTREBBE FAR FALLIRE ALCUNI DEI TEST.
            //VALORIZZARE ALTRE COLONNE NON DOVREBBE AVERE EFFETTO SUGLI ASSERT PRESENTI

            DS.Clear();

            createRow(DS.account, new string[] { "idacc", "ID1", "ayear", "2017", "codeacc", "C1" });
            createRow(DS.account, new string[] { "idacc", "ID2", "ayear", "2017", "codeacc", "C1" });
            createRow(DS.account, new string[] { "idacc", "ID3", "ayear", "2017", "codeacc", "C1" });

            createRow(DS.account_accruedcost, new string[] { "idacc", "ID4", "ayear", "2017", "codeacc", "C1" });
            createRow(DS.account_accruedcost, new string[] { "idacc", "ID5", "ayear", "2017", "codeacc", "C1" });
            createRow(DS.account_accruedcost, new string[] { "idacc", "ID6", "ayear", "2017", "codeacc", "C1" });


            createRow(DS.config, new string[] { "ayear", "2017", "idacc_pl", "ID1", "idacc_accruedcost", "ID4" });
            createRow(DS.config, new string[] { "ayear", "2017", "idacc_pl", "ID1", "idacc_accruedcost", "ID4" });
            createRow(DS.config, new string[] { "ayear", "2016", "idacc_pl", "ID1", "idacc_accruedcost", "ID4" });
            createRow(DS.config, new string[] { "ayear", "2016", "idacc_pl", "ID2", "idacc_accruedcost", "ID5" });           
        }





        /// <summary>
        /// Insert column and value in a new row in a DataTable
        /// </summary>
        /// <param name="DsTable"></param>
        /// <param name="nomecolonna/valore"></param>
        private void createRow(DataTable DsTable,string[] colnamevalue) {

            DataTable dt = DsTable;

            DataRow dr = dt.NewRow();
            for (int i = 0; i < colnamevalue.Length; i+=2) {
                dr[colnamevalue[i]] = colnamevalue[i+1];
            }
            dt.Rows.Add(dr);


        }

    }
}
