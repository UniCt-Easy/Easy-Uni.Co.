
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


namespace taxpaymentpartsetupview_single {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaForm: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable registry{get { return this.Tables["registry"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable taxpaymentpartsetupview{get { return this.Tables["taxpaymentpartsetupview"];}}

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
	T= new DataTable("registry");
	C= new DataColumn("idreg", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("title", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("cf", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("p_iva", typeof(System.String), ""));
	C= new DataColumn("residence", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("annotation", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("birthdate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("gender", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("surname", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forename", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("foreigncf", typeof(System.String), ""));
	C= new DataColumn("active", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
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

	T.Columns.Add(new DataColumn("badgecode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idcategory", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idcentralizedcategory", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idmaritalstatus", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idtitle", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idregistryclass", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("maritalsurname", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idcity", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idnation", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("location", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("extmatricula", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idreg"]};
	T.PrimaryKey = key;

	T= new DataTable("taxpaymentpartsetupview");
	C= new DataColumn("taxcode", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ayear", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idreg", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("registry", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("percentage", typeof(System.Decimal), ""));
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
	key = new DataColumn[3]{
	T.Columns["taxcode"], 	T.Columns["ayear"], 	T.Columns["idreg"]};
	T.PrimaryKey = key;


//Relations
DataTable TPar;
DataTable TChild;
DataColumn []CPar;
DataColumn []CChild;
TPar= Tables["registry"];
TChild= Tables["taxpaymentpartsetupview"];
CPar = new DataColumn[1]{TPar.Columns["idreg"]};
CChild = new DataColumn[1]{TChild.Columns["idreg"]};
Relations.Add(new DataRelation("registrytaxpaymentpartsetupview",CPar,CChild));

}
}
}
