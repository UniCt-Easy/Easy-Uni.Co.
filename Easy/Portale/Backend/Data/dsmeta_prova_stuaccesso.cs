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
[System.Xml.Serialization.XmlRoot("dsmeta_prova_stuaccesso"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_prova_stuaccesso: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sostenimentoesito 		=> (MetaTable)Tables["sostenimentoesito"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry 		=> (MetaTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sostenimento 		=> (MetaTable)Tables["sostenimento"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable valutazionekinddefaultview 		=> (MetaTable)Tables["valutazionekinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable questionariodefaultview 		=> (MetaTable)Tables["questionariodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable prova 		=> (MetaTable)Tables["prova"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_prova_stuaccesso(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_prova_stuaccesso (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_prova_stuaccesso";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_prova_stuaccesso.xsd";

	#region create DataTables
	//////////////////// SOSTENIMENTOESITO /////////////////////////////////
	var tsostenimentoesito= new MetaTable("sostenimentoesito");
	tsostenimentoesito.defineColumn("active", typeof(string),false);
	tsostenimentoesito.defineColumn("idsostenimentoesito", typeof(int),false);
	tsostenimentoesito.defineColumn("title", typeof(string),false);
	Tables.Add(tsostenimentoesito);
	tsostenimentoesito.defineKey("idsostenimentoesito");

	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new MetaTable("registry");
	tregistry.defineColumn("active", typeof(string),false);
	tregistry.defineColumn("idreg", typeof(int),false);
	tregistry.defineColumn("title", typeof(string),false);
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// SOSTENIMENTO /////////////////////////////////
	var tsostenimento= new MetaTable("sostenimento");
	tsostenimento.defineColumn("ct", typeof(DateTime),false);
	tsostenimento.defineColumn("cu", typeof(string),false);
	tsostenimento.defineColumn("data", typeof(DateTime),false);
	tsostenimento.defineColumn("domande", typeof(string));
	tsostenimento.defineColumn("ects", typeof(int));
	tsostenimento.defineColumn("giudizio", typeof(string));
	tsostenimento.defineColumn("idappello", typeof(int));
	tsostenimento.defineColumn("idattivform", typeof(int));
	tsostenimento.defineColumn("idcorsostudio", typeof(int),false);
	tsostenimento.defineColumn("iddidprog", typeof(int),false);
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
	tsostenimento.defineColumn("!idreg_registry_title", typeof(string));
	tsostenimento.defineColumn("!idsostenimentoesito_sostenimentoesito_title", typeof(string));
	tsostenimento.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tsostenimento);
	tsostenimento.defineKey("idcorsostudio", "iddidprog", "idprova", "idreg", "idsostenimento");

	//////////////////// VALUTAZIONEKINDDEFAULTVIEW /////////////////////////////////
	var tvalutazionekinddefaultview= new MetaTable("valutazionekinddefaultview");
	tvalutazionekinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tvalutazionekinddefaultview.defineColumn("idvalutazionekind", typeof(int),false);
	tvalutazionekinddefaultview.defineColumn("title", typeof(string),false);
	tvalutazionekinddefaultview.defineColumn("valutazionekind_active", typeof(string));
	tvalutazionekinddefaultview.defineColumn("valutazionekind_ct", typeof(DateTime),false);
	tvalutazionekinddefaultview.defineColumn("valutazionekind_cu", typeof(string),false);
	tvalutazionekinddefaultview.defineColumn("valutazionekind_description", typeof(string));
	tvalutazionekinddefaultview.defineColumn("valutazionekind_lt", typeof(DateTime),false);
	tvalutazionekinddefaultview.defineColumn("valutazionekind_lu", typeof(string),false);
	tvalutazionekinddefaultview.defineColumn("valutazionekind_sortcode", typeof(int),false);
	Tables.Add(tvalutazionekinddefaultview);
	tvalutazionekinddefaultview.defineKey("idvalutazionekind");

	//////////////////// QUESTIONARIODEFAULTVIEW /////////////////////////////////
	var tquestionariodefaultview= new MetaTable("questionariodefaultview");
	tquestionariodefaultview.defineColumn("dropdown_title", typeof(string),false);
	tquestionariodefaultview.defineColumn("idquestionario", typeof(int),false);
	Tables.Add(tquestionariodefaultview);
	tquestionariodefaultview.defineKey("idquestionario");

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

	#endregion


	#region DataRelation creation
	var cPar = new []{prova.Columns["idappello"], prova.Columns["idprova"]};
	var cChild = new []{sostenimento.Columns["idappello"], sostenimento.Columns["idprova"]};
	Relations.Add(new DataRelation("FK_sostenimento_prova_idappello-idprova",cPar,cChild,false));

	cPar = new []{sostenimentoesito.Columns["idsostenimentoesito"]};
	cChild = new []{sostenimento.Columns["idsostenimentoesito"]};
	Relations.Add(new DataRelation("FK_sostenimento_sostenimentoesito_idsostenimentoesito",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{sostenimento.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_sostenimento_registry_idreg",cPar,cChild,false));

	cPar = new []{valutazionekinddefaultview.Columns["idvalutazionekind"]};
	cChild = new []{prova.Columns["idvalutazionekind"]};
	Relations.Add(new DataRelation("FK_prova_valutazionekinddefaultview_idvalutazionekind",cPar,cChild,false));

	cPar = new []{questionariodefaultview.Columns["idquestionario"]};
	cChild = new []{prova.Columns["idquestionario"]};
	Relations.Add(new DataRelation("FK_prova_questionariodefaultview_idquestionario",cPar,cChild,false));

	#endregion

}
}
}
