
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
[System.Xml.Serialization.XmlRoot("dsmeta_pannellocambioperfstatus_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_pannellocambioperfstatus_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfschedastatusdefaultview_alias1 		=> (MetaTable)Tables["perfschedastatusdefaultview_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfschedastatusdefaultview 		=> (MetaTable)Tables["perfschedastatusdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable year 		=> (MetaTable)Tables["year"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pannellocambioperfstatus 		=> (MetaTable)Tables["pannellocambioperfstatus"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_pannellocambioperfstatus_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_pannellocambioperfstatus_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_pannellocambioperfstatus_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_pannellocambioperfstatus_default.xsd";

	#region create DataTables
	//////////////////// PERFSCHEDASTATUSDEFAULTVIEW_ALIAS1 /////////////////////////////////
	var tperfschedastatusdefaultview_alias1= new MetaTable("perfschedastatusdefaultview_alias1");
	tperfschedastatusdefaultview_alias1.defineColumn("dropdown_title", typeof(string),false);
	tperfschedastatusdefaultview_alias1.defineColumn("idperfschedastatus", typeof(int),false);
	tperfschedastatusdefaultview_alias1.defineColumn("perfschedastatus_active", typeof(string));
	tperfschedastatusdefaultview_alias1.ExtendedProperties["TableForReading"]="perfschedastatusdefaultview";
	Tables.Add(tperfschedastatusdefaultview_alias1);
	tperfschedastatusdefaultview_alias1.defineKey("idperfschedastatus");

	//////////////////// PERFSCHEDASTATUSDEFAULTVIEW /////////////////////////////////
	var tperfschedastatusdefaultview= new MetaTable("perfschedastatusdefaultview");
	tperfschedastatusdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tperfschedastatusdefaultview.defineColumn("idperfschedastatus", typeof(int),false);
	tperfschedastatusdefaultview.defineColumn("perfschedastatus_active", typeof(string));
	tperfschedastatusdefaultview.defineColumn("perfschedastatus_ct", typeof(DateTime),false);
	tperfschedastatusdefaultview.defineColumn("perfschedastatus_cu", typeof(string),false);
	tperfschedastatusdefaultview.defineColumn("perfschedastatus_description", typeof(string));
	tperfschedastatusdefaultview.defineColumn("perfschedastatus_lt", typeof(DateTime),false);
	tperfschedastatusdefaultview.defineColumn("perfschedastatus_lu", typeof(string),false);
	tperfschedastatusdefaultview.defineColumn("title", typeof(string));
	Tables.Add(tperfschedastatusdefaultview);
	tperfschedastatusdefaultview.defineKey("idperfschedastatus");

	//////////////////// YEAR /////////////////////////////////
	var tyear= new MetaTable("year");
	tyear.defineColumn("year", typeof(int),false);
	Tables.Add(tyear);
	tyear.defineKey("year");

	//////////////////// PANNELLOCAMBIOPERFSTATUS /////////////////////////////////
	var tpannellocambioperfstatus= new MetaTable("pannellocambioperfstatus");
	tpannellocambioperfstatus.defineColumn("idpannellocambioperfstatus", typeof(int),false);
	tpannellocambioperfstatus.defineColumn("idperfschedastatus", typeof(int));
	tpannellocambioperfstatus.defineColumn("idperfschedastatus_to", typeof(int));
	tpannellocambioperfstatus.defineColumn("schedakind", typeof(string));
	tpannellocambioperfstatus.defineColumn("year", typeof(int));
	Tables.Add(tpannellocambioperfstatus);
	tpannellocambioperfstatus.defineKey("idpannellocambioperfstatus");

	#endregion


	#region DataRelation creation
	var cPar = new []{perfschedastatusdefaultview_alias1.Columns["idperfschedastatus"]};
	var cChild = new []{pannellocambioperfstatus.Columns["idperfschedastatus_to"]};
	Relations.Add(new DataRelation("FK_pannellocambioperfstatus_perfschedastatusdefaultview_alias1_idperfschedastatus_to",cPar,cChild,false));

	cPar = new []{perfschedastatusdefaultview.Columns["idperfschedastatus"]};
	cChild = new []{pannellocambioperfstatus.Columns["idperfschedastatus"]};
	Relations.Add(new DataRelation("FK_pannellocambioperfstatus_perfschedastatusdefaultview_idperfschedastatus",cPar,cChild,false));

	cPar = new []{year.Columns["year"]};
	cChild = new []{pannellocambioperfstatus.Columns["year"]};
	Relations.Add(new DataRelation("FK_pannellocambioperfstatus_year_year",cPar,cChild,false));

	#endregion

}
}
}
