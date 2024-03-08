
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
[System.Xml.Serialization.XmlRoot("dsmeta_iscrizione_seganagstumast"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_iscrizione_seganagstumast: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sostenimentoesito 		=> (MetaTable)Tables["sostenimentoesito"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sostenimento_alias3 		=> (MetaTable)Tables["sostenimento_alias3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogdotmasview 		=> (MetaTable)Tables["didprogdotmasview"];

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
public dsmeta_iscrizione_seganagstumast(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_iscrizione_seganagstumast (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_iscrizione_seganagstumast";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_iscrizione_seganagstumast.xsd";

	#region create DataTables
	//////////////////// SOSTENIMENTOESITO /////////////////////////////////
	var tsostenimentoesito= new MetaTable("sostenimentoesito");
	tsostenimentoesito.defineColumn("idsostenimentoesito", typeof(int),false);
	tsostenimentoesito.defineColumn("title", typeof(string),false);
	Tables.Add(tsostenimentoesito);
	tsostenimentoesito.defineKey("idsostenimentoesito");

	//////////////////// SOSTENIMENTO_ALIAS3 /////////////////////////////////
	var tsostenimento_alias3= new MetaTable("sostenimento_alias3");
	tsostenimento_alias3.defineColumn("ct", typeof(DateTime),false);
	tsostenimento_alias3.defineColumn("cu", typeof(string),false);
	tsostenimento_alias3.defineColumn("data", typeof(DateTime),false);
	tsostenimento_alias3.defineColumn("domande", typeof(string));
	tsostenimento_alias3.defineColumn("ects", typeof(int));
	tsostenimento_alias3.defineColumn("giudizio", typeof(string));
	tsostenimento_alias3.defineColumn("idappello", typeof(int));
	tsostenimento_alias3.defineColumn("idattivform", typeof(int));
	tsostenimento_alias3.defineColumn("idcorsostudio", typeof(int),false);
	tsostenimento_alias3.defineColumn("iddidprog", typeof(int),false);
	tsostenimento_alias3.defineColumn("idiscrizione", typeof(int),false);
	tsostenimento_alias3.defineColumn("idprova", typeof(int),false);
	tsostenimento_alias3.defineColumn("idreg", typeof(int),false);
	tsostenimento_alias3.defineColumn("idsostenimento", typeof(int),false);
	tsostenimento_alias3.defineColumn("idsostenimentoesito", typeof(int),false);
	tsostenimento_alias3.defineColumn("idtitolostudio", typeof(int));
	tsostenimento_alias3.defineColumn("insecod", typeof(string));
	tsostenimento_alias3.defineColumn("insedesc", typeof(string));
	tsostenimento_alias3.defineColumn("livello", typeof(string));
	tsostenimento_alias3.defineColumn("lt", typeof(DateTime),false);
	tsostenimento_alias3.defineColumn("lu", typeof(string),false);
	tsostenimento_alias3.defineColumn("paridsostenimento", typeof(int));
	tsostenimento_alias3.defineColumn("protanno", typeof(int));
	tsostenimento_alias3.defineColumn("protnumero", typeof(int));
	tsostenimento_alias3.defineColumn("voto", typeof(decimal));
	tsostenimento_alias3.defineColumn("votolode", typeof(string));
	tsostenimento_alias3.defineColumn("votosu", typeof(int));
	tsostenimento_alias3.defineColumn("!idsostenimentoesito_sostenimentoesito_title", typeof(string));
	tsostenimento_alias3.ExtendedProperties["TableForReading"]="sostenimento";
	Tables.Add(tsostenimento_alias3);
	tsostenimento_alias3.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idprova", "idreg", "idsostenimento");

	//////////////////// DIDPROGDOTMASVIEW /////////////////////////////////
	var tdidprogdotmasview= new MetaTable("didprogdotmasview");
	tdidprogdotmasview.defineColumn("aa", typeof(string));
	tdidprogdotmasview.defineColumn("didprog_annosolare", typeof(int));
	tdidprogdotmasview.defineColumn("didprog_attribdebiti", typeof(string));
	tdidprogdotmasview.defineColumn("didprog_ciclo", typeof(int));
	tdidprogdotmasview.defineColumn("didprog_codice", typeof(string));
	tdidprogdotmasview.defineColumn("didprog_codicemiur", typeof(string));
	tdidprogdotmasview.defineColumn("didprog_dataconsmaxiscr", typeof(DateTime));
	tdidprogdotmasview.defineColumn("didprog_freqobbl", typeof(string));
	tdidprogdotmasview.defineColumn("didprog_idareadidattica", typeof(int));
	tdidprogdotmasview.defineColumn("didprog_idconvenzione", typeof(int));
	tdidprogdotmasview.defineColumn("didprog_iddidprognumchiusokind", typeof(int));
	tdidprogdotmasview.defineColumn("didprog_iddidprogsuddannokind", typeof(int));
	tdidprogdotmasview.defineColumn("didprog_iderogazkind", typeof(int));
	tdidprogdotmasview.defineColumn("didprog_idnation_lang2", typeof(int));
	tdidprogdotmasview.defineColumn("didprog_idreg_docenti", typeof(int));
	tdidprogdotmasview.defineColumn("didprog_idsessione", typeof(int));
	tdidprogdotmasview.defineColumn("didprog_idtitolokind", typeof(int));
	tdidprogdotmasview.defineColumn("didprog_immatoltreauth", typeof(string));
	tdidprogdotmasview.defineColumn("didprog_modaccesso", typeof(string));
	tdidprogdotmasview.defineColumn("didprog_modaccesso_en", typeof(string));
	tdidprogdotmasview.defineColumn("didprog_obbformativi", typeof(string));
	tdidprogdotmasview.defineColumn("didprog_obbformativi_en", typeof(string));
	tdidprogdotmasview.defineColumn("didprog_preimmatoltreauth", typeof(string));
	tdidprogdotmasview.defineColumn("didprog_progesamamm", typeof(string));
	tdidprogdotmasview.defineColumn("didprog_prospoccupaz", typeof(string));
	tdidprogdotmasview.defineColumn("didprog_provafinaledesc", typeof(string));
	tdidprogdotmasview.defineColumn("didprog_regolamentotax", typeof(string));
	tdidprogdotmasview.defineColumn("didprog_regolamentotaxurl", typeof(string));
	tdidprogdotmasview.defineColumn("didprog_startiscrizioni", typeof(DateTime));
	tdidprogdotmasview.defineColumn("didprog_stopiscrizioni", typeof(DateTime));
	tdidprogdotmasview.defineColumn("didprog_title_en", typeof(string));
	tdidprogdotmasview.defineColumn("didprog_utenzasost", typeof(int));
	tdidprogdotmasview.defineColumn("didprog_website", typeof(string));
	tdidprogdotmasview.defineColumn("dropdown_title", typeof(string),false);
	tdidprogdotmasview.defineColumn("geo_nationlang_title", typeof(string));
	tdidprogdotmasview.defineColumn("geo_nationlangvis_title", typeof(string));
	tdidprogdotmasview.defineColumn("graduatoria_title", typeof(string));
	tdidprogdotmasview.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogdotmasview.defineColumn("iddidprog", typeof(int),false);
	tdidprogdotmasview.defineColumn("idgraduatoria", typeof(int));
	tdidprogdotmasview.defineColumn("idnation_lang", typeof(int));
	tdidprogdotmasview.defineColumn("idnation_langvis", typeof(int));
	tdidprogdotmasview.defineColumn("idsede", typeof(int));
	tdidprogdotmasview.defineColumn("sede_title", typeof(string));
	tdidprogdotmasview.defineColumn("title", typeof(string));
	Tables.Add(tdidprogdotmasview);
	tdidprogdotmasview.defineKey("iddidprog");

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
	var cChild = new []{sostenimento_alias3.Columns["idcorsostudio"], sostenimento_alias3.Columns["iddidprog"], sostenimento_alias3.Columns["idiscrizione"], sostenimento_alias3.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_sostenimento_alias3_iscrizione_idcorsostudio-iddidprog-idiscrizione-idreg",cPar,cChild,false));

	cPar = new []{sostenimentoesito.Columns["idsostenimentoesito"]};
	cChild = new []{sostenimento_alias3.Columns["idsostenimentoesito"]};
	Relations.Add(new DataRelation("FK_sostenimento_alias3_sostenimentoesito_idsostenimentoesito",cPar,cChild,false));

	cPar = new []{didprogdotmasview.Columns["iddidprog"]};
	cChild = new []{iscrizione.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_iscrizione_didprogdotmasview_iddidprog",cPar,cChild,false));

	cPar = new []{annoaccademico.Columns["aa"]};
	cChild = new []{iscrizione.Columns["aa"]};
	Relations.Add(new DataRelation("FK_iscrizione_annoaccademico_aa",cPar,cChild,false));

	#endregion

}
}
}
