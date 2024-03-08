
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
[System.Xml.Serialization.XmlRoot("dsmeta_geo_region_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_geo_region_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_country_alias3 		=> (MetaTable)Tables["geo_country_alias3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_country_alias1 		=> (MetaTable)Tables["geo_country_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_country 		=> (MetaTable)Tables["geo_country"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_region_alias2 		=> (MetaTable)Tables["geo_region_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_region_alias1 		=> (MetaTable)Tables["geo_region_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_nation 		=> (MetaTable)Tables["geo_nation"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_region 		=> (MetaTable)Tables["geo_region"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_geo_region_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_geo_region_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_geo_region_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_geo_region_seg.xsd";

	#region create DataTables
	//////////////////// GEO_COUNTRY_ALIAS3 /////////////////////////////////
	var tgeo_country_alias3= new MetaTable("geo_country_alias3");
	tgeo_country_alias3.defineColumn("idcountry", typeof(int),false);
	tgeo_country_alias3.defineColumn("title", typeof(string));
	tgeo_country_alias3.ExtendedProperties["TableForReading"]="geo_country";
	Tables.Add(tgeo_country_alias3);
	tgeo_country_alias3.defineKey("idcountry");

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
	tgeo_country.defineColumn("!newcountry_geo_country_title", typeof(string));
	tgeo_country.defineColumn("!oldcountry_geo_country_title", typeof(string));
	Tables.Add(tgeo_country);
	tgeo_country.defineKey("idcountry");

	//////////////////// GEO_REGION_ALIAS2 /////////////////////////////////
	var tgeo_region_alias2= new MetaTable("geo_region_alias2");
	tgeo_region_alias2.defineColumn("idregion", typeof(int),false);
	tgeo_region_alias2.defineColumn("title", typeof(string));
	tgeo_region_alias2.ExtendedProperties["TableForReading"]="geo_region";
	Tables.Add(tgeo_region_alias2);
	tgeo_region_alias2.defineKey("idregion");

	//////////////////// GEO_REGION_ALIAS1 /////////////////////////////////
	var tgeo_region_alias1= new MetaTable("geo_region_alias1");
	tgeo_region_alias1.defineColumn("idregion", typeof(int),false);
	tgeo_region_alias1.defineColumn("title", typeof(string));
	tgeo_region_alias1.ExtendedProperties["TableForReading"]="geo_region";
	Tables.Add(tgeo_region_alias1);
	tgeo_region_alias1.defineKey("idregion");

	//////////////////// GEO_NATION /////////////////////////////////
	var tgeo_nation= new MetaTable("geo_nation");
	tgeo_nation.defineColumn("idnation", typeof(int),false);
	tgeo_nation.defineColumn("title", typeof(string));
	Tables.Add(tgeo_nation);
	tgeo_nation.defineKey("idnation");

	//////////////////// GEO_REGION /////////////////////////////////
	var tgeo_region= new MetaTable("geo_region");
	tgeo_region.defineColumn("idnation", typeof(int));
	tgeo_region.defineColumn("idregion", typeof(int),false);
	tgeo_region.defineColumn("lt", typeof(DateTime));
	tgeo_region.defineColumn("lu", typeof(string));
	tgeo_region.defineColumn("newregion", typeof(int));
	tgeo_region.defineColumn("oldregion", typeof(int));
	tgeo_region.defineColumn("start", typeof(DateTime));
	tgeo_region.defineColumn("stop", typeof(DateTime));
	tgeo_region.defineColumn("title", typeof(string));
	Tables.Add(tgeo_region);
	tgeo_region.defineKey("idregion");

	#endregion


	#region DataRelation creation
	var cPar = new []{geo_region.Columns["idregion"]};
	var cChild = new []{geo_country.Columns["idregion"]};
	Relations.Add(new DataRelation("FK_geo_country_geo_region_idregion",cPar,cChild,false));

	cPar = new []{geo_country_alias3.Columns["idcountry"]};
	cChild = new []{geo_country.Columns["oldcountry"]};
	Relations.Add(new DataRelation("FK_geo_country_geo_country_alias3_oldcountry",cPar,cChild,false));

	cPar = new []{geo_country_alias1.Columns["idcountry"]};
	cChild = new []{geo_country.Columns["newcountry"]};
	Relations.Add(new DataRelation("FK_geo_country_geo_country_alias1_newcountry",cPar,cChild,false));

	cPar = new []{geo_region_alias2.Columns["idregion"]};
	cChild = new []{geo_region.Columns["oldregion"]};
	Relations.Add(new DataRelation("FK_geo_region_geo_region_alias2_oldregion",cPar,cChild,false));

	cPar = new []{geo_region_alias1.Columns["idregion"]};
	cChild = new []{geo_region.Columns["newregion"]};
	Relations.Add(new DataRelation("FK_geo_region_geo_region_alias1_newregion",cPar,cChild,false));

	cPar = new []{geo_nation.Columns["idnation"]};
	cChild = new []{geo_region.Columns["idnation"]};
	Relations.Add(new DataRelation("FK_geo_region_geo_nation_idnation",cPar,cChild,false));

	#endregion

}
}
}
