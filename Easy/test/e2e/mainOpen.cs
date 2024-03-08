
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
using System.Linq;
using System.Windows.Forms;
using helpMain = TestHelper.testE2EMainHelper;
using TestHelper;
using DBConn;
using System.Diagnostics;

namespace e2e {
    [TestClass]
    public class testMainCreation {       
        [TestInitialize]
        public void testInitialize() {
         
        }

        /// <summary>
        /// Verifica che il mainForm si riesca a creare e a chiudere
        /// </summary>
        [TestMethod]
        public void testCreate() {
            string[] parConn = DbConn.getParams("test");

            frmMain.argCopy = new string[] {"autostart", parConn[0], parConn[4], parConn[5],"31/12/2018","2018"};
            frmMain f = new frmMain();
            f.isUnderTest = true;
            f.Show();
            Assert.IsFalse(f.IsDisposed,$"Form {f.Name} already IsDisposed.");
            var isInited = (bool) f.GetType().GetField("isInited",BindingFlags.NonPublic|BindingFlags.Instance).GetValue(f);
            Assert.IsTrue(isInited,$"Form {f.Name} not isInited.");
            f.Close();
            f.Dispose();
            Assert.IsTrue(f.IsDisposed,$"Form {f.Name} not IsDisposed.");
        }


        /**
         *   public Easy_DataAccess MyDataAccess;
         *   public menuMaker MainMenuMaker;
         *   MyListener Debug.Listeners
         */
        /// <summary>
        /// Verifica che il mainForm quando si apre abbia una connessione funzionante
        /// </summary>
        [TestMethod]        
        public void testConnect() {                     
            string[] parConn = DbConn.getParams("test");
            frmMain.argCopy = new string[] {"autostart", parConn[0], parConn[4], parConn[5],"31/12/2018","2018"};

            frmMain f = new frmMain();
            f.isUnderTest = true;
            MethodInfo dynMethod = f.GetType().GetMethod("connect", BindingFlags.NonPublic | BindingFlags.Instance);
            dynMethod.Invoke(f, new object[] { });

            Assert.IsNotNull(f.MyDataAccess);
            Assert.IsNotNull(f.MyDataAccess.Security);
            f.Close();
            f.Dispose();
            Assert.IsNull(f.MyDataAccess);
        }

        [TestMethod]
        public void testMyListener() {
            frmMain f = new frmMain();
            f.isUnderTest = true;
            var ls = f.GetType().GetField("TS",BindingFlags.NonPublic|BindingFlags.Instance);
            var LS = ls.GetValue(f) as MyListener;
            //var LS = q.getField("TS",f) as MyListener;
            Assert.IsNotNull(LS);
            var err = LS.Errors.ToString();
            Assert.AreEqual("",err);
            f.Close();
            f.Dispose();
        }
    }



    [TestClass]
    public class testMainRun {

       
        MenuItem getMenuItem(string metadata, string edittype,Menu.MenuItemCollection menu) {
            foreach (MenuItem m in menu) {
                var el = m as Element;
                if (el != null) {
                    if (el.edittype == edittype && el.metadata == metadata) return m;
                }                
                if (m.MenuItems.Count > 0) {
                    MenuItem res = getMenuItem(metadata, edittype, m.MenuItems);
                    if (res != null) return res;
                }
            }

            return null;
        }
    

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
        public void testMainMenuMaker() {
            menuMaker menu = tester.getProp("MainMenuMaker") as menuMaker;
            Assert.IsNotNull(menu);
            Assert.IsTrue((bool) tester.getProp( "MenuIsCharged",menu));
            Assert.IsNotNull( tester.getProp("DS",menu) as DataSet);
            DataAccess conn = tester.getProp("MyDataAccess") as DataAccess;
            DataAccess menuConn= tester.getProp("DA",menu) as DataAccess;
            Assert.IsNotNull(conn);
            Assert.IsNotNull(menuConn);
            Assert.AreNotEqual(conn,menuConn);
            Assert.AreEqual(null,menuConn.LastError);            
        }

