
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
[System.Xml.Serialization.XmlRoot("dsmeta_protocollodestinatario_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_protocollodestinatario_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrydefaultview 		=> (MetaTable)Tables["registrydefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable protocollodestinatario 		=> (MetaTable)Tables["protocollodestinatario"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_protocollodestinatario_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_protocollodestinatario_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_protocollodestinatario_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_protocollodestinatario_seg.xsd";

	#region create DataTables
	//////////////////// REGISTRYDEFAULTVIEW /////////////////////////////////
	var tregistrydefaultview= new MetaTable("registrydefaultview");
	tregistrydefaultview.defineColumn("dropdown_title", typeof(string),false);
	tregistrydefaultview.defineColumn("idcategory", typeof(string));
	tregistrydefaultview.defineColumn("idcentralizedcategory", typeof(string));
	tregistrydefaultview.defineColumn("idcity", typeof(int));
	tregistrydefaultview.defineColumn("idnation", typeof(int));
	tregistrydefaultview.defineColumn("idreg", typeof(int),false);
	tregistrydefaultview.defineColumn("idregistryclass", typeof(string));
	tregistrydefaultview.defineColumn("idtitle", typeof(string));
	tregistrydefaultview.defineColumn("residence", typeof(int),false);
	Tables.Add(tregistrydefaultview);
	tregistrydefaultview.defineKey("idreg");

	//////////////////// PROTOCOLLODESTINATARIO /////////////////////////////////
	var tprotocollodestinatario= new MetaTable("protocollodestinatario");
	tprotocollodestinatario.defineColumn("ct", typeof(DateTime));
	tprotocollodestinatario.defineColumn("cu", typeof(string));
	tprotocollodestinatario.defineColumn("destcodiceaoo", typeof(string));
	tprotocollodestinatario.defineColumn("destidamm", typeof(string));
	tprotocollodestinatario.defineColumn("destmail", typeof(string));
	tprotocollodestinatario.defineColumn("idprotocollodestinatario", typeof(int),false);
	tprotocollodestinatario.defineColumn("idreg_dest", typeof(int));
	tprotocollodestinatario.defineColumn("lt", typeof(DateTime));
	tprotocollodestinatario.defineColumn("lu", typeof(string));
	tprotocollodestinatario.defineColumn("protanno", typeof(int),false);
	tprotocollodestinatario.defineColumn("protnumero", typeof(int),false);
	Tables.Add(tprotocollodestinatario);
	tprotocollodestinatario.defineKey("idprotocollodestinatario", "protanno", "protnumero");

	#endregion


	#region DataRelation creation
	var cPar = new []{registrydefaultview.Columns["idreg"]};
	var cChild = new []{protocollodestinatario.Columns["idreg_dest"]};
	Relations.Add(new DataRelation("FK_protocollodestinatario_registrydefaultview_idreg_dest",cPar,cChild,false));

	#endregion

}
}
}
