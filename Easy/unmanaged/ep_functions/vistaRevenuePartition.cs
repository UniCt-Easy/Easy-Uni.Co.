/*
    Easy
    Copyright (C) 2019 Universit� degli Studi di Catania (www.unict.it)

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

namespace ep_functions {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaRevenuePartition: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable revenuepartition{get { return Tables["revenuepartition"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable revenuepartitiondetail{get { return Tables["revenuepartitiondetail"];}}

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
public new System.Data.DataTableCollection Tables {get {return base.Tables;}}

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
public new System.Data.DataRelationCollection Relations {get {return base.Relations; } } 

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
public vistaRevenuePartition(){
BeginInit();
InitClass();
EndInit();
}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
private void InitClass() {
DataSetName = "vistaRevenuePartition";
Prefix = "";
Namespace = "http://tempuri.org/vistaRevenuePartition.xsd";
EnforceConstraints = false;
	DataTable T;
	DataColumn C;
	DataColumn [] key;
	T= new DataTable("revenuepartition");
	C= new DataColumn("idrevenuepartition", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("title", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("kind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("lu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ct", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("cu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("revenuepartitioncode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("active", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("description", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idrevenuepartition"]};
	T.PrimaryKey = key;

	T= new DataTable("revenuepartitiondetail");
	C= new DataColumn("idrevenuepartition", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("iddetail", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("rate", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("amount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("lu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ct", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("cu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idsor1", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor2", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor3", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["idrevenuepartition"], 	T.Columns["iddetail"]};
	T.PrimaryKey = key;


//Relations
DataTable TPar;
DataTable TChild;
DataColumn []CPar;
DataColumn []CChild;
TPar= Tables["revenuepartition"];
TChild= Tables["revenuepartitiondetail"];
CPar = new DataColumn[1]{TPar.Columns["idrevenuepartition"]};
CChild = new DataColumn[1]{TChild.Columns["idrevenuepartition"]};
Relations.Add(new DataRelation("revenuepartition_revenuepartitiondetail",CPar,CChild));

}
}
}
