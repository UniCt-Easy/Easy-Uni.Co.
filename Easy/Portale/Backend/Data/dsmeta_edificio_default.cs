
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
[System.Xml.Serialization.XmlRoot("dsmeta_edificio_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_edificio_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sospensione 		=> (MetaTable)Tables["sospensione"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturakind 		=> (MetaTable)Tables["strutturakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable struttura 		=> (MetaTable)Tables["struttura"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable aulakind 		=> (MetaTable)Tables["aulakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable aula 		=> (MetaTable)Tables["aula"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_nation 		=> (MetaTable)Tables["geo_nation"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_city 		=> (MetaTable)Tables["geo_city"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sededefaultview 		=> (MetaTable)Tables["sededefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable edificio 		=> (MetaTable)Tables["edificio"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_edificio_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_edificio_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_edificio_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_edificio_default.xsd";

	#region create DataTables
	//////////////////// SOSPENSIONE /////////////////////////////////
	var tsospensione= new MetaTable("sospensione");
	tsospensione.defineColumn("ct", typeof(DateTime),false);
	tsospensione.defineColumn("cu", typeof(string),false);
	tsospensione.defineColumn("idaula", typeof(int));
	tsospensione.defineColumn("idedificio", typeof(int),false);
	tsospensione.defineColumn("idreg", typeof(int));
	tsospensione.defineColumn("idsede", typeof(int),false);
	tsospensione.defineColumn("idsospensione", typeof(int),false);
	tsospensione.defineColumn("lt", typeof(DateTime),false);
	tsospensione.defineColumn("lu", typeof(string),false);
	tsospensione.defineColumn("motivo", typeof(string));
	tsospensione.defineColumn("start", typeof(DateTime),false);
	tsospensione.defineColumn("stop", typeof(DateTime));
	Tables.Add(tsospensione);
	tsospensione.defineKey("idedificio", "idsede", "idsospensione");

	//////////////////// STRUTTURAKIND /////////////////////////////////
	var tstrutturakind= new MetaTable("strutturakind");
	tstrutturakind.defineColumn("active", typeof(string),false);
	tstrutturakind.defineColumn("idstrutturakind", typeof(int),false);
	tstrutturakind.defineColumn("title", typeof(string),false);
	Tables.Add(tstrutturakind);
	tstrutturakind.defineKey("idstrutturakind");

	//////////////////// STRUTTURA /////////////////////////////////
	var tstruttura= new MetaTable("struttura");
	tstruttura.defineColumn("idstruttura", typeof(int),false);
	tstruttura.defineColumn("idstrutturakind", typeof(int),false);
	tstruttura.defineColumn("title", typeof(string));
	Tables.Add(tstruttura);
	tstruttura.defineKey("idstruttura");

	//////////////////// AULAKIND /////////////////////////////////
	var taulakind= new MetaTable("aulakind");
	taulakind.defineColumn("active", typeof(string),false);
	taulakind.defineColumn("idaulakind", typeof(int),false);
	taulakind.defineColumn("title", typeof(string),false);
	Tables.Add(taulakind);
	taulakind.defineKey("idaulakind");

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
	taula.defineColumn("!idaulakind_aulakind_title", typeof(string));
	taula.defineColumn("!idstruttura_struttura_title", typeof(string));
	taula.defineColumn("!idstruttura_struttura_idstrutturakind_title", typeof(string));
	Tables.Add(taula);
	taula.defineKey("idaula", "idedificio", "idsede");

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

	//////////////////// SEDEDEFAULTVIEW /////////////////////////////////
	var tsededefaultview= new MetaTable("sededefaultview");
	tsededefaultview.defineColumn("dropdown_title", typeof(string),false);
	tsededefaultview.defineColumn("idcity", typeof(int));
	tsededefaultview.defineColumn("idnation", typeof(int));
	tsededefaultview.defineColumn("idsede", typeof(int),false);
	Tables.Add(tsededefaultview);
	tsededefaultview.defineKey("idsede");

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
	var cPar = new []{edificio.Columns["idedificio"], edificio.Columns["idsede"]};
	var cChild = new []{sospensione.Columns["idedificio"], sospensione.Columns["idsede"]};
	Relations.Add(new DataRelation("FK_sospensione_edificio_idedificio-idsede",cPar,cChild,false));

	cPar = new []{edificio.Columns["idedificio"], edificio.Columns["idsede"]};
	cChild = new []{aula.Columns["idedificio"], aula.Columns["idsede"]};
	Relations.Add(new DataRelation("FK_aula_edificio_idedificio-idsede",cPar,cChild,false));

	cPar = new []{struttura.Columns["idstruttura"]};
	cChild = new []{aula.Columns["idstruttura"]};
	Relations.Add(new DataRelation("FK_aula_struttura_idstruttura",cPar,cChild,false));

	cPar = new []{strutturakind.Columns["idstrutturakind"]};
	cChild = new []{struttura.Columns["idstrutturakind"]};
	Relations.Add(new DataRelation("FK_struttura_strutturakind_idstrutturakind",cPar,cChild,false));

	cPar = new []{aulakind.Columns["idaulakind"]};
	cChild = new []{aula.Columns["idaulakind"]};
	Relations.Add(new DataRelation("FK_aula_aulakind_idaulakind",cPar,cChild,false));

	cPar = new []{geo_nation.Columns["idnation"]};
	cChild = new []{edificio.Columns["idnation"]};
	Relations.Add(new DataRelation("FK_edificio_geo_nation_idnation",cPar,cChild,false));

	cPar = new []{geo_city.Columns["idcity"]};
	cChild = new []{edificio.Columns["idcity"]};
	Relations.Add(new DataRelation("FK_edificio_geo_city_idcity",cPar,cChild,false));

	cPar = new []{sededefaultview.Columns["idsede"]};
	cChild = new []{edificio.Columns["idsede"]};
	Relations.Add(new DataRelation("FK_edificio_sededefaultview_idsede",cPar,cChild,false));

	#endregion

}
}
}
