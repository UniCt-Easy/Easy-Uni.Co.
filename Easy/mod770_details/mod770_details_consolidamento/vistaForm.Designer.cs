
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


namespace mod770_details_consolidamento {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaForm: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable mod770_details{get { return this.Tables["mod770_details"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable modello770{get { return this.Tables["modello770"];}}

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
public new System.Data.DataTableCollection Tables {get {return base.Tables;}}

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
	T= new DataTable("mod770_details");
	C= new DataColumn("ayear", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("frame", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("colnumber", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("description", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("fieldlen", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("format", typeof(System.String), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("colorder", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("row", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("position", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("section", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("admittedvalues", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("blockingcontrols", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("correspondence", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[3]{
	T.Columns["ayear"], 	T.Columns["frame"], 	T.Columns["colnumber"]};
	T.PrimaryKey = key;

	T= new DataTable("modello770");
	C= new DataColumn("iddip", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("progr", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("quadro", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("riga", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("colonna", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("stringa", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("intero", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("data", typeof(System.DateTime), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[5]{
	T.Columns["iddip"], 	T.Columns["progr"], 	T.Columns["quadro"], 	T.Columns["riga"], 	T.Columns["colonna"]};
	T.PrimaryKey = key;

}
}
}
