
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
[System.Xml.Serialization.XmlRoot("dsmeta_progettotipocosto_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_progettotipocosto_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tax 		=> (MetaTable)Tables["tax"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettotipocostotax 		=> (MetaTable)Tables["progettotipocostotax"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accmotive_alias2 		=> (MetaTable)Tables["accmotive_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable inventorytree 		=> (MetaTable)Tables["inventorytree"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettotipocostoinventorytree 		=> (MetaTable)Tables["progettotipocostoinventorytree"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable position_alias1 		=> (MetaTable)Tables["position_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettotiporicavocontrattokind 		=> (MetaTable)Tables["progettotiporicavocontrattokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable position 		=> (MetaTable)Tables["position"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettotipocostocontrattokind 		=> (MetaTable)Tables["progettotipocostocontrattokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettotipocostokind 		=> (MetaTable)Tables["progettotipocostokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accmotive_alias1 		=> (MetaTable)Tables["accmotive_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettotiporicavoaccmotive 		=> (MetaTable)Tables["progettotiporicavoaccmotive"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accmotive 		=> (MetaTable)Tables["accmotive"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettotipocostoaccmotive 		=> (MetaTable)Tables["progettotipocostoaccmotive"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettotipocosto 		=> (MetaTable)Tables["progettotipocosto"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_progettotipocosto_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_progettotipocosto_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_progettotipocosto_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_progettotipocosto_seg.xsd";

	#region create DataTables
	//////////////////// TAX /////////////////////////////////
	var ttax= new MetaTable("tax");
	ttax.defineColumn("active", typeof(string));
	ttax.defineColumn("appliancebasis", typeof(string));
	ttax.defineColumn("ct", typeof(DateTime),false);
	ttax.defineColumn("cu", typeof(string),false);
	ttax.defineColumn("description", typeof(string),false);
	ttax.defineColumn("fiscaltaxcode", typeof(string));
	ttax.defineColumn("fiscaltaxcodecredit", typeof(string));
	ttax.defineColumn("fiscaltaxcodecreditf24ord", typeof(string));
	ttax.defineColumn("fiscaltaxcodef24ord", typeof(string));
	ttax.defineColumn("flagunabatable", typeof(string));
	ttax.defineColumn("geoappliance", typeof(string));
	ttax.defineColumn("idaccmotive_cost", typeof(string));
	ttax.defineColumn("idaccmotive_debit", typeof(string));
	ttax.defineColumn("idaccmotive_pay", typeof(string));
	ttax.defineColumn("insuranceagencycode", typeof(string));
	ttax.defineColumn("lt", typeof(DateTime),false);
	ttax.defineColumn("lu", typeof(string),false);
	ttax.defineColumn("maintaxcode", typeof(int));
	ttax.defineColumn("taxablecode", typeof(string));
	ttax.defineColumn("taxcode", typeof(int),false);
	ttax.defineColumn("taxkind", typeof(int),false);
	ttax.defineColumn("taxref", typeof(string),false);
	Tables.Add(ttax);
	ttax.defineKey("taxcode");

	//////////////////// PROGETTOTIPOCOSTOTAX /////////////////////////////////
	var tprogettotipocostotax= new MetaTable("progettotipocostotax");
	tprogettotipocostotax.defineColumn("ct", typeof(DateTime));
	tprogettotipocostotax.defineColumn("cu", typeof(string));
	tprogettotipocostotax.defineColumn("idprogetto", typeof(int),false);
	tprogettotipocostotax.defineColumn("idprogettotipocosto", typeof(int),false);
	tprogettotipocostotax.defineColumn("lt", typeof(DateTime));
	tprogettotipocostotax.defineColumn("lu", typeof(string));
	tprogettotipocostotax.defineColumn("taxcode", typeof(int),false);
	tprogettotipocostotax.defineColumn("!taxcode_tax_description", typeof(string));
	tprogettotipocostotax.defineColumn("!taxcode_tax_taxref", typeof(string));
	tprogettotipocostotax.defineColumn("!taxcode_tax_active", typeof(string));
	tprogettotipocostotax.defineColumn("!taxcode_tax_fiscaltaxcodecreditf24ord", typeof(string));
	tprogettotipocostotax.defineColumn("!taxcode_tax_fiscaltaxcodef24ord", typeof(string));
	Tables.Add(tprogettotipocostotax);
	tprogettotipocostotax.defineKey("idprogetto", "idprogettotipocosto", "taxcode");

	//////////////////// ACCMOTIVE_ALIAS2 /////////////////////////////////
	var taccmotive_alias2= new MetaTable("accmotive_alias2");
	taccmotive_alias2.defineColumn("active", typeof(string));
	taccmotive_alias2.defineColumn("codemotive", typeof(string),false);
	taccmotive_alias2.defineColumn("idaccmotive", typeof(string),false);
	taccmotive_alias2.defineColumn("title", typeof(string),false);
	taccmotive_alias2.ExtendedProperties["TableForReading"]="accmotive";
	Tables.Add(taccmotive_alias2);
	taccmotive_alias2.defineKey("idaccmotive");

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

	//////////////////// PROGETTOTIPOCOSTOINVENTORYTREE /////////////////////////////////
	var tprogettotipocostoinventorytree= new MetaTable("progettotipocostoinventorytree");
	tprogettotipocostoinventorytree.defineColumn("ct", typeof(DateTime));
	tprogettotipocostoinventorytree.defineColumn("cu", typeof(string));
	tprogettotipocostoinventorytree.defineColumn("idinv", typeof(int),false);
	tprogettotipocostoinventorytree.defineColumn("idprogetto", typeof(int),false);
	tprogettotipocostoinventorytree.defineColumn("idprogettotipocosto", typeof(int),false);
	tprogettotipocostoinventorytree.defineColumn("lt", typeof(DateTime));
	tprogettotipocostoinventorytree.defineColumn("lu", typeof(string));
	tprogettotipocostoinventorytree.defineColumn("!idinv_inventorytree_codeinv", typeof(string));
	tprogettotipocostoinventorytree.defineColumn("!idinv_inventorytree_description", typeof(string));
	tprogettotipocostoinventorytree.defineColumn("!idinv_accmotive_alias2_codemotive", typeof(string));
	tprogettotipocostoinventorytree.defineColumn("!idinv_accmotive_alias2_title", typeof(string));
	Tables.Add(tprogettotipocostoinventorytree);
	tprogettotipocostoinventorytree.defineKey("idinv", "idprogetto", "idprogettotipocosto");

	//////////////////// POSITION_ALIAS1 /////////////////////////////////
	var tposition_alias1= new MetaTable("position_alias1");
	tposition_alias1.defineColumn("active", typeof(string));
	tposition_alias1.defineColumn("assegnoaggiuntivo", typeof(string));
	tposition_alias1.defineColumn("codeposition", typeof(string),false);
	tposition_alias1.defineColumn("costolordoannuo", typeof(decimal));
	tposition_alias1.defineColumn("costolordoannuooneri", typeof(decimal));
	tposition_alias1.defineColumn("ct", typeof(DateTime),false);
	tposition_alias1.defineColumn("cu", typeof(string),false);
	tposition_alias1.defineColumn("description", typeof(string),false);
	tposition_alias1.defineColumn("elementoperequativo", typeof(string));
	tposition_alias1.defineColumn("foreignclass", typeof(string));
	tposition_alias1.defineColumn("idposition", typeof(int),false);
	tposition_alias1.defineColumn("indennitadiateneo", typeof(string));
	tposition_alias1.defineColumn("indennitadiposizione", typeof(string));
	tposition_alias1.defineColumn("indvacancacontrattuale", typeof(string));
	tposition_alias1.defineColumn("livello", typeof(string));
	tposition_alias1.defineColumn("lt", typeof(DateTime),false);
	tposition_alias1.defineColumn("lu", typeof(string),false);
	tposition_alias1.defineColumn("maxincomeclass", typeof(int));
	tposition_alias1.defineColumn("oremaxcompitididatempoparziale", typeof(int));
	tposition_alias1.defineColumn("oremaxcompitididatempopieno", typeof(int));
	tposition_alias1.defineColumn("oremaxdidatempoparziale", typeof(int));
	tposition_alias1.defineColumn("oremaxdidatempopieno", typeof(int));
	tposition_alias1.defineColumn("oremaxgg", typeof(int));
	tposition_alias1.defineColumn("oremaxtempoparziale", typeof(int));
	tposition_alias1.defineColumn("oremaxtempopieno", typeof(int));
	tposition_alias1.defineColumn("oremincompitididatempoparziale", typeof(int));
	tposition_alias1.defineColumn("oremincompitididatempopieno", typeof(int));
	tposition_alias1.defineColumn("oremindidatempoparziale", typeof(int));
	tposition_alias1.defineColumn("oremindidatempopieno", typeof(int));
	tposition_alias1.defineColumn("oremintempoparziale", typeof(int));
	tposition_alias1.defineColumn("oremintempopieno", typeof(int));
	tposition_alias1.defineColumn("orestraordinariemax", typeof(int));
	tposition_alias1.defineColumn("parttime", typeof(string));
	tposition_alias1.defineColumn("printingorder", typeof(int));
	tposition_alias1.defineColumn("puntiorganico", typeof(decimal));
	tposition_alias1.defineColumn("siglaesportazione", typeof(string));
	tposition_alias1.defineColumn("siglaimportazione", typeof(string));
	tposition_alias1.defineColumn("tempdef", typeof(string));
	tposition_alias1.defineColumn("tipoente", typeof(string));
	tposition_alias1.defineColumn("tipopersonale", typeof(string));
	tposition_alias1.defineColumn("title", typeof(string));
	tposition_alias1.defineColumn("totaletredicesima", typeof(string));
	tposition_alias1.defineColumn("tredicesimaindennitaintegrativaspeciale", typeof(string));
	tposition_alias1.ExtendedProperties["TableForReading"]="position";
	Tables.Add(tposition_alias1);
	tposition_alias1.defineKey("idposition");

	//////////////////// PROGETTOTIPORICAVOCONTRATTOKIND /////////////////////////////////
	var tprogettotiporicavocontrattokind= new MetaTable("progettotiporicavocontrattokind");
	tprogettotiporicavocontrattokind.defineColumn("ct", typeof(DateTime));
	tprogettotiporicavocontrattokind.defineColumn("cu", typeof(string));
	tprogettotiporicavocontrattokind.defineColumn("idposition", typeof(int),false);
	tprogettotiporicavocontrattokind.defineColumn("idprogetto", typeof(int),false);
	tprogettotiporicavocontrattokind.defineColumn("idprogettotipocosto", typeof(int),false);
	tprogettotiporicavocontrattokind.defineColumn("lt", typeof(DateTime));
	tprogettotiporicavocontrattokind.defineColumn("lu", typeof(string));
	Tables.Add(tprogettotiporicavocontrattokind);
	tprogettotiporicavocontrattokind.defineKey("idposition", "idprogetto", "idprogettotipocosto");

	//////////////////// POSITION /////////////////////////////////
	var tposition= new MetaTable("position");
	tposition.defineColumn("active", typeof(string));
	tposition.defineColumn("assegnoaggiuntivo", typeof(string));
	tposition.defineColumn("codeposition", typeof(string),false);
	tposition.defineColumn("costolordoannuo", typeof(decimal));
	tposition.defineColumn("costolordoannuooneri", typeof(decimal));
	tposition.defineColumn("ct", typeof(DateTime),false);
	tposition.defineColumn("cu", typeof(string),false);
	tposition.defineColumn("description", typeof(string),false);
	tposition.defineColumn("elementoperequativo", typeof(string));
	tposition.defineColumn("foreignclass", typeof(string));
	tposition.defineColumn("idposition", typeof(int),false);
	tposition.defineColumn("indennitadiateneo", typeof(string));
	tposition.defineColumn("indennitadiposizione", typeof(string));
	tposition.defineColumn("indvacancacontrattuale", typeof(string));
	tposition.defineColumn("livello", typeof(string));
	tposition.defineColumn("lt", typeof(DateTime),false);
	tposition.defineColumn("lu", typeof(string),false);
	tposition.defineColumn("maxincomeclass", typeof(int));
	tposition.defineColumn("oremaxcompitididatempoparziale", typeof(int));
	tposition.defineColumn("oremaxcompitididatempopieno", typeof(int));
	tposition.defineColumn("oremaxdidatempoparziale", typeof(int));
	tposition.defineColumn("oremaxdidatempopieno", typeof(int));
	tposition.defineColumn("oremaxgg", typeof(int));
	tposition.defineColumn("oremaxtempoparziale", typeof(int));
	tposition.defineColumn("oremaxtempopieno", typeof(int));
	tposition.defineColumn("oremincompitididatempoparziale", typeof(int));
	tposition.defineColumn("oremincompitididatempopieno", typeof(int));
	tposition.defineColumn("oremindidatempoparziale", typeof(int));
	tposition.defineColumn("oremindidatempopieno", typeof(int));
	tposition.defineColumn("oremintempoparziale", typeof(int));
	tposition.defineColumn("oremintempopieno", typeof(int));
	tposition.defineColumn("orestraordinariemax", typeof(int));
	tposition.defineColumn("parttime", typeof(string));
	tposition.defineColumn("printingorder", typeof(int));
	tposition.defineColumn("puntiorganico", typeof(decimal));
	tposition.defineColumn("siglaesportazione", typeof(string));
	tposition.defineColumn("siglaimportazione", typeof(string));
	tposition.defineColumn("tempdef", typeof(string));
	tposition.defineColumn("tipoente", typeof(string));
	tposition.defineColumn("tipopersonale", typeof(string));
	tposition.defineColumn("title", typeof(string));
	tposition.defineColumn("totaletredicesima", typeof(string));
	tposition.defineColumn("tredicesimaindennitaintegrativaspeciale", typeof(string));
	Tables.Add(tposition);
	tposition.defineKey("idposition");

	//////////////////// PROGETTOTIPOCOSTOCONTRATTOKIND /////////////////////////////////
	var tprogettotipocostocontrattokind= new MetaTable("progettotipocostocontrattokind");
	tprogettotipocostocontrattokind.defineColumn("ct", typeof(DateTime));
	tprogettotipocostocontrattokind.defineColumn("cu", typeof(string));
	tprogettotipocostocontrattokind.defineColumn("idposition", typeof(int),false);
	tprogettotipocostocontrattokind.defineColumn("idprogetto", typeof(int),false);
	tprogettotipocostocontrattokind.defineColumn("idprogettotipocosto", typeof(int),false);
	tprogettotipocostocontrattokind.defineColumn("lt", typeof(DateTime));
	tprogettotipocostocontrattokind.defineColumn("lu", typeof(string));
	Tables.Add(tprogettotipocostocontrattokind);
	tprogettotipocostocontrattokind.defineKey("idposition", "idprogetto", "idprogettotipocosto");

	//////////////////// PROGETTOTIPOCOSTOKIND /////////////////////////////////
	var tprogettotipocostokind= new MetaTable("progettotipocostokind");
	tprogettotipocostokind.defineColumn("idprogettokind", typeof(int),false);
	tprogettotipocostokind.defineColumn("idprogettotipocostokind", typeof(int),false);
	tprogettotipocostokind.defineColumn("title", typeof(string));
	Tables.Add(tprogettotipocostokind);
	tprogettotipocostokind.defineKey("idprogettokind", "idprogettotipocostokind");

	//////////////////// ACCMOTIVE_ALIAS1 /////////////////////////////////
	var taccmotive_alias1= new MetaTable("accmotive_alias1");
	taccmotive_alias1.defineColumn("active", typeof(string));
	taccmotive_alias1.defineColumn("codemotive", typeof(string),false);
	taccmotive_alias1.defineColumn("ct", typeof(DateTime),false);
	taccmotive_alias1.defineColumn("cu", typeof(string),false);
	taccmotive_alias1.defineColumn("expensekind", typeof(string));
	taccmotive_alias1.defineColumn("flag", typeof(int));
	taccmotive_alias1.defineColumn("flagamm", typeof(string));
	taccmotive_alias1.defineColumn("flagdep", typeof(string));
	taccmotive_alias1.defineColumn("idaccmotive", typeof(string),false);
	taccmotive_alias1.defineColumn("lt", typeof(DateTime),false);
	taccmotive_alias1.defineColumn("lu", typeof(string),false);
	taccmotive_alias1.defineColumn("paridaccmotive", typeof(string));
	taccmotive_alias1.defineColumn("title", typeof(string),false);
	taccmotive_alias1.ExtendedProperties["TableForReading"]="accmotive";
	Tables.Add(taccmotive_alias1);
	taccmotive_alias1.defineKey("idaccmotive");

	//////////////////// PROGETTOTIPORICAVOACCMOTIVE /////////////////////////////////
	var tprogettotiporicavoaccmotive= new MetaTable("progettotiporicavoaccmotive");
	tprogettotiporicavoaccmotive.defineColumn("ct", typeof(DateTime));
	tprogettotiporicavoaccmotive.defineColumn("cu", typeof(string));
	tprogettotiporicavoaccmotive.defineColumn("idaccmotive", typeof(string),false);
	tprogettotiporicavoaccmotive.defineColumn("idprogetto", typeof(int),false);
	tprogettotiporicavoaccmotive.defineColumn("idprogettotipocosto", typeof(int),false);
	tprogettotiporicavoaccmotive.defineColumn("lt", typeof(DateTime));
	tprogettotiporicavoaccmotive.defineColumn("lu", typeof(string));
	tprogettotiporicavoaccmotive.defineColumn("!idaccmotive_accmotive_alias1_title", typeof(string));
	tprogettotiporicavoaccmotive.defineColumn("!idaccmotive_accmotive_alias1_codemotive", typeof(string));
	Tables.Add(tprogettotiporicavoaccmotive);
	tprogettotiporicavoaccmotive.defineKey("idaccmotive", "idprogetto", "idprogettotipocosto");

	//////////////////// ACCMOTIVE /////////////////////////////////
	var taccmotive= new MetaTable("accmotive");
	taccmotive.defineColumn("active", typeof(string));
	taccmotive.defineColumn("codemotive", typeof(string),false);
	taccmotive.defineColumn("ct", typeof(DateTime),false);
	taccmotive.defineColumn("cu", typeof(string),false);
	taccmotive.defineColumn("expensekind", typeof(string));
	taccmotive.defineColumn("flag", typeof(int));
	taccmotive.defineColumn("flagamm", typeof(string));
	taccmotive.defineColumn("flagdep", typeof(string));
	taccmotive.defineColumn("idaccmotive", typeof(string),false);
	taccmotive.defineColumn("lt", typeof(DateTime),false);
	taccmotive.defineColumn("lu", typeof(string),false);
	taccmotive.defineColumn("paridaccmotive", typeof(string));
	taccmotive.defineColumn("title", typeof(string),false);
	Tables.Add(taccmotive);
	taccmotive.defineKey("idaccmotive");

	//////////////////// PROGETTOTIPOCOSTOACCMOTIVE /////////////////////////////////
	var tprogettotipocostoaccmotive= new MetaTable("progettotipocostoaccmotive");
	tprogettotipocostoaccmotive.defineColumn("ct", typeof(DateTime));
	tprogettotipocostoaccmotive.defineColumn("cu", typeof(string));
	tprogettotipocostoaccmotive.defineColumn("idaccmotive", typeof(string),false);
	tprogettotipocostoaccmotive.defineColumn("idprogetto", typeof(int),false);
	tprogettotipocostoaccmotive.defineColumn("idprogettotipocosto", typeof(int),false);
	tprogettotipocostoaccmotive.defineColumn("lt", typeof(DateTime));
	tprogettotipocostoaccmotive.defineColumn("lu", typeof(string));
	tprogettotipocostoaccmotive.defineColumn("!idaccmotive_accmotive_title", typeof(string));
	tprogettotipocostoaccmotive.defineColumn("!idaccmotive_accmotive_codemotive", typeof(string));
	Tables.Add(tprogettotipocostoaccmotive);
	tprogettotipocostoaccmotive.defineKey("idaccmotive", "idprogetto", "idprogettotipocosto");

	//////////////////// PROGETTOTIPOCOSTO /////////////////////////////////
	var tprogettotipocosto= new MetaTable("progettotipocosto");
	tprogettotipocosto.defineColumn("ammissibilita", typeof(decimal));
	tprogettotipocosto.defineColumn("budgetrichiesto", typeof(decimal));
	tprogettotipocosto.defineColumn("ct", typeof(DateTime));
	tprogettotipocosto.defineColumn("cu", typeof(string));
	tprogettotipocosto.defineColumn("idprogetto", typeof(int),false);
	tprogettotipocosto.defineColumn("idprogettotipocosto", typeof(int),false);
	tprogettotipocosto.defineColumn("idprogettotipocostokind", typeof(int));
	tprogettotipocosto.defineColumn("lt", typeof(DateTime));
	tprogettotipocosto.defineColumn("lu", typeof(string));
	tprogettotipocosto.defineColumn("sortcode", typeof(int));
	tprogettotipocosto.defineColumn("title", typeof(string));
	Tables.Add(tprogettotipocosto);
	tprogettotipocosto.defineKey("idprogetto", "idprogettotipocosto");

	#endregion


	#region DataRelation creation
	var cPar = new []{progettotipocosto.Columns["idprogetto"], progettotipocosto.Columns["idprogettotipocosto"]};
	var cChild = new []{progettotipocostotax.Columns["idprogetto"], progettotipocostotax.Columns["idprogettotipocosto"]};
	Relations.Add(new DataRelation("FK_progettotipocostotax_progettotipocosto_idprogetto-idprogettotipocosto",cPar,cChild,false));

	cPar = new []{tax.Columns["taxcode"]};
	cChild = new []{progettotipocostotax.Columns["taxcode"]};
	Relations.Add(new DataRelation("FK_progettotipocostotax_tax_taxcode",cPar,cChild,false));

	cPar = new []{progettotipocosto.Columns["idprogetto"], progettotipocosto.Columns["idprogettotipocosto"]};
	cChild = new []{progettotipocostoinventorytree.Columns["idprogetto"], progettotipocostoinventorytree.Columns["idprogettotipocosto"]};
	Relations.Add(new DataRelation("FK_progettotipocostoinventorytree_progettotipocosto_idprogetto-idprogettotipocosto",cPar,cChild,false));

	cPar = new []{inventorytree.Columns["idinv"]};
	cChild = new []{progettotipocostoinventorytree.Columns["idinv"]};
	Relations.Add(new DataRelation("FK_progettotipocostoinventorytree_inventorytree_idinv",cPar,cChild,false));

	cPar = new []{accmotive_alias2.Columns["idaccmotive"]};
	cChild = new []{inventorytree.Columns["idaccmotiveload"]};
	Relations.Add(new DataRelation("FK_inventorytree_accmotive_alias2_idaccmotiveload",cPar,cChild,false));

	cPar = new []{progettotipocosto.Columns["idprogetto"], progettotipocosto.Columns["idprogettotipocosto"]};
	cChild = new []{progettotiporicavocontrattokind.Columns["idprogetto"], progettotiporicavocontrattokind.Columns["idprogettotipocosto"]};
	Relations.Add(new DataRelation("FK_progettotiporicavocontrattokind_progettotipocosto_idprogetto-idprogettotipocosto",cPar,cChild,false));

	cPar = new []{position_alias1.Columns["idposition"]};
	cChild = new []{progettotiporicavocontrattokind.Columns["idposition"]};
	Relations.Add(new DataRelation("FK_progettotiporicavocontrattokind_position_alias1_idposition",cPar,cChild,false));

	cPar = new []{progettotipocosto.Columns["idprogetto"], progettotipocosto.Columns["idprogettotipocosto"]};
	cChild = new []{progettotipocostocontrattokind.Columns["idprogetto"], progettotipocostocontrattokind.Columns["idprogettotipocosto"]};
	Relations.Add(new DataRelation("FK_progettotipocostocontrattokind_progettotipocosto_idprogetto-idprogettotipocosto",cPar,cChild,false));

	cPar = new []{position.Columns["idposition"]};
	cChild = new []{progettotipocostocontrattokind.Columns["idposition"]};
	Relations.Add(new DataRelation("FK_progettotipocostocontrattokind_position_idposition",cPar,cChild,false));

	cPar = new []{progettotipocostokind.Columns["idprogettotipocostokind"]};
	cChild = new []{progettotipocosto.Columns["idprogettotipocostokind"]};
	Relations.Add(new DataRelation("FK_progettotipocosto_progettotipocostokind_idprogettotipocostokind",cPar,cChild,false));

	cPar = new []{progettotipocosto.Columns["idprogetto"], progettotipocosto.Columns["idprogettotipocosto"]};
	cChild = new []{progettotiporicavoaccmotive.Columns["idprogetto"], progettotiporicavoaccmotive.Columns["idprogettotipocosto"]};
	Relations.Add(new DataRelation("FK_progettotiporicavoaccmotive_progettotipocosto_idprogetto-idprogettotipocosto",cPar,cChild,false));

	cPar = new []{accmotive_alias1.Columns["idaccmotive"]};
	cChild = new []{progettotiporicavoaccmotive.Columns["idaccmotive"]};
	Relations.Add(new DataRelation("FK_progettotiporicavoaccmotive_accmotive_alias1_idaccmotive",cPar,cChild,false));

	cPar = new []{progettotipocosto.Columns["idprogetto"], progettotipocosto.Columns["idprogettotipocosto"]};
	cChild = new []{progettotipocostoaccmotive.Columns["idprogetto"], progettotipocostoaccmotive.Columns["idprogettotipocosto"]};
	Relations.Add(new DataRelation("FK_progettotipocostoaccmotive_progettotipocosto_idprogetto-idprogettotipocosto",cPar,cChild,false));

	cPar = new []{accmotive.Columns["idaccmotive"]};
	cChild = new []{progettotipocostoaccmotive.Columns["idaccmotive"]};
	Relations.Add(new DataRelation("FK_progettotipocostoaccmotive_accmotive_idaccmotive",cPar,cChild,false));

	#endregion

}
}
}
