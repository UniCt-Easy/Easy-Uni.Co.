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
using metadatalibrary;
using System.Data;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography;
using System.Windows.Forms;
using mainform;
using DBConn;

namespace TestHelper {

    public class TestErrorLogger : ErrorLogger {
        public override void warnEvent(string e) {
            return;
        }
    }
    public static class getSetterTestHelper{
        public static void setValue(this ComboBox c, object valueToSet) {
           var fieldtoconsider = c.ValueMember;
            if (valueToSet == null) valueToSet = DBNull.Value;
            
            var first = -1;
            var typeok = false;
            DataTable comboTable = null;
            for (var i = 0; i < c.Items.Count; i++) {
                var v = (DataRowView)c.Items[i];
                comboTable = v.Row.Table;

                //converte valueToSet al tipo del DataColumn
                if (valueToSet != DBNull.Value && !typeok) {
                    typeok = true;

                    var columnType = comboTable.Columns[fieldtoconsider].DataType;
                    if (columnType != valueToSet.GetType()) {
                        if (columnType == typeof(string)) valueToSet = valueToSet.ToString();
                        if (columnType == typeof(int)) valueToSet = Convert.ToInt32(valueToSet);
                        if (columnType == typeof(byte)) {
                            if (Convert.ToInt32(valueToSet)>=0) valueToSet = Convert.ToByte(valueToSet);
                        }
                        if (columnType == typeof(uint)) {
                            if (Convert.ToInt32(valueToSet) >= 0) valueToSet = Convert.ToUInt32(valueToSet);
                        }
                        if (columnType == typeof(short)) valueToSet = Convert.ToInt16(valueToSet);
                        if (columnType == typeof(ushort)) {
                            if (Convert.ToInt32(valueToSet) >= 0) valueToSet = Convert.ToUInt16(valueToSet);
                        }
                    }
                }
                if ((v.Row.RowState == DataRowState.Deleted)
                    || (v.Row.RowState == DataRowState.Detached)) continue;
                if (first == -1) first = i;
                var testvalue = v[fieldtoconsider];
                if (testvalue.Equals(valueToSet)) {
                    if (c.SelectedIndex != i) {
                         c.SelectedIndex = i;
                    }
                    return;
                }
            }
           
           
          
        }
         public static void setDisplay(this ComboBox c, object valueToSet) {
           var fieldtoconsider = c.DisplayMember;
            if (valueToSet == null) valueToSet = DBNull.Value;
            
            var first = -1;
            var typeok = false;
            DataTable comboTable = null;
            for (var i = 0; i < c.Items.Count; i++) {
                var v = (DataRowView)c.Items[i];
                comboTable = v.Row.Table;

                //converte valueToSet al tipo del DataColumn
                if (valueToSet != DBNull.Value && !typeok) {
                    typeok = true;

                    var columnType = comboTable.Columns[fieldtoconsider].DataType;
                    if (columnType != valueToSet.GetType()) {
                        if (columnType == typeof(string)) valueToSet = valueToSet.ToString();
                        if (columnType == typeof(int)) valueToSet = Convert.ToInt32(valueToSet);
                        if (columnType == typeof(byte)) {
                            if (Convert.ToInt32(valueToSet)>=0) valueToSet = Convert.ToByte(valueToSet);
                        }
                        if (columnType == typeof(uint)) {
                            if (Convert.ToInt32(valueToSet) >= 0) valueToSet = Convert.ToUInt32(valueToSet);
                        }
                        if (columnType == typeof(short)) valueToSet = Convert.ToInt16(valueToSet);
                        if (columnType == typeof(ushort)) {
                            if (Convert.ToInt32(valueToSet) >= 0) valueToSet = Convert.ToUInt16(valueToSet);
                        }
                    }
                }
                if ((v.Row.RowState == DataRowState.Deleted)
                    || (v.Row.RowState == DataRowState.Detached)) continue;
                if (first == -1) first = i;
                var testvalue = v[fieldtoconsider];
                if (testvalue.Equals(valueToSet)) {
                    if (c.SelectedIndex != i) {
                         c.SelectedIndex = i;
                    }
                    return;
                }
            }
           
           
          
        }

