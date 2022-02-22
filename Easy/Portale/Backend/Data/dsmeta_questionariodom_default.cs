
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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
[System.Xml.Serialization.XmlRoot("dsmeta_questionariodom_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_questionariodom_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable questionariodomrisp 		=> (MetaTable)Tables["questionariodomrisp"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable questionariodomkinddefaultview 		=> (MetaTable)Tables["questionariodomkinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable questionariodom 		=> (MetaTable)Tables["questionariodom"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_questionariodom_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_questionariodom_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_questionariodom_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_questionariodom_default.xsd";

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

	//////////////////// QUESTIONARIODOMKINDDEFAULTVIEW /////////////////////////////////
	var tquestionariodomkinddefaultview= new MetaTable("questionariodomkinddefaultview");
	tquestionariodomkinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tquestionariodomkinddefaultview.defineColumn("idquestionariodomkind", typeof(int),false);
	Tables.Add(tquestionariodomkinddefaultview);
	tquestionariodomkinddefaultview.defineKey("idquestionariodomkind");

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
	Tables.Add(tquestionariodom);
	tquestionariodom.defineKey("idquestionario", "idquestionariodom");

	#endregion


	#region DataRelation creation
	var cPar = new []{questionariodom.Columns["idquestionario"], questionariodom.Columns["idquestionariodom"]};
	var cChild = new []{questionariodomrisp.Columns["idquestionario"], questionariodomrisp.Columns["idquestionariodom"]};
	Relations.Add(new DataRelation("FK_questionariodomrisp_questionariodom_idquestionario-idquestionariodom",cPar,cChild,false));

	cPar = new []{questionariodomkinddefaultview.Columns["idquestionariodomkind"]};
	cChild = new []{questionariodom.Columns["idquestionariodomkind"]};
	Relations.Add(new DataRelation("FK_questionariodom_questionariodomkinddefaultview_idquestionariodomkind",cPar,cChild,false));

	#endregion

}
}
}
