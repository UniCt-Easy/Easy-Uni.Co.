
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


namespace admpay_expensesorted_detail {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaForm: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable admpay_expensesorted{get { return this.Tables["admpay_expensesorted"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable sorting{get { return this.Tables["sorting"];}}
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
	T= new DataTable("admpay_expensesorted");
	C= new DataColumn("yadmpay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nadmpay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nexpense", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idsor", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idsubclass", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("amount", typeof(System.Decimal), "");
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

	Tables.Add(T);
//Primary Key
	key = new DataColumn[5]{
	T.Columns["idsor"], 	T.Columns["idsubclass"], 	T.Columns["nadmpay"], 	T.Columns["nexpense"], 	T.Columns["yadmpay"]};
	T.PrimaryKey = key;

	T= new DataTable("sorting");
	C= new DataColumn("idsor", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idsorkind", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("defaultN1", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("defaultN2", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("defaultN3", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("defaultN4", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("defaultN5", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("defaultS1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaultS2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaultS3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaultS4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaultS5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("defaultv1", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("defaultv2", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("defaultv3", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("defaultv4", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("defaultv5", typeof(System.Decimal), ""));
	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("flagnodate", typeof(System.String), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("movkind", typeof(System.String), ""));
	C= new DataColumn("nlevel", typeof(System.Byte), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("paridsor", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("printingorder", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
	C= new DataColumn("sortcode", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idsor"]};
	T.PrimaryKey = key;

	T= new DataTable("sortinglevel");
	C= new DataColumn("idsorkind", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nlevel", typeof(System.Byte), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

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

	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["idsorkind"], 	T.Columns["nlevel"]};
	T.PrimaryKey = key;

	T= new DataTable("sortingkind");
	C= new DataColumn("idsorkind", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

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
	T.Columns.Add(new DataColumn("nphaseexpense", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("nphaseincome", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("totalexpression", typeof(System.String), ""));
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
TChild= Tables["sorting"];
CPar = new DataColumn[1]{TPar.Columns["idsorkind"]};
CChild = new DataColumn[1]{TChild.Columns["idsorkind"]};
Relations.Add(new DataRelation("sortingkindsorting",CPar,CChild));

TPar= Tables["sortinglevel"];
TChild= Tables["sorting"];
CPar = new DataColumn[2]{TPar.Columns["idsorkind"], TPar.Columns["nlevel"]};
CChild = new DataColumn[2]{TChild.Columns["idsorkind"], TChild.Columns["nlevel"]};
Relations.Add(new DataRelation("sortinglevelsorting",CPar,CChild));

TPar= Tables["sorting"];
TChild= Tables["admpay_expensesorted"];
CPar = new DataColumn[1]{TPar.Columns["idsor"]};
CChild = new DataColumn[1]{TChild.Columns["idsor"]};
Relations.Add(new DataRelation("sortingadmpay_expensesorted",CPar,CChild));

}
}
}
