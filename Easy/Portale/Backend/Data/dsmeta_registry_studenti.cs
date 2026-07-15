/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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
[System.Xml.Serialization.XmlRoot("dsmeta_registry_studenti"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_registry_studenti: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable corsostudio 		=> (MetaTable)Tables["corsostudio"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_alias1 		=> (MetaTable)Tables["registry_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istattitolistudio 		=> (MetaTable)Tables["istattitolistudio"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico 		=> (MetaTable)Tables["annoaccademico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable titolostudio 		=> (MetaTable)Tables["titolostudio"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryreference 		=> (MetaTable)Tables["registryreference"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrymultikind 		=> (MetaTable)Tables["registrymultikind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrymultikindregistry 		=> (MetaTable)Tables["registrymultikindregistry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_nation_alias5 		=> (MetaTable)Tables["geo_nation_alias5"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_city_alias5 		=> (MetaTable)Tables["geo_city_alias5"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable address 		=> (MetaTable)Tables["address"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryaddress 		=> (MetaTable)Tables["registryaddress"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryattach 		=> (MetaTable)Tables["registryattach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_city 		=> (MetaTable)Tables["geo_city"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_nation 		=> (MetaTable)Tables["geo_nation"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable maritalstatusdefaultview 		=> (MetaTable)Tables["maritalstatusdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable residence 		=> (MetaTable)Tables["residence"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable title 		=> (MetaTable)Tables["title"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryclasspersoneview 		=> (MetaTable)Tables["registryclasspersoneview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry 		=> (MetaTable)Tables["registry"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_registry_studenti(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_registry_studenti (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_registry_studenti";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_registry_studenti.xsd";

	#region create DataTables
	//////////////////// CORSOSTUDIO /////////////////////////////////
	var tcorsostudio= new MetaTable("corsostudio");
	tcorsostudio.defineColumn("almalaureasurvey", typeof(string));
	tcorsostudio.defineColumn("annoistituz", typeof(int));
	tcorsostudio.defineColumn("basevoto", typeof(int));
	tcorsostudio.defineColumn("codice", typeof(string));
	tcorsostudio.defineColumn("codicemiur", typeof(string));
	tcorsostudio.defineColumn("codicemiurlungo", typeof(string));
	tcorsostudio.defineColumn("crediti", typeof(int));
	tcorsostudio.defineColumn("ct", typeof(DateTime),false);
	tcorsostudio.defineColumn("cu", typeof(string),false);
	tcorsostudio.defineColumn("durata", typeof(int));
	tcorsostudio.defineColumn("idcorsostudio", typeof(int),false);
	tcorsostudio.defineColumn("idcorsostudiokind", typeof(int),false);
	tcorsostudio.defineColumn("idcorsostudiolivello", typeof(int));
	tcorsostudio.defineColumn("idcorsostudionorma", typeof(int));
	tcorsostudio.defineColumn("idduratakind", typeof(int));
	tcorsostudio.defineColumn("idstruttura", typeof(int));
	tcorsostudio.defineColumn("lt", typeof(DateTime),false);
	tcorsostudio.defineColumn("lu", typeof(string),false);
	tcorsostudio.defineColumn("obbform", typeof(string));
	tcorsostudio.defineColumn("sboccocc", typeof(string));
	tcorsostudio.defineColumn("title", typeof(string));
	tcorsostudio.defineColumn("title_en", typeof(string));
	Tables.Add(tcorsostudio);
	tcorsostudio.defineKey("idcorsostudio");

	//////////////////// REGISTRY_ALIAS1 /////////////////////////////////
	var tregistry_alias1= new MetaTable("registry_alias1");
	tregistry_alias1.defineColumn("active", typeof(string),false);
	tregistry_alias1.defineColumn("idreg", typeof(int),false);
	tregistry_alias1.defineColumn("title", typeof(string),false);
	tregistry_alias1.ExtendedProperties["TableForReading"]="registry";
	Tables.Add(tregistry_alias1);
	tregistry_alias1.defineKey("idreg");

	//////////////////// ISTATTITOLISTUDIO /////////////////////////////////
	var tistattitolistudio= new MetaTable("istattitolistudio");
	tistattitolistudio.defineColumn("idistattitolistudio", typeof(int),false);
	tistattitolistudio.defineColumn("titolo", typeof(string),false);
	Tables.Add(tistattitolistudio);
	tistattitolistudio.defineKey("idistattitolistudio");

	//////////////////// ANNOACCADEMICO /////////////////////////////////
	var tannoaccademico= new MetaTable("annoaccademico");
	tannoaccademico.defineColumn("aa", typeof(string),false);
	Tables.Add(tannoaccademico);
	tannoaccademico.defineKey("aa");

	//////////////////// TITOLOSTUDIO /////////////////////////////////
	var ttitolostudio= new MetaTable("titolostudio");
	ttitolostudio.defineColumn("aa", typeof(string),false);
	ttitolostudio.defineColumn("conseguito", typeof(string),false);
	ttitolostudio.defineColumn("ct", typeof(DateTime));
	ttitolostudio.defineColumn("cu", typeof(string));
	ttitolostudio.defineColumn("data", typeof(DateTime),false);
	ttitolostudio.defineColumn("giudizio", typeof(string));
	ttitolostudio.defineColumn("idattach", typeof(int));
	ttitolostudio.defineColumn("idistattitolistudio", typeof(int),false);
	ttitolostudio.defineColumn("idreg", typeof(int),false);
	ttitolostudio.defineColumn("idreg_istituti", typeof(int),false);
	ttitolostudio.defineColumn("idtitolostudio", typeof(int),false);
	ttitolostudio.defineColumn("lt", typeof(DateTime));
	ttitolostudio.defineColumn("lu", typeof(string));
	ttitolostudio.defineColumn("voto", typeof(int));
	ttitolostudio.defineColumn("votolode", typeof(string));
	ttitolostudio.defineColumn("votosu", typeof(int));
	ttitolostudio.defineColumn("!idistattitolistudio_istattitolistudio_titolo", typeof(string));
	ttitolostudio.defineColumn("!idreg_istituti_registry_title", typeof(string));
	Tables.Add(ttitolostudio);
	ttitolostudio.defineKey("idreg", "idtitolostudio");

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

	//////////////////// REGISTRYMULTIKIND /////////////////////////////////
	var tregistrymultikind= new MetaTable("registrymultikind");
	tregistrymultikind.defineColumn("active", typeof(string));
	tregistrymultikind.defineColumn("ct", typeof(DateTime));
	tregistrymultikind.defineColumn("cu", typeof(string));
	tregistrymultikind.defineColumn("description", typeof(string));
	tregistrymultikind.defineColumn("idregistrymultikind", typeof(int),false);
	tregistrymultikind.defineColumn("lt", typeof(DateTime));
	tregistrymultikind.defineColumn("lu", typeof(string));
	tregistrymultikind.defineColumn("title", typeof(string));
	Tables.Add(tregistrymultikind);
	tregistrymultikind.defineKey("idregistrymultikind");

	//////////////////// REGISTRYMULTIKINDREGISTRY /////////////////////////////////
	var tregistrymultikindregistry= new MetaTable("registrymultikindregistry");
	tregistrymultikindregistry.defineColumn("ct", typeof(DateTime));
	tregistrymultikindregistry.defineColumn("cu", typeof(string));
	tregistrymultikindregistry.defineColumn("idreg", typeof(int),false);
	tregistrymultikindregistry.defineColumn("idregistrymultikind", typeof(int),false);
	tregistrymultikindregistry.defineColumn("lt", typeof(DateTime));
	tregistrymultikindregistry.defineColumn("lu", typeof(string));
	Tables.Add(tregistrymultikindregistry);
	tregistrymultikindregistry.defineKey("idreg", "idregistrymultikind");

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

	//////////////////// REGISTRYATTACH /////////////////////////////////
	var tregistryattach= new MetaTable("registryattach");
	tregistryattach.defineColumn("ct", typeof(DateTime),false);
	tregistryattach.defineColumn("cu", typeof(string),false);
	tregistryattach.defineColumn("idattach", typeof(int),false);
	tregistryattach.defineColumn("idreg", typeof(int),false);
	tregistryattach.defineColumn("lt", typeof(DateTime),false);
	tregistryattach.defineColumn("lu", typeof(string),false);
	tregistryattach.defineColumn("title", typeof(string));
	Tables.Add(tregistryattach);
	tregistryattach.defineKey("idattach", "idreg");

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

	//////////////////// MARITALSTATUSDEFAULTVIEW /////////////////////////////////
	var tmaritalstatusdefaultview= new MetaTable("maritalstatusdefaultview");
	tmaritalstatusdefaultview.defineColumn("description", typeof(string),false);
	tmaritalstatusdefaultview.defineColumn("idmaritalstatus", typeof(string),false);
	tmaritalstatusdefaultview.defineColumn("maritalstatus_active", typeof(string));
	tmaritalstatusdefaultview.defineColumn("maritalstatus_ct", typeof(DateTime),false);
	tmaritalstatusdefaultview.defineColumn("maritalstatus_cu", typeof(string),false);
	tmaritalstatusdefaultview.defineColumn("maritalstatus_lt", typeof(DateTime),false);
	tmaritalstatusdefaultview.defineColumn("maritalstatus_lu", typeof(string),false);
	Tables.Add(tmaritalstatusdefaultview);
	tmaritalstatusdefaultview.defineKey("idmaritalstatus");

	//////////////////// RESIDENCE /////////////////////////////////
	var tresidence= new MetaTable("residence");
	tresidence.defineColumn("active", typeof(string));
	tresidence.defineColumn("description", typeof(string),false);
	tresidence.defineColumn("idresidence", typeof(int),false);
	Tables.Add(tresidence);
	tresidence.defineKey("idresidence");

	//////////////////// TITLE /////////////////////////////////
	var ttitle= new MetaTable("title");
	ttitle.defineColumn("active", typeof(string));
	ttitle.defineColumn("description", typeof(string),false);
	ttitle.defineColumn("idtitle", typeof(string),false);
	Tables.Add(ttitle);
	ttitle.defineKey("idtitle");

	//////////////////// REGISTRYCLASSPERSONEVIEW /////////////////////////////////
	var tregistryclasspersoneview= new MetaTable("registryclasspersoneview");
	tregistryclasspersoneview.defineColumn("dropdown_title", typeof(string),false);
	tregistryclasspersoneview.defineColumn("idregistryclass", typeof(string),false);
	tregistryclasspersoneview.defineColumn("registryclass_active", typeof(string));
	Tables.Add(tregistryclasspersoneview);
	tregistryclasspersoneview.defineKey("idregistryclass");

	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new MetaTable("registry");
	tregistry.defineColumn("acronim", typeof(string));
	tregistry.defineColumn("active", typeof(string),false);
	tregistry.defineColumn("annotation", typeof(string));
	tregistry.defineColumn("authorization_free", typeof(string));
	tregistry.defineColumn("badgecode", typeof(string));
	tregistry.defineColumn("birthdate", typeof(DateTime),false);
	tregistry.defineColumn("ccp", typeof(string));
	tregistry.defineColumn("cf", typeof(string));
	tregistry.defineColumn("code", typeof(string));
	tregistry.defineColumn("codicemiur", typeof(string));
	tregistry.defineColumn("codiceustat", typeof(string));
	tregistry.defineColumn("ct", typeof(DateTime),false);
	tregistry.defineColumn("cu", typeof(string),false);
	tregistry.defineColumn("email_fe", typeof(string));
	tregistry.defineColumn("extension", typeof(string));
	tregistry.defineColumn("extmatricula", typeof(string));
	tregistry.defineColumn("flag_pa", typeof(string));
	tregistry.defineColumn("flagbankitaliaproceeds", typeof(string));
	tregistry.defineColumn("foreigncf", typeof(string));
	tregistry.defineColumn("forename", typeof(string),false);
	tregistry.defineColumn("gender", typeof(string),false);
	tregistry.defineColumn("idaccmotivecredit", typeof(string));
	tregistry.defineColumn("idaccmotivedebit", typeof(string));
	tregistry.defineColumn("idanpr", typeof(string));
	tregistry.defineColumn("idateco", typeof(int));
	tregistry.defineColumn("idcategory", typeof(string));
	tregistry.defineColumn("idcentralizedcategory", typeof(string));
	tregistry.defineColumn("idcity", typeof(int));
	tregistry.defineColumn("idexternal", typeof(int));
	tregistry.defineColumn("idfonteindicebibliometrico", typeof(int));
	tregistry.defineColumn("idistitutokind", typeof(int));
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
	tregistry.defineColumn("institutionalcode", typeof(string));
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
	tregistry.defineColumn("referencenumber", typeof(string));
	tregistry.defineColumn("residence", typeof(int),false);
	tregistry.defineColumn("ricevimento", typeof(string));
	tregistry.defineColumn("rtf", typeof(Byte[]));
	tregistry.defineColumn("sdi_defrifamm", typeof(string));
	tregistry.defineColumn("sdi_norifamm", typeof(string));
	tregistry.defineColumn("soggiorno", typeof(string));
	tregistry.defineColumn("surname", typeof(string),false);
	tregistry.defineColumn("title", typeof(string),false);
	tregistry.defineColumn("title_en", typeof(string));
	tregistry.defineColumn("toredirect", typeof(int));
	tregistry.defineColumn("txt", typeof(string));
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{registry.Columns["idreg"]};
	var cChild = new []{titolostudio.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_titolostudio_registry_idreg",cPar,cChild,false));

	cPar = new []{registry_alias1.Columns["idreg"]};
	cChild = new []{titolostudio.Columns["idreg_istituti"]};
	Relations.Add(new DataRelation("FK_titolostudio_registry_alias1_idreg_istituti",cPar,cChild,false));

	cPar = new []{istattitolistudio.Columns["idistattitolistudio"]};
	cChild = new []{titolostudio.Columns["idistattitolistudio"]};
	Relations.Add(new DataRelation("FK_titolostudio_istattitolistudio_idistattitolistudio",cPar,cChild,false));

	cPar = new []{annoaccademico.Columns["aa"]};
	cChild = new []{titolostudio.Columns["aa"]};
	Relations.Add(new DataRelation("FK_titolostudio_annoaccademico_aa",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registryreference.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registryreference_registry_idreg",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registrymultikindregistry.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registrymultikindregistry_registry_idreg",cPar,cChild,false));

	cPar = new []{registrymultikind.Columns["idregistrymultikind"]};
	cChild = new []{registrymultikindregistry.Columns["idregistrymultikind"]};
	Relations.Add(new DataRelation("FK_registrymultikindregistry_registrymultikind_idregistrymultikind",cPar,cChild,false));

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
	cChild = new []{registryattach.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registryattach_registry_idreg",cPar,cChild,false));

	cPar = new []{geo_city.Columns["idcity"]};
	cChild = new []{registry.Columns["idcity"]};
	Relations.Add(new DataRelation("FK_registry_geo_city_idcity",cPar,cChild,false));

	cPar = new []{geo_nation.Columns["idnation"]};
	cChild = new []{registry.Columns["idnation"]};
	Relations.Add(new DataRelation("FK_registry_geo_nation_idnation",cPar,cChild,false));

	cPar = new []{maritalstatusdefaultview.Columns["idmaritalstatus"]};
	cChild = new []{registry.Columns["idmaritalstatus"]};
	Relations.Add(new DataRelation("FK_registry_maritalstatusdefaultview_idmaritalstatus",cPar,cChild,false));

	cPar = new []{residence.Columns["idresidence"]};
	cChild = new []{registry.Columns["residence"]};
	Relations.Add(new DataRelation("FK_registry_residence_residence",cPar,cChild,false));

	cPar = new []{title.Columns["idtitle"]};
	cChild = new []{registry.Columns["idtitle"]};
	Relations.Add(new DataRelation("FK_registry_title_idtitle",cPar,cChild,false));

	cPar = new []{registryclasspersoneview.Columns["idregistryclass"]};
	cChild = new []{registry.Columns["idregistryclass"]};
	Relations.Add(new DataRelation("FK_registry_registryclasspersoneview_idregistryclass",cPar,cChild,false));

	#endregion

}
}
}
