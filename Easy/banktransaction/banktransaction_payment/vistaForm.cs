
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
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace banktransaction_payment {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Movimento bancario
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable banktransaction 		=> Tables["banktransaction"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expenseview 		=> Tables["expenseview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable payment_bankview 		=> Tables["payment_bankview"];

	///<summary>
	///Importazione esiti e sospesi
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable bankimport 		=> Tables["bankimport"];

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
	//////////////////// BANKTRANSACTION /////////////////////////////////
	var tbanktransaction= new DataTable("banktransaction");
	C= new DataColumn("yban", typeof(short));
	C.AllowDBNull=false;
	tbanktransaction.Columns.Add(C);
	C= new DataColumn("nban", typeof(int));
	C.AllowDBNull=false;
	tbanktransaction.Columns.Add(C);
	C= new DataColumn("kind", typeof(string));
	C.AllowDBNull=false;
	tbanktransaction.Columns.Add(C);
	tbanktransaction.Columns.Add( new DataColumn("bankreference", typeof(string)));
	tbanktransaction.Columns.Add( new DataColumn("transactiondate", typeof(DateTime)));
	tbanktransaction.Columns.Add( new DataColumn("valuedate", typeof(DateTime)));
	tbanktransaction.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tbanktransaction.Columns.Add( new DataColumn("kpay", typeof(int)));
	tbanktransaction.Columns.Add( new DataColumn("kpro", typeof(int)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tbanktransaction.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tbanktransaction.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tbanktransaction.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tbanktransaction.Columns.Add(C);
	tbanktransaction.Columns.Add( new DataColumn("idexp", typeof(int)));
	tbanktransaction.Columns.Add( new DataColumn("idinc", typeof(int)));
	tbanktransaction.Columns.Add( new DataColumn("idpay", typeof(int)));
	tbanktransaction.Columns.Add( new DataColumn("idpro", typeof(int)));
	tbanktransaction.Columns.Add( new DataColumn("idbankimport", typeof(int)));
	Tables.Add(tbanktransaction);
	tbanktransaction.PrimaryKey =  new DataColumn[]{tbanktransaction.Columns["yban"], tbanktransaction.Columns["nban"]};


	//////////////////// EXPENSEVIEW /////////////////////////////////
	var texpenseview= new DataTable("expenseview");
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	C= new DataColumn("phase", typeof(string));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	C= new DataColumn("ymov", typeof(short));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	C= new DataColumn("nmov", typeof(int));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	texpenseview.Columns.Add( new DataColumn("parentidexp", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("parentymov", typeof(short)));
	texpenseview.Columns.Add( new DataColumn("parentnmov", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idformerexpense", typeof(int)));
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	texpenseview.Columns.Add( new DataColumn("idfin", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("codefin", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("finance", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("idupb", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("codeupb", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("upb", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("idreg", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("registry", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("idman", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("manager", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("kpay", typeof(int)));
	C= new DataColumn("ypay", typeof(short));
	C.ReadOnly=true;
	texpenseview.Columns.Add(C);
	texpenseview.Columns.Add( new DataColumn("npay", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("paymentadate", typeof(DateTime)));
	texpenseview.Columns.Add( new DataColumn("doc", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	texpenseview.Columns.Add( new DataColumn("amount", typeof(decimal)));
	texpenseview.Columns.Add( new DataColumn("ayearstartamount", typeof(decimal)));
	texpenseview.Columns.Add( new DataColumn("curramount", typeof(decimal)));
	texpenseview.Columns.Add( new DataColumn("available", typeof(decimal)));
	texpenseview.Columns.Add( new DataColumn("idregistrypaymethod", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idpaymethod", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("cin", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("idbank", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("idcab", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("cc", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("iddeputy", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("deputy", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("refexternaldoc", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("paymentdescr", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("idser", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("service", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("servicestart", typeof(DateTime)));
	texpenseview.Columns.Add( new DataColumn("servicestop", typeof(DateTime)));
	texpenseview.Columns.Add( new DataColumn("ivaamount", typeof(decimal)));
	texpenseview.Columns.Add( new DataColumn("flag", typeof(byte)));
	texpenseview.Columns.Add( new DataColumn("totflag", typeof(byte)));
	C= new DataColumn("flagarrear", typeof(string));
	C.ReadOnly=true;
	texpenseview.Columns.Add(C);
	texpenseview.Columns.Add( new DataColumn("autokind", typeof(byte)));
	texpenseview.Columns.Add( new DataColumn("idpayment", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	texpenseview.Columns.Add( new DataColumn("autocode", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idclawback", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("clawback", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("nbill", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idpay", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("txt", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	Tables.Add(texpenseview);
	texpenseview.PrimaryKey =  new DataColumn[]{texpenseview.Columns["idexp"]};


	//////////////////// PAYMENT_BANKVIEW /////////////////////////////////
	var tpayment_bankview= new DataTable("payment_bankview");
	C= new DataColumn("kpay", typeof(int));
	C.AllowDBNull=false;
	tpayment_bankview.Columns.Add(C);
	C= new DataColumn("idpay", typeof(int));
	C.AllowDBNull=false;
	tpayment_bankview.Columns.Add(C);
	C= new DataColumn("ypay", typeof(short));
	C.AllowDBNull=false;
	tpayment_bankview.Columns.Add(C);
	C= new DataColumn("npay", typeof(int));
	C.AllowDBNull=false;
	tpayment_bankview.Columns.Add(C);
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tpayment_bankview.Columns.Add(C);
	C= new DataColumn("registry", typeof(string));
	C.AllowDBNull=false;
	tpayment_bankview.Columns.Add(C);
	tpayment_bankview.Columns.Add( new DataColumn("description", typeof(string)));
	C= new DataColumn("amount", typeof(decimal));
	C.AllowDBNull=false;
	tpayment_bankview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tpayment_bankview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tpayment_bankview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpayment_bankview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpayment_bankview.Columns.Add(C);
	Tables.Add(tpayment_bankview);
	tpayment_bankview.PrimaryKey =  new DataColumn[]{tpayment_bankview.Columns["kpay"], tpayment_bankview.Columns["idpay"]};


	//////////////////// BANKIMPORT /////////////////////////////////
	var tbankimport= new DataTable("bankimport");
	C= new DataColumn("idbankimport", typeof(int));
	C.AllowDBNull=false;
	tbankimport.Columns.Add(C);
	tbankimport.Columns.Add( new DataColumn("lastpayment", typeof(DateTime)));
	tbankimport.Columns.Add( new DataColumn("lastproceeds", typeof(DateTime)));
	tbankimport.Columns.Add( new DataColumn("lastbillincome", typeof(DateTime)));
	tbankimport.Columns.Add( new DataColumn("lastbillexpense", typeof(DateTime)));
	tbankimport.Columns.Add( new DataColumn("totalpayment", typeof(decimal)));
	tbankimport.Columns.Add( new DataColumn("totalproceeds", typeof(decimal)));
	tbankimport.Columns.Add( new DataColumn("totalbillincome_plus", typeof(decimal)));
	tbankimport.Columns.Add( new DataColumn("totalbillincome_minus", typeof(decimal)));
	tbankimport.Columns.Add( new DataColumn("totalbillexpense_plus", typeof(decimal)));
	tbankimport.Columns.Add( new DataColumn("totalbillexpense_minus", typeof(decimal)));
	tbankimport.Columns.Add( new DataColumn("idbank", typeof(string)));
	tbankimport.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tbankimport.Columns.Add( new DataColumn("cu", typeof(string)));
	tbankimport.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tbankimport.Columns.Add( new DataColumn("lu", typeof(string)));
	tbankimport.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	tbankimport.Columns.Add( new DataColumn("ayear", typeof(short)));
	Tables.Add(tbankimport);
	tbankimport.PrimaryKey =  new DataColumn[]{tbankimport.Columns["idbankimport"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{payment_bankview.Columns["kpay"], payment_bankview.Columns["idpay"]};
	var cChild = new []{banktransaction.Columns["kpay"], banktransaction.Columns["idpay"]};
	Relations.Add(new DataRelation("payment_bankview_banktransaction",cPar,cChild,false));

	cPar = new []{expenseview.Columns["idexp"]};
	cChild = new []{banktransaction.Columns["idexp"]};
	Relations.Add(new DataRelation("expenseviewbanktransaction",cPar,cChild,false));

	cPar = new []{bankimport.Columns["idbankimport"]};
	cChild = new []{banktransaction.Columns["idbankimport"]};
	Relations.Add(new DataRelation("bankimport_banktransaction",cPar,cChild,false));

	#endregion

}
}
}
