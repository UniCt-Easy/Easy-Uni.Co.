
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
[System.Xml.Serialization.XmlRoot("dsmeta_workpackage_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_workpackage_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontattivitaprogettoitineration 		=> (MetaTable)Tables["rendicontattivitaprogettoitineration"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontattivitaprogettoyear 		=> (MetaTable)Tables["rendicontattivitaprogettoyear"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontattivitaprogettoora 		=> (MetaTable)Tables["rendicontattivitaprogettoora"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_alias1 		=> (MetaTable)Tables["registry_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontattivitaprogetto 		=> (MetaTable)Tables["rendicontattivitaprogetto"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetdiaryora 		=> (MetaTable)Tables["assetdiaryora"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry 		=> (MetaTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetacquire 		=> (MetaTable)Tables["assetacquire"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable inventory 		=> (MetaTable)Tables["inventory"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable asset 		=> (MetaTable)Tables["asset"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetdiary 		=> (MetaTable)Tables["assetdiary"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable upb 		=> (MetaTable)Tables["upb"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable workpackageupb 		=> (MetaTable)Tables["workpackageupb"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturadefaultview 		=> (MetaTable)Tables["strutturadefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable workpackage 		=> (MetaTable)Tables["workpackage"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_workpackage_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_workpackage_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_workpackage_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_workpackage_seg.xsd";

	#region create DataTables
	//////////////////// RENDICONTATTIVITAPROGETTOITINERATION /////////////////////////////////
	var trendicontattivitaprogettoitineration= new MetaTable("rendicontattivitaprogettoitineration");
	trendicontattivitaprogettoitineration.defineColumn("iditineration", typeof(int),false);
	trendicontattivitaprogettoitineration.defineColumn("idprogetto", typeof(int),false);
	trendicontattivitaprogettoitineration.defineColumn("idrendicontattivitaprogetto", typeof(int),false);
	trendicontattivitaprogettoitineration.defineColumn("idworkpackage", typeof(int),false);
	Tables.Add(trendicontattivitaprogettoitineration);
	trendicontattivitaprogettoitineration.defineKey("iditineration", "idprogetto", "idrendicontattivitaprogetto", "idworkpackage");

	//////////////////// RENDICONTATTIVITAPROGETTOYEAR /////////////////////////////////
	var trendicontattivitaprogettoyear= new MetaTable("rendicontattivitaprogettoyear");
	trendicontattivitaprogettoyear.defineColumn("idprogetto", typeof(int),false);
	trendicontattivitaprogettoyear.defineColumn("idrendicontattivitaprogetto", typeof(int),false);
	trendicontattivitaprogettoyear.defineColumn("idrendicontattivitaprogettoyear", typeof(int),false);
	trendicontattivitaprogettoyear.defineColumn("idworkpackage", typeof(int),false);
	trendicontattivitaprogettoyear.defineColumn("ore", typeof(int));
	trendicontattivitaprogettoyear.defineColumn("year", typeof(int));
	Tables.Add(trendicontattivitaprogettoyear);
	trendicontattivitaprogettoyear.defineKey("idprogetto", "idrendicontattivitaprogetto", "idrendicontattivitaprogettoyear", "idworkpackage");

	//////////////////// RENDICONTATTIVITAPROGETTOORA /////////////////////////////////
	var trendicontattivitaprogettoora= new MetaTable("rendicontattivitaprogettoora");
	trendicontattivitaprogettoora.defineColumn("!titleancestor", typeof(string));
	trendicontattivitaprogettoora.defineColumn("ct", typeof(DateTime),false);
	trendicontattivitaprogettoora.defineColumn("cu", typeof(string),false);
	trendicontattivitaprogettoora.defineColumn("data", typeof(DateTime));
	trendicontattivitaprogettoora.defineColumn("idrendicontattivitaprogetto", typeof(int),false);
	trendicontattivitaprogettoora.defineColumn("idrendicontattivitaprogettoora", typeof(int),false);
	trendicontattivitaprogettoora.defineColumn("idsal", typeof(int));
	trendicontattivitaprogettoora.defineColumn("idworkpackage", typeof(int),false);
	trendicontattivitaprogettoora.defineColumn("lt", typeof(DateTime),false);
	trendicontattivitaprogettoora.defineColumn("lu", typeof(string),false);
	trendicontattivitaprogettoora.defineColumn("ore", typeof(int));
	trendicontattivitaprogettoora.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(trendicontattivitaprogettoora);
	trendicontattivitaprogettoora.defineKey("idrendicontattivitaprogetto", "idrendicontattivitaprogettoora", "idworkpackage");

	//////////////////// REGISTRY_ALIAS1 /////////////////////////////////
	var tregistry_alias1= new MetaTable("registry_alias1");
	tregistry_alias1.defineColumn("active", typeof(string),false);
	tregistry_alias1.defineColumn("idreg", typeof(int),false);
	tregistry_alias1.defineColumn("title", typeof(string),false);
	tregistry_alias1.ExtendedProperties["TableForReading"]="registry";
	Tables.Add(tregistry_alias1);
	tregistry_alias1.defineKey("idreg");

	//////////////////// RENDICONTATTIVITAPROGETTO /////////////////////////////////
	var trendicontattivitaprogetto= new MetaTable("rendicontattivitaprogetto");
	trendicontattivitaprogetto.defineColumn("!orerendicont", typeof(string));
	trendicontattivitaprogetto.defineColumn("ct", typeof(DateTime),false);
	trendicontattivitaprogetto.defineColumn("cu", typeof(string),false);
	trendicontattivitaprogetto.defineColumn("datainizioprevista", typeof(DateTime),false);
	trendicontattivitaprogetto.defineColumn("description", typeof(string));
	trendicontattivitaprogetto.defineColumn("iditineration", typeof(int));
	trendicontattivitaprogetto.defineColumn("idprogetto", typeof(int),false);
	trendicontattivitaprogetto.defineColumn("idreg", typeof(int),false);
	trendicontattivitaprogetto.defineColumn("idrendicontattivitaprogetto", typeof(int),false);
	trendicontattivitaprogetto.defineColumn("idworkpackage", typeof(int),false);
	trendicontattivitaprogetto.defineColumn("lt", typeof(DateTime),false);
	trendicontattivitaprogetto.defineColumn("lu", typeof(string),false);
	trendicontattivitaprogetto.defineColumn("orepreventivate", typeof(int),false);
	trendicontattivitaprogetto.defineColumn("stop", typeof(DateTime));
	trendicontattivitaprogetto.defineColumn("!idreg_registry_title", typeof(string));
	Tables.Add(trendicontattivitaprogetto);
	trendicontattivitaprogetto.defineKey("idprogetto", "idrendicontattivitaprogetto", "idworkpackage");

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
	Tables.Add(tassetdiaryora);
	tassetdiaryora.defineKey("idassetdiary", "idassetdiaryora", "idworkpackage");

	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new MetaTable("registry");
	tregistry.defineColumn("active", typeof(string),false);
	tregistry.defineColumn("idreg", typeof(int),false);
	tregistry.defineColumn("title", typeof(string),false);
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// ASSETACQUIRE /////////////////////////////////
	var tassetacquire= new MetaTable("assetacquire");
	tassetacquire.defineColumn("description", typeof(string),false);
	tassetacquire.defineColumn("idinv", typeof(int),false);
	tassetacquire.defineColumn("idupb", typeof(string));
	tassetacquire.defineColumn("nassetacquire", typeof(int),false);
	Tables.Add(tassetacquire);
	tassetacquire.defineKey("nassetacquire");

	//////////////////// INVENTORY /////////////////////////////////
	var tinventory= new MetaTable("inventory");
	tinventory.defineColumn("active", typeof(string));
	tinventory.defineColumn("description", typeof(string),false);
	tinventory.defineColumn("idinventory", typeof(int),false);
	Tables.Add(tinventory);
	tinventory.defineKey("idinventory");

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
	tassetdiary.defineColumn("!idasset-idpiece_asset_ninventory", typeof(int));
	tassetdiary.defineColumn("!idasset-idpiece_asset_idasset", typeof(int));
	tassetdiary.defineColumn("!idasset-idpiece_asset_idpiece", typeof(int));
	tassetdiary.defineColumn("!idasset-idpiece_asset_rfid", typeof(string));
	tassetdiary.defineColumn("!idasset-idpiece_asset_idinventory_description", typeof(string));
	tassetdiary.defineColumn("!idasset-idpiece_asset_nassetacquire_description", typeof(string));
	tassetdiary.defineColumn("!idasset-idpiece_asset_nassetacquire_idinv", typeof(int));
	tassetdiary.defineColumn("!idasset-idpiece_asset_nassetacquire_idupb", typeof(string));
	tassetdiary.defineColumn("!idreg_registry_title", typeof(string));
	tassetdiary.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tassetdiary);
	tassetdiary.defineKey("idassetdiary", "idworkpackage");

	//////////////////// UPB /////////////////////////////////
	var tupb= new MetaTable("upb");
	tupb.defineColumn("active", typeof(string));
	tupb.defineColumn("assured", typeof(string));
	tupb.defineColumn("cigcode", typeof(string));
	tupb.defineColumn("codeupb", typeof(string),false);
	tupb.defineColumn("cofogmpcode", typeof(string));
	tupb.defineColumn("ct", typeof(DateTime),false);
	tupb.defineColumn("cu", typeof(string),false);
	tupb.defineColumn("cupcode", typeof(string));
	tupb.defineColumn("expiration", typeof(DateTime));
	tupb.defineColumn("flag", typeof(int));
	tupb.defineColumn("flagactivity", typeof(int));
	tupb.defineColumn("flagkind", typeof(int));
	tupb.defineColumn("granted", typeof(decimal));
	tupb.defineColumn("idepupbkind", typeof(int));
	tupb.defineColumn("idtreasurer", typeof(int));
	tupb.defineColumn("idunderwriter", typeof(int));
	tupb.defineColumn("idupb", typeof(string),false);
	tupb.defineColumn("idupb_capofila", typeof(string));
	tupb.defineColumn("lt", typeof(DateTime),false);
	tupb.defineColumn("lu", typeof(string),false);
	tupb.defineColumn("newcodeupb", typeof(string));
	tupb.defineColumn("paridupb", typeof(string));
	tupb.defineColumn("previousappropriation", typeof(decimal));
	tupb.defineColumn("previousassessment", typeof(decimal));
	tupb.defineColumn("printingorder", typeof(string),false);
	tupb.defineColumn("requested", typeof(decimal));
	tupb.defineColumn("ri_ra_quota", typeof(decimal));
	tupb.defineColumn("ri_rb_quota", typeof(decimal));
	tupb.defineColumn("ri_sa_quota", typeof(decimal));
	tupb.defineColumn("rtf", typeof(Byte[]));
	tupb.defineColumn("start", typeof(DateTime));
	tupb.defineColumn("stop", typeof(DateTime));
	tupb.defineColumn("title", typeof(string),false);
	tupb.defineColumn("txt", typeof(string));
	tupb.defineColumn("uesiopecode", typeof(string));
	Tables.Add(tupb);
	tupb.defineKey("idupb");

	//////////////////// WORKPACKAGEUPB /////////////////////////////////
	var tworkpackageupb= new MetaTable("workpackageupb");
	tworkpackageupb.defineColumn("ct", typeof(DateTime),false);
	tworkpackageupb.defineColumn("cu", typeof(string),false);
	tworkpackageupb.defineColumn("idprogetto", typeof(int),false);
	tworkpackageupb.defineColumn("idupb", typeof(string),false);
	tworkpackageupb.defineColumn("idworkpackage", typeof(int),false);
	tworkpackageupb.defineColumn("lt", typeof(DateTime),false);
	tworkpackageupb.defineColumn("lu", typeof(string),false);
	tworkpackageupb.defineColumn("!idupb_upb_codeupb", typeof(string));
	tworkpackageupb.defineColumn("!idupb_upb_title", typeof(string));
	tworkpackageupb.defineColumn("!idupb_upb_active", typeof(string));
	Tables.Add(tworkpackageupb);
	tworkpackageupb.defineKey("idprogetto", "idupb", "idworkpackage");

	//////////////////// STRUTTURADEFAULTVIEW /////////////////////////////////
	var tstrutturadefaultview= new MetaTable("strutturadefaultview");
	tstrutturadefaultview.defineColumn("dropdown_title", typeof(string),false);
	tstrutturadefaultview.defineColumn("idstruttura", typeof(int),false);
	tstrutturadefaultview.defineColumn("idupb", typeof(string));
	tstrutturadefaultview.defineColumn("paridstruttura", typeof(int));
	Tables.Add(tstrutturadefaultview);
	tstrutturadefaultview.defineKey("idstruttura");

	//////////////////// WORKPACKAGE /////////////////////////////////
	var tworkpackage= new MetaTable("workpackage");
	tworkpackage.defineColumn("acronimo", typeof(string));
	tworkpackage.defineColumn("ct", typeof(DateTime),false);
	tworkpackage.defineColumn("cu", typeof(string),false);
	tworkpackage.defineColumn("description", typeof(string));
	tworkpackage.defineColumn("idprogetto", typeof(int),false);
	tworkpackage.defineColumn("idstruttura", typeof(int));
	tworkpackage.defineColumn("idworkpackage", typeof(int),false);
	tworkpackage.defineColumn("lt", typeof(DateTime),false);
	tworkpackage.defineColumn("lu", typeof(string),false);
	tworkpackage.defineColumn("raggruppamento", typeof(string));
	tworkpackage.defineColumn("start", typeof(DateTime));
	tworkpackage.defineColumn("stop", typeof(DateTime));
	tworkpackage.defineColumn("title", typeof(string));
	Tables.Add(tworkpackage);
	tworkpackage.defineKey("idprogetto", "idworkpackage");

	#endregion


	#region DataRelation creation
	var cPar = new []{workpackage.Columns["idprogetto"], workpackage.Columns["idworkpackage"]};
	var cChild = new []{rendicontattivitaprogetto.Columns["idprogetto"], rendicontattivitaprogetto.Columns["idworkpackage"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogetto_workpackage_idprogetto-idworkpackage",cPar,cChild,false));

	cPar = new []{rendicontattivitaprogetto.Columns["idprogetto"], rendicontattivitaprogetto.Columns["idrendicontattivitaprogetto"], rendicontattivitaprogetto.Columns["idworkpackage"]};
	cChild = new []{rendicontattivitaprogettoitineration.Columns["idprogetto"], rendicontattivitaprogettoitineration.Columns["idrendicontattivitaprogetto"], rendicontattivitaprogettoitineration.Columns["idworkpackage"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogettoitineration_rendicontattivitaprogetto_idprogetto-idrendicontattivitaprogetto-idworkpackage",cPar,cChild,false));

	cPar = new []{rendicontattivitaprogetto.Columns["idprogetto"], rendicontattivitaprogetto.Columns["idrendicontattivitaprogetto"], rendicontattivitaprogetto.Columns["idworkpackage"]};
	cChild = new []{rendicontattivitaprogettoyear.Columns["idprogetto"], rendicontattivitaprogettoyear.Columns["idrendicontattivitaprogetto"], rendicontattivitaprogettoyear.Columns["idworkpackage"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogettoyear_rendicontattivitaprogetto_idprogetto-idrendicontattivitaprogetto-idworkpackage",cPar,cChild,false));

	cPar = new []{rendicontattivitaprogetto.Columns["idrendicontattivitaprogetto"], rendicontattivitaprogetto.Columns["idworkpackage"]};
	cChild = new []{rendicontattivitaprogettoora.Columns["idrendicontattivitaprogetto"], rendicontattivitaprogettoora.Columns["idworkpackage"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogettoora_rendicontattivitaprogetto_idrendicontattivitaprogetto-idworkpackage",cPar,cChild,false));

	cPar = new []{registry_alias1.Columns["idreg"]};
	cChild = new []{rendicontattivitaprogetto.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogetto_registry_alias1_idreg",cPar,cChild,false));

	cPar = new []{workpackage.Columns["idprogetto"], workpackage.Columns["idworkpackage"]};
	cChild = new []{assetdiary.Columns["idprogetto"], assetdiary.Columns["idworkpackage"]};
	Relations.Add(new DataRelation("FK_assetdiary_workpackage_idprogetto-idworkpackage",cPar,cChild,false));

	cPar = new []{assetdiary.Columns["idassetdiary"], assetdiary.Columns["idworkpackage"]};
	cChild = new []{assetdiaryora.Columns["idassetdiary"], assetdiaryora.Columns["idworkpackage"]};
	Relations.Add(new DataRelation("FK_assetdiaryora_assetdiary_idassetdiary-idworkpackage",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{assetdiary.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_assetdiary_registry_idreg",cPar,cChild,false));

	cPar = new []{asset.Columns["idasset"], asset.Columns["idpiece"]};
	cChild = new []{assetdiary.Columns["idasset"], assetdiary.Columns["idpiece"]};
	Relations.Add(new DataRelation("FK_assetdiary_asset_idasset-idpiece",cPar,cChild,false));

	cPar = new []{assetacquire.Columns["nassetacquire"]};
	cChild = new []{asset.Columns["nassetacquire"]};
	Relations.Add(new DataRelation("FK_asset_assetacquire_nassetacquire",cPar,cChild,false));

	cPar = new []{inventory.Columns["idinventory"]};
	cChild = new []{asset.Columns["idinventory"]};
	Relations.Add(new DataRelation("FK_asset_inventory_idinventory",cPar,cChild,false));

	cPar = new []{workpackage.Columns["idprogetto"], workpackage.Columns["idworkpackage"]};
	cChild = new []{workpackageupb.Columns["idprogetto"], workpackageupb.Columns["idworkpackage"]};
	Relations.Add(new DataRelation("FK_workpackageupb_workpackage_idprogetto-idworkpackage",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{workpackageupb.Columns["idupb"]};
	Relations.Add(new DataRelation("FK_workpackageupb_upb_idupb",cPar,cChild,false));

	cPar = new []{strutturadefaultview.Columns["idstruttura"]};
	cChild = new []{workpackage.Columns["idstruttura"]};
	Relations.Add(new DataRelation("FK_workpackage_strutturadefaultview_idstruttura",cPar,cChild,false));

	#endregion

}
}
}
