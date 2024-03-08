
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
[System.Xml.Serialization.XmlRoot("dsmeta_sede_seg_child_azienda"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_sede_seg_child_azienda: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_nation 		=> (MetaTable)Tables["geo_nation"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_city 		=> (MetaTable)Tables["geo_city"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sede 		=> (MetaTable)Tables["sede"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_sede_seg_child_azienda(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_sede_seg_child_azienda (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_sede_seg_child_azienda";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_sede_seg_child_azienda.xsd";

	#region create DataTables
	//////////////////// GEO_NATION /////////////////////////////////
	var tgeo_nation= new MetaTable("geo_nation");
	tgeo_nation.defineColumn("idnation", typeof(int),false);
	tgeo_nation.defineColumn("title", typeof(string));
	Tables.Add(tgeo_nation);
	tgeo_nation.defineKey("idnation");

	//////////////////// GEO_CITY /////////////////////////////////
	var tgeo_city= new MetaTable("geo_city");
	tgeo_city.defineColumn("idcity", typeof(int),false);
	tgeo_city.defineColumn("title", typeof(string));
	Tables.Add(tgeo_city);
	tgeo_city.defineKey("idcity");

	//////////////////// SEDE /////////////////////////////////
	var tsede= new MetaTable("sede");
	tsede.defineColumn("address", typeof(string));
	tsede.defineColumn("annotations", typeof(string));
	tsede.defineColumn("cap", typeof(string));
	tsede.defineColumn("ct", typeof(DateTime),false);
	tsede.defineColumn("cu", typeof(string),false);
	tsede.defineColumn("idcity", typeof(int));
	tsede.defineColumn("idnation", typeof(int));
	tsede.defineColumn("idreg", typeof(int));
	tsede.defineColumn("idsede", typeof(int),false);
	tsede.defineColumn("idsedemiur", typeof(int));
	tsede.defineColumn("latitude", typeof(decimal));
	tsede.defineColumn("longitude", typeof(decimal));
	tsede.defineColumn("lt", typeof(DateTime),false);
	tsede.defineColumn("lu", typeof(string),false);
	tsede.defineColumn("title", typeof(string));
	Tables.Add(tsede);
	tsede.defineKey("idsede");

	#endregion


	#region DataRelation creation
	var cPar = new []{geo_nation.Columns["idnation"]};
	var cChild = new []{sede.Columns["idnation"]};
	Relations.Add(new DataRelation("FK_sede_geo_nation_idnation",cPar,cChild,false));

	cPar = new []{geo_city.Columns["idcity"]};
	cChild = new []{sede.Columns["idcity"]};
	Relations.Add(new DataRelation("FK_sede_geo_city_idcity",cPar,cChild,false));

	#endregion

}
}
}
