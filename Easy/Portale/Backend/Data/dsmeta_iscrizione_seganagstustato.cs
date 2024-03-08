
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
[System.Xml.Serialization.XmlRoot("dsmeta_iscrizione_seganagstustato"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_iscrizione_seganagstustato: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sostenimentoesito 		=> (MetaTable)Tables["sostenimentoesito"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sostenimento_alias4 		=> (MetaTable)Tables["sostenimento_alias4"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogstatoview 		=> (MetaTable)Tables["didprogstatoview"];

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
public dsmeta_iscrizione_seganagstustato(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_iscrizione_seganagstustato (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_iscrizione_seganagstustato";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_iscrizione_seganagstustato.xsd";

	#region create DataTables
	//////////////////// SOSTENIMENTOESITO /////////////////////////////////
	var tsostenimentoesito= new MetaTable("sostenimentoesito");
	tsostenimentoesito.defineColumn("idsostenimentoesito", typeof(int),false);
	tsostenimentoesito.defineColumn("title", typeof(string),false);
	Tables.Add(tsostenimentoesito);
	tsostenimentoesito.defineKey("idsostenimentoesito");

	//////////////////// SOSTENIMENTO_ALIAS4 /////////////////////////////////
	var tsostenimento_alias4= new MetaTable("sostenimento_alias4");
	tsostenimento_alias4.defineColumn("ct", typeof(DateTime),false);
	tsostenimento_alias4.defineColumn("cu", typeof(string),false);
	tsostenimento_alias4.defineColumn("data", typeof(DateTime),false);
	tsostenimento_alias4.defineColumn("domande", typeof(string));
	tsostenimento_alias4.defineColumn("ects", typeof(int));
	tsostenimento_alias4.defineColumn("giudizio", typeof(string));
	tsostenimento_alias4.defineColumn("idappello", typeof(int));
	tsostenimento_alias4.defineColumn("idattivform", typeof(int));
	tsostenimento_alias4.defineColumn("idcorsostudio", typeof(int),false);
	tsostenimento_alias4.defineColumn("iddidprog", typeof(int),false);
	tsostenimento_alias4.defineColumn("idiscrizione", typeof(int),false);
	tsostenimento_alias4.defineColumn("idprova", typeof(int),false);
	tsostenimento_alias4.defineColumn("idreg", typeof(int),false);
	tsostenimento_alias4.defineColumn("idsostenimento", typeof(int),false);
	tsostenimento_alias4.defineColumn("idsostenimentoesito", typeof(int),false);
	tsostenimento_alias4.defineColumn("idtitolostudio", typeof(int));
	tsostenimento_alias4.defineColumn("insecod", typeof(string));
	tsostenimento_alias4.defineColumn("insedesc", typeof(string));
	tsostenimento_alias4.defineColumn("livello", typeof(string));
	tsostenimento_alias4.defineColumn("lt", typeof(DateTime),false);
	tsostenimento_alias4.defineColumn("lu", typeof(string),false);
	tsostenimento_alias4.defineColumn("paridsostenimento", typeof(int));
	tsostenimento_alias4.defineColumn("protanno", typeof(int));
	tsostenimento_alias4.defineColumn("protnumero", typeof(int));
	tsostenimento_alias4.defineColumn("voto", typeof(decimal));
	tsostenimento_alias4.defineColumn("votolode", typeof(string));
	tsostenimento_alias4.defineColumn("votosu", typeof(int));
	tsostenimento_alias4.defineColumn("!idsostenimentoesito_sostenimentoesito_title", typeof(string));
	tsostenimento_alias4.ExtendedProperties["TableForReading"]="sostenimento";
	Tables.Add(tsostenimento_alias4);
	tsostenimento_alias4.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idprova", "idreg", "idsostenimento");

	//////////////////// DIDPROGSTATOVIEW /////////////////////////////////
	var tdidprogstatoview= new MetaTable("didprogstatoview");
	tdidprogstatoview.defineColumn("aa", typeof(string));
	tdidprogstatoview.defineColumn("corsostudio_annoistituz", typeof(int));
	tdidprogstatoview.defineColumn("corsostudio_title", typeof(string));
	tdidprogstatoview.defineColumn("didprog_annosolare", typeof(int));
	tdidprogstatoview.defineColumn("didprog_attribdebiti", typeof(string));
	tdidprogstatoview.defineColumn("didprog_ciclo", typeof(int));
	tdidprogstatoview.defineColumn("didprog_codice", typeof(string));
	tdidprogstatoview.defineColumn("didprog_codicemiur", typeof(string));
	tdidprogstatoview.defineColumn("didprog_dataconsmaxiscr", typeof(DateTime));
	tdidprogstatoview.defineColumn("didprog_freqobbl", typeof(string));
	tdidprogstatoview.defineColumn("didprog_idareadidattica", typeof(int));
	tdidprogstatoview.defineColumn("didprog_idconvenzione", typeof(int));
	tdidprogstatoview.defineColumn("didprog_iddidprognumchiusokind", typeof(int));
	tdidprogstatoview.defineColumn("didprog_iddidprogsuddannokind", typeof(int));
	tdidprogstatoview.defineColumn("didprog_iderogazkind", typeof(int));
	tdidprogstatoview.defineColumn("didprog_idnation_lang", typeof(int));
	tdidprogstatoview.defineColumn("didprog_idnation_lang2", typeof(int));
	tdidprogstatoview.defineColumn("didprog_idnation_langvis", typeof(int));
	tdidprogstatoview.defineColumn("didprog_idreg_docenti", typeof(int));
	tdidprogstatoview.defineColumn("didprog_idtitolokind", typeof(int));
	tdidprogstatoview.defineColumn("didprog_immatoltreauth", typeof(string));
	tdidprogstatoview.defineColumn("didprog_modaccesso", typeof(string));
	tdidprogstatoview.defineColumn("didprog_modaccesso_en", typeof(string));
	tdidprogstatoview.defineColumn("didprog_obbformativi", typeof(string));
	tdidprogstatoview.defineColumn("didprog_obbformativi_en", typeof(string));
	tdidprogstatoview.defineColumn("didprog_preimmatoltreauth", typeof(string));
	tdidprogstatoview.defineColumn("didprog_progesamamm", typeof(string));
	tdidprogstatoview.defineColumn("didprog_prospoccupaz", typeof(string));
	tdidprogstatoview.defineColumn("didprog_provafinaledesc", typeof(string));
	tdidprogstatoview.defineColumn("didprog_regolamentotax", typeof(string));
	tdidprogstatoview.defineColumn("didprog_regolamentotaxurl", typeof(string));
	tdidprogstatoview.defineColumn("didprog_startiscrizioni", typeof(DateTime));
	tdidprogstatoview.defineColumn("didprog_stopiscrizioni", typeof(DateTime));
	tdidprogstatoview.defineColumn("didprog_title_en", typeof(string));
	tdidprogstatoview.defineColumn("didprog_utenzasost", typeof(int));
	tdidprogstatoview.defineColumn("didprog_website", typeof(string));
	tdidprogstatoview.defineColumn("didprognumchiusokind_title", typeof(string));
	tdidprogstatoview.defineColumn("dropdown_title", typeof(string),false);
	tdidprogstatoview.defineColumn("graduatoria_title", typeof(string));
	tdidprogstatoview.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogstatoview.defineColumn("iddidprog", typeof(int),false);
	tdidprogstatoview.defineColumn("idgraduatoria", typeof(int));
	tdidprogstatoview.defineColumn("idsede", typeof(int));
	tdidprogstatoview.defineColumn("idsessione", typeof(int));
	tdidprogstatoview.defineColumn("sede_title", typeof(string));
	tdidprogstatoview.defineColumn("sessione_start", typeof(DateTime));
	tdidprogstatoview.defineColumn("sessione_stop", typeof(DateTime));
	tdidprogstatoview.defineColumn("sessionekind_title", typeof(string));
	tdidprogstatoview.defineColumn("title", typeof(string));
	tdidprogstatoview.defineColumn("titolokind_title", typeof(string));
	Tables.Add(tdidprogstatoview);
	tdidprogstatoview.defineKey("iddidprog");

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
	var cChild = new []{sostenimento_alias4.Columns["idcorsostudio"], sostenimento_alias4.Columns["iddidprog"], sostenimento_alias4.Columns["idiscrizione"], sostenimento_alias4.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_sostenimento_alias4_iscrizione_idcorsostudio-iddidprog-idiscrizione-idreg",cPar,cChild,false));

	cPar = new []{sostenimentoesito.Columns["idsostenimentoesito"]};
	cChild = new []{sostenimento_alias4.Columns["idsostenimentoesito"]};
	Relations.Add(new DataRelation("FK_sostenimento_alias4_sostenimentoesito_idsostenimentoesito",cPar,cChild,false));

	cPar = new []{didprogstatoview.Columns["iddidprog"]};
	cChild = new []{iscrizione.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_iscrizione_didprogstatoview_iddidprog",cPar,cChild,false));

	cPar = new []{annoaccademico.Columns["aa"]};
	cChild = new []{iscrizione.Columns["aa"]};
	Relations.Add(new DataRelation("FK_iscrizione_annoaccademico_aa",cPar,cChild,false));

	#endregion

}
}
}
