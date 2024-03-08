
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
[System.Xml.Serialization.XmlRoot("dsmeta_apppagestemplate_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_apppagestemplate_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attach 		=> (MetaTable)Tables["attach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable apppagesdefaultview 		=> (MetaTable)Tables["apppagesdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable apppagestemplate 		=> (MetaTable)Tables["apppagestemplate"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_apppagestemplate_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_apppagestemplate_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_apppagestemplate_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_apppagestemplate_default.xsd";

	#region create DataTables
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
	tattach.defineColumn("size", typeof(int),false);
	Tables.Add(tattach);
	tattach.defineKey("idattach");

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

	//////////////////// APPPAGESTEMPLATE /////////////////////////////////
	var tapppagestemplate= new MetaTable("apppagestemplate");
	tapppagestemplate.defineColumn("idapppages", typeof(int));
	tapppagestemplate.defineColumn("idapppagestemplate", typeof(int),false);
	tapppagestemplate.defineColumn("idattach", typeof(int));
	tapppagestemplate.defineColumn("idattach_2", typeof(int));
	tapppagestemplate.defineColumn("title", typeof(string));
	Tables.Add(tapppagestemplate);
	tapppagestemplate.defineKey("idapppagestemplate");

	#endregion


	#region DataRelation creation
	var cPar = new []{attach.Columns["idattach"]};
	var cChild = new []{apppagestemplate.Columns["idattach_2"]};
	Relations.Add(new DataRelation("FK_apppagestemplate_attach_idattach_2",cPar,cChild,false));

	cPar = new []{attach.Columns["idattach"]};
	cChild = new []{apppagestemplate.Columns["idattach"]};
	Relations.Add(new DataRelation("FK_apppagestemplate_attach_idattach",cPar,cChild,false));

	cPar = new []{apppagesdefaultview.Columns["idapppages"]};
	cChild = new []{apppagestemplate.Columns["idapppages"]};
	Relations.Add(new DataRelation("FK_apppagestemplate_apppagesdefaultview_idapppages",cPar,cChild,false));

	#endregion

}
}
}
