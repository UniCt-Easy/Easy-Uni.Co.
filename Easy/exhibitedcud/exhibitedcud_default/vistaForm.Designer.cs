
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
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace exhibitedcud_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///CUD Presentato
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable exhibitedcud 		=> Tables["exhibitedcud"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable geo_cityview 		=> Tables["geo_cityview"];

	///<summary>
	///Regione per applicazione imposta regionale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable fiscaltaxregion 		=> Tables["fiscaltaxregion"];

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
	//////////////////// EXHIBITEDCUD /////////////////////////////////
	var texhibitedcud= new DataTable("exhibitedcud");
	C= new DataColumn("idcon", typeof(string));
	C.AllowDBNull=false;
	texhibitedcud.Columns.Add(C);
	C= new DataColumn("idexhibitedcud", typeof(int));
	C.AllowDBNull=false;
	texhibitedcud.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	texhibitedcud.Columns.Add(C);
	C= new DataColumn("stop", typeof(DateTime));
	C.AllowDBNull=false;
	texhibitedcud.Columns.Add(C);
	C= new DataColumn("fiscalyear", typeof(int));
	C.AllowDBNull=false;
	texhibitedcud.Columns.Add(C);
	C= new DataColumn("nmonths", typeof(int));
	C.AllowDBNull=false;
	texhibitedcud.Columns.Add(C);
	texhibitedcud.Columns.Add( new DataColumn("cfotherdeputy", typeof(string)));
	texhibitedcud.Columns.Add( new DataColumn("transfermotive", typeof(string)));
	C= new DataColumn("taxablepension", typeof(decimal));
	C.AllowDBNull=false;
	texhibitedcud.Columns.Add(C);
	texhibitedcud.Columns.Add( new DataColumn("taxablegross", typeof(decimal)));
	texhibitedcud.Columns.Add( new DataColumn("inpsowed", typeof(decimal)));
	texhibitedcud.Columns.Add( new DataColumn("inpsretained", typeof(decimal)));
	texhibitedcud.Columns.Add( new DataColumn("irpefapplied", typeof(decimal)));
	texhibitedcud.Columns.Add( new DataColumn("irpefsuspended", typeof(decimal)));
	texhibitedcud.Columns.Add( new DataColumn("regionaltaxapplied", typeof(decimal)));
	texhibitedcud.Columns.Add( new DataColumn("suspendedregionaltax", typeof(decimal)));
	texhibitedcud.Columns.Add( new DataColumn("citytaxapplied", typeof(decimal)));
	texhibitedcud.Columns.Add( new DataColumn("suspendedcitytax", typeof(decimal)));
	C= new DataColumn("flagignoreprevcud", typeof(string));
	C.AllowDBNull=false;
	texhibitedcud.Columns.Add(C);
	texhibitedcud.Columns.Add( new DataColumn("cu", typeof(string)));
	texhibitedcud.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	texhibitedcud.Columns.Add( new DataColumn("lu", typeof(string)));
	texhibitedcud.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	texhibitedcud.Columns.Add( new DataColumn("ndays", typeof(int)));
	texhibitedcud.Columns.Add( new DataColumn("idlinkedcon", typeof(string)));
	texhibitedcud.Columns.Add( new DataColumn("citytax_account", typeof(decimal)));
	texhibitedcud.Columns.Add( new DataColumn("idcity", typeof(int)));
	texhibitedcud.Columns.Add( new DataColumn("idfiscaltaxregion", typeof(string)));
	texhibitedcud.Columns.Add( new DataColumn("idlinkeddbdepartment", typeof(string)));
	texhibitedcud.Columns.Add( new DataColumn("irpefgross", typeof(decimal)));
	texhibitedcud.Columns.Add( new DataColumn("earnings_based_abatements2020", typeof(decimal)));
	texhibitedcud.Columns.Add( new DataColumn("earnings_based_abatements", typeof(decimal)));
	texhibitedcud.Columns.Add( new DataColumn("fiscalbonusnotapplied", typeof(decimal)));
	texhibitedcud.Columns.Add( new DataColumn("fiscalbonusapplied", typeof(decimal)));
	texhibitedcud.Columns.Add( new DataColumn("flagbonusaccredited", typeof(int)));
	texhibitedcud.Columns.Add( new DataColumn("fiscalbonusnotapplied2020", typeof(decimal)));
	texhibitedcud.Columns.Add( new DataColumn("fiscalbonusapplied2020", typeof(decimal)));
	texhibitedcud.Columns.Add( new DataColumn("totabatements", typeof(decimal)));
	Tables.Add(texhibitedcud);
	texhibitedcud.PrimaryKey =  new DataColumn[]{texhibitedcud.Columns["idcon"], texhibitedcud.Columns["idexhibitedcud"]};


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
	C= new DataColumn("idcountry", typeof(int));
	C.AllowDBNull=false;
	tgeo_cityview.Columns.Add(C);
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


	#endregion


	#region DataRelation creation
	var cPar = new []{fiscaltaxregion.Columns["idfiscaltaxregion"]};
	var cChild = new []{exhibitedcud.Columns["idfiscaltaxregion"]};
	Relations.Add(new DataRelation("fiscaltaxregionexhibitedcud",cPar,cChild,false));

	cPar = new []{geo_cityview.Columns["idcity"]};
	cChild = new []{exhibitedcud.Columns["idcity"]};
	Relations.Add(new DataRelation("geo_cityviewexhibitedcud",cPar,cChild,false));

	#endregion

}
}
}
