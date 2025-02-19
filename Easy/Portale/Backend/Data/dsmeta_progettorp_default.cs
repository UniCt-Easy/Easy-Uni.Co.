
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
[System.Xml.Serialization.XmlRoot("dsmeta_progettorp_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_progettorp_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getprogettocostoview 		=> (MetaTable)Tables["getprogettocostoview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettorp 		=> (MetaTable)Tables["progettorp"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_progettorp_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_progettorp_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_progettorp_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_progettorp_default.xsd";

	#region create DataTables
	//////////////////// GETPROGETTOCOSTOVIEW /////////////////////////////////
	var tgetprogettocostoview= new MetaTable("getprogettocostoview");
	tgetprogettocostoview.defineColumn("adate", typeof(DateTime));
	tgetprogettocostoview.defineColumn("ammissibilita", typeof(decimal));
	tgetprogettocostoview.defineColumn("amount", typeof(decimal));
	tgetprogettocostoview.defineColumn("cf", typeof(string));
	tgetprogettocostoview.defineColumn("description", typeof(string));
	tgetprogettocostoview.defineColumn("doc", typeof(string));
	tgetprogettocostoview.defineColumn("docdate", typeof(DateTime));
	tgetprogettocostoview.defineColumn("idgetprogettocostoview", typeof(int),false);
	tgetprogettocostoview.defineColumn("idprogetto", typeof(int),false);
	tgetprogettocostoview.defineColumn("nmov", typeof(int));
	tgetprogettocostoview.defineColumn("noperation", typeof(int));
	tgetprogettocostoview.defineColumn("p_iva", typeof(string));
	tgetprogettocostoview.defineColumn("payment_adate", typeof(DateTime));
	tgetprogettocostoview.defineColumn("pettycash_description", typeof(string));
	tgetprogettocostoview.defineColumn("pettycash_pettycode", typeof(string));
	tgetprogettocostoview.defineColumn("position_title", typeof(string));
	tgetprogettocostoview.defineColumn("progettotipocosto_title", typeof(string));
	tgetprogettocostoview.defineColumn("raggruppamento", typeof(string));
	tgetprogettocostoview.defineColumn("registry_title", typeof(string));
	tgetprogettocostoview.defineColumn("rendicontattivitaprogetto_description", typeof(string));
	tgetprogettocostoview.defineColumn("transactiondate", typeof(DateTime));
	tgetprogettocostoview.defineColumn("transmissiondate", typeof(DateTime));
	tgetprogettocostoview.defineColumn("workpackage_title", typeof(string));
	tgetprogettocostoview.defineColumn("ymov", typeof(int));
	tgetprogettocostoview.defineColumn("yoperation", typeof(int));
	Tables.Add(tgetprogettocostoview);
	tgetprogettocostoview.defineKey("idgetprogettocostoview", "idprogetto");

	//////////////////// PROGETTORP /////////////////////////////////
	var tprogettorp= new MetaTable("progettorp");
	tprogettorp.defineColumn("datefilter", typeof(string));
	tprogettorp.defineColumn("idprogetto", typeof(int),false);
	tprogettorp.defineColumn("idprogettorp", typeof(int),false);
	tprogettorp.defineColumn("start", typeof(DateTime));
	tprogettorp.defineColumn("stop", typeof(DateTime));
	Tables.Add(tprogettorp);
	tprogettorp.defineKey("idprogetto", "idprogettorp");

	#endregion


	#region DataRelation creation
	var cPar = new []{getprogettocostoview.Columns["idprogetto"]};
	var cChild = new []{progettorp.Columns["idprogetto"]};
	Relations.Add(new DataRelation("FK_progettorp_getprogettocostoview_idprogetto",cPar,cChild,false));

	#endregion

}
}
}
