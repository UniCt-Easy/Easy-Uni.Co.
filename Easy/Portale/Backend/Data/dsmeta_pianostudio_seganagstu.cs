
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
[System.Xml.Serialization.XmlRoot("dsmeta_pianostudio_seganagstu"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_pianostudio_seganagstu: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sostenimento 		=> (MetaTable)Tables["sostenimento"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry 		=> (MetaTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attivform 		=> (MetaTable)Tables["attivform"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pianostudioattivform 		=> (MetaTable)Tables["pianostudioattivform"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pianostudiostatusdefaultview 		=> (MetaTable)Tables["pianostudiostatusdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico 		=> (MetaTable)Tables["annoaccademico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pianostudio 		=> (MetaTable)Tables["pianostudio"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_pianostudio_seganagstu(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_pianostudio_seganagstu (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_pianostudio_seganagstu";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_pianostudio_seganagstu.xsd";

	#region create DataTables
	//////////////////// SOSTENIMENTO /////////////////////////////////
	var tsostenimento= new MetaTable("sostenimento");
	tsostenimento.defineColumn("idappello", typeof(int),false);
	tsostenimento.defineColumn("idattivform", typeof(int));
	tsostenimento.defineColumn("idprova", typeof(int),false);
	tsostenimento.defineColumn("idreg", typeof(int),false);
	tsostenimento.defineColumn("idsostenimento", typeof(int),false);
	tsostenimento.defineColumn("voto", typeof(decimal));
	tsostenimento.defineColumn("votolode", typeof(string));
	tsostenimento.defineColumn("votosu", typeof(int));
	Tables.Add(tsostenimento);
	tsostenimento.defineKey("idappello", "idprova", "idreg", "idsostenimento");

	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new MetaTable("registry");
	tregistry.defineColumn("idreg", typeof(int),false);
	tregistry.defineColumn("title", typeof(string),false);
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

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
	tpianostudioattivform.defineColumn("!idsostenimento_sostenimento_voto", typeof(decimal));
	tpianostudioattivform.defineColumn("!idsostenimento_sostenimento_votosu", typeof(int));
	tpianostudioattivform.defineColumn("!idsostenimento_sostenimento_votolode", typeof(string));
	tpianostudioattivform.defineColumn("!idsostenimento_sostenimento_idattivform_title", typeof(string));
	tpianostudioattivform.defineColumn("!idsostenimento_sostenimento_idreg_title", typeof(string));
	Tables.Add(tpianostudioattivform);
	tpianostudioattivform.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idpianostudio", "idpianostudioattivform", "idreg");

	//////////////////// PIANOSTUDIOSTATUSDEFAULTVIEW /////////////////////////////////
	var tpianostudiostatusdefaultview= new MetaTable("pianostudiostatusdefaultview");
	tpianostudiostatusdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tpianostudiostatusdefaultview.defineColumn("idpianostudiostatus", typeof(int),false);
	Tables.Add(tpianostudiostatusdefaultview);
	tpianostudiostatusdefaultview.defineKey("idpianostudiostatus");

	//////////////////// ANNOACCADEMICO /////////////////////////////////
	var tannoaccademico= new MetaTable("annoaccademico");
	tannoaccademico.defineColumn("aa", typeof(string),false);
	Tables.Add(tannoaccademico);
	tannoaccademico.defineKey("aa");

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
	Tables.Add(tpianostudio);
	tpianostudio.defineKey("idiscrizione", "idpianostudio", "idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{pianostudio.Columns["idiscrizione"], pianostudio.Columns["idpianostudio"], pianostudio.Columns["idreg"]};
	var cChild = new []{pianostudioattivform.Columns["idiscrizione"], pianostudioattivform.Columns["idpianostudio"], pianostudioattivform.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_pianostudioattivform_pianostudio_idiscrizione-idpianostudio-idreg",cPar,cChild,false));

	cPar = new []{sostenimento.Columns["idsostenimento"]};
	cChild = new []{pianostudioattivform.Columns["idsostenimento"]};
	Relations.Add(new DataRelation("FK_pianostudioattivform_sostenimento_idsostenimento",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{sostenimento.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_sostenimento_registry_idreg",cPar,cChild,false));

	cPar = new []{attivform.Columns["idattivform"]};
	cChild = new []{sostenimento.Columns["idattivform"]};
	Relations.Add(new DataRelation("FK_sostenimento_attivform_idattivform",cPar,cChild,false));

	cPar = new []{attivform.Columns["idattivform"]};
	cChild = new []{pianostudioattivform.Columns["idattivform_scelta"]};
	Relations.Add(new DataRelation("FK_pianostudioattivform_attivform_idattivform_scelta",cPar,cChild,false));

	cPar = new []{attivform.Columns["idattivform"]};
	cChild = new []{pianostudioattivform.Columns["idattivform"]};
	Relations.Add(new DataRelation("FK_pianostudioattivform_attivform_idattivform",cPar,cChild,false));

	cPar = new []{pianostudiostatusdefaultview.Columns["idpianostudiostatus"]};
	cChild = new []{pianostudio.Columns["idpianostudiostatus"]};
	Relations.Add(new DataRelation("FK_pianostudio_pianostudiostatusdefaultview_idpianostudiostatus",cPar,cChild,false));

	cPar = new []{annoaccademico.Columns["aa"]};
	cChild = new []{pianostudio.Columns["aa"]};
	Relations.Add(new DataRelation("FK_pianostudio_annoaccademico_aa",cPar,cChild,false));

	#endregion

}
}
}
