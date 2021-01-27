
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


namespace taxfinmotive_single {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaForm: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable taxfinmotive{get { return Tables["taxfinmotive"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable service{get { return Tables["service"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable finmotive_incomeintra{get { return Tables["finmotive_incomeintra"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable finmotive_admintax{get { return Tables["finmotive_admintax"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable finmotive_expensecontra{get { return Tables["finmotive_expensecontra"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable finmotive_incomeemploy{get { return Tables["finmotive_incomeemploy"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable finmotive_expenseemploy{get { return Tables["finmotive_expenseemploy"];}}

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
	T= new DataTable("taxfinmotive");
	C= new DataColumn("taxcode", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idser", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idmotincomeintra", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("ct", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("lu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idmotincomeemploy", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idmotadmintax", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idmotexpenseemploy", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idmotexpensecontra", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["taxcode"], 	T.Columns["idser"]};
	T.PrimaryKey = key;

	T= new DataTable("service");
	T.Columns.Add(new DataColumn("active", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("allowedit", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("certificatekind", typeof(System.String), ""));
	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("flagalwaysinfiscalmodels", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagapplyabatements", typeof(System.String), ""));
	C= new DataColumn("flagonlyfiscalabatement", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idmotive", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("itinerationvisible", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ivaamount", typeof(System.String), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("module", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("rec770kind", typeof(System.String), ""));
	C= new DataColumn("codeser", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idser", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("flagneedbalance", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagforeign", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("voce8000", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("webdefault", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagdistraint", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("voce8000refund_i", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("voce8000refund_e", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagcsausability", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("flagnoexemptionquote", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idser"]};
	T.PrimaryKey = key;

	T= new DataTable("finmotive_incomeintra");
	C= new DataColumn("idfinmotive", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("active", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("codemotive", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("paridfinmotive", typeof(System.String), ""));
	C= new DataColumn("title", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("lu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ct", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("cu", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idfinmotive"]};
	T.PrimaryKey = key;

	T= new DataTable("finmotive_admintax");
	C= new DataColumn("idfinmotive", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("active", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("codemotive", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("paridfinmotive", typeof(System.String), ""));
	C= new DataColumn("title", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("lu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ct", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("cu", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idfinmotive"]};
	T.PrimaryKey = key;

	T= new DataTable("finmotive_expensecontra");
	C= new DataColumn("idfinmotive", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("active", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("codemotive", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("paridfinmotive", typeof(System.String), ""));
	C= new DataColumn("title", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("lu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ct", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("cu", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idfinmotive"]};
	T.PrimaryKey = key;

	T= new DataTable("finmotive_incomeemploy");
	C= new DataColumn("idfinmotive", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("active", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("codemotive", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("paridfinmotive", typeof(System.String), ""));
	C= new DataColumn("title", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("lu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ct", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("cu", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idfinmotive"]};
	T.PrimaryKey = key;

	T= new DataTable("finmotive_expenseemploy");
	C= new DataColumn("idfinmotive", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("active", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("codemotive", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("paridfinmotive", typeof(System.String), ""));
	C= new DataColumn("title", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("lu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ct", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("cu", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idfinmotive"]};
	T.PrimaryKey = key;


//Relations
DataTable TPar;
DataTable TChild;
DataColumn []CPar;
DataColumn []CChild;
TPar= Tables["finmotive_expenseemploy"];
TChild= Tables["taxfinmotive"];
CPar = new DataColumn[1]{TPar.Columns["idfinmotive"]};
CChild = new DataColumn[1]{TChild.Columns["idmotexpenseemploy"]};
Relations.Add(new DataRelation("FK_finmotive_expenseemploy_taxfinmotive",CPar,CChild));

TPar= Tables["finmotive_incomeemploy"];
TChild= Tables["taxfinmotive"];
CPar = new DataColumn[1]{TPar.Columns["idfinmotive"]};
CChild = new DataColumn[1]{TChild.Columns["idmotincomeemploy"]};
Relations.Add(new DataRelation("FK_finmotive_incomeemploy_taxfinmotive",CPar,CChild));

TPar= Tables["finmotive_expensecontra"];
TChild= Tables["taxfinmotive"];
CPar = new DataColumn[1]{TPar.Columns["idfinmotive"]};
CChild = new DataColumn[1]{TChild.Columns["idmotexpensecontra"]};
Relations.Add(new DataRelation("FK_finmotive_expensecontra_taxfinmotive",CPar,CChild));

TPar= Tables["finmotive_admintax"];
TChild= Tables["taxfinmotive"];
CPar = new DataColumn[1]{TPar.Columns["idfinmotive"]};
CChild = new DataColumn[1]{TChild.Columns["idmotadmintax"]};
Relations.Add(new DataRelation("FK_finmotive_admintax_taxfinmotive",CPar,CChild));

TPar= Tables["finmotive_incomeintra"];
TChild= Tables["taxfinmotive"];
CPar = new DataColumn[1]{TPar.Columns["idfinmotive"]};
CChild = new DataColumn[1]{TChild.Columns["idmotincomeintra"]};
Relations.Add(new DataRelation("FK_finmotive_incomeintra_taxfinmotive",CPar,CChild));

TPar= Tables["service"];
TChild= Tables["taxfinmotive"];
CPar = new DataColumn[1]{TPar.Columns["idser"]};
CChild = new DataColumn[1]{TChild.Columns["idser"]};
Relations.Add(new DataRelation("FK_service_taxfinmotive",CPar,CChild));

}
}
}
