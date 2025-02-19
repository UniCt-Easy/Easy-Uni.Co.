
/*
Easy
Copyright (C) 2024 UniversitÓ degli Studi di Catania (www.unict.it)
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
[System.Xml.Serialization.XmlRoot("dsmeta_sostenimento_seganagstuconsmast"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_sostenimento_seganagstuconsmast: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sostenimentoesitodefaultview 		=> (MetaTable)Tables["sostenimentoesitodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrydefaultview 		=> (MetaTable)Tables["registrydefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable provadotmasview 		=> (MetaTable)Tables["provadotmasview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sostenimento 		=> (MetaTable)Tables["sostenimento"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_sostenimento_seganagstuconsmast(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_sostenimento_seganagstuconsmast (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_sostenimento_seganagstuconsmast";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_sostenimento_seganagstuconsmast.xsd";

	#region create DataTables
	//////////////////// SOSTENIMENTOESITODEFAULTVIEW /////////////////////////////////
	var tsostenimentoesitodefaultview= new MetaTable("sostenimentoesitodefaultview");
	tsostenimentoesitodefaultview.defineColumn("dropdown_title", typeof(string),false);
	tsostenimentoesitodefaultview.defineColumn("idsostenimentoesito", typeof(int),false);
	Tables.Add(tsostenimentoesitodefaultview);
	tsostenimentoesitodefaultview.defineKey("idsostenimentoesito");

	//////////////////// REGISTRYDEFAULTVIEW /////////////////////////////////
	var tregistrydefaultview= new MetaTable("registrydefaultview");
	tregistrydefaultview.defineColumn("dropdown_title", typeof(string),false);
	tregistrydefaultview.defineColumn("idcategory", typeof(string));
	tregistrydefaultview.defineColumn("idcentralizedcategory", typeof(string));
	tregistrydefaultview.defineColumn("idcity", typeof(int));
	tregistrydefaultview.defineColumn("idnation", typeof(int));
	tregistrydefaultview.defineColumn("idreg", typeof(int),false);
	tregistrydefaultview.defineColumn("idregistryclass", typeof(string));
	tregistrydefaultview.defineColumn("idtitle", typeof(string));
	tregistrydefaultview.defineColumn("residence", typeof(int),false);
	Tables.Add(tregistrydefaultview);
	tregistrydefaultview.defineKey("idreg");

	//////////////////// PROVADOTMASVIEW /////////////////////////////////
	var tprovadotmasview= new MetaTable("provadotmasview");
	tprovadotmasview.defineColumn("dropdown_title", typeof(string),false);
	tprovadotmasview.defineColumn("idcorsostudio", typeof(int));
	tprovadotmasview.defineColumn("iddidprog", typeof(int));
	tprovadotmasview.defineColumn("idprova", typeof(int),false);
	tprovadotmasview.defineColumn("idquestionario", typeof(int));
	tprovadotmasview.defineColumn("prova_ct", typeof(DateTime),false);
	tprovadotmasview.defineColumn("prova_cu", typeof(string),false);
	tprovadotmasview.defineColumn("prova_idappello", typeof(int));
	tprovadotmasview.defineColumn("prova_idattivform", typeof(int));
	tprovadotmasview.defineColumn("prova_idvalutazionekind", typeof(int));
	tprovadotmasview.defineColumn("prova_lt", typeof(DateTime),false);
	tprovadotmasview.defineColumn("prova_lu", typeof(string),false);
	tprovadotmasview.defineColumn("prova_programma", typeof(string));
	tprovadotmasview.defineColumn("prova_start", typeof(DateTime));
	tprovadotmasview.defineColumn("prova_stop", typeof(DateTime));
	tprovadotmasview.defineColumn("questionario_title", typeof(string));
	tprovadotmasview.defineColumn("title", typeof(string));
	tprovadotmasview.defineColumn("valutazionekind_title", typeof(string));
	Tables.Add(tprovadotmasview);
	tprovadotmasview.defineKey("idprova");

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
	tsostenimento.defineColumn("idiscrizione", typeof(int),false);
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
	tsostenimento.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idprova", "idreg", "idsostenimento");

	#endregion


	#region DataRelation creation
	var cPar = new []{sostenimentoesitodefaultview.Columns["idsostenimentoesito"]};
	var cChild = new []{sostenimento.Columns["idsostenimentoesito"]};
	Relations.Add(new DataRelation("FK_sostenimento_sostenimentoesitodefaultview_idsostenimentoesito",cPar,cChild,false));

	cPar = new []{registrydefaultview.Columns["idreg"]};
	cChild = new []{sostenimento.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_sostenimento_registrydefaultview_idreg",cPar,cChild,false));

	cPar = new []{provadotmasview.Columns["idprova"]};
	cChild = new []{sostenimento.Columns["idprova"]};
	Relations.Add(new DataRelation("FK_sostenimento_provadotmasview_idprova",cPar,cChild,false));

	#endregion

}
}
}
