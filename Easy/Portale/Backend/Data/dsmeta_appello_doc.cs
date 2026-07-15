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
[System.Xml.Serialization.XmlRoot("dsmeta_appello_doc"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_appello_doc: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable studprenotkinddefaultview 		=> (MetaTable)Tables["studprenotkinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable appelloazionekinddefaultview 		=> (MetaTable)Tables["appelloazionekinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sessionedefaultview 		=> (MetaTable)Tables["sessionedefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sostenimento 		=> (MetaTable)Tables["sostenimento"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable commissregistry_docenti 		=> (MetaTable)Tables["commissregistry_docenti"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable commiss 		=> (MetaTable)Tables["commiss"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable prenotappello 		=> (MetaTable)Tables["prenotappello"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable prova 		=> (MetaTable)Tables["prova"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable appellokinddefaultview 		=> (MetaTable)Tables["appellokinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico 		=> (MetaTable)Tables["annoaccademico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable appello 		=> (MetaTable)Tables["appello"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_appello_doc(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_appello_doc (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_appello_doc";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_appello_doc.xsd";

	#region create DataTables
	//////////////////// STUDPRENOTKINDDEFAULTVIEW /////////////////////////////////
	var tstudprenotkinddefaultview= new MetaTable("studprenotkinddefaultview");
	tstudprenotkinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tstudprenotkinddefaultview.defineColumn("idstudprenotkind", typeof(int),false);
	tstudprenotkinddefaultview.defineColumn("studprenotkind_active", typeof(string));
	tstudprenotkinddefaultview.defineColumn("studprenotkind_description", typeof(string),false);
	tstudprenotkinddefaultview.defineColumn("studprenotkind_lt", typeof(DateTime));
	tstudprenotkinddefaultview.defineColumn("studprenotkind_lu", typeof(string));
	tstudprenotkinddefaultview.defineColumn("studprenotkind_sortorder", typeof(int),false);
	tstudprenotkinddefaultview.defineColumn("title", typeof(string),false);
	Tables.Add(tstudprenotkinddefaultview);
	tstudprenotkinddefaultview.defineKey("idstudprenotkind");

	//////////////////// APPELLOAZIONEKINDDEFAULTVIEW /////////////////////////////////
	var tappelloazionekinddefaultview= new MetaTable("appelloazionekinddefaultview");
	tappelloazionekinddefaultview.defineColumn("appelloazionekind_active", typeof(string));
	tappelloazionekinddefaultview.defineColumn("appelloazionekind_ct", typeof(DateTime));
	tappelloazionekinddefaultview.defineColumn("appelloazionekind_cu", typeof(string));
	tappelloazionekinddefaultview.defineColumn("appelloazionekind_description", typeof(string),false);
	tappelloazionekinddefaultview.defineColumn("appelloazionekind_lt", typeof(DateTime),false);
	tappelloazionekinddefaultview.defineColumn("appelloazionekind_lu", typeof(string),false);
	tappelloazionekinddefaultview.defineColumn("appelloazionekind_sortcode", typeof(int));
	tappelloazionekinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tappelloazionekinddefaultview.defineColumn("idappelloazionekind", typeof(int),false);
	tappelloazionekinddefaultview.defineColumn("title", typeof(string),false);
	Tables.Add(tappelloazionekinddefaultview);
	tappelloazionekinddefaultview.defineKey("idappelloazionekind");

	//////////////////// SESSIONEDEFAULTVIEW /////////////////////////////////
	var tsessionedefaultview= new MetaTable("sessionedefaultview");
	tsessionedefaultview.defineColumn("dropdown_title", typeof(string),false);
	tsessionedefaultview.defineColumn("idsessione", typeof(int),false);
	Tables.Add(tsessionedefaultview);
	tsessionedefaultview.defineKey("idsessione");

	//////////////////// SOSTENIMENTO /////////////////////////////////
	var tsostenimento= new MetaTable("sostenimento");
	tsostenimento.defineColumn("ct", typeof(DateTime),false);
	tsostenimento.defineColumn("cu", typeof(string),false);
	tsostenimento.defineColumn("data", typeof(DateTime),false);
	tsostenimento.defineColumn("domande", typeof(string));
	tsostenimento.defineColumn("ects", typeof(int));
	tsostenimento.defineColumn("giudizio", typeof(string));
	tsostenimento.defineColumn("idappello", typeof(int),false);
	tsostenimento.defineColumn("idattivform", typeof(int));
	tsostenimento.defineColumn("idcorsostudio", typeof(int));
	tsostenimento.defineColumn("iddidprog", typeof(int));
	tsostenimento.defineColumn("idiscrizione", typeof(int));
	tsostenimento.defineColumn("idprova", typeof(int),false);
	tsostenimento.defineColumn("idreg", typeof(int),false);
	tsostenimento.defineColumn("idsostenimento", typeof(int),false);
	tsostenimento.defineColumn("idsostenimentoesito", typeof(int),false);
	tsostenimento.defineColumn("idtitolostudio", typeof(int));
	tsostenimento.defineColumn("insecod", typeof(string));
	tsostenimento.defineColumn("insedesc", typeof(string));
	tsostenimento.defineColumn("livello", typeof(string));
	tsostenimento.defineColumn("lt", typeof(DateTime),false);
	tsostenimento.defineColumn("lu", typeof(string),false);
	tsostenimento.defineColumn("paridsostenimento", typeof(int));
	tsostenimento.defineColumn("protanno", typeof(int));
	tsostenimento.defineColumn("protnumero", typeof(int));
	tsostenimento.defineColumn("voto", typeof(decimal));
	tsostenimento.defineColumn("votolode", typeof(string));
	tsostenimento.defineColumn("votosu", typeof(int));
	Tables.Add(tsostenimento);
	tsostenimento.defineKey("idappello", "idprova", "idreg", "idsostenimento");

	//////////////////// COMMISSREGISTRY_DOCENTI /////////////////////////////////
	var tcommissregistry_docenti= new MetaTable("commissregistry_docenti");
	tcommissregistry_docenti.defineColumn("ct", typeof(DateTime),false);
	tcommissregistry_docenti.defineColumn("cu", typeof(string),false);
	tcommissregistry_docenti.defineColumn("idappello", typeof(int),false);
	tcommissregistry_docenti.defineColumn("idcommiss", typeof(int),false);
	tcommissregistry_docenti.defineColumn("idcommissmembrokind", typeof(int));
	tcommissregistry_docenti.defineColumn("idcorsostudio", typeof(int));
	tcommissregistry_docenti.defineColumn("iddidprog", typeof(int));
	tcommissregistry_docenti.defineColumn("idprova", typeof(int),false);
	tcommissregistry_docenti.defineColumn("idreg_docenti", typeof(int),false);
	tcommissregistry_docenti.defineColumn("lt", typeof(DateTime),false);
	tcommissregistry_docenti.defineColumn("lu", typeof(string),false);
	Tables.Add(tcommissregistry_docenti);
	tcommissregistry_docenti.defineKey("idappello", "idcommiss", "idprova", "idreg_docenti");

	//////////////////// COMMISS /////////////////////////////////
	var tcommiss= new MetaTable("commiss");
	tcommiss.defineColumn("ct", typeof(DateTime),false);
	tcommiss.defineColumn("cu", typeof(string),false);
	tcommiss.defineColumn("idappello", typeof(int),false);
	tcommiss.defineColumn("idcommiss", typeof(int),false);
	tcommiss.defineColumn("idcorsostudio", typeof(int));
	tcommiss.defineColumn("iddidprog", typeof(int));
	tcommiss.defineColumn("idprova", typeof(int),false);
	tcommiss.defineColumn("idreg_docenti", typeof(int),false);
	tcommiss.defineColumn("lt", typeof(DateTime),false);
	tcommiss.defineColumn("lu", typeof(string),false);
	Tables.Add(tcommiss);
	tcommiss.defineKey("idappello", "idcommiss", "idprova");

	//////////////////// PRENOTAPPELLO /////////////////////////////////
	var tprenotappello= new MetaTable("prenotappello");
	tprenotappello.defineColumn("ct", typeof(DateTime),false);
	tprenotappello.defineColumn("cu", typeof(string),false);
	tprenotappello.defineColumn("data", typeof(DateTime),false);
	tprenotappello.defineColumn("idappello", typeof(int),false);
	tprenotappello.defineColumn("idattivform", typeof(int),false);
	tprenotappello.defineColumn("idiscrizione", typeof(int),false);
	tprenotappello.defineColumn("idpianostudio", typeof(int),false);
	tprenotappello.defineColumn("idpianostudioattivform", typeof(int),false);
	tprenotappello.defineColumn("idprenotappello", typeof(int),false);
	tprenotappello.defineColumn("idprova", typeof(int),false);
	tprenotappello.defineColumn("idreg", typeof(int),false);
	tprenotappello.defineColumn("lt", typeof(DateTime),false);
	tprenotappello.defineColumn("lu", typeof(string),false);
	Tables.Add(tprenotappello);
	tprenotappello.defineKey("idappello", "idattivform", "idiscrizione", "idpianostudio", "idpianostudioattivform", "idprenotappello", "idprova", "idreg");

	//////////////////// PROVA /////////////////////////////////
	var tprova= new MetaTable("prova");
	tprova.defineColumn("ct", typeof(DateTime),false);
	tprova.defineColumn("cu", typeof(string),false);
	tprova.defineColumn("idappello", typeof(int),false);
	tprova.defineColumn("idattivform", typeof(int));
	tprova.defineColumn("idcorsostudio", typeof(int));
	tprova.defineColumn("iddidprog", typeof(int));
	tprova.defineColumn("idprova", typeof(int),false);
	tprova.defineColumn("idquestionario", typeof(int));
	tprova.defineColumn("idvalutazionekind", typeof(int));
	tprova.defineColumn("lt", typeof(DateTime),false);
	tprova.defineColumn("lu", typeof(string),false);
	tprova.defineColumn("programma", typeof(string));
	tprova.defineColumn("start", typeof(DateTime),false);
	tprova.defineColumn("stop", typeof(DateTime),false);
	tprova.defineColumn("title", typeof(string),false);
	Tables.Add(tprova);
	tprova.defineKey("idappello", "idprova");

	//////////////////// APPELLOKINDDEFAULTVIEW /////////////////////////////////
	var tappellokinddefaultview= new MetaTable("appellokinddefaultview");
	tappellokinddefaultview.defineColumn("appellokind_active", typeof(string));
	tappellokinddefaultview.defineColumn("appellokind_description", typeof(string));
	tappellokinddefaultview.defineColumn("appellokind_lt", typeof(DateTime),false);
	tappellokinddefaultview.defineColumn("appellokind_lu", typeof(string),false);
	tappellokinddefaultview.defineColumn("appellokind_sortcode", typeof(int),false);
	tappellokinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tappellokinddefaultview.defineColumn("idappellokind", typeof(int),false);
	tappellokinddefaultview.defineColumn("title", typeof(string),false);
	Tables.Add(tappellokinddefaultview);
	tappellokinddefaultview.defineKey("idappellokind");

	//////////////////// ANNOACCADEMICO /////////////////////////////////
	var tannoaccademico= new MetaTable("annoaccademico");
	tannoaccademico.defineColumn("aa", typeof(string),false);
	Tables.Add(tannoaccademico);
	tannoaccademico.defineKey("aa");

	//////////////////// APPELLO /////////////////////////////////
	var tappello= new MetaTable("appello");
	tappello.defineColumn("aa", typeof(string));
	tappello.defineColumn("basevoto", typeof(int));
	tappello.defineColumn("cftoend", typeof(decimal));
	tappello.defineColumn("ct", typeof(DateTime),false);
	tappello.defineColumn("cu", typeof(string),false);
	tappello.defineColumn("description", typeof(string));
	tappello.defineColumn("esteroend", typeof(DateTime));
	tappello.defineColumn("esterostart", typeof(DateTime));
	tappello.defineColumn("idappello", typeof(int),false);
	tappello.defineColumn("idappelloazionekind", typeof(int));
	tappello.defineColumn("idappellokind", typeof(int));
	tappello.defineColumn("idsessione", typeof(int));
	tappello.defineColumn("idstudprenotkind", typeof(int));
	tappello.defineColumn("lavoratori", typeof(string));
	tappello.defineColumn("lt", typeof(DateTime),false);
	tappello.defineColumn("lu", typeof(string),false);
	tappello.defineColumn("minanniiscr", typeof(int));
	tappello.defineColumn("minvoto", typeof(int));
	tappello.defineColumn("passaggio", typeof(string));
	tappello.defineColumn("penotend", typeof(DateTime));
	tappello.defineColumn("posti", typeof(int));
	tappello.defineColumn("prenotstart", typeof(DateTime));
	tappello.defineColumn("prointermedia", typeof(string));
	tappello.defineColumn("publicato", typeof(string));
	tappello.defineColumn("surmanestop", typeof(string));
	tappello.defineColumn("surnamestart", typeof(string));
	Tables.Add(tappello);
	tappello.defineKey("idappello");

	#endregion


	#region DataRelation creation
	var cPar = new []{studprenotkinddefaultview.Columns["idstudprenotkind"]};
	var cChild = new []{appello.Columns["idstudprenotkind"]};
	Relations.Add(new DataRelation("FK_appello_studprenotkinddefaultview_idstudprenotkind",cPar,cChild,false));

	cPar = new []{appelloazionekinddefaultview.Columns["idappelloazionekind"]};
	cChild = new []{appello.Columns["idappelloazionekind"]};
	Relations.Add(new DataRelation("FK_appello_appelloazionekinddefaultview_idappelloazionekind",cPar,cChild,false));

	cPar = new []{sessionedefaultview.Columns["idsessione"]};
	cChild = new []{appello.Columns["idsessione"]};
	Relations.Add(new DataRelation("FK_appello_sessionedefaultview_idsessione",cPar,cChild,false));

	cPar = new []{appello.Columns["idappello"]};
	cChild = new []{prova.Columns["idappello"]};
	Relations.Add(new DataRelation("FK_prova_appello_idappello",cPar,cChild,false));

	cPar = new []{prova.Columns["idappello"], prova.Columns["idprova"], prova.Columns["idattivform"]};
	cChild = new []{sostenimento.Columns["idappello"], sostenimento.Columns["idprova"], sostenimento.Columns["idattivform"]};
	Relations.Add(new DataRelation("FK_sostenimento_prova_idappello-idprova-idattivform",cPar,cChild,false));

	cPar = new []{prova.Columns["idappello"], prova.Columns["idprova"]};
	cChild = new []{commiss.Columns["idappello"], commiss.Columns["idprova"]};
	Relations.Add(new DataRelation("FK_commiss_prova_idappello-idprova",cPar,cChild,false));

	cPar = new []{commiss.Columns["idappello"], commiss.Columns["idcommiss"], commiss.Columns["idprova"]};
	cChild = new []{commissregistry_docenti.Columns["idappello"], commissregistry_docenti.Columns["idcommiss"], commissregistry_docenti.Columns["idprova"]};
	Relations.Add(new DataRelation("FK_commissregistry_docenti_commiss_idappello-idcommiss-idprova",cPar,cChild,false));

	cPar = new []{prova.Columns["idappello"], prova.Columns["idprova"]};
	cChild = new []{prenotappello.Columns["idappello"], prenotappello.Columns["idprova"]};
	Relations.Add(new DataRelation("FK_prenotappello_prova_idappello-idprova",cPar,cChild,false));

	cPar = new []{appellokinddefaultview.Columns["idappellokind"]};
	cChild = new []{appello.Columns["idappellokind"]};
	Relations.Add(new DataRelation("FK_appello_appellokinddefaultview_idappellokind",cPar,cChild,false));

	cPar = new []{annoaccademico.Columns["aa"]};
	cChild = new []{appello.Columns["aa"]};
	Relations.Add(new DataRelation("FK_appello_annoaccademico_aa",cPar,cChild,false));

	#endregion

}
}
}
