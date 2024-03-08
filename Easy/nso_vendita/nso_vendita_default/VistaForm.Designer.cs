
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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
namespace nso_vendita_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("VistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class VistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable uniconfig 		=> Tables["uniconfig"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable nso_status 		=> Tables["nso_status"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable nso_vendita 		=> Tables["nso_vendita"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable ipa 		=> Tables["ipa"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable estimatekind 		=> Tables["estimatekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable estimate 		=> Tables["estimate"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable estimatedetail 		=> Tables["estimatedetail"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable nso_deliverystatus 		=> Tables["nso_deliverystatus"];

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
	//////////////////// UNICONFIG /////////////////////////////////
	var tuniconfig= new DataTable("uniconfig");
	C= new DataColumn("dummykey", typeof(int));
	C.AllowDBNull=false;
	tuniconfig.Columns.Add(C);
	tuniconfig.Columns.Add( new DataColumn("expensefinphase", typeof(byte)));
	tuniconfig.Columns.Add( new DataColumn("incomefinphase", typeof(byte)));
	tuniconfig.Columns.Add( new DataColumn("expenseregphase", typeof(byte)));
	tuniconfig.Columns.Add( new DataColumn("incomeregphase", typeof(byte)));
	C= new DataColumn("flagresearchagency", typeof(string));
	C.AllowDBNull=false;
	tuniconfig.Columns.Add(C);
	tuniconfig.Columns.Add( new DataColumn("idsorkind01", typeof(int)));
	tuniconfig.Columns.Add( new DataColumn("idsorkind02", typeof(int)));
	tuniconfig.Columns.Add( new DataColumn("idsorkind03", typeof(int)));
	tuniconfig.Columns.Add( new DataColumn("idsorkind04", typeof(int)));
	tuniconfig.Columns.Add( new DataColumn("idsorkind05", typeof(int)));
	tuniconfig.Columns.Add( new DataColumn("sorkind01asfilter", typeof(string)));
	tuniconfig.Columns.Add( new DataColumn("sorkind02asfilter", typeof(string)));
	tuniconfig.Columns.Add( new DataColumn("sorkind03asfilter", typeof(string)));
	tuniconfig.Columns.Add( new DataColumn("sorkind04asfilter", typeof(string)));
	tuniconfig.Columns.Add( new DataColumn("sorkind05asfilter", typeof(string)));
	tuniconfig.Columns.Add( new DataColumn("tree_upb_withdescr", typeof(string)));
	tuniconfig.Columns.Add( new DataColumn("flag", typeof(int)));
	tuniconfig.Columns.Add( new DataColumn("ep360days", typeof(string)));
	tuniconfig.Columns.Add( new DataColumn("idente", typeof(int)));
	tuniconfig.Columns.Add( new DataColumn("publicagency", typeof(string)));
	tuniconfig.Columns.Add( new DataColumn("ssn_codasl", typeof(string)));
	tuniconfig.Columns.Add( new DataColumn("ssn_codregione", typeof(string)));
	tuniconfig.Columns.Add( new DataColumn("ssn_codssa", typeof(string)));
	tuniconfig.Columns.Add( new DataColumn("rea_provinceoffice", typeof(string)));
	tuniconfig.Columns.Add( new DataColumn("rea_number", typeof(string)));
	tuniconfig.Columns.Add( new DataColumn("rea_socialcapital", typeof(decimal)));
	tuniconfig.Columns.Add( new DataColumn("rea_partner", typeof(string)));
	tuniconfig.Columns.Add( new DataColumn("rea_closingstatus", typeof(string)));
	tuniconfig.Columns.Add( new DataColumn("perla_codicepaipa", typeof(string)));
	tuniconfig.Columns.Add( new DataColumn("perla_codiceaoopa", typeof(string)));
	tuniconfig.Columns.Add( new DataColumn("perla_codiceuopa", typeof(string)));
	tuniconfig.Columns.Add( new DataColumn("perla_codicefiscalepa", typeof(string)));
	tuniconfig.Columns.Add( new DataColumn("webprotaddress", typeof(string)));
	Tables.Add(tuniconfig);
	tuniconfig.PrimaryKey =  new DataColumn[]{tuniconfig.Columns["dummykey"]};


	//////////////////// NSO_STATUS /////////////////////////////////
	var tnso_status= new DataTable("nso_status");
	C= new DataColumn("idnso_status", typeof(short));
	C.AllowDBNull=false;
	tnso_status.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tnso_status.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tnso_status.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tnso_status.Columns.Add(C);
	tnso_status.Columns.Add( new DataColumn("listingorder", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tnso_status.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tnso_status.Columns.Add(C);
	Tables.Add(tnso_status);
	tnso_status.PrimaryKey =  new DataColumn[]{tnso_status.Columns["idnso_status"]};


	//////////////////// NSO_VENDITA /////////////////////////////////
	var tnso_vendita= new DataTable("nso_vendita");
	C= new DataColumn("idnso_vendita", typeof(int));
	C.AllowDBNull=false;
	tnso_vendita.Columns.Add(C);
	C= new DataColumn("filename", typeof(string));
	C.AllowDBNull=false;
	tnso_vendita.Columns.Add(C);
	C= new DataColumn("zipfilename", typeof(string));
	C.AllowDBNull=false;
	tnso_vendita.Columns.Add(C);
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tnso_vendita.Columns.Add(C);
	C= new DataColumn("xml", typeof(string));
	C.AllowDBNull=false;
	tnso_vendita.Columns.Add(C);
	tnso_vendita.Columns.Add( new DataColumn("identificativo_nso", typeof(long)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tnso_vendita.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tnso_vendita.Columns.Add(C);
	tnso_vendita.Columns.Add( new DataColumn("dt", typeof(string)));
	tnso_vendita.Columns.Add( new DataColumn("dt_prot", typeof(string)));
	tnso_vendita.Columns.Add( new DataColumn("ec", typeof(string)));
	tnso_vendita.Columns.Add( new DataColumn("ec_prot", typeof(string)));
	tnso_vendita.Columns.Add( new DataColumn("mt", typeof(string)));
	tnso_vendita.Columns.Add( new DataColumn("mt_prot", typeof(string)));
	tnso_vendita.Columns.Add( new DataColumn("se", typeof(string)));
	tnso_vendita.Columns.Add( new DataColumn("se_prot", typeof(string)));
	tnso_vendita.Columns.Add( new DataColumn("ec_sent", typeof(string)));
	tnso_vendita.Columns.Add( new DataColumn("ec_number", typeof(int)));
	C= new DataColumn("position", typeof(int));
	C.AllowDBNull=false;
	tnso_vendita.Columns.Add(C);
	C= new DataColumn("idnso_status", typeof(short));
	C.AllowDBNull=false;
	tnso_vendita.Columns.Add(C);
	tnso_vendita.Columns.Add( new DataColumn("flag_unseen", typeof(int)));
	tnso_vendita.Columns.Add( new DataColumn("codice_ipa", typeof(string)));
	tnso_vendita.Columns.Add( new DataColumn("protocoldate", typeof(DateTime)));
	tnso_vendita.Columns.Add( new DataColumn("arrivalprotocolnum", typeof(string)));
	tnso_vendita.Columns.Add( new DataColumn("rejectreason", typeof(string)));
	tnso_vendita.Columns.Add( new DataColumn("riferimento_amministrazione", typeof(string)));
	tnso_vendita.Columns.Add( new DataColumn("description", typeof(string)));
	tnso_vendita.Columns.Add( new DataColumn("data_ricezione", typeof(DateTime)));
	tnso_vendita.Columns.Add( new DataColumn("tipo_risposta", typeof(string)));
	tnso_vendita.Columns.Add( new DataColumn("data_risposta", typeof(DateTime)));
	tnso_vendita.Columns.Add( new DataColumn("tipo_riscontro", typeof(string)));
	tnso_vendita.Columns.Add( new DataColumn("data_riscontro", typeof(DateTime)));
	tnso_vendita.Columns.Add( new DataColumn("protocol_error", typeof(string)));
	tnso_vendita.Columns.Add( new DataColumn("tipodocumento", typeof(string)));
	tnso_vendita.Columns.Add( new DataColumn("signedxml", typeof(string)));
	tnso_vendita.Columns.Add( new DataColumn("signedxmlfilename", typeof(string)));
	tnso_vendita.Columns.Add( new DataColumn("utente_accettata", typeof(string)));
	tnso_vendita.Columns.Add( new DataColumn("utente_rifiutata", typeof(string)));
	tnso_vendita.Columns.Add( new DataColumn("data_accettata", typeof(DateTime)));
	tnso_vendita.Columns.Add( new DataColumn("data_rifiutata", typeof(DateTime)));
	C= new DataColumn("order_id", typeof(string));
	C.AllowDBNull=false;
	tnso_vendita.Columns.Add(C);
	tnso_vendita.Columns.Add( new DataColumn("order_idemittente", typeof(string)));
	tnso_vendita.Columns.Add( new DataColumn("order_data_scadenza", typeof(DateTime)));
	C= new DataColumn("order_tipo", typeof(int));
	C.AllowDBNull=false;
	tnso_vendita.Columns.Add(C);
	tnso_vendita.Columns.Add( new DataColumn("contratto_id", typeof(string)));
	tnso_vendita.Columns.Add( new DataColumn("codice_identificativo_gara", typeof(string)));
	tnso_vendita.Columns.Add( new DataColumn("total", typeof(decimal)));
	tnso_vendita.Columns.Add( new DataColumn("tax_total", typeof(decimal)));
	tnso_vendita.Columns.Add( new DataColumn("buyer_id", typeof(string)));
	tnso_vendita.Columns.Add( new DataColumn("buyer_name", typeof(string)));
	tnso_vendita.Columns.Add( new DataColumn("buyer_taxid", typeof(string)));
	tnso_vendita.Columns.Add( new DataColumn("email_nso", typeof(string)));
	tnso_vendita.Columns.Add( new DataColumn("idnso_deliverystatus", typeof(short)));
	Tables.Add(tnso_vendita);
	tnso_vendita.PrimaryKey =  new DataColumn[]{tnso_vendita.Columns["idnso_vendita"]};


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
	tipa.Columns.Add( new DataColumn("ws_user", typeof(string)));
	tipa.Columns.Add( new DataColumn("cf_operatore", typeof(string)));
	tipa.Columns.Add( new DataColumn("email_alert", typeof(string)));
	tipa.Columns.Add( new DataColumn("useforopi", typeof(string)));
	Tables.Add(tipa);
	tipa.PrimaryKey =  new DataColumn[]{tipa.Columns["ipa_fe"]};


	//////////////////// ESTIMATEKIND /////////////////////////////////
	var testimatekind= new DataTable("estimatekind");
	C= new DataColumn("idestimkind", typeof(string));
	C.AllowDBNull=false;
	testimatekind.Columns.Add(C);
	testimatekind.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	testimatekind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	testimatekind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	testimatekind.Columns.Add(C);
	testimatekind.Columns.Add( new DataColumn("idupb", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	testimatekind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	testimatekind.Columns.Add(C);
	testimatekind.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	testimatekind.Columns.Add( new DataColumn("txt", typeof(string)));
	testimatekind.Columns.Add( new DataColumn("email", typeof(string)));
	testimatekind.Columns.Add( new DataColumn("faxnumber", typeof(string)));
	testimatekind.Columns.Add( new DataColumn("office", typeof(string)));
	testimatekind.Columns.Add( new DataColumn("phonenumber", typeof(string)));
	testimatekind.Columns.Add( new DataColumn("linktoinvoice", typeof(string)));
	testimatekind.Columns.Add( new DataColumn("multireg", typeof(string)));
	testimatekind.Columns.Add( new DataColumn("deltaamount", typeof(decimal)));
	testimatekind.Columns.Add( new DataColumn("deltapercentage", typeof(decimal)));
	testimatekind.Columns.Add( new DataColumn("flag_autodocnumbering", typeof(string)));
	testimatekind.Columns.Add( new DataColumn("idsor01", typeof(int)));
	testimatekind.Columns.Add( new DataColumn("idsor02", typeof(int)));
	testimatekind.Columns.Add( new DataColumn("idsor03", typeof(int)));
	testimatekind.Columns.Add( new DataColumn("idsor04", typeof(int)));
	testimatekind.Columns.Add( new DataColumn("idsor05", typeof(int)));
	testimatekind.Columns.Add( new DataColumn("address", typeof(string)));
	testimatekind.Columns.Add( new DataColumn("header", typeof(string)));
	testimatekind.Columns.Add( new DataColumn("idivakind_forced", typeof(int)));
	testimatekind.Columns.Add( new DataColumn("flag", typeof(int)));
	testimatekind.Columns.Add( new DataColumn("riferimento_amministrazione", typeof(string)));
	Tables.Add(testimatekind);
	testimatekind.PrimaryKey =  new DataColumn[]{testimatekind.Columns["idestimkind"]};


	//////////////////// ESTIMATE /////////////////////////////////
	var testimate= new DataTable("estimate");
	C= new DataColumn("idestimkind", typeof(string));
	C.AllowDBNull=false;
	testimate.Columns.Add(C);
	C= new DataColumn("yestim", typeof(short));
	C.AllowDBNull=false;
	testimate.Columns.Add(C);
	C= new DataColumn("nestim", typeof(int));
	C.AllowDBNull=false;
	testimate.Columns.Add(C);
	testimate.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	testimate.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	testimate.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	testimate.Columns.Add(C);
	testimate.Columns.Add( new DataColumn("deliveryaddress", typeof(string)));
	testimate.Columns.Add( new DataColumn("deliveryexpiration", typeof(string)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	testimate.Columns.Add(C);
	testimate.Columns.Add( new DataColumn("doc", typeof(string)));
	testimate.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	testimate.Columns.Add( new DataColumn("exchangerate", typeof(double)));
	testimate.Columns.Add( new DataColumn("idreg", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	testimate.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	testimate.Columns.Add(C);
	C= new DataColumn("officiallyprinted", typeof(string));
	C.AllowDBNull=false;
	testimate.Columns.Add(C);
	testimate.Columns.Add( new DataColumn("paymentexpiring", typeof(short)));
	testimate.Columns.Add( new DataColumn("registryreference", typeof(string)));
	testimate.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	testimate.Columns.Add( new DataColumn("txt", typeof(string)));
	testimate.Columns.Add( new DataColumn("idman", typeof(int)));
	testimate.Columns.Add( new DataColumn("idcurrency", typeof(int)));
	testimate.Columns.Add( new DataColumn("idexpirationkind", typeof(short)));
	testimate.Columns.Add( new DataColumn("flagintracom", typeof(string)));
	testimate.Columns.Add( new DataColumn("idaccmotivecredit", typeof(string)));
	testimate.Columns.Add( new DataColumn("idaccmotivecredit_crg", typeof(string)));
	testimate.Columns.Add( new DataColumn("idaccmotivecredit_datacrg", typeof(DateTime)));
	testimate.Columns.Add( new DataColumn("idsor_underwriter", typeof(int)));
	testimate.Columns.Add( new DataColumn("idunderwriting", typeof(int)));
	testimate.Columns.Add( new DataColumn("idsor01", typeof(int)));
	testimate.Columns.Add( new DataColumn("idsor02", typeof(int)));
	testimate.Columns.Add( new DataColumn("idsor03", typeof(int)));
	testimate.Columns.Add( new DataColumn("idsor04", typeof(int)));
	testimate.Columns.Add( new DataColumn("idsor05", typeof(int)));
	testimate.Columns.Add( new DataColumn("external_reference", typeof(string)));
	testimate.Columns.Add( new DataColumn("cigcode", typeof(string)));
	testimate.Columns.Add( new DataColumn("idnso_vendita", typeof(int)));
	testimate.Columns.Add( new DataColumn("idnocigmotive", typeof(int)));
	Tables.Add(testimate);
	testimate.PrimaryKey =  new DataColumn[]{testimate.Columns["idestimkind"], testimate.Columns["yestim"], testimate.Columns["nestim"]};


	//////////////////// ESTIMATEDETAIL /////////////////////////////////
	var testimatedetail= new DataTable("estimatedetail");
	C= new DataColumn("idestimkind", typeof(string));
	C.AllowDBNull=false;
	testimatedetail.Columns.Add(C);
	C= new DataColumn("yestim", typeof(short));
	C.AllowDBNull=false;
	testimatedetail.Columns.Add(C);
	C= new DataColumn("nestim", typeof(int));
	C.AllowDBNull=false;
	testimatedetail.Columns.Add(C);
	C= new DataColumn("rownum", typeof(int));
	C.AllowDBNull=false;
	testimatedetail.Columns.Add(C);
	testimatedetail.Columns.Add( new DataColumn("annotations", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	testimatedetail.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	testimatedetail.Columns.Add(C);
	testimatedetail.Columns.Add( new DataColumn("detaildescription", typeof(string)));
	testimatedetail.Columns.Add( new DataColumn("discount", typeof(double)));
	testimatedetail.Columns.Add( new DataColumn("idupb", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	testimatedetail.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	testimatedetail.Columns.Add(C);
	testimatedetail.Columns.Add( new DataColumn("ninvoiced", typeof(decimal)));
	testimatedetail.Columns.Add( new DataColumn("number", typeof(decimal)));
	testimatedetail.Columns.Add( new DataColumn("start", typeof(DateTime)));
	testimatedetail.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	testimatedetail.Columns.Add( new DataColumn("tax", typeof(decimal)));
	testimatedetail.Columns.Add( new DataColumn("taxable", typeof(decimal)));
	testimatedetail.Columns.Add( new DataColumn("taxrate", typeof(double)));
	testimatedetail.Columns.Add( new DataColumn("toinvoice", typeof(string)));
	testimatedetail.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	testimatedetail.Columns.Add( new DataColumn("idreg", typeof(int)));
	testimatedetail.Columns.Add( new DataColumn("idgroup", typeof(int)));
	testimatedetail.Columns.Add( new DataColumn("competencystart", typeof(DateTime)));
	testimatedetail.Columns.Add( new DataColumn("competencystop", typeof(DateTime)));
	testimatedetail.Columns.Add( new DataColumn("idinc_taxable", typeof(int)));
	testimatedetail.Columns.Add( new DataColumn("idinc_iva", typeof(int)));
	testimatedetail.Columns.Add( new DataColumn("idivakind", typeof(int)));
	testimatedetail.Columns.Add( new DataColumn("idsor1", typeof(int)));
	testimatedetail.Columns.Add( new DataColumn("idsor2", typeof(int)));
	testimatedetail.Columns.Add( new DataColumn("idsor3", typeof(int)));
	testimatedetail.Columns.Add( new DataColumn("idaccmotiveannulment", typeof(string)));
	testimatedetail.Columns.Add( new DataColumn("epkind", typeof(string)));
	testimatedetail.Columns.Add( new DataColumn("idrevenuepartition", typeof(int)));
	testimatedetail.Columns.Add( new DataColumn("idepacc", typeof(int)));
	testimatedetail.Columns.Add( new DataColumn("idupb_iva", typeof(string)));
	testimatedetail.Columns.Add( new DataColumn("idlist", typeof(int)));
	testimatedetail.Columns.Add( new DataColumn("cigcode", typeof(string)));
	testimatedetail.Columns.Add( new DataColumn("idfinmotive", typeof(string)));
	testimatedetail.Columns.Add( new DataColumn("iduniqueformcode", typeof(string)));
	testimatedetail.Columns.Add( new DataColumn("flag", typeof(int)));
	testimatedetail.Columns.Add( new DataColumn("proceedsexpiring", typeof(DateTime)));
	testimatedetail.Columns.Add( new DataColumn("nform", typeof(string)));
	testimatedetail.Columns.Add( new DataColumn("idsor_siope", typeof(int)));
	testimatedetail.Columns.Add( new DataColumn("idepacc_pre", typeof(int)));
	testimatedetail.Columns.Add( new DataColumn("rownum_main", typeof(int)));
	testimatedetail.Columns.Add( new DataColumn("idtassonomia", typeof(int)));
	Tables.Add(testimatedetail);
	testimatedetail.PrimaryKey =  new DataColumn[]{testimatedetail.Columns["idestimkind"], testimatedetail.Columns["yestim"], testimatedetail.Columns["nestim"], testimatedetail.Columns["rownum"]};


	//////////////////// NSO_DELIVERYSTATUS /////////////////////////////////
	var tnso_deliverystatus= new DataTable("nso_deliverystatus");
	C= new DataColumn("idnso_deliverystatus", typeof(short));
	C.AllowDBNull=false;
	tnso_deliverystatus.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tnso_deliverystatus.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tnso_deliverystatus.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tnso_deliverystatus.Columns.Add(C);
	tnso_deliverystatus.Columns.Add( new DataColumn("listingorder", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tnso_deliverystatus.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tnso_deliverystatus.Columns.Add(C);
	Tables.Add(tnso_deliverystatus);
	tnso_deliverystatus.PrimaryKey =  new DataColumn[]{tnso_deliverystatus.Columns["idnso_deliverystatus"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{nso_status.Columns["idnso_status"]};
	var cChild = new []{nso_vendita.Columns["idnso_status"]};
	Relations.Add(new DataRelation("nso_status_nso_vendita",cPar,cChild,false));

	cPar = new []{ipa.Columns["ipa_fe"]};
	cChild = new []{nso_vendita.Columns["codice_ipa"]};
	Relations.Add(new DataRelation("FK_ipa_nso_vendita",cPar,cChild,false));

	cPar = new []{estimatedetail.Columns["idestimkind"], estimatedetail.Columns["yestim"], estimatedetail.Columns["nestim"]};
	cChild = new []{estimate.Columns["idestimkind"], estimate.Columns["yestim"], estimate.Columns["nestim"]};
	Relations.Add(new DataRelation("estimatedetail_estimate",cPar,cChild,false));

	cPar = new []{estimatekind.Columns["idestimkind"]};
	cChild = new []{estimate.Columns["idestimkind"]};
	Relations.Add(new DataRelation("estimatekind_estimate",cPar,cChild,false));

	cPar = new []{nso_deliverystatus.Columns["idnso_deliverystatus"]};
	cChild = new []{nso_vendita.Columns["idnso_deliverystatus"]};
	Relations.Add(new DataRelation("nso_deliverystatus_nso_vendita",cPar,cChild,false));

	#endregion

}
}
}
