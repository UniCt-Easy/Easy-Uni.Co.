
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
using meta_registryreference;
using meta_address;
using meta_registryclass;
using meta_geo_city;
using meta_registryaddress;
using meta_geo_nation;
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace registry_anagrafica {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public registryTable registry 		=> (registryTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable maritalstatus 		=> (MetaTable)Tables["maritalstatus"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable category 		=> (MetaTable)Tables["category"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable centralizedcategory 		=> (MetaTable)Tables["centralizedcategory"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable position 		=> (MetaTable)Tables["position"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrylegalstatus 		=> (MetaTable)Tables["registrylegalstatus"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public registryreferenceTable registryreference 		=> (registryreferenceTable)Tables["registryreference"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrysorting 		=> (MetaTable)Tables["registrysorting"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrykind 		=> (MetaTable)Tables["registrykind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable title 		=> (MetaTable)Tables["title"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrypaymethod 		=> (MetaTable)Tables["registrypaymethod"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrytaxablestatus 		=> (MetaTable)Tables["registrytaxablestatus"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable residence 		=> (MetaTable)Tables["residence"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public addressTable address 		=> (addressTable)Tables["address"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public registryclassTable registryclass 		=> (registryclassTable)Tables["registryclass"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public geo_cityTable geo_city 		=> (geo_cityTable)Tables["geo_city"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_cityview 		=> (MetaTable)Tables["geo_cityview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_city_agencyview 		=> (MetaTable)Tables["geo_city_agencyview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public registryaddressTable registryaddress 		=> (registryaddressTable)Tables["registryaddress"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrymainview 		=> (MetaTable)Tables["registrymainview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_nazione_alias 		=> (MetaTable)Tables["geo_nazione_alias"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public geo_nationTable geo_nation 		=> (geo_nationTable)Tables["geo_nation"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sortingview 		=> (MetaTable)Tables["sortingview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrycf 		=> (MetaTable)Tables["registrycf"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrypiva 		=> (MetaTable)Tables["registrypiva"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accmotiveapplied_debit 		=> (MetaTable)Tables["accmotiveapplied_debit"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accmotiveapplied_credit 		=> (MetaTable)Tables["accmotiveapplied_credit"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrydurc 		=> (MetaTable)Tables["registrydurc"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable durckind 		=> (MetaTable)Tables["durckind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrycvattachment 		=> (MetaTable)Tables["registrycvattachment"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryspecialcategory770 		=> (MetaTable)Tables["registryspecialcategory770"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable specialcategory770 		=> (MetaTable)Tables["specialcategory770"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable dalia_position 		=> (MetaTable)Tables["dalia_position"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryvisura 		=> (MetaTable)Tables["registryvisura"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrycasellariogiudiziale 		=> (MetaTable)Tables["registrycasellariogiudiziale"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrycasellarioamministrativo 		=> (MetaTable)Tables["registrycasellarioamministrativo"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryottemperanzalegge68_99 		=> (MetaTable)Tables["registryottemperanzalegge68_99"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryregolaritafiscale 		=> (MetaTable)Tables["registryregolaritafiscale"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryverificaanac 		=> (MetaTable)Tables["registryverificaanac"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryattachment 		=> (MetaTable)Tables["registryattachment"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrypattointegrita 		=> (MetaTable)Tables["registrypattointegrita"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable nace 		=> (MetaTable)Tables["nace"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable naturagiur 		=> (MetaTable)Tables["naturagiur"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable numerodip 		=> (MetaTable)Tables["numerodip"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ateco 		=> (MetaTable)Tables["ateco"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_istituti 		=> (MetaTable)Tables["registry_istituti"];

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
	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new registryTable();
	tregistry.addBaseColumns("idreg","title","cf","p_iva","residence","idregistrykind","annotation","birthdate","gender","surname","forename","foreigncf","active","txt","rtf","cu","ct","lu","lt","extmatricula","idregistryclass","idcentralizedcategory","idtitle","idmaritalstatus","badgecode","maritalsurname","idcategory","idcity","location","idnation","authorization_free","multi_cf","idaccmotivecredit","idaccmotivedebit","ccp","flagbankitaliaproceeds","ipa_fe","flag_pa","sdi_norifamm","sdi_defrifamm","pec_fe","email_fe","ipa_perlapa","idnace","idnaturagiur","idnumerodip","idclassconsorsuale","idfonteindicebibliometrico","indicebibliometrico","ricevimento","soggiorno","idstruttura","idreg_istituti","idateco","extension");
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// MARITALSTATUS /////////////////////////////////
	var tmaritalstatus= new MetaTable("maritalstatus");
	tmaritalstatus.defineColumn("idmaritalstatus", typeof(string),false);
	tmaritalstatus.defineColumn("description", typeof(string),false);
	tmaritalstatus.defineColumn("active", typeof(string));
	tmaritalstatus.defineColumn("cu", typeof(string),false);
	tmaritalstatus.defineColumn("ct", typeof(DateTime),false);
	tmaritalstatus.defineColumn("lu", typeof(string),false);
	tmaritalstatus.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(tmaritalstatus);
	tmaritalstatus.defineKey("idmaritalstatus");

	//////////////////// CATEGORY /////////////////////////////////
	var tcategory= new MetaTable("category");
	tcategory.defineColumn("idcategory", typeof(string),false);
	tcategory.defineColumn("description", typeof(string),false);
	tcategory.defineColumn("active", typeof(string));
	tcategory.defineColumn("cu", typeof(string),false);
	tcategory.defineColumn("ct", typeof(DateTime),false);
	tcategory.defineColumn("lu", typeof(string),false);
	tcategory.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(tcategory);
	tcategory.defineKey("idcategory");

	//////////////////// CENTRALIZEDCATEGORY /////////////////////////////////
	var tcentralizedcategory= new MetaTable("centralizedcategory");
	tcentralizedcategory.defineColumn("idcentralizedcategory", typeof(string),false);
	tcentralizedcategory.defineColumn("description", typeof(string),false);
	tcentralizedcategory.defineColumn("active", typeof(string));
	tcentralizedcategory.defineColumn("cu", typeof(string),false);
	tcentralizedcategory.defineColumn("ct", typeof(DateTime),false);
	tcentralizedcategory.defineColumn("lu", typeof(string),false);
	tcentralizedcategory.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(tcentralizedcategory);
	tcentralizedcategory.defineKey("idcentralizedcategory");

	//////////////////// POSITION /////////////////////////////////
	var tposition= new MetaTable("position");
	tposition.defineColumn("idposition", typeof(int),false);
	tposition.defineColumn("description", typeof(string),false);
	tposition.defineColumn("maxincomeclass", typeof(short));
	tposition.defineColumn("cu", typeof(string),false);
	tposition.defineColumn("ct", typeof(DateTime),false);
	tposition.defineColumn("lu", typeof(string),false);
	tposition.defineColumn("lt", typeof(DateTime),false);
	tposition.defineColumn("codeposition", typeof(string),false);
	tposition.defineColumn("foreignclass", typeof(string));
	tposition.defineColumn("assegnoaggiuntivo", typeof(string));
	tposition.defineColumn("costolordoannuo", typeof(decimal));
	tposition.defineColumn("costolordoannuooneri", typeof(decimal));
	tposition.defineColumn("elementoperequativo", typeof(string));
	tposition.defineColumn("indennitadiateneo", typeof(string));
	tposition.defineColumn("indennitadiposizione", typeof(string));
	tposition.defineColumn("indvacancacontrattuale", typeof(string));
	tposition.defineColumn("oremaxcompitididatempoparziale", typeof(int));
	tposition.defineColumn("oremaxcompitididatempopieno", typeof(int));
	tposition.defineColumn("oremaxdidatempoparziale", typeof(int));
	tposition.defineColumn("oremaxdidatempopieno", typeof(int));
	tposition.defineColumn("oremaxgg", typeof(int));
	tposition.defineColumn("oremaxtempoparziale", typeof(int));
	tposition.defineColumn("oremaxtempopieno", typeof(int));
	tposition.defineColumn("oremincompitididatempoparziale", typeof(int));
	tposition.defineColumn("oremincompitididatempopieno", typeof(int));
	tposition.defineColumn("oremindidatempoparziale", typeof(int));
	tposition.defineColumn("oremindidatempopieno", typeof(int));
	tposition.defineColumn("oremintempoparziale", typeof(int));
	tposition.defineColumn("oremintempopieno", typeof(int));
	tposition.defineColumn("orestraordinariemax", typeof(int));
	tposition.defineColumn("parttime", typeof(string));
	tposition.defineColumn("puntiorganico", typeof(decimal));
	tposition.defineColumn("siglaesportazione", typeof(string));
	tposition.defineColumn("siglaimportazione", typeof(string));
	tposition.defineColumn("printingorder", typeof(int));
	tposition.defineColumn("tempdef", typeof(string));
	tposition.defineColumn("tipopersonale", typeof(string));
	tposition.defineColumn("title", typeof(string));
	tposition.defineColumn("totaletredicesima", typeof(string));
	tposition.defineColumn("tredicesimaindennitaintegrativaspeciale", typeof(string));
	tposition.defineColumn("tipoente", typeof(string));
	tposition.defineColumn("livello", typeof(string));
	Tables.Add(tposition);
	tposition.defineKey("idposition");

	//////////////////// REGISTRYLEGALSTATUS /////////////////////////////////
	var tregistrylegalstatus= new MetaTable("registrylegalstatus");
	tregistrylegalstatus.defineColumn("start", typeof(DateTime),false);
	tregistrylegalstatus.defineColumn("idreg", typeof(int),false);
	tregistrylegalstatus.defineColumn("idposition", typeof(int));
	tregistrylegalstatus.defineColumn("incomeclass", typeof(short));
	tregistrylegalstatus.defineColumn("incomeclassvalidity", typeof(DateTime));
	tregistrylegalstatus.defineColumn("txt", typeof(string));
	tregistrylegalstatus.defineColumn("rtf", typeof(Byte[]));
	tregistrylegalstatus.defineColumn("cu", typeof(string));
	tregistrylegalstatus.defineColumn("ct", typeof(DateTime));
	tregistrylegalstatus.defineColumn("lu", typeof(string));
	tregistrylegalstatus.defineColumn("lt", typeof(DateTime));
	tregistrylegalstatus.defineColumn("active", typeof(string));
	tregistrylegalstatus.defineColumn("!qualifica", typeof(string));
	tregistrylegalstatus.defineColumn("csa_compartment", typeof(int));
	tregistrylegalstatus.defineColumn("csa_role", typeof(string));
	tregistrylegalstatus.defineColumn("csa_class", typeof(string));
	tregistrylegalstatus.defineColumn("idregistrylegalstatus", typeof(int),false);
	tregistrylegalstatus.defineColumn("stop", typeof(DateTime));
	tregistrylegalstatus.defineColumn("iddaliaposition", typeof(int));
	tregistrylegalstatus.defineColumn("idinquadramento", typeof(int));
	tregistrylegalstatus.defineColumn("livello", typeof(int));
	tregistrylegalstatus.defineColumn("flagdefault", typeof(string));
	Tables.Add(tregistrylegalstatus);
	tregistrylegalstatus.defineKey("idreg", "idregistrylegalstatus");

	//////////////////// REGISTRYREFERENCE /////////////////////////////////
	var tregistryreference= new registryreferenceTable();
	tregistryreference.addBaseColumns("referencename","idreg","registryreferencerole","phonenumber","faxnumber","mobilenumber","email","userweb","passwordweb","txt","rtf","cu","ct","lu","lt","flagdefault","idregistryreference","skypenumber","msnnumber","pec","activeweb");
	Tables.Add(tregistryreference);
	tregistryreference.defineKey("idreg", "idregistryreference");

	//////////////////// REGISTRYSORTING /////////////////////////////////
	var tregistrysorting= new MetaTable("registrysorting");
	tregistrysorting.defineColumn("idsor", typeof(int),false);
	tregistrysorting.defineColumn("idreg", typeof(int),false);
	tregistrysorting.defineColumn("!codiceclass", typeof(string));
	tregistrysorting.defineColumn("!descrizione", typeof(string));
	tregistrysorting.defineColumn("cu", typeof(string),false);
	tregistrysorting.defineColumn("ct", typeof(DateTime),false);
	tregistrysorting.defineColumn("lu", typeof(string),false);
	tregistrysorting.defineColumn("lt", typeof(DateTime),false);
	tregistrysorting.defineColumn("quota", typeof(double));
	tregistrysorting.defineColumn("!descrtipoclass", typeof(string));
	Tables.Add(tregistrysorting);
	tregistrysorting.defineKey("idsor", "idreg");

	//////////////////// REGISTRYKIND /////////////////////////////////
	var tregistrykind= new MetaTable("registrykind");
	tregistrykind.defineColumn("idregistrykind", typeof(int),false);
	tregistrykind.defineColumn("sortcode", typeof(string),false);
	tregistrykind.defineColumn("description", typeof(string),false);
	tregistrykind.defineColumn("cu", typeof(string),false);
	tregistrykind.defineColumn("ct", typeof(DateTime),false);
	tregistrykind.defineColumn("lu", typeof(string),false);
	tregistrykind.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(tregistrykind);
	tregistrykind.defineKey("idregistrykind");

	//////////////////// TITLE /////////////////////////////////
	var ttitle= new MetaTable("title");
	ttitle.defineColumn("idtitle", typeof(string),false);
	ttitle.defineColumn("description", typeof(string),false);
	ttitle.defineColumn("active", typeof(string));
	ttitle.defineColumn("cu", typeof(string),false);
	ttitle.defineColumn("ct", typeof(DateTime),false);
	ttitle.defineColumn("lu", typeof(string),false);
	ttitle.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(ttitle);
	ttitle.defineKey("idtitle");

	//////////////////// REGISTRYPAYMETHOD /////////////////////////////////
	var tregistrypaymethod= new MetaTable("registrypaymethod");
	tregistrypaymethod.defineColumn("regmodcode", typeof(string),false);
	tregistrypaymethod.defineColumn("idreg", typeof(int),false);
	tregistrypaymethod.defineColumn("idpaymethod", typeof(int));
	tregistrypaymethod.defineColumn("cin", typeof(string));
	tregistrypaymethod.defineColumn("iban", typeof(string));
	tregistrypaymethod.defineColumn("idbank", typeof(string));
	tregistrypaymethod.defineColumn("idcab", typeof(string));
	tregistrypaymethod.defineColumn("cc", typeof(string));
	tregistrypaymethod.defineColumn("paymentdescr", typeof(string));
	tregistrypaymethod.defineColumn("paymentexpiring", typeof(short));
	tregistrypaymethod.defineColumn("idexpirationkind", typeof(short));
	tregistrypaymethod.defineColumn("flagstandard", typeof(string));
	tregistrypaymethod.defineColumn("txt", typeof(string));
	tregistrypaymethod.defineColumn("rtf", typeof(Byte[]));
	tregistrypaymethod.defineColumn("cu", typeof(string),false);
	tregistrypaymethod.defineColumn("ct", typeof(DateTime),false);
	tregistrypaymethod.defineColumn("lu", typeof(string),false);
	tregistrypaymethod.defineColumn("active", typeof(string));
	tregistrypaymethod.defineColumn("lt", typeof(DateTime),false);
	tregistrypaymethod.defineColumn("iddeputy", typeof(int));
	tregistrypaymethod.defineColumn("refexternaldoc", typeof(string));
	tregistrypaymethod.defineColumn("idregistrypaymethod", typeof(int),false);
	tregistrypaymethod.defineColumn("idcurrency", typeof(int));
	tregistrypaymethod.defineColumn("extracode", typeof(string));
	tregistrypaymethod.defineColumn("biccode", typeof(string));
	tregistrypaymethod.defineColumn("flag", typeof(int));
	tregistrypaymethod.defineColumn("idchargehandling", typeof(string));
	tregistrypaymethod.defineColumn("notes", typeof(string));
	tregistrypaymethod.defineColumn("ccdedicato_doc", typeof(Byte[]));
	tregistrypaymethod.defineColumn("ccdedicato_cf", typeof(Byte[]));
	tregistrypaymethod.defineColumn("requested_doc", typeof(int));
	tregistrypaymethod.defineColumn("ccdedicato_stop", typeof(DateTime));
	Tables.Add(tregistrypaymethod);
	tregistrypaymethod.defineKey("idreg", "idregistrypaymethod");

	//////////////////// REGISTRYTAXABLESTATUS /////////////////////////////////
	var tregistrytaxablestatus= new MetaTable("registrytaxablestatus");
	tregistrytaxablestatus.defineColumn("start", typeof(DateTime),false);
	tregistrytaxablestatus.defineColumn("idreg", typeof(int),false);
	tregistrytaxablestatus.defineColumn("supposedincome", typeof(decimal));
	tregistrytaxablestatus.defineColumn("txt", typeof(string));
	tregistrytaxablestatus.defineColumn("rtf", typeof(Byte[]));
	tregistrytaxablestatus.defineColumn("cu", typeof(string),false);
	tregistrytaxablestatus.defineColumn("ct", typeof(DateTime),false);
	tregistrytaxablestatus.defineColumn("lu", typeof(string),false);
	tregistrytaxablestatus.defineColumn("lt", typeof(DateTime),false);
	tregistrytaxablestatus.defineColumn("active", typeof(string));
	Tables.Add(tregistrytaxablestatus);
	tregistrytaxablestatus.defineKey("start", "idreg");

	//////////////////// RESIDENCE /////////////////////////////////
	var tresidence= new MetaTable("residence");
	tresidence.defineColumn("idresidence", typeof(int),false);
	tresidence.defineColumn("coderesidence", typeof(string),false);
	tresidence.defineColumn("description", typeof(string),false);
	tresidence.defineColumn("lt", typeof(DateTime));
	tresidence.defineColumn("lu", typeof(string));
	tresidence.defineColumn("active", typeof(string));
	Tables.Add(tresidence);
	tresidence.defineKey("idresidence");

	//////////////////// ADDRESS /////////////////////////////////
	var taddress= new addressTable();
	taddress.addBaseColumns("idaddress","description","lt","lu","active","codeaddress");
	Tables.Add(taddress);
	taddress.defineKey("idaddress");

	//////////////////// REGISTRYCLASS /////////////////////////////////
	var tregistryclass= new registryclassTable();
	tregistryclass.addBaseColumns("idregistryclass","description","flagtitle","flagCF","flagp_iva","flagqualification","flagextmatricula","flagbadgecode","flagmaritalstatus","flagforeigncf","flagmaritalsurname","flagothers","flagtitle_forced","flagcf_forced","flagp_iva_forced","flagqualification_forced","flagextmatricula_forced","flagbadgecode_forced","flagmaritalstatus_forced","flagforeigncf_forced","flagmaritalsurname_forced","flagothers_forced","active","cu","ct","lu","lt","flagresidence","flagresidence_forced","flagfiscalresidence","flagfiscalresidence_forced","flagcfbutton","flaginfofromcfbutton","flaghuman");
	Tables.Add(tregistryclass);
	tregistryclass.defineKey("idregistryclass");

	//////////////////// GEO_CITY /////////////////////////////////
	var tgeo_city= new geo_cityTable();
	tgeo_city.addBaseColumns("idcity","oldcity","newcity","title","start","stop","idcountry","lu","lt");
	Tables.Add(tgeo_city);
	tgeo_city.defineKey("idcity");

	//////////////////// GEO_CITYVIEW /////////////////////////////////
	var tgeo_cityview= new MetaTable("geo_cityview");
	tgeo_cityview.defineColumn("idcity", typeof(int),false);
	tgeo_cityview.defineColumn("title", typeof(string));
	tgeo_cityview.defineColumn("oldcity", typeof(int));
	tgeo_cityview.defineColumn("newcity", typeof(int));
	tgeo_cityview.defineColumn("start", typeof(DateTime));
	tgeo_cityview.defineColumn("stop", typeof(DateTime));
	tgeo_cityview.defineColumn("idcountry", typeof(int));
	tgeo_cityview.defineColumn("provincecode", typeof(string));
	tgeo_cityview.defineColumn("country", typeof(string));
	tgeo_cityview.defineColumn("oldcountry", typeof(int));
	tgeo_cityview.defineColumn("newcountry", typeof(int));
	tgeo_cityview.defineColumn("countrydatestart", typeof(DateTime));
	tgeo_cityview.defineColumn("countrydatestop", typeof(DateTime));
	tgeo_cityview.defineColumn("idregion", typeof(int));
	tgeo_cityview.defineColumn("region", typeof(string));
	tgeo_cityview.defineColumn("regiondatestart", typeof(DateTime));
	tgeo_cityview.defineColumn("regiondatestop", typeof(DateTime));
	tgeo_cityview.defineColumn("oldregion", typeof(int));
	tgeo_cityview.defineColumn("newregion", typeof(int));
	tgeo_cityview.defineColumn("idnation", typeof(int));
	tgeo_cityview.defineColumn("idcontinent", typeof(int));
	tgeo_cityview.defineColumn("nation", typeof(string));
	tgeo_cityview.defineColumn("nationdatestart", typeof(DateTime));
	tgeo_cityview.defineColumn("nationdatestop", typeof(DateTime));
	tgeo_cityview.defineColumn("oldnation", typeof(int));
	tgeo_cityview.defineColumn("newnation", typeof(int));
	Tables.Add(tgeo_cityview);
	tgeo_cityview.defineKey("idcity");

	//////////////////// GEO_CITY_AGENCYVIEW /////////////////////////////////
	var tgeo_city_agencyview= new MetaTable("geo_city_agencyview");
	tgeo_city_agencyview.defineColumn("idcity", typeof(int),false);
	tgeo_city_agencyview.defineColumn("title", typeof(string));
	tgeo_city_agencyview.defineColumn("idagency", typeof(int),false);
	tgeo_city_agencyview.defineColumn("agencyname", typeof(string));
	tgeo_city_agencyview.defineColumn("agencywebsite", typeof(string));
	tgeo_city_agencyview.defineColumn("idcode", typeof(int),false);
	tgeo_city_agencyview.defineColumn("version", typeof(int),false);
	tgeo_city_agencyview.defineColumn("codename", typeof(string));
	tgeo_city_agencyview.defineColumn("value", typeof(string));
	tgeo_city_agencyview.defineColumn("start", typeof(DateTime));
	tgeo_city_agencyview.defineColumn("stop", typeof(DateTime));
	Tables.Add(tgeo_city_agencyview);
	tgeo_city_agencyview.defineKey("idcity", "idagency", "idcode", "version");

	//////////////////// REGISTRYADDRESS /////////////////////////////////
	var tregistryaddress= new registryaddressTable();
	tregistryaddress.addBaseColumns("idreg","start","idaddresskind","annotations","ct","cu","stop","active","idcity","address","lt","lu","officename","cap","flagforeign","location","idnation","recipientagency");
	tregistryaddress.defineColumn("!descrtipoindirizzo", typeof(string));
	tregistryaddress.defineColumn("!comune", typeof(string));
	tregistryaddress.defineColumn("!localita", typeof(string));
	tregistryaddress.defineColumn("!nazione", typeof(string));
	Tables.Add(tregistryaddress);
	tregistryaddress.defineKey("idreg", "start", "idaddresskind");

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
	tregistrymainview.defineColumn("coderesidence", typeof(string));
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
	tregistrymainview.defineColumn("category", typeof(string));
	tregistrymainview.defineColumn("extmatricula", typeof(string));
	tregistrymainview.defineColumn("idcentralizedcategory", typeof(string));
	tregistrymainview.defineColumn("cu", typeof(string),false);
	tregistrymainview.defineColumn("ct", typeof(DateTime),false);
	tregistrymainview.defineColumn("lu", typeof(string),false);
	tregistrymainview.defineColumn("lt", typeof(DateTime),false);
	tregistrymainview.defineColumn("location", typeof(string));
	tregistrymainview.defineColumn("idnation", typeof(int));
	tregistrymainview.defineColumn("nation", typeof(string));
	tregistrymainview.defineColumn("idregistrykind", typeof(int));
	tregistrymainview.defineColumn("idaccmotivedebit", typeof(string));
	tregistrymainview.defineColumn("codemotivedebit", typeof(string));
	tregistrymainview.defineColumn("idaccmotivecredit", typeof(string));
	tregistrymainview.defineColumn("codemotivecredit", typeof(string));
	tregistrymainview.defineColumn("ccp", typeof(string));
	tregistrymainview.defineColumn("ipa_fe", typeof(string));
	tregistrymainview.defineColumn("flag_pa", typeof(string));
	tregistrymainview.defineColumn("sdi_norifamm", typeof(string));
	tregistrymainview.defineColumn("sdi_defrifamm", typeof(string));
	tregistrymainview.defineColumn("email_fe", typeof(string));
	tregistrymainview.defineColumn("pec_fe", typeof(string));
	tregistrymainview.defineColumn("ipa_perlapa", typeof(string));
	tregistrymainview.defineColumn("idnace", typeof(string));
	tregistrymainview.defineColumn("idnaturagiur", typeof(int));
	tregistrymainview.defineColumn("idnumerodip", typeof(int));
	tregistrymainview.defineColumn("idclassconsorsuale", typeof(int));
	tregistrymainview.defineColumn("idfonteindicebibliometrico", typeof(int));
	tregistrymainview.defineColumn("indicebibliometrico", typeof(int));
	tregistrymainview.defineColumn("ricevimento", typeof(string));
	tregistrymainview.defineColumn("soggiorno", typeof(string));
	tregistrymainview.defineColumn("idstruttura", typeof(int));
	tregistrymainview.defineColumn("idreg_istituti", typeof(int));
	tregistrymainview.defineColumn("idateco", typeof(int));
	tregistrymainview.defineColumn("extension", typeof(string));
	Tables.Add(tregistrymainview);
	tregistrymainview.defineKey("idreg");

	//////////////////// GEO_NAZIONE_ALIAS /////////////////////////////////
	var tgeo_nazione_alias= new MetaTable("geo_nazione_alias");
	tgeo_nazione_alias.defineColumn("idnation", typeof(int),false);
	tgeo_nazione_alias.defineColumn("idcontinent", typeof(int));
	tgeo_nazione_alias.defineColumn("title", typeof(string));
	tgeo_nazione_alias.defineColumn("start", typeof(DateTime));
	tgeo_nazione_alias.defineColumn("stop", typeof(DateTime));
	tgeo_nazione_alias.defineColumn("oldnation", typeof(int));
	tgeo_nazione_alias.defineColumn("newnation", typeof(int));
	tgeo_nazione_alias.defineColumn("lu", typeof(string));
	tgeo_nazione_alias.defineColumn("lt", typeof(DateTime));
	Tables.Add(tgeo_nazione_alias);
	tgeo_nazione_alias.defineKey("idnation");

	//////////////////// GEO_NATION /////////////////////////////////
	var tgeo_nation= new geo_nationTable();
	tgeo_nation.addBaseColumns("idnation","start","stop","title","idcontinent","lt","lu","newnation","oldnation");
	Tables.Add(tgeo_nation);
	tgeo_nation.defineKey("idnation");

	//////////////////// SORTINGVIEW /////////////////////////////////
	var tsortingview= new MetaTable("sortingview");
	tsortingview.defineColumn("codesorkind", typeof(string),false);
	tsortingview.defineColumn("idsorkind", typeof(int),false);
	tsortingview.defineColumn("sortingkind", typeof(string),false);
	tsortingview.defineColumn("idsor", typeof(int),false);
	tsortingview.defineColumn("sortcode", typeof(string),false);
	tsortingview.defineColumn("nlevel", typeof(byte),false);
	tsortingview.defineColumn("leveldescr", typeof(string),false);
	tsortingview.defineColumn("paridsor", typeof(int));
	tsortingview.defineColumn("description", typeof(string),false);
	tsortingview.defineColumn("ayear", typeof(short),false);
	tsortingview.defineColumn("incomeprevision", typeof(decimal));
	tsortingview.defineColumn("expenseprevision", typeof(decimal));
	tsortingview.defineColumn("cu", typeof(string),false);
	tsortingview.defineColumn("ct", typeof(DateTime),false);
	tsortingview.defineColumn("lu", typeof(string),false);
	tsortingview.defineColumn("lt", typeof(DateTime),false);
	tsortingview.defineColumn("defaultn1", typeof(decimal));
	tsortingview.defineColumn("defaultn2", typeof(decimal));
	tsortingview.defineColumn("defaultn3", typeof(decimal));
	tsortingview.defineColumn("defaultn4", typeof(decimal));
	tsortingview.defineColumn("defaultn5", typeof(decimal));
	tsortingview.defineColumn("defaults1", typeof(string));
	tsortingview.defineColumn("defaults2", typeof(string));
	tsortingview.defineColumn("defaults3", typeof(string));
	tsortingview.defineColumn("defaults4", typeof(string));
	tsortingview.defineColumn("defaults5", typeof(string));
	tsortingview.defineColumn("flagnodate", typeof(string));
	tsortingview.defineColumn("movkind", typeof(string));
	Tables.Add(tsortingview);
	tsortingview.defineKey("idsor");

	//////////////////// REGISTRYCF /////////////////////////////////
	var tregistrycf= new MetaTable("registrycf");
	tregistrycf.defineColumn("idreg", typeof(int),false);
	tregistrycf.defineColumn("idregistrycf", typeof(int),false);
	tregistrycf.defineColumn("cf", typeof(string),false);
	tregistrycf.defineColumn("start", typeof(DateTime));
	tregistrycf.defineColumn("stop", typeof(DateTime),false);
	tregistrycf.defineColumn("ct", typeof(DateTime),false);
	tregistrycf.defineColumn("cu", typeof(string),false);
	tregistrycf.defineColumn("lt", typeof(DateTime),false);
	tregistrycf.defineColumn("lu", typeof(string),false);
	Tables.Add(tregistrycf);
	tregistrycf.defineKey("idreg", "idregistrycf");

	//////////////////// REGISTRYPIVA /////////////////////////////////
	var tregistrypiva= new MetaTable("registrypiva");
	tregistrypiva.defineColumn("idreg", typeof(int),false);
	tregistrypiva.defineColumn("idregistrypiva", typeof(int),false);
	tregistrypiva.defineColumn("p_iva", typeof(string),false);
	tregistrypiva.defineColumn("start", typeof(DateTime));
	tregistrypiva.defineColumn("stop", typeof(DateTime));
	tregistrypiva.defineColumn("ct", typeof(DateTime),false);
	tregistrypiva.defineColumn("cu", typeof(string),false);
	tregistrypiva.defineColumn("lt", typeof(DateTime),false);
	tregistrypiva.defineColumn("lu", typeof(string),false);
	Tables.Add(tregistrypiva);
	tregistrypiva.defineKey("idreg", "idregistrypiva");

	//////////////////// ACCMOTIVEAPPLIED_DEBIT /////////////////////////////////
	var taccmotiveapplied_debit= new MetaTable("accmotiveapplied_debit");
	taccmotiveapplied_debit.defineColumn("idaccmotive", typeof(string),false);
	taccmotiveapplied_debit.defineColumn("paridaccmotive", typeof(string));
	taccmotiveapplied_debit.defineColumn("codemotive", typeof(string),false);
	taccmotiveapplied_debit.defineColumn("motive", typeof(string),false);
	taccmotiveapplied_debit.defineColumn("cu", typeof(string),false);
	taccmotiveapplied_debit.defineColumn("ct", typeof(DateTime),false);
	taccmotiveapplied_debit.defineColumn("lu", typeof(string),false);
	taccmotiveapplied_debit.defineColumn("lt", typeof(DateTime),false);
	taccmotiveapplied_debit.defineColumn("active", typeof(string));
	taccmotiveapplied_debit.defineColumn("idepoperation", typeof(string));
	taccmotiveapplied_debit.defineColumn("epoperation", typeof(string));
	taccmotiveapplied_debit.defineColumn("in_use", typeof(string),false);
	Tables.Add(taccmotiveapplied_debit);
	taccmotiveapplied_debit.defineKey("idaccmotive");

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
	Tables.Add(taccmotiveapplied_credit);
	taccmotiveapplied_credit.defineKey("idaccmotive");

	//////////////////// REGISTRYDURC /////////////////////////////////
	var tregistrydurc= new MetaTable("registrydurc");
	tregistrydurc.defineColumn("idregistrydurc", typeof(int),false);
	tregistrydurc.defineColumn("idreg", typeof(int),false);
	tregistrydurc.defineColumn("iddurckind", typeof(short));
	tregistrydurc.defineColumn("start", typeof(DateTime));
	tregistrydurc.defineColumn("stop", typeof(DateTime));
	tregistrydurc.defineColumn("adate", typeof(DateTime));
	tregistrydurc.defineColumn("selfcertification", typeof(Byte[]));
	tregistrydurc.defineColumn("durccertification", typeof(Byte[]));
	tregistrydurc.defineColumn("doc", typeof(string));
	tregistrydurc.defineColumn("docdate", typeof(DateTime));
	tregistrydurc.defineColumn("inpscode", typeof(string));
	tregistrydurc.defineColumn("inailcode", typeof(string));
	tregistrydurc.defineColumn("buildingcode", typeof(string));
	tregistrydurc.defineColumn("otherinsurancecode", typeof(string));
	tregistrydurc.defineColumn("ct", typeof(DateTime),false);
	tregistrydurc.defineColumn("cu", typeof(string),false);
	tregistrydurc.defineColumn("lt", typeof(DateTime),false);
	tregistrydurc.defineColumn("lu", typeof(string),false);
	tregistrydurc.defineColumn("!durckind", typeof(string));
	tregistrydurc.defineColumn("txt", typeof(string));
	tregistrydurc.defineColumn("rtf", typeof(Byte[]));
	tregistrydurc.defineColumn("flagirregular", typeof(string));
	Tables.Add(tregistrydurc);
	tregistrydurc.defineKey("idregistrydurc", "idreg");

	//////////////////// DURCKIND /////////////////////////////////
	var tdurckind= new MetaTable("durckind");
	tdurckind.defineColumn("iddurckind", typeof(short),false);
	tdurckind.defineColumn("description", typeof(string),false);
	Tables.Add(tdurckind);
	tdurckind.defineKey("iddurckind");

	//////////////////// REGISTRYCVATTACHMENT /////////////////////////////////
	var tregistrycvattachment= new MetaTable("registrycvattachment");
	tregistrycvattachment.defineColumn("idreg", typeof(int),false);
	tregistrycvattachment.defineColumn("idregistrycvattachment", typeof(int),false);
	tregistrycvattachment.defineColumn("attachment", typeof(Byte[]));
	tregistrycvattachment.defineColumn("ct", typeof(DateTime),false);
	tregistrycvattachment.defineColumn("cu", typeof(string),false);
	tregistrycvattachment.defineColumn("filename", typeof(string));
	tregistrycvattachment.defineColumn("lt", typeof(DateTime),false);
	tregistrycvattachment.defineColumn("lu", typeof(string),false);
	tregistrycvattachment.defineColumn("referencedate", typeof(DateTime));
	Tables.Add(tregistrycvattachment);
	tregistrycvattachment.defineKey("idreg", "idregistrycvattachment");

	//////////////////// REGISTRYSPECIALCATEGORY770 /////////////////////////////////
	var tregistryspecialcategory770= new MetaTable("registryspecialcategory770");
	tregistryspecialcategory770.defineColumn("idregistryspecialcategory770", typeof(int),false);
	tregistryspecialcategory770.defineColumn("idspecialcategory770", typeof(string),false);
	tregistryspecialcategory770.defineColumn("cu", typeof(string),false);
	tregistryspecialcategory770.defineColumn("ct", typeof(DateTime),false);
	tregistryspecialcategory770.defineColumn("lu", typeof(string),false);
	tregistryspecialcategory770.defineColumn("lt", typeof(DateTime),false);
	tregistryspecialcategory770.defineColumn("description", typeof(string));
	tregistryspecialcategory770.defineColumn("idreg", typeof(int),false);
	tregistryspecialcategory770.defineColumn("ayear", typeof(int),false);
	tregistryspecialcategory770.defineColumn("!specialcategory770", typeof(string));
	Tables.Add(tregistryspecialcategory770);
	tregistryspecialcategory770.defineKey("idregistryspecialcategory770", "idreg");

	//////////////////// SPECIALCATEGORY770 /////////////////////////////////
	var tspecialcategory770= new MetaTable("specialcategory770");
	tspecialcategory770.defineColumn("idspecialcategory770", typeof(string),false);
	tspecialcategory770.defineColumn("description", typeof(string),false);
	tspecialcategory770.defineColumn("ct", typeof(DateTime),false);
	tspecialcategory770.defineColumn("cu", typeof(string),false);
	tspecialcategory770.defineColumn("lt", typeof(DateTime),false);
	tspecialcategory770.defineColumn("lu", typeof(string),false);
	tspecialcategory770.defineColumn("ayear", typeof(int),false);
	tspecialcategory770.defineColumn("active", typeof(string),false);
	Tables.Add(tspecialcategory770);
	tspecialcategory770.defineKey("ayear", "idspecialcategory770");

	//////////////////// DALIA_POSITION /////////////////////////////////
	var tdalia_position= new MetaTable("dalia_position");
	tdalia_position.defineColumn("iddaliaposition", typeof(int),false);
	tdalia_position.defineColumn("codedaliaposition", typeof(string));
	tdalia_position.defineColumn("description", typeof(string));
	Tables.Add(tdalia_position);
	tdalia_position.defineKey("iddaliaposition");

	//////////////////// REGISTRYVISURA /////////////////////////////////
	var tregistryvisura= new MetaTable("registryvisura");
	tregistryvisura.defineColumn("idregistryvisura", typeof(int),false);
	tregistryvisura.defineColumn("idreg", typeof(int),false);
	tregistryvisura.defineColumn("visuracertification", typeof(Byte[]));
	tregistryvisura.defineColumn("start", typeof(DateTime));
	tregistryvisura.defineColumn("stop", typeof(DateTime));
	tregistryvisura.defineColumn("cu", typeof(string),false);
	tregistryvisura.defineColumn("ct", typeof(DateTime),false);
	tregistryvisura.defineColumn("lu", typeof(string),false);
	tregistryvisura.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(tregistryvisura);
	tregistryvisura.defineKey("idregistryvisura", "idreg");

	//////////////////// REGISTRYCASELLARIOGIUDIZIALE /////////////////////////////////
	var tregistrycasellariogiudiziale= new MetaTable("registrycasellariogiudiziale");
	tregistrycasellariogiudiziale.defineColumn("idregistrycasellariogiudiziale", typeof(int),false);
	tregistrycasellariogiudiziale.defineColumn("idreg", typeof(int),false);
	tregistrycasellariogiudiziale.defineColumn("casellariocertification", typeof(Byte[]));
	tregistrycasellariogiudiziale.defineColumn("start", typeof(DateTime));
	tregistrycasellariogiudiziale.defineColumn("stop", typeof(DateTime));
	tregistrycasellariogiudiziale.defineColumn("cu", typeof(string),false);
	tregistrycasellariogiudiziale.defineColumn("ct", typeof(DateTime),false);
	tregistrycasellariogiudiziale.defineColumn("lu", typeof(string),false);
	tregistrycasellariogiudiziale.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(tregistrycasellariogiudiziale);
	tregistrycasellariogiudiziale.defineKey("idregistrycasellariogiudiziale", "idreg");

	//////////////////// REGISTRYCASELLARIOAMMINISTRATIVO /////////////////////////////////
	var tregistrycasellarioamministrativo= new MetaTable("registrycasellarioamministrativo");
	tregistrycasellarioamministrativo.defineColumn("idregistrycasellarioamministrativo", typeof(int),false);
	tregistrycasellarioamministrativo.defineColumn("idreg", typeof(int),false);
	tregistrycasellarioamministrativo.defineColumn("casellariocertification", typeof(Byte[]));
	tregistrycasellarioamministrativo.defineColumn("start", typeof(DateTime));
	tregistrycasellarioamministrativo.defineColumn("stop", typeof(DateTime));
	tregistrycasellarioamministrativo.defineColumn("cu", typeof(string),false);
	tregistrycasellarioamministrativo.defineColumn("ct", typeof(DateTime),false);
	tregistrycasellarioamministrativo.defineColumn("lu", typeof(string),false);
	tregistrycasellarioamministrativo.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(tregistrycasellarioamministrativo);
	tregistrycasellarioamministrativo.defineKey("idregistrycasellarioamministrativo", "idreg");

	//////////////////// REGISTRYOTTEMPERANZALEGGE68_99 /////////////////////////////////
	var tregistryottemperanzalegge68_99= new MetaTable("registryottemperanzalegge68_99");
	tregistryottemperanzalegge68_99.defineColumn("idregistryottemperanzalegge", typeof(int),false);
	tregistryottemperanzalegge68_99.defineColumn("idreg", typeof(int),false);
	tregistryottemperanzalegge68_99.defineColumn("ottemperanzacertification", typeof(Byte[]));
	tregistryottemperanzalegge68_99.defineColumn("start", typeof(DateTime));
	tregistryottemperanzalegge68_99.defineColumn("stop", typeof(DateTime));
	tregistryottemperanzalegge68_99.defineColumn("cu", typeof(string),false);
	tregistryottemperanzalegge68_99.defineColumn("ct", typeof(DateTime),false);
	tregistryottemperanzalegge68_99.defineColumn("lu", typeof(string),false);
	tregistryottemperanzalegge68_99.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(tregistryottemperanzalegge68_99);
	tregistryottemperanzalegge68_99.defineKey("idregistryottemperanzalegge", "idreg");

	//////////////////// REGISTRYREGOLARITAFISCALE /////////////////////////////////
	var tregistryregolaritafiscale= new MetaTable("registryregolaritafiscale");
	tregistryregolaritafiscale.defineColumn("idregistryregolaritafiscale", typeof(int),false);
	tregistryregolaritafiscale.defineColumn("idreg", typeof(int),false);
	tregistryregolaritafiscale.defineColumn("regolaritacertification", typeof(Byte[]));
	tregistryregolaritafiscale.defineColumn("start", typeof(DateTime));
	tregistryregolaritafiscale.defineColumn("stop", typeof(DateTime));
	tregistryregolaritafiscale.defineColumn("cu", typeof(string),false);
	tregistryregolaritafiscale.defineColumn("ct", typeof(DateTime),false);
	tregistryregolaritafiscale.defineColumn("lu", typeof(string),false);
	tregistryregolaritafiscale.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(tregistryregolaritafiscale);
	tregistryregolaritafiscale.defineKey("idregistryregolaritafiscale", "idreg");

	//////////////////// REGISTRYVERIFICAANAC /////////////////////////////////
	var tregistryverificaanac= new MetaTable("registryverificaanac");
	tregistryverificaanac.defineColumn("idregistryverificaanac", typeof(int),false);
	tregistryverificaanac.defineColumn("idreg", typeof(int),false);
	tregistryverificaanac.defineColumn("verificaanaccertification", typeof(Byte[]));
	tregistryverificaanac.defineColumn("start", typeof(DateTime));
	tregistryverificaanac.defineColumn("stop", typeof(DateTime));
	tregistryverificaanac.defineColumn("cu", typeof(string),false);
	tregistryverificaanac.defineColumn("ct", typeof(DateTime),false);
	tregistryverificaanac.defineColumn("lu", typeof(string),false);
	tregistryverificaanac.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(tregistryverificaanac);
	tregistryverificaanac.defineKey("idregistryverificaanac", "idreg");

	//////////////////// REGISTRYATTACHMENT /////////////////////////////////
	var tregistryattachment= new MetaTable("registryattachment");
	tregistryattachment.defineColumn("idreg", typeof(int),false);
	tregistryattachment.defineColumn("idattachment", typeof(int),false);
	tregistryattachment.defineColumn("attachment", typeof(Byte[]));
	tregistryattachment.defineColumn("filename", typeof(string));
	tregistryattachment.defineColumn("cu", typeof(string));
	tregistryattachment.defineColumn("ct", typeof(DateTime));
	tregistryattachment.defineColumn("lu", typeof(string));
	tregistryattachment.defineColumn("lt", typeof(DateTime));
	tregistryattachment.defineColumn("idattachmentkind", typeof(int));
	Tables.Add(tregistryattachment);
	tregistryattachment.defineKey("idreg", "idattachment");

	//////////////////// REGISTRYPATTOINTEGRITA /////////////////////////////////
	var tregistrypattointegrita= new MetaTable("registrypattointegrita");
	tregistrypattointegrita.defineColumn("idregistrypattointegrita", typeof(int),false);
	tregistrypattointegrita.defineColumn("idreg", typeof(int),false);
	tregistrypattointegrita.defineColumn("ct", typeof(DateTime),false);
	tregistrypattointegrita.defineColumn("cu", typeof(string),false);
	tregistrypattointegrita.defineColumn("lt", typeof(DateTime),false);
	tregistrypattointegrita.defineColumn("lu", typeof(string),false);
	tregistrypattointegrita.defineColumn("start", typeof(DateTime));
	tregistrypattointegrita.defineColumn("stop", typeof(DateTime));
	tregistrypattointegrita.defineColumn("pattointegritacertification", typeof(Byte[]));
	Tables.Add(tregistrypattointegrita);
	tregistrypattointegrita.defineKey("idregistrypattointegrita", "idreg");

	//////////////////// NACE /////////////////////////////////
	var tnace= new MetaTable("nace");
	tnace.defineColumn("idnace", typeof(string),false);
	tnace.defineColumn("activity", typeof(string),false);
	tnace.defineColumn("lt", typeof(DateTime));
	tnace.defineColumn("lu", typeof(string));
	Tables.Add(tnace);
	tnace.defineKey("idnace");

	//////////////////// NATURAGIUR /////////////////////////////////
	var tnaturagiur= new MetaTable("naturagiur");
	tnaturagiur.defineColumn("idnaturagiur", typeof(int),false);
	tnaturagiur.defineColumn("title", typeof(string),false);
	tnaturagiur.defineColumn("sortcode", typeof(int),false);
	tnaturagiur.defineColumn("flagforeign", typeof(string));
	tnaturagiur.defineColumn("active", typeof(string),false);
	tnaturagiur.defineColumn("lt", typeof(DateTime));
	tnaturagiur.defineColumn("lu", typeof(string));
	Tables.Add(tnaturagiur);
	tnaturagiur.defineKey("idnaturagiur");

	//////////////////// NUMERODIP /////////////////////////////////
	var tnumerodip= new MetaTable("numerodip");
	tnumerodip.defineColumn("idnumerodip", typeof(int),false);
	tnumerodip.defineColumn("title", typeof(string),false);
	tnumerodip.defineColumn("sortcode", typeof(int),false);
	tnumerodip.defineColumn("active", typeof(string),false);
	tnumerodip.defineColumn("lt", typeof(DateTime));
	tnumerodip.defineColumn("lu", typeof(string));
	Tables.Add(tnumerodip);
	tnumerodip.defineKey("idnumerodip");

	//////////////////// ATECO /////////////////////////////////
	var tateco= new MetaTable("ateco");
	tateco.defineColumn("idateco", typeof(int),false);
	tateco.defineColumn("codice", typeof(string));
	tateco.defineColumn("title", typeof(string));
	tateco.defineColumn("lt", typeof(DateTime));
	tateco.defineColumn("lu", typeof(string));
	Tables.Add(tateco);
	tateco.defineKey("idateco");

	//////////////////// REGISTRY_ISTITUTI /////////////////////////////////
	var tregistry_istituti= new MetaTable("registry_istituti");
	tregistry_istituti.defineColumn("idreg", typeof(int),false);
	tregistry_istituti.defineColumn("idistitutoustat", typeof(int));
	tregistry_istituti.defineColumn("idistitutokind", typeof(int),false);
	tregistry_istituti.defineColumn("title", typeof(string));
	tregistry_istituti.defineColumn("title_en", typeof(string));
	tregistry_istituti.defineColumn("nome", typeof(string));
	tregistry_istituti.defineColumn("codicemiur", typeof(string));
	tregistry_istituti.defineColumn("codiceustat", typeof(string));
	tregistry_istituti.defineColumn("sortcode", typeof(int));
	tregistry_istituti.defineColumn("ct", typeof(DateTime));
	tregistry_istituti.defineColumn("cu", typeof(string),false);
	tregistry_istituti.defineColumn("lt", typeof(DateTime),false);
	tregistry_istituti.defineColumn("lu", typeof(string),false);
	tregistry_istituti.defineColumn("comune", typeof(string));
	Tables.Add(tregistry_istituti);
	tregistry_istituti.defineKey("idreg");

	#endregion


	#region DataRelation creation
	this.defineRelation("FK_registry_registryspecialcategory770","registry","registryspecialcategory770","idreg");
	this.defineRelation("FK_specialcategory770_registryspecialcategory770","specialcategory770","registryspecialcategory770","idspecialcategory770","ayear");
	this.defineRelation("FK_registry_registrycvattachment","registry","registrycvattachment","idreg");
	this.defineRelation("FK_registry_registrydurc","registry","registrydurc","idreg");
	this.defineRelation("FK_durckind_registrydurc","durckind","registrydurc","iddurckind");
	this.defineRelation("registryregistrypiva","registry","registrypiva","idreg");
	this.defineRelation("registryregistrycf","registry","registrycf","idreg");
	var cPar = new []{address.Columns["idaddress"]};
	var cChild = new []{registryaddress.Columns["idaddresskind"]};
	Relations.Add(new DataRelation("addressregistryaddress",cPar,cChild,false));

	this.defineRelation("geo_cityregistryaddress","geo_city","registryaddress","idcity");
	this.defineRelation("registryregistryaddress","registry","registryaddress","idreg");
	this.defineRelation("geo_nationregistryaddress","geo_nation","registryaddress","idnation");
	this.defineRelation("geo_cityviewgeo_city_agencyview","geo_cityview","geo_city_agencyview","idcity");
	this.defineRelation("registryregistrytaxablestatus","registry","registrytaxablestatus","idreg");
	this.defineRelation("registryregistrypaymethod","registry","registrypaymethod","idreg");
	this.defineRelation("registryregistrysorting","registry","registrysorting","idreg");
	this.defineRelation("sortingview_registrysorting","sortingview","registrysorting","idsor");
	this.defineRelation("registryregistryreference","registry","registryreference","idreg");
	this.defineRelation("dalia_position_registrylegalstatus","dalia_position","registrylegalstatus","iddaliaposition");
	this.defineRelation("positionregistrylegalstatus","position","registrylegalstatus","idposition");
	this.defineRelation("registryregistrylegalstatus","registry","registrylegalstatus","idreg");
	this.defineRelation("maritalstatusregistry","maritalstatus","registry","idmaritalstatus");
	this.defineRelation("categoryregistry","category","registry","idcategory");
	this.defineRelation("centralizedcategoryregistry","centralizedcategory","registry","idcentralizedcategory");
	this.defineRelation("titleregistry","title","registry","idtitle");
	cPar = new []{residence.Columns["idresidence"]};
	cChild = new []{registry.Columns["residence"]};
	Relations.Add(new DataRelation("residenceregistry",cPar,cChild,false));

	this.defineRelation("registryclassregistry","registryclass","registry","idregistryclass");
	this.defineRelation("geo_nazione_aliasregistry","geo_nazione_alias","registry","idnation");
	this.defineRelation("geo_cityviewregistry","geo_cityview","registry","idcity");
	this.defineRelation("registrykindregistry","registrykind","registry","idregistrykind");
	cPar = new []{accmotiveapplied_debit.Columns["idaccmotive"]};
	cChild = new []{registry.Columns["idaccmotivedebit"]};
	Relations.Add(new DataRelation("FK_accmotiveapplied_debit_registry",cPar,cChild,false));

	cPar = new []{accmotiveapplied_credit.Columns["idaccmotive"]};
	cChild = new []{registry.Columns["idaccmotivecredit"]};
	Relations.Add(new DataRelation("FK_accmotiveapplied_credit_registry",cPar,cChild,false));

	this.defineRelation("registry_registryvisura","registry","registryvisura","idreg");
	this.defineRelation("FK_registry_registrycasellariogiudiziale","registry","registrycasellariogiudiziale","idreg");
	this.defineRelation("registry_registrycasellarioamministrativo","registry","registrycasellarioamministrativo","idreg");
	this.defineRelation("registry_registryottemperanzalegge68_99","registry","registryottemperanzalegge68_99","idreg");
	this.defineRelation("registry_registryregolaritafiscale","registry","registryregolaritafiscale","idreg");
	this.defineRelation("registry_registryverificaanac","registry","registryverificaanac","idreg");
	this.defineRelation("registry_registryattachment","registry","registryattachment","idreg");
	this.defineRelation("registry_registrypattointegrita","registry","registrypattointegrita","idreg");
	this.defineRelation("nace_registry_aziende","nace","registry","idnace");
	cPar = new []{registry_istituti.Columns["idreg"]};
	cChild = new []{registry.Columns["idreg_istituti"]};
	Relations.Add(new DataRelation("registry_istituti_registry_docenti",cPar,cChild,false));

	this.defineRelation("ateco_registry_aziende","ateco","registry","idateco");
	this.defineRelation("numerodip_registry","numerodip","registry","idnumerodip");
	this.defineRelation("naturagiur_registry","naturagiur","registry","idnaturagiur");
	#endregion

}
}
}
