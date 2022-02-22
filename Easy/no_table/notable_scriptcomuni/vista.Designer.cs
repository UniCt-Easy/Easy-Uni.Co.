
/*
Easy
Copyright (C) 2022 Universit‡ degli Studi di Catania (www.unict.it)
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
using meta_geo_city;
using meta_geo_country;
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace notable_scriptcomuni {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable no_table 		=> (MetaTable)Tables["no_table"];

	///<summary>
	///Comuni
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public geo_cityTable geo_city 		=> (geo_cityTable)Tables["geo_city"];

	///<summary>
	///Codice per un comune
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_city_agency 		=> (MetaTable)Tables["geo_city_agency"];

	///<summary>
	///Associazione citt√† - cap
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_cap 		=> (MetaTable)Tables["geo_cap"];

	///<summary>
	///Province
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public geo_countryTable geo_country 		=> (geo_countryTable)Tables["geo_country"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_city_codeview 		=> (MetaTable)Tables["geo_city_codeview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable taxratecitystartview 		=> (MetaTable)Tables["taxratecitystartview"];

	///<summary>
	///Struttura Imposta Comunale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable taxratecitystart 		=> (MetaTable)Tables["taxratecitystart"];

	///<summary>
	///Scaglioni Imposta Comunale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable taxratecitybracket 		=> (MetaTable)Tables["taxratecitybracket"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta.xsd";

	#region create DataTables
	//////////////////// NO_TABLE /////////////////////////////////
	var tno_table= new MetaTable("no_table");
	tno_table.defineColumn("id_no_table", typeof(int),false);
	Tables.Add(tno_table);

	//////////////////// GEO_CITY /////////////////////////////////
	var tgeo_city= new geo_cityTable();
	tgeo_city.addBaseColumns("idcity","idcountry","lt","lu","newcity","oldcity","start","stop","title");
	Tables.Add(tgeo_city);
	tgeo_city.defineKey("idcity");

	//////////////////// GEO_CITY_AGENCY /////////////////////////////////
	var tgeo_city_agency= new MetaTable("geo_city_agency");
	tgeo_city_agency.defineColumn("idagency", typeof(int),false);
	tgeo_city_agency.defineColumn("idcity", typeof(int),false);
	tgeo_city_agency.defineColumn("idcode", typeof(int),false);
	tgeo_city_agency.defineColumn("version", typeof(int),false);
	tgeo_city_agency.defineColumn("lt", typeof(DateTime));
	tgeo_city_agency.defineColumn("lu", typeof(string));
	tgeo_city_agency.defineColumn("start", typeof(DateTime));
	tgeo_city_agency.defineColumn("stop", typeof(DateTime));
	tgeo_city_agency.defineColumn("value", typeof(string));
	Tables.Add(tgeo_city_agency);
	tgeo_city_agency.defineKey("idagency", "idcity", "idcode", "version");

	//////////////////// GEO_CAP /////////////////////////////////
	var tgeo_cap= new MetaTable("geo_cap");
	tgeo_cap.defineColumn("cap", typeof(string),false);
	tgeo_cap.defineColumn("idcity", typeof(int),false);
	Tables.Add(tgeo_cap);
	tgeo_cap.defineKey("cap");

	//////////////////// GEO_COUNTRY /////////////////////////////////
	var tgeo_country= new geo_countryTable();
	tgeo_country.addBaseColumns("idcountry","idregion","lt","lu","newcountry","oldcountry","province","start","stop","title");
	Tables.Add(tgeo_country);
	tgeo_country.defineKey("idcountry");

	//////////////////// GEO_CITY_CODEVIEW /////////////////////////////////
	var tgeo_city_codeview= new MetaTable("geo_city_codeview");
	tgeo_city_codeview.defineColumn("idcity", typeof(int),false);
	tgeo_city_codeview.defineColumn("title", typeof(string));
	tgeo_city_codeview.defineColumn("oldcity", typeof(int));
	tgeo_city_codeview.defineColumn("newcity", typeof(int));
	tgeo_city_codeview.defineColumn("start", typeof(DateTime));
	tgeo_city_codeview.defineColumn("stop", typeof(DateTime));
	tgeo_city_codeview.defineColumn("idcountry", typeof(int));
	tgeo_city_codeview.defineColumn("idregion", typeof(int));
	tgeo_city_codeview.defineColumn("idnation", typeof(int));
	tgeo_city_codeview.defineColumn("idcontinent", typeof(int));
	tgeo_city_codeview.defineColumn("provincecode", typeof(string));
	tgeo_city_codeview.defineColumn("country", typeof(string));
	tgeo_city_codeview.defineColumn("region", typeof(string));
	tgeo_city_codeview.defineColumn("nation", typeof(string));
	tgeo_city_codeview.defineColumn("catastale", typeof(string));
	tgeo_city_codeview.defineColumn("nazionale", typeof(string));
	tgeo_city_codeview.defineColumn("istat", typeof(string));
	tgeo_city_codeview.defineColumn("cap", typeof(string));
	tgeo_city_codeview.defineColumn("successiva", typeof(string));
	tgeo_city_codeview.defineColumn("precedente", typeof(string));
	Tables.Add(tgeo_city_codeview);
	tgeo_city_codeview.defineKey("idcity");

	//////////////////// TAXRATECITYSTARTVIEW /////////////////////////////////
	var ttaxratecitystartview= new MetaTable("taxratecitystartview");
	ttaxratecitystartview.defineColumn("taxcode", typeof(int),false);
	ttaxratecitystartview.defineColumn("taxref", typeof(string),false);
	ttaxratecitystartview.defineColumn("idcity", typeof(int),false);
	ttaxratecitystartview.defineColumn("idtaxratecitystart", typeof(int),false);
	ttaxratecitystartview.defineColumn("city", typeof(string));
	ttaxratecitystartview.defineColumn("idcountry", typeof(int),false);
	ttaxratecitystartview.defineColumn("country", typeof(string));
	ttaxratecitystartview.defineColumn("start", typeof(DateTime),false);
	ttaxratecitystartview.defineColumn("enforcement", typeof(string));
	ttaxratecitystartview.defineColumn("annotations", typeof(string));
	ttaxratecitystartview.defineColumn("min1", typeof(decimal));
	ttaxratecitystartview.defineColumn("max1", typeof(decimal));
	ttaxratecitystartview.defineColumn("rate1", typeof(decimal));
	ttaxratecitystartview.defineColumn("min2", typeof(decimal));
	ttaxratecitystartview.defineColumn("max2", typeof(decimal));
	ttaxratecitystartview.defineColumn("rate2", typeof(decimal));
	ttaxratecitystartview.defineColumn("min3", typeof(decimal));
	ttaxratecitystartview.defineColumn("max3", typeof(decimal));
	ttaxratecitystartview.defineColumn("rate3", typeof(decimal));
	ttaxratecitystartview.defineColumn("min4", typeof(decimal));
	ttaxratecitystartview.defineColumn("max4", typeof(decimal));
	ttaxratecitystartview.defineColumn("rate4", typeof(decimal));
	ttaxratecitystartview.defineColumn("min5", typeof(decimal));
	ttaxratecitystartview.defineColumn("max5", typeof(decimal));
	ttaxratecitystartview.defineColumn("rate5", typeof(decimal));
	ttaxratecitystartview.defineColumn("taxablemin", typeof(decimal));
	Tables.Add(ttaxratecitystartview);
	ttaxratecitystartview.defineKey("idcity", "idtaxratecitystart");

	//////////////////// TAXRATECITYSTART /////////////////////////////////
	var ttaxratecitystart= new MetaTable("taxratecitystart");
	ttaxratecitystart.defineColumn("idcity", typeof(int),false);
	ttaxratecitystart.defineColumn("idtaxratecitystart", typeof(int),false);
	ttaxratecitystart.defineColumn("start", typeof(DateTime),false);
	ttaxratecitystart.defineColumn("lt", typeof(DateTime),false);
	ttaxratecitystart.defineColumn("lu", typeof(string),false);
	ttaxratecitystart.defineColumn("enforcement", typeof(string));
	ttaxratecitystart.defineColumn("annotations", typeof(string));
	ttaxratecitystart.defineColumn("taxcode", typeof(int),false);
	ttaxratecitystart.defineColumn("taxablemin", typeof(decimal));
	Tables.Add(ttaxratecitystart);
	ttaxratecitystart.defineKey("idcity", "idtaxratecitystart", "taxcode");

	//////////////////// TAXRATECITYBRACKET /////////////////////////////////
	var ttaxratecitybracket= new MetaTable("taxratecitybracket");
	ttaxratecitybracket.defineColumn("idcity", typeof(int),false);
	ttaxratecitybracket.defineColumn("idtaxratecitystart", typeof(int),false);
	ttaxratecitybracket.defineColumn("nbracket", typeof(int),false);
	ttaxratecitybracket.defineColumn("minamount", typeof(decimal));
	ttaxratecitybracket.defineColumn("maxamount", typeof(decimal));
	ttaxratecitybracket.defineColumn("rate", typeof(decimal),false);
	ttaxratecitybracket.defineColumn("lt", typeof(DateTime),false);
	ttaxratecitybracket.defineColumn("lu", typeof(string));
	ttaxratecitybracket.defineColumn("taxcode", typeof(int),false);
	Tables.Add(ttaxratecitybracket);
	ttaxratecitybracket.defineKey("idcity", "idtaxratecitystart", "nbracket", "taxcode");

	#endregion

}
}
}
