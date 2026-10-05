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
[System.Xml.Serialization.XmlRoot("dsmeta_perfvalutazionepersonale_unibas"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_perfvalutazionepersonale_unibas: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfinterazioni_alias1 		=> (MetaTable)Tables["perfinterazioni_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfgiudizio 		=> (MetaTable)Tables["perfgiudizio"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfcomportamento 		=> (MetaTable)Tables["perfcomportamento"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazionepersonalecomportamento 		=> (MetaTable)Tables["perfvalutazionepersonalecomportamento"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazionepersonalesoglia 		=> (MetaTable)Tables["perfvalutazionepersonalesoglia"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazionepersonaleobiettivo 		=> (MetaTable)Tables["perfvalutazionepersonaleobiettivo"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfobiettiviuoinpersonaleview 		=> (MetaTable)Tables["perfobiettiviuoinpersonaleview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfateneoinpersonaleview 		=> (MetaTable)Tables["perfateneoinpersonaleview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getdocentiamministrativiresponsabilidefaultview 		=> (MetaTable)Tables["getdocentiamministrativiresponsabilidefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfschedastatus 		=> (MetaTable)Tables["perfschedastatus"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazionepersonalestatuschanges 		=> (MetaTable)Tables["perfvalutazionepersonalestatuschanges"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable afferenzaammview 		=> (MetaTable)Tables["afferenzaammview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attach 		=> (MetaTable)Tables["attach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazionepersonaleattach 		=> (MetaTable)Tables["perfvalutazionepersonaleattach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getregistrydocentiamministratividefaultview 		=> (MetaTable)Tables["getregistrydocentiamministratividefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfinterazionekind 		=> (MetaTable)Tables["perfinterazionekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfinterazioni 		=> (MetaTable)Tables["perfinterazioni"];

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
public dsmeta_perfvalutazionepersonale_unibas(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfvalutazionepersonale_unibas (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfvalutazionepersonale_unibas";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfvalutazionepersonale_unibas.xsd";

	#region create DataTables
	//////////////////// PERFINTERAZIONI_ALIAS1 /////////////////////////////////
	var tperfinterazioni_alias1= new MetaTable("perfinterazioni_alias1");
	tperfinterazioni_alias1.defineColumn("commenti", typeof(string));
	tperfinterazioni_alias1.defineColumn("commentival", typeof(string));
	tperfinterazioni_alias1.defineColumn("ct", typeof(DateTime),false);
	tperfinterazioni_alias1.defineColumn("cu", typeof(string),false);
	tperfinterazioni_alias1.defineColumn("data", typeof(DateTime));
	tperfinterazioni_alias1.defineColumn("idperfinterazionekind", typeof(int),false);
	tperfinterazioni_alias1.defineColumn("idperfinterazioni", typeof(int),false);
	tperfinterazioni_alias1.defineColumn("idperfvalutazionepersonale", typeof(int),false);
	tperfinterazioni_alias1.defineColumn("lt", typeof(DateTime),false);
	tperfinterazioni_alias1.defineColumn("lu", typeof(string),false);
	tperfinterazioni_alias1.defineColumn("utente", typeof(string));
	tperfinterazioni_alias1.ExtendedProperties["TableForReading"]="perfinterazioni";
	Tables.Add(tperfinterazioni_alias1);
	tperfinterazioni_alias1.defineKey("idperfinterazioni", "idperfvalutazionepersonale");

	//////////////////// PERFGIUDIZIO /////////////////////////////////
	var tperfgiudizio= new MetaTable("perfgiudizio");
	tperfgiudizio.defineColumn("idperfgiudizio", typeof(int),false);
	tperfgiudizio.defineColumn("title", typeof(string));
	Tables.Add(tperfgiudizio);
	tperfgiudizio.defineKey("idperfgiudizio");

	//////////////////// PERFCOMPORTAMENTO /////////////////////////////////
	var tperfcomportamento= new MetaTable("perfcomportamento");
	tperfcomportamento.defineColumn("ct", typeof(DateTime),false);
	tperfcomportamento.defineColumn("cu", typeof(string),false);
	tperfcomportamento.defineColumn("description", typeof(string));
	tperfcomportamento.defineColumn("idperfcomportamento", typeof(int),false);
	tperfcomportamento.defineColumn("lt", typeof(DateTime),false);
	tperfcomportamento.defineColumn("lu", typeof(string),false);
	tperfcomportamento.defineColumn("peso", typeof(decimal));
	tperfcomportamento.defineColumn("title", typeof(string));
	Tables.Add(tperfcomportamento);
	tperfcomportamento.defineKey("idperfcomportamento");

	//////////////////// PERFVALUTAZIONEPERSONALECOMPORTAMENTO /////////////////////////////////
	var tperfvalutazionepersonalecomportamento= new MetaTable("perfvalutazionepersonalecomportamento");
	tperfvalutazionepersonalecomportamento.defineColumn("!perfcomportamento", typeof(string));
	tperfvalutazionepersonalecomportamento.defineColumn("completamento", typeof(decimal));
	tperfvalutazionepersonalecomportamento.defineColumn("ct", typeof(DateTime),false);
	tperfvalutazionepersonalecomportamento.defineColumn("cu", typeof(string),false);
	tperfvalutazionepersonalecomportamento.defineColumn("idperfcomportamento", typeof(int),false);
	tperfvalutazionepersonalecomportamento.defineColumn("idperfgiudizio", typeof(int));
	tperfvalutazionepersonalecomportamento.defineColumn("idperfvalutazionepersonale", typeof(int),false);
	tperfvalutazionepersonalecomportamento.defineColumn("idperfvalutazionepersonalecomportamento", typeof(int),false);
	tperfvalutazionepersonalecomportamento.defineColumn("lt", typeof(DateTime),false);
	tperfvalutazionepersonalecomportamento.defineColumn("lu", typeof(string),false);
	tperfvalutazionepersonalecomportamento.defineColumn("note", typeof(string));
	tperfvalutazionepersonalecomportamento.defineColumn("peso", typeof(decimal));
	tperfvalutazionepersonalecomportamento.defineColumn("valorenumerico", typeof(decimal));
	tperfvalutazionepersonalecomportamento.defineColumn("!idperfcomportamento_perfcomportamento_title", typeof(string));
	tperfvalutazionepersonalecomportamento.defineColumn("!idperfcomportamento_perfcomportamento_description", typeof(string));
	tperfvalutazionepersonalecomportamento.defineColumn("!idperfgiudizio_perfgiudizio_title", typeof(string));
	tperfvalutazionepersonalecomportamento.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tperfvalutazionepersonalecomportamento);
	tperfvalutazionepersonalecomportamento.defineKey("idperfcomportamento", "idperfvalutazionepersonale", "idperfvalutazionepersonalecomportamento");

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

	//////////////////// PERFVALUTAZIONEPERSONALEOBIETTIVO /////////////////////////////////
	var tperfvalutazionepersonaleobiettivo= new MetaTable("perfvalutazionepersonaleobiettivo");
	tperfvalutazionepersonaleobiettivo.defineColumn("completamento", typeof(decimal));
	tperfvalutazionepersonaleobiettivo.defineColumn("ct", typeof(DateTime),false);
	tperfvalutazionepersonaleobiettivo.defineColumn("cu", typeof(string),false);
	tperfvalutazionepersonaleobiettivo.defineColumn("description", typeof(string));
	tperfvalutazionepersonaleobiettivo.defineColumn("forzapunteggio", typeof(string));
	tperfvalutazionepersonaleobiettivo.defineColumn("idperfprogettoobiettivoattivita", typeof(int));
	tperfvalutazionepersonaleobiettivo.defineColumn("idperfvalutazionepersonale", typeof(int),false);
	tperfvalutazionepersonaleobiettivo.defineColumn("idperfvalutazionepersonaleobiettivo", typeof(int),false);
	tperfvalutazionepersonaleobiettivo.defineColumn("inverso", typeof(string));
	tperfvalutazionepersonaleobiettivo.defineColumn("lt", typeof(DateTime),false);
	tperfvalutazionepersonaleobiettivo.defineColumn("lu", typeof(string),false);
	tperfvalutazionepersonaleobiettivo.defineColumn("note", typeof(string));
	tperfvalutazionepersonaleobiettivo.defineColumn("peso", typeof(decimal));
	tperfvalutazionepersonaleobiettivo.defineColumn("punteggio", typeof(int));
	tperfvalutazionepersonaleobiettivo.defineColumn("title", typeof(string));
	tperfvalutazionepersonaleobiettivo.defineColumn("valorenumerico", typeof(decimal));
	tperfvalutazionepersonaleobiettivo.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tperfvalutazionepersonaleobiettivo);
	tperfvalutazionepersonaleobiettivo.defineKey("idperfvalutazionepersonale", "idperfvalutazionepersonaleobiettivo");

	//////////////////// PERFOBIETTIVIUOINPERSONALEVIEW /////////////////////////////////
	var tperfobiettiviuoinpersonaleview= new MetaTable("perfobiettiviuoinpersonaleview");
	tperfobiettiviuoinpersonaleview.defineColumn("completamento", typeof(decimal));
	tperfobiettiviuoinpersonaleview.defineColumn("idperfobiettiviuo", typeof(int),false);
	tperfobiettiviuoinpersonaleview.defineColumn("idperfvalutazionepersonale", typeof(int),false);
	tperfobiettiviuoinpersonaleview.defineColumn("note", typeof(string));
	tperfobiettiviuoinpersonaleview.defineColumn("peso", typeof(decimal));
	tperfobiettiviuoinpersonaleview.defineColumn("punteggio", typeof(int));
	tperfobiettiviuoinpersonaleview.defineColumn("title", typeof(string));
	Tables.Add(tperfobiettiviuoinpersonaleview);
	tperfobiettiviuoinpersonaleview.defineKey("idperfobiettiviuo", "idperfvalutazionepersonale");

	//////////////////// PERFATENEOINPERSONALEVIEW /////////////////////////////////
	var tperfateneoinpersonaleview= new MetaTable("perfateneoinpersonaleview");
	tperfateneoinpersonaleview.defineColumn("completamento", typeof(decimal),false);
	tperfateneoinpersonaleview.defineColumn("idperfvalutazionepersonale", typeof(int),false);
	tperfateneoinpersonaleview.defineColumn("percentuale", typeof(decimal),false);
	tperfateneoinpersonaleview.defineColumn("percentualemax", typeof(decimal),false);
	tperfateneoinpersonaleview.defineColumn("peso", typeof(int),false);
	tperfateneoinpersonaleview.defineColumn("punteggio", typeof(decimal));
	tperfateneoinpersonaleview.defineColumn("title", typeof(string),false);
	Tables.Add(tperfateneoinpersonaleview);
	tperfateneoinpersonaleview.defineKey("idperfvalutazionepersonale");

	//////////////////// GETDOCENTIAMMINISTRATIVIRESPONSABILIDEFAULTVIEW /////////////////////////////////
	var tgetdocentiamministrativiresponsabilidefaultview= new MetaTable("getdocentiamministrativiresponsabilidefaultview");
	tgetdocentiamministrativiresponsabilidefaultview.defineColumn("dropdown_title", typeof(string),false);
	tgetdocentiamministrativiresponsabilidefaultview.defineColumn("getdocentiamministrativiresponsabili_cf", typeof(string));
	tgetdocentiamministrativiresponsabilidefaultview.defineColumn("getdocentiamministrativiresponsabili_contratto", typeof(string));
	tgetdocentiamministrativiresponsabilidefaultview.defineColumn("getdocentiamministrativiresponsabili_extmatricula", typeof(string));
	tgetdocentiamministrativiresponsabilidefaultview.defineColumn("getdocentiamministrativiresponsabili_forename", typeof(string));
	tgetdocentiamministrativiresponsabilidefaultview.defineColumn("getdocentiamministrativiresponsabili_istituto", typeof(string));
	tgetdocentiamministrativiresponsabilidefaultview.defineColumn("getdocentiamministrativiresponsabili_resplevel", typeof(long));
	tgetdocentiamministrativiresponsabilidefaultview.defineColumn("getdocentiamministrativiresponsabili_ssd", typeof(string));
	tgetdocentiamministrativiresponsabilidefaultview.defineColumn("getdocentiamministrativiresponsabili_start", typeof(DateTime));
	tgetdocentiamministrativiresponsabilidefaultview.defineColumn("getdocentiamministrativiresponsabili_stop", typeof(DateTime));
	tgetdocentiamministrativiresponsabilidefaultview.defineColumn("getdocentiamministrativiresponsabili_struttura", typeof(string));
	tgetdocentiamministrativiresponsabilidefaultview.defineColumn("idreg", typeof(int),false);
	tgetdocentiamministrativiresponsabilidefaultview.defineColumn("idstruttura", typeof(int),false);
	tgetdocentiamministrativiresponsabilidefaultview.defineColumn("ruolo", typeof(string),false);
	tgetdocentiamministrativiresponsabilidefaultview.defineColumn("struttura_idstrutturakind", typeof(int));
	tgetdocentiamministrativiresponsabilidefaultview.defineColumn("struttura_title", typeof(string));
	tgetdocentiamministrativiresponsabilidefaultview.defineColumn("strutturakind_title", typeof(string));
	tgetdocentiamministrativiresponsabilidefaultview.defineColumn("surname", typeof(string));
	Tables.Add(tgetdocentiamministrativiresponsabilidefaultview);
	tgetdocentiamministrativiresponsabilidefaultview.defineKey("idreg", "idstruttura", "ruolo");

	//////////////////// PERFSCHEDASTATUS /////////////////////////////////
	var tperfschedastatus= new MetaTable("perfschedastatus");
	tperfschedastatus.defineColumn("active", typeof(string));
	tperfschedastatus.defineColumn("idperfschedastatus", typeof(int),false);
	tperfschedastatus.defineColumn("title", typeof(string));
	Tables.Add(tperfschedastatus);
	tperfschedastatus.defineKey("idperfschedastatus");

	//////////////////// PERFVALUTAZIONEPERSONALESTATUSCHANGES /////////////////////////////////
	var tperfvalutazionepersonalestatuschanges= new MetaTable("perfvalutazionepersonalestatuschanges");
	tperfvalutazionepersonalestatuschanges.defineColumn("changedate", typeof(DateTime));
	tperfvalutazionepersonalestatuschanges.defineColumn("changeuser", typeof(string));
	tperfvalutazionepersonalestatuschanges.defineColumn("ct", typeof(DateTime));
	tperfvalutazionepersonalestatuschanges.defineColumn("cu", typeof(string));
	tperfvalutazionepersonalestatuschanges.defineColumn("idperfschedastatus", typeof(int));
	tperfvalutazionepersonalestatuschanges.defineColumn("idperfvalutazionepersonale", typeof(int),false);
	tperfvalutazionepersonalestatuschanges.defineColumn("idperfvalutazionepersonalestatuschanges", typeof(int),false);
	tperfvalutazionepersonalestatuschanges.defineColumn("lt", typeof(DateTime));
	tperfvalutazionepersonalestatuschanges.defineColumn("lu", typeof(string));
	tperfvalutazionepersonalestatuschanges.defineColumn("!idperfschedastatus_perfschedastatus_title", typeof(string));
	tperfvalutazionepersonalestatuschanges.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tperfvalutazionepersonalestatuschanges);
	tperfvalutazionepersonalestatuschanges.defineKey("idperfvalutazionepersonale", "idperfvalutazionepersonalestatuschanges");

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
	tattach.defineColumn("size", typeof(long),false);
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

	//////////////////// GETREGISTRYDOCENTIAMMINISTRATIVIDEFAULTVIEW /////////////////////////////////
	var tgetregistrydocentiamministratividefaultview= new MetaTable("getregistrydocentiamministratividefaultview");
	tgetregistrydocentiamministratividefaultview.defineColumn("dropdown_title", typeof(string),false);
	tgetregistrydocentiamministratividefaultview.defineColumn("getregistrydocentiamministrativi_active", typeof(string));
	tgetregistrydocentiamministratividefaultview.defineColumn("getregistrydocentiamministrativi_areadidattica", typeof(string));
	tgetregistrydocentiamministratividefaultview.defineColumn("getregistrydocentiamministrativi_categoria", typeof(string),false);
	tgetregistrydocentiamministratividefaultview.defineColumn("getregistrydocentiamministrativi_cf", typeof(string));
	tgetregistrydocentiamministratividefaultview.defineColumn("getregistrydocentiamministrativi_contratto", typeof(string));
	tgetregistrydocentiamministratividefaultview.defineColumn("getregistrydocentiamministrativi_extmatricula", typeof(string));
	tgetregistrydocentiamministratividefaultview.defineColumn("getregistrydocentiamministrativi_forename", typeof(string));
	tgetregistrydocentiamministratividefaultview.defineColumn("getregistrydocentiamministrativi_istituto", typeof(string));
	tgetregistrydocentiamministratividefaultview.defineColumn("getregistrydocentiamministrativi_macroareadidattica", typeof(string));
	tgetregistrydocentiamministratividefaultview.defineColumn("getregistrydocentiamministrativi_ssd", typeof(string));
	tgetregistrydocentiamministratividefaultview.defineColumn("getregistrydocentiamministrativi_struttura", typeof(string));
	tgetregistrydocentiamministratividefaultview.defineColumn("idreg", typeof(int),false);
	tgetregistrydocentiamministratividefaultview.defineColumn("surname", typeof(string));
	Tables.Add(tgetregistrydocentiamministratividefaultview);
	tgetregistrydocentiamministratividefaultview.defineKey("idreg");

	//////////////////// PERFINTERAZIONEKIND /////////////////////////////////
	var tperfinterazionekind= new MetaTable("perfinterazionekind");
	tperfinterazionekind.defineColumn("idperfinterazionekind", typeof(int),false);
	tperfinterazionekind.defineColumn("title", typeof(string));
	Tables.Add(tperfinterazionekind);
	tperfinterazionekind.defineKey("idperfinterazionekind");

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
	tperfinterazioni.defineColumn("!idperfinterazionekind_perfinterazionekind_title", typeof(string));
	tperfinterazioni.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tperfinterazioni);
	tperfinterazioni.defineKey("idperfinterazioni", "idperfvalutazionepersonale");

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
	tperfvalutazionepersonale.defineColumn("!percateneopond", typeof(decimal));
	tperfvalutazionepersonale.defineColumn("!perccomportamentipond", typeof(decimal));
	tperfvalutazionepersonale.defineColumn("!percobiettivipond", typeof(decimal));
	tperfvalutazionepersonale.defineColumn("!percperfuopond", typeof(decimal));
	tperfvalutazionepersonale.defineColumn("ct", typeof(DateTime),false);
	tperfvalutazionepersonale.defineColumn("cu", typeof(string),false);
	tperfvalutazionepersonale.defineColumn("idafferenza", typeof(int),false);
	tperfvalutazionepersonale.defineColumn("idperfgiudizio_captec", typeof(int));
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
	tperfvalutazionepersonale.defineColumn("percgradodiff", typeof(decimal));
	tperfvalutazionepersonale.defineColumn("percobiettivi", typeof(decimal));
	tperfvalutazionepersonale.defineColumn("percperfuo", typeof(decimal));
	tperfvalutazionepersonale.defineColumn("pesoateneo", typeof(decimal));
	tperfvalutazionepersonale.defineColumn("pesocaptec", typeof(decimal));
	tperfvalutazionepersonale.defineColumn("pesocomportamenti", typeof(decimal));
	tperfvalutazionepersonale.defineColumn("pesogradodiff", typeof(decimal));
	tperfvalutazionepersonale.defineColumn("pesoobiettivi", typeof(decimal));
	tperfvalutazionepersonale.defineColumn("pesoperfuo", typeof(decimal));
	tperfvalutazionepersonale.defineColumn("risultato", typeof(decimal));
	tperfvalutazionepersonale.defineColumn("year", typeof(int));
	Tables.Add(tperfvalutazionepersonale);
	tperfvalutazionepersonale.defineKey("idafferenza", "idperfvalutazionepersonale", "idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{perfvalutazionepersonale.Columns["idperfvalutazionepersonale"]};
	var cChild = new []{perfvalutazionepersonalecomportamento.Columns["idperfvalutazionepersonale"]};
	Relations.Add(new DataRelation("FK_perfvalutazionepersonalecomportamento_perfvalutazionepersonale_idperfvalutazionepersonale",cPar,cChild,false));

	cPar = new []{perfgiudizio.Columns["idperfgiudizio"]};
	cChild = new []{perfvalutazionepersonalecomportamento.Columns["idperfgiudizio"]};
	Relations.Add(new DataRelation("FK_perfvalutazionepersonalecomportamento_perfgiudizio_idperfgiudizio",cPar,cChild,false));

	cPar = new []{perfcomportamento.Columns["idperfcomportamento"]};
	cChild = new []{perfvalutazionepersonalecomportamento.Columns["idperfcomportamento"]};
	Relations.Add(new DataRelation("FK_perfvalutazionepersonalecomportamento_perfcomportamento_idperfcomportamento",cPar,cChild,false));

	cPar = new []{perfvalutazionepersonale.Columns["idperfvalutazionepersonale"]};
	cChild = new []{perfvalutazionepersonaleobiettivo.Columns["idperfvalutazionepersonale"]};
	Relations.Add(new DataRelation("FK_perfvalutazionepersonaleobiettivo_perfvalutazionepersonale_idperfvalutazionepersonale",cPar,cChild,false));

	cPar = new []{perfvalutazionepersonaleobiettivo.Columns["idperfvalutazionepersonale"], perfvalutazionepersonaleobiettivo.Columns["idperfvalutazionepersonaleobiettivo"]};
	cChild = new []{perfvalutazionepersonalesoglia.Columns["idperfvalutazionepersonale"], perfvalutazionepersonalesoglia.Columns["idperfvalutazionepersonaleobiettivo"]};
	Relations.Add(new DataRelation("FK_perfvalutazionepersonalesoglia_perfvalutazionepersonaleobiettivo_idperfvalutazionepersonale-idperfvalutazionepersonaleobiettivo",cPar,cChild,false));

	cPar = new []{perfobiettiviuoinpersonaleview.Columns["idperfvalutazionepersonale"]};
	cChild = new []{perfvalutazionepersonale.Columns["idperfvalutazionepersonale"]};
	Relations.Add(new DataRelation("FK_perfvalutazionepersonale_perfobiettiviuoinpersonaleview_idperfvalutazionepersonale",cPar,cChild,false));

	cPar = new []{perfateneoinpersonaleview.Columns["idperfvalutazionepersonale"]};
	cChild = new []{perfvalutazionepersonale.Columns["idperfvalutazionepersonale"]};
	Relations.Add(new DataRelation("FK_perfvalutazionepersonale_perfateneoinpersonaleview_idperfvalutazionepersonale",cPar,cChild,false));

	cPar = new []{getdocentiamministrativiresponsabilidefaultview.Columns["idreg"]};
	cChild = new []{perfvalutazionepersonale.Columns["idreg_valcomp"]};
	Relations.Add(new DataRelation("FK_perfvalutazionepersonale_getdocentiamministrativiresponsabilidefaultview_idreg_valcomp",cPar,cChild,false));

	cPar = new []{perfvalutazionepersonale.Columns["idperfvalutazionepersonale"]};
	cChild = new []{perfvalutazionepersonalestatuschanges.Columns["idperfvalutazionepersonale"]};
	Relations.Add(new DataRelation("FK_perfvalutazionepersonalestatuschanges_perfvalutazionepersonale_idperfvalutazionepersonale",cPar,cChild,false));

	cPar = new []{perfschedastatus.Columns["idperfschedastatus"]};
	cChild = new []{perfvalutazionepersonalestatuschanges.Columns["idperfschedastatus"]};
	Relations.Add(new DataRelation("FK_perfvalutazionepersonalestatuschanges_perfschedastatus_idperfschedastatus",cPar,cChild,false));

	cPar = new []{afferenzaammview.Columns["idafferenza"]};
	cChild = new []{perfvalutazionepersonale.Columns["idafferenza"]};
	Relations.Add(new DataRelation("FK_perfvalutazionepersonale_afferenzaammview_idafferenza",cPar,cChild,false));

	cPar = new []{perfvalutazionepersonale.Columns["idperfvalutazionepersonale"]};
	cChild = new []{perfvalutazionepersonaleattach.Columns["idperfvalutazionepersonale"]};
	Relations.Add(new DataRelation("FK_perfvalutazionepersonaleattach_perfvalutazionepersonale_idperfvalutazionepersonale",cPar,cChild,false));

	cPar = new []{attach.Columns["idattach"]};
	cChild = new []{perfvalutazionepersonaleattach.Columns["idattach"]};
	Relations.Add(new DataRelation("FK_perfvalutazionepersonaleattach_attach_idattach",cPar,cChild,false));

	cPar = new []{getregistrydocentiamministratividefaultview.Columns["idreg"]};
	cChild = new []{perfvalutazionepersonale.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_perfvalutazionepersonale_getregistrydocentiamministratividefaultview_idreg",cPar,cChild,false));

	cPar = new []{perfvalutazionepersonale.Columns["idperfvalutazionepersonale"]};
	cChild = new []{perfinterazioni.Columns["idperfvalutazionepersonale"]};
	Relations.Add(new DataRelation("FK_perfinterazioni_perfvalutazionepersonale_idperfvalutazionepersonale",cPar,cChild,false));

	cPar = new []{perfinterazionekind.Columns["idperfinterazionekind"]};
	cChild = new []{perfinterazioni.Columns["idperfinterazionekind"]};
	Relations.Add(new DataRelation("FK_perfinterazioni_perfinterazionekind_idperfinterazionekind",cPar,cChild,false));

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
