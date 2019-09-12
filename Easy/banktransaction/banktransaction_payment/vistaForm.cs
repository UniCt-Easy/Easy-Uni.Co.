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
using System.Globalization;
namespace banktransaction_payment {
[System.CodeDom.Compiler.GeneratedCodeAttribute("HDSGene", "2.0")]
[DesignerCategoryAttribute("code")]
public partial class vistaForm: System.Data.DataSet {

	#region Table members declaration
	///<summary>
	///Movimento bancario
	///</summary>
	[DebuggerNonUserCodeAttribute()][Browsable(false)]
	public DataTable banktransaction		{get { return Tables["banktransaction"];}}
	[DebuggerNonUserCodeAttribute()][Browsable(false)]
	public DataTable expenseview		{get { return Tables["expenseview"];}}
	[DebuggerNonUserCodeAttribute()][Browsable(false)]
	public DataTable payment_bankview		{get { return Tables["payment_bankview"];}}
	///<summary>
	///Importazione esiti e sospesi
	///</summary>
	[DebuggerNonUserCodeAttribute()][Browsable(false)]
	public DataTable bankimport		{get { return Tables["bankimport"];}}
	#endregion


[DebuggerNonUserCodeAttribute()]
public vistaForm(){
	BeginInit();
	InitClass();
	EndInit();
}
[DebuggerNonUserCodeAttribute()]
private void InitClass() {
	DataSetName = "vistaForm";
	Prefix = "";
	Namespace = "http://tempuri.org/vistaForm.xsd";
	EnforceConstraints = false;

	#region create DataTables
	DataTable T;
	DataColumn C;
	//////////////////// banktransaction /////////////////////////////////
	T= new DataTable("banktransaction");
	C= new DataColumn("yban", typeof(System.Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("nban", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("kind", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("bankreference", typeof(System.String)));
	T.Columns.Add( new DataColumn("transactiondate", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("valuedate", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("amount", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("kpay", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("kpro", typeof(System.Int32)));
	C= new DataColumn("cu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idexp", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idinc", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idpay", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idpro", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idbankimport", typeof(System.Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["yban"], T.Columns["nban"]};


	//////////////////// expenseview /////////////////////////////////
	T= new DataTable("expenseview");
	C= new DataColumn("idexp", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("nphase", typeof(System.Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("phase", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ymov", typeof(System.Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("nmov", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("parentidexp", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("parentymov", typeof(System.Int16)));
	T.Columns.Add( new DataColumn("parentnmov", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idformerexpense", typeof(System.Int32)));
	C= new DataColumn("ayear", typeof(System.Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idfin", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("codefin", typeof(System.String)));
	T.Columns.Add( new DataColumn("finance", typeof(System.String)));
	T.Columns.Add( new DataColumn("idupb", typeof(System.String)));
	T.Columns.Add( new DataColumn("codeupb", typeof(System.String)));
	T.Columns.Add( new DataColumn("upb", typeof(System.String)));
	T.Columns.Add( new DataColumn("idreg", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("registry", typeof(System.String)));
	T.Columns.Add( new DataColumn("idman", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("manager", typeof(System.String)));
	T.Columns.Add( new DataColumn("kpay", typeof(System.Int32)));
	C= new DataColumn("ypay", typeof(System.Int16));
	C.ReadOnly=true;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("npay", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("paymentadate", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("doc", typeof(System.String)));
	T.Columns.Add( new DataColumn("docdate", typeof(System.DateTime)));
	C= new DataColumn("description", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("amount", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("ayearstartamount", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("curramount", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("available", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("idregistrypaymethod", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idpaymethod", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("cin", typeof(System.String)));
	T.Columns.Add( new DataColumn("idbank", typeof(System.String)));
	T.Columns.Add( new DataColumn("idcab", typeof(System.String)));
	T.Columns.Add( new DataColumn("cc", typeof(System.String)));
	T.Columns.Add( new DataColumn("iddeputy", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("deputy", typeof(System.String)));
	T.Columns.Add( new DataColumn("refexternaldoc", typeof(System.String)));
	T.Columns.Add( new DataColumn("paymentdescr", typeof(System.String)));
	T.Columns.Add( new DataColumn("idser", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("service", typeof(System.String)));
	T.Columns.Add( new DataColumn("servicestart", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("servicestop", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("ivaamount", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("flag", typeof(System.Byte)));
	T.Columns.Add( new DataColumn("totflag", typeof(System.Byte)));
	C= new DataColumn("flagarrear", typeof(System.String));
	C.ReadOnly=true;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("autokind", typeof(System.Byte)));
	T.Columns.Add( new DataColumn("idpayment", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("expiration", typeof(System.DateTime)));
	C= new DataColumn("adate", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("autocode", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idclawback", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("clawback", typeof(System.String)));
	T.Columns.Add( new DataColumn("nbill", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idpay", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("txt", typeof(System.String)));
	C= new DataColumn("cu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idexp"]};


	//////////////////// payment_bankview /////////////////////////////////
	T= new DataTable("payment_bankview");
	C= new DataColumn("kpay", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idpay", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ypay", typeof(System.Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("npay", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idreg", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("registry", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("description", typeof(System.String)));
	C= new DataColumn("amount", typeof(System.Decimal));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["kpay"], T.Columns["idpay"]};


	//////////////////// bankimport /////////////////////////////////
	T= new DataTable("bankimport");
	C= new DataColumn("idbankimport", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("lastpayment", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("lastproceeds", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("lastbillincome", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("lastbillexpense", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("totalpayment", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("totalproceeds", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("totalbillincome_plus", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("totalbillincome_minus", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("totalbillexpense_plus", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("totalbillexpense_minus", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("idbank", typeof(System.String)));
	T.Columns.Add( new DataColumn("ct", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("cu", typeof(System.String)));
	T.Columns.Add( new DataColumn("lt", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("lu", typeof(System.String)));
	T.Columns.Add( new DataColumn("adate", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("ayear", typeof(System.Int16)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idbankimport"]};


	#endregion


	#region DataRelation creation
	DataColumn []CPar;
	DataColumn []CChild;
	CPar = new DataColumn[2]{payment_bankview.Columns["kpay"], payment_bankview.Columns["idpay"]};
	CChild = new DataColumn[2]{banktransaction.Columns["kpay"], banktransaction.Columns["idpay"]};
	Relations.Add(new DataRelation("payment_bankview_banktransaction",CPar,CChild));

	CPar = new DataColumn[1]{expenseview.Columns["idexp"]};
	CChild = new DataColumn[1]{banktransaction.Columns["idexp"]};
	Relations.Add(new DataRelation("expenseviewbanktransaction",CPar,CChild));

	CPar = new DataColumn[1]{bankimport.Columns["idbankimport"]};
	CChild = new DataColumn[1]{banktransaction.Columns["idbankimport"]};
	Relations.Add(new DataRelation("bankimport_banktransaction",CPar,CChild));

	#endregion

}
}
}
