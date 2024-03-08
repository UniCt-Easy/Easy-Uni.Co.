
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
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using metadatalibrary;
using System.Data;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Xml;
using q = metadatalibrary.MetaExpression;
using System.Windows.Forms;
using GeneraLiveUpdateForServices;
using LiveUpdate;
using System.IO;
using System.Linq;
using System.Net;

namespace testService {
    [TestClass]
    public class UnitTest1 {
        private Frm_GeneraLiveUpdateForServices f;
        [TestInitialize]
        public void testInitialize() {
           
        }

        [TestMethod]
        public void testCreateIndex_fileExist() {
            GenXML.AzzeraIndicelocale();
            string path = AppDomain.CurrentDomain.BaseDirectory;
            var parentPath = "D:\\Easy";
            string folderToScan = Path.Combine(parentPath, "abatableexpense");
            var subDir = new string[] {
                "abatableexpense_contrattodetail", "meta_abatableexpense",
                "abatableexpense\\meta_abatableexpense\\bin\\Debug",
                "abatableexpense\\abatableexpense_contrattodetail\\bin\\Debug",
                "abatableexpense_contrattodetail\\abatableexpense_contrattodetail\\bin\\Debug",
                "abatableexpense_contrattodetail\\meta_abatableexpense\\bin\\Debug",
            };
            var filesToSkip = new Hashtable();
            var filter = new string[] {"*.*"};
            string error;
            var allowedExtensions = new string[] {".dll",".cs",".csproj",".xsd",".pdb"}.ToList();
            bool res = GenXML.GeneraFileIndiceGenerico(folderToScan, "indice", subDir, filesToSkip, 
                    filter, allowedExtensions, false, out error);
            string destFileName = Path.Combine(folderToScan, "indice.zip");
            Assert.IsTrue(File.Exists(destFileName));
            destFileName = Path.Combine(folderToScan, "indice");
            Assert.IsTrue(File.Exists(destFileName));
            
        }
    }
}
