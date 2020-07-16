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

namespace LiveUpdate {
    using System;
    using System.Data;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Globalization;
    [System.CodeDom.Compiler.GeneratedCodeAttribute("HDSGene", "2.0")]
    [DesignerCategoryAttribute("code")]
    public partial class DsDLLIndex : System.Data.DataSet {

        #region Table members declaration
        [DebuggerNonUserCodeAttribute()]
        [Browsable(false)]
        public DataTable DLL { get { return Tables["DLL"]; } }
        #endregion


        [DebuggerNonUserCodeAttribute()]
        public DsDLLIndex() {
            BeginInit();
            InitClass();
            EndInit();
        }
        [DebuggerNonUserCodeAttribute()]
        private void InitClass() {
            DataSetName = "DsDLLIndex";
            Prefix = "";
            Namespace = "http://tempuri.org/DsDLLIndex.xsd";
            EnforceConstraints = false;

            #region create DataTables
            DataTable T;
            DataColumn C;
            //////////////////// DLL /////////////////////////////////
            T = new DataTable("DLL");
            C = new DataColumn("dllname", typeof(System.String));
            C.AllowDBNull = false;
            T.Columns.Add(C);
            T.Columns.Add(new DataColumn("major", typeof(System.Int32)));
            T.Columns.Add(new DataColumn("minor", typeof(System.Int32)));
            T.Columns.Add(new DataColumn("build", typeof(System.Int32)));
            T.Columns.Add(new DataColumn("revision", typeof(System.Int32)));
            Tables.Add(T);
            T.PrimaryKey = new DataColumn[] { T.Columns["dllname"] };


            #endregion

        }
    }
}
