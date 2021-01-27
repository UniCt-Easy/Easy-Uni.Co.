
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
using meta_webpayment;
using meta_webpaymentdetail;
using meta_list;
using meta_registry;
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace webpayment_prenotazioni_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta: DataSet {

	#region Table members declaration
	///<summary>
	///Pagamento web
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public webpaymentTable webpayment 		=> (webpaymentTable)Tables["webpayment"];

	///<summary>
	///Dett. pagamento web
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public webpaymentdetailTable webpaymentdetail 		=> (webpaymentdetailTable)Tables["webpaymentdetail"];

	///<summary>
	///Listino
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public listTable list 		=> (listTable)Tables["list"];

	///<summary>
	///Magazzino
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable store 		=> (MetaTable)Tables["store"];

	///<summary>
	///stato pagamento web
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable webpaymentstatus 		=> (MetaTable)Tables["webpaymentstatus"];

	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public registryTable registry 		=> (registryTable)Tables["registry"];

	///<summary>
	///Classificazione Merceologica
	///</summary>
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
	//////////////////// WEBPAYMENT /////////////////////////////////
	var twebpayment= new webpaymentTable();
	twebpayment.addBaseColumns("idwebpayment","cf","ct","cu","email","forename","idcustomuser","idlcard","idman","lt","lu","nwebpayment","surname","ywebpayment","idwebpaymentstatus","idreg","idflussocrediti","qrcode","iuv","adate");
	Tables.Add(twebpayment);
	twebpayment.defineKey("idwebpayment");

	//////////////////// WEBPAYMENTDETAIL /////////////////////////////////
	var twebpaymentdetail= new webpaymentdetailTable();
	twebpaymentdetail.addBaseColumns("idwebpayment","idlist","idstore","ct","cu","idsor1","idsor2","idsor3","lt","lu","number","price","iddetail","idupb","idestimkind","paymentexpiring","idivakind","tax","annotations","idinvkind","competencystart","competencystop","idupb_iva");
	twebpaymentdetail.defineColumn("!list", typeof(string));
	twebpaymentdetail.defineColumn("!store", typeof(string));
	twebpaymentdetail.defineColumn("!totale", typeof(decimal));
	Tables.Add(twebpaymentdetail);
	twebpaymentdetail.defineKey("idwebpayment", "iddetail");

	//////////////////// LIST /////////////////////////////////
	var tlist= new listTable();
	tlist.addBaseColumns("idlist","description","intcode","intbarcode","extcode","extbarcode","validitystop","active","idpackage","idunit","unitsforpackage","has_expiry","cu","ct","lu","lt","idlistclass","pic","picext","nmin","ntoreorder","tounload","timesupply","nmaxorder","price","insinfo","descrforuser");
	Tables.Add(tlist);
	tlist.defineKey("idlist");

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

	//////////////////// WEBPAYMENTSTATUS /////////////////////////////////
	var twebpaymentstatus= new MetaTable("webpaymentstatus");
	twebpaymentstatus.defineColumn("idwebpaymentstatus", typeof(short),false);
	twebpaymentstatus.defineColumn("ct", typeof(DateTime),false);
	twebpaymentstatus.defineColumn("cu", typeof(string),false);
	twebpaymentstatus.defineColumn("description", typeof(string),false);
	twebpaymentstatus.defineColumn("listingorder", typeof(int));
	twebpaymentstatus.defineColumn("lt", typeof(DateTime),false);
	twebpaymentstatus.defineColumn("lu", typeof(string),false);
	Tables.Add(twebpaymentstatus);
	twebpaymentstatus.defineKey("idwebpaymentstatus");

	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new registryTable();
	tregistry.addBaseColumns("idreg","active","annotation","badgecode","birthdate","cf","ct","cu","extmatricula","foreigncf","forename","gender","idcategory","idcentralizedcategory","idcity","idmaritalstatus","idnation","idregistryclass","idtitle","location","lt","lu","maritalsurname","p_iva","rtf","surname","title","txt","residence","idregistrykind","authorization_free","multi_cf","toredirect","idaccmotivedebit","idaccmotivecredit","ccp","flagbankitaliaproceeds","idexternal","ipa_fe","flag_pa","sdi_norifamm","sdi_defrifamm","email_fe");
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

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
	this.defineRelation("list_webpaymentdetail","list","webpaymentdetail","idlist");
	this.defineRelation("store_webpaymentdetail","store","webpaymentdetail","idstore");
	this.defineRelation("webpayment_webpaymentdetail","webpayment","webpaymentdetail","idwebpayment");
	this.defineRelation("webpaymentstatus_webpayment","webpaymentstatus","webpayment","idwebpaymentstatus");
	this.defineRelation("listclass_list","listclass","list","idlistclass");
	this.defineRelation("registry_webpayment","registry","webpayment","idreg");
	#endregion

}
}
}
