
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
using meta_parasubcontract;
using meta_service;
using meta_registry;
using meta_payroll;
using meta_geo_city;
using meta_sorting;
using meta_upb;
using meta_config;
using meta_accmotiveapplied;
using meta_dalia_dipartimento;
using meta_dalia_funzionale;
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace parasubcontract_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public parasubcontractTable parasubcontract 		=> (parasubcontractTable)Tables["parasubcontract"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public serviceTable service 		=> (serviceTable)Tables["service"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_cityview 		=> (MetaTable)Tables["geo_cityview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable payrollkind 		=> (MetaTable)Tables["payrollkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable inpsactivity 		=> (MetaTable)Tables["inpsactivity"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable otherinsurance 		=> (MetaTable)Tables["otherinsurance"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable matriculabook 		=> (MetaTable)Tables["matriculabook"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pat 		=> (MetaTable)Tables["pat"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public registryTable registry 		=> (registryTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable deductibleexpense 		=> (MetaTable)Tables["deductibleexpense"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable deduction 		=> (MetaTable)Tables["deduction"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable abatableexpense 		=> (MetaTable)Tables["abatableexpense"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable abatement 		=> (MetaTable)Tables["abatement"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable exhibitedcud 		=> (MetaTable)Tables["exhibitedcud"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable exhibitedcudabatement 		=> (MetaTable)Tables["exhibitedcudabatement"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable exhibitedcuddeduction 		=> (MetaTable)Tables["exhibitedcuddeduction"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable parasubcontractfamily 		=> (MetaTable)Tables["parasubcontractfamily"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable deductioncode 		=> (MetaTable)Tables["deductioncode"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable abatementcode 		=> (MetaTable)Tables["abatementcode"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public payrollTable payroll 		=> (payrollTable)Tables["payroll"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public geo_cityTable geo_city 		=> (geo_cityTable)Tables["geo_city"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable otherinail 		=> (MetaTable)Tables["otherinail"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable payrolltax 		=> (MetaTable)Tables["payrolltax"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable payrolldeduction 		=> (MetaTable)Tables["payrolldeduction"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable payrollabatement 		=> (MetaTable)Tables["payrollabatement"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable payrolltaxbracket 		=> (MetaTable)Tables["payrolltaxbracket"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable parasubcontractyear 		=> (MetaTable)Tables["parasubcontractyear"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable emenscontractkind 		=> (MetaTable)Tables["emenscontractkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingTable sorting 		=> (sortingTable)Tables["sorting"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable parasubcontractsorting 		=> (MetaTable)Tables["parasubcontractsorting"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable expensepayrollview 		=> (MetaTable)Tables["expensepayrollview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable cafdocument 		=> (MetaTable)Tables["cafdocument"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable monthname 		=> (MetaTable)Tables["monthname"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tipocomunicazione 		=> (MetaTable)Tables["tipocomunicazione"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accmotiveapplied_cost 		=> (MetaTable)Tables["accmotiveapplied_cost"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingTable sorting1 		=> (sortingTable)Tables["sorting1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingTable sorting2 		=> (sortingTable)Tables["sorting2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingTable sorting3 		=> (sortingTable)Tables["sorting3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public upbTable upb 		=> (upbTable)Tables["upb"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tax 		=> (MetaTable)Tables["tax"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable taxratebracket 		=> (MetaTable)Tables["taxratebracket"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public configTable config 		=> (configTable)Tables["config"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable payrolltaxcorrige 		=> (MetaTable)Tables["payrolltaxcorrige"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accmotiveappliedTable accmotiveapplied_debit 		=> (accmotiveappliedTable)Tables["accmotiveapplied_debit"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accmotiveappliedTable accmotiveapplied_crg 		=> (accmotiveappliedTable)Tables["accmotiveapplied_crg"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingTable sorting01 		=> (sortingTable)Tables["sorting01"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingTable sorting02 		=> (sortingTable)Tables["sorting02"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingTable sorting03 		=> (sortingTable)Tables["sorting03"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingTable sorting04 		=> (sortingTable)Tables["sorting04"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingTable sorting05 		=> (sortingTable)Tables["sorting05"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable dalia_position 		=> (MetaTable)Tables["dalia_position"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sortingview1 		=> (MetaTable)Tables["sortingview1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public payrollTable payroll_altriesercizi 		=> (payrollTable)Tables["payroll_altriesercizi"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable parasubcontractview 		=> (MetaTable)Tables["parasubcontractview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingTable sorting_siope 		=> (sortingTable)Tables["sorting_siope"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable dalia_recruitmentmotive 		=> (MetaTable)Tables["dalia_recruitmentmotive"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable upb_payroll 		=> (MetaTable)Tables["upb_payroll"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable upb_payrollother 		=> (MetaTable)Tables["upb_payrollother"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public dalia_dipartimentoTable dalia_dipartimento 		=> (dalia_dipartimentoTable)Tables["dalia_dipartimento"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public dalia_funzionaleTable dalia_funzionale 		=> (dalia_funzionaleTable)Tables["dalia_funzionale"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable serviceattachmentkind 		=> (MetaTable)Tables["serviceattachmentkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable parasubcontractattachment 		=> (MetaTable)Tables["parasubcontractattachment"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable costpartition 		=> (MetaTable)Tables["costpartition"];

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
	//////////////////// PARASUBCONTRACT /////////////////////////////////
	var tparasubcontract= new parasubcontractTable();
	tparasubcontract.addBaseColumns("idcon","ycon","ncon","idreg","duty","idpayrollkind","idser","employed","payrollccinfo","start","stop","monthlen","grossamount","idpat","matricula","idmatriculabook","cu","ct","lu","lt","txt","rtf","idupb","idsor1","idsor2","idsor3","idaccmotive","idaccmotivedebit","idaccmotivedebit_crg","idaccmotivedebit_datacrg","idregistrylegalstatus","idsor01","idsor02","idsor03","idsor04","idsor05","iddaliaposition","idsor_siope","requested_doc","iddaliarecruitmentmotive","iddalia_dipartimento","iddalia_funzionale","idcostpartition");
	Tables.Add(tparasubcontract);
	tparasubcontract.defineKey("idcon");

	//////////////////// SERVICE /////////////////////////////////
	var tservice= new serviceTable();
	tservice.addBaseColumns("idser","codeser","servicecode770","description","flagonlyfiscalabatement","ivaamount","certificatekind","cu","ct","lu","lt","active","flagapplyabatements","flagdalia","idmotive","itinerationvisible","flagneedbalance","flagforeign","requested_doc");
	Tables.Add(tservice);
	tservice.defineKey("idser");

	//////////////////// GEO_CITYVIEW /////////////////////////////////
	var tgeo_cityview= new MetaTable("geo_cityview");
	tgeo_cityview.defineColumn("idcity", typeof(int),false);
	tgeo_cityview.defineColumn("title", typeof(string));
	tgeo_cityview.defineColumn("oldcity", typeof(int));
	tgeo_cityview.defineColumn("newcity", typeof(int));
	tgeo_cityview.defineColumn("start", typeof(DateTime));
	tgeo_cityview.defineColumn("stop", typeof(DateTime));
	tgeo_cityview.defineColumn("idcountry", typeof(int),false);
	tgeo_cityview.defineColumn("provincecode", typeof(string));
	tgeo_cityview.defineColumn("country", typeof(string));
	tgeo_cityview.defineColumn("oldcountry", typeof(int));
	tgeo_cityview.defineColumn("newcountry", typeof(int));
	tgeo_cityview.defineColumn("countrydatestart", typeof(DateTime));
	tgeo_cityview.defineColumn("countrydatestop", typeof(DateTime));
	tgeo_cityview.defineColumn("idregion", typeof(int),false);
	tgeo_cityview.defineColumn("region", typeof(string));
	tgeo_cityview.defineColumn("regiondatestart", typeof(DateTime));
	tgeo_cityview.defineColumn("regiondatestop", typeof(DateTime));
	tgeo_cityview.defineColumn("oldregion", typeof(int));
	tgeo_cityview.defineColumn("newregion", typeof(int));
	tgeo_cityview.defineColumn("idnation", typeof(int),false);
	tgeo_cityview.defineColumn("idcontinent", typeof(int));
	tgeo_cityview.defineColumn("nation", typeof(string));
	tgeo_cityview.defineColumn("nationdatestart", typeof(DateTime));
	tgeo_cityview.defineColumn("nationdatestop", typeof(DateTime));
	tgeo_cityview.defineColumn("oldnation", typeof(int));
	tgeo_cityview.defineColumn("newnation", typeof(int));
	Tables.Add(tgeo_cityview);
	tgeo_cityview.defineKey("idcity");

	//////////////////// PAYROLLKIND /////////////////////////////////
	var tpayrollkind= new MetaTable("payrollkind");
	tpayrollkind.defineColumn("idpayrollkind", typeof(string),false);
	tpayrollkind.defineColumn("description", typeof(string));
	tpayrollkind.defineColumn("cu", typeof(string));
	tpayrollkind.defineColumn("ct", typeof(DateTime));
	tpayrollkind.defineColumn("lu", typeof(string));
	tpayrollkind.defineColumn("lt", typeof(DateTime));
	Tables.Add(tpayrollkind);
	tpayrollkind.defineKey("idpayrollkind");

	//////////////////// INPSACTIVITY /////////////////////////////////
	var tinpsactivity= new MetaTable("inpsactivity");
	tinpsactivity.defineColumn("ayear", typeof(int),false);
	tinpsactivity.defineColumn("activitycode", typeof(string),false);
	tinpsactivity.defineColumn("description", typeof(string));
	tinpsactivity.defineColumn("lu", typeof(string));
	tinpsactivity.defineColumn("lt", typeof(DateTime));
	Tables.Add(tinpsactivity);
	tinpsactivity.defineKey("activitycode", "ayear");

	//////////////////// OTHERINSURANCE /////////////////////////////////
	var totherinsurance= new MetaTable("otherinsurance");
	totherinsurance.defineColumn("ayear", typeof(int),false);
	totherinsurance.defineColumn("idotherinsurance", typeof(string),false);
	totherinsurance.defineColumn("description", typeof(string),false);
	totherinsurance.defineColumn("lu", typeof(string));
	totherinsurance.defineColumn("lt", typeof(DateTime));
	Tables.Add(totherinsurance);
	totherinsurance.defineKey("idotherinsurance", "ayear");

	//////////////////// MATRICULABOOK /////////////////////////////////
	var tmatriculabook= new MetaTable("matriculabook");
	tmatriculabook.defineColumn("idmatriculabook", typeof(string),false);
	tmatriculabook.defineColumn("description", typeof(string));
	tmatriculabook.defineColumn("cu", typeof(string));
	tmatriculabook.defineColumn("ct", typeof(DateTime));
	tmatriculabook.defineColumn("lu", typeof(string));
	tmatriculabook.defineColumn("lt", typeof(DateTime));
	Tables.Add(tmatriculabook);
	tmatriculabook.defineKey("idmatriculabook");

	//////////////////// PAT /////////////////////////////////
	var tpat= new MetaTable("pat");
	tpat.defineColumn("idpat", typeof(int),false);
	tpat.defineColumn("patcode", typeof(string),false);
	tpat.defineColumn("description", typeof(string),false);
	tpat.defineColumn("validitystart", typeof(DateTime));
	tpat.defineColumn("validitystop", typeof(DateTime));
	tpat.defineColumn("active", typeof(string));
	tpat.defineColumn("taxablenumerator", typeof(decimal));
	tpat.defineColumn("taxabledenominator", typeof(decimal));
	tpat.defineColumn("adminrate", typeof(decimal));
	tpat.defineColumn("adminnumerator", typeof(decimal));
	tpat.defineColumn("admindenominator", typeof(decimal));
	tpat.defineColumn("employrate", typeof(decimal));
	tpat.defineColumn("employnumerator", typeof(decimal));
	tpat.defineColumn("employdenominator", typeof(decimal));
	tpat.defineColumn("cu", typeof(string));
	tpat.defineColumn("ct", typeof(DateTime));
	tpat.defineColumn("lu", typeof(string));
	tpat.defineColumn("lt", typeof(DateTime));
	Tables.Add(tpat);
	tpat.defineKey("idpat");

	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new registryTable();
	tregistry.addBaseColumns("idreg","title","cf","p_iva","residence","annotation","birthdate","gender","surname","forename","foreigncf","active","txt","rtf","cu","ct","lu","lt","badgecode","idcategory","idcentralizedcategory","idmaritalstatus","idtitle","idregistryclass","maritalsurname","idcity","idnation","location","extmatricula","idaccmotivedebit");
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// DEDUCTIBLEEXPENSE /////////////////////////////////
	var tdeductibleexpense= new MetaTable("deductibleexpense");
	tdeductibleexpense.defineColumn("ayear", typeof(int),false);
	tdeductibleexpense.defineColumn("idcon", typeof(string),false);
	tdeductibleexpense.defineColumn("iddeduction", typeof(int),false);
	tdeductibleexpense.defineColumn("totalamount", typeof(decimal),false);
	tdeductibleexpense.defineColumn("cu", typeof(string));
	tdeductibleexpense.defineColumn("ct", typeof(DateTime));
	tdeductibleexpense.defineColumn("lu", typeof(string));
	tdeductibleexpense.defineColumn("lt", typeof(DateTime));
	tdeductibleexpense.defineColumn("!descrdeduzione", typeof(string));
	Tables.Add(tdeductibleexpense);
	tdeductibleexpense.defineKey("ayear", "idcon", "iddeduction");

	//////////////////// DEDUCTION /////////////////////////////////
	var tdeduction= new MetaTable("deduction");
	tdeduction.defineColumn("iddeduction", typeof(int),false);
	tdeduction.defineColumn("calculationkind", typeof(string),false);
	tdeduction.defineColumn("taxablecode", typeof(string),false);
	tdeduction.defineColumn("description", typeof(string),false);
	tdeduction.defineColumn("evaluatesp", typeof(string),false);
	tdeduction.defineColumn("lu", typeof(string));
	tdeduction.defineColumn("lt", typeof(DateTime));
	tdeduction.defineColumn("validitystart", typeof(DateTime));
	tdeduction.defineColumn("validitystop", typeof(DateTime));
	tdeduction.defineColumn("evaluationorder", typeof(int));
	tdeduction.defineColumn("flagdeductibleexpense", typeof(string));
	Tables.Add(tdeduction);
	tdeduction.defineKey("iddeduction");

	//////////////////// ABATABLEEXPENSE /////////////////////////////////
	var tabatableexpense= new MetaTable("abatableexpense");
	tabatableexpense.defineColumn("ayear", typeof(int),false);
	tabatableexpense.defineColumn("idcon", typeof(string),false);
	tabatableexpense.defineColumn("idabatement", typeof(int),false);
	tabatableexpense.defineColumn("totalamount", typeof(decimal));
	tabatableexpense.defineColumn("cu", typeof(string));
	tabatableexpense.defineColumn("ct", typeof(DateTime));
	tabatableexpense.defineColumn("lu", typeof(string));
	tabatableexpense.defineColumn("lt", typeof(DateTime));
	tabatableexpense.defineColumn("!descrdetrazione", typeof(string));
	Tables.Add(tabatableexpense);
	tabatableexpense.defineKey("ayear", "idcon", "idabatement");

	//////////////////// ABATEMENT /////////////////////////////////
	var tabatement= new MetaTable("abatement");
	tabatement.defineColumn("idabatement", typeof(int),false);
	tabatement.defineColumn("calculationkind", typeof(string),false);
	tabatement.defineColumn("taxcode", typeof(int),false);
	tabatement.defineColumn("description", typeof(string));
	tabatement.defineColumn("evaluatesp", typeof(string));
	tabatement.defineColumn("lu", typeof(string));
	tabatement.defineColumn("lt", typeof(DateTime));
	tabatement.defineColumn("validitystart", typeof(DateTime));
	tabatement.defineColumn("validitystop", typeof(DateTime));
	tabatement.defineColumn("evaluationorder", typeof(int));
	tabatement.defineColumn("appliance", typeof(string));
	tabatement.defineColumn("flagabatableexpense", typeof(string));
	Tables.Add(tabatement);
	tabatement.defineKey("idabatement");

	//////////////////// EXHIBITEDCUD /////////////////////////////////
	var texhibitedcud= new MetaTable("exhibitedcud");
	texhibitedcud.defineColumn("idlinkedcon", typeof(string));
	texhibitedcud.defineColumn("idcon", typeof(string),false);
	texhibitedcud.defineColumn("idexhibitedcud", typeof(int),false);
	texhibitedcud.defineColumn("start", typeof(DateTime),false);
	texhibitedcud.defineColumn("stop", typeof(DateTime),false);
	texhibitedcud.defineColumn("nmonths", typeof(int),false);
	texhibitedcud.defineColumn("taxablepension", typeof(decimal),false);
	texhibitedcud.defineColumn("taxablegross", typeof(decimal));
	texhibitedcud.defineColumn("flagignoreprevcud", typeof(string),false);
	texhibitedcud.defineColumn("cfotherdeputy", typeof(string));
	texhibitedcud.defineColumn("transfermotive", typeof(string));
	texhibitedcud.defineColumn("inpsowed", typeof(decimal));
	texhibitedcud.defineColumn("inpsretained", typeof(decimal));
	texhibitedcud.defineColumn("irpefapplied", typeof(decimal));
	texhibitedcud.defineColumn("irpefsuspended", typeof(decimal));
	texhibitedcud.defineColumn("regionaltaxapplied", typeof(decimal));
	texhibitedcud.defineColumn("suspendedregionaltax", typeof(decimal));
	texhibitedcud.defineColumn("citytaxapplied", typeof(decimal));
	texhibitedcud.defineColumn("suspendedcitytax", typeof(decimal));
	texhibitedcud.defineColumn("cu", typeof(string));
	texhibitedcud.defineColumn("ct", typeof(DateTime));
	texhibitedcud.defineColumn("lu", typeof(string));
	texhibitedcud.defineColumn("lt", typeof(DateTime));
	texhibitedcud.defineColumn("fiscalyear", typeof(int),false);
	texhibitedcud.defineColumn("ndays", typeof(int));
	texhibitedcud.defineColumn("citytax_account", typeof(decimal));
	texhibitedcud.defineColumn("idcity", typeof(int));
	texhibitedcud.defineColumn("idfiscaltaxregion", typeof(string));
	texhibitedcud.defineColumn("idlinkeddbdepartment", typeof(string));
	texhibitedcud.defineColumn("irpefgross", typeof(decimal));
	texhibitedcud.defineColumn("earnings_based_abatements2020", typeof(decimal));
	texhibitedcud.defineColumn("earnings_based_abatements", typeof(decimal));
	texhibitedcud.defineColumn("fiscalbonusnotapplied2020", typeof(decimal));
	texhibitedcud.defineColumn("fiscalbonusnotapplied", typeof(decimal));
	texhibitedcud.defineColumn("fiscalbonusapplied2020", typeof(decimal));
	texhibitedcud.defineColumn("fiscalbonusapplied", typeof(decimal));
	texhibitedcud.defineColumn("flagbonusaccredited", typeof(int));
	texhibitedcud.defineColumn("totabatements", typeof(decimal));
	Tables.Add(texhibitedcud);
	texhibitedcud.defineKey("idcon", "idexhibitedcud");

	//////////////////// EXHIBITEDCUDABATEMENT /////////////////////////////////
	var texhibitedcudabatement= new MetaTable("exhibitedcudabatement");
	texhibitedcudabatement.defineColumn("idcon", typeof(string),false);
	texhibitedcudabatement.defineColumn("idexhibitedcud", typeof(int),false);
	texhibitedcudabatement.defineColumn("idabatement", typeof(int),false);
	texhibitedcudabatement.defineColumn("amount", typeof(decimal));
	texhibitedcudabatement.defineColumn("!descrdetrazione", typeof(string));
	Tables.Add(texhibitedcudabatement);
	texhibitedcudabatement.defineKey("idcon", "idexhibitedcud", "idabatement");

	//////////////////// EXHIBITEDCUDDEDUCTION /////////////////////////////////
	var texhibitedcuddeduction= new MetaTable("exhibitedcuddeduction");
	texhibitedcuddeduction.defineColumn("idcon", typeof(string),false);
	texhibitedcuddeduction.defineColumn("idexhibitedcud", typeof(int),false);
	texhibitedcuddeduction.defineColumn("iddeduction", typeof(int),false);
	texhibitedcuddeduction.defineColumn("amount", typeof(decimal));
	texhibitedcuddeduction.defineColumn("!descrdeduzione", typeof(string));
	Tables.Add(texhibitedcuddeduction);
	texhibitedcuddeduction.defineKey("idcon", "idexhibitedcud", "iddeduction");

	//////////////////// PARASUBCONTRACTFAMILY /////////////////////////////////
	var tparasubcontractfamily= new MetaTable("parasubcontractfamily");
	tparasubcontractfamily.defineColumn("idcon", typeof(string),false);
	tparasubcontractfamily.defineColumn("idfamily", typeof(int),false);
	tparasubcontractfamily.defineColumn("ayear", typeof(int),false);
	tparasubcontractfamily.defineColumn("idaffinity", typeof(string),false);
	tparasubcontractfamily.defineColumn("surname", typeof(string));
	tparasubcontractfamily.defineColumn("forename", typeof(string));
	tparasubcontractfamily.defineColumn("idcitybirth", typeof(int));
	tparasubcontractfamily.defineColumn("idnation", typeof(int));
	tparasubcontractfamily.defineColumn("birthdate", typeof(DateTime));
	tparasubcontractfamily.defineColumn("gender", typeof(string));
	tparasubcontractfamily.defineColumn("flagforeign", typeof(string));
	tparasubcontractfamily.defineColumn("cf", typeof(string));
	tparasubcontractfamily.defineColumn("startapplication", typeof(DateTime));
	tparasubcontractfamily.defineColumn("stopapplication", typeof(DateTime));
	tparasubcontractfamily.defineColumn("appliancepercentage", typeof(decimal));
	tparasubcontractfamily.defineColumn("starthandicap", typeof(DateTime));
	tparasubcontractfamily.defineColumn("foreignresident", typeof(string),false);
	tparasubcontractfamily.defineColumn("flagdependent", typeof(string),false);
	tparasubcontractfamily.defineColumn("amount", typeof(decimal));
	tparasubcontractfamily.defineColumn("childasparent", typeof(string));
	tparasubcontractfamily.defineColumn("lu", typeof(string));
	tparasubcontractfamily.defineColumn("lt", typeof(DateTime));
	tparasubcontractfamily.defineColumn("cu", typeof(string));
	tparasubcontractfamily.defineColumn("ct", typeof(DateTime));
	Tables.Add(tparasubcontractfamily);
	tparasubcontractfamily.defineKey("idcon", "idfamily", "ayear");

	//////////////////// DEDUCTIONCODE /////////////////////////////////
	var tdeductioncode= new MetaTable("deductioncode");
	tdeductioncode.defineColumn("iddeduction", typeof(int),false);
	tdeductioncode.defineColumn("ayear", typeof(int),false);
	tdeductioncode.defineColumn("code", typeof(string));
	tdeductioncode.defineColumn("description", typeof(string));
	tdeductioncode.defineColumn("longdescription", typeof(string));
	tdeductioncode.defineColumn("exemption", typeof(decimal));
	tdeductioncode.defineColumn("maximal", typeof(decimal));
	tdeductioncode.defineColumn("rate", typeof(decimal));
	tdeductioncode.defineColumn("lu", typeof(string));
	tdeductioncode.defineColumn("lt", typeof(DateTime));
	Tables.Add(tdeductioncode);
	tdeductioncode.defineKey("iddeduction", "ayear");

	//////////////////// ABATEMENTCODE /////////////////////////////////
	var tabatementcode= new MetaTable("abatementcode");
	tabatementcode.defineColumn("idabatement", typeof(int),false);
	tabatementcode.defineColumn("ayear", typeof(int),false);
	tabatementcode.defineColumn("code", typeof(string));
	tabatementcode.defineColumn("description", typeof(string));
	tabatementcode.defineColumn("longdescription", typeof(string));
	tabatementcode.defineColumn("exemption", typeof(decimal));
	tabatementcode.defineColumn("maximal", typeof(decimal));
	tabatementcode.defineColumn("rate", typeof(decimal));
	Tables.Add(tabatementcode);
	tabatementcode.defineKey("idabatement", "ayear");

	//////////////////// PAYROLL /////////////////////////////////
	var tpayroll= new payrollTable();
	tpayroll.addBaseColumns("idpayroll","disbursementdate","flagcomputed","npayroll","flagbalance","start","stop","idresidence","workingdays","feegross","netfee","idcon","currentrounding","lu","lt","cu","ct","enabletaxrelief","fiscalyear","flagsummarybalance","idupb","idcostpartition");
	tpayroll.defineColumn("!codeupb", typeof(string));
	Tables.Add(tpayroll);
	tpayroll.defineKey("idpayroll");

	//////////////////// GEO_CITY /////////////////////////////////
	var tgeo_city= new geo_cityTable();
	tgeo_city.addBaseColumns("idcity","stop","start","title","idcountry","lt","lu","newcity","oldcity");
	Tables.Add(tgeo_city);
	tgeo_city.defineKey("idcity");

	//////////////////// OTHERINAIL /////////////////////////////////
	var totherinail= new MetaTable("otherinail");
	totherinail.defineColumn("idcon", typeof(string),false);
	totherinail.defineColumn("idotherinail", typeof(int),false);
	totherinail.defineColumn("taxable", typeof(decimal));
	totherinail.defineColumn("start", typeof(DateTime));
	totherinail.defineColumn("stop", typeof(DateTime));
	totherinail.defineColumn("nmonths", typeof(int));
	Tables.Add(totherinail);
	totherinail.defineKey("idcon", "idotherinail");

	//////////////////// PAYROLLTAX /////////////////////////////////
	var tpayrolltax= new MetaTable("payrolltax");
	tpayrolltax.defineColumn("idpayroll", typeof(int),false);
	tpayrolltax.defineColumn("idpayrolltax", typeof(int),false);
	tpayrolltax.defineColumn("taxcode", typeof(int));
	tpayrolltax.defineColumn("taxablegross", typeof(decimal));
	tpayrolltax.defineColumn("deduction", typeof(decimal));
	tpayrolltax.defineColumn("abatements", typeof(decimal));
	tpayrolltax.defineColumn("cu", typeof(string));
	tpayrolltax.defineColumn("ct", typeof(DateTime));
	tpayrolltax.defineColumn("lu", typeof(string));
	tpayrolltax.defineColumn("lt", typeof(DateTime));
	tpayrolltax.defineColumn("taxablenumerator", typeof(decimal));
	tpayrolltax.defineColumn("taxabledenominator", typeof(decimal));
	tpayrolltax.defineColumn("employrate", typeof(decimal));
	tpayrolltax.defineColumn("employnumerator", typeof(decimal));
	tpayrolltax.defineColumn("employdenominator", typeof(decimal));
	tpayrolltax.defineColumn("adminrate", typeof(decimal));
	tpayrolltax.defineColumn("adminnumerator", typeof(decimal));
	tpayrolltax.defineColumn("admindenominator", typeof(decimal));
	tpayrolltax.defineColumn("employtax", typeof(decimal));
	tpayrolltax.defineColumn("admintax", typeof(decimal));
	tpayrolltax.defineColumn("taxablenet", typeof(decimal));
	tpayrolltax.defineColumn("employtaxgross", typeof(decimal));
	tpayrolltax.defineColumn("annualtaxabletotal", typeof(decimal));
	tpayrolltax.defineColumn("annualpayedemploytax", typeof(decimal));
	tpayrolltax.defineColumn("idcity", typeof(int));
	tpayrolltax.defineColumn("idfiscaltaxregion", typeof(string));
	tpayrolltax.defineColumn("annualcreditapplied", typeof(decimal));
	Tables.Add(tpayrolltax);
	tpayrolltax.defineKey("idpayroll", "idpayrolltax");

	//////////////////// PAYROLLDEDUCTION /////////////////////////////////
	var tpayrolldeduction= new MetaTable("payrolldeduction");
	tpayrolldeduction.defineColumn("idpayroll", typeof(int),false);
	tpayrolldeduction.defineColumn("iddeduction", typeof(int),false);
	tpayrolldeduction.defineColumn("taxablecode", typeof(string));
	tpayrolldeduction.defineColumn("annualamount", typeof(decimal));
	tpayrolldeduction.defineColumn("curramount", typeof(decimal));
	Tables.Add(tpayrolldeduction);
	tpayrolldeduction.defineKey("idpayroll", "iddeduction");

	//////////////////// PAYROLLABATEMENT /////////////////////////////////
	var tpayrollabatement= new MetaTable("payrollabatement");
	tpayrollabatement.defineColumn("idpayroll", typeof(int),false);
	tpayrollabatement.defineColumn("idabatement", typeof(int),false);
	tpayrollabatement.defineColumn("taxcode", typeof(int));
	tpayrollabatement.defineColumn("annualamount", typeof(decimal));
	tpayrollabatement.defineColumn("curramount", typeof(decimal));
	Tables.Add(tpayrollabatement);
	tpayrollabatement.defineKey("idpayroll", "idabatement");

	//////////////////// PAYROLLTAXBRACKET /////////////////////////////////
	var tpayrolltaxbracket= new MetaTable("payrolltaxbracket");
	tpayrolltaxbracket.defineColumn("idpayroll", typeof(int),false);
	tpayrolltaxbracket.defineColumn("idpayrolltax", typeof(int),false);
	tpayrolltaxbracket.defineColumn("nbracket", typeof(short),false);
	tpayrolltaxbracket.defineColumn("taxable", typeof(decimal));
	tpayrolltaxbracket.defineColumn("employrate", typeof(decimal));
	tpayrolltaxbracket.defineColumn("employtax", typeof(decimal));
	tpayrolltaxbracket.defineColumn("adminrate", typeof(decimal));
	tpayrolltaxbracket.defineColumn("admintax", typeof(decimal));
	tpayrolltaxbracket.defineColumn("cu", typeof(string));
	tpayrolltaxbracket.defineColumn("ct", typeof(DateTime));
	tpayrolltaxbracket.defineColumn("lu", typeof(string));
	tpayrolltaxbracket.defineColumn("lt", typeof(DateTime));
	Tables.Add(tpayrolltaxbracket);
	tpayrolltaxbracket.defineKey("idpayroll", "idpayrolltax", "nbracket");

	//////////////////// PARASUBCONTRACTYEAR /////////////////////////////////
	var tparasubcontractyear= new MetaTable("parasubcontractyear");
	tparasubcontractyear.defineColumn("ayear", typeof(int),false);
	tparasubcontractyear.defineColumn("idcon", typeof(string),false);
	tparasubcontractyear.defineColumn("regionaltax", typeof(decimal));
	tparasubcontractyear.defineColumn("countrytax", typeof(decimal));
	tparasubcontractyear.defineColumn("citytax", typeof(decimal));
	tparasubcontractyear.defineColumn("ratequantity", typeof(int));
	tparasubcontractyear.defineColumn("startmonth", typeof(int));
	tparasubcontractyear.defineColumn("suspendedregionaltax", typeof(decimal));
	tparasubcontractyear.defineColumn("suspendedcitytax", typeof(decimal));
	tparasubcontractyear.defineColumn("suspendedcountrytax", typeof(decimal));
	tparasubcontractyear.defineColumn("idotherinsurance", typeof(string));
	tparasubcontractyear.defineColumn("activitycode", typeof(string));
	tparasubcontractyear.defineColumn("cu", typeof(string));
	tparasubcontractyear.defineColumn("ct", typeof(DateTime));
	tparasubcontractyear.defineColumn("lu", typeof(string));
	tparasubcontractyear.defineColumn("lt", typeof(DateTime));
	tparasubcontractyear.defineColumn("notaxappliance", typeof(string));
	tparasubcontractyear.defineColumn("applybrackets", typeof(string));
	tparasubcontractyear.defineColumn("highertax", typeof(decimal));
	tparasubcontractyear.defineColumn("taxablecud", typeof(decimal));
	tparasubcontractyear.defineColumn("cuddays", typeof(short));
	tparasubcontractyear.defineColumn("taxablecontract", typeof(decimal));
	tparasubcontractyear.defineColumn("ndays", typeof(int));
	tparasubcontractyear.defineColumn("taxablepension", typeof(decimal));
	tparasubcontractyear.defineColumn("fiscaldeduction", typeof(decimal));
	tparasubcontractyear.defineColumn("notaxdeduction", typeof(decimal));
	tparasubcontractyear.defineColumn("taxablegross", typeof(decimal));
	tparasubcontractyear.defineColumn("taxablenet", typeof(decimal));
	tparasubcontractyear.defineColumn("startcompetency", typeof(DateTime));
	tparasubcontractyear.defineColumn("stopcompetency", typeof(DateTime));
	tparasubcontractyear.defineColumn("idresidence", typeof(int));
	tparasubcontractyear.defineColumn("idemenscontractkind", typeof(string));
	tparasubcontractyear.defineColumn("citytax_account", typeof(decimal));
	tparasubcontractyear.defineColumn("ratequantity_account", typeof(int));
	tparasubcontractyear.defineColumn("startmonth_account", typeof(int));
	tparasubcontractyear.defineColumn("annualincome", typeof(decimal));
	tparasubcontractyear.defineColumn("flagbonusappliance", typeof(string));
	tparasubcontractyear.defineColumn("flagexcludefromcertificate", typeof(string));
	Tables.Add(tparasubcontractyear);
	tparasubcontractyear.defineKey("ayear", "idcon");

	//////////////////// EMENSCONTRACTKIND /////////////////////////////////
	var temenscontractkind= new MetaTable("emenscontractkind");
	temenscontractkind.defineColumn("idemenscontractkind", typeof(string),false);
	temenscontractkind.defineColumn("ayear", typeof(int),false);
	temenscontractkind.defineColumn("description", typeof(string));
	temenscontractkind.defineColumn("annotations", typeof(string));
	temenscontractkind.defineColumn("flagactivityrequested", typeof(string));
	temenscontractkind.defineColumn("module", typeof(string));
	temenscontractkind.defineColumn("active", typeof(string));
	Tables.Add(temenscontractkind);
	temenscontractkind.defineKey("idemenscontractkind", "ayear");

	//////////////////// SORTING /////////////////////////////////
	var tsorting= new sortingTable();
	tsorting.addBaseColumns("idsorkind","idsor","sortcode","paridsor","nlevel","description","txt","rtf","cu","ct","lu","lt","defaultn1","defaultn2","defaultn3","defaultn4","defaultn5","defaults1","defaults2","defaults3","defaults4","defaults5","flagnodate","movkind","printingorder","defaultv1","defaultv2","defaultv3","defaultv4","idsor01","idsor02","idsor03","idsor04","idsor05","defaultv5");
	Tables.Add(tsorting);
	tsorting.defineKey("idsor");

	//////////////////// PARASUBCONTRACTSORTING /////////////////////////////////
	var tparasubcontractsorting= new MetaTable("parasubcontractsorting");
	tparasubcontractsorting.defineColumn("idsor", typeof(int),false);
	tparasubcontractsorting.defineColumn("idcon", typeof(string),false);
	tparasubcontractsorting.defineColumn("cu", typeof(string),false);
	tparasubcontractsorting.defineColumn("ct", typeof(DateTime),false);
	tparasubcontractsorting.defineColumn("lu", typeof(string),false);
	tparasubcontractsorting.defineColumn("lt", typeof(DateTime),false);
	tparasubcontractsorting.defineColumn("quota", typeof(double));
	tparasubcontractsorting.defineColumn("!codiceclass", typeof(string));
	tparasubcontractsorting.defineColumn("!descrizione", typeof(string));
	Tables.Add(tparasubcontractsorting);
	tparasubcontractsorting.defineKey("idcon", "idsor");

	//////////////////// EXPENSEPAYROLLVIEW /////////////////////////////////
	var texpensepayrollview= new MetaTable("expensepayrollview");
	texpensepayrollview.defineColumn("idpayroll", typeof(int),false);
	texpensepayrollview.defineColumn("idexp", typeof(int),false);
	texpensepayrollview.defineColumn("fiscalyear", typeof(int),false);
	texpensepayrollview.defineColumn("npayroll", typeof(int),false);
	texpensepayrollview.defineColumn("nphase", typeof(byte),false);
	texpensepayrollview.defineColumn("phase", typeof(string),false);
	texpensepayrollview.defineColumn("ymov", typeof(short),false);
	texpensepayrollview.defineColumn("nmov", typeof(int),false);
	texpensepayrollview.defineColumn("parentidexp", typeof(int));
	texpensepayrollview.defineColumn("ayear", typeof(short),false);
	texpensepayrollview.defineColumn("idfin", typeof(int));
	texpensepayrollview.defineColumn("codefin", typeof(string));
	texpensepayrollview.defineColumn("finance", typeof(string));
	texpensepayrollview.defineColumn("idreg", typeof(int));
	texpensepayrollview.defineColumn("registry", typeof(string));
	texpensepayrollview.defineColumn("idman", typeof(int));
	texpensepayrollview.defineColumn("manager", typeof(string));
	texpensepayrollview.defineColumn("doc", typeof(string));
	texpensepayrollview.defineColumn("docdate", typeof(DateTime));
	texpensepayrollview.defineColumn("description", typeof(string),false);
	texpensepayrollview.defineColumn("amount", typeof(decimal));
	texpensepayrollview.defineColumn("ayearstartamount", typeof(decimal));
	texpensepayrollview.defineColumn("curramount", typeof(decimal));
	texpensepayrollview.defineColumn("available", typeof(decimal));
	texpensepayrollview.defineColumn("autokind", typeof(byte));
	texpensepayrollview.defineColumn("idpayment", typeof(int));
	texpensepayrollview.defineColumn("flagarrear", typeof(string));
	texpensepayrollview.defineColumn("expiration", typeof(DateTime));
	texpensepayrollview.defineColumn("adate", typeof(DateTime),false);
	texpensepayrollview.defineColumn("cu", typeof(string));
	texpensepayrollview.defineColumn("ct", typeof(DateTime));
	texpensepayrollview.defineColumn("lu", typeof(string));
	texpensepayrollview.defineColumn("lt", typeof(DateTime));
	texpensepayrollview.defineColumn("idcon", typeof(string),false);
	texpensepayrollview.defineColumn("idupb", typeof(string));
	texpensepayrollview.defineColumn("codeupb", typeof(string));
	texpensepayrollview.defineColumn("upb", typeof(string));
	Tables.Add(texpensepayrollview);

	//////////////////// CAFDOCUMENT /////////////////////////////////
	var tcafdocument= new MetaTable("cafdocument");
	tcafdocument.defineColumn("idcafdocument", typeof(int),false);
	tcafdocument.defineColumn("idcon", typeof(string),false);
	tcafdocument.defineColumn("ayear", typeof(int),false);
	tcafdocument.defineColumn("cafdocumentkind", typeof(string),false);
	tcafdocument.defineColumn("docdate", typeof(DateTime),false);
	tcafdocument.defineColumn("citytaxtorefundhusband", typeof(decimal));
	tcafdocument.defineColumn("citytaxtorefund", typeof(decimal));
	tcafdocument.defineColumn("citytaxtoretainhusband", typeof(decimal));
	tcafdocument.defineColumn("citytaxtoretain", typeof(decimal));
	tcafdocument.defineColumn("regionaltaxtorefundhusband", typeof(decimal));
	tcafdocument.defineColumn("regionaltaxtorefund", typeof(decimal));
	tcafdocument.defineColumn("regionaltaxtoretainhusband", typeof(decimal));
	tcafdocument.defineColumn("regionaltaxtoretain", typeof(decimal));
	tcafdocument.defineColumn("idcity", typeof(int));
	tcafdocument.defineColumn("idfiscaltaxregion", typeof(string));
	tcafdocument.defineColumn("irpeftorefund", typeof(decimal));
	tcafdocument.defineColumn("irpeftoretain", typeof(decimal));
	tcafdocument.defineColumn("startmonth", typeof(int));
	tcafdocument.defineColumn("monthfirstinstalment", typeof(int));
	tcafdocument.defineColumn("monthsecondinstalment", typeof(int));
	tcafdocument.defineColumn("ratequantity", typeof(int));
	tcafdocument.defineColumn("nquotafirstinstalment", typeof(int));
	tcafdocument.defineColumn("nquotasecondinstalment", typeof(int));
	tcafdocument.defineColumn("firstrateadvance", typeof(decimal));
	tcafdocument.defineColumn("separatedincomehusband", typeof(decimal));
	tcafdocument.defineColumn("separatedincome", typeof(decimal));
	tcafdocument.defineColumn("secondrateadvance", typeof(decimal));
	tcafdocument.defineColumn("ct", typeof(DateTime),false);
	tcafdocument.defineColumn("cu", typeof(string),false);
	tcafdocument.defineColumn("lt", typeof(DateTime),false);
	tcafdocument.defineColumn("lu", typeof(string),false);
	tcafdocument.defineColumn("!descrcomunicazione", typeof(string));
	tcafdocument.defineColumn("citytaxaccount", typeof(decimal));
	tcafdocument.defineColumn("citytaxaccounthusband", typeof(decimal));
	Tables.Add(tcafdocument);
	tcafdocument.defineKey("idcafdocument", "idcon");

	//////////////////// MONTHNAME /////////////////////////////////
	var tmonthname= new MetaTable("monthname");
	tmonthname.defineColumn("code", typeof(int),false);
	tmonthname.defineColumn("title", typeof(string));
	tmonthname.defineColumn("cfvalue", typeof(string));
	Tables.Add(tmonthname);
	tmonthname.defineKey("code");

	//////////////////// TIPOCOMUNICAZIONE /////////////////////////////////
	var ttipocomunicazione= new MetaTable("tipocomunicazione");
	ttipocomunicazione.defineColumn("codice", typeof(string),false);
	ttipocomunicazione.defineColumn("descrizione", typeof(string));
	Tables.Add(ttipocomunicazione);
	ttipocomunicazione.defineKey("codice");

	//////////////////// ACCMOTIVEAPPLIED_COST /////////////////////////////////
	var taccmotiveapplied_cost= new MetaTable("accmotiveapplied_cost");
	taccmotiveapplied_cost.defineColumn("idaccmotive", typeof(string),false);
	taccmotiveapplied_cost.defineColumn("paridaccmotive", typeof(string));
	taccmotiveapplied_cost.defineColumn("codemotive", typeof(string),false);
	taccmotiveapplied_cost.defineColumn("motive", typeof(string),false);
	taccmotiveapplied_cost.defineColumn("cu", typeof(string),false);
	taccmotiveapplied_cost.defineColumn("ct", typeof(DateTime),false);
	taccmotiveapplied_cost.defineColumn("lu", typeof(string),false);
	taccmotiveapplied_cost.defineColumn("lt", typeof(DateTime),false);
	taccmotiveapplied_cost.defineColumn("active", typeof(string));
	taccmotiveapplied_cost.defineColumn("idepoperation", typeof(string),false);
	taccmotiveapplied_cost.defineColumn("epoperation", typeof(string));
	taccmotiveapplied_cost.defineColumn("in_use", typeof(string));
	taccmotiveapplied_cost.defineColumn("flagamm", typeof(string));
	taccmotiveapplied_cost.defineColumn("flagdep", typeof(string));
	Tables.Add(taccmotiveapplied_cost);
	taccmotiveapplied_cost.defineKey("idaccmotive");

	//////////////////// SORTING1 /////////////////////////////////
	var tsorting1= new sortingTable();
	tsorting1.TableName = "sorting1";
	tsorting1.addBaseColumns("idsorkind","idsor","sortcode","paridsor","nlevel","description","txt","rtf","cu","ct","lu","lt","defaultN1","defaultN2","defaultN3","defaultN4","defaultN5","defaultS1","defaultS2","defaultS3","defaultS4","defaultS5","flagnodate","movkind","printingorder","defaultv1","defaultv2","defaultv3","defaultv4","idsor01","idsor02","idsor03","idsor04","idsor05","defaultv5");
	tsorting1.ExtendedProperties["TableForReading"]="sorting";
	Tables.Add(tsorting1);
	tsorting1.defineKey("idsor");

	//////////////////// SORTING2 /////////////////////////////////
	var tsorting2= new sortingTable();
	tsorting2.TableName = "sorting2";
	tsorting2.addBaseColumns("idsorkind","idsor","sortcode","paridsor","nlevel","description","txt","rtf","cu","ct","lu","lt","defaultN1","defaultN2","defaultN3","defaultN4","defaultN5","defaultS1","defaultS2","defaultS3","defaultS4","defaultS5","flagnodate","movkind","printingorder","defaultv1","defaultv2","defaultv3","defaultv4","idsor01","idsor02","idsor03","idsor04","idsor05","defaultv5");
	tsorting2.ExtendedProperties["TableForReading"]="sorting";
	Tables.Add(tsorting2);
	tsorting2.defineKey("idsor");

	//////////////////// SORTING3 /////////////////////////////////
	var tsorting3= new sortingTable();
	tsorting3.TableName = "sorting3";
	tsorting3.addBaseColumns("idsorkind","idsor","sortcode","paridsor","nlevel","description","txt","rtf","cu","ct","lu","lt","defaultN1","defaultN2","defaultN3","defaultN4","defaultN5","defaultS1","defaultS2","defaultS3","defaultS4","defaultS5","flagnodate","movkind","printingorder","defaultv1","defaultv2","defaultv3","defaultv4","idsor01","idsor02","idsor03","idsor04","idsor05","defaultv5");
	tsorting3.ExtendedProperties["TableForReading"]="sorting";
	Tables.Add(tsorting3);
	tsorting3.defineKey("idsor");

	//////////////////// UPB /////////////////////////////////
	var tupb= new upbTable();
	tupb.addBaseColumns("idupb","codeupb","title","paridupb","idunderwriter","idman","requested","granted","previousappropriation","previousassessment","expiration","txt","rtf","cu","ct","lu","lt","assured","printingorder","active","idsor01","idsor02","idsor03","idsor04","idsor05");
	Tables.Add(tupb);
	tupb.defineKey("idupb");

	//////////////////// TAX /////////////////////////////////
	var ttax= new MetaTable("tax");
	ttax.defineColumn("taxcode", typeof(int),false);
	ttax.defineColumn("description", typeof(string),false);
	ttax.defineColumn("taxkind", typeof(short));
	ttax.defineColumn("fiscaltaxcode", typeof(string));
	ttax.defineColumn("flagunabatable", typeof(string));
	ttax.defineColumn("cu", typeof(string),false);
	ttax.defineColumn("ct", typeof(DateTime),false);
	ttax.defineColumn("lu", typeof(string),false);
	ttax.defineColumn("lt", typeof(DateTime),false);
	ttax.defineColumn("active", typeof(string));
	ttax.defineColumn("taxablecode", typeof(string));
	ttax.defineColumn("appliancebasis", typeof(string));
	ttax.defineColumn("geoappliance", typeof(string));
	ttax.defineColumn("idaccmotive_debit", typeof(string));
	ttax.defineColumn("idaccmotive_pay", typeof(string));
	ttax.defineColumn("idaccmotive_cost", typeof(string));
	ttax.defineColumn("taxref", typeof(string));
	Tables.Add(ttax);
	ttax.defineKey("taxcode");

	//////////////////// TAXRATEBRACKET /////////////////////////////////
	var ttaxratebracket= new MetaTable("taxratebracket");
	ttaxratebracket.defineColumn("taxcode", typeof(int),false);
	ttaxratebracket.defineColumn("idtaxratestart", typeof(int),false);
	ttaxratebracket.defineColumn("nbracket", typeof(short),false);
	ttaxratebracket.defineColumn("minamount", typeof(decimal));
	ttaxratebracket.defineColumn("maxamount", typeof(decimal));
	ttaxratebracket.defineColumn("admindenominator", typeof(decimal),false);
	ttaxratebracket.defineColumn("adminnumerator", typeof(decimal),false);
	ttaxratebracket.defineColumn("adminrate", typeof(decimal),false);
	ttaxratebracket.defineColumn("employdenominator", typeof(decimal),false);
	ttaxratebracket.defineColumn("employnumerator", typeof(decimal),false);
	ttaxratebracket.defineColumn("employrate", typeof(decimal),false);
	ttaxratebracket.defineColumn("lt", typeof(DateTime),false);
	ttaxratebracket.defineColumn("lu", typeof(string),false);
	Tables.Add(ttaxratebracket);
	ttaxratebracket.defineKey("taxcode", "idtaxratestart", "nbracket");

	//////////////////// CONFIG /////////////////////////////////
	var tconfig= new configTable();
	tconfig.addBaseColumns("ayear","agencycode","appname","flag_autodocnumbering","appropriationphasecode","assessmentphasecode","asset_flagnumbering","asset_flagrestart","assetload_flag","boxpartitiontitle","cashvaliditykind","casualcontract_flagrestart","ct","cu","currpartitiontitle","deferredexpensephase","deferredincomephase","electronicimport","electronictrasmission","expense_expiringdays","expensephase","flagautopayment","flagautoproceeds","flagcredit","flagepexp","flagfruitful","flagpayment","flagproceeds","flagrefund","foreignhours","idacc_accruedcost","idacc_accruedrevenue","idacc_customer","idacc_deferredcost","idacc_deferredcredit","idacc_deferreddebit","idacc_deferredrevenue","idacc_ivapayment","idacc_ivarefund","idacc_patrimony","idacc_pl","idacc_supplier","idaccmotive_admincar","idaccmotive_foot","idaccmotive_owncar","idclawback","idfinexpense","idfinexpensesurplus","idfinincomesurplus","idfinivapayment","idfinivarefund","idivapayperiodicity","idregauto","idsortingkind1","idsortingkind2","idsortingkind3","importappname","income_expiringdays","incomephase","linktoinvoice","lt","lu","minpayment","minrefund","motivelen","motiveprefix","motiveseparator","payment_finlevel","payment_flag","payment_flagautoprintdate","paymentagency","prevpartitiontitle","proceeds_finlevel","proceeds_flag","proceeds_flagautoprintdate","profservice_flagrestart","refundagency","wageaddition_flagrestart");
	Tables.Add(tconfig);
	tconfig.defineKey("ayear");

	//////////////////// PAYROLLTAXCORRIGE /////////////////////////////////
	var tpayrolltaxcorrige= new MetaTable("payrolltaxcorrige");
	tpayrolltaxcorrige.defineColumn("idpayroll", typeof(int),false);
	tpayrolltaxcorrige.defineColumn("idpayrolltaxcorrige", typeof(int),false);
	tpayrolltaxcorrige.defineColumn("taxcode", typeof(int),false);
	tpayrolltaxcorrige.defineColumn("ayear", typeof(short),false);
	tpayrolltaxcorrige.defineColumn("taxablegross", typeof(decimal));
	tpayrolltaxcorrige.defineColumn("taxablenet", typeof(decimal));
	tpayrolltaxcorrige.defineColumn("employamount", typeof(decimal));
	tpayrolltaxcorrige.defineColumn("adminamount", typeof(decimal));
	tpayrolltaxcorrige.defineColumn("idcity", typeof(int));
	tpayrolltaxcorrige.defineColumn("ct", typeof(DateTime),false);
	tpayrolltaxcorrige.defineColumn("cu", typeof(string),false);
	tpayrolltaxcorrige.defineColumn("lt", typeof(DateTime),false);
	tpayrolltaxcorrige.defineColumn("lu", typeof(string),false);
	tpayrolltaxcorrige.defineColumn("idfiscaltaxregion", typeof(string));
	Tables.Add(tpayrolltaxcorrige);
	tpayrolltaxcorrige.defineKey("idpayroll", "idpayrolltaxcorrige");

	//////////////////// ACCMOTIVEAPPLIED_DEBIT /////////////////////////////////
	var taccmotiveapplied_debit= new accmotiveappliedTable();
	taccmotiveapplied_debit.TableName = "accmotiveapplied_debit";
	taccmotiveapplied_debit.addBaseColumns("idaccmotive","paridaccmotive","codemotive","motive","cu","ct","lu","lt","active","idepoperation","epoperation","in_use","flagamm","flagdep");
	taccmotiveapplied_debit.ExtendedProperties["TableForReading"]="accmotiveapplied";
	Tables.Add(taccmotiveapplied_debit);
	taccmotiveapplied_debit.defineKey("idaccmotive");

	//////////////////// ACCMOTIVEAPPLIED_CRG /////////////////////////////////
	var taccmotiveapplied_crg= new accmotiveappliedTable();
	taccmotiveapplied_crg.TableName = "accmotiveapplied_crg";
	taccmotiveapplied_crg.addBaseColumns("idaccmotive","paridaccmotive","codemotive","motive","cu","ct","lu","lt","active","idepoperation","epoperation","in_use","flagamm","flagdep");
	taccmotiveapplied_crg.ExtendedProperties["TableForReading"]="accmotiveapplied";
	Tables.Add(taccmotiveapplied_crg);
	taccmotiveapplied_crg.defineKey("idaccmotive");

	//////////////////// SORTING01 /////////////////////////////////
	var tsorting01= new sortingTable();
	tsorting01.TableName = "sorting01";
	tsorting01.addBaseColumns("ct","cu","defaultN1","defaultN2","defaultN3","defaultN4","defaultN5","defaultS1","defaultS2","defaultS3","defaultS4","defaultS5","defaultv1","defaultv2","defaultv3","defaultv4","defaultv5","description","flagnodate","lt","lu","movkind","printingorder","rtf","sortcode","txt","idsorkind","idsor","paridsor","nlevel","start","stop");
	tsorting01.ExtendedProperties["TableForReading"]="sorting";
	Tables.Add(tsorting01);
	tsorting01.defineKey("idsor");

	//////////////////// SORTING02 /////////////////////////////////
	var tsorting02= new sortingTable();
	tsorting02.TableName = "sorting02";
	tsorting02.addBaseColumns("ct","cu","defaultN1","defaultN2","defaultN3","defaultN4","defaultN5","defaultS1","defaultS2","defaultS3","defaultS4","defaultS5","defaultv1","defaultv2","defaultv3","defaultv4","defaultv5","description","flagnodate","lt","lu","movkind","printingorder","rtf","sortcode","txt","idsorkind","idsor","paridsor","nlevel","start","stop");
	tsorting02.ExtendedProperties["TableForReading"]="sorting";
	Tables.Add(tsorting02);
	tsorting02.defineKey("idsor");

	//////////////////// SORTING03 /////////////////////////////////
	var tsorting03= new sortingTable();
	tsorting03.TableName = "sorting03";
	tsorting03.addBaseColumns("ct","cu","defaultN1","defaultN2","defaultN3","defaultN4","defaultN5","defaultS1","defaultS2","defaultS3","defaultS4","defaultS5","defaultv1","defaultv2","defaultv3","defaultv4","defaultv5","description","flagnodate","lt","lu","movkind","printingorder","rtf","sortcode","txt","idsorkind","idsor","paridsor","nlevel","start","stop");
	tsorting03.ExtendedProperties["TableForReading"]="sorting";
	Tables.Add(tsorting03);
	tsorting03.defineKey("idsor");

	//////////////////// SORTING04 /////////////////////////////////
	var tsorting04= new sortingTable();
	tsorting04.TableName = "sorting04";
	tsorting04.addBaseColumns("ct","cu","defaultN1","defaultN2","defaultN3","defaultN4","defaultN5","defaultS1","defaultS2","defaultS3","defaultS4","defaultS5","defaultv1","defaultv2","defaultv3","defaultv4","defaultv5","description","flagnodate","lt","lu","movkind","printingorder","rtf","sortcode","txt","idsorkind","idsor","paridsor","nlevel","start","stop");
	tsorting04.ExtendedProperties["TableForReading"]="sorting";
	Tables.Add(tsorting04);
	tsorting04.defineKey("idsor");

	//////////////////// SORTING05 /////////////////////////////////
	var tsorting05= new sortingTable();
	tsorting05.TableName = "sorting05";
	tsorting05.addBaseColumns("ct","cu","defaultN1","defaultN2","defaultN3","defaultN4","defaultN5","defaultS1","defaultS2","defaultS3","defaultS4","defaultS5","defaultv1","defaultv2","defaultv3","defaultv4","defaultv5","description","flagnodate","lt","lu","movkind","printingorder","rtf","sortcode","txt","idsorkind","idsor","paridsor","nlevel","start","stop");
	tsorting05.ExtendedProperties["TableForReading"]="sorting";
	Tables.Add(tsorting05);
	tsorting05.defineKey("idsor");

	//////////////////// DALIA_POSITION /////////////////////////////////
	var tdalia_position= new MetaTable("dalia_position");
	tdalia_position.defineColumn("iddaliaposition", typeof(int),false);
	tdalia_position.defineColumn("codedaliaposition", typeof(string));
	tdalia_position.defineColumn("description", typeof(string));
	Tables.Add(tdalia_position);
	tdalia_position.defineKey("iddaliaposition");

	//////////////////// SORTINGVIEW1 /////////////////////////////////
	var tsortingview1= new MetaTable("sortingview1");
	tsortingview1.defineColumn("codesorkind", typeof(string),false);
	tsortingview1.defineColumn("idsorkind", typeof(int),false);
	tsortingview1.defineColumn("sortingkind", typeof(string),false);
	tsortingview1.defineColumn("idsor", typeof(int),false);
	tsortingview1.defineColumn("sortcode", typeof(string),false);
	tsortingview1.defineColumn("nlevel", typeof(byte),false);
	tsortingview1.defineColumn("leveldescr", typeof(string),false);
	tsortingview1.defineColumn("paridsor", typeof(int));
	tsortingview1.defineColumn("description", typeof(string),false);
	tsortingview1.defineColumn("ayear", typeof(short),false);
	tsortingview1.defineColumn("incomeprevision", typeof(decimal));
	tsortingview1.defineColumn("expenseprevision", typeof(decimal));
	tsortingview1.defineColumn("start", typeof(short));
	tsortingview1.defineColumn("stop", typeof(short));
	tsortingview1.defineColumn("cu", typeof(string),false);
	tsortingview1.defineColumn("ct", typeof(DateTime),false);
	tsortingview1.defineColumn("lu", typeof(string),false);
	tsortingview1.defineColumn("lt", typeof(DateTime),false);
	tsortingview1.defineColumn("defaultn1", typeof(decimal));
	tsortingview1.defineColumn("defaultn2", typeof(decimal));
	tsortingview1.defineColumn("defaultn3", typeof(decimal));
	tsortingview1.defineColumn("defaultn4", typeof(decimal));
	tsortingview1.defineColumn("defaultn5", typeof(decimal));
	tsortingview1.defineColumn("defaults1", typeof(string));
	tsortingview1.defineColumn("defaults2", typeof(string));
	tsortingview1.defineColumn("defaults3", typeof(string));
	tsortingview1.defineColumn("defaults4", typeof(string));
	tsortingview1.defineColumn("defaults5", typeof(string));
	tsortingview1.defineColumn("flagnodate", typeof(string));
	tsortingview1.defineColumn("idsor01", typeof(int));
	tsortingview1.defineColumn("idsor02", typeof(int));
	tsortingview1.defineColumn("idsor03", typeof(int));
	tsortingview1.defineColumn("idsor04", typeof(int));
	tsortingview1.defineColumn("idsor05", typeof(int));
	tsortingview1.defineColumn("movkind", typeof(string));
	Tables.Add(tsortingview1);
	tsortingview1.defineKey("idsor");

	//////////////////// PAYROLL_ALTRIESERCIZI /////////////////////////////////
	var tpayroll_altriesercizi= new payrollTable();
	tpayroll_altriesercizi.TableName = "payroll_altriesercizi";
	tpayroll_altriesercizi.addBaseColumns("idpayroll","npayroll","disbursementdate","idresidence","workingdays","feegross","netfee","flagcomputed","flagbalance","idcon","currentrounding","lu","lt","cu","ct","enabletaxrelief","fiscalyear","start","stop","flagsummarybalance","idupb");
	tpayroll_altriesercizi.defineColumn("!codeupb_other", typeof(string));
	tpayroll_altriesercizi.ExtendedProperties["TableForReading"]="payroll";
	Tables.Add(tpayroll_altriesercizi);
	tpayroll_altriesercizi.defineKey("idpayroll");

	//////////////////// PARASUBCONTRACTVIEW /////////////////////////////////
	var tparasubcontractview= new MetaTable("parasubcontractview");
	tparasubcontractview.defineColumn("ayear", typeof(int),false);
	tparasubcontractview.defineColumn("idcon", typeof(string),false);
	tparasubcontractview.defineColumn("ycon", typeof(int),false);
	tparasubcontractview.defineColumn("ncon", typeof(string),false);
	tparasubcontractview.defineColumn("idreg", typeof(int),false);
	tparasubcontractview.defineColumn("idupb", typeof(string));
	tparasubcontractview.defineColumn("idsor01", typeof(int),true,true);
	tparasubcontractview.defineColumn("idsor02", typeof(int),true,true);
	tparasubcontractview.defineColumn("idsor03", typeof(int),true,true);
	tparasubcontractview.defineColumn("idsor04", typeof(int),true,true);
	tparasubcontractview.defineColumn("idsor05", typeof(int),true,true);
	tparasubcontractview.defineColumn("registry", typeof(string));
	tparasubcontractview.defineColumn("iddaliaposition", typeof(int));
	tparasubcontractview.defineColumn("codedaliaposition", typeof(string));
	tparasubcontractview.defineColumn("daliaposition", typeof(string));
	tparasubcontractview.defineColumn("matricula", typeof(int));
	tparasubcontractview.defineColumn("duty", typeof(string));
	tparasubcontractview.defineColumn("idpayrollkind", typeof(string));
	tparasubcontractview.defineColumn("payroll", typeof(string));
	tparasubcontractview.defineColumn("idser", typeof(int),false);
	tparasubcontractview.defineColumn("service", typeof(string));
	tparasubcontractview.defineColumn("codeser", typeof(string));
	tparasubcontractview.defineColumn("idresidence", typeof(int));
	tparasubcontractview.defineColumn("city", typeof(string));
	tparasubcontractview.defineColumn("idcountry", typeof(int));
	tparasubcontractview.defineColumn("country", typeof(string));
	tparasubcontractview.defineColumn("employed", typeof(string),false);
	tparasubcontractview.defineColumn("payrollccinfo", typeof(string),false);
	tparasubcontractview.defineColumn("start", typeof(DateTime),false);
	tparasubcontractview.defineColumn("stop", typeof(DateTime),false);
	tparasubcontractview.defineColumn("monthlen", typeof(int),false);
	tparasubcontractview.defineColumn("grossamount", typeof(decimal),false);
	tparasubcontractview.defineColumn("activitycode", typeof(string));
	tparasubcontractview.defineColumn("activity", typeof(string));
	tparasubcontractview.defineColumn("idotherinsurance", typeof(string));
	tparasubcontractview.defineColumn("otherinsurance", typeof(string));
	tparasubcontractview.defineColumn("idpat", typeof(int));
	tparasubcontractview.defineColumn("patcode", typeof(string));
	tparasubcontractview.defineColumn("pat", typeof(string));
	tparasubcontractview.defineColumn("idmatriculabook", typeof(string));
	tparasubcontractview.defineColumn("matriculabook", typeof(string));
	tparasubcontractview.defineColumn("regionaltax", typeof(decimal));
	tparasubcontractview.defineColumn("countrytax", typeof(decimal));
	tparasubcontractview.defineColumn("citytax", typeof(decimal));
	tparasubcontractview.defineColumn("ratequantity", typeof(int));
	tparasubcontractview.defineColumn("startmonth", typeof(int));
	tparasubcontractview.defineColumn("suspendedregionaltax", typeof(decimal));
	tparasubcontractview.defineColumn("suspendedcountrytax", typeof(decimal));
	tparasubcontractview.defineColumn("suspendedcitytax", typeof(decimal));
	tparasubcontractview.defineColumn("notaxappliance", typeof(string));
	tparasubcontractview.defineColumn("applybrackets", typeof(string));
	tparasubcontractview.defineColumn("highertax", typeof(decimal));
	tparasubcontractview.defineColumn("taxablecud", typeof(decimal));
	tparasubcontractview.defineColumn("cuddays", typeof(short));
	tparasubcontractview.defineColumn("taxablecontract", typeof(decimal));
	tparasubcontractview.defineColumn("ndays", typeof(int));
	tparasubcontractview.defineColumn("taxablepension", typeof(decimal));
	tparasubcontractview.defineColumn("fiscaldeduction", typeof(decimal));
	tparasubcontractview.defineColumn("notaxdeduction", typeof(decimal));
	tparasubcontractview.defineColumn("taxablegross", typeof(decimal));
	tparasubcontractview.defineColumn("taxablenet", typeof(decimal));
	tparasubcontractview.defineColumn("startcompetency", typeof(DateTime));
	tparasubcontractview.defineColumn("stopcompetency", typeof(DateTime));
	tparasubcontractview.defineColumn("idemenscontractkind", typeof(string));
	tparasubcontractview.defineColumn("txt", typeof(string));
	tparasubcontractview.defineColumn("emenscontractkind", typeof(string));
	tparasubcontractview.defineColumn("annualincome", typeof(decimal));
	tparasubcontractview.defineColumn("flagbonusappliance", typeof(string));
	tparasubcontractview.defineColumn("flagexcludefromcertificate", typeof(string));
	tparasubcontractview.defineColumn("citytax_account", typeof(decimal));
	tparasubcontractview.defineColumn("ratequantity_account", typeof(int));
	tparasubcontractview.defineColumn("startmonth_account", typeof(int));
	tparasubcontractview.defineColumn("idaccmotive", typeof(string));
	tparasubcontractview.defineColumn("codemotive", typeof(string));
	tparasubcontractview.defineColumn("idaccmotivedebit", typeof(string));
	tparasubcontractview.defineColumn("codemotivedebit", typeof(string));
	tparasubcontractview.defineColumn("idaccmotivedebit_crg", typeof(string));
	tparasubcontractview.defineColumn("codemotivedebit_crg", typeof(string));
	tparasubcontractview.defineColumn("idaccmotivedebit_datacrg", typeof(DateTime));
	tparasubcontractview.defineColumn("idsor1", typeof(int));
	tparasubcontractview.defineColumn("idsor2", typeof(int));
	tparasubcontractview.defineColumn("idsor3", typeof(int));
	tparasubcontractview.defineColumn("idrelated", typeof(string),true,true);
	tparasubcontractview.defineColumn("codeupb", typeof(string));
	tparasubcontractview.defineColumn("requested_doc", typeof(int));
	tparasubcontractview.defineColumn("sortcode1", typeof(string));
	tparasubcontractview.defineColumn("idcostpartition", typeof(int));
	Tables.Add(tparasubcontractview);
	tparasubcontractview.defineKey("ayear", "idcon");

	//////////////////// SORTING_SIOPE /////////////////////////////////
	var tsorting_siope= new sortingTable();
	tsorting_siope.TableName = "sorting_siope";
	tsorting_siope.addBaseColumns("ct","cu","defaultN1","defaultN2","defaultN3","defaultN4","defaultN5","defaultS1","defaultS2","defaultS3","defaultS4","defaultS5","defaultv1","defaultv2","defaultv3","defaultv4","defaultv5","description","flagnodate","lt","lu","movkind","printingorder","rtf","sortcode","txt","idsorkind","idsor","paridsor","nlevel","start","stop","idsor01","idsor02","idsor03","idsor04","idsor05","email");
	tsorting_siope.ExtendedProperties["TableForReading"]="sorting";
	Tables.Add(tsorting_siope);
	tsorting_siope.defineKey("idsor");

	//////////////////// DALIA_RECRUITMENTMOTIVE /////////////////////////////////
	var tdalia_recruitmentmotive= new MetaTable("dalia_recruitmentmotive");
	tdalia_recruitmentmotive.defineColumn("iddaliarecruitmentmotive", typeof(int),false);
	tdalia_recruitmentmotive.defineColumn("description", typeof(string),false);
	tdalia_recruitmentmotive.defineColumn("active", typeof(string),false);
	tdalia_recruitmentmotive.defineColumn("cu", typeof(string),false);
	tdalia_recruitmentmotive.defineColumn("ct", typeof(DateTime),false);
	tdalia_recruitmentmotive.defineColumn("lu", typeof(string),false);
	tdalia_recruitmentmotive.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(tdalia_recruitmentmotive);
	tdalia_recruitmentmotive.defineKey("iddaliarecruitmentmotive");

	//////////////////// UPB_PAYROLL /////////////////////////////////
	var tupb_payroll= new MetaTable("upb_payroll");
	tupb_payroll.defineColumn("idupb", typeof(string),false);
	tupb_payroll.defineColumn("codeupb", typeof(string),false);
	tupb_payroll.defineColumn("title", typeof(string),false);
	tupb_payroll.defineColumn("paridupb", typeof(string));
	tupb_payroll.defineColumn("idunderwriter", typeof(int));
	tupb_payroll.defineColumn("idman", typeof(int));
	tupb_payroll.defineColumn("requested", typeof(decimal));
	tupb_payroll.defineColumn("granted", typeof(decimal));
	tupb_payroll.defineColumn("previousappropriation", typeof(decimal));
	tupb_payroll.defineColumn("previousassessment", typeof(decimal));
	tupb_payroll.defineColumn("expiration", typeof(DateTime));
	tupb_payroll.defineColumn("txt", typeof(string));
	tupb_payroll.defineColumn("rtf", typeof(Byte[]));
	tupb_payroll.defineColumn("cu", typeof(string),false);
	tupb_payroll.defineColumn("ct", typeof(DateTime),false);
	tupb_payroll.defineColumn("lu", typeof(string),false);
	tupb_payroll.defineColumn("lt", typeof(DateTime),false);
	tupb_payroll.defineColumn("assured", typeof(string));
	tupb_payroll.defineColumn("printingorder", typeof(string),false);
	tupb_payroll.defineColumn("active", typeof(string));
	tupb_payroll.defineColumn("idsor01", typeof(int));
	tupb_payroll.defineColumn("idsor02", typeof(int));
	tupb_payroll.defineColumn("idsor03", typeof(int));
	tupb_payroll.defineColumn("idsor04", typeof(int));
	tupb_payroll.defineColumn("idsor05", typeof(int));
	Tables.Add(tupb_payroll);
	tupb_payroll.defineKey("idupb");

	//////////////////// UPB_PAYROLLOTHER /////////////////////////////////
	var tupb_payrollother= new MetaTable("upb_payrollother");
	tupb_payrollother.defineColumn("idupb", typeof(string),false);
	tupb_payrollother.defineColumn("codeupb", typeof(string),false);
	tupb_payrollother.defineColumn("title", typeof(string),false);
	tupb_payrollother.defineColumn("paridupb", typeof(string));
	tupb_payrollother.defineColumn("idunderwriter", typeof(int));
	tupb_payrollother.defineColumn("idman", typeof(int));
	tupb_payrollother.defineColumn("requested", typeof(decimal));
	tupb_payrollother.defineColumn("granted", typeof(decimal));
	tupb_payrollother.defineColumn("previousappropriation", typeof(decimal));
	tupb_payrollother.defineColumn("previousassessment", typeof(decimal));
	tupb_payrollother.defineColumn("expiration", typeof(DateTime));
	tupb_payrollother.defineColumn("txt", typeof(string));
	tupb_payrollother.defineColumn("rtf", typeof(Byte[]));
	tupb_payrollother.defineColumn("cu", typeof(string),false);
	tupb_payrollother.defineColumn("ct", typeof(DateTime),false);
	tupb_payrollother.defineColumn("lu", typeof(string),false);
	tupb_payrollother.defineColumn("lt", typeof(DateTime),false);
	tupb_payrollother.defineColumn("assured", typeof(string));
	tupb_payrollother.defineColumn("printingorder", typeof(string),false);
	tupb_payrollother.defineColumn("active", typeof(string));
	tupb_payrollother.defineColumn("idsor01", typeof(int));
	tupb_payrollother.defineColumn("idsor02", typeof(int));
	tupb_payrollother.defineColumn("idsor03", typeof(int));
	tupb_payrollother.defineColumn("idsor04", typeof(int));
	tupb_payrollother.defineColumn("idsor05", typeof(int));
	Tables.Add(tupb_payrollother);
	tupb_payrollother.defineKey("idupb");

	//////////////////// DALIA_DIPARTIMENTO /////////////////////////////////
	var tdalia_dipartimento= new dalia_dipartimentoTable();
	tdalia_dipartimento.addBaseColumns("iddalia_dipartimento","codedip","title","ct","cu","lt","lu");
	Tables.Add(tdalia_dipartimento);
	tdalia_dipartimento.defineKey("iddalia_dipartimento");

	//////////////////// DALIA_FUNZIONALE /////////////////////////////////
	var tdalia_funzionale= new dalia_funzionaleTable();
	tdalia_funzionale.addBaseColumns("iddalia_funzionale","codefunz","title","ct","cu","lt","lu");
	Tables.Add(tdalia_funzionale);
	tdalia_funzionale.defineKey("iddalia_funzionale");

	//////////////////// SERVICEATTACHMENTKIND /////////////////////////////////
	var tserviceattachmentkind= new MetaTable("serviceattachmentkind");
	tserviceattachmentkind.defineColumn("idattachmentkind", typeof(int),false);
	tserviceattachmentkind.defineColumn("title", typeof(string));
	tserviceattachmentkind.defineColumn("active", typeof(string));
	tserviceattachmentkind.defineColumn("idser", typeof(int));
	tserviceattachmentkind.defineColumn("flag", typeof(int));
	tserviceattachmentkind.defineColumn("flagforced", typeof(string));
	tserviceattachmentkind.defineColumn("ct", typeof(DateTime),false);
	tserviceattachmentkind.defineColumn("lu", typeof(string),false);
	tserviceattachmentkind.defineColumn("lt", typeof(DateTime),false);
	tserviceattachmentkind.defineColumn("cu", typeof(string),false);
	Tables.Add(tserviceattachmentkind);
	tserviceattachmentkind.defineKey("idattachmentkind");

	//////////////////// PARASUBCONTRACTATTACHMENT /////////////////////////////////
	var tparasubcontractattachment= new MetaTable("parasubcontractattachment");
	tparasubcontractattachment.defineColumn("idcon", typeof(string),false);
	tparasubcontractattachment.defineColumn("idattachment", typeof(int),false);
	tparasubcontractattachment.defineColumn("idattachmentkind", typeof(int));
	tparasubcontractattachment.defineColumn("attachment", typeof(Byte[]));
	tparasubcontractattachment.defineColumn("filename", typeof(string));
	tparasubcontractattachment.defineColumn("ct", typeof(DateTime),false);
	tparasubcontractattachment.defineColumn("cu", typeof(string),false);
	tparasubcontractattachment.defineColumn("lt", typeof(DateTime),false);
	tparasubcontractattachment.defineColumn("lu", typeof(string),false);
	tparasubcontractattachment.defineColumn("!serviceattachmentkind", typeof(string));
	Tables.Add(tparasubcontractattachment);
	tparasubcontractattachment.defineKey("idcon", "idattachment");

	//////////////////// COSTPARTITION /////////////////////////////////
	var tcostpartition= new MetaTable("costpartition");
	tcostpartition.defineColumn("idcostpartition", typeof(int),false);
	tcostpartition.defineColumn("title", typeof(string));
	tcostpartition.defineColumn("kind", typeof(string));
	tcostpartition.defineColumn("lt", typeof(DateTime));
	tcostpartition.defineColumn("lu", typeof(string));
	tcostpartition.defineColumn("ct", typeof(DateTime));
	tcostpartition.defineColumn("cu", typeof(string));
	tcostpartition.defineColumn("costpartitioncode", typeof(string));
	tcostpartition.defineColumn("active", typeof(string));
	tcostpartition.defineColumn("description", typeof(string));
	Tables.Add(tcostpartition);
	tcostpartition.defineKey("idcostpartition");

	#endregion


	#region DataRelation creation
	this.defineRelation("tax_payrolltaxcorrige","tax","payrolltaxcorrige","taxcode");
	this.defineRelation("payrollpayrolltaxcorrige","payroll","payrolltaxcorrige","idpayroll");
	this.defineRelation("parasubcontractcafdocument","parasubcontract","cafdocument","idcon");
	var cPar = new []{tipocomunicazione.Columns["codice"]};
	var cChild = new []{cafdocument.Columns["cafdocumentkind"]};
	Relations.Add(new DataRelation("tipocomunicazionecafdocument",cPar,cChild,false));

	this.defineRelation("parasubcontractexpensepayrollview","parasubcontract","expensepayrollview","idcon");
	this.defineRelation("parasubcontractparasubcontractsorting","parasubcontract","parasubcontractsorting","idcon");
	this.defineRelation("sortingparasubcontractsorting","sorting","parasubcontractsorting","idsor");
	this.defineRelation("parasubcontractparasubcontractyear","parasubcontract","parasubcontractyear","idcon");
	cPar = new []{geo_cityview.Columns["idcity"]};
	cChild = new []{parasubcontractyear.Columns["idresidence"]};
	Relations.Add(new DataRelation("geo_cityviewparasubcontractyear",cPar,cChild,false));

	this.defineRelation("otherinsuranceparasubcontractyear","otherinsurance","parasubcontractyear","idotherinsurance");
	this.defineRelation("inpsactivityparasubcontractyear","inpsactivity","parasubcontractyear","activitycode");
	this.defineRelation("emenscontractkindparasubcontractyear","emenscontractkind","parasubcontractyear","idemenscontractkind");
	this.defineRelation("payrolltaxpayrolltaxbracket","payrolltax","payrolltaxbracket","idpayroll","idpayrolltax");
	this.defineRelation("payrollpayrollabatement","payroll","payrollabatement","idpayroll");
	this.defineRelation("payrollpayrolldeduction","payroll","payrolldeduction","idpayroll");
	this.defineRelation("taxpayrolltax","tax","payrolltax","taxcode");
	this.defineRelation("payrollpayrolltax","payroll","payrolltax","idpayroll");
	this.defineRelation("parasubcontractotherinail","parasubcontract","otherinail","idcon");
	this.defineRelation("parasubcontractpayroll","parasubcontract","payroll","idcon");
	cPar = new []{geo_city.Columns["idcity"]};
	cChild = new []{payroll.Columns["idresidence"]};
	Relations.Add(new DataRelation("geo_citypayroll",cPar,cChild,false));

	cPar = new []{parasubcontractyear.Columns["ayear"], parasubcontractyear.Columns["idcon"]};
	cChild = new []{payroll.Columns["fiscalyear"], payroll.Columns["idcon"]};
	Relations.Add(new DataRelation("parasubcontractyearpayroll",cPar,cChild,false));

	this.defineRelation("parasubcontractparasubcontractfamily","parasubcontract","parasubcontractfamily","idcon");
	this.defineRelation("parasubcontractexhibitedcuddeduction","parasubcontract","exhibitedcuddeduction","idcon");
	this.defineRelation("exhibitedcudexhibitedcuddeduction","exhibitedcud","exhibitedcuddeduction","idcon","idexhibitedcud");
	this.defineRelation("deductioncodeexhibitedcuddeduction","deductioncode","exhibitedcuddeduction","iddeduction");
	this.defineRelation("exhibitedcudexhibitedcudabatement","exhibitedcud","exhibitedcudabatement","idcon","idexhibitedcud");
	this.defineRelation("parasubcontractexhibitedcudabatement","parasubcontract","exhibitedcudabatement","idcon");
	this.defineRelation("abatementcodeexhibitedcudabatement","abatementcode","exhibitedcudabatement","idabatement");
	this.defineRelation("parasubcontractexhibitedcud","parasubcontract","exhibitedcud","idcon");
	this.defineRelation("parasubcontractabatableexpense","parasubcontract","abatableexpense","idcon");
	this.defineRelation("abatementcodeabatableexpense","abatementcode","abatableexpense","idabatement");
	this.defineRelation("parasubcontractdeductibleexpense","parasubcontract","deductibleexpense","idcon");
	this.defineRelation("deductioncodedeductibleexpense","deductioncode","deductibleexpense","iddeduction");
	this.defineRelation("dalia_position_parasubcontract","dalia_position","parasubcontract","iddaliaposition");
	cPar = new []{sorting05.Columns["idsor"]};
	cChild = new []{parasubcontract.Columns["idsor05"]};
	Relations.Add(new DataRelation("sorting05_parasubcontract",cPar,cChild,false));

	cPar = new []{sorting04.Columns["idsor"]};
	cChild = new []{parasubcontract.Columns["idsor04"]};
	Relations.Add(new DataRelation("sorting04_parasubcontract",cPar,cChild,false));

	cPar = new []{sorting03.Columns["idsor"]};
	cChild = new []{parasubcontract.Columns["idsor03"]};
	Relations.Add(new DataRelation("sorting03_parasubcontract",cPar,cChild,false));

	cPar = new []{sorting02.Columns["idsor"]};
	cChild = new []{parasubcontract.Columns["idsor02"]};
	Relations.Add(new DataRelation("sorting02_parasubcontract",cPar,cChild,false));

	cPar = new []{sorting01.Columns["idsor"]};
	cChild = new []{parasubcontract.Columns["idsor01"]};
	Relations.Add(new DataRelation("sorting01_parasubcontract",cPar,cChild,false));

	cPar = new []{accmotiveapplied_crg.Columns["idaccmotive"]};
	cChild = new []{parasubcontract.Columns["idaccmotivedebit_crg"]};
	Relations.Add(new DataRelation("accmotiveapplied_crg_parasubcontract",cPar,cChild,false));

	cPar = new []{accmotiveapplied_debit.Columns["idaccmotive"]};
	cChild = new []{parasubcontract.Columns["idaccmotivedebit"]};
	Relations.Add(new DataRelation("accmotiveapplied_debit_parasubcontract",cPar,cChild,false));

	this.defineRelation("upbparasubcontract","upb","parasubcontract","idupb");
	cPar = new []{sorting3.Columns["idsor"]};
	cChild = new []{parasubcontract.Columns["idsor3"]};
	Relations.Add(new DataRelation("sorting3parasubcontract",cPar,cChild,false));

	cPar = new []{sorting2.Columns["idsor"]};
	cChild = new []{parasubcontract.Columns["idsor2"]};
	Relations.Add(new DataRelation("sorting2parasubcontract",cPar,cChild,false));

	cPar = new []{sorting1.Columns["idsor"]};
	cChild = new []{parasubcontract.Columns["idsor1"]};
	Relations.Add(new DataRelation("sorting1parasubcontract",cPar,cChild,false));

	this.defineRelation("accmotiveappliedparasubcontract","accmotiveapplied_cost","parasubcontract","idaccmotive");
	this.defineRelation("serviceparasubcontract","service","parasubcontract","idser");
	this.defineRelation("payrollkindparasubcontract","payrollkind","parasubcontract","idpayrollkind");
	this.defineRelation("matriculabookparasubcontract","matriculabook","parasubcontract","idmatriculabook");
	this.defineRelation("patparasubcontract","pat","parasubcontract","idpat");
	this.defineRelation("registryparasubcontract","registry","parasubcontract","idreg");
	this.defineRelation("parasubcontract_payroll_altriesercizi","parasubcontract","payroll_altriesercizi","idcon");
	this.defineRelation("payroll_altriesercizi_payrolltax","payroll_altriesercizi","payrolltax","idpayroll");
	cPar = new []{geo_city.Columns["idcity"]};
	cChild = new []{payroll_altriesercizi.Columns["idresidence"]};
	Relations.Add(new DataRelation("geo_city_payroll_altriesercizi",cPar,cChild,false));

	this.defineRelation("payroll_altriesercizi_payrolltaxcorrige","payroll_altriesercizi","payrolltaxcorrige","idpayroll");
	this.defineRelation("payroll_altriesercizi_payrolldeduction","payroll_altriesercizi","payrolldeduction","idpayroll");
	this.defineRelation("payroll_altriesercizi_payrollabatement","payroll_altriesercizi","payrollabatement","idpayroll");
	cPar = new []{sorting_siope.Columns["idsor"]};
	cChild = new []{parasubcontract.Columns["idsor_siope"]};
	Relations.Add(new DataRelation("sorting_siope_parasubcontract",cPar,cChild,false));

	this.defineRelation("dalia_recruitmentmotive_parasubcontract","dalia_recruitmentmotive","parasubcontract","iddaliarecruitmentmotive");
	this.defineRelation("upb_payrollother_payroll_altriesercizi","upb_payrollother","payroll_altriesercizi","idupb");
	this.defineRelation("upb_payroll_payroll","upb_payroll","payroll","idupb");
	this.defineRelation("dalia_dipartimento_parasubcontract","dalia_dipartimento","parasubcontract","iddalia_dipartimento");
	this.defineRelation("dalia_funzionale_parasubcontract","dalia_funzionale","parasubcontract","iddalia_funzionale");
	this.defineRelation("serviceattachmentkind_parasubcontractattachment","serviceattachmentkind","parasubcontractattachment","idattachmentkind");
	this.defineRelation("parasubcontract_parasubcontractattachment","parasubcontract","parasubcontractattachment","idcon");
	this.defineRelation("costpartition_parasubcontract","costpartition","parasubcontract","idcostpartition");
	#endregion

}
}
}
