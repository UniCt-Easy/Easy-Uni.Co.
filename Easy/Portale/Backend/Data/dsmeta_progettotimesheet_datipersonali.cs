
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
[System.Xml.Serialization.XmlRoot("dsmeta_progettotimesheet_datipersonali"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_progettotimesheet_datipersonali: DataSet {

	#region Table members declaration
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
	public MetaTable timesheettemplate 		=> (MetaTable)Tables["timesheettemplate"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable year 		=> (MetaTable)Tables["year"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettotimesheet 		=> (MetaTable)Tables["progettotimesheet"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_progettotimesheet_datipersonali(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_progettotimesheet_datipersonali (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_progettotimesheet_datipersonali";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_progettotimesheet_datipersonali.xsd";

	#region create DataTables
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
	var cPar = new []{progettotimesheet.Columns["idprogettotimesheet"]};
	var cChild = new []{progettotimesheetprogetto.Columns["idprogettotimesheet"]};
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

	cPar = new []{timesheettemplate.Columns["idtimesheettemplate"]};
	cChild = new []{progettotimesheet.Columns["idtimesheettemplate"]};
	Relations.Add(new DataRelation("FK_progettotimesheet_timesheettemplate_idtimesheettemplate",cPar,cChild,false));

	cPar = new []{year.Columns["year"]};
	cChild = new []{progettotimesheet.Columns["year"]};
	Relations.Add(new DataRelation("FK_progettotimesheet_year_year",cPar,cChild,false));

	#endregion

}
}
}
