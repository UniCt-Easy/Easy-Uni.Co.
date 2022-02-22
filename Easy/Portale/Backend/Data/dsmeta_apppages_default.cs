
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
[System.Xml.Serialization.XmlRoot("dsmeta_apppages_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_apppages_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable apptab 		=> (MetaTable)Tables["apptab"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable apptab_alias3 		=> (MetaTable)Tables["apptab_alias3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable apppages_alias1 		=> (MetaTable)Tables["apppages_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable appfielddetail_alias2 		=> (MetaTable)Tables["appfielddetail_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable apprelation 		=> (MetaTable)Tables["apprelation"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable apptab_alias2 		=> (MetaTable)Tables["apptab_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable apppagesbutton 		=> (MetaTable)Tables["apppagesbutton"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getsorting 		=> (MetaTable)Tables["getsorting"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable appfieldlist 		=> (MetaTable)Tables["appfieldlist"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable apptab_alias1 		=> (MetaTable)Tables["apptab_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable appfielddetail 		=> (MetaTable)Tables["appfielddetail"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable menuwebdefaultview 		=> (MetaTable)Tables["menuwebdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable applicazione 		=> (MetaTable)Tables["applicazione"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable apppages 		=> (MetaTable)Tables["apppages"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_apppages_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_apppages_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_apppages_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_apppages_default.xsd";

	#region create DataTables
	//////////////////// APPTAB /////////////////////////////////
	var tapptab= new MetaTable("apptab");
	tapptab.defineColumn("header", typeof(string));
	tapptab.defineColumn("icon", typeof(string));
	tapptab.defineColumn("idapppages", typeof(int),false);
	tapptab.defineColumn("idapptab", typeof(int),false);
	tapptab.defineColumn("position", typeof(int));
	tapptab.defineColumn("title", typeof(string));
	Tables.Add(tapptab);
	tapptab.defineKey("idapppages", "idapptab");

	//////////////////// APPTAB_ALIAS3 /////////////////////////////////
	var tapptab_alias3= new MetaTable("apptab_alias3");
	tapptab_alias3.defineColumn("idapppages", typeof(int),false);
	tapptab_alias3.defineColumn("idapptab", typeof(int),false);
	tapptab_alias3.defineColumn("title", typeof(string));
	tapptab_alias3.ExtendedProperties["TableForReading"]="apptab";
	Tables.Add(tapptab_alias3);
	tapptab_alias3.defineKey("idapppages", "idapptab");

	//////////////////// APPPAGES_ALIAS1 /////////////////////////////////
	var tapppages_alias1= new MetaTable("apppages_alias1");
	tapppages_alias1.defineColumn("editlistingtype", typeof(string));
	tapppages_alias1.defineColumn("idapplicazione", typeof(int),false);
	tapppages_alias1.defineColumn("idapppages", typeof(int),false);
	tapppages_alias1.defineColumn("tablename", typeof(string),false);
	tapppages_alias1.defineColumn("title", typeof(string),false);
	tapppages_alias1.ExtendedProperties["TableForReading"]="apppages";
	Tables.Add(tapppages_alias1);
	tapppages_alias1.defineKey("idapppages");

	//////////////////// APPFIELDDETAIL_ALIAS2 /////////////////////////////////
	var tappfielddetail_alias2= new MetaTable("appfielddetail_alias2");
	tappfielddetail_alias2.defineColumn("columnname", typeof(string));
	tappfielddetail_alias2.defineColumn("idappfielddetail", typeof(int),false);
	tappfielddetail_alias2.defineColumn("idapppages", typeof(int),false);
	tappfielddetail_alias2.defineColumn("title", typeof(string));
	tappfielddetail_alias2.ExtendedProperties["TableForReading"]="appfielddetail";
	Tables.Add(tappfielddetail_alias2);
	tappfielddetail_alias2.defineKey("idappfielddetail", "idapppages");

	//////////////////// APPRELATION /////////////////////////////////
	var tapprelation= new MetaTable("apprelation");
	tapprelation.defineColumn("buttondelete", typeof(string));
	tapprelation.defineColumn("buttonedit", typeof(string));
	tapprelation.defineColumn("buttoninsert", typeof(string));
	tapprelation.defineColumn("calendarstart", typeof(string));
	tapprelation.defineColumn("calendarstop", typeof(string));
	tapprelation.defineColumn("calendartitle", typeof(string));
	tapprelation.defineColumn("description", typeof(string));
	tapprelation.defineColumn("idappfielddetail_parent", typeof(int));
	tapprelation.defineColumn("idapppages", typeof(int),false);
	tapprelation.defineColumn("idapppages_parent", typeof(int));
	tapprelation.defineColumn("idapprelation", typeof(int),false);
	tapprelation.defineColumn("idapptab", typeof(int));
	tapprelation.defineColumn("numrowsmandatory", typeof(int));
	tapprelation.defineColumn("position", typeof(int));
	tapprelation.defineColumn("savebeforetest", typeof(string));
	tapprelation.defineColumn("showinparentgridpos", typeof(int),false);
	tapprelation.defineColumn("type", typeof(string));
	tapprelation.defineColumn("!idappfielddetail_parent_appfielddetail_columnname", typeof(string));
	tapprelation.defineColumn("!idappfielddetail_parent_appfielddetail_title", typeof(string));
	tapprelation.defineColumn("!idapppages_parent_apppages_title", typeof(string));
	tapprelation.defineColumn("!idapppages_parent_apppages_tablename", typeof(string));
	tapprelation.defineColumn("!idapppages_parent_apppages_editlistingtype", typeof(string));
	tapprelation.defineColumn("!idapppages_parent_apppages_idapplicazione_title", typeof(string));
	tapprelation.defineColumn("!idapptab_apptab_title", typeof(string));
	Tables.Add(tapprelation);
	tapprelation.defineKey("idapppages", "idapprelation");

	//////////////////// APPTAB_ALIAS2 /////////////////////////////////
	var tapptab_alias2= new MetaTable("apptab_alias2");
	tapptab_alias2.defineColumn("idapppages", typeof(int),false);
	tapptab_alias2.defineColumn("idapptab", typeof(int),false);
	tapptab_alias2.defineColumn("title", typeof(string));
	tapptab_alias2.ExtendedProperties["TableForReading"]="apptab";
	Tables.Add(tapptab_alias2);
	tapptab_alias2.defineKey("idapppages", "idapptab");

	//////////////////// APPPAGESBUTTON /////////////////////////////////
	var tapppagesbutton= new MetaTable("apppagesbutton");
	tapppagesbutton.defineColumn("code", typeof(string));
	tapppagesbutton.defineColumn("icon", typeof(string));
	tapppagesbutton.defineColumn("idapppages", typeof(int),false);
	tapppagesbutton.defineColumn("idapppagesbutton", typeof(int),false);
	tapppagesbutton.defineColumn("idapptab", typeof(int));
	tapppagesbutton.defineColumn("javascript", typeof(string));
	tapppagesbutton.defineColumn("name", typeof(string));
	tapppagesbutton.defineColumn("parameter", typeof(string));
	tapppagesbutton.defineColumn("position", typeof(string),false);
	tapppagesbutton.defineColumn("refresh", typeof(string));
	tapppagesbutton.defineColumn("storeprocedure", typeof(string));
	tapppagesbutton.defineColumn("title", typeof(string));
	tapppagesbutton.defineColumn("!idapptab_apptab_title", typeof(string));
	Tables.Add(tapppagesbutton);
	tapppagesbutton.defineKey("idapppages", "idapppagesbutton");

	//////////////////// GETSORTING /////////////////////////////////
	var tgetsorting= new MetaTable("getsorting");
	tgetsorting.defineColumn("getsorting", typeof(string),false);
	Tables.Add(tgetsorting);
	tgetsorting.defineKey("getsorting");

	//////////////////// APPFIELDLIST /////////////////////////////////
	var tappfieldlist= new MetaTable("appfieldlist");
	tappfieldlist.defineColumn("columnname", typeof(string));
	tappfieldlist.defineColumn("editable", typeof(string),false);
	tappfieldlist.defineColumn("filter", typeof(string));
	tappfieldlist.defineColumn("filterjs", typeof(string));
	tappfieldlist.defineColumn("getsorting", typeof(string));
	tappfieldlist.defineColumn("idappfieldlist", typeof(int),false);
	tappfieldlist.defineColumn("idapppages", typeof(int),false);
	tappfieldlist.defineColumn("position", typeof(int));
	tappfieldlist.defineColumn("summary", typeof(string));
	tappfieldlist.defineColumn("textfield", typeof(int));
	tappfieldlist.defineColumn("textfieldprefix", typeof(string));
	tappfieldlist.defineColumn("visible", typeof(string));
	Tables.Add(tappfieldlist);
	tappfieldlist.defineKey("idappfieldlist", "idapppages");

	//////////////////// APPTAB_ALIAS1 /////////////////////////////////
	var tapptab_alias1= new MetaTable("apptab_alias1");
	tapptab_alias1.defineColumn("idapppages", typeof(int),false);
	tapptab_alias1.defineColumn("idapptab", typeof(int),false);
	tapptab_alias1.defineColumn("title", typeof(string));
	tapptab_alias1.ExtendedProperties["TableForReading"]="apptab";
	Tables.Add(tapptab_alias1);
	tapptab_alias1.defineKey("idapppages", "idapptab");

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

	//////////////////// MENUWEBDEFAULTVIEW /////////////////////////////////
	var tmenuwebdefaultview= new MetaTable("menuwebdefaultview");
	tmenuwebdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tmenuwebdefaultview.defineColumn("idmenuweb", typeof(int),false);
	tmenuwebdefaultview.defineColumn("idmenuwebparent", typeof(int));
	Tables.Add(tmenuwebdefaultview);
	tmenuwebdefaultview.defineKey("idmenuweb");

	//////////////////// APPLICAZIONE /////////////////////////////////
	var tapplicazione= new MetaTable("applicazione");
	tapplicazione.defineColumn("idapplicazione", typeof(int),false);
	tapplicazione.defineColumn("title", typeof(string));
	Tables.Add(tapplicazione);
	tapplicazione.defineKey("idapplicazione");

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
	var cChild = new []{apptab.Columns["idapppages"]};
	Relations.Add(new DataRelation("FK_apptab_apppages_idapppages",cPar,cChild,false));

	cPar = new []{apppages.Columns["idapppages"]};
	cChild = new []{apprelation.Columns["idapppages"]};
	Relations.Add(new DataRelation("FK_apprelation_apppages_idapppages",cPar,cChild,false));

	cPar = new []{apptab_alias3.Columns["idapptab"]};
	cChild = new []{apprelation.Columns["idapptab"]};
	Relations.Add(new DataRelation("FK_apprelation_apptab_alias3_idapptab",cPar,cChild,false));

	cPar = new []{apppages_alias1.Columns["idapppages"]};
	cChild = new []{apprelation.Columns["idapppages_parent"]};
	Relations.Add(new DataRelation("FK_apprelation_apppages_alias1_idapppages_parent",cPar,cChild,false));

	cPar = new []{applicazione.Columns["idapplicazione"]};
	cChild = new []{apppages_alias1.Columns["idapplicazione"]};
	Relations.Add(new DataRelation("FK_apppages_alias1_applicazione_idapplicazione",cPar,cChild,false));

	cPar = new []{appfielddetail_alias2.Columns["idappfielddetail"]};
	cChild = new []{apprelation.Columns["idappfielddetail_parent"]};
	Relations.Add(new DataRelation("FK_apprelation_appfielddetail_alias2_idappfielddetail_parent",cPar,cChild,false));

	cPar = new []{apppages.Columns["idapppages"]};
	cChild = new []{apppagesbutton.Columns["idapppages"]};
	Relations.Add(new DataRelation("FK_apppagesbutton_apppages_idapppages",cPar,cChild,false));

	cPar = new []{apptab_alias2.Columns["idapptab"]};
	cChild = new []{apppagesbutton.Columns["idapptab"]};
	Relations.Add(new DataRelation("FK_apppagesbutton_apptab_alias2_idapptab",cPar,cChild,false));

	cPar = new []{apppages.Columns["idapppages"]};
	cChild = new []{appfieldlist.Columns["idapppages"]};
	Relations.Add(new DataRelation("FK_appfieldlist_apppages_idapppages",cPar,cChild,false));

	cPar = new []{getsorting.Columns["getsorting"]};
	cChild = new []{appfieldlist.Columns["getsorting"]};
	Relations.Add(new DataRelation("FK_appfieldlist_getsorting_getsorting",cPar,cChild,false));

	cPar = new []{apppages.Columns["idapppages"]};
	cChild = new []{appfielddetail.Columns["idapppages"]};
	Relations.Add(new DataRelation("FK_appfielddetail_apppages_idapppages",cPar,cChild,false));

	cPar = new []{apptab_alias1.Columns["idapptab"]};
	cChild = new []{appfielddetail.Columns["idapptab"]};
	Relations.Add(new DataRelation("FK_appfielddetail_apptab_alias1_idapptab",cPar,cChild,false));

	cPar = new []{menuwebdefaultview.Columns["idmenuweb"]};
	cChild = new []{apppages.Columns["idmenuweb"]};
	Relations.Add(new DataRelation("FK_apppages_menuwebdefaultview_idmenuweb",cPar,cChild,false));

	cPar = new []{applicazione.Columns["idapplicazione"]};
	cChild = new []{apppages.Columns["idapplicazione"]};
	Relations.Add(new DataRelation("FK_apppages_applicazione_idapplicazione",cPar,cChild,false));

	#endregion

}
}
}
