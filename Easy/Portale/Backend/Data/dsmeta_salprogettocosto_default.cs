
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
[System.Xml.Serialization.XmlRoot("dsmeta_salprogettocosto_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_salprogettocosto_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettocostosegsalview 		=> (MetaTable)Tables["progettocostosegsalview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable salprogettocosto 		=> (MetaTable)Tables["salprogettocosto"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_salprogettocosto_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_salprogettocosto_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_salprogettocosto_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_salprogettocosto_default.xsd";

	#region create DataTables
	//////////////////// PROGETTOCOSTOSEGSALVIEW /////////////////////////////////
	var tprogettocostosegsalview= new MetaTable("progettocostosegsalview");
	tprogettocostosegsalview.defineColumn("assetdiaryora_idassetdiary", typeof(int));
	tprogettocostosegsalview.defineColumn("assetdiaryora_start", typeof(DateTime));
	tprogettocostosegsalview.defineColumn("assetdiaryora_stop", typeof(DateTime));
	tprogettocostosegsalview.defineColumn("contrattokind_title", typeof(string));
	tprogettocostosegsalview.defineColumn("dropdown_title", typeof(string),false);
	tprogettocostosegsalview.defineColumn("entrydetail_description", typeof(string));
	tprogettocostosegsalview.defineColumn("expense_description", typeof(string));
	tprogettocostosegsalview.defineColumn("expense_nmov", typeof(int));
	tprogettocostosegsalview.defineColumn("expense_ymov", typeof(int));
	tprogettocostosegsalview.defineColumn("idassetdiaryora", typeof(int));
	tprogettocostosegsalview.defineColumn("idexp", typeof(int));
	tprogettocostosegsalview.defineColumn("idpettycash", typeof(int));
	tprogettocostosegsalview.defineColumn("idprogetto", typeof(int),false);
	tprogettocostosegsalview.defineColumn("idprogettocosto", typeof(int),false);
	tprogettocostosegsalview.defineColumn("idprogettotipocosto", typeof(int),false);
	tprogettocostosegsalview.defineColumn("idrelated", typeof(string));
	tprogettocostosegsalview.defineColumn("idrendicontattivitaprogetto", typeof(int));
	tprogettocostosegsalview.defineColumn("idsalprogettoassetworkpackagemese", typeof(int));
	tprogettocostosegsalview.defineColumn("idworkpackage", typeof(int),false);
	tprogettocostosegsalview.defineColumn("mese_title", typeof(string));
	tprogettocostosegsalview.defineColumn("pettycash_description", typeof(string));
	tprogettocostosegsalview.defineColumn("pettycash_pettycode", typeof(string));
	tprogettocostosegsalview.defineColumn("progettocosto_amount", typeof(decimal));
	tprogettocostosegsalview.defineColumn("progettocosto_ct", typeof(DateTime),false);
	tprogettocostosegsalview.defineColumn("progettocosto_cu", typeof(string),false);
	tprogettocostosegsalview.defineColumn("progettocosto_doc", typeof(string));
	tprogettocostosegsalview.defineColumn("progettocosto_docdate", typeof(DateTime));
	tprogettocostosegsalview.defineColumn("progettocosto_idcontrattokind", typeof(int));
	tprogettocostosegsalview.defineColumn("progettocosto_idsal", typeof(int));
	tprogettocostosegsalview.defineColumn("progettocosto_lt", typeof(DateTime),false);
	tprogettocostosegsalview.defineColumn("progettocosto_lu", typeof(string),false);
	tprogettocostosegsalview.defineColumn("progettocosto_noperation", typeof(int));
	tprogettocostosegsalview.defineColumn("progettocosto_yoperation", typeof(int));
	tprogettocostosegsalview.defineColumn("progettotipocosto_title", typeof(string));
	tprogettocostosegsalview.defineColumn("registry_title", typeof(string));
	tprogettocostosegsalview.defineColumn("rendicontattivitaprogetto_description", typeof(string));
	tprogettocostosegsalview.defineColumn("rendicontattivitaprogetto_idreg", typeof(int));
	tprogettocostosegsalview.defineColumn("sal_start", typeof(DateTime));
	tprogettocostosegsalview.defineColumn("sal_stop", typeof(DateTime));
	tprogettocostosegsalview.defineColumn("salprogettoassetworkpackagemese_amount", typeof(decimal));
	tprogettocostosegsalview.defineColumn("salprogettoassetworkpackagemese_idmese", typeof(int));
	tprogettocostosegsalview.defineColumn("salprogettoassetworkpackagemese_idsalprogettoassetworkpackage", typeof(int));
	tprogettocostosegsalview.defineColumn("salprogettoassetworkpackagemese_year", typeof(int));
	tprogettocostosegsalview.defineColumn("workpackage_raggruppamento", typeof(string));
	tprogettocostosegsalview.defineColumn("workpackage_title", typeof(string));
	Tables.Add(tprogettocostosegsalview);
	tprogettocostosegsalview.defineKey("idprogetto", "idprogettocosto", "idprogettotipocosto", "idworkpackage");

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

	#endregion


	#region DataRelation creation
	var cPar = new []{progettocostosegsalview.Columns["idprogettocosto"]};
	var cChild = new []{salprogettocosto.Columns["idprogettocosto"]};
	Relations.Add(new DataRelation("FK_salprogettocosto_progettocostosegsalview_idprogettocosto",cPar,cChild,false));

	#endregion

}
}
}