        [TestMethod]
        public void testMenu() {
            MainMenu menu  = tester.getProp("mainMenu1") as MainMenu;
            Assert.IsNotNull(menu);
            Assert.IsTrue(menu.MenuItems.Count>0);
        }

        string checkUniqueIndex(MetaTableUniqueIndex index, DataTable t) {
	        var fields = index.hash.keys;
	        string me = $"{t.TableName} unique index on fields " + string.Join(",", fields);
            //Check that all rows in tables are found in the index
            int nRealRow = 0;
            foreach (DataRow r in t.Select()) {
	            nRealRow++;
	            var rFound = index.getRow(index.hash.get(r));
	            if (rFound == null)
		            return $"Some row is not found in {me}";
                if (rFound!=r) return $"Wrong row found in {me}";
            }

            int nIndexedRow = 0;
            foreach (var r in index.lookup.Values) {
                if (r==null) return $"Disposed row found in {me}";
                if (r.RowState==DataRowState.Detached) return $"Detached row found  in {me}";
                if (r.RowState==DataRowState.Deleted) return $"Deleted row found  in {me}";
                nIndexedRow++;
            }

            if (nIndexedRow != nRealRow) return $"Expected {nRealRow} in index but {nIndexedRow} found in {me}";
	        return null;
        }
        string checkNotUniqueIndex(MetaTableNotUniqueIndex index, DataTable t) {
	        var fields = index.hash.keys;
	        string me = $"{t.TableName} not unique index on fields " + string.Join(",", fields);
	        //Check that all rows in tables are found in the index
	        int nRealRow = 0;
	        foreach (DataRow r in t.Select()) {
		        nRealRow++;
		        var rFound = index.getRows(index.hash.get(r));
		        if (rFound == null || rFound.Length == 0) {
			        return $"Some row is not found in {me}";
		        }
		        bool reallyFound = rFound._Filter(x=> x==r)._HasRows();
		        if (!reallyFound) {
			        return $"Some row found in {me}  but not the searched one.";
		        }
	        }
	        int nIndexedRow = 0;
	        foreach (var rList in index.lookup.Values) {
		        foreach (var r in rList) {
			        if (r == null) return $"Disposed row found in {me}";
			        if (r.RowState == DataRowState.Detached) return $"Detached row found  in {me}";
			        if (r.RowState == DataRowState.Deleted) return $"Deleted row found  in {me}";
			        nIndexedRow++;
		        }
	        }

	        if (nIndexedRow != nRealRow) return $"Expected {nRealRow} in index but {nIndexedRow} found in {me}";
	        return null;
        }
        
        string checkDataSetIndexes(DataSet d) {
	        var idm = d.getIndexManager();
	        if (idm == null) return "Index not found on Dataset in form ";

	        foreach (var idx in idm.getIndexes()) {
		        if (idx is MetaTableUniqueIndex) {
			        var result = checkUniqueIndex((MetaTableUniqueIndex) idx, d.Tables[idx.tableName]);
			        if (result != null) return result;
		        }
		        if (idx is MetaTableNotUniqueIndex) {
			        var result = checkNotUniqueIndex((MetaTableNotUniqueIndex) idx, d.Tables[idx.tableName]);
			        if (result != null) return result;
		        }

	        }
	        
	        return null;
        }
     
