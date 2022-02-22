
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
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace Backend.Data {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta_registry_amministrativi_personale"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_registry_amministrativi_personale: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sospensione 		=> (MetaTable)Tables["sospensione"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettotimesheetprogetto 		=> (MetaTable)Tables["progettotimesheetprogetto"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable year 		=> (MetaTable)Tables["year"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable timesheettemplate 		=> (MetaTable)Tables["timesheettemplate"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettotimesheet 		=> (MetaTable)Tables["progettotimesheet"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable stipendioannuo 		=> (MetaTable)Tables["stipendioannuo"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable cedolino 		=> (MetaTable)Tables["cedolino"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable contrattokind_alias1 		=> (MetaTable)Tables["contrattokind_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable inquadramento 		=> (MetaTable)Tables["inquadramento"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable contratto 		=> (MetaTable)Tables["contratto"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable contrattokind 		=> (MetaTable)Tables["contrattokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable residence 		=> (MetaTable)Tables["residence"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrykind 		=> (MetaTable)Tables["registrykind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable category 		=> (MetaTable)Tables["category"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryclassdefaultview 		=> (MetaTable)Tables["registryclassdefaultview"];

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

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_amministrativi 		=> (MetaTable)Tables["registry_amministrativi"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_registry_amministrativi_personale(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_registry_amministrativi_personale (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_registry_amministrativi_personale";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_registry_amministrativi_personale.xsd";

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

	//////////////////// PROGETTOTIMESHEETPROGETTO /////////////////////////////////
	var tprogettotimesheetprogetto= new MetaTable("progettotimesheetprogetto");
	tprogettotimesheetprogetto.defineColumn("ct", typeof(DateTime));
	tprogettotimesheetprogetto.defineColumn("cu", typeof(string));
	tprogettotimesheetprogetto.defineColumn("idprogetto", typeof(int),false);
	tprogettotimesheetprogetto.defineColumn("idprogettotimesheet", typeof(int),false);
	tprogettotimesheetprogetto.defineColumn("lt", typeof(DateTime));
	tprogettotimesheetprogetto.defineColumn("lu", typeof(string));
	tprogettotimesheetprogetto.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tprogettotimesheetprogetto);
	tprogettotimesheetprogetto.defineKey("idprogetto", "idprogettotimesheet");

	//////////////////// YEAR /////////////////////////////////
	var tyear= new MetaTable("year");
	tyear.defineColumn("year", typeof(int),false);
	Tables.Add(tyear);
	tyear.defineKey("year");

	//////////////////// TIMESHEETTEMPLATE /////////////////////////////////
	var ttimesheettemplate= new MetaTable("timesheettemplate");
	ttimesheettemplate.defineColumn("idtimesheettemplate", typeof(string),false);
	Tables.Add(ttimesheettemplate);
	ttimesheettemplate.defineKey("idtimesheettemplate");

	//////////////////// PROGETTOTIMESHEET /////////////////////////////////
	var tprogettotimesheet= new MetaTable("progettotimesheet");
	tprogettotimesheet.defineColumn("ct", typeof(DateTime));
	tprogettotimesheet.defineColumn("cu", typeof(string));
	tprogettotimesheet.defineColumn("idprogettotimesheet", typeof(int),false);
	tprogettotimesheet.defineColumn("idreg", typeof(int),false);
	tprogettotimesheet.defineColumn("idtimesheettemplate", typeof(string));
	tprogettotimesheet.defineColumn("intestazioneallsheet", typeof(string));
	tprogettotimesheet.defineColumn("lt", typeof(DateTime));
	tprogettotimesheet.defineColumn("lu", typeof(string));
	tprogettotimesheet.defineColumn("riepilogoanno", typeof(string));
	tprogettotimesheet.defineColumn("showactivitiesrow", typeof(string));
	tprogettotimesheet.defineColumn("title", typeof(string));
	tprogettotimesheet.defineColumn("year", typeof(int));
	Tables.Add(tprogettotimesheet);
	tprogettotimesheet.defineKey("idprogettotimesheet", "idreg");

	//////////////////// STIPENDIOANNUO /////////////////////////////////
	var tstipendioannuo= new MetaTable("stipendioannuo");
	tstipendioannuo.defineColumn("caricoente", typeof(decimal));
	tstipendioannuo.defineColumn("ct", typeof(DateTime));
	tstipendioannuo.defineColumn("cu", typeof(string));
	tstipendioannuo.defineColumn("idcontratto", typeof(int),false);
	tstipendioannuo.defineColumn("idreg", typeof(int),false);
	tstipendioannuo.defineColumn("idstipendioannuo", typeof(int),false);
	tstipendioannuo.defineColumn("irap", typeof(decimal));
	tstipendioannuo.defineColumn("lordo", typeof(decimal));
	tstipendioannuo.defineColumn("lt", typeof(DateTime));
	tstipendioannuo.defineColumn("lu", typeof(string));
	tstipendioannuo.defineColumn("totale", typeof(decimal));
	tstipendioannuo.defineColumn("year", typeof(int),false);
	Tables.Add(tstipendioannuo);
	tstipendioannuo.defineKey("idcontratto", "idreg", "idstipendioannuo", "year");

	//////////////////// CEDOLINO /////////////////////////////////
	var tcedolino= new MetaTable("cedolino");
	tcedolino.defineColumn("!previdenza", typeof(decimal));
	tcedolino.defineColumn("!tesoro", typeof(decimal));
	tcedolino.defineColumn("!totalece", typeof(decimal));
	tcedolino.defineColumn("!tredicesima", typeof(decimal));
	tcedolino.defineColumn("assegno", typeof(decimal));
	tcedolino.defineColumn("classe", typeof(int));
	tcedolino.defineColumn("data", typeof(DateTime));
	tcedolino.defineColumn("idcedolino", typeof(int),false);
	tcedolino.defineColumn("idcontratto", typeof(int),false);
	tcedolino.defineColumn("idmese", typeof(int));
	tcedolino.defineColumn("idreg", typeof(int),false);
	tcedolino.defineColumn("iis", typeof(decimal));
	tcedolino.defineColumn("irap", typeof(decimal));
	tcedolino.defineColumn("lordo", typeof(decimal));
	tcedolino.defineColumn("scatto", typeof(int));
	tcedolino.defineColumn("stipendio", typeof(decimal));
	tcedolino.defineColumn("totale", typeof(decimal));
	tcedolino.defineColumn("year", typeof(int));
	Tables.Add(tcedolino);
	tcedolino.defineKey("idcedolino", "idcontratto", "idreg");

	//////////////////// CONTRATTOKIND_ALIAS1 /////////////////////////////////
	var tcontrattokind_alias1= new MetaTable("contrattokind_alias1");
	tcontrattokind_alias1.defineColumn("active", typeof(string),false);
	tcontrattokind_alias1.defineColumn("idcontrattokind", typeof(int),false);
	tcontrattokind_alias1.defineColumn("title", typeof(string),false);
	tcontrattokind_alias1.ExtendedProperties["TableForReading"]="contrattokind";
	Tables.Add(tcontrattokind_alias1);
	tcontrattokind_alias1.defineKey("idcontrattokind");

	//////////////////// INQUADRAMENTO /////////////////////////////////
	var tinquadramento= new MetaTable("inquadramento");
	tinquadramento.defineColumn("idcontrattokind", typeof(int),false);
	tinquadramento.defineColumn("idinquadramento", typeof(int),false);
	tinquadramento.defineColumn("tempdef", typeof(string));
	tinquadramento.defineColumn("title", typeof(string));
	Tables.Add(tinquadramento);
	tinquadramento.defineKey("idcontrattokind", "idinquadramento");

	//////////////////// CONTRATTO /////////////////////////////////
	var tcontratto= new MetaTable("contratto");
	tcontratto.defineColumn("classe", typeof(int));
	tcontratto.defineColumn("ct", typeof(DateTime),false);
	tcontratto.defineColumn("cu", typeof(string),false);
	tcontratto.defineColumn("datarivalutazione", typeof(DateTime));
	tcontratto.defineColumn("estremibando", typeof(string));
	tcontratto.defineColumn("idcontratto", typeof(int),false);
	tcontratto.defineColumn("idcontrattokind", typeof(int),false);
	tcontratto.defineColumn("idinquadramento", typeof(int));
	tcontratto.defineColumn("idreg", typeof(int),false);
	tcontratto.defineColumn("lt", typeof(DateTime),false);
	tcontratto.defineColumn("lu", typeof(string),false);
	tcontratto.defineColumn("parttime", typeof(decimal));
	tcontratto.defineColumn("percentualesufondiateneo", typeof(decimal));
	tcontratto.defineColumn("scatto", typeof(int));
	tcontratto.defineColumn("start", typeof(DateTime),false);
	tcontratto.defineColumn("stop", typeof(DateTime));
	tcontratto.defineColumn("tempdef", typeof(string),false);
	tcontratto.defineColumn("tempindet", typeof(string),false);
	tcontratto.defineColumn("!idcontrattokind_contrattokind_title", typeof(string));
	tcontratto.defineColumn("!idinquadramento_inquadramento_title", typeof(string));
	tcontratto.defineColumn("!idinquadramento_inquadramento_tempdef", typeof(string));
	tcontratto.defineColumn("!idinquadramento_inquadramento_idcontrattokind_title", typeof(string));
	Tables.Add(tcontratto);
	tcontratto.defineKey("idcontratto", "idreg");

	//////////////////// CONTRATTOKIND /////////////////////////////////
	var tcontrattokind= new MetaTable("contrattokind");
	tcontrattokind.defineColumn("active", typeof(string),false);
	tcontrattokind.defineColumn("idcontrattokind", typeof(int),false);
	tcontrattokind.defineColumn("title", typeof(string),false);
	Tables.Add(tcontrattokind);
	tcontrattokind.defineKey("idcontrattokind");

	//////////////////// RESIDENCE /////////////////////////////////
	var tresidence= new MetaTable("residence");
	tresidence.defineColumn("active", typeof(string));
	tresidence.defineColumn("description", typeof(string),false);
	tresidence.defineColumn("idresidence", typeof(int),false);
	Tables.Add(tresidence);
	tresidence.defineKey("idresidence");

	//////////////////// REGISTRYKIND /////////////////////////////////
	var tregistrykind= new MetaTable("registrykind");
	tregistrykind.defineColumn("description", typeof(string),false);
	tregistrykind.defineColumn("idregistrykind", typeof(int),false);
	Tables.Add(tregistrykind);
	tregistrykind.defineKey("idregistrykind");

	//////////////////// CATEGORY /////////////////////////////////
	var tcategory= new MetaTable("category");
	tcategory.defineColumn("active", typeof(string));
	tcategory.defineColumn("description", typeof(string),false);
	tcategory.defineColumn("idcategory", typeof(string),false);
	Tables.Add(tcategory);
	tcategory.defineKey("idcategory");

	//////////////////// REGISTRYCLASSDEFAULTVIEW /////////////////////////////////
	var tregistryclassdefaultview= new MetaTable("registryclassdefaultview");
	tregistryclassdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tregistryclassdefaultview.defineColumn("idregistryclass", typeof(string),false);
	tregistryclassdefaultview.defineColumn("registryclass_active", typeof(string));
	Tables.Add(tregistryclassdefaultview);
	tregistryclassdefaultview.defineKey("idregistryclass");

	//////////////////// MARITALSTATUS /////////////////////////////////
	var tmaritalstatus= new MetaTable("maritalstatus");
	tmaritalstatus.defineColumn("active", typeof(string));
	tmaritalstatus.defineColumn("description", typeof(string),false);
	tmaritalstatus.defineColumn("idmaritalstatus", typeof(string),false);
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

	//////////////////// REGISTRY_AMMINISTRATIVI /////////////////////////////////
	var tregistry_amministrativi= new MetaTable("registry_amministrativi");
	tregistry_amministrativi.defineColumn("ct", typeof(DateTime));
	tregistry_amministrativi.defineColumn("cu", typeof(string));
	tregistry_amministrativi.defineColumn("cv", typeof(string));
	tregistry_amministrativi.defineColumn("idcontrattokind", typeof(int));
	tregistry_amministrativi.defineColumn("idreg", typeof(int),false);
	tregistry_amministrativi.defineColumn("lt", typeof(DateTime));
	tregistry_amministrativi.defineColumn("lu", typeof(string));
	Tables.Add(tregistry_amministrativi);
	tregistry_amministrativi.defineKey("idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{registry.Columns["idreg"]};
	var cChild = new []{sospensione.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_sospensione_registry_idreg",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{progettotimesheet.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_progettotimesheet_registry_idreg",cPar,cChild,false));

	cPar = new []{progettotimesheet.Columns["idprogettotimesheet"]};
	cChild = new []{progettotimesheetprogetto.Columns["idprogettotimesheet"]};
	Relations.Add(new DataRelation("FK_progettotimesheetprogetto_progettotimesheet_idprogettotimesheet",cPar,cChild,false));

	cPar = new []{year.Columns["year"]};
	cChild = new []{progettotimesheet.Columns["year"]};
	Relations.Add(new DataRelation("FK_progettotimesheet_year_year",cPar,cChild,false));

	cPar = new []{timesheettemplate.Columns["idtimesheettemplate"]};
	cChild = new []{progettotimesheet.Columns["idtimesheettemplate"]};
	Relations.Add(new DataRelation("FK_progettotimesheet_timesheettemplate_idtimesheettemplate",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{contratto.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_contratto_registry_idreg",cPar,cChild,false));

	cPar = new []{contratto.Columns["idcontratto"], contratto.Columns["idreg"]};
	cChild = new []{stipendioannuo.Columns["idcontratto"], stipendioannuo.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_stipendioannuo_contratto_idcontratto-idreg",cPar,cChild,false));

	cPar = new []{contratto.Columns["idcontratto"], contratto.Columns["idreg"]};
	cChild = new []{cedolino.Columns["idcontratto"], cedolino.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_cedolino_contratto_idcontratto-idreg",cPar,cChild,false));

	cPar = new []{inquadramento.Columns["idinquadramento"]};
	cChild = new []{contratto.Columns["idinquadramento"]};
	Relations.Add(new DataRelation("FK_contratto_inquadramento_idinquadramento",cPar,cChild,false));

	cPar = new []{contrattokind_alias1.Columns["idcontrattokind"]};
	cChild = new []{inquadramento.Columns["idcontrattokind"]};
	Relations.Add(new DataRelation("FK_inquadramento_contrattokind_alias1_idcontrattokind",cPar,cChild,false));

	cPar = new []{contrattokind.Columns["idcontrattokind"]};
	cChild = new []{contratto.Columns["idcontrattokind"]};
	Relations.Add(new DataRelation("FK_contratto_contrattokind_idcontrattokind",cPar,cChild,false));

	cPar = new []{contrattokind.Columns["idcontrattokind"]};
	cChild = new []{registry_amministrativi.Columns["idcontrattokind"]};
	Relations.Add(new DataRelation("FK_registry_amministrativi_contrattokind_idcontrattokind",cPar,cChild,false));

	cPar = new []{residence.Columns["idresidence"]};
	cChild = new []{registry.Columns["residence"]};
	Relations.Add(new DataRelation("FK_registry_residence_residence",cPar,cChild,false));

	cPar = new []{registrykind.Columns["idregistrykind"]};
	cChild = new []{registry.Columns["idregistrykind"]};
	Relations.Add(new DataRelation("FK_registry_registrykind_idregistrykind",cPar,cChild,false));

	cPar = new []{category.Columns["idcategory"]};
	cChild = new []{registry.Columns["idcategory"]};
	Relations.Add(new DataRelation("FK_registry_category_idcategory",cPar,cChild,false));

	cPar = new []{registryclassdefaultview.Columns["idregistryclass"]};
	cChild = new []{registry.Columns["idregistryclass"]};
	Relations.Add(new DataRelation("FK_registry_registryclassdefaultview_idregistryclass",cPar,cChild,false));

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

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registry_amministrativi.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registry_amministrativi_registry_idreg",cPar,cChild,false));

	#endregion

}
}
}
