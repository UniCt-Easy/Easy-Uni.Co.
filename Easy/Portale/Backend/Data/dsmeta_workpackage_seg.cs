
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
[System.Xml.Serialization.XmlRoot("dsmeta_workpackage_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_workpackage_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontattivitaprogettoitineration 		=> (MetaTable)Tables["rendicontattivitaprogettoitineration"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontattivitaprogettoyear 		=> (MetaTable)Tables["rendicontattivitaprogettoyear"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontattivitaprogettoora 		=> (MetaTable)Tables["rendicontattivitaprogettoora"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontattivitaprogettokind 		=> (MetaTable)Tables["rendicontattivitaprogettokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getregistrydocentiamministrativi_alias1 		=> (MetaTable)Tables["getregistrydocentiamministrativi_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontattivitaprogetto_alias1 		=> (MetaTable)Tables["rendicontattivitaprogetto_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetdiaryora 		=> (MetaTable)Tables["assetdiaryora"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getregistrydocentiamministrativi 		=> (MetaTable)Tables["getregistrydocentiamministrativi"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetacquire 		=> (MetaTable)Tables["assetacquire"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable inventory 		=> (MetaTable)Tables["inventory"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable asset 		=> (MetaTable)Tables["asset"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetdiary 		=> (MetaTable)Tables["assetdiary"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable upbelenchiview 		=> (MetaTable)Tables["upbelenchiview"];

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
	trendicontattivitaprogettoitineration.ExtendedProperties["NotEntityChild"]="true";
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
	trendicontattivitaprogettoyear.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(trendicontattivitaprogettoyear);
	trendicontattivitaprogettoyear.defineKey("idprogetto", "idrendicontattivitaprogetto", "idrendicontattivitaprogettoyear", "idworkpackage");

	//////////////////// RENDICONTATTIVITAPROGETTOORA /////////////////////////////////
	var trendicontattivitaprogettoora= new MetaTable("rendicontattivitaprogettoora");
	trendicontattivitaprogettoora.defineColumn("!titleancestor", typeof(string));
	trendicontattivitaprogettoora.defineColumn("ct", typeof(DateTime),false);
	trendicontattivitaprogettoora.defineColumn("cu", typeof(string),false);
	trendicontattivitaprogettoora.defineColumn("data", typeof(DateTime));
	trendicontattivitaprogettoora.defineColumn("idconsolidamento", typeof(int));
	trendicontattivitaprogettoora.defineColumn("idprogetto", typeof(int),false);
	trendicontattivitaprogettoora.defineColumn("idreg", typeof(int),false);
	trendicontattivitaprogettoora.defineColumn("idrendicontattivitaprogetto", typeof(int),false);
	trendicontattivitaprogettoora.defineColumn("idrendicontattivitaprogettoora", typeof(int),false);
	trendicontattivitaprogettoora.defineColumn("idsal", typeof(int));
	trendicontattivitaprogettoora.defineColumn("idworkpackage", typeof(int),false);
	trendicontattivitaprogettoora.defineColumn("lt", typeof(DateTime),false);
	trendicontattivitaprogettoora.defineColumn("lu", typeof(string),false);
	trendicontattivitaprogettoora.defineColumn("ore", typeof(int));
	Tables.Add(trendicontattivitaprogettoora);
	trendicontattivitaprogettoora.defineKey("idprogetto", "idreg", "idrendicontattivitaprogetto", "idrendicontattivitaprogettoora", "idworkpackage");

	//////////////////// RENDICONTATTIVITAPROGETTOKIND /////////////////////////////////
	var trendicontattivitaprogettokind= new MetaTable("rendicontattivitaprogettokind");
	trendicontattivitaprogettokind.defineColumn("active", typeof(string));
	trendicontattivitaprogettokind.defineColumn("idrendicontattivitaprogettokind", typeof(int),false);
	trendicontattivitaprogettokind.defineColumn("title", typeof(string));
	Tables.Add(trendicontattivitaprogettokind);
	trendicontattivitaprogettokind.defineKey("idrendicontattivitaprogettokind");

	//////////////////// GETREGISTRYDOCENTIAMMINISTRATIVI_ALIAS1 /////////////////////////////////
	var tgetregistrydocentiamministrativi_alias1= new MetaTable("getregistrydocentiamministrativi_alias1");
	tgetregistrydocentiamministrativi_alias1.defineColumn("contratto", typeof(string));
	tgetregistrydocentiamministrativi_alias1.defineColumn("extmatricula", typeof(string));
	tgetregistrydocentiamministrativi_alias1.defineColumn("forename", typeof(string));
	tgetregistrydocentiamministrativi_alias1.defineColumn("idreg", typeof(int),false);
	tgetregistrydocentiamministrativi_alias1.defineColumn("surname", typeof(string));
	tgetregistrydocentiamministrativi_alias1.ExtendedProperties["TableForReading"]="getregistrydocentiamministrativi";
	Tables.Add(tgetregistrydocentiamministrativi_alias1);
	tgetregistrydocentiamministrativi_alias1.defineKey("idreg");

	//////////////////// RENDICONTATTIVITAPROGETTO_ALIAS1 /////////////////////////////////
	var trendicontattivitaprogetto_alias1= new MetaTable("rendicontattivitaprogetto_alias1");
	trendicontattivitaprogetto_alias1.defineColumn("!orerendicont", typeof(string));
	trendicontattivitaprogetto_alias1.defineColumn("!raggruppamento", typeof(string));
	trendicontattivitaprogetto_alias1.defineColumn("!titolobreve", typeof(string));
	trendicontattivitaprogetto_alias1.defineColumn("!wp", typeof(string));
	trendicontattivitaprogetto_alias1.defineColumn("ct", typeof(DateTime),false);
	trendicontattivitaprogetto_alias1.defineColumn("cu", typeof(string),false);
	trendicontattivitaprogetto_alias1.defineColumn("datainizioprevista", typeof(DateTime),false);
	trendicontattivitaprogetto_alias1.defineColumn("description", typeof(string));
	trendicontattivitaprogetto_alias1.defineColumn("iditineration", typeof(int));
	trendicontattivitaprogetto_alias1.defineColumn("idprogetto", typeof(int),false);
	trendicontattivitaprogetto_alias1.defineColumn("idreg", typeof(int),false);
	trendicontattivitaprogetto_alias1.defineColumn("idrendicontattivitaprogetto", typeof(int),false);
	trendicontattivitaprogetto_alias1.defineColumn("idrendicontattivitaprogettokind", typeof(int));
	trendicontattivitaprogetto_alias1.defineColumn("idworkpackage", typeof(int),false);
	trendicontattivitaprogetto_alias1.defineColumn("lt", typeof(DateTime),false);
	trendicontattivitaprogetto_alias1.defineColumn("lu", typeof(string),false);
	trendicontattivitaprogetto_alias1.defineColumn("orepreventivate", typeof(int),false);
	trendicontattivitaprogetto_alias1.defineColumn("stop", typeof(DateTime),false);
	trendicontattivitaprogetto_alias1.defineColumn("!idreg_getregistrydocentiamministrativi_surname", typeof(string));
	trendicontattivitaprogetto_alias1.defineColumn("!idreg_getregistrydocentiamministrativi_forename", typeof(string));
	trendicontattivitaprogetto_alias1.defineColumn("!idreg_getregistrydocentiamministrativi_extmatricula", typeof(string));
	trendicontattivitaprogetto_alias1.defineColumn("!idreg_getregistrydocentiamministrativi_contratto", typeof(string));
	trendicontattivitaprogetto_alias1.defineColumn("!idrendicontattivitaprogettokind_rendicontattivitaprogettokind_title", typeof(string));
	trendicontattivitaprogetto_alias1.ExtendedProperties["TableForReading"]="rendicontattivitaprogetto";
	Tables.Add(trendicontattivitaprogetto_alias1);
	trendicontattivitaprogetto_alias1.defineKey("idprogetto", "idreg", "idrendicontattivitaprogetto", "idworkpackage");

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

	//////////////////// GETREGISTRYDOCENTIAMMINISTRATIVI /////////////////////////////////
	var tgetregistrydocentiamministrativi= new MetaTable("getregistrydocentiamministrativi");
	tgetregistrydocentiamministrativi.defineColumn("contratto", typeof(string));
	tgetregistrydocentiamministrativi.defineColumn("extmatricula", typeof(string));
	tgetregistrydocentiamministrativi.defineColumn("forename", typeof(string));
	tgetregistrydocentiamministrativi.defineColumn("idreg", typeof(int),false);
	tgetregistrydocentiamministrativi.defineColumn("surname", typeof(string));
	Tables.Add(tgetregistrydocentiamministrativi);
	tgetregistrydocentiamministrativi.defineKey("idreg");

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
	tinventory.defineColumn("codeinventory", typeof(string),false);
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
	tassetdiary.defineColumn("!idasset-idpiece_asset_idinventory_codeinventory", typeof(string));
	tassetdiary.defineColumn("!idasset-idpiece_asset_idinventory_description", typeof(string));
	tassetdiary.defineColumn("!idasset-idpiece_asset_nassetacquire_description", typeof(string));
	tassetdiary.defineColumn("!idasset-idpiece_asset_nassetacquire_idinv", typeof(int));
	tassetdiary.defineColumn("!idasset-idpiece_asset_nassetacquire_idupb", typeof(string));
	tassetdiary.defineColumn("!idreg_getregistrydocentiamministrativi_surname", typeof(string));
	tassetdiary.defineColumn("!idreg_getregistrydocentiamministrativi_forename", typeof(string));
	tassetdiary.defineColumn("!idreg_getregistrydocentiamministrativi_extmatricula", typeof(string));
	tassetdiary.defineColumn("!idreg_getregistrydocentiamministrativi_contratto", typeof(string));
	tassetdiary.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tassetdiary);
	tassetdiary.defineKey("idassetdiary", "idworkpackage");

	//////////////////// UPBELENCHIVIEW /////////////////////////////////
	var tupbelenchiview= new MetaTable("upbelenchiview");
	tupbelenchiview.defineColumn("active", typeof(string));
	tupbelenchiview.defineColumn("assured", typeof(string));
	tupbelenchiview.defineColumn("cigcode", typeof(string));
	tupbelenchiview.defineColumn("codeupb", typeof(string),false);
	tupbelenchiview.defineColumn("cofogmpcode", typeof(string));
	tupbelenchiview.defineColumn("ct", typeof(DateTime),false);
	tupbelenchiview.defineColumn("cu", typeof(string),false);
	tupbelenchiview.defineColumn("cupcode", typeof(string));
	tupbelenchiview.defineColumn("expiration", typeof(DateTime));
	tupbelenchiview.defineColumn("flag", typeof(int));
	tupbelenchiview.defineColumn("flagactivity", typeof(int));
	tupbelenchiview.defineColumn("flagkind", typeof(int));
	tupbelenchiview.defineColumn("granted", typeof(decimal));
	tupbelenchiview.defineColumn("idepupbkind", typeof(int));
	tupbelenchiview.defineColumn("idman", typeof(int));
	tupbelenchiview.defineColumn("idtreasurer", typeof(int));
	tupbelenchiview.defineColumn("idunderwriter", typeof(int));
	tupbelenchiview.defineColumn("idupb", typeof(string),false);
	tupbelenchiview.defineColumn("idupb_capofila", typeof(string));
	tupbelenchiview.defineColumn("lt", typeof(DateTime),false);
	tupbelenchiview.defineColumn("lu", typeof(string),false);
	tupbelenchiview.defineColumn("newcodeupb", typeof(string));
	tupbelenchiview.defineColumn("paridupb", typeof(string));
	tupbelenchiview.defineColumn("previousappropriation", typeof(decimal));
	tupbelenchiview.defineColumn("previousassessment", typeof(decimal));
	tupbelenchiview.defineColumn("printingorder", typeof(string),false);
	tupbelenchiview.defineColumn("requested", typeof(decimal));
	tupbelenchiview.defineColumn("ri_ra_quota", typeof(decimal));
	tupbelenchiview.defineColumn("ri_rb_quota", typeof(decimal));
	tupbelenchiview.defineColumn("ri_sa_quota", typeof(decimal));
	tupbelenchiview.defineColumn("rtf", typeof(Byte[]));
	tupbelenchiview.defineColumn("start", typeof(DateTime));
	tupbelenchiview.defineColumn("stop", typeof(DateTime));
	tupbelenchiview.defineColumn("title", typeof(string),false);
	tupbelenchiview.defineColumn("txt", typeof(string));
	tupbelenchiview.defineColumn("uesiopecode", typeof(string));
	Tables.Add(tupbelenchiview);
	tupbelenchiview.defineKey("idupb");

	//////////////////// WORKPACKAGEUPB /////////////////////////////////
	var tworkpackageupb= new MetaTable("workpackageupb");
	tworkpackageupb.defineColumn("ct", typeof(DateTime),false);
	tworkpackageupb.defineColumn("cu", typeof(string),false);
	tworkpackageupb.defineColumn("idprogetto", typeof(int),false);
	tworkpackageupb.defineColumn("idupb", typeof(string),false);
	tworkpackageupb.defineColumn("idworkpackage", typeof(int),false);
	tworkpackageupb.defineColumn("lt", typeof(DateTime),false);
	tworkpackageupb.defineColumn("lu", typeof(string),false);
	tworkpackageupb.defineColumn("!idupb_upbelenchiview_codeupb", typeof(string));
	tworkpackageupb.defineColumn("!idupb_upbelenchiview_title", typeof(string));
	tworkpackageupb.defineColumn("!idupb_upbelenchiview_active", typeof(string));
	Tables.Add(tworkpackageupb);
	tworkpackageupb.defineKey("idprogetto", "idupb", "idworkpackage");

	//////////////////// STRUTTURADEFAULTVIEW /////////////////////////////////
	var tstrutturadefaultview= new MetaTable("strutturadefaultview");
	tstrutturadefaultview.defineColumn("aoo_title", typeof(string));
	tstrutturadefaultview.defineColumn("dropdown_title", typeof(string),false);
	tstrutturadefaultview.defineColumn("idstruttura", typeof(int),false);
	tstrutturadefaultview.defineColumn("idupb", typeof(string));
	tstrutturadefaultview.defineColumn("paridstruttura", typeof(int));
	tstrutturadefaultview.defineColumn("sede_title", typeof(string));
	tstrutturadefaultview.defineColumn("struttura_active", typeof(string));
	tstrutturadefaultview.defineColumn("struttura_codice", typeof(string));
	tstrutturadefaultview.defineColumn("struttura_codiceipa", typeof(string));
	tstrutturadefaultview.defineColumn("struttura_ct", typeof(DateTime),false);
	tstrutturadefaultview.defineColumn("struttura_cu", typeof(string),false);
	tstrutturadefaultview.defineColumn("struttura_email", typeof(string));
	tstrutturadefaultview.defineColumn("struttura_fax", typeof(string));
	tstrutturadefaultview.defineColumn("struttura_idaoo", typeof(int));
	tstrutturadefaultview.defineColumn("struttura_idreg", typeof(int));
	tstrutturadefaultview.defineColumn("struttura_idsede", typeof(int),false);
	tstrutturadefaultview.defineColumn("struttura_idstrutturakind", typeof(int),false);
	tstrutturadefaultview.defineColumn("struttura_lt", typeof(DateTime),false);
	tstrutturadefaultview.defineColumn("struttura_lu", typeof(string),false);
	tstrutturadefaultview.defineColumn("struttura_pesoindicatori", typeof(decimal));
	tstrutturadefaultview.defineColumn("struttura_pesoobiettivi", typeof(decimal));
	tstrutturadefaultview.defineColumn("struttura_pesoprogaltreuo", typeof(decimal));
	tstrutturadefaultview.defineColumn("struttura_pesoproguo", typeof(decimal));
	tstrutturadefaultview.defineColumn("struttura_telefono", typeof(string));
	tstrutturadefaultview.defineColumn("struttura_title_en", typeof(string));
	tstrutturadefaultview.defineColumn("strutturakind_struttura_title", typeof(string));
	tstrutturadefaultview.defineColumn("strutturakind_title", typeof(string));
	tstrutturadefaultview.defineColumn("strutturaparent_idstrutturakind", typeof(int));
	tstrutturadefaultview.defineColumn("strutturaparent_title", typeof(string));
	tstrutturadefaultview.defineColumn("title", typeof(string));
	tstrutturadefaultview.defineColumn("upb_title", typeof(string));
	Tables.Add(tstrutturadefaultview);
	tstrutturadefaultview.defineKey("idstruttura");

	//////////////////// WORKPACKAGE /////////////////////////////////
	var tworkpackage= new MetaTable("workpackage");
	tworkpackage.defineColumn("!titolobreve", typeof(string));
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
	tworkpackage.defineColumn("title", typeof(string),false);
	Tables.Add(tworkpackage);
	tworkpackage.defineKey("idprogetto", "idworkpackage");

	#endregion


	#region DataRelation creation
	var cPar = new []{workpackage.Columns["idprogetto"], workpackage.Columns["idworkpackage"]};
	var cChild = new []{rendicontattivitaprogetto_alias1.Columns["idprogetto"], rendicontattivitaprogetto_alias1.Columns["idworkpackage"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogetto_alias1_workpackage_idprogetto-idworkpackage",cPar,cChild,false));

	cPar = new []{rendicontattivitaprogetto_alias1.Columns["idprogetto"], rendicontattivitaprogetto_alias1.Columns["idworkpackage"], rendicontattivitaprogetto_alias1.Columns["idrendicontattivitaprogetto"], rendicontattivitaprogetto_alias1.Columns["iditineration"]};
	cChild = new []{rendicontattivitaprogettoitineration.Columns["idprogetto"], rendicontattivitaprogettoitineration.Columns["idworkpackage"], rendicontattivitaprogettoitineration.Columns["idrendicontattivitaprogetto"], rendicontattivitaprogettoitineration.Columns["iditineration"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogettoitineration_rendicontattivitaprogetto_alias1_idprogetto-idworkpackage-idrendicontattivitaprogetto-iditineration",cPar,cChild,false));

	cPar = new []{rendicontattivitaprogetto_alias1.Columns["idprogetto"], rendicontattivitaprogetto_alias1.Columns["idworkpackage"], rendicontattivitaprogetto_alias1.Columns["idrendicontattivitaprogetto"]};
	cChild = new []{rendicontattivitaprogettoyear.Columns["idprogetto"], rendicontattivitaprogettoyear.Columns["idworkpackage"], rendicontattivitaprogettoyear.Columns["idrendicontattivitaprogetto"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogettoyear_rendicontattivitaprogetto_alias1_idprogetto-idworkpackage-idrendicontattivitaprogetto",cPar,cChild,false));

	cPar = new []{rendicontattivitaprogetto_alias1.Columns["idprogetto"], rendicontattivitaprogetto_alias1.Columns["idworkpackage"], rendicontattivitaprogetto_alias1.Columns["idrendicontattivitaprogetto"], rendicontattivitaprogetto_alias1.Columns["idreg"]};
	cChild = new []{rendicontattivitaprogettoora.Columns["idprogetto"], rendicontattivitaprogettoora.Columns["idworkpackage"], rendicontattivitaprogettoora.Columns["idrendicontattivitaprogetto"], rendicontattivitaprogettoora.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogettoora_rendicontattivitaprogetto_alias1_idprogetto-idworkpackage-idrendicontattivitaprogetto-idreg",cPar,cChild,false));

	cPar = new []{rendicontattivitaprogettokind.Columns["idrendicontattivitaprogettokind"]};
	cChild = new []{rendicontattivitaprogetto_alias1.Columns["idrendicontattivitaprogettokind"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogetto_alias1_rendicontattivitaprogettokind_idrendicontattivitaprogettokind",cPar,cChild,false));

	cPar = new []{getregistrydocentiamministrativi_alias1.Columns["idreg"]};
	cChild = new []{rendicontattivitaprogetto_alias1.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogetto_alias1_getregistrydocentiamministrativi_alias1_idreg",cPar,cChild,false));

	cPar = new []{workpackage.Columns["idprogetto"], workpackage.Columns["idworkpackage"]};
	cChild = new []{assetdiary.Columns["idprogetto"], assetdiary.Columns["idworkpackage"]};
	Relations.Add(new DataRelation("FK_assetdiary_workpackage_idprogetto-idworkpackage",cPar,cChild,false));

	cPar = new []{assetdiary.Columns["idassetdiary"], assetdiary.Columns["idworkpackage"]};
	cChild = new []{assetdiaryora.Columns["idassetdiary"], assetdiaryora.Columns["idworkpackage"]};
	Relations.Add(new DataRelation("FK_assetdiaryora_assetdiary_idassetdiary-idworkpackage",cPar,cChild,false));

	cPar = new []{getregistrydocentiamministrativi.Columns["idreg"]};
	cChild = new []{assetdiary.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_assetdiary_getregistrydocentiamministrativi_idreg",cPar,cChild,false));

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

	cPar = new []{upbelenchiview.Columns["idupb"]};
	cChild = new []{workpackageupb.Columns["idupb"]};
	Relations.Add(new DataRelation("FK_workpackageupb_upbelenchiview_idupb",cPar,cChild,false));

	cPar = new []{strutturadefaultview.Columns["idstruttura"]};
	cChild = new []{workpackage.Columns["idstruttura"]};
	Relations.Add(new DataRelation("FK_workpackage_strutturadefaultview_idstruttura",cPar,cChild,false));

	#endregion

}
}
}
