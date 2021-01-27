
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


namespace no_table_esitomandati {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaForm: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable paymentview{get { return Tables["paymentview"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable banktransaction{get { return Tables["banktransaction"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable expenseview{get { return Tables["expenseview"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable no_table{get { return Tables["no_table"];}}

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
	T= new DataTable("paymentview");
	C= new DataColumn("kpay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ypay", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("npay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("npay_treasurer", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("total", typeof(System.Decimal), ""));
	C= new DataColumn("performed", typeof(System.Decimal), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idstamphandling", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("stamphandling", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idtreasurer", typeof(System.Int32), ""));
	C= new DataColumn("kind", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idreg", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("registry", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idfin", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("codefin", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("finance", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idman", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("manager", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("kpaymenttransmission", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("ypaymenttransmission", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("npaymenttransmission", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("transmissiondate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("adate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("printdate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("annulmentdate", typeof(System.DateTime), ""));
	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["kpay"]};
	T.PrimaryKey = key;

	T= new DataTable("banktransaction");
	C= new DataColumn("yban", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nban", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("kind", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("bankreference", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("transactiondate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("valuedate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("amount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("kpay", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("kpro", typeof(System.Int32), ""));
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

	T.Columns.Add(new DataColumn("idpay", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idpro", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idexp", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idinc", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["yban"], 	T.Columns["nban"]};
	T.PrimaryKey = key;

	T= new DataTable("expenseview");
	C= new DataColumn("idexp", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nphase", typeof(System.Byte), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("phase", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ymov", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nmov", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("ypay", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("kpay", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("npay", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("parentidexp", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("parentymov", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("parentnmov", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idformerexpense", typeof(System.Int32), ""));
	C= new DataColumn("ayear", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idfin", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("codefin", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("finance", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idupb", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("codeupb", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("upb", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idreg", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("registry", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idman", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("manager", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("paymentadate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("doc", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("docdate", typeof(System.DateTime), ""));
	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("amount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("ayearstartamount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("curramount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("available", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("idregistrypaymethod", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idpaymethod", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("cin", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idbank", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idcab", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cc", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("iddeputy", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("deputy", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("refexternaldoc", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("paymentdescr", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idser", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("service", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("servicestart", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("servicestop", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("ivaamount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("flag", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("totflag", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("flagarrear", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("autokind", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("idpayment", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("expiration", typeof(System.DateTime), ""));
	C= new DataColumn("adate", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("autocode", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idclawback", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("clawback", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("nbill", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idpay", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
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
	T= new DataTable("no_table");
	C= new DataColumn("idnotable", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idnotable"]};
	T.PrimaryKey = key;


//Relations
DataTable TPar;
DataTable TChild;
DataColumn []CPar;
DataColumn []CChild;
TPar= Tables["expenseview"];
TChild= Tables["banktransaction"];
CPar = new DataColumn[1]{TPar.Columns["idexp"]};
CChild = new DataColumn[1]{TChild.Columns["idexp"]};
Relations.Add(new DataRelation("FK_expenseview_banktransaction",CPar,CChild));

}
}
}
