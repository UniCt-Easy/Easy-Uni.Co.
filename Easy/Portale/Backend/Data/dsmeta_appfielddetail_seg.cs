/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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
[System.Xml.Serialization.XmlRoot("dsmeta_appfielddetail_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_appfielddetail_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable appfielddetail_alias1 		=> (MetaTable)Tables["appfielddetail_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sqltype 		=> (MetaTable)Tables["sqltype"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable apptabdefaultview 		=> (MetaTable)Tables["apptabdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable appfielddetail 		=> (MetaTable)Tables["appfielddetail"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_appfielddetail_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_appfielddetail_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_appfielddetail_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_appfielddetail_seg.xsd";

	#region create DataTables
	//////////////////// APPFIELDDETAIL_ALIAS1 /////////////////////////////////
	var tappfielddetail_alias1= new MetaTable("appfielddetail_alias1");
	tappfielddetail_alias1.defineColumn("idappfielddetail", typeof(int),false);
	tappfielddetail_alias1.defineColumn("idapppages", typeof(int),false);
	tappfielddetail_alias1.defineColumn("title", typeof(string));
	tappfielddetail_alias1.ExtendedProperties["TableForReading"]="appfielddetail";
	Tables.Add(tappfielddetail_alias1);
	tappfielddetail_alias1.defineKey("idappfielddetail", "idapppages");

	//////////////////// SQLTYPE /////////////////////////////////
	var tsqltype= new MetaTable("sqltype");
	tsqltype.defineColumn("datasettype", typeof(string));
	tsqltype.defineColumn("sqltype", typeof(string),false);
	Tables.Add(tsqltype);
	tsqltype.defineKey("sqltype");

	//////////////////// APPTABDEFAULTVIEW /////////////////////////////////
	var tapptabdefaultview= new MetaTable("apptabdefaultview");
	tapptabdefaultview.defineColumn("apptab_header", typeof(string));
	tapptabdefaultview.defineColumn("apptab_icon", typeof(string));
	tapptabdefaultview.defineColumn("apptab_position", typeof(int));
	tapptabdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tapptabdefaultview.defineColumn("idapppages", typeof(int),false);
	tapptabdefaultview.defineColumn("idapptab", typeof(int),false);
	tapptabdefaultview.defineColumn("idapptabcolsnumber", typeof(int));
	tapptabdefaultview.defineColumn("title", typeof(string));
	Tables.Add(tapptabdefaultview);
	tapptabdefaultview.defineKey("idapppages", "idapptab");

	//////////////////// APPFIELDDETAIL /////////////////////////////////
	var tappfielddetail= new MetaTable("appfielddetail");
	tappfielddetail.defineColumn("afteractivationprefill", typeof(string));
	tappfielddetail.defineColumn("afterrowselectprefill", typeof(string));
	tappfielddetail.defineColumn("calculatedfieldfunction", typeof(string));
	tappfielddetail.defineColumn("charnumber", typeof(int));
	tappfielddetail.defineColumn("columnname", typeof(string));
	tappfielddetail.defineColumn("defaultvalue", typeof(string));
	tappfielddetail.defineColumn("eventtext", typeof(string));
	tappfielddetail.defineColumn("eventtype", typeof(string));
	tappfielddetail.defineColumn("forcedropdown", typeof(string));
	tappfielddetail.defineColumn("forcekey", typeof(string));
	tappfielddetail.defineColumn("hidden", typeof(string));
	tappfielddetail.defineColumn("idappfielddetail", typeof(int),false);
	tappfielddetail.defineColumn("idappfielddetail_sortmember", typeof(int));
	tappfielddetail.defineColumn("idapppages", typeof(int),false);
	tappfielddetail.defineColumn("idapptab", typeof(int));
	tappfielddetail.defineColumn("ischeckbox", typeof(string),false);
	tappfielddetail.defineColumn("islinkingobj", typeof(string));
	tappfielddetail.defineColumn("isnullable", typeof(string));
	tappfielddetail.defineColumn("listtype", typeof(string));
	tappfielddetail.defineColumn("master", typeof(string));
	tappfielddetail.defineColumn("max", typeof(int));
	tappfielddetail.defineColumn("min", typeof(int));
	tappfielddetail.defineColumn("position", typeof(int));
	tappfielddetail.defineColumn("radiovalues", typeof(string));
	tappfielddetail.defineColumn("readonlyfield", typeof(string));
	tappfielddetail.defineColumn("specialcontrol", typeof(string));
	tappfielddetail.defineColumn("sqltype", typeof(string));
	tappfielddetail.defineColumn("tablefilter", typeof(string));
	tappfielddetail.defineColumn("testexclude", typeof(string));
	tappfielddetail.defineColumn("testvalue", typeof(string));
	tappfielddetail.defineColumn("text", typeof(string));
	tappfielddetail.defineColumn("textarea", typeof(string),false);
	tappfielddetail.defineColumn("title", typeof(string));
	tappfielddetail.defineColumn("uniqueonrow", typeof(string),false);
	tappfielddetail.defineColumn("val1", typeof(int));
	tappfielddetail.defineColumn("val2", typeof(int));
	tappfielddetail.defineColumn("visible", typeof(string));
	Tables.Add(tappfielddetail);
	tappfielddetail.defineKey("idappfielddetail", "idapppages");

	#endregion


	#region DataRelation creation
	var cPar = new []{appfielddetail_alias1.Columns["idappfielddetail"]};
	var cChild = new []{appfielddetail.Columns["idappfielddetail_sortmember"]};
	Relations.Add(new DataRelation("FK_appfielddetail_appfielddetail_alias1_idappfielddetail_sortmember",cPar,cChild,false));

	cPar = new []{sqltype.Columns["sqltype"]};
	cChild = new []{appfielddetail.Columns["sqltype"]};
	Relations.Add(new DataRelation("FK_appfielddetail_sqltype_sqltype",cPar,cChild,false));

	cPar = new []{apptabdefaultview.Columns["idapptab"]};
	cChild = new []{appfielddetail.Columns["idapptab"]};
	Relations.Add(new DataRelation("FK_appfielddetail_apptabdefaultview_idapptab",cPar,cChild,false));

	#endregion

}
}
}
