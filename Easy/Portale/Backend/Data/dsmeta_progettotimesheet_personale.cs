
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
[System.Xml.Serialization.XmlRoot("dsmeta_progettotimesheet_personale"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_progettotimesheet_personale: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable inquadramento 		=> (MetaTable)Tables["inquadramento"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable position 		=> (MetaTable)Tables["position"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable workpackage 		=> (MetaTable)Tables["workpackage"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sal 		=> (MetaTable)Tables["sal"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontattivitaprogetto 		=> (MetaTable)Tables["rendicontattivitaprogetto"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progetto_alias2 		=> (MetaTable)Tables["progetto_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontattivitaprogettoora 		=> (MetaTable)Tables["rendicontattivitaprogettoora"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strumentofin 		=> (MetaTable)Tables["strumentofin"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_alias4 		=> (MetaTable)Tables["registry_alias4"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_alias3 		=> (MetaTable)Tables["registry_alias3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable title 		=> (MetaTable)Tables["title"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_alias1 		=> (MetaTable)Tables["registry_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry 		=> (MetaTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettostatuskind 		=> (MetaTable)Tables["progettostatuskind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettokind 		=> (MetaTable)Tables["progettokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable partnerkind 		=> (MetaTable)Tables["partnerkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable corsostudio 		=> (MetaTable)Tables["corsostudio"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progetto 		=> (MetaTable)Tables["progetto"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettotimesheetprogetto 		=> (MetaTable)Tables["progettotimesheetprogetto"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable salelenchiview 		=> (MetaTable)Tables["salelenchiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable mese 		=> (MetaTable)Tables["mese"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettoelenchiview 		=> (MetaTable)Tables["progettoelenchiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontattivitaprogettoannoview 		=> (MetaTable)Tables["rendicontattivitaprogettoannoview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable timesheettemplate 		=> (MetaTable)Tables["timesheettemplate"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable year 		=> (MetaTable)Tables["year"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getregistrydocentiamministrativinomcognmatview 		=> (MetaTable)Tables["getregistrydocentiamministrativinomcognmatview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettotimesheet 		=> (MetaTable)Tables["progettotimesheet"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_progettotimesheet_personale(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_progettotimesheet_personale (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_progettotimesheet_personale";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_progettotimesheet_personale.xsd";

	#region create DataTables
	//////////////////// INQUADRAMENTO /////////////////////////////////
	var tinquadramento= new MetaTable("inquadramento");
	tinquadramento.defineColumn("costolordoannuo", typeof(decimal));
	tinquadramento.defineColumn("costolordoannuooneri", typeof(decimal));
	tinquadramento.defineColumn("ct", typeof(DateTime),false);
	tinquadramento.defineColumn("cu", typeof(string),false);
	tinquadramento.defineColumn("idcontrattokind", typeof(int));
	tinquadramento.defineColumn("idinquadramento", typeof(int),false);
	tinquadramento.defineColumn("idposition", typeof(int),false);
	tinquadramento.defineColumn("lt", typeof(DateTime),false);
	tinquadramento.defineColumn("lu", typeof(string),false);
	tinquadramento.defineColumn("siglaimportazione", typeof(string));
	tinquadramento.defineColumn("start", typeof(DateTime));
	tinquadramento.defineColumn("stop", typeof(DateTime));
	tinquadramento.defineColumn("tempdef", typeof(string));
	tinquadramento.defineColumn("title", typeof(string));
	Tables.Add(tinquadramento);
	tinquadramento.defineKey("idinquadramento", "idposition");

	//////////////////// POSITION /////////////////////////////////
	var tposition= new MetaTable("position");
	tposition.defineColumn("active", typeof(string));
	tposition.defineColumn("assegnoaggiuntivo", typeof(string));
	tposition.defineColumn("codeposition", typeof(string),false);
	tposition.defineColumn("costolordoannuo", typeof(decimal));
	tposition.defineColumn("costolordoannuooneri", typeof(decimal));
	tposition.defineColumn("ct", typeof(DateTime),false);
	tposition.defineColumn("cu", typeof(string),false);
	tposition.defineColumn("description", typeof(string),false);
	tposition.defineColumn("elementoperequativo", typeof(string));
	tposition.defineColumn("foreignclass", typeof(string));
	tposition.defineColumn("idposition", typeof(int),false);
	tposition.defineColumn("indennitadiateneo", typeof(string));
	tposition.defineColumn("indennitadiposizione", typeof(string));
	tposition.defineColumn("indvacancacontrattuale", typeof(string));
	tposition.defineColumn("livello", typeof(string));
	tposition.defineColumn("lt", typeof(DateTime),false);
	tposition.defineColumn("lu", typeof(string),false);
	tposition.defineColumn("maxincomeclass", typeof(int));
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
	tposition.defineColumn("printingorder", typeof(int));
	tposition.defineColumn("puntiorganico", typeof(decimal));
	tposition.defineColumn("siglaesportazione", typeof(string));
	tposition.defineColumn("siglaimportazione", typeof(string));
	tposition.defineColumn("tempdef", typeof(string));
	tposition.defineColumn("tipoente", typeof(string));
	tposition.defineColumn("tipopersonale", typeof(string));
	tposition.defineColumn("title", typeof(string));
	tposition.defineColumn("totaletredicesima", typeof(string));
	tposition.defineColumn("tredicesimaindennitaintegrativaspeciale", typeof(string));
	Tables.Add(tposition);
	tposition.defineKey("idposition");

	//////////////////// WORKPACKAGE /////////////////////////////////
	var tworkpackage= new MetaTable("workpackage");
	tworkpackage.defineColumn("!titolobreve", typeof(string));
	tworkpackage.defineColumn("acronimo", typeof(string));
	tworkpackage.defineColumn("ct", typeof(DateTime),false);
	tworkpackage.defineColumn("cu", typeof(string),false);
	tworkpackage.defineColumn("description", typeof(string));
	tworkpackage.defineColumn("idprogetto", typeof(int),false);
	tworkpackage.defineColumn("idstruttura", typeof(int));
	tworkpackage.defineColumn("idworkpackage", typeof(int),false);
	tworkpackage.defineColumn("lt", typeof(DateTime),false);
	tworkpackage.defineColumn("lu", typeof(string),false);
	tworkpackage.defineColumn("raggruppamento", typeof(string));
	tworkpackage.defineColumn("start", typeof(DateTime));
	tworkpackage.defineColumn("stop", typeof(DateTime));
	tworkpackage.defineColumn("title", typeof(string),false);
	Tables.Add(tworkpackage);
	tworkpackage.defineKey("idprogetto", "idworkpackage");

	//////////////////// SAL /////////////////////////////////
	var tsal= new MetaTable("sal");
	tsal.defineColumn("!budgetcalcolato", typeof(decimal));
	tsal.defineColumn("budget", typeof(decimal));
	tsal.defineColumn("datablocco", typeof(DateTime));
	tsal.defineColumn("idprogetto", typeof(int),false);
	tsal.defineColumn("idsal", typeof(int),false);
	tsal.defineColumn("start", typeof(DateTime));
	tsal.defineColumn("stop", typeof(DateTime));
	Tables.Add(tsal);
	tsal.defineKey("idprogetto", "idsal");

	//////////////////// RENDICONTATTIVITAPROGETTO /////////////////////////////////
	var trendicontattivitaprogetto= new MetaTable("rendicontattivitaprogetto");
	trendicontattivitaprogetto.defineColumn("!orerendicont", typeof(string));
	trendicontattivitaprogetto.defineColumn("ct", typeof(DateTime),false);
	trendicontattivitaprogetto.defineColumn("cu", typeof(string),false);
	trendicontattivitaprogetto.defineColumn("datainizioprevista", typeof(DateTime),false);
	trendicontattivitaprogetto.defineColumn("description", typeof(string));
	trendicontattivitaprogetto.defineColumn("iditineration", typeof(int));
	trendicontattivitaprogetto.defineColumn("idprogetto", typeof(int),false);
	trendicontattivitaprogetto.defineColumn("idreg", typeof(int),false);
	trendicontattivitaprogetto.defineColumn("idrendicontattivitaprogetto", typeof(int),false);
	trendicontattivitaprogetto.defineColumn("idrendicontattivitaprogettokind", typeof(int));
	trendicontattivitaprogetto.defineColumn("idworkpackage", typeof(int),false);
	trendicontattivitaprogetto.defineColumn("lt", typeof(DateTime),false);
	trendicontattivitaprogetto.defineColumn("lu", typeof(string),false);
	trendicontattivitaprogetto.defineColumn("orepreventivate", typeof(int),false);
	trendicontattivitaprogetto.defineColumn("stop", typeof(DateTime));
	Tables.Add(trendicontattivitaprogetto);
	trendicontattivitaprogetto.defineKey("idprogetto", "idreg", "idrendicontattivitaprogetto", "idworkpackage");

	//////////////////// PROGETTO_ALIAS2 /////////////////////////////////
	var tprogetto_alias2= new MetaTable("progetto_alias2");
	tprogetto_alias2.defineColumn("!altreupb", typeof(string));
	tprogetto_alias2.defineColumn("!filtraAsset", typeof(string));
	tprogetto_alias2.defineColumn("bandoriferimentotxt", typeof(string));
	tprogetto_alias2.defineColumn("budget", typeof(decimal));
	tprogetto_alias2.defineColumn("budgetcalcolato", typeof(decimal));
	tprogetto_alias2.defineColumn("budgetcalcolatodate", typeof(DateTime));
	tprogetto_alias2.defineColumn("capofilatxt", typeof(string));
	tprogetto_alias2.defineColumn("codiceidentificativo", typeof(string));
	tprogetto_alias2.defineColumn("contributo", typeof(decimal));
	tprogetto_alias2.defineColumn("contributoente", typeof(decimal));
	tprogetto_alias2.defineColumn("contributoenterichiesto", typeof(decimal));
	tprogetto_alias2.defineColumn("contributorichiesto", typeof(decimal));
	tprogetto_alias2.defineColumn("costoapprovatoateneo", typeof(decimal));
	tprogetto_alias2.defineColumn("costoapprovatoateneocalcolato", typeof(decimal));
	tprogetto_alias2.defineColumn("ct", typeof(DateTime),false);
	tprogetto_alias2.defineColumn("cu", typeof(string),false);
	tprogetto_alias2.defineColumn("cup", typeof(string));
	tprogetto_alias2.defineColumn("data", typeof(DateTime));
	tprogetto_alias2.defineColumn("datacontabile", typeof(DateTime));
	tprogetto_alias2.defineColumn("dataesito", typeof(DateTime));
	tprogetto_alias2.defineColumn("description", typeof(string));
	tprogetto_alias2.defineColumn("durata", typeof(int));
	tprogetto_alias2.defineColumn("finanziamento", typeof(string));
	tprogetto_alias2.defineColumn("finanziatoretxt", typeof(string));
	tprogetto_alias2.defineColumn("idcorsostudio", typeof(int));
	tprogetto_alias2.defineColumn("idcurrency", typeof(int));
	tprogetto_alias2.defineColumn("idduratakind", typeof(int));
	tprogetto_alias2.defineColumn("idpartnerkind", typeof(int));
	tprogetto_alias2.defineColumn("idprogetto", typeof(int),false);
	tprogetto_alias2.defineColumn("idprogettokind", typeof(int));
	tprogetto_alias2.defineColumn("idprogettostatuskind", typeof(int));
	tprogetto_alias2.defineColumn("idreg", typeof(int));
	tprogetto_alias2.defineColumn("idreg_amm", typeof(int));
	tprogetto_alias2.defineColumn("idreg_aziende", typeof(int));
	tprogetto_alias2.defineColumn("idreg_aziende_fin", typeof(int));
	tprogetto_alias2.defineColumn("idregistryprogfin", typeof(int));
	tprogetto_alias2.defineColumn("idregistryprogfinbando", typeof(int));
	tprogetto_alias2.defineColumn("idstrumentofin", typeof(int));
	tprogetto_alias2.defineColumn("lt", typeof(DateTime),false);
	tprogetto_alias2.defineColumn("lu", typeof(string),false);
	tprogetto_alias2.defineColumn("progfinanziamentotxt", typeof(string));
	tprogetto_alias2.defineColumn("respamministrativi", typeof(string));
	tprogetto_alias2.defineColumn("responsabiliamministrativi", typeof(string));
	tprogetto_alias2.defineColumn("responsabiliscientifici", typeof(string));
	tprogetto_alias2.defineColumn("respscientifici", typeof(string));
	tprogetto_alias2.defineColumn("start", typeof(DateTime));
	tprogetto_alias2.defineColumn("stop", typeof(DateTime));
	tprogetto_alias2.defineColumn("title", typeof(string));
	tprogetto_alias2.defineColumn("title_en", typeof(string));
	tprogetto_alias2.defineColumn("titolobreve", typeof(string));
	tprogetto_alias2.defineColumn("totalbudget", typeof(decimal));
	tprogetto_alias2.defineColumn("totalcontributo", typeof(decimal));
	tprogetto_alias2.defineColumn("ulteriorecup", typeof(string));
	tprogetto_alias2.defineColumn("unitaorganizzativa", typeof(string));
	tprogetto_alias2.defineColumn("url", typeof(string));
	tprogetto_alias2.ExtendedProperties["TableForReading"]="progetto";
	Tables.Add(tprogetto_alias2);
	tprogetto_alias2.defineKey("idprogetto");

	//////////////////// RENDICONTATTIVITAPROGETTOORA /////////////////////////////////
	var trendicontattivitaprogettoora= new MetaTable("rendicontattivitaprogettoora");
	trendicontattivitaprogettoora.defineColumn("!titleancestor", typeof(string));
	trendicontattivitaprogettoora.defineColumn("ct", typeof(DateTime),false);
	trendicontattivitaprogettoora.defineColumn("cu", typeof(string),false);
	trendicontattivitaprogettoora.defineColumn("data", typeof(DateTime));
	trendicontattivitaprogettoora.defineColumn("idconsolidamento", typeof(int));
	trendicontattivitaprogettoora.defineColumn("idprogetto", typeof(int),false);
	trendicontattivitaprogettoora.defineColumn("idreg", typeof(int),false);
	trendicontattivitaprogettoora.defineColumn("idrendicontattivitaprogetto", typeof(int),false);
	trendicontattivitaprogettoora.defineColumn("idrendicontattivitaprogettoora", typeof(int),false);
	trendicontattivitaprogettoora.defineColumn("idsal", typeof(int));
	trendicontattivitaprogettoora.defineColumn("idworkpackage", typeof(int),false);
	trendicontattivitaprogettoora.defineColumn("lt", typeof(DateTime),false);
	trendicontattivitaprogettoora.defineColumn("lu", typeof(string),false);
	trendicontattivitaprogettoora.defineColumn("ore", typeof(int));
	trendicontattivitaprogettoora.defineColumn("!idprogetto_progetto_titolobreve", typeof(string));
	trendicontattivitaprogettoora.defineColumn("!idprogetto_progetto_start", typeof(DateTime));
	trendicontattivitaprogettoora.defineColumn("!idprogetto_progetto_stop", typeof(DateTime));
	trendicontattivitaprogettoora.defineColumn("!idrendicontattivitaprogetto_rendicontattivitaprogetto_description", typeof(string));
	trendicontattivitaprogettoora.defineColumn("!idsal_sal_start", typeof(DateTime));
	trendicontattivitaprogettoora.defineColumn("!idsal_sal_stop", typeof(DateTime));
	trendicontattivitaprogettoora.defineColumn("!idsal_sal_datablocco", typeof(DateTime));
	trendicontattivitaprogettoora.defineColumn("!idworkpackage_workpackage_raggruppamento", typeof(string));
	trendicontattivitaprogettoora.defineColumn("!idworkpackage_workpackage_title", typeof(string));
	Tables.Add(trendicontattivitaprogettoora);
	trendicontattivitaprogettoora.defineKey("idprogetto", "idreg", "idrendicontattivitaprogetto", "idrendicontattivitaprogettoora", "idworkpackage");

	//////////////////// STRUMENTOFIN /////////////////////////////////
	var tstrumentofin= new MetaTable("strumentofin");
	tstrumentofin.defineColumn("active", typeof(string));
	tstrumentofin.defineColumn("idstrumentofin", typeof(int),false);
	tstrumentofin.defineColumn("title", typeof(string));
	Tables.Add(tstrumentofin);
	tstrumentofin.defineKey("idstrumentofin");

	//////////////////// REGISTRY_ALIAS4 /////////////////////////////////
	var tregistry_alias4= new MetaTable("registry_alias4");
	tregistry_alias4.defineColumn("active", typeof(string),false);
	tregistry_alias4.defineColumn("idreg", typeof(int),false);
	tregistry_alias4.defineColumn("title", typeof(string),false);
	tregistry_alias4.ExtendedProperties["TableForReading"]="registry";
	Tables.Add(tregistry_alias4);
	tregistry_alias4.defineKey("idreg");

	//////////////////// REGISTRY_ALIAS3 /////////////////////////////////
	var tregistry_alias3= new MetaTable("registry_alias3");
	tregistry_alias3.defineColumn("active", typeof(string),false);
	tregistry_alias3.defineColumn("idreg", typeof(int),false);
	tregistry_alias3.defineColumn("title", typeof(string),false);
	tregistry_alias3.ExtendedProperties["TableForReading"]="registry";
	Tables.Add(tregistry_alias3);
	tregistry_alias3.defineKey("idreg");

	//////////////////// TITLE /////////////////////////////////
	var ttitle= new MetaTable("title");
	ttitle.defineColumn("active", typeof(string));
	ttitle.defineColumn("description", typeof(string),false);
	ttitle.defineColumn("idtitle", typeof(string),false);
	Tables.Add(ttitle);
	ttitle.defineKey("idtitle");

	//////////////////// REGISTRY_ALIAS1 /////////////////////////////////
	var tregistry_alias1= new MetaTable("registry_alias1");
	tregistry_alias1.defineColumn("active", typeof(string),false);
	tregistry_alias1.defineColumn("cf", typeof(string));
	tregistry_alias1.defineColumn("forename", typeof(string));
	tregistry_alias1.defineColumn("idreg", typeof(int),false);
	tregistry_alias1.defineColumn("idtitle", typeof(string));
	tregistry_alias1.defineColumn("surname", typeof(string));
	tregistry_alias1.ExtendedProperties["TableForReading"]="registry";
	Tables.Add(tregistry_alias1);
	tregistry_alias1.defineKey("idreg");

	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new MetaTable("registry");
	tregistry.defineColumn("active", typeof(string),false);
	tregistry.defineColumn("idreg", typeof(int),false);
	tregistry.defineColumn("title", typeof(string),false);
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// PROGETTOSTATUSKIND /////////////////////////////////
	var tprogettostatuskind= new MetaTable("progettostatuskind");
	tprogettostatuskind.defineColumn("idprogettostatuskind", typeof(int),false);
	tprogettostatuskind.defineColumn("title", typeof(string),false);
	Tables.Add(tprogettostatuskind);
	tprogettostatuskind.defineKey("idprogettostatuskind");

	//////////////////// PROGETTOKIND /////////////////////////////////
	var tprogettokind= new MetaTable("progettokind");
	tprogettokind.defineColumn("active", typeof(string));
	tprogettokind.defineColumn("idprogettokind", typeof(int),false);
	tprogettokind.defineColumn("title", typeof(string));
	Tables.Add(tprogettokind);
	tprogettokind.defineKey("idprogettokind");

	//////////////////// PARTNERKIND /////////////////////////////////
	var tpartnerkind= new MetaTable("partnerkind");
	tpartnerkind.defineColumn("active", typeof(string));
	tpartnerkind.defineColumn("idpartnerkind", typeof(int),false);
	tpartnerkind.defineColumn("title", typeof(string));
	Tables.Add(tpartnerkind);
	tpartnerkind.defineKey("idpartnerkind");

	//////////////////// CORSOSTUDIO /////////////////////////////////
	var tcorsostudio= new MetaTable("corsostudio");
	tcorsostudio.defineColumn("annoistituz", typeof(int));
	tcorsostudio.defineColumn("idcorsostudio", typeof(int),false);
	tcorsostudio.defineColumn("title", typeof(string));
	Tables.Add(tcorsostudio);
	tcorsostudio.defineKey("idcorsostudio");

	//////////////////// PROGETTO /////////////////////////////////
	var tprogetto= new MetaTable("progetto");
	tprogetto.defineColumn("!altreupb", typeof(string));
	tprogetto.defineColumn("!filtraAsset", typeof(string));
	tprogetto.defineColumn("bandoriferimentotxt", typeof(string));
	tprogetto.defineColumn("budget", typeof(decimal));
	tprogetto.defineColumn("budgetcalcolato", typeof(decimal));
	tprogetto.defineColumn("budgetcalcolatodate", typeof(DateTime));
	tprogetto.defineColumn("capofilatxt", typeof(string));
	tprogetto.defineColumn("codiceidentificativo", typeof(string));
	tprogetto.defineColumn("contributo", typeof(decimal));
	tprogetto.defineColumn("contributoente", typeof(decimal));
	tprogetto.defineColumn("contributoenterichiesto", typeof(decimal));
	tprogetto.defineColumn("contributorichiesto", typeof(decimal));
	tprogetto.defineColumn("costoapprovatoateneo", typeof(decimal));
	tprogetto.defineColumn("costoapprovatoateneocalcolato", typeof(decimal));
	tprogetto.defineColumn("ct", typeof(DateTime),false);
	tprogetto.defineColumn("cu", typeof(string),false);
	tprogetto.defineColumn("cup", typeof(string));
	tprogetto.defineColumn("data", typeof(DateTime));
	tprogetto.defineColumn("datacontabile", typeof(DateTime));
	tprogetto.defineColumn("dataesito", typeof(DateTime));
	tprogetto.defineColumn("description", typeof(string));
	tprogetto.defineColumn("durata", typeof(int));
	tprogetto.defineColumn("finanziamento", typeof(string));
	tprogetto.defineColumn("finanziatoretxt", typeof(string));
	tprogetto.defineColumn("idcorsostudio", typeof(int));
	tprogetto.defineColumn("idcurrency", typeof(int));
	tprogetto.defineColumn("idduratakind", typeof(int));
	tprogetto.defineColumn("idpartnerkind", typeof(int));
	tprogetto.defineColumn("idprogetto", typeof(int),false);
	tprogetto.defineColumn("idprogettokind", typeof(int));
	tprogetto.defineColumn("idprogettostatuskind", typeof(int));
	tprogetto.defineColumn("idreg", typeof(int));
	tprogetto.defineColumn("idreg_amm", typeof(int));
	tprogetto.defineColumn("idreg_aziende", typeof(int));
	tprogetto.defineColumn("idreg_aziende_fin", typeof(int));
	tprogetto.defineColumn("idregistryprogfin", typeof(int));
	tprogetto.defineColumn("idregistryprogfinbando", typeof(int));
	tprogetto.defineColumn("idstrumentofin", typeof(int));
	tprogetto.defineColumn("lt", typeof(DateTime),false);
	tprogetto.defineColumn("lu", typeof(string),false);
	tprogetto.defineColumn("progfinanziamentotxt", typeof(string));
	tprogetto.defineColumn("respamministrativi", typeof(string));
	tprogetto.defineColumn("responsabiliamministrativi", typeof(string));
	tprogetto.defineColumn("responsabiliscientifici", typeof(string));
	tprogetto.defineColumn("respscientifici", typeof(string));
	tprogetto.defineColumn("start", typeof(DateTime));
	tprogetto.defineColumn("stop", typeof(DateTime));
	tprogetto.defineColumn("title", typeof(string));
	tprogetto.defineColumn("title_en", typeof(string));
	tprogetto.defineColumn("titolobreve", typeof(string));
	tprogetto.defineColumn("totalbudget", typeof(decimal));
	tprogetto.defineColumn("totalcontributo", typeof(decimal));
	tprogetto.defineColumn("ulteriorecup", typeof(string));
	tprogetto.defineColumn("unitaorganizzativa", typeof(string));
	tprogetto.defineColumn("url", typeof(string));
	tprogetto.defineColumn("!idcorsostudio_corsostudio_title", typeof(string));
	tprogetto.defineColumn("!idcorsostudio_corsostudio_annoistituz", typeof(int));
	tprogetto.defineColumn("!idpartnerkind_partnerkind_title", typeof(string));
	tprogetto.defineColumn("!idprogettokind_progettokind_title", typeof(string));
	tprogetto.defineColumn("!idprogettostatuskind_progettostatuskind_title", typeof(string));
	tprogetto.defineColumn("!idreg_registry_title", typeof(string));
	tprogetto.defineColumn("!idreg_amm_registry_surname", typeof(string));
	tprogetto.defineColumn("!idreg_amm_registry_forename", typeof(string));
	tprogetto.defineColumn("!idreg_amm_registry_cf", typeof(string));
	tprogetto.defineColumn("!idreg_amm_registry_idtitle_description", typeof(string));
	tprogetto.defineColumn("!idreg_aziende_registry_title", typeof(string));
	tprogetto.defineColumn("!idreg_aziende_fin_registry_title", typeof(string));
	tprogetto.defineColumn("!idstrumentofin_strumentofin_title", typeof(string));
	Tables.Add(tprogetto);
	tprogetto.defineKey("idprogetto");

	//////////////////// PROGETTOTIMESHEETPROGETTO /////////////////////////////////
	var tprogettotimesheetprogetto= new MetaTable("progettotimesheetprogetto");
	tprogettotimesheetprogetto.defineColumn("ct", typeof(DateTime));
	tprogettotimesheetprogetto.defineColumn("cu", typeof(string));
	tprogettotimesheetprogetto.defineColumn("idprogetto", typeof(int),false);
	tprogettotimesheetprogetto.defineColumn("idprogettotimesheet", typeof(int),false);
	tprogettotimesheetprogetto.defineColumn("lt", typeof(DateTime));
	tprogettotimesheetprogetto.defineColumn("lu", typeof(string));
	Tables.Add(tprogettotimesheetprogetto);
	tprogettotimesheetprogetto.defineKey("idprogetto", "idprogettotimesheet");

	//////////////////// SALELENCHIVIEW /////////////////////////////////
	var tsalelenchiview= new MetaTable("salelenchiview");
	tsalelenchiview.defineColumn("dropdown_title", typeof(string),false);
	tsalelenchiview.defineColumn("idprogetto", typeof(int),false);
	tsalelenchiview.defineColumn("idsal", typeof(int),false);
	tsalelenchiview.defineColumn("sal_budget", typeof(decimal));
	tsalelenchiview.defineColumn("sal_datablocco", typeof(DateTime));
	tsalelenchiview.defineColumn("sal_stop", typeof(DateTime));
	tsalelenchiview.defineColumn("start", typeof(DateTime));
	Tables.Add(tsalelenchiview);
	tsalelenchiview.defineKey("idprogetto", "idsal");

	//////////////////// MESE /////////////////////////////////
	var tmese= new MetaTable("mese");
	tmese.defineColumn("idmese", typeof(int),false);
	tmese.defineColumn("title", typeof(string));
	Tables.Add(tmese);
	tmese.defineKey("idmese");

	//////////////////// PROGETTOELENCHIVIEW /////////////////////////////////
	var tprogettoelenchiview= new MetaTable("progettoelenchiview");
	tprogettoelenchiview.defineColumn("corsostudio_annoistituz", typeof(int));
	tprogettoelenchiview.defineColumn("corsostudio_title", typeof(string));
	tprogettoelenchiview.defineColumn("currency_codecurrency", typeof(string));
	tprogettoelenchiview.defineColumn("dropdown_title", typeof(string),false);
	tprogettoelenchiview.defineColumn("duratakind_title", typeof(string));
	tprogettoelenchiview.defineColumn("idcorsostudio", typeof(int));
	tprogettoelenchiview.defineColumn("idcurrency", typeof(int));
	tprogettoelenchiview.defineColumn("idprogetto", typeof(int),false);
	tprogettoelenchiview.defineColumn("idreg", typeof(int));
	tprogettoelenchiview.defineColumn("idreg_amm", typeof(int));
	tprogettoelenchiview.defineColumn("idreg_aziende", typeof(int));
	tprogettoelenchiview.defineColumn("idreg_aziende_fin", typeof(int));
	tprogettoelenchiview.defineColumn("idstrumentofin", typeof(int));
	tprogettoelenchiview.defineColumn("partnerkind_title", typeof(string));
	tprogettoelenchiview.defineColumn("progetto_bandoriferimentotxt", typeof(string));
	tprogettoelenchiview.defineColumn("progetto_budget", typeof(decimal));
	tprogettoelenchiview.defineColumn("progetto_budgetcalcolato", typeof(decimal));
	tprogettoelenchiview.defineColumn("progetto_budgetcalcolatodate", typeof(DateTime));
	tprogettoelenchiview.defineColumn("progetto_capofilatxt", typeof(string));
	tprogettoelenchiview.defineColumn("progetto_codiceidentificativo", typeof(string));
	tprogettoelenchiview.defineColumn("progetto_contributo", typeof(decimal));
	tprogettoelenchiview.defineColumn("progetto_contributoente", typeof(decimal));
	tprogettoelenchiview.defineColumn("progetto_contributoenterichiesto", typeof(decimal));
	tprogettoelenchiview.defineColumn("progetto_contributorichiesto", typeof(decimal));
	tprogettoelenchiview.defineColumn("progetto_costoapprovatoateneo", typeof(decimal));
	tprogettoelenchiview.defineColumn("progetto_costoapprovatoateneocalcolato", typeof(decimal));
	tprogettoelenchiview.defineColumn("progetto_ct", typeof(DateTime),false);
	tprogettoelenchiview.defineColumn("progetto_cu", typeof(string),false);
	tprogettoelenchiview.defineColumn("progetto_cup", typeof(string));
	tprogettoelenchiview.defineColumn("progetto_data", typeof(DateTime));
	tprogettoelenchiview.defineColumn("progetto_datacontabile", typeof(DateTime));
	tprogettoelenchiview.defineColumn("progetto_dataesito", typeof(DateTime));
	tprogettoelenchiview.defineColumn("progetto_description", typeof(string));
	tprogettoelenchiview.defineColumn("progetto_durata", typeof(int));
	tprogettoelenchiview.defineColumn("progetto_finanziamento", typeof(string));
	tprogettoelenchiview.defineColumn("progetto_finanziatoretxt", typeof(string));
	tprogettoelenchiview.defineColumn("progetto_idduratakind", typeof(int));
	tprogettoelenchiview.defineColumn("progetto_idpartnerkind", typeof(int));
	tprogettoelenchiview.defineColumn("progetto_idprogettokind", typeof(int));
	tprogettoelenchiview.defineColumn("progetto_idprogettostatuskind", typeof(int));
	tprogettoelenchiview.defineColumn("progetto_idregistryprogfin", typeof(int));
	tprogettoelenchiview.defineColumn("progetto_idregistryprogfinbando", typeof(int));
	tprogettoelenchiview.defineColumn("progetto_lt", typeof(DateTime),false);
	tprogettoelenchiview.defineColumn("progetto_lu", typeof(string),false);
	tprogettoelenchiview.defineColumn("progetto_progfinanziamentotxt", typeof(string));
	tprogettoelenchiview.defineColumn("progetto_respamministrativi", typeof(string));
	tprogettoelenchiview.defineColumn("progetto_responsabiliamministrativi", typeof(string));
	tprogettoelenchiview.defineColumn("progetto_responsabiliscientifici", typeof(string));
	tprogettoelenchiview.defineColumn("progetto_respscientifici", typeof(string));
	tprogettoelenchiview.defineColumn("progetto_start", typeof(DateTime));
	tprogettoelenchiview.defineColumn("progetto_stop", typeof(DateTime));
	tprogettoelenchiview.defineColumn("progetto_title", typeof(string));
	tprogettoelenchiview.defineColumn("progetto_title_en", typeof(string));
	tprogettoelenchiview.defineColumn("progetto_totalbudget", typeof(decimal));
	tprogettoelenchiview.defineColumn("progetto_totalcontributo", typeof(decimal));
	tprogettoelenchiview.defineColumn("progetto_ulteriorecup", typeof(string));
	tprogettoelenchiview.defineColumn("progetto_unitaorganizzativa", typeof(string));
	tprogettoelenchiview.defineColumn("progetto_url", typeof(string));
	tprogettoelenchiview.defineColumn("progettokind_title", typeof(string));
	tprogettoelenchiview.defineColumn("progettostatuskind_title", typeof(string));
	tprogettoelenchiview.defineColumn("registry_title", typeof(string));
	tprogettoelenchiview.defineColumn("registryamm_cf", typeof(string));
	tprogettoelenchiview.defineColumn("registryamm_forename", typeof(string));
	tprogettoelenchiview.defineColumn("registryamm_idtitle", typeof(string));
	tprogettoelenchiview.defineColumn("registryamm_surname", typeof(string));
	tprogettoelenchiview.defineColumn("registryaziende_fin_title", typeof(string));
	tprogettoelenchiview.defineColumn("registryaziende_title", typeof(string));
	tprogettoelenchiview.defineColumn("registryprogfin_code", typeof(string));
	tprogettoelenchiview.defineColumn("registryprogfin_title", typeof(string));
	tprogettoelenchiview.defineColumn("registryprogfinbando_number", typeof(string));
	tprogettoelenchiview.defineColumn("registryprogfinbando_scadenza", typeof(DateTime));
	tprogettoelenchiview.defineColumn("registryprogfinbando_title", typeof(string));
	tprogettoelenchiview.defineColumn("strumentofin_title", typeof(string));
	tprogettoelenchiview.defineColumn("title_description", typeof(string));
	tprogettoelenchiview.defineColumn("titolobreve", typeof(string));
	Tables.Add(tprogettoelenchiview);
	tprogettoelenchiview.defineKey("idprogetto");

	//////////////////// RENDICONTATTIVITAPROGETTOANNOVIEW /////////////////////////////////
	var trendicontattivitaprogettoannoview= new MetaTable("rendicontattivitaprogettoannoview");
	trendicontattivitaprogettoannoview.defineColumn("idreg", typeof(int),false);
	trendicontattivitaprogettoannoview.defineColumn("oreanno", typeof(int));
	trendicontattivitaprogettoannoview.defineColumn("oreannoimpegnate", typeof(int));
	trendicontattivitaprogettoannoview.defineColumn("oreannorendicontate", typeof(int));
	trendicontattivitaprogettoannoview.defineColumn("oremaxanno", typeof(int),false);
	trendicontattivitaprogettoannoview.defineColumn("stipendioannuo", typeof(decimal));
	trendicontattivitaprogettoannoview.defineColumn("stipendiorendicontato", typeof(decimal));
	trendicontattivitaprogettoannoview.defineColumn("year", typeof(int),false);
	Tables.Add(trendicontattivitaprogettoannoview);
	trendicontattivitaprogettoannoview.defineKey("idreg", "oremaxanno", "year");

	//////////////////// TIMESHEETTEMPLATE /////////////////////////////////
	var ttimesheettemplate= new MetaTable("timesheettemplate");
	ttimesheettemplate.defineColumn("idtimesheettemplate", typeof(string),false);
	Tables.Add(ttimesheettemplate);
	ttimesheettemplate.defineKey("idtimesheettemplate");

	//////////////////// YEAR /////////////////////////////////
	var tyear= new MetaTable("year");
	tyear.defineColumn("year", typeof(int),false);
	Tables.Add(tyear);
	tyear.defineKey("year");

	//////////////////// GETREGISTRYDOCENTIAMMINISTRATIVINOMCOGNMATVIEW /////////////////////////////////
	var tgetregistrydocentiamministrativinomcognmatview= new MetaTable("getregistrydocentiamministrativinomcognmatview");
	tgetregistrydocentiamministrativinomcognmatview.defineColumn("dropdown_title", typeof(string),false);
	tgetregistrydocentiamministrativinomcognmatview.defineColumn("getregistrydocentiamministrativi_areadidattica", typeof(string));
	tgetregistrydocentiamministrativinomcognmatview.defineColumn("getregistrydocentiamministrativi_categoria", typeof(string),false);
	tgetregistrydocentiamministrativinomcognmatview.defineColumn("getregistrydocentiamministrativi_cf", typeof(string));
	tgetregistrydocentiamministrativinomcognmatview.defineColumn("getregistrydocentiamministrativi_contratto", typeof(string));
	tgetregistrydocentiamministrativinomcognmatview.defineColumn("getregistrydocentiamministrativi_extmatricula", typeof(string));
	tgetregistrydocentiamministrativinomcognmatview.defineColumn("getregistrydocentiamministrativi_forename", typeof(string));
	tgetregistrydocentiamministrativinomcognmatview.defineColumn("getregistrydocentiamministrativi_istituto", typeof(string));
	tgetregistrydocentiamministrativinomcognmatview.defineColumn("getregistrydocentiamministrativi_macroareadidattica", typeof(string));
	tgetregistrydocentiamministrativinomcognmatview.defineColumn("getregistrydocentiamministrativi_ssd", typeof(string));
	tgetregistrydocentiamministrativinomcognmatview.defineColumn("getregistrydocentiamministrativi_struttura", typeof(string));
	tgetregistrydocentiamministrativinomcognmatview.defineColumn("idreg", typeof(int),false);
	tgetregistrydocentiamministrativinomcognmatview.defineColumn("surname", typeof(string));
	Tables.Add(tgetregistrydocentiamministrativinomcognmatview);
	tgetregistrydocentiamministrativinomcognmatview.defineKey("idreg");

	//////////////////// PROGETTOTIMESHEET /////////////////////////////////
	var tprogettotimesheet= new MetaTable("progettotimesheet");
	tprogettotimesheet.defineColumn("collapseteachingother", typeof(string));
	tprogettotimesheet.defineColumn("ct", typeof(DateTime));
	tprogettotimesheet.defineColumn("cu", typeof(string));
	tprogettotimesheet.defineColumn("idmese", typeof(int));
	tprogettotimesheet.defineColumn("idprogetto", typeof(int));
	tprogettotimesheet.defineColumn("idprogettotimesheet", typeof(int),false);
	tprogettotimesheet.defineColumn("idreg", typeof(int),false);
	tprogettotimesheet.defineColumn("idsal", typeof(int));
	tprogettotimesheet.defineColumn("idtimesheettemplate", typeof(string));
	tprogettotimesheet.defineColumn("intestazioneallsheet", typeof(string));
	tprogettotimesheet.defineColumn("lt", typeof(DateTime));
	tprogettotimesheet.defineColumn("lu", typeof(string));
	tprogettotimesheet.defineColumn("multilinetype", typeof(string));
	tprogettotimesheet.defineColumn("output", typeof(string));
	tprogettotimesheet.defineColumn("riepilogoanno", typeof(string));
	tprogettotimesheet.defineColumn("showactivitiesrow", typeof(string));
	tprogettotimesheet.defineColumn("showotheractivitiesrow", typeof(string));
	tprogettotimesheet.defineColumn("title", typeof(string));
	tprogettotimesheet.defineColumn("withworkpackage", typeof(string));
	tprogettotimesheet.defineColumn("year", typeof(int));
	Tables.Add(tprogettotimesheet);
	tprogettotimesheet.defineKey("idprogettotimesheet", "idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{progettotimesheet.Columns["idreg"]};
	var cChild = new []{rendicontattivitaprogettoora.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogettoora_progettotimesheet_idreg",cPar,cChild,false));

	cPar = new []{workpackage.Columns["idworkpackage"]};
	cChild = new []{rendicontattivitaprogettoora.Columns["idworkpackage"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogettoora_workpackage_idworkpackage",cPar,cChild,false));

	cPar = new []{sal.Columns["idsal"]};
	cChild = new []{rendicontattivitaprogettoora.Columns["idsal"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogettoora_sal_idsal",cPar,cChild,false));

	cPar = new []{rendicontattivitaprogetto.Columns["idrendicontattivitaprogetto"]};
	cChild = new []{rendicontattivitaprogettoora.Columns["idrendicontattivitaprogetto"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogettoora_rendicontattivitaprogetto_idrendicontattivitaprogetto",cPar,cChild,false));

	cPar = new []{progetto_alias2.Columns["idprogetto"]};
	cChild = new []{rendicontattivitaprogettoora.Columns["idprogetto"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogettoora_progetto_alias2_idprogetto",cPar,cChild,false));

	cPar = new []{progettotimesheet.Columns["idprogettotimesheet"]};
	cChild = new []{progettotimesheetprogetto.Columns["idprogettotimesheet"]};
	Relations.Add(new DataRelation("FK_progettotimesheetprogetto_progettotimesheet_idprogettotimesheet",cPar,cChild,false));

	cPar = new []{progetto.Columns["idprogetto"]};
	cChild = new []{progettotimesheetprogetto.Columns["idprogetto"]};
	Relations.Add(new DataRelation("FK_progettotimesheetprogetto_progetto_idprogetto",cPar,cChild,false));

	cPar = new []{strumentofin.Columns["idstrumentofin"]};
	cChild = new []{progetto.Columns["idstrumentofin"]};
	Relations.Add(new DataRelation("FK_progetto_strumentofin_idstrumentofin",cPar,cChild,false));

	cPar = new []{registry_alias4.Columns["idreg"]};
	cChild = new []{progetto.Columns["idreg_aziende_fin"]};
	Relations.Add(new DataRelation("FK_progetto_registry_alias4_idreg_aziende_fin",cPar,cChild,false));

	cPar = new []{registry_alias3.Columns["idreg"]};
	cChild = new []{progetto.Columns["idreg_aziende"]};
	Relations.Add(new DataRelation("FK_progetto_registry_alias3_idreg_aziende",cPar,cChild,false));

	cPar = new []{registry_alias1.Columns["idreg"]};
	cChild = new []{progetto.Columns["idreg_amm"]};
	Relations.Add(new DataRelation("FK_progetto_registry_alias1_idreg_amm",cPar,cChild,false));

	cPar = new []{title.Columns["idtitle"]};
	cChild = new []{registry_alias1.Columns["idtitle"]};
	Relations.Add(new DataRelation("FK_registry_alias1_title_idtitle",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{progetto.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_progetto_registry_idreg",cPar,cChild,false));

	cPar = new []{progettostatuskind.Columns["idprogettostatuskind"]};
	cChild = new []{progetto.Columns["idprogettostatuskind"]};
	Relations.Add(new DataRelation("FK_progetto_progettostatuskind_idprogettostatuskind",cPar,cChild,false));

	cPar = new []{progettokind.Columns["idprogettokind"]};
	cChild = new []{progetto.Columns["idprogettokind"]};
	Relations.Add(new DataRelation("FK_progetto_progettokind_idprogettokind",cPar,cChild,false));

	cPar = new []{partnerkind.Columns["idpartnerkind"]};
	cChild = new []{progetto.Columns["idpartnerkind"]};
	Relations.Add(new DataRelation("FK_progetto_partnerkind_idpartnerkind",cPar,cChild,false));

	cPar = new []{corsostudio.Columns["idcorsostudio"]};
	cChild = new []{progetto.Columns["idcorsostudio"]};
	Relations.Add(new DataRelation("FK_progetto_corsostudio_idcorsostudio",cPar,cChild,false));

	cPar = new []{salelenchiview.Columns["idsal"]};
	cChild = new []{progettotimesheet.Columns["idsal"]};
	Relations.Add(new DataRelation("FK_progettotimesheet_salelenchiview_idsal",cPar,cChild,false));

	cPar = new []{progettoelenchiview.Columns["idprogetto"]};
	cChild = new []{salelenchiview.Columns["idprogetto"]};
	Relations.Add(new DataRelation("FK_salelenchiview_progettoelenchiview_idprogetto",cPar,cChild,false));

	cPar = new []{mese.Columns["idmese"]};
	cChild = new []{progettotimesheet.Columns["idmese"]};
	Relations.Add(new DataRelation("FK_progettotimesheet_mese_idmese",cPar,cChild,false));

	cPar = new []{progettoelenchiview.Columns["idprogetto"]};
	cChild = new []{progettotimesheet.Columns["idprogetto"]};
	Relations.Add(new DataRelation("FK_progettotimesheet_progettoelenchiview_idprogetto",cPar,cChild,false));

	cPar = new []{rendicontattivitaprogettoannoview.Columns["idreg"]};
	cChild = new []{progettotimesheet.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_progettotimesheet_rendicontattivitaprogettoannoview_idreg",cPar,cChild,false));

	cPar = new []{timesheettemplate.Columns["idtimesheettemplate"]};
	cChild = new []{progettotimesheet.Columns["idtimesheettemplate"]};
	Relations.Add(new DataRelation("FK_progettotimesheet_timesheettemplate_idtimesheettemplate",cPar,cChild,false));

	cPar = new []{year.Columns["year"]};
	cChild = new []{progettotimesheet.Columns["year"]};
	Relations.Add(new DataRelation("FK_progettotimesheet_year_year",cPar,cChild,false));

	cPar = new []{getregistrydocentiamministrativinomcognmatview.Columns["idreg"]};
	cChild = new []{progettotimesheet.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_progettotimesheet_getregistrydocentiamministrativinomcognmatview_idreg",cPar,cChild,false));

	#endregion

}
}
}
