
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
using meta_registry;
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace csa_import_inail_maxphase {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable csa_import 		=> (MetaTable)Tables["csa_import"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable csa_importver 		=> (MetaTable)Tables["csa_importver"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public registryTable registry 		=> (registryTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry1 		=> (MetaTable)Tables["registry1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable expenseview 		=> (MetaTable)Tables["expenseview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable incomeview 		=> (MetaTable)Tables["incomeview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable csa_importver_partition 		=> (MetaTable)Tables["csa_importver_partition"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable csa_importver_partitionview 		=> (MetaTable)Tables["csa_importver_partitionview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable bill_netti 		=> (MetaTable)Tables["bill_netti"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable bill_versamenti 		=> (MetaTable)Tables["bill_versamenti"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable csa_bill 		=> (MetaTable)Tables["csa_bill"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_sospesi 		=> (MetaTable)Tables["registry_sospesi"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable bill_ripartizione 		=> (MetaTable)Tables["bill_ripartizione"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable billview 		=> (MetaTable)Tables["billview"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta.xsd";

	#region create DataTables
	//////////////////// CSA_IMPORT /////////////////////////////////
	var tcsa_import= new MetaTable("csa_import");
	tcsa_import.defineColumn("idcsa_import", typeof(int),false);
	tcsa_import.defineColumn("yimport", typeof(short),false);
	tcsa_import.defineColumn("nimport", typeof(int),false);
	tcsa_import.defineColumn("description", typeof(string),false);
	tcsa_import.defineColumn("adate", typeof(DateTime),false);
	tcsa_import.defineColumn("ybill_netti", typeof(short));
	tcsa_import.defineColumn("nbill_netti", typeof(int));
	tcsa_import.defineColumn("ybill_versamenti", typeof(short));
	tcsa_import.defineColumn("nbill_versamenti", typeof(int));
	tcsa_import.defineColumn("ct", typeof(DateTime),false);
	tcsa_import.defineColumn("cu", typeof(string),false);
	tcsa_import.defineColumn("lt", typeof(DateTime),false);
	tcsa_import.defineColumn("lu", typeof(string),false);
	Tables.Add(tcsa_import);
	tcsa_import.defineKey("idcsa_import");

	//////////////////// CSA_IMPORTVER /////////////////////////////////
	var tcsa_importver= new MetaTable("csa_importver");
	tcsa_importver.defineColumn("idcsa_import", typeof(int),false);
	tcsa_importver.defineColumn("idver", typeof(int),false);
	tcsa_importver.defineColumn("ruolocsa", typeof(string),false);
	tcsa_importver.defineColumn("capitolocsa", typeof(string),false);
	tcsa_importver.defineColumn("competenza", typeof(string),false);
	tcsa_importver.defineColumn("matricola", typeof(string),false);
	tcsa_importver.defineColumn("ente", typeof(string),false);
	tcsa_importver.defineColumn("vocecsa", typeof(string),false);
	tcsa_importver.defineColumn("importo", typeof(decimal),false);
	tcsa_importver.defineColumn("flagcr", typeof(string));
	tcsa_importver.defineColumn("ayear", typeof(int));
	tcsa_importver.defineColumn("idcsa_contractkind", typeof(int));
	tcsa_importver.defineColumn("idcsa_contract", typeof(int));
	tcsa_importver.defineColumn("idcsa_agency", typeof(int));
	tcsa_importver.defineColumn("idfin_income", typeof(int));
	tcsa_importver.defineColumn("idacc_debit", typeof(string));
	tcsa_importver.defineColumn("idfin_expense", typeof(int));
	tcsa_importver.defineColumn("idacc_expense", typeof(string));
	tcsa_importver.defineColumn("idfin_incomeclawback", typeof(int));
	tcsa_importver.defineColumn("idacc_internalcredit", typeof(string));
	tcsa_importver.defineColumn("idreg_agency", typeof(int));
	tcsa_importver.defineColumn("idcsa_agencypaymethod", typeof(int));
	tcsa_importver.defineColumn("idexp_cost", typeof(int));
	tcsa_importver.defineColumn("idfin_cost", typeof(int));
	tcsa_importver.defineColumn("idacc_cost", typeof(string));
	tcsa_importver.defineColumn("flagclawback", typeof(string));
	tcsa_importver.defineColumn("flagdirectcsaclawback", typeof(string));
	tcsa_importver.defineColumn("idreg", typeof(int));
	tcsa_importver.defineColumn("idupb", typeof(string));
	tcsa_importver.defineColumn("idcsa_contracttax", typeof(int));
	tcsa_importver.defineColumn("idcsa_contractkinddata", typeof(int));
	tcsa_importver.defineColumn("idcsa_incomesetup", typeof(int));
	tcsa_importver.defineColumn("lt", typeof(DateTime),false);
	tcsa_importver.defineColumn("lu", typeof(string),false);
	tcsa_importver.defineColumn("idepexp", typeof(int));
	tcsa_importver.defineColumn("idacc_revenue", typeof(string));
	tcsa_importver.defineColumn("idacc_agency_credit", typeof(string));
	tcsa_importver.defineColumn("idsor_siope_income", typeof(int));
	tcsa_importver.defineColumn("idsor_siope_expense", typeof(int));
	tcsa_importver.defineColumn("idsor_siope_incomeclawback", typeof(int));
	tcsa_importver.defineColumn("idsor_siope_cost", typeof(int));
	Tables.Add(tcsa_importver);
	tcsa_importver.defineKey("idcsa_import", "idver");

	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new registryTable();
	tregistry.addBaseColumns("idreg","active","annotation","badgecode","birthdate","cf","ct","cu","extmatricula","foreigncf","forename","gender","idcategory","idcentralizedcategory","idcity","idmaritalstatus","idnation","idregistryclass","idtitle","location","lt","lu","maritalsurname","p_iva","rtf","surname","title","txt","residence","idregistrykind","authorization_free","multi_cf","toredirect","idaccmotivedebit","idaccmotivecredit");
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// REGISTRY1 /////////////////////////////////
	var tregistry1= new MetaTable("registry1");
	tregistry1.defineColumn("idreg", typeof(int),false);
	tregistry1.defineColumn("active", typeof(string),false);
	tregistry1.defineColumn("annotation", typeof(string));
	tregistry1.defineColumn("badgecode", typeof(string));
	tregistry1.defineColumn("birthdate", typeof(DateTime));
	tregistry1.defineColumn("cf", typeof(string));
	tregistry1.defineColumn("ct", typeof(DateTime),false);
	tregistry1.defineColumn("cu", typeof(string),false);
	tregistry1.defineColumn("extmatricula", typeof(string));
	tregistry1.defineColumn("foreigncf", typeof(string));
	tregistry1.defineColumn("forename", typeof(string));
	tregistry1.defineColumn("gender", typeof(string));
	tregistry1.defineColumn("idcategory", typeof(string));
	tregistry1.defineColumn("idcentralizedcategory", typeof(string));
	tregistry1.defineColumn("idcity", typeof(int));
	tregistry1.defineColumn("idmaritalstatus", typeof(string));
	tregistry1.defineColumn("idnation", typeof(int));
	tregistry1.defineColumn("idregistryclass", typeof(string));
	tregistry1.defineColumn("idtitle", typeof(string));
	tregistry1.defineColumn("location", typeof(string));
	tregistry1.defineColumn("lt", typeof(DateTime),false);
	tregistry1.defineColumn("lu", typeof(string),false);
	tregistry1.defineColumn("maritalsurname", typeof(string));
	tregistry1.defineColumn("p_iva", typeof(string));
	tregistry1.defineColumn("rtf", typeof(Byte[]));
	tregistry1.defineColumn("surname", typeof(string));
	tregistry1.defineColumn("title", typeof(string),false);
	tregistry1.defineColumn("txt", typeof(string));
	tregistry1.defineColumn("residence", typeof(int),false);
	tregistry1.defineColumn("idregistrykind", typeof(int));
	tregistry1.defineColumn("authorization_free", typeof(string));
	tregistry1.defineColumn("multi_cf", typeof(string));
	tregistry1.defineColumn("toredirect", typeof(int));
	tregistry1.defineColumn("idaccmotivedebit", typeof(string));
	tregistry1.defineColumn("idaccmotivecredit", typeof(string));
	Tables.Add(tregistry1);
	tregistry1.defineKey("idreg");

	//////////////////// EXPENSEVIEW /////////////////////////////////
	var texpenseview= new MetaTable("expenseview");
	texpenseview.defineColumn("idexp", typeof(int),false);
	texpenseview.defineColumn("!livprecedente", typeof(string));
	texpenseview.defineColumn("nphase", typeof(byte));
	texpenseview.defineColumn("phase", typeof(string),false);
	texpenseview.defineColumn("ymov", typeof(short),false);
	texpenseview.defineColumn("nmov", typeof(int),false);
	texpenseview.defineColumn("parentidexp", typeof(int));
	texpenseview.defineColumn("parentymov", typeof(short));
	texpenseview.defineColumn("parentnmov", typeof(int));
	texpenseview.defineColumn("idformerexpense", typeof(int));
	texpenseview.defineColumn("ayear", typeof(short),false);
	texpenseview.defineColumn("idfin", typeof(int));
	texpenseview.defineColumn("codefin", typeof(string));
	texpenseview.defineColumn("finance", typeof(string));
	texpenseview.defineColumn("idupb", typeof(string));
	texpenseview.defineColumn("codeupb", typeof(string));
	texpenseview.defineColumn("upb", typeof(string));
	texpenseview.defineColumn("idreg", typeof(int));
	texpenseview.defineColumn("registry", typeof(string));
	texpenseview.defineColumn("idman", typeof(int));
	texpenseview.defineColumn("manager", typeof(string));
	texpenseview.defineColumn("ypay", typeof(short),true,true);
	texpenseview.defineColumn("npay", typeof(int));
	texpenseview.defineColumn("paymentadate", typeof(DateTime));
	texpenseview.defineColumn("doc", typeof(string));
	texpenseview.defineColumn("docdate", typeof(DateTime));
	texpenseview.defineColumn("description", typeof(string),false);
	texpenseview.defineColumn("amount", typeof(decimal));
	texpenseview.defineColumn("ayearstartamount", typeof(decimal));
	texpenseview.defineColumn("curramount", typeof(decimal));
	texpenseview.defineColumn("available", typeof(decimal));
	texpenseview.defineColumn("idregistrypaymethod", typeof(int));
	texpenseview.defineColumn("idpaymethod", typeof(int));
	texpenseview.defineColumn("iban", typeof(string));
	texpenseview.defineColumn("cin", typeof(string));
	texpenseview.defineColumn("idbank", typeof(string));
	texpenseview.defineColumn("idcab", typeof(string));
	texpenseview.defineColumn("cc", typeof(string));
	texpenseview.defineColumn("iddeputy", typeof(int));
	texpenseview.defineColumn("deputy", typeof(string));
	texpenseview.defineColumn("refexternaldoc", typeof(string));
	texpenseview.defineColumn("paymentdescr", typeof(string));
	texpenseview.defineColumn("idser", typeof(int));
	texpenseview.defineColumn("service", typeof(string));
	texpenseview.defineColumn("servicestart", typeof(DateTime));
	texpenseview.defineColumn("servicestop", typeof(DateTime));
	texpenseview.defineColumn("ivaamount", typeof(decimal));
	texpenseview.defineColumn("flag", typeof(byte));
	texpenseview.defineColumn("totflag", typeof(byte));
	texpenseview.defineColumn("flagarrear", typeof(string),true,true);
	texpenseview.defineColumn("autokind", typeof(byte));
	texpenseview.defineColumn("idpayment", typeof(int));
	texpenseview.defineColumn("expiration", typeof(DateTime));
	texpenseview.defineColumn("adate", typeof(DateTime),false);
	texpenseview.defineColumn("autocode", typeof(int));
	texpenseview.defineColumn("idclawback", typeof(int));
	texpenseview.defineColumn("clawback", typeof(string));
	texpenseview.defineColumn("nbill", typeof(int));
	texpenseview.defineColumn("idpay", typeof(int));
	texpenseview.defineColumn("txt", typeof(string));
	texpenseview.defineColumn("cu", typeof(string),false);
	texpenseview.defineColumn("ct", typeof(DateTime),false);
	texpenseview.defineColumn("lu", typeof(string),false);
	texpenseview.defineColumn("lt", typeof(DateTime),false);
	texpenseview.defineColumn("biccode", typeof(string));
	texpenseview.defineColumn("paymethod_flag", typeof(int));
	texpenseview.defineColumn("paymethod_allowdeputy", typeof(string));
	texpenseview.defineColumn("extracode", typeof(string));
	texpenseview.defineColumn("idchargehandling", typeof(int));
	Tables.Add(texpenseview);

	//////////////////// INCOMEVIEW /////////////////////////////////
	var tincomeview= new MetaTable("incomeview");
	tincomeview.defineColumn("idinc", typeof(int),false);
	tincomeview.defineColumn("!livprecedente", typeof(string));
	tincomeview.defineColumn("nphase", typeof(byte));
	tincomeview.defineColumn("phase", typeof(string),false);
	tincomeview.defineColumn("ymov", typeof(short),false);
	tincomeview.defineColumn("nmov", typeof(int),false);
	tincomeview.defineColumn("parentymov", typeof(short));
	tincomeview.defineColumn("parentnmov", typeof(int));
	tincomeview.defineColumn("parentidinc", typeof(int));
	tincomeview.defineColumn("ayear", typeof(short),false);
	tincomeview.defineColumn("idfin", typeof(int));
	tincomeview.defineColumn("codefin", typeof(string));
	tincomeview.defineColumn("finance", typeof(string));
	tincomeview.defineColumn("idupb", typeof(string));
	tincomeview.defineColumn("codeupb", typeof(string));
	tincomeview.defineColumn("upb", typeof(string));
	tincomeview.defineColumn("idreg", typeof(int));
	tincomeview.defineColumn("registry", typeof(string));
	tincomeview.defineColumn("idman", typeof(int));
	tincomeview.defineColumn("manager", typeof(string));
	tincomeview.defineColumn("ypro", typeof(short));
	tincomeview.defineColumn("npro", typeof(int));
	tincomeview.defineColumn("doc", typeof(string));
	tincomeview.defineColumn("docdate", typeof(DateTime));
	tincomeview.defineColumn("description", typeof(string),false);
	tincomeview.defineColumn("amount", typeof(decimal));
	tincomeview.defineColumn("ayearstartamount", typeof(decimal));
	tincomeview.defineColumn("curramount", typeof(decimal));
	tincomeview.defineColumn("available", typeof(decimal));
	tincomeview.defineColumn("unpartitioned", typeof(decimal));
	tincomeview.defineColumn("flag", typeof(byte));
	tincomeview.defineColumn("totflag", typeof(byte),false);
	tincomeview.defineColumn("flagarrear", typeof(string));
	tincomeview.defineColumn("autokind", typeof(byte));
	tincomeview.defineColumn("autocode", typeof(int));
	tincomeview.defineColumn("idpayment", typeof(int));
	tincomeview.defineColumn("expiration", typeof(DateTime));
	tincomeview.defineColumn("adate", typeof(DateTime),false);
	tincomeview.defineColumn("nbill", typeof(int));
	tincomeview.defineColumn("idpro", typeof(int));
	tincomeview.defineColumn("cu", typeof(string),false);
	tincomeview.defineColumn("ct", typeof(DateTime),false);
	tincomeview.defineColumn("lu", typeof(string),false);
	tincomeview.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(tincomeview);

	//////////////////// CSA_IMPORTVER_PARTITION /////////////////////////////////
	var tcsa_importver_partition= new MetaTable("csa_importver_partition");
	tcsa_importver_partition.defineColumn("idcsa_import", typeof(int),false);
	tcsa_importver_partition.defineColumn("idver", typeof(int),false);
	tcsa_importver_partition.defineColumn("ndetail", typeof(int),false);
	tcsa_importver_partition.defineColumn("idexp", typeof(int));
	tcsa_importver_partition.defineColumn("ct", typeof(DateTime));
	tcsa_importver_partition.defineColumn("cu", typeof(string));
	tcsa_importver_partition.defineColumn("lt", typeof(DateTime));
	tcsa_importver_partition.defineColumn("lu", typeof(string));
	tcsa_importver_partition.defineColumn("amount", typeof(decimal));
	tcsa_importver_partition.defineColumn("idupb", typeof(string));
	tcsa_importver_partition.defineColumn("idacc", typeof(string));
	tcsa_importver_partition.defineColumn("idfin", typeof(int));
	tcsa_importver_partition.defineColumn("idepexp", typeof(int));
	tcsa_importver_partition.defineColumn("idsor_siope", typeof(int));
	Tables.Add(tcsa_importver_partition);
	tcsa_importver_partition.defineKey("idcsa_import", "idver", "ndetail");

	//////////////////// CSA_IMPORTVER_PARTITIONVIEW /////////////////////////////////
	var tcsa_importver_partitionview= new MetaTable("csa_importver_partitionview");
	tcsa_importver_partitionview.defineColumn("ayear", typeof(short));
	tcsa_importver_partitionview.defineColumn("competency", typeof(int));
	tcsa_importver_partitionview.defineColumn("idcsa_import", typeof(int),false);
	tcsa_importver_partitionview.defineColumn("yimport", typeof(short),false);
	tcsa_importver_partitionview.defineColumn("nimport", typeof(int),false);
	tcsa_importver_partitionview.defineColumn("idver", typeof(int),false);
	tcsa_importver_partitionview.defineColumn("ndetail", typeof(int),false);
	tcsa_importver_partitionview.defineColumn("amount", typeof(decimal));
	tcsa_importver_partitionview.defineColumn("idcsa_contract", typeof(int));
	tcsa_importver_partitionview.defineColumn("ycontract", typeof(short));
	tcsa_importver_partitionview.defineColumn("ncontract", typeof(int));
	tcsa_importver_partitionview.defineColumn("idcsa_contractkind", typeof(int));
	tcsa_importver_partitionview.defineColumn("csa_contractkindcode", typeof(string));
	tcsa_importver_partitionview.defineColumn("csa_contractkind", typeof(string));
	tcsa_importver_partitionview.defineColumn("ruolocsa", typeof(string),false);
	tcsa_importver_partitionview.defineColumn("capitolocsa", typeof(string),false);
	tcsa_importver_partitionview.defineColumn("competenza", typeof(string),false);
	tcsa_importver_partitionview.defineColumn("matricola", typeof(string),false);
	tcsa_importver_partitionview.defineColumn("ente", typeof(string),false);
	tcsa_importver_partitionview.defineColumn("vocecsa", typeof(string),false);
	tcsa_importver_partitionview.defineColumn("vocecsaunified", typeof(string));
	tcsa_importver_partitionview.defineColumn("idreg", typeof(int));
	tcsa_importver_partitionview.defineColumn("registry", typeof(string));
	tcsa_importver_partitionview.defineColumn("idcsa_agency", typeof(int));
	tcsa_importver_partitionview.defineColumn("agency", typeof(string));
	tcsa_importver_partitionview.defineColumn("idreg_agency", typeof(int));
	tcsa_importver_partitionview.defineColumn("registry_agency", typeof(string));
	tcsa_importver_partitionview.defineColumn("idcsa_agencypaymethod", typeof(int));
	tcsa_importver_partitionview.defineColumn("idregistrypaymethod", typeof(int));
	tcsa_importver_partitionview.defineColumn("idcsa_contracttax", typeof(int));
	tcsa_importver_partitionview.defineColumn("idcsa_contractkinddata", typeof(int));
	tcsa_importver_partitionview.defineColumn("idcsa_incomesetup", typeof(int));
	tcsa_importver_partitionview.defineColumn("idacc_debit", typeof(string));
	tcsa_importver_partitionview.defineColumn("codeacc_debit", typeof(string));
	tcsa_importver_partitionview.defineColumn("account_debit", typeof(string));
	tcsa_importver_partitionview.defineColumn("idacc_expense", typeof(string));
	tcsa_importver_partitionview.defineColumn("codeacc_expense", typeof(string));
	tcsa_importver_partitionview.defineColumn("account_expense", typeof(string));
	tcsa_importver_partitionview.defineColumn("idacc_internalcredit", typeof(string));
	tcsa_importver_partitionview.defineColumn("codeacc_internalcredit", typeof(string));
	tcsa_importver_partitionview.defineColumn("account_internalcredit", typeof(string));
	tcsa_importver_partitionview.defineColumn("idacc_revenue", typeof(string));
	tcsa_importver_partitionview.defineColumn("codeacc_revenue", typeof(string));
	tcsa_importver_partitionview.defineColumn("account_revenue", typeof(string));
	tcsa_importver_partitionview.defineColumn("idacc_agency_credit", typeof(string));
	tcsa_importver_partitionview.defineColumn("codeacc_agency_credit", typeof(string));
	tcsa_importver_partitionview.defineColumn("account_agency_credit", typeof(string));
	tcsa_importver_partitionview.defineColumn("idfin_income", typeof(int));
	tcsa_importver_partitionview.defineColumn("codefin_income", typeof(string));
	tcsa_importver_partitionview.defineColumn("fin_income", typeof(string));
	tcsa_importver_partitionview.defineColumn("idfin_expense", typeof(int));
	tcsa_importver_partitionview.defineColumn("codefin_expense", typeof(string));
	tcsa_importver_partitionview.defineColumn("fin_expense", typeof(string));
	tcsa_importver_partitionview.defineColumn("idfin_incomeclawback", typeof(int));
	tcsa_importver_partitionview.defineColumn("codefin_incomeclawback", typeof(string));
	tcsa_importver_partitionview.defineColumn("fin_incomeclawback", typeof(string));
	tcsa_importver_partitionview.defineColumn("idsor_siope_income", typeof(int));
	tcsa_importver_partitionview.defineColumn("sortcode_income", typeof(string));
	tcsa_importver_partitionview.defineColumn("sorting_income", typeof(string));
	tcsa_importver_partitionview.defineColumn("idsor_siope_expense", typeof(int));
	tcsa_importver_partitionview.defineColumn("sortcode_expense", typeof(string));
	tcsa_importver_partitionview.defineColumn("sorting_expense", typeof(string));
	tcsa_importver_partitionview.defineColumn("idsor_siope_incomeclawback", typeof(int));
	tcsa_importver_partitionview.defineColumn("sortcode_incomeclawback", typeof(string));
	tcsa_importver_partitionview.defineColumn("sorting_incomeclawback", typeof(string));
	tcsa_importver_partitionview.defineColumn("idsor_siope_cost", typeof(int));
	tcsa_importver_partitionview.defineColumn("sortcode_cost", typeof(string));
	tcsa_importver_partitionview.defineColumn("sorting_cost", typeof(string));
	tcsa_importver_partitionview.defineColumn("idexp", typeof(int));
	tcsa_importver_partitionview.defineColumn("ymov", typeof(short));
	tcsa_importver_partitionview.defineColumn("nmov", typeof(int));
	tcsa_importver_partitionview.defineColumn("paridexp", typeof(int));
	tcsa_importver_partitionview.defineColumn("nphaseexpense", typeof(byte));
	tcsa_importver_partitionview.defineColumn("lu", typeof(string));
	tcsa_importver_partitionview.defineColumn("lt", typeof(DateTime));
	tcsa_importver_partitionview.defineColumn("cu", typeof(string));
	tcsa_importver_partitionview.defineColumn("ct", typeof(DateTime));
	tcsa_importver_partitionview.defineColumn("idepexp", typeof(int));
	tcsa_importver_partitionview.defineColumn("yepexp", typeof(short));
	tcsa_importver_partitionview.defineColumn("nepexp", typeof(int));
	tcsa_importver_partitionview.defineColumn("idrelated", typeof(string));
	tcsa_importver_partitionview.defineColumn("paridepexp", typeof(int));
	tcsa_importver_partitionview.defineColumn("nphaseepexp", typeof(short));
	tcsa_importver_partitionview.defineColumn("flagcr", typeof(string));
	tcsa_importver_partitionview.defineColumn("flagclawback", typeof(string));
	tcsa_importver_partitionview.defineColumn("flagdirectcsaclawback", typeof(string));
	tcsa_importver_partitionview.defineColumn("idunderwriting", typeof(int));
	tcsa_importver_partitionview.defineColumn("underwriting", typeof(string));
	tcsa_importver_partitionview.defineColumn("idupb", typeof(string));
	tcsa_importver_partitionview.defineColumn("codeupb", typeof(string));
	tcsa_importver_partitionview.defineColumn("upb", typeof(string));
	tcsa_importver_partitionview.defineColumn("idacc_cost", typeof(string));
	tcsa_importver_partitionview.defineColumn("codeacc_cost", typeof(string));
	tcsa_importver_partitionview.defineColumn("account_cost", typeof(string));
	tcsa_importver_partitionview.defineColumn("idfin", typeof(int));
	tcsa_importver_partitionview.defineColumn("codefin", typeof(string));
	tcsa_importver_partitionview.defineColumn("fin", typeof(string));
	tcsa_importver_partitionview.defineColumn("idsorkind", typeof(string));
	tcsa_importver_partitionview.defineColumn("codesorkind", typeof(string));
	tcsa_importver_partitionview.defineColumn("sortingkind", typeof(string));
	tcsa_importver_partitionview.defineColumn("idsor_siope", typeof(string));
	tcsa_importver_partitionview.defineColumn("sortcode_siope", typeof(string));
	tcsa_importver_partitionview.defineColumn("sorting_siope", typeof(string));
	Tables.Add(tcsa_importver_partitionview);
	tcsa_importver_partitionview.defineKey("idcsa_import", "ndetail", "idver");

	//////////////////// BILL_NETTI /////////////////////////////////
	var tbill_netti= new MetaTable("bill_netti");
	tbill_netti.defineColumn("ybill", typeof(short),false);
	tbill_netti.defineColumn("nbill", typeof(int),false);
	tbill_netti.defineColumn("billkind", typeof(string),false);
	tbill_netti.defineColumn("registry", typeof(string));
	tbill_netti.defineColumn("covered", typeof(decimal));
	tbill_netti.defineColumn("total", typeof(decimal));
	tbill_netti.defineColumn("adate", typeof(DateTime));
	tbill_netti.defineColumn("active", typeof(string));
	tbill_netti.defineColumn("motive", typeof(string));
	tbill_netti.defineColumn("ct", typeof(DateTime),false);
	tbill_netti.defineColumn("cu", typeof(string),false);
	tbill_netti.defineColumn("lt", typeof(DateTime),false);
	tbill_netti.defineColumn("lu", typeof(string),false);
	tbill_netti.defineColumn("idtreasurer", typeof(int));
	tbill_netti.defineColumn("regularizationnote", typeof(string));
	tbill_netti.defineColumn("reduction", typeof(decimal));
	tbill_netti.defineColumn("banknum", typeof(int));
	tbill_netti.defineColumn("idbank", typeof(string));
	Tables.Add(tbill_netti);
	tbill_netti.defineKey("ybill", "nbill", "billkind");

	//////////////////// BILL_VERSAMENTI /////////////////////////////////
	var tbill_versamenti= new MetaTable("bill_versamenti");
	tbill_versamenti.defineColumn("ybill", typeof(short),false);
	tbill_versamenti.defineColumn("nbill", typeof(int),false);
	tbill_versamenti.defineColumn("billkind", typeof(string),false);
	tbill_versamenti.defineColumn("registry", typeof(string));
	tbill_versamenti.defineColumn("covered", typeof(decimal));
	tbill_versamenti.defineColumn("total", typeof(decimal));
	tbill_versamenti.defineColumn("adate", typeof(DateTime));
	tbill_versamenti.defineColumn("active", typeof(string));
	tbill_versamenti.defineColumn("motive", typeof(string));
	tbill_versamenti.defineColumn("ct", typeof(DateTime),false);
	tbill_versamenti.defineColumn("cu", typeof(string),false);
	tbill_versamenti.defineColumn("lt", typeof(DateTime),false);
	tbill_versamenti.defineColumn("lu", typeof(string),false);
	tbill_versamenti.defineColumn("idtreasurer", typeof(int));
	tbill_versamenti.defineColumn("regularizationnote", typeof(string));
	tbill_versamenti.defineColumn("reduction", typeof(decimal));
	tbill_versamenti.defineColumn("banknum", typeof(int));
	tbill_versamenti.defineColumn("idbank", typeof(string));
	Tables.Add(tbill_versamenti);
	tbill_versamenti.defineKey("ybill", "nbill", "billkind");

	//////////////////// CSA_BILL /////////////////////////////////
	var tcsa_bill= new MetaTable("csa_bill");
	tcsa_bill.defineColumn("idcsa_import", typeof(int),false);
	tcsa_bill.defineColumn("idcsa_bill", typeof(int),false);
	tcsa_bill.defineColumn("idreg", typeof(int),false);
	tcsa_bill.defineColumn("nbill", typeof(int),false);
	tcsa_bill.defineColumn("amount", typeof(decimal),false);
	tcsa_bill.defineColumn("lt", typeof(DateTime));
	tcsa_bill.defineColumn("lu", typeof(string));
	tcsa_bill.defineColumn("ct", typeof(DateTime));
	tcsa_bill.defineColumn("cu", typeof(string));
	tcsa_bill.defineColumn("!registry", typeof(string));
	tcsa_bill.defineColumn("!motive", typeof(string));
	tcsa_bill.defineColumn("!datasospeso", typeof(string));
	Tables.Add(tcsa_bill);
	tcsa_bill.defineKey("idcsa_import", "idcsa_bill");

	//////////////////// REGISTRY_SOSPESI /////////////////////////////////
	var tregistry_sospesi= new MetaTable("registry_sospesi");
	tregistry_sospesi.defineColumn("idreg", typeof(int),false);
	tregistry_sospesi.defineColumn("active", typeof(string),false);
	tregistry_sospesi.defineColumn("annotation", typeof(string));
	tregistry_sospesi.defineColumn("badgecode", typeof(string));
	tregistry_sospesi.defineColumn("birthdate", typeof(DateTime));
	tregistry_sospesi.defineColumn("cf", typeof(string));
	tregistry_sospesi.defineColumn("ct", typeof(DateTime),false);
	tregistry_sospesi.defineColumn("cu", typeof(string),false);
	tregistry_sospesi.defineColumn("extmatricula", typeof(string));
	tregistry_sospesi.defineColumn("foreigncf", typeof(string));
	tregistry_sospesi.defineColumn("forename", typeof(string));
	tregistry_sospesi.defineColumn("gender", typeof(string));
	tregistry_sospesi.defineColumn("idcategory", typeof(string));
	tregistry_sospesi.defineColumn("idcentralizedcategory", typeof(string));
	tregistry_sospesi.defineColumn("idcity", typeof(int));
	tregistry_sospesi.defineColumn("idmaritalstatus", typeof(string));
	tregistry_sospesi.defineColumn("idnation", typeof(int));
	tregistry_sospesi.defineColumn("idregistryclass", typeof(string));
	tregistry_sospesi.defineColumn("idtitle", typeof(string));
	tregistry_sospesi.defineColumn("location", typeof(string));
	tregistry_sospesi.defineColumn("lt", typeof(DateTime),false);
	tregistry_sospesi.defineColumn("lu", typeof(string),false);
	tregistry_sospesi.defineColumn("maritalsurname", typeof(string));
	tregistry_sospesi.defineColumn("p_iva", typeof(string));
	tregistry_sospesi.defineColumn("rtf", typeof(Byte[]));
	tregistry_sospesi.defineColumn("surname", typeof(string));
	tregistry_sospesi.defineColumn("title", typeof(string),false);
	tregistry_sospesi.defineColumn("txt", typeof(string));
	tregistry_sospesi.defineColumn("residence", typeof(int),false);
	tregistry_sospesi.defineColumn("idregistrykind", typeof(int));
	tregistry_sospesi.defineColumn("authorization_free", typeof(string));
	tregistry_sospesi.defineColumn("multi_cf", typeof(string));
	tregistry_sospesi.defineColumn("toredirect", typeof(int));
	tregistry_sospesi.defineColumn("idaccmotivedebit", typeof(string));
	tregistry_sospesi.defineColumn("idaccmotivecredit", typeof(string));
	tregistry_sospesi.defineColumn("ccp", typeof(string));
	tregistry_sospesi.defineColumn("flagbankitaliaproceeds", typeof(string));
	tregistry_sospesi.defineColumn("idexternal", typeof(int));
	tregistry_sospesi.defineColumn("ipa_fe", typeof(string));
	tregistry_sospesi.defineColumn("flag_pa", typeof(string));
	tregistry_sospesi.defineColumn("sdi_norifamm", typeof(string));
	tregistry_sospesi.defineColumn("sdi_defrifamm", typeof(string));
	Tables.Add(tregistry_sospesi);
	tregistry_sospesi.defineKey("idreg");

	//////////////////// BILL_RIPARTIZIONE /////////////////////////////////
	var tbill_ripartizione= new MetaTable("bill_ripartizione");
	tbill_ripartizione.defineColumn("ybill", typeof(short),false);
	tbill_ripartizione.defineColumn("nbill", typeof(int),false);
	tbill_ripartizione.defineColumn("billkind", typeof(string),false);
	tbill_ripartizione.defineColumn("registry", typeof(string));
	tbill_ripartizione.defineColumn("covered", typeof(decimal));
	tbill_ripartizione.defineColumn("total", typeof(decimal));
	tbill_ripartizione.defineColumn("adate", typeof(DateTime));
	tbill_ripartizione.defineColumn("active", typeof(string));
	tbill_ripartizione.defineColumn("motive", typeof(string));
	tbill_ripartizione.defineColumn("ct", typeof(DateTime),false);
	tbill_ripartizione.defineColumn("cu", typeof(string),false);
	tbill_ripartizione.defineColumn("lt", typeof(DateTime),false);
	tbill_ripartizione.defineColumn("lu", typeof(string),false);
	tbill_ripartizione.defineColumn("idtreasurer", typeof(int));
	tbill_ripartizione.defineColumn("regularizationnote", typeof(string));
	tbill_ripartizione.defineColumn("reduction", typeof(decimal));
	tbill_ripartizione.defineColumn("banknum", typeof(int));
	tbill_ripartizione.defineColumn("idbank", typeof(string));
	Tables.Add(tbill_ripartizione);
	tbill_ripartizione.defineKey("ybill", "nbill", "billkind");

	//////////////////// BILLVIEW /////////////////////////////////
	var tbillview= new MetaTable("billview");
	tbillview.defineColumn("ybill", typeof(short),false);
	tbillview.defineColumn("nbill", typeof(int),false);
	tbillview.defineColumn("billkind", typeof(string),false);
	tbillview.defineColumn("active", typeof(string));
	tbillview.defineColumn("adate", typeof(DateTime));
	tbillview.defineColumn("registry", typeof(string));
	tbillview.defineColumn("motive", typeof(string));
	tbillview.defineColumn("total", typeof(decimal));
	tbillview.defineColumn("covered", typeof(decimal));
	tbillview.defineColumn("cu", typeof(string),false);
	tbillview.defineColumn("ct", typeof(DateTime),false);
	tbillview.defineColumn("lu", typeof(string),false);
	tbillview.defineColumn("lt", typeof(DateTime),false);
	tbillview.defineColumn("idtreasurer", typeof(int));
	tbillview.defineColumn("treasurer", typeof(string));
	tbillview.defineColumn("regularizationnote", typeof(string));
	tbillview.defineColumn("idsor01", typeof(int));
	tbillview.defineColumn("idsor02", typeof(int));
	tbillview.defineColumn("idsor03", typeof(int));
	tbillview.defineColumn("idsor04", typeof(int));
	tbillview.defineColumn("idsor05", typeof(int));
	Tables.Add(tbillview);
	tbillview.defineKey("ybill", "nbill", "billkind");

	#endregion


	#region DataRelation creation
	this.defineRelation("csa_import_csa_importver","csa_import","csa_importver","idcsa_import");
	this.defineRelation("csa_import_csa_importver_partition","csa_import","csa_importver_partition","idcsa_import");
	var cPar = new []{bill_netti.Columns["ybill"], bill_netti.Columns["nbill"]};
	var cChild = new []{csa_import.Columns["ybill_netti"], csa_import.Columns["nbill_netti"]};
	Relations.Add(new DataRelation("bill_netti_csa_import",cPar,cChild,false));

	cPar = new []{bill_versamenti.Columns["ybill"], bill_versamenti.Columns["nbill"]};
	cChild = new []{csa_import.Columns["ybill_versamenti"], csa_import.Columns["nbill_versamenti"]};
	Relations.Add(new DataRelation("bill_versamenti_csa_import",cPar,cChild,false));

	this.defineRelation("csa_import_csa_bill","csa_import","csa_bill","idcsa_import");
	this.defineRelation("registry_sospesi_csa_bill","registry_sospesi","csa_bill","idreg");
	this.defineRelation("bill_csa_bill","bill_ripartizione","csa_bill","nbill");
	#endregion

}
}
}
