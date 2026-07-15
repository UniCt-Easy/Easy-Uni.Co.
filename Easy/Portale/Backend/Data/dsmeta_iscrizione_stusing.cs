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
[System.Xml.Serialization.XmlRoot("dsmeta_iscrizione_stusing"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_iscrizione_stusing: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sostenimentoesito 		=> (MetaTable)Tables["sostenimentoesito"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sostenimento 		=> (MetaTable)Tables["sostenimento"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sostenimento_alias1 		=> (MetaTable)Tables["sostenimento_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attivform_alias1 		=> (MetaTable)Tables["attivform_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attivform 		=> (MetaTable)Tables["attivform"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pianostudioattivform 		=> (MetaTable)Tables["pianostudioattivform"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pianostudiostatus 		=> (MetaTable)Tables["pianostudiostatus"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sede 		=> (MetaTable)Tables["sede"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprog 		=> (MetaTable)Tables["didprog"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico_alias1 		=> (MetaTable)Tables["annoaccademico_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pianostudio 		=> (MetaTable)Tables["pianostudio"];

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
public dsmeta_iscrizione_stusing(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_iscrizione_stusing (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_iscrizione_stusing";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_iscrizione_stusing.xsd";

	#region create DataTables
	//////////////////// SOSTENIMENTOESITO /////////////////////////////////
	var tsostenimentoesito= new MetaTable("sostenimentoesito");
	tsostenimentoesito.defineColumn("active", typeof(string),false);
	tsostenimentoesito.defineColumn("idsostenimentoesito", typeof(int),false);
	tsostenimentoesito.defineColumn("title", typeof(string),false);
	Tables.Add(tsostenimentoesito);
	tsostenimentoesito.defineKey("idsostenimentoesito");

	//////////////////// SOSTENIMENTO /////////////////////////////////
	var tsostenimento= new MetaTable("sostenimento");
	tsostenimento.defineColumn("ct", typeof(DateTime),false);
	tsostenimento.defineColumn("cu", typeof(string),false);
	tsostenimento.defineColumn("data", typeof(DateTime),false);
	tsostenimento.defineColumn("domande", typeof(string));
	tsostenimento.defineColumn("ects", typeof(int));
	tsostenimento.defineColumn("giudizio", typeof(string));
	tsostenimento.defineColumn("idappello", typeof(int));
	tsostenimento.defineColumn("idattivform", typeof(int),false);
	tsostenimento.defineColumn("idcorsostudio", typeof(int));
	tsostenimento.defineColumn("iddidprog", typeof(int));
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
	tsostenimento.defineColumn("!idsostenimentoesito_sostenimentoesito_title", typeof(string));
	Tables.Add(tsostenimento);
	tsostenimento.defineKey("idiscrizione", "idreg", "idsostenimento");

	//////////////////// SOSTENIMENTO_ALIAS1 /////////////////////////////////
	var tsostenimento_alias1= new MetaTable("sostenimento_alias1");
	tsostenimento_alias1.defineColumn("ct", typeof(DateTime),false);
	tsostenimento_alias1.defineColumn("cu", typeof(string),false);
	tsostenimento_alias1.defineColumn("data", typeof(DateTime),false);
	tsostenimento_alias1.defineColumn("domande", typeof(string));
	tsostenimento_alias1.defineColumn("ects", typeof(int));
	tsostenimento_alias1.defineColumn("giudizio", typeof(string));
	tsostenimento_alias1.defineColumn("idappello", typeof(int));
	tsostenimento_alias1.defineColumn("idattivform", typeof(int),false);
	tsostenimento_alias1.defineColumn("idcorsostudio", typeof(int));
	tsostenimento_alias1.defineColumn("iddidprog", typeof(int));
	tsostenimento_alias1.defineColumn("idiscrizione", typeof(int),false);
	tsostenimento_alias1.defineColumn("idprova", typeof(int),false);
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
	tsostenimento_alias1.ExtendedProperties["TableForReading"]="sostenimento";
	tsostenimento_alias1.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tsostenimento_alias1);
	tsostenimento_alias1.defineKey("idiscrizione", "idreg", "idsostenimento");

	//////////////////// ATTIVFORM_ALIAS1 /////////////////////////////////
	var tattivform_alias1= new MetaTable("attivform_alias1");
	tattivform_alias1.defineColumn("aa", typeof(string),false);
	tattivform_alias1.defineColumn("idattivform", typeof(int),false);
	tattivform_alias1.defineColumn("idcorsostudio", typeof(int),false);
	tattivform_alias1.defineColumn("iddidprog", typeof(int),false);
	tattivform_alias1.defineColumn("iddidproganno", typeof(int),false);
	tattivform_alias1.defineColumn("iddidprogcurr", typeof(int),false);
	tattivform_alias1.defineColumn("iddidprogori", typeof(int),false);
	tattivform_alias1.defineColumn("iddidprogporzanno", typeof(int),false);
	tattivform_alias1.defineColumn("idsede", typeof(int),false);
	tattivform_alias1.defineColumn("title", typeof(string));
	tattivform_alias1.ExtendedProperties["TableForReading"]="attivform";
	Tables.Add(tattivform_alias1);
	tattivform_alias1.defineKey("aa", "idattivform", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno", "idsede");

	//////////////////// ATTIVFORM /////////////////////////////////
	var tattivform= new MetaTable("attivform");
	tattivform.defineColumn("aa", typeof(string),false);
	tattivform.defineColumn("idattivform", typeof(int),false);
	tattivform.defineColumn("idcorsostudio", typeof(int),false);
	tattivform.defineColumn("iddidprog", typeof(int),false);
	tattivform.defineColumn("iddidproganno", typeof(int),false);
	tattivform.defineColumn("iddidprogcurr", typeof(int),false);
	tattivform.defineColumn("iddidprogori", typeof(int),false);
	tattivform.defineColumn("iddidprogporzanno", typeof(int),false);
	tattivform.defineColumn("idsede", typeof(int),false);
	tattivform.defineColumn("title", typeof(string));
	Tables.Add(tattivform);
	tattivform.defineKey("aa", "idattivform", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno", "idsede");

	//////////////////// PIANOSTUDIOATTIVFORM /////////////////////////////////
	var tpianostudioattivform= new MetaTable("pianostudioattivform");
	tpianostudioattivform.defineColumn("anno", typeof(int),false);
	tpianostudioattivform.defineColumn("ct", typeof(DateTime),false);
	tpianostudioattivform.defineColumn("cu", typeof(string),false);
	tpianostudioattivform.defineColumn("idattivform", typeof(int),false);
	tpianostudioattivform.defineColumn("idattivform_scelta", typeof(int),false);
	tpianostudioattivform.defineColumn("idcorsostudio", typeof(int),false);
	tpianostudioattivform.defineColumn("iddidprog", typeof(int),false);
	tpianostudioattivform.defineColumn("idiscrizione", typeof(int),false);
	tpianostudioattivform.defineColumn("idiscrizionebmi", typeof(int));
	tpianostudioattivform.defineColumn("idpianostudio", typeof(int),false);
	tpianostudioattivform.defineColumn("idpianostudioattivform", typeof(int),false);
	tpianostudioattivform.defineColumn("idreg", typeof(int),false);
	tpianostudioattivform.defineColumn("idsostenimento", typeof(int));
	tpianostudioattivform.defineColumn("lt", typeof(DateTime),false);
	tpianostudioattivform.defineColumn("lu", typeof(string),false);
	tpianostudioattivform.defineColumn("!idattivform_attivform_title", typeof(string));
	tpianostudioattivform.defineColumn("!idattivform_scelta_attivform_title", typeof(string));
	Tables.Add(tpianostudioattivform);
	tpianostudioattivform.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idpianostudio", "idpianostudioattivform", "idreg");

	//////////////////// PIANOSTUDIOSTATUS /////////////////////////////////
	var tpianostudiostatus= new MetaTable("pianostudiostatus");
	tpianostudiostatus.defineColumn("active", typeof(string),false);
	tpianostudiostatus.defineColumn("idpianostudiostatus", typeof(int),false);
	tpianostudiostatus.defineColumn("title", typeof(string),false);
	Tables.Add(tpianostudiostatus);
	tpianostudiostatus.defineKey("idpianostudiostatus");

	//////////////////// SEDE /////////////////////////////////
	var tsede= new MetaTable("sede");
	tsede.defineColumn("idreg", typeof(int),false);
	tsede.defineColumn("idsede", typeof(int),false);
	tsede.defineColumn("title", typeof(string));
	Tables.Add(tsede);
	tsede.defineKey("idreg", "idsede");

	//////////////////// DIDPROG /////////////////////////////////
	var tdidprog= new MetaTable("didprog");
	tdidprog.defineColumn("aa", typeof(string),false);
	tdidprog.defineColumn("idcorsostudio", typeof(int),false);
	tdidprog.defineColumn("iddidprog", typeof(int),false);
	tdidprog.defineColumn("idsede", typeof(int),false);
	tdidprog.defineColumn("title", typeof(string));
	Tables.Add(tdidprog);
	tdidprog.defineKey("idcorsostudio", "iddidprog");

	//////////////////// ANNOACCADEMICO_ALIAS1 /////////////////////////////////
	var tannoaccademico_alias1= new MetaTable("annoaccademico_alias1");
	tannoaccademico_alias1.defineColumn("aa", typeof(string),false);
	tannoaccademico_alias1.ExtendedProperties["TableForReading"]="annoaccademico";
	Tables.Add(tannoaccademico_alias1);
	tannoaccademico_alias1.defineKey("aa");

	//////////////////// PIANOSTUDIO /////////////////////////////////
	var tpianostudio= new MetaTable("pianostudio");
	tpianostudio.defineColumn("aa", typeof(string));
	tpianostudio.defineColumn("ct", typeof(DateTime),false);
	tpianostudio.defineColumn("cu", typeof(string),false);
	tpianostudio.defineColumn("idcorsostudio", typeof(int));
	tpianostudio.defineColumn("iddidprog", typeof(int));
	tpianostudio.defineColumn("idiscrizione", typeof(int),false);
	tpianostudio.defineColumn("idiscrizionebmi", typeof(int));
	tpianostudio.defineColumn("idpianostudio", typeof(int),false);
	tpianostudio.defineColumn("idpianostudiostatus", typeof(int));
	tpianostudio.defineColumn("idreg", typeof(int),false);
	tpianostudio.defineColumn("lt", typeof(DateTime),false);
	tpianostudio.defineColumn("lu", typeof(string),false);
	tpianostudio.defineColumn("!iddidprog_didprog_title", typeof(string));
	tpianostudio.defineColumn("!iddidprog_didprog_aa", typeof(string));
	tpianostudio.defineColumn("!iddidprog_didprog_idsede_title", typeof(string));
	tpianostudio.defineColumn("!idpianostudiostatus_pianostudiostatus_title", typeof(string));
	tpianostudio.defineColumn("!pianostudioattivform", typeof(string));
	Tables.Add(tpianostudio);
	tpianostudio.defineKey("idiscrizione", "idpianostudio", "idreg");

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
	var cChild = new []{sostenimento.Columns["idiscrizione"], sostenimento.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_sostenimento_iscrizione_idiscrizione-idreg",cPar,cChild,false));

	cPar = new []{sostenimentoesito.Columns["idsostenimentoesito"]};
	cChild = new []{sostenimento.Columns["idsostenimentoesito"]};
	Relations.Add(new DataRelation("FK_sostenimento_sostenimentoesito_idsostenimentoesito",cPar,cChild,false));

	cPar = new []{iscrizione.Columns["idiscrizione"], iscrizione.Columns["idreg"]};
	cChild = new []{pianostudio.Columns["idiscrizione"], pianostudio.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_pianostudio_iscrizione_idiscrizione-idreg",cPar,cChild,false));

	cPar = new []{pianostudio.Columns["idiscrizione"], pianostudio.Columns["idpianostudio"], pianostudio.Columns["idreg"]};
	cChild = new []{pianostudioattivform.Columns["idiscrizione"], pianostudioattivform.Columns["idpianostudio"], pianostudioattivform.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_pianostudioattivform_pianostudio_idiscrizione-idpianostudio-idreg",cPar,cChild,false));

	cPar = new []{pianostudioattivform.Columns["idcorsostudio"], pianostudioattivform.Columns["iddidprog"], pianostudioattivform.Columns["idiscrizione"], pianostudioattivform.Columns["idreg"], pianostudioattivform.Columns["idattivform"], pianostudioattivform.Columns["idsostenimento"]};
	cChild = new []{sostenimento_alias1.Columns["idcorsostudio"], sostenimento_alias1.Columns["iddidprog"], sostenimento_alias1.Columns["idiscrizione"], sostenimento_alias1.Columns["idreg"], sostenimento_alias1.Columns["idattivform"], sostenimento_alias1.Columns["idsostenimento"]};
	Relations.Add(new DataRelation("FK_sostenimento_alias1_pianostudioattivform_idcorsostudio-iddidprog-idiscrizione-idreg-idattivform-idsostenimento",cPar,cChild,false));

	cPar = new []{attivform_alias1.Columns["idattivform"]};
	cChild = new []{pianostudioattivform.Columns["idattivform_scelta"]};
	Relations.Add(new DataRelation("FK_pianostudioattivform_attivform_alias1_idattivform_scelta",cPar,cChild,false));

	cPar = new []{attivform.Columns["idattivform"]};
	cChild = new []{pianostudioattivform.Columns["idattivform"]};
	Relations.Add(new DataRelation("FK_pianostudioattivform_attivform_idattivform",cPar,cChild,false));

	cPar = new []{pianostudiostatus.Columns["idpianostudiostatus"]};
	cChild = new []{pianostudio.Columns["idpianostudiostatus"]};
	Relations.Add(new DataRelation("FK_pianostudio_pianostudiostatus_idpianostudiostatus",cPar,cChild,false));

	cPar = new []{didprog.Columns["iddidprog"]};
	cChild = new []{pianostudio.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_pianostudio_didprog_iddidprog",cPar,cChild,false));

	cPar = new []{sede.Columns["idsede"]};
	cChild = new []{didprog.Columns["idsede"]};
	Relations.Add(new DataRelation("FK_didprog_sede_idsede",cPar,cChild,false));

	cPar = new []{annoaccademico_alias1.Columns["aa"]};
	cChild = new []{pianostudio.Columns["aa"]};
	Relations.Add(new DataRelation("FK_pianostudio_annoaccademico_alias1_aa",cPar,cChild,false));

	cPar = new []{annoaccademico.Columns["aa"]};
	cChild = new []{iscrizione.Columns["aa"]};
	Relations.Add(new DataRelation("FK_iscrizione_annoaccademico_aa",cPar,cChild,false));

	#endregion

}
}
}
