
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
using System.Globalization;
namespace ct_expenselast_reset {
[Serializable()][DesignerCategoryAttribute("code")][System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRootAttribute("vistaForm")][System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
public partial class vistaForm: System.Data.DataSet {

	#region Table members declaration
	///<summary>
	///Variazione movimento di spesa
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable expensevar		{get { return Tables["expensevar"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable expenseyear		{get { return Tables["expenseyear"];}}
	///<summary>
	///Movimento di spesa
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable expense		{get { return Tables["expense"];}}
	///<summary>
	///Classificazione Movimenti di spesa
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable expensesorted		{get { return Tables["expensesorted"];}}
	///<summary>
	///Movimento di spesa - Dettaglio
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable expenselast		{get { return Tables["expenselast"];}}
	///<summary>
	///Documento di pagamento
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable payment		{get { return Tables["payment"];}}
	#endregion


	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables {get {return base.Tables;}}

	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataRelationCollection Relations {get {return base.Relations; } } 

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
this.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
	EnforceConstraints = false;

	#region create DataTables
	DataTable T;
	DataColumn C;
	//////////////////// expensevar /////////////////////////////////
	T= new DataTable("expensevar");
	C= new DataColumn("nvar", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("adate", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("amount", typeof(System.Decimal)));
	C= new DataColumn("ct", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("doc", typeof(System.String)));
	T.Columns.Add( new DataColumn("docdate", typeof(System.DateTime)));
	C= new DataColumn("lt", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("rtf", typeof(System.Byte[])));
	T.Columns.Add( new DataColumn("transferkind", typeof(System.String)));
	T.Columns.Add( new DataColumn("txt", typeof(System.String)));
	C= new DataColumn("yvar", typeof(System.Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("ninv", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("yinv", typeof(System.Int16)));
	C= new DataColumn("idexp", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idpayment", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("autokind", typeof(System.Byte)));
	T.Columns.Add( new DataColumn("autocode", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idinvkind", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("movkind", typeof(System.Int16)));
	T.Columns.Add( new DataColumn("kpaymenttransmission", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idunderwriting", typeof(System.Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["nvar"], T.Columns["idexp"]};


	//////////////////// expenseyear /////////////////////////////////
	T= new DataTable("expenseyear");
	C= new DataColumn("ayear", typeof(System.Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("amount", typeof(System.Decimal)));
	C= new DataColumn("ct", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idupb", typeof(System.String)));
	C= new DataColumn("lt", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idexp", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idfin", typeof(System.Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["ayear"], T.Columns["idexp"]};


	//////////////////// expense /////////////////////////////////
	T= new DataTable("expense");
	C= new DataColumn("adate", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("doc", typeof(System.String)));
	T.Columns.Add( new DataColumn("docdate", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("expiration", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("idreg", typeof(System.Int32)));
	C= new DataColumn("lt", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("nmov", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("rtf", typeof(System.Byte[])));
	T.Columns.Add( new DataColumn("txt", typeof(System.String)));
	C= new DataColumn("ymov", typeof(System.Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idclawback", typeof(System.Int32)));
	C= new DataColumn("idexp", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("parentidexp", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idpayment", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idformerexpense", typeof(System.Int32)));
	C= new DataColumn("nphase", typeof(System.Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idman", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("autokind", typeof(System.Byte)));
	T.Columns.Add( new DataColumn("autocode", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("cupcode", typeof(System.String)));
	T.Columns.Add( new DataColumn("cigcode", typeof(System.String)));
	T.Columns.Add( new DataColumn("external_reference", typeof(System.String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idexp"]};


	//////////////////// expensesorted /////////////////////////////////
	T= new DataTable("expensesorted");
	C= new DataColumn("idsubclass", typeof(System.Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("amount", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("ayear", typeof(System.Int16)));
	C= new DataColumn("ct", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("description", typeof(System.String)));
	T.Columns.Add( new DataColumn("flagnodate", typeof(System.String)));
	C= new DataColumn("lt", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("paridsor", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("paridsubclass", typeof(System.Int16)));
	T.Columns.Add( new DataColumn("rtf", typeof(System.Byte[])));
	T.Columns.Add( new DataColumn("start", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("stop", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("tobecontinued", typeof(System.String)));
	T.Columns.Add( new DataColumn("txt", typeof(System.String)));
	T.Columns.Add( new DataColumn("valuen1", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("valuen2", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("valuen3", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("valuen4", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("valuen5", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("values1", typeof(System.String)));
	T.Columns.Add( new DataColumn("values2", typeof(System.String)));
	T.Columns.Add( new DataColumn("values3", typeof(System.String)));
	T.Columns.Add( new DataColumn("values4", typeof(System.String)));
	T.Columns.Add( new DataColumn("values5", typeof(System.String)));
	T.Columns.Add( new DataColumn("valuev1", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("valuev2", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("valuev3", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("valuev4", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("valuev5", typeof(System.Decimal)));
	C= new DataColumn("idexp", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idsor", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idsubclass"], T.Columns["idexp"], T.Columns["idsor"]};


	//////////////////// expenselast /////////////////////////////////
	T= new DataTable("expenselast");
	C= new DataColumn("idexp", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("cc", typeof(System.String)));
	T.Columns.Add( new DataColumn("cin", typeof(System.String)));
	C= new DataColumn("ct", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("flag", typeof(System.Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("iban", typeof(System.String)));
	T.Columns.Add( new DataColumn("idbank", typeof(System.String)));
	T.Columns.Add( new DataColumn("idcab", typeof(System.String)));
	T.Columns.Add( new DataColumn("iddeputy", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idpay", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idregistrypaymethod", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idser", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("ivaamount", typeof(System.Decimal)));
	C= new DataColumn("lt", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("nbill", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("paymentdescr", typeof(System.String)));
	T.Columns.Add( new DataColumn("refexternaldoc", typeof(System.String)));
	T.Columns.Add( new DataColumn("servicestart", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("servicestop", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("idpaymethod", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("kpay", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idaccdebit", typeof(System.String)));
	T.Columns.Add( new DataColumn("biccode", typeof(System.String)));
	T.Columns.Add( new DataColumn("extracode", typeof(System.String)));
	T.Columns.Add( new DataColumn("paymethod_allowdeputy", typeof(System.String)));
	T.Columns.Add( new DataColumn("paymethod_flag", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idchargehandling", typeof(System.Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idexp"]};


	//////////////////// payment /////////////////////////////////
	T= new DataTable("payment");
	C= new DataColumn("npay", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ypay", typeof(System.Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("adate", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("annulmentdate", typeof(System.DateTime)));
	C= new DataColumn("ct", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idreg", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("lt", typeof(System.DateTime)));
	C= new DataColumn("lu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("printdate", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("rtf", typeof(System.Byte[])));
	T.Columns.Add( new DataColumn("txt", typeof(System.String)));
	T.Columns.Add( new DataColumn("idfin", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idman", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idstamphandling", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idtreasurer", typeof(System.Int32)));
	C= new DataColumn("flag", typeof(System.Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("kpay", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("kpaymenttransmission", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idsor01", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idsor02", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idsor03", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idsor04", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idsor05", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("external_reference", typeof(System.String)));
	T.Columns.Add( new DataColumn("npay_treasurer", typeof(System.Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["kpay"]};


	#endregion


	#region DataRelation creation
	DataColumn []CPar;
	DataColumn []CChild;
	CPar = new DataColumn[1]{expense.Columns["idexp"]};
	CChild = new DataColumn[1]{expenselast.Columns["idexp"]};
	Relations.Add(new DataRelation("FK_expense_expenselast",CPar,CChild,false));

	CPar = new DataColumn[1]{payment.Columns["kpay"]};
	CChild = new DataColumn[1]{expenselast.Columns["kpay"]};
	Relations.Add(new DataRelation("FK_payment_expenselast",CPar,CChild,false));

	CPar = new DataColumn[1]{expense.Columns["idexp"]};
	CChild = new DataColumn[1]{expensesorted.Columns["idexp"]};
	Relations.Add(new DataRelation("FK_expensesorted_expense",CPar,CChild,false));

	CPar = new DataColumn[1]{expense.Columns["idexp"]};
	CChild = new DataColumn[1]{expenseyear.Columns["idexp"]};
	Relations.Add(new DataRelation("FK_expenseyear_expense",CPar,CChild,false));

	CPar = new DataColumn[1]{expense.Columns["idexp"]};
	CChild = new DataColumn[1]{expensevar.Columns["idexp"]};
	Relations.Add(new DataRelation("FK_expensevar_expense",CPar,CChild,false));

	#endregion

}
}
}
