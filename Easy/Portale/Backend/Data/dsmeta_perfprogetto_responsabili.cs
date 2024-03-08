
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
[System.Xml.Serialization.XmlRoot("dsmeta_perfprogetto_responsabili"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_perfprogetto_responsabili: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettouomembro 		=> (MetaTable)Tables["perfprogettouomembro"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettouo 		=> (MetaTable)Tables["perfprogettouo"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettostatus 		=> (MetaTable)Tables["perfprogettostatus"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettostatuschanges 		=> (MetaTable)Tables["perfprogettostatuschanges"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettoobiettivoattivita_alias2 		=> (MetaTable)Tables["perfprogettoobiettivoattivita_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettoobiettivo_alias2 		=> (MetaTable)Tables["perfprogettoobiettivo_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attach 		=> (MetaTable)Tables["attach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettoobiettivoattivitaattach 		=> (MetaTable)Tables["perfprogettoobiettivoattivitaattach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettoobiettivosoglia 		=> (MetaTable)Tables["perfprogettoobiettivosoglia"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettoobiettivoattivitaattach_alias1 		=> (MetaTable)Tables["perfprogettoobiettivoattivitaattach_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettoobiettivoattivita_alias3 		=> (MetaTable)Tables["perfprogettoobiettivoattivita_alias3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getregistrydocentiamministrativi 		=> (MetaTable)Tables["getregistrydocentiamministrativi"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettoobiettivo 		=> (MetaTable)Tables["perfprogettoobiettivo"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_alias2 		=> (MetaTable)Tables["registry_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable title 		=> (MetaTable)Tables["title"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry 		=> (MetaTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettoavanzamento 		=> (MetaTable)Tables["perfprogettoavanzamento"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettoaccountprevisionview 		=> (MetaTable)Tables["perfprogettoaccountprevisionview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrydefaultview 		=> (MetaTable)Tables["registrydefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogsuddannokinddefaultview 		=> (MetaTable)Tables["didprogsuddannokinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettostatusdefaultview 		=> (MetaTable)Tables["perfprogettostatusdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturadefaultview 		=> (MetaTable)Tables["strutturadefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogetto 		=> (MetaTable)Tables["perfprogetto"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_perfprogetto_responsabili(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfprogetto_responsabili (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfprogetto_responsabili";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfprogetto_responsabili.xsd";

	#region create DataTables
	//////////////////// PERFPROGETTOUOMEMBRO /////////////////////////////////
	var tperfprogettouomembro= new MetaTable("perfprogettouomembro");
	tperfprogettouomembro.defineColumn("agile", typeof(string),false);
	tperfprogettouomembro.defineColumn("ct", typeof(DateTime),false);
	tperfprogettouomembro.defineColumn("cu", typeof(string),false);
	tperfprogettouomembro.defineColumn("idafferenza", typeof(int));
	tperfprogettouomembro.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettouomembro.defineColumn("idperfprogettouo", typeof(int),false);
	tperfprogettouomembro.defineColumn("idreg", typeof(int),false);
	tperfprogettouomembro.defineColumn("lt", typeof(DateTime),false);
	tperfprogettouomembro.defineColumn("lu", typeof(string),false);
	Tables.Add(tperfprogettouomembro);
	tperfprogettouomembro.defineKey("idperfprogetto", "idperfprogettouo", "idreg");

	//////////////////// PERFPROGETTOUO /////////////////////////////////
	var tperfprogettouo= new MetaTable("perfprogettouo");
	tperfprogettouo.defineColumn("!struttura", typeof(string));
	tperfprogettouo.defineColumn("ct", typeof(DateTime),false);
	tperfprogettouo.defineColumn("cu", typeof(string),false);
	tperfprogettouo.defineColumn("description", typeof(string));
	tperfprogettouo.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettouo.defineColumn("idperfprogettouo", typeof(int),false);
	tperfprogettouo.defineColumn("lt", typeof(DateTime),false);
	tperfprogettouo.defineColumn("lu", typeof(string),false);
	tperfprogettouo.defineColumn("title", typeof(string));
	Tables.Add(tperfprogettouo);
	tperfprogettouo.defineKey("idperfprogetto", "idperfprogettouo");

	//////////////////// PERFPROGETTOSTATUS /////////////////////////////////
	var tperfprogettostatus= new MetaTable("perfprogettostatus");
	tperfprogettostatus.defineColumn("active", typeof(string));
	tperfprogettostatus.defineColumn("idperfprogettostatus", typeof(int),false);
	tperfprogettostatus.defineColumn("title", typeof(string));
	Tables.Add(tperfprogettostatus);
	tperfprogettostatus.defineKey("idperfprogettostatus");

	//////////////////// PERFPROGETTOSTATUSCHANGES /////////////////////////////////
	var tperfprogettostatuschanges= new MetaTable("perfprogettostatuschanges");
	tperfprogettostatuschanges.defineColumn("changedate", typeof(DateTime));
	tperfprogettostatuschanges.defineColumn("changeuser", typeof(string));
	tperfprogettostatuschanges.defineColumn("ct", typeof(DateTime));
	tperfprogettostatuschanges.defineColumn("cu", typeof(string));
	tperfprogettostatuschanges.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettostatuschanges.defineColumn("idperfprogettostatus", typeof(int));
	tperfprogettostatuschanges.defineColumn("idperfprogettostatuschanges", typeof(int),false);
	tperfprogettostatuschanges.defineColumn("lt", typeof(DateTime));
	tperfprogettostatuschanges.defineColumn("lu", typeof(string));
	tperfprogettostatuschanges.defineColumn("!idperfprogettostatus_perfprogettostatus_title", typeof(string));
	Tables.Add(tperfprogettostatuschanges);
	tperfprogettostatuschanges.defineKey("idperfprogetto", "idperfprogettostatuschanges");

	//////////////////// PERFPROGETTOOBIETTIVOATTIVITA_ALIAS2 /////////////////////////////////
	var tperfprogettoobiettivoattivita_alias2= new MetaTable("perfprogettoobiettivoattivita_alias2");
	tperfprogettoobiettivoattivita_alias2.defineColumn("datafineprevista", typeof(DateTime));
	tperfprogettoobiettivoattivita_alias2.defineColumn("datainizioprevista", typeof(DateTime));
	tperfprogettoobiettivoattivita_alias2.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettoobiettivoattivita_alias2.defineColumn("idperfprogettoobiettivo", typeof(int),false);
	tperfprogettoobiettivoattivita_alias2.defineColumn("idperfprogettoobiettivoattivita", typeof(int),false);
	tperfprogettoobiettivoattivita_alias2.defineColumn("title", typeof(string));
	tperfprogettoobiettivoattivita_alias2.ExtendedProperties["TableForReading"]="perfprogettoobiettivoattivita";
	Tables.Add(tperfprogettoobiettivoattivita_alias2);
	tperfprogettoobiettivoattivita_alias2.defineKey("idperfprogetto", "idperfprogettoobiettivo", "idperfprogettoobiettivoattivita");

	//////////////////// PERFPROGETTOOBIETTIVO_ALIAS2 /////////////////////////////////
	var tperfprogettoobiettivo_alias2= new MetaTable("perfprogettoobiettivo_alias2");
	tperfprogettoobiettivo_alias2.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettoobiettivo_alias2.defineColumn("idperfprogettoobiettivo", typeof(int),false);
	tperfprogettoobiettivo_alias2.defineColumn("title", typeof(string));
	tperfprogettoobiettivo_alias2.ExtendedProperties["TableForReading"]="perfprogettoobiettivo";
	Tables.Add(tperfprogettoobiettivo_alias2);
	tperfprogettoobiettivo_alias2.defineKey("idperfprogetto", "idperfprogettoobiettivo");

	//////////////////// ATTACH /////////////////////////////////
	var tattach= new MetaTable("attach");
	tattach.defineColumn("attachment", typeof(Byte[]));
	tattach.defineColumn("ct", typeof(DateTime),false);
	tattach.defineColumn("cu", typeof(string),false);
	tattach.defineColumn("filename", typeof(string),false);
	tattach.defineColumn("hash", typeof(string),false);
	tattach.defineColumn("idattach", typeof(int),false);
	tattach.defineColumn("lt", typeof(DateTime),false);
	tattach.defineColumn("lu", typeof(string),false);
	tattach.defineColumn("size", typeof(int),false);
	Tables.Add(tattach);
	tattach.defineKey("idattach");

	//////////////////// PERFPROGETTOOBIETTIVOATTIVITAATTACH /////////////////////////////////
	var tperfprogettoobiettivoattivitaattach= new MetaTable("perfprogettoobiettivoattivitaattach");
	tperfprogettoobiettivoattivitaattach.defineColumn("ct", typeof(DateTime),false);
	tperfprogettoobiettivoattivitaattach.defineColumn("cu", typeof(string),false);
	tperfprogettoobiettivoattivitaattach.defineColumn("data", typeof(DateTime));
	tperfprogettoobiettivoattivitaattach.defineColumn("idattach", typeof(int),false);
	tperfprogettoobiettivoattivitaattach.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettoobiettivoattivitaattach.defineColumn("idperfprogettoobiettivo", typeof(int),false);
	tperfprogettoobiettivoattivitaattach.defineColumn("idperfprogettoobiettivoattivita", typeof(int),false);
	tperfprogettoobiettivoattivitaattach.defineColumn("lt", typeof(DateTime),false);
	tperfprogettoobiettivoattivitaattach.defineColumn("lu", typeof(string),false);
	tperfprogettoobiettivoattivitaattach.defineColumn("!idattach_attach_filename", typeof(string));
	tperfprogettoobiettivoattivitaattach.defineColumn("!idperfprogettoobiettivo_perfprogettoobiettivo_title", typeof(string));
	tperfprogettoobiettivoattivitaattach.defineColumn("!idperfprogettoobiettivoattivita_perfprogettoobiettivoattivita_title", typeof(string));
	tperfprogettoobiettivoattivitaattach.defineColumn("!idperfprogettoobiettivoattivita_perfprogettoobiettivoattivita_datainizioprevista", typeof(DateTime));
	tperfprogettoobiettivoattivitaattach.defineColumn("!idperfprogettoobiettivoattivita_perfprogettoobiettivoattivita_datafineprevista", typeof(DateTime));
	Tables.Add(tperfprogettoobiettivoattivitaattach);
	tperfprogettoobiettivoattivitaattach.defineKey("idattach", "idperfprogetto", "idperfprogettoobiettivo", "idperfprogettoobiettivoattivita");

	//////////////////// PERFPROGETTOOBIETTIVOSOGLIA /////////////////////////////////
	var tperfprogettoobiettivosoglia= new MetaTable("perfprogettoobiettivosoglia");
	tperfprogettoobiettivosoglia.defineColumn("ct", typeof(DateTime),false);
	tperfprogettoobiettivosoglia.defineColumn("cu", typeof(string),false);
	tperfprogettoobiettivosoglia.defineColumn("description", typeof(string));
	tperfprogettoobiettivosoglia.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettoobiettivosoglia.defineColumn("idperfprogettoobiettivo", typeof(int),false);
	tperfprogettoobiettivosoglia.defineColumn("idperfprogettoobiettivosoglia", typeof(int),false);
	tperfprogettoobiettivosoglia.defineColumn("idperfsogliakind", typeof(string));
	tperfprogettoobiettivosoglia.defineColumn("lt", typeof(DateTime),false);
	tperfprogettoobiettivosoglia.defineColumn("lu", typeof(string),false);
	tperfprogettoobiettivosoglia.defineColumn("percentuale", typeof(decimal));
	tperfprogettoobiettivosoglia.defineColumn("valorenumerico", typeof(decimal));
	Tables.Add(tperfprogettoobiettivosoglia);
	tperfprogettoobiettivosoglia.defineKey("idperfprogetto", "idperfprogettoobiettivo", "idperfprogettoobiettivosoglia");

	//////////////////// PERFPROGETTOOBIETTIVOATTIVITAATTACH_ALIAS1 /////////////////////////////////
	var tperfprogettoobiettivoattivitaattach_alias1= new MetaTable("perfprogettoobiettivoattivitaattach_alias1");
	tperfprogettoobiettivoattivitaattach_alias1.defineColumn("ct", typeof(DateTime),false);
	tperfprogettoobiettivoattivitaattach_alias1.defineColumn("cu", typeof(string),false);
	tperfprogettoobiettivoattivitaattach_alias1.defineColumn("data", typeof(DateTime));
	tperfprogettoobiettivoattivitaattach_alias1.defineColumn("idattach", typeof(int),false);
	tperfprogettoobiettivoattivitaattach_alias1.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettoobiettivoattivitaattach_alias1.defineColumn("idperfprogettoobiettivo", typeof(int),false);
	tperfprogettoobiettivoattivitaattach_alias1.defineColumn("idperfprogettoobiettivoattivita", typeof(int),false);
	tperfprogettoobiettivoattivitaattach_alias1.defineColumn("lt", typeof(DateTime),false);
	tperfprogettoobiettivoattivitaattach_alias1.defineColumn("lu", typeof(string),false);
	tperfprogettoobiettivoattivitaattach_alias1.ExtendedProperties["TableForReading"]="perfprogettoobiettivoattivitaattach";
	Tables.Add(tperfprogettoobiettivoattivitaattach_alias1);
	tperfprogettoobiettivoattivitaattach_alias1.defineKey("idattach", "idperfprogetto", "idperfprogettoobiettivo", "idperfprogettoobiettivoattivita");

	//////////////////// PERFPROGETTOOBIETTIVOATTIVITA_ALIAS3 /////////////////////////////////
	var tperfprogettoobiettivoattivita_alias3= new MetaTable("perfprogettoobiettivoattivita_alias3");
	tperfprogettoobiettivoattivita_alias3.defineColumn("completamento", typeof(decimal));
	tperfprogettoobiettivoattivita_alias3.defineColumn("ct", typeof(DateTime),false);
	tperfprogettoobiettivoattivita_alias3.defineColumn("cu", typeof(string),false);
	tperfprogettoobiettivoattivita_alias3.defineColumn("datafineeffettiva", typeof(DateTime));
	tperfprogettoobiettivoattivita_alias3.defineColumn("datafineprevista", typeof(DateTime));
	tperfprogettoobiettivoattivita_alias3.defineColumn("datainizioeffettiva", typeof(DateTime));
	tperfprogettoobiettivoattivita_alias3.defineColumn("datainizioprevista", typeof(DateTime));
	tperfprogettoobiettivoattivita_alias3.defineColumn("description", typeof(string));
	tperfprogettoobiettivoattivita_alias3.defineColumn("idacc", typeof(string));
	tperfprogettoobiettivoattivita_alias3.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettoobiettivoattivita_alias3.defineColumn("idperfprogettoobiettivo", typeof(int),false);
	tperfprogettoobiettivoattivita_alias3.defineColumn("idperfprogettoobiettivoattivita", typeof(int),false);
	tperfprogettoobiettivoattivita_alias3.defineColumn("idreg", typeof(int));
	tperfprogettoobiettivoattivita_alias3.defineColumn("idupb", typeof(string));
	tperfprogettoobiettivoattivita_alias3.defineColumn("lt", typeof(DateTime),false);
	tperfprogettoobiettivoattivita_alias3.defineColumn("lu", typeof(string),false);
	tperfprogettoobiettivoattivita_alias3.defineColumn("paridperfprogettoobiettivoattivita", typeof(int));
	tperfprogettoobiettivoattivita_alias3.defineColumn("title", typeof(string));
	tperfprogettoobiettivoattivita_alias3.ExtendedProperties["TableForReading"]="perfprogettoobiettivoattivita";
	Tables.Add(tperfprogettoobiettivoattivita_alias3);
	tperfprogettoobiettivoattivita_alias3.defineKey("idperfprogetto", "idperfprogettoobiettivo", "idperfprogettoobiettivoattivita");

	//////////////////// GETREGISTRYDOCENTIAMMINISTRATIVI /////////////////////////////////
	var tgetregistrydocentiamministrativi= new MetaTable("getregistrydocentiamministrativi");
	tgetregistrydocentiamministrativi.defineColumn("contratto", typeof(string));
	tgetregistrydocentiamministrativi.defineColumn("extmatricula", typeof(string));
	tgetregistrydocentiamministrativi.defineColumn("forename", typeof(string));
	tgetregistrydocentiamministrativi.defineColumn("idreg", typeof(int),false);
	tgetregistrydocentiamministrativi.defineColumn("surname", typeof(string));
	Tables.Add(tgetregistrydocentiamministrativi);
	tgetregistrydocentiamministrativi.defineKey("idreg");

	//////////////////// PERFPROGETTOOBIETTIVO /////////////////////////////////
	var tperfprogettoobiettivo= new MetaTable("perfprogettoobiettivo");
	tperfprogettoobiettivo.defineColumn("completamento", typeof(decimal));
	tperfprogettoobiettivo.defineColumn("ct", typeof(DateTime),false);
	tperfprogettoobiettivo.defineColumn("cu", typeof(string),false);
	tperfprogettoobiettivo.defineColumn("description", typeof(string));
	tperfprogettoobiettivo.defineColumn("idattach", typeof(int));
	tperfprogettoobiettivo.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettoobiettivo.defineColumn("idperfprogettoobiettivo", typeof(int),false);
	tperfprogettoobiettivo.defineColumn("idreg", typeof(int));
	tperfprogettoobiettivo.defineColumn("lt", typeof(DateTime));
	tperfprogettoobiettivo.defineColumn("lu", typeof(string));
	tperfprogettoobiettivo.defineColumn("peso", typeof(decimal));
	tperfprogettoobiettivo.defineColumn("title", typeof(string));
	tperfprogettoobiettivo.defineColumn("!idreg_getregistrydocentiamministrativi_surname", typeof(string));
	tperfprogettoobiettivo.defineColumn("!idreg_getregistrydocentiamministrativi_forename", typeof(string));
	tperfprogettoobiettivo.defineColumn("!idreg_getregistrydocentiamministrativi_extmatricula", typeof(string));
	tperfprogettoobiettivo.defineColumn("!idreg_getregistrydocentiamministrativi_contratto", typeof(string));
	Tables.Add(tperfprogettoobiettivo);
	tperfprogettoobiettivo.defineKey("idperfprogetto", "idperfprogettoobiettivo");

	//////////////////// REGISTRY_ALIAS2 /////////////////////////////////
	var tregistry_alias2= new MetaTable("registry_alias2");
	tregistry_alias2.defineColumn("active", typeof(string),false);
	tregistry_alias2.defineColumn("cf", typeof(string));
	tregistry_alias2.defineColumn("forename", typeof(string));
	tregistry_alias2.defineColumn("idreg", typeof(int),false);
	tregistry_alias2.defineColumn("idtitle", typeof(string));
	tregistry_alias2.defineColumn("surname", typeof(string));
	tregistry_alias2.ExtendedProperties["TableForReading"]="registry";
	Tables.Add(tregistry_alias2);
	tregistry_alias2.defineKey("idreg");

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
	tregistry.defineColumn("cf", typeof(string));
	tregistry.defineColumn("forename", typeof(string));
	tregistry.defineColumn("idreg", typeof(int),false);
	tregistry.defineColumn("idtitle", typeof(string));
	tregistry.defineColumn("surname", typeof(string));
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// PERFPROGETTOAVANZAMENTO /////////////////////////////////
	var tperfprogettoavanzamento= new MetaTable("perfprogettoavanzamento");
	tperfprogettoavanzamento.defineColumn("avanzamento", typeof(decimal));
	tperfprogettoavanzamento.defineColumn("ct", typeof(DateTime),false);
	tperfprogettoavanzamento.defineColumn("cu", typeof(string),false);
	tperfprogettoavanzamento.defineColumn("data", typeof(DateTime));
	tperfprogettoavanzamento.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettoavanzamento.defineColumn("idperfprogettoavanzamento", typeof(int),false);
	tperfprogettoavanzamento.defineColumn("idreg_amministrativi", typeof(int));
	tperfprogettoavanzamento.defineColumn("idreg_amministrativi_ver", typeof(int));
	tperfprogettoavanzamento.defineColumn("lt", typeof(DateTime),false);
	tperfprogettoavanzamento.defineColumn("lu", typeof(string),false);
	tperfprogettoavanzamento.defineColumn("!idreg_amministrativi_registry_surname", typeof(string));
	tperfprogettoavanzamento.defineColumn("!idreg_amministrativi_registry_forename", typeof(string));
	tperfprogettoavanzamento.defineColumn("!idreg_amministrativi_registry_cf", typeof(string));
	tperfprogettoavanzamento.defineColumn("!idreg_amministrativi_registry_idtitle_description", typeof(string));
	tperfprogettoavanzamento.defineColumn("!idreg_amministrativi_ver_registry_surname", typeof(string));
	tperfprogettoavanzamento.defineColumn("!idreg_amministrativi_ver_registry_forename", typeof(string));
	tperfprogettoavanzamento.defineColumn("!idreg_amministrativi_ver_registry_cf", typeof(string));
	tperfprogettoavanzamento.defineColumn("!idreg_amministrativi_ver_registry_idtitle_description", typeof(string));
	Tables.Add(tperfprogettoavanzamento);
	tperfprogettoavanzamento.defineKey("idperfprogetto", "idperfprogettoavanzamento");

	//////////////////// PERFPROGETTOACCOUNTPREVISIONVIEW /////////////////////////////////
	var tperfprogettoaccountprevisionview= new MetaTable("perfprogettoaccountprevisionview");
	tperfprogettoaccountprevisionview.defineColumn("account", typeof(string));
	tperfprogettoaccountprevisionview.defineColumn("availableprevision", typeof(decimal));
	tperfprogettoaccountprevisionview.defineColumn("codeacc", typeof(string));
	tperfprogettoaccountprevisionview.defineColumn("codeupb", typeof(string));
	tperfprogettoaccountprevisionview.defineColumn("currentprevision", typeof(decimal));
	tperfprogettoaccountprevisionview.defineColumn("idacc", typeof(string));
	tperfprogettoaccountprevisionview.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettoaccountprevisionview.defineColumn("idperfprogettoobiettivo", typeof(int),false);
	tperfprogettoaccountprevisionview.defineColumn("idperfprogettoobiettivoattivita", typeof(int),false);
	tperfprogettoaccountprevisionview.defineColumn("idupb", typeof(string));
	tperfprogettoaccountprevisionview.defineColumn("paridperfprogettoobiettivoattivita", typeof(int));
	tperfprogettoaccountprevisionview.defineColumn("perfprogetto_title", typeof(string));
	tperfprogettoaccountprevisionview.defineColumn("perfprogettoobiettivo_title", typeof(string));
	tperfprogettoaccountprevisionview.defineColumn("perfprogettoobiettivoattivita_title", typeof(string));
	tperfprogettoaccountprevisionview.defineColumn("prevision", typeof(decimal));
	tperfprogettoaccountprevisionview.defineColumn("upb", typeof(string));
	Tables.Add(tperfprogettoaccountprevisionview);
	tperfprogettoaccountprevisionview.defineKey("idperfprogetto", "idperfprogettoobiettivo", "idperfprogettoobiettivoattivita");

	//////////////////// REGISTRYDEFAULTVIEW /////////////////////////////////
	var tregistrydefaultview= new MetaTable("registrydefaultview");
	tregistrydefaultview.defineColumn("dropdown_title", typeof(string),false);
	tregistrydefaultview.defineColumn("idreg", typeof(int),false);
	tregistrydefaultview.defineColumn("registry_active", typeof(string));
	Tables.Add(tregistrydefaultview);
	tregistrydefaultview.defineKey("idreg");

	//////////////////// DIDPROGSUDDANNOKINDDEFAULTVIEW /////////////////////////////////
	var tdidprogsuddannokinddefaultview= new MetaTable("didprogsuddannokinddefaultview");
	tdidprogsuddannokinddefaultview.defineColumn("didprogsuddannokind_active", typeof(string));
	tdidprogsuddannokinddefaultview.defineColumn("didprogsuddannokind_lt", typeof(DateTime),false);
	tdidprogsuddannokinddefaultview.defineColumn("didprogsuddannokind_lu", typeof(string),false);
	tdidprogsuddannokinddefaultview.defineColumn("didprogsuddannokind_sortcode", typeof(int));
	tdidprogsuddannokinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tdidprogsuddannokinddefaultview.defineColumn("iddidprogsuddannokind", typeof(int),false);
	tdidprogsuddannokinddefaultview.defineColumn("title", typeof(string));
	Tables.Add(tdidprogsuddannokinddefaultview);
	tdidprogsuddannokinddefaultview.defineKey("iddidprogsuddannokind");

	//////////////////// PERFPROGETTOSTATUSDEFAULTVIEW /////////////////////////////////
	var tperfprogettostatusdefaultview= new MetaTable("perfprogettostatusdefaultview");
	tperfprogettostatusdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tperfprogettostatusdefaultview.defineColumn("idperfprogettostatus", typeof(int),false);
	tperfprogettostatusdefaultview.defineColumn("perfprogettostatus_active", typeof(string));
	tperfprogettostatusdefaultview.defineColumn("perfprogettostatus_ct", typeof(DateTime),false);
	tperfprogettostatusdefaultview.defineColumn("perfprogettostatus_cu", typeof(string),false);
	tperfprogettostatusdefaultview.defineColumn("perfprogettostatus_description", typeof(string));
	tperfprogettostatusdefaultview.defineColumn("perfprogettostatus_lt", typeof(DateTime),false);
	tperfprogettostatusdefaultview.defineColumn("perfprogettostatus_lu", typeof(string),false);
	tperfprogettostatusdefaultview.defineColumn("title", typeof(string));
	Tables.Add(tperfprogettostatusdefaultview);
	tperfprogettostatusdefaultview.defineKey("idperfprogettostatus");

	//////////////////// STRUTTURADEFAULTVIEW /////////////////////////////////
	var tstrutturadefaultview= new MetaTable("strutturadefaultview");
	tstrutturadefaultview.defineColumn("dropdown_title", typeof(string),false);
	tstrutturadefaultview.defineColumn("idstruttura", typeof(int),false);
	tstrutturadefaultview.defineColumn("struttura_active", typeof(string));
	Tables.Add(tstrutturadefaultview);
	tstrutturadefaultview.defineKey("idstruttura");

	//////////////////// PERFPROGETTO /////////////////////////////////
	var tperfprogetto= new MetaTable("perfprogetto");
	tperfprogetto.defineColumn("benefici", typeof(string));
	tperfprogetto.defineColumn("ct", typeof(DateTime));
	tperfprogetto.defineColumn("cu", typeof(string));
	tperfprogetto.defineColumn("datafineeffettiva", typeof(DateTime));
	tperfprogetto.defineColumn("datafineprevista", typeof(DateTime));
	tperfprogetto.defineColumn("datainizioeffettiva", typeof(DateTime));
	tperfprogetto.defineColumn("datainizioprevista", typeof(DateTime));
	tperfprogetto.defineColumn("description", typeof(string));
	tperfprogetto.defineColumn("iddidprogsuddannokind", typeof(int));
	tperfprogetto.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogetto.defineColumn("idperfprogettostatus", typeof(int));
	tperfprogetto.defineColumn("idreg_respprogetto", typeof(int));
	tperfprogetto.defineColumn("idstruttura", typeof(int),false);
	tperfprogetto.defineColumn("lt", typeof(DateTime));
	tperfprogetto.defineColumn("lu", typeof(string));
	tperfprogetto.defineColumn("note", typeof(string));
	tperfprogetto.defineColumn("risultato", typeof(decimal));
	tperfprogetto.defineColumn("title", typeof(string));
	Tables.Add(tperfprogetto);
	tperfprogetto.defineKey("idperfprogetto");

	#endregion


	#region DataRelation creation
	var cPar = new []{perfprogetto.Columns["idperfprogetto"]};
	var cChild = new []{perfprogettouo.Columns["idperfprogetto"]};
	Relations.Add(new DataRelation("FK_perfprogettouo_perfprogetto_idperfprogetto",cPar,cChild,false));

	cPar = new []{perfprogettouo.Columns["idperfprogetto"], perfprogettouo.Columns["idperfprogettouo"]};
	cChild = new []{perfprogettouomembro.Columns["idperfprogetto"], perfprogettouomembro.Columns["idperfprogettouo"]};
	Relations.Add(new DataRelation("FK_perfprogettouomembro_perfprogettouo_idperfprogetto-idperfprogettouo",cPar,cChild,false));

	cPar = new []{perfprogetto.Columns["idperfprogetto"]};
	cChild = new []{perfprogettostatuschanges.Columns["idperfprogetto"]};
	Relations.Add(new DataRelation("FK_perfprogettostatuschanges_perfprogetto_idperfprogetto",cPar,cChild,false));

	cPar = new []{perfprogettostatus.Columns["idperfprogettostatus"]};
	cChild = new []{perfprogettostatuschanges.Columns["idperfprogettostatus"]};
	Relations.Add(new DataRelation("FK_perfprogettostatuschanges_perfprogettostatus_idperfprogettostatus",cPar,cChild,false));

	cPar = new []{perfprogetto.Columns["idperfprogetto"]};
	cChild = new []{perfprogettoobiettivoattivitaattach.Columns["idperfprogetto"]};
	Relations.Add(new DataRelation("FK_perfprogettoobiettivoattivitaattach_perfprogetto_idperfprogetto",cPar,cChild,false));

	cPar = new []{perfprogettoobiettivoattivita_alias2.Columns["idperfprogettoobiettivoattivita"]};
	cChild = new []{perfprogettoobiettivoattivitaattach.Columns["idperfprogettoobiettivoattivita"]};
	Relations.Add(new DataRelation("FK_perfprogettoobiettivoattivitaattach_perfprogettoobiettivoattivita_alias2_idperfprogettoobiettivoattivita",cPar,cChild,false));

	cPar = new []{perfprogettoobiettivo_alias2.Columns["idperfprogettoobiettivo"]};
	cChild = new []{perfprogettoobiettivoattivitaattach.Columns["idperfprogettoobiettivo"]};
	Relations.Add(new DataRelation("FK_perfprogettoobiettivoattivitaattach_perfprogettoobiettivo_alias2_idperfprogettoobiettivo",cPar,cChild,false));

	cPar = new []{attach.Columns["idattach"]};
	cChild = new []{perfprogettoobiettivoattivitaattach.Columns["idattach"]};
	Relations.Add(new DataRelation("FK_perfprogettoobiettivoattivitaattach_attach_idattach",cPar,cChild,false));

	cPar = new []{perfprogetto.Columns["idperfprogetto"]};
	cChild = new []{perfprogettoobiettivo.Columns["idperfprogetto"]};
	Relations.Add(new DataRelation("FK_perfprogettoobiettivo_perfprogetto_idperfprogetto",cPar,cChild,false));

	cPar = new []{perfprogettoobiettivo.Columns["idperfprogetto"], perfprogettoobiettivo.Columns["idperfprogettoobiettivo"]};
	cChild = new []{perfprogettoobiettivosoglia.Columns["idperfprogetto"], perfprogettoobiettivosoglia.Columns["idperfprogettoobiettivo"]};
	Relations.Add(new DataRelation("FK_perfprogettoobiettivosoglia_perfprogettoobiettivo_idperfprogetto-idperfprogettoobiettivo",cPar,cChild,false));

	cPar = new []{perfprogettoobiettivo.Columns["idperfprogetto"], perfprogettoobiettivo.Columns["idperfprogettoobiettivo"]};
	cChild = new []{perfprogettoobiettivoattivita_alias3.Columns["idperfprogetto"], perfprogettoobiettivoattivita_alias3.Columns["idperfprogettoobiettivo"]};
	Relations.Add(new DataRelation("FK_perfprogettoobiettivoattivita_alias3_perfprogettoobiettivo_idperfprogetto-idperfprogettoobiettivo",cPar,cChild,false));

	cPar = new []{perfprogettoobiettivoattivita_alias3.Columns["idperfprogetto"], perfprogettoobiettivoattivita_alias3.Columns["idperfprogettoobiettivo"], perfprogettoobiettivoattivita_alias3.Columns["idperfprogettoobiettivoattivita"]};
	cChild = new []{perfprogettoobiettivoattivitaattach_alias1.Columns["idperfprogetto"], perfprogettoobiettivoattivitaattach_alias1.Columns["idperfprogettoobiettivo"], perfprogettoobiettivoattivitaattach_alias1.Columns["idperfprogettoobiettivoattivita"]};
	Relations.Add(new DataRelation("FK_perfprogettoobiettivoattivitaattach_alias1_perfprogettoobiettivoattivita_alias3_idperfprogetto-idperfprogettoobiettivo-idperfprogettoobiettivoattivita",cPar,cChild,false));

	cPar = new []{perfprogettoobiettivoattivita_alias3.Columns["idperfprogettoobiettivoattivita"]};
	cChild = new []{perfprogettoobiettivoattivita_alias3.Columns["paridperfprogettoobiettivoattivita"]};
	Relations.Add(new DataRelation("FK_perfprogettoobiettivoattivita_alias3_perfprogettoobiettivoattivita_alias3_idperfprogettoobiettivoattivita",cPar,cChild,false));

	cPar = new []{getregistrydocentiamministrativi.Columns["idreg"]};
	cChild = new []{perfprogettoobiettivo.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_perfprogettoobiettivo_getregistrydocentiamministrativi_idreg",cPar,cChild,false));

	cPar = new []{perfprogetto.Columns["idperfprogetto"]};
	cChild = new []{perfprogettoavanzamento.Columns["idperfprogetto"]};
	Relations.Add(new DataRelation("FK_perfprogettoavanzamento_perfprogetto_idperfprogetto",cPar,cChild,false));

	cPar = new []{registry_alias2.Columns["idreg"]};
	cChild = new []{perfprogettoavanzamento.Columns["idreg_amministrativi_ver"]};
	Relations.Add(new DataRelation("FK_perfprogettoavanzamento_registry_alias2_idreg_amministrativi_ver",cPar,cChild,false));

	cPar = new []{title.Columns["idtitle"]};
	cChild = new []{registry_alias2.Columns["idtitle"]};
	Relations.Add(new DataRelation("FK_registry_alias2_title_idtitle",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{perfprogettoavanzamento.Columns["idreg_amministrativi"]};
	Relations.Add(new DataRelation("FK_perfprogettoavanzamento_registry_idreg_amministrativi",cPar,cChild,false));

	cPar = new []{title.Columns["idtitle"]};
	cChild = new []{registry.Columns["idtitle"]};
	Relations.Add(new DataRelation("FK_registry_title_idtitle",cPar,cChild,false));

	cPar = new []{perfprogettoaccountprevisionview.Columns["idperfprogetto"]};
	cChild = new []{perfprogetto.Columns["idperfprogetto"]};
	Relations.Add(new DataRelation("FK_perfprogetto_perfprogettoaccountprevisionview_idperfprogetto",cPar,cChild,false));

	cPar = new []{registrydefaultview.Columns["idreg"]};
	cChild = new []{perfprogetto.Columns["idreg_respprogetto"]};
	Relations.Add(new DataRelation("FK_perfprogetto_registrydefaultview_idreg_respprogetto",cPar,cChild,false));

	cPar = new []{didprogsuddannokinddefaultview.Columns["iddidprogsuddannokind"]};
	cChild = new []{perfprogetto.Columns["iddidprogsuddannokind"]};
	Relations.Add(new DataRelation("FK_perfprogetto_didprogsuddannokinddefaultview_iddidprogsuddannokind",cPar,cChild,false));

	cPar = new []{perfprogettostatusdefaultview.Columns["idperfprogettostatus"]};
	cChild = new []{perfprogetto.Columns["idperfprogettostatus"]};
	Relations.Add(new DataRelation("FK_perfprogetto_perfprogettostatusdefaultview_idperfprogettostatus",cPar,cChild,false));

	cPar = new []{strutturadefaultview.Columns["idstruttura"]};
	cChild = new []{perfprogetto.Columns["idstruttura"]};
	Relations.Add(new DataRelation("FK_perfprogetto_strutturadefaultview_idstruttura",cPar,cChild,false));

	#endregion

}
}
}
