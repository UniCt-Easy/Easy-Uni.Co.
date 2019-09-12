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

namespace notable_importazione {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaClassMov: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable expensesorted{get { return this.Tables["expensesorted"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable incomesorted{get { return this.Tables["incomesorted"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable sortingkind{get { return this.Tables["sortingkind"];}}

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
public new System.Data.DataTableCollection Tables {get {return base.Tables;}}

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
public vistaClassMov(){
this.BeginInit();
this.InitClass();
this.EndInit();
}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
private void InitClass() {
this.DataSetName = "vistaClassMov";
this.Prefix = "";
this.Namespace = "http://tempuri.org/vistaClassMov.xsd";
this.EnforceConstraints = false;
	DataTable T;
	DataColumn C;
	DataColumn [] key;
	T= new DataTable("expensesorted");
	C= new DataColumn("idsubclass", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("amount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("ayear", typeof(System.Int16), ""));
	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("description", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagnodate", typeof(System.String), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("paridsor", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("paridsubclass", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
	T.Columns.Add(new DataColumn("start", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("stop", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("tobecontinued", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("valuen1", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("valuen2", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("valuen3", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("valuen4", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("valuen5", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("values1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("values2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("values3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("values4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("values5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("valuev1", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("valuev2", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("valuev3", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("valuev4", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("valuev5", typeof(System.Decimal), ""));
	C= new DataColumn("idexp", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idsor", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	Tables.Add(T);
//Primary Key
	key = new DataColumn[3]{
	T.Columns["idsubclass"], 	T.Columns["idexp"], 	T.Columns["idsor"]};
	T.PrimaryKey = key;

	T= new DataTable("incomesorted");
	C= new DataColumn("idsubclass", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("amount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("ayear", typeof(System.Int16), ""));
	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("description", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagnodate", typeof(System.String), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("paridsor", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("paridsubclass", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
	T.Columns.Add(new DataColumn("start", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("stop", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("tobecontinued", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("valuen1", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("valuen2", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("valuen3", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("valuen4", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("valuen5", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("values1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("values2", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("values3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("values4", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("values5", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("valuev1", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("valuev2", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("valuev3", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("valuev4", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("valuev5", typeof(System.Decimal), ""));
	C= new DataColumn("idinc", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idsor", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	Tables.Add(T);
//Primary Key
	key = new DataColumn[3]{
	T.Columns["idsubclass"], 	T.Columns["idinc"], 	T.Columns["idsor"]};
	T.PrimaryKey = key;

	T= new DataTable("sortingkind");
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

	T.Columns.Add(new DataColumn("start", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("stop", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("idparentkind", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idsorkind"]};
	T.PrimaryKey = key;

}
}
}
