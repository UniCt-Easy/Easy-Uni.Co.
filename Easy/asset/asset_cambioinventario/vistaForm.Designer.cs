
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


using System;
using System.Data;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;
#pragma warning disable 1591
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace asset_cambioinventario {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable inventory_origin 		=> Tables["inventory_origin"];

	///<summary>
	///Configurazione Annuale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable config 		=> Tables["config"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry_assetload 		=> Tables["registry_assetload"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry_assetunload 		=> Tables["registry_assetunload"];

	///<summary>
	///Tipi di buoni di carico
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetloadkind 		=> Tables["assetloadkind"];

	///<summary>
	///Causali di scarico
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetunloadmotive 		=> Tables["assetunloadmotive"];

	///<summary>
	///Tipi di buoni di scarico
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetunloadkind 		=> Tables["assetunloadkind"];

	///<summary>
	///Causali di carico
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetloadmotive 		=> Tables["assetloadmotive"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable inventory_dest 		=> Tables["inventory_dest"];

	///<summary>
	///Buono di carico
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetload 		=> Tables["assetload"];

	///<summary>
	///Buono di scarico
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetunload 		=> Tables["assetunload"];

	///<summary>
	///Responsabile cespite
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetmanager 		=> Tables["assetmanager"];

	///<summary>
	///Carico dei cespiti da bolla/fattura
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetacquire 		=> Tables["assetacquire"];

	///<summary>
	///Cespiti e accessori
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable asset 		=> Tables["asset"];

	///<summary>
	///Rivalutazione/Svalutazione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetamortization 		=> Tables["assetamortization"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable asset_detail 		=> Tables["asset_detail"];

	///<summary>
	///Responsabile
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable manager 		=> Tables["manager"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetview 		=> Tables["assetview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetview_piece 		=> Tables["assetview_piece"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable manager_orig 		=> Tables["manager_orig"];

	///<summary>
	///U.P.B.
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb 		=> Tables["upb"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable managerconsegnatario_origin 		=> Tables["managerconsegnatario_origin"];

	///<summary>
	///Consegnatario cespite
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetsubmanager 		=> Tables["assetsubmanager"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable managerconsegnatario 		=> Tables["managerconsegnatario"];

	///<summary>
	///Ubicazione cespite
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetlocation 		=> Tables["assetlocation"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetview1 		=> Tables["assetview1"];

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
	//////////////////// INVENTORY_ORIGIN /////////////////////////////////
	var tinventory_origin= new DataTable("inventory_origin");
	C= new DataColumn("idinventory", typeof(int));
	C.AllowDBNull=false;
	tinventory_origin.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tinventory_origin.Columns.Add(C);
	C= new DataColumn("idinventorykind", typeof(int));
	C.AllowDBNull=false;
	tinventory_origin.Columns.Add(C);
	C= new DataColumn("idinventoryagency", typeof(int));
	C.AllowDBNull=false;
	tinventory_origin.Columns.Add(C);
	tinventory_origin.Columns.Add( new DataColumn("startnumber", typeof(int)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinventory_origin.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinventory_origin.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinventory_origin.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinventory_origin.Columns.Add(C);
	tinventory_origin.Columns.Add( new DataColumn("active", typeof(string)));
	tinventory_origin.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tinventory_origin.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tinventory_origin.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tinventory_origin.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tinventory_origin.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tinventory_origin);
	tinventory_origin.PrimaryKey =  new DataColumn[]{tinventory_origin.Columns["idinventory"]};


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
	tconfig.Columns.Add( new DataColumn("finvarofficial_default", typeof(string)));
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
	tconfig.Columns.Add( new DataColumn("idregauto", typeof(int)));
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
	tconfig.Columns.Add( new DataColumn("idivapayperiodicity", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idsortingkind1", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idsortingkind2", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idsortingkind3", typeof(int)));
	tconfig.Columns.Add( new DataColumn("fin_kind", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("taxvaliditykind", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("flag_paymentamount", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("automanagekind", typeof(int)));
	tconfig.Columns.Add( new DataColumn("flag_autodocnumbering", typeof(int)));
	tconfig.Columns.Add( new DataColumn("flagbank_grouping", typeof(int)));
	tconfig.Columns.Add( new DataColumn("cashvaliditykind", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("wageimportappname", typeof(string)));
	tconfig.Columns.Add( new DataColumn("balancekind", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("idpaymethodabi", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idpaymethodnoabi", typeof(int)));
	tconfig.Columns.Add( new DataColumn("iban_f24", typeof(string)));
	tconfig.Columns.Add( new DataColumn("cudactivitycode", typeof(string)));
	Tables.Add(tconfig);
	tconfig.PrimaryKey =  new DataColumn[]{tconfig.Columns["ayear"]};


	//////////////////// REGISTRY_ASSETLOAD /////////////////////////////////
	var tregistry_assetload= new DataTable("registry_assetload");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistry_assetload.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tregistry_assetload.Columns.Add(C);
	tregistry_assetload.Columns.Add( new DataColumn("annotation", typeof(string)));
	tregistry_assetload.Columns.Add( new DataColumn("badgecode", typeof(string)));
	tregistry_assetload.Columns.Add( new DataColumn("birthdate", typeof(DateTime)));
	tregistry_assetload.Columns.Add( new DataColumn("cf", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry_assetload.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistry_assetload.Columns.Add(C);
	tregistry_assetload.Columns.Add( new DataColumn("extmatricula", typeof(string)));
	tregistry_assetload.Columns.Add( new DataColumn("foreigncf", typeof(string)));
	tregistry_assetload.Columns.Add( new DataColumn("forename", typeof(string)));
	tregistry_assetload.Columns.Add( new DataColumn("gender", typeof(string)));
	tregistry_assetload.Columns.Add( new DataColumn("idcategory", typeof(string)));
	tregistry_assetload.Columns.Add( new DataColumn("idcentralizedcategory", typeof(string)));
	tregistry_assetload.Columns.Add( new DataColumn("idcity", typeof(int)));
	tregistry_assetload.Columns.Add( new DataColumn("idmaritalstatus", typeof(string)));
	tregistry_assetload.Columns.Add( new DataColumn("idnation", typeof(int)));
	tregistry_assetload.Columns.Add( new DataColumn("idregistryclass", typeof(string)));
	tregistry_assetload.Columns.Add( new DataColumn("idtitle", typeof(string)));
	tregistry_assetload.Columns.Add( new DataColumn("location", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry_assetload.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistry_assetload.Columns.Add(C);
	tregistry_assetload.Columns.Add( new DataColumn("maritalsurname", typeof(string)));
	tregistry_assetload.Columns.Add( new DataColumn("p_iva", typeof(string)));
	tregistry_assetload.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tregistry_assetload.Columns.Add( new DataColumn("surname", typeof(string)));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tregistry_assetload.Columns.Add(C);
	tregistry_assetload.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("residence", typeof(int));
	C.AllowDBNull=false;
	tregistry_assetload.Columns.Add(C);
	tregistry_assetload.Columns.Add( new DataColumn("idregistrykind", typeof(int)));
	tregistry_assetload.Columns.Add( new DataColumn("authorization_free", typeof(string)));
	tregistry_assetload.Columns.Add( new DataColumn("multi_cf", typeof(string)));
	tregistry_assetload.Columns.Add( new DataColumn("toredirect", typeof(int)));
	Tables.Add(tregistry_assetload);
	tregistry_assetload.PrimaryKey =  new DataColumn[]{tregistry_assetload.Columns["idreg"]};


	//////////////////// REGISTRY_ASSETUNLOAD /////////////////////////////////
	var tregistry_assetunload= new DataTable("registry_assetunload");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistry_assetunload.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tregistry_assetunload.Columns.Add(C);
	tregistry_assetunload.Columns.Add( new DataColumn("annotation", typeof(string)));
	tregistry_assetunload.Columns.Add( new DataColumn("badgecode", typeof(string)));
	tregistry_assetunload.Columns.Add( new DataColumn("birthdate", typeof(DateTime)));
	tregistry_assetunload.Columns.Add( new DataColumn("cf", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry_assetunload.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistry_assetunload.Columns.Add(C);
	tregistry_assetunload.Columns.Add( new DataColumn("extmatricula", typeof(string)));
	tregistry_assetunload.Columns.Add( new DataColumn("foreigncf", typeof(string)));
	tregistry_assetunload.Columns.Add( new DataColumn("forename", typeof(string)));
	tregistry_assetunload.Columns.Add( new DataColumn("gender", typeof(string)));
	tregistry_assetunload.Columns.Add( new DataColumn("idcategory", typeof(string)));
	tregistry_assetunload.Columns.Add( new DataColumn("idcentralizedcategory", typeof(string)));
	tregistry_assetunload.Columns.Add( new DataColumn("idcity", typeof(int)));
	tregistry_assetunload.Columns.Add( new DataColumn("idmaritalstatus", typeof(string)));
	tregistry_assetunload.Columns.Add( new DataColumn("idnation", typeof(int)));
	tregistry_assetunload.Columns.Add( new DataColumn("idregistryclass", typeof(string)));
	tregistry_assetunload.Columns.Add( new DataColumn("idtitle", typeof(string)));
	tregistry_assetunload.Columns.Add( new DataColumn("location", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry_assetunload.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistry_assetunload.Columns.Add(C);
	tregistry_assetunload.Columns.Add( new DataColumn("maritalsurname", typeof(string)));
	tregistry_assetunload.Columns.Add( new DataColumn("p_iva", typeof(string)));
	tregistry_assetunload.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tregistry_assetunload.Columns.Add( new DataColumn("surname", typeof(string)));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tregistry_assetunload.Columns.Add(C);
	tregistry_assetunload.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("residence", typeof(int));
	C.AllowDBNull=false;
	tregistry_assetunload.Columns.Add(C);
	tregistry_assetunload.Columns.Add( new DataColumn("idregistrykind", typeof(int)));
	tregistry_assetunload.Columns.Add( new DataColumn("authorization_free", typeof(string)));
	tregistry_assetunload.Columns.Add( new DataColumn("multi_cf", typeof(string)));
	tregistry_assetunload.Columns.Add( new DataColumn("toredirect", typeof(int)));
	Tables.Add(tregistry_assetunload);
	tregistry_assetunload.PrimaryKey =  new DataColumn[]{tregistry_assetunload.Columns["idreg"]};


	//////////////////// ASSETLOADKIND /////////////////////////////////
	var tassetloadkind= new DataTable("assetloadkind");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tassetloadkind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tassetloadkind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tassetloadkind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tassetloadkind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tassetloadkind.Columns.Add(C);
	tassetloadkind.Columns.Add( new DataColumn("startnumber", typeof(int)));
	C= new DataColumn("idinventory", typeof(int));
	C.AllowDBNull=false;
	tassetloadkind.Columns.Add(C);
	C= new DataColumn("codeassetloadkind", typeof(string));
	C.AllowDBNull=false;
	tassetloadkind.Columns.Add(C);
	C= new DataColumn("idassetloadkind", typeof(int));
	C.AllowDBNull=false;
	tassetloadkind.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tassetloadkind.Columns.Add(C);
	tassetloadkind.Columns.Add( new DataColumn("active", typeof(string)));
	tassetloadkind.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tassetloadkind.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tassetloadkind.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tassetloadkind.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tassetloadkind.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tassetloadkind);
	tassetloadkind.PrimaryKey =  new DataColumn[]{tassetloadkind.Columns["idassetloadkind"]};


	//////////////////// ASSETUNLOADMOTIVE /////////////////////////////////
	var tassetunloadmotive= new DataTable("assetunloadmotive");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tassetunloadmotive.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tassetunloadmotive.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tassetunloadmotive.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tassetunloadmotive.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tassetunloadmotive.Columns.Add(C);
	C= new DataColumn("codemot", typeof(string));
	C.AllowDBNull=false;
	tassetunloadmotive.Columns.Add(C);
	C= new DataColumn("idmot", typeof(int));
	C.AllowDBNull=false;
	tassetunloadmotive.Columns.Add(C);
	tassetunloadmotive.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(tassetunloadmotive);
	tassetunloadmotive.PrimaryKey =  new DataColumn[]{tassetunloadmotive.Columns["idmot"]};


	//////////////////// ASSETUNLOADKIND /////////////////////////////////
	var tassetunloadkind= new DataTable("assetunloadkind");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tassetunloadkind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tassetunloadkind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tassetunloadkind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tassetunloadkind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tassetunloadkind.Columns.Add(C);
	tassetunloadkind.Columns.Add( new DataColumn("startnumber", typeof(int)));
	tassetunloadkind.Columns.Add( new DataColumn("idinventory", typeof(int)));
	C= new DataColumn("codeassetunloadkind", typeof(string));
	C.AllowDBNull=false;
	tassetunloadkind.Columns.Add(C);
	C= new DataColumn("idassetunloadkind", typeof(int));
	C.AllowDBNull=false;
	tassetunloadkind.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tassetunloadkind.Columns.Add(C);
	tassetunloadkind.Columns.Add( new DataColumn("active", typeof(string)));
	tassetunloadkind.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tassetunloadkind.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tassetunloadkind.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tassetunloadkind.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tassetunloadkind.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tassetunloadkind);
	tassetunloadkind.PrimaryKey =  new DataColumn[]{tassetunloadkind.Columns["idassetunloadkind"]};


	//////////////////// ASSETLOADMOTIVE /////////////////////////////////
	var tassetloadmotive= new DataTable("assetloadmotive");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tassetloadmotive.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tassetloadmotive.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tassetloadmotive.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tassetloadmotive.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tassetloadmotive.Columns.Add(C);
	tassetloadmotive.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	C= new DataColumn("codemot", typeof(string));
	C.AllowDBNull=false;
	tassetloadmotive.Columns.Add(C);
	C= new DataColumn("idmot", typeof(int));
	C.AllowDBNull=false;
	tassetloadmotive.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tassetloadmotive.Columns.Add(C);
	tassetloadmotive.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(tassetloadmotive);
	tassetloadmotive.PrimaryKey =  new DataColumn[]{tassetloadmotive.Columns["idmot"]};


	//////////////////// INVENTORY_DEST /////////////////////////////////
	var tinventory_dest= new DataTable("inventory_dest");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinventory_dest.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinventory_dest.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tinventory_dest.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinventory_dest.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinventory_dest.Columns.Add(C);
	tinventory_dest.Columns.Add( new DataColumn("startnumber", typeof(int)));
	C= new DataColumn("idinventoryagency", typeof(int));
	C.AllowDBNull=false;
	tinventory_dest.Columns.Add(C);
	C= new DataColumn("idinventorykind", typeof(int));
	C.AllowDBNull=false;
	tinventory_dest.Columns.Add(C);
	C= new DataColumn("codeinventory", typeof(string));
	C.AllowDBNull=false;
	tinventory_dest.Columns.Add(C);
	C= new DataColumn("idinventory", typeof(int));
	C.AllowDBNull=false;
	tinventory_dest.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tinventory_dest.Columns.Add(C);
	tinventory_dest.Columns.Add( new DataColumn("active", typeof(string)));
	tinventory_dest.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tinventory_dest.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tinventory_dest.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tinventory_dest.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tinventory_dest.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tinventory_dest);
	tinventory_dest.PrimaryKey =  new DataColumn[]{tinventory_dest.Columns["idinventory"]};


	//////////////////// ASSETLOAD /////////////////////////////////
	var tassetload= new DataTable("assetload");
	C= new DataColumn("nassetload", typeof(int));
	C.AllowDBNull=false;
	tassetload.Columns.Add(C);
	C= new DataColumn("yassetload", typeof(short));
	C.AllowDBNull=false;
	tassetload.Columns.Add(C);
	tassetload.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tassetload.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tassetload.Columns.Add(C);
	tassetload.Columns.Add( new DataColumn("description", typeof(string)));
	tassetload.Columns.Add( new DataColumn("doc", typeof(string)));
	tassetload.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	tassetload.Columns.Add( new DataColumn("enactment", typeof(string)));
	tassetload.Columns.Add( new DataColumn("enactmentdate", typeof(DateTime)));
	tassetload.Columns.Add( new DataColumn("idreg", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tassetload.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tassetload.Columns.Add(C);
	tassetload.Columns.Add( new DataColumn("printdate", typeof(DateTime)));
	tassetload.Columns.Add( new DataColumn("ratificationdate", typeof(DateTime)));
	tassetload.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tassetload.Columns.Add( new DataColumn("txt", typeof(string)));
	tassetload.Columns.Add( new DataColumn("transmitted", typeof(string)));
	tassetload.Columns.Add( new DataColumn("idmot", typeof(int)));
	C= new DataColumn("idassetloadkind", typeof(int));
	C.AllowDBNull=false;
	tassetload.Columns.Add(C);
	C= new DataColumn("idassetload", typeof(int));
	C.AllowDBNull=false;
	tassetload.Columns.Add(C);
	Tables.Add(tassetload);
	tassetload.PrimaryKey =  new DataColumn[]{tassetload.Columns["idassetload"]};


	//////////////////// ASSETUNLOAD /////////////////////////////////
	var tassetunload= new DataTable("assetunload");
	C= new DataColumn("nassetunload", typeof(int));
	C.AllowDBNull=false;
	tassetunload.Columns.Add(C);
	C= new DataColumn("yassetunload", typeof(short));
	C.AllowDBNull=false;
	tassetunload.Columns.Add(C);
	tassetunload.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tassetunload.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tassetunload.Columns.Add(C);
	tassetunload.Columns.Add( new DataColumn("description", typeof(string)));
	tassetunload.Columns.Add( new DataColumn("doc", typeof(string)));
	tassetunload.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	tassetunload.Columns.Add( new DataColumn("enactment", typeof(string)));
	tassetunload.Columns.Add( new DataColumn("enactmentdate", typeof(DateTime)));
	tassetunload.Columns.Add( new DataColumn("idreg", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tassetunload.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tassetunload.Columns.Add(C);
	tassetunload.Columns.Add( new DataColumn("printdate", typeof(DateTime)));
	tassetunload.Columns.Add( new DataColumn("ratificationdate", typeof(DateTime)));
	tassetunload.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tassetunload.Columns.Add( new DataColumn("txt", typeof(string)));
	tassetunload.Columns.Add( new DataColumn("transmitted", typeof(string)));
	tassetunload.Columns.Add( new DataColumn("idmot", typeof(int)));
	C= new DataColumn("idassetunloadkind", typeof(int));
	C.AllowDBNull=false;
	tassetunload.Columns.Add(C);
	C= new DataColumn("idassetunload", typeof(int));
	C.AllowDBNull=false;
	tassetunload.Columns.Add(C);
	Tables.Add(tassetunload);
	tassetunload.PrimaryKey =  new DataColumn[]{tassetunload.Columns["idassetunload"]};


	//////////////////// ASSETMANAGER /////////////////////////////////
	var tassetmanager= new DataTable("assetmanager");
	C= new DataColumn("idasset", typeof(int));
	C.AllowDBNull=false;
	tassetmanager.Columns.Add(C);
	C= new DataColumn("idassetmanager", typeof(int));
	C.AllowDBNull=false;
	tassetmanager.Columns.Add(C);
	tassetmanager.Columns.Add( new DataColumn("start", typeof(DateTime)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tassetmanager.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tassetmanager.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tassetmanager.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tassetmanager.Columns.Add(C);
	C= new DataColumn("idman", typeof(int));
	C.AllowDBNull=false;
	tassetmanager.Columns.Add(C);
	Tables.Add(tassetmanager);
	tassetmanager.PrimaryKey =  new DataColumn[]{tassetmanager.Columns["idasset"], tassetmanager.Columns["idassetmanager"]};


	//////////////////// ASSETACQUIRE /////////////////////////////////
	var tassetacquire= new DataTable("assetacquire");
	C= new DataColumn("nassetacquire", typeof(int));
	C.AllowDBNull=false;
	tassetacquire.Columns.Add(C);
	tassetacquire.Columns.Add( new DataColumn("abatable", typeof(decimal)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tassetacquire.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tassetacquire.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tassetacquire.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tassetacquire.Columns.Add(C);
	tassetacquire.Columns.Add( new DataColumn("discount", typeof(double)));
	tassetacquire.Columns.Add( new DataColumn("idmankind", typeof(string)));
	tassetacquire.Columns.Add( new DataColumn("idreg", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tassetacquire.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tassetacquire.Columns.Add(C);
	tassetacquire.Columns.Add( new DataColumn("nman", typeof(int)));
	C= new DataColumn("number", typeof(int));
	C.AllowDBNull=false;
	tassetacquire.Columns.Add(C);
	tassetacquire.Columns.Add( new DataColumn("rownum", typeof(int)));
	tassetacquire.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tassetacquire.Columns.Add( new DataColumn("startnumber", typeof(int)));
	tassetacquire.Columns.Add( new DataColumn("tax", typeof(decimal)));
	tassetacquire.Columns.Add( new DataColumn("taxable", typeof(decimal)));
	tassetacquire.Columns.Add( new DataColumn("taxrate", typeof(double)));
	tassetacquire.Columns.Add( new DataColumn("txt", typeof(string)));
	tassetacquire.Columns.Add( new DataColumn("yman", typeof(short)));
	tassetacquire.Columns.Add( new DataColumn("transmitted", typeof(string)));
	tassetacquire.Columns.Add( new DataColumn("idupb", typeof(string)));
	C= new DataColumn("idinventory", typeof(int));
	C.AllowDBNull=false;
	tassetacquire.Columns.Add(C);
	C= new DataColumn("idmot", typeof(int));
	C.AllowDBNull=false;
	tassetacquire.Columns.Add(C);
	C= new DataColumn("idinv", typeof(int));
	C.AllowDBNull=false;
	tassetacquire.Columns.Add(C);
	tassetacquire.Columns.Add( new DataColumn("idassetload", typeof(int)));
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tassetacquire.Columns.Add(C);
	tassetacquire.Columns.Add( new DataColumn("idsor1", typeof(int)));
	tassetacquire.Columns.Add( new DataColumn("idsor2", typeof(int)));
	tassetacquire.Columns.Add( new DataColumn("idsor3", typeof(int)));
	tassetacquire.Columns.Add( new DataColumn("historicalvalue", typeof(decimal)));
	tassetacquire.Columns.Add( new DataColumn("idlist", typeof(int)));
	tassetacquire.Columns.Add( new DataColumn("idinvkind", typeof(int)));
	tassetacquire.Columns.Add( new DataColumn("yinv", typeof(short)));
	tassetacquire.Columns.Add( new DataColumn("ninv", typeof(int)));
	tassetacquire.Columns.Add( new DataColumn("invrownum", typeof(int)));
	Tables.Add(tassetacquire);
	tassetacquire.PrimaryKey =  new DataColumn[]{tassetacquire.Columns["nassetacquire"]};


	//////////////////// ASSET /////////////////////////////////
	var tasset= new DataTable("asset");
	C= new DataColumn("idasset", typeof(int));
	C.AllowDBNull=false;
	tasset.Columns.Add(C);
	C= new DataColumn("idpiece", typeof(int));
	C.AllowDBNull=false;
	tasset.Columns.Add(C);
	tasset.Columns.Add( new DataColumn("idasset_prev", typeof(int)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tasset.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tasset.Columns.Add(C);
	tasset.Columns.Add( new DataColumn("lifestart", typeof(DateTime)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tasset.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tasset.Columns.Add(C);
	tasset.Columns.Add( new DataColumn("nassetacquire", typeof(int)));
	tasset.Columns.Add( new DataColumn("ninventory", typeof(int)));
	tasset.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tasset.Columns.Add( new DataColumn("txt", typeof(string)));
	tasset.Columns.Add( new DataColumn("transmitted", typeof(string)));
	tasset.Columns.Add( new DataColumn("idassetunload", typeof(int)));
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tasset.Columns.Add(C);
	tasset.Columns.Add( new DataColumn("idpiece_prev", typeof(int)));
	tasset.Columns.Add( new DataColumn("multifield", typeof(string)));
	tasset.Columns.Add( new DataColumn("idcurrman", typeof(int)));
	tasset.Columns.Add( new DataColumn("idcurrsubman", typeof(int)));
	tasset.Columns.Add( new DataColumn("idcurrlocation", typeof(int)));
	tasset.Columns.Add( new DataColumn("idinventory", typeof(int)));
	Tables.Add(tasset);
	tasset.PrimaryKey =  new DataColumn[]{tasset.Columns["idasset"], tasset.Columns["idpiece"]};


	//////////////////// ASSETAMORTIZATION /////////////////////////////////
	var tassetamortization= new DataTable("assetamortization");
	C= new DataColumn("namortization", typeof(int));
	C.AllowDBNull=false;
	tassetamortization.Columns.Add(C);
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tassetamortization.Columns.Add(C);
	tassetamortization.Columns.Add( new DataColumn("amortizationquota", typeof(double)));
	tassetamortization.Columns.Add( new DataColumn("assetvalue", typeof(decimal)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tassetamortization.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tassetamortization.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tassetamortization.Columns.Add(C);
	C= new DataColumn("idasset", typeof(int));
	C.AllowDBNull=false;
	tassetamortization.Columns.Add(C);
	tassetamortization.Columns.Add( new DataColumn("idpiece", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tassetamortization.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tassetamortization.Columns.Add(C);
	tassetamortization.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tassetamortization.Columns.Add( new DataColumn("txt", typeof(string)));
	tassetamortization.Columns.Add( new DataColumn("transmitted", typeof(string)));
	C= new DataColumn("idinventoryamortization", typeof(int));
	C.AllowDBNull=false;
	tassetamortization.Columns.Add(C);
	tassetamortization.Columns.Add( new DataColumn("idassetunload", typeof(int)));
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tassetamortization.Columns.Add(C);
	Tables.Add(tassetamortization);
	tassetamortization.PrimaryKey =  new DataColumn[]{tassetamortization.Columns["namortization"]};


	//////////////////// ASSET_DETAIL /////////////////////////////////
	var tasset_detail= new DataTable("asset_detail");
	C= new DataColumn("idasset", typeof(int));
	C.AllowDBNull=false;
	tasset_detail.Columns.Add(C);
	C= new DataColumn("idpiece", typeof(int));
	C.AllowDBNull=false;
	tasset_detail.Columns.Add(C);
	tasset_detail.Columns.Add( new DataColumn("idasset_prev", typeof(int)));
	tasset_detail.Columns.Add( new DataColumn("idpiece_prev", typeof(int)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tasset_detail.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tasset_detail.Columns.Add(C);
	tasset_detail.Columns.Add( new DataColumn("lifestart", typeof(DateTime)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tasset_detail.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tasset_detail.Columns.Add(C);
	tasset_detail.Columns.Add( new DataColumn("nassetacquire", typeof(int)));
	tasset_detail.Columns.Add( new DataColumn("ninventory", typeof(int)));
	tasset_detail.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tasset_detail.Columns.Add( new DataColumn("txt", typeof(string)));
	tasset_detail.Columns.Add( new DataColumn("transmitted", typeof(string)));
	tasset_detail.Columns.Add( new DataColumn("idassetunload", typeof(int)));
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tasset_detail.Columns.Add(C);
	tasset_detail.Columns.Add( new DataColumn("multifield", typeof(string)));
	tasset_detail.Columns.Add( new DataColumn("idcurrman", typeof(int)));
	tasset_detail.Columns.Add( new DataColumn("idcurrsubman", typeof(int)));
	tasset_detail.Columns.Add( new DataColumn("idcurrlocation", typeof(int)));
	tasset_detail.Columns.Add( new DataColumn("idinventory", typeof(int)));
	Tables.Add(tasset_detail);
	tasset_detail.PrimaryKey =  new DataColumn[]{tasset_detail.Columns["idasset"], tasset_detail.Columns["idpiece"]};


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
	Tables.Add(tmanager);
	tmanager.PrimaryKey =  new DataColumn[]{tmanager.Columns["idman"]};


	//////////////////// ASSETVIEW /////////////////////////////////
	var tassetview= new DataTable("assetview");
	C= new DataColumn("idasset", typeof(int));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	C= new DataColumn("idpiece", typeof(int));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	tassetview.Columns.Add( new DataColumn("idasset_prev", typeof(int)));
	tassetview.Columns.Add( new DataColumn("idpiece_prev", typeof(int)));
	tassetview.Columns.Add( new DataColumn("idinventory_prev", typeof(int)));
	tassetview.Columns.Add( new DataColumn("codeinventory_prev", typeof(string)));
	tassetview.Columns.Add( new DataColumn("inventory_prev", typeof(string)));
	tassetview.Columns.Add( new DataColumn("ninventory_prev", typeof(int)));
	tassetview.Columns.Add( new DataColumn("idasset_next", typeof(int)));
	tassetview.Columns.Add( new DataColumn("idpiece_next", typeof(int)));
	tassetview.Columns.Add( new DataColumn("idinventory_next", typeof(int)));
	tassetview.Columns.Add( new DataColumn("codeinventory_next", typeof(string)));
	tassetview.Columns.Add( new DataColumn("inventory_next", typeof(string)));
	tassetview.Columns.Add( new DataColumn("ninventory_next", typeof(int)));
	tassetview.Columns.Add( new DataColumn("lifestart", typeof(DateTime)));
	C= new DataColumn("yearstart", typeof(int));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	tassetview.Columns.Add( new DataColumn("nassetacquire", typeof(int)));
	tassetview.Columns.Add( new DataColumn("ninventory", typeof(int)));
	tassetview.Columns.Add( new DataColumn("idcurrlocation", typeof(int)));
	tassetview.Columns.Add( new DataColumn("currlocationcode", typeof(string)));
	tassetview.Columns.Add( new DataColumn("currlocation", typeof(string)));
	tassetview.Columns.Add( new DataColumn("idcurrman", typeof(int)));
	tassetview.Columns.Add( new DataColumn("currmanager", typeof(string)));
	tassetview.Columns.Add( new DataColumn("idcurrsubman", typeof(int)));
	tassetview.Columns.Add( new DataColumn("currsubmanager", typeof(string)));
	C= new DataColumn("idinv", typeof(int));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	C= new DataColumn("codeinv", typeof(string));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	C= new DataColumn("idinv_lev1", typeof(int));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	C= new DataColumn("codeinv_lev1", typeof(string));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	C= new DataColumn("inventorytree", typeof(string));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	C= new DataColumn("inventorytree_lev1", typeof(string));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	tassetview.Columns.Add( new DataColumn("idinventory", typeof(int)));
	C= new DataColumn("codeinventory", typeof(string));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	C= new DataColumn("inventory", typeof(string));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	tassetview.Columns.Add( new DataColumn("idassetload", typeof(int)));
	tassetview.Columns.Add( new DataColumn("idassetloadkind", typeof(int)));
	tassetview.Columns.Add( new DataColumn("yassetload", typeof(short)));
	tassetview.Columns.Add( new DataColumn("nassetload", typeof(int)));
	C= new DataColumn("idloadmot", typeof(int));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	tassetview.Columns.Add( new DataColumn("loadmotive", typeof(string)));
	tassetview.Columns.Add( new DataColumn("loaddescription", typeof(string)));
	tassetview.Columns.Add( new DataColumn("taxable", typeof(decimal)));
	tassetview.Columns.Add( new DataColumn("taxrate", typeof(double)));
	C= new DataColumn("tax", typeof(decimal));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	C= new DataColumn("abatable", typeof(decimal));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	C= new DataColumn("unabatable", typeof(decimal));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	C= new DataColumn("number", typeof(int));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	tassetview.Columns.Add( new DataColumn("discount", typeof(double)));
	C= new DataColumn("cost", typeof(decimal));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	C= new DataColumn("revals", typeof(decimal));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	C= new DataColumn("revals_pending", typeof(decimal));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	C= new DataColumn("subtractions", typeof(decimal));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	C= new DataColumn("currentvalue", typeof(decimal));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	C= new DataColumn("total", typeof(decimal));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	tassetview.Columns.Add( new DataColumn("idassetunload", typeof(int)));
	tassetview.Columns.Add( new DataColumn("idassetunloadkind", typeof(int)));
	tassetview.Columns.Add( new DataColumn("yassetunload", typeof(short)));
	tassetview.Columns.Add( new DataColumn("nassetunload", typeof(int)));
	tassetview.Columns.Add( new DataColumn("unloaddate", typeof(DateTime)));
	tassetview.Columns.Add( new DataColumn("idunloadmot", typeof(int)));
	tassetview.Columns.Add( new DataColumn("unloadmotive", typeof(string)));
	tassetview.Columns.Add( new DataColumn("unloaddescription", typeof(string)));
	tassetview.Columns.Add( new DataColumn("unloaddoc", typeof(string)));
	tassetview.Columns.Add( new DataColumn("unloaddocdate", typeof(DateTime)));
	tassetview.Columns.Add( new DataColumn("unloadenactment", typeof(string)));
	tassetview.Columns.Add( new DataColumn("unloadenactmentdate", typeof(DateTime)));
	tassetview.Columns.Add( new DataColumn("unloadregistry", typeof(string)));
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	C= new DataColumn("flagunload", typeof(string));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	C= new DataColumn("flagtransf", typeof(string));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	tassetview.Columns.Add( new DataColumn("transmitted", typeof(string)));
	C= new DataColumn("flagload", typeof(string));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	C= new DataColumn("loadkind", typeof(string));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	tassetview.Columns.Add( new DataColumn("multifield", typeof(string)));
	C= new DataColumn("idsor01", typeof(int));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	C= new DataColumn("idsor02", typeof(int));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	C= new DataColumn("idsor03", typeof(int));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	C= new DataColumn("idsor04", typeof(int));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	C= new DataColumn("idsor05", typeof(int));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	C= new DataColumn("is_unloaded", typeof(string));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	C= new DataColumn("is_loaded", typeof(string));
	C.ReadOnly=true;
	tassetview.Columns.Add(C);
	tassetview.Columns.Add( new DataColumn("idupb", typeof(string)));
	tassetview.Columns.Add( new DataColumn("codeupb", typeof(string)));
	tassetview.Columns.Add( new DataColumn("upb", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	tassetview.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tassetview.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idinventoryagency", typeof(int));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	C= new DataColumn("inventoryagency", typeof(string));
	C.AllowDBNull=false;
	tassetview.Columns.Add(C);
	tassetview.Columns.Add( new DataColumn("idlist", typeof(int)));
	tassetview.Columns.Add( new DataColumn("intcode", typeof(string)));
	tassetview.Columns.Add( new DataColumn("list", typeof(string)));
	tassetview.Columns.Add( new DataColumn("idinventoryamortization", typeof(int)));
	tassetview.Columns.Add( new DataColumn("amortizationquota", typeof(double)));
	tassetview.Columns.Add( new DataColumn("idinvkind", typeof(int)));
	tassetview.Columns.Add( new DataColumn("yinv", typeof(short)));
	tassetview.Columns.Add( new DataColumn("ninv", typeof(int)));
	tassetview.Columns.Add( new DataColumn("invrownum", typeof(int)));
	Tables.Add(tassetview);
	tassetview.PrimaryKey =  new DataColumn[]{tassetview.Columns["idpiece"], tassetview.Columns["idasset"]};


	//////////////////// ASSETVIEW_PIECE /////////////////////////////////
	var tassetview_piece= new DataTable("assetview_piece");
	C= new DataColumn("idasset", typeof(int));
	C.AllowDBNull=false;
	tassetview_piece.Columns.Add(C);
	C= new DataColumn("idpiece", typeof(int));
	C.AllowDBNull=false;
	tassetview_piece.Columns.Add(C);
	tassetview_piece.Columns.Add( new DataColumn("idasset_prev", typeof(int)));
	tassetview_piece.Columns.Add( new DataColumn("idpiece_prev", typeof(int)));
	tassetview_piece.Columns.Add( new DataColumn("idinventory_prev", typeof(int)));
	tassetview_piece.Columns.Add( new DataColumn("codeinventory_prev", typeof(string)));
	tassetview_piece.Columns.Add( new DataColumn("inventory_prev", typeof(string)));
	tassetview_piece.Columns.Add( new DataColumn("ninventory_prev", typeof(int)));
	tassetview_piece.Columns.Add( new DataColumn("idasset_next", typeof(int)));
	tassetview_piece.Columns.Add( new DataColumn("idpiece_next", typeof(int)));
	tassetview_piece.Columns.Add( new DataColumn("idinventory_next", typeof(int)));
	tassetview_piece.Columns.Add( new DataColumn("codeinventory_next", typeof(string)));
	tassetview_piece.Columns.Add( new DataColumn("inventory_next", typeof(string)));
	tassetview_piece.Columns.Add( new DataColumn("ninventory_next", typeof(int)));
	tassetview_piece.Columns.Add( new DataColumn("lifestart", typeof(DateTime)));
	C= new DataColumn("yearstart", typeof(int));
	C.ReadOnly=true;
	tassetview_piece.Columns.Add(C);
	tassetview_piece.Columns.Add( new DataColumn("nassetacquire", typeof(int)));
	tassetview_piece.Columns.Add( new DataColumn("ninventory", typeof(int)));
	tassetview_piece.Columns.Add( new DataColumn("idcurrlocation", typeof(int)));
	tassetview_piece.Columns.Add( new DataColumn("currlocationcode", typeof(string)));
	tassetview_piece.Columns.Add( new DataColumn("currlocation", typeof(string)));
	tassetview_piece.Columns.Add( new DataColumn("idcurrman", typeof(int)));
	tassetview_piece.Columns.Add( new DataColumn("currmanager", typeof(string)));
	tassetview_piece.Columns.Add( new DataColumn("idcurrsubman", typeof(int)));
	tassetview_piece.Columns.Add( new DataColumn("currsubmanager", typeof(string)));
	C= new DataColumn("idinv", typeof(int));
	C.AllowDBNull=false;
	tassetview_piece.Columns.Add(C);
	C= new DataColumn("codeinv", typeof(string));
	C.AllowDBNull=false;
	tassetview_piece.Columns.Add(C);
	C= new DataColumn("idinv_lev1", typeof(int));
	C.AllowDBNull=false;
	tassetview_piece.Columns.Add(C);
	C= new DataColumn("codeinv_lev1", typeof(string));
	C.AllowDBNull=false;
	tassetview_piece.Columns.Add(C);
	C= new DataColumn("inventorytree", typeof(string));
	C.AllowDBNull=false;
	tassetview_piece.Columns.Add(C);
	C= new DataColumn("inventorytree_lev1", typeof(string));
	C.AllowDBNull=false;
	tassetview_piece.Columns.Add(C);
	tassetview_piece.Columns.Add( new DataColumn("idinventory", typeof(int)));
	C= new DataColumn("codeinventory", typeof(string));
	C.AllowDBNull=false;
	tassetview_piece.Columns.Add(C);
	C= new DataColumn("inventory", typeof(string));
	C.AllowDBNull=false;
	tassetview_piece.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tassetview_piece.Columns.Add(C);
	tassetview_piece.Columns.Add( new DataColumn("idassetload", typeof(int)));
	tassetview_piece.Columns.Add( new DataColumn("idassetloadkind", typeof(int)));
	tassetview_piece.Columns.Add( new DataColumn("yassetload", typeof(short)));
	tassetview_piece.Columns.Add( new DataColumn("nassetload", typeof(int)));
	C= new DataColumn("idloadmot", typeof(int));
	C.AllowDBNull=false;
	tassetview_piece.Columns.Add(C);
	tassetview_piece.Columns.Add( new DataColumn("loadmotive", typeof(string)));
	tassetview_piece.Columns.Add( new DataColumn("loaddescription", typeof(string)));
	tassetview_piece.Columns.Add( new DataColumn("taxable", typeof(decimal)));
	tassetview_piece.Columns.Add( new DataColumn("taxrate", typeof(double)));
	C= new DataColumn("tax", typeof(decimal));
	C.ReadOnly=true;
	tassetview_piece.Columns.Add(C);
	C= new DataColumn("abatable", typeof(decimal));
	C.ReadOnly=true;
	tassetview_piece.Columns.Add(C);
	C= new DataColumn("unabatable", typeof(decimal));
	C.ReadOnly=true;
	tassetview_piece.Columns.Add(C);
	C= new DataColumn("number", typeof(int));
	C.AllowDBNull=false;
	tassetview_piece.Columns.Add(C);
	tassetview_piece.Columns.Add( new DataColumn("discount", typeof(double)));
	C= new DataColumn("cost", typeof(decimal));
	C.ReadOnly=true;
	tassetview_piece.Columns.Add(C);
	C= new DataColumn("revals", typeof(decimal));
	C.ReadOnly=true;
	tassetview_piece.Columns.Add(C);
	C= new DataColumn("revals_pending", typeof(decimal));
	C.ReadOnly=true;
	tassetview_piece.Columns.Add(C);
	C= new DataColumn("subtractions", typeof(decimal));
	C.ReadOnly=true;
	tassetview_piece.Columns.Add(C);
	C= new DataColumn("currentvalue", typeof(decimal));
	C.ReadOnly=true;
	tassetview_piece.Columns.Add(C);
	C= new DataColumn("total", typeof(decimal));
	C.ReadOnly=true;
	tassetview_piece.Columns.Add(C);
	tassetview_piece.Columns.Add( new DataColumn("idassetunload", typeof(int)));
	tassetview_piece.Columns.Add( new DataColumn("idassetunloadkind", typeof(int)));
	tassetview_piece.Columns.Add( new DataColumn("yassetunload", typeof(short)));
	tassetview_piece.Columns.Add( new DataColumn("nassetunload", typeof(int)));
	tassetview_piece.Columns.Add( new DataColumn("unloaddate", typeof(DateTime)));
	tassetview_piece.Columns.Add( new DataColumn("idunloadmot", typeof(int)));
	tassetview_piece.Columns.Add( new DataColumn("unloadmotive", typeof(string)));
	tassetview_piece.Columns.Add( new DataColumn("unloaddescription", typeof(string)));
	tassetview_piece.Columns.Add( new DataColumn("unloaddoc", typeof(string)));
	tassetview_piece.Columns.Add( new DataColumn("unloaddocdate", typeof(DateTime)));
	tassetview_piece.Columns.Add( new DataColumn("unloadenactment", typeof(string)));
	tassetview_piece.Columns.Add( new DataColumn("unloadenactmentdate", typeof(DateTime)));
	tassetview_piece.Columns.Add( new DataColumn("unloadregistry", typeof(string)));
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tassetview_piece.Columns.Add(C);
	C= new DataColumn("flagunload", typeof(string));
	C.ReadOnly=true;
	tassetview_piece.Columns.Add(C);
	C= new DataColumn("flagtransf", typeof(string));
	C.ReadOnly=true;
	tassetview_piece.Columns.Add(C);
	tassetview_piece.Columns.Add( new DataColumn("transmitted", typeof(string)));
	C= new DataColumn("flagload", typeof(string));
	C.ReadOnly=true;
	tassetview_piece.Columns.Add(C);
	C= new DataColumn("loadkind", typeof(string));
	C.ReadOnly=true;
	tassetview_piece.Columns.Add(C);
	tassetview_piece.Columns.Add( new DataColumn("multifield", typeof(string)));
	C= new DataColumn("idsor01", typeof(int));
	C.ReadOnly=true;
	tassetview_piece.Columns.Add(C);
	C= new DataColumn("idsor02", typeof(int));
	C.ReadOnly=true;
	tassetview_piece.Columns.Add(C);
	C= new DataColumn("idsor03", typeof(int));
	C.ReadOnly=true;
	tassetview_piece.Columns.Add(C);
	C= new DataColumn("idsor04", typeof(int));
	C.ReadOnly=true;
	tassetview_piece.Columns.Add(C);
	C= new DataColumn("idsor05", typeof(int));
	C.ReadOnly=true;
	tassetview_piece.Columns.Add(C);
	C= new DataColumn("is_unloaded", typeof(string));
	C.ReadOnly=true;
	tassetview_piece.Columns.Add(C);
	C= new DataColumn("is_loaded", typeof(string));
	C.ReadOnly=true;
	tassetview_piece.Columns.Add(C);
	tassetview_piece.Columns.Add( new DataColumn("idupb", typeof(string)));
	tassetview_piece.Columns.Add( new DataColumn("codeupb", typeof(string)));
	tassetview_piece.Columns.Add( new DataColumn("upb", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tassetview_piece.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tassetview_piece.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tassetview_piece.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tassetview_piece.Columns.Add(C);
	tassetview_piece.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tassetview_piece.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idinventoryagency", typeof(int));
	C.AllowDBNull=false;
	tassetview_piece.Columns.Add(C);
	C= new DataColumn("inventoryagency", typeof(string));
	C.AllowDBNull=false;
	tassetview_piece.Columns.Add(C);
	tassetview_piece.Columns.Add( new DataColumn("idlist", typeof(int)));
	tassetview_piece.Columns.Add( new DataColumn("intcode", typeof(string)));
	tassetview_piece.Columns.Add( new DataColumn("list", typeof(string)));
	tassetview_piece.Columns.Add( new DataColumn("idinventoryamortization", typeof(int)));
	tassetview_piece.Columns.Add( new DataColumn("idinvkind", typeof(int)));
	tassetview_piece.Columns.Add( new DataColumn("yinv", typeof(short)));
	tassetview_piece.Columns.Add( new DataColumn("ninv", typeof(int)));
	tassetview_piece.Columns.Add( new DataColumn("invrownum", typeof(int)));
	tassetview_piece.Columns.Add( new DataColumn("amortizationquota", typeof(double)));
	Tables.Add(tassetview_piece);
	tassetview_piece.PrimaryKey =  new DataColumn[]{tassetview_piece.Columns["idpiece"], tassetview_piece.Columns["idasset"]};


	//////////////////// MANAGER_ORIG /////////////////////////////////
	var tmanager_orig= new DataTable("manager_orig");
	tmanager_orig.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tmanager_orig.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tmanager_orig.Columns.Add(C);
	tmanager_orig.Columns.Add( new DataColumn("email", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tmanager_orig.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tmanager_orig.Columns.Add(C);
	tmanager_orig.Columns.Add( new DataColumn("passwordweb", typeof(string)));
	tmanager_orig.Columns.Add( new DataColumn("phonenumber", typeof(string)));
	tmanager_orig.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tmanager_orig.Columns.Add(C);
	tmanager_orig.Columns.Add( new DataColumn("txt", typeof(string)));
	tmanager_orig.Columns.Add( new DataColumn("userweb", typeof(string)));
	C= new DataColumn("idman", typeof(int));
	C.AllowDBNull=false;
	tmanager_orig.Columns.Add(C);
	C= new DataColumn("iddivision", typeof(int));
	C.AllowDBNull=false;
	tmanager_orig.Columns.Add(C);
	tmanager_orig.Columns.Add( new DataColumn("wantswarn", typeof(string)));
	tmanager_orig.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tmanager_orig.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tmanager_orig.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tmanager_orig.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tmanager_orig.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tmanager_orig.Columns.Add( new DataColumn("newidman", typeof(int)));
	tmanager_orig.Columns.Add( new DataColumn("financeactive", typeof(string)));
	Tables.Add(tmanager_orig);
	tmanager_orig.PrimaryKey =  new DataColumn[]{tmanager_orig.Columns["idman"]};


	//////////////////// UPB /////////////////////////////////
	var tupb= new DataTable("upb");
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("active", typeof(string)));
	tupb.Columns.Add( new DataColumn("assured", typeof(string)));
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	tupb.Columns.Add( new DataColumn("granted", typeof(decimal)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("paridupb", typeof(string)));
	tupb.Columns.Add( new DataColumn("previousappropriation", typeof(decimal)));
	tupb.Columns.Add( new DataColumn("previousassessment", typeof(decimal)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("requested", typeof(decimal)));
	tupb.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("txt", typeof(string)));
	tupb.Columns.Add( new DataColumn("idman", typeof(int)));
	tupb.Columns.Add( new DataColumn("idunderwriter", typeof(int)));
	tupb.Columns.Add( new DataColumn("cupcode", typeof(string)));
	tupb.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tupb.Columns.Add( new DataColumn("flagactivity", typeof(short)));
	tupb.Columns.Add( new DataColumn("flagkind", typeof(byte)));
	tupb.Columns.Add( new DataColumn("newcodeupb", typeof(string)));
	tupb.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	tupb.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tupb.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tupb.Columns.Add( new DataColumn("cigcode", typeof(string)));
	tupb.Columns.Add( new DataColumn("idepupbkind", typeof(int)));
	Tables.Add(tupb);
	tupb.PrimaryKey =  new DataColumn[]{tupb.Columns["idupb"]};


	//////////////////// MANAGERCONSEGNATARIO_ORIGIN /////////////////////////////////
	var tmanagerconsegnatario_origin= new DataTable("managerconsegnatario_origin");
	tmanagerconsegnatario_origin.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tmanagerconsegnatario_origin.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tmanagerconsegnatario_origin.Columns.Add(C);
	tmanagerconsegnatario_origin.Columns.Add( new DataColumn("email", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tmanagerconsegnatario_origin.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tmanagerconsegnatario_origin.Columns.Add(C);
	tmanagerconsegnatario_origin.Columns.Add( new DataColumn("passwordweb", typeof(string)));
	tmanagerconsegnatario_origin.Columns.Add( new DataColumn("phonenumber", typeof(string)));
	tmanagerconsegnatario_origin.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tmanagerconsegnatario_origin.Columns.Add(C);
	tmanagerconsegnatario_origin.Columns.Add( new DataColumn("txt", typeof(string)));
	tmanagerconsegnatario_origin.Columns.Add( new DataColumn("userweb", typeof(string)));
	C= new DataColumn("idman", typeof(int));
	C.AllowDBNull=false;
	tmanagerconsegnatario_origin.Columns.Add(C);
	C= new DataColumn("iddivision", typeof(int));
	C.AllowDBNull=false;
	tmanagerconsegnatario_origin.Columns.Add(C);
	tmanagerconsegnatario_origin.Columns.Add( new DataColumn("wantswarn", typeof(string)));
	tmanagerconsegnatario_origin.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tmanagerconsegnatario_origin.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tmanagerconsegnatario_origin.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tmanagerconsegnatario_origin.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tmanagerconsegnatario_origin.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tmanagerconsegnatario_origin.Columns.Add( new DataColumn("newidman", typeof(int)));
	tmanagerconsegnatario_origin.Columns.Add( new DataColumn("financeactive", typeof(string)));
	Tables.Add(tmanagerconsegnatario_origin);
	tmanagerconsegnatario_origin.PrimaryKey =  new DataColumn[]{tmanagerconsegnatario_origin.Columns["idman"]};


	//////////////////// ASSETSUBMANAGER /////////////////////////////////
	var tassetsubmanager= new DataTable("assetsubmanager");
	C= new DataColumn("idasset", typeof(int));
	C.AllowDBNull=false;
	tassetsubmanager.Columns.Add(C);
	C= new DataColumn("idassetsubmanager", typeof(int));
	C.AllowDBNull=false;
	tassetsubmanager.Columns.Add(C);
	tassetsubmanager.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tassetsubmanager.Columns.Add( new DataColumn("cu", typeof(string)));
	tassetsubmanager.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tassetsubmanager.Columns.Add( new DataColumn("lu", typeof(string)));
	tassetsubmanager.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tassetsubmanager.Columns.Add( new DataColumn("idmanager", typeof(int)));
	Tables.Add(tassetsubmanager);
	tassetsubmanager.PrimaryKey =  new DataColumn[]{tassetsubmanager.Columns["idasset"], tassetsubmanager.Columns["idassetsubmanager"]};


	//////////////////// MANAGERCONSEGNATARIO /////////////////////////////////
	var tmanagerconsegnatario= new DataTable("managerconsegnatario");
	tmanagerconsegnatario.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tmanagerconsegnatario.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tmanagerconsegnatario.Columns.Add(C);
	tmanagerconsegnatario.Columns.Add( new DataColumn("email", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tmanagerconsegnatario.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tmanagerconsegnatario.Columns.Add(C);
	tmanagerconsegnatario.Columns.Add( new DataColumn("passwordweb", typeof(string)));
	tmanagerconsegnatario.Columns.Add( new DataColumn("phonenumber", typeof(string)));
	tmanagerconsegnatario.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tmanagerconsegnatario.Columns.Add(C);
	tmanagerconsegnatario.Columns.Add( new DataColumn("txt", typeof(string)));
	tmanagerconsegnatario.Columns.Add( new DataColumn("userweb", typeof(string)));
	C= new DataColumn("idman", typeof(int));
	C.AllowDBNull=false;
	tmanagerconsegnatario.Columns.Add(C);
	C= new DataColumn("iddivision", typeof(int));
	C.AllowDBNull=false;
	tmanagerconsegnatario.Columns.Add(C);
	tmanagerconsegnatario.Columns.Add( new DataColumn("wantswarn", typeof(string)));
	tmanagerconsegnatario.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tmanagerconsegnatario.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tmanagerconsegnatario.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tmanagerconsegnatario.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tmanagerconsegnatario.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tmanagerconsegnatario.Columns.Add( new DataColumn("newidman", typeof(int)));
	tmanagerconsegnatario.Columns.Add( new DataColumn("financeactive", typeof(string)));
	Tables.Add(tmanagerconsegnatario);
	tmanagerconsegnatario.PrimaryKey =  new DataColumn[]{tmanagerconsegnatario.Columns["idman"]};


	//////////////////// ASSETLOCATION /////////////////////////////////
	var tassetlocation= new DataTable("assetlocation");
	C= new DataColumn("idasset", typeof(int));
	C.AllowDBNull=false;
	tassetlocation.Columns.Add(C);
	C= new DataColumn("idassetlocation", typeof(int));
	C.AllowDBNull=false;
	tassetlocation.Columns.Add(C);
	tassetlocation.Columns.Add( new DataColumn("start", typeof(DateTime)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tassetlocation.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tassetlocation.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tassetlocation.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tassetlocation.Columns.Add(C);
	C= new DataColumn("idlocation", typeof(int));
	C.AllowDBNull=false;
	tassetlocation.Columns.Add(C);
	Tables.Add(tassetlocation);
	tassetlocation.PrimaryKey =  new DataColumn[]{tassetlocation.Columns["idasset"], tassetlocation.Columns["idassetlocation"]};


	//////////////////// ASSETVIEW1 /////////////////////////////////
	var tassetview1= new DataTable("assetview1");
	C= new DataColumn("idasset", typeof(int));
	C.AllowDBNull=false;
	tassetview1.Columns.Add(C);
	C= new DataColumn("idpiece", typeof(int));
	C.AllowDBNull=false;
	tassetview1.Columns.Add(C);
	tassetview1.Columns.Add( new DataColumn("idasset_prev", typeof(int)));
	tassetview1.Columns.Add( new DataColumn("idpiece_prev", typeof(int)));
	tassetview1.Columns.Add( new DataColumn("idinventory_prev", typeof(int)));
	tassetview1.Columns.Add( new DataColumn("codeinventory_prev", typeof(string)));
	tassetview1.Columns.Add( new DataColumn("inventory_prev", typeof(string)));
	tassetview1.Columns.Add( new DataColumn("ninventory_prev", typeof(int)));
	tassetview1.Columns.Add( new DataColumn("idasset_next", typeof(int)));
	tassetview1.Columns.Add( new DataColumn("idpiece_next", typeof(int)));
	tassetview1.Columns.Add( new DataColumn("idinventory_next", typeof(int)));
	tassetview1.Columns.Add( new DataColumn("codeinventory_next", typeof(string)));
	tassetview1.Columns.Add( new DataColumn("inventory_next", typeof(string)));
	tassetview1.Columns.Add( new DataColumn("ninventory_next", typeof(int)));
	tassetview1.Columns.Add( new DataColumn("lifestart", typeof(DateTime)));
	C= new DataColumn("yearstart", typeof(int));
	C.ReadOnly=true;
	tassetview1.Columns.Add(C);
	tassetview1.Columns.Add( new DataColumn("nassetacquire", typeof(int)));
	tassetview1.Columns.Add( new DataColumn("ninventory", typeof(int)));
	tassetview1.Columns.Add( new DataColumn("idcurrlocation", typeof(int)));
	tassetview1.Columns.Add( new DataColumn("currlocationcode", typeof(string)));
	tassetview1.Columns.Add( new DataColumn("currlocation", typeof(string)));
	tassetview1.Columns.Add( new DataColumn("idcurrman", typeof(int)));
	tassetview1.Columns.Add( new DataColumn("currmanager", typeof(string)));
	tassetview1.Columns.Add( new DataColumn("idcurrsubman", typeof(int)));
	tassetview1.Columns.Add( new DataColumn("currsubmanager", typeof(string)));
	tassetview1.Columns.Add( new DataColumn("idsubman", typeof(int)));
	tassetview1.Columns.Add( new DataColumn("submanager", typeof(string)));
	C= new DataColumn("idinv", typeof(int));
	C.AllowDBNull=false;
	tassetview1.Columns.Add(C);
	C= new DataColumn("codeinv", typeof(string));
	C.AllowDBNull=false;
	tassetview1.Columns.Add(C);
	C= new DataColumn("idinv_lev1", typeof(int));
	C.AllowDBNull=false;
	tassetview1.Columns.Add(C);
	C= new DataColumn("codeinv_lev1", typeof(string));
	C.AllowDBNull=false;
	tassetview1.Columns.Add(C);
	C= new DataColumn("inventorytree", typeof(string));
	C.AllowDBNull=false;
	tassetview1.Columns.Add(C);
	C= new DataColumn("inventorytree_lev1", typeof(string));
	C.AllowDBNull=false;
	tassetview1.Columns.Add(C);
	C= new DataColumn("idinventory", typeof(int));
	C.AllowDBNull=false;
	tassetview1.Columns.Add(C);
	C= new DataColumn("codeinventory", typeof(string));
	C.AllowDBNull=false;
	tassetview1.Columns.Add(C);
	C= new DataColumn("inventory", typeof(string));
	C.AllowDBNull=false;
	tassetview1.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tassetview1.Columns.Add(C);
	tassetview1.Columns.Add( new DataColumn("idassetload", typeof(int)));
	tassetview1.Columns.Add( new DataColumn("idassetloadkind", typeof(int)));
	tassetview1.Columns.Add( new DataColumn("yassetload", typeof(short)));
	tassetview1.Columns.Add( new DataColumn("nassetload", typeof(int)));
	C= new DataColumn("idloadmot", typeof(int));
	C.AllowDBNull=false;
	tassetview1.Columns.Add(C);
	tassetview1.Columns.Add( new DataColumn("loadmotive", typeof(string)));
	tassetview1.Columns.Add( new DataColumn("loaddescription", typeof(string)));
	tassetview1.Columns.Add( new DataColumn("taxable", typeof(decimal)));
	tassetview1.Columns.Add( new DataColumn("taxrate", typeof(double)));
	C= new DataColumn("tax", typeof(decimal));
	C.ReadOnly=true;
	tassetview1.Columns.Add(C);
	C= new DataColumn("abatable", typeof(decimal));
	C.ReadOnly=true;
	tassetview1.Columns.Add(C);
	C= new DataColumn("unabatable", typeof(decimal));
	C.ReadOnly=true;
	tassetview1.Columns.Add(C);
	C= new DataColumn("number", typeof(int));
	C.AllowDBNull=false;
	tassetview1.Columns.Add(C);
	tassetview1.Columns.Add( new DataColumn("discount", typeof(double)));
	C= new DataColumn("cost", typeof(decimal));
	C.ReadOnly=true;
	tassetview1.Columns.Add(C);
	C= new DataColumn("revals", typeof(decimal));
	C.ReadOnly=true;
	tassetview1.Columns.Add(C);
	C= new DataColumn("revals_pending", typeof(decimal));
	C.ReadOnly=true;
	tassetview1.Columns.Add(C);
	C= new DataColumn("subtractions", typeof(decimal));
	C.ReadOnly=true;
	tassetview1.Columns.Add(C);
	C= new DataColumn("currentvalue", typeof(decimal));
	C.ReadOnly=true;
	tassetview1.Columns.Add(C);
	C= new DataColumn("total", typeof(decimal));
	C.ReadOnly=true;
	tassetview1.Columns.Add(C);
	tassetview1.Columns.Add( new DataColumn("idassetunload", typeof(int)));
	tassetview1.Columns.Add( new DataColumn("idassetunloadkind", typeof(int)));
	tassetview1.Columns.Add( new DataColumn("yassetunload", typeof(short)));
	tassetview1.Columns.Add( new DataColumn("nassetunload", typeof(int)));
	tassetview1.Columns.Add( new DataColumn("unloaddate", typeof(DateTime)));
	tassetview1.Columns.Add( new DataColumn("idunloadmot", typeof(int)));
	tassetview1.Columns.Add( new DataColumn("unloadmotive", typeof(string)));
	tassetview1.Columns.Add( new DataColumn("unloaddescription", typeof(string)));
	tassetview1.Columns.Add( new DataColumn("unloaddoc", typeof(string)));
	tassetview1.Columns.Add( new DataColumn("unloaddocdate", typeof(DateTime)));
	tassetview1.Columns.Add( new DataColumn("unloadenactment", typeof(string)));
	tassetview1.Columns.Add( new DataColumn("unloadenactmentdate", typeof(DateTime)));
	tassetview1.Columns.Add( new DataColumn("unloadregistry", typeof(string)));
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tassetview1.Columns.Add(C);
	C= new DataColumn("flagunload", typeof(string));
	C.ReadOnly=true;
	tassetview1.Columns.Add(C);
	C= new DataColumn("flagtransf", typeof(string));
	C.ReadOnly=true;
	tassetview1.Columns.Add(C);
	tassetview1.Columns.Add( new DataColumn("transmitted", typeof(string)));
	C= new DataColumn("flagload", typeof(string));
	C.ReadOnly=true;
	tassetview1.Columns.Add(C);
	C= new DataColumn("loadkind", typeof(string));
	C.ReadOnly=true;
	tassetview1.Columns.Add(C);
	tassetview1.Columns.Add( new DataColumn("multifield", typeof(string)));
	C= new DataColumn("idsor01", typeof(int));
	C.ReadOnly=true;
	tassetview1.Columns.Add(C);
	C= new DataColumn("idsor02", typeof(int));
	C.ReadOnly=true;
	tassetview1.Columns.Add(C);
	C= new DataColumn("idsor03", typeof(int));
	C.ReadOnly=true;
	tassetview1.Columns.Add(C);
	C= new DataColumn("idsor04", typeof(int));
	C.ReadOnly=true;
	tassetview1.Columns.Add(C);
	C= new DataColumn("idsor05", typeof(int));
	C.ReadOnly=true;
	tassetview1.Columns.Add(C);
	C= new DataColumn("is_unloaded", typeof(string));
	C.ReadOnly=true;
	tassetview1.Columns.Add(C);
	C= new DataColumn("is_loaded", typeof(string));
	C.ReadOnly=true;
	tassetview1.Columns.Add(C);
	tassetview1.Columns.Add( new DataColumn("idupb", typeof(string)));
	tassetview1.Columns.Add( new DataColumn("codeupb", typeof(string)));
	tassetview1.Columns.Add( new DataColumn("upb", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tassetview1.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tassetview1.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tassetview1.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tassetview1.Columns.Add(C);
	tassetview1.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tassetview1.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idinventoryagency", typeof(int));
	C.AllowDBNull=false;
	tassetview1.Columns.Add(C);
	C= new DataColumn("inventoryagency", typeof(string));
	C.AllowDBNull=false;
	tassetview1.Columns.Add(C);
	tassetview1.Columns.Add( new DataColumn("idlist", typeof(int)));
	tassetview1.Columns.Add( new DataColumn("intcode", typeof(string)));
	tassetview1.Columns.Add( new DataColumn("list", typeof(string)));
	tassetview1.Columns.Add( new DataColumn("idinventoryamortization", typeof(int)));
	tassetview1.Columns.Add( new DataColumn("amortizationquota", typeof(double)));
	tassetview1.Columns.Add( new DataColumn("idinvkind", typeof(int)));
	tassetview1.Columns.Add( new DataColumn("yinv", typeof(short)));
	tassetview1.Columns.Add( new DataColumn("ninv", typeof(int)));
	tassetview1.Columns.Add( new DataColumn("invrownum", typeof(int)));
	Tables.Add(tassetview1);

	#endregion


	#region DataRelation creation
	var cPar = new []{asset.Columns["idasset"]};
	var cChild = new []{assetlocation.Columns["idasset"]};
	Relations.Add(new DataRelation("asset_assetlocation",cPar,cChild,false));

	cPar = new []{managerconsegnatario.Columns["idman"]};
	cChild = new []{assetsubmanager.Columns["idmanager"]};
	Relations.Add(new DataRelation("FK_managerconsegnatario_assetsubmanager",cPar,cChild,false));

	cPar = new []{asset.Columns["idasset"]};
	cChild = new []{assetsubmanager.Columns["idasset"]};
	Relations.Add(new DataRelation("FK_asset_assetsubmanager",cPar,cChild,false));

	cPar = new []{assetunload.Columns["idassetunload"]};
	cChild = new []{assetview_piece.Columns["idassetunload"]};
	Relations.Add(new DataRelation("assetunload_assetview_piece",cPar,cChild,false));

	cPar = new []{assetunload.Columns["idassetunload"]};
	cChild = new []{assetview.Columns["idassetunload"]};
	Relations.Add(new DataRelation("assetunload_assetview",cPar,cChild,false));

	cPar = new []{assetacquire.Columns["nassetacquire"]};
	cChild = new []{asset_detail.Columns["nassetacquire"]};
	Relations.Add(new DataRelation("assetacquire_asset_detail",cPar,cChild,false));

	cPar = new []{asset.Columns["idasset"]};
	cChild = new []{asset_detail.Columns["idasset"]};
	Relations.Add(new DataRelation("asset_asset_detail",cPar,cChild,false));

	cPar = new []{assetacquire.Columns["nassetacquire"]};
	cChild = new []{asset.Columns["nassetacquire"]};
	Relations.Add(new DataRelation("assetacquire_asset",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{assetacquire.Columns["idupb"]};
	Relations.Add(new DataRelation("FK_upb_assetacquire",cPar,cChild,false));

	cPar = new []{assetload.Columns["idassetload"]};
	cChild = new []{assetacquire.Columns["idassetload"]};
	Relations.Add(new DataRelation("assetload_assetacquire",cPar,cChild,false));

	cPar = new []{manager.Columns["idman"]};
	cChild = new []{assetmanager.Columns["idman"]};
	Relations.Add(new DataRelation("manager_assetmanager",cPar,cChild,false));

	cPar = new []{asset.Columns["idasset"]};
	cChild = new []{assetmanager.Columns["idasset"]};
	Relations.Add(new DataRelation("asset_assetmanager",cPar,cChild,false));

	cPar = new []{registry_assetunload.Columns["idreg"]};
	cChild = new []{assetunload.Columns["idreg"]};
	Relations.Add(new DataRelation("registry_assetunload_assetunload",cPar,cChild,false));

	cPar = new []{assetunloadkind.Columns["idassetunloadkind"]};
	cChild = new []{assetunload.Columns["idassetunloadkind"]};
	Relations.Add(new DataRelation("assetunloadkindassetunload",cPar,cChild,false));

	cPar = new []{registry_assetload.Columns["idreg"]};
	cChild = new []{assetload.Columns["idreg"]};
	Relations.Add(new DataRelation("registry_assetload_assetload",cPar,cChild,false));

	cPar = new []{assetloadkind.Columns["idassetloadkind"]};
	cChild = new []{assetload.Columns["idassetloadkind"]};
	Relations.Add(new DataRelation("assetloadkindassetload",cPar,cChild,false));

	cPar = new []{asset.Columns["idasset"], asset.Columns["idpiece"]};
	cChild = new []{assetamortization.Columns["idasset"], assetamortization.Columns["idpiece"]};
	Relations.Add(new DataRelation("asset_assetamortization",cPar,cChild,false));

	#endregion

}
}
}
