
/*
Easy
Copyright (C) 2024 UniversitÓ degli Studi di Catania (www.unict.it)
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
[System.Xml.Serialization.XmlRoot("dsmeta_progettobudget_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_progettobudget_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sal_alias1 		=> (MetaTable)Tables["sal_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontattivitaprogetto_alias2 		=> (MetaTable)Tables["rendicontattivitaprogetto_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable entrydetail 		=> (MetaTable)Tables["entrydetail"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettotipocosto_alias2 		=> (MetaTable)Tables["progettotipocosto_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable position_alias1 		=> (MetaTable)Tables["position_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable income 		=> (MetaTable)Tables["income"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettoricavo 		=> (MetaTable)Tables["progettoricavo"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable mese 		=> (MetaTable)Tables["mese"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable salprogettoassetworkpackage 		=> (MetaTable)Tables["salprogettoassetworkpackage"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable salprogettoassetworkpackagemese 		=> (MetaTable)Tables["salprogettoassetworkpackagemese"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sal 		=> (MetaTable)Tables["sal"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getregistrydocentiamministrativi 		=> (MetaTable)Tables["getregistrydocentiamministrativi"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontattivitaprogetto_alias1 		=> (MetaTable)Tables["rendicontattivitaprogetto_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettotipocosto_alias1 		=> (MetaTable)Tables["progettotipocosto_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable position 		=> (MetaTable)Tables["position"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pettycash 		=> (MetaTable)Tables["pettycash"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable expense 		=> (MetaTable)Tables["expense"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetdiary 		=> (MetaTable)Tables["assetdiary"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetdiaryora 		=> (MetaTable)Tables["assetdiaryora"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettocosto 		=> (MetaTable)Tables["progettocosto"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable upb 		=> (MetaTable)Tables["upb"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accmotive 		=> (MetaTable)Tables["accmotive"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettobudgetvariazione 		=> (MetaTable)Tables["progettobudgetvariazione"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettotipocosto 		=> (MetaTable)Tables["progettotipocosto"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable workpackagesegview 		=> (MetaTable)Tables["workpackagesegview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettobudget 		=> (MetaTable)Tables["progettobudget"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_progettobudget_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_progettobudget_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_progettobudget_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_progettobudget_seg.xsd";

	#region create DataTables
	//////////////////// SAL_ALIAS1 /////////////////////////////////
	var tsal_alias1= new MetaTable("sal_alias1");
	tsal_alias1.defineColumn("idprogetto", typeof(int),false);
	tsal_alias1.defineColumn("idsal", typeof(int),false);
	tsal_alias1.defineColumn("start", typeof(DateTime));
	tsal_alias1.defineColumn("stop", typeof(DateTime));
	tsal_alias1.ExtendedProperties["TableForReading"]="sal";
	Tables.Add(tsal_alias1);
	tsal_alias1.defineKey("idprogetto", "idsal");

	//////////////////// RENDICONTATTIVITAPROGETTO_ALIAS2 /////////////////////////////////
	var trendicontattivitaprogetto_alias2= new MetaTable("rendicontattivitaprogetto_alias2");
	trendicontattivitaprogetto_alias2.defineColumn("description", typeof(string));
	trendicontattivitaprogetto_alias2.defineColumn("idprogetto", typeof(int),false);
	trendicontattivitaprogetto_alias2.defineColumn("idreg", typeof(int),false);
	trendicontattivitaprogetto_alias2.defineColumn("idrendicontattivitaprogetto", typeof(int),false);
	trendicontattivitaprogetto_alias2.defineColumn("idworkpackage", typeof(int),false);
	trendicontattivitaprogetto_alias2.ExtendedProperties["TableForReading"]="rendicontattivitaprogetto";
	Tables.Add(trendicontattivitaprogetto_alias2);
	trendicontattivitaprogetto_alias2.defineKey("idprogetto", "idreg", "idrendicontattivitaprogetto", "idworkpackage");

	//////////////////// ENTRYDETAIL /////////////////////////////////
	var tentrydetail= new MetaTable("entrydetail");
	tentrydetail.defineColumn("description", typeof(string));
	tentrydetail.defineColumn("idrelated", typeof(string));
	tentrydetail.defineColumn("ndetail", typeof(int),false);
	tentrydetail.defineColumn("nentry", typeof(int),false);
	tentrydetail.defineColumn("yentry", typeof(int),false);
	Tables.Add(tentrydetail);
	tentrydetail.defineKey("ndetail", "nentry", "yentry");

	//////////////////// PROGETTOTIPOCOSTO_ALIAS2 /////////////////////////////////
	var tprogettotipocosto_alias2= new MetaTable("progettotipocosto_alias2");
	tprogettotipocosto_alias2.defineColumn("idprogetto", typeof(int),false);
	tprogettotipocosto_alias2.defineColumn("idprogettotipocosto", typeof(int),false);
	tprogettotipocosto_alias2.defineColumn("title", typeof(string));
	tprogettotipocosto_alias2.ExtendedProperties["TableForReading"]="progettotipocosto";
	Tables.Add(tprogettotipocosto_alias2);
	tprogettotipocosto_alias2.defineKey("idprogetto", "idprogettotipocosto");

	//////////////////// POSITION_ALIAS1 /////////////////////////////////
	var tposition_alias1= new MetaTable("position_alias1");
	tposition_alias1.defineColumn("active", typeof(string));
	tposition_alias1.defineColumn("idposition", typeof(int),false);
	tposition_alias1.defineColumn("title", typeof(string));
	tposition_alias1.ExtendedProperties["TableForReading"]="position";
	Tables.Add(tposition_alias1);
	tposition_alias1.defineKey("idposition");

	//////////////////// INCOME /////////////////////////////////
	var tincome= new MetaTable("income");
	tincome.defineColumn("description", typeof(string),false);
	tincome.defineColumn("idinc", typeof(int),false);
	tincome.defineColumn("nmov", typeof(int),false);
	tincome.defineColumn("ymov", typeof(int),false);
	Tables.Add(tincome);
	tincome.defineKey("idinc");

	//////////////////// PROGETTORICAVO /////////////////////////////////
	var tprogettoricavo= new MetaTable("progettoricavo");
	tprogettoricavo.defineColumn("amount", typeof(decimal));
	tprogettoricavo.defineColumn("ct", typeof(DateTime),false);
	tprogettoricavo.defineColumn("cu", typeof(string),false);
	tprogettoricavo.defineColumn("doc", typeof(string));
	tprogettoricavo.defineColumn("docdate", typeof(DateTime));
	tprogettoricavo.defineColumn("idinc", typeof(int));
	tprogettoricavo.defineColumn("idposition", typeof(int));
	tprogettoricavo.defineColumn("idprogetto", typeof(int),false);
	tprogettoricavo.defineColumn("idprogettoricavo", typeof(int),false);
	tprogettoricavo.defineColumn("idprogettotipocosto", typeof(int));
	tprogettoricavo.defineColumn("idrelated", typeof(string));
	tprogettoricavo.defineColumn("idrendicontattivitaprogetto", typeof(int));
	tprogettoricavo.defineColumn("idsal", typeof(int));
	tprogettoricavo.defineColumn("idworkpackage", typeof(int));
	tprogettoricavo.defineColumn("lt", typeof(DateTime),false);
	tprogettoricavo.defineColumn("lu", typeof(string),false);
	tprogettoricavo.defineColumn("!idinc_income_description", typeof(string));
	tprogettoricavo.defineColumn("!idinc_income_ymov", typeof(int));
	tprogettoricavo.defineColumn("!idinc_income_nmov", typeof(int));
	tprogettoricavo.defineColumn("!idposition_position_title", typeof(string));
	tprogettoricavo.defineColumn("!idprogettotipocosto_progettotipocosto_title", typeof(string));
	tprogettoricavo.defineColumn("!idrelated_entrydetail_description", typeof(string));
	tprogettoricavo.defineColumn("!idrendicontattivitaprogetto_rendicontattivitaprogetto_description", typeof(string));
	tprogettoricavo.defineColumn("!idrendicontattivitaprogetto_rendicontattivitaprogetto_idreg_surname", typeof(string));
	tprogettoricavo.defineColumn("!idrendicontattivitaprogetto_rendicontattivitaprogetto_idreg_forename", typeof(string));
	tprogettoricavo.defineColumn("!idrendicontattivitaprogetto_rendicontattivitaprogetto_idreg_extmatricula", typeof(string));
	tprogettoricavo.defineColumn("!idrendicontattivitaprogetto_rendicontattivitaprogetto_idreg_contratto", typeof(string));
	tprogettoricavo.defineColumn("!idsal_sal_start", typeof(DateTime));
	tprogettoricavo.defineColumn("!idsal_sal_stop", typeof(DateTime));
	tprogettoricavo.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tprogettoricavo);
	tprogettoricavo.defineKey("idprogetto", "idprogettoricavo");

	//////////////////// MESE /////////////////////////////////
	var tmese= new MetaTable("mese");
	tmese.defineColumn("idmese", typeof(int),false);
	tmese.defineColumn("title", typeof(string));
	Tables.Add(tmese);
	tmese.defineKey("idmese");

	//////////////////// SALPROGETTOASSETWORKPACKAGE /////////////////////////////////
	var tsalprogettoassetworkpackage= new MetaTable("salprogettoassetworkpackage");
	tsalprogettoassetworkpackage.defineColumn("idasset", typeof(int),false);
	tsalprogettoassetworkpackage.defineColumn("idpiece", typeof(int),false);
	tsalprogettoassetworkpackage.defineColumn("idprogetto", typeof(int),false);
	tsalprogettoassetworkpackage.defineColumn("idsal", typeof(int),false);
	tsalprogettoassetworkpackage.defineColumn("idsalprogettoassetworkpackage", typeof(int),false);
	tsalprogettoassetworkpackage.defineColumn("percentuale", typeof(decimal));
	Tables.Add(tsalprogettoassetworkpackage);
	tsalprogettoassetworkpackage.defineKey("idasset", "idpiece", "idprogetto", "idsal", "idsalprogettoassetworkpackage");

	//////////////////// SALPROGETTOASSETWORKPACKAGEMESE /////////////////////////////////
	var tsalprogettoassetworkpackagemese= new MetaTable("salprogettoassetworkpackagemese");
	tsalprogettoassetworkpackagemese.defineColumn("amount", typeof(decimal));
	tsalprogettoassetworkpackagemese.defineColumn("idmese", typeof(int));
	tsalprogettoassetworkpackagemese.defineColumn("idprogetto", typeof(int),false);
	tsalprogettoassetworkpackagemese.defineColumn("idsal", typeof(int),false);
	tsalprogettoassetworkpackagemese.defineColumn("idsalprogettoassetworkpackage", typeof(int),false);
	tsalprogettoassetworkpackagemese.defineColumn("idsalprogettoassetworkpackagemese", typeof(int),false);
	tsalprogettoassetworkpackagemese.defineColumn("year", typeof(int));
	Tables.Add(tsalprogettoassetworkpackagemese);
	tsalprogettoassetworkpackagemese.defineKey("idprogetto", "idsal", "idsalprogettoassetworkpackage", "idsalprogettoassetworkpackagemese");

	//////////////////// SAL /////////////////////////////////
	var tsal= new MetaTable("sal");
	tsal.defineColumn("idprogetto", typeof(int),false);
	tsal.defineColumn("idsal", typeof(int),false);
	tsal.defineColumn("start", typeof(DateTime));
	tsal.defineColumn("stop", typeof(DateTime));
	Tables.Add(tsal);
	tsal.defineKey("idprogetto", "idsal");

	//////////////////// GETREGISTRYDOCENTIAMMINISTRATIVI /////////////////////////////////
	var tgetregistrydocentiamministrativi= new MetaTable("getregistrydocentiamministrativi");
	tgetregistrydocentiamministrativi.defineColumn("contratto", typeof(string));
	tgetregistrydocentiamministrativi.defineColumn("extmatricula", typeof(string));
	tgetregistrydocentiamministrativi.defineColumn("forename", typeof(string));
	tgetregistrydocentiamministrativi.defineColumn("idreg", typeof(int),false);
	tgetregistrydocentiamministrativi.defineColumn("surname", typeof(string));
	Tables.Add(tgetregistrydocentiamministrativi);
	tgetregistrydocentiamministrativi.defineKey("idreg");

	//////////////////// RENDICONTATTIVITAPROGETTO_ALIAS1 /////////////////////////////////
	var trendicontattivitaprogetto_alias1= new MetaTable("rendicontattivitaprogetto_alias1");
	trendicontattivitaprogetto_alias1.defineColumn("description", typeof(string));
	trendicontattivitaprogetto_alias1.defineColumn("idprogetto", typeof(int),false);
	trendicontattivitaprogetto_alias1.defineColumn("idreg", typeof(int),false);
	trendicontattivitaprogetto_alias1.defineColumn("idrendicontattivitaprogetto", typeof(int),false);
	trendicontattivitaprogetto_alias1.defineColumn("idworkpackage", typeof(int),false);
	trendicontattivitaprogetto_alias1.ExtendedProperties["TableForReading"]="rendicontattivitaprogetto";
	Tables.Add(trendicontattivitaprogetto_alias1);
	trendicontattivitaprogetto_alias1.defineKey("idprogetto", "idreg", "idrendicontattivitaprogetto", "idworkpackage");

	//////////////////// PROGETTOTIPOCOSTO_ALIAS1 /////////////////////////////////
	var tprogettotipocosto_alias1= new MetaTable("progettotipocosto_alias1");
	tprogettotipocosto_alias1.defineColumn("idprogetto", typeof(int),false);
	tprogettotipocosto_alias1.defineColumn("idprogettotipocosto", typeof(int),false);
	tprogettotipocosto_alias1.defineColumn("title", typeof(string));
	tprogettotipocosto_alias1.ExtendedProperties["TableForReading"]="progettotipocosto";
	Tables.Add(tprogettotipocosto_alias1);
	tprogettotipocosto_alias1.defineKey("idprogetto", "idprogettotipocosto");

	//////////////////// POSITION /////////////////////////////////
	var tposition= new MetaTable("position");
	tposition.defineColumn("active", typeof(string));
	tposition.defineColumn("idposition", typeof(int),false);
	tposition.defineColumn("title", typeof(string));
	Tables.Add(tposition);
	tposition.defineKey("idposition");

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

	//////////////////// ASSETDIARY /////////////////////////////////
	var tassetdiary= new MetaTable("assetdiary");
	tassetdiary.defineColumn("idassetdiary", typeof(int),false);
	tassetdiary.defineColumn("idpiece", typeof(int));
	tassetdiary.defineColumn("idreg", typeof(int),false);
	tassetdiary.defineColumn("idworkpackage", typeof(int),false);
	tassetdiary.defineColumn("orepreventivate", typeof(int));
	Tables.Add(tassetdiary);
	tassetdiary.defineKey("idassetdiary", "idworkpackage");

	//////////////////// ASSETDIARYORA /////////////////////////////////
	var tassetdiaryora= new MetaTable("assetdiaryora");
	tassetdiaryora.defineColumn("idassetdiary", typeof(int),false);
	tassetdiaryora.defineColumn("idassetdiaryora", typeof(int),false);
	tassetdiaryora.defineColumn("idworkpackage", typeof(int),false);
	tassetdiaryora.defineColumn("start", typeof(DateTime));
	tassetdiaryora.defineColumn("stop", typeof(DateTime));
	Tables.Add(tassetdiaryora);
	tassetdiaryora.defineKey("idassetdiary", "idassetdiaryora", "idworkpackage");

	//////////////////// PROGETTOCOSTO /////////////////////////////////
	var tprogettocosto= new MetaTable("progettocosto");
	tprogettocosto.defineColumn("amount", typeof(decimal));
	tprogettocosto.defineColumn("ct", typeof(DateTime));
	tprogettocosto.defineColumn("cu", typeof(string));
	tprogettocosto.defineColumn("doc", typeof(string));
	tprogettocosto.defineColumn("docdate", typeof(DateTime));
	tprogettocosto.defineColumn("idassetdiaryora", typeof(int));
	tprogettocosto.defineColumn("idexp", typeof(int));
	tprogettocosto.defineColumn("idpettycash", typeof(int));
	tprogettocosto.defineColumn("idposition", typeof(int));
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
	tprogettocosto.defineColumn("!idassetdiaryora_assetdiaryora_start", typeof(DateTime));
	tprogettocosto.defineColumn("!idassetdiaryora_assetdiaryora_stop", typeof(DateTime));
	tprogettocosto.defineColumn("!idassetdiaryora_assetdiaryora_idassetdiary_idpiece", typeof(int));
	tprogettocosto.defineColumn("!idassetdiaryora_assetdiaryora_idassetdiary_idreg", typeof(int));
	tprogettocosto.defineColumn("!idassetdiaryora_assetdiaryora_idassetdiary_orepreventivate", typeof(int));
	tprogettocosto.defineColumn("!idexp_expense_description", typeof(string));
	tprogettocosto.defineColumn("!idexp_expense_ymov", typeof(int));
	tprogettocosto.defineColumn("!idexp_expense_nmov", typeof(int));
	tprogettocosto.defineColumn("!idpettycash_pettycash_description", typeof(string));
	tprogettocosto.defineColumn("!idpettycash_pettycash_pettycode", typeof(string));
	tprogettocosto.defineColumn("!idposition_position_title", typeof(string));
	tprogettocosto.defineColumn("!idprogettotipocosto_progettotipocosto_title", typeof(string));
	tprogettocosto.defineColumn("!idrendicontattivitaprogetto_rendicontattivitaprogetto_description", typeof(string));
	tprogettocosto.defineColumn("!idrendicontattivitaprogetto_rendicontattivitaprogetto_idreg_surname", typeof(string));
	tprogettocosto.defineColumn("!idrendicontattivitaprogetto_rendicontattivitaprogetto_idreg_forename", typeof(string));
	tprogettocosto.defineColumn("!idrendicontattivitaprogetto_rendicontattivitaprogetto_idreg_extmatricula", typeof(string));
	tprogettocosto.defineColumn("!idrendicontattivitaprogetto_rendicontattivitaprogetto_idreg_contratto", typeof(string));
	tprogettocosto.defineColumn("!idsal_sal_start", typeof(DateTime));
	tprogettocosto.defineColumn("!idsal_sal_stop", typeof(DateTime));
	tprogettocosto.defineColumn("!idsalprogettoassetworkpackagemese_salprogettoassetworkpackagemese_year", typeof(int));
	tprogettocosto.defineColumn("!idsalprogettoassetworkpackagemese_salprogettoassetworkpackagemese_amount", typeof(decimal));
	tprogettocosto.defineColumn("!idsalprogettoassetworkpackagemese_salprogettoassetworkpackagemese_idsalprogettoassetworkpackage_idpiece", typeof(int));
	tprogettocosto.defineColumn("!idsalprogettoassetworkpackagemese_salprogettoassetworkpackagemese_idsalprogettoassetworkpackage_percentuale", typeof(decimal));
	tprogettocosto.defineColumn("!idsalprogettoassetworkpackagemese_salprogettoassetworkpackagemese_idmese_title", typeof(string));
	tprogettocosto.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tprogettocosto);
	tprogettocosto.defineKey("idprogetto", "idprogettocosto", "idprogettotipocosto", "idworkpackage");

	//////////////////// UPB /////////////////////////////////
	var tupb= new MetaTable("upb");
	tupb.defineColumn("active", typeof(string));
	tupb.defineColumn("idupb", typeof(string),false);
	tupb.defineColumn("title", typeof(string),false);
	Tables.Add(tupb);
	tupb.defineKey("idupb");

	//////////////////// ACCMOTIVE /////////////////////////////////
	var taccmotive= new MetaTable("accmotive");
	taccmotive.defineColumn("active", typeof(string));
	taccmotive.defineColumn("codemotive", typeof(string),false);
	taccmotive.defineColumn("idaccmotive", typeof(string),false);
	taccmotive.defineColumn("title", typeof(string),false);
	Tables.Add(taccmotive);
	taccmotive.defineKey("idaccmotive");

	//////////////////// PROGETTOBUDGETVARIAZIONE /////////////////////////////////
	var tprogettobudgetvariazione= new MetaTable("progettobudgetvariazione");
	tprogettobudgetvariazione.defineColumn("ct", typeof(DateTime));
	tprogettobudgetvariazione.defineColumn("cu", typeof(string));
	tprogettobudgetvariazione.defineColumn("data", typeof(DateTime));
	tprogettobudgetvariazione.defineColumn("idaccmotive", typeof(string));
	tprogettobudgetvariazione.defineColumn("idprogetto", typeof(int),false);
	tprogettobudgetvariazione.defineColumn("idprogettobudget", typeof(int),false);
	tprogettobudgetvariazione.defineColumn("idprogettobudgetvariazione", typeof(int),false);
	tprogettobudgetvariazione.defineColumn("idupb", typeof(string));
	tprogettobudgetvariazione.defineColumn("lt", typeof(DateTime));
	tprogettobudgetvariazione.defineColumn("lu", typeof(string));
	tprogettobudgetvariazione.defineColumn("newamount", typeof(decimal));
	tprogettobudgetvariazione.defineColumn("!idaccmotive_accmotive_codemotive", typeof(string));
	tprogettobudgetvariazione.defineColumn("!idaccmotive_accmotive_title", typeof(string));
	tprogettobudgetvariazione.defineColumn("!idupb_upb_title", typeof(string));
	tprogettobudgetvariazione.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tprogettobudgetvariazione);
	tprogettobudgetvariazione.defineKey("idprogetto", "idprogettobudget", "idprogettobudgetvariazione");

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

	//////////////////// PROGETTOBUDGET /////////////////////////////////
	var tprogettobudget= new MetaTable("progettobudget");
	tprogettobudget.defineColumn("!budgetvariazione", typeof(decimal));
	tprogettobudget.defineColumn("!ricaviincassati", typeof(decimal));
	tprogettobudget.defineColumn("!ricavinonincassati", typeof(decimal));
	tprogettobudget.defineColumn("!spese", typeof(decimal));
	tprogettobudget.defineColumn("budget", typeof(decimal));
	tprogettobudget.defineColumn("ct", typeof(DateTime));
	tprogettobudget.defineColumn("cu", typeof(string));
	tprogettobudget.defineColumn("idprogetto", typeof(int),false);
	tprogettobudget.defineColumn("idprogettobudget", typeof(int),false);
	tprogettobudget.defineColumn("idprogettotipocosto", typeof(int),false);
	tprogettobudget.defineColumn("idworkpackage", typeof(int),false);
	tprogettobudget.defineColumn("lt", typeof(DateTime));
	tprogettobudget.defineColumn("lu", typeof(string));
	tprogettobudget.defineColumn("sortcode", typeof(int));
	Tables.Add(tprogettobudget);
	tprogettobudget.defineKey("idprogetto", "idprogettobudget", "idprogettotipocosto", "idworkpackage");

	#endregion


	#region DataRelation creation
	var cPar = new []{progettobudget.Columns["idprogetto"], progettobudget.Columns["idprogettotipocosto"], progettobudget.Columns["idworkpackage"]};
	var cChild = new []{progettoricavo.Columns["idprogetto"], progettoricavo.Columns["idprogettotipocosto"], progettoricavo.Columns["idworkpackage"]};
	Relations.Add(new DataRelation("FK_progettoricavo_progettobudget_idprogetto-idprogettotipocosto-idworkpackage",cPar,cChild,false));

	cPar = new []{sal_alias1.Columns["idsal"]};
	cChild = new []{progettoricavo.Columns["idsal"]};
	Relations.Add(new DataRelation("FK_progettoricavo_sal_alias1_idsal",cPar,cChild,false));

	cPar = new []{rendicontattivitaprogetto_alias2.Columns["idrendicontattivitaprogetto"]};
	cChild = new []{progettoricavo.Columns["idrendicontattivitaprogetto"]};
	Relations.Add(new DataRelation("FK_progettoricavo_rendicontattivitaprogetto_alias2_idrendicontattivitaprogetto",cPar,cChild,false));

	cPar = new []{getregistrydocentiamministrativi.Columns["idreg"]};
	cChild = new []{rendicontattivitaprogetto_alias2.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogetto_alias2_getregistrydocentiamministrativi_idreg",cPar,cChild,false));

	cPar = new []{entrydetail.Columns["idrelated"]};
	cChild = new []{progettoricavo.Columns["idrelated"]};
	Relations.Add(new DataRelation("FK_progettoricavo_entrydetail_idrelated",cPar,cChild,false));

	cPar = new []{progettotipocosto_alias2.Columns["idprogettotipocosto"]};
	cChild = new []{progettoricavo.Columns["idprogettotipocosto"]};
	Relations.Add(new DataRelation("FK_progettoricavo_progettotipocosto_alias2_idprogettotipocosto",cPar,cChild,false));

	cPar = new []{position_alias1.Columns["idposition"]};
	cChild = new []{progettoricavo.Columns["idposition"]};
	Relations.Add(new DataRelation("FK_progettoricavo_position_alias1_idposition",cPar,cChild,false));

	cPar = new []{income.Columns["idinc"]};
	cChild = new []{progettoricavo.Columns["idinc"]};
	Relations.Add(new DataRelation("FK_progettoricavo_income_idinc",cPar,cChild,false));

	cPar = new []{progettobudget.Columns["idprogetto"], progettobudget.Columns["idprogettotipocosto"], progettobudget.Columns["idworkpackage"]};
	cChild = new []{progettocosto.Columns["idprogetto"], progettocosto.Columns["idprogettotipocosto"], progettocosto.Columns["idworkpackage"]};
	Relations.Add(new DataRelation("FK_progettocosto_progettobudget_idprogetto-idprogettotipocosto-idworkpackage",cPar,cChild,false));

	cPar = new []{salprogettoassetworkpackagemese.Columns["idsalprogettoassetworkpackagemese"]};
	cChild = new []{progettocosto.Columns["idsalprogettoassetworkpackagemese"]};
	Relations.Add(new DataRelation("FK_progettocosto_salprogettoassetworkpackagemese_idsalprogettoassetworkpackagemese",cPar,cChild,false));

	cPar = new []{mese.Columns["idmese"]};
	cChild = new []{salprogettoassetworkpackagemese.Columns["idmese"]};
	Relations.Add(new DataRelation("FK_salprogettoassetworkpackagemese_mese_idmese",cPar,cChild,false));

	cPar = new []{salprogettoassetworkpackage.Columns["idsalprogettoassetworkpackage"]};
	cChild = new []{salprogettoassetworkpackagemese.Columns["idsalprogettoassetworkpackage"]};
	Relations.Add(new DataRelation("FK_salprogettoassetworkpackagemese_salprogettoassetworkpackage_idsalprogettoassetworkpackage",cPar,cChild,false));

	cPar = new []{sal.Columns["idsal"]};
	cChild = new []{progettocosto.Columns["idsal"]};
	Relations.Add(new DataRelation("FK_progettocosto_sal_idsal",cPar,cChild,false));

	cPar = new []{rendicontattivitaprogetto_alias1.Columns["idrendicontattivitaprogetto"]};
	cChild = new []{progettocosto.Columns["idrendicontattivitaprogetto"]};
	Relations.Add(new DataRelation("FK_progettocosto_rendicontattivitaprogetto_alias1_idrendicontattivitaprogetto",cPar,cChild,false));

	cPar = new []{getregistrydocentiamministrativi.Columns["idreg"]};
	cChild = new []{rendicontattivitaprogetto_alias1.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogetto_alias1_getregistrydocentiamministrativi_idreg",cPar,cChild,false));

	cPar = new []{progettotipocosto_alias1.Columns["idprogettotipocosto"]};
	cChild = new []{progettocosto.Columns["idprogettotipocosto"]};
	Relations.Add(new DataRelation("FK_progettocosto_progettotipocosto_alias1_idprogettotipocosto",cPar,cChild,false));

	cPar = new []{position.Columns["idposition"]};
	cChild = new []{progettocosto.Columns["idposition"]};
	Relations.Add(new DataRelation("FK_progettocosto_position_idposition",cPar,cChild,false));

	cPar = new []{pettycash.Columns["idpettycash"]};
	cChild = new []{progettocosto.Columns["idpettycash"]};
	Relations.Add(new DataRelation("FK_progettocosto_pettycash_idpettycash",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{progettocosto.Columns["idexp"]};
	Relations.Add(new DataRelation("FK_progettocosto_expense_idexp",cPar,cChild,false));

	cPar = new []{assetdiaryora.Columns["idassetdiaryora"]};
	cChild = new []{progettocosto.Columns["idassetdiaryora"]};
	Relations.Add(new DataRelation("FK_progettocosto_assetdiaryora_idassetdiaryora",cPar,cChild,false));

	cPar = new []{assetdiary.Columns["idassetdiary"]};
	cChild = new []{assetdiaryora.Columns["idassetdiary"]};
	Relations.Add(new DataRelation("FK_assetdiaryora_assetdiary_idassetdiary",cPar,cChild,false));

	cPar = new []{progettobudget.Columns["idprogetto"], progettobudget.Columns["idprogettobudget"]};
	cChild = new []{progettobudgetvariazione.Columns["idprogetto"], progettobudgetvariazione.Columns["idprogettobudget"]};
	Relations.Add(new DataRelation("FK_progettobudgetvariazione_progettobudget_idprogetto-idprogettobudget",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{progettobudgetvariazione.Columns["idupb"]};
	Relations.Add(new DataRelation("FK_progettobudgetvariazione_upb_idupb",cPar,cChild,false));

	cPar = new []{accmotive.Columns["idaccmotive"]};
	cChild = new []{progettobudgetvariazione.Columns["idaccmotive"]};
	Relations.Add(new DataRelation("FK_progettobudgetvariazione_accmotive_idaccmotive",cPar,cChild,false));

	cPar = new []{progettotipocosto.Columns["idprogettotipocosto"]};
	cChild = new []{progettobudget.Columns["idprogettotipocosto"]};
	Relations.Add(new DataRelation("FK_progettobudget_progettotipocosto_idprogettotipocosto",cPar,cChild,false));

	cPar = new []{workpackagesegview.Columns["idworkpackage"]};
	cChild = new []{progettobudget.Columns["idworkpackage"]};
	Relations.Add(new DataRelation("FK_progettobudget_workpackagesegview_idworkpackage",cPar,cChild,false));

	#endregion

}
}
}
