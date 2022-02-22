
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
[System.Xml.Serialization.XmlRoot("dsmeta_sal_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_sal_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontattivitaprogetto 		=> (MetaTable)Tables["rendicontattivitaprogetto"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettotipocosto 		=> (MetaTable)Tables["progettotipocosto"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pettycash 		=> (MetaTable)Tables["pettycash"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable expense 		=> (MetaTable)Tables["expense"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable contrattokind 		=> (MetaTable)Tables["contrattokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettocosto 		=> (MetaTable)Tables["progettocosto"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable salprogettocosto 		=> (MetaTable)Tables["salprogettocosto"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontattivitaprogettoora 		=> (MetaTable)Tables["rendicontattivitaprogettoora"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable salrendicontattivitaprogettoora 		=> (MetaTable)Tables["salrendicontattivitaprogettoora"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sal_alias1 		=> (MetaTable)Tables["sal_alias1"];

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

	//////////////////// PROGETTOTIPOCOSTO /////////////////////////////////
	var tprogettotipocosto= new MetaTable("progettotipocosto");
	tprogettotipocosto.defineColumn("idprogetto", typeof(int),false);
	tprogettotipocosto.defineColumn("idprogettotipocosto", typeof(int),false);
	tprogettotipocosto.defineColumn("title", typeof(string));
	Tables.Add(tprogettotipocosto);
	tprogettotipocosto.defineKey("idprogetto", "idprogettotipocosto");

	//////////////////// PETTYCASH /////////////////////////////////
	var tpettycash= new MetaTable("pettycash");
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
	tcontrattokind.defineColumn("idcontrattokind", typeof(int),false);
	tcontrattokind.defineColumn("title", typeof(string),false);
	Tables.Add(tcontrattokind);
	tcontrattokind.defineKey("idcontrattokind");

	//////////////////// PROGETTOCOSTO /////////////////////////////////
	var tprogettocosto= new MetaTable("progettocosto");
	tprogettocosto.defineColumn("amount", typeof(decimal));
	tprogettocosto.defineColumn("ct", typeof(DateTime));
	tprogettocosto.defineColumn("cu", typeof(string));
	tprogettocosto.defineColumn("doc", typeof(string));
	tprogettocosto.defineColumn("docdate", typeof(DateTime));
	tprogettocosto.defineColumn("idcontrattokind", typeof(int));
	tprogettocosto.defineColumn("idexp", typeof(int));
	tprogettocosto.defineColumn("idpettycash", typeof(int));
	tprogettocosto.defineColumn("idprogetto", typeof(int),false);
	tprogettocosto.defineColumn("idprogettocosto", typeof(int),false);
	tprogettocosto.defineColumn("idprogettotipocosto", typeof(int),false);
	tprogettocosto.defineColumn("idrelated", typeof(string));
	tprogettocosto.defineColumn("idrendicontattivitaprogetto", typeof(int));
	tprogettocosto.defineColumn("idsal", typeof(int));
	tprogettocosto.defineColumn("idworkpackage", typeof(int),false);
	tprogettocosto.defineColumn("lt", typeof(DateTime));
	tprogettocosto.defineColumn("lu", typeof(string));
	tprogettocosto.defineColumn("noperation", typeof(int));
	tprogettocosto.defineColumn("yoperation", typeof(int));
	tprogettocosto.defineColumn("!idcontrattokind_contrattokind_title", typeof(string));
	tprogettocosto.defineColumn("!idexp_expense_description", typeof(string));
	tprogettocosto.defineColumn("!idexp_expense_ymov", typeof(int));
	tprogettocosto.defineColumn("!idexp_expense_nmov", typeof(int));
	tprogettocosto.defineColumn("!idpettycash_pettycash_description", typeof(string));
	tprogettocosto.defineColumn("!idpettycash_pettycash_pettycode", typeof(string));
	tprogettocosto.defineColumn("!idprogettotipocosto_progettotipocosto_title", typeof(string));
	tprogettocosto.defineColumn("!idrendicontattivitaprogetto_rendicontattivitaprogetto_description", typeof(string));
	tprogettocosto.defineColumn("!idsal_sal_start", typeof(DateTime));
	tprogettocosto.defineColumn("!idsal_sal_stop", typeof(DateTime));
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
	Tables.Add(tsalprogettocosto);
	tsalprogettocosto.defineKey("idprogetto", "idprogettocosto", "idsal");

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
	trendicontattivitaprogettoora.defineColumn("!idsal_sal_start", typeof(DateTime));
	trendicontattivitaprogettoora.defineColumn("!idsal_sal_stop", typeof(DateTime));
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
	Tables.Add(tsalrendicontattivitaprogettoora);
	tsalrendicontattivitaprogettoora.defineKey("idprogetto", "idrendicontattivitaprogettoora", "idsal");

	//////////////////// SAL_ALIAS1 /////////////////////////////////
	var tsal_alias1= new MetaTable("sal_alias1");
	tsal_alias1.defineColumn("idprogetto", typeof(int),false);
	tsal_alias1.defineColumn("idsal", typeof(int),false);
	tsal_alias1.defineColumn("start", typeof(DateTime));
	tsal_alias1.defineColumn("stop", typeof(DateTime));
	tsal_alias1.ExtendedProperties["TableForReading"]="sal";
	Tables.Add(tsal_alias1);
	tsal_alias1.defineKey("idprogetto", "idsal");

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

	//////////////////// SALASSETDIARYORA /////////////////////////////////
	var tsalassetdiaryora= new MetaTable("salassetdiaryora");
	tsalassetdiaryora.defineColumn("ct", typeof(DateTime),false);
	tsalassetdiaryora.defineColumn("cu", typeof(string),false);
	tsalassetdiaryora.defineColumn("idassetdiaryora", typeof(int),false);
	tsalassetdiaryora.defineColumn("idprogetto", typeof(int),false);
	tsalassetdiaryora.defineColumn("idsal", typeof(int),false);
	tsalassetdiaryora.defineColumn("lt", typeof(DateTime),false);
	tsalassetdiaryora.defineColumn("lu", typeof(string),false);
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
	var cChild = new []{salprogettocosto.Columns["idprogetto"], salprogettocosto.Columns["idsal"]};
	Relations.Add(new DataRelation("FK_salprogettocosto_sal_idprogetto-idsal",cPar,cChild,false));

	cPar = new []{progettocosto.Columns["idprogettocosto"]};
	cChild = new []{salprogettocosto.Columns["idprogettocosto"]};
	Relations.Add(new DataRelation("FK_salprogettocosto_progettocosto_idprogettocosto",cPar,cChild,false));

	cPar = new []{sal_alias1.Columns["idsal"]};
	cChild = new []{progettocosto.Columns["idsal"]};
	Relations.Add(new DataRelation("FK_progettocosto_sal_alias1_idsal",cPar,cChild,false));

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

	cPar = new []{sal.Columns["idprogetto"], sal.Columns["idsal"]};
	cChild = new []{salrendicontattivitaprogettoora.Columns["idprogetto"], salrendicontattivitaprogettoora.Columns["idsal"]};
	Relations.Add(new DataRelation("FK_salrendicontattivitaprogettoora_sal_idprogetto-idsal",cPar,cChild,false));

	cPar = new []{rendicontattivitaprogettoora.Columns["idrendicontattivitaprogettoora"]};
	cChild = new []{salrendicontattivitaprogettoora.Columns["idrendicontattivitaprogettoora"]};
	Relations.Add(new DataRelation("FK_salrendicontattivitaprogettoora_rendicontattivitaprogettoora_idrendicontattivitaprogettoora",cPar,cChild,false));

	cPar = new []{sal_alias1.Columns["idsal"]};
	cChild = new []{rendicontattivitaprogettoora.Columns["idsal"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogettoora_sal_alias1_idsal",cPar,cChild,false));

	cPar = new []{sal.Columns["idprogetto"], sal.Columns["idsal"]};
	cChild = new []{salassetdiaryora.Columns["idprogetto"], salassetdiaryora.Columns["idsal"]};
	Relations.Add(new DataRelation("FK_salassetdiaryora_sal_idprogetto-idsal",cPar,cChild,false));

	cPar = new []{assetdiaryora.Columns["idassetdiaryora"]};
	cChild = new []{salassetdiaryora.Columns["idassetdiaryora"]};
	Relations.Add(new DataRelation("FK_salassetdiaryora_assetdiaryora_idassetdiaryora",cPar,cChild,false));

	cPar = new []{sal_alias1.Columns["idsal"]};
	cChild = new []{assetdiaryora.Columns["idsal"]};
	Relations.Add(new DataRelation("FK_assetdiaryora_sal_alias1_idsal",cPar,cChild,false));

	#endregion

}
}
}
