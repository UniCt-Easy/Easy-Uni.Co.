
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
using System.Reflection;
using System.Threading;
using System.Xml;
using q = metadatalibrary.MetaExpression;
using mainform;
using System.Windows.Forms;
using helpMain = TestHelper.testE2EMainHelper;
using TestHelper;
using DBConn;
using System.Diagnostics;
using Xceed.Zip;
using Xceed.FileSystem;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections;
using System.Security.Cryptography;
using LiveUpdate;

namespace task_2019 {
    [TestClass]
    public class task_no_e2e {
        static void initLicenses() {
            string txtFile = "";
            string currdir = AppDomain.CurrentDomain.BaseDirectory;
            if (!currdir.EndsWith("\\")) currdir += "\\";
            string licFileName = Path.Combine(currdir, "licenses.dat");
            if (File.Exists(licFileName)) {
                var b = File.ReadAllBytes(licFileName);
                var c = DataAccess.DecryptBytes(b);
                txtFile = UTF32Encoding.UTF8.GetString(c).Trim();
            }
            else {
                //txtFile ="Grid;GGGG-GGGG-GGGG-GGGG|Editors;EEEE-EEEE-EEEE-EEEE|Zip;ZZZZZZZZZZZZZZZZZZZ|Ftp;FFFFFFFFFFFFFFFFFFF";
                //var c = DataAccess.CryptBytes(UTF32Encoding.UTF8.GetBytes(txtFile));
                //File.WriteAllBytes(licFileName, c);
            }

            var couples = txtFile.Split('|');
            foreach (var cc in couples) {
                var kv = cc.Split(';');
                if (kv[0] == "Zip") Xceed.Zip.Licenser.LicenseKey = kv[1];
            }

        }

        [ClassInitialize]
        public static void testInitialize(TestContext t) {
            initLicenses();
        }

        void writeRandomDataToFile(AbstractFile f) {
            var S = f.OpenWrite(true);
            S.Write(new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 0, 8);

            S.Close();
        }

        [TestMethod]
        public void testZipCaseSensitive() {
            string filenamezip = "testArchive.zip";
            if (File.Exists(filenamezip)) File.Delete(filenamezip);
            AbstractFile tempZipFile = new DiskFile(filenamezip);
            ZipArchive zip = new ZipArchive(tempZipFile);
            var f_a_txt = zip.CreateFile("a.txt", false);
            writeRandomDataToFile(f_a_txt);
            var f_A_txt = zip.CreateFile("A.txt", true);
            writeRandomDataToFile(f_A_txt);
            var f_a_TXT = zip.CreateFile("a.TXT", true);
            writeRandomDataToFile(f_a_TXT);

            Assert.AreEqual(1, zip.GetFiles(false, "*.*").Length, "Creato 1 file nello zip");
        }
    }

    /// <summary>
    /// Voglio verificare quanto tempo ci voglia a craccare una password per accertarmi che
    ///  non sia troppo poco.
    /// </summary>
    [TestClass]
    public class task_bruteforce {
        private static testE2EMainHelper tester;

        [ClassInitialize]
        public static void testInitialize(TestContext t) {
            tester = new testE2EMainHelper();
        }

        [ClassCleanup]
        public static void testEnd() {
            tester.close();
        }


        public void testCrackTime() {
            /**
             *
             * 
per ottenere alfa1
password db criptata = CryptString(depPassword.PadRight(31));
questo è uguale a  alpha xor alpha1
quindi alfa  = CryptString(depPassword.PadRight(31)) xor alpha1
dove alpha1 sta nel dbaccess dell'utente
e alfa è SHA256.Create().ComputeHash(Encoding.Default.GetBytes(userPassword));	
quindi proviamo tutte le password sino  a trovarne una tale che 
	SHA256.Create().ComputeHash(Encoding.Default.GetBytes(userPassword)) = aphpa cosi determinato
	
	

             */
            List<byte[]> alfas = new List<byte[]>();
            List<string> logins = new List<string>();
            var conn = tester.getProp("MyDataAccess") as DataAccess;
            var dbaccess = conn.RUN_SELECT("dbaccess", "*", null, null, null, false);
            var dbpwd = conn.GetSys("ML.NeveAGenova") as string;
            var cryptDBPwd = DataAccess.CryptString(dbpwd.PadRight(31));
            Dictionary<string, string> passwordfound = new Dictionary<string, string>();
            var sb = new StringBuilder();
            HashSet<string> added = new HashSet<string>();
            foreach (DataRow r in dbaccess.Rows) {
                if (added.Contains(r["alpha1"].ToString())) continue;
                added.Add(r["alpha1"].ToString());
                var alfa1 = QueryCreator.StringToByteArray(r["alpha1"].ToString());
                var alfa = xor(cryptDBPwd, alfa1);
                sb.AppendLine(QueryCreator.ByteArrayToString(alfa));
                alfas.Add(alfa);
                logins.Add(r["login"].ToString());
            }

            var sha = SHA256.Create();

            string pwd = "";
            List<byte> codes = new List<byte>();
            pwd = nextCombination(pwd, codes);
            bool found = false;
            int index = -1;
            List<string> toRemove = new List<string>();
            while (!found) {
                var tocheck = new List<string>() { pwd }; //generatevariants(pwd);
                foreach (var pp in tocheck) {
                    var hash = sha.ComputeHash(Encoding.Default.GetBytes(pp));

                    foreach (var a in alfas) {
                        if (a.SequenceEqual(hash)) {
                            index = alfas.IndexOf(a);
                            passwordfound[logins[index]] = pp;
                            toRemove.Add(logins[index]);

                        }
                    }

                    if (toRemove.Count > 0) {
                        foreach (var t in toRemove) {
                            index = logins.IndexOf(t);
                            logins.RemoveAt(index);
                            alfas.RemoveAt(index);
                        }

                        toRemove.Clear();
                        found = logins.Count == 0;
                    }

                }



                pwd = nextCombination(pwd, codes);
            }

            Assert.AreNotEqual(-1, index);
        }