         public static void setDisplayHaving(this ComboBox c, string valueToSet) {
           var fieldtoconsider = c.DisplayMember;
            if (valueToSet == null) valueToSet = "";
            
            var first = -1;
            var typeok = false;
            DataTable comboTable = null;
            for (var i = 0; i < c.Items.Count; i++) {
                var v = (DataRowView)c.Items[i];
                comboTable = v.Row.Table;
                
                if ((v.Row.RowState == DataRowState.Deleted)
                    || (v.Row.RowState == DataRowState.Detached)) continue;
                if (first == -1) first = i;
                var testvalue = v[fieldtoconsider].ToString().ToLower();
                if (testvalue.Contains(valueToSet.ToLower())) {
                    if (c.SelectedIndex != i) {
                         c.SelectedIndex = i;
                    }
                    return;
                }
            }
           
           
          
        }
    }

    /// <summary>
    /// test E2e Helper
    /// </summary>
    public class testE2EMainHelper {
        public frmMain mainForm;
        public MyListener ls;
        public testE2EMainHelper() {
            string[] parConn = DbConn.getParams("test");

            frmMain.argCopy = new string[] {"autostart", parConn[0], parConn[4], parConn[5],"31/12/2018","2018"};
            
            ErrorLogger.Logger= new TestErrorLogger();
            
            mainForm = new frmMain();
            mainForm.Show();
            var lsGetter = mainForm.GetType().GetField("TS",BindingFlags.NonPublic|BindingFlags.Instance);
            ls = lsGetter.GetValue(mainForm) as MyListener;
        }


        /// <summary>
        /// Opens a form given metadata name and editType
        /// </summary>
        /// <param name="meta"></param>
        /// <param name="editType"></param>
        public void openFromMenu(string meta, string editType) {
            var menu = getProp("mainMenu1") as MainMenu;
            var regMenu = getMenuItem(meta,editType, menu.MenuItems);
            regMenu.PerformClick();
        }

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

        /// <summary>
        /// Clears output of output viewer
        /// </summary>
        public void clearErrors() {
            ls.Errors.Clear();
        }

        /// <summary>
        /// closes main form
        /// </summary>
        public void close() {
            mainForm.Close();
        }

        /// <summary>
        /// Gets the output viewer content
        /// </summary>
        /// <returns></returns>
        public string getErrors() {
            return ls.Errors.ToString();
        }

        /// <summary>
        /// Connects main form to db
        /// </summary>
        public void connect() {
            MethodInfo dynMethod = mainForm.GetType().GetMethod("connect", BindingFlags.NonPublic | BindingFlags.Instance);
            dynMethod.Invoke(mainForm, new object[] { });
        }

        /// <summary>
        /// Gets the value of a property of an object
        /// </summary>
        /// <param name="propName"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public  object getProp(string propName, object o) {
            return o?.GetType().GetField(propName, BindingFlags.Public|BindingFlags.NonPublic | BindingFlags.Instance).GetValue(o);
        }

        /// <summary>
        /// Gets a property of main form
        /// </summary>
        /// <param name="propName"></param>
        /// <returns></returns>
        public object getProp(string propName) {
            return getProp(propName,mainForm);
        }
        /// <summary>
        /// Invokes a method of mainform
        /// </summary>
        /// <param name="method"></param>
        /// <param name="par"></param>
        /// <returns></returns>
        public object invokeMethod(string method, params object[] par) {
           return invokeMethod(mainForm,method,par);
        }

