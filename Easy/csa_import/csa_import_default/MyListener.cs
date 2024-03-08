
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
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;

namespace csa_import_default {
    class MyListener: TraceListener {
        public StringBuilder Errors = new StringBuilder();
        public Form Err;               //FrmViewError
        //		public override void Write(string message, string category) {
        //			base.Write (message, category);
        //		}

        string GetPrintable(string msg) {
            string S = msg.Replace("\r", "\n");
            S = S.Replace("\n\n", "\n");
            S = S.Replace("\n", "\r\n");
            return S;
        }

        Form getViewError(string s) {
            Assembly a = System.Reflection.Assembly.Load("ViewError");
            foreach (System.Type FormType in a.GetTypes()) {
                if (FormType.Name == "frmViewError") {
                    ConstructorInfo FormBuilder = FormType.GetConstructor(new System.Type[] { typeof(string) });
                    Form F = (Form)FormBuilder.Invoke(new object[] { s });
                    return F;
                }
            }
            return null;
        }

        void updateViewError() {
            if (Err != null) {
                FieldInfo dataInfo = Err.GetType().GetField("txtMsg");
                TextBox tt = (TextBox)dataInfo.GetValue(Err);
                tt.Text = Errors.ToString();
                tt.SelectionLength = 0;
            }
        }

        public MyListener() {
            Errors = new StringBuilder();

        }

        public void CheckForNewErr() {
            if ((Err == null) || (Err.IsDisposed)) {
                Err = getViewError("");
                Err.TopMost = false;
            }
        }
        public override void WriteLine(object o) {
            Errors.AppendLine(GetPrintable(o.ToString()));
            updateViewError();
        }

        public override void WriteLine(string message) {
            Errors.AppendLine(GetPrintable(message));
            updateViewError();
        }

        public override void Write(string message) {
            Errors.Append(GetPrintable(message));
            updateViewError();
        }
        public void ShowErrors() {
            if ((Err == null) || (Err.IsDisposed)) {
                Err = getViewError(Errors.ToString());
                Err.TopMost = false;
            }
            updateViewError();
            Err.Show();
        }
    }
}