        List<string> generatevariants(string s) {
            var list = new List<string>();
            list.Add(s);
            list.Add(s.ToUpperInvariant());

            //Aggiunge sino a 4 cifre in fondo ad s
            for (int i = 0; i <= 9; i++) {
                list.Add(s + "0" + i.ToString());
            }

            for (int i = 0; i <= 9; i++) {
                list.Add(s.ToUpperInvariant() + "0" + i.ToString());
            }

            for (int i = 0; i <= 99; i++) {
                list.Add(s + i.ToString());
            }

            for (int i = 0; i <= 99; i++) {
                list.Add(s.ToUpperInvariant() + i.ToString());
            }

            //Aggiunge sino a 4 cifre in fondo ad s
            for (int i = 1950; i <= 2020; i++) {
                list.Add(s + i.ToString());
            }

            for (int i = 1950; i <= 2020; i++) {
                list.Add(s.ToUpperInvariant() + i.ToString());
            }

            var list2 = new List<string>();
            foreach (var l in list) {
                list2.Add(l);
                var l2 = l.Replace("A", "4").Replace("E", "3").Replace("o", "0").Replace("O", "0")
                    .Replace("I", "1");
                if (l2 != l) list2.Add(l2);
            }

            return list2;
        }

        //public static string VALID_PWD_CHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz;,:.-_'?!*$";
        //private static string pad = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";
        public static string VALID_PWD_CHARS = "abcdefghijklmnopqrstuvwxyz";
        private static string pad = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

        string nextCombination(string r, List<byte> codes) {
            int rLen = r.Length;
            for (int i = 0; i < rLen; i++) {
                if (codes[i] < VALID_PWD_CHARS.Length - 1) {
                    codes[i]++;
                    string left = (i < rLen ? r.Substring(0, rLen - i - 1) : "");
                    string right = pad.Substring(0, i);
                    return left + VALID_PWD_CHARS[codes[i]] + right;
                }

                codes[i] = 0;
            }

            codes.Add(0);
            return VALID_PWD_CHARS[0] + pad.Substring(0, rLen);
        }



        /// <summary>
        /// Esegue lo XOR tra due array di byte
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static byte[] xor(byte[] a, byte[] b) {
            BitArray orEsclusivo = new BitArray(a).Xor(new BitArray(b));
            byte[] result = new byte[32];
            orEsclusivo.CopyTo(result, 0);
            return result;
        }
    }

    [TestClass]
    public class task_cleanup_updateconfig {
        DataTable testConfig;
        string[] testEndpoints;

        public void data_initialize_DRemptyARR0length() {

            testConfig = new DataTable("configtable");

            testConfig.Columns.Add("localreportdir");
            testConfig.Columns.Add("httpupdatepath");
            testConfig.Columns.Add("httpupdatepath2");
            testConfig.Columns.Add("httpupdatepath3");

            DataRow testEntry = testConfig.NewRow();

            testEntry["localreportdir"] = "";
            testEntry["httpupdatepath"] = "";
            testEntry["httpupdatepath2"] = "";
            testEntry["httpupdatepath3"] = "";

            testConfig.Rows.Add(testEntry);

            testEndpoints = new string[] {
            };
        }

