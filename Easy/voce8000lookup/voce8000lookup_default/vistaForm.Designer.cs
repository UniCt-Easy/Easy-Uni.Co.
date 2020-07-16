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

namespace voce8000lookup_default {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaForm: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable voce8000{get { return Tables["voce8000"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable voce8000lookup{get { return Tables["voce8000lookup"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable tax{get { return Tables["tax"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable voce8000_impon{get { return Tables["voce8000_impon"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable voce8000_quotaesente{get { return Tables["voce8000_quotaesente"];}}

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
public new System.Data.DataTableCollection Tables {get {return base.Tables;}}

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
public new System.Data.DataRelationCollection Relations {get {return base.Relations; } } 

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
public vistaForm(){
BeginInit();
InitClass();
EndInit();
}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
private void InitClass() {
DataSetName = "vistaForm";
Prefix = "";
Namespace = "http://tempuri.org/vistaForm.xsd";
EnforceConstraints = false;
	DataTable T;
	DataColumn C;
	DataColumn [] key;
	T= new DataTable("voce8000");
	C= new DataColumn("voce", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("description", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("active", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("kind", typeof(System.String), ""));
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

	T.Columns.Add(new DataColumn("capitolo", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["voce"]};
	T.PrimaryKey = key;

	T= new DataTable("voce8000lookup");
	C= new DataColumn("idvoce", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("conto", typeof(System.String), ""));
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

	T.Columns.Add(new DataColumn("servicekind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("taxref", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("voce", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("taxcode", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("voceimponibile", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagcsausability", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("vocequotaesente", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("capitolovoce", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("capitoloimponibile", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("capitoloquotaesente", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idvoce"]};
	T.PrimaryKey = key;

	T= new DataTable("tax");
	T.Columns.Add(new DataColumn("active", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("appliancebasis", typeof(System.String), ""));
	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("fiscaltaxcode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagunabatable", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("geoappliance", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idaccmotive_cost", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idaccmotive_debit", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idaccmotive_pay", typeof(System.String), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("taxablecode", typeof(System.String), ""));
	C= new DataColumn("taxref", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("taxcode", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("maintaxcode", typeof(System.Int32), ""));
	C= new DataColumn("taxkind", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["taxcode"]};
	T.PrimaryKey = key;

	T= new DataTable("voce8000_impon");
	C= new DataColumn("voce", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("description", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("active", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("kind", typeof(System.String), ""));
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
	key = new DataColumn[1]{
	T.Columns["voce"]};
	T.PrimaryKey = key;

	T= new DataTable("voce8000_quotaesente");
	C= new DataColumn("voce", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("description", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("active", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("kind", typeof(System.String), ""));
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
	key = new DataColumn[1]{
	T.Columns["voce"]};
	T.PrimaryKey = key;


//Relations
DataTable TPar;
DataTable TChild;
DataColumn []CPar;
DataColumn []CChild;
TPar= Tables["voce8000_impon"];
TChild= Tables["voce8000lookup"];
CPar = new DataColumn[1]{TPar.Columns["voce"]};
CChild = new DataColumn[1]{TChild.Columns["voceimponibile"]};
Relations.Add(new DataRelation("voce8000_impon_voce8000lookup",CPar,CChild));

TPar= Tables["tax"];
TChild= Tables["voce8000lookup"];
CPar = new DataColumn[2]{TPar.Columns["taxcode"], TPar.Columns["taxref"]};
CChild = new DataColumn[2]{TChild.Columns["taxcode"], TChild.Columns["taxref"]};
Relations.Add(new DataRelation("FK_tax_voce8000lookup",CPar,CChild));

TPar= Tables["voce8000"];
TChild= Tables["voce8000lookup"];
CPar = new DataColumn[1]{TPar.Columns["voce"]};
CChild = new DataColumn[1]{TChild.Columns["voce"]};
Relations.Add(new DataRelation("FK_voce8000_voce8000lookup",CPar,CChild));

TPar= Tables["voce8000_quotaesente"];
TChild= Tables["voce8000lookup"];
CPar = new DataColumn[1]{TPar.Columns["voce"]};
CChild = new DataColumn[1]{TChild.Columns["vocequotaesente"]};
Relations.Add(new DataRelation("voce8000_quotaesente_voce8000lookup",CPar,CChild));

}
}
}
