
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
namespace admpay_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Pagamento Stipendi
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable admpay 		=> Tables["admpay"];

	///<summary>
	///Impegno del Pagamento Stipendi
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable admpay_appropriation 		=> Tables["admpay_appropriation"];

	///<summary>
	///Accertamento del Pagamento Stipendi
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable admpay_assessment 		=> Tables["admpay_assessment"];

	///<summary>
	///Bilancio
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable fin 		=> Tables["fin"];

	///<summary>
	///U.P.B.
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb 		=> Tables["upb"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomeview 		=> Tables["incomeview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expenseview 		=> Tables["expenseview"];

	///<summary>
	///Spese dei Pagamenti Stipendi
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable admpay_expense 		=> Tables["admpay_expense"];

	///<summary>
	///Entrate dei Pagamenti Stipendi
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable admpay_income 		=> Tables["admpay_income"];

	///<summary>
	///Classificazione Entrata dei Pagamenti Stipendi
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable admpay_incomesorted 		=> Tables["admpay_incomesorted"];

	///<summary>
	///Classificazione Spesa dei Pagamenti Stipendi
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable admpay_expensesorted 		=> Tables["admpay_expensesorted"];

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
	//////////////////// ADMPAY /////////////////////////////////
	var tadmpay= new DataTable("admpay");
	C= new DataColumn("yadmpay", typeof(int));
	C.AllowDBNull=false;
	tadmpay.Columns.Add(C);
	C= new DataColumn("nadmpay", typeof(int));
	C.AllowDBNull=false;
	tadmpay.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tadmpay.Columns.Add(C);
	C= new DataColumn("amount", typeof(decimal));
	C.AllowDBNull=false;
	tadmpay.Columns.Add(C);
	tadmpay.Columns.Add( new DataColumn("processed", typeof(string)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tadmpay.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tadmpay.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tadmpay.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tadmpay.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tadmpay.Columns.Add(C);
	Tables.Add(tadmpay);
	tadmpay.PrimaryKey =  new DataColumn[]{tadmpay.Columns["yadmpay"], tadmpay.Columns["nadmpay"]};


	//////////////////// ADMPAY_APPROPRIATION /////////////////////////////////
	var tadmpay_appropriation= new DataTable("admpay_appropriation");
	C= new DataColumn("yadmpay", typeof(int));
	C.AllowDBNull=false;
	tadmpay_appropriation.Columns.Add(C);
	C= new DataColumn("nadmpay", typeof(int));
	C.AllowDBNull=false;
	tadmpay_appropriation.Columns.Add(C);
	C= new DataColumn("nappropriation", typeof(int));
	C.AllowDBNull=false;
	tadmpay_appropriation.Columns.Add(C);
	tadmpay_appropriation.Columns.Add( new DataColumn("idfin", typeof(int)));
	tadmpay_appropriation.Columns.Add( new DataColumn("idupb", typeof(string)));
	tadmpay_appropriation.Columns.Add( new DataColumn("idexp", typeof(int)));
	C= new DataColumn("amount", typeof(decimal));
	C.AllowDBNull=false;
	tadmpay_appropriation.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tadmpay_appropriation.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tadmpay_appropriation.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tadmpay_appropriation.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tadmpay_appropriation.Columns.Add(C);
	tadmpay_appropriation.Columns.Add( new DataColumn("!codeupb", typeof(string)));
	tadmpay_appropriation.Columns.Add( new DataColumn("!codefin", typeof(string)));
	tadmpay_appropriation.Columns.Add( new DataColumn("!ymov", typeof(int)));
	tadmpay_appropriation.Columns.Add( new DataColumn("!nmov", typeof(int)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tadmpay_appropriation.Columns.Add(C);
	Tables.Add(tadmpay_appropriation);
	tadmpay_appropriation.PrimaryKey =  new DataColumn[]{tadmpay_appropriation.Columns["yadmpay"], tadmpay_appropriation.Columns["nadmpay"], tadmpay_appropriation.Columns["nappropriation"]};


	//////////////////// ADMPAY_ASSESSMENT /////////////////////////////////
	var tadmpay_assessment= new DataTable("admpay_assessment");
	C= new DataColumn("yadmpay", typeof(int));
	C.AllowDBNull=false;
	tadmpay_assessment.Columns.Add(C);
	C= new DataColumn("nadmpay", typeof(int));
	C.AllowDBNull=false;
	tadmpay_assessment.Columns.Add(C);
	C= new DataColumn("nassessment", typeof(int));
	C.AllowDBNull=false;
	tadmpay_assessment.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tadmpay_assessment.Columns.Add(C);
	tadmpay_assessment.Columns.Add( new DataColumn("idfin", typeof(int)));
	tadmpay_assessment.Columns.Add( new DataColumn("idupb", typeof(string)));
	tadmpay_assessment.Columns.Add( new DataColumn("idinc", typeof(int)));
	C= new DataColumn("amount", typeof(decimal));
	C.AllowDBNull=false;
	tadmpay_assessment.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tadmpay_assessment.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tadmpay_assessment.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tadmpay_assessment.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tadmpay_assessment.Columns.Add(C);
	tadmpay_assessment.Columns.Add( new DataColumn("!codeupb", typeof(string)));
	tadmpay_assessment.Columns.Add( new DataColumn("!codefin", typeof(string)));
	tadmpay_assessment.Columns.Add( new DataColumn("!ymov", typeof(int)));
	tadmpay_assessment.Columns.Add( new DataColumn("!nmov", typeof(int)));
	Tables.Add(tadmpay_assessment);
	tadmpay_assessment.PrimaryKey =  new DataColumn[]{tadmpay_assessment.Columns["yadmpay"], tadmpay_assessment.Columns["nadmpay"], tadmpay_assessment.Columns["nassessment"]};


	//////////////////// FIN /////////////////////////////////
	var tfin= new DataTable("fin");
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("codefin", typeof(string));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	Tables.Add(tfin);
	tfin.PrimaryKey =  new DataColumn[]{tfin.Columns["idfin"]};


	//////////////////// UPB /////////////////////////////////
	var tupb= new DataTable("upb");
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	Tables.Add(tupb);
	tupb.PrimaryKey =  new DataColumn[]{tupb.Columns["idupb"]};


	//////////////////// INCOMEVIEW /////////////////////////////////
	var tincomeview= new DataTable("incomeview");
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	C= new DataColumn("phase", typeof(string));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	C= new DataColumn("ymov", typeof(short));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	C= new DataColumn("nmov", typeof(int));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	tincomeview.Columns.Add( new DataColumn("parentymov", typeof(short)));
	tincomeview.Columns.Add( new DataColumn("parentnmov", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("parentidinc", typeof(int)));
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	tincomeview.Columns.Add( new DataColumn("idfin", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("codefin", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("finance", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("idupb", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("codeupb", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("upb", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("idreg", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("registry", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("idman", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("manager", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("ypro", typeof(short)));
	tincomeview.Columns.Add( new DataColumn("npro", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("doc", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	tincomeview.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tincomeview.Columns.Add( new DataColumn("ayearstartamount", typeof(decimal)));
	tincomeview.Columns.Add( new DataColumn("curramount", typeof(decimal)));
	tincomeview.Columns.Add( new DataColumn("available", typeof(decimal)));
	tincomeview.Columns.Add( new DataColumn("unpartitioned", typeof(decimal)));
	tincomeview.Columns.Add( new DataColumn("flag", typeof(byte)));
	C= new DataColumn("totflag", typeof(byte));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	tincomeview.Columns.Add( new DataColumn("flagarrear", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("autokind", typeof(byte)));
	tincomeview.Columns.Add( new DataColumn("autocode", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("idpayment", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	tincomeview.Columns.Add( new DataColumn("nbill", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("idpro", typeof(int)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	Tables.Add(tincomeview);

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
	texpenseview.Columns.Add( new DataColumn("iban", typeof(string)));
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


	//////////////////// ADMPAY_EXPENSE /////////////////////////////////
	var tadmpay_expense= new DataTable("admpay_expense");
	C= new DataColumn("yadmpay", typeof(int));
	C.AllowDBNull=false;
	tadmpay_expense.Columns.Add(C);
	C= new DataColumn("nadmpay", typeof(int));
	C.AllowDBNull=false;
	tadmpay_expense.Columns.Add(C);
	C= new DataColumn("nexpense", typeof(int));
	C.AllowDBNull=false;
	tadmpay_expense.Columns.Add(C);
	C= new DataColumn("nappropriation", typeof(int));
	C.AllowDBNull=false;
	tadmpay_expense.Columns.Add(C);
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tadmpay_expense.Columns.Add(C);
	tadmpay_expense.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tadmpay_expense.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tadmpay_expense.Columns.Add(C);
	C= new DataColumn("amount", typeof(decimal));
	C.AllowDBNull=false;
	tadmpay_expense.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tadmpay_expense.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tadmpay_expense.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tadmpay_expense.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tadmpay_expense.Columns.Add(C);
	tadmpay_expense.Columns.Add( new DataColumn("idser", typeof(int)));
	Tables.Add(tadmpay_expense);
	tadmpay_expense.PrimaryKey =  new DataColumn[]{tadmpay_expense.Columns["yadmpay"], tadmpay_expense.Columns["nadmpay"], tadmpay_expense.Columns["nexpense"]};


	//////////////////// ADMPAY_INCOME /////////////////////////////////
	var tadmpay_income= new DataTable("admpay_income");
	C= new DataColumn("yadmpay", typeof(int));
	C.AllowDBNull=false;
	tadmpay_income.Columns.Add(C);
	C= new DataColumn("nadmpay", typeof(int));
	C.AllowDBNull=false;
	tadmpay_income.Columns.Add(C);
	C= new DataColumn("nincome", typeof(int));
	C.AllowDBNull=false;
	tadmpay_income.Columns.Add(C);
	C= new DataColumn("nassessment", typeof(int));
	C.AllowDBNull=false;
	tadmpay_income.Columns.Add(C);
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tadmpay_income.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tadmpay_income.Columns.Add(C);
	C= new DataColumn("amount", typeof(decimal));
	C.AllowDBNull=false;
	tadmpay_income.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tadmpay_income.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tadmpay_income.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tadmpay_income.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tadmpay_income.Columns.Add(C);
	Tables.Add(tadmpay_income);
	tadmpay_income.PrimaryKey =  new DataColumn[]{tadmpay_income.Columns["yadmpay"], tadmpay_income.Columns["nadmpay"], tadmpay_income.Columns["nincome"]};


	//////////////////// ADMPAY_INCOMESORTED /////////////////////////////////
	var tadmpay_incomesorted= new DataTable("admpay_incomesorted");
	C= new DataColumn("yadmpay", typeof(int));
	C.AllowDBNull=false;
	tadmpay_incomesorted.Columns.Add(C);
	C= new DataColumn("nadmpay", typeof(int));
	C.AllowDBNull=false;
	tadmpay_incomesorted.Columns.Add(C);
	C= new DataColumn("nincome", typeof(int));
	C.AllowDBNull=false;
	tadmpay_incomesorted.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tadmpay_incomesorted.Columns.Add(C);
	C= new DataColumn("idsubclass", typeof(int));
	C.AllowDBNull=false;
	tadmpay_incomesorted.Columns.Add(C);
	C= new DataColumn("amount", typeof(decimal));
	C.AllowDBNull=false;
	tadmpay_incomesorted.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tadmpay_incomesorted.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tadmpay_incomesorted.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tadmpay_incomesorted.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tadmpay_incomesorted.Columns.Add(C);
	Tables.Add(tadmpay_incomesorted);
	tadmpay_incomesorted.PrimaryKey =  new DataColumn[]{tadmpay_incomesorted.Columns["idsor"], tadmpay_incomesorted.Columns["idsubclass"], tadmpay_incomesorted.Columns["nadmpay"], tadmpay_incomesorted.Columns["nincome"], tadmpay_incomesorted.Columns["yadmpay"]};


	//////////////////// ADMPAY_EXPENSESORTED /////////////////////////////////
	var tadmpay_expensesorted= new DataTable("admpay_expensesorted");
	C= new DataColumn("yadmpay", typeof(int));
	C.AllowDBNull=false;
	tadmpay_expensesorted.Columns.Add(C);
	C= new DataColumn("nadmpay", typeof(int));
	C.AllowDBNull=false;
	tadmpay_expensesorted.Columns.Add(C);
	C= new DataColumn("nexpense", typeof(int));
	C.AllowDBNull=false;
	tadmpay_expensesorted.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tadmpay_expensesorted.Columns.Add(C);
	C= new DataColumn("idsubclass", typeof(int));
	C.AllowDBNull=false;
	tadmpay_expensesorted.Columns.Add(C);
	C= new DataColumn("amount", typeof(decimal));
	C.AllowDBNull=false;
	tadmpay_expensesorted.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tadmpay_expensesorted.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tadmpay_expensesorted.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tadmpay_expensesorted.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tadmpay_expensesorted.Columns.Add(C);
	Tables.Add(tadmpay_expensesorted);
	tadmpay_expensesorted.PrimaryKey =  new DataColumn[]{tadmpay_expensesorted.Columns["idsor"], tadmpay_expensesorted.Columns["idsubclass"], tadmpay_expensesorted.Columns["nadmpay"], tadmpay_expensesorted.Columns["nexpense"], tadmpay_expensesorted.Columns["yadmpay"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{admpay_expense.Columns["yadmpay"], admpay_expense.Columns["nadmpay"], admpay_expense.Columns["nexpense"]};
	var cChild = new []{admpay_expensesorted.Columns["nexpense"], admpay_expensesorted.Columns["nadmpay"], admpay_expensesorted.Columns["yadmpay"]};
	Relations.Add(new DataRelation("admpay_expense_admpay_expensesorted",cPar,cChild,false));

	cPar = new []{admpay_income.Columns["yadmpay"], admpay_income.Columns["nadmpay"], admpay_income.Columns["nincome"]};
	cChild = new []{admpay_incomesorted.Columns["nincome"], admpay_incomesorted.Columns["nadmpay"], admpay_incomesorted.Columns["yadmpay"]};
	Relations.Add(new DataRelation("admpay_income_admpay_incomesorted",cPar,cChild,false));

	cPar = new []{admpay.Columns["yadmpay"], admpay.Columns["nadmpay"]};
	cChild = new []{admpay_income.Columns["yadmpay"], admpay_income.Columns["nadmpay"]};
	Relations.Add(new DataRelation("admpay_admpay_income",cPar,cChild,false));

	cPar = new []{admpay.Columns["yadmpay"], admpay.Columns["nadmpay"]};
	cChild = new []{admpay_expense.Columns["yadmpay"], admpay_expense.Columns["nadmpay"]};
	Relations.Add(new DataRelation("admpay_admpay_expense",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{admpay_assessment.Columns["idupb"]};
	Relations.Add(new DataRelation("upb_admpay_assessment",cPar,cChild,false));

	cPar = new []{fin.Columns["idfin"]};
	cChild = new []{admpay_assessment.Columns["idfin"]};
	Relations.Add(new DataRelation("fin_admpay_assessment",cPar,cChild,false));

	cPar = new []{incomeview.Columns["idinc"]};
	cChild = new []{admpay_assessment.Columns["idinc"]};
	Relations.Add(new DataRelation("incomeview_admpay_assessment",cPar,cChild,false));

	cPar = new []{admpay.Columns["yadmpay"], admpay.Columns["nadmpay"]};
	cChild = new []{admpay_assessment.Columns["yadmpay"], admpay_assessment.Columns["nadmpay"]};
	Relations.Add(new DataRelation("admpay_admpay_assessment",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{admpay_appropriation.Columns["idupb"]};
	Relations.Add(new DataRelation("upb_admpay_appropriation",cPar,cChild,false));

	cPar = new []{fin.Columns["idfin"]};
	cChild = new []{admpay_appropriation.Columns["idfin"]};
	Relations.Add(new DataRelation("fin_admpay_appropriation",cPar,cChild,false));

	cPar = new []{expenseview.Columns["idexp"]};
	cChild = new []{admpay_appropriation.Columns["idexp"]};
	Relations.Add(new DataRelation("expenseviewadmpay_appropriation",cPar,cChild,false));

	cPar = new []{admpay.Columns["yadmpay"], admpay.Columns["nadmpay"]};
	cChild = new []{admpay_appropriation.Columns["yadmpay"], admpay_appropriation.Columns["nadmpay"]};
	Relations.Add(new DataRelation("admpayadmpay_appropriation",cPar,cChild,false));

	#endregion

}
}
}
