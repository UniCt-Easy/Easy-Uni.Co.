
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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
[System.Xml.Serialization.XmlRoot("dsmeta_geo_continent_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_geo_continent_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_nation_alias3 		=> (MetaTable)Tables["geo_nation_alias3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_nation_alias1 		=> (MetaTable)Tables["geo_nation_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_nation 		=> (MetaTable)Tables["geo_nation"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_continent 		=> (MetaTable)Tables["geo_continent"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_geo_continent_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_geo_continent_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_geo_continent_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_geo_continent_default.xsd";

	#region create DataTables
	//////////////////// GEO_NATION_ALIAS3 /////////////////////////////////
	var tgeo_nation_alias3= new MetaTable("geo_nation_alias3");
	tgeo_nation_alias3.defineColumn("idnation", typeof(int),false);
	tgeo_nation_alias3.defineColumn("title", typeof(string));
	tgeo_nation_alias3.ExtendedProperties["TableForReading"]="geo_nation";
	Tables.Add(tgeo_nation_alias3);
	tgeo_nation_alias3.defineKey("idnation");

	//////////////////// GEO_NATION_ALIAS1 /////////////////////////////////
	var tgeo_nation_alias1= new MetaTable("geo_nation_alias1");
	tgeo_nation_alias1.defineColumn("idnation", typeof(int),false);
	tgeo_nation_alias1.defineColumn("title", typeof(string));
	tgeo_nation_alias1.ExtendedProperties["TableForReading"]="geo_nation";
	Tables.Add(tgeo_nation_alias1);
	tgeo_nation_alias1.defineKey("idnation");

	//////////////////// GEO_NATION /////////////////////////////////
	var tgeo_nation= new MetaTable("geo_nation");
	tgeo_nation.defineColumn("idcontinent", typeof(int));
	tgeo_nation.defineColumn("idnation", typeof(int),false);
	tgeo_nation.defineColumn("lang", typeof(string));
	tgeo_nation.defineColumn("lt", typeof(DateTime));
	tgeo_nation.defineColumn("lu", typeof(string));
	tgeo_nation.defineColumn("newnation", typeof(int));
	tgeo_nation.defineColumn("oldnation", typeof(int));
	tgeo_nation.defineColumn("start", typeof(DateTime));
	tgeo_nation.defineColumn("stop", typeof(DateTime));
	tgeo_nation.defineColumn("title", typeof(string));
	tgeo_nation.defineColumn("!newnation_geo_nation_title", typeof(string));
	tgeo_nation.defineColumn("!oldnation_geo_nation_title", typeof(string));
	tgeo_nation.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tgeo_nation);
	tgeo_nation.defineKey("idnation");

	//////////////////// GEO_CONTINENT /////////////////////////////////
	var tgeo_continent= new MetaTable("geo_continent");
	tgeo_continent.defineColumn("idcontinent", typeof(int),false);
	tgeo_continent.defineColumn("title", typeof(string));
	tgeo_continent.defineColumn("title_EN", typeof(string));
	Tables.Add(tgeo_continent);
	tgeo_continent.defineKey("idcontinent");

	#endregion


	#region DataRelation creation
	var cPar = new []{geo_continent.Columns["idcontinent"]};
	var cChild = new []{geo_nation.Columns["idcontinent"]};
	Relations.Add(new DataRelation("FK_geo_nation_geo_continent_idcontinent",cPar,cChild,false));

	cPar = new []{geo_nation_alias3.Columns["idnation"]};
	cChild = new []{geo_nation.Columns["oldnation"]};
	Relations.Add(new DataRelation("FK_geo_nation_geo_nation_alias3_oldnation",cPar,cChild,false));

	cPar = new []{geo_nation_alias1.Columns["idnation"]};
	cChild = new []{geo_nation.Columns["newnation"]};
	Relations.Add(new DataRelation("FK_geo_nation_geo_nation_alias1_newnation",cPar,cChild,false));

	#endregion

}
}
}