
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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


namespace unifiedivapay_default {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaForm: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable unifiedivapay{get { return this.Tables["unifiedivapay"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable department{get { return this.Tables["department"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable ivaregisterkind{get { return this.Tables["ivaregisterkind"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable unifiedivapaydetail{get { return this.Tables["unifiedivapaydetail"];}}

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
	T= new DataTable("unifiedivapay");
	C= new DataColumn("yunifiedivapay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nunifiedivapay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("iddepartment", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("assesmentdate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("creditamount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("creditamountdeferred", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("debitamount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("debitamountdeferred", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("paymentamount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("refundamount", typeof(System.Decimal), ""));
	C= new DataColumn("paymentkind", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("start", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("stop", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("paymentdetails", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("mixed", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("prorata", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("dateivapay", typeof(System.DateTime), ""));
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
	key = new DataColumn[3]{
	T.Columns["yunifiedivapay"], 	T.Columns["nunifiedivapay"], 	T.Columns["iddepartment"]};
	T.PrimaryKey = key;

	T= new DataTable("department");
	C= new DataColumn("iddepartment", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("server", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("db", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("userdep", typeof(System.String), ""));
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
	T.Columns["iddepartment"]};
	T.PrimaryKey = key;

	T= new DataTable("ivaregisterkind");
	C= new DataColumn("idivaregisterkind", typeof(System.Int32), "");
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

	C= new DataColumn("registerclass", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idivaregisterkindunified", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idivaregisterkind"]};
	T.PrimaryKey = key;

	T= new DataTable("unifiedivapaydetail");
	C= new DataColumn("yunifiedivapay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nunifiedivapay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idivaregisterkindunified", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("iddepartment", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("iva", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("ivadeferred", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("unabatable", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("unabatabledeferred", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("ivanet", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("ivanetdeferred", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("prorata", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("mixed", typeof(System.Decimal), ""));
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

	T.Columns.Add(new DataColumn("!ivacredit", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("!department", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("!registerkindunified", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("!registerclass", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[4]{
	T.Columns["yunifiedivapay"], 	T.Columns["nunifiedivapay"], 	T.Columns["idivaregisterkindunified"], 	T.Columns["iddepartment"]};
	T.PrimaryKey = key;


//Relations
DataTable TPar;
DataTable TChild;
DataColumn []CPar;
DataColumn []CChild;
TPar= Tables["ivaregisterkind"];
TChild= Tables["unifiedivapaydetail"];
CPar = new DataColumn[1]{TPar.Columns["idivaregisterkindunified"]};
CChild = new DataColumn[1]{TChild.Columns["idivaregisterkindunified"]};
Relations.Add(new DataRelation("ivaregisterkindunifiedivapaydetail",CPar,CChild));

TPar= Tables["unifiedivapay"];
TChild= Tables["unifiedivapaydetail"];
CPar = new DataColumn[3]{TPar.Columns["yunifiedivapay"], TPar.Columns["nunifiedivapay"], TPar.Columns["iddepartment"]};
CChild = new DataColumn[3]{TChild.Columns["yunifiedivapay"], TChild.Columns["nunifiedivapay"], TChild.Columns["iddepartment"]};
Relations.Add(new DataRelation("unifiedivapayunifiedivapaydetail",CPar,CChild));

TPar= Tables["department"];
TChild= Tables["unifiedivapaydetail"];
CPar = new DataColumn[1]{TPar.Columns["iddepartment"]};
CChild = new DataColumn[1]{TChild.Columns["iddepartment"]};
Relations.Add(new DataRelation("departmentunifiedivapaydetail",CPar,CChild));

TPar= Tables["department"];
TChild= Tables["unifiedivapay"];
CPar = new DataColumn[1]{TPar.Columns["iddepartment"]};
CChild = new DataColumn[1]{TChild.Columns["iddepartment"]};
Relations.Add(new DataRelation("departmentunifiedivapay",CPar,CChild));

}
}
}
