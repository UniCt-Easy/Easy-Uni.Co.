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
[System.Xml.Serialization.XmlRoot("dsmeta_iscrizione_stuaccesso"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_iscrizione_stuaccesso: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sostenimentoesito 		=> (MetaTable)Tables["sostenimentoesito"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry 		=> (MetaTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sostenimento 		=> (MetaTable)Tables["sostenimento"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable prova 		=> (MetaTable)Tables["prova"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogingressoview 		=> (MetaTable)Tables["didprogingressoview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico 		=> (MetaTable)Tables["annoaccademico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizione 		=> (MetaTable)Tables["iscrizione"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_iscrizione_stuaccesso(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_iscrizione_stuaccesso (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_iscrizione_stuaccesso";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_iscrizione_stuaccesso.xsd";

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
	tprova.defineColumn("!sostenimento", typeof(string));
	tprova.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tprova);
	tprova.defineKey("idappello", "idprova");

	//////////////////// DIDPROGINGRESSOVIEW /////////////////////////////////
	var tdidprogingressoview= new MetaTable("didprogingressoview");
	tdidprogingressoview.defineColumn("aa", typeof(string));
	tdidprogingressoview.defineColumn("appellokind_title", typeof(string));
	tdidprogingressoview.defineColumn("corsostudio_annoistituz", typeof(int));
	tdidprogingressoview.defineColumn("corsostudio_title", typeof(string));
	tdidprogingressoview.defineColumn("didprog_annosolare", typeof(int));
	tdidprogingressoview.defineColumn("didprog_attribdebiti", typeof(string));
	tdidprogingressoview.defineColumn("didprog_ciclo", typeof(int));
	tdidprogingressoview.defineColumn("didprog_codice", typeof(string));
	tdidprogingressoview.defineColumn("didprog_codicemiur", typeof(string));
	tdidprogingressoview.defineColumn("didprog_dataconsmaxiscr", typeof(DateTime));
	tdidprogingressoview.defineColumn("didprog_freqobbl", typeof(string));
	tdidprogingressoview.defineColumn("didprog_idareadidattica", typeof(int));
	tdidprogingressoview.defineColumn("didprog_idconvenzione", typeof(int));
	tdidprogingressoview.defineColumn("didprog_idcorsostudiokind", typeof(int));
	tdidprogingressoview.defineColumn("didprog_idcorsostudiolivello", typeof(int));
	tdidprogingressoview.defineColumn("didprog_iddidprognumchiusokind", typeof(int));
	tdidprogingressoview.defineColumn("didprog_iddidprogsuddannokind", typeof(int));
	tdidprogingressoview.defineColumn("didprog_iderogazkind", typeof(int));
	tdidprogingressoview.defineColumn("didprog_idreg_docenti", typeof(int));
	tdidprogingressoview.defineColumn("didprog_idtitolokind", typeof(int));
	tdidprogingressoview.defineColumn("didprog_immatoltreauth", typeof(string));
	tdidprogingressoview.defineColumn("didprog_modaccesso", typeof(string));
	tdidprogingressoview.defineColumn("didprog_modaccesso_en", typeof(string));
	tdidprogingressoview.defineColumn("didprog_obbformativi", typeof(string));
	tdidprogingressoview.defineColumn("didprog_obbformativi_en", typeof(string));
	tdidprogingressoview.defineColumn("didprog_preimmatoltreauth", typeof(string));
	tdidprogingressoview.defineColumn("didprog_progesamamm", typeof(string));
	tdidprogingressoview.defineColumn("didprog_prospoccupaz", typeof(string));
	tdidprogingressoview.defineColumn("didprog_provafinaledesc", typeof(string));
	tdidprogingressoview.defineColumn("didprog_regolamentotax", typeof(string));
	tdidprogingressoview.defineColumn("didprog_regolamentotaxurl", typeof(string));
	tdidprogingressoview.defineColumn("didprog_startiscrizioni", typeof(DateTime));
	tdidprogingressoview.defineColumn("didprog_stopiscrizioni", typeof(DateTime));
	tdidprogingressoview.defineColumn("didprog_title_en", typeof(string));
	tdidprogingressoview.defineColumn("didprog_utenzasost", typeof(int));
	tdidprogingressoview.defineColumn("didprog_website", typeof(string));
	tdidprogingressoview.defineColumn("didprognumchiusokind_title", typeof(string));
	tdidprogingressoview.defineColumn("dropdown_title", typeof(string),false);
	tdidprogingressoview.defineColumn("geo_nationlang_lang", typeof(string));
	tdidprogingressoview.defineColumn("geo_nationlang2_lang", typeof(string));
	tdidprogingressoview.defineColumn("geo_nationlangvis_lang", typeof(string));
	tdidprogingressoview.defineColumn("graduatoria_title", typeof(string));
	tdidprogingressoview.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogingressoview.defineColumn("iddidprog", typeof(int),false);
	tdidprogingressoview.defineColumn("idgraduatoria", typeof(int));
	tdidprogingressoview.defineColumn("idnation_lang", typeof(int));
	tdidprogingressoview.defineColumn("idnation_lang2", typeof(int));
	tdidprogingressoview.defineColumn("idnation_langvis", typeof(int));
	tdidprogingressoview.defineColumn("idsede", typeof(int));
	tdidprogingressoview.defineColumn("idsessione", typeof(int));
	tdidprogingressoview.defineColumn("sede_title", typeof(string));
	tdidprogingressoview.defineColumn("sessione_idappellokind", typeof(int));
	tdidprogingressoview.defineColumn("sessione_idsessionekind", typeof(int));
	tdidprogingressoview.defineColumn("sessione_start", typeof(DateTime));
	tdidprogingressoview.defineColumn("sessione_stop", typeof(DateTime));
	tdidprogingressoview.defineColumn("sessionekind_title", typeof(string));
	tdidprogingressoview.defineColumn("title", typeof(string));
	tdidprogingressoview.defineColumn("titolokind_title", typeof(string));
	Tables.Add(tdidprogingressoview);
	tdidprogingressoview.defineKey("idcorsostudio", "iddidprog");

	//////////////////// ANNOACCADEMICO /////////////////////////////////
	var tannoaccademico= new MetaTable("annoaccademico");
	tannoaccademico.defineColumn("aa", typeof(string),false);
	Tables.Add(tannoaccademico);
	tannoaccademico.defineKey("aa");

	//////////////////// ISCRIZIONE /////////////////////////////////
	var tiscrizione= new MetaTable("iscrizione");
	tiscrizione.defineColumn("aa", typeof(string),false);
	tiscrizione.defineColumn("anno", typeof(int));
	tiscrizione.defineColumn("ct", typeof(DateTime),false);
	tiscrizione.defineColumn("cu", typeof(string),false);
	tiscrizione.defineColumn("data", typeof(DateTime));
	tiscrizione.defineColumn("idcorsostudio", typeof(int),false);
	tiscrizione.defineColumn("iddidprog", typeof(int),false);
	tiscrizione.defineColumn("idiscrizione", typeof(int),false);
	tiscrizione.defineColumn("idreg", typeof(int),false);
	tiscrizione.defineColumn("lt", typeof(DateTime),false);
	tiscrizione.defineColumn("lu", typeof(string),false);
	tiscrizione.defineColumn("matricola", typeof(string));
	Tables.Add(tiscrizione);
	tiscrizione.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{iscrizione.Columns["idcorsostudio"], iscrizione.Columns["iddidprog"]};
	var cChild = new []{prova.Columns["idcorsostudio"], prova.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_prova_iscrizione_idcorsostudio-iddidprog",cPar,cChild,false));

	cPar = new []{prova.Columns["idappello"], prova.Columns["idprova"]};
	cChild = new []{sostenimento.Columns["idappello"], sostenimento.Columns["idprova"]};
	Relations.Add(new DataRelation("FK_sostenimento_prova_idappello-idprova",cPar,cChild,false));

	cPar = new []{sostenimentoesito.Columns["idsostenimentoesito"]};
	cChild = new []{sostenimento.Columns["idsostenimentoesito"]};
	Relations.Add(new DataRelation("FK_sostenimento_sostenimentoesito_idsostenimentoesito",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{sostenimento.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_sostenimento_registry_idreg",cPar,cChild,false));

	cPar = new []{didprogingressoview.Columns["iddidprog"]};
	cChild = new []{iscrizione.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_iscrizione_didprogingressoview_iddidprog",cPar,cChild,false));

	cPar = new []{annoaccademico.Columns["aa"]};
	cChild = new []{iscrizione.Columns["aa"]};
	Relations.Add(new DataRelation("FK_iscrizione_annoaccademico_aa",cPar,cChild,false));

	#endregion

}
}
}
