
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


namespace notable_importazione {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaManReve: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable payment{get { return Tables["payment"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable proceeds{get { return Tables["proceeds"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable treasurer{get { return Tables["treasurer"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable manager{get { return Tables["manager"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable fin{get { return Tables["fin"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable stamphandling{get { return Tables["stamphandling"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable paymenttransmission{get { return Tables["paymenttransmission"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable proceedstransmission{get { return Tables["proceedstransmission"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable division{get { return Tables["division"];}}

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
public new System.Data.DataTableCollection Tables {get {return base.Tables;}}

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
public new System.Data.DataRelationCollection Relations {get {return base.Relations; } } 

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
public vistaManReve(){
BeginInit();
InitClass();
EndInit();
}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
private void InitClass() {
DataSetName = "vistaManReve";
Prefix = "";
Namespace = "http://tempuri.org/vistaManReve.xsd";
EnforceConstraints = false;
	DataTable T;
	DataColumn C;
	DataColumn [] key;
	T= new DataTable("payment");
	C= new DataColumn("npay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ypay", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("adate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("annulmentdate", typeof(System.DateTime), ""));
	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idreg", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("lt", typeof(System.DateTime), ""));
	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("printdate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idfin", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idman", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idstamphandling", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idtreasurer", typeof(System.Int32), ""));
	C= new DataColumn("flag", typeof(System.Byte), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("kpay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("kpaymenttransmission", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("external_reference", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("npay_treasurer", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["kpay"]};
	T.PrimaryKey = key;

	T= new DataTable("proceeds");
	C= new DataColumn("npro", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ypro", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("adate", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("annulmentdate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("ct", typeof(System.DateTime), ""));
	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idreg", typeof(System.Int32), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("printdate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idfin", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idman", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idtreasurer", typeof(System.Int32), ""));
	C= new DataColumn("flag", typeof(System.Byte), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("kpro", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("kproceedstransmission", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idstamphandling", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("external_reference", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("npro_treasurer", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["kpro"]};
	T.PrimaryKey = key;

	T= new DataTable("treasurer");
	T.Columns.Add(new DataColumn("address", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("agencycodefortransmission", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cabcodefortransmission", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cap", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cc", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cin", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("city", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("country", typeof(System.String), ""));
	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("depcodefortransmission", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("description", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("faxnumber", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("faxprefix", typeof(System.String), ""));
	C= new DataColumn("flagdefault", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idaccmotive_payment", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idaccmotive_proceeds", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idbank", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idcab", typeof(System.String), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idsor01", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor02", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor03", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor04", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor05", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("phonenumber", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("phoneprefix", typeof(System.String), ""));
	C= new DataColumn("codetreasurer", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idtreasurer", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("spexportexp", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagmultiexp", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("fileextension", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("spexportinc", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("iban", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("bic", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagfruitful", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idtreasurer"]};
	T.PrimaryKey = key;

	T= new DataTable("manager");
	T.Columns.Add(new DataColumn("active", typeof(System.String), ""));
	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("email", typeof(System.String), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("passwordweb", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("phonenumber", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
	C= new DataColumn("title", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("userweb", typeof(System.String), ""));
	C= new DataColumn("idman", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("iddivision", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idman"]};
	T.PrimaryKey = key;

	T= new DataTable("fin");
	C= new DataColumn("ayear", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("codefin", typeof(System.String), "");
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

	C= new DataColumn("printingorder", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
	C= new DataColumn("title", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	C= new DataColumn("idfin", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("paridfin", typeof(System.Int32), ""));
	C= new DataColumn("nlevel", typeof(System.Byte), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("flag", typeof(System.Byte), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idfin"]};
	T.PrimaryKey = key;

	T= new DataTable("stamphandling");
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

	C= new DataColumn("flagdefault", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("handlingbankcode", typeof(System.String), ""));
	C= new DataColumn("idstamphandling", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idstamphandling"]};
	T.PrimaryKey = key;

	T= new DataTable("paymenttransmission");
	C= new DataColumn("npaymenttransmission", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ypaymenttransmission", typeof(System.Int16), "");
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

	T.Columns.Add(new DataColumn("transmissiondate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("idman", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idtreasurer", typeof(System.Int32), ""));
	C= new DataColumn("kpaymenttransmission", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("transmissionkind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagmailsent", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["kpaymenttransmission"]};
	T.PrimaryKey = key;

	T= new DataTable("proceedstransmission");
	C= new DataColumn("nproceedstransmission", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("yproceedstransmission", typeof(System.Int16), "");
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

	T.Columns.Add(new DataColumn("transmissiondate", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("idman", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idtreasurer", typeof(System.Int32), ""));
	C= new DataColumn("kproceedstransmission", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("transmissionkind", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["kproceedstransmission"]};
	T.PrimaryKey = key;

	T= new DataTable("division");
	T.Columns.Add(new DataColumn("address", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cap", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("city", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("country", typeof(System.String), ""));
	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("faxnumber", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("faxprefix", typeof(System.String), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("phonenumber", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("phoneprefix", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	C= new DataColumn("codedivision", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("iddivision", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["iddivision"]};
	T.PrimaryKey = key;


//Relations
DataTable TPar;
DataTable TChild;
DataColumn []CPar;
DataColumn []CChild;
TPar= Tables["treasurer"];
TChild= Tables["proceedstransmission"];
CPar = new DataColumn[1]{TPar.Columns["idtreasurer"]};
CChild = new DataColumn[1]{TChild.Columns["idtreasurer"]};
Relations.Add(new DataRelation("treasurer_proceedstransmission",CPar,CChild));

TPar= Tables["treasurer"];
TChild= Tables["paymenttransmission"];
CPar = new DataColumn[1]{TPar.Columns["idtreasurer"]};
CChild = new DataColumn[1]{TChild.Columns["idtreasurer"]};
Relations.Add(new DataRelation("treasurer_paymenttransmission",CPar,CChild));

TPar= Tables["division"];
TChild= Tables["manager"];
CPar = new DataColumn[1]{TPar.Columns["iddivision"]};
CChild = new DataColumn[1]{TChild.Columns["iddivision"]};
Relations.Add(new DataRelation("FK_division_manager",CPar,CChild));

TPar= Tables["treasurer"];
TChild= Tables["proceeds"];
CPar = new DataColumn[1]{TPar.Columns["idtreasurer"]};
CChild = new DataColumn[1]{TChild.Columns["idtreasurer"]};
Relations.Add(new DataRelation("treasurer_proceeds",CPar,CChild));

TPar= Tables["manager"];
TChild= Tables["proceeds"];
CPar = new DataColumn[1]{TPar.Columns["idman"]};
CChild = new DataColumn[1]{TChild.Columns["idman"]};
Relations.Add(new DataRelation("manager_proceeds",CPar,CChild));

TPar= Tables["proceedstransmission"];
TChild= Tables["proceeds"];
CPar = new DataColumn[1]{TPar.Columns["kproceedstransmission"]};
CChild = new DataColumn[1]{TChild.Columns["kproceedstransmission"]};
Relations.Add(new DataRelation("proceedstransmission_proceeds",CPar,CChild));

TPar= Tables["treasurer"];
TChild= Tables["payment"];
CPar = new DataColumn[1]{TPar.Columns["idtreasurer"]};
CChild = new DataColumn[1]{TChild.Columns["idtreasurer"]};
Relations.Add(new DataRelation("treasurer_payment",CPar,CChild));

TPar= Tables["stamphandling"];
TChild= Tables["payment"];
CPar = new DataColumn[1]{TPar.Columns["idstamphandling"]};
CChild = new DataColumn[1]{TChild.Columns["idstamphandling"]};
Relations.Add(new DataRelation("stamphandling_payment",CPar,CChild));

TPar= Tables["paymenttransmission"];
TChild= Tables["payment"];
CPar = new DataColumn[1]{TPar.Columns["kpaymenttransmission"]};
CChild = new DataColumn[1]{TChild.Columns["kpaymenttransmission"]};
Relations.Add(new DataRelation("paymenttransmission_payment",CPar,CChild));

TPar= Tables["manager"];
TChild= Tables["payment"];
CPar = new DataColumn[1]{TPar.Columns["idman"]};
CChild = new DataColumn[1]{TChild.Columns["idman"]};
Relations.Add(new DataRelation("manager_payment",CPar,CChild));

}
}
}
