
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
[System.Xml.Serialization.XmlRoot("dsmeta_progettotipocostokind_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_progettotipocostokind_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tax 		=> (MetaTable)Tables["tax"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettotipocostokindtax 		=> (MetaTable)Tables["progettotipocostokindtax"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accmotive_alias2 		=> (MetaTable)Tables["accmotive_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable inventorytree 		=> (MetaTable)Tables["inventorytree"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettotipocostokindinventorytree 		=> (MetaTable)Tables["progettotipocostokindinventorytree"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable contrattokind_alias1 		=> (MetaTable)Tables["contrattokind_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettotiporicavokindcontrattokind 		=> (MetaTable)Tables["progettotiporicavokindcontrattokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable contrattokind 		=> (MetaTable)Tables["contrattokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettotipocostokindcontrattokind 		=> (MetaTable)Tables["progettotipocostokindcontrattokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accmotive_alias1 		=> (MetaTable)Tables["accmotive_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettotiporicavokindaccmotive 		=> (MetaTable)Tables["progettotiporicavokindaccmotive"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accmotive 		=> (MetaTable)Tables["accmotive"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettotipocostokindaccmotive 		=> (MetaTable)Tables["progettotipocostokindaccmotive"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettotipocostokind 		=> (MetaTable)Tables["progettotipocostokind"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_progettotipocostokind_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_progettotipocostokind_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_progettotipocostokind_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_progettotipocostokind_seg.xsd";

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

	//////////////////// PROGETTOTIPOCOSTOKINDTAX /////////////////////////////////
	var tprogettotipocostokindtax= new MetaTable("progettotipocostokindtax");
	tprogettotipocostokindtax.defineColumn("ct", typeof(DateTime));
	tprogettotipocostokindtax.defineColumn("cu", typeof(string));
	tprogettotipocostokindtax.defineColumn("idprogettokind", typeof(int),false);
	tprogettotipocostokindtax.defineColumn("idprogettotipocostokind", typeof(int),false);
	tprogettotipocostokindtax.defineColumn("lt", typeof(DateTime));
	tprogettotipocostokindtax.defineColumn("lu", typeof(string));
	tprogettotipocostokindtax.defineColumn("taxcode", typeof(int),false);
	tprogettotipocostokindtax.defineColumn("!taxcode_tax_description", typeof(string));
	tprogettotipocostokindtax.defineColumn("!taxcode_tax_taxref", typeof(string));
	tprogettotipocostokindtax.defineColumn("!taxcode_tax_active", typeof(string));
	Tables.Add(tprogettotipocostokindtax);
	tprogettotipocostokindtax.defineKey("idprogettokind", "idprogettotipocostokind", "taxcode");

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

	//////////////////// PROGETTOTIPOCOSTOKINDINVENTORYTREE /////////////////////////////////
	var tprogettotipocostokindinventorytree= new MetaTable("progettotipocostokindinventorytree");
	tprogettotipocostokindinventorytree.defineColumn("ct", typeof(DateTime),false);
	tprogettotipocostokindinventorytree.defineColumn("cu", typeof(string),false);
	tprogettotipocostokindinventorytree.defineColumn("idinv", typeof(int),false);
	tprogettotipocostokindinventorytree.defineColumn("idprogettokind", typeof(int),false);
	tprogettotipocostokindinventorytree.defineColumn("idprogettotipocostokind", typeof(int),false);
	tprogettotipocostokindinventorytree.defineColumn("lt", typeof(DateTime),false);
	tprogettotipocostokindinventorytree.defineColumn("lu", typeof(string),false);
	tprogettotipocostokindinventorytree.defineColumn("!idinv_inventorytree_codeinv", typeof(string));
	tprogettotipocostokindinventorytree.defineColumn("!idinv_inventorytree_description", typeof(string));
	tprogettotipocostokindinventorytree.defineColumn("!idinv_accmotive_alias2_codemotive", typeof(string));
	tprogettotipocostokindinventorytree.defineColumn("!idinv_accmotive_alias2_title", typeof(string));
	Tables.Add(tprogettotipocostokindinventorytree);
	tprogettotipocostokindinventorytree.defineKey("idinv", "idprogettokind", "idprogettotipocostokind");

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

	//////////////////// PROGETTOTIPORICAVOKINDCONTRATTOKIND /////////////////////////////////
	var tprogettotiporicavokindcontrattokind= new MetaTable("progettotiporicavokindcontrattokind");
	tprogettotiporicavokindcontrattokind.defineColumn("ct", typeof(DateTime));
	tprogettotiporicavokindcontrattokind.defineColumn("cu", typeof(string));
	tprogettotiporicavokindcontrattokind.defineColumn("idcontrattokind", typeof(int),false);
	tprogettotiporicavokindcontrattokind.defineColumn("idprogettokind", typeof(int),false);
	tprogettotiporicavokindcontrattokind.defineColumn("idprogettotipocostokind", typeof(int),false);
	tprogettotiporicavokindcontrattokind.defineColumn("lt", typeof(DateTime));
	tprogettotiporicavokindcontrattokind.defineColumn("lu", typeof(string));
	Tables.Add(tprogettotiporicavokindcontrattokind);
	tprogettotiporicavokindcontrattokind.defineKey("idcontrattokind", "idprogettokind", "idprogettotipocostokind");

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

	//////////////////// PROGETTOTIPOCOSTOKINDCONTRATTOKIND /////////////////////////////////
	var tprogettotipocostokindcontrattokind= new MetaTable("progettotipocostokindcontrattokind");
	tprogettotipocostokindcontrattokind.defineColumn("ct", typeof(DateTime));
	tprogettotipocostokindcontrattokind.defineColumn("cu", typeof(string));
	tprogettotipocostokindcontrattokind.defineColumn("idcontrattokind", typeof(int),false);
	tprogettotipocostokindcontrattokind.defineColumn("idprogettokind", typeof(int),false);
	tprogettotipocostokindcontrattokind.defineColumn("idprogettotipocostokind", typeof(int),false);
	tprogettotipocostokindcontrattokind.defineColumn("lt", typeof(DateTime));
	tprogettotipocostokindcontrattokind.defineColumn("lu", typeof(string));
	Tables.Add(tprogettotipocostokindcontrattokind);
	tprogettotipocostokindcontrattokind.defineKey("idcontrattokind", "idprogettokind", "idprogettotipocostokind");

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

	//////////////////// PROGETTOTIPORICAVOKINDACCMOTIVE /////////////////////////////////
	var tprogettotiporicavokindaccmotive= new MetaTable("progettotiporicavokindaccmotive");
	tprogettotiporicavokindaccmotive.defineColumn("ct", typeof(DateTime));
	tprogettotiporicavokindaccmotive.defineColumn("cu", typeof(string));
	tprogettotiporicavokindaccmotive.defineColumn("idaccmotive", typeof(string),false);
	tprogettotiporicavokindaccmotive.defineColumn("idprogettokind", typeof(int),false);
	tprogettotiporicavokindaccmotive.defineColumn("idprogettotipocostokind", typeof(int),false);
	tprogettotiporicavokindaccmotive.defineColumn("lt", typeof(DateTime));
	tprogettotiporicavokindaccmotive.defineColumn("lu", typeof(string));
	tprogettotiporicavokindaccmotive.defineColumn("!idaccmotive_accmotive_alias1_title", typeof(string));
	tprogettotiporicavokindaccmotive.defineColumn("!idaccmotive_accmotive_alias1_codemotive", typeof(string));
	Tables.Add(tprogettotiporicavokindaccmotive);
	tprogettotiporicavokindaccmotive.defineKey("idaccmotive", "idprogettokind", "idprogettotipocostokind");

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

	//////////////////// PROGETTOTIPOCOSTOKINDACCMOTIVE /////////////////////////////////
	var tprogettotipocostokindaccmotive= new MetaTable("progettotipocostokindaccmotive");
	tprogettotipocostokindaccmotive.defineColumn("ct", typeof(DateTime));
	tprogettotipocostokindaccmotive.defineColumn("cu", typeof(string));
	tprogettotipocostokindaccmotive.defineColumn("idaccmotive", typeof(string),false);
	tprogettotipocostokindaccmotive.defineColumn("idprogettokind", typeof(int),false);
	tprogettotipocostokindaccmotive.defineColumn("idprogettotipocostokind", typeof(int),false);
	tprogettotipocostokindaccmotive.defineColumn("lt", typeof(DateTime));
	tprogettotipocostokindaccmotive.defineColumn("lu", typeof(string));
	tprogettotipocostokindaccmotive.defineColumn("!idaccmotive_accmotive_title", typeof(string));
	tprogettotipocostokindaccmotive.defineColumn("!idaccmotive_accmotive_codemotive", typeof(string));
	Tables.Add(tprogettotipocostokindaccmotive);
	tprogettotipocostokindaccmotive.defineKey("idaccmotive", "idprogettokind", "idprogettotipocostokind");

	//////////////////// PROGETTOTIPOCOSTOKIND /////////////////////////////////
	var tprogettotipocostokind= new MetaTable("progettotipocostokind");
	tprogettotipocostokind.defineColumn("ct", typeof(DateTime));
	tprogettotipocostokind.defineColumn("cu", typeof(string));
	tprogettotipocostokind.defineColumn("description", typeof(string));
	tprogettotipocostokind.defineColumn("idprogettokind", typeof(int),false);
	tprogettotipocostokind.defineColumn("idprogettotipocostokind", typeof(int),false);
	tprogettotipocostokind.defineColumn("lt", typeof(DateTime));
	tprogettotipocostokind.defineColumn("lu", typeof(string));
	tprogettotipocostokind.defineColumn("title", typeof(string));
	Tables.Add(tprogettotipocostokind);
	tprogettotipocostokind.defineKey("idprogettokind", "idprogettotipocostokind");

	#endregion


	#region DataRelation creation
	var cPar = new []{progettotipocostokind.Columns["idprogettokind"], progettotipocostokind.Columns["idprogettotipocostokind"]};
	var cChild = new []{progettotipocostokindtax.Columns["idprogettokind"], progettotipocostokindtax.Columns["idprogettotipocostokind"]};
	Relations.Add(new DataRelation("FK_progettotipocostokindtax_progettotipocostokind_idprogettokind-idprogettotipocostokind",cPar,cChild,false));

	cPar = new []{tax.Columns["taxcode"]};
	cChild = new []{progettotipocostokindtax.Columns["taxcode"]};
	Relations.Add(new DataRelation("FK_progettotipocostokindtax_tax_taxcode",cPar,cChild,false));

	cPar = new []{progettotipocostokind.Columns["idprogettokind"], progettotipocostokind.Columns["idprogettotipocostokind"]};
	cChild = new []{progettotipocostokindinventorytree.Columns["idprogettokind"], progettotipocostokindinventorytree.Columns["idprogettotipocostokind"]};
	Relations.Add(new DataRelation("FK_progettotipocostokindinventorytree_progettotipocostokind_idprogettokind-idprogettotipocostokind",cPar,cChild,false));

	cPar = new []{inventorytree.Columns["idinv"]};
	cChild = new []{progettotipocostokindinventorytree.Columns["idinv"]};
	Relations.Add(new DataRelation("FK_progettotipocostokindinventorytree_inventorytree_idinv",cPar,cChild,false));

	cPar = new []{accmotive_alias2.Columns["idaccmotive"]};
	cChild = new []{inventorytree.Columns["idaccmotiveload"]};
	Relations.Add(new DataRelation("FK_inventorytree_accmotive_alias2_idaccmotiveload",cPar,cChild,false));

	cPar = new []{progettotipocostokind.Columns["idprogettokind"], progettotipocostokind.Columns["idprogettotipocostokind"]};
	cChild = new []{progettotiporicavokindcontrattokind.Columns["idprogettokind"], progettotiporicavokindcontrattokind.Columns["idprogettotipocostokind"]};
	Relations.Add(new DataRelation("FK_progettotiporicavokindcontrattokind_progettotipocostokind_idprogettokind-idprogettotipocostokind",cPar,cChild,false));

	cPar = new []{contrattokind_alias1.Columns["idcontrattokind"]};
	cChild = new []{progettotiporicavokindcontrattokind.Columns["idcontrattokind"]};
	Relations.Add(new DataRelation("FK_progettotiporicavokindcontrattokind_contrattokind_alias1_idcontrattokind",cPar,cChild,false));

	cPar = new []{progettotipocostokind.Columns["idprogettokind"], progettotipocostokind.Columns["idprogettotipocostokind"]};
	cChild = new []{progettotipocostokindcontrattokind.Columns["idprogettokind"], progettotipocostokindcontrattokind.Columns["idprogettotipocostokind"]};
	Relations.Add(new DataRelation("FK_progettotipocostokindcontrattokind_progettotipocostokind_idprogettokind-idprogettotipocostokind",cPar,cChild,false));

	cPar = new []{contrattokind.Columns["idcontrattokind"]};
	cChild = new []{progettotipocostokindcontrattokind.Columns["idcontrattokind"]};
	Relations.Add(new DataRelation("FK_progettotipocostokindcontrattokind_contrattokind_idcontrattokind",cPar,cChild,false));

	cPar = new []{progettotipocostokind.Columns["idprogettokind"], progettotipocostokind.Columns["idprogettotipocostokind"]};
	cChild = new []{progettotiporicavokindaccmotive.Columns["idprogettokind"], progettotiporicavokindaccmotive.Columns["idprogettotipocostokind"]};
	Relations.Add(new DataRelation("FK_progettotiporicavokindaccmotive_progettotipocostokind_idprogettokind-idprogettotipocostokind",cPar,cChild,false));

	cPar = new []{accmotive_alias1.Columns["idaccmotive"]};
	cChild = new []{progettotiporicavokindaccmotive.Columns["idaccmotive"]};
	Relations.Add(new DataRelation("FK_progettotiporicavokindaccmotive_accmotive_alias1_idaccmotive",cPar,cChild,false));

	cPar = new []{progettotipocostokind.Columns["idprogettokind"], progettotipocostokind.Columns["idprogettotipocostokind"]};
	cChild = new []{progettotipocostokindaccmotive.Columns["idprogettokind"], progettotipocostokindaccmotive.Columns["idprogettotipocostokind"]};
	Relations.Add(new DataRelation("FK_progettotipocostokindaccmotive_progettotipocostokind_idprogettokind-idprogettotipocostokind",cPar,cChild,false));

	cPar = new []{accmotive.Columns["idaccmotive"]};
	cChild = new []{progettotipocostokindaccmotive.Columns["idaccmotive"]};
	Relations.Add(new DataRelation("FK_progettotipocostokindaccmotive_accmotive_idaccmotive",cPar,cChild,false));

	#endregion

}
}
}