        public void data_initialize_DRemptyARRmore() {

            testConfig = new DataTable("configtable");

            testConfig.Columns.Add("localreportdir");
            testConfig.Columns.Add("httpupdatepath");
            testConfig.Columns.Add("httpupdatepath2");
            testConfig.Columns.Add("httpupdatepath3");

            DataRow testEntry = testConfig.NewRow();

            testEntry["localreportdir"] = "";
            testEntry["httpupdatepath"] = "";
            testEntry["httpupdatepath2"] = "";
            testEntry["httpupdatepath3"] = "";

            testConfig.Rows.Add(testEntry);

            testEndpoints = new string[] {
                "https://google.com",
                "http://www.microsoft.com/",
                "https://apple.com",
                "https://golang.org/"
            };
        }

        public void data_initialize_DRmixedARRmore() {

            testConfig = new DataTable("configtable");

            testConfig.Columns.Add("localreportdir");
            testConfig.Columns.Add("httpupdatepath");
            testConfig.Columns.Add("httpupdatepath2");
            testConfig.Columns.Add("httpupdatepath3");

            DataRow testEntry = testConfig.NewRow();

            testEntry["localreportdir"] = "C:\\";
            testEntry["httpupdatepath"] = "http://temposrl.com";
            testEntry["httpupdatepath2"] = "test";
            testEntry["httpupdatepath3"] = "https://temposrl.com";

            testConfig.Rows.Add(testEntry);

            testEndpoints = new string[] {
                "https://google.com",
                "http://www.microsoft.com/",
                "https://apple.com",
                "https://golang.org/"
            };
        }

        public void data_initialize_DRalllocalARRmore() {

            testConfig = new DataTable("configtable");

            testConfig.Columns.Add("localreportdir");
            testConfig.Columns.Add("httpupdatepath");
            testConfig.Columns.Add("httpupdatepath2");
            testConfig.Columns.Add("httpupdatepath3");

            DataRow testEntry = testConfig.NewRow();

            testEntry["localreportdir"] = "C:\\";
            testEntry["httpupdatepath"] = "D:\\";
            testEntry["httpupdatepath2"] = "test1";
            testEntry["httpupdatepath3"] = "test2";

            testConfig.Rows.Add(testEntry);

            testEndpoints = new string[] {
                "https://google.com",
                "http://www.microsoft.com/",
                "https://apple.com",
                "https://golang.org/"
            };
        }

        public void data_initialize_DRallwebARRmore() {

            testConfig = new DataTable("configtable");

            testConfig.Columns.Add("localreportdir");
            testConfig.Columns.Add("httpupdatepath");
            testConfig.Columns.Add("httpupdatepath2");
            testConfig.Columns.Add("httpupdatepath3");

            DataRow testEntry = testConfig.NewRow();

            testEntry["localreportdir"] = "C:\\";
            testEntry["httpupdatepath"] = "http://example.com";
            testEntry["httpupdatepath2"] = "http://example.com";
            testEntry["httpupdatepath3"] = "https://example.com";

            testConfig.Rows.Add(testEntry);

            testEndpoints = new string[] {
                "https://google.com",
                "http://www.microsoft.com/",
                "https://apple.com",
                "https://golang.org/"
            };
        }


        [TestMethod]
        public void test_cleanup_DRemptyARR0length() {
            data_initialize_DRemptyARR0length();
            DataRow testRow = testConfig.Rows[0];

            Http.CleanupUpdateConfig(testRow, testEndpoints);

            Assert.AreEqual("", testRow["localreportdir"], "localreportdir KO");
            Assert.AreEqual("", testRow["httpupdatepath"], "httpupdatepath KO");
            Assert.AreEqual("", testRow["httpupdatepath2"], "httpupdatepath2 KO");
            Assert.AreEqual("", testRow["httpupdatepath3"], "httpupdatepath3 KO");
        }

        [TestMethod]
        public void test_cleanup_DRemptyARRmore() {
            data_initialize_DRemptyARRmore();
            DataRow testRow = testConfig.Rows[0];

            Http.CleanupUpdateConfig(testRow, testEndpoints);

            Assert.AreEqual("https://google.com", testRow["localreportdir"], "localreportdir KO");
            Assert.AreEqual("http://www.microsoft.com/", testRow["httpupdatepath"], "httpupdatepath KO");
            Assert.AreEqual("https://apple.com", testRow["httpupdatepath2"], "httpupdatepath2 KO");
            Assert.AreEqual("https://golang.org/", testRow["httpupdatepath3"], "httpupdatepath3 KO");
        }

        [TestMethod]
        public void test_cleanup_DRmixedARRmore() {

            data_initialize_DRmixedARRmore();
            DataRow testRow = testConfig.Rows[0];

            Http.CleanupUpdateConfig(testRow, testEndpoints);

            Assert.AreEqual("C:\\", testRow["localreportdir"], "localreportdir KO");
            Assert.AreEqual("https://google.com", testRow["httpupdatepath"], "httpupdatepath KO");
            Assert.AreEqual("test", testRow["httpupdatepath2"], "httpupdatepath2 OK");
            Assert.AreEqual("http://www.microsoft.com/", testRow["httpupdatepath3"], "httpupdatepath3 KO");
        }

