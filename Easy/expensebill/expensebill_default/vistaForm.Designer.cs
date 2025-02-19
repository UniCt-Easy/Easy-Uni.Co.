
/*
Easy
Copyright (C) 2024 UniversitÓ degli Studi di Catania (www.unict.it)
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


namespace expensebill_default {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaForm: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable expensebill{get { return Tables["expensebill"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable bill{get { return Tables["bill"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable billview{get { return Tables["billview"];}}

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
	T= new DataTable("expensebill");
	C= new DataColumn("idexp", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ybill", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nbill", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("amount", typeof(System.Decimal), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	Tables.Add(T);
//Primary Key
	key = new DataColumn[3]{
	T.Columns["idexp"], 	T.Columns["ybill"], 	T.Columns["nbill"]};
	T.PrimaryKey = key;

	T= new DataTable("bill");
	C= new DataColumn("ybill", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nbill", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("billkind", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("registry", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("covered", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("total", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("adate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("active", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("motive", typeof(System.String), ""));
	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idtreasurer", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("regularizationnote", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("reduction", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("banknum", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idbank", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[3]{
	T.Columns["ybill"], 	T.Columns["nbill"], 	T.Columns["billkind"]};
	T.PrimaryKey = key;

	T= new DataTable("billview");
	C= new DataColumn("ybill", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nbill", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("billkind", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("active", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("adate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("registry", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("motive", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("total", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("reduction", typeof(System.Decimal), ""));
	C= new DataColumn("covered", typeof(System.Decimal), "");
	C.ReadOnly=true;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("regularizationnote", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idtreasurer", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("treasurer", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idsor01", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor02", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor03", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor04", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor05", typeof(System.Int32), ""));
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

	T.Columns.Add(new DataColumn("toregularize", typeof(System.Decimal), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[3]{
	T.Columns["ybill"], 	T.Columns["nbill"], 	T.Columns["billkind"]};
	T.PrimaryKey = key;


//Relations
DataTable TPar;
DataTable TChild;
DataColumn []CPar;
DataColumn []CChild;
TPar= Tables["bill"];
TChild= Tables["expensebill"];
CPar = new DataColumn[2]{TPar.Columns["ybill"], TPar.Columns["nbill"]};
CChild = new DataColumn[2]{TChild.Columns["ybill"], TChild.Columns["nbill"]};
Relations.Add(new DataRelation("FK_bill_expensebill",CPar,CChild));

}
}
}
