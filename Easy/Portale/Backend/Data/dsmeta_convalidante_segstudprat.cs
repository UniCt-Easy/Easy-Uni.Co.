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
[System.Xml.Serialization.XmlRoot("dsmeta_convalidante_segstudprat"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_convalidante_segstudprat: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tirocinioprogetto 		=> (MetaTable)Tables["tirocinioprogetto"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable changeskinddefaultview 		=> (MetaTable)Tables["changeskinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sostenimentoseganagstuview 		=> (MetaTable)Tables["sostenimentoseganagstuview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable convalidante 		=> (MetaTable)Tables["convalidante"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_convalidante_segstudprat(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_convalidante_segstudprat (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_convalidante_segstudprat";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_convalidante_segstudprat.xsd";

	#region create DataTables
	//////////////////// TIROCINIOPROGETTO /////////////////////////////////
	var ttirocinioprogetto= new MetaTable("tirocinioprogetto");
	ttirocinioprogetto.defineColumn("competenze", typeof(string));
	ttirocinioprogetto.defineColumn("ct", typeof(DateTime),false);
	ttirocinioprogetto.defineColumn("cu", typeof(string),false);
	ttirocinioprogetto.defineColumn("datafineeffettiva", typeof(DateTime));
	ttirocinioprogetto.defineColumn("datafineprevista", typeof(DateTime),false);
	ttirocinioprogetto.defineColumn("datainizioeffettiva", typeof(DateTime));
	ttirocinioprogetto.defineColumn("datainizioprevista", typeof(DateTime),false);
	ttirocinioprogetto.defineColumn("dataverbale", typeof(DateTime));
	ttirocinioprogetto.defineColumn("description", typeof(string),false);
	ttirocinioprogetto.defineColumn("description_en", typeof(string));
	ttirocinioprogetto.defineColumn("idaoo", typeof(int),false);
	ttirocinioprogetto.defineColumn("idreg_docenti", typeof(int),false);
	ttirocinioprogetto.defineColumn("idreg_referente", typeof(int),false);
	ttirocinioprogetto.defineColumn("idreg_studenti", typeof(int),false);
	ttirocinioprogetto.defineColumn("idsede", typeof(int));
	ttirocinioprogetto.defineColumn("idstruttura", typeof(int),false);
	ttirocinioprogetto.defineColumn("idtirociniocandidatura", typeof(int),false);
	ttirocinioprogetto.defineColumn("idtirocinioprogetto", typeof(int),false);
	ttirocinioprogetto.defineColumn("idtirocinioproposto", typeof(int),false);
	ttirocinioprogetto.defineColumn("idtirociniostato", typeof(int),false);
	ttirocinioprogetto.defineColumn("lt", typeof(DateTime),false);
	ttirocinioprogetto.defineColumn("lu", typeof(string),false);
	ttirocinioprogetto.defineColumn("ore", typeof(int),false);
	ttirocinioprogetto.defineColumn("protanno", typeof(int));
	ttirocinioprogetto.defineColumn("protnumero", typeof(int));
	ttirocinioprogetto.defineColumn("tempiaccesso", typeof(string));
	ttirocinioprogetto.defineColumn("title", typeof(string),false);
	ttirocinioprogetto.defineColumn("title_en", typeof(string));
	Tables.Add(ttirocinioprogetto);
	ttirocinioprogetto.defineKey("idreg_referente", "idreg_studenti", "idtirociniocandidatura", "idtirocinioprogetto", "idtirocinioproposto");

	//////////////////// CHANGESKINDDEFAULTVIEW /////////////////////////////////
	var tchangeskinddefaultview= new MetaTable("changeskinddefaultview");
	tchangeskinddefaultview.defineColumn("changes_title", typeof(string));
	tchangeskinddefaultview.defineColumn("changeskind_active", typeof(string));
	tchangeskinddefaultview.defineColumn("changeskind_description", typeof(string));
	tchangeskinddefaultview.defineColumn("changeskind_idchanges", typeof(int));
	tchangeskinddefaultview.defineColumn("changeskind_lt", typeof(DateTime),false);
	tchangeskinddefaultview.defineColumn("changeskind_lu", typeof(string),false);
	tchangeskinddefaultview.defineColumn("changeskind_sortcode", typeof(int),false);
	tchangeskinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tchangeskinddefaultview.defineColumn("idchangeskind", typeof(int),false);
	tchangeskinddefaultview.defineColumn("title", typeof(string),false);
	Tables.Add(tchangeskinddefaultview);
	tchangeskinddefaultview.defineKey("idchangeskind");

	//////////////////// SOSTENIMENTOSEGANAGSTUVIEW /////////////////////////////////
	var tsostenimentoseganagstuview= new MetaTable("sostenimentoseganagstuview");
	tsostenimentoseganagstuview.defineColumn("attivform_title", typeof(string));
	tsostenimentoseganagstuview.defineColumn("dropdown_title", typeof(string),false);
	tsostenimentoseganagstuview.defineColumn("idattivform", typeof(int));
	tsostenimentoseganagstuview.defineColumn("idcorsostudio", typeof(int),false);
	tsostenimentoseganagstuview.defineColumn("iddidprog", typeof(int),false);
	tsostenimentoseganagstuview.defineColumn("idiscrizione", typeof(int),false);
	tsostenimentoseganagstuview.defineColumn("idreg", typeof(int),false);
	tsostenimentoseganagstuview.defineColumn("idsostenimento", typeof(int),false);
	tsostenimentoseganagstuview.defineColumn("sostenimento_ct", typeof(DateTime),false);
	tsostenimentoseganagstuview.defineColumn("sostenimento_cu", typeof(string),false);
	tsostenimentoseganagstuview.defineColumn("sostenimento_data", typeof(DateTime),false);
	tsostenimentoseganagstuview.defineColumn("sostenimento_domande", typeof(string));
	tsostenimentoseganagstuview.defineColumn("sostenimento_ects", typeof(int));
	tsostenimentoseganagstuview.defineColumn("sostenimento_giudizio", typeof(string));
	tsostenimentoseganagstuview.defineColumn("sostenimento_idappello", typeof(int));
	tsostenimentoseganagstuview.defineColumn("sostenimento_idprova", typeof(int));
	tsostenimentoseganagstuview.defineColumn("sostenimento_idsostenimentoesito", typeof(int),false);
	tsostenimentoseganagstuview.defineColumn("sostenimento_idtitolostudio", typeof(int));
	tsostenimentoseganagstuview.defineColumn("sostenimento_insecod", typeof(string));
	tsostenimentoseganagstuview.defineColumn("sostenimento_insedesc", typeof(string));
	tsostenimentoseganagstuview.defineColumn("sostenimento_livello", typeof(string));
	tsostenimentoseganagstuview.defineColumn("sostenimento_lt", typeof(DateTime),false);
	tsostenimentoseganagstuview.defineColumn("sostenimento_lu", typeof(string),false);
	tsostenimentoseganagstuview.defineColumn("sostenimento_paridsostenimento", typeof(int));
	tsostenimentoseganagstuview.defineColumn("sostenimento_protanno", typeof(int));
	tsostenimentoseganagstuview.defineColumn("sostenimento_protnumero", typeof(int));
	tsostenimentoseganagstuview.defineColumn("sostenimento_voto", typeof(decimal));
	tsostenimentoseganagstuview.defineColumn("sostenimento_votolode", typeof(string));
	tsostenimentoseganagstuview.defineColumn("sostenimento_votosu", typeof(int));
	tsostenimentoseganagstuview.defineColumn("sostenimentoesito_title", typeof(string));
	Tables.Add(tsostenimentoseganagstuview);
	tsostenimentoseganagstuview.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idreg", "idsostenimento");

	//////////////////// CONVALIDANTE /////////////////////////////////
	var tconvalidante= new MetaTable("convalidante");
	tconvalidante.defineColumn("changes", typeof(string));
	tconvalidante.defineColumn("changesother", typeof(string));
	tconvalidante.defineColumn("ct", typeof(DateTime),false);
	tconvalidante.defineColumn("cu", typeof(string),false);
	tconvalidante.defineColumn("idchangeskind", typeof(int));
	tconvalidante.defineColumn("idconvalida", typeof(int),false);
	tconvalidante.defineColumn("idconvalidante", typeof(int),false);
	tconvalidante.defineColumn("iddichiar", typeof(int));
	tconvalidante.defineColumn("iddidprog", typeof(int));
	tconvalidante.defineColumn("idiscrizione", typeof(int));
	tconvalidante.defineColumn("idiscrizione_from", typeof(int));
	tconvalidante.defineColumn("idiscrizionebmi", typeof(int));
	tconvalidante.defineColumn("idistanza", typeof(int));
	tconvalidante.defineColumn("idlearningagrstud", typeof(int));
	tconvalidante.defineColumn("idlearningagrtrainer", typeof(int));
	tconvalidante.defineColumn("idpratica", typeof(int));
	tconvalidante.defineColumn("idreg", typeof(int),false);
	tconvalidante.defineColumn("idsostenimento", typeof(int));
	tconvalidante.defineColumn("idtirocinioprogetto", typeof(int));
	tconvalidante.defineColumn("lt", typeof(DateTime),false);
	tconvalidante.defineColumn("lu", typeof(string),false);
	Tables.Add(tconvalidante);
	tconvalidante.defineKey("idconvalida", "idconvalidante", "idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{tirocinioprogetto.Columns["idtirocinioprogetto"]};
	var cChild = new []{convalidante.Columns["idtirocinioprogetto"]};
	Relations.Add(new DataRelation("FK_convalidante_tirocinioprogetto_idtirocinioprogetto",cPar,cChild,false));

	cPar = new []{changeskinddefaultview.Columns["idchangeskind"]};
	cChild = new []{convalidante.Columns["idchangeskind"]};
	Relations.Add(new DataRelation("FK_convalidante_changeskinddefaultview_idchangeskind",cPar,cChild,false));

	cPar = new []{sostenimentoseganagstuview.Columns["idsostenimento"]};
	cChild = new []{convalidante.Columns["idsostenimento"]};
	Relations.Add(new DataRelation("FK_convalidante_sostenimentoseganagstuview_idsostenimento",cPar,cChild,false));

	#endregion

}
}
}
