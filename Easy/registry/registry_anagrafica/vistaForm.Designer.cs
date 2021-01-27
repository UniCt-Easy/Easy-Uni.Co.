
/*
Easy
Copyright (C) 2021 Universit‡ degli Studi di Catania (www.unict.it)
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
	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public registryTable registry 		=> (registryTable)Tables["registry"];

	///<summary>
	///Stato civile
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable maritalstatus 		=> (MetaTable)Tables["maritalstatus"];

	///<summary>
	///Categoria
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable category 		=> (MetaTable)Tables["category"];

	///<summary>
	///Classificazione centralizzata anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable centralizedcategory 		=> (MetaTable)Tables["centralizedcategory"];

	///<summary>
	///Qualifica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable position 		=> (MetaTable)Tables["position"];

	///<summary>
	///Inquadramento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrylegalstatus 		=> (MetaTable)Tables["registrylegalstatus"];

	///<summary>
	///Contatto
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public registryreferenceTable registryreference 		=> (registryreferenceTable)Tables["registryreference"];

	///<summary>
	///Classificazione anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrysorting 		=> (MetaTable)Tables["registrysorting"];

	///<summary>
	///Classificazione Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrykind 		=> (MetaTable)Tables["registrykind"];

	///<summary>
	///Titolo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable title 		=> (MetaTable)Tables["title"];

	///<summary>
	///Modalit√† pagamento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrypaymethod 		=> (MetaTable)Tables["registrypaymethod"];

	///<summary>
	///Reddito Annuo Presunto
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrytaxablestatus 		=> (MetaTable)Tables["registrytaxablestatus"];

	///<summary>
	/// Tipo Residenza
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable residence 		=> (MetaTable)Tables["residence"];

	///<summary>
	///Tipo Indirizzo  (anagrafica)
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public addressTable address 		=> (addressTable)Tables["address"];

	///<summary>
	///Tipologie classificazione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public registryclassTable registryclass 		=> (registryclassTable)Tables["registryclass"];

	///<summary>
	///Comuni
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public geo_cityTable geo_city 		=> (geo_cityTable)Tables["geo_city"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_cityview 		=> (MetaTable)Tables["geo_cityview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_city_agencyview 		=> (MetaTable)Tables["geo_city_agencyview"];

	///<summary>
	///Indirizzo di anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public registryaddressTable registryaddress 		=> (registryaddressTable)Tables["registryaddress"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrymainview 		=> (MetaTable)Tables["registrymainview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_nazione_alias 		=> (MetaTable)Tables["geo_nazione_alias"];

	///<summary>
	///Nazioni
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public geo_nationTable geo_nation 		=> (geo_nationTable)Tables["geo_nation"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sortingview 		=> (MetaTable)Tables["sortingview"];

	///<summary>
	///Storicizzazione Codice Fiscale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrycf 		=> (MetaTable)Tables["registrycf"];

	///<summary>
	///Storicizzazione Partita IVA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrypiva 		=> (MetaTable)Tables["registrypiva"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accmotiveapplied_debit 		=> (MetaTable)Tables["accmotiveapplied_debit"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accmotiveapplied_credit 		=> (MetaTable)Tables["accmotiveapplied_credit"];

	///<summary>
	///DURC
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrydurc 		=> (MetaTable)Tables["registrydurc"];

	///<summary>
	///Tipo DURC
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable durckind 		=> (MetaTable)Tables["durckind"];

	///<summary>
	///CV
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrycvattachment 		=> (MetaTable)Tables["registrycvattachment"];

	///<summary>
	///Categorie particolari
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryspecialcategory770 		=> (MetaTable)Tables["registryspecialcategory770"];

	///<summary>
	///Categoria speciale 770
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable specialcategory770 		=> (MetaTable)Tables["specialcategory770"];

	///<summary>
	///Posizione Dalia
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable dalia_position 		=> (MetaTable)Tables["dalia_position"];

	///<summary>
	///visura camerale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryvisura 		=> (MetaTable)Tables["registryvisura"];

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
	tregistry.addBaseColumns("idreg","title","cf","p_iva","residence","idregistrykind","annotation","birthdate","gender","surname","forename","foreigncf","active","txt","rtf","cu","ct","lu","lt","extmatricula","idregistryclass","idcentralizedcategory","idtitle","idmaritalstatus","badgecode","maritalsurname","idcategory","idcity","location","idnation","authorization_free","multi_cf","idaccmotivecredit","idaccmotivedebit","ccp","flagbankitaliaproceeds","ipa_fe","flag_pa","sdi_norifamm","sdi_defrifamm","pec_fe","email_fe","ipa_perlapa");
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
	Tables.Add(tregistrylegalstatus);
	tregistrylegalstatus.defineKey("idreg", "idregistrylegalstatus");

	//////////////////// REGISTRYREFERENCE /////////////////////////////////
	var tregistryreference= new registryreferenceTable();
	tregistryreference.addBaseColumns("referencename","idreg","registryreferencerole","phonenumber","faxnumber","mobilenumber","email","userweb","passwordweb","txt","rtf","cu","ct","lu","lt","flagdefault","idregistryreference","skypenumber","msnnumber","pec");
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
	#endregion

}
}
}
