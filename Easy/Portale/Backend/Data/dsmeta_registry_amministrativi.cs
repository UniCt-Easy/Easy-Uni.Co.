
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
[System.Xml.Serialization.XmlRoot("dsmeta_registry_amministrativi"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_registry_amministrativi: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sospensione 		=> (MetaTable)Tables["sospensione"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontattivitaprogettoitineration 		=> (MetaTable)Tables["rendicontattivitaprogettoitineration"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontattivitaprogettoora 		=> (MetaTable)Tables["rendicontattivitaprogettoora"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable workpackage_alias1 		=> (MetaTable)Tables["workpackage_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontattivitaprogettokind 		=> (MetaTable)Tables["rendicontattivitaprogettokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progetto_alias2 		=> (MetaTable)Tables["progetto_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontattivitaprogetto 		=> (MetaTable)Tables["rendicontattivitaprogetto"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryreference 		=> (MetaTable)Tables["registryreference"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable position 		=> (MetaTable)Tables["position"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable inquadramento 		=> (MetaTable)Tables["inquadramento"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrylegalstatus 		=> (MetaTable)Tables["registrylegalstatus"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettotimesheetprogetto 		=> (MetaTable)Tables["progettotimesheetprogetto"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable year_alias2 		=> (MetaTable)Tables["year_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable timesheettemplate 		=> (MetaTable)Tables["timesheettemplate"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sal 		=> (MetaTable)Tables["sal"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progetto_alias1 		=> (MetaTable)Tables["progetto_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable mese_alias1 		=> (MetaTable)Tables["mese_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettotimesheet 		=> (MetaTable)Tables["progettotimesheet"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetdiaryora 		=> (MetaTable)Tables["assetdiaryora"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable workpackage 		=> (MetaTable)Tables["workpackage"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progetto 		=> (MetaTable)Tables["progetto"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetacquire 		=> (MetaTable)Tables["assetacquire"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable inventory 		=> (MetaTable)Tables["inventory"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable asset 		=> (MetaTable)Tables["asset"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetdiary 		=> (MetaTable)Tables["assetdiary"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable struttura 		=> (MetaTable)Tables["struttura"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable mansionekind 		=> (MetaTable)Tables["mansionekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable afferenza 		=> (MetaTable)Tables["afferenza"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accmotivedefaultview_alias1 		=> (MetaTable)Tables["accmotivedefaultview_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accmotivedefaultview 		=> (MetaTable)Tables["accmotivedefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable residence 		=> (MetaTable)Tables["residence"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrykind 		=> (MetaTable)Tables["registrykind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable category 		=> (MetaTable)Tables["category"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryclassdefaultview 		=> (MetaTable)Tables["registryclassdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable timbratura 		=> (MetaTable)Tables["timbratura"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable maritalstatus 		=> (MetaTable)Tables["maritalstatus"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable costoorario 		=> (MetaTable)Tables["costoorario"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_alias1 		=> (MetaTable)Tables["registry_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable congiuntokind 		=> (MetaTable)Tables["congiuntokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrycongiunto 		=> (MetaTable)Tables["registrycongiunto"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_nation 		=> (MetaTable)Tables["geo_nation"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_city 		=> (MetaTable)Tables["geo_city"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable contrattostipendioview 		=> (MetaTable)Tables["contrattostipendioview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable contrattostipendioannuoview 		=> (MetaTable)Tables["contrattostipendioannuoview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable title 		=> (MetaTable)Tables["title"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable year_alias1 		=> (MetaTable)Tables["year_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable contrattokind_alias1 		=> (MetaTable)Tables["contrattokind_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable contratto_alias2 		=> (MetaTable)Tables["contratto_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable stipendioannuo 		=> (MetaTable)Tables["stipendioannuo"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable year 		=> (MetaTable)Tables["year"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable mese 		=> (MetaTable)Tables["mese"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable contrattokind 		=> (MetaTable)Tables["contrattokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable contratto 		=> (MetaTable)Tables["contratto"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable cedolino 		=> (MetaTable)Tables["cedolino"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry 		=> (MetaTable)Tables["registry"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_registry_amministrativi(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_registry_amministrativi (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_registry_amministrativi";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_registry_amministrativi.xsd";

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

	//////////////////// RENDICONTATTIVITAPROGETTOITINERATION /////////////////////////////////
	var trendicontattivitaprogettoitineration= new MetaTable("rendicontattivitaprogettoitineration");
	trendicontattivitaprogettoitineration.defineColumn("iditineration", typeof(int),false);
	trendicontattivitaprogettoitineration.defineColumn("idprogetto", typeof(int),false);
	trendicontattivitaprogettoitineration.defineColumn("idrendicontattivitaprogetto", typeof(int),false);
	trendicontattivitaprogettoitineration.defineColumn("idworkpackage", typeof(int),false);
	trendicontattivitaprogettoitineration.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(trendicontattivitaprogettoitineration);
	trendicontattivitaprogettoitineration.defineKey("iditineration", "idprogetto", "idrendicontattivitaprogetto", "idworkpackage");

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
	Tables.Add(trendicontattivitaprogettoora);
	trendicontattivitaprogettoora.defineKey("idprogetto", "idreg", "idrendicontattivitaprogetto", "idrendicontattivitaprogettoora", "idworkpackage");

	//////////////////// WORKPACKAGE_ALIAS1 /////////////////////////////////
	var tworkpackage_alias1= new MetaTable("workpackage_alias1");
	tworkpackage_alias1.defineColumn("idprogetto", typeof(int),false);
	tworkpackage_alias1.defineColumn("idworkpackage", typeof(int),false);
	tworkpackage_alias1.defineColumn("raggruppamento", typeof(string));
	tworkpackage_alias1.defineColumn("start", typeof(DateTime));
	tworkpackage_alias1.defineColumn("stop", typeof(DateTime));
	tworkpackage_alias1.defineColumn("title", typeof(string),false);
	tworkpackage_alias1.ExtendedProperties["TableForReading"]="workpackage";
	Tables.Add(tworkpackage_alias1);
	tworkpackage_alias1.defineKey("idprogetto", "idworkpackage");

	//////////////////// RENDICONTATTIVITAPROGETTOKIND /////////////////////////////////
	var trendicontattivitaprogettokind= new MetaTable("rendicontattivitaprogettokind");
	trendicontattivitaprogettokind.defineColumn("active", typeof(string));
	trendicontattivitaprogettokind.defineColumn("idrendicontattivitaprogettokind", typeof(int),false);
	trendicontattivitaprogettokind.defineColumn("title", typeof(string));
	Tables.Add(trendicontattivitaprogettokind);
	trendicontattivitaprogettokind.defineKey("idrendicontattivitaprogettokind");

	//////////////////// PROGETTO_ALIAS2 /////////////////////////////////
	var tprogetto_alias2= new MetaTable("progetto_alias2");
	tprogetto_alias2.defineColumn("idprogetto", typeof(int),false);
	tprogetto_alias2.defineColumn("start", typeof(DateTime));
	tprogetto_alias2.defineColumn("stop", typeof(DateTime));
	tprogetto_alias2.defineColumn("titolobreve", typeof(string));
	tprogetto_alias2.ExtendedProperties["TableForReading"]="progetto";
	Tables.Add(tprogetto_alias2);
	tprogetto_alias2.defineKey("idprogetto");

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
	trendicontattivitaprogetto.defineColumn("stop", typeof(DateTime),false);
	trendicontattivitaprogetto.defineColumn("!idprogetto_progetto_titolobreve", typeof(string));
	trendicontattivitaprogetto.defineColumn("!idprogetto_progetto_start", typeof(DateTime));
	trendicontattivitaprogetto.defineColumn("!idprogetto_progetto_stop", typeof(DateTime));
	trendicontattivitaprogetto.defineColumn("!idrendicontattivitaprogettokind_rendicontattivitaprogettokind_title", typeof(string));
	trendicontattivitaprogetto.defineColumn("!idworkpackage_workpackage_raggruppamento", typeof(string));
	trendicontattivitaprogetto.defineColumn("!idworkpackage_workpackage_title", typeof(string));
	trendicontattivitaprogetto.defineColumn("!idworkpackage_workpackage_start", typeof(DateTime));
	trendicontattivitaprogetto.defineColumn("!idworkpackage_workpackage_stop", typeof(DateTime));
	Tables.Add(trendicontattivitaprogetto);
	trendicontattivitaprogetto.defineKey("idprogetto", "idreg", "idrendicontattivitaprogetto", "idworkpackage");

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

	//////////////////// YEAR_ALIAS2 /////////////////////////////////
	var tyear_alias2= new MetaTable("year_alias2");
	tyear_alias2.defineColumn("year", typeof(int),false);
	tyear_alias2.ExtendedProperties["TableForReading"]="year";
	Tables.Add(tyear_alias2);
	tyear_alias2.defineKey("year");

	//////////////////// TIMESHEETTEMPLATE /////////////////////////////////
	var ttimesheettemplate= new MetaTable("timesheettemplate");
	ttimesheettemplate.defineColumn("idtimesheettemplate", typeof(string),false);
	Tables.Add(ttimesheettemplate);
	ttimesheettemplate.defineKey("idtimesheettemplate");

	//////////////////// SAL /////////////////////////////////
	var tsal= new MetaTable("sal");
	tsal.defineColumn("datablocco", typeof(DateTime));
	tsal.defineColumn("idprogetto", typeof(int),false);
	tsal.defineColumn("idsal", typeof(int),false);
	tsal.defineColumn("start", typeof(DateTime));
	tsal.defineColumn("stop", typeof(DateTime));
	Tables.Add(tsal);
	tsal.defineKey("idprogetto", "idsal");

	//////////////////// PROGETTO_ALIAS1 /////////////////////////////////
	var tprogetto_alias1= new MetaTable("progetto_alias1");
	tprogetto_alias1.defineColumn("idprogetto", typeof(int),false);
	tprogetto_alias1.defineColumn("start", typeof(DateTime));
	tprogetto_alias1.defineColumn("stop", typeof(DateTime));
	tprogetto_alias1.defineColumn("titolobreve", typeof(string));
	tprogetto_alias1.ExtendedProperties["TableForReading"]="progetto";
	Tables.Add(tprogetto_alias1);
	tprogetto_alias1.defineKey("idprogetto");

	//////////////////// MESE_ALIAS1 /////////////////////////////////
	var tmese_alias1= new MetaTable("mese_alias1");
	tmese_alias1.defineColumn("idmese", typeof(int),false);
	tmese_alias1.defineColumn("title", typeof(string));
	tmese_alias1.ExtendedProperties["TableForReading"]="mese";
	Tables.Add(tmese_alias1);
	tmese_alias1.defineKey("idmese");

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
	tprogettotimesheet.defineColumn("!idmese_mese_title", typeof(string));
	tprogettotimesheet.defineColumn("!idprogetto_progetto_titolobreve", typeof(string));
	tprogettotimesheet.defineColumn("!idprogetto_progetto_start", typeof(DateTime));
	tprogettotimesheet.defineColumn("!idprogetto_progetto_stop", typeof(DateTime));
	tprogettotimesheet.defineColumn("!idsal_sal_start", typeof(DateTime));
	tprogettotimesheet.defineColumn("!idsal_sal_stop", typeof(DateTime));
	tprogettotimesheet.defineColumn("!idsal_sal_datablocco", typeof(DateTime));
	Tables.Add(tprogettotimesheet);
	tprogettotimesheet.defineKey("idprogettotimesheet", "idreg");

	//////////////////// ASSETDIARYORA /////////////////////////////////
	var tassetdiaryora= new MetaTable("assetdiaryora");
	tassetdiaryora.defineColumn("!title", typeof(string));
	tassetdiaryora.defineColumn("amount", typeof(decimal));
	tassetdiaryora.defineColumn("ct", typeof(DateTime),false);
	tassetdiaryora.defineColumn("cu", typeof(string),false);
	tassetdiaryora.defineColumn("idassetdiary", typeof(int),false);
	tassetdiaryora.defineColumn("idassetdiaryora", typeof(int),false);
	tassetdiaryora.defineColumn("idsal", typeof(int));
	tassetdiaryora.defineColumn("idworkpackage", typeof(int),false);
	tassetdiaryora.defineColumn("lt", typeof(DateTime),false);
	tassetdiaryora.defineColumn("lu", typeof(string),false);
	tassetdiaryora.defineColumn("start", typeof(DateTime));
	tassetdiaryora.defineColumn("stop", typeof(DateTime));
	Tables.Add(tassetdiaryora);
	tassetdiaryora.defineKey("idassetdiary", "idassetdiaryora", "idworkpackage");

	//////////////////// WORKPACKAGE /////////////////////////////////
	var tworkpackage= new MetaTable("workpackage");
	tworkpackage.defineColumn("idprogetto", typeof(int),false);
	tworkpackage.defineColumn("idworkpackage", typeof(int),false);
	tworkpackage.defineColumn("raggruppamento", typeof(string));
	tworkpackage.defineColumn("title", typeof(string),false);
	Tables.Add(tworkpackage);
	tworkpackage.defineKey("idprogetto", "idworkpackage");

	//////////////////// PROGETTO /////////////////////////////////
	var tprogetto= new MetaTable("progetto");
	tprogetto.defineColumn("idprogetto", typeof(int),false);
	tprogetto.defineColumn("titolobreve", typeof(string));
	Tables.Add(tprogetto);
	tprogetto.defineKey("idprogetto");

	//////////////////// ASSETACQUIRE /////////////////////////////////
	var tassetacquire= new MetaTable("assetacquire");
	tassetacquire.defineColumn("description", typeof(string),false);
	tassetacquire.defineColumn("idinv", typeof(int),false);
	tassetacquire.defineColumn("idupb", typeof(string));
	tassetacquire.defineColumn("nassetacquire", typeof(int),false);
	Tables.Add(tassetacquire);
	tassetacquire.defineKey("nassetacquire");

	//////////////////// INVENTORY /////////////////////////////////
	var tinventory= new MetaTable("inventory");
	tinventory.defineColumn("active", typeof(string));
	tinventory.defineColumn("codeinventory", typeof(string),false);
	tinventory.defineColumn("description", typeof(string),false);
	tinventory.defineColumn("idinventory", typeof(int),false);
	Tables.Add(tinventory);
	tinventory.defineKey("idinventory");

	//////////////////// ASSET /////////////////////////////////
	var tasset= new MetaTable("asset");
	tasset.defineColumn("idasset", typeof(int),false);
	tasset.defineColumn("idinventory", typeof(int));
	tasset.defineColumn("idpiece", typeof(int),false);
	tasset.defineColumn("nassetacquire", typeof(int));
	tasset.defineColumn("ninventory", typeof(int));
	tasset.defineColumn("rfid", typeof(string));
	Tables.Add(tasset);
	tasset.defineKey("idasset", "idpiece");

	//////////////////// ASSETDIARY /////////////////////////////////
	var tassetdiary= new MetaTable("assetdiary");
	tassetdiary.defineColumn("ct", typeof(DateTime),false);
	tassetdiary.defineColumn("cu", typeof(string),false);
	tassetdiary.defineColumn("idasset", typeof(int),false);
	tassetdiary.defineColumn("idassetdiary", typeof(int),false);
	tassetdiary.defineColumn("idpiece", typeof(int));
	tassetdiary.defineColumn("idprogetto", typeof(int),false);
	tassetdiary.defineColumn("idreg", typeof(int),false);
	tassetdiary.defineColumn("idworkpackage", typeof(int),false);
	tassetdiary.defineColumn("lt", typeof(DateTime),false);
	tassetdiary.defineColumn("lu", typeof(string),false);
	tassetdiary.defineColumn("orepreventivate", typeof(int));
	tassetdiary.defineColumn("!idasset-idpiece_asset_ninventory", typeof(int));
	tassetdiary.defineColumn("!idasset-idpiece_asset_idasset", typeof(int));
	tassetdiary.defineColumn("!idasset-idpiece_asset_idpiece", typeof(int));
	tassetdiary.defineColumn("!idasset-idpiece_asset_rfid", typeof(string));
	tassetdiary.defineColumn("!idasset-idpiece_asset_idinventory_codeinventory", typeof(string));
	tassetdiary.defineColumn("!idasset-idpiece_asset_idinventory_description", typeof(string));
	tassetdiary.defineColumn("!idasset-idpiece_asset_nassetacquire_description", typeof(string));
	tassetdiary.defineColumn("!idasset-idpiece_asset_nassetacquire_idinv", typeof(int));
	tassetdiary.defineColumn("!idasset-idpiece_asset_nassetacquire_idupb", typeof(string));
	tassetdiary.defineColumn("!idprogetto_progetto_titolobreve", typeof(string));
	tassetdiary.defineColumn("!idworkpackage_workpackage_raggruppamento", typeof(string));
	tassetdiary.defineColumn("!idworkpackage_workpackage_title", typeof(string));
	tassetdiary.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tassetdiary);
	tassetdiary.defineKey("idassetdiary", "idworkpackage");

	//////////////////// STRUTTURA /////////////////////////////////
	var tstruttura= new MetaTable("struttura");
	tstruttura.defineColumn("active", typeof(string));
	tstruttura.defineColumn("idstruttura", typeof(int),false);
	tstruttura.defineColumn("paridstruttura", typeof(int));
	tstruttura.defineColumn("title", typeof(string));
	Tables.Add(tstruttura);
	tstruttura.defineKey("idstruttura");

	//////////////////// MANSIONEKIND /////////////////////////////////
	var tmansionekind= new MetaTable("mansionekind");
	tmansionekind.defineColumn("idmansionekind", typeof(int),false);
	tmansionekind.defineColumn("title", typeof(string),false);
	Tables.Add(tmansionekind);
	tmansionekind.defineKey("idmansionekind");

	//////////////////// AFFERENZA /////////////////////////////////
	var tafferenza= new MetaTable("afferenza");
	tafferenza.defineColumn("ct", typeof(DateTime),false);
	tafferenza.defineColumn("cu", typeof(string),false);
	tafferenza.defineColumn("idafferenza", typeof(int),false);
	tafferenza.defineColumn("idmansionekind", typeof(int));
	tafferenza.defineColumn("idreg", typeof(int),false);
	tafferenza.defineColumn("idstruttura", typeof(int));
	tafferenza.defineColumn("lt", typeof(DateTime),false);
	tafferenza.defineColumn("lu", typeof(string),false);
	tafferenza.defineColumn("start", typeof(DateTime));
	tafferenza.defineColumn("stop", typeof(DateTime));
	tafferenza.defineColumn("!idmansionekind_mansionekind_title", typeof(string));
	tafferenza.defineColumn("!idstruttura_struttura_title", typeof(string));
	tafferenza.defineColumn("!idstruttura_struttura_paridstruttura", typeof(int));
	Tables.Add(tafferenza);
	tafferenza.defineKey("idafferenza", "idreg");

	//////////////////// ACCMOTIVEDEFAULTVIEW_ALIAS1 /////////////////////////////////
	var taccmotivedefaultview_alias1= new MetaTable("accmotivedefaultview_alias1");
	taccmotivedefaultview_alias1.defineColumn("accmotive_active", typeof(string));
	taccmotivedefaultview_alias1.defineColumn("dropdown_title", typeof(string),false);
	taccmotivedefaultview_alias1.defineColumn("idaccmotive", typeof(string),false);
	taccmotivedefaultview_alias1.ExtendedProperties["TableForReading"]="accmotivedefaultview";
	Tables.Add(taccmotivedefaultview_alias1);
	taccmotivedefaultview_alias1.defineKey("idaccmotive");

	//////////////////// ACCMOTIVEDEFAULTVIEW /////////////////////////////////
	var taccmotivedefaultview= new MetaTable("accmotivedefaultview");
	taccmotivedefaultview.defineColumn("accmotive_active", typeof(string));
	taccmotivedefaultview.defineColumn("dropdown_title", typeof(string),false);
	taccmotivedefaultview.defineColumn("idaccmotive", typeof(string),false);
	Tables.Add(taccmotivedefaultview);
	taccmotivedefaultview.defineKey("idaccmotive");

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

	//////////////////// REGISTRYKIND /////////////////////////////////
	var tregistrykind= new MetaTable("registrykind");
	tregistrykind.defineColumn("description", typeof(string),false);
	tregistrykind.defineColumn("idregistrykind", typeof(int),false);
	Tables.Add(tregistrykind);
	tregistrykind.defineKey("idregistrykind");

	//////////////////// CATEGORY /////////////////////////////////
	var tcategory= new MetaTable("category");
	tcategory.defineColumn("active", typeof(string));
	tcategory.defineColumn("ct", typeof(DateTime),false);
	tcategory.defineColumn("cu", typeof(string),false);
	tcategory.defineColumn("description", typeof(string),false);
	tcategory.defineColumn("idcategory", typeof(string),false);
	tcategory.defineColumn("lt", typeof(DateTime),false);
	tcategory.defineColumn("lu", typeof(string),false);
	Tables.Add(tcategory);
	tcategory.defineKey("idcategory");

	//////////////////// REGISTRYCLASSDEFAULTVIEW /////////////////////////////////
	var tregistryclassdefaultview= new MetaTable("registryclassdefaultview");
	tregistryclassdefaultview.defineColumn("description", typeof(string),false);
	tregistryclassdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tregistryclassdefaultview.defineColumn("idregistryclass", typeof(string),false);
	tregistryclassdefaultview.defineColumn("registryclass_active", typeof(string));
	tregistryclassdefaultview.defineColumn("registryclass_ct", typeof(DateTime),false);
	tregistryclassdefaultview.defineColumn("registryclass_cu", typeof(string),false);
	tregistryclassdefaultview.defineColumn("registryclass_flagbadgecode", typeof(string));
	tregistryclassdefaultview.defineColumn("registryclass_flagbadgecode_forced", typeof(string));
	tregistryclassdefaultview.defineColumn("registryclass_flagCF", typeof(string));
	tregistryclassdefaultview.defineColumn("registryclass_flagcf_forced", typeof(string));
	tregistryclassdefaultview.defineColumn("registryclass_flagcfbutton", typeof(string));
	tregistryclassdefaultview.defineColumn("registryclass_flagextmatricula", typeof(string));
	tregistryclassdefaultview.defineColumn("registryclass_flagextmatricula_forced", typeof(string));
	tregistryclassdefaultview.defineColumn("registryclass_flagfiscalresidence", typeof(string));
	tregistryclassdefaultview.defineColumn("registryclass_flagfiscalresidence_forced", typeof(string));
	tregistryclassdefaultview.defineColumn("registryclass_flagforeigncf", typeof(string));
	tregistryclassdefaultview.defineColumn("registryclass_flagforeigncf_forced", typeof(string));
	tregistryclassdefaultview.defineColumn("registryclass_flaghuman", typeof(string));
	tregistryclassdefaultview.defineColumn("registryclass_flaginfofromcfbutton", typeof(string));
	tregistryclassdefaultview.defineColumn("registryclass_flagmaritalstatus", typeof(string));
	tregistryclassdefaultview.defineColumn("registryclass_flagmaritalstatus_forced", typeof(string));
	tregistryclassdefaultview.defineColumn("registryclass_flagmaritalsurname", typeof(string));
	tregistryclassdefaultview.defineColumn("registryclass_flagmaritalsurname_forced", typeof(string));
	tregistryclassdefaultview.defineColumn("registryclass_flagothers", typeof(string));
	tregistryclassdefaultview.defineColumn("registryclass_flagothers_forced", typeof(string));
	tregistryclassdefaultview.defineColumn("registryclass_flagp_iva", typeof(string));
	tregistryclassdefaultview.defineColumn("registryclass_flagp_iva_forced", typeof(string));
	tregistryclassdefaultview.defineColumn("registryclass_flagqualification", typeof(string));
	tregistryclassdefaultview.defineColumn("registryclass_flagqualification_forced", typeof(string));
	tregistryclassdefaultview.defineColumn("registryclass_flagresidence", typeof(string));
	tregistryclassdefaultview.defineColumn("registryclass_flagresidence_forced", typeof(string));
	tregistryclassdefaultview.defineColumn("registryclass_flagtitle", typeof(string));
	tregistryclassdefaultview.defineColumn("registryclass_flagtitle_forced", typeof(string));
	tregistryclassdefaultview.defineColumn("registryclass_lt", typeof(DateTime),false);
	tregistryclassdefaultview.defineColumn("registryclass_lu", typeof(string),false);
	Tables.Add(tregistryclassdefaultview);
	tregistryclassdefaultview.defineKey("idregistryclass");

	//////////////////// TIMBRATURA /////////////////////////////////
	var ttimbratura= new MetaTable("timbratura");
	ttimbratura.defineColumn("convalida", typeof(string));
	ttimbratura.defineColumn("ct", typeof(DateTime),false);
	ttimbratura.defineColumn("cu", typeof(string),false);
	ttimbratura.defineColumn("data", typeof(DateTime));
	ttimbratura.defineColumn("idreg", typeof(int),false);
	ttimbratura.defineColumn("idtimbratura", typeof(int),false);
	ttimbratura.defineColumn("lt", typeof(DateTime),false);
	ttimbratura.defineColumn("lu", typeof(string),false);
	ttimbratura.defineColumn("minuti", typeof(int));
	Tables.Add(ttimbratura);
	ttimbratura.defineKey("idreg", "idtimbratura");

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

	//////////////////// COSTOORARIO /////////////////////////////////
	var tcostoorario= new MetaTable("costoorario");
	tcostoorario.defineColumn("ct", typeof(DateTime),false);
	tcostoorario.defineColumn("cu", typeof(string),false);
	tcostoorario.defineColumn("idcostoorario", typeof(int),false);
	tcostoorario.defineColumn("idreg", typeof(int),false);
	tcostoorario.defineColumn("irap", typeof(decimal));
	tcostoorario.defineColumn("lt", typeof(DateTime),false);
	tcostoorario.defineColumn("lu", typeof(string),false);
	tcostoorario.defineColumn("netto", typeof(decimal));
	tcostoorario.defineColumn("oneri", typeof(decimal));
	tcostoorario.defineColumn("start", typeof(DateTime));
	tcostoorario.defineColumn("stop", typeof(DateTime));
	tcostoorario.defineColumn("totale", typeof(decimal));
	Tables.Add(tcostoorario);
	tcostoorario.defineKey("idcostoorario", "idreg");

	//////////////////// REGISTRY_ALIAS1 /////////////////////////////////
	var tregistry_alias1= new MetaTable("registry_alias1");
	tregistry_alias1.defineColumn("active", typeof(string),false);
	tregistry_alias1.defineColumn("idreg", typeof(int),false);
	tregistry_alias1.defineColumn("title", typeof(string),false);
	tregistry_alias1.ExtendedProperties["TableForReading"]="registry";
	Tables.Add(tregistry_alias1);
	tregistry_alias1.defineKey("idreg");

	//////////////////// CONGIUNTOKIND /////////////////////////////////
	var tcongiuntokind= new MetaTable("congiuntokind");
	tcongiuntokind.defineColumn("active", typeof(string));
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
	tregistrycongiunto.defineColumn("idreg_parente", typeof(int),false);
	tregistrycongiunto.defineColumn("idregistrycongiunto", typeof(int),false);
	tregistrycongiunto.defineColumn("lt", typeof(DateTime),false);
	tregistrycongiunto.defineColumn("lu", typeof(string),false);
	tregistrycongiunto.defineColumn("!idcongiuntokind_congiuntokind_title", typeof(string));
	tregistrycongiunto.defineColumn("!idreg_parente_registry_title", typeof(string));
	Tables.Add(tregistrycongiunto);
	tregistrycongiunto.defineKey("idreg", "idreg_parente", "idregistrycongiunto");

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

	//////////////////// CONTRATTOSTIPENDIOANNUOVIEW /////////////////////////////////
	var tcontrattostipendioannuoview= new MetaTable("contrattostipendioannuoview");
	tcontrattostipendioannuoview.defineColumn("caricoente", typeof(decimal));
	tcontrattostipendioannuoview.defineColumn("ct", typeof(DateTime));
	tcontrattostipendioannuoview.defineColumn("cu", typeof(string));
	tcontrattostipendioannuoview.defineColumn("idreg", typeof(int),false);
	tcontrattostipendioannuoview.defineColumn("idregistrylegalstatus", typeof(int));
	tcontrattostipendioannuoview.defineColumn("idstipendioannuo", typeof(int));
	tcontrattostipendioannuoview.defineColumn("irap", typeof(decimal));
	tcontrattostipendioannuoview.defineColumn("lordo", typeof(decimal));
	tcontrattostipendioannuoview.defineColumn("lt", typeof(DateTime));
	tcontrattostipendioannuoview.defineColumn("lu", typeof(string));
	tcontrattostipendioannuoview.defineColumn("totale", typeof(decimal));
	tcontrattostipendioannuoview.defineColumn("tredicesima", typeof(decimal));
	tcontrattostipendioannuoview.defineColumn("year", typeof(int),false);
	Tables.Add(tcontrattostipendioannuoview);
	tcontrattostipendioannuoview.defineKey("idreg", "year");

	//////////////////// TITLE /////////////////////////////////
	var ttitle= new MetaTable("title");
	ttitle.defineColumn("active", typeof(string));
	ttitle.defineColumn("ct", typeof(DateTime),false);
	ttitle.defineColumn("cu", typeof(string),false);
	ttitle.defineColumn("description", typeof(string),false);
	ttitle.defineColumn("idtitle", typeof(string),false);
	ttitle.defineColumn("lt", typeof(DateTime),false);
	ttitle.defineColumn("lu", typeof(string),false);
	Tables.Add(ttitle);
	ttitle.defineKey("idtitle");

	//////////////////// YEAR_ALIAS1 /////////////////////////////////
	var tyear_alias1= new MetaTable("year_alias1");
	tyear_alias1.defineColumn("year", typeof(int),false);
	tyear_alias1.ExtendedProperties["TableForReading"]="year";
	Tables.Add(tyear_alias1);
	tyear_alias1.defineKey("year");

	//////////////////// CONTRATTOKIND_ALIAS1 /////////////////////////////////
	var tcontrattokind_alias1= new MetaTable("contrattokind_alias1");
	tcontrattokind_alias1.defineColumn("active", typeof(string),false);
	tcontrattokind_alias1.defineColumn("idcontrattokind", typeof(int),false);
	tcontrattokind_alias1.defineColumn("title", typeof(string),false);
	tcontrattokind_alias1.ExtendedProperties["TableForReading"]="contrattokind";
	Tables.Add(tcontrattokind_alias1);
	tcontrattokind_alias1.defineKey("idcontrattokind");

	//////////////////// CONTRATTO_ALIAS2 /////////////////////////////////
	var tcontratto_alias2= new MetaTable("contratto_alias2");
	tcontratto_alias2.defineColumn("idcontratto", typeof(int),false);
	tcontratto_alias2.defineColumn("idcontrattokind", typeof(int),false);
	tcontratto_alias2.defineColumn("idreg", typeof(int),false);
	tcontratto_alias2.defineColumn("start", typeof(DateTime),false);
	tcontratto_alias2.defineColumn("stop", typeof(DateTime));
	tcontratto_alias2.ExtendedProperties["TableForReading"]="contratto";
	Tables.Add(tcontratto_alias2);
	tcontratto_alias2.defineKey("idcontratto", "idreg");

	//////////////////// STIPENDIOANNUO /////////////////////////////////
	var tstipendioannuo= new MetaTable("stipendioannuo");
	tstipendioannuo.defineColumn("caricoente", typeof(decimal));
	tstipendioannuo.defineColumn("ct", typeof(DateTime));
	tstipendioannuo.defineColumn("cu", typeof(string));
	tstipendioannuo.defineColumn("idcontratto", typeof(int));
	tstipendioannuo.defineColumn("idreg", typeof(int),false);
	tstipendioannuo.defineColumn("idregistrylegalstatus", typeof(int),false);
	tstipendioannuo.defineColumn("idstipendioannuo", typeof(int),false);
	tstipendioannuo.defineColumn("irap", typeof(decimal));
	tstipendioannuo.defineColumn("lordo", typeof(decimal));
	tstipendioannuo.defineColumn("lt", typeof(DateTime));
	tstipendioannuo.defineColumn("lu", typeof(string));
	tstipendioannuo.defineColumn("totale", typeof(decimal));
	tstipendioannuo.defineColumn("year", typeof(int),false);
	tstipendioannuo.defineColumn("!idcontratto_contratto_start", typeof(DateTime));
	tstipendioannuo.defineColumn("!idcontratto_contratto_stop", typeof(DateTime));
	tstipendioannuo.defineColumn("!idcontratto_contratto_idcontrattokind_title", typeof(string));
	Tables.Add(tstipendioannuo);
	tstipendioannuo.defineKey("idreg", "idregistrylegalstatus", "idstipendioannuo", "year");

	//////////////////// YEAR /////////////////////////////////
	var tyear= new MetaTable("year");
	tyear.defineColumn("year", typeof(int),false);
	Tables.Add(tyear);
	tyear.defineKey("year");

	//////////////////// MESE /////////////////////////////////
	var tmese= new MetaTable("mese");
	tmese.defineColumn("idmese", typeof(int),false);
	tmese.defineColumn("title", typeof(string));
	Tables.Add(tmese);
	tmese.defineKey("idmese");

	//////////////////// CONTRATTOKIND /////////////////////////////////
	var tcontrattokind= new MetaTable("contrattokind");
	tcontrattokind.defineColumn("active", typeof(string),false);
	tcontrattokind.defineColumn("idcontrattokind", typeof(int),false);
	tcontrattokind.defineColumn("title", typeof(string),false);
	Tables.Add(tcontrattokind);
	tcontrattokind.defineKey("idcontrattokind");

	//////////////////// CONTRATTO /////////////////////////////////
	var tcontratto= new MetaTable("contratto");
	tcontratto.defineColumn("idcontratto", typeof(int),false);
	tcontratto.defineColumn("idcontrattokind", typeof(int),false);
	tcontratto.defineColumn("idreg", typeof(int),false);
	tcontratto.defineColumn("start", typeof(DateTime),false);
	tcontratto.defineColumn("stop", typeof(DateTime));
	Tables.Add(tcontratto);
	tcontratto.defineKey("idcontratto", "idreg");

	//////////////////// CEDOLINO /////////////////////////////////
	var tcedolino= new MetaTable("cedolino");
	tcedolino.defineColumn("!previdenza", typeof(decimal));
	tcedolino.defineColumn("!tesoro", typeof(decimal));
	tcedolino.defineColumn("!tredicesima", typeof(decimal));
	tcedolino.defineColumn("assegno", typeof(decimal));
	tcedolino.defineColumn("classe", typeof(int));
	tcedolino.defineColumn("data", typeof(DateTime));
	tcedolino.defineColumn("idcedolino", typeof(int),false);
	tcedolino.defineColumn("idcontratto", typeof(int));
	tcedolino.defineColumn("idmese", typeof(int));
	tcedolino.defineColumn("idreg", typeof(int),false);
	tcedolino.defineColumn("idregistrylegalstatus", typeof(int),false);
	tcedolino.defineColumn("iis", typeof(decimal));
	tcedolino.defineColumn("irap", typeof(decimal));
	tcedolino.defineColumn("lordo", typeof(decimal));
	tcedolino.defineColumn("scatto", typeof(int));
	tcedolino.defineColumn("stipendio", typeof(decimal));
	tcedolino.defineColumn("totale", typeof(decimal));
	tcedolino.defineColumn("totalece", typeof(decimal));
	tcedolino.defineColumn("year", typeof(int));
	tcedolino.defineColumn("!idcontratto_contratto_start", typeof(DateTime));
	tcedolino.defineColumn("!idcontratto_contratto_stop", typeof(DateTime));
	tcedolino.defineColumn("!idcontratto_contratto_idcontrattokind_title", typeof(string));
	tcedolino.defineColumn("!idmese_mese_title", typeof(string));
	Tables.Add(tcedolino);
	tcedolino.defineKey("idcedolino", "idreg", "idregistrylegalstatus");

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
	tregistry.defineColumn("idateco", typeof(int));
	tregistry.defineColumn("idcategory", typeof(string));
	tregistry.defineColumn("idcentralizedcategory", typeof(string));
	tregistry.defineColumn("idcity", typeof(int));
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
	tregistry.defineColumn("surname", typeof(string));
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
	cChild = new []{rendicontattivitaprogetto.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogetto_registry_idreg",cPar,cChild,false));

	cPar = new []{rendicontattivitaprogetto.Columns["idrendicontattivitaprogetto"], rendicontattivitaprogetto.Columns["idworkpackage"], rendicontattivitaprogetto.Columns["idprogetto"], rendicontattivitaprogetto.Columns["iditineration"]};
	cChild = new []{rendicontattivitaprogettoitineration.Columns["idrendicontattivitaprogetto"], rendicontattivitaprogettoitineration.Columns["idworkpackage"], rendicontattivitaprogettoitineration.Columns["idprogetto"], rendicontattivitaprogettoitineration.Columns["iditineration"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogettoitineration_rendicontattivitaprogetto_idrendicontattivitaprogetto-idworkpackage-idprogetto-iditineration",cPar,cChild,false));

	cPar = new []{rendicontattivitaprogetto.Columns["idrendicontattivitaprogetto"], rendicontattivitaprogetto.Columns["idworkpackage"], rendicontattivitaprogetto.Columns["idprogetto"], rendicontattivitaprogetto.Columns["idreg"]};
	cChild = new []{rendicontattivitaprogettoora.Columns["idrendicontattivitaprogetto"], rendicontattivitaprogettoora.Columns["idworkpackage"], rendicontattivitaprogettoora.Columns["idprogetto"], rendicontattivitaprogettoora.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogettoora_rendicontattivitaprogetto_idrendicontattivitaprogetto-idworkpackage-idprogetto-idreg",cPar,cChild,false));

	cPar = new []{workpackage_alias1.Columns["idworkpackage"]};
	cChild = new []{rendicontattivitaprogetto.Columns["idworkpackage"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogetto_workpackage_alias1_idworkpackage",cPar,cChild,false));

	cPar = new []{rendicontattivitaprogettokind.Columns["idrendicontattivitaprogettokind"]};
	cChild = new []{rendicontattivitaprogetto.Columns["idrendicontattivitaprogettokind"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogetto_rendicontattivitaprogettokind_idrendicontattivitaprogettokind",cPar,cChild,false));

	cPar = new []{progetto_alias2.Columns["idprogetto"]};
	cChild = new []{rendicontattivitaprogetto.Columns["idprogetto"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogetto_progetto_alias2_idprogetto",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registryreference.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registryreference_registry_idreg",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registrylegalstatus.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registrylegalstatus_registry_idreg",cPar,cChild,false));

	cPar = new []{position.Columns["idposition"]};
	cChild = new []{registrylegalstatus.Columns["idposition"]};
	Relations.Add(new DataRelation("FK_registrylegalstatus_position_idposition",cPar,cChild,false));

	cPar = new []{inquadramento.Columns["idinquadramento"]};
	cChild = new []{registrylegalstatus.Columns["idinquadramento"]};
	Relations.Add(new DataRelation("FK_registrylegalstatus_inquadramento_idinquadramento",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{progettotimesheet.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_progettotimesheet_registry_idreg",cPar,cChild,false));

	cPar = new []{progettotimesheet.Columns["idprogettotimesheet"]};
	cChild = new []{progettotimesheetprogetto.Columns["idprogettotimesheet"]};
	Relations.Add(new DataRelation("FK_progettotimesheetprogetto_progettotimesheet_idprogettotimesheet",cPar,cChild,false));

	cPar = new []{year_alias2.Columns["year"]};
	cChild = new []{progettotimesheet.Columns["year"]};
	Relations.Add(new DataRelation("FK_progettotimesheet_year_alias2_year",cPar,cChild,false));

	cPar = new []{timesheettemplate.Columns["idtimesheettemplate"]};
	cChild = new []{progettotimesheet.Columns["idtimesheettemplate"]};
	Relations.Add(new DataRelation("FK_progettotimesheet_timesheettemplate_idtimesheettemplate",cPar,cChild,false));

	cPar = new []{sal.Columns["idsal"]};
	cChild = new []{progettotimesheet.Columns["idsal"]};
	Relations.Add(new DataRelation("FK_progettotimesheet_sal_idsal",cPar,cChild,false));

	cPar = new []{progetto_alias1.Columns["idprogetto"]};
	cChild = new []{progettotimesheet.Columns["idprogetto"]};
	Relations.Add(new DataRelation("FK_progettotimesheet_progetto_alias1_idprogetto",cPar,cChild,false));

	cPar = new []{mese_alias1.Columns["idmese"]};
	cChild = new []{progettotimesheet.Columns["idmese"]};
	Relations.Add(new DataRelation("FK_progettotimesheet_mese_alias1_idmese",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{assetdiary.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_assetdiary_registry_idreg",cPar,cChild,false));

	cPar = new []{assetdiary.Columns["idassetdiary"], assetdiary.Columns["idworkpackage"]};
	cChild = new []{assetdiaryora.Columns["idassetdiary"], assetdiaryora.Columns["idworkpackage"]};
	Relations.Add(new DataRelation("FK_assetdiaryora_assetdiary_idassetdiary-idworkpackage",cPar,cChild,false));

	cPar = new []{workpackage.Columns["idworkpackage"]};
	cChild = new []{assetdiary.Columns["idworkpackage"]};
	Relations.Add(new DataRelation("FK_assetdiary_workpackage_idworkpackage",cPar,cChild,false));

	cPar = new []{progetto.Columns["idprogetto"]};
	cChild = new []{assetdiary.Columns["idprogetto"]};
	Relations.Add(new DataRelation("FK_assetdiary_progetto_idprogetto",cPar,cChild,false));

	cPar = new []{asset.Columns["idasset"], asset.Columns["idpiece"]};
	cChild = new []{assetdiary.Columns["idasset"], assetdiary.Columns["idpiece"]};
	Relations.Add(new DataRelation("FK_assetdiary_asset_idasset-idpiece",cPar,cChild,false));

	cPar = new []{assetacquire.Columns["nassetacquire"]};
	cChild = new []{asset.Columns["nassetacquire"]};
	Relations.Add(new DataRelation("FK_asset_assetacquire_nassetacquire",cPar,cChild,false));

	cPar = new []{inventory.Columns["idinventory"]};
	cChild = new []{asset.Columns["idinventory"]};
	Relations.Add(new DataRelation("FK_asset_inventory_idinventory",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{afferenza.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_afferenza_registry_idreg",cPar,cChild,false));

	cPar = new []{struttura.Columns["idstruttura"]};
	cChild = new []{afferenza.Columns["idstruttura"]};
	Relations.Add(new DataRelation("FK_afferenza_struttura_idstruttura",cPar,cChild,false));

	cPar = new []{mansionekind.Columns["idmansionekind"]};
	cChild = new []{afferenza.Columns["idmansionekind"]};
	Relations.Add(new DataRelation("FK_afferenza_mansionekind_idmansionekind",cPar,cChild,false));

	cPar = new []{accmotivedefaultview_alias1.Columns["idaccmotive"]};
	cChild = new []{registry.Columns["idaccmotivecredit"]};
	Relations.Add(new DataRelation("FK_registry_accmotivedefaultview_alias1_idaccmotivecredit",cPar,cChild,false));

	cPar = new []{accmotivedefaultview.Columns["idaccmotive"]};
	cChild = new []{registry.Columns["idaccmotivedebit"]};
	Relations.Add(new DataRelation("FK_registry_accmotivedefaultview_idaccmotivedebit",cPar,cChild,false));

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

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{timbratura.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_timbratura_registry_idreg",cPar,cChild,false));

	cPar = new []{maritalstatus.Columns["idmaritalstatus"]};
	cChild = new []{registry.Columns["idmaritalstatus"]};
	Relations.Add(new DataRelation("FK_registry_maritalstatus_idmaritalstatus",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{costoorario.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_costoorario_registry_idreg",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registrycongiunto.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registrycongiunto_registry_idreg",cPar,cChild,false));

	cPar = new []{registry_alias1.Columns["idreg"]};
	cChild = new []{registrycongiunto.Columns["idreg_parente"]};
	Relations.Add(new DataRelation("FK_registrycongiunto_registry_alias1_idreg_parente",cPar,cChild,false));

	cPar = new []{congiuntokind.Columns["idcongiuntokind"]};
	cChild = new []{registrycongiunto.Columns["idcongiuntokind"]};
	Relations.Add(new DataRelation("FK_registrycongiunto_congiuntokind_idcongiuntokind",cPar,cChild,false));

	cPar = new []{geo_nation.Columns["idnation"]};
	cChild = new []{registry.Columns["idnation"]};
	Relations.Add(new DataRelation("FK_registry_geo_nation_idnation",cPar,cChild,false));

	cPar = new []{geo_city.Columns["idcity"]};
	cChild = new []{registry.Columns["idcity"]};
	Relations.Add(new DataRelation("FK_registry_geo_city_idcity",cPar,cChild,false));

	cPar = new []{contrattostipendioview.Columns["idreg"]};
	cChild = new []{registry.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registry_contrattostipendioview_idreg",cPar,cChild,false));

	cPar = new []{contrattostipendioannuoview.Columns["idreg"]};
	cChild = new []{registry.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registry_contrattostipendioannuoview_idreg",cPar,cChild,false));

	cPar = new []{title.Columns["idtitle"]};
	cChild = new []{registry.Columns["idtitle"]};
	Relations.Add(new DataRelation("FK_registry_title_idtitle",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{stipendioannuo.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_stipendioannuo_registry_idreg",cPar,cChild,false));

	cPar = new []{year_alias1.Columns["year"]};
	cChild = new []{stipendioannuo.Columns["year"]};
	Relations.Add(new DataRelation("FK_stipendioannuo_year_alias1_year",cPar,cChild,false));

	cPar = new []{contratto_alias2.Columns["idcontratto"]};
	cChild = new []{stipendioannuo.Columns["idcontratto"]};
	Relations.Add(new DataRelation("FK_stipendioannuo_contratto_alias2_idcontratto",cPar,cChild,false));

	cPar = new []{contrattokind_alias1.Columns["idcontrattokind"]};
	cChild = new []{contratto_alias2.Columns["idcontrattokind"]};
	Relations.Add(new DataRelation("FK_contratto_alias2_contrattokind_alias1_idcontrattokind",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{cedolino.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_cedolino_registry_idreg",cPar,cChild,false));

	cPar = new []{year.Columns["year"]};
	cChild = new []{cedolino.Columns["year"]};
	Relations.Add(new DataRelation("FK_cedolino_year_year",cPar,cChild,false));

	cPar = new []{mese.Columns["idmese"]};
	cChild = new []{cedolino.Columns["idmese"]};
	Relations.Add(new DataRelation("FK_cedolino_mese_idmese",cPar,cChild,false));

	cPar = new []{contratto.Columns["idcontratto"]};
	cChild = new []{cedolino.Columns["idcontratto"]};
	Relations.Add(new DataRelation("FK_cedolino_contratto_idcontratto",cPar,cChild,false));

	cPar = new []{contrattokind.Columns["idcontrattokind"]};
	cChild = new []{contratto.Columns["idcontrattokind"]};
	Relations.Add(new DataRelation("FK_contratto_contrattokind_idcontrattokind",cPar,cChild,false));

	#endregion

}
}
}
