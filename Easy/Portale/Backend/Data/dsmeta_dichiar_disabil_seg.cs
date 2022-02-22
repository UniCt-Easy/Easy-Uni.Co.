
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
[System.Xml.Serialization.XmlRoot("dsmeta_dichiar_disabil_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_dichiar_disabil_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable dichiarkind 		=> (MetaTable)Tables["dichiarkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable dichiardisabilsuppkinddefaultview 		=> (MetaTable)Tables["dichiardisabilsuppkinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable dichiardisabilkinddefaultview 		=> (MetaTable)Tables["dichiardisabilkinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrystudentiview 		=> (MetaTable)Tables["registrystudentiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico 		=> (MetaTable)Tables["annoaccademico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable dichiar 		=> (MetaTable)Tables["dichiar"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable dichiar_disabil 		=> (MetaTable)Tables["dichiar_disabil"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_dichiar_disabil_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_dichiar_disabil_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_dichiar_disabil_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_dichiar_disabil_seg.xsd";

	#region create DataTables
	//////////////////// DICHIARKIND /////////////////////////////////
	var tdichiarkind= new MetaTable("dichiarkind");
	tdichiarkind.defineColumn("active", typeof(string),false);
	tdichiarkind.defineColumn("ct", typeof(DateTime),false);
	tdichiarkind.defineColumn("cu", typeof(string),false);
	tdichiarkind.defineColumn("description", typeof(string),false);
	tdichiarkind.defineColumn("iddichiarkind", typeof(int),false);
	tdichiarkind.defineColumn("lt", typeof(DateTime),false);
	tdichiarkind.defineColumn("lu", typeof(string),false);
	tdichiarkind.defineColumn("sortcode", typeof(int),false);
	tdichiarkind.defineColumn("title", typeof(string),false);
	Tables.Add(tdichiarkind);
	tdichiarkind.defineKey("iddichiarkind");

	//////////////////// DICHIARDISABILSUPPKINDDEFAULTVIEW /////////////////////////////////
	var tdichiardisabilsuppkinddefaultview= new MetaTable("dichiardisabilsuppkinddefaultview");
	tdichiardisabilsuppkinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tdichiardisabilsuppkinddefaultview.defineColumn("iddichiardisabilsuppkind", typeof(int),false);
	Tables.Add(tdichiardisabilsuppkinddefaultview);
	tdichiardisabilsuppkinddefaultview.defineKey("iddichiardisabilsuppkind");

	//////////////////// DICHIARDISABILKINDDEFAULTVIEW /////////////////////////////////
	var tdichiardisabilkinddefaultview= new MetaTable("dichiardisabilkinddefaultview");
	tdichiardisabilkinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tdichiardisabilkinddefaultview.defineColumn("iddichiardisabilkind", typeof(int),false);
	Tables.Add(tdichiardisabilkinddefaultview);
	tdichiardisabilkinddefaultview.defineKey("iddichiardisabilkind");

	//////////////////// REGISTRYSTUDENTIVIEW /////////////////////////////////
	var tregistrystudentiview= new MetaTable("registrystudentiview");
	tregistrystudentiview.defineColumn("dropdown_title", typeof(string),false);
	tregistrystudentiview.defineColumn("idcity", typeof(int));
	tregistrystudentiview.defineColumn("idnation", typeof(int));
	tregistrystudentiview.defineColumn("idreg", typeof(int),false);
	tregistrystudentiview.defineColumn("idregistryclass", typeof(string));
	tregistrystudentiview.defineColumn("idtitle", typeof(string));
	tregistrystudentiview.defineColumn("residence", typeof(int),false);
	Tables.Add(tregistrystudentiview);
	tregistrystudentiview.defineKey("idreg");

	//////////////////// ANNOACCADEMICO /////////////////////////////////
	var tannoaccademico= new MetaTable("annoaccademico");
	tannoaccademico.defineColumn("aa", typeof(string),false);
	Tables.Add(tannoaccademico);
	tannoaccademico.defineKey("aa");

	//////////////////// DICHIAR /////////////////////////////////
	var tdichiar= new MetaTable("dichiar");
	tdichiar.defineColumn("aa", typeof(string));
	tdichiar.defineColumn("ct", typeof(DateTime),false);
	tdichiar.defineColumn("cu", typeof(string),false);
	tdichiar.defineColumn("date", typeof(DateTime),false);
	tdichiar.defineColumn("extension", typeof(string));
	tdichiar.defineColumn("iddichiar", typeof(int),false);
	tdichiar.defineColumn("iddichiarkind", typeof(int),false);
	tdichiar.defineColumn("idreg", typeof(int),false);
	tdichiar.defineColumn("lt", typeof(DateTime),false);
	tdichiar.defineColumn("lu", typeof(string),false);
	tdichiar.defineColumn("protanno", typeof(int));
	tdichiar.defineColumn("protnumero", typeof(int));
	Tables.Add(tdichiar);
	tdichiar.defineKey("iddichiar", "idreg");

	//////////////////// DICHIAR_DISABIL /////////////////////////////////
	var tdichiar_disabil= new MetaTable("dichiar_disabil");
	tdichiar_disabil.defineColumn("ct", typeof(DateTime),false);
	tdichiar_disabil.defineColumn("cu", typeof(string),false);
	tdichiar_disabil.defineColumn("iddichiar", typeof(int),false);
	tdichiar_disabil.defineColumn("iddichiardisabilkind", typeof(int),false);
	tdichiar_disabil.defineColumn("iddichiardisabilsuppkind", typeof(int));
	tdichiar_disabil.defineColumn("idreg", typeof(int),false);
	tdichiar_disabil.defineColumn("lt", typeof(DateTime),false);
	tdichiar_disabil.defineColumn("lu", typeof(string),false);
	tdichiar_disabil.defineColumn("percentuale", typeof(decimal));
	tdichiar_disabil.defineColumn("permanente", typeof(string),false);
	tdichiar_disabil.defineColumn("scadenza", typeof(DateTime));
	Tables.Add(tdichiar_disabil);
	tdichiar_disabil.defineKey("iddichiar", "idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{dichiardisabilsuppkinddefaultview.Columns["iddichiardisabilsuppkind"]};
	var cChild = new []{dichiar_disabil.Columns["iddichiardisabilsuppkind"]};
	Relations.Add(new DataRelation("FK_dichiar_disabil_dichiardisabilsuppkinddefaultview_iddichiardisabilsuppkind",cPar,cChild,false));

	cPar = new []{dichiardisabilkinddefaultview.Columns["iddichiardisabilkind"]};
	cChild = new []{dichiar_disabil.Columns["iddichiardisabilkind"]};
	Relations.Add(new DataRelation("FK_dichiar_disabil_dichiardisabilkinddefaultview_iddichiardisabilkind",cPar,cChild,false));

	cPar = new []{registrystudentiview.Columns["idreg"]};
	cChild = new []{dichiar.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_dichiar_registrystudentiview_idreg",cPar,cChild,false));

	cPar = new []{annoaccademico.Columns["aa"]};
	cChild = new []{dichiar.Columns["aa"]};
	Relations.Add(new DataRelation("FK_dichiar_annoaccademico_aa",cPar,cChild,false));

	cPar = new []{dichiar.Columns["iddichiar"], dichiar.Columns["idreg"]};
	cChild = new []{dichiar_disabil.Columns["iddichiar"], dichiar_disabil.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_dichiar_disabil_dichiar_iddichiar-idreg-",cPar,cChild,false));

	#endregion

}
}
}
