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
[System.Xml.Serialization.XmlRoot("dsmeta_convalidante_segisttri"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_convalidante_segisttri: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sostenimentodefaultview 		=> (MetaTable)Tables["sostenimentodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable convalidante 		=> (MetaTable)Tables["convalidante"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_convalidante_segisttri(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_convalidante_segisttri (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_convalidante_segisttri";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_convalidante_segisttri.xsd";

	#region create DataTables
	//////////////////// SOSTENIMENTODEFAULTVIEW /////////////////////////////////
	var tsostenimentodefaultview= new MetaTable("sostenimentodefaultview");
	tsostenimentodefaultview.defineColumn("annoaccademico_aa", typeof(string));
	tsostenimentodefaultview.defineColumn("annoaccademico_titolostudio_aa", typeof(string));
	tsostenimentodefaultview.defineColumn("attivform_title", typeof(string));
	tsostenimentodefaultview.defineColumn("dropdown_title", typeof(string),false);
	tsostenimentodefaultview.defineColumn("idappello", typeof(int),false);
	tsostenimentodefaultview.defineColumn("idattivform", typeof(int));
	tsostenimentodefaultview.defineColumn("idiscrizione", typeof(int));
	tsostenimentodefaultview.defineColumn("idprova", typeof(int),false);
	tsostenimentodefaultview.defineColumn("idreg", typeof(int),false);
	tsostenimentodefaultview.defineColumn("idsostenimento", typeof(int),false);
	tsostenimentodefaultview.defineColumn("idtitolostudio", typeof(int));
	tsostenimentodefaultview.defineColumn("iscrizione_anno", typeof(int));
	tsostenimentodefaultview.defineColumn("iscrizione_iddidprog", typeof(int));
	tsostenimentodefaultview.defineColumn("istattitolistudio_titolo", typeof(string));
	tsostenimentodefaultview.defineColumn("registry_title", typeof(string));
	tsostenimentodefaultview.defineColumn("sostenimento_ct", typeof(DateTime),false);
	tsostenimentodefaultview.defineColumn("sostenimento_cu", typeof(string),false);
	tsostenimentodefaultview.defineColumn("sostenimento_data", typeof(DateTime),false);
	tsostenimentodefaultview.defineColumn("sostenimento_domande", typeof(string));
	tsostenimentodefaultview.defineColumn("sostenimento_ects", typeof(int));
	tsostenimentodefaultview.defineColumn("sostenimento_giudizio", typeof(string));
	tsostenimentodefaultview.defineColumn("sostenimento_idcorsostudio", typeof(int));
	tsostenimentodefaultview.defineColumn("sostenimento_iddidprog", typeof(int));
	tsostenimentodefaultview.defineColumn("sostenimento_idsostenimentoesito", typeof(int),false);
	tsostenimentodefaultview.defineColumn("sostenimento_insecod", typeof(string));
	tsostenimentodefaultview.defineColumn("sostenimento_insedesc", typeof(string));
	tsostenimentodefaultview.defineColumn("sostenimento_livello", typeof(string));
	tsostenimentodefaultview.defineColumn("sostenimento_lt", typeof(DateTime),false);
	tsostenimentodefaultview.defineColumn("sostenimento_lu", typeof(string),false);
	tsostenimentodefaultview.defineColumn("sostenimento_paridsostenimento", typeof(int));
	tsostenimentodefaultview.defineColumn("sostenimento_protanno", typeof(int));
	tsostenimentodefaultview.defineColumn("sostenimento_protnumero", typeof(int));
	tsostenimentodefaultview.defineColumn("sostenimento_voto", typeof(decimal));
	tsostenimentodefaultview.defineColumn("sostenimento_votolode", typeof(string));
	tsostenimentodefaultview.defineColumn("sostenimento_votosu", typeof(int));
	tsostenimentodefaultview.defineColumn("sostenimentoesito_title", typeof(string));
	tsostenimentodefaultview.defineColumn("titolostudio_voto", typeof(int));
	tsostenimentodefaultview.defineColumn("titolostudio_votolode", typeof(string));
	tsostenimentodefaultview.defineColumn("titolostudio_votosu", typeof(int));
	Tables.Add(tsostenimentodefaultview);
	tsostenimentodefaultview.defineKey("idappello", "idprova", "idreg", "idsostenimento");

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
	var cPar = new []{sostenimentodefaultview.Columns["idsostenimento"]};
	var cChild = new []{convalidante.Columns["idsostenimento"]};
	Relations.Add(new DataRelation("FK_convalidante_sostenimentodefaultview_idsostenimento",cPar,cChild,false));

	#endregion

}
}
}
