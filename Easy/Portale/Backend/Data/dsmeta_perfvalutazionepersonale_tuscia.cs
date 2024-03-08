
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
[System.Xml.Serialization.XmlRoot("dsmeta_perfvalutazionepersonale_tuscia"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_perfvalutazionepersonale_tuscia: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfinterazioni 		=> (MetaTable)Tables["perfinterazioni"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attach 		=> (MetaTable)Tables["attach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazionepersonaleattach 		=> (MetaTable)Tables["perfvalutazionepersonaleattach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getdocentiamministrativiresponsabilidefaultview_alias5 		=> (MetaTable)Tables["getdocentiamministrativiresponsabilidefaultview_alias5"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getdocentiamministrativiresponsabilidefaultview_alias4 		=> (MetaTable)Tables["getdocentiamministrativiresponsabilidefaultview_alias4"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getdocentiamministrativiresponsabilidefaultview_alias3 		=> (MetaTable)Tables["getdocentiamministrativiresponsabilidefaultview_alias3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getdocentiamministrativiresponsabilidefaultview_alias2 		=> (MetaTable)Tables["getdocentiamministrativiresponsabilidefaultview_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazionepersonalesoglia 		=> (MetaTable)Tables["perfvalutazionepersonalesoglia"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazionepersonaleobiettivoattach 		=> (MetaTable)Tables["perfvalutazionepersonaleobiettivoattach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazionepersonaleobiettivo 		=> (MetaTable)Tables["perfvalutazionepersonaleobiettivo"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getdocentiamministrativiresponsabilidefaultview_alias1 		=> (MetaTable)Tables["getdocentiamministrativiresponsabilidefaultview_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getdocentiamministrativiresponsabilidefaultview 		=> (MetaTable)Tables["getdocentiamministrativiresponsabilidefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazionepersonalecomportamentosoglia 		=> (MetaTable)Tables["perfvalutazionepersonalecomportamentosoglia"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfgiudiziodefaultview 		=> (MetaTable)Tables["perfgiudiziodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfcomportamento 		=> (MetaTable)Tables["perfcomportamento"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazionepersonalecomportamento 		=> (MetaTable)Tables["perfvalutazionepersonalecomportamento"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturakind 		=> (MetaTable)Tables["strutturakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable struttura 		=> (MetaTable)Tables["struttura"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazionepersonaleuo 		=> (MetaTable)Tables["perfvalutazionepersonaleuo"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazionepersonaleateneo 		=> (MetaTable)Tables["perfvalutazionepersonaleateneo"];

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
public dsmeta_perfvalutazionepersonale_tuscia(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfvalutazionepersonale_tuscia (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfvalutazionepersonale_tuscia";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfvalutazionepersonale_tuscia.xsd";

	#region create DataTables
	//////////////////// PERFINTERAZIONI /////////////////////////////////
	var tperfinterazioni= new MetaTable("perfinterazioni");
	tperfinterazioni.defineColumn("commenti", typeof(string));
	tperfinterazioni.defineColumn("commentival", typeof(string));
	tperfinterazioni.defineColumn("ct", typeof(DateTime),false);
	tperfinterazioni.defineColumn("cu", typeof(string),false);
	tperfinterazioni.defineColumn("data", typeof(DateTime));
	tperfinterazioni.defineColumn("idperfinterazionekind", typeof(int),false);
	tperfinterazioni.defineColumn("idperfinterazioni", typeof(int),false);
	tperfinterazioni.defineColumn("idperfvalutazionepersonale", typeof(int),false);
	tperfinterazioni.defineColumn("lt", typeof(DateTime),false);
	tperfinterazioni.defineColumn("lu", typeof(string),false);
	tperfinterazioni.defineColumn("utente", typeof(string));
	Tables.Add(tperfinterazioni);
	tperfinterazioni.defineKey("idperfinterazioni", "idperfvalutazionepersonale");

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

	//////////////////// PERFVALUTAZIONEPERSONALEATTACH /////////////////////////////////
	var tperfvalutazionepersonaleattach= new MetaTable("perfvalutazionepersonaleattach");
	tperfvalutazionepersonaleattach.defineColumn("ct", typeof(DateTime),false);
	tperfvalutazionepersonaleattach.defineColumn("cu", typeof(string),false);
	tperfvalutazionepersonaleattach.defineColumn("data", typeof(DateTime));
	tperfvalutazionepersonaleattach.defineColumn("idattach", typeof(int));
	tperfvalutazionepersonaleattach.defineColumn("idperfvalutazionepersonale", typeof(int),false);
	tperfvalutazionepersonaleattach.defineColumn("idperfvalutazionepersonaleattach", typeof(int),false);
	tperfvalutazionepersonaleattach.defineColumn("lt", typeof(DateTime),false);
	tperfvalutazionepersonaleattach.defineColumn("lu", typeof(string),false);
	tperfvalutazionepersonaleattach.defineColumn("!idattach_attach_filename", typeof(string));
	tperfvalutazionepersonaleattach.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tperfvalutazionepersonaleattach);
	tperfvalutazionepersonaleattach.defineKey("idperfvalutazionepersonale", "idperfvalutazionepersonaleattach");

	//////////////////// GETDOCENTIAMMINISTRATIVIRESPONSABILIDEFAULTVIEW_ALIAS5 /////////////////////////////////
	var tgetdocentiamministrativiresponsabilidefaultview_alias5= new MetaTable("getdocentiamministrativiresponsabilidefaultview_alias5");
	tgetdocentiamministrativiresponsabilidefaultview_alias5.defineColumn("dropdown_title", typeof(string),false);
	tgetdocentiamministrativiresponsabilidefaultview_alias5.defineColumn("getdocentiamministrativiresponsabili_cf", typeof(string));
	tgetdocentiamministrativiresponsabilidefaultview_alias5.defineColumn("getdocentiamministrativiresponsabili_contratto", typeof(string));
	tgetdocentiamministrativiresponsabilidefaultview_alias5.defineColumn("getdocentiamministrativiresponsabili_extmatricula", typeof(string));
	tgetdocentiamministrativiresponsabilidefaultview_alias5.defineColumn("getdocentiamministrativiresponsabili_forename", typeof(string));
	tgetdocentiamministrativiresponsabilidefaultview_alias5.defineColumn("getdocentiamministrativiresponsabili_istituto", typeof(string));
	tgetdocentiamministrativiresponsabilidefaultview_alias5.defineColumn("getdocentiamministrativiresponsabili_resplevel", typeof(int));
	tgetdocentiamministrativiresponsabilidefaultview_alias5.defineColumn("getdocentiamministrativiresponsabili_ssd", typeof(string));
	tgetdocentiamministrativiresponsabilidefaultview_alias5.defineColumn("idreg", typeof(int),false);
	tgetdocentiamministrativiresponsabilidefaultview_alias5.defineColumn("ruolo", typeof(string),false);
	tgetdocentiamministrativiresponsabilidefaultview_alias5.defineColumn("struttura", typeof(string),false);
	tgetdocentiamministrativiresponsabilidefaultview_alias5.defineColumn("surname", typeof(string));
	tgetdocentiamministrativiresponsabilidefaultview_alias5.ExtendedProperties["TableForReading"]="getdocentiamministrativiresponsabilidefaultview";
	Tables.Add(tgetdocentiamministrativiresponsabilidefaultview_alias5);
	tgetdocentiamministrativiresponsabilidefaultview_alias5.defineKey("idreg", "ruolo", "struttura");

	//////////////////// GETDOCENTIAMMINISTRATIVIRESPONSABILIDEFAULTVIEW_ALIAS4 /////////////////////////////////
	var tgetdocentiamministrativiresponsabilidefaultview_alias4= new MetaTable("getdocentiamministrativiresponsabilidefaultview_alias4");
	tgetdocentiamministrativiresponsabilidefaultview_alias4.defineColumn("dropdown_title", typeof(string),false);
	tgetdocentiamministrativiresponsabilidefaultview_alias4.defineColumn("getdocentiamministrativiresponsabili_cf", typeof(string));
	tgetdocentiamministrativiresponsabilidefaultview_alias4.defineColumn("getdocentiamministrativiresponsabili_contratto", typeof(string));
	tgetdocentiamministrativiresponsabilidefaultview_alias4.defineColumn("getdocentiamministrativiresponsabili_extmatricula", typeof(string));
	tgetdocentiamministrativiresponsabilidefaultview_alias4.defineColumn("getdocentiamministrativiresponsabili_forename", typeof(string));
	tgetdocentiamministrativiresponsabilidefaultview_alias4.defineColumn("getdocentiamministrativiresponsabili_istituto", typeof(string));
	tgetdocentiamministrativiresponsabilidefaultview_alias4.defineColumn("getdocentiamministrativiresponsabili_resplevel", typeof(int));
	tgetdocentiamministrativiresponsabilidefaultview_alias4.defineColumn("getdocentiamministrativiresponsabili_ssd", typeof(string));
	tgetdocentiamministrativiresponsabilidefaultview_alias4.defineColumn("idreg", typeof(int),false);
	tgetdocentiamministrativiresponsabilidefaultview_alias4.defineColumn("ruolo", typeof(string),false);
	tgetdocentiamministrativiresponsabilidefaultview_alias4.defineColumn("struttura", typeof(string),false);
	tgetdocentiamministrativiresponsabilidefaultview_alias4.defineColumn("surname", typeof(string));
	tgetdocentiamministrativiresponsabilidefaultview_alias4.ExtendedProperties["TableForReading"]="getdocentiamministrativiresponsabilidefaultview";
	Tables.Add(tgetdocentiamministrativiresponsabilidefaultview_alias4);
	tgetdocentiamministrativiresponsabilidefaultview_alias4.defineKey("idreg", "ruolo", "struttura");

	//////////////////// GETDOCENTIAMMINISTRATIVIRESPONSABILIDEFAULTVIEW_ALIAS3 /////////////////////////////////
	var tgetdocentiamministrativiresponsabilidefaultview_alias3= new MetaTable("getdocentiamministrativiresponsabilidefaultview_alias3");
	tgetdocentiamministrativiresponsabilidefaultview_alias3.defineColumn("dropdown_title", typeof(string),false);
	tgetdocentiamministrativiresponsabilidefaultview_alias3.defineColumn("idreg", typeof(int),false);
	tgetdocentiamministrativiresponsabilidefaultview_alias3.defineColumn("ruolo", typeof(string),false);
	tgetdocentiamministrativiresponsabilidefaultview_alias3.defineColumn("struttura", typeof(string),false);
	tgetdocentiamministrativiresponsabilidefaultview_alias3.ExtendedProperties["TableForReading"]="getdocentiamministrativiresponsabilidefaultview";
	Tables.Add(tgetdocentiamministrativiresponsabilidefaultview_alias3);
	tgetdocentiamministrativiresponsabilidefaultview_alias3.defineKey("idreg", "ruolo", "struttura");

	//////////////////// GETDOCENTIAMMINISTRATIVIRESPONSABILIDEFAULTVIEW_ALIAS2 /////////////////////////////////
	var tgetdocentiamministrativiresponsabilidefaultview_alias2= new MetaTable("getdocentiamministrativiresponsabilidefaultview_alias2");
	tgetdocentiamministrativiresponsabilidefaultview_alias2.defineColumn("dropdown_title", typeof(string),false);
	tgetdocentiamministrativiresponsabilidefaultview_alias2.defineColumn("idreg", typeof(int),false);
	tgetdocentiamministrativiresponsabilidefaultview_alias2.defineColumn("ruolo", typeof(string),false);
	tgetdocentiamministrativiresponsabilidefaultview_alias2.defineColumn("struttura", typeof(string),false);
	tgetdocentiamministrativiresponsabilidefaultview_alias2.ExtendedProperties["TableForReading"]="getdocentiamministrativiresponsabilidefaultview";
	Tables.Add(tgetdocentiamministrativiresponsabilidefaultview_alias2);
	tgetdocentiamministrativiresponsabilidefaultview_alias2.defineKey("idreg", "ruolo", "struttura");

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

	//////////////////// PERFVALUTAZIONEPERSONALECOMPORTAMENTOSOGLIA /////////////////////////////////
	var tperfvalutazionepersonalecomportamentosoglia= new MetaTable("perfvalutazionepersonalecomportamentosoglia");
	tperfvalutazionepersonalecomportamentosoglia.defineColumn("ct", typeof(DateTime),false);
	tperfvalutazionepersonalecomportamentosoglia.defineColumn("cu", typeof(string),false);
	tperfvalutazionepersonalecomportamentosoglia.defineColumn("description", typeof(string));
	tperfvalutazionepersonalecomportamentosoglia.defineColumn("idperfsogliakind", typeof(string),false);
	tperfvalutazionepersonalecomportamentosoglia.defineColumn("idperfvalutazionepersonale", typeof(int),false);
	tperfvalutazionepersonalecomportamentosoglia.defineColumn("idperfvalutazionepersonalecomportamento", typeof(int),false);
	tperfvalutazionepersonalecomportamentosoglia.defineColumn("idperfvalutazionepersonalecomportamentosoglia", typeof(int),false);
	tperfvalutazionepersonalecomportamentosoglia.defineColumn("lt", typeof(DateTime),false);
	tperfvalutazionepersonalecomportamentosoglia.defineColumn("lu", typeof(string),false);
	tperfvalutazionepersonalecomportamentosoglia.defineColumn("valore", typeof(decimal),false);
	tperfvalutazionepersonalecomportamentosoglia.defineColumn("valorenumerico", typeof(decimal));
	tperfvalutazionepersonalecomportamentosoglia.defineColumn("year", typeof(int),false);
	tperfvalutazionepersonalecomportamentosoglia.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tperfvalutazionepersonalecomportamentosoglia);
	tperfvalutazionepersonalecomportamentosoglia.defineKey("idperfvalutazionepersonale", "idperfvalutazionepersonalecomportamento", "idperfvalutazionepersonalecomportamentosoglia");

	//////////////////// PERFGIUDIZIODEFAULTVIEW /////////////////////////////////
	var tperfgiudiziodefaultview= new MetaTable("perfgiudiziodefaultview");
	tperfgiudiziodefaultview.defineColumn("dropdown_title", typeof(string),false);
	tperfgiudiziodefaultview.defineColumn("idperfgiudizio", typeof(int),false);
	Tables.Add(tperfgiudiziodefaultview);
	tperfgiudiziodefaultview.defineKey("idperfgiudizio");

	//////////////////// PERFCOMPORTAMENTO /////////////////////////////////
	var tperfcomportamento= new MetaTable("perfcomportamento");
	tperfcomportamento.defineColumn("idperfcomportamento", typeof(int),false);
	tperfcomportamento.defineColumn("title", typeof(string));
	Tables.Add(tperfcomportamento);
	tperfcomportamento.defineKey("idperfcomportamento");

	//////////////////// PERFVALUTAZIONEPERSONALECOMPORTAMENTO /////////////////////////////////
	var tperfvalutazionepersonalecomportamento= new MetaTable("perfvalutazionepersonalecomportamento");
	tperfvalutazionepersonalecomportamento.defineColumn("completamento", typeof(decimal));
	tperfvalutazionepersonalecomportamento.defineColumn("ct", typeof(DateTime),false);
	tperfvalutazionepersonalecomportamento.defineColumn("cu", typeof(string),false);
	tperfvalutazionepersonalecomportamento.defineColumn("idperfcomportamento", typeof(int),false);
	tperfvalutazionepersonalecomportamento.defineColumn("idperfgiudizio", typeof(int));
	tperfvalutazionepersonalecomportamento.defineColumn("idperfvalutazionepersonale", typeof(int),false);
	tperfvalutazionepersonalecomportamento.defineColumn("idperfvalutazionepersonalecomportamento", typeof(int),false);
	tperfvalutazionepersonalecomportamento.defineColumn("lt", typeof(DateTime),false);
	tperfvalutazionepersonalecomportamento.defineColumn("lu", typeof(string),false);
	tperfvalutazionepersonalecomportamento.defineColumn("peso", typeof(decimal));
	tperfvalutazionepersonalecomportamento.defineColumn("valorenumerico", typeof(decimal));
	tperfvalutazionepersonalecomportamento.defineColumn("!idperfcomportamento_perfcomportamento_title", typeof(string));
	tperfvalutazionepersonalecomportamento.defineColumn("!idperfgiudizio_perfgiudiziodefaultview_title", typeof(string));
	tperfvalutazionepersonalecomportamento.defineColumn("!perfvalutazionepersonalecomportamentosoglia", typeof(string));
	tperfvalutazionepersonalecomportamento.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tperfvalutazionepersonalecomportamento);
	tperfvalutazionepersonalecomportamento.defineKey("idperfcomportamento", "idperfvalutazionepersonale", "idperfvalutazionepersonalecomportamento");

	//////////////////// STRUTTURAKIND /////////////////////////////////
	var tstrutturakind= new MetaTable("strutturakind");
	tstrutturakind.defineColumn("active", typeof(string),false);
	tstrutturakind.defineColumn("idstrutturakind", typeof(int),false);
	tstrutturakind.defineColumn("title", typeof(string),false);
	Tables.Add(tstrutturakind);
	tstrutturakind.defineKey("idstrutturakind");

	//////////////////// STRUTTURA /////////////////////////////////
	var tstruttura= new MetaTable("struttura");
	tstruttura.defineColumn("active", typeof(string));
	tstruttura.defineColumn("idstruttura", typeof(int),false);
	tstruttura.defineColumn("idstrutturakind", typeof(int),false);
	tstruttura.defineColumn("title", typeof(string));
	Tables.Add(tstruttura);
	tstruttura.defineKey("idstruttura");

	//////////////////// PERFVALUTAZIONEPERSONALEUO /////////////////////////////////
	var tperfvalutazionepersonaleuo= new MetaTable("perfvalutazionepersonaleuo");
	tperfvalutazionepersonaleuo.defineColumn("afferenza", typeof(decimal));
	tperfvalutazionepersonaleuo.defineColumn("ct", typeof(DateTime),false);
	tperfvalutazionepersonaleuo.defineColumn("cu", typeof(string),false);
	tperfvalutazionepersonaleuo.defineColumn("idperfvalutazionepersonale", typeof(int),false);
	tperfvalutazionepersonaleuo.defineColumn("idperfvalutazionepersonaleuo", typeof(int),false);
	tperfvalutazionepersonaleuo.defineColumn("idstruttura", typeof(int),false);
	tperfvalutazionepersonaleuo.defineColumn("lt", typeof(DateTime),false);
	tperfvalutazionepersonaleuo.defineColumn("lu", typeof(string),false);
	tperfvalutazionepersonaleuo.defineColumn("peso", typeof(decimal));
	tperfvalutazionepersonaleuo.defineColumn("punteggio", typeof(decimal));
	tperfvalutazionepersonaleuo.defineColumn("punteggiopesato", typeof(decimal));
	tperfvalutazionepersonaleuo.defineColumn("!idstruttura_struttura_title", typeof(string));
	tperfvalutazionepersonaleuo.defineColumn("!idstruttura_struttura_idstrutturakind_title", typeof(string));
	tperfvalutazionepersonaleuo.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tperfvalutazionepersonaleuo);
	tperfvalutazionepersonaleuo.defineKey("idperfvalutazionepersonale", "idperfvalutazionepersonaleuo", "idstruttura");

	//////////////////// PERFVALUTAZIONEPERSONALEATENEO /////////////////////////////////
	var tperfvalutazionepersonaleateneo= new MetaTable("perfvalutazionepersonaleateneo");
	tperfvalutazionepersonaleateneo.defineColumn("ct", typeof(DateTime),false);
	tperfvalutazionepersonaleateneo.defineColumn("cu", typeof(string),false);
	tperfvalutazionepersonaleateneo.defineColumn("idperfvalutazionepersonale", typeof(int),false);
	tperfvalutazionepersonaleateneo.defineColumn("idperfvalutazionepersonaleateneo", typeof(int),false);
	tperfvalutazionepersonaleateneo.defineColumn("lt", typeof(DateTime),false);
	tperfvalutazionepersonaleateneo.defineColumn("lu", typeof(string),false);
	tperfvalutazionepersonaleateneo.defineColumn("peso", typeof(decimal));
	tperfvalutazionepersonaleateneo.defineColumn("punteggio", typeof(decimal));
	tperfvalutazionepersonaleateneo.defineColumn("punteggiopesato", typeof(decimal));
	tperfvalutazionepersonaleateneo.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tperfvalutazionepersonaleateneo);
	tperfvalutazionepersonaleateneo.defineKey("idperfvalutazionepersonale", "idperfvalutazionepersonaleateneo");

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
	tperfvalutazionepersonale.defineColumn("motivazione", typeof(string));
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
	var cPar = new []{perfvalutazionepersonale.Columns["idperfvalutazionepersonale"]};
	var cChild = new []{perfvalutazionepersonaleattach.Columns["idperfvalutazionepersonale"]};
	Relations.Add(new DataRelation("FK_perfvalutazionepersonaleattach_perfvalutazionepersonale_idperfvalutazionepersonale",cPar,cChild,false));

	cPar = new []{attach.Columns["idattach"]};
	cChild = new []{perfvalutazionepersonaleattach.Columns["idattach"]};
	Relations.Add(new DataRelation("FK_perfvalutazionepersonaleattach_attach_idattach",cPar,cChild,false));

	cPar = new []{getdocentiamministrativiresponsabilidefaultview_alias5.Columns["idreg"]};
	cChild = new []{perfvalutazionepersonale.Columns["idreg_appr"]};
	Relations.Add(new DataRelation("FK_perfvalutazionepersonale_getdocentiamministrativiresponsabilidefaultview_alias5_idreg_appr",cPar,cChild,false));

	cPar = new []{getdocentiamministrativiresponsabilidefaultview_alias4.Columns["idreg"]};
	cChild = new []{perfvalutazionepersonale.Columns["idreg_val"]};
	Relations.Add(new DataRelation("FK_perfvalutazionepersonale_getdocentiamministrativiresponsabilidefaultview_alias4_idreg_val",cPar,cChild,false));

	cPar = new []{getdocentiamministrativiresponsabilidefaultview_alias3.Columns["idreg"]};
	cChild = new []{perfvalutazionepersonale.Columns["idreg_comp"]};
	Relations.Add(new DataRelation("FK_perfvalutazionepersonale_getdocentiamministrativiresponsabilidefaultview_alias3_idreg_comp",cPar,cChild,false));

	cPar = new []{getdocentiamministrativiresponsabilidefaultview_alias2.Columns["idreg"]};
	cChild = new []{perfvalutazionepersonale.Columns["idreg_create"]};
	Relations.Add(new DataRelation("FK_perfvalutazionepersonale_getdocentiamministrativiresponsabilidefaultview_alias2_idreg_create",cPar,cChild,false));

	cPar = new []{perfvalutazionepersonale.Columns["idperfvalutazionepersonale"]};
	cChild = new []{perfvalutazionepersonaleobiettivo.Columns["idperfvalutazionepersonale"]};
	Relations.Add(new DataRelation("FK_perfvalutazionepersonaleobiettivo_perfvalutazionepersonale_idperfvalutazionepersonale",cPar,cChild,false));

	cPar = new []{perfvalutazionepersonaleobiettivo.Columns["idperfvalutazionepersonale"], perfvalutazionepersonaleobiettivo.Columns["idperfvalutazionepersonaleobiettivo"]};
	cChild = new []{perfvalutazionepersonalesoglia.Columns["idperfvalutazionepersonale"], perfvalutazionepersonalesoglia.Columns["idperfvalutazionepersonaleobiettivo"]};
	Relations.Add(new DataRelation("FK_perfvalutazionepersonalesoglia_perfvalutazionepersonaleobiettivo_idperfvalutazionepersonale-idperfvalutazionepersonaleobiettivo",cPar,cChild,false));

	cPar = new []{perfvalutazionepersonaleobiettivo.Columns["idperfvalutazionepersonale"], perfvalutazionepersonaleobiettivo.Columns["idperfvalutazionepersonaleobiettivo"]};
	cChild = new []{perfvalutazionepersonaleobiettivoattach.Columns["idperfvalutazionepersonale"], perfvalutazionepersonaleobiettivoattach.Columns["idperfvalutazionepersonaleobiettivo"]};
	Relations.Add(new DataRelation("FK_perfvalutazionepersonaleobiettivoattach_perfvalutazionepersonaleobiettivo_idperfvalutazionepersonale-idperfvalutazionepersonaleobiettivo",cPar,cChild,false));

	cPar = new []{getdocentiamministrativiresponsabilidefaultview_alias1.Columns["idreg"]};
	cChild = new []{perfvalutazionepersonale.Columns["idreg_valcomp"]};
	Relations.Add(new DataRelation("FK_perfvalutazionepersonale_getdocentiamministrativiresponsabilidefaultview_alias1_idreg_valcomp",cPar,cChild,false));

	cPar = new []{getdocentiamministrativiresponsabilidefaultview.Columns["idreg"]};
	cChild = new []{perfvalutazionepersonale.Columns["idreg_compcomp"]};
	Relations.Add(new DataRelation("FK_perfvalutazionepersonale_getdocentiamministrativiresponsabilidefaultview_idreg_compcomp",cPar,cChild,false));

	cPar = new []{perfvalutazionepersonale.Columns["idperfvalutazionepersonale"]};
	cChild = new []{perfvalutazionepersonalecomportamento.Columns["idperfvalutazionepersonale"]};
	Relations.Add(new DataRelation("FK_perfvalutazionepersonalecomportamento_perfvalutazionepersonale_idperfvalutazionepersonale",cPar,cChild,false));

	cPar = new []{perfvalutazionepersonalecomportamento.Columns["idperfvalutazionepersonale"], perfvalutazionepersonalecomportamento.Columns["idperfvalutazionepersonalecomportamento"]};
	cChild = new []{perfvalutazionepersonalecomportamentosoglia.Columns["idperfvalutazionepersonale"], perfvalutazionepersonalecomportamentosoglia.Columns["idperfvalutazionepersonalecomportamento"]};
	Relations.Add(new DataRelation("FK_perfvalutazionepersonalecomportamentosoglia_perfvalutazionepersonalecomportamento_idperfvalutazionepersonale-idperfvalutazionepersonalecomportamento",cPar,cChild,false));

	cPar = new []{perfgiudiziodefaultview.Columns["idperfgiudizio"]};
	cChild = new []{perfvalutazionepersonalecomportamento.Columns["idperfgiudizio"]};
	Relations.Add(new DataRelation("FK_perfvalutazionepersonalecomportamento_perfgiudiziodefaultview_idperfgiudizio",cPar,cChild,false));

	cPar = new []{perfcomportamento.Columns["idperfcomportamento"]};
	cChild = new []{perfvalutazionepersonalecomportamento.Columns["idperfcomportamento"]};
	Relations.Add(new DataRelation("FK_perfvalutazionepersonalecomportamento_perfcomportamento_idperfcomportamento",cPar,cChild,false));

	cPar = new []{perfvalutazionepersonale.Columns["idperfvalutazionepersonale"]};
	cChild = new []{perfvalutazionepersonaleuo.Columns["idperfvalutazionepersonale"]};
	Relations.Add(new DataRelation("FK_perfvalutazionepersonaleuo_perfvalutazionepersonale_idperfvalutazionepersonale",cPar,cChild,false));

	cPar = new []{struttura.Columns["idstruttura"]};
	cChild = new []{perfvalutazionepersonaleuo.Columns["idstruttura"]};
	Relations.Add(new DataRelation("FK_perfvalutazionepersonaleuo_struttura_idstruttura",cPar,cChild,false));

	cPar = new []{strutturakind.Columns["idstrutturakind"]};
	cChild = new []{struttura.Columns["idstrutturakind"]};
	Relations.Add(new DataRelation("FK_struttura_strutturakind_idstrutturakind",cPar,cChild,false));

	cPar = new []{perfvalutazionepersonale.Columns["idperfvalutazionepersonale"]};
	cChild = new []{perfvalutazionepersonaleateneo.Columns["idperfvalutazionepersonale"]};
	Relations.Add(new DataRelation("FK_perfvalutazionepersonaleateneo_perfvalutazionepersonale_idperfvalutazionepersonale",cPar,cChild,false));

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
