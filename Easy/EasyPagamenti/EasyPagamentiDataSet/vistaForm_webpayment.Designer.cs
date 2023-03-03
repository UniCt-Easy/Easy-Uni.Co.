
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
using System.Globalization;
using System.Runtime.Serialization;
#pragma warning disable 1591
namespace EasyPagamentiDataSet {
[Serializable()][DesignerCategoryAttribute("code")][System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRootAttribute("vistaForm_webpayment")][System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
public partial class vistaForm_webpayment: DataSet {

	#region Table members declaration
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable registryreference		{get { return Tables["registryreference"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable webpayment		{get { return Tables["webpayment"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable webpaymentdetail		{get { return Tables["webpaymentdetail"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable list		{get { return Tables["list"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable store		{get { return Tables["store"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable webpaymentview		{get { return Tables["webpaymentview"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable webpaymentstatus		{get { return Tables["webpaymentstatus"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable flussocrediti		{get { return Tables["flussocrediti"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable flussocreditidetail		{get { return Tables["flussocreditidetail"];}}
	#endregion


	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables {get {return base.Tables;}}

	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataRelationCollection Relations {get {return base.Relations; } } 

[DebuggerNonUserCodeAttribute()]
public vistaForm_webpayment(){
	BeginInit();
	InitClass();
	EndInit();
}
[DebuggerNonUserCodeAttribute()]
protected vistaForm_webpayment (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCodeAttribute()]
private void InitClass() {
	DataSetName = "vistaForm_webpayment";
	Prefix = "";
	Namespace = "http://tempuri.org/vistaForm_webpayment.xsd";
	EnforceConstraints = false;

	#region create DataTables
	DataTable T;
	DataColumn C;
	//////////////////// REGISTRYREFERENCE /////////////////////////////////
	T= new DataTable("registryreference");
	C= new DataColumn("idreg", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idregistryreference", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("referencename", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("email", typeof(String)));
	T.Columns.Add( new DataColumn("faxnumber", typeof(String)));
	T.Columns.Add( new DataColumn("flagdefault", typeof(String)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("mobilenumber", typeof(String)));
	T.Columns.Add( new DataColumn("passwordweb", typeof(String)));
	T.Columns.Add( new DataColumn("phonenumber", typeof(String)));
	T.Columns.Add( new DataColumn("registryreferencerole", typeof(String)));
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	T.Columns.Add( new DataColumn("userweb", typeof(String)));
	T.Columns.Add( new DataColumn("skypenumber", typeof(String)));
	T.Columns.Add( new DataColumn("msnnumber", typeof(String)));
	T.Columns.Add( new DataColumn("activeweb", typeof(String)));
	T.Columns.Add( new DataColumn("iterweb", typeof(Int32)));
	T.Columns.Add( new DataColumn("saltweb", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idreg"], T.Columns["idregistryreference"]};


	//////////////////// WEBPAYMENT /////////////////////////////////
	T= new DataTable("webpayment");
	C= new DataColumn("idwebpayment", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("cf", typeof(String)));
	T.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	T.Columns.Add( new DataColumn("cu", typeof(String)));
	T.Columns.Add( new DataColumn("email", typeof(String)));
	T.Columns.Add( new DataColumn("forename", typeof(String)));
	T.Columns.Add( new DataColumn("idcustomuser", typeof(String)));
	T.Columns.Add( new DataColumn("idlcard", typeof(Int32)));
	T.Columns.Add( new DataColumn("idman", typeof(Int32)));
	T.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	T.Columns.Add( new DataColumn("lu", typeof(String)));
	T.Columns.Add( new DataColumn("nwebpayment", typeof(Int32)));
	T.Columns.Add( new DataColumn("surname", typeof(String)));
	C= new DataColumn("ywebpayment", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idwebpaymentstatus", typeof(Int16)));
	T.Columns.Add( new DataColumn("idreg", typeof(Int32)));
	T.Columns.Add( new DataColumn("idflussocrediti", typeof(Int32)));
	T.Columns.Add( new DataColumn("qrcode", typeof(String)));
	T.Columns.Add( new DataColumn("iuv", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idwebpayment"]};


	//////////////////// WEBPAYMENTDETAIL /////////////////////////////////
	T= new DataTable("webpaymentdetail");
	C= new DataColumn("idwebpayment", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idlist", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idstore", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	T.Columns.Add( new DataColumn("cu", typeof(String)));
	T.Columns.Add( new DataColumn("idsor1", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor2", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor3", typeof(Int32)));
	T.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	T.Columns.Add( new DataColumn("lu", typeof(String)));
	C= new DataColumn("number", typeof(Decimal));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("price", typeof(Decimal)));
	T.Columns.Add( new DataColumn("!list", typeof(String)));
	T.Columns.Add( new DataColumn("!store", typeof(String)));
	C= new DataColumn("iddetail", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idwebpayment"], T.Columns["iddetail"]};


	//////////////////// LIST /////////////////////////////////
	T= new DataTable("list");
	C= new DataColumn("idlist", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("intcode", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("intbarcode", typeof(String)));
	T.Columns.Add( new DataColumn("extcode", typeof(String)));
	T.Columns.Add( new DataColumn("extbarcode", typeof(String)));
	T.Columns.Add( new DataColumn("validitystop", typeof(DateTime)));
	C= new DataColumn("active", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idpackage", typeof(Int32)));
	T.Columns.Add( new DataColumn("idunit", typeof(Int32)));
	T.Columns.Add( new DataColumn("unitsforpackage", typeof(Int32)));
	C= new DataColumn("has_expiry", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idlistclass", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("pic", typeof(Byte[])));
	T.Columns.Add( new DataColumn("picext", typeof(String)));
	T.Columns.Add( new DataColumn("nmin", typeof(Decimal)));
	T.Columns.Add( new DataColumn("ntoreorder", typeof(Decimal)));
	T.Columns.Add( new DataColumn("tounload", typeof(String)));
	T.Columns.Add( new DataColumn("timesupply", typeof(Int32)));
	T.Columns.Add( new DataColumn("nmaxorder", typeof(Decimal)));
	T.Columns.Add( new DataColumn("price", typeof(Decimal)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idlist"]};


	//////////////////// STORE /////////////////////////////////
	T= new DataTable("store");
	C= new DataColumn("idstore", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("deliveryaddress", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("active", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("email", typeof(String)));
	T.Columns.Add( new DataColumn("idupb", typeof(String)));
	T.Columns.Add( new DataColumn("idsor01", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor02", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor03", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor04", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor05", typeof(Int32)));
	T.Columns.Add( new DataColumn("virtual", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idstore"]};


	//////////////////// WEBPAYMENTVIEW /////////////////////////////////
	T= new DataTable("webpaymentview");
	C= new DataColumn("idwebpayment", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ywebpayment", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("nwebpayment", typeof(Int32)));
	T.Columns.Add( new DataColumn("forename", typeof(String)));
	T.Columns.Add( new DataColumn("surname", typeof(String)));
	T.Columns.Add( new DataColumn("cf", typeof(String)));
	T.Columns.Add( new DataColumn("idcustomuser", typeof(String)));
	T.Columns.Add( new DataColumn("idwebpaymentstatus", typeof(Int16)));
	T.Columns.Add( new DataColumn("webpaymentstatus", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idwebpayment"]};


	//////////////////// WEBPAYMENTSTATUS /////////////////////////////////
	T= new DataTable("webpaymentstatus");
	C= new DataColumn("idwebpaymentstatus", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("listingorder", typeof(Int32)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idwebpaymentstatus"]};


	//////////////////// FLUSSOCREDITI /////////////////////////////////
	T= new DataTable("flussocrediti");
	C= new DataColumn("idflusso", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("datacreazioneflusso", typeof(DateTime)));
	T.Columns.Add( new DataColumn("flusso", typeof(String)));
	T.Columns.Add( new DataColumn("istransmitted", typeof(String)));
	T.Columns.Add( new DataColumn("idsor01", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor02", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor03", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor04", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor05", typeof(Int32)));
	T.Columns.Add( new DataColumn("filename", typeof(String)));
	T.Columns.Add( new DataColumn("progday", typeof(Int32)));
	T.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	T.Columns.Add( new DataColumn("idestimkind", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idflusso"]};


	//////////////////// FLUSSOCREDITIDETAIL /////////////////////////////////
	T= new DataTable("flussocreditidetail");
	C= new DataColumn("idflusso", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("iddetail", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("importoversamento", typeof(Decimal)));
	T.Columns.Add( new DataColumn("idestimkind", typeof(String)));
	T.Columns.Add( new DataColumn("yestim", typeof(Int16)));
	T.Columns.Add( new DataColumn("nestim", typeof(Int32)));
	T.Columns.Add( new DataColumn("rownum", typeof(Int32)));
	T.Columns.Add( new DataColumn("idinvkind", typeof(Int32)));
	T.Columns.Add( new DataColumn("yinv", typeof(Int16)));
	T.Columns.Add( new DataColumn("ninv", typeof(Int32)));
	T.Columns.Add( new DataColumn("invrownum", typeof(Int32)));
	T.Columns.Add( new DataColumn("idfinmotive", typeof(String)));
	T.Columns.Add( new DataColumn("iduniqueformcode", typeof(String)));
	T.Columns.Add( new DataColumn("idaccmotiverevenue", typeof(String)));
	T.Columns.Add( new DataColumn("idaccmotivecredit", typeof(String)));
	T.Columns.Add( new DataColumn("idaccmotiveundotax", typeof(String)));
	T.Columns.Add( new DataColumn("idaccmotiveundotaxpost", typeof(String)));
	T.Columns.Add( new DataColumn("idupb", typeof(String)));
	T.Columns.Add( new DataColumn("idreg", typeof(Int32)));
	T.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	T.Columns.Add( new DataColumn("competencystart", typeof(DateTime)));
	T.Columns.Add( new DataColumn("competencystop", typeof(DateTime)));
	T.Columns.Add( new DataColumn("description", typeof(String)));
	T.Columns.Add( new DataColumn("nform", typeof(String)));
	T.Columns.Add( new DataColumn("expirationdate", typeof(DateTime)));
	T.Columns.Add( new DataColumn("barcodevalue", typeof(String)));
	T.Columns.Add( new DataColumn("barcodeimage", typeof(Byte[])));
	T.Columns.Add( new DataColumn("qrcodevalue", typeof(String)));
	T.Columns.Add( new DataColumn("qrcodeimage", typeof(Byte[])));
	T.Columns.Add( new DataColumn("cf", typeof(String)));
	T.Columns.Add( new DataColumn("iuv", typeof(String)));
	T.Columns.Add( new DataColumn("annulment", typeof(DateTime)));
	T.Columns.Add( new DataColumn("flag", typeof(Int32)));
	T.Columns.Add( new DataColumn("idunivoco", typeof(Int64)));
	T.Columns.Add( new DataColumn("codiceavviso", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idflusso"], T.Columns["iddetail"]};


	#endregion


	#region DataRelation creation
	DataColumn []CPar;
	DataColumn []CChild;
	CPar = new DataColumn[1]{registryreference.Columns["idreg"]};
	CChild = new DataColumn[1]{webpayment.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registryreference_webpayment",CPar,CChild,false));

	CPar = new DataColumn[1]{list.Columns["idlist"]};
	CChild = new DataColumn[1]{webpaymentdetail.Columns["idlist"]};
	Relations.Add(new DataRelation("list_webpaymentdetail",CPar,CChild,false));

	CPar = new DataColumn[1]{store.Columns["idstore"]};
	CChild = new DataColumn[1]{webpaymentdetail.Columns["idstore"]};
	Relations.Add(new DataRelation("store_webpaymentdetail",CPar,CChild,false));

	CPar = new DataColumn[1]{webpayment.Columns["idwebpayment"]};
	CChild = new DataColumn[1]{webpaymentdetail.Columns["idwebpayment"]};
	Relations.Add(new DataRelation("webpayment_webpaymentdetail",CPar,CChild,false));

	CPar = new DataColumn[1]{webpaymentstatus.Columns["idwebpaymentstatus"]};
	CChild = new DataColumn[1]{webpayment.Columns["idwebpaymentstatus"]};
	Relations.Add(new DataRelation("webpaymentstatus_webpayment",CPar,CChild,false));

	CPar = new DataColumn[1]{flussocrediti.Columns["idflusso"]};
	CChild = new DataColumn[1]{webpayment.Columns["idflussocrediti"]};
	Relations.Add(new DataRelation("flussocrediti_webpayment",CPar,CChild,false));

	CPar = new DataColumn[1]{flussocrediti.Columns["idflusso"]};
	CChild = new DataColumn[1]{flussocreditidetail.Columns["idflusso"]};
	Relations.Add(new DataRelation("flussocrediti_flussocreditidetail",CPar,CChild,false));

	#endregion

}
}
}
