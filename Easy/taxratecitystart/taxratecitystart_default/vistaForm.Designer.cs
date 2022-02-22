
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
namespace taxratecitystart_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable geo_cityview 		=> Tables["geo_cityview"];

	///<summary>
	///Tipi di ritenuta
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable tax 		=> Tables["tax"];

	///<summary>
	///Struttura Imposta Comunale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable taxratecitystart 		=> Tables["taxratecitystart"];

	///<summary>
	///Scaglioni Imposta Comunale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable taxratecitybracket 		=> Tables["taxratecitybracket"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable taxratecitystartview 		=> Tables["taxratecitystartview"];

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


	//////////////////// TAX /////////////////////////////////
	var ttax= new DataTable("tax");
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	C= new DataColumn("taxref", typeof(string));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	ttax.Columns.Add( new DataColumn("active", typeof(string)));
	ttax.Columns.Add( new DataColumn("appliancebasis", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	ttax.Columns.Add( new DataColumn("fiscaltaxcode", typeof(string)));
	ttax.Columns.Add( new DataColumn("flagunabatable", typeof(string)));
	ttax.Columns.Add( new DataColumn("geoappliance", typeof(string)));
	ttax.Columns.Add( new DataColumn("idaccmotive_cost", typeof(string)));
	ttax.Columns.Add( new DataColumn("idaccmotive_debit", typeof(string)));
	ttax.Columns.Add( new DataColumn("idaccmotive_pay", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	ttax.Columns.Add( new DataColumn("taxablecode", typeof(string)));
	ttax.Columns.Add( new DataColumn("taxkind", typeof(short)));
	Tables.Add(ttax);
	ttax.PrimaryKey =  new DataColumn[]{ttax.Columns["taxcode"]};


	//////////////////// TAXRATECITYSTART /////////////////////////////////
	var ttaxratecitystart= new DataTable("taxratecitystart");
	C= new DataColumn("idcity", typeof(int));
	C.AllowDBNull=false;
	ttaxratecitystart.Columns.Add(C);
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	ttaxratecitystart.Columns.Add(C);
	C= new DataColumn("idtaxratecitystart", typeof(int));
	C.AllowDBNull=false;
	ttaxratecitystart.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	ttaxratecitystart.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	ttaxratecitystart.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	ttaxratecitystart.Columns.Add(C);
	ttaxratecitystart.Columns.Add( new DataColumn("enforcement", typeof(string)));
	ttaxratecitystart.Columns.Add( new DataColumn("annotations", typeof(string)));
	ttaxratecitystart.Columns.Add( new DataColumn("taxablemin", typeof(decimal)));
	Tables.Add(ttaxratecitystart);
	ttaxratecitystart.PrimaryKey =  new DataColumn[]{ttaxratecitystart.Columns["idcity"], ttaxratecitystart.Columns["taxcode"], ttaxratecitystart.Columns["idtaxratecitystart"]};


	//////////////////// TAXRATECITYBRACKET /////////////////////////////////
	var ttaxratecitybracket= new DataTable("taxratecitybracket");
	C= new DataColumn("rate", typeof(decimal));
	C.AllowDBNull=false;
	ttaxratecitybracket.Columns.Add(C);
	C= new DataColumn("idcity", typeof(int));
	C.AllowDBNull=false;
	ttaxratecitybracket.Columns.Add(C);
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	ttaxratecitybracket.Columns.Add(C);
	C= new DataColumn("idtaxratecitystart", typeof(int));
	C.AllowDBNull=false;
	ttaxratecitybracket.Columns.Add(C);
	C= new DataColumn("nbracket", typeof(int));
	C.AllowDBNull=false;
	ttaxratecitybracket.Columns.Add(C);
	ttaxratecitybracket.Columns.Add( new DataColumn("minamount", typeof(decimal)));
	ttaxratecitybracket.Columns.Add( new DataColumn("maxamount", typeof(decimal)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	ttaxratecitybracket.Columns.Add(C);
	ttaxratecitybracket.Columns.Add( new DataColumn("lu", typeof(string)));
	Tables.Add(ttaxratecitybracket);
	ttaxratecitybracket.PrimaryKey =  new DataColumn[]{ttaxratecitybracket.Columns["idcity"], ttaxratecitybracket.Columns["taxcode"], ttaxratecitybracket.Columns["idtaxratecitystart"], ttaxratecitybracket.Columns["nbracket"]};


	//////////////////// TAXRATECITYSTARTVIEW /////////////////////////////////
	var ttaxratecitystartview= new DataTable("taxratecitystartview");
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	ttaxratecitystartview.Columns.Add(C);
	C= new DataColumn("taxref", typeof(string));
	C.AllowDBNull=false;
	ttaxratecitystartview.Columns.Add(C);
	C= new DataColumn("idcity", typeof(int));
	C.AllowDBNull=false;
	ttaxratecitystartview.Columns.Add(C);
	C= new DataColumn("idtaxratecitystart", typeof(int));
	C.AllowDBNull=false;
	ttaxratecitystartview.Columns.Add(C);
	ttaxratecitystartview.Columns.Add( new DataColumn("city", typeof(string)));
	C= new DataColumn("idcountry", typeof(int));
	C.AllowDBNull=false;
	ttaxratecitystartview.Columns.Add(C);
	ttaxratecitystartview.Columns.Add( new DataColumn("country", typeof(string)));
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	ttaxratecitystartview.Columns.Add(C);
	ttaxratecitystartview.Columns.Add( new DataColumn("enforcement", typeof(string)));
	ttaxratecitystartview.Columns.Add( new DataColumn("annotations", typeof(string)));
	C= new DataColumn("taxablemin", typeof(decimal));
	C.ReadOnly=true;
	ttaxratecitystartview.Columns.Add(C);
	C= new DataColumn("min1", typeof(decimal));
	C.ReadOnly=true;
	ttaxratecitystartview.Columns.Add(C);
	ttaxratecitystartview.Columns.Add( new DataColumn("max1", typeof(decimal)));
	ttaxratecitystartview.Columns.Add( new DataColumn("rate1", typeof(decimal)));
	ttaxratecitystartview.Columns.Add( new DataColumn("min2", typeof(decimal)));
	ttaxratecitystartview.Columns.Add( new DataColumn("max2", typeof(decimal)));
	ttaxratecitystartview.Columns.Add( new DataColumn("rate2", typeof(decimal)));
	ttaxratecitystartview.Columns.Add( new DataColumn("min3", typeof(decimal)));
	ttaxratecitystartview.Columns.Add( new DataColumn("max3", typeof(decimal)));
	ttaxratecitystartview.Columns.Add( new DataColumn("rate3", typeof(decimal)));
	ttaxratecitystartview.Columns.Add( new DataColumn("min4", typeof(decimal)));
	ttaxratecitystartview.Columns.Add( new DataColumn("max4", typeof(decimal)));
	ttaxratecitystartview.Columns.Add( new DataColumn("rate4", typeof(decimal)));
	ttaxratecitystartview.Columns.Add( new DataColumn("min5", typeof(decimal)));
	ttaxratecitystartview.Columns.Add( new DataColumn("max5", typeof(decimal)));
	ttaxratecitystartview.Columns.Add( new DataColumn("rate5", typeof(decimal)));
	Tables.Add(ttaxratecitystartview);
	ttaxratecitystartview.PrimaryKey =  new DataColumn[]{ttaxratecitystartview.Columns["taxcode"], ttaxratecitystartview.Columns["idcity"], ttaxratecitystartview.Columns["idtaxratecitystart"], ttaxratecitystartview.Columns["idcountry"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{taxratecitystart.Columns["idcity"], taxratecitystart.Columns["taxcode"], taxratecitystart.Columns["idtaxratecitystart"]};
	var cChild = new []{taxratecitybracket.Columns["idcity"], taxratecitybracket.Columns["taxcode"], taxratecitybracket.Columns["idtaxratecitystart"]};
	Relations.Add(new DataRelation("taxratecitystart_taxratecitybracket",cPar,cChild,false));

	cPar = new []{geo_cityview.Columns["idcity"]};
	cChild = new []{taxratecitystart.Columns["idcity"]};
	Relations.Add(new DataRelation("geo_cityview_taxratecitystart",cPar,cChild,false));

	cPar = new []{tax.Columns["taxcode"]};
	cChild = new []{taxratecitystart.Columns["taxcode"]};
	Relations.Add(new DataRelation("tax_taxratecitystart",cPar,cChild,false));

	#endregion

}
}
}
