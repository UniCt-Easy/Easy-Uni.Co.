
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
[System.Xml.Serialization.XmlRoot("dsmeta_registry_militari"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_registry_militari: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable provvedimentokind 		=> (MetaTable)Tables["provvedimentokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable provvedimento 		=> (MetaTable)Tables["provvedimento"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable onorificenza 		=> (MetaTable)Tables["onorificenza"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable serviziokind 		=> (MetaTable)Tables["serviziokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable servizio 		=> (MetaTable)Tables["servizio"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable incaricokind 		=> (MetaTable)Tables["incaricokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable incarico 		=> (MetaTable)Tables["incarico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryreference 		=> (MetaTable)Tables["registryreference"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_nation_alias1 		=> (MetaTable)Tables["geo_nation_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_city_alias1 		=> (MetaTable)Tables["geo_city_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable address 		=> (MetaTable)Tables["address"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryaddress 		=> (MetaTable)Tables["registryaddress"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_alias1 		=> (MetaTable)Tables["registry_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable congiuntokind 		=> (MetaTable)Tables["congiuntokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrycongiunto 		=> (MetaTable)Tables["registrycongiunto"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sospensione 		=> (MetaTable)Tables["sospensione"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable struttura 		=> (MetaTable)Tables["struttura"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable residence 		=> (MetaTable)Tables["residence"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable title 		=> (MetaTable)Tables["title"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrykind 		=> (MetaTable)Tables["registrykind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryclass 		=> (MetaTable)Tables["registryclass"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_nation 		=> (MetaTable)Tables["geo_nation"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable maritalstatus 		=> (MetaTable)Tables["maritalstatus"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_city 		=> (MetaTable)Tables["geo_city"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable category 		=> (MetaTable)Tables["category"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry 		=> (MetaTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_militari 		=> (MetaTable)Tables["registry_militari"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_registry_militari(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_registry_militari (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_registry_militari";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_registry_militari.xsd";

	#region create DataTables
	//////////////////// PROVVEDIMENTOKIND /////////////////////////////////
	var tprovvedimentokind= new MetaTable("provvedimentokind");
	tprovvedimentokind.defineColumn("idprovvedimentokind", typeof(int),false);
	tprovvedimentokind.defineColumn("title", typeof(string),false);
	Tables.Add(tprovvedimentokind);
	tprovvedimentokind.defineKey("idprovvedimentokind");

	//////////////////// PROVVEDIMENTO /////////////////////////////////
	var tprovvedimento= new MetaTable("provvedimento");
	tprovvedimento.defineColumn("ct", typeof(DateTime),false);
	tprovvedimento.defineColumn("cu", typeof(string),false);
	tprovvedimento.defineColumn("data", typeof(DateTime));
	tprovvedimento.defineColumn("datacdc", typeof(string));
	tprovvedimento.defineColumn("dataucb", typeof(DateTime));
	tprovvedimento.defineColumn("dispositivo", typeof(string));
	tprovvedimento.defineColumn("fogliocdc", typeof(int));
	tprovvedimento.defineColumn("foglioucb", typeof(int));
	tprovvedimento.defineColumn("idprovvedimento", typeof(int),false);
	tprovvedimento.defineColumn("idprovvedimentokind", typeof(int));
	tprovvedimento.defineColumn("idreg", typeof(int),false);
	tprovvedimento.defineColumn("lt", typeof(DateTime),false);
	tprovvedimento.defineColumn("lu", typeof(string),false);
	tprovvedimento.defineColumn("note", typeof(string));
	tprovvedimento.defineColumn("numero", typeof(int));
	tprovvedimento.defineColumn("numerocdc", typeof(int));
	tprovvedimento.defineColumn("numeroucb", typeof(int));
	tprovvedimento.defineColumn("!idprovvedimentokind_provvedimentokind_title", typeof(string));
	Tables.Add(tprovvedimento);
	tprovvedimento.defineKey("idprovvedimento", "idreg");

	//////////////////// ONORIFICENZA /////////////////////////////////
	var tonorificenza= new MetaTable("onorificenza");
	tonorificenza.defineColumn("anno", typeof(int));
	tonorificenza.defineColumn("ct", typeof(DateTime),false);
	tonorificenza.defineColumn("cu", typeof(string),false);
	tonorificenza.defineColumn("idonorificenza", typeof(int),false);
	tonorificenza.defineColumn("idreg", typeof(int),false);
	tonorificenza.defineColumn("lt", typeof(DateTime),false);
	tonorificenza.defineColumn("lu", typeof(string),false);
	tonorificenza.defineColumn("title", typeof(string));
	Tables.Add(tonorificenza);
	tonorificenza.defineKey("idonorificenza", "idreg");

	//////////////////// SERVIZIOKIND /////////////////////////////////
	var tserviziokind= new MetaTable("serviziokind");
	tserviziokind.defineColumn("idserviziokind", typeof(int),false);
	tserviziokind.defineColumn("title", typeof(string),false);
	Tables.Add(tserviziokind);
	tserviziokind.defineKey("idserviziokind");

	//////////////////// SERVIZIO /////////////////////////////////
	var tservizio= new MetaTable("servizio");
	tservizio.defineColumn("ct", typeof(DateTime),false);
	tservizio.defineColumn("cu", typeof(string),false);
	tservizio.defineColumn("idreg", typeof(int),false);
	tservizio.defineColumn("idservizio", typeof(int),false);
	tservizio.defineColumn("idserviziokind", typeof(int),false);
	tservizio.defineColumn("lt", typeof(DateTime),false);
	tservizio.defineColumn("lu", typeof(string),false);
	tservizio.defineColumn("start", typeof(DateTime),false);
	tservizio.defineColumn("stop", typeof(DateTime));
	tservizio.defineColumn("!idserviziokind_serviziokind_title", typeof(string));
	Tables.Add(tservizio);
	tservizio.defineKey("idservizio");

	//////////////////// INCARICOKIND /////////////////////////////////
	var tincaricokind= new MetaTable("incaricokind");
	tincaricokind.defineColumn("idincaricokind", typeof(int),false);
	tincaricokind.defineColumn("title", typeof(string),false);
	Tables.Add(tincaricokind);
	tincaricokind.defineKey("idincaricokind");

	//////////////////// INCARICO /////////////////////////////////
	var tincarico= new MetaTable("incarico");
	tincarico.defineColumn("ct", typeof(DateTime),false);
	tincarico.defineColumn("cu", typeof(string),false);
	tincarico.defineColumn("idincarico", typeof(int),false);
	tincarico.defineColumn("idincaricokind", typeof(int),false);
	tincarico.defineColumn("idreg", typeof(int),false);
	tincarico.defineColumn("lt", typeof(DateTime),false);
	tincarico.defineColumn("lu", typeof(string),false);
	tincarico.defineColumn("start", typeof(DateTime),false);
	tincarico.defineColumn("stop", typeof(DateTime));
	tincarico.defineColumn("!idincaricokind_incaricokind_title", typeof(string));
	Tables.Add(tincarico);
	tincarico.defineKey("idincarico");

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

	//////////////////// GEO_NATION_ALIAS1 /////////////////////////////////
	var tgeo_nation_alias1= new MetaTable("geo_nation_alias1");
	tgeo_nation_alias1.defineColumn("idnation", typeof(int),false);
	tgeo_nation_alias1.defineColumn("title", typeof(string));
	tgeo_nation_alias1.ExtendedProperties["TableForReading"]="geo_nation";
	Tables.Add(tgeo_nation_alias1);
	tgeo_nation_alias1.defineKey("idnation");

	//////////////////// GEO_CITY_ALIAS1 /////////////////////////////////
	var tgeo_city_alias1= new MetaTable("geo_city_alias1");
	tgeo_city_alias1.defineColumn("idcity", typeof(int),false);
	tgeo_city_alias1.defineColumn("title", typeof(string));
	tgeo_city_alias1.ExtendedProperties["TableForReading"]="geo_city";
	Tables.Add(tgeo_city_alias1);
	tgeo_city_alias1.defineKey("idcity");

	//////////////////// ADDRESS /////////////////////////////////
	var taddress= new MetaTable("address");
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

	//////////////////// REGISTRY_ALIAS1 /////////////////////////////////
	var tregistry_alias1= new MetaTable("registry_alias1");
	tregistry_alias1.defineColumn("cf", typeof(string));
	tregistry_alias1.defineColumn("forename", typeof(string));
	tregistry_alias1.defineColumn("idreg", typeof(int),false);
	tregistry_alias1.defineColumn("idtitle", typeof(string));
	tregistry_alias1.defineColumn("surname", typeof(string));
	tregistry_alias1.defineColumn("title", typeof(string),false);
	tregistry_alias1.ExtendedProperties["TableForReading"]="registry";
	Tables.Add(tregistry_alias1);
	tregistry_alias1.defineKey("idreg");

	//////////////////// CONGIUNTOKIND /////////////////////////////////
	var tcongiuntokind= new MetaTable("congiuntokind");
	tcongiuntokind.defineColumn("idcongiuntokind", typeof(int),false);
	tcongiuntokind.defineColumn("title", typeof(string));
	Tables.Add(tcongiuntokind);
	tcongiuntokind.defineKey("idcongiuntokind");

	//////////////////// REGISTRYCONGIUNTO /////////////////////////////////
	var tregistrycongiunto= new MetaTable("registrycongiunto");
	tregistrycongiunto.defineColumn("ct", typeof(DateTime),false);
	tregistrycongiunto.defineColumn("cu", typeof(string),false);
	tregistrycongiunto.defineColumn("idcongiuntokind", typeof(int));
	tregistrycongiunto.defineColumn("idreg", typeof(int),false);
	tregistrycongiunto.defineColumn("idreg_congiunto", typeof(int),false);
	tregistrycongiunto.defineColumn("idregistrycongiunto", typeof(int),false);
	tregistrycongiunto.defineColumn("lt", typeof(DateTime),false);
	tregistrycongiunto.defineColumn("lu", typeof(string),false);
	tregistrycongiunto.defineColumn("!idcongiuntokind_congiuntokind_title", typeof(string));
	tregistrycongiunto.defineColumn("!idreg_congiunto_registry_title", typeof(string));
	tregistrycongiunto.defineColumn("!idreg_congiunto_registry_surname", typeof(string));
	tregistrycongiunto.defineColumn("!idreg_congiunto_registry_forename", typeof(string));
	tregistrycongiunto.defineColumn("!idreg_congiunto_registry_cf", typeof(string));
	tregistrycongiunto.defineColumn("!idreg_congiunto_registry_idtitle_description", typeof(string));
	Tables.Add(tregistrycongiunto);
	tregistrycongiunto.defineKey("idreg", "idreg_congiunto", "idregistrycongiunto");

	//////////////////// SOSPENSIONE /////////////////////////////////
	var tsospensione= new MetaTable("sospensione");
	tsospensione.defineColumn("ct", typeof(DateTime),false);
	tsospensione.defineColumn("cu", typeof(string),false);
	tsospensione.defineColumn("idaula", typeof(int));
	tsospensione.defineColumn("idedificio", typeof(int));
	tsospensione.defineColumn("idreg", typeof(int));
	tsospensione.defineColumn("idsede", typeof(int));
	tsospensione.defineColumn("idsospensione", typeof(int),false);
	tsospensione.defineColumn("lt", typeof(DateTime),false);
	tsospensione.defineColumn("lu", typeof(string),false);
	tsospensione.defineColumn("motivo", typeof(string));
	tsospensione.defineColumn("start", typeof(DateTime),false);
	tsospensione.defineColumn("stop", typeof(DateTime));
	Tables.Add(tsospensione);
	tsospensione.defineKey("idsospensione");

	//////////////////// STRUTTURA /////////////////////////////////
	var tstruttura= new MetaTable("struttura");
	tstruttura.defineColumn("idstruttura", typeof(int),false);
	tstruttura.defineColumn("title", typeof(string));
	Tables.Add(tstruttura);
	tstruttura.defineKey("idstruttura");

	//////////////////// RESIDENCE /////////////////////////////////
	var tresidence= new MetaTable("residence");
	tresidence.defineColumn("description", typeof(string),false);
	tresidence.defineColumn("idresidence", typeof(int),false);
	Tables.Add(tresidence);
	tresidence.defineKey("idresidence");

	//////////////////// TITLE /////////////////////////////////
	var ttitle= new MetaTable("title");
	ttitle.defineColumn("description", typeof(string),false);
	ttitle.defineColumn("idtitle", typeof(string),false);
	Tables.Add(ttitle);
	ttitle.defineKey("idtitle");

	//////////////////// REGISTRYKIND /////////////////////////////////
	var tregistrykind= new MetaTable("registrykind");
	tregistrykind.defineColumn("description", typeof(string),false);
	tregistrykind.defineColumn("idregistrykind", typeof(int),false);
	Tables.Add(tregistrykind);
	tregistrykind.defineKey("idregistrykind");

	//////////////////// REGISTRYCLASS /////////////////////////////////
	var tregistryclass= new MetaTable("registryclass");
	tregistryclass.defineColumn("description", typeof(string),false);
	tregistryclass.defineColumn("idregistryclass", typeof(string),false);
	Tables.Add(tregistryclass);
	tregistryclass.defineKey("idregistryclass");

	//////////////////// GEO_NATION /////////////////////////////////
	var tgeo_nation= new MetaTable("geo_nation");
	tgeo_nation.defineColumn("idnation", typeof(int),false);
	tgeo_nation.defineColumn("title", typeof(string));
	Tables.Add(tgeo_nation);
	tgeo_nation.defineKey("idnation");

	//////////////////// MARITALSTATUS /////////////////////////////////
	var tmaritalstatus= new MetaTable("maritalstatus");
	tmaritalstatus.defineColumn("description", typeof(string),false);
	tmaritalstatus.defineColumn("idmaritalstatus", typeof(string),false);
	Tables.Add(tmaritalstatus);
	tmaritalstatus.defineKey("idmaritalstatus");

	//////////////////// GEO_CITY /////////////////////////////////
	var tgeo_city= new MetaTable("geo_city");
	tgeo_city.defineColumn("idcity", typeof(int),false);
	tgeo_city.defineColumn("title", typeof(string));
	Tables.Add(tgeo_city);
	tgeo_city.defineKey("idcity");

	//////////////////// CATEGORY /////////////////////////////////
	var tcategory= new MetaTable("category");
	tcategory.defineColumn("description", typeof(string),false);
	tcategory.defineColumn("idcategory", typeof(string),false);
	Tables.Add(tcategory);
	tcategory.defineKey("idcategory");

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

	//////////////////// REGISTRY_MILITARI /////////////////////////////////
	var tregistry_militari= new MetaTable("registry_militari");
	tregistry_militari.defineColumn("ct", typeof(DateTime));
	tregistry_militari.defineColumn("cu", typeof(string));
	tregistry_militari.defineColumn("idreg", typeof(int),false);
	tregistry_militari.defineColumn("idstruttura", typeof(int));
	tregistry_militari.defineColumn("lt", typeof(DateTime));
	tregistry_militari.defineColumn("lu", typeof(string));
	Tables.Add(tregistry_militari);
	tregistry_militari.defineKey("idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{registry.Columns["idreg"]};
	var cChild = new []{provvedimento.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_provvedimento_registry_idreg",cPar,cChild,false));

	cPar = new []{provvedimentokind.Columns["idprovvedimentokind"]};
	cChild = new []{provvedimento.Columns["idprovvedimentokind"]};
	Relations.Add(new DataRelation("FK_provvedimento_provvedimentokind_idprovvedimentokind",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{onorificenza.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_onorificenza_registry_idreg",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{servizio.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_servizio_registry_idreg",cPar,cChild,false));

	cPar = new []{serviziokind.Columns["idserviziokind"]};
	cChild = new []{servizio.Columns["idserviziokind"]};
	Relations.Add(new DataRelation("FK_servizio_serviziokind_idserviziokind",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{incarico.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_incarico_registry_idreg",cPar,cChild,false));

	cPar = new []{incaricokind.Columns["idincaricokind"]};
	cChild = new []{incarico.Columns["idincaricokind"]};
	Relations.Add(new DataRelation("FK_incarico_incaricokind_idincaricokind",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registryreference.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registryreference_registry_idreg",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registryaddress.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registryaddress_registry_idreg",cPar,cChild,false));

	cPar = new []{geo_nation_alias1.Columns["idnation"]};
	cChild = new []{registryaddress.Columns["idnation"]};
	Relations.Add(new DataRelation("FK_registryaddress_geo_nation_alias1_idnation",cPar,cChild,false));

	cPar = new []{geo_city_alias1.Columns["idcity"]};
	cChild = new []{registryaddress.Columns["idcity"]};
	Relations.Add(new DataRelation("FK_registryaddress_geo_city_alias1_idcity",cPar,cChild,false));

	cPar = new []{address.Columns["idaddress"]};
	cChild = new []{registryaddress.Columns["idaddresskind"]};
	Relations.Add(new DataRelation("FK_registryaddress_address_idaddresskind",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registrycongiunto.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registrycongiunto_registry_idreg",cPar,cChild,false));

	cPar = new []{registry_alias1.Columns["idreg"]};
	cChild = new []{registrycongiunto.Columns["idreg_congiunto"]};
	Relations.Add(new DataRelation("FK_registrycongiunto_registry_alias1_idreg_congiunto",cPar,cChild,false));

	cPar = new []{title.Columns["idtitle"]};
	cChild = new []{registry_alias1.Columns["idtitle"]};
	Relations.Add(new DataRelation("FK_registry_alias1_title_idtitle",cPar,cChild,false));

	cPar = new []{congiuntokind.Columns["idcongiuntokind"]};
	cChild = new []{registrycongiunto.Columns["idcongiuntokind"]};
	Relations.Add(new DataRelation("FK_registrycongiunto_congiuntokind_idcongiuntokind",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{sospensione.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_sospensione_registry_idreg",cPar,cChild,false));

	cPar = new []{struttura.Columns["idstruttura"]};
	cChild = new []{registry_militari.Columns["idstruttura"]};
	Relations.Add(new DataRelation("FK_registry_militari_struttura_idstruttura",cPar,cChild,false));

	cPar = new []{residence.Columns["idresidence"]};
	cChild = new []{registry.Columns["residence"]};
	Relations.Add(new DataRelation("FK_registry_residence_residence",cPar,cChild,false));

	cPar = new []{title.Columns["idtitle"]};
	cChild = new []{registry.Columns["idtitle"]};
	Relations.Add(new DataRelation("FK_registry_title_idtitle",cPar,cChild,false));

	cPar = new []{registrykind.Columns["idregistrykind"]};
	cChild = new []{registry.Columns["idregistrykind"]};
	Relations.Add(new DataRelation("FK_registry_registrykind_idregistrykind",cPar,cChild,false));

	cPar = new []{registryclass.Columns["idregistryclass"]};
	cChild = new []{registry.Columns["idregistryclass"]};
	Relations.Add(new DataRelation("FK_registry_registryclass_idregistryclass",cPar,cChild,false));

	cPar = new []{geo_nation.Columns["idnation"]};
	cChild = new []{registry.Columns["idnation"]};
	Relations.Add(new DataRelation("FK_registry_geo_nation_idnation",cPar,cChild,false));

	cPar = new []{maritalstatus.Columns["idmaritalstatus"]};
	cChild = new []{registry.Columns["idmaritalstatus"]};
	Relations.Add(new DataRelation("FK_registry_maritalstatus_idmaritalstatus",cPar,cChild,false));

	cPar = new []{geo_city.Columns["idcity"]};
	cChild = new []{registry.Columns["idcity"]};
	Relations.Add(new DataRelation("FK_registry_geo_city_idcity",cPar,cChild,false));

	cPar = new []{category.Columns["idcategory"]};
	cChild = new []{registry.Columns["idcategory"]};
	Relations.Add(new DataRelation("FK_registry_category_idcategory",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registry_militari.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registry_militari_registry_idreg-",cPar,cChild,false));

	#endregion

}
}
}
