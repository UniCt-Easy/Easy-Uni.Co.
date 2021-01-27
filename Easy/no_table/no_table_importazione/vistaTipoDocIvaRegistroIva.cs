
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


namespace notable_importazione {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaTipoDocIvaRegistroIva: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable invoicekind{get { return Tables["invoicekind"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable ivaregisterkind{get { return Tables["ivaregisterkind"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable invoicekindregisterkind{get { return Tables["invoicekindregisterkind"];}}

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
public new System.Data.DataTableCollection Tables {get {return base.Tables;}}

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
public new System.Data.DataRelationCollection Relations {get {return base.Relations; } } 

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
public vistaTipoDocIvaRegistroIva(){
BeginInit();
InitClass();
EndInit();
}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
private void InitClass() {
DataSetName = "vistaTipoDocIvaRegistroIva";
Prefix = "";
Namespace = "http://tempuri.org/vistaTipoDocIvaRegistroIva.xsd";
EnforceConstraints = false;
	DataTable T;
	DataColumn C;
	DataColumn [] key;
	T= new DataTable("invoicekind");
	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("codeinvkind", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idinvkind", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("flag", typeof(System.Byte), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("flag_autodocnumbering", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("formatstring", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("active", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idinvkind_auto", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("printingcode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idsor01", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor02", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor03", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor04", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor05", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("address", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("header", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("notes1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("notes2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("notes3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ipa_fe", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("riferimento_amministrazione", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idinvkind"]};
	T.PrimaryKey = key;

	T= new DataTable("ivaregisterkind");
	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("registerclass", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idivaregisterkindunified", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagactivity", typeof(System.Int16), ""));
	C= new DataColumn("codeivaregisterkind", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idivaregisterkind", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("compensation", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idtreasurer", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idivaregisterkind"]};
	T.PrimaryKey = key;

	T= new DataTable("invoicekindregisterkind");
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

	C= new DataColumn("idinvkind", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idivaregisterkind", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["idinvkind"], 	T.Columns["idivaregisterkind"]};
	T.PrimaryKey = key;


//Relations
DataTable TPar;
DataTable TChild;
DataColumn []CPar;
DataColumn []CChild;
TPar= Tables["ivaregisterkind"];
TChild= Tables["invoicekindregisterkind"];
CPar = new DataColumn[1]{TPar.Columns["idivaregisterkind"]};
CChild = new DataColumn[1]{TChild.Columns["idivaregisterkind"]};
Relations.Add(new DataRelation("ivaregisterkind_invoicekindregisterkind",CPar,CChild));

TPar= Tables["invoicekind"];
TChild= Tables["invoicekindregisterkind"];
CPar = new DataColumn[1]{TPar.Columns["idinvkind"]};
CChild = new DataColumn[1]{TChild.Columns["idinvkind"]};
Relations.Add(new DataRelation("invoicekind_invoicekindregisterkind",CPar,CChild));

}
}
}
