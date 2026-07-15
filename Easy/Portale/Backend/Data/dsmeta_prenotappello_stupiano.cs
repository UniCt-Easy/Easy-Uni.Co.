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
[System.Xml.Serialization.XmlRoot("dsmeta_prenotappello_stupiano"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_prenotappello_stupiano: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable provadefaultview 		=> (MetaTable)Tables["provadefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable appellosegview 		=> (MetaTable)Tables["appellosegview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable prenotappello 		=> (MetaTable)Tables["prenotappello"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_prenotappello_stupiano(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_prenotappello_stupiano (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_prenotappello_stupiano";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_prenotappello_stupiano.xsd";

	#region create DataTables
	//////////////////// PROVADEFAULTVIEW /////////////////////////////////
	var tprovadefaultview= new MetaTable("provadefaultview");
	tprovadefaultview.defineColumn("attivform_title", typeof(string));
	tprovadefaultview.defineColumn("dropdown_title", typeof(string),false);
	tprovadefaultview.defineColumn("idappello", typeof(int),false);
	tprovadefaultview.defineColumn("idprova", typeof(int),false);
	tprovadefaultview.defineColumn("idquestionario", typeof(int));
	tprovadefaultview.defineColumn("idreg_docenti", typeof(int));
	tprovadefaultview.defineColumn("prova_ct", typeof(DateTime),false);
	tprovadefaultview.defineColumn("prova_cu", typeof(string),false);
	tprovadefaultview.defineColumn("prova_idattivform", typeof(int));
	tprovadefaultview.defineColumn("prova_idcorsostudio", typeof(int));
	tprovadefaultview.defineColumn("prova_iddidprog", typeof(int));
	tprovadefaultview.defineColumn("prova_idvalutazionekind", typeof(int));
	tprovadefaultview.defineColumn("prova_lt", typeof(DateTime),false);
	tprovadefaultview.defineColumn("prova_lu", typeof(string),false);
	tprovadefaultview.defineColumn("prova_programma", typeof(string));
	tprovadefaultview.defineColumn("prova_start", typeof(DateTime));
	tprovadefaultview.defineColumn("prova_stop", typeof(DateTime));
	tprovadefaultview.defineColumn("questionario_title", typeof(string));
	tprovadefaultview.defineColumn("title", typeof(string));
	tprovadefaultview.defineColumn("valutazionekind_title", typeof(string));
	Tables.Add(tprovadefaultview);
	tprovadefaultview.defineKey("idappello", "idprova");

	//////////////////// APPELLOSEGVIEW /////////////////////////////////
	var tappellosegview= new MetaTable("appellosegview");
	tappellosegview.defineColumn("dropdown_title", typeof(string),false);
	tappellosegview.defineColumn("idappello", typeof(int),false);
	Tables.Add(tappellosegview);
	tappellosegview.defineKey("idappello");

	//////////////////// PRENOTAPPELLO /////////////////////////////////
	var tprenotappello= new MetaTable("prenotappello");
	tprenotappello.defineColumn("ct", typeof(DateTime),false);
	tprenotappello.defineColumn("cu", typeof(string),false);
	tprenotappello.defineColumn("data", typeof(DateTime),false);
	tprenotappello.defineColumn("idappello", typeof(int),false);
	tprenotappello.defineColumn("idattivform", typeof(int),false);
	tprenotappello.defineColumn("idiscrizione", typeof(int),false);
	tprenotappello.defineColumn("idpianostudio", typeof(int),false);
	tprenotappello.defineColumn("idpianostudioattivform", typeof(int),false);
	tprenotappello.defineColumn("idprenotappello", typeof(int),false);
	tprenotappello.defineColumn("idprova", typeof(int),false);
	tprenotappello.defineColumn("idreg", typeof(int),false);
	tprenotappello.defineColumn("lt", typeof(DateTime),false);
	tprenotappello.defineColumn("lu", typeof(string),false);
	Tables.Add(tprenotappello);
	tprenotappello.defineKey("idappello", "idattivform", "idiscrizione", "idpianostudio", "idpianostudioattivform", "idprenotappello", "idprova", "idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{provadefaultview.Columns["idprova"]};
	var cChild = new []{prenotappello.Columns["idprova"]};
	Relations.Add(new DataRelation("FK_prenotappello_provadefaultview_idprova",cPar,cChild,false));

	cPar = new []{appellosegview.Columns["idappello"]};
	cChild = new []{prenotappello.Columns["idappello"]};
	Relations.Add(new DataRelation("FK_prenotappello_appellosegview_idappello",cPar,cChild,false));

	#endregion

}
}
}
