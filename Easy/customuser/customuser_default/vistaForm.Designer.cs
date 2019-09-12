/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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

namespace customuser_default {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[Serializable()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaForm: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
public DataTable customuser{get { return this.Tables["customuser"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
public DataTable customusergroup{get { return this.Tables["customusergroup"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
public DataTable customgroup{get { return this.Tables["customgroup"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
public DataTable userenvironment{get { return this.Tables["userenvironment"];}}

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
this.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
	DataTable T;
	DataColumn C;
	DataColumn [] key;
	T= new DataTable("customuser");
	C= new DataColumn("idcustomuser", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("username", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("ct", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("cu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("lu", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idcustomuser"]};
	T.PrimaryKey = key;

	T= new DataTable("customusergroup");
	C= new DataColumn("idcustomgroup", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idcustomuser", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("lastmoduser", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lastmodtimestamp", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("ct", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("cu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("lu", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["idcustomgroup"], 	T.Columns["idcustomuser"]};
	T.PrimaryKey = key;

	T= new DataTable("customgroup");
	C= new DataColumn("idcustomgroup", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("groupname", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("description", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lastmoduser", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lastmodtimestamp", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("ct", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("cu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("lu", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idcustomgroup"]};
	T.PrimaryKey = key;

	T= new DataTable("userenvironment");
	C= new DataColumn("idcustomuser", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("variablename", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("value", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagadmin", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("kind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lu", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("!attuale", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["idcustomuser"], 	T.Columns["variablename"]};
	T.PrimaryKey = key;


//Relations
DataTable TPar;
DataTable TChild;
DataColumn []CPar;
DataColumn []CChild;
TPar= Tables["customuser"];
TChild= Tables["userenvironment"];
CPar = new DataColumn[1]{TPar.Columns["idcustomuser"]};
CChild = new DataColumn[1]{TChild.Columns["idcustomuser"]};
Relations.Add(new DataRelation("customuseruserenvironment",CPar,CChild));

TPar= Tables["customuser"];
TChild= Tables["customusergroup"];
CPar = new DataColumn[1]{TPar.Columns["idcustomuser"]};
CChild = new DataColumn[1]{TChild.Columns["idcustomuser"]};
Relations.Add(new DataRelation("customusercustomusergroup",CPar,CChild));

TPar= Tables["customgroup"];
TChild= Tables["customusergroup"];
CPar = new DataColumn[1]{TPar.Columns["idcustomgroup"]};
CChild = new DataColumn[1]{TChild.Columns["idcustomgroup"]};
Relations.Add(new DataRelation("customgroupcustomusergroup",CPar,CChild));

}
}
}
