
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
[System.Xml.Serialization.XmlRoot("dsmeta_inventorytree_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_inventorytree_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable inventorytreesegview 		=> (MetaTable)Tables["inventorytreesegview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accmotivedefaultview 		=> (MetaTable)Tables["accmotivedefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable inventorytree 		=> (MetaTable)Tables["inventorytree"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_inventorytree_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_inventorytree_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_inventorytree_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_inventorytree_seg.xsd";

	#region create DataTables
	//////////////////// INVENTORYTREESEGVIEW /////////////////////////////////
	var tinventorytreesegview= new MetaTable("inventorytreesegview");
	tinventorytreesegview.defineColumn("dropdown_title", typeof(string),false);
	tinventorytreesegview.defineColumn("idaccmotiveload", typeof(string));
	tinventorytreesegview.defineColumn("idinv", typeof(int),false);
	tinventorytreesegview.defineColumn("paridinv", typeof(int));
	Tables.Add(tinventorytreesegview);
	tinventorytreesegview.defineKey("idinv");

	//////////////////// ACCMOTIVEDEFAULTVIEW /////////////////////////////////
	var taccmotivedefaultview= new MetaTable("accmotivedefaultview");
	taccmotivedefaultview.defineColumn("dropdown_title", typeof(string),false);
	taccmotivedefaultview.defineColumn("idaccmotive", typeof(string),false);
	taccmotivedefaultview.defineColumn("paridaccmotive", typeof(string));
	Tables.Add(taccmotivedefaultview);
	taccmotivedefaultview.defineKey("idaccmotive");

	//////////////////// INVENTORYTREE /////////////////////////////////
	var tinventorytree= new MetaTable("inventorytree");
	tinventorytree.defineColumn("codeinv", typeof(string),false);
	tinventorytree.defineColumn("ct", typeof(DateTime),false);
	tinventorytree.defineColumn("cu", typeof(string),false);
	tinventorytree.defineColumn("description", typeof(string),false);
	tinventorytree.defineColumn("idaccmotivediscount", typeof(string));
	tinventorytree.defineColumn("idaccmotiveload", typeof(string));
	tinventorytree.defineColumn("idaccmotivetransfer", typeof(string));
	tinventorytree.defineColumn("idaccmotiveunload", typeof(string));
	tinventorytree.defineColumn("idinv", typeof(int),false);
	tinventorytree.defineColumn("lookupcode", typeof(string));
	tinventorytree.defineColumn("lt", typeof(DateTime),false);
	tinventorytree.defineColumn("lu", typeof(string),false);
	tinventorytree.defineColumn("nlevel", typeof(int),false);
	tinventorytree.defineColumn("paridinv", typeof(int));
	tinventorytree.defineColumn("rtf", typeof(Byte[]));
	tinventorytree.defineColumn("txt", typeof(string));
	Tables.Add(tinventorytree);
	tinventorytree.defineKey("idinv");

	#endregion


	#region DataRelation creation
	var cPar = new []{inventorytreesegview.Columns["idinv"]};
	var cChild = new []{inventorytree.Columns["paridinv"]};
	Relations.Add(new DataRelation("FK_inventorytree_inventorytreesegview_paridinv",cPar,cChild,false));

	cPar = new []{accmotivedefaultview.Columns["idaccmotive"]};
	cChild = new []{inventorytree.Columns["idaccmotiveload"]};
	Relations.Add(new DataRelation("FK_inventorytree_accmotivedefaultview_idaccmotiveload",cPar,cChild,false));

	#endregion

}
}
}
