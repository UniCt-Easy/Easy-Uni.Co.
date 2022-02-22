
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
[System.Xml.Serialization.XmlRoot("dsmeta_progettocosto_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_progettocosto_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pettycashsegview 		=> (MetaTable)Tables["pettycashsegview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable expensesegview 		=> (MetaTable)Tables["expensesegview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable contrattokinddefaultview 		=> (MetaTable)Tables["contrattokinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable saldefaultview 		=> (MetaTable)Tables["saldefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable entrydetail 		=> (MetaTable)Tables["entrydetail"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontattivitaprogettosegview 		=> (MetaTable)Tables["rendicontattivitaprogettosegview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettotipocosto 		=> (MetaTable)Tables["progettotipocosto"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable workpackagesegview 		=> (MetaTable)Tables["workpackagesegview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettocosto 		=> (MetaTable)Tables["progettocosto"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_progettocosto_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_progettocosto_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_progettocosto_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_progettocosto_seg.xsd";

	#region create DataTables
	//////////////////// PETTYCASHSEGVIEW /////////////////////////////////
	var tpettycashsegview= new MetaTable("pettycashsegview");
	tpettycashsegview.defineColumn("dropdown_title", typeof(string),false);
	tpettycashsegview.defineColumn("idpettycash", typeof(int),false);
	tpettycashsegview.defineColumn("pettycash_active", typeof(string));
	Tables.Add(tpettycashsegview);
	tpettycashsegview.defineKey("idpettycash");

	//////////////////// EXPENSESEGVIEW /////////////////////////////////
	var texpensesegview= new MetaTable("expensesegview");
	texpensesegview.defineColumn("dropdown_title", typeof(string),false);
	texpensesegview.defineColumn("idclawback", typeof(int));
	texpensesegview.defineColumn("idexp", typeof(int),false);
	texpensesegview.defineColumn("idreg", typeof(int));
	Tables.Add(texpensesegview);
	texpensesegview.defineKey("idexp");

	//////////////////// CONTRATTOKINDDEFAULTVIEW /////////////////////////////////
	var tcontrattokinddefaultview= new MetaTable("contrattokinddefaultview");
	tcontrattokinddefaultview.defineColumn("contrattokind_active", typeof(string));
	tcontrattokinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tcontrattokinddefaultview.defineColumn("idcontrattokind", typeof(int),false);
	Tables.Add(tcontrattokinddefaultview);
	tcontrattokinddefaultview.defineKey("idcontrattokind");

	//////////////////// SALDEFAULTVIEW /////////////////////////////////
	var tsaldefaultview= new MetaTable("saldefaultview");
	tsaldefaultview.defineColumn("dropdown_title", typeof(string),false);
	tsaldefaultview.defineColumn("idprogetto", typeof(int),false);
	tsaldefaultview.defineColumn("idsal", typeof(int),false);
	tsaldefaultview.defineColumn("sal_budget", typeof(decimal));
	tsaldefaultview.defineColumn("sal_datablocco", typeof(DateTime));
	tsaldefaultview.defineColumn("sal_stop", typeof(DateTime));
	tsaldefaultview.defineColumn("start", typeof(DateTime));
	Tables.Add(tsaldefaultview);
	tsaldefaultview.defineKey("idsal");

	//////////////////// ENTRYDETAIL /////////////////////////////////
	var tentrydetail= new MetaTable("entrydetail");
	tentrydetail.defineColumn("description", typeof(string));
	tentrydetail.defineColumn("idrelated", typeof(string));
	tentrydetail.defineColumn("ndetail", typeof(int),false);
	tentrydetail.defineColumn("nentry", typeof(int),false);
	tentrydetail.defineColumn("yentry", typeof(int),false);
	Tables.Add(tentrydetail);
	tentrydetail.defineKey("ndetail", "nentry", "yentry");

	//////////////////// RENDICONTATTIVITAPROGETTOSEGVIEW /////////////////////////////////
	var trendicontattivitaprogettosegview= new MetaTable("rendicontattivitaprogettosegview");
	trendicontattivitaprogettosegview.defineColumn("dropdown_title", typeof(string),false);
	trendicontattivitaprogettosegview.defineColumn("idprogetto", typeof(int),false);
	trendicontattivitaprogettosegview.defineColumn("idrendicontattivitaprogetto", typeof(int),false);
	trendicontattivitaprogettosegview.defineColumn("idworkpackage", typeof(int),false);
	Tables.Add(trendicontattivitaprogettosegview);
	trendicontattivitaprogettosegview.defineKey("idrendicontattivitaprogetto");

	//////////////////// PROGETTOTIPOCOSTO /////////////////////////////////
	var tprogettotipocosto= new MetaTable("progettotipocosto");
	tprogettotipocosto.defineColumn("ammissibilita", typeof(decimal));
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
	tworkpackagesegview.defineKey("idworkpackage");

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
	Tables.Add(tprogettocosto);
	tprogettocosto.defineKey("idprogetto", "idprogettocosto", "idprogettotipocosto", "idworkpackage");

	#endregion


	#region DataRelation creation
	var cPar = new []{pettycashsegview.Columns["idpettycash"]};
	var cChild = new []{progettocosto.Columns["idpettycash"]};
	Relations.Add(new DataRelation("FK_progettocosto_pettycashsegview_idpettycash",cPar,cChild,false));

	cPar = new []{expensesegview.Columns["idexp"]};
	cChild = new []{progettocosto.Columns["idexp"]};
	Relations.Add(new DataRelation("FK_progettocosto_expensesegview_idexp",cPar,cChild,false));

	cPar = new []{contrattokinddefaultview.Columns["idcontrattokind"]};
	cChild = new []{progettocosto.Columns["idcontrattokind"]};
	Relations.Add(new DataRelation("FK_progettocosto_contrattokinddefaultview_idcontrattokind",cPar,cChild,false));

	cPar = new []{saldefaultview.Columns["idsal"]};
	cChild = new []{progettocosto.Columns["idsal"]};
	Relations.Add(new DataRelation("FK_progettocosto_saldefaultview_idsal",cPar,cChild,false));

	cPar = new []{entrydetail.Columns["idrelated"]};
	cChild = new []{progettocosto.Columns["idrelated"]};
	Relations.Add(new DataRelation("FK_progettocosto_entrydetail_idrelated",cPar,cChild,false));

	cPar = new []{rendicontattivitaprogettosegview.Columns["idrendicontattivitaprogetto"]};
	cChild = new []{progettocosto.Columns["idrendicontattivitaprogetto"]};
	Relations.Add(new DataRelation("FK_progettocosto_rendicontattivitaprogettosegview_idrendicontattivitaprogetto",cPar,cChild,false));

	cPar = new []{progettotipocosto.Columns["idprogettotipocosto"]};
	cChild = new []{progettocosto.Columns["idprogettotipocosto"]};
	Relations.Add(new DataRelation("FK_progettocosto_progettotipocosto_idprogettotipocosto",cPar,cChild,false));

	cPar = new []{workpackagesegview.Columns["idworkpackage"]};
	cChild = new []{progettocosto.Columns["idworkpackage"]};
	Relations.Add(new DataRelation("FK_progettocosto_workpackagesegview_idworkpackage",cPar,cChild,false));

	#endregion

}
}
}
