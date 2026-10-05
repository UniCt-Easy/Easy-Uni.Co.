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
[System.Xml.Serialization.XmlRoot("dsmeta_registry_servizi"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_registry_servizi: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrymultikind 		=> (MetaTable)Tables["registrymultikind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrymultikindregistry 		=> (MetaTable)Tables["registrymultikindregistry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sospensionekind 		=> (MetaTable)Tables["sospensionekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sospensione 		=> (MetaTable)Tables["sospensione"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryattach 		=> (MetaTable)Tables["registryattach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable residence 		=> (MetaTable)Tables["residence"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrykind 		=> (MetaTable)Tables["registrykind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable categorydefaultview 		=> (MetaTable)Tables["categorydefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryclassdefaultview 		=> (MetaTable)Tables["registryclassdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sasddefaultview 		=> (MetaTable)Tables["sasddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable maritalstatusdefaultview 		=> (MetaTable)Tables["maritalstatusdefaultview"];

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
	public MetaTable tiponomina_alias1 		=> (MetaTable)Tables["tiponomina_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable position_alias2 		=> (MetaTable)Tables["position_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable classconsorsuale_alias1 		=> (MetaTable)Tables["classconsorsuale_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable serviziopreruoloinps 		=> (MetaTable)Tables["serviziopreruoloinps"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_city 		=> (MetaTable)Tables["geo_city"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tiponomina 		=> (MetaTable)Tables["tiponomina"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable position_alias1 		=> (MetaTable)Tables["position_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable classconsorsuale 		=> (MetaTable)Tables["classconsorsuale"];

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

	//////////////////// SOSPENSIONEKIND /////////////////////////////////
	var tsospensionekind= new MetaTable("sospensionekind");
	tsospensionekind.defineColumn("active", typeof(string),false);
	tsospensionekind.defineColumn("idsospensionekind", typeof(int),false);
	tsospensionekind.defineColumn("title", typeof(string),false);
	Tables.Add(tsospensionekind);
	tsospensionekind.defineKey("idsospensionekind");

	//////////////////// SOSPENSIONE /////////////////////////////////
	var tsospensione= new MetaTable("sospensione");
	tsospensione.defineColumn("ct", typeof(DateTime),false);
	tsospensione.defineColumn("cu", typeof(string),false);
	tsospensione.defineColumn("idaula", typeof(int));
	tsospensione.defineColumn("idedificio", typeof(int));
	tsospensione.defineColumn("idreg", typeof(int),false);
	tsospensione.defineColumn("idsede", typeof(int));
	tsospensione.defineColumn("idsospensione", typeof(int),false);
	tsospensione.defineColumn("idsospensionekind", typeof(int));
	tsospensione.defineColumn("lt", typeof(DateTime),false);
	tsospensione.defineColumn("lu", typeof(string),false);
	tsospensione.defineColumn("motivo", typeof(string));
	tsospensione.defineColumn("start", typeof(DateTime),false);
	tsospensione.defineColumn("stop", typeof(DateTime));
	tsospensione.defineColumn("!idsospensionekind_sospensionekind_title", typeof(string));
	Tables.Add(tsospensione);
	tsospensione.defineKey("idreg", "idsospensione");

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

	//////////////////// CATEGORYDEFAULTVIEW /////////////////////////////////
	var tcategorydefaultview= new MetaTable("categorydefaultview");
	tcategorydefaultview.defineColumn("category_active", typeof(string));
	tcategorydefaultview.defineColumn("category_ct", typeof(DateTime),false);
	tcategorydefaultview.defineColumn("category_cu", typeof(string),false);
	tcategorydefaultview.defineColumn("category_lt", typeof(DateTime),false);
	tcategorydefaultview.defineColumn("category_lu", typeof(string),false);
	tcategorydefaultview.defineColumn("description", typeof(string),false);
	tcategorydefaultview.defineColumn("idcategory", typeof(string),false);
	Tables.Add(tcategorydefaultview);
	tcategorydefaultview.defineKey("idcategory");

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

	//////////////////// SASDDEFAULTVIEW /////////////////////////////////
	var tsasddefaultview= new MetaTable("sasddefaultview");
	tsasddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tsasddefaultview.defineColumn("idsasd", typeof(int),false);
	Tables.Add(tsasddefaultview);
	tsasddefaultview.defineKey("idsasd");

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

	//////////////////// TIPONOMINA_ALIAS1 /////////////////////////////////
	var ttiponomina_alias1= new MetaTable("tiponomina_alias1");
	ttiponomina_alias1.defineColumn("active", typeof(string));
	ttiponomina_alias1.defineColumn("idtiponomina", typeof(int),false);
	ttiponomina_alias1.defineColumn("title", typeof(string));
	ttiponomina_alias1.ExtendedProperties["TableForReading"]="tiponomina";
	Tables.Add(ttiponomina_alias1);
	ttiponomina_alias1.defineKey("idtiponomina");

	//////////////////// POSITION_ALIAS2 /////////////////////////////////
	var tposition_alias2= new MetaTable("position_alias2");
	tposition_alias2.defineColumn("active", typeof(string));
	tposition_alias2.defineColumn("assegnoaggiuntivo", typeof(string));
	tposition_alias2.defineColumn("codeposition", typeof(string),false);
	tposition_alias2.defineColumn("costolordoannuo", typeof(decimal));
	tposition_alias2.defineColumn("costolordoannuooneri", typeof(decimal));
	tposition_alias2.defineColumn("ct", typeof(DateTime),false);
	tposition_alias2.defineColumn("cu", typeof(string),false);
	tposition_alias2.defineColumn("description", typeof(string),false);
	tposition_alias2.defineColumn("elementoperequativo", typeof(string));
	tposition_alias2.defineColumn("foreignclass", typeof(string));
	tposition_alias2.defineColumn("idposition", typeof(int),false);
	tposition_alias2.defineColumn("indennitadiateneo", typeof(string));
	tposition_alias2.defineColumn("indennitadiposizione", typeof(string));
	tposition_alias2.defineColumn("indvacancacontrattuale", typeof(string));
	tposition_alias2.defineColumn("livello", typeof(string));
	tposition_alias2.defineColumn("lt", typeof(DateTime),false);
	tposition_alias2.defineColumn("lu", typeof(string),false);
	tposition_alias2.defineColumn("maxincomeclass", typeof(int));
	tposition_alias2.defineColumn("oremaxcompitididatempoparziale", typeof(int));
	tposition_alias2.defineColumn("oremaxcompitididatempopieno", typeof(int));
	tposition_alias2.defineColumn("oremaxdidatempoparziale", typeof(int));
	tposition_alias2.defineColumn("oremaxdidatempopieno", typeof(int));
	tposition_alias2.defineColumn("oremaxgg", typeof(int));
	tposition_alias2.defineColumn("oremaxtempoparziale", typeof(int));
	tposition_alias2.defineColumn("oremaxtempopieno", typeof(int));
	tposition_alias2.defineColumn("oremincompitididatempoparziale", typeof(int));
	tposition_alias2.defineColumn("oremincompitididatempopieno", typeof(int));
	tposition_alias2.defineColumn("oremindidatempoparziale", typeof(int));
	tposition_alias2.defineColumn("oremindidatempopieno", typeof(int));
	tposition_alias2.defineColumn("oremintempoparziale", typeof(int));
	tposition_alias2.defineColumn("oremintempopieno", typeof(int));
	tposition_alias2.defineColumn("orestraordinariemax", typeof(int));
	tposition_alias2.defineColumn("parttime", typeof(string));
	tposition_alias2.defineColumn("printingorder", typeof(int));
	tposition_alias2.defineColumn("puntiorganico", typeof(decimal));
	tposition_alias2.defineColumn("siglaesportazione", typeof(string));
	tposition_alias2.defineColumn("siglaimportazione", typeof(string));
	tposition_alias2.defineColumn("tempdef", typeof(string));
	tposition_alias2.defineColumn("tipoente", typeof(string));
	tposition_alias2.defineColumn("tipopersonale", typeof(string));
	tposition_alias2.defineColumn("title", typeof(string));
	tposition_alias2.defineColumn("totaletredicesima", typeof(string));
	tposition_alias2.defineColumn("tredicesimaindennitaintegrativaspeciale", typeof(string));
	tposition_alias2.ExtendedProperties["TableForReading"]="position";
	Tables.Add(tposition_alias2);
	tposition_alias2.defineKey("idposition");

	//////////////////// CLASSCONSORSUALE_ALIAS1 /////////////////////////////////
	var tclassconsorsuale_alias1= new MetaTable("classconsorsuale_alias1");
	tclassconsorsuale_alias1.defineColumn("active", typeof(string),false);
	tclassconsorsuale_alias1.defineColumn("description", typeof(string),false);
	tclassconsorsuale_alias1.defineColumn("idclassconsorsuale", typeof(int),false);
	tclassconsorsuale_alias1.defineColumn("title", typeof(string),false);
	tclassconsorsuale_alias1.ExtendedProperties["TableForReading"]="classconsorsuale";
	Tables.Add(tclassconsorsuale_alias1);
	tclassconsorsuale_alias1.defineKey("idclassconsorsuale");

	//////////////////// SERVIZIOPRERUOLOINPS /////////////////////////////////
	var tserviziopreruoloinps= new MetaTable("serviziopreruoloinps");
	tserviziopreruoloinps.defineColumn("anni", typeof(int));
	tserviziopreruoloinps.defineColumn("annokind", typeof(string));
	tserviziopreruoloinps.defineColumn("cedolini", typeof(string));
	tserviziopreruoloinps.defineColumn("ct", typeof(DateTime),false);
	tserviziopreruoloinps.defineColumn("cu", typeof(string),false);
	tserviziopreruoloinps.defineColumn("giorni", typeof(int));
	tserviziopreruoloinps.defineColumn("idclassconsorsuale", typeof(int));
	tserviziopreruoloinps.defineColumn("idposition", typeof(int));
	tserviziopreruoloinps.defineColumn("idreg", typeof(int),false);
	tserviziopreruoloinps.defineColumn("idserviziopreruoloinps", typeof(int),false);
	tserviziopreruoloinps.defineColumn("idtiponomina", typeof(int));
	tserviziopreruoloinps.defineColumn("istituzione", typeof(string));
	tserviziopreruoloinps.defineColumn("lt", typeof(DateTime),false);
	tserviziopreruoloinps.defineColumn("lu", typeof(string),false);
	tserviziopreruoloinps.defineColumn("mesi", typeof(int));
	tserviziopreruoloinps.defineColumn("start", typeof(DateTime));
	tserviziopreruoloinps.defineColumn("stop", typeof(DateTime));
	tserviziopreruoloinps.defineColumn("!idclassconsorsuale_classconsorsuale_title", typeof(string));
	tserviziopreruoloinps.defineColumn("!idclassconsorsuale_classconsorsuale_description", typeof(string));
	tserviziopreruoloinps.defineColumn("!idposition_position_title", typeof(string));
	tserviziopreruoloinps.defineColumn("!idtiponomina_tiponomina_title", typeof(string));
	Tables.Add(tserviziopreruoloinps);
	tserviziopreruoloinps.defineKey("idreg", "idserviziopreruoloinps");

	//////////////////// GEO_CITY /////////////////////////////////
	var tgeo_city= new MetaTable("geo_city");
	tgeo_city.defineColumn("idcity", typeof(int),false);
	tgeo_city.defineColumn("title", typeof(string));
	Tables.Add(tgeo_city);
	tgeo_city.defineKey("idcity");

	//////////////////// TIPONOMINA /////////////////////////////////
	var ttiponomina= new MetaTable("tiponomina");
	ttiponomina.defineColumn("active", typeof(string));
	ttiponomina.defineColumn("idtiponomina", typeof(int),false);
	ttiponomina.defineColumn("title", typeof(string));
	Tables.Add(ttiponomina);
	ttiponomina.defineKey("idtiponomina");

	//////////////////// POSITION_ALIAS1 /////////////////////////////////
	var tposition_alias1= new MetaTable("position_alias1");
	tposition_alias1.defineColumn("active", typeof(string));
	tposition_alias1.defineColumn("assegnoaggiuntivo", typeof(string));
	tposition_alias1.defineColumn("codeposition", typeof(string),false);
	tposition_alias1.defineColumn("costolordoannuo", typeof(decimal));
	tposition_alias1.defineColumn("costolordoannuooneri", typeof(decimal));
	tposition_alias1.defineColumn("ct", typeof(DateTime),false);
	tposition_alias1.defineColumn("cu", typeof(string),false);
	tposition_alias1.defineColumn("description", typeof(string),false);
	tposition_alias1.defineColumn("elementoperequativo", typeof(string));
	tposition_alias1.defineColumn("foreignclass", typeof(string));
	tposition_alias1.defineColumn("idposition", typeof(int),false);
	tposition_alias1.defineColumn("indennitadiateneo", typeof(string));
	tposition_alias1.defineColumn("indennitadiposizione", typeof(string));
	tposition_alias1.defineColumn("indvacancacontrattuale", typeof(string));
	tposition_alias1.defineColumn("livello", typeof(string));
	tposition_alias1.defineColumn("lt", typeof(DateTime),false);
	tposition_alias1.defineColumn("lu", typeof(string),false);
	tposition_alias1.defineColumn("maxincomeclass", typeof(int));
	tposition_alias1.defineColumn("oremaxcompitididatempoparziale", typeof(int));
	tposition_alias1.defineColumn("oremaxcompitididatempopieno", typeof(int));
	tposition_alias1.defineColumn("oremaxdidatempoparziale", typeof(int));
	tposition_alias1.defineColumn("oremaxdidatempopieno", typeof(int));
	tposition_alias1.defineColumn("oremaxgg", typeof(int));
	tposition_alias1.defineColumn("oremaxtempoparziale", typeof(int));
	tposition_alias1.defineColumn("oremaxtempopieno", typeof(int));
	tposition_alias1.defineColumn("oremincompitididatempoparziale", typeof(int));
	tposition_alias1.defineColumn("oremincompitididatempopieno", typeof(int));
	tposition_alias1.defineColumn("oremindidatempoparziale", typeof(int));
	tposition_alias1.defineColumn("oremindidatempopieno", typeof(int));
	tposition_alias1.defineColumn("oremintempoparziale", typeof(int));
	tposition_alias1.defineColumn("oremintempopieno", typeof(int));
	tposition_alias1.defineColumn("orestraordinariemax", typeof(int));
	tposition_alias1.defineColumn("parttime", typeof(string));
	tposition_alias1.defineColumn("printingorder", typeof(int));
	tposition_alias1.defineColumn("puntiorganico", typeof(decimal));
	tposition_alias1.defineColumn("siglaesportazione", typeof(string));
	tposition_alias1.defineColumn("siglaimportazione", typeof(string));
	tposition_alias1.defineColumn("tempdef", typeof(string));
	tposition_alias1.defineColumn("tipoente", typeof(string));
	tposition_alias1.defineColumn("tipopersonale", typeof(string));
	tposition_alias1.defineColumn("title", typeof(string));
	tposition_alias1.defineColumn("totaletredicesima", typeof(string));
	tposition_alias1.defineColumn("tredicesimaindennitaintegrativaspeciale", typeof(string));
	tposition_alias1.ExtendedProperties["TableForReading"]="position";
	Tables.Add(tposition_alias1);
	tposition_alias1.defineKey("idposition");

	//////////////////// CLASSCONSORSUALE /////////////////////////////////
	var tclassconsorsuale= new MetaTable("classconsorsuale");
	tclassconsorsuale.defineColumn("active", typeof(string),false);
	tclassconsorsuale.defineColumn("description", typeof(string),false);
	tclassconsorsuale.defineColumn("idclassconsorsuale", typeof(int),false);
	tclassconsorsuale.defineColumn("title", typeof(string),false);
	Tables.Add(tclassconsorsuale);
	tclassconsorsuale.defineKey("idclassconsorsuale");

	//////////////////// SERVIZIOPRERUOLOTESORO /////////////////////////////////
	var tserviziopreruolotesoro= new MetaTable("serviziopreruolotesoro");
	tserviziopreruolotesoro.defineColumn("anni", typeof(int));
	tserviziopreruolotesoro.defineColumn("annokind", typeof(string),false);
	tserviziopreruolotesoro.defineColumn("cedolini", typeof(string));
	tserviziopreruolotesoro.defineColumn("ct", typeof(DateTime),false);
	tserviziopreruolotesoro.defineColumn("cu", typeof(string),false);
	tserviziopreruolotesoro.defineColumn("giorni", typeof(int));
	tserviziopreruolotesoro.defineColumn("idclassconsorsuale", typeof(int));
	tserviziopreruolotesoro.defineColumn("idposition", typeof(int));
	tserviziopreruolotesoro.defineColumn("idreg", typeof(int),false);
	tserviziopreruolotesoro.defineColumn("idserviziopreruolotesoro", typeof(int),false);
	tserviziopreruolotesoro.defineColumn("idtiponomina", typeof(int));
	tserviziopreruolotesoro.defineColumn("istituzione", typeof(string));
	tserviziopreruolotesoro.defineColumn("lt", typeof(DateTime),false);
	tserviziopreruolotesoro.defineColumn("lu", typeof(string),false);
	tserviziopreruolotesoro.defineColumn("mesi", typeof(int));
	tserviziopreruolotesoro.defineColumn("start", typeof(DateTime));
	tserviziopreruolotesoro.defineColumn("stop", typeof(DateTime));
	tserviziopreruolotesoro.defineColumn("!idclassconsorsuale_classconsorsuale_title", typeof(string));
	tserviziopreruolotesoro.defineColumn("!idclassconsorsuale_classconsorsuale_description", typeof(string));
	tserviziopreruolotesoro.defineColumn("!idposition_position_title", typeof(string));
	tserviziopreruolotesoro.defineColumn("!idtiponomina_tiponomina_title", typeof(string));
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

	//////////////////// REGISTRYLEGALSTATUS /////////////////////////////////
	var tregistrylegalstatus= new MetaTable("registrylegalstatus");
	tregistrylegalstatus.defineColumn("active", typeof(string));
	tregistrylegalstatus.defineColumn("anni", typeof(int));
	tregistrylegalstatus.defineColumn("annokind", typeof(string));
	tregistrylegalstatus.defineColumn("cedolini", typeof(string));
	tregistrylegalstatus.defineColumn("csa_class", typeof(string));
	tregistrylegalstatus.defineColumn("csa_compartment", typeof(string));
	tregistrylegalstatus.defineColumn("csa_role", typeof(string));
	tregistrylegalstatus.defineColumn("ct", typeof(DateTime));
	tregistrylegalstatus.defineColumn("cu", typeof(string));
	tregistrylegalstatus.defineColumn("datarivalutazione", typeof(DateTime));
	tregistrylegalstatus.defineColumn("flagdefault", typeof(string));
	tregistrylegalstatus.defineColumn("giorni", typeof(int));
	tregistrylegalstatus.defineColumn("idclassconsorsuale", typeof(int));
	tregistrylegalstatus.defineColumn("iddaliaposition", typeof(int));
	tregistrylegalstatus.defineColumn("idinquadramento", typeof(int));
	tregistrylegalstatus.defineColumn("idposition", typeof(int));
	tregistrylegalstatus.defineColumn("idreg", typeof(int),false);
	tregistrylegalstatus.defineColumn("idregistrylegalstatus", typeof(int),false);
	tregistrylegalstatus.defineColumn("idtipologiaruolo", typeof(int));
	tregistrylegalstatus.defineColumn("idtiponomina", typeof(int));
	tregistrylegalstatus.defineColumn("incomeclass", typeof(int));
	tregistrylegalstatus.defineColumn("incomeclassvalidity", typeof(DateTime));
	tregistrylegalstatus.defineColumn("istituzione", typeof(string));
	tregistrylegalstatus.defineColumn("livello", typeof(int));
	tregistrylegalstatus.defineColumn("lt", typeof(DateTime));
	tregistrylegalstatus.defineColumn("lu", typeof(string));
	tregistrylegalstatus.defineColumn("mesi", typeof(int));
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
	ttitle.defineColumn("ct", typeof(DateTime),false);
	ttitle.defineColumn("cu", typeof(string),false);
	ttitle.defineColumn("description", typeof(string),false);
	ttitle.defineColumn("idtitle", typeof(string),false);
	ttitle.defineColumn("lt", typeof(DateTime),false);
	ttitle.defineColumn("lu", typeof(string),false);
	Tables.Add(ttitle);
	ttitle.defineKey("idtitle");

	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new MetaTable("registry");
	tregistry.defineColumn("acronim", typeof(string));
	tregistry.defineColumn("active", typeof(string),false);
	tregistry.defineColumn("annotation", typeof(string));
	tregistry.defineColumn("authorization_free", typeof(string));
	tregistry.defineColumn("badgecode", typeof(string));
	tregistry.defineColumn("birthdate", typeof(DateTime));
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
	tregistry.defineColumn("forename", typeof(string));
	tregistry.defineColumn("gender", typeof(string));
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
	var cChild = new []{registrymultikindregistry.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registrymultikindregistry_registry_idreg",cPar,cChild,false));

	cPar = new []{registrymultikind.Columns["idregistrymultikind"]};
	cChild = new []{registrymultikindregistry.Columns["idregistrymultikind"]};
	Relations.Add(new DataRelation("FK_registrymultikindregistry_registrymultikind_idregistrymultikind",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{sospensione.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_sospensione_registry_idreg",cPar,cChild,false));

	cPar = new []{sospensionekind.Columns["idsospensionekind"]};
	cChild = new []{sospensione.Columns["idsospensionekind"]};
	Relations.Add(new DataRelation("FK_sospensione_sospensionekind_idsospensionekind",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registryattach.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registryattach_registry_idreg",cPar,cChild,false));

	cPar = new []{residence.Columns["idresidence"]};
	cChild = new []{registry.Columns["residence"]};
	Relations.Add(new DataRelation("FK_registry_residence_residence",cPar,cChild,false));

	cPar = new []{registrykind.Columns["idregistrykind"]};
	cChild = new []{registry.Columns["idregistrykind"]};
	Relations.Add(new DataRelation("FK_registry_registrykind_idregistrykind",cPar,cChild,false));

	cPar = new []{categorydefaultview.Columns["idcategory"]};
	cChild = new []{registry.Columns["idcategory"]};
	Relations.Add(new DataRelation("FK_registry_categorydefaultview_idcategory",cPar,cChild,false));

	cPar = new []{registryclassdefaultview.Columns["idregistryclass"]};
	cChild = new []{registry.Columns["idregistryclass"]};
	Relations.Add(new DataRelation("FK_registry_registryclassdefaultview_idregistryclass",cPar,cChild,false));

	cPar = new []{sasddefaultview.Columns["idsasd"]};
	cChild = new []{registry.Columns["idsasd"]};
	Relations.Add(new DataRelation("FK_registry_sasddefaultview_idsasd",cPar,cChild,false));

	cPar = new []{maritalstatusdefaultview.Columns["idmaritalstatus"]};
	cChild = new []{registry.Columns["idmaritalstatus"]};
	Relations.Add(new DataRelation("FK_registry_maritalstatusdefaultview_idmaritalstatus",cPar,cChild,false));

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

	cPar = new []{tiponomina_alias1.Columns["idtiponomina"]};
	cChild = new []{serviziopreruoloinps.Columns["idtiponomina"]};
	Relations.Add(new DataRelation("FK_serviziopreruoloinps_tiponomina_alias1_idtiponomina",cPar,cChild,false));

	cPar = new []{position_alias2.Columns["idposition"]};
	cChild = new []{serviziopreruoloinps.Columns["idposition"]};
	Relations.Add(new DataRelation("FK_serviziopreruoloinps_position_alias2_idposition",cPar,cChild,false));

	cPar = new []{classconsorsuale_alias1.Columns["idclassconsorsuale"]};
	cChild = new []{serviziopreruoloinps.Columns["idclassconsorsuale"]};
	Relations.Add(new DataRelation("FK_serviziopreruoloinps_classconsorsuale_alias1_idclassconsorsuale",cPar,cChild,false));

	cPar = new []{geo_city.Columns["idcity"]};
	cChild = new []{registry.Columns["idcity"]};
	Relations.Add(new DataRelation("FK_registry_geo_city_idcity",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{serviziopreruolotesoro.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_serviziopreruolotesoro_registry_idreg",cPar,cChild,false));

	cPar = new []{tiponomina.Columns["idtiponomina"]};
	cChild = new []{serviziopreruolotesoro.Columns["idtiponomina"]};
	Relations.Add(new DataRelation("FK_serviziopreruolotesoro_tiponomina_idtiponomina",cPar,cChild,false));

	cPar = new []{position_alias1.Columns["idposition"]};
	cChild = new []{serviziopreruolotesoro.Columns["idposition"]};
	Relations.Add(new DataRelation("FK_serviziopreruolotesoro_position_alias1_idposition",cPar,cChild,false));

	cPar = new []{classconsorsuale.Columns["idclassconsorsuale"]};
	cChild = new []{serviziopreruolotesoro.Columns["idclassconsorsuale"]};
	Relations.Add(new DataRelation("FK_serviziopreruolotesoro_classconsorsuale_idclassconsorsuale",cPar,cChild,false));

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
