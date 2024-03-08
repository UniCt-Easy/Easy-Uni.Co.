
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
[System.Xml.Serialization.XmlRoot("dsmeta_progettotipocostokindinventorytree_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_progettotipocostokindinventorytree_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable inventorytree 		=> (MetaTable)Tables["inventorytree"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettotipocostokindinventorytree 		=> (MetaTable)Tables["progettotipocostokindinventorytree"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_progettotipocostokindinventorytree_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_progettotipocostokindinventorytree_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_progettotipocostokindinventorytree_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_progettotipocostokindinventorytree_seg.xsd";

	#region create DataTables
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

	//////////////////// PROGETTOTIPOCOSTOKINDINVENTORYTREE /////////////////////////////////
	var tprogettotipocostokindinventorytree= new MetaTable("progettotipocostokindinventorytree");
	tprogettotipocostokindinventorytree.defineColumn("ct", typeof(DateTime),false);
	tprogettotipocostokindinventorytree.defineColumn("cu", typeof(string),false);
	tprogettotipocostokindinventorytree.defineColumn("idinv", typeof(int),false);
	tprogettotipocostokindinventorytree.defineColumn("idprogettokind", typeof(int),false);
	tprogettotipocostokindinventorytree.defineColumn("idprogettotipocostokind", typeof(int),false);
	tprogettotipocostokindinventorytree.defineColumn("lt", typeof(DateTime),false);
	tprogettotipocostokindinventorytree.defineColumn("lu", typeof(string),false);
	Tables.Add(tprogettotipocostokindinventorytree);
	tprogettotipocostokindinventorytree.defineKey("idinv", "idprogettokind", "idprogettotipocostokind");

	#endregion


	#region DataRelation creation
	var cPar = new []{inventorytree.Columns["idinv"]};
	var cChild = new []{progettotipocostokindinventorytree.Columns["idinv"]};
	Relations.Add(new DataRelation("FK_progettotipocostokindinventorytree_inventorytree_idinv",cPar,cChild,false));

	#endregion

}
}
}
