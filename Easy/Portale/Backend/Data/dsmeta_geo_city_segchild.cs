
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
[System.Xml.Serialization.XmlRoot("dsmeta_geo_city_segchild"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_geo_city_segchild: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_city_alias2 		=> (MetaTable)Tables["geo_city_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_city_alias1 		=> (MetaTable)Tables["geo_city_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_city 		=> (MetaTable)Tables["geo_city"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_geo_city_segchild(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_geo_city_segchild (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_geo_city_segchild";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_geo_city_segchild.xsd";

	#region create DataTables
	//////////////////// GEO_CITY_ALIAS2 /////////////////////////////////
	var tgeo_city_alias2= new MetaTable("geo_city_alias2");
	tgeo_city_alias2.defineColumn("idcity", typeof(int),false);
	tgeo_city_alias2.defineColumn("title", typeof(string));
	tgeo_city_alias2.ExtendedProperties["TableForReading"]="geo_city";
	Tables.Add(tgeo_city_alias2);
	tgeo_city_alias2.defineKey("idcity");

	//////////////////// GEO_CITY_ALIAS1 /////////////////////////////////
	var tgeo_city_alias1= new MetaTable("geo_city_alias1");
	tgeo_city_alias1.defineColumn("idcity", typeof(int),false);
	tgeo_city_alias1.defineColumn("title", typeof(string));
	tgeo_city_alias1.ExtendedProperties["TableForReading"]="geo_city";
	Tables.Add(tgeo_city_alias1);
	tgeo_city_alias1.defineKey("idcity");

	//////////////////// GEO_CITY /////////////////////////////////
	var tgeo_city= new MetaTable("geo_city");
	tgeo_city.defineColumn("idcity", typeof(int),false);
	tgeo_city.defineColumn("idcountry", typeof(int));
	tgeo_city.defineColumn("lt", typeof(DateTime));
	tgeo_city.defineColumn("lu", typeof(string));
	tgeo_city.defineColumn("newcity", typeof(int));
	tgeo_city.defineColumn("oldcity", typeof(int));
	tgeo_city.defineColumn("start", typeof(DateTime));
	tgeo_city.defineColumn("stop", typeof(DateTime));
	tgeo_city.defineColumn("title", typeof(string));
	Tables.Add(tgeo_city);
	tgeo_city.defineKey("idcity");

	#endregion


	#region DataRelation creation
	var cPar = new []{geo_city_alias2.Columns["idcity"]};
	var cChild = new []{geo_city.Columns["oldcity"]};
	Relations.Add(new DataRelation("FK_geo_city_geo_city_alias2_oldcity",cPar,cChild,false));

	cPar = new []{geo_city_alias1.Columns["idcity"]};
	cChild = new []{geo_city.Columns["newcity"]};
	Relations.Add(new DataRelation("FK_geo_city_geo_city_alias1_newcity",cPar,cChild,false));

	#endregion

}
}
}
