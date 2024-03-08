
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


namespace notable_importazione {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaAutoclassMov: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable autoexpensesorting{get { return this.Tables["autoexpensesorting"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable autoincomesorting{get { return this.Tables["autoincomesorting"];}}

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
public new System.Data.DataTableCollection Tables {get {return base.Tables;}}

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
public new System.Data.DataRelationCollection Relations {get {return base.Relations; } } 

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
public vistaAutoclassMov(){
this.BeginInit();
this.InitClass();
this.EndInit();
}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
private void InitClass() {
this.DataSetName = "vistaAutoclassMov";
this.Prefix = "";
this.Namespace = "http://tempuri.org/vistaAutoclassMov.xsd";
this.EnforceConstraints = false;
	DataTable T;
	DataColumn C;
	T= new DataTable("autoexpensesorting");
	C= new DataColumn("ayear", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idautosort", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("ct", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("cu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaultn1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaultn2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaultn3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaultn4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaultn5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaults1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaults2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaults3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaults4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaults5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaultv1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaultv2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaultv3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaultv4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaultv5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("denominator", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("flagnodate", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idupb", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("lu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("numerator", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idfin", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idman", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsorreg", typeof(System.Int32), ""));
	C= new DataColumn("idsorkind", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idsorkindreg", typeof(System.Int32), ""));
	Tables.Add(T);
	//Primary Key
	T.PrimaryKey =  new DataColumn[]{T.Columns["ayear"], T.Columns["idautosort"]};;

	T= new DataTable("autoincomesorting");
	C= new DataColumn("ayear", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idautosort", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("ct", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("cu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaultn1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaultn2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaultn3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaultn4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaultn5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaults1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaults2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaults3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaults4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaults5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaultv1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaultv2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaultv3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaultv4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaultv5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("denominator", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("flagnodate", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idupb", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("lu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("numerator", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idfin", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idman", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsorreg", typeof(System.Int32), ""));
	C= new DataColumn("idsorkind", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idsorkindreg", typeof(System.Int32), ""));
	Tables.Add(T);
	//Primary Key
	T.PrimaryKey =  new DataColumn[]{T.Columns["ayear"], T.Columns["idautosort"]};;

}
}
}