        public void onActivationForm(Form form) {
            Form main = tester.mainForm;
            if (form.IsMdiChild) {
                Assert.IsTrue(main.MdiChildren.Length > 0, "Form has been added to MDI childs");
                Assert.AreEqual(main.MdiChildren[0],form, "Form has been added to MDI childs");
            }
           
            tester.clearErrors();
            var ctrl = form.getInstance<IFormController>();
            Assert.IsNotNull(ctrl,"IFormController was found");
            var meta = form.getInstance<IMetaData>();
            Assert.IsNotNull(meta,"IMetaData was found");
            var DS = form.getInstance<DataSet>();
            Assert.IsNotNull(DS,"DataSet was found");
            Assert.IsTrue(DS.Tables.Contains(meta.TableName));
            var mainTable = DS.Tables[meta.TableName];
            var eventManager = form.getInstance<IFormEventsManager>();
            Assert.IsNotNull(eventManager,"IFormEventsManager was found");

            Assert.AreEqual(null, checkDataSetIndexes(ctrl.ds), $"activation Indexes of {meta.TableName}  {form.Name} are correct");

            
            string friendlyName=meta.getName();
            if (ctrl.isList && !meta.startEmpty) {
                Assert.AreEqual($"{friendlyName} (Modifica) ",form.Text);
                Assert.AreEqual(ctrl.EditMode,true);
            }
            else {
                Assert.AreEqual($"{friendlyName} (Ricerca) ",form.Text);
                Assert.AreEqual(ctrl.IsEmpty,true);
            }
            Application.DoEvents();
            
            Assert.IsTrue(ctrl.DrawStateIsDone,$"Form {meta.TableName}  {form.Name} initialized correctly");

            if (meta.canInsert) {
                ctrl.DoMainCommand("maininsert");
                Application.DoEvents();
                Assert.AreEqual(ctrl.InsertMode, true, $"{form.Name} got insert mode");
                Assert.AreEqual(null, checkDataSetIndexes(ctrl.ds), $"maininsert Indexes of {meta.TableName}  {form.Name} are correct");
                if (!ctrl.isList) {
                    Assert.AreEqual(mainTable.Rows.Count,1,$"{meta.TableName}  {form.Name} DS main table contains one row");
                }

                ctrl.DontWarnOnInsertCancel = true;

                ctrl.DoMainCommand("maindelete");
                Application.DoEvents();
                if (ctrl.SearchEnabled && !(ctrl.isList && !ctrl.isTree)) {
                    Assert.AreEqual(true, ctrl.IsEmpty, $"{meta.TableName}  {form.Name} insert canceled ok");
                }
                else {
                    Assert.AreEqual(true, ctrl.EditMode, $"{meta.TableName}  {form.Name} insert canceled ok");
                }

                if (!ctrl.isList) {
                    Assert.AreEqual(mainTable.Rows.Count,0,$"{form.Name} DS main table contains no row");
                }
                Assert.AreEqual(null, checkDataSetIndexes(ctrl.ds), $"maindelete Indexes of {meta.TableName}  {form.Name} are correct");
            }

            ctrl.DoMainCommand("maindosearch");
            Assert.AreEqual(null, checkDataSetIndexes(ctrl.ds), $"maindosearch Indexes of {meta.TableName} {form.Name} are correct");
            Application.DoEvents();
            Assert.AreEqual(true, ctrl.EditMode,$"{form.Name} maindosearch caused from to switch into editMode");


            for (int i = 1; i <= 10; i++) {
                if (!meta.CommandEnabled("gotonext")) continue;
                ctrl.DoMainCommand("gotonext");
                Application.DoEvents();
                Assert.IsTrue(ctrl.DrawStateIsDone,$"Form {meta.TableName}  {form.Name} is in good state");
                Assert.AreEqual(ctrl.EditMode,true,$"{form.Name} gotonext {i} ok");
                Assert.AreEqual(null, checkDataSetIndexes(ctrl.ds), $"gotonext Indexes of {meta.TableName}  {form.Name} are correct");
                if (!ctrl.isList) {
                    Assert.AreEqual(mainTable.Rows.Count,1,$"{form.Name} DS main table contains one row");
                }
            }
            for (int i = 1; i <= 10; i++) {
                if (!meta.CommandEnabled("gotoprev")) continue;
                ctrl.DoMainCommand("gotoprev");
                Application.DoEvents();
                Assert.IsTrue(ctrl.DrawStateIsDone,$"Form {form.Name} is in good state");
                Assert.AreEqual(ctrl.EditMode,true,$"{form.Name} gotonext {i} ok");
                if (!ctrl.isList) {
                    Assert.AreEqual(mainTable.Rows.Count,1,$"{form.Name} DS main table contains one row");
                }
            }
            Assert.AreEqual(null, checkDataSetIndexes(ctrl.ds), $"end Indexes of {meta.TableName}  {form.Name} are correct");
            Application.DoEvents();
            if (form.Modal) {
               testE2EFrmHelper.delayedClose(form);
            }
        }
        
