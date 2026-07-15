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
[System.Xml.Serialization.XmlRoot("dsmeta_pianostudioattivform_stusing"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_pianostudioattivform_stusing: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sostenimentoesito 		=> (MetaTable)Tables["sostenimentoesito"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sostenimento 		=> (MetaTable)Tables["sostenimento"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attivformdefaultview_alias1 		=> (MetaTable)Tables["attivformdefaultview_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attivformdefaultview 		=> (MetaTable)Tables["attivformdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pianostudioattivform 		=> (MetaTable)Tables["pianostudioattivform"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_pianostudioattivform_stusing(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_pianostudioattivform_stusing (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_pianostudioattivform_stusing";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_pianostudioattivform_stusing.xsd";

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
	tsostenimento.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tsostenimento);
	tsostenimento.defineKey("idiscrizione", "idreg", "idsostenimento");

	//////////////////// ATTIVFORMDEFAULTVIEW_ALIAS1 /////////////////////////////////
	var tattivformdefaultview_alias1= new MetaTable("attivformdefaultview_alias1");
	tattivformdefaultview_alias1.defineColumn("aa", typeof(string),false);
	tattivformdefaultview_alias1.defineColumn("dropdown_title", typeof(string),false);
	tattivformdefaultview_alias1.defineColumn("idattivform", typeof(int),false);
	tattivformdefaultview_alias1.defineColumn("idcorsostudio", typeof(int),false);
	tattivformdefaultview_alias1.defineColumn("iddidprog", typeof(int),false);
	tattivformdefaultview_alias1.defineColumn("iddidproganno", typeof(int),false);
	tattivformdefaultview_alias1.defineColumn("iddidprogcurr", typeof(int),false);
	tattivformdefaultview_alias1.defineColumn("iddidprogori", typeof(int),false);
	tattivformdefaultview_alias1.defineColumn("iddidprogporzanno", typeof(int),false);
	tattivformdefaultview_alias1.defineColumn("idsede", typeof(int),false);
	tattivformdefaultview_alias1.ExtendedProperties["TableForReading"]="attivformdefaultview";
	Tables.Add(tattivformdefaultview_alias1);
	tattivformdefaultview_alias1.defineKey("aa", "idattivform", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno", "idsede");

	//////////////////// ATTIVFORMDEFAULTVIEW /////////////////////////////////
	var tattivformdefaultview= new MetaTable("attivformdefaultview");
	tattivformdefaultview.defineColumn("aa", typeof(string),false);
	tattivformdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tattivformdefaultview.defineColumn("idattivform", typeof(int),false);
	tattivformdefaultview.defineColumn("idcorsostudio", typeof(int),false);
	tattivformdefaultview.defineColumn("iddidprog", typeof(int),false);
	tattivformdefaultview.defineColumn("iddidproganno", typeof(int),false);
	tattivformdefaultview.defineColumn("iddidprogcurr", typeof(int),false);
	tattivformdefaultview.defineColumn("iddidprogori", typeof(int),false);
	tattivformdefaultview.defineColumn("iddidprogporzanno", typeof(int),false);
	tattivformdefaultview.defineColumn("idsede", typeof(int),false);
	Tables.Add(tattivformdefaultview);
	tattivformdefaultview.defineKey("aa", "idattivform", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno", "idsede");

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
	Tables.Add(tpianostudioattivform);
	tpianostudioattivform.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idpianostudio", "idpianostudioattivform", "idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{pianostudioattivform.Columns["idcorsostudio"], pianostudioattivform.Columns["iddidprog"], pianostudioattivform.Columns["idiscrizione"], pianostudioattivform.Columns["idreg"], pianostudioattivform.Columns["idattivform"], pianostudioattivform.Columns["idsostenimento"]};
	var cChild = new []{sostenimento.Columns["idcorsostudio"], sostenimento.Columns["iddidprog"], sostenimento.Columns["idiscrizione"], sostenimento.Columns["idreg"], sostenimento.Columns["idattivform"], sostenimento.Columns["idsostenimento"]};
	Relations.Add(new DataRelation("FK_sostenimento_pianostudioattivform_idcorsostudio-iddidprog-idiscrizione-idreg-idattivform-idsostenimento",cPar,cChild,false));

	cPar = new []{sostenimentoesito.Columns["idsostenimentoesito"]};
	cChild = new []{sostenimento.Columns["idsostenimentoesito"]};
	Relations.Add(new DataRelation("FK_sostenimento_sostenimentoesito_idsostenimentoesito",cPar,cChild,false));

	cPar = new []{attivformdefaultview_alias1.Columns["idattivform"]};
	cChild = new []{pianostudioattivform.Columns["idattivform_scelta"]};
	Relations.Add(new DataRelation("FK_pianostudioattivform_attivformdefaultview_alias1_idattivform_scelta",cPar,cChild,false));

	cPar = new []{attivformdefaultview.Columns["idattivform"]};
	cChild = new []{pianostudioattivform.Columns["idattivform"]};
	Relations.Add(new DataRelation("FK_pianostudioattivform_attivformdefaultview_idattivform",cPar,cChild,false));

	#endregion

}
}
}
