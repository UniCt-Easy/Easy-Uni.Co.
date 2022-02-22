
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
[System.Xml.Serialization.XmlRoot("dsmeta_edificio_seg_child"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_edificio_seg_child: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_nation 		=> (MetaTable)Tables["geo_nation"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_city 		=> (MetaTable)Tables["geo_city"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable edificio 		=> (MetaTable)Tables["edificio"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_edificio_seg_child(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_edificio_seg_child (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_edificio_seg_child";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_edificio_seg_child.xsd";

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

	//////////////////// EDIFICIO /////////////////////////////////
	var tedificio= new MetaTable("edificio");
	tedificio.defineColumn("address", typeof(string));
	tedificio.defineColumn("cap", typeof(string));
	tedificio.defineColumn("code", typeof(string));
	tedificio.defineColumn("ct", typeof(DateTime),false);
	tedificio.defineColumn("cu", typeof(string),false);
	tedificio.defineColumn("idcity", typeof(int));
	tedificio.defineColumn("idedificio", typeof(int),false);
	tedificio.defineColumn("idnation", typeof(int));
	tedificio.defineColumn("idsede", typeof(int),false);
	tedificio.defineColumn("latitude", typeof(decimal));
	tedificio.defineColumn("location", typeof(string));
	tedificio.defineColumn("longitude", typeof(decimal));
	tedificio.defineColumn("lt", typeof(DateTime),false);
	tedificio.defineColumn("lu", typeof(string),false);
	tedificio.defineColumn("title", typeof(string));
	Tables.Add(tedificio);
	tedificio.defineKey("idedificio", "idsede");

	#endregion


	#region DataRelation creation
	var cPar = new []{geo_nation.Columns["idnation"]};
	var cChild = new []{edificio.Columns["idnation"]};
	Relations.Add(new DataRelation("FK_edificio_geo_nation_idnation",cPar,cChild,false));

	cPar = new []{geo_city.Columns["idcity"]};
	cChild = new []{edificio.Columns["idcity"]};
	Relations.Add(new DataRelation("FK_edificio_geo_city_idcity",cPar,cChild,false));

	#endregion

}
}
}
