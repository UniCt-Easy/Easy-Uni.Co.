
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
using meta_webpaymentdetail;
using meta_list;
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace webpaymentdetail_single {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public webpaymentdetailTable webpaymentdetail 		=> (webpaymentdetailTable)Tables["webpaymentdetail"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable store 		=> (MetaTable)Tables["store"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public listTable list 		=> (listTable)Tables["list"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sorting1 		=> (MetaTable)Tables["sorting1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sorting2 		=> (MetaTable)Tables["sorting2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sorting3 		=> (MetaTable)Tables["sorting3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable listclass 		=> (MetaTable)Tables["listclass"];

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
	//////////////////// WEBPAYMENTDETAIL /////////////////////////////////
	var twebpaymentdetail= new webpaymentdetailTable();
	twebpaymentdetail.addBaseColumns("idwebpayment","idlist","idstore","ct","cu","idsor1","idsor2","idsor3","lt","lu","number","price","iddetail","idupb","idestimkind","paymentexpiring","idivakind","tax","annotations","idinvkind","competencystart","competencystop","idupb_iva");
	twebpaymentdetail.defineColumn("!list", typeof(string));
	twebpaymentdetail.defineColumn("!store", typeof(string));
	twebpaymentdetail.defineColumn("!totale", typeof(decimal));
	Tables.Add(twebpaymentdetail);
	twebpaymentdetail.defineKey("idwebpayment", "iddetail");

	//////////////////// STORE /////////////////////////////////
	var tstore= new MetaTable("store");
	tstore.defineColumn("idstore", typeof(int),false);
	tstore.defineColumn("description", typeof(string),false);
	tstore.defineColumn("deliveryaddress", typeof(string),false);
	tstore.defineColumn("active", typeof(string),false);
	tstore.defineColumn("cu", typeof(string),false);
	tstore.defineColumn("ct", typeof(DateTime),false);
	tstore.defineColumn("lu", typeof(string),false);
	tstore.defineColumn("lt", typeof(DateTime),false);
	tstore.defineColumn("email", typeof(string));
	tstore.defineColumn("idupb", typeof(string));
	tstore.defineColumn("idsor01", typeof(int));
	tstore.defineColumn("idsor02", typeof(int));
	tstore.defineColumn("idsor03", typeof(int));
	tstore.defineColumn("idsor04", typeof(int));
	tstore.defineColumn("idsor05", typeof(int));
	tstore.defineColumn("virtual", typeof(string));
	tstore.defineColumn("idestimkind", typeof(string));
	Tables.Add(tstore);
	tstore.defineKey("idstore");

	//////////////////// LIST /////////////////////////////////
	var tlist= new listTable();
	tlist.addBaseColumns("idlist","description","intcode","intbarcode","extcode","extbarcode","validitystop","active","idpackage","idunit","unitsforpackage","has_expiry","cu","ct","lu","lt","idlistclass","pic","picext","nmin","ntoreorder","tounload","timesupply","nmaxorder","price","insinfo","descrforuser");
	Tables.Add(tlist);
	tlist.defineKey("idlist");

	//////////////////// SORTING1 /////////////////////////////////
	var tsorting1= new MetaTable("sorting1");
	tsorting1.defineColumn("idsorkind", typeof(int),false);
	tsorting1.defineColumn("idsor", typeof(int),false);
	tsorting1.defineColumn("sortcode", typeof(string),false);
	tsorting1.defineColumn("paridsor", typeof(int));
	tsorting1.defineColumn("nlevel", typeof(byte),false);
	tsorting1.defineColumn("description", typeof(string),false);
	tsorting1.defineColumn("txt", typeof(string));
	tsorting1.defineColumn("rtf", typeof(Byte[]));
	tsorting1.defineColumn("cu", typeof(string),false);
	tsorting1.defineColumn("ct", typeof(DateTime),false);
	tsorting1.defineColumn("lu", typeof(string),false);
	tsorting1.defineColumn("lt", typeof(DateTime),false);
	tsorting1.defineColumn("defaultn1", typeof(decimal));
	tsorting1.defineColumn("defaultn2", typeof(decimal));
	tsorting1.defineColumn("defaultn3", typeof(decimal));
	tsorting1.defineColumn("defaultn4", typeof(decimal));
	tsorting1.defineColumn("defaultn5", typeof(decimal));
	tsorting1.defineColumn("defaults1", typeof(string));
	tsorting1.defineColumn("defaults2", typeof(string));
	tsorting1.defineColumn("defaults3", typeof(string));
	tsorting1.defineColumn("defaults4", typeof(string));
	tsorting1.defineColumn("defaults5", typeof(string));
	tsorting1.defineColumn("flagnodate", typeof(string));
	tsorting1.defineColumn("movkind", typeof(string));
	tsorting1.defineColumn("printingorder", typeof(string));
	tsorting1.defineColumn("defaultv1", typeof(decimal));
	tsorting1.defineColumn("defaultv2", typeof(decimal));
	tsorting1.defineColumn("defaultv3", typeof(decimal));
	tsorting1.defineColumn("defaultv4", typeof(decimal));
	tsorting1.defineColumn("defaultv5", typeof(decimal));
	Tables.Add(tsorting1);
	tsorting1.defineKey("idsor");

	//////////////////// SORTING2 /////////////////////////////////
	var tsorting2= new MetaTable("sorting2");
	tsorting2.defineColumn("idsorkind", typeof(int),false);
	tsorting2.defineColumn("idsor", typeof(int),false);
	tsorting2.defineColumn("sortcode", typeof(string),false);
	tsorting2.defineColumn("paridsor", typeof(int));
	tsorting2.defineColumn("nlevel", typeof(byte),false);
	tsorting2.defineColumn("description", typeof(string),false);
	tsorting2.defineColumn("txt", typeof(string));
	tsorting2.defineColumn("rtf", typeof(Byte[]));
	tsorting2.defineColumn("cu", typeof(string),false);
	tsorting2.defineColumn("ct", typeof(DateTime),false);
	tsorting2.defineColumn("lu", typeof(string),false);
	tsorting2.defineColumn("lt", typeof(DateTime),false);
	tsorting2.defineColumn("defaultn1", typeof(decimal));
	tsorting2.defineColumn("defaultn2", typeof(decimal));
	tsorting2.defineColumn("defaultn3", typeof(decimal));
	tsorting2.defineColumn("defaultn4", typeof(decimal));
	tsorting2.defineColumn("defaultn5", typeof(decimal));
	tsorting2.defineColumn("defaults1", typeof(string));
	tsorting2.defineColumn("defaults2", typeof(string));
	tsorting2.defineColumn("defaults3", typeof(string));
	tsorting2.defineColumn("defaults4", typeof(string));
	tsorting2.defineColumn("defaults5", typeof(string));
	tsorting2.defineColumn("flagnodate", typeof(string));
	tsorting2.defineColumn("movkind", typeof(string));
	tsorting2.defineColumn("printingorder", typeof(string));
	tsorting2.defineColumn("defaultv1", typeof(decimal));
	tsorting2.defineColumn("defaultv2", typeof(decimal));
	tsorting2.defineColumn("defaultv3", typeof(decimal));
	tsorting2.defineColumn("defaultv4", typeof(decimal));
	tsorting2.defineColumn("defaultv5", typeof(decimal));
	Tables.Add(tsorting2);
	tsorting2.defineKey("idsor");

	//////////////////// SORTING3 /////////////////////////////////
	var tsorting3= new MetaTable("sorting3");
	tsorting3.defineColumn("idsorkind", typeof(int),false);
	tsorting3.defineColumn("idsor", typeof(int),false);
	tsorting3.defineColumn("sortcode", typeof(string),false);
	tsorting3.defineColumn("paridsor", typeof(int));
	tsorting3.defineColumn("nlevel", typeof(byte),false);
	tsorting3.defineColumn("description", typeof(string),false);
	tsorting3.defineColumn("txt", typeof(string));
	tsorting3.defineColumn("rtf", typeof(Byte[]));
	tsorting3.defineColumn("cu", typeof(string),false);
	tsorting3.defineColumn("ct", typeof(DateTime),false);
	tsorting3.defineColumn("lu", typeof(string),false);
	tsorting3.defineColumn("lt", typeof(DateTime),false);
	tsorting3.defineColumn("defaultn1", typeof(decimal));
	tsorting3.defineColumn("defaultn2", typeof(decimal));
	tsorting3.defineColumn("defaultn3", typeof(decimal));
	tsorting3.defineColumn("defaultn4", typeof(decimal));
	tsorting3.defineColumn("defaultn5", typeof(decimal));
	tsorting3.defineColumn("defaults1", typeof(string));
	tsorting3.defineColumn("defaults2", typeof(string));
	tsorting3.defineColumn("defaults3", typeof(string));
	tsorting3.defineColumn("defaults4", typeof(string));
	tsorting3.defineColumn("defaults5", typeof(string));
	tsorting3.defineColumn("flagnodate", typeof(string));
	tsorting3.defineColumn("movkind", typeof(string));
	tsorting3.defineColumn("printingorder", typeof(string));
	tsorting3.defineColumn("defaultv1", typeof(decimal));
	tsorting3.defineColumn("defaultv2", typeof(decimal));
	tsorting3.defineColumn("defaultv3", typeof(decimal));
	tsorting3.defineColumn("defaultv4", typeof(decimal));
	tsorting3.defineColumn("defaultv5", typeof(decimal));
	Tables.Add(tsorting3);
	tsorting3.defineKey("idsor");

	//////////////////// LISTCLASS /////////////////////////////////
	var tlistclass= new MetaTable("listclass");
	tlistclass.defineColumn("idlistclass", typeof(string),false);
	tlistclass.defineColumn("active", typeof(string),false);
	tlistclass.defineColumn("codelistclass", typeof(string),false);
	tlistclass.defineColumn("paridlistclass", typeof(string));
	tlistclass.defineColumn("printingorder", typeof(string),false);
	tlistclass.defineColumn("title", typeof(string),false);
	tlistclass.defineColumn("rtf", typeof(Byte[]));
	tlistclass.defineColumn("txt", typeof(string));
	tlistclass.defineColumn("ct", typeof(DateTime),false);
	tlistclass.defineColumn("cu", typeof(string),false);
	tlistclass.defineColumn("lt", typeof(DateTime),false);
	tlistclass.defineColumn("lu", typeof(string),false);
	tlistclass.defineColumn("authrequired", typeof(string));
	tlistclass.defineColumn("idaccmotive", typeof(string));
	tlistclass.defineColumn("idinv", typeof(int));
	tlistclass.defineColumn("assetkind", typeof(string));
	tlistclass.defineColumn("va3type", typeof(string));
	tlistclass.defineColumn("flag", typeof(int));
	tlistclass.defineColumn("idintrastatsupplymethod", typeof(int));
	tlistclass.defineColumn("intra12operationkind", typeof(string));
	tlistclass.defineColumn("flagvisiblekind", typeof(byte));
	tlistclass.defineColumn("idfinmotive", typeof(string));
	tlistclass.defineColumn("idaccmotivecredit", typeof(string));
	Tables.Add(tlistclass);
	tlistclass.defineKey("idlistclass");

	#endregion


	#region DataRelation creation
	this.defineRelation("store_webpaymentdetail","store","webpaymentdetail","idstore");
	this.defineRelation("list_webpaymentdetail","list","webpaymentdetail","idlist");
	var cPar = new []{sorting1.Columns["idsor"]};
	var cChild = new []{webpaymentdetail.Columns["idsor1"]};
	Relations.Add(new DataRelation("sorting1_webpaymentdetail",cPar,cChild,false));

	cPar = new []{sorting2.Columns["idsor"]};
	cChild = new []{webpaymentdetail.Columns["idsor2"]};
	Relations.Add(new DataRelation("sorting2_webpaymentdetail",cPar,cChild,false));

	cPar = new []{sorting3.Columns["idsor"]};
	cChild = new []{webpaymentdetail.Columns["idsor3"]};
	Relations.Add(new DataRelation("sorting3_webpaymentdetail",cPar,cChild,false));

	this.defineRelation("listclass_list","listclass","list","idlistclass");
	#endregion

}
}
}
