
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
[System.Xml.Serialization.XmlRoot("dsmeta_registry_anagraficaweb"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_registry_anagraficaweb: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry 		=> (MetaTable)Tables["registry"];

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
	public MetaTable registryreference 		=> (MetaTable)Tables["registryreference"];

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
	public MetaTable address 		=> (MetaTable)Tables["address"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryclass 		=> (MetaTable)Tables["registryclass"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_city 		=> (MetaTable)Tables["geo_city"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_cityview 		=> (MetaTable)Tables["geo_cityview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_city_agencyview 		=> (MetaTable)Tables["geo_city_agencyview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryaddress 		=> (MetaTable)Tables["registryaddress"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrymainview 		=> (MetaTable)Tables["registrymainview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_nazione_alias 		=> (MetaTable)Tables["geo_nazione_alias"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_nation 		=> (MetaTable)Tables["geo_nation"];

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

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_registry_anagraficaweb(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_registry_anagraficaweb (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_registry_anagraficaweb";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_registry_anagraficaweb.xsd";

	#region create DataTables
	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new MetaTable("registry");
	tregistry.defineColumn("idreg", typeof(int),false);
	tregistry.defineColumn("title", typeof(string));
	tregistry.defineColumn("cf", typeof(string));
	tregistry.defineColumn("p_iva", typeof(string));
	tregistry.defineColumn("residence", typeof(int));
	tregistry.defineColumn("idregistrykind", typeof(int));
	tregistry.defineColumn("annotation", typeof(string));
	tregistry.defineColumn("birthdate", typeof(DateTime));
	tregistry.defineColumn("gender", typeof(string));
	tregistry.defineColumn("surname", typeof(string));
	tregistry.defineColumn("forename", typeof(string));
	tregistry.defineColumn("foreigncf", typeof(string));
	tregistry.defineColumn("active", typeof(string));
	tregistry.defineColumn("txt", typeof(string));
	tregistry.defineColumn("rtf", typeof(Byte[]));
	tregistry.defineColumn("cu", typeof(string),false);
	tregistry.defineColumn("ct", typeof(DateTime),false);
	tregistry.defineColumn("lu", typeof(string),false);
	tregistry.defineColumn("lt", typeof(DateTime),false);
	tregistry.defineColumn("extmatricula", typeof(string));
	tregistry.defineColumn("idregistryclass", typeof(string));
	tregistry.defineColumn("idcentralizedcategory", typeof(string));
	tregistry.defineColumn("idtitle", typeof(string));
	tregistry.defineColumn("idmaritalstatus", typeof(string));
	tregistry.defineColumn("badgecode", typeof(string));
	tregistry.defineColumn("maritalsurname", typeof(string));
	tregistry.defineColumn("idcategory", typeof(string));
	tregistry.defineColumn("idcity", typeof(int));
	tregistry.defineColumn("location", typeof(string));
	tregistry.defineColumn("idnation", typeof(int));
	tregistry.defineColumn("authorization_free", typeof(string));
	tregistry.defineColumn("multi_cf", typeof(string));
	tregistry.defineColumn("idaccmotivecredit", typeof(string));
	tregistry.defineColumn("idaccmotivedebit", typeof(string));
	tregistry.defineColumn("ccp", typeof(string));
	tregistry.defineColumn("flagbankitaliaproceeds", typeof(string));
	tregistry.defineColumn("ipa_fe", typeof(string));
	tregistry.defineColumn("flag_pa", typeof(string));
	tregistry.defineColumn("sdi_norifamm", typeof(string));
	tregistry.defineColumn("sdi_defrifamm", typeof(string));
	tregistry.defineColumn("pec_fe", typeof(string));
	tregistry.defineColumn("email_fe", typeof(string));
	tregistry.defineColumn("!rtf", typeof(string));
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
	var tregistryreference= new MetaTable("registryreference");
	tregistryreference.defineColumn("referencename", typeof(string),false);
	tregistryreference.defineColumn("idreg", typeof(int),false);
	tregistryreference.defineColumn("registryreferencerole", typeof(string));
	tregistryreference.defineColumn("phonenumber", typeof(string));
	tregistryreference.defineColumn("faxnumber", typeof(string));
	tregistryreference.defineColumn("mobilenumber", typeof(string));
	tregistryreference.defineColumn("email", typeof(string));
	tregistryreference.defineColumn("userweb", typeof(string));
	tregistryreference.defineColumn("passwordweb", typeof(string));
	tregistryreference.defineColumn("txt", typeof(string));
	tregistryreference.defineColumn("rtf", typeof(Byte[]));
	tregistryreference.defineColumn("cu", typeof(string),false);
	tregistryreference.defineColumn("ct", typeof(DateTime),false);
	tregistryreference.defineColumn("lu", typeof(string),false);
	tregistryreference.defineColumn("lt", typeof(DateTime),false);
	tregistryreference.defineColumn("flagdefault", typeof(string));
	tregistryreference.defineColumn("idregistryreference", typeof(int),false);
	tregistryreference.defineColumn("skypenumber", typeof(string));
	tregistryreference.defineColumn("msnnumber", typeof(string));
	tregistryreference.defineColumn("pec", typeof(string));
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
	tregistrypaymethod.defineColumn("idattach_ccdedicato_doc", typeof(int));
	tregistrypaymethod.defineColumn("idattach_ccdedicato_cf", typeof(int));
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
	var taddress= new MetaTable("address");
	taddress.defineColumn("idaddress", typeof(int),false);
	taddress.defineColumn("description", typeof(string),false);
	taddress.defineColumn("lt", typeof(DateTime));
	taddress.defineColumn("lu", typeof(string));
	taddress.defineColumn("active", typeof(string));
	taddress.defineColumn("codeaddress", typeof(string));
	Tables.Add(taddress);
	taddress.defineKey("idaddress");

	//////////////////// REGISTRYCLASS /////////////////////////////////
	var tregistryclass= new MetaTable("registryclass");
	tregistryclass.defineColumn("idregistryclass", typeof(string),false);
	tregistryclass.defineColumn("description", typeof(string),false);
	tregistryclass.defineColumn("flagtitle", typeof(string),false);
	tregistryclass.defineColumn("flagCF", typeof(string),false);
	tregistryclass.defineColumn("flagp_iva", typeof(string),false);
	tregistryclass.defineColumn("flagqualification", typeof(string),false);
	tregistryclass.defineColumn("flagextmatricula", typeof(string),false);
	tregistryclass.defineColumn("flagbadgecode", typeof(string),false);
	tregistryclass.defineColumn("flagmaritalstatus", typeof(string),false);
	tregistryclass.defineColumn("flagforeigncf", typeof(string),false);
	tregistryclass.defineColumn("flagmaritalsurname", typeof(string),false);
	tregistryclass.defineColumn("flagothers", typeof(string),false);
	tregistryclass.defineColumn("flagtitle_forced", typeof(string),false);
	tregistryclass.defineColumn("flagcf_forced", typeof(string),false);
	tregistryclass.defineColumn("flagp_iva_forced", typeof(string),false);
	tregistryclass.defineColumn("flagqualification_forced", typeof(string),false);
	tregistryclass.defineColumn("flagextmatricula_forced", typeof(string),false);
	tregistryclass.defineColumn("flagbadgecode_forced", typeof(string),false);
	tregistryclass.defineColumn("flagmaritalstatus_forced", typeof(string),false);
	tregistryclass.defineColumn("flagforeigncf_forced", typeof(string),false);
	tregistryclass.defineColumn("flagmaritalsurname_forced", typeof(string),false);
	tregistryclass.defineColumn("flagothers_forced", typeof(string),false);
	tregistryclass.defineColumn("active", typeof(string));
	tregistryclass.defineColumn("cu", typeof(string),false);
	tregistryclass.defineColumn("ct", typeof(DateTime),false);
	tregistryclass.defineColumn("lu", typeof(string),false);
	tregistryclass.defineColumn("lt", typeof(DateTime),false);
	tregistryclass.defineColumn("flagresidence", typeof(string));
	tregistryclass.defineColumn("flagresidence_forced", typeof(string));
	tregistryclass.defineColumn("flagfiscalresidence", typeof(string));
	tregistryclass.defineColumn("flagfiscalresidence_forced", typeof(string));
	tregistryclass.defineColumn("flagcfbutton", typeof(string));
	tregistryclass.defineColumn("flaginfofromcfbutton", typeof(string));
	tregistryclass.defineColumn("flaghuman", typeof(string));
	Tables.Add(tregistryclass);
	tregistryclass.defineKey("idregistryclass");

	//////////////////// GEO_CITY /////////////////////////////////
	var tgeo_city= new MetaTable("geo_city");
	tgeo_city.defineColumn("idcity", typeof(int),false);
	tgeo_city.defineColumn("oldcity", typeof(int));
	tgeo_city.defineColumn("newcity", typeof(int));
	tgeo_city.defineColumn("title", typeof(string));
	tgeo_city.defineColumn("start", typeof(DateTime));
	tgeo_city.defineColumn("stop", typeof(DateTime));
	tgeo_city.defineColumn("idcountry", typeof(int));
	tgeo_city.defineColumn("lu", typeof(string));
	tgeo_city.defineColumn("lt", typeof(DateTime));
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
	var tregistryaddress= new MetaTable("registryaddress");
	tregistryaddress.defineColumn("idreg", typeof(int),false);
	tregistryaddress.defineColumn("start", typeof(DateTime),false);
	tregistryaddress.defineColumn("idaddresskind", typeof(int),false);
	tregistryaddress.defineColumn("annotations", typeof(string));
	tregistryaddress.defineColumn("ct", typeof(DateTime));
	tregistryaddress.defineColumn("cu", typeof(string));
	tregistryaddress.defineColumn("stop", typeof(DateTime));
	tregistryaddress.defineColumn("active", typeof(string));
	tregistryaddress.defineColumn("idcity", typeof(int));
	tregistryaddress.defineColumn("!descrtipoindirizzo", typeof(string));
	tregistryaddress.defineColumn("address", typeof(string));
	tregistryaddress.defineColumn("lt", typeof(DateTime));
	tregistryaddress.defineColumn("lu", typeof(string));
	tregistryaddress.defineColumn("officename", typeof(string));
	tregistryaddress.defineColumn("cap", typeof(string));
	tregistryaddress.defineColumn("flagforeign", typeof(string));
	tregistryaddress.defineColumn("!comune", typeof(string));
	tregistryaddress.defineColumn("location", typeof(string));
	tregistryaddress.defineColumn("idnation", typeof(int));
	tregistryaddress.defineColumn("!localita", typeof(string));
	tregistryaddress.defineColumn("!nazione", typeof(string));
	tregistryaddress.defineColumn("recipientagency", typeof(string));
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
	var tgeo_nation= new MetaTable("geo_nation");
	tgeo_nation.defineColumn("idnation", typeof(int),false);
	tgeo_nation.defineColumn("start", typeof(DateTime));
	tgeo_nation.defineColumn("stop", typeof(DateTime));
	tgeo_nation.defineColumn("title", typeof(string));
	tgeo_nation.defineColumn("idcontinent", typeof(int));
	tgeo_nation.defineColumn("lt", typeof(DateTime));
	tgeo_nation.defineColumn("lu", typeof(string));
	tgeo_nation.defineColumn("newnation", typeof(int));
	tgeo_nation.defineColumn("oldnation", typeof(int));
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
	tregistrydurc.defineColumn("!durccertification", typeof(int));
	tregistrydurc.defineColumn("!selfcertification", typeof(int));
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
	tregistrycvattachment.defineColumn("!attachment", typeof(int));
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
	tregistryvisura.defineColumn("!visuracertification", typeof(int));
	Tables.Add(tregistryvisura);
	tregistryvisura.defineKey("idregistryvisura", "idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{registry.Columns["idreg"]};
	var cChild = new []{registryspecialcategory770.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registry_registryspecialcategory770",cPar,cChild,false));

	cPar = new []{specialcategory770.Columns["idspecialcategory770"], specialcategory770.Columns["ayear"]};
	cChild = new []{registryspecialcategory770.Columns["idspecialcategory770"], registryspecialcategory770.Columns["ayear"]};
	Relations.Add(new DataRelation("FK_specialcategory770_registryspecialcategory770",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registrycvattachment.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registry_registrycvattachment",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registrydurc.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registry_registrydurc",cPar,cChild,false));

	cPar = new []{durckind.Columns["iddurckind"]};
	cChild = new []{registrydurc.Columns["iddurckind"]};
	Relations.Add(new DataRelation("FK_durckind_registrydurc",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registrypiva.Columns["idreg"]};
	Relations.Add(new DataRelation("registryregistrypiva",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registrycf.Columns["idreg"]};
	Relations.Add(new DataRelation("registryregistrycf",cPar,cChild,false));

	cPar = new []{address.Columns["idaddress"]};
	cChild = new []{registryaddress.Columns["idaddresskind"]};
	Relations.Add(new DataRelation("addressregistryaddress",cPar,cChild,false));

	cPar = new []{geo_city.Columns["idcity"]};
	cChild = new []{registryaddress.Columns["idcity"]};
	Relations.Add(new DataRelation("geo_cityregistryaddress",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registryaddress.Columns["idreg"]};
	Relations.Add(new DataRelation("registryregistryaddress",cPar,cChild,false));

	cPar = new []{geo_nation.Columns["idnation"]};
	cChild = new []{registryaddress.Columns["idnation"]};
	Relations.Add(new DataRelation("geo_nationregistryaddress",cPar,cChild,false));

	cPar = new []{geo_cityview.Columns["idcity"]};
	cChild = new []{geo_city_agencyview.Columns["idcity"]};
	Relations.Add(new DataRelation("geo_cityviewgeo_city_agencyview",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registrytaxablestatus.Columns["idreg"]};
	Relations.Add(new DataRelation("registryregistrytaxablestatus",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registrypaymethod.Columns["idreg"]};
	Relations.Add(new DataRelation("registryregistrypaymethod",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registrysorting.Columns["idreg"]};
	Relations.Add(new DataRelation("registryregistrysorting",cPar,cChild,false));

	cPar = new []{sortingview.Columns["idsor"]};
	cChild = new []{registrysorting.Columns["idsor"]};
	Relations.Add(new DataRelation("sortingview_registrysorting",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registryreference.Columns["idreg"]};
	Relations.Add(new DataRelation("registryregistryreference",cPar,cChild,false));

	cPar = new []{dalia_position.Columns["iddaliaposition"]};
	cChild = new []{registrylegalstatus.Columns["iddaliaposition"]};
	Relations.Add(new DataRelation("dalia_position_registrylegalstatus",cPar,cChild,false));

	cPar = new []{position.Columns["idposition"]};
	cChild = new []{registrylegalstatus.Columns["idposition"]};
	Relations.Add(new DataRelation("positionregistrylegalstatus",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registrylegalstatus.Columns["idreg"]};
	Relations.Add(new DataRelation("registryregistrylegalstatus",cPar,cChild,false));

	cPar = new []{maritalstatus.Columns["idmaritalstatus"]};
	cChild = new []{registry.Columns["idmaritalstatus"]};
	Relations.Add(new DataRelation("maritalstatusregistry",cPar,cChild,false));

	cPar = new []{category.Columns["idcategory"]};
	cChild = new []{registry.Columns["idcategory"]};
	Relations.Add(new DataRelation("categoryregistry",cPar,cChild,false));

	cPar = new []{centralizedcategory.Columns["idcentralizedcategory"]};
	cChild = new []{registry.Columns["idcentralizedcategory"]};
	Relations.Add(new DataRelation("centralizedcategoryregistry",cPar,cChild,false));

	cPar = new []{title.Columns["idtitle"]};
	cChild = new []{registry.Columns["idtitle"]};
	Relations.Add(new DataRelation("titleregistry",cPar,cChild,false));

	cPar = new []{residence.Columns["idresidence"]};
	cChild = new []{registry.Columns["residence"]};
	Relations.Add(new DataRelation("residenceregistry",cPar,cChild,false));

	cPar = new []{registryclass.Columns["idregistryclass"]};
	cChild = new []{registry.Columns["idregistryclass"]};
	Relations.Add(new DataRelation("registryclassregistry",cPar,cChild,false));

	cPar = new []{geo_nazione_alias.Columns["idnation"]};
	cChild = new []{registry.Columns["idnation"]};
	Relations.Add(new DataRelation("geo_nazione_aliasregistry",cPar,cChild,false));

	cPar = new []{geo_cityview.Columns["idcity"]};
	cChild = new []{registry.Columns["idcity"]};
	Relations.Add(new DataRelation("geo_cityviewregistry",cPar,cChild,false));

	cPar = new []{registrykind.Columns["idregistrykind"]};
	cChild = new []{registry.Columns["idregistrykind"]};
	Relations.Add(new DataRelation("registrykindregistry",cPar,cChild,false));

	cPar = new []{accmotiveapplied_debit.Columns["idaccmotive"]};
	cChild = new []{registry.Columns["idaccmotivedebit"]};
	Relations.Add(new DataRelation("FK_accmotiveapplied_debit_registry",cPar,cChild,false));

	cPar = new []{accmotiveapplied_credit.Columns["idaccmotive"]};
	cChild = new []{registry.Columns["idaccmotivecredit"]};
	Relations.Add(new DataRelation("FK_accmotiveapplied_credit_registry",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registryvisura.Columns["idreg"]};
	Relations.Add(new DataRelation("registry_registryvisura",cPar,cChild,false));

	#endregion

}
}
}
