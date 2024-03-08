
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
[System.Xml.Serialization.XmlRoot("dsmeta_pianostudioattivform_didprog"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_pianostudioattivform_didprog: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sostenimentodefaultview 		=> (MetaTable)Tables["sostenimentodefaultview"];

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
public dsmeta_pianostudioattivform_didprog(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_pianostudioattivform_didprog (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_pianostudioattivform_didprog";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_pianostudioattivform_didprog.xsd";

	#region create DataTables
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
	tattivformdefaultview_alias1.defineColumn("idinsegn", typeof(int),false);
	tattivformdefaultview_alias1.defineColumn("idinsegninteg", typeof(int));
	tattivformdefaultview_alias1.defineColumn("idsede", typeof(int),false);
	tattivformdefaultview_alias1.ExtendedProperties["TableForReading"]="attivformdefaultview";
	Tables.Add(tattivformdefaultview_alias1);
	tattivformdefaultview_alias1.defineKey("idattivform");

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
	tattivformdefaultview.defineColumn("idinsegn", typeof(int),false);
	tattivformdefaultview.defineColumn("idinsegninteg", typeof(int));
	tattivformdefaultview.defineColumn("idsede", typeof(int),false);
	Tables.Add(tattivformdefaultview);
	tattivformdefaultview.defineKey("idattivform");

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
	var cPar = new []{sostenimentodefaultview.Columns["idsostenimento"]};
	var cChild = new []{pianostudioattivform.Columns["idsostenimento"]};
	Relations.Add(new DataRelation("FK_pianostudioattivform_sostenimentodefaultview_idsostenimento",cPar,cChild,false));

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
