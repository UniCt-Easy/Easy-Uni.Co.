
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
[System.Xml.Serialization.XmlRoot("dsmeta_registryaddress_anagraficasingle"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_registryaddress_anagraficasingle: DataSet {

	#region Table members declaration
	///<summary>
	///Tipo Indirizzo  (anagrafica)
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable address 		=> (MetaTable)Tables["address"];

	///<summary>
	///Comuni
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_city 		=> (MetaTable)Tables["geo_city"];

	///<summary>
	///Province
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_country 		=> (MetaTable)Tables["geo_country"];

	///<summary>
	///Regioni
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_region 		=> (MetaTable)Tables["geo_region"];

	///<summary>
	///Nazioni
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_nation 		=> (MetaTable)Tables["geo_nation"];

	///<summary>
	///Indirizzo di anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryaddress 		=> (MetaTable)Tables["registryaddress"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_nazione_alias 		=> (MetaTable)Tables["geo_nazione_alias"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_registryaddress_anagraficasingle(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_registryaddress_anagraficasingle (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_registryaddress_anagraficasingle";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_registryaddress_anagraficasingle.xsd";

	#region create DataTables
	//////////////////// ADDRESS /////////////////////////////////
	var taddress= new MetaTable("address");
	taddress.defineColumn("idaddress", typeof(int),false);
	taddress.defineColumn("codeaddress", typeof(string),false);
	taddress.defineColumn("description", typeof(string),false);
	taddress.defineColumn("lt", typeof(DateTime));
	taddress.defineColumn("lu", typeof(string));
	taddress.defineColumn("active", typeof(string));
	Tables.Add(taddress);
	taddress.defineKey("idaddress");

	//////////////////// GEO_CITY /////////////////////////////////
	var tgeo_city= new MetaTable("geo_city");
	tgeo_city.defineColumn("idcity", typeof(int),false);
	tgeo_city.defineColumn("oldcity", typeof(int));
	tgeo_city.defineColumn("newcity", typeof(int));
	tgeo_city.defineColumn("title", typeof(string));
	tgeo_city.defineColumn("start", typeof(DateTime));
	tgeo_city.defineColumn("stop", typeof(DateTime));
	tgeo_city.defineColumn("idcountry", typeof(int));
	tgeo_city.defineColumn("lu", typeof(string));
	tgeo_city.defineColumn("lt", typeof(DateTime));
	Tables.Add(tgeo_city);
	tgeo_city.defineKey("idcity");

	//////////////////// GEO_COUNTRY /////////////////////////////////
	var tgeo_country= new MetaTable("geo_country");
	tgeo_country.defineColumn("idcountry", typeof(int),false);
	tgeo_country.defineColumn("province", typeof(string));
	tgeo_country.defineColumn("title", typeof(string));
	tgeo_country.defineColumn("oldcountry", typeof(int));
	tgeo_country.defineColumn("newcountry", typeof(int));
	tgeo_country.defineColumn("start", typeof(DateTime));
	tgeo_country.defineColumn("stop", typeof(DateTime));
	tgeo_country.defineColumn("idregion", typeof(int));
	tgeo_country.defineColumn("lu", typeof(string));
	tgeo_country.defineColumn("lt", typeof(DateTime));
	Tables.Add(tgeo_country);
	tgeo_country.defineKey("idcountry");

	//////////////////// GEO_REGION /////////////////////////////////
	var tgeo_region= new MetaTable("geo_region");
	tgeo_region.defineColumn("idregion", typeof(int),false);
	tgeo_region.defineColumn("title", typeof(string));
	tgeo_region.defineColumn("start", typeof(DateTime));
	tgeo_region.defineColumn("stop", typeof(DateTime));
	tgeo_region.defineColumn("oldregion", typeof(int));
	tgeo_region.defineColumn("newregion", typeof(int));
	tgeo_region.defineColumn("idnation", typeof(int));
	tgeo_region.defineColumn("lu", typeof(string));
	tgeo_region.defineColumn("lt", typeof(DateTime));
	Tables.Add(tgeo_region);
	tgeo_region.defineKey("idregion");

	//////////////////// GEO_NATION /////////////////////////////////
	var tgeo_nation= new MetaTable("geo_nation");
	tgeo_nation.defineColumn("idnation", typeof(int),false);
	tgeo_nation.defineColumn("idcontinent", typeof(int));
	tgeo_nation.defineColumn("title", typeof(string));
	tgeo_nation.defineColumn("start", typeof(DateTime));
	tgeo_nation.defineColumn("stop", typeof(DateTime));
	tgeo_nation.defineColumn("oldnation", typeof(int));
	tgeo_nation.defineColumn("newnation", typeof(int));
	tgeo_nation.defineColumn("lu", typeof(string));
	tgeo_nation.defineColumn("lt", typeof(DateTime));
	Tables.Add(tgeo_nation);
	tgeo_nation.defineKey("idnation");

	//////////////////// REGISTRYADDRESS /////////////////////////////////
	var tregistryaddress= new MetaTable("registryaddress");
	tregistryaddress.defineColumn("idreg", typeof(int),false);
	tregistryaddress.defineColumn("start", typeof(DateTime),false);
	tregistryaddress.defineColumn("idaddresskind", typeof(int),false);
	tregistryaddress.defineColumn("annotations", typeof(string));
	tregistryaddress.defineColumn("ct", typeof(DateTime));
	tregistryaddress.defineColumn("cu", typeof(string));
	tregistryaddress.defineColumn("stop", typeof(DateTime));
	tregistryaddress.defineColumn("active", typeof(string));
	tregistryaddress.defineColumn("idcity", typeof(int));
	tregistryaddress.defineColumn("address", typeof(string));
	tregistryaddress.defineColumn("lt", typeof(DateTime));
	tregistryaddress.defineColumn("lu", typeof(string));
	tregistryaddress.defineColumn("officename", typeof(string));
	tregistryaddress.defineColumn("cap", typeof(string));
	tregistryaddress.defineColumn("flagforeign", typeof(string));
	tregistryaddress.defineColumn("location", typeof(string));
	tregistryaddress.defineColumn("idnation", typeof(int));
	tregistryaddress.defineColumn("!localita", typeof(string));
	tregistryaddress.defineColumn("recipientagency", typeof(string));
	Tables.Add(tregistryaddress);
	tregistryaddress.defineKey("idreg", "start", "idaddresskind");

	//////////////////// GEO_NAZIONE_ALIAS /////////////////////////////////
	var tgeo_nazione_alias= new MetaTable("geo_nazione_alias");
	tgeo_nazione_alias.defineColumn("idnation", typeof(int),false);
	tgeo_nazione_alias.defineColumn("idcontinent", typeof(int));
	tgeo_nazione_alias.defineColumn("title", typeof(string));
	tgeo_nazione_alias.defineColumn("start", typeof(DateTime));
	tgeo_nazione_alias.defineColumn("stop", typeof(DateTime));
	tgeo_nazione_alias.defineColumn("oldnation", typeof(int));
	tgeo_nazione_alias.defineColumn("newnation", typeof(int));
	tgeo_nazione_alias.defineColumn("lu", typeof(string));
	tgeo_nazione_alias.defineColumn("lt", typeof(DateTime));
	Tables.Add(tgeo_nazione_alias);
	tgeo_nazione_alias.defineKey("idnation");

	#endregion


	#region DataRelation creation
	var cPar = new []{address.Columns["idaddress"]};
	var cChild = new []{registryaddress.Columns["idaddresskind"]};
	Relations.Add(new DataRelation("addressregistryaddress",cPar,cChild,false));

	this.defineRelation("geo_cityregistryaddress","geo_city","registryaddress","idcity");
	this.defineRelation("geo_nazione_aliasregistryaddress","geo_nazione_alias","registryaddress","idnation");
	this.defineRelation("geo_nationgeo_region","geo_nation","geo_region","idnation");
	this.defineRelation("geo_regiongeo_country","geo_region","geo_country","idregion");
	this.defineRelation("geo_countrygeo_city","geo_country","geo_city","idcountry");
	#endregion

}
}
}
