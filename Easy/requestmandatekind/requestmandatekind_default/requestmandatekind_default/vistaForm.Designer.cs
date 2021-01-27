
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


namespace requestmandatekind_default {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaForm: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable requestmandatekind{get { return Tables["requestmandatekind"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable mandatekind{get { return Tables["mandatekind"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable mandatekind_original{get { return Tables["mandatekind_original"];}}

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
	T= new DataTable("requestmandatekind");
	C= new DataColumn("idmankind_original", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idmankind", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("ct", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("cu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("lu", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["idmankind_original"], 	T.Columns["idmankind"]};
	T.PrimaryKey = key;

	T= new DataTable("mandatekind");
	C= new DataColumn("idmankind", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("active", typeof(System.String), ""));
	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idupb", typeof(System.String), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("email", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("faxnumber", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("office", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("phonenumber", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("linktoasset", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("linktoinvoice", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("multireg", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("deltaamount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("deltapercentage", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("flag_autodocnumbering", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagactivity", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("name_c", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("name_l", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("name_r", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("title_c", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("title_l", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("title_r", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("notes1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("notes2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("notes3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("warnmail", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("isrequest", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idsor01", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor02", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor03", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor04", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor05", typeof(System.Int32), ""));
	C= new DataColumn("assetkind", typeof(System.Byte), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("dangermail", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("address", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("header", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flag", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("touniqueregister", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ipa_fe", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("riferimento_amministrazione", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagcreatedoubleentry", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idmankind"]};
	T.PrimaryKey = key;

	T= new DataTable("mandatekind_original");
	C= new DataColumn("idmankind", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("active", typeof(System.String), ""));
	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idupb", typeof(System.String), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("email", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("faxnumber", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("office", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("phonenumber", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("linktoasset", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("linktoinvoice", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("multireg", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("deltaamount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("deltapercentage", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("flag_autodocnumbering", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagactivity", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("name_c", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("name_l", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("name_r", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("title_c", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("title_l", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("title_r", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("notes1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("notes2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("notes3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("warnmail", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("isrequest", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idsor01", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor02", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor03", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor04", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor05", typeof(System.Int32), ""));
	C= new DataColumn("assetkind", typeof(System.Byte), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("dangermail", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("address", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("header", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flag", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("touniqueregister", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ipa_fe", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("riferimento_amministrazione", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagcreatedoubleentry", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idmankind"]};
	T.PrimaryKey = key;


//Relations
DataTable TPar;
DataTable TChild;
DataColumn []CPar;
DataColumn []CChild;
TPar= Tables["mandatekind_original"];
TChild= Tables["requestmandatekind"];
CPar = new DataColumn[1]{TPar.Columns["idmankind"]};
CChild = new DataColumn[1]{TChild.Columns["idmankind_original"]};
Relations.Add(new DataRelation("mandatekind_original_requestmandatekind",CPar,CChild));

TPar= Tables["mandatekind"];
TChild= Tables["requestmandatekind"];
CPar = new DataColumn[1]{TPar.Columns["idmankind"]};
CChild = new DataColumn[1]{TChild.Columns["idmankind"]};
Relations.Add(new DataRelation("mandatekind_requestmandatekind",CPar,CChild));

}
}
}
