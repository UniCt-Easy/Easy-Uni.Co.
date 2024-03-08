
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
[System.Xml.Serialization.XmlRoot("dsmeta_registry_docenti_docentenoaltro"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_registry_docenti_docentenoaltro: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sospensione 		=> (MetaTable)Tables["sospensione"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable position 		=> (MetaTable)Tables["position"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable inquadramento 		=> (MetaTable)Tables["inquadramento"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrylegalstatus 		=> (MetaTable)Tables["registrylegalstatus"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable contrattostipendioview 		=> (MetaTable)Tables["contrattostipendioview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable fonteindicebibliometrico 		=> (MetaTable)Tables["fonteindicebibliometrico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryistitutiview 		=> (MetaTable)Tables["registryistitutiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable classconsorsualedefaultview 		=> (MetaTable)Tables["classconsorsualedefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sasddefaultview 		=> (MetaTable)Tables["sasddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturadefaultview 		=> (MetaTable)Tables["strutturadefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable residence 		=> (MetaTable)Tables["residence"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryclasspersoneview 		=> (MetaTable)Tables["registryclasspersoneview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable maritalstatus 		=> (MetaTable)Tables["maritalstatus"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_nation 		=> (MetaTable)Tables["geo_nation"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_city 		=> (MetaTable)Tables["geo_city"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable title 		=> (MetaTable)Tables["title"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry 		=> (MetaTable)Tables["registry"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_registry_docenti_docentenoaltro(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_registry_docenti_docentenoaltro (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_registry_docenti_docentenoaltro";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_registry_docenti_docentenoaltro.xsd";

	#region create DataTables
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

	//////////////////// POSITION /////////////////////////////////
	var tposition= new MetaTable("position");
	tposition.defineColumn("active", typeof(string));
	tposition.defineColumn("idposition", typeof(int),false);
	tposition.defineColumn("title", typeof(string));
	Tables.Add(tposition);
	tposition.defineKey("idposition");

	//////////////////// INQUADRAMENTO /////////////////////////////////
	var tinquadramento= new MetaTable("inquadramento");
	tinquadramento.defineColumn("idinquadramento", typeof(int),false);
	tinquadramento.defineColumn("idposition", typeof(int),false);
	tinquadramento.defineColumn("tempdef", typeof(string));
	tinquadramento.defineColumn("title", typeof(string));
	Tables.Add(tinquadramento);
	tinquadramento.defineKey("idinquadramento", "idposition");

	//////////////////// REGISTRYLEGALSTATUS /////////////////////////////////
	var tregistrylegalstatus= new MetaTable("registrylegalstatus");
	tregistrylegalstatus.defineColumn("!anni", typeof(string));
	tregistrylegalstatus.defineColumn("!giorni", typeof(string));
	tregistrylegalstatus.defineColumn("!mesi", typeof(string));
	tregistrylegalstatus.defineColumn("active", typeof(string));
	tregistrylegalstatus.defineColumn("csa_class", typeof(string));
	tregistrylegalstatus.defineColumn("csa_compartment", typeof(string));
	tregistrylegalstatus.defineColumn("csa_role", typeof(string));
	tregistrylegalstatus.defineColumn("ct", typeof(DateTime));
	tregistrylegalstatus.defineColumn("cu", typeof(string));
	tregistrylegalstatus.defineColumn("datarivalutazione", typeof(DateTime));
	tregistrylegalstatus.defineColumn("flagdefault", typeof(string));
	tregistrylegalstatus.defineColumn("iddaliaposition", typeof(int));
	tregistrylegalstatus.defineColumn("idinquadramento", typeof(int));
	tregistrylegalstatus.defineColumn("idposition", typeof(int));
	tregistrylegalstatus.defineColumn("idreg", typeof(int),false);
	tregistrylegalstatus.defineColumn("idregistrylegalstatus", typeof(int),false);
	tregistrylegalstatus.defineColumn("incomeclass", typeof(int));
	tregistrylegalstatus.defineColumn("incomeclassvalidity", typeof(DateTime));
	tregistrylegalstatus.defineColumn("livello", typeof(int));
	tregistrylegalstatus.defineColumn("lt", typeof(DateTime));
	tregistrylegalstatus.defineColumn("lu", typeof(string));
	tregistrylegalstatus.defineColumn("parttime", typeof(decimal));
	tregistrylegalstatus.defineColumn("percentualesufondiateneo", typeof(decimal));
	tregistrylegalstatus.defineColumn("rtf", typeof(Byte[]));
	tregistrylegalstatus.defineColumn("start", typeof(DateTime));
	tregistrylegalstatus.defineColumn("stop", typeof(DateTime));
	tregistrylegalstatus.defineColumn("tempdef", typeof(string));
	tregistrylegalstatus.defineColumn("tempindet", typeof(string));
	tregistrylegalstatus.defineColumn("txt", typeof(string));
	tregistrylegalstatus.defineColumn("!idinquadramento_inquadramento_title", typeof(string));
	tregistrylegalstatus.defineColumn("!idinquadramento_inquadramento_tempdef", typeof(string));
	tregistrylegalstatus.defineColumn("!idposition_position_title", typeof(string));
	Tables.Add(tregistrylegalstatus);
	tregistrylegalstatus.defineKey("idreg", "idregistrylegalstatus");

	//////////////////// CONTRATTOSTIPENDIOVIEW /////////////////////////////////
	var tcontrattostipendioview= new MetaTable("contrattostipendioview");
	tcontrattostipendioview.defineColumn("anno", typeof(int),false);
	tcontrattostipendioview.defineColumn("assegno", typeof(decimal));
	tcontrattostipendioview.defineColumn("caricoente", typeof(decimal));
	tcontrattostipendioview.defineColumn("classe", typeof(int));
	tcontrattostipendioview.defineColumn("ct", typeof(DateTime));
	tcontrattostipendioview.defineColumn("cu", typeof(string));
	tcontrattostipendioview.defineColumn("idinquadramento", typeof(int),false);
	tcontrattostipendioview.defineColumn("idmese", typeof(int),false);
	tcontrattostipendioview.defineColumn("idposition", typeof(int),false);
	tcontrattostipendioview.defineColumn("idreg", typeof(int),false);
	tcontrattostipendioview.defineColumn("idregistrylegalstatus", typeof(int),false);
	tcontrattostipendioview.defineColumn("idstipendio", typeof(int),false);
	tcontrattostipendioview.defineColumn("iis", typeof(decimal));
	tcontrattostipendioview.defineColumn("irap", typeof(decimal));
	tcontrattostipendioview.defineColumn("lordo", typeof(decimal));
	tcontrattostipendioview.defineColumn("lt", typeof(DateTime));
	tcontrattostipendioview.defineColumn("lu", typeof(string));
	tcontrattostipendioview.defineColumn("mese", typeof(string),false);
	tcontrattostipendioview.defineColumn("mesilavorati", typeof(int));
	tcontrattostipendioview.defineColumn("rifnormativo", typeof(string));
	tcontrattostipendioview.defineColumn("scatto", typeof(int));
	tcontrattostipendioview.defineColumn("siglaimportazione", typeof(string));
	tcontrattostipendioview.defineColumn("start", typeof(DateTime),false);
	tcontrattostipendioview.defineColumn("stipendio", typeof(decimal));
	tcontrattostipendioview.defineColumn("stop", typeof(DateTime));
	tcontrattostipendioview.defineColumn("totale", typeof(decimal));
	tcontrattostipendioview.defineColumn("totaleanno", typeof(decimal));
	tcontrattostipendioview.defineColumn("totaletfr", typeof(decimal));
	tcontrattostipendioview.defineColumn("tredicesima", typeof(decimal),false);
	tcontrattostipendioview.defineColumn("validfortredicesima", typeof(string),false);
	Tables.Add(tcontrattostipendioview);
	tcontrattostipendioview.defineKey("anno", "idreg", "idregistrylegalstatus", "idstipendio", "mese");

	//////////////////// FONTEINDICEBIBLIOMETRICO /////////////////////////////////
	var tfonteindicebibliometrico= new MetaTable("fonteindicebibliometrico");
	tfonteindicebibliometrico.defineColumn("active", typeof(string));
	tfonteindicebibliometrico.defineColumn("idfonteindicebibliometrico", typeof(int),false);
	tfonteindicebibliometrico.defineColumn("title", typeof(string));
	Tables.Add(tfonteindicebibliometrico);
	tfonteindicebibliometrico.defineKey("idfonteindicebibliometrico");

	//////////////////// REGISTRYISTITUTIVIEW /////////////////////////////////
	var tregistryistitutiview= new MetaTable("registryistitutiview");
	tregistryistitutiview.defineColumn("dropdown_title", typeof(string),false);
	tregistryistitutiview.defineColumn("idreg", typeof(int),false);
	tregistryistitutiview.defineColumn("registry_active", typeof(string));
	Tables.Add(tregistryistitutiview);
	tregistryistitutiview.defineKey("idreg");

	//////////////////// CLASSCONSORSUALEDEFAULTVIEW /////////////////////////////////
	var tclassconsorsualedefaultview= new MetaTable("classconsorsualedefaultview");
	tclassconsorsualedefaultview.defineColumn("classconsorsuale_active", typeof(string));
	tclassconsorsualedefaultview.defineColumn("dropdown_title", typeof(string),false);
	tclassconsorsualedefaultview.defineColumn("idclassconsorsuale", typeof(int),false);
	Tables.Add(tclassconsorsualedefaultview);
	tclassconsorsualedefaultview.defineKey("idclassconsorsuale");

	//////////////////// SASDDEFAULTVIEW /////////////////////////////////
	var tsasddefaultview= new MetaTable("sasddefaultview");
	tsasddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tsasddefaultview.defineColumn("idsasd", typeof(int),false);
	Tables.Add(tsasddefaultview);
	tsasddefaultview.defineKey("idsasd");

	//////////////////// STRUTTURADEFAULTVIEW /////////////////////////////////
	var tstrutturadefaultview= new MetaTable("strutturadefaultview");
	tstrutturadefaultview.defineColumn("dropdown_title", typeof(string),false);
	tstrutturadefaultview.defineColumn("idstruttura", typeof(int),false);
	tstrutturadefaultview.defineColumn("struttura_active", typeof(string));
	Tables.Add(tstrutturadefaultview);
	tstrutturadefaultview.defineKey("idstruttura");

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

	//////////////////// REGISTRYCLASSPERSONEVIEW /////////////////////////////////
	var tregistryclasspersoneview= new MetaTable("registryclasspersoneview");
	tregistryclasspersoneview.defineColumn("dropdown_title", typeof(string),false);
	tregistryclasspersoneview.defineColumn("idregistryclass", typeof(string),false);
	tregistryclasspersoneview.defineColumn("registryclass_active", typeof(string));
	Tables.Add(tregistryclasspersoneview);
	tregistryclasspersoneview.defineKey("idregistryclass");

	//////////////////// MARITALSTATUS /////////////////////////////////
	var tmaritalstatus= new MetaTable("maritalstatus");
	tmaritalstatus.defineColumn("active", typeof(string));
	tmaritalstatus.defineColumn("ct", typeof(DateTime),false);
	tmaritalstatus.defineColumn("cu", typeof(string),false);
	tmaritalstatus.defineColumn("description", typeof(string),false);
	tmaritalstatus.defineColumn("idmaritalstatus", typeof(string),false);
	tmaritalstatus.defineColumn("lt", typeof(DateTime),false);
	tmaritalstatus.defineColumn("lu", typeof(string),false);
	Tables.Add(tmaritalstatus);
	tmaritalstatus.defineKey("idmaritalstatus");

	//////////////////// GEO_NATION /////////////////////////////////
	var tgeo_nation= new MetaTable("geo_nation");
	tgeo_nation.defineColumn("idnation", typeof(int),false);
	tgeo_nation.defineColumn("title", typeof(string));
	Tables.Add(tgeo_nation);
	tgeo_nation.defineKey("idnation");

	//////////////////// GEO_CITY /////////////////////////////////
	var tgeo_city= new MetaTable("geo_city");
	tgeo_city.defineColumn("idcity", typeof(int),false);
	tgeo_city.defineColumn("title", typeof(string));
	Tables.Add(tgeo_city);
	tgeo_city.defineKey("idcity");

	//////////////////// TITLE /////////////////////////////////
	var ttitle= new MetaTable("title");
	ttitle.defineColumn("active", typeof(string));
	ttitle.defineColumn("description", typeof(string),false);
	ttitle.defineColumn("idtitle", typeof(string),false);
	Tables.Add(ttitle);
	ttitle.defineKey("idtitle");

	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new MetaTable("registry");
	tregistry.defineColumn("active", typeof(string));
	tregistry.defineColumn("annotation", typeof(string));
	tregistry.defineColumn("authorization_free", typeof(string));
	tregistry.defineColumn("badgecode", typeof(string));
	tregistry.defineColumn("birthdate", typeof(DateTime),false);
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
	tregistry.defineColumn("forename", typeof(string),false);
	tregistry.defineColumn("gender", typeof(string),false);
	tregistry.defineColumn("idaccmotivecredit", typeof(string));
	tregistry.defineColumn("idaccmotivedebit", typeof(string));
	tregistry.defineColumn("idateco", typeof(int));
	tregistry.defineColumn("idcategory", typeof(string));
	tregistry.defineColumn("idcentralizedcategory", typeof(string));
	tregistry.defineColumn("idcity", typeof(int),false);
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
	var cChild = new []{sospensione.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_sospensione_registry_idreg",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registrylegalstatus.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registrylegalstatus_registry_idreg",cPar,cChild,false));

	cPar = new []{position.Columns["idposition"]};
	cChild = new []{registrylegalstatus.Columns["idposition"]};
	Relations.Add(new DataRelation("FK_registrylegalstatus_position_idposition",cPar,cChild,false));

	cPar = new []{inquadramento.Columns["idinquadramento"]};
	cChild = new []{registrylegalstatus.Columns["idinquadramento"]};
	Relations.Add(new DataRelation("FK_registrylegalstatus_inquadramento_idinquadramento",cPar,cChild,false));

	cPar = new []{contrattostipendioview.Columns["idreg"]};
	cChild = new []{registry.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registry_contrattostipendioview_idreg",cPar,cChild,false));

	cPar = new []{fonteindicebibliometrico.Columns["idfonteindicebibliometrico"]};
	cChild = new []{registry.Columns["idfonteindicebibliometrico"]};
	Relations.Add(new DataRelation("FK_registry_fonteindicebibliometrico_idfonteindicebibliometrico",cPar,cChild,false));

	cPar = new []{registryistitutiview.Columns["idreg"]};
	cChild = new []{registry.Columns["idreg_istituti"]};
	Relations.Add(new DataRelation("FK_registry_registryistitutiview_idreg_istituti",cPar,cChild,false));

	cPar = new []{classconsorsualedefaultview.Columns["idclassconsorsuale"]};
	cChild = new []{registry.Columns["idclassconsorsuale"]};
	Relations.Add(new DataRelation("FK_registry_classconsorsualedefaultview_idclassconsorsuale",cPar,cChild,false));

	cPar = new []{sasddefaultview.Columns["idsasd"]};
	cChild = new []{registry.Columns["idsasd"]};
	Relations.Add(new DataRelation("FK_registry_sasddefaultview_idsasd",cPar,cChild,false));

	cPar = new []{strutturadefaultview.Columns["idstruttura"]};
	cChild = new []{registry.Columns["idstruttura"]};
	Relations.Add(new DataRelation("FK_registry_strutturadefaultview_idstruttura",cPar,cChild,false));

	cPar = new []{residence.Columns["idresidence"]};
	cChild = new []{registry.Columns["residence"]};
	Relations.Add(new DataRelation("FK_registry_residence_residence",cPar,cChild,false));

	cPar = new []{registryclasspersoneview.Columns["idregistryclass"]};
	cChild = new []{registry.Columns["idregistryclass"]};
	Relations.Add(new DataRelation("FK_registry_registryclasspersoneview_idregistryclass",cPar,cChild,false));

	cPar = new []{maritalstatus.Columns["idmaritalstatus"]};
	cChild = new []{registry.Columns["idmaritalstatus"]};
	Relations.Add(new DataRelation("FK_registry_maritalstatus_idmaritalstatus",cPar,cChild,false));

	cPar = new []{geo_nation.Columns["idnation"]};
	cChild = new []{registry.Columns["idnation"]};
	Relations.Add(new DataRelation("FK_registry_geo_nation_idnation",cPar,cChild,false));

	cPar = new []{geo_city.Columns["idcity"]};
	cChild = new []{registry.Columns["idcity"]};
	Relations.Add(new DataRelation("FK_registry_geo_city_idcity",cPar,cChild,false));

	cPar = new []{title.Columns["idtitle"]};
	cChild = new []{registry.Columns["idtitle"]};
	Relations.Add(new DataRelation("FK_registry_title_idtitle",cPar,cChild,false));

	#endregion

}
}
}
