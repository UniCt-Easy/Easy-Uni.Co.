
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
[System.Xml.Serialization.XmlRoot("dsmeta_apprelation_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_apprelation_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable appfielddetail 		=> (MetaTable)Tables["appfielddetail"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable apptab 		=> (MetaTable)Tables["apptab"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable apppagesdefaultview 		=> (MetaTable)Tables["apppagesdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable apprelation 		=> (MetaTable)Tables["apprelation"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_apprelation_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_apprelation_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_apprelation_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_apprelation_default.xsd";

	#region create DataTables
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
	tappfielddetail.defineColumn("position", typeof(int));
	tappfielddetail.defineColumn("radiovalues", typeof(string));
	tappfielddetail.defineColumn("readonlyfield", typeof(string));
	tappfielddetail.defineColumn("sqltype", typeof(string));
	tappfielddetail.defineColumn("tablefilter", typeof(string));
	tappfielddetail.defineColumn("testvalue", typeof(string));
	tappfielddetail.defineColumn("text", typeof(string));
	tappfielddetail.defineColumn("textarea", typeof(string),false);
	tappfielddetail.defineColumn("title", typeof(string));
	tappfielddetail.defineColumn("uniqueonrow", typeof(string),false);
	tappfielddetail.defineColumn("visible", typeof(string));
	Tables.Add(tappfielddetail);
	tappfielddetail.defineKey("idappfielddetail", "idapppages");

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

	//////////////////// APPPAGESDEFAULTVIEW /////////////////////////////////
	var tapppagesdefaultview= new MetaTable("apppagesdefaultview");
	tapppagesdefaultview.defineColumn("applicazione_title", typeof(string));
	tapppagesdefaultview.defineColumn("apppages_additionaltables", typeof(string));
	tapppagesdefaultview.defineColumn("apppages_anonimous", typeof(string));
	tapppagesdefaultview.defineColumn("apppages_autosearch", typeof(string));
	tapppagesdefaultview.defineColumn("apppages_beforefillsinc", typeof(string));
	tapppagesdefaultview.defineColumn("apppages_calendarmaincolor", typeof(string));
	tapppagesdefaultview.defineColumn("apppages_calendarstart", typeof(string));
	tapppagesdefaultview.defineColumn("apppages_calendarstop", typeof(string));
	tapppagesdefaultview.defineColumn("apppages_calendartitle", typeof(string));
	tapppagesdefaultview.defineColumn("apppages_cancancel", typeof(string));
	tapppagesdefaultview.defineColumn("apppages_cancmdclose", typeof(string));
	tapppagesdefaultview.defineColumn("apppages_caninsert", typeof(string));
	tapppagesdefaultview.defineColumn("apppages_caninsertcopy", typeof(string));
	tapppagesdefaultview.defineColumn("apppages_cansave", typeof(string));
	tapppagesdefaultview.defineColumn("apppages_cansearch", typeof(string));
	tapppagesdefaultview.defineColumn("apppages_canshowlast", typeof(string));
	tapppagesdefaultview.defineColumn("apppages_customcode", typeof(string));
	tapppagesdefaultview.defineColumn("apppages_customjavascript", typeof(string));
	tapppagesdefaultview.defineColumn("apppages_customreference", typeof(string));
	tapppagesdefaultview.defineColumn("apppages_customusing", typeof(string));
	tapppagesdefaultview.defineColumn("apppages_editlistingtype", typeof(string));
	tapppagesdefaultview.defineColumn("apppages_footer", typeof(string));
	tapppagesdefaultview.defineColumn("apppages_forcealias", typeof(int));
	tapppagesdefaultview.defineColumn("apppages_header", typeof(string));
	tapppagesdefaultview.defineColumn("apppages_icon", typeof(string));
	tapppagesdefaultview.defineColumn("apppages_istree", typeof(string));
	tapppagesdefaultview.defineColumn("apppages_isvalid", typeof(string));
	tapppagesdefaultview.defineColumn("apppages_othersapp", typeof(string));
	tapppagesdefaultview.defineColumn("apppages_principale", typeof(string));
	tapppagesdefaultview.defineColumn("apppages_staticfilter", typeof(string));
	tapppagesdefaultview.defineColumn("apppages_tablename", typeof(string));
	tapppagesdefaultview.defineColumn("apppages_testcustom", typeof(string));
	tapppagesdefaultview.defineColumn("apppages_testcustomtext", typeof(string));
	tapppagesdefaultview.defineColumn("apppages_vocabolario", typeof(string));
	tapppagesdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tapppagesdefaultview.defineColumn("idapplicazione", typeof(int),false);
	tapppagesdefaultview.defineColumn("idapppages", typeof(int),false);
	tapppagesdefaultview.defineColumn("idapppages_ext", typeof(int));
	tapppagesdefaultview.defineColumn("idmenuweb", typeof(int));
	tapppagesdefaultview.defineColumn("menuweb_label", typeof(string));
	tapppagesdefaultview.defineColumn("title", typeof(string));
	Tables.Add(tapppagesdefaultview);
	tapppagesdefaultview.defineKey("idapppages");

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
	Tables.Add(tapprelation);
	tapprelation.defineKey("idapppages", "idapprelation");

	#endregion


	#region DataRelation creation
	var cPar = new []{appfielddetail.Columns["idappfielddetail"]};
	var cChild = new []{apprelation.Columns["idappfielddetail_parent"]};
	Relations.Add(new DataRelation("FK_apprelation_appfielddetail_idappfielddetail_parent",cPar,cChild,false));

	cPar = new []{apptab.Columns["idapptab"]};
	cChild = new []{apprelation.Columns["idapptab"]};
	Relations.Add(new DataRelation("FK_apprelation_apptab_idapptab",cPar,cChild,false));

	cPar = new []{apppagesdefaultview.Columns["idapppages"]};
	cChild = new []{apprelation.Columns["idapppages_parent"]};
	Relations.Add(new DataRelation("FK_apprelation_apppagesdefaultview_idapppages_parent",cPar,cChild,false));

	#endregion

}
}
}
