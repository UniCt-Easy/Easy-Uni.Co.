
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
using System.Linq;
using System.Xml;
using DBConn;
using metaeasylibrary;

namespace viste {
    [TestClass]
    public class TestViste {
        static DataAccess conn;
        static QueryHelper QHS;

        [ClassInitialize]
        public static void testInit(TestContext tc) {
            conn = DbConn.getEasyAccess(DateTime.Now.Year, DateTime.Now,"test");

            if (conn==null) {
                return;
            }
            QHS = conn.GetQueryHelper();

        }

        [ClassCleanup]
        public static void testEnd() {
            conn?.Destroy();
        }

        [TestMethod]
        public void integritaCustomObject() {

            DataTable t = conn.RUN_SELECT("customobject", "*", null, QHS.CmpEq("isreal", "N"), null, false);
            DataTable sys = conn.SQLRunner("select * from sysobjects where xtype='V'", false);
            Assert.IsNotNull(t, "customobject esiste");
            Dictionary<string,bool> ex = new Dictionary<string, bool>();
            foreach (DataRow  v1 in t.Rows) {
                bool found = false;
                string v1Name = v1["objectname"].ToString().ToLower();
                Assert.IsFalse(ex.ContainsKey(v1Name),$"{v1Name} presente due volte in customobject");
                ex[v1Name] = true;
                foreach (DataRow v2 in sys.Rows) {
                    string v2Name = v2["name"].ToString();
                    if (v1Name == v2Name) {
                        found = true;
                        break;
                    }
                }
                Assert.IsTrue(found, "La vista " + v1Name + " non esiste in sysobjects.");
            }
            Dictionary<string,bool> ex2 = new Dictionary<string, bool>();
            foreach (DataRow v1 in sys.Rows) {                
                string v1Name = v1["name"].ToString().ToLower();
                Assert.IsFalse(ex2.ContainsKey(v1Name),$"{v1Name} presente due volte in sysobjects");
                ex2[v1Name] = true;
                Assert.IsTrue(ex.ContainsKey(v1Name),$"{v1Name} non presente in customobject");
                
            }
            Assert.AreEqual(sys.Rows.Count, t.Rows.Count,
                "Le viste di customobject sono tante quanto quelle presenti in sysobjects");
        }

        [TestMethod]
        public void integritaViste() {
            DataTable t = conn.RUN_SELECT("customobject", "*", null, QHS.CmpEq("isreal", "N"), null, false);
            Assert.AreNotEqual(0,t.Rows.Count,"Elenco customobject vuoto");
            List<string> elencoVisteErrate = new List<string>();
            foreach (DataRow r in t.Rows) {
                string v1Name = r["objectname"].ToString();
                string sql = "select top 5 * from " + v1Name;
                if (v1Name == "expensecreditproceedsview") sql += $" where ayear={conn.GetEsercizio()}";
                DataTable v = conn.SQLRunner(sql, true,600);
                if (v == null) {                    
                    elencoVisteErrate.Add(v1Name);
                }
                //Assert.IsNotNull(v, "La vista " + v1Name + " viene eseguita senza errori");
            }
            string elenco= string.Join(",",elencoVisteErrate.ToArray());
            Assert.AreEqual("",elenco,"Elenco viste errate vuoto");
        }
    }
}
