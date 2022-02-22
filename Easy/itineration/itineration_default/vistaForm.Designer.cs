
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
using meta_itineration;
using meta_service;
using meta_registry;
using meta_itinerationrefund;
using meta_itinerationlap;
using meta_sorting;
using meta_upb;
using meta_accmotiveapplied;
using meta_config;
using meta_manager;
using meta_dalia_funzionale;
using meta_dalia_dipartimento;
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace itineration_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public itinerationTable itineration 		=> (itinerationTable)Tables["itineration"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public serviceTable service 		=> (serviceTable)Tables["service"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public registryTable registry 		=> (registryTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public itinerationrefundTable itinerationrefund_advance 		=> (itinerationrefundTable)Tables["itinerationrefund_advance"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public itinerationlapTable itinerationlap 		=> (itinerationlapTable)Tables["itinerationlap"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable itinerationtax 		=> (MetaTable)Tables["itinerationtax"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable itinerationparameter 		=> (MetaTable)Tables["itinerationparameter"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable allowanceabatement 		=> (MetaTable)Tables["allowanceabatement"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable itinerationrefundkind_advance 		=> (MetaTable)Tables["itinerationrefundkind_advance"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tax 		=> (MetaTable)Tables["tax"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingTable sorting 		=> (sortingTable)Tables["sorting"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable itinerationsorting 		=> (MetaTable)Tables["itinerationsorting"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public upbTable upb 		=> (upbTable)Tables["upb"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingTable sorting1 		=> (sortingTable)Tables["sorting1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingTable sorting2 		=> (sortingTable)Tables["sorting2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingTable sorting3 		=> (sortingTable)Tables["sorting3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accmotiveappliedTable accmotiveapplied_cost 		=> (accmotiveappliedTable)Tables["accmotiveapplied_cost"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable position 		=> (MetaTable)Tables["position"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable foreigncountry 		=> (MetaTable)Tables["foreigncountry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public configTable config 		=> (configTable)Tables["config"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accmotiveappliedTable accmotiveapplied_debit 		=> (accmotiveappliedTable)Tables["accmotiveapplied_debit"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accmotiveappliedTable accmotiveapplied_crg 		=> (accmotiveappliedTable)Tables["accmotiveapplied_crg"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public itinerationrefundTable itinerationrefund_balance 		=> (itinerationrefundTable)Tables["itinerationrefund_balance"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable itinerationrefundkind_balance 		=> (MetaTable)Tables["itinerationrefundkind_balance"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable itinerationstatus 		=> (MetaTable)Tables["itinerationstatus"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public managerTable manager 		=> (managerTable)Tables["manager"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable authmodel 		=> (MetaTable)Tables["authmodel"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable itinerationauthagency 		=> (MetaTable)Tables["itinerationauthagency"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable authagency 		=> (MetaTable)Tables["authagency"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable itinerationattachment 		=> (MetaTable)Tables["itinerationattachment"];

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
	public MetaTable legalstatuscontract 		=> (MetaTable)Tables["legalstatuscontract"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingTable sorting_siope 		=> (sortingTable)Tables["sorting_siope"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public itinerationTable itineration_riferimento 		=> (itinerationTable)Tables["itineration_riferimento"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable itinerationflights 		=> (MetaTable)Tables["itinerationflights"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrypaymethod 		=> (MetaTable)Tables["registrypaymethod"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable dalia_recruitmentmotive 		=> (MetaTable)Tables["dalia_recruitmentmotive"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public dalia_funzionaleTable dalia_funzionale 		=> (dalia_funzionaleTable)Tables["dalia_funzionale"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public dalia_dipartimentoTable dalia_dipartimento 		=> (dalia_dipartimentoTable)Tables["dalia_dipartimento"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable itinerationrefundattachment 		=> (MetaTable)Tables["itinerationrefundattachment"];

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
	//////////////////// ITINERATION /////////////////////////////////
	var titineration= new itinerationTable();
	titineration.addBaseColumns("yitineration","nitineration","description","idreg","idser","authorizationdate","start","stop","adate","admincarkmcost","owncarkmcost","footkmcost","admincarkm","owncarkm","footkm","grossfactor","netfee","totalgross","total","totadvance","txt","rtf","cu","ct","lu","lt","active","completed","idaccmotive","idupb","idsor1","idsor2","idsor3","iditineration","idaccmotivedebit","idaccmotivedebit_crg","idaccmotivedebit_datacrg","idregistrylegalstatus","flagweb","iditinerationstatus","applierannotations","idman","idauthmodel","webwarn","authneeded","authdoc","authdocdate","noauthreason","clause_accepted","vehicle_info","vehicle_motive","location","idsor01","idsor02","idsor03","idsor04","idsor05","datecompleted","iddaliaposition","additionalannotations","idsor_siope","iditineration_ref","supposedtravel","supposedliving","supposedfood","nfood","flagownfunds","idforeigncountry","advancepercentage","supposedamount","idregistrypaymethod","flagmove","flagoutside","advanceapplied","iddaliarecruitmentmotive","starttime","stoptime","iddalia_dipartimento","iddalia_funzionale");
	Tables.Add(titineration);
	titineration.defineKey("iditineration");

	//////////////////// SERVICE /////////////////////////////////
	var tservice= new serviceTable();
	tservice.addBaseColumns("idser","description","flagonlyfiscalabatement","ivaamount","certificatekind","cu","ct","lu","lt","itinerationvisible","active","flagdalia");
	Tables.Add(tservice);
	tservice.defineKey("idser");

	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new registryTable();
	tregistry.addBaseColumns("idreg","title","cf","p_iva","residence","annotation","birthdate","gender","surname","forename","foreigncf","active","txt","rtf","cu","ct","lu","lt","idaccmotivedebit");
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// ITINERATIONREFUND_ADVANCE /////////////////////////////////
	var titinerationrefund_advance= new itinerationrefundTable();
	titinerationrefund_advance.TableName = "itinerationrefund_advance";
	titinerationrefund_advance.addBaseColumns("nrefund","description","amount","extraallowance","idcurrency","iditinerationrefundkind","exchangerate","advancepercentage","cu","ct","lu","lt","flag_geo","starttime","stoptime","iditineration","flagadvancebalance","doc","docdate","requiredamount","docamount","webwarn","idforeigncountry","noaccount");
	titinerationrefund_advance.defineColumn("!importoeffettivo", typeof(decimal));
	titinerationrefund_advance.defineColumn("!indennsuppl", typeof(decimal));
	titinerationrefund_advance.defineColumn("!classificazione", typeof(string));
	titinerationrefund_advance.ExtendedProperties["TableForPosting"]="itinerationrefund";
	titinerationrefund_advance.ExtendedProperties["TableForReading"]="itinerationrefund";
	Tables.Add(titinerationrefund_advance);
	titinerationrefund_advance.defineKey("iditineration", "nrefund");

	//////////////////// ITINERATIONLAP /////////////////////////////////
	var titinerationlap= new itinerationlapTable();
	titinerationlap.addBaseColumns("lapnumber","flagitalian","idforeigncountry","starttime","stoptime","days","hours","idreduction","reductionpercentage","allowance","advancepercentage","description","cu","ct","lu","lt","iditineration");
	titinerationlap.defineColumn("!italiaestero", typeof(string));
	titinerationlap.defineColumn("!localita", typeof(string));
	titinerationlap.defineColumn("!indennita", typeof(decimal));
	titinerationlap.defineColumn("!indennitalorda", typeof(decimal));
	Tables.Add(titinerationlap);
	titinerationlap.defineKey("iditineration", "lapnumber");

	//////////////////// ITINERATIONTAX /////////////////////////////////
	var titinerationtax= new MetaTable("itinerationtax");
	titinerationtax.defineColumn("taxcode", typeof(int),false);
	titinerationtax.defineColumn("!ritenuta", typeof(string));
	titinerationtax.defineColumn("taxablenumerator", typeof(decimal));
	titinerationtax.defineColumn("taxabledenominator", typeof(decimal));
	titinerationtax.defineColumn("taxable", typeof(decimal));
	titinerationtax.defineColumn("employrate", typeof(decimal));
	titinerationtax.defineColumn("employnumerator", typeof(decimal));
	titinerationtax.defineColumn("employdenominator", typeof(decimal));
	titinerationtax.defineColumn("employtax", typeof(decimal));
	titinerationtax.defineColumn("adminrate", typeof(decimal));
	titinerationtax.defineColumn("adminnumerator", typeof(decimal));
	titinerationtax.defineColumn("admindenominator", typeof(decimal));
	titinerationtax.defineColumn("admintax", typeof(decimal));
	titinerationtax.defineColumn("cu", typeof(string),false);
	titinerationtax.defineColumn("ct", typeof(DateTime),false);
	titinerationtax.defineColumn("lu", typeof(string),false);
	titinerationtax.defineColumn("lt", typeof(DateTime),false);
	titinerationtax.defineColumn("iditineration", typeof(int),false);
	titinerationtax.defineColumn("!taxref", typeof(string));
	Tables.Add(titinerationtax);
	titinerationtax.defineKey("iditineration", "taxcode");

	//////////////////// ITINERATIONPARAMETER /////////////////////////////////
	var titinerationparameter= new MetaTable("itinerationparameter");
	titinerationparameter.defineColumn("start", typeof(DateTime),false);
	titinerationparameter.defineColumn("italianexemption", typeof(decimal));
	titinerationparameter.defineColumn("foreignexemption", typeof(decimal));
	titinerationparameter.defineColumn("cu", typeof(string),false);
	titinerationparameter.defineColumn("ct", typeof(DateTime),false);
	titinerationparameter.defineColumn("lu", typeof(string),false);
	titinerationparameter.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(titinerationparameter);
	titinerationparameter.defineKey("start");

	//////////////////// ALLOWANCEABATEMENT /////////////////////////////////
	var tallowanceabatement= new MetaTable("allowanceabatement");
	tallowanceabatement.defineColumn("idreduction", typeof(string),false);
	tallowanceabatement.defineColumn("start", typeof(DateTime),false);
	tallowanceabatement.defineColumn("groupnumber", typeof(short),false);
	tallowanceabatement.defineColumn("reductionpercentage", typeof(double),false);
	tallowanceabatement.defineColumn("exemptionreductionpercentage", typeof(double),false);
	tallowanceabatement.defineColumn("cu", typeof(string),false);
	tallowanceabatement.defineColumn("ct", typeof(DateTime),false);
	tallowanceabatement.defineColumn("lu", typeof(string),false);
	tallowanceabatement.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(tallowanceabatement);
	tallowanceabatement.defineKey("idreduction", "start", "groupnumber");

	//////////////////// ITINERATIONREFUNDKIND_ADVANCE /////////////////////////////////
	var titinerationrefundkind_advance= new MetaTable("itinerationrefundkind_advance");
	titinerationrefundkind_advance.defineColumn("iditinerationrefundkind", typeof(int),false);
	titinerationrefundkind_advance.defineColumn("codeitinerationrefundkind", typeof(string),false);
	titinerationrefundkind_advance.defineColumn("description", typeof(string),false);
	titinerationrefundkind_advance.defineColumn("cu", typeof(string),false);
	titinerationrefundkind_advance.defineColumn("ct", typeof(DateTime),false);
	titinerationrefundkind_advance.defineColumn("lu", typeof(string),false);
	titinerationrefundkind_advance.defineColumn("lt", typeof(DateTime),false);
	titinerationrefundkind_advance.defineColumn("idaccmotive", typeof(string));
	titinerationrefundkind_advance.defineColumn("iditinerationrefundkindgroup", typeof(int));
	titinerationrefundkind_advance.ExtendedProperties["TableForPosting"]="itinerationrefundkind";
	titinerationrefundkind_advance.ExtendedProperties["TableForReading"]="itinerationrefundkind";
	Tables.Add(titinerationrefundkind_advance);
	titinerationrefundkind_advance.defineKey("iditinerationrefundkind");

	//////////////////// TAX /////////////////////////////////
	var ttax= new MetaTable("tax");
	ttax.defineColumn("taxcode", typeof(int),false);
	ttax.defineColumn("description", typeof(string),false);
	ttax.defineColumn("taxkind", typeof(short),false);
	ttax.defineColumn("fiscaltaxcode", typeof(string));
	ttax.defineColumn("flagunabatable", typeof(string));
	ttax.defineColumn("cu", typeof(string),false);
	ttax.defineColumn("ct", typeof(DateTime),false);
	ttax.defineColumn("lu", typeof(string),false);
	ttax.defineColumn("lt", typeof(DateTime),false);
	ttax.defineColumn("idaccmotive_debit", typeof(string));
	ttax.defineColumn("idaccmotive_pay", typeof(string));
	ttax.defineColumn("idaccmotive_cost", typeof(string));
	ttax.defineColumn("taxref", typeof(string));
	Tables.Add(ttax);
	ttax.defineKey("taxcode");

	//////////////////// SORTING /////////////////////////////////
	var tsorting= new sortingTable();
	tsorting.addBaseColumns("idsorkind","idsor","sortcode","paridsor","nlevel","description","txt","rtf","cu","ct","lu","lt","defaultn1","defaultn2","defaultn3","defaultn4","defaultn5","defaults1","defaults2","defaults3","defaults4","defaults5","flagnodate","movkind","printingorder","defaultv1","defaultv2","defaultv3","defaultv4","idsor01","idsor02","idsor03","idsor04","idsor05","defaultv5");
	Tables.Add(tsorting);
	tsorting.defineKey("idsor");

	//////////////////// ITINERATIONSORTING /////////////////////////////////
	var titinerationsorting= new MetaTable("itinerationsorting");
	titinerationsorting.defineColumn("idsor", typeof(int),false);
	titinerationsorting.defineColumn("cu", typeof(string),false);
	titinerationsorting.defineColumn("ct", typeof(DateTime),false);
	titinerationsorting.defineColumn("lu", typeof(string),false);
	titinerationsorting.defineColumn("lt", typeof(DateTime),false);
	titinerationsorting.defineColumn("quota", typeof(decimal));
	titinerationsorting.defineColumn("!codiceclass", typeof(string));
	titinerationsorting.defineColumn("!descrizione", typeof(string));
	titinerationsorting.defineColumn("iditineration", typeof(int),false);
	Tables.Add(titinerationsorting);
	titinerationsorting.defineKey("iditineration", "idsor");

	//////////////////// UPB /////////////////////////////////
	var tupb= new upbTable();
	tupb.addBaseColumns("idupb","codeupb","title","paridupb","idunderwriter","idman","requested","granted","previousappropriation","previousassessment","expiration","txt","rtf","cu","ct","lu","lt","assured","printingorder","active","idsor01","idsor02","idsor03","idsor04","idsor05");
	Tables.Add(tupb);
	tupb.defineKey("idupb");

	//////////////////// SORTING1 /////////////////////////////////
	var tsorting1= new sortingTable();
	tsorting1.TableName = "sorting1";
	tsorting1.addBaseColumns("idsorkind","idsor","sortcode","paridsor","nlevel","description","txt","rtf","cu","ct","lu","lt","defaultN1","defaultN2","defaultN3","defaultN4","defaultN5","defaultS1","defaultS2","defaultS3","defaultS4","defaultS5","flagnodate","movkind","printingorder","defaultv1","defaultv2","defaultv3","defaultv4","idsor01","idsor02","idsor03","idsor04","idsor05","defaultv5");
	tsorting1.ExtendedProperties["TableForPosting"]="sorting";
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

	//////////////////// ACCMOTIVEAPPLIED_COST /////////////////////////////////
	var taccmotiveapplied_cost= new accmotiveappliedTable();
	taccmotiveapplied_cost.TableName = "accmotiveapplied_cost";
	taccmotiveapplied_cost.addBaseColumns("idaccmotive","paridaccmotive","codemotive","motive","cu","ct","lu","lt","active","idepoperation","epoperation","in_use","flagamm","flagdep");
	taccmotiveapplied_cost.ExtendedProperties["TableForReading"]="accmotiveapplied";
	Tables.Add(taccmotiveapplied_cost);
	taccmotiveapplied_cost.defineKey("idaccmotive");

	//////////////////// POSITION /////////////////////////////////
	var tposition= new MetaTable("position");
	tposition.defineColumn("idposition", typeof(int),false);
	tposition.defineColumn("active", typeof(string));
	tposition.defineColumn("ct", typeof(DateTime),false);
	tposition.defineColumn("cu", typeof(string),false);
	tposition.defineColumn("description", typeof(string),false);
	tposition.defineColumn("lt", typeof(DateTime),false);
	tposition.defineColumn("lu", typeof(string),false);
	tposition.defineColumn("maxincomeclass", typeof(short));
	tposition.defineColumn("foreignclass", typeof(string));
	Tables.Add(tposition);
	tposition.defineKey("idposition");

	//////////////////// FOREIGNCOUNTRY /////////////////////////////////
	var tforeigncountry= new MetaTable("foreigncountry");
	tforeigncountry.defineColumn("idforeigncountry", typeof(int),false);
	tforeigncountry.defineColumn("ct", typeof(DateTime),false);
	tforeigncountry.defineColumn("cu", typeof(string),false);
	tforeigncountry.defineColumn("description", typeof(string),false);
	tforeigncountry.defineColumn("lt", typeof(DateTime),false);
	tforeigncountry.defineColumn("lu", typeof(string),false);
	tforeigncountry.defineColumn("flag_ue", typeof(string));
	tforeigncountry.defineColumn("codeforeigncountry", typeof(string));
	Tables.Add(tforeigncountry);
	tforeigncountry.defineKey("idforeigncountry");

	//////////////////// CONFIG /////////////////////////////////
	var tconfig= new configTable();
	tconfig.addBaseColumns("ayear","agencycode","appname","appropriationphasecode","assessmentphasecode","asset_flagnumbering","asset_flagrestart","assetload_flag","boxpartitiontitle","cashvaliditykind","casualcontract_flagrestart","ct","cu","currpartitiontitle","deferredexpensephase","deferredincomephase","electronicimport","electronictrasmission","expense_expiringdays","expensephase","flagautopayment","flagautoproceeds","flagcredit","flagepexp","flagfruitful","flagpayment","flagproceeds","flagrefund","foreignhours","idacc_accruedcost","idacc_accruedrevenue","idacc_customer","idacc_deferredcost","idacc_deferredcredit","idacc_deferreddebit","idacc_deferredrevenue","idacc_ivapayment","idacc_ivarefund","idacc_patrimony","idacc_pl","idacc_supplier","idaccmotive_admincar","idaccmotive_foot","idaccmotive_owncar","idclawback","idfinexpense","idfinexpensesurplus","idfinincomesurplus","idfinivapayment","idfinivarefund","idivapayperiodicity","idregauto","idsortingkind1","idsortingkind2","idsortingkind3","importappname","income_expiringdays","incomephase","linktoinvoice","lt","lu","minpayment","minrefund","motivelen","motiveprefix","motiveseparator","payment_finlevel","payment_flag","payment_flagautoprintdate","paymentagency","prevpartitiontitle","proceeds_finlevel","proceeds_flag","proceeds_flagautoprintdate","profservice_flagrestart","refundagency","wageaddition_flagrestart");
	Tables.Add(tconfig);
	tconfig.defineKey("ayear");

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

	//////////////////// ITINERATIONREFUND_BALANCE /////////////////////////////////
	var titinerationrefund_balance= new itinerationrefundTable();
	titinerationrefund_balance.TableName = "itinerationrefund_balance";
	titinerationrefund_balance.addBaseColumns("nrefund","description","amount","extraallowance","idcurrency","iditinerationrefundkind","exchangerate","advancepercentage","cu","ct","lu","lt","flag_geo","starttime","stoptime","iditineration","flagadvancebalance","doc","docdate","requiredamount","docamount","webwarn","idforeigncountry","noaccount");
	titinerationrefund_balance.defineColumn("!importoeffettivo", typeof(decimal));
	titinerationrefund_balance.defineColumn("!indennsuppl", typeof(decimal));
	titinerationrefund_balance.defineColumn("!classificazione", typeof(string));
	titinerationrefund_balance.ExtendedProperties["TableForReading"]="itinerationrefund";
	Tables.Add(titinerationrefund_balance);
	titinerationrefund_balance.defineKey("iditineration", "nrefund");

	//////////////////// ITINERATIONREFUNDKIND_BALANCE /////////////////////////////////
	var titinerationrefundkind_balance= new MetaTable("itinerationrefundkind_balance");
	titinerationrefundkind_balance.defineColumn("iditinerationrefundkind", typeof(int),false);
	titinerationrefundkind_balance.defineColumn("codeitinerationrefundkind", typeof(string),false);
	titinerationrefundkind_balance.defineColumn("description", typeof(string),false);
	titinerationrefundkind_balance.defineColumn("cu", typeof(string),false);
	titinerationrefundkind_balance.defineColumn("ct", typeof(DateTime),false);
	titinerationrefundkind_balance.defineColumn("lu", typeof(string),false);
	titinerationrefundkind_balance.defineColumn("lt", typeof(DateTime),false);
	titinerationrefundkind_balance.defineColumn("idaccmotive", typeof(string));
	titinerationrefundkind_balance.defineColumn("iditinerationrefundkindgroup", typeof(int));
	titinerationrefundkind_balance.ExtendedProperties["TableForReading"]="itinerationrefundkind";
	Tables.Add(titinerationrefundkind_balance);
	titinerationrefundkind_balance.defineKey("iditinerationrefundkind");

	//////////////////// ITINERATIONSTATUS /////////////////////////////////
	var titinerationstatus= new MetaTable("itinerationstatus");
	titinerationstatus.defineColumn("ct", typeof(DateTime),false);
	titinerationstatus.defineColumn("cu", typeof(string),false);
	titinerationstatus.defineColumn("description", typeof(string),false);
	titinerationstatus.defineColumn("lt", typeof(DateTime),false);
	titinerationstatus.defineColumn("lu", typeof(string),false);
	titinerationstatus.defineColumn("iditinerationstatus", typeof(short),false);
	titinerationstatus.defineColumn("listingorder", typeof(short));
	Tables.Add(titinerationstatus);
	titinerationstatus.defineKey("iditinerationstatus");

	//////////////////// MANAGER /////////////////////////////////
	var tmanager= new managerTable();
	tmanager.addBaseColumns("active","ct","cu","email","lt","lu","passwordweb","phonenumber","rtf","title","txt","userweb","idman","iddivision","wantswarn","idsor01","idsor02","idsor03","idsor04","idsor05");
	Tables.Add(tmanager);
	tmanager.defineKey("idman");

	//////////////////// AUTHMODEL /////////////////////////////////
	var tauthmodel= new MetaTable("authmodel");
	tauthmodel.defineColumn("idauthmodel", typeof(int),false);
	tauthmodel.defineColumn("title", typeof(string),false);
	tauthmodel.defineColumn("description", typeof(string));
	tauthmodel.defineColumn("maxamount", typeof(decimal));
	tauthmodel.defineColumn("maxlen", typeof(int));
	tauthmodel.defineColumn("authfinrequired", typeof(string),false);
	tauthmodel.defineColumn("idsor01", typeof(int));
	tauthmodel.defineColumn("idsor02", typeof(int));
	tauthmodel.defineColumn("idsor03", typeof(int));
	tauthmodel.defineColumn("idsor04", typeof(int));
	tauthmodel.defineColumn("idsor05", typeof(int));
	tauthmodel.defineColumn("lu", typeof(string),false);
	tauthmodel.defineColumn("lt", typeof(DateTime),false);
	tauthmodel.defineColumn("active", typeof(string));
	Tables.Add(tauthmodel);
	tauthmodel.defineKey("idauthmodel");

	//////////////////// ITINERATIONAUTHAGENCY /////////////////////////////////
	var titinerationauthagency= new MetaTable("itinerationauthagency");
	titinerationauthagency.defineColumn("iditineration", typeof(int),false);
	titinerationauthagency.defineColumn("idauthagency", typeof(int),false);
	titinerationauthagency.defineColumn("flagstatus", typeof(string),false);
	titinerationauthagency.defineColumn("lu", typeof(string),false);
	titinerationauthagency.defineColumn("lt", typeof(DateTime),false);
	titinerationauthagency.defineColumn("!title", typeof(string));
	titinerationauthagency.defineColumn("!description", typeof(string));
	titinerationauthagency.defineColumn("!status", typeof(string));
	titinerationauthagency.defineColumn("annotationsrejectapproval", typeof(string));
	Tables.Add(titinerationauthagency);
	titinerationauthagency.defineKey("iditineration", "idauthagency");

	//////////////////// AUTHAGENCY /////////////////////////////////
	var tauthagency= new MetaTable("authagency");
	tauthagency.defineColumn("idauthagency", typeof(int),false);
	tauthagency.defineColumn("title", typeof(string),false);
	tauthagency.defineColumn("description", typeof(string));
	tauthagency.defineColumn("ismanager", typeof(string),false);
	tauthagency.defineColumn("lu", typeof(string),false);
	tauthagency.defineColumn("lt", typeof(DateTime),false);
	tauthagency.defineColumn("priority", typeof(int),false);
	Tables.Add(tauthagency);
	tauthagency.defineKey("idauthagency");

	//////////////////// ITINERATIONATTACHMENT /////////////////////////////////
	var titinerationattachment= new MetaTable("itinerationattachment");
	titinerationattachment.defineColumn("iditineration", typeof(int),false);
	titinerationattachment.defineColumn("idattachment", typeof(int),false);
	titinerationattachment.defineColumn("attachment", typeof(Byte[]));
	titinerationattachment.defineColumn("filename", typeof(string));
	titinerationattachment.defineColumn("lt", typeof(DateTime),false);
	titinerationattachment.defineColumn("lu", typeof(string),false);
	titinerationattachment.defineColumn("ct", typeof(DateTime),false);
	titinerationattachment.defineColumn("cu", typeof(string),false);
	titinerationattachment.defineColumn("description", typeof(string));
	titinerationattachment.defineColumn("active", typeof(string));
	Tables.Add(titinerationattachment);
	titinerationattachment.defineKey("iditineration", "idattachment");

	//////////////////// SORTING01 /////////////////////////////////
	var tsorting01= new sortingTable();
	tsorting01.TableName = "sorting01";
	tsorting01.addBaseColumns("ct","cu","defaultN1","defaultN2","defaultN3","defaultN4","defaultN5","defaultS1","defaultS2","defaultS3","defaultS4","defaultS5","defaultv1","defaultv2","defaultv3","defaultv4","defaultv5","description","flagnodate","lt","lu","movkind","printingorder","rtf","sortcode","txt","idsorkind","idsor","paridsor","nlevel","start","idsor01","idsor02","idsor03","idsor04","idsor05","stop");
	tsorting01.ExtendedProperties["TableForReading"]="sorting";
	Tables.Add(tsorting01);
	tsorting01.defineKey("idsor");

	//////////////////// SORTING02 /////////////////////////////////
	var tsorting02= new sortingTable();
	tsorting02.TableName = "sorting02";
	tsorting02.addBaseColumns("ct","cu","defaultN1","defaultN2","defaultN3","defaultN4","defaultN5","defaultS1","defaultS2","defaultS3","defaultS4","defaultS5","defaultv1","defaultv2","defaultv3","defaultv4","defaultv5","description","flagnodate","lt","lu","movkind","printingorder","rtf","sortcode","txt","idsorkind","idsor","paridsor","nlevel","start","idsor01","idsor02","idsor03","idsor04","idsor05","stop");
	tsorting02.ExtendedProperties["TableForReading"]="sorting";
	Tables.Add(tsorting02);
	tsorting02.defineKey("idsor");

	//////////////////// SORTING03 /////////////////////////////////
	var tsorting03= new sortingTable();
	tsorting03.TableName = "sorting03";
	tsorting03.addBaseColumns("ct","cu","defaultN1","defaultN2","defaultN3","defaultN4","defaultN5","defaultS1","defaultS2","defaultS3","defaultS4","defaultS5","defaultv1","defaultv2","defaultv3","defaultv4","defaultv5","description","flagnodate","lt","lu","movkind","printingorder","rtf","sortcode","txt","idsorkind","idsor","paridsor","nlevel","start","idsor01","idsor02","idsor03","idsor04","idsor05","stop");
	tsorting03.ExtendedProperties["TableForReading"]="sorting";
	Tables.Add(tsorting03);
	tsorting03.defineKey("idsor");

	//////////////////// SORTING04 /////////////////////////////////
	var tsorting04= new sortingTable();
	tsorting04.TableName = "sorting04";
	tsorting04.addBaseColumns("ct","cu","defaultN1","defaultN2","defaultN3","defaultN4","defaultN5","defaultS1","defaultS2","defaultS3","defaultS4","defaultS5","defaultv1","defaultv2","defaultv3","defaultv4","defaultv5","description","flagnodate","lt","lu","movkind","printingorder","rtf","sortcode","txt","idsorkind","idsor","paridsor","nlevel","start","idsor01","idsor02","idsor03","idsor04","idsor05","stop");
	tsorting04.ExtendedProperties["TableForReading"]="sorting";
	Tables.Add(tsorting04);
	tsorting04.defineKey("idsor");

	//////////////////// SORTING05 /////////////////////////////////
	var tsorting05= new sortingTable();
	tsorting05.TableName = "sorting05";
	tsorting05.addBaseColumns("ct","cu","defaultN1","defaultN2","defaultN3","defaultN4","defaultN5","defaultS1","defaultS2","defaultS3","defaultS4","defaultS5","defaultv1","defaultv2","defaultv3","defaultv4","defaultv5","description","flagnodate","lt","lu","movkind","printingorder","rtf","sortcode","txt","idsorkind","idsor","paridsor","nlevel","start","idsor01","idsor02","idsor03","idsor04","idsor05","stop");
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

	//////////////////// LEGALSTATUSCONTRACT /////////////////////////////////
	var tlegalstatuscontract= new MetaTable("legalstatuscontract");
	tlegalstatuscontract.defineColumn("idreg", typeof(int),false);
	tlegalstatuscontract.defineColumn("idregistrylegalstatus", typeof(int),false);
	tlegalstatuscontract.defineColumn("idposition", typeof(int));
	tlegalstatuscontract.defineColumn("codeposition", typeof(string),false);
	tlegalstatuscontract.defineColumn("position", typeof(string),false);
	tlegalstatuscontract.defineColumn("incomeclass", typeof(short),true,true);
	tlegalstatuscontract.defineColumn("incomeclassvalidity", typeof(DateTime));
	tlegalstatuscontract.defineColumn("maxincomeclass", typeof(short));
	tlegalstatuscontract.defineColumn("start", typeof(DateTime),false);
	tlegalstatuscontract.defineColumn("stop", typeof(DateTime));
	tlegalstatuscontract.defineColumn("csa_compartment", typeof(string));
	tlegalstatuscontract.defineColumn("csa_role", typeof(string));
	tlegalstatuscontract.defineColumn("csa_class", typeof(string));
	tlegalstatuscontract.defineColumn("csa_description", typeof(string));
	Tables.Add(tlegalstatuscontract);
	tlegalstatuscontract.defineKey("idreg", "idregistrylegalstatus");

	//////////////////// SORTING_SIOPE /////////////////////////////////
	var tsorting_siope= new sortingTable();
	tsorting_siope.TableName = "sorting_siope";
	tsorting_siope.addBaseColumns("ct","cu","defaultN1","defaultN2","defaultN3","defaultN4","defaultN5","defaultS1","defaultS2","defaultS3","defaultS4","defaultS5","defaultv1","defaultv2","defaultv3","defaultv4","defaultv5","description","flagnodate","lt","lu","movkind","printingorder","rtf","sortcode","txt","idsorkind","idsor","paridsor","nlevel","start","stop","idsor01","idsor02","idsor03","idsor04","idsor05","email");
	tsorting_siope.ExtendedProperties["TableForReading"]="sorting";
	Tables.Add(tsorting_siope);
	tsorting_siope.defineKey("idsor");

	//////////////////// ITINERATION_RIFERIMENTO /////////////////////////////////
	var titineration_riferimento= new itinerationTable();
	titineration_riferimento.TableName = "itineration_riferimento";
	titineration_riferimento.addBaseColumns("yitineration","nitineration","description","idreg","idser","authorizationdate","start","stop","adate","admincarkmcost","owncarkmcost","footkmcost","admincarkm","owncarkm","footkm","grossfactor","netfee","totalgross","total","totadvance","txt","rtf","cu","ct","lu","lt","active","completed","idaccmotive","idupb","idsor1","idsor2","idsor3","iditineration","idaccmotivedebit","idaccmotivedebit_crg","idaccmotivedebit_datacrg","idregistrylegalstatus","flagweb","iditinerationstatus","applierannotations","idman","idauthmodel","webwarn","authneeded","authdoc","authdocdate","noauthreason","clause_accepted","vehicle_info","vehicle_motive","location","idsor01","idsor02","idsor03","idsor04","idsor05","datecompleted","iddaliaposition","additionalannotations","idsor_siope","iditineration_ref");
	titineration_riferimento.ExtendedProperties["TableForReading"]="itineration";
	Tables.Add(titineration_riferimento);
	titineration_riferimento.defineKey("iditineration");

	//////////////////// ITINERATIONFLIGHTS /////////////////////////////////
	var titinerationflights= new MetaTable("itinerationflights");
	titinerationflights.defineColumn("idflights", typeof(int),false);
	titinerationflights.defineColumn("iditineration", typeof(int),false);
	titinerationflights.defineColumn("fromlocation", typeof(string));
	titinerationflights.defineColumn("tolocation", typeof(string));
	titinerationflights.defineColumn("cu", typeof(string),false);
	titinerationflights.defineColumn("ct", typeof(DateTime),false);
	titinerationflights.defineColumn("lu", typeof(string),false);
	titinerationflights.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(titinerationflights);
	titinerationflights.defineKey("idflights", "iditineration");

	//////////////////// REGISTRYPAYMETHOD /////////////////////////////////
	var tregistrypaymethod= new MetaTable("registrypaymethod");
	tregistrypaymethod.defineColumn("idreg", typeof(int),false);
	tregistrypaymethod.defineColumn("idregistrypaymethod", typeof(int),false);
	tregistrypaymethod.defineColumn("regmodcode", typeof(string),false);
	tregistrypaymethod.defineColumn("active", typeof(string));
	tregistrypaymethod.defineColumn("cc", typeof(string));
	tregistrypaymethod.defineColumn("cin", typeof(string));
	tregistrypaymethod.defineColumn("ct", typeof(DateTime),false);
	tregistrypaymethod.defineColumn("cu", typeof(string),false);
	tregistrypaymethod.defineColumn("flagstandard", typeof(string));
	tregistrypaymethod.defineColumn("iban", typeof(string));
	tregistrypaymethod.defineColumn("idbank", typeof(string));
	tregistrypaymethod.defineColumn("idcab", typeof(string));
	tregistrypaymethod.defineColumn("iddeputy", typeof(int));
	tregistrypaymethod.defineColumn("lt", typeof(DateTime),false);
	tregistrypaymethod.defineColumn("lu", typeof(string),false);
	tregistrypaymethod.defineColumn("paymentdescr", typeof(string));
	tregistrypaymethod.defineColumn("paymentexpiring", typeof(short));
	tregistrypaymethod.defineColumn("rtf", typeof(Byte[]));
	tregistrypaymethod.defineColumn("txt", typeof(string));
	tregistrypaymethod.defineColumn("refexternaldoc", typeof(string));
	tregistrypaymethod.defineColumn("idcurrency", typeof(int));
	tregistrypaymethod.defineColumn("idpaymethod", typeof(int));
	tregistrypaymethod.defineColumn("idexpirationkind", typeof(short));
	tregistrypaymethod.defineColumn("extracode", typeof(string));
	tregistrypaymethod.defineColumn("biccode", typeof(string));
	tregistrypaymethod.defineColumn("flag", typeof(int));
	tregistrypaymethod.defineColumn("idchargehandling", typeof(int));
	tregistrypaymethod.defineColumn("notes", typeof(string));
	tregistrypaymethod.defineColumn("ccdedicato_doc", typeof(Byte[]));
	tregistrypaymethod.defineColumn("ccdedicato_cf", typeof(Byte[]));
	tregistrypaymethod.defineColumn("requested_doc", typeof(int));
	Tables.Add(tregistrypaymethod);
	tregistrypaymethod.defineKey("idreg", "idregistrypaymethod");

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

	//////////////////// DALIA_FUNZIONALE /////////////////////////////////
	var tdalia_funzionale= new dalia_funzionaleTable();
	tdalia_funzionale.addBaseColumns("iddalia_funzionale","codefunz","title","ct","cu","lt","lu");
	Tables.Add(tdalia_funzionale);
	tdalia_funzionale.defineKey("iddalia_funzionale");

	//////////////////// DALIA_DIPARTIMENTO /////////////////////////////////
	var tdalia_dipartimento= new dalia_dipartimentoTable();
	tdalia_dipartimento.addBaseColumns("iddalia_dipartimento","codedip","title","ct","cu","lt","lu");
	Tables.Add(tdalia_dipartimento);
	tdalia_dipartimento.defineKey("iddalia_dipartimento");

	//////////////////// ITINERATIONREFUNDATTACHMENT /////////////////////////////////
	var titinerationrefundattachment= new MetaTable("itinerationrefundattachment");
	titinerationrefundattachment.defineColumn("idattachment", typeof(int),false);
	titinerationrefundattachment.defineColumn("iditineration", typeof(int),false);
	titinerationrefundattachment.defineColumn("nrefund", typeof(short),false);
	titinerationrefundattachment.defineColumn("attachment", typeof(Byte[]));
	titinerationrefundattachment.defineColumn("filename", typeof(string));
	titinerationrefundattachment.defineColumn("description", typeof(string));
	titinerationrefundattachment.defineColumn("cu", typeof(string),false);
	titinerationrefundattachment.defineColumn("ct", typeof(DateTime),false);
	titinerationrefundattachment.defineColumn("lu", typeof(string),false);
	titinerationrefundattachment.defineColumn("lt", typeof(string),false);
	titinerationrefundattachment.defineColumn("active", typeof(string));
	Tables.Add(titinerationrefundattachment);
	titinerationrefundattachment.defineKey("idattachment", "iditineration", "nrefund");

	#endregion


	#region DataRelation creation
	this.defineRelation("itineration_itinerationauthagency","itineration","itinerationauthagency","iditineration");
	this.defineRelation("authagency_itinerationauthagency","authagency","itinerationauthagency","idauthagency");
	this.defineRelation("itinerationrefundkind_balance_itinerationrefund_balance","itinerationrefundkind_balance","itinerationrefund_balance","iditinerationrefundkind");
	this.defineRelation("itineration_itinerationrefund_balance","itineration","itinerationrefund_balance","iditineration");
	this.defineRelation("itinerationitinerationsorting","itineration","itinerationsorting","iditineration");
	this.defineRelation("sortingitinerationsorting","sorting","itinerationsorting","idsor");
	this.defineRelation("itinerationitinerationlap","itineration","itinerationlap","iditineration");
	this.defineRelation("itinerationitinerationrefund","itineration","itinerationrefund_advance","iditineration");
	this.defineRelation("accmotiveapplied_itineration","accmotiveapplied_cost","itineration","idaccmotive");
	var cPar = new []{sorting1.Columns["idsor"]};
	var cChild = new []{itineration.Columns["idsor1"]};
	Relations.Add(new DataRelation("sorting1itineration",cPar,cChild,false));

	cPar = new []{sorting2.Columns["idsor"]};
	cChild = new []{itineration.Columns["idsor2"]};
	Relations.Add(new DataRelation("sorting2itineration",cPar,cChild,false));

	cPar = new []{sorting3.Columns["idsor"]};
	cChild = new []{itineration.Columns["idsor3"]};
	Relations.Add(new DataRelation("sorting3itineration",cPar,cChild,false));

	cPar = new []{accmotiveapplied_debit.Columns["idaccmotive"]};
	cChild = new []{itineration.Columns["idaccmotivedebit"]};
	Relations.Add(new DataRelation("accmotiveapplied_debit_itineration",cPar,cChild,false));

	cPar = new []{accmotiveapplied_crg.Columns["idaccmotive"]};
	cChild = new []{itineration.Columns["idaccmotivedebit_crg"]};
	Relations.Add(new DataRelation("accmotiveapplied_crg_itineration",cPar,cChild,false));

	this.defineRelation("manager_itineration","manager","itineration","idman");
	cPar = new []{sorting01.Columns["idsor"]};
	cChild = new []{itineration.Columns["idsor01"]};
	Relations.Add(new DataRelation("sorting01_itineration",cPar,cChild,false));

	cPar = new []{sorting02.Columns["idsor"]};
	cChild = new []{itineration.Columns["idsor02"]};
	Relations.Add(new DataRelation("sorting02_itineration",cPar,cChild,false));

	cPar = new []{sorting03.Columns["idsor"]};
	cChild = new []{itineration.Columns["idsor03"]};
	Relations.Add(new DataRelation("sorting03_itineration",cPar,cChild,false));

	cPar = new []{sorting04.Columns["idsor"]};
	cChild = new []{itineration.Columns["idsor04"]};
	Relations.Add(new DataRelation("sorting04_itineration",cPar,cChild,false));

	cPar = new []{sorting05.Columns["idsor"]};
	cChild = new []{itineration.Columns["idsor05"]};
	Relations.Add(new DataRelation("sorting05_itineration",cPar,cChild,false));

	cPar = new []{sorting_siope.Columns["idsor"]};
	cChild = new []{itineration.Columns["idsor_siope"]};
	Relations.Add(new DataRelation("sorting_siope_itineration",cPar,cChild,false));

	this.defineRelation("itinerationitinerationtax","itineration","itinerationtax","iditineration");
	this.defineRelation("taxitinerationtax","tax","itinerationtax","taxcode");
	this.defineRelation("serviceitineration","service","itineration","idser");
	this.defineRelation("upbitineration","upb","itineration","idupb");
	this.defineRelation("itinerationstatus_itineration","itinerationstatus","itineration","iditinerationstatus");
	this.defineRelation("foreigncountry_itinerationlap","foreigncountry","itinerationlap","idforeigncountry");
	this.defineRelation("authmodel_itineration","authmodel","itineration","idauthmodel");
	this.defineRelation("itinerationrefundkinditinerationrefund","itinerationrefundkind_advance","itinerationrefund_advance","iditinerationrefundkind");
	this.defineRelation("registryitineration","registry","itineration","idreg");
	this.defineRelation("dalia_position_itineration","dalia_position","itineration","iddaliaposition");
	this.defineRelation("itineration_itinerationattachment","itineration","itinerationattachment","iditineration");
	cPar = new []{itineration_riferimento.Columns["iditineration"]};
	cChild = new []{itineration.Columns["iditineration_ref"]};
	Relations.Add(new DataRelation("itineration_riferimento_itineration",cPar,cChild,false));

	this.defineRelation("itineration_itinerationflights","itineration","itinerationflights","iditineration");
	this.defineRelation("registrypaymethod_itineration","registrypaymethod","itineration","idreg","idregistrypaymethod");
	this.defineRelation("dalia_recruitmentmotive_itineration","dalia_recruitmentmotive","itineration","iddaliarecruitmentmotive");
	this.defineRelation("dalia_funzionale_itineration","dalia_funzionale","itineration","iddalia_funzionale");
	this.defineRelation("dalia_dipartimento_itineration","dalia_dipartimento","itineration","iddalia_dipartimento");
	this.defineRelation("itinerationrefund_advance_itinerationrefundattachment","itinerationrefund_advance","itinerationrefundattachment","iditineration","nrefund");
	this.defineRelation("itinerationrefund_balance_itinerationrefundattachment","itinerationrefund_balance","itinerationrefundattachment","iditineration","nrefund");
	#endregion

}
}
}
