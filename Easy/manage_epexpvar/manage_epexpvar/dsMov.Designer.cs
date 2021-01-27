
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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


namespace manage_epexpvar {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class dsMov: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable epexpview{get { return Tables["epexpview"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable epexpsorting{get { return Tables["epexpsorting"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable epexpvarview{get { return Tables["epexpvarview"];}}

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
public new System.Data.DataTableCollection Tables {get {return base.Tables;}}

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
public new System.Data.DataRelationCollection Relations {get {return base.Relations; } } 

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
public dsMov(){
BeginInit();
InitClass();
EndInit();
}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
private void InitClass() {
DataSetName = "dsMov";
Prefix = "";
Namespace = "http://tempuri.org/dsMov.xsd";
EnforceConstraints = false;
	DataTable T;
	DataColumn C;
	DataColumn [] key;
	T= new DataTable("epexpview");
	C= new DataColumn("idepexp", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("yepexp", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nepexp", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nphase", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("phase", typeof(System.String), "");
	C.ReadOnly=true;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("amount", typeof(System.Decimal), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("amount2", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("amount3", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("amount4", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("amount5", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("curramount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("curramount2", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("curramount3", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("curramount4", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("curramount5", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("available", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("available2", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("available3", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("available4", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("available5", typeof(System.Decimal), ""));
	C= new DataColumn("ayear", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idacc", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("codeacc", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("account", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idupb", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("codeupb", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("upb", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("paridepexp", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("parentyepexp", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("parentnepexp", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("start", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("stop", typeof(System.DateTime), ""));
	C= new DataColumn("adate", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idreg", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("registry", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("doc", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("docdate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("idman", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("manager", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idrelated", typeof(System.String), ""));
	Tables.Add(T);
	T= new DataTable("epexpsorting");
	C= new DataColumn("idepexp", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("rownum", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("adate", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("amount", typeof(System.Decimal), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ayear", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("description", typeof(System.String), ""));
	C= new DataColumn("idsor", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("kind", typeof(System.String), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("!sorting", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("!sortcode", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["idepexp"], 	T.Columns["rownum"]};
	T.PrimaryKey = key;

	T= new DataTable("epexpvarview");
	C= new DataColumn("idepexp", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nvar", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("yvar", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nphase", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("phase", typeof(System.String), "");
	C.ReadOnly=true;
	T.Columns.Add(C);

	C= new DataColumn("yepexp", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nepexp", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("amount", typeof(System.Decimal), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("amount2", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("amount3", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("amount4", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("amount5", typeof(System.Decimal), ""));
	C= new DataColumn("adate", typeof(System.DateTime), "");
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

	T.Columns.Add(new DataColumn("codeacc", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("account", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("codeupb", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("upb", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idman", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idtreasurer", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor01", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor02", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor03", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor04", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor05", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["idepexp"], 	T.Columns["nvar"]};
	T.PrimaryKey = key;


//Relations
DataTable TPar;
DataTable TChild;
DataColumn []CPar;
DataColumn []CChild;
TPar= Tables["epexpview"];
TChild= Tables["epexpsorting"];
CPar = new DataColumn[1]{TPar.Columns["idepexp"]};
CChild = new DataColumn[1]{TChild.Columns["idepexp"]};
Relations.Add(new DataRelation("epexpview_epexpsorting",CPar,CChild));

}
}
}
