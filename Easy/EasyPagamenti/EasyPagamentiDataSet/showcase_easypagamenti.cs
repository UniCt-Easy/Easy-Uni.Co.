
/*
Easy
Copyright (C) 2023 Universita' degli Studi di Catania (www.unict.it)
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
namespace EasyPagamentiDataSet {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("showcase_easypagamenti"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class showcase_easypagamenti: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable showcase 		=> Tables["showcase"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable store 		=> Tables["store"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable list 		=> Tables["list"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable showcasedetail 		=> Tables["showcasedetail"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public showcase_easypagamenti(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected showcase_easypagamenti (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "showcase_easypagamenti";
	Prefix = "";
	Namespace = "http://tempuri.org/showcase_easypagamenti.xsd";

	#region create DataTables
	DataColumn C;
	//////////////////// SHOWCASE /////////////////////////////////
	var tshowcase= new DataTable("showcase");
	C= new DataColumn("idshowcase", typeof(int));
	C.AllowDBNull=false;
	tshowcase.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tshowcase.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tshowcase.Columns.Add(C);
	C= new DataColumn("idstore", typeof(int));
	C.AllowDBNull=false;
	tshowcase.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tshowcase.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tshowcase.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tshowcase.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tshowcase.Columns.Add(C);
	tshowcase.Columns.Add( new DataColumn("!store", typeof(string)));
	tshowcase.Columns.Add( new DataColumn("paymentexpiring", typeof(short)));
	tshowcase.Columns.Add( new DataColumn("flagldapvisibility", typeof(int)));
	Tables.Add(tshowcase);
	tshowcase.PrimaryKey =  new DataColumn[]{tshowcase.Columns["idshowcase"]};


	//////////////////// STORE /////////////////////////////////
	var tstore= new DataTable("store");
	C= new DataColumn("idstore", typeof(int));
	C.AllowDBNull=false;
	tstore.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tstore.Columns.Add(C);
	C= new DataColumn("deliveryaddress", typeof(string));
	C.AllowDBNull=false;
	tstore.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tstore.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tstore.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tstore.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tstore.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tstore.Columns.Add(C);
	tstore.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tstore.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tstore.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tstore.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tstore.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tstore.Columns.Add( new DataColumn("idupb", typeof(string)));
	tstore.Columns.Add( new DataColumn("idestimkind", typeof(string)));
	Tables.Add(tstore);
	tstore.PrimaryKey =  new DataColumn[]{tstore.Columns["idstore"]};


	//////////////////// LIST /////////////////////////////////
	var tlist= new DataTable("list");
	C= new DataColumn("idlist", typeof(int));
	C.AllowDBNull=false;
	tlist.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tlist.Columns.Add(C);
	C= new DataColumn("intcode", typeof(string));
	C.AllowDBNull=false;
	tlist.Columns.Add(C);
	tlist.Columns.Add( new DataColumn("intbarcode", typeof(string)));
	tlist.Columns.Add( new DataColumn("extcode", typeof(string)));
	tlist.Columns.Add( new DataColumn("extbarcode", typeof(string)));
	tlist.Columns.Add( new DataColumn("validitystop", typeof(DateTime)));
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tlist.Columns.Add(C);
	tlist.Columns.Add( new DataColumn("idpackage", typeof(int)));
	tlist.Columns.Add( new DataColumn("idunit", typeof(int)));
	tlist.Columns.Add( new DataColumn("unitsforpackage", typeof(int)));
	C= new DataColumn("has_expiry", typeof(string));
	C.AllowDBNull=false;
	tlist.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tlist.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tlist.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tlist.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tlist.Columns.Add(C);
	C= new DataColumn("idlistclass", typeof(string));
	C.AllowDBNull=false;
	tlist.Columns.Add(C);
	tlist.Columns.Add( new DataColumn("pic", typeof(Byte[])));
	tlist.Columns.Add( new DataColumn("price", typeof(decimal)));
	tlist.Columns.Add( new DataColumn("idtassonomia", typeof(int)));
	Tables.Add(tlist);
	tlist.PrimaryKey =  new DataColumn[]{tlist.Columns["idlist"]};


	//////////////////// SHOWCASEDETAIL /////////////////////////////////
	var tshowcasedetail= new DataTable("showcasedetail");
	C= new DataColumn("idshowcase", typeof(int));
	C.AllowDBNull=false;
	tshowcasedetail.Columns.Add(C);
	C= new DataColumn("idlist", typeof(int));
	C.AllowDBNull=false;
	tshowcasedetail.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tshowcasedetail.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tshowcasedetail.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tshowcasedetail.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tshowcasedetail.Columns.Add(C);
	tshowcasedetail.Columns.Add( new DataColumn("!intcode", typeof(string)));
	tshowcasedetail.Columns.Add( new DataColumn("!extcode", typeof(string)));
	tshowcasedetail.Columns.Add( new DataColumn("!description", typeof(string)));
	tshowcasedetail.Columns.Add( new DataColumn("idupb", typeof(string)));
	tshowcasedetail.Columns.Add( new DataColumn("idestimkind", typeof(string)));
	tshowcasedetail.Columns.Add( new DataColumn("idivakind", typeof(int)));
	tshowcasedetail.Columns.Add( new DataColumn("competencystart", typeof(DateTime)));
	tshowcasedetail.Columns.Add( new DataColumn("competencystop", typeof(DateTime)));
	tshowcasedetail.Columns.Add( new DataColumn("idupb_iva", typeof(string)));
	tshowcasedetail.Columns.Add( new DataColumn("idsor1", typeof(int)));
	tshowcasedetail.Columns.Add( new DataColumn("idsor2", typeof(int)));
	tshowcasedetail.Columns.Add( new DataColumn("idsor3", typeof(int)));
	Tables.Add(tshowcasedetail);
	tshowcasedetail.PrimaryKey =  new DataColumn[]{tshowcasedetail.Columns["idshowcase"], tshowcasedetail.Columns["idlist"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{list.Columns["idlist"]};
	var cChild = new []{showcasedetail.Columns["idlist"]};
	Relations.Add(new DataRelation("list_showcasedetail",cPar,cChild,false));

	cPar = new []{showcase.Columns["idshowcase"]};
	cChild = new []{showcasedetail.Columns["idshowcase"]};
	Relations.Add(new DataRelation("showcase_showcasedetail",cPar,cChild,false));

	cPar = new []{store.Columns["idstore"]};
	cChild = new []{showcase.Columns["idstore"]};
	Relations.Add(new DataRelation("store_showcase",cPar,cChild,false));

	#endregion

}
}
}