        /// <summary>
        /// Effettua alcuni test generici su un form individuato da metaName/editType
        /// </summary>
        /// <param name="metaName"></param>
        /// <param name="editType"></param>
        public void testGenericForm(string metaName, string editType) {
            var main = tester.mainForm;
            var menu = tester.getProp("mainMenu1") as MainMenu;
            var regMenu = getMenuItem(metaName, editType, menu.MenuItems);
            Assert.IsNotNull(regMenu,$"{metaName}-{editType} not found in menu");
            testE2EFrmHelper.registerFormTest(metaName, editType, onActivationForm);
            tester.openFromMenu(metaName,editType);
            Application.DoEvents();

            //Necessario solo per form MDI, quelli modali vengono chiusi nel metodo onActivationForm
            if (main.MdiChildren.Length > 0) {
                main.MdiChildren[0].Close();
                Assert.AreEqual(0,main.MdiChildren.Length,$"Form closed {metaName}-{editType}");
            }
            Assert.IsTrue(testE2EFrmHelper.hasBeenInvoked(metaName,editType),$"Funzione di test invocata per {metaName}-{editType}");
            
            //form.Close();
            Assert.IsTrue(main.MdiChildren.Length==0,$"{metaName} {editType} was closed");
            string err = tester.getErrors();
            Assert.AreEqual(err,"",$"{metaName} {editType} got no errors");
            Application.DoEvents();
        }

        [TestMethod]
        public void testMainForms() {
            testGenericForm("registry", "anagrafica");
            testGenericForm("invoice", "default");
            testGenericForm("invoicekind", "default");
            testGenericForm("invoicedetail", "default");
            testGenericForm("ivaregisterkind", "default");
            testGenericForm("fin", "default");
            testGenericForm("upb", "default");
            testGenericForm("mandate", "default");
            testGenericForm("mandatekind", "default");
            testGenericForm("mandatedetail", "default");
            testGenericForm("estimate", "default");
            testGenericForm("estimatekind", "default");
            testGenericForm("estimatedetail", "default");
            testGenericForm("underwriting", "default");
            testGenericForm("underwriter", "lista");
            testGenericForm("store", "default");  //è form modale
            testGenericForm("expense", "gerarchico");
            testGenericForm("expense", "levels");
            testGenericForm("income", "gerarchico");
            testGenericForm("income", "levels");
            testGenericForm("asset", "default");
            testGenericForm("assetacquire", "default");
            testGenericForm("assetload", "default");
            testGenericForm("assetunload", "default");
            testGenericForm("assetvar", "default");
            testGenericForm("wageaddition", "default");
            testGenericForm("itineration", "default");
            testGenericForm("parasubcontract", "default");
            testGenericForm("profservice", "default");
            testGenericForm("casualcontract", "default");
            testGenericForm("list", "default");
            testGenericForm("listclass", "default");
            testGenericForm("entry", "default");
            testGenericForm("finvar", "default");
            testGenericForm("accountvar", "default");
            testGenericForm("account", "default");
            testGenericForm("patrimony", "default");
            testGenericForm("placcount", "default");
            testGenericForm("payment", "docmultiplo");
            testGenericForm("paymenttransmission", "default");
            testGenericForm("proceeds", "reversalemultipla");
            testGenericForm("proceedstransmission", "default");
            testGenericForm("manager", "default");
            testGenericForm("pettycashoperation", "default");
            testGenericForm("epexp", "default");
            testGenericForm("epacc", "default");
            testGenericForm("treasurer", "default");
            testGenericForm("serviceregistry", "default");
            testGenericForm("inventorykind", "default");
            testGenericForm("service", "anagrafica");
            testGenericForm("pettycash", "default");
        }

        
        [TestMethod]
        public void testAllFormDataSet() {
            DataAccess conn = tester.getProp("MyDataAccess") as DataAccess;
            var tMenu = conn.readTable("menu",
                q.isNotNull("metadata") & q.isNotNull("edittype") & q.isNull("menucode"), // & q.eq("metadata","bankdispositionsetup"),
                order_by:"metadata"); //
            bool result = true;
            foreach (DataRow r in tMenu.Rows) {
                tester.clearErrors();
                string meta = r["metadata"].ToString();
                if (meta=="license")continue;
                //if (meta != "epilogo") continue;
                if (!testFormDataSet(meta, r["edittype"].ToString())) result = false;
                Assert.AreEqual(0, tester.ls.Errors.Length, $"No errors opening {meta} edittype: {r["edittype"]} ");
            }
            Assert.IsTrue(result,"All forms are ok.");

        }

