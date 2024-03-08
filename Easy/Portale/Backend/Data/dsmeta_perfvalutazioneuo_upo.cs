
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
[System.Xml.Serialization.XmlRoot("dsmeta_perfvalutazioneuo_upo"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_perfvalutazioneuo_upo: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfuointerazioni 		=> (MetaTable)Tables["perfuointerazioni"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getdocentiamministrativiresponsabilinomcognview_alias5 		=> (MetaTable)Tables["getdocentiamministrativiresponsabilinomcognview_alias5"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getdocentiamministrativiresponsabilinomcognview_alias4 		=> (MetaTable)Tables["getdocentiamministrativiresponsabilinomcognview_alias4"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getdocentiamministrativiresponsabilinomcognview_alias3 		=> (MetaTable)Tables["getdocentiamministrativiresponsabilinomcognview_alias3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getdocentiamministrativiresponsabilinomcognview_alias2 		=> (MetaTable)Tables["getdocentiamministrativiresponsabilinomcognview_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfobiettiviuoattach 		=> (MetaTable)Tables["perfobiettiviuoattach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfobiettiviuosoglia 		=> (MetaTable)Tables["perfobiettiviuosoglia"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfobiettiviuo 		=> (MetaTable)Tables["perfobiettiviuo"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attach 		=> (MetaTable)Tables["attach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazioneuoattach 		=> (MetaTable)Tables["perfvalutazioneuoattach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getdocentiamministrativiresponsabilinomcognview_alias1 		=> (MetaTable)Tables["getdocentiamministrativiresponsabilinomcognview_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getdocentiamministrativiresponsabilinomcognview 		=> (MetaTable)Tables["getdocentiamministrativiresponsabilinomcognview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazioneuoindicatorisoglia 		=> (MetaTable)Tables["perfvalutazioneuoindicatorisoglia"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfindicatore 		=> (MetaTable)Tables["perfindicatore"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazioneuoindicatori 		=> (MetaTable)Tables["perfvalutazioneuoindicatori"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettosoglia_alias1 		=> (MetaTable)Tables["perfprogettosoglia_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettoobiettivosoglia 		=> (MetaTable)Tables["perfprogettoobiettivosoglia"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettoobiettivopersonaleview 		=> (MetaTable)Tables["perfprogettoobiettivopersonaleview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettosoglia 		=> (MetaTable)Tables["perfprogettosoglia"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettouoview 		=> (MetaTable)Tables["perfprogettouoview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfschedastatusdefaultview 		=> (MetaTable)Tables["perfschedastatusdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfschedastatus 		=> (MetaTable)Tables["perfschedastatus"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazioneuostatuschanges 		=> (MetaTable)Tables["perfvalutazioneuostatuschanges"];

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
public dsmeta_perfvalutazioneuo_upo(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfvalutazioneuo_upo (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfvalutazioneuo_upo";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfvalutazioneuo_upo.xsd";

	#region create DataTables
	//////////////////// PERFUOINTERAZIONI /////////////////////////////////
	var tperfuointerazioni= new MetaTable("perfuointerazioni");
	tperfuointerazioni.defineColumn("commenti", typeof(string));
	tperfuointerazioni.defineColumn("commentival", typeof(string));
	tperfuointerazioni.defineColumn("ct", typeof(DateTime),false);
	tperfuointerazioni.defineColumn("cu", typeof(string),false);
	tperfuointerazioni.defineColumn("data", typeof(DateTime));
	tperfuointerazioni.defineColumn("idperfinterazionekind", typeof(int),false);
	tperfuointerazioni.defineColumn("idperfuointerazioni", typeof(int),false);
	tperfuointerazioni.defineColumn("idperfvalutazioneuo", typeof(int),false);
	tperfuointerazioni.defineColumn("lt", typeof(DateTime),false);
	tperfuointerazioni.defineColumn("lu", typeof(string),false);
	tperfuointerazioni.defineColumn("utente", typeof(string));
	Tables.Add(tperfuointerazioni);
	tperfuointerazioni.defineKey("idperfuointerazioni", "idperfvalutazioneuo");

	//////////////////// GETDOCENTIAMMINISTRATIVIRESPONSABILINOMCOGNVIEW_ALIAS5 /////////////////////////////////
	var tgetdocentiamministrativiresponsabilinomcognview_alias5= new MetaTable("getdocentiamministrativiresponsabilinomcognview_alias5");
	tgetdocentiamministrativiresponsabilinomcognview_alias5.defineColumn("dropdown_title", typeof(string),false);
	tgetdocentiamministrativiresponsabilinomcognview_alias5.defineColumn("idreg", typeof(int),false);
	tgetdocentiamministrativiresponsabilinomcognview_alias5.defineColumn("ruolo", typeof(string),false);
	tgetdocentiamministrativiresponsabilinomcognview_alias5.defineColumn("struttura", typeof(string),false);
	tgetdocentiamministrativiresponsabilinomcognview_alias5.ExtendedProperties["TableForReading"]="getdocentiamministrativiresponsabilinomcognview";
	Tables.Add(tgetdocentiamministrativiresponsabilinomcognview_alias5);
	tgetdocentiamministrativiresponsabilinomcognview_alias5.defineKey("idreg", "ruolo", "struttura");

	//////////////////// GETDOCENTIAMMINISTRATIVIRESPONSABILINOMCOGNVIEW_ALIAS4 /////////////////////////////////
	var tgetdocentiamministrativiresponsabilinomcognview_alias4= new MetaTable("getdocentiamministrativiresponsabilinomcognview_alias4");
	tgetdocentiamministrativiresponsabilinomcognview_alias4.defineColumn("dropdown_title", typeof(string),false);
	tgetdocentiamministrativiresponsabilinomcognview_alias4.defineColumn("getdocentiamministrativiresponsabili_cf", typeof(string));
	tgetdocentiamministrativiresponsabilinomcognview_alias4.defineColumn("getdocentiamministrativiresponsabili_contratto", typeof(string));
	tgetdocentiamministrativiresponsabilinomcognview_alias4.defineColumn("getdocentiamministrativiresponsabili_extmatricula", typeof(string));
	tgetdocentiamministrativiresponsabilinomcognview_alias4.defineColumn("getdocentiamministrativiresponsabili_forename", typeof(string));
	tgetdocentiamministrativiresponsabilinomcognview_alias4.defineColumn("getdocentiamministrativiresponsabili_istituto", typeof(string));
	tgetdocentiamministrativiresponsabilinomcognview_alias4.defineColumn("getdocentiamministrativiresponsabili_resplevel", typeof(int));
	tgetdocentiamministrativiresponsabilinomcognview_alias4.defineColumn("getdocentiamministrativiresponsabili_ssd", typeof(string));
	tgetdocentiamministrativiresponsabilinomcognview_alias4.defineColumn("idreg", typeof(int),false);
	tgetdocentiamministrativiresponsabilinomcognview_alias4.defineColumn("ruolo", typeof(string),false);
	tgetdocentiamministrativiresponsabilinomcognview_alias4.defineColumn("struttura", typeof(string),false);
	tgetdocentiamministrativiresponsabilinomcognview_alias4.defineColumn("surname", typeof(string));
	tgetdocentiamministrativiresponsabilinomcognview_alias4.ExtendedProperties["TableForReading"]="getdocentiamministrativiresponsabilinomcognview";
	Tables.Add(tgetdocentiamministrativiresponsabilinomcognview_alias4);
	tgetdocentiamministrativiresponsabilinomcognview_alias4.defineKey("idreg", "ruolo", "struttura");

	//////////////////// GETDOCENTIAMMINISTRATIVIRESPONSABILINOMCOGNVIEW_ALIAS3 /////////////////////////////////
	var tgetdocentiamministrativiresponsabilinomcognview_alias3= new MetaTable("getdocentiamministrativiresponsabilinomcognview_alias3");
	tgetdocentiamministrativiresponsabilinomcognview_alias3.defineColumn("dropdown_title", typeof(string),false);
	tgetdocentiamministrativiresponsabilinomcognview_alias3.defineColumn("idreg", typeof(int),false);
	tgetdocentiamministrativiresponsabilinomcognview_alias3.defineColumn("ruolo", typeof(string),false);
	tgetdocentiamministrativiresponsabilinomcognview_alias3.defineColumn("struttura", typeof(string),false);
	tgetdocentiamministrativiresponsabilinomcognview_alias3.ExtendedProperties["TableForReading"]="getdocentiamministrativiresponsabilinomcognview";
	Tables.Add(tgetdocentiamministrativiresponsabilinomcognview_alias3);
	tgetdocentiamministrativiresponsabilinomcognview_alias3.defineKey("idreg", "ruolo", "struttura");

	//////////////////// GETDOCENTIAMMINISTRATIVIRESPONSABILINOMCOGNVIEW_ALIAS2 /////////////////////////////////
	var tgetdocentiamministrativiresponsabilinomcognview_alias2= new MetaTable("getdocentiamministrativiresponsabilinomcognview_alias2");
	tgetdocentiamministrativiresponsabilinomcognview_alias2.defineColumn("dropdown_title", typeof(string),false);
	tgetdocentiamministrativiresponsabilinomcognview_alias2.defineColumn("idreg", typeof(int),false);
	tgetdocentiamministrativiresponsabilinomcognview_alias2.defineColumn("ruolo", typeof(string),false);
	tgetdocentiamministrativiresponsabilinomcognview_alias2.defineColumn("struttura", typeof(string),false);
	tgetdocentiamministrativiresponsabilinomcognview_alias2.ExtendedProperties["TableForReading"]="getdocentiamministrativiresponsabilinomcognview";
	Tables.Add(tgetdocentiamministrativiresponsabilinomcognview_alias2);
	tgetdocentiamministrativiresponsabilinomcognview_alias2.defineKey("idreg", "ruolo", "struttura");

	//////////////////// PERFOBIETTIVIUOATTACH /////////////////////////////////
	var tperfobiettiviuoattach= new MetaTable("perfobiettiviuoattach");
	tperfobiettiviuoattach.defineColumn("idattach", typeof(int),false);
	tperfobiettiviuoattach.defineColumn("idperfobiettiviuo", typeof(int),false);
	tperfobiettiviuoattach.defineColumn("idperfobiettiviuoattach", typeof(int),false);
	tperfobiettiviuoattach.defineColumn("idperfvalutazioneuo", typeof(int),false);
	tperfobiettiviuoattach.defineColumn("title", typeof(string),false);
	Tables.Add(tperfobiettiviuoattach);
	tperfobiettiviuoattach.defineKey("idattach", "idperfobiettiviuo", "idperfobiettiviuoattach", "idperfvalutazioneuo");

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
	tperfobiettiviuo.defineColumn("ct", typeof(DateTime));
	tperfobiettiviuo.defineColumn("cu", typeof(string));
	tperfobiettiviuo.defineColumn("description", typeof(string));
	tperfobiettiviuo.defineColumn("idperfobiettiviuo", typeof(int),false);
	tperfobiettiviuo.defineColumn("idperfvalutazionepersonale", typeof(int));
	tperfobiettiviuo.defineColumn("idperfvalutazioneuo", typeof(int),false);
	tperfobiettiviuo.defineColumn("lt", typeof(DateTime));
	tperfobiettiviuo.defineColumn("lu", typeof(string));
	tperfobiettiviuo.defineColumn("note", typeof(string));
	tperfobiettiviuo.defineColumn("peso", typeof(decimal));
	tperfobiettiviuo.defineColumn("title", typeof(string));
	tperfobiettiviuo.defineColumn("valorenumerico", typeof(decimal));
	tperfobiettiviuo.defineColumn("!perfobiettiviuosoglia", typeof(string));
	tperfobiettiviuo.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tperfobiettiviuo);
	tperfobiettiviuo.defineKey("idperfobiettiviuo", "idperfvalutazioneuo");

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
	tperfvalutazioneuoattach.defineColumn("data", typeof(DateTime));
	tperfvalutazioneuoattach.defineColumn("idattach", typeof(int));
	tperfvalutazioneuoattach.defineColumn("idperfvalutazioneuo", typeof(int),false);
	tperfvalutazioneuoattach.defineColumn("idperfvalutazioneuoattach", typeof(int),false);
	tperfvalutazioneuoattach.defineColumn("lt", typeof(DateTime),false);
	tperfvalutazioneuoattach.defineColumn("lu", typeof(string),false);
	tperfvalutazioneuoattach.defineColumn("!idattach_attach_filename", typeof(string));
	tperfvalutazioneuoattach.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tperfvalutazioneuoattach);
	tperfvalutazioneuoattach.defineKey("idperfvalutazioneuo", "idperfvalutazioneuoattach");

	//////////////////// GETDOCENTIAMMINISTRATIVIRESPONSABILINOMCOGNVIEW_ALIAS1 /////////////////////////////////
	var tgetdocentiamministrativiresponsabilinomcognview_alias1= new MetaTable("getdocentiamministrativiresponsabilinomcognview_alias1");
	tgetdocentiamministrativiresponsabilinomcognview_alias1.defineColumn("dropdown_title", typeof(string),false);
	tgetdocentiamministrativiresponsabilinomcognview_alias1.defineColumn("idreg", typeof(int),false);
	tgetdocentiamministrativiresponsabilinomcognview_alias1.defineColumn("ruolo", typeof(string),false);
	tgetdocentiamministrativiresponsabilinomcognview_alias1.defineColumn("struttura", typeof(string),false);
	tgetdocentiamministrativiresponsabilinomcognview_alias1.ExtendedProperties["TableForReading"]="getdocentiamministrativiresponsabilinomcognview";
	Tables.Add(tgetdocentiamministrativiresponsabilinomcognview_alias1);
	tgetdocentiamministrativiresponsabilinomcognview_alias1.defineKey("idreg", "ruolo", "struttura");

	//////////////////// GETDOCENTIAMMINISTRATIVIRESPONSABILINOMCOGNVIEW /////////////////////////////////
	var tgetdocentiamministrativiresponsabilinomcognview= new MetaTable("getdocentiamministrativiresponsabilinomcognview");
	tgetdocentiamministrativiresponsabilinomcognview.defineColumn("dropdown_title", typeof(string),false);
	tgetdocentiamministrativiresponsabilinomcognview.defineColumn("idreg", typeof(int),false);
	tgetdocentiamministrativiresponsabilinomcognview.defineColumn("ruolo", typeof(string),false);
	tgetdocentiamministrativiresponsabilinomcognview.defineColumn("struttura", typeof(string),false);
	Tables.Add(tgetdocentiamministrativiresponsabilinomcognview);
	tgetdocentiamministrativiresponsabilinomcognview.defineKey("idreg", "ruolo", "struttura");

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
	tperfvalutazioneuoindicatori.defineKey("idperfindicatore", "idperfvalutazioneuo", "idperfvalutazioneuoindicatori");

	//////////////////// PERFPROGETTOSOGLIA_ALIAS1 /////////////////////////////////
	var tperfprogettosoglia_alias1= new MetaTable("perfprogettosoglia_alias1");
	tperfprogettosoglia_alias1.defineColumn("ct", typeof(DateTime),false);
	tperfprogettosoglia_alias1.defineColumn("cu", typeof(string),false);
	tperfprogettosoglia_alias1.defineColumn("description", typeof(string));
	tperfprogettosoglia_alias1.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettosoglia_alias1.defineColumn("idperfprogettosoglia", typeof(int),false);
	tperfprogettosoglia_alias1.defineColumn("idperfsogliakind", typeof(string));
	tperfprogettosoglia_alias1.defineColumn("lt", typeof(DateTime),false);
	tperfprogettosoglia_alias1.defineColumn("lu", typeof(string),false);
	tperfprogettosoglia_alias1.defineColumn("percentuale", typeof(decimal));
	tperfprogettosoglia_alias1.defineColumn("valorenumerico", typeof(decimal));
	tperfprogettosoglia_alias1.ExtendedProperties["TableForReading"]="perfprogettosoglia";
	tperfprogettosoglia_alias1.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tperfprogettosoglia_alias1);
	tperfprogettosoglia_alias1.defineKey("idperfprogetto", "idperfprogettosoglia");

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
	tperfprogettoobiettivopersonaleview.defineColumn("year", typeof(int),false);
	tperfprogettoobiettivopersonaleview.defineColumn("!perfprogettoobiettivosoglia", typeof(string));
	tperfprogettoobiettivopersonaleview.defineColumn("!perfprogettosoglia_alias1", typeof(string));
	Tables.Add(tperfprogettoobiettivopersonaleview);
	tperfprogettoobiettivopersonaleview.defineKey("idperfprogetto", "idperfprogettoobiettivo", "idperfvalutazioneuo", "idstruttura", "year");

	//////////////////// PERFPROGETTOSOGLIA /////////////////////////////////
	var tperfprogettosoglia= new MetaTable("perfprogettosoglia");
	tperfprogettosoglia.defineColumn("ct", typeof(DateTime),false);
	tperfprogettosoglia.defineColumn("cu", typeof(string),false);
	tperfprogettosoglia.defineColumn("description", typeof(string));
	tperfprogettosoglia.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettosoglia.defineColumn("idperfprogettosoglia", typeof(int),false);
	tperfprogettosoglia.defineColumn("idperfsogliakind", typeof(string));
	tperfprogettosoglia.defineColumn("lt", typeof(DateTime),false);
	tperfprogettosoglia.defineColumn("lu", typeof(string),false);
	tperfprogettosoglia.defineColumn("percentuale", typeof(decimal));
	tperfprogettosoglia.defineColumn("valorenumerico", typeof(decimal));
	tperfprogettosoglia.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tperfprogettosoglia);
	tperfprogettosoglia.defineKey("idperfprogetto", "idperfprogettosoglia");

	//////////////////// PERFPROGETTOUOVIEW /////////////////////////////////
	var tperfprogettouoview= new MetaTable("perfprogettouoview");
	tperfprogettouoview.defineColumn("description", typeof(string));
	tperfprogettouoview.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettouoview.defineColumn("idperfvalutazioneuo", typeof(int),false);
	tperfprogettouoview.defineColumn("idstruttura", typeof(int));
	tperfprogettouoview.defineColumn("progetto_title", typeof(string));
	tperfprogettouoview.defineColumn("risultato", typeof(decimal));
	tperfprogettouoview.defineColumn("year", typeof(int),false);
	tperfprogettouoview.defineColumn("!perfprogettosoglia", typeof(string));
	tperfprogettouoview.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tperfprogettouoview);
	tperfprogettouoview.defineKey("idperfprogetto", "idperfvalutazioneuo");

	//////////////////// PERFSCHEDASTATUSDEFAULTVIEW /////////////////////////////////
	var tperfschedastatusdefaultview= new MetaTable("perfschedastatusdefaultview");
	tperfschedastatusdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tperfschedastatusdefaultview.defineColumn("idperfschedastatus", typeof(int),false);
	tperfschedastatusdefaultview.defineColumn("perfschedastatus_active", typeof(string));
	tperfschedastatusdefaultview.defineColumn("perfschedastatus_ct", typeof(DateTime),false);
	tperfschedastatusdefaultview.defineColumn("perfschedastatus_cu", typeof(string),false);
	tperfschedastatusdefaultview.defineColumn("perfschedastatus_description", typeof(string));
	tperfschedastatusdefaultview.defineColumn("perfschedastatus_lt", typeof(DateTime),false);
	tperfschedastatusdefaultview.defineColumn("perfschedastatus_lu", typeof(string),false);
	tperfschedastatusdefaultview.defineColumn("title", typeof(string));
	Tables.Add(tperfschedastatusdefaultview);
	tperfschedastatusdefaultview.defineKey("idperfschedastatus");

	//////////////////// PERFSCHEDASTATUS /////////////////////////////////
	var tperfschedastatus= new MetaTable("perfschedastatus");
	tperfschedastatus.defineColumn("active", typeof(string));
	tperfschedastatus.defineColumn("idperfschedastatus", typeof(int),false);
	tperfschedastatus.defineColumn("title", typeof(string));
	Tables.Add(tperfschedastatus);
	tperfschedastatus.defineKey("idperfschedastatus");

	//////////////////// PERFVALUTAZIONEUOSTATUSCHANGES /////////////////////////////////
	var tperfvalutazioneuostatuschanges= new MetaTable("perfvalutazioneuostatuschanges");
	tperfvalutazioneuostatuschanges.defineColumn("changedate", typeof(DateTime));
	tperfvalutazioneuostatuschanges.defineColumn("changeuser", typeof(string));
	tperfvalutazioneuostatuschanges.defineColumn("ct", typeof(DateTime));
	tperfvalutazioneuostatuschanges.defineColumn("cu", typeof(string));
	tperfvalutazioneuostatuschanges.defineColumn("idperfschedastatus", typeof(int));
	tperfvalutazioneuostatuschanges.defineColumn("idperfvalutazioneuo", typeof(int),false);
	tperfvalutazioneuostatuschanges.defineColumn("idperfvalutazioneuostatuschanges", typeof(int),false);
	tperfvalutazioneuostatuschanges.defineColumn("lt", typeof(DateTime));
	tperfvalutazioneuostatuschanges.defineColumn("lu", typeof(string));
	tperfvalutazioneuostatuschanges.defineColumn("!idperfschedastatus_perfschedastatus_title", typeof(string));
	Tables.Add(tperfvalutazioneuostatuschanges);
	tperfvalutazioneuostatuschanges.defineKey("idperfvalutazioneuo", "idperfvalutazioneuostatuschanges");

	//////////////////// STRUTTURAPERFELENCHIVIEW /////////////////////////////////
	var tstrutturaperfelenchiview= new MetaTable("strutturaperfelenchiview");
	tstrutturaperfelenchiview.defineColumn("aoo_title", typeof(string));
	tstrutturaperfelenchiview.defineColumn("dropdown_title", typeof(string),false);
	tstrutturaperfelenchiview.defineColumn("idstruttura", typeof(int),false);
	tstrutturaperfelenchiview.defineColumn("idupb", typeof(string));
	tstrutturaperfelenchiview.defineColumn("paridstruttura", typeof(int));
	tstrutturaperfelenchiview.defineColumn("sede_title", typeof(string));
	tstrutturaperfelenchiview.defineColumn("struttura_active", typeof(string));
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
	tperfvalutazioneuo.defineColumn("idreg_comp", typeof(int));
	tperfvalutazioneuo.defineColumn("idreg_compobborg", typeof(int));
	tperfvalutazioneuo.defineColumn("idreg_create", typeof(int));
	tperfvalutazioneuo.defineColumn("idreg_val", typeof(int));
	tperfvalutazioneuo.defineColumn("idreg_valobborg", typeof(int));
	tperfvalutazioneuo.defineColumn("idstruttura", typeof(int),false);
	tperfvalutazioneuo.defineColumn("indicatori", typeof(decimal));
	tperfvalutazioneuo.defineColumn("lt", typeof(DateTime),false);
	tperfvalutazioneuo.defineColumn("lu", typeof(string),false);
	tperfvalutazioneuo.defineColumn("motivazione", typeof(string));
	tperfvalutazioneuo.defineColumn("obiettiviindividuali", typeof(decimal));
	tperfvalutazioneuo.defineColumn("pesoindicatori", typeof(decimal));
	tperfvalutazioneuo.defineColumn("pesoobiettivi", typeof(decimal));
	tperfvalutazioneuo.defineColumn("pesoprogaltreuo", typeof(decimal));
	tperfvalutazioneuo.defineColumn("pesoproguo", typeof(decimal));
	tperfvalutazioneuo.defineColumn("risultato", typeof(decimal));
	tperfvalutazioneuo.defineColumn("year", typeof(int),false);
	Tables.Add(tperfvalutazioneuo);
	tperfvalutazioneuo.defineKey("idperfvalutazioneuo", "idstruttura", "year");

	#endregion


	#region DataRelation creation
	var cPar = new []{getdocentiamministrativiresponsabilinomcognview_alias5.Columns["idreg"]};
	var cChild = new []{perfvalutazioneuo.Columns["idreg_appr"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneuo_getdocentiamministrativiresponsabilinomcognview_alias5_idreg_appr",cPar,cChild,false));

	cPar = new []{getdocentiamministrativiresponsabilinomcognview_alias4.Columns["idreg"]};
	cChild = new []{perfvalutazioneuo.Columns["idreg_val"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneuo_getdocentiamministrativiresponsabilinomcognview_alias4_idreg_val",cPar,cChild,false));

	cPar = new []{getdocentiamministrativiresponsabilinomcognview_alias3.Columns["idreg"]};
	cChild = new []{perfvalutazioneuo.Columns["idreg_comp"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneuo_getdocentiamministrativiresponsabilinomcognview_alias3_idreg_comp",cPar,cChild,false));

	cPar = new []{getdocentiamministrativiresponsabilinomcognview_alias2.Columns["idreg"]};
	cChild = new []{perfvalutazioneuo.Columns["idreg_create"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneuo_getdocentiamministrativiresponsabilinomcognview_alias2_idreg_create",cPar,cChild,false));

	cPar = new []{perfvalutazioneuo.Columns["idperfvalutazioneuo"]};
	cChild = new []{perfobiettiviuo.Columns["idperfvalutazioneuo"]};
	Relations.Add(new DataRelation("FK_perfobiettiviuo_perfvalutazioneuo_idperfvalutazioneuo",cPar,cChild,false));

	cPar = new []{perfobiettiviuo.Columns["idperfobiettiviuo"], perfobiettiviuo.Columns["idperfvalutazioneuo"]};
	cChild = new []{perfobiettiviuoattach.Columns["idperfobiettiviuo"], perfobiettiviuoattach.Columns["idperfvalutazioneuo"]};
	Relations.Add(new DataRelation("FK_perfobiettiviuoattach_perfobiettiviuo_idperfobiettiviuo-idperfvalutazioneuo",cPar,cChild,false));

	cPar = new []{perfobiettiviuo.Columns["idperfobiettiviuo"], perfobiettiviuo.Columns["idperfvalutazioneuo"]};
	cChild = new []{perfobiettiviuosoglia.Columns["idperfobiettiviuo"], perfobiettiviuosoglia.Columns["idperfvalutazioneuo"]};
	Relations.Add(new DataRelation("FK_perfobiettiviuosoglia_perfobiettiviuo_idperfobiettiviuo-idperfvalutazioneuo",cPar,cChild,false));

	cPar = new []{perfvalutazioneuo.Columns["idperfvalutazioneuo"]};
	cChild = new []{perfvalutazioneuoattach.Columns["idperfvalutazioneuo"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneuoattach_perfvalutazioneuo_idperfvalutazioneuo",cPar,cChild,false));

	cPar = new []{attach.Columns["idattach"]};
	cChild = new []{perfvalutazioneuoattach.Columns["idattach"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneuoattach_attach_idattach",cPar,cChild,false));

	cPar = new []{getdocentiamministrativiresponsabilinomcognview_alias1.Columns["idreg"]};
	cChild = new []{perfvalutazioneuo.Columns["idreg_valobborg"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneuo_getdocentiamministrativiresponsabilinomcognview_alias1_idreg_valobborg",cPar,cChild,false));

	cPar = new []{getdocentiamministrativiresponsabilinomcognview.Columns["idreg"]};
	cChild = new []{perfvalutazioneuo.Columns["idreg_compobborg"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneuo_getdocentiamministrativiresponsabilinomcognview_idreg_compobborg",cPar,cChild,false));

	cPar = new []{perfvalutazioneuo.Columns["idperfvalutazioneuo"]};
	cChild = new []{perfvalutazioneuoindicatori.Columns["idperfvalutazioneuo"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneuoindicatori_perfvalutazioneuo_idperfvalutazioneuo",cPar,cChild,false));

	cPar = new []{perfvalutazioneuoindicatori.Columns["idperfvalutazioneuoindicatori"]};
	cChild = new []{perfvalutazioneuoindicatorisoglia.Columns["idperfvalutazioneuoindicatori"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneuoindicatorisoglia_perfvalutazioneuoindicatori_idperfvalutazioneuoindicatori",cPar,cChild,false));

	cPar = new []{perfindicatore.Columns["idperfindicatore"]};
	cChild = new []{perfvalutazioneuoindicatori.Columns["idperfindicatore"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneuoindicatori_perfindicatore_idperfindicatore",cPar,cChild,false));

	cPar = new []{perfvalutazioneuo.Columns["idperfvalutazioneuo"], perfvalutazioneuo.Columns["idstruttura"], perfvalutazioneuo.Columns["year"]};
	cChild = new []{perfprogettoobiettivopersonaleview.Columns["idperfvalutazioneuo"], perfprogettoobiettivopersonaleview.Columns["idstruttura"], perfprogettoobiettivopersonaleview.Columns["year"]};
	Relations.Add(new DataRelation("FK_perfprogettoobiettivopersonaleview_perfvalutazioneuo_idperfvalutazioneuo-idstruttura-year",cPar,cChild,false));

	cPar = new []{perfprogettoobiettivopersonaleview.Columns["idperfprogetto"]};
	cChild = new []{perfprogettosoglia_alias1.Columns["idperfprogetto"]};
	Relations.Add(new DataRelation("FK_perfprogettosoglia_alias1_perfprogettoobiettivopersonaleview_idperfprogetto",cPar,cChild,false));

	cPar = new []{perfprogettoobiettivopersonaleview.Columns["idperfprogetto"], perfprogettoobiettivopersonaleview.Columns["idperfprogettoobiettivo"]};
	cChild = new []{perfprogettoobiettivosoglia.Columns["idperfprogetto"], perfprogettoobiettivosoglia.Columns["idperfprogettoobiettivo"]};
	Relations.Add(new DataRelation("FK_perfprogettoobiettivosoglia_perfprogettoobiettivopersonaleview_idperfprogetto-idperfprogettoobiettivo",cPar,cChild,false));

	cPar = new []{perfvalutazioneuo.Columns["idperfvalutazioneuo"], perfvalutazioneuo.Columns["idstruttura"], perfvalutazioneuo.Columns["year"]};
	cChild = new []{perfprogettouoview.Columns["idperfvalutazioneuo"], perfprogettouoview.Columns["idstruttura"], perfprogettouoview.Columns["year"]};
	Relations.Add(new DataRelation("FK_perfprogettouoview_perfvalutazioneuo_idperfvalutazioneuo-idstruttura-year",cPar,cChild,false));

	cPar = new []{perfprogettouoview.Columns["idperfprogetto"]};
	cChild = new []{perfprogettosoglia.Columns["idperfprogetto"]};
	Relations.Add(new DataRelation("FK_perfprogettosoglia_perfprogettouoview_idperfprogetto",cPar,cChild,false));

	cPar = new []{perfschedastatusdefaultview.Columns["idperfschedastatus"]};
	cChild = new []{perfvalutazioneuo.Columns["idperfschedastatus"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneuo_perfschedastatusdefaultview_idperfschedastatus",cPar,cChild,false));

	cPar = new []{perfvalutazioneuo.Columns["idperfvalutazioneuo"]};
	cChild = new []{perfvalutazioneuostatuschanges.Columns["idperfvalutazioneuo"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneuostatuschanges_perfvalutazioneuo_idperfvalutazioneuo",cPar,cChild,false));

	cPar = new []{perfschedastatus.Columns["idperfschedastatus"]};
	cChild = new []{perfvalutazioneuostatuschanges.Columns["idperfschedastatus"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneuostatuschanges_perfschedastatus_idperfschedastatus",cPar,cChild,false));

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
