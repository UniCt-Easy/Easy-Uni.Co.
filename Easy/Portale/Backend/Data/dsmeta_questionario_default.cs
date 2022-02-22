
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
[System.Xml.Serialization.XmlRoot("dsmeta_questionario_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_questionario_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable questionariodomrisp 		=> (MetaTable)Tables["questionariodomrisp"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable questionariodomkind 		=> (MetaTable)Tables["questionariodomkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable questionariodom 		=> (MetaTable)Tables["questionariodom"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable questionariokinddefaultview 		=> (MetaTable)Tables["questionariokinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable questionario 		=> (MetaTable)Tables["questionario"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_questionario_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_questionario_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_questionario_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_questionario_default.xsd";

	#region create DataTables
	//////////////////// QUESTIONARIODOMRISP /////////////////////////////////
	var tquestionariodomrisp= new MetaTable("questionariodomrisp");
	tquestionariodomrisp.defineColumn("ct", typeof(DateTime),false);
	tquestionariodomrisp.defineColumn("cu", typeof(string),false);
	tquestionariodomrisp.defineColumn("idquestionario", typeof(int),false);
	tquestionariodomrisp.defineColumn("idquestionariodom", typeof(int),false);
	tquestionariodomrisp.defineColumn("idquestionariodomrisp", typeof(int),false);
	tquestionariodomrisp.defineColumn("indicedom", typeof(int));
	tquestionariodomrisp.defineColumn("indicerisp", typeof(int),false);
	tquestionariodomrisp.defineColumn("lt", typeof(DateTime),false);
	tquestionariodomrisp.defineColumn("lu", typeof(string),false);
	tquestionariodomrisp.defineColumn("max", typeof(decimal));
	tquestionariodomrisp.defineColumn("min", typeof(decimal));
	tquestionariodomrisp.defineColumn("multiplacontxt", typeof(string));
	tquestionariodomrisp.defineColumn("punteggio", typeof(decimal));
	tquestionariodomrisp.defineColumn("risposta", typeof(string),false);
	Tables.Add(tquestionariodomrisp);
	tquestionariodomrisp.defineKey("idquestionario", "idquestionariodom", "idquestionariodomrisp");

	//////////////////// QUESTIONARIODOMKIND /////////////////////////////////
	var tquestionariodomkind= new MetaTable("questionariodomkind");
	tquestionariodomkind.defineColumn("active", typeof(string));
	tquestionariodomkind.defineColumn("idquestionariodomkind", typeof(int),false);
	tquestionariodomkind.defineColumn("title", typeof(string),false);
	Tables.Add(tquestionariodomkind);
	tquestionariodomkind.defineKey("idquestionariodomkind");

	//////////////////// QUESTIONARIODOM /////////////////////////////////
	var tquestionariodom= new MetaTable("questionariodom");
	tquestionariodom.defineColumn("ct", typeof(DateTime),false);
	tquestionariodom.defineColumn("cu", typeof(string),false);
	tquestionariodom.defineColumn("domanda", typeof(string));
	tquestionariodom.defineColumn("idquestionario", typeof(int),false);
	tquestionariodom.defineColumn("idquestionariodom", typeof(int),false);
	tquestionariodom.defineColumn("idquestionariodomkind", typeof(int));
	tquestionariodom.defineColumn("indicedom", typeof(int));
	tquestionariodom.defineColumn("lt", typeof(DateTime),false);
	tquestionariodom.defineColumn("lu", typeof(string),false);
	tquestionariodom.defineColumn("!idquestionariodomkind_questionariodomkind_title", typeof(string));
	Tables.Add(tquestionariodom);
	tquestionariodom.defineKey("idquestionario", "idquestionariodom");

	//////////////////// QUESTIONARIOKINDDEFAULTVIEW /////////////////////////////////
	var tquestionariokinddefaultview= new MetaTable("questionariokinddefaultview");
	tquestionariokinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tquestionariokinddefaultview.defineColumn("idquestionariokind", typeof(int),false);
	tquestionariokinddefaultview.defineColumn("questionariokind_active", typeof(string));
	Tables.Add(tquestionariokinddefaultview);
	tquestionariokinddefaultview.defineKey("idquestionariokind");

	//////////////////// QUESTIONARIO /////////////////////////////////
	var tquestionario= new MetaTable("questionario");
	tquestionario.defineColumn("anonimo", typeof(string));
	tquestionario.defineColumn("ct", typeof(DateTime),false);
	tquestionario.defineColumn("cu", typeof(string),false);
	tquestionario.defineColumn("description", typeof(string));
	tquestionario.defineColumn("idquestionario", typeof(int),false);
	tquestionario.defineColumn("idquestionariokind", typeof(int));
	tquestionario.defineColumn("lt", typeof(DateTime),false);
	tquestionario.defineColumn("lu", typeof(string),false);
	tquestionario.defineColumn("title", typeof(string));
	Tables.Add(tquestionario);
	tquestionario.defineKey("idquestionario");

	#endregion


	#region DataRelation creation
	var cPar = new []{questionario.Columns["idquestionario"]};
	var cChild = new []{questionariodom.Columns["idquestionario"]};
	Relations.Add(new DataRelation("FK_questionariodom_questionario_idquestionario",cPar,cChild,false));

	cPar = new []{questionariodom.Columns["idquestionario"], questionariodom.Columns["idquestionariodom"]};
	cChild = new []{questionariodomrisp.Columns["idquestionario"], questionariodomrisp.Columns["idquestionariodom"]};
	Relations.Add(new DataRelation("FK_questionariodomrisp_questionariodom_idquestionario-idquestionariodom",cPar,cChild,false));

	cPar = new []{questionariodomkind.Columns["idquestionariodomkind"]};
	cChild = new []{questionariodom.Columns["idquestionariodomkind"]};
	Relations.Add(new DataRelation("FK_questionariodom_questionariodomkind_idquestionariodomkind",cPar,cChild,false));

	cPar = new []{questionariokinddefaultview.Columns["idquestionariokind"]};
	cChild = new []{questionario.Columns["idquestionariokind"]};
	Relations.Add(new DataRelation("FK_questionario_questionariokinddefaultview_idquestionariokind",cPar,cChild,false));

	#endregion

}
}
}
