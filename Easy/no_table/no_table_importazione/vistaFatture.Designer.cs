
/*
Easy
Copyright (C) 2022 Universit‡ degli Studi di Catania (www.unict.it)
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
[System.Xml.Serialization.XmlRoot("vistaFatture"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaFatture: DataSet {

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
	///Fattura
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable invoice 		=> Tables["invoice"];

	///<summary>
	///Dettaglio documento IVA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable invoicedetail 		=> Tables["invoicedetail"];

	///<summary>
	///Contabilizzazione fattura acquisto
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expenseinvoice 		=> Tables["expenseinvoice"];

	///<summary>
	///Contabilizzazione contratto attivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomeinvoice 		=> Tables["incomeinvoice"];

	///<summary>
	///Tipo di documento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable invoicekind 		=> Tables["invoicekind"];

	///<summary>
	///Registro unico
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable uniqueregister 		=> Tables["uniqueregister"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public vistaFatture(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected vistaFatture (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "vistaFatture";
	Prefix = "";
	Namespace = "http://tempuri.org/vistaFatture.xsd";

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


	//////////////////// INVOICE /////////////////////////////////
	var tinvoice= new DataTable("invoice");
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	C= new DataColumn("yinv", typeof(short));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	C= new DataColumn("ninv", typeof(int));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	tinvoice.Columns.Add( new DataColumn("registryreference", typeof(string)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	tinvoice.Columns.Add( new DataColumn("paymentexpiring", typeof(short)));
	tinvoice.Columns.Add( new DataColumn("idexpirationkind", typeof(short)));
	tinvoice.Columns.Add( new DataColumn("idcurrency", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("exchangerate", typeof(double)));
	tinvoice.Columns.Add( new DataColumn("doc", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	tinvoice.Columns.Add( new DataColumn("packinglistnum", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("packinglistdate", typeof(DateTime)));
	tinvoice.Columns.Add( new DataColumn("flagdeferred", typeof(string)));
	C= new DataColumn("officiallyprinted", typeof(string));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	tinvoice.Columns.Add( new DataColumn("txt", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	tinvoice.Columns.Add( new DataColumn("active", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("flagintracom", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("iso_origin", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("iso_provenance", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("iso_destination", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("idcountry_origin", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("idcountry_destination", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("idintrastatkind", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("idaccmotivedebit", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("idaccmotivedebit_crg", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("idaccmotivedebit_datacrg", typeof(DateTime)));
	tinvoice.Columns.Add( new DataColumn("idintrastatpaymethod", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("iso_payment", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("flag_ddt", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("flag", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("idblacklist", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("idinvkind_real", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("yinv_real", typeof(short)));
	tinvoice.Columns.Add( new DataColumn("ninv_real", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("autoinvoice", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("protocoldate", typeof(DateTime)));
	tinvoice.Columns.Add( new DataColumn("idfepaymethodcondition", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("idfepaymethod", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("nelectronicinvoice", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("yelectronicinvoice", typeof(short)));
	tinvoice.Columns.Add( new DataColumn("arrivalprotocolnum", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("annotations", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("toincludeinpaymentindicator", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("resendingpcc", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("touniqueregister", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("idstampkind", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("flag_enable_split_payment", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("flag_auto_split_payment", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("idsdi_acquisto", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("idsdi_vendita", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("flag_reverse_charge", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("ipa_acq", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("rifamm_acq", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("ipa_ven_emittente", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("rifamm_ven_emittente", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("ipa_ven_cliente", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("rifamm_ven_cliente", typeof(string)));
	Tables.Add(tinvoice);
	tinvoice.PrimaryKey =  new DataColumn[]{tinvoice.Columns["ninv"], tinvoice.Columns["yinv"], tinvoice.Columns["idinvkind"]};


	//////////////////// INVOICEDETAIL /////////////////////////////////
	var tinvoicedetail= new DataTable("invoicedetail");
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	tinvoicedetail.Columns.Add(C);
	C= new DataColumn("yinv", typeof(short));
	C.AllowDBNull=false;
	tinvoicedetail.Columns.Add(C);
	C= new DataColumn("ninv", typeof(int));
	C.AllowDBNull=false;
	tinvoicedetail.Columns.Add(C);
	C= new DataColumn("rownum", typeof(int));
	C.AllowDBNull=false;
	tinvoicedetail.Columns.Add(C);
	C= new DataColumn("idivakind", typeof(int));
	C.AllowDBNull=false;
	tinvoicedetail.Columns.Add(C);
	tinvoicedetail.Columns.Add( new DataColumn("detaildescription", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("annotations", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("taxable", typeof(decimal)));
	tinvoicedetail.Columns.Add( new DataColumn("tax", typeof(decimal)));
	tinvoicedetail.Columns.Add( new DataColumn("unabatable", typeof(decimal)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinvoicedetail.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicedetail.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinvoicedetail.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicedetail.Columns.Add(C);
	tinvoicedetail.Columns.Add( new DataColumn("discount", typeof(double)));
	tinvoicedetail.Columns.Add( new DataColumn("idmankind", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("yman", typeof(short)));
	tinvoicedetail.Columns.Add( new DataColumn("nman", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("manrownum", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("number", typeof(decimal)));
	tinvoicedetail.Columns.Add( new DataColumn("idupb", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("idsor1", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idsor2", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idsor3", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("competencystart", typeof(DateTime)));
	tinvoicedetail.Columns.Add( new DataColumn("competencystop", typeof(DateTime)));
	tinvoicedetail.Columns.Add( new DataColumn("paymentcompetency", typeof(DateTime)));
	tinvoicedetail.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("idestimkind", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("yestim", typeof(short)));
	tinvoicedetail.Columns.Add( new DataColumn("nestim", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("estimrownum", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idexp_iva", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idexp_taxable", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idinc_iva", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idinc_taxable", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idgroup", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("yinv_main", typeof(short)));
	tinvoicedetail.Columns.Add( new DataColumn("ninv_main", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("va3type", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("idintrastatcode", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idintrastatmeasure", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("weight", typeof(decimal)));
	tinvoicedetail.Columns.Add( new DataColumn("intrastatoperationkind", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("idintrastatservice", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idunit", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idlist", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idpackage", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("npackage", typeof(decimal)));
	tinvoicedetail.Columns.Add( new DataColumn("unitsforpackage", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idintrastatsupplymethod", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("flag", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("exception12", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("intra12operationkind", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("move12", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("idupb_iva", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("idinvkind_main", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("leasing", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("usedmodesospesometro", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("resetresidualmandate", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("idfetransfer", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("fereferencerule", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("cupcode", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("cigcode", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("idcostpartition", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idpccdebitstatus", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("idpccdebitmotive", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("expensekind", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("rounding", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("idepexp", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idepacc", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("codicetipo", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("codicevalore", typeof(string)));
	Tables.Add(tinvoicedetail);
	tinvoicedetail.PrimaryKey =  new DataColumn[]{tinvoicedetail.Columns["ninv"], tinvoicedetail.Columns["rownum"], tinvoicedetail.Columns["yinv"], tinvoicedetail.Columns["idinvkind"]};


	//////////////////// EXPENSEINVOICE /////////////////////////////////
	var texpenseinvoice= new DataTable("expenseinvoice");
	C= new DataColumn("ninv", typeof(int));
	C.AllowDBNull=false;
	texpenseinvoice.Columns.Add(C);
	C= new DataColumn("yinv", typeof(short));
	C.AllowDBNull=false;
	texpenseinvoice.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpenseinvoice.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpenseinvoice.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpenseinvoice.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpenseinvoice.Columns.Add(C);
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpenseinvoice.Columns.Add(C);
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	texpenseinvoice.Columns.Add(C);
	C= new DataColumn("movkind", typeof(short));
	C.AllowDBNull=false;
	texpenseinvoice.Columns.Add(C);
	Tables.Add(texpenseinvoice);
	texpenseinvoice.PrimaryKey =  new DataColumn[]{texpenseinvoice.Columns["ninv"], texpenseinvoice.Columns["yinv"], texpenseinvoice.Columns["idexp"], texpenseinvoice.Columns["idinvkind"]};


	//////////////////// INCOMEINVOICE /////////////////////////////////
	var tincomeinvoice= new DataTable("incomeinvoice");
	C= new DataColumn("ninv", typeof(int));
	C.AllowDBNull=false;
	tincomeinvoice.Columns.Add(C);
	C= new DataColumn("yinv", typeof(short));
	C.AllowDBNull=false;
	tincomeinvoice.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tincomeinvoice.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tincomeinvoice.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tincomeinvoice.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tincomeinvoice.Columns.Add(C);
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tincomeinvoice.Columns.Add(C);
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	tincomeinvoice.Columns.Add(C);
	C= new DataColumn("movkind", typeof(short));
	C.AllowDBNull=false;
	tincomeinvoice.Columns.Add(C);
	Tables.Add(tincomeinvoice);
	tincomeinvoice.PrimaryKey =  new DataColumn[]{tincomeinvoice.Columns["ninv"], tincomeinvoice.Columns["yinv"], tincomeinvoice.Columns["idinc"], tincomeinvoice.Columns["idinvkind"]};


	//////////////////// INVOICEKIND /////////////////////////////////
	var tinvoicekind= new DataTable("invoicekind");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("codeinvkind", typeof(string));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	tinvoicekind.Columns.Add( new DataColumn("flag_autodocnumbering", typeof(string)));
	tinvoicekind.Columns.Add( new DataColumn("formatstring", typeof(string)));
	tinvoicekind.Columns.Add( new DataColumn("active", typeof(string)));
	tinvoicekind.Columns.Add( new DataColumn("idinvkind_auto", typeof(int)));
	tinvoicekind.Columns.Add( new DataColumn("printingcode", typeof(string)));
	tinvoicekind.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tinvoicekind.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tinvoicekind.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tinvoicekind.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tinvoicekind.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tinvoicekind.Columns.Add( new DataColumn("address", typeof(string)));
	tinvoicekind.Columns.Add( new DataColumn("header", typeof(string)));
	tinvoicekind.Columns.Add( new DataColumn("notes1", typeof(string)));
	tinvoicekind.Columns.Add( new DataColumn("notes2", typeof(string)));
	tinvoicekind.Columns.Add( new DataColumn("notes3", typeof(string)));
	tinvoicekind.Columns.Add( new DataColumn("enable_fe", typeof(string)));
	Tables.Add(tinvoicekind);
	tinvoicekind.PrimaryKey =  new DataColumn[]{tinvoicekind.Columns["idinvkind"]};


	//////////////////// UNIQUEREGISTER /////////////////////////////////
	var tuniqueregister= new DataTable("uniqueregister");
	C= new DataColumn("iduniqueregister", typeof(int));
	C.AllowDBNull=false;
	tuniqueregister.Columns.Add(C);
	C= new DataColumn("yinv", typeof(short));
	C.AllowDBNull=false;
	tuniqueregister.Columns.Add(C);
	C= new DataColumn("ninv", typeof(int));
	C.AllowDBNull=false;
	tuniqueregister.Columns.Add(C);
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	tuniqueregister.Columns.Add(C);
	tuniqueregister.Columns.Add( new DataColumn("ycon", typeof(int)));
	tuniqueregister.Columns.Add( new DataColumn("ncon", typeof(int)));
	tuniqueregister.Columns.Add( new DataColumn("yman", typeof(short)));
	tuniqueregister.Columns.Add( new DataColumn("nman", typeof(int)));
	tuniqueregister.Columns.Add( new DataColumn("idmankind", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tuniqueregister.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tuniqueregister.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tuniqueregister.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tuniqueregister.Columns.Add(C);
	Tables.Add(tuniqueregister);
	tuniqueregister.PrimaryKey =  new DataColumn[]{tuniqueregister.Columns["iduniqueregister"], tuniqueregister.Columns["yinv"], tuniqueregister.Columns["ninv"], tuniqueregister.Columns["idinvkind"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{invoice.Columns["ninv"], invoice.Columns["yinv"], invoice.Columns["idinvkind"]};
	var cChild = new []{uniqueregister.Columns["ninv"], uniqueregister.Columns["yinv"], uniqueregister.Columns["idinvkind"]};
	Relations.Add(new DataRelation("FK_invoice_uniqueregister",cPar,cChild,false));

	cPar = new []{invoice.Columns["ninv"], invoice.Columns["yinv"], invoice.Columns["idinvkind"]};
	cChild = new []{incomeinvoice.Columns["ninv"], incomeinvoice.Columns["yinv"], incomeinvoice.Columns["idinvkind"]};
	Relations.Add(new DataRelation("invoice_incomeinvoice",cPar,cChild,false));

	cPar = new []{invoice.Columns["ninv"], invoice.Columns["yinv"], invoice.Columns["idinvkind"]};
	cChild = new []{expenseinvoice.Columns["ninv"], expenseinvoice.Columns["yinv"], expenseinvoice.Columns["idinvkind"]};
	Relations.Add(new DataRelation("invoice_expenseinvoice",cPar,cChild,false));

	cPar = new []{invoicekind.Columns["idinvkind"]};
	cChild = new []{invoicedetail.Columns["idinvkind_main"]};
	Relations.Add(new DataRelation("invoicekind_invoicedetail",cPar,cChild,false));

	cPar = new []{invoice.Columns["ninv"], invoice.Columns["yinv"], invoice.Columns["idinvkind"]};
	cChild = new []{invoicedetail.Columns["ninv"], invoicedetail.Columns["yinv"], invoicedetail.Columns["idinvkind"]};
	Relations.Add(new DataRelation("invoice_invoicedetail",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{invoice.Columns["idreg"]};
	Relations.Add(new DataRelation("registry_invoice",cPar,cChild,false));

	cPar = new []{invoicekind.Columns["idinvkind"]};
	cChild = new []{invoice.Columns["idinvkind"]};
	Relations.Add(new DataRelation("FK_invoicekind_invoice",cPar,cChild,false));

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
