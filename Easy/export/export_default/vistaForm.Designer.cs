
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


namespace export_default {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaForm: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable exportfunction{get { return this.Tables["exportfunction"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable exportfunctionparam{get { return this.Tables["exportfunctionparam"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable columntypes{get { return this.Tables["columntypes"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable customselection{get { return this.Tables["customselection"];}}

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
public new System.Data.DataTableCollection Tables {get {return base.Tables;}}

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
public new System.Data.DataRelationCollection Relations {get {return base.Relations; } } 

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
	T= new DataTable("exportfunction");
	C= new DataColumn("procedurename", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("modulename", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("fileformat", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("timeout", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("fileextension", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["procedurename"]};
	T.PrimaryKey = key;

	T= new DataTable("exportfunctionparam");
	C= new DataColumn("procedurename", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("paramname", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("systype", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("tag", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("hintkind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("hint", typeof(System.String), ""));
	C= new DataColumn("number", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("iscombobox", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("datasource", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("valuemember", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("displaymember", typeof(System.String), ""));
	C= new DataColumn("noselectionforall", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("help", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("filter", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ct", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("lu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("selectioncode", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["procedurename"], 	T.Columns["paramname"]};
	T.PrimaryKey = key;

	T= new DataTable("columntypes");
	C= new DataColumn("tablename", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("field", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("iskey", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("sqltype", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("col_len", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("col_precision", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("col_scale", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("systemtype", typeof(System.String), ""));
	C= new DataColumn("sqldeclaration", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("allownull", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("defaultvalue", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("format", typeof(System.String), ""));
	C= new DataColumn("denynull", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("lastmoduser", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lastmodtimestamp", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("createuser", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("createtimestamp", typeof(System.DateTime), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["tablename"], 	T.Columns["field"]};
	T.PrimaryKey = key;

	T= new DataTable("customselection");
	C= new DataColumn("selectioncode", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("editlisttype", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("extraparameter", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("fieldname", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("filter", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lastmodtimestamp", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("lastmoduser", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("relationfield", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("selectionname", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("selectiontype", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("tablename", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["selectioncode"]};
	T.PrimaryKey = key;


//Relations
DataTable TPar;
DataTable TChild;
DataColumn []CPar;
DataColumn []CChild;
TPar= Tables["exportfunction"];
TChild= Tables["exportfunctionparam"];
CPar = new DataColumn[1]{TPar.Columns["procedurename"]};
CChild = new DataColumn[1]{TChild.Columns["procedurename"]};
Relations.Add(new DataRelation("exportfunctionexportfunctionparam",CPar,CChild));

TPar= Tables["columntypes"];
TChild= Tables["exportfunctionparam"];
CPar = new DataColumn[1]{TPar.Columns["tablename"]};
CChild = new DataColumn[1]{TChild.Columns["datasource"]};
Relations.Add(new DataRelation("columntypesexportfunctionparam",CPar,CChild));

}
}
}
