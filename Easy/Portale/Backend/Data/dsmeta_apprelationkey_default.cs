
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
[System.Xml.Serialization.XmlRoot("dsmeta_apprelationkey_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_apprelationkey_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable appfielddetaildefaultview_alias1 		=> (MetaTable)Tables["appfielddetaildefaultview_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable appfielddetaildefaultview 		=> (MetaTable)Tables["appfielddetaildefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable apprelationkey 		=> (MetaTable)Tables["apprelationkey"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_apprelationkey_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_apprelationkey_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_apprelationkey_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_apprelationkey_default.xsd";

	#region create DataTables
	//////////////////// APPFIELDDETAILDEFAULTVIEW_ALIAS1 /////////////////////////////////
	var tappfielddetaildefaultview_alias1= new MetaTable("appfielddetaildefaultview_alias1");
	tappfielddetaildefaultview_alias1.defineColumn("appfielddetail_afteractivationprefill", typeof(string));
	tappfielddetaildefaultview_alias1.defineColumn("appfielddetail_afterrowselectprefill", typeof(string));
	tappfielddetaildefaultview_alias1.defineColumn("appfielddetail_calculatedfieldfunction", typeof(string));
	tappfielddetaildefaultview_alias1.defineColumn("appfielddetail_charnumber", typeof(int));
	tappfielddetaildefaultview_alias1.defineColumn("appfielddetail_defaultvalue", typeof(string));
	tappfielddetaildefaultview_alias1.defineColumn("appfielddetail_eventtext", typeof(string));
	tappfielddetaildefaultview_alias1.defineColumn("appfielddetail_eventtype", typeof(string));
	tappfielddetaildefaultview_alias1.defineColumn("appfielddetail_forcedropdown", typeof(string));
	tappfielddetaildefaultview_alias1.defineColumn("appfielddetail_forcekey", typeof(string));
	tappfielddetaildefaultview_alias1.defineColumn("appfielddetail_hidden", typeof(string));
	tappfielddetaildefaultview_alias1.defineColumn("appfielddetail_idappfielddetail_sortmember", typeof(int));
	tappfielddetaildefaultview_alias1.defineColumn("appfielddetail_idapptab", typeof(int));
	tappfielddetaildefaultview_alias1.defineColumn("appfielddetail_ischeckbox", typeof(string));
	tappfielddetaildefaultview_alias1.defineColumn("appfielddetail_islinkingobj", typeof(string));
	tappfielddetaildefaultview_alias1.defineColumn("appfielddetail_isnullable", typeof(string));
	tappfielddetaildefaultview_alias1.defineColumn("appfielddetail_listtype", typeof(string));
	tappfielddetaildefaultview_alias1.defineColumn("appfielddetail_master", typeof(string));
	tappfielddetaildefaultview_alias1.defineColumn("appfielddetail_max", typeof(int));
	tappfielddetaildefaultview_alias1.defineColumn("appfielddetail_min", typeof(int));
	tappfielddetaildefaultview_alias1.defineColumn("appfielddetail_position", typeof(int));
	tappfielddetaildefaultview_alias1.defineColumn("appfielddetail_radiovalues", typeof(string));
	tappfielddetaildefaultview_alias1.defineColumn("appfielddetail_readonlyfield", typeof(string));
	tappfielddetaildefaultview_alias1.defineColumn("appfielddetail_specialcontrol", typeof(string));
	tappfielddetaildefaultview_alias1.defineColumn("appfielddetail_sqltype", typeof(string));
	tappfielddetaildefaultview_alias1.defineColumn("appfielddetail_tablefilter", typeof(string));
	tappfielddetaildefaultview_alias1.defineColumn("appfielddetail_testvalue", typeof(string));
	tappfielddetaildefaultview_alias1.defineColumn("appfielddetail_text", typeof(string));
	tappfielddetaildefaultview_alias1.defineColumn("appfielddetail_textarea", typeof(string));
	tappfielddetaildefaultview_alias1.defineColumn("appfielddetail_title", typeof(string));
	tappfielddetaildefaultview_alias1.defineColumn("appfielddetail_uniqueonrow", typeof(string));
	tappfielddetaildefaultview_alias1.defineColumn("appfielddetail_val1", typeof(int));
	tappfielddetaildefaultview_alias1.defineColumn("appfielddetail_val2", typeof(int));
	tappfielddetaildefaultview_alias1.defineColumn("appfielddetail_visible", typeof(string));
	tappfielddetaildefaultview_alias1.defineColumn("appfielddetailsortmember_columnname", typeof(string));
	tappfielddetaildefaultview_alias1.defineColumn("appfielddetailsortmember_title", typeof(string));
	tappfielddetaildefaultview_alias1.defineColumn("apptab_title", typeof(string));
	tappfielddetaildefaultview_alias1.defineColumn("columnname", typeof(string));
	tappfielddetaildefaultview_alias1.defineColumn("dropdown_title", typeof(string),false);
	tappfielddetaildefaultview_alias1.defineColumn("idappfielddetail", typeof(int),false);
	tappfielddetaildefaultview_alias1.defineColumn("idapppages", typeof(int),false);
	tappfielddetaildefaultview_alias1.defineColumn("sqltype_datasettype", typeof(string));
	tappfielddetaildefaultview_alias1.defineColumn("sqltype_sqltype", typeof(string));
	tappfielddetaildefaultview_alias1.ExtendedProperties["TableForReading"]="appfielddetaildefaultview";
	Tables.Add(tappfielddetaildefaultview_alias1);
	tappfielddetaildefaultview_alias1.defineKey("idappfielddetail", "idapppages");

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

	//////////////////// APPRELATIONKEY /////////////////////////////////
	var tapprelationkey= new MetaTable("apprelationkey");
	tapprelationkey.defineColumn("idappfielddetail", typeof(int));
	tapprelationkey.defineColumn("idappfielddetail_par", typeof(int));
	tapprelationkey.defineColumn("idapppages", typeof(int),false);
	tapprelationkey.defineColumn("idapprelation", typeof(int),false);
	tapprelationkey.defineColumn("idapprelationkey", typeof(int),false);
	Tables.Add(tapprelationkey);
	tapprelationkey.defineKey("idapppages", "idapprelation", "idapprelationkey");

	#endregion


	#region DataRelation creation
	var cPar = new []{appfielddetaildefaultview_alias1.Columns["idappfielddetail"]};
	var cChild = new []{apprelationkey.Columns["idappfielddetail_par"]};
	Relations.Add(new DataRelation("FK_apprelationkey_appfielddetaildefaultview_alias1_idappfielddetail_par",cPar,cChild,false));

	cPar = new []{appfielddetaildefaultview.Columns["idappfielddetail"]};
	cChild = new []{apprelationkey.Columns["idappfielddetail"]};
	Relations.Add(new DataRelation("FK_apprelationkey_appfielddetaildefaultview_idappfielddetail",cPar,cChild,false));

	#endregion

}
}
}
