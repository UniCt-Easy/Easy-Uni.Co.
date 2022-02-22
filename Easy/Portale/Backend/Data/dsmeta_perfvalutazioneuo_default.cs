
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
[System.Xml.Serialization.XmlRoot("dsmeta_perfvalutazioneuo_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_perfvalutazioneuo_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attach 		=> (MetaTable)Tables["attach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazioneuoattach 		=> (MetaTable)Tables["perfvalutazioneuoattach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfobiettiviuosoglia 		=> (MetaTable)Tables["perfobiettiviuosoglia"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfobiettiviuo 		=> (MetaTable)Tables["perfobiettiviuo"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazioneuoindicatorisoglia 		=> (MetaTable)Tables["perfvalutazioneuoindicatorisoglia"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfindicatore 		=> (MetaTable)Tables["perfindicatore"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazioneuoindicatori 		=> (MetaTable)Tables["perfvalutazioneuoindicatori"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettoobiettivosoglia_alias1 		=> (MetaTable)Tables["perfprogettoobiettivosoglia_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettoobiettivopersonaleview 		=> (MetaTable)Tables["perfprogettoobiettivopersonaleview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettoobiettivosoglia 		=> (MetaTable)Tables["perfprogettoobiettivosoglia"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettoobiettivouoview 		=> (MetaTable)Tables["perfprogettoobiettivouoview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getregistrydocentiamministratividefaultview_alias1 		=> (MetaTable)Tables["getregistrydocentiamministratividefaultview_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getregistrydocentiamministratividefaultview 		=> (MetaTable)Tables["getregistrydocentiamministratividefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfschedastatusdefaultview 		=> (MetaTable)Tables["perfschedastatusdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturaperfelenchiview 		=> (MetaTable)Tables["strutturaperfelenchiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable year 		=> (MetaTable)Tables["year"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazioneuo 		=> (MetaTable)Tables["perfvalutazioneuo"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_perfvalutazioneuo_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfvalutazioneuo_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfvalutazioneuo_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfvalutazioneuo_default.xsd";

	#region create DataTables
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

	//////////////////// PERFVALUTAZIONEUOATTACH /////////////////////////////////
	var tperfvalutazioneuoattach= new MetaTable("perfvalutazioneuoattach");
	tperfvalutazioneuoattach.defineColumn("ct", typeof(DateTime),false);
	tperfvalutazioneuoattach.defineColumn("cu", typeof(string),false);
	tperfvalutazioneuoattach.defineColumn("idattach", typeof(int));
	tperfvalutazioneuoattach.defineColumn("idperfvalutazioneuo", typeof(int),false);
	tperfvalutazioneuoattach.defineColumn("idperfvalutazioneuoattach", typeof(int),false);
	tperfvalutazioneuoattach.defineColumn("lt", typeof(DateTime),false);
	tperfvalutazioneuoattach.defineColumn("lu", typeof(string),false);
	tperfvalutazioneuoattach.defineColumn("!idattach_attach_filename", typeof(string));
	tperfvalutazioneuoattach.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tperfvalutazioneuoattach);
	tperfvalutazioneuoattach.defineKey("idperfvalutazioneuo", "idperfvalutazioneuoattach");

	//////////////////// PERFOBIETTIVIUOSOGLIA /////////////////////////////////
	var tperfobiettiviuosoglia= new MetaTable("perfobiettiviuosoglia");
	tperfobiettiviuosoglia.defineColumn("ct", typeof(DateTime),false);
	tperfobiettiviuosoglia.defineColumn("cu", typeof(string),false);
	tperfobiettiviuosoglia.defineColumn("description", typeof(string));
	tperfobiettiviuosoglia.defineColumn("idperfobiettiviuo", typeof(int),false);
	tperfobiettiviuosoglia.defineColumn("idperfobiettiviuosoglia", typeof(int),false);
	tperfobiettiviuosoglia.defineColumn("idperfsogliakind", typeof(string));
	tperfobiettiviuosoglia.defineColumn("idperfvalutazioneuo", typeof(int),false);
	tperfobiettiviuosoglia.defineColumn("lt", typeof(DateTime),false);
	tperfobiettiviuosoglia.defineColumn("lu", typeof(string),false);
	tperfobiettiviuosoglia.defineColumn("percentuale", typeof(decimal));
	tperfobiettiviuosoglia.defineColumn("valorenumerico", typeof(decimal));
	Tables.Add(tperfobiettiviuosoglia);
	tperfobiettiviuosoglia.defineKey("idperfobiettiviuo", "idperfobiettiviuosoglia", "idperfvalutazioneuo");

	//////////////////// PERFOBIETTIVIUO /////////////////////////////////
	var tperfobiettiviuo= new MetaTable("perfobiettiviuo");
	tperfobiettiviuo.defineColumn("completamento", typeof(decimal));
	tperfobiettiviuo.defineColumn("description", typeof(string));
	tperfobiettiviuo.defineColumn("idperfobiettiviuo", typeof(int),false);
	tperfobiettiviuo.defineColumn("idperfvalutazioneuo", typeof(int),false);
	tperfobiettiviuo.defineColumn("peso", typeof(decimal));
	tperfobiettiviuo.defineColumn("title", typeof(string));
	tperfobiettiviuo.defineColumn("valorenumerico", typeof(decimal));
	tperfobiettiviuo.defineColumn("!perfobiettiviuosoglia", typeof(string));
	tperfobiettiviuo.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tperfobiettiviuo);
	tperfobiettiviuo.defineKey("idperfobiettiviuo", "idperfvalutazioneuo");

	//////////////////// PERFVALUTAZIONEUOINDICATORISOGLIA /////////////////////////////////
	var tperfvalutazioneuoindicatorisoglia= new MetaTable("perfvalutazioneuoindicatorisoglia");
	tperfvalutazioneuoindicatorisoglia.defineColumn("ct", typeof(DateTime),false);
	tperfvalutazioneuoindicatorisoglia.defineColumn("cu", typeof(string),false);
	tperfvalutazioneuoindicatorisoglia.defineColumn("description", typeof(string),false);
	tperfvalutazioneuoindicatorisoglia.defineColumn("idperfsogliakind", typeof(string),false);
	tperfvalutazioneuoindicatorisoglia.defineColumn("idperfvalutazioneuoindicatori", typeof(int),false);
	tperfvalutazioneuoindicatorisoglia.defineColumn("idperfvalutazioneuoindicatorisoglia", typeof(int),false);
	tperfvalutazioneuoindicatorisoglia.defineColumn("lt", typeof(DateTime),false);
	tperfvalutazioneuoindicatorisoglia.defineColumn("lu", typeof(string),false);
	tperfvalutazioneuoindicatorisoglia.defineColumn("valore", typeof(decimal),false);
	tperfvalutazioneuoindicatorisoglia.defineColumn("valorenumerico", typeof(decimal));
	tperfvalutazioneuoindicatorisoglia.defineColumn("year", typeof(int),false);
	tperfvalutazioneuoindicatorisoglia.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tperfvalutazioneuoindicatorisoglia);
	tperfvalutazioneuoindicatorisoglia.defineKey("idperfvalutazioneuoindicatori", "idperfvalutazioneuoindicatorisoglia");

	//////////////////// PERFINDICATORE /////////////////////////////////
	var tperfindicatore= new MetaTable("perfindicatore");
	tperfindicatore.defineColumn("ct", typeof(DateTime),false);
	tperfindicatore.defineColumn("cu", typeof(string),false);
	tperfindicatore.defineColumn("description", typeof(string),false);
	tperfindicatore.defineColumn("idperfindicatore", typeof(int),false);
	tperfindicatore.defineColumn("idperfindicatorekind", typeof(int));
	tperfindicatore.defineColumn("inverso", typeof(string));
	tperfindicatore.defineColumn("lt", typeof(DateTime),false);
	tperfindicatore.defineColumn("lu", typeof(string),false);
	tperfindicatore.defineColumn("title", typeof(string));
	Tables.Add(tperfindicatore);
	tperfindicatore.defineKey("idperfindicatore");

	//////////////////// PERFVALUTAZIONEUOINDICATORI /////////////////////////////////
	var tperfvalutazioneuoindicatori= new MetaTable("perfvalutazioneuoindicatori");
	tperfvalutazioneuoindicatori.defineColumn("completamento", typeof(decimal));
	tperfvalutazioneuoindicatori.defineColumn("ct", typeof(DateTime),false);
	tperfvalutazioneuoindicatori.defineColumn("cu", typeof(string),false);
	tperfvalutazioneuoindicatori.defineColumn("idperfindicatore", typeof(int),false);
	tperfvalutazioneuoindicatori.defineColumn("idperfstruttura", typeof(int),false);
	tperfvalutazioneuoindicatori.defineColumn("idperfvalutazioneuo", typeof(int),false);
	tperfvalutazioneuoindicatori.defineColumn("idperfvalutazioneuoindicatori", typeof(int),false);
	tperfvalutazioneuoindicatori.defineColumn("lt", typeof(DateTime),false);
	tperfvalutazioneuoindicatori.defineColumn("lu", typeof(string),false);
	tperfvalutazioneuoindicatori.defineColumn("peso", typeof(decimal));
	tperfvalutazioneuoindicatori.defineColumn("valorenumerico", typeof(decimal));
	tperfvalutazioneuoindicatori.defineColumn("!idperfindicatore_perfindicatore_title", typeof(string));
	tperfvalutazioneuoindicatori.defineColumn("!perfvalutazioneuoindicatorisoglia", typeof(string));
	tperfvalutazioneuoindicatori.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tperfvalutazioneuoindicatori);
	tperfvalutazioneuoindicatori.defineKey("idperfindicatore", "idperfstruttura", "idperfvalutazioneuo", "idperfvalutazioneuoindicatori");

	//////////////////// PERFPROGETTOOBIETTIVOSOGLIA_ALIAS1 /////////////////////////////////
	var tperfprogettoobiettivosoglia_alias1= new MetaTable("perfprogettoobiettivosoglia_alias1");
	tperfprogettoobiettivosoglia_alias1.defineColumn("ct", typeof(DateTime),false);
	tperfprogettoobiettivosoglia_alias1.defineColumn("cu", typeof(string),false);
	tperfprogettoobiettivosoglia_alias1.defineColumn("description", typeof(string));
	tperfprogettoobiettivosoglia_alias1.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettoobiettivosoglia_alias1.defineColumn("idperfprogettoobiettivo", typeof(int),false);
	tperfprogettoobiettivosoglia_alias1.defineColumn("idperfprogettoobiettivosoglia", typeof(int),false);
	tperfprogettoobiettivosoglia_alias1.defineColumn("idperfsogliakind", typeof(string));
	tperfprogettoobiettivosoglia_alias1.defineColumn("lt", typeof(DateTime),false);
	tperfprogettoobiettivosoglia_alias1.defineColumn("lu", typeof(string),false);
	tperfprogettoobiettivosoglia_alias1.defineColumn("percentuale", typeof(decimal));
	tperfprogettoobiettivosoglia_alias1.defineColumn("valorenumerico", typeof(decimal));
	tperfprogettoobiettivosoglia_alias1.ExtendedProperties["TableForReading"]="perfprogettoobiettivosoglia";
	tperfprogettoobiettivosoglia_alias1.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tperfprogettoobiettivosoglia_alias1);
	tperfprogettoobiettivosoglia_alias1.defineKey("idperfprogetto", "idperfprogettoobiettivo", "idperfprogettoobiettivosoglia");

	//////////////////// PERFPROGETTOOBIETTIVOPERSONALEVIEW /////////////////////////////////
	var tperfprogettoobiettivopersonaleview= new MetaTable("perfprogettoobiettivopersonaleview");
	tperfprogettoobiettivopersonaleview.defineColumn("completamento", typeof(decimal));
	tperfprogettoobiettivopersonaleview.defineColumn("description", typeof(string));
	tperfprogettoobiettivopersonaleview.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettoobiettivopersonaleview.defineColumn("idperfprogettoobiettivo", typeof(int),false);
	tperfprogettoobiettivopersonaleview.defineColumn("idperfvalutazioneuo", typeof(int),false);
	tperfprogettoobiettivopersonaleview.defineColumn("idstruttura", typeof(int),false);
	tperfprogettoobiettivopersonaleview.defineColumn("idstruttura_perfprogetto", typeof(int));
	tperfprogettoobiettivopersonaleview.defineColumn("perfprogetto_struttura_title", typeof(string));
	tperfprogettoobiettivopersonaleview.defineColumn("perfprogetto_strutturakind_title", typeof(string),false);
	tperfprogettoobiettivopersonaleview.defineColumn("peso", typeof(decimal));
	tperfprogettoobiettivopersonaleview.defineColumn("progetto_title", typeof(string));
	tperfprogettoobiettivopersonaleview.defineColumn("title", typeof(string));
	tperfprogettoobiettivopersonaleview.defineColumn("!perfprogettoobiettivosoglia_alias1", typeof(string));
	Tables.Add(tperfprogettoobiettivopersonaleview);
	tperfprogettoobiettivopersonaleview.defineKey("idperfprogettoobiettivo", "idperfvalutazioneuo", "idstruttura");

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
	tperfprogettoobiettivosoglia.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tperfprogettoobiettivosoglia);
	tperfprogettoobiettivosoglia.defineKey("idperfprogetto", "idperfprogettoobiettivo", "idperfprogettoobiettivosoglia");

	//////////////////// PERFPROGETTOOBIETTIVOUOVIEW /////////////////////////////////
	var tperfprogettoobiettivouoview= new MetaTable("perfprogettoobiettivouoview");
	tperfprogettoobiettivouoview.defineColumn("completamento", typeof(decimal));
	tperfprogettoobiettivouoview.defineColumn("description", typeof(string));
	tperfprogettoobiettivouoview.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettoobiettivouoview.defineColumn("idperfprogettoobiettivo", typeof(int),false);
	tperfprogettoobiettivouoview.defineColumn("idperfvalutazioneuo", typeof(int),false);
	tperfprogettoobiettivouoview.defineColumn("idstruttura", typeof(int),false);
	tperfprogettoobiettivouoview.defineColumn("peso", typeof(decimal));
	tperfprogettoobiettivouoview.defineColumn("progetto_title", typeof(string));
	tperfprogettoobiettivouoview.defineColumn("title", typeof(string));
	tperfprogettoobiettivouoview.defineColumn("!perfprogettoobiettivosoglia", typeof(string));
	Tables.Add(tperfprogettoobiettivouoview);
	tperfprogettoobiettivouoview.defineKey("idperfprogettoobiettivo", "idperfvalutazioneuo", "idstruttura");

	//////////////////// GETREGISTRYDOCENTIAMMINISTRATIVIDEFAULTVIEW_ALIAS1 /////////////////////////////////
	var tgetregistrydocentiamministratividefaultview_alias1= new MetaTable("getregistrydocentiamministratividefaultview_alias1");
	tgetregistrydocentiamministratividefaultview_alias1.defineColumn("dropdown_title", typeof(string),false);
	tgetregistrydocentiamministratividefaultview_alias1.defineColumn("getregistrydocentiamministrativi_cf", typeof(string));
	tgetregistrydocentiamministratividefaultview_alias1.defineColumn("getregistrydocentiamministrativi_contratto", typeof(string));
	tgetregistrydocentiamministratividefaultview_alias1.defineColumn("getregistrydocentiamministrativi_extmatricula", typeof(string));
	tgetregistrydocentiamministratividefaultview_alias1.defineColumn("getregistrydocentiamministrativi_forename", typeof(string));
	tgetregistrydocentiamministratividefaultview_alias1.defineColumn("getregistrydocentiamministrativi_istituto", typeof(string));
	tgetregistrydocentiamministratividefaultview_alias1.defineColumn("getregistrydocentiamministrativi_ssd", typeof(string));
	tgetregistrydocentiamministratividefaultview_alias1.defineColumn("getregistrydocentiamministrativi_struttura", typeof(string));
	tgetregistrydocentiamministratividefaultview_alias1.defineColumn("idreg", typeof(int),false);
	tgetregistrydocentiamministratividefaultview_alias1.defineColumn("surname", typeof(string));
	tgetregistrydocentiamministratividefaultview_alias1.ExtendedProperties["TableForReading"]="getregistrydocentiamministratividefaultview";
	Tables.Add(tgetregistrydocentiamministratividefaultview_alias1);
	tgetregistrydocentiamministratividefaultview_alias1.defineKey("idreg");

	//////////////////// GETREGISTRYDOCENTIAMMINISTRATIVIDEFAULTVIEW /////////////////////////////////
	var tgetregistrydocentiamministratividefaultview= new MetaTable("getregistrydocentiamministratividefaultview");
	tgetregistrydocentiamministratividefaultview.defineColumn("dropdown_title", typeof(string),false);
	tgetregistrydocentiamministratividefaultview.defineColumn("getregistrydocentiamministrativi_cf", typeof(string));
	tgetregistrydocentiamministratividefaultview.defineColumn("getregistrydocentiamministrativi_contratto", typeof(string));
	tgetregistrydocentiamministratividefaultview.defineColumn("getregistrydocentiamministrativi_extmatricula", typeof(string));
	tgetregistrydocentiamministratividefaultview.defineColumn("getregistrydocentiamministrativi_forename", typeof(string));
	tgetregistrydocentiamministratividefaultview.defineColumn("getregistrydocentiamministrativi_istituto", typeof(string));
	tgetregistrydocentiamministratividefaultview.defineColumn("getregistrydocentiamministrativi_ssd", typeof(string));
	tgetregistrydocentiamministratividefaultview.defineColumn("getregistrydocentiamministrativi_struttura", typeof(string));
	tgetregistrydocentiamministratividefaultview.defineColumn("idreg", typeof(int),false);
	tgetregistrydocentiamministratividefaultview.defineColumn("surname", typeof(string));
	Tables.Add(tgetregistrydocentiamministratividefaultview);
	tgetregistrydocentiamministratividefaultview.defineKey("idreg");

	//////////////////// PERFSCHEDASTATUSDEFAULTVIEW /////////////////////////////////
	var tperfschedastatusdefaultview= new MetaTable("perfschedastatusdefaultview");
	tperfschedastatusdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tperfschedastatusdefaultview.defineColumn("idperfschedastatus", typeof(int),false);
	tperfschedastatusdefaultview.defineColumn("perfschedastatus_active", typeof(string));
	Tables.Add(tperfschedastatusdefaultview);
	tperfschedastatusdefaultview.defineKey("idperfschedastatus");

	//////////////////// STRUTTURAPERFELENCHIVIEW /////////////////////////////////
	var tstrutturaperfelenchiview= new MetaTable("strutturaperfelenchiview");
	tstrutturaperfelenchiview.defineColumn("aoo_title", typeof(string));
	tstrutturaperfelenchiview.defineColumn("dropdown_title", typeof(string),false);
	tstrutturaperfelenchiview.defineColumn("idstruttura", typeof(int),false);
	tstrutturaperfelenchiview.defineColumn("idupb", typeof(string));
	tstrutturaperfelenchiview.defineColumn("paridstruttura", typeof(int));
	tstrutturaperfelenchiview.defineColumn("sede_title", typeof(string));
	tstrutturaperfelenchiview.defineColumn("struttura_codice", typeof(string));
	tstrutturaperfelenchiview.defineColumn("struttura_codiceipa", typeof(string));
	tstrutturaperfelenchiview.defineColumn("struttura_ct", typeof(DateTime),false);
	tstrutturaperfelenchiview.defineColumn("struttura_cu", typeof(string),false);
	tstrutturaperfelenchiview.defineColumn("struttura_email", typeof(string));
	tstrutturaperfelenchiview.defineColumn("struttura_fax", typeof(string));
	tstrutturaperfelenchiview.defineColumn("struttura_idaoo", typeof(int));
	tstrutturaperfelenchiview.defineColumn("struttura_idreg", typeof(int));
	tstrutturaperfelenchiview.defineColumn("struttura_idsede", typeof(int),false);
	tstrutturaperfelenchiview.defineColumn("struttura_idstrutturakind", typeof(int),false);
	tstrutturaperfelenchiview.defineColumn("struttura_lt", typeof(DateTime),false);
	tstrutturaperfelenchiview.defineColumn("struttura_lu", typeof(string),false);
	tstrutturaperfelenchiview.defineColumn("struttura_pesoindicatori", typeof(decimal));
	tstrutturaperfelenchiview.defineColumn("struttura_pesoobiettivi", typeof(decimal));
	tstrutturaperfelenchiview.defineColumn("struttura_pesoprogaltreuo", typeof(decimal));
	tstrutturaperfelenchiview.defineColumn("struttura_pesoproguo", typeof(decimal));
	tstrutturaperfelenchiview.defineColumn("struttura_telefono", typeof(string));
	tstrutturaperfelenchiview.defineColumn("struttura_title_en", typeof(string));
	tstrutturaperfelenchiview.defineColumn("strutturakind_title", typeof(string));
	tstrutturaperfelenchiview.defineColumn("strutturaparent_title", typeof(string));
	tstrutturaperfelenchiview.defineColumn("title", typeof(string));
	tstrutturaperfelenchiview.defineColumn("upb_title", typeof(string));
	Tables.Add(tstrutturaperfelenchiview);
	tstrutturaperfelenchiview.defineKey("idstruttura");

	//////////////////// YEAR /////////////////////////////////
	var tyear= new MetaTable("year");
	tyear.defineColumn("year", typeof(int),false);
	Tables.Add(tyear);
	tyear.defineKey("year");

	//////////////////// PERFVALUTAZIONEUO /////////////////////////////////
	var tperfvalutazioneuo= new MetaTable("perfvalutazioneuo");
	tperfvalutazioneuo.defineColumn("completamentopsauo", typeof(decimal));
	tperfvalutazioneuo.defineColumn("completamentopsuo", typeof(decimal));
	tperfvalutazioneuo.defineColumn("ct", typeof(DateTime),false);
	tperfvalutazioneuo.defineColumn("cu", typeof(string),false);
	tperfvalutazioneuo.defineColumn("idperfschedastatus", typeof(int));
	tperfvalutazioneuo.defineColumn("idperfvalutazioneuo", typeof(int),false);
	tperfvalutazioneuo.defineColumn("idreg_appr", typeof(int));
	tperfvalutazioneuo.defineColumn("idreg_val", typeof(int));
	tperfvalutazioneuo.defineColumn("idstruttura", typeof(int),false);
	tperfvalutazioneuo.defineColumn("indicatori", typeof(decimal));
	tperfvalutazioneuo.defineColumn("lt", typeof(DateTime),false);
	tperfvalutazioneuo.defineColumn("lu", typeof(string),false);
	tperfvalutazioneuo.defineColumn("obiettiviindividuali", typeof(decimal));
	tperfvalutazioneuo.defineColumn("pesoindicatori", typeof(decimal));
	tperfvalutazioneuo.defineColumn("pesoobiettivi", typeof(decimal));
	tperfvalutazioneuo.defineColumn("pesoprogaltreuo", typeof(decimal));
	tperfvalutazioneuo.defineColumn("pesoproguo", typeof(decimal));
	tperfvalutazioneuo.defineColumn("risultato", typeof(decimal));
	tperfvalutazioneuo.defineColumn("year", typeof(int));
	Tables.Add(tperfvalutazioneuo);
	tperfvalutazioneuo.defineKey("idperfvalutazioneuo", "idstruttura");

	#endregion


	#region DataRelation creation
	var cPar = new []{perfvalutazioneuo.Columns["idperfvalutazioneuo"]};
	var cChild = new []{perfvalutazioneuoattach.Columns["idperfvalutazioneuo"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneuoattach_perfvalutazioneuo_idperfvalutazioneuo",cPar,cChild,false));

	cPar = new []{attach.Columns["idattach"]};
	cChild = new []{perfvalutazioneuoattach.Columns["idattach"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneuoattach_attach_idattach",cPar,cChild,false));

	cPar = new []{perfvalutazioneuo.Columns["idperfvalutazioneuo"]};
	cChild = new []{perfobiettiviuo.Columns["idperfvalutazioneuo"]};
	Relations.Add(new DataRelation("FK_perfobiettiviuo_perfvalutazioneuo_idperfvalutazioneuo",cPar,cChild,false));

	cPar = new []{perfobiettiviuo.Columns["idperfobiettiviuo"], perfobiettiviuo.Columns["idperfvalutazioneuo"]};
	cChild = new []{perfobiettiviuosoglia.Columns["idperfobiettiviuo"], perfobiettiviuosoglia.Columns["idperfvalutazioneuo"]};
	Relations.Add(new DataRelation("FK_perfobiettiviuosoglia_perfobiettiviuo_idperfobiettiviuo-idperfvalutazioneuo",cPar,cChild,false));

	cPar = new []{perfvalutazioneuo.Columns["idperfvalutazioneuo"]};
	cChild = new []{perfvalutazioneuoindicatori.Columns["idperfvalutazioneuo"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneuoindicatori_perfvalutazioneuo_idperfvalutazioneuo",cPar,cChild,false));

	cPar = new []{perfvalutazioneuoindicatori.Columns["idperfvalutazioneuoindicatori"]};
	cChild = new []{perfvalutazioneuoindicatorisoglia.Columns["idperfvalutazioneuoindicatori"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneuoindicatorisoglia_perfvalutazioneuoindicatori_idperfvalutazioneuoindicatori",cPar,cChild,false));

	cPar = new []{perfindicatore.Columns["idperfindicatore"]};
	cChild = new []{perfvalutazioneuoindicatori.Columns["idperfindicatore"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneuoindicatori_perfindicatore_idperfindicatore",cPar,cChild,false));

	cPar = new []{perfvalutazioneuo.Columns["idperfvalutazioneuo"], perfvalutazioneuo.Columns["idstruttura"]};
	cChild = new []{perfprogettoobiettivopersonaleview.Columns["idperfvalutazioneuo"], perfprogettoobiettivopersonaleview.Columns["idstruttura"]};
	Relations.Add(new DataRelation("FK_perfprogettoobiettivopersonaleview_perfvalutazioneuo_idperfvalutazioneuo-idstruttura",cPar,cChild,false));

	cPar = new []{perfprogettoobiettivopersonaleview.Columns["idperfprogetto"], perfprogettoobiettivopersonaleview.Columns["idperfprogettoobiettivo"]};
	cChild = new []{perfprogettoobiettivosoglia_alias1.Columns["idperfprogetto"], perfprogettoobiettivosoglia_alias1.Columns["idperfprogettoobiettivo"]};
	Relations.Add(new DataRelation("FK_perfprogettoobiettivosoglia_alias1_perfprogettoobiettivopersonaleview_idperfprogetto-idperfprogettoobiettivo",cPar,cChild,false));

	cPar = new []{perfvalutazioneuo.Columns["idperfvalutazioneuo"], perfvalutazioneuo.Columns["idstruttura"]};
	cChild = new []{perfprogettoobiettivouoview.Columns["idperfvalutazioneuo"], perfprogettoobiettivouoview.Columns["idstruttura"]};
	Relations.Add(new DataRelation("FK_perfprogettoobiettivouoview_perfvalutazioneuo_idperfvalutazioneuo-idstruttura",cPar,cChild,false));

	cPar = new []{perfprogettoobiettivouoview.Columns["idperfprogetto"], perfprogettoobiettivouoview.Columns["idperfprogettoobiettivo"]};
	cChild = new []{perfprogettoobiettivosoglia.Columns["idperfprogetto"], perfprogettoobiettivosoglia.Columns["idperfprogettoobiettivo"]};
	Relations.Add(new DataRelation("FK_perfprogettoobiettivosoglia_perfprogettoobiettivouoview_idperfprogetto-idperfprogettoobiettivo",cPar,cChild,false));

	cPar = new []{getregistrydocentiamministratividefaultview_alias1.Columns["idreg"]};
	cChild = new []{perfvalutazioneuo.Columns["idreg_appr"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneuo_getregistrydocentiamministratividefaultview_alias1_idreg_appr",cPar,cChild,false));

	cPar = new []{getregistrydocentiamministratividefaultview.Columns["idreg"]};
	cChild = new []{perfvalutazioneuo.Columns["idreg_val"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneuo_getregistrydocentiamministratividefaultview_idreg_val",cPar,cChild,false));

	cPar = new []{perfschedastatusdefaultview.Columns["idperfschedastatus"]};
	cChild = new []{perfvalutazioneuo.Columns["idperfschedastatus"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneuo_perfschedastatusdefaultview_idperfschedastatus",cPar,cChild,false));

	cPar = new []{strutturaperfelenchiview.Columns["idstruttura"]};
	cChild = new []{perfvalutazioneuo.Columns["idstruttura"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneuo_strutturaperfelenchiview_idstruttura",cPar,cChild,false));

	cPar = new []{year.Columns["year"]};
	cChild = new []{perfvalutazioneuo.Columns["year"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneuo_year_year",cPar,cChild,false));

	#endregion

}
}
}
