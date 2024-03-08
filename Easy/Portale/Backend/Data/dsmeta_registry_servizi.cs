
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
[System.Xml.Serialization.XmlRoot("dsmeta_registry_servizi"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_registry_servizi: DataSet {

	#region Table members declaration
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
	public MetaTable serviziriepilogoview 		=> (MetaTable)Tables["serviziriepilogoview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable servizioaltro 		=> (MetaTable)Tables["servizioaltro"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable servizioricongiunzioni 		=> (MetaTable)Tables["servizioricongiunzioni"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable serviziomilitare 		=> (MetaTable)Tables["serviziomilitare"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable serviziocontributi 		=> (MetaTable)Tables["serviziocontributi"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_nation 		=> (MetaTable)Tables["geo_nation"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable position_alias2 		=> (MetaTable)Tables["position_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable serviziopreruoloinps 		=> (MetaTable)Tables["serviziopreruoloinps"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_city 		=> (MetaTable)Tables["geo_city"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable position_alias1 		=> (MetaTable)Tables["position_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable serviziopreruolotesoro 		=> (MetaTable)Tables["serviziopreruolotesoro"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable contrattostipendioview 		=> (MetaTable)Tables["contrattostipendioview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable position 		=> (MetaTable)Tables["position"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrylegalstatus 		=> (MetaTable)Tables["registrylegalstatus"];

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
public dsmeta_registry_servizi(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_registry_servizi (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_registry_servizi";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_registry_servizi.xsd";

	#region create DataTables
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

	//////////////////// SERVIZIRIEPILOGOVIEW /////////////////////////////////
	var tserviziriepilogoview= new MetaTable("serviziriepilogoview");
	tserviziriepilogoview.defineColumn("anni", typeof(int));
	tserviziriepilogoview.defineColumn("cedolini", typeof(string));
	tserviziriepilogoview.defineColumn("ct", typeof(DateTime),false);
	tserviziriepilogoview.defineColumn("cu", typeof(string),false);
	tserviziriepilogoview.defineColumn("giorni", typeof(int));
	tserviziriepilogoview.defineColumn("idreg", typeof(int),false);
	tserviziriepilogoview.defineColumn("idserviziriepilogoview", typeof(string),false);
	tserviziriepilogoview.defineColumn("istituzione", typeof(string));
	tserviziriepilogoview.defineColumn("lt", typeof(DateTime),false);
	tserviziriepilogoview.defineColumn("lu", typeof(string),false);
	tserviziriepilogoview.defineColumn("mesi", typeof(int));
	tserviziriepilogoview.defineColumn("start", typeof(DateTime));
	tserviziriepilogoview.defineColumn("stop", typeof(DateTime));
	tserviziriepilogoview.defineColumn("tipologia", typeof(string),false);
	tserviziriepilogoview.defineColumn("totaldays", typeof(int));
	Tables.Add(tserviziriepilogoview);
	tserviziriepilogoview.defineKey("idreg", "idserviziriepilogoview");

	//////////////////// SERVIZIOALTRO /////////////////////////////////
	var tservizioaltro= new MetaTable("servizioaltro");
	tservizioaltro.defineColumn("anni", typeof(int));
	tservizioaltro.defineColumn("ct", typeof(DateTime),false);
	tservizioaltro.defineColumn("cu", typeof(string),false);
	tservizioaltro.defineColumn("giorni", typeof(int));
	tservizioaltro.defineColumn("idreg", typeof(int),false);
	tservizioaltro.defineColumn("idservizioaltro", typeof(int),false);
	tservizioaltro.defineColumn("istituzione", typeof(string));
	tservizioaltro.defineColumn("lt", typeof(DateTime),false);
	tservizioaltro.defineColumn("lu", typeof(string),false);
	tservizioaltro.defineColumn("mesi", typeof(int));
	tservizioaltro.defineColumn("start", typeof(DateTime));
	tservizioaltro.defineColumn("stop", typeof(DateTime));
	Tables.Add(tservizioaltro);
	tservizioaltro.defineKey("idreg", "idservizioaltro");

	//////////////////// SERVIZIORICONGIUNZIONI /////////////////////////////////
	var tservizioricongiunzioni= new MetaTable("servizioricongiunzioni");
	tservizioricongiunzioni.defineColumn("anni", typeof(int));
	tservizioricongiunzioni.defineColumn("cronologico", typeof(string));
	tservizioricongiunzioni.defineColumn("ct", typeof(DateTime),false);
	tservizioricongiunzioni.defineColumn("cu", typeof(string),false);
	tservizioricongiunzioni.defineColumn("datadecreto", typeof(DateTime));
	tservizioricongiunzioni.defineColumn("dataregdecreto", typeof(DateTime));
	tservizioricongiunzioni.defineColumn("euro", typeof(decimal));
	tservizioricongiunzioni.defineColumn("foglio", typeof(string));
	tservizioricongiunzioni.defineColumn("giorni", typeof(int));
	tservizioricongiunzioni.defineColumn("idreg", typeof(int),false);
	tservizioricongiunzioni.defineColumn("idservizioricongiunzioni", typeof(int),false);
	tservizioricongiunzioni.defineColumn("lire", typeof(int));
	tservizioricongiunzioni.defineColumn("lt", typeof(DateTime),false);
	tservizioricongiunzioni.defineColumn("lu", typeof(string),false);
	tservizioricongiunzioni.defineColumn("mesi", typeof(int));
	tservizioricongiunzioni.defineColumn("ndecreto", typeof(string));
	tservizioricongiunzioni.defineColumn("registro", typeof(string));
	tservizioricongiunzioni.defineColumn("start", typeof(DateTime));
	tservizioricongiunzioni.defineColumn("stop", typeof(DateTime));
	Tables.Add(tservizioricongiunzioni);
	tservizioricongiunzioni.defineKey("idreg", "idservizioricongiunzioni");

	//////////////////// SERVIZIOMILITARE /////////////////////////////////
	var tserviziomilitare= new MetaTable("serviziomilitare");
	tserviziomilitare.defineColumn("anni", typeof(int));
	tserviziomilitare.defineColumn("ct", typeof(DateTime),false);
	tserviziomilitare.defineColumn("cu", typeof(string),false);
	tserviziomilitare.defineColumn("giorni", typeof(int));
	tserviziomilitare.defineColumn("idreg", typeof(int),false);
	tserviziomilitare.defineColumn("idserviziomilitare", typeof(int),false);
	tserviziomilitare.defineColumn("istituzione", typeof(string));
	tserviziomilitare.defineColumn("lt", typeof(DateTime),false);
	tserviziomilitare.defineColumn("lu", typeof(string),false);
	tserviziomilitare.defineColumn("mesi", typeof(int));
	tserviziomilitare.defineColumn("start", typeof(DateTime));
	tserviziomilitare.defineColumn("stop", typeof(DateTime));
	Tables.Add(tserviziomilitare);
	tserviziomilitare.defineKey("idreg", "idserviziomilitare");

	//////////////////// SERVIZIOCONTRIBUTI /////////////////////////////////
	var tserviziocontributi= new MetaTable("serviziocontributi");
	tserviziocontributi.defineColumn("anni", typeof(int));
	tserviziocontributi.defineColumn("ct", typeof(DateTime),false);
	tserviziocontributi.defineColumn("cu", typeof(string),false);
	tserviziocontributi.defineColumn("giorni", typeof(int));
	tserviziocontributi.defineColumn("idreg", typeof(int),false);
	tserviziocontributi.defineColumn("idserviziocontributi", typeof(int),false);
	tserviziocontributi.defineColumn("istituzione", typeof(string));
	tserviziocontributi.defineColumn("lt", typeof(DateTime),false);
	tserviziocontributi.defineColumn("lu", typeof(string),false);
	tserviziocontributi.defineColumn("mesi", typeof(int));
	tserviziocontributi.defineColumn("start", typeof(DateTime));
	tserviziocontributi.defineColumn("stop", typeof(DateTime));
	Tables.Add(tserviziocontributi);
	tserviziocontributi.defineKey("idreg", "idserviziocontributi");

	//////////////////// GEO_NATION /////////////////////////////////
	var tgeo_nation= new MetaTable("geo_nation");
	tgeo_nation.defineColumn("idnation", typeof(int),false);
	tgeo_nation.defineColumn("title", typeof(string));
	Tables.Add(tgeo_nation);
	tgeo_nation.defineKey("idnation");

	//////////////////// POSITION_ALIAS2 /////////////////////////////////
	var tposition_alias2= new MetaTable("position_alias2");
	tposition_alias2.defineColumn("active", typeof(string));
	tposition_alias2.defineColumn("idposition", typeof(int),false);
	tposition_alias2.defineColumn("title", typeof(string));
	tposition_alias2.ExtendedProperties["TableForReading"]="position";
	Tables.Add(tposition_alias2);
	tposition_alias2.defineKey("idposition");

	//////////////////// SERVIZIOPRERUOLOINPS /////////////////////////////////
	var tserviziopreruoloinps= new MetaTable("serviziopreruoloinps");
	tserviziopreruoloinps.defineColumn("anni", typeof(int));
	tserviziopreruoloinps.defineColumn("annokind", typeof(string));
	tserviziopreruoloinps.defineColumn("cedolini", typeof(string));
	tserviziopreruoloinps.defineColumn("ct", typeof(DateTime),false);
	tserviziopreruoloinps.defineColumn("cu", typeof(string),false);
	tserviziopreruoloinps.defineColumn("giorni", typeof(int));
	tserviziopreruoloinps.defineColumn("idposition", typeof(int));
	tserviziopreruoloinps.defineColumn("idreg", typeof(int),false);
	tserviziopreruoloinps.defineColumn("idserviziopreruoloinps", typeof(int),false);
	tserviziopreruoloinps.defineColumn("istituzione", typeof(string));
	tserviziopreruoloinps.defineColumn("lt", typeof(DateTime),false);
	tserviziopreruoloinps.defineColumn("lu", typeof(string),false);
	tserviziopreruoloinps.defineColumn("mesi", typeof(int));
	tserviziopreruoloinps.defineColumn("start", typeof(DateTime));
	tserviziopreruoloinps.defineColumn("stop", typeof(DateTime));
	tserviziopreruoloinps.defineColumn("!idposition_position_title", typeof(string));
	Tables.Add(tserviziopreruoloinps);
	tserviziopreruoloinps.defineKey("idreg", "idserviziopreruoloinps");

	//////////////////// GEO_CITY /////////////////////////////////
	var tgeo_city= new MetaTable("geo_city");
	tgeo_city.defineColumn("idcity", typeof(int),false);
	tgeo_city.defineColumn("title", typeof(string));
	Tables.Add(tgeo_city);
	tgeo_city.defineKey("idcity");

	//////////////////// POSITION_ALIAS1 /////////////////////////////////
	var tposition_alias1= new MetaTable("position_alias1");
	tposition_alias1.defineColumn("active", typeof(string));
	tposition_alias1.defineColumn("idposition", typeof(int),false);
	tposition_alias1.defineColumn("title", typeof(string));
	tposition_alias1.ExtendedProperties["TableForReading"]="position";
	Tables.Add(tposition_alias1);
	tposition_alias1.defineKey("idposition");

	//////////////////// SERVIZIOPRERUOLOTESORO /////////////////////////////////
	var tserviziopreruolotesoro= new MetaTable("serviziopreruolotesoro");
	tserviziopreruolotesoro.defineColumn("anni", typeof(int));
	tserviziopreruolotesoro.defineColumn("annokind", typeof(string),false);
	tserviziopreruolotesoro.defineColumn("cedolini", typeof(string));
	tserviziopreruolotesoro.defineColumn("ct", typeof(DateTime),false);
	tserviziopreruolotesoro.defineColumn("cu", typeof(string),false);
	tserviziopreruolotesoro.defineColumn("giorni", typeof(int));
	tserviziopreruolotesoro.defineColumn("idposition", typeof(int));
	tserviziopreruolotesoro.defineColumn("idreg", typeof(int),false);
	tserviziopreruolotesoro.defineColumn("idserviziopreruolotesoro", typeof(int),false);
	tserviziopreruolotesoro.defineColumn("istituzione", typeof(string));
	tserviziopreruolotesoro.defineColumn("lt", typeof(DateTime),false);
	tserviziopreruolotesoro.defineColumn("lu", typeof(string),false);
	tserviziopreruolotesoro.defineColumn("mesi", typeof(int));
	tserviziopreruolotesoro.defineColumn("start", typeof(DateTime));
	tserviziopreruolotesoro.defineColumn("stop", typeof(DateTime));
	tserviziopreruolotesoro.defineColumn("!idposition_position_title", typeof(string));
	Tables.Add(tserviziopreruolotesoro);
	tserviziopreruolotesoro.defineKey("idreg", "idserviziopreruolotesoro");

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

	//////////////////// POSITION /////////////////////////////////
	var tposition= new MetaTable("position");
	tposition.defineColumn("active", typeof(string));
	tposition.defineColumn("idposition", typeof(int),false);
	tposition.defineColumn("title", typeof(string));
	Tables.Add(tposition);
	tposition.defineKey("idposition");

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
	tregistrylegalstatus.defineColumn("!idposition_position_title", typeof(string));
	Tables.Add(tregistrylegalstatus);
	tregistrylegalstatus.defineKey("idreg", "idregistrylegalstatus");

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

	#endregion


	#region DataRelation creation
	var cPar = new []{residence.Columns["idresidence"]};
	var cChild = new []{registry.Columns["residence"]};
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

	cPar = new []{serviziriepilogoview.Columns["idreg"]};
	cChild = new []{registry.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registry_serviziriepilogoview_idreg",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{servizioaltro.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_servizioaltro_registry_idreg",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{servizioricongiunzioni.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_servizioricongiunzioni_registry_idreg",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{serviziomilitare.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_serviziomilitare_registry_idreg",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{serviziocontributi.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_serviziocontributi_registry_idreg",cPar,cChild,false));

	cPar = new []{geo_nation.Columns["idnation"]};
	cChild = new []{registry.Columns["idnation"]};
	Relations.Add(new DataRelation("FK_registry_geo_nation_idnation",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{serviziopreruoloinps.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_serviziopreruoloinps_registry_idreg",cPar,cChild,false));

	cPar = new []{position_alias2.Columns["idposition"]};
	cChild = new []{serviziopreruoloinps.Columns["idposition"]};
	Relations.Add(new DataRelation("FK_serviziopreruoloinps_position_alias2_idposition",cPar,cChild,false));

	cPar = new []{geo_city.Columns["idcity"]};
	cChild = new []{registry.Columns["idcity"]};
	Relations.Add(new DataRelation("FK_registry_geo_city_idcity",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{serviziopreruolotesoro.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_serviziopreruolotesoro_registry_idreg",cPar,cChild,false));

	cPar = new []{position_alias1.Columns["idposition"]};
	cChild = new []{serviziopreruolotesoro.Columns["idposition"]};
	Relations.Add(new DataRelation("FK_serviziopreruolotesoro_position_alias1_idposition",cPar,cChild,false));

	cPar = new []{contrattostipendioview.Columns["idreg"]};
	cChild = new []{registry.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registry_contrattostipendioview_idreg",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registrylegalstatus.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registrylegalstatus_registry_idreg",cPar,cChild,false));

	cPar = new []{position.Columns["idposition"]};
	cChild = new []{registrylegalstatus.Columns["idposition"]};
	Relations.Add(new DataRelation("FK_registrylegalstatus_position_idposition",cPar,cChild,false));

	cPar = new []{title.Columns["idtitle"]};
	cChild = new []{registry.Columns["idtitle"]};
	Relations.Add(new DataRelation("FK_registry_title_idtitle",cPar,cChild,false));

	#endregion

}
}
}
