
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


namespace exportfunctionparam_single {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaForm: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable exportfunctionparam{get { return this.Tables["exportfunctionparam"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable customobject{get { return this.Tables["customobject"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable columntypes{get { return this.Tables["columntypes"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable columntypescombodescfield{get { return this.Tables["columntypescombodescfield"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable tmp_tipo{get { return this.Tables["tmp_tipo"];}}
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

	T= new DataTable("customobject");
	C= new DataColumn("objectname", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("description", typeof(System.String), ""));
	C= new DataColumn("isreal", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("realtable", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lastmoduser", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lastmodtimestamp", typeof(System.DateTime), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["objectname"]};
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

	T= new DataTable("columntypescombodescfield");
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

	T= new DataTable("tmp_tipo");
	C= new DataColumn("codice", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("tipo", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["codice"]};
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
TPar= Tables["customobject"];
TChild= Tables["columntypescombodescfield"];
CPar = new DataColumn[1]{TPar.Columns["objectname"]};
CChild = new DataColumn[1]{TChild.Columns["tablename"]};
Relations.Add(new DataRelation("customobjectcolumntypescombodescfield",CPar,CChild));

TPar= Tables["customobject"];
TChild= Tables["columntypes"];
CPar = new DataColumn[1]{TPar.Columns["objectname"]};
CChild = new DataColumn[1]{TChild.Columns["tablename"]};
Relations.Add(new DataRelation("customobjectcolumntypes",CPar,CChild));

TPar= Tables["customobject"];
TChild= Tables["exportfunctionparam"];
CPar = new DataColumn[1]{TPar.Columns["objectname"]};
CChild = new DataColumn[1]{TChild.Columns["datasource"]};
Relations.Add(new DataRelation("customobjectexportfunctionparam",CPar,CChild));

TPar= Tables["columntypes"];
TChild= Tables["exportfunctionparam"];
CPar = new DataColumn[2]{TPar.Columns["tablename"], TPar.Columns["field"]};
CChild = new DataColumn[2]{TChild.Columns["datasource"], TChild.Columns["valuemember"]};
Relations.Add(new DataRelation("columntypesexportfunctionparam",CPar,CChild));

TPar= Tables["columntypescombodescfield"];
TChild= Tables["exportfunctionparam"];
CPar = new DataColumn[2]{TPar.Columns["tablename"], TPar.Columns["field"]};
CChild = new DataColumn[2]{TChild.Columns["datasource"], TChild.Columns["displaymember"]};
Relations.Add(new DataRelation("columntypescombodescfieldexportfunctionparam",CPar,CChild));

TPar= Tables["tmp_tipo"];
TChild= Tables["exportfunctionparam"];
CPar = new DataColumn[1]{TPar.Columns["codice"]};
CChild = new DataColumn[1]{TChild.Columns["systype"]};
Relations.Add(new DataRelation("tmp_tipo_exportfunctionparam",CPar,CChild));

TPar= Tables["customselection"];
TChild= Tables["exportfunctionparam"];
CPar = new DataColumn[1]{TPar.Columns["selectioncode"]};
CChild = new DataColumn[1]{TChild.Columns["selectioncode"]};
Relations.Add(new DataRelation("customselection_exportfunctionparam",CPar,CChild));

}
}
}
