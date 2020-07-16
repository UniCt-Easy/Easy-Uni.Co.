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

namespace auditcheck_child {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaForm: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable customobject{get { return Tables["customobject"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable audit{get { return Tables["audit"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable auditcheck{get { return Tables["auditcheck"];}}

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
public new System.Data.DataTableCollection Tables {get {return base.Tables;}}

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
public new System.Data.DataRelationCollection Relations {get {return base.Relations; } } 

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
public vistaForm(){
BeginInit();
InitClass();
EndInit();
}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
private void InitClass() {
DataSetName = "vistaForm";
Prefix = "";
Namespace = "http://tempuri.org/vistaForm.xsd";
EnforceConstraints = false;
	DataTable T;
	DataColumn C;
	DataColumn [] key;
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

	T= new DataTable("audit");
	C= new DataColumn("idaudit", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("severity", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("title", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("flagsystem", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("consequence", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idaudit"]};
	T.PrimaryKey = key;

	T= new DataTable("auditcheck");
	C= new DataColumn("tablename", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("opkind", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idaudit", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idcheck", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("sqlcmd", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("message", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("precheck", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flag_cash", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flag_comp", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flag_both", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flag_credit", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flag_proceeds", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[4]{
	T.Columns["tablename"], 	T.Columns["opkind"], 	T.Columns["idaudit"], 	T.Columns["idcheck"]};
	T.PrimaryKey = key;


//Relations
DataTable TPar;
DataTable TChild;
DataColumn []CPar;
DataColumn []CChild;
TPar= Tables["customobject"];
TChild= Tables["auditcheck"];
CPar = new DataColumn[1]{TPar.Columns["objectname"]};
CChild = new DataColumn[1]{TChild.Columns["tablename"]};
Relations.Add(new DataRelation("customobjectauditcheck",CPar,CChild));

TPar= Tables["audit"];
TChild= Tables["auditcheck"];
CPar = new DataColumn[1]{TPar.Columns["idaudit"]};
CChild = new DataColumn[1]{TChild.Columns["idaudit"]};
Relations.Add(new DataRelation("auditauditcheck",CPar,CChild));

}
}
}
