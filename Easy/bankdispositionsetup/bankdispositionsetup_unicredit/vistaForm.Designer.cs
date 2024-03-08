
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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


namespace bankdispositionsetup_unicredit {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaForm: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable EF06_TestaCoda{get { return Tables["EF06_TestaCoda"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable EF06{get { return Tables["EF06"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable IN0109{get { return Tables["IN0109"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable bankdispositionsetup{get { return Tables["bankdispositionsetup"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable banktransaction{get { return Tables["banktransaction"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable payment_bank{get { return Tables["payment_bank"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable proceeds_bank{get { return Tables["proceeds_bank"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable bill{get { return Tables["bill"];}}

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
	T= new DataTable("EF06_TestaCoda");
	T.Columns.Add(new DataColumn("ISTTS1", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("FILTESE", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CODENT1", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("ESERC1", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("TIPREC", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("WA035", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("WA040", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("FILLER", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("NOINC", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("SEGNO1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ITOIN2", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("NOPPAG", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("SEGNOP", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ITOPA2", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("SEGNOG", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("IGIACZ", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("IUTANZ", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("IVIANZ", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("IPROI1", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("IPROP1", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("IFCPR1", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("SEGNOF", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("BYTLEU", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("NOINC_", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("SEGNO1_", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ITOIN2_", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("NOPPAG_", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("SEGNOP_", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ITOPA2_", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("SEGNOG_", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("IGIACZ_", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("IUTANZ_", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("IVIANZ_", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("IPROI1_", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("IPROP1_", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("IFCPR1_", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("SEGNOF_", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("BYTLEU_", typeof(System.String), ""));
	Tables.Add(T);
	T= new DataTable("EF06");
	T.Columns.Add(new DataColumn("ISTTS1", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("FILTESE", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CODENT1", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("ESERC1", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("TIPREC", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("TIPDOC", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("NUMDO1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("PRODO1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CAPBI2", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("ARBTI2", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("ANNOC1", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("IMPMA1", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("SEGNOP", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("DTPAG9", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("DVALP2", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("PROST1", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("ANABE", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("DCAP", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CODGEN", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("IMPRI1", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("INDREG", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("DESTU", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("INDCBI", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CAUTS", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("NUMOA1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("PROGA1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("DVALB2", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("CODVER", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("NUMPRA", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("DESVER", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("NUMPR1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("PROGP1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("MANRI1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("PRORI1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("DTELT2", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("IBOLL1", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("INDBOL", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ICOMT1", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("INDCOM", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ISPEP1", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("INDSPT", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("BYTLEU", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("BYTLEC", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("INDMO", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("INDSI", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("TPAGTS", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("CABIT1", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("CABDTX", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("NUMBO", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CINRT", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CDMEC2", typeof(System.Int64), ""));
	T.Columns.Add(new DataColumn("IMPMA2", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("FILLER", typeof(System.String), ""));
	Tables.Add(T);
	T= new DataTable("IN0109");
	T.Columns.Add(new DataColumn("ISTTS", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("CODEN", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("ESERC", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("DESC", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("NDG", typeof(System.Int64), ""));
	T.Columns.Add(new DataColumn("DTELAB", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("FILTS", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("SEG_FDO", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("FDO", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("REV_INC", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("REV_CAR", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("IMP_PPI", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("MAN_PAG", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("MAN_CAR", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("IMP_PPP", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("SAL_DIR", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("SAL_FAT", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("FIDO", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("IMP_LIB", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("IMP_NTU", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("IMP_TU", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("IMP_ANT", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("FILLER", typeof(System.String), ""));
	Tables.Add(T);
	T= new DataTable("bankdispositionsetup");
	C= new DataColumn("ayear", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("appname", typeof(System.String), ""));
	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("electronictrasmission", typeof(System.String), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("motivelen", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("motiveprefix", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("motiveseparator", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("paymentsgroupingkind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("proceedsgroupingkind", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["ayear"]};
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

	T= new DataTable("payment_bank");
	C= new DataColumn("idpay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idreg", typeof(System.Int32), "");
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

	C= new DataColumn("kpay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["idpay"], 	T.Columns["kpay"]};
	T.PrimaryKey = key;

	T= new DataTable("proceeds_bank");
	C= new DataColumn("idpro", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idreg", typeof(System.Int32), "");
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

	C= new DataColumn("kpro", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["idpro"], 	T.Columns["kpro"]};
	T.PrimaryKey = key;

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

	Tables.Add(T);
//Primary Key
	key = new DataColumn[3]{
	T.Columns["ybill"], 	T.Columns["nbill"], 	T.Columns["billkind"]};
	T.PrimaryKey = key;


//Relations
DataTable TPar;
DataTable TChild;
DataColumn []CPar;
DataColumn []CChild;
TPar= Tables["payment_bank"];
TChild= Tables["banktransaction"];
CPar = new DataColumn[1]{TPar.Columns["idpay"]};
CChild = new DataColumn[1]{TChild.Columns["idpay"]};
Relations.Add(new DataRelation("payment_bankbanktransaction",CPar,CChild));

TPar= Tables["proceeds_bank"];
TChild= Tables["banktransaction"];
CPar = new DataColumn[1]{TPar.Columns["idpro"]};
CChild = new DataColumn[1]{TChild.Columns["idpro"]};
Relations.Add(new DataRelation("proceeds_bankbanktransaction",CPar,CChild));

}
}
}
