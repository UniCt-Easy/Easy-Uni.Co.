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

namespace no_table_consolidclientiforn {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaForm: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable no_table{get { return this.Tables["no_table"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable cliente{get { return this.Tables["cliente"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable fornitore{get { return this.Tables["fornitore"];}}

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
public new System.Data.DataTableCollection Tables {get {return base.Tables;}}

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
public vistaForm(){
this.BeginInit();
this.InitClass();
this.EndInit();
}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
private void InitClass() {
this.DataSetName = "vistaForm";
this.Prefix = "";
this.Namespace = "http://tempuri.org/vistaForm.xsd";
this.EnforceConstraints = false;
	DataTable T;
	DataColumn C;
	DataColumn [] key;
	T= new DataTable("no_table");
	C= new DataColumn("id_no_table", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["id_no_table"]};
	T.PrimaryKey = key;

	T= new DataTable("cliente");
	T.Columns.Add(new DataColumn("CL001001", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("CL002001", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CL003001", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CL004001", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("CL004002", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("CL005001", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("CL006001", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("CL007001", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("CL008001", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("CL008002", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("CL009001", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("CL010001", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("CL011001", typeof(System.Int32), ""));
	Tables.Add(T);
	T= new DataTable("fornitore");
	T.Columns.Add(new DataColumn("FR001001", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("FR002001", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("FR003001", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("FR004001", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("FR004002", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("FR005001", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("FR006001", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("FR007001", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("FR008001", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("FR009001", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("FR009002", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("FR010001", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("FR011001", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("FR012001", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("FR013001", typeof(System.Int32), ""));
	Tables.Add(T);
}
}
}
