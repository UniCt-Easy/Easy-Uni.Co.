
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
[System.Xml.Serialization.XmlRoot("dsmeta_assetconsignsubasset_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_assetconsignsubasset_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetsegview 		=> (MetaTable)Tables["assetsegview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetconsignsubasset 		=> (MetaTable)Tables["assetconsignsubasset"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_assetconsignsubasset_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_assetconsignsubasset_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_assetconsignsubasset_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_assetconsignsubasset_default.xsd";

	#region create DataTables
	//////////////////// ASSETSEGVIEW /////////////////////////////////
	var tassetsegview= new MetaTable("assetsegview");
	tassetsegview.defineColumn("dropdown_title", typeof(string),false);
	tassetsegview.defineColumn("idasset", typeof(int),false);
	tassetsegview.defineColumn("idpiece", typeof(int),false);
	Tables.Add(tassetsegview);
	tassetsegview.defineKey("idasset", "idpiece");

	//////////////////// ASSETCONSIGNSUBASSET /////////////////////////////////
	var tassetconsignsubasset= new MetaTable("assetconsignsubasset");
	tassetconsignsubasset.defineColumn("ct", typeof(DateTime));
	tassetconsignsubasset.defineColumn("cu", typeof(string));
	tassetconsignsubasset.defineColumn("idasset", typeof(int),false);
	tassetconsignsubasset.defineColumn("idassetconsignsub", typeof(int),false);
	tassetconsignsubasset.defineColumn("idassetconsignsubasset", typeof(int),false);
	tassetconsignsubasset.defineColumn("idassetload", typeof(int),false);
	tassetconsignsubasset.defineColumn("idassetloadsub", typeof(int),false);
	tassetconsignsubasset.defineColumn("idassetlocation", typeof(int));
	tassetconsignsubasset.defineColumn("idinv", typeof(int),false);
	tassetconsignsubasset.defineColumn("idinventory", typeof(int),false);
	tassetconsignsubasset.defineColumn("idlocation", typeof(int));
	tassetconsignsubasset.defineColumn("idpiece", typeof(int),false);
	tassetconsignsubasset.defineColumn("lt", typeof(DateTime));
	tassetconsignsubasset.defineColumn("lu", typeof(string));
	tassetconsignsubasset.defineColumn("nassetacquire", typeof(int),false);
	Tables.Add(tassetconsignsubasset);
	tassetconsignsubasset.defineKey("idassetconsignsub", "idassetconsignsubasset", "idassetload", "idassetloadsub");

	#endregion


	#region DataRelation creation
	var cPar = new []{assetsegview.Columns["idasset"]};
	var cChild = new []{assetconsignsubasset.Columns["idasset"]};
	Relations.Add(new DataRelation("FK_assetconsignsubasset_assetsegview_idasset",cPar,cChild,false));

	#endregion

}
}
}
