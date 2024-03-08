
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
namespace expenselastmandatedetail_detail {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable mandatedetail 		=> Tables["mandatedetail"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable mandatekind 		=> Tables["mandatekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable mandate 		=> Tables["mandate"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expenselastmandatedetail 		=> Tables["expenselastmandatedetail"];

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
	//////////////////// MANDATEDETAIL /////////////////////////////////
	var tmandatedetail= new DataTable("mandatedetail");
	C= new DataColumn("idmankind", typeof(string));
	C.AllowDBNull=false;
	tmandatedetail.Columns.Add(C);
	C= new DataColumn("nman", typeof(int));
	C.AllowDBNull=false;
	tmandatedetail.Columns.Add(C);
	C= new DataColumn("rownum", typeof(int));
	C.AllowDBNull=false;
	tmandatedetail.Columns.Add(C);
	C= new DataColumn("yman", typeof(short));
	C.AllowDBNull=false;
	tmandatedetail.Columns.Add(C);
	tmandatedetail.Columns.Add( new DataColumn("annotations", typeof(string)));
	C= new DataColumn("assetkind", typeof(string));
	C.AllowDBNull=false;
	tmandatedetail.Columns.Add(C);
	tmandatedetail.Columns.Add( new DataColumn("competencystart", typeof(DateTime)));
	tmandatedetail.Columns.Add( new DataColumn("competencystop", typeof(DateTime)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tmandatedetail.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tmandatedetail.Columns.Add(C);
	tmandatedetail.Columns.Add( new DataColumn("detaildescription", typeof(string)));
	tmandatedetail.Columns.Add( new DataColumn("discount", typeof(double)));
	tmandatedetail.Columns.Add( new DataColumn("idupb", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tmandatedetail.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tmandatedetail.Columns.Add(C);
	tmandatedetail.Columns.Add( new DataColumn("ninvoiced", typeof(decimal)));
	tmandatedetail.Columns.Add( new DataColumn("number", typeof(decimal)));
	tmandatedetail.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tmandatedetail.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tmandatedetail.Columns.Add( new DataColumn("tax", typeof(decimal)));
	tmandatedetail.Columns.Add( new DataColumn("taxable", typeof(decimal)));
	tmandatedetail.Columns.Add( new DataColumn("taxrate", typeof(double)));
	tmandatedetail.Columns.Add( new DataColumn("toinvoice", typeof(string)));
	tmandatedetail.Columns.Add( new DataColumn("flagmixed", typeof(string)));
	tmandatedetail.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	tmandatedetail.Columns.Add( new DataColumn("unabatable", typeof(decimal)));
	tmandatedetail.Columns.Add( new DataColumn("idgroup", typeof(int)));
	tmandatedetail.Columns.Add( new DataColumn("idreg", typeof(int)));
	tmandatedetail.Columns.Add( new DataColumn("idexp_taxable", typeof(int)));
	tmandatedetail.Columns.Add( new DataColumn("idexp_iva", typeof(int)));
	tmandatedetail.Columns.Add( new DataColumn("idinv", typeof(int)));
	tmandatedetail.Columns.Add( new DataColumn("idivakind", typeof(int)));
	tmandatedetail.Columns.Add( new DataColumn("idsor1", typeof(int)));
	tmandatedetail.Columns.Add( new DataColumn("idsor2", typeof(int)));
	tmandatedetail.Columns.Add( new DataColumn("idsor3", typeof(int)));
	tmandatedetail.Columns.Add( new DataColumn("idaccmotiveannulment", typeof(string)));
	tmandatedetail.Columns.Add( new DataColumn("flagactivity", typeof(short)));
	tmandatedetail.Columns.Add( new DataColumn("va3type", typeof(string)));
	tmandatedetail.Columns.Add( new DataColumn("applierannotations", typeof(string)));
	tmandatedetail.Columns.Add( new DataColumn("ivanotes", typeof(string)));
	tmandatedetail.Columns.Add( new DataColumn("idlist", typeof(int)));
	tmandatedetail.Columns.Add( new DataColumn("idunit", typeof(int)));
	tmandatedetail.Columns.Add( new DataColumn("idpackage", typeof(int)));
	tmandatedetail.Columns.Add( new DataColumn("unitsforpackage", typeof(int)));
	tmandatedetail.Columns.Add( new DataColumn("npackage", typeof(decimal)));
	tmandatedetail.Columns.Add( new DataColumn("cupcode", typeof(string)));
	tmandatedetail.Columns.Add( new DataColumn("cigcode", typeof(string)));
	tmandatedetail.Columns.Add( new DataColumn("flagto_unload", typeof(string)));
	tmandatedetail.Columns.Add( new DataColumn("epkind", typeof(string)));
	tmandatedetail.Columns.Add( new DataColumn("rownum_origin", typeof(int)));
	tmandatedetail.Columns.Add( new DataColumn("contractamount", typeof(decimal)));
	tmandatedetail.Columns.Add( new DataColumn("idavcp", typeof(int)));
	tmandatedetail.Columns.Add( new DataColumn("idavcp_choice", typeof(int)));
	tmandatedetail.Columns.Add( new DataColumn("avcp_startcontract", typeof(DateTime)));
	tmandatedetail.Columns.Add( new DataColumn("avcp_stopcontract", typeof(DateTime)));
	tmandatedetail.Columns.Add( new DataColumn("avcp_description", typeof(string)));
	tmandatedetail.Columns.Add( new DataColumn("idpccdebitmotive", typeof(string)));
	tmandatedetail.Columns.Add( new DataColumn("idpccdebitstatus", typeof(string)));
	tmandatedetail.Columns.Add( new DataColumn("idcostpartition", typeof(int)));
	tmandatedetail.Columns.Add( new DataColumn("expensekind", typeof(string)));
	tmandatedetail.Columns.Add( new DataColumn("idepexp", typeof(int)));
	tmandatedetail.Columns.Add( new DataColumn("idepacc", typeof(int)));
	tmandatedetail.Columns.Add( new DataColumn("idlocation", typeof(int)));
	tmandatedetail.Columns.Add( new DataColumn("idupb_iva", typeof(string)));
	tmandatedetail.Columns.Add( new DataColumn("idsor_siope", typeof(int)));
	tmandatedetail.Columns.Add( new DataColumn("idepexp_pre", typeof(int)));
	tmandatedetail.Columns.Add( new DataColumn("rownum_main", typeof(int)));
	Tables.Add(tmandatedetail);
	tmandatedetail.PrimaryKey =  new DataColumn[]{tmandatedetail.Columns["idmankind"], tmandatedetail.Columns["nman"], tmandatedetail.Columns["rownum"], tmandatedetail.Columns["yman"]};


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
	tmandatekind.Columns.Add( new DataColumn("flag", typeof(int)));
	tmandatekind.Columns.Add( new DataColumn("touniqueregister", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("ipa_fe", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("riferimento_amministrazione", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("flagcreatedoubleentry", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("idivakind_forced", typeof(int)));
	tmandatekind.Columns.Add( new DataColumn("idreg_rupanac", typeof(int)));
	tmandatekind.Columns.Add( new DataColumn("requested_doc", typeof(int)));
	Tables.Add(tmandatekind);
	tmandatekind.PrimaryKey =  new DataColumn[]{tmandatekind.Columns["idmankind"]};


	//////////////////// MANDATE /////////////////////////////////
	var tmandate= new DataTable("mandate");
	C= new DataColumn("idmankind", typeof(string));
	C.AllowDBNull=false;
	tmandate.Columns.Add(C);
	C= new DataColumn("nman", typeof(int));
	C.AllowDBNull=false;
	tmandate.Columns.Add(C);
	C= new DataColumn("yman", typeof(short));
	C.AllowDBNull=false;
	tmandate.Columns.Add(C);
	tmandate.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tmandate.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tmandate.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tmandate.Columns.Add(C);
	tmandate.Columns.Add( new DataColumn("deliveryaddress", typeof(string)));
	tmandate.Columns.Add( new DataColumn("deliveryexpiration", typeof(string)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tmandate.Columns.Add(C);
	tmandate.Columns.Add( new DataColumn("doc", typeof(string)));
	tmandate.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	tmandate.Columns.Add( new DataColumn("exchangerate", typeof(double)));
	tmandate.Columns.Add( new DataColumn("idreg", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tmandate.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tmandate.Columns.Add(C);
	C= new DataColumn("officiallyprinted", typeof(string));
	C.AllowDBNull=false;
	tmandate.Columns.Add(C);
	tmandate.Columns.Add( new DataColumn("paymentexpiring", typeof(short)));
	tmandate.Columns.Add( new DataColumn("registryreference", typeof(string)));
	tmandate.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tmandate.Columns.Add( new DataColumn("txt", typeof(string)));
	tmandate.Columns.Add( new DataColumn("idman", typeof(int)));
	tmandate.Columns.Add( new DataColumn("idcurrency", typeof(int)));
	tmandate.Columns.Add( new DataColumn("idexpirationkind", typeof(short)));
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
	tmandate.Columns.Add( new DataColumn("nman_origin", typeof(int)));
	tmandate.Columns.Add( new DataColumn("yman_origin", typeof(short)));
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
	tmandate.Columns.Add( new DataColumn("idoffice", typeof(int)));
	tmandate.Columns.Add( new DataColumn("flagtenderresult", typeof(string)));
	tmandate.Columns.Add( new DataColumn("motiveassignment", typeof(string)));
	tmandate.Columns.Add( new DataColumn("anacreduced", typeof(double)));
	tmandate.Columns.Add( new DataColumn("idreg_rupanac", typeof(int)));
	tmandate.Columns.Add( new DataColumn("tenderkind", typeof(string)));
	tmandate.Columns.Add( new DataColumn("publishdate", typeof(DateTime)));
	tmandate.Columns.Add( new DataColumn("publishdatekind", typeof(string)));
	tmandate.Columns.Add( new DataColumn("requested_doc", typeof(int)));
	tmandate.Columns.Add( new DataColumn("flagbit", typeof(int)));
	Tables.Add(tmandate);
	tmandate.PrimaryKey =  new DataColumn[]{tmandate.Columns["idmankind"], tmandate.Columns["nman"], tmandate.Columns["yman"]};


	//////////////////// EXPENSELASTMANDATEDETAIL /////////////////////////////////
	var texpenselastmandatedetail= new DataTable("expenselastmandatedetail");
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpenselastmandatedetail.Columns.Add(C);
	C= new DataColumn("idmankind", typeof(string));
	C.AllowDBNull=false;
	texpenselastmandatedetail.Columns.Add(C);
	C= new DataColumn("yman", typeof(short));
	C.AllowDBNull=false;
	texpenselastmandatedetail.Columns.Add(C);
	C= new DataColumn("nman", typeof(int));
	C.AllowDBNull=false;
	texpenselastmandatedetail.Columns.Add(C);
	C= new DataColumn("rownum", typeof(int));
	C.AllowDBNull=false;
	texpenselastmandatedetail.Columns.Add(C);
	C= new DataColumn("amount", typeof(decimal));
	C.AllowDBNull=false;
	texpenselastmandatedetail.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpenselastmandatedetail.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpenselastmandatedetail.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpenselastmandatedetail.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpenselastmandatedetail.Columns.Add(C);
	texpenselastmandatedetail.Columns.Add( new DataColumn("originalamount", typeof(decimal)));
	Tables.Add(texpenselastmandatedetail);
	texpenselastmandatedetail.PrimaryKey =  new DataColumn[]{texpenselastmandatedetail.Columns["idexp"], texpenselastmandatedetail.Columns["idmankind"], texpenselastmandatedetail.Columns["yman"], texpenselastmandatedetail.Columns["nman"], texpenselastmandatedetail.Columns["rownum"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{mandatedetail.Columns["idmankind"], mandatedetail.Columns["nman"], mandatedetail.Columns["rownum"], mandatedetail.Columns["yman"]};
	var cChild = new []{expenselastmandatedetail.Columns["idmankind"], expenselastmandatedetail.Columns["nman"], expenselastmandatedetail.Columns["rownum"], expenselastmandatedetail.Columns["yman"]};
	Relations.Add(new DataRelation("mandatedetail_expenselastmandatedetail",cPar,cChild,false));

	cPar = new []{mandate.Columns["idmankind"], mandate.Columns["nman"], mandate.Columns["yman"]};
	cChild = new []{expenselastmandatedetail.Columns["idmankind"], expenselastmandatedetail.Columns["nman"], expenselastmandatedetail.Columns["yman"]};
	Relations.Add(new DataRelation("mandate_expenselastmandatedetail",cPar,cChild,false));

	cPar = new []{mandatekind.Columns["idmankind"]};
	cChild = new []{expenselastmandatedetail.Columns["idmankind"]};
	Relations.Add(new DataRelation("mandatekind_expenselastmandatedetail",cPar,cChild,false));

	#endregion

}
}
}
