
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


namespace casualcontracttax_default {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaForm: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable casualcontracttax{get { return this.Tables["casualcontracttax"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable tax{get { return this.Tables["tax"];}}

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
	T= new DataTable("casualcontracttax");
	C= new DataColumn("ycon", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ncon", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("taxcode", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("!taxref", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("!descrizione", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("adminrate", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("employrate", typeof(System.Decimal), ""));
	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("taxablegross", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("taxablenet", typeof(System.Decimal), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("admindenominator", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("employdenominator", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("taxabledenominator", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("adminnumerator", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("employnumerator", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("taxablenumerator", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("admintax", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("employtax", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("employtaxgross", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("deduction", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("!imponibilenetto", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("!aliquotaamm", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("!aliquotadip", typeof(System.Decimal), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[3]{
	T.Columns["ycon"], 	T.Columns["ncon"], 	T.Columns["taxcode"]};
	T.PrimaryKey = key;

	T= new DataTable("tax");
	C= new DataColumn("taxcode", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("taxref", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("taxkind", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("fiscaltaxcode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagunabatable", typeof(System.String), ""));
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
	T.Columns.Add(new DataColumn("taxablecode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("appliancebasis", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("geoappliance", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["taxcode"]};
	T.PrimaryKey = key;


//Relations
DataTable TPar;
DataTable TChild;
DataColumn []CPar;
DataColumn []CChild;
TPar= Tables["tax"];
TChild= Tables["casualcontracttax"];
CPar = new DataColumn[1]{TPar.Columns["taxcode"]};
CChild = new DataColumn[1]{TChild.Columns["taxcode"]};
Relations.Add(new DataRelation("taxcasualcontracttax",CPar,CChild));

}
}
}
