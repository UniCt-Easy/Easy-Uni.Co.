
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
[System.Xml.Serialization.XmlRoot("dsmeta_registry_istituti_princ"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_registry_istituti_princ: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable upb 		=> (MetaTable)Tables["upb"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturakind 		=> (MetaTable)Tables["strutturakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sede_alias1 		=> (MetaTable)Tables["sede_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable aoo_alias2 		=> (MetaTable)Tables["aoo_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable struttura 		=> (MetaTable)Tables["struttura"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sospensione 		=> (MetaTable)Tables["sospensione"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryreference 		=> (MetaTable)Tables["registryreference"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_nation_alias5 		=> (MetaTable)Tables["geo_nation_alias5"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_city_alias5 		=> (MetaTable)Tables["geo_city_alias5"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable address 		=> (MetaTable)Tables["address"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryaddress 		=> (MetaTable)Tables["registryaddress"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istitutoprinc 		=> (MetaTable)Tables["istitutoprinc"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sede 		=> (MetaTable)Tables["sede"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable aoo 		=> (MetaTable)Tables["aoo"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_city 		=> (MetaTable)Tables["geo_city"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istitutokind 		=> (MetaTable)Tables["istitutokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry 		=> (MetaTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_istituti 		=> (MetaTable)Tables["registry_istituti"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_registry_istituti_princ(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_registry_istituti_princ (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_registry_istituti_princ";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_registry_istituti_princ.xsd";

	#region create DataTables
	//////////////////// UPB /////////////////////////////////
	var tupb= new MetaTable("upb");
	tupb.defineColumn("active", typeof(string));
	tupb.defineColumn("idupb", typeof(string),false);
	tupb.defineColumn("title", typeof(string),false);
	Tables.Add(tupb);
	tupb.defineKey("idupb");

	//////////////////// STRUTTURAKIND /////////////////////////////////
	var tstrutturakind= new MetaTable("strutturakind");
	tstrutturakind.defineColumn("active", typeof(string),false);
	tstrutturakind.defineColumn("idstrutturakind", typeof(int),false);
	tstrutturakind.defineColumn("title", typeof(string),false);
	Tables.Add(tstrutturakind);
	tstrutturakind.defineKey("idstrutturakind");

	//////////////////// SEDE_ALIAS1 /////////////////////////////////
	var tsede_alias1= new MetaTable("sede_alias1");
	tsede_alias1.defineColumn("idsede", typeof(int),false);
	tsede_alias1.defineColumn("title", typeof(string));
	tsede_alias1.ExtendedProperties["TableForReading"]="sede";
	Tables.Add(tsede_alias1);
	tsede_alias1.defineKey("idsede");

	//////////////////// AOO_ALIAS2 /////////////////////////////////
	var taoo_alias2= new MetaTable("aoo_alias2");
	taoo_alias2.defineColumn("idaoo", typeof(int),false);
	taoo_alias2.defineColumn("title", typeof(string),false);
	taoo_alias2.ExtendedProperties["TableForReading"]="aoo";
	Tables.Add(taoo_alias2);
	taoo_alias2.defineKey("idaoo");

	//////////////////// STRUTTURA /////////////////////////////////
	var tstruttura= new MetaTable("struttura");
	tstruttura.defineColumn("active", typeof(string));
	tstruttura.defineColumn("codice", typeof(string));
	tstruttura.defineColumn("codiceipa", typeof(string));
	tstruttura.defineColumn("ct", typeof(DateTime),false);
	tstruttura.defineColumn("cu", typeof(string),false);
	tstruttura.defineColumn("email", typeof(string));
	tstruttura.defineColumn("fax", typeof(string));
	tstruttura.defineColumn("idaoo", typeof(int));
	tstruttura.defineColumn("idreg", typeof(int));
	tstruttura.defineColumn("idsede", typeof(int),false);
	tstruttura.defineColumn("idstruttura", typeof(int),false);
	tstruttura.defineColumn("idstrutturakind", typeof(int),false);
	tstruttura.defineColumn("idupb", typeof(string));
	tstruttura.defineColumn("lt", typeof(DateTime),false);
	tstruttura.defineColumn("lu", typeof(string),false);
	tstruttura.defineColumn("paridstruttura", typeof(int));
	tstruttura.defineColumn("pesoindicatori", typeof(decimal));
	tstruttura.defineColumn("pesoobiettivi", typeof(decimal));
	tstruttura.defineColumn("pesoprogaltreuo", typeof(decimal));
	tstruttura.defineColumn("pesoproguo", typeof(decimal));
	tstruttura.defineColumn("telefono", typeof(string));
	tstruttura.defineColumn("title", typeof(string));
	tstruttura.defineColumn("title_en", typeof(string));
	tstruttura.defineColumn("!idaoo_aoo_title", typeof(string));
	tstruttura.defineColumn("!idsede_sede_title", typeof(string));
	tstruttura.defineColumn("!idstrutturakind_strutturakind_title", typeof(string));
	tstruttura.defineColumn("!idupb_upb_title", typeof(string));
	tstruttura.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tstruttura);
	tstruttura.defineKey("idstruttura");

	//////////////////// SOSPENSIONE /////////////////////////////////
	var tsospensione= new MetaTable("sospensione");
	tsospensione.defineColumn("ct", typeof(DateTime),false);
	tsospensione.defineColumn("cu", typeof(string),false);
	tsospensione.defineColumn("idaula", typeof(int));
	tsospensione.defineColumn("idedificio", typeof(int));
	tsospensione.defineColumn("idreg", typeof(int),false);
	tsospensione.defineColumn("idsede", typeof(int));
	tsospensione.defineColumn("idsospensione", typeof(int),false);
	tsospensione.defineColumn("lt", typeof(DateTime),false);
	tsospensione.defineColumn("lu", typeof(string),false);
	tsospensione.defineColumn("motivo", typeof(string));
	tsospensione.defineColumn("start", typeof(DateTime),false);
	tsospensione.defineColumn("stop", typeof(DateTime));
	Tables.Add(tsospensione);
	tsospensione.defineKey("idreg", "idsospensione");

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

	//////////////////// ISTITUTOPRINC /////////////////////////////////
	var tistitutoprinc= new MetaTable("istitutoprinc");
	tistitutoprinc.defineColumn("acronimo", typeof(string));
	tistitutoprinc.defineColumn("codiceammipa", typeof(string));
	tistitutoprinc.defineColumn("ct", typeof(DateTime),false);
	tistitutoprinc.defineColumn("cu", typeof(string),false);
	tistitutoprinc.defineColumn("idreg", typeof(int),false);
	tistitutoprinc.defineColumn("lt", typeof(DateTime),false);
	tistitutoprinc.defineColumn("lu", typeof(string),false);
	Tables.Add(tistitutoprinc);
	tistitutoprinc.defineKey("idreg");

	//////////////////// SEDE /////////////////////////////////
	var tsede= new MetaTable("sede");
	tsede.defineColumn("idsede", typeof(int),false);
	tsede.defineColumn("title", typeof(string));
	Tables.Add(tsede);
	tsede.defineKey("idsede");

	//////////////////// AOO /////////////////////////////////
	var taoo= new MetaTable("aoo");
	taoo.defineColumn("codiceaooipa", typeof(string));
	taoo.defineColumn("ct", typeof(DateTime),false);
	taoo.defineColumn("cu", typeof(string),false);
	taoo.defineColumn("idaoo", typeof(int),false);
	taoo.defineColumn("idreg", typeof(int));
	taoo.defineColumn("idsede", typeof(int));
	taoo.defineColumn("lt", typeof(DateTime),false);
	taoo.defineColumn("lu", typeof(string),false);
	taoo.defineColumn("title", typeof(string),false);
	taoo.defineColumn("!idsede_sede_title", typeof(string));
	taoo.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(taoo);
	taoo.defineKey("idaoo");

	//////////////////// GEO_CITY /////////////////////////////////
	var tgeo_city= new MetaTable("geo_city");
	tgeo_city.defineColumn("idcity", typeof(int),false);
	tgeo_city.defineColumn("title", typeof(string));
	Tables.Add(tgeo_city);
	tgeo_city.defineKey("idcity");

	//////////////////// ISTITUTOKIND /////////////////////////////////
	var tistitutokind= new MetaTable("istitutokind");
	tistitutokind.defineColumn("idistitutokind", typeof(int),false);
	tistitutokind.defineColumn("tipoistituto", typeof(string),false);
	Tables.Add(tistitutokind);
	tistitutokind.defineKey("idistitutokind");

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
	tregistry.defineColumn("idcategory", typeof(string));
	tregistry.defineColumn("idcentralizedcategory", typeof(string));
	tregistry.defineColumn("idcity", typeof(int));
	tregistry.defineColumn("idexternal", typeof(int));
	tregistry.defineColumn("idmaritalstatus", typeof(string));
	tregistry.defineColumn("idnation", typeof(int));
	tregistry.defineColumn("idreg", typeof(int),false);
	tregistry.defineColumn("idregistryclass", typeof(string));
	tregistry.defineColumn("idregistrykind", typeof(int));
	tregistry.defineColumn("idtitle", typeof(string));
	tregistry.defineColumn("ipa_fe", typeof(string));
	tregistry.defineColumn("ipa_perlapa", typeof(string));
	tregistry.defineColumn("location", typeof(string));
	tregistry.defineColumn("lt", typeof(DateTime),false);
	tregistry.defineColumn("lu", typeof(string),false);
	tregistry.defineColumn("maritalsurname", typeof(string));
	tregistry.defineColumn("multi_cf", typeof(string));
	tregistry.defineColumn("p_iva", typeof(string));
	tregistry.defineColumn("pec_fe", typeof(string));
	tregistry.defineColumn("residence", typeof(int),false);
	tregistry.defineColumn("rtf", typeof(Byte[]));
	tregistry.defineColumn("sdi_defrifamm", typeof(string));
	tregistry.defineColumn("sdi_norifamm", typeof(string));
	tregistry.defineColumn("surname", typeof(string));
	tregistry.defineColumn("title", typeof(string),false);
	tregistry.defineColumn("toredirect", typeof(int));
	tregistry.defineColumn("txt", typeof(string));
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// REGISTRY_ISTITUTI /////////////////////////////////
	var tregistry_istituti= new MetaTable("registry_istituti");
	tregistry_istituti.defineColumn("codicemiur", typeof(string));
	tregistry_istituti.defineColumn("codiceustat", typeof(string));
	tregistry_istituti.defineColumn("comune", typeof(string));
	tregistry_istituti.defineColumn("ct", typeof(DateTime));
	tregistry_istituti.defineColumn("cu", typeof(string),false);
	tregistry_istituti.defineColumn("idistitutokind", typeof(int),false);
	tregistry_istituti.defineColumn("idistitutoustat", typeof(int));
	tregistry_istituti.defineColumn("idreg", typeof(int),false);
	tregistry_istituti.defineColumn("lt", typeof(DateTime),false);
	tregistry_istituti.defineColumn("lu", typeof(string),false);
	tregistry_istituti.defineColumn("nome", typeof(string));
	tregistry_istituti.defineColumn("sortcode", typeof(int));
	tregistry_istituti.defineColumn("title", typeof(string));
	tregistry_istituti.defineColumn("title_en", typeof(string));
	Tables.Add(tregistry_istituti);
	tregistry_istituti.defineKey("idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{registry.Columns["idreg"]};
	var cChild = new []{struttura.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_struttura_registry_idreg",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{struttura.Columns["idupb"]};
	Relations.Add(new DataRelation("FK_struttura_upb_idupb",cPar,cChild,false));

	cPar = new []{strutturakind.Columns["idstrutturakind"]};
	cChild = new []{struttura.Columns["idstrutturakind"]};
	Relations.Add(new DataRelation("FK_struttura_strutturakind_idstrutturakind",cPar,cChild,false));

	cPar = new []{sede_alias1.Columns["idsede"]};
	cChild = new []{struttura.Columns["idsede"]};
	Relations.Add(new DataRelation("FK_struttura_sede_alias1_idsede",cPar,cChild,false));

	cPar = new []{aoo_alias2.Columns["idaoo"]};
	cChild = new []{struttura.Columns["idaoo"]};
	Relations.Add(new DataRelation("FK_struttura_aoo_alias2_idaoo",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{sospensione.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_sospensione_registry_idreg",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registryreference.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registryreference_registry_idreg",cPar,cChild,false));

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
	cChild = new []{istitutoprinc.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_istitutoprinc_registry_idreg",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{aoo.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_aoo_registry_idreg",cPar,cChild,false));

	cPar = new []{sede.Columns["idsede"]};
	cChild = new []{aoo.Columns["idsede"]};
	Relations.Add(new DataRelation("FK_aoo_sede_idsede",cPar,cChild,false));

	cPar = new []{geo_city.Columns["idcity"]};
	cChild = new []{registry.Columns["idcity"]};
	Relations.Add(new DataRelation("FK_registry_geo_city_idcity",cPar,cChild,false));

	cPar = new []{istitutokind.Columns["idistitutokind"]};
	cChild = new []{registry_istituti.Columns["idistitutokind"]};
	Relations.Add(new DataRelation("FK_registry_istituti_istitutokind_idistitutokind",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registry_istituti.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registry_istituti_registry_idreg",cPar,cChild,false));

	#endregion

}
}
}
