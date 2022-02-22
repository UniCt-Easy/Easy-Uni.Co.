
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


using System;
using System.Data;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;
#pragma warning disable 1591
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace finvardetail_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable finvardetail 		=> Tables["finvardetail"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable finvar 		=> Tables["finvar"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb 		=> Tables["upb"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable finview 		=> Tables["finview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable config 		=> Tables["config"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable finvarstatus 		=> Tables["finvarstatus"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable manager 		=> Tables["manager"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable enactment 		=> Tables["enactment"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable lcard 		=> Tables["lcard"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable underwriting 		=> Tables["underwriting"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expenseview 		=> Tables["expenseview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable finvardetailview 		=> Tables["finvardetailview"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public vistaForm(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected vistaForm (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "vistaForm";
	Prefix = "";
	Namespace = "http://tempuri.org/vistaForm.xsd";

	#region create DataTables
	DataColumn C;
	//////////////////// FINVARDETAIL /////////////////////////////////
	var tfinvardetail= new DataTable("finvardetail");
	C= new DataColumn("yvar", typeof(short));
	C.AllowDBNull=false;
	tfinvardetail.Columns.Add(C);
	C= new DataColumn("nvar", typeof(int));
	C.AllowDBNull=false;
	tfinvardetail.Columns.Add(C);
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tfinvardetail.Columns.Add(C);
	tfinvardetail.Columns.Add( new DataColumn("description", typeof(string)));
	tfinvardetail.Columns.Add( new DataColumn("!entrata", typeof(decimal)));
	tfinvardetail.Columns.Add( new DataColumn("!spesa", typeof(decimal)));
	tfinvardetail.Columns.Add( new DataColumn("amount", typeof(decimal)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfinvardetail.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfinvardetail.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfinvardetail.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfinvardetail.Columns.Add(C);
	tfinvardetail.Columns.Add( new DataColumn("!codicebilancio", typeof(string)));
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tfinvardetail.Columns.Add(C);
	tfinvardetail.Columns.Add( new DataColumn("!upb", typeof(string)));
	tfinvardetail.Columns.Add( new DataColumn("limit", typeof(decimal)));
	tfinvardetail.Columns.Add( new DataColumn("annotation", typeof(string)));
	tfinvardetail.Columns.Add( new DataColumn("idlcard", typeof(int)));
	tfinvardetail.Columns.Add( new DataColumn("idunderwriting", typeof(int)));
	C= new DataColumn("rownum", typeof(int));
	C.AllowDBNull=false;
	tfinvardetail.Columns.Add(C);
	tfinvardetail.Columns.Add( new DataColumn("prevision2", typeof(decimal)));
	tfinvardetail.Columns.Add( new DataColumn("prevision3", typeof(decimal)));
	tfinvardetail.Columns.Add( new DataColumn("createexpense", typeof(string)));
	tfinvardetail.Columns.Add( new DataColumn("idexp", typeof(int)));
	tfinvardetail.Columns.Add( new DataColumn("residual", typeof(decimal)));
	tfinvardetail.Columns.Add( new DataColumn("previousprevision", typeof(decimal)));
	Tables.Add(tfinvardetail);
	tfinvardetail.PrimaryKey =  new DataColumn[]{tfinvardetail.Columns["yvar"], tfinvardetail.Columns["nvar"], tfinvardetail.Columns["rownum"]};


	//////////////////// FINVAR /////////////////////////////////
	var tfinvar= new DataTable("finvar");
	C= new DataColumn("yvar", typeof(short));
	C.AllowDBNull=false;
	tfinvar.Columns.Add(C);
	C= new DataColumn("nvar", typeof(int));
	C.AllowDBNull=false;
	tfinvar.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tfinvar.Columns.Add(C);
	tfinvar.Columns.Add( new DataColumn("enactment", typeof(string)));
	tfinvar.Columns.Add( new DataColumn("variationkind", typeof(byte)));
	tfinvar.Columns.Add( new DataColumn("nenactment", typeof(string)));
	tfinvar.Columns.Add( new DataColumn("enactmentdate", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tfinvar.Columns.Add(C);
	tfinvar.Columns.Add( new DataColumn("txt", typeof(string)));
	tfinvar.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfinvar.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfinvar.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfinvar.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfinvar.Columns.Add(C);
	C= new DataColumn("flagprevision", typeof(string));
	C.AllowDBNull=false;
	tfinvar.Columns.Add(C);
	C= new DataColumn("flagcredit", typeof(string));
	C.AllowDBNull=false;
	tfinvar.Columns.Add(C);
	C= new DataColumn("flagsecondaryprev", typeof(string));
	C.AllowDBNull=false;
	tfinvar.Columns.Add(C);
	C= new DataColumn("flagproceeds", typeof(string));
	C.AllowDBNull=false;
	tfinvar.Columns.Add(C);
	tfinvar.Columns.Add( new DataColumn("limit", typeof(decimal)));
	tfinvar.Columns.Add( new DataColumn("reason", typeof(string)));
	tfinvar.Columns.Add( new DataColumn("idenactment", typeof(int)));
	tfinvar.Columns.Add( new DataColumn("idfinvarstatus", typeof(short)));
	tfinvar.Columns.Add( new DataColumn("annotation", typeof(string)));
	tfinvar.Columns.Add( new DataColumn("idman", typeof(int)));
	tfinvar.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tfinvar.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tfinvar.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tfinvar.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tfinvar.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tfinvar.Columns.Add( new DataColumn("varflag", typeof(int)));
	Tables.Add(tfinvar);
	tfinvar.PrimaryKey =  new DataColumn[]{tfinvar.Columns["yvar"], tfinvar.Columns["nvar"]};


	//////////////////// UPB /////////////////////////////////
	var tupb= new DataTable("upb");
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("paridupb", typeof(string)));
	tupb.Columns.Add( new DataColumn("idunderwriter", typeof(int)));
	tupb.Columns.Add( new DataColumn("idman", typeof(int)));
	tupb.Columns.Add( new DataColumn("requested", typeof(decimal)));
	tupb.Columns.Add( new DataColumn("granted", typeof(decimal)));
	tupb.Columns.Add( new DataColumn("previousappropriation", typeof(decimal)));
	tupb.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	tupb.Columns.Add( new DataColumn("txt", typeof(string)));
	tupb.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("assured", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("active", typeof(string)));
	tupb.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tupb);
	tupb.PrimaryKey =  new DataColumn[]{tupb.Columns["idupb"]};


	//////////////////// FINVIEW /////////////////////////////////
	var tfinview= new DataTable("finview");
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	tfinview.Columns.Add( new DataColumn("finpart", typeof(string)));
	C= new DataColumn("codefin", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("leveldescr", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	tfinview.Columns.Add( new DataColumn("paridfin", typeof(int)));
	tfinview.Columns.Add( new DataColumn("idman", typeof(int)));
	tfinview.Columns.Add( new DataColumn("manager", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("prevision", typeof(decimal));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	tfinview.Columns.Add( new DataColumn("currentprevision", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("availableprevision", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("previousprevision", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("secondaryprev", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("currentsecondaryprev", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("availablesecondaryprev", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("previoussecondaryprev", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("currentarrears", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("previousarrears", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("prevision2", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("prevision3", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("prevision4", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("prevision5", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("flagusable", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("upb", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	tfinview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tfinview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tfinview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tfinview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tfinview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tfinview);
	tfinview.PrimaryKey =  new DataColumn[]{tfinview.Columns["idfin"]};


	//////////////////// CONFIG /////////////////////////////////
	var tconfig= new DataTable("config");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tconfig.Columns.Add(C);
	tconfig.Columns.Add( new DataColumn("agencycode", typeof(string)));
	tconfig.Columns.Add( new DataColumn("appname", typeof(string)));
	tconfig.Columns.Add( new DataColumn("appropriationphasecode", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("assessmentphasecode", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("asset_flagnumbering", typeof(string)));
	tconfig.Columns.Add( new DataColumn("asset_flagrestart", typeof(string)));
	tconfig.Columns.Add( new DataColumn("assetload_flag", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("boxpartitiontitle", typeof(string)));
	tconfig.Columns.Add( new DataColumn("cashvaliditykind", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("casualcontract_flagrestart", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tconfig.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tconfig.Columns.Add(C);
	tconfig.Columns.Add( new DataColumn("currpartitiontitle", typeof(string)));
	tconfig.Columns.Add( new DataColumn("deferredexpensephase", typeof(string)));
	tconfig.Columns.Add( new DataColumn("deferredincomephase", typeof(string)));
	tconfig.Columns.Add( new DataColumn("electronicimport", typeof(string)));
	tconfig.Columns.Add( new DataColumn("electronictrasmission", typeof(string)));
	tconfig.Columns.Add( new DataColumn("expense_expiringdays", typeof(short)));
	tconfig.Columns.Add( new DataColumn("expensephase", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("flagautopayment", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagautoproceeds", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagcredit", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagepexp", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagfruitful", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagpayment", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagproceeds", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagrefund", typeof(string)));
	tconfig.Columns.Add( new DataColumn("foreignhours", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idacc_accruedcost", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_accruedrevenue", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_customer", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_deferredcost", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_deferredcredit", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_deferreddebit", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_deferredrevenue", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_ivapayment", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_ivarefund", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_patrimony", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_pl", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_supplier", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idaccmotive_admincar", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idaccmotive_foot", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idaccmotive_owncar", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idclawback", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idfinexpense", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idfinexpensesurplus", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idfinincomesurplus", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idfinivapayment", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idfinivarefund", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idivapayperiodicity", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idregauto", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idsortingkind1", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idsortingkind2", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idsortingkind3", typeof(int)));
	tconfig.Columns.Add( new DataColumn("importappname", typeof(string)));
	tconfig.Columns.Add( new DataColumn("income_expiringdays", typeof(short)));
	tconfig.Columns.Add( new DataColumn("incomephase", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("linktoinvoice", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tconfig.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tconfig.Columns.Add(C);
	tconfig.Columns.Add( new DataColumn("minpayment", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("minrefund", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("motivelen", typeof(short)));
	tconfig.Columns.Add( new DataColumn("motiveprefix", typeof(string)));
	tconfig.Columns.Add( new DataColumn("motiveseparator", typeof(string)));
	tconfig.Columns.Add( new DataColumn("payment_finlevel", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("payment_flag", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("payment_flagautoprintdate", typeof(string)));
	tconfig.Columns.Add( new DataColumn("paymentagency", typeof(int)));
	tconfig.Columns.Add( new DataColumn("prevpartitiontitle", typeof(string)));
	tconfig.Columns.Add( new DataColumn("proceeds_finlevel", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("proceeds_flag", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("proceeds_flagautoprintdate", typeof(string)));
	tconfig.Columns.Add( new DataColumn("profservice_flagrestart", typeof(string)));
	tconfig.Columns.Add( new DataColumn("refundagency", typeof(int)));
	tconfig.Columns.Add( new DataColumn("wageaddition_flagrestart", typeof(string)));
	Tables.Add(tconfig);
	tconfig.PrimaryKey =  new DataColumn[]{tconfig.Columns["ayear"]};


	//////////////////// FINVARSTATUS /////////////////////////////////
	var tfinvarstatus= new DataTable("finvarstatus");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfinvarstatus.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfinvarstatus.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tfinvarstatus.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfinvarstatus.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfinvarstatus.Columns.Add(C);
	C= new DataColumn("idfinvarstatus", typeof(short));
	C.AllowDBNull=false;
	tfinvarstatus.Columns.Add(C);
	Tables.Add(tfinvarstatus);
	tfinvarstatus.PrimaryKey =  new DataColumn[]{tfinvarstatus.Columns["idfinvarstatus"]};


	//////////////////// MANAGER /////////////////////////////////
	var tmanager= new DataTable("manager");
	tmanager.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	tmanager.Columns.Add( new DataColumn("email", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	tmanager.Columns.Add( new DataColumn("passwordweb", typeof(string)));
	tmanager.Columns.Add( new DataColumn("phonenumber", typeof(string)));
	tmanager.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	tmanager.Columns.Add( new DataColumn("txt", typeof(string)));
	tmanager.Columns.Add( new DataColumn("userweb", typeof(string)));
	C= new DataColumn("idman", typeof(int));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("iddivision", typeof(int));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	tmanager.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tmanager);
	tmanager.PrimaryKey =  new DataColumn[]{tmanager.Columns["idman"]};


	//////////////////// ENACTMENT /////////////////////////////////
	var tenactment= new DataTable("enactment");
	C= new DataColumn("nenactment", typeof(int));
	C.AllowDBNull=false;
	tenactment.Columns.Add(C);
	C= new DataColumn("yenactment", typeof(short));
	C.AllowDBNull=false;
	tenactment.Columns.Add(C);
	C= new DataColumn("idenactment", typeof(int));
	C.AllowDBNull=false;
	tenactment.Columns.Add(C);
	tenactment.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tenactment.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tenactment.Columns.Add(C);
	tenactment.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tenactment.Columns.Add(C);
	tenactment.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tenactment.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tenactment.Columns.Add(C);
	C= new DataColumn("idenactmentstatus", typeof(short));
	C.AllowDBNull=false;
	tenactment.Columns.Add(C);
	tenactment.Columns.Add( new DataColumn("nofficial", typeof(string)));
	Tables.Add(tenactment);
	tenactment.PrimaryKey =  new DataColumn[]{tenactment.Columns["idenactment"]};


	//////////////////// LCARD /////////////////////////////////
	var tlcard= new DataTable("lcard");
	C= new DataColumn("idlcard", typeof(int));
	C.AllowDBNull=false;
	tlcard.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tlcard.Columns.Add(C);
	tlcard.Columns.Add( new DataColumn("description", typeof(string)));
	tlcard.Columns.Add( new DataColumn("ystart", typeof(short)));
	tlcard.Columns.Add( new DataColumn("ystop", typeof(short)));
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tlcard.Columns.Add(C);
	C= new DataColumn("idman", typeof(int));
	C.AllowDBNull=false;
	tlcard.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tlcard.Columns.Add(C);
	tlcard.Columns.Add( new DataColumn("lu", typeof(string)));
	C= new DataColumn("idstore", typeof(int));
	C.AllowDBNull=false;
	tlcard.Columns.Add(C);
	tlcard.Columns.Add( new DataColumn("extcode", typeof(string)));
	Tables.Add(tlcard);
	tlcard.PrimaryKey =  new DataColumn[]{tlcard.Columns["idlcard"]};


	//////////////////// UNDERWRITING /////////////////////////////////
	var tunderwriting= new DataTable("underwriting");
	C= new DataColumn("idunderwriting", typeof(int));
	C.AllowDBNull=false;
	tunderwriting.Columns.Add(C);
	tunderwriting.Columns.Add( new DataColumn("idunderwriter", typeof(int)));
	tunderwriting.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tunderwriting.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tunderwriting.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tunderwriting.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tunderwriting.Columns.Add( new DataColumn("idsor05", typeof(int)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tunderwriting.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tunderwriting.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tunderwriting.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tunderwriting.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tunderwriting.Columns.Add(C);
	tunderwriting.Columns.Add( new DataColumn("active", typeof(string)));
	tunderwriting.Columns.Add( new DataColumn("doc", typeof(string)));
	tunderwriting.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	Tables.Add(tunderwriting);
	tunderwriting.PrimaryKey =  new DataColumn[]{tunderwriting.Columns["idunderwriting"]};


	//////////////////// EXPENSEVIEW /////////////////////////////////
	var texpenseview= new DataTable("expenseview");
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	C= new DataColumn("phase", typeof(string));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	C= new DataColumn("ymov", typeof(short));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	C= new DataColumn("nmov", typeof(int));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	texpenseview.Columns.Add( new DataColumn("parentidexp", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("parentymov", typeof(short)));
	texpenseview.Columns.Add( new DataColumn("parentnmov", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idformerexpense", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("formerymov", typeof(short)));
	texpenseview.Columns.Add( new DataColumn("formernmov", typeof(int)));
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	texpenseview.Columns.Add( new DataColumn("idfin", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("codefin", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("finance", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("idupb", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("codeupb", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("upb", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idreg", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("registry", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("cf", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("p_iva", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("idman", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("manager", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("kpay", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("ypay", typeof(short)));
	texpenseview.Columns.Add( new DataColumn("npay", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("paymentadate", typeof(DateTime)));
	texpenseview.Columns.Add( new DataColumn("doc", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	texpenseview.Columns.Add( new DataColumn("amount", typeof(decimal)));
	texpenseview.Columns.Add( new DataColumn("ayearstartamount", typeof(decimal)));
	texpenseview.Columns.Add( new DataColumn("curramount", typeof(decimal)));
	texpenseview.Columns.Add( new DataColumn("available", typeof(decimal)));
	texpenseview.Columns.Add( new DataColumn("idregistrypaymethod", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idpaymethod", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("iban", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("cin", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("idbank", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("idcab", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("cc", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("iddeputy", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("deputy", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("refexternaldoc", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("paymentdescr", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("idser", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("service", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("codeser", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("servicestart", typeof(DateTime)));
	texpenseview.Columns.Add( new DataColumn("servicestop", typeof(DateTime)));
	texpenseview.Columns.Add( new DataColumn("ivaamount", typeof(decimal)));
	texpenseview.Columns.Add( new DataColumn("flag", typeof(byte)));
	texpenseview.Columns.Add( new DataColumn("totflag", typeof(byte)));
	C= new DataColumn("flagarrear", typeof(string));
	C.ReadOnly=true;
	texpenseview.Columns.Add(C);
	texpenseview.Columns.Add( new DataColumn("autokind", typeof(byte)));
	texpenseview.Columns.Add( new DataColumn("idpayment", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	texpenseview.Columns.Add( new DataColumn("autocode", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idclawback", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("clawback", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("clawbackref", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("nbill", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idpay", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("npaymenttransmission", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("transmissiondate", typeof(DateTime)));
	texpenseview.Columns.Add( new DataColumn("idaccdebit", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("codeaccdebit", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("cigcode", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("cupcode", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	Tables.Add(texpenseview);
	texpenseview.PrimaryKey =  new DataColumn[]{texpenseview.Columns["idexp"], texpenseview.Columns["ayear"]};


	//////////////////// FINVARDETAILVIEW /////////////////////////////////
	var tfinvardetailview= new DataTable("finvardetailview");
	C= new DataColumn("yvar", typeof(short));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("nvar", typeof(int));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("rownum", typeof(int));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("variationdescription", typeof(string));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	tfinvardetailview.Columns.Add( new DataColumn("idenactment", typeof(int)));
	tfinvardetailview.Columns.Add( new DataColumn("enactment", typeof(string)));
	tfinvardetailview.Columns.Add( new DataColumn("nenactment", typeof(string)));
	tfinvardetailview.Columns.Add( new DataColumn("enactmentdate", typeof(DateTime)));
	C= new DataColumn("variationkind", typeof(byte));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("variationkinddescr", typeof(string));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("flagprevision", typeof(string));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("flagcredit", typeof(string));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("flagproceeds", typeof(string));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("flagsecondaryprev", typeof(string));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	tfinvardetailview.Columns.Add( new DataColumn("official", typeof(string)));
	tfinvardetailview.Columns.Add( new DataColumn("nofficial", typeof(int)));
	tfinvardetailview.Columns.Add( new DataColumn("enactmentnumber", typeof(int)));
	tfinvardetailview.Columns.Add( new DataColumn("idman", typeof(int)));
	tfinvardetailview.Columns.Add( new DataColumn("manager", typeof(string)));
	tfinvardetailview.Columns.Add( new DataColumn("idfinvarstatus", typeof(short)));
	tfinvardetailview.Columns.Add( new DataColumn("finvarstatus", typeof(string)));
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("finpart", typeof(string));
	C.ReadOnly=true;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("codefin", typeof(string));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("finance", typeof(string));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	tfinvardetailview.Columns.Add( new DataColumn("description", typeof(string)));
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("upb", typeof(string));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	tfinvardetailview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tfinvardetailview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tfinvardetailview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tfinvardetailview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tfinvardetailview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tfinvardetailview.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tfinvardetailview.Columns.Add( new DataColumn("limit", typeof(decimal)));
	tfinvardetailview.Columns.Add( new DataColumn("annotation", typeof(string)));
	tfinvardetailview.Columns.Add( new DataColumn("idlcard", typeof(int)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	tfinvardetailview.Columns.Add( new DataColumn("idunderwriting", typeof(int)));
	tfinvardetailview.Columns.Add( new DataColumn("underwriting", typeof(string)));
	tfinvardetailview.Columns.Add( new DataColumn("prevision2", typeof(decimal)));
	tfinvardetailview.Columns.Add( new DataColumn("prevision3", typeof(decimal)));
	tfinvardetailview.Columns.Add( new DataColumn("residual", typeof(decimal)));
	tfinvardetailview.Columns.Add( new DataColumn("createexpense", typeof(string)));
	tfinvardetailview.Columns.Add( new DataColumn("idexp", typeof(int)));
	tfinvardetailview.Columns.Add( new DataColumn("phase", typeof(string)));
	tfinvardetailview.Columns.Add( new DataColumn("nmov", typeof(int)));
	tfinvardetailview.Columns.Add( new DataColumn("flagactivity", typeof(short)));
	C= new DataColumn("activity", typeof(string));
	C.ReadOnly=true;
	tfinvardetailview.Columns.Add(C);
	tfinvardetailview.Columns.Add( new DataColumn("flagkind", typeof(byte)));
	C= new DataColumn("kindd", typeof(string));
	C.ReadOnly=true;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("kindr", typeof(string));
	C.ReadOnly=true;
	tfinvardetailview.Columns.Add(C);
	tfinvardetailview.Columns.Add( new DataColumn("varflag", typeof(int)));
	tfinvardetailview.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	tfinvardetailview.Columns.Add( new DataColumn("previousprevision", typeof(decimal)));
	Tables.Add(tfinvardetailview);
	tfinvardetailview.PrimaryKey =  new DataColumn[]{tfinvardetailview.Columns["yvar"], tfinvardetailview.Columns["nvar"], tfinvardetailview.Columns["rownum"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{finvarstatus.Columns["idfinvarstatus"]};
	var cChild = new []{finvar.Columns["idfinvarstatus"]};
	Relations.Add(new DataRelation("finvarstatus_finvar",cPar,cChild,false));

	cPar = new []{manager.Columns["idman"]};
	cChild = new []{finvar.Columns["idman"]};
	Relations.Add(new DataRelation("manager_finvar",cPar,cChild,false));

	cPar = new []{enactment.Columns["idenactment"]};
	cChild = new []{finvar.Columns["idenactment"]};
	Relations.Add(new DataRelation("enactment_finvar",cPar,cChild,false));

	cPar = new []{lcard.Columns["idlcard"]};
	cChild = new []{finvardetail.Columns["idlcard"]};
	Relations.Add(new DataRelation("lcard_finvardetail",cPar,cChild,false));

	cPar = new []{finvar.Columns["yvar"], finvar.Columns["nvar"]};
	cChild = new []{finvardetail.Columns["yvar"], finvardetail.Columns["nvar"]};
	Relations.Add(new DataRelation("finvarfinvardetail",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{finvardetail.Columns["idupb"]};
	Relations.Add(new DataRelation("upbfinvardetail",cPar,cChild,false));

	cPar = new []{finview.Columns["idfin"]};
	cChild = new []{finvardetail.Columns["idfin"]};
	Relations.Add(new DataRelation("finviewfinvardetail",cPar,cChild,false));

	cPar = new []{underwriting.Columns["idunderwriting"]};
	cChild = new []{finvardetail.Columns["idunderwriting"]};
	Relations.Add(new DataRelation("underwriting_finvardetail",cPar,cChild,false));

	cPar = new []{expenseview.Columns["idexp"], expenseview.Columns["ayear"]};
	cChild = new []{finvardetail.Columns["idexp"], finvardetail.Columns["yvar"]};
	Relations.Add(new DataRelation("expenseview_finvardetail",cPar,cChild,false));

	#endregion

}
}
}
