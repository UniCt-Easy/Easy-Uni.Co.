
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
[System.Xml.Serialization.XmlRoot("dsmeta_iscrizione_seganagstusing"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_iscrizione_seganagstusing: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sostenimentoesito 		=> (MetaTable)Tables["sostenimentoesito"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sostenimento_alias1 		=> (MetaTable)Tables["sostenimento_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pianostudioattivform_alias1 		=> (MetaTable)Tables["pianostudioattivform_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pianostudiostatus 		=> (MetaTable)Tables["pianostudiostatus"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico_alias1 		=> (MetaTable)Tables["annoaccademico_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pianostudio_alias1 		=> (MetaTable)Tables["pianostudio_alias1"];

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
public dsmeta_iscrizione_seganagstusing(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_iscrizione_seganagstusing (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_iscrizione_seganagstusing";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_iscrizione_seganagstusing.xsd";

	#region create DataTables
	//////////////////// SOSTENIMENTOESITO /////////////////////////////////
	var tsostenimentoesito= new MetaTable("sostenimentoesito");
	tsostenimentoesito.defineColumn("idsostenimentoesito", typeof(int),false);
	tsostenimentoesito.defineColumn("title", typeof(string),false);
	Tables.Add(tsostenimentoesito);
	tsostenimentoesito.defineKey("idsostenimentoesito");

	//////////////////// SOSTENIMENTO_ALIAS1 /////////////////////////////////
	var tsostenimento_alias1= new MetaTable("sostenimento_alias1");
	tsostenimento_alias1.defineColumn("ct", typeof(DateTime),false);
	tsostenimento_alias1.defineColumn("cu", typeof(string),false);
	tsostenimento_alias1.defineColumn("data", typeof(DateTime),false);
	tsostenimento_alias1.defineColumn("domande", typeof(string));
	tsostenimento_alias1.defineColumn("ects", typeof(int));
	tsostenimento_alias1.defineColumn("giudizio", typeof(string));
	tsostenimento_alias1.defineColumn("idappello", typeof(int));
	tsostenimento_alias1.defineColumn("idattivform", typeof(int));
	tsostenimento_alias1.defineColumn("idcorsostudio", typeof(int));
	tsostenimento_alias1.defineColumn("iddidprog", typeof(int));
	tsostenimento_alias1.defineColumn("idiscrizione", typeof(int),false);
	tsostenimento_alias1.defineColumn("idprova", typeof(int));
	tsostenimento_alias1.defineColumn("idreg", typeof(int),false);
	tsostenimento_alias1.defineColumn("idsostenimento", typeof(int),false);
	tsostenimento_alias1.defineColumn("idsostenimentoesito", typeof(int),false);
	tsostenimento_alias1.defineColumn("idtitolostudio", typeof(int));
	tsostenimento_alias1.defineColumn("insecod", typeof(string));
	tsostenimento_alias1.defineColumn("insedesc", typeof(string));
	tsostenimento_alias1.defineColumn("livello", typeof(string));
	tsostenimento_alias1.defineColumn("lt", typeof(DateTime),false);
	tsostenimento_alias1.defineColumn("lu", typeof(string),false);
	tsostenimento_alias1.defineColumn("paridsostenimento", typeof(int));
	tsostenimento_alias1.defineColumn("protanno", typeof(int));
	tsostenimento_alias1.defineColumn("protnumero", typeof(int));
	tsostenimento_alias1.defineColumn("voto", typeof(decimal));
	tsostenimento_alias1.defineColumn("votolode", typeof(string));
	tsostenimento_alias1.defineColumn("votosu", typeof(int));
	tsostenimento_alias1.defineColumn("!idsostenimentoesito_sostenimentoesito_title", typeof(string));
	tsostenimento_alias1.ExtendedProperties["TableForReading"]="sostenimento";
	Tables.Add(tsostenimento_alias1);
	tsostenimento_alias1.defineKey("idiscrizione", "idreg", "idsostenimento");

	//////////////////// PIANOSTUDIOATTIVFORM_ALIAS1 /////////////////////////////////
	var tpianostudioattivform_alias1= new MetaTable("pianostudioattivform_alias1");
	tpianostudioattivform_alias1.defineColumn("anno", typeof(int),false);
	tpianostudioattivform_alias1.defineColumn("ct", typeof(DateTime),false);
	tpianostudioattivform_alias1.defineColumn("cu", typeof(string),false);
	tpianostudioattivform_alias1.defineColumn("idattivform", typeof(int),false);
	tpianostudioattivform_alias1.defineColumn("idattivform_scelta", typeof(int),false);
	tpianostudioattivform_alias1.defineColumn("idcorsostudio", typeof(int));
	tpianostudioattivform_alias1.defineColumn("iddidprog", typeof(int));
	tpianostudioattivform_alias1.defineColumn("idiscrizione", typeof(int),false);
	tpianostudioattivform_alias1.defineColumn("idiscrizionebmi", typeof(int));
	tpianostudioattivform_alias1.defineColumn("idpianostudio", typeof(int),false);
	tpianostudioattivform_alias1.defineColumn("idpianostudioattivform", typeof(int),false);
	tpianostudioattivform_alias1.defineColumn("idreg", typeof(int),false);
	tpianostudioattivform_alias1.defineColumn("idsostenimento", typeof(int));
	tpianostudioattivform_alias1.defineColumn("lt", typeof(DateTime),false);
	tpianostudioattivform_alias1.defineColumn("lu", typeof(string),false);
	tpianostudioattivform_alias1.ExtendedProperties["TableForReading"]="pianostudioattivform";
	Tables.Add(tpianostudioattivform_alias1);
	tpianostudioattivform_alias1.defineKey("idiscrizione", "idpianostudio", "idpianostudioattivform", "idreg");

	//////////////////// PIANOSTUDIOSTATUS /////////////////////////////////
	var tpianostudiostatus= new MetaTable("pianostudiostatus");
	tpianostudiostatus.defineColumn("idpianostudiostatus", typeof(int),false);
	tpianostudiostatus.defineColumn("title", typeof(string),false);
	Tables.Add(tpianostudiostatus);
	tpianostudiostatus.defineKey("idpianostudiostatus");

	//////////////////// ANNOACCADEMICO_ALIAS1 /////////////////////////////////
	var tannoaccademico_alias1= new MetaTable("annoaccademico_alias1");
	tannoaccademico_alias1.defineColumn("aa", typeof(string),false);
	tannoaccademico_alias1.ExtendedProperties["TableForReading"]="annoaccademico";
	Tables.Add(tannoaccademico_alias1);
	tannoaccademico_alias1.defineKey("aa");

	//////////////////// PIANOSTUDIO_ALIAS1 /////////////////////////////////
	var tpianostudio_alias1= new MetaTable("pianostudio_alias1");
	tpianostudio_alias1.defineColumn("aa", typeof(string));
	tpianostudio_alias1.defineColumn("ct", typeof(DateTime),false);
	tpianostudio_alias1.defineColumn("cu", typeof(string),false);
	tpianostudio_alias1.defineColumn("idcorsostudio", typeof(int));
	tpianostudio_alias1.defineColumn("iddidprog", typeof(int));
	tpianostudio_alias1.defineColumn("idiscrizione", typeof(int),false);
	tpianostudio_alias1.defineColumn("idiscrizionebmi", typeof(int));
	tpianostudio_alias1.defineColumn("idpianostudio", typeof(int),false);
	tpianostudio_alias1.defineColumn("idpianostudiostatus", typeof(int));
	tpianostudio_alias1.defineColumn("idreg", typeof(int),false);
	tpianostudio_alias1.defineColumn("lt", typeof(DateTime),false);
	tpianostudio_alias1.defineColumn("lu", typeof(string),false);
	tpianostudio_alias1.defineColumn("!idpianostudiostatus_pianostudiostatus_title", typeof(string));
	tpianostudio_alias1.ExtendedProperties["TableForReading"]="pianostudio";
	Tables.Add(tpianostudio_alias1);
	tpianostudio_alias1.defineKey("idiscrizione", "idpianostudio", "idreg");

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
	tiscrizione.defineColumn("idcorsostudio", typeof(int));
	tiscrizione.defineColumn("iddidprog", typeof(int));
	tiscrizione.defineColumn("idiscrizione", typeof(int),false);
	tiscrizione.defineColumn("idreg", typeof(int),false);
	tiscrizione.defineColumn("lt", typeof(DateTime),false);
	tiscrizione.defineColumn("lu", typeof(string),false);
	tiscrizione.defineColumn("matricola", typeof(string));
	Tables.Add(tiscrizione);
	tiscrizione.defineKey("idiscrizione", "idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{iscrizione.Columns["idiscrizione"], iscrizione.Columns["idreg"]};
	var cChild = new []{sostenimento_alias1.Columns["idiscrizione"], sostenimento_alias1.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_sostenimento_alias1_iscrizione_idiscrizione-idreg",cPar,cChild,false));

	cPar = new []{sostenimentoesito.Columns["idsostenimentoesito"]};
	cChild = new []{sostenimento_alias1.Columns["idsostenimentoesito"]};
	Relations.Add(new DataRelation("FK_sostenimento_alias1_sostenimentoesito_idsostenimentoesito",cPar,cChild,false));

	cPar = new []{iscrizione.Columns["idiscrizione"], iscrizione.Columns["idreg"]};
	cChild = new []{pianostudio_alias1.Columns["idiscrizione"], pianostudio_alias1.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_pianostudio_alias1_iscrizione_idiscrizione-idreg",cPar,cChild,false));

	cPar = new []{pianostudio_alias1.Columns["idiscrizione"], pianostudio_alias1.Columns["idpianostudio"], pianostudio_alias1.Columns["idreg"]};
	cChild = new []{pianostudioattivform_alias1.Columns["idiscrizione"], pianostudioattivform_alias1.Columns["idpianostudio"], pianostudioattivform_alias1.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_pianostudioattivform_alias1_pianostudio_alias1_idiscrizione-idpianostudio-idreg",cPar,cChild,false));

	cPar = new []{pianostudiostatus.Columns["idpianostudiostatus"]};
	cChild = new []{pianostudio_alias1.Columns["idpianostudiostatus"]};
	Relations.Add(new DataRelation("FK_pianostudio_alias1_pianostudiostatus_idpianostudiostatus",cPar,cChild,false));

	cPar = new []{annoaccademico_alias1.Columns["aa"]};
	cChild = new []{pianostudio_alias1.Columns["aa"]};
	Relations.Add(new DataRelation("FK_pianostudio_alias1_annoaccademico_alias1_aa",cPar,cChild,false));

	cPar = new []{annoaccademico.Columns["aa"]};
	cChild = new []{iscrizione.Columns["aa"]};
	Relations.Add(new DataRelation("FK_iscrizione_annoaccademico_aa",cPar,cChild,false));

	#endregion

}
}
}
