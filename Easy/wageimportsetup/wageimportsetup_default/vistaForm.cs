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

namespace wageimportsetup_default {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaForm: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable wageimportsetup{get { return this.Tables["wageimportsetup"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable sortingkind_fin{get { return this.Tables["sortingkind_fin"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable sortingkind_sortingmaster1{get { return this.Tables["sortingkind_sortingmaster1"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable sortingkind_service{get { return this.Tables["sortingkind_service"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable sortingkind_upb{get { return this.Tables["sortingkind_upb"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable sortingkind_tax{get { return this.Tables["sortingkind_tax"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable sortingkind_registry{get { return this.Tables["sortingkind_registry"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable sortingkind_sortingmaster2{get { return this.Tables["sortingkind_sortingmaster2"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable sortingkind_sortingmaster5{get { return this.Tables["sortingkind_sortingmaster5"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable sortingkind_sortingmaster3{get { return this.Tables["sortingkind_sortingmaster3"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable sortingkind_sortingmaster4{get { return this.Tables["sortingkind_sortingmaster4"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable sortingkind_sortingchild1{get { return this.Tables["sortingkind_sortingchild1"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable sortingkind_sortingchild5{get { return this.Tables["sortingkind_sortingchild5"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable sortingkind_sortingchild3{get { return this.Tables["sortingkind_sortingchild3"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable sortingkind_sortingchild2{get { return this.Tables["sortingkind_sortingchild2"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable sortingkind_sortingchild4{get { return this.Tables["sortingkind_sortingchild4"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable sortingkind_clawback{get { return this.Tables["sortingkind_clawback"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable sortingkind_accmotivegroup1{get { return this.Tables["sortingkind_accmotivegroup1"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable sortingkind_accmotivegroup2{get { return this.Tables["sortingkind_accmotivegroup2"];}}

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
	T= new DataTable("wageimportsetup");
	C= new DataColumn("idwageimportsetup", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idsorkind_fin", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsorkind_upb", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsorkind_registry", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsorkind_tax", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsorkind_clawback", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsorkind_service", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsorkind_sortingmaster1", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsorkind_sortingmaster2", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsorkind_sortingmaster3", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsorkind_sortingmaster4", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsorkind_sortingmaster5", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsorkind_sortingchild1", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsorkind_sortingchild2", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsorkind_sortingchild3", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsorkind_sortingchild4", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsorkind_sortingchild5", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsorkind_accmotivegroup1", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsorkind_accmotivegroup2", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("listfield", typeof(System.String), ""));
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

	T.Columns.Add(new DataColumn("kind", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idwageimportsetup"]};
	T.PrimaryKey = key;

	T= new DataTable("sortingkind_fin");
	C= new DataColumn("idsorkind", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("active", typeof(System.String), ""));
	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

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

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idsorkind"]};
	T.PrimaryKey = key;

	T= new DataTable("sortingkind_sortingmaster1");
	C= new DataColumn("idsorkind", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("active", typeof(System.String), ""));
	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

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

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idsorkind"]};
	T.PrimaryKey = key;

	T= new DataTable("sortingkind_service");
	C= new DataColumn("idsorkind", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("active", typeof(System.String), ""));
	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

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

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idsorkind"]};
	T.PrimaryKey = key;

	T= new DataTable("sortingkind_upb");
	C= new DataColumn("idsorkind", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("active", typeof(System.String), ""));
	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

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

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idsorkind"]};
	T.PrimaryKey = key;

	T= new DataTable("sortingkind_tax");
	C= new DataColumn("idsorkind", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("active", typeof(System.String), ""));
	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

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

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idsorkind"]};
	T.PrimaryKey = key;

	T= new DataTable("sortingkind_registry");
	C= new DataColumn("idsorkind", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("active", typeof(System.String), ""));
	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

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

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idsorkind"]};
	T.PrimaryKey = key;

	T= new DataTable("sortingkind_sortingmaster2");
	C= new DataColumn("idsorkind", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("active", typeof(System.String), ""));
	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

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

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idsorkind"]};
	T.PrimaryKey = key;

	T= new DataTable("sortingkind_sortingmaster5");
	C= new DataColumn("idsorkind", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("active", typeof(System.String), ""));
	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

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

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idsorkind"]};
	T.PrimaryKey = key;

	T= new DataTable("sortingkind_sortingmaster3");
	C= new DataColumn("idsorkind", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("active", typeof(System.String), ""));
	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

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

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idsorkind"]};
	T.PrimaryKey = key;

	T= new DataTable("sortingkind_sortingmaster4");
	C= new DataColumn("idsorkind", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("active", typeof(System.String), ""));
	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

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

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idsorkind"]};
	T.PrimaryKey = key;

	T= new DataTable("sortingkind_sortingchild1");
	C= new DataColumn("idsorkind", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("active", typeof(System.String), ""));
	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

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

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idsorkind"]};
	T.PrimaryKey = key;

	T= new DataTable("sortingkind_sortingchild5");
	C= new DataColumn("idsorkind", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("active", typeof(System.String), ""));
	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

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

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idsorkind"]};
	T.PrimaryKey = key;

	T= new DataTable("sortingkind_sortingchild3");
	C= new DataColumn("idsorkind", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("active", typeof(System.String), ""));
	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

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

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idsorkind"]};
	T.PrimaryKey = key;

	T= new DataTable("sortingkind_sortingchild2");
	C= new DataColumn("idsorkind", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("active", typeof(System.String), ""));
	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

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

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idsorkind"]};
	T.PrimaryKey = key;

	T= new DataTable("sortingkind_sortingchild4");
	C= new DataColumn("idsorkind", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("active", typeof(System.String), ""));
	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

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

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idsorkind"]};
	T.PrimaryKey = key;

	T= new DataTable("sortingkind_clawback");
	C= new DataColumn("idsorkind", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("active", typeof(System.String), ""));
	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

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

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idsorkind"]};
	T.PrimaryKey = key;

	T= new DataTable("sortingkind_accmotivegroup1");
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

	T.Columns.Add(new DataColumn("flagdate", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedN1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedN2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedN3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedN4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedN5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedS1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedS2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedS3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedS4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedS5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedv1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedv2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedv3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedv4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedv5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labelfordate", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labeln1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labeln2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labeln3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labeln4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labeln5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labels1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labels2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labels3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labels4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labels5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labelv1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labelv2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labelv3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labelv4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labelv5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedN1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedN2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedN3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedN4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedN5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedS1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedS2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedS3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedS4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedS5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedv1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedv2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedv3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedv4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedv5", typeof(System.String), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("nodatelabel", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("totalexpression", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("nphaseexpense", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("nphaseincome", typeof(System.Byte), ""));
	C= new DataColumn("codesorkind", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idsorkind", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("flag", typeof(System.Byte), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idsorkind"]};
	T.PrimaryKey = key;

	T= new DataTable("sortingkind_accmotivegroup2");
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

	T.Columns.Add(new DataColumn("flagdate", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedN1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedN2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedN3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedN4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedN5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedS1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedS2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedS3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedS4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedS5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedv1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedv2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedv3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedv4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("forcedv5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labelfordate", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labeln1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labeln2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labeln3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labeln4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labeln5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labels1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labels2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labels3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labels4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labels5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labelv1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labelv2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labelv3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labelv4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("labelv5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedN1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedN2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedN3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedN4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedN5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedS1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedS2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedS3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedS4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedS5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedv1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedv2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedv3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedv4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lockedv5", typeof(System.String), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("nodatelabel", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("totalexpression", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("nphaseexpense", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("nphaseincome", typeof(System.Byte), ""));
	C= new DataColumn("codesorkind", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idsorkind", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("flag", typeof(System.Byte), "");
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
TPar= Tables["sortingkind_fin"];
TChild= Tables["wageimportsetup"];
CPar = new DataColumn[1]{TPar.Columns["idsorkind"]};
CChild = new DataColumn[1]{TChild.Columns["idsorkind_fin"]};
Relations.Add(new DataRelation("sortingkind_finwageimportsetup",CPar,CChild));

TPar= Tables["sortingkind_upb"];
TChild= Tables["wageimportsetup"];
CPar = new DataColumn[1]{TPar.Columns["idsorkind"]};
CChild = new DataColumn[1]{TChild.Columns["idsorkind_upb"]};
Relations.Add(new DataRelation("sortingkind_upbwageimportsetup",CPar,CChild));

TPar= Tables["sortingkind_registry"];
TChild= Tables["wageimportsetup"];
CPar = new DataColumn[1]{TPar.Columns["idsorkind"]};
CChild = new DataColumn[1]{TChild.Columns["idsorkind_registry"]};
Relations.Add(new DataRelation("sortingkind_registrywageimportsetup",CPar,CChild));

TPar= Tables["sortingkind_tax"];
TChild= Tables["wageimportsetup"];
CPar = new DataColumn[1]{TPar.Columns["idsorkind"]};
CChild = new DataColumn[1]{TChild.Columns["idsorkind_tax"]};
Relations.Add(new DataRelation("sortingkind_taxwageimportsetup",CPar,CChild));

TPar= Tables["sortingkind_service"];
TChild= Tables["wageimportsetup"];
CPar = new DataColumn[1]{TPar.Columns["idsorkind"]};
CChild = new DataColumn[1]{TChild.Columns["idsorkind_service"]};
Relations.Add(new DataRelation("sortingkind_servicewageimportsetup",CPar,CChild));

TPar= Tables["sortingkind_sortingmaster1"];
TChild= Tables["wageimportsetup"];
CPar = new DataColumn[1]{TPar.Columns["idsorkind"]};
CChild = new DataColumn[1]{TChild.Columns["idsorkind_sortingmaster1"]};
Relations.Add(new DataRelation("sortingkind_sortingmaster1wageimportsetup",CPar,CChild));

TPar= Tables["sortingkind_sortingmaster2"];
TChild= Tables["wageimportsetup"];
CPar = new DataColumn[1]{TPar.Columns["idsorkind"]};
CChild = new DataColumn[1]{TChild.Columns["idsorkind_sortingmaster2"]};
Relations.Add(new DataRelation("sortingkind_sortingmaster2wageimportsetup",CPar,CChild));

TPar= Tables["sortingkind_sortingmaster3"];
TChild= Tables["wageimportsetup"];
CPar = new DataColumn[1]{TPar.Columns["idsorkind"]};
CChild = new DataColumn[1]{TChild.Columns["idsorkind_sortingmaster3"]};
Relations.Add(new DataRelation("sortingkind_sortingmaster3wageimportsetup",CPar,CChild));

TPar= Tables["sortingkind_sortingmaster4"];
TChild= Tables["wageimportsetup"];
CPar = new DataColumn[1]{TPar.Columns["idsorkind"]};
CChild = new DataColumn[1]{TChild.Columns["idsorkind_sortingmaster4"]};
Relations.Add(new DataRelation("sortingkind_sortingmaster4wageimportsetup",CPar,CChild));

TPar= Tables["sortingkind_sortingmaster5"];
TChild= Tables["wageimportsetup"];
CPar = new DataColumn[1]{TPar.Columns["idsorkind"]};
CChild = new DataColumn[1]{TChild.Columns["idsorkind_sortingmaster5"]};
Relations.Add(new DataRelation("sortingkind_sortingmaster5wageimportsetup",CPar,CChild));

TPar= Tables["sortingkind_sortingchild1"];
TChild= Tables["wageimportsetup"];
CPar = new DataColumn[1]{TPar.Columns["idsorkind"]};
CChild = new DataColumn[1]{TChild.Columns["idsorkind_sortingchild1"]};
Relations.Add(new DataRelation("sortingkind_sortingchild1wageimportsetup",CPar,CChild));

TPar= Tables["sortingkind_sortingchild2"];
TChild= Tables["wageimportsetup"];
CPar = new DataColumn[1]{TPar.Columns["idsorkind"]};
CChild = new DataColumn[1]{TChild.Columns["idsorkind_sortingchild2"]};
Relations.Add(new DataRelation("sortingkind_sortingchild2wageimportsetup",CPar,CChild));

TPar= Tables["sortingkind_sortingchild3"];
TChild= Tables["wageimportsetup"];
CPar = new DataColumn[1]{TPar.Columns["idsorkind"]};
CChild = new DataColumn[1]{TChild.Columns["idsorkind_sortingchild3"]};
Relations.Add(new DataRelation("sortingkind_sortingchild3wageimportsetup",CPar,CChild));

TPar= Tables["sortingkind_sortingchild4"];
TChild= Tables["wageimportsetup"];
CPar = new DataColumn[1]{TPar.Columns["idsorkind"]};
CChild = new DataColumn[1]{TChild.Columns["idsorkind_sortingchild4"]};
Relations.Add(new DataRelation("sortingkind_sortingchild4wageimportsetup",CPar,CChild));

TPar= Tables["sortingkind_sortingchild5"];
TChild= Tables["wageimportsetup"];
CPar = new DataColumn[1]{TPar.Columns["idsorkind"]};
CChild = new DataColumn[1]{TChild.Columns["idsorkind_sortingchild5"]};
Relations.Add(new DataRelation("sortingkind_sortingchild5wageimportsetup",CPar,CChild));

TPar= Tables["sortingkind_clawback"];
TChild= Tables["wageimportsetup"];
CPar = new DataColumn[1]{TPar.Columns["idsorkind"]};
CChild = new DataColumn[1]{TChild.Columns["idsorkind_clawback"]};
Relations.Add(new DataRelation("sortingkind_clawbackwageimportsetup",CPar,CChild));

TPar= Tables["sortingkind_accmotivegroup1"];
TChild= Tables["wageimportsetup"];
CPar = new DataColumn[1]{TPar.Columns["idsorkind"]};
CChild = new DataColumn[1]{TChild.Columns["idsorkind_accmotivegroup1"]};
Relations.Add(new DataRelation("sortingkind_accmotivegroup1_wageimportsetup",CPar,CChild));

TPar= Tables["sortingkind_accmotivegroup2"];
TChild= Tables["wageimportsetup"];
CPar = new DataColumn[1]{TPar.Columns["idsorkind"]};
CChild = new DataColumn[1]{TChild.Columns["idsorkind_accmotivegroup2"]};
Relations.Add(new DataRelation("sortingkind_accmotivegroup2_wageimportsetup",CPar,CChild));

}
}
}
