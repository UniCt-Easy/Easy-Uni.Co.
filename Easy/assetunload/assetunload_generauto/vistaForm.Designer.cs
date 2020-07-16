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

﻿using System;
using System.Data;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.Serialization;
#pragma warning disable 1591
namespace assetunload_generauto {
[Serializable()][DesignerCategoryAttribute("code")][System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRootAttribute("vistaForm")][System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Buono di scarico
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable assetunload		{get { return Tables["assetunload"];}}
	///<summary>
	///Causali di scarico
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable assetunloadmotive		{get { return Tables["assetunloadmotive"];}}
	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable registry		{get { return Tables["registry"];}}
	///<summary>
	///Movimenti di entrata collegati a buoni di scarico
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable assetunloadincome		{get { return Tables["assetunloadincome"];}}
	///<summary>
	///Fasi di entrata
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable incomephase		{get { return Tables["incomephase"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable incomeview		{get { return Tables["incomeview"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable assetunloadkindview		{get { return Tables["assetunloadkindview"];}}
	///<summary>
	///Configurazione Annuale
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable config		{get { return Tables["config"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable assetamortizationunloadview		{get { return Tables["assetamortizationunloadview"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable assetpieceview		{get { return Tables["assetpieceview"];}}
	#endregion


	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables {get {return base.Tables;}}

	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataRelationCollection Relations {get {return base.Relations; } } 

[DebuggerNonUserCodeAttribute()]
public vistaForm(){
	BeginInit();
	InitClass();
	EndInit();
}
[DebuggerNonUserCodeAttribute()]
protected vistaForm (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCodeAttribute()]
private void InitClass() {
	DataSetName = "vistaForm";
	Prefix = "";
	Namespace = "http://tempuri.org/vistaForm.xsd";
	EnforceConstraints = false;

	#region create DataTables
	DataTable T;
	DataColumn C;
	//////////////////// ASSETUNLOAD /////////////////////////////////
	T= new DataTable("assetunload");
	C= new DataColumn("idassetunload", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idassetunloadkind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("yassetunload", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("nassetunload", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idreg", typeof(Int32)));
	T.Columns.Add( new DataColumn("idmot", typeof(Int32)));
	T.Columns.Add( new DataColumn("doc", typeof(String)));
	T.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	T.Columns.Add( new DataColumn("description", typeof(String)));
	T.Columns.Add( new DataColumn("enactment", typeof(String)));
	T.Columns.Add( new DataColumn("enactmentdate", typeof(DateTime)));
	T.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	T.Columns.Add( new DataColumn("printdate", typeof(DateTime)));
	T.Columns.Add( new DataColumn("ratificationdate", typeof(DateTime)));
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("transmitted", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idassetunload"]};


	//////////////////// ASSETUNLOADMOTIVE /////////////////////////////////
	T= new DataTable("assetunloadmotive");
	C= new DataColumn("idmot", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idmot"]};


	//////////////////// REGISTRY /////////////////////////////////
	T= new DataTable("registry");
	C= new DataColumn("idreg", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("title", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("cf", typeof(String)));
	T.Columns.Add( new DataColumn("p_iva", typeof(String)));
	C= new DataColumn("residence", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("annotation", typeof(String)));
	T.Columns.Add( new DataColumn("birthdate", typeof(DateTime)));
	T.Columns.Add( new DataColumn("gender", typeof(String)));
	T.Columns.Add( new DataColumn("surname", typeof(String)));
	T.Columns.Add( new DataColumn("forename", typeof(String)));
	T.Columns.Add( new DataColumn("foreigncf", typeof(String)));
	C= new DataColumn("active", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("badgecode", typeof(String)));
	T.Columns.Add( new DataColumn("idcategory", typeof(String)));
	T.Columns.Add( new DataColumn("idcentralizedcategory", typeof(String)));
	T.Columns.Add( new DataColumn("idmaritalstatus", typeof(String)));
	T.Columns.Add( new DataColumn("idtitle", typeof(String)));
	T.Columns.Add( new DataColumn("idregistryclass", typeof(String)));
	T.Columns.Add( new DataColumn("maritalsurname", typeof(String)));
	T.Columns.Add( new DataColumn("idcity", typeof(Int32)));
	T.Columns.Add( new DataColumn("idnation", typeof(Int32)));
	T.Columns.Add( new DataColumn("location", typeof(String)));
	T.Columns.Add( new DataColumn("extmatricula", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idreg"]};


	//////////////////// ASSETUNLOADINCOME /////////////////////////////////
	T= new DataTable("assetunloadincome");
	C= new DataColumn("idinc", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	T.Columns.Add( new DataColumn("cu", typeof(String)));
	T.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	T.Columns.Add( new DataColumn("lu", typeof(String)));
	T.Columns.Add( new DataColumn("!ymov", typeof(Int16)));
	T.Columns.Add( new DataColumn("!nmov", typeof(Int32)));
	T.Columns.Add( new DataColumn("!incomedescription", typeof(String)));
	T.Columns.Add( new DataColumn("!incomedoc", typeof(String)));
	T.Columns.Add( new DataColumn("!amount", typeof(String)));
	T.Columns.Add( new DataColumn("!available", typeof(String)));
	C= new DataColumn("idassetunload", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idassetunload"], T.Columns["idinc"]};


	//////////////////// INCOMEPHASE /////////////////////////////////
	T= new DataTable("incomephase");
	C= new DataColumn("nphase", typeof(Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["nphase"]};


	//////////////////// INCOMEVIEW /////////////////////////////////
	T= new DataTable("incomeview");
	C= new DataColumn("idinc", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("nphase", typeof(Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("phase", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ymov", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("nmov", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("parentidinc", typeof(Int32)));
	C= new DataColumn("ayear", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idfin", typeof(Int32)));
	T.Columns.Add( new DataColumn("codefin", typeof(String)));
	T.Columns.Add( new DataColumn("finance", typeof(String)));
	T.Columns.Add( new DataColumn("idreg", typeof(Int32)));
	T.Columns.Add( new DataColumn("registry", typeof(String)));
	T.Columns.Add( new DataColumn("idman", typeof(Int32)));
	T.Columns.Add( new DataColumn("manager", typeof(String)));
	T.Columns.Add( new DataColumn("ypro", typeof(Int16)));
	T.Columns.Add( new DataColumn("npro", typeof(Int32)));
	T.Columns.Add( new DataColumn("doc", typeof(String)));
	T.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("amount", typeof(Decimal)));
	T.Columns.Add( new DataColumn("ayearstartamount", typeof(Decimal)));
	T.Columns.Add( new DataColumn("curramount", typeof(Decimal)));
	T.Columns.Add( new DataColumn("available", typeof(Decimal)));
	C= new DataColumn("unpartitioned", typeof(Decimal));
	C.ReadOnly=true;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("flagarrear", typeof(String)));
	T.Columns.Add( new DataColumn("autokind", typeof(Byte)));
	T.Columns.Add( new DataColumn("idpayment", typeof(Int32)));
	T.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idupb", typeof(String)));
	T.Columns.Add( new DataColumn("codeupb", typeof(String)));
	T.Columns.Add( new DataColumn("upb", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idinc"]};


	//////////////////// ASSETUNLOADKINDVIEW /////////////////////////////////
	T= new DataTable("assetunloadkindview");
	C= new DataColumn("idassetunloadkind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idinventory", typeof(Int32)));
	C= new DataColumn("inventory", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("startnumber", typeof(Int32)));
	C= new DataColumn("flaglinear", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idsor01", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor02", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor03", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor04", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor05", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idassetunloadkind"]};


	//////////////////// CONFIG /////////////////////////////////
	T= new DataTable("config");
	C= new DataColumn("ayear", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("agencycode", typeof(String)));
	T.Columns.Add( new DataColumn("appname", typeof(String)));
	T.Columns.Add( new DataColumn("appropriationphasecode", typeof(Byte)));
	T.Columns.Add( new DataColumn("assessmentphasecode", typeof(Byte)));
	T.Columns.Add( new DataColumn("asset_flagnumbering", typeof(String)));
	T.Columns.Add( new DataColumn("asset_flagrestart", typeof(String)));
	T.Columns.Add( new DataColumn("assetload_flag", typeof(Byte)));
	T.Columns.Add( new DataColumn("boxpartitiontitle", typeof(String)));
	T.Columns.Add( new DataColumn("cashvaliditykind", typeof(Byte)));
	T.Columns.Add( new DataColumn("casualcontract_flagrestart", typeof(String)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("currpartitiontitle", typeof(String)));
	T.Columns.Add( new DataColumn("deferredexpensephase", typeof(String)));
	T.Columns.Add( new DataColumn("deferredincomephase", typeof(String)));
	T.Columns.Add( new DataColumn("electronicimport", typeof(String)));
	T.Columns.Add( new DataColumn("electronictrasmission", typeof(String)));
	T.Columns.Add( new DataColumn("expense_expiringdays", typeof(Int16)));
	T.Columns.Add( new DataColumn("expensephase", typeof(Byte)));
	T.Columns.Add( new DataColumn("flagautopayment", typeof(String)));
	T.Columns.Add( new DataColumn("flagautoproceeds", typeof(String)));
	T.Columns.Add( new DataColumn("flagcredit", typeof(String)));
	T.Columns.Add( new DataColumn("flagepexp", typeof(String)));
	T.Columns.Add( new DataColumn("flagfruitful", typeof(String)));
	T.Columns.Add( new DataColumn("flagpayment", typeof(String)));
	T.Columns.Add( new DataColumn("flagproceeds", typeof(String)));
	T.Columns.Add( new DataColumn("flagrefund", typeof(String)));
	T.Columns.Add( new DataColumn("foreignhours", typeof(Int32)));
	T.Columns.Add( new DataColumn("idacc_accruedcost", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_accruedrevenue", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_customer", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_deferredcost", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_deferredcredit", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_deferreddebit", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_deferredrevenue", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_ivapayment", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_ivarefund", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_patrimony", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_pl", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_supplier", typeof(String)));
	T.Columns.Add( new DataColumn("idaccmotive_admincar", typeof(String)));
	T.Columns.Add( new DataColumn("idaccmotive_foot", typeof(String)));
	T.Columns.Add( new DataColumn("idaccmotive_owncar", typeof(String)));
	T.Columns.Add( new DataColumn("idclawback", typeof(Int32)));
	T.Columns.Add( new DataColumn("idfinexpense", typeof(Int32)));
	T.Columns.Add( new DataColumn("idfinexpensesurplus", typeof(Int32)));
	T.Columns.Add( new DataColumn("idfinincomesurplus", typeof(Int32)));
	T.Columns.Add( new DataColumn("idfinivapayment", typeof(Int32)));
	T.Columns.Add( new DataColumn("idfinivarefund", typeof(Int32)));
	T.Columns.Add( new DataColumn("idivapayperiodicity", typeof(Int32)));
	T.Columns.Add( new DataColumn("idregauto", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsortingkind1", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsortingkind2", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsortingkind3", typeof(Int32)));
	T.Columns.Add( new DataColumn("importappname", typeof(String)));
	T.Columns.Add( new DataColumn("income_expiringdays", typeof(Int16)));
	T.Columns.Add( new DataColumn("incomephase", typeof(Byte)));
	T.Columns.Add( new DataColumn("linktoinvoice", typeof(String)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("minpayment", typeof(Decimal)));
	T.Columns.Add( new DataColumn("minrefund", typeof(Decimal)));
	T.Columns.Add( new DataColumn("motivelen", typeof(Int16)));
	T.Columns.Add( new DataColumn("motiveprefix", typeof(String)));
	T.Columns.Add( new DataColumn("motiveseparator", typeof(String)));
	T.Columns.Add( new DataColumn("payment_finlevel", typeof(Byte)));
	T.Columns.Add( new DataColumn("payment_flag", typeof(Byte)));
	T.Columns.Add( new DataColumn("payment_flagautoprintdate", typeof(String)));
	T.Columns.Add( new DataColumn("paymentagency", typeof(Int32)));
	T.Columns.Add( new DataColumn("prevpartitiontitle", typeof(String)));
	T.Columns.Add( new DataColumn("proceeds_finlevel", typeof(Byte)));
	T.Columns.Add( new DataColumn("proceeds_flag", typeof(Byte)));
	T.Columns.Add( new DataColumn("proceeds_flagautoprintdate", typeof(String)));
	T.Columns.Add( new DataColumn("profservice_flagrestart", typeof(String)));
	T.Columns.Add( new DataColumn("refundagency", typeof(Int32)));
	T.Columns.Add( new DataColumn("wageaddition_flagrestart", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["ayear"]};


	//////////////////// ASSETAMORTIZATIONUNLOADVIEW /////////////////////////////////
	T= new DataTable("assetamortizationunloadview");
	C= new DataColumn("namortization", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idasset", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idpiece", typeof(Int32)));
	C= new DataColumn("idinventoryamortization", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("codeinventoryamortization", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("inventoryamortization", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idinventory", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("inventory", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("ninventory", typeof(Int32)));
	T.Columns.Add( new DataColumn("idlocation", typeof(Int32)));
	T.Columns.Add( new DataColumn("locationcode", typeof(String)));
	T.Columns.Add( new DataColumn("location", typeof(String)));
	T.Columns.Add( new DataColumn("idcurrlocation", typeof(Int32)));
	T.Columns.Add( new DataColumn("currlocationcode", typeof(String)));
	T.Columns.Add( new DataColumn("currlocation", typeof(String)));
	T.Columns.Add( new DataColumn("idman", typeof(Int32)));
	T.Columns.Add( new DataColumn("manager", typeof(String)));
	T.Columns.Add( new DataColumn("idcurrman", typeof(Int32)));
	T.Columns.Add( new DataColumn("currmanager", typeof(String)));
	C= new DataColumn("loaddescription", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("assetvalue", typeof(Decimal)));
	T.Columns.Add( new DataColumn("amortizationquota", typeof(Double)));
	C= new DataColumn("amount", typeof(Decimal));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idassetunload", typeof(Int32)));
	T.Columns.Add( new DataColumn("idassetunloadkind", typeof(Int32)));
	T.Columns.Add( new DataColumn("assetunloadkind", typeof(String)));
	T.Columns.Add( new DataColumn("yassetunload", typeof(Int16)));
	T.Columns.Add( new DataColumn("nassetunload", typeof(Int32)));
	C= new DataColumn("flag", typeof(Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("flagunload", typeof(String));
	C.ReadOnly=true;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("transmitted", typeof(String)));
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("nassetacquire", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["namortization"]};


	//////////////////// ASSETPIECEVIEW /////////////////////////////////
	T= new DataTable("assetpieceview");
	C= new DataColumn("idasset", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idpiece", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("lifestart", typeof(DateTime)));
	C= new DataColumn("yearstart", typeof(Int32));
	C.ReadOnly=true;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("nassetacquire", typeof(Int32)));
	T.Columns.Add( new DataColumn("idupb", typeof(String)));
	T.Columns.Add( new DataColumn("ninventory", typeof(Int32)));
	T.Columns.Add( new DataColumn("idlocation", typeof(Int32)));
	T.Columns.Add( new DataColumn("locationcode", typeof(String)));
	T.Columns.Add( new DataColumn("location", typeof(String)));
	T.Columns.Add( new DataColumn("idcurrlocation", typeof(Int32)));
	T.Columns.Add( new DataColumn("currlocationcode", typeof(String)));
	T.Columns.Add( new DataColumn("currlocation", typeof(String)));
	T.Columns.Add( new DataColumn("idman", typeof(Int32)));
	T.Columns.Add( new DataColumn("manager", typeof(String)));
	T.Columns.Add( new DataColumn("idcurrman", typeof(Int32)));
	T.Columns.Add( new DataColumn("currmanager", typeof(String)));
	C= new DataColumn("idinv", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("codeinv", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idinv_lev1", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("codeinv_lev1", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("inventorytree", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("inventorytree_lev1", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idinventory", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("inventory", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("descriptionmain", typeof(String));
	C.ReadOnly=true;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idassetload", typeof(Int32)));
	T.Columns.Add( new DataColumn("idassetloadkind", typeof(Int32)));
	T.Columns.Add( new DataColumn("yassetload", typeof(Int16)));
	T.Columns.Add( new DataColumn("nassetload", typeof(Int32)));
	C= new DataColumn("taxable", typeof(Decimal));
	C.ReadOnly=true;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("taxrate", typeof(Double)));
	T.Columns.Add( new DataColumn("discount", typeof(Double)));
	C= new DataColumn("cost", typeof(Decimal));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("revals", typeof(Decimal));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("revals_pending", typeof(Decimal));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("subtractions", typeof(Decimal));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("currentvalue", typeof(Decimal));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("total", typeof(Decimal));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("abatable", typeof(Decimal));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("unabatable", typeof(Decimal));
	C.ReadOnly=true;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idassetunload", typeof(Int32)));
	T.Columns.Add( new DataColumn("idassetunloadkind", typeof(Int32)));
	T.Columns.Add( new DataColumn("yassetunload", typeof(Int16)));
	T.Columns.Add( new DataColumn("nassetunload", typeof(Int32)));
	T.Columns.Add( new DataColumn("transmitted", typeof(String)));
	C= new DataColumn("flag", typeof(Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idsor01", typeof(Int32));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("idsor02", typeof(Int32));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("idsor03", typeof(Int32));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("idsor04", typeof(Int32));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("idsor05", typeof(Int32));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("is_unloaded", typeof(String));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("is_loaded", typeof(String));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("!pieceorasset", typeof(String)));
	T.Columns.Add( new DataColumn("historicalvalue", typeof(Decimal)));
	Tables.Add(T);

	#endregion


	#region DataRelation creation
	DataColumn []CPar;
	DataColumn []CChild;
	CPar = new DataColumn[1]{assetunload.Columns["idassetunload"]};
	CChild = new DataColumn[1]{assetpieceview.Columns["idassetunload"]};
	Relations.Add(new DataRelation("assetunload_assetpieceview",CPar,CChild,false));

	CPar = new DataColumn[1]{assetunload.Columns["idassetunload"]};
	CChild = new DataColumn[1]{assetamortizationunloadview.Columns["idassetunload"]};
	Relations.Add(new DataRelation("FK_assetunload_assetamortizationunloadview",CPar,CChild,false));

	CPar = new DataColumn[1]{assetunload.Columns["idassetunload"]};
	CChild = new DataColumn[1]{assetunloadincome.Columns["idassetunload"]};
	Relations.Add(new DataRelation("assetunloadassetunloadincome",CPar,CChild,false));

	CPar = new DataColumn[1]{incomeview.Columns["idinc"]};
	CChild = new DataColumn[1]{assetunloadincome.Columns["idinc"]};
	Relations.Add(new DataRelation("incomeview_assetunloadincome",CPar,CChild,false));

	CPar = new DataColumn[1]{assetunloadkindview.Columns["idassetunloadkind"]};
	CChild = new DataColumn[1]{assetunload.Columns["idassetunloadkind"]};
	Relations.Add(new DataRelation("assetunloadkindviewassetunload",CPar,CChild,false));

	CPar = new DataColumn[1]{registry.Columns["idreg"]};
	CChild = new DataColumn[1]{assetunload.Columns["idreg"]};
	Relations.Add(new DataRelation("registryassetunload",CPar,CChild,false));

	CPar = new DataColumn[1]{assetunloadmotive.Columns["idmot"]};
	CChild = new DataColumn[1]{assetunload.Columns["idmot"]};
	Relations.Add(new DataRelation("assetunloadmotiveassetunload",CPar,CChild,false));

	#endregion

}
}
}
