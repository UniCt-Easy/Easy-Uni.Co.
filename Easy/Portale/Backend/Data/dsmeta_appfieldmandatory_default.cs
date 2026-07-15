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
[System.Xml.Serialization.XmlRoot("dsmeta_appfieldmandatory_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_appfieldmandatory_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable appfielddetailsegview_alias1 		=> (MetaTable)Tables["appfielddetailsegview_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable appfielddetailsegview 		=> (MetaTable)Tables["appfielddetailsegview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable appfieldmandatory 		=> (MetaTable)Tables["appfieldmandatory"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_appfieldmandatory_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_appfieldmandatory_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_appfieldmandatory_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_appfieldmandatory_default.xsd";

	#region create DataTables
	//////////////////// APPFIELDDETAILSEGVIEW_ALIAS1 /////////////////////////////////
	var tappfielddetailsegview_alias1= new MetaTable("appfielddetailsegview_alias1");
	tappfielddetailsegview_alias1.defineColumn("appfielddetail_afteractivationprefill", typeof(string));
	tappfielddetailsegview_alias1.defineColumn("appfielddetail_afterrowselectprefill", typeof(string));
	tappfielddetailsegview_alias1.defineColumn("appfielddetail_calculatedfieldfunction", typeof(string));
	tappfielddetailsegview_alias1.defineColumn("appfielddetail_charnumber", typeof(int));
	tappfielddetailsegview_alias1.defineColumn("appfielddetail_columnname", typeof(string));
	tappfielddetailsegview_alias1.defineColumn("appfielddetail_defaultvalue", typeof(string));
	tappfielddetailsegview_alias1.defineColumn("appfielddetail_eventtext", typeof(string));
	tappfielddetailsegview_alias1.defineColumn("appfielddetail_eventtype", typeof(string));
	tappfielddetailsegview_alias1.defineColumn("appfielddetail_forcedropdown", typeof(string));
	tappfielddetailsegview_alias1.defineColumn("appfielddetail_forcekey", typeof(string));
	tappfielddetailsegview_alias1.defineColumn("appfielddetail_hidden", typeof(string));
	tappfielddetailsegview_alias1.defineColumn("appfielddetail_idappfielddetail_sortmember", typeof(int));
	tappfielddetailsegview_alias1.defineColumn("appfielddetail_idapptab", typeof(int));
	tappfielddetailsegview_alias1.defineColumn("appfielddetail_ischeckbox", typeof(string));
	tappfielddetailsegview_alias1.defineColumn("appfielddetail_islinkingobj", typeof(string));
	tappfielddetailsegview_alias1.defineColumn("appfielddetail_isnullable", typeof(string));
	tappfielddetailsegview_alias1.defineColumn("appfielddetail_listtype", typeof(string));
	tappfielddetailsegview_alias1.defineColumn("appfielddetail_master", typeof(string));
	tappfielddetailsegview_alias1.defineColumn("appfielddetail_max", typeof(int));
	tappfielddetailsegview_alias1.defineColumn("appfielddetail_min", typeof(int));
	tappfielddetailsegview_alias1.defineColumn("appfielddetail_position", typeof(int));
	tappfielddetailsegview_alias1.defineColumn("appfielddetail_radiovalues", typeof(string));
	tappfielddetailsegview_alias1.defineColumn("appfielddetail_readonlyfield", typeof(string));
	tappfielddetailsegview_alias1.defineColumn("appfielddetail_specialcontrol", typeof(string));
	tappfielddetailsegview_alias1.defineColumn("appfielddetail_sqltype", typeof(string));
	tappfielddetailsegview_alias1.defineColumn("appfielddetail_tablefilter", typeof(string));
	tappfielddetailsegview_alias1.defineColumn("appfielddetail_testexclude", typeof(string));
	tappfielddetailsegview_alias1.defineColumn("appfielddetail_testvalue", typeof(string));
	tappfielddetailsegview_alias1.defineColumn("appfielddetail_text", typeof(string));
	tappfielddetailsegview_alias1.defineColumn("appfielddetail_textarea", typeof(string));
	tappfielddetailsegview_alias1.defineColumn("appfielddetail_uniqueonrow", typeof(string));
	tappfielddetailsegview_alias1.defineColumn("appfielddetail_val1", typeof(int));
	tappfielddetailsegview_alias1.defineColumn("appfielddetail_val2", typeof(int));
	tappfielddetailsegview_alias1.defineColumn("appfielddetail_visible", typeof(string));
	tappfielddetailsegview_alias1.defineColumn("appfielddetailsortmember_title", typeof(string));
	tappfielddetailsegview_alias1.defineColumn("apptab_title", typeof(string));
	tappfielddetailsegview_alias1.defineColumn("dropdown_title", typeof(string),false);
	tappfielddetailsegview_alias1.defineColumn("idappfielddetail", typeof(int),false);
	tappfielddetailsegview_alias1.defineColumn("idapppages", typeof(int),false);
	tappfielddetailsegview_alias1.defineColumn("sqltype_datasettype", typeof(string));
	tappfielddetailsegview_alias1.defineColumn("sqltype_sqltype", typeof(string));
	tappfielddetailsegview_alias1.defineColumn("title", typeof(string));
	tappfielddetailsegview_alias1.ExtendedProperties["TableForReading"]="appfielddetailsegview";
	Tables.Add(tappfielddetailsegview_alias1);
	tappfielddetailsegview_alias1.defineKey("idappfielddetail", "idapppages");

	//////////////////// APPFIELDDETAILSEGVIEW /////////////////////////////////
	var tappfielddetailsegview= new MetaTable("appfielddetailsegview");
	tappfielddetailsegview.defineColumn("appfielddetail_afteractivationprefill", typeof(string));
	tappfielddetailsegview.defineColumn("appfielddetail_afterrowselectprefill", typeof(string));
	tappfielddetailsegview.defineColumn("appfielddetail_calculatedfieldfunction", typeof(string));
	tappfielddetailsegview.defineColumn("appfielddetail_charnumber", typeof(int));
	tappfielddetailsegview.defineColumn("appfielddetail_columnname", typeof(string));
	tappfielddetailsegview.defineColumn("appfielddetail_defaultvalue", typeof(string));
	tappfielddetailsegview.defineColumn("appfielddetail_eventtext", typeof(string));
	tappfielddetailsegview.defineColumn("appfielddetail_eventtype", typeof(string));
	tappfielddetailsegview.defineColumn("appfielddetail_forcedropdown", typeof(string));
	tappfielddetailsegview.defineColumn("appfielddetail_forcekey", typeof(string));
	tappfielddetailsegview.defineColumn("appfielddetail_hidden", typeof(string));
	tappfielddetailsegview.defineColumn("appfielddetail_idappfielddetail_sortmember", typeof(int));
	tappfielddetailsegview.defineColumn("appfielddetail_idapptab", typeof(int));
	tappfielddetailsegview.defineColumn("appfielddetail_ischeckbox", typeof(string));
	tappfielddetailsegview.defineColumn("appfielddetail_islinkingobj", typeof(string));
	tappfielddetailsegview.defineColumn("appfielddetail_isnullable", typeof(string));
	tappfielddetailsegview.defineColumn("appfielddetail_listtype", typeof(string));
	tappfielddetailsegview.defineColumn("appfielddetail_master", typeof(string));
	tappfielddetailsegview.defineColumn("appfielddetail_max", typeof(int));
	tappfielddetailsegview.defineColumn("appfielddetail_min", typeof(int));
	tappfielddetailsegview.defineColumn("appfielddetail_position", typeof(int));
	tappfielddetailsegview.defineColumn("appfielddetail_radiovalues", typeof(string));
	tappfielddetailsegview.defineColumn("appfielddetail_readonlyfield", typeof(string));
	tappfielddetailsegview.defineColumn("appfielddetail_specialcontrol", typeof(string));
	tappfielddetailsegview.defineColumn("appfielddetail_sqltype", typeof(string));
	tappfielddetailsegview.defineColumn("appfielddetail_tablefilter", typeof(string));
	tappfielddetailsegview.defineColumn("appfielddetail_testexclude", typeof(string));
	tappfielddetailsegview.defineColumn("appfielddetail_testvalue", typeof(string));
	tappfielddetailsegview.defineColumn("appfielddetail_text", typeof(string));
	tappfielddetailsegview.defineColumn("appfielddetail_textarea", typeof(string));
	tappfielddetailsegview.defineColumn("appfielddetail_uniqueonrow", typeof(string));
	tappfielddetailsegview.defineColumn("appfielddetail_val1", typeof(int));
	tappfielddetailsegview.defineColumn("appfielddetail_val2", typeof(int));
	tappfielddetailsegview.defineColumn("appfielddetail_visible", typeof(string));
	tappfielddetailsegview.defineColumn("appfielddetailsortmember_title", typeof(string));
	tappfielddetailsegview.defineColumn("apptab_title", typeof(string));
	tappfielddetailsegview.defineColumn("dropdown_title", typeof(string),false);
	tappfielddetailsegview.defineColumn("idappfielddetail", typeof(int),false);
	tappfielddetailsegview.defineColumn("idapppages", typeof(int),false);
	tappfielddetailsegview.defineColumn("sqltype_datasettype", typeof(string));
	tappfielddetailsegview.defineColumn("sqltype_sqltype", typeof(string));
	tappfielddetailsegview.defineColumn("title", typeof(string));
	Tables.Add(tappfielddetailsegview);
	tappfielddetailsegview.defineKey("idappfielddetail", "idapppages");

	//////////////////// APPFIELDMANDATORY /////////////////////////////////
	var tappfieldmandatory= new MetaTable("appfieldmandatory");
	tappfieldmandatory.defineColumn("idappfielddetail", typeof(int));
	tappfieldmandatory.defineColumn("idappfielddetail_master", typeof(int));
	tappfieldmandatory.defineColumn("idappfieldmandatory", typeof(int),false);
	tappfieldmandatory.defineColumn("idapppages", typeof(int),false);
	tappfieldmandatory.defineColumn("mastervalue", typeof(string));
	tappfieldmandatory.defineColumn("message", typeof(string));
	Tables.Add(tappfieldmandatory);
	tappfieldmandatory.defineKey("idappfieldmandatory", "idapppages");

	#endregion


	#region DataRelation creation
	var cPar = new []{appfielddetailsegview_alias1.Columns["idappfielddetail"]};
	var cChild = new []{appfieldmandatory.Columns["idappfielddetail_master"]};
	Relations.Add(new DataRelation("FK_appfieldmandatory_appfielddetailsegview_alias1_idappfielddetail_master",cPar,cChild,false));

	cPar = new []{appfielddetailsegview.Columns["idappfielddetail"]};
	cChild = new []{appfieldmandatory.Columns["idappfielddetail"]};
	Relations.Add(new DataRelation("FK_appfieldmandatory_appfielddetailsegview_idappfielddetail",cPar,cChild,false));

	#endregion

}
}
}
