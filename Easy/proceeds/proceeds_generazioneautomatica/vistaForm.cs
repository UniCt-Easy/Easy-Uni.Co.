
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


using System;
using System.Data;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;
#pragma warning disable 1591
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace proceeds_generazioneautomatica {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable proceeds 		=> Tables["proceeds"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry 		=> Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable fin 		=> Tables["fin"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable treasurer 		=> Tables["treasurer"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable manager 		=> Tables["manager"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomephase 		=> Tables["incomephase"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable config 		=> Tables["config"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomelastview 		=> Tables["incomelastview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable stamphandling 		=> Tables["stamphandling"];

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
	//////////////////// PROCEEDS /////////////////////////////////
	var tproceeds= new DataTable("proceeds");
	C= new DataColumn("kpro", typeof(int));
	C.AllowDBNull=false;
	tproceeds.Columns.Add(C);
	C= new DataColumn("ypro", typeof(short));
	C.AllowDBNull=false;
	tproceeds.Columns.Add(C);
	C= new DataColumn("npro", typeof(int));
	C.AllowDBNull=false;
	tproceeds.Columns.Add(C);
	tproceeds.Columns.Add( new DataColumn("npro_treasurer", typeof(int)));
	tproceeds.Columns.Add( new DataColumn("kproceedstransmission", typeof(int)));
	tproceeds.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tproceeds.Columns.Add(C);
	tproceeds.Columns.Add( new DataColumn("idreg", typeof(int)));
	tproceeds.Columns.Add( new DataColumn("idfin", typeof(int)));
	tproceeds.Columns.Add( new DataColumn("idman", typeof(int)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tproceeds.Columns.Add(C);
	tproceeds.Columns.Add( new DataColumn("printdate", typeof(DateTime)));
	tproceeds.Columns.Add( new DataColumn("txt", typeof(string)));
	tproceeds.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tproceeds.Columns.Add(C);
	tproceeds.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tproceeds.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tproceeds.Columns.Add(C);
	tproceeds.Columns.Add( new DataColumn("idstamphandling", typeof(int)));
	tproceeds.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tproceeds.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tproceeds.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tproceeds.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tproceeds.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tproceeds);
	tproceeds.PrimaryKey =  new DataColumn[]{tproceeds.Columns["kpro"]};


	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new DataTable("registry");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("cf", typeof(string)));
	tregistry.Columns.Add( new DataColumn("p_iva", typeof(string)));
	C= new DataColumn("residence", typeof(int));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("annotation", typeof(string)));
	tregistry.Columns.Add( new DataColumn("birthdate", typeof(DateTime)));
	tregistry.Columns.Add( new DataColumn("gender", typeof(string)));
	tregistry.Columns.Add( new DataColumn("surname", typeof(string)));
	tregistry.Columns.Add( new DataColumn("forename", typeof(string)));
	tregistry.Columns.Add( new DataColumn("foreigncf", typeof(string)));
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("txt", typeof(string)));
	tregistry.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	Tables.Add(tregistry);
	tregistry.PrimaryKey =  new DataColumn[]{tregistry.Columns["idreg"]};


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
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	tfin.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	tfin.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	tfin.Columns.Add( new DataColumn("paridfin", typeof(int)));
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	Tables.Add(tfin);
	tfin.PrimaryKey =  new DataColumn[]{tfin.Columns["idfin"]};


	//////////////////// TREASURER /////////////////////////////////
	var ttreasurer= new DataTable("treasurer");
	C= new DataColumn("idtreasurer", typeof(int));
	C.AllowDBNull=false;
	ttreasurer.Columns.Add(C);
	ttreasurer.Columns.Add( new DataColumn("description", typeof(string)));
	C= new DataColumn("flagdefault", typeof(string));
	C.AllowDBNull=false;
	ttreasurer.Columns.Add(C);
	ttreasurer.Columns.Add( new DataColumn("cin", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("idbank", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("idcab", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("cc", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("address", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("cap", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("city", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("country", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("phoneprefix", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("phonenumber", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("faxprefix", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("faxnumber", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("flagfruitful", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("idsor01", typeof(int)));
	ttreasurer.Columns.Add( new DataColumn("idsor02", typeof(int)));
	ttreasurer.Columns.Add( new DataColumn("idsor03", typeof(int)));
	ttreasurer.Columns.Add( new DataColumn("idsor04", typeof(int)));
	ttreasurer.Columns.Add( new DataColumn("idsor05", typeof(int)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	ttreasurer.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	ttreasurer.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	ttreasurer.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	ttreasurer.Columns.Add(C);
	ttreasurer.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(ttreasurer);
	ttreasurer.PrimaryKey =  new DataColumn[]{ttreasurer.Columns["idtreasurer"]};


	//////////////////// MANAGER /////////////////////////////////
	var tmanager= new DataTable("manager");
	C= new DataColumn("idman", typeof(int));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("iddivision", typeof(int));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	tmanager.Columns.Add( new DataColumn("email", typeof(string)));
	tmanager.Columns.Add( new DataColumn("phonenumber", typeof(string)));
	tmanager.Columns.Add( new DataColumn("userweb", typeof(string)));
	tmanager.Columns.Add( new DataColumn("passwordweb", typeof(string)));
	tmanager.Columns.Add( new DataColumn("txt", typeof(string)));
	tmanager.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	tmanager.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tmanager);
	tmanager.PrimaryKey =  new DataColumn[]{tmanager.Columns["idman"]};


	//////////////////// INCOMEPHASE /////////////////////////////////
	var tincomephase= new DataTable("incomephase");
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	tincomephase.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tincomephase.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tincomephase.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tincomephase.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tincomephase.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tincomephase.Columns.Add(C);
	Tables.Add(tincomephase);
	tincomephase.PrimaryKey =  new DataColumn[]{tincomephase.Columns["nphase"]};


	//////////////////// CONFIG /////////////////////////////////
	var tconfig= new DataTable("config");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tconfig.Columns.Add(C);
	tconfig.Columns.Add( new DataColumn("automanagekind", typeof(int)));
	tconfig.Columns.Add( new DataColumn("agencycode", typeof(string)));
	tconfig.Columns.Add( new DataColumn("appname", typeof(string)));
	tconfig.Columns.Add( new DataColumn("appropriationphasecode", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("assessmentphasecode", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("asset_flagnumbering", typeof(string)));
	tconfig.Columns.Add( new DataColumn("asset_flagrestart", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flag_autodocnumbering", typeof(int)));
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
	tconfig.Columns.Add( new DataColumn("flag_paymentamount", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("flagautopayment", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagautoproceeds", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagcredit", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagepexp", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagfruitful", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagpayment", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagproceeds", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagrefund", typeof(string)));
	tconfig.Columns.Add( new DataColumn("taxvaliditykind", typeof(byte)));
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
	tconfig.Columns.Add( new DataColumn("flagbank_grouping", typeof(int)));
	tconfig.Columns.Add( new DataColumn("fin_kind", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("prevpartitiontitle", typeof(string)));
	tconfig.Columns.Add( new DataColumn("proceeds_finlevel", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("proceeds_flag", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("proceeds_flagautoprintdate", typeof(string)));
	tconfig.Columns.Add( new DataColumn("profservice_flagrestart", typeof(string)));
	tconfig.Columns.Add( new DataColumn("refundagency", typeof(int)));
	tconfig.Columns.Add( new DataColumn("wageaddition_flagrestart", typeof(string)));
	Tables.Add(tconfig);
	tconfig.PrimaryKey =  new DataColumn[]{tconfig.Columns["ayear"]};


	//////////////////// INCOMELASTVIEW /////////////////////////////////
	var tincomelastview= new DataTable("incomelastview");
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tincomelastview.Columns.Add(C);
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	tincomelastview.Columns.Add(C);
	C= new DataColumn("phase", typeof(string));
	C.AllowDBNull=false;
	tincomelastview.Columns.Add(C);
	C= new DataColumn("ymov", typeof(short));
	C.AllowDBNull=false;
	tincomelastview.Columns.Add(C);
	C= new DataColumn("nmov", typeof(int));
	C.AllowDBNull=false;
	tincomelastview.Columns.Add(C);
	tincomelastview.Columns.Add( new DataColumn("parentymov", typeof(short)));
	tincomelastview.Columns.Add( new DataColumn("parentnmov", typeof(int)));
	tincomelastview.Columns.Add( new DataColumn("parentidinc", typeof(int)));
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tincomelastview.Columns.Add(C);
	tincomelastview.Columns.Add( new DataColumn("idfin", typeof(int)));
	tincomelastview.Columns.Add( new DataColumn("codefin", typeof(string)));
	tincomelastview.Columns.Add( new DataColumn("finance", typeof(string)));
	tincomelastview.Columns.Add( new DataColumn("idupb", typeof(string)));
	tincomelastview.Columns.Add( new DataColumn("codeupb", typeof(string)));
	tincomelastview.Columns.Add( new DataColumn("upb", typeof(string)));
	tincomelastview.Columns.Add( new DataColumn("idreg", typeof(int)));
	tincomelastview.Columns.Add( new DataColumn("registry", typeof(string)));
	tincomelastview.Columns.Add( new DataColumn("idman", typeof(int)));
	tincomelastview.Columns.Add( new DataColumn("manager", typeof(string)));
	tincomelastview.Columns.Add( new DataColumn("kpro", typeof(int)));
	tincomelastview.Columns.Add( new DataColumn("ypro", typeof(short)));
	tincomelastview.Columns.Add( new DataColumn("npro", typeof(int)));
	tincomelastview.Columns.Add( new DataColumn("doc", typeof(string)));
	tincomelastview.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tincomelastview.Columns.Add(C);
	tincomelastview.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tincomelastview.Columns.Add( new DataColumn("ayearstartamount", typeof(decimal)));
	tincomelastview.Columns.Add( new DataColumn("curramount", typeof(decimal)));
	tincomelastview.Columns.Add( new DataColumn("available", typeof(decimal)));
	tincomelastview.Columns.Add( new DataColumn("unpartitioned", typeof(decimal)));
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tincomelastview.Columns.Add(C);
	C= new DataColumn("totflag", typeof(byte));
	C.AllowDBNull=false;
	tincomelastview.Columns.Add(C);
	tincomelastview.Columns.Add( new DataColumn("flagarrear", typeof(string)));
	tincomelastview.Columns.Add( new DataColumn("autokind", typeof(byte)));
	tincomelastview.Columns.Add( new DataColumn("autocode", typeof(int)));
	tincomelastview.Columns.Add( new DataColumn("idpayment", typeof(int)));
	tincomelastview.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tincomelastview.Columns.Add(C);
	tincomelastview.Columns.Add( new DataColumn("nbill", typeof(int)));
	tincomelastview.Columns.Add( new DataColumn("idpro", typeof(int)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tincomelastview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tincomelastview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tincomelastview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tincomelastview.Columns.Add(C);
	tincomelastview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tincomelastview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tincomelastview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tincomelastview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tincomelastview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tincomelastview.Columns.Add( new DataColumn("codetreasurer", typeof(string)));
	tincomelastview.Columns.Add( new DataColumn("treasurer", typeof(string)));
	Tables.Add(tincomelastview);
	tincomelastview.PrimaryKey =  new DataColumn[]{tincomelastview.Columns["idinc"]};


	//////////////////// STAMPHANDLING /////////////////////////////////
	var tstamphandling= new DataTable("stamphandling");
	tstamphandling.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tstamphandling.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tstamphandling.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tstamphandling.Columns.Add(C);
	C= new DataColumn("flagdefault", typeof(string));
	C.AllowDBNull=false;
	tstamphandling.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tstamphandling.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tstamphandling.Columns.Add(C);
	tstamphandling.Columns.Add( new DataColumn("handlingbankcode", typeof(string)));
	C= new DataColumn("idstamphandling", typeof(int));
	C.AllowDBNull=false;
	tstamphandling.Columns.Add(C);
	Tables.Add(tstamphandling);
	tstamphandling.PrimaryKey =  new DataColumn[]{tstamphandling.Columns["idstamphandling"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{proceeds.Columns["kpro"]};
	var cChild = new []{incomelastview.Columns["kpro"]};
	Relations.Add(new DataRelation("proceeds_incomelastview",cPar,cChild,false));

	cPar = new []{manager.Columns["idman"]};
	cChild = new []{proceeds.Columns["idman"]};
	Relations.Add(new DataRelation("managerproceeds",cPar,cChild,false));

	cPar = new []{treasurer.Columns["idtreasurer"]};
	cChild = new []{proceeds.Columns["idtreasurer"]};
	Relations.Add(new DataRelation("treasurerproceeds",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{proceeds.Columns["idreg"]};
	Relations.Add(new DataRelation("registryproceeds",cPar,cChild,false));

	cPar = new []{fin.Columns["idfin"]};
	cChild = new []{proceeds.Columns["idfin"]};
	Relations.Add(new DataRelation("finproceeds",cPar,cChild,false));

	cPar = new []{stamphandling.Columns["idstamphandling"]};
	cChild = new []{proceeds.Columns["idstamphandling"]};
	Relations.Add(new DataRelation("FK_stamphandling_proceeds",cPar,cChild,false));

	#endregion

}
}
}
