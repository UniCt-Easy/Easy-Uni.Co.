
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


namespace expenseclawback_default {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaForm: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable expenseclawback{get { return Tables["expenseclawback"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable clawback{get { return Tables["clawback"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable monthname2{get { return Tables["monthname2"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable monthname1{get { return Tables["monthname1"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable lookup_tiporigaf24ep{get { return Tables["lookup_tiporigaf24ep"];}}

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
	T= new DataTable("expenseclawback");
	C= new DataColumn("idexp", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idclawback", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("amount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("fiscaltaxcode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("identifying_marks", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("code", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("tiporiga", typeof(System.String), ""));
	C= new DataColumn("iddetail", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("rifb_month", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("rifb_year", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("rifa_month", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("rifa_year", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("rifa", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("!rifa_monthname", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("!rifb_monthname", typeof(System.String), ""));
	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["idexp"], 	T.Columns["idclawback"]};
	T.PrimaryKey = key;

	T= new DataTable("clawback");
	C= new DataColumn("idclawback", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("active", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagf24ep", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idclawback"]};
	T.PrimaryKey = key;

	T= new DataTable("monthname2");
	C= new DataColumn("code", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("cfvalue", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("title", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["code"]};
	T.PrimaryKey = key;

	T= new DataTable("monthname1");
	C= new DataColumn("code", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("cfvalue", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("title", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["code"]};
	T.PrimaryKey = key;

	T= new DataTable("lookup_tiporigaf24ep");
	C= new DataColumn("tiporiga", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("description", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["tiporiga"]};
	T.PrimaryKey = key;


//Relations
DataTable TPar;
DataTable TChild;
DataColumn []CPar;
DataColumn []CChild;
TPar= Tables["clawback"];
TChild= Tables["expenseclawback"];
CPar = new DataColumn[1]{TPar.Columns["idclawback"]};
CChild = new DataColumn[1]{TChild.Columns["idclawback"]};
Relations.Add(new DataRelation("clawbackexpenseclawback",CPar,CChild));

TPar= Tables["lookup_tiporigaf24ep"];
TChild= Tables["expenseclawback"];
CPar = new DataColumn[1]{TPar.Columns["tiporiga"]};
CChild = new DataColumn[1]{TChild.Columns["tiporiga"]};
Relations.Add(new DataRelation("lookup_tiporigaf24ep_expenseclawback",CPar,CChild));

TPar= Tables["monthname1"];
TChild= Tables["expenseclawback"];
CPar = new DataColumn[1]{TPar.Columns["code"]};
CChild = new DataColumn[1]{TChild.Columns["rifa_month"]};
Relations.Add(new DataRelation("monthname1_expenseclawback",CPar,CChild));

TPar= Tables["monthname2"];
TChild= Tables["expenseclawback"];
CPar = new DataColumn[1]{TPar.Columns["code"]};
CChild = new DataColumn[1]{TChild.Columns["rifb_month"]};
Relations.Add(new DataRelation("monthname2_expenseclawback",CPar,CChild));

}
}
}
