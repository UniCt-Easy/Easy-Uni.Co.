
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
public partial class vistaTipoRegistroIva: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable treasurer{get { return Tables["treasurer"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable ivaregisterkind{get { return Tables["ivaregisterkind"];}}

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
public new System.Data.DataTableCollection Tables {get {return base.Tables;}}

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
public new System.Data.DataRelationCollection Relations {get {return base.Relations; } } 

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
public vistaTipoRegistroIva(){
BeginInit();
InitClass();
EndInit();
}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
private void InitClass() {
DataSetName = "vistaTipoRegistroIva";
Prefix = "";
Namespace = "http://tempuri.org/vistaTipoRegistroIva.xsd";
EnforceConstraints = false;
	DataTable T;
	DataColumn C;
	DataColumn [] key;
	T= new DataTable("treasurer");
	T.Columns.Add(new DataColumn("address", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("agencycodefortransmission", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cabcodefortransmission", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cap", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cc", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cin", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("city", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("country", typeof(System.String), ""));
	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("depcodefortransmission", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("description", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("faxnumber", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("faxprefix", typeof(System.String), ""));
	C= new DataColumn("flagdefault", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idaccmotive_payment", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idaccmotive_proceeds", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idbank", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idcab", typeof(System.String), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("phonenumber", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("phoneprefix", typeof(System.String), ""));
	C= new DataColumn("codetreasurer", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idtreasurer", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("spexportexp", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagmultiexp", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("fileextension", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("spexportinc", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("iban", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("bic", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagfruitful", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cccbi", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cincbi", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idbankcbi", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idcabcbi", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ibancbi", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("siacodecbi", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("reccbikind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("trasmcode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagbank_grouping", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("motivelen", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("motiveprefix", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("motiveseparator", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("annotations", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagedisp", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idsor01", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor02", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor03", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor04", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor05", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("billcode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("active", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flag", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("header", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("savepath", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("departmentname_fe", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idtreasurer"]};
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


//Relations
DataTable TPar;
DataTable TChild;
DataColumn []CPar;
DataColumn []CChild;
TPar= Tables["treasurer"];
TChild= Tables["ivaregisterkind"];
CPar = new DataColumn[1]{TPar.Columns["idtreasurer"]};
CChild = new DataColumn[1]{TChild.Columns["idtreasurer"]};
Relations.Add(new DataRelation("treasurer_ivaregisterkind",CPar,CChild));

}
}
}