        [TestMethod]
        public void test_cleanup_DRalllocalARRmore() {
            data_initialize_DRalllocalARRmore();
            DataRow testRow = testConfig.Rows[0];

            Http.CleanupUpdateConfig(testRow, testEndpoints);

            Assert.AreEqual("C:\\", testRow["localreportdir"], "localreportdir KO");
            Assert.AreEqual("D:\\", testRow["httpupdatepath"], "httpupdatepath KO");
            Assert.AreEqual("test1", testRow["httpupdatepath2"], "httpupdatepath2 KO");
            Assert.AreEqual("test2", testRow["httpupdatepath3"], "httpupdatepath3 KO");
        }

        [TestMethod]
        public void test_cleanup_DRallwebARRmore() {
            data_initialize_DRallwebARRmore();
            DataRow testRow = testConfig.Rows[0];

            Http.CleanupUpdateConfig(testRow, testEndpoints);

            Assert.AreEqual("C:\\", testRow["localreportdir"], "localreportdir KO");
            Assert.AreEqual("https://google.com", testRow["httpupdatepath"], "httpupdatepath KO");
            Assert.AreEqual("http://www.microsoft.com/", testRow["httpupdatepath2"], "httpupdatepath2 KO");
            Assert.AreEqual("https://apple.com", testRow["httpupdatepath3"], "httpupdatepath3 KO");
        }

    }

    [TestClass]
    public class task_cleanup_urlsarray {
        string[] testUrls;
        string[] resultUrls;
        int resultUrlsCount;

        public void data_initialize_ARR0length() {
            testUrls = new string[] {
            };
            resultUrlsCount = 0;
		}

        public void data_initialize_ARRallOK() {
            testUrls = new string[] {
                "https://google.com",
                "http://www.microsoft.com/",
                "https://apple.com"
            };
            resultUrlsCount = 3;
		}

        public void data_initialize_ARRallKO() {
            testUrls = new string[] {
                "<html>",
                "<head>",
                "test//",
                "//errato"
            };
            resultUrlsCount = 0;
        }

        public void data_initialize_ARRmixed() {
            testUrls = new string[] {
                "https://google.com",
                "<head>",
                "http://www.microsoft.com/",
                "//errato"
            };
            resultUrlsCount = 2;
        }

        [TestMethod]
        public void test_cleanup_ARR0length() {
            data_initialize_ARR0length();

            resultUrls = Http.CleanupUrlsArray(testUrls);

            for (int i = 0; i < resultUrls.Length; i++) {
                Uri tmp = new Uri(resultUrls[i]);

                Assert.IsTrue(tmp.Scheme == Uri.UriSchemeHttp || tmp.Scheme == Uri.UriSchemeHttps, tmp.ToString());
                Assert.IsTrue(resultUrls.Length == resultUrlsCount);
            }
        }

        [TestMethod]
        public void test_cleanup_ARRallOK() {
            data_initialize_ARRallOK();

            resultUrls = Http.CleanupUrlsArray(testUrls);

            for (int i = 0; i < resultUrls.Length; i++) {
                Uri tmp = new Uri(resultUrls[i]);

                Assert.IsTrue(tmp.Scheme == Uri.UriSchemeHttp || tmp.Scheme == Uri.UriSchemeHttps, tmp.ToString());
                Assert.IsTrue(resultUrls.Length == resultUrlsCount);
            }
        }

        [TestMethod]
        public void test_cleanup_ARRallKO() {
            data_initialize_ARRallKO();

            resultUrls = Http.CleanupUrlsArray(testUrls);

            for (int i = 0; i < resultUrls.Length; i++) {
                Uri tmp = new Uri(resultUrls[i]);

                Assert.IsTrue(tmp.Scheme == Uri.UriSchemeHttp || tmp.Scheme == Uri.UriSchemeHttps, tmp.ToString());
                Assert.IsTrue(resultUrls.Length == resultUrlsCount);
            }
        }

        [TestMethod]
        public void test_cleanup_ARRmixed() {
            data_initialize_ARRmixed();

            resultUrls = Http.CleanupUrlsArray(testUrls);

            for (int i = 0; i < resultUrls.Length; i++) {
                Uri tmp = new Uri(resultUrls[i]);

                Assert.IsTrue(tmp.Scheme == Uri.UriSchemeHttp || tmp.Scheme == Uri.UriSchemeHttps, tmp.ToString());
                Assert.IsTrue(resultUrls.Length == resultUrlsCount);
            }
        }
    }
}
