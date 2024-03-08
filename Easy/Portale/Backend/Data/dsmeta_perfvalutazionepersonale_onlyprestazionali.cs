
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
[System.Xml.Serialization.XmlRoot("dsmeta_perfvalutazionepersonale_onlyprestazionali"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_perfvalutazionepersonale_onlyprestazionali: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getdocentiamministrativiresponsabilidefaultview_alias2 		=> (MetaTable)Tables["getdocentiamministrativiresponsabilidefaultview_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getdocentiamministrativiresponsabilidefaultview_alias1 		=> (MetaTable)Tables["getdocentiamministrativiresponsabilidefaultview_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getdocentiamministrativiresponsabilidefaultview 		=> (MetaTable)Tables["getdocentiamministrativiresponsabilidefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazionepersonalesoglia 		=> (MetaTable)Tables["perfvalutazionepersonalesoglia"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazionepersonaleobiettivoattach 		=> (MetaTable)Tables["perfvalutazionepersonaleobiettivoattach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazionepersonaleobiettivo 		=> (MetaTable)Tables["perfvalutazionepersonaleobiettivo"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfobiettiviuosoglia 		=> (MetaTable)Tables["perfobiettiviuosoglia"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfobiettiviuoattach 		=> (MetaTable)Tables["perfobiettiviuoattach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfobiettiviuo 		=> (MetaTable)Tables["perfobiettiviuo"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable afferenzaammview 		=> (MetaTable)Tables["afferenzaammview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getregistrydocentiamministratividefaultview 		=> (MetaTable)Tables["getregistrydocentiamministratividefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfschedastatusdefaultview 		=> (MetaTable)Tables["perfschedastatusdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable year 		=> (MetaTable)Tables["year"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazionepersonale 		=> (MetaTable)Tables["perfvalutazionepersonale"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_perfvalutazionepersonale_onlyprestazionali(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfvalutazionepersonale_onlyprestazionali (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfvalutazionepersonale_onlyprestazionali";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfvalutazionepersonale_onlyprestazionali.xsd";

	#region create DataTables
	//////////////////// GETDOCENTIAMMINISTRATIVIRESPONSABILIDEFAULTVIEW_ALIAS2 /////////////////////////////////
	var tgetdocentiamministrativiresponsabilidefaultview_alias2= new MetaTable("getdocentiamministrativiresponsabilidefaultview_alias2");
	tgetdocentiamministrativiresponsabilidefaultview_alias2.defineColumn("dropdown_title", typeof(string),false);
	tgetdocentiamministrativiresponsabilidefaultview_alias2.defineColumn("getdocentiamministrativiresponsabili_cf", typeof(string));
	tgetdocentiamministrativiresponsabilidefaultview_alias2.defineColumn("getdocentiamministrativiresponsabili_contratto", typeof(string));
	tgetdocentiamministrativiresponsabilidefaultview_alias2.defineColumn("getdocentiamministrativiresponsabili_extmatricula", typeof(string));
	tgetdocentiamministrativiresponsabilidefaultview_alias2.defineColumn("getdocentiamministrativiresponsabili_forename", typeof(string));
	tgetdocentiamministrativiresponsabilidefaultview_alias2.defineColumn("getdocentiamministrativiresponsabili_istituto", typeof(string));
	tgetdocentiamministrativiresponsabilidefaultview_alias2.defineColumn("getdocentiamministrativiresponsabili_resplevel", typeof(int));
	tgetdocentiamministrativiresponsabilidefaultview_alias2.defineColumn("getdocentiamministrativiresponsabili_ssd", typeof(string));
	tgetdocentiamministrativiresponsabilidefaultview_alias2.defineColumn("idreg", typeof(int),false);
	tgetdocentiamministrativiresponsabilidefaultview_alias2.defineColumn("ruolo", typeof(string),false);
	tgetdocentiamministrativiresponsabilidefaultview_alias2.defineColumn("struttura", typeof(string),false);
	tgetdocentiamministrativiresponsabilidefaultview_alias2.defineColumn("surname", typeof(string));
	tgetdocentiamministrativiresponsabilidefaultview_alias2.ExtendedProperties["TableForReading"]="getdocentiamministrativiresponsabilidefaultview";
	Tables.Add(tgetdocentiamministrativiresponsabilidefaultview_alias2);
	tgetdocentiamministrativiresponsabilidefaultview_alias2.defineKey("idreg", "ruolo", "struttura");

	//////////////////// GETDOCENTIAMMINISTRATIVIRESPONSABILIDEFAULTVIEW_ALIAS1 /////////////////////////////////
	var tgetdocentiamministrativiresponsabilidefaultview_alias1= new MetaTable("getdocentiamministrativiresponsabilidefaultview_alias1");
	tgetdocentiamministrativiresponsabilidefaultview_alias1.defineColumn("dropdown_title", typeof(string),false);
	tgetdocentiamministrativiresponsabilidefaultview_alias1.defineColumn("idreg", typeof(int),false);
	tgetdocentiamministrativiresponsabilidefaultview_alias1.defineColumn("ruolo", typeof(string),false);
	tgetdocentiamministrativiresponsabilidefaultview_alias1.defineColumn("struttura", typeof(string),false);
	tgetdocentiamministrativiresponsabilidefaultview_alias1.ExtendedProperties["TableForReading"]="getdocentiamministrativiresponsabilidefaultview";
	Tables.Add(tgetdocentiamministrativiresponsabilidefaultview_alias1);
	tgetdocentiamministrativiresponsabilidefaultview_alias1.defineKey("idreg", "ruolo", "struttura");

	//////////////////// GETDOCENTIAMMINISTRATIVIRESPONSABILIDEFAULTVIEW /////////////////////////////////
	var tgetdocentiamministrativiresponsabilidefaultview= new MetaTable("getdocentiamministrativiresponsabilidefaultview");
	tgetdocentiamministrativiresponsabilidefaultview.defineColumn("dropdown_title", typeof(string),false);
	tgetdocentiamministrativiresponsabilidefaultview.defineColumn("idreg", typeof(int),false);
	tgetdocentiamministrativiresponsabilidefaultview.defineColumn("ruolo", typeof(string),false);
	tgetdocentiamministrativiresponsabilidefaultview.defineColumn("struttura", typeof(string),false);
	Tables.Add(tgetdocentiamministrativiresponsabilidefaultview);
	tgetdocentiamministrativiresponsabilidefaultview.defineKey("idreg", "ruolo", "struttura");

	//////////////////// PERFVALUTAZIONEPERSONALESOGLIA /////////////////////////////////
	var tperfvalutazionepersonalesoglia= new MetaTable("perfvalutazionepersonalesoglia");
	tperfvalutazionepersonalesoglia.defineColumn("ct", typeof(DateTime),false);
	tperfvalutazionepersonalesoglia.defineColumn("cu", typeof(string),false);
	tperfvalutazionepersonalesoglia.defineColumn("description", typeof(string));
	tperfvalutazionepersonalesoglia.defineColumn("idperfsogliakind", typeof(string));
	tperfvalutazionepersonalesoglia.defineColumn("idperfvalutazionepersonale", typeof(int),false);
	tperfvalutazionepersonalesoglia.defineColumn("idperfvalutazionepersonaleobiettivo", typeof(int),false);
	tperfvalutazionepersonalesoglia.defineColumn("idperfvalutazionepersonalesoglia", typeof(int),false);
	tperfvalutazionepersonalesoglia.defineColumn("lt", typeof(DateTime),false);
	tperfvalutazionepersonalesoglia.defineColumn("lu", typeof(string),false);
	tperfvalutazionepersonalesoglia.defineColumn("percentuale", typeof(decimal));
	tperfvalutazionepersonalesoglia.defineColumn("valorenumerico", typeof(decimal));
	Tables.Add(tperfvalutazionepersonalesoglia);
	tperfvalutazionepersonalesoglia.defineKey("idperfvalutazionepersonale", "idperfvalutazionepersonaleobiettivo", "idperfvalutazionepersonalesoglia");

	//////////////////// PERFVALUTAZIONEPERSONALEOBIETTIVOATTACH /////////////////////////////////
	var tperfvalutazionepersonaleobiettivoattach= new MetaTable("perfvalutazionepersonaleobiettivoattach");
	tperfvalutazionepersonaleobiettivoattach.defineColumn("idattach", typeof(int),false);
	tperfvalutazionepersonaleobiettivoattach.defineColumn("idperfvalutazionepersonale", typeof(int),false);
	tperfvalutazionepersonaleobiettivoattach.defineColumn("idperfvalutazionepersonaleobiettivo", typeof(int),false);
	tperfvalutazionepersonaleobiettivoattach.defineColumn("idperfvalutazionepersonaleobiettivoattach", typeof(int),false);
	tperfvalutazionepersonaleobiettivoattach.defineColumn("title", typeof(string),false);
	Tables.Add(tperfvalutazionepersonaleobiettivoattach);
	tperfvalutazionepersonaleobiettivoattach.defineKey("idattach", "idperfvalutazionepersonale", "idperfvalutazionepersonaleobiettivo", "idperfvalutazionepersonaleobiettivoattach");

	//////////////////// PERFVALUTAZIONEPERSONALEOBIETTIVO /////////////////////////////////
	var tperfvalutazionepersonaleobiettivo= new MetaTable("perfvalutazionepersonaleobiettivo");
	tperfvalutazionepersonaleobiettivo.defineColumn("completamento", typeof(decimal));
	tperfvalutazionepersonaleobiettivo.defineColumn("ct", typeof(DateTime),false);
	tperfvalutazionepersonaleobiettivo.defineColumn("cu", typeof(string),false);
	tperfvalutazionepersonaleobiettivo.defineColumn("description", typeof(string));
	tperfvalutazionepersonaleobiettivo.defineColumn("idperfprogettoobiettivoattivita", typeof(int));
	tperfvalutazionepersonaleobiettivo.defineColumn("idperfvalutazionepersonale", typeof(int),false);
	tperfvalutazionepersonaleobiettivo.defineColumn("idperfvalutazionepersonaleobiettivo", typeof(int),false);
	tperfvalutazionepersonaleobiettivo.defineColumn("inverso", typeof(string));
	tperfvalutazionepersonaleobiettivo.defineColumn("lt", typeof(DateTime),false);
	tperfvalutazionepersonaleobiettivo.defineColumn("lu", typeof(string),false);
	tperfvalutazionepersonaleobiettivo.defineColumn("note", typeof(string));
	tperfvalutazionepersonaleobiettivo.defineColumn("peso", typeof(decimal));
	tperfvalutazionepersonaleobiettivo.defineColumn("title", typeof(string));
	tperfvalutazionepersonaleobiettivo.defineColumn("valorenumerico", typeof(decimal));
	tperfvalutazionepersonaleobiettivo.defineColumn("!perfvalutazionepersonalesoglia", typeof(string));
	tperfvalutazionepersonaleobiettivo.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tperfvalutazionepersonaleobiettivo);
	tperfvalutazionepersonaleobiettivo.defineKey("idperfvalutazionepersonale", "idperfvalutazionepersonaleobiettivo");

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
	tperfobiettiviuosoglia.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tperfobiettiviuosoglia);
	tperfobiettiviuosoglia.defineKey("idperfobiettiviuo", "idperfobiettiviuosoglia", "idperfvalutazioneuo");

	//////////////////// PERFOBIETTIVIUOATTACH /////////////////////////////////
	var tperfobiettiviuoattach= new MetaTable("perfobiettiviuoattach");
	tperfobiettiviuoattach.defineColumn("idattach", typeof(int),false);
	tperfobiettiviuoattach.defineColumn("idperfobiettiviuo", typeof(int),false);
	tperfobiettiviuoattach.defineColumn("idperfobiettiviuoattach", typeof(int),false);
	tperfobiettiviuoattach.defineColumn("idperfvalutazioneuo", typeof(int),false);
	tperfobiettiviuoattach.defineColumn("title", typeof(string),false);
	tperfobiettiviuoattach.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tperfobiettiviuoattach);
	tperfobiettiviuoattach.defineKey("idattach", "idperfobiettiviuo", "idperfobiettiviuoattach", "idperfvalutazioneuo");

	//////////////////// PERFOBIETTIVIUO /////////////////////////////////
	var tperfobiettiviuo= new MetaTable("perfobiettiviuo");
	tperfobiettiviuo.defineColumn("completamento", typeof(decimal));
	tperfobiettiviuo.defineColumn("ct", typeof(DateTime));
	tperfobiettiviuo.defineColumn("cu", typeof(string));
	tperfobiettiviuo.defineColumn("description", typeof(string));
	tperfobiettiviuo.defineColumn("idperfobiettiviuo", typeof(int),false);
	tperfobiettiviuo.defineColumn("idperfvalutazionepersonale", typeof(int),false);
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
	tperfobiettiviuo.defineKey("idperfobiettiviuo", "idperfvalutazionepersonale", "idperfvalutazioneuo");

	//////////////////// AFFERENZAAMMVIEW /////////////////////////////////
	var tafferenzaammview= new MetaTable("afferenzaammview");
	tafferenzaammview.defineColumn("afferenza_ct", typeof(DateTime),false);
	tafferenzaammview.defineColumn("afferenza_cu", typeof(string),false);
	tafferenzaammview.defineColumn("afferenza_idmansionekind", typeof(int));
	tafferenzaammview.defineColumn("afferenza_lt", typeof(DateTime),false);
	tafferenzaammview.defineColumn("afferenza_lu", typeof(string),false);
	tafferenzaammview.defineColumn("afferenza_start", typeof(DateTime));
	tafferenzaammview.defineColumn("afferenza_stop", typeof(DateTime));
	tafferenzaammview.defineColumn("dropdown_title", typeof(string),false);
	tafferenzaammview.defineColumn("idafferenza", typeof(int),false);
	tafferenzaammview.defineColumn("idreg", typeof(int),false);
	tafferenzaammview.defineColumn("idstruttura", typeof(int));
	tafferenzaammview.defineColumn("mansionekind_title", typeof(string));
	tafferenzaammview.defineColumn("struttura_paridstruttura", typeof(int));
	tafferenzaammview.defineColumn("struttura_title", typeof(string));
	tafferenzaammview.defineColumn("strutturaparent_title", typeof(string));
	Tables.Add(tafferenzaammview);
	tafferenzaammview.defineKey("idafferenza", "idreg");

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
	tperfschedastatusdefaultview.defineColumn("perfschedastatus_ct", typeof(DateTime),false);
	tperfschedastatusdefaultview.defineColumn("perfschedastatus_cu", typeof(string),false);
	tperfschedastatusdefaultview.defineColumn("perfschedastatus_description", typeof(string));
	tperfschedastatusdefaultview.defineColumn("perfschedastatus_lt", typeof(DateTime),false);
	tperfschedastatusdefaultview.defineColumn("perfschedastatus_lu", typeof(string),false);
	tperfschedastatusdefaultview.defineColumn("title", typeof(string));
	Tables.Add(tperfschedastatusdefaultview);
	tperfschedastatusdefaultview.defineKey("idperfschedastatus");

	//////////////////// YEAR /////////////////////////////////
	var tyear= new MetaTable("year");
	tyear.defineColumn("year", typeof(int),false);
	Tables.Add(tyear);
	tyear.defineKey("year");

	//////////////////// PERFVALUTAZIONEPERSONALE /////////////////////////////////
	var tperfvalutazionepersonale= new MetaTable("perfvalutazionepersonale");
	tperfvalutazionepersonale.defineColumn("ct", typeof(DateTime),false);
	tperfvalutazionepersonale.defineColumn("cu", typeof(string),false);
	tperfvalutazionepersonale.defineColumn("idafferenza", typeof(int),false);
	tperfvalutazionepersonale.defineColumn("idperfschedastatus", typeof(int));
	tperfvalutazionepersonale.defineColumn("idperfvalutazionepersonale", typeof(int),false);
	tperfvalutazionepersonale.defineColumn("idreg", typeof(int),false);
	tperfvalutazionepersonale.defineColumn("idreg_appr", typeof(int));
	tperfvalutazionepersonale.defineColumn("idreg_comp", typeof(int));
	tperfvalutazionepersonale.defineColumn("idreg_compcomp", typeof(int));
	tperfvalutazionepersonale.defineColumn("idreg_create", typeof(int));
	tperfvalutazionepersonale.defineColumn("idreg_val", typeof(int));
	tperfvalutazionepersonale.defineColumn("idreg_valcomp", typeof(int));
	tperfvalutazionepersonale.defineColumn("lt", typeof(DateTime),false);
	tperfvalutazionepersonale.defineColumn("lu", typeof(string),false);
	tperfvalutazionepersonale.defineColumn("percateneo", typeof(decimal));
	tperfvalutazionepersonale.defineColumn("perccomportamenti", typeof(decimal));
	tperfvalutazionepersonale.defineColumn("percobiettivi", typeof(decimal));
	tperfvalutazionepersonale.defineColumn("percperfuo", typeof(decimal));
	tperfvalutazionepersonale.defineColumn("pesoateneo", typeof(decimal));
	tperfvalutazionepersonale.defineColumn("pesocomportamenti", typeof(decimal));
	tperfvalutazionepersonale.defineColumn("pesoobiettivi", typeof(decimal));
	tperfvalutazionepersonale.defineColumn("pesoperfuo", typeof(decimal));
	tperfvalutazionepersonale.defineColumn("risultato", typeof(decimal));
	tperfvalutazionepersonale.defineColumn("year", typeof(int));
	Tables.Add(tperfvalutazionepersonale);
	tperfvalutazionepersonale.defineKey("idafferenza", "idperfvalutazionepersonale", "idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{getdocentiamministrativiresponsabilidefaultview_alias2.Columns["idreg"]};
	var cChild = new []{perfvalutazionepersonale.Columns["idreg_val"]};
	Relations.Add(new DataRelation("FK_perfvalutazionepersonale_getdocentiamministrativiresponsabilidefaultview_alias2_idreg_val",cPar,cChild,false));

	cPar = new []{getdocentiamministrativiresponsabilidefaultview_alias1.Columns["idreg"]};
	cChild = new []{perfvalutazionepersonale.Columns["idreg_comp"]};
	Relations.Add(new DataRelation("FK_perfvalutazionepersonale_getdocentiamministrativiresponsabilidefaultview_alias1_idreg_comp",cPar,cChild,false));

	cPar = new []{getdocentiamministrativiresponsabilidefaultview.Columns["idreg"]};
	cChild = new []{perfvalutazionepersonale.Columns["idreg_create"]};
	Relations.Add(new DataRelation("FK_perfvalutazionepersonale_getdocentiamministrativiresponsabilidefaultview_idreg_create",cPar,cChild,false));

	cPar = new []{perfvalutazionepersonale.Columns["idperfvalutazionepersonale"]};
	cChild = new []{perfvalutazionepersonaleobiettivo.Columns["idperfvalutazionepersonale"]};
	Relations.Add(new DataRelation("FK_perfvalutazionepersonaleobiettivo_perfvalutazionepersonale_idperfvalutazionepersonale",cPar,cChild,false));

	cPar = new []{perfvalutazionepersonaleobiettivo.Columns["idperfvalutazionepersonale"], perfvalutazionepersonaleobiettivo.Columns["idperfvalutazionepersonaleobiettivo"]};
	cChild = new []{perfvalutazionepersonalesoglia.Columns["idperfvalutazionepersonale"], perfvalutazionepersonalesoglia.Columns["idperfvalutazionepersonaleobiettivo"]};
	Relations.Add(new DataRelation("FK_perfvalutazionepersonalesoglia_perfvalutazionepersonaleobiettivo_idperfvalutazionepersonale-idperfvalutazionepersonaleobiettivo",cPar,cChild,false));

	cPar = new []{perfvalutazionepersonaleobiettivo.Columns["idperfvalutazionepersonale"], perfvalutazionepersonaleobiettivo.Columns["idperfvalutazionepersonaleobiettivo"]};
	cChild = new []{perfvalutazionepersonaleobiettivoattach.Columns["idperfvalutazionepersonale"], perfvalutazionepersonaleobiettivoattach.Columns["idperfvalutazionepersonaleobiettivo"]};
	Relations.Add(new DataRelation("FK_perfvalutazionepersonaleobiettivoattach_perfvalutazionepersonaleobiettivo_idperfvalutazionepersonale-idperfvalutazionepersonaleobiettivo",cPar,cChild,false));

	cPar = new []{perfvalutazionepersonale.Columns["idperfvalutazionepersonale"]};
	cChild = new []{perfobiettiviuo.Columns["idperfvalutazionepersonale"]};
	Relations.Add(new DataRelation("FK_perfobiettiviuo_perfvalutazionepersonale_idperfvalutazionepersonale",cPar,cChild,false));

	cPar = new []{perfobiettiviuo.Columns["idperfobiettiviuo"], perfobiettiviuo.Columns["idperfvalutazioneuo"]};
	cChild = new []{perfobiettiviuosoglia.Columns["idperfobiettiviuo"], perfobiettiviuosoglia.Columns["idperfvalutazioneuo"]};
	Relations.Add(new DataRelation("FK_perfobiettiviuosoglia_perfobiettiviuo_idperfobiettiviuo-idperfvalutazioneuo",cPar,cChild,false));

	cPar = new []{perfobiettiviuo.Columns["idperfobiettiviuo"], perfobiettiviuo.Columns["idperfvalutazioneuo"]};
	cChild = new []{perfobiettiviuoattach.Columns["idperfobiettiviuo"], perfobiettiviuoattach.Columns["idperfvalutazioneuo"]};
	Relations.Add(new DataRelation("FK_perfobiettiviuoattach_perfobiettiviuo_idperfobiettiviuo-idperfvalutazioneuo",cPar,cChild,false));

	cPar = new []{afferenzaammview.Columns["idafferenza"]};
	cChild = new []{perfvalutazionepersonale.Columns["idafferenza"]};
	Relations.Add(new DataRelation("FK_perfvalutazionepersonale_afferenzaammview_idafferenza",cPar,cChild,false));

	cPar = new []{getregistrydocentiamministratividefaultview.Columns["idreg"]};
	cChild = new []{perfvalutazionepersonale.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_perfvalutazionepersonale_getregistrydocentiamministratividefaultview_idreg",cPar,cChild,false));

	cPar = new []{perfschedastatusdefaultview.Columns["idperfschedastatus"]};
	cChild = new []{perfvalutazionepersonale.Columns["idperfschedastatus"]};
	Relations.Add(new DataRelation("FK_perfvalutazionepersonale_perfschedastatusdefaultview_idperfschedastatus",cPar,cChild,false));

	cPar = new []{year.Columns["year"]};
	cChild = new []{perfvalutazionepersonale.Columns["year"]};
	Relations.Add(new DataRelation("FK_perfvalutazionepersonale_year_year",cPar,cChild,false));

	#endregion

}
}
}
