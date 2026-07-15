/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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
using NUnit.Framework;
using metadatalibrary;
using metaeasylibrary;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using q = metadatalibrary.MetaExpression;
using System.Linq;

namespace test {
    [TestFixture]
    public class testWithDatabase {
        
        public static Easy_DataAccess Conn;
        static QueryHelper QHS;
        [OneTimeSetUp]
        public static void testInit() {
          
        }
        [OneTimeTearDown]
        public static void testEnd() {
            
        }
        [Test]
        public void getAllSecurity() {
            Conn = dbutils.getEasyDataAccess("utente2");
            QHS = Conn.GetQueryHelper();
            DataTable allRoles = Conn.readFromTable("flowchartuser",
                            q.like("idflowchart","18%") & q.eq("idcustomuser","bianco"));
            Dictionary<string,q> allExpr= new Dictionary<string, q>();
            var qh = new CQueryHelper();
            var sec = Conn.Security;

            foreach (DataRow rr in allRoles.Rows) {
                //Conn.SetSys("idflowchart",);
                //Conn.SetSys("ndetail",);
                //Conn.RecalcUserEnvironment();
                //Conn.ReadAllGroupOperations();
                Conn.ChangeFlowChart(rr["idflowchart"],rr["ndetail"]);
                DataTable tSec = Conn.readFromTable("securitycondition", (q)null, "*", null, null);
                int nException = 0;
                foreach (string sKind in new string[] { "I", "U", "S", "D", "P" }) {
                    foreach (DataRow r in tSec.Rows) {
                        DataTable t = Conn.CreateTableByName(r["tablename"].ToString(), "*");
                        var s = sec.postingCondition(t, sKind);//new DataTable(r["tablename"].ToString()
                        if (s == null) continue;
                        s = s.ToLower();
                        if (allExpr.ContainsKey(s))continue;
                        allExpr[s] = MetaExpressionParser.From(s);
                        if (allExpr[s] == null) continue;
                        var toC = allExpr[s].toSql(qh);
                        try {
                            var sel = t.Select(toC);
                        }
                        catch (Exception e) {
                            QueryCreator.MarkEvent($"tablename:{t.TableName} {toC}");
                            QueryCreator.MarkEvent(e.ToString());
                            nException++;
                        }
                        //Assert.AreEqual(s_i,stringFilter);
                    }
                }
                Assert.AreEqual(0,nException);
            }
            foreach (string s in allExpr.Keys) {

                string stringFilter =  allExpr[s]?.toSql(qh, sec);
                QueryCreator.MarkEvent(s);
                QueryCreator.MarkEvent(stringFilter??"stringa vuota");
                QueryCreator.MarkEvent($"///////////////////////////////////////////////");
            }
            Conn.Destroy();

        }
    }
}
