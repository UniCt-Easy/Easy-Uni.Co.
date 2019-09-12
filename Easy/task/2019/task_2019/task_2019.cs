/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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

ï»¿using System;
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

namespace task_2019 {
    [TestClass]
    public class task_1000 {
        private static  testE2EMainHelper tester;
        [ClassInitialize]
        public static void testInitialize(TestContext t) {
            tester= new testE2EMainHelper();
        }

        [ClassCleanup]
        public static void testEnd() {
            tester.close();
        }

        [TestMethod]
        public void TestMethod1() {
        }
    }
}
