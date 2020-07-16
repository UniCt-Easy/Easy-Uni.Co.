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

namespace bankdispositionsetup_import {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaForm: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable bill{get { return Tables["bill"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable banktransaction{get { return Tables["banktransaction"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable flussobanca{get { return Tables["flussobanca"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable expenseview{get { return Tables["expenseview"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable incomeview{get { return Tables["incomeview"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable proceeds_bankview{get { return Tables["proceeds_bankview"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable payment_bankview{get { return Tables["payment_bankview"];}}

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
	T= new DataTable("bill");
	C= new DataColumn("ybill", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nbill", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("billkind", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("registry", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("covered", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("total", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("adate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("active", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("motive", typeof(System.String), ""));
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

	T.Columns.Add(new DataColumn("idtreasurer", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[3]{
	T.Columns["ybill"], 	T.Columns["nbill"], 	T.Columns["billkind"]};
	T.PrimaryKey = key;

	T= new DataTable("banktransaction");
	C= new DataColumn("nban", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("yban", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("amount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("bankreference", typeof(System.String), ""));
	C= new DataColumn("kind", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("kpay", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("kpro", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("transactiondate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("valuedate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("idpay", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idpro", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idexp", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idinc", typeof(System.Int32), ""));
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
	key = new DataColumn[2]{
	T.Columns["nban"], 	T.Columns["yban"]};
	T.PrimaryKey = key;

	T= new DataTable("flussobanca");
	T.Columns.Add(new DataColumn("SEGNO", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("tipomovbancario", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("NUMQUI", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("ISTTS", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("CODEN", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("ESERC", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("TIPDOC", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("NUMDOC", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("PRODOC", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("CAPBIL", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("ARTBIL", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("CDMEC", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("ANNOCO", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("IMPDOC", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("DTELAB", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("DTPAG", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("DVAL", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("NUMDIS", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("IMPRIT", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("INDREG", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("DVALBE", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("NUMPRA", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CODVER", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("NUMPRR", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("PROGPR", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("IBOLLI", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("INDBOL", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ICOMM", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("INDCOM", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ISPE", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("INDSPE", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("TPAGTS", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CODABI", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CODCAB", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CONTO", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CIN", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("IBAN_PAE", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("IBAN_CHK", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("IBAN_COO", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("NCNT", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CTIPIPU", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("DESVER", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CCGU", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CCPV", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CCUP", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("FILLER", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ANABE", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("INDIR", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CAP", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("LOC", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CFISC", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CAUSALE", typeof(System.String), ""));
	Tables.Add(T);
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
	T.Columns.Add(new DataColumn("kpay", typeof(System.Int32), ""));
	C= new DataColumn("ypay", typeof(System.Int16), "");
	C.ReadOnly=true;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("npay", typeof(System.Int32), ""));
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
	T.Columns.Add(new DataColumn("iban", typeof(System.String), ""));
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
	C= new DataColumn("flagarrear", typeof(System.String), "");
	C.ReadOnly=true;
	T.Columns.Add(C);

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
	T= new DataTable("incomeview");
	C= new DataColumn("idinc", typeof(System.Int32), "");
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

	T.Columns.Add(new DataColumn("parentymov", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("parentnmov", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("parentidinc", typeof(System.Int32), ""));
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
	T.Columns.Add(new DataColumn("kpro", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("ypro", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("npro", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("doc", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("docdate", typeof(System.DateTime), ""));
	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("amount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("ayearstartamount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("curramount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("available", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("unpartitioned", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("flag", typeof(System.Byte), ""));
	C= new DataColumn("totflag", typeof(System.Byte), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("flagarrear", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("autokind", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("autocode", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idpayment", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("expiration", typeof(System.DateTime), ""));
	C= new DataColumn("adate", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("nbill", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idpro", typeof(System.Int32), ""));
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
	T= new DataTable("proceeds_bankview");
	C= new DataColumn("kpro", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idpro", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ypro", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("npro", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idreg", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("registry", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("description", typeof(System.String), ""));
	C= new DataColumn("amount", typeof(System.Decimal), "");
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
	key = new DataColumn[2]{
	T.Columns["kpro"], 	T.Columns["idpro"]};
	T.PrimaryKey = key;

	T= new DataTable("payment_bankview");
	C= new DataColumn("kpay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idpay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ypay", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("npay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idreg", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("registry", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("description", typeof(System.String), ""));
	C= new DataColumn("amount", typeof(System.Decimal), "");
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
	key = new DataColumn[2]{
	T.Columns["kpay"], 	T.Columns["idpay"]};
	T.PrimaryKey = key;


//Relations
DataTable TPar;
DataTable TChild;
DataColumn []CPar;
DataColumn []CChild;
TPar= Tables["proceeds_bankview"];
TChild= Tables["banktransaction"];
CPar = new DataColumn[2]{TPar.Columns["kpro"], TPar.Columns["idpro"]};
CChild = new DataColumn[2]{TChild.Columns["kpro"], TChild.Columns["idpro"]};
Relations.Add(new DataRelation("proceeds_bankview_banktransaction",CPar,CChild));

TPar= Tables["payment_bankview"];
TChild= Tables["banktransaction"];
CPar = new DataColumn[2]{TPar.Columns["kpay"], TPar.Columns["idpay"]};
CChild = new DataColumn[2]{TChild.Columns["kpay"], TChild.Columns["idpay"]};
Relations.Add(new DataRelation("payment_bankview_banktransaction",CPar,CChild));

}
}
}
