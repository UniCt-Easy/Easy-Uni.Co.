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

namespace proceedspart_default {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaForm: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable proceedspart{get { return Tables["proceedspart"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable incomeview{get { return Tables["incomeview"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable incomephase{get { return Tables["incomephase"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable finview{get { return Tables["finview"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable upb{get { return Tables["upb"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable proceedspartview{get { return Tables["proceedspartview"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable config{get { return Tables["config"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable treasurer{get { return Tables["treasurer"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable treasurerincome{get { return Tables["treasurerincome"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable upbincome{get { return Tables["upbincome"];}}

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
	T= new DataTable("proceedspart");
	C= new DataColumn("idinc", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nproceedspart", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idfin", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("yproceedspart", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("amount", typeof(System.Decimal), ""));
	C= new DataColumn("adate", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
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

	T.Columns.Add(new DataColumn("idupb", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("!codeupb", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("!upb", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["idinc"], 	T.Columns["nproceedspart"]};
	T.PrimaryKey = key;

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

	T.Columns.Add(new DataColumn("idunderwriting", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idinc"]};
	T.PrimaryKey = key;

	T= new DataTable("incomephase");
	C= new DataColumn("nphase", typeof(System.Byte), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
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
	key = new DataColumn[1]{
	T.Columns["nphase"]};
	T.PrimaryKey = key;

	T= new DataTable("finview");
	C= new DataColumn("idfin", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ayear", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("finpart", typeof(System.String), ""));
	C= new DataColumn("codefin", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nlevel", typeof(System.Byte), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("leveldescr", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("paridfin", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idman", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("manager", typeof(System.String), ""));
	C= new DataColumn("printingorder", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("title", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("prevision", typeof(System.Decimal), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("currentprevision", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("availableprevision", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("previousprevision", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("secondaryprev", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("currentsecondaryprev", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("availablesecondaryprev", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("previoussecondaryprev", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("currentarrears", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("previousarrears", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("prevision2", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("prevision3", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("prevision4", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("prevision5", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("expiration", typeof(System.DateTime), ""));
	C= new DataColumn("flag", typeof(System.Byte), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("flagusable", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("idupb", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("codeupb", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("upb", typeof(System.String), "");
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
	T= new DataTable("upb");
	C= new DataColumn("idupb", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("active", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("assured", typeof(System.String), ""));
	C= new DataColumn("codeupb", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("expiration", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("granted", typeof(System.Decimal), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("paridupb", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("previousappropriation", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("previousassessment", typeof(System.Decimal), ""));
	C= new DataColumn("printingorder", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("requested", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
	C= new DataColumn("title", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idman", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idunderwriter", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("cupcode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idsor01", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor02", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor03", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor04", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor05", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idtreasurer", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idupb"]};
	T.PrimaryKey = key;

	T= new DataTable("proceedspartview");
	C= new DataColumn("idinc", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nproceedspart", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("yproceedspart", typeof(System.Int16), "");
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

	C= new DataColumn("idfin", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("codefin", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("finance", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("idupb", typeof(System.String), ""));
	C= new DataColumn("codeupb", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("upb", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("amount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("financeincome", typeof(System.String), ""));
	C= new DataColumn("adate", typeof(System.DateTime), "");
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

	T.Columns.Add(new DataColumn("idtreasurer", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("treasurer", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idupbincome", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("codeupbincome", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("upbincome", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idtreasurerincome", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("treasurerincome", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("allocatedamount", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("moneytotransfer", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("moneytransfered", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("idsor01", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor02", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor03", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor04", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor05", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("treasurerproceeds", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idtreasurerproceeds", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["idinc"], 	T.Columns["nproceedspart"]};
	T.PrimaryKey = key;

	T= new DataTable("config");
	C= new DataColumn("ayear", typeof(System.Int16), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("agencycode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("appname", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("appropriationphasecode", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("assessmentphasecode", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("asset_flagnumbering", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("asset_flagrestart", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("assetload_flag", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("boxpartitiontitle", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("finvarofficial_default", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("casualcontract_flagrestart", typeof(System.String), ""));
	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("currpartitiontitle", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("deferredexpensephase", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("deferredincomephase", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("electronicimport", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("electronictrasmission", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("expense_expiringdays", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("expensephase", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("flagautopayment", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagautoproceeds", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagcredit", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagepexp", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagfruitful", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagpayment", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagproceeds", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagrefund", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("foreignhours", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idacc_accruedcost", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_accruedrevenue", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_customer", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_deferredcost", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_deferredcredit", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_deferreddebit", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_deferredrevenue", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_ivapayment", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_ivarefund", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_patrimony", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_pl", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_supplier", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idaccmotive_admincar", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idaccmotive_foot", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idaccmotive_owncar", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idclawback", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idfinexpense", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idfinexpensesurplus", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idfinincomesurplus", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idfinivapayment", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idfinivarefund", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idregauto", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("importappname", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("income_expiringdays", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("incomephase", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("linktoinvoice", typeof(System.String), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("minpayment", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("minrefund", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("motivelen", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("motiveprefix", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("motiveseparator", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("payment_finlevel", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("payment_flag", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("payment_flagautoprintdate", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("paymentagency", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("prevpartitiontitle", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("proceeds_finlevel", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("proceeds_flag", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("proceeds_flagautoprintdate", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("profservice_flagrestart", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("refundagency", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("wageaddition_flagrestart", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idivapayperiodicity", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsortingkind1", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsortingkind2", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsortingkind3", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("fin_kind", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("taxvaliditykind", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("flag_paymentamount", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("automanagekind", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("flag_autodocnumbering", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("flagbank_grouping", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("cashvaliditykind", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("wageimportappname", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("balancekind", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("idpaymethodabi", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idpaymethodnoabi", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("iban_f24", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cudactivitycode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("startivabalance", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("flagivapaybyrow", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_unabatable", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_unabatable_refund", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("invoice_flagregister", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("default_idfinvarstatus", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("flagivaregphase", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("mainflagpayment", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("mainflagrefund", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("mainidfinivapayment", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("mainidfinivarefund", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("mainminpayment", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("mainminrefund", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("mainpaymentagency", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("mainrefundagency", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("mainflagivaregphase", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("mainstartivabalance", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("mainidacc_unabatable", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("mainidacc_unabatable_refund", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_mainivapayment", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_mainivapayment_internal", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_mainivarefund", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_mainivarefund_internal", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagva3", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagrefund12", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagpayment12", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("refundagency12", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("paymentagency12", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idfinivarefund12", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idfinivapayment12", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("minrefund12", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("minpayment12", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("idacc_ivapayment12", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_ivarefund12", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_mainivarefund12", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_mainivapayment12", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_mainivapayment_internal12", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_mainivarefund_internal12", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("startivabalance12", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("mainrefundagency12", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("mainpaymentagency12", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("mainflagrefund12", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("mainflagpayment12", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("mainidfinivarefund12", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("mainidfinivapayment12", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("mainminrefund12", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("mainminpayment12", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("mainstartivabalance12", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("idreg_csa", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("finvar_warnmail", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagdirectcsaclawback", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idacc_revenue_gross_csa", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idfinincome_gross_csa", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor1_stock", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor2_stock", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor3_stock", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idinpscenter", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idivapayperiodicity_instit", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idfin_store", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("flagpcashautopayment", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagpcashautoproceeds", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("email", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("lcard", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("booking_on_invoice", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("itineration_directauth", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("email_f24", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["ayear"]};
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
	T.Columns.Add(new DataColumn("cccbi", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cincbi", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idbankcbi", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idcabcbi", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ibancbi", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("siacodecbi", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("reccbikind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("trasmcode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagbank_grouping", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("motivelen", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("motiveprefix", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("motiveseparator", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("annotations", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagedisp", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idsor01", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor02", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor03", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor04", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor05", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("billcode", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idtreasurer"]};
	T.PrimaryKey = key;

	T= new DataTable("treasurerincome");
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
	T.Columns.Add(new DataColumn("cccbi", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cincbi", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idbankcbi", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idcabcbi", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ibancbi", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("siacodecbi", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("reccbikind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("trasmcode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagbank_grouping", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("motivelen", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("motiveprefix", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("motiveseparator", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("annotations", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagedisp", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idsor01", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor02", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor03", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor04", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor05", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("billcode", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idtreasurer"]};
	T.PrimaryKey = key;

	T= new DataTable("upbincome");
	C= new DataColumn("idupb", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("active", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("assured", typeof(System.String), ""));
	C= new DataColumn("codeupb", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("expiration", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("granted", typeof(System.Decimal), ""));
	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("paridupb", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("previousappropriation", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("previousassessment", typeof(System.Decimal), ""));
	C= new DataColumn("printingorder", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("requested", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
	C= new DataColumn("title", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idman", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idunderwriter", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("cupcode", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idsor01", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor02", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor03", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor04", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("idsor05", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("flagactivity", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("flagkind", typeof(System.Byte), ""));
	T.Columns.Add(new DataColumn("newcodeupb", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("idtreasurer", typeof(System.Int32), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idupb"]};
	T.PrimaryKey = key;


//Relations
DataTable TPar;
DataTable TChild;
DataColumn []CPar;
DataColumn []CChild;
TPar= Tables["treasurerincome"];
TChild= Tables["upbincome"];
CPar = new DataColumn[1]{TPar.Columns["idtreasurer"]};
CChild = new DataColumn[1]{TChild.Columns["idtreasurer"]};
Relations.Add(new DataRelation("FK_treasurerincome_upbincome",CPar,CChild));

TPar= Tables["treasurer"];
TChild= Tables["upb"];
CPar = new DataColumn[1]{TPar.Columns["idtreasurer"]};
CChild = new DataColumn[1]{TChild.Columns["idtreasurer"]};
Relations.Add(new DataRelation("FK_treasurer_upb",CPar,CChild));

TPar= Tables["upbincome"];
TChild= Tables["incomeview"];
CPar = new DataColumn[1]{TPar.Columns["idupb"]};
CChild = new DataColumn[1]{TChild.Columns["idupb"]};
Relations.Add(new DataRelation("FK_upbincome_incomeview",CPar,CChild));

TPar= Tables["upb"];
TChild= Tables["proceedspart"];
CPar = new DataColumn[1]{TPar.Columns["idupb"]};
CChild = new DataColumn[1]{TChild.Columns["idupb"]};
Relations.Add(new DataRelation("upb_proceedspart",CPar,CChild));

TPar= Tables["finview"];
TChild= Tables["proceedspart"];
CPar = new DataColumn[1]{TPar.Columns["idfin"]};
CChild = new DataColumn[1]{TChild.Columns["idfin"]};
Relations.Add(new DataRelation("finviewproceedspart",CPar,CChild));

TPar= Tables["incomeview"];
TChild= Tables["proceedspart"];
CPar = new DataColumn[1]{TPar.Columns["idinc"]};
CChild = new DataColumn[1]{TChild.Columns["idinc"]};
Relations.Add(new DataRelation("incomeviewproceedspart",CPar,CChild));

}
}
}