        bool testFormDataSet(string metaName, string editType) {
            //if (metaName != "no_table") return true;

            var disp = tester.getProp("Dispatcher") as EntityDispatcher;
            var meta = disp.Get(metaName);
            var shower = MetaFactory.factory.getSingleton<IMessageShower>();
            var responder = shower.getResponder();
           
            responder.skipMessagesBox = true;
           
            var form = meta.GetPublicForm(editType);
            if (form == null) return true;
            if (metaName == "taxpay" && editType == "ritenutedapagare") {
                
                TestHelper.TestHelp.autoCloseByMessageTitle("Informazioni", DialogResult.Cancel);
                
            }
            
            meta.Edit(null, editType,false);
            if (meta.ds == null) return true;
            meta.ds.AcceptChanges();
            var ds = meta.DS.Copy();
            meta.DontWarnOnInsertCancel = true;

            string formName = meta.linkedForm.Name;

            bool resTestDataSet=  testDataSet(ds, meta.Conn, $"{metaName}.{editType} form {formName}");

            var controller=meta.formController;
            meta.formController.linkedForm.Close();      
            Assert.IsNull(meta.formController,$"Controller della maschera {formName} del meta/edittype {metaName}.{editType} distrutto");
            Assert.IsNull(controller.linkedForm,$"Distrutto form {metaName}.{editType} form {formName}");
            //Console.WriteLine($"verifico: {metaName}.{editType} form {formName}");
            return resTestDataSet;
        }

        bool testDataSet(DataSet d, IDataAccess conn,string formName) {
            bool result = true;
            foreach (DataTable t in d.Tables) {
                if (!testDataTable(t,conn,formName))result=false;
            }

            if (!result) {
                Console.WriteLine("--------------------------------- in "+formName);
            }
            return result;
        }

