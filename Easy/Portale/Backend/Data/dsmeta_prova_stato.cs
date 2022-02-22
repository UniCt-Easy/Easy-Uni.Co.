
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
[System.Xml.Serialization.XmlRoot("dsmeta_prova_stato"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_prova_stato: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable valutazionekind 		=> (MetaTable)Tables["valutazionekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable questionariodefaultview 		=> (MetaTable)Tables["questionariodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable prova 		=> (MetaTable)Tables["prova"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_prova_stato(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_prova_stato (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_prova_stato";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_prova_stato.xsd";

	#region create DataTables
	//////////////////// VALUTAZIONEKIND /////////////////////////////////
	var tvalutazionekind= new MetaTable("valutazionekind");
	tvalutazionekind.defineColumn("idvalutazionekind", typeof(int),false);
	tvalutazionekind.defineColumn("title", typeof(string),false);
	Tables.Add(tvalutazionekind);
	tvalutazionekind.defineKey("idvalutazionekind");

	//////////////////// QUESTIONARIODEFAULTVIEW /////////////////////////////////
	var tquestionariodefaultview= new MetaTable("questionariodefaultview");
	tquestionariodefaultview.defineColumn("dropdown_title", typeof(string),false);
	tquestionariodefaultview.defineColumn("idquestionario", typeof(int),false);
	Tables.Add(tquestionariodefaultview);
	tquestionariodefaultview.defineKey("idquestionario");

	//////////////////// PROVA /////////////////////////////////
	var tprova= new MetaTable("prova");
	tprova.defineColumn("ct", typeof(DateTime),false);
	tprova.defineColumn("cu", typeof(string),false);
	tprova.defineColumn("idappello", typeof(int));
	tprova.defineColumn("idattivform", typeof(int));
	tprova.defineColumn("idcorsostudio", typeof(int),false);
	tprova.defineColumn("iddidprog", typeof(int),false);
	tprova.defineColumn("idprova", typeof(int),false);
	tprova.defineColumn("idquestionario", typeof(int));
	tprova.defineColumn("idvalutazionekind", typeof(int));
	tprova.defineColumn("lt", typeof(DateTime),false);
	tprova.defineColumn("lu", typeof(string),false);
	tprova.defineColumn("programma", typeof(string));
	tprova.defineColumn("start", typeof(DateTime),false);
	tprova.defineColumn("stop", typeof(DateTime),false);
	tprova.defineColumn("title", typeof(string),false);
	Tables.Add(tprova);
	tprova.defineKey("idcorsostudio", "iddidprog", "idprova");

	#endregion


	#region DataRelation creation
	var cPar = new []{valutazionekind.Columns["idvalutazionekind"]};
	var cChild = new []{prova.Columns["idvalutazionekind"]};
	Relations.Add(new DataRelation("FK_prova_valutazionekind_idvalutazionekind",cPar,cChild,false));

	cPar = new []{questionariodefaultview.Columns["idquestionario"]};
	cChild = new []{prova.Columns["idquestionario"]};
	Relations.Add(new DataRelation("FK_prova_questionariodefaultview_idquestionario",cPar,cChild,false));

	#endregion

}
}
}
