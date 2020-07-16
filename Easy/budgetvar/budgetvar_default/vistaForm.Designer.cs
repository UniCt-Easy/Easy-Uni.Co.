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

using System;
using System.Data;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.Serialization;
#pragma warning disable 1591
namespace budgetvar_default {
[Serializable()][DesignerCategoryAttribute("code")][System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRootAttribute("vistaForm")][System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Dettaglio variazione di Budget
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable budgetvardetail		{get { return Tables["budgetvardetail"];}}
	///<summary>
	///U.P.B.
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable upb		{get { return Tables["upb"];}}
	///<summary>
	///Variazione
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable budgetvar		{get { return Tables["budgetvar"];}}
	///<summary>
	///Configurazione Annuale
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable config		{get { return Tables["config"];}}
	///<summary>
	///Stato variazione di budget
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable budgetvarstatus		{get { return Tables["budgetvarstatus"];}}
	///<summary>
	///Responsabile
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable manager		{get { return Tables["manager"];}}
	///<summary>
	///Allegato alla variazione di budget
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable budgetvarattachment		{get { return Tables["budgetvarattachment"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable sorting01		{get { return Tables["sorting01"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable sorting02		{get { return Tables["sorting02"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable sorting03		{get { return Tables["sorting03"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable sorting04		{get { return Tables["sorting04"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable sorting05		{get { return Tables["sorting05"];}}
	///<summary>
	///Classificazione Movimenti
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable sorting		{get { return Tables["sorting"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable budgetvardetailview		{get { return Tables["budgetvardetailview"];}}
	///<summary>
	///Tipo di Rilevanza analitica
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable sortingkind		{get { return Tables["sortingkind"];}}
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
	//////////////////// BUDGETVARDETAIL /////////////////////////////////
	T= new DataTable("budgetvardetail");
	C= new DataColumn("ybudgetvar", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("nbudgetvar", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idsor", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("!sortcode", typeof(String)));
	T.Columns.Add( new DataColumn("description", typeof(String)));
	T.Columns.Add( new DataColumn("amount", typeof(Decimal)));
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
	C= new DataColumn("idupb", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("!upb", typeof(String)));
	T.Columns.Add( new DataColumn("annotation", typeof(String)));
	C= new DataColumn("rownum", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["ybudgetvar"], T.Columns["nbudgetvar"], T.Columns["rownum"]};


	//////////////////// UPB /////////////////////////////////
	T= new DataTable("upb");
	C= new DataColumn("idupb", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("codeupb", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("title", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idupb"]};


	//////////////////// BUDGETVAR /////////////////////////////////
	T= new DataTable("budgetvar");
	C= new DataColumn("ybudgetvar", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("nbudgetvar", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("adate", typeof(DateTime));
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
	T.Columns.Add( new DataColumn("official", typeof(String)));
	T.Columns.Add( new DataColumn("nofficial", typeof(Int32)));
	T.Columns.Add( new DataColumn("idbudgetvarstatus", typeof(Int16)));
	T.Columns.Add( new DataColumn("reason", typeof(String)));
	T.Columns.Add( new DataColumn("annotation", typeof(String)));
	T.Columns.Add( new DataColumn("idman", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor01", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor02", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor03", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor04", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor05", typeof(Int32)));
	C= new DataColumn("idsorkind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("yvar", typeof(Int16)));
	T.Columns.Add( new DataColumn("nvar", typeof(Int16)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["ybudgetvar"], T.Columns["nbudgetvar"]};


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
	T.Columns.Add( new DataColumn("finvar_warnmail", typeof(String)));
	T.Columns.Add( new DataColumn("idfin_store", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["ayear"]};


	//////////////////// BUDGETVARSTATUS /////////////////////////////////
	T= new DataTable("budgetvarstatus");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idbudgetvarstatus", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idbudgetvarstatus"]};


	//////////////////// MANAGER /////////////////////////////////
	T= new DataTable("manager");
	T.Columns.Add( new DataColumn("active", typeof(String)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("email", typeof(String)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("passwordweb", typeof(String)));
	T.Columns.Add( new DataColumn("phonenumber", typeof(String)));
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	T.Columns.Add( new DataColumn("userweb", typeof(String)));
	C= new DataColumn("idman", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("iddivision", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idsor01", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor02", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor03", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor04", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor05", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idman"]};


	//////////////////// BUDGETVARATTACHMENT /////////////////////////////////
	T= new DataTable("budgetvarattachment");
	C= new DataColumn("ybudgetvar", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("nbudgetvar", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idattachment", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("filename", typeof(String)));
	T.Columns.Add( new DataColumn("attachment", typeof(Byte[])));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["ybudgetvar"], T.Columns["nbudgetvar"], T.Columns["idattachment"]};


	//////////////////// SORTING01 /////////////////////////////////
	T= new DataTable("sorting01");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("defaultN1", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultN2", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultN3", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultN4", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultN5", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultS1", typeof(String)));
	T.Columns.Add( new DataColumn("defaultS2", typeof(String)));
	T.Columns.Add( new DataColumn("defaultS3", typeof(String)));
	T.Columns.Add( new DataColumn("defaultS4", typeof(String)));
	T.Columns.Add( new DataColumn("defaultS5", typeof(String)));
	T.Columns.Add( new DataColumn("defaultv1", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultv2", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultv3", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultv4", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultv5", typeof(Decimal)));
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("flagnodate", typeof(String)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("movkind", typeof(String)));
	T.Columns.Add( new DataColumn("printingorder", typeof(String)));
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	C= new DataColumn("idsorkind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idsor", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("paridsor", typeof(Int32)));
	C= new DataColumn("nlevel", typeof(Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("start", typeof(Int16)));
	T.Columns.Add( new DataColumn("stop", typeof(Int16)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idsor"]};


	//////////////////// SORTING02 /////////////////////////////////
	T= new DataTable("sorting02");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("defaultN1", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultN2", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultN3", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultN4", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultN5", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultS1", typeof(String)));
	T.Columns.Add( new DataColumn("defaultS2", typeof(String)));
	T.Columns.Add( new DataColumn("defaultS3", typeof(String)));
	T.Columns.Add( new DataColumn("defaultS4", typeof(String)));
	T.Columns.Add( new DataColumn("defaultS5", typeof(String)));
	T.Columns.Add( new DataColumn("defaultv1", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultv2", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultv3", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultv4", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultv5", typeof(Decimal)));
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("flagnodate", typeof(String)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("movkind", typeof(String)));
	T.Columns.Add( new DataColumn("printingorder", typeof(String)));
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	C= new DataColumn("idsorkind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idsor", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("paridsor", typeof(Int32)));
	C= new DataColumn("nlevel", typeof(Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("start", typeof(Int16)));
	T.Columns.Add( new DataColumn("stop", typeof(Int16)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idsor"]};


	//////////////////// SORTING03 /////////////////////////////////
	T= new DataTable("sorting03");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("defaultN1", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultN2", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultN3", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultN4", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultN5", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultS1", typeof(String)));
	T.Columns.Add( new DataColumn("defaultS2", typeof(String)));
	T.Columns.Add( new DataColumn("defaultS3", typeof(String)));
	T.Columns.Add( new DataColumn("defaultS4", typeof(String)));
	T.Columns.Add( new DataColumn("defaultS5", typeof(String)));
	T.Columns.Add( new DataColumn("defaultv1", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultv2", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultv3", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultv4", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultv5", typeof(Decimal)));
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("flagnodate", typeof(String)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("movkind", typeof(String)));
	T.Columns.Add( new DataColumn("printingorder", typeof(String)));
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	C= new DataColumn("idsorkind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idsor", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("paridsor", typeof(Int32)));
	C= new DataColumn("nlevel", typeof(Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("start", typeof(Int16)));
	T.Columns.Add( new DataColumn("stop", typeof(Int16)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idsor"]};


	//////////////////// SORTING04 /////////////////////////////////
	T= new DataTable("sorting04");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("defaultN1", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultN2", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultN3", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultN4", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultN5", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultS1", typeof(String)));
	T.Columns.Add( new DataColumn("defaultS2", typeof(String)));
	T.Columns.Add( new DataColumn("defaultS3", typeof(String)));
	T.Columns.Add( new DataColumn("defaultS4", typeof(String)));
	T.Columns.Add( new DataColumn("defaultS5", typeof(String)));
	T.Columns.Add( new DataColumn("defaultv1", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultv2", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultv3", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultv4", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultv5", typeof(Decimal)));
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("flagnodate", typeof(String)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("movkind", typeof(String)));
	T.Columns.Add( new DataColumn("printingorder", typeof(String)));
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	C= new DataColumn("idsorkind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idsor", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("paridsor", typeof(Int32)));
	C= new DataColumn("nlevel", typeof(Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("start", typeof(Int16)));
	T.Columns.Add( new DataColumn("stop", typeof(Int16)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idsor"]};


	//////////////////// SORTING05 /////////////////////////////////
	T= new DataTable("sorting05");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("defaultN1", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultN2", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultN3", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultN4", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultN5", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultS1", typeof(String)));
	T.Columns.Add( new DataColumn("defaultS2", typeof(String)));
	T.Columns.Add( new DataColumn("defaultS3", typeof(String)));
	T.Columns.Add( new DataColumn("defaultS4", typeof(String)));
	T.Columns.Add( new DataColumn("defaultS5", typeof(String)));
	T.Columns.Add( new DataColumn("defaultv1", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultv2", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultv3", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultv4", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultv5", typeof(Decimal)));
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("flagnodate", typeof(String)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("movkind", typeof(String)));
	T.Columns.Add( new DataColumn("printingorder", typeof(String)));
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	C= new DataColumn("idsorkind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idsor", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("paridsor", typeof(Int32)));
	C= new DataColumn("nlevel", typeof(Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("start", typeof(Int16)));
	T.Columns.Add( new DataColumn("stop", typeof(Int16)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idsor"]};


	//////////////////// SORTING /////////////////////////////////
	T= new DataTable("sorting");
	C= new DataColumn("sortcode", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idsor", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idsor"]};


	//////////////////// BUDGETVARDETAILVIEW /////////////////////////////////
	T= new DataTable("budgetvardetailview");
	C= new DataColumn("ybudgetvar", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("nbudgetvar", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("rownum", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("variationdescription", typeof(String)));
	T.Columns.Add( new DataColumn("official", typeof(String)));
	T.Columns.Add( new DataColumn("nofficial", typeof(Int32)));
	T.Columns.Add( new DataColumn("idman", typeof(Int32)));
	T.Columns.Add( new DataColumn("manager", typeof(String)));
	T.Columns.Add( new DataColumn("idbudgetvarstatus", typeof(Int32)));
	T.Columns.Add( new DataColumn("budgetvarstatus", typeof(String)));
	T.Columns.Add( new DataColumn("idsor", typeof(Int32)));
	C= new DataColumn("sortcode", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("sorting", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("description", typeof(String)));
	C= new DataColumn("idupb", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("codeupb", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("upb", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idsor01", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor02", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor03", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor04", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor05", typeof(Int32)));
	T.Columns.Add( new DataColumn("amount", typeof(Decimal)));
	T.Columns.Add( new DataColumn("annotation", typeof(String)));
	T.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	T.Columns.Add( new DataColumn("cu", typeof(String)));
	T.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	T.Columns.Add( new DataColumn("lu", typeof(String)));
	T.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	T.Columns.Add( new DataColumn("flagactivity", typeof(Int16)));
	C= new DataColumn("activity", typeof(String));
	C.ReadOnly=true;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("flagkind", typeof(Byte)));
	C= new DataColumn("kindd", typeof(String));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("kindr", typeof(String));
	C.ReadOnly=true;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idsorkind", typeof(Int32)));
	T.Columns.Add( new DataColumn("codesorkind", typeof(String)));
	T.Columns.Add( new DataColumn("sortingkind", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["ybudgetvar"], T.Columns["rownum"], T.Columns["nbudgetvar"]};


	//////////////////// SORTINGKIND /////////////////////////////////
	T= new DataTable("sortingkind");
	T.Columns.Add( new DataColumn("active", typeof(String)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("flagdate", typeof(String)));
	T.Columns.Add( new DataColumn("forcedN1", typeof(String)));
	T.Columns.Add( new DataColumn("forcedN2", typeof(String)));
	T.Columns.Add( new DataColumn("forcedN3", typeof(String)));
	T.Columns.Add( new DataColumn("forcedN4", typeof(String)));
	T.Columns.Add( new DataColumn("forcedN5", typeof(String)));
	T.Columns.Add( new DataColumn("forcedS1", typeof(String)));
	T.Columns.Add( new DataColumn("forcedS2", typeof(String)));
	T.Columns.Add( new DataColumn("forcedS3", typeof(String)));
	T.Columns.Add( new DataColumn("forcedS4", typeof(String)));
	T.Columns.Add( new DataColumn("forcedS5", typeof(String)));
	T.Columns.Add( new DataColumn("forcedv1", typeof(String)));
	T.Columns.Add( new DataColumn("forcedv2", typeof(String)));
	T.Columns.Add( new DataColumn("forcedv3", typeof(String)));
	T.Columns.Add( new DataColumn("forcedv4", typeof(String)));
	T.Columns.Add( new DataColumn("forcedv5", typeof(String)));
	T.Columns.Add( new DataColumn("labelfordate", typeof(String)));
	T.Columns.Add( new DataColumn("labeln1", typeof(String)));
	T.Columns.Add( new DataColumn("labeln2", typeof(String)));
	T.Columns.Add( new DataColumn("labeln3", typeof(String)));
	T.Columns.Add( new DataColumn("labeln4", typeof(String)));
	T.Columns.Add( new DataColumn("labeln5", typeof(String)));
	T.Columns.Add( new DataColumn("labels1", typeof(String)));
	T.Columns.Add( new DataColumn("labels2", typeof(String)));
	T.Columns.Add( new DataColumn("labels3", typeof(String)));
	T.Columns.Add( new DataColumn("labels4", typeof(String)));
	T.Columns.Add( new DataColumn("labels5", typeof(String)));
	T.Columns.Add( new DataColumn("labelv1", typeof(String)));
	T.Columns.Add( new DataColumn("labelv2", typeof(String)));
	T.Columns.Add( new DataColumn("labelv3", typeof(String)));
	T.Columns.Add( new DataColumn("labelv4", typeof(String)));
	T.Columns.Add( new DataColumn("labelv5", typeof(String)));
	T.Columns.Add( new DataColumn("lockedN1", typeof(String)));
	T.Columns.Add( new DataColumn("lockedN2", typeof(String)));
	T.Columns.Add( new DataColumn("lockedN3", typeof(String)));
	T.Columns.Add( new DataColumn("lockedN4", typeof(String)));
	T.Columns.Add( new DataColumn("lockedN5", typeof(String)));
	T.Columns.Add( new DataColumn("lockedS1", typeof(String)));
	T.Columns.Add( new DataColumn("lockedS2", typeof(String)));
	T.Columns.Add( new DataColumn("lockedS3", typeof(String)));
	T.Columns.Add( new DataColumn("lockedS4", typeof(String)));
	T.Columns.Add( new DataColumn("lockedS5", typeof(String)));
	T.Columns.Add( new DataColumn("lockedv1", typeof(String)));
	T.Columns.Add( new DataColumn("lockedv2", typeof(String)));
	T.Columns.Add( new DataColumn("lockedv3", typeof(String)));
	T.Columns.Add( new DataColumn("lockedv4", typeof(String)));
	T.Columns.Add( new DataColumn("lockedv5", typeof(String)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("nodatelabel", typeof(String)));
	T.Columns.Add( new DataColumn("totalexpression", typeof(String)));
	T.Columns.Add( new DataColumn("nphaseexpense", typeof(Byte)));
	T.Columns.Add( new DataColumn("nphaseincome", typeof(Byte)));
	C= new DataColumn("codesorkind", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idsorkind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("flag", typeof(Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("start", typeof(Int16)));
	T.Columns.Add( new DataColumn("stop", typeof(Int16)));
	T.Columns.Add( new DataColumn("idparentkind", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idsorkind"]};


	#endregion


	#region DataRelation creation
	DataColumn []CPar;
	DataColumn []CChild;
	CPar = new DataColumn[2]{budgetvar.Columns["ybudgetvar"], budgetvar.Columns["nbudgetvar"]};
	CChild = new DataColumn[2]{budgetvarattachment.Columns["ybudgetvar"], budgetvarattachment.Columns["nbudgetvar"]};
	Relations.Add(new DataRelation("budgetvar_budgetvarattachment",CPar,CChild,false));

	CPar = new DataColumn[1]{sortingkind.Columns["idsorkind"]};
	CChild = new DataColumn[1]{budgetvar.Columns["idsorkind"]};
	Relations.Add(new DataRelation("sortingkind_budgetvar",CPar,CChild,false));

	CPar = new DataColumn[1]{sorting05.Columns["idsor"]};
	CChild = new DataColumn[1]{budgetvar.Columns["idsor05"]};
	Relations.Add(new DataRelation("sorting05_budgetvar",CPar,CChild,false));

	CPar = new DataColumn[1]{sorting04.Columns["idsor"]};
	CChild = new DataColumn[1]{budgetvar.Columns["idsor04"]};
	Relations.Add(new DataRelation("sorting04_budgetvar",CPar,CChild,false));

	CPar = new DataColumn[1]{sorting03.Columns["idsor"]};
	CChild = new DataColumn[1]{budgetvar.Columns["idsor03"]};
	Relations.Add(new DataRelation("sorting03_budgetvar",CPar,CChild,false));

	CPar = new DataColumn[1]{sorting02.Columns["idsor"]};
	CChild = new DataColumn[1]{budgetvar.Columns["idsor02"]};
	Relations.Add(new DataRelation("sorting02_budgetvar",CPar,CChild,false));

	CPar = new DataColumn[1]{sorting01.Columns["idsor"]};
	CChild = new DataColumn[1]{budgetvar.Columns["idsor01"]};
	Relations.Add(new DataRelation("sorting01_budgetvar",CPar,CChild,false));

	CPar = new DataColumn[1]{budgetvarstatus.Columns["idbudgetvarstatus"]};
	CChild = new DataColumn[1]{budgetvar.Columns["idbudgetvarstatus"]};
	Relations.Add(new DataRelation("budgetvarstatus_budgetvar",CPar,CChild,false));

	CPar = new DataColumn[1]{manager.Columns["idman"]};
	CChild = new DataColumn[1]{budgetvar.Columns["idman"]};
	Relations.Add(new DataRelation("FK_manager_budgetvar",CPar,CChild,false));

	CPar = new DataColumn[1]{sorting.Columns["idsor"]};
	CChild = new DataColumn[1]{budgetvardetail.Columns["idsor"]};
	Relations.Add(new DataRelation("sorting_budgetvardetail",CPar,CChild,false));

	CPar = new DataColumn[2]{budgetvar.Columns["ybudgetvar"], budgetvar.Columns["nbudgetvar"]};
	CChild = new DataColumn[2]{budgetvardetail.Columns["ybudgetvar"], budgetvardetail.Columns["nbudgetvar"]};
	Relations.Add(new DataRelation("budgetvarbudgetvardetail",CPar,CChild,false));

	CPar = new DataColumn[1]{upb.Columns["idupb"]};
	CChild = new DataColumn[1]{budgetvardetail.Columns["idupb"]};
	Relations.Add(new DataRelation("upbbudgetvardetail",CPar,CChild,false));

	#endregion

}
}
}
