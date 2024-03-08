
/*
Easy
Copyright (C) 2024 Universit‡ degli Studi di Catania (www.unict.it)
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
namespace notable_importazione {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaCpassivi"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaCpassivi: DataSet {

	#region Table members declaration
	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry 		=> Tables["registry"];

	///<summary>
	///Indirizzo di anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registryaddress 		=> Tables["registryaddress"];

	///<summary>
	///Modalit√† pagamento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registrypaymethod 		=> Tables["registrypaymethod"];

	///<summary>
	///Contratto Passivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable mandate 		=> Tables["mandate"];

	///<summary>
	///Dettaglio contratto passivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable mandatedetail 		=> Tables["mandatedetail"];

	///<summary>
	///Responsabile
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable manager 		=> Tables["manager"];

	///<summary>
	///Sezione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable division 		=> Tables["division"];

	///<summary>
	///Contabilizzazione Contratto passivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expensemandate 		=> Tables["expensemandate"];

	///<summary>
	///Tipo contratto passivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable mandatekind 		=> Tables["mandatekind"];

	///<summary>
	///Elenco aliquote
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable ivakind 		=> Tables["ivakind"];

	///<summary>
	///Listino
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable list 		=> Tables["list"];

	///<summary>
	///Piano delle Ubicazioni
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable location 		=> Tables["location"];

	///<summary>
	///Ripartizione dei costi
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable costpartition 		=> Tables["costpartition"];

	///<summary>
	///Classificazione Movimenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting 		=> Tables["sorting"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public vistaCpassivi(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected vistaCpassivi (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "vistaCpassivi";
	Prefix = "";
	Namespace = "http://tempuri.org/vistaCpassivi.xsd";

	#region create DataTables
	DataColumn C;
	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new DataTable("registry");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("annotation", typeof(string)));
	tregistry.Columns.Add( new DataColumn("badgecode", typeof(string)));
	tregistry.Columns.Add( new DataColumn("birthdate", typeof(DateTime)));
	tregistry.Columns.Add( new DataColumn("cf", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("extmatricula", typeof(string)));
	tregistry.Columns.Add( new DataColumn("foreigncf", typeof(string)));
	tregistry.Columns.Add( new DataColumn("forename", typeof(string)));
	tregistry.Columns.Add( new DataColumn("gender", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcategory", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcentralizedcategory", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcity", typeof(int)));
	tregistry.Columns.Add( new DataColumn("idmaritalstatus", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idnation", typeof(int)));
	tregistry.Columns.Add( new DataColumn("idregistryclass", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idtitle", typeof(string)));
	tregistry.Columns.Add( new DataColumn("location", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("maritalsurname", typeof(string)));
	tregistry.Columns.Add( new DataColumn("p_iva", typeof(string)));
	tregistry.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tregistry.Columns.Add( new DataColumn("surname", typeof(string)));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("residence", typeof(int));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("idregistrykind", typeof(int)));
	tregistry.Columns.Add( new DataColumn("authorization_free", typeof(string)));
	tregistry.Columns.Add( new DataColumn("multi_cf", typeof(string)));
	tregistry.Columns.Add( new DataColumn("toredirect", typeof(int)));
	tregistry.Columns.Add( new DataColumn("idaccmotivedebit", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idaccmotivecredit", typeof(string)));
	Tables.Add(tregistry);
	tregistry.PrimaryKey =  new DataColumn[]{tregistry.Columns["idreg"]};


	//////////////////// REGISTRYADDRESS /////////////////////////////////
	var tregistryaddress= new DataTable("registryaddress");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistryaddress.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	tregistryaddress.Columns.Add(C);
	tregistryaddress.Columns.Add( new DataColumn("active", typeof(string)));
	tregistryaddress.Columns.Add( new DataColumn("address", typeof(string)));
	tregistryaddress.Columns.Add( new DataColumn("annotations", typeof(string)));
	tregistryaddress.Columns.Add( new DataColumn("cap", typeof(string)));
	tregistryaddress.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tregistryaddress.Columns.Add( new DataColumn("cu", typeof(string)));
	tregistryaddress.Columns.Add( new DataColumn("flagforeign", typeof(string)));
	tregistryaddress.Columns.Add( new DataColumn("idcity", typeof(int)));
	tregistryaddress.Columns.Add( new DataColumn("idnation", typeof(int)));
	tregistryaddress.Columns.Add( new DataColumn("location", typeof(string)));
	tregistryaddress.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tregistryaddress.Columns.Add( new DataColumn("lu", typeof(string)));
	tregistryaddress.Columns.Add( new DataColumn("officename", typeof(string)));
	tregistryaddress.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	C= new DataColumn("idaddresskind", typeof(int));
	C.AllowDBNull=false;
	tregistryaddress.Columns.Add(C);
	tregistryaddress.Columns.Add( new DataColumn("recipientagency", typeof(string)));
	Tables.Add(tregistryaddress);
	tregistryaddress.PrimaryKey =  new DataColumn[]{tregistryaddress.Columns["idreg"], tregistryaddress.Columns["start"], tregistryaddress.Columns["idaddresskind"]};


	//////////////////// REGISTRYPAYMETHOD /////////////////////////////////
	var tregistrypaymethod= new DataTable("registrypaymethod");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistrypaymethod.Columns.Add(C);
	C= new DataColumn("idregistrypaymethod", typeof(int));
	C.AllowDBNull=false;
	tregistrypaymethod.Columns.Add(C);
	C= new DataColumn("regmodcode", typeof(string));
	C.AllowDBNull=false;
	tregistrypaymethod.Columns.Add(C);
	tregistrypaymethod.Columns.Add( new DataColumn("active", typeof(string)));
	tregistrypaymethod.Columns.Add( new DataColumn("cc", typeof(string)));
	tregistrypaymethod.Columns.Add( new DataColumn("cin", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistrypaymethod.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistrypaymethod.Columns.Add(C);
	tregistrypaymethod.Columns.Add( new DataColumn("flagstandard", typeof(string)));
	tregistrypaymethod.Columns.Add( new DataColumn("iban", typeof(string)));
	tregistrypaymethod.Columns.Add( new DataColumn("idbank", typeof(string)));
	tregistrypaymethod.Columns.Add( new DataColumn("idcab", typeof(string)));
	tregistrypaymethod.Columns.Add( new DataColumn("iddeputy", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistrypaymethod.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistrypaymethod.Columns.Add(C);
	tregistrypaymethod.Columns.Add( new DataColumn("paymentdescr", typeof(string)));
	tregistrypaymethod.Columns.Add( new DataColumn("paymentexpiring", typeof(short)));
	tregistrypaymethod.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tregistrypaymethod.Columns.Add( new DataColumn("txt", typeof(string)));
	tregistrypaymethod.Columns.Add( new DataColumn("refexternaldoc", typeof(string)));
	tregistrypaymethod.Columns.Add( new DataColumn("idcurrency", typeof(int)));
	tregistrypaymethod.Columns.Add( new DataColumn("idpaymethod", typeof(int)));
	tregistrypaymethod.Columns.Add( new DataColumn("idexpirationkind", typeof(short)));
	tregistrypaymethod.Columns.Add( new DataColumn("extracode", typeof(string)));
	Tables.Add(tregistrypaymethod);
	tregistrypaymethod.PrimaryKey =  new DataColumn[]{tregistrypaymethod.Columns["idreg"], tregistrypaymethod.Columns["idregistrypaymethod"]};


	//////////////////// MANDATE /////////////////////////////////
	var tmandate= new DataTable("mandate");
	C= new DataColumn("yman", typeof(short));
	C.AllowDBNull=false;
	tmandate.Columns.Add(C);
	C= new DataColumn("nman", typeof(int));
	C.AllowDBNull=false;
	tmandate.Columns.Add(C);
	tmandate.Columns.Add( new DataColumn("idreg", typeof(int)));
	tmandate.Columns.Add( new DataColumn("registryreference", typeof(string)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tmandate.Columns.Add(C);
	tmandate.Columns.Add( new DataColumn("idman", typeof(int)));
	tmandate.Columns.Add( new DataColumn("deliveryexpiration", typeof(string)));
	tmandate.Columns.Add( new DataColumn("deliveryaddress", typeof(string)));
	tmandate.Columns.Add( new DataColumn("paymentexpiring", typeof(short)));
	tmandate.Columns.Add( new DataColumn("idexpirationkind", typeof(short)));
	tmandate.Columns.Add( new DataColumn("idcurrency", typeof(int)));
	tmandate.Columns.Add( new DataColumn("exchangerate", typeof(double)));
	tmandate.Columns.Add( new DataColumn("doc", typeof(string)));
	tmandate.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tmandate.Columns.Add(C);
	C= new DataColumn("officiallyprinted", typeof(string));
	C.AllowDBNull=false;
	tmandate.Columns.Add(C);
	tmandate.Columns.Add( new DataColumn("txt", typeof(string)));
	tmandate.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tmandate.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tmandate.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tmandate.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tmandate.Columns.Add(C);
	tmandate.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("idmankind", typeof(string));
	C.AllowDBNull=false;
	tmandate.Columns.Add(C);
	tmandate.Columns.Add( new DataColumn("flagintracom", typeof(string)));
	tmandate.Columns.Add( new DataColumn("idaccmotivedebit", typeof(string)));
	tmandate.Columns.Add( new DataColumn("idaccmotivedebit_crg", typeof(string)));
	tmandate.Columns.Add( new DataColumn("idaccmotivedebit_datacrg", typeof(DateTime)));
	tmandate.Columns.Add( new DataColumn("applierannotations", typeof(string)));
	tmandate.Columns.Add( new DataColumn("idmandatestatus", typeof(short)));
	tmandate.Columns.Add( new DataColumn("idstore", typeof(int)));
	tmandate.Columns.Add( new DataColumn("cigcode", typeof(string)));
	tmandate.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tmandate.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tmandate.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tmandate.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tmandate.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tmandate.Columns.Add( new DataColumn("idconsipkind", typeof(int)));
	tmandate.Columns.Add( new DataColumn("flagdanger", typeof(string)));
	tmandate.Columns.Add( new DataColumn("idmankind_origin", typeof(string)));
	tmandate.Columns.Add( new DataColumn("yman_origin", typeof(short)));
	tmandate.Columns.Add( new DataColumn("nman_origin", typeof(int)));
	tmandate.Columns.Add( new DataColumn("subappropriation", typeof(string)));
	tmandate.Columns.Add( new DataColumn("finsubappropriation", typeof(string)));
	tmandate.Columns.Add( new DataColumn("adatesubappropriation", typeof(DateTime)));
	tmandate.Columns.Add( new DataColumn("arrivalprotocolnum", typeof(string)));
	tmandate.Columns.Add( new DataColumn("arrivaldate", typeof(DateTime)));
	tmandate.Columns.Add( new DataColumn("annotations", typeof(string)));
	tmandate.Columns.Add( new DataColumn("resendingpcc", typeof(string)));
	tmandate.Columns.Add( new DataColumn("external_reference", typeof(string)));
	tmandate.Columns.Add( new DataColumn("idconsipkind_ext", typeof(int)));
	tmandate.Columns.Add( new DataColumn("consipmotive", typeof(string)));
	tmandate.Columns.Add( new DataColumn("flagtenderresult", typeof(string)));
	tmandate.Columns.Add( new DataColumn("motiveassignment", typeof(string)));
	tmandate.Columns.Add( new DataColumn("publishdate", typeof(DateTime)));
	tmandate.Columns.Add( new DataColumn("idreg_rupanac", typeof(int)));
	tmandate.Columns.Add( new DataColumn("publishdatekind", typeof(string)));
	tmandate.Columns.Add( new DataColumn("tenderkind", typeof(string)));
	tmandate.Columns.Add( new DataColumn("requested_doc", typeof(string)));
	tmandate.Columns.Add( new DataColumn("flagbit", typeof(string)));
	Tables.Add(tmandate);
	tmandate.PrimaryKey =  new DataColumn[]{tmandate.Columns["idmankind"], tmandate.Columns["nman"], tmandate.Columns["yman"]};


	//////////////////// MANDATEDETAIL /////////////////////////////////
	var tmandatedetail= new DataTable("mandatedetail");
	C= new DataColumn("yman", typeof(short));
	C.AllowDBNull=false;
	tmandatedetail.Columns.Add(C);
	C= new DataColumn("nman", typeof(int));
	C.AllowDBNull=false;
	tmandatedetail.Columns.Add(C);
	C= new DataColumn("rownum", typeof(int));
	C.AllowDBNull=false;
	tmandatedetail.Columns.Add(C);
	tmandatedetail.Columns.Add( new DataColumn("detaildescription", typeof(string)));
	tmandatedetail.Columns.Add( new DataColumn("annotations", typeof(string)));
	tmandatedetail.Columns.Add( new DataColumn("number", typeof(decimal)));
	tmandatedetail.Columns.Add( new DataColumn("taxable", typeof(decimal)));
	tmandatedetail.Columns.Add( new DataColumn("taxrate", typeof(double)));
	tmandatedetail.Columns.Add( new DataColumn("discount", typeof(double)));
	tmandatedetail.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tmandatedetail.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tmandatedetail.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tmandatedetail.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tmandatedetail.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tmandatedetail.Columns.Add(C);
	tmandatedetail.Columns.Add( new DataColumn("idinv", typeof(int)));
	C= new DataColumn("assetkind", typeof(string));
	C.AllowDBNull=false;
	tmandatedetail.Columns.Add(C);
	tmandatedetail.Columns.Add( new DataColumn("idexp_iva", typeof(int)));
	tmandatedetail.Columns.Add( new DataColumn("idexp_taxable", typeof(int)));
	tmandatedetail.Columns.Add( new DataColumn("idupb", typeof(string)));
	tmandatedetail.Columns.Add( new DataColumn("toinvoice", typeof(string)));
	tmandatedetail.Columns.Add( new DataColumn("idsor1", typeof(int)));
	tmandatedetail.Columns.Add( new DataColumn("idsor2", typeof(int)));
	tmandatedetail.Columns.Add( new DataColumn("idsor3", typeof(int)));
	C= new DataColumn("idmankind", typeof(string));
	C.AllowDBNull=false;
	tmandatedetail.Columns.Add(C);
	tmandatedetail.Columns.Add( new DataColumn("competencystart", typeof(DateTime)));
	tmandatedetail.Columns.Add( new DataColumn("competencystop", typeof(DateTime)));
	tmandatedetail.Columns.Add( new DataColumn("tax", typeof(decimal)));
	tmandatedetail.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	tmandatedetail.Columns.Add( new DataColumn("idivakind", typeof(int)));
	tmandatedetail.Columns.Add( new DataColumn("unabatable", typeof(decimal)));
	tmandatedetail.Columns.Add( new DataColumn("flagmixed", typeof(string)));
	tmandatedetail.Columns.Add( new DataColumn("idreg", typeof(int)));
	tmandatedetail.Columns.Add( new DataColumn("idgroup", typeof(int)));
	tmandatedetail.Columns.Add( new DataColumn("ninvoiced", typeof(decimal)));
	tmandatedetail.Columns.Add( new DataColumn("flagactivity", typeof(short)));
	tmandatedetail.Columns.Add( new DataColumn("va3type", typeof(string)));
	tmandatedetail.Columns.Add( new DataColumn("ivanotes", typeof(string)));
	tmandatedetail.Columns.Add( new DataColumn("idlist", typeof(int)));
	tmandatedetail.Columns.Add( new DataColumn("idunit", typeof(int)));
	tmandatedetail.Columns.Add( new DataColumn("idpackage", typeof(int)));
	tmandatedetail.Columns.Add( new DataColumn("unitsforpackage", typeof(int)));
	tmandatedetail.Columns.Add( new DataColumn("cupcode", typeof(string)));
	tmandatedetail.Columns.Add( new DataColumn("npackage", typeof(decimal)));
	tmandatedetail.Columns.Add( new DataColumn("cigcode", typeof(string)));
	tmandatedetail.Columns.Add( new DataColumn("flagto_unload", typeof(string)));
	tmandatedetail.Columns.Add( new DataColumn("epkind", typeof(string)));
	tmandatedetail.Columns.Add( new DataColumn("rownum_origin", typeof(int)));
	tmandatedetail.Columns.Add( new DataColumn("contractamount", typeof(decimal)));
	tmandatedetail.Columns.Add( new DataColumn("idavcp", typeof(int)));
	tmandatedetail.Columns.Add( new DataColumn("idavcp_choice", typeof(string)));
	tmandatedetail.Columns.Add( new DataColumn("avcp_startcontract", typeof(DateTime)));
	tmandatedetail.Columns.Add( new DataColumn("avcp_stopcontract", typeof(DateTime)));
	tmandatedetail.Columns.Add( new DataColumn("avcp_description", typeof(string)));
	tmandatedetail.Columns.Add( new DataColumn("idcostpartition", typeof(int)));
	tmandatedetail.Columns.Add( new DataColumn("idpccdebitstatus", typeof(string)));
	tmandatedetail.Columns.Add( new DataColumn("idpccdebitmotive", typeof(string)));
	tmandatedetail.Columns.Add( new DataColumn("expensekind", typeof(string)));
	tmandatedetail.Columns.Add( new DataColumn("idepexp", typeof(int)));
	tmandatedetail.Columns.Add( new DataColumn("idlocation", typeof(int)));
	tmandatedetail.Columns.Add( new DataColumn("idsor_siope", typeof(int)));
	Tables.Add(tmandatedetail);
	tmandatedetail.PrimaryKey =  new DataColumn[]{tmandatedetail.Columns["idmankind"], tmandatedetail.Columns["nman"], tmandatedetail.Columns["rownum"], tmandatedetail.Columns["yman"]};


	//////////////////// MANAGER /////////////////////////////////
	var tmanager= new DataTable("manager");
	tmanager.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	tmanager.Columns.Add( new DataColumn("email", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	tmanager.Columns.Add( new DataColumn("passwordweb", typeof(string)));
	tmanager.Columns.Add( new DataColumn("phonenumber", typeof(string)));
	tmanager.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	tmanager.Columns.Add( new DataColumn("txt", typeof(string)));
	tmanager.Columns.Add( new DataColumn("userweb", typeof(string)));
	C= new DataColumn("idman", typeof(int));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("iddivision", typeof(int));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	tmanager.Columns.Add( new DataColumn("wantswarn", typeof(string)));
	tmanager.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tmanager.Columns.Add( new DataColumn("newidman", typeof(int)));
	tmanager.Columns.Add( new DataColumn("financeactive", typeof(string)));
	Tables.Add(tmanager);
	tmanager.PrimaryKey =  new DataColumn[]{tmanager.Columns["idman"]};


	//////////////////// DIVISION /////////////////////////////////
	var tdivision= new DataTable("division");
	tdivision.Columns.Add( new DataColumn("address", typeof(string)));
	tdivision.Columns.Add( new DataColumn("cap", typeof(string)));
	tdivision.Columns.Add( new DataColumn("city", typeof(string)));
	tdivision.Columns.Add( new DataColumn("country", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tdivision.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tdivision.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tdivision.Columns.Add(C);
	tdivision.Columns.Add( new DataColumn("faxnumber", typeof(string)));
	tdivision.Columns.Add( new DataColumn("faxprefix", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tdivision.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tdivision.Columns.Add(C);
	tdivision.Columns.Add( new DataColumn("phonenumber", typeof(string)));
	tdivision.Columns.Add( new DataColumn("phoneprefix", typeof(string)));
	tdivision.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tdivision.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("codedivision", typeof(string));
	C.AllowDBNull=false;
	tdivision.Columns.Add(C);
	C= new DataColumn("iddivision", typeof(int));
	C.AllowDBNull=false;
	tdivision.Columns.Add(C);
	Tables.Add(tdivision);
	tdivision.PrimaryKey =  new DataColumn[]{tdivision.Columns["iddivision"]};


	//////////////////// EXPENSEMANDATE /////////////////////////////////
	var texpensemandate= new DataTable("expensemandate");
	C= new DataColumn("idmankind", typeof(string));
	C.AllowDBNull=false;
	texpensemandate.Columns.Add(C);
	C= new DataColumn("nman", typeof(int));
	C.AllowDBNull=false;
	texpensemandate.Columns.Add(C);
	C= new DataColumn("yman", typeof(short));
	C.AllowDBNull=false;
	texpensemandate.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpensemandate.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpensemandate.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpensemandate.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpensemandate.Columns.Add(C);
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpensemandate.Columns.Add(C);
	C= new DataColumn("movkind", typeof(short));
	C.AllowDBNull=false;
	texpensemandate.Columns.Add(C);
	Tables.Add(texpensemandate);
	texpensemandate.PrimaryKey =  new DataColumn[]{texpensemandate.Columns["idmankind"], texpensemandate.Columns["nman"], texpensemandate.Columns["yman"], texpensemandate.Columns["idexp"]};


	//////////////////// MANDATEKIND /////////////////////////////////
	var tmandatekind= new DataTable("mandatekind");
	C= new DataColumn("idmankind", typeof(string));
	C.AllowDBNull=false;
	tmandatekind.Columns.Add(C);
	tmandatekind.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tmandatekind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tmandatekind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tmandatekind.Columns.Add(C);
	tmandatekind.Columns.Add( new DataColumn("idupb", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tmandatekind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tmandatekind.Columns.Add(C);
	tmandatekind.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tmandatekind.Columns.Add( new DataColumn("txt", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("email", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("faxnumber", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("office", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("phonenumber", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("linktoasset", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("linktoinvoice", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("multireg", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("deltaamount", typeof(decimal)));
	tmandatekind.Columns.Add( new DataColumn("deltapercentage", typeof(decimal)));
	tmandatekind.Columns.Add( new DataColumn("flag_autodocnumbering", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("flagactivity", typeof(short)));
	tmandatekind.Columns.Add( new DataColumn("name_c", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("name_l", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("name_r", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("title_c", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("title_l", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("title_r", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("notes1", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("notes2", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("notes3", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("warnmail", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("isrequest", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tmandatekind.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tmandatekind.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tmandatekind.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tmandatekind.Columns.Add( new DataColumn("idsor05", typeof(int)));
	C= new DataColumn("assetkind", typeof(byte));
	C.AllowDBNull=false;
	tmandatekind.Columns.Add(C);
	tmandatekind.Columns.Add( new DataColumn("dangermail", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("address", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("header", typeof(string)));
	Tables.Add(tmandatekind);
	tmandatekind.PrimaryKey =  new DataColumn[]{tmandatekind.Columns["idmankind"]};


	//////////////////// IVAKIND /////////////////////////////////
	var tivakind= new DataTable("ivakind");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	C= new DataColumn("rate", typeof(decimal));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	C= new DataColumn("unabatabilitypercentage", typeof(decimal));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	tivakind.Columns.Add( new DataColumn("active", typeof(string)));
	tivakind.Columns.Add( new DataColumn("idivataxablekind", typeof(int)));
	C= new DataColumn("idivakind", typeof(int));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	tivakind.Columns.Add( new DataColumn("codeivakind", typeof(string)));
	tivakind.Columns.Add( new DataColumn("flag", typeof(int)));
	tivakind.Columns.Add( new DataColumn("annotations", typeof(string)));
	Tables.Add(tivakind);
	tivakind.PrimaryKey =  new DataColumn[]{tivakind.Columns["idivakind"]};


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
	tlist.Columns.Add( new DataColumn("picext", typeof(string)));
	tlist.Columns.Add( new DataColumn("nmin", typeof(decimal)));
	tlist.Columns.Add( new DataColumn("ntoreorder", typeof(decimal)));
	tlist.Columns.Add( new DataColumn("tounload", typeof(string)));
	tlist.Columns.Add( new DataColumn("timesupply", typeof(int)));
	tlist.Columns.Add( new DataColumn("nmaxorder", typeof(decimal)));
	Tables.Add(tlist);
	tlist.PrimaryKey =  new DataColumn[]{tlist.Columns["idlist"]};


	//////////////////// LOCATION /////////////////////////////////
	var tlocation= new DataTable("location");
	tlocation.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tlocation.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tlocation.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tlocation.Columns.Add(C);
	C= new DataColumn("locationcode", typeof(string));
	C.AllowDBNull=false;
	tlocation.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tlocation.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tlocation.Columns.Add(C);
	tlocation.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tlocation.Columns.Add( new DataColumn("txt", typeof(string)));
	tlocation.Columns.Add( new DataColumn("idman", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tlocation.Columns.Add(C);
	C= new DataColumn("idlocation", typeof(int));
	C.AllowDBNull=false;
	tlocation.Columns.Add(C);
	tlocation.Columns.Add( new DataColumn("paridlocation", typeof(int)));
	tlocation.Columns.Add( new DataColumn("newlocationcode", typeof(string)));
	tlocation.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tlocation.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tlocation.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tlocation.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tlocation.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tlocation);
	tlocation.PrimaryKey =  new DataColumn[]{tlocation.Columns["idlocation"]};


	//////////////////// COSTPARTITION /////////////////////////////////
	var tcostpartition= new DataTable("costpartition");
	C= new DataColumn("idcostpartition", typeof(int));
	C.AllowDBNull=false;
	tcostpartition.Columns.Add(C);
	tcostpartition.Columns.Add( new DataColumn("title", typeof(string)));
	tcostpartition.Columns.Add( new DataColumn("kind", typeof(string)));
	tcostpartition.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tcostpartition.Columns.Add( new DataColumn("lu", typeof(string)));
	tcostpartition.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tcostpartition.Columns.Add( new DataColumn("cu", typeof(string)));
	tcostpartition.Columns.Add( new DataColumn("costpartitioncode", typeof(string)));
	tcostpartition.Columns.Add( new DataColumn("active", typeof(string)));
	tcostpartition.Columns.Add( new DataColumn("description", typeof(string)));
	Tables.Add(tcostpartition);
	tcostpartition.PrimaryKey =  new DataColumn[]{tcostpartition.Columns["idcostpartition"]};


	//////////////////// SORTING /////////////////////////////////
	var tsorting= new DataTable("sorting");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting.Columns.Add( new DataColumn("stop", typeof(short)));
	tsorting.Columns.Add( new DataColumn("email", typeof(string)));
	tsorting.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tsorting.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tsorting.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tsorting.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tsorting.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tsorting);
	tsorting.PrimaryKey =  new DataColumn[]{tsorting.Columns["idsor"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{mandate.Columns["idmankind"], mandate.Columns["nman"], mandate.Columns["yman"]};
	var cChild = new []{expensemandate.Columns["idmankind"], expensemandate.Columns["nman"], expensemandate.Columns["yman"]};
	Relations.Add(new DataRelation("mandate_expensemandate",cPar,cChild,false));

	cPar = new []{division.Columns["iddivision"]};
	cChild = new []{manager.Columns["iddivision"]};
	Relations.Add(new DataRelation("division_manager",cPar,cChild,false));

	cPar = new []{mandate.Columns["idmankind"], mandate.Columns["nman"], mandate.Columns["yman"]};
	cChild = new []{mandatedetail.Columns["idmankind"], mandatedetail.Columns["nman"], mandatedetail.Columns["yman"]};
	Relations.Add(new DataRelation("FK_mandatedetail_mandate",cPar,cChild,false));

	cPar = new []{ivakind.Columns["idivakind"]};
	cChild = new []{mandatedetail.Columns["idivakind"]};
	Relations.Add(new DataRelation("FK_ivakind_mandatedetail",cPar,cChild,false));

	cPar = new []{manager.Columns["idman"]};
	cChild = new []{mandate.Columns["idman"]};
	Relations.Add(new DataRelation("manager_mandate",cPar,cChild,false));

	cPar = new []{mandatekind.Columns["idmankind"]};
	cChild = new []{mandate.Columns["idmankind"]};
	Relations.Add(new DataRelation("FK_mandatekind_mandate",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registrypaymethod.Columns["idreg"]};
	Relations.Add(new DataRelation("registry_registrypaymethod",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registryaddress.Columns["idreg"]};
	Relations.Add(new DataRelation("registry_registryaddress",cPar,cChild,false));

	#endregion

}
}
}
