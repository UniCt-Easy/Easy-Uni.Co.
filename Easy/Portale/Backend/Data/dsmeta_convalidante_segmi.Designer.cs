
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
[System.Xml.Serialization.XmlRoot("dsmeta_convalidante_segmi"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_convalidante_segmi: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tirocinioprogetto 		=> (MetaTable)Tables["tirocinioprogetto"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sostenimentodefaultview 		=> (MetaTable)Tables["sostenimentodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pratica 		=> (MetaTable)Tables["pratica"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable learningagrtrainer 		=> (MetaTable)Tables["learningagrtrainer"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable learningagrstud 		=> (MetaTable)Tables["learningagrstud"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanza 		=> (MetaTable)Tables["istanza"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizionebmi 		=> (MetaTable)Tables["iscrizionebmi"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizionedefaultview_alias1 		=> (MetaTable)Tables["iscrizionedefaultview_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizionedefaultview 		=> (MetaTable)Tables["iscrizionedefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogdefaultview 		=> (MetaTable)Tables["didprogdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable dichiar 		=> (MetaTable)Tables["dichiar"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable changeskinddefaultview 		=> (MetaTable)Tables["changeskinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable convalidante 		=> (MetaTable)Tables["convalidante"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_convalidante_segmi(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_convalidante_segmi (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_convalidante_segmi";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_convalidante_segmi.xsd";

	#region create DataTables
	//////////////////// TIROCINIOPROGETTO /////////////////////////////////
	var ttirocinioprogetto= new MetaTable("tirocinioprogetto");
	ttirocinioprogetto.defineColumn("description", typeof(string),false);
	ttirocinioprogetto.defineColumn("idreg_referente", typeof(int),false);
	ttirocinioprogetto.defineColumn("idreg_studenti", typeof(int),false);
	ttirocinioprogetto.defineColumn("idtirociniocandidatura", typeof(int),false);
	ttirocinioprogetto.defineColumn("idtirocinioprogetto", typeof(int),false);
	ttirocinioprogetto.defineColumn("idtirocinioproposto", typeof(int),false);
	ttirocinioprogetto.defineColumn("title", typeof(string),false);
	Tables.Add(ttirocinioprogetto);
	ttirocinioprogetto.defineKey("idreg_referente", "idreg_studenti", "idtirociniocandidatura", "idtirocinioprogetto", "idtirocinioproposto");

	//////////////////// SOSTENIMENTODEFAULTVIEW /////////////////////////////////
	var tsostenimentodefaultview= new MetaTable("sostenimentodefaultview");
	tsostenimentodefaultview.defineColumn("dropdown_title", typeof(string),false);
	tsostenimentodefaultview.defineColumn("idappello", typeof(int));
	tsostenimentodefaultview.defineColumn("idattivform", typeof(int));
	tsostenimentodefaultview.defineColumn("idiscrizione", typeof(int));
	tsostenimentodefaultview.defineColumn("idprova", typeof(int));
	tsostenimentodefaultview.defineColumn("idreg", typeof(int),false);
	tsostenimentodefaultview.defineColumn("idsostenimento", typeof(int),false);
	tsostenimentodefaultview.defineColumn("idtitolostudio", typeof(int));
	Tables.Add(tsostenimentodefaultview);
	tsostenimentodefaultview.defineKey("idsostenimento");

	//////////////////// PRATICA /////////////////////////////////
	var tpratica= new MetaTable("pratica");
	tpratica.defineColumn("idcorsostudio", typeof(int),false);
	tpratica.defineColumn("iddidprog", typeof(int),false);
	tpratica.defineColumn("idiscrizione", typeof(int),false);
	tpratica.defineColumn("idistanza", typeof(int),false);
	tpratica.defineColumn("idistanzakind", typeof(int),false);
	tpratica.defineColumn("idpratica", typeof(int),false);
	tpratica.defineColumn("idreg", typeof(int),false);
	Tables.Add(tpratica);
	tpratica.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idistanza", "idistanzakind", "idpratica", "idreg");

	//////////////////// LEARNINGAGRTRAINER /////////////////////////////////
	var tlearningagrtrainer= new MetaTable("learningagrtrainer");
	tlearningagrtrainer.defineColumn("idbandomi", typeof(int),false);
	tlearningagrtrainer.defineColumn("idiscrizionebmi", typeof(int),false);
	tlearningagrtrainer.defineColumn("idlearningagrtrainer", typeof(int),false);
	tlearningagrtrainer.defineColumn("idreg", typeof(int),false);
	tlearningagrtrainer.defineColumn("title", typeof(string),false);
	Tables.Add(tlearningagrtrainer);
	tlearningagrtrainer.defineKey("idbandomi", "idiscrizionebmi", "idlearningagrtrainer", "idreg");

	//////////////////// LEARNINGAGRSTUD /////////////////////////////////
	var tlearningagrstud= new MetaTable("learningagrstud");
	tlearningagrstud.defineColumn("idbandomi", typeof(int),false);
	tlearningagrstud.defineColumn("idiscrizionebmi", typeof(int),false);
	tlearningagrstud.defineColumn("idlearningagrstud", typeof(int),false);
	tlearningagrstud.defineColumn("idreg", typeof(int),false);
	Tables.Add(tlearningagrstud);
	tlearningagrstud.defineKey("idbandomi", "idiscrizionebmi", "idlearningagrstud", "idreg");

	//////////////////// ISTANZA /////////////////////////////////
	var tistanza= new MetaTable("istanza");
	tistanza.defineColumn("aa", typeof(string),false);
	tistanza.defineColumn("data", typeof(DateTime),false);
	tistanza.defineColumn("idcorsostudio", typeof(int),false);
	tistanza.defineColumn("iddidprog", typeof(int),false);
	tistanza.defineColumn("idiscrizione", typeof(int));
	tistanza.defineColumn("idistanza", typeof(int),false);
	tistanza.defineColumn("idistanzakind", typeof(int),false);
	tistanza.defineColumn("idreg_studenti", typeof(int),false);
	tistanza.defineColumn("idstatuskind", typeof(int));
	Tables.Add(tistanza);
	tistanza.defineKey("idcorsostudio", "iddidprog", "idistanza", "idistanzakind", "idreg_studenti");

	//////////////////// ISCRIZIONEBMI /////////////////////////////////
	var tiscrizionebmi= new MetaTable("iscrizionebmi");
	tiscrizionebmi.defineColumn("idbandomi", typeof(int),false);
	tiscrizionebmi.defineColumn("idiscrizionebmi", typeof(int),false);
	tiscrizionebmi.defineColumn("idreg", typeof(int),false);
	Tables.Add(tiscrizionebmi);
	tiscrizionebmi.defineKey("idbandomi", "idiscrizionebmi", "idreg");

	//////////////////// ISCRIZIONEDEFAULTVIEW_ALIAS1 /////////////////////////////////
	var tiscrizionedefaultview_alias1= new MetaTable("iscrizionedefaultview_alias1");
	tiscrizionedefaultview_alias1.defineColumn("aa", typeof(string),false);
	tiscrizionedefaultview_alias1.defineColumn("dropdown_title", typeof(string),false);
	tiscrizionedefaultview_alias1.defineColumn("idcorsostudio", typeof(int));
	tiscrizionedefaultview_alias1.defineColumn("iddidprog", typeof(int));
	tiscrizionedefaultview_alias1.defineColumn("idiscrizione", typeof(int),false);
	tiscrizionedefaultview_alias1.defineColumn("idreg", typeof(int),false);
	tiscrizionedefaultview_alias1.ExtendedProperties["TableForReading"]="iscrizionedefaultview";
	Tables.Add(tiscrizionedefaultview_alias1);
	tiscrizionedefaultview_alias1.defineKey("idiscrizione");

	//////////////////// ISCRIZIONEDEFAULTVIEW /////////////////////////////////
	var tiscrizionedefaultview= new MetaTable("iscrizionedefaultview");
	tiscrizionedefaultview.defineColumn("aa", typeof(string),false);
	tiscrizionedefaultview.defineColumn("dropdown_title", typeof(string),false);
	tiscrizionedefaultview.defineColumn("idcorsostudio", typeof(int));
	tiscrizionedefaultview.defineColumn("iddidprog", typeof(int));
	tiscrizionedefaultview.defineColumn("idiscrizione", typeof(int),false);
	tiscrizionedefaultview.defineColumn("idreg", typeof(int),false);
	Tables.Add(tiscrizionedefaultview);
	tiscrizionedefaultview.defineKey("idiscrizione");

	//////////////////// DIDPROGDEFAULTVIEW /////////////////////////////////
	var tdidprogdefaultview= new MetaTable("didprogdefaultview");
	tdidprogdefaultview.defineColumn("aa", typeof(string));
	tdidprogdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tdidprogdefaultview.defineColumn("idareadidattica", typeof(int));
	tdidprogdefaultview.defineColumn("idconvenzione", typeof(int));
	tdidprogdefaultview.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogdefaultview.defineColumn("iddidprog", typeof(int),false);
	tdidprogdefaultview.defineColumn("idgraduatoria", typeof(int));
	tdidprogdefaultview.defineColumn("idnation_lang", typeof(int));
	tdidprogdefaultview.defineColumn("idnation_lang2", typeof(int));
	tdidprogdefaultview.defineColumn("idnation_langvis", typeof(int));
	tdidprogdefaultview.defineColumn("idreg_docenti", typeof(int));
	tdidprogdefaultview.defineColumn("idsede", typeof(int));
	tdidprogdefaultview.defineColumn("idsessione", typeof(int));
	Tables.Add(tdidprogdefaultview);
	tdidprogdefaultview.defineKey("iddidprog");

	//////////////////// DICHIAR /////////////////////////////////
	var tdichiar= new MetaTable("dichiar");
	tdichiar.defineColumn("aa", typeof(string));
	tdichiar.defineColumn("date", typeof(DateTime),false);
	tdichiar.defineColumn("iddichiar", typeof(int),false);
	tdichiar.defineColumn("iddichiarkind", typeof(int),false);
	tdichiar.defineColumn("idreg", typeof(int),false);
	Tables.Add(tdichiar);
	tdichiar.defineKey("iddichiar", "idreg");

	//////////////////// CHANGESKINDDEFAULTVIEW /////////////////////////////////
	var tchangeskinddefaultview= new MetaTable("changeskinddefaultview");
	tchangeskinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tchangeskinddefaultview.defineColumn("idchangeskind", typeof(int),false);
	Tables.Add(tchangeskinddefaultview);
	tchangeskinddefaultview.defineKey("idchangeskind");

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

	cPar = new []{sostenimentodefaultview.Columns["idsostenimento"]};
	cChild = new []{convalidante.Columns["idsostenimento"]};
	Relations.Add(new DataRelation("FK_convalidante_sostenimentodefaultview_idsostenimento",cPar,cChild,false));

	cPar = new []{pratica.Columns["idpratica"]};
	cChild = new []{convalidante.Columns["idpratica"]};
	Relations.Add(new DataRelation("FK_convalidante_pratica_idpratica",cPar,cChild,false));

	cPar = new []{learningagrtrainer.Columns["idlearningagrtrainer"]};
	cChild = new []{convalidante.Columns["idlearningagrtrainer"]};
	Relations.Add(new DataRelation("FK_convalidante_learningagrtrainer_idlearningagrtrainer",cPar,cChild,false));

	cPar = new []{learningagrstud.Columns["idlearningagrstud"]};
	cChild = new []{convalidante.Columns["idlearningagrstud"]};
	Relations.Add(new DataRelation("FK_convalidante_learningagrstud_idlearningagrstud",cPar,cChild,false));

	cPar = new []{istanza.Columns["idistanza"]};
	cChild = new []{convalidante.Columns["idistanza"]};
	Relations.Add(new DataRelation("FK_convalidante_istanza_idistanza",cPar,cChild,false));

	cPar = new []{iscrizionebmi.Columns["idiscrizionebmi"]};
	cChild = new []{convalidante.Columns["idiscrizionebmi"]};
	Relations.Add(new DataRelation("FK_convalidante_iscrizionebmi_idiscrizionebmi",cPar,cChild,false));

	cPar = new []{iscrizionedefaultview_alias1.Columns["idiscrizione"]};
	cChild = new []{convalidante.Columns["idiscrizione_from"]};
	Relations.Add(new DataRelation("FK_convalidante_iscrizionedefaultview_alias1_idiscrizione_from",cPar,cChild,false));

	cPar = new []{iscrizionedefaultview.Columns["idiscrizione"]};
	cChild = new []{convalidante.Columns["idiscrizione"]};
	Relations.Add(new DataRelation("FK_convalidante_iscrizionedefaultview_idiscrizione",cPar,cChild,false));

	cPar = new []{didprogdefaultview.Columns["iddidprog"]};
	cChild = new []{convalidante.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_convalidante_didprogdefaultview_iddidprog",cPar,cChild,false));

	cPar = new []{dichiar.Columns["iddichiar"]};
	cChild = new []{convalidante.Columns["iddichiar"]};
	Relations.Add(new DataRelation("FK_convalidante_dichiar_iddichiar",cPar,cChild,false));

	cPar = new []{changeskinddefaultview.Columns["idchangeskind"]};
	cChild = new []{convalidante.Columns["idchangeskind"]};
	Relations.Add(new DataRelation("FK_convalidante_changeskinddefaultview_idchangeskind",cPar,cChild,false));

	#endregion

}
}
}
