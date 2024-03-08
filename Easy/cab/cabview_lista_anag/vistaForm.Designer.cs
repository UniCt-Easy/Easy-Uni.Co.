
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
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace cabview_lista_anag {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Banca
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable bank 		=> Tables["bank"];

	///<summary>
	///Sportello Banca
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable cab 		=> Tables["cab"];

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

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable geo_cityview 		=> Tables["geo_cityview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable cabview 		=> Tables["cabview"];

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
	//////////////////// BANK /////////////////////////////////
	var tbank= new DataTable("bank");
	C= new DataColumn("idbank", typeof(string));
	C.AllowDBNull=false;
	tbank.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tbank.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tbank.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tbank.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tbank.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tbank.Columns.Add(C);
	Tables.Add(tbank);
	tbank.PrimaryKey =  new DataColumn[]{tbank.Columns["idbank"]};


	//////////////////// CAB /////////////////////////////////
	var tcab= new DataTable("cab");
	C= new DataColumn("idbank", typeof(string));
	C.AllowDBNull=false;
	tcab.Columns.Add(C);
	C= new DataColumn("idcab", typeof(string));
	C.AllowDBNull=false;
	tcab.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tcab.Columns.Add(C);
	tcab.Columns.Add( new DataColumn("address", typeof(string)));
	tcab.Columns.Add( new DataColumn("cap", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcab.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcab.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcab.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcab.Columns.Add(C);
	tcab.Columns.Add( new DataColumn("idcity", typeof(int)));
	tcab.Columns.Add( new DataColumn("!comune", typeof(string)));
	tcab.Columns.Add( new DataColumn("location", typeof(string)));
	Tables.Add(tcab);
	tcab.PrimaryKey =  new DataColumn[]{tcab.Columns["idbank"], tcab.Columns["idcab"]};


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

	//////////////////// CABVIEW /////////////////////////////////
	var tcabview= new DataTable("cabview");
	C= new DataColumn("idbank", typeof(string));
	C.AllowDBNull=false;
	tcabview.Columns.Add(C);
	C= new DataColumn("idcab", typeof(string));
	C.AllowDBNull=false;
	tcabview.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tcabview.Columns.Add(C);
	tcabview.Columns.Add( new DataColumn("address", typeof(string)));
	tcabview.Columns.Add( new DataColumn("cap", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcabview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcabview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcabview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcabview.Columns.Add(C);
	tcabview.Columns.Add( new DataColumn("location", typeof(string)));
	tcabview.Columns.Add( new DataColumn("idcity", typeof(int)));
	tcabview.Columns.Add( new DataColumn("city", typeof(string)));
	tcabview.Columns.Add( new DataColumn("country", typeof(string)));
	tcabview.Columns.Add( new DataColumn("flagusable", typeof(string)));
	Tables.Add(tcabview);
	tcabview.PrimaryKey =  new DataColumn[]{tcabview.Columns["idbank"], tcabview.Columns["idcab"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{bank.Columns["idbank"]};
	var cChild = new []{cabview.Columns["idbank"]};
	Relations.Add(new DataRelation("bankcabview",cPar,cChild,false));

	cPar = new []{geo_city.Columns["idcity"]};
	cChild = new []{cabview.Columns["idcity"]};
	Relations.Add(new DataRelation("geo_citycabview",cPar,cChild,false));

	cPar = new []{geo_cityview.Columns["idcity"]};
	cChild = new []{cabview.Columns["idcity"]};
	Relations.Add(new DataRelation("geo_cityviewcabview",cPar,cChild,false));

	cPar = new []{geo_country.Columns["idcountry"]};
	cChild = new []{geo_city.Columns["idcountry"]};
	Relations.Add(new DataRelation("geo_countrygeo_city",cPar,cChild,false));

	#endregion

}
}
}
