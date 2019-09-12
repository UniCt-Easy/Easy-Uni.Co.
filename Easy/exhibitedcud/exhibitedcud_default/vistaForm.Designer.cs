/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
using System.Globalization;
namespace exhibitedcud_default {
[System.CodeDom.Compiler.GeneratedCodeAttribute("HDSGene", "2.0")]
[DesignerCategoryAttribute("code")]
public partial class vistaForm: System.Data.DataSet {

	#region Table members declaration
	[DebuggerNonUserCodeAttribute()][Browsable(false)]
	public DataTable exhibitedcud		{get { return Tables["exhibitedcud"];}}
	[DebuggerNonUserCodeAttribute()][Browsable(false)]
	public DataTable exhibitedcudview		{get { return Tables["exhibitedcudview"];}}
	[DebuggerNonUserCodeAttribute()][Browsable(false)]
	public DataTable geo_cityview		{get { return Tables["geo_cityview"];}}
	[DebuggerNonUserCodeAttribute()][Browsable(false)]
	public DataTable fiscaltaxregion		{get { return Tables["fiscaltaxregion"];}}
	#endregion


[DebuggerNonUserCodeAttribute()]
public vistaForm(){
	BeginInit();
	InitClass();
	EndInit();
}
[DebuggerNonUserCodeAttribute()]
private void InitClass() {
	DataSetName = "vistaForm";
	Prefix = "";
	Namespace = "http://tempuri.org/vistaForm.xsd";
	EnforceConstraints = false;

	#region create DataTables
	DataTable T;
	DataColumn C;
	//////////////////// exhibitedcud /////////////////////////////////
	T= new DataTable("exhibitedcud");
	C= new DataColumn("idcon", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idexhibitedcud", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("start", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("stop", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("fiscalyear", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("nmonths", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("cfotherdeputy", typeof(System.String)));
	T.Columns.Add( new DataColumn("transfermotive", typeof(System.String)));
	C= new DataColumn("taxablepension", typeof(System.Decimal));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("taxablegross", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("inpsowed", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("inpsretained", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("irpefapplied", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("irpefsuspended", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("regionaltaxapplied", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("suspendedregionaltax", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("citytaxapplied", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("suspendedcitytax", typeof(System.Decimal)));
	C= new DataColumn("flagignoreprevcud", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("cu", typeof(System.String)));
	T.Columns.Add( new DataColumn("ct", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("lu", typeof(System.String)));
	T.Columns.Add( new DataColumn("lt", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("ndays", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idlinkedcon", typeof(System.String)));
	T.Columns.Add( new DataColumn("citytax_account", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("idcity", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idfiscaltaxregion", typeof(System.String)));
	T.Columns.Add( new DataColumn("idlinkeddbdepartment", typeof(System.String)));
	T.Columns.Add( new DataColumn("irpefgross", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("earnings_based_abatements", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("fiscalbonusnotapplied", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("fiscalbonusapplied", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("flagbonusaccredited", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("totabatements", typeof(System.Decimal)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idcon"], T.Columns["idexhibitedcud"]};


	//////////////////// exhibitedcudview /////////////////////////////////
	T= new DataTable("exhibitedcudview");
	C= new DataColumn("idcon", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ycon", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ncon", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idexhibitedcud", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("cfotherdeputy", typeof(System.String)));
	T.Columns.Add( new DataColumn("citytax_account", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("citytaxapplied", typeof(System.Decimal)));
	C= new DataColumn("fiscalyear", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("flagignoreprevcud", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("inpsowed", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("inpsretained", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("irpefapplied", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("irpefsuspended", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("ndays", typeof(System.Int32)));
	C= new DataColumn("nmonths", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("regionaltaxapplied", typeof(System.Decimal)));
	C= new DataColumn("start", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("stop", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("suspendedcitytax", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("suspendedregionaltax", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("taxablegross", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("taxablenet", typeof(System.Decimal)));
	C= new DataColumn("taxablepension", typeof(System.Decimal));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("transfermotive", typeof(System.String)));
	T.Columns.Add( new DataColumn("idlinkedcon", typeof(System.String)));
	T.Columns.Add( new DataColumn("ylinkedcon", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("nlinkedcon", typeof(System.String)));
	T.Columns.Add( new DataColumn("idcity0101", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("city0101", typeof(System.String)));
	T.Columns.Add( new DataColumn("idcity3112", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("city3112", typeof(System.String)));
	T.Columns.Add( new DataColumn("ct", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("cu", typeof(System.String)));
	T.Columns.Add( new DataColumn("lt", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("lu", typeof(System.String)));
	T.Columns.Add( new DataColumn("provincecode0101", typeof(System.String)));
	T.Columns.Add( new DataColumn("region0101", typeof(System.String)));
	T.Columns.Add( new DataColumn("provincecode3112", typeof(System.String)));
	T.Columns.Add( new DataColumn("region3112", typeof(System.String)));
	T.Columns.Add( new DataColumn("irpefgross", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("earnings_based_abatements", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("fiscalbonusapplied", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("totabatements", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("fiscalbonusnotapplied", typeof(System.String)));
	T.Columns.Add( new DataColumn("flagbonusaccredited", typeof(System.Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idcon"], T.Columns["idexhibitedcud"]};


	//////////////////// geo_cityview /////////////////////////////////
	T= new DataTable("geo_cityview");
	C= new DataColumn("idcity", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("title", typeof(System.String)));
	T.Columns.Add( new DataColumn("oldcity", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("newcity", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("start", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("stop", typeof(System.DateTime)));
	C= new DataColumn("idcountry", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("provincecode", typeof(System.String)));
	T.Columns.Add( new DataColumn("country", typeof(System.String)));
	T.Columns.Add( new DataColumn("oldcountry", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("newcountry", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("countrydatestart", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("countrydatestop", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("idregion", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("region", typeof(System.String)));
	T.Columns.Add( new DataColumn("regiondatestart", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("regiondatestop", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("oldregion", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("newregion", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idnation", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idcontinent", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("nation", typeof(System.String)));
	T.Columns.Add( new DataColumn("nationdatestart", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("nationdatestop", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("oldnation", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("newnation", typeof(System.Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idcity"]};


	//////////////////// fiscaltaxregion /////////////////////////////////
	T= new DataTable("fiscaltaxregion");
	C= new DataColumn("idfiscaltaxregion", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("title", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("active", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idfiscaltaxregion"]};


	#endregion


	#region DataRelation creation
	DataColumn []CPar;
	DataColumn []CChild;
	CPar = new DataColumn[1]{fiscaltaxregion.Columns["idfiscaltaxregion"]};
	CChild = new DataColumn[1]{exhibitedcud.Columns["idfiscaltaxregion"]};
	Relations.Add(new DataRelation("fiscaltaxregionexhibitedcud",CPar,CChild));

	CPar = new DataColumn[1]{geo_cityview.Columns["idcity"]};
	CChild = new DataColumn[1]{exhibitedcud.Columns["idcity"]};
	Relations.Add(new DataRelation("geo_cityviewexhibitedcud",CPar,CChild));

	#endregion

}
}
}
