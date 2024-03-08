
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
[System.Xml.Serialization.XmlRoot("dsmeta_registry_aziende"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_registry_aziende: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_city_alias2 		=> (MetaTable)Tables["geo_city_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sede 		=> (MetaTable)Tables["sede"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryreference 		=> (MetaTable)Tables["registryreference"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryprogfinbandoattach 		=> (MetaTable)Tables["registryprogfinbandoattach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryprogfinbando 		=> (MetaTable)Tables["registryprogfinbando"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryprogfin 		=> (MetaTable)Tables["registryprogfin"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_nation_alias5 		=> (MetaTable)Tables["geo_nation_alias5"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_city_alias5 		=> (MetaTable)Tables["geo_city_alias5"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable address 		=> (MetaTable)Tables["address"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryaddress 		=> (MetaTable)Tables["registryaddress"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ccnl 		=> (MetaTable)Tables["ccnl"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ccnlregistry_aziende 		=> (MetaTable)Tables["ccnlregistry_aziende"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable numerodip 		=> (MetaTable)Tables["numerodip"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable naturagiurdefaultview 		=> (MetaTable)Tables["naturagiurdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable nacedefaultview 		=> (MetaTable)Tables["nacedefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accmotivedefaultview_alias1 		=> (MetaTable)Tables["accmotivedefaultview_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable atecodefaultview 		=> (MetaTable)Tables["atecodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accmotivedefaultview 		=> (MetaTable)Tables["accmotivedefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_city 		=> (MetaTable)Tables["geo_city"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_nation 		=> (MetaTable)Tables["geo_nation"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable residence 		=> (MetaTable)Tables["residence"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryclassaziendeview 		=> (MetaTable)Tables["registryclassaziendeview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable category 		=> (MetaTable)Tables["category"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrykind 		=> (MetaTable)Tables["registrykind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry 		=> (MetaTable)Tables["registry"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_registry_aziende(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_registry_aziende (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_registry_aziende";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_registry_aziende.xsd";

	#region create DataTables
	//////////////////// GEO_CITY_ALIAS2 /////////////////////////////////
	var tgeo_city_alias2= new MetaTable("geo_city_alias2");
	tgeo_city_alias2.defineColumn("idcity", typeof(int),false);
	tgeo_city_alias2.defineColumn("title", typeof(string));
	tgeo_city_alias2.ExtendedProperties["TableForReading"]="geo_city";
	Tables.Add(tgeo_city_alias2);
	tgeo_city_alias2.defineKey("idcity");

	//////////////////// SEDE /////////////////////////////////
	var tsede= new MetaTable("sede");
	tsede.defineColumn("address", typeof(string));
	tsede.defineColumn("annotations", typeof(string));
	tsede.defineColumn("cap", typeof(string));
	tsede.defineColumn("ct", typeof(DateTime),false);
	tsede.defineColumn("cu", typeof(string),false);
	tsede.defineColumn("idcity", typeof(int));
	tsede.defineColumn("idnation", typeof(int));
	tsede.defineColumn("idreg", typeof(int));
	tsede.defineColumn("idsede", typeof(int),false);
	tsede.defineColumn("idsedemiur", typeof(int));
	tsede.defineColumn("latitude", typeof(decimal));
	tsede.defineColumn("longitude", typeof(decimal));
	tsede.defineColumn("lt", typeof(DateTime),false);
	tsede.defineColumn("lu", typeof(string),false);
	tsede.defineColumn("title", typeof(string));
	tsede.defineColumn("!idcity_geo_city_title", typeof(string));
	tsede.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tsede);
	tsede.defineKey("idsede");

	//////////////////// REGISTRYREFERENCE /////////////////////////////////
	var tregistryreference= new MetaTable("registryreference");
	tregistryreference.defineColumn("activeweb", typeof(string));
	tregistryreference.defineColumn("ct", typeof(DateTime),false);
	tregistryreference.defineColumn("cu", typeof(string),false);
	tregistryreference.defineColumn("email", typeof(string));
	tregistryreference.defineColumn("faxnumber", typeof(string));
	tregistryreference.defineColumn("flagdefault", typeof(string));
	tregistryreference.defineColumn("idreg", typeof(int),false);
	tregistryreference.defineColumn("idregistryreference", typeof(int),false);
	tregistryreference.defineColumn("iterweb", typeof(int));
	tregistryreference.defineColumn("lt", typeof(DateTime),false);
	tregistryreference.defineColumn("lu", typeof(string),false);
	tregistryreference.defineColumn("mobilenumber", typeof(string));
	tregistryreference.defineColumn("msnnumber", typeof(string));
	tregistryreference.defineColumn("passwordweb", typeof(string));
	tregistryreference.defineColumn("pec", typeof(string));
	tregistryreference.defineColumn("phonenumber", typeof(string));
	tregistryreference.defineColumn("referencename", typeof(string),false);
	tregistryreference.defineColumn("registryreferencerole", typeof(string));
	tregistryreference.defineColumn("rtf", typeof(Byte[]));
	tregistryreference.defineColumn("saltweb", typeof(string));
	tregistryreference.defineColumn("skypenumber", typeof(string));
	tregistryreference.defineColumn("txt", typeof(string));
	tregistryreference.defineColumn("userweb", typeof(string));
	tregistryreference.defineColumn("website", typeof(string));
	Tables.Add(tregistryreference);
	tregistryreference.defineKey("idreg", "idregistryreference");

	//////////////////// REGISTRYPROGFINBANDOATTACH /////////////////////////////////
	var tregistryprogfinbandoattach= new MetaTable("registryprogfinbandoattach");
	tregistryprogfinbandoattach.defineColumn("ct", typeof(DateTime),false);
	tregistryprogfinbandoattach.defineColumn("cu", typeof(string),false);
	tregistryprogfinbandoattach.defineColumn("idattach", typeof(int),false);
	tregistryprogfinbandoattach.defineColumn("idreg", typeof(int),false);
	tregistryprogfinbandoattach.defineColumn("idregistryprogfin", typeof(int),false);
	tregistryprogfinbandoattach.defineColumn("idregistryprogfinbando", typeof(int),false);
	tregistryprogfinbandoattach.defineColumn("lt", typeof(DateTime),false);
	tregistryprogfinbandoattach.defineColumn("lu", typeof(string),false);
	tregistryprogfinbandoattach.defineColumn("title", typeof(string));
	Tables.Add(tregistryprogfinbandoattach);
	tregistryprogfinbandoattach.defineKey("idattach", "idreg", "idregistryprogfin", "idregistryprogfinbando");

	//////////////////// REGISTRYPROGFINBANDO /////////////////////////////////
	var tregistryprogfinbando= new MetaTable("registryprogfinbando");
	tregistryprogfinbando.defineColumn("ct", typeof(DateTime),false);
	tregistryprogfinbando.defineColumn("cu", typeof(string),false);
	tregistryprogfinbando.defineColumn("description", typeof(string));
	tregistryprogfinbando.defineColumn("idreg", typeof(int),false);
	tregistryprogfinbando.defineColumn("idregistryprogfin", typeof(int),false);
	tregistryprogfinbando.defineColumn("idregistryprogfinbando", typeof(int),false);
	tregistryprogfinbando.defineColumn("lt", typeof(DateTime),false);
	tregistryprogfinbando.defineColumn("lu", typeof(string),false);
	tregistryprogfinbando.defineColumn("number", typeof(string));
	tregistryprogfinbando.defineColumn("scadenza", typeof(DateTime));
	tregistryprogfinbando.defineColumn("title", typeof(string));
	Tables.Add(tregistryprogfinbando);
	tregistryprogfinbando.defineKey("idreg", "idregistryprogfin", "idregistryprogfinbando");

	//////////////////// REGISTRYPROGFIN /////////////////////////////////
	var tregistryprogfin= new MetaTable("registryprogfin");
	tregistryprogfin.defineColumn("code", typeof(string));
	tregistryprogfin.defineColumn("ct", typeof(DateTime),false);
	tregistryprogfin.defineColumn("cu", typeof(string),false);
	tregistryprogfin.defineColumn("description", typeof(string));
	tregistryprogfin.defineColumn("idreg", typeof(int),false);
	tregistryprogfin.defineColumn("idregistryprogfin", typeof(int),false);
	tregistryprogfin.defineColumn("lt", typeof(DateTime),false);
	tregistryprogfin.defineColumn("lu", typeof(string),false);
	tregistryprogfin.defineColumn("title", typeof(string));
	Tables.Add(tregistryprogfin);
	tregistryprogfin.defineKey("idreg", "idregistryprogfin");

	//////////////////// GEO_NATION_ALIAS5 /////////////////////////////////
	var tgeo_nation_alias5= new MetaTable("geo_nation_alias5");
	tgeo_nation_alias5.defineColumn("idnation", typeof(int),false);
	tgeo_nation_alias5.defineColumn("title", typeof(string));
	tgeo_nation_alias5.ExtendedProperties["TableForReading"]="geo_nation";
	Tables.Add(tgeo_nation_alias5);
	tgeo_nation_alias5.defineKey("idnation");

	//////////////////// GEO_CITY_ALIAS5 /////////////////////////////////
	var tgeo_city_alias5= new MetaTable("geo_city_alias5");
	tgeo_city_alias5.defineColumn("idcity", typeof(int),false);
	tgeo_city_alias5.defineColumn("title", typeof(string));
	tgeo_city_alias5.ExtendedProperties["TableForReading"]="geo_city";
	Tables.Add(tgeo_city_alias5);
	tgeo_city_alias5.defineKey("idcity");

	//////////////////// ADDRESS /////////////////////////////////
	var taddress= new MetaTable("address");
	taddress.defineColumn("active", typeof(string));
	taddress.defineColumn("description", typeof(string),false);
	taddress.defineColumn("idaddress", typeof(int),false);
	Tables.Add(taddress);
	taddress.defineKey("idaddress");

	//////////////////// REGISTRYADDRESS /////////////////////////////////
	var tregistryaddress= new MetaTable("registryaddress");
	tregistryaddress.defineColumn("active", typeof(string));
	tregistryaddress.defineColumn("address", typeof(string));
	tregistryaddress.defineColumn("annotations", typeof(string));
	tregistryaddress.defineColumn("cap", typeof(string));
	tregistryaddress.defineColumn("ct", typeof(DateTime));
	tregistryaddress.defineColumn("cu", typeof(string));
	tregistryaddress.defineColumn("flagforeign", typeof(string));
	tregistryaddress.defineColumn("idaddresskind", typeof(int),false);
	tregistryaddress.defineColumn("idcity", typeof(int));
	tregistryaddress.defineColumn("idnation", typeof(int));
	tregistryaddress.defineColumn("idreg", typeof(int),false);
	tregistryaddress.defineColumn("location", typeof(string));
	tregistryaddress.defineColumn("lt", typeof(DateTime));
	tregistryaddress.defineColumn("lu", typeof(string));
	tregistryaddress.defineColumn("officename", typeof(string));
	tregistryaddress.defineColumn("recipientagency", typeof(string));
	tregistryaddress.defineColumn("start", typeof(DateTime),false);
	tregistryaddress.defineColumn("stop", typeof(DateTime));
	tregistryaddress.defineColumn("!idaddresskind_address_description", typeof(string));
	tregistryaddress.defineColumn("!idcity_geo_city_title", typeof(string));
	tregistryaddress.defineColumn("!idnation_geo_nation_title", typeof(string));
	Tables.Add(tregistryaddress);
	tregistryaddress.defineKey("idaddresskind", "idreg", "start");

	//////////////////// CCNL /////////////////////////////////
	var tccnl= new MetaTable("ccnl");
	tccnl.defineColumn("active", typeof(string),false);
	tccnl.defineColumn("area", typeof(string),false);
	tccnl.defineColumn("contraenti", typeof(string),false);
	tccnl.defineColumn("ct", typeof(DateTime),false);
	tccnl.defineColumn("cu", typeof(string),false);
	tccnl.defineColumn("decorrenza", typeof(DateTime));
	tccnl.defineColumn("idccnl", typeof(int),false);
	tccnl.defineColumn("lt", typeof(DateTime),false);
	tccnl.defineColumn("lu", typeof(string),false);
	tccnl.defineColumn("scadec", typeof(DateTime));
	tccnl.defineColumn("scadenza", typeof(DateTime));
	tccnl.defineColumn("sortcode", typeof(int),false);
	tccnl.defineColumn("stipula", typeof(DateTime),false);
	tccnl.defineColumn("title", typeof(string),false);
	Tables.Add(tccnl);
	tccnl.defineKey("idccnl");

	//////////////////// CCNLREGISTRY_AZIENDE /////////////////////////////////
	var tccnlregistry_aziende= new MetaTable("ccnlregistry_aziende");
	tccnlregistry_aziende.defineColumn("ct", typeof(DateTime),false);
	tccnlregistry_aziende.defineColumn("cu", typeof(string),false);
	tccnlregistry_aziende.defineColumn("idccnl", typeof(int),false);
	tccnlregistry_aziende.defineColumn("idreg_aziende", typeof(int),false);
	tccnlregistry_aziende.defineColumn("lt", typeof(DateTime),false);
	tccnlregistry_aziende.defineColumn("lu", typeof(string),false);
	tccnlregistry_aziende.defineColumn("!idccnl_ccnl_title", typeof(string));
	tccnlregistry_aziende.defineColumn("!idccnl_ccnl_active", typeof(string));
	tccnlregistry_aziende.defineColumn("!idccnl_ccnl_area", typeof(string));
	tccnlregistry_aziende.defineColumn("!idccnl_ccnl_decorrenza", typeof(DateTime));
	tccnlregistry_aziende.defineColumn("!idccnl_ccnl_scadec", typeof(DateTime));
	tccnlregistry_aziende.defineColumn("!idccnl_ccnl_scadenza", typeof(DateTime));
	tccnlregistry_aziende.defineColumn("!idccnl_ccnl_sortcode", typeof(int));
	tccnlregistry_aziende.defineColumn("!idccnl_ccnl_stipula", typeof(DateTime));
	Tables.Add(tccnlregistry_aziende);
	tccnlregistry_aziende.defineKey("idccnl", "idreg_aziende");

	//////////////////// NUMERODIP /////////////////////////////////
	var tnumerodip= new MetaTable("numerodip");
	tnumerodip.defineColumn("active", typeof(string),false);
	tnumerodip.defineColumn("idnumerodip", typeof(int),false);
	tnumerodip.defineColumn("lt", typeof(DateTime));
	tnumerodip.defineColumn("lu", typeof(string));
	tnumerodip.defineColumn("sortcode", typeof(int),false);
	tnumerodip.defineColumn("title", typeof(string),false);
	Tables.Add(tnumerodip);
	tnumerodip.defineKey("idnumerodip");

	//////////////////// NATURAGIURDEFAULTVIEW /////////////////////////////////
	var tnaturagiurdefaultview= new MetaTable("naturagiurdefaultview");
	tnaturagiurdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tnaturagiurdefaultview.defineColumn("idnaturagiur", typeof(int),false);
	tnaturagiurdefaultview.defineColumn("naturagiur_active", typeof(string));
	Tables.Add(tnaturagiurdefaultview);
	tnaturagiurdefaultview.defineKey("idnaturagiur");

	//////////////////// NACEDEFAULTVIEW /////////////////////////////////
	var tnacedefaultview= new MetaTable("nacedefaultview");
	tnacedefaultview.defineColumn("dropdown_title", typeof(string),false);
	tnacedefaultview.defineColumn("idnace", typeof(string),false);
	Tables.Add(tnacedefaultview);
	tnacedefaultview.defineKey("idnace");

	//////////////////// ACCMOTIVEDEFAULTVIEW_ALIAS1 /////////////////////////////////
	var taccmotivedefaultview_alias1= new MetaTable("accmotivedefaultview_alias1");
	taccmotivedefaultview_alias1.defineColumn("accmotive_active", typeof(string));
	taccmotivedefaultview_alias1.defineColumn("dropdown_title", typeof(string),false);
	taccmotivedefaultview_alias1.defineColumn("idaccmotive", typeof(string),false);
	taccmotivedefaultview_alias1.ExtendedProperties["TableForReading"]="accmotivedefaultview";
	Tables.Add(taccmotivedefaultview_alias1);
	taccmotivedefaultview_alias1.defineKey("idaccmotive");

	//////////////////// ATECODEFAULTVIEW /////////////////////////////////
	var tatecodefaultview= new MetaTable("atecodefaultview");
	tatecodefaultview.defineColumn("dropdown_title", typeof(string),false);
	tatecodefaultview.defineColumn("idateco", typeof(int),false);
	Tables.Add(tatecodefaultview);
	tatecodefaultview.defineKey("idateco");

	//////////////////// ACCMOTIVEDEFAULTVIEW /////////////////////////////////
	var taccmotivedefaultview= new MetaTable("accmotivedefaultview");
	taccmotivedefaultview.defineColumn("accmotive_active", typeof(string));
	taccmotivedefaultview.defineColumn("dropdown_title", typeof(string),false);
	taccmotivedefaultview.defineColumn("idaccmotive", typeof(string),false);
	Tables.Add(taccmotivedefaultview);
	taccmotivedefaultview.defineKey("idaccmotive");

	//////////////////// GEO_CITY /////////////////////////////////
	var tgeo_city= new MetaTable("geo_city");
	tgeo_city.defineColumn("idcity", typeof(int),false);
	tgeo_city.defineColumn("title", typeof(string));
	Tables.Add(tgeo_city);
	tgeo_city.defineKey("idcity");

	//////////////////// GEO_NATION /////////////////////////////////
	var tgeo_nation= new MetaTable("geo_nation");
	tgeo_nation.defineColumn("idnation", typeof(int),false);
	tgeo_nation.defineColumn("title", typeof(string));
	Tables.Add(tgeo_nation);
	tgeo_nation.defineKey("idnation");

	//////////////////// RESIDENCE /////////////////////////////////
	var tresidence= new MetaTable("residence");
	tresidence.defineColumn("active", typeof(string));
	tresidence.defineColumn("coderesidence", typeof(string),false);
	tresidence.defineColumn("description", typeof(string),false);
	tresidence.defineColumn("idresidence", typeof(int),false);
	tresidence.defineColumn("lt", typeof(DateTime));
	tresidence.defineColumn("lu", typeof(string));
	Tables.Add(tresidence);
	tresidence.defineKey("idresidence");

	//////////////////// REGISTRYCLASSAZIENDEVIEW /////////////////////////////////
	var tregistryclassaziendeview= new MetaTable("registryclassaziendeview");
	tregistryclassaziendeview.defineColumn("description", typeof(string),false);
	tregistryclassaziendeview.defineColumn("dropdown_title", typeof(string),false);
	tregistryclassaziendeview.defineColumn("idregistryclass", typeof(string),false);
	tregistryclassaziendeview.defineColumn("registryclass_active", typeof(string));
	tregistryclassaziendeview.defineColumn("registryclass_ct", typeof(DateTime),false);
	tregistryclassaziendeview.defineColumn("registryclass_cu", typeof(string),false);
	tregistryclassaziendeview.defineColumn("registryclass_flagbadgecode", typeof(string));
	tregistryclassaziendeview.defineColumn("registryclass_flagbadgecode_forced", typeof(string));
	tregistryclassaziendeview.defineColumn("registryclass_flagCF", typeof(string));
	tregistryclassaziendeview.defineColumn("registryclass_flagcf_forced", typeof(string));
	tregistryclassaziendeview.defineColumn("registryclass_flagcfbutton", typeof(string));
	tregistryclassaziendeview.defineColumn("registryclass_flagextmatricula", typeof(string));
	tregistryclassaziendeview.defineColumn("registryclass_flagextmatricula_forced", typeof(string));
	tregistryclassaziendeview.defineColumn("registryclass_flagfiscalresidence", typeof(string));
	tregistryclassaziendeview.defineColumn("registryclass_flagfiscalresidence_forced", typeof(string));
	tregistryclassaziendeview.defineColumn("registryclass_flagforeigncf", typeof(string));
	tregistryclassaziendeview.defineColumn("registryclass_flagforeigncf_forced", typeof(string));
	tregistryclassaziendeview.defineColumn("registryclass_flaghuman", typeof(string));
	tregistryclassaziendeview.defineColumn("registryclass_flaginfofromcfbutton", typeof(string));
	tregistryclassaziendeview.defineColumn("registryclass_flagmaritalstatus", typeof(string));
	tregistryclassaziendeview.defineColumn("registryclass_flagmaritalstatus_forced", typeof(string));
	tregistryclassaziendeview.defineColumn("registryclass_flagmaritalsurname", typeof(string));
	tregistryclassaziendeview.defineColumn("registryclass_flagmaritalsurname_forced", typeof(string));
	tregistryclassaziendeview.defineColumn("registryclass_flagothers", typeof(string));
	tregistryclassaziendeview.defineColumn("registryclass_flagothers_forced", typeof(string));
	tregistryclassaziendeview.defineColumn("registryclass_flagp_iva", typeof(string));
	tregistryclassaziendeview.defineColumn("registryclass_flagp_iva_forced", typeof(string));
	tregistryclassaziendeview.defineColumn("registryclass_flagqualification", typeof(string));
	tregistryclassaziendeview.defineColumn("registryclass_flagqualification_forced", typeof(string));
	tregistryclassaziendeview.defineColumn("registryclass_flagresidence", typeof(string));
	tregistryclassaziendeview.defineColumn("registryclass_flagresidence_forced", typeof(string));
	tregistryclassaziendeview.defineColumn("registryclass_flagtitle", typeof(string));
	tregistryclassaziendeview.defineColumn("registryclass_flagtitle_forced", typeof(string));
	tregistryclassaziendeview.defineColumn("registryclass_lt", typeof(DateTime),false);
	tregistryclassaziendeview.defineColumn("registryclass_lu", typeof(string),false);
	Tables.Add(tregistryclassaziendeview);
	tregistryclassaziendeview.defineKey("idregistryclass");

	//////////////////// CATEGORY /////////////////////////////////
	var tcategory= new MetaTable("category");
	tcategory.defineColumn("active", typeof(string));
	tcategory.defineColumn("description", typeof(string),false);
	tcategory.defineColumn("idcategory", typeof(string),false);
	Tables.Add(tcategory);
	tcategory.defineKey("idcategory");

	//////////////////// REGISTRYKIND /////////////////////////////////
	var tregistrykind= new MetaTable("registrykind");
	tregistrykind.defineColumn("description", typeof(string),false);
	tregistrykind.defineColumn("idregistrykind", typeof(int),false);
	Tables.Add(tregistrykind);
	tregistrykind.defineKey("idregistrykind");

	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new MetaTable("registry");
	tregistry.defineColumn("active", typeof(string),false);
	tregistry.defineColumn("annotation", typeof(string));
	tregistry.defineColumn("authorization_free", typeof(string));
	tregistry.defineColumn("badgecode", typeof(string));
	tregistry.defineColumn("birthdate", typeof(DateTime));
	tregistry.defineColumn("ccp", typeof(string));
	tregistry.defineColumn("cf", typeof(string));
	tregistry.defineColumn("ct", typeof(DateTime),false);
	tregistry.defineColumn("cu", typeof(string),false);
	tregistry.defineColumn("email_fe", typeof(string));
	tregistry.defineColumn("extension", typeof(string));
	tregistry.defineColumn("extmatricula", typeof(string));
	tregistry.defineColumn("flag_pa", typeof(string));
	tregistry.defineColumn("flagbankitaliaproceeds", typeof(string));
	tregistry.defineColumn("foreigncf", typeof(string));
	tregistry.defineColumn("forename", typeof(string));
	tregistry.defineColumn("gender", typeof(string));
	tregistry.defineColumn("idaccmotivecredit", typeof(string));
	tregistry.defineColumn("idaccmotivedebit", typeof(string));
	tregistry.defineColumn("idateco", typeof(int));
	tregistry.defineColumn("idcategory", typeof(string));
	tregistry.defineColumn("idcentralizedcategory", typeof(string));
	tregistry.defineColumn("idcity", typeof(int));
	tregistry.defineColumn("idclassconsorsuale", typeof(int));
	tregistry.defineColumn("idexternal", typeof(int));
	tregistry.defineColumn("idfonteindicebibliometrico", typeof(int));
	tregistry.defineColumn("idmaritalstatus", typeof(string));
	tregistry.defineColumn("idnace", typeof(string));
	tregistry.defineColumn("idnation", typeof(int));
	tregistry.defineColumn("idnaturagiur", typeof(int));
	tregistry.defineColumn("idnumerodip", typeof(int));
	tregistry.defineColumn("idreg", typeof(int),false);
	tregistry.defineColumn("idreg_istituti", typeof(int));
	tregistry.defineColumn("idregistryclass", typeof(string));
	tregistry.defineColumn("idregistrykind", typeof(int));
	tregistry.defineColumn("idsasd", typeof(int));
	tregistry.defineColumn("idstruttura", typeof(int));
	tregistry.defineColumn("idtitle", typeof(string));
	tregistry.defineColumn("indicebibliometrico", typeof(int));
	tregistry.defineColumn("ipa_fe", typeof(string));
	tregistry.defineColumn("ipa_perlapa", typeof(string));
	tregistry.defineColumn("location", typeof(string));
	tregistry.defineColumn("lt", typeof(DateTime),false);
	tregistry.defineColumn("lu", typeof(string),false);
	tregistry.defineColumn("maritalsurname", typeof(string));
	tregistry.defineColumn("multi_cf", typeof(string));
	tregistry.defineColumn("p_iva", typeof(string));
	tregistry.defineColumn("pec_fe", typeof(string));
	tregistry.defineColumn("pic", typeof(string));
	tregistry.defineColumn("residence", typeof(int));
	tregistry.defineColumn("ricevimento", typeof(string));
	tregistry.defineColumn("rtf", typeof(Byte[]));
	tregistry.defineColumn("sdi_defrifamm", typeof(string));
	tregistry.defineColumn("sdi_norifamm", typeof(string));
	tregistry.defineColumn("soggiorno", typeof(string));
	tregistry.defineColumn("surname", typeof(string));
	tregistry.defineColumn("title", typeof(string),false);
	tregistry.defineColumn("title_en", typeof(string));
	tregistry.defineColumn("toredirect", typeof(int));
	tregistry.defineColumn("txt", typeof(string));
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{registry.Columns["idreg"]};
	var cChild = new []{sede.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_sede_registry_idreg",cPar,cChild,false));

	cPar = new []{geo_city_alias2.Columns["idcity"]};
	cChild = new []{sede.Columns["idcity"]};
	Relations.Add(new DataRelation("FK_sede_geo_city_alias2_idcity",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registryreference.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registryreference_registry_idreg",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registryprogfin.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registryprogfin_registry_idreg",cPar,cChild,false));

	cPar = new []{registryprogfin.Columns["idreg"], registryprogfin.Columns["idregistryprogfin"]};
	cChild = new []{registryprogfinbando.Columns["idreg"], registryprogfinbando.Columns["idregistryprogfin"]};
	Relations.Add(new DataRelation("FK_registryprogfinbando_registryprogfin_idreg-idregistryprogfin",cPar,cChild,false));

	cPar = new []{registryprogfinbando.Columns["idreg"], registryprogfinbando.Columns["idregistryprogfin"], registryprogfinbando.Columns["idregistryprogfinbando"]};
	cChild = new []{registryprogfinbandoattach.Columns["idreg"], registryprogfinbandoattach.Columns["idregistryprogfin"], registryprogfinbandoattach.Columns["idregistryprogfinbando"]};
	Relations.Add(new DataRelation("FK_registryprogfinbandoattach_registryprogfinbando_idreg-idregistryprogfin-idregistryprogfinbando",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registryaddress.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registryaddress_registry_idreg",cPar,cChild,false));

	cPar = new []{geo_nation_alias5.Columns["idnation"]};
	cChild = new []{registryaddress.Columns["idnation"]};
	Relations.Add(new DataRelation("FK_registryaddress_geo_nation_alias5_idnation",cPar,cChild,false));

	cPar = new []{geo_city_alias5.Columns["idcity"]};
	cChild = new []{registryaddress.Columns["idcity"]};
	Relations.Add(new DataRelation("FK_registryaddress_geo_city_alias5_idcity",cPar,cChild,false));

	cPar = new []{address.Columns["idaddress"]};
	cChild = new []{registryaddress.Columns["idaddresskind"]};
	Relations.Add(new DataRelation("FK_registryaddress_address_idaddresskind",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{ccnlregistry_aziende.Columns["idreg_aziende"]};
	Relations.Add(new DataRelation("FK_ccnlregistry_aziende_registry_idreg_aziende",cPar,cChild,false));

	cPar = new []{ccnl.Columns["idccnl"]};
	cChild = new []{ccnlregistry_aziende.Columns["idccnl"]};
	Relations.Add(new DataRelation("FK_ccnlregistry_aziende_ccnl_idccnl",cPar,cChild,false));

	cPar = new []{numerodip.Columns["idnumerodip"]};
	cChild = new []{registry.Columns["idnumerodip"]};
	Relations.Add(new DataRelation("FK_registry_numerodip_idnumerodip",cPar,cChild,false));

	cPar = new []{naturagiurdefaultview.Columns["idnaturagiur"]};
	cChild = new []{registry.Columns["idnaturagiur"]};
	Relations.Add(new DataRelation("FK_registry_naturagiurdefaultview_idnaturagiur",cPar,cChild,false));

	cPar = new []{nacedefaultview.Columns["idnace"]};
	cChild = new []{registry.Columns["idnace"]};
	Relations.Add(new DataRelation("FK_registry_nacedefaultview_idnace",cPar,cChild,false));

	cPar = new []{accmotivedefaultview_alias1.Columns["idaccmotive"]};
	cChild = new []{registry.Columns["idaccmotivecredit"]};
	Relations.Add(new DataRelation("FK_registry_accmotivedefaultview_alias1_idaccmotivecredit",cPar,cChild,false));

	cPar = new []{atecodefaultview.Columns["idateco"]};
	cChild = new []{registry.Columns["idateco"]};
	Relations.Add(new DataRelation("FK_registry_atecodefaultview_idateco",cPar,cChild,false));

	cPar = new []{accmotivedefaultview.Columns["idaccmotive"]};
	cChild = new []{registry.Columns["idaccmotivedebit"]};
	Relations.Add(new DataRelation("FK_registry_accmotivedefaultview_idaccmotivedebit",cPar,cChild,false));

	cPar = new []{geo_city.Columns["idcity"]};
	cChild = new []{registry.Columns["idcity"]};
	Relations.Add(new DataRelation("FK_registry_geo_city_idcity",cPar,cChild,false));

	cPar = new []{geo_nation.Columns["idnation"]};
	cChild = new []{registry.Columns["idnation"]};
	Relations.Add(new DataRelation("FK_registry_geo_nation_idnation",cPar,cChild,false));

	cPar = new []{residence.Columns["idresidence"]};
	cChild = new []{registry.Columns["residence"]};
	Relations.Add(new DataRelation("FK_registry_residence_residence",cPar,cChild,false));

	cPar = new []{registryclassaziendeview.Columns["idregistryclass"]};
	cChild = new []{registry.Columns["idregistryclass"]};
	Relations.Add(new DataRelation("FK_registry_registryclassaziendeview_idregistryclass",cPar,cChild,false));

	cPar = new []{category.Columns["idcategory"]};
	cChild = new []{registry.Columns["idcategory"]};
	Relations.Add(new DataRelation("FK_registry_category_idcategory",cPar,cChild,false));

	cPar = new []{registrykind.Columns["idregistrykind"]};
	cChild = new []{registry.Columns["idregistrykind"]};
	Relations.Add(new DataRelation("FK_registry_registrykind_idregistrykind",cPar,cChild,false));

	#endregion

}
}
}
