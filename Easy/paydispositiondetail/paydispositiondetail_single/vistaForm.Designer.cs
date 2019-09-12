/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
namespace paydispositiondetail_single {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Disposizione di Pagamento - Dettaglio
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable paydispositiondetail 		=> Tables["paydispositiondetail"];

	///<summary>
	///Nazioni
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable geo_nation 		=> Tables["geo_nation"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable geo_cityview 		=> Tables["geo_cityview"];

	///<summary>
	///Causale CBI
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable cbimotive 		=> Tables["cbimotive"];

	///<summary>
	///Movimento di spesa
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expense 		=> Tables["expense"];

	///<summary>
	///Fasi di spesa
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expensephase 		=> Tables["expensephase"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable payment1 		=> Tables["payment1"];

	///<summary>
	///Movimento di spesa - Dettaglio
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expenselast 		=> Tables["expenselast"];

	///<summary>
	///Trattamento delle spese
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable chargehandling 		=> Tables["chargehandling"];

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
	//////////////////// PAYDISPOSITIONDETAIL /////////////////////////////////
	var tpaydispositiondetail= new DataTable("paydispositiondetail");
	C= new DataColumn("idpaydisposition", typeof(int));
	C.AllowDBNull=false;
	tpaydispositiondetail.Columns.Add(C);
	C= new DataColumn("iddetail", typeof(int));
	C.AllowDBNull=false;
	tpaydispositiondetail.Columns.Add(C);
	tpaydispositiondetail.Columns.Add( new DataColumn("surname", typeof(string)));
	tpaydispositiondetail.Columns.Add( new DataColumn("forename", typeof(string)));
	tpaydispositiondetail.Columns.Add( new DataColumn("idcity", typeof(int)));
	tpaydispositiondetail.Columns.Add( new DataColumn("idnation", typeof(int)));
	tpaydispositiondetail.Columns.Add( new DataColumn("gender", typeof(string)));
	tpaydispositiondetail.Columns.Add( new DataColumn("birthdate", typeof(DateTime)));
	tpaydispositiondetail.Columns.Add( new DataColumn("cf", typeof(string)));
	tpaydispositiondetail.Columns.Add( new DataColumn("address", typeof(string)));
	tpaydispositiondetail.Columns.Add( new DataColumn("location", typeof(string)));
	tpaydispositiondetail.Columns.Add( new DataColumn("province", typeof(string)));
	tpaydispositiondetail.Columns.Add( new DataColumn("cap", typeof(string)));
	tpaydispositiondetail.Columns.Add( new DataColumn("abi", typeof(string)));
	tpaydispositiondetail.Columns.Add( new DataColumn("cab", typeof(string)));
	tpaydispositiondetail.Columns.Add( new DataColumn("motive", typeof(string)));
	tpaydispositiondetail.Columns.Add( new DataColumn("amount", typeof(decimal)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tpaydispositiondetail.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tpaydispositiondetail.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpaydispositiondetail.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpaydispositiondetail.Columns.Add(C);
	tpaydispositiondetail.Columns.Add( new DataColumn("email", typeof(string)));
	tpaydispositiondetail.Columns.Add( new DataColumn("idcbimotive", typeof(int)));
	tpaydispositiondetail.Columns.Add( new DataColumn("cc", typeof(string)));
	tpaydispositiondetail.Columns.Add( new DataColumn("iban", typeof(string)));
	tpaydispositiondetail.Columns.Add( new DataColumn("cin", typeof(string)));
	tpaydispositiondetail.Columns.Add( new DataColumn("flaghuman", typeof(Char)));
	tpaydispositiondetail.Columns.Add( new DataColumn("title", typeof(string)));
	tpaydispositiondetail.Columns.Add( new DataColumn("p_iva", typeof(string)));
	tpaydispositiondetail.Columns.Add( new DataColumn("paymentcode", typeof(string)));
	tpaydispositiondetail.Columns.Add( new DataColumn("paymethodcode", typeof(int)));
	tpaydispositiondetail.Columns.Add( new DataColumn("academicyear", typeof(int)));
	tpaydispositiondetail.Columns.Add( new DataColumn("calendaryear", typeof(int)));
	tpaydispositiondetail.Columns.Add( new DataColumn("degreekind", typeof(string)));
	tpaydispositiondetail.Columns.Add( new DataColumn("degreecode", typeof(string)));
	tpaydispositiondetail.Columns.Add( new DataColumn("flagtaxrefund", typeof(string)));
	tpaydispositiondetail.Columns.Add( new DataColumn("idexp", typeof(int)));
	tpaydispositiondetail.Columns.Add( new DataColumn("flag", typeof(int)));
	tpaydispositiondetail.Columns.Add( new DataColumn("idchargehandling", typeof(int)));
	Tables.Add(tpaydispositiondetail);
	tpaydispositiondetail.PrimaryKey =  new DataColumn[]{tpaydispositiondetail.Columns["idpaydisposition"], tpaydispositiondetail.Columns["iddetail"]};


	//////////////////// GEO_NATION /////////////////////////////////
	var tgeo_nation= new DataTable("geo_nation");
	C= new DataColumn("idnation", typeof(int));
	C.AllowDBNull=false;
	tgeo_nation.Columns.Add(C);
	tgeo_nation.Columns.Add( new DataColumn("idcontinent", typeof(int)));
	tgeo_nation.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tgeo_nation.Columns.Add( new DataColumn("lu", typeof(string)));
	tgeo_nation.Columns.Add( new DataColumn("newnation", typeof(int)));
	tgeo_nation.Columns.Add( new DataColumn("oldnation", typeof(int)));
	tgeo_nation.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tgeo_nation.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tgeo_nation.Columns.Add( new DataColumn("title", typeof(string)));
	Tables.Add(tgeo_nation);
	tgeo_nation.PrimaryKey =  new DataColumn[]{tgeo_nation.Columns["idnation"]};


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
	C= new DataColumn("idcountry", typeof(int));
	C.AllowDBNull=false;
	tgeo_cityview.Columns.Add(C);
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


	//////////////////// CBIMOTIVE /////////////////////////////////
	var tcbimotive= new DataTable("cbimotive");
	C= new DataColumn("idcbimotive", typeof(int));
	C.AllowDBNull=false;
	tcbimotive.Columns.Add(C);
	C= new DataColumn("codemotive", typeof(string));
	C.AllowDBNull=false;
	tcbimotive.Columns.Add(C);
	tcbimotive.Columns.Add( new DataColumn("description", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcbimotive.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcbimotive.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcbimotive.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcbimotive.Columns.Add(C);
	Tables.Add(tcbimotive);
	tcbimotive.PrimaryKey =  new DataColumn[]{tcbimotive.Columns["idcbimotive"]};


	//////////////////// EXPENSE /////////////////////////////////
	var texpense= new DataTable("expense");
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	texpense.Columns.Add( new DataColumn("doc", typeof(string)));
	texpense.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	texpense.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	texpense.Columns.Add( new DataColumn("idreg", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	C= new DataColumn("nmov", typeof(int));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	texpense.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	texpense.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("ymov", typeof(short));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	texpense.Columns.Add( new DataColumn("idclawback", typeof(int)));
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	texpense.Columns.Add( new DataColumn("parentidexp", typeof(int)));
	texpense.Columns.Add( new DataColumn("idpayment", typeof(int)));
	texpense.Columns.Add( new DataColumn("idformerexpense", typeof(int)));
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	texpense.Columns.Add( new DataColumn("idman", typeof(int)));
	texpense.Columns.Add( new DataColumn("autokind", typeof(byte)));
	texpense.Columns.Add( new DataColumn("autocode", typeof(int)));
	texpense.Columns.Add( new DataColumn("cupcode", typeof(string)));
	texpense.Columns.Add( new DataColumn("cigcode", typeof(string)));
	texpense.Columns.Add( new DataColumn("external_reference", typeof(string)));
	Tables.Add(texpense);
	texpense.PrimaryKey =  new DataColumn[]{texpense.Columns["idexp"]};


	//////////////////// EXPENSEPHASE /////////////////////////////////
	var texpensephase= new DataTable("expensephase");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpensephase.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpensephase.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	texpensephase.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpensephase.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpensephase.Columns.Add(C);
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	texpensephase.Columns.Add(C);
	Tables.Add(texpensephase);
	texpensephase.PrimaryKey =  new DataColumn[]{texpensephase.Columns["nphase"]};


	//////////////////// PAYMENT1 /////////////////////////////////
	var tpayment1= new DataTable("payment1");
	C= new DataColumn("npay", typeof(int));
	C.AllowDBNull=false;
	tpayment1.Columns.Add(C);
	tpayment1.Columns.Add( new DataColumn("npay_treasurer", typeof(int)));
	C= new DataColumn("ypay", typeof(short));
	C.AllowDBNull=false;
	tpayment1.Columns.Add(C);
	tpayment1.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	tpayment1.Columns.Add( new DataColumn("annulmentdate", typeof(DateTime)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tpayment1.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tpayment1.Columns.Add(C);
	tpayment1.Columns.Add( new DataColumn("idreg", typeof(int)));
	tpayment1.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpayment1.Columns.Add(C);
	tpayment1.Columns.Add( new DataColumn("printdate", typeof(DateTime)));
	tpayment1.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tpayment1.Columns.Add( new DataColumn("txt", typeof(string)));
	tpayment1.Columns.Add( new DataColumn("idfin", typeof(int)));
	tpayment1.Columns.Add( new DataColumn("idman", typeof(int)));
	tpayment1.Columns.Add( new DataColumn("idstamphandling", typeof(int)));
	tpayment1.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tpayment1.Columns.Add(C);
	C= new DataColumn("kpay", typeof(int));
	C.AllowDBNull=false;
	tpayment1.Columns.Add(C);
	tpayment1.Columns.Add( new DataColumn("kpaymenttransmission", typeof(int)));
	tpayment1.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tpayment1.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tpayment1.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tpayment1.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tpayment1.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tpayment1);
	tpayment1.PrimaryKey =  new DataColumn[]{tpayment1.Columns["kpay"]};


	//////////////////// EXPENSELAST /////////////////////////////////
	var texpenselast= new DataTable("expenselast");
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpenselast.Columns.Add(C);
	texpenselast.Columns.Add( new DataColumn("cc", typeof(string)));
	texpenselast.Columns.Add( new DataColumn("cin", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpenselast.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpenselast.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	texpenselast.Columns.Add(C);
	texpenselast.Columns.Add( new DataColumn("iban", typeof(string)));
	texpenselast.Columns.Add( new DataColumn("idbank", typeof(string)));
	texpenselast.Columns.Add( new DataColumn("idcab", typeof(string)));
	texpenselast.Columns.Add( new DataColumn("iddeputy", typeof(int)));
	texpenselast.Columns.Add( new DataColumn("idpay", typeof(int)));
	texpenselast.Columns.Add( new DataColumn("idregistrypaymethod", typeof(int)));
	texpenselast.Columns.Add( new DataColumn("idser", typeof(int)));
	texpenselast.Columns.Add( new DataColumn("ivaamount", typeof(decimal)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpenselast.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpenselast.Columns.Add(C);
	texpenselast.Columns.Add( new DataColumn("nbill", typeof(int)));
	texpenselast.Columns.Add( new DataColumn("paymentdescr", typeof(string)));
	texpenselast.Columns.Add( new DataColumn("refexternaldoc", typeof(string)));
	texpenselast.Columns.Add( new DataColumn("servicestart", typeof(DateTime)));
	texpenselast.Columns.Add( new DataColumn("servicestop", typeof(DateTime)));
	texpenselast.Columns.Add( new DataColumn("idpaymethod", typeof(int)));
	texpenselast.Columns.Add( new DataColumn("kpay", typeof(int)));
	texpenselast.Columns.Add( new DataColumn("idaccdebit", typeof(string)));
	texpenselast.Columns.Add( new DataColumn("biccode", typeof(string)));
	texpenselast.Columns.Add( new DataColumn("extracode", typeof(string)));
	texpenselast.Columns.Add( new DataColumn("paymethod_allowdeputy", typeof(string)));
	texpenselast.Columns.Add( new DataColumn("paymethod_flag", typeof(int)));
	texpenselast.Columns.Add( new DataColumn("idchargehandling", typeof(int)));
	Tables.Add(texpenselast);
	texpenselast.PrimaryKey =  new DataColumn[]{texpenselast.Columns["idexp"]};


	//////////////////// CHARGEHANDLING /////////////////////////////////
	var tchargehandling= new DataTable("chargehandling");
	tchargehandling.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tchargehandling.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tchargehandling.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tchargehandling.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tchargehandling.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tchargehandling.Columns.Add(C);
	tchargehandling.Columns.Add( new DataColumn("handlingbankcode", typeof(string)));
	tchargehandling.Columns.Add( new DataColumn("flag", typeof(int)));
	C= new DataColumn("idchargehandling", typeof(int));
	C.AllowDBNull=false;
	tchargehandling.Columns.Add(C);
	tchargehandling.Columns.Add( new DataColumn("motive", typeof(string)));
	tchargehandling.Columns.Add( new DataColumn("payment_kind", typeof(string)));
	Tables.Add(tchargehandling);
	tchargehandling.PrimaryKey =  new DataColumn[]{tchargehandling.Columns["idchargehandling"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{cbimotive.Columns["idcbimotive"]};
	var cChild = new []{paydispositiondetail.Columns["idcbimotive"]};
	Relations.Add(new DataRelation("FK_cbimotive_paydispositiondetail",cPar,cChild,false));

	cPar = new []{geo_nation.Columns["idnation"]};
	cChild = new []{paydispositiondetail.Columns["idnation"]};
	Relations.Add(new DataRelation("geo_nation_paydispositiondetail",cPar,cChild,false));

	cPar = new []{geo_cityview.Columns["idcity"]};
	cChild = new []{paydispositiondetail.Columns["idcity"]};
	Relations.Add(new DataRelation("geo_cityview_paydispositiondetail",cPar,cChild,false));

	cPar = new []{expensephase.Columns["nphase"]};
	cChild = new []{expense.Columns["nphase"]};
	Relations.Add(new DataRelation("expensephase_expense",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{expenselast.Columns["idexp"]};
	Relations.Add(new DataRelation("expense_expenselast",cPar,cChild,false));

	cPar = new []{payment1.Columns["kpay"]};
	cChild = new []{expenselast.Columns["kpay"]};
	Relations.Add(new DataRelation("payment1_expenselast",cPar,cChild,false));

	cPar = new []{paydispositiondetail.Columns["idexp"]};
	cChild = new []{expense.Columns["idexp"]};
	Relations.Add(new DataRelation("paydispositiondetail_expense",cPar,cChild,false));

	cPar = new []{chargehandling.Columns["idchargehandling"]};
	cChild = new []{paydispositiondetail.Columns["idchargehandling"]};
	Relations.Add(new DataRelation("chargehandling_paydispositiondetail",cPar,cChild,false));

	#endregion

}
}
}
