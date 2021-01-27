
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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using metadatalibrary;
using System.Data;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Xml;
using q=metadatalibrary.MetaExpression;
using mainform;
using System.Windows.Forms;
using helpMain= TestHelper.testE2EMainHelper;
using Timer = System.Windows.Forms.Timer;

namespace e2e {
   

    class formHook : Form {
        public int ncall = 0;
        private int msgCode;
        public formHook(int msgCode) {
            this.msgCode = msgCode;
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == msgCode)
            {
                // Call to your logic here
                ncall++;
            }
        }
    }
    class HookMessage {

    }

    [TestClass]
    public class testHook {
        [TestInitialize]
        public void testInitialize() {

        }
        
        [TestMethod]
        public void testSettext() {
            formHook f = new formHook(0x000C);
            Assert.AreEqual(0,f.ncall,  "Inizialmente nessuna call a setText");
            f.Show();
            Assert.AreEqual(0,f.ncall,  "Nessuna chiamata dopo Show()");
            f.Text = "pippo";
            Assert.AreEqual(1,f.ncall,  "Una chiamata dopo Text=");
            //var tt= new System.Threading.Timer((object ff) => {
                

            //},f,10,10);

            TestHelper.TestHelp.autoCloseByMessageTitle("title test", DialogResult.OK);
            var res=MessageBox.Show(f, "ciao", "title test",MessageBoxButtons.OKCancel);
            Assert.AreEqual(DialogResult.OK,res,"Inviato ok a maschera");
            
            TestHelper.TestHelp.autoCloseByMessageTitle("title test", DialogResult.Cancel);
            res=MessageBox.Show(f, "ciao", "title test",MessageBoxButtons.OKCancel);
            Assert.AreEqual(DialogResult.Cancel,res,"Inviato Cancel a maschera");

            //tt.Dispose();
            Assert.AreEqual(1,f.ncall,  "Una chiamata dopo MessageBox.Show");
            f.Close();
        }

       

        [TestMethod]
        public void testWindowCreate() {
            formHook f = new formHook(0x0001);
            Assert.AreEqual(0,f.ncall,  "Inizialmente nessuna call a setText");
            f.Show();
            Assert.AreEqual(1,f.ncall,  "Una chiamata dopo Show()");
            f.Text = "pippo";
            Assert.AreEqual(1,f.ncall,  "Una chiamata dopo Text=");
            TestHelper.TestHelp.autoCloseByMessageTitle("title2",DialogResult.Cancel);
            var res=MessageBox.Show(f, "ciao", "title2", MessageBoxButtons.OK);
            Assert.AreEqual(DialogResult.OK,res,"Inviato Cancel a maschera");
            Assert.AreEqual(1,f.ncall,  "Una chiamata dopo MessageBox.Show");
            f.Close();
        }

    }


}
