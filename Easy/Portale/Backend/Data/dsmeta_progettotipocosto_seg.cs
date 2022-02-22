
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
[System.Xml.Serialization.XmlRoot("dsmeta_progettotipocosto_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_progettotipocosto_seg: DataSet {

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
	public MetaTable contrattokind_alias1 		=> (MetaTable)Tables["contrattokind_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettotiporicavocontrattokind 		=> (MetaTable)Tables["progettotiporicavocontrattokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable contrattokind 		=> (MetaTable)Tables["contrattokind"];

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

	//////////////////// CONTRATTOKIND_ALIAS1 /////////////////////////////////
	var tcontrattokind_alias1= new MetaTable("contrattokind_alias1");
	tcontrattokind_alias1.defineColumn("active", typeof(string),false);
	tcontrattokind_alias1.defineColumn("assegnoaggiuntivo", typeof(string));
	tcontrattokind_alias1.defineColumn("costolordoannuo", typeof(decimal));
	tcontrattokind_alias1.defineColumn("costolordoannuooneri", typeof(decimal));
	tcontrattokind_alias1.defineColumn("ct", typeof(DateTime),false);
	tcontrattokind_alias1.defineColumn("cu", typeof(string),false);
	tcontrattokind_alias1.defineColumn("description", typeof(string));
	tcontrattokind_alias1.defineColumn("elementoperequativo", typeof(string));
	tcontrattokind_alias1.defineColumn("idcontrattokind", typeof(int),false);
	tcontrattokind_alias1.defineColumn("indennitadiateneo", typeof(string));
	tcontrattokind_alias1.defineColumn("indennitadiposizione", typeof(string));
	tcontrattokind_alias1.defineColumn("indvacancacontrattuale", typeof(string));
	tcontrattokind_alias1.defineColumn("lt", typeof(DateTime),false);
	tcontrattokind_alias1.defineColumn("lu", typeof(string),false);
	tcontrattokind_alias1.defineColumn("oremaxcompitididatempoparziale", typeof(int));
	tcontrattokind_alias1.defineColumn("oremaxcompitididatempopieno", typeof(int));
	tcontrattokind_alias1.defineColumn("oremaxdidatempoparziale", typeof(int));
	tcontrattokind_alias1.defineColumn("oremaxdidatempopieno", typeof(int));
	tcontrattokind_alias1.defineColumn("oremaxgg", typeof(int));
	tcontrattokind_alias1.defineColumn("oremaxtempoparziale", typeof(int));
	tcontrattokind_alias1.defineColumn("oremaxtempopieno", typeof(int));
	tcontrattokind_alias1.defineColumn("oremincompitididatempoparziale", typeof(int));
	tcontrattokind_alias1.defineColumn("oremincompitididatempopieno", typeof(int));
	tcontrattokind_alias1.defineColumn("oremindidatempoparziale", typeof(int));
	tcontrattokind_alias1.defineColumn("oremindidatempopieno", typeof(int));
	tcontrattokind_alias1.defineColumn("oremintempoparziale", typeof(int));
	tcontrattokind_alias1.defineColumn("oremintempopieno", typeof(int));
	tcontrattokind_alias1.defineColumn("orestraordinariemax", typeof(int));
	tcontrattokind_alias1.defineColumn("parttime", typeof(string));
	tcontrattokind_alias1.defineColumn("puntiorganico", typeof(decimal));
	tcontrattokind_alias1.defineColumn("scatto", typeof(string));
	tcontrattokind_alias1.defineColumn("siglaesportazione", typeof(string));
	tcontrattokind_alias1.defineColumn("siglaimportazione", typeof(string));
	tcontrattokind_alias1.defineColumn("sortcode", typeof(int),false);
	tcontrattokind_alias1.defineColumn("tempdef", typeof(string));
	tcontrattokind_alias1.defineColumn("title", typeof(string),false);
	tcontrattokind_alias1.defineColumn("totaletredicesima", typeof(string));
	tcontrattokind_alias1.defineColumn("tredicesimaindennitaintegrativaspeciale", typeof(string));
	tcontrattokind_alias1.ExtendedProperties["TableForReading"]="contrattokind";
	Tables.Add(tcontrattokind_alias1);
	tcontrattokind_alias1.defineKey("idcontrattokind");

	//////////////////// PROGETTOTIPORICAVOCONTRATTOKIND /////////////////////////////////
	var tprogettotiporicavocontrattokind= new MetaTable("progettotiporicavocontrattokind");
	tprogettotiporicavocontrattokind.defineColumn("ct", typeof(DateTime));
	tprogettotiporicavocontrattokind.defineColumn("cu", typeof(string));
	tprogettotiporicavocontrattokind.defineColumn("idcontrattokind", typeof(int),false);
	tprogettotiporicavocontrattokind.defineColumn("idprogetto", typeof(int),false);
	tprogettotiporicavocontrattokind.defineColumn("idprogettotipocosto", typeof(int),false);
	tprogettotiporicavocontrattokind.defineColumn("lt", typeof(DateTime));
	tprogettotiporicavocontrattokind.defineColumn("lu", typeof(string));
	Tables.Add(tprogettotiporicavocontrattokind);
	tprogettotiporicavocontrattokind.defineKey("idcontrattokind", "idprogetto", "idprogettotipocosto");

	//////////////////// CONTRATTOKIND /////////////////////////////////
	var tcontrattokind= new MetaTable("contrattokind");
	tcontrattokind.defineColumn("active", typeof(string),false);
	tcontrattokind.defineColumn("assegnoaggiuntivo", typeof(string));
	tcontrattokind.defineColumn("costolordoannuo", typeof(decimal));
	tcontrattokind.defineColumn("costolordoannuooneri", typeof(decimal));
	tcontrattokind.defineColumn("ct", typeof(DateTime),false);
	tcontrattokind.defineColumn("cu", typeof(string),false);
	tcontrattokind.defineColumn("description", typeof(string));
	tcontrattokind.defineColumn("elementoperequativo", typeof(string));
	tcontrattokind.defineColumn("idcontrattokind", typeof(int),false);
	tcontrattokind.defineColumn("indennitadiateneo", typeof(string));
	tcontrattokind.defineColumn("indennitadiposizione", typeof(string));
	tcontrattokind.defineColumn("indvacancacontrattuale", typeof(string));
	tcontrattokind.defineColumn("lt", typeof(DateTime),false);
	tcontrattokind.defineColumn("lu", typeof(string),false);
	tcontrattokind.defineColumn("oremaxcompitididatempoparziale", typeof(int));
	tcontrattokind.defineColumn("oremaxcompitididatempopieno", typeof(int));
	tcontrattokind.defineColumn("oremaxdidatempoparziale", typeof(int));
	tcontrattokind.defineColumn("oremaxdidatempopieno", typeof(int));
	tcontrattokind.defineColumn("oremaxgg", typeof(int));
	tcontrattokind.defineColumn("oremaxtempoparziale", typeof(int));
	tcontrattokind.defineColumn("oremaxtempopieno", typeof(int));
	tcontrattokind.defineColumn("oremincompitididatempoparziale", typeof(int));
	tcontrattokind.defineColumn("oremincompitididatempopieno", typeof(int));
	tcontrattokind.defineColumn("oremindidatempoparziale", typeof(int));
	tcontrattokind.defineColumn("oremindidatempopieno", typeof(int));
	tcontrattokind.defineColumn("oremintempoparziale", typeof(int));
	tcontrattokind.defineColumn("oremintempopieno", typeof(int));
	tcontrattokind.defineColumn("orestraordinariemax", typeof(int));
	tcontrattokind.defineColumn("parttime", typeof(string));
	tcontrattokind.defineColumn("puntiorganico", typeof(decimal));
	tcontrattokind.defineColumn("scatto", typeof(string));
	tcontrattokind.defineColumn("siglaesportazione", typeof(string));
	tcontrattokind.defineColumn("siglaimportazione", typeof(string));
	tcontrattokind.defineColumn("sortcode", typeof(int),false);
	tcontrattokind.defineColumn("tempdef", typeof(string));
	tcontrattokind.defineColumn("title", typeof(string),false);
	tcontrattokind.defineColumn("totaletredicesima", typeof(string));
	tcontrattokind.defineColumn("tredicesimaindennitaintegrativaspeciale", typeof(string));
	Tables.Add(tcontrattokind);
	tcontrattokind.defineKey("idcontrattokind");

	//////////////////// PROGETTOTIPOCOSTOCONTRATTOKIND /////////////////////////////////
	var tprogettotipocostocontrattokind= new MetaTable("progettotipocostocontrattokind");
	tprogettotipocostocontrattokind.defineColumn("ct", typeof(DateTime));
	tprogettotipocostocontrattokind.defineColumn("cu", typeof(string));
	tprogettotipocostocontrattokind.defineColumn("idcontrattokind", typeof(int),false);
	tprogettotipocostocontrattokind.defineColumn("idprogetto", typeof(int),false);
	tprogettotipocostocontrattokind.defineColumn("idprogettotipocosto", typeof(int),false);
	tprogettotipocostocontrattokind.defineColumn("lt", typeof(DateTime));
	tprogettotipocostocontrattokind.defineColumn("lu", typeof(string));
	Tables.Add(tprogettotipocostocontrattokind);
	tprogettotipocostocontrattokind.defineKey("idcontrattokind", "idprogetto", "idprogettotipocosto");

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

	cPar = new []{contrattokind_alias1.Columns["idcontrattokind"]};
	cChild = new []{progettotiporicavocontrattokind.Columns["idcontrattokind"]};
	Relations.Add(new DataRelation("FK_progettotiporicavocontrattokind_contrattokind_alias1_idcontrattokind",cPar,cChild,false));

	cPar = new []{progettotipocosto.Columns["idprogetto"], progettotipocosto.Columns["idprogettotipocosto"]};
	cChild = new []{progettotipocostocontrattokind.Columns["idprogetto"], progettotipocostocontrattokind.Columns["idprogettotipocosto"]};
	Relations.Add(new DataRelation("FK_progettotipocostocontrattokind_progettotipocosto_idprogetto-idprogettotipocosto",cPar,cChild,false));

	cPar = new []{contrattokind.Columns["idcontrattokind"]};
	cChild = new []{progettotipocostocontrattokind.Columns["idcontrattokind"]};
	Relations.Add(new DataRelation("FK_progettotipocostocontrattokind_contrattokind_idcontrattokind",cPar,cChild,false));

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