        bool testDataTable(DataTable t, IDataAccess conn,string formName) {
            bool result = true;
            var dbs = conn.GetStructure(DataAccess.GetTableForReading(t));
            var disp = tester.getProp("Dispatcher") as EntityDispatcher;
            var meta = disp.Get(DataAccess.GetTableForReading(t));

            if (dbs.columntypes.Rows.Count == 0) return true;

            if (t.PrimaryKey.Length == 0) {
                
                if (meta.primaryKey()== null || meta.primaryKey().Length == 0) {
                    Console.WriteLine($"Tabella {t.TableName} non ha chiave");
                    return false;
                }
            }
            CQueryHelper qhc= new CQueryHelper();
            foreach (DataColumn c in t.Columns) {
                if (QueryCreator.IsTemporary(c)) continue;
                if (dbs.columntypes.Select(qhc.CmpEq("field", c.ColumnName)).Length > 0) continue;
                Console.WriteLine($"{t.TableName}.{c.ColumnName} non esiste nel database");
                result= false;
            }

            foreach (DataRow r in dbs.columntypes.Rows) {
                string colName = r["field"].ToString();
                if (!t.Columns.Contains(colName)) continue;
                DataColumn c = t.Columns[colName];
                if (t.TableName.StartsWith("accmotiveapplied") && colName=="idepoperation")continue;//special case

                if (t.TableName == "listclassyearview" && (colName=="ayear" || colName=="idlistclass")) {
                    continue;
                }

                if (formName == "casualcontract.default form Frm_casualcontract_default") {
                    if (t.TableName == "uniqueregister" && (colName=="ycon" || colName=="ncon")) {
                        continue;
                    }
                }
                if (formName == "invoice.default form Frm_invoice_default") {
                    if (t.TableName == "uniqueregister" && (colName=="idinvkind" || colName=="yinv" || colName=="ninv")) {
                        continue;
                    }
                }
                if (formName == "paymentview.esitazionemultipla form FrmPaymentview_esitazionemultipla") {
                    if (t.TableName == "banktransaction" && colName=="kpay" ) {
                        continue;
                    }
                }
                if (formName == "proceedsview.esitazionemultipla form FrmProceedsview_esitazionemultipla") {
                    if (t.TableName == "banktransaction" && colName=="kpro" ) {
                        continue;
                    }
                }
                if (formName == "upb.default form Frm_upb_default") {
                    if (t.TableName=="autoexpensesorting"&& colName=="idupb")continue;//special case
                    if (t.TableName=="sortingexpensefilter"&& colName=="idupb")continue;//special case
                    if (t.TableName=="autoincomesorting"&& colName=="idupb")continue;//special case
                    if (t.TableName=="sortingincomefilter"&& colName=="idupb")continue;//special case
                }

                if (formName == "ddt_in.default form frmddt_in_default") {
                    if (t.TableName=="stock"&& colName=="idddt_in")continue;//special case
                }

                if (formName == "fin.default form Frm_fin_default") {
                    if (t.TableName=="autoexpensesorting"&& colName=="idfin")continue;//special case
                    if (t.TableName=="autoincomesorting"&& colName=="idfin")continue;//special case
                    if (t.TableName=="sortingexpensefilter"&& colName=="idfin")continue;//special case
                    if (t.TableName=="sortingincomefilter"&& colName=="idfin")continue;//special case
                }
                if (formName == "upb.history form Frm_upb_default") {
                    if (t.TableName=="autoexpensesorting"&& colName=="idupb")continue;//special case
                    if (t.TableName=="autoincomesorting"&& colName=="idupb")continue;//special case
                    if (t.TableName=="sortingexpensefilter"&& colName=="idupb")continue;//special case
                    if (t.TableName=="sortingincomefilter"&& colName=="idupb")continue;//special case
                }

                if (formName == "proceeds.reversalemultipla form Frm_proceeds_reversalemultipla") {
                    if (t.TableName=="banktransaction"&& colName=="kpro")continue;//special case
                }

                if (formName == "payment.docmultiplo form Frm_payment_docmultiplo") {
                    if (t.TableName=="banktransaction"&& colName=="kpay")continue;//special case
                }
                if (formName == "config.default form Frm_config_default") {
                    if (t.TableName.StartsWith("accmotiveapplied")&& colName=="idepoperation")continue;//special case
                }
                

                if (c.AllowDBNull)continue;
                if (r["allownull"].ToString().ToUpper()=="N")continue;
                Console.WriteLine($"{t.TableName}.{colName}");
                result= false;
            }

            return result;
        }

    }
}
