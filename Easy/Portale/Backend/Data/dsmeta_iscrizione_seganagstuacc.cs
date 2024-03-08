
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
[System.Xml.Serialization.XmlRoot("dsmeta_iscrizione_seganagstuacc"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_iscrizione_seganagstuacc: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sostenimentoesito 		=> (MetaTable)Tables["sostenimentoesito"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sostenimento_alias2 		=> (MetaTable)Tables["sostenimento_alias2"];

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
public dsmeta_iscrizione_seganagstuacc(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_iscrizione_seganagstuacc (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_iscrizione_seganagstuacc";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_iscrizione_seganagstuacc.xsd";

	#region create DataTables
	//////////////////// SOSTENIMENTOESITO /////////////////////////////////
	var tsostenimentoesito= new MetaTable("sostenimentoesito");
	tsostenimentoesito.defineColumn("idsostenimentoesito", typeof(int),false);
	tsostenimentoesito.defineColumn("title", typeof(string),false);
	Tables.Add(tsostenimentoesito);
	tsostenimentoesito.defineKey("idsostenimentoesito");

	//////////////////// SOSTENIMENTO_ALIAS2 /////////////////////////////////
	var tsostenimento_alias2= new MetaTable("sostenimento_alias2");
	tsostenimento_alias2.defineColumn("ct", typeof(DateTime),false);
	tsostenimento_alias2.defineColumn("cu", typeof(string),false);
	tsostenimento_alias2.defineColumn("data", typeof(DateTime),false);
	tsostenimento_alias2.defineColumn("domande", typeof(string));
	tsostenimento_alias2.defineColumn("ects", typeof(int));
	tsostenimento_alias2.defineColumn("giudizio", typeof(string));
	tsostenimento_alias2.defineColumn("idappello", typeof(int));
	tsostenimento_alias2.defineColumn("idattivform", typeof(int));
	tsostenimento_alias2.defineColumn("idcorsostudio", typeof(int),false);
	tsostenimento_alias2.defineColumn("iddidprog", typeof(int),false);
	tsostenimento_alias2.defineColumn("idiscrizione", typeof(int),false);
	tsostenimento_alias2.defineColumn("idprova", typeof(int),false);
	tsostenimento_alias2.defineColumn("idreg", typeof(int),false);
	tsostenimento_alias2.defineColumn("idsostenimento", typeof(int),false);
	tsostenimento_alias2.defineColumn("idsostenimentoesito", typeof(int),false);
	tsostenimento_alias2.defineColumn("idtitolostudio", typeof(int));
	tsostenimento_alias2.defineColumn("insecod", typeof(string));
	tsostenimento_alias2.defineColumn("insedesc", typeof(string));
	tsostenimento_alias2.defineColumn("livello", typeof(string));
	tsostenimento_alias2.defineColumn("lt", typeof(DateTime),false);
	tsostenimento_alias2.defineColumn("lu", typeof(string),false);
	tsostenimento_alias2.defineColumn("paridsostenimento", typeof(int));
	tsostenimento_alias2.defineColumn("protanno", typeof(int));
	tsostenimento_alias2.defineColumn("protnumero", typeof(int));
	tsostenimento_alias2.defineColumn("voto", typeof(decimal));
	tsostenimento_alias2.defineColumn("votolode", typeof(string));
	tsostenimento_alias2.defineColumn("votosu", typeof(int));
	tsostenimento_alias2.defineColumn("!idsostenimentoesito_sostenimentoesito_title", typeof(string));
	tsostenimento_alias2.ExtendedProperties["TableForReading"]="sostenimento";
	Tables.Add(tsostenimento_alias2);
	tsostenimento_alias2.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idprova", "idreg", "idsostenimento");

	//////////////////// DIDPROGINGRESSOVIEW /////////////////////////////////
	var tdidprogingressoview= new MetaTable("didprogingressoview");
	tdidprogingressoview.defineColumn("aa", typeof(string));
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
	tdidprogingressoview.defineColumn("geo_nationlang_title", typeof(string));
	tdidprogingressoview.defineColumn("geo_nationlang2_title", typeof(string));
	tdidprogingressoview.defineColumn("geo_nationlangvis_title", typeof(string));
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
	tdidprogingressoview.defineColumn("sessione_start", typeof(DateTime));
	tdidprogingressoview.defineColumn("sessione_stop", typeof(DateTime));
	tdidprogingressoview.defineColumn("sessionekind_title", typeof(string));
	tdidprogingressoview.defineColumn("title", typeof(string));
	tdidprogingressoview.defineColumn("titolokind_title", typeof(string));
	Tables.Add(tdidprogingressoview);
	tdidprogingressoview.defineKey("iddidprog");

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
	var cPar = new []{iscrizione.Columns["idcorsostudio"], iscrizione.Columns["iddidprog"], iscrizione.Columns["idiscrizione"], iscrizione.Columns["idreg"]};
	var cChild = new []{sostenimento_alias2.Columns["idcorsostudio"], sostenimento_alias2.Columns["iddidprog"], sostenimento_alias2.Columns["idiscrizione"], sostenimento_alias2.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_sostenimento_alias2_iscrizione_idcorsostudio-iddidprog-idiscrizione-idreg",cPar,cChild,false));

	cPar = new []{sostenimentoesito.Columns["idsostenimentoesito"]};
	cChild = new []{sostenimento_alias2.Columns["idsostenimentoesito"]};
	Relations.Add(new DataRelation("FK_sostenimento_alias2_sostenimentoesito_idsostenimentoesito",cPar,cChild,false));

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
