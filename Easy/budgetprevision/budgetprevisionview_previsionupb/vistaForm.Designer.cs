
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


namespace budgetprevisionview_previsionupb {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaForm: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable upb{get { return this.Tables["upb"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable budgetprevisionview{get { return this.Tables["budgetprevisionview"];}}

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
	T= new DataTable("upb");
	C= new DataColumn("idupb", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("active", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("assured", typeof(System.String), ""));
	C= new DataColumn("codeupb", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("expiration", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("granted", typeof(System.Decimal), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("paridupb", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("previousappropriation", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("previousassessment", typeof(System.Decimal), ""));
	C= new DataColumn("printingorder", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("requested", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
	C= new DataColumn("title", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idman", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idunderwriter", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("cupcode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idsor01", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor02", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor03", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor04", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor05", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idupb"]};
	T.PrimaryKey = key;

	T= new DataTable("budgetprevisionview");
	C= new DataColumn("ayear", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idsorkind", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("codesorkind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("sortingkind", typeof(System.String), ""));
	C= new DataColumn("idsor", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("sortcode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("sorting", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("paridsor", typeof(System.Int32), ""));
	C= new DataColumn("nlevel", typeof(System.Byte), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("leveldescr", typeof(System.String), ""));
	C= new DataColumn("idupb", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("codeupb", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("upb", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("paridupb", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("prevision", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("previousprevision", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("prevision2", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("prevision3", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("prevision4", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("prevision5", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("idsor01", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor02", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor03", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor04", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor05", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("ct", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("cu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("lu", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[3]{
	T.Columns["ayear"], 	T.Columns["idsor"], 	T.Columns["idupb"]};
	T.PrimaryKey = key;


//Relations
DataTable TPar;
DataTable TChild;
DataColumn []CPar;
DataColumn []CChild;
TPar= Tables["upb"];
TChild= Tables["budgetprevisionview"];
CPar = new DataColumn[1]{TPar.Columns["idupb"]};
CChild = new DataColumn[1]{TChild.Columns["idupb"]};
Relations.Add(new DataRelation("upb_budgetprevisionview",CPar,CChild));

}
}
}
