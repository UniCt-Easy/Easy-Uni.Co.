
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
[System.Xml.Serialization.XmlRoot("dsmeta_geo_country_segchild"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_geo_country_segchild: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_country_alias2 		=> (MetaTable)Tables["geo_country_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_country_alias1 		=> (MetaTable)Tables["geo_country_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_country 		=> (MetaTable)Tables["geo_country"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_geo_country_segchild(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_geo_country_segchild (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_geo_country_segchild";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_geo_country_segchild.xsd";

	#region create DataTables
	//////////////////// GEO_COUNTRY_ALIAS2 /////////////////////////////////
	var tgeo_country_alias2= new MetaTable("geo_country_alias2");
	tgeo_country_alias2.defineColumn("idcountry", typeof(int),false);
	tgeo_country_alias2.defineColumn("title", typeof(string));
	tgeo_country_alias2.ExtendedProperties["TableForReading"]="geo_country";
	Tables.Add(tgeo_country_alias2);
	tgeo_country_alias2.defineKey("idcountry");

	//////////////////// GEO_COUNTRY_ALIAS1 /////////////////////////////////
	var tgeo_country_alias1= new MetaTable("geo_country_alias1");
	tgeo_country_alias1.defineColumn("idcountry", typeof(int),false);
	tgeo_country_alias1.defineColumn("title", typeof(string));
	tgeo_country_alias1.ExtendedProperties["TableForReading"]="geo_country";
	Tables.Add(tgeo_country_alias1);
	tgeo_country_alias1.defineKey("idcountry");

	//////////////////// GEO_COUNTRY /////////////////////////////////
	var tgeo_country= new MetaTable("geo_country");
	tgeo_country.defineColumn("idcountry", typeof(int),false);
	tgeo_country.defineColumn("idregion", typeof(int));
	tgeo_country.defineColumn("lt", typeof(DateTime));
	tgeo_country.defineColumn("lu", typeof(string));
	tgeo_country.defineColumn("newcountry", typeof(int));
	tgeo_country.defineColumn("oldcountry", typeof(int));
	tgeo_country.defineColumn("province", typeof(string));
	tgeo_country.defineColumn("start", typeof(DateTime));
	tgeo_country.defineColumn("stop", typeof(DateTime));
	tgeo_country.defineColumn("title", typeof(string));
	Tables.Add(tgeo_country);
	tgeo_country.defineKey("idcountry");

	#endregion


	#region DataRelation creation
	var cPar = new []{geo_country_alias2.Columns["idcountry"]};
	var cChild = new []{geo_country.Columns["oldcountry"]};
	Relations.Add(new DataRelation("FK_geo_country_geo_country_alias2_oldcountry",cPar,cChild,false));

	cPar = new []{geo_country_alias1.Columns["idcountry"]};
	cChild = new []{geo_country.Columns["newcountry"]};
	Relations.Add(new DataRelation("FK_geo_country_geo_country_alias1_newcountry",cPar,cChild,false));

	#endregion

}
}
}
