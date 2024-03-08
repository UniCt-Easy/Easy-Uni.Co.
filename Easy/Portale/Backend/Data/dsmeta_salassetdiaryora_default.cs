
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
[System.Xml.Serialization.XmlRoot("dsmeta_salassetdiaryora_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_salassetdiaryora_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetdiaryorasegsalview 		=> (MetaTable)Tables["assetdiaryorasegsalview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable salassetdiaryora 		=> (MetaTable)Tables["salassetdiaryora"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_salassetdiaryora_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_salassetdiaryora_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_salassetdiaryora_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_salassetdiaryora_default.xsd";

	#region create DataTables
	//////////////////// ASSETDIARYORASEGSALVIEW /////////////////////////////////
	var tassetdiaryorasegsalview= new MetaTable("assetdiaryorasegsalview");
	tassetdiaryorasegsalview.defineColumn("asset_idasset", typeof(int));
	tassetdiaryorasegsalview.defineColumn("asset_idpiece", typeof(int));
	tassetdiaryorasegsalview.defineColumn("asset_ninventory", typeof(int));
	tassetdiaryorasegsalview.defineColumn("asset_rfid", typeof(string));
	tassetdiaryorasegsalview.defineColumn("assetdiary_idreg", typeof(int));
	tassetdiaryorasegsalview.defineColumn("assetdiaryora_amount", typeof(decimal));
	tassetdiaryorasegsalview.defineColumn("assetdiaryora_ct", typeof(DateTime),false);
	tassetdiaryorasegsalview.defineColumn("assetdiaryora_cu", typeof(string),false);
	tassetdiaryorasegsalview.defineColumn("assetdiaryora_lt", typeof(DateTime),false);
	tassetdiaryorasegsalview.defineColumn("assetdiaryora_lu", typeof(string),false);
	tassetdiaryorasegsalview.defineColumn("assetdiaryora_start", typeof(DateTime));
	tassetdiaryorasegsalview.defineColumn("assetdiaryora_stop", typeof(DateTime));
	tassetdiaryorasegsalview.defineColumn("dropdown_title", typeof(string),false);
	tassetdiaryorasegsalview.defineColumn("idassetdiary", typeof(int),false);
	tassetdiaryorasegsalview.defineColumn("idassetdiaryora", typeof(int),false);
	tassetdiaryorasegsalview.defineColumn("idsal", typeof(int));
	tassetdiaryorasegsalview.defineColumn("idworkpackage", typeof(int),false);
	tassetdiaryorasegsalview.defineColumn("registry_title", typeof(string));
	tassetdiaryorasegsalview.defineColumn("sal_start", typeof(DateTime));
	tassetdiaryorasegsalview.defineColumn("sal_stop", typeof(DateTime));
	tassetdiaryorasegsalview.defineColumn("workpackage_raggruppamento", typeof(string));
	tassetdiaryorasegsalview.defineColumn("workpackage_title", typeof(string));
	Tables.Add(tassetdiaryorasegsalview);
	tassetdiaryorasegsalview.defineKey("idassetdiary", "idassetdiaryora", "idworkpackage");

	//////////////////// SALASSETDIARYORA /////////////////////////////////
	var tsalassetdiaryora= new MetaTable("salassetdiaryora");
	tsalassetdiaryora.defineColumn("ct", typeof(DateTime),false);
	tsalassetdiaryora.defineColumn("cu", typeof(string),false);
	tsalassetdiaryora.defineColumn("idassetdiaryora", typeof(int),false);
	tsalassetdiaryora.defineColumn("idprogetto", typeof(int),false);
	tsalassetdiaryora.defineColumn("idsal", typeof(int),false);
	tsalassetdiaryora.defineColumn("lt", typeof(DateTime),false);
	tsalassetdiaryora.defineColumn("lu", typeof(string),false);
	Tables.Add(tsalassetdiaryora);
	tsalassetdiaryora.defineKey("idassetdiaryora", "idprogetto", "idsal");

	#endregion


	#region DataRelation creation
	var cPar = new []{assetdiaryorasegsalview.Columns["idassetdiaryora"]};
	var cChild = new []{salassetdiaryora.Columns["idassetdiaryora"]};
	Relations.Add(new DataRelation("FK_salassetdiaryora_assetdiaryorasegsalview_idassetdiaryora",cPar,cChild,false));

	#endregion

}
}
}
