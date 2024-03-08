
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
[System.Xml.Serialization.XmlRoot("dsmeta_assetdiary_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_assetdiary_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sal 		=> (MetaTable)Tables["sal"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetdiaryora 		=> (MetaTable)Tables["assetdiaryora"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getregistrydocentiamministratividefaultview 		=> (MetaTable)Tables["getregistrydocentiamministratividefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable asset 		=> (MetaTable)Tables["asset"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetsegview 		=> (MetaTable)Tables["assetsegview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetdiary 		=> (MetaTable)Tables["assetdiary"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_assetdiary_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_assetdiary_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_assetdiary_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_assetdiary_seg.xsd";

	#region create DataTables
	//////////////////// SAL /////////////////////////////////
	var tsal= new MetaTable("sal");
	tsal.defineColumn("idprogetto", typeof(int),false);
	tsal.defineColumn("idsal", typeof(int),false);
	tsal.defineColumn("start", typeof(DateTime));
	tsal.defineColumn("stop", typeof(DateTime));
	Tables.Add(tsal);
	tsal.defineKey("idprogetto", "idsal");

	//////////////////// ASSETDIARYORA /////////////////////////////////
	var tassetdiaryora= new MetaTable("assetdiaryora");
	tassetdiaryora.defineColumn("!title", typeof(string));
	tassetdiaryora.defineColumn("amount", typeof(decimal));
	tassetdiaryora.defineColumn("ct", typeof(DateTime),false);
	tassetdiaryora.defineColumn("cu", typeof(string),false);
	tassetdiaryora.defineColumn("idassetdiary", typeof(int),false);
	tassetdiaryora.defineColumn("idassetdiaryora", typeof(int),false);
	tassetdiaryora.defineColumn("idsal", typeof(int));
	tassetdiaryora.defineColumn("idworkpackage", typeof(int),false);
	tassetdiaryora.defineColumn("lt", typeof(DateTime),false);
	tassetdiaryora.defineColumn("lu", typeof(string),false);
	tassetdiaryora.defineColumn("start", typeof(DateTime));
	tassetdiaryora.defineColumn("stop", typeof(DateTime));
	tassetdiaryora.defineColumn("!idsal_sal_start", typeof(DateTime));
	tassetdiaryora.defineColumn("!idsal_sal_stop", typeof(DateTime));
	Tables.Add(tassetdiaryora);
	tassetdiaryora.defineKey("idassetdiary", "idassetdiaryora", "idworkpackage");

	//////////////////// GETREGISTRYDOCENTIAMMINISTRATIVIDEFAULTVIEW /////////////////////////////////
	var tgetregistrydocentiamministratividefaultview= new MetaTable("getregistrydocentiamministratividefaultview");
	tgetregistrydocentiamministratividefaultview.defineColumn("dropdown_title", typeof(string),false);
	tgetregistrydocentiamministratividefaultview.defineColumn("getregistrydocentiamministrativi_cf", typeof(string));
	tgetregistrydocentiamministratividefaultview.defineColumn("getregistrydocentiamministrativi_contratto", typeof(string));
	tgetregistrydocentiamministratividefaultview.defineColumn("getregistrydocentiamministrativi_extmatricula", typeof(string));
	tgetregistrydocentiamministratividefaultview.defineColumn("getregistrydocentiamministrativi_forename", typeof(string));
	tgetregistrydocentiamministratividefaultview.defineColumn("getregistrydocentiamministrativi_istituto", typeof(string));
	tgetregistrydocentiamministratividefaultview.defineColumn("getregistrydocentiamministrativi_ssd", typeof(string));
	tgetregistrydocentiamministratividefaultview.defineColumn("getregistrydocentiamministrativi_struttura", typeof(string));
	tgetregistrydocentiamministratividefaultview.defineColumn("idreg", typeof(int),false);
	tgetregistrydocentiamministratividefaultview.defineColumn("surname", typeof(string));
	Tables.Add(tgetregistrydocentiamministratividefaultview);
	tgetregistrydocentiamministratividefaultview.defineKey("idreg");

	//////////////////// ASSET /////////////////////////////////
	var tasset= new MetaTable("asset");
	tasset.defineColumn("idasset", typeof(int),false);
	tasset.defineColumn("idinventory", typeof(int));
	tasset.defineColumn("idpiece", typeof(int),false);
	tasset.defineColumn("nassetacquire", typeof(int));
	tasset.defineColumn("ninventory", typeof(int));
	tasset.defineColumn("rfid", typeof(string));
	Tables.Add(tasset);
	tasset.defineKey("idasset", "idpiece");

	//////////////////// ASSETSEGVIEW /////////////////////////////////
	var tassetsegview= new MetaTable("assetsegview");
	tassetsegview.defineColumn("asset_amortizationquota", typeof(decimal));
	tassetsegview.defineColumn("asset_ct", typeof(DateTime),false);
	tassetsegview.defineColumn("asset_cu", typeof(string),false);
	tassetsegview.defineColumn("asset_flag", typeof(int),false);
	tassetsegview.defineColumn("asset_idasset_prev", typeof(int));
	tassetsegview.defineColumn("asset_idassetunload", typeof(int));
	tassetsegview.defineColumn("asset_idcurrlocation", typeof(int));
	tassetsegview.defineColumn("asset_idcurrman", typeof(int));
	tassetsegview.defineColumn("asset_idcurrsubman", typeof(int));
	tassetsegview.defineColumn("asset_idinventoryamortization", typeof(int));
	tassetsegview.defineColumn("asset_idpiece_prev", typeof(int));
	tassetsegview.defineColumn("asset_lifestart", typeof(DateTime));
	tassetsegview.defineColumn("asset_lt", typeof(DateTime),false);
	tassetsegview.defineColumn("asset_lu", typeof(string),false);
	tassetsegview.defineColumn("asset_multifield", typeof(string));
	tassetsegview.defineColumn("asset_ninventory", typeof(int));
	tassetsegview.defineColumn("asset_rfid", typeof(string));
	tassetsegview.defineColumn("asset_rtf", typeof(Byte[]));
	tassetsegview.defineColumn("asset_transmitted", typeof(string));
	tassetsegview.defineColumn("asset_txt", typeof(string));
	tassetsegview.defineColumn("assetacquire_description", typeof(string));
	tassetsegview.defineColumn("dropdown_title", typeof(string),false);
	tassetsegview.defineColumn("idasset", typeof(int),false);
	tassetsegview.defineColumn("idinventory", typeof(int));
	tassetsegview.defineColumn("idpiece", typeof(int),false);
	tassetsegview.defineColumn("inventory_description", typeof(string));
	tassetsegview.defineColumn("inventorytree_codeinv", typeof(string));
	tassetsegview.defineColumn("inventorytree_description", typeof(string));
	tassetsegview.defineColumn("inventorytree_idinv", typeof(int));
	tassetsegview.defineColumn("nassetacquire", typeof(int));
	tassetsegview.defineColumn("upb_codeupb", typeof(string));
	tassetsegview.defineColumn("upb_idupb", typeof(string));
	tassetsegview.defineColumn("upb_title", typeof(string));
	Tables.Add(tassetsegview);
	tassetsegview.defineKey("idasset", "idpiece");

	//////////////////// ASSETDIARY /////////////////////////////////
	var tassetdiary= new MetaTable("assetdiary");
	tassetdiary.defineColumn("!amount", typeof(string));
	tassetdiary.defineColumn("ct", typeof(DateTime),false);
	tassetdiary.defineColumn("cu", typeof(string),false);
	tassetdiary.defineColumn("idasset", typeof(int),false);
	tassetdiary.defineColumn("idassetdiary", typeof(int),false);
	tassetdiary.defineColumn("idpiece", typeof(int));
	tassetdiary.defineColumn("idprogetto", typeof(int),false);
	tassetdiary.defineColumn("idreg", typeof(int),false);
	tassetdiary.defineColumn("idworkpackage", typeof(int),false);
	tassetdiary.defineColumn("lt", typeof(DateTime),false);
	tassetdiary.defineColumn("lu", typeof(string),false);
	tassetdiary.defineColumn("orepreventivate", typeof(int));
	Tables.Add(tassetdiary);
	tassetdiary.defineKey("idassetdiary", "idworkpackage");

	#endregion


	#region DataRelation creation
	var cPar = new []{assetdiary.Columns["idassetdiary"], assetdiary.Columns["idworkpackage"]};
	var cChild = new []{assetdiaryora.Columns["idassetdiary"], assetdiaryora.Columns["idworkpackage"]};
	Relations.Add(new DataRelation("FK_assetdiaryora_assetdiary_idassetdiary-idworkpackage",cPar,cChild,false));

	cPar = new []{sal.Columns["idsal"]};
	cChild = new []{assetdiaryora.Columns["idsal"]};
	Relations.Add(new DataRelation("FK_assetdiaryora_sal_idsal",cPar,cChild,false));

	cPar = new []{getregistrydocentiamministratividefaultview.Columns["idreg"]};
	cChild = new []{assetdiary.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_assetdiary_getregistrydocentiamministratividefaultview_idreg",cPar,cChild,false));

	cPar = new []{asset.Columns["idasset"]};
	cChild = new []{assetdiary.Columns["idasset"]};
	Relations.Add(new DataRelation("FK_assetdiary_asset_idasset",cPar,cChild,false));

	cPar = new []{assetsegview.Columns["idasset"], assetsegview.Columns["idpiece"]};
	cChild = new []{assetdiary.Columns["idasset"], assetdiary.Columns["idpiece"]};
	Relations.Add(new DataRelation("FK_assetdiary_assetsegview_idasset-idpiece",cPar,cChild,false));

	#endregion

}
}
}
