
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
[System.Xml.Serialization.XmlRoot("dsmeta_salprogettoassetworkpackage_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_salprogettoassetworkpackage_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable year 		=> (MetaTable)Tables["year"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable mese 		=> (MetaTable)Tables["mese"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable salprogettoassetworkpackagemese 		=> (MetaTable)Tables["salprogettoassetworkpackagemese"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetsegview 		=> (MetaTable)Tables["assetsegview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable workpackagesegview 		=> (MetaTable)Tables["workpackagesegview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable asset 		=> (MetaTable)Tables["asset"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable salprogettoassetworkpackage 		=> (MetaTable)Tables["salprogettoassetworkpackage"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_salprogettoassetworkpackage_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_salprogettoassetworkpackage_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_salprogettoassetworkpackage_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_salprogettoassetworkpackage_default.xsd";

	#region create DataTables
	//////////////////// YEAR /////////////////////////////////
	var tyear= new MetaTable("year");
	tyear.defineColumn("year", typeof(int),false);
	Tables.Add(tyear);
	tyear.defineKey("year");

	//////////////////// MESE /////////////////////////////////
	var tmese= new MetaTable("mese");
	tmese.defineColumn("idmese", typeof(int),false);
	tmese.defineColumn("title", typeof(string));
	Tables.Add(tmese);
	tmese.defineKey("idmese");

	//////////////////// SALPROGETTOASSETWORKPACKAGEMESE /////////////////////////////////
	var tsalprogettoassetworkpackagemese= new MetaTable("salprogettoassetworkpackagemese");
	tsalprogettoassetworkpackagemese.defineColumn("amount", typeof(decimal));
	tsalprogettoassetworkpackagemese.defineColumn("idmese", typeof(int));
	tsalprogettoassetworkpackagemese.defineColumn("idprogetto", typeof(int),false);
	tsalprogettoassetworkpackagemese.defineColumn("idsal", typeof(int),false);
	tsalprogettoassetworkpackagemese.defineColumn("idsalprogettoassetworkpackage", typeof(int),false);
	tsalprogettoassetworkpackagemese.defineColumn("idsalprogettoassetworkpackagemese", typeof(int),false);
	tsalprogettoassetworkpackagemese.defineColumn("year", typeof(int));
	tsalprogettoassetworkpackagemese.defineColumn("!idmese_mese_title", typeof(string));
	tsalprogettoassetworkpackagemese.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tsalprogettoassetworkpackagemese);
	tsalprogettoassetworkpackagemese.defineKey("idprogetto", "idsal", "idsalprogettoassetworkpackage", "idsalprogettoassetworkpackagemese");

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

	//////////////////// WORKPACKAGESEGVIEW /////////////////////////////////
	var tworkpackagesegview= new MetaTable("workpackagesegview");
	tworkpackagesegview.defineColumn("dropdown_title", typeof(string),false);
	tworkpackagesegview.defineColumn("idprogetto", typeof(int),false);
	tworkpackagesegview.defineColumn("idworkpackage", typeof(int),false);
	tworkpackagesegview.defineColumn("raggruppamento", typeof(string));
	tworkpackagesegview.defineColumn("struttura_idstrutturakind", typeof(int));
	tworkpackagesegview.defineColumn("struttura_title", typeof(string));
	tworkpackagesegview.defineColumn("strutturakind_title", typeof(string));
	tworkpackagesegview.defineColumn("workpackage_acronimo", typeof(string));
	tworkpackagesegview.defineColumn("workpackage_ct", typeof(DateTime),false);
	tworkpackagesegview.defineColumn("workpackage_cu", typeof(string),false);
	tworkpackagesegview.defineColumn("workpackage_description", typeof(string));
	tworkpackagesegview.defineColumn("workpackage_idstruttura", typeof(int));
	tworkpackagesegview.defineColumn("workpackage_lt", typeof(DateTime),false);
	tworkpackagesegview.defineColumn("workpackage_lu", typeof(string),false);
	tworkpackagesegview.defineColumn("workpackage_start", typeof(DateTime));
	tworkpackagesegview.defineColumn("workpackage_stop", typeof(DateTime));
	tworkpackagesegview.defineColumn("workpackage_title", typeof(string));
	Tables.Add(tworkpackagesegview);
	tworkpackagesegview.defineKey("idprogetto", "idworkpackage");

	//////////////////// ASSET /////////////////////////////////
	var tasset= new MetaTable("asset");
	tasset.defineColumn("amortizationquota", typeof(decimal));
	tasset.defineColumn("ct", typeof(DateTime),false);
	tasset.defineColumn("cu", typeof(string),false);
	tasset.defineColumn("flag", typeof(int),false);
	tasset.defineColumn("idasset", typeof(int),false);
	tasset.defineColumn("idasset_prev", typeof(int));
	tasset.defineColumn("idassetunload", typeof(int));
	tasset.defineColumn("idcurrlocation", typeof(int));
	tasset.defineColumn("idcurrman", typeof(int));
	tasset.defineColumn("idcurrsubman", typeof(int));
	tasset.defineColumn("idinventory", typeof(int));
	tasset.defineColumn("idinventoryamortization", typeof(int));
	tasset.defineColumn("idpiece", typeof(int),false);
	tasset.defineColumn("idpiece_prev", typeof(int));
	tasset.defineColumn("lifestart", typeof(DateTime));
	tasset.defineColumn("lt", typeof(DateTime),false);
	tasset.defineColumn("lu", typeof(string),false);
	tasset.defineColumn("multifield", typeof(string));
	tasset.defineColumn("nassetacquire", typeof(int));
	tasset.defineColumn("ninventory", typeof(int));
	tasset.defineColumn("rfid", typeof(string));
	tasset.defineColumn("rtf", typeof(Byte[]));
	tasset.defineColumn("transmitted", typeof(string));
	tasset.defineColumn("txt", typeof(string));
	Tables.Add(tasset);
	tasset.defineKey("idasset", "idpiece");

	//////////////////// SALPROGETTOASSETWORKPACKAGE /////////////////////////////////
	var tsalprogettoassetworkpackage= new MetaTable("salprogettoassetworkpackage");
	tsalprogettoassetworkpackage.defineColumn("ct", typeof(DateTime),false);
	tsalprogettoassetworkpackage.defineColumn("cu", typeof(string),false);
	tsalprogettoassetworkpackage.defineColumn("idasset", typeof(int),false);
	tsalprogettoassetworkpackage.defineColumn("idpiece", typeof(int),false);
	tsalprogettoassetworkpackage.defineColumn("idprogetto", typeof(int),false);
	tsalprogettoassetworkpackage.defineColumn("idsal", typeof(int),false);
	tsalprogettoassetworkpackage.defineColumn("idsalprogettoassetworkpackage", typeof(int),false);
	tsalprogettoassetworkpackage.defineColumn("idworkpackage", typeof(int));
	tsalprogettoassetworkpackage.defineColumn("lt", typeof(DateTime),false);
	tsalprogettoassetworkpackage.defineColumn("lu", typeof(string),false);
	tsalprogettoassetworkpackage.defineColumn("percentuale", typeof(decimal));
	tsalprogettoassetworkpackage.defineColumn("useassetdiary", typeof(string),false);
	Tables.Add(tsalprogettoassetworkpackage);
	tsalprogettoassetworkpackage.defineKey("idasset", "idpiece", "idprogetto", "idsal", "idsalprogettoassetworkpackage");

	#endregion


	#region DataRelation creation
	var cPar = new []{salprogettoassetworkpackage.Columns["idprogetto"], salprogettoassetworkpackage.Columns["idsal"], salprogettoassetworkpackage.Columns["idsalprogettoassetworkpackage"]};
	var cChild = new []{salprogettoassetworkpackagemese.Columns["idprogetto"], salprogettoassetworkpackagemese.Columns["idsal"], salprogettoassetworkpackagemese.Columns["idsalprogettoassetworkpackage"]};
	Relations.Add(new DataRelation("FK_salprogettoassetworkpackagemese_salprogettoassetworkpackage_idprogetto-idsal-idsalprogettoassetworkpackage",cPar,cChild,false));

	cPar = new []{year.Columns["year"]};
	cChild = new []{salprogettoassetworkpackagemese.Columns["year"]};
	Relations.Add(new DataRelation("FK_salprogettoassetworkpackagemese_year_year",cPar,cChild,false));

	cPar = new []{mese.Columns["idmese"]};
	cChild = new []{salprogettoassetworkpackagemese.Columns["idmese"]};
	Relations.Add(new DataRelation("FK_salprogettoassetworkpackagemese_mese_idmese",cPar,cChild,false));

	cPar = new []{assetsegview.Columns["idasset"], assetsegview.Columns["idpiece"]};
	cChild = new []{salprogettoassetworkpackage.Columns["idasset"], salprogettoassetworkpackage.Columns["idpiece"]};
	Relations.Add(new DataRelation("FK_salprogettoassetworkpackage_assetsegview_idasset-idpiece",cPar,cChild,false));

	cPar = new []{workpackagesegview.Columns["idworkpackage"]};
	cChild = new []{salprogettoassetworkpackage.Columns["idworkpackage"]};
	Relations.Add(new DataRelation("FK_salprogettoassetworkpackage_workpackagesegview_idworkpackage",cPar,cChild,false));

	cPar = new []{asset.Columns["idpiece"]};
	cChild = new []{salprogettoassetworkpackage.Columns["idpiece"]};
	Relations.Add(new DataRelation("FK_salprogettoassetworkpackage_asset_idpiece",cPar,cChild,false));

	#endregion

}
}
}
