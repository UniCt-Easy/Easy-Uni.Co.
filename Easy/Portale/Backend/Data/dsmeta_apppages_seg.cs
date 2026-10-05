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
[System.Xml.Serialization.XmlRoot("dsmeta_apppages_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_apppages_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attach_alias1 		=> (MetaTable)Tables["attach_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attach 		=> (MetaTable)Tables["attach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable apppagestemplate 		=> (MetaTable)Tables["apppagestemplate"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable appfielddetail_alias3 		=> (MetaTable)Tables["appfielddetail_alias3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable appfielddetail_alias2 		=> (MetaTable)Tables["appfielddetail_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable appfieldmandatory 		=> (MetaTable)Tables["appfieldmandatory"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable apptab 		=> (MetaTable)Tables["apptab"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable appfielddetail 		=> (MetaTable)Tables["appfielddetail"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable apppages 		=> (MetaTable)Tables["apppages"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_apppages_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_apppages_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_apppages_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_apppages_seg.xsd";

	#region create DataTables
	//////////////////// ATTACH_ALIAS1 /////////////////////////////////
	var tattach_alias1= new MetaTable("attach_alias1");
	tattach_alias1.defineColumn("attachment", typeof(Byte[]));
	tattach_alias1.defineColumn("ct", typeof(DateTime),false);
	tattach_alias1.defineColumn("cu", typeof(string),false);
	tattach_alias1.defineColumn("filename", typeof(string),false);
	tattach_alias1.defineColumn("hash", typeof(string),false);
	tattach_alias1.defineColumn("idattach", typeof(int),false);
	tattach_alias1.defineColumn("lt", typeof(DateTime),false);
	tattach_alias1.defineColumn("lu", typeof(string),false);
	tattach_alias1.defineColumn("size", typeof(int),false);
	tattach_alias1.ExtendedProperties["TableForReading"]="attach";
	Tables.Add(tattach_alias1);
	tattach_alias1.defineKey("idattach");

	//////////////////// ATTACH /////////////////////////////////
	var tattach= new MetaTable("attach");
	tattach.defineColumn("attachment", typeof(Byte[]));
	tattach.defineColumn("ct", typeof(DateTime),false);
	tattach.defineColumn("cu", typeof(string),false);
	tattach.defineColumn("filename", typeof(string),false);
	tattach.defineColumn("hash", typeof(string),false);
	tattach.defineColumn("idattach", typeof(int),false);
	tattach.defineColumn("lt", typeof(DateTime),false);
	tattach.defineColumn("lu", typeof(string),false);
	tattach.defineColumn("size", typeof(long),false);
	Tables.Add(tattach);
	tattach.defineKey("idattach");

	//////////////////// APPPAGESTEMPLATE /////////////////////////////////
	var tapppagestemplate= new MetaTable("apppagestemplate");
	tapppagestemplate.defineColumn("idapppages", typeof(int));
	tapppagestemplate.defineColumn("idapppagestemplate", typeof(int),false);
	tapppagestemplate.defineColumn("idattach", typeof(int));
	tapppagestemplate.defineColumn("idattach_2", typeof(int));
	tapppagestemplate.defineColumn("title", typeof(string));
	tapppagestemplate.defineColumn("!idattach_attach_filename", typeof(string));
	tapppagestemplate.defineColumn("!idattach_2_attach_filename", typeof(string));
	tapppagestemplate.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tapppagestemplate);
	tapppagestemplate.defineKey("idapppagestemplate");

	//////////////////// APPFIELDDETAIL_ALIAS3 /////////////////////////////////
	var tappfielddetail_alias3= new MetaTable("appfielddetail_alias3");
	tappfielddetail_alias3.defineColumn("idappfielddetail", typeof(int),false);
	tappfielddetail_alias3.defineColumn("idapppages", typeof(int),false);
	tappfielddetail_alias3.defineColumn("title", typeof(string));
	tappfielddetail_alias3.ExtendedProperties["TableForReading"]="appfielddetail";
	Tables.Add(tappfielddetail_alias3);
	tappfielddetail_alias3.defineKey("idappfielddetail", "idapppages");

	//////////////////// APPFIELDDETAIL_ALIAS2 /////////////////////////////////
	var tappfielddetail_alias2= new MetaTable("appfielddetail_alias2");
	tappfielddetail_alias2.defineColumn("idappfielddetail", typeof(int),false);
	tappfielddetail_alias2.defineColumn("idapppages", typeof(int),false);
	tappfielddetail_alias2.defineColumn("title", typeof(string));
	tappfielddetail_alias2.ExtendedProperties["TableForReading"]="appfielddetail";
	Tables.Add(tappfielddetail_alias2);
	tappfielddetail_alias2.defineKey("idappfielddetail", "idapppages");

	//////////////////// APPFIELDMANDATORY /////////////////////////////////
	var tappfieldmandatory= new MetaTable("appfieldmandatory");
	tappfieldmandatory.defineColumn("idappfielddetail", typeof(int));
	tappfieldmandatory.defineColumn("idappfielddetail_master", typeof(int));
	tappfieldmandatory.defineColumn("idappfieldmandatory", typeof(int),false);
	tappfieldmandatory.defineColumn("idapppages", typeof(int),false);
	tappfieldmandatory.defineColumn("mastervalue", typeof(string));
	tappfieldmandatory.defineColumn("message", typeof(string));
	tappfieldmandatory.defineColumn("!idappfielddetail_appfielddetail_title", typeof(string));
	tappfieldmandatory.defineColumn("!idappfielddetail_master_appfielddetail_title", typeof(string));
	Tables.Add(tappfieldmandatory);
	tappfieldmandatory.defineKey("idappfieldmandatory", "idapppages");

	//////////////////// APPTAB /////////////////////////////////
	var tapptab= new MetaTable("apptab");
	tapptab.defineColumn("idapppages", typeof(int),false);
	tapptab.defineColumn("idapptab", typeof(int),false);
	tapptab.defineColumn("title", typeof(string));
	Tables.Add(tapptab);
	tapptab.defineKey("idapppages", "idapptab");

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
	tappfielddetail.defineColumn("!idapptab_apptab_title", typeof(string));
	Tables.Add(tappfielddetail);
	tappfielddetail.defineKey("idappfielddetail", "idapppages");

	//////////////////// APPPAGES /////////////////////////////////
	var tapppages= new MetaTable("apppages");
	tapppages.defineColumn("additionaltables", typeof(string));
	tapppages.defineColumn("anonimous", typeof(string));
	tapppages.defineColumn("autosearch", typeof(string),false);
	tapppages.defineColumn("beforefillsinc", typeof(string));
	tapppages.defineColumn("calendarmaincolor", typeof(string));
	tapppages.defineColumn("calendarstart", typeof(string));
	tapppages.defineColumn("calendarstop", typeof(string));
	tapppages.defineColumn("calendartitle", typeof(string));
	tapppages.defineColumn("cancancel", typeof(string),false);
	tapppages.defineColumn("cancmdclose", typeof(string),false);
	tapppages.defineColumn("caninsert", typeof(string),false);
	tapppages.defineColumn("caninsertcopy", typeof(string),false);
	tapppages.defineColumn("cansave", typeof(string),false);
	tapppages.defineColumn("cansearch", typeof(string),false);
	tapppages.defineColumn("canshowlast", typeof(string));
	tapppages.defineColumn("customcode", typeof(string));
	tapppages.defineColumn("customjavascript", typeof(string));
	tapppages.defineColumn("customreference", typeof(string));
	tapppages.defineColumn("customusing", typeof(string));
	tapppages.defineColumn("editlistingtype", typeof(string));
	tapppages.defineColumn("footer", typeof(string));
	tapppages.defineColumn("forcealias", typeof(int));
	tapppages.defineColumn("header", typeof(string));
	tapppages.defineColumn("icon", typeof(string),false);
	tapppages.defineColumn("idapplicazione", typeof(int),false);
	tapppages.defineColumn("idapppages", typeof(int),false);
	tapppages.defineColumn("idmenuweb", typeof(int));
	tapppages.defineColumn("istree", typeof(string),false);
	tapppages.defineColumn("isvalid", typeof(string));
	tapppages.defineColumn("othersapp", typeof(string));
	tapppages.defineColumn("principale", typeof(string),false);
	tapppages.defineColumn("report", typeof(string));
	tapppages.defineColumn("reportstored", typeof(string));
	tapppages.defineColumn("staticfilter", typeof(string));
	tapppages.defineColumn("tablename", typeof(string),false);
	tapppages.defineColumn("testcustom", typeof(string));
	tapppages.defineColumn("testcustomtext", typeof(string));
	tapppages.defineColumn("title", typeof(string),false);
	tapppages.defineColumn("vocabolario", typeof(string),false);
	Tables.Add(tapppages);
	tapppages.defineKey("idapppages");

	#endregion


	#region DataRelation creation
	var cPar = new []{apppages.Columns["idapppages"]};
	var cChild = new []{apppagestemplate.Columns["idapppages"]};
	Relations.Add(new DataRelation("FK_apppagestemplate_apppages_idapppages",cPar,cChild,false));

	cPar = new []{attach_alias1.Columns["idattach"]};
	cChild = new []{apppagestemplate.Columns["idattach_2"]};
	Relations.Add(new DataRelation("FK_apppagestemplate_attach_alias1_idattach_2",cPar,cChild,false));

	cPar = new []{attach.Columns["idattach"]};
	cChild = new []{apppagestemplate.Columns["idattach"]};
	Relations.Add(new DataRelation("FK_apppagestemplate_attach_idattach",cPar,cChild,false));

	cPar = new []{apppages.Columns["idapppages"]};
	cChild = new []{appfieldmandatory.Columns["idapppages"]};
	Relations.Add(new DataRelation("FK_appfieldmandatory_apppages_idapppages",cPar,cChild,false));

	cPar = new []{appfielddetail_alias3.Columns["idappfielddetail"]};
	cChild = new []{appfieldmandatory.Columns["idappfielddetail_master"]};
	Relations.Add(new DataRelation("FK_appfieldmandatory_appfielddetail_alias3_idappfielddetail_master",cPar,cChild,false));

	cPar = new []{appfielddetail_alias2.Columns["idappfielddetail"]};
	cChild = new []{appfieldmandatory.Columns["idappfielddetail"]};
	Relations.Add(new DataRelation("FK_appfieldmandatory_appfielddetail_alias2_idappfielddetail",cPar,cChild,false));

	cPar = new []{apppages.Columns["idapppages"]};
	cChild = new []{appfielddetail.Columns["idapppages"]};
	Relations.Add(new DataRelation("FK_appfielddetail_apppages_idapppages",cPar,cChild,false));

	cPar = new []{apptab.Columns["idapptab"]};
	cChild = new []{appfielddetail.Columns["idapptab"]};
	Relations.Add(new DataRelation("FK_appfielddetail_apptab_idapptab",cPar,cChild,false));

	#endregion

}
}
}
