
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
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace Backend.Data {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta_estimate_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_estimate_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable estimate 		=> (MetaTable)Tables["estimate"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable estimatedetail 		=> (MetaTable)Tables["estimatedetail"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable manager 		=> (MetaTable)Tables["manager"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable estimatekind 		=> (MetaTable)Tables["estimatekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable currency 		=> (MetaTable)Tables["currency"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable expirationkind 		=> (MetaTable)Tables["expirationkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable estimatesorting 		=> (MetaTable)Tables["estimatesorting"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable invoicedetail 		=> (MetaTable)Tables["invoicedetail"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrymainview 		=> (MetaTable)Tables["registrymainview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable config 		=> (MetaTable)Tables["config"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable incomevar 		=> (MetaTable)Tables["incomevar"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry 		=> (MetaTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable upb_detail 		=> (MetaTable)Tables["upb_detail"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable incomesorted 		=> (MetaTable)Tables["incomesorted"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accmotiveapplied_credit 		=> (MetaTable)Tables["accmotiveapplied_credit"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accmotiveapplied_crg 		=> (MetaTable)Tables["accmotiveapplied_crg"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sortingview 		=> (MetaTable)Tables["sortingview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable underwriting 		=> (MetaTable)Tables["underwriting"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sorting01 		=> (MetaTable)Tables["sorting01"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sorting02 		=> (MetaTable)Tables["sorting02"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sorting03 		=> (MetaTable)Tables["sorting03"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sorting04 		=> (MetaTable)Tables["sorting04"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sorting05 		=> (MetaTable)Tables["sorting05"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ivakind 		=> (MetaTable)Tables["ivakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable estimatedetailview 		=> (MetaTable)Tables["estimatedetailview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable estimatesortingview 		=> (MetaTable)Tables["estimatesortingview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable estimateattachment 		=> (MetaTable)Tables["estimateattachment"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_estimate_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_estimate_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_estimate_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_estimate_default.xsd";

	#region create DataTables
	//////////////////// ESTIMATE /////////////////////////////////
	var testimate= new MetaTable("estimate");
	testimate.defineColumn("idestimkind", typeof(string),false);
	testimate.defineColumn("nestim", typeof(int),false);
	testimate.defineColumn("yestim", typeof(short),false);
	testimate.defineColumn("active", typeof(string));
	testimate.defineColumn("adate", typeof(DateTime),false);
	testimate.defineColumn("ct", typeof(DateTime),false);
	testimate.defineColumn("cu", typeof(string),false);
	testimate.defineColumn("deliveryaddress", typeof(string));
	testimate.defineColumn("deliveryexpiration", typeof(string));
	testimate.defineColumn("description", typeof(string),false);
	testimate.defineColumn("doc", typeof(string));
	testimate.defineColumn("docdate", typeof(DateTime));
	testimate.defineColumn("exchangerate", typeof(double));
	testimate.defineColumn("idcurrency", typeof(int));
	testimate.defineColumn("idexpirationkind", typeof(short));
	testimate.defineColumn("idman", typeof(int));
	testimate.defineColumn("idreg", typeof(int));
	testimate.defineColumn("lt", typeof(DateTime),false);
	testimate.defineColumn("lu", typeof(string),false);
	testimate.defineColumn("officiallyprinted", typeof(string),false);
	testimate.defineColumn("paymentexpiring", typeof(short));
	testimate.defineColumn("registryreference", typeof(string));
	testimate.defineColumn("rtf", typeof(Byte[]));
	testimate.defineColumn("txt", typeof(string));
	testimate.defineColumn("flagintracom", typeof(string));
	testimate.defineColumn("idaccmotivecredit", typeof(string));
	testimate.defineColumn("idaccmotivecredit_crg", typeof(string));
	testimate.defineColumn("idaccmotivecredit_datacrg", typeof(DateTime));
	testimate.defineColumn("idunderwriting", typeof(int));
	testimate.defineColumn("idsor01", typeof(int));
	testimate.defineColumn("idsor02", typeof(int));
	testimate.defineColumn("idsor03", typeof(int));
	testimate.defineColumn("idsor04", typeof(int));
	testimate.defineColumn("idsor05", typeof(int));
	testimate.defineColumn("external_reference", typeof(string));
	testimate.defineColumn("cigcode", typeof(string));
	Tables.Add(testimate);
	testimate.defineKey("idestimkind", "nestim", "yestim");

	//////////////////// ESTIMATEDETAIL /////////////////////////////////
	var testimatedetail= new MetaTable("estimatedetail");
	testimatedetail.defineColumn("idestimkind", typeof(string),false);
	testimatedetail.defineColumn("nestim", typeof(int),false);
	testimatedetail.defineColumn("rownum", typeof(int),false);
	testimatedetail.defineColumn("yestim", typeof(short),false);
	testimatedetail.defineColumn("annotations", typeof(string));
	testimatedetail.defineColumn("ct", typeof(DateTime),false);
	testimatedetail.defineColumn("cu", typeof(string),false);
	testimatedetail.defineColumn("detaildescription", typeof(string));
	testimatedetail.defineColumn("discount", typeof(double));
	testimatedetail.defineColumn("idinc_iva", typeof(int));
	testimatedetail.defineColumn("idinc_taxable", typeof(int));
	testimatedetail.defineColumn("idsor1", typeof(int));
	testimatedetail.defineColumn("idsor2", typeof(int));
	testimatedetail.defineColumn("idsor3", typeof(int));
	testimatedetail.defineColumn("idupb", typeof(string));
	testimatedetail.defineColumn("lt", typeof(DateTime),false);
	testimatedetail.defineColumn("lu", typeof(string),false);
	testimatedetail.defineColumn("ninvoiced", typeof(decimal));
	testimatedetail.defineColumn("number", typeof(decimal));
	testimatedetail.defineColumn("start", typeof(DateTime));
	testimatedetail.defineColumn("stop", typeof(DateTime));
	testimatedetail.defineColumn("tax", typeof(decimal));
	testimatedetail.defineColumn("taxable", typeof(decimal));
	testimatedetail.defineColumn("taxrate", typeof(double));
	testimatedetail.defineColumn("toinvoice", typeof(string));
	testimatedetail.defineColumn("idaccmotive", typeof(string));
	testimatedetail.defineColumn("idivakind", typeof(int));
	testimatedetail.defineColumn("!totaleriga", typeof(decimal));
	testimatedetail.defineColumn("idreg", typeof(int));
	testimatedetail.defineColumn("idgroup", typeof(int));
	testimatedetail.defineColumn("competencystart", typeof(DateTime));
	testimatedetail.defineColumn("competencystop", typeof(DateTime));
	testimatedetail.defineColumn("idaccmotiveannulment", typeof(string));
	testimatedetail.defineColumn("!registry", typeof(string));
	testimatedetail.defineColumn("!codeupb", typeof(string));
	testimatedetail.defineColumn("!tipoiva", typeof(string));
	testimatedetail.defineColumn("!imponibile", typeof(decimal));
	testimatedetail.defineColumn("!iva", typeof(decimal));
	testimatedetail.defineColumn("epkind", typeof(string));
	testimatedetail.defineColumn("idrevenuepartition", typeof(int));
	testimatedetail.defineColumn("idupb_iva", typeof(string));
	testimatedetail.defineColumn("idepacc", typeof(int));
	testimatedetail.defineColumn("idlist", typeof(int));
	testimatedetail.defineColumn("cigcode", typeof(string));
	testimatedetail.defineColumn("idfinmotive", typeof(string));
	testimatedetail.defineColumn("iduniqueformcode", typeof(string));
	testimatedetail.defineColumn("nform", typeof(string));
	testimatedetail.defineColumn("flag", typeof(int));
	testimatedetail.defineColumn("proceedsexpiring", typeof(DateTime));
	testimatedetail.defineColumn("idsor_siope", typeof(int));
	testimatedetail.defineColumn("idepacc_pre", typeof(int));
	Tables.Add(testimatedetail);
	testimatedetail.defineKey("idestimkind", "nestim", "rownum", "yestim");

	//////////////////// MANAGER /////////////////////////////////
	var tmanager= new MetaTable("manager");
	tmanager.defineColumn("idman", typeof(int),false);
	tmanager.defineColumn("active", typeof(string));
	tmanager.defineColumn("ct", typeof(DateTime),false);
	tmanager.defineColumn("cu", typeof(string),false);
	tmanager.defineColumn("email", typeof(string));
	tmanager.defineColumn("iddivision", typeof(int),false);
	tmanager.defineColumn("lt", typeof(DateTime),false);
	tmanager.defineColumn("lu", typeof(string),false);
	tmanager.defineColumn("passwordweb", typeof(string));
	tmanager.defineColumn("phonenumber", typeof(string));
	tmanager.defineColumn("rtf", typeof(Byte[]));
	tmanager.defineColumn("title", typeof(string),false);
	tmanager.defineColumn("txt", typeof(string));
	tmanager.defineColumn("userweb", typeof(string));
	tmanager.defineColumn("idsor01", typeof(int));
	tmanager.defineColumn("idsor02", typeof(int));
	tmanager.defineColumn("idsor03", typeof(int));
	tmanager.defineColumn("idsor04", typeof(int));
	tmanager.defineColumn("idsor05", typeof(int));
	Tables.Add(tmanager);
	tmanager.defineKey("idman");

	//////////////////// ESTIMATEKIND /////////////////////////////////
	var testimatekind= new MetaTable("estimatekind");
	testimatekind.defineColumn("idestimkind", typeof(string),false);
	testimatekind.defineColumn("active", typeof(string));
	testimatekind.defineColumn("ct", typeof(DateTime),false);
	testimatekind.defineColumn("cu", typeof(string),false);
	testimatekind.defineColumn("description", typeof(string),false);
	testimatekind.defineColumn("idupb", typeof(string));
	testimatekind.defineColumn("lt", typeof(DateTime),false);
	testimatekind.defineColumn("lu", typeof(string),false);
	testimatekind.defineColumn("rtf", typeof(Byte[]));
	testimatekind.defineColumn("txt", typeof(string));
	testimatekind.defineColumn("email", typeof(string));
	testimatekind.defineColumn("faxnumber", typeof(string));
	testimatekind.defineColumn("office", typeof(string));
	testimatekind.defineColumn("phonenumber", typeof(string));
	testimatekind.defineColumn("linktoinvoice", typeof(string));
	testimatekind.defineColumn("multireg", typeof(string));
	testimatekind.defineColumn("flag_autodocnumbering", typeof(string));
	testimatekind.defineColumn("idsor01", typeof(int));
	testimatekind.defineColumn("idsor02", typeof(int));
	testimatekind.defineColumn("idsor03", typeof(int));
	testimatekind.defineColumn("idsor04", typeof(int));
	testimatekind.defineColumn("idsor05", typeof(int));
	testimatekind.defineColumn("idivakind_forced", typeof(int));
	testimatekind.defineColumn("flag", typeof(int));
	Tables.Add(testimatekind);
	testimatekind.defineKey("idestimkind");

	//////////////////// CURRENCY /////////////////////////////////
	var tcurrency= new MetaTable("currency");
	tcurrency.defineColumn("idcurrency", typeof(int),false);
	tcurrency.defineColumn("codecurrency", typeof(string));
	tcurrency.defineColumn("ct", typeof(DateTime),false);
	tcurrency.defineColumn("cu", typeof(string),false);
	tcurrency.defineColumn("description", typeof(string),false);
	tcurrency.defineColumn("lt", typeof(DateTime),false);
	tcurrency.defineColumn("lu", typeof(string),false);
	Tables.Add(tcurrency);
	tcurrency.defineKey("idcurrency");

	//////////////////// EXPIRATIONKIND /////////////////////////////////
	var texpirationkind= new MetaTable("expirationkind");
	texpirationkind.defineColumn("idexpirationkind", typeof(short),false);
	texpirationkind.defineColumn("active", typeof(string));
	texpirationkind.defineColumn("description", typeof(string),false);
	texpirationkind.defineColumn("lt", typeof(DateTime));
	texpirationkind.defineColumn("lu", typeof(string));
	Tables.Add(texpirationkind);
	texpirationkind.defineKey("idexpirationkind");

	//////////////////// ESTIMATESORTING /////////////////////////////////
	var testimatesorting= new MetaTable("estimatesorting");
	testimatesorting.defineColumn("idsor", typeof(int),false);
	testimatesorting.defineColumn("idestimkind", typeof(string),false);
	testimatesorting.defineColumn("yestim", typeof(short),false);
	testimatesorting.defineColumn("nestim", typeof(int),false);
	testimatesorting.defineColumn("ct", typeof(DateTime),false);
	testimatesorting.defineColumn("cu", typeof(string),false);
	testimatesorting.defineColumn("lt", typeof(DateTime),false);
	testimatesorting.defineColumn("lu", typeof(string),false);
	testimatesorting.defineColumn("!sortingkind", typeof(string));
	testimatesorting.defineColumn("!codiceclass", typeof(string));
	testimatesorting.defineColumn("!descrizione", typeof(string));
	testimatesorting.defineColumn("quota", typeof(double));
	Tables.Add(testimatesorting);
	testimatesorting.defineKey("idestimkind", "idsor", "nestim", "yestim");

	//////////////////// INVOICEDETAIL /////////////////////////////////
	var tinvoicedetail= new MetaTable("invoicedetail");
	tinvoicedetail.defineColumn("idinvkind", typeof(int),false);
	tinvoicedetail.defineColumn("ninv", typeof(int),false);
	tinvoicedetail.defineColumn("rownum", typeof(int),false);
	tinvoicedetail.defineColumn("yinv", typeof(short),false);
	tinvoicedetail.defineColumn("annotations", typeof(string));
	tinvoicedetail.defineColumn("competencystart", typeof(DateTime));
	tinvoicedetail.defineColumn("competencystop", typeof(DateTime));
	tinvoicedetail.defineColumn("ct", typeof(DateTime),false);
	tinvoicedetail.defineColumn("cu", typeof(string),false);
	tinvoicedetail.defineColumn("detaildescription", typeof(string));
	tinvoicedetail.defineColumn("discount", typeof(double));
	tinvoicedetail.defineColumn("idaccmotive", typeof(string));
	tinvoicedetail.defineColumn("idivakind", typeof(int),false);
	tinvoicedetail.defineColumn("idmankind", typeof(string));
	tinvoicedetail.defineColumn("idsor1", typeof(int));
	tinvoicedetail.defineColumn("idsor2", typeof(int));
	tinvoicedetail.defineColumn("idsor3", typeof(int));
	tinvoicedetail.defineColumn("idupb", typeof(string));
	tinvoicedetail.defineColumn("lt", typeof(DateTime),false);
	tinvoicedetail.defineColumn("lu", typeof(string),false);
	tinvoicedetail.defineColumn("manrownum", typeof(int));
	tinvoicedetail.defineColumn("nman", typeof(int));
	tinvoicedetail.defineColumn("number", typeof(decimal));
	tinvoicedetail.defineColumn("tax", typeof(decimal));
	tinvoicedetail.defineColumn("taxable", typeof(decimal));
	tinvoicedetail.defineColumn("unabatable", typeof(decimal));
	tinvoicedetail.defineColumn("yman", typeof(short));
	tinvoicedetail.defineColumn("idestimkind", typeof(string));
	tinvoicedetail.defineColumn("estimrownum", typeof(int));
	tinvoicedetail.defineColumn("nestim", typeof(int));
	tinvoicedetail.defineColumn("yestim", typeof(short));
	tinvoicedetail.defineColumn("idexp_iva", typeof(int));
	tinvoicedetail.defineColumn("idexp_taxable", typeof(int));
	tinvoicedetail.defineColumn("idinc_iva", typeof(int));
	tinvoicedetail.defineColumn("idinc_taxable", typeof(int));
	tinvoicedetail.defineColumn("idgroup", typeof(int));
	tinvoicedetail.defineColumn("idsor_siope", typeof(int));
	Tables.Add(tinvoicedetail);
	tinvoicedetail.defineKey("idinvkind", "ninv", "rownum", "yinv");

	//////////////////// REGISTRYMAINVIEW /////////////////////////////////
	var tregistrymainview= new MetaTable("registrymainview");
	tregistrymainview.defineColumn("idreg", typeof(int),false);
	tregistrymainview.defineColumn("title", typeof(string),false);
	tregistrymainview.defineColumn("idregistryclass", typeof(string));
	tregistrymainview.defineColumn("registryclass", typeof(string));
	tregistrymainview.defineColumn("surname", typeof(string));
	tregistrymainview.defineColumn("forename", typeof(string));
	tregistrymainview.defineColumn("cf", typeof(string));
	tregistrymainview.defineColumn("p_iva", typeof(string));
	tregistrymainview.defineColumn("residence", typeof(int),false);
	tregistrymainview.defineColumn("residencekind", typeof(string));
	tregistrymainview.defineColumn("annotation", typeof(string));
	tregistrymainview.defineColumn("birthdate", typeof(DateTime));
	tregistrymainview.defineColumn("idcity", typeof(int));
	tregistrymainview.defineColumn("city", typeof(string));
	tregistrymainview.defineColumn("gender", typeof(string));
	tregistrymainview.defineColumn("foreigncf", typeof(string));
	tregistrymainview.defineColumn("idtitle", typeof(string));
	tregistrymainview.defineColumn("qualification", typeof(string));
	tregistrymainview.defineColumn("idmaritalstatus", typeof(string));
	tregistrymainview.defineColumn("maritalstatus", typeof(string));
	tregistrymainview.defineColumn("sortcode", typeof(string));
	tregistrymainview.defineColumn("registrykind", typeof(string));
	tregistrymainview.defineColumn("human", typeof(string));
	tregistrymainview.defineColumn("active", typeof(string),false);
	tregistrymainview.defineColumn("badgecode", typeof(string));
	tregistrymainview.defineColumn("maritalsurname", typeof(string));
	tregistrymainview.defineColumn("idcategory", typeof(string));
	tregistrymainview.defineColumn("extmatricula", typeof(string));
	tregistrymainview.defineColumn("idcentralizedcategory", typeof(string));
	tregistrymainview.defineColumn("cu", typeof(string),false);
	tregistrymainview.defineColumn("ct", typeof(DateTime),false);
	tregistrymainview.defineColumn("lu", typeof(string),false);
	tregistrymainview.defineColumn("lt", typeof(DateTime),false);
	tregistrymainview.defineColumn("location", typeof(string));
	tregistrymainview.defineColumn("idnation", typeof(int));
	tregistrymainview.defineColumn("nation", typeof(string));
	tregistrymainview.defineColumn("idaccmotivecredit", typeof(string));
	Tables.Add(tregistrymainview);
	tregistrymainview.defineKey("idreg");

	//////////////////// CONFIG /////////////////////////////////
	var tconfig= new MetaTable("config");
	tconfig.defineColumn("ayear", typeof(short),false);
	tconfig.defineColumn("agencycode", typeof(string));
	tconfig.defineColumn("appname", typeof(string));
	tconfig.defineColumn("appropriationphasecode", typeof(byte));
	tconfig.defineColumn("assessmentphasecode", typeof(byte));
	tconfig.defineColumn("asset_flagnumbering", typeof(string));
	tconfig.defineColumn("asset_flagrestart", typeof(string));
	tconfig.defineColumn("assetload_flag", typeof(byte));
	tconfig.defineColumn("boxpartitiontitle", typeof(string));
	tconfig.defineColumn("cashvaliditykind", typeof(byte));
	tconfig.defineColumn("casualcontract_flagrestart", typeof(string));
	tconfig.defineColumn("ct", typeof(DateTime),false);
	tconfig.defineColumn("cu", typeof(string),false);
	tconfig.defineColumn("currpartitiontitle", typeof(string));
	tconfig.defineColumn("deferredexpensephase", typeof(string));
	tconfig.defineColumn("deferredincomephase", typeof(string));
	tconfig.defineColumn("electronicimport", typeof(string));
	tconfig.defineColumn("electronictrasmission", typeof(string));
	tconfig.defineColumn("expense_expiringdays", typeof(short));
	tconfig.defineColumn("expensephase", typeof(byte));
	tconfig.defineColumn("flagautopayment", typeof(string));
	tconfig.defineColumn("flagautoproceeds", typeof(string));
	tconfig.defineColumn("flagcredit", typeof(string));
	tconfig.defineColumn("flagepexp", typeof(string));
	tconfig.defineColumn("flagfruitful", typeof(string));
	tconfig.defineColumn("flagpayment", typeof(string));
	tconfig.defineColumn("flagproceeds", typeof(string));
	tconfig.defineColumn("flagrefund", typeof(string));
	tconfig.defineColumn("foreignhours", typeof(int));
	tconfig.defineColumn("idacc_accruedcost", typeof(string));
	tconfig.defineColumn("idacc_accruedrevenue", typeof(string));
	tconfig.defineColumn("idacc_customer", typeof(string));
	tconfig.defineColumn("idacc_deferredcost", typeof(string));
	tconfig.defineColumn("idacc_deferredcredit", typeof(string));
	tconfig.defineColumn("idacc_deferreddebit", typeof(string));
	tconfig.defineColumn("idacc_deferredrevenue", typeof(string));
	tconfig.defineColumn("idacc_ivapayment", typeof(string));
	tconfig.defineColumn("idacc_ivarefund", typeof(string));
	tconfig.defineColumn("idacc_patrimony", typeof(string));
	tconfig.defineColumn("idacc_pl", typeof(string));
	tconfig.defineColumn("idacc_supplier", typeof(string));
	tconfig.defineColumn("idaccmotive_admincar", typeof(string));
	tconfig.defineColumn("idaccmotive_foot", typeof(string));
	tconfig.defineColumn("idaccmotive_owncar", typeof(string));
	tconfig.defineColumn("idclawback", typeof(int));
	tconfig.defineColumn("idfinexpense", typeof(int));
	tconfig.defineColumn("idfinexpensesurplus", typeof(int));
	tconfig.defineColumn("idfinincomesurplus", typeof(int));
	tconfig.defineColumn("idfinivapayment", typeof(int));
	tconfig.defineColumn("idfinivarefund", typeof(int));
	tconfig.defineColumn("idivapayperiodicity", typeof(int));
	tconfig.defineColumn("idregauto", typeof(int));
	tconfig.defineColumn("idsortingkind1", typeof(int));
	tconfig.defineColumn("idsortingkind2", typeof(int));
	tconfig.defineColumn("idsortingkind3", typeof(int));
	tconfig.defineColumn("importappname", typeof(string));
	tconfig.defineColumn("income_expiringdays", typeof(short));
	tconfig.defineColumn("incomephase", typeof(byte));
	tconfig.defineColumn("linktoinvoice", typeof(string));
	tconfig.defineColumn("lt", typeof(DateTime),false);
	tconfig.defineColumn("lu", typeof(string),false);
	tconfig.defineColumn("minpayment", typeof(decimal));
	tconfig.defineColumn("minrefund", typeof(decimal));
	tconfig.defineColumn("motivelen", typeof(short));
	tconfig.defineColumn("motiveprefix", typeof(string));
	tconfig.defineColumn("motiveseparator", typeof(string));
	tconfig.defineColumn("payment_finlevel", typeof(byte));
	tconfig.defineColumn("payment_flag", typeof(byte));
	tconfig.defineColumn("payment_flagautoprintdate", typeof(string));
	tconfig.defineColumn("paymentagency", typeof(int));
	tconfig.defineColumn("prevpartitiontitle", typeof(string));
	tconfig.defineColumn("proceeds_finlevel", typeof(byte));
	tconfig.defineColumn("proceeds_flag", typeof(byte));
	tconfig.defineColumn("proceeds_flagautoprintdate", typeof(string));
	tconfig.defineColumn("profservice_flagrestart", typeof(string));
	tconfig.defineColumn("refundagency", typeof(int));
	tconfig.defineColumn("wageaddition_flagrestart", typeof(string));
	tconfig.defineColumn("flag_autodocnumbering", typeof(int));
	Tables.Add(tconfig);
	tconfig.defineKey("ayear");

	//////////////////// INCOMEVAR /////////////////////////////////
	var tincomevar= new MetaTable("incomevar");
	tincomevar.defineColumn("nvar", typeof(int),false);
	tincomevar.defineColumn("adate", typeof(DateTime),false);
	tincomevar.defineColumn("amount", typeof(decimal));
	tincomevar.defineColumn("ct", typeof(DateTime),false);
	tincomevar.defineColumn("cu", typeof(string),false);
	tincomevar.defineColumn("description", typeof(string),false);
	tincomevar.defineColumn("doc", typeof(string));
	tincomevar.defineColumn("docdate", typeof(DateTime));
	tincomevar.defineColumn("lt", typeof(DateTime),false);
	tincomevar.defineColumn("lu", typeof(string),false);
	tincomevar.defineColumn("rtf", typeof(Byte[]));
	tincomevar.defineColumn("transferkind", typeof(string));
	tincomevar.defineColumn("txt", typeof(string));
	tincomevar.defineColumn("yvar", typeof(short),false);
	tincomevar.defineColumn("ninv", typeof(int));
	tincomevar.defineColumn("yinv", typeof(short));
	tincomevar.defineColumn("idinc", typeof(int),false);
	tincomevar.defineColumn("autokind", typeof(byte));
	tincomevar.defineColumn("idinvkind", typeof(int));
	tincomevar.defineColumn("movkind", typeof(short));
	Tables.Add(tincomevar);
	tincomevar.defineKey("nvar", "idinc");

	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new MetaTable("registry");
	tregistry.defineColumn("idreg", typeof(int),false);
	tregistry.defineColumn("title", typeof(string),false);
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// UPB_DETAIL /////////////////////////////////
	var tupb_detail= new MetaTable("upb_detail");
	tupb_detail.defineColumn("idupb", typeof(string),false);
	tupb_detail.defineColumn("codeupb", typeof(string),false);
	Tables.Add(tupb_detail);
	tupb_detail.defineKey("idupb");

	//////////////////// INCOMESORTED /////////////////////////////////
	var tincomesorted= new MetaTable("incomesorted");
	tincomesorted.defineColumn("idsubclass", typeof(short),false);
	tincomesorted.defineColumn("amount", typeof(decimal));
	tincomesorted.defineColumn("ayear", typeof(short));
	tincomesorted.defineColumn("ct", typeof(DateTime),false);
	tincomesorted.defineColumn("cu", typeof(string),false);
	tincomesorted.defineColumn("description", typeof(string));
	tincomesorted.defineColumn("flagnodate", typeof(string));
	tincomesorted.defineColumn("lt", typeof(DateTime),false);
	tincomesorted.defineColumn("lu", typeof(string),false);
	tincomesorted.defineColumn("paridsor", typeof(int));
	tincomesorted.defineColumn("paridsubclass", typeof(short));
	tincomesorted.defineColumn("rtf", typeof(Byte[]));
	tincomesorted.defineColumn("start", typeof(DateTime));
	tincomesorted.defineColumn("stop", typeof(DateTime));
	tincomesorted.defineColumn("tobecontinued", typeof(string));
	tincomesorted.defineColumn("txt", typeof(string));
	tincomesorted.defineColumn("valuen1", typeof(decimal));
	tincomesorted.defineColumn("valuen2", typeof(decimal));
	tincomesorted.defineColumn("valuen3", typeof(decimal));
	tincomesorted.defineColumn("valuen4", typeof(decimal));
	tincomesorted.defineColumn("valuen5", typeof(decimal));
	tincomesorted.defineColumn("values1", typeof(string));
	tincomesorted.defineColumn("values2", typeof(string));
	tincomesorted.defineColumn("values3", typeof(string));
	tincomesorted.defineColumn("values4", typeof(string));
	tincomesorted.defineColumn("values5", typeof(string));
	tincomesorted.defineColumn("valuev1", typeof(decimal));
	tincomesorted.defineColumn("valuev2", typeof(decimal));
	tincomesorted.defineColumn("valuev3", typeof(decimal));
	tincomesorted.defineColumn("valuev4", typeof(decimal));
	tincomesorted.defineColumn("valuev5", typeof(decimal));
	tincomesorted.defineColumn("idinc", typeof(int),false);
	tincomesorted.defineColumn("idsor", typeof(int),false);
	Tables.Add(tincomesorted);
	tincomesorted.defineKey("idsubclass", "idinc", "idsor");

	//////////////////// ACCMOTIVEAPPLIED_CREDIT /////////////////////////////////
	var taccmotiveapplied_credit= new MetaTable("accmotiveapplied_credit");
	taccmotiveapplied_credit.defineColumn("idaccmotive", typeof(string),false);
	taccmotiveapplied_credit.defineColumn("paridaccmotive", typeof(string));
	taccmotiveapplied_credit.defineColumn("codemotive", typeof(string),false);
	taccmotiveapplied_credit.defineColumn("motive", typeof(string),false);
	taccmotiveapplied_credit.defineColumn("cu", typeof(string),false);
	taccmotiveapplied_credit.defineColumn("ct", typeof(DateTime),false);
	taccmotiveapplied_credit.defineColumn("lu", typeof(string),false);
	taccmotiveapplied_credit.defineColumn("lt", typeof(DateTime),false);
	taccmotiveapplied_credit.defineColumn("active", typeof(string));
	taccmotiveapplied_credit.defineColumn("idepoperation", typeof(string));
	taccmotiveapplied_credit.defineColumn("epoperation", typeof(string));
	taccmotiveapplied_credit.defineColumn("in_use", typeof(string),false);
	taccmotiveapplied_credit.defineColumn("flagdep", typeof(string));
	taccmotiveapplied_credit.defineColumn("flagamm", typeof(string));
	Tables.Add(taccmotiveapplied_credit);
	taccmotiveapplied_credit.defineKey("idaccmotive");

	//////////////////// ACCMOTIVEAPPLIED_CRG /////////////////////////////////
	var taccmotiveapplied_crg= new MetaTable("accmotiveapplied_crg");
	taccmotiveapplied_crg.defineColumn("idaccmotive", typeof(string),false);
	taccmotiveapplied_crg.defineColumn("paridaccmotive", typeof(string));
	taccmotiveapplied_crg.defineColumn("codemotive", typeof(string),false);
	taccmotiveapplied_crg.defineColumn("motive", typeof(string),false);
	taccmotiveapplied_crg.defineColumn("cu", typeof(string),false);
	taccmotiveapplied_crg.defineColumn("ct", typeof(DateTime),false);
	taccmotiveapplied_crg.defineColumn("lu", typeof(string),false);
	taccmotiveapplied_crg.defineColumn("lt", typeof(DateTime),false);
	taccmotiveapplied_crg.defineColumn("active", typeof(string));
	taccmotiveapplied_crg.defineColumn("idepoperation", typeof(string));
	taccmotiveapplied_crg.defineColumn("epoperation", typeof(string));
	taccmotiveapplied_crg.defineColumn("in_use", typeof(string),false);
	taccmotiveapplied_crg.defineColumn("flagdep", typeof(string));
	taccmotiveapplied_crg.defineColumn("flagamm", typeof(string));
	Tables.Add(taccmotiveapplied_crg);
	taccmotiveapplied_crg.defineKey("idaccmotive");

	//////////////////// SORTINGVIEW /////////////////////////////////
	var tsortingview= new MetaTable("sortingview");
	tsortingview.defineColumn("sortingkind", typeof(string),false);
	tsortingview.defineColumn("idsor", typeof(int),false);
	tsortingview.defineColumn("sortcode", typeof(string),false);
	tsortingview.defineColumn("description", typeof(string),false);
	Tables.Add(tsortingview);
	tsortingview.defineKey("idsor");

	//////////////////// UNDERWRITING /////////////////////////////////
	var tunderwriting= new MetaTable("underwriting");
	tunderwriting.defineColumn("idunderwriting", typeof(int),false);
	tunderwriting.defineColumn("idunderwriter", typeof(int));
	tunderwriting.defineColumn("idsor01", typeof(int));
	tunderwriting.defineColumn("idsor02", typeof(int));
	tunderwriting.defineColumn("idsor03", typeof(int));
	tunderwriting.defineColumn("idsor04", typeof(int));
	tunderwriting.defineColumn("idsor05", typeof(int));
	tunderwriting.defineColumn("cu", typeof(string),false);
	tunderwriting.defineColumn("ct", typeof(DateTime),false);
	tunderwriting.defineColumn("lu", typeof(string),false);
	tunderwriting.defineColumn("lt", typeof(DateTime),false);
	tunderwriting.defineColumn("title", typeof(string),false);
	tunderwriting.defineColumn("active", typeof(string));
	tunderwriting.defineColumn("doc", typeof(string));
	tunderwriting.defineColumn("docdate", typeof(DateTime));
	Tables.Add(tunderwriting);
	tunderwriting.defineKey("idunderwriting");

	//////////////////// SORTING01 /////////////////////////////////
	var tsorting01= new MetaTable("sorting01");
	tsorting01.defineColumn("ct", typeof(DateTime),false);
	tsorting01.defineColumn("cu", typeof(string),false);
	tsorting01.defineColumn("defaultN1", typeof(decimal));
	tsorting01.defineColumn("defaultN2", typeof(decimal));
	tsorting01.defineColumn("defaultN3", typeof(decimal));
	tsorting01.defineColumn("defaultN4", typeof(decimal));
	tsorting01.defineColumn("defaultN5", typeof(decimal));
	tsorting01.defineColumn("defaultS1", typeof(string));
	tsorting01.defineColumn("defaultS2", typeof(string));
	tsorting01.defineColumn("defaultS3", typeof(string));
	tsorting01.defineColumn("defaultS4", typeof(string));
	tsorting01.defineColumn("defaultS5", typeof(string));
	tsorting01.defineColumn("defaultv1", typeof(decimal));
	tsorting01.defineColumn("defaultv2", typeof(decimal));
	tsorting01.defineColumn("defaultv3", typeof(decimal));
	tsorting01.defineColumn("defaultv4", typeof(decimal));
	tsorting01.defineColumn("defaultv5", typeof(decimal));
	tsorting01.defineColumn("description", typeof(string),false);
	tsorting01.defineColumn("flagnodate", typeof(string));
	tsorting01.defineColumn("lt", typeof(DateTime),false);
	tsorting01.defineColumn("lu", typeof(string),false);
	tsorting01.defineColumn("movkind", typeof(string));
	tsorting01.defineColumn("printingorder", typeof(string));
	tsorting01.defineColumn("rtf", typeof(Byte[]));
	tsorting01.defineColumn("sortcode", typeof(string),false);
	tsorting01.defineColumn("txt", typeof(string));
	tsorting01.defineColumn("idsorkind", typeof(int),false);
	tsorting01.defineColumn("idsor", typeof(int),false);
	tsorting01.defineColumn("paridsor", typeof(int));
	tsorting01.defineColumn("nlevel", typeof(byte),false);
	tsorting01.defineColumn("start", typeof(short));
	tsorting01.defineColumn("stop", typeof(short));
	Tables.Add(tsorting01);
	tsorting01.defineKey("idsor");

	//////////////////// SORTING02 /////////////////////////////////
	var tsorting02= new MetaTable("sorting02");
	tsorting02.defineColumn("ct", typeof(DateTime),false);
	tsorting02.defineColumn("cu", typeof(string),false);
	tsorting02.defineColumn("defaultN1", typeof(decimal));
	tsorting02.defineColumn("defaultN2", typeof(decimal));
	tsorting02.defineColumn("defaultN3", typeof(decimal));
	tsorting02.defineColumn("defaultN4", typeof(decimal));
	tsorting02.defineColumn("defaultN5", typeof(decimal));
	tsorting02.defineColumn("defaultS1", typeof(string));
	tsorting02.defineColumn("defaultS2", typeof(string));
	tsorting02.defineColumn("defaultS3", typeof(string));
	tsorting02.defineColumn("defaultS4", typeof(string));
	tsorting02.defineColumn("defaultS5", typeof(string));
	tsorting02.defineColumn("defaultv1", typeof(decimal));
	tsorting02.defineColumn("defaultv2", typeof(decimal));
	tsorting02.defineColumn("defaultv3", typeof(decimal));
	tsorting02.defineColumn("defaultv4", typeof(decimal));
	tsorting02.defineColumn("defaultv5", typeof(decimal));
	tsorting02.defineColumn("description", typeof(string),false);
	tsorting02.defineColumn("flagnodate", typeof(string));
	tsorting02.defineColumn("lt", typeof(DateTime),false);
	tsorting02.defineColumn("lu", typeof(string),false);
	tsorting02.defineColumn("movkind", typeof(string));
	tsorting02.defineColumn("printingorder", typeof(string));
	tsorting02.defineColumn("rtf", typeof(Byte[]));
	tsorting02.defineColumn("sortcode", typeof(string),false);
	tsorting02.defineColumn("txt", typeof(string));
	tsorting02.defineColumn("idsorkind", typeof(int),false);
	tsorting02.defineColumn("idsor", typeof(int),false);
	tsorting02.defineColumn("paridsor", typeof(int));
	tsorting02.defineColumn("nlevel", typeof(byte),false);
	tsorting02.defineColumn("start", typeof(short));
	tsorting02.defineColumn("stop", typeof(short));
	Tables.Add(tsorting02);
	tsorting02.defineKey("idsor");

	//////////////////// SORTING03 /////////////////////////////////
	var tsorting03= new MetaTable("sorting03");
	tsorting03.defineColumn("ct", typeof(DateTime),false);
	tsorting03.defineColumn("cu", typeof(string),false);
	tsorting03.defineColumn("defaultN1", typeof(decimal));
	tsorting03.defineColumn("defaultN2", typeof(decimal));
	tsorting03.defineColumn("defaultN3", typeof(decimal));
	tsorting03.defineColumn("defaultN4", typeof(decimal));
	tsorting03.defineColumn("defaultN5", typeof(decimal));
	tsorting03.defineColumn("defaultS1", typeof(string));
	tsorting03.defineColumn("defaultS2", typeof(string));
	tsorting03.defineColumn("defaultS3", typeof(string));
	tsorting03.defineColumn("defaultS4", typeof(string));
	tsorting03.defineColumn("defaultS5", typeof(string));
	tsorting03.defineColumn("defaultv1", typeof(decimal));
	tsorting03.defineColumn("defaultv2", typeof(decimal));
	tsorting03.defineColumn("defaultv3", typeof(decimal));
	tsorting03.defineColumn("defaultv4", typeof(decimal));
	tsorting03.defineColumn("defaultv5", typeof(decimal));
	tsorting03.defineColumn("description", typeof(string),false);
	tsorting03.defineColumn("flagnodate", typeof(string));
	tsorting03.defineColumn("lt", typeof(DateTime),false);
	tsorting03.defineColumn("lu", typeof(string),false);
	tsorting03.defineColumn("movkind", typeof(string));
	tsorting03.defineColumn("printingorder", typeof(string));
	tsorting03.defineColumn("rtf", typeof(Byte[]));
	tsorting03.defineColumn("sortcode", typeof(string),false);
	tsorting03.defineColumn("txt", typeof(string));
	tsorting03.defineColumn("idsorkind", typeof(int),false);
	tsorting03.defineColumn("idsor", typeof(int),false);
	tsorting03.defineColumn("paridsor", typeof(int));
	tsorting03.defineColumn("nlevel", typeof(byte),false);
	tsorting03.defineColumn("start", typeof(short));
	tsorting03.defineColumn("stop", typeof(short));
	Tables.Add(tsorting03);
	tsorting03.defineKey("idsor");

	//////////////////// SORTING04 /////////////////////////////////
	var tsorting04= new MetaTable("sorting04");
	tsorting04.defineColumn("ct", typeof(DateTime),false);
	tsorting04.defineColumn("cu", typeof(string),false);
	tsorting04.defineColumn("defaultN1", typeof(decimal));
	tsorting04.defineColumn("defaultN2", typeof(decimal));
	tsorting04.defineColumn("defaultN3", typeof(decimal));
	tsorting04.defineColumn("defaultN4", typeof(decimal));
	tsorting04.defineColumn("defaultN5", typeof(decimal));
	tsorting04.defineColumn("defaultS1", typeof(string));
	tsorting04.defineColumn("defaultS2", typeof(string));
	tsorting04.defineColumn("defaultS3", typeof(string));
	tsorting04.defineColumn("defaultS4", typeof(string));
	tsorting04.defineColumn("defaultS5", typeof(string));
	tsorting04.defineColumn("defaultv1", typeof(decimal));
	tsorting04.defineColumn("defaultv2", typeof(decimal));
	tsorting04.defineColumn("defaultv3", typeof(decimal));
	tsorting04.defineColumn("defaultv4", typeof(decimal));
	tsorting04.defineColumn("defaultv5", typeof(decimal));
	tsorting04.defineColumn("description", typeof(string),false);
	tsorting04.defineColumn("flagnodate", typeof(string));
	tsorting04.defineColumn("lt", typeof(DateTime),false);
	tsorting04.defineColumn("lu", typeof(string),false);
	tsorting04.defineColumn("movkind", typeof(string));
	tsorting04.defineColumn("printingorder", typeof(string));
	tsorting04.defineColumn("rtf", typeof(Byte[]));
	tsorting04.defineColumn("sortcode", typeof(string),false);
	tsorting04.defineColumn("txt", typeof(string));
	tsorting04.defineColumn("idsorkind", typeof(int),false);
	tsorting04.defineColumn("idsor", typeof(int),false);
	tsorting04.defineColumn("paridsor", typeof(int));
	tsorting04.defineColumn("nlevel", typeof(byte),false);
	tsorting04.defineColumn("start", typeof(short));
	tsorting04.defineColumn("stop", typeof(short));
	Tables.Add(tsorting04);
	tsorting04.defineKey("idsor");

	//////////////////// SORTING05 /////////////////////////////////
	var tsorting05= new MetaTable("sorting05");
	tsorting05.defineColumn("ct", typeof(DateTime),false);
	tsorting05.defineColumn("cu", typeof(string),false);
	tsorting05.defineColumn("defaultN1", typeof(decimal));
	tsorting05.defineColumn("defaultN2", typeof(decimal));
	tsorting05.defineColumn("defaultN3", typeof(decimal));
	tsorting05.defineColumn("defaultN4", typeof(decimal));
	tsorting05.defineColumn("defaultN5", typeof(decimal));
	tsorting05.defineColumn("defaultS1", typeof(string));
	tsorting05.defineColumn("defaultS2", typeof(string));
	tsorting05.defineColumn("defaultS3", typeof(string));
	tsorting05.defineColumn("defaultS4", typeof(string));
	tsorting05.defineColumn("defaultS5", typeof(string));
	tsorting05.defineColumn("defaultv1", typeof(decimal));
	tsorting05.defineColumn("defaultv2", typeof(decimal));
	tsorting05.defineColumn("defaultv3", typeof(decimal));
	tsorting05.defineColumn("defaultv4", typeof(decimal));
	tsorting05.defineColumn("defaultv5", typeof(decimal));
	tsorting05.defineColumn("description", typeof(string),false);
	tsorting05.defineColumn("flagnodate", typeof(string));
	tsorting05.defineColumn("lt", typeof(DateTime),false);
	tsorting05.defineColumn("lu", typeof(string),false);
	tsorting05.defineColumn("movkind", typeof(string));
	tsorting05.defineColumn("printingorder", typeof(string));
	tsorting05.defineColumn("rtf", typeof(Byte[]));
	tsorting05.defineColumn("sortcode", typeof(string),false);
	tsorting05.defineColumn("txt", typeof(string));
	tsorting05.defineColumn("idsorkind", typeof(int),false);
	tsorting05.defineColumn("idsor", typeof(int),false);
	tsorting05.defineColumn("paridsor", typeof(int));
	tsorting05.defineColumn("nlevel", typeof(byte),false);
	tsorting05.defineColumn("start", typeof(short));
	tsorting05.defineColumn("stop", typeof(short));
	Tables.Add(tsorting05);
	tsorting05.defineKey("idsor");

	//////////////////// IVAKIND /////////////////////////////////
	var tivakind= new MetaTable("ivakind");
	tivakind.defineColumn("description", typeof(string),false);
	tivakind.defineColumn("idivakind", typeof(int),false);
	Tables.Add(tivakind);
	tivakind.defineKey("idivakind");

	//////////////////// ESTIMATEDETAILVIEW /////////////////////////////////
	var testimatedetailview= new MetaTable("estimatedetailview");
	testimatedetailview.defineColumn("idestimkind", typeof(string),false);
	testimatedetailview.defineColumn("yestim", typeof(short),false);
	testimatedetailview.defineColumn("nestim", typeof(int),false);
	testimatedetailview.defineColumn("rownum", typeof(int),false);
	testimatedetailview.defineColumn("idgroup", typeof(int));
	testimatedetailview.defineColumn("estimkind", typeof(string),false);
	testimatedetailview.defineColumn("idreg", typeof(int));
	testimatedetailview.defineColumn("registry", typeof(string));
	testimatedetailview.defineColumn("detaildescription", typeof(string));
	testimatedetailview.defineColumn("annotations", typeof(string));
	testimatedetailview.defineColumn("number", typeof(decimal));
	testimatedetailview.defineColumn("taxable", typeof(decimal));
	testimatedetailview.defineColumn("taxrate", typeof(double));
	testimatedetailview.defineColumn("tax", typeof(decimal));
	testimatedetailview.defineColumn("discount", typeof(double));
	testimatedetailview.defineColumn("start", typeof(DateTime));
	testimatedetailview.defineColumn("stop", typeof(DateTime));
	testimatedetailview.defineColumn("competencystart", typeof(DateTime));
	testimatedetailview.defineColumn("competencystop", typeof(DateTime));
	testimatedetailview.defineColumn("idinc_taxable", typeof(int));
	testimatedetailview.defineColumn("idinc_iva", typeof(int));
	testimatedetailview.defineColumn("taxable_euro", typeof(decimal),true,true);
	testimatedetailview.defineColumn("iva_euro", typeof(decimal),true,true);
	testimatedetailview.defineColumn("rowtotal", typeof(decimal),true,true);
	testimatedetailview.defineColumn("idupb", typeof(string));
	testimatedetailview.defineColumn("codeupb", typeof(string));
	testimatedetailview.defineColumn("upb", typeof(string));
	testimatedetailview.defineColumn("cu", typeof(string),false);
	testimatedetailview.defineColumn("ct", typeof(DateTime),false);
	testimatedetailview.defineColumn("lu", typeof(string),false);
	testimatedetailview.defineColumn("lt", typeof(DateTime),false);
	testimatedetailview.defineColumn("idaccmotive", typeof(string));
	testimatedetailview.defineColumn("codemotive", typeof(string));
	testimatedetailview.defineColumn("idaccmotiveannulment", typeof(string));
	testimatedetailview.defineColumn("codemotiveannulment", typeof(string));
	testimatedetailview.defineColumn("idsor1", typeof(int));
	testimatedetailview.defineColumn("idsor2", typeof(int));
	testimatedetailview.defineColumn("idsor3", typeof(int));
	testimatedetailview.defineColumn("sortcode1", typeof(string));
	testimatedetailview.defineColumn("sortcode2", typeof(string));
	testimatedetailview.defineColumn("sortcode3", typeof(string));
	testimatedetailview.defineColumn("idivakind", typeof(int));
	testimatedetailview.defineColumn("ivakind", typeof(string));
	testimatedetailview.defineColumn("toinvoice", typeof(string));
	testimatedetailview.defineColumn("exchangerate", typeof(double));
	testimatedetailview.defineColumn("description", typeof(string),false);
	testimatedetailview.defineColumn("flagintracom", typeof(string));
	testimatedetailview.defineColumn("ninvoiced", typeof(decimal));
	testimatedetailview.defineColumn("idsor01", typeof(int),true,true);
	testimatedetailview.defineColumn("idsor02", typeof(int),true,true);
	testimatedetailview.defineColumn("idsor03", typeof(int),true,true);
	testimatedetailview.defineColumn("idsor04", typeof(int),true,true);
	testimatedetailview.defineColumn("idsor05", typeof(int),true,true);
	testimatedetailview.defineColumn("epkind", typeof(string));
	testimatedetailview.defineColumn("idrevenuepartition", typeof(int));
	testimatedetailview.defineColumn("idupb_iva", typeof(string));
	testimatedetailview.defineColumn("idepacc", typeof(int));
	testimatedetailview.defineColumn("idlist", typeof(int));
	testimatedetailview.defineColumn("intcode", typeof(string));
	testimatedetailview.defineColumn("list", typeof(string));
	testimatedetailview.defineColumn("cigcode", typeof(string));
	testimatedetailview.defineColumn("idfinmotive", typeof(string));
	testimatedetailview.defineColumn("iduniqueformcode", typeof(string));
	testimatedetailview.defineColumn("nform", typeof(string));
	testimatedetailview.defineColumn("flag", typeof(int));
	testimatedetailview.defineColumn("proceedsexpiring", typeof(DateTime));
	testimatedetailview.defineColumn("idsor_siope", typeof(int));
	testimatedetailview.defineColumn("idepacc_pre", typeof(int));
	Tables.Add(testimatedetailview);
	testimatedetailview.defineKey("idestimkind", "yestim", "nestim", "rownum");

	//////////////////// ESTIMATESORTINGVIEW /////////////////////////////////
	var testimatesortingview= new MetaTable("estimatesortingview");
	testimatesortingview.defineColumn("idestimkind", typeof(string),false);
	testimatesortingview.defineColumn("mankind", typeof(string),false);
	testimatesortingview.defineColumn("yestim", typeof(short),false);
	testimatesortingview.defineColumn("nestim", typeof(int),false);
	testimatesortingview.defineColumn("quota", typeof(double));
	testimatesortingview.defineColumn("idsor", typeof(int),false);
	testimatesortingview.defineColumn("sortingkind", typeof(string),false);
	testimatesortingview.defineColumn("sortcode", typeof(string),false);
	testimatesortingview.defineColumn("sorting", typeof(string),false);
	testimatesortingview.defineColumn("lt", typeof(DateTime),false);
	testimatesortingview.defineColumn("lu", typeof(string),false);
	testimatesortingview.defineColumn("ct", typeof(DateTime),false);
	testimatesortingview.defineColumn("cu", typeof(string),false);
	Tables.Add(testimatesortingview);
	testimatesortingview.defineKey("idestimkind", "yestim", "nestim", "idsor");

	//////////////////// ESTIMATEATTACHMENT /////////////////////////////////
	var testimateattachment= new MetaTable("estimateattachment");
	testimateattachment.defineColumn("idestimkind", typeof(string),false);
	testimateattachment.defineColumn("yestim", typeof(short),false);
	testimateattachment.defineColumn("nestim", typeof(int),false);
	testimateattachment.defineColumn("idattachment", typeof(int),false);
	testimateattachment.defineColumn("filename", typeof(string));
	testimateattachment.defineColumn("attachment", typeof(Byte[]));
	testimateattachment.defineColumn("lt", typeof(DateTime));
	testimateattachment.defineColumn("lu", typeof(string));
	testimateattachment.defineColumn("ct", typeof(DateTime));
	testimateattachment.defineColumn("cu", typeof(string));
	testimateattachment.defineColumn("!attachment", typeof(int));
	Tables.Add(testimateattachment);
	testimateattachment.defineKey("idestimkind", "yestim", "nestim", "idattachment");

	#endregion


	#region DataRelation creation
	var cPar = new []{estimate.Columns["idestimkind"], estimate.Columns["nestim"], estimate.Columns["yestim"]};
	var cChild = new []{invoicedetail.Columns["idestimkind"], invoicedetail.Columns["nestim"], invoicedetail.Columns["yestim"]};
	Relations.Add(new DataRelation("estimateinvoicedetail",cPar,cChild,false));

	cPar = new []{sortingview.Columns["idsor"]};
	cChild = new []{estimatesorting.Columns["idsor"]};
	Relations.Add(new DataRelation("FK_sortingview_estimatesorting",cPar,cChild,false));

	cPar = new []{estimate.Columns["idestimkind"], estimate.Columns["nestim"], estimate.Columns["yestim"]};
	cChild = new []{estimatesorting.Columns["idestimkind"], estimatesorting.Columns["nestim"], estimatesorting.Columns["yestim"]};
	Relations.Add(new DataRelation("estimateestimatesorting",cPar,cChild,false));

	cPar = new []{ivakind.Columns["idivakind"]};
	cChild = new []{estimatedetail.Columns["idivakind"]};
	Relations.Add(new DataRelation("FK_ivakind_estimatedetail",cPar,cChild,false));

	cPar = new []{estimate.Columns["idestimkind"], estimate.Columns["nestim"], estimate.Columns["yestim"]};
	cChild = new []{estimatedetail.Columns["idestimkind"], estimatedetail.Columns["nestim"], estimatedetail.Columns["yestim"]};
	Relations.Add(new DataRelation("estimateestimatedetail",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{estimatedetail.Columns["idreg"]};
	Relations.Add(new DataRelation("registry_estimatedetail",cPar,cChild,false));

	cPar = new []{upb_detail.Columns["idupb"]};
	cChild = new []{estimatedetail.Columns["idupb"]};
	Relations.Add(new DataRelation("upb_detail_estimatedetail",cPar,cChild,false));

	cPar = new []{underwriting.Columns["idunderwriting"]};
	cChild = new []{estimate.Columns["idunderwriting"]};
	Relations.Add(new DataRelation("FK_underwriting_estimate",cPar,cChild,false));

	cPar = new []{registrymainview.Columns["idreg"]};
	cChild = new []{estimate.Columns["idreg"]};
	Relations.Add(new DataRelation("registrymainviewestimate",cPar,cChild,false));

	cPar = new []{currency.Columns["idcurrency"]};
	cChild = new []{estimate.Columns["idcurrency"]};
	Relations.Add(new DataRelation("currencyestimate",cPar,cChild,false));

	cPar = new []{expirationkind.Columns["idexpirationkind"]};
	cChild = new []{estimate.Columns["idexpirationkind"]};
	Relations.Add(new DataRelation("expirationkindestimate",cPar,cChild,false));

	cPar = new []{manager.Columns["idman"]};
	cChild = new []{estimate.Columns["idman"]};
	Relations.Add(new DataRelation("managerestimate",cPar,cChild,false));

	cPar = new []{estimatekind.Columns["idestimkind"]};
	cChild = new []{estimate.Columns["idestimkind"]};
	Relations.Add(new DataRelation("estimatekindestimate",cPar,cChild,false));

	cPar = new []{accmotiveapplied_credit.Columns["idaccmotive"]};
	cChild = new []{estimate.Columns["idaccmotivecredit"]};
	Relations.Add(new DataRelation("accmotiveapplied_credit_estimate",cPar,cChild,false));

	cPar = new []{accmotiveapplied_crg.Columns["idaccmotive"]};
	cChild = new []{estimate.Columns["idaccmotivecredit_crg"]};
	Relations.Add(new DataRelation("accmotiveapplied_crg_estimate",cPar,cChild,false));

	cPar = new []{sorting01.Columns["idsor"]};
	cChild = new []{estimate.Columns["idsor01"]};
	Relations.Add(new DataRelation("sorting01_estimate",cPar,cChild,false));

	cPar = new []{sorting02.Columns["idsor"]};
	cChild = new []{estimate.Columns["idsor02"]};
	Relations.Add(new DataRelation("sorting02_estimate",cPar,cChild,false));

	cPar = new []{sorting03.Columns["idsor"]};
	cChild = new []{estimate.Columns["idsor03"]};
	Relations.Add(new DataRelation("sorting03_estimate",cPar,cChild,false));

	cPar = new []{sorting05.Columns["idsor"]};
	cChild = new []{estimate.Columns["idsor05"]};
	Relations.Add(new DataRelation("sorting05_estimate",cPar,cChild,false));

	cPar = new []{sorting04.Columns["idsor"]};
	cChild = new []{estimate.Columns["idsor04"]};
	Relations.Add(new DataRelation("sorting04_estimate",cPar,cChild,false));

	cPar = new []{estimate.Columns["idestimkind"], estimate.Columns["nestim"], estimate.Columns["yestim"]};
	cChild = new []{estimateattachment.Columns["idestimkind"], estimateattachment.Columns["nestim"], estimateattachment.Columns["yestim"]};
	Relations.Add(new DataRelation("estimate_estimateattachment",cPar,cChild,false));

	#endregion

}
}
}
