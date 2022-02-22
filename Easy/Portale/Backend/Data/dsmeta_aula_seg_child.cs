
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
[System.Xml.Serialization.XmlRoot("dsmeta_aula_seg_child"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_aula_seg_child: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_nation 		=> (MetaTable)Tables["geo_nation"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_city 		=> (MetaTable)Tables["geo_city"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable aulakinddefaultview 		=> (MetaTable)Tables["aulakinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturadefaultview 		=> (MetaTable)Tables["strutturadefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable aula 		=> (MetaTable)Tables["aula"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_aula_seg_child(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_aula_seg_child (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_aula_seg_child";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_aula_seg_child.xsd";

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

	//////////////////// AULAKINDDEFAULTVIEW /////////////////////////////////
	var taulakinddefaultview= new MetaTable("aulakinddefaultview");
	taulakinddefaultview.defineColumn("aulakind_active", typeof(string));
	taulakinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	taulakinddefaultview.defineColumn("idaulakind", typeof(int),false);
	Tables.Add(taulakinddefaultview);
	taulakinddefaultview.defineKey("idaulakind");

	//////////////////// STRUTTURADEFAULTVIEW /////////////////////////////////
	var tstrutturadefaultview= new MetaTable("strutturadefaultview");
	tstrutturadefaultview.defineColumn("dropdown_title", typeof(string),false);
	tstrutturadefaultview.defineColumn("idstruttura", typeof(int),false);
	tstrutturadefaultview.defineColumn("idupb", typeof(string));
	tstrutturadefaultview.defineColumn("paridstruttura", typeof(int));
	Tables.Add(tstrutturadefaultview);
	tstrutturadefaultview.defineKey("idstruttura");

	//////////////////// AULA /////////////////////////////////
	var taula= new MetaTable("aula");
	taula.defineColumn("address", typeof(string));
	taula.defineColumn("cap", typeof(string));
	taula.defineColumn("capienza", typeof(int));
	taula.defineColumn("capienzadis", typeof(int));
	taula.defineColumn("code", typeof(string));
	taula.defineColumn("ct", typeof(DateTime),false);
	taula.defineColumn("cu", typeof(string),false);
	taula.defineColumn("dotazioni", typeof(string));
	taula.defineColumn("idaula", typeof(int),false);
	taula.defineColumn("idaulakind", typeof(int));
	taula.defineColumn("idcity", typeof(int));
	taula.defineColumn("idedificio", typeof(int),false);
	taula.defineColumn("idnation", typeof(int));
	taula.defineColumn("idsede", typeof(int),false);
	taula.defineColumn("idstruttura", typeof(int));
	taula.defineColumn("latitude", typeof(decimal));
	taula.defineColumn("location", typeof(string));
	taula.defineColumn("longitude", typeof(decimal));
	taula.defineColumn("lt", typeof(DateTime),false);
	taula.defineColumn("lu", typeof(string),false);
	taula.defineColumn("title", typeof(string));
	Tables.Add(taula);
	taula.defineKey("idaula", "idedificio", "idsede");

	#endregion


	#region DataRelation creation
	var cPar = new []{geo_nation.Columns["idnation"]};
	var cChild = new []{aula.Columns["idnation"]};
	Relations.Add(new DataRelation("FK_aula_geo_nation_idnation",cPar,cChild,false));

	cPar = new []{geo_city.Columns["idcity"]};
	cChild = new []{aula.Columns["idcity"]};
	Relations.Add(new DataRelation("FK_aula_geo_city_idcity",cPar,cChild,false));

	cPar = new []{aulakinddefaultview.Columns["idaulakind"]};
	cChild = new []{aula.Columns["idaulakind"]};
	Relations.Add(new DataRelation("FK_aula_aulakinddefaultview_idaulakind",cPar,cChild,false));

	cPar = new []{strutturadefaultview.Columns["idstruttura"]};
	cChild = new []{aula.Columns["idstruttura"]};
	Relations.Add(new DataRelation("FK_aula_strutturadefaultview_idstruttura",cPar,cChild,false));

	#endregion

}
}
}
