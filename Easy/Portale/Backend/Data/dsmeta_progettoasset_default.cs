
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
[System.Xml.Serialization.XmlRoot("dsmeta_progettoasset_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_progettoasset_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetsegview 		=> (MetaTable)Tables["assetsegview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettoasset 		=> (MetaTable)Tables["progettoasset"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_progettoasset_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_progettoasset_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_progettoasset_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_progettoasset_default.xsd";

	#region create DataTables
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

	//////////////////// PROGETTOASSET /////////////////////////////////
	var tprogettoasset= new MetaTable("progettoasset");
	tprogettoasset.defineColumn("!altreupb", typeof(string));
	tprogettoasset.defineColumn("!ammortamento", typeof(string));
	tprogettoasset.defineColumn("aggiunta", typeof(string));
	tprogettoasset.defineColumn("ammortamentopreventivato", typeof(decimal));
	tprogettoasset.defineColumn("costoorario", typeof(decimal));
	tprogettoasset.defineColumn("ct", typeof(DateTime),false);
	tprogettoasset.defineColumn("cu", typeof(string),false);
	tprogettoasset.defineColumn("descammortamentopreventivato", typeof(string));
	tprogettoasset.defineColumn("idasset", typeof(int),false);
	tprogettoasset.defineColumn("idpiece", typeof(int),false);
	tprogettoasset.defineColumn("idprogetto", typeof(int),false);
	tprogettoasset.defineColumn("lt", typeof(DateTime),false);
	tprogettoasset.defineColumn("lu", typeof(string),false);
	tprogettoasset.defineColumn("start", typeof(DateTime));
	tprogettoasset.defineColumn("stop", typeof(DateTime));
	Tables.Add(tprogettoasset);
	tprogettoasset.defineKey("idasset", "idpiece", "idprogetto");

	#endregion


	#region DataRelation creation
	var cPar = new []{assetsegview.Columns["idasset"], assetsegview.Columns["idpiece"]};
	var cChild = new []{progettoasset.Columns["idasset"], progettoasset.Columns["idpiece"]};
	Relations.Add(new DataRelation("FK_progettoasset_assetsegview_idasset-idpiece",cPar,cChild,false));

	#endregion

}
}
}
