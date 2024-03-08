
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
[System.Xml.Serialization.XmlRoot("dsmeta_apprelation_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_apprelation_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable appfielddetail_alias1 		=> (MetaTable)Tables["appfielddetail_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable appfielddetail 		=> (MetaTable)Tables["appfielddetail"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable apprelationkey 		=> (MetaTable)Tables["apprelationkey"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable appfielddetaildefaultview 		=> (MetaTable)Tables["appfielddetaildefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable apptabdefaultview 		=> (MetaTable)Tables["apptabdefaultview"];

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
	//////////////////// APPFIELDDETAIL_ALIAS1 /////////////////////////////////
	var tappfielddetail_alias1= new MetaTable("appfielddetail_alias1");
	tappfielddetail_alias1.defineColumn("columnname", typeof(string));
	tappfielddetail_alias1.defineColumn("idappfielddetail", typeof(int),false);
	tappfielddetail_alias1.defineColumn("idapppages", typeof(int),false);
	tappfielddetail_alias1.defineColumn("title", typeof(string));
	tappfielddetail_alias1.ExtendedProperties["TableForReading"]="appfielddetail";
	Tables.Add(tappfielddetail_alias1);
	tappfielddetail_alias1.defineKey("idappfielddetail", "idapppages");

	//////////////////// APPFIELDDETAIL /////////////////////////////////
	var tappfielddetail= new MetaTable("appfielddetail");
	tappfielddetail.defineColumn("columnname", typeof(string));
	tappfielddetail.defineColumn("idappfielddetail", typeof(int),false);
	tappfielddetail.defineColumn("idapppages", typeof(int),false);
	tappfielddetail.defineColumn("title", typeof(string));
	Tables.Add(tappfielddetail);
	tappfielddetail.defineKey("idappfielddetail", "idapppages");

	//////////////////// APPRELATIONKEY /////////////////////////////////
	var tapprelationkey= new MetaTable("apprelationkey");
	tapprelationkey.defineColumn("idappfielddetail", typeof(int));
	tapprelationkey.defineColumn("idappfielddetail_par", typeof(int));
	tapprelationkey.defineColumn("idapppages", typeof(int),false);
	tapprelationkey.defineColumn("idapprelation", typeof(int),false);
	tapprelationkey.defineColumn("idapprelationkey", typeof(int),false);
	tapprelationkey.defineColumn("!idappfielddetail_appfielddetail_columnname", typeof(string));
	tapprelationkey.defineColumn("!idappfielddetail_appfielddetail_title", typeof(string));
	tapprelationkey.defineColumn("!idappfielddetail_par_appfielddetail_columnname", typeof(string));
	tapprelationkey.defineColumn("!idappfielddetail_par_appfielddetail_title", typeof(string));
	Tables.Add(tapprelationkey);
	tapprelationkey.defineKey("idapppages", "idapprelation", "idapprelationkey");

	//////////////////// APPFIELDDETAILDEFAULTVIEW /////////////////////////////////
	var tappfielddetaildefaultview= new MetaTable("appfielddetaildefaultview");
	tappfielddetaildefaultview.defineColumn("appfielddetail_afteractivationprefill", typeof(string));
	tappfielddetaildefaultview.defineColumn("appfielddetail_afterrowselectprefill", typeof(string));
	tappfielddetaildefaultview.defineColumn("appfielddetail_calculatedfieldfunction", typeof(string));
	tappfielddetaildefaultview.defineColumn("appfielddetail_charnumber", typeof(int));
	tappfielddetaildefaultview.defineColumn("appfielddetail_defaultvalue", typeof(string));
	tappfielddetaildefaultview.defineColumn("appfielddetail_eventtext", typeof(string));
	tappfielddetaildefaultview.defineColumn("appfielddetail_eventtype", typeof(string));
	tappfielddetaildefaultview.defineColumn("appfielddetail_forcedropdown", typeof(string));
	tappfielddetaildefaultview.defineColumn("appfielddetail_forcekey", typeof(string));
	tappfielddetaildefaultview.defineColumn("appfielddetail_hidden", typeof(string));
	tappfielddetaildefaultview.defineColumn("appfielddetail_idappfielddetail_sortmember", typeof(int));
	tappfielddetaildefaultview.defineColumn("appfielddetail_idapptab", typeof(int));
	tappfielddetaildefaultview.defineColumn("appfielddetail_ischeckbox", typeof(string));
	tappfielddetaildefaultview.defineColumn("appfielddetail_islinkingobj", typeof(string));
	tappfielddetaildefaultview.defineColumn("appfielddetail_isnullable", typeof(string));
	tappfielddetaildefaultview.defineColumn("appfielddetail_listtype", typeof(string));
	tappfielddetaildefaultview.defineColumn("appfielddetail_master", typeof(string));
	tappfielddetaildefaultview.defineColumn("appfielddetail_max", typeof(int));
	tappfielddetaildefaultview.defineColumn("appfielddetail_min", typeof(int));
	tappfielddetaildefaultview.defineColumn("appfielddetail_position", typeof(int));
	tappfielddetaildefaultview.defineColumn("appfielddetail_radiovalues", typeof(string));
	tappfielddetaildefaultview.defineColumn("appfielddetail_readonlyfield", typeof(string));
	tappfielddetaildefaultview.defineColumn("appfielddetail_specialcontrol", typeof(string));
	tappfielddetaildefaultview.defineColumn("appfielddetail_sqltype", typeof(string));
	tappfielddetaildefaultview.defineColumn("appfielddetail_tablefilter", typeof(string));
	tappfielddetaildefaultview.defineColumn("appfielddetail_testvalue", typeof(string));
	tappfielddetaildefaultview.defineColumn("appfielddetail_text", typeof(string));
	tappfielddetaildefaultview.defineColumn("appfielddetail_textarea", typeof(string));
	tappfielddetaildefaultview.defineColumn("appfielddetail_title", typeof(string));
	tappfielddetaildefaultview.defineColumn("appfielddetail_uniqueonrow", typeof(string));
	tappfielddetaildefaultview.defineColumn("appfielddetail_val1", typeof(int));
	tappfielddetaildefaultview.defineColumn("appfielddetail_val2", typeof(int));
	tappfielddetaildefaultview.defineColumn("appfielddetail_visible", typeof(string));
	tappfielddetaildefaultview.defineColumn("appfielddetailsortmember_columnname", typeof(string));
	tappfielddetaildefaultview.defineColumn("appfielddetailsortmember_title", typeof(string));
	tappfielddetaildefaultview.defineColumn("apptab_title", typeof(string));
	tappfielddetaildefaultview.defineColumn("columnname", typeof(string));
	tappfielddetaildefaultview.defineColumn("dropdown_title", typeof(string),false);
	tappfielddetaildefaultview.defineColumn("idappfielddetail", typeof(int),false);
	tappfielddetaildefaultview.defineColumn("idapppages", typeof(int),false);
	tappfielddetaildefaultview.defineColumn("sqltype_datasettype", typeof(string));
	tappfielddetaildefaultview.defineColumn("sqltype_sqltype", typeof(string));
	Tables.Add(tappfielddetaildefaultview);
	tappfielddetaildefaultview.defineKey("idappfielddetail", "idapppages");

	//////////////////// APPTABDEFAULTVIEW /////////////////////////////////
	var tapptabdefaultview= new MetaTable("apptabdefaultview");
	tapptabdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tapptabdefaultview.defineColumn("idapppages", typeof(int),false);
	tapptabdefaultview.defineColumn("idapptab", typeof(int),false);
	Tables.Add(tapptabdefaultview);
	tapptabdefaultview.defineKey("idapppages", "idapptab");

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
	var cPar = new []{apprelation.Columns["idapppages"], apprelation.Columns["idapprelation"]};
	var cChild = new []{apprelationkey.Columns["idapppages"], apprelationkey.Columns["idapprelation"]};
	Relations.Add(new DataRelation("FK_apprelationkey_apprelation_idapppages-idapprelation",cPar,cChild,false));

	cPar = new []{appfielddetail_alias1.Columns["idappfielddetail"]};
	cChild = new []{apprelationkey.Columns["idappfielddetail_par"]};
	Relations.Add(new DataRelation("FK_apprelationkey_appfielddetail_alias1_idappfielddetail_par",cPar,cChild,false));

	cPar = new []{appfielddetail.Columns["idappfielddetail"]};
	cChild = new []{apprelationkey.Columns["idappfielddetail"]};
	Relations.Add(new DataRelation("FK_apprelationkey_appfielddetail_idappfielddetail",cPar,cChild,false));

	cPar = new []{appfielddetaildefaultview.Columns["idappfielddetail"]};
	cChild = new []{apprelation.Columns["idappfielddetail_parent"]};
	Relations.Add(new DataRelation("FK_apprelation_appfielddetaildefaultview_idappfielddetail_parent",cPar,cChild,false));

	cPar = new []{apptabdefaultview.Columns["idapptab"]};
	cChild = new []{apprelation.Columns["idapptab"]};
	Relations.Add(new DataRelation("FK_apprelation_apptabdefaultview_idapptab",cPar,cChild,false));

	cPar = new []{apppagesdefaultview.Columns["idapppages"]};
	cChild = new []{apptabdefaultview.Columns["idapppages"]};
	Relations.Add(new DataRelation("FK_apptabdefaultview_apppagesdefaultview_idapppages",cPar,cChild,false));

	cPar = new []{apppagesdefaultview.Columns["idapppages"]};
	cChild = new []{apprelation.Columns["idapppages_parent"]};
	Relations.Add(new DataRelation("FK_apprelation_apppagesdefaultview_idapppages_parent",cPar,cChild,false));

	#endregion

}
}
}
