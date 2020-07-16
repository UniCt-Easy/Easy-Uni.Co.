/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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

namespace sortinglevel_default {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaForm: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable sortinglevel{get { return this.Tables["sortinglevel"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable sortingkind{get { return this.Tables["sortingkind"];}}

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
	T= new DataTable("sortinglevel");
	C= new DataColumn("nlevel", typeof(System.Byte), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idsorkind", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

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

	C= new DataColumn("flag", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["nlevel"], 	T.Columns["idsorkind"]};
	T.PrimaryKey = key;

	T= new DataTable("sortingkind");
	C= new DataColumn("idsorkind", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("nphaseincome", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("nphaseexpense", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("flag", typeof(System.Byte), ""));
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

	T.Columns.Add(new DataColumn("labeln1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedn1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedn1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labeln2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedn2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedn2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labeln3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedn3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedn3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labeln4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedn4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedn4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labeln5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedn5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedn5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labels1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockeds1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forceds1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labels2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockeds2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forceds2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labels3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockeds3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forceds3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labels4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockeds4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forceds4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labels5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockeds5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forceds5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagdate", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labelfordate", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("nodatelabel", typeof(System.String), ""));
	C= new DataColumn("codesorkind", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idsorkind"]};
	T.PrimaryKey = key;


//Relations
DataTable TPar;
DataTable TChild;
DataColumn []CPar;
DataColumn []CChild;
TPar= Tables["sortingkind"];
TChild= Tables["sortinglevel"];
CPar = new DataColumn[1]{TPar.Columns["idsorkind"]};
CChild = new DataColumn[1]{TChild.Columns["idsorkind"]};
Relations.Add(new DataRelation("sortingkindsortinglevel",CPar,CChild));

}
}
}
