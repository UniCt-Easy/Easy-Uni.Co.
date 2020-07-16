/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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
namespace sdi_vendita_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("VistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class VistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Stato fattura in SDI
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sdi_status 		=> Tables["sdi_status"];

	///<summary>
	///Fatture di vendita selezionate per la trasmissione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sdi_vendita 		=> Tables["sdi_vendita"];

	///<summary>
	///Stato trasmissione SDI
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sdi_deliverystatus 		=> Tables["sdi_deliverystatus"];

	///<summary>
	///Fattura
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable invoice 		=> Tables["invoice"];

	///<summary>
	///Codice IPA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable ipa 		=> Tables["ipa"];

	///<summary>
	///Riferimento amministrazione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sdi_rifamm 		=> Tables["sdi_rifamm"];

	///<summary>
	///Tipo di documento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable invoicekind 		=> Tables["invoicekind"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public VistaForm(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected VistaForm (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "VistaForm";
	Prefix = "";
	Namespace = "http://tempuri.org/VistaForm.xsd";

	#region create DataTables
	DataColumn C;
	//////////////////// SDI_STATUS /////////////////////////////////
	var tsdi_status= new DataTable("sdi_status");
	C= new DataColumn("idsdi_status", typeof(short));
	C.AllowDBNull=false;
	tsdi_status.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsdi_status.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsdi_status.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsdi_status.Columns.Add(C);
	tsdi_status.Columns.Add( new DataColumn("listingorder", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsdi_status.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsdi_status.Columns.Add(C);
	Tables.Add(tsdi_status);
	tsdi_status.PrimaryKey =  new DataColumn[]{tsdi_status.Columns["idsdi_status"]};


	//////////////////// SDI_VENDITA /////////////////////////////////
	var tsdi_vendita= new DataTable("sdi_vendita");
	C= new DataColumn("idsdi_vendita", typeof(int));
	C.AllowDBNull=false;
	tsdi_vendita.Columns.Add(C);
	C= new DataColumn("filename", typeof(string));
	C.AllowDBNull=false;
	tsdi_vendita.Columns.Add(C);
	tsdi_vendita.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	C= new DataColumn("xml", typeof(string));
	C.AllowDBNull=false;
	tsdi_vendita.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsdi_vendita.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsdi_vendita.Columns.Add(C);
	tsdi_vendita.Columns.Add( new DataColumn("identificativo_sdi", typeof(long)));
	tsdi_vendita.Columns.Add( new DataColumn("ns", typeof(string)));
	tsdi_vendita.Columns.Add( new DataColumn("mc", typeof(string)));
	tsdi_vendita.Columns.Add( new DataColumn("rc", typeof(string)));
	tsdi_vendita.Columns.Add( new DataColumn("ne", typeof(string)));
	tsdi_vendita.Columns.Add( new DataColumn("dt", typeof(string)));
	tsdi_vendita.Columns.Add( new DataColumn("at", typeof(string)));
	tsdi_vendita.Columns.Add( new DataColumn("flag_unseen", typeof(int)));
	tsdi_vendita.Columns.Add( new DataColumn("idsdi_status", typeof(short)));
	tsdi_vendita.Columns.Add( new DataColumn("idsdi_deliverystatus", typeof(short)));
	tsdi_vendita.Columns.Add( new DataColumn("position", typeof(int)));
	C= new DataColumn("exported", typeof(string));
	C.AllowDBNull=false;
	tsdi_vendita.Columns.Add(C);
	tsdi_vendita.Columns.Add( new DataColumn("zipfilename", typeof(string)));
	tsdi_vendita.Columns.Add( new DataColumn("ns_prot", typeof(string)));
	tsdi_vendita.Columns.Add( new DataColumn("mc_prot", typeof(string)));
	tsdi_vendita.Columns.Add( new DataColumn("rc_prot", typeof(string)));
	tsdi_vendita.Columns.Add( new DataColumn("ne_prot", typeof(string)));
	tsdi_vendita.Columns.Add( new DataColumn("dt_prot", typeof(string)));
	tsdi_vendita.Columns.Add( new DataColumn("at_prot", typeof(string)));
	tsdi_vendita.Columns.Add( new DataColumn("arrivalprotocolnum", typeof(string)));
	tsdi_vendita.Columns.Add( new DataColumn("ipa_fe", typeof(string)));
	tsdi_vendita.Columns.Add( new DataColumn("idsdi_rifamm", typeof(string)));
	tsdi_vendita.Columns.Add( new DataColumn("signedxml", typeof(string)));
	tsdi_vendita.Columns.Add( new DataColumn("signedxmlfilename", typeof(string)));
	tsdi_vendita.Columns.Add( new DataColumn("issigned", typeof(string)));
	Tables.Add(tsdi_vendita);
	tsdi_vendita.PrimaryKey =  new DataColumn[]{tsdi_vendita.Columns["idsdi_vendita"]};


	//////////////////// SDI_DELIVERYSTATUS /////////////////////////////////
	var tsdi_deliverystatus= new DataTable("sdi_deliverystatus");
	C= new DataColumn("idsdi_deliverystatus", typeof(short));
	C.AllowDBNull=false;
	tsdi_deliverystatus.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsdi_deliverystatus.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsdi_deliverystatus.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsdi_deliverystatus.Columns.Add(C);
	tsdi_deliverystatus.Columns.Add( new DataColumn("listingorder", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsdi_deliverystatus.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsdi_deliverystatus.Columns.Add(C);
	Tables.Add(tsdi_deliverystatus);
	tsdi_deliverystatus.PrimaryKey =  new DataColumn[]{tsdi_deliverystatus.Columns["idsdi_deliverystatus"]};


	//////////////////// INVOICE /////////////////////////////////
	var tinvoice= new DataTable("invoice");
	C= new DataColumn("ninv", typeof(int));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	C= new DataColumn("yinv", typeof(short));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	tinvoice.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	tinvoice.Columns.Add( new DataColumn("doc", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	tinvoice.Columns.Add( new DataColumn("exchangerate", typeof(double)));
	tinvoice.Columns.Add( new DataColumn("flagdeferred", typeof(string)));
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	C= new DataColumn("officiallyprinted", typeof(string));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	tinvoice.Columns.Add( new DataColumn("packinglistdate", typeof(DateTime)));
	tinvoice.Columns.Add( new DataColumn("packinglistnum", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("paymentexpiring", typeof(short)));
	tinvoice.Columns.Add( new DataColumn("registryreference", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tinvoice.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	tinvoice.Columns.Add( new DataColumn("idcurrency", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("idexpirationkind", typeof(short)));
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
	tinvoice.Columns.Add( new DataColumn("annotations", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("arrivalprotocolnum", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("toincludeinpaymentindicator", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("resendingpcc", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("touniqueregister", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("idstampkind", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("flag_auto_split_payment", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("flag_enable_split_payment", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("idsdi_acquisto", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("idsdi_vendita", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("flag_reverse_charge", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("ipa_acq", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("rifamm_acq", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("ipa_ven_emittente", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("rifamm_ven_emittente", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("ipa_ven_cliente", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("rifamm_ven_cliente", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("flagbit", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("ssntipospesa", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("email_ven_cliente", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("pec_ven_cliente", typeof(string)));
	Tables.Add(tinvoice);
	tinvoice.PrimaryKey =  new DataColumn[]{tinvoice.Columns["ninv"], tinvoice.Columns["yinv"], tinvoice.Columns["idinvkind"]};


	//////////////////// IPA /////////////////////////////////
	var tipa= new DataTable("ipa");
	C= new DataColumn("ipa_fe", typeof(string));
	C.AllowDBNull=false;
	tipa.Columns.Add(C);
	C= new DataColumn("agencyname", typeof(string));
	C.AllowDBNull=false;
	tipa.Columns.Add(C);
	C= new DataColumn("officename", typeof(string));
	C.AllowDBNull=false;
	tipa.Columns.Add(C);
	tipa.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tipa.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tipa.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tipa.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tipa.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tipa.Columns.Add( new DataColumn("cu", typeof(string)));
	tipa.Columns.Add( new DataColumn("lu", typeof(string)));
	tipa.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tipa.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tipa.Columns.Add( new DataColumn("codiceufficio", typeof(string)));
	tipa.Columns.Add( new DataColumn("voceindice", typeof(string)));
	tipa.Columns.Add( new DataColumn("diritto", typeof(string)));
	tipa.Columns.Add( new DataColumn("nomeufficio", typeof(string)));
	tipa.Columns.Add( new DataColumn("nomepersona", typeof(string)));
	tipa.Columns.Add( new DataColumn("cod_amm_aoo", typeof(string)));
	Tables.Add(tipa);
	tipa.PrimaryKey =  new DataColumn[]{tipa.Columns["ipa_fe"]};


	//////////////////// SDI_RIFAMM /////////////////////////////////
	var tsdi_rifamm= new DataTable("sdi_rifamm");
	C= new DataColumn("idsdi_rifamm", typeof(string));
	C.AllowDBNull=false;
	tsdi_rifamm.Columns.Add(C);
	tsdi_rifamm.Columns.Add( new DataColumn("codiceufficio", typeof(string)));
	tsdi_rifamm.Columns.Add( new DataColumn("voceindice", typeof(string)));
	tsdi_rifamm.Columns.Add( new DataColumn("diritto", typeof(string)));
	tsdi_rifamm.Columns.Add( new DataColumn("nomeufficio", typeof(string)));
	tsdi_rifamm.Columns.Add( new DataColumn("nomepersona", typeof(string)));
	tsdi_rifamm.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tsdi_rifamm.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tsdi_rifamm.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tsdi_rifamm.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tsdi_rifamm.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tsdi_rifamm.Columns.Add( new DataColumn("nomeufficioricevente", typeof(string)));
	tsdi_rifamm.Columns.Add( new DataColumn("cod_amm_aoo", typeof(string)));
	Tables.Add(tsdi_rifamm);
	tsdi_rifamm.PrimaryKey =  new DataColumn[]{tsdi_rifamm.Columns["idsdi_rifamm"]};


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
	tinvoicekind.Columns.Add( new DataColumn("ipa_fe", typeof(string)));
	Tables.Add(tinvoicekind);
	tinvoicekind.PrimaryKey =  new DataColumn[]{tinvoicekind.Columns["idinvkind"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{sdi_vendita.Columns["idsdi_vendita"]};
	var cChild = new []{invoice.Columns["idsdi_vendita"]};
	Relations.Add(new DataRelation("FK_sdi_vendita_invoice",cPar,cChild,false));

	cPar = new []{invoicekind.Columns["idinvkind"]};
	cChild = new []{invoice.Columns["idinvkind"]};
	Relations.Add(new DataRelation("invoicekind_invoice",cPar,cChild,false));

	cPar = new []{sdi_rifamm.Columns["idsdi_rifamm"]};
	cChild = new []{sdi_vendita.Columns["idsdi_rifamm"]};
	Relations.Add(new DataRelation("FK_sdi_rifamm_sdi_vendita",cPar,cChild,false));

	cPar = new []{ipa.Columns["ipa_fe"]};
	cChild = new []{sdi_vendita.Columns["ipa_fe"]};
	Relations.Add(new DataRelation("FK_ipa_sdi_vendita",cPar,cChild,false));

	cPar = new []{sdi_deliverystatus.Columns["idsdi_deliverystatus"]};
	cChild = new []{sdi_vendita.Columns["idsdi_deliverystatus"]};
	Relations.Add(new DataRelation("FK_sdi_deliverystatus_sdi_vendita",cPar,cChild,false));

	cPar = new []{sdi_status.Columns["idsdi_status"]};
	cChild = new []{sdi_vendita.Columns["idsdi_status"]};
	Relations.Add(new DataRelation("FK_sdi_status_sdi_vendita",cPar,cChild,false));

	#endregion

}
}
}
