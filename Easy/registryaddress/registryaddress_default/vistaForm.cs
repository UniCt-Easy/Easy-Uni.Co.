
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace registryaddress_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry 		=> Tables["registry"];

	///<summary>
	///Tipo Indirizzo  (anagrafica)
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable address 		=> Tables["address"];

	///<summary>
	///Comuni
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable geo_city 		=> Tables["geo_city"];

	///<summary>
	///Province
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable geo_country 		=> Tables["geo_country"];

	///<summary>
	///Regioni
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable geo_region 		=> Tables["geo_region"];

	///<summary>
	///Nazioni
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable geo_nation 		=> Tables["geo_nation"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable geo_cityview 		=> Tables["geo_cityview"];

	///<summary>
	///Indirizzo di anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registryaddress 		=> Tables["registryaddress"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registryaddressview 		=> Tables["registryaddressview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable geo_nazione_alias 		=> Tables["geo_nazione_alias"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registrymainview 		=> Tables["registrymainview"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public vistaForm(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected vistaForm (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "vistaForm";
	Prefix = "";
	Namespace = "http://tempuri.org/vistaForm.xsd";

	#region create DataTables
	DataColumn C;
	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new DataTable("registry");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("cf", typeof(string)));
	tregistry.Columns.Add( new DataColumn("p_iva", typeof(string)));
	C= new DataColumn("residence", typeof(int));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("annotation", typeof(string)));
	tregistry.Columns.Add( new DataColumn("birthdate", typeof(DateTime)));
	tregistry.Columns.Add( new DataColumn("gender", typeof(string)));
	tregistry.Columns.Add( new DataColumn("surname", typeof(string)));
	tregistry.Columns.Add( new DataColumn("forename", typeof(string)));
	tregistry.Columns.Add( new DataColumn("foreigncf", typeof(string)));
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("txt", typeof(string)));
	tregistry.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("badgecode", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcategory", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcentralizedcategory", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idmaritalstatus", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idtitle", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idregistryclass", typeof(string)));
	tregistry.Columns.Add( new DataColumn("maritalsurname", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcity", typeof(int)));
	tregistry.Columns.Add( new DataColumn("extmatricula", typeof(string)));
	Tables.Add(tregistry);
	tregistry.PrimaryKey =  new DataColumn[]{tregistry.Columns["idreg"]};


	//////////////////// ADDRESS /////////////////////////////////
	var taddress= new DataTable("address");
	C= new DataColumn("idaddress", typeof(int));
	C.AllowDBNull=false;
	taddress.Columns.Add(C);
	C= new DataColumn("codeaddress", typeof(string));
	C.AllowDBNull=false;
	taddress.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	taddress.Columns.Add(C);
	taddress.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	taddress.Columns.Add( new DataColumn("lu", typeof(string)));
	taddress.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(taddress);
	taddress.PrimaryKey =  new DataColumn[]{taddress.Columns["idaddress"]};


	//////////////////// GEO_CITY /////////////////////////////////
	var tgeo_city= new DataTable("geo_city");
	C= new DataColumn("idcity", typeof(int));
	C.AllowDBNull=false;
	tgeo_city.Columns.Add(C);
	tgeo_city.Columns.Add( new DataColumn("oldcity", typeof(int)));
	tgeo_city.Columns.Add( new DataColumn("newcity", typeof(int)));
	tgeo_city.Columns.Add( new DataColumn("title", typeof(string)));
	tgeo_city.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tgeo_city.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tgeo_city.Columns.Add( new DataColumn("idcountry", typeof(int)));
	tgeo_city.Columns.Add( new DataColumn("lu", typeof(string)));
	tgeo_city.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	Tables.Add(tgeo_city);
	tgeo_city.PrimaryKey =  new DataColumn[]{tgeo_city.Columns["idcity"]};


	//////////////////// GEO_COUNTRY /////////////////////////////////
	var tgeo_country= new DataTable("geo_country");
	C= new DataColumn("idcountry", typeof(int));
	C.AllowDBNull=false;
	tgeo_country.Columns.Add(C);
	tgeo_country.Columns.Add( new DataColumn("province", typeof(string)));
	tgeo_country.Columns.Add( new DataColumn("title", typeof(string)));
	tgeo_country.Columns.Add( new DataColumn("oldcountry", typeof(int)));
	tgeo_country.Columns.Add( new DataColumn("newcountry", typeof(int)));
	tgeo_country.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tgeo_country.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tgeo_country.Columns.Add( new DataColumn("idregion", typeof(int)));
	tgeo_country.Columns.Add( new DataColumn("lu", typeof(string)));
	tgeo_country.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	Tables.Add(tgeo_country);
	tgeo_country.PrimaryKey =  new DataColumn[]{tgeo_country.Columns["idcountry"]};


	//////////////////// GEO_REGION /////////////////////////////////
	var tgeo_region= new DataTable("geo_region");
	C= new DataColumn("idregion", typeof(int));
	C.AllowDBNull=false;
	tgeo_region.Columns.Add(C);
	tgeo_region.Columns.Add( new DataColumn("title", typeof(string)));
	tgeo_region.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tgeo_region.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tgeo_region.Columns.Add( new DataColumn("oldregion", typeof(int)));
	tgeo_region.Columns.Add( new DataColumn("newregion", typeof(int)));
	tgeo_region.Columns.Add( new DataColumn("idnation", typeof(int)));
	tgeo_region.Columns.Add( new DataColumn("lu", typeof(string)));
	tgeo_region.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	Tables.Add(tgeo_region);
	tgeo_region.PrimaryKey =  new DataColumn[]{tgeo_region.Columns["idregion"]};


	//////////////////// GEO_NATION /////////////////////////////////
	var tgeo_nation= new DataTable("geo_nation");
	C= new DataColumn("idnation", typeof(int));
	C.AllowDBNull=false;
	tgeo_nation.Columns.Add(C);
	tgeo_nation.Columns.Add( new DataColumn("idcontinent", typeof(int)));
	tgeo_nation.Columns.Add( new DataColumn("title", typeof(string)));
	tgeo_nation.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tgeo_nation.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tgeo_nation.Columns.Add( new DataColumn("oldnation", typeof(int)));
	tgeo_nation.Columns.Add( new DataColumn("newnation", typeof(int)));
	tgeo_nation.Columns.Add( new DataColumn("lu", typeof(string)));
	tgeo_nation.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	Tables.Add(tgeo_nation);
	tgeo_nation.PrimaryKey =  new DataColumn[]{tgeo_nation.Columns["idnation"]};


	//////////////////// GEO_CITYVIEW /////////////////////////////////
	var tgeo_cityview= new DataTable("geo_cityview");
	C= new DataColumn("idcity", typeof(int));
	C.AllowDBNull=false;
	tgeo_cityview.Columns.Add(C);
	tgeo_cityview.Columns.Add( new DataColumn("title", typeof(string)));
	tgeo_cityview.Columns.Add( new DataColumn("oldcity", typeof(int)));
	tgeo_cityview.Columns.Add( new DataColumn("newcity", typeof(int)));
	tgeo_cityview.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tgeo_cityview.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tgeo_cityview.Columns.Add( new DataColumn("idcountry", typeof(int)));
	tgeo_cityview.Columns.Add( new DataColumn("provincecode", typeof(string)));
	tgeo_cityview.Columns.Add( new DataColumn("country", typeof(string)));
	tgeo_cityview.Columns.Add( new DataColumn("oldcountry", typeof(int)));
	tgeo_cityview.Columns.Add( new DataColumn("newcountry", typeof(int)));
	tgeo_cityview.Columns.Add( new DataColumn("countrydatestart", typeof(DateTime)));
	tgeo_cityview.Columns.Add( new DataColumn("countrydatestop", typeof(DateTime)));
	tgeo_cityview.Columns.Add( new DataColumn("idregion", typeof(int)));
	tgeo_cityview.Columns.Add( new DataColumn("region", typeof(string)));
	tgeo_cityview.Columns.Add( new DataColumn("regiondatestart", typeof(DateTime)));
	tgeo_cityview.Columns.Add( new DataColumn("regiondatestop", typeof(DateTime)));
	tgeo_cityview.Columns.Add( new DataColumn("oldregion", typeof(int)));
	tgeo_cityview.Columns.Add( new DataColumn("newregion", typeof(int)));
	tgeo_cityview.Columns.Add( new DataColumn("idnation", typeof(int)));
	tgeo_cityview.Columns.Add( new DataColumn("idcontinent", typeof(int)));
	tgeo_cityview.Columns.Add( new DataColumn("nation", typeof(string)));
	tgeo_cityview.Columns.Add( new DataColumn("nationdatestart", typeof(DateTime)));
	tgeo_cityview.Columns.Add( new DataColumn("nationdatestop", typeof(DateTime)));
	tgeo_cityview.Columns.Add( new DataColumn("oldnation", typeof(int)));
	tgeo_cityview.Columns.Add( new DataColumn("newnation", typeof(int)));
	Tables.Add(tgeo_cityview);
	tgeo_cityview.PrimaryKey =  new DataColumn[]{tgeo_cityview.Columns["idcity"]};


	//////////////////// REGISTRYADDRESS /////////////////////////////////
	var tregistryaddress= new DataTable("registryaddress");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistryaddress.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	tregistryaddress.Columns.Add(C);
	C= new DataColumn("idaddresskind", typeof(int));
	C.AllowDBNull=false;
	tregistryaddress.Columns.Add(C);
	tregistryaddress.Columns.Add( new DataColumn("annotations", typeof(string)));
	tregistryaddress.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tregistryaddress.Columns.Add( new DataColumn("cu", typeof(string)));
	tregistryaddress.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tregistryaddress.Columns.Add( new DataColumn("active", typeof(string)));
	tregistryaddress.Columns.Add( new DataColumn("idcity", typeof(int)));
	tregistryaddress.Columns.Add( new DataColumn("address", typeof(string)));
	tregistryaddress.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tregistryaddress.Columns.Add( new DataColumn("lu", typeof(string)));
	tregistryaddress.Columns.Add( new DataColumn("officename", typeof(string)));
	tregistryaddress.Columns.Add( new DataColumn("cap", typeof(string)));
	tregistryaddress.Columns.Add( new DataColumn("flagforeign", typeof(string)));
	tregistryaddress.Columns.Add( new DataColumn("location", typeof(string)));
	tregistryaddress.Columns.Add( new DataColumn("idnation", typeof(int)));
	tregistryaddress.Columns.Add( new DataColumn("recipientagency", typeof(string)));
	Tables.Add(tregistryaddress);
	tregistryaddress.PrimaryKey =  new DataColumn[]{tregistryaddress.Columns["idreg"], tregistryaddress.Columns["start"], tregistryaddress.Columns["idaddresskind"]};


	//////////////////// REGISTRYADDRESSVIEW /////////////////////////////////
	var tregistryaddressview= new DataTable("registryaddressview");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistryaddressview.Columns.Add(C);
	C= new DataColumn("registry", typeof(string));
	C.AllowDBNull=false;
	tregistryaddressview.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	tregistryaddressview.Columns.Add(C);
	tregistryaddressview.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	C= new DataColumn("idaddresskind", typeof(int));
	C.AllowDBNull=false;
	tregistryaddressview.Columns.Add(C);
	C= new DataColumn("codeaddress", typeof(string));
	C.AllowDBNull=false;
	tregistryaddressview.Columns.Add(C);
	C= new DataColumn("addresskind", typeof(string));
	C.AllowDBNull=false;
	tregistryaddressview.Columns.Add(C);
	tregistryaddressview.Columns.Add( new DataColumn("officename", typeof(string)));
	tregistryaddressview.Columns.Add( new DataColumn("address", typeof(string)));
	tregistryaddressview.Columns.Add( new DataColumn("idcity", typeof(int)));
	tregistryaddressview.Columns.Add( new DataColumn("city", typeof(string)));
	tregistryaddressview.Columns.Add( new DataColumn("active", typeof(string)));
	tregistryaddressview.Columns.Add( new DataColumn("annotations", typeof(string)));
	tregistryaddressview.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tregistryaddressview.Columns.Add( new DataColumn("cu", typeof(string)));
	tregistryaddressview.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tregistryaddressview.Columns.Add( new DataColumn("lu", typeof(string)));
	tregistryaddressview.Columns.Add( new DataColumn("cap", typeof(string)));
	tregistryaddressview.Columns.Add( new DataColumn("flagforeign", typeof(string)));
	tregistryaddressview.Columns.Add( new DataColumn("location", typeof(string)));
	tregistryaddressview.Columns.Add( new DataColumn("idnation", typeof(int)));
	tregistryaddressview.Columns.Add( new DataColumn("nation", typeof(string)));
	Tables.Add(tregistryaddressview);
	tregistryaddressview.PrimaryKey =  new DataColumn[]{tregistryaddressview.Columns["idreg"], tregistryaddressview.Columns["start"], tregistryaddressview.Columns["idaddresskind"]};


	//////////////////// GEO_NAZIONE_ALIAS /////////////////////////////////
	var tgeo_nazione_alias= new DataTable("geo_nazione_alias");
	C= new DataColumn("idnation", typeof(int));
	C.AllowDBNull=false;
	tgeo_nazione_alias.Columns.Add(C);
	tgeo_nazione_alias.Columns.Add( new DataColumn("idcontinent", typeof(int)));
	tgeo_nazione_alias.Columns.Add( new DataColumn("title", typeof(string)));
	tgeo_nazione_alias.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tgeo_nazione_alias.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tgeo_nazione_alias.Columns.Add( new DataColumn("oldnation", typeof(int)));
	tgeo_nazione_alias.Columns.Add( new DataColumn("newnation", typeof(int)));
	tgeo_nazione_alias.Columns.Add( new DataColumn("lu", typeof(string)));
	tgeo_nazione_alias.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	Tables.Add(tgeo_nazione_alias);
	tgeo_nazione_alias.PrimaryKey =  new DataColumn[]{tgeo_nazione_alias.Columns["idnation"]};


	//////////////////// REGISTRYMAINVIEW /////////////////////////////////
	var tregistrymainview= new DataTable("registrymainview");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistrymainview.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tregistrymainview.Columns.Add(C);
	tregistrymainview.Columns.Add( new DataColumn("surname", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("forename", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("cf", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("p_iva", typeof(string)));
	C= new DataColumn("residence", typeof(int));
	C.AllowDBNull=false;
	tregistrymainview.Columns.Add(C);
	tregistrymainview.Columns.Add( new DataColumn("coderesidence", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("residencekind", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("annotation", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("birthdate", typeof(DateTime)));
	tregistrymainview.Columns.Add( new DataColumn("idcity", typeof(int)));
	tregistrymainview.Columns.Add( new DataColumn("city", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("gender", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("foreigncf", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("idtitle", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("qualification", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("idmaritalstatus", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("maritalstatus", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("sortcode", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("registrykind", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("human", typeof(string)));
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tregistrymainview.Columns.Add(C);
	tregistrymainview.Columns.Add( new DataColumn("badgecode", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("maritalsurname", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("idcategory", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("category", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("extmatricula", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("idcentralizedcategory", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistrymainview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistrymainview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistrymainview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistrymainview.Columns.Add(C);
	tregistrymainview.Columns.Add( new DataColumn("location", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("idnation", typeof(int)));
	tregistrymainview.Columns.Add( new DataColumn("nation", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("idregistryclass", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("registryclass", typeof(string)));
	Tables.Add(tregistrymainview);
	tregistrymainview.PrimaryKey =  new DataColumn[]{tregistrymainview.Columns["idreg"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{geo_nazione_alias.Columns["idnation"]};
	var cChild = new []{registryaddress.Columns["idnation"]};
	Relations.Add(new DataRelation("geo_nazione_aliasregistryaddress",cPar,cChild,false));

	cPar = new []{address.Columns["idaddress"]};
	cChild = new []{registryaddress.Columns["idaddresskind"]};
	Relations.Add(new DataRelation("addressregistryaddress",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registryaddress.Columns["idreg"]};
	Relations.Add(new DataRelation("registryregistryaddress",cPar,cChild,false));

	cPar = new []{geo_city.Columns["idcity"]};
	cChild = new []{registryaddress.Columns["idcity"]};
	Relations.Add(new DataRelation("geo_cityregistryaddress",cPar,cChild,false));

	cPar = new []{geo_nation.Columns["idnation"]};
	cChild = new []{geo_region.Columns["idnation"]};
	Relations.Add(new DataRelation("geo_nationgeo_region",cPar,cChild,false));

	cPar = new []{geo_region.Columns["idregion"]};
	cChild = new []{geo_country.Columns["idregion"]};
	Relations.Add(new DataRelation("geo_regiongeo_country",cPar,cChild,false));

	cPar = new []{geo_country.Columns["idcountry"]};
	cChild = new []{geo_city.Columns["idcountry"]};
	Relations.Add(new DataRelation("geo_countrygeo_city",cPar,cChild,false));

	#endregion

}
}
}
