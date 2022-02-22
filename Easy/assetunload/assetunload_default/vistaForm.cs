
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
namespace assetunload_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Buono di scarico
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetunload 		=> Tables["assetunload"];

	///<summary>
	///Causali di scarico
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetunloadmotive 		=> Tables["assetunloadmotive"];

	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry 		=> Tables["registry"];

	///<summary>
	///Movimenti di entrata collegati a buoni di scarico
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetunloadincome 		=> Tables["assetunloadincome"];

	///<summary>
	///Fasi di entrata
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomephase 		=> Tables["incomephase"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomeview 		=> Tables["incomeview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetunloadkindview 		=> Tables["assetunloadkindview"];

	///<summary>
	///Configurazione Annuale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable config 		=> Tables["config"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetamortizationunloadview 		=> Tables["assetamortizationunloadview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetpieceview 		=> Tables["assetpieceview"];

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
	//////////////////// ASSETUNLOAD /////////////////////////////////
	var tassetunload= new DataTable("assetunload");
	C= new DataColumn("idassetunload", typeof(int));
	C.AllowDBNull=false;
	tassetunload.Columns.Add(C);
	C= new DataColumn("idassetunloadkind", typeof(int));
	C.AllowDBNull=false;
	tassetunload.Columns.Add(C);
	C= new DataColumn("yassetunload", typeof(short));
	C.AllowDBNull=false;
	tassetunload.Columns.Add(C);
	C= new DataColumn("nassetunload", typeof(int));
	C.AllowDBNull=false;
	tassetunload.Columns.Add(C);
	tassetunload.Columns.Add( new DataColumn("idreg", typeof(int)));
	tassetunload.Columns.Add( new DataColumn("idmot", typeof(int)));
	tassetunload.Columns.Add( new DataColumn("doc", typeof(string)));
	tassetunload.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	tassetunload.Columns.Add( new DataColumn("description", typeof(string)));
	tassetunload.Columns.Add( new DataColumn("enactment", typeof(string)));
	tassetunload.Columns.Add( new DataColumn("enactmentdate", typeof(DateTime)));
	tassetunload.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	tassetunload.Columns.Add( new DataColumn("printdate", typeof(DateTime)));
	tassetunload.Columns.Add( new DataColumn("ratificationdate", typeof(DateTime)));
	tassetunload.Columns.Add( new DataColumn("txt", typeof(string)));
	tassetunload.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tassetunload.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tassetunload.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tassetunload.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tassetunload.Columns.Add(C);
	tassetunload.Columns.Add( new DataColumn("transmitted", typeof(string)));
	Tables.Add(tassetunload);
	tassetunload.PrimaryKey =  new DataColumn[]{tassetunload.Columns["idassetunload"]};


	//////////////////// ASSETUNLOADMOTIVE /////////////////////////////////
	var tassetunloadmotive= new DataTable("assetunloadmotive");
	C= new DataColumn("idmot", typeof(int));
	C.AllowDBNull=false;
	tassetunloadmotive.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tassetunloadmotive.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tassetunloadmotive.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tassetunloadmotive.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tassetunloadmotive.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tassetunloadmotive.Columns.Add(C);
	tassetunloadmotive.Columns.Add( new DataColumn("active", typeof(string)));
	tassetunloadmotive.Columns.Add( new DataColumn("flag", typeof(int)));
	Tables.Add(tassetunloadmotive);
	tassetunloadmotive.PrimaryKey =  new DataColumn[]{tassetunloadmotive.Columns["idmot"]};


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
	tregistry.Columns.Add( new DataColumn("badgecode", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcategory", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcentralizedcategory", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idmaritalstatus", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idtitle", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idregistryclass", typeof(string)));
	tregistry.Columns.Add( new DataColumn("maritalsurname", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcity", typeof(int)));
	tregistry.Columns.Add( new DataColumn("idnation", typeof(int)));
	tregistry.Columns.Add( new DataColumn("location", typeof(string)));
	tregistry.Columns.Add( new DataColumn("extmatricula", typeof(string)));
	Tables.Add(tregistry);
	tregistry.PrimaryKey =  new DataColumn[]{tregistry.Columns["idreg"]};


	//////////////////// ASSETUNLOADINCOME /////////////////////////////////
	var tassetunloadincome= new DataTable("assetunloadincome");
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tassetunloadincome.Columns.Add(C);
	tassetunloadincome.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tassetunloadincome.Columns.Add( new DataColumn("cu", typeof(string)));
	tassetunloadincome.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tassetunloadincome.Columns.Add( new DataColumn("lu", typeof(string)));
	tassetunloadincome.Columns.Add( new DataColumn("!ymov", typeof(short)));
	tassetunloadincome.Columns.Add( new DataColumn("!nmov", typeof(int)));
	tassetunloadincome.Columns.Add( new DataColumn("!incomedescription", typeof(string)));
	tassetunloadincome.Columns.Add( new DataColumn("!incomedoc", typeof(string)));
	tassetunloadincome.Columns.Add( new DataColumn("!amount", typeof(string)));
	tassetunloadincome.Columns.Add( new DataColumn("!available", typeof(string)));
	C= new DataColumn("idassetunload", typeof(int));
	C.AllowDBNull=false;
	tassetunloadincome.Columns.Add(C);
	Tables.Add(tassetunloadincome);
	tassetunloadincome.PrimaryKey =  new DataColumn[]{tassetunloadincome.Columns["idassetunload"], tassetunloadincome.Columns["idinc"]};


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


	//////////////////// INCOMEVIEW /////////////////////////////////
	var tincomeview= new DataTable("incomeview");
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	C= new DataColumn("phase", typeof(string));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	C= new DataColumn("ymov", typeof(short));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	C= new DataColumn("nmov", typeof(int));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	tincomeview.Columns.Add( new DataColumn("parentidinc", typeof(int)));
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	tincomeview.Columns.Add( new DataColumn("idfin", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("codefin", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("finance", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("idreg", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("registry", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("idman", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("manager", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("ypro", typeof(short)));
	tincomeview.Columns.Add( new DataColumn("npro", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("doc", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	tincomeview.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tincomeview.Columns.Add( new DataColumn("ayearstartamount", typeof(decimal)));
	tincomeview.Columns.Add( new DataColumn("curramount", typeof(decimal)));
	tincomeview.Columns.Add( new DataColumn("available", typeof(decimal)));
	C= new DataColumn("unpartitioned", typeof(decimal));
	C.ReadOnly=true;
	tincomeview.Columns.Add(C);
	tincomeview.Columns.Add( new DataColumn("flagarrear", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("autokind", typeof(byte)));
	tincomeview.Columns.Add( new DataColumn("idpayment", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	tincomeview.Columns.Add( new DataColumn("idupb", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("codeupb", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("upb", typeof(string)));
	Tables.Add(tincomeview);
	tincomeview.PrimaryKey =  new DataColumn[]{tincomeview.Columns["idinc"]};


	//////////////////// ASSETUNLOADKINDVIEW /////////////////////////////////
	var tassetunloadkindview= new DataTable("assetunloadkindview");
	C= new DataColumn("idassetunloadkind", typeof(int));
	C.AllowDBNull=false;
	tassetunloadkindview.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tassetunloadkindview.Columns.Add(C);
	tassetunloadkindview.Columns.Add( new DataColumn("idinventory", typeof(int)));
	C= new DataColumn("inventory", typeof(string));
	C.AllowDBNull=false;
	tassetunloadkindview.Columns.Add(C);
	tassetunloadkindview.Columns.Add( new DataColumn("startnumber", typeof(int)));
	C= new DataColumn("flaglinear", typeof(string));
	C.AllowDBNull=false;
	tassetunloadkindview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tassetunloadkindview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tassetunloadkindview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tassetunloadkindview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tassetunloadkindview.Columns.Add(C);
	tassetunloadkindview.Columns.Add( new DataColumn("active", typeof(string)));
	tassetunloadkindview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tassetunloadkindview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tassetunloadkindview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tassetunloadkindview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tassetunloadkindview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tassetunloadkindview);
	tassetunloadkindview.PrimaryKey =  new DataColumn[]{tassetunloadkindview.Columns["idassetunloadkind"]};


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


	//////////////////// ASSETAMORTIZATIONUNLOADVIEW /////////////////////////////////
	var tassetamortizationunloadview= new DataTable("assetamortizationunloadview");
	C= new DataColumn("namortization", typeof(int));
	C.AllowDBNull=false;
	tassetamortizationunloadview.Columns.Add(C);
	C= new DataColumn("idasset", typeof(int));
	C.AllowDBNull=false;
	tassetamortizationunloadview.Columns.Add(C);
	tassetamortizationunloadview.Columns.Add( new DataColumn("idpiece", typeof(int)));
	C= new DataColumn("idinventoryamortization", typeof(int));
	C.AllowDBNull=false;
	tassetamortizationunloadview.Columns.Add(C);
	C= new DataColumn("codeinventoryamortization", typeof(string));
	C.AllowDBNull=false;
	tassetamortizationunloadview.Columns.Add(C);
	C= new DataColumn("inventoryamortization", typeof(string));
	C.AllowDBNull=false;
	tassetamortizationunloadview.Columns.Add(C);
	C= new DataColumn("idinventory", typeof(int));
	C.AllowDBNull=false;
	tassetamortizationunloadview.Columns.Add(C);
	C= new DataColumn("inventory", typeof(string));
	C.AllowDBNull=false;
	tassetamortizationunloadview.Columns.Add(C);
	tassetamortizationunloadview.Columns.Add( new DataColumn("ninventory", typeof(int)));
	tassetamortizationunloadview.Columns.Add( new DataColumn("idlocation", typeof(int)));
	tassetamortizationunloadview.Columns.Add( new DataColumn("locationcode", typeof(string)));
	tassetamortizationunloadview.Columns.Add( new DataColumn("location", typeof(string)));
	tassetamortizationunloadview.Columns.Add( new DataColumn("idcurrlocation", typeof(int)));
	tassetamortizationunloadview.Columns.Add( new DataColumn("currlocationcode", typeof(string)));
	tassetamortizationunloadview.Columns.Add( new DataColumn("currlocation", typeof(string)));
	tassetamortizationunloadview.Columns.Add( new DataColumn("idman", typeof(int)));
	tassetamortizationunloadview.Columns.Add( new DataColumn("manager", typeof(string)));
	tassetamortizationunloadview.Columns.Add( new DataColumn("idcurrman", typeof(int)));
	tassetamortizationunloadview.Columns.Add( new DataColumn("currmanager", typeof(string)));
	C= new DataColumn("nassetacquire", typeof(int));
	C.AllowDBNull=false;
	tassetamortizationunloadview.Columns.Add(C);
	C= new DataColumn("loaddescription", typeof(string));
	C.AllowDBNull=false;
	tassetamortizationunloadview.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tassetamortizationunloadview.Columns.Add(C);
	tassetamortizationunloadview.Columns.Add( new DataColumn("assetvalue", typeof(decimal)));
	tassetamortizationunloadview.Columns.Add( new DataColumn("amortizationquota", typeof(double)));
	C= new DataColumn("amount", typeof(decimal));
	C.ReadOnly=true;
	tassetamortizationunloadview.Columns.Add(C);
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tassetamortizationunloadview.Columns.Add(C);
	tassetamortizationunloadview.Columns.Add( new DataColumn("idassetunload", typeof(int)));
	tassetamortizationunloadview.Columns.Add( new DataColumn("idassetunloadkind", typeof(int)));
	tassetamortizationunloadview.Columns.Add( new DataColumn("assetunloadkind", typeof(string)));
	tassetamortizationunloadview.Columns.Add( new DataColumn("yassetunload", typeof(short)));
	tassetamortizationunloadview.Columns.Add( new DataColumn("nassetunload", typeof(int)));
	tassetamortizationunloadview.Columns.Add( new DataColumn("idassetload", typeof(int)));
	tassetamortizationunloadview.Columns.Add( new DataColumn("idassetloadkind", typeof(int)));
	tassetamortizationunloadview.Columns.Add( new DataColumn("assetloadkind", typeof(string)));
	tassetamortizationunloadview.Columns.Add( new DataColumn("yassetload", typeof(short)));
	tassetamortizationunloadview.Columns.Add( new DataColumn("nassetload", typeof(int)));
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tassetamortizationunloadview.Columns.Add(C);
	C= new DataColumn("flagunload", typeof(string));
	C.ReadOnly=true;
	tassetamortizationunloadview.Columns.Add(C);
	C= new DataColumn("flagload", typeof(string));
	C.ReadOnly=true;
	tassetamortizationunloadview.Columns.Add(C);
	tassetamortizationunloadview.Columns.Add( new DataColumn("transmitted", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tassetamortizationunloadview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tassetamortizationunloadview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tassetamortizationunloadview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tassetamortizationunloadview.Columns.Add(C);
	tassetamortizationunloadview.Columns.Add( new DataColumn("idsor1", typeof(int)));
	tassetamortizationunloadview.Columns.Add( new DataColumn("idsor2", typeof(int)));
	tassetamortizationunloadview.Columns.Add( new DataColumn("idsor3", typeof(int)));
	tassetamortizationunloadview.Columns.Add( new DataColumn("idupb", typeof(string)));
	Tables.Add(tassetamortizationunloadview);
	tassetamortizationunloadview.PrimaryKey =  new DataColumn[]{tassetamortizationunloadview.Columns["namortization"]};


	//////////////////// ASSETPIECEVIEW /////////////////////////////////
	var tassetpieceview= new DataTable("assetpieceview");
	C= new DataColumn("idasset", typeof(int));
	C.AllowDBNull=false;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("idpiece", typeof(int));
	C.AllowDBNull=false;
	tassetpieceview.Columns.Add(C);
	tassetpieceview.Columns.Add( new DataColumn("lifestart", typeof(DateTime)));
	C= new DataColumn("yearstart", typeof(int));
	C.ReadOnly=true;
	tassetpieceview.Columns.Add(C);
	tassetpieceview.Columns.Add( new DataColumn("nassetacquire", typeof(int)));
	tassetpieceview.Columns.Add( new DataColumn("idupb", typeof(string)));
	tassetpieceview.Columns.Add( new DataColumn("ninventory", typeof(int)));
	tassetpieceview.Columns.Add( new DataColumn("idlocation", typeof(int)));
	tassetpieceview.Columns.Add( new DataColumn("locationcode", typeof(string)));
	tassetpieceview.Columns.Add( new DataColumn("location", typeof(string)));
	tassetpieceview.Columns.Add( new DataColumn("idcurrlocation", typeof(int)));
	tassetpieceview.Columns.Add( new DataColumn("currlocationcode", typeof(string)));
	tassetpieceview.Columns.Add( new DataColumn("currlocation", typeof(string)));
	tassetpieceview.Columns.Add( new DataColumn("idman", typeof(int)));
	tassetpieceview.Columns.Add( new DataColumn("manager", typeof(string)));
	tassetpieceview.Columns.Add( new DataColumn("idcurrman", typeof(int)));
	tassetpieceview.Columns.Add( new DataColumn("currmanager", typeof(string)));
	C= new DataColumn("idinv", typeof(int));
	C.AllowDBNull=false;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("codeinv", typeof(string));
	C.AllowDBNull=false;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("idinv_lev1", typeof(int));
	C.AllowDBNull=false;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("codeinv_lev1", typeof(string));
	C.AllowDBNull=false;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("inventorytree", typeof(string));
	C.AllowDBNull=false;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("inventorytree_lev1", typeof(string));
	C.AllowDBNull=false;
	tassetpieceview.Columns.Add(C);
	tassetpieceview.Columns.Add( new DataColumn("idinventory", typeof(int)));
	C= new DataColumn("inventory", typeof(string));
	C.AllowDBNull=false;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("descriptionmain", typeof(string));
	C.ReadOnly=true;
	tassetpieceview.Columns.Add(C);
	tassetpieceview.Columns.Add( new DataColumn("idassetload", typeof(int)));
	tassetpieceview.Columns.Add( new DataColumn("idassetloadkind", typeof(int)));
	tassetpieceview.Columns.Add( new DataColumn("yassetload", typeof(short)));
	tassetpieceview.Columns.Add( new DataColumn("nassetload", typeof(int)));
	tassetpieceview.Columns.Add( new DataColumn("taxable", typeof(decimal)));
	C= new DataColumn("tax", typeof(decimal));
	C.ReadOnly=true;
	tassetpieceview.Columns.Add(C);
	tassetpieceview.Columns.Add( new DataColumn("taxrate", typeof(double)));
	tassetpieceview.Columns.Add( new DataColumn("discount", typeof(double)));
	C= new DataColumn("cost", typeof(decimal));
	C.ReadOnly=true;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("revals", typeof(decimal));
	C.ReadOnly=true;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("revals_pending", typeof(decimal));
	C.ReadOnly=true;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("subtractions", typeof(decimal));
	C.ReadOnly=true;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("currentvalue", typeof(decimal));
	C.ReadOnly=true;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("total", typeof(decimal));
	C.ReadOnly=true;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("abatable", typeof(decimal));
	C.ReadOnly=true;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("unabatable", typeof(decimal));
	C.ReadOnly=true;
	tassetpieceview.Columns.Add(C);
	tassetpieceview.Columns.Add( new DataColumn("idassetunload", typeof(int)));
	tassetpieceview.Columns.Add( new DataColumn("idassetunloadkind", typeof(int)));
	tassetpieceview.Columns.Add( new DataColumn("yassetunload", typeof(short)));
	tassetpieceview.Columns.Add( new DataColumn("nassetunload", typeof(int)));
	tassetpieceview.Columns.Add( new DataColumn("transmitted", typeof(string)));
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("idsor01", typeof(int));
	C.ReadOnly=true;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("idsor02", typeof(int));
	C.ReadOnly=true;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("idsor03", typeof(int));
	C.ReadOnly=true;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("idsor04", typeof(int));
	C.ReadOnly=true;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("idsor05", typeof(int));
	C.ReadOnly=true;
	tassetpieceview.Columns.Add(C);
	tassetpieceview.Columns.Add( new DataColumn("idsor1", typeof(int)));
	tassetpieceview.Columns.Add( new DataColumn("idsor2", typeof(int)));
	tassetpieceview.Columns.Add( new DataColumn("idsor3", typeof(int)));
	C= new DataColumn("is_unloaded", typeof(string));
	C.ReadOnly=true;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("is_loaded", typeof(string));
	C.ReadOnly=true;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tassetpieceview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tassetpieceview.Columns.Add(C);
	tassetpieceview.Columns.Add( new DataColumn("!pieceorasset", typeof(string)));
	tassetpieceview.Columns.Add( new DataColumn("intcode", typeof(string)));
	tassetpieceview.Columns.Add( new DataColumn("list", typeof(string)));
	tassetpieceview.Columns.Add( new DataColumn("historicalvalue", typeof(decimal)));
	tassetpieceview.Columns.Add( new DataColumn("inventorykind", typeof(string)));
	Tables.Add(tassetpieceview);
	tassetpieceview.PrimaryKey =  new DataColumn[]{tassetpieceview.Columns["idasset"], tassetpieceview.Columns["idpiece"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{assetunload.Columns["idassetunload"]};
	var cChild = new []{assetpieceview.Columns["idassetunload"]};
	Relations.Add(new DataRelation("assetunload_assetpieceview",cPar,cChild,false));

	cPar = new []{assetunload.Columns["idassetunload"]};
	cChild = new []{assetamortizationunloadview.Columns["idassetunload"]};
	Relations.Add(new DataRelation("assetunload_assetamortizationunloadview",cPar,cChild,false));

	cPar = new []{incomeview.Columns["idinc"]};
	cChild = new []{assetunloadincome.Columns["idinc"]};
	Relations.Add(new DataRelation("incomeview_assetunloadincome",cPar,cChild,false));

	cPar = new []{assetunload.Columns["idassetunload"]};
	cChild = new []{assetunloadincome.Columns["idassetunload"]};
	Relations.Add(new DataRelation("assetunloadassetunloadincome",cPar,cChild,false));

	cPar = new []{assetunloadmotive.Columns["idmot"]};
	cChild = new []{assetunload.Columns["idmot"]};
	Relations.Add(new DataRelation("assetunloadmotiveassetunload",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{assetunload.Columns["idreg"]};
	Relations.Add(new DataRelation("registryassetunload",cPar,cChild,false));

	cPar = new []{assetunloadkindview.Columns["idassetunloadkind"]};
	cChild = new []{assetunload.Columns["idassetunloadkind"]};
	Relations.Add(new DataRelation("assetunloadkindviewassetunload",cPar,cChild,false));

	#endregion

}
}
}
