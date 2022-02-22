
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
[System.Xml.Serialization.XmlRoot("dsmeta_customview_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_customview_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable customview 		=> (MetaTable)Tables["customview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable customviewcolumn 		=> (MetaTable)Tables["customviewcolumn"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable customvieworderby 		=> (MetaTable)Tables["customvieworderby"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable customviewwhere 		=> (MetaTable)Tables["customviewwhere"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable customoperator 		=> (MetaTable)Tables["customoperator"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable connector 		=> (MetaTable)Tables["connector"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable customdirection 		=> (MetaTable)Tables["customdirection"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable fieldtosum 		=> (MetaTable)Tables["fieldtosum"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_customview_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_customview_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_customview_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_customview_default.xsd";

	#region create DataTables
	//////////////////// CUSTOMVIEW /////////////////////////////////
	var tcustomview= new MetaTable("customview");
	tcustomview.defineColumn("objectname", typeof(string),false);
	tcustomview.defineColumn("viewname", typeof(string),false);
	tcustomview.defineColumn("isreal", typeof(string));
	tcustomview.defineColumn("issystem", typeof(string));
	tcustomview.defineColumn("staticfilter", typeof(string));
	tcustomview.defineColumn("lastmodtimestamp", typeof(DateTime));
	tcustomview.defineColumn("lastmoduser", typeof(string));
	tcustomview.defineColumn("createtimestamp", typeof(DateTime));
	tcustomview.defineColumn("createuser", typeof(string));
	Tables.Add(tcustomview);
	tcustomview.defineKey("objectname", "viewname");

	//////////////////// CUSTOMVIEWCOLUMN /////////////////////////////////
	var tcustomviewcolumn= new MetaTable("customviewcolumn");
	tcustomviewcolumn.defineColumn("objectname", typeof(string),false);
	tcustomviewcolumn.defineColumn("viewname", typeof(string),false);
	tcustomviewcolumn.defineColumn("colnumber", typeof(short),false);
	tcustomviewcolumn.defineColumn("heading", typeof(string));
	tcustomviewcolumn.defineColumn("colwidth", typeof(int));
	tcustomviewcolumn.defineColumn("visible", typeof(short),false);
	tcustomviewcolumn.defineColumn("fontname", typeof(string));
	tcustomviewcolumn.defineColumn("fontsize", typeof(short));
	tcustomviewcolumn.defineColumn("bold", typeof(short));
	tcustomviewcolumn.defineColumn("italic", typeof(short));
	tcustomviewcolumn.defineColumn("underline", typeof(short));
	tcustomviewcolumn.defineColumn("strikeout", typeof(short));
	tcustomviewcolumn.defineColumn("color", typeof(int));
	tcustomviewcolumn.defineColumn("format", typeof(string));
	tcustomviewcolumn.defineColumn("isreal", typeof(string));
	tcustomviewcolumn.defineColumn("expression", typeof(string));
	tcustomviewcolumn.defineColumn("colname", typeof(string));
	tcustomviewcolumn.defineColumn("systemtype", typeof(string));
	tcustomviewcolumn.defineColumn("lastmodtimestamp", typeof(DateTime));
	tcustomviewcolumn.defineColumn("lastmoduser", typeof(string));
	tcustomviewcolumn.defineColumn("createtimestamp", typeof(DateTime));
	tcustomviewcolumn.defineColumn("createuser", typeof(string));
	tcustomviewcolumn.defineColumn("listcolpos", typeof(short));
	Tables.Add(tcustomviewcolumn);
	tcustomviewcolumn.defineKey("objectname", "viewname", "colnumber");

	//////////////////// CUSTOMVIEWORDERBY /////////////////////////////////
	var tcustomvieworderby= new MetaTable("customvieworderby");
	tcustomvieworderby.defineColumn("objectname", typeof(string),false);
	tcustomvieworderby.defineColumn("viewname", typeof(string),false);
	tcustomvieworderby.defineColumn("periodnumber", typeof(short),false);
	tcustomvieworderby.defineColumn("columnname", typeof(string));
	tcustomvieworderby.defineColumn("direction", typeof(int));
	tcustomvieworderby.defineColumn("lastmodtimestamp", typeof(DateTime));
	tcustomvieworderby.defineColumn("lastmoduser", typeof(string));
	tcustomvieworderby.defineColumn("createtimestamp", typeof(DateTime));
	tcustomvieworderby.defineColumn("createuser", typeof(string));
	Tables.Add(tcustomvieworderby);
	tcustomvieworderby.defineKey("objectname", "viewname", "periodnumber");

	//////////////////// CUSTOMVIEWWHERE /////////////////////////////////
	var tcustomviewwhere= new MetaTable("customviewwhere");
	tcustomviewwhere.defineColumn("objectname", typeof(string),false);
	tcustomviewwhere.defineColumn("viewname", typeof(string),false);
	tcustomviewwhere.defineColumn("periodnumber", typeof(short),false);
	tcustomviewwhere.defineColumn("connector", typeof(int));
	tcustomviewwhere.defineColumn("columnname", typeof(string));
	tcustomviewwhere.defineColumn("operator", typeof(int));
	tcustomviewwhere.defineColumn("value", typeof(string));
	tcustomviewwhere.defineColumn("runtime", typeof(int));
	tcustomviewwhere.defineColumn("lastmodtimestamp", typeof(DateTime));
	tcustomviewwhere.defineColumn("lastmoduser", typeof(string));
	tcustomviewwhere.defineColumn("createtimestamp", typeof(DateTime));
	tcustomviewwhere.defineColumn("createuser", typeof(string));
	Tables.Add(tcustomviewwhere);
	tcustomviewwhere.defineKey("objectname", "viewname", "periodnumber");

	//////////////////// CUSTOMOPERATOR /////////////////////////////////
	var tcustomoperator= new MetaTable("customoperator");
	tcustomoperator.defineColumn("idoperator", typeof(int),false);
	tcustomoperator.defineColumn("name", typeof(string),false);
	tcustomoperator.defineColumn("lastmodtimestamp", typeof(DateTime));
	tcustomoperator.defineColumn("lastmoduser", typeof(string));
	Tables.Add(tcustomoperator);
	tcustomoperator.defineKey("idoperator");

	//////////////////// CONNECTOR /////////////////////////////////
	var tconnector= new MetaTable("connector");
	tconnector.defineColumn("idconnector", typeof(int),false);
	tconnector.defineColumn("name", typeof(string),false);
	Tables.Add(tconnector);
	tconnector.defineKey("idconnector");

	//////////////////// CUSTOMDIRECTION /////////////////////////////////
	var tcustomdirection= new MetaTable("customdirection");
	tcustomdirection.defineColumn("direction", typeof(int),false);
	tcustomdirection.defineColumn("valore", typeof(string));
	Tables.Add(tcustomdirection);

	//////////////////// FIELDTOSUM /////////////////////////////////
	var tfieldtosum= new MetaTable("fieldtosum");
	tfieldtosum.defineColumn("colname", typeof(string),false);
	tfieldtosum.defineColumn("flag", typeof(Boolean));
	Tables.Add(tfieldtosum);
	tfieldtosum.defineKey("colname");

	#endregion


	#region DataRelation creation
	var cPar = new []{customoperator.Columns["idoperator"]};
	var cChild = new []{customviewwhere.Columns["operator"]};
	Relations.Add(new DataRelation("customoperatorcustomviewwhere",cPar,cChild,false));

	cPar = new []{connector.Columns["idconnector"]};
	cChild = new []{customviewwhere.Columns["connector"]};
	Relations.Add(new DataRelation("connectorcustomviewwhere",cPar,cChild,false));

	cPar = new []{customview.Columns["objectname"], customview.Columns["viewname"]};
	cChild = new []{customviewwhere.Columns["objectname"], customviewwhere.Columns["viewname"]};
	Relations.Add(new DataRelation("customviewcustomviewwhere",cPar,cChild,false));

	cPar = new []{customview.Columns["objectname"], customview.Columns["viewname"]};
	cChild = new []{customvieworderby.Columns["objectname"], customvieworderby.Columns["viewname"]};
	Relations.Add(new DataRelation("customviewcustomvieworderby",cPar,cChild,false));

	cPar = new []{customview.Columns["objectname"], customview.Columns["viewname"]};
	cChild = new []{customviewcolumn.Columns["objectname"], customviewcolumn.Columns["viewname"]};
	Relations.Add(new DataRelation("customviewcustomviewcolumn",cPar,cChild,false));

	#endregion

}
}
}