        /// <summary>
        /// Invokes a method of an object
        /// </summary>
        /// <param name="o"></param>
        /// <param name="method"></param>
        /// <param name="par"></param>
        /// <returns></returns>
        public   object invokeMethod(object o, string method, params object[] par) {
            MethodInfo dynMethod = o.GetType().GetMethod(method, BindingFlags.NonPublic | BindingFlags.Instance);
            return dynMethod.Invoke(o,par);
        }
    }

    public class testE2EFrmHelper {
        public delegate void testFunDelegate(Form f);
        public Form  f;
        public IMetaData meta;
        public IDataAccess conn;
        public IFormController ctrl;
        public IResponder resp;
        public IMessageShower shower;
        static  Dictionary<Form , bool> activated= new Dictionary<Form, bool>();

        static testE2EFrmHelper() {
            FormController.MainEventsManager.addListener(
                new ApplicationEventHandlerDelegate<FormActivated>(onActivationForm));
        }

        public testE2EFrmHelper(Form f) {
            this.f = f;
            meta = f.getInstance<IMetaData>();
            conn = f.getInstance<IDataAccess>();
            ctrl = f.getInstance<IFormController>();
            shower = MetaFactory.factory.getSingleton<IMessageShower>();
            resp = shower.getResponder();
            resp.registerErrorMessages = true;
            resp.skipMessagesBox = true;
        }

        public void closeForm() {
            f.Close();
            f.Dispose();
        }
        
        public static void onActivationForm(FormActivated e) {
            if (activated.ContainsKey(e.f)) return;
            activated.Add(e.f, true);
            var meta = e.f.getInstance<IMetaData>();
            string key = $"{meta.TableName}#{meta.editType}";
            if (registeredFun.ContainsKey(key)) {
                testFunDelegate f = registeredFun[key];
                registeredFun.Remove(key);
                f(e.f);
                invocations[key] = true;
            }
        }
        static Dictionary<string, bool>invocations  = new Dictionary<string, bool>();
        public static bool hasBeenInvoked(string meta, string editType) {
            string key = $"{meta}#{editType}";
            return invocations.ContainsKey(key);
        }
      
        static Dictionary<string,testFunDelegate> registeredFun = new Dictionary<string, testFunDelegate>();
        public static void registerFormTest(string meta, string editType, testFunDelegate testFun) {
            string key = $"{meta}#{editType}";
            registeredFun[key] = testFun;
        }

       

        public static void delayedClose(Form f) {
            var _delayTimer = new System.Timers.Timer();
            _delayTimer.Interval = 20;
            _delayTimer.AutoReset = false;
            _delayTimer.Elapsed += (o, ee) => f.Close();
            _delayTimer.Enabled = true;
            _delayTimer.Start();

        }

        public void clickByTag(string tag, Control.ControlCollection ctrls=null) {
            Control c = findByTag(tag, ctrls);
            if (c==null)return;
            if (c is Button)((Button)c).PerformClick();
        }

        public void clickByName(string name, Control.ControlCollection ctrls=null) {
            Control c = findByName(name, ctrls);
            if (c==null)return;
            HelpForm.FocusControl(c);
            if (c is Button)((Button)c).PerformClick();
        }

        public Control findByTag(string tag, Control.ControlCollection ctrls=null) {
            if (ctrls == null) ctrls = f.Controls;
            foreach (Control c in ctrls) {
                if (c.Tag != null && c.Tag is string) {
                    if ((string) c.Tag == tag) return c;
                }
                if (c.Controls.Count > 0) {
                    Control res = findByTag(tag, c.Controls);
                    if (res != null) return res;
                }

            }

            return null;
        }
        public Control findByName(string name, Control.ControlCollection ctrls=null) {
            if (ctrls == null) ctrls = f.Controls;
            foreach (Control c in ctrls) {
                
                if (c.Name == name) return c;
                
                if (c.Controls.Count > 0) {
                    Control res = findByName(name, c.Controls);
                    if (res != null) return res;
                }

            }

            return null;
        }
    }
}
