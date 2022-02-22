
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
namespace finvar_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Dettaglio variazione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable finvardetail 		=> Tables["finvardetail"];

	///<summary>
	///U.P.B.
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb 		=> Tables["upb"];

	///<summary>
	///Variazione/Storno
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable finvar 		=> Tables["finvar"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable finvardetailview 		=> Tables["finvardetailview"];

	///<summary>
	///Bilancio
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable fin 		=> Tables["fin"];

	///<summary>
	///Configurazione Annuale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable config 		=> Tables["config"];

	///<summary>
	///Stato variazione bilancio
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable finvarstatus 		=> Tables["finvarstatus"];

	///<summary>
	///Atto Amministrativo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable enactment 		=> Tables["enactment"];

	///<summary>
	///Responsabile
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable manager 		=> Tables["manager"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable lcardvarview 		=> Tables["lcardvarview"];

	///<summary>
	///Allegato alla variazione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable finvarattachment 		=> Tables["finvarattachment"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting01 		=> Tables["sorting01"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting02 		=> Tables["sorting02"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting03 		=> Tables["sorting03"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting04 		=> Tables["sorting04"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting05 		=> Tables["sorting05"];

	///<summary>
	///Finanziamento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable underwriting 		=> Tables["underwriting"];

	///<summary>
	///Tipo variazione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable variationkind 		=> Tables["variationkind"];

	///<summary>
	///Tipo Variazione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable finvarkind 		=> Tables["finvarkind"];

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
	tfinvardetail.Columns.Add( new DataColumn("!codicebilancio", typeof(string)));
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
	tfinvardetail.Columns.Add( new DataColumn("!finanziamento", typeof(string)));
	tfinvardetail.Columns.Add( new DataColumn("prevision2", typeof(decimal)));
	tfinvardetail.Columns.Add( new DataColumn("prevision3", typeof(decimal)));
	tfinvardetail.Columns.Add( new DataColumn("createexpense", typeof(string)));
	tfinvardetail.Columns.Add( new DataColumn("idexp", typeof(int)));
	tfinvardetail.Columns.Add( new DataColumn("residual", typeof(decimal)));
	tfinvardetail.Columns.Add( new DataColumn("previousprevision", typeof(decimal)));
	Tables.Add(tfinvardetail);
	tfinvardetail.PrimaryKey =  new DataColumn[]{tfinvardetail.Columns["yvar"], tfinvardetail.Columns["nvar"], tfinvardetail.Columns["rownum"]};


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
	tupb.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	Tables.Add(tupb);
	tupb.PrimaryKey =  new DataColumn[]{tupb.Columns["idupb"]};


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
	C= new DataColumn("variationkind", typeof(byte));
	C.AllowDBNull=false;
	tfinvar.Columns.Add(C);
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
	C= new DataColumn("flagproceeds", typeof(string));
	C.AllowDBNull=false;
	tfinvar.Columns.Add(C);
	C= new DataColumn("flagsecondaryprev", typeof(string));
	C.AllowDBNull=false;
	tfinvar.Columns.Add(C);
	tfinvar.Columns.Add( new DataColumn("official", typeof(string)));
	tfinvar.Columns.Add( new DataColumn("nofficial", typeof(int)));
	tfinvar.Columns.Add( new DataColumn("idfinvarstatus", typeof(short)));
	tfinvar.Columns.Add( new DataColumn("idenactment", typeof(int)));
	tfinvar.Columns.Add( new DataColumn("reason", typeof(string)));
	tfinvar.Columns.Add( new DataColumn("limit", typeof(decimal)));
	tfinvar.Columns.Add( new DataColumn("annotation", typeof(string)));
	tfinvar.Columns.Add( new DataColumn("idman", typeof(int)));
	tfinvar.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tfinvar.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tfinvar.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tfinvar.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tfinvar.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tfinvar.Columns.Add( new DataColumn("idfinvarkind", typeof(int)));
	tfinvar.Columns.Add( new DataColumn("moneytransfer", typeof(string)));
	tfinvar.Columns.Add( new DataColumn("varflag", typeof(int)));
	Tables.Add(tfinvar);
	tfinvar.PrimaryKey =  new DataColumn[]{tfinvar.Columns["yvar"], tfinvar.Columns["nvar"]};


	//////////////////// FINVARDETAILVIEW /////////////////////////////////
	var tfinvardetailview= new DataTable("finvardetailview");
	C= new DataColumn("yvar", typeof(short));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("nvar", typeof(int));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("variationdescription", typeof(string));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	tfinvardetailview.Columns.Add( new DataColumn("idenactment", typeof(int)));
	tfinvardetailview.Columns.Add( new DataColumn("enactment", typeof(string)));
	tfinvardetailview.Columns.Add( new DataColumn("nenactment", typeof(string)));
	tfinvardetailview.Columns.Add( new DataColumn("enactmentdate", typeof(DateTime)));
	tfinvardetailview.Columns.Add( new DataColumn("variationkind", typeof(byte)));
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	tfinvardetailview.Columns.Add( new DataColumn("finpart", typeof(string)));
	C= new DataColumn("codefin", typeof(string));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("finance", typeof(string));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	tfinvardetailview.Columns.Add( new DataColumn("description", typeof(string)));
	tfinvardetailview.Columns.Add( new DataColumn("amount", typeof(decimal)));
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
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	tfinvardetailview.Columns.Add( new DataColumn("codeupb", typeof(string)));
	tfinvardetailview.Columns.Add( new DataColumn("upb", typeof(string)));
	tfinvardetailview.Columns.Add( new DataColumn("official", typeof(string)));
	tfinvardetailview.Columns.Add( new DataColumn("nofficial", typeof(int)));
	tfinvardetailview.Columns.Add( new DataColumn("limit", typeof(decimal)));
	tfinvardetailview.Columns.Add( new DataColumn("annotation", typeof(string)));
	tfinvardetailview.Columns.Add( new DataColumn("idlcard", typeof(int)));
	tfinvardetailview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tfinvardetailview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tfinvardetailview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tfinvardetailview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tfinvardetailview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tfinvardetailview.Columns.Add( new DataColumn("idunderwriting", typeof(int)));
	tfinvardetailview.Columns.Add( new DataColumn("underwriting", typeof(string)));
	C= new DataColumn("rownum", typeof(int));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	tfinvardetailview.Columns.Add( new DataColumn("prevision2", typeof(decimal)));
	tfinvardetailview.Columns.Add( new DataColumn("prevision3", typeof(decimal)));
	tfinvardetailview.Columns.Add( new DataColumn("createexpense", typeof(string)));
	tfinvardetailview.Columns.Add( new DataColumn("idexp", typeof(int)));
	tfinvardetailview.Columns.Add( new DataColumn("flag", typeof(byte)));
	tfinvardetailview.Columns.Add( new DataColumn("residual", typeof(decimal)));
	tfinvardetailview.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	tfinvardetailview.Columns.Add( new DataColumn("previousprevision", typeof(decimal)));
	Tables.Add(tfinvardetailview);
	tfinvardetailview.PrimaryKey =  new DataColumn[]{tfinvardetailview.Columns["rownum"], tfinvardetailview.Columns["yvar"], tfinvardetailview.Columns["nvar"]};


	//////////////////// FIN /////////////////////////////////
	var tfin= new DataTable("fin");
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("codefin", typeof(string));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	Tables.Add(tfin);
	tfin.PrimaryKey =  new DataColumn[]{tfin.Columns["idfin"]};


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
	tconfig.Columns.Add( new DataColumn("finvar_warnmail", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idfin_store", typeof(int)));
	tconfig.Columns.Add( new DataColumn("fin_kind", typeof(byte)));
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
	tenactment.Columns.Add( new DataColumn("nofficial", typeof(string)));
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
	tenactment.Columns.Add( new DataColumn("idenactmentstatus", typeof(short)));
	tenactment.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tenactment.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tenactment.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tenactment.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tenactment.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tenactment);
	tenactment.PrimaryKey =  new DataColumn[]{tenactment.Columns["idenactment"]};


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


	//////////////////// LCARDVARVIEW /////////////////////////////////
	var tlcardvarview= new DataTable("lcardvarview");
	C= new DataColumn("ylvar", typeof(short));
	C.AllowDBNull=false;
	tlcardvarview.Columns.Add(C);
	C= new DataColumn("nlvar", typeof(int));
	C.AllowDBNull=false;
	tlcardvarview.Columns.Add(C);
	C= new DataColumn("idlcard", typeof(int));
	C.AllowDBNull=false;
	tlcardvarview.Columns.Add(C);
	C= new DataColumn("idlcardvar", typeof(int));
	C.AllowDBNull=false;
	tlcardvarview.Columns.Add(C);
	C= new DataColumn("amount", typeof(decimal));
	C.AllowDBNull=false;
	tlcardvarview.Columns.Add(C);
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tlcardvarview.Columns.Add(C);
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tlcardvarview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tlcardvarview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tlcardvarview.Columns.Add(C);
	tlcardvarview.Columns.Add( new DataColumn("email", typeof(string)));
	tlcardvarview.Columns.Add( new DataColumn("yvar", typeof(short)));
	tlcardvarview.Columns.Add( new DataColumn("nvar", typeof(int)));
	tlcardvarview.Columns.Add( new DataColumn("description", typeof(string)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tlcardvarview.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tlcardvarview.Columns.Add(C);
	tlcardvarview.Columns.Add( new DataColumn("lcard", typeof(string)));
	tlcardvarview.Columns.Add( new DataColumn("extcode", typeof(string)));
	tlcardvarview.Columns.Add( new DataColumn("codeupb", typeof(string)));
	tlcardvarview.Columns.Add( new DataColumn("upb", typeof(string)));
	tlcardvarview.Columns.Add( new DataColumn("paridupb", typeof(string)));
	tlcardvarview.Columns.Add( new DataColumn("ayear", typeof(short)));
	tlcardvarview.Columns.Add( new DataColumn("codefin", typeof(string)));
	tlcardvarview.Columns.Add( new DataColumn("fin", typeof(string)));
	tlcardvarview.Columns.Add( new DataColumn("nlevel", typeof(byte)));
	tlcardvarview.Columns.Add( new DataColumn("paridfin", typeof(int)));
	tlcardvarview.Columns.Add( new DataColumn("parcodefin", typeof(string)));
	tlcardvarview.Columns.Add( new DataColumn("parfintitle", typeof(string)));
	tlcardvarview.Columns.Add( new DataColumn("parfinlevel", typeof(byte)));
	tlcardvarview.Columns.Add( new DataColumn("idman", typeof(int)));
	tlcardvarview.Columns.Add( new DataColumn("manager", typeof(string)));
	Tables.Add(tlcardvarview);
	tlcardvarview.PrimaryKey =  new DataColumn[]{tlcardvarview.Columns["idlcardvar"]};


	//////////////////// FINVARATTACHMENT /////////////////////////////////
	var tfinvarattachment= new DataTable("finvarattachment");
	C= new DataColumn("yvar", typeof(short));
	C.AllowDBNull=false;
	tfinvarattachment.Columns.Add(C);
	C= new DataColumn("nvar", typeof(int));
	C.AllowDBNull=false;
	tfinvarattachment.Columns.Add(C);
	C= new DataColumn("idattachment", typeof(int));
	C.AllowDBNull=false;
	tfinvarattachment.Columns.Add(C);
	tfinvarattachment.Columns.Add( new DataColumn("filename", typeof(string)));
	tfinvarattachment.Columns.Add( new DataColumn("attachment", typeof(Byte[])));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfinvarattachment.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfinvarattachment.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfinvarattachment.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfinvarattachment.Columns.Add(C);
	Tables.Add(tfinvarattachment);
	tfinvarattachment.PrimaryKey =  new DataColumn[]{tfinvarattachment.Columns["yvar"], tfinvarattachment.Columns["nvar"], tfinvarattachment.Columns["idattachment"]};


	//////////////////// SORTING01 /////////////////////////////////
	var tsorting01= new DataTable("sorting01");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	tsorting01.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting01.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting01.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting01.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting01.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting01.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting01.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting01.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting01.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting01.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting01.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting01.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting01.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting01.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting01.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	tsorting01.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	tsorting01.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting01.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting01.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	tsorting01.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	tsorting01.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	tsorting01.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting01.Columns.Add( new DataColumn("stop", typeof(short)));
	Tables.Add(tsorting01);
	tsorting01.PrimaryKey =  new DataColumn[]{tsorting01.Columns["idsor"]};


	//////////////////// SORTING02 /////////////////////////////////
	var tsorting02= new DataTable("sorting02");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	tsorting02.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting02.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting02.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting02.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting02.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting02.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting02.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting02.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting02.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting02.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting02.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting02.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting02.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting02.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting02.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	tsorting02.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	tsorting02.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting02.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting02.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	tsorting02.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	tsorting02.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	tsorting02.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting02.Columns.Add( new DataColumn("stop", typeof(short)));
	Tables.Add(tsorting02);
	tsorting02.PrimaryKey =  new DataColumn[]{tsorting02.Columns["idsor"]};


	//////////////////// SORTING03 /////////////////////////////////
	var tsorting03= new DataTable("sorting03");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	tsorting03.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting03.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting03.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting03.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting03.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting03.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting03.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting03.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting03.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting03.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting03.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting03.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting03.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting03.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting03.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	tsorting03.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	tsorting03.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting03.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting03.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	tsorting03.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	tsorting03.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	tsorting03.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting03.Columns.Add( new DataColumn("stop", typeof(short)));
	Tables.Add(tsorting03);
	tsorting03.PrimaryKey =  new DataColumn[]{tsorting03.Columns["idsor"]};


	//////////////////// SORTING04 /////////////////////////////////
	var tsorting04= new DataTable("sorting04");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	tsorting04.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting04.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting04.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting04.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting04.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting04.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting04.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting04.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting04.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting04.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting04.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting04.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting04.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting04.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting04.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	tsorting04.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	tsorting04.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting04.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting04.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	tsorting04.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	tsorting04.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	tsorting04.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting04.Columns.Add( new DataColumn("stop", typeof(short)));
	Tables.Add(tsorting04);
	tsorting04.PrimaryKey =  new DataColumn[]{tsorting04.Columns["idsor"]};


	//////////////////// SORTING05 /////////////////////////////////
	var tsorting05= new DataTable("sorting05");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	tsorting05.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting05.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting05.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting05.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting05.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting05.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting05.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting05.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting05.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting05.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting05.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting05.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting05.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting05.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting05.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	tsorting05.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	tsorting05.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting05.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting05.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	tsorting05.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	tsorting05.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	tsorting05.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting05.Columns.Add( new DataColumn("stop", typeof(short)));
	Tables.Add(tsorting05);
	tsorting05.PrimaryKey =  new DataColumn[]{tsorting05.Columns["idsor"]};


	//////////////////// UNDERWRITING /////////////////////////////////
	var tunderwriting= new DataTable("underwriting");
	C= new DataColumn("idunderwriting", typeof(int));
	C.AllowDBNull=false;
	tunderwriting.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tunderwriting.Columns.Add(C);
	Tables.Add(tunderwriting);
	tunderwriting.PrimaryKey =  new DataColumn[]{tunderwriting.Columns["idunderwriting"]};


	//////////////////// VARIATIONKIND /////////////////////////////////
	var tvariationkind= new DataTable("variationkind");
	C= new DataColumn("idvariationkind", typeof(byte));
	C.AllowDBNull=false;
	tvariationkind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tvariationkind.Columns.Add(C);
	Tables.Add(tvariationkind);
	tvariationkind.PrimaryKey =  new DataColumn[]{tvariationkind.Columns["idvariationkind"]};


	//////////////////// FINVARKIND /////////////////////////////////
	var tfinvarkind= new DataTable("finvarkind");
	C= new DataColumn("idfinvarkind", typeof(int));
	C.AllowDBNull=false;
	tfinvarkind.Columns.Add(C);
	C= new DataColumn("codevarkind", typeof(string));
	C.AllowDBNull=false;
	tfinvarkind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tfinvarkind.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfinvarkind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfinvarkind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfinvarkind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfinvarkind.Columns.Add(C);
	Tables.Add(tfinvarkind);
	tfinvarkind.PrimaryKey =  new DataColumn[]{tfinvarkind.Columns["idfinvarkind"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{finvar.Columns["yvar"], finvar.Columns["nvar"]};
	var cChild = new []{finvarattachment.Columns["yvar"], finvarattachment.Columns["nvar"]};
	Relations.Add(new DataRelation("finvar_finvarattachment",cPar,cChild,false));

	cPar = new []{finvar.Columns["yvar"], finvar.Columns["nvar"]};
	cChild = new []{lcardvarview.Columns["yvar"], lcardvarview.Columns["nvar"]};
	Relations.Add(new DataRelation("finvar_lcardvarview",cPar,cChild,false));

	cPar = new []{finvarkind.Columns["idfinvarkind"]};
	cChild = new []{finvar.Columns["idfinvarkind"]};
	Relations.Add(new DataRelation("FK_finvarkind_finvar",cPar,cChild,false));

	cPar = new []{manager.Columns["idman"]};
	cChild = new []{finvar.Columns["idman"]};
	Relations.Add(new DataRelation("FK_manager_finvar",cPar,cChild,false));

	cPar = new []{finvarstatus.Columns["idfinvarstatus"]};
	cChild = new []{finvar.Columns["idfinvarstatus"]};
	Relations.Add(new DataRelation("finvarstatus_finvar",cPar,cChild,false));

	cPar = new []{enactment.Columns["idenactment"]};
	cChild = new []{finvar.Columns["idenactment"]};
	Relations.Add(new DataRelation("administrativeact_finvar",cPar,cChild,false));

	cPar = new []{sorting01.Columns["idsor"]};
	cChild = new []{finvar.Columns["idsor01"]};
	Relations.Add(new DataRelation("sorting01_finvar",cPar,cChild,false));

	cPar = new []{sorting02.Columns["idsor"]};
	cChild = new []{finvar.Columns["idsor02"]};
	Relations.Add(new DataRelation("sorting02_finvar",cPar,cChild,false));

	cPar = new []{sorting03.Columns["idsor"]};
	cChild = new []{finvar.Columns["idsor03"]};
	Relations.Add(new DataRelation("sorting03_finvar",cPar,cChild,false));

	cPar = new []{sorting04.Columns["idsor"]};
	cChild = new []{finvar.Columns["idsor04"]};
	Relations.Add(new DataRelation("sorting04_finvar",cPar,cChild,false));

	cPar = new []{sorting05.Columns["idsor"]};
	cChild = new []{finvar.Columns["idsor05"]};
	Relations.Add(new DataRelation("sorting05_finvar",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{finvardetail.Columns["idupb"]};
	Relations.Add(new DataRelation("upbfinvardetail",cPar,cChild,false));

	cPar = new []{finvar.Columns["yvar"], finvar.Columns["nvar"]};
	cChild = new []{finvardetail.Columns["yvar"], finvardetail.Columns["nvar"]};
	Relations.Add(new DataRelation("finvarfinvardetail",cPar,cChild,false));

	cPar = new []{fin.Columns["idfin"]};
	cChild = new []{finvardetail.Columns["idfin"]};
	Relations.Add(new DataRelation("finfinvardetail",cPar,cChild,false));

	cPar = new []{underwriting.Columns["idunderwriting"]};
	cChild = new []{finvardetail.Columns["idunderwriting"]};
	Relations.Add(new DataRelation("underwriting_finvardetail",cPar,cChild,false));

	#endregion

}
}
}
