
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
namespace cafdocument_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Comunicazioni da CAF
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable cafdocument 		=> Tables["cafdocument"];

	///<summary>
	///Nomi e codici dei mesi nel codice fiscale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable monthname 		=> Tables["monthname"];

	///<summary>
	///Regione per applicazione imposta regionale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable fiscaltaxregion 		=> Tables["fiscaltaxregion"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable geo_city_agencyview 		=> Tables["geo_city_agencyview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable cafdocumentview 		=> Tables["cafdocumentview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable monthname1 		=> Tables["monthname1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable monthname2 		=> Tables["monthname2"];

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
	//////////////////// CAFDOCUMENT /////////////////////////////////
	var tcafdocument= new DataTable("cafdocument");
	C= new DataColumn("idcafdocument", typeof(int));
	C.AllowDBNull=false;
	tcafdocument.Columns.Add(C);
	C= new DataColumn("idcon", typeof(string));
	C.AllowDBNull=false;
	tcafdocument.Columns.Add(C);
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tcafdocument.Columns.Add(C);
	C= new DataColumn("cafdocumentkind", typeof(string));
	C.AllowDBNull=false;
	tcafdocument.Columns.Add(C);
	C= new DataColumn("docdate", typeof(DateTime));
	C.AllowDBNull=false;
	tcafdocument.Columns.Add(C);
	tcafdocument.Columns.Add( new DataColumn("citytaxtorefundhusband", typeof(decimal)));
	tcafdocument.Columns.Add( new DataColumn("citytaxtorefund", typeof(decimal)));
	tcafdocument.Columns.Add( new DataColumn("citytaxtoretainhusband", typeof(decimal)));
	tcafdocument.Columns.Add( new DataColumn("citytaxtoretain", typeof(decimal)));
	tcafdocument.Columns.Add( new DataColumn("regionaltaxtorefundhusband", typeof(decimal)));
	tcafdocument.Columns.Add( new DataColumn("regionaltaxtorefund", typeof(decimal)));
	tcafdocument.Columns.Add( new DataColumn("regionaltaxtoretainhusband", typeof(decimal)));
	tcafdocument.Columns.Add( new DataColumn("regionaltaxtoretain", typeof(decimal)));
	tcafdocument.Columns.Add( new DataColumn("idcity", typeof(int)));
	tcafdocument.Columns.Add( new DataColumn("idfiscaltaxregion", typeof(string)));
	tcafdocument.Columns.Add( new DataColumn("irpeftorefund", typeof(decimal)));
	tcafdocument.Columns.Add( new DataColumn("irpeftoretain", typeof(decimal)));
	tcafdocument.Columns.Add( new DataColumn("startmonth", typeof(int)));
	tcafdocument.Columns.Add( new DataColumn("monthfirstinstalment", typeof(int)));
	tcafdocument.Columns.Add( new DataColumn("monthsecondinstalment", typeof(int)));
	tcafdocument.Columns.Add( new DataColumn("ratequantity", typeof(int)));
	tcafdocument.Columns.Add( new DataColumn("nquotafirstinstalment", typeof(int)));
	tcafdocument.Columns.Add( new DataColumn("nquotasecondinstalment", typeof(int)));
	tcafdocument.Columns.Add( new DataColumn("firstrateadvance", typeof(decimal)));
	tcafdocument.Columns.Add( new DataColumn("separatedincomehusband", typeof(decimal)));
	tcafdocument.Columns.Add( new DataColumn("separatedincome", typeof(decimal)));
	tcafdocument.Columns.Add( new DataColumn("secondrateadvance", typeof(decimal)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcafdocument.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcafdocument.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcafdocument.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcafdocument.Columns.Add(C);
	tcafdocument.Columns.Add( new DataColumn("citytaxaccount", typeof(decimal)));
	tcafdocument.Columns.Add( new DataColumn("citytaxaccounthusband", typeof(decimal)));
	Tables.Add(tcafdocument);
	tcafdocument.PrimaryKey =  new DataColumn[]{tcafdocument.Columns["idcafdocument"], tcafdocument.Columns["idcon"]};


	//////////////////// MONTHNAME /////////////////////////////////
	var tmonthname= new DataTable("monthname");
	C= new DataColumn("code", typeof(int));
	C.AllowDBNull=false;
	tmonthname.Columns.Add(C);
	tmonthname.Columns.Add( new DataColumn("title", typeof(string)));
	tmonthname.Columns.Add( new DataColumn("cfvalue", typeof(string)));
	Tables.Add(tmonthname);
	tmonthname.PrimaryKey =  new DataColumn[]{tmonthname.Columns["code"]};


	//////////////////// FISCALTAXREGION /////////////////////////////////
	var tfiscaltaxregion= new DataTable("fiscaltaxregion");
	C= new DataColumn("idfiscaltaxregion", typeof(string));
	C.AllowDBNull=false;
	tfiscaltaxregion.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tfiscaltaxregion.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tfiscaltaxregion.Columns.Add(C);
	tfiscaltaxregion.Columns.Add( new DataColumn("idcountry", typeof(int)));
	tfiscaltaxregion.Columns.Add( new DataColumn("idregion", typeof(int)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfiscaltaxregion.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfiscaltaxregion.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfiscaltaxregion.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfiscaltaxregion.Columns.Add(C);
	Tables.Add(tfiscaltaxregion);
	tfiscaltaxregion.PrimaryKey =  new DataColumn[]{tfiscaltaxregion.Columns["idfiscaltaxregion"]};


	//////////////////// GEO_CITY_AGENCYVIEW /////////////////////////////////
	var tgeo_city_agencyview= new DataTable("geo_city_agencyview");
	C= new DataColumn("idcity", typeof(int));
	C.AllowDBNull=false;
	tgeo_city_agencyview.Columns.Add(C);
	tgeo_city_agencyview.Columns.Add( new DataColumn("title", typeof(string)));
	C= new DataColumn("idagency", typeof(int));
	C.AllowDBNull=false;
	tgeo_city_agencyview.Columns.Add(C);
	tgeo_city_agencyview.Columns.Add( new DataColumn("agencyname", typeof(string)));
	tgeo_city_agencyview.Columns.Add( new DataColumn("agencywebsite", typeof(string)));
	C= new DataColumn("idcode", typeof(int));
	C.AllowDBNull=false;
	tgeo_city_agencyview.Columns.Add(C);
	C= new DataColumn("version", typeof(int));
	C.AllowDBNull=false;
	tgeo_city_agencyview.Columns.Add(C);
	tgeo_city_agencyview.Columns.Add( new DataColumn("codename", typeof(string)));
	tgeo_city_agencyview.Columns.Add( new DataColumn("value", typeof(string)));
	tgeo_city_agencyview.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tgeo_city_agencyview.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tgeo_city_agencyview.Columns.Add( new DataColumn("provincecode", typeof(string)));
	Tables.Add(tgeo_city_agencyview);
	tgeo_city_agencyview.PrimaryKey =  new DataColumn[]{tgeo_city_agencyview.Columns["idcity"], tgeo_city_agencyview.Columns["idagency"], tgeo_city_agencyview.Columns["idcode"], tgeo_city_agencyview.Columns["version"]};


	//////////////////// CAFDOCUMENTVIEW /////////////////////////////////
	var tcafdocumentview= new DataTable("cafdocumentview");
	C= new DataColumn("idcafdocument", typeof(int));
	C.AllowDBNull=false;
	tcafdocumentview.Columns.Add(C);
	C= new DataColumn("idcon", typeof(string));
	C.AllowDBNull=false;
	tcafdocumentview.Columns.Add(C);
	C= new DataColumn("ycon", typeof(int));
	C.AllowDBNull=false;
	tcafdocumentview.Columns.Add(C);
	C= new DataColumn("ncon", typeof(string));
	C.AllowDBNull=false;
	tcafdocumentview.Columns.Add(C);
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tcafdocumentview.Columns.Add(C);
	C= new DataColumn("registry", typeof(string));
	C.AllowDBNull=false;
	tcafdocumentview.Columns.Add(C);
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tcafdocumentview.Columns.Add(C);
	C= new DataColumn("cafdocumentkind", typeof(string));
	C.ReadOnly=true;
	tcafdocumentview.Columns.Add(C);
	C= new DataColumn("docdate", typeof(DateTime));
	C.AllowDBNull=false;
	tcafdocumentview.Columns.Add(C);
	tcafdocumentview.Columns.Add( new DataColumn("citytaxtorefundhusband", typeof(decimal)));
	tcafdocumentview.Columns.Add( new DataColumn("citytaxtorefund", typeof(decimal)));
	tcafdocumentview.Columns.Add( new DataColumn("citytaxtoretainhusband", typeof(decimal)));
	tcafdocumentview.Columns.Add( new DataColumn("citytaxtoretain", typeof(decimal)));
	tcafdocumentview.Columns.Add( new DataColumn("regionaltaxtorefundhusband", typeof(decimal)));
	tcafdocumentview.Columns.Add( new DataColumn("regionaltaxtorefund", typeof(decimal)));
	tcafdocumentview.Columns.Add( new DataColumn("regionaltaxtoretainhusband", typeof(decimal)));
	tcafdocumentview.Columns.Add( new DataColumn("regionaltaxtoretain", typeof(decimal)));
	tcafdocumentview.Columns.Add( new DataColumn("idcity", typeof(int)));
	tcafdocumentview.Columns.Add( new DataColumn("citycode", typeof(string)));
	tcafdocumentview.Columns.Add( new DataColumn("idfiscaltaxregion", typeof(string)));
	tcafdocumentview.Columns.Add( new DataColumn("fiscaltaxregion", typeof(string)));
	tcafdocumentview.Columns.Add( new DataColumn("irpeftorefund", typeof(decimal)));
	tcafdocumentview.Columns.Add( new DataColumn("irpeftoretain", typeof(decimal)));
	tcafdocumentview.Columns.Add( new DataColumn("startmonth", typeof(int)));
	tcafdocumentview.Columns.Add( new DataColumn("monthfirstinstalment", typeof(int)));
	tcafdocumentview.Columns.Add( new DataColumn("monthsecondinstalment", typeof(int)));
	tcafdocumentview.Columns.Add( new DataColumn("ratequantity", typeof(int)));
	tcafdocumentview.Columns.Add( new DataColumn("nquotafirstinstalment", typeof(int)));
	tcafdocumentview.Columns.Add( new DataColumn("nquotasecondinstalment", typeof(int)));
	tcafdocumentview.Columns.Add( new DataColumn("firstrateadvance", typeof(decimal)));
	tcafdocumentview.Columns.Add( new DataColumn("separatedincomehusband", typeof(decimal)));
	tcafdocumentview.Columns.Add( new DataColumn("separatedincome", typeof(decimal)));
	tcafdocumentview.Columns.Add( new DataColumn("secondrateadvance", typeof(decimal)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcafdocumentview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcafdocumentview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcafdocumentview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcafdocumentview.Columns.Add(C);
	tcafdocumentview.Columns.Add( new DataColumn("citytaxaccount", typeof(decimal)));
	tcafdocumentview.Columns.Add( new DataColumn("citytaxaccounthusband", typeof(decimal)));
	Tables.Add(tcafdocumentview);
	tcafdocumentview.PrimaryKey =  new DataColumn[]{tcafdocumentview.Columns["idcafdocument"], tcafdocumentview.Columns["idcon"]};


	//////////////////// MONTHNAME1 /////////////////////////////////
	var tmonthname1= new DataTable("monthname1");
	C= new DataColumn("code", typeof(int));
	C.AllowDBNull=false;
	tmonthname1.Columns.Add(C);
	tmonthname1.Columns.Add( new DataColumn("title", typeof(string)));
	tmonthname1.Columns.Add( new DataColumn("cfvalue", typeof(string)));
	Tables.Add(tmonthname1);
	tmonthname1.PrimaryKey =  new DataColumn[]{tmonthname1.Columns["code"]};


	//////////////////// MONTHNAME2 /////////////////////////////////
	var tmonthname2= new DataTable("monthname2");
	C= new DataColumn("code", typeof(int));
	C.AllowDBNull=false;
	tmonthname2.Columns.Add(C);
	tmonthname2.Columns.Add( new DataColumn("title", typeof(string)));
	tmonthname2.Columns.Add( new DataColumn("cfvalue", typeof(string)));
	Tables.Add(tmonthname2);
	tmonthname2.PrimaryKey =  new DataColumn[]{tmonthname2.Columns["code"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{monthname2.Columns["code"]};
	var cChild = new []{cafdocument.Columns["monthsecondinstalment"]};
	Relations.Add(new DataRelation("monthname2_cafdocument",cPar,cChild,false));

	cPar = new []{monthname1.Columns["code"]};
	cChild = new []{cafdocument.Columns["monthfirstinstalment"]};
	Relations.Add(new DataRelation("monthname1_cafdocument",cPar,cChild,false));

	cPar = new []{monthname.Columns["code"]};
	cChild = new []{cafdocument.Columns["startmonth"]};
	Relations.Add(new DataRelation("monthname_cafdocument",cPar,cChild,false));

	cPar = new []{geo_city_agencyview.Columns["idcity"]};
	cChild = new []{cafdocument.Columns["idcity"]};
	Relations.Add(new DataRelation("geo_city_agencyviewcafdocument",cPar,cChild,false));

	cPar = new []{fiscaltaxregion.Columns["idfiscaltaxregion"]};
	cChild = new []{cafdocument.Columns["idfiscaltaxregion"]};
	Relations.Add(new DataRelation("fiscaltaxregioncafdocument",cPar,cChild,false));

	#endregion

}
}
}
