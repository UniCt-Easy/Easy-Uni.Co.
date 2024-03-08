
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
[System.Xml.Serialization.XmlRoot("dsmeta_sal_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_sal_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable workpackage_alias3 		=> (MetaTable)Tables["workpackage_alias3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sal_alias3 		=> (MetaTable)Tables["sal_alias3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontattivitaprogetto_alias1 		=> (MetaTable)Tables["rendicontattivitaprogetto_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontattivitaprogettoora 		=> (MetaTable)Tables["rendicontattivitaprogettoora"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable salrendicontattivitaprogettoora 		=> (MetaTable)Tables["salrendicontattivitaprogettoora"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable workpackage_alias2 		=> (MetaTable)Tables["workpackage_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sal_alias2 		=> (MetaTable)Tables["sal_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettotipocosto 		=> (MetaTable)Tables["progettotipocosto"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pettycash 		=> (MetaTable)Tables["pettycash"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable expense 		=> (MetaTable)Tables["expense"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable contrattokind 		=> (MetaTable)Tables["contrattokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable mese 		=> (MetaTable)Tables["mese"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable salprogettoassetworkpackage_alias2 		=> (MetaTable)Tables["salprogettoassetworkpackage_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable salprogettoassetworkpackagemese_alias1 		=> (MetaTable)Tables["salprogettoassetworkpackagemese_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetdiary_alias1 		=> (MetaTable)Tables["assetdiary_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetdiaryora_alias2 		=> (MetaTable)Tables["assetdiaryora_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontattivitaprogetto 		=> (MetaTable)Tables["rendicontattivitaprogetto"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettocosto 		=> (MetaTable)Tables["progettocosto"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable salprogettocosto 		=> (MetaTable)Tables["salprogettocosto"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable salprogettoassetworkpackagemese 		=> (MetaTable)Tables["salprogettoassetworkpackagemese"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable workpackage_alias1 		=> (MetaTable)Tables["workpackage_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetacquire 		=> (MetaTable)Tables["assetacquire"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable inventory 		=> (MetaTable)Tables["inventory"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable salprogettoassetworkpackage 		=> (MetaTable)Tables["salprogettoassetworkpackage"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable workpackage 		=> (MetaTable)Tables["workpackage"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sal_alias1 		=> (MetaTable)Tables["sal_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry 		=> (MetaTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable asset 		=> (MetaTable)Tables["asset"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetdiary 		=> (MetaTable)Tables["assetdiary"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetdiaryora 		=> (MetaTable)Tables["assetdiaryora"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable salassetdiaryora 		=> (MetaTable)Tables["salassetdiaryora"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sal 		=> (MetaTable)Tables["sal"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_sal_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_sal_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_sal_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_sal_default.xsd";

	#region create DataTables
	//////////////////// WORKPACKAGE_ALIAS3 /////////////////////////////////
	var tworkpackage_alias3= new MetaTable("workpackage_alias3");
	tworkpackage_alias3.defineColumn("idprogetto", typeof(int),false);
	tworkpackage_alias3.defineColumn("idworkpackage", typeof(int),false);
	tworkpackage_alias3.defineColumn("raggruppamento", typeof(string));
	tworkpackage_alias3.defineColumn("title", typeof(string));
	tworkpackage_alias3.ExtendedProperties["TableForReading"]="workpackage";
	Tables.Add(tworkpackage_alias3);
	tworkpackage_alias3.defineKey("idprogetto", "idworkpackage");

	//////////////////// SAL_ALIAS3 /////////////////////////////////
	var tsal_alias3= new MetaTable("sal_alias3");
	tsal_alias3.defineColumn("idprogetto", typeof(int),false);
	tsal_alias3.defineColumn("idsal", typeof(int),false);
	tsal_alias3.defineColumn("start", typeof(DateTime));
	tsal_alias3.defineColumn("stop", typeof(DateTime));
	tsal_alias3.ExtendedProperties["TableForReading"]="sal";
	Tables.Add(tsal_alias3);
	tsal_alias3.defineKey("idprogetto", "idsal");

	//////////////////// RENDICONTATTIVITAPROGETTO_ALIAS1 /////////////////////////////////
	var trendicontattivitaprogetto_alias1= new MetaTable("rendicontattivitaprogetto_alias1");
	trendicontattivitaprogetto_alias1.defineColumn("!orerendicont", typeof(string));
	trendicontattivitaprogetto_alias1.defineColumn("ct", typeof(DateTime),false);
	trendicontattivitaprogetto_alias1.defineColumn("cu", typeof(string),false);
	trendicontattivitaprogetto_alias1.defineColumn("datainizioprevista", typeof(DateTime),false);
	trendicontattivitaprogetto_alias1.defineColumn("description", typeof(string));
	trendicontattivitaprogetto_alias1.defineColumn("iditineration", typeof(int));
	trendicontattivitaprogetto_alias1.defineColumn("idprogetto", typeof(int),false);
	trendicontattivitaprogetto_alias1.defineColumn("idreg", typeof(int),false);
	trendicontattivitaprogetto_alias1.defineColumn("idrendicontattivitaprogetto", typeof(int),false);
	trendicontattivitaprogetto_alias1.defineColumn("idworkpackage", typeof(int),false);
	trendicontattivitaprogetto_alias1.defineColumn("lt", typeof(DateTime),false);
	trendicontattivitaprogetto_alias1.defineColumn("lu", typeof(string),false);
	trendicontattivitaprogetto_alias1.defineColumn("orepreventivate", typeof(int),false);
	trendicontattivitaprogetto_alias1.defineColumn("stop", typeof(DateTime));
	trendicontattivitaprogetto_alias1.ExtendedProperties["TableForReading"]="rendicontattivitaprogetto";
	Tables.Add(trendicontattivitaprogetto_alias1);
	trendicontattivitaprogetto_alias1.defineKey("idprogetto", "idrendicontattivitaprogetto", "idworkpackage");

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
	Tables.Add(trendicontattivitaprogettoora);
	trendicontattivitaprogettoora.defineKey("idrendicontattivitaprogetto", "idrendicontattivitaprogettoora", "idworkpackage");

	//////////////////// SALRENDICONTATTIVITAPROGETTOORA /////////////////////////////////
	var tsalrendicontattivitaprogettoora= new MetaTable("salrendicontattivitaprogettoora");
	tsalrendicontattivitaprogettoora.defineColumn("ct", typeof(DateTime),false);
	tsalrendicontattivitaprogettoora.defineColumn("cu", typeof(string),false);
	tsalrendicontattivitaprogettoora.defineColumn("idprogetto", typeof(int),false);
	tsalrendicontattivitaprogettoora.defineColumn("idrendicontattivitaprogettoora", typeof(int),false);
	tsalrendicontattivitaprogettoora.defineColumn("idsal", typeof(int),false);
	tsalrendicontattivitaprogettoora.defineColumn("lt", typeof(DateTime),false);
	tsalrendicontattivitaprogettoora.defineColumn("lu", typeof(string),false);
	tsalrendicontattivitaprogettoora.defineColumn("!idrendicontattivitaprogettoora_workpackage_alias3_raggruppamento", typeof(string));
	tsalrendicontattivitaprogettoora.defineColumn("!idrendicontattivitaprogettoora_workpackage_alias3_title", typeof(string));
	tsalrendicontattivitaprogettoora.defineColumn("!idrendicontattivitaprogettoora_rendicontattivitaprogettoora_data", typeof(DateTime));
	tsalrendicontattivitaprogettoora.defineColumn("!idrendicontattivitaprogettoora_rendicontattivitaprogetto_alias1_description", typeof(string));
	tsalrendicontattivitaprogettoora.defineColumn("!idrendicontattivitaprogettoora_rendicontattivitaprogetto_alias1_registry_title", typeof(string));
	tsalrendicontattivitaprogettoora.defineColumn("!idrendicontattivitaprogettoora_rendicontattivitaprogettoora_ore", typeof(int));
	tsalrendicontattivitaprogettoora.defineColumn("!idrendicontattivitaprogettoora_sal_alias3_start", typeof(DateTime));
	tsalrendicontattivitaprogettoora.defineColumn("!idrendicontattivitaprogettoora_sal_alias3_stop", typeof(DateTime));
	Tables.Add(tsalrendicontattivitaprogettoora);
	tsalrendicontattivitaprogettoora.defineKey("idprogetto", "idrendicontattivitaprogettoora", "idsal");

	//////////////////// WORKPACKAGE_ALIAS2 /////////////////////////////////
	var tworkpackage_alias2= new MetaTable("workpackage_alias2");
	tworkpackage_alias2.defineColumn("idprogetto", typeof(int),false);
	tworkpackage_alias2.defineColumn("idworkpackage", typeof(int),false);
	tworkpackage_alias2.defineColumn("raggruppamento", typeof(string));
	tworkpackage_alias2.defineColumn("title", typeof(string));
	tworkpackage_alias2.ExtendedProperties["TableForReading"]="workpackage";
	Tables.Add(tworkpackage_alias2);
	tworkpackage_alias2.defineKey("idprogetto", "idworkpackage");

	//////////////////// SAL_ALIAS2 /////////////////////////////////
	var tsal_alias2= new MetaTable("sal_alias2");
	tsal_alias2.defineColumn("idprogetto", typeof(int),false);
	tsal_alias2.defineColumn("idsal", typeof(int),false);
	tsal_alias2.defineColumn("start", typeof(DateTime));
	tsal_alias2.defineColumn("stop", typeof(DateTime));
	tsal_alias2.ExtendedProperties["TableForReading"]="sal";
	Tables.Add(tsal_alias2);
	tsal_alias2.defineKey("idprogetto", "idsal");

	//////////////////// PROGETTOTIPOCOSTO /////////////////////////////////
	var tprogettotipocosto= new MetaTable("progettotipocosto");
	tprogettotipocosto.defineColumn("idprogetto", typeof(int),false);
	tprogettotipocosto.defineColumn("idprogettotipocosto", typeof(int),false);
	tprogettotipocosto.defineColumn("title", typeof(string));
	Tables.Add(tprogettotipocosto);
	tprogettotipocosto.defineKey("idprogetto", "idprogettotipocosto");

	//////////////////// PETTYCASH /////////////////////////////////
	var tpettycash= new MetaTable("pettycash");
	tpettycash.defineColumn("active", typeof(string));
	tpettycash.defineColumn("description", typeof(string),false);
	tpettycash.defineColumn("idpettycash", typeof(int),false);
	tpettycash.defineColumn("pettycode", typeof(string));
	Tables.Add(tpettycash);
	tpettycash.defineKey("idpettycash");

	//////////////////// EXPENSE /////////////////////////////////
	var texpense= new MetaTable("expense");
	texpense.defineColumn("description", typeof(string),false);
	texpense.defineColumn("idexp", typeof(int),false);
	texpense.defineColumn("nmov", typeof(int),false);
	texpense.defineColumn("ymov", typeof(int),false);
	Tables.Add(texpense);
	texpense.defineKey("idexp");

	//////////////////// CONTRATTOKIND /////////////////////////////////
	var tcontrattokind= new MetaTable("contrattokind");
	tcontrattokind.defineColumn("active", typeof(string),false);
	tcontrattokind.defineColumn("idcontrattokind", typeof(int),false);
	tcontrattokind.defineColumn("title", typeof(string),false);
	Tables.Add(tcontrattokind);
	tcontrattokind.defineKey("idcontrattokind");

	//////////////////// MESE /////////////////////////////////
	var tmese= new MetaTable("mese");
	tmese.defineColumn("idmese", typeof(int),false);
	tmese.defineColumn("title", typeof(string));
	Tables.Add(tmese);
	tmese.defineKey("idmese");

	//////////////////// SALPROGETTOASSETWORKPACKAGE_ALIAS2 /////////////////////////////////
	var tsalprogettoassetworkpackage_alias2= new MetaTable("salprogettoassetworkpackage_alias2");
	tsalprogettoassetworkpackage_alias2.defineColumn("idasset", typeof(int),false);
	tsalprogettoassetworkpackage_alias2.defineColumn("idpiece", typeof(int),false);
	tsalprogettoassetworkpackage_alias2.defineColumn("idprogetto", typeof(int),false);
	tsalprogettoassetworkpackage_alias2.defineColumn("idsal", typeof(int),false);
	tsalprogettoassetworkpackage_alias2.defineColumn("idsalprogettoassetworkpackage", typeof(int),false);
	tsalprogettoassetworkpackage_alias2.defineColumn("percentuale", typeof(decimal));
	tsalprogettoassetworkpackage_alias2.ExtendedProperties["TableForReading"]="salprogettoassetworkpackage";
	Tables.Add(tsalprogettoassetworkpackage_alias2);
	tsalprogettoassetworkpackage_alias2.defineKey("idasset", "idpiece", "idprogetto", "idsal", "idsalprogettoassetworkpackage");

	//////////////////// SALPROGETTOASSETWORKPACKAGEMESE_ALIAS1 /////////////////////////////////
	var tsalprogettoassetworkpackagemese_alias1= new MetaTable("salprogettoassetworkpackagemese_alias1");
	tsalprogettoassetworkpackagemese_alias1.defineColumn("amount", typeof(decimal));
	tsalprogettoassetworkpackagemese_alias1.defineColumn("idmese", typeof(int));
	tsalprogettoassetworkpackagemese_alias1.defineColumn("idprogetto", typeof(int),false);
	tsalprogettoassetworkpackagemese_alias1.defineColumn("idsal", typeof(int),false);
	tsalprogettoassetworkpackagemese_alias1.defineColumn("idsalprogettoassetworkpackage", typeof(int),false);
	tsalprogettoassetworkpackagemese_alias1.defineColumn("idsalprogettoassetworkpackagemese", typeof(int),false);
	tsalprogettoassetworkpackagemese_alias1.defineColumn("year", typeof(int));
	tsalprogettoassetworkpackagemese_alias1.ExtendedProperties["TableForReading"]="salprogettoassetworkpackagemese";
	Tables.Add(tsalprogettoassetworkpackagemese_alias1);
	tsalprogettoassetworkpackagemese_alias1.defineKey("idprogetto", "idsal", "idsalprogettoassetworkpackage", "idsalprogettoassetworkpackagemese");

	//////////////////// ASSETDIARY_ALIAS1 /////////////////////////////////
	var tassetdiary_alias1= new MetaTable("assetdiary_alias1");
	tassetdiary_alias1.defineColumn("idassetdiary", typeof(int),false);
	tassetdiary_alias1.defineColumn("idpiece", typeof(int));
	tassetdiary_alias1.defineColumn("idreg", typeof(int),false);
	tassetdiary_alias1.defineColumn("idworkpackage", typeof(int),false);
	tassetdiary_alias1.defineColumn("orepreventivate", typeof(int));
	tassetdiary_alias1.ExtendedProperties["TableForReading"]="assetdiary";
	Tables.Add(tassetdiary_alias1);
	tassetdiary_alias1.defineKey("idassetdiary", "idworkpackage");

	//////////////////// ASSETDIARYORA_ALIAS2 /////////////////////////////////
	var tassetdiaryora_alias2= new MetaTable("assetdiaryora_alias2");
	tassetdiaryora_alias2.defineColumn("!title", typeof(string));
	tassetdiaryora_alias2.defineColumn("amount", typeof(decimal));
	tassetdiaryora_alias2.defineColumn("ct", typeof(DateTime),false);
	tassetdiaryora_alias2.defineColumn("cu", typeof(string),false);
	tassetdiaryora_alias2.defineColumn("idassetdiary", typeof(int),false);
	tassetdiaryora_alias2.defineColumn("idassetdiaryora", typeof(int),false);
	tassetdiaryora_alias2.defineColumn("idsal", typeof(int));
	tassetdiaryora_alias2.defineColumn("idworkpackage", typeof(int),false);
	tassetdiaryora_alias2.defineColumn("lt", typeof(DateTime),false);
	tassetdiaryora_alias2.defineColumn("lu", typeof(string),false);
	tassetdiaryora_alias2.defineColumn("start", typeof(DateTime));
	tassetdiaryora_alias2.defineColumn("stop", typeof(DateTime));
	tassetdiaryora_alias2.ExtendedProperties["TableForReading"]="assetdiaryora";
	Tables.Add(tassetdiaryora_alias2);
	tassetdiaryora_alias2.defineKey("idassetdiary", "idassetdiaryora", "idworkpackage");

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
	Tables.Add(trendicontattivitaprogetto);
	trendicontattivitaprogetto.defineKey("idprogetto", "idrendicontattivitaprogetto", "idworkpackage");

	//////////////////// PROGETTOCOSTO /////////////////////////////////
	var tprogettocosto= new MetaTable("progettocosto");
	tprogettocosto.defineColumn("amount", typeof(decimal));
	tprogettocosto.defineColumn("ct", typeof(DateTime));
	tprogettocosto.defineColumn("cu", typeof(string));
	tprogettocosto.defineColumn("doc", typeof(string));
	tprogettocosto.defineColumn("docdate", typeof(DateTime));
	tprogettocosto.defineColumn("idassetdiaryora", typeof(int));
	tprogettocosto.defineColumn("idcontrattokind", typeof(int));
	tprogettocosto.defineColumn("idexp", typeof(int));
	tprogettocosto.defineColumn("idpettycash", typeof(int));
	tprogettocosto.defineColumn("idprogetto", typeof(int),false);
	tprogettocosto.defineColumn("idprogettocosto", typeof(int),false);
	tprogettocosto.defineColumn("idprogettotipocosto", typeof(int),false);
	tprogettocosto.defineColumn("idrelated", typeof(string));
	tprogettocosto.defineColumn("idrendicontattivitaprogetto", typeof(int));
	tprogettocosto.defineColumn("idsal", typeof(int));
	tprogettocosto.defineColumn("idsalprogettoassetworkpackagemese", typeof(int));
	tprogettocosto.defineColumn("idworkpackage", typeof(int),false);
	tprogettocosto.defineColumn("lt", typeof(DateTime));
	tprogettocosto.defineColumn("lu", typeof(string));
	tprogettocosto.defineColumn("noperation", typeof(int));
	tprogettocosto.defineColumn("yoperation", typeof(int));
	Tables.Add(tprogettocosto);
	tprogettocosto.defineKey("idprogetto", "idprogettocosto", "idprogettotipocosto", "idworkpackage");

	//////////////////// SALPROGETTOCOSTO /////////////////////////////////
	var tsalprogettocosto= new MetaTable("salprogettocosto");
	tsalprogettocosto.defineColumn("ct", typeof(DateTime),false);
	tsalprogettocosto.defineColumn("cu", typeof(string),false);
	tsalprogettocosto.defineColumn("idprogetto", typeof(int),false);
	tsalprogettocosto.defineColumn("idprogettocosto", typeof(int),false);
	tsalprogettocosto.defineColumn("idsal", typeof(int),false);
	tsalprogettocosto.defineColumn("lt", typeof(DateTime),false);
	tsalprogettocosto.defineColumn("lu", typeof(string),false);
	tsalprogettocosto.defineColumn("!idprogettocosto_workpackage_alias2_raggruppamento", typeof(string));
	tsalprogettocosto.defineColumn("!idprogettocosto_workpackage_alias2_title", typeof(string));
	tsalprogettocosto.defineColumn("!idprogettocosto_progettotipocosto_title", typeof(string));
	tsalprogettocosto.defineColumn("!idprogettocosto_progettocosto_amount", typeof(decimal));
	tsalprogettocosto.defineColumn("!idprogettocosto_contrattokind_title", typeof(string));
	tsalprogettocosto.defineColumn("!idprogettocosto_rendicontattivitaprogetto_description", typeof(string));
	tsalprogettocosto.defineColumn("!idprogettocosto_rendicontattivitaprogetto_registry_title", typeof(string));
	tsalprogettocosto.defineColumn("!idprogettocosto_progettocosto_doc", typeof(string));
	tsalprogettocosto.defineColumn("!idprogettocosto_progettocosto_docdate", typeof(DateTime));
	tsalprogettocosto.defineColumn("!idprogettocosto_expense_description", typeof(string));
	tsalprogettocosto.defineColumn("!idprogettocosto_expense_ymov", typeof(int));
	tsalprogettocosto.defineColumn("!idprogettocosto_expense_nmov", typeof(int));
	tsalprogettocosto.defineColumn("!idprogettocosto_pettycash_description", typeof(string));
	tsalprogettocosto.defineColumn("!idprogettocosto_pettycash_pettycode", typeof(string));
	tsalprogettocosto.defineColumn("!idprogettocosto_progettocosto_yoperation", typeof(int));
	tsalprogettocosto.defineColumn("!idprogettocosto_progettocosto_noperation", typeof(int));
	tsalprogettocosto.defineColumn("!idprogettocosto_assetdiaryora_alias2_assetdiary_alias1_idpiece", typeof(int));
	tsalprogettocosto.defineColumn("!idprogettocosto_assetdiaryora_alias2_assetdiary_alias1_idreg", typeof(int));
	tsalprogettocosto.defineColumn("!idprogettocosto_assetdiaryora_alias2_assetdiary_alias1_orepreventivate", typeof(int));
	tsalprogettocosto.defineColumn("!idprogettocosto_assetdiaryora_alias2_start", typeof(DateTime));
	tsalprogettocosto.defineColumn("!idprogettocosto_assetdiaryora_alias2_stop", typeof(DateTime));
	tsalprogettocosto.defineColumn("!idprogettocosto_salprogettoassetworkpackagemese_alias1_salprogettoassetworkpackage_alias2_idpiece", typeof(int));
	tsalprogettocosto.defineColumn("!idprogettocosto_salprogettoassetworkpackagemese_alias1_salprogettoassetworkpackage_alias2_percentuale", typeof(decimal));
	tsalprogettocosto.defineColumn("!idprogettocosto_salprogettoassetworkpackagemese_alias1_mese_title", typeof(string));
	tsalprogettocosto.defineColumn("!idprogettocosto_salprogettoassetworkpackagemese_alias1_amount", typeof(decimal));
	tsalprogettocosto.defineColumn("!idprogettocosto_sal_alias2_start", typeof(DateTime));
	tsalprogettocosto.defineColumn("!idprogettocosto_sal_alias2_stop", typeof(DateTime));
	Tables.Add(tsalprogettocosto);
	tsalprogettocosto.defineKey("idprogetto", "idprogettocosto", "idsal");

	//////////////////// SALPROGETTOASSETWORKPACKAGEMESE /////////////////////////////////
	var tsalprogettoassetworkpackagemese= new MetaTable("salprogettoassetworkpackagemese");
	tsalprogettoassetworkpackagemese.defineColumn("amount", typeof(decimal));
	tsalprogettoassetworkpackagemese.defineColumn("idmese", typeof(int));
	tsalprogettoassetworkpackagemese.defineColumn("idprogetto", typeof(int),false);
	tsalprogettoassetworkpackagemese.defineColumn("idsal", typeof(int),false);
	tsalprogettoassetworkpackagemese.defineColumn("idsalprogettoassetworkpackage", typeof(int),false);
	tsalprogettoassetworkpackagemese.defineColumn("idsalprogettoassetworkpackagemese", typeof(int),false);
	tsalprogettoassetworkpackagemese.defineColumn("year", typeof(int));
	tsalprogettoassetworkpackagemese.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tsalprogettoassetworkpackagemese);
	tsalprogettoassetworkpackagemese.defineKey("idprogetto", "idsal", "idsalprogettoassetworkpackage", "idsalprogettoassetworkpackagemese");

	//////////////////// WORKPACKAGE_ALIAS1 /////////////////////////////////
	var tworkpackage_alias1= new MetaTable("workpackage_alias1");
	tworkpackage_alias1.defineColumn("idprogetto", typeof(int),false);
	tworkpackage_alias1.defineColumn("idworkpackage", typeof(int),false);
	tworkpackage_alias1.defineColumn("raggruppamento", typeof(string));
	tworkpackage_alias1.defineColumn("title", typeof(string));
	tworkpackage_alias1.ExtendedProperties["TableForReading"]="workpackage";
	Tables.Add(tworkpackage_alias1);
	tworkpackage_alias1.defineKey("idprogetto", "idworkpackage");

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
	tsalprogettoassetworkpackage.defineColumn("!idasset-idpiece_asset_ninventory", typeof(int));
	tsalprogettoassetworkpackage.defineColumn("!idasset-idpiece_asset_idasset", typeof(int));
	tsalprogettoassetworkpackage.defineColumn("!idasset-idpiece_asset_idpiece", typeof(int));
	tsalprogettoassetworkpackage.defineColumn("!idasset-idpiece_asset_rfid", typeof(string));
	tsalprogettoassetworkpackage.defineColumn("!idasset-idpiece_asset_idinventory_codeinventory", typeof(string));
	tsalprogettoassetworkpackage.defineColumn("!idasset-idpiece_asset_idinventory_description", typeof(string));
	tsalprogettoassetworkpackage.defineColumn("!idasset-idpiece_asset_nassetacquire_description", typeof(string));
	tsalprogettoassetworkpackage.defineColumn("!idasset-idpiece_asset_nassetacquire_idinv", typeof(int));
	tsalprogettoassetworkpackage.defineColumn("!idasset-idpiece_asset_nassetacquire_idupb", typeof(string));
	tsalprogettoassetworkpackage.defineColumn("!idworkpackage_workpackage_raggruppamento", typeof(string));
	tsalprogettoassetworkpackage.defineColumn("!idworkpackage_workpackage_title", typeof(string));
	Tables.Add(tsalprogettoassetworkpackage);
	tsalprogettoassetworkpackage.defineKey("idasset", "idpiece", "idprogetto", "idsal", "idsalprogettoassetworkpackage");

	//////////////////// WORKPACKAGE /////////////////////////////////
	var tworkpackage= new MetaTable("workpackage");
	tworkpackage.defineColumn("idprogetto", typeof(int),false);
	tworkpackage.defineColumn("idworkpackage", typeof(int),false);
	tworkpackage.defineColumn("raggruppamento", typeof(string));
	tworkpackage.defineColumn("title", typeof(string));
	Tables.Add(tworkpackage);
	tworkpackage.defineKey("idprogetto", "idworkpackage");

	//////////////////// SAL_ALIAS1 /////////////////////////////////
	var tsal_alias1= new MetaTable("sal_alias1");
	tsal_alias1.defineColumn("idprogetto", typeof(int),false);
	tsal_alias1.defineColumn("idsal", typeof(int),false);
	tsal_alias1.defineColumn("start", typeof(DateTime));
	tsal_alias1.defineColumn("stop", typeof(DateTime));
	tsal_alias1.ExtendedProperties["TableForReading"]="sal";
	Tables.Add(tsal_alias1);
	tsal_alias1.defineKey("idprogetto", "idsal");

	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new MetaTable("registry");
	tregistry.defineColumn("active", typeof(string),false);
	tregistry.defineColumn("idreg", typeof(int),false);
	tregistry.defineColumn("title", typeof(string),false);
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

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

	//////////////////// SALASSETDIARYORA /////////////////////////////////
	var tsalassetdiaryora= new MetaTable("salassetdiaryora");
	tsalassetdiaryora.defineColumn("ct", typeof(DateTime),false);
	tsalassetdiaryora.defineColumn("cu", typeof(string),false);
	tsalassetdiaryora.defineColumn("idassetdiaryora", typeof(int),false);
	tsalassetdiaryora.defineColumn("idprogetto", typeof(int),false);
	tsalassetdiaryora.defineColumn("idsal", typeof(int),false);
	tsalassetdiaryora.defineColumn("lt", typeof(DateTime),false);
	tsalassetdiaryora.defineColumn("lu", typeof(string),false);
	tsalassetdiaryora.defineColumn("!idassetdiaryora_workpackage_raggruppamento", typeof(string));
	tsalassetdiaryora.defineColumn("!idassetdiaryora_workpackage_title", typeof(string));
	tsalassetdiaryora.defineColumn("!idassetdiaryora_assetdiary_asset_idinventory", typeof(int));
	tsalassetdiaryora.defineColumn("!idassetdiaryora_assetdiary_asset_ninventory", typeof(int));
	tsalassetdiaryora.defineColumn("!idassetdiaryora_assetdiary_asset_idpiece", typeof(int));
	tsalassetdiaryora.defineColumn("!idassetdiaryora_assetdiary_asset_nassetacquire", typeof(int));
	tsalassetdiaryora.defineColumn("!idassetdiaryora_assetdiary_asset_rfid", typeof(string));
	tsalassetdiaryora.defineColumn("!idassetdiaryora_assetdiary_registry_title", typeof(string));
	tsalassetdiaryora.defineColumn("!idassetdiaryora_assetdiaryora_start", typeof(DateTime));
	tsalassetdiaryora.defineColumn("!idassetdiaryora_assetdiaryora_stop", typeof(DateTime));
	tsalassetdiaryora.defineColumn("!idassetdiaryora_assetdiaryora_amount", typeof(decimal));
	tsalassetdiaryora.defineColumn("!idassetdiaryora_sal_alias1_start", typeof(DateTime));
	tsalassetdiaryora.defineColumn("!idassetdiaryora_sal_alias1_stop", typeof(DateTime));
	Tables.Add(tsalassetdiaryora);
	tsalassetdiaryora.defineKey("idassetdiaryora", "idprogetto", "idsal");

	//////////////////// SAL /////////////////////////////////
	var tsal= new MetaTable("sal");
	tsal.defineColumn("!budgetcalcolato", typeof(decimal));
	tsal.defineColumn("budget", typeof(decimal));
	tsal.defineColumn("datablocco", typeof(DateTime));
	tsal.defineColumn("idprogetto", typeof(int),false);
	tsal.defineColumn("idsal", typeof(int),false);
	tsal.defineColumn("start", typeof(DateTime));
	tsal.defineColumn("stop", typeof(DateTime));
	Tables.Add(tsal);
	tsal.defineKey("idprogetto", "idsal");

	#endregion


	#region DataRelation creation
	var cPar = new []{sal.Columns["idprogetto"], sal.Columns["idsal"]};
	var cChild = new []{salrendicontattivitaprogettoora.Columns["idprogetto"], salrendicontattivitaprogettoora.Columns["idsal"]};
	Relations.Add(new DataRelation("FK_salrendicontattivitaprogettoora_sal_idprogetto-idsal",cPar,cChild,false));

	cPar = new []{rendicontattivitaprogettoora.Columns["idrendicontattivitaprogettoora"]};
	cChild = new []{salrendicontattivitaprogettoora.Columns["idrendicontattivitaprogettoora"]};
	Relations.Add(new DataRelation("FK_salrendicontattivitaprogettoora_rendicontattivitaprogettoora_idrendicontattivitaprogettoora",cPar,cChild,false));

	cPar = new []{workpackage_alias3.Columns["idworkpackage"]};
	cChild = new []{rendicontattivitaprogettoora.Columns["idworkpackage"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogettoora_workpackage_alias3_idworkpackage",cPar,cChild,false));

	cPar = new []{sal_alias3.Columns["idsal"]};
	cChild = new []{rendicontattivitaprogettoora.Columns["idsal"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogettoora_sal_alias3_idsal",cPar,cChild,false));

	cPar = new []{rendicontattivitaprogetto_alias1.Columns["idrendicontattivitaprogetto"]};
	cChild = new []{rendicontattivitaprogettoora.Columns["idrendicontattivitaprogetto"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogettoora_rendicontattivitaprogetto_alias1_idrendicontattivitaprogetto",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{rendicontattivitaprogetto_alias1.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogetto_alias1_registry_idreg",cPar,cChild,false));

	cPar = new []{sal.Columns["idprogetto"], sal.Columns["idsal"]};
	cChild = new []{salprogettocosto.Columns["idprogetto"], salprogettocosto.Columns["idsal"]};
	Relations.Add(new DataRelation("FK_salprogettocosto_sal_idprogetto-idsal",cPar,cChild,false));

	cPar = new []{progettocosto.Columns["idprogettocosto"]};
	cChild = new []{salprogettocosto.Columns["idprogettocosto"]};
	Relations.Add(new DataRelation("FK_salprogettocosto_progettocosto_idprogettocosto",cPar,cChild,false));

	cPar = new []{workpackage_alias2.Columns["idworkpackage"]};
	cChild = new []{progettocosto.Columns["idworkpackage"]};
	Relations.Add(new DataRelation("FK_progettocosto_workpackage_alias2_idworkpackage",cPar,cChild,false));

	cPar = new []{salprogettoassetworkpackagemese_alias1.Columns["idsalprogettoassetworkpackagemese"]};
	cChild = new []{progettocosto.Columns["idsalprogettoassetworkpackagemese"]};
	Relations.Add(new DataRelation("FK_progettocosto_salprogettoassetworkpackagemese_alias1_idsalprogettoassetworkpackagemese",cPar,cChild,false));

	cPar = new []{sal_alias2.Columns["idsal"]};
	cChild = new []{progettocosto.Columns["idsal"]};
	Relations.Add(new DataRelation("FK_progettocosto_sal_alias2_idsal",cPar,cChild,false));

	cPar = new []{rendicontattivitaprogetto.Columns["idrendicontattivitaprogetto"]};
	cChild = new []{progettocosto.Columns["idrendicontattivitaprogetto"]};
	Relations.Add(new DataRelation("FK_progettocosto_rendicontattivitaprogetto_idrendicontattivitaprogetto",cPar,cChild,false));

	cPar = new []{progettotipocosto.Columns["idprogettotipocosto"]};
	cChild = new []{progettocosto.Columns["idprogettotipocosto"]};
	Relations.Add(new DataRelation("FK_progettocosto_progettotipocosto_idprogettotipocosto",cPar,cChild,false));

	cPar = new []{pettycash.Columns["idpettycash"]};
	cChild = new []{progettocosto.Columns["idpettycash"]};
	Relations.Add(new DataRelation("FK_progettocosto_pettycash_idpettycash",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{progettocosto.Columns["idexp"]};
	Relations.Add(new DataRelation("FK_progettocosto_expense_idexp",cPar,cChild,false));

	cPar = new []{contrattokind.Columns["idcontrattokind"]};
	cChild = new []{progettocosto.Columns["idcontrattokind"]};
	Relations.Add(new DataRelation("FK_progettocosto_contrattokind_idcontrattokind",cPar,cChild,false));

	cPar = new []{assetdiaryora_alias2.Columns["idassetdiaryora"]};
	cChild = new []{progettocosto.Columns["idassetdiaryora"]};
	Relations.Add(new DataRelation("FK_progettocosto_assetdiaryora_alias2_idassetdiaryora",cPar,cChild,false));

	cPar = new []{mese.Columns["idmese"]};
	cChild = new []{salprogettoassetworkpackagemese_alias1.Columns["idmese"]};
	Relations.Add(new DataRelation("FK_salprogettoassetworkpackagemese_alias1_mese_idmese",cPar,cChild,false));

	cPar = new []{salprogettoassetworkpackage_alias2.Columns["idsalprogettoassetworkpackage"]};
	cChild = new []{salprogettoassetworkpackagemese_alias1.Columns["idsalprogettoassetworkpackage"]};
	Relations.Add(new DataRelation("FK_salprogettoassetworkpackagemese_alias1_salprogettoassetworkpackage_alias2_idsalprogettoassetworkpackage",cPar,cChild,false));

	cPar = new []{assetdiary_alias1.Columns["idassetdiary"]};
	cChild = new []{assetdiaryora_alias2.Columns["idassetdiary"]};
	Relations.Add(new DataRelation("FK_assetdiaryora_alias2_assetdiary_alias1_idassetdiary",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{rendicontattivitaprogetto.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogetto_registry_idreg",cPar,cChild,false));

	cPar = new []{sal.Columns["idprogetto"], sal.Columns["idsal"]};
	cChild = new []{salprogettoassetworkpackage.Columns["idprogetto"], salprogettoassetworkpackage.Columns["idsal"]};
	Relations.Add(new DataRelation("FK_salprogettoassetworkpackage_sal_idprogetto-idsal",cPar,cChild,false));

	cPar = new []{salprogettoassetworkpackage.Columns["idprogetto"], salprogettoassetworkpackage.Columns["idsal"], salprogettoassetworkpackage.Columns["idsalprogettoassetworkpackage"]};
	cChild = new []{salprogettoassetworkpackagemese.Columns["idprogetto"], salprogettoassetworkpackagemese.Columns["idsal"], salprogettoassetworkpackagemese.Columns["idsalprogettoassetworkpackage"]};
	Relations.Add(new DataRelation("FK_salprogettoassetworkpackagemese_salprogettoassetworkpackage_idprogetto-idsal-idsalprogettoassetworkpackage",cPar,cChild,false));

	cPar = new []{workpackage_alias1.Columns["idworkpackage"]};
	cChild = new []{salprogettoassetworkpackage.Columns["idworkpackage"]};
	Relations.Add(new DataRelation("FK_salprogettoassetworkpackage_workpackage_alias1_idworkpackage",cPar,cChild,false));

	cPar = new []{asset.Columns["idasset"], asset.Columns["idpiece"]};
	cChild = new []{salprogettoassetworkpackage.Columns["idasset"], salprogettoassetworkpackage.Columns["idpiece"]};
	Relations.Add(new DataRelation("FK_salprogettoassetworkpackage_asset_idasset-idpiece",cPar,cChild,false));

	cPar = new []{assetacquire.Columns["nassetacquire"]};
	cChild = new []{asset.Columns["nassetacquire"]};
	Relations.Add(new DataRelation("FK_asset_assetacquire_nassetacquire",cPar,cChild,false));

	cPar = new []{inventory.Columns["idinventory"]};
	cChild = new []{asset.Columns["idinventory"]};
	Relations.Add(new DataRelation("FK_asset_inventory_idinventory",cPar,cChild,false));

	cPar = new []{sal.Columns["idprogetto"], sal.Columns["idsal"]};
	cChild = new []{salassetdiaryora.Columns["idprogetto"], salassetdiaryora.Columns["idsal"]};
	Relations.Add(new DataRelation("FK_salassetdiaryora_sal_idprogetto-idsal",cPar,cChild,false));

	cPar = new []{assetdiaryora.Columns["idassetdiaryora"]};
	cChild = new []{salassetdiaryora.Columns["idassetdiaryora"]};
	Relations.Add(new DataRelation("FK_salassetdiaryora_assetdiaryora_idassetdiaryora",cPar,cChild,false));

	cPar = new []{workpackage.Columns["idworkpackage"]};
	cChild = new []{assetdiaryora.Columns["idworkpackage"]};
	Relations.Add(new DataRelation("FK_assetdiaryora_workpackage_idworkpackage",cPar,cChild,false));

	cPar = new []{sal_alias1.Columns["idsal"]};
	cChild = new []{assetdiaryora.Columns["idsal"]};
	Relations.Add(new DataRelation("FK_assetdiaryora_sal_alias1_idsal",cPar,cChild,false));

	cPar = new []{assetdiary.Columns["idassetdiary"]};
	cChild = new []{assetdiaryora.Columns["idassetdiary"]};
	Relations.Add(new DataRelation("FK_assetdiaryora_assetdiary_idassetdiary",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{assetdiary.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_assetdiary_registry_idreg",cPar,cChild,false));

	cPar = new []{asset.Columns["idasset"]};
	cChild = new []{assetdiary.Columns["idasset"]};
	Relations.Add(new DataRelation("FK_assetdiary_asset_idasset",cPar,cChild,false));

	#endregion

}
}
}
